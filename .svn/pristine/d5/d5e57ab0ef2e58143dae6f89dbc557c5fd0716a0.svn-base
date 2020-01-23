using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using SPMS;
using Telerik.Web.UI;
using SMHR;
using SPMS;
public partial class Training_frm_SaveTrgfeedbackquestion : System.Web.UI.Page
{
   
    #region pageload methods
    /// <summary>
    /// page load methods
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        SMHR_TRAINER _obj_Smhr_Trner = new SMHR_TRAINER();
        SMHR_TRAINEE _obj_Smhr_TrnEE = new SMHR_TRAINEE();
        try
        {
            Page.Validate();
            if (!Page.IsPostBack)
            {
                #region pageload


                //_obj_Smhr_Trner.Mode = 10;
                //_obj_Smhr_Trner.TRAINERDETAILS_EMPLOYEEID = Convert.ToInt32(Session["EMP_ID"]);

                //DataTable dt1 = BLL.get_TRAINer(_obj_Smhr_Trner);
                //if (dt1.Rows.Count != 0)
                //{
                //    _obj_Smhr_Trner.Mode = 11;
                //    _obj_Smhr_Trner.TRAINERDETAILS_EMPLOYEEID = Convert.ToInt32(Session["EMP_ID"]);
                //    //_obj_Smhr_Trner.TRAINERDETAILS_EMPLOYEEID = 62;
                //    DataTable dttrg = BLL.get_TRAINer(_obj_Smhr_Trner);
                //    if (dttrg.Rows.Count != 0)
                //    {
                //        Rcmb_Trg.DataSource = dttrg;
                //        Rcmb_Trg.DataValueField = "TR_ID";
                //        Rcmb_Trg.DataTextField = "TR_TITLE";
                //        Rcmb_Trg.DataBind();
                //        Rcmb_Trg.Items.Insert(0, new RadComboBoxItem("Select"));
                //        Rg_SaveTrgFeedback.Visible = false;
                //        btn_save_trgfeedbacques.Visible = false;
                //    }
                //    else
                //    {
                //        DataTable dt22 = new DataTable();
                //        Rcmb_Trg.DataSource = dt22;
                //        Rcmb_Trg.DataBind();
                //        Rcmb_Trg.Items.Insert(0, new RadComboBoxItem("Select"));
                //        Rg_SaveTrgFeedback.Visible = false;
                //        btn_save_trgfeedbacques.Visible = false;
                //    }

                //}

                //else
                //{
                //    _obj_Smhr_TrnEE.Mode = 7;
                //    _obj_Smhr_TrnEE.TRAINEE_EMPID = Convert.ToInt32(Session["EMP_ID"]);

                //    DataTable dttrg1 = BLL.get_TRAINEE(_obj_Smhr_TrnEE);
                //    if (dttrg1.Rows.Count != 0)
                //    {
                //        Rcmb_Trg.DataSource = dttrg1;
                //        Rcmb_Trg.DataValueField = "TR_ID";
                //        Rcmb_Trg.DataTextField = "TR_TITLE";
                //        Rcmb_Trg.DataBind();
                //        Rcmb_Trg.Items.Insert(0, new RadComboBoxItem("Select"));
                //        Rg_SaveTrgFeedback.Visible = false;
                //        btn_save_trgfeedbacques.Visible = false;
                //    }
                //    else
                //    {
                //        DataTable dt22 = new DataTable();
                //        Rcmb_Trg.DataSource = dt22;
                //        Rcmb_Trg.DataBind();
                //        Rcmb_Trg.Items.Insert(0, new RadComboBoxItem("Select"));
                //        Rg_SaveTrgFeedback.Visible = false;
                //        btn_save_trgfeedbacques.Visible = false;
                //    }


                //}

                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("FEEDBACK");
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
                    lbl_starttime.Visible = false;
                    rtp_starttime.Visible = false;

                    lbl_endtime.Visible = false;
                    rtp_endtime.Visible = false;
                    Lbl_Trg.Visible = false;
                    Rcmb_Trg.Visible = false;

                    lbl_Employee.Visible = false;
                    Rcm_Employee.Visible = false;
                    expertise_id.Visible = false;
                    LBL_DATE.Visible = true;
                    rdtp_strtdate.Visible = true;
                    CHGEXPERTID.Visible = false;
                    Rg_SaveTrgFeedback.Visible = false;
                    btn_save_trgfeedbacques.Visible = false;

                }
                else
                {
                    lbl_starttime.Visible = false;
                    rtp_starttime.Visible = false;

                    lbl_endtime.Visible = false;
                    rtp_endtime.Visible = false;
                    Lbl_Trg.Visible = false;
                    Rcmb_Trg.Visible = false;

                    lbl_Employee.Visible = false;
                    Rcm_Employee.Visible = false;
                    expertise_id.Visible = false;
                    LBL_DATE.Visible = true;
                    rdtp_strtdate.Visible = true;
                    CHGEXPERTID.Visible = false;
                    Rg_SaveTrgFeedback.Visible = false;
                    btn_save_trgfeedbacques.Visible = false;
                }

                #endregion

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_SaveTrgfeedbackquestion", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }





    }

    #endregion

