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



public partial class PMS_frm_PmsApproverAppraisal : System.Web.UI.Page
{
    SPMS_EMPGOALSETTING _obj_Pms_EmpGoalSetting;
    SPMS_APPRAISAL _obj_Spms_Appraisal;
    SPMS_APPRAISALGOAL _obj_Spms_AppraisalGoal;
    SPMS_GOALSETTINGKRADETAILS _obj_Spms_GoalStgKraDtls;
    SPMS_APPRAISALKRA _obj_Spms_AppraisalKra;
    SPMS_APRAISALAPPROVER _obj_Pms_AppApprover;

    PMS_GoalSettings_Details _obj_Pms_GoalSettingdetails;
    PMS_LOGININFO _obj_Pms_LoginInfo;
    PMS_GETEMPLOYEE _obj_PMS_getemployee;
    PMS_EMPSETUP _obj_pms_EmployeeSetup;



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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Approver Appraisal");
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
                    //  Rg_Appraisal_Goal.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
                LoadBusinessUnit();
                //PMS_EMPSETUP _obj_Pms_EmpSetup;
                //_obj_Pms_EmpSetup = new PMS_EMPSETUP();


                //_obj_pms_EmployeeSetup = new PMS_EMPSETUP();
                //_obj_pms_EmployeeSetup.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);

                //SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
                //_obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //_obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                //DataTable dt_buu = new DataTable();
                //dt_buu = BLL.get_Business_Units(_obj_smhr_logininfo);

                //PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                //_obj_Pms_Appraisalcycle.MODE = 8;
                //_obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                //if (dt_buu.Rows.Count != 0)
                //{
                //    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dt_buu.Rows[0]["BUSINESSUNIT_ID"]);
                //}
                //DataTable dtappidzzR = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                //if (dtappidzzR.Rows.Count != 0)
                //{
                //    _obj_Pms_EmpSetup.Mode = 11;
                //    _obj_Pms_EmpSetup.BU_ID = Convert.ToInt32(dt_buu.Rows[0]["BUSINESSUNIT_ID"]);
                //    _obj_Pms_EmpSetup.EMP_SETUP_LASTMDFBY = Convert.ToInt32(dtappidzzR.Rows[0]["APPRCYCLE_ID"]);
                //    _obj_Pms_EmpSetup.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                //    DataTable dt = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);

                //    if (dt.Rows.Count != 0)
                //    {
                //        rcmb_EmployeeType.DataSource = dt;
                //        rcmb_EmployeeType.DataTextField = "EMPLOYEE_NAME";
                //        rcmb_EmployeeType.DataValueField = "EMP_ID";
                //        rcmb_EmployeeType.DataBind();
                //        //if ((Convert.ToString(Session["EMP_TYPE"])) != "14")//FOR HR LOGIN
                //        //{
                //        //    rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                //        //}
                //        rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                //        //rcmb_BusinessUnitType.Visible = false;
                //        //lbl_BusinessUnitName.Visible = false;
                //        if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                //        {

                //            rcmb_EmployeeType.Enabled = false;


                //        }

                //        else
                //        {
                //            rcmb_EmployeeType.Enabled = true;
                //        }


                //    }
                //    else
                //    {
                //        DataTable dt5 = new DataTable();

                //        rcmb_EmployeeType.DataSource = dt5;
                //        rcmb_EmployeeType.DataBind();
                //        //lbl_BusinessUnitName.Visible = false;
                //        //rcmb_BusinessUnitType.Visible = false;
                //        //Pms_Bll.ShowMessage(this, "Manger Appraisal Has Not Done");

                //    }
                //}
                //else
                //{
                //    DataTable dt5 = new DataTable();

                //    rcmb_EmployeeType.DataSource = dt5;
                //    rcmb_EmployeeType.DataBind();
                //    //lbl_BusinessUnitName.Visible = false;
                //    //rcmb_BusinessUnitType.Visible = false;

                //}

                ////rcmb_BusinessUnitType.Visible = false;
                ////lbl_BusinessUnitName.Visible = false;
                //rtxt_RpMgr.Enabled = false;
                //rtxt_GpMgr.Enabled = false;


                //rdtp_DateofDiscussion.SelectedDate = DateTime.Now;
                //rdtp_DateofDiscussion.Enabled = false;
                //Rm_Appraisal_PAGE.SelectedIndex = 0;
                //Rm_Appraisal_Kra.Visible = false;
                //Rm_Appraisal_Goal.Visible = false;
                //Rm_Kra_Details.Visible = false;
                //Rm_AppraisalDiscussion.Visible = false;
                //rtxt_RpMgr.Enabled = true;
                //rtxt_GpMgr.Enabled = true;
                //if ((Convert.ToString(Session["EMP_TYPE"])) == "14")//FOR HR LOGIN
                //{
                //SMHRMaster myMasterObj = (SMHRMaster)this.Master;
                //myMasterObj.FindControl("HyperLink1").Visible = false;


