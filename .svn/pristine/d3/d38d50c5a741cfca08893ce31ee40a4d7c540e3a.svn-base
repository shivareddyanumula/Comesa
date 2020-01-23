using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using System.Text;
using Telerik.Web.UI;

public partial class Masters_EmployeeLoanStatus : System.Web.UI.Page
{
    string Control;
    protected void Page_Load(object sender, EventArgs e)
    {
        // Control = Convert.ToString(Request.QueryString["Control"]);

        try
        {
            if (!Page.IsPostBack)
            {

                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Employee Loan Status");//COUNTRY");
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
                    return;
                }


                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    Rg_HrMamager.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
                    return;
                }
                Control = Convert.ToString(Request.QueryString["Control"]);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeLoanStatus", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Rg_HrMamager_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadData();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeLoanStatus", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

    }

    private void LoadData()
    {
        try
        {
            DataTable dt;
            //if (Convert.ToInt32(Session["EMP_ID"]) == 0)
            //{
            //    SMHR_LOANREQUEST _obj_smhr_empcompoff = new SMHR_LOANREQUEST();
            //    _obj_smhr_empcompoff.OPERATION = operation.Select3;
            //    _obj_smhr_empcompoff.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //    //_obj_smhr_empcompoff.lOANREQUEST_EMPLOYEEID = 57;// Convert.ToInt32(Session["EMP_ID"]);
            //    dt = BLL.get_EmployeeLoanFinalstatus(_obj_smhr_empcompoff);
            //    Rg_HrMamager.DataSource = dt;
            //}
            //else
            //{
            //    SMHR_LOANREQUEST _obj_smhr_empcompoff = new SMHR_LOANREQUEST();
            //    _obj_smhr_empcompoff.OPERATION = operation.Select_Self;
            //    _obj_smhr_empcompoff.lOANREQUEST_EMPLOYEEID = Convert.ToInt32(Session["EMP_ID"]);
            //    dt = BLL.get_EmployeeLoanFinalstatus(_obj_smhr_empcompoff);
            //    Rg_HrMamager.DataSource = dt;
            //}
            if (Control != null)
            {
                if ((Convert.ToString(Session["SELFSERVICE"]) == "true" && Control.ToUpper() == "SELFLOAN") || (Convert.ToString(Session["SELFSERVICE"]) == "" && Control.ToUpper() == "SELFLOAN"))
                {
                    SMHR_LOANREQUEST _obj_smhr_empcompoff = new SMHR_LOANREQUEST();
                    _obj_smhr_empcompoff.OPERATION = operation.Select_Self;
                    _obj_smhr_empcompoff.lOANREQUEST_EMPLOYEEID = Convert.ToInt32(Session["EMP_ID"]);
                    dt = BLL.get_EmployeeLoanFinalstatus(_obj_smhr_empcompoff);
                    Rg_HrMamager.DataSource = dt;
                }
                else
                {
                    BLL.ShowMessage(this, "You do not have Accecc on this Screen!");
                    return;
                }
            }
            else
            {
                SMHR_LOANREQUEST _obj_smhr_empcompoff = new SMHR_LOANREQUEST();
                _obj_smhr_empcompoff.OPERATION = operation.Select3;
                _obj_smhr_empcompoff.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //_obj_smhr_empcompoff.lOANREQUEST_EMPLOYEEID = 57;// Convert.ToInt32(Session["EMP_ID"]);
                dt = BLL.get_EmployeeLoanFinalstatus(_obj_smhr_empcompoff);
                Rg_HrMamager.DataSource = dt;
            }
            dt.Columns.Add("SI_NO");
            if (dt.Rows.Count != 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    dt.Rows[j]["SI_NO"] = j + 1;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeLoanStatus", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

    }
}
