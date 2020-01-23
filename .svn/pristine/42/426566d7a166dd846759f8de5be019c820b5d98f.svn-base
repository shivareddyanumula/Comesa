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


public partial class PMS_frm_PmsMgrAppraisalnew : System.Web.UI.Page
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
    GOALSETTING_IDP_DETAILS _obj_Pms_goalIDPdetails;
    string str;
    int Temp = 0;

    string strkra;
    int tempkra = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Validate();

        //LoadEmployees();

        //Rm_Appraisal_PAGE.SelectedIndex = 0;

        try
        {
            if (!Page.IsPostBack)
            {


                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Manager Appraisal");//Self Appraisal");
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
                    RG_MgrAppraisal.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
                Rm_Appraisal_PAGE.SelectedIndex = 0;
                LoadBusinessUnit();
                rtxt_RpMgr.Enabled = false;
                rtxt_GpMgr.Enabled = false;
                rdtp_DATEofAppraisal.SelectedDate = DateTime.Now;
                rdtp_DATEofAppraisal.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsMgrAppraisalnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


    }

    private void LoadBusinessUnit()
    {
        try
        {
            SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
            _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"].ToString());
            rcmb_BU.Items.Clear();
            rcmb_BU.DataSource = BLL.get_Business_Units(_obj_smhr_logininfo);
            rcmb_BU.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BU.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BU.DataBind();
            rcmb_BU.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            RG_MgrAppraisal.Visible = false;
            tr_FinalRating.Visible = false;
            //rtxt_AppraisalCycle.Text = string.Empty;
            rtxt_GpMgr.Text = string.Empty;
            //rtxt_Project.Text = string.Empty;
            rtxt_RpMgr.Text = string.Empty;
            rcmb_EmployeeType.Items.Clear();
            rtxt_AppraisalCycle.Items.Clear();
            //btn_Submit.Visible = false;
            //btn_Finalise.Visible = false;
            //btn_Cancel.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsMgrAppraisalnew", ex.StackTrace, DateTime.Now);
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
                //rtxt_RpMgr.Text = Convert.ToString(dtbuid1.Rows[0]["REPORTINGMANAGER"]);
                //rtxt_GpMgr.Text = Convert.ToString(dtbuid1.Rows[0]["APPROVALMANAGER"]);
                rcmb_EmployeeType.Items.Clear();
                rcmb_EmployeeType.DataSource = dtbuid1;
                rcmb_EmployeeType.DataTextField = "employee";
                rcmb_EmployeeType.DataValueField = "EMPID";
                rcmb_EmployeeType.DataBind();

                rtxt_RpMgr.Enabled = false;
                rtxt_GpMgr.Enabled = false;
            }

            else
            {
                //RG_MgrAppraisal.Visible = false;
                Pms_Bll.ShowMessage(this, "Employee Not In Active State");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsMgrAppraisalnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadGrid()
    {
        try
        {
            PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            _obj_Pms_Appraisalcycle.MODE = 8;
            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(Convert.ToInt32(rcmb_BU.SelectedItem.Value));
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

            _obj_GS.GS_MODE = 27;
            _obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //_obj_GS.GS_ID = Convert.ToInt32(Session["GSID"]);
            DataTable dt_details = new DataTable();
            dt_details = Pms_Bll.get_GS(_obj_GS);
            if (dt_details.Rows.Count > 0)
            {
                RG_MgrAppraisal.DataSource = dt_details;
                RG_MgrAppraisal.DataBind();

                int tot_wt = 0;
                int tot_goal_wt = 0;
                int tot_kra_wt = 0;
                int tot_idp_wt = 0;
                for (int index = 0; index < RG_MgrAppraisal.Items.Count; index++)
                {
                    Label lbltype = new Label();
                    lbltype = RG_MgrAppraisal.Items[index].FindControl("lbl_type") as Label;
                    tot_wt = tot_wt + 5; //Convert.ToInt32(Convert.ToString(RG_MgrAppraisal.Items[index]["WEIGHTAGE"].Text).Trim());
                    if (lbltype.Text.Trim() == "Goal")
                        tot_goal_wt = tot_goal_wt + 5;// Convert.ToInt32(Convert.ToString(RG_MgrAppraisal.Items[index]["WEIGHTAGE"].Text).Trim());
                    else if (lbltype.Text.Trim() == "IDP")
                        tot_idp_wt = tot_idp_wt + 5;// Convert.ToInt32(Convert.ToString(RG_MgrAppraisal.Items[index]["WEIGHTAGE"].Text).Trim());
                    else
                        tot_kra_wt = tot_kra_wt + 5;// Convert.ToInt32(Convert.ToString(RG_MgrAppraisal.Items[index]["WEIGHTAGE"].Text).Trim());
                }
                decimal goal_rtng = 0;
                decimal kra_rtng = 0;
                decimal idp_rtng = 0;
                decimal appr_rtng = 0;
                for (int index = 0; index < dt_details.Rows.Count; index++)
                {
                    if (Convert.ToString(dt_details.Rows[index]["A"]).Trim() == "Goal")
                        goal_rtng = goal_rtng + (Convert.ToDecimal(dt_details.Rows[index]["MGR_RATING"])) / tot_goal_wt;
                    else if (Convert.ToString(dt_details.Rows[index]["A"]).Trim() == "IDP")
                        idp_rtng = idp_rtng + (Convert.ToDecimal(dt_details.Rows[index]["MGR_RATING"])) / tot_idp_wt;
                    else
                        kra_rtng = kra_rtng + (Convert.ToDecimal(dt_details.Rows[index]["MGR_RATING"])) / tot_kra_wt;
                    //Overall Rating
                    appr_rtng = appr_rtng + (Convert.ToDecimal(dt_details.Rows[index]["MGR_RATING"])) / tot_wt;
                }

                Lbl_competency.Text = Convert.ToString(Math.Round(goal_rtng * 100, 2)) + "%";
                lbl_Values.Text = Convert.ToString(Math.Round(idp_rtng * 100, 2)) + "%";
                lbl_objective.Text = Convert.ToString(Math.Round(kra_rtng * 100, 2)) + "%";
                RG_MgrAppraisal.Visible = true;
                tr_FinalRating.Visible = true;
                lbls.Visible = true;
                lbl_FinalRatingValue.Text = Convert.ToString(Math.Round(appr_rtng * 100, 2));
            }
            else
            {
                BLL.ShowMessage(this, "No Data Exists for this Employee.");
                ViewState["Status"] = 0;
                RG_MgrAppraisal.Visible = false;
                tr_FinalRating.Visible = false;
                lbls.Visible = false;
                return;
            }

            int count = 0;
            LinkButton lbtn = new LinkButton();
            for (int index = 0; index < RG_MgrAppraisal.Items.Count; index++)
            {
                lbtn = RG_MgrAppraisal.Items[index].FindControl("lnk_Edit") as LinkButton;
                if (dt_details.Rows[index]["FIXED"] != System.DBNull.Value)
                {
                    if (Convert.ToString(dt_details.Rows[index]["FIXED"]) != string.Empty)
                    {
                        if (Convert.ToString(dt_details.Rows[index]["FIXED"]) == "2")
                        {
                            //RG_MgrAppraisal.Items[index].Enabled = false;
                            count++;
                            lbtn.ForeColor = Color.Green;
                        }
                        else
                        {
                            //RG_MgrAppraisal.Items[index].Enabled = true;
                            lbtn.ForeColor = Color.Red;
                        }
                    }
                    else
                    {
                        //RG_MgrAppraisal.Items[index].Enabled = true;
                        lbtn.ForeColor = Color.Red;
                    }
                }
                else
                {
                    //RG_MgrAppraisal.Items[index].Enabled = true;
                    lbtn.ForeColor = Color.Red;
                }
            }
            if (count == RG_MgrAppraisal.Items.Count)
            {
                ViewState["Status"] = 1;
                //btn_Submit.Visible = false;
                //btn_Finalise.Visible = false;
                //btn_Cancel.Visible = true;
            }
            else
            {
                ViewState["Status"] = 0;
                //btn_Cancel.Visible = true;
                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    //btn_Submit.Visible = false;
                    //btn_Finalise.Visible = false;
                }
                else
                {
                    //btn_Submit.Visible = true;
                    //btn_Finalise.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsMgrAppraisalnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_BU_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            lnkAssignTraining.Visible = false;
            lnkEmpDtls.Visible = false;
            if (rcmb_BU.SelectedIndex > 0)
            {

                LoadAppraisalCycle();
            }
            else
            {
                //rcmb_EmployeeType.Items.Clear();
                rcmb_EmployeeType.ClearSelection();
                rcmb_EmployeeType.Items.Clear();
                rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                rtxt_AppraisalCycle.ClearSelection();
                rtxt_AppraisalCycle.Items.Clear();
                rtxt_AppraisalCycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
            RG_MgrAppraisal.Visible = false;
            lbls.Visible = false;
            //rtxt_AppraisalCycle.Text = string.Empty;
            rtxt_GpMgr.Text = string.Empty;
            //rtxt_Project.Text = string.Empty;
            rtxt_RpMgr.Text = string.Empty;
            rtxt_Role.Text = string.Empty;
            RG_MgrAppraisal.Visible = false;
            tr_FinalRating.Visible = false; lbls.Visible = false;
            rcmb_EmployeeType.ClearSelection();
            rcmb_EmployeeType.Items.Clear();
            rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsMgrAppraisalnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadAppraisalCycle()
    {
        try
        {
            rtxt_AppraisalCycle.ClearSelection();
            rtxt_AppraisalCycle.Items.Clear();
            rtxt_AppraisalCycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            _obj_Pms_Appraisalcycle.MODE = 9;
            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsMgrAppraisalnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_EmployeeType_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_EmployeeType.SelectedIndex > 0)
            {
                lnkEmpDtls.Visible = true;
                lnkAssignTraining.Visible = true;
                Session["MGR_EMP_ID"] = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                //LoadAppraisalCycle();
                _obj_pms_EmployeeSetup = new PMS_EMPSETUP();
                _obj_pms_EmployeeSetup.EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                _obj_pms_EmployeeSetup.BU_ID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
                _obj_pms_EmployeeSetup.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtbuid1 = Pms_Bll.get_LoginInfo(_obj_pms_EmployeeSetup);
                if (dtbuid1.Rows.Count != 0)
                {
                    rtxt_RpMgr.Text = Convert.ToString(dtbuid1.Rows[0]["REPORTINGMANAGER"]);
                    rtxt_GpMgr.Text = Convert.ToString(dtbuid1.Rows[0]["APPROVALMANAGER"]);
                    rtxt_RpMgr.Enabled = false;
                    rtxt_GpMgr.Enabled = false;

                    _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                    _obj_Pms_Appraisalcycle.MODE = 8;
                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
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
                            // rtxt_Project.Text = Convert.ToString(dt1.Rows[0]["PROJECT_NAME"]);
                            //rtxt_AppraisalCycle.Text = Convert.ToString(dt1.Rows[0]["APPRCYCLE_NAME"]);
                            //lbl_Apprais_id.Text = Convert.ToString(dt1.Rows[0]["APPRCYCLE_ID"]);
                            //rtxt_AppraisalCycle.Enabled = false;
                            rtxt_Role.Enabled = false;
                            //rtxt_Project.Enabled = false;
                            LoadGrid();
                            //RG_MgrAppraisal.Visible = true;
                            if (Convert.ToInt32(ViewState["Status"]) == 1)
                            {
                                BLL.ShowMessage(this, "Manager Appraisal Already Fianlized.");
                                return;
                            }
                        }
                        else
                        {
                            Pms_Bll.ShowMessage(this, "Goal Setting Has Not Done");
                            rtxt_Role.Text = string.Empty;
                            //rtxt_Project.Text = string.Empty;
                            //rtxt_AppraisalCycle.Text = string.Empty;
                            RG_MgrAppraisal.Visible = false;
                            tr_FinalRating.Visible = false;
                            lbls.Visible = false;
                            //btn_Submit.Visible = false;
                            //btn_Finalise.Visible = false;
                            //btn_Cancel.Visible = false;
                        }
                    }
                    else
                    {
                        Pms_Bll.ShowMessage(this, "Goal Setting Has Not Done");
                        rtxt_Role.Text = string.Empty;
                        //rtxt_Project.Text = string.Empty;
                        RG_MgrAppraisal.Visible = false;
                        tr_FinalRating.Visible = false;
                        lbls.Visible = false;
                        //btn_Submit.Visible = false;
                        //btn_Finalise.Visible = false;
                        //btn_Cancel.Visible = false;
                    }
                }

                else
                {
                    RG_MgrAppraisal.Visible = false;
                    tr_FinalRating.Visible = false;
                    lbls.Visible = false;
                    rtxt_Role.Text = string.Empty;
                    //rtxt_Project.Text = string.Empty;
                    rtxt_RpMgr.Text = string.Empty;
                    rtxt_GpMgr.Text = string.Empty;
                    //btn_Submit.Visible = false;
                    //btn_Finalise.Visible = false;
                    //btn_Cancel.Visible = false;
                    Pms_Bll.ShowMessage(this, "Employee Not In Active State");
                    return;
                }
            }
            else
            {
                rtxt_Role.Text = string.Empty;
                //rtxt_Project.Text = string.Empty;
                //rtxt_AppraisalCycle.Text = string.Empty;
                RG_MgrAppraisal.Visible = false;
                tr_FinalRating.Visible = false;
                lbls.Visible = false;
                rtxt_RpMgr.Text = string.Empty;
                rtxt_GpMgr.Text = string.Empty;
                lnkAssignTraining.Visible = false;
                lnkEmpDtls.Visible = false;
                //btn_Submit.Visible = false;
                //btn_Finalise.Visible = false;
                //btn_Cancel.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsMgrAppraisalnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rtxt_AppraisalCycle_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            lnkAssignTraining.Visible = false;
            lnkEmpDtls.Visible = false;
            if (rtxt_AppraisalCycle.SelectedIndex > 0)
            {
                rcmb_EmployeeType.ClearSelection();
                rcmb_EmployeeType.Items.Clear();
                rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                _obj_Pms_Appraisalcycle.MODE = 8;
                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtappidzzR = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                if (dtappidzzR.Rows.Count != 0)
                {
                    //TO GET SELFAPPRAISAL STATUS FOR SELECTED APPRAISAL CYCLE,15.09.2012
                    _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                    _obj_Pms_Appraisalcycle.MODE = 2;
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["org_id"]);
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value);
                    DataTable dt_app = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                    if (dt_app.Rows.Count > 0)
                    {
                        PMS_EMPSETUP _obj_Pms_EmpSetup;
                        _obj_Pms_EmpSetup = new PMS_EMPSETUP();
                        if (Convert.ToBoolean(dt_app.Rows[0]["APPRCYCLE_SELFAPPRAISAL"]) == false)
                            _obj_Pms_EmpSetup.Mode = 22;
                        else
                            _obj_Pms_EmpSetup.Mode = 18;
                        _obj_Pms_EmpSetup.BU_ID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
                        _obj_Pms_EmpSetup.GSLIFECYCLE = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value);//Convert.ToInt32(dtappidzzR.Rows[0]["APPRCYCLE_ID"]);
                        _obj_Pms_EmpSetup.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Pms_EmpSetup.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                        DataTable dt_EMP = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);

                        if (dt_EMP.Rows.Count != 0)
                        {
                            rcmb_EmployeeType.DataSource = dt_EMP;
                            rcmb_EmployeeType.DataTextField = "EMPLOYEE_NAME";
                            rcmb_EmployeeType.DataValueField = "EMP_ID";
                            rcmb_EmployeeType.DataBind();
                            rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                        }
                    }
                }
                //_obj_pms_EmployeeSetup = new PMS_EMPSETUP();
                //_obj_pms_EmployeeSetup.EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                //_obj_pms_EmployeeSetup.BU_ID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
                //_obj_pms_EmployeeSetup.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                //DataTable dtbuid1 = Pms_Bll.get_LoginInfo(_obj_pms_EmployeeSetup);
                //if (dtbuid1.Rows.Count != 0)
                //{
                //    //rtxt_RpMgr.Text = Convert.ToString(dtbuid1.Rows[0]["REPORTINGMANAGER"]);
                //    //rtxt_GpMgr.Text = Convert.ToString(dtbuid1.Rows[0]["APPROVALMANAGER"]);
                //    //rtxt_RpMgr.Enabled = false;
                //    //rtxt_GpMgr.Enabled = false;

                //    _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                //    _obj_Pms_Appraisalcycle.MODE = 8;
                //    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
                //    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                //    DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                //    //where i am getting apprisal cycle 
                //    if (dtappid.Rows.Count != 0)
                //    {
                //        _obj_GS = new PMS_GoalSettings();
                //        _obj_GS.GS_MODE = 9;
                //        _obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //        _obj_GS.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                //        _obj_GS.GS_APPRAISAL_CYCLE = Convert.ToString(rtxt_AppraisalCycle.SelectedItem.Value);//Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
                //        DataTable dt1 = Pms_Bll.get_GS(_obj_GS);
                //        if (dt1.Rows.Count != 0)
                //        {
                //            rtxt_Role.Text = Convert.ToString(dt1.Rows[0]["ROLE_NAMES"]);
                //            rtxt_Project.Text = Convert.ToString(dt1.Rows[0]["PROJECT_NAME"]);
                //            //rtxt_AppraisalCycle.Text = Convert.ToString(dt1.Rows[0]["APPRCYCLE_NAME"]);
                //            //lbl_Apprais_id.Text = Convert.ToString(dt1.Rows[0]["APPRCYCLE_ID"]);
                //            //rtxt_AppraisalCycle.Enabled = false;
                //            rtxt_Role.Enabled = false;
                //            rtxt_Project.Enabled = false;
                //            LoadGrid();
                //            RG_MgrAppraisal.Visible = true;
                //            if (Convert.ToInt32(ViewState["Status"]) == 1)
                //            {
                //                BLL.ShowMessage(this, "Manager Appraisal Already Fianlized.");
                //                return;
                //            }
                //        }
                //        else
                //        {
                //            Pms_Bll.ShowMessage(this, "Goal Setting Has Not Done");
                //            rtxt_Role.Text = string.Empty;
                //            rtxt_Project.Text = string.Empty;
                //            //rtxt_AppraisalCycle.Text = string.Empty;
                //            RG_MgrAppraisal.Visible = false;
                //            //btn_Submit.Visible = false;
                //            //btn_Finalise.Visible = false;
                //            //btn_Cancel.Visible = false;
                //        }
                //    }
                //    else
                //    {
                //        Pms_Bll.ShowMessage(this, "Goal Setting Has Not Done");
                //        rtxt_Role.Text = string.Empty;
                //        rtxt_Project.Text = string.Empty;
                //        //rtxt_AppraisalCycle.Text = string.Empty;
                //        RG_MgrAppraisal.Visible = false;
                //        //btn_Submit.Visible = false;
                //        //btn_Finalise.Visible = false;
                //        //btn_Cancel.Visible = false;
                //    }
                //}

                //else
                //{
                //    rtxt_Role.Text = string.Empty;
                //    rtxt_Project.Text = string.Empty;
                //    RG_MgrAppraisal.Visible = false;
                //    //btn_Submit.Visible = false;
                //    //btn_Finalise.Visible = false;
                //    //btn_Cancel.Visible = false;
                //    Pms_Bll.ShowMessage(this, "Employee Not In Active State");
                //    return;
                //}
            }
            else
            {
                rtxt_Role.Text = string.Empty;
                //rtxt_Project.Text = string.Empty;
                RG_MgrAppraisal.Visible = false;
                lbls.Visible = false;
                tr_FinalRating.Visible = false;
                rtxt_RpMgr.Text = string.Empty;
                rtxt_GpMgr.Text = string.Empty;
                rcmb_EmployeeType.ClearSelection();
                rcmb_EmployeeType.Items.Clear();
                rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                //btn_Submit.Visible = false;
                //btn_Finalise.Visible = false;
                //btn_Cancel.Visible = false;
            }
            rtxt_Role.Text = string.Empty;
            //rtxt_Project.Text = string.Empty;
            RG_MgrAppraisal.Visible = false;
            lbls.Visible = false;
            tr_FinalRating.Visible = false;
            rtxt_RpMgr.Text = string.Empty;
            rtxt_GpMgr.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsMgrAppraisalnew", ex.StackTrace, DateTime.Now);
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
            rtng_emp_detail.Value = 0;
            rtng_mgr_detail.Value = 0;
            rtxt_emp_Comments_Detail.Text = string.Empty;
            rtxt_mgr_Comments_detail.Text = string.Empty;
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
                _obj_GS.GS_ID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
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
            _obj_GS.CREATEDBY = Convert.ToInt32(ViewState["objid"]); //pasing obj id
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
                //  lbltype_detail_text.Text = Convert.ToString(dt_details.Rows[0]["A"]);
                //  lbl_rolekra_detail_text.Text = Convert.ToString(dt_details.Rows[0]["NAME"]);
                if (dt_details.Rows[0]["TARGET_ACHIEVED"] != System.DBNull.Value && Convert.ToString(dt_details.Rows[0]["TARGET_ACHIEVED"]) != "")
                {
                    rtng_emp_detail.Value = Convert.ToDouble(dt_details.Rows[0]["TARGET_ACHIEVED"]);
                }
                if (dt_details.Rows[0]["EMP_COMMENTS"] != System.DBNull.Value && Convert.ToString(dt_details.Rows[0]["EMP_COMMENTS"]) != "")
                {
                    rtxt_emp_Comments_Detail.Text = Convert.ToString(dt_details.Rows[0]["EMP_COMMENTS"]);
                }
                if (dt_details.Rows[0]["MGR_RATING"] != System.DBNull.Value && Convert.ToString(dt_details.Rows[0]["MGR_RATING"]) != "")
                
                {
                    rtng_mgr_detail.Value = Convert.ToDouble(dt_details.Rows[0]["MGR_RATING"]);
                }
                if (dt_details.Rows[0]["MGR_COMMENTS"] != System.DBNull.Value && Convert.ToString(dt_details.Rows[0]["MGR_COMMENTS"]) != "")
                {
                    rtxt_mgr_Comments_detail.Text = Convert.ToString(dt_details.Rows[0]["MGR_COMMENTS"]);
                }
                if (dt_details.Rows[0]["FIXED"] != System.DBNull.Value && Convert.ToString(dt_details.Rows[0]["FIXED"]) != string.Empty)
                {
                    if (Convert.ToString(dt_details.Rows[0]["FIXED"]) == "2")
                    {
                        btn_Submit_Detail.Visible = false;
                        btn_Finalise_Detail.Visible = false;
                        rtng_mgr_detail.Enabled = false;
                        rtxt_mgr_Comments_detail.Enabled = false;
                    }
                    else
                    {
                        btn_Submit_Detail.Visible = true;
                        btn_Finalise_Detail.Visible = true;
                        rtng_mgr_detail.Enabled = true;
                        rtxt_mgr_Comments_detail.Enabled = true;
                    }
                }
                else
                {
                    btn_Submit_Detail.Visible = true;
                    btn_Finalise_Detail.Visible = true;
                    rtng_mgr_detail.Enabled = true;
                    rtxt_mgr_Comments_detail.Enabled = true;
                }
                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    btn_Submit_Detail.Visible = false;
                    btn_Finalise_Detail.Visible = false;
                    rtng_mgr_detail.Enabled = false;
                    rtxt_mgr_Comments_detail.Enabled = false;
                }
                _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                _obj_Pms_Appraisalcycle.MODE = 2;
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["org_id"]);
                _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value);
                DataTable DT = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                if (DT.Rows.Count > 0)
                {
                    if (DT.Rows[0]["APPRCYCLE_SELFAPPRAISAL"] != System.DBNull.Value)
                    {
                        if (Convert.ToBoolean(DT.Rows[0]["APPRCYCLE_SELFAPPRAISAL"]) == true)
                        {
                            tr_empcommnets_details.Visible = true;
                            tr_empratng_details.Visible = true;
                        }
                        else
                        {
                            tr_empcommnets_details.Visible = false;
                            tr_empratng_details.Visible = false;
                        }
                    }
                }
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsMgrAppraisalnew", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsMgrAppraisalnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Submit_Detail_Click(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToDecimal(rtng_mgr_detail.Value) == 0)
            {
                BLL.ShowMessage(this, "Please Select Manager Rating");
                return;
            }
            //int count = 0;
            bool status = false;
            //for (int index = 0; index < RG_MgrAppraisal.Items.Count; index++)
            //{
            //    CheckBox chk = RG_MgrAppraisal.Items[index].FindControl("chckbtn_Select") as CheckBox;
            //    if (chk.Checked)
            //        count++;
            //}
            //if (count == 0)
            //{
            //    BLL.ShowMessage(this, "Please Select Atleast one Record.");
            //    return;
            //}
            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
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
            _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value);//Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
            _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_appr_chk = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
            if (dt_appr_chk.Rows.Count != 0)
            {
                //TO UPDATE THE STATUS IN PMS_APPRAISAL
                _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                _obj_Spms_Appraisal.APPRAISAL_DATE = rdtp_DATEofAppraisal.SelectedDate.Value;
                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE = 13;
                _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value); //Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
                _obj_Spms_Appraisal.APPRAISAL_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_Spms_Appraisal.APPRAISAL_STATUS = 2;
                _obj_Spms_Appraisal.APPRAISAL_CREATEDDATE = DateTime.Now;
                _obj_Spms_Appraisal.APPRAISAL_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_Spms_Appraisal.APPRAISAL_LASTMDFDATE = DateTime.Now;

                _obj_Spms_Appraisal.Mode = 44;
                status = Pms_Bll.set_Appraisal(_obj_Spms_Appraisal);
            }
            else
            {
                //TO INSERT THE DATA IN PMS_APPRAISAL
                _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                _obj_Spms_Appraisal.APPRAISAL_DATE = rdtp_DATEofAppraisal.SelectedDate.Value;
                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE = 13;
                _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value);// Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
                _obj_Spms_Appraisal.APPRAISAL_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_Spms_Appraisal.APPRAISAL_STATUS = 2;
                _obj_Spms_Appraisal.APPRAISAL_CREATEDDATE = DateTime.Now;

                _obj_Spms_Appraisal.Mode = 4;
                status = Pms_Bll.set_Appraisal(_obj_Spms_Appraisal);
            }
            if (status)
            {
                //TO GET THE APPRAISAL ID
                _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value); //Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
                _obj_Spms_Appraisal.Mode = 5;
                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_app_id = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                //CALCULATING TOTAL WEIGHTAGES
                int tot_wt = 0;
                int tot_goal_wt = 0;
                int tot_kra_wt = 0;
                int tot_idp_wt = 0;
                for (int index = 0; index < RG_MgrAppraisal.Items.Count; index++)
                {
                    Label lbltype = new Label();
                    lbltype = RG_MgrAppraisal.Items[index].FindControl("lbl_type") as Label;
                    tot_wt = tot_wt + 5; //Convert.ToInt32(Convert.ToString(RG_MgrAppraisal.Items[index]["WEIGHTAGE"].Text).Trim());
                    if (lbltype.Text.Trim() == "Goal")
                        tot_goal_wt = tot_goal_wt + 5;// Convert.ToInt32(Convert.ToString(RG_MgrAppraisal.Items[index]["WEIGHTAGE"].Text).Trim());
                    else if (lbltype.Text.Trim() == "IDP")
                        tot_idp_wt = tot_idp_wt + 5;// Convert.ToInt32(Convert.ToString(RG_MgrAppraisal.Items[index]["WEIGHTAGE"].Text).Trim());
                    else
                        tot_kra_wt = tot_kra_wt + 5;// Convert.ToInt32(Convert.ToString(RG_MgrAppraisal.Items[index]["WEIGHTAGE"].Text).Trim());
                }
                if (lbl_type_text.Text.Trim() == "Goal")
                {
                    //TO CHECK WHETHER DATA EXISTS FOR KRA IN APPRAISAL OR NOT
                    _obj_Spms_Appraisal.Mode = 30;
                    _obj_Spms_Appraisal.APP_ROLEKRA_ID = Convert.ToInt32(lbl_rolekra.Text);
                    DataTable dt_app_goal_chk = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                    if (dt_app_goal_chk.Rows.Count == 0)
                    {
                        //INSERTING THE APPRAISAL GOAL DATA
                        _obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();
                        _obj_Spms_AppraisalGoal.Mode = 3;
                        _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(lbl_rolekra.Text);
                        _obj_Spms_AppraisalGoal.APP_GOALS_MGR_RATING = Convert.ToDecimal(rtng_mgr_detail.Value);
                        _obj_Spms_AppraisalGoal.APP_GOALS_MGR_COMMENTS = Convert.ToString(rtxt_mgr_Comments_detail.Text.Replace("'", "''"));
                        if (dt_app_id.Rows.Count != 0)
                            _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dt_app_id.Rows[0]["APPRAISAL_ID"]);
                        else
                            _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = 0;
                        _obj_Spms_AppraisalGoal.APP_GOALS_FIXED = Convert.ToString(1);
                        _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Spms_AppraisalGoal.APP_GOALS_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_Spms_AppraisalGoal.APP_GOALS_CREATEDDATE = DateTime.Now;
                        _obj_Spms_AppraisalGoal.APP_GOALS_FINAL = 1;
                        bool status1 = Pms_Bll.set_AppraisalGoal(_obj_Spms_AppraisalGoal);
                    }
                    else
                    {
                        //TO UPDATE THE DATA IN APPRAISAL GOALS WITH STATUS OF FIXED
                        _obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();
                        if (dt_app_id.Rows.Count != 0)
                            _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dt_app_id.Rows[0]["APPRAISAL_ID"]);
                        else
                            _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = 0;
                        _obj_Spms_AppraisalGoal.APP_GOALS_MGR_RATING = Convert.ToDecimal(rtng_mgr_detail.Value);
                        _obj_Spms_AppraisalGoal.APP_GOALS_MGR_COMMENTS = Convert.ToString(rtxt_mgr_Comments_detail.Text.Replace("'", "''"));
                        _obj_Spms_AppraisalGoal.APP_GOALS_FIXED = Convert.ToString(1);
                        _obj_Spms_AppraisalGoal.APP_GOALS_FINAL = 1;
                        _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(lbl_rolekra.Text);
                        _obj_Spms_AppraisalGoal.Mode = 19;
                        _obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFDATE = DateTime.Now;
                        bool status10 = Pms_Bll.set_AppraisalGoal(_obj_Spms_AppraisalGoal);
                    }
                }
                else if (lbl_type_text.Text.Trim() == "IDP")
                {
                    //TO CHECK WHETHER DATA EXISTS FOR IDP IN APPRAISAL OR NOT
                    _obj_Spms_Appraisal.Mode = 43;
                    _obj_Spms_Appraisal.APP_ROLEKRA_ID = Convert.ToInt32(lbl_rolekra.Text);
                    DataTable dt_app_idp_chk = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                    if (dt_app_idp_chk.Rows.Count == 0)
                    {
                        //INSERTING THE APPRAISAL IDP DATA
                        _obj_Spms_AppraisalIdp = new SPMS_APPRAISALIDP();
                        _obj_Spms_AppraisalIdp.Mode = 3;
                        if (dt_app_id.Rows.Count != 0)
                            _obj_Spms_AppraisalIdp.APP_IDP_APP_ID = Convert.ToInt32(dt_app_id.Rows[0]["APPRAISAL_ID"]);
                        else
                            _obj_Spms_AppraisalIdp.APP_IDP_APP_ID = 0;
                        _obj_Spms_AppraisalIdp.APP_IDP_IDP_ID = Convert.ToInt32(lbl_rolekra.Text);
                        _obj_Spms_AppraisalIdp.APP_IDP_MGR_RATING = Convert.ToDecimal(rtng_mgr_detail.Value);
                        _obj_Spms_AppraisalIdp.APP_IDP_MGR_COMMENTS = Convert.ToString(rtxt_mgr_Comments_detail.Text.Replace("'", "''"));
                        _obj_Spms_AppraisalIdp.APP_IDP_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Spms_AppraisalIdp.APP_IDP_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_Spms_AppraisalIdp.APP_IDP_CREATEDDATE = DateTime.Now;
                        _obj_Spms_AppraisalIdp.APP_IDP_FINAL = 1;
                        _obj_Spms_AppraisalIdp.APP_IDP_FIXED = Convert.ToString(1);
                        bool status1 = Pms_Bll.set_AppraisalIdp(_obj_Spms_AppraisalIdp);
                    }
                    else
                    {
                        //UPDATING THE APPRAISAL IDP DATA WITH STATUS OF FIXED
                        _obj_Spms_AppraisalIdp = new SPMS_APPRAISALIDP();
                        if (dt_app_id.Rows.Count != 0)
                            _obj_Spms_AppraisalIdp.APP_IDP_APP_ID = Convert.ToInt32(dt_app_id.Rows[0]["APPRAISAL_ID"]);
                        else
                            _obj_Spms_AppraisalIdp.APP_IDP_APP_ID = 0;
                        _obj_Spms_AppraisalIdp.Mode = 20;
                        _obj_Spms_AppraisalIdp.APP_IDP_IDP_ID = Convert.ToInt32(lbl_rolekra.Text);
                        _obj_Spms_AppraisalIdp.APP_IDP_MGR_RATING = Convert.ToDecimal(rtng_mgr_detail.Value);
                        _obj_Spms_AppraisalIdp.APP_IDP_MGR_COMMENTS = Convert.ToString(rtxt_mgr_Comments_detail.Text.Replace("'", "''"));
                        _obj_Spms_AppraisalIdp.APP_IDP_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Spms_AppraisalIdp.APP_IDP_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_Spms_AppraisalIdp.APP_IDP_LASTMDFDATE = DateTime.Now;
                        _obj_Spms_AppraisalIdp.APP_IDP_FINAL = 1;
                        _obj_Spms_AppraisalIdp.APP_IDP_FIXED = Convert.ToString(1);
                        bool status1 = Pms_Bll.set_AppraisalIdp(_obj_Spms_AppraisalIdp);
                    }
                }
                else//FOR KRA
                {
                    //TO CHECK WHETHER DATA EXISTS FOR KRA IN APPRAISAL OR NOT
                    _obj_Spms_Appraisal.Mode = 31;
                    _obj_Spms_Appraisal.APP_ROLEKRA_ID = Convert.ToInt32(lbl_rolekra.Text);
                    _obj_Spms_Appraisal.APPRAISAL_CREATEDBY = Convert.ToInt32(LBL_OJID.Text);
                    DataTable dt_app_kra_chk = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                    if (dt_app_kra_chk.Rows.Count == 0)
                    {
                        //INSERTING THE APPRAISAL KRA DATA
                        _obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                        _obj_Spms_AppraisalKra.Mode = 3;
                        if (dt_app_id.Rows.Count != 0)
                            _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dt_app_id.Rows[0]["APPRAISAL_ID"]);
                        else
                            _obj_Spms_AppraisalKra.APP_KRA_APP_ID = 0;
                        _obj_Spms_AppraisalKra.APP_KRA_KRA_ID = Convert.ToInt32(lbl_rolekra.Text);
                        _obj_Spms_AppraisalKra.APP_KRA_OBJ_ID = Convert.ToInt32(LBL_OJID.Text);
                        _obj_Spms_AppraisalKra.APP_KRA_MGR_RATING = Convert.ToDecimal(rtng_mgr_detail.Value);
                        _obj_Spms_AppraisalKra.APP_KRA_MGR_COMMENTS = Convert.ToString(rtxt_mgr_Comments_detail.Text.Replace("'", "''"));
                        _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Spms_AppraisalKra.APP_KRA_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_Spms_AppraisalKra.APP_KRA_CREATEDDATE = DateTime.Now;
                        _obj_Spms_AppraisalKra.APP_KRA_FIXED = Convert.ToString(1);
                        _obj_Spms_AppraisalKra.APP_KRA_FINAL = 1;
                        bool status1 = Pms_Bll.set_AppraisalKra(_obj_Spms_AppraisalKra);

                    }
                    else
                    {
                        //UPDATING THE APPRAISAL KRA DATA WITH STATUS OF FIXED
                        _obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                        if (dt_app_id.Rows.Count != 0)
                            _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dt_app_id.Rows[0]["APPRAISAL_ID"]);
                        else
                            _obj_Spms_AppraisalKra.APP_KRA_APP_ID = 0;
                        _obj_Spms_AppraisalKra.Mode = 20;
                        _obj_Spms_AppraisalKra.APP_KRA_KRA_ID = Convert.ToInt32(lbl_rolekra.Text);
                        _obj_Spms_AppraisalKra.APP_KRA_OBJ_ID = Convert.ToInt32(LBL_OJID.Text);
                        _obj_Spms_AppraisalKra.APP_KRA_MGR_RATING = Convert.ToDecimal(rtng_mgr_detail.Value);
                        _obj_Spms_AppraisalKra.APP_KRA_MGR_COMMENTS = Convert.ToString(rtxt_mgr_Comments_detail.Text.Replace("'", "''"));
                        _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Spms_AppraisalKra.APP_KRA_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_Spms_AppraisalKra.APP_KRA_LASTMDFDATE = DateTime.Now;
                        _obj_Spms_AppraisalKra.APP_KRA_FIXED = Convert.ToString(1);
                        _obj_Spms_AppraisalKra.APP_KRA_FINAL = 1;
                        bool status1 = Pms_Bll.set_AppraisalKra(_obj_Spms_AppraisalKra);

                    }
                }
                PMS_GoalSettings obj_GS = new PMS_GoalSettings();
                _obj_GS.GS_ID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
                _obj_GS.GS_MODE = 27;
                _obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_details = new DataTable();
                dt_details = Pms_Bll.get_GS(_obj_GS);
                decimal goal_rtng = 0;
                decimal kra_rtng = 0;
                decimal idp_rtng = 0;
                decimal appr_rtng = 0;
                for (int index = 0; index < dt_details.Rows.Count; index++)
                {
                    if (Convert.ToString(dt_details.Rows[index]["A"]).Trim() == "Goal")
                        goal_rtng = goal_rtng + (Convert.ToDecimal(dt_details.Rows[index]["MGR_RATING"])) / tot_goal_wt;
                    else if (Convert.ToString(dt_details.Rows[index]["A"]).Trim() == "IDP")
                        idp_rtng = idp_rtng + (Convert.ToDecimal(dt_details.Rows[index]["MGR_RATING"])) / tot_idp_wt;
                    else
                        kra_rtng = kra_rtng + (Convert.ToDecimal(dt_details.Rows[index]["MGR_RATING"])) / tot_kra_wt;
                    //Overall Rating
                    appr_rtng = appr_rtng + (Convert.ToDecimal(dt_details.Rows[index]["MGR_RATING"])) / tot_wt;
                }

                //TO UPDATE THE AVG RATINGS IN APPRAISAL
                _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                _obj_Spms_Appraisal.APPRAISAL_GOAL_AVGRTG = Convert.ToDecimal(goal_rtng);
                _obj_Spms_Appraisal.APPRAISAL_KRA_AVGRTG = Convert.ToDecimal(kra_rtng);
                _obj_Spms_Appraisal.APPRAISAL_IDP_AVGRTG = Convert.ToDecimal(idp_rtng);
                _obj_Spms_Appraisal.APPRAISAL_AVGRTG = Convert.ToDecimal(appr_rtng);
                _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value);//Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Spms_Appraisal.APPRAISAL_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_Spms_Appraisal.APPRAISAL_LASTMDFDATE = DateTime.Now;
                _obj_Spms_Appraisal.Mode = 46;
                bool status11 = Pms_Bll.set_Appraisal(_obj_Spms_Appraisal);

                BLL.ShowMessage(this, "Manager Comments Submitted Successfully.");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsMgrAppraisalnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Finalise_Detail_Click(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToDecimal(rtng_mgr_detail.Value) == 0)
            {
                BLL.ShowMessage(this, "Please Select Manager Rating");
                return;
            }
            bool status = false;
            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

            _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
            _obj_Pms_EmpGoalSetting.Mode = 8;
            _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
            if (dtappid.Rows.Count != 0)
            {
                _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(rtxt_AppraisalCycle.SelectedItem.Value);// Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
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
            if (dt_appr_chk.Rows.Count != 0)
            {
                //TO UPDATE THE STATUS IN PMS_APPRAISAL
                _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                _obj_Spms_Appraisal.APPRAISAL_DATE = rdtp_DATEofAppraisal.SelectedDate.Value;
                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE = 13;
                _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value); //Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
                _obj_Spms_Appraisal.APPRAISAL_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_Spms_Appraisal.APPRAISAL_STATUS = 2;
                _obj_Spms_Appraisal.APPRAISAL_CREATEDDATE = DateTime.Now;
                _obj_Spms_Appraisal.APPRAISAL_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_Spms_Appraisal.APPRAISAL_LASTMDFDATE = DateTime.Now;

                _obj_Spms_Appraisal.Mode = 44;
                status = Pms_Bll.set_Appraisal(_obj_Spms_Appraisal);
            }
            else
            {
                //TO INSERT THE DATA IN PMS_APPRAISAL
                _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                _obj_Spms_Appraisal.APPRAISAL_DATE = rdtp_DATEofAppraisal.SelectedDate.Value;
                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE = 13;
                _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value);// Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
                _obj_Spms_Appraisal.APPRAISAL_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_Spms_Appraisal.APPRAISAL_STATUS = 2;
                _obj_Spms_Appraisal.APPRAISAL_CREATEDDATE = DateTime.Now;

                _obj_Spms_Appraisal.Mode = 4;
                status = Pms_Bll.set_Appraisal(_obj_Spms_Appraisal);
            }
            if (status)
            {
                //TO GET THE APPRAISAL ID
                _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value);// Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
                _obj_Spms_Appraisal.Mode = 5;
                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_app_id = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                //CALCULATING TOTAL WEIGHTAGES
                int tot_wt = 0;
                int tot_goal_wt = 0;
                int tot_kra_wt = 0;
                int tot_idp_wt = 0;
                for (int index = 0; index < RG_MgrAppraisal.Items.Count; index++)
                {
                    Label lbltype = new Label();
                    lbltype = RG_MgrAppraisal.Items[index].FindControl("lbl_type") as Label;
                    tot_wt = tot_wt + 5;// Convert.ToInt32(Convert.ToString(RG_MgrAppraisal.Items[index]["WEIGHTAGE"].Text).Trim());
                    if (lbltype.Text.Trim() == "Goal")
                        tot_goal_wt = tot_goal_wt + 5;// Convert.ToInt32(Convert.ToString(RG_MgrAppraisal.Items[index]["WEIGHTAGE"].Text).Trim());
                    else if (lbltype.Text.Trim() == "IDP")
                        tot_idp_wt = tot_idp_wt + 5;// Convert.ToInt32(Convert.ToString(RG_MgrAppraisal.Items[index]["WEIGHTAGE"].Text).Trim());
                    else
                        tot_kra_wt = tot_kra_wt + 5;// Convert.ToInt32(Convert.ToString(RG_MgrAppraisal.Items[index]["WEIGHTAGE"].Text).Trim());
                }
                ////TO GET THE AVG RATINGS FOR THAT APPRAISAL
                //_obj_Spms_Appraisal = new SPMS_APPRAISAL();
                //_obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                //_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value); //Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
                //_obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //_obj_Spms_Appraisal.Mode = 45;
                //DataTable dt_avg_rtngs = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                //decimal goal_rtng = Convert.ToDecimal(dt_avg_rtngs.Rows[0]["APPRAISAL_GOAL_AVGRTG"]);
                //decimal kra_rtng = Convert.ToDecimal(dt_avg_rtngs.Rows[0]["APPRAISAL_KRA_AVGRTG"]);
                //decimal idp_rtng = Convert.ToDecimal(dt_avg_rtngs.Rows[0]["APPRAISAL_IDP_AVGRTG"]);
                //decimal appr_rtng = Convert.ToDecimal(dt_avg_rtngs.Rows[0]["APPRAISAL_AVGRTG"]);

                if (lbl_type_text.Text.Trim() == "Goal")
                {
                    //TO CHECK WHETHER DATA EXISTS FOR KRA IN APPRAISAL OR NOT
                    _obj_Spms_Appraisal.Mode = 30;
                    _obj_Spms_Appraisal.APP_ROLEKRA_ID = Convert.ToInt32(lbl_rolekra.Text);
                    DataTable dt_app_goal_chk = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                    if (dt_app_goal_chk.Rows.Count == 0)
                    {
                        //INSERTING THE APPRAISAL GOAL DATA
                        _obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();
                        _obj_Spms_AppraisalGoal.Mode = 3;
                        _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(lbl_rolekra.Text);
                        _obj_Spms_AppraisalGoal.APP_GOALS_MGR_RATING = Convert.ToDecimal(rtng_mgr_detail.Value);
                        _obj_Spms_AppraisalGoal.APP_GOALS_MGR_COMMENTS = Convert.ToString(rtxt_mgr_Comments_detail.Text.Replace("'", "''"));
                        _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dt_app_id.Rows[0]["APPRAISAL_ID"]);
                        _obj_Spms_AppraisalGoal.APP_GOALS_FIXED = Convert.ToString(2);
                        _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Spms_AppraisalGoal.APP_GOALS_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_Spms_AppraisalGoal.APP_GOALS_CREATEDDATE = DateTime.Now;
                        _obj_Spms_AppraisalGoal.APP_GOALS_FINAL = 2;
                        bool status1 = Pms_Bll.set_AppraisalGoal(_obj_Spms_AppraisalGoal);
                    }
                    else
                    {
                        //TO UPDATE THE DATA IN APPRAISAL GOALS WITH STATUS OF FIXED
                        _obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();
                        if (dt_app_id.Rows.Count != 0)
                            _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dt_app_id.Rows[0]["APPRAISAL_ID"]);
                        else
                            _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = 0;
                        _obj_Spms_AppraisalGoal.APP_GOALS_MGR_RATING = Convert.ToDecimal(rtng_mgr_detail.Value);
                        _obj_Spms_AppraisalGoal.APP_GOALS_MGR_COMMENTS = Convert.ToString(rtxt_mgr_Comments_detail.Text.Replace("'", "''"));
                        _obj_Spms_AppraisalGoal.APP_GOALS_FIXED = Convert.ToString(2);
                        _obj_Spms_AppraisalGoal.APP_GOALS_FINAL = 2;
                        _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(lbl_rolekra.Text);
                        _obj_Spms_AppraisalGoal.Mode = 19;
                        _obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFDATE = DateTime.Now;
                        bool status10 = Pms_Bll.set_AppraisalGoal(_obj_Spms_AppraisalGoal);
                    }

                    ////TO GET THE WEIGHTAGE
                    //_obj_GSdetails = new PMS_GoalSettings_Details();
                    //_obj_GSdetails.GSDTL_ID = Convert.ToInt32(lbl_rolekra.Text);
                    //_obj_GSdetails.GSDTL_GS_ID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
                    //_obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                    //_obj_GSdetails.GS_DETAILS_MODE = 8;
                    //DataTable dt_goal_wt = Pms_Bll.get_GSdetails(_obj_GSdetails);

                    ////CALCULATING AVG RATING
                    //goal_rtng = goal_rtng + (Convert.ToDecimal(rtng_mgr_detail.Value) * Convert.ToInt32(dt_goal_wt.Rows[0]["GSDTL_WEIGHTAGE"])) / tot_goal_wt;
                    //appr_rtng = appr_rtng + (Convert.ToDecimal(rtng_mgr_detail.Value) * Convert.ToInt32(dt_goal_wt.Rows[0]["GSDTL_WEIGHTAGE"])) / tot_wt;
                }
                else if (lbl_type_text.Text.Trim() == "IDP")
                {
                    //TO CHECK WHETHER DATA EXISTS FOR IDP IN APPRAISAL OR NOT
                    _obj_Spms_Appraisal.Mode = 43;
                    _obj_Spms_Appraisal.APP_ROLEKRA_ID = Convert.ToInt32(lbl_rolekra.Text);
                    DataTable dt_app_idp_chk = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                    if (dt_app_idp_chk.Rows.Count == 0)
                    {
                        //INSERTING THE APPRAISAL IDP DATA
                        _obj_Spms_AppraisalIdp = new SPMS_APPRAISALIDP();
                        _obj_Spms_AppraisalIdp.Mode = 3;
                        if (dt_app_id.Rows.Count != 0)
                            _obj_Spms_AppraisalIdp.APP_IDP_APP_ID = Convert.ToInt32(dt_app_id.Rows[0]["APPRAISAL_ID"]);
                        else
                            _obj_Spms_AppraisalIdp.APP_IDP_APP_ID = 0;
                        _obj_Spms_AppraisalIdp.APP_IDP_IDP_ID = Convert.ToInt32(lbl_rolekra.Text);
                        _obj_Spms_AppraisalIdp.APP_IDP_MGR_RATING = Convert.ToDecimal(rtng_mgr_detail.Value);
                        _obj_Spms_AppraisalIdp.APP_IDP_MGR_COMMENTS = Convert.ToString(rtxt_mgr_Comments_detail.Text.Replace("'", "''"));
                        _obj_Spms_AppraisalIdp.APP_IDP_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Spms_AppraisalIdp.APP_IDP_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_Spms_AppraisalIdp.APP_IDP_CREATEDDATE = DateTime.Now;
                        _obj_Spms_AppraisalIdp.APP_IDP_FINAL = 2;
                        _obj_Spms_AppraisalIdp.APP_IDP_FIXED = Convert.ToString(2);
                        bool status1 = Pms_Bll.set_AppraisalIdp(_obj_Spms_AppraisalIdp);
                    }
                    else
                    {
                        //UPDATING THE APPRAISAL IDP DATA WITH STATUS OF FIXED
                        _obj_Spms_AppraisalIdp = new SPMS_APPRAISALIDP();
                        _obj_Spms_AppraisalIdp.APP_IDP_MGR_RATING = Convert.ToDecimal(rtng_mgr_detail.Value);
                        _obj_Spms_AppraisalIdp.APP_IDP_MGR_COMMENTS = Convert.ToString(rtxt_mgr_Comments_detail.Text.Replace("'", "''"));
                        if (dt_app_id.Rows.Count != 0)
                            _obj_Spms_AppraisalIdp.APP_IDP_APP_ID = Convert.ToInt32(dt_app_id.Rows[0]["APPRAISAL_ID"]);
                        else
                            _obj_Spms_AppraisalIdp.APP_IDP_APP_ID = 0;
                        _obj_Spms_AppraisalIdp.APP_IDP_IDP_ID = Convert.ToInt32(lbl_rolekra.Text);
                        _obj_Spms_AppraisalIdp.APP_IDP_FINAL = 2;
                        _obj_Spms_AppraisalIdp.APP_IDP_FIXED = Convert.ToString(2);
                        _obj_Spms_AppraisalIdp.Mode = 20;
                        _obj_Spms_AppraisalIdp.APP_IDP_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Spms_AppraisalIdp.APP_IDP_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_Spms_AppraisalIdp.APP_IDP_LASTMDFDATE = DateTime.Now;
                        bool status10 = Pms_Bll.set_AppraisalIdp(_obj_Spms_AppraisalIdp);
                    }

                    ////TO GET THE WEIGHTAGE
                    //_obj_Pms_goalIDPdetails = new GOALSETTING_IDP_DETAILS();
                    //_obj_Pms_goalIDPdetails.GS_IDP_IDP_ID = Convert.ToInt32(lbl_rolekra.Text);
                    //_obj_Pms_goalIDPdetails.GS_IDP_GS_ID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
                    //_obj_Pms_goalIDPdetails.GS_IDP_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    //_obj_Pms_goalIDPdetails.MODE = 10;
                    //DataTable dt_idp_wt = Pms_Bll.get_GsIDP(_obj_Pms_goalIDPdetails);

                    ////CALCULATING AVG RATING
                    //idp_rtng = idp_rtng + (Convert.ToDecimal(rtng_mgr_detail.Value) * Convert.ToInt32(dt_idp_wt.Rows[0]["GS_IDP_WEIGHTAGE"])) / tot_idp_wt;
                    //appr_rtng = appr_rtng + (Convert.ToDecimal(rtng_mgr_detail.Value) * Convert.ToInt32(dt_idp_wt.Rows[0]["GS_IDP_WEIGHTAGE"])) / tot_wt;
                }
                else//FOR KRA
                {
                    //TO CHECK WHETHER DATA EXISTS FOR KRA IN APPRAISAL OR NOT
                    _obj_Spms_Appraisal.Mode = 31;
                    _obj_Spms_Appraisal.APP_ROLEKRA_ID = Convert.ToInt32(lbl_rolekra.Text);
                    _obj_Spms_Appraisal.APPRAISAL_CREATEDBY = Convert.ToInt32(LBL_OJID.Text);
                    DataTable dt_app_kra_chk = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                    if (dt_app_kra_chk.Rows.Count == 0)
                    {
                        //INSERTING THE APPRAISAL KRA DATA
                        _obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                        _obj_Spms_AppraisalKra.Mode = 3;
                        if (dt_app_id.Rows.Count != 0)
                            _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dt_app_id.Rows[0]["APPRAISAL_ID"]);
                        else
                            _obj_Spms_AppraisalKra.APP_KRA_APP_ID = 0;
                        _obj_Spms_AppraisalKra.APP_KRA_KRA_ID = Convert.ToInt32(lbl_rolekra.Text);
                        _obj_Spms_AppraisalKra.APP_KRA_OBJ_ID = Convert.ToInt32(LBL_OJID.Text);
                        _obj_Spms_AppraisalKra.APP_KRA_MGR_RATING = Convert.ToDecimal(rtng_mgr_detail.Value);
                        _obj_Spms_AppraisalKra.APP_KRA_MGR_COMMENTS = Convert.ToString(rtxt_mgr_Comments_detail.Text.Replace("'", "''"));
                        _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Spms_AppraisalKra.APP_KRA_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_Spms_AppraisalKra.APP_KRA_CREATEDDATE = DateTime.Now;
                        _obj_Spms_AppraisalKra.APP_KRA_FIXED = Convert.ToString(2);
                        _obj_Spms_AppraisalKra.APP_KRA_FINAL = 2;
                        bool status1 = Pms_Bll.set_AppraisalKra(_obj_Spms_AppraisalKra);

                    }
                    else
                    {
                        //UPDATING THE APPRAISAL KRA DATA WITH STATUS OF FIXED
                        _obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                        _obj_Spms_AppraisalKra.APP_KRA_MGR_RATING = Convert.ToDecimal(rtng_mgr_detail.Value);
                        _obj_Spms_AppraisalKra.APP_KRA_MGR_COMMENTS = Convert.ToString(rtxt_mgr_Comments_detail.Text.Replace("'", "''"));
                        if (dt_app_id.Rows.Count != 0)
                            _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dt_app_id.Rows[0]["APPRAISAL_ID"]);
                        else
                            _obj_Spms_AppraisalKra.APP_KRA_APP_ID = 0;
                        _obj_Spms_AppraisalKra.APP_KRA_KRA_ID = Convert.ToInt32(lbl_rolekra.Text);
                        _obj_Spms_AppraisalKra.APP_KRA_OBJ_ID = Convert.ToInt32(LBL_OJID.Text);
                        _obj_Spms_AppraisalKra.APP_KRA_FIXED = Convert.ToString(2);
                        _obj_Spms_AppraisalKra.APP_KRA_FINAL = 2;
                        _obj_Spms_AppraisalKra.Mode = 20;
                        _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Spms_AppraisalKra.APP_KRA_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_Spms_AppraisalKra.APP_KRA_LASTMDFDATE = DateTime.Now;
                        bool status10 = Pms_Bll.set_AppraisalKra(_obj_Spms_AppraisalKra);
                    }

                    ////TO GET THE WEIGHTAGE
                    //_obj_Pms_goalkradetails = new GOALSETTING_GOALKRA_DETAILS();
                    //_obj_Pms_goalkradetails.GS_KRA_KRA_ID = Convert.ToInt32(lbl_rolekra.Text);
                    //_obj_Pms_goalkradetails.GS_KRA_GS_ID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
                    //_obj_Pms_goalkradetails.GS_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    //_obj_Pms_goalkradetails.MODE = 10;
                    //DataTable dt_kra_wt = Pms_Bll.get_Gskra(_obj_Pms_goalkradetails);

                    ////CALCULATING AVG RATING
                    //kra_rtng = kra_rtng + (Convert.ToDecimal(rtng_mgr_detail.Value) * Convert.ToInt32(dt_kra_wt.Rows[0]["GS_KRA_WEIGHTAGE"])) / tot_kra_wt;
                    //appr_rtng = appr_rtng + (Convert.ToDecimal(rtng_mgr_detail.Value) * Convert.ToInt32(dt_kra_wt.Rows[0]["GS_KRA_WEIGHTAGE"])) / tot_wt;
                }

                PMS_GoalSettings obj_GS = new PMS_GoalSettings();
                _obj_GS.GS_ID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
                _obj_GS.GS_MODE = 27;
                _obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_details = new DataTable();
                dt_details = Pms_Bll.get_GS(_obj_GS);
                decimal goal_rtng = 0;
                decimal kra_rtng = 0;
                decimal idp_rtng = 0;
                decimal appr_rtng = 0;
                for (int index = 0; index < dt_details.Rows.Count; index++)
                {
                    if (Convert.ToString(dt_details.Rows[index]["A"]).Trim() == "Goal")
                        goal_rtng = goal_rtng + (Convert.ToDecimal(dt_details.Rows[index]["MGR_RATING"])) / tot_goal_wt;
                    else if (Convert.ToString(dt_details.Rows[index]["A"]).Trim() == "IDP")
                        idp_rtng = idp_rtng + (Convert.ToDecimal(dt_details.Rows[index]["MGR_RATING"])) / tot_idp_wt;
                    else
                        kra_rtng = kra_rtng + (Convert.ToDecimal(dt_details.Rows[index]["MGR_RATING"])) / tot_kra_wt;
                    //Overall Rating
                    appr_rtng = appr_rtng + (Convert.ToDecimal(dt_details.Rows[index]["MGR_RATING"])) / tot_wt;
                }
                Lbl_competency.Text = Convert.ToString(Math.Round(goal_rtng * 100, 2)) + "%";
                lbl_Values.Text = Convert.ToString(Math.Round(idp_rtng * 100, 2)) + "%";
                lbl_objective.Text = Convert.ToString(Math.Round(kra_rtng * 100, 2)) + "%";

                //TO UPDATE THE AVG RATINGS IN APPRAISAL
                _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                _obj_Spms_Appraisal.APPRAISAL_GOAL_AVGRTG = Convert.ToDecimal(goal_rtng);
                _obj_Spms_Appraisal.APPRAISAL_KRA_AVGRTG = Convert.ToDecimal(kra_rtng);
                _obj_Spms_Appraisal.APPRAISAL_IDP_AVGRTG = Convert.ToDecimal(idp_rtng);
                _obj_Spms_Appraisal.APPRAISAL_AVGRTG = Convert.ToDecimal(appr_rtng);
                _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value);//Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Spms_Appraisal.APPRAISAL_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_Spms_Appraisal.APPRAISAL_LASTMDFDATE = DateTime.Now;
                _obj_Spms_Appraisal.Mode = 46;
                bool status11 = Pms_Bll.set_Appraisal(_obj_Spms_Appraisal);

                Rm_Appraisal_PAGE.SelectedIndex = 0;
                LoadGrid();
                BLL.ShowMessage(this, "Manager Comments Finalized Successfully.");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsMgrAppraisalnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //protected void lnk_ViewKRA_command(object sender, CommandEventArgs e)
    //{
    //    try
    //    {
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
    //            "ShowPop();", true);
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsMgrAppraisalnew", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}

    protected void lnkAssignTraining_Click(object sender, EventArgs e)
    {
        try
        {
            if (rcmb_EmployeeType.SelectedIndex > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowTrngDtlsPopup('" + Convert.ToString(rcmb_EmployeeType.SelectedValue) + "');", true);
            }
            else
            {
                Pms_Bll.ShowMessage(this, "Please Select Employee");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsMgrAppraisalnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnkEmpDtls_Click(object sender, EventArgs e)
    {
        try
        {
            if (rcmb_EmployeeType.SelectedIndex > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowEmpDataPop('" + Convert.ToString(rcmb_EmployeeType.SelectedValue) + "');", true);
            }
            else
            {
                Pms_Bll.ShowMessage(this, "Please Select Employee");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsMgrAppraisalnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
