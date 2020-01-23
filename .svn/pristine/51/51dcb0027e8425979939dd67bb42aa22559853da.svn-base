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

public partial class PMS_frm_PmsApp : System.Web.UI.Page
{
    SPMS_EMPGOALSETTING _obj_Pms_EmpGoalSetting;
    SPMS_APPRAISAL _obj_Spms_Appraisal;
    SPMS_APPRAISALGOAL _obj_Spms_AppraisalGoal;
    SPMS_GOALSETTINGKRADETAILS _obj_Spms_GoalStgKraDtls;
    SPMS_APPRAISALKRA _obj_Spms_AppraisalKra;
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

    #region pageload
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Self Appraisal");
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
                    // Rg_Appraisal_Goal.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Save.Visible = false;
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
                LoadEmployees();

                rtxt_RpMgr.Enabled = false;
                rtxt_GpMgr.Enabled = false;
                rdtp_DATEofAppraisal.SelectedDate = DateTime.Now;
                rdtp_DATEofAppraisal.Enabled = false;
                Rm_Appraisal_PAGE.SelectedIndex = 0;
                Rm_Appraisal_Kra.Visible = false;
                Rm_Appraisal_Goal.Visible = false;
                Rm_Kra_Details.Visible = false;
                Rm_AppraisalDiscussion.Visible = false;

            }

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion


    #region LoadMgrppraisalDiscussion
    /// <summary>
    /// here i am loading manager details based on employee selection(not needed)
    /// </summary>
    /// <param name="dt"></param>
    protected void BindManager(DataTable dt)
    {
        //rcmb_ManagerType.Items.Clear();
        //rcmb_ManagerType.DataSource = dt;
        //rcmb_ManagerType.DataTextField = "EMPNAME";
        //rcmb_ManagerType.DataValueField = "EMP_ID";
        //rcmb_ManagerType.DataBind();
        //rcmb_ManagerType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
    }


    #endregion

    #region Save,CancelAppraisalDisc

    /// <summary>
    /// here manager and employee acn enter comments
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_Save_Click(object sender, EventArgs e)
    {

        //try
        //{
        //    if (lbl_App_Discussion_Id.Text == "")
        //    {
        //        _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
        //        _obj_Pms_EmpGoalSetting.Mode = 8;
        //        _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
        //        DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);

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
        //        DataTable dtgoal7 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
        //        _obj_Pms_AppDiscDtls = new SPMS_APRAISALDISCUSSION();
        //        _obj_Pms_AppDiscDtls.APP_DISCUSSION_APP_ID = Convert.ToInt32(dtgoal7.Rows[0]["APPRAISAL_ID"]);
        //        _obj_Pms_AppDiscDtls.APP_DISCUSSION_EMP_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_EmployeeCommentsAppDiscussion.Text));
        //        _obj_Pms_AppDiscDtls.APP_DISCUSSION_MGR_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_MgrCommentsAppDiscussion.Text));
        //        _obj_Pms_AppDiscDtls.APP_DISCUSSION_DATE = rdtp_DateofDiscussion.SelectedDate.Value;
        //        _obj_Pms_AppDiscDtls.APP_DISCUSSION_CREATEDBY = 1; // ### Need to Get the Session
        //        _obj_Pms_AppDiscDtls.APP_DISCUSSION_CREATEDDATE = DateTime.Now;
        //        _obj_Pms_AppDiscDtls.Mode = 3;
        //        bool status = Pms_Bll.set_AppDiscDtls(_obj_Pms_AppDiscDtls);
        //        if (status == true)
        //        {
        //            Pms_Bll.ShowMessage(this, "Appraisal Discussion given Successfully");
        //            //LoadBusinessUnit();
        //            rcmb_EmployeeType.ClearSelection();
        //            DataTable dt9 = new DataTable();
        //            rcmb_EmployeeType.DataSource = dt9;
        //            rcmb_EmployeeType.DataBind();
        //            rcmb_EmployeeType.Enabled = true;
        //            rcmb_BusinessUnitType.Enabled = true;

        //            Rm_Appraisal_PAGE.SelectedIndex = 0;
        //            Rm_Appraisal_Kra.Visible = false;
        //            Rm_Appraisal_Goal.Visible = false;
        //            Rm_Kra_Details.Visible = false;
        //            Rm_AppraisalDiscussion.Visible = false;

        //            return;
        //        }
        //    }

        //}
        //catch (Exception ex)
        //{
        //    Pms_Bll.ShowMessage(this, ex.Message.ToString());
        //    return;
        //}
    }


    protected void btn_Cancel_Click(object sender, EventArgs e)
    {


    }

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
            //PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            //_obj_Pms_Appraisalcycle.MODE = 11;
            //_obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(Session["emp_id"]);//where i am passing employee to get bunit
            //DataTable dtem = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

            //_obj_Pms_Appraisalcycle.MODE = 8;
            //_obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem.Rows[0]["EMP_BUSINESSUNIT_ID"]);
            //DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
            ////where i am getting apprisal cycle 



            //_obj_GS.GS_APPRAISAL_CYCLE = Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);


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
                _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
            }
            else
            {
                _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = "0";
            }
            _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);


            if (dt.Rows.Count != 0)
            {
                int GSID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);

                _obj_GSdetails.GSDTL_GS_ID = GSID;
            }
            _obj_GSdetails.LASTMDFBY = Convert.ToInt16(Session["ORG_ID"]);
            _obj_GSdetails.GS_DETAILS_MODE = 5;
            DataTable dt_details = new DataTable();
            dt_details = Pms_Bll.get_GSdetails(_obj_GSdetails);


            if (dt_details.Rows.Count != 0)
            {
                Rg_Appraisal_Goal.DataSource = dt_details;
                Rg_Appraisal_Goal.DataBind();



                Rm_Appraisal_PAGE.SelectedIndex = 0;
                Rm_Appraisal_Goal.Visible = true;

                Rg_Appraisal_Goal.Visible = true;

                Rp_Appraisal_VIEWDETAILS.Visible = true;
                Rm_Appraisal_Kra.SelectedIndex = 0;
                Rm_Kra_Details.Visible = true;


                _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                _obj_Pms_Appraisalcycle.MODE = 11;
                _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtemzL = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                _obj_Pms_Appraisalcycle.MODE = 8;
                if (dtem.Rows.Count != 0)
                {
                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzL.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                }
                else
                {
                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;
                }
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtappidzL = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                if (dtappidzL.Rows.Count != 0)
                {
                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzL.Rows[0]["APPRCYCLE_ID"]);
                }
                else
                {
                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = 0;
                }
                _obj_Spms_Appraisal.Mode = 34;
                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtgoal9 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                if (dtgoal9.Rows.Count == 0)
                {

                    for (int i = 0; i < Rg_Appraisal_Goal.Rows.Count; i++)
                    {
                        _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                        _obj_Pms_Appraisalcycle.MODE = 11;
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtemzLa = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                        _obj_Pms_Appraisalcycle.MODE = 8;
                        if (dtemzLa.Rows.Count != 0)
                        {
                            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzLa.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                        }
                        else
                        {
                            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;
                        }
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtappidzLa = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                        RadRating rdrtgtargetachieve = new Telerik.Web.UI.RadRating();
                        rdrtgtargetachieve = Rg_Appraisal_Goal.Rows[i].FindControl("ratingPie") as RadRating;

                        _obj_Pms_EmpGoalSetting.Mode = 16;
                        _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                        if (dtappidzLa.Rows.Count != 0)
                        {
                            _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(dtappidzLa.Rows[0]["APPRCYCLE_ID"]);
                        }
                        else
                        {
                            _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = "0";

                        }
                        _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dt22 = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
                        if ((Convert.ToString(dt22.Rows[i]["GSDTL_TARGET_ACHEIVED"]) != string.Empty))
                        {
                            int k = Convert.ToInt32(dt22.Rows[i]["GSDTL_TARGET_ACHEIVED"]);
                            if (k == 1)
                            {
                                rdrtgtargetachieve.Value = Convert.ToInt32(dt22.Rows[i]["GSDTL_TARGET_ACHEIVED"]);
                                rdrtgtargetachieve.Enabled = true;
                                rdrtgtargetachieve.ToolTip = "0%";

                            }
                            else if (k == 2)
                            {
                                rdrtgtargetachieve.ToolTip = "25%";
                                rdrtgtargetachieve.Value = Convert.ToInt32(dt22.Rows[i]["GSDTL_TARGET_ACHEIVED"]);
                                rdrtgtargetachieve.Enabled = true;

                            }
                            else if (k == 3)
                            {
                                rdrtgtargetachieve.Value = Convert.ToInt32(dt22.Rows[i]["GSDTL_TARGET_ACHEIVED"]);
                                rdrtgtargetachieve.Enabled = true;
                                rdrtgtargetachieve.ToolTip = "50%";
                            }
                            else if (k == 4)
                            {
                                rdrtgtargetachieve.Value = Convert.ToInt32(dt22.Rows[i]["GSDTL_TARGET_ACHEIVED"]);
                                rdrtgtargetachieve.Enabled = true;
                                rdrtgtargetachieve.ToolTip = "75%";

                            }
                            else if (k == 5)
                            {
                                rdrtgtargetachieve.Value = Convert.ToInt32(dt22.Rows[i]["GSDTL_TARGET_ACHEIVED"]);
                                rdrtgtargetachieve.Enabled = true;
                                rdrtgtargetachieve.ToolTip = "100%";
                            }
                            else if (k == 0)
                            {

                                rdrtgtargetachieve.Enabled = true;

                            }
                        }
                        else
                        {
                            rdrtgtargetachieve.Value = 0;
                            rdrtgtargetachieve.Enabled = true;
                        }
                    }

                }

                else if ((Convert.ToInt32(dtgoal9.Rows[0]["APP_EMP_GOAL_FIXED"]) == 1))
                {
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
                        else
                        {
                            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;
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
                        else
                        {
                            _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = "0";

                        }
                        _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dt22 = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
                        if ((Convert.ToString(dt22.Rows[i]["GSDTL_TARGET_ACHEIVED"]) != string.Empty))
                        {
                            int k = Convert.ToInt32(dt22.Rows[i]["GSDTL_TARGET_ACHEIVED"]);
                            if (k == 1)
                            {
                                rdrtgtargetachieve.Value = Convert.ToInt32(dt22.Rows[i]["GSDTL_TARGET_ACHEIVED"]);
                                rdrtgtargetachieve.Enabled = true;
                                rdrtgtargetachieve.ToolTip = "0%";

                            }
                            else if (k == 2)
                            {
                                rdrtgtargetachieve.ToolTip = "25%";
                                rdrtgtargetachieve.Value = Convert.ToInt32(dt22.Rows[i]["GSDTL_TARGET_ACHEIVED"]);
                                rdrtgtargetachieve.Enabled = true;

                            }
                            else if (k == 3)
                            {
                                rdrtgtargetachieve.Value = Convert.ToInt32(dt22.Rows[i]["GSDTL_TARGET_ACHEIVED"]);
                                rdrtgtargetachieve.Enabled = true;
                                rdrtgtargetachieve.ToolTip = "50%";
                            }
                            else if (k == 4)
                            {
                                rdrtgtargetachieve.Value = Convert.ToInt32(dt22.Rows[i]["GSDTL_TARGET_ACHEIVED"]);
                                rdrtgtargetachieve.Enabled = true;
                                rdrtgtargetachieve.ToolTip = "75%";

                            }
                            else if (k == 5)
                            {
                                rdrtgtargetachieve.Value = Convert.ToInt32(dt22.Rows[i]["GSDTL_TARGET_ACHEIVED"]);
                                rdrtgtargetachieve.Enabled = true;
                                rdrtgtargetachieve.ToolTip = "100%";
                            }
                            else if (k == 0)
                            {

                                rdrtgtargetachieve.Enabled = true;

                            }
                        }
                        else
                        {
                            rdrtgtargetachieve.Value = 0;
                            rdrtgtargetachieve.Enabled = true;
                        }
                    }

                }

                else if ((Convert.ToInt32(dtgoal9.Rows[0]["APP_EMP_GOAL_FIXED"]) == 2))
                {
                    for (int i = 0; i < Rg_Appraisal_Goal.Rows.Count; i++)
                    {
                        _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                        _obj_Pms_Appraisalcycle.MODE = 11;
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtemzaL = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                        _obj_Pms_Appraisalcycle.MODE = 8;
                        if (dtemzaL.Rows.Count != 0)
                        {
                            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzaL.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                        }
                        else
                        {
                            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;
                        }
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtappidzaL = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                        RadRating rdrtgtargetachieve = new Telerik.Web.UI.RadRating();
                        rdrtgtargetachieve = Rg_Appraisal_Goal.Rows[i].FindControl("ratingPie") as RadRating;

                        _obj_Pms_EmpGoalSetting.Mode = 16;
                        _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                        if (dtappidzaL.Rows.Count != 0)
                        {
                            _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(dtappidzaL.Rows[0]["APPRCYCLE_ID"]);
                        }
                        else
                        {
                            _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = "0";
                        }
                        _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dt22 = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
                        if ((Convert.ToString(dt22.Rows[i]["GSDTL_TARGET_ACHEIVED"]) != string.Empty))
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

            }
            else
            {

                Pms_Bll.ShowMessage(this, "No Goal Assigned");

                Rm_Kra_Details.Visible = false;
                Rm_AppraisalDiscussion.Visible = false;
                Rm_Appraisal_Goal.Visible = false;


                return;
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisal", ex.StackTrace, DateTime.Now);
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
                _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
            }
            else
            {
                _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = "0";
            }
            _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
            if (dt.Rows.Count != 0)
            {
                int GSID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
                _obj_GSdetails = new PMS_GoalSettings_Details();
                _obj_GSdetails.GSDTL_GS_ID = GSID;
            }
            _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
            _obj_GSdetails.GS_DETAILS_MODE = 5;
            DataTable dt_details = new DataTable();

            dt_details = Pms_Bll.get_GSdetails(_obj_GSdetails);
            if (dt_details.Rows.Count != 0)
            {
                _obj_Spms_GoalStgKraDtls = new SPMS_GOALSETTINGKRADETAILS();
                _obj_Spms_GoalStgKraDtls.Mode = 7;
                _obj_Spms_GoalStgKraDtls.GS_KRA_GSDTL_ID = Convert.ToInt32(dt_details.Rows[0]["GSDTL_GS_ID"]);
                if (dtappid.Rows.Count != 0)
                {
                    _obj_Spms_GoalStgKraDtls.LASTMDFBY = Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
                }
                else
                {
                    _obj_Spms_GoalStgKraDtls.LASTMDFBY = 0;
                }
                _obj_Spms_GoalStgKraDtls.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt2 = Pms_Bll.get_GoalStgKraDtls(_obj_Spms_GoalStgKraDtls);

                if (dt2.Rows.Count != 0)
                {
                    Rg_Appraisal_Kra.DataSource = dt2;
                    Rg_Appraisal_Kra.DataBind();



                    Rm_Appraisal_PAGE.SelectedIndex = 0;
                    Rm_Appraisal_Goal.Visible = true;
                    Rg_Appraisal_Kra.Visible = true;
                    Rg_Appraisal_Goal.Visible = true;//n
                    Rm_Appraisal_Kra.Visible = true;

                    Rp_Appraisal_VIEWDETAILS.Visible = true;
                    Rm_Appraisal_Kra.SelectedIndex = 0;
                    Rm_Kra_Details.Visible = true;

                    _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                    _obj_Pms_Appraisalcycle.MODE = 11;
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtemzL = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                    _obj_Pms_Appraisalcycle.MODE = 8;
                    if (dtemzL.Rows.Count != 0)
                    {
                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzL.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                    }
                    else
                    {
                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;
                    }
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtappidzL = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                    _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                    if (dtappidzL.Rows.Count != 0)
                    {
                        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzL.Rows[0]["APPRCYCLE_ID"]);
                    }

                    else
                    {
                        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = 0;
                    }
                    _obj_Spms_Appraisal.Mode = 35;
                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtgoal9 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                    if (dtgoal9.Rows.Count == 0)
                    {

                        for (int i = 0; i < Rg_Appraisal_Kra.Rows.Count; i++)
                        {
                            RadRating rdrtgtargetachievekra = new Telerik.Web.UI.RadRating();
                            rdrtgtargetachievekra = Rg_Appraisal_Kra.Rows[i].FindControl("ratingPiekra") as RadRating;
                            Label lblkradt_id = new System.Web.UI.WebControls.Label();
                            lblkradt_id = Rg_Appraisal_Kra.Rows[i].FindControl("lbl_Kra_Id") as Label;

                            //PMS_GoalSettings _obj_GS = new PMS_GoalSettings();
                            //_obj_GS.GS_MODE = 8;
                            //_obj_GS.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                            //DataTable dt11 = Pms_Bll.get_GS(_obj_GS);
                            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                            _obj_Pms_Appraisalcycle.MODE = 11;
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtem11 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                            _obj_Pms_Appraisalcycle.MODE = 8;
                            if (dtem11.Rows.Count != 0)
                            {
                                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem11.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                            }
                            else
                            {
                                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;
                            }
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtappid11 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                            _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
                            _obj_Pms_EmpGoalSetting.Mode = 8;


                            _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                            if (dtappid11.Rows.Count != 0)
                            {
                                _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(dtappid11.Rows[0]["APPRCYCLE_ID"]);
                            }

                            else
                            {
                                _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = "0";

                            }
                            _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt16(Session["ORG_ID"]);
                            DataTable dt11 = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
                            if (dt11.Rows.Count != 0)
                            {
                                _obj_Pms_EmpSetup = new PMS_EMPSETUP();
                                _obj_Pms_EmpSetup.Mode = 17;
                                _obj_Pms_EmpSetup.EMP_SETUP_LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                                _obj_Pms_EmpSetup.EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                DataTable dtem1 = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);




                                _obj_Pms_Roles = new SPMS_ROLES();
                                _obj_Pms_Roles.Mode = 6;
                                if (dtem1.Rows.Count != 0)
                                {
                                    _obj_Pms_Roles.BUID = Convert.ToInt32(dtem1.Rows[0]["BU_ID"]);
                                }
                                else
                                {
                                    _obj_Pms_Roles.BUID = 0;
                                }
                                _obj_Pms_Roles.ROLES_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                _obj_Pms_Roles.ROLES_NAME = Convert.ToString(rtxt_Role.Text);
                                DataTable dt5 = Pms_Bll.get_Roles(_obj_Pms_Roles);

                                _obj_Pms_RoleKra = new SPMS_ROLEKRA();
                                _obj_Pms_RoleKra.Mode = 8;
                                if (dt5.Rows.Count != 0)
                                {
                                    _obj_Pms_RoleKra.ROLE_ID = Convert.ToInt32(dt5.Rows[0]["ROLE_ID"]);
                                }
                                else
                                {
                                    _obj_Pms_RoleKra.ROLE_ID = 0;
                                }
                                _obj_Pms_RoleKra.ROLEKRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                _obj_Pms_RoleKra.ROLE_KRA_ID = Convert.ToInt32(lblkradt_id.Text);
                                DataTable dt20 = Pms_Bll.get_RoleKra(_obj_Pms_RoleKra);

                                if (dt20.Rows.Count != 0)
                                {

                                    _obj_Pms_goalkradetails = new GOALSETTING_GOALKRA_DETAILS();
                                    _obj_Pms_goalkradetails.MODE = 9;
                                    _obj_Pms_goalkradetails.GS_KRA_TARGET_ACHEIVED = Convert.ToString(rdrtgtargetachievekra.Value);
                                    if (dt11.Rows.Count != 0)
                                    {

                                        _obj_Pms_goalkradetails.GS_KRA_GS_ID = Convert.ToInt32(dt11.Rows[0]["GS_ID"]);
                                    }
                                    else
                                    {
                                        _obj_Pms_goalkradetails.GS_KRA_GS_ID = 0;
                                    }
                                    _obj_Pms_goalkradetails.GS_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                    _obj_Pms_goalkradetails.GS_KRA_KRA_ID = Convert.ToInt32(lblkradt_id.Text); //Convert.ToInt32(dt20.Rows[0]["ROLEKRA_ID"]);
                                    DataTable dt13 = Pms_Bll.get_Gskra(_obj_Pms_goalkradetails);

                                    if ((Convert.ToString(dt13.Rows[0]["GS_KRA_TARGET_ACHEIVED"]) != string.Empty))
                                    {

                                        int j = Convert.ToInt32(dt13.Rows[0]["GS_KRA_TARGET_ACHEIVED"]);
                                        if (j == 1)
                                        {
                                            rdrtgtargetachievekra.Value = Convert.ToInt32(dt13.Rows[0]["GS_KRA_TARGET_ACHEIVED"]);
                                            rdrtgtargetachievekra.Enabled = true;
                                            rdrtgtargetachievekra.ToolTip = "0%";
                                        }
                                        else if (j == 2)
                                        {
                                            rdrtgtargetachievekra.Value = Convert.ToInt32(dt13.Rows[0]["GS_KRA_TARGET_ACHEIVED"]);
                                            rdrtgtargetachievekra.Enabled = true;
                                            rdrtgtargetachievekra.ToolTip = "25%";
                                        }
                                        else if (j == 3)
                                        {
                                            rdrtgtargetachievekra.Value = Convert.ToInt32(dt13.Rows[0]["GS_KRA_TARGET_ACHEIVED"]);
                                            rdrtgtargetachievekra.Enabled = true;
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
                                            rdrtgtargetachievekra.Enabled = true;
                                            rdrtgtargetachievekra.ToolTip = "100%";
                                        }
                                        else if (j == 0)
                                        {

                                            rdrtgtargetachievekra.Enabled = true;

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


                    else if ((Convert.ToInt32(dtgoal9.Rows[0]["APP_KRA_EMP_FIXED"]) == 1))
                    {
                        for (int i = 0; i < Rg_Appraisal_Kra.Rows.Count; i++)
                        {
                            RadRating rdrtgtargetachievekra = new Telerik.Web.UI.RadRating();
                            rdrtgtargetachievekra = Rg_Appraisal_Kra.Rows[i].FindControl("ratingPiekra") as RadRating;
                            Label lblkradt_id = new System.Web.UI.WebControls.Label();
                            lblkradt_id = Rg_Appraisal_Kra.Rows[i].FindControl("lbl_Kra_Id") as Label;

                            //PMS_GoalSettings _obj_GS = new PMS_GoalSettings();
                            //_obj_GS.GS_MODE = 8;
                            //_obj_GS.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                            //DataTable dt11 = Pms_Bll.get_GS(_obj_GS);


                            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                            _obj_Pms_Appraisalcycle.MODE = 11;
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtem11 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                            _obj_Pms_Appraisalcycle.MODE = 8;
                            if (dtem11.Rows.Count != 0)
                            {
                                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem11.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                            }
                            else
                            {
                                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;
                            }
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtappid11 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                            _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
                            _obj_Pms_EmpGoalSetting.Mode = 8;


                            _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                            if (dtappid11.Rows.Count != 0)
                            {
                                _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(dtappid11.Rows[0]["APPRCYCLE_ID"]);

                            }
                            else
                            {
                                _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = "0";

                            }
                            _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dt11 = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
                            if (dt11.Rows.Count != 0)
                            {
                                _obj_Pms_EmpSetup = new PMS_EMPSETUP();
                                _obj_Pms_EmpSetup.Mode = 17;
                                _obj_Pms_EmpSetup.EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                _obj_Pms_EmpSetup.EMP_SETUP_LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dtem1 = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);




                                _obj_Pms_Roles = new SPMS_ROLES();
                                _obj_Pms_Roles.Mode = 6;
                                if (dtem1.Rows.Count != 0)
                                {
                                    _obj_Pms_Roles.BUID = Convert.ToInt32(dtem1.Rows[0]["BU_ID"]);
                                }
                                else
                                {
                                    _obj_Pms_Roles.BUID = 0;
                                }
                                _obj_Pms_Roles.ROLES_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                _obj_Pms_Roles.ROLES_NAME = Convert.ToString(rtxt_Role.Text);
                                DataTable dt5 = Pms_Bll.get_Roles(_obj_Pms_Roles);

                                _obj_Pms_RoleKra = new SPMS_ROLEKRA();
                                _obj_Pms_RoleKra.Mode = 8;
                                if (dt5.Rows.Count != 0)
                                {
                                    _obj_Pms_RoleKra.ROLE_ID = Convert.ToInt32(dt5.Rows[0]["ROLE_ID"]);
                                }
                                else
                                {
                                    _obj_Pms_RoleKra.ROLE_ID = 0;
                                }
                                _obj_Pms_RoleKra.ROLEKRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                _obj_Pms_RoleKra.ROLE_KRA_ID = Convert.ToInt32(lblkradt_id.Text);
                                DataTable dt20 = Pms_Bll.get_RoleKra(_obj_Pms_RoleKra);

                                if (dt20.Rows.Count != 0)
                                {

                                    _obj_Pms_goalkradetails = new GOALSETTING_GOALKRA_DETAILS();
                                    _obj_Pms_goalkradetails.MODE = 9;
                                    _obj_Pms_goalkradetails.GS_KRA_TARGET_ACHEIVED = Convert.ToString(rdrtgtargetachievekra.Value);
                                    if (dt11.Rows.Count != 0)
                                    {
                                        _obj_Pms_goalkradetails.GS_KRA_GS_ID = Convert.ToInt32(dt11.Rows[0]["GS_ID"]);
                                    }
                                    else
                                    {
                                        _obj_Pms_goalkradetails.GS_KRA_GS_ID = 0;
                                    }
                                    _obj_Pms_goalkradetails.GS_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                    _obj_Pms_goalkradetails.GS_KRA_KRA_ID = Convert.ToInt32(lblkradt_id.Text); //Convert.ToInt32(dt20.Rows[0]["ROLEKRA_ID"]);
                                    DataTable dt13 = Pms_Bll.get_Gskra(_obj_Pms_goalkradetails);

                                    if ((Convert.ToString(dt13.Rows[0]["GS_KRA_TARGET_ACHEIVED"]) != string.Empty))
                                    {

                                        int j = Convert.ToInt32(dt13.Rows[0]["GS_KRA_TARGET_ACHEIVED"]);
                                        if (j == 1)
                                        {
                                            rdrtgtargetachievekra.Value = Convert.ToInt32(dt13.Rows[0]["GS_KRA_TARGET_ACHEIVED"]);
                                            rdrtgtargetachievekra.Enabled = true;
                                            rdrtgtargetachievekra.ToolTip = "0%";
                                        }
                                        else if (j == 2)
                                        {
                                            rdrtgtargetachievekra.Value = Convert.ToInt32(dt13.Rows[0]["GS_KRA_TARGET_ACHEIVED"]);
                                            rdrtgtargetachievekra.Enabled = true;
                                            rdrtgtargetachievekra.ToolTip = "25%";
                                        }
                                        else if (j == 3)
                                        {
                                            rdrtgtargetachievekra.Value = Convert.ToInt32(dt13.Rows[0]["GS_KRA_TARGET_ACHEIVED"]);
                                            rdrtgtargetachievekra.Enabled = true;
                                            rdrtgtargetachievekra.ToolTip = "50%";
                                        }
                                        else if (j == 4)
                                        {
                                            rdrtgtargetachievekra.Value = Convert.ToInt32(dt13.Rows[0]["GS_KRA_TARGET_ACHEIVED"]);
                                            rdrtgtargetachievekra.Enabled = true;
                                            rdrtgtargetachievekra.ToolTip = "75%";
                                        }
                                        else if (j == 5)
                                        {
                                            rdrtgtargetachievekra.Value = Convert.ToInt32(dt13.Rows[0]["GS_KRA_TARGET_ACHEIVED"]);
                                            rdrtgtargetachievekra.Enabled = true;
                                            rdrtgtargetachievekra.ToolTip = "100%";
                                        }
                                        else if (j == 0)
                                        {

                                            rdrtgtargetachievekra.Enabled = true;

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


                    else if ((Convert.ToInt32(dtgoal9.Rows[0]["APP_KRA_EMP_FIXED"]) == 2))
                    {
                        for (int i = 0; i < Rg_Appraisal_Kra.Rows.Count; i++)
                        {
                            RadRating rdrtgtargetachievekra = new Telerik.Web.UI.RadRating();
                            rdrtgtargetachievekra = Rg_Appraisal_Kra.Rows[i].FindControl("ratingPiekra") as RadRating;
                            Label lblkradt_id = new System.Web.UI.WebControls.Label();
                            lblkradt_id = Rg_Appraisal_Kra.Rows[i].FindControl("lbl_Kra_Id") as Label;

                            //PMS_GoalSettings _obj_GS = new PMS_GoalSettings();
                            //_obj_GS.GS_MODE = 8;
                            //_obj_GS.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                            //DataTable dt11 = Pms_Bll.get_GS(_obj_GS);

                            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                            _obj_Pms_Appraisalcycle.MODE = 11;
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtem11 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                            _obj_Pms_Appraisalcycle.MODE = 8;
                            if (dtem11.Rows.Count != 0)
                            {


                                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem11.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                            }
                            else
                            {
                                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;
                            }
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtappid11 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                            _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
                            _obj_Pms_EmpGoalSetting.Mode = 8;


                            _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                            if (dtappid11.Rows.Count != 0)
                            {

                                _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(dtappid11.Rows[0]["APPRCYCLE_ID"]);
                            }
                            else
                            {
                                _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = "0";
                            }
                            _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dt11 = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
                            if (dt11.Rows.Count != 0)
                            {
                                _obj_Pms_EmpSetup = new PMS_EMPSETUP();
                                _obj_Pms_EmpSetup.Mode = 17;
                                _obj_Pms_EmpSetup.EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                _obj_Pms_EmpSetup.EMP_SETUP_LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);

                                DataTable dtem1 = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);




                                _obj_Pms_Roles = new SPMS_ROLES();
                                _obj_Pms_Roles.Mode = 6;
                                if (dtem1.Rows.Count != 0)
                                {
                                    _obj_Pms_Roles.BUID = Convert.ToInt32(dtem1.Rows[0]["BU_ID"]);
                                }
                                else
                                {
                                    _obj_Pms_Roles.BUID = 0;

                                }
                                _obj_Pms_Roles.ROLES_NAME = Convert.ToString(rtxt_Role.Text);
                                _obj_Pms_Roles.ROLES_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dt5 = Pms_Bll.get_Roles(_obj_Pms_Roles);

                                _obj_Pms_RoleKra = new SPMS_ROLEKRA();
                                _obj_Pms_RoleKra.Mode = 8;
                                if (dt5.Rows.Count != 0)
                                {

                                    _obj_Pms_RoleKra.ROLE_ID = Convert.ToInt32(dt5.Rows[0]["ROLE_ID"]);
                                }
                                else
                                {
                                    _obj_Pms_RoleKra.ROLE_ID = 0;
                                }
                                _obj_Pms_RoleKra.ROLE_KRA_ID = Convert.ToInt32(lblkradt_id.Text);
                                _obj_Pms_RoleKra.ROLEKRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dt20 = Pms_Bll.get_RoleKra(_obj_Pms_RoleKra);

                                if (dt20.Rows.Count != 0)
                                {

                                    _obj_Pms_goalkradetails = new GOALSETTING_GOALKRA_DETAILS();
                                    _obj_Pms_goalkradetails.MODE = 9;
                                    _obj_Pms_goalkradetails.GS_KRA_TARGET_ACHEIVED = Convert.ToString(rdrtgtargetachievekra.Value);
                                    if (dt11.Rows.Count != 0)
                                    {
                                        _obj_Pms_goalkradetails.GS_KRA_GS_ID = Convert.ToInt32(dt11.Rows[0]["GS_ID"]);
                                    }
                                    else
                                    {
                                        _obj_Pms_goalkradetails.GS_KRA_GS_ID = 0;


                                    }
                                    _obj_Pms_goalkradetails.GS_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                    _obj_Pms_goalkradetails.GS_KRA_KRA_ID = Convert.ToInt32(lblkradt_id.Text); //Convert.ToInt32(dt20.Rows[0]["ROLEKRA_ID"]);
                                    DataTable dt13 = Pms_Bll.get_Gskra(_obj_Pms_goalkradetails);

                                    if ((Convert.ToString(dt13.Rows[0]["GS_KRA_TARGET_ACHEIVED"]) != string.Empty))
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
                }


                else
                {
                    Pms_Bll.ShowMessage(this, "No KRA Assigned");

                    rcmb_BusinessUnitType.Enabled = true;
                    rcmb_EmployeeType.Enabled = true;
                    Rm_Kra_Details.Visible = false;
                    Rm_AppraisalDiscussion.Visible = false;

                    Rm_Appraisal_Kra.Visible = false;

                    return;
                }
            }
            else
            {
                Pms_Bll.ShowMessage(this, "No KRA Assigned");
                rcmb_BusinessUnitType.Enabled = true;
                rcmb_EmployeeType.Enabled = true;
                Rm_Kra_Details.Visible = false;
                Rm_AppraisalDiscussion.Visible = false;

                Rm_Appraisal_Kra.Visible = false;

                return;
            }


        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisal", ex.StackTrace, DateTime.Now);
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
        //rcmb_BusinessUnitType.Items.Clear();
        //SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
        //_obj_Smhr_BusinessUnit.OPERATION = operation.Select;
        //DataTable dt = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
        //rcmb_BusinessUnitType.DataSource = dt;
        //rcmb_BusinessUnitType.DataTextField = "BUSINESSUNIT_CODE";
        //rcmb_BusinessUnitType.DataValueField = "BUSINESSUNIT_ID";
        //rcmb_BusinessUnitType.DataBind();
        //rcmb_BusinessUnitType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

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


        //SPMS_EMPGOALSETTING _obj_Pms_EmpGoalSetting;
        //_obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
        //_obj_Pms_EmpGoalSetting.Mode = 11;
        //_obj_Pms_EmpGoalSetting.BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
        //DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);

        //rcmb_EmployeeType.Items.Clear();
        //rcmb_EmployeeType.DataSource = dt;
        //rcmb_EmployeeType.DataTextField = "EMPLOYEE_NAME";
        //rcmb_EmployeeType.DataValueField = "EMP_ID";
        //rcmb_EmployeeType.DataBind();
        //rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));



    }

    private void LoadEmployees()
    {
        try
        {
            if ((Convert.ToString(Session["EMP_TYPE"])) == "0")//for manger login not using now
            {
                //_obj_PMS_getemployee = new PMS_GETEMPLOYEE();
                //_obj_PMS_getemployee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                //_obj_PMS_getemployee.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                //DataTable dtbuid = Pms_Bll.get_RMEmployees(_obj_PMS_getemployee);
                //if (dtbuid.Rows.Count != 0)
                //{
                //    rtxt_RpMgr.Text = Convert.ToString(dtbuid.Rows[0]["REPORTINGMANAGER"]);
                //    rtxt_GpMgr.Text = Convert.ToString(dtbuid.Rows[0]["approvalmgr"]);
                //    rcmb_EmployeeType.Items.Clear();
                //    rcmb_EmployeeType.DataSource = dtbuid;
                //    rcmb_EmployeeType.DataTextField = "employee";
                //    rcmb_EmployeeType.DataValueField = "EMPID";
                //    rcmb_EmployeeType.DataBind();

                //    rcmb_BusinessUnitType.Visible = false;
                //    lbl_BusinessUnitName.Visible = false;
                //    rtxt_RpMgr.Enabled = false;
                //    rtxt_GpMgr.Enabled = false;
                //}

                //else
                //{
                //    //rcmb_feedback.SelectedIndex = 0;
                //    //Pms_Bll.ShowMessage(this, "Goal Setting Has Not Done");
                //    //rcmb_feedback.Enabled = false;
                //    //rtxt_Role.Text = string.Empty;
                //    //rtxt_Project.Text = string.Empty;
                //    //rtxt_AppraisalCycle.Text = string.Empty;
                //}
            }
            else
            {
                _obj_pms_EmployeeSetup = new PMS_EMPSETUP();


                _obj_smhr_logininfo = new SMHR_LOGININFO();
                _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                _obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"].ToString());
                DataTable dt_buu = new DataTable();
                dt_buu = BLL.get_Business_Units(_obj_smhr_logininfo);


                _obj_pms_EmployeeSetup.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                if (dt_buu.Rows.Count != 0)
                {
                    _obj_pms_EmployeeSetup.BU_ID = Convert.ToInt32(dt_buu.Rows[0]["BUSINESSUNIT_ID"]);
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


                    rcmb_BusinessUnitType.Visible = false;
                    lbl_BusinessUnitName.Visible = false;
                    rtxt_RpMgr.Enabled = false;
                    rtxt_GpMgr.Enabled = false;
                    lbl_givefeedback.Text = "Self Appraisal For                  ";

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
                        _obj_GS.GS_APPRAISAL_CYCLE = Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
                        DataTable dt1 = Pms_Bll.get_GS(_obj_GS);

                        if (dt1.Rows.Count != 0)
                        {
                            rtxt_Role.Text = Convert.ToString(dt1.Rows[0]["ROLE_NAMES"]);
                            rtxt_Project.Text = Convert.ToString(dt1.Rows[0]["PROJECT_NAME"]);
                            rtxt_AppraisalCycle.Text = Convert.ToString(dt1.Rows[0]["APPRCYCLE_NAME"]);
                            lbl_Apprais_id.Text = Convert.ToString(dt1.Rows[0]["APPRCYCLE_ID"]);
                            rtxt_AppraisalCycle.Enabled = false;
                            rtxt_Role.Enabled = false;
                            rtxt_Project.Enabled = false;
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
                            rcmb_feedback.SelectedIndex = 0;
                            Pms_Bll.ShowMessage(this, "Goal Setting Has Not Done");
                            rcmb_feedback.Enabled = false;
                            rtxt_Role.Text = string.Empty;
                            rtxt_Project.Text = string.Empty;
                            rtxt_AppraisalCycle.Text = string.Empty;

                        }
                    }
                    else
                    {
                        rcmb_feedback.SelectedIndex = 0;
                        Pms_Bll.ShowMessage(this, "Goal Setting Has Not Done");
                        rcmb_feedback.Enabled = false;
                        rtxt_Role.Text = string.Empty;
                        rtxt_Project.Text = string.Empty;
                        rtxt_AppraisalCycle.Text = string.Empty;
                    }
                }

                else
                {
                    Pms_Bll.ShowMessage(this, "Employee Not In Active State");
                    rcmb_BusinessUnitType.Visible = false;
                    return;
                }
            }

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }



    #endregion

    protected void rcmb_EmployeeType_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_EmployeeType.SelectedItem.Text == "Select")
            {
                Pms_Bll.ShowMessage(this, "select employee");
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
                Rg_Appraisal_Goal.Visible = false;
                Rg_Appraisal_Kra.Visible = false;
                rcmb_feedback.SelectedIndex = 0;
            }
            else
            {
                _obj_Pms_EmpSetup = new PMS_EMPSETUP();


                _obj_Pms_LoginInfo = new PMS_LOGININFO();


                _obj_Pms_LoginInfo.EMPID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);

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


                _obj_GS = new PMS_GoalSettings();
                _obj_GS.GS_MODE = 9;
                _obj_GS.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                if (dtappid.Rows.Count != 0)
                {
                    _obj_GS.GS_APPRAISAL_CYCLE = Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);

                }
                else
                {
                    _obj_GS.GS_APPRAISAL_CYCLE = "0";

                }
                _obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt1 = Pms_Bll.get_GS(_obj_GS);

                if (dt1.Rows.Count != 0)
                {
                    rtxt_Role.Text = Convert.ToString(dt1.Rows[0]["ROLE_NAMES"]);
                    rtxt_Project.Text = Convert.ToString(dt1.Rows[0]["PROJECT_NAME"]);
                    rtxt_AppraisalCycle.Text = Convert.ToString(dt1.Rows[0]["APPRCYCLE_NAME"]);
                    lbl_Apprais_id.Text = Convert.ToString(dt1.Rows[0]["APPRCYCLE_ID"]);
                    rtxt_AppraisalCycle.Enabled = false;
                    rtxt_Role.Enabled = false;
                    rtxt_Project.Enabled = false;
                    rcmb_feedback.SelectedIndex = 0;


                }
                else
                {
                    rcmb_feedback.SelectedIndex = 0;
                }

                Session["empid"] = rcmb_EmployeeType.SelectedItem.Value;
                Rg_Appraisal_Goal.Enabled = true;
                btn_Cancel.Visible = true;
                Rg_Appraisal_Kra.Enabled = true;
                Rm_Appraisal_Goal.Enabled = true;
                Rg_Appraisal_Goal.Enabled = true;
                Rm_AppraisalDiscussion.Visible = false;
                rcmb_feedback.Enabled = true;

            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    #region Loadgoal,kraDetails



    /// <summary>
    /// Here i am loading grid based on emploee selecteion task grid will be displayed
    /// </summary>
    /// <param name="o"></param>
    /// <param name="e"></param>

    protected void rcmb_feedback_indexchanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if ((rcmb_feedback.SelectedItem.Text != "Select"))
            {
                if (rcmb_feedback.SelectedItem.Text == "GOAL")
                {
                    LoadGrid();
                    _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                    _obj_Pms_Appraisalcycle.MODE = 11;
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtemzL = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                    _obj_Pms_Appraisalcycle.MODE = 8;
                    if (dtemzL.Rows.Count != 0)
                    {
                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzL.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                    }
                    else
                    {
                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;
                    }
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtappidzL = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                    _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);

                    if (dtappidzL.Rows.Count != 0)
                    {
                        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzL.Rows[0]["APPRCYCLE_ID"]);
                    }
                    else
                    {
                        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = 0;
                    }
                    _obj_Spms_Appraisal.Mode = 34;
                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtgoal9 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                    //if (dtgoal9.Rows[0]["APP_EMP_GOAL_FIXED"] == System.DBNull.Value)
                    // { 
                    if (dtgoal9.Rows.Count == 0)
                    {
                        lbl_final.Text = "Appraisal Not Started";
                        lbl_final.Visible = true;
                    }
                    else if (Convert.ToInt32(dtgoal9.Rows[0]["APP_EMP_GOAL_FIXED"]) == 1)
                    {
                        lbl_final.Text = "Appraisal Not Finalized";
                        lbl_final.Visible = true;
                    }
                    else if (Convert.ToInt32(dtgoal9.Rows[0]["APP_EMP_GOAL_FIXED"]) == 2)
                    {
                        lbl_final.Text = "Appraisal Finalized";
                        lbl_final.Visible = true;

                    }


                    _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                    _obj_Pms_Appraisalcycle.MODE = 11;
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtemzz2 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                    _obj_Pms_Appraisalcycle.MODE = 8;
                    if (dtemzz2.Rows.Count != 0)
                    {
                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz2.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                    }
                    else
                    {
                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;
                    }
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtappidzz2 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                    _obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE = 11;
                    if (dtappidzz2.Rows.Count != 0)
                    {
                        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz2.Rows[0]["APPRCYCLE_ID"]);

                    }
                    else
                    {
                        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = 0;
                    }
                    _obj_Spms_Appraisal.Mode = 5;
                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtgoal1 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                    if (dtgoal1.Rows.Count != 0)
                    {

                        SPMS_APPRAISALGOAL _obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();
                        _obj_Spms_AppraisalGoal.Mode = 13;
                        _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtgoal1.Rows[0]["APPRAISAL_ID"]);
                        DataTable dt9 = Pms_Bll.get_AppraisalGoal(_obj_Spms_AppraisalGoal);
                        if (dt9.Rows.Count != 0)
                        {
                            LOADFINALIZE();
                            btn_finalise.Visible = false;
                            Pms_Bll.ShowMessage(this, "Already Self Appraisal Finalized");
                            for (int l = 0; l <= Rg_Appraisal_Goal.Rows.Count - 1; l++)
                            {
                                TextBox txtempfeed = new System.Web.UI.WebControls.TextBox();
                                Button btnsubmitempfeed = new System.Web.UI.WebControls.Button();
                                Button btncancelempfeed = new System.Web.UI.WebControls.Button();
                                Button btnupdateempfeed = new System.Web.UI.WebControls.Button();
                                RadRating rdrtgtargetachieve = new Telerik.Web.UI.RadRating();
                                txtempfeed = Rg_Appraisal_Goal.Rows[l].FindControl("txt_GoalEmployeeFeedback") as TextBox;
                                btnsubmitempfeed = Rg_Appraisal_Goal.Rows[l].FindControl("btn_GoalEmpSubmit") as Button;
                                btncancelempfeed = Rg_Appraisal_Goal.Rows[l].FindControl("btn_GoalEmpCancel") as Button;
                                rdrtgtargetachieve = Rg_Appraisal_Goal.Rows[l].FindControl("ratingPie") as RadRating;
                                btnupdateempfeed = Rg_Appraisal_Goal.Rows[l].FindControl("btn_GoalEmpUpdate") as Button;
                                txtempfeed.Enabled = false;

                                btnsubmitempfeed.Visible = false;
                                btncancelempfeed.Visible = false;
                                btnupdateempfeed.Visible = false;
                                rdrtgtargetachieve.Enabled = false;
                            }

                            Rg_Appraisal_Goal.Visible = true;
                            Rg_Appraisal_Kra.Visible = false;
                            lblgoal.Visible = true;
                            //return;
                        }
                        else
                        {
                            LOADFINALIZE();
                        }
                    }
                    else
                    {
                        LOADFINALIZE();
                    }



                    Rg_Appraisal_Kra.Visible = false;
                    lblgoal.Visible = true;
                    lblkra.Visible = false;


                }

                else if (rcmb_feedback.SelectedItem.Text == "KRA")
                {
                    LoadKraGrid();
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
                    else
                    {
                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;
                    }
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtappidzL = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                    SPMS_APPRAISAL _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                    _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                    if (dtappidzL.Rows.Count != 0)
                    {
                        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzL.Rows[0]["APPRCYCLE_ID"]);
                    }
                    else
                    {
                        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = 0;
                    }
                    _obj_Spms_Appraisal.Mode = 35;
                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtgoal9 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                    //if (dtgoal9.Rows[0]["APP_KRA_EMP_FIXED"] == System.DBNull.Value)
                    //{
                    if (dtgoal9.Rows.Count == 0)
                    {
                        lbl_final.Text = "Appraisal Not Started";
                        lbl_final.Visible = true;


                    }
                    else if (Convert.ToInt32(dtgoal9.Rows[0]["APP_KRA_EMP_FIXED"]) == 1)
                    {
                        lbl_final.Text = "Appraisal Not Finalized";
                        lbl_final.Visible = true;
                    }
                    else if (Convert.ToInt32(dtgoal9.Rows[0]["APP_KRA_EMP_FIXED"]) == 2)
                    {
                        lbl_final.Text = "Appraisal Finalized";
                        lbl_final.Visible = true;
                    }
                    _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                    _obj_Pms_Appraisalcycle.MODE = 11;
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtemzz2 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                    _obj_Pms_Appraisalcycle.MODE = 8;
                    if (dtemzz2.Rows.Count != 0)
                    {
                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz2.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                    }
                    else
                    {
                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;

                    }
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtappidzz2 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                    if (dtappidzz2.Rows.Count != 0)
                    {
                        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz2.Rows[0]["APPRCYCLE_ID"]);
                    }
                    else
                    {
                        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = 0;

                    }
                    _obj_Spms_Appraisal.Mode = 5;
                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtgoal1 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                    if (dtgoal1.Rows.Count != 0)
                    {

                        SPMS_APPRAISALKRA _obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                        _obj_Spms_AppraisalKra.Mode = 13;
                        _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtgoal1.Rows[0]["APPRAISAL_ID"]);
                        DataTable dt9 = Pms_Bll.get_AppraisalKra(_obj_Spms_AppraisalKra);
                        if (dt9.Rows.Count != 0)
                        {
                            LOADkraFINALIZE();
                            btn_KraFINALISE.Visible = false;
                            Pms_Bll.ShowMessage(this, "Already Self Appraisal Finalized");

                        }
                        else
                        {
                            LOADkraFINALIZE();
                        }
                    }
                    else
                    {
                        LOADkraFINALIZE();
                    }

                    Rm_Appraisal_Goal.Visible = false;
                    lblgoal.Visible = false;
                    lblkra.Visible = true;


                }


            }
            else
            {
                Pms_Bll.ShowMessage(this, "Please Select Feedback");
                Rg_Appraisal_Goal.Visible = false;
                Rg_Appraisal_Kra.Visible = false;
                lbl_final.Visible = false;
                return;
            }
            rdtp_DATEofAppraisal.SelectedDate = DateTime.Now;
            rdtp_DATEofAppraisal.Enabled = false;

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }



    #endregion

    #region loadgoal ,kra finalise button
    public void LOADFINALIZE()
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
                _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
            }
            else
            {
                _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = "0";
            }
            _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
            if (dt.Rows.Count != 0)
            {
                int GSID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
                _obj_GSdetails = new PMS_GoalSettings_Details();
                _obj_GSdetails.GSDTL_GS_ID = GSID;
            }
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
                else
                {
                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;
                }
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtappidzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                _obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();
                if (dt_details.Rows.Count != 0)
                {
                    _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(dt_details.Rows[i]["GSDTL_ID"]);
                }
                else
                {
                    _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = 0;
                }
                _obj_Spms_AppraisalGoal.APP_GOALS_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                _obj_Spms_AppraisalGoal.Mode = 5;
                if (dtappidzz.Rows.Count != 0)
                {
                    _obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFBY = Convert.ToInt32(dtappidzz.Rows[0]["APPRCYCLE_ID"]);
                }
                else
                {
                    _obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFBY = 0;
                }
                _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);

                DataTable dtgoal = Pms_Bll.get_AppraisalGoal(_obj_Spms_AppraisalGoal);
                TextBox txtempfeed = new System.Web.UI.WebControls.TextBox();
                txtempfeed = Rg_Appraisal_Goal.Rows[i].FindControl("txt_GoalEmployeeFeedback") as TextBox;
                if (dtgoal.Rows.Count != 0)
                {
                    txtempfeed.Text = Convert.ToString(dtgoal.Rows[0]["APP_GOALS_EMP_COMMENTS"]);

                    str = txtempfeed.Text;

                    Temp++;



                }

            }



            if (Temp == Rg_Appraisal_Goal.Rows.Count)
            {
                btn_finalise.Visible = true;
                btn_KraFINALISE.Visible = false;
            }

            else
            {
                btn_finalise.Visible = false;
                btn_KraFINALISE.Visible = false;
            }

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void LOADkraFINALIZE()
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

                _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
            }
            else
            {
                _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = "0";
            }
            _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
            if (dt.Rows.Count != 0)
            {
                int GSID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
                _obj_GSdetails = new PMS_GoalSettings_Details();
                _obj_GSdetails.GSDTL_GS_ID = GSID;
            }
            _obj_GSdetails.GS_DETAILS_MODE = 5;
            _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_details = new DataTable();
            dt_details = Pms_Bll.get_GSdetails(_obj_GSdetails);
            if (dt_details.Rows.Count != 0)
            {
                if (dt.Rows.Count != 0)
                {
                    _obj_Spms_GoalStgKraDtls = new SPMS_GOALSETTINGKRADETAILS();
                    _obj_Spms_GoalStgKraDtls.Mode = 7;
                    _obj_Spms_GoalStgKraDtls.GS_KRA_GSDTL_ID = Convert.ToInt32(dt_details.Rows[0]["GSDTL_GS_ID"]);
                    if (dtappid.Rows.Count != 0)
                    {
                        _obj_Spms_GoalStgKraDtls.LASTMDFBY = Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
                    }
                    else
                    {
                        _obj_Spms_GoalStgKraDtls.LASTMDFBY = 0;
                    }
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
                        else
                        {
                            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;
                        }

                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtappidzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                        _obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                        if (dt2.Rows.Count != 0)
                        {
                            _obj_Spms_AppraisalKra.APP_KRA_KRA_ID = Convert.ToInt32(dt2.Rows[i]["KRA_ID"]);
                        }
                        else
                        {
                            _obj_Spms_AppraisalKra.APP_KRA_KRA_ID = 0;

                        }
                        _obj_Spms_AppraisalKra.APP_KRA_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                        if (dtappidzz.Rows.Count != 0)
                        {
                            _obj_Spms_AppraisalKra.APP_KRA_LASTMDFBY = Convert.ToInt32(dtappidzz.Rows[0]["APPRCYCLE_ID"]);
                        }
                        else
                        {
                            _obj_Spms_AppraisalKra.APP_KRA_LASTMDFBY = 0;
                        }
                        _obj_Spms_AppraisalKra.Mode = 5;
                        _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtKra = Pms_Bll.get_AppraisalKra(_obj_Spms_AppraisalKra);

                        TextBox txtKra1 = new System.Web.UI.WebControls.TextBox();

                        txtKra1 = Rg_Appraisal_Kra.Rows[i].FindControl("txt_KraEmployeeFeedback") as TextBox;

                        if (dtKra.Rows.Count != 0)
                        {
                            txtKra1.Text = Convert.ToString(dtKra.Rows[0]["APP_KRA_EMP_COMMENTS"]);


                            strkra = txtKra1.Text;

                            tempkra++;
                        }
                    }

                    if (tempkra == Rg_Appraisal_Kra.Rows.Count)
                    {
                        btn_KraFINALISE.Visible = true;
                        btn_finalise.Visible = false;
                    }

                    else
                    {
                        btn_KraFINALISE.Visible = false;
                        btn_finalise.Visible = false;
                    }
                }

            }
            else
            {

                rcmb_BusinessUnitType.Enabled = true;
                rcmb_EmployeeType.Enabled = true;
                Rm_Kra_Details.Visible = false;
                Rm_AppraisalDiscussion.Visible = false;

                Rm_Appraisal_Kra.Visible = false;
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisal", ex.StackTrace, DateTime.Now);
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
            RadRating rdrtgtargetachieve = new Telerik.Web.UI.RadRating();

            Label lblappraisaldtl = new System.Web.UI.WebControls.Label();
            int i = Convert.ToInt32(e.CommandArgument);

            lblgsdt_id = Rg_Appraisal_Goal.Rows[i].FindControl("lbl_Goal_Id") as Label;
            lblappraisaldtl = Rg_Appraisal_Goal.Rows[i].FindControl("lbl_Goal_AppraisalCycle") as Label;
            TextBox txtempfeed = new System.Web.UI.WebControls.TextBox();
            Button btnsubmitempfeed = new System.Web.UI.WebControls.Button();
            Button btnupdateempfeed = new System.Web.UI.WebControls.Button();
            Button btncancelempfeed = new System.Web.UI.WebControls.Button();
            txtempfeed = Rg_Appraisal_Goal.Rows[i].FindControl("txt_GoalEmployeeFeedback") as TextBox;
            btnsubmitempfeed = Rg_Appraisal_Goal.Rows[i].FindControl("btn_GoalEmpSubmit") as Button;
            btnupdateempfeed = Rg_Appraisal_Goal.Rows[i].FindControl("btn_GoalEmpUpdate") as Button;
            btncancelempfeed = Rg_Appraisal_Goal.Rows[i].FindControl("btn_GoalEmpCancel") as Button;
            rdrtgtargetachieve = Rg_Appraisal_Goal.Rows[i].FindControl("ratingPie") as RadRating;

            TextBox txtmgrfeed = new System.Web.UI.WebControls.TextBox();
            Button btnsubmitmgrfeed = new System.Web.UI.WebControls.Button();
            Button btncancelmgrfeed = new System.Web.UI.WebControls.Button();
            RadRating rdratingmgr = new Telerik.Web.UI.RadRating();
            txtmgrfeed = Rg_Appraisal_Goal.Rows[i].FindControl("txt_GoalManagerFeedback") as TextBox;
            btnsubmitmgrfeed = Rg_Appraisal_Goal.Rows[i].FindControl("btn_GoalMgrSubmit") as Button;
            btncancelmgrfeed = Rg_Appraisal_Goal.Rows[i].FindControl("btn_GoalMgrCancel") as Button;
            rdratingmgr = Rg_Appraisal_Goal.Rows[i].FindControl("rdrtg_GoalMgr") as RadRating;

            #region Employee Feedback


            if (e.CommandName == "GoalEmployee_Feed")
            {
                try
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
                    else
                    {
                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;
                    }
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtappidzL = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                    _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                    if (dtappidzL.Rows.Count != 0)
                    {

                        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzL.Rows[0]["APPRCYCLE_ID"]);
                    }
                    else
                    {
                        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = 0;
                    }

                    _obj_Spms_Appraisal.Mode = 34;
                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtgoal9 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                    //if (dtgoal9.Rows[0]["APP_EMP_GOAL_FIXED"] == System.DBNull.Value)
                    //{
                    if (dtgoal9.Rows.Count == 0)
                    {
                        _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                        _obj_Pms_Appraisalcycle.MODE = 11;
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtemzLQ = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                        _obj_Pms_Appraisalcycle.MODE = 8;
                        if (dtemzLQ.Rows.Count != 0)
                        {

                            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzLQ.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                        }
                        else
                        {

                            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;
                        }
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtappidzLQ = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                        _obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();

                        _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(lblgsdt_id.Text);
                        _obj_Spms_AppraisalGoal.Mode = 5;

                        _obj_Spms_AppraisalGoal.APP_GOALS_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                        if (dtappidzLQ.Rows.Count != 0)
                        {
                            _obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFBY = Convert.ToInt32(dtappidzLQ.Rows[0]["APPRCYCLE_ID"]);
                        }
                        else
                        {
                            _obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFBY = 0;

                        }
                        _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtgoal = Pms_Bll.get_AppraisalGoal(_obj_Spms_AppraisalGoal);

                        if (dtgoal.Rows.Count != 0)
                        {
                            txtempfeed.Text = Convert.ToString(dtgoal.Rows[0]["APP_GOALS_EMP_COMMENTS"]);

                            txtempfeed.Enabled = false;

                            if (txtempfeed.Visible == true)
                            {

                                txtempfeed.Visible = false;

                                btnsubmitempfeed.Visible = false;
                                btncancelempfeed.Visible = false;
                                btnupdateempfeed.Visible = false;

                            }
                            else
                            {

                                txtempfeed.Visible = true;

                                btncancelempfeed.Visible = true;
                                btnsubmitempfeed.Visible = false;
                                btnupdateempfeed.Visible = true;
                            }
                        }
                        else
                        {

                            if (txtempfeed.Visible == true)
                            {

                                txtempfeed.Visible = false;

                                btnsubmitempfeed.Visible = false;
                                btncancelempfeed.Visible = false;
                                btnupdateempfeed.Visible = false;
                            }
                            else
                            {

                                txtempfeed.Visible = true;
                                txtempfeed.Enabled = true;
                                btnsubmitempfeed.Visible = true;
                                btncancelempfeed.Visible = true;
                                btnupdateempfeed.Visible = false;
                            }


                        }

                    }
                    else
                    {
                        if ((Convert.ToInt32(dtgoal9.Rows[0]["APP_EMP_GOAL_FIXED"]) == 2))
                        {
                            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                            _obj_Pms_Appraisalcycle.MODE = 11;
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtemzLN = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                            _obj_Pms_Appraisalcycle.MODE = 8;
                            if (dtemzLN.Rows.Count != 0)
                            {
                                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzLN.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                            }
                            else
                            {
                                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;
                            }
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtappidzLN = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                            _obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();

                            _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(lblgsdt_id.Text);
                            _obj_Spms_AppraisalGoal.Mode = 5;
                            _obj_Spms_AppraisalGoal.APP_GOALS_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                            if (dtappidzLN.Rows.Count != 0)
                            {
                                _obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFBY = Convert.ToInt32(dtappidzLN.Rows[0]["APPRCYCLE_ID"]);
                            }

                            else
                            {
                                _obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFBY = 0;
                            }

                            _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtgoal = Pms_Bll.get_AppraisalGoal(_obj_Spms_AppraisalGoal);

                            if (dtgoal.Rows.Count != 0)
                            {
                                txtempfeed.Text = Convert.ToString(dtgoal.Rows[0]["APP_GOALS_EMP_COMMENTS"]);

                                txtempfeed.Enabled = false;

                                if (txtempfeed.Visible == true)
                                {

                                    txtempfeed.Visible = false;

                                    btnsubmitempfeed.Visible = false;
                                    btncancelempfeed.Visible = false;
                                    btnupdateempfeed.Visible = false;

                                }
                                else
                                {

                                    txtempfeed.Visible = true;
                                    txtempfeed.Enabled = false;
                                    btncancelempfeed.Visible = false;
                                    btnsubmitempfeed.Visible = false;
                                    btnupdateempfeed.Visible = false;

                                }
                            }
                            else
                            {

                                if (txtempfeed.Visible == true)
                                {

                                    txtempfeed.Visible = false;

                                    btnsubmitempfeed.Visible = false;
                                    btncancelempfeed.Visible = false;
                                    btnupdateempfeed.Visible = false;
                                }
                                else
                                {

                                    txtempfeed.Visible = true;

                                    btnsubmitempfeed.Visible = true;
                                    btncancelempfeed.Visible = true;
                                    btnupdateempfeed.Visible = false;
                                }


                            }

                        }
                        else if ((Convert.ToInt32(dtgoal9.Rows[0]["APP_EMP_GOAL_FIXED"]) == 1))
                        {
                            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                            _obj_Pms_Appraisalcycle.MODE = 11;
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtemzLP = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                            _obj_Pms_Appraisalcycle.MODE = 8;
                            if (dtemzLP.Rows.Count != 0)
                            {
                                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzLP.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                            }
                            else
                            {
                                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;
                            }
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtappidzLP = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                            _obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();

                            _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(lblgsdt_id.Text);
                            _obj_Spms_AppraisalGoal.Mode = 5;
                            _obj_Spms_AppraisalGoal.APP_GOALS_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                            if (dtappidzLP.Rows.Count != 0)
                            {

                                _obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFBY = Convert.ToInt32(dtappidzLP.Rows[0]["APPRCYCLE_ID"]);
                            }

                            else
                            {
                                _obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFBY = 0;
                            }
                            _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtgoal = Pms_Bll.get_AppraisalGoal(_obj_Spms_AppraisalGoal);

                            if (dtgoal.Rows.Count != 0)
                            {
                                txtempfeed.Text = Convert.ToString(dtgoal.Rows[0]["APP_GOALS_EMP_COMMENTS"]);

                                txtempfeed.Enabled = false;

                                if (txtempfeed.Visible == true)
                                {

                                    txtempfeed.Visible = false;

                                    btnsubmitempfeed.Visible = false;
                                    btncancelempfeed.Visible = false;
                                    btnupdateempfeed.Visible = false;


                                }
                                else
                                {

                                    txtempfeed.Visible = true;

                                    btncancelempfeed.Visible = true;
                                    btnsubmitempfeed.Visible = false;
                                    btnupdateempfeed.Visible = true;
                                    txtempfeed.Enabled = true;
                                    btnupdateempfeed.Enabled = true;
                                }
                            }
                            else
                            {

                                if (txtempfeed.Visible == true)
                                {

                                    txtempfeed.Visible = false;

                                    btnsubmitempfeed.Visible = false;
                                    btncancelempfeed.Visible = false;
                                    btnupdateempfeed.Visible = false;
                                }
                                else
                                {

                                    btncancelempfeed.Visible = true;
                                    btnsubmitempfeed.Visible = true;
                                    btnupdateempfeed.Visible = false;
                                    txtempfeed.Enabled = true;
                                    btnupdateempfeed.Enabled = true;
                                    txtempfeed.Visible = true;
                                }


                            }

                        }


                    }


                }

                catch (Exception ex)
                {
                    SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisal", ex.StackTrace, DateTime.Now);
                    Response.Redirect("~/Frm_ErrorPage.aspx");
                }


            }
            #endregion


            #region Manager Feedback
            else if (e.CommandName == "GoalMgr_Feed")
            {
                //_obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();

                //_obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(lblgsdt_id.Text);
                //_obj_Spms_AppraisalGoal.Mode = 5;
                //DataTable dtgoal = Pms_Bll.get_AppraisalGoal(_obj_Spms_AppraisalGoal);

                //if (dtgoal.Rows.Count != 0)
                //{
                //    txtmgrfeed.Text = Convert.ToString(dtgoal.Rows[0]["APP_GOALS_MGR_COMMENTS"]);
                //    rdratingmgr.Value = Convert.ToInt32(dtgoal.Rows[0]["APP_GOALS_MGR_RATING"]);
                //    btnsubmitmgrfeed.Text = "Update";
                //    if (txtmgrfeed.Visible == true)
                //    {

                //        rdratingmgr.Visible = false;
                //        txtmgrfeed.Visible = false;

                //        btnsubmitmgrfeed.Visible = false;
                //        btncancelmgrfeed.Visible = false;
                //    }
                //    else
                //    {

                //        rdratingmgr.Visible = true;
                //        txtmgrfeed.Visible = true;
                //        btnsubmitmgrfeed.Visible = true;
                //        btncancelmgrfeed.Visible = true;

                //    }
                //}
                //else
                //{
                //    if (txtmgrfeed.Visible == true)
                //    {

                //        rdratingmgr.Visible = false;
                //        txtmgrfeed.Visible = false;
                //        btnsubmitmgrfeed.Visible = false;
                //        btncancelmgrfeed.Visible = false;
                //    }
                //    else
                //    {

                //        rdratingmgr.Visible = true;
                //        txtmgrfeed.Visible = true;

                //        btnsubmitmgrfeed.Visible = true;
                //        btncancelmgrfeed.Visible = true;
                //    }


                //}

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
                    btnupdateempfeed.Visible = false;
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

                //if (txtmgrfeed.Visible == true)
                //{

                //    rdratingmgr.Visible = false;
                //    txtmgrfeed.Visible = false;
                //    btnsubmitmgrfeed.Visible = false;
                //    btncancelmgrfeed.Visible = false;
                //}
                //else
                //{

                //    rdratingmgr.Visible = true;
                //    txtmgrfeed.Visible = true;

                //    btnsubmitmgrfeed.Visible = true;
                //    btncancelmgrfeed.Visible = true;
                //}

            }

            #endregion

            #region Manager  Submit,Update
            else if (e.CommandName == "btn_GoalMgrSubmit")
            {

                //_obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();

                //_obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(lblgsdt_id.Text);
                //_obj_Spms_AppraisalGoal.Mode = 5;
                //DataTable dtgoal = Pms_Bll.get_AppraisalGoal(_obj_Spms_AppraisalGoal);
                //if (dtgoal.Rows.Count == 0)
                //{
                //    PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                //    _obj_Pms_Appraisalcycle.MODE = 11;
                //    _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                //    DataTable dtemzz2 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                //    _obj_Pms_Appraisalcycle.MODE = 8;
                //    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz2.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                //    DataTable dtappidzz2 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                //    _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                //    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                //    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz2.Rows[0]["APPRCYCLE_ID"]);
                //    _obj_Spms_Appraisal.Mode = 5;

                //    DataTable dtgoal1 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

                //    _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtgoal1.Rows[0]["APPRAISAL_ID"]);
                //    _obj_Spms_AppraisalGoal.Mode = 3;
                //    _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(lblgsdt_id.Text);
                //    _obj_Spms_AppraisalGoal.APP_GOALS_EMP_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(txtempfeed.Text));
                //    _obj_Spms_AppraisalGoal.APP_GOALS_MGR_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(txtmgrfeed.Text));
                //    _obj_Spms_AppraisalGoal.APP_GOALS_MGR_RATING = Convert.ToInt32(rdratingmgr.Value);
                //    _obj_Spms_AppraisalGoal.APP_GOALS_CREATEDBY = 1;
                //    _obj_Spms_AppraisalGoal.APP_GOALS_CREATEDDATE = DateTime.Now;
                //    bool status = Pms_Bll.set_AppraisalGoal(_obj_Spms_AppraisalGoal);
                //    if (status == true)
                //    {
                //        Pms_Bll.ShowMessage(this, "Mgr GoalFeedback Inserted Successfully");



                //        _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
                //        _obj_Pms_EmpGoalSetting.Mode = 8;
                //        _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                //        _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(dtappidzz2.Rows[0]["APPRCYCLE_ID"]);
                //        DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
                //        if (dt.Rows.Count != 0)
                //        {
                //            Rg_Appraisal_Goal.DataSource = dt;
                //            Rg_Appraisal_Goal.DataBind();
                //        }
                //     _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                //        _obj_Pms_Appraisalcycle.MODE = 11;
                //        _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                //        DataTable dtemzz23 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                //        _obj_Pms_Appraisalcycle.MODE = 8;
                //        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz23.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                //        DataTable dtappidzz23 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                //        _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                //        _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                //        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz23.Rows[0]["APPRCYCLE_ID"]);
                //        _obj_Spms_Appraisal.Mode = 5;

                //        DataTable dtg = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

                //        _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtg.Rows[0]["APPRAISAL_ID"]);
                //        _obj_Spms_AppraisalGoal.Mode = 7;

                //        DataTable dt1 = Pms_Bll.get_AppraisalGoal(_obj_Spms_AppraisalGoal);


                //        Rm_Appraisal_PAGE.SelectedIndex = 0;
                //        Rm_Appraisal_Goal.Visible = true;

                //        Rp_Appraisal_VIEWDETAILS.Visible = true;

                //        Rm_Kra_Details.Visible = true;
                //        return;
                //    }



                //}
                //else
                //{
                //    PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                //    _obj_Pms_Appraisalcycle.MODE = 11;
                //    _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                //    DataTable dtemzz2 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                //    _obj_Pms_Appraisalcycle.MODE = 8;
                //    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz2.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                //    DataTable dtappidzz2 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                //    _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                //    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                //    _obj_Spms_Appraisal.Mode = 5;
                //    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz2.Rows[0]["APPRCYCLE_ID"]);
                //    DataTable dtgoal1 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

                //    _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtgoal1.Rows[0]["APPRAISAL_ID"]);
                //    _obj_Spms_AppraisalGoal.Mode = 6;
                //    _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(lblgsdt_id.Text);
                //    _obj_Spms_AppraisalGoal.APP_GOALS_EMP_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(txtempfeed.Text));
                //    _obj_Spms_AppraisalGoal.APP_GOALS_MGR_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(txtmgrfeed.Text));
                //    _obj_Spms_AppraisalGoal.APP_GOALS_MGR_RATING = Convert.ToInt32(rdratingmgr.Value);
                //    _obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFBY = 1;
                //    _obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFDATE = DateTime.Now;
                //    bool status = Pms_Bll.set_AppraisalGoal(_obj_Spms_AppraisalGoal);
                //    if (status == true)
                //    {
                //        Pms_Bll.ShowMessage(this, "Mgr GoalFeedback Updated Successfully");
                //        _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
                //        _obj_Pms_EmpGoalSetting.Mode = 8;
                //        _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                //        DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
                //        if (dt.Rows.Count != 0)
                //        {
                //            Rg_Appraisal_Goal.DataSource = dt;
                //            Rg_Appraisal_Goal.DataBind();
                //        }
                //     _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                //        _obj_Pms_Appraisalcycle.MODE = 11;
                //        _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                //        DataTable dtemzz24 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                //        _obj_Pms_Appraisalcycle.MODE = 8;
                //        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz24.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                //        DataTable dtappidzz24 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                //        _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                //        _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                //        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz24.Rows[0]["APPRCYCLE_ID"]);
                //        _obj_Spms_Appraisal.Mode = 5;

                //        DataTable dtg = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

                //        _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtg.Rows[0]["APPRAISAL_ID"]);
                //        _obj_Spms_AppraisalGoal.Mode = 7;

                //        DataTable dt1 = Pms_Bll.get_AppraisalGoal(_obj_Spms_AppraisalGoal);


                //        Rm_Appraisal_PAGE.SelectedIndex = 0;
                //        Rm_Appraisal_Goal.Visible = true;

                //        Rp_Appraisal_VIEWDETAILS.Visible = true;

                //        Rm_Kra_Details.Visible = true;
                //        return;
                //    }

                //}
            }
            #endregion



            #region   Employee  Submit,Update

            else if (e.CommandName == "btn_GoalEmpSubmit")
            {
                try
                {
                    string o = txtempfeed.Text;
                    int g = Convert.ToInt32(rdrtgtargetachieve.Value);
                    if ((g > 0))
                    {
                        if ((o.Length >= 10))
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
                            else
                            {
                                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;
                            }
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtappidzL = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                            _obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();

                            _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(lblgsdt_id.Text);
                            _obj_Spms_AppraisalGoal.APP_GOALS_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                            _obj_Spms_AppraisalGoal.Mode = 5;
                            if (dtappidzL.Rows.Count != 0)
                            {
                                _obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFBY = Convert.ToInt32(dtappidzL.Rows[0]["APPRCYCLE_ID"]);
                            }
                            else
                            {
                                _obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFBY = 0;

                            }
                            _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtgoal = Pms_Bll.get_AppraisalGoal(_obj_Spms_AppraisalGoal);
                            if (dtgoal.Rows.Count == 0)
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
                                else
                                {
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;
                                }
                                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dtappidzz01 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                                _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                                _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                if (dtappidzz01.Rows.Count != 0)
                                {
                                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz01.Rows[0]["APPRCYCLE_ID"]);
                                }
                                else
                                {
                                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = 0;
                                }
                                _obj_Spms_Appraisal.Mode = 27;
                                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dtemp = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                                if (dtemp.Rows.Count != 0)
                                {
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
                                        _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
                                    }
                                    else
                                    {
                                        _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = "0";
                                    }

                                    _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                                    DataTable dt11 = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);

                                    PMS_GoalSettings_Details _obj_GSdetails = new PMS_GoalSettings_Details();
                                    _obj_GSdetails.GS_DETAILS_MODE = 7;
                                    _obj_GSdetails.GSDTL_TARGET_ACHEIVED = Convert.ToString(rdrtgtargetachieve.Value);
                                    if (dt11.Rows.Count != 0)
                                    {
                                        _obj_GSdetails.GSDTL_GS_ID = Convert.ToInt32(dt11.Rows[0]["GS_ID"]);
                                    }
                                    else
                                    {
                                        _obj_GSdetails.GSDTL_GS_ID = 0;
                                    }
                                    _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                                    _obj_GSdetails.GSDTL_ID = Convert.ToInt32(lblgsdt_id.Text);
                                    bool status8 = Pms_Bll.set_GSdetails(_obj_GSdetails);


                                    _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                                    _obj_Pms_Appraisalcycle.MODE = 11;
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                    DataTable dtemzz2 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                    _obj_Pms_Appraisalcycle.MODE = 8;
                                    if (dtemzz2.Rows.Count != 0)
                                    {
                                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz2.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                                    }
                                    else
                                    {
                                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;
                                    }
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                    DataTable dtappidzz2 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                    _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                    if (dtappidzz2.Rows.Count != 0)
                                    {
                                        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz2.Rows[0]["APPRCYCLE_ID"]);
                                    }
                                    else
                                    {
                                        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = 0;

                                    }
                                    _obj_Spms_Appraisal.Mode = 5;
                                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                    DataTable dtgoal1 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                                    if (dtgoal1.Rows.Count != 0)
                                    {

                                        _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtgoal1.Rows[0]["APPRAISAL_ID"]);
                                    }
                                    else
                                    {
                                        _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = 0;
                                    }
                                    _obj_Spms_AppraisalGoal.Mode = 3;
                                    _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(lblgsdt_id.Text);
                                    _obj_Spms_AppraisalGoal.APP_GOALS_EMP_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(txtempfeed.Text));
                                    _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                    _obj_Spms_AppraisalGoal.APP_GOALS_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                                    _obj_Spms_AppraisalGoal.APP_GOALS_CREATEDDATE = DateTime.Now;
                                    _obj_Spms_AppraisalGoal.APP_GOALS_FINAL = 0;
                                    bool status1 = Pms_Bll.set_AppraisalGoal(_obj_Spms_AppraisalGoal);
                                    if (status1 == true)
                                    {
                                        Pms_Bll.ShowMessage(this, "Employee Comments Inserted Successfully");
                                        _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                                        _obj_Pms_Appraisalcycle.MODE = 11;
                                        _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                        DataTable dtemzz25 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                        _obj_Pms_Appraisalcycle.MODE = 8;
                                        if (dtemzz25.Rows.Count != 0)
                                        {
                                            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz25.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                                        }
                                        else
                                        {
                                            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;
                                        }
                                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                        DataTable dtappidzz25 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                        _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                        if (dtappidzz25.Rows.Count != 0)
                                        {
                                            _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz25.Rows[0]["APPRCYCLE_ID"]);
                                        }
                                        else
                                        {
                                            _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = 0;

                                        }
                                        _obj_Spms_Appraisal.Mode = 5;
                                        _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                        DataTable dtgoal4 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

                                        _obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();
                                        if (dtgoal4.Rows.Count != 0)
                                        {
                                            _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtgoal4.Rows[0]["APPRAISAL_ID"]);
                                        }
                                        else
                                        {
                                            _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = 0;
                                        }
                                        _obj_Spms_AppraisalGoal.APP_EMP_GOAL_FIXED = Convert.ToString(1);
                                        _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                        _obj_Spms_AppraisalGoal.Mode = 17;
                                        bool status10 = Pms_Bll.set_AppraisalGoal(_obj_Spms_AppraisalGoal);
                                        LoadGrid();
                                        LOADFINALIZE();
                                        rdtp_DATEofAppraisal.SelectedDate = DateTime.Now;
                                        Rm_Appraisal_PAGE.SelectedIndex = 0;
                                        Rm_Appraisal_Goal.Visible = true;

                                        Rp_Appraisal_VIEWDETAILS.Visible = true;

                                        Rm_Kra_Details.Visible = true;

                                        return;
                                    }
                                }
                                else
                                {
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
                                        _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
                                    }
                                    else
                                    {
                                        _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = "0";
                                    }
                                    _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);

                                    DataTable dt11 = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
                                    PMS_GoalSettings_Details _obj_GSdetails = new PMS_GoalSettings_Details();
                                    _obj_GSdetails.GS_DETAILS_MODE = 7;
                                    _obj_GSdetails.GSDTL_TARGET_ACHEIVED = Convert.ToString(rdrtgtargetachieve.Value);
                                    if (dt11.Rows.Count != 0)
                                    {
                                        _obj_GSdetails.GSDTL_GS_ID = Convert.ToInt32(dt11.Rows[0]["GS_ID"]);
                                    }
                                    else
                                    {
                                        _obj_GSdetails.GSDTL_GS_ID = 0;

                                    }
                                    _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                                    _obj_GSdetails.GSDTL_ID = Convert.ToInt32(lblgsdt_id.Text);
                                    bool status8 = Pms_Bll.set_GSdetails(_obj_GSdetails);

                                    _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                    _obj_Spms_Appraisal.APPRAISAL_DATE = rdtp_DATEofAppraisal.SelectedDate.Value;
                                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                    _obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE = 1;
                                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(lbl_Apprais_id.Text);
                                    _obj_Spms_Appraisal.APPRAISAL_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                                    _obj_Spms_Appraisal.APPRAISAL_STATUS = 1;
                                    _obj_Spms_Appraisal.APPRAISAL_CREATEDDATE = DateTime.Now;

                                    _obj_Spms_Appraisal.Mode = 4;
                                    bool status = Pms_Bll.set_Appraisal(_obj_Spms_Appraisal);
                                    if (status == true)
                                    {
                                        _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                                        _obj_Pms_Appraisalcycle.MODE = 11;
                                        _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                        DataTable dtemzz2 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                        _obj_Pms_Appraisalcycle.MODE = 8;
                                        if (dtemzz2.Rows.Count != 0)
                                        {
                                            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz2.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                                        }

                                        else
                                        {
                                            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;

                                        }
                                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                        DataTable dtappidzz2 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                        _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                                        _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                        _obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE = 1;
                                        if (dtappidzz2.Rows.Count != 0)
                                        {
                                            _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz2.Rows[0]["APPRCYCLE_ID"]);
                                        }

                                        else
                                        {
                                            _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = 0;
                                        }
                                        _obj_Spms_Appraisal.Mode = 5;
                                        _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                        DataTable dtgoal1 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                                        if (dtgoal1.Rows.Count != 0)
                                        {
                                            _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtgoal1.Rows[0]["APPRAISAL_ID"]);
                                        }
                                        else
                                        {
                                            _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = 0;
                                        }
                                        _obj_Spms_AppraisalGoal.Mode = 3;
                                        _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(lblgsdt_id.Text);
                                        _obj_Spms_AppraisalGoal.APP_GOALS_EMP_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(txtempfeed.Text));
                                        _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                        _obj_Spms_AppraisalGoal.APP_GOALS_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                                        _obj_Spms_AppraisalGoal.APP_GOALS_CREATEDDATE = DateTime.Now;
                                        _obj_Spms_AppraisalGoal.APP_GOALS_FINAL = 0;
                                        bool status1 = Pms_Bll.set_AppraisalGoal(_obj_Spms_AppraisalGoal);
                                        if (status1 == true)
                                        {
                                            Pms_Bll.ShowMessage(this, "Employee Comments Inserted Successfully");
                                            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                                            _obj_Pms_Appraisalcycle.MODE = 11;
                                            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                            DataTable dtemzz26 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                            _obj_Pms_Appraisalcycle.MODE = 8;
                                            if (dtemzz26.Rows.Count != 0)
                                            {
                                                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz26.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                                            }
                                            else
                                            {
                                                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;
                                            }
                                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                            DataTable dtappidzz26 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                            _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                            if (dtappidzz26.Rows.Count != 0)
                                            {
                                                _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz26.Rows[0]["APPRCYCLE_ID"]);
                                            }
                                            else
                                            {
                                                _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = 0;
                                            }
                                            _obj_Spms_Appraisal.Mode = 5;
                                            _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                            DataTable dtgoal4 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

                                            _obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();
                                            if (dtgoal4.Rows.Count != 0)
                                            {
                                                _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtgoal4.Rows[0]["APPRAISAL_ID"]);
                                            }
                                            else
                                            {
                                                _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = 0;
                                            }
                                            _obj_Spms_AppraisalGoal.APP_EMP_GOAL_FIXED = Convert.ToString(1);
                                            _obj_Spms_AppraisalGoal.Mode = 17;
                                            _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                            bool status10 = Pms_Bll.set_AppraisalGoal(_obj_Spms_AppraisalGoal);
                                            LoadGrid();
                                            LOADFINALIZE();
                                            rdtp_DATEofAppraisal.SelectedDate = DateTime.Now;
                                            Rm_Appraisal_PAGE.SelectedIndex = 0;
                                            Rm_Appraisal_Goal.Visible = true;

                                            Rp_Appraisal_VIEWDETAILS.Visible = true;

                                            Rm_Kra_Details.Visible = true;

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
                                DataTable dtemzz2 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                _obj_Pms_Appraisalcycle.MODE = 8;
                                if (dtemzz2.Rows.Count != 0)
                                {
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz2.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                                }

                                else
                                {
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;
                                }
                                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dtappidzz2 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                                _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                _obj_Spms_Appraisal.Mode = 5;
                                if (dtappidzz2.Rows.Count != 0)
                                {
                                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz2.Rows[0]["APPRCYCLE_ID"]);
                                }
                                else
                                {
                                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = 0;

                                }
                                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dtgoal1 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                                if (dtgoal1.Rows.Count != 0)
                                {
                                    _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtgoal1.Rows[0]["APPRAISAL_ID"]);
                                }
                                else
                                {
                                    _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = 0;
                                }
                                _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                _obj_Spms_AppraisalGoal.Mode = 6;
                                _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(lblgsdt_id.Text);
                                _obj_Spms_AppraisalGoal.APP_GOALS_EMP_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(txtempfeed.Text));

                                _obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                                _obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFDATE = DateTime.Now;
                                bool status = Pms_Bll.set_AppraisalGoal(_obj_Spms_AppraisalGoal);
                                if (status == true)
                                {
                                    Pms_Bll.ShowMessage(this, "Employee GoalFeedback Updated Successfully");
                                    LoadGrid();

                                    rdtp_DATEofAppraisal.SelectedDate = DateTime.Now;
                                    Rm_Appraisal_PAGE.SelectedIndex = 0;
                                    Rm_Appraisal_Goal.Visible = true;

                                    Rp_Appraisal_VIEWDETAILS.Visible = true;

                                    Rm_Kra_Details.Visible = true;
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
                        Pms_Bll.ShowMessage(this, "Please Select Target Achieved");
                        return;

                    }

                }

                catch (Exception ex)
                {
                    SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisal", ex.StackTrace, DateTime.Now);
                    Response.Redirect("~/Frm_ErrorPage.aspx");
                }
            }



            #endregion

            #region employee goal update
            else if (e.CommandName == "btn_GoalEmpUpdate")
            {
                try
                {
                    string q = txtempfeed.Text;

                    int g = Convert.ToInt32(rdrtgtargetachieve.Value);

                    if ((g > 0))
                    {
                        if ((q.Length >= 10))
                        {
                            PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                            _obj_Pms_Appraisalcycle.MODE = 11;
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtemzz2 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                            _obj_Pms_Appraisalcycle.MODE = 8;
                            if (dtemzz2.Rows.Count != 0)
                            {
                                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz2.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                            }
                            else
                            {
                                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;

                            }
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtappidzz2 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                            _obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();


                            _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                            _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                            if (dtappidzz2.Rows.Count != 0)
                            {
                                _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz2.Rows[0]["APPRCYCLE_ID"]);
                            }
                            else
                            {
                                _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = 0;

                            }
                            _obj_Spms_Appraisal.Mode = 5;
                            _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtgoal1 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

                            PMS_GoalSettings_Details _obj_GSdetails = new PMS_GoalSettings_Details();
                            _obj_GSdetails.GS_DETAILS_MODE = 9;
                            _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_GSdetails.GSDTL_ID = Convert.ToInt32(lblgsdt_id.Text);
                            _obj_GSdetails.GSDTL_TARGET_ACHEIVED = Convert.ToString(rdrtgtargetachieve.Value);
                            bool stat = Pms_Bll.set_GSdetails(_obj_GSdetails);
                            if (dtgoal1.Rows.Count != 0)
                            {
                                _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtgoal1.Rows[0]["APPRAISAL_ID"]);
                            }
                            else
                            {
                                _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = 0;
                            }

                            _obj_Spms_AppraisalGoal.Mode = 18;
                            _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(lblgsdt_id.Text);

                            _obj_Spms_AppraisalGoal.APP_GOALS_EMP_COMMENTS = Convert.ToString(txtempfeed.Text);

                            _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            bool status1 = Pms_Bll.set_AppraisalGoal(_obj_Spms_AppraisalGoal);
                            if (status1 == true)
                            {
                                Pms_Bll.ShowMessage(this, "Employee Feedback Updated Successfully");

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
                                    _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
                                }

                                else
                                {
                                    _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = "0";
                                }
                                _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
                                if (dt.Rows.Count != 0)
                                {
                                    int GSID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);

                                    _obj_GSdetails = new PMS_GoalSettings_Details();
                                    _obj_GSdetails.GSDTL_GS_ID = GSID;
                                    _obj_GSdetails.GS_DETAILS_MODE = 5;
                                }
                                _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dt_details = new DataTable();
                                dt_details = Pms_Bll.get_GSdetails(_obj_GSdetails);
                                if (dt_details.Rows.Count != 0)
                                {
                                    Rg_Appraisal_Goal.DataSource = dt_details;
                                    Rg_Appraisal_Goal.DataBind();
                                }

                                //LoadKraGrid();

                                LoadGrid();
                                LOADFINALIZE();
                                rdtp_DATEofAppraisal.SelectedDate = DateTime.Now;
                                Rm_Appraisal_PAGE.SelectedIndex = 0;
                                Rm_Appraisal_Goal.Visible = true;

                                Rp_Appraisal_VIEWDETAILS.Visible = true;

                                Rm_Kra_Details.Visible = true;


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
                        Pms_Bll.ShowMessage(this, "Please Select Target Achieved");
                        return;
                    }
                }

                catch (Exception ex)
                {
                    SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisal", ex.StackTrace, DateTime.Now);
                    Response.Redirect("~/Frm_ErrorPage.aspx");
                }

            }
            #endregion

        }
        catch (Exception ex)
        {
            Pms_Bll.ShowMessage(this, ex.Message.ToString());
            return;
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

            lblkradt_id = Rg_Appraisal_Kra.Rows[i].FindControl("lbl_Kra_Id") as Label;
            lblappraisalKradtl = Rg_Appraisal_Kra.Rows[i].FindControl("lbl_Kra_AppraisalCycle") as Label;
            TextBox txtKraEmployeeFeedback = new System.Web.UI.WebControls.TextBox();
            Button btnKraEmpSubmit = new System.Web.UI.WebControls.Button();
            Button btnKraEmpCancel = new System.Web.UI.WebControls.Button();
            Button btnKraEmpUpdate = new System.Web.UI.WebControls.Button();
            txtKraEmployeeFeedback = Rg_Appraisal_Kra.Rows[i].FindControl("txt_KraEmployeeFeedback") as TextBox;
            btnKraEmpSubmit = Rg_Appraisal_Kra.Rows[i].FindControl("btn_KraEmpSubmit") as Button;
            btnKraEmpCancel = Rg_Appraisal_Kra.Rows[i].FindControl("btn_KraEmpCancel") as Button;
            btnKraEmpUpdate = Rg_Appraisal_Kra.Rows[i].FindControl("btn_KraEmpUpdate") as Button;
            RadRating rdrtgtargetachievekra = new Telerik.Web.UI.RadRating();
            rdrtgtargetachievekra = Rg_Appraisal_Kra.Rows[i].FindControl("ratingPiekra") as RadRating;


            TextBox txtKraManagerFeedback = new System.Web.UI.WebControls.TextBox();
            Button btnKraMgrSubmit = new System.Web.UI.WebControls.Button();
            Button btnKraMgrCancel = new System.Web.UI.WebControls.Button();
            RadRating rdrtgKraMgr = new Telerik.Web.UI.RadRating();
            txtKraManagerFeedback = Rg_Appraisal_Kra.Rows[i].FindControl("txt_KraManagerFeedback") as TextBox;
            btnKraMgrSubmit = Rg_Appraisal_Kra.Rows[i].FindControl("btn_KraMgrSubmit") as Button;
            btnKraMgrCancel = Rg_Appraisal_Kra.Rows[i].FindControl("btn_KraMgrCancel") as Button;
            rdrtgKraMgr = Rg_Appraisal_Kra.Rows[i].FindControl("rdrtg_KraMgr") as RadRating;

            #region Employee Kra Feedback


            if (e.CommandName == "KraEmployee_Feed")
            {

                try
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

                    else
                    {
                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;

                    }
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtappidzL = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                    _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);

                    if (dtappidzL.Rows.Count != 0)
                    {
                        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzL.Rows[0]["APPRCYCLE_ID"]);
                    }

                    else
                    {
                        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = 0;
                    }
                    _obj_Spms_Appraisal.Mode = 35;
                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtgoal9 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                    //if (dtgoal9.Rows[0]["APP_KRA_EMP_FIXED"] == System.DBNull.Value)
                    //{
                    if (dtgoal9.Rows.Count == 0)
                    {
                        _obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                        _obj_Spms_AppraisalKra.APP_KRA_KRA_ID = Convert.ToInt32(lblkradt_id.Text);
                        _obj_Spms_AppraisalKra.APP_KRA_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                        _obj_Spms_AppraisalKra.Mode = 5;
                        if (dtappidzL.Rows.Count != 0)
                        {

                            _obj_Spms_AppraisalKra.APP_KRA_LASTMDFBY = Convert.ToInt32(dtappidzL.Rows[0]["APPRCYCLE_ID"]);
                        }

                        else
                        {
                            _obj_Spms_AppraisalKra.APP_KRA_LASTMDFBY = 0;
                        }
                        _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtKra = Pms_Bll.get_AppraisalKra(_obj_Spms_AppraisalKra);
                        if (dtKra.Rows.Count != 0)
                        {
                            txtKraEmployeeFeedback.Text = Convert.ToString(dtKra.Rows[0]["APP_KRA_EMP_COMMENTS"]);
                            txtKraEmployeeFeedback.Enabled = false;
                            if (txtKraEmployeeFeedback.Visible == true)
                            {
                                txtKraEmployeeFeedback.Visible = false;
                                btnKraEmpSubmit.Visible = false;
                                btnKraEmpCancel.Visible = false;
                                btnKraEmpUpdate.Visible = false;

                            }
                            else
                            {
                                txtKraEmployeeFeedback.Visible = true;
                                btnKraEmpSubmit.Visible = false;
                                btnKraEmpCancel.Visible = true;
                                btnKraEmpUpdate.Visible = true;

                            }
                        }
                        else
                        {
                            if (txtKraEmployeeFeedback.Visible == true)
                            {
                                txtKraEmployeeFeedback.Visible = false;
                                btnKraEmpSubmit.Visible = false;
                                btnKraEmpCancel.Visible = false;
                                btnKraEmpUpdate.Visible = false;

                            }
                            else
                            {
                                txtKraEmployeeFeedback.Visible = true;
                                btnKraEmpSubmit.Visible = true;
                                btnKraEmpCancel.Visible = true;
                                btnKraEmpUpdate.Visible = false;

                            }
                        }
                    }

                    else
                    {
                        if ((Convert.ToInt32(dtgoal9.Rows[0]["APP_KRA_EMP_FIXED"]) == 2))
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
                            else
                            {
                                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;
                            }
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtappidzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                            _obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                            _obj_Spms_AppraisalKra.APP_KRA_KRA_ID = Convert.ToInt32(lblkradt_id.Text);
                            _obj_Spms_AppraisalKra.APP_KRA_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                            if (dtappidzz.Rows.Count != 0)
                            {
                                _obj_Spms_AppraisalKra.APP_KRA_LASTMDFBY = Convert.ToInt32(dtappidzz.Rows[0]["APPRCYCLE_ID"]);
                            }
                            else
                            {
                                _obj_Spms_AppraisalKra.APP_KRA_LASTMDFBY = 0;
                            }
                            _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Spms_AppraisalKra.Mode = 5;
                            DataTable dtKra = Pms_Bll.get_AppraisalKra(_obj_Spms_AppraisalKra);
                            if (dtKra.Rows.Count != 0)
                            {
                                txtKraEmployeeFeedback.Text = Convert.ToString(dtKra.Rows[0]["APP_KRA_EMP_COMMENTS"]);
                                txtKraEmployeeFeedback.Enabled = false;
                                if (txtKraEmployeeFeedback.Visible == true)
                                {
                                    txtKraEmployeeFeedback.Visible = false;
                                    btnKraEmpSubmit.Visible = false;
                                    btnKraEmpCancel.Visible = false;
                                    btnKraEmpUpdate.Visible = false;

                                }
                                else
                                {
                                    txtKraEmployeeFeedback.Visible = true;
                                    btnKraEmpSubmit.Visible = false;
                                    btnKraEmpCancel.Visible = false;
                                    btnKraEmpUpdate.Visible = false;

                                }
                            }
                            else
                            {
                                if (txtKraEmployeeFeedback.Visible == true)
                                {
                                    txtKraEmployeeFeedback.Visible = false;
                                    btnKraEmpSubmit.Visible = false;
                                    btnKraEmpCancel.Visible = false;
                                    btnKraEmpUpdate.Visible = false;

                                }
                                else
                                {
                                    txtKraEmployeeFeedback.Visible = true;
                                    btnKraEmpSubmit.Visible = true;
                                    btnKraEmpCancel.Visible = true;
                                    btnKraEmpUpdate.Visible = false;


                                }
                            }
                        }
                        else if ((Convert.ToInt32(dtgoal9.Rows[0]["APP_KRA_EMP_FIXED"]) == 1))
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
                            else
                            {
                                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;
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
                            else
                            {
                                _obj_Spms_AppraisalKra.APP_KRA_LASTMDFBY = 0;
                            }
                            _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtKra = Pms_Bll.get_AppraisalKra(_obj_Spms_AppraisalKra);
                            if (dtKra.Rows.Count != 0)
                            {
                                txtKraEmployeeFeedback.Text = Convert.ToString(dtKra.Rows[0]["APP_KRA_EMP_COMMENTS"]);
                                txtKraEmployeeFeedback.Enabled = false;
                                if (txtKraEmployeeFeedback.Visible == true)
                                {
                                    txtKraEmployeeFeedback.Visible = false;
                                    btnKraEmpSubmit.Visible = false;
                                    btnKraEmpCancel.Visible = false;
                                    btnKraEmpUpdate.Visible = false;

                                }
                                else
                                {
                                    txtKraEmployeeFeedback.Visible = true;
                                    btnKraEmpSubmit.Visible = false;
                                    btnKraEmpCancel.Visible = true;
                                    txtKraEmployeeFeedback.Enabled = true;
                                    btnKraEmpUpdate.Visible = true;
                                    btnKraEmpUpdate.Enabled = true;
                                }
                            }
                            else
                            {
                                if (txtKraEmployeeFeedback.Visible == true)
                                {
                                    txtKraEmployeeFeedback.Visible = false;
                                    btnKraEmpSubmit.Visible = false;
                                    btnKraEmpCancel.Visible = false;
                                    btnKraEmpUpdate.Visible = false;

                                }
                                else
                                {
                                    txtKraEmployeeFeedback.Visible = true;
                                    btnKraEmpSubmit.Visible = true;
                                    btnKraEmpCancel.Visible = true;
                                    txtKraEmployeeFeedback.Enabled = true;
                                    btnKraEmpUpdate.Visible = false;
                                    btnKraEmpUpdate.Enabled = true;

                                }
                            }
                        }



                    }
                }

                catch (Exception ex)
                {
                    SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisal", ex.StackTrace, DateTime.Now);
                    Response.Redirect("~/Frm_ErrorPage.aspx");
                }
            }
            #endregion



            #region Manager Kra Feedback
            else if (e.CommandName == "KraMgr_Feed")
            {
                //    try
                //{
                //    _obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                //    _obj_Spms_AppraisalKra.APP_KRA_KRA_ID = Convert.ToInt32(lblkradt_id.Text);
                //    _obj_Spms_AppraisalKra.Mode = 5;
                //    DataTable dtKra1 = Pms_Bll.get_AppraisalKra(_obj_Spms_AppraisalKra);

                //    if (dtKra1.Rows.Count != 0)
                //    {
                //        txtKraManagerFeedback.Text = Convert.ToString(dtKra1.Rows[0]["APP_KRA_MGR_COMMENTS"]);
                //        rdrtgKraMgr.Value = Convert.ToInt32(dtKra1.Rows[0]["APP_KRA_MGR_RATING"]);
                //        btnKraMgrSubmit.Text = "Update";
                //        if (txtKraManagerFeedback.Visible == true)
                //        {

                //            rdrtgKraMgr.Visible = false;
                //            txtKraManagerFeedback.Visible = false;
                //            btnKraMgrSubmit.Visible = false;
                //            btnKraMgrCancel.Visible = false;
                //        }
                //        else
                //        {
                //            rdrtgKraMgr.Visible = true;
                //            txtKraManagerFeedback.Visible = true;
                //            btnKraMgrSubmit.Visible = true;
                //            btnKraMgrCancel.Visible = true;
                //        }
                //    }
                //    else
                //    {
                //        if (txtKraManagerFeedback.Visible == true)
                //        {
                //            rdrtgKraMgr.Visible = false;
                //            txtKraManagerFeedback.Visible = false;
                //            btnKraMgrSubmit.Visible = false;
                //            btnKraMgrCancel.Visible = false;
                //        }
                //        else
                //        {
                //            rdrtgKraMgr.Visible = true;
                //            txtKraManagerFeedback.Visible = true;
                //            btnKraMgrSubmit.Visible = true;
                //            btnKraMgrCancel.Visible = true;
                //        }

                //    }
                //}
                //    catch (Exception ex)
                //    {
                //        Pms_Bll.ShowMessage(this, ex.Message.ToString());
                //        return;
                //    }
            }
            #endregion

            #region Employee Kra Cancel

            else if (e.CommandName == "btn_KraEmpCancel")
            {
                try
                {
                    if (txtKraEmployeeFeedback.Visible == true)
                    {
                        txtKraEmployeeFeedback.Visible = false;
                        btnKraEmpSubmit.Visible = false;
                        btnKraEmpCancel.Visible = false;
                        btnKraEmpUpdate.Visible = false;

                    }
                    else
                    {
                        txtKraEmployeeFeedback.Visible = true;
                        btnKraEmpSubmit.Visible = true;
                        btnKraEmpCancel.Visible = true;

                    }

                }

                catch (Exception ex)
                {
                    SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisal", ex.StackTrace, DateTime.Now);
                    Response.Redirect("~/Frm_ErrorPage.aspx");
                }
            }
            #endregion

            #region Manager Kra Cancel

            else if (e.CommandName == "btn_KraMgrCancel")
            {
                //try
                //{
                //    if (txtKraManagerFeedback.Visible == true)
                //    {
                //        rdrtgKraMgr.Visible = false;
                //        txtKraManagerFeedback.Visible = false;
                //        btnKraMgrSubmit.Visible = false;
                //        btnKraMgrCancel.Visible = false;
                //    }
                //    else
                //    {
                //        rdrtgKraMgr.Visible = true;
                //        txtKraManagerFeedback.Visible = true;
                //        btnKraMgrSubmit.Visible = true;
                //        btnKraMgrCancel.Visible = true;
                //    }

                //}
                //catch (Exception ex)
                //{
                //    Pms_Bll.ShowMessage(this, ex.Message.ToString());
                //    return;
                //}
            }

            #endregion

            #region Manager KRA  Submit,Update
            else if (e.CommandName == "btn_KraMgrSubmit")
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
                //    if(dtgoal4.Rows.Count !=0)
                //    {
                //    _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtgoal4.Rows[0]["APPRAISAL_ID"]);
                //    }
                //    _obj_Spms_AppraisalKra.Mode = 3;
                //    _obj_Spms_AppraisalKra.APP_KRA_KRA_ID = Convert.ToInt32(lblkradt_id.Text);
                //    _obj_Spms_AppraisalKra.APP_KRA_EMP_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(txtKraEmployeeFeedback.Text));
                //    _obj_Spms_AppraisalKra.APP_KRA_MGR_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(txtKraManagerFeedback.Text));
                //    _obj_Spms_AppraisalKra.APP_KRA_MGR_RATING = Convert.ToInt32(rdrtgKraMgr.Value);
                //    _obj_Spms_AppraisalKra.APP_KRA_CREATEDBY = 1;
                //    _obj_Spms_AppraisalKra.APP_KRA_CREATEDDATE = DateTime.Now;
                //    bool status1 = Pms_Bll.set_AppraisalKra(_obj_Spms_AppraisalKra);
                //    if (status1 == true)
                //    {
                //        Pms_Bll.ShowMessage(this, "Mgr KraFeedback Inserted Successfully");
                //        _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
                //        _obj_Pms_EmpGoalSetting.Mode = 8;
                //        _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                //        DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
                //        if (dt.Rows.Count != 0)
                //        {
                //            _obj_Spms_GoalStgKraDtls = new SPMS_GOALSETTINGKRADETAILS();
                //            _obj_Spms_GoalStgKraDtls.Mode = 7;
                //            _obj_Spms_GoalStgKraDtls.GS_KRA_GSDTL_ID = Convert.ToInt32(dt.Rows[0]["GOALCHILDDTL_ID"]);
                //            DataTable dt2 = Pms_Bll.get_GoalStgKraDtls(_obj_Spms_GoalStgKraDtls);

                //            if (dt2.Rows.Count != 0)
                //            {
                //                Rg_Appraisal_Kra.DataSource = dt2;
                //                Rg_Appraisal_Kra.DataBind();
                //            }
                //        }


                //        _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                //        _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);

                //        _obj_Spms_Appraisal.Mode = 5;
                //        DataTable dtgo = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                //        if(dtgo.Rows.Count !=0)
                //        {
                //        _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtgo.Rows[0]["APPRAISAL_ID"]);
                //        }
                //        _obj_Spms_AppraisalKra.Mode = 7;
                //        DataTable dt5 = Pms_Bll.get_AppraisalKra(_obj_Spms_AppraisalKra);

                //        Rm_Appraisal_PAGE.SelectedIndex = 0;
                //        Rm_Appraisal_Goal.Visible = true;

                //        Rg_Appraisal_Kra.Visible = true;
                //        Rp_Appraisal_VIEWDETAILS.Visible = true;
                //        Rm_Appraisal_Kra.SelectedIndex = 0;
                //        Rm_Kra_Details.Visible = true;
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
                //        Pms_Bll.ShowMessage(this, "Mgr KraFeedback Updated Successfully");

                //        _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
                //        _obj_Pms_EmpGoalSetting.Mode = 8;
                //        _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                //        DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
                //        if (dt.Rows.Count != 0)
                //        {
                //            _obj_Spms_GoalStgKraDtls = new SPMS_GOALSETTINGKRADETAILS();
                //            _obj_Spms_GoalStgKraDtls.Mode = 7;
                //            _obj_Spms_GoalStgKraDtls.GS_KRA_GSDTL_ID = Convert.ToInt32(dt.Rows[0]["GOALCHILDDTL_ID"]);
                //            DataTable dt2 = Pms_Bll.get_GoalStgKraDtls(_obj_Spms_GoalStgKraDtls);

                //            if (dt2.Rows.Count != 0)
                //            {
                //                Rg_Appraisal_Kra.DataSource = dt2;
                //                Rg_Appraisal_Kra.DataBind();
                //            }
                //        }

                //        _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                //        _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);

                //        _obj_Spms_Appraisal.Mode = 5;
                //        DataTable dtgo = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                //        _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtgo.Rows[0]["APPRAISAL_ID"]);
                //        _obj_Spms_AppraisalKra.Mode = 7;
                //        DataTable dt6 = Pms_Bll.get_AppraisalKra(_obj_Spms_AppraisalKra);

                //        Rm_Appraisal_PAGE.SelectedIndex = 0;
                //        Rm_Appraisal_Goal.Visible = true;

                //        Rg_Appraisal_Kra.Visible = true;
                //        Rp_Appraisal_VIEWDETAILS.Visible = true;
                //        Rm_Appraisal_Kra.SelectedIndex = 0;
                //        Rm_Kra_Details.Visible = true;
                //        return;
                //    }
                //}
            }
            #endregion



            #region   EmployeeKra  Submit

            else if (e.CommandName == "btn_KraEmpSubmit")
            {
                try
                {
                    string q = txtKraEmployeeFeedback.Text;

                    int g = Convert.ToInt32(rdrtgtargetachievekra.Value);

                    if ((g > 0))
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

                            else
                            {
                                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;
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

                            else
                            {
                                _obj_Spms_AppraisalKra.APP_KRA_LASTMDFBY = 0;
                            }
                            _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtkra3 = Pms_Bll.get_AppraisalKra(_obj_Spms_AppraisalKra);
                            if (dtkra3.Rows.Count == 0)
                            {
                                _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                                _obj_Pms_Appraisalcycle.MODE = 11;
                                _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dtem1E = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                _obj_Pms_Appraisalcycle.MODE = 8;
                                if (dtem1E.Rows.Count != 0)
                                {
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem1E.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                                }
                                else
                                {
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;

                                }
                                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dtappid1E = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                                _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                                _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                _obj_Spms_Appraisal.Mode = 27;
                                if (dtappid1E.Rows.Count != 0)
                                {
                                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappid1E.Rows[0]["APPRCYCLE_ID"]);
                                }

                                else
                                {
                                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = 0;

                                }
                                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dtemp = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                                if (dtemp.Rows.Count != 0)
                                {
                                    _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                                    _obj_Pms_Appraisalcycle.MODE = 11;
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                    DataTable dtem1 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                    _obj_Pms_Appraisalcycle.MODE = 8;
                                    if (dtem1.Rows.Count != 0)
                                    {
                                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem1.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                                    }
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                    DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                                    _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
                                    _obj_Pms_EmpGoalSetting.Mode = 10;

                                    _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                    if (dtappid.Rows.Count != 0)
                                    {
                                        _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
                                    }
                                    _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                                    DataTable dt11 = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);

                                    PMS_EMPSETUP _obj_Pms_EmpSetup = new PMS_EMPSETUP();
                                    _obj_Pms_EmpSetup.Mode = 17;
                                    _obj_Pms_EmpSetup.EMP_SETUP_LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                                    _obj_Pms_EmpSetup.EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                    DataTable dtem = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);


                                    SPMS_ROLES _obj_Pms_Roles = new SPMS_ROLES();
                                    _obj_Pms_Roles.Mode = 6;
                                    if (dtem.Rows.Count != 0)
                                    {
                                        _obj_Pms_Roles.BUID = Convert.ToInt32(dtem.Rows[0]["BU_ID"]);
                                    }
                                    _obj_Pms_Roles.ROLES_NAME = Convert.ToString(rtxt_Role.Text);
                                    _obj_Pms_Roles.ROLES_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);

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



                                    GOALSETTING_GOALKRA_DETAILS _obj_Pms_goalkradetails = new GOALSETTING_GOALKRA_DETAILS();
                                    _obj_Pms_goalkradetails.MODE = 8;
                                    _obj_Pms_goalkradetails.GS_KRA_TARGET_ACHEIVED = Convert.ToString(rdrtgtargetachievekra.Value);
                                    if (dt11.Rows.Count != 0)
                                    {
                                        _obj_Pms_goalkradetails.GS_KRA_GS_ID = Convert.ToInt32(dt11.Rows[0]["GS_ID"]);
                                    }
                                    if (dt20.Rows.Count != 0)
                                    {
                                        _obj_Pms_goalkradetails.GS_KRA_KRA_ID = Convert.ToInt32(lblkradt_id.Text); //Convert.ToInt32(dt20.Rows[0]["ROLEKRA_ID"]);
                                    }
                                    _obj_Pms_goalkradetails.GS_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                    bool status8 = Pms_Bll.set_Gskra(_obj_Pms_goalkradetails);


                                    _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                                    _obj_Pms_Appraisalcycle.MODE = 11;
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                    DataTable dtemzz2 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                    _obj_Pms_Appraisalcycle.MODE = 8;
                                    if (dtemzz2.Rows.Count != 0)
                                    {
                                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz2.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                                    }
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                    DataTable dtappidzz2 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                                    _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                    if (dtappidzz2.Rows.Count != 0)
                                    {
                                        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz2.Rows[0]["APPRCYCLE_ID"]);
                                    }
                                    _obj_Spms_Appraisal.Mode = 5;
                                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                    DataTable dtgoal4 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

                                    if (dtgoal4.Rows.Count != 0)
                                    {
                                        _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtgoal4.Rows[0]["APPRAISAL_ID"]);
                                    }
                                    _obj_Spms_AppraisalKra.Mode = 3;
                                    _obj_Spms_AppraisalKra.APP_KRA_KRA_ID = Convert.ToInt32(lblkradt_id.Text);
                                    _obj_Spms_AppraisalKra.APP_KRA_EMP_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(txtKraEmployeeFeedback.Text));
                                    _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                    _obj_Spms_AppraisalKra.APP_KRA_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                                    _obj_Spms_AppraisalKra.APP_KRA_CREATEDDATE = DateTime.Now;
                                    _obj_Spms_AppraisalKra.APP_KRA_FINAL = 0;
                                    bool status1 = Pms_Bll.set_AppraisalKra(_obj_Spms_AppraisalKra);//yyyy
                                    if (status1 == true)
                                    {
                                        Pms_Bll.ShowMessage(this, "Employee Comments Inserted Successfully");
                                        _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                                        _obj_Pms_Appraisalcycle.MODE = 11;
                                        _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                        DataTable dtemzz27 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                        _obj_Pms_Appraisalcycle.MODE = 8;
                                        if (dtemzz27.Rows.Count != 0)
                                        {
                                            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz27.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                                        }
                                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                        DataTable dtappidzz27 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                                        _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                        if (dtappidzz27.Rows.Count != 0)
                                        {
                                            _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz27.Rows[0]["APPRCYCLE_ID"]);
                                        }

                                        _obj_Spms_Appraisal.Mode = 5;
                                        _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                        DataTable dtgoal44 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

                                        _obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                                        if (dtgoal44.Rows.Count != 0)
                                        {
                                            _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtgoal44.Rows[0]["APPRAISAL_ID"]);
                                        }
                                        _obj_Spms_AppraisalKra.APP_KRA_EMP_FIXED = Convert.ToString(1);
                                        _obj_Spms_AppraisalKra.Mode = 18;
                                        _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                        bool status10 = Pms_Bll.set_AppraisalKra(_obj_Spms_AppraisalKra);
                                        LoadKraGrid();
                                        LOADkraFINALIZE();
                                        rdtp_DATEofAppraisal.SelectedDate = DateTime.Now;
                                        Rg_Appraisal_Goal.Visible = false;

                                        Rm_Appraisal_PAGE.SelectedIndex = 0;
                                        Rm_Appraisal_Goal.Visible = true;

                                        Rg_Appraisal_Kra.Visible = true;
                                        Rp_Appraisal_VIEWDETAILS.Visible = true;
                                        Rm_Appraisal_Kra.SelectedIndex = 0;


                                        return;
                                    }
                                }
                                else
                                {

                                    _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                    _obj_Spms_Appraisal.APPRAISAL_DATE = rdtp_DATEofAppraisal.SelectedDate.Value;
                                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                    _obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE = 1;
                                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(lbl_Apprais_id.Text);
                                    _obj_Spms_Appraisal.APPRAISAL_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                                    _obj_Spms_Appraisal.APPRAISAL_STATUS = 1;
                                    _obj_Spms_Appraisal.APPRAISAL_CREATEDDATE = DateTime.Now;

                                    _obj_Spms_Appraisal.Mode = 4;
                                    bool status = Pms_Bll.set_Appraisal(_obj_Spms_Appraisal);

                                    _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                                    _obj_Pms_Appraisalcycle.MODE = 11;
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                    DataTable dtem1 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                    _obj_Pms_Appraisalcycle.MODE = 8;
                                    if (dtem1.Rows.Count != 0)
                                    {
                                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem1.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                                    }
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                    DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                                    _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
                                    _obj_Pms_EmpGoalSetting.Mode = 10;

                                    _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                    if (dtappid.Rows.Count != 0)
                                    {
                                        _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
                                    }
                                    _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                                    DataTable dt11 = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
                                    PMS_EMPSETUP _obj_Pms_EmpSetup = new PMS_EMPSETUP();
                                    _obj_Pms_EmpSetup.Mode = 17;
                                    _obj_Pms_EmpSetup.EMP_SETUP_LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                                    _obj_Pms_EmpSetup.EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                    DataTable dtem = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);


                                    SPMS_ROLES _obj_Pms_Roles = new SPMS_ROLES();
                                    _obj_Pms_Roles.Mode = 6;
                                    if (dtem.Rows.Count != 0)
                                    {
                                        _obj_Pms_Roles.BUID = Convert.ToInt32(dtem.Rows[0]["BU_ID"]);
                                    }
                                    _obj_Pms_Roles.ROLES_NAME = Convert.ToString(rtxt_Role.Text);
                                    _obj_Pms_Roles.ROLES_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
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


                                    GOALSETTING_GOALKRA_DETAILS _obj_Pms_goalkradetails = new GOALSETTING_GOALKRA_DETAILS();
                                    _obj_Pms_goalkradetails.MODE = 8;
                                    _obj_Pms_goalkradetails.GS_KRA_TARGET_ACHEIVED = Convert.ToString(rdrtgtargetachievekra.Value);
                                    if (dt11.Rows.Count != 0)
                                    {
                                        _obj_Pms_goalkradetails.GS_KRA_GS_ID = Convert.ToInt32(dt11.Rows[0]["GS_ID"]);
                                    }
                                    if (dt20.Rows.Count != 0)
                                    {
                                        _obj_Pms_goalkradetails.GS_KRA_KRA_ID = Convert.ToInt32(lblkradt_id.Text);// Convert.ToInt32(dt20.Rows[0]["ROLEKRA_ID"]);
                                    }
                                    _obj_Pms_goalkradetails.GS_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                    bool status8 = Pms_Bll.set_Gskra(_obj_Pms_goalkradetails);


                                    if (status == true)
                                    {
                                        _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                                        _obj_Pms_Appraisalcycle.MODE = 11;
                                        _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                        DataTable dtemzz2 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                        _obj_Pms_Appraisalcycle.MODE = 8;
                                        if (dtemzz2.Rows.Count != 0)
                                        {
                                            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz2.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                                        }
                                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                        DataTable dtappidzz2 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                        _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                                        _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                        _obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE = 1;
                                        if (dtappidzz2.Rows.Count != 0)
                                        {
                                            _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz2.Rows[0]["APPRCYCLE_ID"]);
                                        }
                                        _obj_Spms_Appraisal.Mode = 5;
                                        _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                        DataTable dtgoal4 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                                        if (dtgoal4.Rows.Count != 0)
                                        {
                                            _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtgoal4.Rows[0]["APPRAISAL_ID"]);
                                        }
                                        _obj_Spms_AppraisalKra.Mode = 3;
                                        _obj_Spms_AppraisalKra.APP_KRA_KRA_ID = Convert.ToInt32(lblkradt_id.Text);
                                        _obj_Spms_AppraisalKra.APP_KRA_EMP_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(txtKraEmployeeFeedback.Text));
                                        _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                        _obj_Spms_AppraisalKra.APP_KRA_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                                        _obj_Spms_AppraisalKra.APP_KRA_CREATEDDATE = DateTime.Now;
                                        _obj_Spms_AppraisalKra.APP_KRA_FINAL = 0;
                                        bool status1 = Pms_Bll.set_AppraisalKra(_obj_Spms_AppraisalKra);
                                        if (status1 == true)
                                        {
                                            Pms_Bll.ShowMessage(this, "Employee Comments Inserted Successfully");
                                            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                                            _obj_Pms_Appraisalcycle.MODE = 11;
                                            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                            DataTable dtemzz28 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                            _obj_Pms_Appraisalcycle.MODE = 8;

                                            if (dtemzz28.Rows.Count != 0)
                                            {
                                                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz28.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                                            }
                                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                            DataTable dtappidzz28 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                            _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                            if (dtappidzz28.Rows.Count != 0)
                                            {
                                                _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz28.Rows[0]["APPRCYCLE_ID"]);
                                            }

                                            _obj_Spms_Appraisal.Mode = 5;
                                            _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                            DataTable dtgoal44 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

                                            _obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                                            if (dtgoal44.Rows.Count != 0)
                                            {
                                                _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtgoal44.Rows[0]["APPRAISAL_ID"]);
                                            }
                                            _obj_Spms_AppraisalKra.APP_KRA_EMP_FIXED = Convert.ToString(1);
                                            _obj_Spms_AppraisalKra.Mode = 18;
                                            _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                            bool status10 = Pms_Bll.set_AppraisalKra(_obj_Spms_AppraisalKra);
                                            LoadKraGrid();
                                            LOADkraFINALIZE();
                                            rdtp_DATEofAppraisal.SelectedDate = DateTime.Now;
                                            Rg_Appraisal_Goal.Visible = false;

                                            Rm_Appraisal_PAGE.SelectedIndex = 0;
                                            Rm_Appraisal_Goal.Visible = true;

                                            Rg_Appraisal_Kra.Visible = true;
                                            Rp_Appraisal_VIEWDETAILS.Visible = true;
                                            Rm_Appraisal_Kra.SelectedIndex = 0;


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
                                DataTable dtemzz2 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                _obj_Pms_Appraisalcycle.MODE = 8;
                                if (dtemzz2.Rows.Count != 0)
                                {
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz2.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                                }
                                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dtappidzz2 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                                _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                _obj_Spms_Appraisal.Mode = 5;
                                if (dtappidzz2.Rows.Count != 0)
                                {
                                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz2.Rows[0]["APPRCYCLE_ID"]);
                                }
                                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dtgoal7 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                                if (dtgoal7.Rows.Count != 0)
                                {
                                    _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtgoal7.Rows[0]["APPRAISAL_ID"]);
                                }
                                _obj_Spms_AppraisalKra.Mode = 6;
                                _obj_Spms_AppraisalKra.APP_KRA_KRA_ID = Convert.ToInt32(lblkradt_id.Text);
                                _obj_Spms_AppraisalKra.APP_KRA_EMP_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(txtKraEmployeeFeedback.Text));
                                _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                _obj_Spms_AppraisalKra.APP_KRA_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                                _obj_Spms_AppraisalKra.APP_KRA_LASTMDFDATE = DateTime.Now;
                                bool status = Pms_Bll.set_AppraisalKra(_obj_Spms_AppraisalKra);
                                if (status == true)
                                {
                                    Pms_Bll.ShowMessage(this, "Employee KraFeedback Updated Successfully");
                                    LoadKraGrid();
                                    rdtp_DATEofAppraisal.SelectedDate = DateTime.Now;

                                    Rm_Appraisal_PAGE.SelectedIndex = 0;
                                    Rm_Appraisal_Goal.Visible = true;
                                    Rg_Appraisal_Goal.Visible = false;

                                    Rg_Appraisal_Kra.Visible = true;
                                    Rp_Appraisal_VIEWDETAILS.Visible = true;
                                    Rm_Appraisal_Kra.SelectedIndex = 0;
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
                        Pms_Bll.ShowMessage(this, "Please  Select Target Achieved");
                        return;
                    }


                }

                catch (Exception ex)
                {
                    SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisal", ex.StackTrace, DateTime.Now);
                    Response.Redirect("~/Frm_ErrorPage.aspx");
                }
            }
            #endregion



            #region   EmployeeKra  Submit,Update
            else if (e.CommandName == "btn_KraEmpUpdate")
            {
                try
                {
                    string q = txtKraEmployeeFeedback.Text;
                    int g = Convert.ToInt32(rdrtgtargetachievekra.Value);

                    if ((g > 0))
                    {
                        if ((q.Length >= 10))
                        {


                            PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                            _obj_Pms_Appraisalcycle.MODE = 11;
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtemzz2 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                            _obj_Pms_Appraisalcycle.MODE = 8;
                            if (dtemzz2.Rows.Count != 0)
                            {
                                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz2.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                            }
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtappidzz2 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                            _obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();


                            _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                            _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                            if (dtappidzz2.Rows.Count != 0)
                            {
                                _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz2.Rows[0]["APPRCYCLE_ID"]);
                            }
                            _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Spms_Appraisal.Mode = 5;
                            DataTable dtgoal4 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);


                            if (dtgoal4.Rows.Count != 0)
                            {
                                _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtgoal4.Rows[0]["APPRAISAL_ID"]);
                            }
                            _obj_Spms_AppraisalKra.Mode = 19;
                            _obj_Spms_AppraisalKra.APP_KRA_KRA_ID = Convert.ToInt32(lblkradt_id.Text);
                            _obj_Spms_AppraisalKra.APP_KRA_EMP_COMMENTS = Convert.ToString(txtKraEmployeeFeedback.Text);

                            _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);


                            bool status1 = Pms_Bll.set_AppraisalKra(_obj_Spms_AppraisalKra);




                            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                            _obj_Pms_Appraisalcycle.MODE = 11;
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtem1 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                            _obj_Pms_Appraisalcycle.MODE = 8;
                            if (dtem1.Rows.Count != 0)
                            {
                                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem1.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                            }
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                            _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
                            _obj_Pms_EmpGoalSetting.Mode = 10;

                            _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                            if (dtappid.Rows.Count != 0)
                            {
                                _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
                            }
                            _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dt11 = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
                            PMS_EMPSETUP _obj_Pms_EmpSetup = new PMS_EMPSETUP();
                            _obj_Pms_EmpSetup.Mode = 17;
                            _obj_Pms_EmpSetup.EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                            _obj_Pms_EmpSetup.EMP_SETUP_LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtem = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);


                            SPMS_ROLES _obj_Pms_Roles = new SPMS_ROLES();
                            _obj_Pms_Roles.Mode = 6;
                            if (dtem.Rows.Count != 0)
                            {
                                _obj_Pms_Roles.BUID = Convert.ToInt32(dtem.Rows[0]["BU_ID"]);
                            }
                            _obj_Pms_Roles.ROLES_NAME = Convert.ToString(rtxt_Role.Text);
                            _obj_Pms_Roles.ROLES_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
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



                            GOALSETTING_GOALKRA_DETAILS _obj_Pms_goalkradetails = new GOALSETTING_GOALKRA_DETAILS();
                            _obj_Pms_goalkradetails.MODE = 8;
                            _obj_Pms_goalkradetails.GS_KRA_TARGET_ACHEIVED = Convert.ToString(rdrtgtargetachievekra.Value);
                            if (dt11.Rows.Count != 0)
                            {
                                _obj_Pms_goalkradetails.GS_KRA_GS_ID = Convert.ToInt32(dt11.Rows[0]["GS_ID"]);
                            }
                            if (dt20.Rows.Count != 0)
                            {
                                _obj_Pms_goalkradetails.GS_KRA_KRA_ID = Convert.ToInt32(lblkradt_id.Text);// Convert.ToInt32(dt20.Rows[0]["ROLEKRA_ID"]);
                            }
                            _obj_Pms_goalkradetails.GS_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            bool status8 = Pms_Bll.set_Gskra(_obj_Pms_goalkradetails);

                            if (status1 == true)
                            {
                                Pms_Bll.ShowMessage(this, "Employee Feedback Updated Successfully");


                                LoadKraGrid();
                                LOADkraFINALIZE();

                                rdtp_DATEofAppraisal.SelectedDate = DateTime.Now;

                                //LoadKraGrid();
                                //LOADkraFINALIZE();

                                Rg_Appraisal_Goal.Visible = false;

                                Rm_Appraisal_PAGE.SelectedIndex = 0;
                                Rm_Appraisal_Goal.Visible = true;

                                Rg_Appraisal_Kra.Visible = true;
                                Rp_Appraisal_VIEWDETAILS.Visible = true;
                                Rm_Appraisal_Kra.SelectedIndex = 0;

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
                        Pms_Bll.ShowMessage(this, "Please Select Target Acheived");
                        return;
                    }

                }

                catch (Exception ex)
                {
                    SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisal", ex.StackTrace, DateTime.Now);
                    Response.Redirect("~/Frm_ErrorPage.aspx");
                }
            }

            #endregion
        }
        catch (Exception ex)
        {
            Pms_Bll.ShowMessage(this, ex.Message.ToString());
            return;
        }

    }
    #endregion

    #region Approver Submit,cancel Method


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


        //    }
        //    else
        //    {

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



        //    }
        //    else
        //    {

        //    }
        //    rcmb_BusinessUnitType.Enabled = false;
        //    rcmb_EmployeeType.Enabled = false;

        //    btn_Cancel.Visible = false;

        //    Rg_Appraisal_Kra.Enabled = false;
        //    Rm_Appraisal_Goal.Enabled = false;

        //    Rm_AppraisalDiscussion.Visible = true;
        //    rdtp_DateofDiscussion.SelectedDate = null;
        //    rtxt_MgrCommentsAppDiscussion.Text = string.Empty;
        //    rtxt_EmployeeCommentsAppDiscussion.Text = string.Empty;
        //    Rm_AppraisalDiscussion.SelectedIndex = 0;
        //    return;
        //}

    }
    protected void btn_ApproverCancel_Click1(object sender, EventArgs e)
    {

        //rcmb_EmployeeType.ClearSelection();
        //DataTable dt = new DataTable();
        //rcmb_EmployeeType.DataSource = dt;
        //rcmb_EmployeeType.DataBind();
        //Rm_Appraisal_PAGE.SelectedIndex = 0;
        //Rm_Appraisal_Kra.Visible = false;
        //Rm_Appraisal_Goal.Visible = false;
        //Rm_Kra_Details.Visible = false;
        //Rm_AppraisalDiscussion.Visible = false;

    }


    #endregion

    #region goal,kra finalise click methods

    protected void btn_finalise_Click1(object sender, EventArgs e)
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


            _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
            if (dtappid.Rows.Count != 0)
            {
                _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
            }
            _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);

            DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
            if (dt.Rows.Count != 0)
            {
                int GSID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
                _obj_GSdetails = new PMS_GoalSettings_Details();
                _obj_GSdetails.GSDTL_GS_ID = GSID;
            }
            _obj_GSdetails.GS_DETAILS_MODE = 5;
            _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_details = new DataTable();
            dt_details = Pms_Bll.get_GSdetails(_obj_GSdetails);

            _obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();
            if (dt_details.Rows.Count != 0)
            {
                _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(dt_details.Rows[0]["GSDTL_ID"]);
            }
            _obj_Spms_AppraisalGoal.APP_GOALS_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
            if (dtappid.Rows.Count != 0)
            {
                _obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFBY = Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
            }
            _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Spms_AppraisalGoal.Mode = 5;
            DataTable dtgoal = Pms_Bll.get_AppraisalGoal(_obj_Spms_AppraisalGoal);
            if (dtgoal.Rows.Count != 0)
            {
                _obj_Spms_Appraisal = new SPMS_APPRAISAL();
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

                _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                _obj_Spms_Appraisal.Mode = 2;
                if (dtappidzz.Rows.Count != 0)
                {
                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz.Rows[0]["APPRCYCLE_ID"]);
                }

                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

                DataTable dtemp = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                if (Convert.ToInt32(dtemp.Rows[0]["APPRAISAL_APPROVALSTAGE"]) == 1)
                {
                    _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                    _obj_Spms_Appraisal.APPRAISAL_DATE = rdtp_DATEofAppraisal.SelectedDate.Value;
                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE = 11;
                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(lbl_Apprais_id.Text);
                    _obj_Spms_Appraisal.APPRAISAL_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_Spms_Appraisal.APPRAISAL_STATUS = 1;
                    _obj_Spms_Appraisal.APPRAISAL_CREATEDDATE = DateTime.Now;
                    if (dtemp.Rows.Count != 0)
                    {
                        _obj_Spms_Appraisal.APPRAISAL_ID = Convert.ToInt32(dtemp.Rows[0]["APPRAISAL_ID"]);
                    }
                    _obj_Spms_Appraisal.Mode = 6;
                    bool status = Pms_Bll.set_Appraisal(_obj_Spms_Appraisal);
                    if (status == true)
                    {
                        _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                        _obj_Pms_Appraisalcycle.MODE = 11;
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtemzz2 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                        _obj_Pms_Appraisalcycle.MODE = 8;
                        if (dtemzz2.Rows.Count != 0)
                        {
                            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz2.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                        }
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtappidzz2 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                        _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                        _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                        if (dtappidzz2.Rows.Count != 0)
                        {
                            _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz2.Rows[0]["APPRCYCLE_ID"]);
                        }
                        _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Spms_Appraisal.Mode = 5;

                        DataTable dtgoal1 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                        if (dtgoal1.Rows.Count != 0)
                        {
                            _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtgoal1.Rows[0]["APPRAISAL_ID"]);
                        }
                        _obj_Spms_AppraisalGoal.Mode = 12;
                        _obj_Spms_AppraisalGoal.APP_GOALS_FINAL = 1;
                        _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        bool status1 = Pms_Bll.set_AppraisalGoal(_obj_Spms_AppraisalGoal);





                        _obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();
                        if (dtgoal1.Rows.Count != 0)
                        {

                            _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtgoal1.Rows[0]["APPRAISAL_ID"]);
                        }
                        _obj_Spms_AppraisalGoal.APP_EMP_GOAL_FIXED = Convert.ToString(2);
                        _obj_Spms_AppraisalGoal.Mode = 17;
                        _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        bool status10 = Pms_Bll.set_AppraisalGoal(_obj_Spms_AppraisalGoal);

                        _obj_pms_EmployeeSetup = new PMS_EMPSETUP();
                        _obj_pms_EmployeeSetup.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);

                        SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
                        _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                        _obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"].ToString());
                        DataTable dt_buu = new DataTable();
                        dt_buu = BLL.get_Business_Units(_obj_smhr_logininfo);
                        if (dt_buu.Rows.Count != 0)
                        {
                            _obj_pms_EmployeeSetup.BU_ID = Convert.ToInt32(dt_buu.Rows[0]["BUSINESSUNIT_ID"]);
                        }

                        _obj_pms_EmployeeSetup.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtbuid1 = Pms_Bll.get_LoginInfo(_obj_pms_EmployeeSetup);
                        _obj_Pms_Send_Notification = new PMS_NOTIFICATION();
                        _obj_Pms_Send_Notification.EMPID = Convert.ToInt32(Session["EMP_ID"]);
                        if (dtbuid1.Rows.Count != 0)
                        {
                            _obj_Pms_Send_Notification.RMID = Convert.ToInt32(dtbuid1.Rows[0]["REPORTINGMGR_ID"]);
                        }
                        _obj_Pms_Send_Notification.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                        bool status3 = Pms_Bll.Send_Notification(_obj_Pms_Send_Notification);//AAAA
                        rdtp_DATEofAppraisal.SelectedDate = DateTime.Now;

                        Rm_Appraisal_PAGE.SelectedIndex = 0;
                        Rm_Appraisal_Kra.Visible = false;
                        Rm_Appraisal_Goal.Visible = false;
                        Rm_Kra_Details.Visible = false;
                        rcmb_feedback.SelectedIndex = 0;
                        rdtp_DATEofAppraisal.SelectedDate = null;
                        Rm_AppraisalDiscussion.Visible = false;
                        lbl_final.Visible = false;
                        Pms_Bll.ShowMessage(this, "Employee Comments Finalized Successfully");
                        Pms_Bll.ShowMessage(this, "Notification Send");
                        return;



                    }


                }
                else
                {

                    _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                    _obj_Spms_Appraisal.APPRAISAL_DATE = DateTime.Now;
                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE = 12;
                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(lbl_Apprais_id.Text);
                    _obj_Spms_Appraisal.APPRAISAL_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_Spms_Appraisal.APPRAISAL_STATUS = 1;
                    _obj_Spms_Appraisal.APPRAISAL_CREATEDDATE = DateTime.Now;
                    if (dtemp.Rows.Count != 0)
                    {
                        _obj_Spms_Appraisal.APPRAISAL_ID = Convert.ToInt32(dtemp.Rows[0]["APPRAISAL_ID"]);
                    }
                    _obj_Spms_Appraisal.Mode = 6;
                    bool status = Pms_Bll.set_Appraisal(_obj_Spms_Appraisal);
                    if (status == true)
                    {
                        _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                        _obj_Pms_Appraisalcycle.MODE = 11;
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtemzz2 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                        _obj_Pms_Appraisalcycle.MODE = 8;
                        if (dtemzz2.Rows.Count != 0)
                        {

                            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz2.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                        }
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtappidzz2 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                        _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                        _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                        if (dtappidzz2.Rows.Count != 0)
                        {
                            _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz2.Rows[0]["APPRCYCLE_ID"]);
                        }

                        _obj_Spms_Appraisal.Mode = 5;
                        _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtgoal1 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                        if (dtgoal1.Rows.Count != 0)
                        {
                            _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtgoal1.Rows[0]["APPRAISAL_ID"]);
                        }
                        _obj_Spms_AppraisalGoal.Mode = 12;
                        _obj_Spms_AppraisalGoal.APP_GOALS_FINAL = 1;
                        _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        bool status1 = Pms_Bll.set_AppraisalGoal(_obj_Spms_AppraisalGoal);
                        if (status1 == true)
                        {


                            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                            _obj_Pms_Appraisalcycle.MODE = 11;
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtemzz30 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                            _obj_Pms_Appraisalcycle.MODE = 8;
                            if (dtemzz30.Rows.Count != 0)
                            {
                                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz30.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                            }
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtappidzz30 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                            _obj_Spms_Appraisal = new SPMS_APPRAISAL();



                            _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                            if (dtappidzz30.Rows.Count != 0)
                            {
                                _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz30.Rows[0]["APPRCYCLE_ID"]);
                            }

                            _obj_Spms_Appraisal.Mode = 5;
                            _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtgoal4 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

                            _obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();
                            if (dtgoal4.Rows.Count != 0)
                            {
                                _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtgoal4.Rows[0]["APPRAISAL_ID"]);
                            }
                            _obj_Spms_AppraisalGoal.APP_EMP_GOAL_FIXED = Convert.ToString(2);
                            _obj_Spms_AppraisalGoal.Mode = 17;
                            _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            bool status10 = Pms_Bll.set_AppraisalGoal(_obj_Spms_AppraisalGoal);

                            _obj_pms_EmployeeSetup = new PMS_EMPSETUP();
                            _obj_pms_EmployeeSetup.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);

                            SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
                            _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                            _obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"].ToString());
                            DataTable dt_buu = new DataTable();
                            dt_buu = BLL.get_Business_Units(_obj_smhr_logininfo);
                            if (dt_buu.Rows.Count != 0)
                            {
                                _obj_pms_EmployeeSetup.BU_ID = Convert.ToInt32(dt_buu.Rows[0]["BUSINESSUNIT_ID"]);
                            }
                            _obj_pms_EmployeeSetup.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtbuid1 = Pms_Bll.get_LoginInfo(_obj_pms_EmployeeSetup);
                            _obj_Pms_Send_Notification = new PMS_NOTIFICATION();
                            _obj_Pms_Send_Notification.EMPID = Convert.ToInt32(Session["EMP_ID"]);
                            if (dtbuid1.Rows.Count != 0)
                            {
                                _obj_Pms_Send_Notification.RMID = Convert.ToInt32(dtbuid1.Rows[0]["REPORTINGMGR_ID"]);
                            }
                            _obj_Pms_Send_Notification.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                            bool status3 = Pms_Bll.Send_Notification(_obj_Pms_Send_Notification);//AAAA
                            rdtp_DATEofAppraisal.SelectedDate = DateTime.Now;

                            Rm_Appraisal_PAGE.SelectedIndex = 0;
                            Rm_Appraisal_Kra.Visible = false;
                            Rm_Appraisal_Goal.Visible = false;
                            Rm_Kra_Details.Visible = false;
                            rcmb_feedback.SelectedIndex = 0;
                            rdtp_DATEofAppraisal.SelectedDate = null;
                            Rm_AppraisalDiscussion.Visible = false;
                            lbl_final.Visible = false;
                            Pms_Bll.ShowMessage(this, "Employee Comments Finalized Successfully");
                            Pms_Bll.ShowMessage(this, "Notification Send");
                            return;
                        }


                    }
                }

            }


        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_KraFINALISE_Click(object sender, EventArgs e)
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


            _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
            if (dtappid.Rows.Count != 0)
            {
                _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
            }
            _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
            if (dtappid.Rows.Count != 0)
            {
                int GSID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
                _obj_GSdetails = new PMS_GoalSettings_Details();
                _obj_GSdetails.GSDTL_GS_ID = GSID;
            }
            _obj_GSdetails.GS_DETAILS_MODE = 5;
            _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_details = new DataTable();
            dt_details = Pms_Bll.get_GSdetails(_obj_GSdetails);
            if (dt_details.Rows.Count != 0)
            {
                _obj_Spms_GoalStgKraDtls = new SPMS_GOALSETTINGKRADETAILS();
                _obj_Spms_GoalStgKraDtls.Mode = 7;
                _obj_Spms_GoalStgKraDtls.GS_KRA_GSDTL_ID = Convert.ToInt32(dt_details.Rows[0]["GSDTL_GS_ID"]);
                if (dtappid.Rows.Count != 0)
                {
                    _obj_Spms_GoalStgKraDtls.LASTMDFBY = Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
                }
                _obj_Spms_GoalStgKraDtls.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt2 = Pms_Bll.get_GoalStgKraDtls(_obj_Spms_GoalStgKraDtls);

                _obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                if (dt2.Rows.Count != 0)
                {
                    _obj_Spms_AppraisalKra.APP_KRA_KRA_ID = Convert.ToInt32(dt2.Rows[0]["KRA_ID"]);
                }
                _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Spms_AppraisalKra.APP_KRA_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                _obj_Spms_AppraisalKra.Mode = 5;
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

                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                    if (dtappidzz.Rows.Count != 0)
                    {
                        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz.Rows[0]["APPRCYCLE_ID"]);
                    }
                    _obj_Spms_Appraisal.Mode = 2;
                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtemp = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                    if (Convert.ToInt32(dtemp.Rows[0]["APPRAISAL_APPROVALSTAGE"]) == 1)
                    {

                        _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                        _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                        _obj_Spms_Appraisal.APPRAISAL_DATE = rdtp_DATEofAppraisal.SelectedDate.Value;
                        _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE = 11;
                        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(lbl_Apprais_id.Text);
                        _obj_Spms_Appraisal.APPRAISAL_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_Spms_Appraisal.APPRAISAL_STATUS = 1;
                        _obj_Spms_Appraisal.APPRAISAL_CREATEDDATE = DateTime.Now;
                        _obj_Spms_Appraisal.APPRAISAL_ID = Convert.ToInt32(dtemp.Rows[0]["APPRAISAL_ID"]);
                        _obj_Spms_Appraisal.Mode = 6;
                        bool status = Pms_Bll.set_Appraisal(_obj_Spms_Appraisal);
                        if (status == true)
                        {
                            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                            _obj_Pms_Appraisalcycle.MODE = 11;
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtemzz1 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                            _obj_Pms_Appraisalcycle.MODE = 8;
                            if (dtemzz1.Rows.Count != 0)
                            {
                                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz1.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                            }
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtappidzz1 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                            _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                            _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);

                            //_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(lbl_Apprais_id.Text);
                            if (dtappidzz1.Rows.Count != 0)
                            {
                                _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz1.Rows[0]["APPRCYCLE_ID"]);
                            }


                            _obj_Spms_Appraisal.Mode = 5;
                            _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtgoal1 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                            if (dtgoal1.Rows.Count != 0)
                            {
                                _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtgoal1.Rows[0]["APPRAISAL_ID"]);
                            }
                            _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Spms_AppraisalKra.Mode = 12;
                            _obj_Spms_AppraisalKra.APP_KRA_FINAL = 1;
                            bool status1 = Pms_Bll.set_AppraisalKra(_obj_Spms_AppraisalKra);
                            if (status1 == true)
                            {



                                _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                                _obj_Pms_Appraisalcycle.MODE = 11;
                                _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dtemzz2 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                _obj_Pms_Appraisalcycle.MODE = 8;
                                if (dtemzz2.Rows.Count != 0)
                                {
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz2.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                                }
                                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dtappidzz2 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                                _obj_Spms_Appraisal = new SPMS_APPRAISAL();



                                _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                if (dtappidzz2.Rows.Count != 0)
                                {
                                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz2.Rows[0]["APPRCYCLE_ID"]);
                                }

                                _obj_Spms_Appraisal.Mode = 5;
                                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dtgoal4 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

                                _obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                                if (dtgoal4.Rows.Count != 0)
                                {
                                    _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtgoal4.Rows[0]["APPRAISAL_ID"]);
                                }
                                _obj_Spms_AppraisalKra.APP_KRA_EMP_FIXED = Convert.ToString(2);
                                _obj_Spms_AppraisalKra.Mode = 18;
                                _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                bool status10 = Pms_Bll.set_AppraisalKra(_obj_Spms_AppraisalKra);
                                rdtp_DATEofAppraisal.SelectedDate = DateTime.Now;

                                Rm_Appraisal_PAGE.SelectedIndex = 0;
                                Rm_Appraisal_Kra.Visible = false;
                                Rm_Appraisal_Goal.Visible = false;
                                Rm_Kra_Details.Visible = false;
                                rcmb_feedback.SelectedIndex = 0;
                                rdtp_DATEofAppraisal.SelectedDate = null;
                                Rm_AppraisalDiscussion.Visible = false;
                                lbl_final.Visible = false;
                                Pms_Bll.ShowMessage(this, "Employee Comments Finalized Successfully");
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
                        _obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE = 12;
                        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(lbl_Apprais_id.Text);
                        _obj_Spms_Appraisal.APPRAISAL_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_Spms_Appraisal.APPRAISAL_STATUS = 1;
                        _obj_Spms_Appraisal.APPRAISAL_CREATEDDATE = DateTime.Now;
                        _obj_Spms_Appraisal.APPRAISAL_ID = Convert.ToInt32(dtemp.Rows[0]["APPRAISAL_ID"]);
                        _obj_Spms_Appraisal.Mode = 6;
                        bool status = Pms_Bll.set_Appraisal(_obj_Spms_Appraisal);
                        if (status == true)
                        {
                            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                            _obj_Pms_Appraisalcycle.MODE = 11;
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtemzz2 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                            _obj_Pms_Appraisalcycle.MODE = 8;
                            if (dtemzz2.Rows.Count != 0)
                            {
                                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz2.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                            }
                            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtappidzz2 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                            _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                            _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                            if (dtappidzz2.Rows.Count != 0)
                            {

                                _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz2.Rows[0]["APPRCYCLE_ID"]);
                            }

                            _obj_Spms_Appraisal.Mode = 5;
                            _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtgoal1 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                            if (dtgoal1.Rows.Count != 0)
                            {
                                _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtgoal1.Rows[0]["APPRAISAL_ID"]);
                            }
                            _obj_Spms_AppraisalKra.Mode = 12;
                            _obj_Spms_AppraisalKra.APP_KRA_FINAL = 1;
                            _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            bool status1 = Pms_Bll.set_AppraisalKra(_obj_Spms_AppraisalKra);
                            if (status1 == true)
                            {




                                _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                                _obj_Pms_Appraisalcycle.MODE = 11;
                                _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dtemzz31 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                                _obj_Pms_Appraisalcycle.MODE = 8;
                                if (dtemzz31.Rows.Count != 0)
                                {
                                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz31.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                                }
                                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dtappidzz31 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                                _obj_Spms_Appraisal = new SPMS_APPRAISAL();



                                _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                                if (dtappidzz31.Rows.Count != 0)
                                {
                                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz31.Rows[0]["APPRCYCLE_ID"]);
                                }

                                _obj_Spms_Appraisal.Mode = 5;
                                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dtgoal4 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

                                _obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                                if (dtgoal4.Rows.Count != 0)
                                {
                                    _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtgoal4.Rows[0]["APPRAISAL_ID"]);
                                }
                                _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                _obj_Spms_AppraisalKra.APP_KRA_EMP_FIXED = Convert.ToString(2);
                                _obj_Spms_AppraisalKra.Mode = 18;
                                bool status10 = Pms_Bll.set_AppraisalKra(_obj_Spms_AppraisalKra);

                                rdtp_DATEofAppraisal.SelectedDate = DateTime.Now;
                                Rm_Appraisal_PAGE.SelectedIndex = 0;
                                Rm_Appraisal_Kra.Visible = false;
                                Rm_Appraisal_Goal.Visible = false;
                                Rm_Kra_Details.Visible = false;
                                rcmb_feedback.SelectedIndex = 0;
                                rdtp_DATEofAppraisal.SelectedDate = null;
                                Rm_AppraisalDiscussion.Visible = false;

                                lbl_final.Visible = false;
                                Pms_Bll.ShowMessage(this, "Employee Comments Finalized Successfully");
                                return;
                            }
                        }
                    }
                }
            }

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_GoalEmpSubmit_Click(object sender, EventArgs e)
    {

    }

    #endregion



}

