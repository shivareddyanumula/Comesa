﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SMHR;
using Telerik.Web.UI;

public partial class Recruitment_frm_applicantadd : System.Web.UI.Page
{
    #region References

    SMHR_MASTERS _obj_smhr_masters;
    SMHR_APPLICANT _obj_smhr_applicant;
    SMHR_EMPLOYEE _obj_smhr_employee;
    SMHR_GLOBALCONFIG _obj_smhr_globalconfig;
    SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;

    #endregion

    #region DataTables

    static DataTable dt_Details = new DataTable();
    DataTable dtExperience; //Datatable for Experience
    DataTable dt_Contact; // Datatable for Contact
    DataTable dtLanguage; // Datatable for Langugae
    DataTable dt_Skill; // Datatable for Skill
    DataTable dtReference; //Datatable for Reference
    DataTable dt_Qual; //Datatable for Qualification

    #endregion

    #region Variables

    static int Mode = 0;
    static string _lbl_App_ID = "";
    static string _lbl_ID = "";

    #endregion

    #region Load

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                string control = string.Empty;
                if (Request.QueryString.HasKeys())
                {
                    control = Convert.ToString(Request.QueryString["control"]);
                }

                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                if (control == "1")
                {
                    _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Applicant Details");
                }
                else
                {
                    _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("APPLICANT");
                }
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

