using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using SMHR;

public partial class Selfservice_Skills : System.Web.UI.Page
{
    SMHR_EMPLOYEE _obj_smhr_employee;
    SMHR_MASTERS _obj_smhr_masters;
    SMHR_APPLICANT _obj_smhr_applicant;
    static string _lbl_ID = "";
    static string _lbl_Emp_Id = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                LoadSkill();
                LoadCombos();
                clearSkillFields();
            }
            LoadSkill();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Skills", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Skill_Add_Click(object sender, EventArgs e)
    {
        try
        {
            if (Check_Combo(RG_Skills, "lbl_Skill_ID", rcb_Skill))
            {
                _obj_smhr_employee = new SMHR_EMPLOYEE();
                _obj_smhr_employee.EMP_ID = Convert.ToInt32(Request.QueryString["ID"]);
                _obj_smhr_employee.Mode = 1;
                DataTable dt = BLL.get_EmpESS(_obj_smhr_employee);
                if (dt.Rows.Count != 0)
                {
                    _lbl_Emp_Id = Convert.ToString(dt.Rows[0]["EMP_APPLICANT_ID"]);
                }
                _obj_smhr_applicant = new SMHR_APPLICANT();
                bool status = false;
                _obj_smhr_applicant.OPERATION = operation.Insert;
                _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(_lbl_Emp_Id);
                _obj_smhr_applicant.APPSKL_SKILL_ID = Convert.ToInt32(rcb_Skill.SelectedItem.Value);
                _obj_smhr_applicant.APPSKL_LASTUSED = Convert.ToInt32(rcb_YearLastUsed.SelectedItem.Text);
                _obj_smhr_applicant.APPSKL_EXPERT = Convert.ToInt32(rcb_ExpertLevel.SelectedValue);
                _obj_smhr_applicant.APPSKL_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_smhr_applicant.APPSKL_CREATEDDATE = DateTime.Now;
                status = BLL.set_ApplicantSkills(_obj_smhr_applicant);
                clearSkillFields();
                LoadSkill();
            }
            else
            {
                BLL.ShowMessage(this, "This Skill Set has already been added");
                rcb_Skill.Focus();
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Skills", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Skill_Correct_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_smhr_employee = new SMHR_EMPLOYEE();
            _obj_smhr_employee.EMP_ID = Convert.ToInt32(Request.QueryString["ID"]);
            _obj_smhr_employee.Mode = 1;
            DataTable dt = BLL.get_EmpESS(_obj_smhr_employee);
            if (dt.Rows.Count != 0)
            {
                _lbl_Emp_Id = Convert.ToString(dt.Rows[0]["EMP_APPLICANT_ID"]);
            }
            _obj_smhr_applicant = new SMHR_APPLICANT();
            bool status = false;
            _obj_smhr_applicant.OPERATION = operation.Update;
            _obj_smhr_applicant.APPSKL_ID = Convert.ToInt32(_lbl_ID);
            _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(_lbl_Emp_Id);
            _obj_smhr_applicant.APPSKL_SKILL_ID = Convert.ToInt32(rcb_Skill.SelectedItem.Value);
            _obj_smhr_applicant.APPSKL_LASTUSED = Convert.ToInt32(rcb_YearLastUsed.SelectedItem.Text);
            _obj_smhr_applicant.APPSKL_EXPERT = Convert.ToInt32(rcb_ExpertLevel.SelectedValue);
            _obj_smhr_applicant.APPSKL_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_applicant.APPSKL_LASTMDFDATE = DateTime.Now;
            status = BLL.set_ApplicantSkills(_obj_smhr_applicant);
            LoadSkill();
            clearSkillFields();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Skills", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Skill_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearSkillFields();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Skills", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void RG_Skills_ItemCommand(object source, GridCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Edit_Rec")
            {
                GridDataItem dtItem = (GridDataItem)e.Item;
                int index = dtItem.ItemIndex;
                Label lbl_ID = new Label();
                Label lblID = new Label();
                Label lblLastUsed = new Label();
                Label lbl_ExpertID = new Label();
                lbl_ID = RG_Skills.Items[index].FindControl("lblID") as Label;
                lblID = RG_Skills.Items[index].FindControl("lbl_Skill_ID") as Label;
                lblLastUsed = RG_Skills.Items[index].FindControl("lbl_Skill_LastUsed") as Label;
                lbl_ExpertID = RG_Skills.Items[index].FindControl("lbl_Skill_Exp_ID") as Label;
                rcb_Skill.SelectedIndex = rcb_Skill.FindItemIndexByValue(lblID.Text);
                rcb_YearLastUsed.SelectedIndex = rcb_YearLastUsed.FindItemIndexByText(lblLastUsed.Text);
                rcb_ExpertLevel.SelectedIndex = rcb_ExpertLevel.FindItemIndexByValue(Convert.ToString(lbl_ExpertID.Text).Trim());
                _lbl_ID = lbl_ID.Text;
                btn_Skill_Add.Visible = false;
                btn_Skill_Correct.Visible = true;
                rcb_Skill.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Skills", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void clearSkillFields()
    {
        rcb_Skill.SelectedIndex = -1;
        rcb_YearLastUsed.SelectedIndex = -1;
        rcb_ExpertLevel.SelectedIndex = -1;
        btn_Skill_Add.Visible = true;
        btn_Skill_Correct.Visible = false;
        rcb_Skill.Enabled = true;
    }

    private void LoadSkill()
    {
        try
        {
            _obj_smhr_employee = new SMHR_EMPLOYEE();
            _obj_smhr_employee.EMP_ID = Convert.ToInt32(Request.QueryString["ID"]);
            _obj_smhr_employee.Mode = 1;
            DataTable dt1 = BLL.get_EmpESS(_obj_smhr_employee);
            if (dt1.Rows.Count != 0)
            {
                _lbl_Emp_Id = Convert.ToString(dt1.Rows[0]["EMP_APPLICANT_ID"]);
            }
            _obj_smhr_applicant = new SMHR_APPLICANT();
            _obj_smhr_applicant.APPSKL_APPLICANT_ID = Convert.ToInt32(_lbl_Emp_Id);
            _obj_smhr_applicant.OPERATION = operation.Check;
            DataTable dt = BLL.get_ApplicantSkills(_obj_smhr_applicant);
            RG_Skills.DataSource = dt;
            RG_Skills.DataBind();
            ViewState["dt_Skill"] = dt;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Skills", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadCombos()
    {
        try
        {
            rcb_Skill.Items.Clear();
            _obj_smhr_masters = new SMHR_MASTERS();
            _obj_smhr_masters.MASTER_TYPE = "SKILL";
            _obj_smhr_masters.OPERATION = operation.Select;
            _obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);
            rcb_Skill.DataSource = dt_Details;
            rcb_Skill.DataTextField = "HR_MASTER_CODE";
            rcb_Skill.DataValueField = "HR_MASTER_ID";
            rcb_Skill.DataBind();
            rcb_Skill.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

            DataTable dt = BLL.get_Year(1);
            rcb_YearLastUsed.DataSource = dt;
            rcb_YearLastUsed.DataValueField = "SMHR_YEAR_ID";
            rcb_YearLastUsed.DataTextField = "SMHR_YEAR";
            rcb_YearLastUsed.DataBind();
            rcb_YearLastUsed.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Skills", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    public bool Check_Combo(RadGrid rdGrid, string lbl_validate, RadComboBox rcmb_Validate)
    {
        try
        {
            bool status = true;
            if (rdGrid.Items.Count > 0)
            {
                for (int i = 0; i < rdGrid.Items.Count; i++)
                {
                    Label lbl_Control = new Label();
                    lbl_Control = rdGrid.Items[i].FindControl("" + lbl_validate + "") as Label;
                    if (Convert.ToInt32(lbl_Control.Text) == Convert.ToInt32(rcmb_Validate.SelectedValue))
                    {
                        status = false;
                    }
                }
            }
            return status;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Skills", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return false;
        }
    }

    private void getEmployee()
    {
        try
        {
            _obj_smhr_employee = new SMHR_EMPLOYEE();
            _obj_smhr_employee.OPERATION = operation.Select;
            _obj_smhr_employee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtEmp = BLL.get_Employee(_obj_smhr_employee);
            if (dtEmp.Rows.Count > 0)
            {
                ViewState["APP_ID"] = Convert.ToString(dtEmp.Rows[0]["EMP_APPLICANT_ID"]);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Skills", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void saveSkill()
    {
        try
        {
            getEmployee();
            _obj_smhr_applicant = new SMHR_APPLICANT();
            _obj_smhr_applicant.OPERATION = operation.Update;
            _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(ViewState["APP_ID"]);// Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
            bool status = false;
            foreach (GridItem row in RG_Skills.Items)
            {
                _obj_smhr_applicant.OPERATION = operation.Update;
                _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(ViewState["APP_ID"]); //Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                _obj_smhr_applicant.APPSKL_APPLICANT_ID = Convert.ToInt32(ViewState["APP_ID"]); //Convert.ToInt32(HF_APID.Value);
                _obj_smhr_applicant.APPSKL_SKILL_ID = Convert.ToInt32((row.FindControl("lbl_Skill_ID") as Label).Text);
                _obj_smhr_applicant.OPERATION = operation.Check_New;
                if ((BLL.get_ApplicantSkills(_obj_smhr_applicant)).Rows.Count > 0)
                {
                    _obj_smhr_applicant.APPSKL_ID = Convert.ToInt32(((DataTable)BLL.get_ApplicantSkills(_obj_smhr_applicant)).Rows[0]["APPSKL_ID"]);
                    //_obj_smhr_applicant.APPSKL_ID = Convert.ToInt32((row.FindControl("lblID") as Label).Text);
                    _obj_smhr_applicant.OPERATION = operation.Update;
                }
                else
                {
                    _obj_smhr_applicant.OPERATION = operation.Insert;
                }


                _obj_smhr_applicant.APPSKL_LASTUSED = Convert.ToInt32((row.FindControl("lbl_Skill_LastUsed") as Label).Text);
                _obj_smhr_applicant.APPSKL_EXPERT = Convert.ToInt32((row.FindControl("lbl_Skill_Exp_ID") as Label).Text);
                _obj_smhr_applicant.APPSKL_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_smhr_applicant.APPSKL_CREATEDDATE = DateTime.Now;
                _obj_smhr_applicant.APPSKL_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_smhr_applicant.APPSKL_LASTMDFDATE = DateTime.Now;
                status = BLL.set_ApplicantSkills(_obj_smhr_applicant);
                if (status == true)
                {
                    BLL.ShowMessage(this, "Information Saved Successfully");
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Skills", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (RG_Skills.Items.Count != 0)
            {
                saveSkill();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Skills", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
