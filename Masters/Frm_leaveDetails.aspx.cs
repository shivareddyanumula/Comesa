using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SMHR;
using System.IO;
using Telerik.Web.UI;


public partial class PBLL
{
    public static DataTable get_LeaveApp(SMHR_LEAVEAPP _obj_Smhr_LeaveApp)
    {

        return BLL.ExecuteQuery("EXEC USP_SMHR_LEAVEAPP @Operation = 'LEAVEDETAILSROLLBACK', @ORGANISATION_ID = " + _obj_Smhr_LeaveApp.ORGANISATION_ID + ",@EMP_LOGIN_ID='" + _obj_Smhr_LeaveApp.LOGIN_ID + "',@LEAVEAPP_EMP_ID = " + _obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID + "");
        

    }
}
public partial class Masters_Frm_leaveDetails : System.Web.UI.Page
{
    string control = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {


                //Session.Remove("WRITEFACILITY");
                //SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                //_obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                //_obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                //_obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //_obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Employee Leaves Details");//KENYAPAYITEM");
                //DataTable dtformdtls = BLL.get_LoginInfo(_obj_Smhr_LoginInfo);
                //if (dtformdtls.Rows.Count != 0)
                //{
                //    if ((Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_READ"]) == true) && (Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_WRITE"]) == true))
                //    {
                //        Session["WRITEFACILITY"] = 1;//WHICH MEANS READ AND WRITE
                //    }
                //    else if ((Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_READ"]) == true) && (Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_WRITE"]) == false))
                //    {
                //        Session["WRITEFACILITY"] = 2;//WHICH MEANS READ NO WRITE
                //    }
                //    else if ((Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_READ"]) == false) && (Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_WRITE"]) == false))
                //    {
                //        Session["WRITEFACILITY"] = 3;//WHICH MEANS NO READ AND NO WRITE
                //    }

                //}
                //else
                //{
                //    smhr_UNAUTHORIZED _obj_smhr_unauthorized = new smhr_UNAUTHORIZED();
                //    _obj_smhr_unauthorized.UNAUTHORIZED_USERID = Convert.ToInt32(Session["USER_ID"]);
                //    _obj_smhr_unauthorized.UNAUTHORIZED_FORMID = Convert.ToInt32(ViewState["FORMS_ID"]);
                //    _obj_smhr_unauthorized.UNAUTHORIZED_MODULEID = Convert.ToInt32(ViewState["MODULE_ID"]);
                //    _obj_smhr_unauthorized.UNAUTHORIZED_ACCESSDATE = Convert.ToDateTime(DateTime.Now.ToString());
                //    SMHR.BLL.UnAuthorized_Log(_obj_smhr_unauthorized);
                //    Response.Redirect("~/frm_UnAuthorized.aspx", false);
                //}
                //if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                //{
                //    Rg_LeaveApp.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                //}
                //else if (Convert.ToInt32(Session["WRITEFACILITY"]) == 3)
                //{
                //    smhr_UNAUTHORIZED _obj_smhr_unauthorized = new smhr_UNAUTHORIZED();
                //    _obj_smhr_unauthorized.UNAUTHORIZED_USERID = Convert.ToInt32(Session["USER_ID"]);
                //    _obj_smhr_unauthorized.UNAUTHORIZED_FORMID = Convert.ToInt32(ViewState["FORMS_ID"]);
                //    _obj_smhr_unauthorized.UNAUTHORIZED_MODULEID = Convert.ToInt32(ViewState["MODULE_ID"]);
                //    _obj_smhr_unauthorized.UNAUTHORIZED_ACCESSDATE = Convert.ToDateTime(DateTime.Now.ToString());
                //    SMHR.BLL.UnAuthorized_Log(_obj_smhr_unauthorized);
                //    Response.Redirect("~/frm_UnAuthorized.aspx", false);
                //}
                control = Convert.ToString(Request.QueryString["Control"]);
                if (control == "rollback")
                {
                    Rg_LeaveApp.Visible = false;
                    Rg_rollback.Visible = true;
                }
                else
                {
                    Rg_LeaveApp.Visible = true;
                    Rg_rollback.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_leaveDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
   
    public void LoadGrid()
    {
        try
        {
            SMHR_LEAVEAPP _obj_smhr_leaveApp = new SMHR_LEAVEAPP();
            _obj_smhr_leaveApp.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_leaveApp.LEAVEAPP_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            _obj_smhr_leaveApp.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_leaveApp.OPERATION = operation.Available;
            DataTable dt_Details = BLL.get_LeaveApp(_obj_smhr_leaveApp);
            Rg_LeaveApp.DataSource = dt_Details;
            //  Rg_LeaveApp.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_leaveDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    public void LoadGridrolb()
    {
        try
        {
            SMHR_LEAVEAPP _obj_smhr_leaveApp = new SMHR_LEAVEAPP();
            _obj_smhr_leaveApp.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_leaveApp.LEAVEAPP_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            _obj_smhr_leaveApp.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            //_obj_smhr_leaveApp.OPERATION = operation.Available;
            DataTable dt_Details = PBLL.get_LeaveApp(_obj_smhr_leaveApp);
            Rg_rollback.DataSource = dt_Details;
            //  Rg_LeaveApp.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_leaveDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    
    protected void Rg_LeaveApp_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_leaveDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Rollback_click(object sender, CommandEventArgs e)
    {
        try
        {
            SMHR_LEAVEAPP _obj_smhr_leaveApp1 = new SMHR_LEAVEAPP();
            _obj_smhr_leaveApp1.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_leaveApp1.LEAVEAPP_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            _obj_smhr_leaveApp1.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_leaveApp1.OPERATION = operation.Available;
            DataTable dt_Details = BLL.get_LeaveApp(_obj_smhr_leaveApp1);
            SMHR_LEAVEAPP _obj_smhr_leaveapp = new SMHR_LEAVEAPP();
            string str = Convert.ToString(e.CommandArgument);
            _obj_smhr_leaveapp = new SMHR_LEAVEAPP();
            _obj_smhr_leaveapp.LEAVEAPP_STATUS = 3;
            _obj_smhr_leaveapp.LEAVEAPP_EMP_ID = Convert.ToInt32(dt_Details.Rows[0]["EMP_ID"]);
            //_obj_smhr_leaveapp.LEAVEAPP_APPROVEDBY = Convert.ToInt32(Convert.ToString(Session["EMP_ID"]));
            _obj_smhr_leaveapp.LEAVEAPP_APPROVEDATE = Convert.ToDateTime((dt_Details.Rows[0]["LEAVEAPP_TODATE"]));
            _obj_smhr_leaveapp.LEAVE_ROLLBACKDATE = DateTime.Now;
            _obj_smhr_leaveapp.LASTMDFBY = Convert.ToInt32(Convert.ToString(Session["EMP_ID"]));
            _obj_smhr_leaveapp.LEAVEAPP_ID = Convert.ToInt32(e.CommandArgument);
            _obj_smhr_leaveapp.LASTMDFDATE = DateTime.Now;
            _obj_smhr_leaveapp.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_leaveapp.LEAVEAPP_LEAVETYPE_ID = Convert.ToInt32(dt_Details.Rows[0]["LEAVETYPEID"]);

            _obj_smhr_leaveapp.OPERATION = operation.Delete1;
            BLL.set_LeaveApp(_obj_smhr_leaveapp);
            SMHR_LEAVEBALANCE _obj_smhr_leavebal = new SMHR_LEAVEBALANCE();
            _obj_smhr_leavebal.LT_LEAVETYPEID = Convert.ToInt32(dt_Details.Rows[0]["LEAVETYPEID"]);
            _obj_smhr_leavebal.OPERATION = operation.Update;
            _obj_smhr_leavebal.EMPNAME = Convert.ToString(dt_Details.Rows[0]["EMP_ID"]);
            _obj_smhr_leavebal.ORGANISATION_ID = Convert.ToInt32(Convert.ToString(Session["org_ID"]));
            _obj_smhr_leavebal.MODE = 8;
            _obj_smhr_leavebal.NDays = float.Parse(Convert.ToString(dt_Details.Rows[0]["LEAVEAPP_DAYS"]));
            _obj_smhr_leavebal.LEAVEAPP_ID = Convert.ToInt32(e.CommandArgument);
            _obj_smhr_leavebal.CREATEDDATE = Convert.ToDateTime((dt_Details.Rows[0]["LEAVEAPP_TODATE"]));
            bool rs = BLL.set_leavebalances(_obj_smhr_leavebal);
            if (rs == true)
            {
                //BLL.ShowMessage(this, "Leave Successfully Rolled back");
            
            SMHR_LEAVEAPP _obj_Smhr_LeaveApp = new SMHR_LEAVEAPP();
            _obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            _obj_Smhr_LeaveApp.ORGANISATION_ID = Convert.ToInt32(Convert.ToString(Session["org_ID"]));
            _obj_Smhr_LeaveApp.LEAVEAPP_FROMDATE = Convert.ToDateTime((dt_Details.Rows[0]["LEAVEAPP_FROMDATE"]));
            _obj_Smhr_LeaveApp.LEAVEAPP_TODATE = Convert.ToDateTime((dt_Details.Rows[0]["LEAVEAPP_TODATE"]));
            _obj_Smhr_LeaveApp.LEAVEAPP_DAYS = float.Parse(Convert.ToString(dt_Details.Rows[0]["LEAVEAPP_DAYS"]));
            _obj_Smhr_LeaveApp.LEAVEAPP_ID = Convert.ToInt32(e.CommandArgument);
            _obj_Smhr_LeaveApp.MODE = 4;
            DataTable dt_mail = BLL.get_EmpLeaveDetails(_obj_Smhr_LeaveApp);
            if (dt_mail.Rows.Count > 0)
            {
                //if (!((dt_mail.Rows[0]["REPORTING_EMP_EMAIL"] != System.DBNull.Value && dt_mail.Rows[0]["REPORTING_EMP_EMAIL"] != string.Empty) || (dt_mail.Rows[0]["EMP_EMAIL"] != System.DBNull.Value && dt_mail.Rows[0]["EMP_EMAIL"] != string.Empty) || (dt_mail.Rows[0]["REPORTING_EMP"] != System.DBNull.Value && dt_mail.Rows[0]["REPORTING_EMP"] != string.Empty)))
                if (((Convert.ToString(dt_mail.Rows[0]["REPORTING_EMP_EMAIL"]) != string.Empty) && (dt_mail.Rows[0]["REPORTING_EMP_EMAIL"]) != System.DBNull.Value)
                    && ((Convert.ToString(dt_mail.Rows[0]["EMP_EMAIL"]) != string.Empty) && (dt_mail.Rows[0]["EMP_EMAIL"]) != System.DBNull.Value)
                    && ((Convert.ToString(dt_mail.Rows[0]["REPORTING_EMP"]) != string.Empty) && ((dt_mail.Rows[0]["REPORTING_EMP"]) != System.DBNull.Value)))
                {
                    _obj_Smhr_LeaveApp.MODE = 5;
                    if (BLL.get_Leave_Mail(_obj_Smhr_LeaveApp))
                    {
                        BLL.ShowMessage(this, "Leave Successfully Rolled back and Mail Sent");
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Mail Not Sent");
                    }
                }
            }
            else
            {
                BLL.ShowMessage(this, "Leave Successfully Rolled back but Mail not Sent");
            }
        }
            LoadGridrolb();
            Rg_rollback.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_leaveDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


    }

    protected void Rg_LeaveApp_NeedDataSourcerollback(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {


            LoadGridrolb();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_leaveDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    
}