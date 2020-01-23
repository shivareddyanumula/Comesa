using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using RECRUITMENT;
using System.Data;
using Telerik.Web.UI;
public partial class Recruitment_frm_skill : System.Web.UI.Page
{
    #region References

    RECRUITMENT_SKILLSCATEGARY _obj_Rec_SkillCategary;
    SMHR_MASTERS _obj_Smhr_Masters;

    #endregion

    #region PageLoad

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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Skill");//APPLICANT");
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
                    RG_Skillscategary.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
                Loadskills();
                RM_Skillscategary.SelectedIndex = 0;
            }
            Page.Validate();
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_skill", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected override void InitializeCulture()
    {
        Recruitment_BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    #endregion

    #region Loadskills

    private void Loadskills()
    {
        try
        {
            _obj_Smhr_Masters = new SMHR_MASTERS();
            _obj_Smhr_Masters.MASTER_TYPE = "SKILL";
            _obj_Smhr_Masters.OPERATION = operation.Select;
            DataTable dt_skills = BLL.get_MasterRecords(_obj_Smhr_Masters);
            RCB_Skills.DataSource = dt_skills;
            RCB_Skills.DataTextField = "HR_MASTER_CODE";
            RCB_Skills.DataValueField = "HR_MASTER_ID";
            RCB_Skills.DataBind();
            RCB_Skills.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_skill", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region loadgrid

    protected void loadgrid()
    {
        try
        {
            _obj_Rec_SkillCategary = new RECRUITMENT_SKILLSCATEGARY();
            _obj_Rec_SkillCategary.MODE = 1;
            DataTable dt = Recruitment_BLL.get_skillscategary(_obj_Rec_SkillCategary);
            RG_Skillscategary.DataSource = dt;
            RG_Skillscategary.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_skill", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    protected void RG_Skillscategary_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            _obj_Rec_SkillCategary = new RECRUITMENT_SKILLSCATEGARY();
            _obj_Rec_SkillCategary.MODE = 1;
            DataTable dt = Recruitment_BLL.get_skillscategary(_obj_Rec_SkillCategary);
            RG_Skillscategary.DataSource = dt;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_skill", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            RM_Skillscategary.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_skill", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        _obj_Rec_SkillCategary = new RECRUITMENT_SKILLSCATEGARY();
        try
        {
            _obj_Rec_SkillCategary.MODE = 3;
            //_obj_Pms_Ratings.RATINGS_NAME = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_RatingName.Text))
            _obj_Rec_SkillCategary.SKILLCAT_SKILLID = Convert.ToInt32(RCB_Skills.SelectedItem.Text);
            _obj_Rec_SkillCategary.SKILLCAT_NAME = Recruitment_BLL.ReplaceQuote(Convert.ToString(txt_Skillname.Text));
            _obj_Rec_SkillCategary.SKILLCAT_DESCRIPTION = Recruitment_BLL.ReplaceQuote(Convert.ToString(txt_Description.Text));
            _obj_Rec_SkillCategary.LASTMDFBY = 1; // ### Need to Get the Session
            _obj_Rec_SkillCategary.LASTMDFDATE = DateTime.Now;
            _obj_Rec_SkillCategary.CREATEDBY = 2; // ### Need to Get the Session
            _obj_Rec_SkillCategary.CREATEDDATE = DateTime.Now;
            bool status = Recruitment_BLL.set_skillscategary(_obj_Rec_SkillCategary);
            if (status == true)
            {
                Recruitment_BLL.ShowMessage(this, "Skills Inserted Succesfully");
                loadgrid();
                clearfields();
                RM_Skillscategary.SelectedIndex = 0;
                return;
            }
            else
            {
                Recruitment_BLL.ShowMessage(this, "Unable to Update the record,Execption Occured");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_skill", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Commnad(object sender, CommandEventArgs e)
    {
        try
        {
            clearfields();
            _obj_Rec_SkillCategary = new RECRUITMENT_SKILLSCATEGARY();
            _obj_Rec_SkillCategary.MODE = 2;
            _obj_Rec_SkillCategary.SKILLCAT_ID = Convert.ToInt32(e.CommandArgument);
            DataTable DT = Recruitment_BLL.get_skillscategary(_obj_Rec_SkillCategary);
            lbl_id.Text = Convert.ToString(DT.Rows[0]["SKILLCAT_ID"]);
            RCB_Skills.SelectedIndex = Convert.ToInt32(RCB_Skills.Items.FindItemByValue(Convert.ToString(DT.Rows[0]["SKILLCAT_SKILLID"])));
            txt_Skillname.Text = Recruitment_BLL.ReplaceQuote(Convert.ToString(DT.Rows[0]["SKILLCAT_NAME"]));
            txt_Description.Text = Recruitment_BLL.ReplaceQuote(Convert.ToString(DT.Rows[0]["SKILLCAT_DESCRIPTION"]));
            RM_Skillscategary.SelectedIndex = 1;
            btn_Save.Visible = true;
            btn_Save.Visible = false;
            btn_Update.Visible = true;
            txt_Description.Enabled = true;
            txt_Skillname.Enabled = false;
            RCB_Skills.Enabled = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_skill", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Update_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_Rec_SkillCategary = new RECRUITMENT_SKILLSCATEGARY();
            _obj_Rec_SkillCategary.SKILLCAT_ID = Convert.ToInt32(lbl_id.Text);
            _obj_Rec_SkillCategary.SKILLCAT_NAME = Recruitment_BLL.ReplaceQuote(Convert.ToString(txt_Skillname.Text));
            _obj_Rec_SkillCategary.SKILLCAT_DESCRIPTION = Recruitment_BLL.ReplaceQuote(Convert.ToString(txt_Description.Text));
            _obj_Rec_SkillCategary.SKILLCAT_SKILLID = Convert.ToInt32(RCB_Skills.SelectedValue);
            _obj_Rec_SkillCategary.LASTMDFBY = 1; // ### Need to Get the Session
            _obj_Rec_SkillCategary.LASTMDFDATE = DateTime.Now;
            _obj_Rec_SkillCategary.MODE = 4;
            bool status = Recruitment_BLL.set_skillscategary(_obj_Rec_SkillCategary);
            if (status == true)
            {
                Recruitment_BLL.ShowMessage(this, "Skills Updated Succesfully");
                loadgrid();
                btn_Update.Visible = true;
                RM_Skillscategary.SelectedIndex = 0;
            }
            else
            {
                Recruitment_BLL.ShowMessage(this, "Unable to Update the record,Execption Occured");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_skill", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void clearfields() // CHANGE IT
    {
        try
        {
            txt_Description.Text = string.Empty;
            txt_Skillname.Text = string.Empty;
            RCB_Skills.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_skill", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //protected void lnk_Add_Command(object sender, CommandEventArgs e)
    //{
    //    //clearControls();
    //    //btn_Save.Visible = true;
    //    //btn_Update.Visible = false;
    //    RM_Skillscategary.SelectedIndex = 1;
    //}

}
