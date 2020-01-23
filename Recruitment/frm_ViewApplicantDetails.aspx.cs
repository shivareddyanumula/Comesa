using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Data;
using Telerik.Web.UI;


public partial class Recruitment_frm_ViewApplicantDetails : System.Web.UI.Page
{
    #region References

    SMHR_MASTERS _obj_smhr_masters;
    SMHR_APPLICANT _obj_smhr_applicant;
    SMHR_EMPLOYEE _obj_smhr_employee;
    //SMHR_GLOBALCONFIG _obj_smhr_globalconfig;
    //SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems;
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
    //static string _lbl_App_ID = "";
    //static string _lbl_ID = "";

    #endregion

    #region Page_Events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                //BLL.ChangeDateFormat(Convert.ToString(Session["EMP_ID"]), txt_DOB, txt_JoinDate,
                //        txt_RelieveDate);
                if (Convert.ToString(Request.QueryString["APPID"]) == null)
                {
                    //btn_Update.Visible = false;
                    //btn_Exp_Correct.Visible = false;
                    //btn_Lang_Correct.Visible = false;
                    //btn_Qual_Correct.Visible = false;
                    //btn_Ref_Correct.Visible = false;
                    //btn_Skill_Correct.Visible = false;
                    //btn_Contact_Correct.Visible = false;
                    //RMP_Applicant_1.SelectedIndex = 0;
                    //RTS_Applicant.SelectedIndex = 0;
                    createColumns();
                    //lnk_ViewResume.Visible = false;
                    //LoadCombos();

                    Mode = 0;
                }
                else
                {
                    //RMP_Applicant_1.SelectedIndex = 0;
                    //RTS_Applicant.SelectedIndex = 0;
                    //LoadCombos();
                    Mode = 2;
                    //btn_Update.Visible = true;
                    //btn_Save.Visible = false;
                    //btn_Exp_Correct.Visible = false;
                    //btn_Lang_Correct.Visible = false;
                    //btn_Qual_Correct.Visible = false;
                    //btn_Ref_Correct.Visible = false;
                    //btn_Skill_Correct.Visible = false;
                    //btn_Contact_Correct.Visible = false;
                    //_lbl_App_ID = Convert.ToString(Request.QueryString["APPID"]);
                    /*added by anusha 25/05/2015*/
                    LoadCombos();
                    HF_APID.Value = Convert.ToString(Request.QueryString["APPID"]);
                    getDetails(HF_APID.Value);
                }
                int expSerial = getExpSerial();
                //txt_Serial.Text = Convert.ToString(expSerial);
                int conSerial = getContactSerial();
                //txt_Serail_C.Text = Convert.ToString(conSerial);

              
                    //code for security privilage
                    Session.Remove("WRITEFACILITY");