                    btn_Contact_Add.Visible = false;
                    btn_Contact_Correct.Visible = false;
                    btn_Exp_Add.Visible = false;
                    btn_Exp_Correct.Visible = false;
                    btn_Lang_Add.Visible = false;
                    btn_Lang_Correct.Visible = false;
                    btn_Qual_Add.Visible = false;
                    btn_Qual_Correct.Visible = false;
                    btn_Ref_Add.Visible = false;
                    btn_Ref_Correct.Visible = false;
                    btn_Save.Visible = false;
                    btn_Skill_Add.Visible = false;
                    btn_Skill_Correct.Visible = false;
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
                    return;
                }
                ddl_Status.SelectedValue = "Applied";
                ddl_Status.Enabled = false;
                BLL.ChangeDateFormat(Convert.ToString(Session["EMP_ID"]), txt_DOB, txt_JoinDate,
                        txt_RelieveDate);
                if (Convert.ToString(Request.QueryString["APPID"]) == null)
                {
                    btn_Update.Visible = false;
                    btn_Exp_Correct.Visible = false;
                    btn_Lang_Correct.Visible = false;
                    btn_Qual_Correct.Visible = false;
                    btn_Ref_Correct.Visible = false;
                    btn_Skill_Correct.Visible = false;
                    btn_Contact_Correct.Visible = false;
                    RMP_Applicant_1.SelectedIndex = 0;
                    RTS_Applicant.SelectedIndex = 0;
                    createColumns();
                    lnk_ViewResume.Visible = false;
                    LoadCombos();

                    Mode = 0;
                }
                else
                {
                    btn_Save.Visible = false;
                    RMP_Applicant_1.SelectedIndex = 0;
                    RTS_Applicant.SelectedIndex = 0;
                    btn_Update.Visible = true;
                    btn_Update.Enabled = true;
                    LoadCombos();
                    Mode = 2;
                    btn_Exp_Correct.Visible = false;
                    btn_Lang_Correct.Visible = false;
                    btn_Qual_Correct.Visible = false;
                    btn_Ref_Correct.Visible = false;
                    btn_Skill_Correct.Visible = false;
                    btn_Contact_Correct.Visible = false;
                    //_lbl_App_ID = Convert.ToString(Request.QueryString["APPID"]);
                    HF_APID.Value = Convert.ToString(Request.QueryString["APPID"]);
                    getDetails(HF_APID.Value);
                }
                int expSerial = getExpSerial();
                txt_Serial.Text = Convert.ToString(expSerial);
                int conSerial = getContactSerial();
                txt_Serail_C.Text = Convert.ToString(conSerial);
            }
            Page.Validate();
        }
        //BLL.gridDateFormat(Convert.ToString(Session["EMP_ID"]), RG_Experience, "APPEXP_JOINDATE", "APPEXP_RELDATE");
        //BLL.gridDateFormat(Convert.ToString(Session["EMP_ID"]), RG_Skills, "APPSKL_LASTUSED");
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


    }

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    #endregion

    #region LoadCombos

    private void LoadCombos()
    {
        try
        {
            _obj_smhr_masters = new SMHR_MASTERS();
            _obj_smhr_masters.MASTER_TYPE = "RELIGION";
            _obj_smhr_masters.OPERATION = operation.Select;
            _obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);
            ddl_Religion.DataSource = dt_Details;
            ddl_Religion.DataTextField = "HR_MASTER_CODE";
            ddl_Religion.DataValueField = "HR_MASTER_ID";
            ddl_Religion.DataBind();
            ddl_Religion.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

            _obj_smhr_masters.MASTER_TYPE = "NATIONALITY";
            _obj_smhr_masters.OPERATION = operation.Select;
            _obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);
            ddl_Nationality.DataSource = dt_Details;
            ddl_Nationality.DataTextField = "HR_MASTER_CODE";
            ddl_Nationality.DataValueField = "HR_MASTER_ID";
            ddl_Nationality.DataBind();
            ddl_Nationality.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

            _obj_smhr_masters.MASTER_TYPE = "SKILL";
            _obj_smhr_masters.OPERATION = operation.Select;
            _obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);
            rcb_Skill.DataSource = dt_Details;
            rcb_Skill.DataTextField = "HR_MASTER_CODE";
            rcb_Skill.DataValueField = "HR_MASTER_ID";
            rcb_Skill.DataBind();
            rcb_Skill.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

            _obj_smhr_masters.MASTER_TYPE = "QUALIFICATION";
            _obj_smhr_masters.OPERATION = operation.Select;
            _obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);
            ddl_Category.DataSource = dt_Details;
            ddl_Category.DataTextField = "HR_MASTER_CODE";
            ddl_Category.DataValueField = "HR_MASTER_ID";
            ddl_Category.DataBind();
            ddl_Category.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

            _obj_smhr_masters.MASTER_TYPE = "LANGUAGE";
            _obj_smhr_masters.OPERATION = operation.Select;
            _obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);
            ddl_Language.DataSource = dt_Details;
            ddl_Language.DataTextField = "HR_MASTER_CODE";
            ddl_Language.DataValueField = "HR_MASTER_ID";
            ddl_Language.DataBind();
            ddl_Language.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

            _obj_smhr_masters.MASTER_TYPE = "RELATIONSHIP";
            _obj_smhr_masters.OPERATION = operation.Select;
            _obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);
            ddl_Relationship.DataSource = dt_Details;
            ddl_Relationship.DataTextField = "HR_MASTER_CODE";
            ddl_Relationship.DataValueField = "HR_MASTER_ID";
            ddl_Relationship.DataBind();
            ddl_Relationship.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            ddl_BU.DataSource = dt_BUDetails;
            ddl_BU.DataValueField = "BUSINESSUNIT_ID";
            ddl_BU.DataTextField = "BUSINESSUNIT_CODE";
            ddl_BU.DataBind();
            ddl_BU.Items.Insert(0, new RadComboBoxItem("Select"));

            _obj_smhr_employee = new SMHR_EMPLOYEE();
            _obj_smhr_employee.OPERATION = operation.Select;
            _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_EmployeeRef(_obj_smhr_employee);
            ddl_Employee.DataSource = dt_Details;
            ddl_Employee.DataTextField = "EMP_NAME";
            ddl_Employee.DataValueField = "EMP_ID";
            ddl_Employee.DataBind();
            ddl_Employee.Items.Insert(0, new RadComboBoxItem("Select"));

            //DataTable dt = BLL.get_Year(1);
            //rcb_YearLastUsed.DataSource = dt;
            //rcb_YearLastUsed.DataValueField = "SMHR_YEAR_ID";
            //rcb_YearLastUsed.DataTextField = "SMHR_YEAR";
            //rcb_YearLastUsed.DataBind();
            //rcb_YearLastUsed.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void createColumns()
    {
        try
        {
            dtExperience = new DataTable(); //Datatable for Experience
            dt_Contact = new DataTable(); // Datatable for Contact
            dtLanguage = new DataTable(); // Datatable for Langugae
            dt_Skill = new DataTable(); // Datatable for Skill
            dtReference = new DataTable(); //Datatable for Reference
            dt_Qual = new DataTable(); //Datatable for Qualification
            dtExperience.Columns.Clear();
            dt_Skill.Columns.Clear();
            dt_Qual.Columns.Clear();
            dt_Contact.Columns.Clear();
            dtLanguage.Columns.Clear();
            dtReference.Columns.Clear();
            dtExperience.Rows.Clear();
            dt_Skill.Rows.Clear();
            dt_Qual.Rows.Clear();
            dt_Contact.Rows.Clear();
            dtLanguage.Rows.Clear();
            dtReference.Rows.Clear();
            //Experience
            dtExperience.Columns.Add("APPEXP_ID");
            dtExperience.Columns.Add("APPEXP_SERIAL");
            dtExperience.Columns.Add("APPEXP_COMPANY");
            dtExperience.Columns.Add("APPEXP_JOINDATE");
            dtExperience.Columns.Add("APPEXP_JOINSAL");
            dtExperience.Columns.Add("APPEXP_JOINDESC");
            dtExperience.Columns.Add("APPEXP_REASONREL");
            dtExperience.Columns.Add("APPEXP_RELDATE");
            dtExperience.Columns.Add("APPEXP_RELSAL");
            dtExperience.Columns.Add("APPEXP_REASONDESC");
            dtExperience.PrimaryKey = new DataColumn[] { dtExperience.Columns["APPEXP_SERIAL"] };

            //Skill
            dt_Skill.Columns.Add("APPSKL_ID");
            dt_Skill.Columns.Add("APPSKL_SKILL_ID");
            dt_Skill.Columns.Add("APPSKL_SKILL_NAME");
            dt_Skill.Columns.Add("APPSKL_LASTUSED");
            dt_Skill.Columns.Add("APPSKL_EXPERT");
            dt_Skill.Columns.Add("APPSKL_EXPERT_NAME");
            dt_Skill.PrimaryKey = new DataColumn[] { dt_Skill.Columns["APPSKL_SKILL_ID"] };
            //Contact
            dt_Contact.Columns.Add("APPCONT_ID");
            dt_Contact.Columns.Add("APPCONT_SERIAL");
            dt_Contact.Columns.Add("APPCONT_COMPANY");
            dt_Contact.Columns.Add("APPCONT_CONTACT");
            dt_Contact.Columns.Add("APPCONT_PHONE");
            dt_Contact.Columns.Add("APPCONT_ADDRESS");
            dt_Contact.PrimaryKey = new DataColumn[] { dt_Contact.Columns["APPCONT_SERIAL"] };
            //Qualification
            dt_Qual.Columns.Add("APPQFN_ID");
            dt_Qual.Columns.Add("APPQFN_QUALIFICATION_ID");
            dt_Qual.Columns.Add("APPQFN_QUALIFICATION_NAME");
            dt_Qual.Columns.Add("APPQFN_INSTITUTE");
            dt_Qual.Columns.Add("APPQFN_PASSEDYEAR");
            dt_Qual.Columns.Add("APPQFN_PERCENTAGE");
            dt_Qual.Columns.Add("APPQFN_GRADE");
            dt_Qual.PrimaryKey = new DataColumn[] { dt_Qual.Columns["APPQFN_QUALIFICATION_ID"] };
            //Language
            dtLanguage.Columns.Add("APPLAN_ID");
            dtLanguage.Columns.Add("APPLAN_LANGUAGE_ID");
            dtLanguage.Columns.Add("APPLAN_LANGUAGE_NAME");
            dtLanguage.Columns.Add("APPLAN_READ");
            dtLanguage.Columns.Add("APPLAN_WRITE");
            dtLanguage.Columns.Add("APPLAN_SPEAK");
            dtLanguage.Columns.Add("APPLAN_UNDERSTAND");
            dtLanguage.PrimaryKey = new DataColumn[] { dtLanguage.Columns["APPLAN_LANGUAGE_ID"] };
            //Reference
            dtReference.Columns.Add("APPREF_ID");
            dtReference.Columns.Add("APPREF_REFFERED_EMP_ID");
            dtReference.Columns.Add("APPREF_REFFERED_EMP_NAME");
            dtReference.Columns.Add("APPREF_RELATIONSHIP");
            dtReference.Columns.Add("APPREF_RELATIONSHIP_NAME");
            dtReference.Columns.Add("APPREF_REFERRED");
            dtReference.PrimaryKey = new DataColumn[] { dtReference.Columns["APPREF_REFFERED_EMP_ID"] };

            RG_Contact.DataSource = dt_Contact;
            RG_Contact.DataBind();
            RG_Experience.DataSource = dtExperience;
            RG_Experience.DataBind();
            RG_Language.DataSource = dtLanguage;
            RG_Language.DataBind();
            RG_Reference.DataSource = dtReference;
            RG_Reference.DataBind();
            RG_Skills.DataSource = dt_Skill;
            RG_Skills.DataBind();
            RG_Qualification.DataSource = dt_Qual;
            RG_Qualification.DataBind();

            ViewState["dt_Contact"] = dt_Contact;
            ViewState["dtExperience"] = dtExperience;
            ViewState["dtLanguage"] = dtLanguage;
            ViewState["dtReference"] = dtReference;
            ViewState["dt_Skill"] = dt_Skill;
            ViewState["dt_Qual"] = dt_Qual;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    #endregion
    protected void ddl_BU_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            //   LoadEmployee();
            _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
            _obj_smhr_emp_payitems.OPERATION = operation.Empty;
            _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(ddl_BU.SelectedValue);
            _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
            if (dt_Details.Rows.Count != 0)
            {
                ddl_Employee.DataSource = dt_Details;
                ddl_Employee.DataTextField = "Empname";
                ddl_Employee.DataValueField = "EMP_ID";
                ddl_Employee.DataBind();
            }
            ddl_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    #region serial

    private int getExpSerial()
    {
        int serialMax = 0;
        try
        {
            
            if (RG_Experience.Items.Count == 0)
            {
                serialMax = 1;
            }
            else if (RG_Experience.Items.Count >= 1)
            {
                serialMax = Convert.ToInt32(RG_Experience.Items.Count);
                serialMax = serialMax + 1;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return serialMax;
    }

    private int getContactSerial()
    {
        int serialMax = 1;
        try
        {

            if (RG_Contact.Items.Count == 0)
            {
                serialMax = 1;
            }
            else if (RG_Contact.Items.Count >= 1)
            {
                serialMax = Convert.ToInt32(RG_Contact.Items.Count);
                serialMax = serialMax + 1;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return serialMax;
    }

    #endregion

    #region Add

    protected void btn_Qual_Add_Click(object sender, EventArgs e)
    {
        try
        {
            decimal percentage = 0;
            if (txt_Percentage.Text == string.Empty)
                txt_Percentage.Text = percentage.ToString();
            else
                percentage = Convert.ToDecimal(txt_Percentage.Text);

            if (Check_Combo(RG_Qualification, "lbl_ID", ddl_Category))
            {
                if (Mode == 0) //New Add
                {
                    dt_Qual = (DataTable)ViewState["dt_Qual"];
                    DataRow dr = dt_Qual.NewRow();
                    dr[0] = "0";
                    dr[1] = ddl_Category.SelectedValue;
                    dr[2] = ddl_Category.SelectedItem.Text;
                    dr[3] = txt_Institute.Text;
                    dr[4] = txt_YearofPass.Value;
                    dr[5] = txt_Percentage.Value;
                    dr[6] = ddl_Grade.SelectedItem.Text;
                    dt_Qual.Rows.Add(dr);
                    RG_Qualification.DataSource = dt_Qual;
                    RG_Qualification.DataBind();
                    clearQualFields();
                    Mode = 0;
                }
                else if (Mode == 2) // Edit Add
                {
                    _obj_smhr_applicant = new SMHR_APPLICANT();
                    bool status = false;
                    _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value);// Convert.ToInt32(_lbl_App_ID);
                    _obj_smhr_applicant.APPQFN_QUALIFICATION_ID = Convert.ToInt32(ddl_Category.SelectedValue);
                    _obj_smhr_applicant.APPQFN_INSTITUTE = Convert.ToString(txt_Institute.Text.Replace("'", "''"));
                    _obj_smhr_applicant.APPQFN_PASSEDYEAR = Convert.ToInt32(txt_YearofPass.Value);
                    _obj_smhr_applicant.APPQFN_PERCENTAGE = Convert.ToInt32(Convert.ToString(txt_Percentage.Value));
                    _obj_smhr_applicant.APPQFN_GRADE = Convert.ToString(ddl_Grade.SelectedItem.Value);
                    _obj_smhr_applicant.APPQFN_CREATEDBY = 1;
                    _obj_smhr_applicant.APPQFN_CREATEDDATE = DateTime.Now;
                    _obj_smhr_applicant.OPERATION = operation.Insert;
                    status = BLL.set_AppQualification(_obj_smhr_applicant);
                    Mode = 2;
                    LoadQualification();
                    clearQualFields();
                    ddl_Category.Enabled = true;
                }
            }
            else
            {
                BLL.ShowMessage(this, "This Qualification is already added");
                ddl_Category.Focus();
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Skill_Add_Click(object sender, EventArgs e)
    {
        try
        {
            if (Check_Combo(RG_Skills, "lbl_Skill_ID", rcb_Skill))
            {
                if (Mode == 0)
                {
                    dt_Skill = (DataTable)ViewState["dt_Skill"];
                    DataRow dr = dt_Skill.NewRow();
                    dr[0] = "0";
                    dr[1] = rcb_Skill.SelectedValue;
                    dr[2] = rcb_Skill.SelectedItem.Text;
                    //dr[3] = rcb_YearLastUsed.SelectedItem.Text;
                    dr[4] = rcb_ExpertLevel.SelectedValue;
                    dr[5] = rcb_ExpertLevel.SelectedItem.Text;
                    dt_Skill.Rows.Add(dr);
                    RG_Skills.DataSource = dt_Skill;
                    RG_Skills.DataBind();
                    clearSkillFields();
                    Mode = 0;
                }
                else if (Mode == 2)
                {
                    _obj_smhr_applicant = new SMHR_APPLICANT();
                    bool status = false;
                    _obj_smhr_applicant.OPERATION = operation.Insert;
                    _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                    _obj_smhr_applicant.APPSKL_SKILL_ID = Convert.ToInt32(rcb_Skill.SelectedItem.Value);
                    //_obj_smhr_applicant.APPSKL_LASTUSED = Convert.ToInt32(rcb_YearLastUsed.SelectedItem.Text);
                    _obj_smhr_applicant.APPSKL_EXPERT = Convert.ToInt32(rcb_ExpertLevel.SelectedValue);
                    _obj_smhr_applicant.APPSKL_CREATEDBY = 1;
                    _obj_smhr_applicant.APPSKL_CREATEDDATE = DateTime.Now;
                    status = BLL.set_ApplicantSkills(_obj_smhr_applicant);
                    Mode = 2;
                    clearSkillFields();
                    LoadSkill();
                }
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Exp_Add_Click(object sender, EventArgs e)
    {
        try
        {
            /*if (Mode == 0)
            {
                dtExperience = (DataTable)ViewState["dtExperience"];
                DataRow dr = dtExperience.NewRow();
                dr[0] = "0";
                dr[1] = txt_Serial.Text;
                dr[2] = txt_CompanyName.Text;
                dr[3] = Convert.ToDateTime(txt_JoinDate.SelectedDate).ToShortDateString();
                dr[4] = txt_JoinSalary.Value;
                dr[5] = txt_JoinDesc.Text;
                dr[6] = txt_ReasonRelieve.Text;
                dr[7] = Convert.ToDateTime(txt_RelieveDate.SelectedDate).ToShortDateString();
                dr[8] = txt_RelSalary.Value;
                dr[9] = txt_RelDesc.Text;
                dtExperience.Rows.Add(dr);
                Mode = 0;
                RG_Experience.DataSource = dtExperience;
                RG_Experience.DataBind();
                int expSerial = getExpSerial();
                txt_Serial.Text = Convert.ToString(expSerial);
                clearExpFields();
            }
            else if (Mode == 2)
            {
                _obj_smhr_applicant = new SMHR_APPLICANT();
                bool status = false;
                _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                _obj_smhr_applicant.APPEXP_SERIAL = Convert.ToInt32(txt_Serial.Text);
                _obj_smhr_applicant.APPEXP_COMPANY = Convert.ToString(txt_CompanyName.Text.Replace("'", "''"));
                _obj_smhr_applicant.APPEXP_JOINDATE = Convert.ToDateTime(txt_JoinDate.SelectedDate.Value);
                _obj_smhr_applicant.APPEXP_JOINSAL = Convert.ToDouble(txt_JoinSalary.Value);
                _obj_smhr_applicant.APPEXP_JOINDESC = Convert.ToString(txt_JoinDesc.Text.Replace("'", "''"));
                _obj_smhr_applicant.APPEXP_REASONREL = Convert.ToString(txt_ReasonRelieve.Text.Replace("'", "''"));
                _obj_smhr_applicant.APPEXP_RELDATE = Convert.ToDateTime(txt_RelieveDate.SelectedDate.Value);
                _obj_smhr_applicant.APPEXP_RELSAL = Convert.ToDouble(txt_RelSalary.Value);
                _obj_smhr_applicant.APPEXP_REASONDESC = Convert.ToString(txt_RelDesc.Text.Replace("'", "''"));
                _obj_smhr_applicant.APPEXP_CREATEDBY = 1;
                _obj_smhr_applicant.APPEXP_CREATEDDATE = DateTime.Now;
                _obj_smhr_applicant.OPERATION = operation.Insert;
                status = BLL.set_ApplicantExperience(_obj_smhr_applicant);
                Mode = 2;
                clearExpFields();
                LoadExperience();
            }*/
            if (Mode == 0)
            {
                Label lblJDate1 = new Label();              /*divya 27042016----for checking previous relieving date*/
                Label lblRDate1 = new Label();
                int index11 = RG_Experience.Items.Count;
                if (index11 > 0)
                {
                    lblJDate1 = RG_Experience.Items[index11 - 1].FindControl("lbl_Exp_JoinDate") as Label;
                    lblRDate1 = RG_Experience.Items[index11 - 1].FindControl("lbl_Exp_RelDate") as Label;
                    if (txt_JoinDate.SelectedDate != null && txt_RelieveDate.SelectedDate != null)
                    {

                        DateTime dt = GetDateTime(lblRDate1.Text);
                        if (Convert.ToDateTime(txt_JoinDate.SelectedDate) <= Convert.ToDateTime(dt))
                        {
                            BLL.ShowMessage(this, "Joining Date should be greater than Previous Relieving Date");
                            return;
                        }
                    }
                }
                else if (txt_JoinDate.SelectedDate != null && txt_RelieveDate.SelectedDate != null)
                {
                    if (Convert.ToDateTime(txt_JoinDate.SelectedDate) >= Convert.ToDateTime(txt_RelieveDate.SelectedDate))
                    {
                        BLL.ShowMessage(this, "Joining Date should not be Greater Than Relieving Date");
                        return;
                    }
                }
                else if (txt_JoinDate.SelectedDate == null && txt_RelieveDate.SelectedDate != null)
                {
                    BLL.ShowMessage(this, "Please Enter Joining Date");
                    return;
                }
                Label lblJDate = new Label();
                Label lblRDate = new Label();
                int index1 = RG_Experience.Items.Count;
                if (index1 > 0)
                {
                    lblJDate = RG_Experience.Items[index1 - 1].FindControl("lbl_Exp_JoinDate") as Label;
                    lblRDate = RG_Experience.Items[index1 - 1].FindControl("lbl_Exp_RelDate") as Label;
                    if (string.IsNullOrEmpty(lblRDate.Text))
                    {
                        BLL.ShowMessage(this, "Previous Company Relieving date is Empty");
                        return;
                    }
                    DateTime dt = GetDateTime(lblRDate.Text);

                    if (Convert.ToDateTime(dt) >= Convert.ToDateTime(txt_JoinDate.SelectedDate))
                    {
                        BLL.ShowMessage(this, "Joining Date should be more then Previous Relieving Date");
                        return;
                    }

                }

                dtExperience = (DataTable)ViewState["dtExperience"];
                DataRow dr = dtExperience.NewRow();
                dr[0] = "0";
                dr[1] = txt_Serial.Text;
                dr[2] = txt_CompanyName.Text;

                dr[4] = txt_JoinSalary.Value;
                dr[5] = txt_JoinDesc.Text;
                dr[6] = txt_ReasonRelieve.Text;

                dr[8] = txt_RelSalary.Value;
                dr[9] = txt_RelDesc.Text;
                if (txt_JoinDate.SelectedDate != null)
                {
                    dr[3] = Convert.ToDateTime(txt_JoinDate.SelectedDate).ToString("dd/MM/yyyy");
                }
                else
                {
                    dr[3] = null;
                }
                if (txt_RelieveDate.SelectedDate != null)
                {
                    dr[7] = Convert.ToDateTime(txt_RelieveDate.SelectedDate).ToString("dd/MM/yyyy");
                }
                else
                {
                    dr[7] = null;

                }
                dtExperience.Rows.Add(dr);
                Mode = 0;
                RG_Experience.DataSource = dtExperience;
                RG_Experience.DataBind();
                int expSerial = getExpSerial();
                txt_Serial.Text = Convert.ToString(expSerial);
                clearExpFields();
            }
            else if (Mode == 2)
            {
                if (!string.IsNullOrEmpty(HF_APID.Value))
                {
                     Label lblJDate1 = new Label();
                    Label lblRDate1 = new Label();
                     int index11 = RG_Experience.Items.Count;
                     if (index11 > 0)
                     {
                         lblJDate1 = RG_Experience.Items[index11 - 1].FindControl("lbl_Exp_JoinDate") as Label;
                         lblRDate1 = RG_Experience.Items[index11 - 1].FindControl("lbl_Exp_RelDate") as Label;
                         if (txt_JoinDate.SelectedDate != null && txt_RelieveDate.SelectedDate != null)
                         {
                             
                             DateTime dt = GetDateTime(lblRDate1.Text);
                             if (Convert.ToDateTime(txt_JoinDate.SelectedDate) <= Convert.ToDateTime(dt))
                             {
                                 BLL.ShowMessage(this, "Joining Date should be greater than Previous Relieving Date");
                                 return;
                             }
                         }
                     }
                     else  if (txt_JoinDate.SelectedDate != null && txt_RelieveDate.SelectedDate != null)
                    {
                        if (Convert.ToDateTime(txt_JoinDate.SelectedDate) >= Convert.ToDateTime(txt_RelieveDate.SelectedDate))
                        {
                            BLL.ShowMessage(this, "Joining Date should not be Greater Than Relieving Date");
                            return;
                        }
                    }
                  
                   /* else if(txt_JoinDate.SelectedDate!=null && txt_RelieveDate.SelectedDate!=null)
                        {
                            Label lblRDate1 = new Label();
                            DateTime dt = GetDateTime(lblRDate1.Text);
                            if (Convert.ToDateTime(txt_JoinDate.SelectedDate) <= Convert.ToDateTime(dt))
                            {
                                BLL.ShowMessage(this,"Joining Date should be greater than Previous Relieving Date");
                                return;
                            }
                        }*/
                    else if (txt_JoinDate.SelectedDate == null && txt_RelieveDate.SelectedDate != null)
                    {
                        BLL.ShowMessage(this, "Please Enter Joining Date");
                        return;
                    }
                    Label lblJDate = new Label();
                    Label lblRDate = new Label();
                    int index1 = RG_Experience.Items.Count;
                    if (index1 > 0)
                    {
                        lblJDate = RG_Experience.Items[index1 - 1].FindControl("lbl_Exp_JoinDate") as Label;
                        lblRDate = RG_Experience.Items[index1 - 1].FindControl("lbl_Exp_RelDate") as Label;
                        if (string.IsNullOrEmpty(lblRDate.Text))
                        {
                            BLL.ShowMessage(this, "Previous Company Relieving date is Empty");
                            return;
                        }
                        DateTime dt = GetDateTime(lblRDate.Text);
                        if (Convert.ToDateTime(dt) >= Convert.ToDateTime(txt_JoinDate.SelectedDate))
                        {
                            BLL.ShowMessage(this, "Joining Date should be more then Previous Relieving Date");
                            return;
                        }

                    }
                    _obj_smhr_applicant = new SMHR_APPLICANT();
                    bool status = false;
                    _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                    _obj_smhr_applicant.APPEXP_SERIAL = Convert.ToInt32(txt_Serial.Text);
                    _obj_smhr_applicant.APPEXP_COMPANY = Convert.ToString(txt_CompanyName.Text.Replace("'", "''"));
                    //_obj_smhr_applicant.APPEXP_JOINDATE = Convert.ToDateTime(txt_JoinDate.SelectedDate.Value);
                    _obj_smhr_applicant.APPEXP_JOINSAL = Convert.ToDouble(txt_JoinSalary.Value);
                    _obj_smhr_applicant.APPEXP_JOINDESC = Convert.ToString(txt_JoinDesc.Text.Replace("'", "''"));
                    _obj_smhr_applicant.APPEXP_REASONREL = Convert.ToString(txt_ReasonRelieve.Text.Replace("'", "''"));

                    if (txt_JoinDate.SelectedDate != null)
                    {
                        _obj_smhr_applicant.APPEXP_JOINDATE = Convert.ToDateTime(txt_JoinDate.SelectedDate.Value);
                    }
                    else
                    {
                        _obj_smhr_applicant.APPEXP_JOINDATE = null;

                    }
                    if (txt_RelieveDate.SelectedDate != null)
                    {
                        _obj_smhr_applicant.APPEXP_RELDATE = Convert.ToDateTime(txt_RelieveDate.SelectedDate.Value);
                    }
                    else
                    {
                        _obj_smhr_applicant.APPEXP_RELDATE = null;

                    }
                    _obj_smhr_applicant.APPEXP_RELSAL = Convert.ToDouble(txt_RelSalary.Value);
                    _obj_smhr_applicant.APPEXP_REASONDESC = Convert.ToString(txt_RelDesc.Text.Replace("'", "''"));
                    _obj_smhr_applicant.APPEXP_CREATEDBY = 1;
                    _obj_smhr_applicant.APPEXP_CREATEDDATE = DateTime.Now;
                    _obj_smhr_applicant.OPERATION = operation.Insert;
                    status = BLL.set_ApplicantExperience(_obj_smhr_applicant);
                    Mode = 2;
                    clearExpFields();
                    LoadExperience();
                }
                else
                {

                    if (txt_JoinDate.SelectedDate != null && txt_RelieveDate.SelectedDate != null)
                    {
                        if (Convert.ToDateTime(txt_JoinDate.SelectedDate) >= Convert.ToDateTime(txt_RelieveDate.SelectedDate))
                        {
                            BLL.ShowMessage(this, "Joining Date should not be Greater Than Relieving Date");
                            return;
                        }
                    }
                    else if (txt_JoinDate.SelectedDate == null && txt_RelieveDate.SelectedDate != null)
                    {
                        BLL.ShowMessage(this, "Please Enter Joining Date");
                        return;
                    }
                    Label lblJDate = new Label();
                    Label lblRDate = new Label();
                    int index1 = RG_Experience.Items.Count;
                    if (index1 > 0)
                    {
                        lblJDate = RG_Experience.Items[index1 - 1].FindControl("lbl_Exp_JoinDate") as Label;
                        lblRDate = RG_Experience.Items[index1 - 1].FindControl("lbl_Exp_RelDate") as Label;
                        if (string.IsNullOrEmpty(lblRDate.Text))
                        {
                            BLL.ShowMessage(this, "Previous Company Relieving date is Empty");
                            return;
                        }
                        DateTime dt = GetDateTime(lblRDate.Text);
                        if (Convert.ToDateTime(dt) >= Convert.ToDateTime(txt_JoinDate.SelectedDate))
                        {
                            BLL.ShowMessage(this, "Joining Date should be more then Previous Relieving Date");
                            return;
                        }

                    }
                    dtExperience = (DataTable)ViewState["dtExperience"];
                    DataRow dr = dtExperience.NewRow();
                    dr[0] = "0";
                    dr[1] = txt_Serial.Text;
                    dr[2] = txt_CompanyName.Text;

                    dr[4] = txt_JoinSalary.Value;
                    dr[5] = txt_JoinDesc.Text;
                    dr[6] = txt_ReasonRelieve.Text;

                    dr[8] = txt_RelSalary.Value;
                    dr[9] = txt_RelDesc.Text;
                    if (txt_JoinDate.SelectedDate != null)
                    {
                        dr[3] = Convert.ToDateTime(txt_JoinDate.SelectedDate).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        dr[3] = null;
                    }
                    if (txt_RelieveDate.SelectedDate != null)
                    {
                        Convert.ToDateTime(txt_RelieveDate.SelectedDate).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        dr[7] = null;

                    }
                    dtExperience.Rows.Add(dr);
                    Mode = 0;
                    RG_Experience.DataSource = dtExperience;
                    RG_Experience.DataBind();
                    int expSerial = getExpSerial();
                    txt_Serial.Text = Convert.ToString(expSerial);
                    clearExpFields();


                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private DateTime GetDateTime(string p)
    {
        DateTime dt;
        try
        {
            dt = DateTime.ParseExact(p, "dd/MM/yyyy",null);
        }
        catch (Exception ex)
        {
            dt = Convert.ToDateTime(p);
        }
        return dt;
    }
    protected void btn_Contact_Add_Click(object sender, EventArgs e)
    {
        try
        {
            if (Mode == 0)
            {
                dt_Contact = (DataTable)ViewState["dt_Contact"];
                DataRow dr = dt_Contact.NewRow();
                dr[0] = "0";
                dr[1] = txt_Serail_C.Text;
                dr[2] = txt_Company_C.Text;
                dr[3] = txt_ContactName.Text;
                dr[4] = txt_PhoneNumber.Text;
                dr[5] = txt_Address_C.Text;
                dt_Contact.Rows.Add(dr);
                RG_Contact.DataSource = dt_Contact;
                RG_Contact.DataBind();
                clearConFields();
                Mode = 0;
                int conSerial = getContactSerial();
                txt_Serail_C.Text = Convert.ToString(conSerial);
            }
            else if (Mode == 2)
            {
                _obj_smhr_applicant = new SMHR_APPLICANT();
                bool status = false;
                _obj_smhr_applicant.OPERATION = operation.Insert;
                _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                _obj_smhr_applicant.APPCONT_SERIAL = Convert.ToInt32(txt_Serail_C.Text.Replace("'", "''"));
                _obj_smhr_applicant.APPCONT_COMPANY = Convert.ToString(txt_Company_C.Text.Replace("'", "''"));
                _obj_smhr_applicant.APPCONT_CONTACT = Convert.ToString(txt_ContactName.Text.Replace("'", "''"));
                _obj_smhr_applicant.APPCONT_PHONE = Convert.ToString(txt_PhoneNumber.Text.Replace("'", "''"));
                _obj_smhr_applicant.APPCONT_ADDRESS = Convert.ToString(txt_Address_C.Text.Replace("'", "''"));
             //   _obj_smhr_applicant.APPCONT_CREATEDBY = 1;
                _obj_smhr_applicant.APPCONT_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_smhr_applicant.APPCONT_CREATEDDATE = DateTime.Now;
                status = BLL.set_ApplicantContact(_obj_smhr_applicant);
                clearConFields();
                LoadContact();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void btn_Lang_Add_Click(object sender, EventArgs e)
    {
        try
        {
            if (Check_Combo(RG_Language, "lbl_ID", ddl_Language))
            {
                if (Mode == 0)
                {

                    if (chk_Read.Checked == false && chk_Speak.Checked == false && chk_Understand.Checked == false && chk_Write.Checked == false)
                    {
                        BLL.ShowMessage(this, "Please check atleast one language mode");
                        return;
                    }
                    dtLanguage = (DataTable)ViewState["dtLanguage"];
                    DataRow dr = dtLanguage.NewRow();
                    dr[0] = "0";
                    dr[1] = ddl_Language.SelectedValue;
                    dr[2] = ddl_Language.SelectedItem.Text;
                    if (chk_Read.Checked)
                        dr[3] = true;
                    else
                        dr[3] = false;
                    if (chk_Write.Checked)
                        dr[4] = true;
                    else
                        dr[4] = false;
                    if (chk_Speak.Checked)
                        dr[5] = true;
                    else
                        dr[5] = false;
                    if (chk_Understand.Checked)
                        dr[6] = true;
                    else
                        dr[6] = false;
                    dtLanguage.Rows.Add(dr);
                    RG_Language.DataSource = dtLanguage;
                    RG_Language.DataBind();
                    clearLangFields();
                    btn_Lang_Add.Visible = true;
                    btn_Lang_Correct.Visible = false;
                    ddl_Language.Enabled = true;
                    Mode = 0;
                }
                else if (Mode == 2)
                {
                    if (chk_Read.Checked == false && chk_Speak.Checked == false && chk_Understand.Checked == false && chk_Write.Checked == false)
                    {
                        BLL.ShowMessage(this, "Please check atleast one language mode");
                        return;
                    }
                    _obj_smhr_applicant = new SMHR_APPLICANT();
                    bool status = false;
                    _obj_smhr_applicant.OPERATION = operation.Insert;
                    _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                    _obj_smhr_applicant.APPLAN_LANGUAGE_ID = Convert.ToInt32(ddl_Language.SelectedValue);
                    if (chk_Read.Checked)
                        _obj_smhr_applicant.APPLAN_READ = true;
                    else
                        _obj_smhr_applicant.APPLAN_READ = false;
                    if (chk_Write.Checked)
                        _obj_smhr_applicant.APPLAN_WRITE = true;
                    else
                        _obj_smhr_applicant.APPLAN_WRITE = false;
                    if (chk_Speak.Checked)
                        _obj_smhr_applicant.APPLAN_SPEAK = true;
                    else
                        _obj_smhr_applicant.APPLAN_SPEAK = false;
                    if (chk_Understand.Checked)
                        _obj_smhr_applicant.APPLAN_UNDERSTAND = true;
                    else
                        _obj_smhr_applicant.APPLAN_UNDERSTAND = false;
                    _obj_smhr_applicant.APPLAN_CREATEDBY = 1;
                    _obj_smhr_applicant.APPLAN_CREATEDDATE = DateTime.Now;
                    status = BLL.set_ApplicantLanguage(_obj_smhr_applicant);
                    clearLangFields();
                    Mode = 2;
                    LoadLanguage();
                }
            }
            else
            {
                BLL.ShowMessage(this, "This Language is already added");
                ddl_Language.Focus();
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Ref_Add_Click(object sender, EventArgs e)
    {
        try
        {
            if (Mode == 0)
            {
                dtReference = (DataTable)ViewState["dtReference"];
                DataRow dr = dtReference.NewRow();
                dr[0] = "0";
                dr[1] = ddl_Employee.SelectedValue;
                dr[2] = ddl_Employee.SelectedItem.Text;
                dr[3] = ddl_Relationship.SelectedValue;
                dr[4] = ddl_Relationship.SelectedItem.Text;
                if (chk_Referred.Checked)
                    dr[5] = true;
                else
                    dr[5] = false;
                dtReference.Rows.Add(dr);
                RG_Reference.DataSource = dtReference;
                RG_Reference.DataBind();
                btn_Ref_Add.Visible = true;
                btn_Ref_Correct.Visible = false;
                ddl_Employee.Enabled = true;
                clearRefFields();
            }
            else if (Mode == 2)
            {
                _obj_smhr_applicant = new SMHR_APPLICANT();
                bool status = false;
                _obj_smhr_applicant.OPERATION = operation.Insert;
                _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                _obj_smhr_applicant.APPREF_REFFERED_EMP_ID = Convert.ToInt32(ddl_Employee.SelectedValue);
                _obj_smhr_applicant.APPREF_RELATIONSHIP = Convert.ToInt32(ddl_Relationship.SelectedValue);
                if (chk_Referred.Checked)
                    _obj_smhr_applicant.APPREF_REFERRED = true;
                else
                    _obj_smhr_applicant.APPREF_REFERRED = false;
                _obj_smhr_applicant.APPREF_CREATEDBY = 1;
                _obj_smhr_applicant.APPREF_CREATEDDATE = DateTime.Now;
                status = BLL.set_ApplicantReference(_obj_smhr_applicant);
                clearRefFields();
                Mode = 2;
                LoadReference();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region Correct

    protected void btn_Qual_Correct_Click(object sender, EventArgs e)
    {
        try
        {
            if (Mode == 1) //New Edit
            {
                dt_Qual = (DataTable)ViewState["dt_Qual"];
                DataRow dr;
                DataRow dr1 = dt_Qual.Rows.Find(ddl_Category.SelectedValue);
                int index = 0;
                int RowIndex = 0;
                for (index = 0; index < dt_Qual.Rows.Count; index++)
                {
                    if (dt_Qual.Rows[index].Equals(dr1))
                    {
                        RowIndex = index;
                    }
                }
                dr = dt_Qual.Rows[RowIndex];
                dr.BeginEdit();
                dr[0] = "0";
                dr[1] = ddl_Category.SelectedValue;
                dr[2] = ddl_Category.SelectedItem.Text;
                dr[3] = txt_Institute.Text;
                dr[4] = txt_YearofPass.Value;
                dr[5] = txt_Percentage.Value;
                dr[6] = ddl_Grade.SelectedItem.Text;
                dr.EndEdit();
                RG_Qualification.DataSource = dt_Qual;
                RG_Qualification.DataBind();
                clearQualFields();
                Mode = 0;
            }
            else
            {
                _obj_smhr_applicant = new SMHR_APPLICANT();
                bool status = false;
                _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                _obj_smhr_applicant.APPQFN_ID = Convert.ToInt32(HF_ID.Value); //Convert.ToInt32(_lbl_ID);
                _obj_smhr_applicant.APPQFN_QUALIFICATION_ID = Convert.ToInt32(ddl_Category.SelectedValue);
                _obj_smhr_applicant.APPQFN_INSTITUTE = Convert.ToString(txt_Institute.Text.Replace("'", "''"));
                _obj_smhr_applicant.APPQFN_PASSEDYEAR = Convert.ToInt32(txt_YearofPass.Value);
                if (txt_Percentage.Value != null)
                {
                    _obj_smhr_applicant.APPQFN_PERCENTAGE = Convert.ToInt32(Convert.ToString(txt_Percentage.Value));
                }
                _obj_smhr_applicant.APPQFN_GRADE = Convert.ToString(ddl_Grade.SelectedItem.Value);
                _obj_smhr_applicant.APPQFN_LASTMDFBY = 1;
                _obj_smhr_applicant.APPQFN_LASTMDFDATE = DateTime.Now;
                _obj_smhr_applicant.OPERATION = operation.Update;
                status = BLL.set_AppQualification(_obj_smhr_applicant);
                Mode = 2;
                LoadQualification();
                clearQualFields();
                ddl_Category.Enabled = true;

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Skill_Correct_Click(object sender, EventArgs e)
    {
        try
        {
            if (Mode == 1)
            {
                dt_Skill = (DataTable)ViewState["dt_Skill"];
                DataRow dr;
                dr = dt_Skill.Rows[0];
                dr.BeginEdit();
                dr[0] = "0";
                dr[1] = rcb_Skill.SelectedValue;
                dr[2] = rcb_Skill.SelectedItem.Text;
                //dr[3] = rcb_YearLastUsed.SelectedItem.Text;
                dr[4] = rcb_ExpertLevel.SelectedValue;
                dr[5] = rcb_ExpertLevel.SelectedItem.Text;
                dr.EndEdit();
                Mode = 0;
                RG_Skills.DataSource = dt_Skill;
                RG_Skills.DataBind();
                clearSkillFields();
                btn_Skill_Add.Visible = true;
                btn_Skill_Correct.Visible = false;
                rcb_Skill.Enabled = true;
            }
            else
            {
                _obj_smhr_applicant = new SMHR_APPLICANT();
                bool status = false;
                _obj_smhr_applicant.OPERATION = operation.Update;
                _obj_smhr_applicant.APPSKL_ID = Convert.ToInt32(HF_ID.Value); //Convert.ToInt32(_lbl_ID);
                _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                _obj_smhr_applicant.APPSKL_SKILL_ID = Convert.ToInt32(rcb_Skill.SelectedItem.Value);
                //_obj_smhr_applicant.APPSKL_LASTUSED = Convert.ToInt32(rcb_YearLastUsed.SelectedItem.Text);
                _obj_smhr_applicant.APPSKL_EXPERT = Convert.ToInt32(rcb_ExpertLevel.SelectedItem.Value);
                _obj_smhr_applicant.APPSKL_LASTMDFBY = 1;
                _obj_smhr_applicant.APPSKL_LASTMDFDATE = DateTime.Now;
                status = BLL.set_ApplicantSkills(_obj_smhr_applicant);
                Mode = 2;
                LoadSkill();
                clearSkillFields();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Exp_Correct_Click(object sender, EventArgs e)
    {
        try
        {
           /* if (Mode == 1)
            {
                dtExperience = (DataTable)ViewState["dtExperience"];
                DataRow dr;
                DataRow dr1 = dtExperience.Rows.Find(txt_Serial.Text);
                int RowIndex = 0;
                for (int index = 0; index < dtExperience.Rows.Count; index++)
                {
                    if (dtExperience.Rows[index].Equals(dr1))
                        RowIndex = index;
                }
                dr = dtExperience.Rows[RowIndex];
                dr.BeginEdit();
                dr[0] = "0";
                dr[1] = txt_Serial.Text;
                dr[2] = txt_CompanyName.Text;
                dr[3] = Convert.ToDateTime(txt_JoinDate.SelectedDate).ToShortDateString();
                dr[4] = txt_JoinSalary.Value;
                dr[5] = txt_JoinDesc.Text;
                dr[6] = txt_ReasonRelieve.Text;
                dr[7] = Convert.ToDateTime(txt_RelieveDate.SelectedDate).ToShortDateString();
                dr[8] = txt_RelSalary.Value;
                dr[9] = txt_RelDesc.Text;
                dr.EndEdit();
                RG_Experience.DataSource = dtExperience;
                RG_Experience.DataBind();
                clearExpFields();
                btn_Exp_Add.Visible = true;
                btn_Exp_Correct.Visible = false;
                int expSerial = getExpSerial();
                txt_Serial.Text = Convert.ToString(expSerial);
                Mode = 0;
            }
            else
            {
                _obj_smhr_applicant = new SMHR_APPLICANT();
                bool status = false;
                _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                _obj_smhr_applicant.APPEXP_ID = Convert.ToInt32(HF_ID.Value);//Convert.ToInt32(_lbl_ID);
                _obj_smhr_applicant.APPEXP_SERIAL = Convert.ToInt32(txt_Serial.Text);
                _obj_smhr_applicant.APPEXP_COMPANY = Convert.ToString(txt_CompanyName.Text.Replace("'", "''"));
                _obj_smhr_applicant.APPEXP_JOINDATE = Convert.ToDateTime(txt_JoinDate.SelectedDate.Value);
                _obj_smhr_applicant.APPEXP_JOINSAL = Convert.ToDouble(txt_JoinSalary.Value);
                _obj_smhr_applicant.APPEXP_JOINDESC = Convert.ToString(txt_JoinDesc.Text.Replace("'", "''"));
                _obj_smhr_applicant.APPEXP_REASONREL = Convert.ToString(txt_ReasonRelieve.Text.Replace("'", "''"));
                _obj_smhr_applicant.APPEXP_RELDATE = Convert.ToDateTime(txt_RelieveDate.SelectedDate.Value);
                _obj_smhr_applicant.APPEXP_RELSAL = Convert.ToDouble(txt_RelSalary.Value);
                _obj_smhr_applicant.APPEXP_REASONDESC = Convert.ToString(txt_RelDesc.Text.Replace("'", "''"));
                _obj_smhr_applicant.APPEXP_LASTMDFBY = 1;
                _obj_smhr_applicant.APPEXP_LASTMDFDATE = Convert.ToString(DateTime.Now);
                _obj_smhr_applicant.OPERATION = operation.Update;
                status = BLL.set_ApplicantExperience(_obj_smhr_applicant);
                Mode = 2;
                clearExpFields();
                int expSerial = getExpSerial();
                txt_Serial.Text = Convert.ToString(expSerial);
                LoadExperience();
            }*/
            if (Mode == 1)
            {
                dtExperience = (DataTable)ViewState["dtExperience"];
                DataRow dr;
                DataRow dr1 = dtExperience.Rows.Find(txt_Serial.Text);
                int RowIndex = 0;
                for (int index = 0; index < dtExperience.Rows.Count; index++)
                {
                    if (dtExperience.Rows[index].Equals(dr1))
                        RowIndex = index;
                }
                if (txt_JoinDate.SelectedDate != null && txt_RelieveDate.SelectedDate != null)
                {
                    if (Convert.ToDateTime(txt_JoinDate.SelectedDate) >= Convert.ToDateTime(txt_RelieveDate.SelectedDate))
                    {
                        BLL.ShowMessage(this, "Relieving Date should be Greater Than Joining Date");
                        return;
                    }
                }
                else if (txt_JoinDate.SelectedDate == null && txt_RelieveDate.SelectedDate != null)
                {
                    BLL.ShowMessage(this, "Please Enter Joining Date");
                    return;
                }
                Label lblPrevJDate = new Label();
                Label lblPrevRDate = new Label();
                Label lblNextJDate = new Label();
                Label lblNextRDate = new Label();
                int index1 = RG_Experience.Items.Count;
                if (index1 > 1)
                {
                    if (RowIndex == index1 - 1)//Edit Last Record
                    {
                        lblPrevRDate = RG_Experience.Items[RowIndex - 1].FindControl("lbl_Exp_RelDate") as Label;
                        DateTime dtPrevRDate = GetDateTime(lblPrevRDate.Text);//GetDateTime(lblPrevRDate.Text);
                        if (Convert.ToDateTime(dtPrevRDate) >= Convert.ToDateTime(txt_JoinDate.SelectedDate))
                        {
                            BLL.ShowMessage(this, "Joining Date should be greater than Previous Company Relieving Date");
                            return;
                        }
                    }
                    else if (RowIndex > 0)//Edit Middle Records
                    {

                        lblPrevRDate = RG_Experience.Items[RowIndex - 1].FindControl("lbl_Exp_RelDate") as Label;
                        lblNextJDate = RG_Experience.Items[RowIndex + 1].FindControl("lbl_Exp_JoinDate") as Label;
                        DateTime dtPrevRDate = GetDateTime(lblPrevRDate.Text);
                        DateTime dtNextJDate = GetDateTime(lblNextJDate.Text);
                        if (Convert.ToDateTime(dtPrevRDate) >= Convert.ToDateTime(txt_JoinDate.SelectedDate))
                        {
                            BLL.ShowMessage(this, "Joining Date should be greater than Previous Company Relieving Date");
                            return;
                        }
                        if (Convert.ToDateTime(txt_RelieveDate.SelectedDate) >= Convert.ToDateTime(dtNextJDate))
                        {
                            BLL.ShowMessage(this, "Relieve Date should be less than Next Company Joining Date");
                            return;
                        }
                    }
                    else if (RowIndex == 0)//Edit First Record
                    {
                        lblNextJDate = RG_Experience.Items[RowIndex + 1].FindControl("lbl_Exp_JoinDate") as Label;
                        DateTime dtNextJDate = GetDateTime(lblNextJDate.Text);
                        if (Convert.ToDateTime(dtNextJDate) <= Convert.ToDateTime(txt_RelieveDate.SelectedDate))
                        {
                            BLL.ShowMessage(this, "Relieving Date should be less than Next Company Joining Date");
                            return;
                        }
                    }
                }
                dr = dtExperience.Rows[RowIndex];
                dr.BeginEdit();
                dr[0] = "0";
                dr[1] = txt_Serial.Text;
                if (txt_JoinDate.SelectedDate != null)
                {
                    dr[3] = Convert.ToDateTime(txt_JoinDate.SelectedDate).ToString("dd/MM/yyyy");
                }
                else
                {
                    dr[3] = null;
                }
                if (txt_RelieveDate.SelectedDate != null)
                {
                    dr[7] = Convert.ToDateTime(txt_RelieveDate.SelectedDate).ToString("dd/MM/yyyy");
                }
                else
                {
                    dr[7] = null;

                }
                dr[2] = txt_CompanyName.Text;
                // dr[3] = Convert.ToDateTime(txt_JoinDate.SelectedDate).ToShortDateString();
                dr[4] = txt_JoinSalary.Value;
                dr[5] = txt_JoinDesc.Text;
                dr[6] = txt_ReasonRelieve.Text;
                // dr[7] = Convert.ToDateTime(txt_RelieveDate.SelectedDate).ToShortDateString();
                dr[8] = txt_RelSalary.Value;
                dr[9] = txt_RelDesc.Text;
                dr.EndEdit();
                RG_Experience.DataSource = dtExperience;
                RG_Experience.DataBind();
                clearExpFields();
                btn_Exp_Add.Visible = true;
                btn_Exp_Correct.Visible = false;
                int expSerial = getExpSerial();
                txt_Serial.Text = Convert.ToString(expSerial);
                Mode = 0;
            }
            else
            {
                if (!string.IsNullOrEmpty(HF_APID.Value))
                {

                    if (txt_JoinDate.SelectedDate != null && txt_RelieveDate.SelectedDate != null)
                    {
                        if (Convert.ToDateTime(txt_JoinDate.SelectedDate) >= Convert.ToDateTime(txt_RelieveDate.SelectedDate))
                        {
                            BLL.ShowMessage(this, "Relieving Date should be Greater Than Joining Date");
                            return;
                        }
                    }
                    else if (txt_JoinDate.SelectedDate == null && txt_RelieveDate.SelectedDate != null)
                    {
                        BLL.ShowMessage(this, "Please Enter Joining Date");
                        return;
                    }
                    //dtExperience = (DataTable)ViewState["dtExperience"];
                    // DataRow dr;
                    //DataRow dr1 = dtExperience.Rows.Find(txt_Serial.Text);
                    int RowIndex = Convert.ToInt32(rgExperienceEditIndex.Value);
                    //for (int index = 0; index < RG_Experience. .Rows.Count; index++)
                    //{
                    //    if (dtExperience.Rows[index].Equals(dr1))
                    //        RowIndex = index;
                    //}
                    Label lblPrevJDate = new Label();
                    Label lblPrevRDate = new Label();
                    Label lblNextJDate = new Label();
                    Label lblNextRDate = new Label();
                    int index1 = RG_Experience.Items.Count;
                    if (index1 > 1)
                    {
                        if (RowIndex == index1 - 1)//Edit Last Record
                        {
                            lblPrevRDate = RG_Experience.Items[RowIndex - 1].FindControl("lbl_Exp_RelDate") as Label;
                            DateTime dtPrevRDate = GetDateTime(lblPrevRDate.Text);//GetDateTime(lblPrevRDate.Text);
                            if (Convert.ToDateTime(dtPrevRDate) >= Convert.ToDateTime(txt_JoinDate.SelectedDate))
                            {
                                BLL.ShowMessage(this, "Joining Date should be greater than Previous Company Relieving Date");
                                return;
                            }
                        }
                        else if (RowIndex > 0)//Edit Middle Records
                        {

                            lblPrevRDate = RG_Experience.Items[RowIndex - 1].FindControl("lbl_Exp_RelDate") as Label;
                            lblNextJDate = RG_Experience.Items[RowIndex + 1].FindControl("lbl_Exp_JoinDate") as Label;
                            DateTime dtPrevRDate = GetDateTime(lblPrevRDate.Text);
                            DateTime dtNextJDate = GetDateTime(lblNextJDate.Text);
                            if (Convert.ToDateTime(dtPrevRDate) >= Convert.ToDateTime(txt_JoinDate.SelectedDate))
                            {
                                BLL.ShowMessage(this, "Joining Date should be greater than Previous Company Relieving Date");
                                return;
                            }
                            if (Convert.ToDateTime(txt_RelieveDate.SelectedDate) >= Convert.ToDateTime(dtNextJDate))
                            {
                                BLL.ShowMessage(this, "Relieve Date should be less than Next Company Joining Date");
                                return;
                            }
                        }
                        else if (RowIndex == 0)//Edit First Record
                        {
                            lblNextJDate = RG_Experience.Items[RowIndex + 1].FindControl("lbl_Exp_JoinDate") as Label;
                            DateTime dtNextJDate = GetDateTime(lblNextJDate.Text);
                            if (Convert.ToDateTime(dtNextJDate) <= Convert.ToDateTime(txt_RelieveDate.SelectedDate))
                            {
                                BLL.ShowMessage(this, "Relieving Date should be less than Next Company Joining Date");
                                return;
                            }
                        }
                    }



                    _obj_smhr_applicant = new SMHR_APPLICANT();
                    bool status = false;
                    _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                    _obj_smhr_applicant.APPEXP_ID = Convert.ToInt32(HF_ID.Value);//Convert.ToInt32(_lbl_ID);
                    _obj_smhr_applicant.APPEXP_SERIAL = Convert.ToInt32(txt_Serial.Text);
                    _obj_smhr_applicant.APPEXP_COMPANY = Convert.ToString(txt_CompanyName.Text.Replace("'", "''"));
                    if (txt_JoinDate.SelectedDate != null)
                    {
                        _obj_smhr_applicant.APPEXP_JOINDATE = Convert.ToDateTime(txt_JoinDate.SelectedDate.Value);
                    }
                    else
                    {
                        _obj_smhr_applicant.APPEXP_JOINDATE = null;
                    }
                    if (txt_RelieveDate.SelectedDate != null)
                    {
                        _obj_smhr_applicant.APPEXP_RELDATE = Convert.ToDateTime(txt_RelieveDate.SelectedDate.Value);
                    }
                    else
                    {
                        _obj_smhr_applicant.APPEXP_RELDATE = null;

                    }

                    _obj_smhr_applicant.APPEXP_JOINSAL = Convert.ToDouble(txt_JoinSalary.Value);
                    _obj_smhr_applicant.APPEXP_JOINDESC = Convert.ToString(txt_JoinDesc.Text.Replace("'", "''"));
                    _obj_smhr_applicant.APPEXP_REASONREL = Convert.ToString(txt_ReasonRelieve.Text.Replace("'", "''"));

                    _obj_smhr_applicant.APPEXP_RELSAL = Convert.ToDouble(txt_RelSalary.Value);
                    _obj_smhr_applicant.APPEXP_REASONDESC = Convert.ToString(txt_RelDesc.Text.Replace("'", "''"));
                    _obj_smhr_applicant.APPEXP_LASTMDFBY = 1;
                    _obj_smhr_applicant.APPEXP_LASTMDFDATE = Convert.ToString(DateTime.Now);
                    _obj_smhr_applicant.OPERATION = operation.Update;
                    status = BLL.set_ApplicantExperience(_obj_smhr_applicant);
                    Mode = 2;
                    clearExpFields();
                    int expSerial = getExpSerial();
                    txt_Serial.Text = Convert.ToString(expSerial);
                    LoadExperience();
                }
                else
                {
                    dtExperience = (DataTable)ViewState["dtExperience"];
                    DataRow dr;
                    DataRow dr1 = dtExperience.Rows.Find(txt_Serial.Text);
                    int RowIndex = 0;
                    for (int index = 0; index < dtExperience.Rows.Count; index++)
                    {
                        if (dtExperience.Rows[index].Equals(dr1))
                            RowIndex = index;
                    }
                    if (txt_JoinDate.SelectedDate != null && txt_RelieveDate.SelectedDate != null)
                    {
                        if (Convert.ToDateTime(txt_JoinDate.SelectedDate) >= Convert.ToDateTime(txt_RelieveDate.SelectedDate))
                        {
                            BLL.ShowMessage(this, "Joining Date should be Greater Than  Relieving Date");
                            return;
                        }
                    }
                    else if (txt_JoinDate.SelectedDate == null && txt_RelieveDate.SelectedDate != null)
                    {
                        BLL.ShowMessage(this, "Please Enter Joining Date");
                        return;
                    }
                    Label lblPrevJDate = new Label();
                    Label lblPrevRDate = new Label();
                    Label lblNextJDate = new Label();
                    Label lblNextRDate = new Label();
                    int index1 = RG_Experience.Items.Count;
                    if (index1 > 1)
                    {
                        if (RowIndex == index1 - 1)//Edit Last Record
                        {
                            lblPrevRDate = RG_Experience.Items[RowIndex - 1].FindControl("lbl_Exp_RelDate") as Label;
                            DateTime dtPrevRDate = GetDateTime(lblPrevRDate.Text);//GetDateTime(lblPrevRDate.Text);
                            if (Convert.ToDateTime(dtPrevRDate) >= Convert.ToDateTime(txt_JoinDate.SelectedDate))
                            {
                                BLL.ShowMessage(this, "Joining Date should be greater than Previous Company Relieving Date");
                                return;
                            }
                        }
                        else if (RowIndex > 0)//Edit Middle Records
                        {

                            lblPrevRDate = RG_Experience.Items[RowIndex - 1].FindControl("lbl_Exp_RelDate") as Label;
                            lblNextJDate = RG_Experience.Items[RowIndex + 1].FindControl("lbl_Exp_JoinDate") as Label;
                            DateTime dtPrevRDate = GetDateTime(lblPrevRDate.Text);
                            DateTime dtNextJDate = GetDateTime(lblNextJDate.Text);
                            if (Convert.ToDateTime(dtPrevRDate) >= Convert.ToDateTime(txt_JoinDate.SelectedDate))
                            {
                                BLL.ShowMessage(this, "Joining Date should be greater than Previous Company Relieving Date");
                                return;
                            }
                            if (Convert.ToDateTime(txt_RelieveDate.SelectedDate) >= Convert.ToDateTime(dtNextJDate))
                            {
                                BLL.ShowMessage(this, "Relieve Date should be less than Next Company Joining Date");
                                return;
                            }
                        }
                        else if (RowIndex == 0)//Edit First Record
                        {
                            lblNextJDate = RG_Experience.Items[RowIndex + 1].FindControl("lbl_Exp_JoinDate") as Label;
                            DateTime dtNextJDate = GetDateTime(lblNextJDate.Text);
                            if (Convert.ToDateTime(dtNextJDate) <= Convert.ToDateTime(txt_RelieveDate.SelectedDate))
                            {
                                BLL.ShowMessage(this, "Relieving Date should be less than Next Company Joining Date");
                                return;
                            }
                        }
                    }
                    dr = dtExperience.Rows[RowIndex];
                    dr.BeginEdit();
                    dr[0] = "0";
                    dr[1] = txt_Serial.Text;
                    dr[2] = txt_CompanyName.Text;
                    dr[3] = Convert.ToDateTime(txt_JoinDate.SelectedDate).ToString("dd/MM/yyyy");
                    dr[4] = txt_JoinSalary.Value;
                    dr[5] = txt_JoinDesc.Text;
                    dr[6] = txt_ReasonRelieve.Text;
                    dr[7] = Convert.ToDateTime(txt_RelieveDate.SelectedDate).ToString("dd/MM/yyyy");
                    dr[8] = txt_RelSalary.Value;
                    dr[9] = txt_RelDesc.Text;
                    dr.EndEdit();
                    RG_Experience.DataSource = dtExperience;
                    RG_Experience.DataBind();
                    clearExpFields();
                    btn_Exp_Add.Visible = true;
                    btn_Exp_Correct.Visible = false;
                    int expSerial = getExpSerial();
                    txt_Serial.Text = Convert.ToString(expSerial);
                    Mode = 0;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Contact_Correct_Click(object sender, EventArgs e)
    {
        try
        {
            if (Mode == 1)
            {
                dt_Contact = (DataTable)ViewState["dt_Contact"];
                DataRow dr;
                DataRow dr1 = dt_Contact.Rows.Find(txt_Serail_C.Text);
                int RowIndex = 0;
                for (int Index = 0; Index < dt_Contact.Rows.Count; Index++)
                {
                    if (dt_Contact.Rows[Index].Equals(dr1))
                        RowIndex = Index;
                }
                dr = dt_Contact.Rows[RowIndex];
                dr.BeginEdit();
                dr[0] = "0";
                dr[1] = txt_Serail_C.Text;
                dr[2] = txt_Company_C.Text;
                dr[3] = txt_ContactName.Text;
                dr[4] = txt_PhoneNumber.Text;
                dr[5] = txt_Address_C.Text;
                dr.EndEdit();
                RG_Contact.DataSource = dt_Contact;
                RG_Contact.DataBind();
                clearConFields();
                int conSerial = getContactSerial();
                txt_Serail_C.Text = Convert.ToString(conSerial);
                btn_Contact_Add.Visible = true;
                btn_Contact_Correct.Visible = false;
                Mode = 2;
            }
            else
            {
                _obj_smhr_applicant = new SMHR_APPLICANT();
                bool status = false;
                _obj_smhr_applicant.OPERATION = operation.Update;
                _obj_smhr_applicant.APPCONT_ID = Convert.ToInt32(HF_ID.Value); //Convert.ToInt32(_lbl_ID);
                _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                _obj_smhr_applicant.APPCONT_SERIAL = Convert.ToInt32(txt_Serail_C.Text.Replace("'", "''"));
                _obj_smhr_applicant.APPCONT_COMPANY = Convert.ToString(txt_Company_C.Text.Replace("'", "''"));
                _obj_smhr_applicant.APPCONT_CONTACT = Convert.ToString(txt_ContactName.Text.Replace("'", "''"));
                _obj_smhr_applicant.APPCONT_PHONE = Convert.ToString(txt_PhoneNumber.Text.Replace("'", "''"));
                _obj_smhr_applicant.APPCONT_ADDRESS = Convert.ToString(txt_Address_C.Text.Replace("'", "''"));
                //_obj_smhr_applicant.APPCONT_LASTMDFBY = 1;
                _obj_smhr_applicant.APPCONT_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_smhr_applicant.APPCONT_LASTMDFDATE = DateTime.Now;
                status = BLL.set_ApplicantContact(_obj_smhr_applicant);
                clearConFields();
                Mode = 2;
                int conSerial = getContactSerial();
                txt_Serail_C.Text = Convert.ToString(conSerial);
                LoadContact();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Lang_Correct_Click(object sender, EventArgs e)
    {
        try
        {
            if (Mode == 1)
            {
                if (chk_Read.Checked == false && chk_Speak.Checked == false && chk_Understand.Checked == false && chk_Write.Checked == false)
                {
                    BLL.ShowMessage(this, "Please check atleast one language mode");
                    return;
                }
                dtLanguage = (DataTable)ViewState["dtLanguage"];
                DataRow dr;
                DataRow dr1 = dtLanguage.Rows.Find(ddl_Language.SelectedValue);
                int RowIndex = 0;
                for (int index = 0; index < dtLanguage.Rows.Count; index++)
                {
                    if (dtLanguage.Rows[index].Equals(dr1))
                        RowIndex = index;
                }
                dr = dtLanguage.Rows[RowIndex];
                dr.BeginEdit();
                dr[0] = ddl_Language.SelectedValue;
                dr[1] = ddl_Language.SelectedValue;
                dr[2] = ddl_Language.SelectedItem.Text;
                if (chk_Read.Checked)
                    dr[3] = true;
                else
                    dr[3] = false;
                if (chk_Write.Checked)
                    dr[4] = true;
                else
                    dr[4] = false;
                if (chk_Speak.Checked)
                    dr[5] = true;
                else
                    dr[5] = false;
                if (chk_Understand.Checked)
                    dr[6] = true;
                else
                    dr[6] = false;
                dr.EndEdit();
                RG_Language.DataSource = dtLanguage;
                RG_Language.DataBind();
                clearLangFields();
                btn_Lang_Add.Visible = true;
                btn_Lang_Correct.Visible = false;
                ddl_Language.Enabled = true;
                Mode = 2;
            }
            else
            {
                if (chk_Read.Checked == false && chk_Speak.Checked == false && chk_Understand.Checked == false && chk_Write.Checked == false)
                {
                    BLL.ShowMessage(this, "Please check atleast one language mode");
                    return;
                }
                _obj_smhr_applicant = new SMHR_APPLICANT();
                bool status = false;
                _obj_smhr_applicant.OPERATION = operation.Update;
                _obj_smhr_applicant.APPLAN_ID = Convert.ToInt32(HF_ID.Value); //Convert.ToInt32(_lbl_ID);
                _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                _obj_smhr_applicant.APPLAN_LANGUAGE_ID = Convert.ToInt32(ddl_Language.SelectedValue);
                if (chk_Read.Checked)
                    _obj_smhr_applicant.APPLAN_READ = true;
                else
                    _obj_smhr_applicant.APPLAN_READ = false;
                if (chk_Write.Checked)
                    _obj_smhr_applicant.APPLAN_WRITE = true;
                else
                    _obj_smhr_applicant.APPLAN_WRITE = false;
                if (chk_Speak.Checked)
                    _obj_smhr_applicant.APPLAN_SPEAK = true;
                else
                    _obj_smhr_applicant.APPLAN_SPEAK = false;
                if (chk_Understand.Checked)
                    _obj_smhr_applicant.APPLAN_UNDERSTAND = true;
                else
                    _obj_smhr_applicant.APPLAN_UNDERSTAND = false;
                _obj_smhr_applicant.APPLAN_LASTMDFBY = 1;
                _obj_smhr_applicant.APPLAN_LASTMDFDATE = DateTime.Now;
                status = BLL.set_ApplicantLanguage(_obj_smhr_applicant);
                clearLangFields();
                Mode = 2;
                LoadLanguage();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Ref_Correct_Click(object sender, EventArgs e)
    {
        try
        {
            if (Mode == 1)
            {
                dtReference = (DataTable)ViewState["dtReference"];
                DataRow dr;
                DataRow dr1 = dtReference.Rows.Find(ddl_Employee.SelectedValue);
                int RowIndex = 0;
                for (int Index = 0; Index < dtReference.Rows.Count; Index++)
                {
                    if (dtReference.Rows[Index].Equals(dr1))
                        RowIndex = Index;
                }
                dr = dtReference.Rows[RowIndex];
                dr.BeginEdit();
                dr[0] = "0";
                dr[1] = ddl_Employee.SelectedValue;
                dr[2] = ddl_Employee.SelectedItem.Text;
                dr[3] = ddl_Relationship.SelectedValue;
                dr[4] = ddl_Relationship.SelectedItem.Text;
                if (chk_Referred.Checked)
                    dr[5] = true;
                else
                    dr[5] = false;
                dr.EndEdit();
                RG_Reference.DataSource = dtReference;
                RG_Reference.DataBind();
                btn_Ref_Add.Visible = true;
                btn_Ref_Correct.Visible = false;
                ddl_Employee.Enabled = true;
                clearRefFields();
                Mode = 2;
            }
            else if (Mode == 3)
            {
                _obj_smhr_applicant = new SMHR_APPLICANT();
                bool status = false;
                _obj_smhr_applicant.OPERATION = operation.Update;
                _obj_smhr_applicant.APPREF_ID = Convert.ToInt32(HF_ID.Value); //Convert.ToInt32(_lbl_ID);
                _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                _obj_smhr_applicant.APPREF_REFFERED_EMP_ID = Convert.ToInt32(ddl_Employee.SelectedValue);
                _obj_smhr_applicant.APPREF_RELATIONSHIP = Convert.ToInt32(ddl_Relationship.SelectedValue);
                if (chk_Referred.Checked)
                    _obj_smhr_applicant.APPREF_REFERRED = true;
                else
                    _obj_smhr_applicant.APPREF_REFERRED = false;
                _obj_smhr_applicant.APPREF_LASTMDFBY = 1;
                _obj_smhr_applicant.APPREF_LASTMDFDATE = DateTime.Now;
                status = BLL.set_ApplicantReference(_obj_smhr_applicant);
                clearRefFields();
                Mode = 2;
                LoadReference();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region Cancel

    protected void btn_Qual_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearQualFields();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void btn_Exp_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearExpFields();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void btn_Contact_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearConFields();
            int conSerial = getContactSerial();
            txt_Serail_C.Text = Convert.ToString(conSerial);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void btn_Lang_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearLangFields();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void btn_Ref_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearRefFields();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    #endregion

    #region ClearFields

    private void clearQualFields()
    {
        try
        {
            ddl_Category.SelectedIndex = -1;
            txt_Institute.Text = string.Empty;
            txt_YearofPass.Value = null;
            txt_Percentage.Value = null;
            ddl_Grade.SelectedIndex = -1;
            btn_Qual_Add.Visible = true;
            btn_Qual_Correct.Visible = false;
            ddl_Category.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void clearSkillFields()
    {
        try
        {
            rcb_Skill.SelectedIndex = -1;
            //rcb_YearLastUsed.SelectedIndex = -1;
            rcb_ExpertLevel.SelectedIndex = -1;
            btn_Skill_Add.Visible = true;
            btn_Skill_Correct.Visible = false;
            rcb_Skill.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void clearConFields()
    {
        try
        {
            txt_Serail_C.Text = string.Empty;
            txt_Company_C.Text = string.Empty;
            txt_ContactName.Text = string.Empty;
            txt_PhoneNumber.Text = string.Empty;
            txt_Address_C.Text = string.Empty;
            btn_Contact_Add.Visible = true;
            btn_Contact_Correct.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void clearLangFields()
    {
        try
        {
            ddl_Language.SelectedIndex = -1;
            chk_Write.Checked = false;
            chk_Understand.Checked = false;
            chk_Speak.Checked = false;
            chk_Read.Checked = false;
            btn_Lang_Add.Visible = true;
            btn_Lang_Correct.Visible = false;
            ddl_Language.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void clearExpFields()
    {
        try
        {
            txt_CompanyName.Text = string.Empty;
            txt_JoinDate.SelectedDate = null;
            txt_JoinDesc.Text = string.Empty;
            txt_JoinSalary.Value = null;
            txt_ReasonRelieve.Text = string.Empty;
            txt_RelDesc.Text = string.Empty;
            txt_RelieveDate.SelectedDate = null;
            txt_RelSalary.Value = null;
            btn_Exp_Add.Visible = true;
            btn_Exp_Correct.Visible = false;
            int count = 0;
            count = RG_Experience.Items.Count;
            if (count == 0)
            {
                txt_Serial.Text = "1";
            }
            else
            {
                count += 1;
                txt_Serial.Text = Convert.ToString(count);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void clearRefFields()
    {
        try
        {
            ddl_Employee.SelectedIndex = -1;
            ddl_Relationship.SelectedIndex = -1;
            chk_Referred.Checked = false;
            btn_Ref_Add.Visible = true;
            btn_Ref_Correct.Visible = false;
            ddl_BU.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region MainMethods

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            //if (FUpload.HasFile)
            //{
            //    if (!FUpload.PostedFile.FileName.EndsWith(".doc"))
            //    {
            //        BLL.ShowMessage(this, "Only .doc files are valid to upload");
            //        return;
            //    }
            //}
            _obj_smhr_applicant = new SMHR_APPLICANT();
            bool status = false;
            getCode();
            _obj_smhr_applicant.OPERATION = operation.Insert;
            _obj_smhr_applicant.APPLICANT_CODE = Convert.ToString(txt_AppCode.Text);
            _obj_smhr_applicant.APPLICANT_TITLE = Convert.ToString(ddl_Title.SelectedValue);
            _obj_smhr_applicant.APPLICANT_FIRSTNAME = Convert.ToString(txt_FirstName.Text.Replace("'", "''"));
            _obj_smhr_applicant.APPLICANT_MIDDLENAME = Convert.ToString(txt_AppMiddleName.Text.Replace("'", "''"));
            _obj_smhr_applicant.APPLICANT_LASTNAME = Convert.ToString(txt_AppLastName.Text.Replace("'", "''"));
            if (txt_DOB.SelectedDate!=null)
            {
                 _obj_smhr_applicant.APPLICANT_DOB = txt_DOB.SelectedDate.Value;
            }
           
            _obj_smhr_applicant.APPLICANT_GENDER = Convert.ToString(ddl_Gender.SelectedValue);
            _obj_smhr_applicant.APPLICANT_BLOODGROUP = Convert.ToString(ddl_BloodGroup.SelectedValue);
            if (ddl_Religion.SelectedValue != "")
            {
                _obj_smhr_applicant.APPLICANT_RELIGION_ID = Convert.ToInt32(ddl_Religion.SelectedValue);
            }
            if (ddl_Nationality.SelectedValue != "")
            {
                _obj_smhr_applicant.APPLICANT_NATIONALITY_ID = Convert.ToInt32(ddl_Nationality.SelectedValue);
            }
            _obj_smhr_applicant.APPLICANT_STATUS = Convert.ToString(ddl_Status.SelectedItem.Value);
            _obj_smhr_applicant.APPLICANT_MARITALSTATUS = Convert.ToString(ddl_MaritalStatus.SelectedValue);
            _obj_smhr_applicant.APPLICANT_ADDRESS = Convert.ToString(txt_Address.Text);
            _obj_smhr_applicant.APPLICANT_REMARKS = Convert.ToString(txt_Remarks.Text);
            _obj_smhr_applicant.APPLICANT_TYPE = string.Empty;
            _obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_applicant.APPLICANT_EMAIL = Convert.ToString(rtxt_Email.Text);
            _obj_smhr_applicant.APPLICANT_MOBILE = Convert.ToString(rmtxt_MobileNo.Text);
            if (!string.IsNullOrEmpty(FUpload.PostedFile.FileName))
            {
                FUpload.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/EmpUploads"), txt_AppCode.Text + "_" + FUpload.FileName));
                _obj_smhr_applicant.APPLICANT_RESUME = "~/EmpUploads/" + txt_AppCode.Text + "_" + FUpload.FileName;
            }
            else
            {
                _obj_smhr_applicant.APPLICANT_RESUME = string.Empty;
            }
            _obj_smhr_applicant.APPLICANT_CREATEDBY = "1";
            _obj_smhr_applicant.APPLICANT_CREATEDDATE = DateTime.Now;
            status = BLL.set_Applicant(_obj_smhr_applicant);
            if (status == true)
            {
                _obj_smhr_applicant.OPERATION = operation.Check;
                _obj_smhr_applicant.APPLICANT_CODE = Convert.ToString(txt_AppCode.Text);
                DataTable dt_Det = BLL.get_Applicant(_obj_smhr_applicant);
                if (dt_Det.Rows.Count != 0)
                {
                    //_lbl_App_ID = Convert.ToString(dt_Det.Rows[0][0]);
                    HF_APID.Value = Convert.ToString(dt_Det.Rows[0][0]);
                    //Save Qualification
                    if (RG_Qualification.Items.Count != 0)
                    {
                        saveQualification();
                    }
                    //Save Experience
                    if (RG_Experience.Items.Count != 0)
                    {
                        saveExperience();
                    }
                    //Save Skills
                    if (RG_Skills.Items.Count != 0)
                    {
                        saveSkill();
                    }
                    //Save Reference 
                    if (RG_Reference.Items.Count != 0)
                    {
                        saveReference();
                    }
                    //Save Contact
                    if (RG_Contact.Items.Count != 0)
                    {
                        saveContact();
                    }
                    //Save Language
                    if (RG_Language.Items.Count != 0)
                    {
                        saveLanguage();
                    }
                    //BLL.ShowMessage(this, "Applicant Inserted Successfully");
                    //Response.Redirect("~/Recruitment/frmapplicant.aspx", false);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Applicant Inserted Successfully'); window.location='" + Request.ApplicationPath + "Recruitment/frmapplicant.aspx';", true);
                }
                else
                {
                    BLL.ShowMessage(this, "Error occured while doing the process");
                    return;
                }

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Recruitment/frmapplicant.aspx",false);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Update_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_smhr_applicant = new SMHR_APPLICANT();
            _obj_smhr_applicant.OPERATION = operation.Check;
            _obj_smhr_applicant.APPLICANT_CODE = Convert.ToString(txt_AppCode.Text);
            DataTable dt_Det = BLL.get_Applicant(_obj_smhr_applicant);
            if (dt_Det.Rows.Count != 0)
            {
                //_lbl_App_ID = Convert.ToString(dt_Det.Rows[0][0]);
                HF_APID.Value = Convert.ToString(dt_Det.Rows[0][0]);
            }
            bool status = false;

            _obj_smhr_applicant = new SMHR_APPLICANT();
            _obj_smhr_applicant.OPERATION = operation.Update;
            _obj_smhr_applicant.APPLICANT_CODE = Convert.ToString(txt_AppCode.Text);
            _obj_smhr_applicant.APPLICANT_TITLE = Convert.ToString(ddl_Title.SelectedValue);
            _obj_smhr_applicant.APPLICANT_FIRSTNAME = Convert.ToString(txt_FirstName.Text.Replace("'", "''"));
            _obj_smhr_applicant.APPLICANT_MIDDLENAME = Convert.ToString(txt_AppMiddleName.Text.Replace("'", "''"));
            _obj_smhr_applicant.APPLICANT_LASTNAME = Convert.ToString(txt_AppLastName.Text.Replace("'", "''"));
            _obj_smhr_applicant.APPLICANT_DOB = Convert.ToDateTime(txt_DOB.SelectedDate);
            _obj_smhr_applicant.APPLICANT_GENDER = Convert.ToString(ddl_Gender.SelectedValue);
            _obj_smhr_applicant.APPLICANT_BLOODGROUP = Convert.ToString(ddl_BloodGroup.SelectedValue);
            if (ddl_Religion.SelectedValue != "")
            {
                _obj_smhr_applicant.APPLICANT_RELIGION_ID = Convert.ToInt32(ddl_Religion.SelectedValue);
            }
            if (ddl_Nationality.SelectedValue != "")
            {
                _obj_smhr_applicant.APPLICANT_NATIONALITY_ID = Convert.ToInt32(ddl_Nationality.SelectedValue);
            }
            _obj_smhr_applicant.APPLICANT_STATUS = Convert.ToString(ddl_Status.SelectedItem.Value);
            _obj_smhr_applicant.APPLICANT_MARITALSTATUS = Convert.ToString(ddl_MaritalStatus.SelectedValue);
            _obj_smhr_applicant.APPLICANT_ADDRESS = Convert.ToString(txt_Address.Text);
            _obj_smhr_applicant.APPLICANT_EMAIL = Convert.ToString(rtxt_Email.Text);
            _obj_smhr_applicant.APPLICANT_MOBILE = Convert.ToString(rmtxt_MobileNo.Text);
            _obj_smhr_applicant.APPLICANT_REMARKS = Convert.ToString(txt_Remarks.Text);
            _obj_smhr_applicant.APPLICANT_TYPE = string.Empty;
            _obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            if (!string.IsNullOrEmpty(FUpload.PostedFile.FileName))
            {
                FUpload.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/EmpUploads"), txt_AppCode.Text + "_" + FUpload.FileName));
                _obj_smhr_applicant.APPLICANT_RESUME = "~/EmpUploads/" + txt_AppCode.Text + "_" + FUpload.FileName;
            }
            else
            {
                if (ViewState["fileLocation"] != null)
                {
                    _obj_smhr_applicant.APPLICANT_RESUME = Convert.ToString(ViewState["fileLocation"]);
                }
            }
            _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
            _obj_smhr_applicant.APPLICANT_LASTMDFBY = 1;
            _obj_smhr_applicant.APPLICANT_LASTMDFDATE = DateTime.Now;
            status = BLL.set_Applicant(_obj_smhr_applicant);
            if (status == true)
            {
                string host = HttpContext.Current.Request.Url.AbsoluteUri;
                host = (host.Substring(0, host.LastIndexOf("=") + 1)).Replace("/Recruitment/frm_applicantadd.aspx?APPID=", "");
                
                //BLL.ShowMessage(this, "Applicant Updated Successfully");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Applicant Updated Successfully'); window.location='" + host + "/" + "Recruitment/frmapplicant.aspx';", true);
                //Response.Redirect("~/Recruitment/frmapplicant.aspx", false);
            }
            else
            {
                BLL.ShowMessage(this, "Error occured while doing the process");
                return;
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
        }
    }

    #endregion

    #region ItemCommand

    protected void RG_Qualification_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
    {
        try
        {
            if (Mode == 0)
            {
                if (e.CommandName == "Edit_Rec")
                {
                    GridDataItem dtItem = (GridDataItem)e.Item;
                    int index = dtItem.ItemIndex;
                    Label lblID = new Label();
                    Label lblInstitute = new Label();
                    Label lblYearPass = new Label();
                    Label lblPercent = new Label();
                    Label lblGrade = new Label();
                    lblID = RG_Qualification.Items[index].FindControl("lbl_ID") as Label;
                    lblInstitute = RG_Qualification.Items[index].FindControl("lbl_AppInstitute") as Label;
                    lblYearPass = RG_Qualification.Items[index].FindControl("lbl_AppYearPass") as Label;
                    lblPercent = RG_Qualification.Items[index].FindControl("lbl_AppPercentage") as Label;
                    lblGrade = RG_Qualification.Items[index].FindControl("lbl_AppGrade") as Label;
                    ddl_Category.SelectedIndex = ddl_Category.FindItemIndexByValue(lblID.Text);
                    txt_Institute.Text = Convert.ToString(lblInstitute.Text);
                    txt_YearofPass.Value = Convert.ToDouble(lblYearPass.Text);
                    txt_Percentage.Value = Convert.ToDouble(lblPercent.Text);
                    ddl_Grade.SelectedIndex = ddl_Grade.FindItemIndexByValue(lblGrade.Text);
                    Mode = 1;
                    btn_Qual_Add.Visible = false;
                    if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                    {
                        btn_Qual_Correct.Visible = false;

                    }

                    else
                    {
                        btn_Qual_Correct.Visible = true;
                    }

                }
            }
            else
            {
                if (e.CommandName == "Edit_Rec")
                {
                    GridDataItem dtItem = (GridDataItem)e.Item;
                    int index = dtItem.ItemIndex;
                    Label lbl_ID = new Label();
                    Label lblID = new Label();
                    Label lblInstitute = new Label();
                    Label lblYearPass = new Label();
                    Label lblPercent = new Label();
                    Label lblGrade = new Label();
                    lbl_ID = RG_Qualification.Items[index].FindControl("lblID") as Label;
                    lblID = RG_Qualification.Items[index].FindControl("lbl_ID") as Label;
                    lblInstitute = RG_Qualification.Items[index].FindControl("lbl_AppInstitute") as Label;
                    lblYearPass = RG_Qualification.Items[index].FindControl("lbl_AppYearPass") as Label;
                    lblPercent = RG_Qualification.Items[index].FindControl("lbl_AppPercentage") as Label;
                    lblGrade = RG_Qualification.Items[index].FindControl("lbl_AppGrade") as Label;
                    ddl_Category.SelectedIndex = ddl_Category.FindItemIndexByValue(lblID.Text);
                    //_lbl_ID = lbl_ID.Text;
                    HF_ID.Value = lbl_ID.Text;
                    txt_Institute.Text = Convert.ToString(lblInstitute.Text);
                    txt_YearofPass.Value = Convert.ToDouble(lblYearPass.Text);
                    if (lblPercent.Text != "0")
                    {
                        txt_Percentage.Value = Convert.ToDouble(lblPercent.Text);
                    }
                    ddl_Grade.SelectedIndex = ddl_Grade.FindItemIndexByValue(lblGrade.Text);
                    ddl_Category.Enabled = false;
                    Mode = 3;
                    btn_Qual_Add.Visible = false;

                    if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                    {
                        btn_Qual_Correct.Visible = false;

                    }

                    else
                    {
                        btn_Qual_Correct.Visible = true;
                    }

                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
        }
    }

    protected void RG_Skills_ItemCommand(object source, GridCommandEventArgs e)
    {
        try
        {
            if (Mode == 0)
            {
                if (e.CommandName == "Edit_Rec")
                {
                    GridDataItem dtItem = (GridDataItem)e.Item;
                    int index = dtItem.ItemIndex;
                    Label lblID = new Label();
                    Label lblLastUsed = new Label();
                    Label lbl_ExpertID = new Label();
                    lblID = RG_Skills.Items[index].FindControl("lbl_Skill_ID") as Label;
                    lblLastUsed = RG_Skills.Items[index].FindControl("lbl_Skill_LastUsed") as Label;
                    lbl_ExpertID = RG_Skills.Items[index].FindControl("lbl_Skill_Exp_ID") as Label;
                    rcb_Skill.SelectedIndex = rcb_Skill.FindItemIndexByValue(lblID.Text);
                    //rcb_YearLastUsed.SelectedIndex = rcb_YearLastUsed.FindItemIndexByText(lblLastUsed.Text);
                    rcb_ExpertLevel.SelectedValue = Convert.ToString((lbl_ExpertID.Text).Trim());
                    btn_Skill_Add.Visible = false;
                    rcb_Skill.Enabled = false;
                    if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                    {
                        btn_Skill_Correct.Visible = false;

                    }

                    else
                    {
                        btn_Skill_Correct.Visible = true;
                    }

                    Mode = 1;
                }
            }
            else
            {
                if (e.CommandName == "Edit_Rec")
                {
                    GridDataItem dtItem = (GridDataItem)e.Item;
                    int index = dtItem.ItemIndex;
                    Label lbl_ID = new Label();
                    Label lblID = new Label();
                    Label lbl_ExpertID = new Label();
                    Label lblLastUsed = new Label();
                    lbl_ID = RG_Skills.Items[index].FindControl("lblID") as Label;
                    lblID = RG_Skills.Items[index].FindControl("lbl_Skill_ID") as Label;
                    lblLastUsed = RG_Skills.Items[index].FindControl("lbl_Skill_LastUsed") as Label;
                    lbl_ExpertID = RG_Skills.Items[index].FindControl("lbl_Skill_Exp_ID") as Label;
                    rcb_Skill.SelectedIndex = rcb_Skill.FindItemIndexByValue(lblID.Text);
                    //rcb_YearLastUsed.SelectedIndex = rcb_YearLastUsed.FindItemIndexByText(lblLastUsed.Text);
                    rcb_ExpertLevel.SelectedValue = Convert.ToString((lbl_ExpertID.Text).Trim());
                    //_lbl_ID = lbl_ID.Text;
                    HF_ID.Value = lbl_ID.Text;
                    btn_Skill_Add.Visible = false;
                    rcb_Skill.Enabled = false;
                    if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                    {
                        btn_Skill_Correct.Visible = false;

                    }

                    else
                    {
                        btn_Skill_Correct.Visible = true;
                    }

                    Mode = 3;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
        }
    }

    protected void RG_Experience_ItemCommand(object source, GridCommandEventArgs e)
    {
        try
        {
            if (Mode == 0)
            {
                if (e.CommandName == "Edit_Rec")
                {
                    GridDataItem dtItem = (GridDataItem)e.Item;
                    int index = dtItem.ItemIndex;

                    Label lblSerial = new Label();
                    Label lblCompany = new Label();
                    Label lblJDate = new Label();
                    Label lblJSal = new Label();
                    Label lblJdesc = new Label();
                    Label lblRDesc = new Label();
                    Label lblRSal = new Label();
                    Label lblRDate = new Label();
                    Label lblDesc = new Label();

                    lblSerial = RG_Experience.Items[index].FindControl("lbl_Exp_Serial") as Label;
                    lblCompany = RG_Experience.Items[index].FindControl("lbl_Exp_CompName") as Label;
                    lblJDate = RG_Experience.Items[index].FindControl("lbl_Exp_JoinDate") as Label;
                    lblJSal = RG_Experience.Items[index].FindControl("lbl_Exp_JoinSal") as Label;
                    lblJdesc = RG_Experience.Items[index].FindControl("lbl_Exp_JoinDesc") as Label;
                    lblRDesc = RG_Experience.Items[index].FindControl("lbl_Exp_RelReason") as Label;
                    lblRSal = RG_Experience.Items[index].FindControl("lbl_Exp_RelSalary") as Label;
                    lblRDate = RG_Experience.Items[index].FindControl("lbl_Exp_RelDate") as Label;
                    lblDesc = RG_Experience.Items[index].FindControl("lbl_Exp_RelDesc") as Label;

                    txt_Serial.Text = lblSerial.Text;
                    txt_CompanyName.Text = lblCompany.Text;
                    txt_JoinDate.SelectedDate = Convert.ToDateTime(lblJDate.Text);
                    txt_JoinSalary.Value = Convert.ToDouble(lblJSal.Text);
                    txt_JoinDesc.Text = lblJdesc.Text;
                    txt_ReasonRelieve.Text = lblRDesc.Text;
                    txt_RelSalary.Value = Convert.ToDouble(lblRSal.Text);
                    txt_RelieveDate.SelectedDate = Convert.ToDateTime(lblRDate.Text);
                    txt_RelDesc.Text = lblDesc.Text;
                    Mode = 1;
                    btn_Exp_Add.Visible = false;

                    if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                    {
                        btn_Exp_Correct.Visible = false;

                    }

                    else
                    {
                        btn_Exp_Correct.Visible = true;
                    }


                }
            }
            else
            {
                GridDataItem dtItem = (GridDataItem)e.Item;
                int index = dtItem.ItemIndex;
                rgExperienceEditIndex.Value = Convert.ToString(index);
                Label lblID = new Label();
                Label lblSerial = new Label();
                Label lblCompany = new Label();
                Label lblJDate = new Label();
                Label lblJSal = new Label();
                Label lblJdesc = new Label();
                Label lblRDesc = new Label();
                Label lblRSal = new Label();
                Label lblRDate = new Label();
                Label lblDesc = new Label();

                lblID = RG_Experience.Items[index].FindControl("lblID") as Label;
                lblSerial = RG_Experience.Items[index].FindControl("lbl_Exp_Serial") as Label;
                lblCompany = RG_Experience.Items[index].FindControl("lbl_Exp_CompName") as Label;
                lblJDate = RG_Experience.Items[index].FindControl("lbl_Exp_JoinDate") as Label;
                lblJSal = RG_Experience.Items[index].FindControl("lbl_Exp_JoinSal") as Label;
                lblJdesc = RG_Experience.Items[index].FindControl("lbl_Exp_JoinDesc") as Label;
                lblRDesc = RG_Experience.Items[index].FindControl("lbl_Exp_RelReason") as Label;
                lblRSal = RG_Experience.Items[index].FindControl("lbl_Exp_RelSalary") as Label;
                lblRDate = RG_Experience.Items[index].FindControl("lbl_Exp_RelDate") as Label;
                lblDesc = RG_Experience.Items[index].FindControl("lbl_Exp_RelDesc") as Label;

                //_lbl_ID = lblID.Text;
                HF_ID.Value = lblID.Text;
                txt_Serial.Text = lblSerial.Text;
                txt_CompanyName.Text = lblCompany.Text;
                string[] strFormattommdd;
                strFormattommdd = lblJDate.Text.Split('/');
                if (Convert.ToInt32(strFormattommdd[1]) <= 12)
                {
                    lblJDate.Text = strFormattommdd[1] + "/" + strFormattommdd[0] + "/" + strFormattommdd[2];
                }
                txt_JoinDate.SelectedDate = Convert.ToDateTime(lblJDate.Text);
                txt_JoinSalary.Value = Convert.ToDouble(lblJSal.Text);
                txt_JoinDesc.Text = lblJdesc.Text;
                txt_ReasonRelieve.Text = lblRDesc.Text;
                txt_RelSalary.Value = Convert.ToDouble(lblRSal.Text);
                strFormattommdd = null;
                strFormattommdd = lblRDate.Text.Split('/');
                if (Convert.ToInt32(strFormattommdd[1]) <= 12)
                {
                    lblRDate.Text = strFormattommdd[1] + "/" + strFormattommdd[0] + "/" + strFormattommdd[2];
                }
                txt_RelieveDate.SelectedDate = Convert.ToDateTime(lblRDate.Text);
                txt_RelDesc.Text = lblDesc.Text;
                Mode = 3;
                btn_Exp_Add.Visible = false;

                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    btn_Exp_Correct.Visible = false;

                }

                else
                {
                    btn_Exp_Correct.Visible = true;
                }


            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void RG_Contact_ItemCommand(object source, GridCommandEventArgs e)
    {
        try
        {
            if (Mode == 0)
            {
                if (e.CommandName == "Edit_Rec")
                {
                    GridDataItem dtItem = (GridDataItem)e.Item;
                    int index = dtItem.ItemIndex;
                    Label lblSerial = new Label();
                    Label lblCompName = new Label();
                    Label lblConPerson = new Label();
                    Label lblConPhone = new Label();
                    Label lblConAddress = new Label();

                    lblSerial = RG_Contact.Items[index].FindControl("lbl_Con_Serial") as Label;
                    lblCompName = RG_Contact.Items[index].FindControl("lbl_ConName") as Label;
                    lblConPerson = RG_Contact.Items[index].FindControl("lbl_ConPerson") as Label;
                    lblConPhone = RG_Contact.Items[index].FindControl("lbl_ConPhoneNumber") as Label;
                    lblConAddress = RG_Contact.Items[index].FindControl("lbl_ConAddress") as Label;

                    txt_Serail_C.Text = lblSerial.Text;
                    txt_Company_C.Text = lblCompName.Text;
                    txt_ContactName.Text = lblConPerson.Text;
                    txt_PhoneNumber.Text = lblConPhone.Text;
                    txt_Address_C.Text = lblConAddress.Text;
                    Mode = 1;

                    btn_Contact_Add.Visible = false;
                    if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                    {

                        btn_Contact_Correct.Visible = false;
                    }

                    else
                    {
                        btn_Contact_Correct.Visible = true;
                    }

                }
            }
            else
            {
                GridDataItem dtItem = (GridDataItem)e.Item;
                int index = dtItem.ItemIndex;
                Label lblID = new Label();
                Label lblSerial = new Label();
                Label lblCompName = new Label();
                Label lblConPerson = new Label();
                Label lblConPhone = new Label();
                Label lblConAddress = new Label();

                lblSerial = RG_Contact.Items[index].FindControl("lbl_Con_Serial") as Label;
                lblCompName = RG_Contact.Items[index].FindControl("lbl_ConName") as Label;
                lblConPerson = RG_Contact.Items[index].FindControl("lbl_ConPerson") as Label;
                lblConPhone = RG_Contact.Items[index].FindControl("lbl_ConPhoneNumber") as Label;
                lblConAddress = RG_Contact.Items[index].FindControl("lbl_ConAddress") as Label;
                lblID = RG_Contact.Items[index].FindControl("lblID") as Label;

                //_lbl_ID = lblID.Text;
                HF_ID.Value = lblID.Text;
                txt_Serail_C.Text = lblSerial.Text;
                txt_Company_C.Text = lblCompName.Text;
                txt_ContactName.Text = lblConPerson.Text;
                txt_PhoneNumber.Text = lblConPhone.Text;
                txt_Address_C.Text = lblConAddress.Text;
                Mode = 2;


                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    btn_Contact_Correct.Visible = false;

                }

                else
                {
                    btn_Contact_Correct.Visible = true;
                }

                btn_Contact_Add.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void RG_Language_ItemCommand(object source, GridCommandEventArgs e)
    {
        try
        {
            if (Mode == 0)
            {
                if (e.CommandName == "Edit_Rec")
                {
                    GridDataItem dtItem = (GridDataItem)e.Item;
                    int index = dtItem.ItemIndex;
                    Label lbl_ID = new Label();
                    CheckBox chkRead = new CheckBox();
                    CheckBox chkWrite = new CheckBox();
                    CheckBox chkSpeak = new CheckBox();
                    CheckBox chkUnderstand = new CheckBox();
                    lbl_ID = RG_Language.Items[index].FindControl("lbl_ID") as Label;
                    chkRead = RG_Language.Items[index].FindControl("chk_Lang_Read") as CheckBox;
                    chkWrite = RG_Language.Items[index].FindControl("chk_Lang_Write") as CheckBox;
                    chkSpeak = RG_Language.Items[index].FindControl("chk_Lang_Speak") as CheckBox;
                    chkUnderstand = RG_Language.Items[index].FindControl("chk_Lang_Understand") as CheckBox;
                    ddl_Language.SelectedIndex = ddl_Language.FindItemIndexByValue(lbl_ID.Text);
                    if (chkRead.Checked)
                        chk_Read.Checked = true;
                    else
                        chk_Read.Checked = false;
                    if (chkSpeak.Checked)
                        chk_Speak.Checked = true;
                    else
                        chk_Speak.Checked = false;
                    if (chkUnderstand.Checked)
                        chk_Understand.Checked = true;
                    else
                        chk_Understand.Checked = false;
                    if (chkWrite.Checked)
                        chk_Write.Checked = true;
                    else
                        chk_Write.Checked = false;
                    //ddl_Language.Enabled = false;
                    Mode = 1;
                    btn_Lang_Add.Visible = false;

                    if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                    {

                        btn_Lang_Correct.Visible = false;
                    }

                    else
                    {
                        btn_Lang_Correct.Visible = true;
                    }


                }
            }
            else
            {
                if (e.CommandName == "Edit_Rec")
                {
                    GridDataItem dtItem = (GridDataItem)e.Item;
                    int index = dtItem.ItemIndex;
                    Label lblID = new Label();
                    Label lbl_ID = new Label();
                    CheckBox chkRead = new CheckBox();
                    CheckBox chkWrite = new CheckBox();
                    CheckBox chkSpeak = new CheckBox();
                    CheckBox chkUnderstand = new CheckBox();

                    lblID = RG_Language.Items[index].FindControl("lblID") as Label;
                    HF_ID.Value = lblID.Text;
                    lbl_ID = RG_Language.Items[index].FindControl("lbl_ID") as Label;
                    chkRead = RG_Language.Items[index].FindControl("chk_Lang_Read") as CheckBox;
                    chkWrite = RG_Language.Items[index].FindControl("chk_Lang_Write") as CheckBox;
                    chkSpeak = RG_Language.Items[index].FindControl("chk_Lang_Speak") as CheckBox;
                    chkUnderstand = RG_Language.Items[index].FindControl("chk_Lang_Understand") as CheckBox;
                    ddl_Language.SelectedIndex = ddl_Language.FindItemIndexByValue(lbl_ID.Text);
                    if (chkRead.Checked)
                        chk_Read.Checked = true;
                    else
                        chk_Read.Checked = false;
                    if (chkSpeak.Checked)
                        chk_Speak.Checked = true;
                    else
                        chk_Speak.Checked = false;
                    if (chkUnderstand.Checked)
                        chk_Understand.Checked = true;
                    else
                        chk_Understand.Checked = false;
                    if (chkWrite.Checked)
                        chk_Write.Checked = true;
                    else
                        chk_Write.Checked = false;
                    //ddl_Language.Enabled = false;
                    //_lbl_ID = lblID.Text;
                    HF_ID.Value = lblID.Text;

                    Mode = 3;
                    btn_Lang_Add.Visible = false;

                    if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                    {

                        btn_Lang_Correct.Visible = false;
                    }

                    else
                    {
                        btn_Lang_Correct.Visible = true;
                    }

                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void RG_Reference_ItemCommand(object source, GridCommandEventArgs e)
    {
        try
        {
            if (Mode == 0)
            {
                if (e.CommandName == "Edit_Rec")
                {
                    GridDataItem dtItem = (GridDataItem)e.Item;
                    int index = dtItem.ItemIndex;
                    Label lblID = new Label();
                    Label lblRelID = new Label();
                    CheckBox chkRef = new CheckBox();
                    lblID = RG_Reference.Items[index].FindControl("lbl_ID") as Label;
                    lblRelID = RG_Reference.Items[index].FindControl("lbl_RelID") as Label;
                    chkRef = RG_Reference.Items[index].FindControl("chkReferred") as CheckBox;

                    ddl_Employee.SelectedIndex = ddl_Employee.FindItemIndexByValue(lblID.Text);
                    ddl_Relationship.SelectedIndex = ddl_Relationship.FindItemIndexByValue(lblRelID.Text);
                    if (chkRef.Checked)
                        chk_Referred.Checked = true;
                    else
                        chk_Referred.Checked = false;
                    Mode = 1;
                    btn_Ref_Add.Visible = false;
                    if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                    {

                        btn_Ref_Correct.Visible = false;
                    }

                    else
                    {
                        btn_Ref_Correct.Visible = true;
                    }

                    //ddl_Employee.Enabled = false;
                }
            }
            else
            {
                if (e.CommandName == "Edit_Rec")
                {
                    GridDataItem dtItem = (GridDataItem)e.Item;
                    int index = dtItem.ItemIndex;
                    Label lbl_ID = new Label();
                    Label lblID = new Label();
                    Label lblRelID = new Label();
                    CheckBox chkRef = new CheckBox();
                    lbl_ID = RG_Reference.Items[index].FindControl("lblID") as Label;
                    lblID = RG_Reference.Items[index].FindControl("lbl_ID") as Label;
                    lblRelID = RG_Reference.Items[index].FindControl("lbl_RelID") as Label;
                    chkRef = RG_Reference.Items[index].FindControl("chkReferred") as CheckBox;
                    //_lbl_ID = lbl_ID.Text;
                    HF_ID.Value = lbl_ID.Text;
                    ddl_Employee.SelectedIndex = ddl_Employee.FindItemIndexByValue(lblID.Text);
                    ddl_Relationship.SelectedIndex = ddl_Relationship.FindItemIndexByValue(lblRelID.Text);

                    if (chkRef.Checked)
                        chk_Referred.Checked = true;
                    else
                        chk_Referred.Checked = false;
                    Mode = 3;
                    btn_Ref_Add.Visible = false;


                    if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                    {

                        btn_Ref_Correct.Visible = false;
                    }

                    else
                    {
                        btn_Ref_Correct.Visible = true;
                    }

                    //ddl_Employee.Enabled = false;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region GetDetails

    private void getDetails(string ID)
    {
        try
        {
            _obj_smhr_applicant = new SMHR_APPLICANT();
            _obj_smhr_applicant.OPERATION = operation.Select;
            _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(ID);
            _obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_Applicant(_obj_smhr_applicant);

            if (dt_Details.Rows.Count != 0)
            {
                txt_AppCode.Text = Convert.ToString(dt_Details.Rows[0]["APPLICANT_CODE"]);
                ddl_Title.SelectedValue = Convert.ToString(dt_Details.Rows[0]["APPLICANT_TITLE"]);
                txt_FirstName.Text = Convert.ToString(dt_Details.Rows[0]["APPLICANT_FIRSTNAME"]);
                txt_AppMiddleName.Text = Convert.ToString(dt_Details.Rows[0]["APPLICANT_MIDDLENAME"]);
                txt_AppLastName.Text = Convert.ToString(dt_Details.Rows[0]["APPLICANT_LASTNAME"]);
                txt_DOB.SelectedDate = Convert.ToDateTime(Convert.ToString(dt_Details.Rows[0]["APPLICANT_DOB"]));

                DateTime dt = Convert.ToDateTime(txt_DOB.SelectedDate.Value);
                DateTime BirthDate = Convert.ToDateTime(txt_DOB.SelectedDate.Value);
                dt = dt.AddYears(15);
                if (dt < DateTime.Now)
                {
                    int years = DateTime.Now.Year - BirthDate.Year;
                    // subtract another year if we're before the
                    // birth day in the current year
                    if (DateTime.Now.Month < BirthDate.Month ||
                        (DateTime.Now.Month == BirthDate.Month &&
                        DateTime.Now.Day < BirthDate.Day))
                        years--;
                    lblAge.Text = Convert.ToString(years + " yrs");
                }
                //txt_DOB.SelectedDate = DateTime.ParseExact(dt_Details.Rows[0]["APPLICANT_DOB"].ToString(), "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                ddl_Gender.SelectedIndex = ddl_Gender.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["APPLICANT_GENDER"]));
                if (dt_Details.Rows[0]["APPLICANT_BLOODGROUP"] != System.DBNull.Value)
                    ddl_BloodGroup.SelectedIndex = ddl_BloodGroup.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["APPLICANT_BLOODGROUP"]));
                ddl_Religion.SelectedIndex = ddl_Religion.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["APPLICANT_RELIGION_ID"]));
                ddl_Nationality.SelectedIndex = ddl_Nationality.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["APPLICANT_NATIONALITY_ID"]));
                ddl_MaritalStatus.SelectedIndex = ddl_MaritalStatus.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["APPLICANT_MARITALSTATUS"]));
                ddl_Status.SelectedIndex = ddl_Status.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["APPLICANT_STATUS"]));
                txt_Address.Text = Convert.ToString(dt_Details.Rows[0]["APPLICANT_ADDRESS"]);
                txt_Remarks.Text = Convert.ToString(dt_Details.Rows[0]["APPLICANT_REMARKS"]);
                rtxt_Email.Text = Convert.ToString(dt_Details.Rows[0]["APPLICANT_EMAIL"]);
                rmtxt_MobileNo.Text = Convert.ToString(dt_Details.Rows[0]["APPLICANT_MOBILE"]);

                if (dt_Details.Rows[0]["APPLICANT_RESUME"] != System.DBNull.Value && Convert.ToString(dt_Details.Rows[0]["APPLICANT_RESUME"]) != "")
                {
                    lnk_ViewResume.Visible = true;
                    lnk_ViewResume.OnClientClick = "javascript:window.open('../" + Convert.ToString(dt_Details.Rows[0]["APPLICANT_RESUME"]).TrimStart('~', '/') + "');return false;";
                    ViewState["fileLocation"] = dt_Details.Rows[0]["APPLICANT_RESUME"];
                }
                else
                {
                    lnk_ViewResume.Visible = false;
                }
            }

            LoadExperience();
            LoadLanguage();
            LoadQualification();
            LoadReference();
            LoadSkill();
            LoadContact();

            bool status = ValidateEmployee(ID);
            if (status == true)
            {
                pnlPersonal.Enabled = false;
                btn_Update.Enabled = false;
                //Personal.Enabled = false;
                Qualification.Enabled = false;
                Experience.Enabled = false;
                Reference.Enabled = false;
                Contact.Enabled = false;
                Language.Enabled = false;
                //Skills.Enabled = false;
                Upload.Enabled = false;
                FUpload.Enabled = false;
            }
            else
            {
                pnlPersonal.Enabled = true;
                btn_Update.Enabled = true;
                //Personal.Enabled = true;
                Qualification.Enabled = true;
                Experience.Enabled = true;
                Reference.Enabled = true;
                Contact.Enabled = true;
                Language.Enabled = true;
                //Skills.Enabled = true;
                Upload.Enabled = true;
                FUpload.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    private void getCode()
    {
        try
        {
            string code = string.Empty;
            string str = string.Empty;
            string Series = string.Empty;
            _obj_smhr_applicant = new SMHR_APPLICANT();
            _obj_smhr_applicant.OPERATION = operation.Validate;
            _obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_Applicant(_obj_smhr_applicant);
            if (dt_Details.Rows.Count != 0)
            {
                str = dt_Details.Rows[0][0].ToString().Trim();
                if (str.Length == 1)
                {
                    Series = "000";
                }
                else if (str.Length == 2)
                {
                    Series = "00";
                }
                else if (str.Length == 3)
                {
                    Series = "00";
                }
                else if (str.Length == 4)
                {
                    Series = "0";
                }

                _obj_smhr_globalconfig = new SMHR_GLOBALCONFIG();
                _obj_smhr_globalconfig.OPERATION = operation.Select;
                _obj_smhr_globalconfig.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt = BLL.get_ConfigDetails(_obj_smhr_globalconfig);
                txt_AppCode.Text = dt.Rows[0]["GLOBALCONFIG_APP_CODE"].ToString().Trim() + Convert.ToString(Series) + Convert.ToString(str);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region SaveDetails

    private void saveQualification()
    {
        try
        {
            dt_Qual = (DataTable)ViewState["dt_Qual"];
            foreach (DataRow row in dt_Qual.Rows)
            {
                bool status = false;
                _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                _obj_smhr_applicant.APPQFN_QUALIFICATION_ID = Convert.ToInt32(Convert.ToString(row[1]));
                _obj_smhr_applicant.APPQFN_INSTITUTE = Convert.ToString(row[3]);
                _obj_smhr_applicant.APPQFN_PASSEDYEAR = Convert.ToInt32(Convert.ToString(row[4]));
                if (!string.IsNullOrEmpty(row[5].ToString()))
                {
                    _obj_smhr_applicant.APPQFN_PERCENTAGE = Convert.ToInt32(Convert.ToString(row[5]));
                }
                _obj_smhr_applicant.APPQFN_GRADE = Convert.ToString(row[6]);
                _obj_smhr_applicant.APPQFN_CREATEDBY = 1;
                _obj_smhr_applicant.APPQFN_CREATEDDATE = DateTime.Now;
                _obj_smhr_applicant.OPERATION = operation.Insert;
                status = BLL.set_AppQualification(_obj_smhr_applicant);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void saveExperience()
    {
        try
        {
            bool status = false;
            dtExperience = (DataTable)ViewState["dtExperience"];
            foreach (DataRow row in dtExperience.Rows)
            {
                _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                _obj_smhr_applicant.APPEXP_SERIAL = Convert.ToInt32(Convert.ToString(row[1]));
                _obj_smhr_applicant.APPEXP_COMPANY = Convert.ToString(row[2]);
                _obj_smhr_applicant.APPEXP_JOINDATE = Convert.ToDateTime(Convert.ToString(row[3]));
                if (!string.IsNullOrEmpty(row[4].ToString()))
                {
                    _obj_smhr_applicant.APPEXP_JOINSAL = Convert.ToDouble(Convert.ToString(row[4]));
                }
                _obj_smhr_applicant.APPEXP_JOINDESC = Convert.ToString(row[5]);
                _obj_smhr_applicant.APPEXP_REASONREL = Convert.ToString(row[6]);
                _obj_smhr_applicant.APPEXP_RELDATE = Convert.ToDateTime(Convert.ToString(row[7]));
                _obj_smhr_applicant.APPEXP_RELSAL = Convert.ToDouble(Convert.ToString(row[8]));
                _obj_smhr_applicant.APPEXP_REASONDESC = Convert.ToString(row[9]);
                _obj_smhr_applicant.APPEXP_CREATEDBY = 1;
                _obj_smhr_applicant.APPEXP_CREATEDDATE = DateTime.Now;
                _obj_smhr_applicant.OPERATION = operation.Insert;
                status = BLL.set_ApplicantExperience(_obj_smhr_applicant);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void saveSkill()
    {
        try
        {
            dt_Skill = (DataTable)ViewState["dt_Skill"];
            bool status = false;
            foreach (DataRow row in dt_Skill.Rows)
            {
                _obj_smhr_applicant.OPERATION = operation.Insert;
                _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                _obj_smhr_applicant.APPSKL_SKILL_ID = Convert.ToInt32(Convert.ToString(row[1]));
                if (!string.IsNullOrEmpty(row[3].ToString()))
                {
                    _obj_smhr_applicant.APPSKL_LASTUSED = Convert.ToInt32(Convert.ToString(row[3]));
                }
                _obj_smhr_applicant.APPSKL_EXPERT = Convert.ToInt32(Convert.ToString(row[4]));
                _obj_smhr_applicant.APPSKL_CREATEDBY = 1;
                _obj_smhr_applicant.APPSKL_CREATEDDATE = DateTime.Now;
                status = BLL.set_ApplicantSkills(_obj_smhr_applicant);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void saveContact()
    {
        try
        {
            bool status = false;
            dt_Contact = (DataTable)ViewState["dt_Contact"];
            foreach (DataRow row in dt_Contact.Rows)
            {
                _obj_smhr_applicant.OPERATION = operation.Insert;
                _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                _obj_smhr_applicant.APPCONT_SERIAL = Convert.ToInt32(Convert.ToString(row[1]));
                _obj_smhr_applicant.APPCONT_COMPANY = Convert.ToString(row[2]);
                _obj_smhr_applicant.APPCONT_CONTACT = Convert.ToString(row[3]);
                _obj_smhr_applicant.APPCONT_PHONE = Convert.ToString(row[4]);
                _obj_smhr_applicant.APPCONT_ADDRESS = Convert.ToString(row[5]);
                _obj_smhr_applicant.APPCONT_CREATEDBY = 1;
                _obj_smhr_applicant.APPCONT_CREATEDDATE = DateTime.Now;
                status = BLL.set_ApplicantContact(_obj_smhr_applicant);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void saveReference()
    {
        try
        {
            bool status = false;
            dtReference = (DataTable)ViewState["dtReference"];
            foreach (DataRow row in dtReference.Rows)
            {
                _obj_smhr_applicant.OPERATION = operation.Insert;
                _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                _obj_smhr_applicant.APPREF_REFFERED_EMP_ID = Convert.ToInt32(Convert.ToString(row[1]));
                _obj_smhr_applicant.APPREF_RELATIONSHIP = Convert.ToInt32(Convert.ToString(row[3]));
                _obj_smhr_applicant.APPREF_REFERRED = Convert.ToBoolean(Convert.ToString(row[5]));
                _obj_smhr_applicant.APPREF_CREATEDBY = 1;
                _obj_smhr_applicant.APPREF_CREATEDDATE = DateTime.Now;
                status = BLL.set_ApplicantReference(_obj_smhr_applicant);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void saveLanguage()
    {
        try
        {
            bool status = false;
            dtLanguage = (DataTable)ViewState["dtLanguage"];
            foreach (DataRow row in dtLanguage.Rows)
            {
                _obj_smhr_applicant.OPERATION = operation.Insert;
                _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                _obj_smhr_applicant.APPLAN_LANGUAGE_ID = Convert.ToInt32(Convert.ToString(row[1]));
                _obj_smhr_applicant.APPLAN_READ = Convert.ToBoolean(Convert.ToString(row[3]));
                _obj_smhr_applicant.APPLAN_WRITE = Convert.ToBoolean(Convert.ToString(row[4]));
                _obj_smhr_applicant.APPLAN_SPEAK = Convert.ToBoolean(Convert.ToString(row[5]));
                _obj_smhr_applicant.APPLAN_UNDERSTAND = Convert.ToBoolean(Convert.ToString(row[6]));
                _obj_smhr_applicant.APPLAN_CREATEDBY = 1;
                _obj_smhr_applicant.APPLAN_CREATEDDATE = DateTime.Now;
                status = BLL.set_ApplicantLanguage(_obj_smhr_applicant);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region LoadDetails

    private void LoadQualification()
    {
        try
        {
            _obj_smhr_applicant.APPQFN_APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
            _obj_smhr_applicant.OPERATION = operation.Check;
            DataTable dt = BLL.get_ApplicantQualification(_obj_smhr_applicant);
            if (dt.Rows.Count != 0)
            {
                RG_Qualification.DataSource = dt;
                RG_Qualification.DataBind();
            }
        }
        catch (Exception ex)
        {

            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadExperience()
    {
        try
        {
            _obj_smhr_applicant.APPEXP_APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
            _obj_smhr_applicant.OPERATION = operation.Check;
            DataTable dt = BLL.get_ApplicantExperience(_obj_smhr_applicant);
            if (dt.Rows.Count != 0)
            {
                RG_Experience.DataSource = dt;
                RG_Experience.DataBind();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadSkill()
    {
        try
        {
            _obj_smhr_applicant.APPSKL_APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
            _obj_smhr_applicant.OPERATION = operation.Check;
            DataTable dt = BLL.get_ApplicantSkills(_obj_smhr_applicant);
            if (dt.Rows.Count != 0)
            {
                RG_Skills.DataSource = dt;
                RG_Skills.DataBind();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadLanguage()
    {
        try
        {
            _obj_smhr_applicant.APPLAN_APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
            _obj_smhr_applicant.OPERATION = operation.Check;
            DataTable dt = BLL.get_ApplicantLanguage(_obj_smhr_applicant);
            if (dt.Rows.Count != 0)
            {
                RG_Language.DataSource = dt;
                RG_Language.DataBind();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadReference()
    {
        try
        {
            _obj_smhr_applicant.APPREF_APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
            _obj_smhr_applicant.OPERATION = operation.Check;
            DataTable dt = BLL.get_ApplicantReference(_obj_smhr_applicant);
            if (dt.Rows.Count != 0)
            {
                RG_Reference.DataSource = dt;
                RG_Reference.DataBind();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadContact()
    {
        try
        {
            _obj_smhr_applicant.APPCONT_APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
            _obj_smhr_applicant.OPERATION = operation.Check;
            DataTable dt = BLL.get_ApplicantContact(_obj_smhr_applicant);
            if (dt.Rows.Count != 0)
            {
                RG_Contact.DataSource = dt;
                RG_Contact.DataBind();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadAppExpData()
    {
        try
        {
            _obj_smhr_applicant = new SMHR_APPLICANT();
            _obj_smhr_applicant.OPERATION = operation.Select;
            dt_Details = BLL.get_ApplicantExperience(_obj_smhr_applicant);
            RG_Experience.DataSource = dt_Details;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    private void checkdob()
    {
        try
        {
            DateTime dt = Convert.ToDateTime(txt_DOB.SelectedDate.Value);
            DateTime BirthDate = Convert.ToDateTime(txt_DOB.SelectedDate.Value);
            dt = dt.AddYears(15);
            if (dt < DateTime.Now)
            {
                int years = DateTime.Now.Year - BirthDate.Year;
                // subtract another year if we're before the
                // birth day in the current year
                if (DateTime.Now.Month < BirthDate.Month ||
                    (DateTime.Now.Month == BirthDate.Month &&
                    DateTime.Now.Day < BirthDate.Day))
                    years--;
                lblAge.Text = Convert.ToString(years + " yrs");
            }
            else
            {
                txt_DOB.SelectedDate = null;
                txt_DOB.Focus();
                BLL.ShowMessage(this, "Invalid Date of Birth");

                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #region SelectedChanged

    protected void txt_DOB_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
   {
        try
        {
            /*DateTime dt = Convert.ToDateTime(txt_DOB.SelectedDate.Value);
            DateTime BirthDate = Convert.ToDateTime(txt_DOB.SelectedDate.Value);
            dt = dt.AddYears(15);
            if (dt < DateTime.Now)
            {
                int years = DateTime.Now.Year - BirthDate.Year;
                // subtract another year if we're before the
                // birth day in the current year
                if (DateTime.Now.Month < BirthDate.Month ||
                    (DateTime.Now.Month == BirthDate.Month &&
                    DateTime.Now.Day < BirthDate.Day))
                    years--;
                lblAge.Text = Convert.ToString(years + " yrs");
            }
            else
            {
                txt_DOB.SelectedDate = null;
                txt_DOB.Focus();
                BLL.ShowMessage(this, "Invalid Date of Birth");
               
                return;
            }*/
            DateTime dt = Convert.ToDateTime(txt_DOB.SelectedDate.Value);
            if (dt < DateTime.Now)
            {
                checkdob();
            }
            else
            {
                BLL.ShowMessage(this, "Invalid Date of Birth");
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region Validations

    private bool ValidateEmployee(string ID)
    {
        try
        {
            _obj_smhr_applicant = new SMHR_APPLICANT();
            _obj_smhr_applicant.OPERATION = operation.Empty;
            _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(ID);
            DataTable dt = BLL.get_Applicant(_obj_smhr_applicant);
            if (dt.Rows.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {

            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return false;
    }

    public bool Check_Combo(RadGrid rdGrid, string lbl_validate, RadComboBox rcmb_Validate)
    {
        bool status = true;
        try
        {


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

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return status;
    }

    #endregion
}