using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Data;
using Telerik.Web.UI;
using SPMS;
public partial class Training_frm_trainingattendancedtls : System.Web.UI.Page
{
    #region page load
    /// <summary>
    /// page load methos
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        try
    {
        if (!Page.IsPostBack)
        {  
            loadBusinessUnit();
            rgd_AttDtls_Emp.Visible = false;
            lbl_AttDtls_Training.Visible = false;
            rcmb_Attdtls_Training.Visible = false;
            lbl_AttDtls_AttDt.Visible = false;
            rdtp_AttDtls_AttDt.Visible = false;
           Page.Validate();


           Session.Remove("WRITEFACILITY");

           SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

           _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
           _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
           _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
           _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("TRAINING ATTENDANCE DETAILS");
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

               rcmb_Attdtls_BU.Enabled = false;

           }
           else
           {
               rcmb_Attdtls_BU.Enabled = true;
           }
        }

         }
         catch (Exception ex)
         {
             SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_trainingattendancedtls", ex.StackTrace, DateTime.Now);
             Response.Redirect("~/Frm_ErrorPage.aspx");
         }
    }

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }
    #endregion

    #region load business unit
    /// <summary>
    /// loading business unit details
    /// </summary>
    protected void loadBusinessUnit()
    {
        try

    {
        rcmb_Attdtls_BU.Items.Clear();
        SMHR_BUSINESSUNIT _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();


        SMHR_LOGININFO _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
        _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
        _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
        DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
        if (dt_BUDetails.Rows.Count != 0)
        {
            rcmb_Attdtls_BU.DataSource = dt_BUDetails;
            rcmb_Attdtls_BU.DataValueField = "BUSINESSUNIT_ID";
            rcmb_Attdtls_BU.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_Attdtls_BU.DataBind();
            rcmb_Attdtls_BU.Items.Insert(0, new RadComboBoxItem("Select"));
        }

        else
        {
            DataTable dt_Details = new DataTable();
            rcmb_Attdtls_BU.DataSource = dt_BUDetails;

            rcmb_Attdtls_BU.DataBind();
            rcmb_Attdtls_BU.Items.Insert(0, new RadComboBoxItem("Select"));
        }

          


        }
         catch (Exception ex)
         {
             SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_trainingattendancedtls", ex.StackTrace, DateTime.Now);
             Response.Redirect("~/Frm_ErrorPage.aspx");
         }

    }
    #endregion

    #region load employee

    protected void loadEmployees()
    {
        try
    {
       
        if (rdtp_AttDtls_AttDt.SelectedDate <= DateTime.Now)
        {
            SMHR_TRAININGREQUEST _obj_Smhr_TrgRqst;
            _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();

            _obj_Smhr_TrgRqst.Mode = 24;
            _obj_Smhr_TrgRqst.TR_LASTMDFDATE = Convert.ToDateTime(rdtp_AttDtls_AttDt.SelectedDate);
            _obj_Smhr_TrgRqst.TR_CREATEDDATE = DateTime.Now;
            DataTable dtdiff = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);


            _obj_Smhr_TrgRqst.Mode = 25;
            _obj_Smhr_TrgRqst.TR_ID = Convert.ToInt32(rcmb_Attdtls_Training.SelectedItem.Value);
            _obj_Smhr_TrgRqst.TR_ORG_ID = Convert.ToInt32(Session["org_id"]);
            DataTable dtequal = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);
            if (dtequal.Rows.Count != 0)
            {
                if ((rdtp_AttDtls_AttDt.SelectedDate == DateTime.Now) || ((Convert.ToInt32(dtdiff.Rows[0]["diffdate"])) <= (Convert.ToInt32(dtequal.Rows[0]["FEEDBACK_BACKDATE"]))))
                {

                    Telerik.Web.UI.RadComboBox ddlList = new RadComboBox();
                    SMHR_TRAININGATTENDANCEDTLS _obj_Smhr_TrngAttendanceDtls = new SMHR_TRAININGATTENDANCEDTLS();
                    _obj_Smhr_TrngAttendanceDtls.Mode = 5;
                    _obj_Smhr_TrngAttendanceDtls.ATTENDANCE_TR_ID = Convert.ToInt32(rcmb_Attdtls_Training.SelectedItem.Value);

                    _obj_Smhr_TrngAttendanceDtls.ATTENDANCE_DATE = Convert.ToDateTime(rdtp_AttDtls_AttDt.SelectedDate);
                    DataTable dtfinal = BLL.get_TRgAttandencedtls(_obj_Smhr_TrngAttendanceDtls);
                    if (dtfinal.Rows.Count != 0)
                    {//if attendance  not finalised

                        if (Convert.ToInt32(dtfinal.Rows[0]["ATTENDANCE_ISFINAL"]) == 1)
                        {

                            _obj_Smhr_TrngAttendanceDtls.Mode = 6;
                            _obj_Smhr_TrngAttendanceDtls.ATTENDANCE_TR_ID = Convert.ToInt32(rcmb_Attdtls_Training.SelectedItem.Value);

                            _obj_Smhr_TrngAttendanceDtls.ATTENDANCE_DATE = Convert.ToDateTime(rdtp_AttDtls_AttDt.SelectedDate);
                            DataTable dtfinal1 = BLL.get_TRgAttandencedtls(_obj_Smhr_TrngAttendanceDtls);
                            if (dtfinal1.Rows.Count != 0)
                            {
                                rgd_AttDtls_Emp.DataSource = dtfinal1;

                                rgd_AttDtls_Emp.DataBind();
                                btn_AttDtls_Submit.Visible = false;
                                btn_finalise.Visible = true;
                                rgd_AttDtls_Emp.Visible = true;
                                for (int j = 0; j <= rgd_AttDtls_Emp.Items.Count - 1; j++)
                                {
                                    ddlList = rgd_AttDtls_Emp.Items[j].FindControl("rcmb_AttDtls_Status") as RadComboBox;
                                    if (Convert.ToString(Convert.ToString(dtfinal1.Rows[j]["ATTENDANCE_STATUS"])) == "Present")
                                        ddlList.SelectedIndex = ddlList.FindItemIndexByValue(Convert.ToString("P"));
                                    else if (Convert.ToString(Convert.ToString(dtfinal1.Rows[j]["ATTENDANCE_STATUS"])) == "Absent")
                                        ddlList.SelectedIndex = ddlList.FindItemIndexByValue(Convert.ToString("A"));

                                    //ddlList.SelectedItem.Text = Convert.ToString(dtfinal1.Rows[j]["ATTENDANCE_STATUS"]);

                                }

                                BLL.ShowMessage(this, "Attendace Details Not Finalised");

                                return;
                            }
                            else
                            {
                                DataTable dt1 = new DataTable();
                                rgd_AttDtls_Emp.DataSource = dt1;

                                rgd_AttDtls_Emp.DataBind();
                                btn_AttDtls_Submit.Visible = false;
                                btn_finalise.Visible = false;
                                rgd_AttDtls_Emp.Visible = true;
                            }

                        }

                        else if (Convert.ToInt32(dtfinal.Rows[0]["ATTENDANCE_ISFINAL"]) == 2)
                        {//if attendance  already finalised
                            _obj_Smhr_TrngAttendanceDtls.Mode = 7;
                            _obj_Smhr_TrngAttendanceDtls.ATTENDANCE_TR_ID = Convert.ToInt32(rcmb_Attdtls_Training.SelectedItem.Value);

                            _obj_Smhr_TrngAttendanceDtls.ATTENDANCE_DATE = Convert.ToDateTime(rdtp_AttDtls_AttDt.SelectedDate);
                            DataTable dtfinal1 = BLL.get_TRgAttandencedtls(_obj_Smhr_TrngAttendanceDtls);
                            rgd_AttDtls_Emp.DataSource = dtfinal1;
                            rgd_AttDtls_Emp.DataBind();
                            btn_AttDtls_Submit.Visible = false;
                            btn_finalise.Visible = false;
                            for (int j = 0; j <= rgd_AttDtls_Emp.Items.Count - 1; j++)
                            {
                                ddlList = rgd_AttDtls_Emp.Items[j].FindControl("rcmb_AttDtls_Status") as RadComboBox;
                                if (Convert.ToString(Convert.ToString(dtfinal1.Rows[j]["ATTENDANCE_STATUS"])) == "Present")
                                    ddlList.SelectedIndex = ddlList.FindItemIndexByValue(Convert.ToString("P"));
                                else if (Convert.ToString(Convert.ToString(dtfinal1.Rows[j]["ATTENDANCE_STATUS"])) == "Absent")
                                    ddlList.SelectedIndex = ddlList.FindItemIndexByValue(Convert.ToString("A"));
                                //ddlList.SelectedItem.Text = Convert.ToString(dtfinal1.Rows[j]["ATTENDANCE_STATUS"]);

                            }
                            BLL.ShowMessage(this, "Attendace Details  Finalised");
                            rgd_AttDtls_Emp.Visible = true;
                            rgd_AttDtls_Emp.Enabled = false;
                            return;

                        }
                    }
                    else
                    {

                        SMHR_TRAINEE _obj_Smhr_TrnEE = new SMHR_TRAINEE();
                        _obj_Smhr_TrnEE.Mode = 6;
                        _obj_Smhr_TrnEE.TRAINEE_TR_ID = Convert.ToInt32(rcmb_Attdtls_Training.SelectedItem.Value);
                        _obj_Smhr_TrnEE.TRAINEE_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_Attdtls_BU.SelectedItem.Value);
                        _obj_Smhr_TrnEE.TRAINEE_LASTMDFDATE = Convert.ToDateTime(rdtp_AttDtls_AttDt.SelectedDate);

                        DataTable dtemp = BLL.get_TRAINEE(_obj_Smhr_TrnEE);
                        if (dtemp.Rows.Count != 0)
                        {
                            rgd_AttDtls_Emp.DataSource = dtemp;
                            rgd_AttDtls_Emp.DataBind();
                            btn_AttDtls_Submit.Visible = true;
                            btn_finalise.Visible = true;

                            rgd_AttDtls_Emp.Visible = true;
                            rgd_AttDtls_Emp.Enabled = true;
                            return;
                        }

                        else
                        {
                            DataTable dt1 = new DataTable();
                            rgd_AttDtls_Emp.DataSource = dt1;
                            rgd_AttDtls_Emp.DataBind();
                            btn_AttDtls_Submit.Visible = false;
                            btn_finalise.Visible = false;

                            rgd_AttDtls_Emp.Visible = true;
                            return;
                        }

                    }
                }
                else
                {

                    SMHR_TRAINEE _obj_Smhr_TrnEE = new SMHR_TRAINEE();
                    _obj_Smhr_TrnEE.Mode = 6;
                    _obj_Smhr_TrnEE.TRAINEE_TR_ID = Convert.ToInt32(rcmb_Attdtls_Training.SelectedItem.Value);
                    _obj_Smhr_TrnEE.TRAINEE_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_Attdtls_BU.SelectedItem.Value);
                    _obj_Smhr_TrnEE.TRAINEE_LASTMDFDATE = Convert.ToDateTime(rdtp_AttDtls_AttDt.SelectedDate);

                    DataTable dtemp = BLL.get_TRAINEE(_obj_Smhr_TrnEE);
                    if (dtemp.Rows.Count != 0)
                    {
                        rgd_AttDtls_Emp.DataSource = dtemp;
                        rgd_AttDtls_Emp.DataBind();
                        btn_AttDtls_Submit.Visible = true;
                        btn_finalise.Visible = false;
                        for (int j = 0; j <= rgd_AttDtls_Emp.Items.Count - 1; j++)
                        {
                            RadComboBox ddlList = rgd_AttDtls_Emp.Items[j].FindControl("rcmb_AttDtls_Status") as RadComboBox;

                            ddlList.SelectedItem.Text = "Absent";

                        }
                        rgd_AttDtls_Emp.Visible = true;
                        rgd_AttDtls_Emp.Enabled = false;
                        btn_AttDtls_Submit.Visible = false;
                        return;
                    }

                    else
                    {
                        DataTable dt1 = new DataTable();
                        rgd_AttDtls_Emp.DataSource = dt1;
                        rgd_AttDtls_Emp.DataBind();
                        btn_AttDtls_Submit.Visible = false;
                        btn_finalise.Visible = false;
                        rgd_AttDtls_Emp.Enabled = false;
                        rgd_AttDtls_Emp.Visible = true;

                        return;
                    }
                }


            }

            else
            {
                if ((rdtp_AttDtls_AttDt.SelectedDate == DateTime.Now))
                {

                    Telerik.Web.UI.RadComboBox ddlList = new RadComboBox();
                    SMHR_TRAININGATTENDANCEDTLS _obj_Smhr_TrngAttendanceDtls = new SMHR_TRAININGATTENDANCEDTLS();
                    _obj_Smhr_TrngAttendanceDtls.Mode = 5;
                    _obj_Smhr_TrngAttendanceDtls.ATTENDANCE_TR_ID = Convert.ToInt32(rcmb_Attdtls_Training.SelectedItem.Value);

                    _obj_Smhr_TrngAttendanceDtls.ATTENDANCE_DATE = Convert.ToDateTime(rdtp_AttDtls_AttDt.SelectedDate);
                    DataTable dtfinal = BLL.get_TRgAttandencedtls(_obj_Smhr_TrngAttendanceDtls);
                    if (dtfinal.Rows.Count != 0)
                    {//if attendance  not finalised
                        if (Convert.ToInt32(dtfinal.Rows[0]["ATTENDANCE_ISFINAL"]) == 1)
                        {

                            _obj_Smhr_TrngAttendanceDtls.Mode = 6;
                            _obj_Smhr_TrngAttendanceDtls.ATTENDANCE_TR_ID = Convert.ToInt32(rcmb_Attdtls_Training.SelectedItem.Value);

                            _obj_Smhr_TrngAttendanceDtls.ATTENDANCE_DATE = Convert.ToDateTime(rdtp_AttDtls_AttDt.SelectedDate);
                            DataTable dtfinal1 = BLL.get_TRgAttandencedtls(_obj_Smhr_TrngAttendanceDtls);
                            if (dtfinal1.Rows.Count != 0)
                            {
                                rgd_AttDtls_Emp.DataSource = dtfinal1;

                                rgd_AttDtls_Emp.DataBind();
                                btn_AttDtls_Submit.Visible = false;
                                btn_finalise.Visible = true;
                                rgd_AttDtls_Emp.Visible = true;
                                for (int j = 0; j <= rgd_AttDtls_Emp.Items.Count - 1; j++)
                                {
                                    ddlList = rgd_AttDtls_Emp.Items[j].FindControl("rcmb_AttDtls_Status") as RadComboBox;
                                    if (Convert.ToString(Convert.ToString(dtfinal1.Rows[j]["ATTENDANCE_STATUS"])) == "Present")
                                        ddlList.SelectedIndex = ddlList.FindItemIndexByValue(Convert.ToString("P"));
                                    else if (Convert.ToString(Convert.ToString(dtfinal1.Rows[j]["ATTENDANCE_STATUS"])) == "Absent")
                                        ddlList.SelectedIndex = ddlList.FindItemIndexByValue(Convert.ToString("A"));

                                    //ddlList.SelectedItem.Text = Convert.ToString(dtfinal1.Rows[j]["ATTENDANCE_STATUS"]);

                                }

                                BLL.ShowMessage(this, "Attendace Details Not Finalised");

                                return;
                            }
                            else
                            {
                                DataTable dt1 = new DataTable();
                                rgd_AttDtls_Emp.DataSource = dt1;

                                rgd_AttDtls_Emp.DataBind();
                                btn_AttDtls_Submit.Visible = false;
                                btn_finalise.Visible = false;
                                rgd_AttDtls_Emp.Visible = true;
                            }

                        }

                        else if (Convert.ToInt32(dtfinal.Rows[0]["ATTENDANCE_ISFINAL"]) == 2)
                        {//if attendance  already finalised
                            _obj_Smhr_TrngAttendanceDtls.Mode = 7;
                            _obj_Smhr_TrngAttendanceDtls.ATTENDANCE_TR_ID = Convert.ToInt32(rcmb_Attdtls_Training.SelectedItem.Value);

                            _obj_Smhr_TrngAttendanceDtls.ATTENDANCE_DATE = Convert.ToDateTime(rdtp_AttDtls_AttDt.SelectedDate);
                            DataTable dtfinal1 = BLL.get_TRgAttandencedtls(_obj_Smhr_TrngAttendanceDtls);
                            rgd_AttDtls_Emp.DataSource = dtfinal1;
                            rgd_AttDtls_Emp.DataBind();
                            btn_AttDtls_Submit.Visible = false;
                            btn_finalise.Visible = false;
                            for (int j = 0; j <= rgd_AttDtls_Emp.Items.Count - 1; j++)
                            {
                                ddlList = rgd_AttDtls_Emp.Items[j].FindControl("rcmb_AttDtls_Status") as RadComboBox;
                                if (Convert.ToString(Convert.ToString(dtfinal1.Rows[j]["ATTENDANCE_STATUS"])) == "Present")
                                    ddlList.SelectedIndex = ddlList.FindItemIndexByValue(Convert.ToString("P"));
                                else if (Convert.ToString(Convert.ToString(dtfinal1.Rows[j]["ATTENDANCE_STATUS"])) == "Absent")
                                    ddlList.SelectedIndex = ddlList.FindItemIndexByValue(Convert.ToString("A"));
                                //ddlList.SelectedItem.Text = Convert.ToString(dtfinal1.Rows[j]["ATTENDANCE_STATUS"]);

                            }
                            BLL.ShowMessage(this, "Attendace Details  Finalised");
                            rgd_AttDtls_Emp.Visible = true;
                            rgd_AttDtls_Emp.Enabled = false;
                            return;

                        }
                    }
                    else
                    {

                        SMHR_TRAINEE _obj_Smhr_TrnEE = new SMHR_TRAINEE();
                        _obj_Smhr_TrnEE.Mode = 6;
                        _obj_Smhr_TrnEE.TRAINEE_TR_ID = Convert.ToInt32(rcmb_Attdtls_Training.SelectedItem.Value);
                        _obj_Smhr_TrnEE.TRAINEE_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_Attdtls_BU.SelectedItem.Value);
                        _obj_Smhr_TrnEE.TRAINEE_LASTMDFDATE = Convert.ToDateTime(rdtp_AttDtls_AttDt.SelectedDate);

                        DataTable dtemp = BLL.get_TRAINEE(_obj_Smhr_TrnEE);
                        if (dtemp.Rows.Count != 0)
                        {
                            rgd_AttDtls_Emp.DataSource = dtemp;
                            rgd_AttDtls_Emp.DataBind();
                            btn_AttDtls_Submit.Visible = true;
                            btn_finalise.Visible = true;

                            rgd_AttDtls_Emp.Visible = true;
                            rgd_AttDtls_Emp.Enabled = true;
                            return;
                        }

                        else
                        {
                            DataTable dt1 = new DataTable();
                            rgd_AttDtls_Emp.DataSource = dt1;
                            rgd_AttDtls_Emp.DataBind();
                            btn_AttDtls_Submit.Visible = false;
                            btn_finalise.Visible = false;

                            rgd_AttDtls_Emp.Visible = true;
                            return;
                        }

                    }
                }
                else
                {

                    SMHR_TRAINEE _obj_Smhr_TrnEE = new SMHR_TRAINEE();
                    _obj_Smhr_TrnEE.Mode = 6;
                    _obj_Smhr_TrnEE.TRAINEE_TR_ID = Convert.ToInt32(rcmb_Attdtls_Training.SelectedItem.Value);
                    _obj_Smhr_TrnEE.TRAINEE_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_Attdtls_BU.SelectedItem.Value);
                    _obj_Smhr_TrnEE.TRAINEE_LASTMDFDATE = Convert.ToDateTime(rdtp_AttDtls_AttDt.SelectedDate);

                    DataTable dtemp = BLL.get_TRAINEE(_obj_Smhr_TrnEE);
                    if (dtemp.Rows.Count != 0)
                    {
                        rgd_AttDtls_Emp.DataSource = dtemp;
                        rgd_AttDtls_Emp.DataBind();
                        btn_AttDtls_Submit.Visible = true;
                        btn_finalise.Visible = false;
                        for (int j = 0; j <= rgd_AttDtls_Emp.Items.Count - 1; j++)
                        {
                            RadComboBox ddlList = rgd_AttDtls_Emp.Items[j].FindControl("rcmb_AttDtls_Status") as RadComboBox;

                            ddlList.SelectedItem.Text = "Absent";

                        }
                        rgd_AttDtls_Emp.Visible = true;
                        rgd_AttDtls_Emp.Enabled = false;
                        btn_AttDtls_Submit.Visible = false;
                        return;
                    }

                    else
                    {
                        DataTable dt1 = new DataTable();
                        rgd_AttDtls_Emp.DataSource = dt1;
                        rgd_AttDtls_Emp.DataBind();
                        btn_AttDtls_Submit.Visible = false;
                        btn_finalise.Visible = false;
                        rgd_AttDtls_Emp.Enabled = false;
                        rgd_AttDtls_Emp.Visible = true;

                        return;
                    }
                }

            }
           
        }

        else
        {
            BLL.ShowMessage(this, "Future Attendance Cannot Given");
            rgd_AttDtls_Emp.Visible = false;
            btn_finalise.Visible = false;
            btn_AttDtls_Submit.Visible = false;

            return;
        }
       }
         catch (Exception ex)
         {
             SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_trainingattendancedtls", ex.StackTrace, DateTime.Now);
             Response.Redirect("~/Frm_ErrorPage.aspx");
         }

    }

    #endregion

    #region trg changed
    /// <summary>
    /// when trg changed
    /// </summary>
    /// <param name="o"></param>
    /// <param name="e"></param>
    protected void rcmb_Attdtls_TRG_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
    {
        if (rcmb_Attdtls_Training.SelectedItem.Text != "Select")
        {
            SMHR_TRAINER _obj_Smhr_Trner = new SMHR_TRAINER();
            //_obj_Smhr_Trner.Mode = 17;
            //_obj_Smhr_Trner.TRAINERDETAILS_EMPLOYEEID = Convert.ToInt32(Session["EMP_ID"]);
            //_obj_Smhr_Trner.TRAINERDETAILS_TR_ID = Convert.ToInt32(rcmb_Attdtls_Training.SelectedItem.Value);
            //DataTable dt1 = BLL.get_TRAINer(_obj_Smhr_Trner);
            //if (dt1.Rows.Count != 0)
            //{  BLL.ShowMessage(this, "Attendace Details have been Submitted");
            //    lbl_AttDtls_AttDt.Visible = true;
            //    rdtp_AttDtls_AttDt.Visible = true;
            //}


            //else
            //{
            //    BLL.ShowMessage(this, "Employee Not Under This Training");
            //    lbl_AttDtls_AttDt.Visible = false;
            //    rdtp_AttDtls_AttDt.Visible = false;
            //}
            //SMHR_TRAININGREQUEST _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();
            //       _obj_Smhr_TrgRqst.Mode = 21;

            //       DataTable dthrid = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);
            //       if (dthrid.Rows.Count != 0)
            //       {
            //           if (dthrid.Rows[0]["login_emp_id"] == Session["EMP_ID"])
            //           {
            //               _obj_Smhr_Trner.Mode = 18;

            //               _obj_Smhr_Trner.TRAINERDETAILS_TR_ID = Convert.ToInt32(rcmb_Attdtls_Training.SelectedItem.Value);
            //               DataTable dt15 = BLL.get_TRAINer(_obj_Smhr_Trner);
            //               if (dt15.Rows.Count != 0)
            //               {
            //                   lbl_AttDtls_AttDt.Visible = true;
            //                   rdtp_AttDtls_AttDt.Visible = true;
            //               }
            //           }
            //       }


            lbl_AttDtls_AttDt.Visible = true;
            rdtp_AttDtls_AttDt.Visible = true;
        }

        else
        {
            lbl_AttDtls_AttDt.Visible = false;
            rdtp_AttDtls_AttDt.Visible = false;
        }
        }
         catch (Exception ex)
         {
             SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_trainingattendancedtls", ex.StackTrace, DateTime.Now);
             Response.Redirect("~/Frm_ErrorPage.aspx");
         }
    }
