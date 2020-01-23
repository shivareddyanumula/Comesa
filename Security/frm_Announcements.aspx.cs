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


public partial class Security_frm_Announcements : System.Web.UI.Page
{
    SMHR_ANNOUNCEMENT obj_smhr_announcement;
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Announcement/Events");//ANNOUNCEMENT_EVENTS");
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
                    rg_Main.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
                loadGrid();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Announcements", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            rmp_MainPage.SelectedIndex = 1;
            txt_Title.Text = "";
            txt_Description.Text = "";
            btn_Save.Visible = true;
            btn_Update.Visible = false;
            rdp_ExpiryDate.SelectedDate = null;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Announcements", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            //int I_ID = Convert.ToInt32(e.CommandArgument);
            rmp_MainPage.SelectedIndex = 1;
            btn_Save.Visible = false;
            btn_Update.Visible = true;
            btn_Cancel.Visible = true;
            Session["I_ID"] = Convert.ToString(e.CommandArgument);
            obj_smhr_announcement = new SMHR_ANNOUNCEMENT();
            obj_smhr_announcement.ANNCE_ID = Convert.ToInt32(e.CommandArgument);
            obj_smhr_announcement.ANNCE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            obj_smhr_announcement.OPERATION = operation.Edit;
            DataTable dt_Edit = BLL.get_Announcement(obj_smhr_announcement);
            if (dt_Edit.Rows.Count > 0)
            {
                txt_Title.Text = Convert.ToString(dt_Edit.Rows[0]["ANNCE_TITLE"]);
                txt_Description.Text = Convert.ToString(dt_Edit.Rows[0]["ANNCE_MESSAGE"]);
                rdp_ExpiryDate.SelectedDate = Convert.ToDateTime(dt_Edit.Rows[0]["ANNCE_EXP_DATE"]);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Announcements", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            obj_smhr_announcement = new SMHR_ANNOUNCEMENT();
            obj_smhr_announcement.ANNCE_TITLE = Convert.ToString(txt_Title.Text.Replace("'", "''"));
            obj_smhr_announcement.ANNCE_MESSAGE = Convert.ToString(txt_Description.Text.Replace("'", "''"));
            obj_smhr_announcement.ANNCE_EXP_DATE = Convert.ToDateTime(rdp_ExpiryDate.SelectedDate);
            obj_smhr_announcement.ANNCE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_SAVE":

                    obj_smhr_announcement.ANNCE_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    obj_smhr_announcement.ANNCE_CREATEDDATE = Convert.ToDateTime(DateTime.Now);
                    obj_smhr_announcement.OPERATION = operation.Insert;
                    if (BLL.set_Announcement(obj_smhr_announcement))
                    {
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    }
                    break;
                case "BTN_UPDATE":
                    obj_smhr_announcement.ANNCE_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    obj_smhr_announcement.ANNCE_LASTMDFDATE = Convert.ToDateTime(DateTime.Now);
                    obj_smhr_announcement.ANNCE_ID = Convert.ToInt32(Session["I_ID"]);
                    obj_smhr_announcement.OPERATION = operation.Update;
                    if (BLL.set_Announcement(obj_smhr_announcement))
                    {
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    }
                    break;
                default:
                    break;
            }
            rmp_MainPage.SelectedIndex = 0;
            loadGrid();
            rg_Main.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Announcements", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Update_Click(object sender, EventArgs e)
    {

    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            rmp_MainPage.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Announcements", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void getDetails()
    {


    }

    public void loadGrid()
    {
        try
        {
            obj_smhr_announcement = new SMHR_ANNOUNCEMENT();
            obj_smhr_announcement.OPERATION = operation.Select;
            obj_smhr_announcement.ANNCE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_loadGrid = BLL.get_Announcement(obj_smhr_announcement);
            rg_Main.DataSource = dt_loadGrid;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Announcements", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rg_Main_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            loadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Announcements", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
