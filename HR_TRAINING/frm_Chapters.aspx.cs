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
public partial class HR_TRAINING_frm_Chapters : System.Web.UI.Page
{
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Chapters");//COURSE");
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Chapters", ex.StackTrace, DateTime.Now);

            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }



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
            // lbl_CourseHeader.Visible = false;
            rcmb_CN.Enabled = false;

            clearControls();
            LoadDropDowns();
            //lbl_CourseName.Enabled = false;

            SMHR_CHAPTERS _obj_Smhr_Chapter = new SMHR_CHAPTERS();
            _obj_Smhr_Chapter.CHARPTER_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Chapter.CHAPTER_ID = Convert.ToInt32(e.CommandArgument);
            _obj_Smhr_Chapter.OPERATION = operation.Get;

            DataTable dt = BLL.get_Chapter(_obj_Smhr_Chapter);
            if (dt.Rows.Count != 0)
            {
                lbl_ChapterId.Text = Convert.ToString(dt.Rows[0]["CHAPTER_ID"]);
                rtxt_ChapterDesc.Text = Convert.ToString(dt.Rows[0]["CHAPTER_DESCRIPTION"]);
                rtxt_ChapterName.Text = Convert.ToString(dt.Rows[0]["CHAPTER_NAME"]);
                rcmb_CN.SelectedIndex = rcmb_CN.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["CHAPTER_COURSE_ID"]));
                rad_IsActive.Checked = Convert.ToBoolean(dt.Rows[0]["CHAPTER_STATUS"]);

                //rad_IsActive.Checked = true;

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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Chapters", ex.StackTrace, DateTime.Now);
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
            //lbl_CourseHeader.Visible = false;
            //loadDropdown();
            clearControls();
            LoadDropDowns();
            btn_Save.Visible = true;
            rcmb_CN.Enabled = true;
            Rm_Course_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Chapters", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion


    /// <summary>
    /// load grid methods
    /// </summary>
    /// 







    public void LoadGrid()
    {
        try
        {
            SMHR_CHAPTERS _obj_Smhr_Chapter = new SMHR_CHAPTERS();
            _obj_Smhr_Chapter.OPERATION = operation.Select;

            _obj_Smhr_Chapter.CHARPTER_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            DataTable DT = BLL.get_Chapter(_obj_Smhr_Chapter);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Chapters", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #region load SKILL
    /// <summary>
    /// load grid methods
    /// </summary>

    protected void Rg_Course_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Chapters", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
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
            SMHR_CHAPTERS _obj_Smhr_Chapter = new SMHR_CHAPTERS();

            _obj_Smhr_Chapter.CHAPTER_NAME = rtxt_ChapterName.Text;
            _obj_Smhr_Chapter.CHAPTER_DESCRIPTION = rtxt_ChapterDesc.Text;
            _obj_Smhr_Chapter.CHAPTER_COURSE_ID = Convert.ToInt32(rcmb_CN.SelectedValue);
            _obj_Smhr_Chapter.CHARPTER_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Chapter.CHAPTER_STATUS = rad_IsActive.Checked;
            _obj_Smhr_Chapter.CHAPTER_CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_Chapter.CHAPTER_CREATEDDATE = DateTime.Now;
            _obj_Smhr_Chapter.CHARPTER_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Chapter.CHAPTER_LASTMDFDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_Chapter.CHAPTER_LASTMDFDATE = DateTime.Now;


            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_UPDATE":
                    _obj_Smhr_Chapter.CHAPTER_ID = Convert.ToInt32(lbl_ChapterId.Text);
                    _obj_Smhr_Chapter.OPERATION = operation.Update;
                    if (Convert.ToBoolean(rad_IsActive.Checked) == false)
                    {
                        //SMHR_COURSESCHEDULE _obj_CourseSchedule = new SMHR_COURSESCHEDULE();
                        //_obj_CourseSchedule.OPERATION = operation.Check2;
                        //_obj_CourseSchedule.COURSESCHEDULEID = Convert.ToInt32(lblCourseScheduleID.Text);
                        SMHR_TRAINING_ONLINEASSESSMENT _obj_Online = new SMHR_TRAINING_ONLINEASSESSMENT();
                        _obj_Online.OPERATION = operation.Check2;
                        _obj_Online.TRAINING_ASSESSMENT_CHAPTER_ID = Convert.ToInt32(lbl_ChapterId.Text);



                        DataTable dt = BLL.get_OnlineAssessment(_obj_Online);

                        if (Convert.ToString(dt.Rows[0]["Count"]) != "0")
                        {
                            BLL.ShowMessage(this, "Cannot make inactive");
                            rad_IsActive.Checked = true;
                            return;
                        }
                    }


                    if (BLL.set_Chapter(_obj_Smhr_Chapter))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                case "BTN_SAVE":
                    _obj_Smhr_Chapter.OPERATION = operation.Check;
                    if (Convert.ToString(BLL.get_Chapter(_obj_Smhr_Chapter).Rows[0]["Count"]) != "0")
                    {
                        BLL.ShowMessage(this, "Chapter with this Name Already Exists");
                        return;
                    }
                    _obj_Smhr_Chapter.OPERATION = operation.Insert;
                    if (BLL.set_Chapter(_obj_Smhr_Chapter))
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Chapters", ex.StackTrace, DateTime.Now);

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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Chapters", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region load course based on organisation
    /// <summary>
    /// to load courses from master based on organisation
    /// </summary>


    protected void clearControls()
    {
        try
        {
            rtxt_ChapterDesc.Text = string.Empty;
            rtxt_ChapterName.Text = string.Empty;
            rcmb_CN.SelectedIndex = -1;
            btn_Save.Visible = false;
            btn_Update.Visible = false;
            Rm_Course_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Chapters", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    private void LoadDropDowns()
    {
        try
        {
            SMHR_COURSE _obj_Course = new SMHR_COURSE();
            _obj_Course.OPERATION = operation.Select2;
            _obj_Course.COURSE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            rcmb_CN.DataSource = BLL.get_Course(_obj_Course);
            rcmb_CN.DataTextField = "COURSE_NAME";
            rcmb_CN.DataValueField = "COURSE_ID";
            rcmb_CN.DataBind();
            rcmb_CN.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Chapters", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

}

