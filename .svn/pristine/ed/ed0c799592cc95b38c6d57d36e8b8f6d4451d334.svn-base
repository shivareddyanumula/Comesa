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
using SPMS;
public partial class Training_frm_TrainingFeedBack : System.Web.UI.Page
{
    //SMHR_JOBREQUISITION _obj_Smhr_JobReqDetails = new SMHR_JOBREQUISITION();
    SMHR_TRAININGREQUEST _obj_Smhr_TrgRqst;
    SMHR_LOGINTYPE _obj_Smhr_LoginInfo = new SMHR_LOGINTYPE();
    SMHR_FEEDBACK_QUESTION _obj_SMHR_FEEDBACK_QUESTION=new SMHR_FEEDBACK_QUESTION();
    SMHR_TRAININGFEEDBACK _obj_SMHR_TRAININGFEEDBACK_RESPONSE = new SMHR_TRAININGFEEDBACK();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                LoadGrid();
                Rg_TrgFeedback.DataBind();
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("ASSIGN FEEDBACK");
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
                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    RG_FeedBack.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    RG_FeedBack.Enabled = false;
                }
                else
                {
                    RG_FeedBack.Enabled = true;
                }
                Rm_TRGFEEDABCK_PAGE.SelectedIndex = 0;

            }
            Page.Validate();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingFeedBack", ex.StackTrace, DateTime.Now);

            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
       try
       {
        btn_assign.Visible = false;
        //rcm_employee.Visible = false;
        LoadCombos();
        btn_Finalize.Visible = false;
        btn_Preview.Visible = false;
        //lbl_assign.Visible = false;
        btn_Cancel.Visible = true;
        Rp_TRGFEEDABCK_VIEWMAIN.Visible = false;
        Rm_TRGFEEDABCK_PAGE.SelectedIndex = 1;
        RP_trgfeedback_VIEWDETAILS.Visible = true;
        rcmb_Type.SelectedIndex = 0;
        rtxt_FeedbackName.Text = string.Empty;
        rnt_bakdateddate.Text = string.Empty;
        rtxt_FeedbackDescription.Text = string.Empty;
        rlb_Quetions.Items.Clear();
        rlb_Quetions.Enabled = true;
        RG_FeedBack.Visible = false;
        rtxt_FeedbackName.Enabled = true;
        rcmb_BU.Enabled = true;
        rcmb_TRName.Enabled = true;
        rcmb_Type.Enabled = true;
        btn_Save.Visible = true;

          }
         catch (Exception ex)
         {
             SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingFeedBack", ex.StackTrace, DateTime.Now);

             Response.Redirect("~/Frm_ErrorPage.aspx");
         }
    }



    #region LoadGrid
    /// <summary>
    ///IN THIS data binding from database to datatable binding to radgrid
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void Rg_TrgFeedback_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {

        //_obj_SMHR_TRAININGFEEDBACK_RESPONSE.OPERATION = operation.Select;

        //DataTable dt = BLL.get_FeedbackResponse(_obj_SMHR_TRAININGFEEDBACK_RESPONSE);
        //if (dt.Rows.Count != 0)
        //{
            //Rg_TrgFeedback.DataSource = dt;
            LoadGrid();
        //}
    }
    protected void LoadGrid()
    {
        try
        {
            _obj_SMHR_TRAININGFEEDBACK_RESPONSE.OPERATION = operation.Select;
            _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_FeedbackResponse(_obj_SMHR_TRAININGFEEDBACK_RESPONSE);
            if (dt.Rows.Count != 0)
            {
                Rg_TrgFeedback.DataSource = dt;
            }
            else
            {
                DataTable dt1 = new DataTable();

                Rg_TrgFeedback.DataSource = dt1;

                Rg_TrgFeedback.DataBind();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingFeedBack", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion



    protected void lnk_FEEDBACK_ID_Command(object sender, CommandEventArgs e)
    {

        try
        {
        _obj_SMHR_TRAININGFEEDBACK_RESPONSE.OPERATION = operation.MODE;
        _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
        lbl_id.Text = Convert.ToString(e.CommandArgument);

        DataTable DT = BLL.get_FeedbackResponse(_obj_SMHR_TRAININGFEEDBACK_RESPONSE);
        if (DT.Rows.Count != 0)
        {
            LoadCombos();
            rcmb_BU.SelectedIndex = rcmb_BU.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["FEEDBACK_BU_ID"]));
            rcmb_TRName.SelectedIndex = rcmb_TRName.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["FEEDBACK_TR_ID"]));
            rcmb_Type.SelectedItem.Text = Convert.ToString(DT.Rows[0]["FEEDBACK_CATEGORY"]);
            //rcm_employee.SelectedIndex = rcm_employee.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["TRAINERDETAILS_EMPLOYEEID"]));
            rtxt_FeedbackName.Text = Convert.ToString(DT.Rows[0]["FEEDBACK_NAME"]);
            rtxt_FeedbackDescription.Text = Convert.ToString(DT.Rows[0]["FEEDBACK_DESCRIPTION"]);
            //rcm_employee.DataSource = DT;
            //rcm_employee.DataTextField = "EMP_EMPCODE";
            //rcm_employee.DataValueField = "TRAINERDETAILS_EMPLOYEEID";
            //rcm_employee.DataBind();

            rlb_Quetions.DataSource = DT;
            rlb_Quetions.DataTextField = "FEEDBACKQUESTS_QUESTION";
            rlb_Quetions.DataValueField = "FEEDBACKQUESTS_ID";
            rlb_Quetions.DataBind();
            rlb_Quetions.Enabled = false;
            rcmb_BU.Enabled = false;
            rcmb_TRName.Enabled = false;
            rcmb_Type.Enabled = false;
            RG_FeedBack.DataSource = DT;
            RG_FeedBack.DataBind();

            RG_FeedBack.Visible = true;
            Rm_TRGFEEDABCK_PAGE.SelectedIndex = 1;
            btn_assign.Visible = true;
            //rcm_employee.Visible = true;
            btn_Cancel.Visible = true;
            //lbl_assign.Visible = true;
            btn_Finalize.Visible = false;
            btn_Preview.Visible = false;
            btn_Save.Visible = false;
            btn_Cancel.Visible = false;
            rtxt_FeedbackName.Enabled = false;
            rtxt_FeedbackDescription.Enabled = false;
            Rp_TRGFEEDABCK_VIEWMAIN.Visible = false;
            RP_trgfeedback_VIEWDETAILS.Visible = true;
        }
          }
         catch (Exception ex)
         {
             SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingFeedBack", ex.StackTrace, DateTime.Now);
             Response.Redirect("~/Frm_ErrorPage.aspx");  
         }

    }
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    private void LoadCombos()
    {
        try
    {
        SMHR_BUSINESSUNIT _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();


        SMHR_LOGININFO _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
        _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
        _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
        DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
        if (dt_BUDetails.Rows.Count != 0)
        {
            rcmb_BU.DataSource = dt_BUDetails;
            rcmb_BU.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BU.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BU.DataBind();
            rcmb_BU.Items.Insert(0, new RadComboBoxItem("Select"));
        }

        else
        {
            DataTable dt_Details = new DataTable();
            rcmb_BU.DataSource = dt_BUDetails;

            rcmb_BU.DataBind();
            rcmb_BU.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        //Business Unit
     
        //Training Nameonly approved trainings will come
        DataTable DT = new DataTable();
        _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();
        _obj_Smhr_TrgRqst.Mode = 16;

        _obj_Smhr_TrgRqst.TR_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
        rcmb_TRName.DataSource = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);
        rcmb_TRName.DataTextField = "TR_TITLE";
        rcmb_TRName.DataValueField = "TR_ID";
        rcmb_TRName.DataBind();
        rcmb_TRName.Items.Insert(0, new RadComboBoxItem("Select", "0"));
         }
         catch (Exception ex)
         {
             SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingFeedBack", ex.StackTrace, DateTime.Now);
             Response.Redirect("~/Frm_ErrorPage.aspx");
         }
    }
   
    protected void rcmb_Type_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Type.SelectedItem.Text != "Select")
            {
                rlb_Quetions.Items.Clear();
                _obj_SMHR_TRAININGFEEDBACK_RESPONSE.OPERATION = operation.EMPTY1;
                _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_TR_ID = Convert.ToInt32(rcmb_TRName.SelectedValue);
                _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_CATEGORY = Convert.ToString(rcmb_Type.SelectedValue);
                //if (Convert.ToString(BLL.get_FeedbackResponse(_obj_SMHR_TRAININGFEEDBACK_RESPONSE).Rows[0]["FEEDBACK_STATUS"]) != "0"  )
                //{
                //    btn_Save.Enabled = false;
                //}
                //else
                //{
                //    btn_Save.Enabled = true;
                //}
                _obj_SMHR_FEEDBACK_QUESTION.FEEDBACKQUESTS_QUESTION_CATEGORY = Convert.ToString(rcmb_Type.SelectedValue);
               _obj_SMHR_FEEDBACK_QUESTION.OPERATION = operation.Empty;
                _obj_SMHR_FEEDBACK_QUESTION.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt = BLL.get_FeedbackQuestion(_obj_SMHR_FEEDBACK_QUESTION);
                rlb_Quetions.DataSource = dt;
                rlb_Quetions.DataTextField = "FEEDBACKQUESTS_QUESTION";
                rlb_Quetions.DataValueField = "FEEDBACKQUESTS_ID";
                rlb_Quetions.DataBind();
                RG_FeedBack.Visible = false;
            }

            else
            {
                BLL.ShowMessage(this, "Please Select Type");
              
                DataTable dt1 = new DataTable();

                rlb_Quetions.DataSource = dt1;
              
                rlb_Quetions.DataBind();
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingFeedBack", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {



        try
        {

            if (rlb_Quetions.Items.Count != 0)
            {

                SMHR_TRAININGFEEDBACK _obj_SMHR_TRAININGFEEDBACK_RESPONSE = new SMHR_TRAININGFEEDBACK();
                _obj_SMHR_TRAININGFEEDBACK_RESPONSE.OPERATION = operation.MODE6;
                _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_TR_ID = Convert.ToInt32(rcmb_TRName.SelectedValue);
                _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_CATEGORY = Convert.ToString(rcmb_Type.SelectedValue);
                _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_BU_ID = Convert.ToInt32(rcmb_BU.SelectedValue);
                _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt93 = BLL.get_FeedbackResponse(_obj_SMHR_TRAININGFEEDBACK_RESPONSE);


                if (dt93.Rows.Count != 0)
                {

                    BLL.ShowMessage(this, "Already Feedback Assigned For Training");
                    RP_trgfeedback_VIEWDETAILS.Visible = false;
                    Rp_TRGFEEDABCK_VIEWMAIN.Visible = true;
                    Rm_TRGFEEDABCK_PAGE.SelectedIndex = 0;

                    LoadGrid();
                    Rg_TrgFeedback.DataBind();
                    Rm_TRGFEEDABCK_PAGE.SelectedIndex = 0;
                }
                else
                {

                    bool res2 = false;
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_TR_ID = Convert.ToInt32(rcmb_TRName.SelectedValue);
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_CATEGORY = Convert.ToString(rcmb_Type.SelectedValue);
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_BU_ID = Convert.ToInt32(rcmb_BU.SelectedValue);
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_NAME = BLL.ReplaceQuote(Convert.ToString(rtxt_FeedbackName.Text));
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_DESCRIPTION = BLL.ReplaceQuote(Convert.ToString(rtxt_FeedbackDescription.Text));
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_STATUS = 0;
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE.CREATEDDATE = DateTime.Now;
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_BACKDATE = Convert.ToInt32(rnt_bakdateddate.Value);
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE.OPERATION = operation.Insert;
                    res2 = BLL.set_FeedbackResponse(_obj_SMHR_TRAININGFEEDBACK_RESPONSE);
                    Label lblApp = new Label();

                    for (int index = 0; index < RG_FeedBack.Items.Count; index++)
                    {
                        lblApp = RG_FeedBack.Items[index].FindControl("lblAppID") as Label;
                        SMHR_TRGFEEDBACKQUESDTLS _obj_Smhr_TRGFEEDBACKQUESDTLS = new SMHR_TRGFEEDBACKQUESDTLS();
                        _obj_SMHR_TRAININGFEEDBACK_RESPONSE.OPERATION = operation.MODE1;
                        _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_NAME = BLL.ReplaceQuote(Convert.ToString(rtxt_FeedbackName.Text));
                        _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_TR_ID = Convert.ToInt32(rcmb_TRName.SelectedValue);
                        _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_CATEGORY = Convert.ToString(rcmb_Type.SelectedValue);
                        _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_BU_ID = Convert.ToInt32(rcmb_BU.SelectedValue);
                        DataTable dt5 = BLL.get_FeedbackResponse(_obj_SMHR_TRAININGFEEDBACK_RESPONSE);



                        _obj_Smhr_TRGFEEDBACKQUESDTLS.TRFDBDTL_FDBID = Convert.ToInt32(dt5.Rows[0]["FEEDBACK_ID"]);



                        _obj_Smhr_TRGFEEDBACKQUESDTLS.TRFDBDTL_QUESTIONSID = Convert.ToInt32(lblApp.Text);
                        _obj_Smhr_TRGFEEDBACKQUESDTLS.Mode = 3;
                        _obj_Smhr_TRGFEEDBACKQUESDTLS.TRFDBDTL_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_Smhr_TRGFEEDBACKQUESDTLS.TRFDBDTL_CREATEDDATE = DateTime.Now;
                        bool status = BLL.set_TRGFEEDBAKQUESTDTLS(_obj_Smhr_TRGFEEDBACKQUESDTLS);
                        Session["TR_ID"] = Convert.ToInt32(rcmb_TRName.SelectedValue);
                        Session["CATEGORY"] = Convert.ToString(rcmb_Type.SelectedValue);
                        Session["BU_ID"] = Convert.ToInt32(rcmb_BU.SelectedValue);
                        int a = Convert.ToInt32(Session["TR_ID"]);

                        //if (Convert.ToString(BLL.get_FeedbackResponse(_obj_SMHR_TRAININGFEEDBACK_RESPONSE).Rows[0]["Count"]) != "0")
                        ////{
                        ////    BLL.ShowMessage(this, "Trainig FeedBack Already Saved Successfully");
                        ////    return;
                        ////}
                        ////else
                        ////{
                        //    //_obj_SMHR_TRAININGFEEDBACK_RESPONSE.OPERATION = operation.Insert;
                        //    //res2 = BLL.set_FeedbackResponse(_obj_SMHR_TRAININGFEEDBACK_RESPONSE);
                        ////}

                    }
                    if (res2 == true)
                    {
                        BLL.ShowMessage(this, "Training FeedBack Saved Successfully");
                        rlb_Quetions.Enabled = false;
                        btn_Preview.Visible = true;
                        //btn_Finalize.Visible = true;
                        btn_Save.Visible = false;
                        rcmb_Type.Enabled = false;
                        rcmb_BU.Enabled = false;
                        rcmb_TRName.Enabled = false;
                        rtxt_FeedbackDescription.Text = string.Empty;
                        rtxt_FeedbackName.Enabled = false;
                        RP_trgfeedback_VIEWDETAILS.Visible = false;
                        Rp_TRGFEEDABCK_VIEWMAIN.Visible = true;
                        Rm_TRGFEEDABCK_PAGE.SelectedIndex = 0;

                        LoadGrid();
                        Rg_TrgFeedback.DataBind();
                        Rm_TRGFEEDABCK_PAGE.SelectedIndex = 0;



                        //assign feedback to trainer of that trg
                        if (rcmb_Type.SelectedItem.Text == "Trainer")
                        {
                            SMHR_ASSIGNFEEDBACK_EMPLOYEE _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE = new SMHR_ASSIGNFEEDBACK_EMPLOYEE();


                            _obj_SMHR_TRAININGFEEDBACK_RESPONSE.OPERATION = operation.MODE1;
                            _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_NAME = BLL.ReplaceQuote(Convert.ToString(rtxt_FeedbackName.Text));
                            _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_BU_ID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
                            _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_TR_ID = Convert.ToInt32(rcmb_TRName.SelectedItem.Value);
                            _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_CATEGORY = Convert.ToString(rcmb_Type.SelectedItem.Text);

                            DataTable dt5 = BLL.get_FeedbackResponse(_obj_SMHR_TRAININGFEEDBACK_RESPONSE);




                            SMHR_TRAINER _obj_Smhr_Trner = new SMHR_TRAINER();
                            _obj_Smhr_Trner.Mode = 5;
                            _obj_Smhr_Trner.TRAINERDETAILS_TR_ID = Convert.ToInt32(rcmb_TRName.SelectedItem.Value);
                            DataTable dt1 = BLL.get_TRAINer(_obj_Smhr_Trner);


                            _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.Mode = 2;
                            _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGNFEED_FEEBAK_ID = Convert.ToInt32(dt5.Rows[0]["FEEDBACK_ID"]);
                            //if trg is external then inplace of trainer we are passing hr employeeid
                            if (dt1.Rows.Count != 0)
                            {
                                _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGN_EMP_ID = Convert.ToInt32(dt1.Rows[0]["TRAINERDETAILS_EMPLOYEEID"]);
                            }
                            else
                            {//IF TRAINER EXTERNAL WE HAVE TO GIVE HR ID

                                _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();
                                _obj_Smhr_TrgRqst.Mode = 21;
                                _obj_Smhr_TrgRqst.TR_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable DT45 = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);
                                if (DT45.Rows.Count != 0)
                                {
                                    _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGN_EMP_ID = 0;
                                }

                                else
                                {
                                    _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGN_EMP_ID = 0;
                                }
                            }

                            DataTable dt2 = BLL.get__SMHR_ASSIGNFEEDBACK_EMPLOYEE(_obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE);
                            if (dt2.Rows.Count != 0)
                            {

                                BLL.ShowMessage(this, "Tarining Already Assigned To Employee");
                                return;
                            }
                            else
                            {

                                _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE = new SMHR_ASSIGNFEEDBACK_EMPLOYEE();
                                _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.Mode = 3;
                                _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGNFEED_FEEBAK_ID = Convert.ToInt32(dt5.Rows[0]["FEEDBACK_ID"]);
                                if (dt1.Rows.Count != 0)
                                {
                                    _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGN_EMP_ID = Convert.ToInt32(dt1.Rows[0]["TRAINERDETAILS_EMPLOYEEID"]);
                                }

                                else
                                {
                                    _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();
                                    _obj_Smhr_TrgRqst.Mode = 21;
                                    _obj_Smhr_TrgRqst.TR_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                    DataTable DT455 = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);
                                    if (DT455.Rows.Count != 0)
                                    {
                                        _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGN_EMP_ID = 0;
                                    }

                                    else
                                    {
                                        _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGN_EMP_ID = 0;
                                    }

                                }
                                _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGN_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                                _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGN_CREATEDDATE = DateTime.Now;
                                bool status = BLL.set_SMHR_ASSIGNFEEDBACK_EMPLOYEE(_obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE);
                                if (status == true)
                                {
                                    BLL.ShowMessage(this, "Feedback Assigned Successfully");

                                    RP_trgfeedback_VIEWDETAILS.Visible = false;
                                    Rp_TRGFEEDABCK_VIEWMAIN.Visible = true;
                                    Rm_TRGFEEDABCK_PAGE.SelectedIndex = 0;

                                    LoadGrid();
                                    Rg_TrgFeedback.DataBind();
                                    Rm_TRGFEEDABCK_PAGE.SelectedIndex = 0;

                                }

                            }


                        }
                        else if (rcmb_Type.SelectedItem.Text == "Trainee")
                        {
                            _obj_SMHR_TRAININGFEEDBACK_RESPONSE.OPERATION = operation.MODE1;
                            _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_NAME = BLL.ReplaceQuote(Convert.ToString(rtxt_FeedbackName.Text));
                            _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_BU_ID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
                            _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_TR_ID = Convert.ToInt32(rcmb_TRName.SelectedItem.Value);
                            _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_CATEGORY = Convert.ToString(rcmb_Type.SelectedItem.Text);

                            DataTable dt55 = BLL.get_FeedbackResponse(_obj_SMHR_TRAININGFEEDBACK_RESPONSE);

                            SMHR_ASSIGNFEEDBACK_EMPLOYEE _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE = new SMHR_ASSIGNFEEDBACK_EMPLOYEE();

                            _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.Mode = 6;
                            //_obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGNFEED_FEEBAK_ID = Convert.ToInt32(lbl_id.Text);
                            _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGNFEED_FEEBAK_ID = Convert.ToInt32(dt55.Rows[0]["FEEDBACK_ID"]);

                            DataTable dttrnee = BLL.get__SMHR_ASSIGNFEEDBACK_EMPLOYEE(_obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE);

                            if (dttrnee.Rows.Count != 0)
                            {
                                BLL.ShowMessage(this, "Training Already Assigned To Trainee");
                               

                            }
                            else
                            {
                                SMHR_TRAINEE _obj_Smhr_TrnEE = new SMHR_TRAINEE();
                                _obj_Smhr_TrnEE.Mode = 5;
                                _obj_Smhr_TrnEE.TRAINEE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                _obj_Smhr_TrnEE.TRAINEE_TR_ID = Convert.ToInt32(rcmb_TRName.SelectedItem.Value);
                                DataTable dtemp = BLL.get_TRAINEE(_obj_Smhr_TrnEE);
                                //  for (int i = 0; i <= dtemp.Rows.Count ; i++)
                                //  {
                                foreach (DataRow item in dtemp.Rows)
                                {
                                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE.OPERATION = operation.MODE1;
                                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_BU_ID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
                                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_TR_ID = Convert.ToInt32(rcmb_TRName.SelectedItem.Value);
                                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_CATEGORY = Convert.ToString(rcmb_Type.SelectedItem.Text);
                                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_NAME = BLL.ReplaceQuote(Convert.ToString(rtxt_FeedbackName.Text));
                                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                    DataTable dt5 = BLL.get_FeedbackResponse(_obj_SMHR_TRAININGFEEDBACK_RESPONSE);

                                    _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE = new SMHR_ASSIGNFEEDBACK_EMPLOYEE();
                                    _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.Mode = 3;

                                    _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGNFEED_FEEBAK_ID = Convert.ToInt32(dt5.Rows[0]["FEEDBACK_ID"]);
                                    _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGN_EMP_ID = Convert.ToInt32(item["TRAINEE_EMPID"]);
                                    _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGN_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                                    _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGN_CREATEDDATE = DateTime.Now;
                                    bool status = BLL.set_SMHR_ASSIGNFEEDBACK_EMPLOYEE(_obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE);
                                    if (status == true)
                                    {
                                      
                                        //LoadGrid();
                                        //Rm_TRGFEEDABCK_PAGE.SelectedIndex = 0;

                                    }
                                    //BLL.ShowMessage(this, "Feedback Assigned Successfully");
                                    BLL.ShowMessage(this, "Feedback Assigned Successfully");
                                    RP_trgfeedback_VIEWDETAILS.Visible = false;
                                    Rp_TRGFEEDABCK_VIEWMAIN.Visible = true;
                                    Rm_TRGFEEDABCK_PAGE.SelectedIndex = 0;

                                    LoadGrid();
                                    Rg_TrgFeedback.DataBind();
                                    Rm_TRGFEEDABCK_PAGE.SelectedIndex = 0;
                                }
                            }
                        }

                        return;
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Please Check Feedback Question");
                        return;
                    }





                }



            }
       

            else
            {
                BLL.ShowMessage(this, "Please Check Feedback Question");
                return;

            }



          

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingFeedBack", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void  btn_Preview_Click(object sender, EventArgs e)
    {
        try
        {
            Session["TR_ID"] = Convert.ToInt32(rcmb_TRName.SelectedValue);
            Session["CATEGORY"] = Convert.ToString(rcmb_Type.SelectedValue);
            Session["BU_ID"] = Convert.ToInt32(rcmb_BU.SelectedValue);
            Session["FEEDBACK_NAME"] = BLL.ReplaceQuote(Convert.ToString(rtxt_FeedbackName.Text));

            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "function pageLoad() { WinOpen_image(); }", true);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "javascript:Close();", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingFeedBack", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        
    }

    protected void btn_Finalize_Click(object sender, EventArgs e)
    {
        try
        {
            Label lblApp = new Label();
            bool res2 = false;
            for (int index = 0; index < RG_FeedBack.Items.Count; index++)
            {
                lblApp = RG_FeedBack.Items[index].FindControl("lblAppID") as Label;
                _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_TR_ID = Convert.ToInt32(rcmb_TRName.SelectedValue);
                _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_CATEGORY = Convert.ToString(rcmb_Type.SelectedValue);
                //_obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_BU_ID = Convert.ToInt32(rcmb_BU.SelectedValue);
                _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_STATUS = 1;
                _obj_SMHR_TRAININGFEEDBACK_RESPONSE.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);

                _obj_SMHR_TRAININGFEEDBACK_RESPONSE.LASTMDFDATE = DateTime.Now;
                _obj_SMHR_TRAININGFEEDBACK_RESPONSE.OPERATION = operation.load ;
                //if (Convert.ToString(BLL.get_FeedbackResponse(_obj_SMHR_TRAININGFEEDBACK_RESPONSE).Rows[0]["Count"]) != "0")
                //{
                //}
                //else
                //{
             
                //}
              //  _obj_SMHR_TRAININGFEEDBACK_RESPONSE.OPERATION = operation.load;
                res2 = BLL.set_FeedbackResponse(_obj_SMHR_TRAININGFEEDBACK_RESPONSE);

            }
            if (res2 == true)
            {
                BLL.ShowMessage(this, "Training FeedBack Finalized Saved Successfully");
                btn_Save.Enabled = false;
                return;
            }
            else
            {
                BLL.ShowMessage(this, "Training FeedBack Finalized Saved Successfully");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingFeedBack", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {

            RP_trgfeedback_VIEWDETAILS.Visible = false;
            Rp_TRGFEEDABCK_VIEWMAIN.Visible = true;
            Rm_TRGFEEDABCK_PAGE.SelectedIndex = 0;

            LoadGrid();
            Rg_TrgFeedback.DataBind();
            Rm_TRGFEEDABCK_PAGE.SelectedIndex = 0;


            //LoadGrid();
            //Rg_TrgFeedback.Visible = true;
            //Rm_TRGFEEDABCK_PAGE.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingFeedBack", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void QuestionRadListBox_ItemCheck(object sender, Telerik.Web.UI.RadListBoxItemEventArgs e)
    {
        try
        {

            RG_FeedBack.Visible = true;
            StringBuilder sb = new StringBuilder();
            IList<RadListBoxItem> collection = rlb_Quetions.CheckedItems;
            foreach (RadListBoxItem item in collection)
            {
                if (sb.Length == 0)
                {
                    sb.Append(item.Value);
                }
                else
                {
                    sb.Append("," + item.Value);
                }

            }
            Label1.Text = sb.ToString();
            if (Label1.Text == "")
            {
                _obj_SMHR_FEEDBACK_QUESTION.FEEDBACK_ID = Convert.ToString(0);
            }
            else
            {
                _obj_SMHR_FEEDBACK_QUESTION.FEEDBACK_ID = Convert.ToString(Label1.Text);
            }
            _obj_SMHR_FEEDBACK_QUESTION.OPERATION = operation.EMPTY1;
            DataTable dt = BLL.get_FeedbackQuestion(_obj_SMHR_FEEDBACK_QUESTION);
            RG_FeedBack.DataSource = dt;
            Session["datatable"] = dt;
            RG_FeedBack.DataBind();
            RG_FeedBack.Visible = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingFeedBack", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
       
     }

    protected void RG_FeedBack_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
      
    }
    protected void btn_assign_Click(object sender, EventArgs e)
    {
        try
        {
       
        //assign feedback to trainer of that trg
        if (rcmb_Type.SelectedItem.Text == "Trainer")
        {
            SMHR_ASSIGNFEEDBACK_EMPLOYEE _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE = new SMHR_ASSIGNFEEDBACK_EMPLOYEE();
           

            _obj_SMHR_TRAININGFEEDBACK_RESPONSE.OPERATION = operation.MODE1;
            _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_NAME = BLL.ReplaceQuote(Convert.ToString(rtxt_FeedbackName.Text));
            _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_BU_ID=Convert.ToInt32(rcmb_BU.SelectedItem.Value);
            _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_TR_ID = Convert.ToInt32(rcmb_TRName.SelectedItem.Value);
                 _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_CATEGORY = Convert.ToString(rcmb_Type.SelectedItem.Text);

                 DataTable dt5 = BLL.get_FeedbackResponse(_obj_SMHR_TRAININGFEEDBACK_RESPONSE);


           

            SMHR_TRAINER _obj_Smhr_Trner = new SMHR_TRAINER();
            _obj_Smhr_Trner.Mode = 5;
            _obj_Smhr_Trner.TRAINERDETAILS_TR_ID = Convert.ToInt32(rcmb_TRName.SelectedItem.Value);
            DataTable dt1 = BLL.get_TRAINer(_obj_Smhr_Trner);


            _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.Mode = 2;
            _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGNFEED_FEEBAK_ID = Convert.ToInt32(dt5.Rows[0]["FEEDBACK_ID"]);
            //if trg is external then inplace of trainer we are passing hr employeeid
            if (dt1.Rows.Count != 0)
            {
                _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGN_EMP_ID = Convert.ToInt32(dt1.Rows[0]["TRAINERDETAILS_EMPLOYEEID"]);
            }
            else
            {//IF TRAINER EXTERNAL WE HAVE TO GIVE HR ID

                _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();
                _obj_Smhr_TrgRqst.Mode = 21;
                _obj_Smhr_TrgRqst.TR_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable DT45 = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);
                if (DT45.Rows.Count != 0)
                {
                    _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGN_EMP_ID = 0;
                }

                else
                {
                    _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGN_EMP_ID = 0;
                }
            }

            DataTable dt2 = BLL.get__SMHR_ASSIGNFEEDBACK_EMPLOYEE(_obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE);
            if (dt2.Rows.Count != 0)
            {

                BLL.ShowMessage(this, "Tarining Already Assigned To Employee");
                return;
            }
            else
            {

                _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE = new SMHR_ASSIGNFEEDBACK_EMPLOYEE();
                _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.Mode = 3;
                _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGNFEED_FEEBAK_ID = Convert.ToInt32(dt5.Rows[0]["FEEDBACK_ID"]);
                if (dt1.Rows.Count !=0)
                {
                    _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGN_EMP_ID = Convert.ToInt32(dt1.Rows[0]["TRAINERDETAILS_EMPLOYEEID"]);
                }

                else
                {
                    _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();
                    _obj_Smhr_TrgRqst.Mode = 21;
                    _obj_Smhr_TrgRqst.TR_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable DT455 = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);
                    if (DT455.Rows.Count != 0)
                    {
                        _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGN_EMP_ID = 0;
                    }

                    else
                    {
                        _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGN_EMP_ID = 0;
                    }

                }
                _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGN_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGN_CREATEDDATE = DateTime.Now;
                bool status = BLL.set_SMHR_ASSIGNFEEDBACK_EMPLOYEE(_obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE);
                if (status == true)
                {
                    BLL.ShowMessage(this, "Feedback Assigned Successfully");
                    LoadGrid();
                    Rg_TrgFeedback.DataBind();
                    Rm_TRGFEEDABCK_PAGE.SelectedIndex = 0;
                    return;
                }

            }
           
           
        }
        else if (rcmb_Type.SelectedItem.Text == "Trainee")
        {

            SMHR_ASSIGNFEEDBACK_EMPLOYEE _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE = new SMHR_ASSIGNFEEDBACK_EMPLOYEE();

            _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.Mode = 6;
            _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGNFEED_FEEBAK_ID = Convert.ToInt32(lbl_id.Text);

            DataTable dttrnee = BLL.get__SMHR_ASSIGNFEEDBACK_EMPLOYEE(_obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE);

            if(dttrnee.Rows.Count !=0)
            {
                 BLL.ShowMessage(this, "Tarining Already Assigned To Trainee");
                return;

            }
            else
            {
            SMHR_TRAINEE _obj_Smhr_TrnEE = new SMHR_TRAINEE();
            _obj_Smhr_TrnEE.Mode = 5;
            _obj_Smhr_TrnEE.TRAINEE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_TrnEE.TRAINEE_TR_ID = Convert.ToInt32(rcmb_TRName.SelectedItem.Value);
            DataTable dtemp = BLL.get_TRAINEE(_obj_Smhr_TrnEE);
          //  for (int i = 0; i <= dtemp.Rows.Count ; i++)
          //  {
                foreach(DataRow item in dtemp.Rows)
                {
                _obj_SMHR_TRAININGFEEDBACK_RESPONSE.OPERATION = operation.MODE1;
                _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_BU_ID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
                _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_TR_ID = Convert.ToInt32(rcmb_TRName.SelectedItem.Value);
                _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_CATEGORY = Convert.ToString(rcmb_Type.SelectedItem.Text);
                _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_NAME = BLL.ReplaceQuote(Convert.ToString(rtxt_FeedbackName.Text));
                _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt5 = BLL.get_FeedbackResponse(_obj_SMHR_TRAININGFEEDBACK_RESPONSE);

               _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE = new SMHR_ASSIGNFEEDBACK_EMPLOYEE();
                _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.Mode = 3;

                _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGNFEED_FEEBAK_ID = Convert.ToInt32(dt5.Rows[0]["FEEDBACK_ID"]);
                _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGN_EMP_ID = Convert.ToInt32(item["TRAINEE_EMPID"]);
                _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGN_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGN_CREATEDDATE = DateTime.Now;
                bool status = BLL.set_SMHR_ASSIGNFEEDBACK_EMPLOYEE(_obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE);
                if (status == true)
                {
                    //BLL.ShowMessage(this, "Feedback Assigned Successfully");
                    //LoadGrid();
                    //Rm_TRGFEEDABCK_PAGE.SelectedIndex = 0;

                }
                //BLL.ShowMessage(this, "Feedback Assigned Successfully");
                LoadGrid();
                Rg_TrgFeedback.DataBind();

                    Rm_TRGFEEDABCK_PAGE.SelectedIndex = 0;
            }
            }
        }
         }
         catch (Exception ex)
         {
             SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingFeedBack", ex.StackTrace, DateTime.Now);
             Response.Redirect("~/Frm_ErrorPage.aspx");
         }
    }
}
