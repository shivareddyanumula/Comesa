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
                //code for security privilage
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
                    btn_Save.Visible = false;
                    btn_Update.Visible = false;
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
                LoadBusinessUnit();
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

    protected void LoadBusinessUnit()
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
                rcmb_BusinessUnitType.DataSource = dt_BUDetails;
                rcmb_BusinessUnitType.DataValueField = "BUSINESSUNIT_ID";
                rcmb_BusinessUnitType.DataTextField = "BUSINESSUNIT_CODE";
                rcmb_BusinessUnitType.DataBind();
                rcmb_BusinessUnitType.Items.Insert(0, new RadComboBoxItem("Select"));
            }

            else
            {
                DataTable dt_Details = new DataTable();
                rcmb_BusinessUnitType.DataSource = dt_BUDetails;

                rcmb_BusinessUnitType.DataBind();
                rcmb_BusinessUnitType.Items.Insert(0, new RadComboBoxItem("Select"));
            }



        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Course", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

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
            lbl_CourseHeader.Visible = false;
            rcmb_CC.Enabled = false;
            rcmb_BusinessUnitType.Enabled = false;


            clearControls();
            LoadCombos();
            //lbl_CourseName.Enabled = false;
            DataTable dt = BLL.get_Course(new SMHR_COURSE(Convert.ToInt32(Convert.ToString(e.CommandArgument))));
            if (dt.Rows.Count != 0)
            {
                lbl_CourseId.Text = Convert.ToString(dt.Rows[0]["COURSE_ID"]);
                LoadBusinessUnit();
                rcmb_BusinessUnitType.SelectedIndex = rcmb_BusinessUnitType.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["COURSE_BUSINESSUNIT_ID"]));
                rtxt_CourseName.Text = Convert.ToString(dt.Rows[0]["COURSE_NAME"]);
                rtxt_CourseDesc.Text = Convert.ToString(dt.Rows[0]["COURSE_DESC"]);
                rcmb_CC.SelectedIndex = rcmb_CC.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["COURSE_CATEGORYID"]));
                //LoadSkill();
                SMHR_TRAININGREQUEST _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();
                _obj_Smhr_TrgRqst.TR_DESCRIPTION = Convert.ToString(dt.Rows[0]["COURSE_SKILL_WID"]);
                _obj_Smhr_TrgRqst.Mode = 28;//addinbll
                DataTable DT = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);
                if (DT.Rows.Count != 0)
                {
                    rlb_skills.DataSource = DT;
                    rlb_skills.DataValueField = "HR_MASTER_ID";
                    rlb_skills.DataTextField = "HR_MASTER_CODE";
                    rlb_skills.DataBind();
                }


                skil_id.Visible = true;


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
            lbl_CourseHeader.Visible = false;
            //loadDropdown();
            clearControls();
            LoadCombos();
            skil_id.Visible = false;
            LoadBusinessUnit();
            rcmb_BusinessUnitType.SelectedIndex = 0;
            btn_Save.Visible = true;
            rcmb_BusinessUnitType.Enabled = true;
            rcmb_CC.Enabled = true;
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
    public void LoadSkill()
    {
        try
        {
            if (rcmb_BusinessUnitType.SelectedItem.Text != "SELECT")
            {
                SMHR_TRAININGREQUEST _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();
                _obj_Smhr_TrgRqst.TR_LASTMDFBY = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
                _obj_Smhr_TrgRqst.Mode = 23;//addinbll
                DataTable DT = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);
                if (DT.Rows.Count != 0)
                {
                    rlb_skills.DataSource = DT;
                    rlb_skills.DataValueField = "HR_MASTER_ID";
                    rlb_skills.DataTextField = "HR_MASTER_CODE";
                    rlb_skills.DataBind();
                }

                else
                {
                    DataTable dt1 = new DataTable();
                    rlb_skills.DataSource = dt1;
                    rlb_skills.DataBind();
                }
                clearControls();
            }

            else
            {
                BLL.ShowMessage(this, "Please Select Business Unit");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Course", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
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

            if ((rlb_skills.Items.Count != 0))
            {
                Label Label1 = new Label();
                StringBuilder sb = new StringBuilder();
                IList<RadListBoxItem> collection = rlb_skills.CheckedItems;
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
                _obj_Smhr_Course = new SMHR_COURSE();
                if (Label1.Text == "")
                {
                    _obj_Smhr_Course.COURSE_SKILL_WID = Convert.ToString(0);
                }
                else
                {
                    _obj_Smhr_Course.COURSE_SKILL_WID = Convert.ToString(Label1.Text);
                }

                _obj_Smhr_Course.COURSE_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
                _obj_Smhr_Course.COURSE_NAME = BLL.ReplaceQuote(rtxt_CourseName.Text.ToUpper());
                _obj_Smhr_Course.COURSE_DESC = BLL.ReplaceQuote(rtxt_CourseDesc.Text);
                _obj_Smhr_Course.COURSE_CATEGORYID = rcmb_CC.SelectedItem.Value;

                _obj_Smhr_Course.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                _obj_Smhr_Course.CREATEDDATE = DateTime.Now;
                _obj_Smhr_Course.COURSE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_Course.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                _obj_Smhr_Course.LASTMDFDATE = DateTime.Now;

                switch (((Button)sender).ID.ToUpper())
                {
                    case "BTN_UPDATE":
                        _obj_Smhr_Course.COURSE_ID = Convert.ToInt32(lbl_CourseId.Text);
                        _obj_Smhr_Course.COURSE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Smhr_Course.OPERATION = operation.Check;
                        if (Convert.ToString(BLL.get_Course(_obj_Smhr_Course).Rows[0]["Count"]) != "1")
                        {
                            BLL.ShowMessage(this, "Course with this Name Already Exists");
                            return;
                        }
                        _obj_Smhr_Course.OPERATION = operation.Update;
                        if (BLL.set_Course(_obj_Smhr_Course))
                            BLL.ShowMessage(this, "Information Updated Successfully");
                        else
                            BLL.ShowMessage(this, "Information Not Saved");
                        break;
                    case "BTN_SAVE":
                        _obj_Smhr_Course.OPERATION = operation.Check;
                        _obj_Smhr_Course.COURSE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
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

            else
            {
                BLL.ShowMessage(this, "Select Skills");
                return;
            }
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
        try
        {
            rtxt_CourseName.Text = string.Empty;
            rtxt_CourseDesc.Text = string.Empty;
            rcmb_CC.SelectedIndex = -1;
            btn_Save.Visible = false;
            btn_Update.Visible = false;
            Rm_Course_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Course", ex.StackTrace, DateTime.Now);

            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion




    protected void rcmb_BusinessUnitType_indexchanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_BusinessUnitType.SelectedItem.Text != "Select")
            {

                skil_id.Visible = true;

                LoadSkill();
                Rm_Course_page.SelectedIndex = 1;
                btn_Save.Visible = true;
            }

            else
            {
                skil_id.Visible = false;
                BLL.ShowMessage(this, "Select Type");
                Rm_Course_page.SelectedIndex = 1;
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Course", ex.StackTrace, DateTime.Now);

            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }


}
