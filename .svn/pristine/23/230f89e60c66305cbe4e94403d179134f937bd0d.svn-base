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
using System.Text;

public partial class HR_TRAINING_frm_offline_Assessments : System.Web.UI.Page
{

    public void btnCancelMarks_Click(object sender, EventArgs e)
    {
        try
        {
            txtmarks.Text = string.Empty;
            rbtnlst.ClearSelection();
            lblAssessmentID.Text = string.Empty;
            Rm_Course_page.SelectedIndex = 2;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_offline Assessments", ex.StackTrace, DateTime.Now);

            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void btnSaveMarks_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_OFFLINEASSESSMENT_RESULT oSMHR_OFFLINEASSESSMENT_RESULT = new SMHR_OFFLINEASSESSMENT_RESULT();
            oSMHR_OFFLINEASSESSMENT_RESULT.OFFLINE_RESULTID = Convert.ToInt32(lblAssessmentID.Text);
            oSMHR_OFFLINEASSESSMENT_RESULT.OFFLINE_MARKS = Convert.ToInt32(txtmarks.Text);
            if (string.Compare(rbtnlst.SelectedValue, "Pass", true) == 0)
                oSMHR_OFFLINEASSESSMENT_RESULT.OFFLINE_RESULT = true;
            else
                oSMHR_OFFLINEASSESSMENT_RESULT.OFFLINE_RESULT = false;
            oSMHR_OFFLINEASSESSMENT_RESULT.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            oSMHR_OFFLINEASSESSMENT_RESULT.LASTMDFDATE = DateTime.Now;
            oSMHR_OFFLINEASSESSMENT_RESULT.OPERATION = operation.Update;
            if (BLL.set_OfflineAssessmentResult(oSMHR_OFFLINEASSESSMENT_RESULT))
            {
                BLL.ShowMessage(this, "Information Updated Successfully");
                Rm_Course_page.SelectedIndex = 2;
            }
            else
            {
                BLL.ShowMessage(this, "Information Not Saved");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_offline Assessments", ex.StackTrace, DateTime.Now);

            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        SMHR_LOGININFO _obj_SMHR_LoginInfo;
        SMHR_MASTERS _obj_Smhr_Masters;
        SMHR_COURSE _obj_Smhr_Course;
        SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit;
        SMHR_TRAINING_OFFLINEASSESSMENTS _obj_SMHR_Offlineassesments;

        try
        {

            if (!Page.IsPostBack)
            {
               
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Offline Assessments");//COURSE");
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
                    Rg_Course.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
                lbl_CourseHeader.Visible = true;
                Page.Validate();
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_offline Assessments", ex.StackTrace, DateTime.Now);

            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }
    public void LoadGrid()
    {
        try
        {
            SMHR_TRAINING_OFFLINEASSESSMENTS _obj_SMHR_Offlineassesments = new SMHR_TRAINING_OFFLINEASSESSMENTS();
            _obj_SMHR_Offlineassesments.OFFLINEASSESSMENT_ORGID = Convert.ToInt32(Session["ORG_ID"]);



            DataTable DT = BLL.get_OfflineAssessment(_obj_SMHR_Offlineassesments);
            if (DT.Rows.Count != 0)
            {
                Rg_Course.DataSource = DT;
            }

            else
            {
                DataTable dt1 = new DataTable();
                Rg_Course.DataSource = dt1;
            }
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_offline Assessments", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void clearControls()
    {
        try
        {
            rtxt_AssessmentName.Text = string.Empty;
            rcmb_CC.SelectedIndex = -1;
            rfc_rcmb_CS.Items.Clear();
            rfc_rcmb_CS.SelectedIndex = -1;
            btn_Save.Visible = false;
            btn_Update.Visible = false;

            Rm_Course_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_offline Assessments", ex.StackTrace, DateTime.Now);

            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void Rg_Course_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_offline_Assessments", ex.StackTrace, DateTime.Now);

            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Marks_Command(object sender, CommandEventArgs e)
    {
        try
        {
            txtmarks.Text = string.Empty;
            rbtnlst.ClearSelection();
            lblAssessmentID.Text = e.CommandArgument.ToString();
            for (int i = 0; i < RadOfflineResults.Items.Count; i++)
            {
                if (string.Compare(RadOfflineResults.Items[i].Cells[2].Text, e.CommandArgument.ToString(), true) == 0)
                {
                    lblAssessmentName.Text = RadOfflineResults.Items[i].Cells[3].Text;
                }
            }
            Rm_Course_page.SelectedIndex = 3;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_offline Assessments", ex.StackTrace, DateTime.Now);
             Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            //lbl_CourseHeader.Visible = false;
            //loadDropdown();
            clearControls();
            LoadCombos();
            btn_Save.Visible = true;
            rcmb_CC.Enabled = true;
            rfc_rcmb_CS.Enabled = true;
            rtxt_AssessmentName.Enabled = true;
            Rm_Course_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_offline Assessments", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }




    private void LoadCombos()
    {
        try
        {
            SMHR_COURSE _obj_Course = new SMHR_COURSE();
            _obj_Course.OPERATION = operation.Select2;
            _obj_Course.COURSE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            rcmb_CC.DataSource = BLL.get_Course(_obj_Course);
            rcmb_CC.DataTextField = "COURSE_NAME";
            rcmb_CC.DataValueField = "COURSE_ID";
            rcmb_CC.DataBind();
            rcmb_CC.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            rfc_rcmb_CS.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_offline Assessments", ex.StackTrace, DateTime.Now);

            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    protected void radCourse_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (string.Compare(rcmb_CC.SelectedItem.Text, "Select", true) != 0)
            {
                LoadComboSchedule();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_offline Assessments", ex.StackTrace, DateTime.Now);

            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadComboSchedule()
    {
        try
        {
            SMHR_COURSESCHEDULE _obj_Smhr_TrgRqst = new SMHR_COURSESCHEDULE();
            _obj_Smhr_TrgRqst.OPERATION = operation.Select3;
            _obj_Smhr_TrgRqst.COURSESCHEDULE_COURSEID = Convert.ToInt32(rcmb_CC.SelectedValue);
            _obj_Smhr_TrgRqst.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);//YYY
            rfc_rcmb_CS.DataSource = BLL.get_CourseSchedule(_obj_Smhr_TrgRqst);
            rfc_rcmb_CS.DataValueField = "CourseSchedule_ID";
            rfc_rcmb_CS.DataTextField = "CourseSchedule_Name";
            rfc_rcmb_CS.DataBind();
            rfc_rcmb_CS.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_offline Assessments", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    /*added by anusha for need datasource 12/05/2015*/
    private void needdatasource()
    {
        try
        {
            Btn_Cancel1.Visible = true;
            SMHR_OFFLINEASSESSMENT_RESULT oSMHR_OFFLINEASSESSMENT_RESULT = new SMHR_OFFLINEASSESSMENT_RESULT();
            oSMHR_OFFLINEASSESSMENT_RESULT.OFFLINE_ASSESSMENTID = Convert.ToInt32(Session["Assements_ID"]);
            oSMHR_OFFLINEASSESSMENT_RESULT.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            oSMHR_OFFLINEASSESSMENT_RESULT.OPERATION = operation.Get;
            RadOfflineResults.DataSource = BLL.get_OfflineAssessmentResult(oSMHR_OFFLINEASSESSMENT_RESULT);
            //  RadOfflineResults.DataBind();

           // Rm_Course_page.SelectedIndex = 2;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_offline Assessments", ex.StackTrace, DateTime.Now);

            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


    }



    protected void lnk_Result_Command(object sender, CommandEventArgs e)
    {
        try
        {
            Btn_Cancel1.Visible = true;
            Session["Assements_ID"] = Convert.ToInt32(e.CommandArgument);
            SMHR_OFFLINEASSESSMENT_RESULT oSMHR_OFFLINEASSESSMENT_RESULT = new SMHR_OFFLINEASSESSMENT_RESULT();
            oSMHR_OFFLINEASSESSMENT_RESULT.OFFLINE_ASSESSMENTID = Convert.ToInt32(e.CommandArgument);
            oSMHR_OFFLINEASSESSMENT_RESULT.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            oSMHR_OFFLINEASSESSMENT_RESULT.OPERATION = operation.Get;
            RadOfflineResults.DataSource = BLL.get_OfflineAssessmentResult(oSMHR_OFFLINEASSESSMENT_RESULT);
            RadOfflineResults.DataBind();

            Rm_Course_page.SelectedIndex = 2;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_offline Assessments", ex.StackTrace, DateTime.Now);

            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


    }
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            // lbl_CourseHeader.Visible = false;
            rcmb_CC.Enabled = false;
            btn_Save.Visible = false;
            rfc_rcmb_CS.Enabled = false;

            rtxt_AssessmentName.Enabled = false;

            clearControls();
            LoadCombos();
            //LoadComboSchedule();

            //lbl_CourseName.Enabled = false;
            //DataTable dt = BLL.get_OfflineAssessment(new SMHR_TRAINING_OFFLINEASSESSMENTS(Convert.ToInt32(Convert.ToString(e.CommandArgument))));
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Update.Visible = false;

            }

            else
            {
                btn_Update.Visible = true;
            }


            lbl_OfflineassementId.Text = Convert.ToString(e.CommandArgument);
            SMHR_TRAINING_OFFLINEASSESSMENTS _obj_SMHR_Offlineassesments = new SMHR_TRAINING_OFFLINEASSESSMENTS();
            _obj_SMHR_Offlineassesments.OPERATION = operation.Get;
            _obj_SMHR_Offlineassesments.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_Offlineassesments.OFFLINEASSESSMENT_ID = Convert.ToInt32(lbl_OfflineassementId.Text);
            DataTable dt = BLL.get_OfflineAssessment(_obj_SMHR_Offlineassesments);

            if (dt.Rows.Count != 0)
            {



                rcmb_CC.SelectedIndex = rcmb_CC.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["OFFLINEASSESSMENT_COURSEID"]));
                radCourse_SelectedIndexChanged(null, null);
                rfc_rcmb_CS.SelectedIndex = rfc_rcmb_CS.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["OFFLINEASSESSMENT_COURSESCHEDULEID"]));

                rtxt_AssessmentName.Text = Convert.ToString(dt.Rows[0]["OFFLINEASSESSMENT_NAME"]);
                rad_IsActive.Checked = Convert.ToBoolean(dt.Rows[0]["OFFLINEASSESSMENT_STATUS"]);

                Rm_Course_page.SelectedIndex = 1;

            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_offline Assessments", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }




    protected void btn_Save_Click(object sender, EventArgs e)
    {

        try
        {
            if (((Button)sender).ID.ToUpper()=="BTN_UPDATE")
            {
                if (Convert.ToString(rad_IsActive.Checked) == "True")
                {
                    if (fileupload_upload.FileName == "")
                    {
                        BLL.ShowMessage(this, "Please Select a File to Upload");
                        return;
                    }
                }
            }
            SMHR_TRAINING_OFFLINEASSESSMENTS _obj_SMHR_Offlineassesments = new SMHR_TRAINING_OFFLINEASSESSMENTS();
            _obj_SMHR_Offlineassesments.OFFLINEASSESSMENT_COURSEID = Convert.ToInt32(rcmb_CC.SelectedValue);
            _obj_SMHR_Offlineassesments.OFFLINEASSESSMENT_COURSESCHEDULEID = Convert.ToInt32(rfc_rcmb_CS.SelectedValue);
            _obj_SMHR_Offlineassesments.OFFLINEASSESSMENT_NAME = rtxt_AssessmentName.Text;
            _obj_SMHR_Offlineassesments.OFFLINEASSESSMENT_UPLOADEDDOC = fileupload_upload.FileName;
            _obj_SMHR_Offlineassesments.OFFLINEASSESSMENT_CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_SMHR_Offlineassesments.OFFLINEASSESSMENT_CREATEDDATE = DateTime.Now;
            _obj_SMHR_Offlineassesments.OFFLINEASSESSMENT_ORGID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_Offlineassesments.OFFLINEASSESSMENT_MODYFIEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_SMHR_Offlineassesments.OFFLINEASSESSMENT_MODYFIEDDATE = DateTime.Now;
            _obj_SMHR_Offlineassesments.OFFLINEASSESSMENT_STATUS = rad_IsActive.Checked;
            if (fileupload_upload.HasFile)
            {
                string pdfName = rtxt_AssessmentName.Text + "_" + Guid.NewGuid().ToString() + "_FBIO" + fileupload_upload.FileName;
                string strPath = "~/EmpUploads/" + pdfName;
                fileupload_upload.PostedFile.SaveAs(Server.MapPath("~/EmpUploads/") + pdfName);
                _obj_SMHR_Offlineassesments.OFFLINEASSESSMENT_UPLOADEDDOC = strPath;
            }
            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_UPDATE":

                    _obj_SMHR_Offlineassesments.OFFLINEASSESSMENT_ID = Convert.ToInt32(lbl_OfflineassementId.Text);

                    _obj_SMHR_Offlineassesments.OPERATION = operation.Check;

                    _obj_SMHR_Offlineassesments.OPERATION = operation.Update;
                    if (BLL.set_OfflineAssessment(_obj_SMHR_Offlineassesments))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                case "BTN_SAVE":

                    _obj_SMHR_Offlineassesments.OPERATION = operation.Check;
                    if (Convert.ToString(BLL.get_OfflineAssessment(_obj_SMHR_Offlineassesments).Rows[0]["Count"]) != "0")
                    {
                        BLL.ShowMessage(this, "Assessment Name with this Name Already Exists");
                        return;
                    }
                    _obj_SMHR_Offlineassesments.OPERATION = operation.Insert;
                    if (BLL.set_OfflineAssessment(_obj_SMHR_Offlineassesments))
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                default:
                    break;
            }

            Rm_Course_page.SelectedIndex = 0;
            LoadGrid();
            Rg_Course.DataBind();


        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_offline Assessments", ex.StackTrace, DateTime.Now);

            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_offline_Assessments", ex.StackTrace, DateTime.Now);

            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Btn_Cancel1_Click(object sender, EventArgs e)
    {
        try
        {
            Rm_Course_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_offline Assessments", ex.StackTrace, DateTime.Now);

            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
   
    /*added by anusha 12/05/2015*/
  
    protected void RadOfflineResults_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            needdatasource();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_offline Assessments", ex.StackTrace, DateTime.Now);

            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}