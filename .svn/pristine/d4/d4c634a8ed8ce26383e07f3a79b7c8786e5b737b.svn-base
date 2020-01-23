using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using SMHR;
using RECRUITMENT;

public partial class Recruitment_frm_recruitmentskillscategary : System.Web.UI.Page
{
    RECRUITMENT_SKILLSCATEGARY _obj_Rec_SkillCategary;
    SMHR_MASTERS _obj_Smhr_Masters;

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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Skill Category");//COUNTRY");
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
                    RG_SkillsCategary.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
                RM_SkillsCategary.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_recruitmentskillscategary", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        Page.Validate();
    }

    private void Loadskills()
    {
        try
        {
            _obj_Smhr_Masters = new SMHR_MASTERS();
            _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Masters.MASTER_TYPE = "SKILL";
            // _obj_smhr_masters.MODE =3;
            _obj_Smhr_Masters.OPERATION = operation.Select;
            DataTable dt_skills = new DataTable();
            dt_skills = BLL.get_MasterRecords(_obj_Smhr_Masters);
            RCMB_Skills.DataSource = dt_skills;
            RCMB_Skills.DataTextField = "HR_MASTER_CODE";
            RCMB_Skills.DataValueField = "HR_MASTER_ID";
            RCMB_Skills.DataBind();
            RCMB_Skills.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_recruitmentskillscategary", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void loadgrid()
    {
        try
        {
            _obj_Rec_SkillCategary = new RECRUITMENT_SKILLSCATEGARY();
            _obj_Rec_SkillCategary.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Rec_SkillCategary.MODE = 7;
            DataTable dt = Recruitment_BLL.get_skillscategary(_obj_Rec_SkillCategary);
            if (dt.Rows.Count != 0)
            {
                RG_SkillsCategary.DataSource = dt;
                RG_SkillsCategary.DataBind();
            }
            else
            {
                DataTable dt1 = new DataTable();
                RG_SkillsCategary.DataSource = dt1;
                RG_SkillsCategary.DataBind();

                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_recruitmentskillscategary", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            clearfields();
            RCMB_Skills.Items.Clear();
            btn_Update.Visible = false;
            btn_Save.Visible = true;
            RM_SkillsCategary.SelectedIndex = 1;
            Loadskills();
            RT_Skillname.Enabled = true;
            RCMB_Skills.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_recruitmentskillscategary", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        _obj_Rec_SkillCategary = new RECRUITMENT_SKILLSCATEGARY();
        try
        {
            //  _obj_Rec_SkillCategary.MODE = 3;
            _obj_Rec_SkillCategary.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //_obj_Pms_Ratings.RATINGS_NAME = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_RatingName.Text))

            _obj_Rec_SkillCategary.SKILLCAT_DESCRIPTION = Recruitment_BLL.ReplaceQuote(Convert.ToString(RT_SkillDesc.Text));
            _obj_Rec_SkillCategary.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_Rec_SkillCategary.LASTMDFDATE = DateTime.Now;
            _obj_Rec_SkillCategary.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_Rec_SkillCategary.CREATEDDATE = DateTime.Now;

            _obj_Rec_SkillCategary.SKILLCAT_SKILLID = Convert.ToInt32(RCMB_Skills.SelectedItem.Value);
            _obj_Rec_SkillCategary.SKILLCAT_NAME = Recruitment_BLL.ReplaceQuote(Convert.ToString(RT_Skillname.Text));


            _obj_Rec_SkillCategary.MODE = 8;
            DataTable dt_Skills = Recruitment_BLL.get_skillscategary(_obj_Rec_SkillCategary);
            if (Convert.ToString(dt_Skills.Rows[0]["Count"]) != "0")
            {
                Recruitment_BLL.ShowMessage(this, "This Combination Already Exists");
                return;
            }
            _obj_Rec_SkillCategary.MODE = 3;
            _obj_Rec_SkillCategary.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            bool status = Recruitment_BLL.set_skillscategary(_obj_Rec_SkillCategary);
            if (status == true)
            {
                Recruitment_BLL.ShowMessage(this, "Skills Inserted Succesfully");
                loadgrid();
                //clearfields();
                RM_SkillsCategary.SelectedIndex = 0;
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_recruitmentskillscategary", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void RG_Skillscategary_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            _obj_Rec_SkillCategary = new RECRUITMENT_SKILLSCATEGARY();
            _obj_Rec_SkillCategary.MODE = 7;
            _obj_Rec_SkillCategary.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = Recruitment_BLL.get_skillscategary(_obj_Rec_SkillCategary);
            RG_SkillsCategary.DataSource = dt;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_recruitmentskillscategary", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {

        clearfields();
        try
        {
            _obj_Rec_SkillCategary = new RECRUITMENT_SKILLSCATEGARY();
            _obj_Rec_SkillCategary.MODE = 2;
            _obj_Rec_SkillCategary.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Rec_SkillCategary.SKILLCAT_ID = Convert.ToInt32(e.CommandArgument);
            DataTable DT = Recruitment_BLL.get_skillscategary(_obj_Rec_SkillCategary);
            lbl_id.Text = Convert.ToString(DT.Rows[0]["SKILLCAT_ID"]);
            RCMB_Skills.SelectedIndex = RCMB_Skills.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["SKILLCAT_SKILLID"]));
            RT_Skillname.Text = Recruitment_BLL.ReplaceQuote(Convert.ToString(DT.Rows[0]["SKILLCAT_NAME"]));
            RT_SkillDesc.Text = Recruitment_BLL.ReplaceQuote(Convert.ToString(DT.Rows[0]["SKILLCAT_DESCRIPTION"]));
            RM_SkillsCategary.SelectedIndex = 1;
            btn_Save.Visible = true;
            btn_Save.Visible = false;
            btn_Update.Visible = true;
            RT_SkillDesc.Enabled = true;
            RT_Skillname.Enabled = false;
            RCMB_Skills.Enabled = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_recruitmentskillscategary", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Update_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_Rec_SkillCategary = new RECRUITMENT_SKILLSCATEGARY();
            _obj_Rec_SkillCategary.SKILLCAT_ID = Convert.ToInt32(lbl_id.Text);
            _obj_Rec_SkillCategary.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Rec_SkillCategary.SKILLCAT_NAME = Recruitment_BLL.ReplaceQuote(Convert.ToString(RT_Skillname.Text));
            _obj_Rec_SkillCategary.SKILLCAT_DESCRIPTION = Recruitment_BLL.ReplaceQuote(Convert.ToString(RT_SkillDesc.Text));
            _obj_Rec_SkillCategary.SKILLCAT_SKILLID = Convert.ToInt32(RCMB_Skills.SelectedValue);

            _obj_Rec_SkillCategary.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_Rec_SkillCategary.LASTMDFDATE = DateTime.Now;
            //_obj_Rec_SkillCategary.MODE = 8;

            //if (Convert.ToString(Recruitment_BLL.get_skillscategary(_obj_Rec_SkillCategary).Rows[0]["Count"]) != "0")
            //{
            //    Recruitment_BLL.ShowMessage(this, "This Combination Already Exists");
            //    return;
            //}
            _obj_Rec_SkillCategary.MODE = 4;

            bool status = Recruitment_BLL.set_skillscategary(_obj_Rec_SkillCategary);
            if (status == true)
            {
                Recruitment_BLL.ShowMessage(this, "Skills Updated Succesfully");
                loadgrid();
                btn_Update.Visible = true;
                RM_SkillsCategary.SelectedIndex = 0;
            }
            else
            {
                Recruitment_BLL.ShowMessage(this, "Unable to Update the record,Execption Occured");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_recruitmentskillscategary", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            RM_SkillsCategary.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_recruitmentskillscategary", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void clearfields() // CHANGE IT
    {
        try
        {
            RT_SkillDesc.Text = string.Empty;
            RT_Skillname.Text = string.Empty;

            RCMB_Skills.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_recruitmentskillscategary", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

}
