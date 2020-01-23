﻿using System;
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
public partial class Payroll_frm_Leaveapplication : System.Web.UI.Page
{
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_ATTENDANCE _obj_SMHR_Attendence;
    DataTable dt_mail;
    string Control;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "function pageLoad(){   }", true);

            Control = Convert.ToString(Request.QueryString["Control"]);
            if (!Page.IsPostBack)
            {
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                if (Control != null)
                {
                    if (Control.ToUpper() == "SELFLEAVE")
                    {
                        _obj_Smhr_LoginInfo.LOGIN_ID = 12;
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("LEAVE APPLICATION");
                    }
                }
                else
                {
                    _obj_Smhr_LoginInfo.LOGIN_ID = 14;
                    _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("LEAVE APPLICATION");
                }
                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //_obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("LEAVEAPPLICATION");
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
                    Rg_LeaveApp.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Save.Visible = false;
                    btn_Calc.Visible = false;
                    // added to support Only-View functionality.
                    foreach (GridColumn col in Rg_LeaveApp.Columns)
                    {
                        if (col.UniqueName == "ColEdit")
                        {
                            col.Visible = false;
                        }
                    }
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


                BLL.ChangeDateFormat(Convert.ToString(Session["EMP_ID"]), rdtp_LeaveAppFromDate, rdtp_LeaveAppToDate, rdtp_LeaveAppAppliedDate);
                BLL.gridDateFormat(Convert.ToString(Session["EMP_ID"]), Rg_LeaveApp, "LEAVEAPP_APPLIEDDATE");
                SMHR_GLOBALCONFIG _obj_SMHR_GlobalConfig = new SMHR_GLOBALCONFIG();
                _obj_SMHR_GlobalConfig.OPERATION = operation.Validate;
                _obj_SMHR_GlobalConfig.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt = BLL.get_ConfigDetails(_obj_SMHR_GlobalConfig);
                //if (dt.Rows.Count > 0)
                //{
                //    if (Convert.ToBoolean(dt.Rows[0]["GLOBALCONFIG_LEAVETRANFLAG"]) == true)
                //        rdtp_LeaveAppAppliedDate.Enabled = false;
                //    else
                //        rdtp_LeaveAppAppliedDate.Enabled = true;
                //}
                Session.Remove("fromDate");
                Session.Remove("toDate");
                rdtp_LeaveAppFromDate.MinDate = Convert.ToDateTime("01-01-2013");
                rdtp_LeaveAppToDate.MinDate = Convert.ToDateTime("01-01-2013");
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Leaveapplication", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            BLL.ShowMessage(this, ex.Message.ToString());
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
            LoadCalPeriod();
            DataTable dt = BLL.get_LeaveApp(new SMHR_LEAVEAPP(Convert.ToInt32(Convert.ToString(e.CommandArgument))));
            if (dt.Rows.Count != 0)
            {
                lbl_LeaveAppID.Text = Convert.ToString(e.CommandArgument);
                rcmb_BusinessUnit.SelectedIndex = rcmb_BusinessUnit.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["BUSINESSUNIT_ID"]));
                rcmb_BusinessUnit_SelectedIndexChanged(null, null);
                if ((Convert.ToInt32(dt.Rows[0]["EMP_STATUS"]) == 0) || (Convert.ToInt32(dt.Rows[0]["EMP_STATUS"]) == 1))
                {
                    SMHR_LEAVEAPP _obj_Smhr_LeaveApp = new SMHR_LEAVEAPP();
                    _obj_Smhr_LeaveApp.BUSINESSUNIT_ID = Convert.ToInt32(Convert.ToString(dt.Rows[0]["BUSINESSUNIT_ID"]));
                    _obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID = Convert.ToInt32(Convert.ToString(dt.Rows[0]["LEAVEAPP_EMP_ID"]));
                    _obj_Smhr_LeaveApp.MODE = 3;
                    DataTable dtemp = BLL.get_EmpLeaveDetails(_obj_Smhr_LeaveApp);
                    rcmb_LeaveAppEmployeeID.DataSource = dtemp;
                    rcmb_LeaveAppEmployeeID.DataTextField = "EMPNAME";
                    rcmb_LeaveAppEmployeeID.DataValueField = "EMP_ID";
                    rcmb_LeaveAppEmployeeID.DataBind();
                    rcmb_LeaveAppEmployeeID.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
                    rcmb_LeaveAppEmployeeID.SelectedIndex = rcmb_LeaveAppEmployeeID.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LEAVEAPP_EMP_ID"]));
                }
                else if ((Convert.ToInt32(dt.Rows[0]["EMP_STATUS"]) == 2) || (Convert.ToInt32(dt.Rows[0]["EMP_STATUS"]) == 3))
                {
                    btn_Update.Visible = false;
                    SMHR_LEAVEAPP _obj_Smhr_LeaveApp = new SMHR_LEAVEAPP();
                    _obj_Smhr_LeaveApp.BUSINESSUNIT_ID = Convert.ToInt32(Convert.ToString(dt.Rows[0]["BUSINESSUNIT_ID"]));
                    _obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID = Convert.ToInt32(Convert.ToString(dt.Rows[0]["LEAVEAPP_EMP_ID"]));
                    _obj_Smhr_LeaveApp.OPERATION = operation.EMPTY_R;
                    DataTable dtemp = BLL.get_LeaveApp(_obj_Smhr_LeaveApp);
                    rcmb_LeaveAppEmployeeID.DataSource = dtemp;
                    rcmb_LeaveAppEmployeeID.DataTextField = "EMPNAME";
                    rcmb_LeaveAppEmployeeID.DataValueField = "EMP_ID";
                    rcmb_LeaveAppEmployeeID.DataBind();
                    rcmb_LeaveAppEmployeeID.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
                    rcmb_LeaveAppEmployeeID.SelectedIndex = rcmb_LeaveAppEmployeeID.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LEAVEAPP_EMP_ID"]));
                }
                rcbCalPrd.SelectedIndex = rcbCalPrd.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LEAVEAPP_CAL_PERIOD"]));
                rcbCalPrd_SelectedIndexChanged(null, null);

                LoadLeaveTypes();
                rcmb_LeaveAppLType.SelectedIndex = rcmb_LeaveAppLType.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LEAVEAPP_LEAVETYPE_ID"]));

                //to check if the selcted leavetype is incident leave
                if (rcmb_LeaveAppLType.SelectedIndex > 0 && IsIncidentLeave())
                {
                    LoadIncident(); //if incident leave, load incidents
                    trIncident.Visible = true;
                    //If incident leave, select incident
                    rcmb_IncidentLeave.SelectedIndex = rcmb_IncidentLeave.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LEAVEAPP_INCIDENT_ID"]));
                    if (rcmb_IncidentLeave.SelectedIndex > 0)
                        trIncidentLink.Visible = true;
                }

                rdtp_LeaveAppFromDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["LEAVEAPP_FROMDATE"]);
                rdtp_LeaveAppToDate.MinDate = Convert.ToDateTime(rdtp_LeaveAppFromDate.SelectedDate);
                Session["fromDate"] = rdtp_LeaveAppFromDate.SelectedDate;
                rdtp_LeaveAppToDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["LEAVEAPP_TODATE"]);
                Session["toDate"] = rdtp_LeaveAppToDate.SelectedDate;
                rtxt_LeaveAppNoofDays.Text = Convert.ToString(dt.Rows[0]["LEAVEAPP_DAYS"]);
                rdtp_LeaveAppAppliedDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["LEAVEAPP_APPLIEDDATE"]);
                rtxt_LeaveAppReason.Text = Convert.ToString(dt.Rows[0]["LEAVEAPP_REASON"]);
                rbtn_FromDate.SelectedIndex = rbtn_FromDate.Items.IndexOf(rbtn_FromDate.Items.FindByValue(Convert.ToString(dt.Rows[0]["LEAVEAPP_FIRSTHALF"])));
                rbtn_ToDate.SelectedIndex = rbtn_ToDate.Items.IndexOf(rbtn_ToDate.Items.FindByValue(Convert.ToString(dt.Rows[0]["LEAVEAPP_SECONDHALF"])));

                if ((dt.Rows[0]["LEAVEAPP_DOCUMENT"] != System.DBNull.Value) && (dt.Rows[0]["LEAVEAPP_DOCUMENT"] != ""))
                {
                    if (File.Exists(Server.MapPath(Convert.ToString(dt.Rows[0]["LEAVEAPP_DOCUMENT"]))))
                    {
                        lnk_Download.Visible = true;
                        lnk_Download.OnClientClick = "javascript:window.open('../" + Convert.ToString(dt.Rows[0]["LEAVEAPP_DOCUMENT"]).TrimStart('~', '/') + "');return false;";
                        ViewState["fileLocation"] = dt.Rows[0]["LEAVEAPP_DOCUMENT"];
                    }
                }
                else
                {
                    lnk_Download.Visible = false;
                }
                if (Convert.ToString(dt.Rows[0]["LEAVEAPP_STATUS"]) == "0")
                {
                    if ((Convert.ToInt32(dt.Rows[0]["EMP_STATUS"]) == 2) || (Convert.ToInt32(dt.Rows[0]["EMP_STATUS"]) == 3))
                    {
                        btn_Update.Visible = false;
                        rcmb_BusinessUnit.Enabled = false;
                        rcmb_LeaveAppEmployeeID.Enabled = true;
                    }
                    else
                    {
                        btn_Update.Visible = true;
                        rcmb_BusinessUnit.Enabled = false;
                        rcmb_LeaveAppEmployeeID.Enabled = true;
                    }
                }
                else if (Convert.ToString(dt.Rows[0]["LEAVEAPP_STATUS"]) == "3")
                {
                    BLL.ShowMessage(this, "Cancelled Leave Cannot Be Edited");
                }
                else
                {
                    rdtp_LeaveAppToDate.Enabled = false;
                    BLL.ShowMessage(this, "This Record Cannot Be Edited As It Is Already " + (Convert.ToString(dt.Rows[0]["LEAVEAPP_STATUS"]) == "1" ? "Approved" : "Rejected"));
                    EnabledFields(false);
                }
                Rm_LA_page.SelectedIndex = 1;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Leaveapplication", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            BLL.ShowMessage(this, ex.Message.ToString());
        }
    }
    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            rdtp_LeaveAppAppliedDate.SelectedDate = DateTime.Now.Date;
            lnk_Download.Visible = false;
            rcmb_LeaveAppEmployeeID.Items.Clear();
            rcmb_LeaveAppEmployeeID.Items.Insert(0, new RadComboBoxItem("", ""));
            rcmb_LeaveAppLType.Items.Clear();
            rcmb_LeaveAppLType.Items.Insert(0, new RadComboBoxItem("", ""));
            SMHR_GLOBALCONFIG _obj_SMHR_GlobalConfig = new SMHR_GLOBALCONFIG();
            _obj_SMHR_GlobalConfig.OPERATION = operation.Validate;
            _obj_SMHR_GlobalConfig.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_ConfigDetails(_obj_SMHR_GlobalConfig);
            if (Convert.ToBoolean(dt.Rows[0]["GLOBALCONFIG_LEAVETRANFLAG"]) == true)
            {
                BLL.ShowMessage(this, "Year End Process For Leave Is In Progress, No Comp Off Request Is Considered");
                return;
            }
            loadDropdown();
            LoadCalPeriod();
            clearControls();
            rdtp_LeaveAppAppliedDate.SelectedDate = DateTime.Now;
            //rdtp_LeaveAppFromDate.MinDate = Convert.ToDateTime("01-01-2013");
            //rdtp_LeaveAppToDate.MinDate = Convert.ToDateTime("01-01-2013");
            btn_Save.Visible = true;
            Rm_LA_page.SelectedIndex = 1;
            //if (Convert.ToString(Session["SELFSERVICE"]) == "")
            //{
            //    rcmb_LeaveAppEmployeeID.Enabled = true;
            //    Rm_LA_page.SelectedIndex = 1;
            //}
            //else if(Convert.ToString(Session["SELFSERVICE"]) == "ADMIN")
            //{

            //    rcmb_LeaveAppEmployeeID.Enabled = true;
            //    Rm_LA_page.SelectedIndex = 1;
            //}
            if (Control != null)
            {
                if ((Convert.ToString(Session["SELFSERVICE"]) == "true" && Control.ToUpper() == "SELFLEAVE") || (Convert.ToString(Session["SELFSERVICE"]) == "" && Control.ToUpper() == "SELFLEAVE"))
                {
                    SMHR_EMPASSETDOC _obj_smhr_empassetdoc = new SMHR_EMPASSETDOC();
                    _obj_smhr_empassetdoc.EMPASSETDOC_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                    _obj_smhr_empassetdoc.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dt_Details = BLL.get_EmpAssetDocBU(_obj_smhr_empassetdoc);
                    rcmb_BusinessUnit.SelectedValue = Convert.ToString(dt_Details.Rows[0][0]);
                    LoadEmployees();
                  //  rcmb_LeaveAppEmployeeID.SelectedIndex = rcmb_LeaveAppEmployeeID.FindItemIndexByValue(Convert.ToString(Session["EMP_ID"]));
                    rcmb_BusinessUnit.Enabled = false;
                    rcmb_LeaveAppEmployeeID.Enabled = true;
                    LoadLeaveTypes();
                    lnk_Cal.Visible = true;
                    Rm_LA_page.SelectedIndex = 1;
                    //lnk_Cal.OnClientClick = "  openRadWin('frm_empleavebal.aspx'); return false;";
                    //getLeavedetails();
                }
                else
                {
                    BLL.ShowMessage(this, "You Do Not Have Access On This Screen");
                    return;
                }

            }
            else
            {
                rcmb_LeaveAppEmployeeID.Enabled = true;
                Rm_LA_page.SelectedIndex = 1;
                lnk_Cal.Visible = false;
            }
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                Rg_LeaveApp.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                btn_Save.Visible = false;
                btn_Calc.Visible = false;
                // added to support Only-View functionality.
                foreach (GridColumn col in Rg_LeaveApp.Columns)
                {
                    if (col.UniqueName == "ColEdit")
                    {
                        col.Visible = false;
                    }
                }
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Leaveapplication", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void loadDropdown()
    {
        try
        {
            rcmb_BusinessUnit.Items.Clear();
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            rcmb_BusinessUnit.DataSource = dt_BUDetails;
            rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BusinessUnit.DataBind();
            rcmb_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Leaveapplication", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    public void LoadGrid()
    {
        try
        {
            //if (Convert.ToInt32(Session["EMP_ID"]) > 0)
            if (Control != null)
            {
                //if (Convert.ToString(Session["SELFSERVICE"]) == "")
                //{
                //    //FOR MANAGER
                //    SMHR_LEAVEAPP _obj_smhr_leaveApp = new SMHR_LEAVEAPP();
                //    _obj_smhr_leaveApp.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //    Rg_LeaveApp.DataSource = BLL.get_LeaveApp(_obj_smhr_leaveApp);
                //    clearControls();
                //    lnk_Cal.Visible = false;
                //    if (Session["DASHBOARD"] != null)
                //    {
                //        Rm_LA_page.SelectedIndex = 1;
                //        lnk_Add_Command(null, null);
                //    }
                //}
                if ((Convert.ToString(Session["SELFSERVICE"]) == "true" && Control.ToUpper() == "SELFLEAVE") || (Convert.ToString(Session["SELFSERVICE"]) == "" && Control.ToUpper() == "SELFLEAVE"))
                {
                    //FOR SELF-EMPLOYEE
                    SMHR_LEAVEAPP _obj_smhr_leaveApp = new SMHR_LEAVEAPP();
                    _obj_smhr_leaveApp.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_leaveApp.LEAVEAPP_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                    _obj_smhr_leaveApp.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                    DataTable dt_Details = BLL.get_EmpLeaveApp(_obj_smhr_leaveApp);
                    Rg_LeaveApp.DataSource = dt_Details;
                    clearControls();
                    //if (Session["DASHBOARD"] != null)
                    //{
                    //    Rm_LA_page.SelectedIndex = 1;
                    //    lnk_Add_Command(null, null);
                    //}
                }
                else
                {
                    BLL.ShowMessage(this, "You Do Not Have Access On This Screen.");
                    return;
                }
            }

            else
            {
                //FOR ADMIN
                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();
                if (Control != null)
                {
                    if (Control.ToUpper() == "SELFLEAVE")
                    {
                        _obj_Smhr_LoginInfo.LOGIN_ID = 12;
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("LEAVE APPLICATION");
                    }
                }
                else
                {
                    _obj_Smhr_LoginInfo.LOGIN_ID = 14;
                    _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("LEAVE APPLICATION");
                }
                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //_obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("LEAVEAPPLICATION");
                DataTable dtformdtls = BLL.get_LoginInfo(_obj_Smhr_LoginInfo);
                if (dtformdtls.Rows.Count != 0)
                {
                    if ((Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_READ"]) == true) && (Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_WRITE"]) == true))
                    {
                        SMHR_LEAVEAPP _obj_smhr_leaveApp = new SMHR_LEAVEAPP();
                        _obj_smhr_leaveApp.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_smhr_leaveApp.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                        Rg_LeaveApp.DataSource = BLL.get_LeaveApp(_obj_smhr_leaveApp);
                        clearControls();
                        //lnk_Cal.Visible = true;
                    }
                    else if ((Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_READ"]) == true) && (Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_WRITE"]) == false))
                    {
                        Rg_LeaveApp.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                        btn_Save.Visible = false;
                        btn_Calc.Visible = false;
                        // added to support Only-View functionality.
                        foreach (GridColumn col in Rg_LeaveApp.Columns)
                        {
                            if (col.UniqueName == "ColEdit")
                            {
                                col.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        if (Session["SELFSERVICE"] == "true")
                            Response.Redirect("~/Security/frm_Dashboard.aspx", false);
                        else if (Session["SELFSERVICE"] == "")
                            Response.Redirect("~/Security/frm_Dashboradmngr.aspx", false);
                        else
                            Response.Redirect("~/Masters/Default.aspx", false);
                    }
                }
                else
                {
                    if (Session["SELFSERVICE"] == "true")
                        Response.Redirect("~/Security/frm_Dashboard.aspx", false);
                    else if (Session["SELFSERVICE"] == "")
                        Response.Redirect("~/Security/frm_Dashboradmngr.aspx", false);
                    else
                        Response.Redirect("~/Masters/Default.aspx", false);
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Leaveapplication", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            BLL.ShowMessage(this, ex.Message.ToString());
        }
    }
    public void LoadCalPeriod()
    {
        try
        {
            SMHR_PERIOD _obj_smhr_period = new SMHR_PERIOD();
            DataTable dt_Details = new DataTable();
            _obj_smhr_period.OPERATION = operation.Select;
            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_PeriodHeaderDetails_Calendar(_obj_smhr_period);
            rcbCalPrd.DataSource = dt_Details;
            rcbCalPrd.DataValueField = "PERIOD_ID";
            rcbCalPrd.DataTextField = "PERIOD_NAME";
            rcbCalPrd.DataBind();
            rcbCalPrd.Items.Insert(0, new RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Leaveapplication", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            BLL.ShowMessage(this, ex.Message.ToString());
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            double noofDays = Convert.ToDouble(rtxt_LeaveAppNoofDays.Text);

            if (lblEmpLeaveBal.Text == "No Leave balances were defined for selected calendar period")
            {
                BLL.ShowMessage(this, "No Leave balances were defined for selected calendar period");
                return;
            }

            if (Convert.ToDouble(lblEmpLeaveBal.Text) < noofDays)
            {
                BLL.ShowMessage(this,"Leave balances exceeding more than available balances");
                return;
            }

            if (rtxt_LeaveAppNoofDays.Text == string.Empty)
            {
                BLL.ShowMessage(this, "Please make sure to select proper selections for Half day/Full day radio buttons");
                return;
            }
            // checking whether selected employee is joined before leave applied date,from date ,to date
            bool empjoined = get_DOJ();
            if (!empjoined)
            {
                BLL.ShowMessage(this, "Employee has not Joined in the Organization for the selected date");
                return;
            }
            getDays();
            SMHR_LEAVEAPP _obj_Smhr_LeaveApp = new SMHR_LEAVEAPP();
            _obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID = Convert.ToInt32(rcmb_LeaveAppEmployeeID.SelectedItem.Value);
            _obj_Smhr_LeaveApp.LEAVEAPP_LEAVETYPE_ID = Convert.ToInt32(rcmb_LeaveAppLType.SelectedItem.Value);
            _obj_Smhr_LeaveApp.LEAVEAPP_FROMDATE = Convert.ToDateTime(rdtp_LeaveAppFromDate.SelectedDate);
            _obj_Smhr_LeaveApp.LEAVEAPP_TODATE = Convert.ToDateTime(rdtp_LeaveAppToDate.SelectedDate);
            _obj_Smhr_LeaveApp.LEAVEAPP_DAYS = float.Parse(rtxt_LeaveAppNoofDays.Text);
            _obj_Smhr_LeaveApp.LEAVEAPP_APPLIEDDATE = Convert.ToDateTime(rdtp_LeaveAppAppliedDate.SelectedDate);
            _obj_Smhr_LeaveApp.LEAVEAPP_REASON = BLL.ReplaceQuote(rtxt_LeaveAppReason.Text.Trim());
            _obj_Smhr_LeaveApp.LEAVEAPP_FIRSTHALF = Convert.ToBoolean(Convert.ToUInt32(rbtn_FromDate.SelectedItem.Value));
            _obj_Smhr_LeaveApp.LEAVEAPP_SECONDHALF = Convert.ToBoolean(Convert.ToUInt32(rbtn_ToDate.SelectedItem.Value));
            _obj_Smhr_LeaveApp.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_LeaveApp.LEAVEAPP_CAL_PERIOD = Convert.ToInt32(rcbCalPrd.SelectedValue);
            _obj_Smhr_LeaveApp.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_LeaveApp.CREATEDDATE = DateTime.Now;
            _obj_Smhr_LeaveApp.LEAVEAPPDAYS = noofDays;

            //to check if selected leave type is incident leave, if s then pass incidentId parameter
            if (IsIncidentLeave())
            {
                if (rcmb_IncidentLeave.SelectedIndex > 0)
                {
                    _obj_Smhr_LeaveApp.LEAVEAPP_INCIDENT_ID = Convert.ToInt32(rcmb_IncidentLeave.SelectedValue);
                }
                else
                {
                    BLL.ShowMessage(this, "Please Select an Incident");
                    return;
                }
            }

            /*if (rcmb_LeaveAppLType.SelectedItem.Text.Trim() != "LOP")
            {
                //TO GET LEAVEBALANCES OF EMPLOYEE
                _obj_Smhr_LeaveApp.OPERATION = operation.Select1;
                DataTable dt_bal = BLL.get_LeaveApp(_obj_Smhr_LeaveApp);
                if (dt_bal.Rows.Count > 0)
                {
                    if (Convert.ToDouble(dt_bal.Rows[0]["LT_CURRENTBALANCE"]) <= 0.00)
                    {
                        BLL.ShowMessage(this, "Employee Does Not Have Leaves For This LeaveType.Please Select Another LeaveType.");
                        return;
                    }
                    if (Convert.ToDouble(dt_bal.Rows[0]["LT_CURRENTBALANCE"]) < Convert.ToDouble(rtxt_LeaveAppNoofDays.Text))
                    {
                        BLL.ShowMessage(this, "Employee Has Only " + Convert.ToDouble(dt_bal.Rows[0]["LT_CURRENTBALANCE"]) + " Balances.");
                        getLeavedetails();
                        return;
                    }
                }
                else
                {
                    BLL.ShowMessage(this, "Employee Does Not Have Balances For Selected Leave Type.");
                    return;
                }
            }*/
            ViewState["AppliedDate"] = Convert.ToDateTime(rdtp_LeaveAppAppliedDate.SelectedDate);
            if (!string.IsNullOrEmpty(FUpload_Doc.PostedFile.FileName))
            {
                FUpload_Doc.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/EmpUploads/DocUploads/"), "LEAVEAPP_" + rcmb_LeaveAppEmployeeID.SelectedItem.Value + "_" + FUpload_Doc.FileName));
                _obj_Smhr_LeaveApp.LEAVEAPP_DOCUMENT = "~/EmpUploads/DocUploads/" + "LEAVEAPP_" + rcmb_LeaveAppEmployeeID.SelectedItem.Value + "_" + FUpload_Doc.FileName;
            }
            else
            {
                if (ViewState["fileLocation"] != null)
                {
                    _obj_Smhr_LeaveApp.LEAVEAPP_DOCUMENT = Convert.ToString(ViewState["fileLocation"]);
                }
            }
            _obj_Smhr_LeaveApp.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_LeaveApp.LASTMDFDATE = DateTime.Now;

            // checking whether leave applied is fullday and from date and to date is same
            //if((rdtp_LeaveAppToDate.SelectedDate==rdtp_LeaveAppToDate.SelectedDate)&&(Convert.ToBoolean((rbtn_ToDate.SelectedValue=="0")&&(rbtn_FromDate.SelectedValue=="0"))))
            //{
            //    BLL.ShowMessage(this,"Full Day Leave Cannot be Applied on same from and to dates");
            //    return;
            //}
            //if (Convert.ToString(rtxt_LeaveAppNoofDays.Text) == "0")
            //{
            //    BLL.ShowMessage(this, "Check From Date Or To Date May Be Weekly Off Or Holiday");
            //    return;
            //}

            //if the number of days contain any half days then we will get a problem in conversion to int
            // so we are rounding that to 1 as it has to loop for that day also
            string round = rtxt_LeaveAppNoofDays.Text;//
            double Days_Applied = 0.5;
            if (round.EndsWith("5"))
                Days_Applied += Convert.ToDouble(rtxt_LeaveAppNoofDays.Text);
            else
                Days_Applied = Convert.ToDouble(rtxt_LeaveAppNoofDays.Text);

            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_UPDATE":
                    _obj_SMHR_Attendence = new SMHR_ATTENDANCE();
                    for (int I_Date = 0; I_Date <= Convert.ToInt32(Days_Applied); I_Date++)
                    {
                        DateTime F_Date = Convert.ToDateTime(rdtp_LeaveAppFromDate.SelectedDate);
                        _obj_SMHR_Attendence.ATTENDANCE_MODE = true;
                        _obj_SMHR_Attendence.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
                        _obj_SMHR_Attendence.ATTENDANCE_DATE = Convert.ToDateTime(F_Date);
                        _obj_SMHR_Attendence.OPERATION = operation.Check;
                        DataTable dt = BLL.get_Attendance(_obj_SMHR_Attendence);
                        if (dt.Rows.Count != 0)
                        {
                            //if (Convert.ToInt32(dt.Rows[0]["ATTENDANCE_FINALIZE"]) == 1)
                            //{
                            //    BLL.ShowMessage(this, "Attendence already done, cannot update Leave Application");
                            //    return;
                            //}
                            //else
                            //{
                            bool status = false;
                            _obj_Smhr_LeaveApp.OPERATION = operation.Validate;
                            _obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID = Convert.ToInt32(rcmb_LeaveAppEmployeeID.SelectedItem.Value);
                            _obj_Smhr_LeaveApp.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dt_Leaves = BLL.get_LeaveApp(_obj_Smhr_LeaveApp);
                            if (dt_Leaves.Rows.Count != 0)
                            {
                                if ((Convert.ToDateTime(Session["fromDate"]) != Convert.ToDateTime(rdtp_LeaveAppFromDate.SelectedDate) || ((Convert.ToDateTime(Session["toDate"]) != Convert.ToDateTime(rdtp_LeaveAppToDate.SelectedDate)))))
                                {
                                    if (Convert.ToDateTime(Session["fromDate"]) > Convert.ToDateTime(rdtp_LeaveAppFromDate.SelectedDate) ||
                                       Convert.ToDateTime(Session["toDate"]) < Convert.ToDateTime(rdtp_LeaveAppToDate.SelectedDate))
                                    {
                                        for (int I_GridCount = 0; I_GridCount < dt_Leaves.Rows.Count; I_GridCount++)
                                        {
                                            DateTime date = Convert.ToDateTime(dt_Leaves.Rows[I_GridCount]["LEAVEAPP_FROMDATE"]);
                                            for (float F_LeaveFromDate = 0; F_LeaveFromDate <= Convert.ToSingle(dt_Leaves.Rows[I_GridCount]["LEAVEAPP_DAYS"]) - 1; F_LeaveFromDate++)
                                            {
                                                status = true;

                                                if (F_Date == date)
                                                {
                                                    if (!(Convert.ToInt32(dt_Leaves.Rows[I_GridCount]["LEAVEAPP_STATUS"]) == 3))
                                                    {
                                                        BLL.ShowMessage(this, "Leave Application Already Filed For This Date");
                                                        return;
                                                    }
                                                }

                                                date = date.AddDays(1);
                                            }
                                        }
                                    }
                                }
                            }
                            //}
                        }
                        else
                        {
                            bool status = false;
                            _obj_Smhr_LeaveApp.OPERATION = operation.Validate;
                            _obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID = Convert.ToInt32(rcmb_LeaveAppEmployeeID.SelectedItem.Value);
                            _obj_Smhr_LeaveApp.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dt_Leaves = BLL.get_LeaveApp(_obj_Smhr_LeaveApp);
                            if (dt_Leaves.Rows.Count != 0)
                            {
                                if ((Convert.ToDateTime(Session["fromDate"]) != Convert.ToDateTime(rdtp_LeaveAppFromDate.SelectedDate) || ((Convert.ToDateTime(Session["toDate"]) != Convert.ToDateTime(rdtp_LeaveAppToDate.SelectedDate)))))
                                {
                                    if (Convert.ToDateTime(Session["fromDate"]) > Convert.ToDateTime(rdtp_LeaveAppFromDate.SelectedDate) ||
                                       Convert.ToDateTime(Session["toDate"]) < Convert.ToDateTime(rdtp_LeaveAppToDate.SelectedDate))
                                    {
                                        for (int I_GridCount = 0; I_GridCount < dt_Leaves.Rows.Count; I_GridCount++)
                                        {
                                            DateTime date = Convert.ToDateTime(dt_Leaves.Rows[I_GridCount]["LEAVEAPP_FROMDATE"]);

                                            for (float F_LeaveFromDate = 0; F_LeaveFromDate <= Convert.ToSingle(dt_Leaves.Rows[I_GridCount]["LEAVEAPP_DAYS"]) - 1; F_LeaveFromDate++)
                                            {
                                                status = true;
                                                if (F_Date == date && (date < Convert.ToDateTime(Session["fromDate"]) || date > Convert.ToDateTime(Session["toDate"])))
                                                {
                                                    if (!(Convert.ToInt32(dt_Leaves.Rows[I_GridCount]["LEAVEAPP_STATUS"]) == 3))
                                                    {
                                                        BLL.ShowMessage(this, "Leave Application Already Filed For This Date");
                                                        return;
                                                    }
                                                }
                                                date = date.AddDays(1);
                                            }
                                        }
                                    }
                                }

                                if (status == false)
                                {
                                    _obj_Smhr_LeaveApp.LEAVEAPP_ID = Convert.ToInt32(lbl_LeaveAppID.Text);
                                    _obj_Smhr_LeaveApp.OPERATION = operation.Update;
                                    if (BLL.set_LeaveApp(_obj_Smhr_LeaveApp))
                                    {
                                        //BLL.ShowMessage(this, "Leave Application sent for Approval");
                                        if ((Convert.ToDateTime(Session["fromDate"]) != Convert.ToDateTime(rdtp_LeaveAppFromDate.SelectedDate) || ((Convert.ToDateTime(Session["toDate"]) != Convert.ToDateTime(rdtp_LeaveAppToDate.SelectedDate)))))
                                        {
                                            _obj_Smhr_LeaveApp = new SMHR_LEAVEAPP();
                                            _obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID = Convert.ToInt32(rcmb_LeaveAppEmployeeID.SelectedItem.Value);
                                            _obj_Smhr_LeaveApp.MODE = 4;
                                            DataTable dt_mail = BLL.get_EmpLeaveDetails(_obj_Smhr_LeaveApp);
                                            if (dt_mail.Rows.Count > 0)
                                            {
                                                if (((Convert.ToString(dt_mail.Rows[0]["REPORTING_EMP_EMAIL"]) != string.Empty) && (dt_mail.Rows[0]["REPORTING_EMP_EMAIL"]) != System.DBNull.Value)
                                                    && ((Convert.ToString(dt_mail.Rows[0]["EMP_EMAIL"]) != string.Empty) && (dt_mail.Rows[0]["EMP_EMAIL"]) != System.DBNull.Value)
                                                    && ((Convert.ToString(dt_mail.Rows[0]["REPORTING_EMP"]) != string.Empty) && ((dt_mail.Rows[0]["REPORTING_EMP"]) != System.DBNull.Value)))
                                                {
                                                    _obj_Smhr_LeaveApp.MODE = 4;
                                                    _obj_Smhr_LeaveApp.LEAVEAPP_FROMDATE = Convert.ToDateTime(rdtp_LeaveAppFromDate.SelectedDate);
                                                    _obj_Smhr_LeaveApp.LEAVEAPP_TODATE = Convert.ToDateTime(rdtp_LeaveAppToDate.SelectedDate);
                                                    _obj_Smhr_LeaveApp.LEAVEAPP_DAYS = Convert.ToSingle(rtxt_LeaveAppNoofDays.Text);

                                                    if (BLL.get_Leave_Mail(_obj_Smhr_LeaveApp))
                                                        BLL.ShowMessage(this, "Leave Application sent for Approval And Notification Sent");
                                                }
                                            }
                                            else
                                                BLL.ShowMessage(this, "Leave Application sent for Approval");
                                        }
                                        else
                                            BLL.ShowMessage(this, "Leave Application sent for Approval");
                                    }
                                    else
                                        BLL.ShowMessage(this, "Information Not Saved");

                                    Rm_LA_page.SelectedIndex = 0;
                                    LoadGrid();
                                    Rg_LeaveApp.DataBind();
                                    return;
                                }
                            }
                        }
                        F_Date = F_Date.AddDays(1);
                    }
                    _obj_Smhr_LeaveApp.LEAVEAPP_ID = Convert.ToInt32(lbl_LeaveAppID.Text);
                    _obj_Smhr_LeaveApp.OPERATION = operation.Update;
                    if (BLL.set_LeaveApp(_obj_Smhr_LeaveApp))
                    {
                        //BLL.ShowMessage(this, "Leave Application Sent For Approval");
                        if ((Convert.ToDateTime(Session["fromDate"]) != Convert.ToDateTime(rdtp_LeaveAppFromDate.SelectedDate) || ((Convert.ToDateTime(Session["toDate"]) != Convert.ToDateTime(rdtp_LeaveAppToDate.SelectedDate)))))
                        {
                            _obj_Smhr_LeaveApp = new SMHR_LEAVEAPP();
                            _obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID = Convert.ToInt32(rcmb_LeaveAppEmployeeID.SelectedItem.Value);
                            _obj_Smhr_LeaveApp.MODE = 4;
                            DataTable dt_mail = BLL.get_EmpLeaveDetails(_obj_Smhr_LeaveApp);
                            if (dt_mail.Rows.Count > 0)
                            {
                                if (((Convert.ToString(dt_mail.Rows[0]["REPORTING_EMP_EMAIL"]) != string.Empty) && (dt_mail.Rows[0]["REPORTING_EMP_EMAIL"]) != System.DBNull.Value)
                                    && ((Convert.ToString(dt_mail.Rows[0]["EMP_EMAIL"]) != string.Empty) && (dt_mail.Rows[0]["EMP_EMAIL"]) != System.DBNull.Value)
                                    && ((Convert.ToString(dt_mail.Rows[0]["REPORTING_EMP"]) != string.Empty) && ((dt_mail.Rows[0]["REPORTING_EMP"]) != System.DBNull.Value)))
                                {
                                    _obj_Smhr_LeaveApp.MODE = 4;
                                    _obj_Smhr_LeaveApp.LEAVEAPP_FROMDATE = Convert.ToDateTime(rdtp_LeaveAppFromDate.SelectedDate);
                                    _obj_Smhr_LeaveApp.LEAVEAPP_TODATE = Convert.ToDateTime(rdtp_LeaveAppToDate.SelectedDate);
                                    _obj_Smhr_LeaveApp.LEAVEAPP_DAYS = Convert.ToSingle(rtxt_LeaveAppNoofDays.Text);
                                    if (BLL.get_Leave_Mail(_obj_Smhr_LeaveApp))
                                        BLL.ShowMessage(this, "Leave Application sent for Approval And Notification Sent");

                                }
                                else
                                {
                                    BLL.ShowMessage(this, "Leave Application sent for Approval");
                                }
                            }
                            else
                                BLL.ShowMessage(this, "Leave Application sent for Approval");
                        }
                        else
                            BLL.ShowMessage(this, "Leave Application sent for Approval");
                    }
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                case "BTN_SAVE":
                    //To check whether employee is already applied for leave for the given period or not, newly added by sravani 22.02.2011
                    //_obj_Smhr_LeaveApp.OPERATION = operation.Check1;
                    //if (Convert.ToString(BLL.get_LeaveApp(_obj_Smhr_LeaveApp).Rows[0]["Count"]) != "0")
                    //{
                    //    BLL.ShowMessage(this, "Already you applied Leave Applicaton for this period");
                    //    rdtp_LeaveAppFromDate.SelectedDate = null;
                    //    rdtp_LeaveAppToDate.SelectedDate = null;
                    //    rtxt_LeaveAppNoofDays.Text = string.Empty;
                    //    return;
                    //}
                    _obj_SMHR_Attendence = new SMHR_ATTENDANCE();
                    for (int I_Date = 0; I_Date < Convert.ToInt32(Days_Applied); I_Date++)
                    {
                        DateTime F_Date = Convert.ToDateTime(rdtp_LeaveAppFromDate.SelectedDate);
                        _obj_SMHR_Attendence.ATTENDANCE_MODE = true;
                        _obj_SMHR_Attendence.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
                        _obj_SMHR_Attendence.ATTENDANCE_DATE = Convert.ToDateTime(F_Date);
                        _obj_SMHR_Attendence.OPERATION = operation.Check;
                        DataTable dt = BLL.get_Attendance(_obj_SMHR_Attendence);
                        if (dt.Rows.Count != 0)
                        {
                            //if (Convert.ToInt32(dt.Rows[0]["ATTENDANCE_FINALIZE"]) == 1)
                            //{
                            //    BLL.ShowMessage(this, "Attendence already done.Leaves cannot be processed");
                            //    return;
                            //}
                            //else
                            //{
                            bool status = false;
                            _obj_Smhr_LeaveApp.OPERATION = operation.Validate;
                            _obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID = Convert.ToInt32(rcmb_LeaveAppEmployeeID.SelectedItem.Value);
                            _obj_Smhr_LeaveApp.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dt_Leaves = BLL.get_LeaveApp(_obj_Smhr_LeaveApp);
                            if (dt_Leaves.Rows.Count != 0)
                            {
                                for (int I_GridCount = 0; I_GridCount < dt_Leaves.Rows.Count; I_GridCount++)
                                {
                                    DateTime date = Convert.ToDateTime(dt_Leaves.Rows[I_GridCount]["LEAVEAPP_FROMDATE"]);
                                    for (float F_LeaveFromDate = 0; F_LeaveFromDate <= Convert.ToSingle(dt_Leaves.Rows[I_GridCount]["LEAVEAPP_DAYS"]) - 1; F_LeaveFromDate++)
                                    {
                                        status = true;
                                        if (F_Date == date)
                                        {
                                            BLL.ShowMessage(this, "Leave Application Already Filed For This Date");
                                            return;
                                        }
                                        if (status == false)
                                        {
                                            _obj_Smhr_LeaveApp.OPERATION = operation.Insert;
                                            _obj_Smhr_LeaveApp.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                            if (BLL.set_LeaveApp(_obj_Smhr_LeaveApp))
                                            {
                                                //BLL.ShowMessage(this, "Leave Application Sent For Approval");
                                                _obj_Smhr_LeaveApp = new SMHR_LEAVEAPP();
                                                _obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID = Convert.ToInt32(rcmb_LeaveAppEmployeeID.SelectedItem.Value);
                                                _obj_Smhr_LeaveApp.MODE = 4;
                                                DataTable dt_mail = BLL.get_EmpLeaveDetails(_obj_Smhr_LeaveApp);
                                                if (dt_mail.Rows.Count > 0)
                                                {
                                                    if (((Convert.ToString(dt_mail.Rows[0]["REPORTING_EMP_EMAIL"]) != string.Empty) && (dt_mail.Rows[0]["REPORTING_EMP_EMAIL"]) != System.DBNull.Value)
                                                        && ((Convert.ToString(dt_mail.Rows[0]["EMP_EMAIL"]) != string.Empty) && (dt_mail.Rows[0]["EMP_EMAIL"]) != System.DBNull.Value)
                                                        && ((Convert.ToString(dt_mail.Rows[0]["REPORTING_EMP"]) != string.Empty) && ((dt_mail.Rows[0]["REPORTING_EMP"]) != System.DBNull.Value)))
                                                    {
                                                        _obj_Smhr_LeaveApp.MODE = 1;
                                                        _obj_Smhr_LeaveApp.LEAVEAPP_FROMDATE = Convert.ToDateTime(rdtp_LeaveAppFromDate.SelectedDate);
                                                        _obj_Smhr_LeaveApp.LEAVEAPP_TODATE = Convert.ToDateTime(rdtp_LeaveAppToDate.SelectedDate);
                                                        _obj_Smhr_LeaveApp.LEAVEAPP_DAYS = Convert.ToSingle(rtxt_LeaveAppNoofDays.Text);
                                                        if (BLL.get_Leave_Mail(_obj_Smhr_LeaveApp))
                                                            BLL.ShowMessage(this, "Leave Application sent for Approval And Notification Sent");
                                                        else
                                                            BLL.ShowMessage(this, "Leave Application sent for Approval");
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                BLL.ShowMessage(this, "Information Not Saved");
                                            }
                                            //_obj_Smhr_LeaveApp = new SMHR_LEAVEAPP();
                                            //_obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID = Convert.ToInt32(rcmb_LeaveAppEmployeeID.SelectedItem.Value);
                                            //_obj_Smhr_LeaveApp.MODE = 4;
                                            //DataTable dt_mail = BLL.get_EmpLeaveDetails(_obj_Smhr_LeaveApp);
                                            //if (dt_mail.Rows.Count > 0)
                                            //{
                                            //    //if (!((dt_mail.Rows[0]["REPORTING_EMP_EMAIL"] != System.DBNull.Value && dt_mail.Rows[0]["REPORTING_EMP_EMAIL"] != string.Empty) || (dt_mail.Rows[0]["EMP_EMAIL"] != System.DBNull.Value && dt_mail.Rows[0]["EMP_EMAIL"] != string.Empty) || (dt_mail.Rows[0]["REPORTING_EMP"] != System.DBNull.Value && dt_mail.Rows[0]["REPORTING_EMP"] != string.Empty)))
                                            //    if (((Convert.ToString(dt_mail.Rows[0]["REPORTING_EMP_EMAIL"]) != string.Empty) && (dt_mail.Rows[0]["REPORTING_EMP_EMAIL"]) != System.DBNull.Value)
                                            //        && ((Convert.ToString(dt_mail.Rows[0]["EMP_EMAIL"]) != string.Empty) && (dt_mail.Rows[0]["EMP_EMAIL"]) != System.DBNull.Value)
                                            //        && ((Convert.ToString(dt_mail.Rows[0]["REPORTING_EMP"]) != string.Empty) && ((dt_mail.Rows[0]["REPORTING_EMP"]) != System.DBNull.Value)))
                                            //    {
                                            //        _obj_Smhr_LeaveApp.MODE = 1;
                                            //        _obj_Smhr_LeaveApp.LEAVEAPP_FROMDATE = Convert.ToDateTime(rdtp_LeaveAppFromDate.SelectedDate);
                                            //        _obj_Smhr_LeaveApp.LEAVEAPP_TODATE = Convert.ToDateTime(rdtp_LeaveAppToDate.SelectedDate);
                                            //        _obj_Smhr_LeaveApp.LEAVEAPP_DAYS = Convert.ToSingle(rtxt_LeaveAppNoofDays.Text);
                                            //        if (BLL.get_Leave_Mail(_obj_Smhr_LeaveApp))
                                            //        {
                                            //            BLL.ShowMessage(this, "Notification Sent");
                                            //        }
                                            //    }
                                            //}
                                            Rm_LA_page.SelectedIndex = 0;
                                            LoadGrid();
                                            Rg_LeaveApp.DataBind();
                                            return;
                                        }
                                        date = date.AddDays(1);
                                    }
                                }
                            }
                            //}
                        }
                        else
                        {
                            _obj_Smhr_LeaveApp.OPERATION = operation.Validate;
                            _obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID = Convert.ToInt32(rcmb_LeaveAppEmployeeID.SelectedItem.Value);
                            _obj_Smhr_LeaveApp.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dt_Leaves = BLL.get_LeaveApp(_obj_Smhr_LeaveApp);
                            if (dt_Leaves.Rows.Count != 0)
                            {
                                bool status = false;
                                for (int I_GridCount = 0; I_GridCount < dt_Leaves.Rows.Count; I_GridCount++)
                                {
                                    DateTime date = Convert.ToDateTime(dt_Leaves.Rows[I_GridCount]["LEAVEAPP_FROMDATE"]);
                                    for (float F_LeaveFromDate = 0; F_LeaveFromDate <= Convert.ToSingle(dt_Leaves.Rows[I_GridCount]["LEAVEAPP_DAYS"]) - 1; F_LeaveFromDate++)
                                    {
                                        status = true;

                                        if (F_Date == date)
                                        {
                                            if (!(Convert.ToInt32(dt_Leaves.Rows[I_GridCount]["LEAVEAPP_STATUS"]) == 3))
                                            {
                                                BLL.ShowMessage(this, "Leave Application Already Filed For This Date");
                                                return;
                                            }
                                        }

                                        date = date.AddDays(1);
                                    }
                                }
                                if (status == false)
                                {
                                    _obj_Smhr_LeaveApp.OPERATION = operation.Insert;
                                    _obj_Smhr_LeaveApp.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                    if (BLL.set_LeaveApp(_obj_Smhr_LeaveApp))
                                    {
                                        //BLL.ShowMessage(this, "Leave Application Sent For Approval");
                                        _obj_Smhr_LeaveApp = new SMHR_LEAVEAPP();
                                        _obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID = Convert.ToInt32(rcmb_LeaveAppEmployeeID.SelectedItem.Value);
                                        _obj_Smhr_LeaveApp.MODE = 4;
                                        DataTable dt_mail = BLL.get_EmpLeaveDetails(_obj_Smhr_LeaveApp);
                                        if (dt_mail.Rows.Count > 0)
                                        {
                                            if (((Convert.ToString(dt_mail.Rows[0]["REPORTING_EMP_EMAIL"]) != string.Empty) && (dt_mail.Rows[0]["REPORTING_EMP_EMAIL"]) != System.DBNull.Value)
                                                && ((Convert.ToString(dt_mail.Rows[0]["EMP_EMAIL"]) != string.Empty) && (dt_mail.Rows[0]["EMP_EMAIL"]) != System.DBNull.Value)
                                                && ((Convert.ToString(dt_mail.Rows[0]["REPORTING_EMP"]) != string.Empty) && ((dt_mail.Rows[0]["REPORTING_EMP"]) != System.DBNull.Value)))
                                            {
                                                _obj_Smhr_LeaveApp.MODE = 1;
                                                _obj_Smhr_LeaveApp.LEAVEAPP_FROMDATE = Convert.ToDateTime(rdtp_LeaveAppFromDate.SelectedDate);
                                                _obj_Smhr_LeaveApp.LEAVEAPP_TODATE = Convert.ToDateTime(rdtp_LeaveAppToDate.SelectedDate);
                                                _obj_Smhr_LeaveApp.LEAVEAPP_DAYS = Convert.ToSingle(rtxt_LeaveAppNoofDays.Text);
                                                if (BLL.get_Leave_Mail(_obj_Smhr_LeaveApp))
                                                    BLL.ShowMessage(this, "Leave Application sent for Approval And Notification Sent");
                                                else
                                                    BLL.ShowMessage(this, "Leave Application sent for Approval");
                                            }
                                            else
                                            {
                                                BLL.ShowMessage(this, "Leave Application sent for Approval");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        BLL.ShowMessage(this, "Information Not Saved");
                                    }
                                    //_obj_Smhr_LeaveApp = new SMHR_LEAVEAPP();
                                    //_obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID = Convert.ToInt32(rcmb_LeaveAppEmployeeID.SelectedItem.Value);
                                    //_obj_Smhr_LeaveApp.MODE = 4;
                                    //DataTable dt_mail = BLL.get_EmpLeaveDetails(_obj_Smhr_LeaveApp);
                                    //if (dt_mail.Rows.Count > 0)
                                    //{
                                    //    //if (!((dt_mail.Rows[0]["REPORTING_EMP_EMAIL"] != System.DBNull.Value && dt_mail.Rows[0]["REPORTING_EMP_EMAIL"] != string.Empty) || (dt_mail.Rows[0]["EMP_EMAIL"] != System.DBNull.Value && dt_mail.Rows[0]["EMP_EMAIL"] != string.Empty) || (dt_mail.Rows[0]["REPORTING_EMP"] != System.DBNull.Value && dt_mail.Rows[0]["REPORTING_EMP"] != string.Empty)))
                                    //    if (((Convert.ToString(dt_mail.Rows[0]["REPORTING_EMP_EMAIL"]) != string.Empty) && (dt_mail.Rows[0]["REPORTING_EMP_EMAIL"]) != System.DBNull.Value)
                                    //        && ((Convert.ToString(dt_mail.Rows[0]["EMP_EMAIL"]) != string.Empty) && (dt_mail.Rows[0]["EMP_EMAIL"]) != System.DBNull.Value)
                                    //        && ((Convert.ToString(dt_mail.Rows[0]["REPORTING_EMP"]) != string.Empty) && ((dt_mail.Rows[0]["REPORTING_EMP"]) != System.DBNull.Value)))
                                    //    {
                                    //        _obj_Smhr_LeaveApp.MODE = 1;
                                    //        _obj_Smhr_LeaveApp.LEAVEAPP_FROMDATE = Convert.ToDateTime(rdtp_LeaveAppFromDate.SelectedDate);
                                    //        _obj_Smhr_LeaveApp.LEAVEAPP_TODATE = Convert.ToDateTime(rdtp_LeaveAppToDate.SelectedDate);
                                    //        _obj_Smhr_LeaveApp.LEAVEAPP_DAYS = Convert.ToSingle(rtxt_LeaveAppNoofDays.Text);
                                    //        if (BLL.get_Leave_Mail(_obj_Smhr_LeaveApp))
                                    //        {
                                    //            BLL.ShowMessage(this, "Notification Sent");
                                    //        }
                                    //    }
                                    //}
                                    Rm_LA_page.SelectedIndex = 0;
                                    LoadGrid();
                                    Rg_LeaveApp.DataBind();
                                    return;
                                }
                            }

                        }
                        F_Date = F_Date.AddDays(1);
                    }

                    _obj_Smhr_LeaveApp.OPERATION = operation.Insert;
                    _obj_Smhr_LeaveApp.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    if (BLL.set_LeaveApp(_obj_Smhr_LeaveApp))
                    {
                        //BLL.ShowMessage(this, "Leave Application Sent For Approval");
                        _obj_Smhr_LeaveApp = new SMHR_LEAVEAPP();
                        _obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID = Convert.ToInt32(rcmb_LeaveAppEmployeeID.SelectedItem.Value);
                        _obj_Smhr_LeaveApp.MODE = 4;
                        DataTable dt_mail1 = BLL.get_EmpLeaveDetails(_obj_Smhr_LeaveApp);
                        if (dt_mail1.Rows.Count > 0)
                        {
                            //if (!((dt_mail.Rows[0]["REPORTING_EMP_EMAIL"] != System.DBNull.Value && dt_mail.Rows[0]["REPORTING_EMP_EMAIL"] != string.Empty) || (dt_mail.Rows[0]["EMP_EMAIL"] != System.DBNull.Value && dt_mail.Rows[0]["EMP_EMAIL"] != string.Empty) || (dt_mail.Rows[0]["REPORTING_EMP"] != System.DBNull.Value && dt_mail.Rows[0]["REPORTING_EMP"] != string.Empty)))
                            if (((Convert.ToString(dt_mail1.Rows[0]["REPORTING_EMP_EMAIL"]) != string.Empty) && (dt_mail1.Rows[0]["REPORTING_EMP_EMAIL"]) != System.DBNull.Value)
                                && ((Convert.ToString(dt_mail1.Rows[0]["EMP_EMAIL"]) != string.Empty) && (dt_mail1.Rows[0]["EMP_EMAIL"]) != System.DBNull.Value)
                                && ((Convert.ToString(dt_mail1.Rows[0]["REPORTING_EMP"]) != string.Empty) && ((dt_mail1.Rows[0]["REPORTING_EMP"]) != System.DBNull.Value)))
                            {
                                _obj_Smhr_LeaveApp.MODE = 1;
                                _obj_Smhr_LeaveApp.LEAVEAPP_FROMDATE = Convert.ToDateTime(rdtp_LeaveAppFromDate.SelectedDate);
                                _obj_Smhr_LeaveApp.LEAVEAPP_TODATE = Convert.ToDateTime(rdtp_LeaveAppToDate.SelectedDate);
                                _obj_Smhr_LeaveApp.LEAVEAPP_DAYS = Convert.ToSingle(rtxt_LeaveAppNoofDays.Text);
                                if (BLL.get_Leave_Mail(_obj_Smhr_LeaveApp))
                                    BLL.ShowMessage(this, "Leave Application sent for Approval And Notification Sent");
                                else
                                    BLL.ShowMessage(this, "Leave Application sent for Approval");
                            }
                            else
                            {
                                BLL.ShowMessage(this, "Leave Application sent for Approval");
                            }
                        }
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Information Not Saved");
                    }
                    //_obj_Smhr_LeaveApp = new SMHR_LEAVEAPP();
                    //_obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID = Convert.ToInt32(rcmb_LeaveAppEmployeeID.SelectedItem.Value);
                    //_obj_Smhr_LeaveApp.MODE = 4;
                    //DataTable dt_mail1 = BLL.get_EmpLeaveDetails(_obj_Smhr_LeaveApp);
                    //if (dt_mail1.Rows.Count > 0)
                    //{
                    //    //if (!((dt_mail.Rows[0]["REPORTING_EMP_EMAIL"] != System.DBNull.Value && dt_mail.Rows[0]["REPORTING_EMP_EMAIL"] != string.Empty) || (dt_mail.Rows[0]["EMP_EMAIL"] != System.DBNull.Value && dt_mail.Rows[0]["EMP_EMAIL"] != string.Empty) || (dt_mail.Rows[0]["REPORTING_EMP"] != System.DBNull.Value && dt_mail.Rows[0]["REPORTING_EMP"] != string.Empty)))
                    //    if (((Convert.ToString(dt_mail1.Rows[0]["REPORTING_EMP_EMAIL"]) != string.Empty) && (dt_mail1.Rows[0]["REPORTING_EMP_EMAIL"]) != System.DBNull.Value)
                    //        && ((Convert.ToString(dt_mail1.Rows[0]["EMP_EMAIL"]) != string.Empty) && (dt_mail1.Rows[0]["EMP_EMAIL"]) != System.DBNull.Value)
                    //        && ((Convert.ToString(dt_mail1.Rows[0]["REPORTING_EMP"]) != string.Empty) && ((dt_mail1.Rows[0]["REPORTING_EMP"]) != System.DBNull.Value)))
                    //    {
                    //        _obj_Smhr_LeaveApp.MODE = 1;
                    //        _obj_Smhr_LeaveApp.LEAVEAPP_FROMDATE = Convert.ToDateTime(rdtp_LeaveAppFromDate.SelectedDate);
                    //        _obj_Smhr_LeaveApp.LEAVEAPP_TODATE = Convert.ToDateTime(rdtp_LeaveAppToDate.SelectedDate);
                    //        _obj_Smhr_LeaveApp.LEAVEAPP_DAYS = Convert.ToSingle(rtxt_LeaveAppNoofDays.Text);
                    //        if (BLL.get_Leave_Mail(_obj_Smhr_LeaveApp))
                    //        {
                    //            BLL.ShowMessage(this, "Notification Sent");
                    //        }
                    //    }
                    //}
                    break;
                default:
                    break;
            }
            Rm_LA_page.SelectedIndex = 0;
            LoadGrid();
            Rg_LeaveApp.DataBind();
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Leaveapplication", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void clearControls()
    {
        try
        {
            lbl_LeaveAppID.Text = string.Empty;
            rcmb_LeaveAppEmployeeID.SelectedIndex = -1;
            rcmb_LeaveAppLType.SelectedIndex = -1;
            rdtp_LeaveAppFromDate.SelectedDate = null;
            rdtp_LeaveAppToDate.SelectedDate = null;
            rtxt_LeaveAppNoofDays.Text = string.Empty;
            rdtp_LeaveAppAppliedDate.SelectedDate = null;
            rtxt_LeaveAppReason.Text = string.Empty;
            rbtn_FromDate.SelectedIndex = 0;
            rbtn_ToDate.SelectedIndex = 0;
            //chk_LeaveAppFirstHalf.Checked = false;
            //chk_LeaveAppSecondHalf.Checked = false;
            btn_LeaveCancel.Visible = false;
            btn_Save.Visible = false;
            btn_Update.Visible = false;
            Rm_LA_page.SelectedIndex = 0;
            rdtp_LeaveAppFromDate.MinDate = Convert.ToDateTime("01-01-2013");
            rdtp_LeaveAppToDate.MinDate = Convert.ToDateTime("01-01-2013");
            //rdtp_LeaveAppToDate.MinDate = Convert.ToDateTime("01-01-1900");
            rcmb_IncidentLeave.ClearSelection();
            rcmb_LeaveAppLType.ClearSelection();
            trIncident.Visible = false;
            trIncidentLink.Visible = false; //To hide linkbutton which is used to show incident details popup
            EnabledFields(true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Leaveapplication", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            BLL.ShowMessage(this, ex.Message.ToString());
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearControls();
            //bool status = Convert.ToBoolean(Session["checkRole"]);
            //if (Control != null)
            //{
            //    if (Session["DASHBOARD"] != null && Control.ToUpper() == "SELFLEAVE")
            //    {
            //        if (status == true)
            //        {

            //            Response.Redirect("~/Security/frm_Dashboard.aspx", false);
            //        }
            //        else
            //        {

            //            Response.Redirect("~/Security/frm_Dashboradmngr.aspx", false);
            //        }
            //    }
            //    else
            //    {
            //        Rm_LA_page.SelectedIndex = 0;
            //    }
            //}
            //else
            //{
            //    Rm_LA_page.SelectedIndex = 0;
            //}
            //COMMENTED ABOVE CODE ON 25.01.2013
            Rm_LA_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Leaveapplication", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Leaveapplication", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            BLL.ShowMessage(this, ex.Message.ToString());
        }
    }
    protected void LoadEmployees()
    {
        try  //sravani 05.02.2011
        {
            //if (Convert.ToString(Session["SELFSERVICE"]) == "")
            //{
            //    //FOR MANAGER
            //    rcmb_LeaveAppEmployeeID.Items.Clear();
            //    SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
            //    _obj_smhr_emp_payitems.OPERATION = operation.Empty_Self;
            //    _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //    _obj_smhr_emp_payitems.REPORTING_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            //    _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
            //    DataTable dt_Details = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
            //    rcmb_LeaveAppEmployeeID.DataSource = dt_Details;
            //    rcmb_LeaveAppEmployeeID.DataTextField = "EMPNAME";
            //    rcmb_LeaveAppEmployeeID.DataValueField = "EMP_ID";
            //    rcmb_LeaveAppEmployeeID.DataBind();
            //    rcmb_LeaveAppEmployeeID.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));//previously it is blocke and unblocked by bharadwaj
            //}
            //else
            //{
            //FOR ADMIN
            rcmb_LeaveAppEmployeeID.Items.Clear();
            SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
            _obj_smhr_emp_payitems.OPERATION = operation.Empty;
            _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
            DataTable dt_Details = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
            rcmb_LeaveAppEmployeeID.DataSource = dt_Details;
            rcmb_LeaveAppEmployeeID.DataTextField = "EMPNAME";
            rcmb_LeaveAppEmployeeID.DataValueField = "EMP_ID";
            rcmb_LeaveAppEmployeeID.DataBind();
            rcmb_LeaveAppEmployeeID.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));//previously it is blocke and unblocked by bharadwaj
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Leaveapplication", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        //rcmb_LeaveAppEmployeeID.Items.Clear();
        //SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
        //_obj_smhr_emp_payitems.OPERATION = operation.Validate;
        //_obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
        //_obj_smhr_emp_payitems.SMHR_EMP_PAYITEMS_EMPID = Convert.ToInt32(Session["EMP_ID"]);
        //DataTable dt_Details = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
        //rcmb_LeaveAppEmployeeID.DataSource = dt_Details;
        //rcmb_LeaveAppEmployeeID.DataTextField = "EMPNAME";
        //rcmb_LeaveAppEmployeeID.DataValueField = "EMP_ID";
        //rcmb_LeaveAppEmployeeID.DataBind();
        //rcmb_LeaveAppEmployeeID.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));//blocked by me
    }
    protected void rcmb_BusinessUnit_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rcbCalPrd.SelectedIndex = 0;
            trEmpLeaveBal.Visible = false;
            LoadEmployees();
            rcmb_LeaveAppLType.ClearSelection();
            rcmb_LeaveAppLType.Items.Clear();
            rcmb_LeaveAppLType.Text = string.Empty;
            trIncident.Visible = false;
            trIncidentLink.Visible = false; //To hide linkbutton to show incident details popup
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Leaveapplication", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            BLL.ShowMessage(this, ex.Message.ToString());
        }
    }
    protected void rcmb_LeaveAppEmployeeID_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rcbCalPrd.SelectedIndex = 0;
            trEmpLeaveBal.Visible = false;
            LoadLeaveTypes();
            trIncident.Visible = false;
            trIncidentLink.Visible = false; //To hide linkbutton to show incident details popup
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Leaveapplication", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            BLL.ShowMessage(this, ex.Message.ToString());
        }
    }
    protected void LoadLeaveTypes()
    {
        try
        {
            if (rcmb_LeaveAppEmployeeID.SelectedItem.Text.ToUpper() != "SELECT")
            {
                SMHR_LEAVEAPP _obj_Smhr_LeaveApp = new SMHR_LEAVEAPP();

                //_obj_Smhr_LeaveApp.OPERATION = operation.Insert;
                //_obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID = Convert.ToInt32(rcmb_LeaveAppEmployeeID.SelectedItem.Value);
                _obj_Smhr_LeaveApp.OPERATION = operation.Get;
                _obj_Smhr_LeaveApp.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

                rcmb_LeaveAppLType.Items.Clear();
                rcmb_LeaveAppLType.DataSource = BLL.get_LeaveApp(_obj_Smhr_LeaveApp);
                rcmb_LeaveAppLType.DataTextField = "LEAVEMASTER_CODE";
                rcmb_LeaveAppLType.DataValueField = "LEAVEMASTER_ID";
                rcmb_LeaveAppLType.DataBind();
                rcmb_LeaveAppLType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

                getLeavedetails();
            }
            else
            {
                rcmb_LeaveAppLType.Items.Clear();
                rcmb_LeaveAppLType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
            }

            rdtp_LeaveAppToDate.SelectedDate = null;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Leaveapplication", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_LeaveAppLType_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            //trIncident.Visible = false;
            //trIncidentLink.Visible = false; //To hide linkbutton to show incident details popup
            ////trRG_Incident.Visible = false;

            //rdtp_LeaveAppFromDate.SelectedDate = null;
            //rdtp_LeaveAppToDate.SelectedDate = null;
            //rtxt_LeaveAppNoofDays.Text = string.Empty;
            //rdtp_LeaveAppToDate.MinDate = Convert.ToDateTime("01-01-2013");
            //if (rcmb_LeaveAppLType.SelectedItem.Text.ToUpper() != "SELECT" && rcmb_LeaveAppEmployeeID.SelectedItem.Text.ToUpper() != "SELECT")
            //{
            //    rdtp_LeaveAppToDate.Enabled = true;
            //    SMHR_LEAVEAPP _obj_Smhr_LeaveApp = new SMHR_LEAVEAPP();
            //    _obj_Smhr_LeaveApp.OPERATION = operation.Update;
            //    _obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID = Convert.ToInt32(rcmb_LeaveAppEmployeeID.SelectedItem.Value);
            //    _obj_Smhr_LeaveApp.LEAVEAPP_LEAVETYPE_ID = Convert.ToInt32(rcmb_LeaveAppLType.SelectedItem.Value);
            //    DataTable dt = BLL.get_LeaveApp(_obj_Smhr_LeaveApp);

            //    if (dt.Rows.Count != 0)
            //    {
            //        if (Convert.ToBoolean(dt.Rows[0]["ISHALFDAYS"]) != true)
            //        {
            //            rbtn_FromDate.Items[0].Enabled = false;
            //            rbtn_ToDate.Items[0].Enabled = false;

            //            rbtn_FromDate.Items[1].Selected = true;
            //            rbtn_ToDate.Items[1].Selected = true;

            //        }
            //        else
            //        {
            //            rbtn_FromDate.Items[0].Enabled = true;
            //            rbtn_ToDate.Items[0].Enabled = true;

            //            rbtn_FromDate.Items[0].Selected = true;
            //            rbtn_ToDate.Items[0].Selected = true;

            //        }
            //    }
            //    getLeavedetails();
            //    LoadIncidentLeave();  //if selected leave type is incident leave, populate incidents.
            //}
            //else
            //{
            //    getLeavedetails();
            //    //rdtp_LeaveAppToDate.Enabled = false;
            //    //rcmb_LeaveAppLType.Items.Clear();
            //    //rcmb_LeaveAppLType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Leaveapplication", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void rcbCalPrd_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcbCalPrd.SelectedIndex > 0 && rcmb_LeaveAppEmployeeID.SelectedIndex > 0)
            {
                trEmpLeaveBal.Visible = true;
                lblEmpLeaveBal.Text = string.Empty;

                SMHR_LOB _obj_smhr_lob = new SMHR_LOB();

                _obj_smhr_lob.OPERATION = operation.Get;
                _obj_smhr_lob.LT_EMPID = Convert.ToInt32(rcmb_LeaveAppEmployeeID.SelectedValue);
                _obj_smhr_lob.LT_PERIOD = Convert.ToInt32(rcbCalPrd.SelectedValue);

                DataTable dtLob = BLL.getEmpLOB(_obj_smhr_lob);

                if (dtLob.Rows.Count > 0)
                    lblEmpLeaveBal.Text = Convert.ToString(dtLob.Rows[0]["LT_CURRENTBALANCE"]);
                else
                    lblEmpLeaveBal.Text = "No Leave balances were defined for selected calendar period";
            }
            else
            {
                trEmpLeaveBal.Visible = false;

                BLL.ShowMessage(this, "Please select Calendar Period to get leave balances");
                rcbCalPrd.Focus();
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Leaveapplication", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            BLL.ShowMessage(this, ex.Message.ToString());
        }
    }
    private void LoadIncidentLeave()
    {
        try
        {
            //To check if selected LeaveType is an Incident type
            SMHR_LEAVEAPP _obj_Smhr_LeaveApp = new SMHR_LEAVEAPP();
            _obj_Smhr_LeaveApp.OPERATION = operation.CHECKEXISTS;
            _obj_Smhr_LeaveApp.LEAVEAPP_LEAVETYPE_ID = Convert.ToInt32(rcmb_LeaveAppLType.SelectedValue);
            _obj_Smhr_LeaveApp.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_LeaveApp(_obj_Smhr_LeaveApp);
            if (dt.Rows.Count > 0)
            {
                if (Convert.ToBoolean(dt.Rows[0]["LEAVEMASTER_ISINCIDENT"]) == true)
                {
                    LoadIncident();    //If selected LeaveType is Incident then, populate Incidents in combobox
                    trIncident.Visible = true; //To show Incident combobox
                }
                else
                {
                    trIncident.Visible = false;    //If selected LeaveType is not Incident then, hide Incident combobox
                }
            }
            else
            {
                trIncident.Visible = false;
                rcmb_IncidentLeave.Items.Clear();
                //trRG_Incident.Visible = false;
                //RWIncidentDetails.Visible = false;
                trIncidentLink.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Leaveapplication", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private bool IsIncidentLeave()
    {
        bool flag = false;
        try
        {


            //To check if selected LeaveType is an Incident type
            SMHR_LEAVEAPP _obj_Smhr_LeaveApp = new SMHR_LEAVEAPP();
            _obj_Smhr_LeaveApp.OPERATION = operation.CHECKEXISTS;
            _obj_Smhr_LeaveApp.LEAVEAPP_LEAVETYPE_ID = Convert.ToInt32(rcmb_LeaveAppLType.SelectedValue);
            _obj_Smhr_LeaveApp.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_LeaveApp(_obj_Smhr_LeaveApp);
            if (dt.Rows.Count > 0)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Leaveapplication", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            BLL.ShowMessage(this, ex.Message.ToString());
        }
        return flag;
    }
    private void LoadIncident()
    {
        try
        {
            SMHR_WorkmanCompensation objWorkComp = new SMHR_WorkmanCompensation();
            objWorkComp.OPERATION = operation.Select1;
            objWorkComp.EmpID = Convert.ToInt32(rcmb_LeaveAppEmployeeID.SelectedValue);
            DataSet dsInicidentInjury = new DataSet();
            dsInicidentInjury = BLL.GET_SMHR_INCIDENTS(objWorkComp);
            //To populate incidents from SMHR_INCIDENTS_MASTER table
            rcmb_IncidentLeave.Items.Clear();
            rcmb_IncidentLeave.Text = string.Empty;
            if (dsInicidentInjury.Tables.Count > 0)
            {
                if (dsInicidentInjury.Tables[0].Rows.Count > 0)
                {
                    rcmb_IncidentLeave.DataSource = dsInicidentInjury.Tables[0];
                    rcmb_IncidentLeave.DataTextField = "INCIDENT_NAME";
                    rcmb_IncidentLeave.DataValueField = "INCIDENT_ID";
                    rcmb_IncidentLeave.DataBind();
                    rcmb_IncidentLeave.Items.Insert(0, new RadComboBoxItem("Select"));
                }
                else
                {
                    rcmb_IncidentLeave.Items.Clear();
                    BLL.ShowMessage(this, "No Incidents Exist for the selected employee");
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Leaveapplication", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            BLL.ShowMessage(this, ex.Message.ToString());
        }
    }
    protected void getDays()
    {
        try
        {
            SMHR_LEAVEAPP _obj_Smhr_LeaveApp = new SMHR_LEAVEAPP();
            _obj_Smhr_LeaveApp.OPERATION = operation.Empty;
            _obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID = Convert.ToInt32(rcmb_LeaveAppEmployeeID.SelectedItem.Value);
            _obj_Smhr_LeaveApp.LEAVEAPP_LEAVETYPE_ID = Convert.ToInt32(rcmb_LeaveAppLType.SelectedItem.Value);
            _obj_Smhr_LeaveApp.LEAVEAPP_FROMDATE = Convert.ToDateTime(rdtp_LeaveAppFromDate.SelectedDate);
            _obj_Smhr_LeaveApp.LEAVEAPP_TODATE = Convert.ToDateTime(rdtp_LeaveAppToDate.SelectedDate);
            _obj_Smhr_LeaveApp.LEAVEAPP_FIRSTHALF = Convert.ToBoolean(Convert.ToUInt32(rbtn_FromDate.SelectedItem.Value));
            _obj_Smhr_LeaveApp.LEAVEAPP_SECONDHALF = Convert.ToBoolean(Convert.ToUInt32(rbtn_ToDate.SelectedItem.Value));
            DataTable dt = BLL.get_LeaveApp(_obj_Smhr_LeaveApp);
            rtxt_LeaveAppNoofDays.Text = Convert.ToString(dt.Rows[0]["DAYS"]);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Leaveapplication", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Calc_Click(object sender, EventArgs e)
    {
        try
        {
            if (rdtp_LeaveAppFromDate.SelectedDate != null && rdtp_LeaveAppToDate.SelectedDate != null)
            {
                if (Convert.ToDateTime(rdtp_LeaveAppFromDate.SelectedDate) == Convert.ToDateTime(rdtp_LeaveAppToDate.SelectedDate))
                {
                    rbtn_ToDate.Items[0].Enabled = false;
                    rbtn_ToDate.SelectedIndex = 1;
                }
                else
                    rbtn_ToDate.Items[0].Enabled = true;
            }
            getDays();
            getLeavedetails();
            //if ((rdtp_LeaveAppFromDate.SelectedDate != null) && (rdtp_LeaveAppToDate != null))
            //{
            //    if ((rdtp_LeaveAppToDate.SelectedDate == rdtp_LeaveAppToDate.SelectedDate) && (Convert.ToBoolean((rbtn_ToDate.SelectedValue == "0") && (rbtn_FromDate.SelectedValue == "0"))))
            //        rtxt_LeaveAppNoofDays.Text = "0.0";
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Leaveapplication", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            BLL.ShowMessage(this, ex.Message.ToString());
        }
    }
    private void getLeavedetails()
    {
        try
        {
            if (Convert.ToString(rcmb_LeaveAppEmployeeID.SelectedItem.Value) == string.Empty)
            {
                BLL.ShowMessage(this, "Please Select Employee Before Selecting From Date.");
                return;
            }
            SMHR_LEAVEBALANCE _obj_Smhr_LeaveBalance = new SMHR_LEAVEBALANCE();
            _obj_Smhr_LeaveBalance.LT_EMPID = Convert.ToInt32(rcmb_LeaveAppEmployeeID.SelectedItem.Value);
            _obj_Smhr_LeaveBalance.MODE = 0;
            DataTable dt = BLL.get_leavebalances(_obj_Smhr_LeaveBalance);
            HtmlTableRow ht_row, ht_row1;
            HtmlTableCell ht_cell;
            ht_row = new HtmlTableRow();
            ht_row1 = new HtmlTableRow();

            tbl_Leavebalance.Rows.Clear();
            tbl_Leavebalance.Border = 1;
            foreach (DataRow item in dt.Rows)
            {
                ht_cell = new HtmlTableCell();
                ht_cell.InnerText = Convert.ToString(item["LEAVETYPE"]);
                ht_row.Cells.Add(ht_cell);

                ht_cell = new HtmlTableCell();
                ht_cell.InnerText = Convert.ToString(item["LT_CURRENTBALANCE"]);
                ht_cell.Align = "center";
                ht_row1.Cells.Add(ht_cell);

            }
            tbl_Leavebalance.Rows.Add(ht_row);
            tbl_Leavebalance.Rows.Add(ht_row1);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Leaveapplication", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Edit_1_Command(object sender, CommandEventArgs e)
    {
        try
        {
            rcmb_BusinessUnit.Enabled = false;
            rcmb_LeaveAppEmployeeID.Enabled = false;
            rcmb_LeaveAppLType.Enabled = false;
            rdtp_LeaveAppFromDate.Enabled = false;
            rdtp_LeaveAppToDate.Enabled = false;
            rtxt_LeaveAppNoofDays.Enabled = false;
            //rdtp_LeaveAppAppliedDate.Enabled = b;
            rtxt_LeaveAppReason.Enabled = false;
            rcmb_IncidentLeave.Enabled = false;
            rbtn_FromDate.Enabled = false;
            rbtn_ToDate.Enabled = false;
            FUpload_Doc.Enabled = false;
            lnk_Download.Enabled = false;
            loadDropdown();
            // clearControls();
            DataTable dt = BLL.get_LeaveApp(new SMHR_LEAVEAPP(Convert.ToInt32(Convert.ToString(e.CommandArgument))));

            lbl_LeaveAppID.Text = Convert.ToString(e.CommandArgument);
            rcmb_BusinessUnit.SelectedIndex = rcmb_BusinessUnit.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["BUSINESSUNIT_ID"]));
            rcmb_BusinessUnit_SelectedIndexChanged(null, null);

            SMHR_LEAVEAPP _obj_Smhr_LeaveApp = new SMHR_LEAVEAPP();
            _obj_Smhr_LeaveApp.BUSINESSUNIT_ID = Convert.ToInt32(Convert.ToString(dt.Rows[0]["BUSINESSUNIT_ID"]));
            _obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID = Convert.ToInt32(Convert.ToString(dt.Rows[0]["LEAVEAPP_EMP_ID"]));
            _obj_Smhr_LeaveApp.MODE = 3;
            DataTable dtemp = BLL.get_EmpLeaveDetails(_obj_Smhr_LeaveApp);
            rcmb_LeaveAppEmployeeID.DataSource = dtemp;
            rcmb_LeaveAppEmployeeID.DataTextField = "EMPNAME";
            rcmb_LeaveAppEmployeeID.DataValueField = "EMP_ID";
            rcmb_LeaveAppEmployeeID.DataBind();
            rcmb_LeaveAppEmployeeID.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
            rcmb_LeaveAppEmployeeID.SelectedIndex = rcmb_LeaveAppEmployeeID.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LEAVEAPP_EMP_ID"]));
            LoadLeaveTypes();
            rcmb_LeaveAppLType.SelectedIndex = rcmb_LeaveAppLType.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LEAVEAPP_LEAVETYPE_ID"]));
            rdtp_LeaveAppFromDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["LEAVEAPP_FROMDATE"]);
            rdtp_LeaveAppToDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["LEAVEAPP_TODATE"]);
            rtxt_LeaveAppNoofDays.Text = Convert.ToString(dt.Rows[0]["LEAVEAPP_DAYS"]);
            rdtp_LeaveAppAppliedDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["LEAVEAPP_APPLIEDDATE"]);
            rtxt_LeaveAppReason.Text = Convert.ToString(dt.Rows[0]["LEAVEAPP_REASON"]);
            rbtn_FromDate.SelectedIndex = rbtn_FromDate.Items.IndexOf(rbtn_FromDate.Items.FindByValue(Convert.ToString(dt.Rows[0]["LEAVEAPP_FIRSTHALF"])));
            LoadCalPeriod();
            rcbCalPrd.SelectedIndex = rcbCalPrd.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LEAVEAPP_CAL_PERIOD"]));
            rcbCalPrd.Enabled = false;
            // chk_LeaveAppFirstHalf.Checked = ;
            rbtn_ToDate.SelectedIndex = rbtn_ToDate.Items.IndexOf(rbtn_ToDate.Items.FindByValue(Convert.ToString(dt.Rows[0]["LEAVEAPP_SECONDHALF"])));
            int i = Convert.ToInt32(dt.Rows[0]["LEAVEAPP_STATUS"]);
            ViewState["LEAVE_STATUS"] = i;
            if (i == 3)
            {
                BLL.ShowMessage(this, " Ooops!!!You Cannot Cancel A Cancelled Leave Again !!");
                return;
            }
            else if (i == 2)
            {
                BLL.ShowMessage(this, " Ooops!!!You Cannot Cancel A Rejected Leave Again !!");
                return;
            }
            else if (i == 1)
            {
                BLL.ShowMessage(this, " Ooops!!!You Cannot Cancel An Approved Leave Again !!");
                return;
            }
            else
            {
                if (Convert.ToDateTime(dt.Rows[0]["LEAVEAPP_FROMDATE"]) >= System.DateTime.Now)
                {
                    if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                    {
                        btn_LeaveCancel.Visible = false;
                    }
                    else
                    {
                        btn_LeaveCancel.Visible = true;
                    }
                    Rm_LA_page.SelectedIndex = 1;
                }
                else
                {
                    BLL.ShowMessage(this, "This Leave Cannot Be Cancelled As The Leave Date " + (Convert.ToDateTime(dt.Rows[0]["LEAVEAPP_FROMDATE"]) == System.DateTime.Now ? "Is The Present Day" : "Already Passed"));
                    Rm_LA_page.SelectedIndex = 0;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Leaveapplication", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void EnabledFields(bool b)
    {
        try
        {
            rcmb_BusinessUnit.Enabled = b;
            rcmb_LeaveAppEmployeeID.Enabled = b;
            rcmb_LeaveAppLType.Enabled = b;
            rdtp_LeaveAppFromDate.Enabled = b;
            rdtp_LeaveAppToDate.Enabled = b;
            rtxt_LeaveAppNoofDays.Enabled = b;
            //rdtp_LeaveAppAppliedDate.Enabled = b;
            rtxt_LeaveAppReason.Enabled = b;
            rcmb_IncidentLeave.Enabled = b;
            rbtn_FromDate.Enabled = b;
            rbtn_ToDate.Enabled = b;
            FUpload_Doc.Enabled = b;
            lnk_Download.Enabled = b;

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Leaveapplication", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            BLL.ShowMessage(this, ex.Message.ToString());
        }
    }
    protected void btn_LeaveCancel_Click(object sender, EventArgs e)
    {
        try
        {

            rcmb_BusinessUnit.Enabled = false;
            rcmb_LeaveAppEmployeeID.Enabled = false;
            rcmb_LeaveAppLType.Enabled = false;
            rdtp_LeaveAppFromDate.Enabled = false;
            rdtp_LeaveAppToDate.Enabled = false;
            rtxt_LeaveAppNoofDays.Enabled = false;
            //rdtp_LeaveAppAppliedDate.Enabled = b;
            rtxt_LeaveAppReason.Enabled = false;
            rcmb_IncidentLeave.Enabled = false;
            rbtn_FromDate.Enabled = false;
            rbtn_ToDate.Enabled = false;
            FUpload_Doc.Enabled = false;
            lnk_Download.Enabled = false;
            SMHR_LEAVEAPP _obj_Smhr_LeaveApp = new SMHR_LEAVEAPP();
            _obj_Smhr_LeaveApp.OPERATION = operation.Update;
            _obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID = Convert.ToInt32(rcmb_LeaveAppEmployeeID.SelectedItem.Value);
            _obj_Smhr_LeaveApp.LEAVEAPP_LEAVETYPE_ID = Convert.ToInt32(rcmb_LeaveAppLType.SelectedItem.Value);
            _obj_Smhr_LeaveApp.LEAVEAPP_FROMDATE = Convert.ToDateTime(rdtp_LeaveAppFromDate.SelectedDate);
            _obj_Smhr_LeaveApp.LEAVEAPP_TODATE = Convert.ToDateTime(rdtp_LeaveAppToDate.SelectedDate);
            _obj_Smhr_LeaveApp.LEAVEAPP_DAYS = float.Parse(rtxt_LeaveAppNoofDays.Text);
            _obj_Smhr_LeaveApp.LEAVEAPP_APPLIEDDATE = Convert.ToDateTime(rdtp_LeaveAppAppliedDate.SelectedDate);
            _obj_Smhr_LeaveApp.LEAVEAPP_REASON = BLL.ReplaceQuote(rtxt_LeaveAppReason.Text);
            _obj_Smhr_LeaveApp.LEAVEAPP_FIRSTHALF = Convert.ToBoolean(Convert.ToUInt32(rbtn_FromDate.SelectedItem.Value));
            _obj_Smhr_LeaveApp.LEAVEAPP_SECONDHALF = Convert.ToBoolean(Convert.ToUInt32(rbtn_ToDate.SelectedItem.Value));
            _obj_Smhr_LeaveApp.LEAVEAPP_CAL_PERIOD = Convert.ToInt32(rcbCalPrd.SelectedItem.Value);
            _obj_Smhr_LeaveApp.LEAVEAPP_DAYS = float.Parse(rtxt_LeaveAppNoofDays.Text);
            _obj_Smhr_LeaveApp.LEAVEAPP_ID = Convert.ToInt32(lbl_LeaveAppID.Text);
            _obj_Smhr_LeaveApp.LEAVEAPP_STATUS = 3;
            _obj_Smhr_LeaveApp.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_Smhr_LeaveApp.LASTMDFDATE = System.DateTime.Now;

            bool rs = BLL.set_LeaveApp(_obj_Smhr_LeaveApp);
            if (rs == true)
            {
                if (ViewState["LEAVE_STATUS"].ToString() == "1")
                {
                    SMHR_LEAVEBALANCE _obj_smhr_leavebal = new SMHR_LEAVEBALANCE();
                    _obj_smhr_leavebal.LT_EMPID = Convert.ToInt32(rcmb_LeaveAppEmployeeID.SelectedItem.Value);
                    _obj_smhr_leavebal.LT_LEAVETYPEID = Convert.ToInt32(rcmb_LeaveAppLType.SelectedItem.Value);
                    _obj_smhr_leavebal.NDays = float.Parse(rtxt_LeaveAppNoofDays.Text);
                    _obj_smhr_leavebal.MODE = 6;
                    _obj_Smhr_LeaveApp.OPERATION = operation.Update;
                    BLL.set_leavebalances(_obj_smhr_leavebal);
                    BLL.ShowMessage(this, "Leave Cancellation Done And Balances Updated Successfully ");

                }
                else
                {
                    //BLL.ShowMessage(this, "Leave Cancellation Done Successfully!");
                    //Rm_LA_page.SelectedIndex = 1;
                    //LoadGrid();
                    //Rg_LeaveApp.DataBind();
                }
                _obj_Smhr_LeaveApp = new SMHR_LEAVEAPP();
                _obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID = Convert.ToInt32(rcmb_LeaveAppEmployeeID.SelectedItem.Value);
                _obj_Smhr_LeaveApp.LEAVEAPP_ID = Convert.ToInt32(lbl_LeaveAppID.Text);

                _obj_Smhr_LeaveApp.MODE = 4;
                dt_mail = BLL.get_EmpLeaveDetails(_obj_Smhr_LeaveApp);
                if (dt_mail.Rows.Count > 0)
                {
                    //if (!((dt_mail.Rows[0]["REPORTING_EMP_EMAIL"] != System.DBNull.Value && dt_mail.Rows[0]["REPORTING_EMP_EMAIL"] != string.Empty) || (dt_mail.Rows[0]["EMP_EMAIL"] != System.DBNull.Value && dt_mail.Rows[0]["EMP_EMAIL"] != string.Empty) || (dt_mail.Rows[0]["REPORTING_EMP"] != System.DBNull.Value && dt_mail.Rows[0]["REPORTING_EMP"] != string.Empty)))
                    if (((Convert.ToString(dt_mail.Rows[0]["REPORTING_EMP_EMAIL"]) != string.Empty) && (dt_mail.Rows[0]["REPORTING_EMP_EMAIL"]) != System.DBNull.Value)
                        && ((Convert.ToString(dt_mail.Rows[0]["EMP_EMAIL"]) != string.Empty) && (dt_mail.Rows[0]["EMP_EMAIL"]) != System.DBNull.Value)
                        && ((Convert.ToString(dt_mail.Rows[0]["REPORTING_EMP"]) != string.Empty) && ((dt_mail.Rows[0]["REPORTING_EMP"]) != System.DBNull.Value)))
                    {
                        _obj_Smhr_LeaveApp.MODE = 7;
                        _obj_Smhr_LeaveApp.LEAVEAPP_FROMDATE = Convert.ToDateTime(rdtp_LeaveAppFromDate.SelectedDate);
                        _obj_Smhr_LeaveApp.LEAVEAPP_TODATE = Convert.ToDateTime(rdtp_LeaveAppToDate.SelectedDate);
                        _obj_Smhr_LeaveApp.LEAVEAPP_DAYS = float.Parse(rtxt_LeaveAppNoofDays.Text);
                        if (BLL.get_Leave_Mail(_obj_Smhr_LeaveApp))
                            BLL.ShowMessage(this, "Leave Cancellation Done Successfully And Notification Sent");
                        else
                            BLL.ShowMessage(this, "Leave Cancellation Done Successfully");
                    }
                }
            }
            Rm_LA_page.SelectedIndex = 1;
            LoadGrid();
            Rg_LeaveApp.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Leaveapplication", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void lnk_Cal_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "function pageLoad(){  ShowPopForm(); }", true);
            getLeavedetails();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Leaveapplication", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            BLL.ShowMessage(this, ex.Message.ToString());
        }
    }
    protected bool get_DOJ()
    {
        try
        {
            //string str_AppliedDate = Convert.ToString(ViewState["AppliedDate"]);
            SMHR_EMPLOYEE obj_smhr_employee = new SMHR_EMPLOYEE();
            //ViewState["DTLEMP"] = rcmb_LeaveAppEmployeeID.SelectedItem.Value;
            //obj_smhr_employee.EMP_ID = Convert.ToInt32(ViewState["DTLEMP"]);
            obj_smhr_employee.EMP_ID = Convert.ToInt32(rcmb_LeaveAppEmployeeID.SelectedValue);
            obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_EMP = BLL.get_Employee(obj_smhr_employee);
            if (dt_EMP.Rows.Count != 0)
            {
                //if ((Convert.ToDateTime(dt_EMP.Rows[0]["EMP_DOJ"])) < (Convert.ToDateTime(str_AppliedDate)))
                if (((Convert.ToDateTime(dt_EMP.Rows[0]["EMP_DOJ"])) <= (Convert.ToDateTime(rdtp_LeaveAppFromDate.SelectedDate)))
                    && ((Convert.ToDateTime(dt_EMP.Rows[0]["EMP_DOJ"])) <= (Convert.ToDateTime(rdtp_LeaveAppToDate.SelectedDate)))
                    && (((Convert.ToDateTime(dt_EMP.Rows[0]["EMP_DOJ"])) <= (Convert.ToDateTime(rdtp_LeaveAppAppliedDate.SelectedDate)))))
                {
                    return true;
                }
                //else if ((Convert.ToDateTime(dt_EMP.Rows[0]["EMP_DOJ"])) < (Convert.ToDateTime(rdp_AppliedDate.SelectedDate)))
                //{
                //    return true;
                //}
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Leaveapplication", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return false;
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {


    }
    protected void lnk_IncidentDtls_Click(object sender, EventArgs e)
    {
        try
        {
            if (rcmb_LeaveAppLType.SelectedIndex > 0)
            {
                getLeavedetails();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Leaveapplication", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            BLL.ShowMessage(this, ex.Message.ToString());
        }
    }
    protected void rdtp_LeaveAppFromDate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        try
        {
            if (rdtp_LeaveAppFromDate.SelectedDate != null)
            {
                if (Convert.ToString(Convert.ToDateTime(rdtp_LeaveAppFromDate.SelectedDate).DayOfWeek) == "Saturday" ||
                    Convert.ToString(Convert.ToDateTime(rdtp_LeaveAppFromDate.SelectedDate).DayOfWeek) == "Sunday")
                {
                    BLL.ShowMessage(this, "Please select week days for applying leave");
                    rdtp_LeaveAppFromDate.Clear();
                    rdtp_LeaveAppFromDate.Focus();
                    return;
                }
            }

            getLeavedetails();
            if ((rdtp_LeaveAppFromDate.SelectedDate != null) && (rdtp_LeaveAppToDate.SelectedDate != null))
            {
                getDays();
                getLeavedetails();
                //if ((rdtp_LeaveAppToDate.SelectedDate == rdtp_LeaveAppToDate.SelectedDate) && (Convert.ToBoolean((rbtn_ToDate.SelectedValue == "0") && (rbtn_FromDate.SelectedValue == "0"))))
                //   rtxt_LeaveAppNoofDays.Text = "0.0";
            }
            if (Convert.ToString(rcmb_LeaveAppEmployeeID.SelectedItem.Value) == string.Empty)
            {
                rdtp_LeaveAppFromDate.SelectedDate = null;
                rdtp_LeaveAppToDate.MinDate = Convert.ToDateTime("01-01-2013");
                rtxt_LeaveAppNoofDays.Text = string.Empty;
            }
            if (rdtp_LeaveAppFromDate.SelectedDate != null)
            {
                rdtp_LeaveAppToDate.SelectedDate = null;
                rdtp_LeaveAppToDate.MinDate = Convert.ToDateTime(rdtp_LeaveAppFromDate.SelectedDate);
                rtxt_LeaveAppNoofDays.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Leaveapplication", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            BLL.ShowMessage(this, ex.Message.ToString());
        }
    }
    protected void rcmb_IncidentLeave_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(rcmb_IncidentLeave.SelectedValue))
                trIncidentLink.Visible = true;  //To show link button which is used to show/hide the "Employee Incidents" grid
            else
            {
                trIncidentLink.Visible = false; //To show link button which is used to show/hide the "Employee Incidents" grid
                //trIncident.Visible = false;
            }

            if (rcmb_LeaveAppLType.SelectedIndex > 0)
            {
                getLeavedetails();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Leaveapplication", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    //protected void lnk_IncidentDtls_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (lnk_IncidentDtls.Text == "Click to view Employee Incident Details")
    //        {
    //            LoadIncidentsGrid();
    //            RG_Incident.DataBind();
    //            //To show popup
    //            //RWIncidentDetails.Height = 400;
    //            //RWIncidentDetails.Width = 600;
    //            RWIncidentDetails.Visible = true;
    //            lnk_IncidentDtls.Text = "Click to hide Employee Incident Details";
    //        }
    //        else
    //        {
    //            RWIncidentDetails.Visible = false;
    //        }


    //        //if (trRG_Incident.Visible)
    //        //{
    //        //    trRG_Incident.Visible = false;
    //        //    lnk_IncidentDtls.Text = "Click to view Employee Incident Details";
    //        //}
    //        //else
    //        //{
    //        //    LoadIncidentsGrid();
    //        //    RG_Incident.DataBind();
    //        //    trRG_Incident.Visible = true;
    //        //    lnk_IncidentDtls.Text = "Click to hide Employee Incident Details";

    //        //    //To show popup
    //        //    //RWIncidentDetails.Height = 400;
    //        //    //RWIncidentDetails.Width = 600;
    //        //    //RWIncidentDetails.Visible = true;
    //        //    //RWIncidentDetails.VisibleOnPageLoad = true;
    //        //}
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Leaveapplication", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}

    //protected void RG_Incident_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    //{
    //    //LoadIncidentsGrid();
    //}

    //private void LoadIncidentsGrid()
    //{
    //    //To populate incidents which are mapped with employees in radgrid - "RG_Incident"
    //    try
    //    {
    //        SMHR_WorkmanCompensation ObjWrkComp = new SMHR_WorkmanCompensation();
    //        ObjWrkComp.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
    //        ObjWrkComp.EmpID = Convert.ToInt32(rcmb_LeaveAppEmployeeID.SelectedValue);
    //        ObjWrkComp.IncidentID = Convert.ToInt32(rcmb_IncidentLeave.SelectedValue);
    //        ObjWrkComp.OPERATION = operation.EMPDETAILS;
    //        //RG_Incident.DataSource = BLL.GET_SMHR_INCIDENTS(ObjWrkComp).Tables[0];
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Workman_Compensation_frm_AddIncidentsToEmp", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}
    protected void rdtp_LeaveAppToDate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        try
        {
            double value = 0;

            SMHR_LEAVEAPP _obj_Smhr_LeaveApp = new SMHR_LEAVEAPP();

            if (rdtp_LeaveAppFromDate.SelectedDate != null && rdtp_LeaveAppToDate.SelectedDate != null)
            {
                if (Convert.ToString(Convert.ToDateTime(rdtp_LeaveAppFromDate.SelectedDate).DayOfWeek) == "Saturday" ||
                    Convert.ToString(Convert.ToDateTime(rdtp_LeaveAppFromDate.SelectedDate).DayOfWeek) == "Sunday")
                {
                    BLL.ShowMessage(this, "Please select week days for applying leave");
                    rdtp_LeaveAppFromDate.Clear();
                    rdtp_LeaveAppFromDate.Focus();
                    return;
                }

                if (Convert.ToString(Convert.ToDateTime(rdtp_LeaveAppToDate.SelectedDate).DayOfWeek) == "Saturday" ||
                    Convert.ToString(Convert.ToDateTime(rdtp_LeaveAppToDate.SelectedDate).DayOfWeek) == "Sunday")
                {
                    BLL.ShowMessage(this, "Please select week days for applying leave");
                    rdtp_LeaveAppToDate.Clear();
                    rdtp_LeaveAppToDate.Focus();
                    return;
                }

                if (rdtp_LeaveAppFromDate.SelectedDate == rdtp_LeaveAppToDate.SelectedDate)
                {
                    if ((rbtn_FromDate.SelectedValue == "0" && rbtn_ToDate.SelectedValue == "1") || (rbtn_FromDate.SelectedValue == "1" && rbtn_ToDate.SelectedValue == "0"))
                    {
                        //BLL.ShowMessage(this, "Please select proper selections for day type..!");
                        BLL.ShowMessage(this, "Please Select  Half day or Full Day");
                        rtxt_LeaveAppNoofDays.Text = string.Empty;
                        return;
                    }

                    if (rbtn_FromDate.SelectedValue == "1" && rbtn_ToDate.SelectedValue == "1")
                        value = 0.5;
                    if (rbtn_FromDate.SelectedValue == "0" && rbtn_ToDate.SelectedValue == "0")
                        value = 1;
                }
                else
                {
                    _obj_Smhr_LeaveApp.OPERATION = operation.VALIDATEPERIOD;
                    _obj_Smhr_LeaveApp.LEAVEAPP_FROMDATE = Convert.ToDateTime(rdtp_LeaveAppFromDate.SelectedDate);
                    _obj_Smhr_LeaveApp.LEAVEAPP_TODATE = Convert.ToDateTime(rdtp_LeaveAppToDate.SelectedDate);
                    if (rbtn_FromDate.SelectedValue == "1")
                        _obj_Smhr_LeaveApp.SD = 0;
                    else
                        _obj_Smhr_LeaveApp.SD = 1;
                    if (rbtn_ToDate.SelectedValue == "1")
                        _obj_Smhr_LeaveApp.ED = 0;
                    else
                        _obj_Smhr_LeaveApp.ED = 1;

                    DataTable dt = BLL.get_LeaveApp(_obj_Smhr_LeaveApp);

                    if (dt.Rows.Count > 0)
                        value = Convert.ToDouble(dt.Rows[0]["RESULT"]);
                }
                /*if (rdtp_LeaveAppFromDate.SelectedDate == rdtp_LeaveAppToDate.SelectedDate)
                {
                    if (rbtn_FromDate.SelectedValue == "0" && rbtn_ToDate.SelectedValue == "0")
                    {
                        value = (Convert.ToDateTime(rdtp_LeaveAppToDate.SelectedDate) - Convert.ToDateTime(rdtp_LeaveAppFromDate.SelectedDate)).Days + 1;
                    }
                    else if (rbtn_FromDate.SelectedValue == "1" && rbtn_ToDate.SelectedValue == "1")
                    {
                        value = (Convert.ToDateTime(rdtp_LeaveAppToDate.SelectedDate) - Convert.ToDateTime(rdtp_LeaveAppFromDate.SelectedDate)).Days + 0.5;
                    }
                    else if ((rbtn_FromDate.SelectedValue == "0" && rbtn_ToDate.SelectedValue == "1") || (rbtn_FromDate.SelectedValue == "1" && rbtn_ToDate.SelectedValue == "0"))
                    {
                        BLL.ShowMessage(this, "Please select proper selections for day type..!");
                        rtxt_LeaveAppNoofDays.Text = string.Empty;
                        return;
                    }
                }*/
            }

            rtxt_LeaveAppNoofDays.Text = value.ToString();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Leaveapplication", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            BLL.ShowMessage(this, ex.Message.ToString());
        }
    }
    protected void rbtn_ToDate_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            rdtp_LeaveAppToDate_SelectedDateChanged(null, null);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Leaveapplication", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            BLL.ShowMessage(this, ex.Message.ToString());
        }
    }
}