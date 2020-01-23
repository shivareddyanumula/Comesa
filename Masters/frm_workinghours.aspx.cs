using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Data;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;


public partial class Masters_frm_workinghours : System.Web.UI.Page
{
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Working Hours");//WORKINGHOURS");
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
                    Rg_WHours.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Save.Visible = false;
                    btn_Edit.Visible = false;
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

                Page.Validate();
                if (Request.QueryString["POP"] != null)
                {
                    ((HtmlTableRow)Master.FindControl("M_Header")).Style.Add("display", "none");
                    ((HtmlTableRow)Master.FindControl("M_Footer")).Style.Add("display", "none");
                    ((RadMenu)Master.FindControl("MainMenu")).Style.Add("display", "none");
                    ((RadComboBox)Master.FindControl("cmbCulture")).Style.Add("display", "none");
                    ((LinkButton)Master.FindControl("Lnk_LogOut")).Style.Add("display", "none");
                    ((LinkButton)Master.FindControl("lnk_Home")).Style.Add("display", "none");
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_workinghours", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            loadDropdown();
            clearControls();
            DataTable dt = BLL.get_WorkingHours(new SMHR_WORKINGHOURS(Convert.ToInt32(Convert.ToString(e.CommandArgument))));

            lbl_WHoursID.Text = Convert.ToString(dt.Rows[0]["WRKHRS_ID"]);
            rcmb_WHoursBunitID.SelectedIndex = rcmb_WHoursBunitID.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["WRKHRS_BUSINESSUNIT_ID"]));
            rcmb_WHoursDay.SelectedIndex = rcmb_WHoursDay.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["WRKHRS_DAY_ID"]));
            rntxt_WhoursHours.Text = Convert.ToString(dt.Rows[0]["WRKHRS_NOOFHOURS"]);
            rtp_WhoursStartTime.SelectedDate = Convert.ToDateTime(dt.Rows[0]["WRKHRS_STARTTIME"]);
            rtp_WhoursEndTime.SelectedDate = Convert.ToDateTime(dt.Rows[0]["WRKHRS_ENDTIME"]);

            if (Convert.ToString(Request.QueryString["ID"]) == null)
                rcmb_WHoursBunitID.Enabled = true;
            else
                rcmb_WHoursBunitID.Enabled = false;

            //code for security
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Edit.Visible = false;

            }

            else
            {
                btn_Edit.Visible = true;
            }
            Rm_WH_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_workinghours", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            loadDropdown();
            clearControls();
            btn_Save.Visible = true;
            Rm_WH_page.SelectedIndex = 1;

            if (Convert.ToString(Request.QueryString["ID"]) == null)
            {
                rcmb_WHoursBunitID.SelectedIndex = 0;
                rcmb_WHoursBunitID.Enabled = true;
            }
            else
            {
                rcmb_WHoursBunitID.SelectedIndex = rcmb_WHoursBunitID.FindItemIndexByValue(Convert.ToString(Request.QueryString["ID"]));
                rcmb_WHoursBunitID.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_workinghours", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    public void LoadGrid()
    {
        try
        {
            SMHR_WORKINGHOURS _obj_Smhr_WorkingHours = new SMHR_WORKINGHOURS();

            if (Convert.ToString(Request.QueryString["ID"]) == null)
            {
                _obj_Smhr_WorkingHours.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                DataTable DT = BLL.get_WorkingHours(_obj_Smhr_WorkingHours);
                Rg_WHours.DataSource = DT;
                clearControls();
            }
            else
            {

                _obj_Smhr_WorkingHours.OPERATION = operation.Empty;
                _obj_Smhr_WorkingHours.WRKHRS_BUSINESSUNIT_ID = Convert.ToInt32(Convert.ToString(Request.QueryString["ID"]));
                Rg_WHours.DataSource = BLL.get_WorkingHours(_obj_Smhr_WorkingHours);
                clearControls();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_workinghours", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void loadDropdown()
    {
        try
        {
            rcmb_WHoursBunitID.Items.Clear();
            //SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
            //_obj_Smhr_BusinessUnit.OPERATION = operation.Select;
            //_obj_Smhr_BusinessUnit.ISDELETED = true; 
            //rcmb_WHoursBunitID.DataSource = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
            //rcmb_WHoursBunitID.DataTextField = "BUSINESSUNIT_CODE";
            //rcmb_WHoursBunitID.DataValueField = "BUSINESSUNIT_ID";
            //rcmb_WHoursBunitID.DataBind();
            //rcmb_WHoursBunitID.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

            SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
            _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"].ToString());
            rcmb_WHoursBunitID.Items.Clear();
            rcmb_WHoursBunitID.DataSource = BLL.get_Business_Units(_obj_smhr_logininfo);
            rcmb_WHoursBunitID.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_WHoursBunitID.DataValueField = "BUSINESSUNIT_ID";
            rcmb_WHoursBunitID.DataBind();
            rcmb_WHoursBunitID.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            rcmb_WHoursDay.Items.Clear();
            rcmb_WHoursDay.DataSource = BLL.get_Days();
            rcmb_WHoursDay.DataTextField = "DAY_NAME";
            rcmb_WHoursDay.DataValueField = "DAY_ID";
            rcmb_WHoursDay.DataBind();
            rcmb_WHoursDay.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_workinghours", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_WORKINGHOURS _obj_Smhr_WorkingHours = new SMHR_WORKINGHOURS();
            _obj_Smhr_WorkingHours.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_Smhr_WorkingHours.WRKHRS_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_WHoursBunitID.SelectedItem.Value);
            _obj_Smhr_WorkingHours.WRKHRS_DAY_ID = Convert.ToInt32(rcmb_WHoursDay.SelectedItem.Value);
            _obj_Smhr_WorkingHours.WRKHRS_NOOFHOURS = Convert.ToInt32(rntxt_WhoursHours.Text);
            _obj_Smhr_WorkingHours.WRKHRS_STARTTIME = Convert.ToString(Convert.ToDateTime(rtp_WhoursStartTime.SelectedDate).TimeOfDay);
            _obj_Smhr_WorkingHours.WRKHRS_ENDTIME = Convert.ToString(Convert.ToDateTime(rtp_WhoursEndTime.SelectedDate).TimeOfDay);

            _obj_Smhr_WorkingHours.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session 
            _obj_Smhr_WorkingHours.CREATEDDATE = DateTime.Now;

            _obj_Smhr_WorkingHours.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_WorkingHours.LASTMDFDATE = DateTime.Now;

            if (Convert.ToInt32(rntxt_WhoursHours.Text) > 0 && rtp_WhoursStartTime.SelectedDate != null && rtp_WhoursEndTime.SelectedDate != null)
            {
                //if (rtp_WhoursStartTime.SelectedDate != null && rtp_WhoursEndTime.SelectedDate != null)
                //{
                if (rtp_WhoursStartTime.SelectedDate > rtp_WhoursEndTime.SelectedDate)
                {
                    BLL.ShowMessage(this, "End Time cannot be less than Start Time");
                    return;
                }
                else
                {
                    DateTime EndTime = Convert.ToDateTime(rtp_WhoursEndTime.SelectedDate);
                    DateTime StartTime = Convert.ToDateTime(rtp_WhoursStartTime.SelectedDate);

                    TimeSpan span = EndTime - StartTime;
                    int hrs = span.Hours;
                    if (hrs != Convert.ToInt32(rntxt_WhoursHours.Text))
                    {
                        BLL.ShowMessage(this, "Working hours must match with No. of Hours");
                        return;
                    }
                }
                //}
            }
            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_EDIT":
                    _obj_Smhr_WorkingHours.WRKHRS_ID = Convert.ToInt32(lbl_WHoursID.Text);
                    _obj_Smhr_WorkingHours.OPERATION = operation.Check;
                    if (Convert.ToString(BLL.get_WorkingHours(_obj_Smhr_WorkingHours).Rows[0]["Count"]) != "1")
                    {
                        BLL.ShowMessage(this, "Working Hours for this day to this Business Unit Already Exists");
                        return;
                    }
                    _obj_Smhr_WorkingHours.OPERATION = operation.Update;
                    if (BLL.set_WorkingHours(_obj_Smhr_WorkingHours))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");

                    break;
                case "BTN_SAVE":
                    _obj_Smhr_WorkingHours.OPERATION = operation.Check;
                    if (Convert.ToString(BLL.get_WorkingHours(_obj_Smhr_WorkingHours).Rows[0]["Count"]) != "0")
                    {
                        BLL.ShowMessage(this, "Working Hours for this day to this Business Unit Already Exists");
                        return;
                    }
                    _obj_Smhr_WorkingHours.OPERATION = operation.Insert;
                    if (BLL.set_WorkingHours(_obj_Smhr_WorkingHours))
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                default:
                    break;
            }
            Rm_WH_page.SelectedIndex = 0;
            LoadGrid();
            Rg_WHours.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_workinghours", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void clearControls()
    {
        try
        {
            lbl_WHoursID.Text = string.Empty;
            rcmb_WHoursBunitID.SelectedIndex = -1;
            rcmb_WHoursDay.SelectedIndex = -1;
            rntxt_WhoursHours.Text = string.Empty;
            rtp_WhoursStartTime.SelectedDate = null;
            rtp_WhoursEndTime.SelectedDate = null;

            btn_Save.Visible = false;
            btn_Edit.Visible = false;
            Rm_WH_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_workinghours", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_workinghours", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rg_WHours_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_workinghours", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
