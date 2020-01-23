using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using Telerik.Web.UI;

public partial class HR_frmEmployeeDetails : System.Web.UI.Page
{
    SMHR_EMPLOYEE _obj_smhr_Employee;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit;
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (!Page.IsPostBack)
            {
                Session.Remove("WRITEFACILITY");
                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Employee Search");//EMPLOYEEDETAILS");
                DataTable dtformdtls = BLL.get_LoginInfo(_obj_Smhr_LoginInfo);
                if (dtformdtls.Rows.Count != 0)
                {
                    if ((Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_READ"]) == true) && (Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_WRITE"]) == true))
                    {
                        Session["WRITEFACILITY"] = 1;//WHICH MEANS READ AND WRITE
                    }
                    else if ((Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_READ"]) == true) && (Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_WRITE"]) == false))
                    {
                        Session["WRITEFACILITY"] = 2;//WHICH MEANS READ NO WRITE
                    }
                    else if ((Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_READ"]) == false) && (Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_WRITE"]) == false))
                    {
                        Session["WRITEFACILITY"] = 3;//WHICH MEANS NO READ AND NO WRITE
                    }

                }
                else
                {
                    smhr_UNAUTHORIZED _obj_smhr_unauthorized = new smhr_UNAUTHORIZED();
                    _obj_smhr_unauthorized.UNAUTHORIZED_USERID = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_unauthorized.UNAUTHORIZED_FORMID = Convert.ToInt32(ViewState["FORMS_ID"]);
                    _obj_smhr_unauthorized.UNAUTHORIZED_MODULEID = Convert.ToInt32(ViewState["MODULE_ID"]);
                    _obj_smhr_unauthorized.UNAUTHORIZED_ACCESSDATE = Convert.ToDateTime(DateTime.Now.ToString());
                    SMHR.BLL.UnAuthorized_Log(_obj_smhr_unauthorized);
                    Response.Redirect("~/frm_UnAuthorized.aspx", false);
                }
                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    rgMain.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    //btn_Save.Visible = false;
                    //btn_Update.Visible = false;
                }
                else if (Convert.ToInt32(Session["WRITEFACILITY"]) == 3)
                {
                    smhr_UNAUTHORIZED _obj_smhr_unauthorized = new smhr_UNAUTHORIZED();
                    _obj_smhr_unauthorized.UNAUTHORIZED_USERID = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_unauthorized.UNAUTHORIZED_FORMID = Convert.ToInt32(ViewState["FORMS_ID"]);
                    _obj_smhr_unauthorized.UNAUTHORIZED_MODULEID = Convert.ToInt32(ViewState["MODULE_ID"]);
                    _obj_smhr_unauthorized.UNAUTHORIZED_ACCESSDATE = Convert.ToDateTime(DateTime.Now.ToString());
                    SMHR.BLL.UnAuthorized_Log(_obj_smhr_unauthorized);
                    Response.Redirect("~/frm_UnAuthorized.aspx", false);
                }

                loadBusinessUnit();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEmployeeDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void rgMain_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            loadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEmployeeDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void loadGrid()
    {
        try
        {
            _obj_smhr_Employee = new SMHR_EMPLOYEE();
            if (Convert.ToInt32(rcmbBusinessUnit.SelectedValue) == -1)
            {
                _obj_smhr_Employee.OPERATION = operation.EMPALL;
                _obj_smhr_Employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_Details = BLL.getEmpDetails(_obj_smhr_Employee);
                rgMain.DataSource = dt_Details;
            }
            else
            {
                _obj_smhr_Employee.OPERATION = operation.EMPDETAILS;
                _obj_smhr_Employee.EMP_BUSINESSUNIT_ID = Convert.ToInt32(rcmbBusinessUnit.SelectedValue);
                _obj_smhr_Employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt = BLL.getEmpDetails(_obj_smhr_Employee);
                if (dt.Rows.Count > 0)
                {
                    rgMain.DataSource = dt;
                    // rgMain.DataBind();
                }
                else
                {
                    DataTable dtEmpty = new DataTable();
                    rgMain.DataSource = dtEmpty;
                    //rgMain.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEmployeeDetails.aspx", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void loadBusinessUnit()
    {
        try
        {
            rcmbBusinessUnit.Items.Clear();
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.OPERATION = operation.Select;
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //_obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            //DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            DataTable dt_BUDetails = BLL.get_Sup_BusinessUnit(_obj_SMHR_LoginInfo);
            rcmbBusinessUnit.DataSource = dt_BUDetails;
            rcmbBusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            rcmbBusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            rcmbBusinessUnit.DataBind();

            _obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
            _obj_Smhr_BusinessUnit.OPERATION = operation.Validate1;
            _obj_Smhr_BusinessUnit.BUSINESSUNIT_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            _obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtBu = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
            if (dtBu.Rows.Count > 0)
            {
                string strBuid = Convert.ToString(dtBu.Rows[0]["BUSINESSUNIT_ID"]);
                string strBusinessUnit = Convert.ToString(dtBu.Rows[0]["BUSINESSUNIT_CODE"]);
                rcmbBusinessUnit.SelectedIndex = rcmbBusinessUnit.Items.FindItemIndexByValue(Convert.ToString(strBuid));
            }
            rcmbBusinessUnit.Items.Insert(rcmbBusinessUnit.Items.Count(), new Telerik.Web.UI.RadComboBoxItem("All", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEmployeeDetails.aspx", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmbBusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            loadGrid();
            rgMain.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEmployeeDetails.aspx", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    //protected void btnSearch_Click(object sender, EventArgs e)
    //{

    //}
}
