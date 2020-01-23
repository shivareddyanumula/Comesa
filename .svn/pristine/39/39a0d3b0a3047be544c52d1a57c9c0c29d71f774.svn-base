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

public partial class Training_frm_Course : System.Web.UI.Page
{
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_MASTERS _obj_Smhr_Masters;
    SMHR_COURSE _obj_Smhr_Course;
    SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit;


    #region pageload methods
    /// <summary>
    /// page load methods
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("COURSE");
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Course", ex.StackTrace, DateTime.Now);

            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    #endregion


    #region LoadBusineeUnit

    /// <summary>
    /// To Load BusinessUnit Details the Dropdown
    /// </summary>



    #endregion

    #region edit command methods
    /// <summary>
    /// to edit particular course based on command argument
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            //lbl_CourseHeader.Visible = false;
            rcmb_CC.Enabled = false;
            rtxt_CourseName.Enabled = false;
            clearControls();
            LoadCombos();
            //lbl_CourseName.Enabled = false;

            //lbl_labl.Text = Convert.ToString(e.CommandArgument);
            SMHR_COURSE oSMHR_COURSE = new SMHR_COURSE();
            oSMHR_COURSE.OPERATION = operation.Select;
            oSMHR_COURSE.COURSE_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            DataTable dt = BLL.get_Course(oSMHR_COURSE);
            if (dt.Rows.Count != 0)
            {

                lbl_CourseId.Text = Convert.ToString(dt.Rows[0]["COURSE_ID"]);
                rtxt_CourseName.Text = Convert.ToString(dt.Rows[0]["COURSE_NAME"]);
                rtxt_CourseDesc.Text = Convert.ToString(dt.Rows[0]["COURSE_DESC"]);
                rtxt_CDS.Text = Convert.ToString(dt.Rows[0]["COURSE_DESIGNEDFOR"]);
                radCourseDuration.Text = Convert.ToString(dt.Rows[0]["COURSE_DURATION"]);
                rcmb_CC.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem(Convert.ToString(dt.Rows[0]["HR_MASTER_CODE"]), Convert.ToString(dt.Rows[0]["COURSE_CATEGORYID"])));
                //rcmb_CC.SelectedIndex = rcmb_CC.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["COURSE_CATEGORYID"]));
                rad_IsActive.Checked = Convert.ToBoolean(dt.Rows[0]["COURSE_STATUS"]);
                hdnStatus.Value = Convert.ToString(dt.Rows[0]["COURSE_STATUS"]);
                if (rad_IsActive.Checked)
                {
                    rtxt_CourseDesc.Enabled = true;
                    rtxt_CDS.Enabled = true;
                    radCourseDuration.Enabled = true;
                }
                else
                {
                    rtxt_CourseDesc.Enabled = false;
                    rtxt_CDS.Enabled = false;
                    radCourseDuration.Enabled = false;
                }
                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    btn_Update.Visible = false;

                }

                else
                {
                    btn_Update.Visible = true;
                }

                Rm_Course_page.SelectedIndex = 1;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Course", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    #endregion


    #region add command
    /// <summary>
    /// add commnad methods
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            // lbl_CourseHeader.Visible = false;
            //loadDropdown();
            clearControls();
            LoadCombos();
            btn_Save.Visible = true;
            rcmb_CC.Enabled = true;
            rtxt_CourseName.Enabled = true;
            Rm_Course_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Course", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion


    /// <summary>
    /// load grid methods
    /// </summary>
    public void LoadGrid()
    {
        try
        {
            _obj_Smhr_Course = new SMHR_COURSE();
            _obj_Smhr_Course.COURSE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);

            DataTable DT = BLL.get_Course(_obj_Smhr_Course);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Course", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #region load SKILL
    /// <summary>
    /// load grid methods
    /// </summary>

    protected void Rg_Course_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        LoadGrid();
    }
    #endregion

    #region save click methods
    /// <summary>
    /// save click methods
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_Smhr_Course = new SMHR_COURSE();
            _obj_Smhr_Course.COURSE_NAME = BLL.ReplaceQuote(rtxt_CourseName.Text);
            _obj_Smhr_Course.COURSE_DESC = BLL.ReplaceQuote(rtxt_CourseDesc.Text);
            _obj_Smhr_Course.COURSE_CATEGORYID = rcmb_CC.SelectedItem.Value;
            _obj_Smhr_Course.COURSE_DURATION = Convert.ToInt32(radCourseDuration.Text);
            _obj_Smhr_Course.COURSE_STATUS = rad_IsActive.Checked;

            _obj_Smhr_Course.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_Course.CREATEDDATE = DateTime.Now;
            _obj_Smhr_Course.COURSE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Course.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_Course.LASTMDFDATE = DateTime.Now;
            _obj_Smhr_Course.COURSE_DESIGNEDFOR = rtxt_CDS.Text;

            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_UPDATE":
                    if (rad_IsActive.Checked == false && rad_IsActive.Checked == Convert.ToBoolean(hdnStatus.Value))
                    {
                        BLL.ShowMessage(this, "There is no data to update");
                        Rm_Course_page.SelectedIndex = 0;
                        LoadGrid();
                        return;
                    }
                    if (rad_IsActive.Checked)
                    {
                        _obj_Smhr_Course.OPERATION = operation.Select1;
                        if (!Convert.ToBoolean(BLL.get_Course(_obj_Smhr_Course).Rows[0]["HR_MASTER_STATUS"]))
                        {
                            BLL.ShowMessage(this, "Please Change Course Category Status to Active for this Course");
                            Rm_Course_page.SelectedIndex = 0;
                            LoadGrid();
                            return;
                        }
                    }
                    else
                    {
                        SMHR_COURSESCHEDULE _obj_CS = new SMHR_COURSESCHEDULE();
                        _obj_CS.OPERATION = operation.Online;
                        _obj_CS.COURSESCHEDULE_COURSEID = Convert.ToInt32(lbl_CourseId.Text);
                        _obj_CS.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        // _obj_CS.COURSESCHEDULE_STATUS=rad_IsActive.Checked;
                        DataTable dtc = BLL.get_CourseSchedule(_obj_CS);
                        if (!Convert.ToBoolean(dtc.Rows[0]["Status"]))
                        {
                            BLL.ShowMessage(this, Convert.ToString(dtc.Rows[0]["ErrorMessage"]));
                            rad_IsActive.Checked = true;
                            Rm_Course_page.SelectedIndex = 0;
                            LoadGrid();
                            return;
                        }
                    }
                    //if (Convert.ToBoolean(rad_IsActive.Checked) == false)
                    //{
                    //    SMHR_TRAINERPROFILE _obj_Trainer = new SMHR_TRAINERPROFILE();
                    //    _obj_Trainer.TRAINER_ORGID = Convert.ToInt32(Session["ORG_ID"]);
                    //    _obj_Trainer.Trainer_CourseCategory = Convert.ToInt32(lbl_CourseId.Text);
                    //    _obj_Trainer.OPERATION = operation.Scale;
                    //    DataTable dt = BLL.get_TrainingProfile(_obj_Trainer);
                    //    if (!Convert.ToBoolean(dt.Rows[0]["Status"]))
                    //    {
                    //        BLL.ShowMessage(this, "Cannot make inactive");
                    //        rad_IsActive.Checked = true;
                    //        return;
                    //    }
                    //}
                    _obj_Smhr_Course.COURSE_ID = Convert.ToInt32(lbl_CourseId.Text);
                    _obj_Smhr_Course.OPERATION = operation.Update;
                    if (BLL.set_Course(_obj_Smhr_Course))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                case "BTN_SAVE":
                    _obj_Smhr_Course.OPERATION = operation.Check;
                    if (Convert.ToString(BLL.get_Course(_obj_Smhr_Course).Rows[0]["Count"]) != "0")
                    {
                        BLL.ShowMessage(this, "Course with this Name Already Exists");
                        return;
                    }
                    _obj_Smhr_Course.OPERATION = operation.Insert;
                    if (BLL.set_Course(_obj_Smhr_Course))
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Course", ex.StackTrace, DateTime.Now);

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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Course", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region load course based on organisation
    /// <summary>
    /// to load courses from master based on organisation
    /// </summary>
    private void LoadCombos()
    {
        try
        {
            _obj_Smhr_Masters = new SMHR_MASTERS();
            //Load PayItem Type
            rcmb_CC.Items.Clear();
            _obj_Smhr_Masters.MASTER_TYPE = "COURSE";
            _obj_Smhr_Masters.OPERATION = operation.Select1;
            _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            rcmb_CC.DataSource = BLL.get_MasterRecords(_obj_Smhr_Masters);
            rcmb_CC.DataTextField = "HR_MASTER_CODE";
            rcmb_CC.DataValueField = "HR_MASTER_ID";
            rcmb_CC.DataBind();
            rcmb_CC.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Course", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    protected void clearControls()
    {
        rtxt_CDS.Text = string.Empty;
        rtxt_CourseName.Text = string.Empty;
        radCourseDuration.Text = string.Empty;
        rtxt_CourseDesc.Text = string.Empty;
        rcmb_CC.SelectedIndex = -1;
        btn_Save.Visible = false;
        btn_Update.Visible = false;
        Rm_Course_page.SelectedIndex = 0;
    }

    #endregion







}
