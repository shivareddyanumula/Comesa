using System;
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
using System.Data.OleDb;
using System.IO;

public partial class HR_frmemployee : System.Web.UI.Page
{
    SMHR_EMPLOYEE _obj_smhr_employee;
    DataTable dt_Details;
    static string _lbl_Emp_ID = "";
    string strfilename2;
    DataSet ds = new DataSet();
    DataSet ds_directemp = new DataSet();
    DataTable dt_Qual; //Datatable for Qualification

    DataSet ds_Qualification = new DataSet();
    DataSet ds_skills = new DataSet();
    DataSet ds_experiance = new DataSet();
    DataSet ds_contact = new DataSet();
    DataSet ds_language = new DataSet();
    DataSet ds_Family = new DataSet();
    DataSet ds_Otherdetails = new DataSet();
    DataSet ds_weeklyOff = new DataSet();
    DataSet ds_physicaldetails = new DataSet();

    bool stdatetime;
    int Year;

    int bu_id;
    int paymentmode;
    int relaid;
    string emp_status;
    int Sbuid;
    int Applicant_id;

    RadComboBox ddl_BusinessUnit = new RadComboBox();
    RadComboBox ddl_Applicant = new RadComboBox();
    RadComboBox ddl_Mode = new RadComboBox();
    RadComboBox ddl_Department = new RadComboBox();
    RadComboBox ddl_Designation = new RadComboBox();
    RadComboBox ddl_Sup_BusinessUnit = new RadComboBox();
    RadComboBox ddl_Supervisor = new RadComboBox();
    RadComboBox ddl_EmpStatus = new RadComboBox();
    RadComboBox ddl_Currency = new RadComboBox();
    RadComboBox ddl_Grade = new RadComboBox();
    RadComboBox ddl_SalaryStructure = new RadComboBox();
    RadComboBox rcmb_Period = new RadComboBox();
    RadComboBox ddl_LeaveStructure = new RadComboBox();
    RadComboBox ddl_Shift = new RadComboBox();
    RadComboBox ddl_Employee_Status = new RadComboBox();
    RadComboBox ddl_OTType = new RadComboBox();
    RadComboBox rcb_YearLastUsed = new RadComboBox();
    RadComboBox ddl_Employee = new RadComboBox();
    RadComboBox ddl_Relationship = new RadComboBox();
    Label lbl_Code = new Label();
    SMHR_BUSINESSUNIT _obj_smhr_businessunit;
    SMHR_APPLICANT _obj_smhr_applicant;
    SMHR_MASTERS _obj_smhr_masters;
    SMHR_LEAVESTRUCT _obj_smhr_leaveStruct;
    SMHR_POSITIONS _obj_smhr_positions;
    SMHR_SALARYSTRUCT _obj_smhr_salaryStruct;
    SMHR_SHIFTDEFINITION _obj_smhr_shift;
    SMHR_EMPLOYEEWEEKLYOFF _obj_smhr_weeklyoff;
    SMHR_GLOBALCONFIG _obj_smhr_globalconfig;
    SMHR_CURRENCY _obj_smhr_Currency;
    SMHR_DEPARTMENT _obj_Department;
    SMHR_EMPOTHERDETAILS _obj_SMHR_EMPOTHERDETAILS;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_EMP_PHYSICALDETAILS _obj_SMHR_EMPPHYSICALDETAILS;
    SMHR_EMP_TDS _obj_smhr_EMP_TDS;
    string aplicantcode;

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (RWM_POSTREPLY1.Windows.Count > 0)
        {
            RWM_POSTREPLY1.Windows.RemoveAt(0);
        }