                //myMasterObj.FindControl("Lnk_LogOut").Visible = false;
                //myMasterObj.FindControl("lnk_Home").Visible = false;
                //myMasterObj.FindControl("MainMenu").Visible = false;
                //myMasterObj.FindControl("Label1").Visible = false;
                //myMasterObj.FindControl("Label2").Visible = false;


                //}

            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsApproverAppraisal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }




    protected void LoadBusinessUnit()
    {
        try
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

            rtxt_RpMgr.Enabled = false;
            rtxt_GpMgr.Enabled = false;


            rdtp_DateofDiscussion.SelectedDate = DateTime.Now;
            rdtp_DateofDiscussion.Enabled = false;
            Rm_Appraisal_PAGE.SelectedIndex = 0;
            Rm_Appraisal_Kra.Visible = false;
            Rm_Appraisal_Goal.Visible = false;
            Rm_Kra_Details.Visible = false;
            Rm_AppraisalDiscussion.Visible = false;
            rtxt_RpMgr.Enabled = true;
            rtxt_GpMgr.Enabled = true;
            if ((Convert.ToString(Session["EMP_TYPE"])) == "14")//FOR HR LOGIN
            {
                SMHRMaster myMasterObj = (SMHRMaster)this.Master;
                myMasterObj.FindControl("HyperLink1").Visible = false;


                myMasterObj.FindControl("Lnk_LogOut").Visible = false;
                myMasterObj.FindControl("lnk_Home").Visible = false;
                myMasterObj.FindControl("MainMenu").Visible = false;
                myMasterObj.FindControl("Label1").Visible = false;
                myMasterObj.FindControl("Label2").Visible = false;


            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsApproverAppraisal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_BusinessUnitType_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_BusinessUnitType.SelectedIndex > 0)
            {
                PMS_EMPSETUP _obj_Pms_EmpSetup;
                _obj_Pms_EmpSetup = new PMS_EMPSETUP();


                _obj_pms_EmployeeSetup = new PMS_EMPSETUP();
                _obj_pms_EmployeeSetup.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);

                //SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
                //_obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //_obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                //DataTable dt_buu = new DataTable();
                //dt_buu = BLL.get_Business_Units(_obj_smhr_logininfo);

                PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                _obj_Pms_Appraisalcycle.MODE = 8;
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);

                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);

                DataTable dtappidzzR = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                if (dtappidzzR.Rows.Count != 0)
                {
                    _obj_Pms_EmpSetup.Mode = 11;
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
                        //if ((Convert.ToString(Session["EMP_TYPE"])) != "14")//FOR HR LOGIN
                        //{
                        //    rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                        //}
                        rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                        //rcmb_BusinessUnitType.Visible = false;
                        //lbl_BusinessUnitName.Visible = false;
                        if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                        {

                            rcmb_EmployeeType.Enabled = false;


                        }

                        else
                        {
                            rcmb_EmployeeType.Enabled = true;
                        }


                    }
                    else
                    {
                        DataTable dt5 = new DataTable();

                        rcmb_EmployeeType.DataSource = dt5;
                        rcmb_EmployeeType.DataBind();
                        //lbl_BusinessUnitName.Visible = false;
                        //rcmb_BusinessUnitType.Visible = false;
                        //Pms_Bll.ShowMessage(this, "Manger Appraisal Has Not Done");

                    }
                }
                else
                {
                    DataTable dt5 = new DataTable();

                    rcmb_EmployeeType.DataSource = dt5;
                    rcmb_EmployeeType.DataBind();
                    //lbl_BusinessUnitName.Visible = false;
                    //rcmb_BusinessUnitType.Visible = false;

                }

                //rcmb_BusinessUnitType.Visible = false;
                //lbl_BusinessUnitName.Visible = false;
                rtxt_RpMgr.Enabled = false;
                rtxt_GpMgr.Enabled = false;


                rdtp_DateofDiscussion.SelectedDate = DateTime.Now;
                rdtp_DateofDiscussion.Enabled = false;
                Rm_Appraisal_PAGE.SelectedIndex = 0;
                Rm_Appraisal_Kra.Visible = false;
                Rm_Appraisal_Goal.Visible = false;
                Rm_Kra_Details.Visible = false;
                Rm_AppraisalDiscussion.Visible = false;
                rtxt_RpMgr.Enabled = true;
                rtxt_GpMgr.Enabled = true;
                if ((Convert.ToString(Session["EMP_TYPE"])) == "14")//FOR HR LOGIN
                {
                    SMHRMaster myMasterObj = (SMHRMaster)this.Master;
                    myMasterObj.FindControl("HyperLink1").Visible = false;


                    myMasterObj.FindControl("Lnk_LogOut").Visible = false;
                    myMasterObj.FindControl("lnk_Home").Visible = false;
                    myMasterObj.FindControl("MainMenu").Visible = false;
                    myMasterObj.FindControl("Label1").Visible = false;
                    myMasterObj.FindControl("Label2").Visible = false;


                }
            }
            else
            {
                //Pms_Bll.ShowMessage(this, "Please Select Employee");
                //DataTable dt=new DataTable();
                //rcmb_EmployeeType.DataSource=dt;
                //rcmb_EmployeeType.DataBind();
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
                Rm_Appraisal_PAGE.SelectedIndex = 0;
                Rm_Appraisal_Kra.Visible = false;
                Rm_Appraisal_Goal.Visible = false;
                Rm_Kra_Details.Visible = false;
                Rm_AppraisalDiscussion.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsApproverAppraisal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #region LoadGoal Grid
    /// <summary>
    /// here i am binding goal grid based on employee selection 
    /// </summary>
    /// <param name="dt"></param>
    protected void LoadGrid()
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
            _obj_Pms_EmpGoalSetting.Mode = 10;

            _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
            if (dtappid.Rows.Count != 0)
            {
                _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
            }
            _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
            int GSID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
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

                _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(LBL_Appraise_Id.Text);
                DataTable dtg = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                _obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();
                if (dtg.Rows.Count != 0)
                {
                    _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtg.Rows[0]["APPRAISAL_ID"]);
                }
                _obj_Spms_AppraisalGoal.Mode = 7;
                _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt8 = Pms_Bll.get_AppraisalGoal(_obj_Spms_AppraisalGoal);
                if (dt8.Rows.Count != 0)
                {
                    rnt_GoalAvgrtg.Value = Convert.ToDouble(dt8.Rows[0]["APP_GOALS_MGR_RATING"]);
                }
                rnt_GoalAvgrtg.Enabled = false;
                Rm_Appraisal_PAGE.SelectedIndex = 0;
                Rm_Appraisal_Goal.Visible = true;
                Rg_Appraisal_Goal.Visible = true;
                Rp_Appraisal_VIEWDETAILS.Visible = true;
                Rm_Appraisal_Kra.SelectedIndex = 0;
                Rm_Kra_Details.Visible = true;
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
                    _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Pms_EmpGoalSetting.Mode = 16;
                    _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                    if (dtappidzLaP.Rows.Count != 0)
                    {
                        _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(dtappidzLaP.Rows[0]["APPRCYCLE_ID"]);
                    }
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
                LoadKraGrid();
                Rg_Appraisal_Kra.Visible = true;


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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsApproverAppraisal", ex.StackTrace, DateTime.Now);
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

            int GSID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
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
                    // _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                    //_obj_Pms_Appraisalcycle.MODE = 11;
                    //_obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                    //DataTable dtemzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                    //_obj_Pms_Appraisalcycle.MODE = 8;
                    //_obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                    //DataTable dtappidzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                    //_obj_Spms_Appraisal = new SPMS_APPRAISAL();

                    //_obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);

                    //_obj_Spms_Appraisal.Mode = 41;

                    //_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz.Rows[0]["APPRCYCLE_ID"]);

                    //DataTable dtkra = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                    ////_obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                    ////_obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtkra.Rows[0]["APPRAISAL_ID"]);
                    ////_obj_Spms_AppraisalKra.Mode = 7;
                    ////DataTable dt5 = Pms_Bll.get_AppraisalKra(_obj_Spms_AppraisalKra);
                    //if (dtkra.Rows.Count != 0)
                    //{
                    //    rnt_KraAvgrtg.Value = Convert.ToDouble(dtkra.Rows[0]["APPRAISAL_KRA_AVGRTG"]);
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

                    rnt_KraAvgrtg.Enabled = false;
                    Rm_Appraisal_PAGE.SelectedIndex = 0;
                    Rm_Appraisal_Goal.Visible = true;
                    Rg_Appraisal_Kra.Visible = true;
                    Rg_Appraisal_Goal.Visible = true;//n
                    Rm_Appraisal_Kra.Visible = true;
                    Rp_Appraisal_VIEWDETAILS.Visible = true;
                    Rm_Appraisal_Kra.SelectedIndex = 0;
                    Rm_Kra_Details.Visible = true;
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
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        if (dtem12.Rows.Count != 0)
                        {
                            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem12.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                        }
                        DataTable dtappid1 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                        _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
                        _obj_Pms_EmpGoalSetting.Mode = 10;
                        _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                        if (dtappid1.Rows.Count != 0)
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
                            _obj_Pms_Roles.ROLES_NAME = Convert.ToString(rtxt_Role.Text);
                            if (dtem1.Rows.Count != 0)
                            {
                                _obj_Pms_Roles.BUID = Convert.ToInt32(dtem1.Rows[0]["BU_ID"]);
                            }
                            _obj_Pms_Roles.ROLES_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dt55 = Pms_Bll.get_Roles(_obj_Pms_Roles);

                            SPMS_ROLEKRA _obj_Pms_RoleKra = new SPMS_ROLEKRA();
                            _obj_Pms_RoleKra.Mode = 8;
                            _obj_Pms_RoleKra.ROLEKRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            if (dt55.Rows.Count != 0)
                            {
                                _obj_Pms_RoleKra.ROLE_ID = Convert.ToInt32(dt55.Rows[0]["ROLE_ID"]);
                            }
                            _obj_Pms_RoleKra.ROLE_KRA_ID = Convert.ToInt32(lblkradt_id.Text);
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
                    Rm_Kra_Details.Visible = false;
                    Rm_AppraisalDiscussion.Visible = false;

                    Rm_Appraisal_Kra.Visible = false;

                    return;
                }
            }
            else
            {
                Pms_Bll.ShowMessage(this, "No Kra Assigned");
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsApproverAppraisal", ex.StackTrace, DateTime.Now);
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
                Rm_Appraisal_PAGE.SelectedIndex = 0;
                Rm_Appraisal_Kra.Visible = false;
                Rm_Appraisal_Goal.Visible = false;
                Rm_Kra_Details.Visible = false;
                Rm_AppraisalDiscussion.Visible = false;
            }
            else
            {
                PMS_EMPSETUP _obj_Pms_EmpSetup = new PMS_EMPSETUP();


                SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
                _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);

                DataTable dt_bu = BLL.get_Business_Units(_obj_smhr_logininfo);
                if (dt_bu.Rows.Count != 0)
                {
                    _obj_Pms_EmpSetup.BU_ID = Convert.ToInt32(dt_bu.Rows[0]["BUSINESSUNIT_ID"]);
                }
                _obj_Pms_EmpSetup.EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                _obj_Pms_EmpSetup.Mode = 6;
                _obj_Pms_EmpSetup.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                DataTable DTREPO = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);
                if (DTREPO.Rows.Count != 0)
                {

                    rtxt_RpMgr.Text = Convert.ToString(DTREPO.Rows[0]["REPORTINGMGR_NAME"]);
                    rtxt_RpMgr.Enabled = false;

                }




                _obj_Pms_EmpSetup.EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                _obj_Pms_EmpSetup.Mode = 7;
                _obj_Pms_EmpSetup.EMP_SETUP_LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                DataTable DTgeneralmgr = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);
                if (DTgeneralmgr.Rows.Count != 0)
                {
                    rtxt_GpMgr.Text = Convert.ToString(DTgeneralmgr.Rows[0]["GENERALMGR_NAME"]);
                    rtxt_GpMgr.Enabled = false;

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
                    rtxt_Role.Enabled = false;
                    rtxt_Project.Enabled = false;
                    rtxt_AppraisalCycle.Enabled = false;


                }
                else
                {

                }



                LoadGrid();


                Session["empid"] = rcmb_EmployeeType.SelectedItem.Value;
                lnk_Idp.OnClientClick = " openRadWin('frm_idp.aspx'); return false;";
                lnk_Task.OnClientClick = " openRadWin('frm_Pms_Task.aspx'); return false;";

                lbl_ApproverComments.Visible = true;
                txt_ApproverComments.Visible = true;
                lbl_FinalRating.Visible = true;
                rdrtg_final.Visible = true;
                Rg_Appraisal_Goal.Enabled = true;
                btn_ApproverSubmit.Visible = true;
                btn_Cancel.Visible = true;

                lnk_Idp.Visible = false;
                lnk_Task.Visible = false;
                lbl_KraAvgRtg.Visible = false;
                lbl_GoalAvgRtg.Visible = false;
                rnt_GoalAvgrtg.Visible = false;
                rnt_KraAvgrtg.Visible = false;
                rnt_KraAvgrtg.Enabled = false;

                Rg_Appraisal_Kra.Enabled = true;
                txt_ApproverComments.Enabled = false;
                rdrtg_final.Enabled = true;
                btn_ApproverSubmit.Enabled = true;
                rdrtg_final.Enabled = false;

                lbl_KraAvgRtg.Enabled = true;
                rnt_GoalAvgrtg.Enabled = false;
                rnt_KraAvgrtg.Enabled = false;

                Rm_Appraisal_Goal.Enabled = true;
                Rg_Appraisal_Goal.Enabled = true;
                lbl_GoalAvgRtg.Enabled = true;
                lnk_Idp.Visible = false;

                btn_ApproverSubmit.Visible = false;
                Rm_AppraisalDiscussion.Visible = false;

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
                _obj_Spms_Appraisal.Mode = 22;
                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                if (dtappidzz2.Rows.Count != 0)
                {
                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz2.Rows[0]["APPRCYCLE_ID"]);
                }
                DataTable dt12 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                if (dt12.Rows.Count != 0)
                {
                    txt_ApproverComments.Text = Convert.ToString(dt12.Rows[0]["APP_APPROVER_COMMENTS"]);
                    rdrtg_final.Value = Convert.ToDecimal(dt12.Rows[0]["APP_APPROVER_RATING"]);
                    rdrtg_final.Enabled = false;
                    txt_ApproverComments.Enabled = false;
                    btn_ApproverSubmit.Visible = false;
                    btn_ApproverCancel.Visible = false;
                    Pms_Bll.ShowMessage(this, "Already Appraisal Done");
                }
                else
                {

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
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtappidzL = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);



                    _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                    if (dtappidzL.Rows.Count != 0)
                    {
                        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzL.Rows[0]["APPRCYCLE_ID"]);
                    }
                    _obj_Spms_Appraisal.Mode = 36;
                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtg = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                    //which gives sum of goal,kra avg rtg
                    //rnt_KraAvgrtg.Value = Convert.ToDouble(dtg.Rows[0]["APP_KRA_MGR_RATING"]);
                    if (dtg.Rows.Count != 0)
                    {
                        rdrtg_final.Value = Convert.ToDecimal(dtg.Rows[0]["APP_KRA_MGR_RATING"]);
                        rdrtg_final.Enabled = false;
                    }
                    else
                    {
                        rdrtg_final.Value = 0;
                        rdrtg_final.Enabled = true;
                    }

                    _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                    if (dtappidzL.Rows.Count != 0)
                    {

                        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzL.Rows[0]["APPRCYCLE_ID"]);
                    }
                    _obj_Spms_Appraisal.Mode = 42;
                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtg34 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

                    if (dtg34.Rows.Count != 0)
                    {
                        if (dtg34.Rows[0]["APPRAISAL_GOAL_AVGRTG"] != System.DBNull.Value)
                        {
                            rnt_GoalAvgrtg.Value = Convert.ToDouble(dtg34.Rows[0]["APPRAISAL_GOAL_AVGRTG"]);
                        }
                        else
                        {
                            rnt_GoalAvgrtg.Value = 0.0;
                        }
                        if (dtg34.Rows[0]["APPRAISAL_KRA_AVGRTG"] != System.DBNull.Value)
                        {
                            rnt_KraAvgrtg.Value = Convert.ToDouble(dtg34.Rows[0]["APPRAISAL_KRA_AVGRTG"]);
                        }
                        else
                        {
                            rnt_KraAvgrtg.Value = 0.0;
                        }
                        lbl_GoalAvgRtg.Visible = true;
                        lbl_KraAvgRtg.Visible = true;
                        rnt_KraAvgrtg.Visible = true;
                        rnt_GoalAvgrtg.Visible = true;
                    }
                    else
                    {
                        rnt_GoalAvgrtg.Value = 0;
                        rnt_KraAvgrtg.Value = 0;
                        lbl_GoalAvgRtg.Visible = true;
                        lbl_KraAvgRtg.Visible = true;
                        rnt_KraAvgrtg.Visible = true;
                        rnt_GoalAvgrtg.Visible = true;
                    }

                    txt_ApproverComments.Text = string.Empty;

                    txt_ApproverComments.Enabled = true;
                    rdrtg_final.Enabled = false;
                    btn_ApproverSubmit.Visible = true;
                    btn_ApproverCancel.Visible = true;


                }
            }



        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsApproverAppraisal", ex.StackTrace, DateTime.Now);
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
            Button btncancelmgrfeed = new System.Web.UI.WebControls.Button();
            RadRating rdratingmgr = new Telerik.Web.UI.RadRating();
            txtmgrfeed = Rg_Appraisal_Goal.Rows[i].FindControl("txt_GoalManagerFeedback") as TextBox;
            btnsubmitmgrfeed = Rg_Appraisal_Goal.Rows[i].FindControl("btn_GoalMgrSubmit") as Button;
            btncancelmgrfeed = Rg_Appraisal_Goal.Rows[i].FindControl("btn_GoalMgrCancel") as Button;
            rdratingmgr = Rg_Appraisal_Goal.Rows[i].FindControl("rdrtg_GoalMgr") as RadRating;

            #region Employee Feedback


            if (e.CommandName == "GoalEmployee_Feed")
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


                _obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();

                _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(lblgsdt_id.Text);
                _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = 0;
                _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Spms_AppraisalGoal.APP_GOALS_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                if (dtappidzL.Rows.Count != 0)
                {
                    _obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFBY = Convert.ToInt32(dtappidzL.Rows[0]["APPRCYCLE_ID"]);
                }
                _obj_Spms_AppraisalGoal.Mode = 5;
                DataTable dtgoal = Pms_Bll.get_AppraisalGoal(_obj_Spms_AppraisalGoal);

                if (dtgoal.Rows.Count != 0)
                {
                    txtempfeed.Text = Convert.ToString(dtgoal.Rows[0]["APP_GOALS_EMP_COMMENTS"]);

                    if (txtempfeed.Visible == true)
                    {

                        txtempfeed.Visible = false;


                    }
                    else
                    {

                        txtempfeed.Visible = true;
                        txtempfeed.Enabled = false;

                    }
                }
                else
                {

                    if (txtempfeed.Visible == true)
                    {

                        txtempfeed.Visible = false;


                    }
                    else
                    {

                        txtempfeed.Visible = true;
                        txtempfeed.Enabled = false;

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
                    if (dtg.Rows.Count != 0)
                    {
                        _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtg.Rows[0]["APPRAISAL_ID"]);
                    }
                    _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(lblgsdt_id.Text);
                    _obj_Spms_AppraisalGoal.Mode = 8;
                    DataTable dtgoal = Pms_Bll.get_AppraisalGoal(_obj_Spms_AppraisalGoal);

                    if (dtgoal.Rows.Count != 0)
                    {

                        txtmgrfeed.Text = Convert.ToString(dtgoal.Rows[0]["APP_GOALS_MGR_COMMENTS"]);


                        rdratingmgr.Value = Convert.ToInt32(dtgoal.Rows[0]["APP_GOALS_MGR_RATING"]);



                        txtmgrfeed.Enabled = false;
                        rdratingmgr.Enabled = false;
                        if (txtmgrfeed.Visible == true)
                        {

                            rdratingmgr.Visible = false;
                            txtmgrfeed.Visible = false;

                            btnsubmitmgrfeed.Visible = false;
                            btncancelmgrfeed.Visible = false;
                        }
                        else
                        {

                            rdratingmgr.Visible = true;
                            txtmgrfeed.Visible = true;
                            btnsubmitmgrfeed.Visible = false;
                            btncancelmgrfeed.Visible = false;

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
                        }
                        else
                        {

                            rdratingmgr.Visible = true;
                            txtmgrfeed.Visible = true;

                            btnsubmitmgrfeed.Visible = false;
                            btncancelmgrfeed.Visible = false;
                        }


                    }

                }
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsApproverAppraisal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
            #endregion






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
            txtKraEmployeeFeedback = Rg_Appraisal_Kra.Rows[i].FindControl("txt_KraEmployeeFeedback") as TextBox;
            btnKraEmpSubmit = Rg_Appraisal_Kra.Rows[i].FindControl("btn_KraEmpSubmit") as Button;
            btnKraEmpCancel = Rg_Appraisal_Kra.Rows[i].FindControl("btn_KraEmpCancel") as Button;

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
                _obj_Spms_AppraisalKra.APP_KRA_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                if (dtappidzz.Rows.Count != 0)
                {
                    _obj_Spms_AppraisalKra.APP_KRA_LASTMDFBY = Convert.ToInt32(dtappidzz.Rows[0]["APPRCYCLE_ID"]);
                }
                _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);

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
                    _obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                    _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtg.Rows[0]["APPRAISAL_ID"]);
                    _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Spms_AppraisalKra.APP_KRA_KRA_ID = Convert.ToInt32(lblkradt_id.Text);
                    _obj_Spms_AppraisalKra.Mode = 8;
                    DataTable dtKra1 = Pms_Bll.get_AppraisalKra(_obj_Spms_AppraisalKra);

                    if (dtKra1.Rows.Count != 0)
                    {
                        txtKraManagerFeedback.Text = Convert.ToString(dtKra1.Rows[0]["APP_KRA_MGR_COMMENTS"]);
                        rdrtgKraMgr.Value = Convert.ToInt32(dtKra1.Rows[0]["APP_KRA_MGR_RATING"]);

                        txtKraManagerFeedback.Enabled = false;
                        rdrtgKraMgr.Enabled = false;
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
                            btnKraMgrSubmit.Visible = false;
                            btnKraMgrCancel.Visible = false;
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
                            btnKraMgrSubmit.Visible = false;
                            btnKraMgrCancel.Visible = false;
                        }

                    }
                }
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsApproverAppraisal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
            #endregion

    #endregion


    #region Approver Submit Method


    protected void btn_ApproverSubmit_Click(object sender, EventArgs e)
    {
        try
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



            _obj_Spms_Appraisal = new SPMS_APPRAISAL();

            _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
            if (dtappidzz.Rows.Count != 0)
            {
                _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz.Rows[0]["APPRCYCLE_ID"]);
            }
            _obj_Spms_Appraisal.Mode = 10;
            _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtcheck = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

            if (dtcheck.Rows.Count != 0)
            {
                Pms_Bll.ShowMessage(this, "ApproverComments Already Finalised");

            }
            else
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


                _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                _obj_Spms_Appraisal.Mode = 27;
                if (dtappidzz02.Rows.Count != 0)
                {
                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz02.Rows[0]["APPRCYCLE_ID"]);
                }
                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtapp_id = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

                _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                _obj_Spms_Appraisal.APPRAISAL_DATE = DateTime.Now;
                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE = 8;
                _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(LBL_Appraise_Id.Text);
                _obj_Spms_Appraisal.APPRAISAL_CREATEDBY = Convert.ToInt32(Session["user_id"]);
                _obj_Spms_Appraisal.APPRAISAL_STATUS = 3;
                _obj_Spms_Appraisal.APPRAISAL_CREATEDDATE = DateTime.Now;
                if (dtapp_id.Rows.Count != 0)
                {
                    _obj_Spms_Appraisal.APPRAISAL_ID = Convert.ToInt32(dtapp_id.Rows[0]["APPRAISAL_ID"]);
                }
                _obj_Spms_Appraisal.Mode = 6;

                bool status = Pms_Bll.set_Appraisal(_obj_Spms_Appraisal);
                if (status == true)
                {
                    _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                    _obj_Pms_Appraisalcycle.MODE = 11;
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtemzzg = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                    _obj_Pms_Appraisalcycle.MODE = 8;
                    if (dtemzzg.Rows.Count != 0)
                    {
                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzzg.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                    }
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtappidzzg = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                    _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                    _obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE = 8;
                    if (dtappidzzg.Rows.Count != 0)
                    {

                        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzzg.Rows[0]["APPRCYCLE_ID"]);
                    }
                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

                    _obj_Spms_Appraisal.Mode = 5;

                    DataTable dtgoal1 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

                    _obj_Pms_AppApprover = new SPMS_APRAISALAPPROVER();
                    if (dtgoal1.Rows.Count != 0)
                    {
                        _obj_Pms_AppApprover.APP_APPROVER_APP_ID = Convert.ToInt32(dtgoal1.Rows[0]["APPRAISAL_ID"]);
                    }

                    _obj_Pms_AppApprover.Mode = 3;
                    _obj_Pms_AppApprover.APP_APPROVER_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(txt_ApproverComments.Text));
                    _obj_Pms_AppApprover.APP_APPROVER_RATING = Convert.ToDecimal(rdrtg_final.Value);
                    _obj_Pms_AppApprover.APP_APPROVER_CREATEDBY = Convert.ToInt32(Session["user_id"]);
                    _obj_Pms_AppApprover.APP_APPROVER_CREATEDDATE = DateTime.Now;
                    _obj_Pms_AppApprover.APP_APPROVER_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    bool status1 = Pms_Bll.set_AppApprover(_obj_Pms_AppApprover);
                    if (status1 == true)
                    {


                        //PMS_NOTIFICATION _obj_Pms_Send_AppMgrNotification;

                        //SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
                        //_obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                        //_obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"].ToString());

                        //DataTable dt_bu = BLL.get_Business_Units(_obj_smhr_logininfo);

                        //_obj_PMS_getemployee = new PMS_GETEMPLOYEE();
                        //_obj_PMS_getemployee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                        //_obj_PMS_getemployee.BU_ID = Convert.ToInt32(dt_bu.Rows[0]["BUSINESSUNIT_ID"]);
                        //DataTable dtbuid1 = Pms_Bll.get_RMEmployees(_obj_PMS_getemployee);
                        //PMS_EMPSETUP _obj_Pms_EmpSetup;
                        //_obj_Pms_EmpSetup = new PMS_EMPSETUP();
                        //_obj_Pms_LoginInfo = new PMS_LOGININFO();
                        //_obj_Pms_EmpSetup.EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                        //_obj_Pms_EmpSetup.Mode = 14;
                        //DataTable dtbuid2 = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);
                        ////durga written
                        ////_obj_Pms_Send_AppMgrNotification = new PMS_NOTIFICATION();
                        ////_obj_Pms_Send_AppMgrNotification.EMPID = Convert.ToInt32(dtbuid2.Rows[0]["GENERALMGR_ID"]);
                        ////_obj_Pms_Send_AppMgrNotification.RMID = Convert.ToInt32(dtbuid2.Rows[0]["REPORTINGMGR_ID"]);
                        ////bool status5 = Pms_Bll.Send_AppMgrNotification(_obj_Pms_Send_AppMgrNotification);
                        //_obj_Pms_Send_AppMgrNotification = new PMS_NOTIFICATION();


                        PMS_NOTIFICATION _obj_Pms_Send_Notification = new PMS_NOTIFICATION();
                        _obj_Pms_Send_Notification.EMPID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                        _obj_Pms_Send_Notification.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                        //sends mail to manager from approver
                        bool status7 = Pms_Bll.Send_NotificationApproverManager(_obj_Pms_Send_Notification);//aaa

                        _obj_Pms_Send_Notification = new PMS_NOTIFICATION();
                        _obj_Pms_Send_Notification.EMPID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                        _obj_Pms_Send_Notification.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                        //sends mail to employee from approver
                        bool status8 = Pms_Bll.Send_NotificationApproverEmployee(_obj_Pms_Send_Notification);//aaa




                        //PMS_NOTIFICATION _obj_Pms_Send_AppMgrNotification1;



                        //_obj_Pms_EmpSetup = new PMS_EMPSETUP();
                        //_obj_Pms_LoginInfo = new PMS_LOGININFO();
                        //_obj_Pms_EmpSetup.EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                        //_obj_Pms_EmpSetup.Mode = 14;
                        //DataTable dtbuid4 = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);



                        //_obj_Pms_Send_AppMgrNotification1 = new PMS_NOTIFICATION();
                        //_obj_Pms_Send_AppMgrNotification1.EMPID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                        //_obj_Pms_Send_AppMgrNotification1.GMID = Convert.ToInt32(dtbuid4.Rows[0]["GENERALMGR_ID"]);
                        //bool status6 = Pms_Bll.Send_AppMgrNotification1(_obj_Pms_Send_AppMgrNotification1);




                        btn_Cancel.Visible = false;
                        lbl_KraAvgRtg.Enabled = false;
                        rnt_KraAvgrtg.Enabled = false;
                        Rg_Appraisal_Kra.Enabled = false;
                        Rm_Appraisal_Goal.Enabled = false;
                        //rcmb_EmployeeType.ClearSelection();
                        //DataTable dt = new DataTable();
                        //rcmb_EmployeeType.DataSource = dt;
                        ////rcmb_EmployeeType.DataBind();
                        //rcmb_EmployeeType.SelectedIndex = 0;
                        rcmb_EmployeeType.Enabled = true;
                        Rm_Appraisal_PAGE.SelectedIndex = 0;
                        Rm_Appraisal_Kra.Visible = false;
                        Rm_Appraisal_Goal.Visible = false;
                        Rm_Kra_Details.Visible = false;
                        Rm_AppraisalDiscussion.Visible = false;
                        //rcmb_feedback.SelectedIndex = 0;
                        rtxt_RpMgr.Text = string.Empty;
                        rtxt_GpMgr.Text = string.Empty;
                        rcmb_BusinessUnitType.Enabled = true;
                        rcmb_EmployeeType.Enabled = true;
                        rtxt_RpMgr.Enabled = true;
                        rtxt_GpMgr.Enabled = true;
                        rtxt_Role.Enabled = true;
                        rtxt_Project.Enabled = true;
                        rtxt_AppraisalCycle.Enabled = true;
                        rtxt_Role.Text = string.Empty;
                        rtxt_Project.Text = string.Empty;
                        rtxt_AppraisalCycle.Text = string.Empty;
                        rcmb_BusinessUnitType.SelectedIndex = 0;
                        rcmb_EmployeeType.ClearSelection();
                        rcmb_EmployeeType.Items.Clear();
                        rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

                        Pms_Bll.ShowMessage(this, "Approver Comments Inserted Successfully");
                        Pms_Bll.ShowMessage(this, "Notification Send");
                        return;
                    }
                }

            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsApproverAppraisal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    protected void btn_ApproverCancel_Click1(object sender, EventArgs e)
    {
        try
        {
            //rcmb_EmployeeType.ClearSelection();
            //DataTable dt = new DataTable();
            //rcmb_EmployeeType.DataSource = dt;
            //rcmb_EmployeeType.DataBind();
            Rm_Appraisal_PAGE.SelectedIndex = 0;
            Rm_Appraisal_Kra.Visible = false;
            Rm_Appraisal_Goal.Visible = false;
            Rm_Kra_Details.Visible = false;
            Rm_AppraisalDiscussion.Visible = false;
            rcmb_EmployeeType.SelectedIndex = 0;
            rtxt_RpMgr.Text = string.Empty;
            rtxt_GpMgr.Text = string.Empty;
            rtxt_Role.Enabled = true;
            rtxt_Project.Enabled = true;
            rtxt_AppraisalCycle.Enabled = true;
            rtxt_Role.Text = string.Empty;
            rtxt_Project.Text = string.Empty;

            rtxt_AppraisalCycle.Text = string.Empty;
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsApproverAppraisal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

}
