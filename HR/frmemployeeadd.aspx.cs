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
using System.Text;
using Telerik.Web.UI;
using System.IO;
using System.Xml;
using Microsoft.VisualBasic;
using System.Net.Mail;
using System.Globalization;
using System.Threading;
using System.Collections.Generic;

public partial class HR_frmemployeeadd : System.Web.UI.Page
{
    static string strPath = "";
    // string strImagePath = "";
    SMHR_ALLOWANCE _obj_SMHR_ALLOWANCE = new SMHR_ALLOWANCE();

    #region References

    SMHR_BUSINESSUNIT _obj_smhr_businessunit;
    SMHR_APPLICANT _obj_smhr_applicant;
    SMHR_MASTERS _obj_smhr_masters;
    SMHR_LEAVESTRUCT _obj_smhr_leaveStruct;
    SMHR_POSITIONS _obj_smhr_positions;
    SMHR_SALARYSTRUCT _obj_smhr_salaryStruct;
    SMHR_EMPLOYEE _obj_smhr_employee = new SMHR_EMPLOYEE();// AS IT IS THROWING EXCEPTION WHILE GETSUPERVISOR() NOT INITIALISED
    SMHR_SHIFTDEFINITION _obj_smhr_shift;
    SMHR_EMPLOYEEWEEKLYOFF _obj_smhr_weeklyoff;
    SMHR_GLOBALCONFIG _obj_smhr_globalconfig;
    SMHR_CURRENCY _obj_smhr_Currency;
    SMHR_DEPARTMENT _obj_Department;
    SMHR_EMPOTHERDETAILS _obj_SMHR_EMPOTHERDETAILS;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_EMP_PHYSICALDETAILS _obj_SMHR_EMPPHYSICALDETAILS;
    SMHR_EMP_TDS _obj_smhr_EMP_TDS;
    SMHR_EMPOTHERDETAILS _obj_smhr_EmpOtherDetails;
    SMHR_LOCATION _obj_smhr_loc;
    SMHR_SUBDIVISION _obj_Smhr_SubDivision;
    SMHR_EMP_ONSITEDETAILS _obj_OnsiteDetails;
    SMHR_EMP_SHIFTDETAILS _obj_ShiftDetails;
    SMHR_EMPIMPORTANTDATES _obj_SMHR_EMPIMPORTANTDATES;
    Random _obj_rand = new Random();// for generating random numbers

    #endregion

    #region DataTables

    DataTable dt_Details;
    DataTable dt_Details1;
    DataTable dtExperience; //Datatable for Experience
    DataTable dt_Contact; // Datatable for Contact
    DataTable dtLanguage; // Datatable for Langugae
    DataTable dt_Skill; // Datatable for Skill
    DataTable dtReference; //Datatable for Reference
    DataTable dt_Qual; //Datatable for Qualification
    DataTable dtFamily; //Datatable for Family
    DataTable dtSwipe; //Datatable for Swipe
    DataTable dtOTRate = new DataTable(); //DataTable for OT rate
    DataTable dtPhysicalDetails = new DataTable(); //DataTable for Physical Details

    #endregion

    #region Variables

    static int Mode = 0;
    //static string _lbl_App_ID = "";
    static string _lbl_ID = "";
    static string strAppcode = "";
    StringBuilder AppCode = new StringBuilder();
    //static string _lbl_Emp_ID = "";
    static double minsal = 0.0;
    static double maxsal = 0.0;
    static double int_DOBS = 0;
    static double int_DOBE = 0;
    static int int_MIN = 18;
    static string int_DF = "";
    bool contracts = false;
    int Randomnumber = 0;
    static string strPass = "";
    static string strPass1 = "";
    static int empFamilyDetailID = 0;

    #endregion

    #region Load
    //RadComboBox rcmb_Period = new RadComboBox();
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {


            txt_endDate.Enabled = true;
            Page.Validate();
            if (!IsPostBack)
            {
                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Employee Details");//EMPLOYEE");
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
                    //RG_Employee.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
                txt_FDOB.MaxDate = DateTime.Now;
                BLL.ChangeDateFormat(Convert.ToString(Session["EMP_ID"]), txt_DOB, txt_DOC, txt_DOJ, txt_endDate, txt_ExpiryDate, txt_FDOB,
                            txt_IssueDate, txt_probDate, txt_JoinDate, txt_RelieveDate, txt_startDate, rdp_offDate, txt_IncrementDate, rdp_contract_end, rdp_contract_start);
                lbl_Rand.Text = Convert.ToString((_obj_rand.Next(0, 100)));
                txt_endDate.Enabled = true;
                //LoadGrades();
            }

            //string ST = "11-13-2012";
            //DateTime date = DateTime.ParseExact(ST, "MM/dd/yyyy", System.Globalization.CultureInfo.CurrentCulture);
            ////DateTime yourDateTime = DateTime.ParseExact("2009-05-08", "yyyyMMdd", null);
            //DateTime date = DateTime.ParseExact(ST, Convert.ToString(Session["DATE_FORMAT"]), System.Globalization.CultureInfo.InvariantCulture);

            rtxt_pwd.Attributes.Add("value", strPass);
            rtxt_passcode.Attributes.Add("value", strPass1);
            if (!Page.IsPostBack)
            {
                txt_BasicPay.Enabled = false;
                //VariablePay.Visible = false;

                if (Convert.ToString(Request.QueryString["EID"]) == null)
                {
                    tr_AnnualSalary.Visible = false;
                    LoadAnnual();
                    btn_Update.Visible = false;
                    //Picture.Enabled = false;
                    RTS_Employee.Tabs.FindTabByText("Picture").Enabled = false;
                    //RTS_Employee.Tabs.FindTabByText("OnSite Details").Enabled = false;
                    //RTS_Employee.Tabs.FindTabByText("Shift Details").Enabled = false;

                    btn_Save.Visible = true;
                    ddl_Language.Enabled = true;
                    //Picture.Visible = false;
                    clearConFields();
                    clearExpFields();
                    clearFamilyFields();
                    clearLangFields();
                    clearOTFields();
                    clearQualFields();
                    clearRefFields();
                    clearSkillFields();
                    clearSwpFields();
                    clearPersonal();
                    RTS_Employee.SelectedIndex = 0;
                    createColumns();
                    ddl_Applicant.Enabled = true;
                    btn_Con_Correct.Visible = false;
                    btn_Exp_Correct.Visible = false;
                    btn_swp_Correct.Visible = false;
                    btn_Qual_Correct.Visible = false;
                    btn_Ref_Correct.Visible = false;
                    btn_Skill_Correct.Visible = false;
                    btn_Fam_Correct.Visible = false;
                    btn_OT_Correct.Visible = false;
                    LoadCombos();
                    // LoadPeriod();
                    LoadUserGroups();
                    rtxt_pwd.Text = "123456aA";
                    rtxt_passcode.Text = "123456aA";
                    strPass = "123456aA";
                    strPass1 = "123456aA";
                    rtxt_pwd.TextMode = TextBoxMode.Password;
                    rtxt_passcode.TextMode = TextBoxMode.Password;
                    rtxt_pwd.Attributes.Add("value", strPass);
                    rtxt_passcode.Attributes.Add("value", strPass1);
                    //  LoadApplicant();
                    Mode = 0;
                    if (Convert.ToInt32(Session["WRITEFACILITY"]) == 1)
                        btn_Save.Visible = true;
                    else
                        btn_Save.Visible = false;
                    btn_Update.Visible = false;
                    txt_startDate.Enabled = false;
                    txt_endDate.Enabled = true;  //  18.1.2016  for enddate enable
                    //ddl_EmpStatus_SelectedIndexChanged(null, null);
                    ddl_Employee_Status.SelectedIndex = 1;
                    ddl_Employee_Status.Enabled = false;
                    RMP_EmployeePage.SelectedIndex = 0;
                    btn_Physical_Update.Visible = false;
                    rtxt_empcode.Enabled = true;

                    chk_IsManual.Enabled = true;
                    //EMployee Tds
                    //LoadBusinessUnit_Tds();
                    //LoadGrid_Tds();

                    string str = Convert.ToString(ddl_BusinessUnit.SelectedValue);

                    _obj_SMHR_LoginInfo.OPERATION = operation.Select;
                    _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dt_BusinessUnit = BLL.get_Sup_BusinessUnit(_obj_SMHR_LoginInfo);
                    if (dt_BusinessUnit.Rows.Count != 0)
                    {
                        ddl_Sup_BusinessUnit.DataSource = dt_BusinessUnit;
                        ddl_Sup_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
                        ddl_Sup_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
                        ddl_Sup_BusinessUnit.DataBind();
                        ddl_Sup_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                    }
                    LoadGrades();
                    LoadPeriod();
                }
                else
                {
                    // LoadBusinessUnit_Tds();
                    //Picture.Enabled = true;
                    tr_AnnualSalary.Visible = false;
                    LoadAnnual();

                    //rntxt_Annual.Value = 0.0;
                    LoadCombos();
                    Mode = 2;
                    //_lbl_Emp_ID = Convert.ToString(Request.QueryString["EID"]);
                    HF_EMPID.Value = Convert.ToString(Request.QueryString["EID"]);
                    LoadApplicant();
                    //checkLocal();
                    btn_Update.Visible = true;
                    rtxt_empcode.Enabled = true;
                    getDetails(Convert.ToString(Request.QueryString["EID"]));
                    //31.5.2016
                    /*if (ddl_EmpStatus.SelectedItem.Text == "Contract" || string.Compare(ddl_EmpStatus.SelectedItem.Text.ToUpper(), "Members of Parliament", true) == 0 || string.Compare(ddl_EmpStatus.SelectedItem.Text.ToUpper(), "Members of Senate", true) == 0)
                    {
                        contract.Visible = true;
                    }
                    else
                    {
                        contract.Visible = false;
                    }*/
                    ddl_Applicant.Enabled = false;

                    btn_Save.Visible = false;

                    btn_Con_Correct.Visible = false;
                    btn_Exp_Correct.Visible = false;
                    btn_Lang_Correct.Visible = false;
                    btn_Qual_Correct.Visible = false;
                    btn_Ref_Correct.Visible = false;
                    btn_Skill_Correct.Visible = false;
                    btn_Fam_Correct.Visible = false;
                    btn_swp_Correct.Visible = false;
                    btn_Fam_Correct.Visible = false;
                    btn_OT_Correct.Visible = false;
                    btn_Fam_Add.Visible = true;
                    btn_Con_Add.Visible = true;
                    btn_Exp_Add.Visible = true;
                    btn_Lang_Add.Visible = true;
                    btn_Qual_Add.Visible = true;
                    btn_Ref_Add.Visible = true;
                    btn_Skill_Add.Visible = true;
                    btn_swp_Add.Visible = true;
                    btn_Fam_Add.Visible = true;
                    btn_OT_Add.Visible = true;
                    btn_Physical_Save.Visible = false;

                    chk_IsManual.Enabled = false;

                    if (ddl_Supervisor.SelectedIndex != 0)
                    {
                        txt_startDate.Enabled = true;
                        txt_endDate.Enabled = true;
                    }
                    else
                    {
                        txt_startDate.Enabled = false;
                        txt_endDate.Enabled = true;  //18.1.2016 for enddate 
                    }

                    RMP_EmployeePage.SelectedIndex = 0;
                    //ddl_EmpStatus_SelectedIndexChanged(null, null);
                    ddl_Employee_Status.SelectedIndex = 1;
                    ddl_Employee_Status.Enabled = false;

                    if (Request.QueryString["Status"] == "R")
                    {
                        ddl_EmpStatus.Enabled = true;
                    }
                    else
                    {
                        ddl_EmpStatus.Enabled = false;
                    }

                    if (ddl_EmpStatus.SelectedItem.Text.Trim() == "Permanent")
                    {
                        ddl_EmpStatus.Enabled = false;
                    }
                    else
                    {
                        //31.5.2016
                        /*if (ddl_EmpStatus.SelectedItem.Text.Trim() == "Contract" || string.Compare(ddl_EmpStatus.SelectedItem.Text.ToUpper(), "Members of Parliament", true) == 0 || string.Compare(ddl_EmpStatus.SelectedItem.Text.ToUpper(), "Members of Senate", true) == 0)
                        {
                            contract.Visible = true;
                        }
                        else
                        {
                            contract.Visible = false;
                        }*/
                        //ddl_EmpStatus.Enabled = true;
                    }



                    ////Modified




                    ////gets Supervisor for employee
                    //_obj_smhr_employee.OPERATION = operation.Select1;
                    //_obj_smhr_employee.EMP_ID = Convert.ToInt32(Request.QueryString["EID"]);
                    //DataTable dt_DefaultSupervisor = BLL.get_DefaultSupervisor(_obj_smhr_employee);
                    //if (dt_DefaultSupervisor.Rows.Count != 0)
                    //{
                    //    //gets business unit for supervisor
                    //    string str_Supervisor = Convert.ToString(dt_DefaultSupervisor.Rows[0]["EMP_REPORTINGEMPLOYEE"]);
                    //    _obj_smhr_employee.OPERATION = operation.Validate;
                    //    _obj_smhr_employee.EMP_ID = Convert.ToInt32(str_Supervisor);
                    //    DataTable dt_SupBusinessUnit = BLL.get_DefaultSupervisor(_obj_smhr_employee);

                    //    //gets employees related to above businessunit
                    //    string str_BusinessUnit = Convert.ToString(dt_SupBusinessUnit.Rows[0]["BUSINESSUNIT_ID"]);
                    //    _obj_smhr_employee.OPERATION = operation.Check1;
                    //    _obj_smhr_employee.EMP_BUSINESSUNIT_ID = Convert.ToInt32(str_BusinessUnit);
                    //    DataTable dt_Employee = BLL.get_DefaultSupervisor(_obj_smhr_employee);
                    //    if (dt_Employee.Rows.Count != 0)
                    //    {
                    //        ddl_Supervisor.DataSource = dt_Employee;
                    //        ddl_Supervisor.DataTextField = "EMP_NAME";
                    //        ddl_Supervisor.DataValueField = "EMP_ID";
                    //        ddl_Supervisor.DataBind();
                    //        ddl_Supervisor.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                    //        ddl_Supervisor.SelectedItem.Text = Convert.ToString(dt_DefaultSupervisor.Rows[0]["SUPERVISOR_NAME"]);
                    //        //ddl_Supervisor.SelectedIndex = ddl_Supervisor.FindItemIndexByValue(Convert.ToString(dt_DefaultSupervisor.Rows[0]["SUPERVISOR_NAME"]));
                    //    }


                    //    //gets all business units
                    //    //_obj_SMHR_LoginInfo.OPERATION = operation.Select;
                    //    _obj_SMHR_LoginInfo.OPERATION = operation.Validate1;
                    //    _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    //    _obj_SMHR_LoginInfo.BUID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
                    //    DataTable dt_BusinessUnit = BLL.get_Sup_BusinessUnit(_obj_SMHR_LoginInfo);
                    //    if (dt_BusinessUnit.Rows.Count != 0)
                    //    {
                    //        ddl_Sup_BusinessUnit.DataSource = dt_BusinessUnit;
                    //        ddl_Sup_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
                    //        ddl_Sup_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
                    //        ddl_Sup_BusinessUnit.DataBind();
                    //        ddl_Sup_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                    //        ddl_Sup_BusinessUnit.SelectedItem.Text = Convert.ToString(dt_SupBusinessUnit.Rows[0]["BUSINESSUNIT_CODE"]);

                    //    }
                    //}
                    //else
                    //{
                    //    _obj_SMHR_LoginInfo.OPERATION = operation.Validate1;
                    //    _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    //    _obj_SMHR_LoginInfo.BUID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
                    //    DataTable dt_BusinessUnit = BLL.get_Sup_BusinessUnit(_obj_SMHR_LoginInfo);
                    //    if (dt_BusinessUnit.Rows.Count != 0)
                    //    {
                    //        ddl_Sup_BusinessUnit.DataSource = dt_BusinessUnit;
                    //        ddl_Sup_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
                    //        ddl_Sup_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
                    //        ddl_Sup_BusinessUnit.DataBind();
                    //        ddl_Sup_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                    //        //ddl_Sup_BusinessUnit.SelectedItem.Text = Convert.ToString(dt_SupBusinessUnit.Rows[0]["BUSINESSUNIT_DESC"]);

                    //    }
                    //}


                    //if (!chk_Isvariablepay.Checked)
                    //{
                    //    rntxt_Count.Text = "";
                    //    rntxt_Amount.Text = "";
                    //}
                }

                DataTable dt = BLL.get_1259735();
                if (dt.Rows.Count != 0)
                {
                    string strVal = BLL.PasswordDecrypt(Convert.ToString(dt.Rows[0][1]));
                    _obj_smhr_employee = new SMHR_EMPLOYEE();
                    //_obj_smhr_employee.OPERATION = operation.Select;
                    _obj_smhr_employee.OPERATION = operation.EmployeeCount;
                    _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtDetails = BLL.get_Employee(_obj_smhr_employee);
                    if (dtDetails.Rows.Count != 0)
                    {
                        if (Convert.ToString(dtDetails.Rows[0][0]) != "6rAoGC7EbQxz7FSee5gSCKsSCWJkUsWCvt4EVz99O0s=")
                        {
                            if (dtDetails.Rows.Count != Convert.ToInt32(strVal))
                            {
                                return;
                            }
                            else
                            {
                                BLL.ShowMessage(this, "You have only limited no of users License. You cannot create more employees");
                                RTS_Employee.Enabled = false;
                                return;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                if (Convert.ToString(Session["Rehire"]) != string.Empty)
                {
                    txt_DOJ.Enabled = true;
                    ViewState["Rehire"] = true;
                    if (Session["RelDate"] != null)
                    {
                        txt_DOJ.MinDate = Convert.ToDateTime(Session["RelDate"]);
                    }
                    Session["RelDate"] = null;
                    ddl_BusinessUnit.Enabled = true;
                    ddl_LeaveStructure.Enabled = true;
                    ddl_SalaryStructure.Enabled = true;
                    ddl_EmpStatus.Enabled = true;
                    ddl_Jobs.Enabled = true;
                    ddl_Designation.Enabled = true;
                    ddl_Slabs.Enabled = true;
                    ddl_Grade.Enabled = true;
                    Session["Rehire"] = null;
                    Session.Remove("RelDate");
                    Session.Remove("Rehire");
                    //cnfrmbtnextn.Enabled = true;
                    btn_Update.OnClientClick = "if (!confirm('Are you sure..?It updates with the same data.')) return false";
                    //btn_Update.Attributes.Add("onclick", "return Rehire();");
                    //btn_Update.OnClientClick += new EventHandler(btn_Update_OnClientClick);
                    //btn_Update.Attributes.Add("OnClientClick", "return Rehire();");
                }
                else
                {
                    ViewState["Rehire"] = false;
                    //cnfrmbtnextn.Enabled = false;
                    //btn_Update.Attributes.Add("onclick", "return Rehire();");
                    //btn_Update.OnClientClick += new EventHandler(btn_Update_OnClientClick);
                    //btn_Update.Attributes.Add("OnClientClick", "return Rehire();");
                }

                //BLL.gridDateFormat(Convert.ToString(Session["EMP_ID"]), RG_Experience, "APPEXP_JOINDATE", "APPEXP_RELDATE");
                //BLL.gridDateFormat(Convert.ToString(Session["EMP_ID"]), RG_Skills, "APPSKL_LASTUSED");

                //if (Convert.ToString(Session["Rehire"]) != string.Empty)
                //{
                //    txt_DOJ.Enabled = true;
                //    ViewState["Rehire"] = true;
                //    if (Session["RelDate"] != null)
                //    {
                //        txt_DOJ.MinDate = Convert.ToDateTime(Session["RelDate"]);
                //    }
                //    Session["RelDate"] = null;

                //    ddl_BusinessUnit.Enabled = true;
                //    ddl_LeaveStructure.Enabled = true;
                //    ddl_SalaryStructure.Enabled = true;
                //    ddl_EmpStatus.Enabled = true;
                //    Session["Rehire"] = null;
                //    btn_Update.Attributes.Add("OnClientClick", "return Rehire();");
                //}
                //else
                //{
                //    ViewState["Rehire"] = false;
                //}

                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("EMPLOYEE");
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
                    btn_Con_Add.Visible = false;
                    btn_Con_Correct.Visible = false;
                    btn_Exp_Add.Visible = false;
                    btn_Exp_Correct.Visible = false;
                    btn_Fam_Add.Visible = false;
                    btn_Fam_Correct.Visible = false;
                    btn_Lang_Add.Visible = false;
                    btn_Lang_Correct.Visible = false;
                    btn_OT_Add.Visible = false;
                    btn_OT_Correct.Visible = false;
                    btn_Physical_Save.Visible = false;
                    btn_Physical_Update.Visible = false;
                    btn_Qual_Add.Visible = false;
                    btn_Qual_Correct.Visible = false;
                    btn_Ref_Add.Visible = false;
                    btn_Ref_Correct.Visible = false;
                    btn_Save.Visible = false;
                    btn_Shift_refresh.Visible = false;
                    btn_Skill_Add.Visible = false;
                    btn_Skill_Correct.Visible = false;
                    btn_swp_Add.Visible = false;
                    btn_swp_Correct.Visible = false;
                    btn_Update.Visible = false;
                }
                LoadGrades();
            }
            #region getting the control which caused post-back
            //string ctrlname = string.Empty;
            //Control c = GetPostBackControl(this.Page);
            //if (c != null)
            //{
            //    ctrlname = c.ID;
            //}
            //if ((ctrlname.ToUpper() == "BTN_SAVE"))
            //{
            //    btn_Save.Enabled = false;
            //    btn_Save.Text = "Saving...";
            //}
            //else if ((ctrlname.ToUpper() == "BTN_UPDATE"))
            //{
            //    btn_Cancel.Focus();
            //    btn_Update.Enabled = false;
            //    btn_Update.Text = "Updating...";
            //}
            //else
            //{

            //}
            #endregion
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region method for getting the control which caused post-back
    //public static Control GetPostBackControl(Page page)
    //{
    //    Control control = null;

    //    string ctrlname = page.Request.Params.Get("__EVENTTARGET");
    //    if (ctrlname != null && ctrlname != string.Empty)
    //    {
    //        control = page.FindControl(ctrlname);
    //    }
    //    else
    //    {
    //        foreach (string ctl in page.Request.Form)
    //        {
    //            Control c = page.FindControl(ctl);
    //            if (c is System.Web.UI.WebControls.Button)
    //            {
    //                control = c;
    //                break;
    //            }
    //        }
    //    }
    //    return control;
    //}
    #endregion

    #region LoadMethods

    public void LoadStructure()
    {
        try
        {
            ddl_SalaryStructure.Items.Clear();
            _obj_smhr_salaryStruct = new SMHR_SALARYSTRUCT();
            _obj_smhr_salaryStruct.ISDELETED = false;
            _obj_smhr_salaryStruct.OPERATION = operation.Select;
            _obj_smhr_salaryStruct.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_SalaryHeaderDetails(_obj_smhr_salaryStruct);
            ddl_SalaryStructure.DataSource = dt_Details;
            ddl_SalaryStructure.DataTextField = "SALARYSTRUCT_CODE";
            ddl_SalaryStructure.DataValueField = "SALARYSTRUCT_ID";
            ddl_SalaryStructure.DataBind();
            ddl_SalaryStructure.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            //Leave Structure
            ddl_LeaveStructure.Items.Clear();
            _obj_smhr_leaveStruct = new SMHR_LEAVESTRUCT();
            _obj_smhr_leaveStruct.OPERATION = operation.Select;
            _obj_smhr_leaveStruct.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_LeaveStructHeaderDetails(_obj_smhr_leaveStruct);
            ddl_LeaveStructure.DataSource = dt_Details;
            ddl_LeaveStructure.DataTextField = "LEAVESTRUCT_CODE";
            ddl_LeaveStructure.DataValueField = "LEAVESTRUCT_ID";
            ddl_LeaveStructure.DataBind();
            ddl_LeaveStructure.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

            ////PERIOD
            //rcmb_Period.Items.Clear();
            //_obj_smhr_employee = new SMHR_PERIOD();
            //_obj_smhr_employee.OPERATION = operation.PERIOD;
            //_obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //_obj_smhr_employee.period
            //dt_Details = BLL.get_Period(_obj_smhr_employee);
            //rcmb_Period.DataSource = dt_Details;
            //rcmb_Period.DataTextField = "PERIOD_NAME";
            //rcmb_Period.DataValueField = "PERIOD_ID";
            //rcmb_Period.DataBind();
            //rcmb_Period.Items.Insert(0,new Telerik.Web.UI.RadComboBoxItem("Select"));
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    private void LoadCombos()
    {
        try
        {
            //Business Unit
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            ddl_BusinessUnit.Items.Clear();
            ddl_BusinessUnit.DataSource = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            ddl_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            ddl_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            ddl_BusinessUnit.DataBind();
            ddl_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            ////Pay Currency
            //ddl_Currency.Items.Clear();
            //_obj_smhr_Currency = new SMHR_CURRENCY();
            //_obj_smhr_Currency.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //dt_Details = BLL.get_Currency(_obj_smhr_Currency);
            //ddl_Currency.DataSource = dt_Details;
            //ddl_Currency.DataTextField = "CURR_CODE";
            //ddl_Currency.DataValueField = "CURR_ID";
            //ddl_Currency.DataBind();
            //ddl_Currency.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            //Religion
            ddl_Religion.Items.Clear();
            _obj_smhr_masters = new SMHR_MASTERS();
            _obj_smhr_masters.MASTER_TYPE = "RELIGION";
            _obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_masters.OPERATION = operation.Select;
            dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);
            ddl_Religion.DataSource = dt_Details;
            ddl_Religion.DataTextField = "HR_MASTER_CODE";
            ddl_Religion.DataValueField = "HR_MASTER_ID";
            ddl_Religion.DataBind();
            ddl_Religion.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            //Nationality
            ddl_Nationality.Items.Clear();
            _obj_smhr_masters.MASTER_TYPE = "NATIONALITY";
            _obj_smhr_masters.OPERATION = operation.Select;
            _obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);
            ddl_Nationality.DataSource = dt_Details;
            ddl_Nationality.DataTextField = "HR_MASTER_CODE";
            ddl_Nationality.DataValueField = "HR_MASTER_ID";
            ddl_Nationality.DataBind();
            ddl_Nationality.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            //Tribe
            ddl_Tribe.Items.Clear();
            _obj_smhr_masters.MASTER_TYPE = "TRIBE";
            _obj_smhr_masters.OPERATION = operation.Select;
            _obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);
            ddl_Tribe.DataSource = dt_Details;
            ddl_Tribe.DataTextField = "HR_MASTER_CODE";
            ddl_Tribe.DataValueField = "HR_MASTER_ID";
            ddl_Tribe.DataBind();
            ddl_Tribe.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            //Employee Type
            //ddl_EmpStatus.Items.Clear();
            //_obj_smhr_masters.MASTER_TYPE = "EMPLOYEETYPE";
            //_obj_smhr_masters.OPERATION = operation.Select;
            //_obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);
            //ddl_EmpStatus.DataSource = dt_Details;
            //ddl_EmpStatus.DataTextField = "HR_MASTER_CODE";
            //ddl_EmpStatus.DataValueField = "HR_MASTER_ID";
            //ddl_EmpStatus.DataBind();
            //ddl_EmpStatus.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            //Skill

            getJobs();
            getPosition();
            //Get Grades
            if (ddl_Designation.SelectedValue != string.Empty)
            {
                //ddl_Grade.Items.Clear();
                SMHR_POSITIONS _obj_smhr_positions = new SMHR_POSITIONS();
                _obj_smhr_positions.OPERATION = operation.POSITIONSGRADE;
                _obj_smhr_positions.POSITIONS_ID = Convert.ToInt32(ddl_Designation.SelectedValue);
                _obj_smhr_positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtPos = BLL.get_Positions(_obj_smhr_positions);
                ddl_Grade.DataSource = dtPos;
                ddl_Grade.DataTextField = "CODERANK";
                ddl_Grade.DataValueField = "EMPLOYEEGRADE_ID";
                ddl_Grade.DataBind();
                //ddl_Grade.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            }
            rcb_Skill.Items.Clear();
            _obj_smhr_masters.MASTER_TYPE = "SKILL";
            _obj_smhr_masters.OPERATION = operation.Select;
            _obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);
            rcb_Skill.DataSource = dt_Details;
            rcb_Skill.DataTextField = "HR_MASTER_CODE";
            rcb_Skill.DataValueField = "HR_MASTER_ID";
            rcb_Skill.DataBind();
            rcb_Skill.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            //Qualification
            ddl_Category.Items.Clear();
            _obj_smhr_masters.MASTER_TYPE = "QUALIFICATION";
            _obj_smhr_masters.OPERATION = operation.Select;
            _obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);
            ddl_Category.DataSource = dt_Details;
            ddl_Category.DataTextField = "HR_MASTER_CODE";
            ddl_Category.DataValueField = "HR_MASTER_ID";
            ddl_Category.DataBind();
            ddl_Category.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            //Language
            ddl_Language.Items.Clear();
            _obj_smhr_masters.MASTER_TYPE = "LANGUAGE";
            _obj_smhr_masters.OPERATION = operation.Select;
            _obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);
            ddl_Language.DataSource = dt_Details;
            ddl_Language.DataTextField = "HR_MASTER_CODE";
            ddl_Language.DataValueField = "HR_MASTER_ID";
            ddl_Language.DataBind();
            ddl_Language.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            //Grade
            //ddl_Grade.Items.Clear();
            //_obj_smhr_masters.MASTER_TYPE = "GRADE";
            //_obj_smhr_masters.OPERATION = operation.Select;
            //_obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);
            //ddl_Grade.DataSource = dt_Details;
            //ddl_Grade.DataTextField = "HR_MASTER_CODE";
            //ddl_Grade.DataValueField = "HR_MASTER_ID";
            //ddl_Grade.DataBind();
            //ddl_Grade.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            //Relationship
            ddl_Relationship.Items.Clear();
            _obj_smhr_masters.MASTER_TYPE = "RELATIONSHIP";
            _obj_smhr_masters.OPERATION = operation.Select;
            _obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);
            ddl_Relationship.DataSource = dt_Details;
            ddl_Relationship.DataTextField = "HR_MASTER_CODE";
            ddl_Relationship.DataValueField = "HR_MASTER_ID";
            ddl_Relationship.DataBind();
            ddl_Relationship.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            //Salary Structure
            ddl_SalaryStructure.Items.Clear();
            _obj_smhr_salaryStruct = new SMHR_SALARYSTRUCT();
            _obj_smhr_salaryStruct.ISDELETED = false;
            _obj_smhr_salaryStruct.OPERATION = operation.Select;
            _obj_smhr_salaryStruct.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_SalaryHeaderDetails(_obj_smhr_salaryStruct);
            ddl_SalaryStructure.DataSource = dt_Details;
            ddl_SalaryStructure.DataTextField = "SALARYSTRUCT_CODE";
            ddl_SalaryStructure.DataValueField = "SALARYSTRUCT_ID";
            ddl_SalaryStructure.DataBind();
            ddl_SalaryStructure.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            //Leave Structure
            ddl_LeaveStructure.Items.Clear();
            _obj_smhr_leaveStruct = new SMHR_LEAVESTRUCT();
            _obj_smhr_leaveStruct.OPERATION = operation.Select;
            _obj_smhr_leaveStruct.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_LeaveStructHeaderDetails(_obj_smhr_leaveStruct);
            ddl_LeaveStructure.DataSource = dt_Details;
            ddl_LeaveStructure.DataTextField = "LEAVESTRUCT_CODE";
            ddl_LeaveStructure.DataValueField = "LEAVESTRUCT_ID";
            ddl_LeaveStructure.DataBind();
            ddl_LeaveStructure.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            //Relationship
            ddlRelation.Items.Clear();
            _obj_smhr_masters.MASTER_TYPE = "RELATIONSHIP";
            _obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_masters.OPERATION = operation.Select;
            dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);
            ddlRelation.DataSource = dt_Details;
            ddlRelation.DataTextField = "HR_MASTER_CODE";
            ddlRelation.DataValueField = "HR_MASTER_ID";
            ddlRelation.DataBind();
            ddlRelation.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            //Shift
            ddl_Shift.Items.Clear();
            _obj_smhr_shift = new SMHR_SHIFTDEFINITION();
            _obj_smhr_shift.OPERATION = operation.Select;
            _obj_smhr_shift.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_ShiftDefinition(_obj_smhr_shift);
            ddl_Shift.DataSource = dt_Details;
            ddl_Shift.DataTextField = "SHIFT_CODE";
            ddl_Shift.DataValueField = "SHIFT_ID";
            ddl_Shift.DataBind();
            ddl_Shift.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            //Supervisor

            //OT Type
            ddl_OTType.Items.Clear();
            _obj_smhr_masters.OPERATION = operation.Select;
            _obj_smhr_masters.MASTER_TYPE = "OT";
            _obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);
            ddl_OTType.DataSource = dt_Details;
            ddl_OTType.DataValueField = "HR_MASTER_ID";
            ddl_OTType.DataTextField = "HR_MASTER_CODE";
            ddl_OTType.DataBind();
            ddl_OTType.Items.Insert(0, new RadComboBoxItem("Select"));
            // Applciant
            ddl_Applicant.Items.Clear();
            _obj_smhr_applicant = new SMHR_APPLICANT();
            _obj_smhr_applicant.OPERATION = operation.Check;
            _obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_Applicant(_obj_smhr_applicant);
            ddl_Applicant.DataSource = dt_Details;
            ddl_Applicant.DataValueField = "APPLICANT_ID";
            ddl_Applicant.DataTextField = "APPNAME";
            ddl_Applicant.DataBind();
            ddl_Applicant.Items.Insert(0, new RadComboBoxItem("Select"));
            //Skills Year
            DataTable dt = BLL.get_Year(1);// need to get clarification 2020
            rcb_YearLastUsed.DataSource = dt;
            rcb_YearLastUsed.DataValueField = "SMHR_YEAR_ID";
            rcb_YearLastUsed.DataTextField = "SMHR_YEAR";
            rcb_YearLastUsed.DataBind();
            rcb_YearLastUsed.Items.Insert(0, new RadComboBoxItem("Select"));
            ddl_Employee_Status.Items.Clear();
            _obj_smhr_masters.MASTER_TYPE = "STATUS";
            _obj_smhr_masters.OPERATION = operation.Select;
            dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);//as it is c data done nothing
            ddl_Employee_Status.DataSource = dt_Details;
            ddl_Employee_Status.DataTextField = "HR_MASTER_CODE";
            ddl_Employee_Status.DataValueField = "HR_MASTER_ID";
            ddl_Employee_Status.DataBind();
            ddl_Employee_Status.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));





            //To populate County
            LoadCounty();
            LoadProject();
            LoadFunding();
            //To populate EmployeeType
            LoadEmployeeTypes();

            //to load the Employee Residency Type for PNG localozation

            //loadRadioList();
            //loadRadio();

            //ddl_baseloc.Items.Clear();
            //_obj_smhr_loc = new SMHR_LOCATION();
            //_obj_smhr_loc.OPERATION = operation.Check;
            //_obj_smhr_loc.MODE = 4;
            //_obj_smhr_loc.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //dt_Details = BLL.get_Location(_obj_smhr_loc);
            //ddl_baseloc.DataSource = dt_Details;
            //ddl_baseloc.DataValueField = "LOCATION_ID";
            //ddl_baseloc.DataTextField = "LOCATION_NAME";
            //ddl_baseloc.DataBind();
            //ddl_baseloc.Items.Insert(0, new RadComboBoxItem("Select"));



            ////Employee Category
            rcmbCategory.Items.Clear();
            SMHR_MASTERS _obj_smhr_Master = new SMHR_MASTERS();
            _obj_smhr_Master.MASTER_TYPE = "CATEGORY";
            _obj_smhr_Master.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_Master.OPERATION = operation.Select;
            DataTable dtCategory = BLL.get_MasterRecords(_obj_smhr_Master);
            if (dtCategory.Rows.Count > 0)
            {
                rcmbCategory.DataSource = dtCategory;
                rcmbCategory.DataTextField = "HR_MASTER_CODE";
                rcmbCategory.DataValueField = "HR_MASTER_ID";
                rcmbCategory.DataBind();
                rcmbCategory.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            }
            else
            {
                rcmbCategory.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadEmployeeTypes()
    {
        try
        {
            SMHR_EMPLOYEETYPE _obj_Smhr_EMPLOYEETYPE = new SMHR_EMPLOYEETYPE();
            _obj_Smhr_EMPLOYEETYPE.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //_obj_Smhr_EMPLOYEETYPE.EMPLOYEETYPE_ID = Convert.ToInt32(ddl_EmpStatus.SelectedValue);
            _obj_Smhr_EMPLOYEETYPE.OPERATION = operation.Select;
            DataTable dtEmpType = BLL.get_EmployeeType(_obj_Smhr_EMPLOYEETYPE);
            ddl_EmpStatus.Items.Clear();
            if (dtEmpType.Rows.Count > 0)
            {
                ddl_EmpStatus.DataSource = dtEmpType;
                ddl_EmpStatus.DataTextField = "EMPLOYEETYPE_CODE";
                ddl_EmpStatus.DataValueField = "EMPLOYEETYPE_ID";
                ddl_EmpStatus.DataBind();
                ddl_EmpStatus.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadCounty()
    {
        try
        {
            SMHR_COUNTY _obj_Smhr_County = new SMHR_COUNTY();
            _obj_Smhr_County.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_County.OPERATION = operation.Select;
            DataTable dt = BLL.get_County(_obj_Smhr_County);
            rcmb_County.DataSource = dt;
            rcmb_County.DataTextField = "COUNTY_CODE";
            rcmb_County.DataValueField = "COUNTY_ID";
            rcmb_County.DataBind();
            rcmb_County.Items.Insert(0, new RadComboBoxItem("Select", "0"));
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadUserGroups()
    {
        try
        {
            SMHR_LOGINTYPE _obj_Smhr_LoginInfo = new SMHR_LOGINTYPE();
            rcmb_usergroup.Items.Clear();
            _obj_Smhr_LoginInfo.OPERATION = operation.Select;
            _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            rcmb_usergroup.DataSource = BLL.get_LoginType(_obj_Smhr_LoginInfo);
            rcmb_usergroup.DataTextField = "LOGTYP_CODE";
            rcmb_usergroup.DataValueField = "LOGTYP_ID";
            rcmb_usergroup.DataBind();
            rcmb_usergroup.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadApplicant()
    {
        try
        {
            ddl_Applicant.Items.Clear();
            _obj_smhr_applicant = new SMHR_APPLICANT();
            _obj_smhr_applicant.OPERATION = operation.Select;
            _obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_Applicant(_obj_smhr_applicant);
            ddl_Applicant.DataSource = dt_Details;
            ddl_Applicant.DataValueField = "APPLICANT_ID";
            ddl_Applicant.DataTextField = "APPNAME";
            ddl_Applicant.DataBind();
            ddl_Applicant.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void LoadProject()
    {
        try
        {
            SMHR_PROJECT smhrPorject = new SMHR_PROJECT();
            smhrPorject.PROJECT_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            // smhrPorject.PROJECT_BUSINESSUNIT_ID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
            smhrPorject.OPERATION = operation.Get;
            rcmbProject.DataSource = BLL.GetProject(smhrPorject);
            rcmbProject.DataTextField = "PROJECT_NAME";
            rcmbProject.DataValueField = "PROJECT_ID";
            rcmbProject.DataBind();
            rcmbProject.Items.Insert(0, new RadComboBoxItem("Select", "0"));
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void LoadFunding()
    {
        try
        {
            SMHR_PROJECT smhrPorject = new SMHR_PROJECT();
            smhrPorject.PROJECT_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //smhrPorject.PROJECT_BUSINESSUNIT_ID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
            smhrPorject.OPERATION = operation.Get;
            rcmb_Funding.DataSource = BLL.GetProject(smhrPorject);
            rcmb_Funding.DataTextField = "PROJECT_NAME";
            rcmb_Funding.DataValueField = "PROJECT_ID";
            rcmb_Funding.DataBind();
            rcmb_Funding.Items.Insert(0, new RadComboBoxItem("Select", "0"));
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
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
            dtFamily = new DataTable(); //Datatable for Family
            dtSwipe = new DataTable(); //Datatable for Swipe
            dtOTRate = new DataTable(); //DataTable for OT rate
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
            dtFamily.Rows.Clear();
            dtFamily.Columns.Clear();
            dtSwipe.Rows.Clear();
            dtSwipe.Columns.Clear();
            dtOTRate.Rows.Clear();
            dtOTRate.Columns.Clear();
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
            dtExperience.Columns.Add("APPEXP_RANDID");//DUMPING RANDOM NUMBER
            dtExperience.PrimaryKey = new DataColumn[] { dtExperience.Columns["APPEXP_SERIAL"] };
            //Skill
            dt_Skill.Columns.Add("APPSKL_ID");
            dt_Skill.Columns.Add("APPSKL_SKILL_ID");
            dt_Skill.Columns.Add("APPSKL_SKILL_NAME");
            dt_Skill.Columns.Add("APPSKL_LASTUSED");
            dt_Skill.Columns.Add("APPSKL_EXPERT");
            dt_Skill.Columns.Add("APPSKL_EXPERT_NAME");
            dt_Skill.Columns.Add("APPSKL_RANDID");
            dt_Skill.PrimaryKey = new DataColumn[] { dt_Skill.Columns["APPSKL_SKILL_ID"] };
            //Contact
            dt_Contact.Columns.Add("APPCONT_ID");
            dt_Contact.Columns.Add("APPCONT_SERIAL");
            dt_Contact.Columns.Add("APPCONT_COMPANY");
            dt_Contact.Columns.Add("APPCONT_CONTACT");
            dt_Contact.Columns.Add("APPCONT_PHONE");
            dt_Contact.Columns.Add("APPCONT_ADDRESS");
            dt_Contact.Columns.Add("APPCONT_RANDID");
            dt_Contact.PrimaryKey = new DataColumn[] { dt_Contact.Columns["APPCONT_SERIAL"] };
            //Qualification
            dt_Qual.Columns.Add("APPQFN_ID");
            dt_Qual.Columns.Add("APPQFN_QUALIFICATION_ID");
            dt_Qual.Columns.Add("APPQFN_QUALIFICATION_NAME");
            dt_Qual.Columns.Add("APPQFN_INSTITUTE");
            dt_Qual.Columns.Add("APPQFN_PASSEDYEAR");
            dt_Qual.Columns.Add("APPQFN_PERCENTAGE");
            dt_Qual.Columns.Add("APPQFN_GRADE");
            dt_Qual.Columns.Add("APPQFN_RANDID");
            dt_Qual.PrimaryKey = new DataColumn[] { dt_Qual.Columns["APPQFN_QUALIFICATION_ID"] };
            //Language
            dtLanguage.Columns.Add("APPLAN_ID");
            dtLanguage.Columns.Add("APPLAN_LANGUAGE_ID");
            dtLanguage.Columns.Add("APPLAN_LANGUAGE_NAME");
            dtLanguage.Columns.Add("APPLAN_READ");
            dtLanguage.Columns.Add("APPLAN_WRITE");
            dtLanguage.Columns.Add("APPLAN_SPEAK");
            dtLanguage.Columns.Add("APPLAN_UNDERSTAND");
            dtLanguage.Columns.Add("APPLAN_RANDID");
            dtLanguage.PrimaryKey = new DataColumn[] { dtLanguage.Columns["APPLAN_LANGUAGE_ID"] };
            //Reference
            dtReference.Columns.Add("APPREF_ID");
            dtReference.Columns.Add("APPREF_REFFERED_EMP_ID");
            dtReference.Columns.Add("APPREF_REFFERED_EMP_NAME");
            dtReference.Columns.Add("APPREF_RELATIONSHIP");
            dtReference.Columns.Add("APPREF_RELATIONSHIP_NAME");
            dtReference.Columns.Add("APPREF_REFERRED");
            dtReference.Columns.Add("APPREF_RANDID");
            dtReference.PrimaryKey = new DataColumn[] { dtReference.Columns["APPREF_REFFERED_EMP_ID"] };
            //Family
            dtFamily.Columns.Add("EMPFMDTL_ID");
            dtFamily.Columns.Add("EMPFMDTL_SERIAL");
            dtFamily.Columns.Add("EMPFMDTL_EMPREL_ID");
            dtFamily.Columns.Add("EMPFMDTL_EMPREL_NAME");
            dtFamily.Columns.Add("EMPFMDTL_SURNAME");
            dtFamily.Columns.Add("EMPFMDTL_NAME");
            dtFamily.Columns.Add("EMPFMDTL_RELDOB");
            dtFamily.Columns.Add("EMPFMDTL_RELEMERGENCY");
            dtFamily.Columns.Add("EMPFMDTL_RANDID");
            dtFamily.Columns.Add("EMPFMDTL_PHOTO");
            dtFamily.Columns.Add("EMPFMDTL_BIODATA");
            dtFamily.Columns.Add("EMPFMDTL_BIOMETRICDOC");

            dtFamily.Columns.Add("EMPFMDTL_IS_DEP");
            dtFamily.Columns.Add("EMPFMDTL_IS_EDU");
            dtFamily.Columns.Add("EMPFMDTL_IS_MED");
            dtFamily.PrimaryKey = new DataColumn[] { dtFamily.Columns["EMPFMDTL_SERIAL"] };
            //Swipe Card
            //Swipe Card Details
            dtSwipe.Columns.Add("EMPSWM_ID");
            dtSwipe.Columns.Add("EMPSWM_SERIAL");
            dtSwipe.Columns.Add("EMPSWM_CARDCODE");
            dtSwipe.Columns.Add("EMPSWM_CARDISSUE");
            dtSwipe.Columns.Add("EMPSWM_CARDEXPIRY");
            dtSwipe.Columns.Add("EMPSWM_REMARKS");
            dtSwipe.Columns.Add("EMPSWM_RANDID");
            dtSwipe.PrimaryKey = new DataColumn[] { dtSwipe.Columns["EMPSWM_SERIAL"] };
            //OT Rate
            dtOTRate.Columns.Add("EMPOTR_ID");
            dtOTRate.Columns.Add("EMPOTR_OTTYPE_ID");
            dtOTRate.Columns.Add("EMPOTR_OTTYPE_NAME");
            dtOTRate.Columns.Add("EMPOTR_OTRATE");
            dtOTRate.Columns.Add("EMPOTR_RANDID");
            dtOTRate.PrimaryKey = new DataColumn[] { dtOTRate.Columns["EMPOTR_OTTYPE_ID"] };

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
            RG_Family.DataSource = dtFamily;
            RG_Family.DataBind();
            RG_Swipe.DataSource = dtSwipe;
            RG_Swipe.DataBind();
            RG_OTRate.DataSource = dtOTRate;
            RG_OTRate.DataBind();

            ViewState["dtExperience"] = dtExperience;
            ViewState["dt_Contact"] = dt_Contact;
            ViewState["dtLanguage"] = dtLanguage;
            ViewState["dt_Skill"] = dt_Skill;
            ViewState["dtReference"] = dtReference;
            ViewState["dt_Qual"] = dt_Qual;
            ViewState["dtFamily"] = dtFamily;
            ViewState["dtSwipe"] = dtSwipe;
            ViewState["dtOTRate"] = dtOTRate;
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region serialAll

    private int getSwipeSerial()
    {
        int serialMax = 0;
        try
        {

            if (RG_Swipe.Items.Count == 0)
            {
                serialMax = 1;
            }
            else if (RG_Swipe.Items.Count > 0)
            {
                serialMax = Convert.ToInt32(RG_Swipe.Items.Count);
                serialMax = serialMax + 1;
            }


        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return serialMax;
    }

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
                serialMax = RG_Experience.Items.Count;
                serialMax += 1;
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
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
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return serialMax;
    }

    private int getFamilySerial()
    {
        int serialMax = 0;
        try
        {
            if (RG_Family.Items.Count == 0)
            {
                serialMax = 1;
            }
            else
            {
                serialMax = RG_Family.Items.Count + 1;
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return serialMax;
    }

    #endregion

    #region clearMethods

    private void clearPersonal()
    {
        try
        {
            // ddl_Applicant.SelectedIndex = -1;
            //lbl_Code.Text = string.Empty;
            txt_AppLastName.Text = string.Empty;
            txt_AppMiddleName.Text = string.Empty;
            txt_BasicPay.Value = null;
            txt_DOB.SelectedDate = null;
            txt_DOC.SelectedDate = null;
            txt_DOJ.SelectedDate = null;
            txt_endDate.SelectedDate = null;
            txt_FirstName.Text = string.Empty;
            //        txt_GrossSalary.Value = null;
            ddl_Jobs.SelectedIndex = -1;
            ddl_Designation.SelectedIndex = -1;
            ddl_Grade.SelectedIndex = -1;
            ddl_Mode.SelectedIndex = -1;
            ddl_Nationality.SelectedIndex = -1;
            ddl_Tribe.SelectedIndex = -1;
            ddl_SalaryStructure.SelectedIndex = -1;
            ddl_Shift.SelectedIndex = -1;
            ddl_Supervisor.SelectedIndex = -1;
            txt_Address.Text = string.Empty;
            txt_Remarks.Text = string.Empty;
            txt_probDate.SelectedDate = null;
            rdp_contract_start.SelectedDate = null;
            rdp_contract_end.SelectedDate = null;
            txt_IncrementDate.SelectedDate = null;
            txt_previousProm.SelectedDate = null;
            ddl_Mode.SelectedIndex = -1;
            rntxt_NoticePeriod.Value = null;
            ddl_Title.SelectedIndex = -1;
            ddl_BloodGroup.SelectedIndex = -1;
            txt_startDate.SelectedDate = null;
            txt_endDate.SelectedDate = null;
            ddl_MaritalStatus.SelectedIndex = -1;
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void clearFamilyFields()
    {
        try
        {
            txt_FDOB.SelectedDate = null;
            radSurName.Text = string.Empty;
            txt_Name.Text = string.Empty;
            lbl_FDOB.Visible = false;
            txt_FDOB.Visible = false;
            //radFIDNumber.Text = string.Empty;
            //radFIDNumber.Visible = false;
            txt_FDOB.Visible = false;
            chk_EmergencyCont.Visible = false;
            ddlRelation.SelectedIndex = -1;
            chk_EmergencyCont.Checked = false;
            btn_Fam_Add.Visible = true;
            btn_Fam_Correct.Visible = false;
            chkDeptAlwnce.Checked = false;
            chkEduAlwnce.Checked = false;
            chkMedAlwnce.Checked = false;
            //rntxt_Annual.Text = "";
            // rntxt_Annual.Value = 0.0;
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void clearQualFields()
    {
        try
        {
            ddl_Category.SelectedIndex = -1;
            txt_Institute.Text = string.Empty;
            txt_YearofPass.Value = null;
            txt_Percentage.Value = null;
            ddl__Grade.SelectedIndex = -1;
            btn_Qual_Add.Visible = true;
            btn_Qual_Correct.Visible = false;
            ddl_Category.Enabled = true;
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void clearSkillFields()
    {
        try
        {
            rcb_Skill.SelectedIndex = -1;
            rcb_ExpertLevel.SelectedIndex = -1;
            rcb_YearLastUsed.SelectedIndex = -1;
            btn_Skill_Add.Visible = true;
            btn_Skill_Correct.Visible = false;
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
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
                txt_Serial.Text = "1";
            else
            {
                count += 1;
                txt_Serial.Text = Convert.ToString(count);
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
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
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
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
            btn_Con_Add.Visible = true;
            btn_Con_Correct.Visible = false;
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
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
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void clearSwpFields()
    {
        try
        {
            txt_CardCode.Text = string.Empty;
            txt_ExpiryDate.SelectedDate = null;
            txt_IssueDate.SelectedDate = null;
            txt_SwpRemarks.Text = string.Empty;
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void clearOTFields()
    {
        try
        {
            ddl_OTType.SelectedIndex = -1;
            txt_Value.Value = null;
            btn_OT_Add.Visible = true;
            btn_OT_Correct.Visible = false;
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void clearOtherDetails()
    {
        try
        {
            rtxt_IdNumber.Text = string.Empty;
         //   rtxt_PinNumber.Text = string.Empty;
           // rtxt_NssfNo.Text = string.Empty;
            rtxt_NhifNo.Text = string.Empty;
            rtxt_TaxReliefAmt.Text = string.Empty;
            rtxt_NnakNo.Text = string.Empty;
           // rtxt_PPIDNo.Text = string.Empty;
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void clearPhysicalDetails()
    {
        try
        {
            rtxt_Height.Text = string.Empty;
            rtxt_Weight.Text = string.Empty;
            rtxt_SkinColor.Text = string.Empty;
            rtxt_IdentificationMarks.Text = string.Empty;
            //rtxt_BGroup.Text = string.Empty;
            rtxt_EyePower.Text = string.Empty;
            rtxt_Handicapped.Text = string.Empty;
            rtxt_TreatmentName_Physical.Text = string.Empty;
            rtxt_HospitalName_Physical.Text = string.Empty;
            rtxt_TreatmentDuration_Physical.Text = string.Empty;
            rtxt_IllnessStatus_Physical.Text = string.Empty;
            rtxt_TreatmentName_Mental.Text = string.Empty;
            rtxt_HospitalName_Mental.Text = string.Empty;
            rtxt_TreatmentDuration_Mental.Text = string.Empty;
            rtxt_IllnessStatus_Mental.Text = string.Empty;
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void clearImportantDates()
    {
        try
        {
            rdp_DOA.SelectedDate = null;
            rdp_MedTerminationDate.SelectedDate = null;
            rdp_PensionDate.SelectedDate = null;
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    #region AddMethods

    protected void btn_Fam_Add_Click(object sender, EventArgs e)
    {
        try
        {
            if ((chkDeptAlwnce.Checked || chkEduAlwnce.Checked || chkMedAlwnce.Checked) &&
                (Convert.ToString(Request.QueryString["EID"]) == string.Empty || Convert.ToString(Request.QueryString["EID"]) == null))
            {
                BLL.ShowMessage(this, "Please create employee and then add the family details for checking allowances radio buttons");
                return;
            }
            if (chkDeptAlwnce.Checked)
            {
                SMHR_EMPLOYEE _obj_SMHR_EMPLOYEE = new SMHR_EMPLOYEE();

                _obj_SMHR_ALLOWANCE.OPERATION = operation.Check;
                _obj_SMHR_ALLOWANCE.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_SMHR_ALLOWANCE.ALLOWANCE_PERIOD_ID = Convert.ToInt32(rcmb_Period.SelectedValue);
                _obj_SMHR_ALLOWANCE.ALLOWANCE_EMPLOYEEGRADE_ID = Convert.ToInt32(ddl_Grade.SelectedValue);
                _obj_SMHR_ALLOWANCE.ALLOWANCE_CONFG_ID = 0; //for Dependents

                DataTable dtDepChk = BLL.GET_ALLOWANCE(_obj_SMHR_ALLOWANCE);

                _obj_SMHR_EMPLOYEE.OPERATION = operation.Available;
                _obj_SMHR_EMPLOYEE.EMP_ID = Convert.ToInt32(Request.QueryString["EID"]);
                _obj_SMHR_EMPLOYEE.EMP_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

                DataTable dtEmpFmlyChk = BLL.get_EmployeeFamily(_obj_SMHR_EMPLOYEE);

                if (dtDepChk.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtDepChk.Rows[0]["ALLOWANCE_ELIGIBLE"]) < (Convert.ToInt32(dtEmpFmlyChk.Rows[0]["COUNT"]) + 1))
                    {
                        BLL.ShowMessage(this, "Max no. of Dependents for this financial year is exceeded..!");
                        return;
                    }
                }
                else
                {
                    BLL.ShowMessage(this, "No values are defined for Dependent allowances in payitem screen");
                    chkDeptAlwnce.Checked = false;
                    return;
                }
            }
            if (chkEduAlwnce.Checked)
            {
                SMHR_EMPLOYEE _obj_SMHR_EMPLOYEE = new SMHR_EMPLOYEE();

                _obj_SMHR_ALLOWANCE.OPERATION = operation.Check;
                _obj_SMHR_ALLOWANCE.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_SMHR_ALLOWANCE.ALLOWANCE_PERIOD_ID = Convert.ToInt32(rcmb_Period.SelectedValue);
                _obj_SMHR_ALLOWANCE.ALLOWANCE_EMPLOYEEGRADE_ID = Convert.ToInt32(ddl_Grade.SelectedValue);
                _obj_SMHR_ALLOWANCE.ALLOWANCE_CONFG_ID = 1; //for Education 

                DataTable dtDepChk = BLL.GET_ALLOWANCE(_obj_SMHR_ALLOWANCE);

                _obj_SMHR_EMPLOYEE.OPERATION = operation.Check2;
                _obj_SMHR_EMPLOYEE.EMP_ID = Convert.ToInt32(Request.QueryString["EID"]);
                _obj_SMHR_EMPLOYEE.EMP_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_SMHR_EMPLOYEE.EMPFMDTL_ID = empFamilyDetailID;

                DataTable dtEmpFmlyChk = BLL.get_EmployeeFamily(_obj_SMHR_EMPLOYEE);

                if (dtDepChk.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtDepChk.Rows[0]["ALLOWANCE_ELIGIBLE"]) < (Convert.ToInt32(dtEmpFmlyChk.Rows[0]["COUNT"]) + 1))
                    {
                        BLL.ShowMessage(this, "Max no. of Dependents for this financial year is exceeded..!");
                        return;
                    }
                }
                else
                {
                    BLL.ShowMessage(this, "No values are defined for Dependent allowances in payitem screen");
                    chkDeptAlwnce.Checked = false;
                    return;
                }
                /*if (4 < (Convert.ToInt32(dtEmpFmlyChk.Rows[0]["COUNT"]) + 1))   //Convert.ToInt32(dtDepChk.Rows[0]["ALLOWANCE_ELIGIBLE"])
                {
                    BLL.ShowMessage(this, "Only 4 dependents are entitled for Education Allowance");
                    return;
                }*/
            }

            //if (Check_Combo(RG_Family, "lbl_ID", ddlRelation))
            //{
            if (string.IsNullOrEmpty(radSurName.Text))
            {
                BLL.ShowMessage(this, "please enter surname");
                return;
            }
            if (string.IsNullOrEmpty(txt_Name.Text))
            {
                BLL.ShowMessage(this, "please enter name");
                return;
            }
            if (txt_FSerial.Text == string.Empty)
            {
                if (RG_Family.Items.Count == 0)
                    txt_FSerial.Text = "1";
                else
                {
                    int countserialno = RG_Family.Items.Count;
                    countserialno += 1;
                    txt_FSerial.Text = Convert.ToString(countserialno);
                }
            }
            if (Mode == 0)
            {
                // ADDING RECORDS TO THE GRID

                btn_Fam_Add.Enabled = false;
                dtFamily = (DataTable)ViewState["dtFamily"];
                /*if (dtFamily.Rows.Count >= 5)
                {
                    BLL.ShowMessage(this, "you cant declare more than 5 dependents");
                    btn_Fam_Add.Enabled = true;
                    return;
                }
                if (dtFamily.Rows.Count > 0)
                {
                    //EMPFMDTL_EMPREL_NAME
                    DataRow[] drfilter;
                    if (string.Compare(ddlRelation.SelectedItem.Text.ToLower(), "son", true) == 0 || string.Compare(ddlRelation.SelectedItem.Text.ToLower(), "daughter", true) == 0)
                    {
                        drfilter = dtFamily.Select("EMPFMDTL_EMPREL_NAME in ('son','daughter')");
                        if (drfilter.Length == 4 && dtFamily.Rows.Count >= 4)
                        {
                            BLL.ShowMessage(this, "only four son/daughters can delcare");
                            btn_Fam_Add.Enabled = true;
                            return;
                        }
                    }
                    else
                    {
                        drfilter = dtFamily.Select("EMPFMDTL_EMPREL_NAME='" + ddlRelation.SelectedItem.Text.ToLower() + "'");
                        if (drfilter.Length == 1)
                        {
                            BLL.ShowMessage(this, "Dependent already declared");
                            btn_Fam_Add.Enabled = true;
                            return;
                        }
                    }

                    //drfilter = dtFamily.Select("EMPFMDTL_EMPREL_NAME='wife'");
                    //if (drfilter.Length == 1 && string.Compare(ddlRelation.SelectedItem.Text.ToLower(), "wife", true) == 0)
                    //{
                    //    BLL.ShowMessage(this, "Dependent already declared");
                    //    btn_Fam_Add.Enabled = true;
                    //    return;
                    //}

                }*/
                DataRow dr;
                dr = dtFamily.NewRow();
                dr[0] = "0";
                dr[1] = txt_FSerial.Text.ToString().Trim();
                dr[2] = ddlRelation.SelectedValue.ToString().Trim();
                dr[3] = Convert.ToString(ddlRelation.SelectedItem.Text);
                dr[4] = Convert.ToString(radSurName.Text);
                dr[5] = Convert.ToString(txt_Name.Text);
                if (string.Compare(ddlRelation.SelectedItem.Text.ToLower(), "spouse", true) != 0)
                {
                    if (txt_FDOB.SelectedDate == null)
                    {
                        BLL.ShowMessage(this, "please select dependent DOB");
                        btn_Fam_Add.Enabled = true;
                        return;
                    }
                    dr[6] = Convert.ToDateTime(txt_FDOB.SelectedDate.Value).ToString(BLL.get_Format(Convert.ToString(Session["ORG_ID"])));
                }
                if (chk_EmergencyCont.Checked)
                    dr[7] = true;
                else
                    dr[7] = false;
                dr[8] = lbl_Rand.Text + "-" + txt_FSerial.Text.ToString().Trim();
                if (FBrowsePhoto.HasFile)
                {
                    // Session["a"] = FUpload.FileName;
                    string imagename = txt_Name.Text + "_" + Guid.NewGuid().ToString() + "_FIMG" + FBrowsePhoto.FileName;
                    string strPath = "~/EmpUploads/" + imagename;
                    FBrowsePhoto.PostedFile.SaveAs(Server.MapPath("~/EmpUploads/") + imagename);
                    dr[9] = strPath;
                }
                if (FBioData.HasFile)
                {
                    string pdfName = txt_Name.Text + "_" + Guid.NewGuid().ToString() + "_FBIO" + FBioData.FileName;
                    string strPath = "~/EmpUploads/" + pdfName;
                    FBioData.PostedFile.SaveAs(Server.MapPath("~/EmpUploads/") + pdfName);
                    dr[10] = strPath;
                }
                if (FBioMetricData.HasFile)
                {
                    string pdfName = txt_Name.Text + "_" + Guid.NewGuid().ToString() + "_FBIOMETRIC" + FBioMetricData.FileName;
                    string strPath = "~/EmpUploads/" + pdfName;
                    FBioMetricData.PostedFile.SaveAs(Server.MapPath("~/EmpUploads/") + pdfName);
                    dr[11] = strPath;
                }
                //dr[10] = FBrowsePhoto.;
                dr[12] = false;
                dr[13] = false;
                dr[14] = false;
                dtFamily.Rows.Add(dr);
                RG_Family.DataSource = dtFamily;
                RG_Family.DataBind();
                clearFamilyFields();
                Mode = 0;
                int Serial = getFamilySerial();
                txt_FSerial.Text = Convert.ToString(Serial);
                btn_Fam_Add.Enabled = true;

            }
            else if (Mode == 2)
            {
                //if (RG_Family.Items.Count >= 5)
                //{
                //    BLL.ShowMessage(this, "you cant declare more than 5 dependents");
                //    btn_Fam_Add.Enabled = true;
                //    return;
                //}
                if (RG_Family.Items.Count > 0)
                {


                    //EMPFMDTL_EMPREL_NAME
                    Label lbRel; int count = 0;
                    foreach (GridDataItem r in RG_Family.Items)
                    {
                        lbRel = new Label();
                        lbRel = (Label)r.FindControl("lbl_Relation");
                        /*if (string.Compare(lbRel.Text.ToLower(), "son", true) == 0 || string.Compare(lbRel.Text.ToLower(), "daughter", true) == 0)
                        {
                            count++;
                            if (count == 4 && (string.Compare(ddlRelation.Text.ToLower(), "son", true) == 0 || string.Compare(ddlRelation.Text.ToLower(), "daughter", true) == 0)) //RG_Family.Items.Count>=4)
                            {
                                BLL.ShowMessage(this, "only four son/daughters can delcare");
                                btn_Fam_Add.Enabled = true;
                                return;
                            }
                        }
                        if (string.Compare(lbRel.Text.ToLower(), ddlRelation.SelectedItem.Text.ToLower(), true) == 0)
                        {
                            BLL.ShowMessage(this, "Dependent already declared");
                            btn_Fam_Add.Enabled = true;
                            return;
                        }*/
                    }
                }
                //WHEN SAVE IS CLICKED DUMPING  RECORD TO THE TABLE
                btn_Fam_Add.Enabled = false;
                bool status = false;
                _obj_smhr_employee = new SMHR_EMPLOYEE();
                _obj_smhr_employee.OPERATION = operation.Insert;
                _obj_smhr_employee.EMPFMDTL_EMP_ID = Convert.ToInt32(HF_EMPID.Value); //Convert.ToInt32(_lbl_Emp_ID);
                _obj_smhr_employee.EMPFMDTL_SERIAL = Convert.ToInt32(txt_FSerial.Text);
                _obj_smhr_employee.EMPFMDTL_EMPREL_ID = Convert.ToInt32(ddlRelation.SelectedValue);
                _obj_smhr_employee.EMPFMDTL_EMPREL_NAME = ddlRelation.SelectedItem.Text;
                _obj_smhr_employee.EMPFMDTL_SURNAME = radSurName.Text;
                _obj_smhr_employee.EMPFMDTL_NAME = Convert.ToString(txt_Name.Text);
                _obj_smhr_employee.EMPFMDTL_IS_DEP = Convert.ToBoolean(chkDeptAlwnce.Checked);
                _obj_smhr_employee.EMPFMDTL_IS_EDU = Convert.ToBoolean(chkEduAlwnce.Checked);
                _obj_smhr_employee.EMPFMDTL_IS_MED = Convert.ToBoolean(chkMedAlwnce.Checked);

                if (string.Compare(ddlRelation.SelectedItem.Text.ToLower(), "spouse", true) != 0)
                {
                    if (txt_FDOB.SelectedDate == null)
                    {
                        BLL.ShowMessage(this, "please select dependent DOB");
                        btn_Fam_Add.Enabled = true;
                        return;
                    }
                    _obj_smhr_employee.EMPFMDTL_RELDOB = Convert.ToDateTime(txt_FDOB.SelectedDate.Value);
                }

                if (chk_EmergencyCont.Checked)
                    _obj_smhr_employee.EMPFMDTL_EMERGENCYCONTACT = true;
                else
                    _obj_smhr_employee.EMPFMDTL_EMERGENCYCONTACT = false;

                _obj_smhr_employee.EMPFMDTL_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_smhr_employee.EMPFMDTL_CREATEDDATE = DateTime.Now;
                if (FBrowsePhoto.HasFile)
                {
                    string imagename = txt_Name.Text + "_" + Guid.NewGuid().ToString() + "_FIMG" + FBrowsePhoto.FileName;
                    string strPath = "~/EmpUploads/" + imagename;
                    FBrowsePhoto.PostedFile.SaveAs(Server.MapPath("~/EmpUploads/") + imagename);
                    _obj_smhr_employee.EMPFMDTL_PHOTO = strPath;
                }
                if (FBioData.HasFile)
                {
                    string pdfName = txt_Name.Text + "_" + Guid.NewGuid().ToString() + "_FBIO" + FBioData.FileName;
                    string strPath = "~/EmpUploads/" + pdfName;
                    FBioData.PostedFile.SaveAs(Server.MapPath("~/EmpUploads/") + pdfName);
                    _obj_smhr_employee.EMPFMDTL_BIODATA = strPath;
                }
                if (FBioMetricData.HasFile)
                {
                    string pdfName = txt_Name.Text + "_" + Guid.NewGuid().ToString() + "_FBIOMETRIC" + FBioMetricData.FileName;
                    string strPath = "~/EmpUploads/" + pdfName;
                    FBioMetricData.PostedFile.SaveAs(Server.MapPath("~/EmpUploads/") + pdfName);
                    _obj_smhr_employee.EMPFMDTL_BIOMETRICDOC = strPath;
                }
                status = BLL.set_EmpFamily(_obj_smhr_employee);//no organisation column is found in this table
                Mode = 2;
                if (status == true)
                {
                    LoadFamily();
                    clearFamilyFields();
                    int Serial = getFamilySerial();
                    txt_FSerial.Text = Convert.ToString(Serial);
                }
                btn_Fam_Add.Enabled = true;
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Con_Add_Click(object sender, EventArgs e)
    {
        try
        {
            if (Mode == 0)
            {
                btn_Con_Add.Enabled = false;
                dt_Contact = (DataTable)ViewState["dt_Contact"];
                DataRow dr = dt_Contact.NewRow();
                dr[0] = "0";
                dr[1] = txt_Serail_C.Text;
                dr[2] = txt_Company_C.Text.Replace("'", "''");
                dr[3] = txt_ContactName.Text.Replace("'", "''");
                dr[4] = txt_PhoneNumber.Text;
                dr[5] = txt_Address_C.Text.Replace("'", "''");
                dr[6] = lbl_Rand.Text + "-" + txt_Serail_C.Text;
                dt_Contact.Rows.Add(dr);
                RG_Contact.DataSource = dt_Contact;
                RG_Contact.DataBind();
                clearConFields();
                Mode = 0;
                int conSerial = getContactSerial();
                txt_Serail_C.Text = Convert.ToString(conSerial);
                btn_Con_Add.Enabled = true;
            }
            else if (Mode == 2)
            {
                btn_Con_Add.Enabled = false;
                _obj_smhr_applicant = new SMHR_APPLICANT();
                bool status = false;
                _obj_smhr_applicant.OPERATION = operation.Insert;
                _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                _obj_smhr_applicant.APPCONT_SERIAL = Convert.ToInt32(txt_Serail_C.Text.Replace("'", "''"));
                _obj_smhr_applicant.APPCONT_COMPANY = Convert.ToString(txt_Company_C.Text.Replace("'", "''"));
                _obj_smhr_applicant.APPCONT_CONTACT = Convert.ToString(txt_ContactName.Text.Replace("'", "''"));
                _obj_smhr_applicant.APPCONT_PHONE = Convert.ToString(txt_PhoneNumber.Text.Replace("'", "''"));
                _obj_smhr_applicant.APPCONT_ADDRESS = Convert.ToString(txt_Address_C.Text.Replace("'", "''"));
                _obj_smhr_applicant.APPCONT_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_smhr_applicant.APPCONT_CREATEDDATE = DateTime.Now;
                status = BLL.set_ApplicantContact(_obj_smhr_applicant);//no organisation column has found
                Mode = 2;
                clearConFields();
                LoadContact();
                btn_Con_Add.Enabled = true;
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Lang_Add_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddl_Language.SelectedValue != string.Empty)
            {
                if (Check_Combo(RG_Language, "lbl_ID", ddl_Language))
                {
                    BLL.ShowMessage(this, "This Language is already added");
                    ddl_Language.Focus();
                    return;
                }

                if (Mode == 0)
                {
                    _obj_smhr_applicant = new SMHR_APPLICANT();
                    bool status = false;
                    _obj_smhr_applicant.OPERATION = operation.Insert;
                    if (_obj_smhr_applicant.APPLICANT_ID == null || _obj_smhr_applicant.APPLICANT_ID == 0)
                    {
                        if (_obj_smhr_applicant.APPLICANT_ID == null)
                        {
                            BLL.ShowMessage(this, "Please select applicant");
                            return;
                        }
                        else
                        {
                            BLL.ShowMessage(this, "There is no applicant exists to update this record...");
                            return;
                        }
                    }
                    btn_Lang_Add.Enabled = true;
                    if (chk_Read.Checked == false && chk_Speak.Checked == false &&
                                chk_Understand.Checked == false && chk_Write.Checked == false)
                    {
                        BLL.ShowMessage(this, "Please Check atleast one mode");
                        return;
                    }


                    dtLanguage = (DataTable)ViewState["dtLanguage"];

                    if (dtLanguage.Columns.Count > 8)
                    {
                        DataRow dr1 = dtLanguage.NewRow();
                        //dr[0] = "0";
                        dr1[2] = ddl_Language.SelectedValue;
                        dr1[3] = ddl_Language.SelectedItem.Text;
                        if (chk_Read.Checked)
                            dr1[4] = true;
                        else
                            dr1[4] = false;
                        if (chk_Write.Checked)
                            dr1[5] = true;
                        else
                            dr1[5] = false;
                        if (chk_Speak.Checked)
                            dr1[6] = true;
                        else
                            dr1[6] = false;
                        if (chk_Understand.Checked)
                            dr1[7] = true;
                        else
                            dr1[7] = false;
                        //dr1[7] = lbl_Rand.Text + "-" + dtLanguage.Rows.Count;
                        dtLanguage.Rows.Add(dr1);
                    }

                    else
                    {
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
                        //dr[7] = lbl_Rand.Text + "-" + dtLanguage.Rows.Count;
                        dtLanguage.Rows.Add(dr);
                    }
                    RG_Language.DataSource = dtLanguage;
                    RG_Language.DataBind();
                    clearLangFields();
                    btn_Lang_Add.Visible = true;
                    btn_Lang_Correct.Visible = false;
                    ddl_Language.Enabled = true;
                    Mode = 0;
                    btn_Lang_Add.Enabled = true;
                }

                else if (Mode == 2)
                {

                    btn_Lang_Add.Enabled = false;
                    if (chk_Read.Checked == false && chk_Speak.Checked == false &&
                                chk_Understand.Checked == false && chk_Write.Checked == false)
                    {
                        BLL.ShowMessage(this, "Please Check atleast one mode");
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
                    _obj_smhr_applicant.APPLAN_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_applicant.APPLAN_CREATEDDATE = DateTime.Now;
                    status = BLL.set_ApplicantLanguage(_obj_smhr_applicant);//no organisation column has found
                    clearLangFields();

                    Mode = 2;
                    LoadLanguage();

                    btn_Lang_Add.Enabled = true;
                }
            }
            //}

            else
            {
                BLL.ShowMessage(this, "Please select Language");
                ddl_Language.Focus();
                return;
            }

            //else
            //{
            //    BLL.ShowMessage(this, "This Language is already added");
            //    ddl_Language.Focus();
            //    return;
            //}

        }

        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Qual_Add_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddl_Category.SelectedValue != string.Empty)
            {
                if (Check_Combo(RG_Qualification, "lbl_ID", ddl_Category))
                {
                    BLL.ShowMessage(this, "This Qualification is already added");
                    ddl_Category.Focus();
                    return;
                }
                if (Mode == 0) //New Add
                {
                    btn_Qual_Add.Enabled = false;
                    dt_Qual = (DataTable)ViewState["dt_Qual"];
                    if (dt_Qual.Columns.Count > 8)
                    {
                        //dt_Qual = (DataTable)RG_Qualification.DataSource;
                        DataRow dr1 = dt_Qual.NewRow();
                        //dr1[0] = "0";

                        dr1[2] = ddl_Category.SelectedValue;
                        dr1[3] = ddl_Category.SelectedItem.Text;
                        dr1[4] = txt_Institute.Text.Replace("'", "''");
                        if (txt_YearofPass.Value != null)
                            dr1[5] = txt_YearofPass.Value;
                        if (txt_Percentage.Value != null)
                            dr1[6] = txt_Percentage.Value;
                        //dr1[7] = ddl__Grade.SelectedItem.Value;
                        dr1[7] = Convert.ToString(ddl__Grade.SelectedItem.Value) == "0" ? null : Convert.ToString(ddl__Grade.SelectedItem.Value);
                        //dr1[8] = lbl_Rand.Text + "-" + dt_Qual.Rows.Count;
                        dt_Qual.Rows.Add(dr1);
                    }
                    else
                    {
                        DataRow dr = dt_Qual.NewRow();
                        dr[0] = "0";
                        dr[1] = ddl_Category.SelectedValue;
                        dr[2] = ddl_Category.SelectedItem.Text;
                        dr[3] = txt_Institute.Text.Replace("'", "''");
                        if (txt_YearofPass.Value != null)
                            dr[4] = txt_YearofPass.Value;
                        if (txt_Percentage.Value != null)
                            dr[5] = txt_Percentage.Value;
                        //dr[6] = ddl__Grade.SelectedItem.Value;
                        dr[6] = Convert.ToString(ddl__Grade.SelectedItem.Value) == "0" ? null : Convert.ToString(ddl__Grade.SelectedItem.Value);
                        dr[7] = lbl_Rand.Text + "-" + dt_Qual.Rows.Count;
                        dt_Qual.Rows.Add(dr);
                    }
                    RG_Qualification.DataSource = dt_Qual;
                    RG_Qualification.DataBind();
                    clearQualFields();
                    Mode = 0;
                    btn_Qual_Add.Enabled = true;
                }
                else if (Mode == 2) // Edit Add
                {
                    btn_Qual_Add.Enabled = false;
                    _obj_smhr_applicant = new SMHR_APPLICANT();
                    bool status = false;
                    _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                    _obj_smhr_applicant.APPQFN_QUALIFICATION_ID = Convert.ToInt32(ddl_Category.SelectedValue);
                    _obj_smhr_applicant.APPQFN_INSTITUTE = Convert.ToString(txt_Institute.Text.Replace("'", "''"));
                    _obj_smhr_applicant.APPQFN_PASSEDYEAR = Convert.ToInt32(txt_YearofPass.Value);
                    if (txt_Percentage.Value != null)
                        _obj_smhr_applicant.APPQFN_PERCENTAGE = Convert.ToDouble(Convert.ToString(txt_Percentage.Value));
                    //_obj_smhr_applicant.APPQFN_GRADE = Convert.ToString(ddl__Grade.SelectedItem.Value);
                    _obj_smhr_applicant.APPQFN_GRADE = Convert.ToString(ddl__Grade.SelectedItem.Value) == "0" ? null : Convert.ToString(ddl__Grade.SelectedItem.Value);
                    _obj_smhr_applicant.APPQFN_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_applicant.APPQFN_CREATEDDATE = DateTime.Now;
                    _obj_smhr_applicant.OPERATION = operation.Insert;
                    status = BLL.set_AppQualification(_obj_smhr_applicant);//no organisation column has found
                    Mode = 2;
                    LoadQualification();
                    clearQualFields();
                    ddl_Category.Enabled = true;
                    btn_Qual_Add.Enabled = true;
                }
            }

        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Skill_Add_Click(object sender, EventArgs e)
    {
        try
        {
            if (rcb_Skill.SelectedValue != string.Empty)
            {
                if (Check_Combo(RG_Skills, "lbl_Skill_ID", rcb_Skill))
                {
                    BLL.ShowMessage(this, "This Skill Set has already been added");
                    rcb_Skill.Focus();
                    return;
                }
                if (Mode == 0)
                {
                    btn_Skill_Add.Enabled = false;
                    dt_Skill = (DataTable)ViewState["dt_Skill"];
                    if (dt_Skill.Columns.Count > 7)
                    {
                        DataRow dr1 = dt_Skill.NewRow();
                        //dr1[0] = "0";
                        dr1[2] = rcb_Skill.SelectedValue;
                        dr1[3] = rcb_ExpertLevel.SelectedValue;
                        dr1[4] = rcb_ExpertLevel.SelectedItem.Text;
                        dr1[5] = rcb_Skill.SelectedItem.Text;
                        dr1[6] = rcb_YearLastUsed.SelectedItem.Text;
                        //dr1[7] = lbl_Rand.Text + "-" + dt_Skill.Rows.Count;
                        dt_Skill.Rows.Add(dr1);
                    }
                    else
                    {
                        DataRow dr = dt_Skill.NewRow();
                        dr[0] = "0";
                        dr[1] = rcb_Skill.SelectedValue;
                        dr[2] = rcb_Skill.SelectedItem.Text;
                        dr[3] = rcb_YearLastUsed.SelectedItem.Text;
                        dr[4] = rcb_ExpertLevel.SelectedValue;
                        dr[5] = rcb_ExpertLevel.SelectedItem.Text;
                        //dr[6] = lbl_Rand.Text + "-" + dt_Skill.Rows.Count;
                        dt_Skill.Rows.Add(dr);

                    }
                    RG_Skills.DataSource = dt_Skill;
                    RG_Skills.DataBind();
                    clearSkillFields();
                    Mode = 0;
                    btn_Skill_Add.Enabled = true;
                }
                else if (Mode == 2)
                {
                    btn_Skill_Add.Enabled = false;
                    _obj_smhr_applicant = new SMHR_APPLICANT();
                    bool status = false;
                    _obj_smhr_applicant.OPERATION = operation.Insert;
                    _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                    _obj_smhr_applicant.APPSKL_SKILL_ID = Convert.ToInt32(rcb_Skill.SelectedItem.Value);
                    _obj_smhr_applicant.APPSKL_LASTUSED = Convert.ToInt32(rcb_YearLastUsed.SelectedItem.Text);
                    _obj_smhr_applicant.APPSKL_EXPERT = Convert.ToInt32(rcb_ExpertLevel.SelectedValue);
                    _obj_smhr_applicant.APPSKL_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_applicant.APPSKL_CREATEDDATE = DateTime.Now;
                    status = BLL.set_ApplicantSkills(_obj_smhr_applicant);//no organisation column has found
                    Mode = 2;
                    clearSkillFields();
                    LoadSkill();
                    btn_Skill_Add.Enabled = true;
                }
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Exp_Add_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_Serial.Text == string.Empty)
            {
                if (RG_Experience.Items.Count == 0)
                    txt_Serial.Text = "1";
                else
                {
                    int countserialno = RG_Experience.Items.Count;
                    countserialno += 1;
                    txt_Serial.Text = Convert.ToString(countserialno);
                }
            }
            //else
            //{
            //    txt_Serial.Text = Convert.ToString(Exp);
            //}

            if (Mode == 0)
            {
                btn_Exp_Add.Enabled = false;
                dtExperience = (DataTable)ViewState["dtExperience"];
                //DataRow dr = dtExperience.NewRow();
                try
                {
                    if (dtExperience.Columns.Count > 11)
                    {
                        DataRow dr1 = dtExperience.NewRow();
                        //dr[0] = "0";
                        dr1[2] = txt_Serial.Text;
                        dr1[3] = txt_CompanyName.Text.Replace("'", "''");
                        if (txt_JoinDate.SelectedDate.HasValue)
                            dr1[4] = Convert.ToDateTime(txt_JoinDate.SelectedDate).ToString(BLL.get_Format(Convert.ToString(Session["ORG_ID"])));
                        else
                            dr1[4] = null;
                        dr1[5] = txt_JoinSalary.Value;
                        dr1[6] = txt_JoinDesc.Text.Replace("'", "''");
                        dr1[7] = txt_ReasonRelieve.Text.Replace("'", "''");
                        if (txt_RelieveDate.SelectedDate.HasValue)
                            dr1[8] = Convert.ToDateTime(txt_RelieveDate.SelectedDate).ToString(BLL.get_Format(Convert.ToString(Session["ORG_ID"])));
                        else
                            dr1[8] = null;
                        dr1[9] = txt_RelSalary.Value;
                        dr1[10] = txt_RelDesc.Text.Replace("'", "''");
                        //dr1[11] = lbl_Rand.Text + "-" + txt_Serial.Text;
                        dtExperience.Rows.Add(dr1);
                    }
                    else
                    {
                        DataRow dr = dtExperience.NewRow();
                        dr[0] = "0";
                        dr[1] = txt_Serial.Text;
                        dr[2] = txt_CompanyName.Text.Replace("'", "''");
                        if (txt_JoinDate.SelectedDate.HasValue)
                            dr[3] = Convert.ToDateTime(txt_JoinDate.SelectedDate).ToString(BLL.get_Format(Convert.ToString(Session["ORG_ID"])));
                        else
                            dr[3] = null;
                        dr[4] = txt_JoinSalary.Value;
                        dr[5] = txt_JoinDesc.Text.Replace("'", "''");
                        dr[6] = txt_ReasonRelieve.Text.Replace("'", "''");
                        if (txt_RelieveDate.SelectedDate.HasValue)
                            dr[7] = Convert.ToDateTime(txt_RelieveDate.SelectedDate).ToString(BLL.get_Format(Convert.ToString(Session["ORG_ID"])));
                        else
                            dr[7] = null;
                        dr[8] = txt_RelSalary.Value;
                        dr[9] = txt_RelDesc.Text.Replace("'", "''");
                        //dr[10] = lbl_Rand.Text + "-" + txt_Serial.Text;
                        dtExperience.Rows.Add(dr);
                    }
                }
                catch (Exception ae)
                {
                    BLL.ShowMessage(this, ae.Message.ToString());
                    return;
                }
                Mode = 0;
                RG_Experience.DataSource = dtExperience;
                RG_Experience.DataBind();
                //int expSerial = getExpSerial();
                //txt_Serial.Text = Convert.ToString(expSerial);
                int expserial = Convert.ToInt32(txt_Serial.Text);
                expserial += 1;
                txt_Serial.Text = Convert.ToString(expserial);
                clearExpFields();
                btn_Exp_Add.Enabled = true;

            }
            else if (Mode == 2)
            {
                btn_Exp_Add.Enabled = false;
                _obj_smhr_applicant = new SMHR_APPLICANT();
                bool status = false;
                _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                _obj_smhr_applicant.APPEXP_SERIAL = Convert.ToInt32(txt_Serial.Text);
                _obj_smhr_applicant.APPEXP_COMPANY = Convert.ToString(txt_CompanyName.Text.Replace("'", "''"));
                if (txt_JoinDate.SelectedDate.HasValue)
                    _obj_smhr_applicant.APPEXP_JOINDATE = Convert.ToDateTime(txt_JoinDate.SelectedDate.Value);
                else
                    _obj_smhr_applicant.APPEXP_JOINDATE = null;
                if (txt_JoinSalary.Text != string.Empty)
                    _obj_smhr_applicant.APPEXP_JOINSAL = Convert.ToDouble(txt_JoinSalary.Value);
                else
                    _obj_smhr_applicant.APPEXP_JOINSAL = 0.0;
                _obj_smhr_applicant.APPEXP_JOINDESC = Convert.ToString(txt_JoinDesc.Text.Replace("'", "''"));
                _obj_smhr_applicant.APPEXP_REASONREL = Convert.ToString(txt_ReasonRelieve.Text.Replace("'", "''"));
                if (txt_RelieveDate.SelectedDate.HasValue)
                    _obj_smhr_applicant.APPEXP_RELDATE = Convert.ToDateTime(txt_RelieveDate.SelectedDate.Value);
                else
                    _obj_smhr_applicant.APPEXP_RELDATE = null;
                if (txt_RelSalary.Text != string.Empty)
                    _obj_smhr_applicant.APPEXP_RELSAL = Convert.ToDouble(txt_RelSalary.Value);
                else
                    _obj_smhr_applicant.APPEXP_RELSAL = 0.0;
                _obj_smhr_applicant.APPEXP_REASONDESC = Convert.ToString(txt_RelDesc.Text.Replace("'", "''"));
                _obj_smhr_applicant.APPEXP_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_smhr_applicant.APPEXP_CREATEDDATE = DateTime.Now;
                _obj_smhr_applicant.OPERATION = operation.Insert;
                status = BLL.set_ApplicantExperience(_obj_smhr_applicant);//no organisation column has found
                Mode = 2;
                clearExpFields();
                LoadExperience();
                btn_Exp_Add.Enabled = true;

            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Ref_Add_Click(object sender, EventArgs e)
    {
        try
        {
            if (Check_Combo(RG_Reference, "lbl_ID", ddl_Employee))
            {
                if (Mode == 0)
                {
                    btn_Ref_Add.Enabled = false;
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

                    dr[6] = lbl_Rand.Text + "-" + dtReference.Rows.Count;
                    dtReference.Rows.Add(dr);
                    RG_Reference.DataSource = dtReference;
                    RG_Reference.DataBind();
                    btn_Ref_Add.Visible = true;
                    btn_Ref_Correct.Visible = false;
                    ddl_Employee.Enabled = true;
                    Mode = 0;
                    clearRefFields();
                    btn_Ref_Add.Enabled = true;
                }
                else if (Mode == 2)
                {
                    btn_Ref_Add.Enabled = false;
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
                    _obj_smhr_applicant.APPREF_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_applicant.APPREF_CREATEDDATE = DateTime.Now;
                    status = BLL.set_ApplicantReference(_obj_smhr_applicant);//no organisation column has found
                    clearRefFields();
                    Mode = 2;
                    LoadReference();
                    btn_Ref_Add.Enabled = true;
                }
            }
            else
            {
                BLL.ShowMessage(this, "This Employee is already added as Reference");
                ddl_Employee.Focus();
                return;
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_swp_Add_Click(object sender, EventArgs e)
    {
        try
        {
            if (Check_TextBox(RG_Swipe, "lbl_swpCardCode", txt_CardCode))
            {
                if (Mode == 0)
                {
                    btn_swp_Add.Enabled = false;
                    dtSwipe = (DataTable)ViewState["dtSwipe"];
                    DataRow dr = dtSwipe.NewRow();
                    dr[0] = "0";
                    dr[1] = txt_SSerial.Text;
                    dr[2] = txt_CardCode.Text;
                    dr[3] = Convert.ToDateTime(txt_IssueDate.SelectedDate).ToString(BLL.get_Format(Convert.ToString(Session["ORG_ID"])));
                    dr[4] = Convert.ToDateTime(txt_ExpiryDate.SelectedDate).ToString(BLL.get_Format(Convert.ToString(Session["ORG_ID"])));
                    dr[5] = txt_SwpRemarks.Text;
                    dr[6] = lbl_Rand.Text + "-" + txt_SSerial.Text;
                    dtSwipe.Rows.Add(dr);
                    RG_Swipe.DataSource = dtSwipe;
                    RG_Swipe.DataBind();
                    clearSwpFields();
                    Mode = 0;
                    btn_swp_Add.Enabled = true;
                }
                else if (Mode == 2)
                {
                    btn_swp_Add.Enabled = false;
                    bool status = false;
                    _obj_smhr_employee = new SMHR_EMPLOYEE();
                    _obj_smhr_employee.OPERATION = operation.Insert;
                    _obj_smhr_employee.EMPSWM_EMP_ID = Convert.ToInt32(HF_EMPID.Value); //Convert.ToInt32(_lbl_Emp_ID);
                    _obj_smhr_employee.EMPSWM_SERIAL = Convert.ToInt32(txt_SSerial.Text);
                    _obj_smhr_employee.EMPSWM_CARDCODE = Convert.ToString(txt_CardCode.Text);
                    _obj_smhr_employee.EMPSWM_CARDISSUE = Convert.ToDateTime(txt_IssueDate.SelectedDate.Value);
                    _obj_smhr_employee.EMPSWM_CARDEXPIRY = Convert.ToDateTime(txt_ExpiryDate.SelectedDate.Value);
                    _obj_smhr_employee.EMPSWM_REMARKS = Convert.ToString(txt_SwpRemarks.Text);
                    _obj_smhr_employee.EMPSWM_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_employee.EMPSWM_CREATEDDATE = DateTime.Now;
                    status = BLL.set_EmployeeSwipe(_obj_smhr_employee);//no organisation column has found
                    Mode = 2;
                    if (status == true)
                    {
                        LoadSwipe();
                        clearSwpFields();
                    }
                    btn_swp_Add.Enabled = true;
                }
                int swpSerial = getSwipeSerial();
                txt_SSerial.Text = Convert.ToString(swpSerial);
            }
            else
            {
                BLL.ShowMessage(this, "This Swipe Card Code already exists");
                txt_CardCode.Focus();
                return;
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_OT_Add_Click(object sender, EventArgs e)
    {
        try
        {
            if (Check_Combo(RG_OTRate, "lbl_OTTypeID", ddl_OTType))
            {
                if (Mode == 0)
                {
                    btn_OT_Add.Enabled = false;
                    dtOTRate = (DataTable)ViewState["dtOTRate"];
                    DataRow dr = dtOTRate.NewRow();
                    dr[0] = "0";
                    dr[1] = ddl_OTType.SelectedValue;
                    dr[2] = ddl_OTType.SelectedItem.Text;
                    dr[3] = txt_Value.Value;
                    dr[4] = lbl_Rand.Text + "-" + dtOTRate.Rows.Count;
                    dtOTRate.Rows.Add(dr);
                    Mode = 0;
                    RG_OTRate.DataSource = dtOTRate;
                    RG_OTRate.DataBind();
                    clearOTFields();
                    btn_OT_Add.Enabled = true;
                }
                else if (Mode == 2)
                {
                    btn_OT_Add.Enabled = false;
                    bool status = false;
                    _obj_smhr_employee = new SMHR_EMPLOYEE();
                    _obj_smhr_employee.OPERATION = operation.Insert;
                    _obj_smhr_employee.EMPOTR_EMP_ID = Convert.ToInt32(HF_EMPID.Value); //Convert.ToInt32(_lbl_Emp_ID); ;
                    _obj_smhr_employee.EMPOTR_OTTYPE_ID = Convert.ToInt32(ddl_OTType.SelectedValue);
                    _obj_smhr_employee.EMPOTR_OTRATE = Convert.ToDouble(txt_Value.Value);
                    _obj_smhr_employee.EMPOTR_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_employee.EMPOTR_CREATEDDATE = DateTime.Now;
                    status = BLL.set_EmpOTInfo(_obj_smhr_employee);//no organisation column has found
                    if (status == true)
                    {
                        LoadOTInfo();
                        clearOTFields();
                    }
                    Mode = 2;
                    btn_OT_Add.Enabled = true;
                }
            }
            else
            {
                BLL.ShowMessage(this, "This OT Type already exists");
                ddl_OTType.Focus();
                return;
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region Check Grid

    public bool Check_TextBox(RadGrid rdGrid, string lbl_validate, RadTextBox txt_Validate)
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
                    if (Convert.ToInt32(lbl_Control.Text) == Convert.ToInt32(txt_Validate.Text))
                    {
                        status = false;
                    }
                }
            }
            return status;
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return false;
        }
    }

    public bool Check_Combo(RadGrid rdGrid, string lbl_validate, RadComboBox rcmb_Validate)
    {
        try
        {
            bool status = false;
            if (rdGrid.Items.Count > 0)
            {
                for (int i = 0; i < rdGrid.Items.Count; i++)
                {
                    Label lbl_Control = new Label();
                    lbl_Control = rdGrid.Items[i].FindControl("" + lbl_validate + "") as Label;
                    if (Convert.ToInt32(lbl_Control.Text) == Convert.ToInt32(rcmb_Validate.SelectedValue))
                    {
                        status = true;
                    }
                }
            }
            return status;
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return false;
        }
    }

    #endregion

    #region CorrectMethods

    protected void btn_Exp_Correct_Click(object sender, EventArgs e)
    {
        try
        {
            if (Mode == 1)
            {
                dtExperience = (DataTable)ViewState["dtExperience"];
                DataRow dr;
                //DataRow dr1 = dtExperience.Rows.Find(txt_Serial.Text);
                int RowIndex = 0;
                if (dtExperience.Columns.Count > 11)
                {
                    for (int index = 0; index < dtExperience.Rows.Count; index++)
                    {
                        //if (dtExperience.Rows[index].Equals(dr1))
                        //    RowIndex = index;
                        if (dtExperience.Rows[index][2].ToString() == txt_Serial.Text)
                            RowIndex = index;
                    }
                    dr = dtExperience.Rows[RowIndex];
                    dr.BeginEdit();
                    //dr[0] = "0";
                    dr[2] = txt_Serial.Text;
                    dr[3] = txt_CompanyName.Text.Replace("'", "''");
                    if (txt_JoinDate.SelectedDate.HasValue)
                        dr[4] = Convert.ToDateTime(txt_JoinDate.SelectedDate).ToString(BLL.get_Format(Convert.ToString(Session["ORG_ID"])));
                    else
                        dr[4] = null;
                    dr[5] = txt_JoinSalary.Value;
                    dr[6] = txt_JoinDesc.Text.Replace("'", "''");
                    dr[7] = txt_ReasonRelieve.Text.Replace("'", "''");
                    if (txt_RelieveDate.SelectedDate.HasValue)
                        dr[8] = Convert.ToDateTime(txt_RelieveDate.SelectedDate).ToString(BLL.get_Format(Convert.ToString(Session["ORG_ID"])));
                    else
                        dr[8] = null;
                    dr[9] = txt_RelSalary.Value;
                    dr[10] = txt_RelDesc.Text.Replace("'", "''");
                    dr.EndEdit();

                    //dr1[2] = txt_Serial.Text;
                    //dr1[3] = txt_CompanyName.Text.Replace("'", "''");
                    //dr1[4] = Convert.ToDateTime(txt_JoinDate.SelectedDate).ToString(BLL.get_Format(Convert.ToString(Session["ORG_ID"])));
                    //dr1[5] = txt_JoinSalary.Value;
                    //dr1[6] = txt_JoinDesc.Text.Replace("'", "''");
                    //dr1[7] = txt_ReasonRelieve.Text.Replace("'", "''");
                    //dr1[8] = Convert.ToDateTime(txt_RelieveDate.SelectedDate).ToString(BLL.get_Format(Convert.ToString(Session["ORG_ID"])));
                    //dr1[9] = txt_RelSalary.Value;
                    //dr1[10] = txt_RelDesc.Text.Replace("'", "''");
                    ////dr1[11] = lbl_Rand.Text + "-" + txt_Serial.Text;
                    //dtExperience.Rows.Add(dr1);
                }
                else
                {
                    for (int index = 0; index < dtExperience.Rows.Count; index++)
                    {
                        //if (dtExperience.Rows[index].Equals(dr1))
                        //    RowIndex = index;
                        if (dtExperience.Rows[index][1].ToString() == txt_Serial.Text)
                            RowIndex = index;
                    }
                    dr = dtExperience.Rows[RowIndex];
                    dr.BeginEdit();
                    //dr[0] = "0";
                    dr[1] = txt_Serial.Text;
                    dr[2] = txt_CompanyName.Text.Replace("'", "''");
                    if (txt_JoinDate.SelectedDate.HasValue)
                        dr[3] = Convert.ToDateTime(txt_JoinDate.SelectedDate).ToString(BLL.get_Format(Convert.ToString(Session["ORG_ID"])));
                    else
                        dr[3] = null;
                    dr[4] = txt_JoinSalary.Value;
                    dr[5] = txt_JoinDesc.Text.Replace("'", "''");
                    dr[6] = txt_ReasonRelieve.Text.Replace("'", "''");
                    if (txt_RelieveDate.SelectedDate.HasValue)
                        dr[7] = Convert.ToDateTime(txt_RelieveDate.SelectedDate).ToString(BLL.get_Format(Convert.ToString(Session["ORG_ID"])));
                    else
                        dr[7] = null;
                    dr[8] = txt_RelSalary.Value;
                    dr[9] = txt_RelDesc.Text.Replace("'", "''");
                    dr.EndEdit();
                }
                RG_Experience.DataSource = dtExperience;
                RG_Experience.DataBind();
                clearExpFields();
                btn_Exp_Add.Visible = true;
                Mode = 0;
                btn_Exp_Correct.Visible = false;
                int expSerial = getExpSerial();
                txt_Serial.Text = Convert.ToString(expSerial);
            }
            else
            {
                _obj_smhr_applicant = new SMHR_APPLICANT();
                bool status = false;
                _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                _obj_smhr_applicant.APPEXP_ID = Convert.ToInt32(_lbl_ID);
                _obj_smhr_applicant.APPEXP_SERIAL = Convert.ToInt32(txt_Serial.Text);
                _obj_smhr_applicant.APPEXP_COMPANY = Convert.ToString(txt_CompanyName.Text.Replace("'", "''"));
                if (txt_JoinDate.SelectedDate.HasValue)
                    _obj_smhr_applicant.APPEXP_JOINDATE = Convert.ToDateTime(txt_JoinDate.SelectedDate.Value);
                else
                    _obj_smhr_applicant.APPEXP_JOINDATE = null;
                if (txt_JoinSalary.Text != string.Empty)
                    _obj_smhr_applicant.APPEXP_JOINSAL = Convert.ToDouble(txt_JoinSalary.Value);
                else
                    _obj_smhr_applicant.APPEXP_JOINSAL = 0.0;
                _obj_smhr_applicant.APPEXP_JOINDESC = Convert.ToString(txt_JoinDesc.Text.Replace("'", "''"));
                _obj_smhr_applicant.APPEXP_REASONREL = Convert.ToString(txt_ReasonRelieve.Text.Replace("'", "''"));
                if (txt_RelieveDate.SelectedDate.HasValue)
                    _obj_smhr_applicant.APPEXP_RELDATE = Convert.ToDateTime(txt_RelieveDate.SelectedDate.Value);
                else
                    _obj_smhr_applicant.APPEXP_RELDATE = null;
                if (txt_RelSalary.Text != string.Empty)
                    _obj_smhr_applicant.APPEXP_RELSAL = Convert.ToDouble(txt_RelSalary.Value);
                else
                    _obj_smhr_applicant.APPEXP_RELSAL = 0.0;
                _obj_smhr_applicant.APPEXP_REASONDESC = Convert.ToString(txt_RelDesc.Text.Replace("'", "''"));
                //_obj_smhr_applicant.APPEXP_LASTMDFBY = 1;
                _obj_smhr_applicant.APPEXP_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_smhr_applicant.APPEXP_LASTMDFDATE = Convert.ToString(DateTime.Now);
                _obj_smhr_applicant.OPERATION = operation.Update;
                status = BLL.set_ApplicantExperience(_obj_smhr_applicant);
                Mode = 2;
                clearExpFields();
                LoadExperience();
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Con_Correct_Click(object sender, EventArgs e)
    {
        try
        {
            if (Mode == 1)
            {
                dt_Contact = (DataTable)ViewState["dt_Contact"];
                DataRow dr;
                DataRow dr1 = dt_Contact.Rows.Find(txt_Serail_C.Text);
                int RowIndex = 0;
                for (int index = 0; index < dt_Contact.Rows.Count; index++)
                {
                    if (dt_Contact.Rows[index].Equals(dr1))
                        RowIndex = index;
                }
                dr = dt_Contact.Rows[RowIndex];
                dr.BeginEdit();
                dr[0] = "0";
                dr[1] = txt_Serail_C.Text;
                dr[2] = txt_Company_C.Text.Replace("'", "''");
                dr[3] = txt_ContactName.Text.Replace("'", "''");
                dr[4] = txt_PhoneNumber.Text.Replace("'", "''");
                dr[5] = txt_Address_C.Text.Replace("'", "''");
                dr.EndEdit();
                RG_Contact.DataSource = dt_Contact;
                RG_Contact.DataBind();
                clearConFields();
                Mode = 0;
                int conSerial = getContactSerial();
                txt_Serail_C.Text = Convert.ToString(conSerial);
                btn_Con_Add.Visible = true;
                btn_Con_Correct.Visible = false;
            }
            else
            {
                _obj_smhr_applicant = new SMHR_APPLICANT();
                bool status = false;
                _obj_smhr_applicant.OPERATION = operation.Update;
                _obj_smhr_applicant.APPCONT_ID = Convert.ToInt32(_lbl_ID);
                _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                _obj_smhr_applicant.APPCONT_SERIAL = Convert.ToInt32(txt_Serail_C.Text.Replace("'", "''"));
                _obj_smhr_applicant.APPCONT_COMPANY = Convert.ToString(txt_Company_C.Text.Replace("'", "''"));
                _obj_smhr_applicant.APPCONT_CONTACT = Convert.ToString(txt_ContactName.Text.Replace("'", "''"));
                _obj_smhr_applicant.APPCONT_PHONE = Convert.ToString(txt_PhoneNumber.Text.Replace("'", "''"));
                _obj_smhr_applicant.APPCONT_ADDRESS = Convert.ToString(txt_Address_C.Text.Replace("'", "''"));
                // _obj_smhr_applicant.APPCONT_LASTMDFBY = 1;
                _obj_smhr_applicant.APPCONT_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_smhr_applicant.APPCONT_LASTMDFDATE = DateTime.Now;
                status = BLL.set_ApplicantContact(_obj_smhr_applicant);
                clearConFields();
                Mode = 2;
                LoadContact();
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Lang_Correct_Click(object sender, EventArgs e)
    {
        try
        {
            // btn_Lang_Add.Visible = false;
            if (Mode == 1)
            {
                if (chk_Read.Checked == false && chk_Speak.Checked == false &&
                            chk_Understand.Checked == false && chk_Write.Checked == false)
                {
                    BLL.ShowMessage(this, "Please Check atleast one mode");
                    return;
                }
                dtLanguage = (DataTable)ViewState["dtLanguage"];
                DataRow dr;
                //DataRow dr1 = dtLanguage.Rows.Find(ddl_Language.SelectedValue);
                int RowIndex = 0;
                if (dtLanguage.Columns.Count > 8)
                {
                    for (int index = 0; index < dtLanguage.Rows.Count; index++)
                    {
                        if (dtLanguage.Rows[index][2].ToString() == ddl_Language.SelectedValue)
                            RowIndex = index;
                    }
                    dr = dtLanguage.Rows[RowIndex];
                    dr.BeginEdit();
                    //dr[2] = ddl_Language.SelectedValue;
                    dr[2] = ddl_Language.SelectedValue;
                    dr[3] = ddl_Language.SelectedItem.Text;
                    if (chk_Read.Checked)
                        dr[4] = true;
                    else
                        dr[4] = false;
                    if (chk_Write.Checked)
                        dr[5] = true;
                    else
                        dr[5] = false;
                    if (chk_Speak.Checked)
                        dr[6] = true;
                    else
                        dr[6] = false;
                    if (chk_Understand.Checked)
                        dr[7] = true;
                    else
                        dr[7] = false;
                    dr.EndEdit();

                    //DataRow dr1 = dtLanguage.NewRow();
                    ////dr[0] = "0";
                    //dr1[2] = ddl_Language.SelectedValue;
                    //dr1[3] = ddl_Language.SelectedItem.Text;
                    //if (chk_Read.Checked)
                    //    dr1[4] = true;
                    //else
                    //    dr1[4] = false;
                    //if (chk_Write.Checked)
                    //    dr1[5] = true;
                    //else
                    //    dr1[5] = false;
                    //if (chk_Speak.Checked)
                    //    dr1[6] = true;
                    //else
                    //    dr1[6] = false;
                    //if (chk_Understand.Checked)
                    //    dr1[7] = true;
                    //else
                    //    dr1[7] = false;
                    ////dr1[7] = lbl_Rand.Text + "-" + dtLanguage.Rows.Count;
                    //dtLanguage.Rows.Add(dr1);
                }
                else
                {
                    for (int index = 0; index < dtLanguage.Rows.Count; index++)
                    {
                        if (dtLanguage.Rows[index][1].ToString() == ddl_Language.SelectedValue)
                            RowIndex = index;
                    }
                    dr = dtLanguage.Rows[RowIndex];
                    dr.BeginEdit();
                    //dr[0] = ddl_Language.SelectedValue;
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
                }
                RG_Language.DataSource = dtLanguage;
                RG_Language.DataBind();
                //clearLangFields();
                Mode = 0;
                btn_Lang_Add.Visible = true;
                btn_Lang_Correct.Visible = false;
                ddl_Language.Enabled = true;
            }
            else
            {
                if (chk_Read.Checked == false && chk_Speak.Checked == false &&
                            chk_Understand.Checked == false && chk_Write.Checked == false)
                {
                    BLL.ShowMessage(this, "Please Check atleast one mode");
                    return;
                }
                _obj_smhr_applicant = new SMHR_APPLICANT();
                bool status = false;
                _obj_smhr_applicant.OPERATION = operation.Update;
                _obj_smhr_applicant.APPLAN_ID = Convert.ToInt32(_lbl_ID);
                if (_obj_smhr_applicant.APPLAN_ID == null || _obj_smhr_applicant.APPLAN_ID == 0)
                {
                    if (_obj_smhr_applicant.APPLAN_ID == null)
                    {
                        BLL.ShowMessage(this, "Please select applicant");
                        return;
                    }
                    else
                    {
                        BLL.ShowMessage(this, "There is no applicant exists to update this record...");
                        return;
                    }
                }

                _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value);//Convert.ToInt32(_lbl_App_ID);
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
                //_obj_smhr_applicant.APPLAN_LASTMDFBY = 1;
                _obj_smhr_applicant.APPLAN_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_smhr_applicant.APPLAN_LASTMDFDATE = DateTime.Now;
                status = BLL.set_ApplicantLanguage(_obj_smhr_applicant);
                clearLangFields();
                Mode = 2;
                LoadLanguage();
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Qual_Correct_Click(object sender, EventArgs e)
    {
        try
        {
            if (Mode == 1) //New Edit
            {
                dt_Qual = (DataTable)ViewState["dt_Qual"];
                DataRow dr;
                //DataRow dr1 = dt_Qual.Rows.Find(ddl_Category.SelectedValue);
                int RowIndex = 0;
                if (dt_Qual.Columns.Count > 8)
                {
                    for (int index = 0; index < dt_Qual.Rows.Count; index++)
                    {
                        //if (dt_Qual.Rows[index].Equals(dr1))
                        if (dt_Qual.Rows[index][2].ToString() == ddl_Category.SelectedValue)
                            RowIndex = index;
                    }
                    dr = dt_Qual.Rows[RowIndex];
                    dr.BeginEdit();
                    // dr[0] = "0";
                    dr[2] = ddl_Category.SelectedValue;
                    dr[3] = ddl_Category.SelectedItem.Text;
                    dr[4] = txt_Institute.Text.Replace("'", "''");
                    dr[5] = txt_YearofPass.Value;
                    dr[6] = txt_Percentage.Value;
                    dr[7] = ddl__Grade.SelectedItem.Text;
                    dr.EndEdit();
                }
                else
                {
                    for (int index = 0; index < dt_Qual.Rows.Count; index++)
                    {
                        //if (dt_Qual.Rows[index].Equals(dr1))
                        if (dt_Qual.Rows[index][1].ToString() == ddl_Category.SelectedValue)
                            RowIndex = index;
                    }
                    dr = dt_Qual.Rows[RowIndex];
                    dr.BeginEdit();
                    // dr[0] = "0";
                    dr[1] = ddl_Category.SelectedValue;
                    dr[2] = ddl_Category.SelectedItem.Text;
                    dr[3] = txt_Institute.Text.Replace("'", "''");
                    dr[4] = txt_YearofPass.Value;
                    dr[5] = txt_Percentage.Value;
                    /*added by anusha 05/06/2015*/
                    if (ddl__Grade.SelectedItem.Text == "Select")
                    {
                        dr[6] = string.Empty;
                    }
                    else
                    {
                        dr[6] = ddl__Grade.SelectedItem.Text;
                    }
                    dr.EndEdit();
                }
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
                _obj_smhr_applicant.APPQFN_ID = Convert.ToInt32(_lbl_ID);
                _obj_smhr_applicant.APPQFN_QUALIFICATION_ID = Convert.ToInt32(ddl_Category.SelectedValue);
                _obj_smhr_applicant.APPQFN_INSTITUTE = Convert.ToString(txt_Institute.Text.Replace("'", "''"));
                _obj_smhr_applicant.APPQFN_PASSEDYEAR = Convert.ToInt32(txt_YearofPass.Value);
                if (string.IsNullOrEmpty(Convert.ToString(txt_Percentage.Value)))
                {
                    _obj_smhr_applicant.APPQFN_PERCENTAGE = 0;
                }
                else
                {
                    _obj_smhr_applicant.APPQFN_PERCENTAGE = Convert.ToDouble(Convert.ToString(txt_Percentage.Value));
                }
                _obj_smhr_applicant.APPQFN_GRADE = Convert.ToString(ddl__Grade.SelectedItem.Value) == "0" ? "" : Convert.ToString(ddl__Grade.SelectedItem.Value);
                //_obj_smhr_applicant.APPQFN_LASTMDFBY = 1;
                _obj_smhr_applicant.APPQFN_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_smhr_applicant.APPQFN_LASTMDFDATE = DateTime.Now;
                _obj_smhr_applicant.OPERATION = operation.Update;
                status = BLL.set_AppQualification(_obj_smhr_applicant);
                Mode = 2;
                LoadQualification();
                clearQualFields();
                ddl_Category.Enabled = true;

            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
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
                //DataRow dr1 = dt_Skill.Rows.Find(rcb_Skill.SelectedValue);
                int RowIndex = 0;
                if (dt_Skill.Columns.Count > 7)
                {
                    for (int index = 0; index < dt_Skill.Rows.Count; index++)
                    {
                        //if (dt_Skill.Rows[index].Equals(dr1))
                        //RowIndex = index;
                        if (dt_Skill.Rows[index][2].ToString() == rcb_Skill.SelectedValue)
                            RowIndex = index;
                    }
                    dr = dt_Skill.Rows[RowIndex];
                    dr.BeginEdit();
                    //dr[0] = "0";
                    dr[2] = rcb_Skill.SelectedValue;
                    dr[5] = rcb_Skill.SelectedItem.Text;
                    dr[6] = rcb_YearLastUsed.SelectedItem.Text;
                    dr[3] = rcb_ExpertLevel.SelectedValue;
                    dr[4] = rcb_ExpertLevel.SelectedItem.Text;
                    dr.EndEdit();

                }
                else
                {
                    for (int index = 0; index < dt_Skill.Rows.Count; index++)
                    {
                        //if (dt_Skill.Rows[index].Equals(dr1))
                        //RowIndex = index;
                        if (dt_Skill.Rows[index][1].ToString() == rcb_Skill.SelectedValue)
                            RowIndex = index;
                    }
                    dr = dt_Skill.Rows[RowIndex];
                    dr.BeginEdit();
                    //dr[0] = "0";
                    dr[1] = rcb_Skill.SelectedValue;
                    dr[2] = rcb_Skill.SelectedItem.Text;
                    dr[3] = rcb_YearLastUsed.SelectedItem.Text;
                    dr[4] = rcb_ExpertLevel.SelectedValue;
                    dr[5] = rcb_ExpertLevel.SelectedItem.Text;
                    dr.EndEdit();

                }
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
                _obj_smhr_applicant.APPSKL_ID = Convert.ToInt32(_lbl_ID);
                _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                _obj_smhr_applicant.APPSKL_SKILL_ID = Convert.ToInt32(rcb_Skill.SelectedItem.Value);
                _obj_smhr_applicant.APPSKL_LASTUSED = Convert.ToInt32(rcb_YearLastUsed.SelectedItem.Text);
                _obj_smhr_applicant.APPSKL_EXPERT = Convert.ToInt32(rcb_ExpertLevel.SelectedValue);
                //_obj_smhr_applicant.APPSKL_LASTMDFBY = 1;
                _obj_smhr_applicant.APPSKL_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_smhr_applicant.APPSKL_LASTMDFDATE = DateTime.Now;
                status = BLL.set_ApplicantSkills(_obj_smhr_applicant);
                Mode = 2;
                LoadSkill();
                clearSkillFields();
                rcb_Skill.Enabled = true;
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
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
                for (int index = 0; index < dtReference.Rows.Count; index++)
                {
                    if (dtReference.Rows[index].Equals(dr1))
                        RowIndex = index;
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
                Mode = 0;
                clearRefFields();
            }
            else
            {
                _obj_smhr_applicant = new SMHR_APPLICANT();
                bool status = false;
                _obj_smhr_applicant.OPERATION = operation.Update;
                _obj_smhr_applicant.APPREF_ID = Convert.ToInt32(_lbl_ID);
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
                Mode = 1;
                LoadReference();
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Fam_Correct_Click(object sender, EventArgs e)
    {
        try
        {
            if ((chkDeptAlwnce.Checked || chkEduAlwnce.Checked || chkMedAlwnce.Checked) &&
                (Convert.ToString(Request.QueryString["EID"]) == string.Empty || Convert.ToString(Request.QueryString["EID"]) == null))
            {
                BLL.ShowMessage(this, "Please create employee and then add the family details for checking allowances radio buttons");
                return;
            }
            if (chkDeptAlwnce.Checked)
            {
                SMHR_EMPLOYEE _obj_SMHR_EMPLOYEE = new SMHR_EMPLOYEE();

                _obj_SMHR_ALLOWANCE.OPERATION = operation.Check;
                _obj_SMHR_ALLOWANCE.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_SMHR_ALLOWANCE.ALLOWANCE_PERIOD_ID = Convert.ToInt32(rcmb_Period.SelectedValue);
                _obj_SMHR_ALLOWANCE.ALLOWANCE_EMPLOYEEGRADE_ID = Convert.ToInt32(ddl_Grade.SelectedValue);
                _obj_SMHR_ALLOWANCE.ALLOWANCE_CONFG_ID = 0; //for Dependent

                DataTable dtDepChk = BLL.GET_ALLOWANCE(_obj_SMHR_ALLOWANCE);

                _obj_SMHR_EMPLOYEE.OPERATION = operation.Check1;
                _obj_SMHR_EMPLOYEE.EMP_ID = Convert.ToInt32(Request.QueryString["EID"]);
                _obj_SMHR_EMPLOYEE.EMP_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_SMHR_EMPLOYEE.EMPFMDTL_ID = empFamilyDetailID;

                DataTable dtEmpFmlyChk = BLL.get_EmployeeFamily(_obj_SMHR_EMPLOYEE);

                //if (Convert.ToInt32(dtDepChk.Rows[0]["ALLOWANCE_ELIGIBLE"]) < (Convert.ToInt32(dtEmpFmlyChk.Rows[0]["COUNT"]) + 1))
                //{
                //    BLL.ShowMessage(this, "Max no. of Dependents related to Employee grade & financial year is exceeded..!");
                //    return;
                //}
                if (dtDepChk.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtDepChk.Rows[0]["ALLOWANCE_ELIGIBLE"]) < (Convert.ToInt32(dtEmpFmlyChk.Rows[0]["COUNT"]) + 1))
                    {
                        BLL.ShowMessage(this, "Max no. of Dependents for this financial year is exceeded..!");
                        return;
                    }
                }
                else
                {
                    BLL.ShowMessage(this, "No values are defined for Dependent allowances in payitem screen");
                    chkDeptAlwnce.Checked = false;
                    return;
                }
            }
            if (chkEduAlwnce.Checked)
            {
                SMHR_EMPLOYEE _obj_SMHR_EMPLOYEE = new SMHR_EMPLOYEE();

                _obj_SMHR_ALLOWANCE.OPERATION = operation.Check;
                _obj_SMHR_ALLOWANCE.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_SMHR_ALLOWANCE.ALLOWANCE_PERIOD_ID = Convert.ToInt32(rcmb_Period.SelectedValue);
                _obj_SMHR_ALLOWANCE.ALLOWANCE_EMPLOYEEGRADE_ID = Convert.ToInt32(ddl_Grade.SelectedValue);
                _obj_SMHR_ALLOWANCE.ALLOWANCE_CONFG_ID = 1; //for Education 

                DataTable dtDepChk = BLL.GET_ALLOWANCE(_obj_SMHR_ALLOWANCE);

                _obj_SMHR_EMPLOYEE.OPERATION = operation.Check2;
                _obj_SMHR_EMPLOYEE.EMP_ID = Convert.ToInt32(Request.QueryString["EID"]);
                _obj_SMHR_EMPLOYEE.EMP_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_SMHR_EMPLOYEE.EMPFMDTL_ID = empFamilyDetailID;

                DataTable dtEmpFmlyChk = BLL.get_EmployeeFamily(_obj_SMHR_EMPLOYEE);

                if (dtDepChk.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtDepChk.Rows[0]["ALLOWANCE_ELIGIBLE"]) < (Convert.ToInt32(dtEmpFmlyChk.Rows[0]["COUNT"]) + 1))
                    {
                        BLL.ShowMessage(this, "Max no. of Dependents for this financial year is exceeded..!");
                        return;
                    }
                }
                else
                {
                    BLL.ShowMessage(this, "No values are defined for Dependent allowances in payitem screen");
                    chkDeptAlwnce.Checked = false;
                    return;
                }
                /*if (4 < (Convert.ToInt32(dtEmpFmlyChk.Rows[0]["COUNT"]) + 1))   //Convert.ToInt32(dtDepChk.Rows[0]["ALLOWANCE_ELIGIBLE"])
                {
                    BLL.ShowMessage(this, "Only 4 dependents are entitled for Education Allowance");
                    return;
                }*/
            }

            if (Mode == 1)
            {
                dtFamily = (DataTable)ViewState["dtFamily"];
                DataRow dr;
                DataRow dr1 = dtFamily.Rows.Find(txt_FSerial.Text);
                int RowIndex = 0;
                for (int index = 0; index < dtFamily.Rows.Count; index++)
                {
                    if (dtFamily.Rows[index].Equals(dr1))
                        RowIndex = index;
                }
                if (dtFamily.Rows.Count > 0)
                {
                    //EMPFMDTL_EMPREL_NAME
                    DataRow[] drfilter;
                    /*if (string.Compare(ddlRelation.SelectedItem.Text.ToLower(), "son", true) == 0 || string.Compare(ddlRelation.SelectedItem.Text.ToLower(), "daughter", true) == 0)
                    {
                        drfilter = dtFamily.Select("EMPFMDTL_EMPREL_NAME in ('son','daughter')");
                        if (drfilter.Length == 4)
                        {
                            BLL.ShowMessage(this, "only four son/daughters can delcare");
                            btn_Fam_Add.Enabled = true;
                            return;
                        }
                    }
                    //validation pending for same relation
                    drfilter = dtFamily.Select("EMPFMDTL_EMPREL_NAME='" + ddlRelation.SelectedItem.Text.ToLower() + "'");
                    if (string.Compare(drfilter[0]["EMPFMDTL_SERIAL"].ToString(), txt_FSerial.Text, true) != 0 && drfilter.Length == 1)
                    {
                        BLL.ShowMessage(this, "Dependent already declared");
                        btn_Fam_Add.Enabled = true;
                        return;
                    }*/
                }
                dr = dtFamily.Rows[RowIndex];
                dr.BeginEdit();

                dr[0] = "0";
                dr[1] = txt_FSerial.Text.ToString().Trim();
                dr[2] = ddlRelation.SelectedValue.ToString().Trim();
                dr[3] = Convert.ToString(ddlRelation.SelectedItem.Text);
                dr[4] = Convert.ToString(radSurName.Text);
                dr[5] = Convert.ToString(txt_Name.Text);

                if (string.Compare(ddlRelation.SelectedItem.Text.ToLower(), "spouse", true) != 0)
                {
                    if (txt_FDOB.SelectedDate == null)
                    {
                        BLL.ShowMessage(this, "please select dependent DOB");
                        btn_Fam_Add.Enabled = true;
                        return;
                    }
                    dr[6] = Convert.ToDateTime(txt_FDOB.SelectedDate.Value).ToString(BLL.get_Format(Convert.ToString(Session["ORG_ID"])));

                }

                if (chk_EmergencyCont.Checked)
                    dr[7] = true;
                else
                    dr[7] = false;
                dr[8] = lbl_Rand.Text + "-" + txt_FSerial.Text.ToString().Trim();
                if (FBrowsePhoto.HasFile)
                {
                    string imagename = txt_Name.Text + "_" + Guid.NewGuid().ToString() + "_FIMG" + FBrowsePhoto.FileName;
                    string strPath = "~/EmpUploads/" + imagename;
                    FBrowsePhoto.PostedFile.SaveAs(Server.MapPath("~/EmpUploads/") + imagename);
                    dr[9] = strPath;
                }
                if (FBioData.HasFile)
                {
                    string pdfName = txt_Name.Text + "_" + Guid.NewGuid().ToString() + "_FBIO" + FBioData.FileName;
                    string strPath = "~/EmpUploads/" + pdfName;
                    FBioData.PostedFile.SaveAs(Server.MapPath("~/EmpUploads/") + pdfName);
                    dr[10] = strPath;
                }
                if (FBioMetricData.HasFile)
                {
                    string pdfName = txt_Name.Text + "_" + Guid.NewGuid().ToString() + "_FBIOMETRIC" + FBioMetricData.FileName;
                    string strPath = "~/EmpUploads/" + pdfName;
                    FBioMetricData.PostedFile.SaveAs(Server.MapPath("~/EmpUploads/") + pdfName);
                    dr[11] = strPath;
                }
                dr.EndEdit();
                RG_Family.DataSource = dtFamily;
                RG_Family.DataBind();
                clearFamilyFields();
                int Serial = getFamilySerial();
                Mode = 0;
                txt_FSerial.Text = Convert.ToString(Serial);
            }
            else
            {
                if (RG_Family.Items.Count > 0)
                {
                    Label lbRel; int count = 0; Label relID;
                    foreach (GridDataItem r in RG_Family.Items)
                    {
                        lbRel = new Label();
                        lbRel = (Label)r.FindControl("lbl_Relation");
                        relID = new Label();
                        relID = (Label)r.FindControl("lblID");

                        if (string.Compare(lbRel.Text.ToLower(), "son", true) == 0 || string.Compare(lbRel.Text.ToLower(), "daughter", true) == 0)
                        {
                            if (string.Compare(_lbl_ID, relID.Text, true) != 0)
                                count++;
                        }
                        /*else if (string.Compare(_lbl_ID, relID.Text, true) != 0 && string.Compare(lbRel.Text.ToLower(), ddlRelation.SelectedItem.Text.ToLower(), true) == 0)
                        {
                            BLL.ShowMessage(this, "Dependent already declared");
                            btn_Fam_Add.Enabled = true;
                            return;
                        }*/
                    }
                    /*if (count == 4 && (string.Compare(ddlRelation.Text.ToLower(), "son", true) == 0 || string.Compare(ddlRelation.Text.ToLower(), "daughter", true) == 0) && string.Compare(ddlRelation.SelectedValue, _lbl_ID, true) != 0)
                    {
                        BLL.ShowMessage(this, "only four son/daughters can delcare");
                        btn_Fam_Add.Enabled = true;
                        return;
                    }*/
                }
                bool status = false;
                _obj_smhr_employee = new SMHR_EMPLOYEE();
                _obj_smhr_employee.OPERATION = operation.Update;
                _obj_smhr_employee.EMPFMDTL_ID = empFamilyDetailID; //Convert.ToInt32(_lbl_ID);
                _obj_smhr_employee.EMPFMDTL_EMP_ID = Convert.ToInt32(HF_EMPID.Value); //Convert.ToInt32(_lbl_Emp_ID);
                _obj_smhr_employee.EMPFMDTL_SERIAL = Convert.ToInt32(txt_FSerial.Text);
                _obj_smhr_employee.EMPFMDTL_EMPREL_ID = Convert.ToInt32(ddlRelation.SelectedValue);
                _obj_smhr_employee.EMPFMDTL_EMPREL_NAME = ddlRelation.SelectedItem.Text;
                _obj_smhr_employee.EMPFMDTL_SURNAME = radSurName.Text;
                _obj_smhr_employee.EMPFMDTL_NAME = Convert.ToString(txt_Name.Text);
                _obj_smhr_employee.EMPFMDTL_IS_DEP = Convert.ToBoolean(chkDeptAlwnce.Checked);
                _obj_smhr_employee.EMPFMDTL_IS_EDU = Convert.ToBoolean(chkEduAlwnce.Checked);
                _obj_smhr_employee.EMPFMDTL_IS_MED = Convert.ToBoolean(chkMedAlwnce.Checked);
                if (string.Compare(ddlRelation.SelectedItem.Text.ToLower(), "spouse", true) != 0)
                {
                    if (txt_FDOB.SelectedDate == null)
                    {
                        BLL.ShowMessage(this, "please select dependent DOB");
                        btn_Fam_Add.Enabled = true;
                        return;
                    }
                    _obj_smhr_employee.EMPFMDTL_RELDOB = Convert.ToDateTime(txt_FDOB.SelectedDate.Value);
                }
                if (chk_EmergencyCont.Checked)
                    _obj_smhr_employee.EMPFMDTL_EMERGENCYCONTACT = true;
                else
                    _obj_smhr_employee.EMPFMDTL_EMERGENCYCONTACT = false;

                //   _obj_smhr_employee.EMPFMDTL_LASTMDFBY = 1;
                _obj_smhr_employee.EMPFMDTL_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_smhr_employee.EMPFMDTL_LASTMDFDATE = DateTime.Now;


                if (FBrowsePhoto.HasFile)
                {
                    string imagename = txt_Name.Text + "_" + Guid.NewGuid().ToString() + "_FIMG" + FBrowsePhoto.FileName;
                    string strPath = "~/EmpUploads/" + imagename;
                    FBrowsePhoto.PostedFile.SaveAs(Server.MapPath("~/EmpUploads/") + imagename);
                    _obj_smhr_employee.EMPFMDTL_PHOTO = strPath;
                }
                if (FBioData.HasFile)
                {
                    string pdfName = txt_Name.Text + "_" + Guid.NewGuid().ToString() + "_FBIO" + FBioData.FileName;
                    string strPath = "~/EmpUploads/" + pdfName;
                    FBioData.PostedFile.SaveAs(Server.MapPath("~/EmpUploads/") + pdfName);
                    _obj_smhr_employee.EMPFMDTL_BIODATA = strPath;
                }
                if (FBioMetricData.HasFile)
                {
                    string pdfName = txt_Name.Text + "_" + Guid.NewGuid().ToString() + "_FBIOMETRIC" + FBioMetricData.FileName;
                    string strPath = "~/EmpUploads/" + pdfName;
                    FBioMetricData.PostedFile.SaveAs(Server.MapPath("~/EmpUploads/") + pdfName);
                    _obj_smhr_employee.EMPFMDTL_BIOMETRICDOC = strPath;
                }
                Mode = 2;
                status = BLL.set_EmpFamily(_obj_smhr_employee);
                if (status == true)
                {
                    LoadFamily();
                    clearFamilyFields();
                    int Serial = getFamilySerial();
                    txt_FSerial.Text = Convert.ToString(Serial);
                }
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_swp_Correct_Click(object sender, EventArgs e)
    {
        try
        {
            if (Mode == 1)
            {
                dtSwipe = (DataTable)ViewState["dtSwipe"];
                DataRow dr;
                DataRow dr1 = dtSwipe.Rows.Find(txt_SSerial.Text);
                int RowIndex = 0;
                for (int index = 0; index < dtSwipe.Rows.Count; index++)
                {
                    if (dtSwipe.Rows[index].Equals(dr1))
                        RowIndex = index;
                }
                dr = dtSwipe.Rows[RowIndex];
                dr.BeginEdit();
                dr[0] = "0";
                dr[1] = txt_SSerial.Text;
                dr[2] = txt_CardCode.Text;
                dr[3] = Convert.ToDateTime(txt_IssueDate.SelectedDate).ToString(BLL.get_Format(Convert.ToString(Session["ORG_ID"])));
                dr[4] = Convert.ToDateTime(txt_ExpiryDate.SelectedDate).ToString(BLL.get_Format(Convert.ToString(Session["ORG_ID"])));
                dr[5] = txt_SwpRemarks.Text;
                dr.EndEdit();
                Mode = 0;
                RG_Swipe.DataSource = dtSwipe;
                RG_Swipe.DataBind();
                clearSwpFields();
            }
            else
            {
                bool status = false;
                _obj_smhr_employee = new SMHR_EMPLOYEE();
                _obj_smhr_employee.OPERATION = operation.Update;
                _obj_smhr_employee.EMPSWM_ID = Convert.ToInt32(_lbl_ID);
                _obj_smhr_employee.EMPSWM_EMP_ID = Convert.ToInt32(HF_EMPID.Value); //Convert.ToInt32(_lbl_Emp_ID);
                _obj_smhr_employee.EMPSWM_SERIAL = Convert.ToInt32(txt_SSerial.Text);
                _obj_smhr_employee.EMPSWM_CARDCODE = Convert.ToString(txt_CardCode.Text);
                _obj_smhr_employee.EMPSWM_CARDISSUE = Convert.ToDateTime(txt_IssueDate.SelectedDate.Value);
                _obj_smhr_employee.EMPSWM_CARDEXPIRY = Convert.ToDateTime(txt_ExpiryDate.SelectedDate.Value);
                _obj_smhr_employee.EMPSWM_REMARKS = Convert.ToString(txt_SwpRemarks.Text);
                _obj_smhr_employee.EMPSWM_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                Mode = 2;
                _obj_smhr_employee.EMPSWM_CREATEDDATE = DateTime.Now;
                status = BLL.set_EmployeeSwipe(_obj_smhr_employee);
                if (status == true)
                {
                    LoadSwipe();
                    clearSwpFields();
                }
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void btn_OT_Correct_Click(object sender, EventArgs e)
    {
        try
        {
            if (Mode == 1)
            {
                dtOTRate = (DataTable)ViewState["dtOTRate"];
                DataRow dr;
                DataRow dr1 = dtOTRate.Rows.Find(ddl_OTType.SelectedValue);
                int RowIndex = 0;
                for (int index = 0; index < dtOTRate.Rows.Count; index++)
                {
                    if (dtOTRate.Rows[index].Equals(dr1))
                        RowIndex = index;
                }
                dr = dtOTRate.Rows[RowIndex];
                dr.BeginEdit();
                dr[0] = "0";
                dr[1] = ddl_OTType.SelectedValue;
                dr[2] = ddl_OTType.SelectedItem.Text;
                dr[3] = txt_Value.Value;
                dr.EndEdit();
                RG_OTRate.DataSource = dtOTRate;
                RG_OTRate.DataBind();
                clearOTFields();
                Mode = 0;
            }
            else
            {
                bool status = false;
                _obj_smhr_employee = new SMHR_EMPLOYEE();
                _obj_smhr_employee.OPERATION = operation.Update;
                _obj_smhr_employee.EMPOTR_ID = Convert.ToInt32(_lbl_ID);
                _obj_smhr_employee.EMPOTR_EMP_ID = Convert.ToInt32(HF_EMPID.Value); //Convert.ToInt32(_lbl_Emp_ID);
                _obj_smhr_employee.EMPOTR_OTTYPE_ID = Convert.ToInt32(ddl_OTType.SelectedValue);
                _obj_smhr_employee.EMPOTR_OTRATE = Convert.ToDouble(txt_Value.Value);
                _obj_smhr_employee.EMPOTR_LASTMDFBY = 1;
                _obj_smhr_employee.EMPOTR_LASTMDFDATE = DateTime.Now;
                status = BLL.set_EmpOTInfo(_obj_smhr_employee);
                Mode = 2;
                if (status == true)
                {
                    LoadOTInfo();
                    clearOTFields();
                }
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region CancelMethods

    protected void btn_Con_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearConFields();
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Exp_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearExpFields();
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Qual_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearQualFields();
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Skill_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearSkillFields();
            rcb_Skill.Enabled = true;
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Lang_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearLangFields();
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Ref_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearRefFields();
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Fam_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearFamilyFields();
            int Serial = getFamilySerial();
            txt_FSerial.Text = Convert.ToString(Serial);
            //rntxt_Annual.Text = "0.0";
            //rntxt_Annual.Value = 0.0;
            btn_Fam_Add.Enabled = true;
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_swp_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearSwpFields();
            int swpSerial = getSwipeSerial();
            txt_SSerial.Text = Convert.ToString(swpSerial);
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_OT_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearOTFields();
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region ItemCommand

    protected void RG_Qualification_ItemCommand(object source, GridCommandEventArgs e)
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
                    //txt_YearofPass.Value = Convert.ToString(lblYearPass.Text) == "" ? 0 : Convert.ToDouble(lblYearPass.Text);
                    //txt_Percentage.Value = Convert.ToString(lblPercent.Text) == "" ? 0 : Convert.ToDouble(lblPercent.Text);

                    if (Convert.ToString(lblYearPass.Text) == "" || Convert.ToString(lblYearPass.Text) == "0")
                    {
                        txt_YearofPass.Value = null;
                    }
                    else
                    {
                        txt_YearofPass.Value = Convert.ToDouble(lblYearPass.Text);
                    }

                    if (Convert.ToString(lblPercent.Text) == "" || Convert.ToString(lblPercent.Text) == "0")
                    {
                        txt_Percentage.Value = null;
                    }
                    else
                    {
                        txt_Percentage.Value = Convert.ToDouble(lblPercent.Text);
                    }
                    ddl__Grade.SelectedIndex = ddl__Grade.FindItemIndexByValue(lblGrade.Text);
                    Mode = 1;
                    ddl_Category.Enabled = false;
                    btn_Qual_Add.Visible = false;
                    //code for security
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
                    _lbl_ID = Convert.ToString(lbl_ID.Text);
                    txt_Institute.Text = Convert.ToString(lblInstitute.Text);
                    //txt_YearofPass.Value = Convert.ToDouble(lblYearPass.Text);
                    //txt_Percentage.Value = Convert.ToDouble(lblPercent.Text);
                    //txt_YearofPass.Value = Convert.ToString(lblYearPass.Text) == "" ? 0 : Convert.ToDouble(lblYearPass.Text);
                    if (Convert.ToString(lblYearPass.Text) == "" || Convert.ToString(lblYearPass.Text) == "0")
                    {
                        txt_YearofPass.Value = null;
                    }
                    else
                    {
                        txt_YearofPass.Value = Convert.ToDouble(lblYearPass.Text);
                    }

                    if (Convert.ToString(lblPercent.Text) == "" || Convert.ToString(lblPercent.Text) == "0")
                    {
                        txt_Percentage.Value = null;
                    }
                    else
                    {
                        txt_Percentage.Value = Convert.ToDouble(lblPercent.Text);
                    }
                    //txt_Percentage.Value = Convert.ToString(lblPercent.Text) == "" ? 0 : Convert.ToDouble(lblPercent.Text);

                    ddl__Grade.SelectedIndex = ddl__Grade.FindItemIndexByValue(lblGrade.Text);
                    ddl_Category.Enabled = false;
                    Mode = 2;
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
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
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
                    rcb_YearLastUsed.SelectedIndex = rcb_YearLastUsed.FindItemIndexByText(lblLastUsed.Text);
                    //rcb_ExpertLevel.SelectedItem.Text = Convert.ToString(lbl_ExpertID.Text).Trim();
                    rcb_ExpertLevel.SelectedIndex = Convert.ToInt32(lbl_ExpertID.Text);

                    btn_Skill_Add.Visible = false;
                    if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                    {
                        btn_Skill_Correct.Visible = false;

                    }

                    else
                    {
                        btn_Skill_Correct.Visible = true;
                    }

                    rcb_Skill.Enabled = false;
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
                    rcb_YearLastUsed.SelectedIndex = rcb_YearLastUsed.FindItemIndexByText(lblLastUsed.Text);
                    rcb_ExpertLevel.SelectedValue = Convert.ToString(lbl_ExpertID.Text).Trim();
                    _lbl_ID = lbl_ID.Text;
                    btn_Skill_Add.Visible = false;


                    if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                    {
                        btn_Skill_Correct.Visible = false;

                    }

                    else
                    {
                        btn_Skill_Correct.Visible = true;
                    }
                    rcb_Skill.Enabled = false;
                    Mode = 2;
                }
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
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
                    //txt_JoinDate.SelectedDate = Convert.ToDateTime(lblJDate.Text);
                    if (lblJDate.Text != string.Empty)
                        txt_JoinDate.SelectedDate = DateTime.ParseExact(lblJDate.Text, Convert.ToString(Session["DATE_FORMAT"]), System.Globalization.CultureInfo.CurrentCulture);
                    else
                        txt_JoinDate.SelectedDate = null;
                    if (lblJSal.Text != string.Empty)
                        txt_JoinSalary.Value = Convert.ToDouble(lblJSal.Text);
                    else
                        txt_JoinSalary.Text = string.Empty;
                    txt_JoinDesc.Text = lblJdesc.Text;
                    txt_ReasonRelieve.Text = lblRDesc.Text;
                    if (lblRSal.Text != string.Empty)
                        txt_RelSalary.Value = Convert.ToDouble(lblRSal.Text);
                    else
                        txt_RelSalary.Text = string.Empty;
                    //txt_RelieveDate.SelectedDate = Convert.ToDateTime(lblRDate.Text);
                    if (lblRDate.Text != string.Empty)
                        txt_RelieveDate.SelectedDate = DateTime.ParseExact(lblRDate.Text, Convert.ToString(Session["DATE_FORMAT"]), System.Globalization.CultureInfo.CurrentCulture);
                    else
                        txt_RelieveDate.SelectedDate = null;
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
                if (e.CommandName == "Edit_Rec")
                {
                    GridDataItem dtItem = (GridDataItem)e.Item;
                    int index = dtItem.ItemIndex;

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

                    _lbl_ID = lblID.Text;
                    txt_Serial.Text = lblSerial.Text;
                    txt_CompanyName.Text = lblCompany.Text;
                    if (lblJDate.Text != string.Empty)
                        txt_JoinDate.SelectedDate = DateTime.ParseExact(lblJDate.Text, Convert.ToString(Session["DATE_FORMAT"]), System.Globalization.CultureInfo.InvariantCulture);
                    else
                        txt_JoinDate.SelectedDate = null;
                    // txt_JoinDate.SelectedDate = Convert.ToDateTime(lblJDate.Text);
                    if (lblJSal.Text != string.Empty)
                        txt_JoinSalary.Value = Convert.ToDouble(lblJSal.Text);
                    else
                        txt_JoinSalary.Text = string.Empty;
                    txt_JoinDesc.Text = lblJdesc.Text;
                    txt_ReasonRelieve.Text = lblRDesc.Text;
                    if (lblRSal.Text != string.Empty)
                        txt_RelSalary.Value = Convert.ToDouble(lblRSal.Text);
                    else
                        txt_RelSalary.Text = string.Empty;
                    string df = Convert.ToString(Session["DATE_FORMAT"]);
                    if (lblRDate.Text != string.Empty)
                        txt_RelieveDate.SelectedDate = DateTime.ParseExact(lblRDate.Text, Convert.ToString(Session["DATE_FORMAT"]), System.Globalization.CultureInfo.InvariantCulture);
                    else
                        txt_RelieveDate.SelectedDate = null;
                    //txt_RelieveDate.SelectedDate = Convert.ToDateTime(lblRDate.Text);
                    txt_RelDesc.Text = lblDesc.Text;
                    Mode = 2;
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
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
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

                    if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                    {
                        btn_Con_Correct.Visible = false;

                    }

                    else
                    {
                        btn_Con_Correct.Visible = true;
                    }
                    btn_Con_Add.Visible = false;
                }
            }
            else
            {
                if (e.CommandName == "Edit_Rec")
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

                    _lbl_ID = lblID.Text;
                    txt_Serail_C.Text = lblSerial.Text;
                    txt_Company_C.Text = lblCompName.Text;
                    txt_ContactName.Text = lblConPerson.Text;
                    txt_PhoneNumber.Text = lblConPhone.Text;
                    txt_Address_C.Text = lblConAddress.Text;
                    Mode = 2;
                    if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                    {
                        btn_Con_Correct.Visible = false;

                    }

                    else
                    {
                        btn_Con_Correct.Visible = true;
                    }

                    btn_Con_Add.Visible = false;
                }
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
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
                    ddl_Language.Enabled = false;
                    Mode = 1;
                    btn_Lang_Add.Visible = false;
                    if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                    {
                        btn_Lang_Correct.Visible = true;

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
                    ddl_Language.Enabled = false;
                    _lbl_ID = lblID.Text;
                    Mode = 2;
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
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
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
                    _lbl_ID = lbl_ID.Text;
                    ddl_Employee.SelectedIndex = ddl_Employee.FindItemIndexByValue(lblID.Text);
                    ddl_Relationship.SelectedIndex = ddl_Relationship.FindItemIndexByValue(lblRelID.Text);
                    if (chkRef.Checked)
                        chk_Referred.Checked = true;
                    else
                        chk_Referred.Checked = false;
                    Mode = 2;
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
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void RG_Family_ItemCommand(object source, GridCommandEventArgs e)
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
                    Label lblRelID = new Label();
                    Label lblRelName = new Label();
                    Label lblSurname = new Label();
                    Label lblName = new Label();
                    Label lblDOB = new Label();
                    Label lblWifeIDNumber = new Label();
                    Label lblannual = new Label();
                    CheckBox _chkEmergency = new CheckBox();
                    lblSerial = RG_Family.Items[index].FindControl("lbl_Serial") as Label;
                    lblRelID = RG_Family.Items[index].FindControl("lbl_ID") as Label;
                    lblRelName = RG_Family.Items[index].FindControl("lbl_Relation") as Label;
                    lblName = RG_Family.Items[index].FindControl("lbl_Name") as Label;
                    lblSurname = RG_Family.Items[index].FindControl("lbl_Surname") as Label;
                    lblDOB = RG_Family.Items[index].FindControl("lbl_DOB") as Label;
                    lblWifeIDNumber = RG_Family.Items[index].FindControl("lbl_WifeIDNumber") as Label;
                    lblannual = RG_Family.Items[index].FindControl("lbl_Annual") as Label;
                    _chkEmergency = RG_Family.Items[index].FindControl("chk_Emergency") as CheckBox;
                    txt_FSerial.Text = lblSerial.Text;
                    ddlRelation.SelectedIndex = ddlRelation.FindItemIndexByValue(lblRelID.Text);
                    txt_Name.Text = lblName.Text;
                    radSurName.Text = lblSurname.Text;
                    lbl_FDOB.Visible = false;
                    txt_FDOB.Visible = false;
                    if (string.Compare(lblRelName.Text.ToLower(), "spouse", true) == 0)
                    {
                        lbl_FDOB.Visible = false;
                        txt_FDOB.Visible = false;
                        chk_EmergencyCont.Visible = true;
                    }
                    else
                    {
                        lbl_FDOB.Visible = true;
                        chk_EmergencyCont.Visible = false;
                        txt_FDOB.Visible = true;
                        txt_FDOB.SelectedDate = DateTime.ParseExact(lblDOB.Text, "dd/MM/yyyy", null); //Convert.ToDateTime(lblDOB.Text);
                    }

                    if (_chkEmergency.Checked)
                        chk_EmergencyCont.Checked = true;
                    else
                        chk_EmergencyCont.Checked = false;
                    Mode = 1;
                    if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                    {
                        btn_Fam_Correct.Visible = false;

                    }

                    else
                    {
                        btn_Fam_Correct.Visible = true;
                    }
                    btn_Fam_Add.Visible = false;

                }
            }
            else
            {
                if (e.CommandName == "Edit_Rec")
                {
                    GridDataItem dtItem = (GridDataItem)e.Item;
                    int index = dtItem.ItemIndex;
                    Label lblID = new Label();
                    Label lblSerial = new Label();
                    Label lblRelID = new Label();
                    Label lblRelName = new Label();
                    Label lblSurname = new Label();
                    Label lblName = new Label();
                    Label lblDOB = new Label();
                    Label lblWifeIDNumber = new Label();
                    Label lblannual = new Label();
                    CheckBox _chkEmergency = new CheckBox();
                    CheckBox _chkDepAlwnce = new CheckBox();
                    CheckBox _chkEduAlwnce = new CheckBox();
                    CheckBox _chkMedAlwnce = new CheckBox();
                    lblID = RG_Family.Items[index].FindControl("lblID") as Label;
                    lblSerial = RG_Family.Items[index].FindControl("lbl_Serial") as Label;
                    lblRelID = RG_Family.Items[index].FindControl("lbl_ID") as Label;
                    lblRelName = RG_Family.Items[index].FindControl("lbl_Relation") as Label;
                    lblName = RG_Family.Items[index].FindControl("lbl_Name") as Label;
                    lblSurname = RG_Family.Items[index].FindControl("lbl_Surname") as Label;
                    lblDOB = RG_Family.Items[index].FindControl("lbl_DOB") as Label;
                    lblWifeIDNumber = RG_Family.Items[index].FindControl("lbl_WifeIDNumber") as Label;
                    lblannual = RG_Family.Items[index].FindControl("lbl_Annual") as Label;
                    _chkEmergency = RG_Family.Items[index].FindControl("chk_Emergency") as CheckBox;
                    _chkDepAlwnce = RG_Family.Items[index].FindControl("chkDepAlwnce") as CheckBox;
                    _chkEduAlwnce = RG_Family.Items[index].FindControl("chkEduAlwnce") as CheckBox;
                    _chkMedAlwnce = RG_Family.Items[index].FindControl("chkMedAlwnce") as CheckBox;
                    _lbl_ID = lblID.Text;
                    txt_FSerial.Text = lblSerial.Text;
                    ddlRelation.SelectedIndex = ddlRelation.FindItemIndexByValue(lblRelID.Text);
                    txt_Name.Text = lblName.Text;
                    radSurName.Text = lblSurname.Text;
                    lbl_FDOB.Visible = false;
                    txt_FDOB.Visible = false;
                    chk_EmergencyCont.Visible = false;
                    if (string.Compare(lblRelName.Text.ToLower(), "spouse", true) == 0)
                    {
                        lbl_FDOB.Visible = false;
                        txt_FDOB.Visible = false;
                        chk_EmergencyCont.Visible = true;
                    }
                    else
                    {
                        lbl_FDOB.Visible = true;
                        chk_EmergencyCont.Visible = false;
                        txt_FDOB.Visible = true;
                        txt_FDOB.SelectedDate = DateTime.ParseExact(lblDOB.Text, "dd/MM/yyyy", null); //Convert.ToDateTime(lblDOB.Text);
                    }

                    if (_chkEmergency.Checked)
                        chk_EmergencyCont.Checked = true;
                    else
                        chk_EmergencyCont.Checked = false;

                    if (_chkDepAlwnce.Checked)
                        chkDeptAlwnce.Checked = true;
                    else
                        chkDeptAlwnce.Checked = false;

                    if (_chkDepAlwnce.Checked)
                        chkEduAlwnce.Checked = true;
                    else
                        chkEduAlwnce.Checked = false;

                    if (_chkDepAlwnce.Checked)
                        chkMedAlwnce.Checked = true;
                    else
                        chkMedAlwnce.Checked = false;

                    Mode = 2;
                    if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                    {
                        btn_Fam_Correct.Visible = false;

                    }

                    else
                    {
                        btn_Fam_Correct.Visible = true;
                    }
                    btn_Fam_Add.Visible = false;

                }
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void RG_Swipe_ItemCommand(object source, GridCommandEventArgs e)
    {
        try
        {
            if (Mode == 0)
            {
                if (e.CommandName == "Edit_Rec")
                {
                    GridDataItem dtItem = (GridDataItem)e.Item;
                    int index = dtItem.ItemIndex;
                    Label lblsSerial = new Label();
                    Label lblCCode = new Label();
                    Label lblIssue = new Label();
                    Label lblExpiry = new Label();
                    Label lblRem = new Label();
                    lblsSerial = RG_Swipe.Items[index].FindControl("lbl_swpSerial") as Label;
                    lblCCode = RG_Swipe.Items[index].FindControl("lbl_swpCardCode") as Label;
                    lblIssue = RG_Swipe.Items[index].FindControl("lbl_swpCardIssue") as Label;
                    lblExpiry = RG_Swipe.Items[index].FindControl("lbl_swpCardexpiry") as Label;
                    lblRem = RG_Swipe.Items[index].FindControl("lbl_swpRemarks") as Label;
                    Mode = 1;
                    txt_SSerial.Text = Convert.ToString(lblsSerial.Text);
                    txt_CardCode.Text = Convert.ToString(lblCCode.Text);
                    txt_IssueDate.SelectedDate = Convert.ToDateTime(Convert.ToString(lblIssue.Text));
                    txt_ExpiryDate.SelectedDate = Convert.ToDateTime(Convert.ToString(lblExpiry.Text));
                    txt_SwpRemarks.Text = Convert.ToString(lblRem.Text);
                    btn_swp_Add.Visible = false;
                    if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                    {
                        btn_swp_Correct.Visible = false;

                    }

                    else
                    {
                        btn_swp_Correct.Visible = true;
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
                    Label lblsSerial = new Label();
                    Label lblCCode = new Label();
                    Label lblIssue = new Label();
                    Label lblExpiry = new Label();
                    Label lblRem = new Label();
                    lblID = RG_Swipe.Items[index].FindControl("lbl_ID") as Label;
                    lblsSerial = RG_Swipe.Items[index].FindControl("lbl_swpSerial") as Label;
                    lblCCode = RG_Swipe.Items[index].FindControl("lbl_swpCardCode") as Label;
                    lblIssue = RG_Swipe.Items[index].FindControl("lbl_swpCardIssue") as Label;
                    lblExpiry = RG_Swipe.Items[index].FindControl("lbl_swpCardexpiry") as Label;
                    lblRem = RG_Swipe.Items[index].FindControl("lbl_swpRemarks") as Label;
                    Mode = 2;
                    _lbl_ID = lblID.Text;
                    txt_SSerial.Text = Convert.ToString(lblsSerial.Text);
                    txt_CardCode.Text = Convert.ToString(lblCCode.Text);
                    txt_IssueDate.SelectedDate = Convert.ToDateTime(Convert.ToString(lblIssue.Text));
                    txt_ExpiryDate.SelectedDate = Convert.ToDateTime(Convert.ToString(lblExpiry.Text));
                    txt_SwpRemarks.Text = Convert.ToString(lblRem.Text);
                    btn_swp_Add.Visible = false;
                    if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                    {
                        btn_swp_Correct.Visible = false;

                    }

                    else
                    {
                        btn_swp_Correct.Visible = true;
                    }


                }
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void RG_OTRate_ItemCommand(object source, GridCommandEventArgs e)
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
                    Label lblOTTypeID = new Label();
                    Label lblOTValue = new Label();
                    lblID = RG_OTRate.Items[index].FindControl("lbl_ID") as Label;
                    lblOTTypeID = RG_OTRate.Items[index].FindControl("lbl_OTTypeID") as Label;
                    lblOTValue = RG_OTRate.Items[index].FindControl("lbl_OtRate") as Label;
                    ddl_OTType.SelectedIndex = ddl_OTType.FindItemIndexByValue(lblOTTypeID.Text);
                    txt_Value.Value = Convert.ToDouble(lblOTValue.Text);
                    Mode = 1;
                    btn_OT_Add.Visible = false;
                    if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                    {
                        btn_OT_Correct.Visible = false;

                    }

                    else
                    {
                        btn_OT_Correct.Visible = true;
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
                    Label lblOTTypeID = new Label();
                    Label lblOTValue = new Label();
                    lblID = RG_OTRate.Items[index].FindControl("lbl_ID") as Label;
                    lblOTTypeID = RG_OTRate.Items[index].FindControl("lbl_OTTypeID") as Label;
                    lblOTValue = RG_OTRate.Items[index].FindControl("lbl_OtRate") as Label;
                    ddl_OTType.SelectedIndex = ddl_OTType.FindItemIndexByValue(lblOTTypeID.Text);
                    txt_Value.Value = Convert.ToDouble(lblOTValue.Text);
                    Mode = 2;
                    _lbl_ID = lblID.Text;
                    btn_OT_Add.Visible = false;
                    if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                    {
                        btn_OT_Correct.Visible = false;

                    }

                    else
                    {
                        btn_OT_Correct.Visible = true;
                    }

                }
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    #endregion

    #region CodeGeneration

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
                    Series = "0000";
                }
                else if (str.Length == 2)
                {
                    Series = "000";
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

                strAppcode = dt.Rows[0][8].ToString().Trim() + Convert.ToString(Series) + Convert.ToString(str);
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void getEmpCode()
    {
        try
        {
            string code = string.Empty;
            string str = string.Empty;
            string Series = "000000";
            string strCode = string.Empty;

            SMHR_GLOBALCONFIG _obj_smhr_globalConfig = new SMHR_GLOBALCONFIG();

            _obj_smhr_globalConfig.OPERATION = operation.Get;
            _obj_smhr_globalConfig.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            dt_Details = BLL.get_ConfigDetails(_obj_smhr_globalConfig);
            //_obj_smhr_employee = new SMHR_EMPLOYEE();
            //_obj_smhr_employee.OPERATION = operation.Update;
            //_obj_smhr_employee.APP_EMP_STATUS = Convert.ToString(ddl_EmpStatus.SelectedItem.Value);
            //_obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //dt_Details = BLL.get_Employee(_obj_smhr_employee);

            SMHR_EMPLOYEETYPE _obj_smhr_EmployeeType = new SMHR_EMPLOYEETYPE();
            _obj_smhr_EmployeeType.OPERATION = operation.Get;
            _obj_smhr_EmployeeType.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_EmployeeType.EMPLOYEETYPE_CODE = Convert.ToString(ddl_EmpStatus.SelectedItem.Text).Trim();
            DataTable dt = BLL.get_EmployeeType(_obj_smhr_EmployeeType);
            if (dt.Rows.Count != 0)
            {
                strCode = Convert.ToString(dt.Rows[0]["EMPLOYEETYPE_PREFIX"]).Trim();           //2
                //str = dt.Rows[0]["EMPLOYEETYPE_SERIALNO"].ToString().Trim();                  //7

                if (dt_Details.Rows.Count > 0)
                    str = Convert.ToString(dt_Details.Rows[0]["GLOBALCONFIG_ORG_EMP_CNT"]);

                if (str != string.Empty && str.Length > 0)
                    Series = Series.Substring(0, (6 - str.Length));

                lbl_Code.Text = strCode + Series + str;
            }
            /*if (dt.Rows.Count != 0)
            {
                //str = dt.Rows[0][0].ToString().Trim();
                //To get no of zero's for this organisation 04.03.2011
                SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
                _obj_Smhr_BusinessUnit.OPERATION = operation.Get_BU;
                _obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_bu = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
                StringBuilder sb = new StringBuilder();
                if (dt_bu.Rows.Count > 0)
                {
                    int n = Convert.ToInt32(dt_bu.Rows[0]["ORGANISATION_NOOFZEROS"]);       //2
                    for (int i = Convert.ToInt32(str.Length); i <= n; i++)
                    {
                        sb = sb.Append("0");
                    }
                    Series = Convert.ToString(sb);                                          //00
                }

                //_obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
                //_obj_smhr_businessunit.BUSINESSUNIT_ID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
                //_obj_smhr_businessunit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //DataTable dt_BU = BLL.get_BusinessUnit(_obj_smhr_businessunit);

                //if (Convert.ToString(ddl_EmpStatus.SelectedItem.Text).Trim() == "Permanent and Pensionable")
                //{
                //                      2                               00                          7    +    1                 --2008
                lbl_Code.Text = Convert.ToString(strCode) + Convert.ToString(Series) + (Convert.ToInt32(str) + 1).ToString();
                //}
                //else if (Convert.ToString(ddl_EmpStatus.SelectedItem.Text).Trim() == "Contract")
                //{

                //    _obj_smhr_globalconfig = new SMHR_GLOBALCONFIG();
                //    _obj_smhr_globalconfig.OPERATION = operation.Select;
                //    _obj_smhr_globalconfig.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //    DataTable dt = BLL.get_ConfigDetails(_obj_smhr_globalconfig);
                //    if (dt.Rows.Count != 0)
                //    {
                //        strCode = dt.Rows[0]["GLOBALCONFIG_CONTRACT_EMPCODE"].ToString().Trim();
                //    }
                //    lbl_Code.Text = Convert.ToString(strCode) + Convert.ToString(Series) + Convert.ToString(str);
                //}
                //else
                //{
                //    _obj_smhr_globalconfig = new SMHR_GLOBALCONFIG();
                //    _obj_smhr_globalconfig.OPERATION = operation.Select;
                //    _obj_smhr_globalconfig.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //    DataTable dt = BLL.get_ConfigDetails(_obj_smhr_globalconfig);
                //    if (dt.Rows.Count != 0)
                //    {
                //        strCode = dt.Rows[0]["GLOBALCONFIG_CONSULTANT_EMPCODE"].ToString().Trim();
                //    }
                //    lbl_Code.Text = Convert.ToString(strCode) + Convert.ToString(Series) + Convert.ToString(str);
                //}

            }*/
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region saveMethods

    private void saveQualification()
    {
        try
        {
            if (ddl_Applicant.SelectedValue != "")
            {
                _obj_smhr_applicant = new SMHR_APPLICANT();
                _obj_smhr_applicant.OPERATION = operation.Update;
                //_obj_smhr_applicant.APPLAN_ID = Convert.ToInt32(lbl_app_id);
                _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                bool status = false;
                foreach (GridItem row in RG_Qualification.Items)
                {

                    _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                    _obj_smhr_applicant.APPQFN_QUALIFICATION_ID = Convert.ToInt32((row.FindControl("lbl_ID") as Label).Text);
                    _obj_smhr_applicant.APPQFN_APPLICANT_ID = Convert.ToInt32(HF_APID.Value);
                    _obj_smhr_applicant.OPERATION = operation.Check_New;
                    if ((BLL.get_ApplicantQualification(_obj_smhr_applicant)).Rows.Count > 0)
                    {
                        _obj_smhr_applicant.APPQFN_ID = Convert.ToInt32((row.FindControl("lblID") as Label).Text);
                        _obj_smhr_applicant.OPERATION = operation.Update;
                    }
                    else
                    {
                        _obj_smhr_applicant.OPERATION = operation.Insert;
                    }

                    _obj_smhr_applicant.APPQFN_INSTITUTE = Convert.ToString((row.FindControl("lbl_AppInstitute") as Label).Text);
                    //_obj_smhr_applicant.APPQFN_PASSEDYEAR = Convert.ToInt32((row.FindControl("lbl_AppYearPass") as Label).Text);
                    _obj_smhr_applicant.APPQFN_PASSEDYEAR = Convert.ToString((row.FindControl("lbl_AppYearPass") as Label).Text) == "" ? Convert.ToInt32(0) : Convert.ToInt32((row.FindControl("lbl_AppYearPass") as Label).Text);
                    //_obj_smhr_applicant.APPQFN_PERCENTAGE = Convert.ToDouble((row.FindControl("lbl_AppPercentage") as Label).Text);
                    _obj_smhr_applicant.APPQFN_PERCENTAGE = Convert.ToString((row.FindControl("lbl_AppPercentage") as Label).Text) == "" ? Convert.ToDouble(0) : Convert.ToDouble((row.FindControl("lbl_AppPercentage") as Label).Text);
                    _obj_smhr_applicant.APPQFN_GRADE = Convert.ToString((row.FindControl("lbl_AppGrade") as Label).Text);
                    _obj_smhr_applicant.APPQFN_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_applicant.APPQFN_LASTMDFDATE = DateTime.Now;
                    _obj_smhr_applicant.APPQFN_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_applicant.APPQFN_CREATEDDATE = DateTime.Now;
                    //_obj_smhr_applicant.OPERATION = operation.Update;
                    status = BLL.set_AppQualification(_obj_smhr_applicant);
                }
            }
            else
            {

                _obj_smhr_applicant = new SMHR_APPLICANT();
                foreach (GridItem row in RG_Qualification.Items)
                {
                    bool status = false;
                    _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                    _obj_smhr_applicant.APPQFN_QUALIFICATION_ID = Convert.ToInt32((row.FindControl("lbl_ID") as Label).Text);
                    _obj_smhr_applicant.APPQFN_INSTITUTE = Convert.ToString((row.FindControl("lbl_AppInstitute") as Label).Text);
                    _obj_smhr_applicant.APPQFN_PASSEDYEAR = Convert.ToString((row.FindControl("lbl_AppYearPass") as Label).Text) == "" ? Convert.ToInt32(0) : Convert.ToInt32((row.FindControl("lbl_AppYearPass") as Label).Text);
                    //_obj_smhr_applicant.APPQFN_PERCENTAGE = Convert.ToDouble((row.FindControl("lbl_AppPercentage") as Label).Text);
                    _obj_smhr_applicant.APPQFN_PERCENTAGE = Convert.ToString((row.FindControl("lbl_AppPercentage") as Label).Text) == "" ? Convert.ToDouble(0) : Convert.ToDouble((row.FindControl("lbl_AppPercentage") as Label).Text);
                    _obj_smhr_applicant.APPQFN_GRADE = Convert.ToString((row.FindControl("lbl_AppGrade") as Label).Text);
                    _obj_smhr_applicant.APPQFN_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_applicant.APPQFN_CREATEDDATE = DateTime.Now;
                    _obj_smhr_applicant.OPERATION = operation.Insert;
                    status = BLL.set_AppQualification(_obj_smhr_applicant);
                }
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void saveExperience()
    {
        try
        {
            if (ddl_Applicant.SelectedValue != "")
            {
                _obj_smhr_applicant = new SMHR_APPLICANT();
                _obj_smhr_applicant.OPERATION = operation.Update;
                //_obj_smhr_applicant.APPLAN_ID = Convert.ToInt32(lbl_app_id);
                _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                bool status = false;
                foreach (GridItem row in RG_Experience.Items)
                {
                    _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                    _obj_smhr_applicant.APPEXP_APPLICANT_ID = Convert.ToInt32(HF_APID.Value);
                    _obj_smhr_applicant.APPEXP_SERIAL = Convert.ToInt32((row.FindControl("lbl_Exp_Serial") as Label).Text);
                    _obj_smhr_applicant.OPERATION = operation.Check1;
                    //////if ((BLL.get_ApplicantExperience(_obj_smhr_applicant)).Rows.Count > 0)
                    if (Convert.ToString(BLL.get_ApplicantExperience(_obj_smhr_applicant).Rows[0]["Count"]) != "0")
                    {
                        _obj_smhr_applicant.APPEXP_ID = Convert.ToInt32((row.FindControl("lblID") as Label).Text);
                        _obj_smhr_applicant.OPERATION = operation.Update;
                    }
                    else
                    {
                        _obj_smhr_applicant.OPERATION = operation.Insert;
                    }

                    _obj_smhr_applicant.APPEXP_COMPANY = Convert.ToString((row.FindControl("lbl_Exp_CompName") as Label).Text);
                    //_obj_smhr_applicant.APPEXP_JOINDATE = DateTime.ParseExact(((row.FindControl("lbl_Exp_JoinDate") as Label).Text), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    _obj_smhr_applicant.APPEXP_JOINDATE = DateTime.ParseExact(((row.FindControl("lbl_Exp_JoinDate") as Label).Text), Convert.ToString(Session["DATE_FORMAT"]), System.Globalization.CultureInfo.CurrentCulture);
                    if (Convert.ToString((row.FindControl("lbl_Exp_JoinSal") as Label).Text) != string.Empty)
                        _obj_smhr_applicant.APPEXP_JOINSAL = Convert.ToDouble(Convert.ToString((row.FindControl("lbl_Exp_JoinSal") as Label).Text));
                    else
                        _obj_smhr_applicant.APPEXP_JOINSAL = 0.0;
                    _obj_smhr_applicant.APPEXP_JOINDESC = Convert.ToString((row.FindControl("lbl_Exp_JoinDesc") as Label).Text);
                    _obj_smhr_applicant.APPEXP_REASONREL = Convert.ToString((row.FindControl("lbl_Exp_RelReason") as Label).Text);
                    //_obj_smhr_applicant.APPEXP_RELDATE = DateTime.ParseExact(((row.FindControl("lbl_Exp_RelDate") as Label).Text), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    _obj_smhr_applicant.APPEXP_RELDATE = DateTime.ParseExact(((row.FindControl("lbl_Exp_RelDate") as Label).Text), Convert.ToString(Session["DATE_FORMAT"]), System.Globalization.CultureInfo.CurrentCulture);
                    if (Convert.ToString((row.FindControl("lbl_Exp_RelSalary") as Label).Text) != string.Empty)
                        _obj_smhr_applicant.APPEXP_RELSAL = Convert.ToDouble((row.FindControl("lbl_Exp_RelSalary") as Label).Text);
                    else
                        _obj_smhr_applicant.APPEXP_RELSAL = 0.0;
                    _obj_smhr_applicant.APPEXP_REASONDESC = Convert.ToString((row.FindControl("lbl_Exp_RelDesc") as Label).Text);
                    _obj_smhr_applicant.APPEXP_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_applicant.APPEXP_LASTMDFDATE = Convert.ToString(DateTime.Now);
                    _obj_smhr_applicant.APPEXP_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_applicant.APPEXP_CREATEDDATE = DateTime.Now;
                    ////_obj_smhr_applicant.OPERATION = operation.Update;
                    status = BLL.set_ApplicantExperience(_obj_smhr_applicant);
                }


            }
            else
            {
                _obj_smhr_applicant = new SMHR_APPLICANT();
                bool status = false;

                foreach (GridItem row in RG_Experience.Items)
                {
                    _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                    _obj_smhr_applicant.APPEXP_SERIAL = Convert.ToInt32((row.FindControl("lbl_Exp_Serial") as Label).Text);
                    _obj_smhr_applicant.APPEXP_COMPANY = Convert.ToString((row.FindControl("lbl_Exp_CompName") as Label).Text);
                    //_obj_smhr_applicant.APPEXP_JOINDATE = DateTime.ParseExact(((row.FindControl("lbl_Exp_JoinDate") as Label).Text), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    _obj_smhr_applicant.APPEXP_JOINDATE = DateTime.ParseExact(((row.FindControl("lbl_Exp_JoinDate") as Label).Text), Convert.ToString(Session["DATE_FORMAT"]), System.Globalization.CultureInfo.CurrentCulture);
                    if (Convert.ToString((row.FindControl("lbl_Exp_JoinSal") as Label).Text) != string.Empty)
                        _obj_smhr_applicant.APPEXP_JOINSAL = Convert.ToDouble(Convert.ToString((row.FindControl("lbl_Exp_JoinSal") as Label).Text));
                    else
                        _obj_smhr_applicant.APPEXP_JOINSAL = 0.0;
                    //_obj_smhr_applicant.APPEXP_JOINSAL = Convert.ToDouble((row.FindControl("lbl_Exp_JoinSal") as Label).Text);
                    _obj_smhr_applicant.APPEXP_JOINDESC = Convert.ToString((row.FindControl("lbl_Exp_JoinDesc") as Label).Text);
                    _obj_smhr_applicant.APPEXP_REASONREL = Convert.ToString((row.FindControl("lbl_Exp_RelReason") as Label).Text);
                    //_obj_smhr_applicant.APPEXP_RELDATE = DateTime.ParseExact(((row.FindControl("lbl_Exp_RelDate") as Label).Text), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    _obj_smhr_applicant.APPEXP_RELDATE = DateTime.ParseExact(((row.FindControl("lbl_Exp_RelDate") as Label).Text), Convert.ToString(Session["DATE_FORMAT"]), System.Globalization.CultureInfo.CurrentCulture);
                    if (Convert.ToString((row.FindControl("lbl_Exp_RelSalary") as Label).Text) != string.Empty)
                        _obj_smhr_applicant.APPEXP_RELSAL = Convert.ToDouble((row.FindControl("lbl_Exp_RelSalary") as Label).Text);
                    else
                        _obj_smhr_applicant.APPEXP_RELSAL = 0.0;
                    //_obj_smhr_applicant.APPEXP_RELSAL = Convert.ToDouble((row.FindControl("lbl_Exp_RelSalary") as Label).Text);
                    _obj_smhr_applicant.APPEXP_REASONDESC = Convert.ToString((row.FindControl("lbl_Exp_RelDesc") as Label).Text);
                    _obj_smhr_applicant.APPEXP_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_applicant.APPEXP_CREATEDDATE = DateTime.Now;
                    _obj_smhr_applicant.OPERATION = operation.Insert;
                    status = BLL.set_ApplicantExperience(_obj_smhr_applicant);
                }
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void saveSkill()
    {
        try
        {
            if (ddl_Applicant.SelectedValue != "")
            {
                _obj_smhr_applicant = new SMHR_APPLICANT();
                _obj_smhr_applicant.OPERATION = operation.Update;
                //_obj_smhr_applicant.APPLAN_ID = Convert.ToInt32(lbl_app_id);
                _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                bool status = false;
                foreach (GridItem row in RG_Skills.Items)
                {
                    _obj_smhr_applicant.OPERATION = operation.Update;
                    _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                    _obj_smhr_applicant.APPSKL_APPLICANT_ID = Convert.ToInt32(HF_APID.Value);
                    _obj_smhr_applicant.APPSKL_SKILL_ID = Convert.ToInt32((row.FindControl("lbl_Skill_ID") as Label).Text);
                    _obj_smhr_applicant.OPERATION = operation.Check_New;
                    if ((BLL.get_ApplicantSkills(_obj_smhr_applicant)).Rows.Count > 0)
                    {
                        _obj_smhr_applicant.APPSKL_ID = Convert.ToInt32((row.FindControl("lblID") as Label).Text);
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
                }


            }
            else
            {
                _obj_smhr_applicant = new SMHR_APPLICANT();
                bool status = false;
                foreach (GridItem row in RG_Skills.Items)
                {
                    _obj_smhr_applicant.OPERATION = operation.Insert;
                    _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                    _obj_smhr_applicant.APPSKL_SKILL_ID = Convert.ToInt32((row.FindControl("lbl_Skill_ID") as Label).Text);
                    _obj_smhr_applicant.APPSKL_LASTUSED = Convert.ToInt32((row.FindControl("lbl_Skill_LastUsed") as Label).Text);
                    _obj_smhr_applicant.APPSKL_EXPERT = Convert.ToInt32((row.FindControl("lbl_Skill_Exp_ID") as Label).Text);
                    _obj_smhr_applicant.APPSKL_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_applicant.APPSKL_CREATEDDATE = DateTime.Now;
                    status = BLL.set_ApplicantSkills(_obj_smhr_applicant);
                }
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void saveFamily()
    {
        try
        {
            _obj_smhr_employee = new SMHR_EMPLOYEE();
            bool status = false;
            foreach (GridItem row in RG_Family.Items)
            {
                _obj_smhr_employee = new SMHR_EMPLOYEE();
                _obj_smhr_employee.OPERATION = operation.Insert;
                _obj_smhr_employee.EMPFMDTL_EMP_ID = Convert.ToInt32(HF_EMPID.Value); //Convert.ToInt32(_lbl_Emp_ID);
                _obj_smhr_employee.EMPFMDTL_SERIAL = Convert.ToInt32((row.FindControl("lbl_Serial") as Label).Text);
                _obj_smhr_employee.EMPFMDTL_EMPREL_ID = Convert.ToInt32((row.FindControl("lbl_ID") as Label).Text);
                _obj_smhr_employee.EMPFMDTL_EMPREL_NAME = Convert.ToString((row.FindControl("lbl_Relation") as Label).Text);
                _obj_smhr_employee.EMPFMDTL_SURNAME = Convert.ToString((row.FindControl("lbl_Surname") as Label).Text);
                _obj_smhr_employee.EMPFMDTL_NAME = Convert.ToString((row.FindControl("lbl_Name") as Label).Text);
                //_obj_smhr_employee.EMPFMDTL_RELDOB = DateTime.ParseExact(((row.FindControl("lbl_DOB") as Label).Text), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                if (string.Compare((row.FindControl("lbl_Relation") as Label).Text, "spouse", true) != 0)
                {
                    _obj_smhr_employee.EMPFMDTL_RELDOB = DateTime.ParseExact(((row.FindControl("lbl_DOB") as Label).Text), Convert.ToString(Session["DATE_FORMAT"]), System.Globalization.CultureInfo.CurrentCulture);
                }
                //DateTime date = DateTime.ParseExact(ST, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture);
                // _obj_smhr_employee.EMPFMDTL_RELDEPENDENT = (row.FindControl("chk_Dep") as CheckBox).Checked;
                _obj_smhr_employee.EMPFMDTL_EMERGENCYCONTACT = (row.FindControl("chk_Emergency") as CheckBox).Checked;
                // _obj_smhr_employee.EMPFMDTL_ISNEXTTOKIN = (row.FindControl("chk_NextToKin") as CheckBox).Checked;
                _obj_smhr_employee.EMPFMDTL_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_smhr_employee.EMPFMDTL_CREATEDDATE = DateTime.Now;
                _obj_smhr_employee.EMPFMDTL_PHOTO = Convert.ToString((row.FindControl("lbl_Photo") as Label).Text);
                _obj_smhr_employee.EMPFMDTL_BIODATA = Convert.ToString((row.FindControl("lbl_BioData") as Label).Text);
                //_obj_smhr_employee.EMPFMDTL_OCCUPATION = Convert.ToString((row.FindControl("lbl_Occupation") as Label).Text);
                //_obj_smhr_employee.EMPFMDTL_IMAGE = Convert.ToString((row.FindControl("EMPFMDTL_IMAGE") as Image).ImageUrl);
                status = BLL.set_EmpFamily(_obj_smhr_employee);
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void saveSwipe()
    {
        try
        {
            // as we are not using swipe information 
            _obj_smhr_employee = new SMHR_EMPLOYEE();
            bool status = false;
            dtSwipe = (DataTable)ViewState["dtSwipe"];
            if (dtSwipe != null)
            {
                foreach (DataRow row in dtSwipe.Rows)
                {
                    string Random = Convert.ToString(row[6]);
                    if (Random.Substring(0, 2) == lbl_Rand.Text)
                    {
                        _obj_smhr_employee = new SMHR_EMPLOYEE();
                        _obj_smhr_employee.OPERATION = operation.Update;
                        _obj_smhr_employee.EMPFMDTL_EMP_ID = Convert.ToInt32(HF_EMPID.Value); //Convert.ToInt32(_lbl_Emp_ID);
                        _obj_smhr_employee.EMPSWM_SERIAL = Convert.ToInt32(row[1]);
                        _obj_smhr_employee.EMPSWM_CARDCODE = Convert.ToString(row[2]);
                        _obj_smhr_employee.EMPSWM_CARDISSUE = Convert.ToDateTime(row[3]);
                        _obj_smhr_employee.EMPSWM_CARDEXPIRY = Convert.ToDateTime(row[4]);
                        _obj_smhr_employee.EMPSWM_REMARKS = Convert.ToString(row[5]);
                        _obj_smhr_employee.EMPSWM_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_smhr_employee.EMPSWM_CREATEDDATE = DateTime.Now;
                        status = BLL.set_EmployeeSwipe(_obj_smhr_employee);
                    }
                }
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void saveContact()
    {
        try
        {
            _obj_smhr_applicant = new SMHR_APPLICANT();
            bool status = false;
            dt_Contact = (DataTable)ViewState["dt_Contact"];
            if (dt_Contact != null)
            {
                foreach (DataRow row in dt_Contact.Rows)
                {
                    string Random = Convert.ToString(row[6]);
                    if (Random.Substring(0, 2) == lbl_Rand.Text)
                    {
                        _obj_smhr_applicant.OPERATION = operation.Insert;
                        _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                        _obj_smhr_applicant.APPCONT_SERIAL = Convert.ToInt32(Convert.ToString(row[1]));
                        _obj_smhr_applicant.APPCONT_COMPANY = Convert.ToString(row[2]);
                        _obj_smhr_applicant.APPCONT_CONTACT = Convert.ToString(row[3]);
                        _obj_smhr_applicant.APPCONT_PHONE = Convert.ToString(row[4]);
                        _obj_smhr_applicant.APPCONT_ADDRESS = Convert.ToString(row[5]);
                        _obj_smhr_applicant.APPCONT_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_smhr_applicant.APPCONT_CREATEDDATE = DateTime.Now;
                        status = BLL.set_ApplicantContact(_obj_smhr_applicant);
                    }
                }
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void saveOT()
    {
        try
        {
            _obj_smhr_employee = new SMHR_EMPLOYEE();
            bool status = false;
            dtOTRate = (DataTable)ViewState["dtOTRate"];
            if (dtOTRate != null)
            {
                foreach (DataRow row in dtOTRate.Rows)
                {
                    string Random = Convert.ToString(row[4]);
                    if (Random.Substring(0, 2) == lbl_Rand.Text)
                    {
                        _obj_smhr_employee.OPERATION = operation.Insert;
                        _obj_smhr_employee.EMPOTR_EMP_ID = Convert.ToInt32(HF_EMPID.Value); //Convert.ToInt32(_lbl_Emp_ID);
                        _obj_smhr_employee.EMPOTR_OTTYPE_ID = Convert.ToInt32(row[1]);
                        _obj_smhr_employee.EMPOTR_OTRATE = Convert.ToDouble(row[3]);
                        _obj_smhr_employee.EMPOTR_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_smhr_employee.EMPOTR_CREATEDDATE = DateTime.Now;
                        status = BLL.set_EmpOTInfo(_obj_smhr_employee);
                    }
                }
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void saveReference()
    {
        try
        {
            _obj_smhr_applicant = new SMHR_APPLICANT();
            bool status = false;
            dtReference = (DataTable)ViewState["dtReference"];
            if (dtReference != null)
            {
                foreach (DataRow row in dtReference.Rows)
                {
                    string Random = Convert.ToString(row[6]);
                    if (Random.Substring(0, 2) == lbl_Rand.Text)
                    {
                        _obj_smhr_applicant.OPERATION = operation.Insert;
                        _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                        _obj_smhr_applicant.APPREF_REFFERED_EMP_ID = Convert.ToInt32(Convert.ToString(row[1]));
                        _obj_smhr_applicant.APPREF_RELATIONSHIP = Convert.ToInt32(Convert.ToString(row[3]));
                        _obj_smhr_applicant.APPREF_REFERRED = Convert.ToBoolean(Convert.ToString(row[5]));
                        _obj_smhr_applicant.APPREF_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_smhr_applicant.APPREF_CREATEDDATE = DateTime.Now;
                        status = BLL.set_ApplicantReference(_obj_smhr_applicant);
                    }
                }
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void saveLanguage()
    {
        try
        {
            //_obj_smhr_applicant = new SMHR_APPLICANT();
            //bool status = false;
            //dtLanguage = (DataTable)ViewState["dtLanguage"];
            //if (dtLanguage != null)
            //{
            //    foreach (DataRow row in dtLanguage.Rows)
            //    {
            //          string Random = Convert.ToString(row[7]);
            //          if (Random.Substring(0, 2) == lbl_Rand.Text)
            //          {
            //              _obj_smhr_applicant.OPERATION = operation.Insert;
            //              _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(_lbl_App_ID);
            //              _obj_smhr_applicant.APPLAN_LANGUAGE_ID = Convert.ToInt32(Convert.ToString(row[1]));
            //              _obj_smhr_applicant.APPLAN_READ = Convert.ToBoolean(Convert.ToString(row[3]));
            //              _obj_smhr_applicant.APPLAN_WRITE = Convert.ToBoolean(Convert.ToString(row[4]));
            //              _obj_smhr_applicant.APPLAN_SPEAK = Convert.ToBoolean(Convert.ToString(row[5]));
            //              _obj_smhr_applicant.APPLAN_UNDERSTAND = Convert.ToBoolean(Convert.ToString(row[6]));
            //              _obj_smhr_applicant.APPLAN_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            //              _obj_smhr_applicant.APPLAN_CREATEDDATE = DateTime.Now;
            //              status = BLL.set_ApplicantLanguage(_obj_smhr_applicant);
            //          }
            //    }
            //}
            if (ddl_Applicant.SelectedValue != "")
            {
                _obj_smhr_applicant = new SMHR_APPLICANT();
                bool status = false;
                _obj_smhr_applicant.OPERATION = operation.Update;
                //_obj_smhr_applicant.APPLAN_ID = Convert.ToInt32(lbl_app_id);
                _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                foreach (GridItem row in RG_Language.Items)
                {
                    //_obj_smhr_applicant.OPERATION = operation.Update;
                    _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                    _obj_smhr_applicant.APPLAN_APPLICANT_ID = Convert.ToInt32(HF_APID.Value);
                    _obj_smhr_applicant.APPLAN_LANGUAGE_ID = Convert.ToInt32((row.FindControl("lbl_ID") as Label).Text);
                    _obj_smhr_applicant.OPERATION = operation.Check_New;
                    if ((BLL.get_ApplicantLanguage(_obj_smhr_applicant)).Rows.Count > 0)
                    {
                        _obj_smhr_applicant.APPLAN_ID = Convert.ToInt32((row.FindControl("lblID") as Label).Text);
                        _obj_smhr_applicant.OPERATION = operation.Update;
                    }
                    else
                    {
                        _obj_smhr_applicant.OPERATION = operation.Insert;
                    }

                    _obj_smhr_applicant.APPLAN_READ = (row.FindControl("chk_Lang_Read") as CheckBox).Checked;
                    _obj_smhr_applicant.APPLAN_WRITE = (row.FindControl("chk_Lang_Write") as CheckBox).Checked;
                    _obj_smhr_applicant.APPLAN_SPEAK = (row.FindControl("chk_Lang_Speak") as CheckBox).Checked;
                    _obj_smhr_applicant.APPLAN_UNDERSTAND = (row.FindControl("chk_Lang_Understand") as CheckBox).Checked;
                    _obj_smhr_applicant.APPLAN_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_applicant.APPLAN_CREATEDDATE = DateTime.Now;
                    _obj_smhr_applicant.APPLAN_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_applicant.APPLAN_LASTMDFDATE = DateTime.Now;
                    status = BLL.set_ApplicantLanguage(_obj_smhr_applicant);


                }

                ////_obj_smhr_applicant.APPLAN_LANGUAGE_ID = Convert.ToInt32(ddl_Language.SelectedValue);
                ////if (chk_Read.Checked)
                ////    _obj_smhr_applicant.APPLAN_READ = true;
                ////else
                ////    _obj_smhr_applicant.APPLAN_READ = false;
                ////if (chk_Write.Checked)
                ////    _obj_smhr_applicant.APPLAN_WRITE = true;
                ////else
                ////    _obj_smhr_applicant.APPLAN_WRITE = false;
                ////if (chk_Speak.Checked)
                ////    _obj_smhr_applicant.APPLAN_SPEAK = true;
                ////else
                ////    _obj_smhr_applicant.APPLAN_SPEAK = false;
                ////if (chk_Understand.Checked)
                ////    _obj_smhr_applicant.APPLAN_UNDERSTAND = true;
                ////else
                ////    _obj_smhr_applicant.APPLAN_UNDERSTAND = false;
                ////_obj_smhr_applicant.APPLAN_LASTMDFBY = 1;
                ////_obj_smhr_applicant.APPLAN_LASTMDFDATE = DateTime.Now;
                ////status = BLL.set_ApplicantLanguage(_obj_smhr_applicant);
            }
            else
            {
                _obj_smhr_applicant = new SMHR_APPLICANT();
                bool status = false;
                foreach (GridItem row in RG_Language.Items)
                {
                    _obj_smhr_applicant.OPERATION = operation.Insert;
                    _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                    _obj_smhr_applicant.APPLAN_LANGUAGE_ID = Convert.ToInt32((row.FindControl("lbl_ID") as Label).Text);
                    _obj_smhr_applicant.APPLAN_READ = (row.FindControl("chk_Lang_Read") as CheckBox).Checked;
                    _obj_smhr_applicant.APPLAN_WRITE = (row.FindControl("chk_Lang_Write") as CheckBox).Checked;
                    _obj_smhr_applicant.APPLAN_SPEAK = (row.FindControl("chk_Lang_Speak") as CheckBox).Checked;
                    _obj_smhr_applicant.APPLAN_UNDERSTAND = (row.FindControl("chk_Lang_Understand") as CheckBox).Checked;
                    _obj_smhr_applicant.APPLAN_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_applicant.APPLAN_CREATEDDATE = DateTime.Now;
                    status = BLL.set_ApplicantLanguage(_obj_smhr_applicant);

                }

            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void saveWeeklyOff(string ID)
    {
        try
        {
            _obj_smhr_weeklyoff = new SMHR_EMPLOYEEWEEKLYOFF();
            _obj_smhr_weeklyoff.OPERATION = operation.Select;
            _obj_smhr_weeklyoff.EMPWOFF_EMP_ID = Convert.ToInt32(HF_EMPID.Value); //Convert.ToInt32(_lbl_Emp_ID);
            DataTable dt = BLL.get_EmpWeekOff(_obj_smhr_weeklyoff);
            if (dt.Rows.Count == 0)
            {
                _obj_smhr_weeklyoff = new SMHR_EMPLOYEEWEEKLYOFF();
                _obj_smhr_weeklyoff.OPERATION = operation.Insert;
                _obj_smhr_weeklyoff.EMPWOFF_EMP_ID = Convert.ToInt32(ID);
                if (rdp_offDate.SelectedDate != null)
                    _obj_smhr_weeklyoff.EMPWOFF_EFFDATE = rdp_offDate.SelectedDate.Value;
                else
                    _obj_smhr_weeklyoff.EMPWOFF_EFFDATE = null;
                if (chk_Monday.Checked)
                    _obj_smhr_weeklyoff.EMPWOFF_MON = true;
                else
                    _obj_smhr_weeklyoff.EMPWOFF_MON = false;
                if (chk_tuesday.Checked)
                    _obj_smhr_weeklyoff.EMPWOFF_TUE = true;
                else
                    _obj_smhr_weeklyoff.EMPWOFF_TUE = false;
                if (chk_wednesday.Checked)
                    _obj_smhr_weeklyoff.EMPWOFF_WED = true;
                else
                    _obj_smhr_weeklyoff.EMPWOFF_WED = false;
                if (chk_thursday.Checked)
                    _obj_smhr_weeklyoff.EMPWOFF_THU = true;
                else
                    _obj_smhr_weeklyoff.EMPWOFF_THU = false;
                if (chk_Friday.Checked)
                    _obj_smhr_weeklyoff.EMPWOFF_FRI = true;
                else
                    _obj_smhr_weeklyoff.EMPWOFF_FRI = false;
                if (chk_Saturday.Checked)
                    _obj_smhr_weeklyoff.EMPWOFF_SAT = true;
                else
                    _obj_smhr_weeklyoff.EMPWOFF_SAT = false;
                if (chk_Sunday.Checked)
                    _obj_smhr_weeklyoff.EMPWOFF_SUN = true;
                else
                    _obj_smhr_weeklyoff.EMPWOFF_SUN = false;
                _obj_smhr_weeklyoff.EMPWOFF_CREATEDBY = Convert.ToInt32(Convert.ToString(Session["USER_ID"]));
                _obj_smhr_weeklyoff.EMPWOFF_CREATEDDATE = DateTime.Now;
                bool status = BLL.set_EmpWeekOff(_obj_smhr_weeklyoff);
            }
            else
            {
                _obj_smhr_weeklyoff = new SMHR_EMPLOYEEWEEKLYOFF();
                _obj_smhr_weeklyoff.OPERATION = operation.Update;
                _obj_smhr_weeklyoff.EMPWOFF_EMP_ID = Convert.ToInt32(ID);
                if (rdp_offDate.SelectedDate != null)
                    _obj_smhr_weeklyoff.EMPWOFF_EFFDATE = rdp_offDate.SelectedDate.Value;
                else
                    _obj_smhr_weeklyoff.EMPWOFF_EFFDATE = null;
                if (chk_Monday.Checked)
                    _obj_smhr_weeklyoff.EMPWOFF_MON = true;
                else
                    _obj_smhr_weeklyoff.EMPWOFF_MON = false;
                if (chk_tuesday.Checked)
                    _obj_smhr_weeklyoff.EMPWOFF_TUE = true;
                else
                    _obj_smhr_weeklyoff.EMPWOFF_TUE = false;
                if (chk_wednesday.Checked)
                    _obj_smhr_weeklyoff.EMPWOFF_WED = true;
                else
                    _obj_smhr_weeklyoff.EMPWOFF_WED = false;
                if (chk_thursday.Checked)
                    _obj_smhr_weeklyoff.EMPWOFF_THU = true;
                else
                    _obj_smhr_weeklyoff.EMPWOFF_THU = false;
                if (chk_Friday.Checked)
                    _obj_smhr_weeklyoff.EMPWOFF_FRI = true;
                else
                    _obj_smhr_weeklyoff.EMPWOFF_FRI = false;
                if (chk_Saturday.Checked)
                    _obj_smhr_weeklyoff.EMPWOFF_SAT = true;
                else
                    _obj_smhr_weeklyoff.EMPWOFF_SAT = false;
                if (chk_Sunday.Checked)
                    _obj_smhr_weeklyoff.EMPWOFF_SUN = true;
                else
                    _obj_smhr_weeklyoff.EMPWOFF_SUN = false;
                _obj_smhr_weeklyoff.EMPWOFF_LASTMDFBY = Convert.ToInt32(Convert.ToString(Session["USER_ID"]));
                _obj_smhr_weeklyoff.EMPWOFF_LASTMDFDATE = DateTime.Now;
                bool status = BLL.set_EmpWeekOff(_obj_smhr_weeklyoff);
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void saveOtherDetails(string ID)
    {
        try
        {
            bool status = false;
            _obj_SMHR_EMPOTHERDETAILS = new SMHR_EMPOTHERDETAILS();
            _obj_SMHR_EMPOTHERDETAILS.OPERATION = operation.Insert;
            _obj_SMHR_EMPOTHERDETAILS.EMPOTHERDTL_EMPID = Convert.ToInt32(HF_EMPID.Value); //Convert.ToInt32(_lbl_Emp_ID);
            _obj_SMHR_EMPOTHERDETAILS.EMPOTHERDTL_IDNO = rtxt_IdNumber.Text;
           // _obj_SMHR_EMPOTHERDETAILS.EMPOTHERDTL_PINNO = rtxt_PinNumber.Text;
         //   _obj_SMHR_EMPOTHERDETAILS.EMPOTHERDTL_NSSFNO = rtxt_NssfNo.Text;
            _obj_SMHR_EMPOTHERDETAILS.EMPOTHERDTL_NHIFNO = rtxt_NhifNo.Text;
            _obj_SMHR_EMPOTHERDETAILS.EMPOTHERDTL_TAXRELIEFAMOUNT = rtxt_TaxReliefAmt.Text;
            _obj_SMHR_EMPOTHERDETAILS.EMPOTHERDTL_NNAKNO = rtxt_NnakNo.Text;
            _obj_SMHR_EMPOTHERDETAILS.EMPOTHERDTL_PASSPORTNO = txtPassportNo.Text;
            _obj_SMHR_EMPOTHERDETAILS.EMPOTHERDTL_KRANO = rtxt_KRA_PINNO.Text;
            //_obj_SMHR_EMPOTHERDETAILS.EMPOTHERDTL_PPIDNO = rtxt_PPIDNo.Text;
            //_obj_SMHR_EMPOTHERDETAILS.EMPOTHERDTL_HELBNO = rtxt_HELBNo.Text;
            _obj_SMHR_EMPOTHERDETAILS.EMPOTHERDTL_COOPNO = rtxt_CooperativeNo.Text;
            _obj_SMHR_EMPOTHERDETAILS.EMPOTHERDTL_PROJECT_ID = Convert.ToInt32(rcmbProject.SelectedValue);
            _obj_SMHR_EMPOTHERDETAILS.EMPOTHERDTL_FUNDING_ID = Convert.ToInt32(rcmb_Funding.SelectedValue);
            if (rdpExpiryDate.SelectedDate.HasValue)
            {
                _obj_SMHR_EMPOTHERDETAILS.EMPOTHERDTL_EXPIRYDATE = rdpExpiryDate.SelectedDate;

            }
            else
            {
                _obj_SMHR_EMPOTHERDETAILS.EMPOTHERDTL_EXPIRYDATE = null;
            }
            _obj_SMHR_EMPOTHERDETAILS.EMPOTHERDTL_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_SMHR_EMPOTHERDETAILS.EMPOTHERDTL_CREATEDDATE = DateTime.Now;

            _obj_SMHR_EMPOTHERDETAILS.EMPOTHERDTL_BUDGETLINE = rtbbudgetline.Text;
            status = BLL.set_SMHR_EMPOTHERDETAILS(_obj_SMHR_EMPOTHERDETAILS);
            if (status == true)
            {
                LoadOtherDetails();
                //clearOtherDetails();
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void saveImportantDates()
    {
        try
        {
            bool status = false;
            _obj_SMHR_EMPIMPORTANTDATES = new SMHR_EMPIMPORTANTDATES();
            _obj_SMHR_EMPIMPORTANTDATES.OPERATION = operation.Insert;
            _obj_SMHR_EMPIMPORTANTDATES.EMPIMPORTANTDATES_EMPID = Convert.ToInt32(HF_EMPID.Value); //Convert.ToInt32(_lbl_Emp_ID);
            _obj_SMHR_EMPIMPORTANTDATES.EMPIMPORTANTDATES_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            if (rdp_DOA.SelectedDate != null)
                _obj_SMHR_EMPIMPORTANTDATES.EMPIMPORTANTDATES_ANNIVERSARYDATE = Convert.ToDateTime(rdp_DOA.SelectedDate).ToShortDateString();
            if (rdp_MedTerminationDate.SelectedDate != null)
                _obj_SMHR_EMPIMPORTANTDATES.EMPIMPORTANTDATES_MEDICALTERMINATIONDATE = Convert.ToDateTime(rdp_MedTerminationDate.SelectedDate).ToShortDateString();
            if (rdp_PensionDate.SelectedDate != null)
                _obj_SMHR_EMPIMPORTANTDATES.EMPIMPORTANTDATES_PENSIONJOINEDDATE = Convert.ToDateTime(rdp_PensionDate.SelectedDate).ToShortDateString();

            if (radOrientationDate.SelectedDate != null)
                _obj_SMHR_EMPIMPORTANTDATES.EMPIMPORTANTDATES_ORIENTATIONDATE = Convert.ToDateTime(radOrientationDate.SelectedDate).ToShortDateString();
            //Orientation Doc
            if (FOrientation.HasFile)
            {
                string imagename = txt_Name.Text + "_" + Guid.NewGuid().ToString() + "_FORIENDOC" + FOrientation.FileName;
                string strPath = "~/EmpUploads/" + imagename;
                FOrientation.PostedFile.SaveAs(Server.MapPath("~/EmpUploads/") + imagename);
                _obj_SMHR_EMPIMPORTANTDATES.EMPIMPORTANTDATES_ORIENTATIONDOC = strPath;
            }

            if (FOfficialScerectsactDoc.HasFile)
            {
                string imagename = txt_Name.Text + "_" + Guid.NewGuid().ToString() + "_OFFICIALSCERECTSACT" + FOfficialScerectsactDoc.FileName;
                string strPath = "~/EmpUploads/" + imagename;
                FOfficialScerectsactDoc.PostedFile.SaveAs(Server.MapPath("~/EmpUploads/") + imagename);
                _obj_SMHR_EMPIMPORTANTDATES.EMPIMPORTANTDATES_OFFICIALSCERECTSACTDOC = strPath;
            }
            //NextofKinForm
            if (FNextofKinForm.HasFile)
            {
                string imagename = txt_Name.Text + "_" + Guid.NewGuid().ToString() + "_FNEXTOFKINFORM" + FNextofKinForm.FileName;
                string strPath = "~/EmpUploads/" + imagename;
                FNextofKinForm.PostedFile.SaveAs(Server.MapPath("~/EmpUploads/") + imagename);
                _obj_SMHR_EMPIMPORTANTDATES.EMPIMPORTANTDATES_NEXTOFKINFORM = strPath;
            }
            if (FPSC2_1.HasFile)
            {
                string imagename = txt_Name.Text + "_" + Guid.NewGuid().ToString() + "_FPSC2_1" + FPSC2_1.FileName;
                string strPath = "~/EmpUploads/" + imagename;
                FPSC2_1.PostedFile.SaveAs(Server.MapPath("~/EmpUploads/") + imagename);
                _obj_SMHR_EMPIMPORTANTDATES.EMPIMPORTANTDATES_PSC2_1 = strPath;
            }
            if (FStaffParticulars.HasFile)
            {
                string imagename = txt_Name.Text + "_" + Guid.NewGuid().ToString() + "_FSTAFFPARTICULARS" + FStaffParticulars.FileName;
                string strPath = "~/EmpUploads/" + imagename;
                FStaffParticulars.PostedFile.SaveAs(Server.MapPath("~/EmpUploads/") + imagename);
                _obj_SMHR_EMPIMPORTANTDATES.EMPIMPORTANTDATES_STAFFPARTICULARS = strPath;
            }
            _obj_SMHR_EMPIMPORTANTDATES.EMPIMPORTANTDATES_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_SMHR_EMPIMPORTANTDATES.EMPIMPORTANTDATES_CREATEDDATE = DateTime.Now;
            status = BLL.set_SMHR_EMPIMPORTANTDATES(_obj_SMHR_EMPIMPORTANTDATES);
            if (status == true)
            {
                LoadImportantDates();
                clearImportantDates();
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    #region LoadMethods

    private void LoadQualification()
    {
        try
        {
            _obj_smhr_applicant = new SMHR_APPLICANT();
            int I_ = Convert.ToInt32(ViewState["ddlIndex"]);
            if (I_ != 0)
            {
                _obj_smhr_applicant.APPQFN_APPLICANT_ID = Convert.ToInt32(I_);
            }
            else
            {
                _obj_smhr_applicant.APPQFN_APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
            }
            _obj_smhr_applicant.OPERATION = operation.Check;
            DataTable dt = BLL.get_ApplicantQualification(_obj_smhr_applicant);
            RG_Qualification.DataSource = dt;
            ViewState["dt_Qual"] = dt;
            RG_Qualification.DataBind();
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadExperience()
    {
        try
        {
            _obj_smhr_applicant = new SMHR_APPLICANT();
            int I_ = Convert.ToInt32(ViewState["ddlIndex"]);
            if (I_ != 0)
            {
                _obj_smhr_applicant.APPEXP_APPLICANT_ID = Convert.ToInt32(I_);
            }
            else
            {
                _obj_smhr_applicant.APPEXP_APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
            }
            _obj_smhr_applicant.OPERATION = operation.Check;
            DataTable dt = BLL.get_ApplicantExperience(_obj_smhr_applicant);
            RG_Experience.DataSource = dt;
            ViewState["dtExperience"] = dt;
            RG_Experience.DataBind();
            txt_Serial.Text = Convert.ToString(RG_Experience.Items.Count + 1);
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadSkill()
    {
        try
        {
            _obj_smhr_applicant = new SMHR_APPLICANT();
            int I_ = Convert.ToInt32(ViewState["ddlIndex"]);
            if (I_ != 0)
            {
                _obj_smhr_applicant.APPSKL_APPLICANT_ID = Convert.ToInt32(I_);
            }
            else
            {
                _obj_smhr_applicant.APPSKL_APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
            }
            _obj_smhr_applicant.OPERATION = operation.Check;
            DataTable dt = BLL.get_ApplicantSkills(_obj_smhr_applicant);
            RG_Skills.DataSource = dt;
            ViewState["dt_Skill"] = dt;
            RG_Skills.DataBind();
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadFamily()
    {
        try
        {
            _obj_smhr_employee = new SMHR_EMPLOYEE();
            _obj_smhr_employee.EMPFMDTL_EMP_ID = Convert.ToInt32(HF_EMPID.Value); //Convert.ToInt32(_lbl_Emp_ID);
            _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_employee.OPERATION = operation.Check;
            DataTable dt = BLL.get_EmployeeFamily(_obj_smhr_employee);
            RG_Family.DataSource = dt;
            RG_Family.DataBind();
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadSwipe()
    {
        try
        {
            _obj_smhr_employee = new SMHR_EMPLOYEE();
            _obj_smhr_employee.EMPSWM_EMP_ID = Convert.ToInt32(HF_EMPID.Value); //Convert.ToInt32(_lbl_Emp_ID);
            _obj_smhr_employee.OPERATION = operation.Check;
            DataTable dt = BLL.get_EmployeeSwipe(_obj_smhr_employee);
            RG_Swipe.DataSource = dt;
            RG_Swipe.DataBind();
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadLanguage()
    {
        try
        {
            _obj_smhr_applicant = new SMHR_APPLICANT();
            int I_ = Convert.ToInt32(ViewState["ddlIndex"]);
            if (I_ != 0)
            {
                _obj_smhr_applicant.APPLAN_APPLICANT_ID = Convert.ToInt32(I_);
            }
            else
            {
                _obj_smhr_applicant.APPLAN_APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
            }
            _obj_smhr_applicant.OPERATION = operation.Check;
            DataTable dt = BLL.get_ApplicantLanguage(_obj_smhr_applicant);
            RG_Language.DataSource = dt;
            ViewState["dtLanguage"] = dt;
            RG_Language.DataBind();
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadReference()
    {
        try
        {
            _obj_smhr_applicant = new SMHR_APPLICANT();
            int I_ = Convert.ToInt32(ViewState["ddlIndex"]);
            if (I_ != 0)
            {
                _obj_smhr_applicant.APPREF_APPLICANT_ID = Convert.ToInt32(I_);
            }
            else
            {
                _obj_smhr_applicant.APPREF_APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
            }
            _obj_smhr_applicant.OPERATION = operation.Check;
            DataTable dt = BLL.get_ApplicantReference(_obj_smhr_applicant);
            RG_Reference.DataSource = dt;
            RG_Reference.DataBind();
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadContact()
    {
        try
        {
            _obj_smhr_applicant = new SMHR_APPLICANT();
            int I_ = Convert.ToInt32(ViewState["ddlIndex"]);
            if (I_ != 0)
            {
                _obj_smhr_applicant.APPCONT_APPLICANT_ID = Convert.ToInt32(I_);
            }
            else
            {
                _obj_smhr_applicant.APPCONT_APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
            }
            _obj_smhr_applicant.OPERATION = operation.Check;
            DataTable dt = BLL.get_ApplicantContact(_obj_smhr_applicant);
            RG_Contact.DataSource = dt;
            RG_Contact.DataBind();
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadOTInfo()
    {
        try
        {
            _obj_smhr_employee = new SMHR_EMPLOYEE();
            _obj_smhr_employee.OPERATION = operation.Empty;
            _obj_smhr_employee.EMPOTR_EMP_ID = Convert.ToInt32(HF_EMPID.Value); //Convert.ToInt32(_lbl_Emp_ID);    
            DataTable dt = BLL.get_EmpOTRate(_obj_smhr_employee);
            RG_OTRate.DataSource = dt;
            RG_OTRate.DataBind();
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadWeekOff()
    {
        try
        {
            _obj_smhr_weeklyoff = new SMHR_EMPLOYEEWEEKLYOFF();
            _obj_smhr_weeklyoff.OPERATION = operation.Select;
            _obj_smhr_weeklyoff.EMPWOFF_EMP_ID = Convert.ToInt32(HF_EMPID.Value); //Convert.ToInt32(_lbl_Emp_ID);
            DataTable dt = BLL.get_EmpWeekOff(_obj_smhr_weeklyoff);
            if (dt.Rows.Count != 0)
            {
                //if (dt.Rows[0]["EMPWOFF_EFFDATE"] != System.DBNull.Value)
                //    rdp_offDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["EMPWOFF_EFFDATE"]);
                if (dt.Rows[0]["DateOfJoin"] != System.DBNull.Value)
                    rdp_offDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["DateOfJoin"]);                
                if (dt.Rows[0]["EMPWOFF_MON"] != System.DBNull.Value)
                    chk_Monday.Checked = Convert.ToBoolean(dt.Rows[0]["EMPWOFF_MON"]);
                if (dt.Rows[0]["EMPWOFF_TUE"] != System.DBNull.Value)
                    chk_tuesday.Checked = Convert.ToBoolean(dt.Rows[0]["EMPWOFF_TUE"]);
                if (dt.Rows[0]["EMPWOFF_WED"] != System.DBNull.Value)
                    chk_wednesday.Checked = Convert.ToBoolean(dt.Rows[0]["EMPWOFF_WED"]);
                if (dt.Rows[0]["EMPWOFF_THU"] != System.DBNull.Value)
                    chk_thursday.Checked = Convert.ToBoolean(dt.Rows[0]["EMPWOFF_THU"]);
                if (dt.Rows[0]["EMPWOFF_FRI"] != System.DBNull.Value)
                    chk_Friday.Checked = Convert.ToBoolean(dt.Rows[0]["EMPWOFF_FRI"]);
                if (dt.Rows[0]["EMPWOFF_SAT"] != System.DBNull.Value)
                    chk_Saturday.Checked = Convert.ToBoolean(dt.Rows[0]["EMPWOFF_SAT"]);
                if (dt.Rows[0]["EMPWOFF_SUN"] != System.DBNull.Value)
                    chk_Sunday.Checked = Convert.ToBoolean(dt.Rows[0]["EMPWOFF_SUN"]);
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadOtherDetails()
    {
        try
        {
            _obj_SMHR_EMPOTHERDETAILS = new SMHR_EMPOTHERDETAILS();
            _obj_SMHR_EMPOTHERDETAILS.OPERATION = operation.Select;
            _obj_SMHR_EMPOTHERDETAILS.EMPOTHERDTL_EMPID = Convert.ToInt32(HF_EMPID.Value.ToString());//Convert.ToInt32(_lbl_Emp_ID.ToString());
            DataTable dt = BLL.get_SMHR_EMPOTHERDETAILS(_obj_SMHR_EMPOTHERDETAILS);
            if (dt.Rows.Count != 0)
            {
                rtxt_IdNumber.Text = Convert.ToString(dt.Rows[0]["EMPOTHERDTL_IDNO"]);
                rtxt_NhifNo.Text = Convert.ToString(dt.Rows[0]["EMPOTHERDTL_NHIFNO"]);
                rtxt_NnakNo.Text = Convert.ToString(dt.Rows[0]["EMPOTHERDTL_NNAKNO"]);
               // rtxt_NssfNo.Text = Convert.ToString(dt.Rows[0]["EMPOTHERDTL_NSSFNO"]);
              //  rtxt_PinNumber.Text = Convert.ToString(dt.Rows[0]["EMPOTHERDTL_PINNO"]);
                rtxt_TaxReliefAmt.Text = Convert.ToString(dt.Rows[0]["EMPOTHERDTL_TAXRELIEFAMOUNT"]);
                txtPassportNo.Text = Convert.ToString(dt.Rows[0]["EMPOTHERDTL_PASSPORTNO"]);
                rtxt_KRA_PINNO.Text = Convert.ToString(dt.Rows[0]["EMPOTHERDTL_KRANO"]);
                //rtxt_PPIDNo.Text = Convert.ToString(dt.Rows[0]["EMPOTHERDTL_PPIDNO"]);
                //rtxt_HELBNo.Text = Convert.ToString(dt.Rows[0]["EMPOTHERDTL_HELBNO"]);
                rtxt_CooperativeNo.Text = Convert.ToString(dt.Rows[0]["EMPOTHERDTL_COOPNO"]);
                rcmbProject.SelectedValue = Convert.ToString(dt.Rows[0]["EMPOTHERDTL_PROJECT_ID"]);
                rcmb_Funding.SelectedValue = Convert.ToString(dt.Rows[0]["EMPOTHERDTL_FUNDING_ID"]);
                if (dt.Rows[0]["EMPOTHERDTL_PASSPORTEXPIRYDATE"] != System.DBNull.Value)
                {
                    rdpExpiryDate.SelectedDate = Convert.ToDateTime((dt.Rows[0]["EMPOTHERDTL_PASSPORTEXPIRYDATE"]));
                }
                else
                {
                    rdpExpiryDate.SelectedDate = null;
                }
                rtbbudgetline.Text = Convert.ToString(dt.Rows[0]["EMPOTHERDTL_BUDGETLINE"]);
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    //Code to Load Physical Details.
    private void LoadPhysicalDetails()
    {
        try
        {
            _obj_SMHR_EMPPHYSICALDETAILS = new SMHR_EMP_PHYSICALDETAILS();
            _obj_SMHR_EMPPHYSICALDETAILS.OPERATION = operation.Select;
            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_EMPID = Convert.ToInt32(HF_EMPID.Value.ToString()); //Convert.ToInt32(_lbl_Emp_ID.ToString());
            DataTable dt = BLL.get_PhysicalDetails(_obj_SMHR_EMPPHYSICALDETAILS);
            if (dt.Rows.Count != 0)
            {
                rtxt_Height.Text = Convert.ToString(dt.Rows[0]["EMPPHYSICALDTL_HEIGHT"]);
                rtxt_Weight.Text = Convert.ToString(dt.Rows[0]["EMPPHYSICALDTL_WEIGHT"]);
                rtxt_SkinColor.Text = Convert.ToString(dt.Rows[0]["EMPPHYSICALDTL_COLOR"]);
                rtxt_IdentificationMarks.Text = Convert.ToString(dt.Rows[0]["EMPPHYSICALDTL_IDENTIFICATION"]);
                rtxt_EyePower.Text = Convert.ToString(dt.Rows[0]["EMPPHYSICALDTL_EYEPOWER"]);
                if (Convert.ToString(dt.Rows[0]["EMPPHYSICALDTL_HANDICAP"]) != null)
                {
                    chk_Handicapped.Checked = Convert.ToBoolean(dt.Rows[0]["EMPPHYSICALDTL_HANDICAP"]);
                }
                if (Convert.ToString(dt.Rows[0]["EMPPHYSICALDTL_HANDICAP_YES"]) != "")
                {
                    lbl_HandicapDetails.Visible = true;
                    rtxt_Handicapped.Visible = true;
                    rtxt_Handicapped.Text = Convert.ToString(dt.Rows[0]["EMPPHYSICALDTL_HANDICAP_YES"]);
                }
                rtxt_Handicapped.Text = Convert.ToString(dt.Rows[0]["EMPPHYSICALDTL_HANDICAP_YES"]);
                rtxt_TreatmentName_Physical.Text = Convert.ToString(dt.Rows[0]["EMPPHYSICALDTL_PHYSICALTREATMENT"]);
                rtxt_HospitalName_Physical.Text = Convert.ToString(dt.Rows[0]["EMPPHYSICALDTL_PHYSICALHOSPITAL"]);
                rtxt_TreatmentDuration_Physical.Text = Convert.ToString(dt.Rows[0]["EMPPHYSICALDTL_PHYSICALDURATION"]);
                rtxt_IllnessStatus_Physical.Text = Convert.ToString(dt.Rows[0]["EMPPHYSICALDTL_PHYSICALSTATUS"]);
                rtxt_TreatmentName_Mental.Text = Convert.ToString(dt.Rows[0]["EMPPHYSICALDTL_MENTALTREATMENT"]);
                rtxt_HospitalName_Mental.Text = Convert.ToString(dt.Rows[0]["EMPPHYSICALDTL_MENTALHOSPITAL"]);
                rtxt_TreatmentDuration_Mental.Text = Convert.ToString(dt.Rows[0]["EMPPHYSICALDTL_MENTALDURATION"]);
                rtxt_IllnessStatus_Mental.Text = Convert.ToString(dt.Rows[0]["EMPPHYSICALDTL_MENTALSTATUS"]);
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadNewContactDetails()
    {
        try
        {
            _obj_smhr_employee = new SMHR_EMPLOYEE();
            _obj_smhr_employee.OPERATION = operation.Select;
            _obj_smhr_employee.EMP_ID = Convert.ToInt32(HF_EMPID.Value.ToString()); //Convert.ToInt32(_lbl_Emp_ID.ToString());
            DataTable dt = BLL.get_EMP_NEWCONTACTS(_obj_smhr_employee);
            if (dt.Rows.Count != 0)
            {
                rmtxt_MobileNo.Text = Convert.ToString(dt.Rows[0]["EMP_MOBILENO"]);
                rmtxt_LandlineNo.Text = Convert.ToString(dt.Rows[0]["EMP_LANDLINENO"]);
                rtxt_EmailID.Text = Convert.ToString(dt.Rows[0]["EMP_EMAILID"]);
                txtSkypeId.Text = Convert.ToString(dt.Rows[0]["EMP_SKYPEID"]);
                rntbExtensionNo.Text = Convert.ToString(dt.Rows[0]["EMP_EXTENSIONNO"]);
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadSelfLoginDetails()
    {
        try
        {
            LoadUserGroups();
            _obj_smhr_employee = new SMHR_EMPLOYEE();
            _obj_smhr_employee.OPERATION = operation.Select1;
            _obj_smhr_employee.EMP_ID = Convert.ToInt32(HF_EMPID.Value.ToString()); //Convert.ToInt32(_lbl_Emp_ID.ToString());
            DataTable dt = BLL.get_EMP_NEWCONTACTS(_obj_smhr_employee);
            if (dt.Rows.Count != 0)
            {
                //rtxt_passcode.Text = Convert.ToString(dt.Rows[0]["EMP_MOBILENO"]);
                //rtxt_pwd.Text = Convert.ToString(dt.Rows[0]["EMP_LANDLINENO"]);
                rcmb_usergroup.SelectedIndex = rcmb_usergroup.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LOGIN_TYPE"]));
                if (rcmb_usergroup.SelectedIndex > 0)
                {
                    rcmb_usergroup.Enabled = false;
                }
                strPass = BLL.PasswordDecrypt(Convert.ToString(dt.Rows[0]["LOGIN_PASSWORD"]));
                strPass1 = BLL.PasswordDecrypt(Convert.ToString(dt.Rows[0]["LOGIN_PASS_CODE"]));
                //string strPass = Convert.ToString(dt.Rows[0]["LOGIN_PASSWORD"]);
                rtxt_pwd.Attributes.Add("value", strPass);
                rtxt_passcode.Attributes.Add("value", strPass1);
                rtxt_pwd.Text = Convert.ToString(BLL.PasswordDecrypt(Convert.ToString(dt.Rows[0]["LOGIN_PASSWORD"])));
                rtxt_passcode.Text = Convert.ToString(BLL.PasswordDecrypt(Convert.ToString(dt.Rows[0]["LOGIN_PASS_CODE"])));
                rtxt_pwd.TextMode = TextBoxMode.Password;
                rtxt_passcode.TextMode = TextBoxMode.Password;

            }
            else
            {
                strPass = "123456aA";
                rtxt_pwd.Text = strPass;
                rtxt_pwd.TextMode = TextBoxMode.Password;
                strPass1 = "123456aA";
                rtxt_passcode.Text = strPass1;
                rtxt_passcode.TextMode = TextBoxMode.Password;
                rtxt_pwd.Attributes.Add("value", strPass);
                rtxt_passcode.Attributes.Add("value", strPass1);
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadImportantDates()
    {
        try
        {
            _obj_SMHR_EMPIMPORTANTDATES = new SMHR_EMPIMPORTANTDATES();
            _obj_SMHR_EMPIMPORTANTDATES.OPERATION = operation.Select;
            _obj_SMHR_EMPIMPORTANTDATES.EMPIMPORTANTDATES_EMPID = Convert.ToInt32(HF_EMPID.Value.ToString()); //Convert.ToInt32(_lbl_Emp_ID.ToString());
            DataTable dt = BLL.get_SMHR_EMPIMPORTANTDATES(_obj_SMHR_EMPIMPORTANTDATES);
            if (dt.Rows.Count != 0)
            {
                if (dt.Rows[0]["EMPIMPORTANTDATES_ANNIVERSARYDATE"] != string.Empty)
                    rdp_DOA.SelectedDate = Convert.ToDateTime(dt.Rows[0]["EMPIMPORTANTDATES_ANNIVERSARYDATE"]);
                if (dt.Rows[0]["EMPIMPORTANTDATES_MEDICALTERMINATIONDATE"] != string.Empty)
                    rdp_MedTerminationDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["EMPIMPORTANTDATES_MEDICALTERMINATIONDATE"]);
                if (dt.Rows[0]["EMPIMPORTANTDATES_PENSIONJOINEDDATE"] != string.Empty)
                    rdp_PensionDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["EMPIMPORTANTDATES_PENSIONJOINEDDATE"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["EMPIMPORTANTDATES_ORIENTATIONDATE"].ToString()))
                    radOrientationDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["EMPIMPORTANTDATES_ORIENTATIONDATE"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["EMPIMPORTANTDATES_ORIENTATIONDOC"].ToString()))
                {
                    lnkUploadedOrien.HRef = dt.Rows[0]["EMPIMPORTANTDATES_ORIENTATIONDOC"].ToString();
                    lnkUploadedOrien.Visible = true;
                }
                else
                    lnkUploadedOrien.Visible = false;
                if (!string.IsNullOrEmpty(dt.Rows[0]["EMPIMPORTANTDATES_OFFICIALSCERECTSACTDOC"].ToString()))
                {
                    aOfficialScerectsactDoc.HRef = dt.Rows[0]["EMPIMPORTANTDATES_OFFICIALSCERECTSACTDOC"].ToString();
                    aOfficialScerectsactDoc.Visible = true;
                }
                else
                    aOfficialScerectsactDoc.Visible = false;
                if (!string.IsNullOrEmpty(dt.Rows[0]["EMPIMPORTANTDATES_NEXTOFKINFORM"].ToString()))
                {
                    aNextofKinForm.HRef = dt.Rows[0]["EMPIMPORTANTDATES_NEXTOFKINFORM"].ToString();
                    aNextofKinForm.Visible = true;
                }
                else
                    aNextofKinForm.Visible = false;
                if (!string.IsNullOrEmpty(dt.Rows[0]["EMPIMPORTANTDATES_PSC2_1"].ToString()))
                {
                    aPSC2_1.HRef = dt.Rows[0]["EMPIMPORTANTDATES_PSC2_1"].ToString();
                    aPSC2_1.Visible = true;
                }
                else
                    aPSC2_1.Visible = false;
                if (!string.IsNullOrEmpty(dt.Rows[0]["EMPIMPORTANTDATES_STAFFPARTICULARS"].ToString()))
                {
                    aStaffParticulars.HRef = dt.Rows[0]["EMPIMPORTANTDATES_STAFFPARTICULARS"].ToString();
                    aStaffParticulars.Visible = true;
                }
                else
                    aStaffParticulars.Visible = false;
            }
            rdp_DateJoined.SelectedDate = txt_DOJ.SelectedDate;
            rdp_Confirm.SelectedDate = txt_DOC.SelectedDate;
            rdp_Birth.SelectedDate = txt_DOB.SelectedDate;
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    #region getDetails

    private void getDetails(string ID)
    {
        try
        {
            LoadPeriod();

            _obj_smhr_employee = new SMHR_EMPLOYEE();
            _obj_smhr_employee.OPERATION = operation.Select;
            _obj_smhr_employee.EMP_ID = Convert.ToInt32(ID);
            //dt_Details = new DataTable();
            _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_Employee(_obj_smhr_employee);
            if (dt_Details.Rows.Count != 0)
            {
                #region EmployeeGratuityValues
                rtbEmplyrGrat.Text = Convert.ToString(dt_Details.Rows[0]["EMP_EMPLOYER_GRAT_ID"]);
                rtbEmplyeGrat.Text = Convert.ToString(dt_Details.Rows[0]["EMP_EMPLOYEE_GRAT_ID"]);
                #endregion

                ddl_Applicant.SelectedValue = Convert.ToString(dt_Details.Rows[0]["EMP_APPLICANT_ID"]);
                //ViewState["ddlIndex"] = ddl_Applicant.SelectedValue;
                lbl_Code.Text = Convert.ToString(dt_Details.Rows[0]["EMP_EMPCODE"]);
                rtxt_empcode.Text = Convert.ToString(dt_Details.Rows[0]["EMP_EMPCODE"]);

                txt_DOJ.Enabled = false;
                ddl_BusinessUnit.Enabled = false;
                ddl_LeaveStructure.Enabled = false;
                ddl_SalaryStructure.Enabled = false;
                ddl_Jobs.Enabled = false;
                ddl_Designation.Enabled = false;
                ddl_Slabs.Enabled = false;
                ddl_Grade.Enabled = false;
                //rcmb_Period.Enabled = false;
                if (Convert.ToInt32(dt_Details.Rows[0]["EMP_STATUS"]) == 1)
                {
                    ViewState["STATUS"] = 1;
                }
                else if (Convert.ToInt32(dt_Details.Rows[0]["EMP_STATUS"]) == 2)
                {
                    ViewState["STATUS"] = 2;
                }
                else if (Convert.ToInt32(dt_Details.Rows[0]["EMP_STATUS"]) == 3)
                {
                    ViewState["STATUS"] = 3;
                }
                else if (Convert.ToInt32(dt_Details.Rows[0]["EMP_STATUS"]) == 4)
                {
                    ViewState["STATUS"] = 4;
                }
                else
                {
                    ViewState["STATUS"] = 0;
                }
                //if (Convert.ToBoolean(ViewState["Rehire"]) == true)
                //{
                //    if(Session["RelDate"]!=null)
                //    txt_DOJ.MinDate = Convert.ToDateTime(Session["RelDate"]);
                //    Session["RelDate"] = null;
                //}
                //else
                //{
                //    Session["RelDate"] = null;
                //}
                //Inerted By Raghasudha on sep 25 2013
                if (dt_Details.Rows[0]["EMP_STATUS"] != System.DBNull.Value)
                {
                    if (Convert.ToInt32(dt_Details.Rows[0]["EMP_STATUS"]) == 1 || Convert.ToInt32(dt_Details.Rows[0]["EMP_STATUS"]) == 2 || Convert.ToInt32(dt_Details.Rows[0]["EMP_STATUS"]) == 3)
                    {
                        lbl_ReasonForSeperation.Visible = true;
                        txt_ReasonForSeperation.Visible = true;
                        lbl_Seperator.Visible = true;
                        txt_ReasonForSeperation.Text = dt_Details.Rows[0]["HR_MASTER_CODE"].ToString();
                        txt_ReasonForSeperation.Enabled = false;
                    }
                }
                //Inerted By Raghasudha on sep 25 2013
                if (dt_Details.Rows[0]["EMP_DOJ"] != System.DBNull.Value)
                {
                    txt_DOJ.SelectedDate = Convert.ToDateTime(Convert.ToString(dt_Details.Rows[0]["EMP_DOJ"]));
                    rdp_offDate.SelectedDate= Convert.ToDateTime(Convert.ToString(dt_Details.Rows[0]["EMP_DOJ"]));
                }
                else
                {
                    txt_DOJ.SelectedDate = null;
                    rdp_offDate.SelectedDate = null;
                }

                if (dt_Details.Rows[0]["EMP_DOC"] != System.DBNull.Value)
                {
                    txt_DOC.SelectedDate = Convert.ToDateTime(Convert.ToString(dt_Details.Rows[0]["EMP_DOC"]));
                }
                else
                {
                    txt_DOC.SelectedDate = null;
                }
                if (Convert.ToString(dt_Details.Rows[0]["EMP_BUSINESSUNIT_ID"]) != null)
                    ddl_BusinessUnit.SelectedIndex = ddl_BusinessUnit.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["EMP_BUSINESSUNIT_ID"]));
                LoadCurrency();

                LoadMode();
                //checking for organisation variable pay 

                //DataTable dt_isvp = BLL.get_Organisation_Isvp(Convert.ToString(Session["ORG_ID"]), Convert.ToString(ddl_BusinessUnit.SelectedValue));
                //if (Convert.ToString(dt_isvp.Rows[0]["BUSINESSUNIT_ISVARIABLEAMOUNT"]) == "True")// 1 MEANS THAT ORGANISATION IS HAVING VARIABLE PAY
                //{
                //    VariablePay.Visible = true;
                //    if (dt_Details.Rows[0]["EMP_ISVARIABLEAMOUNT"] != System.DBNull.Value)
                //    {
                //        chk_Isvariablepay.Checked = Convert.ToBoolean(dt_Details.Rows[0]["EMP_ISVARIABLEAMOUNT"]);
                //        if (dt_Details.Rows[0]["EMP_COUNT_VARIABLEAMOUNT"] != System.DBNull.Value)
                //            rntxt_Count.Text = Convert.ToString(dt_Details.Rows[0]["EMP_COUNT_VARIABLEAMOUNT"]);
                //        if (dt_Details.Rows[0]["EMP_VARIABLEAMOUNT"] != System.DBNull.Value)
                //            rntxt_Amount.Text = Convert.ToString(dt_Details.Rows[0]["EMP_VARIABLEAMOUNT"]);
                //    }
                //    else
                //    {
                //        chk_Isvariablepay.Checked = false;
                //        rntxt_Count.Text = string.Empty;
                //        rntxt_Amount.Text = string.Empty;
                //    }
                //    lbl_Isvariablepay.Visible = true;
                //    text.Visible = true;
                //    chk_Isvariablepay.Visible = true;
                //}
                //else
                //{
                //    chk_Isvariablepay.Enabled = false;
                //    VariablePay.Visible = false;
                //    lbl_Isvariablepay.Visible = false;
                //    text.Visible = false;
                //    chk_Isvariablepay.Visible = false;
                //}
                //getSupervisor();
                //getPosition();
                LoadDates();
                get_SupBusinessUnit();

                //getJobs();
                getJobs_Edit();
                LoadPeriod();
                if (Convert.ToString(dt_Details.Rows[0]["EMP_PERIOD_ID"]) != null && Convert.ToString(dt_Details.Rows[0]["EMP_PERIOD_ID"]) != string.Empty)
                    rcmb_Period.SelectedIndex = rcmb_Period.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["EMP_PERIOD_ID"]));
                else
                    rcmb_Period.SelectedIndex = 0;

                if (Convert.ToString(dt_Details.Rows[0]["EMP_JOBS_ID"]) != null)
                {
                    ddl_Jobs.SelectedIndex = ddl_Jobs.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["EMP_JOBS_ID"]));
                    //getJobs(Convert.ToString(dt_Details.Rows[0]["EMP_JOBS_ID"]));
                }
                else
                    ddl_Jobs.SelectedValue = null;
                //get period

                if (rcmb_Period.SelectedValue != string.Empty)
                {
                    SMHR_EMPLOYEE emp = new SMHR_EMPLOYEE();
                    emp.OPERATION = operation.Check1;
                    emp.EMP_ID = Convert.ToInt32(HF_EMPID.Value);
                    emp.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    emp.EMP_PERIOD_ID = Convert.ToInt32(rcmb_Period.SelectedValue);
                    DataTable DT = new DataTable();
                    DT = BLL.get_Employee(emp);
                    if (DT.Rows.Count > 0)
                    {
                        if (Convert.ToString(DT.Rows[0]["PAYROLL_STATUS"]) == "APPROVED")
                            rcmb_Period.Enabled = false;
                        else
                            rcmb_Period.Enabled = true;
                    }
                }
                else
                    rcmb_Period.SelectedIndex = 0;
                getPosition();
                if (Convert.ToString(dt_Details.Rows[0]["EMP_DESIGNATION_ID"]) != null)
                {
                    ddl_Designation.SelectedIndex = ddl_Designation.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["EMP_DESIGNATION_ID"]));
                    hdnDesignation.Value = dt_Details.Rows[0]["EMP_DESIGNATION_ID"].ToString();
                    //getJob(Convert.ToString(dt_Details.Rows[0]["EMP_DESIGNATION_ID"]));
                }
                else
                    ddl_Designation.SelectedValue = null;

                //Get Grades
                if (ddl_Designation.SelectedValue != string.Empty)
                {
                    ddl_Grade.Items.Clear();
                    /*SMHR_POSITIONS _obj_smhr_positions = new SMHR_POSITIONS();
                    _obj_smhr_positions.OPERATION = operation.POSITIONSGRADE;
                    _obj_smhr_positions.POSITIONS_ID = Convert.ToInt32(ddl_Designation.SelectedValue);
                    _obj_smhr_positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtPos = BLL.get_Positions(_obj_smhr_positions);*/

                    SMHR_EMPLOYEEGRADE _obj_SMHR_EMP_GRADE = new SMHR_EMPLOYEEGRADE();

                    _obj_SMHR_EMP_GRADE.OPERATION = operation.EmployeeGrade;
                    _obj_SMHR_EMP_GRADE.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

                    DataTable dtPos = BLL.GetEmployeeGrade(_obj_SMHR_EMP_GRADE);

                    ddl_Grade.DataSource = dtPos;
                    ddl_Grade.DataTextField = "EMPLOYEEGRADE_CODE";
                    ddl_Grade.DataValueField = "EMPLOYEEGRADE_ID";
                    ddl_Grade.DataBind();
                    ddl_Grade.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

                    /*ddl_Slabs.Items.Clear();
                    ddl_Slabs.DataSource = LoadSalarySlabs();
                    ddl_Slabs.DataValueField = "EMPLOYEEGRADE_SLAB_SRNO";
                    ddl_Slabs.DataTextField = "EMPLOYEEGRADE_SLAB_AMOUNT";
                    ddl_Slabs.DataBind();
                    ddl_Slabs.Items.Insert(0, new RadComboBoxItem { Text = "Select", Value = "0" });*/
                }

                //To show Increment Month
                //31.5.2016 divya
                /*if (!string.IsNullOrEmpty(Convert.ToString(dt_Details.Rows[0]["EMP_INCRMENTMONTH"])))
                {
                    rcmb_IncrementMonth.SelectedIndex = rcmb_IncrementMonth.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["EMP_INCRMENTMONTH"]));
                }
                else
                {
                    rcmb_IncrementMonth.ClearSelection();
                }*/

                //To show Increment Date
                var mindate = txt_IncrementDate.MinDate = DateTime.Now;
                if (!string.IsNullOrEmpty(Convert.ToString(dt_Details.Rows[0]["EMP_INCRMENTDATE"])))
                {
                    if (Convert.ToDateTime(dt_Details.Rows[0]["EMP_INCRMENTDATE"]).ToString("dd-MM-yyyy") == "01-01-1900")
                        txt_IncrementDate = null;
                    else if (Convert.ToDateTime(dt_Details.Rows[0]["EMP_INCRMENTDATE"]).ToString("yyyy") == "1900")
                        txt_IncrementDate = null;


                    else if (Convert.ToInt32(Convert.ToDateTime(dt_Details.Rows[0]["EMP_INCRMENTDATE"]).ToString("yyyyMMdd")) < Convert.ToInt32(mindate.ToString("yyyyMMdd")))
                        txt_IncrementDate.SelectedDate = null;
                    else
                        txt_IncrementDate.SelectedDate = Convert.ToDateTime(dt_Details.Rows[0]["EMP_INCRMENTDATE"]);
                }

                //else
                //{
                //    txt_IncrementDate.SelectedDate = null;
                //}
                //to show contract start date
                if (!string.IsNullOrEmpty(Convert.ToString(dt_Details.Rows[0]["EMP_CONTRACT_STARTDATE"])))
                {
                    if (Convert.ToDateTime(dt_Details.Rows[0]["EMP_CONTRACT_STARTDATE"]).ToString("dd-MM-yyyy") == "01-01-1900")
                        rdp_contract_start = null;
                    else if (Convert.ToDateTime(dt_Details.Rows[0]["EMP_CONTRACT_STARTDATE"]).ToString("yyyy") == "1900")

                        rdp_contract_start = null;

                    else
                        rdp_contract_start.SelectedDate = Convert.ToDateTime(dt_Details.Rows[0]["EMP_CONTRACT_STARTDATE"]);
                }
                /* else
                 {
                     rdp_contract_start.SelectedDate = null;
                 }*/
                //to show contract end date
                if (!string.IsNullOrEmpty(Convert.ToString(dt_Details.Rows[0]["EMP_CONTRACT_ENDDATE"])))
                {
                    if (Convert.ToDateTime(dt_Details.Rows[0]["EMP_CONTRACT_ENDDATE"]).ToString("dd-MM-yyyy") == "01-01-1900")
                        rdp_contract_end = null;
                    else if (Convert.ToDateTime(dt_Details.Rows[0]["EMP_CONTRACT_ENDDATE"]).ToString("yyyy") == "1900")

                        rdp_contract_end = null;

                    else
                        rdp_contract_end.SelectedDate = Convert.ToDateTime(dt_Details.Rows[0]["EMP_CONTRACT_ENDDATE"]);
                }
                /*else
                {
                    rdp_contract_end.SelectedDate = null;
                }*/
                if ((dt_Details.Rows[0]["EMP_GRADE"] != System.DBNull.Value) &&
                    (Convert.ToString(dt_Details.Rows[0]["EMP_PERIOD_ID"]) != null && Convert.ToString(dt_Details.Rows[0]["EMP_PERIOD_ID"]) != string.Empty))
                {
                    ddl_Grade.SelectedValue = Convert.ToString(dt_Details.Rows[0]["EMP_GRADE"]);

                    ddl_Slabs.Items.Clear();
                    ddl_Slabs.DataSource = LoadSalarySlabs1();
                    ddl_Slabs.DataValueField = "EMPLOYEEGRADE_SLAB_ID";
                    ddl_Slabs.DataTextField = "EMPLOYEEGRADE_SLAB_AMOUNT";
                    ddl_Slabs.DataBind();
                    ddl_Slabs.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                }
                else
                {
                    ddl_Slabs.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                    ddl_Grade.SelectedIndex = ddl_Slabs.SelectedIndex = 0;
                }

                if (dt_Details.Rows[0]["EMP_SLAB_ID"] != System.DBNull.Value)
                {
                    ddl_Slabs.SelectedValue = Convert.ToString(dt_Details.Rows[0]["EMP_SLAB_ID"]);
                }
                else
                {
                    ddl_Slabs.SelectedValue = null;
                }
                //if(dt_Details.Rows[0]["EMP_PERIOD_ID"]!=System.DBNull.Value)
                //{
                //    rcmb_Period.SelectedValue = Convert.ToString(dt_Details.Rows[0]["EMP_PERIOD_ID"]);

                //}
                //else
                //{
                //    rcmb_Period.SelectedValue = null;
                //}
                if (dt_Details.Rows[0]["EMP_DATEOFLASTPROMOTION"] != System.DBNull.Value)
                    txt_previousProm.SelectedDate = Convert.ToDateTime(Convert.ToString(dt_Details.Rows[0]["EMP_DATEOFLASTPROMOTION"]));
                else
                    txt_previousProm.SelectedDate = null;

                //if (Convert.ToString(dt_Details.Rows[0]["EMP_REPORTINGEMPLOYEE"]) != null)
                //    ddl_Supervisor.SelectedIndex = ddl_Supervisor.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["EMP_REPORTINGEMPLOYEE"]));
                //else
                //    ddl_Supervisor.SelectedValue = null;
                if (dt_Details.Rows[0]["EMP_RPTSTARTDATE"] != System.DBNull.Value)
                    txt_startDate.SelectedDate = Convert.ToDateTime(Convert.ToString(dt_Details.Rows[0]["EMP_RPTSTARTDATE"]));
                else
                    txt_startDate.SelectedDate = null;
                if (dt_Details.Rows[0]["EMP_RPTENDDATE"] != System.DBNull.Value)
                    txt_endDate.SelectedDate = Convert.ToDateTime(Convert.ToString(dt_Details.Rows[0]["EMP_RPTENDDATE"]));
                else
                    txt_endDate.SelectedDate = null;
                if (Convert.ToString(dt_Details.Rows[0]["EMP_SHIFT_ID"]) != null)
                    ddl_Shift.SelectedIndex = ddl_Shift.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["EMP_SHIFT_ID"]));
                else
                    ddl_Shift.SelectedValue = null;
                //if (Convert.ToString(dt_Details.Rows[0]["EMP_LOCATION_ID"]) != null)
                //    ddl_baseloc.SelectedIndex = ddl_baseloc.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["EMP_LOCATION_ID"]));
                //else
                //    ddl_baseloc.SelectedValue = null;
                //if (dt_Details.Rows[0]["EMP_GROSSSAL"] != System.DBNull.Value)
                //{
                //    txt_GrossSalary.Value = Convert.ToDouble(Convert.ToString(dt_Details.Rows[0]["EMP_GROSSSAL"]));
                //}
                //else
                //{
                //    txt_GrossSalary.Value = null;
                //}
                if (dt_Details.Rows[0]["EMP_BASIC"] != System.DBNull.Value)
                {
                    txt_BasicPay.Text = Convert.ToString(dt_Details.Rows[0]["EMP_BASIC"]);
                }
                else
                    txt_BasicPay.Text = string.Empty;

                if (Convert.ToString(dt_Details.Rows[0]["EMP_PAYMENTMODE_ID"]) != null)
                    ddl_Mode.SelectedIndex = ddl_Mode.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["EMP_PAYMENTMODE_ID"]));
                else
                    ddl_Mode.SelectedValue = null;
                if (Convert.ToString(dt_Details.Rows[0]["EMP_SALALRYSTRUCT_ID"]) != null)
                    ddl_SalaryStructure.SelectedIndex = ddl_SalaryStructure.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["EMP_SALALRYSTRUCT_ID"]));
                else
                    ddl_SalaryStructure.SelectedValue = null;
                if (Convert.ToString(dt_Details.Rows[0]["EMP_LEAVESTRUCT_ID"]) != null)
                    ddl_LeaveStructure.SelectedIndex = ddl_LeaveStructure.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["EMP_LEAVESTRUCT_ID"]));
                else
                    ddl_LeaveStructure.SelectedValue = null;
                if (dt_Details.Rows[0]["EMP_PROBATIONDATE"] != System.DBNull.Value)
                    txt_probDate.SelectedDate = Convert.ToDateTime(Convert.ToString(dt_Details.Rows[0]["EMP_PROBATIONDATE"]));
                else
                    txt_probDate.SelectedDate = null;
                rntxt_NoticePeriod.Value = Convert.ToDouble(Convert.ToString(dt_Details.Rows[0]["EMP_NOTICEPERIOD"]));
                if (dt_Details.Rows[0]["EMP_PICTURE"] != System.DBNull.Value)
                {
                    ViewState["fileLocation"] = dt_Details.Rows[0]["EMP_PICTURE"];
                    RBI_Employee_Image.ImageUrl = Convert.ToString(dt_Details.Rows[0]["EMP_PICTURE"]);
                }
                if (Convert.ToString(dt_Details.Rows[0]["EMP_PICTURE"]) == "")
                {
                    lnkPicDelete.Visible = false;
                }
                else
                {
                    lnkPicDelete.Visible = true;
                }

                if (dt_Details.Rows[0]["EMP_EMPLOYEETYPE"] != System.DBNull.Value)
                {
                    //ddl_EmpStatus.SelectedValue = Convert.ToString(dt_Details.Rows[0]["EMP_EMPLOYEETYPE"]).Trim();
                    ddl_EmpStatus.SelectedIndex = ddl_EmpStatus.FindItemIndexByText(Convert.ToString(dt_Details.Rows[0]["EMP_EMPLOYEETYPE"]));
                    //31.5.2016
                    /* if (Convert.ToString(dt_Details.Rows[0]["EMP_EMPLOYEETYPE"]).Trim() == "Contract")
                     {
                         contract.Visible = true;
                     }
                     else
                     {
                         contract.Visible = false;
                     }*/
                }
                else
                {
                    ddl_EmpStatus.SelectedValue = "0";
                }
                if (dt_Details.Rows[0]["EMP_PAYCURRENCY"] != System.DBNull.Value)
                {
                    ddl_Currency.SelectedValue = Convert.ToString(dt_Details.Rows[0]["EMP_PAYCURRENCY"]);
                }
                else
                {
                    ddl_Currency.SelectedValue = "0";
                }
                if (dt_Details.Rows[0]["EMP_EMPLOYEE_STATUS"] != System.DBNull.Value)
                {
                    ddl_Employee_Status.SelectedIndex = ddl_Employee_Status.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["EMP_EMPLOYEE_STATUS"]));
                }
                else
                {
                    ddl_Employee_Status.SelectedIndex = 0;
                }

                if (Convert.ToString(dt_Details.Rows[0]["EMP_SUPBUSINESSUNIT_ID"]) != null)
                {
                    ddl_Sup_BusinessUnit.SelectedIndex = ddl_Sup_BusinessUnit.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["EMP_SUPBUSINESSUNIT_ID"]));
                    //getJob(Convert.ToString(dt_Details.Rows[0]["EMP_SUPBUSINESSUNIT_ID"]));
                }
                else
                    ddl_Sup_BusinessUnit.SelectedValue = null;

                getSupervisor();
                if (Convert.ToString(dt_Details.Rows[0]["EMP_REPORTINGEMPLOYEE"]) != null)

                    ddl_Supervisor.SelectedIndex = ddl_Supervisor.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["EMP_REPORTINGEMPLOYEE"]));
                else
                    ddl_Supervisor.SelectedValue = null;


                if (dt_Details.Rows[0]["EMP_HOBBIES"] != System.DBNull.Value)
                {
                    rtxt_Hobbies.Text = Convert.ToString(Convert.ToString(dt_Details.Rows[0]["EMP_HOBBIES"]));
                }
                else
                    rtxt_Hobbies.Text = null;
                //31.5.2016
                /*if (dt_Details.Rows[0]["EMP_CONTRACT_DATE"] != System.DBNull.Value)
                {
                    txt_Contract_Date.SelectedDate = Convert.ToDateTime(Convert.ToString(dt_Details.Rows[0]["EMP_CONTRACT_DATE"]));
                }
                else
                    txt_Contract_Date.SelectedDate = null;*/

                //LoadDivision();
                //if (dt_Details.Rows[0]["EMP_DIV_ID"] != System.DBNull.Value)
                //{
                //    if (Convert.ToString(dt_Details.Rows[0]["EMP_DIV_ID"]) != "0")
                //        rcmb_Devision.SelectedIndex = Convert.ToInt32(rcmb_Devision.Items.FindItemIndexByValue(dt_Details.Rows[0]["EMP_DIV_ID"].ToString()));
                //}

                if (Convert.ToString(dt_Details.Rows[0]["EMP_ANNUALGROSSSALARY"]) != "")
                {
                    txt_AnnualGrossSalary.Text = Convert.ToString(dt_Details.Rows[0]["EMP_ANNUALGROSSSALARY"]);
                }
                if (Convert.ToString(dt_Details.Rows[0]["EMP_ANNUALBASICSALARY"]) != "")
                {
                    txt_AnnualBasicSalary.Text = Convert.ToString(dt_Details.Rows[0]["EMP_ANNUALBASICSALARY"]);
                }
                if (Convert.ToString(dt_Details.Rows[0]["EMP_REPORTINGEMPLOYEE"]) != "0")
                {
                    chk_Mandatory.Checked = true;
                }
                else
                {
                    chk_Mandatory.Checked = false;
                }
                if (dt_Details.Rows[0]["EMP_ISSUPERVISOR"] != System.DBNull.Value)
                {
                    if (Convert.ToBoolean(dt_Details.Rows[0]["EMP_ISSUPERVISOR"]) == true)
                    {
                        chk_Mandatory.Checked = true;
                    }
                    else
                    {
                        chk_Mandatory.Checked = false;
                    }
                }

                if (dt_Details.Rows[0]["EMP_CATEGORY_ID"] != System.DBNull.Value)
                {
                    rcmbCategory.SelectedIndex = Convert.ToInt32(rcmbCategory.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["EMP_CATEGORY_ID"])));
                }
                //if ((Convert.ToString(dt_Details.Rows[0]["EMP_GROSSSAL"]) == "0") && (Convert.ToString(dt_Details.Rows[0]["EMP_BASIC"]) == "0"))
                //{
                //    btn_Update.Visible = false;
                //}

                //ddl_EmpStatus.Enabled = true;
                //Load_Directorate();
                Load_Directorate_Edit();

                if (Convert.ToString(dt_Details.Rows[0]["EMP_DIRECTORATE_ID"]) != null)
                {
                    if (Convert.ToString(dt_Details.Rows[0]["EMP_DIRECTORATE_ID"]) != "0")
                        rcmb_Directorate.SelectedIndex = rcmb_Directorate.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["EMP_DIRECTORATE_ID"]));
                }
                else
                    rcmb_Directorate.SelectedValue = null;
                LoadDepartment();
                ddl_Department.SelectedIndex = ddl_Department.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["EMP_DEPARTMENT_ID"]));
                LoadDivision();
                if (dt_Details.Rows[0]["EMP_DIV_ID"] != System.DBNull.Value)
                {
                    if (Convert.ToString(dt_Details.Rows[0]["EMP_DIV_ID"]) != "0")
                        rcmb_Devision.SelectedIndex = Convert.ToInt32(rcmb_Devision.Items.FindItemIndexByValue(dt_Details.Rows[0]["EMP_DIV_ID"].ToString()));
                }
                rcmb_Devision_SelectedIndexChanged(null, null);
                if (dt_Details.Rows[0]["EMP_SUBDIVISION_ID"] != System.DBNull.Value)
                {
                    if (Convert.ToString(dt_Details.Rows[0]["EMP_SUBDIVISION_ID"]) != "0")
                        rcmb_SubDivision.SelectedIndex = Convert.ToInt32(rcmb_SubDivision.Items.FindItemIndexByValue(dt_Details.Rows[0]["EMP_SUBDIVISION_ID"].ToString()));
                }
                rtxt_MemberID.Text = Convert.ToString(dt_Details.Rows[0]["EMP_MEMBERID"]);
                rtxt_CurrentProject.Text = Convert.ToString(dt_Details.Rows[0]["EMP_CURRENTPROJECT"]);
                if (dt_Details.Rows[0]["EMP_ISMANUAL"] != System.DBNull.Value)
                {
                    chk_IsManual.Checked = Convert.ToBoolean(dt_Details.Rows[0]["EMP_ISMANUAL"]);
                }

                //To display County
                if (Convert.ToString(dt_Details.Rows[0]["COUNTY_ID"]) != "")
                {
                    rcmb_County.SelectedIndex = rcmb_County.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["COUNTY_ID"]));
                }
                //if (Convert.ToString(dt_Details.Rows[0]["EMP_PROJECT_ID"]) != "")
                //{
                //    rcmbProject.SelectedIndex = rcmbProject.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["EMP_PROJECT_ID"]));

                //}
                //if (Convert.ToString(dt_Details.Rows[0]["EMP_FUNDING_ID"]) != "")
                //{
                //    rcmb_Funding.SelectedIndex = rcmb_Funding.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["EMP_FUNDING_ID"]));

                //}

                _obj_smhr_applicant = new SMHR_APPLICANT();
                _obj_smhr_applicant.OPERATION = operation.Select;
                _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(Convert.ToString(dt_Details.Rows[0][2]));
                _obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt = BLL.get_Applicant(_obj_smhr_applicant);
                if (dt.Rows.Count != 0)
                {
                    //_lbl_App_ID = Convert.ToString(dt_Details.Rows[0][2]);
                    HF_APID.Value = Convert.ToString(dt_Details.Rows[0][2]);
                    ddl_Title.SelectedValue = Convert.ToString(dt.Rows[0]["APPLICANT_TITLE"]);
                    txt_FirstName.Text = Convert.ToString(dt.Rows[0]["APPLICANT_FIRSTNAME"]);
                    txt_AppMiddleName.Text = Convert.ToString(dt.Rows[0]["APPLICANT_MIDDLENAME"]);
                    txt_AppLastName.Text = Convert.ToString(dt.Rows[0]["APPLICANT_LASTNAME"]);
                    txt_DOB.SelectedDate = Convert.ToDateTime(Convert.ToString(dt.Rows[0]["APPLICANT_DOB"]));
                    ddl_Gender.SelectedIndex = ddl_Gender.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["APPLICANT_GENDER"]));
                    if (dt.Rows[0]["APPLICANT_BLOODGROUP"] != System.DBNull.Value)
                    {
                        ddl_BloodGroup.SelectedIndex = ddl_BloodGroup.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["APPLICANT_BLOODGROUP"]).Trim());
                    }
                    ddl_Religion.SelectedIndex = ddl_Religion.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["APPLICANT_RELIGION_ID"]));
                    ddl_Nationality.SelectedIndex = ddl_Nationality.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["APPLICANT_NATIONALITY_ID"]));
                    ddl_Tribe.SelectedIndex = ddl_Tribe.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["APPLICANT_TRIBE_ID"]));
                    ddl_MaritalStatus.SelectedIndex = ddl_MaritalStatus.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["APPLICANT_MARITALSTATUS"]));
                    txt_Address.Text = Convert.ToString(dt.Rows[0]["APPLICANT_ADDRESS"]);
                    txt_Remarks.Text = Convert.ToString(dt.Rows[0]["APPLICANT_REMARKS"]);
                    getDates();
                    LoadProject();
                    LoadFunding();
                    LoadContact();
                    LoadExperience();
                    LoadLanguage();
                    LoadQualification();
                    LoadLanguage();
                    LoadReference();
                    LoadSkill();
                    LoadSwipe();
                    LoadFamily();
                    LoadOTInfo();
                    LoadWeekOff();
                    LoadOtherDetails();
                    LoadImportantDates();
                    LoadPhysicalDetails();
                    LoadNewContactDetails();
                    LoadSelfLoginDetails();
                }
            }

            #region OtherDetailsNewFields
            rtbActivity.Text = Convert.ToString(dt_Details.Rows[0]["EMP_ACTIVITY"]);
            rtbProgramme.Text = Convert.ToString(dt_Details.Rows[0]["EMP_PROGRAMME"]);
            rtbOrgUnit.Text = Convert.ToString(dt_Details.Rows[0]["EMP_ORGUNIT"]);
            rtbIntervention.Text = Convert.ToString(dt_Details.Rows[0]["EMP_INTERVENTION"]);
            rtbFocusArea.Text = Convert.ToString(dt_Details.Rows[0]["EMP_FOCUS_AREA"]);
            rtbResultArea.Text = Convert.ToString(dt_Details.Rows[0]["EMP_RESULT_AREA"]);
            rtbOutCome.Text = Convert.ToString(dt_Details.Rows[0]["EMP_OUTCOME"]);
            #endregion
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


    }


    //protected void btn_Onsite_Save_Click(object sender, EventArgs e)
    //{
    //    _obj_OnsiteDetails = new SMHR_EMP_ONSITEDETAILS();
    //    _obj_OnsiteDetails.ONSITEDETAILS_EMP_ID = Convert.ToInt32(HF_EMPID.Value.ToString());
    //    _obj_OnsiteDetails.ONSITEDETAILS_FROMDATE = Convert.ToDateTime(rdtp_FromDate.SelectedDate).Date;
    //    _obj_OnsiteDetails.ONSITEDETAILS_TODATE = Convert.ToDateTime(rdtp_ToDate.SelectedDate).Date;
    //    _obj_OnsiteDetails.ONSITEDETAILS_LOCATION = Convert.ToInt32(rcmb_OnSiteLocation.SelectedItem.Value);
    //    _obj_OnsiteDetails.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
    //    _obj_OnsiteDetails.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
    //    switch (((Button)sender).ID.ToUpper())
    //    {
    //        case "BTN_ONSITE_SAVE":
    //            _obj_OnsiteDetails.MODE = 1;
    //            if (BLL.set_OnsiteDetails(_obj_OnsiteDetails))
    //                BLL.ShowMessage(this, "Information Saved Successfully");
    //            else
    //                BLL.ShowMessage(this, "Information Not Saved");
    //            break;

    //        case "BTN_ONSITE_UPDATE":

    //            _obj_OnsiteDetails.ONSITEDETAILS_ID = Convert.ToInt32(hf_OnsiteID.Value);
    //            _obj_OnsiteDetails.MODE = 2;
    //            if (BLL.set_OnsiteDetails(_obj_OnsiteDetails))
    //                BLL.ShowMessage(this, "Information Updated Successfully");
    //            else
    //                BLL.ShowMessage(this, "Information Not Updated");
    //            break;
    //    }

    //}
    //protected void lnk_Onsite_Edit_Command(object sender, CommandEventArgs e)
    //{
    //    _obj_OnsiteDetails = new SMHR_EMP_ONSITEDETAILS();
    //    _obj_OnsiteDetails.MODE = 4;
    //    _obj_OnsiteDetails.ONSITEDETAILS_ID = Convert.ToInt32(e.CommandArgument);
    //    hf_OnsiteID.Value = Convert.ToString(e.CommandArgument);
    //    DataTable dt = BLL.get_OnsiteDetails(_obj_OnsiteDetails);
    //    rdtp_FromDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["ONSITEDETAILS_FROMDATE"]);
    //    rdtp_ToDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["ONSITEDETAILS_TODATE"]);
    //    rcmb_OnSiteLocation.SelectedIndex = rcmb_OnSiteLocation.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["ONSITEDETAILS_LOCATION"]));
    //    btn_Onsite_Save.Visible = false;
    //    btn_Onsite_Update.Visible = true;
    //}
    //protected void btn_Onsite_Cancel_Click(object sender, EventArgs e)
    //{
    //    btn_Onsite_Save.Visible = true;
    //    btn_Onsite_Update.Visible = false;
    //    rdtp_FromDate.SelectedDate = null;
    //    rdtp_ToDate.SelectedDate = null;
    //    rcmb_OnSiteLocation.SelectedIndex = 0;
    //}
    //private void LoadShiftDetails()
    //{
    //    _obj_ShiftDetails = new SMHR_EMP_SHIFTDETAILS();
    //    _obj_ShiftDetails.MODE = 3;
    //    _obj_ShiftDetails.SHIFTDETAILS_EMP_ID = Convert.ToInt32(HF_EMPID.Value.ToString());
    //    rg_Shift.DataSource = BLL.get_ShiftDetails(_obj_ShiftDetails);
    //    rg_Shift.DataBind();
    //}
    //protected void btn_Shift_Save_Click(object sender, EventArgs e)
    //{
    //    _obj_ShiftDetails = new SMHR_EMP_SHIFTDETAILS();
    //    _obj_ShiftDetails.SHIFTDETAILS_EMP_ID = Convert.ToInt32(HF_EMPID.Value.ToString());
    //    _obj_ShiftDetails.SHIFTDETAILS_FROMDATE = Convert.ToDateTime(rdtp_ShiftFromDate.SelectedDate).Date;
    //    _obj_ShiftDetails.SHIFTDETAILS_TODATE = Convert.ToDateTime(rdtp_ShiftToDate.SelectedDate).Date;
    //    _obj_ShiftDetails.SHIFTDETAILS_SHIFT_ID = Convert.ToInt32(rcmb_ShiftDetails.SelectedItem.Value);
    //    _obj_ShiftDetails.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
    //    _obj_ShiftDetails.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
    //    switch (((Button)sender).ID.ToUpper())
    //    {
    //        case "BTN_SHIFT_SAVE":
    //            _obj_ShiftDetails.MODE = 1;
    //            if (BLL.set_ShiftDetails(_obj_ShiftDetails))
    //                BLL.ShowMessage(this, "Information Saved Successfully");
    //            else
    //                BLL.ShowMessage(this, "Information Not Saved");
    //            break;

    //        case "BTN_SHIFT_UPDATE":

    //            _obj_ShiftDetails.SHIFTDETAILS_ID = Convert.ToInt32(hf_Shift_ID.Value);
    //            _obj_ShiftDetails.MODE = 2;
    //            if (BLL.set_ShiftDetails(_obj_ShiftDetails))
    //                BLL.ShowMessage(this, "Information Updated Successfully");
    //            else
    //                BLL.ShowMessage(this, "Information Not Updated");
    //            break;
    //    }
    //    btn_Shift_Save.Visible = true;
    //    btn_Shift_Update.Visible = false;
    //    rdtp_ShiftFromDate.SelectedDate = null;
    //    rdtp_ShiftToDate.SelectedDate = null;
    //    rcmb_ShiftDetails.SelectedIndex = 0;
    //    LoadShiftDetails();
    //}
    //protected void lnk_Shift_Edit_Command(object sender, CommandEventArgs e)
    //{
    //    _obj_ShiftDetails = new SMHR_EMP_SHIFTDETAILS();
    //    _obj_ShiftDetails.MODE = 4;
    //    _obj_ShiftDetails.SHIFTDETAILS_ID = Convert.ToInt32(e.CommandArgument);
    //    hf_Shift_ID.Value = Convert.ToString(e.CommandArgument);
    //    DataTable dt = BLL.get_ShiftDetails(_obj_ShiftDetails);
    //    rdtp_ShiftFromDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["SHIFTDETAILS_FROMDATE"]);
    //    rdtp_ShiftToDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["SHIFTDETAILS_TODATE"]);
    //    rcmb_ShiftDetails.SelectedIndex = rcmb_ShiftDetails.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["SHIFTDETAILS_SHIFT_ID"]));
    //    btn_Shift_Save.Visible = false;
    //    btn_Shift_Update.Visible = true;
    //}
    //protected void btn_Shift_Cancel_Click(object sender, EventArgs e)
    //{
    //    btn_Shift_Save.Visible = true;
    //    btn_Shift_Update.Visible = false;
    //    rdtp_ShiftToDate.SelectedDate = null;
    //    rdtp_ShiftFromDate.SelectedDate = null;
    //    rcmb_ShiftDetails.SelectedIndex = 0;
    //}
    private void getJob(string strPosition)
    {
        //if (strPosition != "")
        //{
        //    _obj_smhr_positions = new SMHR_POSITIONS();
        //    _obj_smhr_positions.OPERATION = operation.Empty;
        //    _obj_smhr_positions.POSITIONS_ID = Convert.ToInt32(strPosition);
        //    _obj_smhr_positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
        //    DataTable dt = BLL.get_Positions(_obj_smhr_positions);
        //    if (dt.Rows.Count != 0)
        //    {
        //        //lbl_jobName.Text = Convert.ToString(dt.Rows[0]["JOBS_CODE"]);
        //        if (Convert.ToString(dt.Rows[0]["JOBS_ID"]) != "")
        //        {
        //            SMHR_JOBS _obj_Jobs = new SMHR_JOBS();
        //            _obj_Jobs.JOBS_ID = Convert.ToInt32(dt.Rows[0]["JOBS_ID"]);
        //            DataTable dt1 = BLL.get_Jobs(_obj_Jobs);
        //            maxsal = Convert.ToDouble(dt1.Rows[0]["JOBS_MAXSAL"]);
        //            minsal = Convert.ToDouble(dt1.Rows[0]["JOBS_MINSAL"]);
        //            if (txt_GrossSalary.Text != "")
        //            {
        //                //for validating job minsal and maxsal with the gross                        
        //                if (!((Convert.ToDouble(txt_GrossSalary.Text) >= minsal) && (Convert.ToDouble(txt_GrossSalary.Text) <= maxsal)))
        //                {
        //                    BLL.ShowMessage(this, "Gross Must be in the range of Selected Job Min and Max Salary:" + minsal + "-" + maxsal);
        //                    txt_GrossSalary.Text = "";
        //                    txt_BasicPay.Text = "";
        //                    return;
        //                }

        //            }
        //        }
        //    }
        //}
    }
    private void getJobs()
    {
        try
        {
            if (ddl_BusinessUnit.SelectedIndex > 0)
            {
                // added by joseph on 2009-11-21
                ddl_Jobs.Items.Clear();
                SMHR_JOBS _obj_Jobs = new SMHR_JOBS();
                //_obj_Jobs.OPERATION = operation.Select;
                //_obj_Jobs.OPERATION = operation.Delete1;
                _obj_Jobs.OPERATION = operation.Get;
                _obj_Jobs.BUID = Convert.ToInt32(ddl_BusinessUnit.SelectedItem.Value);
                _obj_Jobs.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable DT = BLL.get_Jobs(_obj_Jobs);
                ddl_Jobs.DataSource = DT;
                ddl_Jobs.DataTextField = "JOBS_CODE";
                ddl_Jobs.DataValueField = "JOBS_ID";
                ddl_Jobs.DataBind();
                ddl_Jobs.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                //
            }
            else
            {
                ddl_Jobs.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                ddl_Designation.Items.Clear();
                ddl_Designation.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                ddl_Grade.Items.Clear();
                //ddl_Grade.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void getJobs_Edit()
    {
        try
        {
            if (ddl_BusinessUnit.SelectedIndex > 0)
            {
                // added by joseph on 2009-11-21
                ddl_Jobs.Items.Clear();
                SMHR_JOBS _obj_Jobs = new SMHR_JOBS();
                _obj_Jobs.OPERATION = operation.Select;
                _obj_Jobs.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable DT = BLL.get_Jobs(_obj_Jobs);
                ddl_Jobs.DataSource = DT;
                ddl_Jobs.DataTextField = "JOBS_CODE";
                ddl_Jobs.DataValueField = "JOBS_ID";
                ddl_Jobs.DataBind();
                ddl_Jobs.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                //
            }
            else
            {
                ddl_Jobs.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                ddl_Designation.Items.Clear();
                ddl_Designation.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                ddl_Grade.Items.Clear();
                //ddl_Grade.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void getPosition()
    {
        try
        {
            if (ddl_BusinessUnit.SelectedIndex > 0 && ddl_Jobs.SelectedValue != string.Empty)
            {
                // added by joseph on 2009-11-21
                ddl_Designation.Items.Clear();
                SMHR_POSITIONS _obj_smhr_positions = new SMHR_POSITIONS();
                _obj_smhr_positions.OPERATION = operation.JOBPOSITIONS;
                _obj_smhr_positions.POSITIONS_JOBSID = Convert.ToInt32(ddl_Jobs.SelectedValue);
                _obj_smhr_positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtPos = BLL.get_Positions(_obj_smhr_positions);
                ddl_Designation.DataSource = dtPos;
                ddl_Designation.DataTextField = "POSITIONS_CODE";
                ddl_Designation.DataValueField = "POSITIONS_ID";
                ddl_Designation.DataBind();
                ddl_Designation.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                //
            }
            else
            {
                ddl_Designation.Items.Clear();
                ddl_Designation.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

                //ddl_Grade.Items.Clear();
                //ddl_Grade.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region MainMethods

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_ORGANISATION _obj_Smhr_Organisation = new SMHR_ORGANISATION();
            _obj_Smhr_Organisation.MODE = 8;
            _obj_Smhr_Organisation.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_Organisation(_obj_Smhr_Organisation);
            _obj_smhr_employee.OPERATION = operation.EmployeeCount;
            _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtDetails = BLL.get_Employee(_obj_smhr_employee);
            string Val = BLL.PasswordDecrypt(Convert.ToString(dt.Rows[0]["ORGANISATION_EMPLOYEES"]));
            string strVal = Convert.ToString(dtDetails.Rows[0]["EMPCOUNT"]);
            if (dtDetails.Rows.Count != 0)
            {
                if (Val != strVal)
                {
                    if (Convert.ToInt32(Val) > Convert.ToInt32(strVal))
                    {



                        if (txt_DOB.SelectedDate == null)
                        {
                            BLL.ShowMessage(this, "Please Enter Valid Date of Birth "); return;
                        }
                        if (txt_DOJ.SelectedDate == null)
                        {
                            BLL.ShowMessage(this, "Please Enter Valid Date of Join "); return;
                        }
                        rtxt_pwd.Attributes.Add("value", strPass);
                        rtxt_passcode.Attributes.Add("value", strPass1);
                        if (chk_Friday.Checked == true || chk_Monday.Checked == true || chk_Saturday.Checked == true
                               || chk_Sunday.Checked == true || chk_thursday.Checked == true || chk_tuesday.Checked == true
                               || chk_wednesday.Checked == true)
                        {
                            if (rdp_offDate.SelectedDate == null)
                            {
                                BLL.ShowMessage(this, "Enter Weekly off Effective Date.");
                                return;
                            }
                        }
                        if ((Convert.ToString(Session["Supervisor"]) != string.Empty))
                        {
                            Session["Supervisor"] = null;
                        }

                        if (chk_Mandatory.Checked)
                        {
                            if (ddl_Supervisor.SelectedIndex <= 0)
                            {
                                BLL.ShowMessage(this, "Supervisor is Mandatory");
                                return;
                            }
                        }
                        //to check contract dates

                        if (rdp_contract_start.SelectedDate != null || rdp_contract_end.SelectedDate != null)
                        {
                            if (rdp_contract_start.SelectedDate != null && rdp_contract_end.SelectedDate == null)
                            {
                                BLL.ShowMessage(this, "Contract end date is mandatory..!");
                                rdp_contract_end.Focus();
                                return;
                            }
                            if (rdp_contract_start.SelectedDate == null && rdp_contract_end.SelectedDate != null)
                            {
                                BLL.ShowMessage(this, "Contract start date is mandatory..!");
                                rdp_contract_start.Focus();
                                return;
                            }
                        }

                        /* To check if MemberID/PensionID already exists */
                        if (Convert.ToString(rtxt_MemberID.Text.Replace("'", "''")) != string.Empty)
                        {
                            _obj_smhr_employee = new SMHR_EMPLOYEE();
                            _obj_smhr_employee.EMP_MEMBERID = BLL.ReplaceQuote(Convert.ToString(rtxt_MemberID.Text.Replace("'", "''")).Trim());
                            _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_smhr_employee.OPERATION = operation.CHECKDUPLICATE;
                            if (BLL.get_EmployeeStatus(_obj_smhr_employee))
                            {
                                BLL.ShowMessage(this, "Member ID Already Exists. Please enter another Member ID");
                                RMP_EmployeePage.SelectedIndex = 12;
                                RTS_Employee.SelectedIndex = 12;
                                rtxt_MemberID.Text = string.Empty;
                                rtxt_MemberID.Focus();
                                return;
                            }
                        }
                        /* To check if MemberID/PensionID already exists */

                        if (Convert.ToString(rtxt_EmailID.Text.Replace("'", "''")) != string.Empty)
                        {
                            _obj_smhr_employee = new SMHR_EMPLOYEE();
                            _obj_smhr_employee.EMP_EMAILID = BLL.ReplaceQuote(Convert.ToString(rtxt_EmailID.Text.Replace("'", "''")).Trim());
                            _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_smhr_employee.OPERATION = operation.CHK_EMAILORG;//operation.CHK_EMPMAIL;
                            if (Convert.ToInt32(BLL.get_Employee(_obj_smhr_employee).Rows[0][0]) > 0)
                            {
                                BLL.ShowMessage(this, "Email ID Already Exists.Please enter another Email ID");
                                RMP_EmployeePage.SelectedIndex = 13;
                                rtxt_EmailID.Text = "";
                                rtxt_EmailID.Focus();
                                return;
                            }
                        }
                        if (Convert.ToString(txtSkypeId.Text.Replace("'", "''")).Trim() != string.Empty)
                        {
                            _obj_smhr_employee.EMP_SKYPEID = Convert.ToString(txtSkypeId.Text.Replace("'", "''")).Trim();
                            _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_smhr_employee.EMP_BUSINESSUNIT_ID = Convert.ToInt32(ddl_BusinessUnit.SelectedItem.Value);
                            _obj_smhr_employee.OPERATION = operation.CheckSkype;
                            DataTable dt_empskype = BLL.get_EMP_NEWCONTACTS(_obj_smhr_employee);
                            if (dt_empskype.Rows.Count > 0)
                            {
                                if (Convert.ToInt32(dt_empskype.Rows[0][0].ToString()) > 0)
                                {
                                    BLL.ShowMessage(this, "This Skype-Id Already Exists");
                                    RMP_EmployeePage.SelectedIndex = 13;
                                    txtSkypeId.Text = "";
                                    txtSkypeId.Focus();
                                    return;
                                }
                            }
                        }
                        //if (chk_Isvariablepay.Checked)
                        //{
                        //    if ((rntxt_Amount.Text == string.Empty) || (rntxt_Count.Text == string.Empty))
                        //    {
                        //        BLL.ShowMessage(this, "Variable Amount and Payable Times Should be Greater than Zero");
                        //        return;
                        //    }
                        //}
                        if (chk_IsManual.Checked)
                        {
                            _obj_smhr_employee = new SMHR_EMPLOYEE();
                            _obj_smhr_employee.OPERATION = operation.Get;
                            _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_smhr_employee.EMP_EMPCODE = rtxt_empcode.Text;
                            if (Convert.ToString(BLL.get_empcode(_obj_smhr_employee).Rows[0]["Count"]) != "0")
                            {
                                BLL.ShowMessage(this, "Employee Code Already Exists");
                                rtxt_empcode.Text = string.Empty;
                                rtxt_empcode.Focus();
                                return;
                            }
                        }
                        if (ddl_Applicant.SelectedValue == "")
                        {
                            //Saving Applicant
                            bool status = false;
                            //if (salCheck = chk_Salary())
                            //{
                            getCode();
                            _obj_smhr_applicant = new SMHR_APPLICANT();
                            _obj_smhr_applicant.OPERATION = operation.Insert;
                            _obj_smhr_applicant.APPLICANT_CODE = Convert.ToString(strAppcode);
                            _obj_smhr_applicant.APPLICANT_TITLE = Convert.ToString(ddl_Title.SelectedValue);
                            _obj_smhr_applicant.APPLICANT_FIRSTNAME = Convert.ToString(txt_FirstName.Text.Replace("'", "''"));
                            _obj_smhr_applicant.APPLICANT_MIDDLENAME = Convert.ToString(txt_AppMiddleName.Text.Replace("'", "''"));
                            _obj_smhr_applicant.APPLICANT_LASTNAME = Convert.ToString(txt_AppLastName.Text.Replace("'", "''"));
                            ViewState["emp_name"] = string.Concat(Convert.ToString(_obj_smhr_applicant.APPLICANT_FIRSTNAME), ' ', Convert.ToString(_obj_smhr_applicant.APPLICANT_MIDDLENAME), ' ', Convert.ToString(_obj_smhr_applicant.APPLICANT_LASTNAME));
                            if (txt_DOB.SelectedDate != null)
                                _obj_smhr_applicant.APPLICANT_DOB = txt_DOB.SelectedDate.Value;
                            _obj_smhr_applicant.APPLICANT_GENDER = Convert.ToString(ddl_Gender.SelectedValue);
                            if (ddl_BloodGroup.SelectedValue == "Select")
                            {
                                _obj_smhr_applicant.APPLICANT_BLOODGROUP = null;
                            }
                            else
                            {
                                _obj_smhr_applicant.APPLICANT_BLOODGROUP = Convert.ToString(ddl_BloodGroup.SelectedValue);
                            }
                            _obj_smhr_applicant.APPLICANT_RELIGION_ID = ddl_Religion.SelectedValue != string.Empty ? Convert.ToInt32(ddl_Religion.SelectedValue) : 0;
                            _obj_smhr_applicant.APPLICANT_STATUS = "Selected";
                            _obj_smhr_applicant.APPLICANT_NATIONALITY_ID = Convert.ToInt32(ddl_Nationality.SelectedValue);
                            _obj_smhr_applicant.APPLICANT_TRIBE_ID = ddl_Tribe.SelectedValue != string.Empty ? Convert.ToInt32(ddl_Tribe.SelectedValue) : 0;
                            _obj_smhr_applicant.APPLICANT_MARITALSTATUS = Convert.ToString(ddl_MaritalStatus.SelectedValue);
                            _obj_smhr_applicant.APPLICANT_ADDRESS = Convert.ToString(txt_Address.Text.Replace("'", "''"));
                            _obj_smhr_applicant.APPLICANT_REMARKS = Convert.ToString(txt_Remarks.Text.Replace("'", "''"));
                            _obj_smhr_applicant.APPLICANT_TYPE = "DIRECT";
                            _obj_smhr_applicant.APPLICANT_CREATEDBY = Convert.ToString(Session["USER_ID"]);
                            _obj_smhr_applicant.APPLICANT_CREATEDDATE = DateTime.Now;
                            _obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            if (Convert.ToInt32(Session["ORG_ID"]) == 0)
                                return;
                            status = BLL.set_Applicant(_obj_smhr_applicant);
                            if (status == true)
                            {
                                //getCode();
                                _obj_smhr_applicant.OPERATION = operation.Check;
                                _obj_smhr_applicant.APPLICANT_CODE = Convert.ToString(strAppcode);
                                _obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dt_Det = BLL.get_Applicant(_obj_smhr_applicant);
                                if (dt_Det.Rows.Count != 0)
                                {
                                    HF_APID.Value = "";
                                    HF_APID.Value = Convert.ToString(dt_Det.Rows[0][0]);
                                    //_lbl_App_ID = "";
                                    //_lbl_App_ID = Convert.ToString(dt_Det.Rows[0][0]);
                                }
                                //Saving Employee With Applicant ID
                                _obj_smhr_employee = new SMHR_EMPLOYEE();
                                if (chk_IsManual.Checked)
                                {
                                    _obj_smhr_employee.EMP_EMPCODE = rtxt_empcode.Text.Trim();
                                    lbl_Code.Text = rtxt_empcode.Text.Trim();

                                }
                                else
                                {
                                    getEmpCode();
                                    _obj_smhr_employee.EMP_EMPCODE = Convert.ToString(lbl_Code.Text.Replace("'", "''"));
                                }
                                _obj_smhr_employee.OPERATION = operation.Insert;
                                _obj_smhr_employee.EMP_APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                                _obj_smhr_employee.EMP_DOJ = Convert.ToDateTime(txt_DOJ.SelectedDate.Value);
                                if (txt_DOC.SelectedDate.HasValue)
                                {
                                    _obj_smhr_employee.EMP_DOC = txt_DOC.SelectedDate.Value;
                                }
                                else
                                {
                                    _obj_smhr_employee.EMP_DOC = null;
                                }
                                if (Convert.ToInt32(ddl_Jobs.SelectedValue) > 0)
                                {
                                    _obj_smhr_employee.EMP_JOBS_ID = Convert.ToInt32(ddl_Jobs.SelectedValue);
                                }
                                else
                                {
                                    _obj_smhr_employee.EMP_JOBS_ID = 0;
                                }
                                if (Convert.ToInt32(ddl_Designation.SelectedValue) > 0)
                                {
                                    _obj_smhr_employee.EMP_DESIGNATION_ID = Convert.ToInt32(ddl_Designation.SelectedValue);
                                }
                                else
                                {
                                    _obj_smhr_employee.EMP_DESIGNATION_ID = 0;
                                }
                                if (Convert.ToInt32(ddl_BusinessUnit.SelectedValue) > 0)
                                {
                                    _obj_smhr_employee.EMP_BUSINESSUNIT_ID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
                                }
                                else
                                {
                                    _obj_smhr_employee.EMP_BUSINESSUNIT_ID = 0;
                                }
                                if (txt_previousProm.SelectedDate.HasValue)
                                    _obj_smhr_employee.EMP_DATEOFLASTPROMOTION = txt_previousProm.SelectedDate;
                                else
                                    _obj_smhr_employee.EMP_DATEOFLASTPROMOTION = null;
                                if (ddl_Grade.SelectedValue != string.Empty)
                                {
                                    _obj_smhr_employee.EMP_GRADE = Convert.ToInt32(ddl_Grade.SelectedValue);
                                }
                                else
                                {
                                    _obj_smhr_employee.EMP_GRADE = null;
                                }
                                if (ddl_Slabs.SelectedValue != string.Empty)
                                {
                                    _obj_smhr_employee.EMP_SLAB_ID = Convert.ToInt32(ddl_Slabs.SelectedValue);
                                }
                                else
                                {
                                    _obj_smhr_employee.EMP_SLAB_ID = null;
                                }
                                if (ddl_Supervisor.SelectedIndex != 0)
                                    _obj_smhr_employee.EMP_REPORTINGEMPLOYEE = Convert.ToInt32(ddl_Supervisor.SelectedValue);
                                if (txt_startDate.SelectedDate.HasValue)
                                    _obj_smhr_employee.EMP_RPTSTARTDATE = txt_startDate.SelectedDate;
                                else
                                    _obj_smhr_employee.EMP_RPTSTARTDATE = null;
                                if (txt_endDate.SelectedDate.HasValue)
                                    _obj_smhr_employee.EMP_RPTENDDATE = txt_endDate.SelectedDate.Value;
                                else
                                    _obj_smhr_employee.EMP_RPTENDDATE = null;
                                if (ddl_Shift.SelectedIndex != -1)
                                    _obj_smhr_employee.EMP_SHIFT_ID = Convert.ToInt32(ddl_Shift.SelectedValue);
                                // string[] str = Convert.ToString(ddl_Slabs.Text).Replace(" )", "").Split('(');
                                string[] str = Convert.ToString(ddl_Slabs.Text).Replace(" )", "").Replace(")", "").Split('(');
                                _obj_smhr_employee.EMP_GROSSSAL = Convert.ToDouble(str[1].Trim());
                                _obj_smhr_employee.EMP_BASIC = Convert.ToDouble(txt_BasicPay.Text); //Convert.ToDouble(str[1].Trim());
                                _obj_smhr_employee.EMP_PAYMENTMODE_ID = Convert.ToInt32(ddl_Mode.SelectedValue);
                                _obj_smhr_employee.EMP_SALALRYSTRUCT_ID = Convert.ToInt32(ddl_SalaryStructure.SelectedValue);
                                _obj_smhr_employee.EMP_LEAVESTRUCT_ID = Convert.ToInt32(ddl_LeaveStructure.SelectedValue);
                                if (txt_probDate.SelectedDate.HasValue)
                                    _obj_smhr_employee.EMP_PROBATIONDATE = txt_probDate.SelectedDate;
                                else
                                    _obj_smhr_employee.EMP_PROBATIONDATE = null;

                                if (rdp_contract_start.SelectedDate.HasValue)
                                    _obj_smhr_employee.EMP_CONTRACT_STARTDATE = Convert.ToDateTime(rdp_contract_start.SelectedDate);
                                else
                                    _obj_smhr_employee.EMP_CONTRACT_STARTDATE = null;

                                if (rdp_contract_end.SelectedDate.HasValue)
                                    _obj_smhr_employee.EMP_CONTRACT_ENDDATE = Convert.ToDateTime(rdp_contract_end.SelectedDate);
                                else
                                    _obj_smhr_employee.EMP_CONTRACT_ENDDATE = null;

                                if (txt_IncrementDate.SelectedDate.HasValue)
                                    _obj_smhr_employee.EMP_INCREMENTDATE = Convert.ToDateTime(txt_IncrementDate.SelectedDate);
                                else
                                    _obj_smhr_employee.EMP_INCREMENTDATE = null;

                                if (rtxt_Hobbies.Text != "")
                                {
                                    _obj_smhr_employee.EMP_HOBBIES = Convert.ToString(rtxt_Hobbies.Text);
                                }
                                else
                                {
                                    _obj_smhr_employee.EMP_HOBBIES = null;
                                }


                                _obj_smhr_employee.EMP_NOTICEPERIOD = Convert.ToInt32(rntxt_NoticePeriod.Value);
                                _obj_smhr_employee.EMP_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                                _obj_smhr_employee.EMP_CREATEDDATE = DateTime.Now;
                                _obj_smhr_employee.APPLICANT_TYPE = "DIRECT";
                                //_obj_smhr_employee.EMP_EMPLOYEETYPE = Convert.ToString(ddl_EmpStatus.SelectedItem.Value);
                                _obj_smhr_employee.EMP_EMPLOYEETYPE = Convert.ToString(ddl_EmpStatus.SelectedItem.Text);
                                _obj_smhr_employee.EMP_PAYCURRENCY = Convert.ToInt32(ddl_Currency.SelectedValue);
                                _obj_smhr_employee.EMP_DEPARTMENT_ID = ddl_Department.SelectedValue != string.Empty ? Convert.ToInt32(ddl_Department.SelectedValue) : 0;
                                _obj_smhr_employee.EMP_DIRECTORATE_ID = rcmb_Directorate.SelectedValue != string.Empty ? Convert.ToInt32(rcmb_Directorate.SelectedValue) : 0;
                                //31.5.2016
                                /*if (txt_Contract_Date.SelectedDate.HasValue)
                                {
                                    _obj_smhr_employee.EMP_CONTRACT_DATE = Convert.ToDateTime(txt_Contract_Date.SelectedDate.Value);
                                }
                                else
                                {
                                    _obj_smhr_employee.EMP_CONTRACT_DATE = null;
                                }*/

                                //_obj_smhr_employee modified
                                //_obj_smhr_employee.EMP_HOBBIES = Convert.ToString();
                                if (ddl_Sup_BusinessUnit.SelectedValue != "")
                                {
                                    _obj_smhr_employee.EMP_SUPBUSINESSUNIT_ID = Convert.ToInt32(ddl_Sup_BusinessUnit.SelectedValue);
                                }
                                //if (chk_Isvariablepay.Checked)
                                //{
                                //    _obj_smhr_employee.EMP_ISVARIABLEPAY = true;
                                //    _obj_smhr_employee.EMP_VPPAYABLECOUNT = Convert.ToInt32(Math.Round(Convert.ToDouble(rntxt_Count.Text), 0));
                                //    _obj_smhr_employee.EMP_VARIABLEAMT = Convert.ToInt32(Math.Round(Convert.ToDouble(rntxt_Amount.Text), 0));
                                //}
                                //else
                                //{
                                //    _obj_smhr_employee.EMP_ISVARIABLEPAY = false;
                                //    _obj_smhr_employee.EMP_VARIABLEAMT = 0;
                                //    _obj_smhr_employee.EMP_VPPAYABLECOUNT = 0;
                                //}
                                _obj_smhr_employee.EMP_HOBBIES = Convert.ToString(rtxt_Hobbies.Text);
                                // DIVISION PURPOSE AS IT IS USED FOR THE AX DIMENSION
                                // if ((rcmb_Devision.SelectedValue != null) || (rcmb_Devision.SelectedValue!=""))
                                // if(Convert.ToInt32(rcmb_Devision.SelectedValue)>0)
                                if (rcmb_Devision.SelectedIndex > 0)
                                    _obj_smhr_employee.EMP_DIV_ID = Convert.ToInt32(rcmb_Devision.SelectedValue);
                                else
                                    _obj_smhr_employee.EMP_DIV_ID = 0;
                                ///////////////////

                                if (txt_AnnualGrossSalary.Text != "")
                                {
                                    _obj_smhr_employee.emp_ANNUAL_GROSSSALARY = Convert.ToDouble(txt_AnnualGrossSalary.Value);
                                }
                                if (txt_AnnualBasicSalary.Text != "")
                                {
                                    _obj_smhr_employee.emp_ANNUAL_BASICSALARY = Convert.ToDouble(txt_AnnualBasicSalary.Value);
                                }

                                _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                _obj_smhr_employee.EMP_EMAILID = Convert.ToString(rtxt_EmailID.Text.Replace("'", "''"));
                                //if (ddl_baseloc.Visible == false)
                                //{
                                //   //_obj_smhr_employee.EMP_LOCID = null;
                                //}
                                //else
                                //{
                                //    _obj_smhr_employee.EMP_LOCID = Convert.ToInt32(ddl_baseloc.SelectedValue);
                                //}
                                ViewState["email"] = Convert.ToString(rtxt_EmailID.Text.Replace("'", "''"));
                                _obj_smhr_employee.EMP_CATEGORY_ID = Convert.ToInt32(rcmbCategory.SelectedValue);
                                if (rcmb_SubDivision.SelectedIndex > 0)
                                    _obj_smhr_employee.EMP_SUBDIVISION = Convert.ToInt32(rcmb_SubDivision.SelectedItem.Value);
                                else
                                    _obj_smhr_employee.EMP_SUBDIVISION = null;
                                //_obj_smhr_employee.EMP_FUNDNAME = Convert.ToString(rcmb_FundName.SelectedValue);
                                //_obj_smhr_employee.EMP_WORKSTATUS = Convert.ToString(rcmb_WorkStatus.SelectedValue);
                                _obj_smhr_employee.EMP_MEMBERID = Convert.ToString(rtxt_MemberID.Text);
                                _obj_smhr_employee.EMP_CURRENTPROJECT = Convert.ToString(rtxt_CurrentProject.Text.Replace("'", "''"));
                                _obj_smhr_employee.EMP_ISMANUAL = chk_IsManual.Checked;
                                //31.5.2016
                                //_obj_smhr_employee.EMP_INCRMENTMONTH = Convert.ToInt32(rcmb_IncrementMonth.SelectedValue);
                                if (rcmb_County.SelectedIndex > 0)
                                {
                                    _obj_smhr_employee.EMP_COUNTY_ID = Convert.ToInt32(rcmb_County.SelectedValue);
                                }
                                if (rcmb_Period.SelectedIndex > 0)
                                {
                                    _obj_smhr_employee.EMP_PERIOD_ID = Convert.ToInt32(rcmb_Period.SelectedValue);
                                }

                                #region OtherDetailsNewFields
                                _obj_smhr_employee.EMP_ACTIVITY = rtbActivity.Text;
                                _obj_smhr_employee.EMP_PROGRAMME = rtbProgramme.Text;
                                _obj_smhr_employee.EMP_ORGUNIT = rtbOrgUnit.Text;
                                _obj_smhr_employee.EMP_INTERVENTION = rtbIntervention.Text;
                                _obj_smhr_employee.EMP_FOCUS_AREA = rtbFocusArea.Text;
                                _obj_smhr_employee.EMP_RESULT_AREA = rtbResultArea.Text;
                                _obj_smhr_employee.EMP_OUTCOME = rtbOutCome.Text;
                                #endregion

                                status = BLL.set_Employee(_obj_smhr_employee);
                                if (status == true)
                                {
                                    SMHR_GLOBALCONFIG _obj_smhr_globalConfig = new SMHR_GLOBALCONFIG();

                                    _obj_smhr_globalConfig.OPERATION = operation.Update;
                                    _obj_smhr_globalConfig.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

                                    dt_Details = BLL.get_ConfigDetails(_obj_smhr_globalConfig);

                                    _obj_smhr_employee = new SMHR_EMPLOYEE();
                                    _obj_smhr_employee.OPERATION = operation.Check;
                                    _obj_smhr_employee.EMP_EMPCODE = Convert.ToString(lbl_Code.Text);
                                    _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);//AS IT IS GETTING THAT PRATICULAT EMPLOYEE ID
                                    dt_Details = BLL.get_Employee(_obj_smhr_employee);
                                    if (dt_Details.Rows.Count != 0)
                                    {
                                        //_lbl_Emp_ID = Convert.ToString(dt_Details.Rows[0][0]);
                                        HF_EMPID.Value = Convert.ToString(dt_Details.Rows[0][0]);
                                    }

                                    if (RG_Contact.Items.Count != 0)  // COntact Information
                                    {
                                        saveContact();
                                    }
                                    if (RG_Experience.Items.Count != 0) //Experience Information
                                    {
                                        saveExperience();
                                    }
                                    if (RG_Language.Items.Count != 0) //Language Information
                                    {
                                        saveLanguage();
                                    }
                                    if (RG_Qualification.Items.Count != 0) //Qualification Information
                                    {
                                        saveQualification();
                                    }
                                    if (RG_Reference.Items.Count != 0) //Reference Information
                                    {
                                        saveReference();
                                    }
                                    if (RG_Skills.Items.Count != 0) //Skills Information
                                    {
                                        saveSkill();
                                    }
                                    if (RG_Family.Items.Count != 0) //Family Information
                                    {
                                        saveFamily();
                                    }
                                    if (RG_Swipe.Items.Count != 0) //Swipe Information
                                    {
                                        saveSwipe();
                                    }
                                    if (RG_OTRate.Items.Count != 0) //OT Information
                                    {
                                        saveOT();
                                    }
                                    //saveWeeklyOff(_lbl_Emp_ID);
                                    //saveOtherDetails(_lbl_Emp_ID); // Other Details
                                    saveWeeklyOff(HF_EMPID.Value);
                                    saveOtherDetails(HF_EMPID.Value);
                                    LoadOtherDetails();
                                    saveImportantDates();
                                    btn_Physical_Save_Click(null, null); //Save Physical Details
                                    if ((Convert.ToInt32(rcmb_usergroup.SelectedIndex) > 0) && rtxt_EmailID.Text != string.Empty)
                                    {
                                        //TO INSERT DATA INTO LOGININFO TABLE
                                        bool statusRandom = false;
                                        _obj_smhr_employee.EMP_ID = Convert.ToInt32(HF_EMPID.Value);
                                        _obj_smhr_employee.USER_GROUP = Convert.ToInt32(rcmb_usergroup.SelectedItem.Value);
                                        _obj_smhr_employee.PASSWORD = BLL.PasswordEncrypt(BLL.ReplaceQuote(rtxt_pwd.Text));
                                        _obj_smhr_employee.PASSCODE = BLL.PasswordEncrypt(BLL.ReplaceQuote(rtxt_passcode.Text));
                                        ViewState["passcode"] = BLL.PasswordEncrypt(BLL.ReplaceQuote(rtxt_passcode.Text));
                                        ViewState["passcodeDE"] = BLL.ReplaceQuote(rtxt_passcode.Text);
                                        _obj_smhr_employee.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                                        _obj_smhr_employee.OPERATION = operation.Insert;
                                        statusRandom = BLL.set_EMP_NEWCONTACTS(_obj_smhr_employee);
                                        if (statusRandom == true)
                                        {
                                            string randomPassword = CreateRandomPassword();
                                            ViewState["randompassword"] = randomPassword;
                                            _obj_smhr_employee.EMP_ID = Convert.ToInt32(HF_EMPID.Value);
                                            _obj_smhr_employee.USER_GROUP = Convert.ToInt32(rcmb_usergroup.SelectedItem.Value);
                                            _obj_smhr_employee.PASSWORD = BLL.PasswordEncrypt(BLL.ReplaceQuote(randomPassword));
                                            _obj_smhr_employee.PASSCODE = BLL.PasswordEncrypt(BLL.ReplaceQuote(rtxt_passcode.Text)); //Convert.ToString(dt.Rows[0]["LOGIN_PASS_CODE"]);
                                            _obj_smhr_employee.OPERATION = operation.Update;
                                            BLL.set_EMP_NEWCONTACTS(_obj_smhr_employee);
                                            // BLL.setemployeelogin(Convert.ToInt32(HF_EMPID.Value), BLL.ReplaceQuote(randomPassword));//sendMail();
                                        }
                                    }
                                    // Save_Tds_Details();
                                    Response.Redirect("~/HR/frmemployee.aspx?ID=" + Convert.ToString(lbl_Code.Text), false);
                                    ViewState["btnAdd"] = null;
                                    return;
                                }
                                else
                                {
                                    BLL.ShowMessage(this, "Exception occured while doing the process");
                                    return;
                                }
                            }
                            //}
                            //else
                            //{
                            //    BLL.ShowMessage(this, "Either Gross Salary Entered is greater than or less than the limit of the position selected");
                            //    return;
                            //}
                        }
                        else
                        {
                            ViewState["emp_name"] = string.Concat(Convert.ToString(txt_FirstName.Text.Replace("'", "''")), ' ', Convert.ToString(txt_AppMiddleName.Text.Replace("'", "''")), ' ', Convert.ToString(txt_AppLastName.Text.Replace("'", "''")));
                            bool status = false;
                            //if (status1 = chk_Salary())
                            //{
                            //Saving Employee With Applicant ID
                            _obj_smhr_employee = new SMHR_EMPLOYEE();
                            if (chk_IsManual.Checked)
                            {
                                _obj_smhr_employee.EMP_EMPCODE = rtxt_empcode.Text.Trim();
                                lbl_Code.Text = rtxt_empcode.Text.Trim();
                            }
                            else
                            {
                                getEmpCode();
                                _obj_smhr_employee.EMP_EMPCODE = Convert.ToString(lbl_Code.Text.Replace("'", "''"));
                            }
                            _obj_smhr_employee.OPERATION = operation.Insert;
                            //_obj_smhr_employee.EMP_EMPCODE = Convert.ToString(lbl_Code.Text.Replace("'", "''"));
                            _obj_smhr_employee.EMP_APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                            _obj_smhr_employee.EMP_DOJ = Convert.ToDateTime(txt_DOJ.SelectedDate.Value);
                            if (txt_DOC.SelectedDate.HasValue)
                            {
                                _obj_smhr_employee.EMP_DOC = txt_DOC.SelectedDate.Value;
                            }
                            else
                            {
                                _obj_smhr_employee.EMP_DOC = null;
                            }
                            _obj_smhr_employee.EMP_JOBS_ID = Convert.ToInt32(ddl_Jobs.SelectedValue);
                            _obj_smhr_employee.EMP_DESIGNATION_ID = Convert.ToInt32(ddl_Designation.SelectedValue);
                            _obj_smhr_employee.EMP_BUSINESSUNIT_ID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
                            if (txt_previousProm.SelectedDate.HasValue)
                                _obj_smhr_employee.EMP_DATEOFLASTPROMOTION = txt_previousProm.SelectedDate;
                            else
                                _obj_smhr_employee.EMP_DATEOFLASTPROMOTION = null;
                            if (ddl_Grade.SelectedValue != string.Empty)
                            {
                                _obj_smhr_employee.EMP_GRADE = Convert.ToInt32(ddl_Grade.SelectedValue);
                            }
                            else
                            {
                                _obj_smhr_employee.EMP_GRADE = null;
                            }
                            if (ddl_Slabs.SelectedValue != string.Empty)
                            {
                                _obj_smhr_employee.EMP_SLAB_ID = Convert.ToInt32(ddl_Slabs.SelectedValue);
                            }
                            else
                            {
                                _obj_smhr_employee.EMP_SLAB_ID = null;
                            }
                            if (ddl_Supervisor.SelectedIndex != 0)
                                _obj_smhr_employee.EMP_REPORTINGEMPLOYEE = Convert.ToInt32(ddl_Supervisor.SelectedValue);
                            if (txt_startDate.SelectedDate.HasValue)
                                _obj_smhr_employee.EMP_RPTSTARTDATE = txt_startDate.SelectedDate;
                            else
                                _obj_smhr_employee.EMP_RPTSTARTDATE = null;
                            if (txt_endDate.SelectedDate.HasValue)
                                _obj_smhr_employee.EMP_RPTENDDATE = txt_endDate.SelectedDate.Value;
                            else
                                _obj_smhr_employee.EMP_RPTENDDATE = null;
                            if (ddl_Shift.SelectedIndex != -1)
                                _obj_smhr_employee.EMP_SHIFT_ID = Convert.ToInt32(ddl_Shift.SelectedValue);
                            //string[] str = Convert.ToString(ddl_Slabs.Text).Replace(" )", "").Split('(');
                            string[] str = Convert.ToString(ddl_Slabs.Text).Replace(" )", "").Replace(")", "").Split('(');
                            _obj_smhr_employee.EMP_GROSSSAL = Convert.ToDouble(str[1].Trim());
                            _obj_smhr_employee.EMP_BASIC = Convert.ToDouble(txt_BasicPay.Text); //Convert.ToDouble(str[1].Trim());
                            _obj_smhr_employee.EMP_PAYMENTMODE_ID = Convert.ToInt32(ddl_Mode.SelectedValue);
                            _obj_smhr_employee.EMP_SALALRYSTRUCT_ID = Convert.ToInt32(ddl_SalaryStructure.SelectedValue);
                            _obj_smhr_employee.EMP_LEAVESTRUCT_ID = Convert.ToInt32(ddl_LeaveStructure.SelectedValue);
                            if (txt_probDate.SelectedDate.HasValue)
                                _obj_smhr_employee.EMP_PROBATIONDATE = txt_probDate.SelectedDate;
                            else
                                _obj_smhr_employee.EMP_PROBATIONDATE = null;

                            if (rntxt_NoticePeriod.Value.HasValue)
                                _obj_smhr_employee.EMP_NOTICEPERIOD = Convert.ToInt32(rntxt_NoticePeriod.Value);
                            else
                                _obj_smhr_employee.EMP_NOTICEPERIOD = 0;

                            if (rdp_contract_start.SelectedDate.HasValue)
                                _obj_smhr_employee.EMP_CONTRACT_STARTDATE = Convert.ToDateTime(rdp_contract_start.SelectedDate);
                            else
                                _obj_smhr_employee.EMP_CONTRACT_STARTDATE = null;

                            if (rdp_contract_end.SelectedDate.HasValue)
                                _obj_smhr_employee.EMP_CONTRACT_ENDDATE = Convert.ToDateTime(rdp_contract_end.SelectedDate);
                            else
                                _obj_smhr_employee.EMP_CONTRACT_ENDDATE = null;

                            if (txt_IncrementDate.SelectedDate.HasValue)
                                _obj_smhr_employee.EMP_INCREMENTDATE = Convert.ToDateTime(txt_IncrementDate.SelectedDate);
                            else
                                _obj_smhr_employee.EMP_INCREMENTDATE = null;

                            _obj_smhr_employee.EMP_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                            _obj_smhr_employee.EMP_CREATEDDATE = DateTime.Now;
                            _obj_smhr_employee.EMP_EMPLOYEETYPE = Convert.ToString(ddl_EmpStatus.SelectedItem.Text);
                            _obj_smhr_employee.EMP_EMPLOYEE_STATUS = Convert.ToInt32(ddl_Employee_Status.SelectedValue);
                            _obj_smhr_employee.EMP_DEPARTMENT_ID = ddl_Department.SelectedValue != string.Empty ? Convert.ToInt32(ddl_Department.SelectedValue) : 0;
                            _obj_smhr_employee.EMP_DIRECTORATE_ID = rcmb_Directorate.SelectedValue != string.Empty ? Convert.ToInt32(rcmb_Directorate.SelectedValue) : 0;
                            //_obj_smhr_employee.EMP_LOCID = Convert.ToInt32(ddl_baseloc.SelectedValue);

                            //supvisor business unit
                            //if (Convert.ToString(dt_Details.Rows[0]["EMP_SUPBUSINESSUNIT_ID"]) != null)
                            //{
                            //    ddl_Sup_BusinessUnit.SelectedIndex = ddl_Sup_BusinessUnit.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["EMP_SUPBUSINESSUNIT_ID"]));
                            //    //getJob(Convert.ToString(dt_Details.Rows[0]["EMP_SUPBUSINESSUNIT_ID"]));
                            //}
                            if (ddl_Sup_BusinessUnit.SelectedValue != "")
                            {
                                _obj_smhr_employee.EMP_SUPBUSINESSUNIT_ID = Convert.ToInt32(ddl_Sup_BusinessUnit.SelectedValue);
                            }
                            else
                                ddl_Sup_BusinessUnit.SelectedValue = null;

                            _obj_smhr_employee.EMP_HOBBIES = Convert.ToString(rtxt_Hobbies.Text);
                            _obj_smhr_employee.EMP_PAYCURRENCY = Convert.ToInt32(ddl_Currency.SelectedValue);
                            //31.5.2016
                            /*if (txt_Contract_Date.SelectedDate.HasValue)
                            {
                                _obj_smhr_employee.EMP_CONTRACT_DATE = Convert.ToDateTime(txt_Contract_Date.SelectedDate.Value);
                            }
                            else
                            {
                                _obj_smhr_employee.EMP_CONTRACT_DATE = null;
                            }*/

                            //if (chk_Isvariablepay.Checked)
                            //{
                            //    _obj_smhr_employee.EMP_ISVARIABLEPAY = true;
                            //    _obj_smhr_employee.EMP_VPPAYABLECOUNT = Convert.ToInt32(Math.Round(Convert.ToDouble(rntxt_Count.Text), 0));
                            //    _obj_smhr_employee.EMP_VARIABLEAMT = Convert.ToInt32(Math.Round(Convert.ToDouble(rntxt_Amount.Text), 0));
                            //}
                            //else
                            //{
                            //    if ((rntxt_Amount.Text != "") || (rntxt_Amount.Text != ""))
                            //    {
                            //        BLL.ShowMessage(this, "Select Variable pay Checkbox");
                            //        return;
                            //    }
                            //    _obj_smhr_employee.EMP_ISVARIABLEPAY = false;
                            //    _obj_smhr_employee.EMP_VARIABLEAMT = 0;
                            //    _obj_smhr_employee.EMP_VPPAYABLECOUNT = 0;
                            //}

                            // DIVISION PURPOSE AS IT IS USED FOR THE AX DIMENSION
                            if (rcmb_Devision.SelectedIndex > 0)
                                _obj_smhr_employee.EMP_DIV_ID = Convert.ToInt32(rcmb_Devision.SelectedValue);
                            else
                                _obj_smhr_employee.EMP_DIV_ID = 0;
                            ///////////////////

                            if (txt_AnnualGrossSalary.Text != "")
                            {
                                _obj_smhr_employee.emp_ANNUAL_GROSSSALARY = Convert.ToDouble(txt_AnnualGrossSalary.Value);
                            }
                            if (txt_AnnualBasicSalary.Text != "")
                            {
                                _obj_smhr_employee.emp_ANNUAL_BASICSALARY = Convert.ToDouble(txt_AnnualBasicSalary.Value);
                            }

                            _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_smhr_employee.EMP_EMAILID = Convert.ToString(rtxt_EmailID.Text.Replace("'", "''"));
                            ViewState["email"] = Convert.ToString(rtxt_EmailID.Text.Replace("'", "''"));
                            if (rcmbCategory.SelectedIndex > 0)
                            {
                                _obj_smhr_employee.EMP_CATEGORY_ID = Convert.ToInt32(rcmbCategory.SelectedValue);
                            }
                            //_obj_smhr_employee.EMP_FUNDNAME = Convert.ToString(rcmb_FundName.SelectedValue);
                            //_obj_smhr_employee.EMP_WORKSTATUS = Convert.ToString(rcmb_WorkStatus.SelectedValue);
                            _obj_smhr_employee.EMP_MEMBERID = Convert.ToString(rtxt_MemberID.Text);

                            _obj_smhr_employee.EMP_CURRENTPROJECT = Convert.ToString(rtxt_CurrentProject.Text.Replace("'", "''"));
                            _obj_smhr_employee.EMP_ISMANUAL = chk_IsManual.Checked;
                            _obj_smhr_employee.EMP_PERIOD_ID = Convert.ToInt32(rcmb_Period.SelectedIndex);
                            if (Convert.ToInt32(Session["ORG_ID"]) == 0)
                                return;

                            #region OtherDetailsNewFields
                            _obj_smhr_employee.EMP_ACTIVITY = rtbActivity.Text;
                            _obj_smhr_employee.EMP_PROGRAMME = rtbProgramme.Text;
                            _obj_smhr_employee.EMP_ORGUNIT = rtbOrgUnit.Text;
                            _obj_smhr_employee.EMP_INTERVENTION = rtbIntervention.Text;
                            _obj_smhr_employee.EMP_FOCUS_AREA = rtbFocusArea.Text;
                            _obj_smhr_employee.EMP_RESULT_AREA = rtbResultArea.Text;
                            _obj_smhr_employee.EMP_OUTCOME = rtbOutCome.Text;
                            #endregion

                            status = BLL.set_Employee(_obj_smhr_employee);
                            if (status == true)
                            {
                                SMHR_GLOBALCONFIG _obj_smhr_globalConfig = new SMHR_GLOBALCONFIG();

                                _obj_smhr_globalConfig.OPERATION = operation.Update;
                                _obj_smhr_globalConfig.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

                                dt_Details = BLL.get_ConfigDetails(_obj_smhr_globalConfig);

                                _obj_smhr_employee = new SMHR_EMPLOYEE();
                                _obj_smhr_employee.OPERATION = operation.Check;
                                _obj_smhr_employee.EMP_EMPCODE = Convert.ToString(lbl_Code.Text);
                                _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                dt_Details = BLL.get_Employee(_obj_smhr_employee);
                                if (dt_Details.Rows.Count != 0)
                                {
                                    //_lbl_Emp_ID = Convert.ToString(dt_Details.Rows[0][0]);
                                    HF_EMPID.Value = Convert.ToString(dt_Details.Rows[0][0]);
                                }
                                if (RG_Family.Items.Count != 0) //Family Information
                                {
                                    saveFamily();
                                }
                                if (RG_Swipe.Items.Count != 0) //Swipe Information
                                {
                                    saveSwipe();
                                }
                                if (RG_OTRate.Items.Count != 0)
                                {
                                    saveOT();
                                }
                                if (RG_Contact.Items.Count != 0)  // COntact Information
                                {
                                    //saveContact();
                                }
                                if (RG_Experience.Items.Count != 0) //Experience Information
                                {
                                    saveExperience();
                                }
                                if (RG_Language.Items.Count != 0) //Language Information
                                {
                                    saveLanguage();
                                }
                                if (RG_Qualification.Items.Count != 0) //Qualification Information
                                {
                                    saveQualification();
                                }
                                if (RG_Reference.Items.Count != 0) //Reference Information
                                {
                                    saveReference();
                                }
                                if (RG_Skills.Items.Count != 0) //Skills Information
                                {
                                    saveSkill();
                                }
                                //saveWeeklyOff(_lbl_Emp_ID);
                                //saveOtherDetails(_lbl_Emp_ID);
                                saveWeeklyOff(HF_EMPID.Value);
                                saveOtherDetails(HF_EMPID.Value);
                                LoadOtherDetails();
                                saveImportantDates();
                                //btn_Physical_Update_Click(null, null);
                                btn_Physical_Save_Click(null, null); //Save Physical Details


                                if ((Convert.ToInt32(rcmb_usergroup.SelectedIndex) > 0) && rtxt_EmailID.Text != string.Empty)
                                {
                                    //TO INSERT DATA INTO LOGININFO TABLE
                                    bool statusRandom = false;
                                    _obj_smhr_employee.EMP_ID = Convert.ToInt32(HF_EMPID.Value);
                                    _obj_smhr_employee.USER_GROUP = Convert.ToInt32(rcmb_usergroup.SelectedItem.Value);
                                    _obj_smhr_employee.PASSWORD = BLL.PasswordEncrypt(BLL.ReplaceQuote(rtxt_pwd.Text));
                                    _obj_smhr_employee.PASSCODE = BLL.PasswordEncrypt(BLL.ReplaceQuote(rtxt_passcode.Text));
                                    ViewState["passcode"] = BLL.PasswordEncrypt(BLL.ReplaceQuote(rtxt_passcode.Text));
                                    _obj_smhr_employee.OPERATION = operation.Insert;
                                    statusRandom = BLL.set_EMP_NEWCONTACTS(_obj_smhr_employee);
                                    if (statusRandom == true)
                                    {
                                        string randomPassword = CreateRandomPassword();
                                        ViewState["randompassword"] = randomPassword;
                                        _obj_smhr_employee.EMP_ID = Convert.ToInt32(HF_EMPID.Value);
                                        _obj_smhr_employee.USER_GROUP = Convert.ToInt32(rcmb_usergroup.SelectedItem.Value);
                                        _obj_smhr_employee.PASSWORD = BLL.PasswordEncrypt(BLL.ReplaceQuote(randomPassword));
                                        _obj_smhr_employee.PASSCODE = BLL.PasswordEncrypt(BLL.ReplaceQuote(rtxt_passcode.Text)); //Convert.ToString(dt.Rows[0]["LOGIN_PASS_CODE"]);
                                        _obj_smhr_employee.OPERATION = operation.Update;
                                        BLL.set_EMP_NEWCONTACTS(_obj_smhr_employee);
                                        // BLL.setemployeelogin(Convert.ToInt32(HF_EMPID.Value), BLL.ReplaceQuote(randomPassword));//sendMail();
                                    }
                                }
                                BLL.ShowMessage(this, "Employee Inserted Successfully");
                                Response.Redirect("~/HR/frmemployee.aspx?ID=" + Convert.ToString(lbl_Code.Text), false);
                                return;
                            }
                            else
                            {
                                BLL.ShowMessage(this, "Exception occured while doing the process");
                                return;
                            }
                            //}
                            //else
                            //{
                            //    BLL.ShowMessage(this, "Either Gross Salary Entered is greater than or less than the limit of the position selected");
                            //    return;
                            //}
                        }
                    }
                    else
                    {
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You have only limited no of users License. You cannot create more employees');window.location ='../HR/frmemployee.aspx';", true);
                        BLL.ShowMessage(this, "You have only limited no of users License. You cannot create more employees");
                        return;
                    }

                }
                else
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You have only limited no of users License. You cannot create more employees');window.location ='../HR/frmemployee.aspx';", true);
                    BLL.ShowMessage(this, "You have only limited no of users License. You cannot create more employees");
                    return;

                }
            }
        }

        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx", false);
        }

    }




    //Code for basic salary to be auto-calaulated.
    //protected void txt_GrossSalary_TextChanged(object sender, EventArgs e)
    //{
    //    //ddl_EmpStatus_SelectedIndexChanged(null, null);
    //    //Calculate_Basic();
    //}

    protected void btn_Update_Click(object sender, EventArgs e)
    {
        try
        {
            rtxt_pwd.Attributes.Add("value", strPass);
            rtxt_passcode.Attributes.Add("value", strPass1);
            if (Convert.ToInt32(ViewState["STATUS"]) == 1)
            {
                BLL.ShowMessage(this, "Employee is Resigned.You can not update the record.");
                return;
            }
            else if (Convert.ToInt32(ViewState["STATUS"]) == 2)
            {
                BLL.ShowMessage(this, "Employee is Relieved.You can not update the record.");
                return;
            }
            else if (Convert.ToInt32(ViewState["STATUS"]) == 3)
            {
                BLL.ShowMessage(this, "Employee is Rehired.You can not update the record.");
                return;
            }
            else if (Convert.ToInt32(ViewState["STATUS"]) == 4)
            {
                BLL.ShowMessage(this, "Employee is Transferred.You cannot update the record.");
                return;
            }
            else
            {
                //if (Convert.ToBoolean(ViewState["Rehire"]) == true)
                // {
                //     MsgBoxResult mresult = Interaction.MsgBox("Are You Sure?It Updates with Same data.", MsgBoxStyle.OkCancel, "Confirmation");

                //     if (mresult.ToString() == "Cancel")
                //     {
                //         return;
                //     }
                // }
                if (chk_Friday.Checked == true || chk_Monday.Checked == true || chk_Saturday.Checked == true
                  || chk_Sunday.Checked == true || chk_thursday.Checked == true || chk_tuesday.Checked == true
                  || chk_wednesday.Checked == true)
                {
                    if (rdp_offDate.SelectedDate == null)
                    {
                        BLL.ShowMessage(this, "Enter Weekly off Effective Date.");
                        return;
                    }
                }
                if ((Convert.ToString(Session["Supervisor"]) != string.Empty))
                {
                    Session["Supervisor"] = null;
                }
                if (chk_Mandatory.Checked)
                {
                    if (ddl_Supervisor.SelectedIndex <= 0)
                    {
                        BLL.ShowMessage(this, "Supervisor is Mandatory");
                        return;
                    }
                }

                if (rdp_contract_start.SelectedDate != null || rdp_contract_end.SelectedDate != null)
                {
                    if (rdp_contract_start.SelectedDate != null && rdp_contract_end.SelectedDate == null)
                    {
                        BLL.ShowMessage(this, "Contract end date is mandatory..!");
                        rdp_contract_end.Focus();
                        return;
                    }
                    if (rdp_contract_start.SelectedDate == null && rdp_contract_end.SelectedDate != null)
                    {
                        BLL.ShowMessage(this, "Contract start date is mandatory..!");
                        rdp_contract_start.Focus();
                        return;
                    }
                }

                /* To check if MemberID/PensionID already exists */
                if (Convert.ToString(rtxt_MemberID.Text.Replace("'", "''")) != string.Empty)
                {
                    _obj_smhr_employee = new SMHR_EMPLOYEE();
                    _obj_smhr_employee.EMP_MEMBERID = BLL.ReplaceQuote(Convert.ToString(rtxt_MemberID.Text.Replace("'", "''")).Trim());
                    _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_employee.EMP_ID = Convert.ToInt32(HF_EMPID.Value);
                    _obj_smhr_employee.OPERATION = operation.CHECKDUPLICATE;
                    if (BLL.get_EmployeeStatus(_obj_smhr_employee))
                    {
                        BLL.ShowMessage(this, "Member ID Already Exists. Please enter another Member ID");
                        RMP_EmployeePage.SelectedIndex = 12;
                        RTS_Employee.SelectedIndex = 12;
                        rtxt_MemberID.Text = string.Empty;
                        rtxt_MemberID.Focus();
                        return;
                    }
                }
                /* To check if MemberID/PensionID already exists */


                // for checking the duplicate email id of employee in physical details
                _obj_smhr_employee = new SMHR_EMPLOYEE();
                _obj_smhr_employee.OPERATION = operation.Select;
                _obj_smhr_employee.EMP_ID = Convert.ToInt32(HF_EMPID.Value.ToString()); //Convert.ToInt32(_lbl_Emp_ID.ToString());
                DataTable dt_email = BLL.get_EMP_NEWCONTACTS(_obj_smhr_employee);
                string email = string.Empty;
                string skypeId = string.Empty;
                if (dt_email.Rows.Count > 0)
                {
                    email = Convert.ToString(dt_email.Rows[0]["EMP_EMAILID"]).Trim();
                    skypeId = Convert.ToString(dt_email.Rows[0]["EMP_SKYPEID"]).Trim();
                }
                if (Convert.ToString(rtxt_EmailID.Text.Replace("'", "''")).Trim() != string.Empty && Convert.ToString(rtxt_EmailID.Text.Replace("'", "''")).Trim() != email)
                {
                    _obj_smhr_employee = new SMHR_EMPLOYEE();
                    _obj_smhr_employee.EMP_EMAILID = BLL.ReplaceQuote(Convert.ToString(rtxt_EmailID.Text.Replace("'", "''")).Trim());
                    _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_employee.OPERATION = operation.CHK_EMAILORG;//operation.CHK_EMPMAIL;
                    if (Convert.ToInt32(BLL.get_Employee(_obj_smhr_employee).Rows[0][0]) > 0)
                    {
                        BLL.ShowMessage(this, "Email ID Already Exists.Please enter another Email ID");
                        RMP_EmployeePage.SelectedIndex = 13;
                        rtxt_EmailID.Text = "";
                        rtxt_EmailID.Focus();
                        return;
                    }
                }
                if (Convert.ToString(rtxt_EmailID.Text.Replace("'", "''")).Trim() != string.Empty && rcmb_usergroup.SelectedIndex > 0)
                {
                    if (rtxt_pwd.Text.Length < 4 || rtxt_pwd.Text.Length > 14)
                    {
                        BLL.ShowMessage(this, "Password Length should be Minimum 4 & Maximum 14 Characters.");
                        return;
                    }
                    if (rtxt_passcode.Text.Length < 4 || rtxt_passcode.Text.Length > 14)
                    {
                        BLL.ShowMessage(this, "PassCode Length should be Minimum 4 & Maximum 14 Characters.");
                        return;
                    }
                }
                if (Convert.ToString(txtSkypeId.Text.Replace("'", "''")).Trim() != string.Empty && Convert.ToString(txtSkypeId.Text.Replace("'", "''")).Trim() != skypeId)
                {
                    _obj_smhr_employee.EMP_SKYPEID = Convert.ToString(txtSkypeId.Text.Replace("'", "''")).Trim();
                    _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_employee.EMP_BUSINESSUNIT_ID = Convert.ToInt32(ddl_BusinessUnit.SelectedItem.Value);
                    _obj_smhr_employee.OPERATION = operation.CheckSkype;
                    DataTable dt_empskype = BLL.get_EMP_NEWCONTACTS(_obj_smhr_employee);
                    if (dt_empskype.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dt_empskype.Rows[0][0].ToString()) > 0)
                        {
                            BLL.ShowMessage(this, "This Skype-Id Already Exists");
                            RMP_EmployeePage.SelectedIndex = 13;
                            txtSkypeId.Text = "";
                            txtSkypeId.Focus();
                            return;
                        }
                    }
                }

                _obj_smhr_EmpOtherDetails = new SMHR_EMPOTHERDETAILS();
                _obj_smhr_EmpOtherDetails.OPERATION = operation.Select;
                _obj_smhr_EmpOtherDetails.EMPOTHERDTL_EMPID = Convert.ToInt32(HF_EMPID.Value.ToString());
                DataTable dtEmpOtherDetails = BLL.get_SMHR_EMPOTHERDETAILS(_obj_smhr_EmpOtherDetails);
                string passport = string.Empty;
                if (dtEmpOtherDetails.Rows.Count > 0)
                {
                    passport = Convert.ToString(dtEmpOtherDetails.Rows[0]["EMPOTHERDTL_PASSPORTNO"]).Trim();
                }
                if (Convert.ToString(txtPassportNo.Text.Replace("'", "''")).Trim() != string.Empty && Convert.ToString(txtPassportNo.Text.Replace("'", "''")).Trim() != passport)
                {
                    _obj_smhr_EmpOtherDetails.EMPOTHERDTL_PASSPORTNO = Convert.ToString(txtPassportNo.Text.Replace("'", "''")).Trim();
                    _obj_smhr_EmpOtherDetails.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_EmpOtherDetails.OPERATION = operation.CheckPass;
                    DataTable dt_emppass = BLL.get_SMHR_EMPOTHERDETAILS(_obj_smhr_EmpOtherDetails);
                    if (dt_emppass.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dt_emppass.Rows[0][0].ToString()) > 0)
                        {
                            BLL.ShowMessage(this, "This Passport No. Already Exists");
                            RMP_EmployeePage.SelectedIndex = 13;
                            txtPassportNo.Text = "";
                            txtPassportNo.Focus();
                            return;
                        }
                    }
                }

                //if (chk_Isvariablepay.Checked)
                //{
                //    if ((rntxt_Amount.Text == string.Empty) || (rntxt_Count.Text == string.Empty))
                //    {
                //        BLL.ShowMessage(this, "Variable Amount and Payable Times Should be Greater than Zero");
                //        return;
                //    }
                //    else
                //    {
                //        //int amount=Math.Round((rntxt_Amount.Text),0);
                //        rntxt_Amount.Text = Convert.ToString(Math.Round(Convert.ToDouble(rntxt_Amount.Text), 0));
                //        rntxt_Count.Text = Convert.ToString(Math.Round(Convert.ToDouble(rntxt_Count.Text), 0));
                //    }
                //}
                if (chk_IsManual.Checked)
                {
                    if (Convert.ToString(lbl_Code.Text).Trim() != Convert.ToString(rtxt_empcode.Text).Trim())
                    {

                        _obj_smhr_employee = new SMHR_EMPLOYEE();
                        _obj_smhr_employee.OPERATION = operation.Get;
                        _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_smhr_employee.EMP_EMPCODE = rtxt_empcode.Text;
                        if (Convert.ToString(BLL.get_empcode(_obj_smhr_employee).Rows[0]["Count"]) != "0")
                        {
                            BLL.ShowMessage(this, "Employee Code Already Exists");
                            rtxt_empcode.Text = string.Empty;
                            rtxt_empcode.Focus();
                            return;
                        }
                        lbl_Code.Text = rtxt_empcode.Text;
                    }
                }
                bool status = false;
                //if (status1 = chk_Salary())
                //{
                //Updates Applicant Related Details
                _obj_smhr_applicant = new SMHR_APPLICANT();
                _obj_smhr_employee = new SMHR_EMPLOYEE();
                _obj_smhr_applicant.OPERATION = operation.Update1;
                _obj_smhr_applicant.APPLICANT_TITLE = Convert.ToString(ddl_Title.SelectedValue);
                _obj_smhr_applicant.APPLICANT_FIRSTNAME = Convert.ToString(txt_FirstName.Text.Replace("'", "''"));
                _obj_smhr_applicant.APPLICANT_MIDDLENAME = Convert.ToString(txt_AppMiddleName.Text.Replace("'", "''"));
                _obj_smhr_applicant.APPLICANT_LASTNAME = Convert.ToString(txt_AppLastName.Text.Replace("'", "''"));
                ViewState["emp_name"] = string.Concat(Convert.ToString(txt_FirstName.Text.Replace("'", "''")), ' ', Convert.ToString(txt_AppMiddleName.Text.Replace("'", "''")), ' ', Convert.ToString(txt_AppLastName.Text.Replace("'", "''")));
                _obj_smhr_applicant.APPLICANT_DOB = Convert.ToDateTime(txt_DOB.SelectedDate.Value);
                _obj_smhr_applicant.APPLICANT_GENDER = Convert.ToString(ddl_Gender.SelectedValue);
                if (ddl_BloodGroup.SelectedIndex != -1)
                {
                    _obj_smhr_applicant.APPLICANT_BLOODGROUP = Convert.ToString(ddl_BloodGroup.SelectedValue);
                }
                _obj_smhr_applicant.APPLICANT_RELIGION_ID = Convert.ToInt32(ddl_Religion.SelectedValue);
                _obj_smhr_applicant.APPLICANT_NATIONALITY_ID = Convert.ToInt32(ddl_Nationality.SelectedValue);
                _obj_smhr_applicant.APPLICANT_TRIBE_ID = ddl_Tribe.SelectedValue != string.Empty ? Convert.ToInt32(ddl_Tribe.SelectedValue) : 0;
                _obj_smhr_applicant.APPLICANT_MARITALSTATUS = Convert.ToString(ddl_MaritalStatus.SelectedValue);
                _obj_smhr_applicant.APPLICANT_ADDRESS = Convert.ToString(txt_Address.Text.Replace("'", "''"));
                _obj_smhr_applicant.APPLICANT_REMARKS = Convert.ToString(txt_Remarks.Text.Replace("'", "''"));
                _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                _obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //_obj_smhr_applicant.APPLICANT_LASTMDFBY = 1;
                _obj_smhr_applicant.APPLICANT_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); ;
                _obj_smhr_applicant.APPLICANT_LASTMDFDATE = DateTime.Now;
                _obj_smhr_applicant.APPLICANT_TYPE = "DIRECT";
                status = BLL.set_EmpApplicant(_obj_smhr_applicant);//no organisation column has found
                //Updates Employee Related Details



                _obj_smhr_employee.OPERATION = operation.Update;
                _obj_smhr_employee.EMP_EMPCODE = Convert.ToString(lbl_Code.Text.Replace("'", "''"));
                _obj_smhr_employee.EMP_APPLICANT_ID = Convert.ToInt32(HF_APID.Value); //Convert.ToInt32(_lbl_App_ID);
                _obj_smhr_employee.EMP_DOJ = Convert.ToDateTime(txt_DOJ.SelectedDate.Value);

                if (txt_DOC.SelectedDate.HasValue)
                {
                    _obj_smhr_employee.EMP_DOC = txt_DOC.SelectedDate.Value;
                }
                else
                {
                    _obj_smhr_employee.EMP_DOC = null;
                }
                _obj_smhr_employee.EMP_JOBS_ID = Convert.ToInt32(ddl_Jobs.SelectedValue);
                _obj_smhr_employee.EMP_DESIGNATION_ID = Convert.ToInt32(ddl_Designation.SelectedValue);
                _obj_smhr_employee.EMP_BUSINESSUNIT_ID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
                if (txt_previousProm.SelectedDate.HasValue)
                    _obj_smhr_employee.EMP_DATEOFLASTPROMOTION = txt_previousProm.SelectedDate;
                else
                    _obj_smhr_employee.EMP_DATEOFLASTPROMOTION = null;
                if (ddl_Grade.SelectedValue != string.Empty)
                {
                    _obj_smhr_employee.EMP_GRADE = Convert.ToInt32(ddl_Grade.SelectedValue);
                }
                else
                {
                    _obj_smhr_employee.EMP_GRADE = null;
                }

                if (ddl_Slabs.SelectedValue != string.Empty)
                {
                    _obj_smhr_employee.EMP_SLAB_ID = Convert.ToInt32(ddl_Slabs.SelectedValue);
                }

                else
                {
                    _obj_smhr_employee.EMP_SLAB_ID = null;
                }
                //if (ddl_baseloc.SelectedIndex != 0)
                //{
                //    _obj_smhr_employee.EMP_LOCID = Convert.ToInt32(ddl_baseloc.SelectedValue);
                //}
                //else
                //{
                //    _obj_smhr_employee.EMP_LOCID = 0;
                //}
                //if (ddl_Supervisor.SelectedIndex != 0)
                //  _obj_smhr_employee.EMP_REPORTINGEMPLOYEE = Convert.ToInt32(ddl_Supervisor.SelectedValue);

                if (txt_startDate.SelectedDate.HasValue)
                    _obj_smhr_employee.EMP_RPTSTARTDATE = txt_startDate.SelectedDate;
                else
                    _obj_smhr_employee.EMP_RPTSTARTDATE = null;
                if (txt_endDate.SelectedDate.HasValue)
                    _obj_smhr_employee.EMP_RPTENDDATE = txt_endDate.SelectedDate.Value;
                else
                    _obj_smhr_employee.EMP_RPTENDDATE = null;
                if (ddl_Shift.SelectedIndex != -1)
                    _obj_smhr_employee.EMP_SHIFT_ID = Convert.ToInt32(ddl_Shift.SelectedValue);
                //if (txt_GrossSalary.Value.HasValue)
                //    _obj_smhr_employee.EMP_GROSSSAL = Convert.ToDouble(txt_GrossSalary.Value);
                //else
                //    _obj_smhr_employee.EMP_GROSSSAL = 0;
                /*20160118
                if (txt_BasicPay.Value.HasValue)
                {
                    string[] str = Convert.ToString(ddl_Slabs.Text).Replace(" )", "").Split('(');
                    _obj_smhr_employee.EMP_BASIC = Math.Round((Convert.ToDouble(str[1].Trim()) / 12), 2);
                    _obj_smhr_employee.EMP_GROSSSAL = Convert.ToDouble(str[1].Trim());
                }
                else
                {
                    _obj_smhr_employee.EMP_BASIC = 0;
                    _obj_smhr_employee.EMP_GROSSSAL = 0;
                }
                if (ddl_Slabs.SelectedValue != string.Empty)
                {
                    _obj_smhr_employee.EMP_SLAB_ID = Convert.ToInt32(ddl_Slabs.SelectedValue);
                }*/
                if (ddl_Slabs.SelectedIndex > 0 && txt_BasicPay.Text != string.Empty)
                {

                    string[] str = Convert.ToString(ddl_Slabs.Text).Replace(" )", "").Replace(")", "").Split('(');
                    _obj_smhr_employee.EMP_GROSSSAL = Convert.ToDouble(str[1].Trim());
                    //_obj_smhr_employee.EMP_BASIC = Convert.ToDouble(txt_BasicPay.Text);
                    _obj_smhr_employee.EMP_BASIC = Math.Round((Convert.ToDouble(str[1].Trim()) / 12), 2);
                }
                else
                {
                    _obj_smhr_employee.EMP_BASIC = 0;
                    _obj_smhr_employee.EMP_GROSSSAL = 0;
                }
                _obj_smhr_employee.EMP_PAYMENTMODE_ID = Convert.ToInt32(ddl_Mode.SelectedValue);
                _obj_smhr_employee.EMP_SALALRYSTRUCT_ID = Convert.ToInt32(ddl_SalaryStructure.SelectedValue);
                _obj_smhr_employee.EMP_LEAVESTRUCT_ID = Convert.ToInt32(ddl_LeaveStructure.SelectedValue);

                if (txt_probDate.SelectedDate.HasValue)
                {
                    _obj_smhr_employee.EMP_PROBATIONDATE = txt_probDate.SelectedDate;
                }
                else
                {
                    _obj_smhr_employee.EMP_PROBATIONDATE = null;
                }

                //to update contract start date
                if (rdp_contract_start.SelectedDate.HasValue)
                {
                    _obj_smhr_employee.EMP_CONTRACT_STARTDATE = rdp_contract_start.SelectedDate;
                }
                else
                {
                    _obj_smhr_employee.EMP_CONTRACT_STARTDATE = null;
                }
                //to update contract end date
                if (rdp_contract_end.SelectedDate.HasValue)
                {
                    _obj_smhr_employee.EMP_CONTRACT_ENDDATE = rdp_contract_end.SelectedDate;
                }
                else
                {
                    _obj_smhr_employee.EMP_CONTRACT_ENDDATE = null;
                }
                //to update increment date
                if (txt_IncrementDate.SelectedDate.HasValue)
                {
                    _obj_smhr_employee.EMP_INCREMENTDATE = txt_IncrementDate.SelectedDate;
                }
                else
                {
                    _obj_smhr_employee.EMP_INCREMENTDATE = null;
                }
                if (rntxt_NoticePeriod.Value.HasValue)
                {
                    _obj_smhr_employee.EMP_NOTICEPERIOD = Convert.ToInt32(rntxt_NoticePeriod.Value);
                }
                else
                {
                    _obj_smhr_employee.EMP_NOTICEPERIOD = 0;
                }
                //if (!string.IsNullOrEmpty(FUpload.PostedFile.FileName))//Previously

                //(RBI_Employee_Image.ImageUrl!=null)&&
                //if ((RBI_Employee_Image.ImageUrl != string.Empty) && (Convert.ToString(ViewState["FILE_NAME"])!=""))//by me
                //{               
                //    string Source = RBI_Employee_Image.ImageUrl;
                //    string Dest="~/EmpUploads/Photo Upload/" + Session["ORG_ID"] + "/"+Convert.ToString(ViewState["FILE_NAME"]);
                //    if (Source != Dest)
                //    {
                //        if (System.IO.Directory.Exists(Server.MapPath("~/EmpUploads/Photo Upload/" + Session["ORG_ID"] + "/" + Convert.ToString(ViewState["FILE_NAME"]))) == false)
                //        {
                //            File.Delete("~/EmpUploads/Photo Upload/" + Session["ORG_ID"] + "/" + Convert.ToString(ViewState["FILE_NAME"]));//DELETING THE PREVIOUS ONE
                //            File.Move(Source, "~/EmpUploads/Photo Upload/" + Session["ORG_ID"] + "/");//MOVING THE NEW FILE FROM UPLOAD TO PHOTO UPLOAD
                //            _obj_smhr_employee.EMP_PICUTRE = Dest;
                //        }
                //        else
                //        {
                //            _obj_smhr_employee.EMP_PICUTRE = Source;
                //        }
                //        // EVEN WE HAVE TO DELETE THE PREVIOUS FILE
                //        FileInfo[] files;
                //        int FileFromCollection;
                //        DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/EmpUploads/Upload/" + Session["ORG_ID"] + "/"));
                //        files = dir.GetFiles();
                //        if (files.Length > 0)
                //        {
                //            for (FileFromCollection = 0; FileFromCollection <= files.Length - 1; FileFromCollection++)
                //            {
                //                files[FileFromCollection].Delete();
                //            }
                //        }
                //    }
                //    else
                //    {
                //        _obj_smhr_employee.EMP_PICUTRE = Dest;
                //    }
                //    //FUpload.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/EmpUploads"), lbl_Code.Text + "_" + FUpload.FileName));
                //    //_obj_smhr_employee.EMP_PICUTRE = "~/EmpUploads/" + lbl_Code.Text + "_" + FUpload.FileName;
                //}


                //_obj_smhr_employee.EMP_PICUTRE = strPath;
                _obj_smhr_employee.EMP_PICUTRE = RBI_Employee_Image.ImageUrl.ToString();


                //else
                //{
                //    if (ViewState["fileLocation"] != null)
                //    {
                //        _obj_smhr_employee.EMP_PICUTRE = Convert.ToString(ViewState["fileLocation"]);
                //    }
                //}

                if (ddl_Sup_BusinessUnit.SelectedIndex > 0)
                {
                    _obj_smhr_employee.EMP_SUPBUSINESSUNIT_ID = Convert.ToInt32(ddl_Sup_BusinessUnit.SelectedValue);

                    //end should be enable in edit mode
                    txt_endDate.Enabled = true;

                }
                else
                {

                    //end should be enable in edit mode
                    txt_endDate.Enabled = false;
                }
                if (ddl_Supervisor.SelectedIndex > 0)
                {
                    _obj_smhr_employee.EMP_REPORTINGEMPLOYEE = Convert.ToInt32(ddl_Supervisor.SelectedValue);
                }


                if (rtxt_Hobbies.Text != "")
                {
                    _obj_smhr_employee.EMP_HOBBIES = Convert.ToString(rtxt_Hobbies.Text);
                }
                else
                {
                    _obj_smhr_employee.EMP_HOBBIES = null;
                }


                _obj_smhr_employee.EMP_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_smhr_employee.EMP_LASTMDFDATE = DateTime.Now;
                //_obj_smhr_employee.EMP_EMPLOYEETYPE = Convert.ToString(ddl_EmpStatus.SelectedItem.Value);
                _obj_smhr_employee.EMP_EMPLOYEETYPE = Convert.ToString(ddl_EmpStatus.SelectedItem.Text);
                _obj_smhr_employee.EMP_PAYCURRENCY = Convert.ToInt32(ddl_Currency.SelectedValue);
                _obj_smhr_employee.EMP_ID = Convert.ToInt32(HF_EMPID.Value); //Convert.ToInt32(_lbl_Emp_ID);
                _obj_smhr_employee.EMP_EMPLOYEE_STATUS = Convert.ToInt32(ddl_Employee_Status.SelectedValue);
                _obj_smhr_employee.EMP_DEPARTMENT_ID = ddl_Department.SelectedValue != string.Empty ? Convert.ToInt32(ddl_Department.SelectedValue) : 0;
                _obj_smhr_employee.EMP_DIRECTORATE_ID = rcmb_Directorate.SelectedValue != string.Empty ? Convert.ToInt32(rcmb_Directorate.SelectedValue) : 0;
                //31.5.2016
                /*if (txt_Contract_Date.SelectedDate.HasValue)
                {
                    _obj_smhr_employee.EMP_CONTRACT_DATE = Convert.ToDateTime(txt_Contract_Date.SelectedDate.Value);
                }
                else
                {
                    _obj_smhr_employee.EMP_CONTRACT_DATE = null;
                }*/



                //if (chk_Isvariablepay.Checked)
                //{
                //    _obj_smhr_employee.EMP_ISVARIABLEPAY = true;
                //    _obj_smhr_employee.EMP_VPPAYABLECOUNT = Convert.ToInt32(rntxt_Count.Text);
                //    _obj_smhr_employee.EMP_VARIABLEAMT = Convert.ToInt32(rntxt_Amount.Text);
                //}
                //else
                //{
                //    if ((rntxt_Amount.Text != "") || (rntxt_Amount.Text != ""))
                //    {
                //        BLL.ShowMessage(this, "Select Variable pay Checkbox");
                //        return;
                //    }
                //    _obj_smhr_employee.EMP_ISVARIABLEPAY = false;
                //    _obj_smhr_employee.EMP_VARIABLEAMT = 0;
                //    _obj_smhr_employee.EMP_VPPAYABLECOUNT = 0;
                //}
                if (chk_IsManual.Checked)
                {
                    _obj_smhr_employee.EMP_EMPCODE = rtxt_empcode.Text;
                }
                else
                {
                    _obj_smhr_employee.EMP_EMPCODE = Convert.ToString(lbl_Code.Text.Replace("'", "''"));

                }
                //modified supervisor business unit
                //if (ddl_Supervisor.SelectedIndex != 0)
                //    _obj_smhr_employee.EMP_REPORTINGEMPLOYEE = Convert.ToInt32(ddl_Supervisor.SelectedValue);


                // DIVISION PURPOSE AS IT IS USED FOR THE AX DIMENSION
                if (rcmb_Devision.SelectedIndex > 0)
                    _obj_smhr_employee.EMP_DIV_ID = Convert.ToInt32(rcmb_Devision.SelectedValue);
                else
                    _obj_smhr_employee.EMP_DIV_ID = 0;
                ///////////////////

                if (txt_AnnualGrossSalary.Text != "")
                {
                    _obj_smhr_employee.emp_ANNUAL_GROSSSALARY = Convert.ToDouble(txt_AnnualGrossSalary.Value);
                }
                if (txt_AnnualBasicSalary.Text != "")
                {
                    _obj_smhr_employee.emp_ANNUAL_BASICSALARY = Convert.ToDouble(txt_AnnualBasicSalary.Value);
                }

                _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                ViewState["email"] = Convert.ToString(rtxt_EmailID.Text.Replace("'", "''"));
                if (rcmbCategory.SelectedIndex > 0)
                {
                    _obj_smhr_employee.EMP_CATEGORY_ID = Convert.ToInt32(rcmbCategory.SelectedValue);
                }
                if (rcmb_SubDivision.SelectedIndex > 0)
                    _obj_smhr_employee.EMP_SUBDIVISION = Convert.ToInt32(rcmb_SubDivision.SelectedItem.Value);
                else
                    _obj_smhr_employee.EMP_SUBDIVISION = null;
                //_obj_smhr_employee.EMP_FUNDNAME = Convert.ToString(rcmb_FundName.SelectedValue);
                //_obj_smhr_employee.EMP_WORKSTATUS = Convert.ToString(rcmb_WorkStatus.SelectedValue);
                _obj_smhr_employee.EMP_MEMBERID = Convert.ToString(rtxt_MemberID.Text);
                if (rcmb_County.SelectedIndex > 0)
                {
                    _obj_smhr_employee.EMP_COUNTY_ID = Convert.ToInt32(rcmb_County.SelectedValue);
                }
                if (rcmb_Period.SelectedIndex > 0)
                {
                    _obj_smhr_employee.EMP_PERIOD_ID = Convert.ToInt32(rcmb_Period.SelectedValue);
                }
                _obj_smhr_employee.EMP_CURRENTPROJECT = Convert.ToString(rtxt_CurrentProject.Text.Replace("'", "''"));
                _obj_smhr_employee.EMP_ISMANUAL = chk_IsManual.Checked;

                #region OtherDetailsNewFields
                _obj_smhr_employee.EMP_ACTIVITY = rtbActivity.Text;
                _obj_smhr_employee.EMP_PROGRAMME = rtbProgramme.Text;
                _obj_smhr_employee.EMP_ORGUNIT = rtbOrgUnit.Text;
                _obj_smhr_employee.EMP_INTERVENTION = rtbIntervention.Text;
                _obj_smhr_employee.EMP_FOCUS_AREA = rtbFocusArea.Text;
                _obj_smhr_employee.EMP_RESULT_AREA = rtbResultArea.Text;
                _obj_smhr_employee.EMP_OUTCOME = rtbOutCome.Text;
                #endregion

                status = BLL.set_Employee(_obj_smhr_employee);
                strPath = "";
                if (status == true)
                {

                    //saveWeeklyOff(_lbl_Emp_ID);
                    //saveOtherDetails(_lbl_Emp_ID);
                    saveWeeklyOff(HF_EMPID.Value);
                    saveOtherDetails(HF_EMPID.Value);
                    saveImportantDates();
                    _obj_SMHR_EMPPHYSICALDETAILS = new SMHR_EMP_PHYSICALDETAILS();

                    _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_EMPID = Convert.ToInt32(HF_EMPID.Value); //Convert.ToInt32(_lbl_Emp_ID);

                    DataTable dt_getPhysicalDetails = BLL.get_PhysicalDetails(_obj_SMHR_EMPPHYSICALDETAILS);//no organisation column has found
                    if (dt_getPhysicalDetails.Rows.Count != 0)
                    {
                        btn_Physical_Update_Click(sender, e);

                    }
                    else
                    {
                        btn_Physical_Save_Click(sender, e);
                    }
                    if ((Convert.ToInt32(rcmb_usergroup.SelectedIndex) > 0) && rtxt_EmailID.Text != string.Empty)
                    {
                        _obj_smhr_employee = new SMHR_EMPLOYEE();
                        _obj_smhr_employee.OPERATION = operation.Select1;
                        _obj_smhr_employee.EMP_ID = Convert.ToInt32(HF_EMPID.Value.ToString()); //Convert.ToInt32(_lbl_Emp_ID.ToString());
                        DataTable dt = BLL.get_EMP_NEWCONTACTS(_obj_smhr_employee);
                        if (dt.Rows.Count != 0)
                        {
                            _obj_smhr_employee.EMP_ID = Convert.ToInt32(HF_EMPID.Value);
                            _obj_smhr_employee.USER_GROUP = Convert.ToInt32(rcmb_usergroup.SelectedItem.Value);
                            _obj_smhr_employee.PASSWORD = BLL.PasswordEncrypt(BLL.ReplaceQuote(rtxt_pwd.Text));
                            _obj_smhr_employee.PASSCODE = BLL.PasswordEncrypt(BLL.ReplaceQuote(rtxt_passcode.Text));
                            _obj_smhr_employee.OPERATION = operation.Update;
                            ViewState["passcode"] = BLL.PasswordEncrypt(BLL.ReplaceQuote(rtxt_passcode.Text));
                            ViewState["passcodeDE"] = BLL.ReplaceQuote(rtxt_passcode.Text);
                            ViewState["randompassword"] = BLL.ReplaceQuote(rtxt_pwd.Text);
                            BLL.set_EMP_NEWCONTACTS(_obj_smhr_employee);
                            if (Convert.ToString(rtxt_EmailID.Text.Replace("'", "''")).Trim() != string.Empty && Convert.ToString(rtxt_EmailID.Text.Replace("'", "''")).Trim() != email)
                            {
                                //  BLL.setemployeelogin(Convert.ToInt32(HF_EMPID.Value), BLL.ReplaceQuote(rtxt_pwd.Text));// sendMail();
                            }
                        }
                        else
                        {
                            bool statusRandom = false;
                            _obj_smhr_employee.EMP_ID = Convert.ToInt32(HF_EMPID.Value);
                            _obj_smhr_employee.USER_GROUP = Convert.ToInt32(rcmb_usergroup.SelectedItem.Value);
                            _obj_smhr_employee.PASSWORD = BLL.PasswordEncrypt(BLL.ReplaceQuote(rtxt_pwd.Text));
                            _obj_smhr_employee.PASSCODE = BLL.PasswordEncrypt(BLL.ReplaceQuote(rtxt_passcode.Text));
                            ViewState["passcode"] = BLL.PasswordEncrypt(BLL.ReplaceQuote(rtxt_passcode.Text));
                            ViewState["passcodeDE"] = BLL.ReplaceQuote(rtxt_passcode.Text);
                            _obj_smhr_employee.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                            _obj_smhr_employee.OPERATION = operation.Insert;
                            statusRandom = BLL.set_EMP_NEWCONTACTS(_obj_smhr_employee);
                            if (statusRandom == true)
                            {
                                string randomPassword = CreateRandomPassword();
                                ViewState["randompassword"] = randomPassword;
                                _obj_smhr_employee.EMP_ID = Convert.ToInt32(HF_EMPID.Value);
                                _obj_smhr_employee.USER_GROUP = Convert.ToInt32(rcmb_usergroup.SelectedItem.Value);
                                _obj_smhr_employee.PASSWORD = BLL.PasswordEncrypt(BLL.ReplaceQuote(randomPassword));
                                _obj_smhr_employee.PASSCODE = BLL.PasswordEncrypt(BLL.ReplaceQuote(rtxt_passcode.Text)); //Convert.ToString(dt.Rows[0]["LOGIN_PASS_CODE"]);
                                _obj_smhr_employee.OPERATION = operation.Update;
                                //BLL.set_EMP_NEWCONTACTS(_obj_smhr_employee);
                                //BLL.setemployeelogin(Convert.ToInt32(HF_EMPID.Value), BLL.ReplaceQuote(randomPassword));// sendMail();
                            }

                            //_obj_smhr_employee.EMP_ID = Convert.ToInt32(HF_EMPID.Value);
                            //_obj_smhr_employee.USER_GROUP = Convert.ToInt32(rcmb_usergroup.SelectedItem.Value);
                            //_obj_smhr_employee.PASSWORD = BLL.PasswordEncrypt(BLL.ReplaceQuote(rtxt_pwd.Text));
                            //_obj_smhr_employee.PASSCODE = BLL.PasswordEncrypt(BLL.ReplaceQuote(rtxt_passcode.Text));
                            //_obj_smhr_employee.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                            //_obj_smhr_employee.OPERATION = operation.Insert;
                            //BLL.set_EMP_NEWCONTACTS(_obj_smhr_employee);
                        }
                    }
                    else
                    {
                        _obj_smhr_employee = new SMHR_EMPLOYEE();
                        _obj_smhr_employee.OPERATION = operation.Select1;
                        _obj_smhr_employee.EMP_ID = Convert.ToInt32(HF_EMPID.Value.ToString()); //Convert.ToInt32(_lbl_Emp_ID.ToString());
                        DataTable dt = BLL.get_EMP_NEWCONTACTS(_obj_smhr_employee);
                        if (dt.Rows.Count != 0)
                        {
                            _obj_smhr_employee.EMP_ID = Convert.ToInt32(HF_EMPID.Value);
                            _obj_smhr_employee.USER_GROUP = Convert.ToInt32(rcmb_usergroup.SelectedItem.Value);
                            _obj_smhr_employee.PASSWORD = BLL.PasswordEncrypt(BLL.ReplaceQuote(rtxt_pwd.Text));
                            _obj_smhr_employee.PASSCODE = BLL.PasswordEncrypt(BLL.ReplaceQuote(rtxt_passcode.Text));
                            _obj_smhr_employee.OPERATION = operation.Update;
                            ViewState["passcode"] = BLL.PasswordEncrypt(BLL.ReplaceQuote(rtxt_passcode.Text));
                            ViewState["passcodeDE"] = BLL.ReplaceQuote(rtxt_passcode.Text);
                            ViewState["randompassword"] = BLL.ReplaceQuote(rtxt_pwd.Text);
                            BLL.set_EMP_NEWCONTACTS(_obj_smhr_employee);
                            if (Convert.ToString(rtxt_EmailID.Text.Replace("'", "''")).Trim() != string.Empty && Convert.ToString(rtxt_EmailID.Text.Replace("'", "''")).Trim() != email)
                            {
                                //  BLL.setemployeelogin(Convert.ToInt32(HF_EMPID.Value), BLL.ReplaceQuote(rtxt_pwd.Text));// sendMail();
                            }
                        }
                    }

                    if (Convert.ToString(Request.QueryString["Filter"]) == string.Empty)
                    {
                        Response.Redirect("~/HR/frmemployee.aspx?ID1=" + Convert.ToString(lbl_Code.Text), false);
                    }

                    else
                    {
                        string str_Query = Convert.ToString(Request.QueryString["Filter"]);
                        string empCode = Convert.ToString(lbl_Code.Text);
                        Response.Redirect(string.Format("~/HR/frmemployee.aspx?Filter1={0} &ID1={1}", str_Query, empCode), false);
                        //Response.Redirect("~/HR/frmemployee.aspx?Filter1=" + Convert.ToString(str_Query) + "&ID1=" + Convert.ToString(lbl_Code.Text));
                    }

                    return;
                }

                else
                {
                    BLL.ShowMessage(this, "Error Occured while Doing the Process");
                    return;
                }

                //}
                //else
                //{
                //    BLL.ShowMessage(this, "Either Gross Salary Entered is greater than or less than the limit of the position selected");
                //    return;
                //}
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx", false);
        }
    }


    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToString(Request.QueryString["Filter"]) == string.Empty)
            {
                Response.Redirect("~/HR/frmemployee.aspx", false);
            }
            else
            {
                string str_Query = Convert.ToString(Request.QueryString["Filter"]);
                Response.Redirect("~/HR/frmemployee.aspx?Filter1=" + Convert.ToString(str_Query), false);
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx", false);
        }
    }

    protected void btn_Shift_refresh_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ddl_Shift.Items.Clear();
            _obj_smhr_shift = new SMHR_SHIFTDEFINITION();
            _obj_smhr_shift.OPERATION = operation.Select;
            _obj_smhr_shift.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_ShiftDefinition(_obj_smhr_shift);
            ddl_Shift.DataSource = dt_Details;
            ddl_Shift.DataTextField = "SHIFT_CODE";
            ddl_Shift.DataValueField = "SHIFT_ID";
            ddl_Shift.DataBind();
            ddl_Shift.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region selectIndexChanged

    protected void chk_Handicapped_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chk_Handicapped.Checked == true)
            {
                lbl_HandicapDetails.Visible = true;
                rtxt_Handicapped.Visible = true;
            }
            else
            {
                lbl_HandicapDetails.Visible = false;
                rtxt_Handicapped.Visible = false;
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //protected void chk_Isvariablepay_CheckedChanged(object sender, EventArgs e)
    //{
    //    if (chk_Isvariablepay.Checked)
    //    {
    //        VariablePay.Visible = true;
    //    }
    //    else
    //    {
    //        VariablePay.Visible = false;
    //    }
    //}
    protected void chk_IsManual_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chk_IsManual.Checked)
            {
                td_lbl_empcode.Visible = true;
                td_colon_empcode.Visible = true;
                td_rtxt_empcode.Visible = true;
                td_rfv_empcode.Visible = true;
                RFV_rtxt_empcode.Enabled = true;
                rtxt_empcode.Visible = true;
            }
            else
            {
                td_lbl_empcode.Visible = false;
                td_colon_empcode.Visible = false;
                td_rtxt_empcode.Visible = false;
                td_rfv_empcode.Visible = false;
                RFV_rtxt_empcode.Enabled = false;
                rtxt_empcode.Visible = false;
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void ddl_Applicant_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (ddl_Applicant.SelectedIndex != 0)
            {
                ViewState["ddlIndex"] = ddl_Applicant.SelectedValue;
                _obj_smhr_applicant = new SMHR_APPLICANT();
                _obj_smhr_applicant.OPERATION = operation.Available;
                _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(ddl_Applicant.SelectedValue);
                _obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                dt_Details1 = BLL.get_Applicant(_obj_smhr_applicant);
                if (dt_Details1.Rows.Count != 0)
                {
                    LoadStructure();
                    ddl_SalaryStructure.SelectedIndex = Convert.ToInt32(ddl_SalaryStructure.FindItemIndexByValue(Convert.ToString(dt_Details1.Rows[0]["JOBOFFRS_SALSTRUCT"])));
                    ddl_LeaveStructure.SelectedIndex = ddl_LeaveStructure.FindItemIndexByValue(Convert.ToString(dt_Details1.Rows[0]["JOBOFFRS_LEAVESTRUCT"]));
                    txt_DOJ.SelectedDate = Convert.ToDateTime(dt_Details1.Rows[0]["JOBOFFRS_JOINDATE"].ToString());//, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    // txt_GrossSalary.Text = Convert.ToString(dt_Details1.Rows[0]["JOBOFFRS_OFFERSAL"]);

                    if (DateTime.Today < txt_DOJ.SelectedDate)    //To validate DOJ
                    {
                        BLL.ShowMessage(this, "Date of Join cannot be GreaterThan Current Date");
                        txt_DOJ.Clear();
                        txt_DOJ.Focus();
                    }
                }

                //  _obj_smhr_applicant = new SMHR_APPLICANT();
                _obj_smhr_applicant.OPERATION = operation.Select;
                //  _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(ddl_Applicant.SelectedValue);
                //   _obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                dt_Details = BLL.get_Applicant(_obj_smhr_applicant);
                if (dt_Details.Rows.Count != 0)
                {
                    //_lbl_App_ID = ddl_Applicant.SelectedValue;
                    HF_APID.Value = ddl_Applicant.SelectedValue;
                    ddl_Title.SelectedValue = Convert.ToString(dt_Details.Rows[0]["APPLICANT_TITLE"]);
                    txt_FirstName.Text = Convert.ToString(dt_Details.Rows[0]["APPLICANT_FIRSTNAME"]);
                    txt_AppMiddleName.Text = Convert.ToString(dt_Details.Rows[0]["APPLICANT_MIDDLENAME"]);
                    txt_AppLastName.Text = Convert.ToString(dt_Details.Rows[0]["APPLICANT_LASTNAME"]);
                    txt_DOB.SelectedDate = Convert.ToDateTime(dt_Details.Rows[0]["APPLICANT_DOB"].ToString());//, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    //txt_DOB.SelectedDate = DateTime.ParseExact(dt_Details.Rows[0]["APPLICANT_DOB"].ToString(), "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    ddl_Gender.SelectedIndex = ddl_Gender.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["APPLICANT_GENDER"]));
                    ddl_BloodGroup.SelectedIndex = ddl_BloodGroup.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["APPLICANT_BLOODGROUP"]));
                    ddl_Religion.SelectedIndex = ddl_Religion.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["APPLICANT_RELIGION_ID"]));
                    ddl_Nationality.SelectedIndex = ddl_Nationality.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["APPLICANT_NATIONALITY_ID"]));
                    ddl_Tribe.SelectedIndex = ddl_Tribe.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["APPLICANT_TRIBE_ID"]));
                    ddl_MaritalStatus.SelectedIndex = ddl_MaritalStatus.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["APPLICANT_MARITALSTATUS"]));
                    txt_Address.Text = Convert.ToString(dt_Details.Rows[0]["APPLICANT_ADDRESS"]);
                    txt_Remarks.Text = Convert.ToString(dt_Details.Rows[0]["APPLICANT_REMARKS"]);
                    LoadExperience();
                    LoadLanguage();
                    LoadQualification();
                    LoadReference();
                    LoadSkill();
                    LoadContact();

                }
            }
            else
            {
                ddl_Title.SelectedIndex = 0;
                txt_FirstName.Text = string.Empty;
                txt_AppMiddleName.Text = string.Empty;
                txt_AppLastName.Text = string.Empty;
                txt_DOB.SelectedDate = null;
                ddl_Gender.SelectedIndex = 0;
                ddl_BloodGroup.SelectedIndex = 0;
                ddl_Religion.SelectedIndex = 0;
                ddl_Nationality.SelectedIndex = 0;
                ddl_Tribe.SelectedIndex = 0;
                ddl_MaritalStatus.SelectedIndex = 0;
                txt_Address.Text = string.Empty;
                txt_Remarks.Text = string.Empty;

                RG_Contact.DataSource = null;
                RG_Contact.DataBind();

                RG_Experience.DataSource = null;
                RG_Experience.DataBind();

                RG_Family.DataSource = null;
                RG_Family.DataBind();

                RG_Language.DataSource = null;
                RG_Language.DataBind();

                RG_OTRate.DataSource = null;
                RG_OTRate.DataBind();

                RG_Qualification.DataSource = null;
                RG_Qualification.DataBind();

                RG_Reference.DataSource = null;
                RG_Reference.DataBind();

                RG_Skills.DataSource = null;
                RG_Skills.DataBind();

                RG_Swipe.DataSource = null;
                RG_Swipe.DataBind();


            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void txt_DOJ_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        try
        {
            if ((txt_DOJ.SelectedDate.HasValue) && (txt_DOB.SelectedDate.HasValue))
            {
                DateTime dt = Convert.ToDateTime(txt_DOB.SelectedDate.Value);
                DateTime BirthDate = Convert.ToDateTime(txt_DOJ.SelectedDate.Value);
                TimeSpan dt1 = BirthDate - dt;
                if (BirthDate <= DateTime.Now)
                {
                    if (dt < DateTime.Now)
                    {
                        double Days = Math.Round((dt1.TotalDays) / 365.25, 0);
                        lbl_Age.Text = Convert.ToString(Days + " years");
                        txt_startDate.SelectedDate = txt_DOJ.SelectedDate.Value;
                        rdp_offDate.SelectedDate = txt_DOJ.SelectedDate.Value;
                        txt_startDate.Enabled = false;
                        if (lbl_Max.Text != string.Empty)
                        {
                            if (Convert.ToDouble(lbl_Max.Text) < Convert.ToDouble(Days))
                            {
                                //BLL.ShowMessage(this, "Age of Employee Is Exceeding the Max Limit of selected Businessunit");
                                BLL.ShowMessage(this, "Age of Employee Is Exceeding the Max Limit of selected Employee Type");
                                txt_DOJ.Clear();
                                txt_DOJ.Focus();
                                return;
                            }
                        }
                    }
                    else
                    {
                        if (txt_DOB.SelectedDate.HasValue)
                        {
                            txt_DOB.Focus();
                        }
                        else
                        {
                            BLL.ShowMessage(this, "Invalid Date of Birth");
                            txt_DOB.SelectedDate = null;
                            return;
                        }
                    }

                }
                else
                {
                    BLL.ShowMessage(this, "Date of Join cannot be GreaterThan Current Date");
                    txt_DOJ.Clear();
                    txt_DOJ.Focus();
                }
            }

            else
            {
                if (txt_DOB.SelectedDate.HasValue)
                {
                    DateTime dt = Convert.ToDateTime(txt_DOB.SelectedDate.Value);
                    dt = dt.AddYears(19);
                    if (dt >= DateTime.Now)
                    {
                        BLL.ShowMessage(this, "Invalid Date of Birth");
                        txt_DOB.SelectedDate = null;
                        return;
                    }
                }
                else
                {
                    txt_DOB.Focus();
                }
            }
            // checking for the existance of the calendar period as leave are going to generated by calendar period
            if (txt_DOJ.SelectedDate.HasValue)
            {
                _obj_smhr_employee = new SMHR_EMPLOYEE();
                _obj_smhr_employee.EMP_DATEOFJOIN = Convert.ToString(txt_DOJ.SelectedDate);
                _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_smhr_employee.OPERATION = operation.Select1;
                rdp_offDate.SelectedDate = txt_DOJ.SelectedDate.Value;
                DataTable Dt = BLL.get_Employee(_obj_smhr_employee);
                if (Dt.Rows.Count > 0)
                {
                    if ((Dt.Rows[0][0]).ToString() == "0")
                    {
                        BLL.ShowMessage(this, "Define Current Calendar Period");
                        txt_DOJ.Clear();
                        return;
                    }
                }

                //To fetch Increment month
                //31.5.2016 divya
                /* _obj_smhr_employee.OPERATION = operation.Select;
                 _obj_smhr_employee.EMP_DATEOFJOIN = Convert.ToDateTime(txt_DOJ.SelectedDate).ToShortDateString();
                 DataTable dt = BLL.get_IncrementMonth(_obj_smhr_employee);
                 if (dt.Rows.Count > 0)
                 {
                     rcmb_IncrementMonth.SelectedValue = Convert.ToString(dt.Rows[0]["INCR_ID"]);
                 }*/
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void ddl_Supervisor_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (ddl_Supervisor.SelectedIndex != 0)
            {
                txt_startDate.Enabled = true;
                txt_endDate.Enabled = true;
                txt_startDate.Focus();
            }
            else
            {
                txt_startDate.Enabled = false;
                //18.1.2016 for enable enddate
                txt_endDate.Enabled = true;
                ddl_EmpStatus.Focus();
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void ddl_Designation_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            //lbl_jobName.Text = string.Empty;
            //getJob(ddl_Designation.SelectedValue);
            if (rcmb_Period.SelectedValue == string.Empty || rcmb_Period.SelectedValue == null)
            {
                BLL.ShowMessage(this, "Please select Financial Period before choose Position");
                ddl_Designation.SelectedIndex = 0;
                return;
            }

            if (ddl_BusinessUnit.SelectedIndex > 0 && ddl_Designation.SelectedValue != string.Empty)
            {
                // ddl_Grade.Items.Clear();
                SMHR_POSITIONS _obj_smhr_positions = new SMHR_POSITIONS();
                _obj_smhr_positions.OPERATION = operation.POSITIONSGRADE;
                _obj_smhr_positions.POSITIONS_ID = Convert.ToInt32(ddl_Designation.SelectedValue);
                _obj_smhr_positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_smhr_positions.POSITIN_PERIOD_ID = Convert.ToInt32(rcmb_Period.SelectedValue);
                DataTable dtPos = BLL.get_Positions(_obj_smhr_positions);


                if (string.Compare(hdnDesignation.Value, ddl_Designation.SelectedValue, true) != 0)
                {
                    _obj_smhr_positions.OPERATION = operation.GETVACANCY;
                    DataTable dtVacancy = BLL.get_Positions(_obj_smhr_positions);
                    if (Convert.ToInt32(dtVacancy.Rows[0][0]) == 0)
                    {
                        //ddl_Designation.SelectedIndex = -1;
                        //ddl_Grade.Items.Clear();
                        BLL.ShowMessage(this, "Establishment not done for this position");
                    }
                    //else if (Convert.ToInt32(dtVacancy.Rows[0][0]) == 1)
                    //{
                    //    ddl_Designation.SelectedIndex = -1;
                    //    ddl_Grade.Items.Clear();
                    //    BLL.ShowMessage(this, "Establishment not finalised for this position");
                    //}
                    else if (Convert.ToInt32(dtVacancy.Rows[0][0]) == 3)
                    {
                        //ddl_Designation.SelectedIndex = -1;
                        //ddl_Grade.Items.Clear();
                        BLL.ShowMessage(this, "There is no vacancy for this position");
                    }
                    else if (Convert.ToInt32(dtVacancy.Rows[0][0]) == 2)
                    {
                        //ddl_Grade.DataSource = dtPos;
                        //ddl_Grade.DataTextField = "CODERANK";
                        //ddl_Grade.DataValueField = "EMPLOYEEGRADE_ID";
                        //ddl_Grade.DataBind();

                        ddl_Slabs.Items.Clear();
                        ddl_Slabs.DataValueField = "EMPLOYEEGRADE_SLAB_ID";
                        ddl_Slabs.DataTextField = "EMPLOYEEGRADE_SLAB_AMOUNT";
                        ddl_Slabs.DataSource = LoadSalarySlabs();
                        ddl_Slabs.DataBind();
                        ddl_Slabs.Items.Insert(0, new RadComboBoxItem { Text = "Select", Value = "0" });
                    }
                }
            }
            else
            {
                ddl_Grade.Items.Clear();
                //ddl_Grade.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void ddl_Jobs_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            getPosition();
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void ddl_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            SMHR_BUSINESSUNIT _obj_smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
            if (ddl_BusinessUnit.SelectedIndex > 0)
            {
                LoadMode();
                LoadCurrency();
                getJobs();
                //getPosition();
                LoadDates();
                //LoadDivision();
                Load_Directorate();
                getSupervisor();
                get_SupBusinessUnit();

                // DataTable dt = BLL.get_Organisation_Isvp(Convert.ToString(Session["ORG_ID"]), Convert.ToString(ddl_BusinessUnit.SelectedValue));
                //if (Convert.ToString(dt.Rows[0]["BUSINESSUNIT_ISVARIABLEAMOUNT"]) == "True")// 1 MEANS THAT ORGANISATION IS HAVING VARIABLE PAY
                //{
                //    chk_Isvariablepay.Enabled = true;
                //    chk_Isvariablepay.Visible = true;
                //    text.Visible = true;
                //    lbl_Isvariablepay.Visible = true;
                //}
                //else
                //{
                //    chk_Isvariablepay.Enabled = false;
                //    chk_Isvariablepay.Checked = false;
                //    chk_Isvariablepay.Visible = false;
                //    text.Visible = false;
                //    lbl_Isvariablepay.Visible = false;
                //    VariablePay.Visible = false;
                //}
            }
            else
            {
                ddl_Mode.Items.Clear();
                ddl_Currency.Items.Clear();
                rcmb_Directorate.Items.Clear();
                ddl_Jobs.Items.Clear();
                ddl_Designation.Items.Clear();
                ddl_Jobs.Items.Clear();
                ddl_Supervisor.Items.Clear();
                ddl_Department.Items.Clear();
                ddl_Sup_BusinessUnit.ClearSelection();
                ddl_Currency.SelectedIndex = 0;
                lbl_Code.Text = string.Empty;
            }
            rcmb_Devision.ClearSelection();
            rcmb_Devision.Items.Clear();
            rcmb_Devision.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            rcmb_SubDivision.ClearSelection();
            rcmb_SubDivision.Items.Clear();
            rcmb_SubDivision.Items.Insert(0, new RadComboBoxItem("Select", "0"));
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_Directorate_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            LoadDepartment();
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Load_Directorate()
    {
        try
        {
            rcmb_Directorate.Items.Clear();

            if (Convert.ToString(Session["ORG_ID"]) != string.Empty)
            {
                //Load Directorate
                SMHR_DIRECTORATE _obj_Smhr_Directorate = new SMHR_DIRECTORATE();
                _obj_Smhr_Directorate.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_Directorate.BUSINESSUNIT_ID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
                _obj_Smhr_Directorate.OPERATION = operation.Check_Emp;
                DataTable DT = BLL.get_Directorate(_obj_Smhr_Directorate);
                rcmb_Directorate.DataTextField = "DIRECTORATE_CODE";
                rcmb_Directorate.DataValueField = "DIRECTORATE_ID";
                rcmb_Directorate.DataSource = DT;
                rcmb_Directorate.DataBind();
                rcmb_Directorate.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void Load_Directorate_Edit()
    {
        try
        {
            rcmb_Directorate.Items.Clear();

            if (Convert.ToString(Session["ORG_ID"]) != string.Empty)
            {
                //Load Directorate
                SMHR_DIRECTORATE _obj_Smhr_Directorate = new SMHR_DIRECTORATE();
                _obj_Smhr_Directorate.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_Directorate.BUSINESSUNIT_ID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
                DataTable DT = BLL.get_Directorate(_obj_Smhr_Directorate);
                rcmb_Directorate.DataTextField = "DIRECTORATE_CODE";
                rcmb_Directorate.DataValueField = "DIRECTORATE_ID";
                rcmb_Directorate.DataSource = DT;
                rcmb_Directorate.DataBind();
                rcmb_Directorate.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void ddl_EmpStatus_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (ddl_EmpStatus.SelectedIndex > 0)
            {
                SMHR_EMPLOYEETYPE _obj_Smhr_EMPLOYEETYPE = new SMHR_EMPLOYEETYPE();
                _obj_Smhr_EMPLOYEETYPE.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_EMPLOYEETYPE.EMPLOYEETYPE_ID = Convert.ToInt32(ddl_EmpStatus.SelectedValue);
                DataTable dtEmpType = BLL.get_EmployeeType(_obj_Smhr_EMPLOYEETYPE);
                if (dtEmpType.Rows.Count == 1)
                {
                    if (string.IsNullOrEmpty(Convert.ToString(dtEmpType.Rows[0]["EmployeeTypeAge"])))
                    {
                        BLL.ShowMessage(this, "Please define Age-limits for selected Employee Type");
                        return;
                    }
                    string str_DOBE = Convert.ToString(dtEmpType.Rows[0]["EmployeeTypeAge"]);
                    string str_DOBS = str_DOBE.Replace("-", "");
                    int_DOBS = Convert.ToInt32(str_DOBS.Substring(0, 2));
                    int_DOBE = Convert.ToInt32(str_DOBS.Substring(2, 2));
                    lbl_Max.Text = str_DOBS.Substring(2, 2);    //To specify the max age

                    if (txt_DOB.SelectedDate.HasValue)  //To check the age validation
                    {
                        CheckDOB();
                    }
                }
            }

            //int count = 0;
            //31.5.2016
            /*if ((ddl_EmpStatus.SelectedItem.Text).ToUpper() == "CONTRACT" || string.Compare((ddl_EmpStatus.SelectedItem.Text).ToUpper(), "Members of Parliament", true) == 0 || string.Compare((ddl_EmpStatus.SelectedItem.Text).ToUpper(), "Members of Senate", true) == 0)
            {
                contract.Visible = true;
                contracts = true;
            }
            else
            {
                if (lbl_Code.Text == "")
                {
                    if (ddl_EmpStatus.SelectedItem.Text == "Permanent")
                    {
                        //getEmpCode();
                    }
                }
                contract.Visible = false;
                lbl_Supismandatory.Visible = true;
                chk_Mandatory.Visible = true;
            }*/
            // Calculate_Basic();
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void Calculate_Basic()
    {
        //if (txt_GrossSalary.Text != string.Empty)
        //{
        //    if (Convert.ToDouble(txt_GrossSalary.Text) >= 0)
        //    {
        //        if (contracts)
        //        {
        //            txt_BasicPay.Text = txt_GrossSalary.Text;
        //        }
        //        else
        //        {
        //            //code for getting Basic percentage of Gross For the businessunit selected
        //            _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
        //            _obj_smhr_businessunit.OPERATION = operation.Select;
        //            _obj_smhr_businessunit.BUSINESSUNIT_ID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
        //            _obj_smhr_businessunit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
        //            DataTable dt_BusinessUnit = BLL.get_BusinessUnit(_obj_smhr_businessunit);
        //            if ((dt_BusinessUnit.Rows.Count > 0) && (ddl_BusinessUnit.SelectedValue != string.Empty))
        //            {
        //                _obj_smhr_businessunit.OPERATION = operation.Get_BULocalization;
        //                DataTable dtBuLocal = BLL.get_BusinessUnit(_obj_smhr_businessunit);
        //                if (dtBuLocal.Rows.Count > 0)
        //                {
        //                    float strSuperAnnuation = Convert.ToSingle(0.00);
        //                    //if (Convert.ToString(dtBuLocal.Rows[0]["HR_MASTER_CODE"]).ToUpper() == "AUSTRALIA")
        //                    //{
        //                    //    float emp_GrossSal = Convert.ToSingle(txt_GrossSalary.Text.Replace("'", "''"));
        //                    //    strSuperAnnuation = Convert.ToSingle(emp_GrossSal * 0.09);
        //                    //    txt_BasicPay.Text = Convert.ToString(emp_GrossSal - strSuperAnnuation);
        //                    //    if (lbl_jobName.Text != "")
        //                    //    {
        //                    //        if (!((Convert.ToDouble(txt_GrossSalary.Text) >= minsal) && (Convert.ToDouble(txt_GrossSalary.Text) <= maxsal)))
        //                    //        {
        //                    //            BLL.ShowMessage(this, "Gross Must be in the range of Selected Job Min and Max Salary:" + minsal + "-" + maxsal);
        //                    //            txt_GrossSalary.Text = "";
        //                    //            txt_BasicPay.Text = "";
        //                    //            return;
        //                    //        }
        //                    //    }
        //                    //}
        //                    //else
        //                    //{
        //                    if (dt_BusinessUnit.Rows[0]["BUSINESSUNIT_BASICPERCENT"] != System.DBNull.Value)
        //                    {
        //                        float IBasicPercent = Convert.ToSingle(dt_BusinessUnit.Rows[0]["BUSINESSUNIT_BASICPERCENT"]);

        //                        float emp_GrossSal = Convert.ToSingle(txt_GrossSalary.Text.Replace("'", "''"));
        //                        //float emp_BasicSal = (55 * emp_GrossSal) / 100;
        //                        float emp_BasicSal = (IBasicPercent * emp_GrossSal) / 100;
        //                        txt_BasicPay.Text = Convert.ToString(emp_BasicSal);
        //                        //if (ddl_Jobs.SelectedValue != "Select")
        //                        //{
        //                        //    if (!((Convert.ToDouble(txt_GrossSalary.Text) >= minsal) && (Convert.ToDouble(txt_GrossSalary.Text) <= maxsal)))
        //                        //    {
        //                        //        BLL.ShowMessage(this, "Gross Must be in the range of Selected Job Min and Max Salary:" + minsal + "-" + maxsal);
        //                        //        txt_GrossSalary.Text = "";
        //                        //        txt_BasicPay.Text = "";
        //                        //        return;
        //                        //    }
        //                        //}
        //                    }
        //                    else
        //                    {
        //                        BLL.ShowMessage(this, "Basic Is Not Defined For The Businessunit:" + ddl_BusinessUnit.SelectedItem.Text);
        //                        txt_GrossSalary.Text = "";
        //                        return;
        //                    }
        //                    //}
        //                }
        //            }
        //            else
        //            {
        //                BLL.ShowMessage(this, "Select Proper Businessunit");
        //                txt_GrossSalary.Text = "";
        //            }

        //        }
        //    }
        //    else
        //    {
        //        BLL.ShowMessage(this, "Gross Must be Greater Than Zero!");
        //        txt_BasicPay.Text = "";
        //        txt_GrossSalary.Focus();
        //    }
        //}
        ////else
        ////{
        ////    BLL.ShowMessage(this, "Enter Gross Salary");
        ////    txt_GrossSalary.Focus();
        ////}
    }

    private void LoadDates()
    {
        try
        {
            _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
            _obj_smhr_businessunit.OPERATION = operation.Select;
            _obj_smhr_businessunit.BUSINESSUNIT_ID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
            _obj_smhr_businessunit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_bu = BLL.get_BusinessUnit(_obj_smhr_businessunit);
            if (dt_bu.Rows.Count == 1)
            {
                //string str_DOBE = Convert.ToString(dt_bu.Rows[0]["BUSINESSUNIT_AGE"]);
                //string str_DOBS = str_DOBE.Replace("-", "");
                //int_DOBS = Convert.ToInt32(str_DOBS.Substring(0, 2));
                //int_DOBE = Convert.ToInt32(str_DOBS.Substring(2, 2));
                //lbl_Max.Text = str_DOBS.Substring(2, 2);
                int_DF = Convert.ToString(dt_bu.Rows[0]["BUSINESSUNIT_DATEFORMAT_ID"]);
                LoadDateFormat(int_DF);
               // txt_DOJ.MinDate = Convert.ToDateTime(dt_bu.Rows[0]["BUSINESSUNIT_STARTDATE"]);
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    private void LoadDateFormat(string dateformat)
    {
        try
        {
            if (txt_DOB.SelectedDate.HasValue)
            {
                CheckDOB();
            }
            string str_dateformat = "";
            if (dateformat == "1")
            {
                str_dateformat = "dd/MM/yyyy";
            }
            else if (dateformat == "2")
            {
                str_dateformat = "MM/dd/yyyy";
            }
            else
            {
                str_dateformat = "yyyy-MM-dd";
            }
            txt_DOB.DateInput.DateFormat = str_dateformat;
            txt_DOJ.DateInput.DateFormat = str_dateformat;
            txt_DOC.DateInput.DateFormat = str_dateformat;
            txt_probDate.DateInput.DateFormat = str_dateformat;
            rdp_contract_start.DateInput.DateFormat = str_dateformat;
            rdp_contract_end.DateInput.DateFormat = str_dateformat;
            txt_IncrementDate.DateInput.DateFormat = str_dateformat;
            rdp_offDate.DateInput.DateFormat = str_dateformat;
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadDivision()
    {
        try
        {
            if (ddl_Department.SelectedValue != null)
            {
                rcmb_Devision.Items.Clear();
                _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
                _obj_smhr_businessunit.OPERATION = operation.Select1;
                _obj_smhr_businessunit.BUID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
                if (ddl_Department.SelectedIndex > 0)
                {
                    _obj_smhr_businessunit.DEPARTMENT_ID = ddl_Department.SelectedValue != string.Empty ? Convert.ToInt32(ddl_Department.SelectedValue) : 0;
                }
                else
                {
                    _obj_smhr_businessunit.DEPARTMENT_ID = 0;
                }
                if (rcmb_Directorate.SelectedIndex > 0)
                {
                    _obj_smhr_businessunit.DIRECTORATE_ID = rcmb_Directorate.SelectedValue != string.Empty ? Convert.ToInt32(rcmb_Directorate.SelectedValue) : 0;
                }
                else
                {
                    _obj_smhr_businessunit.DIRECTORATE_ID = 0;
                }
                //  _obj_smhr_businessunit.BUID = ddl_Department.SelectedValue != string.Empty ? Convert.ToInt32(ddl_Department.SelectedValue) : 0;
                _obj_smhr_businessunit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable Dt_Divisions = BLL.Get_Divisions(_obj_smhr_businessunit);
                if (Dt_Divisions.Rows.Count > 0)
                {
                    rcmb_Devision.DataSource = Dt_Divisions;
                    rcmb_Devision.DataTextField = "SMHR_DIV_CODE";
                    rcmb_Devision.DataValueField = "SMHR_DIV_ID";
                    rcmb_Devision.DataBind();
                }
                rcmb_Devision.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            }
            else
                rcmb_Devision.Items.Clear();
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadMode()
    {
        try
        {
            if (ddl_BusinessUnit.SelectedIndex != 0)
            {
                //Payment Modes
                _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
                _obj_smhr_businessunit.OPERATION = operation.Empty;
                _obj_smhr_businessunit.BUSINESSUNIT_ID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
                _obj_smhr_businessunit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt = BLL.get_BusinessUnit(_obj_smhr_businessunit);
                ddl_Mode.DataSource = dt;
                ddl_Mode.DataTextField = "HR_MASTER_CODE";
                ddl_Mode.DataValueField = "HR_MASTER_ID";
                ddl_Mode.DataBind();
                ddl_Mode.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadCurrency()
    {
        try
        {
            ddl_Currency.Text = string.Empty;
            ddl_Currency.Items.Clear();
            if (ddl_BusinessUnit.SelectedIndex != 0)
            {
                //COMENTED ON 13.03.2013 AS WE R LOADING CURRENCY FROM CURRENCY CONVERSION MASTERS
                ////_obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
                ////_obj_smhr_businessunit.OPERATION = operation.EMPTY1;
                ////_obj_smhr_businessunit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                ////_obj_smhr_businessunit.BUSINESSUNIT_ID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
                ////DataTable dt = BLL.get_BusinessUnit(_obj_smhr_businessunit);
                SMHR_CURRENCY_CONVERSION _obj_Curr_Conv = new SMHR_CURRENCY_CONVERSION();
                _obj_Curr_Conv.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Curr_Conv.MODE = 6;
                DataTable dt = BLL.get_Currency_Conversion(_obj_Curr_Conv);
                if (dt.Rows.Count != 0)
                {

                    ddl_Currency.DataSource = dt;
                    ddl_Currency.DataTextField = "CURR_CODE";
                    ddl_Currency.DataValueField = "CURR_ID";
                    ddl_Currency.DataBind();
                    ddl_Currency.Items.Insert(0, new RadComboBoxItem("Select"));
                    //ddl_Currency.SelectedIndex = ddl_Currency.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["BUSINESSUNIT_CURRENCY_ID"]));
                }
                else
                {
                    ddl_Currency.Items.Insert(0, new RadComboBoxItem("Select"));
                    ddl_Currency.SelectedIndex = 0;
                }
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadPeriod()
    {
        try
        {
            rcmb_Period.Items.Clear();
            SMHR_PERIOD PRD = new SMHR_PERIOD();
            PRD.OPERATION = operation.PERIOD;
            PRD.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT = new DataTable();
            DT = BLL.GetEmployeePeriod(PRD);
            //rcmb_Period.DataSource = BLL.GetEmployeePeriod(PRD);
            if (DT.Rows.Count > 0)
            {
                rcmb_Period.DataSource = DT;
                rcmb_Period.DataTextField = "PERIOD_NAME";
                rcmb_Period.DataValueField = "PERIOD_ID";
                rcmb_Period.DataBind();
            }
            rcmb_Period.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadGrades()
    {
        try
        {
            ddl_Grade.Items.Clear();

            SMHR_EMPLOYEEGRADE _obj_Emp_Grade = new SMHR_EMPLOYEEGRADE();

            ddl_Grade.Items.Clear();
            //ddl_Grade.ClearSelection();

            _obj_Emp_Grade.OPERATION = operation.EmployeeGrade;
            _obj_Emp_Grade.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            DataTable dt = BLL.GetEmployeeGrade(_obj_Emp_Grade);

            if (dt.Rows.Count > 0)
            {
                ddl_Grade.DataSource = dt;
                ddl_Grade.DataTextField = "EMPLOYEEGRADE_CODE";
                ddl_Grade.DataValueField = "EMPLOYEEGRADE_ID";
                ddl_Grade.DataBind();
            }
            ddl_Grade.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void CheckDOB()
    {
        try
        {
            if (txt_DOJ.SelectedDate.HasValue)
            {
                if (ddl_EmpStatus.SelectedIndex > 0)    //To validate age based on EmployeeType
                {
                    SMHR_EMPLOYEETYPE _obj_Smhr_EMPLOYEETYPE = new SMHR_EMPLOYEETYPE();
                    _obj_Smhr_EMPLOYEETYPE.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Smhr_EMPLOYEETYPE.EMPLOYEETYPE_ID = Convert.ToInt32(ddl_EmpStatus.SelectedValue);
                    DataTable dtEmpType = BLL.get_EmployeeType(_obj_Smhr_EMPLOYEETYPE);
                    if (dtEmpType.Rows.Count == 1)
                    {
                        string str_DOBE = Convert.ToString(dtEmpType.Rows[0]["EmployeeTypeAge"]);
                        string str_DOBS = str_DOBE.Replace("-", "");
                        //int_DOBS = Convert.ToInt32(str_DOBS.Substring(0, 2));
                        //int_DOBE = Convert.ToInt32(str_DOBS.Substring(2, 2));
                        lbl_Max.Text = str_DOBS.Substring(2, 2);    //To specify the max age
                    }
                }



                DateTime dt = Convert.ToDateTime(txt_DOB.SelectedDate.Value);
                DateTime BirthDate = Convert.ToDateTime(txt_DOJ.SelectedDate.Value);
                TimeSpan dt1 = BirthDate - dt;
                if (dt < DateTime.Now)
                {
                    string str = Convert.ToString(Convert.ToDouble((dt1.TotalDays) / 365.25));

                    if (str.Contains("."))

                        str = str.Substring(0, (str.IndexOf('.')));

                    double Days = Convert.ToDouble(str);
                    // double Days = Math.Round((dt1.TotalDays) / 365.25, 0);
                    if (Days >= 18)
                    {
                        lbl_Age.Text = Convert.ToString(Days + " years");
                        txt_startDate.SelectedDate = txt_DOJ.SelectedDate.Value;
                        if (lbl_Max.Text != string.Empty)
                        {
                            if (Convert.ToDouble(lbl_Max.Text) < Convert.ToDouble(Days))
                            {
                                //BLL.ShowMessage(this, "Age of Employee Is Exceeding the Max Limit of selected Businessunit");
                                BLL.ShowMessage(this, "Age of Employee Is Exceeding the Max Limit of selected Employee Type");
                                txt_DOB.Clear();
                                txt_DOB.Focus();
                                //txt_DOJ.Clear();
                                //txt_DOJ.Focus();
                                return;
                            }
                        }
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Employee should be more than " + int_MIN + " years of age");
                        txt_DOB.Clear();
                        txt_DOB.Focus();
                    }
                }
                else
                {
                    txt_DOB.SelectedDate = null;
                    txt_DOB.Focus();
                    BLL.ShowMessage(this, "Invalid Date of Birth");
                    return;
                }
            }
            else
            {
                DateTime dt = Convert.ToDateTime(txt_DOB.SelectedDate.Value);
                ///////////////// Added By Joseph///////////////
                DateTime BirthDate = DateTime.Now;
                TimeSpan dt1 = BirthDate - dt;
                if (dt < DateTime.Now)
                {
                    string str = Convert.ToString(Convert.ToDouble((dt1.TotalDays) / 365.25));

                    if (str.Contains("."))

                        str = str.Substring(0, (str.IndexOf('.')));

                    double Days = Convert.ToDouble(str);
                    //double Days = Math.Round((dt1.TotalDays) / 365.25, 0);
                    if (int_DOBS < Days)
                    {
                        if (int_DOBE < Days)
                        {
                            if (Days > 18)
                            {
                                lbl_Age.Text = Convert.ToString(Days + " years");
                            }
                            else
                            {
                                txt_DOB.SelectedDate = null;
                                txt_DOB.Focus();
                                BLL.ShowMessage(this, "Employee should not be more than " + int_DOBE + " years of age");
                            }
                        }
                        else
                        {
                            lbl_Age.Text = Convert.ToString(Days + " years");
                        }
                    }
                    else
                    {
                        txt_DOB.SelectedDate = null;
                        txt_DOB.Focus();
                        BLL.ShowMessage(this, "Employee should be more than " + int_DOBS + " years of age");
                    }
                }
                else
                {
                    txt_DOB.SelectedDate = null;
                    txt_DOB.Focus();
                    BLL.ShowMessage(this, "Invalid Date of Birth");
                }
                /////////////////Completed///////////////
                //dt = dt.AddYears(int_DOBS);
                //if (dt >= DateTime.Now)
                //{
                //    BLL.ShowMessage(this, "Invalid Date of Birth");
                //    txt_DOB.SelectedDate = null;
                //    return;
                //}
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void txt_DOB_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        try
        {
            if (txt_DOB.SelectedDate < DateTime.Now)
            {
                CheckDOB();
                //return;
            }
            else
            {
                BLL.ShowMessage(this, "Invalid Date of birth");
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadDepartment()
    {
        try
        {
            if (ddl_BusinessUnit.SelectedIndex != 0)
            {
                _obj_Department = new SMHR_DEPARTMENT();
                _obj_Department.MODE = 7;
                _obj_Department.DIRECTORATE_ID = rcmb_Directorate.SelectedValue != string.Empty ? Convert.ToInt32(rcmb_Directorate.SelectedValue) : 0;
                _obj_Department.BUID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
                DataTable dt = BLL.get_Department(_obj_Department);
                ddl_Department.DataSource = dt;
                ddl_Department.DataTextField = "DEPARTMENT_NAME";
                ddl_Department.DataValueField = "DEPARTMENT_ID";
                ddl_Department.DataBind();
                ddl_Department.Items.Insert(0, new RadComboBoxItem("Select"));
            }
            else
            {

            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    //modified supervisor business unit

    protected void ddl_Sup_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            //_obj_SMHR_LoginInfo.OPERATION = operation.Check_New;
            //_obj_SMHR_LoginInfo.LOGIN_BUSINESSUNITID = Convert.ToString(ddl_Sup_BusinessUnit.SelectedItem.Text).ToUpper();
            //DataTable dt_getBUSINESS_ID = BLL.get_Sup_BusinessUnit(_obj_SMHR_LoginInfo);
            //string str_BUSINESSUNIT_ID = Convert.ToString(dt_getBUSINESS_ID.Rows[0][0]);

            string str_BUSINESSUNIT_ID = Convert.ToString(ddl_Sup_BusinessUnit.SelectedItem.Value);
            if (str_BUSINESSUNIT_ID == "")
            {
                //ddl_BusinessUnit_SelectedIndexChanged(null,null);
                getSupervisor();
            }
            else
            {
                _obj_SMHR_LoginInfo.OPERATION = operation.Check;
                _obj_SMHR_LoginInfo.BUID = Convert.ToInt32(str_BUSINESSUNIT_ID);
                DataTable dt_getEMP = BLL.get_Sup_BusinessUnit(_obj_SMHR_LoginInfo);

                ddl_Supervisor.Items.Clear();
                ddl_Supervisor.DataSource = dt_getEMP;
                ddl_Supervisor.DataTextField = "EMP_NAME";
                ddl_Supervisor.DataValueField = "EMP_ID";
                ddl_Supervisor.DataBind();
                ddl_Supervisor.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    private void get_SupBusinessUnit()
    {
        try
        {
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.OPERATION = operation.Validate1;
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.BUID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
            DataTable dt_BusinessUnit = BLL.get_Sup_BusinessUnit(_obj_SMHR_LoginInfo);
            if (dt_BusinessUnit.Rows.Count != 0)
            {
                ddl_Sup_BusinessUnit.DataSource = dt_BusinessUnit;
                ddl_Sup_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
                ddl_Sup_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
                ddl_Sup_BusinessUnit.DataBind();// due to this statement only in edit mode it is not finding the employee sup businessunit
                ddl_Sup_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #region picture

    byte[] ReadFile(string sPath)
    {
        byte[] data = null;
        FileInfo fInfo = new FileInfo(sPath);
        long numBytes = fInfo.Length;
        FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);
        BinaryReader br = new BinaryReader(fStream);
        data = br.ReadBytes((int)numBytes);
        //string Value = "";
        //Value = BitConverter.ToString(data);
        return data;
    }

    #endregion

    #region Validations

    private void getDates()
    {
        try
        {
            if (txt_DOJ.SelectedDate.HasValue)
            {
                DateTime dt = Convert.ToDateTime(txt_DOB.SelectedDate.Value);
                DateTime BirthDate = Convert.ToDateTime(txt_DOJ.SelectedDate.Value);
                TimeSpan dt1 = BirthDate - dt;
                double Days = Math.Round((dt1.TotalDays) / 365.25, 0);
                lbl_Age.Text = Convert.ToString(Days + " years");
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void getSupervisor()
    {
        try
        {
            if (Convert.ToString(Request.QueryString["EID"]) != null)
            {
                if (ddl_Sup_BusinessUnit.SelectedIndex > 0)
                {

                    //_obj_smhr_employee.OPERATION = operation.Check1;
                    _obj_smhr_employee.OPERATION = operation.Select2;
                    _obj_smhr_employee.EMP_BUSINESSUNIT_ID = Convert.ToInt32(ddl_Sup_BusinessUnit.SelectedValue);
                    _obj_smhr_employee.EMP_ID = Convert.ToInt32(Convert.ToString(Request.QueryString["EID"]));
                    DataTable dt_Employee = BLL.get_DefaultSupervisor(_obj_smhr_employee);
                    if (dt_Employee.Rows.Count != 0)
                    {
                        ddl_Supervisor.DataSource = dt_Employee;
                        ddl_Supervisor.DataTextField = "EMP_NAME";
                        ddl_Supervisor.DataValueField = "EMP_ID";
                        ddl_Supervisor.DataBind();
                        ddl_Supervisor.Items.Insert(0, new RadComboBoxItem("Select"));
                    }
                    else
                    {
                        Session["Supervisor"] = true;
                    }
                }
                else
                {
                    if (ddl_BusinessUnit.SelectedIndex > 0)
                    {
                        ddl_Supervisor.Items.Clear();
                        _obj_smhr_employee = new SMHR_EMPLOYEE();
                        //_obj_smhr_employee.OPERATION = operation.Check;
                        _obj_smhr_employee.OPERATION = operation.Select2;
                        _obj_smhr_employee.EMP_BUSINESSUNIT_ID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
                        _obj_smhr_employee.EMP_ID = Convert.ToInt32(Convert.ToString(Request.QueryString["EID"]));
                        //DataTable dtDetails = BLL.get_Supervisor(_obj_smhr_employee);
                        DataTable dtDetails = BLL.get_DefaultSupervisor(_obj_smhr_employee);
                        _obj_smhr_employee.OPERATION = operation.Empty;
                        DataTable dt_BU = BLL.get_DefaultSupervisor(_obj_smhr_employee);
                        string def_Supervisor = Convert.ToString(dt_BU.Rows[0]["BUSINESSUNIT_SUPERVISOR"]);
                        ddl_Supervisor.DataSource = dtDetails;
                        ddl_Supervisor.DataTextField = "EMP_NAME";
                        ddl_Supervisor.DataValueField = "EMP_ID";
                        ddl_Supervisor.DataBind();
                        ddl_Supervisor.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                        if (def_Supervisor != "")
                            if (ddl_Supervisor.Items.FindItemByValue(Convert.ToString(dt_BU.Rows[0]["BUSINESSUNIT_SUPERVISOR"])) != null)
                                ddl_Supervisor.SelectedValue = Convert.ToString(dt_BU.Rows[0]["BUSINESSUNIT_SUPERVISOR"]);

                        ddl_Employee.Items.Clear();
                        if (dtDetails.Rows.Count > 0)
                        {
                            ddl_Employee.DataSource = dtDetails;
                            ddl_Employee.DataTextField = "EMP_NAME";
                            ddl_Employee.DataValueField = "EMP_ID";
                            ddl_Employee.DataBind();
                            ddl_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                        }
                        else
                        {
                            Session["Supervisor"] = true;
                            ddl_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                        }
                    }
                    else
                    {
                        ddl_Employee.Items.Clear();
                        ddl_Supervisor.Items.Clear();

                    }
                }
            }
            else
            {
                if (ddl_BusinessUnit.SelectedIndex != 0)
                {
                    ddl_Supervisor.Items.Clear();
                    _obj_smhr_employee = new SMHR_EMPLOYEE();
                    _obj_smhr_employee.OPERATION = operation.Delete;
                    _obj_smhr_employee.EMP_BUSINESSUNIT_ID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
                    DataTable dtDetails = BLL.get_Employee(_obj_smhr_employee);
                    ddl_Supervisor.DataSource = dtDetails;
                    ddl_Supervisor.DataTextField = "EMP_NAME";
                    ddl_Supervisor.DataValueField = "EMP_ID";
                    ddl_Supervisor.DataBind();
                    ddl_Supervisor.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

                    ddl_Employee.Items.Clear();
                    ddl_Employee.DataSource = dtDetails;
                    ddl_Employee.DataTextField = "EMP_NAME";
                    ddl_Employee.DataValueField = "EMP_ID";
                    ddl_Employee.DataBind();
                    ddl_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                }
                else
                {
                    ddl_Employee.Items.Clear();
                    ddl_Supervisor.Items.Clear();
                }
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void get_NewCode()
    {
        try
        {
            string strVal = Convert.ToString(lbl_Code.Text);
            string[] str = strVal.Split(new char[] { '-' });
            _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
            _obj_smhr_businessunit.BUSINESSUNIT_ID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
            DataTable dt_BU = BLL.get_BusinessUnit(_obj_smhr_businessunit);
            if (dt_BU.Rows.Count != 0)
            {
                lbl_Code.Text = Convert.ToString(str[0]) + '-' + Convert.ToString(dt_BU.Rows[0]["BUSINESSUNIT_EMPCODE"]);
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //private bool chk_Salary()
    //{
    //    bool status = false;
    //    if (ddl_Designation.SelectedIndex != 0)
    //    {
    //        _obj_smhr_employee = new SMHR_EMPLOYEE();
    //        _obj_smhr_employee.EMP_DESIGNATION_ID = Convert.ToInt32(ddl_Designation.SelectedValue);
    //        _obj_smhr_employee.OPERATION = operation.Empty;
    //        DataTable dt = BLL.get_Supervisor(_obj_smhr_employee);

    //        if (dt.Rows.Count != 0)
    //        {
    //            if (((dt.Rows[0]["JOBS_MINSAL"] != "") && (dt.Rows[0]["JOBS_MINSAL"] != System.DBNull.Value)) &&
    //                    ((dt.Rows[0]["JOBS_MAXSAL"] != "") && (dt.Rows[0]["JOBS_MAXSAL"] != System.DBNull.Value)))
    //            {
    //                if (Convert.ToDouble(txt_GrossSalary.Value) < Convert.ToDouble(dt.Rows[0]["JOBS_MINSAL"]))
    //                    status = false;
    //                else
    //                {
    //                    if (Convert.ToDouble(txt_GrossSalary.Value) > Convert.ToDouble(dt.Rows[0]["JOBS_MAXSAL"]))
    //                        status = false;
    //                    else
    //                        status = true;
    //                }
    //            }
    //        }
    //    }
    //    else
    //    {
    //        status = true;
    //    }
    //    return status;

    //}

    #endregion

    #region Physical Details

    /// <summary>
    /// Function   :   Here we adding Contact Details and Physical Details of the employee
    ///                to SMHR_EMPLOYEE and SMHR_EMP_PHYSICALDETAILS table respectively.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_Physical_Save_Click(object sender, EventArgs e)
    {
        try
        {

            //Contact Details
            _obj_smhr_employee = new SMHR_EMPLOYEE();
            _obj_smhr_employee.EMP_ID = Convert.ToInt32(HF_EMPID.Value); //Convert.ToInt32(_lbl_Emp_ID);

            //_obj_smhr_employee.OPERATION=operation.Select_New;
            //DataTable dt_getNEWCONTACTSDETAILS=BLL.get_EMP_NEWCONTACTS(_obj_smhr_employee);

            string _str_EMP_ID = Convert.ToString(_obj_smhr_employee.EMP_ID);
            _obj_smhr_employee.OPERATION = operation.Select_EMPID;
            DataTable dt_getEMP_ID = BLL.get_EMP_NEWCONTACTS(_obj_smhr_employee);

            int check = 0;
            if (dt_getEMP_ID.Rows.Count != 0)
            {
                for (int EMP_ID = 0; EMP_ID < dt_getEMP_ID.Rows.Count; EMP_ID++)
                {
                    check = 1;

                    if (Convert.ToString(dt_getEMP_ID.Rows[EMP_ID][0]) == _str_EMP_ID)
                    {
                        _obj_smhr_employee.OPERATION = operation.Insert1;
                        _obj_smhr_employee.EMP_MOBILENO = Convert.ToString(rmtxt_MobileNo.Text.Replace("'", "''"));
                        _obj_smhr_employee.EMP_LANDLINENO = Convert.ToString(rmtxt_LandlineNo.Text.Replace("'", "''"));
                        _obj_smhr_employee.EMP_EMAILID = Convert.ToString(rtxt_EmailID.Text.Replace("'", "''"));
                        _obj_smhr_employee.EMP_ID = Convert.ToInt32(HF_EMPID.Value);// Convert.ToInt32(_lbl_Emp_ID);
                        _obj_smhr_employee.EMP_SKYPEID = Convert.ToString(txtSkypeId.Text.Replace("'", "''"));
                        _obj_smhr_employee.EMP_EXTENSION = Convert.ToString(rntbExtensionNo.Text.Replace("'", "''"));
                        BLL.set_EMP_NEWCONTACTS(_obj_smhr_employee);
                        BLL.ShowMessage(this, "Records Inserted Successfully");

                        //if (dt_getNEWCONTACTSDETAILS.Rows[0].ItemArray[0].ToString() == null || dt_getNEWCONTACTSDETAILS.Rows[0].ItemArray[1].ToString() == null || dt_getNEWCONTACTSDETAILS.Rows[0].ItemArray[2].ToString() == null)
                        //{
                        //    _obj_smhr_employee.OPERATION = operation.Insert1;
                        //    _obj_smhr_employee.EMP_MOBILENO = Convert.ToString(rmtxt_MobileNo.Text.Replace("'", "''"));
                        //    _obj_smhr_employee.EMP_LANDLINENO = Convert.ToString(rmtxt_LandlineNo.Text.Replace("'", "''"));
                        //    _obj_smhr_employee.EMP_EMAILID = Convert.ToString(rtxt_EmailID.Text.Replace("'", "''"));
                        //    _obj_smhr_employee.EMP_ID = 118;// Convert.ToInt32(_lbl_Emp_ID);

                        //    BLL.set_EMP_NEWCONTACTS(_obj_smhr_employee);
                        //    BLL.ShowMessage(this, "Records Inserted Successfully");
                        //}
                        //else
                        //{
                        //    BLL.ShowMessage(this, "data already exists");
                        //}
                    }
                    if (check == 0)
                    {
                        BLL.ShowMessage(this, "EMP_ID is missing");
                    }
                }
            }







            //Physical Details
            _obj_SMHR_EMPPHYSICALDETAILS = new SMHR_EMP_PHYSICALDETAILS();

            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_EMPID = Convert.ToInt32(HF_EMPID.Value); //Convert.ToInt32(_lbl_Emp_ID);

            DataTable dt_getPhysicalDetails = BLL.get_PhysicalDetails(_obj_SMHR_EMPPHYSICALDETAILS);
            if (dt_getPhysicalDetails.Rows.Count == 0)
            {

                _obj_SMHR_EMPPHYSICALDETAILS.OPERATION = operation.Insert_New;

                _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_EMPID = Convert.ToInt32(HF_EMPID.Value); //Convert.ToInt32(_lbl_Emp_ID);
                if (rtxt_Height.Text == "")
                {
                    _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_HEIGHT = 0.00;
                }
                else
                {
                    _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_HEIGHT = Convert.ToDouble(rtxt_Height.Text.Replace("'", "''"));
                }

                if (rtxt_Weight.Text == "")
                {
                    _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_WEIGHT = 0.00;
                }
                else
                {
                    _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_WEIGHT = Convert.ToDouble(rtxt_Weight.Text.Replace("'", "''"));
                }

                _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_COLOR = Convert.ToString(rtxt_SkinColor.Text.Replace("'", "''"));
                _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_IDENTIFICATION = Convert.ToString(rtxt_IdentificationMarks.Text.Replace("'", "''"));
                //_obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_BLOODGROUP = Convert.ToString(rtxt_BGroup.Text.Replace("'", "''"));
                _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_EYEPOWER = Convert.ToString(rtxt_EyePower.Text.Replace("'", "''"));
                if (chk_Handicapped.Checked == true)
                {
                    _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_HANDICAP = true;
                }
                else
                {
                    _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_HANDICAP = false;
                }
                _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_HANDICAP_YES = Convert.ToString(rtxt_Handicapped.Text.Replace("'", "''"));
                _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_PHYSICALTREATMENT = Convert.ToString(rtxt_TreatmentName_Physical.Text.Replace("'", "''"));
                _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_PHYSICALHOSPITAL = Convert.ToString(rtxt_HospitalName_Physical.Text.Replace("'", "''"));
                _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_PHYSICALDURATION = Convert.ToString(rtxt_TreatmentDuration_Physical.Text.Replace("'", "''"));
                _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_PHYSICALSTATUS = Convert.ToString(rtxt_IllnessStatus_Physical.Text.Replace("'", "''"));
                _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_MENTALTREATMENT = Convert.ToString(rtxt_TreatmentName_Mental.Text.Replace("'", "''"));
                _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_MENTALHOSPITAL = Convert.ToString(rtxt_HospitalName_Mental.Text.Replace("'", "''"));
                _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_MENTALDURATION = Convert.ToString(rtxt_TreatmentDuration_Mental.Text.Replace("'", "''"));
                _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_MENTALSTATUS = Convert.ToString(rtxt_IllnessStatus_Mental.Text.Replace("'", "''"));
                _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_CREATEDDATE = DateTime.Now;

                if (FPhysicalDoc.HasFile)
                {
                    string imagename = txt_Name.Text + "_" + Guid.NewGuid().ToString() + "_PHY" + FPhysicalDoc.FileName;
                    string strPath = "~/EmpUploads/" + imagename;
                    FPhysicalDoc.PostedFile.SaveAs(Server.MapPath("~/EmpUploads/") + imagename);
                    _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_PHYSICALDETAILSDOC = strPath;
                }

                BLL.set_PhysicalDetails(_obj_SMHR_EMPPHYSICALDETAILS);
                BLL.ShowMessage(this, "Records Inserted Successfully");
            }
            else
            {
                BLL.ShowMessage(this, "Data of Physical Details for this Employee ID Already Exists");
            }
            //status=BLL.set_PhysicalDetails(_obj_SMHR_EMPPHYSICALDETAILS);
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void btn_Physical_Update_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_smhr_employee = new SMHR_EMPLOYEE();
            _obj_smhr_employee.EMP_ID = Convert.ToInt32(HF_EMPID.Value); //Convert.ToInt32(_lbl_Emp_ID);
            _obj_smhr_employee.OPERATION = operation.Insert1;
            _obj_smhr_employee.EMP_MOBILENO = Convert.ToString(rmtxt_MobileNo.Text.Replace("'", "''"));
            _obj_smhr_employee.EMP_LANDLINENO = Convert.ToString(rmtxt_LandlineNo.Text.Replace("'", "''"));
            _obj_smhr_employee.EMP_EMAILID = Convert.ToString(rtxt_EmailID.Text.Replace("'", "''"));
            _obj_smhr_employee.EMP_SKYPEID = Convert.ToString(txtSkypeId.Text.Replace("'", "''"));
            _obj_smhr_employee.EMP_EXTENSION = Convert.ToString(rntbExtensionNo.Text.Replace("'", "''"));
            BLL.set_EMP_NEWCONTACTS(_obj_smhr_employee);

            _obj_SMHR_EMPPHYSICALDETAILS = new SMHR_EMP_PHYSICALDETAILS();

            _obj_SMHR_EMPPHYSICALDETAILS.OPERATION = operation.Update_New;

            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_EMPID = Convert.ToInt32(HF_EMPID.Value); //Convert.ToInt32(_lbl_Emp_ID);
            if (rtxt_Height.Text == "")
            {
                _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_HEIGHT = 0.00;
            }
            else
            {
                _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_HEIGHT = Convert.ToDouble(rtxt_Height.Text.Replace("'", "''"));
            }

            if (rtxt_Weight.Text == "")
            {
                _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_WEIGHT = 0.00;
            }
            else
            {
                _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_WEIGHT = Convert.ToDouble(rtxt_Weight.Text.Replace("'", "''"));
            }
            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_COLOR = Convert.ToString(rtxt_SkinColor.Text);
            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_IDENTIFICATION = Convert.ToString(rtxt_IdentificationMarks.Text);
            //_obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_BLOODGROUP = Convert.ToString(rtxt_BGroup.Text);
            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_EYEPOWER = Convert.ToString(rtxt_EyePower.Text);
            if (chk_Handicapped.Checked == true)
            {
                _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_HANDICAP = true;

            }
            else
            {
                _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_HANDICAP = false;
            }
            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_HANDICAP_YES = Convert.ToString(rtxt_Handicapped.Text);
            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_PHYSICALTREATMENT = Convert.ToString(rtxt_TreatmentName_Physical.Text);
            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_PHYSICALHOSPITAL = Convert.ToString(rtxt_HospitalName_Physical.Text);
            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_PHYSICALDURATION = Convert.ToString(rtxt_TreatmentDuration_Physical.Text);
            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_PHYSICALSTATUS = Convert.ToString(rtxt_IllnessStatus_Physical.Text);
            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_MENTALTREATMENT = Convert.ToString(rtxt_TreatmentName_Mental.Text);
            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_MENTALHOSPITAL = Convert.ToString(rtxt_HospitalName_Mental.Text);
            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_MENTALDURATION = Convert.ToString(rtxt_TreatmentDuration_Mental.Text);
            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_MENTALSTATUS = Convert.ToString(rtxt_IllnessStatus_Mental.Text);
            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_MODIFIEDBBY = Convert.ToInt32(Session["USER_ID"]);//1;
            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_MODIFIEDDATE = DateTime.Now;
            if (FPhysicalDoc.HasFile)
            {
                string imagename = txt_Name.Text + "_" + Guid.NewGuid().ToString() + "_PHY_" + FPhysicalDoc.FileName;
                string strPath = "~/EmpUploads/" + imagename;
                FPhysicalDoc.PostedFile.SaveAs(Server.MapPath("~/EmpUploads/") + imagename);
                _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_PHYSICALDETAILSDOC = strPath;
            }
            BLL.set_PhysicalDetails(_obj_SMHR_EMPPHYSICALDETAILS);
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Physical_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearPhysicalDetails();
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    //#region Saving Uploaded Image
    //protected void Save_Picture()
    //{
    //    if (FUpload.HasFile)
    //    {
    //        string s = System.IO.Path.GetExtension(FUpload.PostedFile.FileName);
    //        if ((s == ".jpg") || (s == ".gif") || (s == ".jpeg"))
    //            RBI_Employee_Image.ImageUrl = FUpload.FileName;
    //        else
    //            BLL.ShowMessage(this, "Upload Only Image Files");
    //    }
    //}
    //#endregion

    #region Upload Image
    /// <summary>
    /// this method will show the selected image
    /// </summary>    
    protected void btn_Upload_Click(object sender, EventArgs e)
    {
        try
        {
            //if (FUpload.HasFile)
            //{
            //    string filename = FUpload.FileName;
            //     //checking for the existance of organisation id
            //    if (System.IO.Directory.Exists(Server.MapPath("~/EmpUploads/Photo Upload/" + Session["ORG_ID"] + "/")) == false)
            //    {
            //        System.IO.Directory.CreateDirectory(Server.MapPath("~/EmpUploads/Photo Upload/" + Session["ORG_ID"] + "/"));
            //    }
            //    string filenamewithempid = txt_AppLastName.Text + "-" + Convert.ToString(_lbl_Emp_ID);
            //    ViewState["FILE_NAME"] = filenamewithempid;
            //     //checking whether particular employee is already uploaded photo or not
            //    if (System.IO.Directory.Exists(Server.MapPath(filenamewithempid)) == false)
            //    {
            //        FUpload.SaveAs(Server.MapPath("~/EmpUploads/Photo Upload/" + Session["ORG_ID"] + "/" + filenamewithempid));
            //        RBI_Employee_Image.ImageUrl = "~/EmpUploads/Photo Upload/" + Session["ORG_ID"] + "/" + filenamewithempid;
            //        RBI_Employee_Image.Visible = true;
            //    }

            //    //if he uploaded his photo already then it will come to else
            //    else
            //    {
            //        FUpload.SaveAs(Server.MapPath("~/EmpUploads/Photo Upload/" + Session["ORG_ID"] + "/" + filenamewithempid));
            //        RBI_Employee_Image.ImageUrl = "~/EmpUploads/Photo Upload/" + Session["ORG_ID"] + "/" + filenamewithempid;
            //        RBI_Employee_Image.Visible = true;
            //    }
            //}
            //else
            //{
            //    BLL.ShowMessage(this, "Select a Image Files to Upload");
            //    return;
            //}

            if (FUpload.HasFile)
            {
                // Session["a"] = FUpload.FileName;
                strPath = "~/EmpUploads/" + txt_AppLastName.Text + "_" + FUpload.FileName;
                FUpload.PostedFile.SaveAs(Server.MapPath("~/EmpUploads/") + txt_AppLastName.Text + "_" + FUpload.FileName);
                RBI_Employee_Image.ImageUrl = strPath;
                RBI_Employee_Image.Visible = true;
                lnkPicDelete.Visible = true;
            }

            else
            {
                BLL.ShowMessage(this, "Please Select an Image");
                return;
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


    }
    #endregion

    //protected void btn_Update_OnClientClick(object sender, EventArgs e)
    //{
    //    if (!ClientScript.IsStartupScriptRegistered("confirm"))
    //    {
    //        Page.ClientScript.RegisterStartupScript(this.GetType(),
    //            "confirm", "Rehire();", true);
    //    }
    //}

    #region ANNUAL GROSS AND ANNUAL BASIC
    protected void txt_AnnualGrossSalary_TextChanged(object sender, EventArgs e)
    {
        try
        {
            ddl_EmpStatus_SelectedIndexChanged(null, null);
            Calculate_AnnualBasic();
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void Calculate_AnnualBasic()
    {
        try
        {
            if (txt_AnnualGrossSalary.Text != string.Empty)
            {
                if (Convert.ToDouble(txt_AnnualGrossSalary.Text) >= 0)
                {
                    if (ddl_SalaryStructure.SelectedIndex > 0)
                    {
                        _obj_smhr_salaryStruct = new SMHR_SALARYSTRUCT();
                        _obj_smhr_salaryStruct.OPERATION = operation.Select;
                        _obj_smhr_salaryStruct.SALARYSTRUCT_ID = Convert.ToInt32(ddl_SalaryStructure.SelectedItem.Value);
                        _obj_smhr_salaryStruct.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dt_PeriodType = BLL.get_SalaryHeaderDetails(_obj_smhr_salaryStruct);
                        _obj_smhr_salaryStruct.SALARYSTRUCT_TYPE = Convert.ToInt32(dt_PeriodType.Rows[0]["SALARYSTRUCT_TYPE"]);
                        _obj_smhr_salaryStruct.OPERATION = operation.Validate;
                        DataTable dt_PeriodTypeName = BLL.get_SalaryHeaderDetails(_obj_smhr_salaryStruct);
                        if (contracts)
                        {
                            txt_AnnualBasicSalary.Text = txt_AnnualGrossSalary.Text;
                            if (dt_PeriodTypeName.Rows.Count != 0)
                            {
                                //Not Sure
                                //if (Convert.ToString(dt_PeriodTypeName.Rows[0]["PERIODTYPE_NAME"]).ToUpper() == "MONTHLY")
                                //{
                                //    txt_GrossSalary.Text = Convert.ToString(Convert.ToDouble(txt_AnnualGrossSalary.Text) / 12);
                                //    txt_BasicPay.Text = txt_GrossSalary.Text;
                                //}
                                //else if (Convert.ToString(dt_PeriodTypeName.Rows[0]["PERIODTYPE_NAME"]).ToUpper() == "FORTNIGHT")
                                //{
                                //    txt_GrossSalary.Text = Convert.ToString(Convert.ToDouble(txt_AnnualGrossSalary.Text) / 26);
                                //    txt_BasicPay.Text = txt_GrossSalary.Text;
                                //}
                            }
                            if (ddl_Jobs.SelectedValue != "Select")
                            {
                                if (!((Convert.ToDouble(txt_AnnualGrossSalary.Text) >= minsal) && (Convert.ToDouble(txt_AnnualGrossSalary.Text) <= maxsal)))
                                {
                                    BLL.ShowMessage(this, "Gross Must be in the range of Selected Job Min and Max Salary:" + minsal + "-" + maxsal);
                                    txt_AnnualGrossSalary.Text = "";
                                    txt_AnnualBasicSalary.Text = "";
                                    return;
                                }
                            }
                        }
                        else
                        {
                            //code for getting Basic percentage of Gross For the businessunit selected
                            _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
                            _obj_smhr_businessunit.OPERATION = operation.Select;
                            _obj_smhr_businessunit.BUSINESSUNIT_ID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
                            _obj_smhr_businessunit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dt_BusinessUnit = BLL.get_BusinessUnit(_obj_smhr_businessunit);
                            if ((dt_BusinessUnit.Rows.Count > 0) && (ddl_BusinessUnit.SelectedValue != string.Empty))
                            {
                                _obj_smhr_businessunit.OPERATION = operation.Get_BULocalization;
                                DataTable dtBuLocal = BLL.get_BusinessUnit(_obj_smhr_businessunit);
                                if (dtBuLocal.Rows.Count > 0)
                                {
                                    float strSuperAnnuation = Convert.ToSingle(0.00);
                                    //if (Convert.ToString(dtBuLocal.Rows[0]["HR_MASTER_CODE"]).ToUpper() == "AUSTRALIA")
                                    //{
                                    //    float emp_GrossSal = Convert.ToSingle(txt_AnnualGrossSalary.Text.Replace("'", "''"));
                                    //    strSuperAnnuation = Convert.ToSingle(emp_GrossSal * 0.09);
                                    //    txt_AnnualBasicSalary.Text = Convert.ToString(emp_GrossSal - strSuperAnnuation);
                                    //    if (dt_PeriodTypeName.Rows.Count != 0)
                                    //    {
                                    //        if (Convert.ToString(dt_PeriodTypeName.Rows[0]["PERIODTYPE_NAME"]).ToUpper() == "MONTHLY")
                                    //        {
                                    //            txt_GrossSalary.Text = Convert.ToString(Convert.ToDouble(txt_AnnualGrossSalary.Text) / 12);
                                    //            txt_BasicPay.Text = Convert.ToString(Convert.ToDouble(txt_AnnualBasicSalary.Text) / 12);
                                    //        }
                                    //        else if (Convert.ToString(dt_PeriodTypeName.Rows[0]["PERIODTYPE_NAME"]).ToUpper() == "FORTNIGHT")
                                    //        {
                                    //            txt_GrossSalary.Text = Convert.ToString(Convert.ToDouble(txt_AnnualGrossSalary.Text) / 26);
                                    //            txt_BasicPay.Text = Convert.ToString(Convert.ToDouble(txt_AnnualBasicSalary.Text) / 26);
                                    //        }
                                    //    }
                                    //    txt_AnnualGrossSalary.Focus();
                                    //    if (lbl_jobName.Text != "")
                                    //    {
                                    //        if (!((Convert.ToDouble(txt_AnnualGrossSalary.Text) >= minsal) && (Convert.ToDouble(txt_AnnualGrossSalary.Text) <= maxsal)))
                                    //        {
                                    //            BLL.ShowMessage(this, "Gross Must be in the range of Selected Job Min and Max Salary:" + minsal + "-" + maxsal);
                                    //            txt_AnnualGrossSalary.Text = "";
                                    //            txt_AnnualBasicSalary.Text = "";
                                    //            txt_GrossSalary.Text = "";
                                    //            txt_BasicPay.Text = "";
                                    //            return;
                                    //        }
                                    //    }
                                    //}
                                    //else
                                    //{
                                    if (dt_BusinessUnit.Rows[0]["BUSINESSUNIT_BASICPERCENT"] != System.DBNull.Value)
                                    {
                                        float IBasicPercent = Convert.ToSingle(dt_BusinessUnit.Rows[0]["BUSINESSUNIT_BASICPERCENT"]);
                                        float emp_GrossSal = Convert.ToSingle(txt_AnnualGrossSalary.Text.Replace("'", "''"));
                                        float emp_BasicSal = (IBasicPercent * emp_GrossSal) / 100;
                                        txt_AnnualBasicSalary.Text = Convert.ToString(emp_BasicSal);
                                        if (dt_PeriodTypeName.Rows.Count != 0)
                                        {
                                            //Not Sure
                                            //if (Convert.ToString(dt_PeriodTypeName.Rows[0]["PERIODTYPE_NAME"]).ToUpper() == "MONTHLY")
                                            //{
                                            //    txt_GrossSalary.Text = Convert.ToString(Convert.ToDouble(txt_AnnualGrossSalary.Text) / 12);
                                            //    txt_BasicPay.Text = Convert.ToString(Convert.ToDouble(txt_AnnualBasicSalary.Text) / 12);
                                            //}
                                            //else if (Convert.ToString(dt_PeriodTypeName.Rows[0]["PERIODTYPE_NAME"]).ToUpper() == "FORTNIGHT")
                                            //{
                                            //    txt_GrossSalary.Text = Convert.ToString(Convert.ToDouble(txt_AnnualGrossSalary.Text) / 26);
                                            //    txt_BasicPay.Text = Convert.ToString(Convert.ToDouble(txt_AnnualBasicSalary.Text) / 26);
                                            //}
                                        }
                                        txt_AnnualGrossSalary.Focus();
                                        //if (lbl_jobName.Text != "")
                                        if (ddl_Jobs.SelectedValue != "Select")
                                        {
                                            if (!((Convert.ToDouble(txt_AnnualGrossSalary.Text) >= minsal) && (Convert.ToDouble(txt_AnnualGrossSalary.Text) <= maxsal)))
                                            {
                                                BLL.ShowMessage(this, "Gross Must be in the range of Selected Job Min and Max Salary:" + minsal + "-" + maxsal);
                                                txt_AnnualGrossSalary.Text = "";
                                                txt_AnnualBasicSalary.Text = "";
                                                //txt_GrossSalary.Text = "";
                                                txt_BasicPay.Text = "";
                                                return;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        BLL.ShowMessage(this, "Basic Is Not Defined For The Businessunit:" + ddl_BusinessUnit.SelectedItem.Text);
                                        txt_AnnualGrossSalary.Text = "";
                                        return;
                                    }
                                    //}
                                }
                            }
                            else
                            {
                                BLL.ShowMessage(this, "Select Proper Businessunit");
                                txt_AnnualGrossSalary.Text = "";
                            }

                        }
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Select Salary Structure");
                        txt_AnnualGrossSalary.Text = "";
                    }
                }
                else
                {
                    BLL.ShowMessage(this, "Gross Must be Greater Than Zero!");
                    txt_AnnualBasicSalary.Text = "";
                    txt_AnnualGrossSalary.Focus();
                }
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    public void LoadAnnual()
    {
        try
        {
            SMHR_ORGANISATION _obj_SMHR_ORGANISATION = new SMHR_ORGANISATION();
            _obj_SMHR_ORGANISATION.MODE = 2;
            _obj_SMHR_ORGANISATION.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Organisation = BLL.get_Organisation(_obj_SMHR_ORGANISATION);
            if (dt_Organisation.Rows.Count != 0)
            {
                if (Convert.ToString(dt_Organisation.Rows[0]["ORGANISATION_ANNUALPROCESS"]) != "")
                {
                    if (Convert.ToString(dt_Organisation.Rows[0]["ORGANISATION_ANNUALPROCESS"]).ToUpper() == "TRUE")
                    {
                        tr_AnnualSalary.Visible = true;
                        //txt_GrossSalary.Enabled = false;
                        txt_BasicPay.Enabled = false;
                        //td_MonthlySalary.Visible = false;
                        //td_Empty.Visible = true;
                    }
                    else
                    {

                        tr_AnnualSalary.Visible = false;
                        //txt_GrossSalary.Enabled = true;
                        txt_BasicPay.Enabled = false;
                        //td_MonthlySalary.Visible = true;
                        //td_Empty.Visible = false;
                        //if (Convert.ToString(Request.QueryString["EID"]) == null)
                        //td_Empty.Visible = true;
                        //else
                        //td_Empty.Visible = false;
                    }
                }
                else
                {
                    tr_AnnualSalary.Visible = false;
                    //txt_GrossSalary.Enabled = true;
                    txt_BasicPay.Enabled = true;
                    //td_MonthlySalary.Visible = true;
                    //td_Empty.Visible = false;
                }
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rtxt_pwd_TextChanged(object sender, EventArgs e)
    {
        try
        {
            strPass = rtxt_pwd.Text;
            rtxt_pwd.Attributes.Add("value", strPass);
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void rtxt_passcode_TextChanged(object sender, EventArgs e)
    {
        try
        {
            strPass1 = rtxt_passcode.Text;
            rtxt_passcode.Attributes.Add("value", strPass1);
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //protected void checkLocal()
    //{

    //    _obj_smhr_employee = new SMHR_EMPLOYEE();
    //    _obj_smhr_employee.OPERATION = operation.SelectLocal;
    //    _obj_smhr_employee.EMP_ID = Convert.ToInt32(HF_EMPID.Value);
    //    DataTable dtLocal = BLL.get_Employee(_obj_smhr_employee);
    //    if (dtLocal.Rows.Count > 0)
    //    {
    //        if (Convert.ToString(dtLocal.Rows[0]["HR_MASTER_CODE"]).ToUpper() == "KENYA")
    //        {
    //            if (Convert.ToString(Session["SELFSERVICE"]).ToUpper() != "")
    //            {
    //                if (Convert.ToString(Session["SELFSERVICE"]).ToUpper() == "TRUE")
    //                {
    //                    //btn_Update.Enabled = false;
    //                    btn_Qual_Add.Enabled = false;
    //                    btn_Skill_Add.Enabled = false;
    //                    btn_Exp_Add.Enabled = false;
    //                    btn_Con_Add.Enabled = false;
    //                    btn_Lang_Add.Enabled = false;
    //                    btn_Ref_Add.Enabled = false;
    //                    btn_Fam_Add.Enabled = false;
    //                    btn_OT_Add.Enabled = false;
    //                    btn_swp_Add.Enabled = false;
    //                }
    //            }
    //            else
    //            {
    //                //btn_Update.Enabled = false;

    //            }
    //        }
    //        else
    //        {

    //        }
    //    }

    //}
    protected void lnkPicDelete_Click(object sender, EventArgs e)
    {
        try
        {
            bool status = false;
            _obj_smhr_employee = new SMHR_EMPLOYEE();
            _obj_smhr_employee.OPERATION = operation.DelPic;
            _obj_smhr_employee.EMP_ID = Convert.ToInt32(HF_EMPID.Value);
            _obj_smhr_employee.EMP_BUSINESSUNIT_ID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
            _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            status = BLL.set_Employee(_obj_smhr_employee);
            if (status == true)
            {
                RBI_Employee_Image.ImageUrl = "";
                lnkPicDelete.Visible = false;
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    public static string CreateRandomPassword()
    {
        char[] chars = new char[8];
        try
        {
            string _allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            Random randNum = new Random();
            //char[] chars = new char[8];
            int allowedCharCount = _allowedChars.Length;

            for (int i = 0; i < 8; i++)
            {
                chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
            }

            return new string(chars);
        }
        catch (System.Exception ex)
        {
            //throw ex;
            SMHR.BLL.Error_Log(HttpContext.Current.Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            HttpContext.Current.Response.Redirect("~/Frm_ErrorPage.aspx");
            return new string(chars);
        }
    }

    public void sendMail()
    {
        try
        {
            string strPass = Convert.ToString(ViewState["passcodeDE"]);
            SMHR_LOGININFO _obj_Login = new SMHR_LOGININFO();
            _obj_Login.OPERATION = operation.Check1;
            _obj_Login.LOGIN_USERNAME = Convert.ToString(ViewState["email"]);
            _obj_Login.LOGIN_PASS_CODE = Convert.ToString(ViewState["passcode"]);
            _obj_Login.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_Login_Validate(_obj_Login);
            if (dt.Rows.Count != 0)
            {
                string toAddress, subject, body;
                toAddress = (Convert.ToString(dt.Rows[0]["LOGIN_EMAILID"]));

                subject = "Smart HR Password";
                body = "<html>" +
                                "<body> " +
                                "<p>Dear " + Convert.ToString(ViewState["emp_name"]) + ", </p> " +
                                "<p>Welcome to Smart HR Online !</p>" +
                                "<p>Your credentials for accessing Smart HR for " + Convert.ToString(dt.Rows[0]["ORGANISATION_NAME"]) + " are <br>" +
                                "</p> " +
                                "<p>User name: " + Convert.ToString(ViewState["email"]) + " </p> " +
                                "<p>Password:  " + Convert.ToString(ViewState["randompassword"]) + " </p> " +
                                "<p>Security Code: " + Convert.ToString(ViewState["passcodeDE"]) + "</p>" +
                                "This above password is temporary. Please change it later for security reasons.</p>" +
                                "<p>Best Regards,<br/><br/>" +
                                "Team Smart HR</p>" +
                                "</body>" +
                                " </html>";
                BLL.SendMail(toAddress, null, subject, body);
                BLL.ShowMessage(this, "A Mail has been sent to the user");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Test", "<script type='text/javascript'>Close()</" + "script>", false);
            }
            else
            {
                BLL.ShowMessage(this, "Security Code is Invalid");
                return;
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void ddl_Department_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (ddl_Department.SelectedIndex > 0)
            {
                LoadDivision();
                /* _obj_Department = new SMHR_DEPARTMENT();   //GET DEPTCODE BY DEPT
                 _obj_Department.MODE = 21;
                 _obj_Department.DIRECTORATE_ID = rcmb_Directorate.SelectedValue != string.Empty ? Convert.ToInt32(rcmb_Directorate.SelectedValue) : 0;
                 _obj_Department.BUID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
                 _obj_Department.DEPARTMENT_ID = Convert.ToInt32(ddl_Department.SelectedValue);
                 DataTable dt = BLL.get_Department(_obj_Department);
                 rtxt_DCode.Text = Convert.ToString(dt.Rows[0]["DEPARTMENT_CODE"]);*/
            }
            else
            {
                rcmb_Devision.ClearSelection();
                rcmb_Devision.Items.Clear();
                rcmb_Devision.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            }
            rcmb_SubDivision.ClearSelection();
            rcmb_SubDivision.Items.Clear();
            rcmb_SubDivision.Items.Insert(0, new RadComboBoxItem("Select", "0"));
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_Devision_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Devision.SelectedIndex > 0)
            {
                rcmb_SubDivision.Items.Clear();
                _obj_Smhr_SubDivision = new SMHR_SUBDIVISION();
                _obj_Smhr_SubDivision.SUBDIVISION_DIVISION_ID = Convert.ToInt32(rcmb_Devision.SelectedItem.Value);
                _obj_Smhr_SubDivision.SUBDIVISION_BU_ID = Convert.ToInt32(ddl_BusinessUnit.SelectedItem.Value);
                _obj_Smhr_SubDivision.MODE = 6;
                DataTable dt = BLL.get_SubDivision(_obj_Smhr_SubDivision);
                rcmb_SubDivision.DataSource = dt;
                rcmb_SubDivision.DataTextField = "SUBDIVISION_NAME";
                rcmb_SubDivision.DataValueField = "SUBDIVISION_ID";
                rcmb_SubDivision.DataBind();
                rcmb_SubDivision.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
            else
            {
                rcmb_SubDivision.ClearSelection();
                rcmb_SubDivision.Items.Clear();
                rcmb_SubDivision.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            }
            rcmb_Devision.Focus();
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //protected void btn_DependentImageUpload_Click(object sender, EventArgs e)
    //{
    //    if (FUploadDependent.HasFile)
    //    {
    //        // Session["a"] = FUpload.FileName;
    //        strImagePath = "~/EmpUploads/" + txt_Name.Text + "_" + DateTime.Now.ToShortDateString() + "_" + FUploadDependent.FileName;
    //        FUploadDependent.PostedFile.SaveAs(Server.MapPath("~/EmpUploads/") + txt_Name.Text + "_" + DateTime.Now.ToShortDateString() + "_" + FUploadDependent.FileName);
    //        img_DependentImage.ImageUrl = strImagePath;
    //        img_DependentImage.Visible = true;
    //    }

    //    else
    //    {
    //        BLL.ShowMessage(this, "Please UpLoad store Image");
    //        return;
    //    }
    //}

    protected void ddlRelation_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            //trDOBorID.Visible = true;
            lbl_FDOB.Visible = false;
            txt_FDOB.Visible = false;
            chk_EmergencyCont.Visible = false;
            if (ddlRelation.SelectedIndex > 0)
            {
                if (string.Compare(ddlRelation.SelectedItem.Text.ToLower(), "spouse", true) == 0)
                {
                    lbl_FDOB.Visible = false;
                    txt_FDOB.Visible = false;
                    chk_EmergencyCont.Visible = true;
                }
                else
                {
                    lbl_FDOB.Visible = true;
                    txt_FDOB.Visible = true;
                    chk_EmergencyCont.Visible = false;
                }
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private DataTable LoadSalarySlabs()
    {
        DataSet ds = new DataSet();
        try
        {
            SMHR_EMPLOYEEGRADE _obj_Smhr_EmployeeGrade = new SMHR_EMPLOYEEGRADE();
            _obj_Smhr_EmployeeGrade.EMPLOYEEGRADE_ID = ddl_Grade.SelectedValue != string.Empty ? Convert.ToInt32(ddl_Grade.SelectedIndex) : 0;
            _obj_Smhr_EmployeeGrade.OPERATION = operation.EmployeeSlabs;
            _obj_Smhr_EmployeeGrade.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_EmployeeGrade.PERIOD_ID = Convert.ToInt32(rcmb_Period.SelectedIndex);
            ds = BLL.get_EmployeeGrade(_obj_Smhr_EmployeeGrade);


        }

        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

        }
        return ds.Tables[0];

    }

    private DataTable LoadSalarySlabs1()
    {
        DataTable dt = new DataTable();
        try
        {
            SMHR_EMPLOYEEGRADE_SLAB _obj_Smhr_EmployeeGrade = new SMHR_EMPLOYEEGRADE_SLAB();
            _obj_Smhr_EmployeeGrade.EMPLOYEEGRADE_SLAB_EMPLOYEEGRADE_ID = ddl_Grade.SelectedValue != string.Empty ? Convert.ToInt32(ddl_Grade.SelectedValue) : 0;
            _obj_Smhr_EmployeeGrade.OPERATION = operation.EmployeeSlabs;
            _obj_Smhr_EmployeeGrade.EMPLOYEEGRADE_SLAB_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_EmployeeGrade.EMPLOYEEGRADE_SLAB_PERIOD_ID = Convert.ToInt32(rcmb_Period.SelectedValue);

            dt = BLL.get_EmployeeGrades(_obj_Smhr_EmployeeGrade);


        }


        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return dt;
    }

    protected void ddl_Slabs_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (ddl_Slabs.SelectedIndex > 0)
            {
                //txt_GrossSalary.Text = ddl_Slabs.Text;
                string[] str = Convert.ToString(ddl_Slabs.Text).Replace(" )", "").Replace(")", "").Split('(');
                //txt_BasicPay.Value = Convert.ToDouble(Convert.ToString(str[1].Trim())) / 12;
                txt_BasicPay.Value = Math.Round((Convert.ToDouble(str[1].Trim()) / 12), 2);
                //ddl_EmpStatus_SelectedIndexChanged(null, null);
                //Calculate_Basic();
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void ddl_Grade_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            SMHR_EMPLOYEEGRADE_SLAB _obj_SMHR_EMPLOYEEGRADE_SLAB = new SMHR_EMPLOYEEGRADE_SLAB();
            ddl_Slabs.Items.Clear();

            if (ddl_Grade.SelectedIndex > 0)
            {
                _obj_SMHR_EMPLOYEEGRADE_SLAB.OPERATION = operation.Get;
                _obj_SMHR_EMPLOYEEGRADE_SLAB.EMPLOYEEGRADE_SLAB_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_SMHR_EMPLOYEEGRADE_SLAB.EMPLOYEEGRADE_SLAB_EMPLOYEEGRADE_ID = Convert.ToInt32(ddl_Grade.SelectedValue);
                if (rcmb_Period.SelectedValue == null || rcmb_Period.SelectedValue == "")
                {
                    BLL.ShowMessage(this, "Please Select Financial Period");
                    return;
                }
                else
                {
                    _obj_SMHR_EMPLOYEEGRADE_SLAB.EMPLOYEEGRADE_SLAB_PERIOD_ID = Convert.ToInt32(rcmb_Period.SelectedValue);
                }

                DataTable dtSlabs = LoadSalarySlabs1();

                if (dtSlabs.Rows.Count > 0)
                {
                    ddl_Slabs.DataSource = dtSlabs;
                    ddl_Slabs.DataTextField = "EMPLOYEEGRADE_SLAB_AMOUNT";
                    ddl_Slabs.DataValueField = "EMPLOYEEGRADE_SLAB_ID";
                    ddl_Slabs.DataBind();
                }
                ddl_Slabs.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            }
            else
            {
                ddl_Slabs.SelectedIndex = 0;
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_Period_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {

            if (rcmb_Period.SelectedIndex > 0)
            {
                ddl_Grade.Items.Clear();
                ddl_Slabs.Items.Clear();
                SMHR_EMPLOYEEGRADE_SLAB _obj_Smhr_EmployeeGrade = new SMHR_EMPLOYEEGRADE_SLAB();
                _obj_Smhr_EmployeeGrade.EMPLOYEEGRADE_SLAB_EMPLOYEEGRADE_ID = Convert.ToInt32(ddl_Grade.SelectedItem);
                _obj_Smhr_EmployeeGrade.OPERATION = operation.Employeegrades;
                _obj_Smhr_EmployeeGrade.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_EmployeeGrade.EMPLOYEEGRADE_SLAB_PERIOD_ID = Convert.ToInt32(rcmb_Period.SelectedValue);

                DataTable dt = new DataTable();
                dt = BLL.get_EmployeeGrades(_obj_Smhr_EmployeeGrade);

                if (dt.Rows.Count > 0)
                {
                    ddl_Grade.DataSource = dt;
                    ddl_Grade.DataTextField = "EMPLOYEEGRADE_SLAB_EMPLOYEEGRADE_CODE";
                    ddl_Grade.DataValueField = "EMPLOYEEGRADE_SLAB_EMPLOYEEGRADE_ID";
                    ddl_Grade.DataBind();
                }
                ddl_Grade.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                ddl_Grade.Enabled = true;
                ddl_Slabs.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                ddl_Slabs.Enabled = true;
            }

        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //private DataTable Loadgrade()
    //{
    //    SMHR_EMPLOYEEGRADE_SLAB _obj_Smhr_EmployeeGrade = new SMHR_EMPLOYEEGRADE_SLAB();
    //    _obj_Smhr_EmployeeGrade.EMPLOYEEGRADE_SLAB_EMPLOYEEGRADE_ID = Convert.ToInt32(ddl__Grade.SelectedValue);
    //    _obj_Smhr_EmployeeGrade.OPERATION = operation.Employeegrades;
    //    _obj_Smhr_EmployeeGrade.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //    DataSet ds = BLL.get_EmployeeGrades(_obj_Smhr_EmployeeGrade);

    //    return ds.Tables[0];
    //}

    protected void chkAlwnce_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            switch (((CheckBox)sender).ID.ToUpper())
            {
                case "CHKDEPTALWNCE":
                    if (ddlRelation.SelectedIndex > 0 && rcmb_Period.SelectedIndex > 0 && ddl_Grade.SelectedIndex > 0)
                    {
                        if (((ddlRelation.SelectedItem.Text.ToUpper() == "SON") || (ddlRelation.SelectedItem.Text.ToUpper() == "WIFE") ||
                            (ddlRelation.SelectedItem.Text.ToUpper() == "DAUGHTER")) && (txt_FDOB.SelectedDate != null))
                        {
                            if ((Convert.ToDateTime(txt_FDOB.SelectedDate).AddYears(21).AddDays(-1)) <= DateTime.Now)
                            {

                                BLL.ShowMessage(this, "The selected dependent is more than 21 years of age.!");
                                chkDeptAlwnce.Checked = false;
                                txt_FDOB.Focus();
                                return;
                            }
                            if ((Convert.ToDateTime(txt_FDOB.SelectedDate).AddYears(18).AddDays(-1)) <= DateTime.Now)
                            {
                                BLL.ShowMessage(this, "Dependent already completed 18 years");
                                txt_FDOB.Focus();
                                return;
                            }
                        }
                        else
                        {
                            if (txt_FDOB.SelectedDate == null)
                            {
                                BLL.ShowMessage(this, "Please enter relation DOB before checking the Dependent checkbox");
                                chkDeptAlwnce.Checked = false;
                                txt_FDOB.Focus();
                                return;
                            }
                            else
                            {
                                BLL.ShowMessage(this, "You are not supposed to select Dependent for selected relation ship");
                                chkDeptAlwnce.Checked = false;
                                return;
                            }
                        }
                    }
                    else
                    {
                        if (ddlRelation.SelectedIndex == 0)
                        {
                            BLL.ShowMessage(this, "Please select employee relationship before checking the Dependent checkbox");
                            chkDeptAlwnce.Checked = false;
                            ddlRelation.Focus();
                            return;
                        }
                        else if (rcmb_Period.SelectedIndex == 0)
                        {
                            BLL.ShowMessage(this, "Please select Financial period before checking the Dependent checkbox");
                            chkDeptAlwnce.Checked = false;
                            return;
                        }
                        else
                        {
                            BLL.ShowMessage(this, "Please select Employee grade before checking the Dependent checkbox");
                            chkDeptAlwnce.Checked = false;
                            return;
                        }
                    }
                    break;

                case "CHKEDUALWNCE":
                    if (ddlRelation.SelectedIndex > 0 && rcmb_Period.SelectedIndex > 0 && ddl_Grade.SelectedIndex > 0)
                    {
                        if (((ddlRelation.SelectedItem.Text.ToUpper() == "SON") || (ddlRelation.SelectedItem.Text.ToUpper() == "WIFE") ||
                            (ddlRelation.SelectedItem.Text.ToUpper() == "DAUGHTER")) && (txt_FDOB.SelectedDate != null))
                        {
                            if ((Convert.ToDateTime(txt_FDOB.SelectedDate).AddYears(25).AddDays(-1)) <= DateTime.Now)
                            {

                                BLL.ShowMessage(this, "You can select only if the dependent age is less than 25.");
                                chkEduAlwnce.Checked = false;
                                txt_FDOB.Focus();
                                return;
                            }
                            /*if ((Convert.ToDateTime(txt_FDOB.SelectedDate).AddYears(18).AddDays(-1)) <= DateTime.Now)
                            {
                                BLL.ShowMessage(this, "Dependent already completed 18 years");
                                txt_FDOB.Focus();
                                return;
                            }*/
                        }
                        else
                        {
                            if (txt_FDOB.SelectedDate == null)
                            {
                                BLL.ShowMessage(this, "Please enter relation DOB before checking the Education checkbox");
                                chkEduAlwnce.Checked = false;
                                txt_FDOB.Focus();
                                return;
                            }
                            else
                            {
                                BLL.ShowMessage(this, "You are not supposed to select Dependent for selected relation ship");
                                chkEduAlwnce.Checked = false;
                                return;
                            }
                        }
                    }
                    else
                    {
                        if (ddlRelation.SelectedIndex == 0)
                        {
                            BLL.ShowMessage(this, "Please select employee relationship before checking the Education checkbox");
                            chkEduAlwnce.Checked = false;
                            ddlRelation.Focus();
                            return;
                        }
                        else if (rcmb_Period.SelectedIndex == 0)
                        {
                            BLL.ShowMessage(this, "Please select Financial period before checking the Education checkbox");
                            chkEduAlwnce.Checked = false;
                            return;
                        }
                        else
                        {
                            BLL.ShowMessage(this, "Please select Employee grade before checking the Education checkbox");
                            chkEduAlwnce.Checked = false;
                            return;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnkBtnFmlyEdit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            empFamilyDetailID = Convert.ToInt32(e.CommandArgument);

            _obj_smhr_employee.EMPFMDTL_ID = empFamilyDetailID;
            _obj_smhr_employee.OPERATION = operation.Select;

            DataTable dtEmpFmlyDtls = BLL.get_EmployeeFamily(_obj_smhr_employee);

            if (dtEmpFmlyDtls.Rows.Count > 0)
            {
                txt_FSerial.Text = Convert.ToString(dtEmpFmlyDtls.Rows[0]["EMPFMDTL_SERIAL"]);
                ddlRelation.SelectedIndex = ddlRelation.Items.FindItemIndexByValue(Convert.ToString(dtEmpFmlyDtls.Rows[0]["EMPFMDTL_EMPREL_ID"]));
                radSurName.Text = Convert.ToString(dtEmpFmlyDtls.Rows[0]["EMPFMDTL_SURNAME"]);
                txt_Name.Text = Convert.ToString(dtEmpFmlyDtls.Rows[0]["EMPFMDTL_NAME"]);
                if (Convert.ToString(dtEmpFmlyDtls.Rows[0]["EMPFMDTL_RELDOB"]) != string.Empty)
                    txt_FDOB.SelectedDate = Convert.ToDateTime(dtEmpFmlyDtls.Rows[0]["EMPFMDTL_RELDOB"]);
                if (Convert.ToBoolean(dtEmpFmlyDtls.Rows[0]["EMPFMDTL_IS_DEP"]) == true)
                    chkDeptAlwnce.Checked = true;
                else
                    chkDeptAlwnce.Checked = false;
                if (Convert.ToBoolean(dtEmpFmlyDtls.Rows[0]["EMPFMDTL_IS_EDU"]) == true)
                    chkEduAlwnce.Checked = true;
                else
                    chkEduAlwnce.Checked = false;
                if (Convert.ToBoolean(dtEmpFmlyDtls.Rows[0]["EMPFMDTL_IS_MED"]) == true)
                    chkMedAlwnce.Checked = true;
                else
                    chkMedAlwnce.Checked = false;

                btn_Fam_Add.Visible = false;
                btn_Fam_Correct.Visible = true;
            }
            else
            {
                btn_Fam_Add.Visible = true;
                btn_Fam_Correct.Visible = false;
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rdp_contract_start_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        /*if (rdp_contract_start.SelectedDate != null)
        {
            rdp_contract_end.Clear();
            rdp_contract_end.MinDate = Convert.ToDateTime(rdp_contract_start.SelectedDate);
            rdp_contract_end.Focus();
        }
        else
            rdp_contract_start.Focus();*/
        if (rdp_contract_start.SelectedDate != null || rdp_contract_end.SelectedDate != null)
        {
            if (rdp_contract_end.SelectedDate < rdp_contract_start.SelectedDate)
            {
                BLL.ShowMessage(this, "Contract Start Date Should Less Than Contract End Date");
                rdp_contract_start.Focus();
                rdp_contract_start.SelectedDate = null;
                return;

            }
        }
    }
    protected void rdp_contract_end_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        if (rdp_contract_start.SelectedDate != null || rdp_contract_end.SelectedDate != null)
        {
            if (rdp_contract_start.SelectedDate > rdp_contract_end.SelectedDate)
            {
                BLL.ShowMessage(this, "Contract End Date Should Not Less Than Contract Start Date");
                rdp_contract_end.Focus();
                rdp_contract_end.SelectedDate = null;
                return;

            }
        }
    }
}