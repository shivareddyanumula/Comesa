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

public partial class PMS_frm_PmsMgrAppraisal : System.Web.UI.Page
{
    SPMS_EMPGOALSETTING _obj_Pms_EmpGoalSetting;
    SPMS_APPRAISAL _obj_Spms_Appraisal;
    SPMS_APPRAISALGOAL _obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();
    SPMS_GOALSETTINGKRADETAILS _obj_Spms_GoalStgKraDtls;
    SPMS_APPRAISALKRA _obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
    SPMS_APRAISALAPPROVER _obj_Pms_AppApprover;

    PMS_GoalSettings_Details _obj_Pms_GoalSettingdetails;
    PMS_LOGININFO _obj_Pms_LoginInfo;
    PMS_GETEMPLOYEE _obj_PMS_getemployee;
    PMS_EMPSETUP _obj_pms_EmployeeSetup;

    int GSID;
    string strgoal;
    int Tempgoal = 0;
    int strgoalrtg;
    int tempgoalrtg = 0;

    string strkra;
    int tempkra = 0;
    int strkrartg;
    int tempkrartg = 0;



    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();

            if (!Page.IsPostBack)
            {
                //LoadEmployees();
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Manager Appraisal");
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
                    //  RG_SelfAppraisal.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    //   btn_Submit_Detail.Visible = false;
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
                LoadBusinessUnit();
                //_obj_pms_EmployeeSetup = new PMS_EMPSETUP();
                //_obj_pms_EmployeeSetup.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);

                //SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
                //_obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //_obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                //DataTable dt_buu = new DataTable();
                //dt_buu = BLL.get_Business_Units(_obj_smhr_logininfo);

                //_obj_PMS_getemployee = new PMS_GETEMPLOYEE();
                //_obj_PMS_getemployee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                //_obj_PMS_getemployee.Mode = 1;
                //_obj_PMS_getemployee.BU_ID = Convert.ToInt32(dt_buu.Rows[0]["BUSINESSUNIT_ID"]);
                //_obj_PMS_getemployee.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                //DataTable dtbuid1 = new DataTable();
                //dtbuid1 = Pms_Bll.get_RMEmployees(_obj_PMS_getemployee);
                //if (dtbuid1.Rows.Count != 0)
                //{
                //    //rcmb_EmployeeType.SelectedValue = Convert.ToString(dtbuid1.Rows[0]["employee"]);
                //    PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                //    _obj_Pms_Appraisalcycle.MODE = 8;
                //    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtbuid1.Rows[0]["BU_ID"]);
                //    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                //    DataTable dtappidzzR = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                //    if (dtappidzzR.Rows.Count != 0)
                //    {
                //        PMS_EMPSETUP _obj_Pms_EmpSetup;
                //        _obj_Pms_EmpSetup = new PMS_EMPSETUP();
                //        _obj_Pms_EmpSetup.Mode = 9;
                //        _obj_Pms_EmpSetup.BU_ID = Convert.ToInt32(dtbuid1.Rows[0]["BU_ID"]);
                //        _obj_Pms_EmpSetup.EMP_SETUP_LASTMDFBY = Convert.ToInt32(dtappidzzR.Rows[0]["APPRCYCLE_ID"]);
                //        _obj_Pms_EmpSetup.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                //        DataTable dt = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);

                //        if (dt.Rows.Count != 0)
                //        {
                //            rcmb_EmployeeType.DataSource = dt;
                //            rcmb_EmployeeType.DataTextField = "EMPLOYEE_NAME";
                //            rcmb_EmployeeType.DataValueField = "EMP_ID";
                //            rcmb_EmployeeType.DataBind();
                //            rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                //            //rcmb_BusinessUnitType.Visible = false;
                //            //lbl_BusinessUnitName.Visible = false;
                //            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                //            {

                //                rcmb_feedback.Enabled = false;


                //            }

                //            else
                //            {
                //                rcmb_feedback.Enabled = true;
                //            }

                //        }
                //        else
                //        {
                //            DataTable dt5 = new DataTable();

                //            rcmb_EmployeeType.DataSource = dt5;
                //            rcmb_EmployeeType.DataBind();
                //            //lbl_BusinessUnitName.Visible = false;
                //            //rcmb_BusinessUnitType.Visible = false;
                //            rcmb_feedback.Enabled = false;
                //            //Pms_Bll.ShowMessage(this, "No Employee Completed Self Appraisal");
                //        }
                //    }
                //    else
                //    {
                //        DataTable dt5 = new DataTable();

                //        rcmb_EmployeeType.DataSource = dt5;
                //        rcmb_EmployeeType.DataBind();
                //        //lbl_BusinessUnitName.Visible = false;
                //        //rcmb_BusinessUnitType.Visible = false;
                //        rcmb_feedback.Enabled = false;
                //    }

                //    rdtp_DATEofAppraisal.SelectedDate = DateTime.Now;
                //    rdtp_DATEofAppraisal.Enabled = false;
                //    Rm_Appraisal_PAGE.SelectedIndex = 0;
                //    rtxt_Role.Text = string.Empty;
                //    rtxt_Project.Text = string.Empty;
                //    rtxt_GpMgr.Text = string.Empty;
                //    rtxt_RpMgr.Text = string.Empty;
                //    rtxt_AppraisalCycle.Text = string.Empty;
                //    rtxt_Role.Enabled = true;
                //    rtxt_GpMgr.Enabled = true;
                //    rtxt_Project.Enabled = true;
                //    rtxt_AppraisalCycle.Enabled = true;
                //    lblkra.Visible = false;
                //    rnt_KraAvgrtg.Visible = false;
                //    lbl_KraAvgRtg.Visible = false;
                //    btn_kramgrfinalise.Visible = false;
                //    rtxt_RpMgr.Enabled = true;
                //    rcmb_feedback.Enabled = false;

                //    LNK_IDP22.Visible = false;

                //}
                //else
                //{ Pms_Bll.ShowMessage(this, "No Employee Completed Self Appraisal");
                //DataTable dt5 = new DataTable();

                //rcmb_EmployeeType.DataSource = dt5;
                //rcmb_EmployeeType.DataBind();
                ////lbl_BusinessUnitName.Visible = false;
                ////rcmb_BusinessUnitType.Visible = false;
                //rcmb_feedback.Enabled = false;
                //}
            }

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsMgrAppraisal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    #region LoadMgrppraisalDiscussion
    /// <summary>
    /// here i am loading manager details based on employee selection
    /// </summary>
    /// <param name="dt"></param>
    #endregion


    #region LoadGoal Grid
    /// <summary>
    /// here i am binding goal grid based on employee selection 
    /// </summary>
    /// <param name="dt"></param>
    protected void LoadGrid()
    {
        try
        {

            _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
            //_obj_Pms_EmpGoalSetting.Mode = 10;

            //_obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
            ////_obj_Pms_EmpGoalSetting.GS_APPRAISALSTAGE = 12;

            //DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
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
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
            _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
            _obj_Pms_EmpGoalSetting.Mode = 10;
            _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
            if (dtappid.Rows.Count != 0)
            {
                _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
            }
            DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);

            if (dt.Rows.Count != 0)
            {
                GSID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
            }
            PMS_GoalSettings_Details _obj_GSdetails = new PMS_GoalSettings_Details();
            _obj_GSdetails.GSDTL_GS_ID = GSID;

            _obj_GSdetails.GS_DETAILS_MODE = 5;
            _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_details = new DataTable();
            dt_details = Pms_Bll.get_GSdetails(_obj_GSdetails);
            if (dt_details.Rows.Count != 0)
            {
                Rg_Appraisal_Goal.DataSource = dt_details;
                Rg_Appraisal_Goal.DataBind();
                Rm_Appraisal_GOALKRA.SelectedIndex = 0;
                Rg_Appraisal_Goal.Visible = true;
                Rp_Appraisal_VIEWDETAILS.Visible = true;
                for (int i = 0; i < Rg_Appraisal_Goal.Rows.Count; i++)
                {
                    _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                    _obj_Pms_Appraisalcycle.MODE = 11;
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtemzLaP = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                    _obj_Pms_Appraisalcycle.MODE = 8;
                    if (dtemzLaP.Rows.Count != 0)
                    {
                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzLaP.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                    }
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtappidzLaP = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                    RadRating rdrtgtargetachieve = new Telerik.Web.UI.RadRating();
                    rdrtgtargetachieve = Rg_Appraisal_Goal.Rows[i].FindControl("ratingPie") as RadRating;

                    _obj_Pms_EmpGoalSetting.Mode = 16;
                    _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                    if (dtappidzLaP.Rows.Count != 0)
                    {
                        _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(dtappidzLaP.Rows[0]["APPRCYCLE_ID"]);
                    }
                    _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dt22 = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
                    if (dt22.Rows[i]["GSDTL_TARGET_ACHEIVED"] != string.Empty)
                    {
                        int k = Convert.ToInt32(dt22.Rows[i]["GSDTL_TARGET_ACHEIVED"]);
                        if (k == 1)
                        {
                            rdrtgtargetachieve.Value = Convert.ToInt32(dt22.Rows[i]["GSDTL_TARGET_ACHEIVED"]);
                            rdrtgtargetachieve.Enabled = false;
                            rdrtgtargetachieve.ToolTip = "0%";
                        }
                        else if (k == 2)
                        {
                            rdrtgtargetachieve.ToolTip = "25%";
                            rdrtgtargetachieve.Value = Convert.ToInt32(dt22.Rows[i]["GSDTL_TARGET_ACHEIVED"]);
                            rdrtgtargetachieve.Enabled = false;

                        }
                        else if (k == 3)
                        {
                            rdrtgtargetachieve.Value = Convert.ToInt32(dt22.Rows[i]["GSDTL_TARGET_ACHEIVED"]);
                            rdrtgtargetachieve.Enabled = false;
                            rdrtgtargetachieve.ToolTip = "50%";
                        }
                        else if (k == 4)
                        {
                            rdrtgtargetachieve.Value = Convert.ToInt32(dt22.Rows[i]["GSDTL_TARGET_ACHEIVED"]);
                            rdrtgtargetachieve.Enabled = false;
                            rdrtgtargetachieve.ToolTip = "75%";
                        }
                        else if (k == 5)
                        {
                            rdrtgtargetachieve.Value = Convert.ToInt32(dt22.Rows[i]["GSDTL_TARGET_ACHEIVED"]);
                            rdrtgtargetachieve.Enabled = false;
                            rdrtgtargetachieve.ToolTip = "100%";
                        }
                        else if (k == 0)
                        {

                            rdrtgtargetachieve.Enabled = false;

                        }

                    }
                    else
                    {
                        rdrtgtargetachieve.Value = 0;
                        rdrtgtargetachieve.Enabled = true;
                    }
                }
            }
            else
            {
                Pms_Bll.ShowMessage(this, "No Goal Assigned");
                return;
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsMgrAppraisal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    #endregion

    #region LoadKra Grid
    /// <summary>
    /// here i am binding Kra grid based on employee selection 
    /// </summary>
    /// <param name="dt"></param>
    protected void LoadKraGrid()
    {
        try
        {
            //_obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
            //_obj_Pms_EmpGoalSetting.Mode = 10;

            //_obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
            ////_obj_Pms_EmpGoalSetting.GS_APPRAISALSTAGE = 12;
            //DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);

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
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
            _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
            _obj_Pms_EmpGoalSetting.Mode = 10;
            _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);

            _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
            if (dtappid.Rows.Count != 0)
            {
                _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
            }
            DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
            if (dt.Rows.Count != 0)
            {
                GSID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
            }
            PMS_GoalSettings_Details _obj_GSdetails = new PMS_GoalSettings_Details();
            _obj_GSdetails.GSDTL_GS_ID = GSID;
            _obj_GSdetails.GS_DETAILS_MODE = 5;
            _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_details = new DataTable();
            dt_details = Pms_Bll.get_GSdetails(_obj_GSdetails);
            if (dt_details.Rows.Count != 0)
            {
                _obj_Spms_GoalStgKraDtls = new SPMS_GOALSETTINGKRADETAILS();
                _obj_Spms_GoalStgKraDtls.Mode = 7;
                _obj_Spms_GoalStgKraDtls.GS_KRA_GSDTL_ID = Convert.ToInt32(dt_details.Rows[0]["GSDTL_GS_ID"]);
                _obj_Spms_GoalStgKraDtls.LASTMDFBY = Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
                _obj_Spms_GoalStgKraDtls.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt2 = Pms_Bll.get_GoalStgKraDtls(_obj_Spms_GoalStgKraDtls);

                if (dt2.Rows.Count != 0)
                {
                    Rg_Appraisal_Kra.DataSource = dt2;
                    Rg_Appraisal_Kra.DataBind();



                    Rm_Appraisal_PAGE.SelectedIndex = 0;
                    Rm_Appraisal_GOALKRA.SelectedIndex = 1;
                    Rg_Appraisal_Goal.Visible = true;//n
                    Rp_Appraisal_VIEWDETAILS.Visible = true;
                    for (int i = 0; i < Rg_Appraisal_Kra.Rows.Count; i++)
                    {
                        RadRating rdrtgtargetachievekra = new Telerik.Web.UI.RadRating();
                        rdrtgtargetachievekra = Rg_Appraisal_Kra.Rows[i].FindControl("ratingPiekra") as RadRating;
                        Label lblkradt_id = new System.Web.UI.WebControls.Label();
                        lblkradt_id = Rg_Appraisal_Kra.Rows[i].FindControl("lbl_Kra_Id") as Label;

                        _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                        _obj_Pms_Appraisalcycle.MODE = 11;
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtem12 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                        _obj_Pms_Appraisalcycle.MODE = 8;
                        if (dtem12.Rows.Count != 0)
                        {

                            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem12.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                        }
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtappid1 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                        _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
                        _obj_Pms_EmpGoalSetting.Mode = 10;
                        _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                        if (dtappid.Rows.Count != 0)
                        {

                            _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(dtappid1.Rows[0]["APPRCYCLE_ID"]);
                        }
                        DataTable dt11 = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
                        if (dt11.Rows.Count != 0)
                        {
                            PMS_EMPSETUP _obj_Pms_EmpSetup = new PMS_EMPSETUP();
                            _obj_Pms_EmpSetup.Mode = 17;
                            _obj_Pms_EmpSetup.EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                            _obj_Pms_EmpSetup.EMP_SETUP_LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtem1 = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);

                            SPMS_ROLES _obj_Pms_Roles = new SPMS_ROLES();
                            _obj_Pms_Roles.Mode = 6;
                            if (dtem1.Rows.Count != 0)
                            {
                                _obj_Pms_Roles.BUID = Convert.ToInt32(dtem1.Rows[0]["BU_ID"]);
                            }
                            _obj_Pms_Roles.ROLES_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Pms_Roles.ROLES_NAME = Convert.ToString(rtxt_Role.Text);
                            DataTable dt5 = Pms_Bll.get_Roles(_obj_Pms_Roles);

                            SPMS_ROLEKRA _obj_Pms_RoleKra = new SPMS_ROLEKRA();
                            _obj_Pms_RoleKra.Mode = 8;
                            if (dt5.Rows.Count != 0)
                            {
                                _obj_Pms_RoleKra.ROLE_ID = Convert.ToInt32(dt5.Rows[0]["ROLE_ID"]);
                            }
                            _obj_Pms_RoleKra.ROLE_KRA_ID = Convert.ToInt32(lblkradt_id.Text);
                            _obj_Pms_RoleKra.ROLEKRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dt20 = Pms_Bll.get_RoleKra(_obj_Pms_RoleKra);


                            if (dt20.Rows.Count != 0)
                            {
                                GOALSETTING_GOALKRA_DETAILS _obj_Pms_goalkradetails = new GOALSETTING_GOALKRA_DETAILS();
                                _obj_Pms_goalkradetails.MODE = 9;
                                _obj_Pms_goalkradetails.GS_KRA_TARGET_ACHEIVED = Convert.ToString(rdrtgtargetachievekra.Value);
                                if (dt11.Rows.Count != 0)
                                {
                                    _obj_Pms_goalkradetails.GS_KRA_GS_ID = Convert.ToInt32(dt11.Rows[0]["GS_ID"]);
                                }
                                _obj_Pms_goalkradetails.GS_KRA_KRA_ID = Convert.ToInt32(dt20.Rows[0]["ROLEKRA_ID"]);
                                _obj_Pms_goalkradetails.GS_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dt13 = Pms_Bll.get_Gskra(_obj_Pms_goalkradetails);

                                if (dt13.Rows[0]["GS_KRA_TARGET_ACHEIVED"] != string.Empty)
                                {

                                    int j = Convert.ToInt32(dt13.Rows[0]["GS_KRA_TARGET_ACHEIVED"]);
                                    if (j == 1)
                                    {
                                        rdrtgtargetachievekra.Value = Convert.ToInt32(dt13.Rows[0]["GS_KRA_TARGET_ACHEIVED"]);
                                        rdrtgtargetachievekra.Enabled = false;
                                        rdrtgtargetachievekra.ToolTip = "0%";
                                    }
                                    else if (j == 2)
                                    {
                                        rdrtgtargetachievekra.Value = Convert.ToInt32(dt13.Rows[0]["GS_KRA_TARGET_ACHEIVED"]);
                                        rdrtgtargetachievekra.Enabled = false;
                                        rdrtgtargetachievekra.ToolTip = "25%";
                                    }
                                    else if (j == 3)
                                    {
                                        rdrtgtargetachievekra.Value = Convert.ToInt32(dt13.Rows[0]["GS_KRA_TARGET_ACHEIVED"]);
                                        rdrtgtargetachievekra.Enabled = false;
                                        rdrtgtargetachievekra.ToolTip = "50%";
                                    }
                                    else if (j == 4)
                                    {
                                        rdrtgtargetachievekra.Value = Convert.ToInt32(dt13.Rows[0]["GS_KRA_TARGET_ACHEIVED"]);
                                        rdrtgtargetachievekra.Enabled = false;
                                        rdrtgtargetachievekra.ToolTip = "75%";
                                    }
                                    else if (j == 5)
                                    {
                                        rdrtgtargetachievekra.Value = Convert.ToInt32(dt13.Rows[0]["GS_KRA_TARGET_ACHEIVED"]);
                                        rdrtgtargetachievekra.Enabled = false;
                                        rdrtgtargetachievekra.ToolTip = "100%";
                                    }
                                    else if (j == 0)
                                    {

                                        rdrtgtargetachievekra.Enabled = false;

                                    }
                                }

                            }
                        }
                        else
                        {
                            rdrtgtargetachievekra.Value = 0;
                            rdrtgtargetachievekra.Enabled = true;
                        }

                    }

                }
                else
                {
                    Pms_Bll.ShowMessage(this, "No Kra Assigned");
                    rcmb_BusinessUnitType.Enabled = true;
                    rcmb_EmployeeType.Enabled = true;
                    return;
                }
            }
            else
            {
                Pms_Bll.ShowMessage(this, "No Kra Assigned");
                rcmb_BusinessUnitType.Enabled = true;
                rcmb_EmployeeType.Enabled = true;
                return;
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsMgrAppraisal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion


    #region LoadBusineeUnit
    /// <summary>
    /// I Am Loading Business uit values based on business unit id
    /// </summary>

    protected void LoadBusinessUnit()
    {


        SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
        _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
        _obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"].ToString());
        rcmb_BusinessUnitType.Items.Clear();
        rcmb_BusinessUnitType.DataSource = BLL.get_Business_Units(_obj_smhr_logininfo);
        rcmb_BusinessUnitType.DataTextField = "BUSINESSUNIT_CODE";
        rcmb_BusinessUnitType.DataValueField = "BUSINESSUNIT_ID";
        rcmb_BusinessUnitType.DataBind();
        rcmb_BusinessUnitType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

        rdtp_DATEofAppraisal.SelectedDate = DateTime.Now;
        rdtp_DATEofAppraisal.Enabled = false;
        Rm_Appraisal_PAGE.SelectedIndex = 0;
        rtxt_Role.Text = string.Empty;
        rtxt_Project.Text = string.Empty;
        rtxt_GpMgr.Text = string.Empty;
        rtxt_RpMgr.Text = string.Empty;
        rtxt_AppraisalCycle.Text = string.Empty;
        rtxt_Role.Enabled = true;
        rtxt_GpMgr.Enabled = true;
        rtxt_Project.Enabled = true;
        rtxt_AppraisalCycle.Enabled = true;
        lblkra.Visible = false;
        rnt_KraAvgrtg.Visible = false;
        lbl_KraAvgRtg.Visible = false;
        btn_kramgrfinalise.Visible = false;
        rtxt_RpMgr.Enabled = true;
        rcmb_feedback.Enabled = false;

        LNK_IDP22.Visible = false;
    }
    #endregion

    #region Loading Employee Details
    /// <summary>
    /// HERE I AM LOADING EMPLOYEE DETAILS WHEN BUSINESS UNIT COMBO BOX SELECT INDEX CHANGED EVENT FIRED
    /// </summary>
    /// <param name="o"></param>
    /// <param name="e"></param>


    protected void rcmb_BusinessUnitType_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            //    //LoadEmployees();
            //    PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            //    _obj_Pms_Appraisalcycle.MODE = 8;
            //    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
            //    DataTable dtappidzzR = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

            //    PMS_EMPSETUP _obj_Pms_EmpSetup;
            //    _obj_Pms_EmpSetup = new PMS_EMPSETUP();
            //    _obj_Pms_EmpSetup.Mode = 9;
            //    _obj_Pms_EmpSetup.BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
            //    _obj_Pms_EmpSetup.EMP_SETUP_LASTMDFBY=Convert.ToInt32(dtappidzzR.Rows[0]["APPRCYCLE_ID"]);
            //    DataTable dt = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);

            //    rcmb_EmployeeType.Items.Clear();
            //    rcmb_EmployeeType.DataSource = dt;
            //    rcmb_EmployeeType.DataTextField = "EMPLOYEE_NAME";
            //    rcmb_EmployeeType.DataValueField = "EMP_ID";
            //    rcmb_EmployeeType.DataBind();
            //    rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));


            //To Load Employee Dropdown List
            if (rcmb_BusinessUnitType.SelectedIndex > 0)
            {
                _obj_pms_EmployeeSetup = new PMS_EMPSETUP();
                _obj_pms_EmployeeSetup.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);

                //SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
                //_obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //_obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                //DataTable dt_buu = new DataTable();
                //dt_buu = BLL.get_Business_Units(_obj_smhr_logininfo);

                _obj_PMS_getemployee = new PMS_GETEMPLOYEE();
                _obj_PMS_getemployee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                _obj_PMS_getemployee.Mode = 1;
                _obj_PMS_getemployee.BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
                _obj_PMS_getemployee.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtbuid1 = new DataTable();
                dtbuid1 = Pms_Bll.get_RMEmployees(_obj_PMS_getemployee);
                if (dtbuid1.Rows.Count != 0)
                {
                    //rcmb_EmployeeType.SelectedValue = Convert.ToString(dtbuid1.Rows[0]["employee"]);
                    PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                    _obj_Pms_Appraisalcycle.MODE = 8;
                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtappidzzR = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                    if (dtappidzzR.Rows.Count != 0)
                    {
                        PMS_EMPSETUP _obj_Pms_EmpSetup;
                        _obj_Pms_EmpSetup = new PMS_EMPSETUP();
                        _obj_Pms_EmpSetup.Mode = 9;
                        _obj_Pms_EmpSetup.BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
                        _obj_Pms_EmpSetup.EMP_SETUP_LASTMDFBY = Convert.ToInt32(dtappidzzR.Rows[0]["APPRCYCLE_ID"]);
                        _obj_Pms_EmpSetup.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dt = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);

                        if (dt.Rows.Count != 0)
                        {
                            rcmb_EmployeeType.DataSource = dt;
                            rcmb_EmployeeType.DataTextField = "EMPLOYEE_NAME";
                            rcmb_EmployeeType.DataValueField = "EMP_ID";
                            rcmb_EmployeeType.DataBind();
                            rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                            //rcmb_BusinessUnitType.Visible = false;
                            //lbl_BusinessUnitName.Visible = false;
                            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                            {

                                rcmb_feedback.Enabled = false;


                            }

                            else
                            {
                                rcmb_feedback.Enabled = true;
                            }

                        }
                        else
                        {
                            DataTable dt5 = new DataTable();

                            rcmb_EmployeeType.DataSource = dt5;
                            rcmb_EmployeeType.DataBind();
                            //lbl_BusinessUnitName.Visible = false;
                            //rcmb_BusinessUnitType.Visible = false;
                            rcmb_feedback.Enabled = false;
                            //Pms_Bll.ShowMessage(this, "No Employee Completed Self Appraisal");
                        }
                    }
                    else
                    {
                        DataTable dt5 = new DataTable();

                        rcmb_EmployeeType.DataSource = dt5;
                        rcmb_EmployeeType.DataBind();
                        //lbl_BusinessUnitName.Visible = false;
                        //rcmb_BusinessUnitType.Visible = false;
                        rcmb_feedback.Enabled = false;
                    }

                    rdtp_DATEofAppraisal.SelectedDate = DateTime.Now;
                    rdtp_DATEofAppraisal.Enabled = false;
                    //Rm_Appraisal_PAGE.SelectedIndex = 0;
                    //rtxt_Role.Text = string.Empty;
                    //rtxt_Project.Text = string.Empty;
                    //rtxt_GpMgr.Text = string.Empty;
                    //rtxt_RpMgr.Text = string.Empty;
                    //rtxt_AppraisalCycle.Text = string.Empty;
                    //rtxt_Role.Enabled = true;
                    //rtxt_GpMgr.Enabled = true;
                    //rtxt_Project.Enabled = true;
                    //rtxt_AppraisalCycle.Enabled = true;
                    //lblkra.Visible = false;
                    //rnt_KraAvgrtg.Visible = false;
                    //lbl_KraAvgRtg.Visible = false;
                    //btn_kramgrfinalise.Visible = false;
                    //rtxt_RpMgr.Enabled = true;
                    //rcmb_feedback.Enabled = false;

                    //LNK_IDP22.Visible = false;

                    rtxt_RpMgr.Enabled = true;
                    rtxt_GpMgr.Enabled = true;
                    rtxt_Role.Enabled = true;
                    rtxt_Project.Enabled = true;
                    rtxt_RpMgr.Text = String.Empty;
                    rtxt_GpMgr.Text = string.Empty;
                    rtxt_Role.Text = string.Empty;
                    rtxt_Project.Text = string.Empty;
                    rtxt_AppraisalCycle.Text = string.Empty;
                    rtxt_AppraisalCycle.Enabled = true;
                    rcmb_feedback.Enabled = false;
                    Rg_Appraisal_Kra.Visible = false;
                    Rg_Appraisal_Goal.Visible = false;
                    lbl_GoalAvgRtg.Visible = false;
                    rnt_GoalAvgrtg.Visible = false;
                    lbl_KraAvgRtg.Visible = false;
                    rnt_KraAvgrtg.Visible = false;
                    lblgoal.Visible = false;
                    lblkra.Visible = false;
                    rcmb_feedback.SelectedIndex = 0;

                }
                else
                {
                    Pms_Bll.ShowMessage(this, "No Employee Completed Self Appraisal");
                    DataTable dt5 = new DataTable();

                    rcmb_EmployeeType.DataSource = dt5;
                    rcmb_EmployeeType.DataBind();
                    //lbl_BusinessUnitName.Visible = false;
                    //rcmb_BusinessUnitType.Visible = false;
                    rcmb_feedback.Enabled = false;
                }
            }
            else
            {
                //Pms_Bll.ShowMessage(this, "Please Select Employee");
                rcmb_EmployeeType.ClearSelection();
                rcmb_EmployeeType.Items.Clear();
                rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                rtxt_RpMgr.Enabled = true;
                rtxt_GpMgr.Enabled = true;
                rtxt_Role.Enabled = true;
                rtxt_Project.Enabled = true;
                rtxt_RpMgr.Text = String.Empty;
                rtxt_GpMgr.Text = string.Empty;
                rtxt_Role.Text = string.Empty;
                rtxt_Project.Text = string.Empty;
                rtxt_AppraisalCycle.Text = string.Empty;
                rtxt_AppraisalCycle.Enabled = true;
                rcmb_feedback.Enabled = false;
                Rg_Appraisal_Kra.Visible = false;
                Rg_Appraisal_Goal.Visible = false;
                lbl_GoalAvgRtg.Visible = false;
                rnt_GoalAvgrtg.Visible = false;
                lbl_KraAvgRtg.Visible = false;
                rnt_KraAvgrtg.Visible = false;
                lblgoal.Visible = false;
                lblkra.Visible = false;
                rcmb_feedback.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsMgrAppraisal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadEmployees()
    {
        try
        {
            if ((Convert.ToString(Session["EMP_TYPE"])) == "5")
            {
                _obj_PMS_getemployee = new PMS_GETEMPLOYEE();
                _obj_PMS_getemployee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                _obj_PMS_getemployee.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtbuid = Pms_Bll.get_RMEmployees(_obj_PMS_getemployee);
                if (dtbuid.Rows.Count != 0)
                {

                    rtxt_RpMgr.Text = Convert.ToString(dtbuid.Rows[0]["REPORTINGMANAGER"]);
                    rtxt_GpMgr.Text = Convert.ToString(dtbuid.Rows[0]["approvalmgr"]);
                }
                rcmb_EmployeeType.Items.Clear();
                rcmb_EmployeeType.DataSource = dtbuid;
                rcmb_EmployeeType.DataTextField = "employee";
                rcmb_EmployeeType.DataValueField = "EMPID";
                rcmb_EmployeeType.DataBind();
                //rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                rcmb_BusinessUnitType.Visible = false;
                lbl_BusinessUnitName.Visible = false;
                rtxt_RpMgr.Enabled = false;
                rtxt_GpMgr.Enabled = false;

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
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                //where i am getting apprisal cycle 


                PMS_GoalSettings _obj_GS = new PMS_GoalSettings();
                _obj_GS.GS_MODE = 9;
                _obj_GS.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                _obj_GS.GS_APPRAISAL_CYCLE = Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
                _obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt1 = Pms_Bll.get_GS(_obj_GS);

                if (dt1.Rows.Count != 0)
                {
                    rtxt_Role.Text = Convert.ToString(dt1.Rows[0]["ROLE_NAMES"]);
                    rtxt_Project.Text = Convert.ToString(dt1.Rows[0]["PROJECT_NAME"]);
                    rtxt_AppraisalCycle.Text = Convert.ToString(dt1.Rows[0]["APPRCYCLE_NAME"]);
                    LBL_Appraise_Id.Text = Convert.ToString(dt1.Rows[0]["APPRCYCLE_ID"]);
                    rtxt_AppraisalCycle.Enabled = false;
                    rtxt_Role.Enabled = false;
                    rtxt_Project.Enabled = false;
                    rcmb_feedback.Enabled = true;


                }
                else
                {
                    rcmb_feedback.SelectedIndex = 0;
                }

            }
            else
            {
                _obj_pms_EmployeeSetup = new PMS_EMPSETUP();
                _obj_pms_EmployeeSetup.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);

                SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
                _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);

                DataTable dt_buu = new DataTable();
                dt_buu = BLL.get_Business_Units(_obj_smhr_logininfo);

                _obj_PMS_getemployee = new PMS_GETEMPLOYEE();
                _obj_PMS_getemployee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                if (dt_buu.Rows.Count != 0)
                {
                    _obj_PMS_getemployee.BU_ID = Convert.ToInt32(dt_buu.Rows[0]["BUSINESSUNIT_ID"]);
                }
                _obj_PMS_getemployee.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtbuid1 = new DataTable();
                dtbuid1 = Pms_Bll.get_RMEmployees(_obj_PMS_getemployee);
                //rcmb_EmployeeType.SelectedValue = Convert.ToString(dtbuid1.Rows[0]["employee"]);

                PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                _obj_Pms_Appraisalcycle.MODE = 8;
                if (dtbuid1.Rows.Count != 0)
                {
                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtbuid1.Rows[0]["BU_ID"]);
                }
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtappidzzR = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                PMS_EMPSETUP _obj_Pms_EmpSetup;
                _obj_Pms_EmpSetup = new PMS_EMPSETUP();
                _obj_Pms_EmpSetup.Mode = 9;
                if (dtbuid1.Rows.Count != 0)
                {
                    _obj_Pms_EmpSetup.BU_ID = Convert.ToInt32(dtbuid1.Rows[0]["BU_ID"]);
                }
                if (dtappidzzR.Rows.Count != 0)
                {
                    _obj_Pms_EmpSetup.EMP_SETUP_LASTMDFBY = Convert.ToInt32(dtappidzzR.Rows[0]["APPRCYCLE_ID"]);
                }
                _obj_Pms_EmpSetup.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);

                if (dt.Rows.Count != 0)
                {
                    rcmb_EmployeeType.DataSource = dt;
                    rcmb_EmployeeType.DataTextField = "EMPLOYEE_NAME";
                    rcmb_EmployeeType.DataValueField = "EMP_ID";
                    rcmb_EmployeeType.DataBind();
                    rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                    rcmb_BusinessUnitType.Visible = false;
                    lbl_BusinessUnitName.Visible = false;

                }
                else
                {
                    DataTable dt5 = new DataTable();

                    rcmb_EmployeeType.DataSource = dt5;
                    rcmb_EmployeeType.DataBind();
                    lbl_BusinessUnitName.Visible = false;
                    rcmb_BusinessUnitType.Visible = false;
                    rcmb_feedback.Enabled = false;

                }

                rtxt_RpMgr.Text = Convert.ToString(dtbuid1.Rows[0]["REPORTINGMANAGER"]);
                rtxt_GpMgr.Text = Convert.ToString(dtbuid1.Rows[0]["APPROVALMGR"]);


                rcmb_BusinessUnitType.Visible = false;
                lbl_BusinessUnitName.Visible = false;
                rtxt_RpMgr.Enabled = false;
                rtxt_GpMgr.Enabled = false;
                _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                _obj_Pms_Appraisalcycle.MODE = 11;
                _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtem = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                _obj_Pms_Appraisalcycle.MODE = 8;
                if (dtem.Rows.Count != 0)
                {
                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                }
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                //where i am getting apprisal cycle 


                PMS_GoalSettings _obj_GS = new PMS_GoalSettings();
                _obj_GS.GS_MODE = 9;
                _obj_GS.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                if (dtappid.Rows.Count != 0)
                {
                    _obj_GS.GS_APPRAISAL_CYCLE = Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
                }
                _obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt1 = Pms_Bll.get_GS(_obj_GS);

                if (dt1.Rows.Count != 0)
                {
                    rtxt_Role.Text = Convert.ToString(dt1.Rows[0]["ROLE_NAMES"]);
                    rtxt_Project.Text = Convert.ToString(dt1.Rows[0]["PROJECT_NAME"]);
                    rtxt_AppraisalCycle.Text = Convert.ToString(dt1.Rows[0]["APPRCYCLE_NAME"]);
                    LBL_Appraise_Id.Text = Convert.ToString(dt1.Rows[0]["APPRCYCLE_ID"]);
                    rtxt_AppraisalCycle.Enabled = false;
                    rtxt_Role.Enabled = false;
                    rtxt_Project.Enabled = false;
                    rcmb_feedback.Enabled = true;


                }
                else
                {
                    rcmb_feedback.SelectedIndex = 0;
                }
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsMgrAppraisal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void BindEmployees(DataTable dt)
    {
        try
        {
            rcmb_EmployeeType.Items.Clear();
            rcmb_EmployeeType.DataSource = dt;
            rcmb_EmployeeType.DataTextField = "EMPNAME";
            rcmb_EmployeeType.DataValueField = "EMP_ID";
            rcmb_EmployeeType.DataBind();
            rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsMgrAppraisal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion




    protected void rcmb_EmployeeType_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if ((rcmb_EmployeeType.SelectedItem.Text == "Select"))
            {


                Pms_Bll.ShowMessage(this, "Please Select Employee");
                rtxt_RpMgr.Enabled = true;
                rtxt_GpMgr.Enabled = true;
                rtxt_Role.Enabled = true;
                rtxt_Project.Enabled = true;
                rtxt_RpMgr.Text = String.Empty;
                rtxt_GpMgr.Text = string.Empty;
                rtxt_Role.Text = string.Empty;
                rtxt_Project.Text = string.Empty;
                rtxt_AppraisalCycle.Text = string.Empty;
                rtxt_AppraisalCycle.Enabled = true;
                rcmb_feedback.Enabled = false;
                Rg_Appraisal_Kra.Visible = false;
                Rg_Appraisal_Goal.Visible = false;
                lbl_GoalAvgRtg.Visible = false;
                rnt_GoalAvgrtg.Visible = false;
                lbl_KraAvgRtg.Visible = false;
                rnt_KraAvgrtg.Visible = false;
                lblgoal.Visible = false;
                lblkra.Visible = false;
                rcmb_feedback.SelectedIndex = 0;

            }
            else
            {
                PMS_EMPSETUP _obj_Pms_EmpSetup = new PMS_EMPSETUP();

                _obj_Pms_LoginInfo = new PMS_LOGININFO();

                _obj_Pms_LoginInfo.EMPID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);

                //DataTable dtbuid = Pms_Bll.get_LoginInfo(_obj_Pms_LoginInfo);




                //_obj_Pms_EmpSetup.BU_ID = 21;

                //_obj_Pms_EmpSetup.BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
                _obj_Pms_EmpSetup.EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                _obj_Pms_EmpSetup.Mode = 6;
                _obj_Pms_EmpSetup.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                DataTable DTREPO = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);
                if (DTREPO.Rows.Count != 0)
                {

                    rtxt_RpMgr.Text = Convert.ToString(DTREPO.Rows[0]["REPORTINGMGR_NAME"]);
                    rtxt_RpMgr.Enabled = false;
                    rcmb_feedback.SelectedIndex = 0;
                }

                else
                {
                    rcmb_feedback.SelectedIndex = 0;
                }

                _obj_Pms_EmpSetup = new PMS_EMPSETUP();



                SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
                _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);

                DataTable dt_bu = BLL.get_Business_Units(_obj_smhr_logininfo);
                if (dt_bu.Rows.Count != 0)
                {
                    _obj_Pms_EmpSetup.BU_ID = Convert.ToInt32(dt_bu.Rows[0]["BUSINESSUNIT_ID"]);
                }

                //_obj_Pms_EmpSetup.BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
                _obj_Pms_EmpSetup.EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                _obj_Pms_EmpSetup.Mode = 7;
                _obj_Pms_EmpSetup.EMP_SETUP_LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                DataTable DTgeneralmgr = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);
                if (DTgeneralmgr.Rows.Count != 0)
                {
                    rtxt_GpMgr.Text = Convert.ToString(DTgeneralmgr.Rows[0]["GENERALMGR_NAME"]);
                    rtxt_GpMgr.Enabled = false;
                    rcmb_feedback.SelectedIndex = 0;
                }



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
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                //where i am getting apprisal cycle 


