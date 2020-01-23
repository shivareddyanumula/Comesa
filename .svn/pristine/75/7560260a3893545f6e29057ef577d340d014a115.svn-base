using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Data;
using SPMS;
using Telerik.Web.UI;



public partial class PMS_frm_GoalSettings : System.Web.UI.Page
{
    PMS_GoalSettings _obj_GS;
    PMS_GoalSettings_Details _obj_GSdetails;
    PMS_GOALKRA _obj_Pms_GOALKRA;
    PMS_EMPSETUP _obj_Pms_EmpSetup;
    pms_kraform _obj_PMS_KRA;
    SPMS_ROLEKRA _obj_Pms_Roles;
    GOALSETTING_GOALKRA_DETAILS _obj_Pms_goalkradetails;
    DataTable dt_KRA = new DataTable();
    DataTable dt_goal = new DataTable();
    PMS_GETEMPLOYEE _obj_PMS_getemployee;
    PMS_LOGININFO _obj_Pms_LoginInfo;

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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Goal Setting");//HRCREATION");
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
                    //RG_Addhr.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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

                //loadBusinessUnit();
                LoadEmployees();
                LoadRolename();
                LoadProject();
                LoadAppraisalCycle();
                createcontrols();
                RadMultiPage rmp1 = (RadMultiPage)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("RMP_GoalSettings");
                Label txt_rm = (Label)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("txt_ReportingManager");
                Label txt_gm = (Label)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("txt_GeneralManager");
                Button btn_Cancel_GoalSettingsDetails = (Button)RadPanelBar1.FindItemByValue("Goal Details").FindControl("btn_Cancel_GoalSettingsDetails");
                Button btn_KRASubmit = (Button)RadPanelBar1.FindItemByValue("Load KRA").FindControl("btn_KRASubmit");
                RadGrid Rg_KRA = (RadGrid)RadPanelBar1.FindItemByValue("Load KRA").FindControl("RG_kraform");
                txt_rm.Text = string.Empty;
                txt_gm.Text = string.Empty;
                btn_Cancel_GoalSettingsDetails.Visible = false;
                btn_KRASubmit.Visible = false;
                Rg_KRA.Visible = false;
                int selectedIndex = RadPanelBar1.SelectedItem.Index;
                RadPanelBar1.Items[selectedIndex - 1].Selected = false;
                RadPanelBar1.Items[selectedIndex - 1].Expanded = false;
                RadPanelBar1.Items[selectedIndex - 1].Enabled = true;
                RadPanelBar1.Items[selectedIndex].Expanded = false;
                RadPanelBar1.Items[selectedIndex + 1].Enabled = false;
                RadPanelBar1.Items[selectedIndex].Enabled = false;
                RadPanelBar1.Items[selectedIndex - 1].Enabled = true;
            }
            Page.Validate();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GoalSettings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void loadBusinessUnit()
    {
        try
        {
            RadComboBox rcmb_BU = (RadComboBox)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("RCB_BusinessUnit");
            rcmb_BU.Items.Clear();


            SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
            _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"].ToString());
            rcmb_BU.Items.Clear();
            rcmb_BU.DataSource = BLL.get_Business_Units(_obj_smhr_logininfo);
            rcmb_BU.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BU.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BU.DataBind();
            rcmb_BU.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GoalSettings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void BindEmployees(DataTable dt)
    {
        try
        {
            RadComboBox rcmb_EN = (RadComboBox)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("RCB_EmployeeName");
            rcmb_EN.Items.Clear();
            rcmb_EN.DataSource = dt;
            rcmb_EN.DataTextField = "Empname";
            rcmb_EN.DataValueField = "EMP_ID";
            rcmb_EN.DataBind();
            rcmb_EN.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GoalSettings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadEmployees()
    {
        try
        {
            RadComboBox rcmb_EN = (RadComboBox)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("RCB_EmployeeName");
            RadComboBox rcmb_BU = (RadComboBox)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("RCB_BusinessUnit");
            Label txt_rm = (Label)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("txt_ReportingManager");
            Label txt_gm = (Label)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("txt_GeneralManager");
            RadComboBox rcmb_Project = (RadComboBox)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("RCMB_Project");
            RadComboBox rcmb_RoleName = (RadComboBox)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("RCB_RoleName");
            Label lbl_BU = (Label)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("lbl_BusinessUnit");
            Label lbl_RMid = (Label)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("lbl_RMID");
            if ((Convert.ToString(Session["EMP_TYPE"])) == "5")
            {
                _obj_PMS_getemployee = new PMS_GETEMPLOYEE();
                _obj_PMS_getemployee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                _obj_PMS_getemployee.Mode = 1;
                DataTable dtbuid = Pms_Bll.get_RMEmployees(_obj_PMS_getemployee);
                txt_rm.Text = Convert.ToString(dtbuid.Rows[0]["REPORTINGMANAGER"]);
                txt_gm.Text = Convert.ToString(dtbuid.Rows[0]["approvalmgr"]);
                rcmb_EN.Items.Clear();
                rcmb_EN.DataSource = dtbuid;
                rcmb_EN.DataTextField = "employee";
                rcmb_EN.DataValueField = "EMPID";
                rcmb_EN.DataBind();
                rcmb_EN.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                rcmb_BU.Visible = false;
                lbl_BU.Visible = false;
                txt_rm.Enabled = false;
                txt_gm.Enabled = false;


                PMS_GoalSettings _obj_GS = new PMS_GoalSettings();
                _obj_GS.GS_MODE = 9;
                _obj_GS.GS_EMP_ID = Convert.ToInt32(rcmb_EN.SelectedItem.Value);
                DataTable dt1 = Pms_Bll.get_GS(_obj_GS);

                if (dt1.Rows.Count != 0)
                {
                    rcmb_RoleName.Text = Convert.ToString(dt1.Rows[0]["ROLE_NAMES"]);
                    rcmb_Project.Text = Convert.ToString(dt1.Rows[0]["PROJECT_NAME"]);
                    rcmb_Project.Enabled = true;
                    rcmb_RoleName.Enabled = true;

                }

            }
            else
            {
                SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
                _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                _obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"].ToString());
                rcmb_BU.Items.Clear();
                DataTable dt_bu = BLL.get_Business_Units(_obj_smhr_logininfo);

                _obj_PMS_getemployee = new PMS_GETEMPLOYEE();
                _obj_PMS_getemployee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                _obj_PMS_getemployee.BU_ID = Convert.ToInt32(dt_bu.Rows[0]["BUSINESSUNIT_ID"]);
                _obj_PMS_getemployee.Mode = 1;
                DataTable dtbuid1 = new DataTable();
                dtbuid1 = Pms_Bll.get_RMEmployees(_obj_PMS_getemployee);
                lbl_RMid.Text = Convert.ToString(dtbuid1.Rows[0]["REPORTINGMGR_ID"]);
                txt_rm.Text = Convert.ToString(dtbuid1.Rows[0]["REPORTINGMANAGER"]);
                txt_gm.Text = Convert.ToString(dtbuid1.Rows[0]["APPROVALMGR"]);
                rcmb_EN.Items.Clear();
                rcmb_EN.DataSource = dtbuid1;
                rcmb_EN.DataTextField = "employee";
                rcmb_EN.DataValueField = "EMPID";
                rcmb_EN.DataBind();
                rcmb_EN.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

                rcmb_BU.Visible = false;
                lbl_BU.Visible = false;
                txt_rm.Enabled = true;
                txt_gm.Enabled = true;

                PMS_GoalSettings _obj_GS = new PMS_GoalSettings();
                _obj_GS.GS_MODE = 9;
                _obj_GS.GS_EMP_ID = Convert.ToInt32(rcmb_EN.SelectedItem.Value);
                DataTable dt1 = Pms_Bll.get_GS(_obj_GS);

                if (dt1.Rows.Count != 0)
                {
                    rcmb_RoleName.Text = Convert.ToString(dt1.Rows[0]["ROLE_NAMES"]);
                    rcmb_Project.Text = Convert.ToString(dt1.Rows[0]["PROJECT_NAME"]);
                    rcmb_Project.Enabled = true;
                    rcmb_RoleName.Enabled = true;

                }

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GoalSettings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void RCB_BusinessUnit_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            LoadEmployees();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GoalSettings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void LoadProject()
    {
        try
        {
            RadComboBox rcmb_EN = (RadComboBox)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("RCB_EmployeeName");
            PMS_EMPSETUP _obj_Pms_EmpSetup = new PMS_EMPSETUP();
            _obj_Pms_EmpSetup.Mode = 16;
            _obj_Pms_EmpSetup.REPORTINGMGR_ID = Convert.ToInt32(Session["EMP_ID"]);
            DataTable dt = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);




            RadComboBox rcmb_Project = (RadComboBox)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("RCMB_Project");
            rcmb_Project.Items.Clear();
            SPMS_PROJECT _obj_Pms_Project = new SPMS_PROJECT();
            _obj_Pms_Project.BUID = Convert.ToInt32(dt.Rows[0]["BU_ID"]);
            _obj_Pms_Project.Mode = 6;
            DataTable DT_Project = new DataTable();
            DT_Project = Pms_Bll.get_Project(_obj_Pms_Project);
            rcmb_Project.DataSource = DT_Project;
            rcmb_Project.DataTextField = "PROJECT_NAME";
            rcmb_Project.DataValueField = "PROJECT_ID";
            rcmb_Project.DataBind();
            rcmb_Project.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            int selectedIndex = RadPanelBar1.SelectedItem.Index;
            RadPanelBar1.Items[selectedIndex + 1].Selected = true;
            RadPanelBar1.Items[selectedIndex + 1].Expanded = true;
            RadPanelBar1.Items[selectedIndex + 1].Enabled = true;
            RadPanelBar1.Items[selectedIndex].Expanded = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GoalSettings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void LoadRolename()
    {
        try
        {
            RadComboBox rcmb_EN = (RadComboBox)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("RCB_EmployeeName");
            PMS_EMPSETUP _obj_Pms_EmpSetup = new PMS_EMPSETUP();
            _obj_Pms_EmpSetup.Mode = 16;
            _obj_Pms_EmpSetup.REPORTINGMGR_ID = Convert.ToInt32(Session["EMP_ID"]);
            DataTable dt = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);

            RadComboBox rcmb_RoleName = (RadComboBox)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("RCB_RoleName");
            rcmb_RoleName.Items.Clear();
            PMS_BINDROLES _obj_roles = new PMS_BINDROLES();

            _obj_roles.MODE = 8;
            _obj_roles.BUID = Convert.ToInt32(dt.Rows[0]["BU_ID"]);
            DataTable DT_Roles = new DataTable();
            DT_Roles = Pms_Bll.get_roles(_obj_roles);
            rcmb_RoleName.DataSource = DT_Roles;
            rcmb_RoleName.DataTextField = "ROLE_NAME";
            rcmb_RoleName.DataValueField = "ROLE_ID";
            rcmb_RoleName.DataBind();
            rcmb_RoleName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GoalSettings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void LoadAppraisalCycle()
    {
        try
        {
            RadComboBox rcmb_EN = (RadComboBox)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("RCB_EmployeeName");
            PMS_EMPSETUP _obj_Pms_EmpSetup = new PMS_EMPSETUP();
            _obj_Pms_EmpSetup.Mode = 16;
            _obj_Pms_EmpSetup.REPORTINGMGR_ID = Convert.ToInt32(Session["EMP_ID"]);
            DataTable dt = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);


            RadComboBox rcmb_ApprasialCycle = (RadComboBox)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("RCB_ApprasialCycle");
            rcmb_ApprasialCycle.Items.Clear();
            PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();

            _obj_Pms_Appraisalcycle.MODE = 9;
            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dt.Rows[0]["BU_ID"]);

            DataTable DT_AppraisalCycle = new DataTable();
            DT_AppraisalCycle = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
            rcmb_ApprasialCycle.DataSource = DT_AppraisalCycle;
            rcmb_ApprasialCycle.DataTextField = "APPRCYCLE_NAME";
            rcmb_ApprasialCycle.DataValueField = "APPRCYCLE_ID";
            rcmb_ApprasialCycle.DataBind();
            rcmb_ApprasialCycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GoalSettings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void Goal_ID()
    {
        try
        {
            RadComboBox rcmb_ApprasialCycle = (RadComboBox)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("RCB_ApprasialCycle");
            RadComboBox rcmb_EN = (RadComboBox)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("RCB_EmployeeName");
            Label label_id = (Label)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("lbl_id");
            _obj_GS = new PMS_GoalSettings();
            _obj_GS.GS_MODE = 6;
            _obj_GS.GS_EMP_ID = Convert.ToInt32(rcmb_EN.SelectedValue);
            _obj_GS.GS_APPRAISAL_CYCLE = Convert.ToString(rcmb_ApprasialCycle.SelectedValue);
            DataTable dt_App = Pms_Bll.get_GS(_obj_GS);
            if (dt_App.Rows.Count != 0)
            {
                label_id.Text = Convert.ToString(dt_App.Rows[0]["GS_ID"]);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GoalSettings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void loadgrid_GoalSettings_Details(int ID)
    {
        try
        {
            RadGrid Rg_GsDetails = (RadGrid)RadPanelBar1.FindItemByValue("Goal Details").FindControl("RG_GoalSettings_DetailsGrid");
            _obj_GSdetails = new PMS_GoalSettings_Details();
            _obj_GSdetails.GS_DETAILS_MODE = 5;
            _obj_GSdetails.GSDTL_GS_ID = Convert.ToInt32(ID);
            DataTable dt = Pms_Bll.get_GSdetails(_obj_GSdetails);
            Rg_GsDetails.DataSource = dt;
            Rg_GsDetails.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GoalSettings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }



    protected void Clearfields_GoalSettings_Details()
    {
        try
        {
            TextBox txt_GN = (TextBox)RadPanelBar1.FindItemByValue("Goal Details").FindControl("txt_GoalName");
            TextBox txt_GD = (TextBox)RadPanelBar1.FindItemByValue("Goal Details").FindControl("txt_GoalDescription");
            RadNumericTextBox rnt_weigthage = (RadNumericTextBox)RadPanelBar1.FindItemByValue("Goal Details").FindControl("RNT_Weightage");
            TextBox rnt_Measure = (TextBox)RadPanelBar1.FindItemByValue("Goal Details").FindControl("txt_Measure");
            RadNumericTextBox rnt_target = (RadNumericTextBox)RadPanelBar1.FindItemByValue("Goal Details").FindControl("RNT_GoalTarget");
            RadDatePicker rdp_timelines = (RadDatePicker)RadPanelBar1.FindItemByValue("Goal Details").FindControl("rdtp_Goal_TIMELINES");

            txt_GN.Text = string.Empty;
            txt_GD.Text = string.Empty;
            rnt_weigthage.Text = string.Empty;
            rnt_Measure.Text = string.Empty;
            rnt_target.Text = string.Empty;
            rdp_timelines.SelectedDate = null;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GoalSettings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void EnabledTrues_Goalsettings_Details()
    {
        try
        {
            TextBox txt_GN = (TextBox)RadPanelBar1.FindItemByValue("Goal Details").FindControl("txt_GoalName");
            TextBox txt_GD = (TextBox)RadPanelBar1.FindItemByValue("Goal Details").FindControl("txt_GoalDescription");
            RadNumericTextBox rnt_weigthage = (RadNumericTextBox)RadPanelBar1.FindItemByValue("Goal Details").FindControl("RNT_Weightage");
            TextBox rnt_Measure = (TextBox)RadPanelBar1.FindItemByValue("Goal Details").FindControl("txt_Measure");
            RadDatePicker rdp_Date = (RadDatePicker)RadPanelBar1.FindItemByValue("Goal Details").FindControl("RDP_Date");
            Button btn_Submit = (Button)RadPanelBar1.FindItemByValue("Goal Details").FindControl("btn_Submit");
            txt_GN.Enabled = true;
            btn_Submit.Enabled = true;
            txt_GD.Enabled = true;
            rnt_Measure.Enabled = true;
            rnt_weigthage.Enabled = true;
            rdp_Date.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GoalSettings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void createcontrols()
    {
        try
        {
            DataTable dt_KRA = new DataTable();
            DataTable dt_goal = new DataTable();

            dt_KRA.Rows.Clear();
            dt_KRA.Columns.Clear();
            dt_goal.Rows.Clear();
            dt_goal.Columns.Clear();
            dt_KRA.Columns.Add("GS_KRAID");
            dt_KRA.Columns.Add("KRAID");
            dt_KRA.Columns.Add("KRANAME");
            dt_KRA.Columns.Add("KRAdesc");
            dt_KRA.Columns.Add("KRAMEASURE");
            dt_KRA.Columns.Add("KRAWEIGHTAGE");

            dt_KRA.Columns.Add("KRATarget");
            dt_KRA.Columns.Add("KRATimelines");

            dt_KRA.Columns.Add("Sr_No");
            ViewState["dtKRA"] = dt_KRA;

            dt_goal.Columns.Add("GSDTL_ID");
            dt_goal.Columns.Add("GSDTL_NAME");
            dt_goal.Columns.Add("GSDTL_DESC");
            dt_goal.Columns.Add("GSDTL_MEASURE");
            dt_goal.Columns.Add("GSDTL_WEIGHTAGE");

            dt_goal.Columns.Add("GS_Goal_TARGET");
            dt_goal.Columns.Add("GS_Goal_TIMELINES");

            dt_goal.Columns.Add("Sr_No");
            ViewState["dtgoal"] = dt_goal;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GoalSettings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }



    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            Label label_id = (Label)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("lbl_id");
            RadComboBox rcmb_BU = (RadComboBox)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("RCB_BusinessUnit");
            RadComboBox rcmb_EN = (RadComboBox)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("RCB_EmployeeName");
            RadComboBox rcmb_RoleName = (RadComboBox)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("RCB_RoleName");
            RadComboBox rcmb_ApprasialCycle = (RadComboBox)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("RCB_ApprasialCycle");
            RadComboBox rcmb_Project = (RadComboBox)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("RCMB_Project");
            TextBox txt_JD = (TextBox)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("txt_JobDescription");
            RadMultiPage rmp1 = (RadMultiPage)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("RMP_GoalSettings");
            RadMultiPage rmp2 = (RadMultiPage)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("RMP_loadkra");
            RadMultiPage rmp3 = (RadMultiPage)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("RMP_GoalSettings_Details");
            Button btn_Saved = (Button)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("btn_Save");
            RadGrid Rg_KRA = (RadGrid)RadPanelBar1.FindItemByValue("Load KRA").FindControl("RG_kraform");
            Button btn_KRASubmit = (Button)RadPanelBar1.FindItemByValue("Load KRA").FindControl("btn_KRASubmit");
            SPMS_EMPGOALSETTING _obj_Pms_EmpGoalSetting;
            _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
            _obj_Pms_EmpGoalSetting.Mode = 15;
            _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EN.SelectedItem.Value);
            DataTable DT12 = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
            if (DT12.Rows.Count != 0)
            {
                Pms_Bll.ShowMessage(this, "Already Goal Setting Done");

            }
            else
            {
                if (label_id.Text == "")
                {
                    _obj_GS = new PMS_GoalSettings();
                    _obj_GS.GS_MODE = 4;

                    _obj_GS.GS_EMP_ID = Convert.ToInt32(rcmb_EN.SelectedValue);
                    _obj_GS.GS_APPRAISAL_CYCLE = (rcmb_ApprasialCycle.SelectedValue);
                    _obj_GS.GS_ROLENAME = Convert.ToInt32(rcmb_RoleName.SelectedValue);
                    _obj_GS.GS_JOB_DESCRIPTION = Pms_Bll.ReplaceQuote(Convert.ToString(txt_JD.Text));
                    _obj_GS.GS_PROJECT = Convert.ToString(rcmb_Project.SelectedValue);
                    _obj_GS.LASTMDFBY = 1; // ### Need to Get the Session
                    _obj_GS.LASTMDFDATE = DateTime.Now;
                    _obj_GS.CREATEDBY = 2; // ### Need to Get the Session
                    _obj_GS.CREATEDDATE = DateTime.Now;
                    bool status = Pms_Bll.set_GS(_obj_GS);
                    if (status == true)
                    {
                        Pms_Bll.ShowMessage(this, "Record Inserted Succesfully");
                        int selectedIndex = RadPanelBar1.SelectedItem.Index;
                        RadPanelBar1.Items[selectedIndex + 1].Selected = true;
                        RadPanelBar1.Items[selectedIndex + 1].Expanded = true;
                        RadPanelBar1.Items[selectedIndex + 1].Enabled = true;
                        RadPanelBar1.Items[selectedIndex].Expanded = false;

                        RadPanelBar1.Items[selectedIndex].Enabled = true;
                        RadPanelBar1.Items[selectedIndex + 1].Enabled = true;


                        btn_Saved.Enabled = false;

                        RadComboBox RC_Assignkra = (RadComboBox)RadPanelBar1.FindItemByValue("Load KRA").FindControl("RCB_KRA");
                        _obj_Pms_Roles = new SPMS_ROLEKRA();
                        _obj_Pms_Roles.Mode = 6;
                        _obj_Pms_Roles.ROLE_ID = Convert.ToInt32(rcmb_RoleName.SelectedItem.Value);
                        DataTable dt = new DataTable();
                        dt = Pms_Bll.get_RoleKra(_obj_Pms_Roles);
                        RC_Assignkra.DataSource = dt;
                        RC_Assignkra.DataTextField = "KRA_NAME";
                        RC_Assignkra.DataValueField = "ROLEKRA_ID";
                        RC_Assignkra.DataBind();
                        RC_Assignkra.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                        Rg_KRA.Visible = false;
                        btn_KRASubmit.Visible = false;
                        return;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GoalSettings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void clearfields()
    {
        try
        {
            RadComboBox RC_Assignkra = (RadComboBox)RadPanelBar1.FindItemByValue("Load KRA").FindControl("RCB_KRA");
            TextBox Kra_Descri = (TextBox)RadPanelBar1.FindItemByValue("Load KRA").FindControl("txt_KraDescription");
            RadNumericTextBox rnt_KraWeigthage = (RadNumericTextBox)RadPanelBar1.FindItemByValue("Load KRA").FindControl("RNT_KraWeightage");
            TextBox rnt_KraMeasure = (TextBox)RadPanelBar1.FindItemByValue("Load KRA").FindControl("txt_KraMeasure");

            Kra_Descri.Text = string.Empty;
            rnt_KraMeasure.Text = null;
            rnt_KraWeigthage.Text = null;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GoalSettings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void savekra()
    {
        try
        {
            RadComboBox RC_Assignkra = (RadComboBox)RadPanelBar1.FindItemByValue("Load KRA").FindControl("RCB_KRA");
            TextBox Kra_Descri = (TextBox)RadPanelBar1.FindItemByValue("Load KRA").FindControl("txt_KraDescription");
            RadNumericTextBox rnt_KraWeigthage = (RadNumericTextBox)RadPanelBar1.FindItemByValue("Load KRA").FindControl("RNT_KraWeightage");
            RadNumericTextBox rnt_KraMeasure = (RadNumericTextBox)RadPanelBar1.FindItemByValue("Load KRA").FindControl("RNT_KraMeasure");

            RadGrid Rg_KRA = (RadGrid)RadPanelBar1.FindItemByValue("Load KRA").FindControl("RG_kraform");
            Label lbl_GSDetails = (Label)RadPanelBar1.FindItemByValue("Goal Details").FindControl("lbl_GSDetails");
            Label lbl_KRANAME = new Label();
            Button btn_Cancel_GoalSettingsDetails = (Button)RadPanelBar1.FindItemByValue("Goal Details").FindControl("btn_Cancel_GoalSettingsDetails");
            RadGrid Rg_GoalSettingdetails = (RadGrid)RadPanelBar1.FindItemByValue("Goal Details").FindControl("RG_GoalSettings_DetailsGrid");
            Button btn_GoalDetailSubmit = (Button)RadPanelBar1.FindItemByValue("Goal Details").FindControl("btn_GoalDetailSubmit");

            RadNumericTextBox rnt_KraTARGET = (RadNumericTextBox)RadPanelBar1.FindItemByValue("Load KRA").FindControl("RNT_KraTarget");
            RadDatePicker Rdp_KraTIMELINES = (RadDatePicker)RadPanelBar1.FindItemByValue("Load KRA").FindControl("rdtp_TIMELINES");


            _obj_GS = new PMS_GoalSettings();
            _obj_GS.GS_MODE = 12;
            DataTable Dt_detail = Pms_Bll.get_GS(_obj_GS);
            int GSID = Convert.ToInt32(Dt_detail.Rows[0]["Temp"]);
            DataTable dt_KRA = new DataTable();
            _obj_Pms_goalkradetails = new GOALSETTING_GOALKRA_DETAILS();
            _obj_Pms_goalkradetails.MODE = 4;
            _obj_Pms_goalkradetails.GS_KRA_GS_ID = GSID;//@GS_KRA_GSDTL_ID = '123', 
            for (int i = 0; i < Rg_KRA.Items.Count; i++)
            {
                lbl_KRANAME = (Label)Rg_KRA.Items[i].FindControl("lbl_KRANAME") as Label;
                _obj_Pms_goalkradetails.GS_KRA_GSDTL_ID = GSID;
                _obj_Pms_goalkradetails.GS_KRA_KRA_ID = Convert.ToInt32(Rg_KRA.Items[i]["KRAID"].Text);
                _obj_Pms_goalkradetails.GS_KRA_NAME = Convert.ToString(lbl_KRANAME.Text);

                _obj_Pms_goalkradetails.GS_KRA_DESCRIPTION = Convert.ToString(Rg_KRA.Items[i]["KRAdesc"].Text);
                _obj_Pms_goalkradetails.GS_KRA_MEASURE = Convert.ToString(Rg_KRA.Items[i]["KRAMEASURE"].Text);
                //_obj_Pms_goalkradetails.GS_KRA_WEIGHTAGE = 0;

                _obj_Pms_goalkradetails.GS_KRA_WEIGHTAGE = Convert.ToInt32(Rg_KRA.Items[i]["KRAWEIGHTAGE"].Text);
                _obj_Pms_goalkradetails.GS_KRA_DATE = DateTime.Now;
                _obj_Pms_goalkradetails.GS_KRA_TARGET = Convert.ToString(Rg_KRA.Items[i]["KRATarget"].Text);

                _obj_Pms_goalkradetails.GS_KRA_TIMELINES = Convert.ToDateTime(Rg_KRA.Items[i]["KRATimelines"].Text);
                _obj_Pms_goalkradetails.CREATEDDATE = DateTime.Now;
                _obj_Pms_goalkradetails.CREATEDBY = 1;
                bool status = Pms_Bll.set_Gskra(_obj_Pms_goalkradetails);

            }
            Pms_Bll.ShowMessage(this, "Information Inserted Succesfully");
            int selectedIndex = RadPanelBar1.SelectedItem.Index;
            RadPanelBar1.Items[selectedIndex + 1].Selected = true;
            RadPanelBar1.Items[selectedIndex + 1].Expanded = true;
            RadPanelBar1.Items[selectedIndex + 1].Enabled = true;
            RadPanelBar1.Items[selectedIndex].Expanded = false;



            RadPanelBar1.Items[selectedIndex].Enabled = true;

            btn_Cancel_GoalSettingsDetails.Visible = false;
            Rg_GoalSettingdetails.Visible = false;
            btn_GoalDetailSubmit.Visible = false;
            SPMS_PROJECT _obj_Pms_Project;
            RadNumericTextBox rnt_weigthage = (RadNumericTextBox)RadPanelBar1.FindItemByValue("Goal Details").FindControl("RNT_Weightage");
            _obj_Pms_Project = new SPMS_PROJECT();
            _obj_Pms_Project.Mode = 7;
            DataTable dt = Pms_Bll.get_Project(_obj_Pms_Project);
            if (Convert.ToString(dt.Rows[0]["max_weightage"]) == "0")
            {
                rnt_weigthage.MaxValue = 7;
            }
            else
            {
                rnt_weigthage.MaxValue = Convert.ToInt32(dt.Rows[0]["max_weightage"]);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GoalSettings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    protected void EnabledFalse_Goalsettings_Details()
    {
        try
        {
            TextBox txt_GN = (TextBox)RadPanelBar1.FindItemByValue("Goal Details").FindControl("txt_GoalName");
            TextBox txt_GD = (TextBox)RadPanelBar1.FindItemByValue("Goal Details").FindControl("txt_GoalDescription");
            RadNumericTextBox rnt_weigthage = (RadNumericTextBox)RadPanelBar1.FindItemByValue("Goal Details").FindControl("RNT_Weightage");
            TextBox rnt_Measure = (TextBox)RadPanelBar1.FindItemByValue("Goal Details").FindControl("txt_Measure");

            Button btn_Submit = (Button)RadPanelBar1.FindItemByValue("Goal Details").FindControl("btn_Submit");
            RadGrid Rg_GoalSettingdetails = (RadGrid)RadPanelBar1.FindItemByValue("Load KRA").FindControl("RG_GoalSettings_DetailsGrid");
            txt_GN.Enabled = false;
            btn_Submit.Enabled = false;
            txt_GD.Enabled = true;
            rnt_Measure.Enabled = false;
            rnt_weigthage.Enabled = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GoalSettings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            Label label_gsdetails = (Label)RadPanelBar1.FindItemByValue("Goal Details").FindControl("lbl_GSDetails");
            RadMultiPage rmp3 = (RadMultiPage)RadPanelBar1.FindItemByValue("Goal Details").FindControl("RMP_GoalSettings_Details");
            TextBox txt_GN = (TextBox)RadPanelBar1.FindItemByValue("Goal Details").FindControl("txt_GoalName");
            TextBox txt_GD = (TextBox)RadPanelBar1.FindItemByValue("Goal Details").FindControl("txt_GoalDescription");
            RadNumericTextBox rnt_weigthage = (RadNumericTextBox)RadPanelBar1.FindItemByValue("Goal Details").FindControl("RNT_Weightage");
            TextBox rnt_Measure = (TextBox)RadPanelBar1.FindItemByValue("Goal Details").FindControl("txt_Measure");

            Button btn_Submit = (Button)RadPanelBar1.FindItemByValue("Goal Details").FindControl("btn_Submit");
            Label label_id = (Label)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("lbl_id");
            RadGrid Rg_GsDetails = (RadGrid)RadPanelBar1.FindItemByValue("Goal Details").FindControl("RG_GoalSettings_DetailsGrid");
            RadGrid Rg_GoalSettingdetails = (RadGrid)RadPanelBar1.FindItemByValue("Goal Details").FindControl("RG_GoalSettings_DetailsGrid");
            Button btn_GoalDetailSubmit = (Button)RadPanelBar1.FindItemByValue("Goal Details").FindControl("btn_GoalDetailSubmit");
            RadNumericTextBox rnt_goal_target = (RadNumericTextBox)RadPanelBar1.FindItemByValue("Goal Details").FindControl("RNT_GoalTarget");
            RadDatePicker rdp_goal_timelines = (RadDatePicker)RadPanelBar1.FindItemByValue("Goal Details").FindControl("rdtp_Goal_TIMELINES");
            //RadTextBox rnt_goal_targetachieved = (RadTextBox)RadPanelBar1.FindItemByValue("Goal Details").FindControl("rtxt_goal_TARGET_ACHEIVED");
            try
            {
                dt_goal = (DataTable)ViewState["dtgoal"];
                DataRow dr1 = dt_goal.NewRow();
                dr1[0] = dt_goal.Rows.Count + 1;
                dr1[1] = txt_GN.Text;
                dr1[2] = txt_GD.Text;
                dr1[3] = rnt_Measure.Text;
                dr1[4] = rnt_weigthage.Text;
                //dr1[5] = rdp_Date.SelectedDate.Value.Date.ToShortDateString();
                dr1[7] = dt_goal.Rows.Count + 1;
                dr1[5] = rnt_goal_target.Text;
                dr1[6] = rdp_goal_timelines.SelectedDate.Value.Date.ToShortDateString();
                //dr1[8] = rnt_goal_targetachieved.Text;
                dt_goal.Rows.Add(dr1);
                ViewState["dtgoal"] = dt_goal;
                Rg_GsDetails.DataSource = dt_goal;
                Rg_GsDetails.DataBind();
                rmp3.SelectedIndex = 1;
                Clearfields_GoalSettings_Details();
                btn_Submit.Visible = true;

            }
            catch (Exception ex)
            {
                Pms_Bll.ShowMessage(this, ex.Message.ToString());
                return;
            }
            Rg_GoalSettingdetails.Visible = true;
            btn_GoalDetailSubmit.Visible = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GoalSettings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_UpdateAssignkra_Click(object sender, EventArgs e)
    {
        try
        {
            RadComboBox RC_Assignkra = (RadComboBox)RadPanelBar1.FindItemByValue("Load KRA").FindControl("RCB_KRA");
            TextBox Kra_Descri = (TextBox)RadPanelBar1.FindItemByValue("Load KRA").FindControl("txt_KraDescription");
            RadNumericTextBox rnt_KraWeigthage = (RadNumericTextBox)RadPanelBar1.FindItemByValue("Load KRA").FindControl("RNT_KraWeightage");
            TextBox rnt_KraMeasure = (TextBox)RadPanelBar1.FindItemByValue("Load KRA").FindControl("txt_KraMeasure");
            //RadDatePicker Rdp_Kradate = (RadDatePicker)RadPanelBar1.FindItemByValue("Load KRA").FindControl("RDP_Date");
            RadGrid Rg_KRA = (RadGrid)RadPanelBar1.FindItemByValue("Load KRA").FindControl("RG_kraform");
            RadMultiPage rmp3 = (RadMultiPage)RadPanelBar1.FindItemByValue("Goal Details").FindControl("RMP_GoalSettings_Details");
            Label lbl_Loadkra = (Label)RadPanelBar1.FindItemByValue("Load KRA").FindControl("lbl_kra");
            Button btn_KRASubmit = (Button)RadPanelBar1.FindItemByValue("Load KRA").FindControl("btn_KRASubmit");
            Button btn_SaveAssignkra = (Button)RadPanelBar1.FindItemByValue("Load KRA").FindControl("btn_SaveAssignkra");
            Button btn_UpdateAssignkra = (Button)RadPanelBar1.FindItemByValue("Load KRA").FindControl("btn_UpdateAssignkra");
            RadNumericTextBox rnt_KraTARGET = (RadNumericTextBox)RadPanelBar1.FindItemByValue("Load KRA").FindControl("RNT_KraTarget");
            RadDatePicker Rdp_KraTIMELINES = (RadDatePicker)RadPanelBar1.FindItemByValue("Load KRA").FindControl("rdtp_TIMELINES");
            //RadTextBox rnt_Kratargetachieved = (RadTextBox)RadPanelBar1.FindItemByValue("Load KRA").FindControl("rtxt_TARGET_ACHEIVED");


            try
            {
                dt_KRA = (DataTable)ViewState["dtKRA"];
                foreach (DataRow item in dt_KRA.Rows)
                {
                    if (item["Sr_No"].ToString() == Convert.ToString(lbl_Loadkra.Text))
                    {
                        item["GS_KRAID"] = Convert.ToString(RC_Assignkra.SelectedItem.Value);
                        item["KRANAME"] = Convert.ToString(RC_Assignkra.SelectedItem.Text);
                        item["KRAdesc"] = Kra_Descri.Text;
                        item["KRAMEASURE"] = rnt_KraMeasure.Text;
                        item["KRAWEIGHTAGE"] = rnt_KraWeigthage.Text;
                        //item["KRAdate"] = Rdp_Kradate.SelectedDate.Value.Date.ToShortDateString();
                        item["KRATarget"] = rnt_KraTARGET.Value;
                        item["KRATimelines"] = Rdp_KraTIMELINES.SelectedDate.Value.Date.ToShortDateString();
                        //item["KRATargetAchieved"] = rnt_Kratargetachieved.Text;
                    }
                }

                ViewState["dtKRA"] = dt_KRA;
                clearfields();
                Rg_KRA.DataSource = dt_KRA;
                Rg_KRA.DataBind();
                Rg_KRA.Visible = true;
                btn_KRASubmit.Visible = true;
                btn_SaveAssignkra.Visible = false;
                btn_UpdateAssignkra.Visible = false;
            }
            catch (Exception ex)
            {
                Pms_Bll.ShowMessage(this, ex.Message.ToString());
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GoalSettings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void btn_UpdateGoalSettingsDetails_Click(object sender, EventArgs e)
    {
        try
        {
            Label label_gsdetails = (Label)RadPanelBar1.FindItemByValue("Goal Details").FindControl("lbl_GSDetails");
            RadMultiPage rmp3 = (RadMultiPage)RadPanelBar1.FindItemByValue("Goal Details").FindControl("RMP_GoalSettings_Details");
            TextBox txt_GN = (TextBox)RadPanelBar1.FindItemByValue("Goal Details").FindControl("txt_GoalName");
            TextBox txt_GD = (TextBox)RadPanelBar1.FindItemByValue("Goal Details").FindControl("txt_GoalDescription");
            RadNumericTextBox rnt_weigthage = (RadNumericTextBox)RadPanelBar1.FindItemByValue("Goal Details").FindControl("RNT_Weightage");
            TextBox rnt_Measure = (TextBox)RadPanelBar1.FindItemByValue("Goal Details").FindControl("txt_Measure");
            //RadDatePicker rdp_Date = (RadDatePicker)RadPanelBar1.FindItemByValue("Goal Details").FindControl("RDP_Date");
            Button btn_Submit = (Button)RadPanelBar1.FindItemByValue("Goal Details").FindControl("btn_Submit");
            Label label_id = (Label)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("lbl_id");
            RadGrid Rg_GsDetails = (RadGrid)RadPanelBar1.FindItemByValue("Goal Details").FindControl("RG_GoalSettings_DetailsGrid");
            Button btn_UpdateGoalSettingsDetails = (Button)RadPanelBar1.FindItemByValue("Goal Details").FindControl("btn_UpdateGoalSettingsDetails");
            Button btn_GoalDetailSubmit = (Button)RadPanelBar1.FindItemByValue("Goal Details").FindControl("btn_GoalDetailSubmit");
            RadNumericTextBox rnt_goal_target = (RadNumericTextBox)RadPanelBar1.FindItemByValue("Goal Details").FindControl("RNT_GoalTarget");
            RadDatePicker rdp_goal_timelines = (RadDatePicker)RadPanelBar1.FindItemByValue("Goal Details").FindControl("rdtp_Goal_TIMELINES");
            //RadTextBox rnt_goal_targetachieved = (RadTextBox)RadPanelBar1.FindItemByValue("Goal Details").FindControl("rtxt_goal_TARGET_ACHEIVED");

            try
            {

                dt_goal = (DataTable)ViewState["dtgoal"];
                foreach (DataRow item in dt_goal.Rows)
                {
                    if (item["Sr_No"].ToString() == Convert.ToString(label_gsdetails.Text))
                    {

                        item["GSDTL_NAME"] = txt_GN.Text;
                        item["GSDTL_DESC"] = txt_GD.Text;
                        item["GSDTL_MEASURE"] = rnt_Measure.Text;
                        item["GSDTL_WEIGHTAGE"] = rnt_weigthage.Text;
                        //item["GSDTL_DATE"] = rdp_Date.SelectedDate.Value.Date.ToShortDateString();//rdp_Date.SelectedDate;
                        item["GS_Goal_TARGET"] = rnt_goal_target.Value;
                        item["GS_Goal_TIMELINES"] = rdp_goal_timelines.SelectedDate.Value.Date.ToShortDateString();
                        //item["GS_Goal_TARGET_ACHEIVED"] = rnt_goal_targetachieved.Text;
                    }
                }




                ViewState["dtgoal"] = dt_goal;

                Rg_GsDetails.DataSource = dt_goal;
                Rg_GsDetails.DataBind();
                rmp3.SelectedIndex = 1;
                Clearfields_GoalSettings_Details();
                btn_UpdateGoalSettingsDetails.Visible = false;
                btn_GoalDetailSubmit.Visible = true;
                txt_GN.Enabled = true;
                rnt_Measure.Enabled = true;
                //rdp_Date.Enabled = true;
                rnt_weigthage.Enabled = true;
            }
            catch (Exception ex)
            {
                Pms_Bll.ShowMessage(this, ex.Message.ToString());
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GoalSettings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }



    protected void lnk_Edit_Commnad(object sender, CommandEventArgs e)
    {
        try
        {
            Label lbl_Loadkra = (Label)RadPanelBar1.FindItemByValue("Load KRA").FindControl("lbl_kra");
            RadComboBox RC_Assignkra = (RadComboBox)RadPanelBar1.FindItemByValue("Load KRA").FindControl("RCB_KRA");
            TextBox Kra_Descri = (TextBox)RadPanelBar1.FindItemByValue("Load KRA").FindControl("txt_KraDescription");
            RadNumericTextBox rnt_KraWeigthage = (RadNumericTextBox)RadPanelBar1.FindItemByValue("Load KRA").FindControl("RNT_KraWeightage");
            TextBox rnt_KraMeasure = (TextBox)RadPanelBar1.FindItemByValue("Load KRA").FindControl("txt_KraMeasure");
            //RadDatePicker Rdp_Kradate = (RadDatePicker)RadPanelBar1.FindItemByValue("Load KRA").FindControl("RDP_Date");
            Button btn_UpdateAssignkra = (Button)RadPanelBar1.FindItemByValue("Load KRA").FindControl("btn_UpdateAssignkra");
            Button btn_KRASubmit = (Button)RadPanelBar1.FindItemByValue("Load KRA").FindControl("btn_KRASubmit");
            Button btn_SaveAssignkra = (Button)RadPanelBar1.FindItemByValue("Load KRA").FindControl("btn_SaveAssignkra");
            lbl_Loadkra.Text = Convert.ToString(e.CommandArgument);
            dt_KRA = (DataTable)ViewState["dtKRA"];

            foreach (DataRow item in dt_KRA.Rows)
            {
                if (item["Sr_No"].ToString() == Convert.ToString(lbl_Loadkra.Text))
                {
                    RC_Assignkra.SelectedIndex = Convert.ToInt32(item["GS_KRAID"]);
                    Kra_Descri.Text = Pms_Bll.ReplaceQuote(Convert.ToString(item["KRAdesc"]));
                    rnt_KraMeasure.Text = Convert.ToString(item["KRAMEASURE"]);
                    rnt_KraWeigthage.Text = Convert.ToString(item["KRAWEIGHTAGE"]);
                    //Rdp_Kradate.SelectedDate = Convert.ToDateTime(item["KRAdate"]);
                    btn_UpdateAssignkra.Visible = true;
                    btn_KRASubmit.Visible = false;
                    btn_SaveAssignkra.Visible = false;
                }
            }


        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GoalSettings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }




    }

    protected void SaveGoaldetails()
    {
        try
        {
            Label label_gsdetails = (Label)RadPanelBar1.FindItemByValue("Goal Details").FindControl("lbl_GSDetails");
            RadMultiPage rmp3 = (RadMultiPage)RadPanelBar1.FindItemByValue("Goal Details").FindControl("RMP_GoalSettings_Details");
            TextBox txt_GN = (TextBox)RadPanelBar1.FindItemByValue("Goal Details").FindControl("txt_GoalName");
            TextBox txt_GD = (TextBox)RadPanelBar1.FindItemByValue("Goal Details").FindControl("txt_GoalDescription");
            RadNumericTextBox rnt_weigthage = (RadNumericTextBox)RadPanelBar1.FindItemByValue("Goal Details").FindControl("RNT_Weightage");
            TextBox rnt_Measure = (TextBox)RadPanelBar1.FindItemByValue("Goal Details").FindControl("txt_Measure");
            //RadDatePicker rdp_Date = (RadDatePicker)RadPanelBar1.FindItemByValue("Goal Details").FindControl("RDP_Date");
            Button btn_Submit = (Button)RadPanelBar1.FindItemByValue("Goal Details").FindControl("btn_Submit");
            Label label_id = (Label)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("lbl_id");
            Button btn_GDSubmit = (Button)RadPanelBar1.FindItemByValue("Goal Details").FindControl("btn_GoalDetailSubmit");
            RadGrid Rg_GsDetails = (RadGrid)RadPanelBar1.FindItemByValue("Goal Details").FindControl("RG_GoalSettings_DetailsGrid");
            Label lbl_RMid = (Label)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("lbl_RMID");
            RadNumericTextBox rnt_goal_target = (RadNumericTextBox)RadPanelBar1.FindItemByValue("Goal Details").FindControl("RNT_GoalTarget");
            RadDatePicker rdp_goal_timelines = (RadDatePicker)RadPanelBar1.FindItemByValue("Goal Details").FindControl("rdtp_Goal_TIMELINES");
            //RadTextBox rnt_goal_targetachieved = (RadTextBox)RadPanelBar1.FindItemByValue("Goal Details").FindControl("rtxt_goal_TARGET_ACHEIVED");
            // This methos is used to get the the GS _ID from DS Table
            _obj_GS = new PMS_GoalSettings();
            _obj_GS.GS_MODE = 12;
            DataTable Dt_detail = Pms_Bll.get_GS(_obj_GS);
            int GSID = Convert.ToInt32(Dt_detail.Rows[0]["Temp"]);
            _obj_GSdetails = new PMS_GoalSettings_Details();
            _obj_GSdetails.GS_DETAILS_MODE = 3;
            _obj_GSdetails.GSDTL_GS_ID = GSID;//need to be changed; should be getting dynamically
            for (int a = 0; a < Rg_GsDetails.Items.Count; a++)
            {
                _obj_GSdetails.GSDTL_NAME = Convert.ToString(Rg_GsDetails.Items[a]["GSDTL_NAME"].Text);
                //_obj_GSdetails.GSDTL_DESCRIPTION = Convert.ToString(Rg_GsDetails.Items[a]["GSDTL_DESC"].Text);
                _obj_GSdetails.GSDTL_DESCRIPTION = "1";
                _obj_GSdetails.GSDTL_MEASURE = Convert.ToString(Rg_GsDetails.Items[a]["GSDTL_MEASURE"].Text);
                _obj_GSdetails.GSDTL_WEIGHTAGE = Convert.ToInt32(Rg_GsDetails.Items[a]["GSDTL_WEIGHTAGE"].Text);
                _obj_GSdetails.GSDTL_DATE = DateTime.Now;
                _obj_GSdetails.LASTMDFBY = 1; // ### Need to Get the Session
                _obj_GSdetails.LASTMDFDATE = DateTime.Now;
                _obj_GSdetails.CREATEDBY = 2; // ### Need to Get the Session
                _obj_GSdetails.CREATEDDATE = DateTime.Now;
                _obj_GSdetails.GSDTL_TARGET = Convert.ToString(Rg_GsDetails.Items[a]["GS_Goal_TARGET"].Text);
                //_obj_GSdetails.GSDTL_TARGET_ACHEIVED = Pms_Bll.ReplaceQuote(Rg_GsDetails.Items[a]["GS_Goal_TARGET_ACHEIVED"].Text);
                _obj_GSdetails.GSDTL_TIMELINES = Convert.ToDateTime(Rg_GsDetails.Items[a]["GS_Goal_TIMELINES"].Text);
                bool status = Pms_Bll.set_GSdetails(_obj_GSdetails);

            }
            Pms_Bll.ShowMessage(this, "Goal Details Submited Successfully");
            PMS_NOTIFICATION _obj_Pms_Send_Notification;
            PMS_LOGININFO _obj_Pms_LoginInfo;
            PMS_EMPSETUP _obj_Pms_EmpSetup = new PMS_EMPSETUP();
            _obj_Pms_LoginInfo = new PMS_LOGININFO();
            RadComboBox rcmb_EN = (RadComboBox)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("RCB_EmployeeName");
            _obj_Pms_LoginInfo.EMPID = Convert.ToInt32(rcmb_EN.SelectedItem.Value);

            DataTable dtbuid1 = Pms_Bll.get_LoginInfo(_obj_Pms_EmpSetup);
            _obj_Pms_Send_Notification = new PMS_NOTIFICATION();
            _obj_Pms_Send_Notification.EMPID = Convert.ToInt32(rcmb_EN.SelectedItem.Value);
            _obj_Pms_Send_Notification.RMID = Convert.ToInt32(lbl_RMid.Text);
            bool status3 = Pms_Bll.Send_Notification2(_obj_Pms_Send_Notification);
            Pms_Bll.ShowMessage(this, "NOTIFICATION SEND");

            int selectedIndex = RadPanelBar1.SelectedItem.Index;
            RadPanelBar1.Items[selectedIndex - 1].Selected = false;
            RadPanelBar1.Items[selectedIndex - 1].Expanded = false;
            RadPanelBar1.Items[selectedIndex - 1].Enabled = false;
            RadPanelBar1.Items[selectedIndex].Expanded = false;

            RadPanelBar1.Items[selectedIndex - 1].Enabled = true;

            RadPanelBar1.Enabled = false;
            RadPanelBar1.SelectedItem.Value = "Registration Fee Setup";
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GoalSettings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_GoalSettingsDetails_Click(object sender, EventArgs e)
    {
        try
        {
            RadMultiPage rmp3 = (RadMultiPage)RadPanelBar1.FindItemByValue("Goal Details").FindControl("RMP_GoalSettings_Details");
            rmp3.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GoalSettings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_CommandGS_Details(object sender, CommandEventArgs e)
    {
        try
        {
            Label label_gsdetails = (Label)RadPanelBar1.FindItemByValue("Goal Details").FindControl("lbl_GSDetails");
            TextBox txt_GN = (TextBox)RadPanelBar1.FindItemByValue("Goal Details").FindControl("txt_GoalName");
            TextBox txt_GD = (TextBox)RadPanelBar1.FindItemByValue("Goal Details").FindControl("txt_GoalDescription");
            RadNumericTextBox rnt_weigthage = (RadNumericTextBox)RadPanelBar1.FindItemByValue("Goal Details").FindControl("RNT_Weightage");
            TextBox rnt_Measure = (TextBox)RadPanelBar1.FindItemByValue("Goal Details").FindControl("txt_Measure");
            //RadDatePicker rdp_Date = (RadDatePicker)RadPanelBar1.FindItemByValue("Goal Details").FindControl("RDP_Date");
            Button btn_Submit = (Button)RadPanelBar1.FindItemByValue("Goal Details").FindControl("btn_Submit");
            Button btn_GoalDetailSubmit = (Button)RadPanelBar1.FindItemByValue("Goal Details").FindControl("btn_GoalDetailSubmit");
            Button btn_UpdateGoalSettingsDetails = (Button)RadPanelBar1.FindItemByValue("Goal Details").FindControl("btn_UpdateGoalSettingsDetails");
            label_gsdetails.Text = Convert.ToString(e.CommandArgument);
            EnabledFalse_Goalsettings_Details();
            Clearfields_GoalSettings_Details();
            dt_goal = (DataTable)ViewState["dtgoal"];
            foreach (DataRow item in dt_goal.Rows)
            {
                if (item["Sr_No"].ToString() == Convert.ToString(label_gsdetails.Text))
                {
                    txt_GN.Text = Convert.ToString(item["GSDTL_NAME"]);
                    txt_GD.Text = Convert.ToString(item["GSDTL_DESC"]);
                    rnt_Measure.Text = Convert.ToString(item["GSDTL_MEASURE"]);
                    rnt_weigthage.Text = Convert.ToString(item["GSDTL_WEIGHTAGE"]);
                    //rdp_Date.SelectedDate = Convert.ToDateTime(item["GSDTL_DATE"]);
                }
            }

            //_obj_GSdetails = new PMS_GoalSettings_Details();
            //_obj_GSdetails.GS_DETAILS_MODE = 2;
            //_obj_GSdetails.GSDTL_ID = Convert.ToInt32(e.CommandArgument);
            //DataTable DT = Pms_Bll.get_GSdetails(_obj_GSdetails);
            //label_gsdetails.Text = Convert.ToString(DT.Rows[0]["GSDTL_ID"]);
            //txt_GN.Text = Convert.ToString(DT.Rows[0]["GSDTL_NAME"]);
            //txt_GD.Text = Convert.ToString(DT.Rows[0]["GSDTL_DESCRIPTION"]);
            //rnt_Measure.Text = Convert.ToString(DT.Rows[0]["GSDTL_MEASURE"]);
            //rnt_weigthage.Text = Convert.ToString(DT.Rows[0]["GSDTL_WEIGHTAGE"]);
            //rdp_Date.SelectedDate = Convert.ToDateTime(DT.Rows[0]["GSDTL_DATE"]);
            EnabledFalse_Goalsettings_Details();
            btn_Submit.Enabled = false;
            btn_GoalDetailSubmit.Visible = false;
            btn_UpdateGoalSettingsDetails.Visible = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GoalSettings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_AssignKra_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnk_loadkra = (LinkButton)RadPanelBar1.FindItemByValue("Load KRA").FindControl("lnk_loadkra");
            lnk_loadkra.Visible = false;

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GoalSettings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


    }

    //protected void lnk_Add_Command(object sender, CommandEventArgs e)
    //{
    //}

    protected void RCB_EmployeeName_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            RadComboBox rcmb_EN = (RadComboBox)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("RCB_EmployeeName");
            RadComboBox rcmb_BU = (RadComboBox)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("RCB_BusinessUnit");
            Label txt_rm = (Label)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("txt_ReportingManager");
            Label txt_gm = (Label)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("txt_GeneralManager");
            RadComboBox rcmb_Project = (RadComboBox)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("RCMB_Project");
            RadComboBox rcmb_RoleName = (RadComboBox)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("RCB_RoleName");
            Label lbl_BU = (Label)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("lbl_BusinessUnit");
            RadComboBox rcmb_ApprasialCycle = (RadComboBox)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("RCB_ApprasialCycle");
            Button btn_Save = (Button)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("btn_Save");

            if ((rcmb_EN.SelectedItem.Text == "Select"))
            {


                Pms_Bll.ShowMessage(this, "Please Select Employee");
                txt_rm.Enabled = true;
                txt_gm.Enabled = true;

                txt_rm.Text = String.Empty;
                txt_gm.Text = string.Empty;
                rcmb_Project.SelectedIndex = 0;
                rcmb_RoleName.SelectedIndex = 0;
                rcmb_ApprasialCycle.SelectedIndex = 0;


            }
            else
            {
                PMS_EMPSETUP _obj_Pms_EmpSetup = new PMS_EMPSETUP();

                _obj_Pms_LoginInfo = new PMS_LOGININFO();

                _obj_Pms_LoginInfo.EMPID = Convert.ToInt32(rcmb_EN.SelectedItem.Value);

                //DataTable dtbuid = Pms_Bll.get_LoginInfo(_obj_Pms_LoginInfo);




                //_obj_Pms_EmpSetup.BU_ID = Convert.ToInt32(dtbuid.Rows[0]["BUID"]);

                //_obj_Pms_EmpSetup.BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
                _obj_Pms_EmpSetup.EMP_ID = Convert.ToInt32(rcmb_EN.SelectedItem.Value);
                _obj_Pms_EmpSetup.Mode = 6;
                DataTable DTREPO = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);
                if (DTREPO.Rows.Count != 0)
                {

                    txt_rm.Text = Convert.ToString(DTREPO.Rows[0]["REPORTINGMGR_NAME"]);
                    txt_rm.Enabled = false;

                }


                _obj_Pms_EmpSetup = new PMS_EMPSETUP();

                //_obj_Pms_EmpSetup.BU_ID = Convert.ToInt32(dtbuid.Rows[0]["BUID"]);
                //_obj_Pms_EmpSetup.BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
                _obj_Pms_EmpSetup.EMP_ID = Convert.ToInt32(rcmb_EN.SelectedItem.Value);
                _obj_Pms_EmpSetup.Mode = 7;
                DataTable DTgeneralmgr = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);
                if (DTgeneralmgr.Rows.Count != 0)
                {
                    txt_gm.Text = Convert.ToString(DTgeneralmgr.Rows[0]["GENERALMGR_NAME"]);
                    txt_gm.Enabled = false;

                }

                SPMS_EMPGOALSETTING _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
                _obj_Pms_EmpGoalSetting.Mode = 15;
                _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EN.SelectedItem.Value);
                DataTable DT12 = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
                if (DT12.Rows.Count != 0)
                {
                    Pms_Bll.ShowMessage(this, "Already Goal Setting Done For This Employee");
                    btn_Save.Enabled = false;
                }
                else
                {
                    btn_Save.Enabled = true;
                }
                rcmb_Project.SelectedIndex = 0;
                rcmb_RoleName.SelectedIndex = 0;
                rcmb_ApprasialCycle.SelectedIndex = 0;
                //_obj_Pms_EmpSetup.BU_ID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
                //_obj_Pms_EmpSetup.EMP_ID = Convert.ToInt32(rcmb_EN.SelectedItem.Value);
                //_obj_Pms_EmpSetup.Mode = 6;
                //DataTable DTREPO = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);
                //if (DTREPO.Rows.Count != 0)
                //{
                //    TextBox txt_RM = (TextBox)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("txt_ReportingManager");

                //    txt_RM.Text = Convert.ToString(DTREPO.Rows[0]["REPORTINGMGR_NAME"]);
                //    txt_RM.Enabled = false;

                //}
                ////else
                ////{
                ////    LoadReportingManager();
                ////    rcmb_BusinessUnitType.Enabled = false;
                ////    btn_Save.Visible = true;
                ////}

                //_obj_Pms_EmpSetup = new PMS_EMPSETUP();
                ////RadComboBox rcmb_BU = (RadComboBox)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("RCB_BusinessUnit");
                ////RadComboBox rcmb_EN = (RadComboBox)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("RCB_EmployeeName");

                ////_obj_Pms_EmpSetup.BU_ID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
                //_obj_Pms_EmpSetup.EMP_ID = Convert.ToInt32(rcmb_EN.SelectedItem.Value);
                //_obj_Pms_EmpSetup.Mode = 7;
                //DataTable DTgeneralmgr = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);
                //if (DTgeneralmgr.Rows.Count != 0)
                //{
                //    TextBox txt_GM = (TextBox)RadPanelBar1.FindItemByValue("Registration Fee Setup").FindControl("txt_GeneralManager");
                //    txt_GM.Text = Convert.ToString(DTgeneralmgr.Rows[0]["GENERALMGR_NAME"]);
                //    txt_GM.Enabled = false;


                //}

                ////////////_obj_Pms_EmpSetup = new PMS_EMPSETUP();
                ////////////_obj_Pms_EmpSetup.BU_ID = Convert.ToInt32(RCB_BusinessUnit.SelectedValue);
                ////////////_obj_Pms_EmpSetup.EMP_ID = Convert.ToInt32(RCB_EmployeeName.SelectedValue);
                ////////////_obj_Pms_EmpSetup.Mode = 4;
                ////////////DataTable dt = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);
                ////////////txt_ReportingManager.Text = Convert.ToString(dt.Rows[0]["REPORTINGMGR_ID"]);
                ////////////txt_GeneralManager.Text = Convert.ToString(dt.Rows[0]["GENERALMGR_ID"]);

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GoalSettings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_loadkra_Click(object sender, EventArgs e)
    {
        try
        {
            //ListBox lb_Kraname = (ListBox)RadPanelBar1.FindItemByValue("Load KRA").FindControl("lb_KRAS");
            //DataTable dt = (DataTable)Session["datatable"];
            //lb_Kraname.DataSource = dt;
            //lb_Kraname.DataTextField = "KRANAME";
            ////lbl_KRAS.
            //lb_Kraname.DataValueField = "KRAID";
            //lb_Kraname.DataBind();

            RadComboBox RC_Assignkra = (RadComboBox)RadPanelBar1.FindItemByValue("Load KRA").FindControl("RCB_KRA");
            string str2 = (string)Session["str"];
            _obj_PMS_KRA = new pms_kraform();
            _obj_PMS_KRA.KRA_DESCRIPTION = str2;
            _obj_PMS_KRA.KRA_MODE = 5;
            DataTable dt = new DataTable();
            dt = Pms_Bll.get_kra(_obj_PMS_KRA);
            RC_Assignkra.DataSource = dt;
            RC_Assignkra.DataTextField = "KRA_NAME";
            RC_Assignkra.DataValueField = "KRA_ID";
            RC_Assignkra.DataBind();
            RC_Assignkra.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GoalSettings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }



    }



    protected void btn_cancelback_Click(object sender, EventArgs e)
    {
        try
        {
            int selectedIndex = RadPanelBar1.SelectedItem.Index;
            RadPanelBar1.Items[selectedIndex + 1].Selected = true;
            RadPanelBar1.Items[selectedIndex + 1].Expanded = true;
            RadPanelBar1.Items[selectedIndex + 1].Enabled = true;
            RadPanelBar1.Items[selectedIndex].Expanded = false;

            RadMultiPage rmp3 = (RadMultiPage)RadPanelBar1.FindItemByValue("Goal Details").FindControl("RMP_GoalSettings_Details");
            int w = 315;
            loadgrid_GoalSettings_Details(w);
            rmp3.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GoalSettings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_SaveAssignkra_Click(object sender, EventArgs e)
    {

        RadComboBox RC_Assignkra = (RadComboBox)RadPanelBar1.FindItemByValue("Load KRA").FindControl("RCB_KRA");
        TextBox Kra_Descri = (TextBox)RadPanelBar1.FindItemByValue("Load KRA").FindControl("txt_KraDescription");
        RadNumericTextBox rnt_KraWeigthage = (RadNumericTextBox)RadPanelBar1.FindItemByValue("Load KRA").FindControl("RNT_KraWeightage");
        TextBox rnt_KraMeasure = (TextBox)RadPanelBar1.FindItemByValue("Load KRA").FindControl("txt_KraMeasure");
        //RadDatePicker Rdp_Kradate = (RadDatePicker)RadPanelBar1.FindItemByValue("Load KRA").FindControl("RDP_Date");
        RadGrid Rg_KRA = (RadGrid)RadPanelBar1.FindItemByValue("Load KRA").FindControl("RG_kraform");
        RadMultiPage rmp3 = (RadMultiPage)RadPanelBar1.FindItemByValue("Goal Details").FindControl("RMP_GoalSettings_Details");
        Button btn_KRASubmit = (Button)RadPanelBar1.FindItemByValue("Load KRA").FindControl("btn_KRASubmit");
        Button btn_SaveAssignkra = (Button)RadPanelBar1.FindItemByValue("Load KRA").FindControl("btn_SaveAssignkra");
        RadNumericTextBox rnt_KraTARGET = (RadNumericTextBox)RadPanelBar1.FindItemByValue("Load KRA").FindControl("RNT_KraTarget");
        RadDatePicker Rdp_KraTIMELINES = (RadDatePicker)RadPanelBar1.FindItemByValue("Load KRA").FindControl("rdtp_TIMELINES");
        //RadTextBox rnt_Kratargetachieved = (RadTextBox)RadPanelBar1.FindItemByValue("Load KRA").FindControl("rtxt_TARGET_ACHEIVED");

        try
        {
            if (Check_Combo(Rg_KRA, "lbl_ID", RC_Assignkra))
            {

                dt_KRA = (DataTable)ViewState["dtKRA"];
                DataRow dr = dt_KRA.NewRow();
                dr[0] = Convert.ToString(RC_Assignkra.SelectedItem.Value);
                dr[1] = Convert.ToString(RC_Assignkra.SelectedItem.Value);

                dr[2] = Convert.ToString(RC_Assignkra.SelectedItem.Text);
                dr[3] = Kra_Descri.Text;
                dr[4] = rnt_KraMeasure.Text;
                dr[5] = rnt_KraWeigthage.Text;



                //dr[6] = Rdp_Kradate.SelectedDate.Value.Date.ToShortDateString();
                dr[6] = rnt_KraTARGET.Value;
                dr[7] = Rdp_KraTIMELINES.SelectedDate.Value.Date.ToShortDateString();
                //dr[8] = rnt_Kratargetachieved.Text;
                dr[8] = dt_KRA.Rows.Count + 1;
                dt_KRA.Rows.Add(dr);
                clearfields();
                Rg_KRA.DataSource = dt_KRA;
                Rg_KRA.DataBind();

                Rg_KRA.Visible = true;
                btn_KRASubmit.Visible = true;
                btn_SaveAssignkra.Visible = false;


            }
            else
            {
                Pms_Bll.ShowMessage(this, "This KRA is already assigned");
            }
        }
        catch (Exception ex)
        {
            Pms_Bll.ShowMessage(this, ex.Message.ToString());
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GoalSettings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

            return;



        }

    }

    public bool Check_Combo(RadGrid rdGrid, string lbl_validate, RadComboBox rcmb_Validate)
    {
        bool status = true;
        try
        {
            RadGrid Rg_KRA = (RadGrid)RadPanelBar1.FindItemByValue("Load KRA").FindControl("RG_kraform");
            RadComboBox RC_Assignkra = (RadComboBox)RadPanelBar1.FindItemByValue("Load KRA").FindControl("RCB_KRA");
            Label lbl_KRANAME = new Label();
            lbl_KRANAME = (Label)Rg_KRA.FindControl("lbl_KRANAME") as Label;


            if (Rg_KRA.Items.Count > 0)
            {
                for (int i = 0; i < Rg_KRA.Items.Count; i++)
                {
                    Label lbl_Control = new Label();
                    lbl_KRANAME = (Label)Rg_KRA.Items[i].FindControl("lbl_KRANAME") as Label;
                    //lbl_Control = (Label)Rg_KRA.Items[i].FindControl("" + lbl_KRANAME + "") as Label;
                    if (Convert.ToString(lbl_KRANAME.Text) == Convert.ToString(RC_Assignkra.SelectedItem.Text))
                    {
                        status = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {

            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GoalSettings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

        return status;
    }

    protected void RCB_KRA_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            RadComboBox RC_Assignkra = (RadComboBox)RadPanelBar1.FindItemByValue("Load KRA").FindControl("RCB_KRA");
            TextBox Kra_Descri = (TextBox)RadPanelBar1.FindItemByValue("Load KRA").FindControl("txt_KraDescription");
            RadNumericTextBox rnt_KraWeigthage = (RadNumericTextBox)RadPanelBar1.FindItemByValue("Load KRA").FindControl("RNT_KraWeightage");
            TextBox rnt_KraMeasure = (TextBox)RadPanelBar1.FindItemByValue("Load KRA").FindControl("txt_KraMeasure");

            RadDatePicker Rdp_Kradate = (RadDatePicker)RadPanelBar1.FindItemByValue("Load KRA").FindControl("RDP_Date");
            RadGrid Rg_KRA = (RadGrid)RadPanelBar1.FindItemByValue("Load KRA").FindControl("RG_kraform");
            Button btn_KRASubmit = (Button)RadPanelBar1.FindItemByValue("Load KRA").FindControl("btn_KRASubmit");
            Button btn_SaveAssignkra = (Button)RadPanelBar1.FindItemByValue("Load KRA").FindControl("btn_SaveAssignkra");
            Button btn_UpdateAssignkra = (Button)RadPanelBar1.FindItemByValue("Load KRA").FindControl("btn_UpdateAssignkra");
            RadNumericTextBox rnt_KraTARGET = (RadNumericTextBox)RadPanelBar1.FindItemByValue("Load KRA").FindControl("RNT_KraTarget");
            RadDatePicker Rdp_KraTIMELINES = (RadDatePicker)RadPanelBar1.FindItemByValue("Load KRA").FindControl("rdtp_TIMELINES");
            RadTextBox rnt_Kratargetachieved = (RadTextBox)RadPanelBar1.FindItemByValue("Load KRA").FindControl("rtxt_TARGET_ACHEIVED");
            if (RC_Assignkra.SelectedIndex != 0)
            {
                _obj_PMS_KRA = new pms_kraform();
                _obj_PMS_KRA.KRA_MODE = 6;
                _obj_PMS_KRA.KRA_NAME = Convert.ToString(RC_Assignkra.SelectedItem.Text);
                DataTable dt1 = new DataTable();
                dt1 = Pms_Bll.get_kra(_obj_PMS_KRA);
                string str = Convert.ToString(dt1.Rows[0]["KRA_DESCRIPTION"]);
                Kra_Descri.Text = str;
                rnt_KraMeasure.Text = Convert.ToString(dt1.Rows[0]["KRA_MEASURE"]);

                SPMS_PROJECT _obj_Pms_Project = new SPMS_PROJECT(); ;


                _obj_Pms_Project.Mode = 7;
                DataTable dt = Pms_Bll.get_Project(_obj_Pms_Project);
                if (Convert.ToString(dt.Rows[0]["max_weightage"]) == "0")
                {
                    rnt_KraWeigthage.MaxValue = 7;
                }
                else
                {
                    rnt_KraWeigthage.MaxValue = Convert.ToInt32(dt.Rows[0]["max_weightage"]);
                }
                //rnt_KraWeigthage.Value = 22;
                rnt_KraMeasure.Enabled = false;
                Kra_Descri.Enabled = false;
                //rnt_KraWeigthage.Enabled = false;
                //Rg_KRA.Visible = false;
                btn_KRASubmit.Visible = false;
                btn_SaveAssignkra.Visible = true;
                btn_UpdateAssignkra.Visible = false;
                rnt_KraTARGET.Value = null;
                Rdp_KraTIMELINES.SelectedDate = null;
                rnt_Kratargetachieved.Text = string.Empty;



            }
        }
        catch (Exception ex)
        {
            Pms_Bll.ShowMessage(this, ex.Message.ToString());
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GoalSettings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

            return;
        }

    }

    protected void btn_KRASubmit_Click(object sender, EventArgs e)
    {
        try
        {
            savekra();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GoalSettings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

            return;
        }

    }

    protected void btn_GoalDtlSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            SaveGoaldetails();
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GoalSettings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

            return;
        }
    }

    protected void RadPanelBar1_ItemClick(object sender, RadPanelBarEventArgs e)
    {

    }
}