        try
        {
            LoadCombos();
            ////

            ////
            RadComboBoxItem item1 = new RadComboBoxItem();
            item1.Text = "Permanent";
            item1.Value = "Permanent";
            RadComboBoxItem item2 = new RadComboBoxItem();
            item2.Text = "Contract";
            item2.Value = "Contract";
            RadComboBoxItem item3 = new RadComboBoxItem();
            item3.Text = "Consultant";
            item3.Value = "Consultant";
            ddl_EmpStatus.Items.Add(item1);
            ddl_EmpStatus.Items.Add(item2);
            ddl_EmpStatus.Items.Add(item3);
            //  ddl_EmpStatus.Items.Insert(0, new RadComboBoxItem("", ""));




            RadComboBoxItem item4 = new RadComboBoxItem();
            item4.Text = "Beginner";
            item4.Value = "Beginner";
            RadComboBoxItem item5 = new RadComboBoxItem();
            item5.Text = "Intermediate";
            item5.Value = "Intermediate";
            RadComboBoxItem item6 = new RadComboBoxItem();
            item6.Text = "Expert";
            item6.Value = "Expert";
            rcb_YearLastUsed.Items.Add(item4);
            rcb_YearLastUsed.Items.Add(item5);
            rcb_YearLastUsed.Items.Add(item6);


            // LoadApplicant();
            BLL.gridDateFormat(Convert.ToString(Session["EMP_ID"]), RG_Employee, "EMP_DOJ");
            if (!Page.IsPostBack)
            {




                lbl_Result.Visible = false;

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
                    RG_Employee.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
                if (Convert.ToString(Request.QueryString["ID"]) != null)
                {
                    BLL.ShowMessage(this, "Employee with Code " + Convert.ToString(Request.QueryString["ID"]) + " Created Successfully");
                    return;
                }
                else if (Convert.ToString(Request.QueryString["ID1"]) != null)
                {
                    BLL.ShowMessage(this, "Employee with Code " + Convert.ToString(Request.QueryString["ID1"]) + " Updated Successfully");
                    // return;
                }
                else
                {
                    lbl_Result.Visible = false;
                }
            }
            string str_Filter = Convert.ToString(Session["RadGridFilter5"]);
            if (Convert.ToString(Request.QueryString["Filter1"]) != null)
            {
                RG_Employee.MasterTableView.FilterExpression = Convert.ToString(Session["RadGridFilter5"]);
                RG_Employee.Rebind();
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployee", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        try
        {
            string str_filter = RG_Employee.MasterTableView.FilterExpression;
            Session["RadGridFilter5"] = RG_Employee.MasterTableView.FilterExpression;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployee", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Employee_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            string str_Query = RG_Employee.MasterTableView.FilterExpression;
            _lbl_Emp_ID = Convert.ToString(e.CommandArgument);
            Response.Redirect("~/HR/frmemployeeadd.aspx?EID=" + Convert.ToString(_lbl_Emp_ID) + "&Filter=" + Convert.ToString(str_Query), false);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployee", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Click(object sender, EventArgs e)
    {
        try
        {
           
            SMHR_ORGANISATION _obj_Smhr_Organisation = new SMHR_ORGANISATION();
            _obj_Smhr_Organisation.MODE = 8;
            _obj_Smhr_Organisation.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            DataTable dt = BLL.get_Organisation(_obj_Smhr_Organisation);
            if (dt.Rows.Count != 0)
            {
                SMHR_EMPLOYEETYPE _obj_smhr_EmployeeType = new SMHR_EMPLOYEETYPE();
                _obj_smhr_EmployeeType.OPERATION = operation.Get;
                _obj_smhr_EmployeeType.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_global = BLL.get_EmployeeType(_obj_smhr_EmployeeType);

                if (dt_global.Rows.Count > 0)
                {
                    //if ((dt_global.Rows[0]["GLOBALCONFIG_EMP_CODE"] == System.DBNull.Value || Convert.ToString(dt_global.Rows[0]["GLOBALCONFIG_EMP_CODE"]) == "") ||
                    //    (dt_global.Rows[0]["GLOBALCONFIG_CONTRACT_EMPCODE"] == System.DBNull.Value || Convert.ToString(dt_global.Rows[0]["GLOBALCONFIG_CONTRACT_EMPCODE"]) == "") ||
                    //    (dt_global.Rows[0]["GLOBALCONFIG_CONSULTANT_EMPCODE"] == System.DBNull.Value || Convert.ToString(dt_global.Rows[0]["GLOBALCONFIG_CONSULTANT_EMPCODE"]) == ""))
                    //{
                    //    BLL.ShowMessage(this, "Please Set all Employee Type Prefixes in GlobalConfig Screen.");
                    //    return;
                    //}
                    if (Convert.ToInt32(dt_global.Rows[0]["EMPLOYEETYPE_PREFIXNULL"]) > 0)
                    {
                        BLL.ShowMessage(this, "Please Set all Employee Type Prefixes in Master Employee Types Screen.");
                        return;
                    }
                    else
                    {
                        if (Convert.ToString(dt.Rows[0]["ORGANISATION_EMPLOYEES"]) == "0")
                        {
                            Response.Redirect("frmemployeeadd.aspx");
                        }
                        else
                        {
                            //string val = BLL.PasswordEncrypt(Convert.ToString(3));
                            // string strVal = BLL.PasswordDecrypt(Convert.ToString(dt.Rows[0][1]));
                            _obj_smhr_employee = new SMHR_EMPLOYEE();
                            //_obj_smhr_employee.OPERATION = operation.Select;
                            _obj_smhr_employee.OPERATION = operation.EmployeeCount;
                            //_obj_smhr_employee.EMP_LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                            _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtDetails = BLL.get_Employee(_obj_smhr_employee);
                            string Val = BLL.PasswordDecrypt(Convert.ToString(dt.Rows[0]["ORGANISATION_EMPLOYEES"]));
                            string strVal = Convert.ToString(dtDetails.Rows[0]["EMPCOUNT"]);
                            if (dtDetails.Rows.Count != 0)
                            {
                                //if (BLL.PasswordDecrypt(Convert.ToString(dt.Rows[0]["ORGANISATION_EMPLOYEES"])) != Convert.ToString(dtDetails.Rows.Count))
                                if (Val != strVal)
                                {
                                    //if (Convert.ToInt32(BLL.PasswordDecrypt(Convert.ToString(dt.Rows[0]["ORGANISATION_EMPLOYEES"]))) > Convert.ToInt32(Convert.ToString(dtDetails.Rows.Count)))
                                    if (Convert.ToInt32(Val) > Convert.ToInt32(strVal))
                                    {
                                        Response.Redirect("frmemployeeadd.aspx", false);
                                    }
                                    else
                                    {
                                        BLL.ShowMessage(this, "You have only limited no of users License. You cannot create more employees");
                                        return;
                                    }

                                }
                                else
                                {
                                    BLL.ShowMessage(this, "You have only limited no of users License. You cannot create more employees");
                                    return;
                                }
                                //if (Convert.ToString(dt.Rows[0][0]) != "6rAoGC7EbQxz7FSee5gSCKsSCWJkUsWCvt4EVz99O0s=")
                                //{
                                //        if (dtDetails.Rows.Count != Convert.ToInt32(strVal))
                                //        {
                                //            Response.Redirect("frmemployeeadd.aspx");
                                //            return;
                                //        }
                                //        else
                                //        {
                                //            BLL.ShowMessage(this, "You have only limited no of users License. You cannot create more employees");
                                //            return;
                                //        }
                                //    }
                                //    else
                                //    {
                                //        Response.Redirect("frmemployeeadd.aspx");
                                //        return;
                                //    }
                                //}
                                //else
                                //{
                                //    Response.Redirect("frmemployeeadd.aspx");
                                //    return;
                                //}

                            }
                        }
                        Response.Redirect("frmemployeeadd.aspx", false);//by Bharadwaj 
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployee", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadData()
    {
        try
        {
            //if (Session["SELFSERVICE"] != "")
            //{
            //    if (Session["SELFSERVICE"] == "true")
            //    {
            //        _obj_smhr_employee = new SMHR_EMPLOYEE();
            //        _obj_smhr_employee.OPERATION = operation.Self;
            //        _obj_smhr_employee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            //        _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //        dt_Details = BLL.get_Employee(_obj_smhr_employee);
            //        RG_Employee.DataSource = dt_Details;
            //    }
            //    else
            //    {
            //        _obj_smhr_employee = new SMHR_EMPLOYEE();
            //        _obj_smhr_employee.OPERATION = operation.Select;
            //        _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //        _obj_smhr_employee.EMP_LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            //        dt_Details = BLL.get_Employee(_obj_smhr_employee);
            //        RG_Employee.DataSource = dt_Details;
            //    }
            //}
            //else
            //{
            //    _obj_smhr_employee = new SMHR_EMPLOYEE();
            //    _obj_smhr_employee.OPERATION = operation.SELECTSUPERVISOR;
            //    _obj_smhr_employee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            //    _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //    dt_Details = BLL.get_Employee(_obj_smhr_employee);
            //    RG_Employee.DataSource = dt_Details;
            //}
            _obj_smhr_employee = new SMHR_EMPLOYEE();
            _obj_smhr_employee.OPERATION = operation.Select;
            _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_employee.EMP_LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            dt_Details = BLL.get_Employee(_obj_smhr_employee);
            RG_Employee.DataSource = dt_Details;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployee", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void RG_Employee_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            if (ViewState["btnAdd"] == null)
            {
                LoadData();
                lbl_Result.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployee", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Delete_Excel_File()
    {
        try
        {
            ds.Dispose();
            if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == true)
            {
                // FileUpload_Task.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Corporate_Contract_Docs/") + Convert.ToString(rcmb_taskPorjectname.SelectedItem.Text.Replace("/", "_")), filename));

                string strpath = Server.MapPath("~/IMPORT_EXCEL/");


                DirectoryInfo dirinfo = new DirectoryInfo(strpath);
                strpath = strpath + strfilename2;
                FileInfo fi = new FileInfo(strpath);
                {
                    fi.Delete();
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployee", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadApplicant()
    {
        try
        {
            //ddl_Applicant.Items.Clear();
            _obj_smhr_applicant = new SMHR_APPLICANT();
            _obj_smhr_applicant.OPERATION = operation.Select;
            _obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_Applicant(_obj_smhr_applicant);
            ddl_Applicant.DataSource = dt_Details;
            ddl_Applicant.DataValueField = "APPLICANT_ID";
            ddl_Applicant.DataTextField = "APPNAME";
            ddl_Applicant.DataBind();
            // ddl_Applicant.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployee", ex.StackTrace, DateTime.Now);
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
            //      ddl_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            //Pay Currency
            ddl_Currency.Items.Clear();
            _obj_smhr_Currency = new SMHR_CURRENCY();
            _obj_smhr_Currency.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_Currency(_obj_smhr_Currency);
            ddl_Currency.DataSource = dt_Details;
            ddl_Currency.DataTextField = "CURR_CODE";
            ddl_Currency.DataValueField = "CURR_ID";
            ddl_Currency.DataBind();
            //    ddl_Currency.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            //Religion
            //ddl_Religion.Items.Clear();
            //_obj_smhr_masters = new SMHR_MASTERS();
            //_obj_smhr_masters.MASTER_TYPE = "RELIGION";
            //_obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //_obj_smhr_masters.OPERATION = operation.Select;
            //dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);
            //ddl_Religion.DataSource = dt_Details;
            //ddl_Religion.DataTextField = "HR_MASTER_CODE";
            //ddl_Religion.DataValueField = "HR_MASTER_ID";
            //ddl_Religion.DataBind();
            //ddl_Religion.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            ////Nationality
            //ddl_Nationality.Items.Clear();
            //_obj_smhr_masters.MASTER_TYPE = "NATIONALITY";
            //_obj_smhr_masters.OPERATION = operation.Select;
            //_obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);
            //ddl_Nationality.DataSource = dt_Details;
            //ddl_Nationality.DataTextField = "HR_MASTER_CODE";
            //ddl_Nationality.DataValueField = "HR_MASTER_ID";
            //ddl_Nationality.DataBind();
            //ddl_Nationality.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            ////Skill
            //rcb_Skill.Items.Clear();
            //_obj_smhr_masters.MASTER_TYPE = "SKILL";
            //_obj_smhr_masters.OPERATION = operation.Select;
            //_obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);
            //rcb_Skill.DataSource = dt_Details;
            //rcb_Skill.DataTextField = "HR_MASTER_CODE";
            //rcb_Skill.DataValueField = "HR_MASTER_ID";
            //rcb_Skill.DataBind();
            //rcb_Skill.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            ////Qualification
            //ddl_Category.Items.Clear();
            //_obj_smhr_masters.MASTER_TYPE = "QUALIFICATION";
            //_obj_smhr_masters.OPERATION = operation.Select;
            //_obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);
            //ddl_Category.DataSource = dt_Details;
            //ddl_Category.DataTextField = "HR_MASTER_CODE";
            //ddl_Category.DataValueField = "HR_MASTER_ID";
            //ddl_Category.DataBind();
            //ddl_Category.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            ////Language
            //ddl_Language.Items.Clear();
            //_obj_smhr_masters.MASTER_TYPE = "LANGUAGE";
            //_obj_smhr_masters.OPERATION = operation.Select;
            //_obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);
            //ddl_Language.DataSource = dt_Details;
            //ddl_Language.DataTextField = "HR_MASTER_CODE";
            //ddl_Language.DataValueField = "HR_MASTER_ID";
            //ddl_Language.DataBind();
            //ddl_Language.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));


            ////Grade
            ddl_Grade.Items.Clear();
            _obj_smhr_masters = new SMHR_MASTERS();
            _obj_smhr_masters.MASTER_TYPE = "GRADE";
            _obj_smhr_masters.OPERATION = operation.Select;
            _obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);
            ddl_Grade.DataSource = dt_Details;
            ddl_Grade.DataTextField = "HR_MASTER_CODE";
            ddl_Grade.DataValueField = "HR_MASTER_ID";
            ddl_Grade.DataBind();
            // ddl_Grade.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            
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

            //For loading period

            //rcmb_Period.Items.Clear();
            //_obj_smhr_employee = new SMHR_EMPLOYEE();
            //_obj_smhr_employee.OPERATION = operation.Select;
            //_obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //dt_Details = BLL.get_empperiod(_obj_smhr_employee);
            //rcmb_Period.DataSource = dt_Details;
            //rcmb_Period.DataTextField ="PERIOD_NAME";
            //rcmb_Period.DataValueField = "EMP_PERIOD_ID";
            //rcmb_Period.DataBind();


            ////Salary Structure
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
            //  ddl_SalaryStructure.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
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
            //   ddl_LeaveStructure.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            //Relationship
            //ddlRelation.Items.Clear();
            //_obj_smhr_masters.MASTER_TYPE = "RELATIONSHIP";
            //_obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //_obj_smhr_masters.OPERATION = operation.Select;
            //dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);
            //ddlRelation.DataSource = dt_Details;
            //ddlRelation.DataTextField = "HR_MASTER_CODE";
            //ddlRelation.DataValueField = "HR_MASTER_ID";
            //ddlRelation.DataBind();
            //ddlRelation.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            ////Shift
            ddl_Shift.Items.Clear();
            _obj_smhr_shift = new SMHR_SHIFTDEFINITION();
            _obj_smhr_shift.OPERATION = operation.Select;
            _obj_smhr_shift.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_ShiftDefinition(_obj_smhr_shift);
            ddl_Shift.DataSource = dt_Details;
            ddl_Shift.DataTextField = "SHIFT_CODE";
            ddl_Shift.DataValueField = "SHIFT_ID";
            ddl_Shift.DataBind();
            //   ddl_Shift.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
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
            //    rcb_YearLastUsed.Items.Insert(0, new RadComboBoxItem("Select"));
            ddl_Employee_Status.Items.Clear();
            _obj_smhr_masters.MASTER_TYPE = "STATUS";
            _obj_smhr_masters.OPERATION = operation.Select;
            dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);//as it is c data done nothing
            ddl_Employee_Status.DataSource = dt_Details;
            ddl_Employee_Status.DataTextField = "HR_MASTER_CODE";
            ddl_Employee_Status.DataValueField = "HR_MASTER_ID";
            ddl_Employee_Status.DataBind();
            // ddl_Employee_Status.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployee", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public static bool CheckStringValue(string str)
    {
        //
        // Convert true if number  or false if not
        //
        int Num;
        if (int.TryParse(str, out Num) == true)
        {
            if (Num > 2359)
            {
                return false;
            }
            if (str.Length != 4)
            {
                return false;

            }
            if (str.Length == 4)
            {
                string minute = str.Substring(2, 2);
                int minuteInt = int.Parse(minute);
                if (minuteInt >= 60)
                {
                    return false;
                }
            }

        }
        else
        {
            return false;
        }
        return true;
    }
    //*********************************

    public static bool CheckDateFormat(string strin)
    {
        try
        {
            if (strin.Length > 10)
            {
                return false;
            }
            char[] c = null;
            string strFinal = string.Empty;
            Array ar = strin.Split(new char[] { '/' });
            string yeararray = Convert.ToString(ar.GetValue(2));
            if (yeararray.Length > 4)
            {
                return false;
            }
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar.GetValue(i).ToString().Length == 1)
                {
                    strFinal = strFinal + "0" + ar.GetValue(i) + "/";
                }
                else if (ar.GetValue(i).ToString().Length == 2)
                {
                    strFinal = strFinal + ar.GetValue(i) + "/";
                }
                else
                {
                    if (strFinal.Length == 6)
                        strFinal = strFinal + ar.GetValue(i).ToString();
                    else
                        strFinal = strFinal + "/" + ar.GetValue(i).ToString();
                }
            }
            c = strFinal.ToCharArray();
            if ((c[2] != '/') || c[5] != '/')
            {
                return false;
            }

            if (Convert.ToInt32(strFinal.Substring(0, 2).Trim()) > 31)
            {
                return false;
            }
            if (Convert.ToInt32(strFinal.Substring(3, 2).Trim()) > 12)
            {
                return false;
            }

            if (Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 2)
            {
                if (Convert.ToInt32(strFinal.Substring(6, 4).Trim()) / 4 == 0)
                { // check leap year

                    if (Convert.ToInt32(strFinal.Substring(0, 2).Trim()) > 29)
                    {
                        return false;
                    }

                }
                else
                {
                    if (Convert.ToInt32(strFinal.Substring(0, 2).Trim()) > 28)
                    {
                        return false;
                    }
                }

            }
            if (Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 1 || Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 3 || Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 5 || Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 7 || Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 8 || Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 10 || Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 12)
            {
                if (Convert.ToInt32(strFinal.Substring(0, 2).Trim()) > 31)
                {
                    return false;
                }
            }
            if (Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 4 || Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 6 || Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 9 || Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 11)
            {
                if (Convert.ToInt32(strFinal.Substring(0, 2).Trim()) > 30)
                {
                    return false;
                }
            }



            return true;
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
    }
    //*************************

    //protected void Btn_Imp_Employee_click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        //written by rajasekhar


    //        Session.Remove("dt_fail");
    //        Session.Remove("ds_data");
    //        Session.Remove("dt_fail_FAM");
    //        Session.Remove("ds_data_fam");
    //        Session.Remove("dt_fail_weof");
    //        Session.Remove("ds_data_weof");
    //        Session.Remove("dt_fail_od");
    //        Session.Remove("ds_data_od");

    //        Session.Remove("dt_fail_phd");
    //        Session.Remove("ds_data_phd");
    //        string strcon = null;

    //        string strfilename1 = FileUpload1.FileName;
    //        strfilename2 = Convert.ToString(DateTime.Now.TimeOfDay) + "_" + strfilename1;
    //        strfilename2 = strfilename2.Replace("/", "").Replace(":", ".");
    //        if (FileUpload1.HasFile)
    //        {

    //            if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == false)
    //            {
    //                System.IO.Directory.CreateDirectory(Server.MapPath("~/IMPORT_EXCEL/"));

    //            }



    //            FileUpload1.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/IMPORT_EXCEL/"), strfilename2));
    //            string filename1 = Server.MapPath("~/IMPORT_EXCEL/") + ("") + (Convert.ToString(strfilename2));
    //            FileInfo fileInfo = new FileInfo(filename1);
    //            if (fileInfo.Exists)
    //            {
    //                string path = MapPath(strfilename1);
    //                // string name = Path.GetFileName( path );
    //                string ext = Path.GetExtension(path);

    //                string type = string.Empty;
    //                //  set known types based on file extension  
    //                if (ext != null)
    //                {
    //                    switch (ext.ToLower())
    //                    {

    //                        case ".xls":

    //                            type = "excel";
    //                            break;
    //                        case ".xlsx":
    //                            type = "excel";
    //                            break;

    //                        default:
    //                            type = string.Empty;
    //                            break;
    //                    }
    //                }
    //                if (type == string.Empty)
    //                {
    //                    if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == true)
    //                    {

    //                        string path1 = Server.MapPath("~/IMPORT_EXCEL/") + ("") + (Convert.ToString(strfilename2));
    //                        System.IO.File.Delete(path1);
    //                    }
    //                    BLL.ShowMessage(this, "Please select the Excel File  (Eg: Excel.xlsx). ");
    //                    return;
    //                }
    //            }
    //        }


    //        else
    //        {
    //            BLL.ShowMessage(this, "Please Select the File to be uploaded");
    //            return;
    //        }

    //        string strpath = Server.MapPath("~/IMPORT_EXCEL/");

    //        strpath = strpath + strfilename2;


    //        // Getting data from excell file to dataset.
    //        strcon = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source='" + strpath + "';" + "Extended Properties=Excel 12.0;";


    //        OleDbConnection objConn = null;
    //        objConn = new OleDbConnection(strcon);
    //        objConn.Open();

    //        DataTable dt_chk2 = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
    //        string sheetname;
    //        if (dt_chk2 == null)
    //        {
    //            objConn.Close();
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        else
    //        {
    //            sheetname = Convert.ToString(dt_chk2.Rows[3]["TABLE_NAME"]);
    //        }
    //        OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM  [" + sheetname + "]", strcon);



    //        da.Fill(ds);
    //        ds.Tables[0].Columns.Add("Error Message");

    //        objConn.Close();
    //        DataTable dt = new DataTable();
    //        DataTable dtfail = new DataTable();


    //        string errormsg = string.Empty;


    //        Int32 rowno = 0;


    //        string columnno = null;

    //        Boolean filestatus = true;
    //        dtfail.Columns.Add("S.NO", typeof(Int32));
    //        dtfail.Columns.Add("ROWNO", typeof(Int32));
    //        dtfail.Columns.Add("COLUMNS NAMES", typeof(string));

    //        if (ds.Tables[0].Columns[0].ToString().Trim() == "ApplicantID*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds.Tables[0].Columns[1].ToString().Trim() == "Business Unit*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds.Tables[0].Columns[2].ToString().Trim() == "DateOfJoin*(dd/mm/yyyy)")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds.Tables[0].Columns[3].ToString().Trim() == "Date of Confirm*(dd/mm/yyyy)")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds.Tables[0].Columns[4].ToString().Trim() == "Payment Mode*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds.Tables[0].Columns[5].ToString().Trim() == "Department*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds.Tables[0].Columns[6].ToString().Trim() == "Position*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds.Tables[0].Columns[7].ToString().Trim() == "Employee Type*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds.Tables[0].Columns[8].ToString().Trim() == "Grade")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds.Tables[0].Columns[9].ToString().Trim() == "Leave Structure*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds.Tables[0].Columns[10].ToString().Trim() == "Currency*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds.Tables[0].Columns[11].ToString().Trim() == "Salary Structure*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds.Tables[0].Columns[12].ToString().Trim() == "Shift*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds.Tables[0].Columns[13].ToString().Trim() == "Supervisor Business Unit")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds.Tables[0].Columns[14].ToString().Trim() == "Supervisor")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds.Tables[0].Columns[15].ToString().Trim() == "Gross Salary*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        //if (ds.Tables[0].Columns[16].ToString().Trim() == "Basic Pay*")
    //        //{
    //        //}
    //        //else
    //        //{
    //        //    Delete_Excel_File();
    //        //    BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //        //    return;

    //        //}
    //        if (ds.Tables[0].Columns[16].ToString().Trim() == "Probation Date(dd/mm/yyyy)")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds.Tables[0].Columns[17].ToString().Trim() == "Previous Promotion(dd/mm/yyyy)")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds.Tables[0].Columns[18].ToString().Trim() == "Notification Period")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds.Tables[0].Columns[19].ToString().Trim() == "Is Supervisor Mandatory")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds.Tables[0].Columns[20].ToString().Trim() == "Is VariablePay")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }

    //        if (ds.Tables[0].Columns[21].ToString().Trim() == "No Of Times Payable")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds.Tables[0].Columns[22].ToString().Trim() == "Variable Amount")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds.Tables[0].Columns[23].ToString().Trim() == "Hobbies")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds.Tables[0].Columns[24].ToString().Trim() == "Contract Date*(dd/mm/yyyy)")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        // Employee_family details
    //        objConn = new OleDbConnection(strcon);
    //        objConn.Open();
    //        sheetname = Convert.ToString(dt_chk2.Rows[0]["TABLE_NAME"]);

    //        OleDbDataAdapter da_family = new OleDbDataAdapter("SELECT * FROM  [" + sheetname + "]", strcon);
    //        //da.Fill(ds);
    //        //ds.Tables[0].Columns.Add("Error Message");
    //        da_family.Fill(ds_Family);
    //        ds_Family.Tables[0].Columns.Add("Error Message");

    //        objConn.Close();
    //        DataTable dtfail_family = new DataTable();



    //        dtfail_family.Columns.Add("S.NO", typeof(Int32));
    //        dtfail_family.Columns.Add("ROWNO", typeof(Int32));
    //        dtfail_family.Columns.Add("COLUMNS NAMES", typeof(string));

    //        if (ds_Family.Tables[0].Columns[0].ToString().Trim() == "ApplicantID*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }

    //        if (ds_Family.Tables[0].Columns[1].ToString().Trim() == "Date of Birth(dd/mm/yyyy)*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_Family.Tables[0].Columns[2].ToString().Trim() == "Relationship*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_Family.Tables[0].Columns[3].ToString().Trim() == "Is Dependant")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_Family.Tables[0].Columns[4].ToString().Trim() == "Name*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_Family.Tables[0].Columns[5].ToString().Trim() == "Next to Kin")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_Family.Tables[0].Columns[6].ToString().Trim() == "Emergency Contact")
    //        {
    //        }
    //        else
    //        {

    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_Family.Tables[0].Columns[7].ToString().Trim() == "Annual Income")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_Family.Tables[0].Columns[8].ToString().Trim() == "Occupation")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }


    //        //@@@@@@@@@@@@@@Employee weeklyoff
    //        objConn = new OleDbConnection(strcon);
    //        objConn.Open();
    //        sheetname = Convert.ToString(dt_chk2.Rows[4]["TABLE_NAME"]);

    //        OleDbDataAdapter da_weeklyoff = new OleDbDataAdapter("SELECT * FROM  [" + sheetname + "]", strcon);
    //        da_weeklyoff.Fill(ds_weeklyOff);
    //        ds_weeklyOff.Tables[0].Columns.Add("Error Message");
    //        objConn.Close();
    //        DataTable dtfail_weeklyoff = new DataTable();



    //        dtfail_weeklyoff.Columns.Add("S.NO", typeof(Int32));
    //        dtfail_weeklyoff.Columns.Add("ROWNO", typeof(Int32));
    //        dtfail_weeklyoff.Columns.Add("COLUMNS NAMES", typeof(string));

    //        if (ds_weeklyOff.Tables[0].Columns[0].ToString().Trim() == "ApplicantID*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }

    //        if (ds_weeklyOff.Tables[0].Columns[1].ToString().Trim() == "Effective Date*(dd/mm/yyyy)")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }

    //        if (ds_weeklyOff.Tables[0].Columns[2].ToString().Trim() == "Monday")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_weeklyOff.Tables[0].Columns[3].ToString().Trim() == "Tuesday")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_weeklyOff.Tables[0].Columns[4].ToString().Trim() == "Wednesday")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_weeklyOff.Tables[0].Columns[5].ToString().Trim() == "Thursday")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_weeklyOff.Tables[0].Columns[6].ToString().Trim() == "Friday")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_weeklyOff.Tables[0].Columns[7].ToString().Trim() == "Saturday")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_weeklyOff.Tables[0].Columns[8].ToString().Trim() == "Sunday")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }

    //        //@@@@@@@@@employee OthrerDetails


    //        objConn = new OleDbConnection(strcon);
    //        objConn.Open();
    //        sheetname = Convert.ToString(dt_chk2.Rows[1]["TABLE_NAME"]);

    //        OleDbDataAdapter da_empotherdetails = new OleDbDataAdapter("SELECT * FROM  [" + sheetname + "]", strcon);
    //        da_empotherdetails.Fill(ds_Otherdetails);
    //        ds_Otherdetails.Tables[0].Columns.Add("Error Message");
    //        objConn.Close();
    //        DataTable dtfail_empod = new DataTable();



    //        dtfail_empod.Columns.Add("S.NO", typeof(Int32));
    //        dtfail_empod.Columns.Add("ROWNO", typeof(Int32));
    //        dtfail_empod.Columns.Add("COLUMNS NAMES", typeof(string));

    //        if (ds_Otherdetails.Tables[0].Columns[0].ToString().Trim() == "ApplicantID*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }

    //        if (ds_Otherdetails.Tables[0].Columns[1].ToString().Trim() == "PF Number")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_Otherdetails.Tables[0].Columns[2].ToString().Trim() == "PAN Number")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_Otherdetails.Tables[0].Columns[3].ToString().Trim() == "ESI Number")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_Otherdetails.Tables[0].Columns[4].ToString().Trim() == "Gratuity Number")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }

    //        //@@@@@@@@@@@employee Physical Details



    //        objConn = new OleDbConnection(strcon);
    //        objConn.Open();
    //        sheetname = Convert.ToString(dt_chk2.Rows[2]["TABLE_NAME"]);

    //        OleDbDataAdapter da_empphysicaldetails = new OleDbDataAdapter("SELECT * FROM  [" + sheetname + "]", strcon);
    //        da_empphysicaldetails.Fill(ds_physicaldetails);
    //        ds_physicaldetails.Tables[0].Columns.Add("Error Message");
    //        objConn.Close();
    //        DataTable dtfail_emphy = new DataTable();



    //        dtfail_emphy.Columns.Add("S.NO", typeof(Int32));
    //        dtfail_emphy.Columns.Add("ROWNO", typeof(Int32));
    //        dtfail_emphy.Columns.Add("COLUMNS NAMES", typeof(string));

    //        if (ds_physicaldetails.Tables[0].Columns[0].ToString().Trim() == "ApplicantID*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }

    //        if (ds_physicaldetails.Tables[0].Columns[1].ToString().Trim() == "Mobile No")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_physicaldetails.Tables[0].Columns[2].ToString().Trim() == "Email ID")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_physicaldetails.Tables[0].Columns[3].ToString().Trim() == "LandLine No")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_physicaldetails.Tables[0].Columns[4].ToString().Trim() == "Height(cms)")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_physicaldetails.Tables[0].Columns[5].ToString().Trim() == "Skin Color")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_physicaldetails.Tables[0].Columns[6].ToString().Trim() == "Mole Identification Or Other Marks")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_physicaldetails.Tables[0].Columns[7].ToString().Trim() == "Is Handicapped?")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_physicaldetails.Tables[0].Columns[8].ToString().Trim() == "Details")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_physicaldetails.Tables[0].Columns[9].ToString().Trim() == "Weight(Kgs)")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_physicaldetails.Tables[0].Columns[10].ToString().Trim() == "Eye Power")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_physicaldetails.Tables[0].Columns[11].ToString().Trim() == "(physical)Treatment Name")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_physicaldetails.Tables[0].Columns[12].ToString().Trim() == "Hospital Name")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_physicaldetails.Tables[0].Columns[13].ToString().Trim() == "Treatment Duration(days)")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_physicaldetails.Tables[0].Columns[14].ToString().Trim() == "Current Illness Status")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_physicaldetails.Tables[0].Columns[15].ToString().Trim() == "(Mental)Treatment Name")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_physicaldetails.Tables[0].Columns[16].ToString().Trim() == "Hospital Name")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_physicaldetails.Tables[0].Columns[17].ToString().Trim() == "Treatment Duration(days)")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_physicaldetails.Tables[0].Columns[18].ToString().Trim() == "Current Illness Status1")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        //if (ds.Tables[0].Rows.Count == 0)
    //        //{
    //        //    Delete_Excel_File();
    //        //    BLL.ShowMessage(this, "Successfully processed Excel file. No Records are Imported.");
    //        //    return;
    //        //}
    //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //        {
    //            // LoadCombos();
    //            //  LoadApplicant();

    //            errormsg = string.Empty;
    //            columnno = string.Empty;

    //            if (ds.Tables[0].Rows[i]["ApplicantID*"].ToString().Trim() != "")
    //            {





    //                for (int count = 0; count < ddl_Applicant.Items.Count; count++)
    //                {
    //                    string code = "";
    //                    code = ddl_Applicant.Items[count].Text;
    //                    bool name = code.Contains("-");
    //                    if (name)
    //                    {
    //                        int index = code.IndexOf("-");
    //                        code = code.Substring(0, index);

    //                    }
    //                    if ((ds.Tables[0].Rows[i]["ApplicantID*"].ToString().Trim()) == code.Trim())
    //                    {
    //                        Applicant_id = Convert.ToInt32(ddl_Applicant.Items[count].Value);

    //                    }





    //                }
    //                if (Applicant_id == 0)
    //                {
    //                    errormsg = errormsg + "," + "Applicant with this Code Does not  Exists";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = "ApplicantID*";

    //                }

    //            }

    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = "ApplicantID*";
    //            }
    //            for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
    //            {
    //                if (ds.Tables[0].Rows[i]["ApplicantID*"].ToString().Trim() == ds.Tables[0].Rows[k]["ApplicantID*"].ToString().Trim())
    //                {
    //                    if (i != k)
    //                    {
    //                        errormsg = "ApplicantID is repeated in Excel Sheet";
    //                        filestatus = false;
    //                        rowno = i + 2;
    //                        columnno = "ApplicantID*";
    //                    }
    //                }
    //            }

    //            if (ds.Tables[0].Rows[i]["Business Unit*"].ToString().Trim() != "")
    //            {

    //                for (int count = 0; count < ddl_BusinessUnit.Items.Count; count++)
    //                {
    //                    if ((ds.Tables[0].Rows[i]["Business Unit*"].ToString().Trim()) == ddl_BusinessUnit.Items[count].Text)
    //                    {
    //                        bu_id = Convert.ToInt32(ddl_BusinessUnit.Items[count].Value);

    //                    }

    //                }
    //                if (bu_id == 0)
    //                {
    //                    errormsg = errormsg + "," + "Business Unit Does not  Exists";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = columnno + "," + "Business Unit*";

    //                }
    //                else
    //                {

    //                    LoadMode();
    //                    LoadCurrency();
    //                    getPosition();
    //                    // LoadDates();
    //                    LoadDepartment();
    //                    getSupervisor();
    //                    get_SupBusinessUnit();
    //                }

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Business Unit*";
    //            }
    //            if (ds.Tables[0].Rows[i]["DateOfJoin*(dd/mm/yyyy)"].ToString().Trim() != "")
    //            {
    //                string dojdate = "";

    //                dojdate = ds.Tables[0].Rows[i]["DateOfJoin*(dd/mm/yyyy)"].ToString().Trim();

    //                bool wrongsdformat = dojdate.Contains(".");

    //                if (wrongsdformat)
    //                    dojdate = dojdate.Replace(".", "/");
    //                bool Chkdate = CheckDateFormat(dojdate);
    //                if (Chkdate == false)
    //                {
    //                    errormsg = errormsg + "," + "Enter Correct Start Date";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = columnno + "," + "DateOfJoin*(dd/mm/yyyy)";

    //                }

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "DateOfJoin*(dd/mm/yyyy)";

    //            }
    //            if (ds.Tables[0].Rows[i]["Date of Confirm*(dd/mm/yyyy)"].ToString().Trim() != "")
    //            {
    //                string docdate = "";

    //                docdate = ds.Tables[0].Rows[i]["Date of Confirm*(dd/mm/yyyy)"].ToString().Trim();

    //                bool wrongsdformat = docdate.Contains(".");

    //                if (wrongsdformat)
    //                    docdate = docdate.Replace(".", "/");
    //                bool Chkdate = CheckDateFormat(docdate);


    //                if (Chkdate == false)
    //                {
    //                    errormsg = errormsg + "," + "Enter Correct Start Date";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = columnno + "," + "Date of Confirm*(dd/mm/yyyy)";

    //                }
    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Date of Confirm*(dd/mm/yyyy)";
    //            }
    //            if (ds.Tables[0].Rows[i]["Payment Mode*"].ToString().Trim() != "")
    //            {
    //                for (int count = 0; count < ddl_Mode.Items.Count; count++)
    //                {
    //                    if ((ds.Tables[0].Rows[i]["Payment Mode*"].ToString().Trim()) == ddl_Mode.Items[count].Text)
    //                    {
    //                        paymentmode = Convert.ToInt32(ddl_Mode.Items[count].Value);

    //                    }

    //                }

    //                if (paymentmode == 0)
    //                {
    //                    errormsg = errormsg + "," + "Payment Mode Does not  Exists";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = columnno + "," + "Payment Mode*";

    //                }
    //                else
    //                {
    //                }

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Payment Mode*";
    //            }


    //            if (ds.Tables[0].Rows[i]["Department*"].ToString().Trim() != "")
    //            {

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Department*";

    //            }
    //            if (ds.Tables[0].Rows[i]["Position*"].ToString().Trim() != "")
    //            {

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Position*";

    //            }
    //            if (ds.Tables[0].Rows[i]["Employee Type*"].ToString().Trim() != "")
    //            {

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Employee Type*";

    //            }
    //            if (ds.Tables[0].Rows[i]["Leave Structure*"].ToString().Trim() != "")
    //            {

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Leave Structure*";

    //            }

    //            if (ds.Tables[0].Rows[i]["Currency*"].ToString().Trim() != "")
    //            {

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Currency*";

    //            }

    //            if (ds.Tables[0].Rows[i]["Salary Structure*"].ToString().Trim() != "")
    //            {

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Salary Structure*";

    //            }
    //            if (ds.Tables[0].Rows[i]["Shift*"].ToString().Trim() != "")
    //            {

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Shift*";

    //            }
    //            if (ds.Tables[0].Rows[i]["Gross Salary*"].ToString().Trim() != "")
    //            {

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Gross Salary*";

    //            }
    //            //if (ds.Tables[0].Rows[i]["Basic Pay*"].ToString().Trim() != "")
    //            //{

    //            //}
    //            //else
    //            //{
    //            //    filestatus = false;
    //            //    rowno = i + 2;
    //            //    columnno = columnno + "," + "Basic Pay*";

    //            //}
    //            if (ds.Tables[0].Rows[i]["Contract Date*(dd/mm/yyyy)"].ToString().Trim() != "")
    //            {

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Contract Date*(dd/mm/yyyy)";

    //            }
    //            if (filestatus == false)
    //            {
    //                DataRow newrow = dtfail.NewRow();
    //                newrow["S.NO"] = dtfail.Rows.Count + 1;


    //                newrow["ROWNO"] = rowno;
    //                newrow["COLUMNS NAMES"] = columnno;
    //                dtfail.Rows.Add(newrow);
    //                ds.Tables[0].Rows[i]["Error Message"] = errormsg;
    //            }
    //        }


    //        //@@@@@@@@@@@@@@@@@@@employee_family details ApplicantID*
    //        for (int i = 0; i < ds_Family.Tables[0].Rows.Count; i++)
    //        {
    //            errormsg = string.Empty;
    //            columnno = string.Empty;
    //            if (ds_Family.Tables[0].Rows[i]["ApplicantID*"].ToString().Trim() != "")
    //            {
    //                if (ds_Family.Tables[0].Rows[i]["ApplicantID*"].ToString().Trim() != ds.Tables[0].Rows[i]["ApplicantID*"].ToString().Trim())
    //                {
    //                    errormsg = "Enter Correct Applicant Id";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = "ApplicantID*";

    //                }
    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = "ApplicantID*";

    //            }
    //            //for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
    //            //{
    //            //    if (ds_Family.Tables[0].Rows[i]["ApplicantID*"].ToString().Trim() == ds_Family.Tables[0].Rows[k]["ApplicantID*"].ToString().Trim())
    //            //    {
    //            //        if (i != k)
    //            //        {
    //            //            errormsg = "ApplicantID is repeated in Excel Sheet";
    //            //            filestatus = false;
    //            //            rowno = i + 2;
    //            //            columnno = "ApplicantID*";
    //            //        }
    //            //    }
    //            //}

    //            if (ds_Family.Tables[0].Rows[i]["Date of Birth(dd/mm/yyyy)*"].ToString().Trim() != "")
    //            {

    //                string dateofbirth = "";

    //                dateofbirth = ds_Family.Tables[0].Rows[i]["Date of Birth(dd/mm/yyyy)*"].ToString();

    //                bool wrongsdformat = dateofbirth.Contains(".");

    //                if (wrongsdformat)
    //                    dateofbirth = dateofbirth.Replace(".", "/");

    //                bool Chkdate = CheckDateFormat(dateofbirth);
    //                if (Chkdate == false)
    //                {
    //                    errormsg = errormsg + "," + "Enter Correct Date of Birth";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = columnno + "," + "Date of Birth(dd/mm/yyyy)*";

    //                }
    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Date of Birth(dd/mm/yyyy)*";

    //            }
    //            if (ds_Family.Tables[0].Rows[i]["Relationship*"].ToString().Trim() != "")
    //            {
    //                for (int count = 0; count < ddl_Relationship.Items.Count; count++)
    //                {
    //                    if ((ds_Family.Tables[0].Rows[i]["Relationship*"].ToString().Trim()) == ddl_Relationship.Items[count].Text)
    //                    {
    //                        relaid = Convert.ToInt32(ddl_Relationship.Items[count].Value);

    //                    }

    //                }

    //                if (relaid == 0)
    //                {
    //                    errormsg = errormsg + "," + "Relation Does not  Exists";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = columnno + "," + "Relationship";

    //                }
    //                else
    //                {
    //                }
    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Relationship";


    //            }
    //            if (ds_Family.Tables[0].Rows[i]["Is Dependant"].ToString().Trim() != "")
    //            {
    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Is Dependant";


    //            }
    //            if (ds_Family.Tables[0].Rows[i]["Name*"].ToString().Trim() != "")
    //            {
    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Name*";


    //            }
    //            if (filestatus == false)
    //            {
    //                DataRow newrow = dtfail_family.NewRow();
    //                newrow["S.NO"] = dtfail_family.Rows.Count + 1;


    //                newrow["ROWNO"] = rowno;
    //                newrow["COLUMNS NAMES"] = columnno;
    //                dtfail_family.Rows.Add(newrow);
    //                ds_Family.Tables[0].Rows[i]["Error Message"] = errormsg;
    //            }

    //        }



    //        //@@@@@@@@@Employee WeeklyOff

    //        for (int i = 0; i < ds_weeklyOff.Tables[0].Rows.Count; i++)
    //        {
    //            errormsg = string.Empty;
    //            columnno = string.Empty;
    //            if (ds_weeklyOff.Tables[0].Rows[i]["ApplicantID*"].ToString().Trim() != "")
    //            {

    //                if (ds_weeklyOff.Tables[0].Rows[i]["ApplicantID*"].ToString().Trim() != ds.Tables[0].Rows[i]["ApplicantID*"].ToString().Trim())
    //                {
    //                    errormsg = "Enter Correct Applicant Id";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = "ApplicantID*";

    //                }


    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = "ApplicantID*";

    //            }
    //            for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
    //            {
    //                if (ds_weeklyOff.Tables[0].Rows[i]["ApplicantID*"].ToString().Trim() == ds_weeklyOff.Tables[0].Rows[k]["ApplicantID*"].ToString().Trim())
    //                {
    //                    if (i != k)
    //                    {
    //                        errormsg = "ApplicantID is repeated in Excel Sheet";
    //                        filestatus = false;
    //                        rowno = i + 2;
    //                        columnno = "ApplicantID*";
    //                    }
    //                }
    //            }

    //            if (ds_weeklyOff.Tables[0].Rows[i]["Effective Date*(dd/mm/yyyy)"].ToString().Trim() != "")
    //            {

    //                string efd = "";

    //                efd = ds_weeklyOff.Tables[0].Rows[i]["Effective Date*(dd/mm/yyyy)"].ToString();

    //                bool wrongsdformat = efd.Contains(".");

    //                if (wrongsdformat)
    //                    efd = efd.Replace(".", "/");

    //                bool Chkdate = CheckDateFormat(efd);
    //                if (Chkdate == false)
    //                {
    //                    errormsg = errormsg + "," + "Enter Correct Effective  Date";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = columnno + "," + "Effective Date*(dd/mm/yyyy)";

    //                }
    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Effective Date*(dd/mm/yyyy)";

    //            }
    //            if (filestatus == false)
    //            {
    //                DataRow newrow = dtfail_weeklyoff.NewRow();
    //                newrow["S.NO"] = dtfail_weeklyoff.Rows.Count + 1;


    //                newrow["ROWNO"] = rowno;
    //                newrow["COLUMNS NAMES"] = columnno;
    //                dtfail_weeklyoff.Rows.Add(newrow);
    //                ds_weeklyOff.Tables[0].Rows[i]["Error Message"] = errormsg;
    //            }
    //        }


    //        //@@@@@@@@@employee Other Details

    //        for (int i = 0; i < ds_Otherdetails.Tables[0].Rows.Count; i++)
    //        {
    //            errormsg = string.Empty;
    //            columnno = string.Empty;
    //            if (ds_Otherdetails.Tables[0].Rows[i]["ApplicantID*"].ToString().Trim() != "")
    //            {
    //                for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
    //                {
    //                    if (ds_Otherdetails.Tables[0].Rows[i]["ApplicantID*"].ToString().Trim() == ds_Otherdetails.Tables[0].Rows[k]["ApplicantID*"].ToString().Trim())
    //                    {
    //                        if (i != k)
    //                        {
    //                            errormsg = "ApplicantID is repeated in Excel Sheet";
    //                            filestatus = false;
    //                            rowno = i + 2;
    //                            columnno = "ApplicantID*";
    //                        }
    //                    }

    //                }
    //                if (ds_Otherdetails.Tables[0].Rows[i]["ApplicantID*"].ToString().Trim() != ds.Tables[0].Rows[i]["ApplicantID*"].ToString().Trim())
    //                {
    //                    errormsg = "Enter Correct Applicant Id";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = "ApplicantID*";

    //                }

    //            }
    //            else
    //            {
    //            }

    //            if (filestatus == false)
    //            {
    //                DataRow newrow = dtfail_empod.NewRow();
    //                newrow["S.NO"] = dtfail_empod.Rows.Count + 1;


    //                newrow["ROWNO"] = rowno;
    //                newrow["COLUMNS NAMES"] = columnno;
    //                dtfail_empod.Rows.Add(newrow);
    //                ds_Otherdetails.Tables[0].Rows[i]["Error Message"] = errormsg;
    //            }

    //        }




    //        //@@@@@@@@@emp_physicaldetails

    //        for (int i = 0; i < ds_physicaldetails.Tables[0].Rows.Count; i++)
    //        {
    //            errormsg = string.Empty;
    //            columnno = string.Empty;
    //            if (ds_physicaldetails.Tables[0].Rows[i]["ApplicantID*"].ToString().Trim() != "")
    //            {
    //                for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
    //                {
    //                    if (ds_physicaldetails.Tables[0].Rows[i]["ApplicantID*"].ToString().Trim() == ds_physicaldetails.Tables[0].Rows[k]["ApplicantID*"].ToString().Trim())
    //                    {
    //                        if (i != k)
    //                        {
    //                            errormsg = "ApplicantID is repeated in Excel Sheet";
    //                            filestatus = false;
    //                            rowno = i + 2;
    //                            columnno = "ApplicantID*";
    //                        }
    //                    }
    //                }
    //                if (ds_physicaldetails.Tables[0].Rows[i]["ApplicantID*"].ToString().Trim() != ds.Tables[0].Rows[i]["ApplicantID*"].ToString().Trim())
    //                {
    //                    errormsg = "Enter Correct Applicant Id";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = "ApplicantID*";

    //                }
    //            }
    //            else
    //            {
    //            }
    //            if (ds_physicaldetails.Tables[0].Rows[i]["Mobile No"].ToString().Trim() != "")
    //            {
    //                string mobile;
    //                mobile = ds_physicaldetails.Tables[0].Rows[i]["Mobile No"].ToString().Trim();
    //                bool isint = IsInteger(mobile);
    //                if (isint == false)
    //                {
    //                    errormsg = errormsg + "," + "Mobile number should be in digits";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = "Mobile No";
    //                }

    //            }
    //            if (ds_physicaldetails.Tables[0].Rows[i]["LandLine No"].ToString().Trim() != "")
    //            {
    //                string land;
    //                land = ds_physicaldetails.Tables[0].Rows[i]["LandLine No"].ToString().Trim();
    //                bool isint = IsInteger(land);
    //                if (isint == false)
    //                {
    //                    errormsg = errormsg + "," + "landline number should be in digits";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = "LandLine No";
    //                }

    //            }

    //            if (filestatus == false)
    //            {
    //                DataRow newrow = dtfail_emphy.NewRow();
    //                newrow["S.NO"] = dtfail_emphy.Rows.Count + 1;


    //                newrow["ROWNO"] = rowno;
    //                newrow["COLUMNS NAMES"] = columnno;
    //                dtfail_emphy.Rows.Add(newrow);
    //                ds_physicaldetails.Tables[0].Rows[i]["Error Message"] = errormsg;
    //            }

    //        }


    //        if (dtfail.Rows.Count > 0 || dtfail_family.Rows.Count > 0 || dtfail_weeklyoff.Rows.Count > 0 || dtfail_empod.Rows.Count > 0 || dtfail_emphy.Rows.Count > 0)
    //        {
    //            Session["dt_fail"] = dtfail;
    //            Session["ds_data"] = ds;
    //            Session["dt_fail_FAM"] = dtfail_family;
    //            Session["ds_data_fam"] = ds_Family;
    //            Session["dt_fail_weof"] = dtfail_weeklyoff;
    //            Session["ds_data_weof"] = ds_weeklyOff;
    //            Session["dt_fail_od"] = dtfail_empod;
    //            Session["ds_data_od"] = ds_Otherdetails;

    //            Session["dt_fail_phd"] = dtfail_emphy;
    //            Session["ds_data_phd"] = ds_physicaldetails;
    //            Delete_Excel_File();
    //            //LinkButton lnk_Import_process = (LinkButton)RadPanelBar1.FindItemByValue("AddAttachment").FindControl("lnk_Import_process");
    //            Telerik.Web.UI.RadWindow newwindow = new Telerik.Web.UI.RadWindow();
    //            // RWM_POSTREPLY.Windows.Remove(newwindow);
    //            newwindow.ID = "RadWindow_import";

    //            newwindow.NavigateUrl = "~/HR/Employeerror.aspx";
    //            newwindow.Title = "Import Process";
    //            newwindow.Width = 1150;
    //            newwindow.Height = 580;
    //            newwindow.VisibleOnPageLoad = true;
    //            if (RWM_POSTREPLY1.Windows.Count > 1)
    //            {
    //                RWM_POSTREPLY1.Windows.RemoveAt(1);
    //            }
    //            RWM_POSTREPLY1.Windows.Add(newwindow);



    //            RWM_POSTREPLY1.Visible = true;
    //            return;

    //        }
    //        else
    //        {
    //            bool status = false;
    //            ds.Tables[0].Columns.Add("EMPLOYEEID");
    //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //            {

    //                _obj_smhr_employee = new SMHR_EMPLOYEE();


    //                for (int count = 0; count < ddl_Applicant.Items.Count; count++)
    //                {
    //                    string code = "";
    //                    code = ddl_Applicant.Items[count].Text;
    //                    bool name = code.Contains("-");
    //                    if (name)
    //                    {
    //                        int index = code.IndexOf("-");
    //                        code = code.Substring(0, index);

    //                    }
    //                    if ((ds.Tables[0].Rows[i]["ApplicantID*"].ToString().Trim()) == code.Trim())
    //                    {
    //                        Applicant_id = Convert.ToInt32(ddl_Applicant.Items[count].Value);

    //                    }





    //                }
    //                for (int count = 0; count < ddl_EmpStatus.Items.Count; count++)
    //                {
    //                    if ((ds.Tables[0].Rows[i]["Employee Type*"].ToString().Trim()) == ddl_EmpStatus.Items[count].Text)
    //                    {
    //                        emp_status = Convert.ToString(ddl_EmpStatus.Items[count].Value);

    //                    }





    //                }

    //                for (int count = 0; count < ddl_BusinessUnit.Items.Count; count++)
    //                {
    //                    if ((ds.Tables[0].Rows[i]["Business Unit*"].ToString().Trim()) == ddl_BusinessUnit.Items[count].Text)
    //                    {
    //                        bu_id = Convert.ToInt32(ddl_BusinessUnit.Items[count].Value);

    //                    }

    //                }
    //                if (bu_id != 0)
    //                {
    //                    LoadMode();
    //                    LoadCurrency();
    //                    getPosition();
    //                    // LoadDates();
    //                    LoadDepartment();
    //                    getSupervisor();
    //                    get_SupBusinessUnit();


    //                }





    //                getEmpCode();

    //                _obj_smhr_employee.EMP_EMPCODE = Convert.ToString(lbl_Code.Text.Replace("'", "''"));
    //                _obj_smhr_employee.EMP_BUSINESSUNIT_ID = bu_id;
    //                _obj_smhr_employee.EMP_APPLICANT_ID = Applicant_id;
    //                //  _obj_smhr_employee.EMP_DOJ = Convert.ToDateTime(ds.Tables[0].Rows[i]["DateOfJoin*"]);
    //                // _obj_smhr_employee.EMP_DATEOFJOIN=

    //                if (Convert.ToString(ds.Tables[0].Rows[i]["DateOfJoin*(dd/mm/yyyy)"]).Contains("."))
    //                {
    //                    _obj_smhr_employee.EMP_DATEOFJOIN = Convert.ToString(ds.Tables[0].Rows[i]["DateOfJoin*(dd/mm/yyyy)"]).Replace(".", "/");

    //                }
    //                else
    //                {
    //                    _obj_smhr_employee.EMP_DATEOFJOIN = Convert.ToString(ds.Tables[0].Rows[i]["DateOfJoin*(dd/mm/yyyy)"]);

    //                }
    //                if (Convert.ToString(ds.Tables[0].Rows[i]["Date of Confirm*(dd/mm/yyyy)"]).Contains("."))
    //                {
    //                    _obj_smhr_employee.EMP_DATEOFCONFORM = Convert.ToString(ds.Tables[0].Rows[i]["Date of Confirm*(dd/mm/yyyy)"]).Replace(".", "/");

    //                }
    //                else
    //                {
    //                    _obj_smhr_employee.EMP_DATEOFCONFORM = Convert.ToString(ds.Tables[0].Rows[i]["Date of Confirm*(dd/mm/yyyy)"]);

    //                }

    //                //  _obj_smhr_employee.EMP_DOC = Convert.ToDateTime(ds.Tables[0].Rows[i]["Date of Confirm*"]);
    //                // _obj_smhr_employee.EMP_RPTSTARTDATE = Convert.ToDateTime(ds.Tables[0].Rows[i]["DateOfJoin*"]);
    //                _obj_smhr_employee.EMP_rpt = Convert.ToString(ds.Tables[0].Rows[i]["DateOfJoin*(dd/mm/yyyy)"]);

    //                for (int count = 0; count < ddl_Mode.Items.Count; count++)
    //                {
    //                    if ((ds.Tables[0].Rows[i]["Payment Mode*"].ToString().Trim()) == ddl_Mode.Items[count].Text)
    //                    {
    //                        _obj_smhr_employee.EMP_PAYMENTMODE_ID = Convert.ToInt32(ddl_Mode.Items[count].Value);

    //                    }
    //                }
    //                for (int count = 0; count < ddl_Department.Items.Count; count++)
    //                {
    //                    if ((ds.Tables[0].Rows[i]["Department*"].ToString().Trim()) == ddl_Department.Items[count].Text)
    //                    {
    //                        _obj_smhr_employee.EMP_DEPARTMENT_ID = Convert.ToInt32(ddl_Department.Items[count].Value);

    //                    }
    //                }


    //                for (int count = 0; count < ddl_Designation.Items.Count; count++)
    //                {
    //                    if ((ds.Tables[0].Rows[i]["Position*"].ToString().Trim()) == ddl_Designation.Items[count].Text)
    //                    {
    //                        _obj_smhr_employee.EMP_DESIGNATION_ID = Convert.ToInt32(ddl_Designation.Items[count].Value);

    //                    }
    //                }

    //                for (int count = 0; count < ddl_EmpStatus.Items.Count; count++)
    //                {
    //                    if ((ds.Tables[0].Rows[i]["Employee Type*"].ToString().Trim()) == ddl_EmpStatus.Items[count].Text)
    //                    {
    //                        _obj_smhr_employee.EMP_EMPLOYEETYPE = Convert.ToString(ddl_EmpStatus.Items[count].Text);

    //                    }
    //                }



    //                for (int count = 0; count < ddl_Grade.Items.Count; count++)
    //                {
    //                    if ((ds.Tables[0].Rows[i]["Grade"].ToString().Trim()) == ddl_Grade.Items[count].Text)
    //                    {
    //                        _obj_smhr_employee.EMP_GRADE = Convert.ToInt32(ddl_Grade.Items[count].Value);

    //                    }
    //                }

    //                for (int count = 0; count < ddl_LeaveStructure.Items.Count; count++)
    //                {
    //                    if ((ds.Tables[0].Rows[i]["Leave Structure*"].ToString().Trim()) == ddl_LeaveStructure.Items[count].Text)
    //                    {
    //                        _obj_smhr_employee.EMP_LEAVESTRUCT_ID = Convert.ToInt32(ddl_LeaveStructure.Items[count].Value);

    //                    }
    //                }
    //                for (int count = 0; count < ddl_SalaryStructure.Items.Count; count++)
    //                {
    //                    if ((ds.Tables[0].Rows[i]["Salary Structure*"].ToString().Trim()) == ddl_SalaryStructure.Items[count].Text)
    //                    {
    //                        _obj_smhr_employee.EMP_SALALRYSTRUCT_ID = Convert.ToInt32(ddl_SalaryStructure.Items[count].Value);

    //                    }
    //                }
    //                for (int count = 0; count < ddl_Currency.Items.Count; count++)
    //                {
    //                    if ((ds.Tables[0].Rows[i]["Currency*"].ToString().Trim()) == ddl_Currency.Items[count].Text)
    //                    {
    //                        _obj_smhr_employee.EMP_PAYCURRENCY = Convert.ToInt32(ddl_Currency.Items[count].Value);


    //                    }
    //                }
    //                for (int count = 0; count < ddl_Shift.Items.Count; count++)
    //                {
    //                    if ((ds.Tables[0].Rows[i]["Shift*"].ToString().Trim()) == ddl_Shift.Items[count].Text)
    //                    {
    //                        _obj_smhr_employee.EMP_SHIFT_ID = Convert.ToInt32(ddl_Shift.Items[count].Value);

    //                    }
    //                }

    //                for (int count = 0; count < ddl_Sup_BusinessUnit.Items.Count; count++)
    //                {
    //                    if ((ds.Tables[0].Rows[i]["Supervisor Business Unit"].ToString().Trim()) == ddl_Sup_BusinessUnit.Items[count].Text)
    //                    {
    //                        Sbuid = Convert.ToInt32(ddl_Sup_BusinessUnit.Items[count].Value);
    //                        _obj_smhr_employee.EMP_SUPBUSINESSUNIT_ID = Convert.ToInt32(ddl_Sup_BusinessUnit.Items[count].Value);

    //                    }
    //                }

    //                _obj_SMHR_LoginInfo = new SMHR_LOGININFO();


    //                _obj_SMHR_LoginInfo.OPERATION = operation.Check;
    //                _obj_SMHR_LoginInfo.BUID = Sbuid;
    //                DataTable dt_getEMP = BLL.get_Sup_BusinessUnit(_obj_SMHR_LoginInfo);

    //                ddl_Supervisor.Items.Clear();
    //                ddl_Supervisor.DataSource = dt_getEMP;
    //                ddl_Supervisor.DataTextField = "EMP_NAME";
    //                ddl_Supervisor.DataValueField = "EMP_ID";
    //                ddl_Supervisor.DataBind();



    //                for (int count = 0; count < ddl_Supervisor.Items.Count; count++)
    //                {
    //                    //string code1 = "";
    //                    //code1 = ddl_Supervisor.Items[count].Text;
    //                    //bool name = code1.Contains("-");
    //                    //if (name)
    //                    //{
    //                    //    int index = code1.IndexOf("-");
    //                    //    code1 = code1.Substring(0, index);

    //                    //}
    //                    if ((ds.Tables[0].Rows[i]["Supervisor"].ToString().Trim()) == ddl_Supervisor.Items[count].Text.Trim())
    //                    {
    //                        _obj_smhr_employee.EMP_REPORTINGEMPLOYEE = Convert.ToInt32(ddl_Supervisor.Items[count].Value);

    //                    }
    //                }
    //                if ((ds.Tables[0].Rows[i]["Employee Type*"].ToString().Trim().ToUpper()) == "CONTRACT")
    //                {
    //                    _obj_smhr_employee.EMP_BASIC = Convert.ToInt32(ds.Tables[0].Rows[i]["Gross Salary*"]);
    //                }
    //                else
    //                {
    //                    //code for getting Basic percentage of Gross For the businessunit selected
    //                    _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
    //                    _obj_smhr_businessunit.OPERATION = operation.Select;
    //                    _obj_smhr_businessunit.BUSINESSUNIT_ID = bu_id;
    //                    _obj_smhr_businessunit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                    DataTable dt_BusinessUnit = BLL.get_BusinessUnit(_obj_smhr_businessunit);

    //                    float IBasicPercent = Convert.ToSingle(dt_BusinessUnit.Rows[0]["BUSINESSUNIT_BASICPERCENT"]);

    //                    float emp_GrossSal = Convert.ToSingle(Convert.ToInt32(ds.Tables[0].Rows[i]["Gross Salary*"]));
    //                    //float emp_BasicSal = (55 * emp_GrossSal) / 100;
    //                    float emp_BasicSal = (IBasicPercent * emp_GrossSal) / 100;
    //                    _obj_smhr_employee.EMP_BASIC = emp_BasicSal;
    //                }



    //                //_obj_smhr_employee.EMP_PROBATIONDATE = Convert.ToDateTime(ds.Tables[0].Rows[i]["Probation Date"]);
    //                _obj_smhr_employee.EMP_PROBDATE = ds.Tables[0].Rows[i]["Probation Date(dd/mm/yyyy)"].ToString().Trim();
    //                // _obj_smhr_employee.EMP_DATEOFLASTPROMOTION = Convert.ToDateTime(ds.Tables[0].Rows[i]["Previous Promotion"]);
    //                _obj_smhr_employee.EMP_DATEOLP = ds.Tables[0].Rows[i]["Previous Promotion(dd/mm/yyyy)"].ToString().Trim();
    //                _obj_smhr_employee.EMP_NOTICEPERIOD = Convert.ToInt32(ds.Tables[0].Rows[i]["Notification Period"]);
    //                // _obj_smhr_employee.EMP_CONTRACT_DATE = Convert.ToDateTime(ds.Tables[0].Rows[i]["Contract Date*"]);
    //                _obj_smhr_employee.EMP_CONTRDATE = ds.Tables[0].Rows[i]["Contract Date*(dd/mm/yyyy)"].ToString().Trim();
    //                _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);


    //                _obj_smhr_employee.EMP_HOBBIES = ds.Tables[0].Rows[i]["Hobbies"].ToString();
    //                if (ds.Tables[0].Rows[i]["Is VariablePay"].ToString().Trim().ToUpper() == "TRUE")
    //                {
    //                    DataTable dt_isvariablepay = BLL.get_Organisation_Isvp(Convert.ToString(Session["ORG_ID"]), Convert.ToString(bu_id));
    //                    if (Convert.ToString(dt_isvariablepay.Rows[0]["BUSINESSUNIT_ISVARIABLEAMOUNT"]) == "True")// 1 MEANS THAT ORGANISATION IS HAVING VARIABLE PAY
    //                    {
    //                        _obj_smhr_employee.EMP_ISVARIABLEPAY = true;
    //                        _obj_smhr_employee.EMP_VPPAYABLECOUNT = Convert.ToInt32(Math.Round(Convert.ToDouble(Convert.ToInt32(ds.Tables[0].Rows[i]["No Of Times Payable"])), 0));
    //                        _obj_smhr_employee.EMP_VARIABLEAMT = Convert.ToInt32(Math.Round(Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i]["Variable Amount"])), 0));
    //                    }
    //                }
    //                else
    //                {
    //                    _obj_smhr_employee.EMP_ISVARIABLEPAY = false;
    //                    _obj_smhr_employee.EMP_VARIABLEAMT = 0;
    //                    _obj_smhr_employee.EMP_VPPAYABLECOUNT = 0;
    //                }
    //                _obj_smhr_employee.EMP_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
    //                _obj_smhr_employee.EMP_CREATEDDATE = DateTime.Now;
    //                _obj_smhr_employee.EMP_EMPLOYEE_STATUS = Convert.ToInt32(ddl_Employee_Status.SelectedValue);
    //                _obj_smhr_employee.OPERATION = operation.Insert1;


    //                status = BLL.set_Employee(_obj_smhr_employee);

    //                _obj_smhr_employee.OPERATION = operation.Check;
    //                DataTable dt_empid = BLL.get_Employee(_obj_smhr_employee);
    //                int EMPID = Convert.ToInt32(dt_empid.Rows[0]["EMP_ID"]);

    //                ds.Tables[0].Rows[i]["EMPLOYEEID"] = EMPID;

    //            }
    //            // @@@@@@@@@@@@@@@emp_familydetails

    //            for (int i = 0; i < ds_Family.Tables[0].Rows.Count; i++)
    //            {
    //                int empl_id = 0;
    //                if (ds_Family.Tables[0].Rows[i]["ApplicantID*"].ToString().Trim() != "")
    //                {
    //                    bool status_family = false;


    //                    for (int j = 0; j < ds_Family.Tables[0].Rows.Count; j++)
    //                    {
    //                        if (ds_Family.Tables[0].Rows[i]["ApplicantID*"].ToString().Trim() == ds.Tables[0].Rows[j]["ApplicantID*"].ToString().Trim())
    //                        {
    //                            status_family = true;
    //                            empl_id = Convert.ToInt32(ds.Tables[0].Rows[j]["EMPLOYEEID"]);

    //                            break;

    //                        }

    //                    }
    //                    if (status_family == true)
    //                    {

    //                        bool status1 = false;
    //                        _obj_smhr_employee = new SMHR_EMPLOYEE();
    //                        _obj_smhr_employee.OPERATION = operation.Check_New;
    //                        _obj_smhr_employee.EMPFMDTL_EMP_ID = empl_id;
    //                        DataTable dt_serialno = BLL.get_EmployeeFamily(_obj_smhr_employee);
    //                        //int serno =( Convert.ToInt32(dt_serialno.Rows[0]["APPCONT_SERIAL"]))+1;
    //                        _obj_smhr_employee.EMPFMDTL_SERIAL = (Convert.ToInt32(dt_serialno.Rows[0]["EMPFMDTL_SERIAL"])) + 1;

    //                        //_obj_smhr_employee.EMPFMDTL_SERIAL = i+1;
    //                        for (int c = 0; c < ddl_Relationship.Items.Count; c++)
    //                        {
    //                            if ((ds_Family.Tables[0].Rows[i]["Relationship*"].ToString().Trim()) == ddl_Relationship.Items[c].Text)
    //                            {
    //                                _obj_smhr_employee.EMPFMDTL_EMPREL_ID = Convert.ToInt32(ddl_Relationship.Items[c].Value);

    //                            }

    //                        }



    //                        _obj_smhr_employee.EMPFMDTL_NAME = ds_Family.Tables[0].Rows[i]["Name*"].ToString().Trim();
    //                        //  _obj_smhr_employee.EMPFMDTL_RELDOB = Convert.ToDateTime(ds_Family.Tables[0].Rows[i]["Date of Birth"]);
    //                        _obj_smhr_employee.EMFM_RELDOB = ds_Family.Tables[0].Rows[i]["Date of Birth(dd/mm/yyyy)*"].ToString().Trim();
    //                        if (ds_Family.Tables[0].Rows[i]["Is Dependant"].ToString().Trim() != "")
    //                            _obj_smhr_employee.EMPFMDTL_RELDEPENDENT = Convert.ToBoolean(ds_Family.Tables[0].Rows[i]["Is Dependant"]);
    //                        else
    //                            _obj_smhr_employee.EMPFMDTL_RELDEPENDENT = false;
    //                        if (ds_Family.Tables[0].Rows[i]["Emergency Contact"].ToString().Trim() != "")
    //                            _obj_smhr_employee.EMPFMDTL_EMERGENCYCONTACT = Convert.ToBoolean(ds_Family.Tables[0].Rows[i]["Emergency Contact"]);
    //                        else
    //                            _obj_smhr_employee.EMPFMDTL_EMERGENCYCONTACT = false;
    //                        if (ds_Family.Tables[0].Rows[i]["Next to Kin"].ToString().Trim() != "")
    //                            _obj_smhr_employee.EMPFMDTL_ISNEXTTOKIN = Convert.ToBoolean(ds_Family.Tables[0].Rows[i]["Next to Kin"]);
    //                        else
    //                            _obj_smhr_employee.EMPFMDTL_ISNEXTTOKIN = false;
    //                        _obj_smhr_employee.EMPFMDTL_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
    //                        _obj_smhr_employee.EMPFMDTL_CREATEDDATE = DateTime.Now;
    //                        _obj_smhr_employee.EMPFMDTL_ANNUALINCOME = Convert.ToDouble(ds_Family.Tables[0].Rows[i]["Annual Income"]);
    //                        _obj_smhr_employee.EMPFMDTL_OCCUPATION = Convert.ToString(ds_Family.Tables[0].Rows[i]["Occupation"]);
    //                        status1 = BLL.set_EmpFamily(_obj_smhr_employee);//no organisation column is found in this table



    //                    }

    //                }

    //            }

    //            //@@@@@@@@@@@@@employee_Weekly Off

    //            for (int i = 0; i < ds_weeklyOff.Tables[0].Rows.Count; i++)
    //            {
    //                int empl_id1 = 0;
    //                if (ds_weeklyOff.Tables[0].Rows[i]["ApplicantID*"].ToString().Trim() != "")
    //                {
    //                    bool status_weoff = false;


    //                    for (int j = 0; j < ds_weeklyOff.Tables[0].Rows.Count; j++)
    //                    {
    //                        if (ds_weeklyOff.Tables[0].Rows[i]["ApplicantID*"].ToString().Trim() == ds.Tables[0].Rows[j]["ApplicantID*"].ToString().Trim())
    //                        {
    //                            status_weoff = true;
    //                            empl_id1 = Convert.ToInt32(ds.Tables[0].Rows[j]["EMPLOYEEID"]);

    //                            break;

    //                        }

    //                    }
    //                    if (status_weoff == true)
    //                    {
    //                        _obj_smhr_weeklyoff = new SMHR_EMPLOYEEWEEKLYOFF();
    //                        _obj_smhr_weeklyoff.OPERATION = operation.Select;
    //                        _obj_smhr_weeklyoff.EMPWOFF_EMP_ID = empl_id1;
    //                        DataTable dt_wof = BLL.get_EmpWeekOff(_obj_smhr_weeklyoff);
    //                        if (dt_wof.Rows.Count == 0)
    //                        {
    //                            _obj_smhr_weeklyoff = new SMHR_EMPLOYEEWEEKLYOFF();
    //                            _obj_smhr_weeklyoff.OPERATION = operation.Insert1;
    //                            _obj_smhr_weeklyoff.EMPWOFF_EMP_ID = empl_id1;
    //                            if (ds_weeklyOff.Tables[0].Rows[i]["Effective Date*(dd/mm/yyyy)"].ToString().Trim() != null)
    //                                _obj_smhr_weeklyoff.EMPWOFFEFDATE = ds_weeklyOff.Tables[0].Rows[i]["Effective Date*(dd/mm/yyyy)"].ToString();
    //                            else
    //                                _obj_smhr_weeklyoff.EMPWOFFEFDATE = null;
    //                            if (ds_weeklyOff.Tables[0].Rows[i]["Monday"].ToString().Trim() == "TRUE")
    //                                _obj_smhr_weeklyoff.EMPWOFF_MON = true;
    //                            else
    //                                _obj_smhr_weeklyoff.EMPWOFF_MON = false;
    //                            if (ds_weeklyOff.Tables[0].Rows[i]["Tuesday"].ToString().Trim() == "TRUE")
    //                                _obj_smhr_weeklyoff.EMPWOFF_TUE = true;
    //                            else
    //                                _obj_smhr_weeklyoff.EMPWOFF_TUE = false;
    //                            if (ds_weeklyOff.Tables[0].Rows[i]["Wednesday"].ToString().Trim() == "TRUE")
    //                                _obj_smhr_weeklyoff.EMPWOFF_WED = true;
    //                            else
    //                                _obj_smhr_weeklyoff.EMPWOFF_WED = false;
    //                            if (ds_weeklyOff.Tables[0].Rows[i]["Thursday"].ToString().Trim() == "TRUE")
    //                                _obj_smhr_weeklyoff.EMPWOFF_THU = true;
    //                            else
    //                                _obj_smhr_weeklyoff.EMPWOFF_THU = false;
    //                            if (ds_weeklyOff.Tables[0].Rows[i]["Friday"].ToString().Trim() == "TRUE")
    //                                _obj_smhr_weeklyoff.EMPWOFF_FRI = true;
    //                            else
    //                                _obj_smhr_weeklyoff.EMPWOFF_FRI = false;
    //                            if (ds_weeklyOff.Tables[0].Rows[i]["Saturday"].ToString().Trim() == "TRUE")
    //                                _obj_smhr_weeklyoff.EMPWOFF_SAT = true;
    //                            else
    //                                _obj_smhr_weeklyoff.EMPWOFF_SAT = false;
    //                            if (ds_weeklyOff.Tables[0].Rows[i]["Sunday"].ToString().Trim() == "TRUE")
    //                                _obj_smhr_weeklyoff.EMPWOFF_SUN = true;
    //                            else
    //                                _obj_smhr_weeklyoff.EMPWOFF_SUN = false;
    //                            _obj_smhr_weeklyoff.EMPWOFF_CREATEDBY = Convert.ToInt32(Convert.ToString(Session["USER_ID"]));
    //                            _obj_smhr_weeklyoff.EMPWOFF_CREATEDDATE = DateTime.Now;
    //                            bool status2 = BLL.set_EmpWeekOff(_obj_smhr_weeklyoff);
    //                        }
    //                        else
    //                        {
    //                        }
    //                    }
    //                }
    //            }

    //            //@@@@@@@@@EMPLOYEE OTHERDETAILS

    //            for (int i = 0; i < ds_Otherdetails.Tables[0].Rows.Count; i++)
    //            {
    //                int empl_id2 = 0;
    //                if (ds_Otherdetails.Tables[0].Rows[i]["ApplicantID*"].ToString().Trim() != "")
    //                {
    //                    bool status_empodt = false;


    //                    for (int j = 0; j < ds_Otherdetails.Tables[0].Rows.Count; j++)
    //                    {
    //                        if (ds_Otherdetails.Tables[0].Rows[i]["ApplicantID*"].ToString().Trim() == ds.Tables[0].Rows[j]["ApplicantID*"].ToString().Trim())
    //                        {
    //                            status_empodt = true;
    //                            empl_id2 = Convert.ToInt32(ds.Tables[0].Rows[j]["EMPLOYEEID"]);

    //                            break;

    //                        }

    //                    }
    //                    if (status_empodt == true)
    //                    {

    //                        _obj_SMHR_EMPOTHERDETAILS = new SMHR_EMPOTHERDETAILS();
    //                        _obj_SMHR_EMPOTHERDETAILS.OPERATION = operation.Insert;
    //                        _obj_SMHR_EMPOTHERDETAILS.EMPOTHERDTL_EMPID = empl_id2;
    //                        _obj_SMHR_EMPOTHERDETAILS.EMPOTHERDTL_IDNO = ds_Otherdetails.Tables[0].Rows[i]["PF Number"].ToString().Trim();
    //                        _obj_SMHR_EMPOTHERDETAILS.EMPOTHERDTL_PINNO = ds_Otherdetails.Tables[0].Rows[i]["PAN Number"].ToString().Trim();
    //                        _obj_SMHR_EMPOTHERDETAILS.EMPOTHERDTL_NSSFNO = ds_Otherdetails.Tables[0].Rows[i]["ESI Number"].ToString().Trim();
    //                        _obj_SMHR_EMPOTHERDETAILS.EMPOTHERDTL_NHIFNO = ds_Otherdetails.Tables[0].Rows[i]["Gratuity Number"].ToString().Trim();
    //                        _obj_SMHR_EMPOTHERDETAILS.EMPOTHERDTL_TAXRELIEFAMOUNT = string.Empty;
    //                        _obj_SMHR_EMPOTHERDETAILS.EMPOTHERDTL_NNAKNO = string.Empty;
    //                        _obj_SMHR_EMPOTHERDETAILS.EMPOTHERDTL_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
    //                        _obj_SMHR_EMPOTHERDETAILS.EMPOTHERDTL_CREATEDDATE = DateTime.Now;
    //                        BLL.set_SMHR_EMPOTHERDETAILS(_obj_SMHR_EMPOTHERDETAILS);
    //                    }



    //                }
    //            }



    //            for (int i = 0; i < ds_physicaldetails.Tables[0].Rows.Count; i++)
    //            {
    //                int empl_id3 = 0;
    //                if (ds_physicaldetails.Tables[0].Rows[i]["ApplicantID*"].ToString().Trim() != "")
    //                {
    //                    bool status_empodt = false;


    //                    for (int j = 0; j < ds_physicaldetails.Tables[0].Rows.Count; j++)
    //                    {
    //                        if (ds_physicaldetails.Tables[0].Rows[i]["ApplicantID*"].ToString().Trim() == ds.Tables[0].Rows[j]["ApplicantID*"].ToString().Trim())
    //                        {
    //                            status_empodt = true;
    //                            empl_id3 = Convert.ToInt32(ds.Tables[0].Rows[j]["EMPLOYEEID"]);

    //                            break;

    //                        }

    //                    }
    //                    if (status_empodt == true)
    //                    {
    //                        _obj_smhr_employee.OPERATION = operation.Insert1;
    //                        _obj_smhr_employee.EMP_MOBILENO = ds_physicaldetails.Tables[0].Rows[i]["Mobile No"].ToString().Trim().Replace("'", "''");
    //                        _obj_smhr_employee.EMP_LANDLINENO = ds_physicaldetails.Tables[0].Rows[i]["Mobile No"].ToString().Trim().Replace("'", "''");
    //                        _obj_smhr_employee.EMP_EMAILID = ds_physicaldetails.Tables[0].Rows[i]["Mobile No"].ToString().Trim().Replace("'", "''");
    //                        _obj_smhr_employee.EMP_ID = Convert.ToInt32(ds_physicaldetails.Tables[0].Rows[i]["Mobile No"]);

    //                        BLL.set_EMP_NEWCONTACTS(_obj_smhr_employee);




    //                        //Physical Details
    //                        _obj_SMHR_EMPPHYSICALDETAILS = new SMHR_EMP_PHYSICALDETAILS();

    //                        _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_EMPID = empl_id3;

    //                        DataTable dt_getPhysicalDetails = BLL.get_PhysicalDetails(_obj_SMHR_EMPPHYSICALDETAILS);
    //                        if (dt_getPhysicalDetails.Rows.Count == 0)
    //                        {

    //                            _obj_SMHR_EMPPHYSICALDETAILS.OPERATION = operation.Insert_New;

    //                            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_EMPID = empl_id3;
    //                            if (ds_physicaldetails.Tables[0].Rows[i]["Height(cms)"].ToString().Trim() == "")
    //                            {
    //                                _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_HEIGHT = 0.00;
    //                            }
    //                            else
    //                            {
    //                                _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_HEIGHT = Convert.ToDouble(ds_physicaldetails.Tables[0].Rows[i]["Height(cms)"]);
    //                            }

    //                            if (ds_physicaldetails.Tables[0].Rows[i]["Weight(Kgs)"] == "")
    //                            {
    //                                _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_WEIGHT = 0.00;
    //                            }
    //                            else
    //                            {
    //                                _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_WEIGHT = Convert.ToDouble(ds_physicaldetails.Tables[0].Rows[i]["Weight(Kgs)"]);
    //                            }

    //                            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_COLOR = ds_physicaldetails.Tables[0].Rows[i]["Skin Color"].ToString().Replace("'", "''");
    //                            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_IDENTIFICATION = ds_physicaldetails.Tables[0].Rows[i]["Mole Identification Or Other Marks"].ToString().Trim().Replace("'", "''");
    //                            //_obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_BLOODGROUP = Convert.ToString(rtxt_BGroup.Text.Replace("'", "''"));
    //                            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_EYEPOWER = ds_physicaldetails.Tables[0].Rows[i]["Eye Power"].ToString().Replace("'", "''");

    //                            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_HANDICAP = Convert.ToBoolean(ds_physicaldetails.Tables[0].Rows[i]["Is Handicapped?"]);


    //                            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_HANDICAP_YES = ds_physicaldetails.Tables[0].Rows[i]["Details"].ToString().Replace("'", "''");
    //                            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_PHYSICALTREATMENT = ds_physicaldetails.Tables[0].Rows[i]["(physical)Treatment Name"].ToString();
    //                            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_PHYSICALHOSPITAL = ds_physicaldetails.Tables[0].Rows[i]["Hospital Name"].ToString().Replace("'", "''");
    //                            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_PHYSICALDURATION = ds_physicaldetails.Tables[0].Rows[i]["Treatment Duration(days)"].ToString().Replace("'", "''");
    //                            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_PHYSICALSTATUS = ds_physicaldetails.Tables[0].Rows[i]["Current Illness Status"].ToString().Replace("'", "''");
    //                            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_MENTALTREATMENT = ds_physicaldetails.Tables[0].Rows[i]["(Mental)Treatment Name"].ToString().Replace("'", "''");
    //                            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_MENTALHOSPITAL = ds_physicaldetails.Tables[0].Rows[i]["Hospital Name"].ToString().Replace("'", "''");
    //                            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_MENTALDURATION = ds_physicaldetails.Tables[0].Rows[i]["Treatment Duration(days)"].ToString().Replace("'", "''");
    //                            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_MENTALSTATUS = ds_physicaldetails.Tables[0].Rows[i]["Current Illness Status"].ToString().Replace("'", "''");
    //                            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
    //                            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_CREATEDDATE = DateTime.Now;


    //                            BLL.set_PhysicalDetails(_obj_SMHR_EMPPHYSICALDETAILS);


    //                        }
    //                    }

    //                }
    //            }


    //            BLL.ShowMessage(this, "Successfully processed Excel file.");
    //            LoadData();
    //            RG_Employee.DataBind();



    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;

    //    }

    //}


    public bool IsInteger(string data)
    {
        bool result = true;

        try
        {
            int.Parse(data);
        }
        catch (FormatException)
        {
            result = false;
        }

        return result;
    }
    private void getEmpCode()
    {
        try
        {
            string code = string.Empty;
            string str = string.Empty;
            string Series = string.Empty;
            string strCode = string.Empty;
            _obj_smhr_employee = new SMHR_EMPLOYEE();
            _obj_smhr_employee.OPERATION = operation.Update;
            _obj_smhr_employee.APP_EMP_STATUS = emp_status;
            _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_Employee(_obj_smhr_employee);
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
                _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
                _obj_smhr_businessunit.BUSINESSUNIT_ID = bu_id;
                _obj_smhr_businessunit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_BU = BLL.get_BusinessUnit(_obj_smhr_businessunit);

                if (emp_status == "Permanent")
                {
                    _obj_smhr_globalconfig = new SMHR_GLOBALCONFIG();
                    _obj_smhr_globalconfig.OPERATION = operation.Select;
                    _obj_smhr_globalconfig.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dt = BLL.get_ConfigDetails(_obj_smhr_globalconfig);
                    if (dt.Rows.Count != 0)
                    {
                        strCode = dt.Rows[0][7].ToString().Trim();
                    }
                    lbl_Code.Text = "P-" + Convert.ToString(strCode) + Convert.ToString(Series) + Convert.ToString(str);
                }
                else
                {
                    if (dt_BU.Rows.Count != 0)
                    {
                        if (dt_BU.Rows[0]["BUSINESSUNIT_EMPCODE"] != "" || dt_BU.Rows[0]["BUSINESSUNIT_EMPCODE"] != DBNull.Value)
                        {
                            lbl_Code.Text = "T-" + Convert.ToString(strCode) + Convert.ToString(Series) + Convert.ToString(str);
                        }
                        else
                        {
                            if (emp_status == "Contract")
                            {
                                lbl_Code.Text = "C-" + Convert.ToString(strCode) + Convert.ToString(Series) + Convert.ToString(str);
                            }
                            else
                            {
                                lbl_Code.Text = "T-" + Convert.ToString(strCode) + Convert.ToString(Series) + Convert.ToString(str);
                            }
                        }
                    }
                    else
                    {
                        if (emp_status == "Contract")
                        {
                            lbl_Code.Text = "C-" + Convert.ToString(Series) + Convert.ToString(str);
                        }
                        else
                        {
                            lbl_Code.Text = "T-" + Convert.ToString(Series) + Convert.ToString(str);
                        }
                    }
                }


            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployee", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    private void getSupervisor()
    {
        try
        {

            ddl_Supervisor.Items.Clear();
            _obj_smhr_employee = new SMHR_EMPLOYEE();
            _obj_smhr_employee.OPERATION = operation.Check;
            _obj_smhr_employee.EMP_BUSINESSUNIT_ID = bu_id;
            _obj_smhr_employee.EMP_ID = 0;
            DataTable dtDetails = BLL.get_Supervisor(_obj_smhr_employee);
            _obj_smhr_employee.OPERATION = operation.Empty;
            DataTable dt_BU = BLL.get_DefaultSupervisor(_obj_smhr_employee);
            string def_Supervisor = Convert.ToString(dt_BU.Rows[0]["BUSINESSUNIT_SUPERVISOR"]);
            ddl_Supervisor.DataSource = dtDetails;
            ddl_Supervisor.DataTextField = "EMP_EMPCODE";
            ddl_Supervisor.DataValueField = "EMP_ID";
            ddl_Supervisor.DataBind();

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployee", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


    }


    private void get_SupBusinessUnit()
    {
        try
        {
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.OPERATION = operation.Validate1;
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.BUID = bu_id;
            DataTable dt_BusinessUnit = BLL.get_Sup_BusinessUnit(_obj_SMHR_LoginInfo);
            if (dt_BusinessUnit.Rows.Count != 0)
            {
                ddl_Sup_BusinessUnit.DataSource = dt_BusinessUnit;
                ddl_Sup_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
                ddl_Sup_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
                ddl_Sup_BusinessUnit.DataBind();
                //  ddl_Sup_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployee", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadDepartment()
    {
        try
        {
            _obj_Department = new SMHR_DEPARTMENT();
            _obj_Department.MODE = 7;
            _obj_Department.BUID = bu_id;
            DataTable dt = BLL.get_Department(_obj_Department);
            ddl_Department.DataSource = dt;
            ddl_Department.DataTextField = "DEPARTMENT_NAME";
            ddl_Department.DataValueField = "DEPARTMENT_ID";
            ddl_Department.DataBind();
            // ddl_Department.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployee", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }



    }

    private void getPosition()
    {
        try
        {
            // if (ddl_BusinessUnit.SelectedIndex != 0)
            // {
            // added by joseph on 2009-11-21
            ddl_Designation.Items.Clear();
            SMHR_POSITIONS _obj_smhr_positions = new SMHR_POSITIONS();
            _obj_smhr_positions.OPERATION = operation.Select;
            _obj_smhr_positions.JOBLOC_BUSINESSUNIT_ID = bu_id;
            _obj_smhr_positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtPos = BLL.get_BUPositions(_obj_smhr_positions);
            ddl_Designation.DataSource = dtPos;
            ddl_Designation.DataTextField = "POSITIONS_CODE";
            ddl_Designation.DataValueField = "POSITIONS_ID";
            ddl_Designation.DataBind();
            // ddl_Designation.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            //
            // }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployee", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadMode()
    {
        try
        {

            //Payment Modes
            _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
            _obj_smhr_businessunit.OPERATION = operation.Empty;
            _obj_smhr_businessunit.BUSINESSUNIT_ID = bu_id;
            _obj_smhr_businessunit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_BusinessUnit(_obj_smhr_businessunit);
            ddl_Mode.DataSource = dt;
            ddl_Mode.DataTextField = "HR_MASTER_CODE";
            ddl_Mode.DataValueField = "HR_MASTER_ID";
            ddl_Mode.DataBind();
            ddl_Mode.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployee", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadCurrency()
    {
        try
        {
            _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
            _obj_smhr_businessunit.OPERATION = operation.EMPTY1;
            _obj_smhr_businessunit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_businessunit.BUSINESSUNIT_ID = bu_id;
            DataTable dt = BLL.get_BusinessUnit(_obj_smhr_businessunit);
            //if (dt.Rows.Count != 0)
            //{
            //    ddl_Currency.SelectedIndex = ddl_Currency.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["BUSINESSUNIT_CURRENCY_ID"]));
            //}
            //else
            //{
            //    ddl_Currency.SelectedIndex = 0;
            //}

            //CHANGE BY PRADEEP
            if (dt.Rows.Count != 0)
            {

                ddl_Currency.DataSource = dt;
                ddl_Currency.DataTextField = "CURR_CODE";
                ddl_Currency.DataValueField = "BUSINESSUNIT_CURRENCY_ID";
                ddl_Currency.DataBind();
                ddl_Currency.Items.Insert(0, new RadComboBoxItem("Select"));
                //ddl_Currency.SelectedIndex = ddl_Currency.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["BUSINESSUNIT_CURRENCY_ID"]));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployee", ex.StackTrace, DateTime.Now);
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

                SMHR_GLOBALCONFIG _obj_smhr_globalconfig = new SMHR_GLOBALCONFIG();
                _obj_smhr_globalconfig.OPERATION = operation.Select;
                _obj_smhr_globalconfig.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt = BLL.get_ConfigDetails(_obj_smhr_globalconfig);
                aplicantcode = dt.Rows[0][8].ToString().Trim() + Convert.ToString(Series) + Convert.ToString(str);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployee", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    //private void saveQualification()
    //{
    //    _obj_smhr_applicant = new SMHR_APPLICANT();
    //    dt_Qual = (DataTable)ViewState["dt_Qual"];
    //    foreach (DataRow row in dt_Qual.Rows)
    //    {
    //        bool status = false;
    //        _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(_lbl_App_ID);
    //        _obj_smhr_applicant.APPQFN_QUALIFICATION_ID = Convert.ToInt32(Convert.ToString(row[1]));
    //        _obj_smhr_applicant.APPQFN_INSTITUTE = Convert.ToString(row[3]);
    //        _obj_smhr_applicant.APPQFN_PASSEDYEAR = Convert.ToInt32(Convert.ToString(row[4]));
    //        _obj_smhr_applicant.APPQFN_PERCENTAGE = Convert.ToDouble(Convert.ToString(row[5]));
    //        _obj_smhr_applicant.APPQFN_GRADE = Convert.ToString(row[6]);
    //        _obj_smhr_applicant.APPQFN_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
    //        _obj_smhr_applicant.APPQFN_CREATEDDATE = DateTime.Now;
    //        _obj_smhr_applicant.OPERATION = operation.Insert;
    //        status = BLL.set_AppQualification(_obj_smhr_applicant);
    //    }
    //}


    //protected void Btn_Imp_directEmp_click(object sender, EventArgs e)
    //{
    //    try
    //    {


    //        Session.Remove("dt_fail1 ");
    //        Session.Remove("ds_data1");

    //        Session.Remove("dt_fail_FAM1");
    //        Session.Remove("ds_data_fam1");

    //        Session.Remove("dt_fail_weof1");
    //        Session.Remove("ds_data_weof1");

    //        Session.Remove("dt_fail_od1");
    //        Session.Remove("ds_data_od1");

    //        Session.Remove("dt_fail_phd1");
    //        Session.Remove("ds_data_phd1");

    //        // Session.Remove("dt_fail_per1");
    //        // Session.Remove("ds_data_per1");

    //        Session.Remove("DT_FAIL_QUALI1");
    //        Session.Remove("DT_DATA_QUALI1");

    //        Session.Remove("DT_FAIL_SKILLS1");
    //        Session.Remove("DT_DATA_SKILLS1");

    //        Session.Remove("DT_FAIL_EXPERIANCE1");
    //        Session.Remove("DT_DATA_EXPERIANCE1");

    //        Session.Remove("DT_FAIL_CONTACT1");
    //        Session.Remove("DT_DATA_CONTACT1");

    //        Session.Remove("DT_FAIL_LANGUAGE1");
    //        Session.Remove("DT_DATA_LANGUAGE1");





    //        string strcon = null;

    //        string strfilename1 = Up_directEmp.FileName;
    //        strfilename2 = Convert.ToString(DateTime.Now.TimeOfDay) + "_" + strfilename1;
    //        strfilename2 = strfilename2.Replace("/", "").Replace(":", ".");
    //        if (Up_directEmp.HasFile)
    //        {
    //            if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == false)
    //            {
    //                System.IO.Directory.CreateDirectory(Server.MapPath("~/IMPORT_EXCEL/"));
    //            }
    //            Up_directEmp.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/IMPORT_EXCEL/"), strfilename2));
    //            string filename1 = Server.MapPath("~/IMPORT_EXCEL/") + ("") + (Convert.ToString(strfilename2));
    //            FileInfo fileInfo = new FileInfo(filename1);
    //            if (fileInfo.Exists)
    //            {
    //                string path = MapPath(strfilename1);
    //                // string name = Path.GetFileName( path );
    //                string ext = Path.GetExtension(path);

    //                string type = string.Empty;
    //                if (ext != null)
    //                {
    //                    switch (ext.ToLower())
    //                    {

    //                        case ".xls":

    //                            type = "excel";
    //                            break;
    //                        case ".xlsx":
    //                            type = "excel";
    //                            break;

    //                        default:
    //                            type = string.Empty;
    //                            break;
    //                    }
    //                }
    //                if (type == string.Empty)
    //                {
    //                    if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == true)
    //                    {

    //                        string path1 = Server.MapPath("~/IMPORT_EXCEL/") + ("") + (Convert.ToString(strfilename2));
    //                        System.IO.File.Delete(path1);
    //                    }
    //                    BLL.ShowMessage(this, "Please select the Excel File  (Eg: Excel.xlsx). ");
    //                    return;
    //                }



    //            }


    //        }
    //        else
    //        {
    //            BLL.ShowMessage(this, "Please Select the File to be uploaded");
    //            return;
    //        }

    //        string strpath = Server.MapPath("~/IMPORT_EXCEL/");

    //        strpath = strpath + strfilename2;


    //        // Getting data from excell file to dataset.
    //        strcon = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source='" + strpath + "';" + "Extended Properties=Excel 12.0;";


    //        OleDbConnection objConn = null;
    //        objConn = new OleDbConnection(strcon);
    //        objConn.Open();

    //        DataTable dt_chk2 = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
    //        string sheetname;
    //        if (dt_chk2 == null)
    //        {
    //            objConn.Close();
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        else
    //        {
    //            sheetname = Convert.ToString(dt_chk2.Rows[7]["TABLE_NAME"]);// personal details
    //        }
    //        OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM  [" + sheetname + "]", strcon);



    //        da.Fill(ds_directemp);
    //        ds_directemp.Tables[0].Columns.Add("Error Message");

    //        objConn.Close();
    //        DataTable dt = new DataTable();
    //        DataTable dtfail_DirectEmp = new DataTable();

    //        string errormsg = string.Empty;



    //        string projecttype = null;
    //        Int32 rowno = 0;

    //        DateTime dat;
    //        string columnno = null;
    //        string projname = null;
    //        Boolean filestatus = true;
    //        dtfail_DirectEmp.Columns.Add("S.NO", typeof(Int32));
    //        dtfail_DirectEmp.Columns.Add("ROWNO", typeof(Int32));
    //        dtfail_DirectEmp.Columns.Add("COLUMNS NAMES", typeof(string));

    //        if (ds_directemp.Tables[0].Columns[0].ToString().Trim() == "Applicant SNO*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }

    //        if (ds_directemp.Tables[0].Columns[1].ToString().Trim() == "Title*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_directemp.Tables[0].Columns[2].ToString().Trim() == "First Name*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_directemp.Tables[0].Columns[3].ToString().Trim() == "Middle Name")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_directemp.Tables[0].Columns[4].ToString().Trim() == "Last Name")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_directemp.Tables[0].Columns[5].ToString().Trim() == "Date of Birth*(DD/MM/YYYY)")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_directemp.Tables[0].Columns[6].ToString().Trim() == "Gender*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_directemp.Tables[0].Columns[7].ToString().Trim() == "Blood Group*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_directemp.Tables[0].Columns[8].ToString().Trim() == "Religion*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_directemp.Tables[0].Columns[9].ToString().Trim() == "Nationality*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_directemp.Tables[0].Columns[10].ToString().Trim() == "Status*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_directemp.Tables[0].Columns[11].ToString().Trim() == "Marital Status")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_directemp.Tables[0].Columns[12].ToString().Trim() == "Address*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_directemp.Tables[0].Columns[13].ToString().Trim() == "Remarks")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_directemp.Tables[0].Columns[14].ToString().Trim() == "Business Unit*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_directemp.Tables[0].Columns[15].ToString().Trim() == "DateOfJoin*(dd/mm/yyyy)")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_directemp.Tables[0].Columns[16].ToString().Trim() == "Date of Confirm*(dd/mm/yyyy)")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_directemp.Tables[0].Columns[17].ToString().Trim() == "Payment Mode*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_directemp.Tables[0].Columns[18].ToString().Trim() == "Department*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_directemp.Tables[0].Columns[19].ToString().Trim() == "Position*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_directemp.Tables[0].Columns[20].ToString().Trim() == "Employee Type*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_directemp.Tables[0].Columns[21].ToString().Trim() == "Grade")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_directemp.Tables[0].Columns[22].ToString().Trim() == "Leave Structure*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_directemp.Tables[0].Columns[23].ToString().Trim() == "Currency*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_directemp.Tables[0].Columns[24].ToString().Trim() == "Salary Structure*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_directemp.Tables[0].Columns[25].ToString().Trim() == "Shift*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_directemp.Tables[0].Columns[26].ToString().Trim() == "Supervisor Business Unit")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_directemp.Tables[0].Columns[27].ToString().Trim() == "Supervisor")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_directemp.Tables[0].Columns[28].ToString().Trim() == "Gross Salary*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_directemp.Tables[0].Columns[29].ToString().Trim() == "Probation Date(dd/mm/yyyy)")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_directemp.Tables[0].Columns[30].ToString().Trim() == "Previous Promotion(dd/mm/yyyy)")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_directemp.Tables[0].Columns[31].ToString().Trim() == "Notification Period")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_directemp.Tables[0].Columns[32].ToString().Trim() == "Is Supervisor Mandatory")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_directemp.Tables[0].Columns[33].ToString().Trim() == "Is VariablePay")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_directemp.Tables[0].Columns[34].ToString().Trim() == "No Of Times Payable")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_directemp.Tables[0].Columns[35].ToString().Trim() == "Variable Amount")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_directemp.Tables[0].Columns[36].ToString().Trim() == "Hobbies")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }

    //        if (ds_directemp.Tables[0].Columns[37].ToString().Trim() == "Contract Date*(dd/mm/yyyy)")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }

    //        if (ds_directemp.Tables[0].Columns[38].ToString().Trim() == "Employee Code (If Manual)")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }

    //        objConn = new OleDbConnection(strcon);
    //        objConn.Open();
    //        sheetname = Convert.ToString(dt_chk2.Rows[6]["TABLE_NAME"]);//Qualification Details

    //        OleDbDataAdapter da1 = new OleDbDataAdapter("SELECT * FROM  [" + sheetname + "]", strcon);
    //        da1.Fill(ds_Qualification);
    //        ds_Qualification.Tables[0].Columns.Add("Error Message");

    //        objConn.Close();
    //        DataTable dtfail_Qualification = new DataTable();



    //        dtfail_Qualification.Columns.Add("S.NO", typeof(Int32));
    //        dtfail_Qualification.Columns.Add("ROWNO", typeof(Int32));
    //        dtfail_Qualification.Columns.Add("COLUMNS NAMES", typeof(string));
    //        if (ds_Qualification.Tables[0].Columns[0].ToString().Trim() == "Applicant SNO*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_Qualification.Tables[0].Columns[1].ToString().Trim() == "Category*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_Qualification.Tables[0].Columns[2].ToString().Trim() == "Institute*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_Qualification.Tables[0].Columns[3].ToString().Trim() == "Year of pass*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_Qualification.Tables[0].Columns[4].ToString().Trim() == "Percentage*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_Qualification.Tables[0].Columns[5].ToString().Trim() == "Grade*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        objConn = new OleDbConnection(strcon);
    //        objConn.Open();
    //        sheetname = Convert.ToString(dt_chk2.Rows[8]["TABLE_NAME"]);//skills Details

    //        OleDbDataAdapter da_Skills = new OleDbDataAdapter("SELECT * FROM  [" + sheetname + "]", strcon);
    //        da_Skills.Fill(ds_skills);
    //        ds_skills.Tables[0].Columns.Add("Error Message");

    //        objConn.Close();
    //        DataTable dtfail_Skills = new DataTable();



    //        dtfail_Skills.Columns.Add("S.NO", typeof(Int32));
    //        dtfail_Skills.Columns.Add("ROWNO", typeof(Int32));
    //        dtfail_Skills.Columns.Add("COLUMNS NAMES", typeof(string));
    //        if (ds_skills.Tables[0].Columns[0].ToString().Trim() == "Applicant SNO*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }



    //        if (ds_skills.Tables[0].Columns[1].ToString().Trim() == "Skill Name*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }

    //        if (ds_skills.Tables[0].Columns[2].ToString().Trim() == "Last Used*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }

    //        if (ds_skills.Tables[0].Columns[3].ToString().Trim() == "Expertise*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please selsct the Correct Excel Template Sheet.");
    //            return;
    //        }


    //        objConn = new OleDbConnection(strcon);
    //        objConn.Open();
    //        sheetname = Convert.ToString(dt_chk2.Rows[1]["TABLE_NAME"]);

    //        OleDbDataAdapter da_Experiance = new OleDbDataAdapter("SELECT * FROM  [" + sheetname + "]", strcon);
    //        da_Experiance.Fill(ds_experiance);
    //        ds_experiance.Tables[0].Columns.Add("Error Message");

    //        objConn.Close();
    //        DataTable dtfail_experiance = new DataTable();



    //        dtfail_experiance.Columns.Add("S.NO", typeof(Int32));
    //        dtfail_experiance.Columns.Add("ROWNO", typeof(Int32));
    //        dtfail_experiance.Columns.Add("COLUMNS NAMES", typeof(string));
    //        if (ds_experiance.Tables[0].Columns[0].ToString().Trim() == "Applicant SNO*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_experiance.Tables[0].Columns[1].ToString().Trim() == "Company Name*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_experiance.Tables[0].Columns[2].ToString().Trim() == "Joining Date*(DD/MM/YYYY)")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_experiance.Tables[0].Columns[3].ToString().Trim() == "Join Salary*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_experiance.Tables[0].Columns[4].ToString().Trim() == "Join Position*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_experiance.Tables[0].Columns[5].ToString().Trim() == "Reason For Relieving*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_experiance.Tables[0].Columns[6].ToString().Trim() == "Relieving Date*(DD/MM/YYYY)")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_experiance.Tables[0].Columns[7].ToString().Trim() == "Relieving Salary*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_experiance.Tables[0].Columns[8].ToString().Trim() == "Relieving Position*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }

    //        objConn = new OleDbConnection(strcon);

    //        objConn.Open();
    //        sheetname = Convert.ToString(dt_chk2.Rows[0]["TABLE_NAME"]);

    //        OleDbDataAdapter da_Contact = new OleDbDataAdapter("SELECT * FROM  [" + sheetname + "]", strcon);
    //        da_Contact.Fill(ds_contact);
    //        ds_contact.Tables[0].Columns.Add("Error Message");

    //        objConn.Close();
    //        DataTable dtfail_contacts = new DataTable();



    //        dtfail_contacts.Columns.Add("S.NO", typeof(Int32));
    //        dtfail_contacts.Columns.Add("ROWNO", typeof(Int32));
    //        dtfail_contacts.Columns.Add("COLUMNS NAMES", typeof(string));
    //        if (ds_contact.Tables[0].Columns[0].ToString().Trim() == "Applicant SNO*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }


    //        if (ds_contact.Tables[0].Columns[1].ToString().Trim() == "Company Name*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }

    //        if (ds_contact.Tables[0].Columns[2].ToString().Trim() == "Contact Person*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }

    //        if (ds_contact.Tables[0].Columns[3].ToString().Trim() == "Phone Number*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }

    //        if (ds_contact.Tables[0].Columns[4].ToString().Trim() == "Address*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        objConn = new OleDbConnection(strcon);
    //        objConn.Open();
    //        sheetname = Convert.ToString(dt_chk2.Rows[3]["TABLE_NAME"]);

    //        OleDbDataAdapter da_language = new OleDbDataAdapter("SELECT * FROM  [" + sheetname + "]", strcon);
    //        da_language.Fill(ds_language);
    //        ds_language.Tables[0].Columns.Add("Error Message");

    //        objConn.Close();
    //        DataTable dtfail_language = new DataTable();



    //        dtfail_language.Columns.Add("S.NO", typeof(Int32));
    //        dtfail_language.Columns.Add("ROWNO", typeof(Int32));
    //        dtfail_language.Columns.Add("COLUMNS NAMES", typeof(string));

    //        if (ds_language.Tables[0].Columns[0].ToString().Trim() == "Applicant SNO*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_language.Tables[0].Columns[1].ToString().Trim() == "Language*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }

    //        if (ds_language.Tables[0].Columns[2].ToString().Trim() == "Read")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_language.Tables[0].Columns[3].ToString().Trim() == "Write")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_language.Tables[0].Columns[4].ToString().Trim() == "Speak")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds_language.Tables[0].Columns[5].ToString().Trim() == "Understand")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }

    //        objConn = new OleDbConnection(strcon);
    //        objConn.Open();
    //        sheetname = Convert.ToString(dt_chk2.Rows[2]["TABLE_NAME"]);

    //        OleDbDataAdapter da_family = new OleDbDataAdapter("SELECT * FROM  [" + sheetname + "]", strcon);
    //        //da.Fill(ds);
    //        //ds.Tables[0].Columns.Add("Error Message");
    //        da_family.Fill(ds_Family);
    //        ds_Family.Tables[0].Columns.Add("Error Message");

    //        objConn.Close();
    //        DataTable dtfail_family = new DataTable();



    //        dtfail_family.Columns.Add("S.NO", typeof(Int32));
    //        dtfail_family.Columns.Add("ROWNO", typeof(Int32));
    //        dtfail_family.Columns.Add("COLUMNS NAMES", typeof(string));

    //        if (ds_Family.Tables[0].Columns[0].ToString().Trim() == "Applicant SNO*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }

    //        if (ds_Family.Tables[0].Columns[1].ToString().Trim() == "Date of Birth(dd/mm/yyyy)*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_Family.Tables[0].Columns[2].ToString().Trim() == "Relationship*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_Family.Tables[0].Columns[3].ToString().Trim() == "Is Dependant")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_Family.Tables[0].Columns[4].ToString().Trim() == "Name*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_Family.Tables[0].Columns[5].ToString().Trim() == "Next to Kin")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_Family.Tables[0].Columns[6].ToString().Trim() == "Emergency Contact")
    //        {
    //        }
    //        else
    //        {

    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_Family.Tables[0].Columns[7].ToString().Trim() == "Annual Income")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_Family.Tables[0].Columns[8].ToString().Trim() == "Occupation")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }


    //        //@@@@@@@@@@@@@@Employee weeklyoff
    //        objConn = new OleDbConnection(strcon);
    //        objConn.Open();
    //        sheetname = Convert.ToString(dt_chk2.Rows[9]["TABLE_NAME"]);

    //        OleDbDataAdapter da_weeklyoff = new OleDbDataAdapter("SELECT * FROM  [" + sheetname + "]", strcon);
    //        da_weeklyoff.Fill(ds_weeklyOff);
    //        ds_weeklyOff.Tables[0].Columns.Add("Error Message");
    //        objConn.Close();
    //        DataTable dtfail_weeklyoff = new DataTable();



    //        dtfail_weeklyoff.Columns.Add("S.NO", typeof(Int32));
    //        dtfail_weeklyoff.Columns.Add("ROWNO", typeof(Int32));
    //        dtfail_weeklyoff.Columns.Add("COLUMNS NAMES", typeof(string));

    //        if (ds_weeklyOff.Tables[0].Columns[0].ToString().Trim() == "Applicant SNO*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }

    //        if (ds_weeklyOff.Tables[0].Columns[1].ToString().Trim() == "Effective Date*(dd/mm/yyyy)")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }

    //        if (ds_weeklyOff.Tables[0].Columns[2].ToString().Trim() == "Monday")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_weeklyOff.Tables[0].Columns[3].ToString().Trim() == "Tuesday")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_weeklyOff.Tables[0].Columns[4].ToString().Trim() == "Wednesday")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_weeklyOff.Tables[0].Columns[5].ToString().Trim() == "Thursday")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_weeklyOff.Tables[0].Columns[6].ToString().Trim() == "Friday")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_weeklyOff.Tables[0].Columns[7].ToString().Trim() == "Saturday")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_weeklyOff.Tables[0].Columns[8].ToString().Trim() == "Sunday")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }

    //        //@@@@@@@@@employee OthrerDetails


    //        objConn = new OleDbConnection(strcon);
    //        objConn.Open();
    //        sheetname = Convert.ToString(dt_chk2.Rows[4]["TABLE_NAME"]);

    //        OleDbDataAdapter da_empotherdetails = new OleDbDataAdapter("SELECT * FROM  [" + sheetname + "]", strcon);
    //        da_empotherdetails.Fill(ds_Otherdetails);
    //        ds_Otherdetails.Tables[0].Columns.Add("Error Message");
    //        objConn.Close();
    //        DataTable dtfail_empod = new DataTable();



    //        dtfail_empod.Columns.Add("S.NO", typeof(Int32));
    //        dtfail_empod.Columns.Add("ROWNO", typeof(Int32));
    //        dtfail_empod.Columns.Add("COLUMNS NAMES", typeof(string));

    //        if (ds_Otherdetails.Tables[0].Columns[0].ToString().Trim() == "Applicant SNO*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }

    //        if (ds_Otherdetails.Tables[0].Columns[1].ToString().Trim() == "PF Number")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_Otherdetails.Tables[0].Columns[2].ToString().Trim() == "PAN Number")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_Otherdetails.Tables[0].Columns[3].ToString().Trim() == "ESI Number")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_Otherdetails.Tables[0].Columns[4].ToString().Trim() == "Gratuity Number")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }

    //        //@@@@@@@@@@@employee Physical Details



    //        objConn = new OleDbConnection(strcon);
    //        objConn.Open();
    //        sheetname = Convert.ToString(dt_chk2.Rows[5]["TABLE_NAME"]);

    //        OleDbDataAdapter da_empphysicaldetails = new OleDbDataAdapter("SELECT * FROM  [" + sheetname + "]", strcon);
    //        da_empphysicaldetails.Fill(ds_physicaldetails);
    //        ds_physicaldetails.Tables[0].Columns.Add("Error Message");
    //        objConn.Close();
    //        DataTable dtfail_emphy = new DataTable();



    //        dtfail_emphy.Columns.Add("S.NO", typeof(Int32));
    //        dtfail_emphy.Columns.Add("ROWNO", typeof(Int32));
    //        dtfail_emphy.Columns.Add("COLUMNS NAMES", typeof(string));

    //        if (ds_physicaldetails.Tables[0].Columns[0].ToString().Trim() == "Applicant SNO*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }

    //        if (ds_physicaldetails.Tables[0].Columns[1].ToString().Trim() == "Mobile No")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_physicaldetails.Tables[0].Columns[2].ToString().Trim() == "Email ID")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_physicaldetails.Tables[0].Columns[3].ToString().Trim() == "LandLine No")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_physicaldetails.Tables[0].Columns[4].ToString().Trim() == "Height(cms)")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_physicaldetails.Tables[0].Columns[5].ToString().Trim() == "Skin Color")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_physicaldetails.Tables[0].Columns[6].ToString().Trim() == "Mole Identification Or Other Marks")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_physicaldetails.Tables[0].Columns[7].ToString().Trim() == "Is Handicapped?")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_physicaldetails.Tables[0].Columns[8].ToString().Trim() == "Details")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_physicaldetails.Tables[0].Columns[9].ToString().Trim() == "Weight(Kgs)")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_physicaldetails.Tables[0].Columns[10].ToString().Trim() == "Eye Power")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_physicaldetails.Tables[0].Columns[11].ToString().Trim() == "(physical)Treatment Name")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_physicaldetails.Tables[0].Columns[12].ToString().Trim() == "Hospital Name")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_physicaldetails.Tables[0].Columns[13].ToString().Trim() == "Treatment Duration(days)")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_physicaldetails.Tables[0].Columns[14].ToString().Trim() == "Current Illness Status")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_physicaldetails.Tables[0].Columns[15].ToString().Trim() == "(Mental)Treatment Name")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_physicaldetails.Tables[0].Columns[16].ToString().Trim() == "Hospital Name")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_physicaldetails.Tables[0].Columns[17].ToString().Trim() == "Treatment Duration(days)")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds_physicaldetails.Tables[0].Columns[18].ToString().Trim() == "Current Illness Status1")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }



    //        for (int i = 0; i < ds_directemp.Tables[0].Rows.Count; i++)
    //        {
    //            Session.Remove("MANUAL");

    //            errormsg = string.Empty;
    //            columnno = string.Empty;
    //            SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
    //            _obj_Smhr_BusinessUnit.OPERATION = operation.Get_BU;
    //            _obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //            DataTable dt_bu = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
    //            if (Convert.ToString(dt_bu.Rows[0]["ORGANISATION_EMPCODE_MANUAL"]) == "True")
    //            {
    //                Session["MANUAL"] = "MANUAL";

    //                if (ds_directemp.Tables[0].Rows[i]["Employee Code (If Manual)"].ToString().Trim() == "")
    //                {
    //                    errormsg = "Enter Employee Code (If Manual) ";

    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = "Employee Code (If Manual)";
    //                    return;
    //                }
    //                else
    //                {
    //                    _obj_smhr_employee = new SMHR_EMPLOYEE();
    //                    _obj_smhr_employee.OPERATION = operation.Get;
    //                    _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                    _obj_smhr_employee.EMP_EMPCODE = Convert.ToString(ds_directemp.Tables[0].Rows[i]["Employee Code (If Manual)"]).Trim();
    //                    if (Convert.ToString(BLL.get_empcode(_obj_smhr_employee).Rows[0]["Count"]) != "0")
    //                    {
    //                        // BLL.ShowMessage(this, "Employee Code Already Exists");
    //                        // rtxt_empcode.Text = string.Empty;
    //                        // rtxt_empcode.Focus();
    //                        errormsg = "Employee Code Already Exists ";

    //                        filestatus = false;
    //                        rowno = i + 2;
    //                        columnno = columnno + "," + "Employee Code (If Manual)";
    //                        return;
    //                    }
    //                }
    //            }
    //            else
    //            {
    //                if (ds_directemp.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() != "")
    //                {
    //                    for (int j = 0; j < ds_directemp.Tables[0].Rows.Count; j++)
    //                    {
    //                        if (i != j)
    //                        {
    //                            if (ds_directemp.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() == ds_directemp.Tables[0].Rows[j]["Applicant SNO*"].ToString().Trim())
    //                            {
    //                                errormsg = "Applicant SNO is repeated in excel Sheet";

    //                                filestatus = false;
    //                                rowno = i + 2;
    //                                columnno = columnno + "," + "Applicant SNO*";
    //                            }
    //                        }
    //                    }

    //                }
    //                else
    //                {
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = columnno + "," + "Applicant SNO*";

    //                }
    //            }
    //            if (ds_directemp.Tables[0].Rows[i]["Title*"].ToString().Trim() != "")
    //            {
    //                if (ds_directemp.Tables[0].Rows[i]["Title*"].ToString().Trim() == "Mr." || ds_directemp.Tables[0].Rows[i]["Title*"].ToString().Trim() == "Ms." || ds_directemp.Tables[0].Rows[i]["Title*"].ToString().Trim() == "Mrs.")
    //                {

    //                }
    //                else
    //                {
    //                    errormsg = errormsg + "," + "Please Check the title";

    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = "Title*";

    //                }

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = "Title*";

    //            }
    //            if (ds_directemp.Tables[0].Rows[i]["First Name*"].ToString().Trim() != "")
    //            {

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "First Name*";

    //            }



    //            if (ds_directemp.Tables[0].Rows[i]["Date of Birth*(DD/MM/YYYY)"].ToString().Trim() != "")
    //            {
    //                string dobirth = "";

    //                dobirth = ds_directemp.Tables[0].Rows[i]["Date of Birth*(DD/MM/YYYY)"].ToString().Trim();

    //                bool wrongsdformat = dobirth.Contains(".");

    //                if (wrongsdformat)
    //                    dobirth = dobirth.Replace(".", "/");
    //                bool Chkdate = CheckDateFormat(dobirth);


    //                // bool Chkdate = CheckDateFormat(Convert.ToString(ds_directemp.Tables[0].Rows[i]["Date of Birth*(DD/MM/YYYY)"]));
    //                if (Chkdate == true)
    //                {

    //                    _obj_smhr_applicant = new SMHR_APPLICANT();
    //                    _obj_smhr_applicant.OPERATION = operation.Check_New;
    //                    _obj_smhr_applicant.APPLI_DOB = Convert.ToString(ds_directemp.Tables[0].Rows[i]["Date of Birth*(DD/MM/YYYY)"]);
    //                    DataTable dtdatecheck = BLL.CONVERTTODATE(_obj_smhr_applicant);


    //                    if ((Convert.ToString(dtdatecheck.Rows[0]["RESULT"])) == "ACCEPT")
    //                    {

    //                        stdatetime = true;
    //                    }
    //                    else
    //                    {

    //                        stdatetime = false;

    //                        errormsg = errormsg + "," + "Enter Valid Date Of Birth";

    //                        filestatus = false;
    //                        rowno = i + 2;
    //                        columnno = columnno + "," + "Date of Birth*(DD/MM/YYYY)";


    //                    }



    //                }
    //                else
    //                {
    //                    errormsg = errormsg + "," + "Enter Correct Start Date";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = columnno + "," + "Date of Birth*(DD/MM/YYYY)";

    //                }
    //            }

    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Date of Birth*(DD/MM/YYYY)";

    //            }
    //            if ((ds_directemp.Tables[0].Rows[i]["Title*"].ToString().Trim() == "Mr." && ds_directemp.Tables[0].Rows[i]["Gender*"].ToString().Trim() == "Male") || ((ds_directemp.Tables[0].Rows[i]["Title*"].ToString().Trim() == "Ms." || ds_directemp.Tables[0].Rows[i]["Title*"].ToString().Trim() == "Mrs.") && ds_directemp.Tables[0].Rows[i]["Gender*"].ToString().Trim() == "Female"))
    //            {


    //            }
    //            else
    //            {
    //                errormsg = errormsg + "," + "Check the title and Gender";

    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Gender*";

    //            }

    //            if (ds_directemp.Tables[0].Rows[i]["Blood Group*"].ToString().Trim() == "O+" || ds_directemp.Tables[0].Rows[i]["Blood Group*"].ToString().Trim() == "O-" || ds_directemp.Tables[0].Rows[i]["Blood Group*"].ToString().Trim() == "B+" || ds_directemp.Tables[0].Rows[i]["Blood Group*"].ToString().Trim() == "B-" || ds_directemp.Tables[0].Rows[i]["Blood Group*"].ToString().Trim() == "AB+" || ds_directemp.Tables[0].Rows[i]["Blood Group*"].ToString().Trim() == "AB-" || ds_directemp.Tables[0].Rows[i]["Blood Group*"].ToString().Trim() == "A-")
    //            {
    //            }
    //            else
    //            {
    //                errormsg = errormsg + "," + "Check the Blood group";
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Blood Group*";//Religion*


    //            }
    //            if (ds_directemp.Tables[0].Rows[i]["Religion*"].ToString().Trim() != "")
    //            {
    //                SMHR_MASTERS _Obj_smhr_Masters = new SMHR_MASTERS();

    //                _Obj_smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                _Obj_smhr_Masters.MASTER_TYPE = "RELIGION";
    //                _Obj_smhr_Masters.OPERATION = operation.Check;

    //                _Obj_smhr_Masters.MASTER_CODE = ds_directemp.Tables[0].Rows[i]["Religion*"].ToString().Trim();
    //                DataTable dt_relig = BLL.get_Applicant_Validate(_Obj_smhr_Masters);
    //                if (Convert.ToInt32(dt_relig.Rows[0]["COUNT"]) > 0)
    //                {
    //                }
    //                else
    //                {
    //                    errormsg = errormsg + "," + "Enter Valid Religion";

    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = columnno + "," + "Religion*";


    //                }

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Religion*";


    //            }
    //            if (ds_directemp.Tables[0].Rows[i]["Nationality*"].ToString().Trim() != "")
    //            {
    //                SMHR_MASTERS _Obj_smhr_Masters = new SMHR_MASTERS();
    //                _Obj_smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                _Obj_smhr_Masters.OPERATION = operation.Check;
    //                _Obj_smhr_Masters.MASTER_TYPE = "NATIONALITY";
    //                _Obj_smhr_Masters.MASTER_CODE = ds_directemp.Tables[0].Rows[i]["Nationality*"].ToString().Trim();
    //                DataTable dt_nat = BLL.get_Applicant_Validate(_Obj_smhr_Masters);
    //                if (Convert.ToInt32(dt_nat.Rows[0]["COUNT"]) > 0)
    //                {
    //                }
    //                else
    //                {
    //                    errormsg = errormsg + "," + "Nationality does't exits";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = columnno + "," + "Nationality*";


    //                }
    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Nationality*";


    //            }
    //            if (ds_directemp.Tables[0].Rows[i]["Status*"].ToString().Trim() == "Applied" || ds_directemp.Tables[0].Rows[i]["Status*"].ToString().Trim() == "Selected" || ds_directemp.Tables[0].Rows[i]["Status*"].ToString().Trim() == "Rejected")
    //            {
    //            }
    //            else
    //            {
    //                errormsg = errormsg + "," + "Status does't exits";

    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Status*";
    //                //Marital Status



    //            }
    //            if (ds_directemp.Tables[0].Rows[i]["Marital Status"].ToString().Trim() == "Single" || ds_directemp.Tables[0].Rows[i]["Marital Status"].ToString().Trim() == "Divorced" || ds_directemp.Tables[0].Rows[i]["Marital Status"].ToString().Trim() == "Married" || ds_directemp.Tables[0].Rows[i]["Marital Status"].ToString().Trim() == "Now Married")
    //            {
    //            }
    //            else
    //            {
    //                errormsg = errormsg + "," + "Marital Status does't exits";

    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Marital Status";




    //            }
    //            if (ds_directemp.Tables[0].Rows[i]["Address*"].ToString().Trim() != "")
    //            {

    //            }


    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Address*";




    //            }

    //            //if (ds_directemp.Tables[0].Rows[i]["Remarks"].ToString().Trim() != "")
    //            //{

    //            //}


    //            //else
    //            //{
    //            //    filestatus = false;
    //            //    rowno = i + 2;
    //            //    columnno = columnno + "," + "Remarks";




    //            //}
    //            if (ds_directemp.Tables[0].Rows[i]["Business Unit*"].ToString().Trim() != "")
    //            {

    //                for (int count = 0; count < ddl_BusinessUnit.Items.Count; count++)
    //                {
    //                    if ((ds_directemp.Tables[0].Rows[i]["Business Unit*"].ToString().Trim()) == ddl_BusinessUnit.Items[count].Text)
    //                    {
    //                        bu_id = Convert.ToInt32(ddl_BusinessUnit.Items[count].Value);

    //                    }

    //                }
    //                if (bu_id == 0)
    //                {
    //                    errormsg = errormsg + "," + "Business Unit Does not  Exists";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = columnno + "," + "Business Unit*";

    //                }
    //                else
    //                {

    //                    LoadMode();
    //                    LoadCurrency();
    //                    getPosition();
    //                    // LoadDates();
    //                    LoadDepartment();
    //                    getSupervisor();
    //                    get_SupBusinessUnit();
    //                }

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Business Unit*";
    //            }
    //            if (ds_directemp.Tables[0].Rows[i]["DateOfJoin*(dd/mm/yyyy)"].ToString().Trim() != "")
    //            {
    //                string dojdate = "";

    //                dojdate = ds_directemp.Tables[0].Rows[i]["DateOfJoin*(dd/mm/yyyy)"].ToString().Trim();

    //                bool wrongsdformat = dojdate.Contains(".");

    //                if (wrongsdformat)
    //                    dojdate = dojdate.Replace(".", "/");
    //                bool Chkdate = CheckDateFormat(dojdate);
    //                if (Chkdate == false)
    //                {
    //                    errormsg = errormsg + "," + "Enter Correct Start Date";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = columnno + "," + "DateOfJoin*(dd/mm/yyyy)";

    //                }

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "DateOfJoin*(dd/mm/yyyy)";

    //            }
    //            if (ds_directemp.Tables[0].Rows[i]["Date of Confirm*(dd/mm/yyyy)"].ToString().Trim() != "")
    //            {
    //                string docdate = "";

    //                docdate = ds_directemp.Tables[0].Rows[i]["Date of Confirm*(dd/mm/yyyy)"].ToString().Trim();

    //                bool wrongsdformat = docdate.Contains(".");

    //                if (wrongsdformat)
    //                    docdate = docdate.Replace(".", "/");
    //                bool Chkdate = CheckDateFormat(docdate);


    //                if (Chkdate == false)
    //                {
    //                    errormsg = errormsg + "," + "Enter Correct Start Date";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = columnno + "," + "Date of Confirm*(dd/mm/yyyy)";

    //                }
    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Date of Confirm*(dd/mm/yyyy)";
    //            }
    //            if (ds_directemp.Tables[0].Rows[i]["Payment Mode*"].ToString().Trim() != "")
    //            {
    //                for (int count = 0; count < ddl_Mode.Items.Count; count++)
    //                {
    //                    if ((ds_directemp.Tables[0].Rows[i]["Payment Mode*"].ToString().Trim()) == ddl_Mode.Items[count].Text)
    //                    {
    //                        paymentmode = Convert.ToInt32(ddl_Mode.Items[count].Value);

    //                    }

    //                }

    //                if (paymentmode == 0)
    //                {
    //                    errormsg = errormsg + "," + "Payment Mode Does not  Exists";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = columnno + "," + "Payment Mode*";

    //                }
    //                else
    //                {
    //                }

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Payment Mode*";
    //            }


    //            if (ds_directemp.Tables[0].Rows[i]["Department*"].ToString().Trim() != "")
    //            {

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Department*";

    //            }
    //            if (ds_directemp.Tables[0].Rows[i]["Position*"].ToString().Trim() != "")
    //            {

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Position*";

    //            }
    //            if (ds_directemp.Tables[0].Rows[i]["Employee Type*"].ToString().Trim() != "")
    //            {

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Employee Type*";

    //            }
    //            if (ds_directemp.Tables[0].Rows[i]["Leave Structure*"].ToString().Trim() != "")
    //            {

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Leave Structure*";

    //            }

    //            if (ds_directemp.Tables[0].Rows[i]["Currency*"].ToString().Trim() != "")
    //            {

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Currency*";

    //            }

    //            if (ds_directemp.Tables[0].Rows[i]["Salary Structure*"].ToString().Trim() != "")
    //            {

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Salary Structure*";

    //            }
    //            if (ds_directemp.Tables[0].Rows[i]["Shift*"].ToString().Trim() != "")
    //            {

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Shift*";

    //            }
    //            if (ds_directemp.Tables[0].Rows[i]["Gross Salary*"].ToString().Trim() != "")
    //            {

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Gross Salary*";

    //            }
    //            //if (ds.Tables[0].Rows[i]["Basic Pay*"].ToString().Trim() != "")
    //            //{

    //            //}
    //            //else
    //            //{
    //            //    filestatus = false;
    //            //    rowno = i + 2;
    //            //    columnno = columnno + "," + "Basic Pay*";

    //            //}
    //            if (ds_directemp.Tables[0].Rows[i]["Contract Date*(dd/mm/yyyy)"].ToString().Trim() != "")
    //            {

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Contract Date*(dd/mm/yyyy)";

    //            }
    //            if (Convert.ToString(Session["MANUAL"]) == "MANUAL")
    //            {

    //                if (ds_directemp.Tables[0].Rows[i]["Employee Code (If Manual)"].ToString().Trim() != "")
    //                {


    //                }
    //                else
    //                {
    //                    filestatus = false;
    //                    errormsg = "Employee Code (If Manual) should not be empty";

    //                    rowno = i + 2;
    //                    columnno = columnno + "," + "Employee Code (If Manual)";
    //                }
    //            }
    //            else
    //            {
    //                if (ds_directemp.Tables[0].Rows[i]["Employee Code (If Manual)"].ToString().Trim() != "")
    //                {
    //                    filestatus = false;
    //                    errormsg = "Employee Code (If Manual) should be empty";
    //                    rowno = i + 2;
    //                    columnno = columnno + "," + "Employee Code (If Manual)";

    //                }

    //            }

    //            if (filestatus == false)
    //            {
    //                DataRow newrow = dtfail_DirectEmp.NewRow();
    //                newrow["S.NO"] = dtfail_DirectEmp.Rows.Count + 1;


    //                newrow["ROWNO"] = rowno;
    //                newrow["COLUMNS NAMES"] = columnno;
    //                dtfail_DirectEmp.Rows.Add(newrow);
    //                ds_directemp.Tables[0].Rows[i]["Error Message"] = errormsg;

    //            }



    //        }
    //        for (int i = 0; i < ds_Family.Tables[0].Rows.Count; i++)
    //        {
    //            errormsg = string.Empty;
    //            columnno = string.Empty;
    //            //if (ds_Family.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() != "")
    //            //{
    //            //}
    //            //else
    //            //{
    //            //    filestatus = false;
    //            //    rowno = i + 2;
    //            //    columnno = "Applicant SNO*";

    //            //}
    //            //for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
    //            //{
    //            //    if (ds_Family.Tables[0].Rows[i]["ApplicantID*"].ToString().Trim() == ds_Family.Tables[0].Rows[k]["ApplicantID*"].ToString().Trim())
    //            //    {
    //            //        if (i != k)
    //            //        {
    //            //            errormsg = "ApplicantID is repeated in Excel Sheet";
    //            //            filestatus = false;
    //            //            rowno = i + 2;
    //            //            columnno = "ApplicantID*";
    //            //        }
    //            //    }
    //            //}

    //            if (ds_Family.Tables[0].Rows[i]["Date of Birth(dd/mm/yyyy)*"].ToString().Trim() != "")
    //            {

    //                string dateofbirth = "";

    //                dateofbirth = ds_Family.Tables[0].Rows[i]["Date of Birth(dd/mm/yyyy)*"].ToString();

    //                bool wrongsdformat = dateofbirth.Contains(".");

    //                if (wrongsdformat)
    //                    dateofbirth = dateofbirth.Replace(".", "/");

    //                bool Chkdate = CheckDateFormat(dateofbirth);
    //                if (Chkdate == false)
    //                {
    //                    errormsg = errormsg + "," + "Enter Correct Date of Birth";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = columnno + "," + "Date of Birth(dd/mm/yyyy)*";

    //                }
    //            }
    //            else
    //            {
    //                errormsg = errormsg + "," + "Enter  Date of Birth";

    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Date of Birth(dd/mm/yyyy)*";

    //            }
    //            if (ds_Family.Tables[0].Rows[i]["Relationship*"].ToString().Trim() != "")
    //            {
    //                for (int count = 0; count < ddl_Relationship.Items.Count; count++)
    //                {
    //                    if ((ds_Family.Tables[0].Rows[i]["Relationship*"].ToString().Trim()) == ddl_Relationship.Items[count].Text)
    //                    {
    //                        relaid = Convert.ToInt32(ddl_Relationship.Items[count].Value);

    //                    }

    //                }

    //                if (relaid == 0)
    //                {
    //                    errormsg = errormsg + "," + "Relation Does not  Exists";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = columnno + "," + "Relationship";

    //                }
    //                else
    //                {
    //                }
    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Relationship";


    //            }
    //            if (ds_Family.Tables[0].Rows[i]["Is Dependant"].ToString().Trim() != "")
    //            {
    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Is Dependant";


    //            }
    //            if (ds_Family.Tables[0].Rows[i]["Name*"].ToString().Trim() != "")
    //            {
    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Name*";


    //            }
    //            if (filestatus == false)
    //            {
    //                DataRow newrow = dtfail_family.NewRow();
    //                newrow["S.NO"] = dtfail_family.Rows.Count + 1;


    //                newrow["ROWNO"] = rowno;
    //                newrow["COLUMNS NAMES"] = columnno;
    //                dtfail_family.Rows.Add(newrow);
    //                ds_Family.Tables[0].Rows[i]["Error Message"] = errormsg;
    //            }

    //        }



    //        //@@@@@@@@@Employee WeeklyOff

    //        for (int i = 0; i < ds_weeklyOff.Tables[0].Rows.Count; i++)
    //        {
    //            errormsg = string.Empty;
    //            columnno = string.Empty;
    //            //if (ds_weeklyOff.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() != "")
    //            //{
    //            //}
    //            //else
    //            //{
    //            //    //filestatus = false;
    //            //    //rowno = i + 2;
    //            //    //columnno = "Applicant SNO*";

    //            //}
    //            for (int k = 0; k < ds_weeklyOff.Tables[0].Rows.Count; k++)
    //            {
    //                if (ds_weeklyOff.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() == ds_weeklyOff.Tables[0].Rows[k]["Applicant SNO*"].ToString().Trim())
    //                {
    //                    if (i != k)
    //                    {
    //                        errormsg = "ApplicantID is repeated in Excel Sheet";
    //                        filestatus = false;
    //                        rowno = i + 2;
    //                        columnno = "Applicant SNO*";
    //                    }
    //                }
    //            }

    //            if (ds_weeklyOff.Tables[0].Rows[i]["Effective Date*(dd/mm/yyyy)"].ToString().Trim() != "")
    //            {

    //                string efd = "";

    //                efd = ds_weeklyOff.Tables[0].Rows[i]["Effective Date*(dd/mm/yyyy)"].ToString();

    //                bool wrongsdformat = efd.Contains(".");

    //                if (wrongsdformat)
    //                    efd = efd.Replace(".", "/");

    //                bool Chkdate = CheckDateFormat(efd);
    //                if (Chkdate == false)
    //                {
    //                    errormsg = errormsg + "," + "Enter Correct Effective  Date";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = columnno + "," + "Effective Date*(dd/mm/yyyy)";

    //                }
    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Effective Date*(dd/mm/yyyy)";

    //            }
    //            if (filestatus == false)
    //            {
    //                DataRow newrow = dtfail_weeklyoff.NewRow();
    //                newrow["S.NO"] = dtfail_weeklyoff.Rows.Count + 1;


    //                newrow["ROWNO"] = rowno;
    //                newrow["COLUMNS NAMES"] = columnno;
    //                dtfail_weeklyoff.Rows.Add(newrow);
    //                ds_weeklyOff.Tables[0].Rows[i]["Error Message"] = errormsg;
    //            }
    //        }


    //        //@@@@@@@@@employee Other Details

    //        for (int i = 0; i < ds_Otherdetails.Tables[0].Rows.Count; i++)
    //        {
    //            errormsg = string.Empty;
    //            columnno = string.Empty;
    //            if (ds_Otherdetails.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() != "")
    //            {
    //                for (int k = 0; k < ds_Otherdetails.Tables[0].Rows.Count; k++)
    //                {
    //                    if (ds_Otherdetails.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() == ds_Otherdetails.Tables[0].Rows[k]["Applicant SNO*"].ToString().Trim())
    //                    {
    //                        if (i != k)
    //                        {
    //                            errormsg = "ApplicantID is repeated in Excel Sheet";
    //                            filestatus = false;
    //                            rowno = i + 2;
    //                            columnno = "ApplicantID*";
    //                        }
    //                    }
    //                }
    //            }
    //            else
    //            {
    //            }

    //            if (filestatus == false)
    //            {
    //                DataRow newrow = dtfail_empod.NewRow();
    //                newrow["S.NO"] = dtfail_empod.Rows.Count + 1;


    //                newrow["ROWNO"] = rowno;
    //                newrow["COLUMNS NAMES"] = columnno;
    //                dtfail_empod.Rows.Add(newrow);
    //                ds_Otherdetails.Tables[0].Rows[i]["Error Message"] = errormsg;
    //            }

    //        }




    //        //@@@@@@@@@emp_physicaldetails

    //        for (int i = 0; i < ds_physicaldetails.Tables[0].Rows.Count; i++)
    //        {
    //            errormsg = string.Empty;
    //            columnno = string.Empty;
    //            if (ds_physicaldetails.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() != "")
    //            {
    //                for (int k = 0; k < ds_physicaldetails.Tables[0].Rows.Count; k++)
    //                {
    //                    if (ds_physicaldetails.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() == ds_physicaldetails.Tables[0].Rows[k]["Applicant SNO*"].ToString().Trim())
    //                    {
    //                        if (i != k)
    //                        {
    //                            errormsg = "ApplicantID is repeated in Excel Sheet";
    //                            filestatus = false;
    //                            rowno = i + 2;
    //                            columnno = "Applicant SNO*";
    //                        }
    //                    }
    //                }
    //            }
    //            else
    //            {
    //            }
    //            if (ds_physicaldetails.Tables[0].Rows[i]["Mobile No"].ToString().Trim() != "")
    //            {
    //                string mobile;
    //                mobile = ds_physicaldetails.Tables[0].Rows[i]["Mobile No"].ToString().Trim();
    //                //bool isint = IsInteger(mobile);
    //                //if (isint == false)
    //                //{
    //                //    errormsg = errormsg + "," + "Mobile number should be in digits";
    //                //    filestatus = false;
    //                //    rowno = i + 2;
    //                //    columnno = "Mobile No";
    //                //}

    //            }
    //            if (ds_physicaldetails.Tables[0].Rows[i]["LandLine No"].ToString().Trim() != "")
    //            {
    //                string land;
    //                land = ds_physicaldetails.Tables[0].Rows[i]["LandLine No"].ToString().Trim();
    //                bool isint = IsInteger(land);
    //                if (isint == false)
    //                {
    //                    errormsg = errormsg + "," + "landline number should be in digits";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = "LandLine No";
    //                }

    //            }

    //            if (filestatus == false)
    //            {
    //                DataRow newrow = dtfail_emphy.NewRow();
    //                newrow["S.NO"] = dtfail_emphy.Rows.Count + 1;


    //                newrow["ROWNO"] = rowno;
    //                newrow["COLUMNS NAMES"] = columnno;
    //                dtfail_emphy.Rows.Add(newrow);
    //                ds_physicaldetails.Tables[0].Rows[i]["Error Message"] = errormsg;
    //            }

    //        }
    //        for (int i = 0; i < ds_Qualification.Tables[0].Rows.Count; i++)
    //        {
    //            errormsg = string.Empty;
    //            columnno = string.Empty;
    //            if (ds_Qualification.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() != "")
    //            {
    //                bool status1 = false;

    //                for (int j = 0; j < ds_directemp.Tables[0].Rows.Count; j++)
    //                {
    //                    if (ds_Qualification.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() == ds_directemp.Tables[0].Rows[j]["Applicant SNO*"].ToString().Trim())
    //                    {




    //                        status1 = true;
    //                        break;

    //                    }
    //                }
    //                for (int k = 0; k < ds_Qualification.Tables[0].Rows.Count; k++)
    //                {
    //                    for (int l = 0; l < ds_Qualification.Tables[0].Rows.Count; l++)
    //                    {
    //                        if (k != l)
    //                        {
    //                            if (ds_Qualification.Tables[0].Rows[k]["Applicant SNO*"].ToString().Trim() == ds_Qualification.Tables[0].Rows[l]["Applicant SNO*"].ToString().Trim() && ds_Qualification.Tables[0].Rows[k]["Category*"].ToString().Trim() == ds_Qualification.Tables[0].Rows[l]["Category*"].ToString().Trim())
    //                            {
    //                                errormsg = "already exist in excel";
    //                                filestatus = false;//already exist in excel
    //                                rowno = i + 2;
    //                                columnno = columnno + "," + "Category*";
    //                                break;
    //                            }
    //                        }
    //                    }
    //                }
    //                if (status1 == false)
    //                {
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = "Applicant SNO*";

    //                }

    //                //SMHR_APPLICANT _obj_smhr_applicant = new SMHR_APPLICANT();
    //                //_obj_smhr_applicant.OPERATION = operation.Check;
    //                //_obj_smhr_applicant.APPLICANT_CODE = Convert.ToString(ds_Qualification.Tables[0].Rows[i]["Applicant Code*"].ToString().Trim());
    //                //_obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                //DataTable dt_appcode = BLL.get_Applicant(_obj_smhr_applicant);
    //                //if (dt_appcode.Rows.Count > 0)//validate applicant id exist or not
    //                //{
    //                //    app_id = Convert.ToInt32(dt_appcode.Rows[0]["APPLICANT_ID"]);
    //                //}
    //                //else
    //                //{
    //                //    filestatus = false;
    //                //    rowno = i + 2;
    //                //    columnno = "Applicant Code*";

    //                //}




    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = "Applicant SNO*";

    //            }
    //            if (ds_Qualification.Tables[0].Rows[i]["Category*"].ToString().Trim() != "")
    //            {
    //                SMHR_MASTERS _Obj_smhr_Masters = new SMHR_MASTERS();
    //                _Obj_smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                _Obj_smhr_Masters.OPERATION = operation.Select;
    //                _Obj_smhr_Masters.MASTER_TYPE = "QUALIFICATION";
    //                _Obj_smhr_Masters.MASTER_CODE = ds_Qualification.Tables[0].Rows[i]["Category*"].ToString().Trim();
    //                DataTable dt_nat = BLL.get_Applicant_Validate(_Obj_smhr_Masters);
    //                if (Convert.ToInt32(dt_nat.Rows.Count) > 0)
    //                {


    //                }
    //                else
    //                {
    //                    errormsg = errormsg + "," + "Category does not exists";

    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = columnno + "," + "Category*";


    //                }

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Category*";

    //            }

    //            if (ds_Qualification.Tables[0].Rows[i]["Institute*"].ToString().Trim() != "")
    //            {

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Institute*";

    //            }
    //            if (ds_Qualification.Tables[0].Rows[i]["Year of pass*"].ToString().Trim() != "")
    //            {
    //                int b;
    //                int.TryParse(Convert.ToString(ds_Qualification.Tables[0].Rows[i]["Year of pass*"]), out  b);
    //                if (b != int.MinValue) //year of integer length 4 only
    //                {
    //                    int count = Convert.ToString(ds_Qualification.Tables[0].Rows[i]["Year of pass*"]).Length;
    //                    if (count > 4)
    //                    {
    //                        errormsg = errormsg + "," + "enter valid year";
    //                        filestatus = false;
    //                        rowno = i + 2;
    //                        columnno = "Year of pass*";
    //                    }
    //                }
    //                else
    //                {
    //                    errormsg = errormsg + "," + "enter valid year";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = "Year of pass*";

    //                }
    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Year of pass*";

    //            }

    //            if (ds_Qualification.Tables[0].Rows[i]["Percentage*"].ToString().Trim() != "")
    //            {
    //                //string date = Convert.ToString(ds.Tables[0].Rows[i]["Date of Birth*"]);
    //                //string st = date.Substring(0, 10);

    //                int b;
    //                int.TryParse(Convert.ToString(ds_Qualification.Tables[0].Rows[i]["Percentage*"]), out  b);
    //                if (b != int.MinValue) //year of integer length 4 only
    //                {

    //                }
    //                else
    //                {
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = "Percentage*";

    //                }
    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Percentage*";
    //            }







    //            if (ds_Qualification.Tables[0].Rows[i]["Grade*"].ToString().Trim() != "")
    //            {

    //                if (ds_Qualification.Tables[0].Rows[i]["Grade*"].ToString().Trim().ToUpper() == "A" || ds_Qualification.Tables[0].Rows[i]["Grade*"].ToString().Trim().ToUpper() == "B" || ds_Qualification.Tables[0].Rows[i]["Grade*"].ToString().Trim().ToUpper() == "C" || ds_Qualification.Tables[0].Rows[i]["Grade*"].ToString().Trim().ToUpper() == "D")
    //                {
    //                }
    //                else
    //                {
    //                    errormsg = errormsg + "," + "Grade does not exists";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = columnno + "," + "Grade*";


    //                }

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Grade*";


    //            }

    //            if (filestatus == false)
    //            {
    //                DataRow newrow = dtfail_Qualification.NewRow();
    //                newrow["S.NO"] = dtfail_Qualification.Rows.Count + 1;


    //                newrow["ROWNO"] = rowno;
    //                newrow["COLUMNS NAMES"] = columnno;
    //                dtfail_Qualification.Rows.Add(newrow);
    //                ds_Qualification.Tables[0].Rows[i]["Error Message"] = errormsg;
    //            }


    //        }






    //        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@




    //        //@@@@@@@@@@@@@@@@@@@@@@@@@--To check the Skills data in excel sheet

    //        for (int i = 0; i < ds_skills.Tables[0].Rows.Count; i++)
    //        {
    //            errormsg = string.Empty;
    //            columnno = string.Empty;
    //            if (ds_skills.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() != "")
    //            {
    //                bool status1 = false;

    //                for (int j = 0; j < ds_directemp.Tables[0].Rows.Count; j++)
    //                {
    //                    if (ds_skills.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() == ds_directemp.Tables[0].Rows[j]["Applicant SNO*"].ToString().Trim())
    //                    {




    //                        status1 = true;
    //                        break;

    //                    }
    //                }
    //                // for (int k = 0; k < ds_skills.Tables[0].Rows.Count; k++)
    //                // {
    //                for (int l = 0; l < ds_skills.Tables[0].Rows.Count; l++)
    //                {
    //                    if (i != l)
    //                    {
    //                        if (ds_skills.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() == ds_skills.Tables[0].Rows[l]["Applicant SNO*"].ToString().Trim() && ds_skills.Tables[0].Rows[i]["Skill Name*"].ToString().Trim() == ds_skills.Tables[0].Rows[l]["Skill Name*"].ToString().Trim())
    //                        {
    //                            errormsg = errormsg + "," + "already exist in excel";
    //                            filestatus = false;//already exist in excel
    //                            rowno = i + 2;
    //                            columnno = columnno + "," + "Skill Name*";
    //                            break;
    //                        }
    //                        else
    //                        {
    //                        }
    //                    }
    //                }
    //                //   }

    //                if (status1 == false)
    //                {
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = "Applicant SNO*";
    //                }



    //                //string aplicantcode = ds_skills.Tables[0].Rows[i]["Applicant Code*"].ToString();
    //                //SMHR_APPLICANT _obj_smhr_applicant = new SMHR_APPLICANT();
    //                //_obj_smhr_applicant.APPLICANT_CODE = aplicantcode;
    //                //_obj_smhr_applicant.OPERATION = operation.Check;
    //                //_obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                //DataTable dt_app_id = BLL.get_Applicant(_obj_smhr_applicant);

    //                //if (dt_app_id.Rows.Count > 0)
    //                //{
    //                //    app_id = Convert.ToInt32(dt_app_id.Rows[0]["APPLICANT_ID"]);
    //                //}
    //                //else
    //                //{
    //                //    filestatus = false;
    //                //    rowno = i + 2;
    //                //    columnno = "Applicant Code*";
    //                //}

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = "Applicant SNO*";
    //            }

    //            if (ds_skills.Tables[0].Rows[i]["Skill Name*"].ToString().Trim() != "")
    //            {
    //                SMHR_MASTERS _Obj_smhr_Masters = new SMHR_MASTERS();
    //                _Obj_smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                _Obj_smhr_Masters.OPERATION = operation.Select;
    //                _Obj_smhr_Masters.MASTER_TYPE = "SKILL";
    //                _Obj_smhr_Masters.MASTER_CODE = ds_skills.Tables[0].Rows[i]["Skill Name*"].ToString().Trim();
    //                DataTable dt_nat = BLL.get_Applicant_Validate(_Obj_smhr_Masters);
    //                if (Convert.ToInt32(dt_nat.Rows.Count) > 0)
    //                {


    //                }



    //                else
    //                {
    //                    errormsg = errormsg + "," + "Skill Does not exist";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = columnno + "," + "Skill Name*";


    //                }
    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Skill Name*";


    //            }

    //            if (ds_skills.Tables[0].Rows[i]["Last Used*"].ToString().Trim() != "")
    //            {
    //                Year = Convert.ToInt32(ds_skills.Tables[0].Rows[i]["Last Used*"]);



    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Last Used*";


    //            }

    //            if (ds_skills.Tables[0].Rows[i]["Expertise*"].ToString().Trim() == "Beginner" || ds_skills.Tables[0].Rows[i]["Expertise*"].ToString().Trim() == "Intermediate" || ds_skills.Tables[0].Rows[i]["Expertise*"].ToString().Trim() == "Expert")
    //            {

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Expertise*";

    //            }

    //            if (filestatus == false)
    //            {
    //                DataRow newrow = dtfail_Skills.NewRow();
    //                newrow["S.NO"] = dtfail_Skills.Rows.Count + 1;


    //                newrow["ROWNO"] = rowno;
    //                newrow["COLUMNS NAMES"] = columnno;
    //                dtfail_Skills.Rows.Add(newrow);
    //                ds_skills.Tables[0].Rows[i]["Error Message"] = errormsg;
    //            }


    //        }




    //        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@




    //        //@@@@@@@@@@@@@@@@@@@@@@@@@@--To check the Experiance data in excel sheet

    //        for (int i = 0; i < ds_experiance.Tables[0].Rows.Count; i++)
    //        {
    //            errormsg = string.Empty;
    //            columnno = string.Empty;
    //            string JOINDAT = string.Empty;
    //            string RELDAT = string.Empty;
    //            DateTime jdate;
    //            DateTime rdate;
    //            if (ds_experiance.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() != "")
    //            {

    //                bool status1 = false;

    //                for (int j = 0; j < ds_directemp.Tables[0].Rows.Count; j++)
    //                {
    //                    if (ds_experiance.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() == ds_directemp.Tables[0].Rows[j]["Applicant SNO*"].ToString().Trim())
    //                    {
    //                        status1 = true;
    //                        break;

    //                    }
    //                }
    //                if (status1 == false)
    //                {
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = "Applicant SNO*";
    //                }

    //                //SMHR_APPLICANT _obj_smhr_applicant = new SMHR_APPLICANT();
    //                //_obj_smhr_applicant.OPERATION = operation.Check;
    //                //_obj_smhr_applicant.APPLICANT_CODE = Convert.ToString(ds_experiance.Tables[0].Rows[i]["Applicant Code*"].ToString().Trim());
    //                //_obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                //DataTable dt_appcode = BLL.get_Applicant(_obj_smhr_applicant);
    //                //if (dt_appcode.Rows.Count > 0)//validate applicant id exist or not
    //                //{
    //                //    app_id = Convert.ToInt32(dt_appcode.Rows[0]["APPLICANT_ID"]);
    //                //}
    //                //else
    //                //{
    //                //    filestatus = false;
    //                //    rowno = i + 2;
    //                //    columnno = "Applicant Code*";

    //                //}

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = "Applicant SNO*";

    //            }
    //            if (ds_experiance.Tables[0].Rows[i]["Company Name*"].ToString().Trim() != "")
    //            {

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Company Name*";

    //            }

    //            if (ds_experiance.Tables[0].Rows[i]["Joining Date*(DD/MM/YYYY)"].ToString().Trim() != "")
    //            {
    //                //  DateTime b;


    //                string JD = "";

    //                JD = ds_experiance.Tables[0].Rows[i]["Joining Date*(DD/MM/YYYY)"].ToString();

    //                bool WJD = JD.Contains(".");

    //                if (WJD)
    //                    JD = JD.Replace(".", "/");
    //                bool Chkdate = CheckDateFormat(JD);
    //                if (Chkdate == false)
    //                {
    //                    errormsg = errormsg + "," + "Enter Correct Joining Date";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = columnno + "," + "Joining Date*(DD/MM/YYYY)";

    //                }


    //                //JOINDAT = JD;


    //                //jdate = new DateTime();
    //                //jdate = DateTime.ParseExact(JOINDAT, "dd/MM/yyyy", null);






    //                //DateTime.TryParse(Convert.ToString(jdate), out  b);
    //                //if (b != DateTime.MinValue)
    //                //{
    //                //}
    //                //else
    //                //{
    //                //    filestatus = false;
    //                //    rowno = i + 2;
    //                //    columnno = columnno + "," + "Joining Date*(DD/MM/YYYY)";
    //                //}


    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Joining Date*(DD/MM/YYYY)";

    //            }
    //            if (ds_experiance.Tables[0].Rows[i]["Join Salary*"].ToString().Trim() != "")
    //            {
    //                int b;
    //                int.TryParse(Convert.ToString(ds_experiance.Tables[0].Rows[i]["Join Salary*"]), out  b);
    //                if (b != 0) //year of integer length 4 only
    //                {

    //                }
    //                else
    //                {
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = columnno + "," + "Join Salary*";

    //                }
    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Join Salary*";

    //            }








    //            if (ds_experiance.Tables[0].Rows[i]["Join Position*"].ToString().Trim() != "")
    //            {


    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Join Position*";


    //            }
    //            if (ds_experiance.Tables[0].Rows[i]["Reason For Relieving*"].ToString().Trim() != "")
    //            {


    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Reason For Relieving*";


    //            }
    //            if (ds_experiance.Tables[0].Rows[i]["Relieving Date*(DD/MM/YYYY)"].ToString().Trim() != "")
    //            {

    //                //DateTime b;

    //                string reldate = "";

    //                reldate = ds_experiance.Tables[0].Rows[i]["Relieving Date*(DD/MM/YYYY)"].ToString();

    //                bool wrongsdformat1 = reldate.Contains(".");

    //                if (wrongsdformat1)
    //                    reldate = reldate.Replace(".", "/");

    //                bool Chkdate = CheckDateFormat(reldate);
    //                if (Chkdate == false)
    //                {
    //                    errormsg = errormsg + "," + "Enter Correct Releving Date";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = columnno + "," + "Relieving Date*(DD/MM/YYYY)";

    //                }
    //                //RELDAT = reldate;
    //                //rdate = new DateTime();
    //                //rdate = DateTime.ParseExact(RELDAT, "dd/MM/yyyy", null);
    //                //DateTime.TryParse(Convert.ToString(rdate), out  b);
    //                //if (b != DateTime.MinValue)
    //                //{
    //                //}
    //                //else
    //                //{
    //                //    filestatus = false;
    //                //    rowno = i + 2;
    //                //    columnno = columnno + "," + "Relieving Date*(DD/MM/YYYY)";
    //                //}

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Relieving Date*(DD/MM/YYYY)";


    //            }

    //            if (ds_experiance.Tables[0].Rows[i]["Relieving Salary*"].ToString().Trim() != "")
    //            {
    //                //string date = Convert.ToString(ds.Tables[0].Rows[i]["Date of Birth*"]);
    //                //string st = date.Substring(0, 10);

    //                int b;
    //                int.TryParse(Convert.ToString(ds_experiance.Tables[0].Rows[i]["Relieving Salary*"]), out  b);
    //                if (b != 0) //year of integer length 4 only
    //                {

    //                }
    //                else
    //                {
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = columnno + "," + "Relieving Salary*";

    //                }
    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Relieving Salary*";
    //            }


    //            if (ds_experiance.Tables[0].Rows[i]["Relieving Position*"].ToString().Trim() != "")
    //            {


    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Relieving Position*";


    //            }

    //            if (filestatus == false)
    //            {
    //                DataRow newrow = dtfail_experiance.NewRow();
    //                newrow["S.NO"] = dtfail_experiance.Rows.Count + 1;


    //                newrow["ROWNO"] = rowno;
    //                newrow["COLUMNS NAMES"] = columnno;
    //                dtfail_experiance.Rows.Add(newrow);
    //                ds_experiance.Tables[0].Rows[i]["Error Message"] = errormsg;


    //            }


    //        }


    //        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    //        // @@@@@@@@@@@@@@@@@@@@@@@@--To check contact details in excel

    //        for (int i = 0; i < ds_contact.Tables[0].Rows.Count; i++)
    //        {
    //            if (ds_contact.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() != "")
    //            {

    //                bool status1 = false;

    //                for (int j = 0; j < ds_directemp.Tables[0].Rows.Count; j++)
    //                {
    //                    if (ds_contact.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() == ds_directemp.Tables[0].Rows[j]["Applicant SNO*"].ToString().Trim())
    //                    {
    //                        status1 = true;
    //                        break;

    //                    }
    //                }
    //                if (status1 == false)
    //                {
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = "Applicant SNO*";

    //                }

    //                // string aplicantcode = ds_contact.Tables[0].Rows[i]["Applicant Code*"].ToString();
    //                // SMHR_APPLICANT _obj_smhr_applicant = new SMHR_APPLICANT();
    //                // _obj_smhr_applicant.APPLICANT_CODE = aplicantcode;
    //                // _obj_smhr_applicant.OPERATION = operation.Check;
    //                // _obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                // DataTable dt_app_id = BLL.get_Applicant(_obj_smhr_applicant);

    //                //if (dt_app_id.Rows.Count > 0)//APPLICANT_ID
    //                //{
    //                //    app_id = Convert.ToInt32(dt_app_id.Rows[0]["APPLICANT_ID"]);
    //                //}
    //                //else
    //                //{
    //                //    filestatus = false;
    //                //    rowno = i + 2;
    //                //    columnno = "Applicant Code*";
    //                //}

    //            }
    //            else
    //            {
    //                //    filestatus = false;
    //                //    rowno = i + 2;
    //                //    columnno = "Applicant SNO*";
    //            }

    //            if (ds_contact.Tables[0].Rows[i]["Company Name*"].ToString().Trim() != "")
    //            {

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Company Name*";

    //            }

    //            if (ds_contact.Tables[0].Rows[i]["Contact Person*"].ToString().Trim() != "")
    //            {

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Contact Person*";

    //            }

    //            if (ds_contact.Tables[0].Rows[i]["Phone Number*"].ToString().Trim() != "")
    //            {

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Phone Number*";

    //            }
    //            if (ds_contact.Tables[0].Rows[i]["Address*"].ToString().Trim() != "")
    //            {

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Address*";

    //            }

    //            if (filestatus == false)
    //            {
    //                DataRow newrow = dtfail_contacts.NewRow();
    //                newrow["S.NO"] = dtfail_contacts.Rows.Count + 1;


    //                newrow["ROWNO"] = rowno;
    //                newrow["COLUMNS NAMES"] = columnno;
    //                dtfail_contacts.Rows.Add(newrow);
    //            }


    //        }



    //        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@



    //        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@--To check the language data in excel 

    //        for (int i = 0; i < ds_language.Tables[0].Rows.Count; i++)
    //        {
    //            if (ds_language.Tables[0].Rows[i]["APPlicant SNO*"].ToString().Trim() != "")
    //            {

    //                bool status1 = false;

    //                for (int j = 0; j < ds_directemp.Tables[0].Rows.Count; j++)
    //                {
    //                    if (ds_language.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() == ds_directemp.Tables[0].Rows[j]["Applicant SNO*"].ToString().Trim())
    //                    {





    //                        status1 = true;
    //                        break;

    //                    }
    //                }

    //                for (int k = 0; k < ds_language.Tables[0].Rows.Count; k++)
    //                {
    //                    for (int l = 0; l < ds_language.Tables[0].Rows.Count; l++)
    //                    {
    //                        if (k != l)
    //                        {
    //                            if (ds_language.Tables[0].Rows[k]["Applicant SNO*"].ToString().Trim() == ds_language.Tables[0].Rows[l]["Applicant SNO*"].ToString().Trim() && ds_language.Tables[0].Rows[k]["Language*"].ToString().Trim() == ds_language.Tables[0].Rows[l]["Language*"].ToString().Trim())
    //                            {
    //                                filestatus = false;//already exist in excel
    //                                rowno = i + 2;
    //                                columnno = columnno + "," + "Language*";
    //                                break;
    //                            }
    //                        }
    //                    }
    //                }
    //                if (status1 == false)
    //                {
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = "APPlicant SNO*";

    //                }

    //                //string aplicantcode = ds_language.Tables[0].Rows[i]["APPlicant Code*"].ToString();
    //                //SMHR_APPLICANT _obj_smhr_applicant = new SMHR_APPLICANT();
    //                //_obj_smhr_applicant.APPLICANT_CODE = aplicantcode;
    //                //_obj_smhr_applicant.OPERATION = operation.Check;
    //                //_obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                //DataTable dt_app_id = BLL.get_Applicant(_obj_smhr_applicant);

    //                //if (dt_app_id.Rows.Count > 0)//APPLICANT_ID
    //                //{
    //                //    app_id = Convert.ToInt32(dt_app_id.Rows[0]["APPLICANT_ID"]);
    //                //}
    //                //else
    //                //{
    //                //    filestatus = false;
    //                //    rowno = i + 2;
    //                //    columnno = "APPlicant Code*";
    //                //}




    //            }
    //            //else
    //            //{
    //            //    filestatus = false;
    //            //    rowno = i + 2;
    //            //    columnno = "APPlicant SNO*";
    //            //}


    //            if (ds_language.Tables[0].Rows[i]["Language*"].ToString().Trim() != "")
    //            {
    //                SMHR_MASTERS _Obj_smhr_Masters = new SMHR_MASTERS();
    //                _Obj_smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                _Obj_smhr_Masters.OPERATION = operation.Select;
    //                _Obj_smhr_Masters.MASTER_TYPE = "LANGUAGE";
    //                _Obj_smhr_Masters.MASTER_CODE = ds_language.Tables[0].Rows[i]["Language*"].ToString().Trim();
    //                DataTable dt_nat = BLL.get_Applicant_Validate(_Obj_smhr_Masters);
    //                if (Convert.ToInt32(dt_nat.Rows.Count) > 0)
    //                {

    //                }
    //                else
    //                {
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = columnno + "," + "Language*";


    //                }
    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Language*";


    //            }

    //            if (ds_language.Tables[0].Rows[i]["Read"].ToString().Trim() != "")
    //            {
    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Read";


    //            }
    //            if (ds_language.Tables[0].Rows[i]["Write"].ToString().Trim() != "")
    //            {
    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Write";


    //            }
    //            if (ds_language.Tables[0].Rows[i]["Speak"].ToString().Trim() != "")
    //            {
    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Speak";


    //            }
    //            if (ds_language.Tables[0].Rows[i]["Understand"].ToString().Trim() != "")
    //            {
    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Understand";


    //            }
    //            if (filestatus == false)
    //            {
    //                DataRow newrow = dtfail_language.NewRow();
    //                newrow["S.NO"] = dtfail_language.Rows.Count + 1;


    //                newrow["ROWNO"] = rowno;
    //                newrow["COLUMNS NAMES"] = columnno;
    //                dtfail_language.Rows.Add(newrow);
    //            }
    //        }







    //        if (dtfail_DirectEmp.Rows.Count > 0 || dtfail_Qualification.Rows.Count > 0 || dtfail_Skills.Rows.Count > 0 || dtfail_experiance.Rows.Count > 0 || dtfail_contacts.Rows.Count > 0 || dtfail_language.Rows.Count > 0 || dtfail_family.Rows.Count > 0 || dtfail_weeklyoff.Rows.Count > 0 || dtfail_empod.Rows.Count > 0 || dtfail_emphy.Rows.Count > 0)
    //        {
    //            Session["dt_fail1"] = dtfail_DirectEmp;
    //            Session["ds_data1"] = ds_directemp;

    //            Session["DT_FAIL_QUALI1"] = dtfail_Qualification;
    //            Session["DT_DATA_QUALI1"] = ds_Qualification;

    //            Session["DT_FAIL_SKILLS1"] = dtfail_Skills;
    //            Session["DT_DATA_SKILLS1"] = ds_skills;

    //            Session["DT_FAIL_EXPERIANCE1"] = dtfail_experiance;
    //            Session["DT_DATA_EXPERIANCE1"] = ds_experiance;

    //            Session["DT_FAIL_CONTACT1"] = dtfail_contacts;
    //            Session["DT_DATA_CONTACT1"] = ds_contact;

    //            Session["DT_FAIL_LANGUAGE1"] = dtfail_language;
    //            Session["DT_DATA_LANGUAGE1"] = ds_language;

    //            Session["dt_fail_FAM1"] = dtfail_family;
    //            Session["ds_data_fam1"] = ds_Family;

    //            Session["dt_fail_weof1"] = dtfail_weeklyoff;
    //            Session["ds_data_weof1"] = ds_weeklyOff;

    //            Session["dt_fail_od1"] = dtfail_empod;
    //            Session["ds_data_od1"] = ds_Otherdetails;

    //            Session["dt_fail_phd1"] = dtfail_emphy;
    //            Session["ds_data_phd1"] = ds_physicaldetails;

    //            Delete_Excel_File();
    //            //LinkButton lnk_Import_process = (LinkButton)RadPanelBar1.FindItemByValue("AddAttachment").FindControl("lnk_Import_process");
    //            Telerik.Web.UI.RadWindow newwindow = new Telerik.Web.UI.RadWindow();
    //            // RWM_POSTREPLY.Windows.Remove(newwindow);
    //            newwindow.ID = "RadWindow_import";

    //            newwindow.NavigateUrl = "~/HR/DirectEmployerror.aspx";
    //            newwindow.Title = "Import Process";
    //            newwindow.Width = 1150;
    //            newwindow.Height = 580;
    //            newwindow.VisibleOnPageLoad = true;
    //            if (RWM_POSTREPLY1.Windows.Count > 1)
    //            {
    //                RWM_POSTREPLY1.Windows.RemoveAt(1);
    //            }
    //            RWM_POSTREPLY1.Windows.Add(newwindow);



    //            RWM_POSTREPLY1.Visible = true;
    //            return;

    //        }
    //        else
    //        {

    //            ds_directemp.Tables[0].Columns.Add("ApplicantID");
    //            ds_directemp.Tables[0].Columns.Add("EMPLOYEEID");


    //            for (int i = 0; i < ds_directemp.Tables[0].Rows.Count; i++)
    //            {
    //                _obj_smhr_applicant = new SMHR_APPLICANT();
    //                bool status = false;
    //                SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
    //                _obj_Smhr_BusinessUnit.OPERATION = operation.Get_BU;
    //                _obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                DataTable dt_bu = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
    //                if (Convert.ToString(dt_bu.Rows[0]["ORGANISATION_EMPCODE_MANUAL"]) == "True")
    //                {
    //                    //_obj_smhr_applicant.APPLICANT_CODE = Convert.ToString(ds_directemp.Tables[0].Rows[i]["Employee Code (If Manual)"]).Trim();
    //                    Session["ORGANISATION_EMPCODE_MANUAL"] = "MANUAL";

    //                }


    //                getCode();
    //                _obj_smhr_applicant.APPLICANT_CODE = aplicantcode;



    //                _obj_smhr_applicant.OPERATION = operation.Insert1;
    //                _obj_smhr_applicant.APPLICANT_TITLE = Convert.ToString(ds_directemp.Tables[0].Rows[i]["Title*"]).Trim();
    //                _obj_smhr_applicant.APPLICANT_FIRSTNAME = (Convert.ToString(ds_directemp.Tables[0].Rows[i]["First Name*"]).Replace("'", "''"));
    //                _obj_smhr_applicant.APPLICANT_MIDDLENAME = (Convert.ToString(ds_directemp.Tables[0].Rows[i]["Middle Name"]).Replace("'", "''"));
    //                _obj_smhr_applicant.APPLICANT_LASTNAME = (Convert.ToString(ds_directemp.Tables[0].Rows[i]["Last Name"]).Replace("'", "''"));
    //                _obj_smhr_applicant.APPLI_DOB = Convert.ToString(ds_directemp.Tables[0].Rows[i]["Date of Birth*(DD/MM/YYYY)"]);
    //                // _obj_smhr_applicant.APPLICANT_DOB = Convert.ToDateTime(ds.Tables[0].Rows[i]["Date of Birth*(MM/DD/YYYY)"]);
    //                _obj_smhr_applicant.APPLICANT_GENDER = Convert.ToString(ds_directemp.Tables[0].Rows[i]["Gender*"]).Trim();
    //                _obj_smhr_applicant.APPLICANT_BLOODGROUP = Convert.ToString(ds_directemp.Tables[0].Rows[i]["Blood Group*"]).Trim();


    //                SMHR_MASTERS _Obj_smhr_Masters = new SMHR_MASTERS();

    //                _Obj_smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                _Obj_smhr_Masters.MASTER_TYPE = "RELIGION";
    //                _Obj_smhr_Masters.OPERATION = operation.Select;

    //                _Obj_smhr_Masters.MASTER_CODE = ds_directemp.Tables[0].Rows[i]["Religion*"].ToString().Trim();
    //                DataTable dt_relig1 = BLL.get_Applicant_Validate(_Obj_smhr_Masters);


    //                _obj_smhr_applicant.APPLICANT_RELIGION_ID = Convert.ToInt32(dt_relig1.Rows[0]["HR_MASTER_ID"]);


    //                _Obj_smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                _Obj_smhr_Masters.MASTER_TYPE = "NATIONALITY";
    //                _Obj_smhr_Masters.OPERATION = operation.Select;
    //                _Obj_smhr_Masters.MASTER_CODE = ds_directemp.Tables[0].Rows[i]["Nationality*"].ToString().Trim();
    //                DataTable dt_nationality = BLL.get_Applicant_Validate(_Obj_smhr_Masters);

    //                _obj_smhr_applicant.APPLICANT_NATIONALITY_ID = Convert.ToInt32(dt_nationality.Rows[0]["HR_MASTER_ID"]);
    //                _obj_smhr_applicant.APPLICANT_STATUS = Convert.ToString(ds_directemp.Tables[0].Rows[i]["Status*"]).Trim();
    //                _obj_smhr_applicant.APPLICANT_MARITALSTATUS = Convert.ToString(ds_directemp.Tables[0].Rows[i]["Marital Status"]).Trim();
    //                _obj_smhr_applicant.APPLICANT_ADDRESS = Convert.ToString(ds_directemp.Tables[0].Rows[i]["Address*"]);
    //                _obj_smhr_applicant.APPLICANT_REMARKS = Convert.ToString(ds_directemp.Tables[0].Rows[i]["Remarks"]);
    //                _obj_smhr_applicant.APPLICANT_TYPE = string.Empty;
    //                _obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                _obj_smhr_applicant.APPLICANT_CREATEDBY = Convert.ToString(Session["USER_ID"]);
    //                _obj_smhr_applicant.APPLICANT_CREATEDDATE = DateTime.Now;
    //                status = BLL.set_Applicant(_obj_smhr_applicant);

    //                _obj_smhr_applicant.OPERATION = operation.Get;
    //                DataTable dt_apidq = BLL.get_Applicant(_obj_smhr_applicant);

    //                int Applicid = Convert.ToInt32(dt_apidq.Rows[0]["applicant_id"]);

    //                ds_directemp.Tables[0].Rows[i]["ApplicantID"] = Applicid;



    //                //@@@@@@@converting to employee

    //                for (int count = 0; count < ddl_EmpStatus.Items.Count; count++)
    //                {
    //                    if ((ds_directemp.Tables[0].Rows[i]["Employee Type*"].ToString().Trim()) == ddl_EmpStatus.Items[count].Text)
    //                    {
    //                        emp_status = Convert.ToString(ddl_EmpStatus.Items[count].Value);

    //                    }





    //                }

    //                for (int count = 0; count < ddl_BusinessUnit.Items.Count; count++)
    //                {
    //                    if ((ds_directemp.Tables[0].Rows[i]["Business Unit*"].ToString().Trim()) == ddl_BusinessUnit.Items[count].Text)
    //                    {
    //                        bu_id = Convert.ToInt32(ddl_BusinessUnit.Items[count].Value);

    //                    }

    //                }
    //                if (bu_id != 0)
    //                {
    //                    LoadMode();
    //                    LoadCurrency();
    //                    getPosition();
    //                    // LoadDates();
    //                    LoadDepartment();
    //                    getSupervisor();
    //                    get_SupBusinessUnit();


    //                }


    //                if (Convert.ToString(Session["ORGANISATION_EMPCODE_MANUAL"]) == "MANUAL")
    //                {
    //                    _obj_smhr_employee.EMP_EMPCODE = Convert.ToString(ds_directemp.Tables[0].Rows[i]["Employee Code (If Manual)"]).Trim();

    //                }

    //                else
    //                {

    //                    getEmpCode();


    //                    _obj_smhr_employee.EMP_EMPCODE = Convert.ToString(lbl_Code.Text.Replace("'", "''"));
    //                }
    //                _obj_smhr_employee.EMP_BUSINESSUNIT_ID = bu_id;
    //                _obj_smhr_employee.EMP_APPLICANT_ID = Applicid;
    //                //  _obj_smhr_employee.EMP_DOJ = Convert.ToDateTime(ds.Tables[0].Rows[i]["DateOfJoin*"]);
    //                // _obj_smhr_employee.EMP_DATEOFJOIN=

    //                if (Convert.ToString(ds_directemp.Tables[0].Rows[i]["DateOfJoin*(dd/mm/yyyy)"]).Contains("."))
    //                {
    //                    _obj_smhr_employee.EMP_DATEOFJOIN = Convert.ToString(ds_directemp.Tables[0].Rows[i]["DateOfJoin*(dd/mm/yyyy)"]).Replace(".", "/");

    //                }
    //                else
    //                {
    //                    _obj_smhr_employee.EMP_DATEOFJOIN = Convert.ToString(ds_directemp.Tables[0].Rows[i]["DateOfJoin*(dd/mm/yyyy)"]);

    //                }
    //                if (Convert.ToString(ds_directemp.Tables[0].Rows[i]["Date of Confirm*(dd/mm/yyyy)"]).Contains("."))
    //                {
    //                    _obj_smhr_employee.EMP_DATEOFCONFORM = Convert.ToString(ds_directemp.Tables[0].Rows[i]["Date of Confirm*(dd/mm/yyyy)"]).Replace(".", "/");

    //                }
    //                else
    //                {
    //                    _obj_smhr_employee.EMP_DATEOFCONFORM = Convert.ToString(ds_directemp.Tables[0].Rows[i]["Date of Confirm*(dd/mm/yyyy)"]);

    //                }

    //                //  _obj_smhr_employee.EMP_DOC = Convert.ToDateTime(ds.Tables[0].Rows[i]["Date of Confirm*"]);
    //                // _obj_smhr_employee.EMP_RPTSTARTDATE = Convert.ToDateTime(ds.Tables[0].Rows[i]["DateOfJoin*"]);
    //                _obj_smhr_employee.EMP_rpt = Convert.ToString(ds_directemp.Tables[0].Rows[i]["DateOfJoin*(dd/mm/yyyy)"]);

    //                for (int count = 0; count < ddl_Mode.Items.Count; count++)
    //                {
    //                    if ((ds_directemp.Tables[0].Rows[i]["Payment Mode*"].ToString().Trim()) == ddl_Mode.Items[count].Text)
    //                    {
    //                        _obj_smhr_employee.EMP_PAYMENTMODE_ID = Convert.ToInt32(ddl_Mode.Items[count].Value);

    //                    }
    //                }
    //                for (int count = 0; count < ddl_Department.Items.Count; count++)
    //                {
    //                    if ((ds_directemp.Tables[0].Rows[i]["Department*"].ToString().Trim()) == ddl_Department.Items[count].Text)
    //                    {
    //                        _obj_smhr_employee.EMP_DEPARTMENT_ID = Convert.ToInt32(ddl_Department.Items[count].Value);

    //                    }
    //                }


    //                for (int count = 0; count < ddl_Designation.Items.Count; count++)
    //                {
    //                    if ((ds_directemp.Tables[0].Rows[i]["Position*"].ToString().Trim()) == ddl_Designation.Items[count].Text)
    //                    {
    //                        _obj_smhr_employee.EMP_DESIGNATION_ID = Convert.ToInt32(ddl_Designation.Items[count].Value);

    //                    }
    //                }

    //                for (int count = 0; count < ddl_EmpStatus.Items.Count; count++)
    //                {
    //                    if ((ds_directemp.Tables[0].Rows[i]["Employee Type*"].ToString().Trim()) == ddl_EmpStatus.Items[count].Text)
    //                    {
    //                        _obj_smhr_employee.EMP_EMPLOYEETYPE = Convert.ToString(ddl_EmpStatus.Items[count].Text);

    //                    }
    //                }



    //                for (int count = 0; count < ddl_Grade.Items.Count; count++)
    //                {
    //                    if ((ds_directemp.Tables[0].Rows[i]["Grade"].ToString().Trim()) == ddl_Grade.Items[count].Text)
    //                    {
    //                        _obj_smhr_employee.EMP_GRADE = Convert.ToInt32(ddl_Grade.Items[count].Value);

    //                    }
    //                }

    //                for (int count = 0; count < ddl_LeaveStructure.Items.Count; count++)
    //                {
    //                    if ((ds_directemp.Tables[0].Rows[i]["Leave Structure*"].ToString().Trim()) == ddl_LeaveStructure.Items[count].Text)
    //                    {
    //                        _obj_smhr_employee.EMP_LEAVESTRUCT_ID = Convert.ToInt32(ddl_LeaveStructure.Items[count].Value);

    //                    }
    //                }
    //                for (int count = 0; count < ddl_SalaryStructure.Items.Count; count++)
    //                {
    //                    if ((ds_directemp.Tables[0].Rows[i]["Salary Structure*"].ToString().Trim()) == ddl_SalaryStructure.Items[count].Text)
    //                    {
    //                        _obj_smhr_employee.EMP_SALALRYSTRUCT_ID = Convert.ToInt32(ddl_SalaryStructure.Items[count].Value);

    //                    }
    //                }
    //                for (int count = 0; count < ddl_Currency.Items.Count; count++)
    //                {
    //                    if ((ds_directemp.Tables[0].Rows[i]["Currency*"].ToString().Trim()) == ddl_Currency.Items[count].Text)
    //                    {
    //                        _obj_smhr_employee.EMP_PAYCURRENCY = Convert.ToInt32(ddl_Currency.Items[count].Value);


    //                    }
    //                }
    //                for (int count = 0; count < ddl_Shift.Items.Count; count++)
    //                {
    //                    if ((ds_directemp.Tables[0].Rows[i]["Shift*"].ToString().Trim()) == ddl_Shift.Items[count].Text)
    //                    {
    //                        _obj_smhr_employee.EMP_SHIFT_ID = Convert.ToInt32(ddl_Shift.Items[count].Value);

    //                    }
    //                }

    //                for (int count = 0; count < ddl_Sup_BusinessUnit.Items.Count; count++)
    //                {
    //                    if ((ds_directemp.Tables[0].Rows[i]["Supervisor Business Unit"].ToString().Trim()) == ddl_Sup_BusinessUnit.Items[count].Text)
    //                    {
    //                        Sbuid = Convert.ToInt32(ddl_Sup_BusinessUnit.Items[count].Value);
    //                        _obj_smhr_employee.EMP_SUPBUSINESSUNIT_ID = Convert.ToInt32(ddl_Sup_BusinessUnit.Items[count].Value);

    //                    }
    //                }

    //                _obj_SMHR_LoginInfo = new SMHR_LOGININFO();


    //                _obj_SMHR_LoginInfo.OPERATION = operation.Get;
    //                _obj_SMHR_LoginInfo.BUID = Sbuid;
    //                DataTable dt_getEMP = BLL.get_Sup_BusinessUnit(_obj_SMHR_LoginInfo);

    //                ddl_Supervisor.Items.Clear();
    //                ddl_Supervisor.DataSource = dt_getEMP;
    //                ddl_Supervisor.DataTextField = "EMP_EMPCODE";
    //                ddl_Supervisor.DataValueField = "EMP_ID";
    //                ddl_Supervisor.DataBind();



    //                for (int count = 0; count < ddl_Supervisor.Items.Count; count++)
    //                {
    //                    //string code1 = "";
    //                    //code1 = ddl_Supervisor.Items[count].Text;
    //                    //bool name = code1.Contains("-");
    //                    //if (name)
    //                    //{
    //                    //    int index = code1.IndexOf("-");
    //                    //    code1 = code1.Substring(0, index);

    //                    //}
    //                    if ((ds_directemp.Tables[0].Rows[i]["Supervisor"].ToString().Trim()) == ddl_Supervisor.Items[count].Text.Trim())
    //                    {
    //                        _obj_smhr_employee.EMP_REPORTINGEMPLOYEE = Convert.ToInt32(ddl_Supervisor.Items[count].Value);

    //                    }
    //                }
    //                if ((ds_directemp.Tables[0].Rows[i]["Employee Type*"].ToString().Trim().ToUpper()) == "CONTRACT")
    //                {
    //                    _obj_smhr_employee.EMP_BASIC = Convert.ToInt32(ds_directemp.Tables[0].Rows[i]["Gross Salary*"]);
    //                }
    //                else
    //                {
    //                    //code for getting Basic percentage of Gross For the businessunit selected
    //                    _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
    //                    _obj_smhr_businessunit.OPERATION = operation.Select;
    //                    _obj_smhr_businessunit.BUSINESSUNIT_ID = bu_id;
    //                    _obj_smhr_businessunit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                    DataTable dt_BusinessUnit = BLL.get_BusinessUnit(_obj_smhr_businessunit);

    //                    float IBasicPercent = Convert.ToSingle(dt_BusinessUnit.Rows[0]["BUSINESSUNIT_BASICPERCENT"]);

    //                    float emp_GrossSal = Convert.ToSingle(Convert.ToInt32(ds_directemp.Tables[0].Rows[i]["Gross Salary*"]));
    //                    //float emp_BasicSal = (55 * emp_GrossSal) / 100;
    //                    float emp_BasicSal = (IBasicPercent * emp_GrossSal) / 100;
    //                    _obj_smhr_employee.EMP_BASIC = emp_BasicSal;
    //                }



    //                //_obj_smhr_employee.EMP_PROBATIONDATE = Convert.ToDateTime(ds.Tables[0].Rows[i]["Probation Date"]);
    //                _obj_smhr_employee.EMP_PROBDATE = ds_directemp.Tables[0].Rows[i]["Probation Date(dd/mm/yyyy)"].ToString().Trim();
    //                // _obj_smhr_employee.EMP_DATEOFLASTPROMOTION = Convert.ToDateTime(ds.Tables[0].Rows[i]["Previous Promotion"]);
    //                _obj_smhr_employee.EMP_DATEOLP = ds_directemp.Tables[0].Rows[i]["Previous Promotion(dd/mm/yyyy)"].ToString().Trim();

    //                if (ds_directemp.Tables[0].Rows[i]["Notification Period"].ToString() == string.Empty)
    //                {
    //                    _obj_smhr_employee.EMP_NOTICEPERIOD = 0;
    //                }
    //                else
    //                {
    //                    _obj_smhr_employee.EMP_NOTICEPERIOD = Convert.ToInt32(ds_directemp.Tables[0].Rows[i]["Notification Period"]);
    //                }
    //                // _obj_smhr_employee.EMP_CONTRACT_DATE = Convert.ToDateTime(ds.Tables[0].Rows[i]["Contract Date*"]);
    //                _obj_smhr_employee.EMP_CONTRDATE = ds_directemp.Tables[0].Rows[i]["Contract Date*(dd/mm/yyyy)"].ToString().Trim();
    //                _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);


    //                _obj_smhr_employee.EMP_HOBBIES = ds_directemp.Tables[0].Rows[i]["Hobbies"].ToString();
    //                if (ds_directemp.Tables[0].Rows[i]["Is VariablePay"].ToString().Trim().ToUpper() == "TRUE")
    //                {
    //                    DataTable dt_isvariablepay = BLL.get_Organisation_Isvp(Convert.ToString(Session["ORG_ID"]), Convert.ToString(bu_id));
    //                    if (Convert.ToString(dt_isvariablepay.Rows[0]["BUSINESSUNIT_ISVARIABLEAMOUNT"]) == "True")// 1 MEANS THAT ORGANISATION IS HAVING VARIABLE PAY
    //                    {
    //                        _obj_smhr_employee.EMP_ISVARIABLEPAY = true;
    //                        _obj_smhr_employee.EMP_VPPAYABLECOUNT = Convert.ToInt32(Math.Round(Convert.ToDouble(Convert.ToInt32(ds_directemp.Tables[0].Rows[i]["No Of Times Payable"])), 0));
    //                        _obj_smhr_employee.EMP_VARIABLEAMT = Convert.ToInt32(Math.Round(Convert.ToDouble(Convert.ToString(ds_directemp.Tables[0].Rows[i]["Variable Amount"])), 0));
    //                    }
    //                }
    //                else
    //                {
    //                    _obj_smhr_employee.EMP_ISVARIABLEPAY = false;
    //                    _obj_smhr_employee.EMP_VARIABLEAMT = 0;
    //                    _obj_smhr_employee.EMP_VPPAYABLECOUNT = 0;
    //                }
    //                _obj_smhr_employee.EMP_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
    //                _obj_smhr_employee.EMP_CREATEDDATE = DateTime.Now;
    //                _obj_smhr_employee.EMP_EMPLOYEE_STATUS = Convert.ToInt32(ddl_Employee_Status.SelectedValue);
    //                _obj_smhr_employee.OPERATION = operation.Insert1;


    //                status = BLL.set_Employee(_obj_smhr_employee);

    //                _obj_smhr_employee.OPERATION = operation.Check;
    //                DataTable dt_empid = BLL.get_Employee(_obj_smhr_employee);
    //                int EMPID = Convert.ToInt32(dt_empid.Rows[0]["EMP_ID"]);

    //                ds_directemp.Tables[0].Rows[i]["EMPLOYEEID"] = EMPID;


    //            }//first for loop ds_directemp

    //            ////inserting Qualification details in to database
    //            for (int i = 0; i < ds_Qualification.Tables[0].Rows.Count; i++)
    //            {

    //                bool status = false;
    //                // columnno = string.Empty;
    //                int applicant_id = 0;
    //                if (ds_Qualification.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() != "")
    //                {
    //                    bool status_qualification = false;


    //                    for (int j = 0; j < ds_directemp.Tables[0].Rows.Count; j++)
    //                    {
    //                        if (ds_Qualification.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() == ds_directemp.Tables[0].Rows[j]["Applicant SNO*"].ToString().Trim())
    //                        {
    //                            status_qualification = true;
    //                            applicant_id = Convert.ToInt32(ds_directemp.Tables[0].Rows[j]["ApplicantID"]);

    //                            break;

    //                        }

    //                    }
    //                    if (status_qualification == true)
    //                    {

    //                        SMHR_MASTERS _Obj_smhr_Masters = new SMHR_MASTERS();
    //                        _Obj_smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                        _Obj_smhr_Masters.OPERATION = operation.Select;
    //                        _Obj_smhr_Masters.MASTER_TYPE = "QUALIFICATION";
    //                        _Obj_smhr_Masters.MASTER_CODE = ds_Qualification.Tables[0].Rows[i]["Category*"].ToString().Trim();
    //                        DataTable dt_Quali = BLL.get_Applicant_Validate(_Obj_smhr_Masters);
    //                        _obj_smhr_applicant.APPLICANT_ID = applicant_id;

    //                        _obj_smhr_applicant.APPQFN_QUALIFICATION_ID = Convert.ToInt32(Convert.ToString(dt_Quali.Rows[0]["HR_MASTER_ID"]));
    //                        _obj_smhr_applicant.APPQFN_INSTITUTE = Convert.ToString(ds_Qualification.Tables[0].Rows[i]["Institute*"].ToString().Trim());
    //                        _obj_smhr_applicant.APPQFN_PASSEDYEAR = Convert.ToInt32(Convert.ToString(ds_Qualification.Tables[0].Rows[i]["Year of pass*"].ToString().Trim()));
    //                        _obj_smhr_applicant.APPQFN_PERCENTAGE = Convert.ToInt32(Convert.ToString(ds_Qualification.Tables[0].Rows[i]["Percentage*"].ToString().Trim()));
    //                        _obj_smhr_applicant.APPQFN_GRADE = Convert.ToString(ds_Qualification.Tables[0].Rows[i]["Grade*"].ToString().Trim());
    //                        _obj_smhr_applicant.APPQFN_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
    //                        _obj_smhr_applicant.APPQFN_CREATEDDATE = DateTime.Now;
    //                        _obj_smhr_applicant.OPERATION = operation.Insert;
    //                        status = BLL.set_AppQualification(_obj_smhr_applicant);

    //                    }


    //                }
    //            }
    //            //// inserting skills data into database from excel

    //            for (int i = 0; i < ds_skills.Tables[0].Rows.Count; i++)
    //            {

    //                bool status = false;
    //                // columnno = string.Empty;
    //                int applicant_id = 0;

    //                if (ds_skills.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() != "")
    //                {
    //                    bool status_skills = false;

    //                    for (int j = 0; j < ds_directemp.Tables[0].Rows.Count; j++)
    //                    {
    //                        if (ds_skills.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() == ds_directemp.Tables[0].Rows[j]["Applicant SNO*"].ToString().Trim())
    //                        {
    //                            status_skills = true;
    //                            applicant_id = Convert.ToInt32(ds_directemp.Tables[0].Rows[j]["ApplicantID"]);

    //                            break;

    //                        }
    //                    }

    //                    if (status_skills == true)
    //                    {

    //                        SMHR_MASTERS _Obj_smhr_Masters = new SMHR_MASTERS();

    //                        _Obj_smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                        _Obj_smhr_Masters.MASTER_TYPE = "SKILL";
    //                        _Obj_smhr_Masters.OPERATION = operation.Select;

    //                        _Obj_smhr_Masters.MASTER_CODE = ds_skills.Tables[0].Rows[i]["Skill Name*"].ToString().Trim();
    //                        DataTable dt_skill1 = BLL.get_Applicant_Validate(_Obj_smhr_Masters);

    //                        _obj_smhr_applicant.APPLICANT_ID = applicant_id;

    //                        _obj_smhr_applicant.APPSKL_SKILL_ID = Convert.ToInt32(dt_skill1.Rows[0]["HR_MASTER_ID"]);

    //                        _obj_smhr_applicant.APPSKL_LASTUSED = Convert.ToInt32(ds_skills.Tables[0].Rows[i]["Last Used*"]);
    //                        _obj_smhr_applicant.OPERATION = operation.Insert;
    //                        _obj_smhr_applicant.APPSKL_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
    //                        _obj_smhr_applicant.APPSKL_CREATEDDATE = DateTime.Now;
    //                        if (ds_skills.Tables[0].Rows[i]["Expertise*"].ToString().Trim() != "")
    //                        {
    //                            if (ds_skills.Tables[0].Rows[i]["Expertise*"].ToString().Trim() == "Beginner")
    //                            {
    //                                _obj_smhr_applicant.APPSKL_EXPERT = 1;
    //                            }
    //                            else if (ds_skills.Tables[0].Rows[i]["Expertise*"].ToString().Trim() == "Intermediate")
    //                            {
    //                                _obj_smhr_applicant.APPSKL_EXPERT = 2;
    //                            }
    //                            else if (ds_skills.Tables[0].Rows[i]["Expertise*"].ToString().Trim() == "Expert")
    //                            {
    //                                _obj_smhr_applicant.APPSKL_EXPERT = 3;

    //                            }
    //                        }

    //                        status = BLL.set_ApplicantSkills(_obj_smhr_applicant);

    //                    }


    //                }
    //            }


    //            ////inserting experiance data into database from excel


    //            for (int i = 0; i < ds_experiance.Tables[0].Rows.Count; i++)
    //            {
    //                bool status = false;
    //                // columnno = string.Empty;
    //                int applicant_id = 0;
    //                if (ds_experiance.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() != "")
    //                {

    //                    bool status_experience = false;

    //                    for (int j = 0; j < ds_directemp.Tables[0].Rows.Count; j++)
    //                    {
    //                        if (ds_experiance.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() == ds_directemp.Tables[0].Rows[j]["Applicant SNO*"].ToString().Trim())
    //                        {
    //                            status_experience = true;
    //                            applicant_id = Convert.ToInt32(ds_directemp.Tables[0].Rows[j]["ApplicantID"]);

    //                            break;

    //                        }
    //                    }


    //                    if (status_experience == true)
    //                    {

    //                        _obj_smhr_applicant.APPLICANT_ID = applicant_id;
    //                        _obj_smhr_applicant.APPEXP_APPLICANT_ID = applicant_id;
    //                        _obj_smhr_applicant.OPERATION = operation.Check_New;
    //                        DataTable dt_serial = BLL.get_ApplicantExperience(_obj_smhr_applicant);
    //                        _obj_smhr_applicant.APPEXP_SERIAL = Convert.ToInt32(dt_serial.Rows[0]["APPEXP_SERIAL"]) + 1;//get the number
    //                        _obj_smhr_applicant.APPEXP_COMPANY = Convert.ToString(ds_experiance.Tables[0].Rows[i]["Company Name*"].ToString().Trim()).Replace("'", "''");
    //                        // _obj_smhr_applicant.APPEXP_JOINDATE = Convert.ToDateTime(ds_experiance.Tables[0].Rows[i]["Joining Date*(DD/MM/YYYY)"]);
    //                        if (Convert.ToString(ds_experiance.Tables[0].Rows[i]["Joining Date*(DD/MM/YYYY)"]).Contains("."))
    //                        {
    //                            _obj_smhr_applicant.APPEXJOINDATE = Convert.ToString(ds_experiance.Tables[0].Rows[i]["Joining Date*(DD/MM/YYYY)"]).Replace(".", "/");

    //                        }
    //                        else
    //                        {
    //                            _obj_smhr_applicant.APPEXJOINDATE = Convert.ToString(ds_experiance.Tables[0].Rows[i]["Joining Date*(DD/MM/YYYY)"]);

    //                        }
    //                        _obj_smhr_applicant.APPEXP_JOINSAL = Convert.ToDouble(ds_experiance.Tables[0].Rows[i]["Join Salary*"]);
    //                        _obj_smhr_applicant.APPEXP_JOINDESC = Convert.ToString(ds_experiance.Tables[0].Rows[i]["Join Position*"].ToString().Trim()).Replace("'", "''");
    //                        _obj_smhr_applicant.APPEXP_REASONREL = Convert.ToString(ds_experiance.Tables[0].Rows[i]["Reason For Relieving*"].ToString().Trim()).Replace("'", "''");
    //                        // _obj_smhr_applicant.APPEXP_RELDATE = Convert.ToDateTime(ds_experiance.Tables[0].Rows[i]["Relieving Date*(DD/MM/YYYY)"]);
    //                        if (Convert.ToString(ds_experiance.Tables[0].Rows[i]["Relieving Date*(DD/MM/YYYY)"]).Contains("."))
    //                        {
    //                            _obj_smhr_applicant.APPEXRELDATE = Convert.ToString(ds_experiance.Tables[0].Rows[i]["Relieving Date*(DD/MM/YYYY)"]).Replace(".", "/");

    //                        }
    //                        else
    //                        {
    //                            _obj_smhr_applicant.APPEXRELDATE = Convert.ToString(ds_experiance.Tables[0].Rows[i]["Relieving Date*(DD/MM/YYYY)"]);

    //                        }
    //                        _obj_smhr_applicant.APPEXP_RELSAL = Convert.ToDouble(ds_experiance.Tables[0].Rows[i]["Relieving Salary*"]);
    //                        _obj_smhr_applicant.APPEXP_REASONDESC = Convert.ToString(ds_experiance.Tables[0].Rows[i]["Relieving Position*"].ToString().Trim()).Replace("'", "''");
    //                        _obj_smhr_applicant.APPEXP_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
    //                        _obj_smhr_applicant.APPEXP_CREATEDDATE = DateTime.Now;
    //                        _obj_smhr_applicant.OPERATION = operation.Insert1;
    //                        status = BLL.set_ApplicantExperience(_obj_smhr_applicant);





    //                    }


    //                }
    //            }
    //            ////Inserting Applicant contact data fron excel to database

    //            for (int i = 0; i < ds_contact.Tables[0].Rows.Count; i++)
    //            {
    //                bool status = false;
    //                // columnno = string.Empty;
    //                int applicant_id = 0;
    //                if (ds_contact.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() != "")
    //                {

    //                    bool status_contact = false;

    //                    for (int j = 0; j < ds_directemp.Tables[0].Rows.Count; j++)
    //                    {
    //                        if (ds_contact.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() == ds_directemp.Tables[0].Rows[j]["Applicant SNO*"].ToString().Trim())
    //                        {
    //                            status_contact = true;
    //                            applicant_id = Convert.ToInt32(ds_directemp.Tables[0].Rows[j]["ApplicantID"]);

    //                            break;

    //                        }
    //                    }
    //                    if (status_contact == true)
    //                    {
    //                        _obj_smhr_applicant.APPLICANT_ID = applicant_id;


    //                        _obj_smhr_applicant.APPCONT_COMPANY = (Convert.ToString(ds_contact.Tables[0].Rows[i]["Company Name*"]).Replace("'", "''"));
    //                        _obj_smhr_applicant.APPCONT_CONTACT = (Convert.ToString(ds_contact.Tables[0].Rows[i]["Contact Person*"]).Replace("'", "''"));
    //                        _obj_smhr_applicant.APPCONT_PHONE = (Convert.ToString(ds_contact.Tables[0].Rows[i]["Phone Number*"]).Replace("'", "''"));
    //                        _obj_smhr_applicant.APPCONT_ADDRESS = (Convert.ToString(ds_contact.Tables[0].Rows[i]["Address*"]).Replace("'", "''"));
    //                        _obj_smhr_applicant.APPCONT_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
    //                        _obj_smhr_applicant.APPCONT_CREATEDDATE = DateTime.Now;
    //                        _obj_smhr_applicant.OPERATION = operation.Check_New;
    //                        DataTable dt_serialno = BLL.get_ApplicantContact(_obj_smhr_applicant);

    //                        _obj_smhr_applicant.APPCONT_SERIAL = (Convert.ToInt32(dt_serialno.Rows[0]["APPCONT_SERIAL"])) + 1;


    //                        _obj_smhr_applicant.OPERATION = operation.Insert;

    //                        status = BLL.set_ApplicantContact(_obj_smhr_applicant);
    //                    }

    //                }
    //            }


    //            ////Inserting Language  data fron excel to database

    //            for (int i = 0; i < ds_language.Tables[0].Rows.Count; i++)
    //            {
    //                bool status = false;
    //                // columnno = string.Empty;
    //                int applicant_id = 0;
    //                if (ds_language.Tables[0].Rows[i]["APPlicant SNO*"].ToString().Trim() != "")
    //                {

    //                    bool status_language = false;

    //                    for (int j = 0; j < ds_directemp.Tables[0].Rows.Count; j++)
    //                    {
    //                        if (ds_language.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() == ds_directemp.Tables[0].Rows[j]["Applicant SNO*"].ToString().Trim())
    //                        {
    //                            status_language = true;
    //                            applicant_id = Convert.ToInt32(ds_directemp.Tables[0].Rows[j]["ApplicantID"]);

    //                            break;

    //                        }
    //                    }

    //                    if (status_language == true)
    //                    {
    //                        _obj_smhr_applicant.APPLICANT_ID = applicant_id;
    //                        SMHR_MASTERS _Obj_smhr_Masters = new SMHR_MASTERS();

    //                        _Obj_smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                        _Obj_smhr_Masters.OPERATION = operation.Select;
    //                        _Obj_smhr_Masters.MASTER_TYPE = "LANGUAGE";
    //                        _Obj_smhr_Masters.MASTER_CODE = ds_language.Tables[0].Rows[i]["Language*"].ToString().Trim();
    //                        DataTable dt_nat = BLL.get_Applicant_Validate(_Obj_smhr_Masters);

    //                        _obj_smhr_applicant.APPLAN_LANGUAGE_ID = Convert.ToInt32(dt_nat.Rows[0]["HR_MASTER_ID"]);

    //                        _obj_smhr_applicant.APPLAN_READ = Convert.ToBoolean(ds_language.Tables[0].Rows[i]["Read"]);
    //                        _obj_smhr_applicant.APPLAN_SPEAK = Convert.ToBoolean(ds_language.Tables[0].Rows[i]["Speak"]);
    //                        _obj_smhr_applicant.APPLAN_UNDERSTAND = Convert.ToBoolean(ds_language.Tables[0].Rows[i]["Understand"]);
    //                        _obj_smhr_applicant.APPLAN_WRITE = Convert.ToBoolean(ds_language.Tables[0].Rows[i]["Write"]);
    //                        _obj_smhr_applicant.APPLAN_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
    //                        _obj_smhr_applicant.APPLAN_CREATEDDATE = DateTime.Now;
    //                        _obj_smhr_applicant.OPERATION = operation.Insert;

    //                        status = BLL.set_ApplicantLanguage(_obj_smhr_applicant);


    //                    }
    //                }
    //            }//LANGUAGE FOR LOOP END

    //            // @@@@@@@@@@@@@@@emp_familydetails

    //            for (int i = 0; i < ds_Family.Tables[0].Rows.Count; i++)
    //            {
    //                int empl_id = 0;
    //                if (ds_Family.Tables[0].Rows[i]["APPlicant SNO*"].ToString().Trim() != "")
    //                {
    //                    bool status_family = false;


    //                    for (int j = 0; j < ds_Family.Tables[0].Rows.Count; j++)
    //                    {
    //                        if (ds_Family.Tables[0].Rows[i]["APPlicant SNO*"].ToString().Trim() == ds_directemp.Tables[0].Rows[j]["APPlicant SNO*"].ToString().Trim())
    //                        {
    //                            status_family = true;
    //                            empl_id = Convert.ToInt32(ds_directemp.Tables[0].Rows[j]["EMPLOYEEID"]);

    //                            break;

    //                        }

    //                    }
    //                    if (status_family == true)
    //                    {

    //                        bool status1 = false;
    //                        _obj_smhr_employee = new SMHR_EMPLOYEE();
    //                        _obj_smhr_employee.OPERATION = operation.Check_New;
    //                        _obj_smhr_employee.EMPFMDTL_EMP_ID = empl_id;
    //                        DataTable dt_serialno = BLL.get_EmployeeFamily(_obj_smhr_employee);
    //                        //int serno =( Convert.ToInt32(dt_serialno.Rows[0]["APPCONT_SERIAL"]))+1;
    //                        _obj_smhr_employee.EMPFMDTL_SERIAL = (Convert.ToInt32(dt_serialno.Rows[0]["EMPFMDTL_SERIAL"])) + 1;

    //                        //_obj_smhr_employee.EMPFMDTL_SERIAL = i+1;
    //                        for (int c = 0; c < ddl_Relationship.Items.Count; c++)
    //                        {
    //                            if ((ds_Family.Tables[0].Rows[i]["Relationship*"].ToString().Trim()) == ddl_Relationship.Items[c].Text)
    //                            {
    //                                _obj_smhr_employee.EMPFMDTL_EMPREL_ID = Convert.ToInt32(ddl_Relationship.Items[c].Value);

    //                            }

    //                        }



    //                        _obj_smhr_employee.EMPFMDTL_NAME = ds_Family.Tables[0].Rows[i]["Name*"].ToString().Trim();
    //                        //  _obj_smhr_employee.EMPFMDTL_RELDOB = Convert.ToDateTime(ds_Family.Tables[0].Rows[i]["Date of Birth"]);
    //                        _obj_smhr_employee.EMFM_RELDOB = ds_Family.Tables[0].Rows[i]["Date of Birth(dd/mm/yyyy)*"].ToString().Trim();
    //                        if (ds_Family.Tables[0].Rows[i]["Is Dependant"].ToString().Trim() != "")
    //                            _obj_smhr_employee.EMPFMDTL_RELDEPENDENT = Convert.ToBoolean(ds_Family.Tables[0].Rows[i]["Is Dependant"]);
    //                        else
    //                            _obj_smhr_employee.EMPFMDTL_RELDEPENDENT = false;
    //                        if (ds_Family.Tables[0].Rows[i]["Emergency Contact"].ToString().Trim() != "")
    //                            _obj_smhr_employee.EMPFMDTL_EMERGENCYCONTACT = Convert.ToBoolean(ds_Family.Tables[0].Rows[i]["Emergency Contact"]);
    //                        else
    //                            _obj_smhr_employee.EMPFMDTL_EMERGENCYCONTACT = false;
    //                        if (ds_Family.Tables[0].Rows[i]["Next to Kin"].ToString().Trim() != "")
    //                            _obj_smhr_employee.EMPFMDTL_ISNEXTTOKIN = Convert.ToBoolean(ds_Family.Tables[0].Rows[i]["Next to Kin"]);
    //                        else
    //                            _obj_smhr_employee.EMPFMDTL_ISNEXTTOKIN = false;
    //                        _obj_smhr_employee.EMPFMDTL_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
    //                        _obj_smhr_employee.EMPFMDTL_CREATEDDATE = DateTime.Now;
    //                        _obj_smhr_employee.EMPFMDTL_ANNUALINCOME = Convert.ToDouble(ds_Family.Tables[0].Rows[i]["Annual Income"]);
    //                        _obj_smhr_employee.EMPFMDTL_OCCUPATION = Convert.ToString(ds_Family.Tables[0].Rows[i]["Occupation"]);
    //                        _obj_smhr_employee.OPERATION = operation.Insert1;
    //                        status1 = BLL.set_EmpFamily(_obj_smhr_employee);//no organisation column is found in this table



    //                    }

    //                }

    //            }

    //            //@@@@@@@@@@@@@employee_Weekly Off

    //            for (int i = 0; i < ds_weeklyOff.Tables[0].Rows.Count; i++)
    //            {
    //                int empl_id1 = 0;
    //                if (ds_weeklyOff.Tables[0].Rows[i]["APPlicant SNO*"].ToString().Trim() != "")
    //                {
    //                    bool status_weoff = false;


    //                    for (int j = 0; j < ds_weeklyOff.Tables[0].Rows.Count; j++)
    //                    {
    //                        if (ds_weeklyOff.Tables[0].Rows[i]["APPlicant SNO*"].ToString().Trim() == ds_directemp.Tables[0].Rows[j]["APPlicant SNO*"].ToString().Trim())
    //                        {
    //                            status_weoff = true;
    //                            empl_id1 = Convert.ToInt32(ds_directemp.Tables[0].Rows[j]["EMPLOYEEID"]);

    //                            break;

    //                        }

    //                    }
    //                    if (status_weoff == true)
    //                    {
    //                        _obj_smhr_weeklyoff = new SMHR_EMPLOYEEWEEKLYOFF();
    //                        _obj_smhr_weeklyoff.OPERATION = operation.Select;
    //                        _obj_smhr_weeklyoff.EMPWOFF_EMP_ID = empl_id1;
    //                        DataTable dt_wof = BLL.get_EmpWeekOff(_obj_smhr_weeklyoff);
    //                        if (dt_wof.Rows.Count == 0)
    //                        {
    //                            _obj_smhr_weeklyoff = new SMHR_EMPLOYEEWEEKLYOFF();
    //                            _obj_smhr_weeklyoff.OPERATION = operation.Insert1;
    //                            _obj_smhr_weeklyoff.EMPWOFF_EMP_ID = empl_id1;
    //                            if (ds_weeklyOff.Tables[0].Rows[i]["Effective Date*(dd/mm/yyyy)"].ToString().Trim() != null)
    //                                _obj_smhr_weeklyoff.EMPWOFFEFDATE = ds_weeklyOff.Tables[0].Rows[i]["Effective Date*(dd/mm/yyyy)"].ToString();
    //                            else
    //                                _obj_smhr_weeklyoff.EMPWOFFEFDATE = null;
    //                            if (ds_weeklyOff.Tables[0].Rows[i]["Monday"].ToString().Trim() == "TRUE")
    //                                _obj_smhr_weeklyoff.EMPWOFF_MON = true;
    //                            else
    //                                _obj_smhr_weeklyoff.EMPWOFF_MON = false;
    //                            if (ds_weeklyOff.Tables[0].Rows[i]["Tuesday"].ToString().Trim() == "TRUE")
    //                                _obj_smhr_weeklyoff.EMPWOFF_TUE = true;
    //                            else
    //                                _obj_smhr_weeklyoff.EMPWOFF_TUE = false;
    //                            if (ds_weeklyOff.Tables[0].Rows[i]["Wednesday"].ToString().Trim() == "TRUE")
    //                                _obj_smhr_weeklyoff.EMPWOFF_WED = true;
    //                            else
    //                                _obj_smhr_weeklyoff.EMPWOFF_WED = false;
    //                            if (ds_weeklyOff.Tables[0].Rows[i]["Thursday"].ToString().Trim() == "TRUE")
    //                                _obj_smhr_weeklyoff.EMPWOFF_THU = true;
    //                            else
    //                                _obj_smhr_weeklyoff.EMPWOFF_THU = false;
    //                            if (ds_weeklyOff.Tables[0].Rows[i]["Friday"].ToString().Trim() == "TRUE")
    //                                _obj_smhr_weeklyoff.EMPWOFF_FRI = true;
    //                            else
    //                                _obj_smhr_weeklyoff.EMPWOFF_FRI = false;
    //                            if (ds_weeklyOff.Tables[0].Rows[i]["Saturday"].ToString().Trim() == "TRUE")
    //                                _obj_smhr_weeklyoff.EMPWOFF_SAT = true;
    //                            else
    //                                _obj_smhr_weeklyoff.EMPWOFF_SAT = false;
    //                            if (ds_weeklyOff.Tables[0].Rows[i]["Sunday"].ToString().Trim() == "TRUE")
    //                                _obj_smhr_weeklyoff.EMPWOFF_SUN = true;
    //                            else
    //                                _obj_smhr_weeklyoff.EMPWOFF_SUN = false;
    //                            _obj_smhr_weeklyoff.EMPWOFF_CREATEDBY = Convert.ToInt32(Convert.ToString(Session["USER_ID"]));
    //                            _obj_smhr_weeklyoff.EMPWOFF_CREATEDDATE = DateTime.Now;
    //                            bool status2 = BLL.set_EmpWeekOff(_obj_smhr_weeklyoff);
    //                        }
    //                        else
    //                        {
    //                        }
    //                    }
    //                }
    //            }

    //            //@@@@@@@@@EMPLOYEE OTHERDETAILS

    //            for (int i = 0; i < ds_Otherdetails.Tables[0].Rows.Count; i++)
    //            {
    //                int empl_id2 = 0;
    //                if (ds_Otherdetails.Tables[0].Rows[i]["APPlicant SNO*"].ToString().Trim() != "")
    //                {
    //                    bool status_empodt = false;


    //                    for (int j = 0; j < ds_Otherdetails.Tables[0].Rows.Count; j++)
    //                    {
    //                        if (ds_Otherdetails.Tables[0].Rows[i]["APPlicant SNO*"].ToString().Trim() == ds_directemp.Tables[0].Rows[j]["APPlicant SNO*"].ToString().Trim())
    //                        {
    //                            status_empodt = true;
    //                            empl_id2 = Convert.ToInt32(ds_directemp.Tables[0].Rows[j]["EMPLOYEEID"]);

    //                            break;

    //                        }

    //                    }
    //                    if (status_empodt == true)
    //                    {

    //                        _obj_SMHR_EMPOTHERDETAILS = new SMHR_EMPOTHERDETAILS();
    //                        _obj_SMHR_EMPOTHERDETAILS.OPERATION = operation.Insert;
    //                        _obj_SMHR_EMPOTHERDETAILS.EMPOTHERDTL_EMPID = empl_id2;
    //                        _obj_SMHR_EMPOTHERDETAILS.EMPOTHERDTL_IDNO = ds_Otherdetails.Tables[0].Rows[i]["PF Number"].ToString().Trim();
    //                        _obj_SMHR_EMPOTHERDETAILS.EMPOTHERDTL_PINNO = ds_Otherdetails.Tables[0].Rows[i]["PAN Number"].ToString().Trim();
    //                        _obj_SMHR_EMPOTHERDETAILS.EMPOTHERDTL_NSSFNO = ds_Otherdetails.Tables[0].Rows[i]["ESI Number"].ToString().Trim();
    //                        _obj_SMHR_EMPOTHERDETAILS.EMPOTHERDTL_NHIFNO = ds_Otherdetails.Tables[0].Rows[i]["Gratuity Number"].ToString().Trim();
    //                        _obj_SMHR_EMPOTHERDETAILS.EMPOTHERDTL_TAXRELIEFAMOUNT = string.Empty;
    //                        _obj_SMHR_EMPOTHERDETAILS.EMPOTHERDTL_NNAKNO = string.Empty;
    //                        _obj_SMHR_EMPOTHERDETAILS.EMPOTHERDTL_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
    //                        _obj_SMHR_EMPOTHERDETAILS.EMPOTHERDTL_CREATEDDATE = DateTime.Now;
    //                        BLL.set_SMHR_EMPOTHERDETAILS(_obj_SMHR_EMPOTHERDETAILS);
    //                    }



    //                }
    //            }



    //            for (int i = 0; i < ds_physicaldetails.Tables[0].Rows.Count; i++)
    //            {
    //                int empl_id3 = 0;
    //                if (ds_physicaldetails.Tables[0].Rows[i]["APPlicant SNO*"].ToString().Trim() != "")
    //                {
    //                    bool status_empodt = false;


    //                    for (int j = 0; j < ds_physicaldetails.Tables[0].Rows.Count; j++)
    //                    {
    //                        if (ds_physicaldetails.Tables[0].Rows[i]["APPlicant SNO*"].ToString().Trim() == ds_directemp.Tables[0].Rows[j]["APPlicant SNO*"].ToString().Trim())
    //                        {
    //                            status_empodt = true;
    //                            empl_id3 = Convert.ToInt32(ds_directemp.Tables[0].Rows[j]["EMPLOYEEID"]);

    //                            break;

    //                        }

    //                    }
    //                    if (status_empodt == true)
    //                    {
    //                        _obj_smhr_employee.OPERATION = operation.Insert1;
    //                        _obj_smhr_employee.EMP_MOBILENO = ds_physicaldetails.Tables[0].Rows[i]["Mobile No"].ToString().Trim().Replace("'", "''");
    //                        _obj_smhr_employee.EMP_LANDLINENO = ds_physicaldetails.Tables[0].Rows[i]["LandLine No"].ToString().Trim().Replace("'", "''");
    //                        _obj_smhr_employee.EMP_EMAILID = ds_physicaldetails.Tables[0].Rows[i]["Email ID"].ToString().Trim().Replace("'", "''");
    //                        _obj_smhr_employee.EMP_ID = empl_id3;

    //                        BLL.set_EMP_NEWCONTACTS(_obj_smhr_employee);




    //                        //Physical Details
    //                        _obj_SMHR_EMPPHYSICALDETAILS = new SMHR_EMP_PHYSICALDETAILS();

    //                        _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_EMPID = empl_id3;

    //                        DataTable dt_getPhysicalDetails = BLL.get_PhysicalDetails(_obj_SMHR_EMPPHYSICALDETAILS);
    //                        if (dt_getPhysicalDetails.Rows.Count == 0)
    //                        {

    //                            _obj_SMHR_EMPPHYSICALDETAILS.OPERATION = operation.Insert_New;

    //                            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_EMPID = empl_id3;
    //                            if (ds_physicaldetails.Tables[0].Rows[i]["Height(cms)"].ToString().Trim() == "")
    //                            {
    //                                _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_HEIGHT = 0.00;
    //                            }
    //                            else
    //                            {
    //                                _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_HEIGHT = Convert.ToDouble(ds_physicaldetails.Tables[0].Rows[i]["Height(cms)"]);
    //                            }

    //                            if (ds_physicaldetails.Tables[0].Rows[i]["Weight(Kgs)"] == "")
    //                            {
    //                                _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_WEIGHT = 0.00;
    //                            }
    //                            else
    //                            {
    //                                _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_WEIGHT = Convert.ToDouble(ds_physicaldetails.Tables[0].Rows[i]["Weight(Kgs)"]);
    //                            }

    //                            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_COLOR = ds_physicaldetails.Tables[0].Rows[i]["Skin Color"].ToString().Replace("'", "''");
    //                            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_IDENTIFICATION = ds_physicaldetails.Tables[0].Rows[i]["Mole Identification Or Other Marks"].ToString().Trim().Replace("'", "''");
    //                            //_obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_BLOODGROUP = Convert.ToString(rtxt_BGroup.Text.Replace("'", "''"));
    //                            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_EYEPOWER = ds_physicaldetails.Tables[0].Rows[i]["Eye Power"].ToString().Replace("'", "''");

    //                            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_HANDICAP = Convert.ToBoolean(ds_physicaldetails.Tables[0].Rows[i]["Is Handicapped?"]);


    //                            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_HANDICAP_YES = ds_physicaldetails.Tables[0].Rows[i]["Details"].ToString().Replace("'", "''");
    //                            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_PHYSICALTREATMENT = ds_physicaldetails.Tables[0].Rows[i]["(physical)Treatment Name"].ToString();
    //                            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_PHYSICALHOSPITAL = ds_physicaldetails.Tables[0].Rows[i]["Hospital Name"].ToString().Replace("'", "''");
    //                            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_PHYSICALDURATION = ds_physicaldetails.Tables[0].Rows[i]["Treatment Duration(days)"].ToString().Replace("'", "''");
    //                            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_PHYSICALSTATUS = ds_physicaldetails.Tables[0].Rows[i]["Current Illness Status"].ToString().Replace("'", "''");
    //                            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_MENTALTREATMENT = ds_physicaldetails.Tables[0].Rows[i]["(Mental)Treatment Name"].ToString().Replace("'", "''");
    //                            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_MENTALHOSPITAL = ds_physicaldetails.Tables[0].Rows[i]["Hospital Name"].ToString().Replace("'", "''");
    //                            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_MENTALDURATION = ds_physicaldetails.Tables[0].Rows[i]["Treatment Duration(days)"].ToString().Replace("'", "''");
    //                            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_MENTALSTATUS = ds_physicaldetails.Tables[0].Rows[i]["Current Illness Status"].ToString().Replace("'", "''");
    //                            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
    //                            _obj_SMHR_EMPPHYSICALDETAILS.EMPPHYSICALDTL_CREATEDDATE = DateTime.Now;


    //                            BLL.set_PhysicalDetails(_obj_SMHR_EMPPHYSICALDETAILS);


    //                        }
    //                    }

    //                }
    //            }




    //            BLL.ShowMessage(this, "Successfully processed Excel file.");
    //            LoadData();
    //            RG_Employee.DataBind();





    //        }





    //    }//else
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }


    //}
}