                PMS_GoalSettings _obj_GS = new PMS_GoalSettings();
                _obj_GS.GS_MODE = 9;
                _obj_GS.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                _obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                if (dtappid.Rows.Count != 0)
                {
                    _obj_GS.GS_APPRAISAL_CYCLE = Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
                }
                DataTable dt1 = Pms_Bll.get_GS(_obj_GS);

                if (dt1.Rows.Count != 0)
                {
                    rtxt_Role.Text = Convert.ToString(dt1.Rows[0]["ROLE_NAMES"]);
                    rtxt_Project.Text = Convert.ToString(dt1.Rows[0]["PROJECT_NAME"]);
                    rtxt_AppraisalCycle.Text = Convert.ToString(dt1.Rows[0]["APPRCYCLE_NAME"]);
                    LBL_Appraise_Id.Text = Convert.ToString(dt1.Rows[0]["APPRCYCLE_ID"]);
                    rtxt_Role.Enabled = false;
                    rtxt_Project.Enabled = false;
                    rtxt_AppraisalCycle.Enabled = false;
                    rcmb_feedback.SelectedIndex = 0;

                }
                else
                {
                    rcmb_feedback.SelectedIndex = 0;
                }



                //LoadGrid();//which displays both,kra problem
                //LoadKraGrid();
                Session["empid"] = rcmb_EmployeeType.SelectedItem.Value;
                lnk_Idp.OnClientClick = " openRadWin('frm_idp.aspx'); return false;";



                Rg_Appraisal_Goal.Enabled = true;
                // btn_Cancel.Visible = true;
                lbl_KraAvgRtg.Visible = true;
                lbl_GoalAvgRtg.Visible = true;
                rnt_GoalAvgrtg.Visible = true;
                rnt_KraAvgrtg.Visible = true;
                rnt_KraAvgrtg.Enabled = false;

                Rg_Appraisal_Kra.Enabled = true;
                rnt_GoalAvgrtg.Value = null;
                lbl_KraAvgRtg.Enabled = true;
                rnt_KraAvgrtg.Value = null;
                //Rm_Appraisal_Goal.Enabled = true;
                Rg_Appraisal_Goal.Enabled = true;
                lbl_GoalAvgRtg.Enabled = true;
                rnt_GoalAvgrtg.Enabled = true;
                //Rm_AppraisalDiscussion.Visible = false;
                rcmb_feedback.Enabled = true;
                lbl_KraAvgRtg.Visible = false;
                rnt_KraAvgrtg.Visible = false;
                lbl_GoalAvgRtg.Visible = false;
                rnt_GoalAvgrtg.Visible = false;
                Rg_Appraisal_Kra.Visible = false;
                lblgoal.Visible = false;