    #region training index changed
    /// <summary>
    /// when trg changed based if trainee trainer will come for trainer trainee will come
    /// </summary>
    /// <param name="o"></param>
    /// <param name="e"></param>
    protected void Rcmb_Trg_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {try
    {
        if (Rcmb_Trg.SelectedItem.Text != "Select")
        {

            SMHR_TRAINEE _obj_Smhr_TrnEE = new SMHR_TRAINEE();
            _obj_Smhr_TrnEE.Mode = 14;//YYY
            _obj_Smhr_TrnEE.TRAINEE_EMPID = Convert.ToInt32(Session["EMP_ID"]);
            _obj_Smhr_TrnEE.TRAINEE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtemp15 = BLL.get_TRAINEE(_obj_Smhr_TrnEE);
            //if employee is trainee then
            if (dtemp15.Rows.Count != 0)
            {
                SMHR_TRAINER _obj_Smhr_Trner = new SMHR_TRAINER();
                _obj_Smhr_Trner.TRAINERDETAILS_TR_ID = Convert.ToInt32(Rcmb_Trg.SelectedItem.Value);
                _obj_Smhr_Trner.Mode = 15;//YYY
                _obj_Smhr_Trner.TRAINERDETAILS_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                //if trg is internal trg then 
                DataTable dttrgexist = BLL.get_TRAINer(_obj_Smhr_Trner);
                if (Convert.ToInt32(dttrgexist.Rows[0]["emp_id"]) != 0)
                {
                    Rcm_Employee.DataSource = dttrgexist;
                    Rcm_Employee.DataValueField = "emp_id";
                    Rcm_Employee.DataTextField = "EMPLOYEE_NAME";
                    Rcm_Employee.DataBind();
                    Rcm_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
                }
                else
                {
                 _obj_Smhr_Trner = new SMHR_TRAINER();
                    _obj_Smhr_Trner.TRAINERDETAILS_TR_ID = Convert.ToInt32(Rcmb_Trg.SelectedItem.Value);
                    _obj_Smhr_Trner.Mode = 16;//YYY
                    _obj_Smhr_Trner.TRAINERDETAILS_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    //if trg of external trg
                    DataTable dttrgexist22 = BLL.get_TRAINer(_obj_Smhr_Trner);
                    if (dttrgexist22.Rows[0]["TRAINERDETAILS_EMPLOYEENAME"] != string.Empty)
                    {
                        Rcm_Employee.DataSource = dttrgexist22;
                        Rcm_Employee.DataValueField = "TRAINERDETAILS_EMPLOYEENAME";
                        Rcm_Employee.DataTextField = "TRAINERDETAILS_EMPLOYEENAME";
                        Rcm_Employee.DataBind();
                        Rcm_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
                    }
                    else
                    {//if trg of external trainer
                        Rcm_Employee.DataSource = dttrgexist22;
                        Rcm_Employee.DataValueField = "TRAINERDETAILS_CONTACTPERSON";
                        Rcm_Employee.DataTextField = "TRAINERDETAILS_CONTACTPERSON";
                        Rcm_Employee.DataBind();
                        Rcm_Employee.Items.Insert(0, new RadComboBoxItem("Select"));

                    }

                }
                lbl_Employee.Text = "Trainer :";
            }

            else
            {//loads trainee
              
                 SMHR_TRAININGREQUEST _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();
                _obj_Smhr_TrgRqst.Mode = 21;
                _obj_Smhr_TrgRqst.TR_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable DT455 = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);

                //
                SMHR_TRAINER _obj_Smhr_Trner = new SMHR_TRAINER();
                _obj_Smhr_Trner.TRAINERDETAILS_TR_ID = Convert.ToInt32(Rcmb_Trg.SelectedItem.Value);
                _obj_Smhr_Trner.Mode = 18;//YYY
                _obj_Smhr_Trner.TRAINERDETAILS_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dttrainer = BLL.get_TRAINer(_obj_Smhr_Trner);
              
                //if (Convert.ToInt32(DT455.Rows[0]["login_emp_id"]) == Convert.ToInt32(Session["EMP_ID"]) )
                //{//if hr logs in

                     if (Convert.ToInt32(Session["EMP_ID"]) != 0 )
                {
                    _obj_Smhr_TrnEE = new SMHR_TRAINEE();
                    _obj_Smhr_TrnEE.Mode = 5;
                    _obj_Smhr_TrnEE.TRAINEE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Smhr_TrnEE.TRAINEE_TR_ID = Convert.ToInt32(Rcmb_Trg.SelectedItem.Value);
                    DataTable dtemp1 = BLL.get_TRAINEE(_obj_Smhr_TrnEE);

                    Rcm_Employee.DataSource = dtemp1;
                    Rcm_Employee.DataValueField = "TRAINEE_EMPID";
                    Rcm_Employee.DataTextField = "EMPLOYEE_NAME";
                    Rcm_Employee.DataBind();
                    Rcm_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
                    lbl_Employee.Text = "Trainee :";
                }

            else  if (dttrainer.Rows.Count != 0)
                {//if internal trainer logs in
                    if (Convert.ToInt32(dttrainer.Rows[0]["TRAINERDETAILS_EMPLOYEEID"]) == Convert.ToInt32(Session["EMP_ID"]))
                    {
                        _obj_Smhr_TrnEE = new SMHR_TRAINEE();
                        _obj_Smhr_TrnEE.Mode = 5;
                        _obj_Smhr_TrnEE.TRAINEE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Smhr_TrnEE.TRAINEE_TR_ID = Convert.ToInt32(Rcmb_Trg.SelectedItem.Value);
                        DataTable dtemp1 = BLL.get_TRAINEE(_obj_Smhr_TrnEE);

                        Rcm_Employee.DataSource = dtemp1;
                        Rcm_Employee.DataValueField = "TRAINEE_EMPID";
                        Rcm_Employee.DataTextField = "EMPLOYEE_NAME";
                        Rcm_Employee.DataBind();
                        Rcm_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
                        lbl_Employee.Text = "Trainee :";
                    }
                }
                else
                {
                    BLL.ShowMessage(this, "No Trainee Under This User");
                    DataTable dt5 = new DataTable();

                    Rcm_Employee.DataSource = dt5;

                    Rcm_Employee.DataBind();
                    Rcm_Employee.Items.Insert(0, new RadComboBoxItem("Select"));


                }


           


            }
            lbl_starttime.Visible = true;
            rtp_starttime.Visible = true;
           
            lbl_endtime.Visible = true;
            rtp_endtime.Visible = true;
            Lbl_Trg.Visible = true;
            Rcmb_Trg.Visible = true;
            lbl_Employee.Visible = true;
            Rcm_Employee.Visible = true;
            expertise_id.Visible = false;

            CHGEXPERTID.Visible = false;

            //    SMHR_ASSIGNFEEDBACK_EMPLOYEE _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE = new SMHR_ASSIGNFEEDBACK_EMPLOYEE();

            //    _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.Mode = 5;
            //    _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGN_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);

            //    _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGN_CREATEDBY = Convert.ToInt32(Rcmb_Trg.SelectedItem.Value);
            //    //i am passing trg and employee to get feedback_id 
            //    DataTable dtfeedbackid = BLL.get__SMHR_ASSIGNFEEDBACK_EMPLOYEE(_obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE);
            //    if (dtfeedbackid.Rows.Count != 0)
            //    {
            //        SMHR_TRGFEEDBACKQUESDTLS _obj_Smhr_TRGFEEDBACKQUESDTLS = new SMHR_TRGFEEDBACKQUESDTLS();
            //        _obj_Smhr_TRGFEEDBACKQUESDTLS.Mode = 4;

            //        _obj_Smhr_TRGFEEDBACKQUESDTLS.TRFDBDTL_FDBID = Convert.ToInt32(dtfeedbackid.Rows[0]["FEEDBACK_ID"]);
            //        DataTable dtques = BLL.get_TRGFEEDBAKQUESTDTLS(_obj_Smhr_TRGFEEDBACKQUESDTLS);
            //        if (dtques.Rows.Count != 0)
            //        {
            //            Rg_SaveTrgFeedback.DataSource = dtques;
            //            Rg_SaveTrgFeedback.DataBind();
            //            Rg_SaveTrgFeedback.Visible = true;
            //            btn_save_trgfeedbacques.Visible = true;

            //        }
            //        else
            //        {
            //            DataTable dt5 = new DataTable();
            //            Rg_SaveTrgFeedback.DataSource = dt5;
            //            Rg_SaveTrgFeedback.DataBind();
            //            Rg_SaveTrgFeedback.Visible = true;
            //            btn_save_trgfeedbacques.Visible = false;
            //            return;
            //        }



            //    }
            //    else
            //    {

            //        DataTable dt4 = new DataTable();
            //        Rg_SaveTrgFeedback.DataSource = dt4;
            //        Rg_SaveTrgFeedback.DataBind();
            //        Rg_SaveTrgFeedback.Visible = true;
            //        btn_save_trgfeedbacques.Visible = false;
            //    }

            //}

            //else
            //{
            //    BLL.ShowMessage(this, "Please Select Training");
            //    DataTable dt9 = new DataTable();
            //    Rg_SaveTrgFeedback.DataSource = dt9;
            //    Rg_SaveTrgFeedback.DataBind();
            //    Rg_SaveTrgFeedback.Visible = true;
            //    btn_save_trgfeedbacques.Visible = false;
            //    return;
            //}



        }
        else
        {
            BLL.ShowMessage(this, "Please Select Training");
            lbl_starttime.Visible = true;
            rtp_starttime.Visible = true;

            lbl_endtime.Visible = true;
            rtp_endtime.Visible = true;
            Lbl_Trg.Visible = true;
            Rcmb_Trg.Visible = true;
            lbl_Employee.Visible = false;
            Rcm_Employee.Visible = false;
            expertise_id.Visible = false;

            CHGEXPERTID.Visible = false;
            Rg_SaveTrgFeedback.Visible = false;
        }


         }
         catch (Exception ex)
         {
             SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_SaveTrgfeedbackquestion", ex.StackTrace, DateTime.Now);
             Response.Redirect("~/Frm_ErrorPage.aspx");
         }
    }

    #endregion
    #region saving feedback questions
    /// <summary>
    /// save feedback methods
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>

    protected void btn_save_trgfeedbacques_Click(object sender, EventArgs e)
     {try
     {
         SMHR_TrgSaveFeedback _obj_Smhr_TrgSaveFeedback = new SMHR_TrgSaveFeedback();
        //_obj_Smhr_TrgSaveFeedback.Mode = 4;
        //_obj_Smhr_TrgSaveFeedback.SAVEFEEDBACK_TR_ID = Convert.ToInt32(Rcmb_Trg.SelectedItem.Value);
        //_obj_Smhr_TrgSaveFeedback.SAVEFEEDBACK_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
     
        //DataTable dtstatus = BLL.get_TrgSaveFeedback(_obj_Smhr_TrgSaveFeedback);
        //if (dtstatus.Rows.Count != 0)
        //{
        //    BLL.ShowMessage(this, "Alraedy Feedback Given");
        //    DataTable dt9 = new DataTable();
        //    Rg_SaveTrgFeedback.DataSource = dt9;
        //    Rg_SaveTrgFeedback.DataBind();
        //    Rg_SaveTrgFeedback.Visible = true;
        //    btn_save_trgfeedbacques.Visible = false;
        //    return;

           

           

        //}

        //else
        //{
         if ((rcm_changeExpertise.SelectedItem.Text == "Select")&(chk_nograde.Checked==false)& (chk_nograde.Visible==true))
         {
             BLL.ShowMessage(this, "Select Expertise");
             return;
         }
             Label lblfeedbackid = new Label();
            Label lblfeedbackquestion = new Label();
            RadioButton rdopt1 = new RadioButton();
            RadioButton rdopt2 = new RadioButton();
            RadioButton rdopt3 = new RadioButton();
            RadioButton rdopt4 = new RadioButton();
            for (int a = 0; a < Rg_SaveTrgFeedback.Items.Count; a++)
            {
                lblfeedbackid = Rg_SaveTrgFeedback.Items[a].FindControl("lbl_feedbk_id") as Label;
                lblfeedbackquestion = Rg_SaveTrgFeedback.Items[a].FindControl("lbl_feedbk_question") as Label;
                rdopt1 = Rg_SaveTrgFeedback.Items[a].FindControl("rd_feedbkoption1") as RadioButton;
                rdopt2 = Rg_SaveTrgFeedback.Items[a].FindControl("rd_feedbkoption2") as RadioButton;
                rdopt3 = Rg_SaveTrgFeedback.Items[a].FindControl("rd_feedbkoption3") as RadioButton;
                rdopt4 = Rg_SaveTrgFeedback.Items[a].FindControl("rd_feedbkoption4") as RadioButton;




                _obj_Smhr_TrgSaveFeedback.Mode = 3;
                _obj_Smhr_TrgSaveFeedback.SAVEFEEDBACK_TR_ID = Convert.ToInt32(Rcmb_Trg.SelectedItem.Value);
                _obj_Smhr_TrgSaveFeedback.SAVEFEEDBACK_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
              
                _obj_Smhr_TrgSaveFeedback.SAVEFEEDBACK_FEEDBACKQUESTS_ID = Convert.ToInt32(lblfeedbackid.Text);
                _obj_Smhr_TrgSaveFeedback.SAVEFEEDBACK_FEEDBACKQUESTION = Convert.ToString(lblfeedbackquestion.Text);

                if (rdopt1.Checked == true)
                {
                    _obj_Smhr_TrgSaveFeedback.SAVEFEEDBACK_FEEDBACKQUESTS_OPTION1 = Convert.ToString(rdopt1.Text);
                }
                else
                {
                    _obj_Smhr_TrgSaveFeedback.SAVEFEEDBACK_FEEDBACKQUESTS_OPTION1 = string.Empty;

                }
                if (rdopt2.Checked == true)
                {
                    _obj_Smhr_TrgSaveFeedback.SAVEFEEDBACK_FEEDBACKQUESTS_OPTION2 = Convert.ToString(rdopt2.Text);
                }
                else
                {
                    _obj_Smhr_TrgSaveFeedback.SAVEFEEDBACK_FEEDBACKQUESTS_OPTION2 = string.Empty;

                }
                if (rdopt3.Checked == true)
                {
                    _obj_Smhr_TrgSaveFeedback.SAVEFEEDBACK_FEEDBACKQUESTS_OPTION3 = Convert.ToString(rdopt3.Text);
                }
                else
                {
                    _obj_Smhr_TrgSaveFeedback.SAVEFEEDBACK_FEEDBACKQUESTS_OPTION3 = string.Empty;

                }

                if (rdopt4.Checked == true)
                {
                    _obj_Smhr_TrgSaveFeedback.SAVEFEEDBACK_FEEDBACKQUESTS_OPTION4 = Convert.ToString(rdopt4.Text);
                }
                else
                {
                    _obj_Smhr_TrgSaveFeedback.SAVEFEEDBACK_FEEDBACKQUESTS_OPTION4 = string.Empty;

                }

                //_obj_Smhr_TrgSaveFeedback.SAVEFEEDBACK_FEEDBACKQUESTS_OPTION2 = Convert.ToBoolean(rdopt2.Text);
                //_obj_Smhr_TrgSaveFeedback.SAVEFEEDBACK_FEEDBACKQUESTS_OPTION3 = Convert.ToBoolean(rdopt3.Text);
                //_obj_Smhr_TrgSaveFeedback.SAVEFEEDBACK_FEEDBACKQUESTS_OPTION4 = Convert.ToBoolean(rdopt4.Text);


                _obj_Smhr_TrgSaveFeedback.SAVEFEEDBACK_EMPLOYEE_ID_for = Convert.ToString(Rcm_Employee.SelectedItem.Value);

                _obj_Smhr_TrgSaveFeedback.SAVEFEEDBACK_DATE = Convert.ToDateTime(rdtp_strtdate.SelectedDate);
                _obj_Smhr_TrgSaveFeedback.SAVEFEEDBACK_ENDTIME =Convert.ToString(Convert.ToDateTime(rtp_endtime.SelectedDate).TimeOfDay);
                _obj_Smhr_TrgSaveFeedback.SAVEFEEDBACK_STARTTIME = Convert.ToString(Convert.ToDateTime(rtp_starttime.SelectedDate).TimeOfDay);
                _obj_Smhr_TrgSaveFeedback.SAVEFEEDBACK_STATUS = 1;
                _obj_Smhr_TrgSaveFeedback.SAVEFEEDBACK_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_Smhr_TrgSaveFeedback.SAVEFEEDBACK_CREATEDDATE = DateTime.Now;
                bool status = BLL.set_TrgSaveFeedback(_obj_Smhr_TrgSaveFeedback);
                if (status == true)
                {
                    BLL.ShowMessage(this, "Feedback Saved Successfully");
                   
                   


                }
}
            if (chk_nograde.Checked == false)
            {

                SMHR_TRAINEE _obj_Smhr_TrnEE = new SMHR_TRAINEE();
                _obj_Smhr_TrnEE.Mode = 14;
                _obj_Smhr_TrnEE.TRAINEE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_TrnEE.TRAINEE_EMPID = Convert.ToInt32(Session["EMP_ID"]);
                DataTable dtemp15 = BLL.get_TRAINEE(_obj_Smhr_TrnEE);
                if (dtemp15.Rows.Count != 0)
                {
                }
                else
                {
                    SMHR_TRAININGREQUEST _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();
                    _obj_Smhr_TrgRqst.Mode = 29;//YYY
                    _obj_Smhr_TrgRqst.TR_ID = Convert.ToInt32(Rcmb_Trg.SelectedItem.Value);
                    _obj_Smhr_TrgRqst.TR_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtmultiid = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);

                    _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();
                    _obj_Smhr_TrgRqst.Mode = 18;//YYY
                    _obj_Smhr_TrgRqst.TR_LASTMDFBY = Convert.ToInt32(Rcm_Employee.SelectedItem.Value);
                    _obj_Smhr_TrgRqst.TR_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtapplicantid = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);
                    if (dtapplicantid.Rows.Count != 0)
                    {
                        _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();
                        _obj_Smhr_TrgRqst.Mode = 27;

                        //_obj_Smhr_TrgRqst.TR_LASTMDFBY = Convert.ToInt32(rcm_changeExpertise.SelectedItem.Value);
                        //_obj_Smhr_TrgRqst.TR_ID = Convert.ToInt32(dtapplicantid.Rows[0]["emp_applicant_id"]);
                        _obj_Smhr_TrgRqst.TR_ID = Convert.ToInt32(Rcmb_Trg.SelectedItem.Value);//trg
                        _obj_Smhr_TrgRqst.TR_LASTMDFBY = Convert.ToInt32(dtapplicantid.Rows[0]["emp_applicant_id"]);//applicant
                        if (dtmultiid.Rows.Count != 0)
                        {
                            _obj_Smhr_TrgRqst.TR_DESCRIPTION = Convert.ToString(dtmultiid.Rows[0]["course_skill_wid"]);//skillmulti
                        }

                        else
                        {
                            _obj_Smhr_TrgRqst.TR_DESCRIPTION = "0";
                        }
                        _obj_Smhr_TrgRqst.LASTMDFBY = Convert.ToInt32(rcm_changeExpertise.SelectedItem.Value);//expert
                        _obj_Smhr_TrgRqst.TR_CREATEDBY = Convert.ToInt32(Session["user_id"]);
                        _obj_Smhr_TrgRqst.TR_CREATEDDATE = DateTime.Now;
                        _obj_Smhr_TrgRqst.TR_ORG_ID = Convert.ToInt32(Session["org_id"]);


                        bool stat = BLL.set_TrgRqst(_obj_Smhr_TrgRqst);
                        BLL.ShowMessage(this, "Skills Have Been Updated");

                    }

                }
            }

            else
            {

            }


            lbl_starttime.Visible = false;
            rtp_starttime.Visible = false;

            lbl_endtime.Visible = false;
            rtp_endtime.Visible = false;
            Lbl_Trg.Visible = false;
            Rcmb_Trg.Visible = false;
            nogradeid.Visible = false;
            lbl_Employee.Visible = false;
            Rcm_Employee.Visible = false;
            expertise_id.Visible = false;
            LBL_DATE.Visible = true;
            rdtp_strtdate.Visible = true;
            CHGEXPERTID.Visible = false;
            Rg_SaveTrgFeedback.Visible = false;
            rdtp_strtdate.SelectedDate = null;
            btn_save_trgfeedbacques.Visible = false;
        

         }
         catch (Exception ex)
         {
             SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_SaveTrgfeedbackquestion", ex.StackTrace, DateTime.Now);
             Response.Redirect("~/Frm_ErrorPage.aspx");
         }
     }
    #endregion

    #region date index changed
    /// <summary>
    /// date selected index changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rdtp_strtdate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {try
    {
        if (rdtp_strtdate.SelectedDate != null)
        {
            DataTable dt = new DataTable();
            Rcmb_Trg.DataSource = dt;
            Rcmb_Trg.DataBind();
            rtp_starttime.SelectedDate=null;
            rtp_endtime.SelectedDate = null;
            lbl_starttime.Visible = true;
            rtp_starttime.Visible = true;
            nogradeid.Visible = false;
            lbl_endtime.Visible = true;
            rtp_endtime.Visible = true;
            Lbl_Trg.Visible = true;
            Rcmb_Trg.Visible = true;
            lbl_Employee.Visible = false;
            Rcm_Employee.Visible = false;
            expertise_id.Visible = false;
            Rg_SaveTrgFeedback.Visible=false;
          
            Rcmb_Trg.SelectedIndex = -1;
            CHGEXPERTID.Visible = false;
             SMHR_TRAINEE _obj_Smhr_TrnEE = new SMHR_TRAINEE();
            _obj_Smhr_TrnEE.Mode = 14;
            _obj_Smhr_TrnEE.TRAINEE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_TrnEE.TRAINEE_EMPID = Convert.ToInt32(Session["EMP_ID"]);
            DataTable dtemp15 = BLL.get_TRAINEE(_obj_Smhr_TrnEE);
            SMHR_TRAININGSCHEDULE _obj_Smhr_TRAININGSCHEDULE = new SMHR_TRAININGSCHEDULE();
            SMHR_TRAININGREQUEST _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();
            _obj_Smhr_TrgRqst.Mode = 21;
            _obj_Smhr_TrgRqst.TR_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT455 = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);
            _obj_Smhr_TRAININGSCHEDULE.Mode = 9;//YYY
            for (int i = 0; i < DT455.Rows.Count; i++)
            {
                if ((Convert.ToInt32(DT455.Rows[i]["login_emp_id"]) == Convert.ToInt32(Session["EMP_ID"])))
                {
                    _obj_Smhr_TRAININGSCHEDULE.TS_PARAM1 = 0;
                    break;
                }
                else
                {
                    _obj_Smhr_TRAININGSCHEDULE.TS_PARAM1 = Convert.ToInt32(Session["EMP_ID"]);

                }
            }
            
            _obj_Smhr_TRAININGSCHEDULE.TS_LASTMDFDATE = Convert.ToDateTime(rdtp_strtdate.SelectedDate);
            _obj_Smhr_TRAININGSCHEDULE.TS_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dttime = BLL.get_TRAININGSCHEDULE(_obj_Smhr_TRAININGSCHEDULE);

            if (dttime.Rows.Count != 0)
            {
                //here based on date i am getting training,starttime,endtime
                rtp_starttime.SelectedDate = Convert.ToDateTime(dttime.Rows[0]["SESSION_STARTTIME"]);

                rtp_endtime.SelectedDate = Convert.ToDateTime(dttime.Rows[0]["SESSION_ENDTIME"]);
                Rcmb_Trg.DataSource = dttime;
                Rcmb_Trg.DataValueField = "TR_ID";
                Rcmb_Trg.DataTextField = "TR_TITLE";
                Rcmb_Trg.DataBind();
                Rcmb_Trg.Items.Insert(0, new RadComboBoxItem("Select"));
            }

            else
            {
                BLL.ShowMessage(this, "No Training Exists On This Date");
            }

        }
        else
        {
            BLL.ShowMessage(this, "Please Select Date");

            lbl_starttime.Visible = false;
            rtp_starttime.Visible = false;

            lbl_endtime.Visible = false;
            rtp_endtime.Visible = false;
            Lbl_Trg.Visible = false;
            Rcmb_Trg.Visible = false;

            lbl_Employee.Visible = false;
            Rcm_Employee.Visible = false;
            expertise_id.Visible = false;
            Rg_SaveTrgFeedback.Visible = false;
            CHGEXPERTID.Visible = false;
        }
           }
         catch (Exception ex)
         {
             SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_SaveTrgfeedbackquestion", ex.StackTrace, DateTime.Now);
             Response.Redirect("~/Frm_ErrorPage.aspx");
         }
    }
    #endregion

    #region employee select index changed
    /// <summary>
    /// 
    /// </summary>
    /// <param name="o"></param>
    /// <param name="e"></param>
    protected void Rcm_Employee_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {try
    {
        if (Rcm_Employee.SelectedItem.Text != "Select")
        {
             SMHR_TrgSaveFeedback _obj_Smhr_TrgSaveFeedback = new SMHR_TrgSaveFeedback();
        _obj_Smhr_TrgSaveFeedback.Mode = 4;
        _obj_Smhr_TrgSaveFeedback.SAVEFEEDBACK_TR_ID = Convert.ToInt32(Rcmb_Trg.SelectedItem.Value);
        _obj_Smhr_TrgSaveFeedback.SAVEFEEDBACK_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
        _obj_Smhr_TrgSaveFeedback.SAVEFEEDBACK_DATE = Convert.ToDateTime(rdtp_strtdate.SelectedDate);
        _obj_Smhr_TrgSaveFeedback.SAVEFEEDBACK_EMPLOYEE_ID_for = Convert.ToString(Rcm_Employee.SelectedItem.Value);

        DataTable dtstatus = BLL.get_TrgSaveFeedback(_obj_Smhr_TrgSaveFeedback);
        if (dtstatus.Rows.Count != 0)
        {

            BLL.ShowMessage(this, "Alraedy Feedback Given");
          
            btn_save_trgfeedbacques.Visible = false;
            lbl_starttime.Visible = true;
            rtp_starttime.Visible = true;

            lbl_endtime.Visible = true;
            rtp_endtime.Visible = true;
            Lbl_Trg.Visible = true;
            Rcmb_Trg.Visible = true;

            lbl_Employee.Visible = true;
            Rcm_Employee.Visible = true;
            expertise_id.Visible = true;

            CHGEXPERTID.Visible = false;
           
            Rg_SaveTrgFeedback.Visible = true;
            SMHR_TRAINEE _obj_Smhr_TrnEE = new SMHR_TRAINEE();
            _obj_Smhr_TrnEE.Mode = 14;
            _obj_Smhr_TrnEE.TRAINEE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_TrnEE.TRAINEE_EMPID = Convert.ToInt32(Session["EMP_ID"]);
            DataTable dtemp15 = BLL.get_TRAINEE(_obj_Smhr_TrnEE);
            //if employee is trainee then
            if (dtemp15.Rows.Count != 0)
            {
                expertise_id.Visible = false;
                CHGEXPERTID.Visible = false;
            }
            else
            {

                // SMHR_TRAINEE _obj_Smhr_TrnEE = new SMHR_TRAINEE();
                _obj_Smhr_TrnEE.Mode = 12;//YYY
                _obj_Smhr_TrnEE.TRAINEE_EMPID = Convert.ToInt32(Rcm_Employee.SelectedItem.Value);
                _obj_Smhr_TrnEE.TRAINEE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtemp1 = BLL.get_TRAINEE(_obj_Smhr_TrnEE);
                if (dtemp1.Rows[0]["APPSKL_EXPERT"] != System.DBNull.Value)
                {
                    if (Convert.ToInt32(dtemp1.Rows[0]["APPSKL_EXPERT"]) == 1)
                    {
                        lbl_Expert.Text = "Beginner";
                    }
                    else if (Convert.ToInt32(dtemp1.Rows[0]["APPSKL_EXPERT"]) == 2)
                    {
                        lbl_Expert.Text = "Intermediate";
                    }
                    else if (Convert.ToInt32(dtemp1.Rows[0]["APPSKL_EXPERT"]) == 3)
                    {
                        lbl_Expert.Text = "Expert";
                    }
                }
                else
                {
                    lbl_Expert.Text = "Skill Not Given";
                }
            }
            
            _obj_Smhr_TrgSaveFeedback.Mode = 5;
            _obj_Smhr_TrgSaveFeedback.SAVEFEEDBACK_TR_ID = Convert.ToInt32(Rcmb_Trg.SelectedItem.Value);
         
            _obj_Smhr_TrgSaveFeedback.SAVEFEEDBACK_DATE = Convert.ToDateTime(rdtp_strtdate.SelectedDate);
            _obj_Smhr_TrgSaveFeedback.SAVEFEEDBACK_EMPLOYEE_ID_for = Convert.ToString(Rcm_Employee.SelectedItem.Value);

            DataTable dtstatus22 = BLL.get_TrgSaveFeedback(_obj_Smhr_TrgSaveFeedback);
            Rg_SaveTrgFeedback.DataSource = dtstatus22;
            Rg_SaveTrgFeedback.DataBind();
            
             RadioButton rdopt1 = new RadioButton();
            RadioButton rdopt2 = new RadioButton();
            RadioButton rdopt3 = new RadioButton();
            RadioButton rdopt4 = new RadioButton();
            for (int a = 0; a < Rg_SaveTrgFeedback.Items.Count; a++)
            {
                rdopt1 = Rg_SaveTrgFeedback.Items[a].FindControl("rd_feedbkoption1") as RadioButton;
                rdopt2 = Rg_SaveTrgFeedback.Items[a].FindControl("rd_feedbkoption2") as RadioButton;
                rdopt3 = Rg_SaveTrgFeedback.Items[a].FindControl("rd_feedbkoption3") as RadioButton;
                rdopt4 = Rg_SaveTrgFeedback.Items[a].FindControl("rd_feedbkoption4") as RadioButton;
                if (rdopt1.Text !="")
                {
                    rdopt1.Checked = true;
                }
                if (rdopt2.Text != "")
                {
                    rdopt2.Checked = true;
                }
                if (rdopt3.Text != "")
                {
                    rdopt3.Checked = true;
                }
                if (rdopt4.Text != "")
                {
                    rdopt4.Checked = true;
                }
                if (Convert.ToString(dtstatus22.Rows[a]["FEEDBACKQUESTS_OPTION1"]) == string.Empty)
                {
                    rdopt1.Text = string.Empty;
                }

                else if (Convert.ToString(dtstatus22.Rows[a]["FEEDBACKQUESTS_OPTION1"]) != string.Empty)
                {
                    rdopt1.Text = Convert.ToString(dtstatus22.Rows[a]["FEEDBACKQUESTS_OPTION1"]);
                }


                if (Convert.ToString(dtstatus22.Rows[a]["FEEDBACKQUESTS_OPTION2"]) == string.Empty)
                {
                    rdopt2.Text = string.Empty;
                }

                else if (Convert.ToString(dtstatus22.Rows[a]["FEEDBACKQUESTS_OPTION2"]) != string.Empty)
                {
                    rdopt2.Text = Convert.ToString(dtstatus22.Rows[a]["FEEDBACKQUESTS_OPTION2"]);
                }


                if (Convert.ToString(dtstatus22.Rows[a]["FEEDBACKQUESTS_OPTION3"]) == string.Empty)
                {
                    rdopt3.Text = string.Empty;
                }

                else if (Convert.ToString(dtstatus22.Rows[a]["FEEDBACKQUESTS_OPTION3"]) != string.Empty)
                {
                    rdopt3.Text = Convert.ToString(dtstatus22.Rows[a]["FEEDBACKQUESTS_OPTION3"]);
                }


                if (Convert.ToString(dtstatus22.Rows[a]["FEEDBACKQUESTS_OPTION4"]) == string.Empty)
                {
                    rdopt4.Text = string.Empty;
                }

                else if (Convert.ToString(dtstatus22.Rows[a]["FEEDBACKQUESTS_OPTION4"]) != string.Empty)
                {
                    rdopt4.Text = Convert.ToString(dtstatus22.Rows[a]["FEEDBACKQUESTS_OPTION4"]);
                }


                //if (Convert.ToInt32(dtstatus22.Rows[a]["FEEDBACKQUESTS_OPTION2"]) == 0)
                //{
                //    rdopt2.Checked = false;
                //}

                //else if (Convert.ToInt32(dtstatus22.Rows[a]["FEEDBACKQUESTS_OPTION2"]) == 1)
                //{
                //    rdopt2.Checked = true;
                //}
                //if (Convert.ToInt32(dtstatus22.Rows[a]["FEEDBACKQUESTS_OPTION3"]) == 0)
                //{
                //    rdopt3.Checked = false;
                //}

                //else if (Convert.ToInt32(dtstatus22.Rows[a]["FEEDBACKQUESTS_OPTION3"]) == 1)
                //{
                //    rdopt3.Checked = true;
                //}
                //if (Convert.ToInt32(dtstatus22.Rows[a]["FEEDBACKQUESTS_OPTION4"]) == 0)
                //{
                //    rdopt4.Checked = false;
                //}

                //else if (Convert.ToInt32(dtstatus22.Rows[a]["FEEDBACKQUESTS_OPTION4"]) == 1)
                //{
                //    rdopt4.Checked = true;
                //}

            }


            return;
        }
        else
        {
              SMHR_TRAINEE _obj_Smhr_TrnEE = new SMHR_TRAINEE();
            _obj_Smhr_TrnEE.Mode = 14;
            _obj_Smhr_TrnEE.TRAINEE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_TrnEE.TRAINEE_EMPID = Convert.ToInt32(Session["EMP_ID"]);
            DataTable dtemp15 = BLL.get_TRAINEE(_obj_Smhr_TrnEE);
            //if employee is trainee then
            if (dtemp15.Rows.Count != 0)
            {
                expertise_id.Visible = false;
                CHGEXPERTID.Visible = false;

            }
            else
            {
                //Rcmb_Trg.Items.Insert(0, new RadComboBoxItem("Select"));
              _obj_Smhr_TrnEE = new SMHR_TRAINEE();
                _obj_Smhr_TrnEE.Mode = 12;//YYY
                _obj_Smhr_TrnEE.TRAINEE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_TrnEE.TRAINEE_EMPID = Convert.ToInt32(Rcm_Employee.SelectedItem.Value);
                DataTable dtemp1 = BLL.get_TRAINEE(_obj_Smhr_TrnEE);
                if (dtemp1.Rows[0]["APPSKL_EXPERT"] != System.DBNull.Value)
                {

                    if (Convert.ToInt32(dtemp1.Rows[0]["APPSKL_EXPERT"]) == 1)
                    {
                        lbl_Expert.Text = "Beginner";
                    }
                    else if (Convert.ToInt32(dtemp1.Rows[0]["APPSKL_EXPERT"]) == 2)
                    {
                        lbl_Expert.Text = "Intermediate";
                    }
                    else if (Convert.ToInt32(dtemp1.Rows[0]["APPSKL_EXPERT"]) == 3)
                    {
                        lbl_Expert.Text = "Expert";
                    }
                }
                else
                {
                    lbl_Expert.Text = "Skill Not Given";
                }
                expertise_id.Visible = true;

                CHGEXPERTID.Visible = true;
                nogradeid.Visible = true;
            }
            SMHR_ASSIGNFEEDBACK_EMPLOYEE _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE = new SMHR_ASSIGNFEEDBACK_EMPLOYEE();

            _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.Mode = 5;
            SMHR_TRAININGREQUEST _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();
            _obj_Smhr_TrgRqst.Mode = 21;
            _obj_Smhr_TrgRqst.TR_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT455 = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);
            for (int i = 0; i < DT455.Rows.Count; i++)
            {
                if ((Convert.ToInt32(DT455.Rows[i]["login_emp_id"]) == Convert.ToInt32(Session["EMP_ID"])))
                {
                    _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGN_EMP_ID = 0;
                    break;

                }
               

                else
                {


                    _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGN_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                }
            }
            

            _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGN_CREATEDBY = Convert.ToInt32(Rcmb_Trg.SelectedItem.Value);
            //i am passing trg and employee to get feedback_id 
            DataTable dtfeedbackid = BLL.get__SMHR_ASSIGNFEEDBACK_EMPLOYEE(_obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE);
            if (dtfeedbackid.Rows.Count != 0)
            {
                SMHR_TRGFEEDBACKQUESDTLS _obj_Smhr_TRGFEEDBACKQUESDTLS = new SMHR_TRGFEEDBACKQUESDTLS();
                _obj_Smhr_TRGFEEDBACKQUESDTLS.Mode = 4;

                _obj_Smhr_TRGFEEDBACKQUESDTLS.TRFDBDTL_FDBID = Convert.ToInt32(dtfeedbackid.Rows[0]["FEEDBACK_ID"]);
                DataTable dtques = BLL.get_TRGFEEDBAKQUESTDTLS(_obj_Smhr_TRGFEEDBACKQUESDTLS);
                if (dtques.Rows.Count != 0) 
                {
                    Rg_SaveTrgFeedback.DataSource = dtques;
                    Rg_SaveTrgFeedback.DataBind();
                    Rg_SaveTrgFeedback.Visible = true;
                    btn_save_trgfeedbacques.Visible = true;

                }
                else
                {
                    DataTable dt5 = new DataTable();
                    Rg_SaveTrgFeedback.DataSource = dt5;
                    Rg_SaveTrgFeedback.DataBind();
                    Rg_SaveTrgFeedback.Visible = true;
                    btn_save_trgfeedbacques.Visible = false;
                    return;
                }
                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    btn_save_trgfeedbacques.Visible = false;

                }



            }
            else
            {

                DataTable dt4 = new DataTable();
                Rg_SaveTrgFeedback.DataSource = dt4;
                Rg_SaveTrgFeedback.DataBind();
                Rg_SaveTrgFeedback.Visible = true;
                btn_save_trgfeedbacques.Visible = false;
            }




            lbl_starttime.Visible = true;
            rtp_starttime.Visible = true;

            lbl_endtime.Visible = true;
            rtp_endtime.Visible = true;
            Lbl_Trg.Visible = true;
            Rcmb_Trg.Visible = true;

            lbl_Employee.Visible = true;
            Rcm_Employee.Visible = true;
           
        }

        }
        else
        {
            BLL.ShowMessage(this, "Please Select Emoployee");

            lbl_starttime.Visible = true;
            rtp_starttime.Visible = true;

            lbl_endtime.Visible = true;
            rtp_endtime.Visible = true;
            Lbl_Trg.Visible = true;
            Rcmb_Trg.Visible = true;

            lbl_Employee.Visible = true;
            Rcm_Employee.Visible = true;
            expertise_id.Visible = false;
                

            CHGEXPERTID.Visible = false;
            Rg_SaveTrgFeedback.Visible = false;
            btn_save_trgfeedbacques.Visible = false;
        }


         }
         catch (Exception ex)
         {
             SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_SaveTrgfeedbackquestion", ex.StackTrace, DateTime.Now);
             Response.Redirect("~/Frm_ErrorPage.aspx");
         }
    }

    #endregion


   
    
}