                    SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                    _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                    _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                    _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("APPLICANT");
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
                        //btn_Contact_Add.Visible = false;
                        //btn_Contact_Correct.Visible = false;
                        //btn_Exp_Add.Visible = false;
                        //btn_Exp_Correct.Visible = false;
                        //btn_Lang_Add.Visible = false;
                        //btn_Lang_Correct.Visible = false;
                        //btn_Qual_Add.Visible = false;
                        //btn_Qual_Correct.Visible = false;
                        //btn_Ref_Add.Visible = false;
                        //btn_Ref_Correct.Visible = false;
                        //btn_Save.Visible = false;
                        //btn_Skill_Add.Visible = false;
                        //btn_Skill_Correct.Visible = false;
                        //btn_Update.Visible = false;
                    }
                
                //BLL.gridDateFormat(Convert.ToString(Session["EMP_ID"]), RG_Experience, "APPEXP_JOINDATE", "APPEXP_RELDATE");
                //BLL.gridDateFormat(Convert.ToString(Session["EMP_ID"]), RG_Skills, "APPSKL_LASTUSED");
               
            }
            //Page.Validate();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ViewApplicantDetails", ex.StackTrace, DateTime.Now);
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

    /*added by anusha 25/05/2015*/

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

            //_obj_smhr_masters.MASTER_TYPE = "SKILL";
            //_obj_smhr_masters.OPERATION = operation.Select;
            //_obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);
            //rcb_Skill.DataSource = dt_Details;
            //rcb_Skill.DataTextField = "HR_MASTER_CODE";
            //rcb_Skill.DataValueField = "HR_MASTER_ID";
            //rcb_Skill.DataBind();
            //rcb_Skill.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

            //_obj_smhr_masters.MASTER_TYPE = "QUALIFICATION";
            //_obj_smhr_masters.OPERATION = operation.Select;
            //_obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);
            //ddl_Category.DataSource = dt_Details;
            //ddl_Category.DataTextField = "HR_MASTER_CODE";
            //ddl_Category.DataValueField = "HR_MASTER_ID";
            //ddl_Category.DataBind();
            //ddl_Category.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

            //_obj_smhr_masters.MASTER_TYPE = "LANGUAGE";
            //_obj_smhr_masters.OPERATION = operation.Select;
            //_obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);
            //ddl_Language.DataSource = dt_Details;
            //ddl_Language.DataTextField = "HR_MASTER_CODE";
            //ddl_Language.DataValueField = "HR_MASTER_ID";
            //ddl_Language.DataBind();
            //ddl_Language.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

            //_obj_smhr_masters.MASTER_TYPE = "RELATIONSHIP";
            //_obj_smhr_masters.OPERATION = operation.Select;
            //_obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);
            //ddl_Relationship.DataSource = dt_Details;
            //ddl_Relationship.DataTextField = "HR_MASTER_CODE";
            //ddl_Relationship.DataValueField = "HR_MASTER_ID";
            //ddl_Relationship.DataBind();
            //ddl_Relationship.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

            //_obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            //_obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //_obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            //DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            //ddl_BU.DataSource = dt_BUDetails;
            //ddl_BU.DataValueField = "BUSINESSUNIT_ID";
            //ddl_BU.DataTextField = "BUSINESSUNIT_CODE";
            //ddl_BU.DataBind();
            //ddl_BU.Items.Insert(0, new RadComboBoxItem("Select"));

            //_obj_smhr_employee = new SMHR_EMPLOYEE();
            //_obj_smhr_employee.OPERATION = operation.Select;
            //_obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //dt_Details = BLL.get_EmployeeRef(_obj_smhr_employee);
            //ddl_Employee.DataSource = dt_Details;
            //ddl_Employee.DataTextField = "EMP_NAME";
            //ddl_Employee.DataValueField = "EMP_ID";
            //ddl_Employee.DataBind();
            //ddl_Employee.Items.Insert(0, new RadComboBoxItem("Select"));

            //DataTable dt = BLL.get_Year(1);
            //rcb_YearLastUsed.DataSource = dt;
            //rcb_YearLastUsed.DataValueField = "SMHR_YEAR_ID";
            //rcb_YearLastUsed.DataTextField = "SMHR_YEAR";
            //rcb_YearLastUsed.DataBind();
            //rcb_YearLastUsed.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ViewApplicantDetails", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ViewApplicantDetails", ex.StackTrace, DateTime.Now);
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
                //txt_DOB.SelectedDate = DateTime.ParseExact(dt_Details.Rows[0]["APPLICANT_DOB"].ToString(), "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                ddl_Gender.SelectedIndex = ddl_Gender.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["APPLICANT_GENDER"]));
                if (dt_Details.Rows[0]["APPLICANT_BLOODGROUP"] != System.DBNull.Value)
                    ddl_BloodGroup.SelectedIndex = ddl_BloodGroup.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["APPLICANT_BLOODGROUP"]));
                ddl_Religion.SelectedIndex = ddl_Religion.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["APPLICANT_RELIGION_ID"]));
                ddl_Nationality.SelectedIndex= ddl_Nationality.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["APPLICANT_NATIONALITY_ID"]));
                ddl_MaritalStatus.SelectedIndex = ddl_MaritalStatus.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["APPLICANT_MARITALSTATUS"]));
                ddl_Status.SelectedIndex = ddl_Status.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["APPLICANT_STATUS"]));
                txt_Address.Text = Convert.ToString(dt_Details.Rows[0]["APPLICANT_ADDRESS"]);
                txt_Remarks.Text = Convert.ToString(dt_Details.Rows[0]["APPLICANT_REMARKS"]);
                rtxt_Email.Text = Convert.ToString(dt_Details.Rows[0]["APPLICANT_EMAIL"]);
                rmtxt_MobileNo.Text = Convert.ToString(dt_Details.Rows[0]["APPLICANT_MOBILE"]);

                //if (dt_Details.Rows[0]["APPLICANT_RESUME"] != System.DBNull.Value && Convert.ToString(dt_Details.Rows[0]["APPLICANT_RESUME"]) != "")
                //{
                //    lnk_ViewResume.Visible = true;
                //    lnk_ViewResume.OnClientClick = "javascript:window.open('../" + Convert.ToString(dt_Details.Rows[0]["APPLICANT_RESUME"]).TrimStart('~', '/') + "');return false;";
                //    ViewState["fileLocation"] = dt_Details.Rows[0]["APPLICANT_RESUME"];
                //}
                //else
                //{
                //    lnk_ViewResume.Visible = false;
                //}
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
                Personal.Enabled = false;
                Qualification.Enabled = false;
                Experience.Enabled = false;
                Reference.Enabled = false;
                Contact.Enabled = false;
                Language.Enabled = false;
                //Skills.Enabled = false;
                //Upload.Enabled = false;
                //FUpload.Enabled = false;
            }
            else
            {
                Personal.Enabled = true;
                Qualification.Enabled = true;
                Experience.Enabled = true;
                Reference.Enabled = true;
                Contact.Enabled = true;
                Language.Enabled = true;
                //Skills.Enabled = true;
                //Upload.Enabled = true;
                //FUpload.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ViewApplicantDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    #endregion

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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ViewApplicantDetails", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ViewApplicantDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return serialMax;
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
            RG_Qualification.DataSource = dt;
            RG_Qualification.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ViewApplicantDetails", ex.StackTrace, DateTime.Now);
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
            RG_Experience.DataSource = dt;
            RG_Experience.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ViewApplicantDetails", ex.StackTrace, DateTime.Now);
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
            RG_Skills.DataSource = dt;
            RG_Skills.DataBind();

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ViewApplicantDetails", ex.StackTrace, DateTime.Now);
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
            RG_Language.DataSource = dt;
            RG_Language.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ViewApplicantDetails", ex.StackTrace, DateTime.Now);
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
            RG_Reference.DataSource = dt;
            RG_Reference.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ViewApplicantDetails", ex.StackTrace, DateTime.Now);
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
            RG_Contact.DataSource = dt;
            RG_Contact.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ViewApplicantDetails", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ViewApplicantDetails", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ViewApplicantDetails", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ViewApplicantDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return status;
    }

    #endregion

    //#region ItemCommand

    //protected void RG_Qualification_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
    //{
    //    try
    //    {
    //        if (Mode == 0)
    //        {
    //            if (e.CommandName == "Edit_Rec")
    //            {
    //                GridDataItem dtItem = (GridDataItem)e.Item;
    //                int index = dtItem.ItemIndex;
    //                Label lblID = new Label();
    //                Label lblInstitute = new Label();
    //                Label lblYearPass = new Label();
    //                Label lblPercent = new Label();
    //                Label lblGrade = new Label();
    //                lblID = RG_Qualification.Items[index].FindControl("lbl_ID") as Label;
    //                lblInstitute = RG_Qualification.Items[index].FindControl("lbl_AppInstitute") as Label;
    //                lblYearPass = RG_Qualification.Items[index].FindControl("lbl_AppYearPass") as Label;
    //                lblPercent = RG_Qualification.Items[index].FindControl("lbl_AppPercentage") as Label;
    //                lblGrade = RG_Qualification.Items[index].FindControl("lbl_AppGrade") as Label;
    //                ddl_Category.SelectedIndex = ddl_Category.FindItemIndexByValue(lblID.Text);
    //                txt_Institute.Text = Convert.ToString(lblInstitute.Text);
    //                txt_YearofPass.Value = Convert.ToDouble(lblYearPass.Text);
    //                txt_Percentage.Value = Convert.ToDouble(lblPercent.Text);
    //                ddl_Grade.SelectedIndex = ddl_Grade.FindItemIndexByValue(lblGrade.Text);
    //                Mode = 1;
    //                //btn_Qual_Add.Visible = false;
    //                //if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
    //                //{
    //                //    btn_Qual_Correct.Visible = false;

    //                //}

    //                //else
    //                //{
    //                //    btn_Qual_Correct.Visible = true;
    //                //}

    //            }
    //        }
    //        else
    //        {
    //            if (e.CommandName == "Edit_Rec")
    //            {
    //                GridDataItem dtItem = (GridDataItem)e.Item;
    //                int index = dtItem.ItemIndex;
    //                Label lbl_ID = new Label();
    //                Label lblID = new Label();
    //                Label lblInstitute = new Label();
    //                Label lblYearPass = new Label();
    //                Label lblPercent = new Label();
    //                Label lblGrade = new Label();
    //                lbl_ID = RG_Qualification.Items[index].FindControl("lblID") as Label;
    //                lblID = RG_Qualification.Items[index].FindControl("lbl_ID") as Label;
    //                lblInstitute = RG_Qualification.Items[index].FindControl("lbl_AppInstitute") as Label;
    //                lblYearPass = RG_Qualification.Items[index].FindControl("lbl_AppYearPass") as Label;
    //                lblPercent = RG_Qualification.Items[index].FindControl("lbl_AppPercentage") as Label;
    //                lblGrade = RG_Qualification.Items[index].FindControl("lbl_AppGrade") as Label;
    //                ddl_Category.SelectedIndex = ddl_Category.FindItemIndexByValue(lblID.Text);
    //                //_lbl_ID = lbl_ID.Text;
    //                HF_ID.Value = lbl_ID.Text;
    //                txt_Institute.Text = Convert.ToString(lblInstitute.Text);
    //                txt_YearofPass.Value = Convert.ToDouble(lblYearPass.Text);
    //                if (lblPercent.Text != "0")
    //                {
    //                    txt_Percentage.Value = Convert.ToDouble(lblPercent.Text);
    //                }
    //                ddl_Grade.SelectedIndex = ddl_Grade.FindItemIndexByValue(lblGrade.Text);
    //                ddl_Category.Enabled = false;
    //                Mode = 3;
    //                //btn_Qual_Add.Visible = false;

    //                //if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
    //                //{
    //                //    btn_Qual_Correct.Visible = false;

    //                //}

    //                //else
    //                //{
    //                //    btn_Qual_Correct.Visible = true;
    //                //}

    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
    //    }
    //}

    //protected void RG_Skills_ItemCommand(object source, GridCommandEventArgs e)
    //{
    //    try
    //    {
    //        if (Mode == 0)
    //        {
    //            if (e.CommandName == "Edit_Rec")
    //            {
    //                GridDataItem dtItem = (GridDataItem)e.Item;
    //                int index = dtItem.ItemIndex;
    //                Label lblID = new Label();
    //                Label lblLastUsed = new Label();
    //                Label lbl_ExpertID = new Label();
    //                lblID = RG_Skills.Items[index].FindControl("lbl_Skill_ID") as Label;
    //                lblLastUsed = RG_Skills.Items[index].FindControl("lbl_Skill_LastUsed") as Label;
    //                lbl_ExpertID = RG_Skills.Items[index].FindControl("lbl_Skill_Exp_ID") as Label;
    //                rcb_Skill.SelectedIndex = rcb_Skill.FindItemIndexByValue(lblID.Text);
    //                //rcb_YearLastUsed.SelectedIndex = rcb_YearLastUsed.FindItemIndexByText(lblLastUsed.Text);
    //                rcb_ExpertLevel.SelectedValue = Convert.ToString((lbl_ExpertID.Text).Trim());
    //                //btn_Skill_Add.Visible = false;
    //                //rcb_Skill.Enabled = false;
    //                //if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
    //                //{
    //                //    btn_Skill_Correct.Visible = false;

    //                //}

    //                //else
    //                //{
    //                //    btn_Skill_Correct.Visible = true;
    //                //}

    //                Mode = 1;
    //            }
    //        }
    //        else
    //        {
    //            if (e.CommandName == "Edit_Rec")
    //            {
    //                GridDataItem dtItem = (GridDataItem)e.Item;
    //                int index = dtItem.ItemIndex;
    //                Label lbl_ID = new Label();
    //                Label lblID = new Label();
    //                Label lbl_ExpertID = new Label();
    //                Label lblLastUsed = new Label();
    //                lbl_ID = RG_Skills.Items[index].FindControl("lblID") as Label;
    //                lblID = RG_Skills.Items[index].FindControl("lbl_Skill_ID") as Label;
    //                lblLastUsed = RG_Skills.Items[index].FindControl("lbl_Skill_LastUsed") as Label;
    //                lbl_ExpertID = RG_Skills.Items[index].FindControl("lbl_Skill_Exp_ID") as Label;
    //                rcb_Skill.SelectedIndex = rcb_Skill.FindItemIndexByValue(lblID.Text);
    //                //rcb_YearLastUsed.SelectedIndex = rcb_YearLastUsed.FindItemIndexByText(lblLastUsed.Text);
    //                rcb_ExpertLevel.SelectedValue = Convert.ToString((lbl_ExpertID.Text).Trim());
    //                //_lbl_ID = lbl_ID.Text;
    //                HF_ID.Value = lbl_ID.Text;
    //                //btn_Skill_Add.Visible = false;
    //                //rcb_Skill.Enabled = false;
    //                //if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
    //                //{
    //                //    btn_Skill_Correct.Visible = false;

    //                //}

    //                //else
    //                //{
    //                //    btn_Skill_Correct.Visible = true;
    //                //}

    //                Mode = 3;
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
    //    }
    //}

    //protected void RG_Experience_ItemCommand(object source, GridCommandEventArgs e)
    //{
    //    try
    //    {
    //        if (Mode == 0)
    //        {
    //            if (e.CommandName == "Edit_Rec")
    //            {
    //                GridDataItem dtItem = (GridDataItem)e.Item;
    //                int index = dtItem.ItemIndex;

    //                Label lblSerial = new Label();
    //                Label lblCompany = new Label();
    //                Label lblJDate = new Label();
    //                Label lblJSal = new Label();
    //                Label lblJdesc = new Label();
    //                Label lblRDesc = new Label();
    //                Label lblRSal = new Label();
    //                Label lblRDate = new Label();
    //                Label lblDesc = new Label();

    //                lblSerial = RG_Experience.Items[index].FindControl("lbl_Exp_Serial") as Label;
    //                lblCompany = RG_Experience.Items[index].FindControl("lbl_Exp_CompName") as Label;
    //                lblJDate = RG_Experience.Items[index].FindControl("lbl_Exp_JoinDate") as Label;
    //                lblJSal = RG_Experience.Items[index].FindControl("lbl_Exp_JoinSal") as Label;
    //                lblJdesc = RG_Experience.Items[index].FindControl("lbl_Exp_JoinDesc") as Label;
    //                lblRDesc = RG_Experience.Items[index].FindControl("lbl_Exp_RelReason") as Label;
    //                lblRSal = RG_Experience.Items[index].FindControl("lbl_Exp_RelSalary") as Label;
    //                lblRDate = RG_Experience.Items[index].FindControl("lbl_Exp_RelDate") as Label;
    //                lblDesc = RG_Experience.Items[index].FindControl("lbl_Exp_RelDesc") as Label;

    //                txt_Serial.Text = lblSerial.Text;
    //                txt_CompanyName.Text = lblCompany.Text;
    //                txt_JoinDate.SelectedDate = Convert.ToDateTime(lblJDate.Text);
    //                txt_JoinSalary.Value = Convert.ToDouble(lblJSal.Text);
    //                txt_JoinDesc.Text = lblJdesc.Text;
    //                txt_ReasonRelieve.Text = lblRDesc.Text;
    //                txt_RelSalary.Value = Convert.ToDouble(lblRSal.Text);
    //                txt_RelieveDate.SelectedDate = Convert.ToDateTime(lblRDate.Text);
    //                txt_RelDesc.Text = lblDesc.Text;
    //                Mode = 1;
    //                //btn_Exp_Add.Visible = false;

    //                //if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
    //                //{
    //                //    btn_Exp_Correct.Visible = false;

    //                //}

    //                //else
    //                //{
    //                //    btn_Exp_Correct.Visible = true;
    //                //}


    //            }
    //        }
    //        else
    //        {
    //            GridDataItem dtItem = (GridDataItem)e.Item;
    //            int index = dtItem.ItemIndex;

    //            Label lblID = new Label();
    //            Label lblSerial = new Label();
    //            Label lblCompany = new Label();
    //            Label lblJDate = new Label();
    //            Label lblJSal = new Label();
    //            Label lblJdesc = new Label();
    //            Label lblRDesc = new Label();
    //            Label lblRSal = new Label();
    //            Label lblRDate = new Label();
    //            Label lblDesc = new Label();

    //            lblID = RG_Experience.Items[index].FindControl("lblID") as Label;
    //            lblSerial = RG_Experience.Items[index].FindControl("lbl_Exp_Serial") as Label;
    //            lblCompany = RG_Experience.Items[index].FindControl("lbl_Exp_CompName") as Label;
    //            lblJDate = RG_Experience.Items[index].FindControl("lbl_Exp_JoinDate") as Label;
    //            lblJSal = RG_Experience.Items[index].FindControl("lbl_Exp_JoinSal") as Label;
    //            lblJdesc = RG_Experience.Items[index].FindControl("lbl_Exp_JoinDesc") as Label;
    //            lblRDesc = RG_Experience.Items[index].FindControl("lbl_Exp_RelReason") as Label;
    //            lblRSal = RG_Experience.Items[index].FindControl("lbl_Exp_RelSalary") as Label;
    //            lblRDate = RG_Experience.Items[index].FindControl("lbl_Exp_RelDate") as Label;
    //            lblDesc = RG_Experience.Items[index].FindControl("lbl_Exp_RelDesc") as Label;

    //            //_lbl_ID = lblID.Text;
    //            HF_ID.Value = lblID.Text;
    //            txt_Serial.Text = lblSerial.Text;
    //            txt_CompanyName.Text = lblCompany.Text;
    //            string[] strFormattommdd;
    //            strFormattommdd = lblJDate.Text.Split('/');
    //            if (Convert.ToInt32(strFormattommdd[1]) <= 12)
    //            {
    //                lblJDate.Text = strFormattommdd[1] + "/" + strFormattommdd[0] + "/" + strFormattommdd[2];
    //            }
    //            txt_JoinDate.SelectedDate = Convert.ToDateTime(lblJDate.Text);
    //            txt_JoinSalary.Value = Convert.ToDouble(lblJSal.Text);
    //            txt_JoinDesc.Text = lblJdesc.Text;
    //            txt_ReasonRelieve.Text = lblRDesc.Text;
    //            txt_RelSalary.Value = Convert.ToDouble(lblRSal.Text);
    //            strFormattommdd = null;
    //            strFormattommdd = lblRDate.Text.Split('/');
    //            if (Convert.ToInt32(strFormattommdd[1]) <= 12)
    //            {
    //                lblRDate.Text = strFormattommdd[1] + "/" + strFormattommdd[0] + "/" + strFormattommdd[2];
    //            }
    //            txt_RelieveDate.SelectedDate = Convert.ToDateTime(lblRDate.Text);
    //            txt_RelDesc.Text = lblDesc.Text;
    //            Mode = 3;
    //            //btn_Exp_Add.Visible = false;

    //            //if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
    //            //{
    //            //    btn_Exp_Correct.Visible = false;

    //            //}

    //            //else
    //            //{
    //            //    btn_Exp_Correct.Visible = true;
    //            //}


    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
    //    }
    //}

    //protected void RG_Contact_ItemCommand(object source, GridCommandEventArgs e)
    //{
    //    try
    //    {
    //        if (Mode == 0)
    //        {
    //            if (e.CommandName == "Edit_Rec")
    //            {
    //                GridDataItem dtItem = (GridDataItem)e.Item;
    //                int index = dtItem.ItemIndex;
    //                Label lblSerial = new Label();
    //                Label lblCompName = new Label();
    //                Label lblConPerson = new Label();
    //                Label lblConPhone = new Label();
    //                Label lblConAddress = new Label();

    //                lblSerial = RG_Contact.Items[index].FindControl("lbl_Con_Serial") as Label;
    //                lblCompName = RG_Contact.Items[index].FindControl("lbl_ConName") as Label;
    //                lblConPerson = RG_Contact.Items[index].FindControl("lbl_ConPerson") as Label;
    //                lblConPhone = RG_Contact.Items[index].FindControl("lbl_ConPhoneNumber") as Label;
    //                lblConAddress = RG_Contact.Items[index].FindControl("lbl_ConAddress") as Label;

    //                txt_Serail_C.Text = lblSerial.Text;
    //                txt_Company_C.Text = lblCompName.Text;
    //                txt_ContactName.Text = lblConPerson.Text;
    //                txt_PhoneNumber.Text = lblConPhone.Text;
    //                txt_Address_C.Text = lblConAddress.Text;
    //                Mode = 1;

    //                //btn_Contact_Add.Visible = false;
    //                //if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
    //                //{

    //                //    btn_Contact_Correct.Visible = false;
    //                //}

    //                //else
    //                //{
    //                //    btn_Contact_Correct.Visible = true;
    //                //}

    //            }
    //        }
    //        else
    //        {
    //            GridDataItem dtItem = (GridDataItem)e.Item;
    //            int index = dtItem.ItemIndex;
    //            Label lblID = new Label();
    //            Label lblSerial = new Label();
    //            Label lblCompName = new Label();
    //            Label lblConPerson = new Label();
    //            Label lblConPhone = new Label();
    //            Label lblConAddress = new Label();

    //            lblSerial = RG_Contact.Items[index].FindControl("lbl_Con_Serial") as Label;
    //            lblCompName = RG_Contact.Items[index].FindControl("lbl_ConName") as Label;
    //            lblConPerson = RG_Contact.Items[index].FindControl("lbl_ConPerson") as Label;
    //            lblConPhone = RG_Contact.Items[index].FindControl("lbl_ConPhoneNumber") as Label;
    //            lblConAddress = RG_Contact.Items[index].FindControl("lbl_ConAddress") as Label;
    //            lblID = RG_Contact.Items[index].FindControl("lblID") as Label;

    //            //_lbl_ID = lblID.Text;
    //            HF_ID.Value = lblID.Text;
    //            txt_Serail_C.Text = lblSerial.Text;
    //            txt_Company_C.Text = lblCompName.Text;
    //            txt_ContactName.Text = lblConPerson.Text;
    //            txt_PhoneNumber.Text = lblConPhone.Text;
    //            txt_Address_C.Text = lblConAddress.Text;
    //            Mode = 2;


    //            //if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
    //            //{
    //            //    btn_Contact_Correct.Visible = false;

    //            //}

    //            //else
    //            //{
    //            //    btn_Contact_Correct.Visible = true;
    //            //}

    //            //btn_Contact_Add.Visible = false;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
    //    }
    //}

    //protected void RG_Language_ItemCommand(object source, GridCommandEventArgs e)
    //{
    //    try
    //    {
    //        if (Mode == 0)
    //        {
    //            if (e.CommandName == "Edit_Rec")
    //            {
    //                GridDataItem dtItem = (GridDataItem)e.Item;
    //                int index = dtItem.ItemIndex;
    //                Label lbl_ID = new Label();
    //                CheckBox chkRead = new CheckBox();
    //                CheckBox chkWrite = new CheckBox();
    //                CheckBox chkSpeak = new CheckBox();
    //                CheckBox chkUnderstand = new CheckBox();
    //                lbl_ID = RG_Language.Items[index].FindControl("lbl_ID") as Label;
    //                chkRead = RG_Language.Items[index].FindControl("chk_Lang_Read") as CheckBox;
    //                chkWrite = RG_Language.Items[index].FindControl("chk_Lang_Write") as CheckBox;
    //                chkSpeak = RG_Language.Items[index].FindControl("chk_Lang_Speak") as CheckBox;
    //                chkUnderstand = RG_Language.Items[index].FindControl("chk_Lang_Understand") as CheckBox;
    //                ddl_Language.SelectedIndex = ddl_Language.FindItemIndexByValue(lbl_ID.Text);
    //                if (chkRead.Checked)
    //                    chk_Read.Checked = true;
    //                else
    //                    chk_Read.Checked = false;
    //                if (chkSpeak.Checked)
    //                    chk_Speak.Checked = true;
    //                else
    //                    chk_Speak.Checked = false;
    //                if (chkUnderstand.Checked)
    //                    chk_Understand.Checked = true;
    //                else
    //                    chk_Understand.Checked = false;
    //                if (chkWrite.Checked)
    //                    chk_Write.Checked = true;
    //                else
    //                    chk_Write.Checked = false;
    //                //ddl_Language.Enabled = false;
    //                Mode = 1;
    //                //btn_Lang_Add.Visible = false;

    //                //if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
    //                //{

    //                //    btn_Lang_Correct.Visible = false;
    //                //}

    //                //else
    //                //{
    //                //    btn_Lang_Correct.Visible = true;
    //                //}


    //            }
    //        }
    //        else
    //        {
    //            if (e.CommandName == "Edit_Rec")
    //            {
    //                GridDataItem dtItem = (GridDataItem)e.Item;
    //                int index = dtItem.ItemIndex;
    //                Label lblID = new Label();
    //                Label lbl_ID = new Label();
    //                CheckBox chkRead = new CheckBox();
    //                CheckBox chkWrite = new CheckBox();
    //                CheckBox chkSpeak = new CheckBox();
    //                CheckBox chkUnderstand = new CheckBox();

    //                lblID = RG_Language.Items[index].FindControl("lblID") as Label;
    //                HF_ID.Value = lblID.Text;
    //                lbl_ID = RG_Language.Items[index].FindControl("lbl_ID") as Label;
    //                chkRead = RG_Language.Items[index].FindControl("chk_Lang_Read") as CheckBox;
    //                chkWrite = RG_Language.Items[index].FindControl("chk_Lang_Write") as CheckBox;
    //                chkSpeak = RG_Language.Items[index].FindControl("chk_Lang_Speak") as CheckBox;
    //                chkUnderstand = RG_Language.Items[index].FindControl("chk_Lang_Understand") as CheckBox;
    //                ddl_Language.SelectedIndex = ddl_Language.FindItemIndexByValue(lbl_ID.Text);
    //                if (chkRead.Checked)
    //                    chk_Read.Checked = true;
    //                else
    //                    chk_Read.Checked = false;
    //                if (chkSpeak.Checked)
    //                    chk_Speak.Checked = true;
    //                else
    //                    chk_Speak.Checked = false;
    //                if (chkUnderstand.Checked)
    //                    chk_Understand.Checked = true;
    //                else
    //                    chk_Understand.Checked = false;
    //                if (chkWrite.Checked)
    //                    chk_Write.Checked = true;
    //                else
    //                    chk_Write.Checked = false;
    //                //ddl_Language.Enabled = false;
    //                //_lbl_ID = lblID.Text;
    //                HF_ID.Value = lblID.Text;

    //                Mode = 3;
    //                //btn_Lang_Add.Visible = false;

    //                //if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
    //                //{

    //                //    btn_Lang_Correct.Visible = false;
    //                //}

    //                //else
    //                //{
    //                //    btn_Lang_Correct.Visible = true;
    //                //}

    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
    //    }
    //}

    //protected void RG_Reference_ItemCommand(object source, GridCommandEventArgs e)
    //{
    //    try
    //    {
    //        if (Mode == 0)
    //        {
    //            if (e.CommandName == "Edit_Rec")
    //            {
    //                GridDataItem dtItem = (GridDataItem)e.Item;
    //                int index = dtItem.ItemIndex;
    //                Label lblID = new Label();
    //                Label lblRelID = new Label();
    //                CheckBox chkRef = new CheckBox();
    //                lblID = RG_Reference.Items[index].FindControl("lbl_ID") as Label;
    //                lblRelID = RG_Reference.Items[index].FindControl("lbl_RelID") as Label;
    //                chkRef = RG_Reference.Items[index].FindControl("chkReferred") as CheckBox;

    //                ddl_Employee.SelectedIndex = ddl_Employee.FindItemIndexByValue(lblID.Text);
    //                ddl_Relationship.SelectedIndex = ddl_Relationship.FindItemIndexByValue(lblRelID.Text);
    //                if (chkRef.Checked)
    //                    chk_Referred.Checked = true;
    //                else
    //                    chk_Referred.Checked = false;
    //                Mode = 1;
    //                //btn_Ref_Add.Visible = false;
    //                //if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
    //                //{

    //                //    btn_Ref_Correct.Visible = false;
    //                //}

    //                //else
    //                //{
    //                //    btn_Ref_Correct.Visible = true;
    //                //}

    //                //ddl_Employee.Enabled = false;
    //            }
    //        }
    //        else
    //        {
    //            if (e.CommandName == "Edit_Rec")
    //            {
    //                GridDataItem dtItem = (GridDataItem)e.Item;
    //                int index = dtItem.ItemIndex;
    //                Label lbl_ID = new Label();
    //                Label lblID = new Label();
    //                Label lblRelID = new Label();
    //                CheckBox chkRef = new CheckBox();
    //                lbl_ID = RG_Reference.Items[index].FindControl("lblID") as Label;
    //                lblID = RG_Reference.Items[index].FindControl("lbl_ID") as Label;
    //                lblRelID = RG_Reference.Items[index].FindControl("lbl_RelID") as Label;
    //                chkRef = RG_Reference.Items[index].FindControl("chkReferred") as CheckBox;
    //                //_lbl_ID = lbl_ID.Text;
    //                HF_ID.Value = lbl_ID.Text;
    //                ddl_Employee.SelectedIndex = ddl_Employee.FindItemIndexByValue(lblID.Text);
    //                ddl_Relationship.SelectedIndex = ddl_Relationship.FindItemIndexByValue(lblRelID.Text);

    //                if (chkRef.Checked)
    //                    chk_Referred.Checked = true;
    //                else
    //                    chk_Referred.Checked = false;
    //                Mode = 3;
    //                //btn_Ref_Add.Visible = false;


    //                //if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
    //                //{

    //                //    btn_Ref_Correct.Visible = false;
    //                //}

    //                //else
    //                //{
    //                //    btn_Ref_Correct.Visible = true;
    //                //}

    //                //ddl_Employee.Enabled = false;
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantadd", ex.StackTrace, DateTime.Now);
    //    }
    //}

    //#endregion
}