                lblkra.Visible = false;
                Rg_Appraisal_Goal.Visible = false;
                _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                _obj_Pms_Appraisalcycle.MODE = 11;
                _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtemzz99 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                _obj_Pms_Appraisalcycle.MODE = 8;
                if (dtemzz99.Rows.Count != 0)
                {
                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz99.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                }
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtappidzz99 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);

                _obj_Spms_Appraisal.Mode = 5;
                if (dtappidzz99.Rows.Count != 0)
                {
                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz99.Rows[0]["APPRCYCLE_ID"]);
                }
                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtg = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

                _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtg.Rows[0]["APPRAISAL_ID"]);
                _obj_Spms_AppraisalGoal.Mode = 7;
                _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt14 = Pms_Bll.get_AppraisalGoal(_obj_Spms_AppraisalGoal);

                if (dt14.Rows.Count != 0)
                {
                    rnt_GoalAvgrtg.Value = Convert.ToDouble(dt14.Rows[0]["APP_GOALS_MGR_RATING"]);
                    rnt_GoalAvgrtg.Enabled = false;
                }
                else
                {
                    rnt_GoalAvgrtg.Value = 0;
                    rnt_GoalAvgrtg.Enabled = false;

                }

                //_obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                //_obj_Pms_Appraisalcycle.MODE = 11;
                //_obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                //DataTable dtemzz41 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                //_obj_Pms_Appraisalcycle.MODE = 8;
                //_obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz41.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                //DataTable dtappidzz41 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                //_obj_Spms_Appraisal = new SPMS_APPRAISAL();

                //_obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                //_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz41.Rows[0]["APPRCYCLE_ID"]);
                //_obj_Spms_Appraisal.Mode = 5;

                ////_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(LBL_Appraise_Id.Text);

                //DataTable dtg7 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                //_obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                //_obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtg7.Rows[0]["APPRAISAL_ID"]);
                //_obj_Spms_AppraisalKra.Mode = 7;
                //DataTable dt5 = Pms_Bll.get_AppraisalKra(_obj_Spms_AppraisalKra);
                //if (dt5.Rows.Count != 0)
                //{
                //    rnt_KraAvgrtg.Value = Convert.ToDouble(dt5.Rows[0]["APP_KRA_MGR_RATING"]);
                //}
                //else
                //{
                //    rnt_KraAvgrtg.Value = 0;
                //}
                double dou_GrantTotal = 0;
                for (int z = 0; z < Rg_Appraisal_Kra.Rows.Count; z++)
                {

                    Label lblkraweightage = new System.Web.UI.WebControls.Label();
                    RadRating rdrtg_KraMgr = new Telerik.Web.UI.RadRating();

                    rdrtg_KraMgr = Rg_Appraisal_Kra.Rows[z].FindControl("rdrtg_KraMgr") as RadRating;
                    lblkraweightage = Rg_Appraisal_Kra.Rows[z].FindControl("lbl_KrawEIGHTAGE") as Label;

                    int s = Convert.ToInt32(lblkraweightage.Text);
                    int w = Convert.ToInt32(rdrtg_KraMgr.Value);
                    double g = Convert.ToDouble((double)(s * w) / 100);
                    dou_GrantTotal = dou_GrantTotal + g;

                }

                rnt_KraAvgrtg.Value = dou_GrantTotal;

            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsMgrAppraisal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }






    #region Loadgoal,kraDetails



    /// <summary>
    /// Here i am loading grid based on emploee selecteion task grid will be displayed
    /// </summary>
    /// <param name="o"></param>
    /// <param name="e"></param>

    protected void rcmb_feedback_indexchanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if ((rcmb_feedback.SelectedItem.Text != "Select"))
            {
                if (rcmb_feedback.SelectedItem.Text == "GOAL")
                {
                    LoadGrid();
                    //LOADGOALmgrFINALIZE();
                    PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                    _obj_Pms_Appraisalcycle.MODE = 11;
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtemzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                    _obj_Pms_Appraisalcycle.MODE = 8;
                    if (dtemzz.Rows.Count != 0)
                    {
                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                    }
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtappidzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                    SPMS_APPRAISAL _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                    _obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE = 11;
                    if (dtappidzz.Rows.Count != 0)
                    {
                        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz.Rows[0]["APPRCYCLE_ID"]);
                    }
                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

                    _obj_Spms_Appraisal.Mode = 5;

                    DataTable dtgoal1 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                    if (dtgoal1.Rows.Count != 0)
                    {

                        SPMS_APPRAISALGOAL _obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();
                        _obj_Spms_AppraisalGoal.Mode = 14;
                        if (dtgoal1.Rows.Count != 0)
                        {

                            _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtgoal1.Rows[0]["APPRAISAL_ID"]);
                        }
                        _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dt9 = Pms_Bll.get_AppraisalGoal(_obj_Spms_AppraisalGoal);
                        if (dt9.Rows.Count != 0)
                        {
                            LOADGOALmgrFINALIZE();
                            btn_goalmgrfinalise.Visible = false;
                            Pms_Bll.ShowMessage(this, "Already Manager Feedback Finalised");
                            Rg_Appraisal_Kra.Visible = false;
                            lnk_Idp.Visible = false;
                            lblgoal.Visible = true;

                            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                            _obj_Pms_Appraisalcycle.MODE = 11;
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtemzz4 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                            _obj_Pms_Appraisalcycle.MODE = 8;
                            if (dtemzz4.Rows.Count != 0)
                            {
                                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz4.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                            }
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtappidzz4 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                            _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                            _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);

                            _obj_Spms_Appraisal.Mode = 5;
                            _obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE = 2;
                            if (dtappidzz4.Rows.Count != 0)
                            {
                                _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz4.Rows[0]["APPRCYCLE_ID"]);
                            }
                            _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtg = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

                            _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtg.Rows[0]["APPRAISAL_ID"]);
                            _obj_Spms_AppraisalGoal.Mode = 7;
                            _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dt1 = Pms_Bll.get_AppraisalGoal(_obj_Spms_AppraisalGoal);

                            rnt_GoalAvgrtg.Value = Convert.ToDouble(dt1.Rows[0]["APP_GOALS_MGR_RATING"]);
                            if (dt1.Rows.Count != 0)
                            {
                                rnt_GoalAvgrtg.Value = Convert.ToDouble(dt1.Rows[0]["APP_GOALS_MGR_RATING"]);
                                rnt_GoalAvgrtg.Enabled = false;
                            }
                            else
                            {
                                rnt_GoalAvgrtg.Value = 0;
                                rnt_GoalAvgrtg.Enabled = true;
                            }
                            lbl_GoalAvgRtg.Visible = true;
                            rnt_GoalAvgrtg.Visible = true;
                            return;
                        }
                        else
                        {
                            LOADGOALmgrFINALIZE();
                        }
                    }
                    else
                    {
                        LOADGOALmgrFINALIZE();
                    }

                    //_obj_Spms_Appraisal = new SPMS_APPRAISAL();
                    //_obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);




                    //_obj_Spms_Appraisal.Mode = 30;

                    //DataTable dtgoal9 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                    //if (Convert.ToInt32(dtgoal9.Rows[0]["APP_GOALS_FIXED"]) == 1)
                    //{

                    //    for (int i = 0; i <= Rg_Appraisal_Goal.Rows.Count - 1; i++)
                    //    {

                    //        TextBox txtmgrfeed = new System.Web.UI.WebControls.TextBox();
                    //        Button btnsubmitmgrfeed = new System.Web.UI.WebControls.Button();
                    //        Button btncancelmgrfeed = new System.Web.UI.WebControls.Button();
                    //        RadRating rdratingmgr = new Telerik.Web.UI.RadRating();
                    //        txtmgrfeed = Rg_Appraisal_Goal.Rows[i].FindControl("txt_GoalManagerFeedback") as TextBox;
                    //        btnsubmitmgrfeed = Rg_Appraisal_Goal.Rows[i].FindControl("btn_GoalMgrSubmit") as Button;
                    //        btncancelmgrfeed = Rg_Appraisal_Goal.Rows[i].FindControl("btn_GoalMgrCancel") as Button;
                    //        rdratingmgr = Rg_Appraisal_Goal.Rows[i].FindControl("rdrtg_GoalMgr") as RadRating;
                    //        txtmgrfeed.Enabled = false;
                    //        btnsubmitmgrfeed.Visible = false;
                    //        btncancelmgrfeed.Visible = false;
                    //        rdratingmgr.Enabled = false;

                    //    }
                    //}
                    //else
                    //{
                    //    for (int i = 0; i <= Rg_Appraisal_Goal.Rows.Count - 1; i++)
                    //    {

                    //        TextBox txtmgrfeed = new System.Web.UI.WebControls.TextBox();
                    //        Button btnsubmitmgrfeed = new System.Web.UI.WebControls.Button();
                    //        Button btncancelmgrfeed = new System.Web.UI.WebControls.Button();
                    //        RadRating rdratingmgr = new Telerik.Web.UI.RadRating();
                    //        txtmgrfeed = Rg_Appraisal_Goal.Rows[i].FindControl("txt_GoalManagerFeedback") as TextBox;
                    //        btnsubmitmgrfeed = Rg_Appraisal_Goal.Rows[i].FindControl("btn_GoalMgrSubmit") as Button;
                    //        btncancelmgrfeed = Rg_Appraisal_Goal.Rows[i].FindControl("btn_GoalMgrCancel") as Button;
                    //        rdratingmgr = Rg_Appraisal_Goal.Rows[i].FindControl("rdrtg_GoalMgr") as RadRating;
                    //        txtmgrfeed.Enabled = true;
                    //        btnsubmitmgrfeed.Visible = true;
                    //        btncancelmgrfeed.Visible = true;
                    //        rdratingmgr.Enabled = true;
                    //    }

                    //}
                    lblgoal.Visible = true;
                    lblkra.Visible = false;
                    Rg_Appraisal_Kra.Visible = false;
                    lbl_GoalAvgRtg.Visible = true;
                    rnt_GoalAvgrtg.Visible = true;
                    lbl_KraAvgRtg.Visible = false;
                    rnt_KraAvgrtg.Visible = false;
                    lnk_Idp.Visible = false;
                    Rm_Appraisal_PAGE.SelectedIndex = 0;
                    Rm_Appraisal_GOALKRA.SelectedIndex = 0;


                }

                else if (rcmb_feedback.SelectedItem.Text == "KRA")
                {
                    LoadKraGrid();

                    PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                    _obj_Pms_Appraisalcycle.MODE = 11;
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtemzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                    _obj_Pms_Appraisalcycle.MODE = 8;
                    if (dtemzz.Rows.Count != 0)
                    {
                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                    }
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtappidzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                    SPMS_APPRAISAL _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                    if (dtappidzz.Rows.Count != 0)
                    {
                        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz.Rows[0]["APPRCYCLE_ID"]);
                    }

                    _obj_Spms_Appraisal.Mode = 5;
                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtgoal1 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                    if (dtgoal1.Rows.Count != 0)
                    {

                        SPMS_APPRAISALKRA _obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                        _obj_Spms_AppraisalKra.Mode = 14;
                        _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtgoal1.Rows[0]["APPRAISAL_ID"]);
                        _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dt9 = Pms_Bll.get_AppraisalKra(_obj_Spms_AppraisalKra);
                        if (dt9.Rows.Count != 0)
                        {
                            LOADKRAmgrFINALIZE();
                            btn_kramgrfinalise.Visible = false;
                            Pms_Bll.ShowMessage(this, "Already Manager Feedback Finalised");
                            Rm_Appraisal_PAGE.SelectedIndex = 0;
                            lnk_Idp.Visible = false;
                            lbl_KraAvgRtg.Visible = true;
                            rnt_KraAvgrtg.Visible = true;
                            Rg_Appraisal_Kra.Visible = true;

                            //_obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                            //  _obj_Pms_Appraisalcycle.MODE = 11;
                            //  _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                            //  DataTable dtemzz41 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                            //  _obj_Pms_Appraisalcycle.MODE = 8;
                            //  _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz41.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                            //  DataTable dtappidzz41 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                            //  _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                            //  _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);

                            //  _obj_Spms_Appraisal.Mode = 5;
                            //  _obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE = 2;
                            //  _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz41.Rows[0]["APPRCYCLE_ID"]);

                            //  DataTable dtg = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                            //  _obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                            //  _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtg.Rows[0]["APPRAISAL_ID"]);
                            //  _obj_Spms_AppraisalKra.Mode = 7;
                            //  DataTable dt5 = Pms_Bll.get_AppraisalKra(_obj_Spms_AppraisalKra);
                            //  rnt_KraAvgrtg.Value = Convert.ToDouble(dt5.Rows[0]["APP_KRA_MGR_RATING"]);
                            //  if (dt5.Rows.Count != 0)
                            //  {
                            //      rnt_KraAvgrtg.Value = Convert.ToDouble(dt5.Rows[0]["APP_KRA_MGR_RATING"]);
                            //      rnt_KraAvgrtg.Enabled = false;
                            //  }
                            //  else
                            //  {
                            //      rnt_KraAvgrtg.Value = 0;
                            //      rnt_KraAvgrtg.Enabled = true;
                            //  }
                            double dou_GrantTotal = 0;
                            for (int z = 0; z < Rg_Appraisal_Kra.Rows.Count; z++)
                            {
                                Label lblkraweightage = new System.Web.UI.WebControls.Label();
                                RadRating rdrtg_KraMgr = new Telerik.Web.UI.RadRating();

                                rdrtg_KraMgr = Rg_Appraisal_Kra.Rows[z].FindControl("rdrtg_KraMgr") as RadRating;
                                lblkraweightage = Rg_Appraisal_Kra.Rows[z].FindControl("lbl_KrawEIGHTAGE") as Label;

                                int s = Convert.ToInt32(lblkraweightage.Text);
                                int w = Convert.ToInt32(rdrtg_KraMgr.Value);
                                double g = Convert.ToDouble((double)(s * w) / 100);
                                dou_GrantTotal = dou_GrantTotal + g;

                            }

                            rnt_KraAvgrtg.Value = dou_GrantTotal;
                            lblkra.Visible = true;
                            return;
                        }
                        else
                        {
                            LOADKRAmgrFINALIZE();
                            LNK_IDP22.Visible = false;
                            double dou_GrantTotal = 0;
                            for (int z = 0; z < Rg_Appraisal_Kra.Rows.Count; z++)
                            {
                                Label lblkraweightage = new System.Web.UI.WebControls.Label();
                                RadRating rdrtg_KraMgr = new Telerik.Web.UI.RadRating();

                                rdrtg_KraMgr = Rg_Appraisal_Kra.Rows[z].FindControl("rdrtg_KraMgr") as RadRating;
                                lblkraweightage = Rg_Appraisal_Kra.Rows[z].FindControl("lbl_KrawEIGHTAGE") as Label;

                                int s = Convert.ToInt32(lblkraweightage.Text);
                                int w = Convert.ToInt32(rdrtg_KraMgr.Value);
                                double g = Convert.ToDouble((double)(s * w) / 100);
                                dou_GrantTotal = dou_GrantTotal + g;

                            }

                            rnt_KraAvgrtg.Value = dou_GrantTotal;
                        }
                    }
                    else
                    {
                        LOADKRAmgrFINALIZE();
                        LNK_IDP22.Visible = false;
                        double dou_GrantTotal = 0;
                        for (int z = 0; z < Rg_Appraisal_Kra.Rows.Count; z++)
                        {
                            Label lblkraweightage = new System.Web.UI.WebControls.Label();
                            RadRating rdrtg_KraMgr = new Telerik.Web.UI.RadRating();

                            rdrtg_KraMgr = Rg_Appraisal_Kra.Rows[z].FindControl("rdrtg_KraMgr") as RadRating;
                            lblkraweightage = Rg_Appraisal_Kra.Rows[z].FindControl("lbl_KrawEIGHTAGE") as Label;

                            int s = Convert.ToInt32(lblkraweightage.Text);
                            int w = Convert.ToInt32(rdrtg_KraMgr.Value);
                            double g = Convert.ToDouble((double)(s * w) / 100);
                            dou_GrantTotal = dou_GrantTotal + g;

                        }

                        rnt_KraAvgrtg.Value = dou_GrantTotal;
                    }
                    //LOADKRAmgrFINALIZE();

                    lblgoal.Visible = false;
                    lblkra.Visible = true;

                    lbl_KraAvgRtg.Visible = true;
                    rnt_KraAvgrtg.Visible = true;
                    lbl_GoalAvgRtg.Visible = false;
                    rnt_GoalAvgrtg.Visible = false;
                    Rm_Appraisal_PAGE.SelectedIndex = 0;
                    Rm_Appraisal_GOALKRA.SelectedIndex = 1;


                }


            }
            else
            {
                Pms_Bll.ShowMessage(this, "Please Select Feedback");
                Rg_Appraisal_Goal.Visible = false;
                Rg_Appraisal_Kra.Visible = false;
                lbl_GoalAvgRtg.Visible = false;
                rnt_GoalAvgrtg.Visible = false;
                lbl_KraAvgRtg.Visible = false;
                rnt_KraAvgrtg.Visible = false;
                lblgoal.Visible = false;
                lblkra.Visible = false;
                return;
            }
            rdtp_DATEofAppraisal.SelectedDate = DateTime.Now;
            rdtp_DATEofAppraisal.Enabled = false;

            lnk_Idp.Visible = false;
            Rg_Appraisal_Kra.Visible = true;
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsMgrAppraisal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }



    #endregion


    #region Rg_Appraisal Goal commands

    protected void Rg_Appraisal_Goal_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            Label lblgsdt_id = new System.Web.UI.WebControls.Label();


            Label lblappraisaldtl = new System.Web.UI.WebControls.Label();
            int i = Convert.ToInt32(e.CommandArgument);

            lblgsdt_id = Rg_Appraisal_Goal.Rows[i].FindControl("lbl_Goal_Id") as Label;
            lblappraisaldtl = Rg_Appraisal_Goal.Rows[i].FindControl("lbl_Goal_AppraisalCycle") as Label;
            TextBox txtempfeed = new System.Web.UI.WebControls.TextBox();
            Button btnsubmitempfeed = new System.Web.UI.WebControls.Button();
            Button btncancelempfeed = new System.Web.UI.WebControls.Button();
            txtempfeed = Rg_Appraisal_Goal.Rows[i].FindControl("txt_GoalEmployeeFeedback") as TextBox;
            btnsubmitempfeed = Rg_Appraisal_Goal.Rows[i].FindControl("btn_GoalEmpSubmit") as Button;
            btncancelempfeed = Rg_Appraisal_Goal.Rows[i].FindControl("btn_GoalEmpCancel") as Button;


            TextBox txtmgrfeed = new System.Web.UI.WebControls.TextBox();
            Button btnsubmitmgrfeed = new System.Web.UI.WebControls.Button();
            Button btngoalmgrfeedupdate = new System.Web.UI.WebControls.Button();
            Button btncancelmgrfeed = new System.Web.UI.WebControls.Button();
            RadRating rdratingmgr = new Telerik.Web.UI.RadRating();

            txtmgrfeed = Rg_Appraisal_Goal.Rows[i].FindControl("txt_GoalManagerFeedback") as TextBox;
            btnsubmitmgrfeed = Rg_Appraisal_Goal.Rows[i].FindControl("btn_GoalMgrSubmit") as Button;
            btncancelmgrfeed = Rg_Appraisal_Goal.Rows[i].FindControl("btn_GoalMgrCancel") as Button;
            rdratingmgr = Rg_Appraisal_Goal.Rows[i].FindControl("rdrtg_GoalMgr") as RadRating;
            btngoalmgrfeedupdate = Rg_Appraisal_Goal.Rows[i].FindControl("btn_GoalMgrupdate") as Button;
            #region Employee Feedback


            if (e.CommandName == "GoalEmployee_Feed")
            {


                PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                _obj_Pms_Appraisalcycle.MODE = 11;
                _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtemzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                _obj_Pms_Appraisalcycle.MODE = 8;
                if (dtemzz.Rows.Count != 0)
                {
                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                }
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);

                DataTable dtappidzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                _obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();

                _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(lblgsdt_id.Text);
                _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = 0;
                _obj_Spms_AppraisalGoal.APP_GOALS_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                _obj_Spms_AppraisalGoal.Mode = 5;
                _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                if (dtappidzz.Rows.Count != 0)
                {
                    _obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFBY = Convert.ToInt32(dtappidzz.Rows[0]["APPRCYCLE_ID"]);
                }
                DataTable dtgoal = Pms_Bll.get_AppraisalGoal(_obj_Spms_AppraisalGoal);

                if (dtgoal.Rows.Count != 0)
                {
                    txtempfeed.Text = Convert.ToString(dtgoal.Rows[0]["APP_GOALS_EMP_COMMENTS"]);
                    //btnsubmitempfeed.Text = "Update";
                    if (txtempfeed.Visible == true)
                    {

                        txtempfeed.Visible = false;

                        //btnsubmitempfeed.Visible = false;
                        //btncancelempfeed.Visible = false;
                    }
                    else
                    {

                        txtempfeed.Visible = true;
                        txtempfeed.Enabled = false;
                        //btnsubmitempfeed.Visible = true;
                        //btncancelempfeed.Visible = true;
                    }
                }
                else
                {

                    if (txtempfeed.Visible == true)
                    {

                        txtempfeed.Visible = false;

                        //btnsubmitempfeed.Visible = false;
                        //btncancelempfeed.Visible = false;
                    }
                    else
                    {

                        txtempfeed.Visible = true;
                        txtempfeed.Enabled = false;
                        //btnsubmitempfeed.Visible = true;
                        //btncancelempfeed.Visible = true;
                    }



                }
            }
            #endregion


            #region Manager Feedback
            else if (e.CommandName == "GoalMgr_Feed")
            {

                PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                _obj_Pms_Appraisalcycle.MODE = 11;
                _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);

                DataTable dtemzQ = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                _obj_Pms_Appraisalcycle.MODE = 8;
                if (dtemzQ.Rows.Count != 0)
                {
                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzQ.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                }
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtappidzQ = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                if (dtappidzQ.Rows.Count != 0)
                {
                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzQ.Rows[0]["APPRCYCLE_ID"]);
                }
                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

                _obj_Spms_Appraisal.Mode = 30;
                //(Convert.ToInt32(dtgoal9.Rows[0]["APP_GOALS_FIXED"]) == 1) ||
                DataTable dtgoal9 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                if (dtgoal9.Rows[0]["APP_GOALS_FIXED"] == System.DBNull.Value)
                {
                    _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                    _obj_Pms_Appraisalcycle.MODE = 11;
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtemzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                    _obj_Pms_Appraisalcycle.MODE = 8;
                    if (dtemzz.Rows.Count != 0)
                    {
                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                    }
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtappidzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                    _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);

                    _obj_Spms_Appraisal.Mode = 5;
                    _obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE = 2;
                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    if (dtappidzz.Rows.Count != 0)
                    {
                        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz.Rows[0]["APPRCYCLE_ID"]);
                    }
                    DataTable dtg = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                    if (dtg.Rows.Count != 0)
                    {
                        _obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();
                        _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtg.Rows[0]["APPRAISAL_ID"]);

                        _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(lblgsdt_id.Text);
                        _obj_Spms_AppraisalGoal.Mode = 8;
                        DataTable dtgoal = Pms_Bll.get_AppraisalGoal(_obj_Spms_AppraisalGoal);

                        if (dtgoal.Rows.Count != 0)
                        {
                            if ((dtgoal.Rows[0]["APP_GOALS_MGR_COMMENTS"]) != string.Empty)
                            {
                                txtmgrfeed.Text = Convert.ToString(dtgoal.Rows[0]["APP_GOALS_MGR_COMMENTS"]);
                                //rdrtgKraMgr.Value = Convert.ToDouble(dtKra1.Rows[0]["APP_KRA_MGR_RATING"]);
                                //btnKraMgrSubmit.Text = "Update";

                                txtmgrfeed.Enabled = true;
                                rdratingmgr.Enabled = true;
                                if (txtmgrfeed.Visible == true)
                                {

                                    rdratingmgr.Visible = false;
                                    txtmgrfeed.Visible = false;

                                    btnsubmitmgrfeed.Visible = false;
                                    btncancelmgrfeed.Visible = false;
                                    btngoalmgrfeedupdate.Visible = false;
                                }
                                else
                                {

                                    rdratingmgr.Visible = true;
                                    txtmgrfeed.Visible = true;
                                    btnsubmitmgrfeed.Visible = false;
                                    btncancelmgrfeed.Visible = true;
                                    btngoalmgrfeedupdate.Visible = true;


                                }
                            }
                            else
                            {
                                if (txtmgrfeed.Visible == true)
                                {
                                    rdratingmgr.Visible = false;
                                    txtmgrfeed.Visible = false;
                                    btnsubmitmgrfeed.Visible = false;
                                    btncancelmgrfeed.Visible = false;
                                    btngoalmgrfeedupdate.Visible = false;
                                }
                                else
                                {
                                    rdratingmgr.Visible = true;
                                    txtmgrfeed.Visible = true;
                                    txtmgrfeed.Enabled = true;
                                    btnsubmitmgrfeed.Visible = true;
                                    btncancelmgrfeed.Visible = true;
                                    btngoalmgrfeedupdate.Visible = false;

                                }
                            }

                        }
                        else
                        {
                            if (txtmgrfeed.Visible == true)
                            {
                                rdratingmgr.Visible = false;
                                txtmgrfeed.Visible = false;
                                btnsubmitmgrfeed.Visible = false;
                                btncancelmgrfeed.Visible = false;
                                btngoalmgrfeedupdate.Visible = false;
                            }
                            else
                            {

                                rdratingmgr.Visible = true;
                                txtmgrfeed.Visible = true;
                                txtmgrfeed.Enabled = true;
                                btnsubmitmgrfeed.Visible = true;
                                btncancelmgrfeed.Visible = true;
                                btngoalmgrfeedupdate.Visible = false;

                            }

                        }


                    }

                }
                else
                {
                    if ((Convert.ToInt32(dtgoal9.Rows[0]["APP_GOALS_FIXED"]) == 2))
                    {
                        for (int l = 0; l <= Rg_Appraisal_Goal.Rows.Count - 1; l++)
                        {

                            TextBox txtmgrfeed1 = new System.Web.UI.WebControls.TextBox();
                            Button btnsubmitmgrfeed1 = new System.Web.UI.WebControls.Button();
                            Button btncancelmgrfeed1 = new System.Web.UI.WebControls.Button();
                            RadRating rdratingmgr1 = new Telerik.Web.UI.RadRating();
                            txtmgrfeed1 = Rg_Appraisal_Goal.Rows[l].FindControl("txt_GoalManagerFeedback") as TextBox;
                            btnsubmitmgrfeed1 = Rg_Appraisal_Goal.Rows[l].FindControl("btn_GoalMgrSubmit") as Button;
                            btncancelmgrfeed1 = Rg_Appraisal_Goal.Rows[l].FindControl("btn_GoalMgrCancel") as Button;
                            rdratingmgr1 = Rg_Appraisal_Goal.Rows[l].FindControl("rdrtg_GoalMgr") as RadRating;
                            if (txtmgrfeed1.Visible == false)
                            {
                                txtmgrfeed1.Visible = true;
                                txtmgrfeed1.Enabled = false;
                                btnsubmitmgrfeed1.Visible = false;
                                btncancelmgrfeed1.Visible = false;
                                rdratingmgr1.Enabled = false;
                                rdratingmgr1.Visible = true;
                            }

                            else
                            {
                                txtmgrfeed1.Visible = false;
                                txtmgrfeed1.Enabled = false;
                                btnsubmitmgrfeed1.Visible = false;
                                btncancelmgrfeed1.Visible = false;
                                rdratingmgr1.Enabled = false;
                                rdratingmgr1.Visible = false;
                            }


                        }
                    }
                    else if ((Convert.ToInt32(dtgoal9.Rows[0]["APP_GOALS_FIXED"]) == 1))
                    {
                        _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                        _obj_Pms_Appraisalcycle.MODE = 11;
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtemzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                        _obj_Pms_Appraisalcycle.MODE = 8;
                        if (dtemzz.Rows.Count != 0)
                        {
                            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                        }
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtappidzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                        _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                        _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);

                        _obj_Spms_Appraisal.Mode = 5;
                        _obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE = 2;
                        if (dtappidzz.Rows.Count != 0)
                        {
                            _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz.Rows[0]["APPRCYCLE_ID"]);
                        }
                        _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtg = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                        if (dtg.Rows.Count != 0)
                        {
                            _obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();
                            _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtg.Rows[0]["APPRAISAL_ID"]);

                            _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(lblgsdt_id.Text);
                            _obj_Spms_AppraisalGoal.Mode = 8;
                            DataTable dtgoal = Pms_Bll.get_AppraisalGoal(_obj_Spms_AppraisalGoal);

                            if (dtgoal.Rows.Count != 0)
                            {
                                if ((dtgoal.Rows[0]["APP_GOALS_MGR_COMMENTS"]) != string.Empty)
                                {
                                    txtmgrfeed.Text = Convert.ToString(dtgoal.Rows[0]["APP_GOALS_MGR_COMMENTS"]);
                                    //rdrtgKraMgr.Value = Convert.ToDouble(dtKra1.Rows[0]["APP_KRA_MGR_RATING"]);
                                    //btnKraMgrSubmit.Text = "Update";

                                    txtmgrfeed.Enabled = true;
                                    rdratingmgr.Enabled = true;
                                    if (txtmgrfeed.Visible == true)
                                    {

                                        rdratingmgr.Visible = false;
                                        txtmgrfeed.Visible = false;

                                        btnsubmitmgrfeed.Visible = false;
                                        btncancelmgrfeed.Visible = false;
                                        btngoalmgrfeedupdate.Visible = false;
                                    }
                                    else
                                    {

                                        rdratingmgr.Visible = true;
                                        txtmgrfeed.Visible = true;
                                        btnsubmitmgrfeed.Visible = false;
                                        btncancelmgrfeed.Visible = true;
                                        btngoalmgrfeedupdate.Visible = true;


                                    }
                                }
                                else
                                {
                                    if (txtmgrfeed.Visible == true)
                                    {
                                        rdratingmgr.Visible = false;
                                        txtmgrfeed.Visible = false;
                                        btnsubmitmgrfeed.Visible = false;
                                        btncancelmgrfeed.Visible = false;
                                        btngoalmgrfeedupdate.Visible = false;
                                    }
                                    else
                                    {
                                        rdratingmgr.Visible = true;
                                        txtmgrfeed.Visible = true;
                                        txtmgrfeed.Enabled = true;
                                        btnsubmitmgrfeed.Visible = true;
                                        btncancelmgrfeed.Visible = true;
                                        btngoalmgrfeedupdate.Visible = false;

                                    }
                                }

                            }
                            else
                            {
                                if (txtmgrfeed.Visible == true)
                                {
                                    rdratingmgr.Visible = false;
                                    txtmgrfeed.Visible = false;
                                    btnsubmitmgrfeed.Visible = false;
                                    btncancelmgrfeed.Visible = false;
                                    btngoalmgrfeedupdate.Visible = false;
                                }
                                else
                                {

                                    rdratingmgr.Visible = true;
                                    txtmgrfeed.Visible = true;
                                    txtmgrfeed.Enabled = true;
                                    btnsubmitmgrfeed.Visible = true;
                                    btncancelmgrfeed.Visible = true;
                                    btngoalmgrfeedupdate.Visible = false;

                                }

                            }


                        }

                    }

                }


            }



            #endregion

            #region Employee Cancel

            else if (e.CommandName == "btn_GoalEmpCancel")
            {


                if (txtempfeed.Visible == true)
                {

                    txtempfeed.Visible = false;

                    btnsubmitempfeed.Visible = false;
                    btncancelempfeed.Visible = false;
                }
                else
                {

                    txtempfeed.Visible = true;

                    btnsubmitempfeed.Visible = true;
                    btncancelempfeed.Visible = true;
                }
            }
            #endregion


            #region Manager Cancel

            else if (e.CommandName == "btn_GoalMgrCancel")
            {

                if (txtmgrfeed.Visible == true)
                {

                    rdratingmgr.Visible = false;
                    txtmgrfeed.Visible = false;
                    btnsubmitmgrfeed.Visible = false;
                    btncancelmgrfeed.Visible = false;
                    btngoalmgrfeedupdate.Visible = false;
                }
                else
                {

                    rdratingmgr.Visible = true;
                    txtmgrfeed.Visible = true;

                    btnsubmitmgrfeed.Visible = true;
                    btncancelmgrfeed.Visible = true;
                }

            }

            #endregion

            #region Manager  Submit
            else if (e.CommandName == "btn_GoalMgrSubmit")
            {

                string q = txtmgrfeed.Text;
                int l = Convert.ToInt32(rdratingmgr.Value);
                if ((l > 0))
                {
                    if ((q.Length >= 10))
                    {

                        PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                        _obj_Pms_Appraisalcycle.MODE = 11;
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtemzzB = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                        _obj_Pms_Appraisalcycle.MODE = 8;
                        if (dtemzzB.Rows.Count != 0)
                        {
                            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzzB.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                        }
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtappidzzB = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);



                        _obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();

                        _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(lblgsdt_id.Text);
                        _obj_Spms_AppraisalGoal.APP_GOALS_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                        _obj_Spms_AppraisalGoal.Mode = 5;
                        if (dtappidzzB.Rows.Count != 0)
                        {
                            _obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFBY = Convert.ToInt32(dtappidzzB.Rows[0]["APPRCYCLE_ID"]);
                        }
                        _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtgoal = Pms_Bll.get_AppraisalGoal(_obj_Spms_AppraisalGoal);
                        if (dtgoal.Rows.Count != 0)
                        {
                            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                            _obj_Pms_Appraisalcycle.MODE = 11;
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtemzz01 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                            _obj_Pms_Appraisalcycle.MODE = 8;
                            if (dtemzz01.Rows.Count != 0)
                            {
                                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz01.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                            }
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtappidzz01 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                            _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                            _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                            _obj_Spms_Appraisal.Mode = 27;
                            if (dtappidzz01.Rows.Count != 0)
                            {
                                _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz01.Rows[0]["APPRCYCLE_ID"]);
                            }
                            _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtemp = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                            if (dtemp.Rows.Count != 0)
                            {
                                _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                                _obj_Pms_Appraisalcycle.MODE = 11;
                                _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dtemzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                _obj_Pms_Appraisalcycle.MODE = 8;
                                if (dtemzz.Rows.Count != 0)
                                {
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                                }
                                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dtappidzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                                _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                                _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                if (dtappidzz.Rows.Count != 0)
                                {
                                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz.Rows[0]["APPRCYCLE_ID"]);
                                }
                                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

                                _obj_Spms_Appraisal.Mode = 5;

                                DataTable dtgoal1 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                                _obj_Spms_AppraisalGoal.Mode = 11;
                                _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(lblgsdt_id.Text);
                                DataTable dtgoal_id = Pms_Bll.get_AppraisalGoal(_obj_Spms_AppraisalGoal);

                                _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtgoal1.Rows[0]["APPRAISAL_ID"]);
                                _obj_Spms_AppraisalGoal.Mode = 15;
                                _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(lblgsdt_id.Text);
                                _obj_Spms_AppraisalGoal.APP_GOALS_EMP_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(txtempfeed.Text));
                                _obj_Spms_AppraisalGoal.APP_GOALS_MGR_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(txtmgrfeed.Text));
                                _obj_Spms_AppraisalGoal.APP_GOALS_MGR_RATING = Convert.ToDecimal(rdratingmgr.Value);
                                //_obj_Spms_AppraisalGoal.APP_GOALS_FIXED=Convert.ToString(1);
                                _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                bool status1 = Pms_Bll.set_AppraisalGoal(_obj_Spms_AppraisalGoal);



                                _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                                _obj_Pms_Appraisalcycle.MODE = 11;
                                _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dtemzz43 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                _obj_Pms_Appraisalcycle.MODE = 8;
                                if (dtemzz43.Rows.Count != 0)
                                {
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz43.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                                }
                                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dtappidzz43 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);



                                _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                if (dtappidzz43.Rows.Count != 0)
                                {
                                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz43.Rows[0]["APPRCYCLE_ID"]);

                                }
                                _obj_Spms_Appraisal.Mode = 5;
                                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dtgoal4 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

                                _obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();
                                if (dtgoal4.Rows.Count != 0)
                                {
                                    _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtgoal4.Rows[0]["APPRAISAL_ID"]);
                                }
                                _obj_Spms_AppraisalGoal.APP_GOALS_FIXED = Convert.ToString(1);
                                _obj_Spms_AppraisalGoal.Mode = 16;

                                bool status10 = Pms_Bll.set_AppraisalGoal(_obj_Spms_AppraisalGoal);

                                if (status1 == true)
                                {
                                    Pms_Bll.ShowMessage(this, "Manager Feedback Inserted Successfully");

                                    _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                                    _obj_Pms_Appraisalcycle.MODE = 11;
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                    DataTable dtem = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                    _obj_Pms_Appraisalcycle.MODE = 8;
                                    if (dtem.Rows.Count != 0)
                                    {
                                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                                    }
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                    DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                                    _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
                                    _obj_Pms_EmpGoalSetting.Mode = 8;

                                    _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                                    _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                    if (dtappid.Rows.Count != 0)
                                    {
                                        _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
                                    }
                                    DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
                                    if (dt.Rows.Count != 0)
                                    {
                                        GSID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
                                    }
                                    PMS_GoalSettings_Details _obj_GSdetails = new PMS_GoalSettings_Details();
                                    _obj_GSdetails.GSDTL_GS_ID = GSID;
                                    _obj_GSdetails.GS_DETAILS_MODE = 5;
                                    _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                                    DataTable dt_details = new DataTable();
                                    dt_details = Pms_Bll.get_GSdetails(_obj_GSdetails);
                                    if (dt_details.Rows.Count != 0)
                                    {
                                        Rg_Appraisal_Goal.DataSource = dt_details;
                                        Rg_Appraisal_Goal.DataBind();
                                    }

                                    //LoadKraGrid();

                                    _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                                    _obj_Pms_Appraisalcycle.MODE = 11;
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                    DataTable dtemzz44 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                    _obj_Pms_Appraisalcycle.MODE = 8;
                                    if (dtemzz44.Rows.Count != 0)
                                    {
                                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz44.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                                    }
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                    DataTable dtappidzz44 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                    _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);

                                    _obj_Spms_Appraisal.Mode = 5;
                                    if (dtappidzz44.Rows.Count != 0)
                                    {
                                        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz44.Rows[0]["APPRCYCLE_ID"]);
                                    }
                                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                    DataTable dtg = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

                                    _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtg.Rows[0]["APPRAISAL_ID"]);
                                    _obj_Spms_AppraisalGoal.Mode = 7;
                                    _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                    DataTable dt1 = Pms_Bll.get_AppraisalGoal(_obj_Spms_AppraisalGoal);
                                    if (dt1.Rows.Count != 0)
                                    {
                                        rnt_GoalAvgrtg.Value = Convert.ToDouble(dt1.Rows[0]["APP_GOALS_MGR_RATING"]);
                                    }
                                    LoadGrid();
                                    LOADGOALmgrFINALIZE();
                                    Rm_Appraisal_PAGE.SelectedIndex = 0;
                                    rnt_GoalAvgrtg.Enabled = false;
                                    Rp_Appraisal_VIEWDETAILS.Visible = true;
                                    Rg_Appraisal_Goal.Visible = true;

                                    return;
                                }
                            }
                            else
                            {

                                _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                                _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                _obj_Spms_Appraisal.APPRAISAL_DATE = rdtp_DATEofAppraisal.SelectedDate.Value;
                                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                _obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE = 2;
                                _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(LBL_Appraise_Id.Text);
                                _obj_Spms_Appraisal.APPRAISAL_CREATEDBY = Convert.ToInt32(Session["user_id"]);
                                _obj_Spms_Appraisal.APPRAISAL_CREATEDDATE = DateTime.Now;

                                _obj_Spms_Appraisal.Mode = 4;
                                bool status = Pms_Bll.set_Appraisal(_obj_Spms_Appraisal);
                                if (status == true)
                                {
                                    _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                                    _obj_Pms_Appraisalcycle.MODE = 11;
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                    DataTable dtemzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                    _obj_Pms_Appraisalcycle.MODE = 8;
                                    if (dtemzz.Rows.Count != 0)
                                    {
                                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                                    }
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                    DataTable dtappidzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                    _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                    if (dtappidzz.Rows.Count != 0)
                                    {
                                        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz.Rows[0]["APPRCYCLE_ID"]);
                                    }
                                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

                                    _obj_Spms_Appraisal.Mode = 5;

                                    DataTable dtgoal1 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                                    //changes
                                    if (dtgoal1.Rows.Count != 0)
                                    {
                                        _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtgoal1.Rows[0]["APPRAISAL_ID"]);
                                    }
                                    _obj_Spms_AppraisalGoal.Mode = 15;
                                    _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(lblgsdt_id.Text);
                                    _obj_Spms_AppraisalGoal.APP_GOALS_EMP_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(txtempfeed.Text));
                                    _obj_Spms_AppraisalGoal.APP_GOALS_MGR_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(txtmgrfeed.Text));
                                    _obj_Spms_AppraisalGoal.APP_GOALS_MGR_RATING = Convert.ToDecimal(rdratingmgr.Value);
                                    _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);

                                    bool status1 = Pms_Bll.set_AppraisalGoal(_obj_Spms_AppraisalGoal);
                                    _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                                    _obj_Pms_Appraisalcycle.MODE = 11;
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                    DataTable dtemzz46 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                    _obj_Pms_Appraisalcycle.MODE = 8;
                                    if (dtemzz.Rows.Count != 0)
                                    {
                                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                                    }
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                    DataTable dtappidzz46 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                    if (dtappidzz46.Rows.Count != 0)
                                    {
                                        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz46.Rows[0]["APPRCYCLE_ID"]);
                                    }
                                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

                                    _obj_Spms_Appraisal.Mode = 5;

                                    DataTable dtgoal4 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

                                    _obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();
                                    if (dtgoal4.Rows.Count != 0)
                                    {
                                        _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtgoal4.Rows[0]["APPRAISAL_ID"]);
                                    }
                                    _obj_Spms_AppraisalGoal.APP_GOALS_FIXED = Convert.ToString(1);
                                    _obj_Spms_AppraisalGoal.Mode = 16;
                                    _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                    bool status10 = Pms_Bll.set_AppraisalGoal(_obj_Spms_AppraisalGoal);
                                    if (status1 == true)
                                    {
                                        Pms_Bll.ShowMessage(this, "Manager Feedback Inserted Successfully");

                                        _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                                        _obj_Pms_Appraisalcycle.MODE = 11;
                                        _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                        DataTable dtem = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                        _obj_Pms_Appraisalcycle.MODE = 8;
                                        if (dtem.Rows.Count != 0)
                                        {
                                            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                                        }
                                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                        DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                                        _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
                                        _obj_Pms_EmpGoalSetting.Mode = 8;

                                        _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                                        _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                        if (dtappid.Rows.Count != 0)
                                        {
                                            _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
                                        }
                                        DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
                                        if (dt.Rows.Count != 0)
                                        {
                                            GSID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
                                        }
                                        PMS_GoalSettings_Details _obj_GSdetails = new PMS_GoalSettings_Details();
                                        _obj_GSdetails.GSDTL_GS_ID = GSID;
                                        _obj_GSdetails.GS_DETAILS_MODE = 5;
                                        _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                                        DataTable dt_details = new DataTable();
                                        dt_details = Pms_Bll.get_GSdetails(_obj_GSdetails);
                                        if (dt_details.Rows.Count != 0)
                                        {
                                            Rg_Appraisal_Goal.DataSource = dt_details;
                                            Rg_Appraisal_Goal.DataBind();
                                        }

                                        _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                                        _obj_Pms_Appraisalcycle.MODE = 11;
                                        _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                        DataTable dtemzz99 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                        _obj_Pms_Appraisalcycle.MODE = 8;
                                        if (dtemzz99.Rows.Count != 0)
                                        {
                                            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz99.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                                        }
                                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                        DataTable dtappidzz99 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                        _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                                        _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);

                                        _obj_Spms_Appraisal.Mode = 5;
                                        if (dtappidzz99.Rows.Count != 0)
                                        {
                                            _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz99.Rows[0]["APPRCYCLE_ID"]);
                                        }
                                        _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                        DataTable dtg = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                                        if (dtg.Rows.Count != 0)
                                        {
                                            _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtg.Rows[0]["APPRAISAL_ID"]);
                                        }
                                        _obj_Spms_AppraisalGoal.Mode = 7;
                                        _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                        DataTable dt1 = Pms_Bll.get_AppraisalGoal(_obj_Spms_AppraisalGoal);

                                        rnt_GoalAvgrtg.Value = Convert.ToDouble(dt1.Rows[0]["APP_GOALS_MGR_RATING"]);
                                        LoadGrid();
                                        LOADGOALmgrFINALIZE();
                                        Rm_Appraisal_PAGE.SelectedIndex = 0;
                                        rnt_GoalAvgrtg.Enabled = false;
                                        Rp_Appraisal_VIEWDETAILS.Visible = true;
                                        Rg_Appraisal_Goal.Visible = true;

                                        return;
                                    }

                                }

                            }
                        }
                        else
                        {
                            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                            _obj_Pms_Appraisalcycle.MODE = 11;
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtemzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                            _obj_Pms_Appraisalcycle.MODE = 8;
                            if (dtemzz.Rows.Count != 0)
                            {
                                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                            }
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtappidzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);



                            _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                            _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                            if (dtappidzz.Rows.Count != 0)
                            {
                                _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz.Rows[0]["APPRCYCLE_ID"]);
                            }
                            _obj_Spms_Appraisal.Mode = 5;

                            _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtgoal1 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                            if (dtgoal1.Rows.Count != 0)
                            {
                                _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtgoal1.Rows[0]["APPRAISAL_ID"]);
                            }
                            _obj_Spms_AppraisalGoal.Mode = 6;
                            _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(lblgsdt_id.Text);
                            _obj_Spms_AppraisalGoal.APP_GOALS_EMP_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(txtempfeed.Text));
                            _obj_Spms_AppraisalGoal.APP_GOALS_MGR_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(txtmgrfeed.Text));
                            _obj_Spms_AppraisalGoal.APP_GOALS_MGR_RATING = Convert.ToDecimal(rdratingmgr.Value);
                            _obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFBY = 1;
                            _obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFDATE = DateTime.Now;
                            bool status = Pms_Bll.set_AppraisalGoal(_obj_Spms_AppraisalGoal);
                            if (status == true)
                            {
                                Pms_Bll.ShowMessage(this, "Mgr GoalFeedback Updated Successfully");
                                //_obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
                                //_obj_Pms_EmpGoalSetting.Mode = 8;
                                //_obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                //DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);

                                _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                                _obj_Pms_Appraisalcycle.MODE = 11;
                                _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dtem = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                _obj_Pms_Appraisalcycle.MODE = 8;
                                if (dtem.Rows.Count != 0)
                                {
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                                }
                                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                                _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
                                _obj_Pms_EmpGoalSetting.Mode = 8;

                                _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                                _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                if (dtappid.Rows.Count != 0)
                                {
                                    _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
                                }
                                DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
                                if (dt.Rows.Count != 0)
                                {
                                    Rg_Appraisal_Goal.DataSource = dt;
                                    Rg_Appraisal_Goal.DataBind();
                                }
                                _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                                _obj_Pms_Appraisalcycle.MODE = 11;
                                _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dtemzz47 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                _obj_Pms_Appraisalcycle.MODE = 8;
                                if (dtemzz47.Rows.Count != 0)
                                {
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz47.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                                }
                                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dtappidzz47 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                                _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                                _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                if (dtappidzz47.Rows.Count != 0)
                                {
                                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz47.Rows[0]["APPRCYCLE_ID"]);
                                }
                                _obj_Spms_Appraisal.Mode = 5;
                                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dtg = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                                if (dtg.Rows.Count != 0)
                                {
                                    _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtg.Rows[0]["APPRAISAL_ID"]);
                                }
                                _obj_Spms_AppraisalGoal.Mode = 7;
                                _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dt1 = Pms_Bll.get_AppraisalGoal(_obj_Spms_AppraisalGoal);

                                rnt_GoalAvgrtg.Value = Convert.ToDouble(dt1.Rows[0]["APP_GOALS_MGR_RATING"]);
                                Rm_Appraisal_PAGE.SelectedIndex = 1;
                                rnt_GoalAvgrtg.Enabled = false;
                                Rp_Appraisal_VIEWDETAILS.Visible = true;


                                return;
                            }

                        }
                    }
                    else
                    {
                        Pms_Bll.ShowMessage(this, "Please enter the Comments more than 10 characters");
                        return;
                    }
                }
                else
                {
                    Pms_Bll.ShowMessage(this, "Please check the Stars");
                    return;
                }
            }
            #endregion

            #region Manager  update
            else if (e.CommandName == "btn_GoalMgrupdate")
            {
                string q = txtmgrfeed.Text;
                int l = Convert.ToInt32(rdratingmgr.Value);
                if ((l > 0))
                {
                    if ((q.Length >= 10))
                    {
                        PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                        _obj_Pms_Appraisalcycle.MODE = 11;
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtemzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                        _obj_Pms_Appraisalcycle.MODE = 8;
                        if (dtemzz.Rows.Count != 0)
                        {
                            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                        }
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtappidzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                        _obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();


                        _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                        _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                        if (dtappidzz.Rows.Count != 0)
                        {
                            _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz.Rows[0]["APPRCYCLE_ID"]);
                        }

                        _obj_Spms_Appraisal.Mode = 5;
                        _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtgoal1 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

                        if (dtgoal1.Rows.Count != 0)
                        {
                            _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtgoal1.Rows[0]["APPRAISAL_ID"]);
                        }
                        _obj_Spms_AppraisalGoal.Mode = 15;
                        _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(lblgsdt_id.Text);
                        _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Spms_AppraisalGoal.APP_GOALS_MGR_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(txtmgrfeed.Text));
                        _obj_Spms_AppraisalGoal.APP_GOALS_MGR_RATING = Convert.ToDecimal(rdratingmgr.Value);


                        bool status1 = Pms_Bll.set_AppraisalGoal(_obj_Spms_AppraisalGoal);
                        if (status1 == true)
                        {
                            Pms_Bll.ShowMessage(this, "Manager Feedback Updated Successfully");

                            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                            _obj_Pms_Appraisalcycle.MODE = 11;
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtem = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                            _obj_Pms_Appraisalcycle.MODE = 8;
                            if (dtem.Rows.Count != 0)
                            {
                                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                            }
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                            _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
                            _obj_Pms_EmpGoalSetting.Mode = 8;

                            _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                            if (dtappid.Rows.Count != 0)
                            {

                                _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
                            }
                            DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
                            if (dt.Rows.Count != 0)
                            {
                                GSID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
                            }
                            PMS_GoalSettings_Details _obj_GSdetails = new PMS_GoalSettings_Details();
                            _obj_GSdetails.GSDTL_GS_ID = GSID;
                            _obj_GSdetails.GS_DETAILS_MODE = 5;
                            _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dt_details = new DataTable();
                            dt_details = Pms_Bll.get_GSdetails(_obj_GSdetails);
                            if (dt_details.Rows.Count != 0)
                            {
                                Rg_Appraisal_Goal.DataSource = dt_details;
                                Rg_Appraisal_Goal.DataBind();
                            }

                            //LoadKraGrid();

                            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                            _obj_Pms_Appraisalcycle.MODE = 11;
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtemzz48 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                            _obj_Pms_Appraisalcycle.MODE = 8;
                            if (dtemzz.Rows.Count != 0)
                            {
                                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                            }
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtappidzz48 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                            _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                            _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                            if (dtappidzz48.Rows.Count != 0)
                            {
                                _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz48.Rows[0]["APPRCYCLE_ID"]);
                            }
                            _obj_Spms_Appraisal.Mode = 5;
                            _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(LBL_Appraise_Id.Text);

                            DataTable dtg = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                            if (dtg.Rows.Count != 0)
                            {
                                _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtg.Rows[0]["APPRAISAL_ID"]);
                            }
                            _obj_Spms_AppraisalGoal.Mode = 7;
                            _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dt1 = Pms_Bll.get_AppraisalGoal(_obj_Spms_AppraisalGoal);

                            rnt_GoalAvgrtg.Value = Convert.ToDouble(dt1.Rows[0]["APP_GOALS_MGR_RATING"]);
                            LoadGrid();
                            LOADGOALmgrFINALIZE();
                            Rm_Appraisal_PAGE.SelectedIndex = 0;
                            rnt_GoalAvgrtg.Enabled = false;
                            Rp_Appraisal_VIEWDETAILS.Visible = true;
                            Rg_Appraisal_Goal.Visible = true;

                            return;
                        }

                    }
                    else
                    {
                        Pms_Bll.ShowMessage(this, "Please enter the Comments more than 10 characters");
                        return;
                    }
                }
                else
                {
                    Pms_Bll.ShowMessage(this, "Please check the Stars");
                    return;
                }
            }
            #endregion

            #region   Employee  Submit,Update

            else if (e.CommandName == "btn_GoalEmpSubmit")
            {
                //    _obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();

                //    _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(lblgsdt_id.Text);

                //    _obj_Spms_AppraisalGoal.Mode = 5;
                //    DataTable dtgoal = Pms_Bll.get_AppraisalGoal(_obj_Spms_AppraisalGoal);
                //    if (dtgoal.Rows.Count == 0)
                //    {

                //        PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                //        _obj_Pms_Appraisalcycle.MODE = 11;
                //        _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                //        DataTable dtemzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                //        _obj_Pms_Appraisalcycle.MODE = 8;
                //        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                //        DataTable dtappidzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                //        _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                //        _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                //        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz.Rows[0]["APPRCYCLE_ID"]);
                //        _obj_Spms_Appraisal.Mode = 5;

                //        DataTable dtgoal1 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                //        _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtgoal1.Rows[0]["APPRAISAL_ID"]);
                //        _obj_Spms_AppraisalGoal.Mode = 3;
                //        _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(lblgsdt_id.Text);
                //        _obj_Spms_AppraisalGoal.APP_GOALS_EMP_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(txtempfeed.Text));
                //        _obj_Spms_AppraisalGoal.APP_GOALS_MGR_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(txtmgrfeed.Text));
                //        _obj_Spms_AppraisalGoal.APP_GOALS_MGR_RATING = Convert.ToInt32(rdratingmgr.Value);
                //        _obj_Spms_AppraisalGoal.APP_GOALS_CREATEDBY = 1;

                //        _obj_Spms_AppraisalGoal.APP_GOALS_CREATEDDATE = DateTime.Now;
                //        bool status = Pms_Bll.set_AppraisalGoal(_obj_Spms_AppraisalGoal);
                //        if (status == true)
                //        {
                //            Pms_Bll.ShowMessage(this, "Employee GoalFeedback Inserted Successfully");
                //            LoadGrid();
                //            LoadKraGrid();

                //            Rm_Appraisal_PAGE.SelectedIndex = 1;
                //            rnt_GoalAvgrtg.Visible = true;
                //            Rp_Appraisal_VIEWDETAILS.Visible = true;



                //            return;
                //        }
                //    }
                //    else
                //    {
                //        PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                //        _obj_Pms_Appraisalcycle.MODE = 11;
                //        _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                //        DataTable dtemzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                //        _obj_Pms_Appraisalcycle.MODE = 8;
                //        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                //        DataTable dtappidzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                //        _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                //        _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                //        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz.Rows[0]["APPRCYCLE_ID"]);
                //        _obj_Spms_Appraisal.Mode = 5;

                //        DataTable dtgoal1 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                //        _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtgoal1.Rows[0]["APPRAISAL_ID"]);
                //        _obj_Spms_AppraisalGoal.Mode = 6;
                //        _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(lblgsdt_id.Text);
                //        _obj_Spms_AppraisalGoal.APP_GOALS_EMP_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(txtempfeed.Text));
                //        _obj_Spms_AppraisalGoal.APP_GOALS_MGR_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(txtmgrfeed.Text));
                //        _obj_Spms_AppraisalGoal.APP_GOALS_MGR_RATING = Convert.ToInt32(rdratingmgr.Value);
                //        _obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFBY = 1;
                //        _obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFDATE = DateTime.Now;
                //        bool status = Pms_Bll.set_AppraisalGoal(_obj_Spms_AppraisalGoal);
                //        if (status == true)
                //        {
                //            Pms_Bll.ShowMessage(this, "Employee GoalFeedback Updated Successfully");
                //            LoadGrid();
                //            LoadKraGrid();

                //            Rm_Appraisal_PAGE.SelectedIndex = 1;
                //            rnt_GoalAvgrtg.Visible = true;
                //            Rp_Appraisal_VIEWDETAILS.Visible = true;


                //            return;
                //        }

                //    }
            }
            #endregion
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsMgrAppraisal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    #region Rg_Appraisal Kra Commands


    protected void Rg_Appraisal_Kra_Command(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            Label lblkradt_id = new System.Web.UI.WebControls.Label();
            Label lblappraisalKradtl = new System.Web.UI.WebControls.Label();
            int i = Convert.ToInt32(e.CommandArgument);
            Label lblkraweightage = new System.Web.UI.WebControls.Label();


            lblkradt_id = Rg_Appraisal_Kra.Rows[i].FindControl("lbl_Kra_Id") as Label;
            lblappraisalKradtl = Rg_Appraisal_Kra.Rows[i].FindControl("lbl_Kra_AppraisalCycle") as Label;
            lblkraweightage = Rg_Appraisal_Kra.Rows[i].FindControl("lbl_KrawEIGHTAGE") as Label;
            TextBox txtKraEmployeeFeedback = new System.Web.UI.WebControls.TextBox();
            Button btnKraEmpSubmit = new System.Web.UI.WebControls.Button();
            Button btnKraEmpCancel = new System.Web.UI.WebControls.Button();

            txtKraEmployeeFeedback = Rg_Appraisal_Kra.Rows[i].FindControl("txt_KraEmployeeFeedback") as TextBox;
            btnKraEmpSubmit = Rg_Appraisal_Kra.Rows[i].FindControl("btn_KraEmpSubmit") as Button;
            btnKraEmpCancel = Rg_Appraisal_Kra.Rows[i].FindControl("btn_KraEmpCancel") as Button;

            TextBox txtKraManagerFeedback = new System.Web.UI.WebControls.TextBox();
            Button btnKraMgrSubmit = new System.Web.UI.WebControls.Button();
            Button btnKraMgrCancel = new System.Web.UI.WebControls.Button();
            RadRating rdrtgKraMgr = new Telerik.Web.UI.RadRating();
            Button btnKramgrupadte = new System.Web.UI.WebControls.Button();

            txtKraManagerFeedback = Rg_Appraisal_Kra.Rows[i].FindControl("txt_KraManagerFeedback") as TextBox;
            btnKraMgrSubmit = Rg_Appraisal_Kra.Rows[i].FindControl("btn_KraMgrSubmit") as Button;
            btnKraMgrCancel = Rg_Appraisal_Kra.Rows[i].FindControl("btn_KraMgrCancel") as Button;
            rdrtgKraMgr = Rg_Appraisal_Kra.Rows[i].FindControl("rdrtg_KraMgr") as RadRating;
            btnKramgrupadte = Rg_Appraisal_Kra.Rows[i].FindControl("btn_KraMgrupdate") as Button;
            #region Employee Kra Feedback


            if (e.CommandName == "KraEmployee_Feed")
            {
                PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                _obj_Pms_Appraisalcycle.MODE = 11;

                _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtemzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                _obj_Pms_Appraisalcycle.MODE = 8;
                if (dtemzz.Rows.Count != 0)
                {
                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                }
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtappidzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                _obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                _obj_Spms_AppraisalKra.APP_KRA_KRA_ID = Convert.ToInt32(lblkradt_id.Text);
                _obj_Spms_AppraisalKra.Mode = 5;
                _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Spms_AppraisalKra.APP_KRA_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                if (dtappidzz.Rows.Count != 0)
                {
                    _obj_Spms_AppraisalKra.APP_KRA_LASTMDFBY = Convert.ToInt32(dtappidzz.Rows[0]["APPRCYCLE_ID"]);
                }
                DataTable dtKra = Pms_Bll.get_AppraisalKra(_obj_Spms_AppraisalKra);
                if (dtKra.Rows.Count != 0)
                {
                    txtKraEmployeeFeedback.Text = Convert.ToString(dtKra.Rows[0]["APP_KRA_EMP_COMMENTS"]);

                    if (txtKraEmployeeFeedback.Visible == true)
                    {
                        txtKraEmployeeFeedback.Visible = false;


                    }
                    else
                    {
                        txtKraEmployeeFeedback.Visible = true;

                        txtKraEmployeeFeedback.Enabled = false;
                    }
                }
                else
                {
                    if (txtKraEmployeeFeedback.Visible == true)
                    {
                        txtKraEmployeeFeedback.Visible = false;


                    }
                    else
                    {
                        txtKraEmployeeFeedback.Visible = true;

                        txtKraEmployeeFeedback.Enabled = false;
                    }
                }
            }
            #endregion



            #region Manager Kra Feedback
            else if (e.CommandName == "KraMgr_Feed")
            {
                PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                _obj_Pms_Appraisalcycle.MODE = 11;
                _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtemzL = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                _obj_Pms_Appraisalcycle.MODE = 8;
                if (dtemzL.Rows.Count != 0)
                {
                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzL.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                }
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtappidzL = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                if (dtappidzL.Rows.Count != 0)
                {
                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzL.Rows[0]["APPRCYCLE_ID"]);
                }
                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Spms_Appraisal.Mode = 31;
                //(Convert.ToInt32(dtgoal9.Rows[0]["APP_KRA_FIXED"]) == 1) ||
                DataTable dtgoal9 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                if (dtgoal9.Rows[0]["APP_KRA_FIXED"] == System.DBNull.Value)
                {
                    _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                    _obj_Pms_Appraisalcycle.MODE = 11;
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtemzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                    _obj_Pms_Appraisalcycle.MODE = 8;
                    if (dtemzz.Rows.Count != 0)
                    {
                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                    }
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtappidzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                    _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                    if (dtappidzz.Rows.Count != 0)
                    {

                        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz.Rows[0]["APPRCYCLE_ID"]);
                    }
                    _obj_Spms_Appraisal.Mode = 5;

                    _obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE = 1;
                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(LBL_Appraise_Id.Text);
                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtg = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                    if (dtg.Rows.Count != 0)
                    {
                        _obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                        if (dtg.Rows.Count != 0)
                        {
                            _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtg.Rows[0]["APPRAISAL_ID"]);
                        }
                        _obj_Spms_AppraisalKra.APP_KRA_KRA_ID = Convert.ToInt32(lblkradt_id.Text);
                        _obj_Spms_AppraisalKra.Mode = 8;
                        _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtKra1 = Pms_Bll.get_AppraisalKra(_obj_Spms_AppraisalKra);

                        if (dtKra1.Rows.Count != 0)
                        {


                            if ((dtKra1.Rows[0]["APP_KRA_MGR_COMMENTS"]) != string.Empty)
                            {
                                txtKraManagerFeedback.Text = Convert.ToString(dtKra1.Rows[0]["APP_KRA_MGR_COMMENTS"]);

                                txtKraManagerFeedback.Enabled = true;
                                rdrtgKraMgr.Enabled = true;

                                if (txtKraManagerFeedback.Visible == true)
                                {

                                    rdrtgKraMgr.Visible = false;
                                    txtKraManagerFeedback.Visible = false;
                                    btnKraMgrSubmit.Visible = false;
                                    btnKraMgrCancel.Visible = false;
                                    btnKramgrupadte.Visible = false;
                                }
                                else
                                {
                                    rdrtgKraMgr.Visible = true;
                                    txtKraManagerFeedback.Visible = true;
                                    btnKraMgrSubmit.Visible = false;
                                    btnKraMgrCancel.Visible = true;
                                    btnKramgrupadte.Visible = true;
                                }
                            }
                            else
                            {
                                if (txtKraManagerFeedback.Visible == true)
                                {
                                    rdrtgKraMgr.Visible = false;
                                    txtKraManagerFeedback.Visible = false;
                                    btnKraMgrSubmit.Visible = false;
                                    btnKraMgrCancel.Visible = false;
                                    btnKramgrupadte.Visible = false;
                                }
                                else
                                {
                                    rdrtgKraMgr.Visible = true;
                                    txtKraManagerFeedback.Visible = true;
                                    txtKraManagerFeedback.Enabled = true;
                                    btnKraMgrSubmit.Visible = true;
                                    btnKraMgrCancel.Visible = true;
                                    btnKramgrupadte.Visible = false;

                                }
                            }

                        }
                        else
                        {
                            if (txtKraManagerFeedback.Visible == true)
                            {
                                rdrtgKraMgr.Visible = false;
                                txtKraManagerFeedback.Visible = false;
                                btnKraMgrSubmit.Visible = false;
                                btnKraMgrCancel.Visible = false;
                            }
                            else
                            {

                                rdrtgKraMgr.Visible = true;
                                txtKraManagerFeedback.Visible = true;
                                txtKraManagerFeedback.Enabled = true;
                                btnKraMgrSubmit.Visible = true;
                                btnKraMgrCancel.Visible = true;


                            }

                        }
                    }

                }
                else
                {
                    if ((Convert.ToInt32(dtgoal9.Rows[0]["APP_KRA_FIXED"]) == 2))
                    {

                        for (int l = 0; l <= Rg_Appraisal_Kra.Rows.Count - 1; l++)
                        {

                            TextBox txtmgrfeed1 = new System.Web.UI.WebControls.TextBox();
                            Button btnsubmitmgrfeed1 = new System.Web.UI.WebControls.Button();
                            Button btncancelmgrfeed1 = new System.Web.UI.WebControls.Button();
                            RadRating rdratingmgr1 = new Telerik.Web.UI.RadRating();
                            txtmgrfeed1 = Rg_Appraisal_Kra.Rows[l].FindControl("txt_KraManagerFeedback") as TextBox;
                            btnsubmitmgrfeed1 = Rg_Appraisal_Kra.Rows[l].FindControl("btn_KraMgrSubmit") as Button;
                            btncancelmgrfeed1 = Rg_Appraisal_Kra.Rows[l].FindControl("btn_KraMgrCancel") as Button;
                            rdratingmgr1 = Rg_Appraisal_Kra.Rows[l].FindControl("rdrtg_KraMgr") as RadRating;
                            if (txtmgrfeed1.Visible == false)
                            {
                                txtmgrfeed1.Visible = true;
                                txtmgrfeed1.Enabled = false;
                                btnsubmitmgrfeed1.Visible = false;
                                btncancelmgrfeed1.Visible = false;
                                rdratingmgr1.Enabled = false;
                                rdratingmgr1.Visible = true;
                            }

                            else
                            {
                                txtmgrfeed1.Visible = false;
                                txtmgrfeed1.Enabled = false;
                                btnsubmitmgrfeed1.Visible = false;
                                btncancelmgrfeed1.Visible = false;
                                rdratingmgr1.Enabled = false;
                                rdratingmgr1.Visible = false;
                            }


                        }
                    }
                    else if ((Convert.ToInt32(dtgoal9.Rows[0]["APP_KRA_FIXED"]) == 1))
                    {
                        _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                        _obj_Pms_Appraisalcycle.MODE = 11;
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtemzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                        _obj_Pms_Appraisalcycle.MODE = 8;
                        if (dtemzz.Rows.Count != 0)
                        {
                            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                        }
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);

                        DataTable dtappidzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                        _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                        _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);

                        _obj_Spms_Appraisal.Mode = 5;
                        _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE = 1;
                        if (dtappidzz.Rows.Count != 0)
                        {
                            _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz.Rows[0]["APPRCYCLE_ID"]);
                        }
                        DataTable dtg = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                        if (dtg.Rows.Count != 0)
                        {
                            _obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                            _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtg.Rows[0]["APPRAISAL_ID"]);
                            _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Spms_AppraisalKra.APP_KRA_KRA_ID = Convert.ToInt32(lblkradt_id.Text);
                            _obj_Spms_AppraisalKra.Mode = 8;
                            DataTable dtKra1 = Pms_Bll.get_AppraisalKra(_obj_Spms_AppraisalKra);

                            if (dtKra1.Rows.Count != 0)
                            {


                                if ((dtKra1.Rows[0]["APP_KRA_MGR_COMMENTS"]) != string.Empty)
                                {
                                    txtKraManagerFeedback.Text = Convert.ToString(dtKra1.Rows[0]["APP_KRA_MGR_COMMENTS"]);

                                    txtKraManagerFeedback.Enabled = true;
                                    rdrtgKraMgr.Enabled = true;

                                    if (txtKraManagerFeedback.Visible == true)
                                    {

                                        rdrtgKraMgr.Visible = false;
                                        txtKraManagerFeedback.Visible = false;
                                        btnKraMgrSubmit.Visible = false;
                                        btnKraMgrCancel.Visible = false;
                                        btnKramgrupadte.Visible = false;
                                    }
                                    else
                                    {
                                        rdrtgKraMgr.Visible = true;
                                        txtKraManagerFeedback.Visible = true;
                                        btnKraMgrSubmit.Visible = false;
                                        btnKraMgrCancel.Visible = true;
                                        btnKramgrupadte.Visible = true;
                                    }
                                }
                                else
                                {
                                    if (txtKraManagerFeedback.Visible == true)
                                    {
                                        rdrtgKraMgr.Visible = false;
                                        txtKraManagerFeedback.Visible = false;
                                        btnKraMgrSubmit.Visible = false;
                                        btnKraMgrCancel.Visible = false;
                                        btnKramgrupadte.Visible = false;
                                    }
                                    else
                                    {
                                        rdrtgKraMgr.Visible = true;
                                        txtKraManagerFeedback.Visible = true;
                                        txtKraManagerFeedback.Enabled = true;
                                        btnKraMgrSubmit.Visible = true;
                                        btnKraMgrCancel.Visible = true;
                                        btnKramgrupadte.Visible = false;

                                    }
                                }

                            }
                            else
                            {
                                if (txtKraManagerFeedback.Visible == true)
                                {
                                    rdrtgKraMgr.Visible = false;
                                    txtKraManagerFeedback.Visible = false;
                                    btnKraMgrSubmit.Visible = false;
                                    btnKraMgrCancel.Visible = false;
                                }
                                else
                                {

                                    rdrtgKraMgr.Visible = true;
                                    txtKraManagerFeedback.Visible = true;
                                    txtKraManagerFeedback.Enabled = true;
                                    btnKraMgrSubmit.Visible = true;
                                    btnKraMgrCancel.Visible = true;


                                }

                            }
                        }

                    }

                }
            }
            #endregion

            #region Employee Kra Cancel

            else if (e.CommandName == "btn_KraEmpCancel")
            {
                if (txtKraEmployeeFeedback.Visible == true)
                {
                    txtKraEmployeeFeedback.Visible = false;
                    btnKraEmpSubmit.Visible = false;
                    btnKraEmpCancel.Visible = false;

                }
                else
                {
                    txtKraEmployeeFeedback.Visible = true;
                    btnKraEmpSubmit.Visible = true;
                    btnKraEmpCancel.Visible = true;

                }
            }
            #endregion

            #region Manager Kra Cancel

            else if (e.CommandName == "btn_KraMgrCancel")
            {
                if (txtKraManagerFeedback.Visible == true)
                {
                    rdrtgKraMgr.Visible = false;
                    txtKraManagerFeedback.Visible = false;
                    btnKraMgrSubmit.Visible = false;
                    btnKraMgrCancel.Visible = false;
                    btnKramgrupadte.Visible = false;
                }
                else
                {
                    rdrtgKraMgr.Visible = true;
                    txtKraManagerFeedback.Visible = true;
                    btnKraMgrSubmit.Visible = true;
                    btnKraMgrCancel.Visible = true;
                }
            }

            #endregion

            #region Manager KRA  Submit,Update
            else if (e.CommandName == "btn_KraMgrSubmit")
            {
                string q = txtKraManagerFeedback.Text;
                int l = Convert.ToInt32(rdrtgKraMgr.Value);
                if ((l > 0))
                {
                    if ((q.Length >= 10))
                    {
                        PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                        _obj_Pms_Appraisalcycle.MODE = 11;
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtemzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                        _obj_Pms_Appraisalcycle.MODE = 8;
                        if (dtemzz.Rows.Count != 0)
                        {
                            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                        }
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtappidzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);



                        _obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                        _obj_Spms_AppraisalKra.APP_KRA_KRA_ID = Convert.ToInt32(lblkradt_id.Text);
                        _obj_Spms_AppraisalKra.APP_KRA_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                        _obj_Spms_AppraisalKra.Mode = 5;
                        if (dtappidzz.Rows.Count != 0)
                        {
                            _obj_Spms_AppraisalKra.APP_KRA_LASTMDFBY = Convert.ToInt32(dtappidzz.Rows[0]["APPRCYCLE_ID"]);
                        }
                        _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtkra3 = Pms_Bll.get_AppraisalKra(_obj_Spms_AppraisalKra);
                        if (dtkra3.Rows.Count != 0)
                        {
                            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                            _obj_Pms_Appraisalcycle.MODE = 11;
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtemzz02 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                            _obj_Pms_Appraisalcycle.MODE = 8;
                            if (dtemzz02.Rows.Count != 0)
                            {
                                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz02.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                            }
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtappidzz02 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                            _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                            _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                            _obj_Spms_Appraisal.Mode = 27;
                            if (dtappidzz02.Rows.Count != 0)
                            {
                                _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz02.Rows[0]["APPRCYCLE_ID"]);
                            }
                            DataTable dtemp = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                            if (dtemp.Rows.Count != 0)
                            {
                                _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                                _obj_Pms_Appraisalcycle.MODE = 11;
                                _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dtemzzR = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                _obj_Pms_Appraisalcycle.MODE = 8;
                                if (dtemzzR.Rows.Count != 0)
                                {
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzzR.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                                }
                                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dtappidzzR = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                                _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                                _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                if (dtappidzzR.Rows.Count != 0)
                                {
                                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzzR.Rows[0]["APPRCYCLE_ID"]);

                                }
                                _obj_Spms_Appraisal.Mode = 5;
                                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dtgoal4 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

                                _obj_Spms_AppraisalKra.Mode = 10;
                                _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                _obj_Spms_AppraisalKra.APP_KRA_KRA_ID = Convert.ToInt32(lblkradt_id.Text);
                                _obj_Spms_AppraisalKra.APP_KRA_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                if (dtappidzzR.Rows.Count != 0)
                                {
                                    _obj_Spms_AppraisalKra.APP_KRA_LASTMDFBY = Convert.ToInt32(dtappidzzR.Rows[0]["APPRCYCLE_ID"]);
                                }
                                DataTable dtkra_id = Pms_Bll.get_AppraisalKra(_obj_Spms_AppraisalKra);

                                if (dtgoal4.Rows.Count != 0)
                                {
                                    _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtgoal4.Rows[0]["APPRAISAL_ID"]);
                                }
                                _obj_Spms_AppraisalKra.Mode = 4;
                                _obj_Spms_AppraisalKra.APP_KRA_KRA_ID = Convert.ToInt32(lblkradt_id.Text);
                                _obj_Spms_AppraisalKra.APP_KRA_EMP_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(txtKraEmployeeFeedback.Text));
                                _obj_Spms_AppraisalKra.APP_KRA_MGR_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(txtKraManagerFeedback.Text));
                                _obj_Spms_AppraisalKra.APP_KRA_MGR_RATING = Convert.ToDecimal(rdrtgKraMgr.Value);
                                _obj_Spms_AppraisalKra.APP_KRA_LASTMDFBY = 1;
                                _obj_Spms_AppraisalKra.APP_KRA_LASTMDFDATE = DateTime.Now;
                                if (dtkra_id.Rows.Count != 0)
                                {
                                    _obj_Spms_AppraisalKra.APP_KRA_ID = Convert.ToInt32(dtkra_id.Rows[0]["APP_KRA_ID"]);
                                }
                                _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);




                                bool status1 = Pms_Bll.set_AppraisalKra(_obj_Spms_AppraisalKra);
                                _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                                _obj_Pms_Appraisalcycle.MODE = 11;
                                _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dtemzz49 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                _obj_Pms_Appraisalcycle.MODE = 8;
                                if (dtemzz49.Rows.Count != 0)
                                {
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz49.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                                }
                                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dtappidzz49 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                                _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                if (dtappidzz.Rows.Count != 0)
                                {
                                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz.Rows[0]["APPRCYCLE_ID"]);
                                }

                                _obj_Spms_Appraisal.Mode = 5;
                                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dtgoal44 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

                                _obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                                if (dtgoal44.Rows.Count != 0)
                                {
                                    _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtgoal44.Rows[0]["APPRAISAL_ID"]);
                                }
                                _obj_Spms_AppraisalKra.APP_KRA_FIXED = Convert.ToString(1);
                                _obj_Spms_AppraisalKra.Mode = 17;
                                _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                bool status10 = Pms_Bll.set_AppraisalKra(_obj_Spms_AppraisalKra);
                                if (status1 == true)
                                {
                                    Pms_Bll.ShowMessage(this, "Manager Feedback Inserted Successfully");
                                    _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                                    _obj_Pms_Appraisalcycle.MODE = 11;
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                    DataTable dtem = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                    _obj_Pms_Appraisalcycle.MODE = 8;
                                    if (dtem.Rows.Count != 0)
                                    {
                                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                                    }
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                    DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                                    _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
                                    _obj_Pms_EmpGoalSetting.Mode = 8;

                                    _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                                    _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                    if (dtappid.Rows.Count != 0)
                                    {
                                        _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
                                    }
                                    DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
                                    if (dt.Rows.Count != 0)
                                    {
                                        GSID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
                                    }
                                    PMS_GoalSettings_Details _obj_GSdetails = new PMS_GoalSettings_Details();
                                    _obj_GSdetails.GSDTL_GS_ID = GSID;
                                    _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                                    _obj_GSdetails.GS_DETAILS_MODE = 5;
                                    DataTable dt_details = new DataTable();
                                    dt_details = Pms_Bll.get_GSdetails(_obj_GSdetails);
                                    if (dt_details.Rows.Count != 0)
                                    {
                                        _obj_Spms_GoalStgKraDtls = new SPMS_GOALSETTINGKRADETAILS();
                                        _obj_Spms_GoalStgKraDtls.Mode = 7;
                                        if (dt_details.Rows.Count != 0)
                                        {
                                            _obj_Spms_GoalStgKraDtls.GS_KRA_GSDTL_ID = Convert.ToInt32(dt_details.Rows[0]["GSDTL_ID"]);
                                        }
                                        _obj_Spms_GoalStgKraDtls.LASTMDFBY = Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
                                        _obj_Spms_GoalStgKraDtls.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                                        DataTable dt2 = Pms_Bll.get_GoalStgKraDtls(_obj_Spms_GoalStgKraDtls);

                                        if (dt2.Rows.Count != 0)
                                        {
                                            Rg_Appraisal_Kra.DataSource = dt2;
                                            Rg_Appraisal_Kra.DataBind();
                                        }
                                    }

                                    LoadKraGrid();
                                    LOADKRAmgrFINALIZE();
                                    //_obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                                    // _obj_Pms_Appraisalcycle.MODE = 11;
                                    // _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                                    // DataTable dtemzz41 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                    // _obj_Pms_Appraisalcycle.MODE = 8;
                                    // _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz41.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                                    // DataTable dtappidzz41 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                                    // _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                                    // _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                    // _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz41.Rows[0]["APPRCYCLE_ID"]);
                                    // _obj_Spms_Appraisal.Mode = 5;

                                    // //_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(LBL_Appraise_Id.Text);

                                    // DataTable dtg = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                                    // _obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                                    // _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtg.Rows[0]["APPRAISAL_ID"]);
                                    // _obj_Spms_AppraisalKra.Mode = 7;
                                    // DataTable dt5 = Pms_Bll.get_AppraisalKra(_obj_Spms_AppraisalKra);
                                    // if (dt5.Rows.Count != 0)
                                    // {
                                    //     rnt_KraAvgrtg.Value = Convert.ToDouble(dt5.Rows[0]["APP_KRA_MGR_RATING"]);
                                    // }
                                    // else
                                    // {
                                    //     rnt_KraAvgrtg.Value = 0;
                                    // }
                                    double dou_GrantTotal = 0;
                                    for (int z = 0; z < Rg_Appraisal_Kra.Rows.Count; z++)
                                    {
                                        //Label lblkraweightage = new System.Web.UI.WebControls.Label();
                                        RadRating rdrtg_KraMgr = new Telerik.Web.UI.RadRating();

                                        rdrtg_KraMgr = Rg_Appraisal_Kra.Rows[z].FindControl("rdrtg_KraMgr") as RadRating;
                                        lblkraweightage = Rg_Appraisal_Kra.Rows[z].FindControl("lbl_KrawEIGHTAGE") as Label;

                                        int s = Convert.ToInt32(lblkraweightage.Text);
                                        int w = Convert.ToInt32(rdrtg_KraMgr.Value);
                                        double g = Convert.ToDouble((double)(s * w) / 100);
                                        dou_GrantTotal = dou_GrantTotal + g;

                                    }

                                    rnt_KraAvgrtg.Value = dou_GrantTotal;


                                    Rm_Appraisal_PAGE.SelectedIndex = 0;
                                    Rm_Appraisal_GOALKRA.SelectedIndex = 1;
                                    btn_goalmgrfinalise.Visible = false;

                                    Rg_Appraisal_Goal.Visible = false;
                                    rnt_KraAvgrtg.Visible = true;
                                    rnt_KraAvgrtg.Enabled = false;
                                    Rg_Appraisal_Kra.Visible = true;
                                    Rp_Appraisal_VIEWDETAILS.Visible = true;

                                    return;
                                }
                            }
                            else
                            {
                                _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                                _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                _obj_Spms_Appraisal.APPRAISAL_DATE = rdtp_DATEofAppraisal.SelectedDate.Value;
                                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                _obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE = 2;
                                _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(LBL_Appraise_Id.Text);
                                _obj_Spms_Appraisal.APPRAISAL_CREATEDBY = 1;
                                _obj_Spms_Appraisal.APPRAISAL_STATUS = 2;
                                _obj_Spms_Appraisal.APPRAISAL_CREATEDDATE = DateTime.Now;

                                _obj_Spms_Appraisal.Mode = 4;
                                bool status = Pms_Bll.set_Appraisal(_obj_Spms_Appraisal);
                                if (status == true)
                                {
                                    _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                                    _obj_Pms_Appraisalcycle.MODE = 11;
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                    DataTable dtemzz7 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                    _obj_Pms_Appraisalcycle.MODE = 8;
                                    if (dtemzz7.Rows.Count != 0)
                                    {
                                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz7.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                                    }
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                    DataTable dtappidzz7 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                    _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                    if (dtappidzz7.Rows.Count != 0)
                                    {
                                        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz7.Rows[0]["apprcycle_id"]);
                                    }
                                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                    _obj_Spms_Appraisal.Mode = 5;
                                    DataTable dtgoal4 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                                    if (dtgoal4.Rows.Count != 0)
                                    {
                                        _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtgoal4.Rows[0]["APPRAISAL_ID"]);
                                    }
                                    _obj_Spms_AppraisalKra.Mode = 3;
                                    _obj_Spms_AppraisalKra.APP_KRA_KRA_ID = Convert.ToInt32(lblkradt_id.Text);
                                    _obj_Spms_AppraisalKra.APP_KRA_EMP_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(txtKraEmployeeFeedback.Text));
                                    _obj_Spms_AppraisalKra.APP_KRA_MGR_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(txtKraManagerFeedback.Text));
                                    _obj_Spms_AppraisalKra.APP_KRA_MGR_RATING = Convert.ToDecimal(rdrtgKraMgr.Value);
                                    _obj_Spms_AppraisalKra.APP_KRA_CREATEDBY = 1;
                                    _obj_Spms_AppraisalKra.APP_KRA_CREATEDDATE = DateTime.Now;
                                    _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);

                                    bool status1 = Pms_Bll.set_AppraisalKra(_obj_Spms_AppraisalKra);
                                    if (status1 == true)
                                    {
                                        Pms_Bll.ShowMessage(this, "Manager Feedback Inserted Successfully");
                                        _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                                        _obj_Pms_Appraisalcycle.MODE = 11;
                                        _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                        DataTable dtem = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                        _obj_Pms_Appraisalcycle.MODE = 8;
                                        if (dtem.Rows.Count != 0)
                                        {
                                            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                                        }
                                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                        DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                                        _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
                                        _obj_Pms_EmpGoalSetting.Mode = 8;
                                        _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);

                                        _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                        if (dtappid.Rows.Count != 0)
                                        {
                                            _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
                                        }
                                        DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
                                        if (dt.Rows.Count != 0)
                                        {
                                            GSID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
                                        }
                                        PMS_GoalSettings_Details _obj_GSdetails = new PMS_GoalSettings_Details();
                                        _obj_GSdetails.GSDTL_GS_ID = GSID;
                                        _obj_GSdetails.GS_DETAILS_MODE = 5;
                                        _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                                        DataTable dt_details = new DataTable();
                                        dt_details = Pms_Bll.get_GSdetails(_obj_GSdetails);
                                        if (dt_details.Rows.Count != 0)
                                        {
                                            _obj_Spms_GoalStgKraDtls = new SPMS_GOALSETTINGKRADETAILS();
                                            _obj_Spms_GoalStgKraDtls.Mode = 7;
                                            _obj_Spms_GoalStgKraDtls.GS_KRA_GSDTL_ID = Convert.ToInt32(dt_details.Rows[0]["GSDTL_ID"]);
                                            _obj_Spms_GoalStgKraDtls.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                                            _obj_Spms_GoalStgKraDtls.LASTMDFBY = Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
                                            DataTable dt2 = Pms_Bll.get_GoalStgKraDtls(_obj_Spms_GoalStgKraDtls);

                                            if (dt2.Rows.Count != 0)
                                            {
                                                Rg_Appraisal_Kra.DataSource = dt2;
                                                Rg_Appraisal_Kra.DataBind();
                                            }
                                        }

                                        LoadKraGrid();
                                        LOADKRAmgrFINALIZE();
                                        //_obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                                        //       _obj_Pms_Appraisalcycle.MODE = 11;
                                        //       _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                                        //       DataTable dtemzz51 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                        //       _obj_Pms_Appraisalcycle.MODE = 8;
                                        //       _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz51.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                                        //       DataTable dtappidzz51 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                                        //       _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                                        //       _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);

                                        //       _obj_Spms_Appraisal.Mode = 5;

                                        //       _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz51.Rows[0]["APPRCYCLE_ID"]);

                                        //       DataTable dtg = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                                        //       _obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                                        //       _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtg.Rows[0]["APPRAISAL_ID"]);
                                        //       _obj_Spms_AppraisalKra.Mode = 7;
                                        //       DataTable dt5 = Pms_Bll.get_AppraisalKra(_obj_Spms_AppraisalKra);

                                        //       if (Convert.ToInt32(dt5.Rows[0]["APP_KRA_MGR_RATING"]) != 0)
                                        //       {
                                        //           rnt_KraAvgrtg.Value = Convert.ToDouble(dt5.Rows[0]["APP_KRA_MGR_RATING"]);
                                        //       }

                                        //       else
                                        //       {
                                        //           rnt_KraAvgrtg.Value = 0;
                                        //       }
                                        double dou_GrantTotal = 0;

                                        for (int z = 0; z < Rg_Appraisal_Kra.Rows.Count; z++)
                                        {
                                            //Label lblkraweightage = new System.Web.UI.WebControls.Label();
                                            RadRating rdrtg_KraMgr = new Telerik.Web.UI.RadRating();

                                            rdrtg_KraMgr = Rg_Appraisal_Kra.Rows[z].FindControl("rdrtg_KraMgr") as RadRating;
                                            lblkraweightage = Rg_Appraisal_Kra.Rows[z].FindControl("lbl_KrawEIGHTAGE") as Label;

                                            int s = Convert.ToInt32(lblkraweightage.Text);
                                            int w = Convert.ToInt32(rdrtg_KraMgr.Value);
                                            double g = Convert.ToDouble((double)(s * w) / 100);
                                            dou_GrantTotal = dou_GrantTotal + g;

                                        }

                                        rnt_KraAvgrtg.Value = dou_GrantTotal;
                                        Rm_Appraisal_PAGE.SelectedIndex = 0;
                                        Rm_Appraisal_GOALKRA.SelectedIndex = 1;
                                        btn_goalmgrfinalise.Visible = false;

                                        Rg_Appraisal_Goal.Visible = false;
                                        rnt_KraAvgrtg.Visible = true;
                                        rnt_KraAvgrtg.Enabled = false;
                                        Rg_Appraisal_Kra.Visible = true;
                                        Rp_Appraisal_VIEWDETAILS.Visible = true;

                                        return;
                                    }

                                }
                            }
                        }
                        else
                        {
                            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                            _obj_Pms_Appraisalcycle.MODE = 11;
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtemzzr = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                            _obj_Pms_Appraisalcycle.MODE = 8;
                            if (dtemzzr.Rows.Count != 0)
                            {
                                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzzr.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                            }
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtappidzzr = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                            _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                            _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                            if (dtappidzz.Rows.Count != 0)
                            {
                                _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzzr.Rows[0]["APPRCYCLE_ID"]);
                            }
                            _obj_Spms_Appraisal.Mode = 5;
                            _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtgoal7 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                            if (dtgoal7.Rows.Count != 0)
                            {
                                _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtgoal7.Rows[0]["APPRAISAL_ID"]);
                            }
                            _obj_Spms_AppraisalKra.Mode = 6;
                            _obj_Spms_AppraisalKra.APP_KRA_KRA_ID = Convert.ToInt32(lblkradt_id.Text);
                            _obj_Spms_AppraisalKra.APP_KRA_EMP_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(txtKraEmployeeFeedback.Text));
                            _obj_Spms_AppraisalKra.APP_KRA_MGR_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(txtKraManagerFeedback.Text));
                            _obj_Spms_AppraisalKra.APP_KRA_MGR_RATING = Convert.ToInt32(rdrtgKraMgr.Value);
                            _obj_Spms_AppraisalKra.APP_KRA_LASTMDFBY = 1;
                            _obj_Spms_AppraisalKra.APP_KRA_LASTMDFDATE = DateTime.Now;
                            _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            bool status = Pms_Bll.set_AppraisalKra(_obj_Spms_AppraisalKra);
                            if (status == true)
                            {
                                Pms_Bll.ShowMessage(this, "Mgr KraFeedback Updated Successfully");

                                //_obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
                                //_obj_Pms_EmpGoalSetting.Mode = 8;
                                //_obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                //DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
                                _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                                _obj_Pms_Appraisalcycle.MODE = 11;
                                _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dtem = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                _obj_Pms_Appraisalcycle.MODE = 8;
                                if (dtem.Rows.Count != 0)
                                {
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                                }
                                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                                _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
                                _obj_Pms_EmpGoalSetting.Mode = 8;

                                _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                                _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                if (dtappid.Rows.Count != 0)
                                {
                                    _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
                                }
                                DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
                                if (dt.Rows.Count != 0)
                                {
                                    _obj_Spms_GoalStgKraDtls = new SPMS_GOALSETTINGKRADETAILS();
                                    _obj_Spms_GoalStgKraDtls.Mode = 7;
                                    _obj_Spms_GoalStgKraDtls.GS_KRA_GSDTL_ID = Convert.ToInt32(dt.Rows[0]["GOALCHILDDTL_ID"]);
                                    _obj_Spms_GoalStgKraDtls.LASTMDFBY = Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
                                    _obj_Spms_GoalStgKraDtls.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                                    DataTable dt2 = Pms_Bll.get_GoalStgKraDtls(_obj_Spms_GoalStgKraDtls);

                                    if (dt2.Rows.Count != 0)
                                    {
                                        Rg_Appraisal_Kra.DataSource = dt2;
                                        Rg_Appraisal_Kra.DataBind();
                                    }
                                }
                                _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                                //_obj_Pms_Appraisalcycle.MODE = 11;
                                //_obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                                //DataTable dtemzz53 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                //_obj_Pms_Appraisalcycle.MODE = 8;
                                //_obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz53.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                                //DataTable dtappidzz53 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                                //_obj_Spms_Appraisal = new SPMS_APPRAISAL();
                                //_obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                //_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz53.Rows[0]["APPRCYCLE_ID"]);
                                //_obj_Spms_Appraisal.Mode = 5;
                                //DataTable dtgo = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                                //_obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtgo.Rows[0]["APPRAISAL_ID"]);
                                //_obj_Spms_AppraisalKra.Mode = 7;
                                //DataTable dt6 = Pms_Bll.get_AppraisalKra(_obj_Spms_AppraisalKra);

                                //if (Convert.ToInt32(dt6.Rows[0]["APP_KRA_MGR_RATING"]) != 0)
                                //{
                                //    rnt_KraAvgrtg.Value = Convert.ToDouble(dt6.Rows[0]["APP_KRA_MGR_RATING"]);
                                //}

                                //else
                                //{
                                //    rnt_KraAvgrtg.Value = 0;
                                //}
                                double dou_GrantTotal = 0;
                                for (int z = 0; z < Rg_Appraisal_Kra.Rows.Count; z++)
                                {
                                    //Label lblkraweightage = new System.Web.UI.WebControls.Label();
                                    RadRating rdrtg_KraMgr = new Telerik.Web.UI.RadRating();

                                    rdrtg_KraMgr = Rg_Appraisal_Kra.Rows[z].FindControl("rdrtg_KraMgr") as RadRating;
                                    lblkraweightage = Rg_Appraisal_Kra.Rows[z].FindControl("lbl_KrawEIGHTAGE") as Label;

                                    int s = Convert.ToInt32(lblkraweightage.Text);
                                    int w = Convert.ToInt32(rdrtg_KraMgr.Value);
                                    double g = Convert.ToDouble((double)(s * w) / 100);
                                    dou_GrantTotal = dou_GrantTotal + g;

                                }

                                rnt_KraAvgrtg.Value = dou_GrantTotal;


                                Rm_Appraisal_PAGE.SelectedIndex = 1;

                                Rg_Appraisal_Goal.Visible = false;
                                rnt_KraAvgrtg.Visible = true;
                                rnt_KraAvgrtg.Enabled = false;
                                Rg_Appraisal_Kra.Visible = true;
                                Rp_Appraisal_VIEWDETAILS.Visible = true;

                                return;
                            }
                        }


                    }
                    else
                    {
                        Pms_Bll.ShowMessage(this, "Please enter the Comments more than 10 characters");
                        return;
                    }
                }
                else
                {
                    Pms_Bll.ShowMessage(this, "Please check the Stars");
                    return;
                }
            }
            #endregion

            #region   managerkra  Update

            else if (e.CommandName == "btn_KraMgrupdate")
            {
                string q = txtKraManagerFeedback.Text;
                int l = Convert.ToInt32(rdrtgKraMgr.Value);
                if ((l > 0))
                {
                    if ((q.Length >= 10))
                    {


                        PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                        _obj_Pms_Appraisalcycle.MODE = 11;
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtemzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                        _obj_Pms_Appraisalcycle.MODE = 8;
                        if (dtemzz.Rows.Count != 0)
                        {
                            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                        }
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtappidzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                        _obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();


                        _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                        _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                        if (dtappidzz.Rows.Count != 0)
                        {
                            _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz.Rows[0]["APPRCYCLE_ID"]);
                        }
                        _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Spms_Appraisal.Mode = 5;
                        DataTable dtgoal4 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);


                        if (dtgoal4.Rows.Count != 0)
                        {
                            _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtgoal4.Rows[0]["APPRAISAL_ID"]);
                        }
                        _obj_Spms_AppraisalKra.Mode = 16;
                        _obj_Spms_AppraisalKra.APP_KRA_KRA_ID = Convert.ToInt32(lblkradt_id.Text);

                        _obj_Spms_AppraisalKra.APP_KRA_MGR_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(txtKraManagerFeedback.Text));
                        _obj_Spms_AppraisalKra.APP_KRA_MGR_RATING = Convert.ToDecimal(rdrtgKraMgr.Value);

                        _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);

                        bool status1 = Pms_Bll.set_AppraisalKra(_obj_Spms_AppraisalKra);
                        if (status1 == true)
                        {
                            Pms_Bll.ShowMessage(this, "Manager Feedback Updated Successfully");
                            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                            _obj_Pms_Appraisalcycle.MODE = 11;
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtem = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                            _obj_Pms_Appraisalcycle.MODE = 8;
                            if (dtem.Rows.Count != 0)
                            {
                                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                            }
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                            _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
                            _obj_Pms_EmpGoalSetting.Mode = 8;


                            _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                            if (dtappid.Rows.Count != 0)
                            {
                                _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
                            }
                            _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
                            if (dt.Rows.Count != 0)
                            {
                                GSID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
                            }
                            PMS_GoalSettings_Details _obj_GSdetails = new PMS_GoalSettings_Details();
                            _obj_GSdetails.GSDTL_GS_ID = GSID;
                            _obj_GSdetails.GS_DETAILS_MODE = 5;
                            _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dt_details = new DataTable();
                            dt_details = Pms_Bll.get_GSdetails(_obj_GSdetails);
                            if (dt_details.Rows.Count != 0)
                            {
                                _obj_Spms_GoalStgKraDtls = new SPMS_GOALSETTINGKRADETAILS();
                                _obj_Spms_GoalStgKraDtls.Mode = 7;
                                _obj_Spms_GoalStgKraDtls.GS_KRA_GSDTL_ID = Convert.ToInt32(dt_details.Rows[0]["GSDTL_ID"]);
                                _obj_Spms_GoalStgKraDtls.LASTMDFBY = Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
                                _obj_Spms_GoalStgKraDtls.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dt2 = Pms_Bll.get_GoalStgKraDtls(_obj_Spms_GoalStgKraDtls);

                                if (dt2.Rows.Count != 0)
                                {
                                    Rg_Appraisal_Kra.DataSource = dt2;
                                    Rg_Appraisal_Kra.DataBind();
                                }
                            }

                            LoadKraGrid();
                            LOADKRAmgrFINALIZE();
                            //_obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                            //  _obj_Pms_Appraisalcycle.MODE = 11;
                            //  _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                            //  DataTable dtemzz56 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                            //  _obj_Pms_Appraisalcycle.MODE = 8;
                            //  _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz56.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                            //  DataTable dtappidzz56 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                            //  _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                            //  _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);

                            //  _obj_Spms_Appraisal.Mode = 5;

                            //  _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz56.Rows[0]["APPRCYCLE_ID"]);

                            //  DataTable dtg = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                            //  _obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                            //  _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtg.Rows[0]["APPRAISAL_ID"]);
                            //  _obj_Spms_AppraisalKra.Mode = 7;
                            //  DataTable dt5 = Pms_Bll.get_AppraisalKra(_obj_Spms_AppraisalKra);
                            //  if (dt5.Rows.Count != 0)
                            //  {
                            //      rnt_KraAvgrtg.Value = Convert.ToDouble(dt5.Rows[0]["APP_KRA_MGR_RATING"]);
                            //  }
                            //  else
                            //  {
                            //      rnt_KraAvgrtg.Value = 0;
                            //  }
                            double dou_GrantTotal = 0;
                            for (int z = 0; z < Rg_Appraisal_Kra.Rows.Count; z++)
                            {
                                //Label lblkraweightage = new System.Web.UI.WebControls.Label();
                                RadRating rdrtg_KraMgr = new Telerik.Web.UI.RadRating();

                                rdrtg_KraMgr = Rg_Appraisal_Kra.Rows[z].FindControl("rdrtg_KraMgr") as RadRating;
                                lblkraweightage = Rg_Appraisal_Kra.Rows[z].FindControl("lbl_KrawEIGHTAGE") as Label;

                                int s = Convert.ToInt32(lblkraweightage.Text);
                                int w = Convert.ToInt32(rdrtg_KraMgr.Value);
                                double g = Convert.ToDouble((double)(s * w) / 100);
                                dou_GrantTotal = dou_GrantTotal + g;

                            }

                            rnt_KraAvgrtg.Value = dou_GrantTotal;

                            Rm_Appraisal_PAGE.SelectedIndex = 0;
                            Rm_Appraisal_GOALKRA.SelectedIndex = 1;
                            btn_goalmgrfinalise.Visible = false;

                            Rg_Appraisal_Goal.Visible = false;
                            rnt_KraAvgrtg.Visible = true;
                            rnt_KraAvgrtg.Enabled = false;
                            Rg_Appraisal_Kra.Visible = true;
                            Rp_Appraisal_VIEWDETAILS.Visible = true;

                            return;
                        }


                    }
                    else
                    {
                        Pms_Bll.ShowMessage(this, "Please enter the Comments more than 10 characters");
                        return;
                    }

                }
                else
                {
                    Pms_Bll.ShowMessage(this, "Please check the Stars");
                    return;
                }



            }

            #endregion
            #region   EmployeeKra  Submit,Update

            else if (e.CommandName == "btn_KraEmpSubmit")
            {
                //_obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                //_obj_Spms_AppraisalKra.APP_KRA_KRA_ID = Convert.ToInt32(lblkradt_id.Text);
                //_obj_Spms_AppraisalKra.Mode = 5;
                //DataTable dtkra3 = Pms_Bll.get_AppraisalKra(_obj_Spms_AppraisalKra);
                //if (dtkra3.Rows.Count == 0)
                //{
                //    _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                //    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                //    _obj_Spms_Appraisal.Mode = 5;

                //    DataTable dtgoal4 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

                //    _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtgoal4.Rows[0]["APPRAISAL_ID"]);
                //    _obj_Spms_AppraisalKra.Mode = 3;
                //    _obj_Spms_AppraisalKra.APP_KRA_KRA_ID = Convert.ToInt32(lblkradt_id.Text);
                //    _obj_Spms_AppraisalKra.APP_KRA_EMP_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(txtKraEmployeeFeedback.Text));
                //    _obj_Spms_AppraisalKra.APP_KRA_MGR_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(txtKraManagerFeedback.Text));
                //    _obj_Spms_AppraisalKra.APP_KRA_MGR_RATING = Convert.ToInt32(rdrtgKraMgr.Value);
                //    _obj_Spms_AppraisalKra.APP_KRA_CREATEDBY = 1;
                //    _obj_Spms_AppraisalKra.APP_KRA_CREATEDDATE = DateTime.Now;
                //    bool status = Pms_Bll.set_AppraisalKra(_obj_Spms_AppraisalKra);
                //    if (status == true)
                //    {
                //        Pms_Bll.ShowMessage(this, "Employee KraFeedback Inserted Successfully");
                //        LoadKraGrid();

                //        Rm_Appraisal_PAGE.SelectedIndex = 1;
                //        rnt_KraAvgrtg.Visible = true;
                //        Rg_Appraisal_Kra.Visible = true;
                //        Rp_Appraisal_VIEWDETAILS.Visible = true;



                //        return;
                //    }
                //}
                //else
                //{
                //    _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                //    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                //    _obj_Spms_Appraisal.Mode = 5;

                //    DataTable dtgoal7 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

                //    _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtgoal7.Rows[0]["APPRAISAL_ID"]);
                //    _obj_Spms_AppraisalKra.Mode = 6;
                //    _obj_Spms_AppraisalKra.APP_KRA_KRA_ID = Convert.ToInt32(lblkradt_id.Text);
                //    _obj_Spms_AppraisalKra.APP_KRA_EMP_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(txtKraEmployeeFeedback.Text));
                //    _obj_Spms_AppraisalKra.APP_KRA_MGR_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(txtKraManagerFeedback.Text));
                //    _obj_Spms_AppraisalKra.APP_KRA_MGR_RATING = Convert.ToInt32(rdrtgKraMgr.Value);
                //    _obj_Spms_AppraisalKra.APP_KRA_LASTMDFBY = 1;
                //    _obj_Spms_AppraisalKra.APP_KRA_LASTMDFDATE = DateTime.Now;
                //    bool status = Pms_Bll.set_AppraisalKra(_obj_Spms_AppraisalKra);
                //    if (status == true)
                //    {
                //        Pms_Bll.ShowMessage(this, "Employee KraFeedback Updated Successfully");
                //        LoadKraGrid();

                //        Rm_Appraisal_PAGE.SelectedIndex = 1;

                //        rnt_KraAvgrtg.Visible = true;
                //        Rg_Appraisal_Kra.Visible = true;
                //        Rp_Appraisal_VIEWDETAILS.Visible = true;

                //        return;
                //    }
                //}
            }
            #endregion
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsMgrAppraisal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    #region Approver Submit Method


    protected void btn_ApproverSubmit_Click(object sender, EventArgs e)
    {
        //_obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
        //_obj_Pms_EmpGoalSetting.Mode = 8;
        //_obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
        //DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
        //_obj_Spms_Appraisal = new SPMS_APPRAISAL();
        //_obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);

        //_obj_Spms_Appraisal.Mode = 5;

        //DataTable dtgoal7 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
        //_obj_Pms_AppApprover = new SPMS_APRAISALAPPROVER();
        //_obj_Pms_AppApprover.APP_APPROVER_APP_ID = Convert.ToInt32(dtgoal7.Rows[0]["APPRAISAL_ID"]);
        //_obj_Pms_AppApprover.Mode = 3;

        //_obj_Pms_AppApprover.APP_APPROVER_CREATEDBY = 1;
        //_obj_Pms_AppApprover.APP_APPROVER_CREATEDDATE = DateTime.Now;

        //bool status = Pms_Bll.set_AppApprover(_obj_Pms_AppApprover);
        //if (status == true)
        //{
        //    Pms_Bll.ShowMessage(this, "Approver Comments Inserted Successfully");

        //    _obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();
        //    _obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
        //    _obj_Spms_Appraisal = new SPMS_APPRAISAL();
        //    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);

        //    _obj_Spms_Appraisal.Mode = 5;

        //    DataTable dtg = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

        //    _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtg.Rows[0]["APPRAISAL_ID"]);
        //    _obj_Spms_AppraisalGoal.Mode = 7;
        //    DataTable dt1 = Pms_Bll.get_AppraisalGoal(_obj_Spms_AppraisalGoal);
        //    if (dt1.Rows.Count == 0)
        //    {

        //        rnt_GoalAvgrtg.Value = 0;
        //        rnt_GoalAvgrtg.Enabled = false;
        //    }
        //    else
        //    {
        //        rnt_GoalAvgrtg.Value = Convert.ToDouble(dt1.Rows[0]["APP_GOALS_MGR_RATING"]);
        //        rnt_GoalAvgrtg.Enabled = false;
        //    }
        //    _obj_Spms_Appraisal = new SPMS_APPRAISAL();
        //    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);

        //    _obj_Spms_Appraisal.Mode = 5;
        //    DataTable dtgo = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
        //    _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtgo.Rows[0]["APPRAISAL_ID"]);
        //    _obj_Spms_AppraisalKra.Mode = 7;
        //    DataTable dt6 = Pms_Bll.get_AppraisalKra(_obj_Spms_AppraisalKra);
        //    if (dt6.Rows.Count == 0)
        //    {
        //        rnt_KraAvgrtg.Value = 0;
        //        rnt_KraAvgrtg.Enabled = false;


        //    }
        //    else
        //    {
        //        rnt_KraAvgrtg.Value = Convert.ToDouble(dt6.Rows[0]["APP_KRA_MGR_RATING"]);
        //        rnt_KraAvgrtg.Enabled = false;

        //    }
        //    rcmb_BusinessUnitType.Enabled = false;
        //    rcmb_EmployeeType.Enabled = false;

        //    lbl_KraAvgRtg.Enabled = false;
        //    rnt_KraAvgrtg.Enabled = false;
        //    Rg_Appraisal_Kra.Enabled = false;

        //    return;
        //}

    }
    #endregion

    protected void btn_ApproverCancel_Click1(object sender, EventArgs e)
    {

        //rcmb_EmployeeType.ClearSelection();
        //DataTable dt = new DataTable();
        //rcmb_EmployeeType.DataSource = dt;
        //rcmb_EmployeeType.DataBind();
        //Rm_Appraisal_PAGE.SelectedIndex = 0;

        //LoadBusinessUnit();
    }
    #region laod goal,kra finalise
    public void LOADGOALmgrFINALIZE()
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
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


            _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
            _obj_Pms_EmpGoalSetting.Mode = 8;

            _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
            if (dtappid.Rows.Count != 0)
            {
                _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
            }
            DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
            if (dt.Rows.Count != 0)
            {
                GSID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
            }
            PMS_GoalSettings_Details _obj_GSdetails = new PMS_GoalSettings_Details();
            _obj_GSdetails.GSDTL_GS_ID = GSID;
            _obj_GSdetails.GS_DETAILS_MODE = 5;
            _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_details = new DataTable();
            dt_details = Pms_Bll.get_GSdetails(_obj_GSdetails);

            for (int i = 0; i <= Rg_Appraisal_Goal.Rows.Count - 1; i++)
            {
                _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                _obj_Pms_Appraisalcycle.MODE = 11;
                _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtemzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                _obj_Pms_Appraisalcycle.MODE = 8;
                if (dtemzz.Rows.Count != 0)
                {
                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                }
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtappidzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);

                _obj_Spms_Appraisal.Mode = 5;
                if (dtappidzz.Rows.Count != 0)
                {
                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz.Rows[0]["APPRCYCLE_ID"]);
                }
                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtg = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                if (dtg.Rows.Count != 0)
                {
                    _obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();
                    if (dtg.Rows.Count != 0)
                    {
                        _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtg.Rows[0]["APPRAISAL_ID"]);
                    }
                    _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    if (dt_details.Rows.Count != 0)
                    {
                        _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(dt_details.Rows[i]["GSDTL_ID"]);
                    }
                    _obj_Spms_AppraisalGoal.Mode = 8;
                    DataTable dtgoal = Pms_Bll.get_AppraisalGoal(_obj_Spms_AppraisalGoal);

                    if (dtgoal.Rows[0]["APP_GOALS_MGR_COMMENTS"] != string.Empty)
                    {
                        TextBox txtmgrfeed = new System.Web.UI.WebControls.TextBox();
                        txtmgrfeed = Rg_Appraisal_Goal.Rows[i].FindControl("txt_GoalManagerFeedback") as TextBox;
                        RadRating rdratingmgr = new Telerik.Web.UI.RadRating();
                        rdratingmgr = Rg_Appraisal_Goal.Rows[i].FindControl("rdrtg_GoalMgr") as RadRating;


                        txtmgrfeed.Text = Convert.ToString(dtgoal.Rows[0]["APP_GOALS_MGR_COMMENTS"]);
                        strgoal = txtmgrfeed.Text;

                        Tempgoal++;

                        rdratingmgr.Value = Convert.ToInt32(dtgoal.Rows[0]["APP_GOALS_MGR_RATING"]);
                        //strgoalrtg = Convert.ToInt32(rdratingmgr.Value);
                        //tempgoalrtg++;
                        //btn_goalmgrfinalise.Visible = true;
                        //btn_kramgrfinalise.Visible = false;
                    }
                }





            }


            //else
            //        {
            //            btn_goalmgrfinalise.Visible = false;
            //            btn_kramgrfinalise.Visible = false;
            //        }



            if (Tempgoal == Rg_Appraisal_Goal.Rows.Count)
            {
                btn_goalmgrfinalise.Visible = true;
                btn_kramgrfinalise.Visible = false;
            }

            else
            {
                btn_goalmgrfinalise.Visible = false;
                btn_kramgrfinalise.Visible = false;
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsMgrAppraisal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    public void LOADKRAmgrFINALIZE()
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
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


            _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
            _obj_Pms_EmpGoalSetting.Mode = 8;
            _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);

            _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
            if (dtappid.Rows.Count != 0)
            {
                _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
            }
            DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
            if (dt.Rows.Count != 0)
            {
                GSID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
            }
            PMS_GoalSettings_Details _obj_GSdetails = new PMS_GoalSettings_Details();
            _obj_GSdetails.GSDTL_GS_ID = GSID;
            _obj_GSdetails.GS_DETAILS_MODE = 5;
            _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_details = new DataTable();
            dt_details = Pms_Bll.get_GSdetails(_obj_GSdetails);
            if (dt_details.Rows.Count != 0)
            {
                _obj_Spms_GoalStgKraDtls = new SPMS_GOALSETTINGKRADETAILS();
                _obj_Spms_GoalStgKraDtls.Mode = 7;
                _obj_Spms_GoalStgKraDtls.GS_KRA_GSDTL_ID = Convert.ToInt32(dt_details.Rows[0]["GSDTL_GS_ID"]);
                _obj_Spms_GoalStgKraDtls.LASTMDFBY = Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
                _obj_Spms_GoalStgKraDtls.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt2 = Pms_Bll.get_GoalStgKraDtls(_obj_Spms_GoalStgKraDtls);


                for (int i = 0; i <= Rg_Appraisal_Kra.Rows.Count - 1; i++)
                {
                    _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                    _obj_Pms_Appraisalcycle.MODE = 11;
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtemzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                    _obj_Pms_Appraisalcycle.MODE = 8;
                    if (dtemzz.Rows.Count != 0)
                    {
                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                    }
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtappidzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                    _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);

                    _obj_Spms_Appraisal.Mode = 5;
                    _obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE = 2;
                    if (dtappidzz.Rows.Count != 0)
                    {
                        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz.Rows[0]["APPRCYCLE_ID"]);
                    }
                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtg = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                    if (dtg.Rows.Count != 0)
                    {
                        _obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                        _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtg.Rows[0]["APPRAISAL_ID"]);
                        _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Spms_AppraisalKra.APP_KRA_KRA_ID = Convert.ToInt32(dt2.Rows[i]["KRA_ID"]);
                        _obj_Spms_AppraisalKra.Mode = 8;
                        DataTable dtKra1 = Pms_Bll.get_AppraisalKra(_obj_Spms_AppraisalKra);
                        if (dtKra1.Rows.Count > 0)
                        {
                            if (dtKra1.Rows[0]["APP_KRA_MGR_COMMENTS"] != string.Empty)
                            {
                                TextBox txtKraManagerFeedback = new System.Web.UI.WebControls.TextBox();
                                txtKraManagerFeedback = Rg_Appraisal_Kra.Rows[i].FindControl("txt_KraManagerFeedback") as TextBox;
                                RadRating rdrtgKraMgr = new Telerik.Web.UI.RadRating();
                                rdrtgKraMgr = Rg_Appraisal_Kra.Rows[i].FindControl("rdrtg_KraMgr") as RadRating;



                                txtKraManagerFeedback.Text = Convert.ToString(dtKra1.Rows[0]["APP_KRA_MGR_COMMENTS"]);
                                rdrtgKraMgr.Value = Convert.ToInt32(dtKra1.Rows[0]["APP_KRA_MGR_RATING"]);

                                strkra = txtKraManagerFeedback.Text;

                                tempkra++;
                                ////strkrartg = Convert.ToInt32(rdrtgKraMgr.Value);
                                ////tempkrartg++;
                                ////btn_kramgrfinalise.Visible = true;
                                ////btn_goalmgrfinalise.Visible = false;

                            }
                        }

                    }
                }


                //else
                //       {
                //           btn_kramgrfinalise.Visible = false;
                //           btn_goalmgrfinalise.Visible = false;
                //       }

                if (tempkra == Rg_Appraisal_Kra.Rows.Count)
                {
                    btn_kramgrfinalise.Visible = true;
                    btn_goalmgrfinalise.Visible = false;
                }

                else
                {
                    btn_kramgrfinalise.Visible = false;
                    btn_goalmgrfinalise.Visible = false;
                }
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsMgrAppraisal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region goal finalclick
    protected void btn_goalmgrfinalise_Click(object sender, EventArgs e)
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
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


            _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
            _obj_Pms_EmpGoalSetting.Mode = 8;
            _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);

            _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
            if (dtappid.Rows.Count != 0)
            {
                _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
            }
            DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
            if (dt.Rows.Count != 0)
            {
                GSID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
            }
            PMS_GoalSettings_Details _obj_GSdetails = new PMS_GoalSettings_Details();
            _obj_GSdetails.GSDTL_GS_ID = GSID;
            _obj_GSdetails.GS_DETAILS_MODE = 5;
            _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_details = new DataTable();
            dt_details = Pms_Bll.get_GSdetails(_obj_GSdetails);

            _obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();
            _obj_Spms_AppraisalGoal.APP_GOALS_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
            if (dt_details.Rows.Count != 0)
            {
                _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(dt_details.Rows[0]["GSDTL_ID"]);
            }
            if (dtappid.Rows.Count != 0)
            {
                _obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFBY = Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
            }
            _obj_Spms_AppraisalGoal.Mode = 5;
            _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtgoal = Pms_Bll.get_AppraisalGoal(_obj_Spms_AppraisalGoal);
            if (dtgoal.Rows.Count != 0)
            {
                _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                _obj_Pms_Appraisalcycle.MODE = 11;
                _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtemzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                _obj_Pms_Appraisalcycle.MODE = 8;
                if (dtemzz.Rows.Count != 0)
                {
                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                }
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtappidzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                _obj_Spms_Appraisal.Mode = 2;
                if (dtappidzz.Rows.Count != 0)
                {
                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz.Rows[0]["APPRCYCLE_ID"]);
                }
                DataTable dtemp = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                if (Convert.ToInt32(dtemp.Rows[0]["APPRAISAL_APPROVALSTAGE"]) == 12)
                {

                    _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                    _obj_Spms_Appraisal.APPRAISAL_DATE = rdtp_DATEofAppraisal.SelectedDate.Value;
                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE = 13;
                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(LBL_Appraise_Id.Text);
                    _obj_Spms_Appraisal.APPRAISAL_CREATEDBY = 1;
                    _obj_Spms_Appraisal.APPRAISAL_STATUS = 2;
                    _obj_Spms_Appraisal.APPRAISAL_CREATEDDATE = DateTime.Now;
                    _obj_Spms_Appraisal.APPRAISAL_ID = Convert.ToInt32(dtemp.Rows[0]["APPRAISAL_ID"]);

                    _obj_Spms_Appraisal.Mode = 6;
                    bool status = Pms_Bll.set_Appraisal(_obj_Spms_Appraisal);
                    _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                    _obj_Pms_Appraisalcycle.MODE = 11;
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtemzz5P = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                    _obj_Pms_Appraisalcycle.MODE = 8;
                    if (dtemzz5P.Rows.Count != 0)
                    {
                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz5P.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                    }
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtappidzz5P = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                    _obj_Spms_Appraisal.Mode = 33;
                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Spms_Appraisal.APPRAISAL_GOAL_AVGRTG = Convert.ToDecimal(rnt_GoalAvgrtg.Value);
                    if (dtappidzz5P.Rows.Count != 0)
                    {
                        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz5P.Rows[0]["APPRCYCLE_ID"]);
                    }
                    bool status2 = Pms_Bll.set_Appraisal(_obj_Spms_Appraisal);
                    if (status2 == true)
                    {
                        _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                        _obj_Pms_Appraisalcycle.MODE = 11;
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtemzz57 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                        _obj_Pms_Appraisalcycle.MODE = 8;
                        if (dtemzz.Rows.Count != 0)
                        {
                            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                        }
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtappidzz57 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                        _obj_Spms_Appraisal = new SPMS_APPRAISAL();



                        _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                        if (dtappidzz57.Rows.Count != 0)
                        {

                            _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz57.Rows[0]["APPRCYCLE_ID"]);
                        }
                        _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

                        _obj_Spms_Appraisal.Mode = 5;

                        DataTable dtgoal1 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

                        if (dtgoal1.Rows.Count != 0)
                        {
                            _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtgoal1.Rows[0]["APPRAISAL_ID"]);
                        }
                        _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Spms_AppraisalGoal.Mode = 12;
                        //_obj_Spms_AppraisalGoal.APP_GOALS_AVGRTG = Convert.ToDecimal(rnt_GoalAvgrtg.Value);
                        _obj_Spms_AppraisalGoal.APP_GOALS_FINAL = 2;
                        bool status1 = Pms_Bll.set_AppraisalGoal(_obj_Spms_AppraisalGoal);
                        if (status1 == true)
                        {
                            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                            _obj_Pms_Appraisalcycle.MODE = 11;
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtemzz58 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                            _obj_Pms_Appraisalcycle.MODE = 8;
                            if (dtemzz58.Rows.Count != 0)
                            {
                                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz58.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                            }
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtappidzz58 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                            _obj_Spms_Appraisal = new SPMS_APPRAISAL();



                            _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                            if (dtappidzz58.Rows.Count != 0)
                            {
                                _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz58.Rows[0]["APPRCYCLE_ID"]);
                            }
                            _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

                            _obj_Spms_Appraisal.Mode = 5;

                            DataTable dtgoal4 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

                            _obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();
                            if (dtgoal4.Rows.Count != 0)
                            {
                                _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtgoal4.Rows[0]["APPRAISAL_ID"]);
                            }
                            _obj_Spms_AppraisalGoal.APP_GOALS_FIXED = Convert.ToString(2);
                            _obj_Spms_AppraisalGoal.Mode = 16;
                            _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            bool status10 = Pms_Bll.set_AppraisalGoal(_obj_Spms_AppraisalGoal);


                            PMS_NOTIFICATION _obj_Pms_Send_Notification;
                            _obj_Pms_LoginInfo = new PMS_LOGININFO();
                            PMS_EMPSETUP _obj_Pms_EmpSetup;
                            _obj_Pms_EmpSetup = new PMS_EMPSETUP();

                            _obj_Pms_LoginInfo = new PMS_LOGININFO();
                            _obj_Pms_EmpSetup.EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                            _obj_Pms_EmpSetup.Mode = 14;
                            _obj_Pms_EmpSetup.EMP_SETUP_LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtbuid2 = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);
                            //writtenby durga()
                            //_obj_Pms_Send_Notification = new PMS_NOTIFICATION();
                            //_obj_Pms_Send_Notification.EMPID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                            //_obj_Pms_Send_Notification.RMID = Convert.ToInt32(dtbuid2.Rows[0]["REPORTINGMGR_ID"]);
                            //bool status3 = Pms_Bll.Send_Notification(_obj_Pms_Send_Notification);


                            _obj_Pms_Send_Notification = new PMS_NOTIFICATION();
                            _obj_Pms_Send_Notification.EMPID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                            _obj_Pms_Send_Notification.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                            //sends mail to employee from manager
                            bool status4 = Pms_Bll.Send_NotificationMangerEmployee(_obj_Pms_Send_Notification);//aaa


                            _obj_Pms_Send_Notification = new PMS_NOTIFICATION();
                            _obj_Pms_Send_Notification.EMPID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                            _obj_Pms_Send_Notification.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                            //sends mail to approver from manager
                            bool status5 = Pms_Bll.Send_NotificationMangerApprover(_obj_Pms_Send_Notification);//aaa



                            _obj_Pms_LoginInfo = new PMS_LOGININFO();
                            _obj_Pms_LoginInfo.EMPID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);


                            LoadBusinessUnit();


                            Rm_Appraisal_PAGE.SelectedIndex = 0;

                            rcmb_feedback.SelectedIndex = 0;
                            //rdtp_DATEofAppraisal.SelectedDate = null;

                            //rdtp_DATEofAppraisal.SelectedDate = null;
                            Rm_Appraisal_PAGE.SelectedIndex = 0;
                            Rg_Appraisal_Kra.Visible = false;
                            Rg_Appraisal_Goal.Visible = false;


                            //rdtp_DATEofAppraisal.SelectedDate = null;



                            lblkra.Visible = false;
                            lbl_KraAvgRtg.Visible = false;
                            rnt_KraAvgrtg.Visible = false;
                            btn_kramgrfinalise.Visible = false;
                            //rtxt_Role.Text = string.Empty;
                            //rtxt_Project.Text = string.Empty;
                            //rtxt_GpMgr.Text = string.Empty;
                            //rtxt_RpMgr.Text = string.Empty;
                            //rtxt_AppraisalCycle.Text = string.Empty;
                            //rtxt_Role.Enabled = true;
                            //rtxt_GpMgr.Enabled = true;
                            //rtxt_Project.Enabled = true;
                            //rtxt_AppraisalCycle.Enabled = true;
                            //rtxt_RpMgr.Enabled = true;
                            //rcmb_EmployeeType.SelectedIndex = 0;
                            rcmb_feedback.Enabled = false;

                            lblgoal.Visible = false;
                            lbl_GoalAvgRtg.Visible = false;
                            rnt_GoalAvgrtg.Visible = false;
                            btn_goalmgrfinalise.Visible = false;
                            lnk_Idp.Visible = false;

                            rcmb_feedback.Enabled = false;
                            //rcmb_EmployeeType.ClearSelection();
                            //rcmb_EmployeeType.Items.Clear();
                            //rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                            //rtxt_RpMgr.Text = string.Empty;
                            //rtxt_Role.Text = string.Empty;
                            //rtxt_GpMgr.Text = string.Empty;
                            //rtxt_Project.Text = string.Empty;
                            //rtxt_AppraisalCycle.Text = string.Empty;

                            rcmb_BusinessUnitType.SelectedIndex = 0;
                            rcmb_EmployeeType.ClearSelection();
                            rcmb_EmployeeType.Items.Clear();
                            rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                            rtxt_RpMgr.Text = string.Empty;
                            rtxt_Role.Text = string.Empty;
                            rtxt_GpMgr.Text = string.Empty;
                            rtxt_Project.Text = string.Empty;
                            rtxt_AppraisalCycle.Text = string.Empty;
                            Pms_Bll.ShowMessage(this, "Manager Feedback finalised Successfully");
                            Pms_Bll.ShowMessage(this, "Notification Send");
                            return;

                        }
                    }
                }
                else
                {
                    _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                    _obj_Spms_Appraisal.APPRAISAL_DATE = rdtp_DATEofAppraisal.SelectedDate.Value;
                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE = 14;
                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(LBL_Appraise_Id.Text);
                    _obj_Spms_Appraisal.APPRAISAL_CREATEDBY = 1;
                    _obj_Spms_Appraisal.APPRAISAL_STATUS = 2;
                    _obj_Spms_Appraisal.APPRAISAL_CREATEDDATE = DateTime.Now;
                    if (dtemp.Rows.Count != 0)
                    {
                        _obj_Spms_Appraisal.APPRAISAL_ID = Convert.ToInt32(dtemp.Rows[0]["APPRAISAL_ID"]);
                    }
                    _obj_Spms_Appraisal.Mode = 6;
                    bool status = Pms_Bll.set_Appraisal(_obj_Spms_Appraisal);
                    _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                    _obj_Pms_Appraisalcycle.MODE = 11;
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtemzz6N = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                    _obj_Pms_Appraisalcycle.MODE = 8;
                    if (dtemzz6N.Rows.Count != 0)
                    {
                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz6N.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                    }
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtappidzz6N = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                    _obj_Spms_Appraisal.Mode = 33;
                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Spms_Appraisal.APPRAISAL_GOAL_AVGRTG = Convert.ToDecimal(rnt_GoalAvgrtg.Value);
                    if (dtappidzz6N.Rows.Count != 0)
                    {
                        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz6N.Rows[0]["APPRCYCLE_ID"]);
                    }
                    bool status2 = Pms_Bll.set_Appraisal(_obj_Spms_Appraisal);
                    if (status2 == true)
                    {
                        _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                        _obj_Pms_Appraisalcycle.MODE = 11;
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtemzz61 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                        _obj_Pms_Appraisalcycle.MODE = 8;
                        if (dtemzz61.Rows.Count != 0)
                        {
                            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz61.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                        }
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtappidzz61 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                        _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                        _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                        if (dtappidzz61.Rows.Count != 0)
                        {
                            _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz61.Rows[0]["APPRCYCLE_ID"]);
                        }
                        _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Spms_Appraisal.Mode = 5;

                        DataTable dtgoal1 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                        if (dtgoal1.Rows.Count != 0)
                        {
                            _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtgoal1.Rows[0]["APPRAISAL_ID"]);
                        }
                        _obj_Spms_AppraisalGoal.Mode = 12;
                        //_obj_Spms_AppraisalGoal.APP_GOALS_AVGRTG = Convert.ToDecimal(rnt_GoalAvgrtg.Value);
                        _obj_Spms_AppraisalGoal.APP_GOALS_FINAL = 2;
                        _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        bool status1 = Pms_Bll.set_AppraisalGoal(_obj_Spms_AppraisalGoal);
                        if (status1 == true)
                        {
                            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                            _obj_Pms_Appraisalcycle.MODE = 11;
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtemzz63 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                            _obj_Pms_Appraisalcycle.MODE = 8;
                            if (dtemzz63.Rows.Count != 0)
                            {
                                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz63.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                            }
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtappidzz63 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                            _obj_Spms_Appraisal = new SPMS_APPRAISAL();



                            _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                            if (dtappidzz63.Rows.Count != 0)
                            {
                                _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz63.Rows[0]["APPRCYCLE_ID"]);
                            }
                            _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Spms_Appraisal.Mode = 5;

                            DataTable dtgoal4 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

                            _obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();
                            if (dtgoal4.Rows.Count != 0)
                            {
                                _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtgoal4.Rows[0]["APPRAISAL_ID"]);
                            }
                            _obj_Spms_AppraisalGoal.APP_GOALS_FIXED = Convert.ToString(2);
                            _obj_Spms_AppraisalGoal.Mode = 16;
                            _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            bool status10 = Pms_Bll.set_AppraisalGoal(_obj_Spms_AppraisalGoal);


                            PMS_NOTIFICATION _obj_Pms_Send_Notification;
                            _obj_Pms_LoginInfo = new PMS_LOGININFO();
                            PMS_EMPSETUP _obj_Pms_EmpSetup;
                            _obj_Pms_EmpSetup = new PMS_EMPSETUP();

                            _obj_Pms_LoginInfo = new PMS_LOGININFO();
                            _obj_Pms_EmpSetup.EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                            _obj_Pms_EmpSetup.Mode = 14;
                            _obj_Pms_EmpSetup.EMP_SETUP_LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtbuid2 = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);
                            //writtenby durga()
                            //_obj_Pms_Send_Notification = new PMS_NOTIFICATION();
                            //_obj_Pms_Send_Notification.EMPID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                            //_obj_Pms_Send_Notification.RMID = Convert.ToInt32(dtbuid2.Rows[0]["REPORTINGMGR_ID"]);
                            //bool status3 = Pms_Bll.Send_Notification(_obj_Pms_Send_Notification);


                            _obj_Pms_Send_Notification = new PMS_NOTIFICATION();
                            _obj_Pms_Send_Notification.EMPID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                            //sends mail to employee from manager
                            _obj_Pms_Send_Notification.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                            bool status4 = Pms_Bll.Send_NotificationMangerEmployee(_obj_Pms_Send_Notification);//aaa


                            _obj_Pms_Send_Notification = new PMS_NOTIFICATION();
                            _obj_Pms_Send_Notification.EMPID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                            //sends mail to approver from manager
                            _obj_Pms_Send_Notification.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                            bool status5 = Pms_Bll.Send_NotificationMangerApprover(_obj_Pms_Send_Notification);//aaa









                            _obj_Pms_LoginInfo = new PMS_LOGININFO();
                            _obj_Pms_LoginInfo.EMPID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);


                            LoadBusinessUnit();


                            Rm_Appraisal_PAGE.SelectedIndex = 0;


                            rcmb_feedback.SelectedIndex = 0;
                            //rdtp_DATEofAppraisal.SelectedDate = null;

                            //rdtp_DATEofAppraisal.SelectedDate = null;
                            Rm_Appraisal_PAGE.SelectedIndex = 0;
                            Rg_Appraisal_Kra.Visible = false;
                            Rg_Appraisal_Goal.Visible = false;


                            //rdtp_DATEofAppraisal.SelectedDate = null;



                            lblkra.Visible = false;
                            lbl_KraAvgRtg.Visible = false;
                            rnt_KraAvgrtg.Visible = false;
                            btn_kramgrfinalise.Visible = false;
                            //rtxt_Role.Text = string.Empty;
                            //rtxt_Project.Text = string.Empty;
                            //rtxt_GpMgr.Text = string.Empty;
                            //rtxt_RpMgr.Text = string.Empty;
                            //rtxt_AppraisalCycle.Text = string.Empty;
                            //rtxt_Role.Enabled = true;
                            //rtxt_GpMgr.Enabled = true;
                            //rtxt_Project.Enabled = true;
                            //rtxt_AppraisalCycle.Enabled = true;
                            //rtxt_RpMgr.Enabled = true;
                            //rcmb_EmployeeType.SelectedIndex = 0;
                            rcmb_feedback.Enabled = false;
                            //rcmb_feedback.Enabled = true;
                            lblgoal.Visible = false;
                            lbl_GoalAvgRtg.Visible = false;
                            rnt_GoalAvgrtg.Visible = false;
                            btn_goalmgrfinalise.Visible = false;
                            lnk_Idp.Visible = false;

                            rcmb_BusinessUnitType.SelectedIndex = 0;
                            rcmb_EmployeeType.ClearSelection();
                            rcmb_EmployeeType.Items.Clear();
                            rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                            rtxt_RpMgr.Text = string.Empty;
                            rtxt_Role.Text = string.Empty;
                            rtxt_GpMgr.Text = string.Empty;
                            rtxt_Project.Text = string.Empty;
                            rtxt_AppraisalCycle.Text = string.Empty;

                            Pms_Bll.ShowMessage(this, "Manager Feedback finalised Successfully");
                            Pms_Bll.ShowMessage(this, "Notification Send");
                            return;
                        }
                    }
                }
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsMgrAppraisal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    #region KRAFINALISECLICK

    protected void btn_kramgrfinalise_Click(object sender, EventArgs e)
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
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


            _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
            _obj_Pms_EmpGoalSetting.Mode = 8;

            _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
            if (dtappid.Rows.Count != 0)
            {

                _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
            }
            DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
            if (dt.Rows.Count != 0)
            {
                GSID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
            }
            PMS_GoalSettings_Details _obj_GSdetails = new PMS_GoalSettings_Details();
            _obj_GSdetails.GSDTL_GS_ID = GSID;
            _obj_GSdetails.GS_DETAILS_MODE = 5;
            _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_details = new DataTable();
            dt_details = Pms_Bll.get_GSdetails(_obj_GSdetails);
            if (dt_details.Rows.Count != 0)
            {
                _obj_Spms_GoalStgKraDtls = new SPMS_GOALSETTINGKRADETAILS();
                _obj_Spms_GoalStgKraDtls.Mode = 7;
                _obj_Spms_GoalStgKraDtls.GS_KRA_GSDTL_ID = Convert.ToInt32(dt_details.Rows[0]["GSDTL_GS_ID"]);
                _obj_Spms_GoalStgKraDtls.LASTMDFBY = Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
                _obj_Spms_GoalStgKraDtls.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt2 = Pms_Bll.get_GoalStgKraDtls(_obj_Spms_GoalStgKraDtls);





                _obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                if (dt2.Rows.Count != 0)
                {
                    _obj_Spms_AppraisalKra.APP_KRA_KRA_ID = Convert.ToInt32(dt2.Rows[0]["KRA_ID"]);
                }
                _obj_Spms_AppraisalKra.APP_KRA_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                _obj_Spms_AppraisalKra.Mode = 5;
                _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                if (dtappid.Rows.Count != 0)
                {
                    _obj_Spms_AppraisalKra.APP_KRA_LASTMDFBY = Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
                }
                DataTable dtkra3 = Pms_Bll.get_AppraisalKra(_obj_Spms_AppraisalKra);
                if (dtkra3.Rows.Count != 0)
                {
                    _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                    _obj_Pms_Appraisalcycle.MODE = 11;
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtemzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                    _obj_Pms_Appraisalcycle.MODE = 8;
                    if (dtemzz.Rows.Count != 0)
                    {
                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                    }
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtappidzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                    _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                    _obj_Spms_Appraisal.Mode = 2;
                    if (dtappidzz.Rows.Count != 0)
                    {
                        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz.Rows[0]["APPRCYCLE_ID"]);
                    }
                    DataTable dtemp = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                    if (Convert.ToInt32(dtemp.Rows[0]["APPRAISAL_APPROVALSTAGE"]) == 12)
                    {

                        _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                        _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                        _obj_Spms_Appraisal.APPRAISAL_DATE = rdtp_DATEofAppraisal.SelectedDate.Value;
                        _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE = 13;
                        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(LBL_Appraise_Id.Text);
                        _obj_Spms_Appraisal.APPRAISAL_STATUS = 2;
                        _obj_Spms_Appraisal.APPRAISAL_CREATEDBY = 1;
                        _obj_Spms_Appraisal.APPRAISAL_CREATEDDATE = DateTime.Now;
                        if (dtemp.Rows.Count != 0)
                        {
                            _obj_Spms_Appraisal.APPRAISAL_ID = Convert.ToInt32(dtemp.Rows[0]["APPRAISAL_ID"]);
                        }
                        _obj_Spms_Appraisal.Mode = 6;
                        bool status = Pms_Bll.set_Appraisal(_obj_Spms_Appraisal);
                        _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                        _obj_Pms_Appraisalcycle.MODE = 11;
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtemzz60 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                        _obj_Pms_Appraisalcycle.MODE = 8;
                        if (dtemzz60.Rows.Count != 0)
                        {
                            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz60.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                        }
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtappidzz60 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                        _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                        _obj_Spms_Appraisal.Mode = 32;
                        _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        if (dtappidzz60.Rows.Count != 0)
                        {
                            _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz60.Rows[0]["APPRCYCLE_ID"]);
                        }
                        _obj_Spms_Appraisal.APPRAISAL_KRA_AVGRTG = Convert.ToDecimal(rnt_KraAvgrtg.Value);
                        bool status2 = Pms_Bll.set_Appraisal(_obj_Spms_Appraisal);
                        if (status2 == true)
                        {
                            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                            _obj_Pms_Appraisalcycle.MODE = 11;
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtemzz65 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                            _obj_Pms_Appraisalcycle.MODE = 8;
                            if (dtemzz65.Rows.Count != 0)
                            {
                                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz65.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                            }
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtappidzz65 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);



                            _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                            _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                            if (dtappidzz65.Rows.Count != 0)
                            {
                                _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz65.Rows[0]["APPRCYCLE_ID"]);
                            }

                            _obj_Spms_Appraisal.Mode = 5;

                            DataTable dtgoal1 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

                            _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtgoal1.Rows[0]["APPRAISAL_ID"]);
                            //for (int p = 0; p < Rg_Appraisal_Kra.Rows.Count; p++)
                            //{
                            //    _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtgoal1.Rows[0]["APPRAISAL_ID"]);
                            //    _obj_Spms_AppraisalKra.APP_KRA_KRA_ID = Convert.ToInt32(dt2.Rows[p]["KRA_ID"]);

                            //    TextBox txtKraManagerFeedback = new System.Web.UI.WebControls.TextBox();

                            //    RadRating rdrtgKraMgr = new Telerik.Web.UI.RadRating();
                            //    txtKraManagerFeedback = Rg_Appraisal_Kra.Rows[p].FindControl("txt_KraManagerFeedback") as TextBox;

                            //    rdrtgKraMgr = Rg_Appraisal_Kra.Rows[p].FindControl("rdrtg_KraMgr") as RadRating;
                            //    _obj_Spms_AppraisalKra.APP_KRA_MGR_COMMENTS = Convert.ToString(txtKraManagerFeedback.Text);
                            //    _obj_Spms_AppraisalKra.APP_KRA_MGR_RATING = rdrtgKraMgr.Value;
                            //    _obj_Spms_AppraisalKra.Mode = 16;
                            //    bool status6 = Pms_Bll.set_AppraisalKra(_obj_Spms_AppraisalKra);

                            //}

                            _obj_Spms_AppraisalKra.Mode = 12;
                            _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Spms_AppraisalKra.APP_KRA_FINAL = 2;
                            //_obj_Spms_AppraisalKra.APP_KRA_AVGRTG = Convert.ToDecimal(rnt_KraAvgrtg.Value);
                            bool status1 = Pms_Bll.set_AppraisalKra(_obj_Spms_AppraisalKra);
                            if (status1 == true)
                            {
                                _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                                _obj_Pms_Appraisalcycle.MODE = 11;
                                _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dtemzz68 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                _obj_Pms_Appraisalcycle.MODE = 8;
                                if (dtemzz68.Rows.Count != 0)
                                {
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz68.Rows[0]["EMP_BUSINESSUNIT_ID"]);

                                }
                                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dtappidzz68 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                                _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

                                _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                if (dtappidzz68.Rows.Count != 0)
                                {
                                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz68.Rows[0]["APPRCYCLE_ID"]);
                                }

                                _obj_Spms_Appraisal.Mode = 5;

                                DataTable dtgoal4 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

                                _obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                                if (dtgoal4.Rows.Count != 0)
                                {
                                    _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtgoal4.Rows[0]["APPRAISAL_ID"]);
                                }
                                _obj_Spms_AppraisalKra.APP_KRA_FIXED = Convert.ToString(2);
                                _obj_Spms_AppraisalKra.Mode = 17;
                                _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                bool status10 = Pms_Bll.set_AppraisalKra(_obj_Spms_AppraisalKra);






                                rcmb_feedback.SelectedIndex = 0;
                                //rdtp_DATEofAppraisal.SelectedDate = null;
                                Rm_Appraisal_PAGE.SelectedIndex = 0;
                                Rg_Appraisal_Kra.Visible = false;
                                Rg_Appraisal_Goal.Visible = false;

                                //rcmb_feedback.SelectedIndex = 0;
                                //rdtp_DATEofAppraisal.SelectedDate = null;



                                lblkra.Visible = false;
                                lbl_KraAvgRtg.Visible = false;
                                rnt_KraAvgrtg.Visible = false;
                                btn_kramgrfinalise.Visible = false;
                                //rtxt_Role.Text = string.Empty;
                                //rtxt_Project.Text = string.Empty;
                                //rtxt_GpMgr.Text = string.Empty;
                                //rtxt_RpMgr.Text = string.Empty;
                                //rtxt_AppraisalCycle.Text = string.Empty;
                                //rtxt_Role.Enabled = true;
                                //rtxt_GpMgr.Enabled = true;
                                //rtxt_Project.Enabled = true;
                                //rtxt_AppraisalCycle.Enabled = true;
                                //rtxt_RpMgr.Enabled = true;
                                //rcmb_EmployeeType.SelectedIndex = 0;
                                rcmb_feedback.Enabled = false;
                                //rcmb_feedback.Enabled = true;
                                LNK_IDP22.Visible = false;
                                rcmb_BusinessUnitType.SelectedIndex = 0;
                                rcmb_EmployeeType.ClearSelection();
                                rcmb_EmployeeType.Items.Clear();
                                rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                                rtxt_RpMgr.Text = string.Empty;
                                rtxt_Role.Text = string.Empty;
                                rtxt_GpMgr.Text = string.Empty;
                                rtxt_Project.Text = string.Empty;
                                rtxt_AppraisalCycle.Text = string.Empty;
                                Pms_Bll.ShowMessage(this, "Manager Feedback Finalised Successfully");
                                return;

                            }

                        }
                    }
                    else
                    {
                        _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                        _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                        _obj_Spms_Appraisal.APPRAISAL_DATE = rdtp_DATEofAppraisal.SelectedDate.Value;
                        _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE = 14;
                        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(LBL_Appraise_Id.Text);
                        _obj_Spms_Appraisal.APPRAISAL_STATUS = 2;
                        _obj_Spms_Appraisal.APPRAISAL_CREATEDBY = 1;
                        _obj_Spms_Appraisal.APPRAISAL_CREATEDDATE = DateTime.Now;
                        if (dtemp.Rows.Count != 0)
                        {
                            _obj_Spms_Appraisal.APPRAISAL_ID = Convert.ToInt32(dtemp.Rows[0]["APPRAISAL_ID"]);
                        }
                        _obj_Spms_Appraisal.Mode = 6;

                        bool status = Pms_Bll.set_Appraisal(_obj_Spms_Appraisal);

                        _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                        _obj_Pms_Appraisalcycle.MODE = 11;
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtemzz60 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                        _obj_Pms_Appraisalcycle.MODE = 8;
                        if (dtemzz60.Rows.Count != 0)
                        {
                            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz60.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                        }
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtappidzz60 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                        _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                        _obj_Spms_Appraisal.Mode = 32;
                        _obj_Spms_Appraisal.APPRAISAL_KRA_AVGRTG = Convert.ToDecimal(rnt_KraAvgrtg.Value);
                        if (dtappidzz60.Rows.Count != 0)
                        {
                            _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz60.Rows[0]["APPRCYCLE_ID"]);
                        }
                        _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        bool status2 = Pms_Bll.set_Appraisal(_obj_Spms_Appraisal);
                        if (status2 == true)
                        {
                            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                            _obj_Pms_Appraisalcycle.MODE = 11;
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtemzz70 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                            _obj_Pms_Appraisalcycle.MODE = 8;
                            if (dtemzz70.Rows.Count != 0)
                            {
                                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz70.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                            }
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtappidzz70 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                            _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                            _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                            if (dtappidzz70.Rows.Count != 0)
                            {
                                _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz70.Rows[0]["APPRCYCLE_ID"]);
                            }
                            _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Spms_Appraisal.Mode = 5;

                            DataTable dtgoal1 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                            if (dtgoal1.Rows.Count != 0)
                            {
                                _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtgoal1.Rows[0]["APPRAISAL_ID"]);
                            }
                            _obj_Spms_AppraisalKra.Mode = 12;
                            _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Spms_AppraisalKra.APP_KRA_FINAL = 2;
                            //_obj_Spms_AppraisalKra.APP_KRA_AVGRTG = Convert.ToDecimal(rnt_KraAvgrtg.Value);
                            bool status1 = Pms_Bll.set_AppraisalKra(_obj_Spms_AppraisalKra);
                            if (status1 == true)
                            {
                                _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                                _obj_Pms_Appraisalcycle.MODE = 11;
                                _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dtemzz81 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                _obj_Pms_Appraisalcycle.MODE = 8;
                                if (dtemzz81.Rows.Count != 0)
                                {
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz81.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                                }
                                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dtappidzz81 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                                _obj_Spms_Appraisal = new SPMS_APPRAISAL();


                                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

                                _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                if (dtappidzz81.Rows.Count != 0)
                                {
                                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz81.Rows[0]["APPRCYCLE_ID"]);

                                }
                                _obj_Spms_Appraisal.Mode = 5;

                                DataTable dtgoal4 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

                                _obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                                if (dtgoal4.Rows.Count != 0)
                                {
                                    _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtgoal4.Rows[0]["APPRAISAL_ID"]);
                                }
                                _obj_Spms_AppraisalKra.APP_KRA_FIXED = Convert.ToString(2);
                                _obj_Spms_AppraisalKra.Mode = 17;
                                _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                bool status10 = Pms_Bll.set_AppraisalKra(_obj_Spms_AppraisalKra);






                                rcmb_feedback.SelectedIndex = 0;
                                //rdtp_DATEofAppraisal.SelectedDate = null;
                                Rm_Appraisal_PAGE.SelectedIndex = 0;
                                Rg_Appraisal_Kra.Visible = false;
                                Rg_Appraisal_Goal.Visible = false;

                                //rcmb_feedback.SelectedIndex = 0;
                                //rdtp_DATEofAppraisal.SelectedDate = null;



                                lblkra.Visible = false;
                                lbl_KraAvgRtg.Visible = false;
                                rnt_KraAvgrtg.Visible = false;
                                btn_kramgrfinalise.Visible = false;
                                //rtxt_Role.Text = string.Empty;
                                //rtxt_Project.Text = string.Empty;
                                //rtxt_GpMgr.Text = string.Empty;
                                //rtxt_RpMgr.Text = string.Empty;
                                //rtxt_AppraisalCycle.Text = string.Empty;
                                //rtxt_Role.Enabled = true;
                                //rtxt_GpMgr.Enabled = true;
                                //rtxt_Project.Enabled = true;
                                //rtxt_AppraisalCycle.Enabled = true;
                                //rtxt_RpMgr.Enabled = true;
                                //rcmb_EmployeeType.SelectedIndex = 0;
                                rcmb_feedback.Enabled = false;
                                LNK_IDP22.Visible = false;
                                //rcmb_feedback.Enabled = true;
                                rcmb_BusinessUnitType.SelectedIndex = 0;
                                rcmb_EmployeeType.ClearSelection();
                                rcmb_EmployeeType.Items.Clear();
                                rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                                rtxt_RpMgr.Text = string.Empty;
                                rtxt_Role.Text = string.Empty;
                                rtxt_GpMgr.Text = string.Empty;
                                rtxt_Project.Text = string.Empty;
                                rtxt_AppraisalCycle.Text = string.Empty;
                                Pms_Bll.ShowMessage(this, "Manager Feedback Finalised Successfully");
                                return;

                            }
                        }
                    }
                }
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsMgrAppraisal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion


    protected void Rg_Appraisal_Kra_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