#endregion

    #region date changed
    protected void rdtp_AttDtls_AttDt_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        try
        {
            loadEmployees();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_trainingattendancedtls", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }


    #endregion

    #region attendance submit,finalise
    
    protected void btn_AttDtls_Submit_Click(object sender, EventArgs e)
    {
        try
        {
        for (int i = 0; i <= rgd_AttDtls_Emp.Items.Count - 1; i++)
        {
            RadComboBox rcm_status=new RadComboBox();
            rcm_status = rgd_AttDtls_Emp.Items[i].FindControl("rcmb_AttDtls_Status") as RadComboBox;
            Label lblemp = new Label();
            lblemp = rgd_AttDtls_Emp.Items[i].FindControl("lbl_empid") as Label;


            SMHR_TRAININGATTENDANCEDTLS _obj_Smhr_TrngAttendanceDtls = new SMHR_TRAININGATTENDANCEDTLS();
            _obj_Smhr_TrngAttendanceDtls.Mode = 3;
            _obj_Smhr_TrngAttendanceDtls.ATTENDANCE_TR_ID = Convert.ToInt32(rcmb_Attdtls_Training.SelectedItem.Value);
            _obj_Smhr_TrngAttendanceDtls.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_Attdtls_BU.SelectedItem.Value);
            _obj_Smhr_TrngAttendanceDtls.ATTENDANCE_EMP_ID = Convert.ToInt32(lblemp.Text);
            _obj_Smhr_TrngAttendanceDtls.ATTENDANCE_DATE = Convert.ToDateTime(rdtp_AttDtls_AttDt.SelectedDate);
            _obj_Smhr_TrngAttendanceDtls.ATTENDANCE_STATUS = Convert.ToString(rcm_status.SelectedItem.Text);
            _obj_Smhr_TrngAttendanceDtls.ATTENDANCE_ISFINAL = Convert.ToInt32(1);
            _obj_Smhr_TrngAttendanceDtls.ATTENDANCE_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_Smhr_TrngAttendanceDtls.ATTENDANCE_CREATEDDATE = DateTime.Now;
            bool status = BLL.set_TRgAttandencedtls(_obj_Smhr_TrngAttendanceDtls);




        }

        BLL.ShowMessage(this, "Attendace Details have been Submitted");
        //loadBusinessUnit();
        //rgd_AttDtls_Emp.Visible = false;
       // lbl_AttDtls_Training.Visible = false;
       // rcmb_Attdtls_Training.Visible = false;
       // lbl_AttDtls_AttDt.Visible = false;
       // rdtp_AttDtls_AttDt.Visible = false;
        btn_AttDtls_Submit.Visible = false;
        //btn_finalise.Visible = false;
        return;
         }
         catch (Exception ex)
         {
             SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_trainingattendancedtls", ex.StackTrace, DateTime.Now);
             Response.Redirect("~/Frm_ErrorPage.aspx");
         }
    }

    protected void btn_finalise_Submit_Click(object sender, EventArgs e)
    {
        try
    {
        for (int i = 0; i <= rgd_AttDtls_Emp.Items.Count - 1; i++)
        {
            RadComboBox rcm_status = new RadComboBox();
            rcm_status = rgd_AttDtls_Emp.Items[i].FindControl("rcmb_AttDtls_Status") as RadComboBox;
            Label lblemp = new Label();
            lblemp = rgd_AttDtls_Emp.Items[i].FindControl("lbl_empid") as Label;


         //   SMHR_TRAININGATTENDANCEDTLS _obj_Smhr_TrngAttendanceDtls = new SMHR_TRAININGATTENDANCEDTLS();
         //   _obj_Smhr_TrngAttendanceDtls.Mode = 4;
         //   _obj_Smhr_TrngAttendanceDtls.ATTENDANCE_TR_ID = Convert.ToInt32(rcmb_Attdtls_Training.SelectedItem.Value);
          
         //   _obj_Smhr_TrngAttendanceDtls.ATTENDANCE_EMP_ID = Convert.ToInt32(lblemp.Text);
         //_obj_Smhr_TrngAttendanceDtls.ATTENDANCE_STATUS = Convert.ToString(rcm_status.SelectedItem.Text);
         //   _obj_Smhr_TrngAttendanceDtls.ATTENDANCE_ISFINAL = Convert.ToInt32(2);
         //   _obj_Smhr_TrngAttendanceDtls.ATTENDANCE_DATE = Convert.ToDateTime(rdtp_AttDtls_AttDt.SelectedDate);
         //   _obj_Smhr_TrngAttendanceDtls.ATTENDANCE_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
         //   _obj_Smhr_TrngAttendanceDtls.ATTENDANCE_LASTMDFDATE = DateTime.Now;
         //   bool status = BLL.set_TRgAttandencedtls(_obj_Smhr_TrngAttendanceDtls);

            SMHR_TRAININGATTENDANCEDTLS _obj_Smhr_TrngAttendanceDtls = new SMHR_TRAININGATTENDANCEDTLS();
            _obj_Smhr_TrngAttendanceDtls.Mode = 3;
            _obj_Smhr_TrngAttendanceDtls.ATTENDANCE_TR_ID = Convert.ToInt32(rcmb_Attdtls_Training.SelectedItem.Value);
            _obj_Smhr_TrngAttendanceDtls.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_Attdtls_BU.SelectedItem.Value);
            _obj_Smhr_TrngAttendanceDtls.ATTENDANCE_EMP_ID = Convert.ToInt32(lblemp.Text);
            _obj_Smhr_TrngAttendanceDtls.ATTENDANCE_DATE = Convert.ToDateTime(rdtp_AttDtls_AttDt.SelectedDate);
            _obj_Smhr_TrngAttendanceDtls.ATTENDANCE_STATUS = Convert.ToString(rcm_status.SelectedItem.Text);
            _obj_Smhr_TrngAttendanceDtls.ATTENDANCE_ISFINAL = Convert.ToInt32(2);
            _obj_Smhr_TrngAttendanceDtls.ATTENDANCE_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_Smhr_TrngAttendanceDtls.ATTENDANCE_CREATEDDATE = DateTime.Now;
            bool status = BLL.set_TRgAttandencedtls(_obj_Smhr_TrngAttendanceDtls);




        }

        BLL.ShowMessage(this, "Attendace Details have been Finalised");
       // loadBusinessUnit();
      //  rgd_AttDtls_Emp.Visible = false;
        //lbl_AttDtls_Training.Visible = false;
        //rcmb_Attdtls_Training.Visible = false;
       // lbl_AttDtls_AttDt.Visible = false;
      //  rdtp_AttDtls_AttDt.Visible = false;

        rgd_AttDtls_Emp.Enabled = false;
        btn_finalise.Visible = false;
        btn_AttDtls_Submit.Visible = false;
        return;

         }
         catch (Exception ex)
         {
             SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_trainingattendancedtls", ex.StackTrace, DateTime.Now);
             Response.Redirect("~/Frm_ErrorPage.aspx");
         }
    }


    #endregion

    #region business unit changed
    protected void rcmb_Attdtls_BU_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
    {

        if (rcmb_Attdtls_BU.SelectedItem.Text != "Select")
        {
            //only approved trgs will come here
            //SMHR_TRAINER _obj_Smhr_Trner = new SMHR_TRAINER();


            //_obj_Smhr_Trner.TRAINERDETAILS_BUSINESSUNITID = Convert.ToInt32(rcmb_Attdtls_BU.SelectedItem.Value);

            //_obj_Smhr_Trner.Mode = 7;

            //DataTable dttrg = BLL.get_TRAINer(_obj_Smhr_Trner);

            SMHR_TRAINEE _obj_Smhr_TrnEE = new SMHR_TRAINEE();

            _obj_Smhr_TrnEE.Mode = 15;
            _obj_Smhr_TrnEE.TRAINEE_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_Attdtls_BU.SelectedItem.Value);
           _obj_Smhr_TrnEE.TRAINEE_EMPID=Convert.ToInt32(Session["EMP_ID"]);
           _obj_Smhr_TrnEE.TRAINEE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
           DataTable dttraineeexist = BLL.get_TRAINEE(_obj_Smhr_TrnEE);
            if (dttraineeexist.Rows.Count != 0)
            {
                rcmb_Attdtls_Training.DataSource = dttraineeexist;
                rcmb_Attdtls_Training.DataTextField = "TR_TITLE";
                rcmb_Attdtls_Training.DataValueField = "TR_ID";
                rcmb_Attdtls_Training.DataBind();

                rcmb_Attdtls_Training.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
                lbl_AttDtls_Training.Visible = true;
                rcmb_Attdtls_Training.Visible = true;
                rdtp_AttDtls_AttDt.Visible = false;
                lbl_AttDtls_AttDt.Visible = false;
                rgd_AttDtls_Emp.Visible = false;
            }

            else
            {//IF THR LOGIN USER EQUAL TO HR THEN DISPLY TRG UNDER HR
                SMHR_TRAININGREQUEST _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();
                _obj_Smhr_TrgRqst.Mode = 21;
                _obj_Smhr_TrgRqst.TR_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable DT455 = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);


                //if (Convert.ToInt32(DT455.Rows[0]["login_emp_id"]) == Convert.ToInt32(Session["EMP_ID"]))
                //{
               //for hr
                if (Convert.ToInt32(Session["EMP_ID"]) != 0)
                {
                    _obj_Smhr_TrnEE = new SMHR_TRAINEE();

                    _obj_Smhr_TrnEE.Mode = 16;
                    _obj_Smhr_TrnEE.TRAINEE_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_Attdtls_BU.SelectedItem.Value);
                    _obj_Smhr_TrnEE.TRAINEE_EMPID = 0;
                    _obj_Smhr_TrnEE.TRAINEE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dttraineeexist1 = BLL.get_TRAINEE(_obj_Smhr_TrnEE);
                    if (dttraineeexist1.Rows.Count != 0)
                    {
                        rcmb_Attdtls_Training.DataSource = dttraineeexist1;
                        rcmb_Attdtls_Training.DataTextField = "TR_TITLE";
                        rcmb_Attdtls_Training.DataValueField = "TR_ID";
                        rcmb_Attdtls_Training.DataBind();

                        rcmb_Attdtls_Training.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
                        lbl_AttDtls_Training.Visible = true;
                        rcmb_Attdtls_Training.Visible = true;
                        rdtp_AttDtls_AttDt.Visible = false;
                        lbl_AttDtls_AttDt.Visible = false;
                        rgd_AttDtls_Emp.Visible = false;
                    }

                    else
                    {
                        BLL.ShowMessage(this, "No Training Under This User");
                        return;
                    }
                }
                else
                {
                    BLL.ShowMessage(this, "No Training Under This User");
                    return;
                }

            }
            
        }
        else
        {
            BLL.ShowMessage(this, "Please Select BusinessUnit");
            rdtp_AttDtls_AttDt.Visible = false;
            lbl_AttDtls_AttDt.Visible = false;
            rgd_AttDtls_Emp.Visible = false;
            lbl_AttDtls_Training.Visible = false;
            rcmb_Attdtls_Training.Visible = false;
            return;



        }
         }
         catch (Exception ex)
         {
             SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_trainingattendancedtls", ex.StackTrace, DateTime.Now);
             Response.Redirect("~/Frm_ErrorPage.aspx");
         }

    }


    #endregion

}
