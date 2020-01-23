using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;
using System.Data.SqlClient;
using SPMS;
using SMHR;
using System.Drawing;

public partial class PMS_frm_PmsAppraisalnew : System.Web.UI.Page
{
    SPMS_EMPGOALSETTING _obj_Pms_EmpGoalSetting;
    SPMS_APPRAISAL _obj_Spms_Appraisal;
    SPMS_APPRAISALGOAL _obj_Spms_AppraisalGoal;
    SPMS_GOALSETTINGKRADETAILS _obj_Spms_GoalStgKraDtls;
    SPMS_APPRAISALKRA _obj_Spms_AppraisalKra;
    SPMS_APPRAISALIDP _obj_Spms_AppraisalIdp;
    SPMS_APRAISALAPPROVER _obj_Pms_AppApprover;
    SPMS_APRAISALDISCUSSION _obj_Pms_AppDiscDtls;
    PMS_GoalSettings_Details _obj_Pms_GoalSettingdetails;
    PMS_LOGININFO _obj_Pms_LoginInfo;
    PMS_GETEMPLOYEE _obj_PMS_getemployee;
    PMS_NOTIFICATION _obj_Pms_Send_Notification;
    PMS_EMPSETUP _obj_pms_EmployeeSetup;
    SMHR_LOGININFO _obj_smhr_logininfo;
    PMS_Appraisalcycle _obj_Pms_Appraisalcycle;
    PMS_GoalSettings _obj_GS;
    PMS_EMPSETUP _obj_Pms_EmpSetup;
    SPMS_ROLES _obj_Pms_Roles;
    SPMS_ROLEKRA _obj_Pms_RoleKra;
    GOALSETTING_GOALKRA_DETAILS _obj_Pms_goalkradetails;
    PMS_GoalSettings_Details _obj_GSdetails = new PMS_GoalSettings_Details();
    string str;
    int Temp = 0;
    string strkra;
    int tempkra = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
            if (!Page.IsPostBack)
            {


                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("My Self Appraisal");//Self Appraisal");
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
                    RG_SelfAppraisal.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Submit_Detail.Visible = false;
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
                //LoadEmployees();
                LoadAppraisalCycle();
                rtxt_RpMgr.Enabled = false;
                rtxt_GpMgr.Enabled = false;
                rtxt_Role.Enabled = false;
                //rtxt_Project.Enabled = false;
                rdtp_DATEofAppraisal.SelectedDate = DateTime.Now;
                rdtp_DATEofAppraisal.Enabled = false;
                Rm_Appraisal_PAGE.SelectedIndex = 0;
                //btn_Submit.Visible = false;
                //btn_Finalise.Visible = false;
                //btn_Cancel.Visible = false;
                RG_SelfAppraisal.Visible = false;

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisalnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    private void LoadEmployees()
    {
        try
        {
            if (Convert.ToInt32(Session["EMP_ID"]) == 0)
            {
                BLL.ShowMessage(this, "You can not access this screen.");
                return;
            }
            _obj_pms_EmployeeSetup = new PMS_EMPSETUP();


            //_obj_smhr_logininfo = new SMHR_LOGININFO();
            //_obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            //_obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"].ToString());
            //DataTable dt_buu = new DataTable();
            //dt_buu = BLL.get_Business_Units(_obj_smhr_logininfo);
            SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
            _obj_smhr_emp_payitems.OPERATION = operation.Self;
            _obj_smhr_emp_payitems.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT_SELF = BLL.get_EmpDetails(_obj_smhr_emp_payitems);

            _obj_pms_EmployeeSetup.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            if (DT_SELF.Rows.Count != 0)
            {
                _obj_pms_EmployeeSetup.BU_ID = Convert.ToInt32(DT_SELF.Rows[0]["EMP_BUSINESSUNIT_ID"]);
            }
            else
            {
                _obj_pms_EmployeeSetup.BU_ID = 0;
            }
            _obj_pms_EmployeeSetup.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtbuid1 = Pms_Bll.get_LoginInfo(_obj_pms_EmployeeSetup);
            if (dtbuid1.Rows.Count != 0)
            {
                rtxt_RpMgr.Text = Convert.ToString(dtbuid1.Rows[0]["REPORTINGMANAGER"]);
                rtxt_GpMgr.Text = Convert.ToString(dtbuid1.Rows[0]["APPROVALMANAGER"]);
                //rcmb_EmployeeType.Items.Clear();
                //rcmb_EmployeeType.DataSource = dtbuid1;
                //rcmb_EmployeeType.DataTextField = "employee";
                //rcmb_EmployeeType.DataValueField = "EMPID";
                //rcmb_EmployeeType.DataBind();



                rtxt_RpMgr.Enabled = false;
                rtxt_GpMgr.Enabled = false;


                _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                _obj_Pms_Appraisalcycle.MODE = 11;
                _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(Session["emp_id"]);//where i am passing employee to get bunit
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtem = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                _obj_Pms_Appraisalcycle.MODE = 8;
                if (dtem.Rows.Count != 0)
                {
                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                }
                else
                {
                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;
                }
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                //where i am getting apprisal cycle 
                if (dtappid.Rows.Count != 0)
                {

                    _obj_GS = new PMS_GoalSettings();
                    _obj_GS.GS_MODE = 9;
                    _obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_GS.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                    _obj_GS.GS_APPRAISAL_CYCLE = Convert.ToString(rtxt_AppraisalCycle.SelectedItem.Value);//Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
                    DataTable dt1 = Pms_Bll.get_GS(_obj_GS);

                    if (dt1.Rows.Count != 0)
                    {
                        rtxt_Role.Text = Convert.ToString(dt1.Rows[0]["ROLE_NAMES"]);
                        //       rtxt_Project.Text = Convert.ToString(dt1.Rows[0]["PROJECT_NAME"]);
                        //rtxt_AppraisalCycle.Text = Convert.ToString(dt1.Rows[0]["APPRCYCLE_NAME"]);
                        lbl_Apprais_id.Text = Convert.ToString(rtxt_AppraisalCycle.SelectedItem.Value); //Convert.ToString(dt1.Rows[0]["APPRCYCLE_ID"]);
                        //rtxt_AppraisalCycle.Enabled = false;
                        rtxt_Role.Enabled = false;
                        //rtxt_Project.Enabled = false;
                        LoadGrid();
                        if (Convert.ToInt32(ViewState["Status"]) == 1)
                        {
                            BLL.ShowMessage(this, "Self Appraisal Already Finalized.");
                        }
                    }
                    else
                    {
                        //rcmb_feedback.SelectedIndex = 0;
                        Pms_Bll.ShowMessage(this, "Goal Setting Has Not Done");
                        //rcmb_feedback.Enabled = false;
                        rtxt_Role.Text = string.Empty;
                        //rtxt_Project.Text = string.Empty;
                        //rtxt_AppraisalCycle.Text = string.Empty;
                        RG_SelfAppraisal.Visible = false;
                        //btn_Cancel.Visible = false;
                        //btn_Submit.Visible = false;
                        //btn_Finalise.Visible = false;
                    }
                }
                else
                {
                    //rcmb_feedback.SelectedIndex = 0;
                    Pms_Bll.ShowMessage(this, "Goal Setting Has Not Done");
                    //rcmb_feedback.Enabled = false;
                    rtxt_Role.Text = string.Empty;
                    //rtxt_Project.Text = string.Empty;
                    //rtxt_AppraisalCycle.Text = string.Empty;
                    RG_SelfAppraisal.Visible = false;
                    //btn_Cancel.Visible = false;
                    //btn_Submit.Visible = false;
                    //btn_Finalise.Visible = false;
                }
            }

            else
            {
                RG_SelfAppraisal.Visible = false;
                //btn_Submit.Visible = false;
                //btn_Finalise.Visible = false;
                Pms_Bll.ShowMessage(this, "Employee Not In Active State");
                //btn_Cancel.Visible = false;
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisalnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadAppraisalCycle()
    {
        try
        {
            _obj_pms_EmployeeSetup = new PMS_EMPSETUP();
            SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
            _obj_smhr_emp_payitems.OPERATION = operation.Self;
            _obj_smhr_emp_payitems.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT_SELF = BLL.get_EmpDetails(_obj_smhr_emp_payitems);

            _obj_pms_EmployeeSetup.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            if (DT_SELF.Rows.Count != 0)
            {
                _obj_pms_EmployeeSetup.BU_ID = Convert.ToInt32(DT_SELF.Rows[0]["EMP_BUSINESSUNIT_ID"]);
            }
            else
            {
                _obj_pms_EmployeeSetup.BU_ID = 0;
            }
            _obj_pms_EmployeeSetup.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtbuid1 = Pms_Bll.get_LoginInfo(_obj_pms_EmployeeSetup);
            if (dtbuid1.Rows.Count != 0)
            {
                rtxt_RpMgr.Text = Convert.ToString(dtbuid1.Rows[0]["REPORTINGMANAGER"]);
                rtxt_GpMgr.Text = Convert.ToString(dtbuid1.Rows[0]["APPROVALMANAGER"]);
                rcmb_EmployeeType.Items.Clear();
                rcmb_EmployeeType.DataSource = dtbuid1;
                rcmb_EmployeeType.DataTextField = "employee";
                rcmb_EmployeeType.DataValueField = "EMPID";
                rcmb_EmployeeType.DataBind();
            }

            rtxt_AppraisalCycle.Items.Clear();
            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();

            _obj_Pms_Appraisalcycle.MODE = 9;
            if (DT_SELF.Rows.Count != 0)
            {
                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(DT_SELF.Rows[0]["EMP_BUSINESSUNIT_ID"]);
            }
            else
            {
                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;
            }
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["org_id"]);
            DataTable DT_AppraisalCycle = new DataTable();
            DT_AppraisalCycle = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
            if (DT_AppraisalCycle.Rows.Count != 0)
            {
                rtxt_AppraisalCycle.DataSource = DT_AppraisalCycle;
                rtxt_AppraisalCycle.DataTextField = "APPRCYCLE_NAME";
                rtxt_AppraisalCycle.DataValueField = "APPRCYCLE_ID";
                rtxt_AppraisalCycle.DataBind();
                rtxt_AppraisalCycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
            else
            {
                DataTable dt6 = new DataTable();

                rtxt_AppraisalCycle.DataSource = dt6;

                rtxt_AppraisalCycle.DataBind();
                rtxt_AppraisalCycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisalnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadGrid()
    {
        try
        {
            PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            _obj_Pms_Appraisalcycle.MODE = 11;
            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtem = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

            _obj_Pms_Appraisalcycle.MODE = 8;
            if (dtem.Rows.Count != 0)
            {

                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem.Rows[0]["EMP_BUSINESSUNIT_ID"]);
            }
            else
            {
                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;

            }
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


            _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
            _obj_Pms_EmpGoalSetting.Mode = 8;


            _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
            if (dtappid.Rows.Count != 0)
            {

                _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(rtxt_AppraisalCycle.SelectedItem.Value);//Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
            }
            else
            {
                _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = "0";
            }
            _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
            _obj_GS = new PMS_GoalSettings();
            DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
            if (dt.Rows.Count != 0)
                _obj_GS.GS_ID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
            else
                _obj_GS.GS_ID = 0;

            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            _obj_Pms_Appraisalcycle.MODE = 2;
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["org_id"]);
            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value);
            DataTable dt_app = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
            if (dt_app.Rows.Count > 0)
            {
                if (Convert.ToBoolean(dt_app.Rows[0]["APPRCYCLE_SELFAPPRAISAL"]) == false)
                {
                    BLL.ShowMessage(this, "Self Appraisal Disabled for this Appraisal Cycle.");
                    //RG_SelfAppraisal.Visible = false;
                    ViewState["Status"] = 0;
                    //return;
                }
            }

            _obj_GS.GS_MODE = 27;
            _obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //_obj_GS.GS_ID = Convert.ToInt32(Session["GSID"]);
            DataTable dt_details = new DataTable();
            dt_details = Pms_Bll.get_GS(_obj_GS);
            if (dt_details.Rows.Count > 0)
            {
                RG_SelfAppraisal.DataSource = dt_details;
                RG_SelfAppraisal.DataBind();
                RG_SelfAppraisal.Visible = true;

                _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                _obj_Pms_Appraisalcycle.MODE = 2;
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value);
                DataTable DT = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                if (DT.Rows.Count > 0)
                {
                    if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) > Convert.ToDateTime(Convert.ToDateTime(DT.Rows[0]["APPCYCLE_ENDDATE"]).ToShortDateString()))
                    {
                        RG_SelfAppraisal.Enabled = true;
                        if (Convert.ToBoolean(dt_app.Rows[0]["APPRCYCLE_SELFAPPRAISAL"]) == false)
                            RG_SelfAppraisal.Enabled = false;
                        else
                            RG_SelfAppraisal.Enabled = true;
                    }
                    else
                        RG_SelfAppraisal.Enabled = false;
                }
                //// RG_SelfAppraisal.Enabled = true;
            }
            else
            {
                RG_SelfAppraisal.Visible = false;
                ViewState["Status"] = 0;
                BLL.ShowMessage(this, "Goal Setting Has Not Done.");
                //btn_Submit.Visible = false;
                //btn_Finalise.Visible = false;
                //btn_Cancel.Visible = false;
                return;
            }
            int count = 0;
            LinkButton lbtn = new LinkButton();
            for (int index = 0; index < RG_SelfAppraisal.Items.Count; index++)
            {
                lbtn = RG_SelfAppraisal.Items[index].FindControl("lnk_Edit") as LinkButton;
                if (dt_details.Rows[index]["FINAL"] != System.DBNull.Value)
                {
                    if (Convert.ToString(dt_details.Rows[index]["FINAL"]) != string.Empty)
                    {
                        if (Convert.ToString(dt_details.Rows[index]["FINAL"]) == "0")
                        {
                            //RG_SelfAppraisal.Items[index].Enabled = true;
                            lbtn.ForeColor = Color.Red;
                        }
                        else
                        {
                            //RG_SelfAppraisal.Items[index].Enabled = false;
                            lbtn.ForeColor = Color.Green;
                            count++;
                        }
                    }
                    else
                    {
                        //RG_SelfApkpraisal.Items[index].Enabled = true;
                        lbtn.ForeColor = Color.Red;
                    }
                }
                else
                {
                    //RG_SelfAppraiksal.Items[index].Enabled = true;
                    lbtn.ForeColor = Color.Red;
                }
            }
            if (count == RG_SelfAppraisal.Items.Count)
            {
                //BLL.ShowMessage(this, "Self Appraisal Already Finalized.");
                ViewState["Status"] = 1;
                //btn_Submit.Visible = false;
                //btn_Finalise.Visible = false;
                //btn_Cancel.Visible = true;
            }
            else
            {
                ViewState["Status"] = 0;
                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    //btn_Submit.Visible = false;
                    //btn_Finalise.Visible = false;
                    //btn_Cancel.Visible = true;
                }
                else
                {
                    //btn_Submit.Visible = true;
                    //btn_Finalise.Visible = true;
                    //btn_Cancel.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisalnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            lbl_rolekra.Text = string.Empty;
            lbl_type_text.Text = string.Empty;
            lbltype_detail_text.Text = string.Empty;
            lbl_rolekra_detail_text.Text = string.Empty;
            rtng_detail.Value = 0;
            rtxt_Comments_detail.Text = string.Empty;
            Rm_Appraisal_PAGE.SelectedIndex = 1;
            lbl_rolekra.Text = Convert.ToString(e.CommandArgument);
            lbl_type_text.Text = Convert.ToString(e.CommandName);
            LinkButton lnkTemp = sender as LinkButton;
            GridDataItem item = lnkTemp.NamingContainer as GridDataItem;
            ViewState["objid"] = item["Objective_ID"].Text;

            _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
            _obj_Pms_EmpGoalSetting.Mode = 8;
            _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
            _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(rtxt_AppraisalCycle.SelectedItem.Value);//Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
            _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
            _obj_GS = new PMS_GoalSettings();
            DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
            if (dt.Rows.Count != 0)
            {
                _obj_GS.GS_ID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);

            }
            else
                _obj_GS.GS_ID = 0;
            _obj_GS.GS_ROLEKRA_ID = Convert.ToInt32(lbl_rolekra.Text);
            if (lbl_type_text.Text.Trim() == "Goal")
                _obj_GS.GS_MODE = 28;
            else if (lbl_type_text.Text.Trim() == "IDP")
                _obj_GS.GS_MODE = 29;
            else
                _obj_GS.GS_MODE = 30;
            _obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //_obj_GS.GS_ID = Convert.ToInt32(Session["GSID"]);
            _obj_GS.CREATEDBY = Convert.ToInt32(ViewState["objid"]);  //pasing obj id
            DataTable dt_details = new DataTable();
            dt_details = Pms_Bll.get_GS(_obj_GS);
            if (dt_details.Rows.Count > 0)
            {
                if (Convert.ToString(dt_details.Rows[0]["A"]) == "KRA")
                {
                    tr_Kraname.Visible = true;
                    TR_OBJ_NAME.Visible = true;
                    TR1.Visible = false;
                    TR2.Visible = false;
                    LBL_OJID.Text = Convert.ToString(dt_details.Rows[0]["GS_KRA_OBJ_ID"]);
                    lbltype_detail_text.Text = Convert.ToString(dt_details.Rows[0]["KRA_NAME"]);
                    lbl_rolekra_detail_text.Text = Convert.ToString(dt_details.Rows[0]["NAME"]);
                }
                else
                {
                    tr_Kraname.Visible = false;
                    TR_OBJ_NAME.Visible = false;
                    TR1.Visible = true;
                    TR2.Visible = true;
                    lbl_tydet.Text = Convert.ToString(dt_details.Rows[0]["A"]);
                    lblnamedt.Text = Convert.ToString(dt_details.Rows[0]["NAME"]);
                }
                // 
                if (dt_details.Rows[0]["TARGET_ACHIEVED"] != System.DBNull.Value && Convert.ToString(dt_details.Rows[0]["TARGET_ACHIEVED"]) != "")
                {
                    rtng_detail.Value = Convert.ToDouble(dt_details.Rows[0]["TARGET_ACHIEVED"]);
                }
                if (dt_details.Rows[0]["EMP_COMMENTS"] != System.DBNull.Value && Convert.ToString(dt_details.Rows[0]["EMP_COMMENTS"]) != "")
                {
                    rtxt_Comments_detail.Text = Convert.ToString(dt_details.Rows[0]["EMP_COMMENTS"]);
                }
                if (dt_details.Rows[0]["FINAL"] != System.DBNull.Value && Convert.ToString(dt_details.Rows[0]["FINAL"]) != string.Empty)
                {
                    if (Convert.ToString(dt_details.Rows[0]["FINAL"]) == "0")
                    {
                        btn_Submit_Detail.Visible = true;
                        btn_Finalise_Detail.Visible = true;
                        rtng_detail.Enabled = true;
                        rtxt_Comments_detail.Enabled = true;
                    }
                    else
                    {
                        btn_Submit_Detail.Visible = false;
                        btn_Finalise_Detail.Visible = false;
                        rtng_detail.Enabled = false;
                        rtxt_Comments_detail.Enabled = false;
                    }
                }
                else
                {
                    btn_Submit_Detail.Visible = true;
                    btn_Finalise_Detail.Visible = true;
                    rtng_detail.Enabled = true;
                    rtxt_Comments_detail.Enabled = true;
                }
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisalnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_Detail_Click(object sender, EventArgs e)
    {
        try
        {
            lbl_rolekra.Text = string.Empty;
            lbl_type_text.Text = string.Empty;
            Rm_Appraisal_PAGE.SelectedIndex = 0;
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisalnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Submit_Detail_Click(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToDecimal(rtng_detail.Value) == 0)
            {
                BLL.ShowMessage(this, "Please Select Rating");
                return;
            }
            bool status = false;

            PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            _obj_Pms_Appraisalcycle.MODE = 11;
            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtem = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

            _obj_Pms_Appraisalcycle.MODE = 8;
            if (dtem.Rows.Count != 0)
            {

                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem.Rows[0]["EMP_BUSINESSUNIT_ID"]);
            }
            else
            {
                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;

            }
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


            _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
            _obj_Pms_EmpGoalSetting.Mode = 8;


            _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
            if (dtappid.Rows.Count != 0)
            {

                _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(rtxt_AppraisalCycle.SelectedItem.Value); //Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
            }
            else
            {
                _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = "0";
            }
            _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
            _obj_GS = new PMS_GoalSettings();
            if (dt.Rows.Count != 0)
                _obj_GS.GS_ID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
            else
                _obj_GS.GS_ID = 0;
            //TO CHECK WHETHER APPRAISAL EXISTS FOR THE EMPLOYEE OR NOT
            _obj_Spms_Appraisal = new SPMS_APPRAISAL();
            _obj_Spms_Appraisal.Mode = 27;
            _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
            _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value); //Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
            _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_appr_chk = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
            if (dt_appr_chk.Rows.Count == 0)
            {
                //TO INSERT THE DATE IN PMS_APPRAISAL
                _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                _obj_Spms_Appraisal.APPRAISAL_DATE = rdtp_DATEofAppraisal.SelectedDate.Value;
                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE = 1;
                _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value);// Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
                _obj_Spms_Appraisal.APPRAISAL_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_Spms_Appraisal.APPRAISAL_STATUS = 1;
                _obj_Spms_Appraisal.APPRAISAL_CREATEDDATE = DateTime.Now;

                _obj_Spms_Appraisal.Mode = 4;
                status = Pms_Bll.set_Appraisal(_obj_Spms_Appraisal);
            }
            else
            {
                status = true;
            }
            if (status)
            {

                if (lbl_type_text.Text.Trim() == "Goal")
                {
                    //UPDATING THE GOALS RATING IN GOALSETTING DETAILS
                    PMS_GoalSettings_Details _obj_GSdetails = new PMS_GoalSettings_Details();
                    _obj_GSdetails.GS_DETAILS_MODE = 7;
                    _obj_GSdetails.GSDTL_TARGET_ACHEIVED = Convert.ToString(Convert.ToDecimal(rtng_detail.Value));
                    _obj_GSdetails.GSDTL_GS_ID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
                    _obj_GSdetails.GSDTL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_GSdetails.GSDTL_ID = Convert.ToInt32(lbl_rolekra.Text);
                    _obj_GSdetails.LASTMDFDATE = DateTime.Now;
                    _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    bool status8 = Pms_Bll.set_GSdetails(_obj_GSdetails);

                    _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value); //Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
                    _obj_Spms_Appraisal.Mode = 5;
                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    //TO GET THE APPRAISAL ID
                    DataTable dtgoal1 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                    _obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();
                    if (dtgoal1.Rows.Count != 0)
                    {
                        _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtgoal1.Rows[0]["APPRAISAL_ID"]);
                    }
                    else
                    {
                        _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = 0;
                    }
                    //TO CHECK WHETHER DATA EXISTS FOR KRA IN APPRAISAL OR NOT
                    _obj_Spms_Appraisal.Mode = 30;
                    _obj_Spms_Appraisal.APP_ROLEKRA_ID = Convert.ToInt32(lbl_rolekra.Text);
                    DataTable dt_app_goal_chk = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                    if (dt_app_goal_chk.Rows.Count == 0)
                    {
                        //INSERTING THE APPRAISAL GOAL DATA
                        _obj_Spms_AppraisalGoal.Mode = 3;
                        _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(lbl_rolekra.Text);
                        _obj_Spms_AppraisalGoal.APP_GOALS_EMP_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_Comments_detail.Text));
                        _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Spms_AppraisalGoal.APP_GOALS_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_Spms_AppraisalGoal.APP_GOALS_CREATEDDATE = DateTime.Now;
                        _obj_Spms_AppraisalGoal.APP_GOALS_FINAL = 0;
                        bool status1 = Pms_Bll.set_AppraisalGoal(_obj_Spms_AppraisalGoal);
                    }
                    else
                    {
                        //UPDATING THE APPRAISAL GOAL DATA
                        _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtgoal1.Rows[0]["APPRAISAL_ID"]);
                        _obj_Spms_AppraisalGoal.Mode = 18;
                        _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(lbl_rolekra.Text);
                        _obj_Spms_AppraisalGoal.APP_GOALS_EMP_COMMENTS = Convert.ToString(rtxt_Comments_detail.Text.Replace("'", "''"));
                        _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFDATE = DateTime.Now;
                        bool status1 = Pms_Bll.set_AppraisalGoal(_obj_Spms_AppraisalGoal);
                    }
                    //_obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();
                    _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtgoal1.Rows[0]["APPRAISAL_ID"]);
                    _obj_Spms_AppraisalGoal.APP_EMP_GOAL_FIXED = Convert.ToString(1);
                    _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(lbl_rolekra.Text);
                    _obj_Spms_AppraisalGoal.Mode = 17;
                    _obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFDATE = DateTime.Now;
                    bool status10 = Pms_Bll.set_AppraisalGoal(_obj_Spms_AppraisalGoal);
                }
                else if (lbl_type_text.Text.Trim() == "IDP")
                {
                    //UPDATING THE IDP RATING IN GOALS OF IDP
                    GOALSETTING_IDP_DETAILS _obj_Pms_goalidpdetails = new GOALSETTING_IDP_DETAILS();
                    _obj_Pms_goalidpdetails.MODE = 8;
                    _obj_Pms_goalidpdetails.GS_IDP_TARGET_ACHEIVED = Convert.ToString(Convert.ToDecimal(rtng_detail.Value));
                    _obj_Pms_goalidpdetails.GS_IDP_GS_ID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
                    _obj_Pms_goalidpdetails.GS_IDP_IDP_ID = Convert.ToInt32(lbl_rolekra.Text);
                    _obj_Pms_goalidpdetails.GS_IDP_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Pms_goalidpdetails.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_Pms_goalidpdetails.LASTMDFDATE = DateTime.Now;
                    bool status8 = Pms_Bll.set_GsIDP(_obj_Pms_goalidpdetails);

                    _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                    _obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE = 1;
                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value); //Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
                    _obj_Spms_Appraisal.Mode = 5;
                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    //TO GET THE APPRAISAL ID
                    DataTable dtgoal4 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                    _obj_Spms_AppraisalIdp = new SPMS_APPRAISALIDP();
                    if (dtgoal4.Rows.Count != 0)
                    {
                        _obj_Spms_AppraisalIdp.APP_IDP_APP_ID = Convert.ToInt32(dtgoal4.Rows[0]["APPRAISAL_ID"]);
                    }
                    //TO CHECK WHETHER DATA EXISTS FOR IDP IN APPRAISAL OR NOT
                    _obj_Spms_Appraisal.Mode = 43;
                    _obj_Spms_Appraisal.APP_ROLEKRA_ID = Convert.ToInt32(lbl_rolekra.Text);
                    DataTable dt_app_idp_chk = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                    if (dt_app_idp_chk.Rows.Count == 0)
                    {
                        //INSERTING THE APPRAISAL IDP DATA
                        _obj_Spms_AppraisalIdp.Mode = 3;
                        _obj_Spms_AppraisalIdp.APP_IDP_IDP_ID = Convert.ToInt32(lbl_rolekra.Text);
                        _obj_Spms_AppraisalIdp.APP_IDP_EMP_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_Comments_detail.Text));
                        _obj_Spms_AppraisalIdp.APP_IDP_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Spms_AppraisalIdp.APP_IDP_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_Spms_AppraisalIdp.APP_IDP_CREATEDDATE = DateTime.Now;
                        _obj_Spms_AppraisalIdp.APP_IDP_FINAL = 0;
                        bool status1 = Pms_Bll.set_AppraisalIdp(_obj_Spms_AppraisalIdp);

                    }
                    else
                    {
                        //UPDATING THE APPRAISAL IDP DATA
                        //_obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                        _obj_Spms_AppraisalIdp.APP_IDP_APP_ID = Convert.ToInt32(dtgoal4.Rows[0]["APPRAISAL_ID"]);
                        _obj_Spms_AppraisalIdp.Mode = 19;
                        _obj_Spms_AppraisalIdp.APP_IDP_IDP_ID = Convert.ToInt32(lbl_rolekra.Text);
                        _obj_Spms_AppraisalIdp.APP_IDP_EMP_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_Comments_detail.Text));
                        _obj_Spms_AppraisalIdp.APP_IDP_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Spms_AppraisalIdp.APP_IDP_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_Spms_AppraisalIdp.APP_IDP_LASTMDFDATE = DateTime.Now;
                        bool status1 = Pms_Bll.set_AppraisalIdp(_obj_Spms_AppraisalIdp);

                    }
                    //UPDATING THE APPRAISAL IDP DATA WITH STATUS OF EMP_FIXED
                    //_obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                    _obj_Spms_AppraisalIdp.APP_IDP_APP_ID = Convert.ToInt32(dtgoal4.Rows[0]["APPRAISAL_ID"]);
                    _obj_Spms_AppraisalIdp.APP_IDP_IDP_ID = Convert.ToInt32(lbl_rolekra.Text);
                    _obj_Spms_AppraisalIdp.APP_IDP_EMP_FIXED = Convert.ToString(1);
                    _obj_Spms_AppraisalIdp.Mode = 18;
                    _obj_Spms_AppraisalIdp.APP_IDP_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Spms_AppraisalIdp.APP_IDP_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_Spms_AppraisalIdp.APP_IDP_LASTMDFDATE = DateTime.Now;
                    bool status10 = Pms_Bll.set_AppraisalIdp(_obj_Spms_AppraisalIdp);
                }
                else//FOR KRA
                {
                    //UPDATING THE KRA RATING IN GOALS OF KRA
                    GOALSETTING_GOALKRA_DETAILS _obj_Pms_goalkradetails = new GOALSETTING_GOALKRA_DETAILS();
                    _obj_Pms_goalkradetails.MODE = 8;
                    _obj_Pms_goalkradetails.GS_KRA_TARGET_ACHEIVED = Convert.ToString(Convert.ToDecimal(rtng_detail.Value));
                    _obj_Pms_goalkradetails.GS_KRA_GS_ID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
                    _obj_Pms_goalkradetails.GS_KRA_KRA_ID = Convert.ToInt32(lbl_rolekra.Text);
                    _obj_Pms_goalkradetails.GS_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Pms_goalkradetails.GS_KRA_OBJ_ID = Convert.ToInt32(LBL_OJID.Text);
                    _obj_Pms_goalkradetails.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_Pms_goalkradetails.LASTMDFDATE = DateTime.Now;
                    bool status8 = Pms_Bll.set_Gskra(_obj_Pms_goalkradetails);

                    _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                    _obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE = 1;
                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value); //Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
                    _obj_Spms_Appraisal.Mode = 5;
                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    //TO GET THE APPRAISAL ID
                    DataTable dtgoal4 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                    _obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                    if (dtgoal4.Rows.Count != 0)
                    {
                        _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtgoal4.Rows[0]["APPRAISAL_ID"]);
                    }
                    //TO CHECK WHETHER DATA EXISTS FOR KRA IN APPRAISAL OR NOT
                    _obj_Spms_Appraisal.Mode = 31;
                    _obj_Spms_Appraisal.APP_ROLEKRA_ID = Convert.ToInt32(lbl_rolekra.Text);
                    _obj_Spms_Appraisal.APPRAISAL_CREATEDBY = Convert.ToInt32(LBL_OJID.Text);
                    DataTable dt_app_kra_chk = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                    if (dt_app_kra_chk.Rows.Count == 0)
                    {
                        //INSERTING THE APPRAISAL KRA DATA
                        _obj_Spms_AppraisalKra.Mode = 3;
                        _obj_Spms_AppraisalKra.APP_KRA_KRA_ID = Convert.ToInt32(lbl_rolekra.Text);
                        _obj_Spms_AppraisalKra.APP_KRA_OBJ_ID = Convert.ToInt32(LBL_OJID.Text);
                        _obj_Spms_AppraisalKra.APP_KRA_EMP_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_Comments_detail.Text));
                        _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Spms_AppraisalKra.APP_KRA_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_Spms_AppraisalKra.APP_KRA_CREATEDDATE = DateTime.Now;
                        _obj_Spms_AppraisalKra.APP_KRA_FINAL = 0;
                        bool status1 = Pms_Bll.set_AppraisalKra(_obj_Spms_AppraisalKra);

                    }
                    else
                    {
                        //UPDATING THE APPRAISAL KRA DATA
                        //_obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                        _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtgoal4.Rows[0]["APPRAISAL_ID"]);
                        _obj_Spms_AppraisalKra.Mode = 19;
                        _obj_Spms_AppraisalKra.APP_KRA_OBJ_ID = Convert.ToInt32(LBL_OJID.Text);
                        _obj_Spms_AppraisalKra.APP_KRA_KRA_ID = Convert.ToInt32(lbl_rolekra.Text);
                        _obj_Spms_AppraisalKra.APP_KRA_EMP_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_Comments_detail.Text));
                        _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Spms_AppraisalKra.APP_KRA_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_Spms_AppraisalKra.APP_KRA_LASTMDFDATE = DateTime.Now;
                        bool status1 = Pms_Bll.set_AppraisalKra(_obj_Spms_AppraisalKra);

                    }
                    //UPDATING THE APPRAISAL KRA DATA WITH STATUS OF EMP_FIXED
                    //_obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                    _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtgoal4.Rows[0]["APPRAISAL_ID"]);
                    _obj_Spms_AppraisalKra.APP_KRA_KRA_ID = Convert.ToInt32(lbl_rolekra.Text);
                    _obj_Spms_AppraisalKra.APP_KRA_OBJ_ID = Convert.ToInt32(LBL_OJID.Text);
                    _obj_Spms_AppraisalKra.APP_KRA_EMP_FIXED = Convert.ToString(1);
                    _obj_Spms_AppraisalKra.Mode = 18;
                    _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Spms_AppraisalKra.APP_KRA_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_Spms_AppraisalKra.APP_KRA_LASTMDFDATE = DateTime.Now;
                    bool status10 = Pms_Bll.set_AppraisalKra(_obj_Spms_AppraisalKra);
                }

                //}
                //}
                //LoadGrid();
                BLL.ShowMessage(this, "Employee Comments Submitted Successfully.");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisalnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rtxt_AppraisalCycle_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rtxt_AppraisalCycle.SelectedIndex > 0)
            {
                PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();

                _obj_Pms_Appraisalcycle.MODE = 16;
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rtxt_AppraisalCycle.SelectedValue);

                DataTable dtAprslCycle = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                if (Convert.ToBoolean(dtAprslCycle.Rows[0]["APPRCYCLE_SELFAPPRAISAL"]) == false)
                {
                    RG_SelfAppraisal.Visible = false;
                    rtxt_AppraisalCycle.SelectedIndex = 0;
                    rtxt_Role.Text = string.Empty;
                    BLL.ShowMessage(this, "Self Appraisal is not in enabled mode..!");
                }
                else
                    LoadEmployees();
                //LoadGrid();
                //if (Convert.ToInt32(ViewState["Status"]) == 1)
                //{
                //    BLL.ShowMessage(this, "Self Appraisal Already Finalized.");
                //}
            }
            else
            {
                RG_SelfAppraisal.Visible = false;
                //btn_Cancel.Visible = false;
                //btn_Submit.Visible = false;
                //btn_Finalise.Visible = false;
                //rtxt_Project.Text = string.Empty;
                rtxt_Role.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisalnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Finalise_Detail_Click(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToDecimal(rtng_detail.Value) == 0)
            {
                BLL.ShowMessage(this, "Please Select Rating");
                return;
            }
            bool status = false;
            PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            _obj_Pms_Appraisalcycle.MODE = 11;
            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtem = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

            _obj_Pms_Appraisalcycle.MODE = 8;
            if (dtem.Rows.Count != 0)
            {

                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem.Rows[0]["EMP_BUSINESSUNIT_ID"]);
            }
            else
            {
                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;

            }
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


            _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
            _obj_Pms_EmpGoalSetting.Mode = 8;


            _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
            if (dtappid.Rows.Count != 0)
            {

                _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(rtxt_AppraisalCycle.SelectedItem.Value); //Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
            }
            else
            {
                _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = "0";
            }
            _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
            _obj_GS = new PMS_GoalSettings();
            if (dt.Rows.Count != 0)
                _obj_GS.GS_ID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
            else
                _obj_GS.GS_ID = 0;
            //TO CHECK WHETHER APPRAISAL EXISTS FOR THE EMPLOYEE OR NOT
            _obj_Spms_Appraisal = new SPMS_APPRAISAL();
            _obj_Spms_Appraisal.Mode = 27;
            _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
            _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value); //Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
            _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_appr_chk = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
            if (dt_appr_chk.Rows.Count == 0)
            {
                //TO INSERT THE DATE IN PMS_APPRAISAL
                _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                _obj_Spms_Appraisal.APPRAISAL_DATE = rdtp_DATEofAppraisal.SelectedDate.Value;
                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE = 11;
                _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value);// Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
                _obj_Spms_Appraisal.APPRAISAL_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_Spms_Appraisal.APPRAISAL_STATUS = 1;
                _obj_Spms_Appraisal.APPRAISAL_CREATEDDATE = DateTime.Now;

                _obj_Spms_Appraisal.Mode = 4;
                status = Pms_Bll.set_Appraisal(_obj_Spms_Appraisal);
            }
            else
            {
                status = true;
            }
            if (status)
            {
                //for (int index = 0; index < RG_SelfAppraisal.Items.Count; index++)
                //{
                //CheckBox chk = RG_SelfAppraisal.Items[index].FindControl("chckbtn_Select") as CheckBox;
                //if (chk.Checked)
                //{
                //    Label lbl_type = RG_SelfAppraisal.Items[index].FindControl("lbl_type") as Label;
                //    RadRating rtng = RG_SelfAppraisal.Items[index].FindControl("rdrtg_rating") as RadRating;
                //    RadTextBox rtxt_comments = RG_SelfAppraisal.Items[index].FindControl("rtxt_comments") as RadTextBox;
                //    Label lbl_rolekra_id = RG_SelfAppraisal.Items[index].FindControl("lbl_ROLEKRA_ID") as Label;
                //    if (rtxt_comments.Text == string.Empty)
                //    {
                //        BLL.ShowMessage(this, "Please Enter Comments in Row : " + (++index) + "");
                //        return;
                //    }
                //    if (rtng.Value == 0)
                //    {
                //        BLL.ShowMessage(this, "Please Give Rating in Row : " + (++index) + "");
                //        return;
                //    }
                if (lbl_type_text.Text.Trim() == "Goal")
                {
                    //UPDATING THE GOALS RATING IN GOALSETTING DETAILS
                    PMS_GoalSettings_Details _obj_GSdetails = new PMS_GoalSettings_Details();
                    _obj_GSdetails.GS_DETAILS_MODE = 7;
                    _obj_GSdetails.GSDTL_TARGET_ACHEIVED = Convert.ToString(Convert.ToDecimal(rtng_detail.Value));
                    _obj_GSdetails.GSDTL_GS_ID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
                    _obj_GSdetails.GSDTL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_GSdetails.GSDTL_ID = Convert.ToInt32(lbl_rolekra.Text);
                    _obj_GSdetails.LASTMDFDATE = DateTime.Now;
                    _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    bool status8 = Pms_Bll.set_GSdetails(_obj_GSdetails);

                    _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value); //Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
                    _obj_Spms_Appraisal.Mode = 5;
                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    //TO GET THE APPRAISAL ID
                    DataTable dtgoal1 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                    _obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();
                    if (dtgoal1.Rows.Count != 0)
                    {
                        _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtgoal1.Rows[0]["APPRAISAL_ID"]);
                    }
                    else
                    {
                        _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = 0;
                    }
                    //TO CHECK WHETHER DATA EXISTS FOR KRA IN APPRAISAL OR NOT
                    _obj_Spms_Appraisal.Mode = 30;
                    _obj_Spms_Appraisal.APP_ROLEKRA_ID = Convert.ToInt32(lbl_rolekra.Text);
                    DataTable dt_app_goal_chk = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                    if (dt_app_goal_chk.Rows.Count == 0)
                    {
                        //INSERTING THE APPRAISAL GOAL DATA
                        _obj_Spms_AppraisalGoal.Mode = 3;
                        _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(lbl_rolekra.Text);
                        _obj_Spms_AppraisalGoal.APP_GOALS_EMP_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_Comments_detail.Text));
                        _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Spms_AppraisalGoal.APP_GOALS_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_Spms_AppraisalGoal.APP_GOALS_CREATEDDATE = DateTime.Now;
                        _obj_Spms_AppraisalGoal.APP_GOALS_FINAL = 1;
                        bool status1 = Pms_Bll.set_AppraisalGoal(_obj_Spms_AppraisalGoal);
                    }
                    else
                    {
                        //UPDATING THE APPRAISAL GOAL DATA
                        _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtgoal1.Rows[0]["APPRAISAL_ID"]);
                        _obj_Spms_AppraisalGoal.Mode = 18;
                        _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(lbl_rolekra.Text);
                        _obj_Spms_AppraisalGoal.APP_GOALS_EMP_COMMENTS = Convert.ToString(rtxt_Comments_detail.Text.Replace("'", "''"));
                        _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFDATE = DateTime.Now;
                        _obj_Spms_AppraisalGoal.APP_GOALS_FINAL = 1;
                        bool status1 = Pms_Bll.set_AppraisalGoal(_obj_Spms_AppraisalGoal);
                    }
                    //_obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();
                    _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtgoal1.Rows[0]["APPRAISAL_ID"]);
                    _obj_Spms_AppraisalGoal.APP_EMP_GOAL_FIXED = Convert.ToString(2);
                    _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(lbl_rolekra.Text);
                    _obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFDATE = DateTime.Now;
                    _obj_Spms_AppraisalGoal.Mode = 17;
                    bool status10 = Pms_Bll.set_AppraisalGoal(_obj_Spms_AppraisalGoal);
                }
                else if (lbl_type_text.Text.Trim() == "IDP")
                {
                    //UPDATING THE IDP RATING IN GOALS OF IDP
                    GOALSETTING_IDP_DETAILS _obj_Pms_goalidpdetails = new GOALSETTING_IDP_DETAILS();
                    _obj_Pms_goalidpdetails.MODE = 8;
                    _obj_Pms_goalidpdetails.GS_IDP_TARGET_ACHEIVED = Convert.ToString(Convert.ToDecimal(rtng_detail.Value));
                    _obj_Pms_goalidpdetails.GS_IDP_GS_ID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
                    _obj_Pms_goalidpdetails.GS_IDP_IDP_ID = Convert.ToInt32(lbl_rolekra.Text);
                    _obj_Pms_goalidpdetails.GS_IDP_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Pms_goalidpdetails.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_Pms_goalidpdetails.LASTMDFDATE = DateTime.Now;
                    bool status8 = Pms_Bll.set_GsIDP(_obj_Pms_goalidpdetails);

                    _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                    _obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE = 11;
                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value); //Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
                    _obj_Spms_Appraisal.Mode = 5;
                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    //TO GET THE APPRAISAL ID
                    DataTable dtgoal4 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                    _obj_Spms_AppraisalIdp = new SPMS_APPRAISALIDP();
                    if (dtgoal4.Rows.Count != 0)
                    {
                        _obj_Spms_AppraisalIdp.APP_IDP_APP_ID = Convert.ToInt32(dtgoal4.Rows[0]["APPRAISAL_ID"]);
                    }
                    //TO CHECK WHETHER DATA EXISTS FOR IDP IN APPRAISAL OR NOT
                    _obj_Spms_Appraisal.Mode = 43;
                    _obj_Spms_Appraisal.APP_ROLEKRA_ID = Convert.ToInt32(lbl_rolekra.Text);
                    DataTable dt_app_idp_chk = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                    if (dt_app_idp_chk.Rows.Count == 0)
                    {
                        //INSERTING THE APPRAISAL IDP DATA
                        _obj_Spms_AppraisalIdp.Mode = 3;
                        _obj_Spms_AppraisalIdp.APP_IDP_IDP_ID = Convert.ToInt32(lbl_rolekra.Text);
                        _obj_Spms_AppraisalIdp.APP_IDP_EMP_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_Comments_detail.Text));
                        _obj_Spms_AppraisalIdp.APP_IDP_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Spms_AppraisalIdp.APP_IDP_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_Spms_AppraisalIdp.APP_IDP_CREATEDDATE = DateTime.Now;
                        _obj_Spms_AppraisalIdp.APP_IDP_FINAL = 1;
                        bool status1 = Pms_Bll.set_AppraisalIdp(_obj_Spms_AppraisalIdp);

                    }
                    else
                    {
                        //UPDATING THE APPRAISAL IDP DATA
                        //_obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                        _obj_Spms_AppraisalIdp.APP_IDP_APP_ID = Convert.ToInt32(dtgoal4.Rows[0]["APPRAISAL_ID"]);
                        _obj_Spms_AppraisalIdp.Mode = 19;
                        _obj_Spms_AppraisalIdp.APP_IDP_IDP_ID = Convert.ToInt32(lbl_rolekra.Text);
                        _obj_Spms_AppraisalIdp.APP_IDP_EMP_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_Comments_detail.Text));
                        _obj_Spms_AppraisalIdp.APP_IDP_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Spms_AppraisalIdp.APP_IDP_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_Spms_AppraisalIdp.APP_IDP_LASTMDFDATE = DateTime.Now;
                        _obj_Spms_AppraisalIdp.APP_IDP_FINAL = 1;
                        bool status1 = Pms_Bll.set_AppraisalIdp(_obj_Spms_AppraisalIdp);

                    }
                    //UPDATING THE APPRAISAL IDP DATA WITH STATUS OF EMP_FIXED
                    //_obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                    _obj_Spms_AppraisalIdp.APP_IDP_APP_ID = Convert.ToInt32(dtgoal4.Rows[0]["APPRAISAL_ID"]);
                    _obj_Spms_AppraisalIdp.APP_IDP_IDP_ID = Convert.ToInt32(lbl_rolekra.Text);
                    _obj_Spms_AppraisalIdp.APP_IDP_EMP_FIXED = Convert.ToString(2);
                    _obj_Spms_AppraisalIdp.Mode = 18;
                    _obj_Spms_AppraisalIdp.APP_IDP_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Spms_AppraisalIdp.APP_IDP_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_Spms_AppraisalIdp.APP_IDP_LASTMDFDATE = DateTime.Now;
                    bool status10 = Pms_Bll.set_AppraisalIdp(_obj_Spms_AppraisalIdp);
                }
                else//FOR KRA
                {
                    //UPDATING THE KRA RATING IN GOALS OF KRA
                    GOALSETTING_GOALKRA_DETAILS _obj_Pms_goalkradetails = new GOALSETTING_GOALKRA_DETAILS();
                    _obj_Pms_goalkradetails.MODE = 8;
                    _obj_Pms_goalkradetails.GS_KRA_TARGET_ACHEIVED = Convert.ToString(Convert.ToDecimal(rtng_detail.Value));
                    _obj_Pms_goalkradetails.GS_KRA_GS_ID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
                    _obj_Pms_goalkradetails.GS_KRA_KRA_ID = Convert.ToInt32(lbl_rolekra.Text);
                    _obj_Pms_goalkradetails.GS_KRA_OBJ_ID = Convert.ToInt32(LBL_OJID.Text);
                    _obj_Pms_goalkradetails.GS_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Pms_goalkradetails.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_Pms_goalkradetails.LASTMDFDATE = DateTime.Now;
                    bool status8 = Pms_Bll.set_Gskra(_obj_Pms_goalkradetails);

                    _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                    _obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE = 11;
                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value); //Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
                    _obj_Spms_Appraisal.Mode = 5;
                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    //TO GET THE APPRAISAL ID
                    DataTable dtgoal4 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                    _obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                    if (dtgoal4.Rows.Count != 0)
                    {
                        _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtgoal4.Rows[0]["APPRAISAL_ID"]);
                    }
                    //TO CHECK WHETHER DATA EXISTS FOR KRA IN APPRAISAL OR NOT
                    _obj_Spms_Appraisal.Mode = 31;
                    _obj_Spms_Appraisal.APP_ROLEKRA_ID = Convert.ToInt32(lbl_rolekra.Text);
                    _obj_Spms_Appraisal.APPRAISAL_CREATEDBY = Convert.ToInt32(LBL_OJID.Text);
                    DataTable dt_app_kra_chk = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                    if (dt_app_kra_chk.Rows.Count == 0)
                    {
                        //INSERTING THE APPRAISAL KRA DATA
                        _obj_Spms_AppraisalKra.Mode = 3;
                        _obj_Spms_AppraisalKra.APP_KRA_KRA_ID = Convert.ToInt32(lbl_rolekra.Text);
                        _obj_Spms_AppraisalKra.APP_KRA_OBJ_ID = Convert.ToInt32(LBL_OJID.Text);
                        _obj_Spms_AppraisalKra.APP_KRA_EMP_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_Comments_detail.Text));
                        _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Spms_AppraisalKra.APP_KRA_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_Spms_AppraisalKra.APP_KRA_CREATEDDATE = DateTime.Now;
                        _obj_Spms_AppraisalKra.APP_KRA_FINAL = 1;
                        bool status1 = Pms_Bll.set_AppraisalKra(_obj_Spms_AppraisalKra);

                    }
                    else
                    {
                        //UPDATING THE APPRAISAL KRA DATA
                        //_obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                        _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtgoal4.Rows[0]["APPRAISAL_ID"]);
                        _obj_Spms_AppraisalKra.Mode = 19;
                        _obj_Spms_AppraisalKra.APP_KRA_KRA_ID = Convert.ToInt32(lbl_rolekra.Text);
                        _obj_Spms_AppraisalKra.APP_KRA_OBJ_ID = Convert.ToInt32(LBL_OJID.Text);
                        _obj_Spms_AppraisalKra.APP_KRA_EMP_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_Comments_detail.Text));
                        _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Spms_AppraisalKra.APP_KRA_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_Spms_AppraisalKra.APP_KRA_LASTMDFDATE = DateTime.Now;
                        _obj_Spms_AppraisalKra.APP_KRA_FINAL = 1;
                        bool status1 = Pms_Bll.set_AppraisalKra(_obj_Spms_AppraisalKra);

                    }
                    //UPDATING THE APPRAISAL KRA DATA WITH STATUS OF EMP_FIXED
                    //_obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                    _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtgoal4.Rows[0]["APPRAISAL_ID"]);
                    _obj_Spms_AppraisalKra.APP_KRA_KRA_ID = Convert.ToInt32(lbl_rolekra.Text);
                    _obj_Spms_AppraisalKra.APP_KRA_OBJ_ID = Convert.ToInt32(LBL_OJID.Text);
                    _obj_Spms_AppraisalKra.APP_KRA_EMP_FIXED = Convert.ToString(2);
                    _obj_Spms_AppraisalKra.Mode = 18;
                    _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Spms_AppraisalKra.APP_KRA_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_Spms_AppraisalKra.APP_KRA_LASTMDFDATE = DateTime.Now;
                    bool status10 = Pms_Bll.set_AppraisalKra(_obj_Spms_AppraisalKra);
                }

                //}
                //}

                Rm_Appraisal_PAGE.SelectedIndex = 0;
                LoadGrid();
                BLL.ShowMessage(this, "Employee Comments Finalized Successfully.");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisalnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}