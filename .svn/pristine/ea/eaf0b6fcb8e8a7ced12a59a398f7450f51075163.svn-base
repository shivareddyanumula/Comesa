using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SMHR;
using Telerik.Web.UI;
public partial class Payroll_frm_Gratuityapproval : System.Web.UI.Page
{
    SMHR_GRATUITY _obj_gratuity = new SMHR_GRATUITY();
    SMHR_LOGININFO _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
    DataTable dt_null = new DataTable();
    DataTable dt_businessunits = new DataTable();
    #region Pageload
    /// <summary>
    /// loading Business units based on the user login
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("GRATUITY APPROVAL");
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
                    RG_Approve.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Approve.Visible = false;
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

                btn_Approve.Visible = false;
                RG_Approve.DataSource = dt_null;
                RG_Approve.DataBind();
                RG_Approve.Visible = false;
                _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
                _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"].ToString());
                rcmb_Businessunit.Items.Clear();
                dt_businessunits = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
                rcmb_Businessunit.DataSource = dt_businessunits;
                rcmb_Businessunit.DataTextField = "BUSINESSUNIT_CODE";
                rcmb_Businessunit.DataValueField = "BUSINESSUNIT_ID";
                rcmb_Businessunit.DataBind();
                rcmb_Businessunit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));



            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Gratuityapproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    #endregion
    #region Businessunit
    /// <summary>
    /// it will loads the people who are sent for approval for the gratutity
    /// </summary>
    /// <param name="o"></param>
    /// <param name="e"></param>
    protected void rcmb_Businessunit_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            RG_Approve.Visible = true;
            if (rcmb_Businessunit.SelectedIndex != 0)
            {
                DataTable dt = new DataTable();
                _obj_gratuity.EMP_BUID = Convert.ToInt32(rcmb_Businessunit.SelectedValue.ToString());
                _obj_gratuity.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                dt = BLL.get_gratuityemp(_obj_gratuity);
                if (dt.Rows.Count > 0)
                {
                    RG_Approve.DataSource = dt;
                    RG_Approve.DataBind();


                    if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                    {
                        btn_Approve.Visible = false;
                    }
                    else
                    {
                        btn_Approve.Visible = true;
                    }
                }
                else
                {
                    BLL.ShowMessage(this, "All Employees Were Approved For The Selected Business unit");
                    btn_Approve.Enabled = false;
                    RG_Approve.DataSource = dt_null;
                    RG_Approve.DataBind();
                    RG_Approve.Visible = true;
                }
            }
            else
            {
                BLL.ShowMessage(this, "Select A Businessunit!");
                RG_Approve.DataSource = dt_null;
                RG_Approve.DataBind();
                btn_Approve.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Gratuityapproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion
    #region Approving Employees
    /// <summary>
    /// approving employees based on the business unit he has selected
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_Approve_Click(object sender, EventArgs e)
    {
        try
        {
            int count = 0;
            for (int index = 0; index < RG_Approve.Items.Count; index++)
            {
                btn_Approve.Enabled = true;
                btn_Approve.Visible = true;
                _obj_gratuity.OPERATION = operation.Update;
                _obj_gratuity.EMP_ID = Convert.ToInt32(RG_Approve.Items[index]["EMP_ID"].Text);
                _obj_gratuity.Emp_status = 1;
                _obj_gratuity.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                int Iresult = Convert.ToInt32(BLL.set_Gratutityemp(_obj_gratuity));
                if (Iresult >= 1)
                {
                    count++;
                }
            }
            BLL.ShowMessage(this, "Total Records Approved Are:" + count);
            btn_Approve.Enabled = false;
            RG_Approve.DataSource = dt_null;
            RG_Approve.DataBind();
            RG_Approve.Visible = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Gratuityapproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            rcmb_Businessunit.SelectedIndex = 0;
            RG_Approve.DataSource = dt_null;
            RG_Approve.DataBind();
            btn_Approve.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Gratuityapproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
