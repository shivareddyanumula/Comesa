using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class PMS_TrainingRequestPopup : System.Web.UI.Page
{
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_MASTERS _obj_Smhr_Masters;
    SMHR_TRAINING_LOCATION _obj_Smhr_Location;
    SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (!Page.IsPostBack)
            {
                lbl_CourseHeader.Visible = true;
                Page.Validate();
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
                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    Rg_Course.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;

                }
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "TrainingRequestPopup", ex.StackTrace, DateTime.Now);

            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }
    protected void lnk_Apply_Command(object sender, CommandEventArgs e)
    {
        try
        {
            if (Request.QueryString.HasKeys())
            {
                SMHR_TRAINING_REQUST _obj_Smhr_TrainigRequest = new SMHR_TRAINING_REQUST();
                _obj_Smhr_TrainigRequest.TRAINING_ISAPPROVED = 1;
                _obj_Smhr_TrainigRequest.TRAINING_RAISEDBY = Convert.ToInt32(Request.QueryString["EMP_ID"]);
                _obj_Smhr_TrainigRequest.TRAINING_BATCHID = Convert.ToInt32(e.CommandArgument);
                //_obj_Smhr_TrainigRequest.TRAINING_RAISEDBY = Convert.ToInt32(Session["EMP_ID"]);
                _obj_Smhr_TrainigRequest.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_Smhr_TrainigRequest.CREATEDDATE = DateTime.Now;
                _obj_Smhr_TrainigRequest.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_TrainigRequest.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_Smhr_TrainigRequest.LASTMDFDATE = DateTime.Now;
                _obj_Smhr_TrainigRequest.OPERATION = operation.Insert1;

                if (BLL.set_TrainigRequest(_obj_Smhr_TrainigRequest))
                {
                    BLL.ShowMessage(this, "Information Saved Successfully");
                    Rm_Course_page.SelectedIndex = 0;
                    LoadGrid();
                    Rg_Course.DataBind();
                }
                else
                    BLL.ShowMessage(this, "Information Not Saved");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "TrainingRequestPopup", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            lbl_CourseHeader.Visible = false;

            clearControls();
            LoadCombos();
            _obj_Smhr_Location = new SMHR_TRAINING_LOCATION();
            _obj_Smhr_Location.LocationID = Convert.ToInt32(e.CommandArgument);
            _obj_Smhr_Location.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Location.OPERATION = operation.Get;
            DataTable dt = BLL.get_TrainingLocation(_obj_Smhr_Location);
            if (dt.Rows.Count != 0)
            {


                Rm_Course_page.SelectedIndex = 1;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "TrainingRequestPopup", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    private void BindBatches()
    {
        try
        {
            if (Request.QueryString.HasKeys())
            {

                SMHR_COURSESCHEDULE _obj_Smhr_CourseSchedule = new SMHR_COURSESCHEDULE();
                _obj_Smhr_CourseSchedule.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_CourseSchedule.COURSESCHEDULE_COURSEID = Convert.ToInt32(radCourse.SelectedValue);
                _obj_Smhr_CourseSchedule.CREATEDBY = Convert.ToInt32(Request.QueryString["EMP_ID"]);
                _obj_Smhr_CourseSchedule.OPERATION = operation.Select2;
                DataTable DT = BLL.get_CourseSchedule(_obj_Smhr_CourseSchedule);
                if (DT.Rows.Count != 0)
                {
                    RGBatcheDetails.DataSource = DT;
                }

                else
                {
                    DataTable dt1 = new DataTable();
                    RGBatcheDetails.DataSource = dt1;
                }
                RGBatcheDetails.DataBind();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "TrainingRequestPopup", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            lbl_CourseHeader.Visible = false;
            clearControls();
            LoadCombos();
            RGBatcheDetails.Visible = false;
            Rm_Course_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "TrainingRequestPopup", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void LoadGrid()
    {
        try
        {
            if (Request.QueryString.HasKeys())
            {
                SMHR_TRAINING_REQUST _obj_smhr_training_requst = new SMHR_TRAINING_REQUST();
                _obj_smhr_training_requst.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //_obj_smhr_training_requst.TRAINING_RAISEDBY = Convert.ToInt32(Session["EMP_ID"]);
                _obj_smhr_training_requst.TRAINING_RAISEDBY = Convert.ToInt32(Request.QueryString["EMP_ID"]);
                _obj_smhr_training_requst.OPERATION = operation.Select;
                DataTable DT = BLL.get_TrainigRequest(_obj_smhr_training_requst);
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
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "TrainingRequestPopup", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "TrainingRequestPopup", ex.StackTrace, DateTime.Now);
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
            radCourse.DataSource = BLL.get_Course(_obj_Course);
            radCourse.DataTextField = "COURSE_NAME";
            radCourse.DataValueField = "COURSE_ID";
            radCourse.DataBind();
            radCourse.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "TrainingRequestPopup", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void clearControls()
    {
        try
        {
            Rm_Course_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "TrainingRequestPopup", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    protected void radCourse_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (string.Compare(radCourse.SelectedItem.Text, "Select", true) != 0)
            {
                BindBatches();
                RGBatcheDetails.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "TrainingRequestPopup", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            Rm_Course_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "TrainingRequestPopup", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /*added by anusha for need datasource 21/05/2015*/
    private void BindBatchesSource()
    {
        try
        {
            SMHR_COURSESCHEDULE _obj_Smhr_CourseSchedule = new SMHR_COURSESCHEDULE();
            _obj_Smhr_CourseSchedule.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            if (!string.IsNullOrEmpty(radCourse.SelectedValue))
            {
                _obj_Smhr_CourseSchedule.COURSESCHEDULE_COURSEID = Convert.ToInt32(radCourse.SelectedValue);
                _obj_Smhr_CourseSchedule.CREATEDBY = Convert.ToInt32(Session["EMP_ID"]);
                _obj_Smhr_CourseSchedule.OPERATION = operation.Select2;
                DataTable DT = BLL.get_CourseSchedule(_obj_Smhr_CourseSchedule);
                if (DT.Rows.Count != 0)
                {
                    RGBatcheDetails.DataSource = DT;
                }

                else
                {
                    DataTable dt1 = new DataTable();
                    RGBatcheDetails.DataSource = dt1;
                }
            }
            else
            {
                DataTable dt1 = new DataTable();
                RGBatcheDetails.DataSource = dt1;

            }
            /*commented by anusha 12/05/2015*/
            //  RGBatcheDetails.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void RGBatcheDetails_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            BindBatchesSource();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

}