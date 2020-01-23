using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using SMHR;
using System.Data;
using System.Xml;
using System.IO;

public partial class HR_EmployeeCopy : System.Web.UI.Page
{
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems;
    SMHR_EMPLOYEE _obj_SMHR_EMPLOYEE;
    SMHR_DEPARTMENT _obj_SMHR_DEPARTMENT;
    SMHR_BUSINESSUNIT _obj_SMHR_BUSINESSUNIT;
    SMHR_POSITIONS _obj_smhr_positions;
    SMHR_ORGANISATION _obj_SMHR_ORGANISATION;
    int iChkCount = 0;
    static double maxsal = 0.0;
    static double minsal = 0.0;
    bool contracts = false;
    DataTable dt_Details;
    int I_ChkCount = 0;
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Employee Copy");//EMPLOYEECOPY");
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
                    // rg_Attendence.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Copy.Visible = false;
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
                LoadCombo();
                LoadAnnual();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeCopy", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void rcmb_SourceBU_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_SourceBU.SelectedIndex != 0)
            {
                rg_Employee.Visible = true;
                _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
                _obj_smhr_emp_payitems.OPERATION = operation.Empty;
                _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(rcmb_SourceBU.SelectedValue);
                _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_Details = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
                if (dt_Details.Rows.Count != 0)
                {
                    rg_Employee.DataSource = dt_Details;
                    rg_Employee.DataBind();
                }
                else
                {
                    BLL.ShowMessage(this, "No employees in the selected BusinessUnit.");
                }
                //rcmb_DestinationBU.SelectedIndex = 0;
                rcmb_DestinationDept.Items.Clear();

                //TO LOAD DESTINATION BU
                _obj_SMHR_BUSINESSUNIT = new SMHR_BUSINESSUNIT();
                _obj_SMHR_BUSINESSUNIT.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_SMHR_BUSINESSUNIT.BU_LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                rcmb_DestinationBU.Items.Clear();
                DataTable dt = BLL.getBU(_obj_SMHR_BUSINESSUNIT);
                for (int index = 0; index < dt.Rows.Count; index++)
                {
                    if (Convert.ToInt32(dt.Rows[index]["BUSINESSUNIT_ID"]) == Convert.ToInt32(rcmb_SourceBU.SelectedItem.Value))
                    {
                        dt.Rows[index].Delete();
                        dt.AcceptChanges();
                        break;
                    }
                }
                rcmb_DestinationBU.DataSource = dt;
                rcmb_DestinationBU.DataTextField = "BUSINESSUNIT_CODE";
                rcmb_DestinationBU.DataValueField = "BUSINESSUNIT_ID";
                rcmb_DestinationBU.DataBind();
                rcmb_DestinationBU.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
            else
            {
                rcmb_DestinationBU.ClearSelection();
                rcmb_DestinationBU.Items.Clear();
                rcmb_DestinationBU.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeCopy", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    public void LoadCombo()
    {
        try
        {
            //loading source business unit.
            _obj_SMHR_BUSINESSUNIT = new SMHR_BUSINESSUNIT();
            _obj_SMHR_BUSINESSUNIT.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_BUSINESSUNIT.BU_LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            rcmb_SourceBU.Items.Clear();
            rcmb_SourceBU.DataSource = BLL.getBU(_obj_SMHR_BUSINESSUNIT);
            rcmb_SourceBU.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_SourceBU.DataValueField = "BUSINESSUNIT_ID";
            rcmb_SourceBU.DataBind();
            rcmb_SourceBU.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            //loading destination business unit.
            //_obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            //_obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //_obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            //rcmb_SourceBU.Items.Clear();
            //rcmb_SourceBU.DataSource = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            //rcmb_SourceBU.DataTextField = "BUSINESSUNIT_CODE";
            //rcmb_SourceBU.DataValueField = "BUSINESSUNIT_ID";
            //rcmb_SourceBU.DataBind();
            //rcmb_SourceBU.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeCopy", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }


    protected void btn_Copy_Click(object sender, EventArgs e)
    {
        try
        {
            if (rcmb_SourceBU.SelectedIndex == 0)
            {
                BLL.ShowMessage(this, "Please Select Source Business Unit");
            }
            else if (rcmb_SourceBU.SelectedIndex > 0)
            {
                _obj_SMHR_EMPLOYEE = new SMHR_EMPLOYEE();
                _obj_SMHR_DEPARTMENT = new SMHR_DEPARTMENT();
                CheckBox chk = new CheckBox();
                Label lbl_Emp_Id = new Label();
                Label lbl_BuId = new Label();
                Label lbl_DepartmentId = new Label();
                Label lbl_Error = new Label();
                Label lbl_EmpCode = new Label();
                Label lbl_SalStruct = new Label();
                Label lbl_GrossSal = new Label();
                Label lbl_EmpDoj = new Label();
                for (int iEmpId = 0; iEmpId < rg_Employee.Items.Count; iEmpId++)
                {
                    chk = rg_Employee.Items[iEmpId].FindControl("chk_Select") as CheckBox;
                    lbl_Emp_Id = rg_Employee.Items[iEmpId].FindControl("lbl_EmployeeID") as Label;
                    lbl_BuId = rg_Employee.Items[iEmpId].FindControl("lbl_BuId") as Label;
                    lbl_DepartmentId = rg_Employee.Items[iEmpId].FindControl("lbl_DepartmentId") as Label;
                    lbl_Error = rg_Employee.Items[iEmpId].FindControl("lbl_Error") as Label;
                    lbl_EmpCode = rg_Employee.Items[iEmpId].FindControl("lbl_EmpCode") as Label;
                    lbl_SalStruct = rg_Employee.Items[iEmpId].FindControl("lbl_SalStruct") as Label;
                    lbl_GrossSal = rg_Employee.Items[iEmpId].FindControl("lbl_GrossSal") as Label;
                    lbl_EmpDoj = rg_Employee.Items[iEmpId].FindControl("lbl_EmpDoj") as Label;
                    if (chk.Checked)
                    {
                        iChkCount = iChkCount + 1;
                        _obj_SMHR_EMPLOYEE.OPERATION = operation.Check_Emp;
                        _obj_SMHR_EMPLOYEE.EMP_EMPCODE = Convert.ToString(lbl_EmpCode.Text);
                        _obj_SMHR_EMPLOYEE.EMP_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_DestinationBU.SelectedItem.Value);
                        _obj_SMHR_EMPLOYEE.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dt_Check = BLL.get_Employee(_obj_SMHR_EMPLOYEE);
                        if (dt_Check.Rows.Count != 0)
                        {
                            if (Convert.ToString(dt_Check.Rows[0][0]) == "0")
                            {
                                //if (Convert.ToInt32(lbl_GrossSal.Text) == 0)
                                //{
                                //    BLL.ShowMessage(this,"Transfer not allowed.This employee has already been transferred and has Gross Salary as 0");
                                //    return;
                                //}
                                if (Convert.ToDateTime(lbl_EmpDoj.Text) > Convert.ToDateTime(ViewState["buStartDate"]))
                                {
                                    _obj_SMHR_EMPLOYEE.OPERATION = operation.EMP_COPY;
                                    _obj_SMHR_EMPLOYEE.emp_SOURCEBU = Convert.ToInt32(rcmb_SourceBU.SelectedItem.Value);
                                    _obj_SMHR_EMPLOYEE.EMP_ID = Convert.ToInt32(lbl_Emp_Id.Text);
                                    _obj_SMHR_EMPLOYEE.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                    _obj_SMHR_EMPLOYEE.EMP_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_DestinationBU.SelectedItem.Value);
                                    _obj_SMHR_EMPLOYEE.EMP_DEPARTMENT_ID = Convert.ToInt32(rcmb_DestinationDept.SelectedItem.Value);
                                    _obj_SMHR_EMPLOYEE.EMP_PAYCURRENCY = Convert.ToInt32(rcmb_DestinationCurr.SelectedItem.Value);
                                    _obj_SMHR_EMPLOYEE.EMP_EMPCODE = Convert.ToString(lbl_EmpCode.Text);
                                    _obj_SMHR_EMPLOYEE.EMP_SALALRYSTRUCT_ID = Convert.ToInt32(lbl_SalStruct.Text);
                                    _obj_SMHR_EMPLOYEE.EMP_DESIGNATION_ID = Convert.ToInt32(rcmb_DestinationPosition.SelectedItem.Value);
                                    if ((Convert.ToString(txt_AnnualGross.Text) == "") || (Convert.ToString(txt_AnnualGross.Text) == string.Empty))
                                    {
                                        _obj_SMHR_EMPLOYEE.emp_ANNUAL_GROSSSALARY = 0.00;
                                    }
                                    else
                                    {
                                        _obj_SMHR_EMPLOYEE.emp_ANNUAL_GROSSSALARY = Convert.ToDouble(txt_AnnualGross.Text);
                                    }
                                    if ((Convert.ToString(txt_AnnualBasic.Text) == "") || (Convert.ToString(txt_AnnualBasic.Text) == string.Empty))
                                    {
                                        _obj_SMHR_EMPLOYEE.emp_ANNUAL_BASICSALARY = 0.00;
                                    }
                                    else
                                    {
                                        _obj_SMHR_EMPLOYEE.emp_ANNUAL_BASICSALARY = Convert.ToDouble(txt_AnnualBasic.Text);
                                    }
                                    _obj_SMHR_EMPLOYEE.EMP_GROSSSAL = Convert.ToDouble(txt_MonthlyGross.Text);
                                    _obj_SMHR_EMPLOYEE.EMP_BASIC = Convert.ToDouble(txt_MonthlyBasic.Text);
                                    bool status = BLL.set_Employee(_obj_SMHR_EMPLOYEE);
                                    if (status == true)
                                    {
                                        _obj_SMHR_EMPLOYEE.OPERATION = operation.Update_New;
                                        _obj_SMHR_EMPLOYEE.EMP_ID = Convert.ToInt32(lbl_Emp_Id.Text);
                                        _obj_SMHR_EMPLOYEE.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                        _obj_SMHR_EMPLOYEE.EMP_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_SourceBU.SelectedItem.Value);
                                        bool status1 = BLL.set_Employee(_obj_SMHR_EMPLOYEE);

                                        //generating XML file
                                        _obj_SMHR_EMPLOYEE.OPERATION = operation.Select_New;
                                        _obj_SMHR_EMPLOYEE.EMP_EMPCODE = Convert.ToString(lbl_EmpCode.Text);
                                        DataTable dtDetails = BLL.getEmployee(_obj_SMHR_EMPLOYEE);
                                        if (dtDetails.Rows.Count > 0)
                                        {
                                            _obj_SMHR_BUSINESSUNIT = new SMHR_BUSINESSUNIT();
                                            _obj_SMHR_BUSINESSUNIT.OPERATION = operation.Select;
                                            _obj_SMHR_BUSINESSUNIT.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                            _obj_SMHR_BUSINESSUNIT.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_DestinationBU.SelectedValue);
                                            DataTable dt = BLL.get_BusinessUnit(_obj_SMHR_BUSINESSUNIT);

                                            string DateVal = DateTime.Now.ToString("ddMMyyyy");

                                            DataTable dt_1 = BLL.ExecuteQuery("SELECT MASTERNO FROM SMHR_GLOBALCONFIG WHERE GLOBALCONFIG_ORGANISATION_ID = '" + Convert.ToInt32(Session["ORG_ID"]) + "'");
                                            //string strPath = "C:\\AXXML\\SMHR\\IN\\" + lbl_Code.Text + ".xml";
                                            string strPath = "C:\\AXXML\\SMHR\\IN\\" + Convert.ToString(dt.Rows[0]["BUSINESSUNIT_CODE"]) + "_SMHR_MST_" + DateVal + "_" + dt_1.Rows[0]["MASTERNO"] + ".xml";
                                            bool statusXml = BLL.ExecuteNonQuery("UPDATE SMHR_GLOBALCONFIG SET MASTERNO = MASTERNO + 1 WHERE " +
                                                "GLOBALCONFIG_ORGANISATION_ID = '" + Convert.ToInt32(Session["ORG_ID"]) + "'");
                                            XmlTextWriter myXmlTextWriter = new XmlTextWriter(strPath, null);
                                            myXmlTextWriter.Formatting = Formatting.Indented;
                                            myXmlTextWriter.WriteStartDocument(false);
                                            myXmlTextWriter.WriteStartElement("xml");

                                            myXmlTextWriter.WriteStartElement("EmplTable", null);
                                            myXmlTextWriter.WriteElementString("EmplId", null, Convert.ToString(lbl_EmpCode.Text));
                                            if (Convert.ToString(dtDetails.Rows[0]["GENDER"]).Trim() == "Male")
                                                myXmlTextWriter.WriteElementString("EmplGender", null, Convert.ToString(1));
                                            else
                                                myXmlTextWriter.WriteElementString("EmplGender", null, Convert.ToString(2));
                                            myXmlTextWriter.WriteElementString("PartyId", null, Convert.ToString(lbl_Emp_Id.Text));
                                            myXmlTextWriter.WriteElementString("status", null, Convert.ToString(1));
                                            myXmlTextWriter.WriteElementString("Name", null, Convert.ToString(dtDetails.Rows[0]["EMPNAME"]));
                                            myXmlTextWriter.WriteElementString("NameAlias", null, Convert.ToString(dtDetails.Rows[0]["EMPNAME"]));
                                            myXmlTextWriter.WriteElementString("Type", null, Convert.ToString(1));
                                            myXmlTextWriter.WriteElementString("FirstName", null, Convert.ToString(dtDetails.Rows[0]["APPLICANT_FIRSTNAME"]));
                                            myXmlTextWriter.WriteElementString("MiddleName", null, Convert.ToString(dtDetails.Rows[0]["APPLICANT_MIDDLENAME"]));
                                            myXmlTextWriter.WriteElementString("LastName", null, Convert.ToString(dtDetails.Rows[0]["APPLICANT_LASTNAME"]));
                                            myXmlTextWriter.WriteElementString("Dimension", null, Convert.ToString(rcmb_DestinationDept.SelectedItem.Text.Replace("'", "''")));
                                            myXmlTextWriter.WriteEndElement();
                                            //Write the XML to file and close the myXmlTextWriter
                                            myXmlTextWriter.Flush();
                                            myXmlTextWriter.Close();
                                        }

                                        BLL.ShowMessage(this, "Employees has been transferred");
                                        rcmb_SourceBU.SelectedIndex = 0;
                                        rcmb_DestinationBU.ClearSelection();
                                        rcmb_DestinationBU.Items.Clear();
                                        rcmb_DestinationBU.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                                        rg_Employee.Visible = false;
                                        rcmb_DestinationCurr.Items.Clear();
                                        rcmb_DestinationDept.Items.Clear();
                                        rcmb_DestinationPosition.Items.Clear();
                                        txt_AnnualGross.Text = "";
                                        txt_AnnualBasic.Text = "";
                                        txt_MonthlyGross.Text = "";
                                        txt_MonthlyBasic.Text = "";
                                    }
                                }
                                else
                                {
                                    BLL.ShowMessage(this, "Cannot Transfer.Employee Date Of Join Falls before Start Date Of Destination Business Unit");
                                }
                            }
                            else
                            {
                                BLL.ShowMessage(this, "One or more of the selected employee already exist in Destination Business Unit");
                            }
                        }
                    }
                }
                if (iChkCount == 0)
                {
                    BLL.ShowMessage(this, "Please Select Employee");
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeCopy", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            rcmb_SourceBU.SelectedIndex = 0;
            rg_Employee.Visible = false;
            rcmb_DestinationBU.ClearSelection();
            rcmb_DestinationBU.Items.Clear();
            rcmb_DestinationBU.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            rcmb_DestinationDept.Items.Clear();
            rcmb_DestinationPosition.Items.Clear();
            rcmb_DestinationCurr.Items.Clear();
            lbl_DestinationJob.Text = "";
            txt_AnnualGross.Text = "";
            txt_AnnualBasic.Text = "";
            txt_MonthlyGross.Text = "";
            txt_MonthlyBasic.Text = "";
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeCopy", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void rcmb_DestinationBU_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            _obj_SMHR_DEPARTMENT = new SMHR_DEPARTMENT();
            _obj_SMHR_DEPARTMENT.MODE = 14;
            _obj_SMHR_DEPARTMENT.BUID = Convert.ToInt32(rcmb_DestinationBU.SelectedItem.Value);
            _obj_SMHR_DEPARTMENT.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_dept = BLL.get_Department(_obj_SMHR_DEPARTMENT);
            rcmb_DestinationDept.DataSource = dt_dept;
            rcmb_DestinationDept.DataTextField = "DEPARTMENT_NAME";
            rcmb_DestinationDept.DataValueField = "DEPARTMENT_ID";
            rcmb_DestinationDept.DataBind();
            rcmb_DestinationDept.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            rcmb_DestinationCurr.Items.Clear();
            _obj_SMHR_BUSINESSUNIT = new SMHR_BUSINESSUNIT();
            _obj_SMHR_BUSINESSUNIT.OPERATION = operation.Empty1;
            _obj_SMHR_BUSINESSUNIT.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_DestinationBU.SelectedItem.Value);
            _obj_SMHR_BUSINESSUNIT.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Currency = BLL.get_BusinessUnit(_obj_SMHR_BUSINESSUNIT);
            rcmb_DestinationCurr.DataSource = dt_Currency;
            rcmb_DestinationCurr.DataTextField = "CURR_CODE";
            rcmb_DestinationCurr.DataValueField = "BUSINESSUNIT_CURRENCY_ID";
            rcmb_DestinationCurr.DataBind();
            rcmb_DestinationCurr.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            _obj_SMHR_BUSINESSUNIT.OPERATION = operation.Select;
            DataTable dt_Bu = BLL.get_BusinessUnit(_obj_SMHR_BUSINESSUNIT);
            if (dt_Bu.Rows.Count != 0)
            {
                ViewState["buStartDate"] = Convert.ToString(dt_Bu.Rows[0]["BUSINESSUNIT_STARTDATE"]);
            }
            if (rcmb_DestinationBU.SelectedIndex > 0)
            {
                getPosition();
            }
            lbl_DestinationJob.Text = "";
            txt_AnnualGross.Text = "";
            txt_AnnualBasic.Text = "";
            txt_MonthlyGross.Text = "";
            txt_MonthlyBasic.Text = "";
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeCopy", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void rcmb_DestinationPosition_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_DestinationPosition.SelectedIndex > 0)
            {
                _obj_smhr_positions = new SMHR_POSITIONS();
                _obj_smhr_positions.OPERATION = operation.Empty;
                _obj_smhr_positions.POSITIONS_ID = Convert.ToInt32(rcmb_DestinationPosition.SelectedValue);
                _obj_smhr_positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt = BLL.get_Positions(_obj_smhr_positions);
                if (dt.Rows.Count != 0)
                {
                    lbl_DestinationJob.Text = Convert.ToString(dt.Rows[0]["JOBS_CODE"]);
                    if (Convert.ToString(dt.Rows[0]["JOBS_ID"]) != "")
                    {
                        SMHR_JOBS _obj_Jobs = new SMHR_JOBS();
                        _obj_Jobs.JOBS_ID = Convert.ToInt32(dt.Rows[0]["JOBS_ID"]);
                        DataTable dt1 = BLL.get_Jobs(_obj_Jobs);
                        maxsal = Convert.ToDouble(dt1.Rows[0]["JOBS_MAXSAL"]);
                        minsal = Convert.ToDouble(dt1.Rows[0]["JOBS_MINSAL"]);
                        if (txt_MonthlyGross.Text != "")
                        {
                            //for validating job minsal and maxsal with the gross                        
                            if (!((Convert.ToDouble(txt_MonthlyGross.Text) >= minsal) && (Convert.ToDouble(txt_MonthlyGross.Text) <= maxsal)))
                            {
                                BLL.ShowMessage(this, "Gross Must be in the range of Selected Job Min and Max Salary:" + minsal + "-" + maxsal);
                                txt_MonthlyGross.Text = "";
                                txt_MonthlyBasic.Text = "";
                                return;
                            }

                        }
                    }
                }
            }
            //lbl_DestinationJob.Text = Convert.ToString(dt.Rows[0]["JOBS_CODE"]);

            //rcmb_DestinationJob.DataSource = dt;
            //rcmb_DestinationJob.DataTextField = "JOBS_CODE";
            //rcmb_DestinationJob.DataValueField = "JOBS_ID";
            //rcmb_DestinationJob.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeCopy", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void getPosition()
    {
        try
        {
            rcmb_DestinationPosition.Items.Clear();
            SMHR_POSITIONS _obj_smhr_positions = new SMHR_POSITIONS();
            _obj_smhr_positions.OPERATION = operation.Select;
            _obj_smhr_positions.JOBLOC_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_DestinationBU.SelectedValue);
            _obj_smhr_positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            rcmb_DestinationPosition.DataSource = BLL.get_BUPositions(_obj_smhr_positions);
            rcmb_DestinationPosition.DataTextField = "POSITIONS_CODE";
            rcmb_DestinationPosition.DataValueField = "POSITIONS_ID";
            rcmb_DestinationPosition.DataBind();
            rcmb_DestinationPosition.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeCopy", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }


    protected void txt_AnnualGross_TextChanged(object sender, EventArgs e)
    {
        try
        {
            //getEmployee();
            CheckBox chk = new CheckBox();
            Label lbl_Emp_Id = new Label();
            for (int iEmpId = 0; iEmpId < rg_Employee.Items.Count; iEmpId++)
            {
                chk = rg_Employee.Items[iEmpId].FindControl("chk_Select") as CheckBox;
                lbl_Emp_Id = rg_Employee.Items[iEmpId].FindControl("lbl_EmployeeID") as Label;
                if (chk.Checked)
                {
                    I_ChkCount = I_ChkCount + 1;
                    _obj_SMHR_EMPLOYEE = new SMHR_EMPLOYEE();
                    _obj_SMHR_EMPLOYEE.OPERATION = operation.Select;
                    _obj_SMHR_EMPLOYEE.EMP_ID = Convert.ToInt32(lbl_Emp_Id.Text);
                    _obj_SMHR_EMPLOYEE.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    dt_Details = BLL.get_Employee(_obj_SMHR_EMPLOYEE);
                }
            }
            if (I_ChkCount == 0)
            {
                BLL.ShowMessage(this, "Please Select Employees");
                txt_AnnualGross.Text = "";
                return;
            }
            if (Convert.ToString(dt_Details.Rows[0]["EMP_EMPLOYEETYPE"]).Trim() == "CONTRACT")
            {
                contracts = true;
            }
            Calculate_AnnualBasic();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeCopy", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void txt_MonthlyGross_TextChanged(object sender, EventArgs e)
    {
        try
        {
            //getEmployee();
            CheckBox chk = new CheckBox();
            Label lbl_Emp_Id = new Label();
            for (int iEmpId = 0; iEmpId < rg_Employee.Items.Count; iEmpId++)
            {
                chk = rg_Employee.Items[iEmpId].FindControl("chk_Select") as CheckBox;
                lbl_Emp_Id = rg_Employee.Items[iEmpId].FindControl("lbl_EmployeeID") as Label;
                if (chk.Checked)
                {
                    I_ChkCount = I_ChkCount + 1;
                    _obj_SMHR_EMPLOYEE = new SMHR_EMPLOYEE();
                    _obj_SMHR_EMPLOYEE.OPERATION = operation.Select;
                    _obj_SMHR_EMPLOYEE.EMP_ID = Convert.ToInt32(lbl_Emp_Id.Text);
                    _obj_SMHR_EMPLOYEE.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    dt_Details = BLL.get_Employee(_obj_SMHR_EMPLOYEE);
                }
            }
            if (I_ChkCount == 0)
            {
                BLL.ShowMessage(this, "Please Select Employees");
                txt_MonthlyGross.Text = "";
                return;
            }
            if (Convert.ToString(dt_Details.Rows[0]["EMP_EMPLOYEETYPE"]).Trim() == "CONTRACT")
            {
                contracts = true;
            }
            Calculate_Basic();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeCopy", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    //private void getEmployee()
    //{
    //    CheckBox chk = new CheckBox();
    //    Label lbl_Emp_Id = new Label();
    //    for (int iEmpId = 0; iEmpId < rg_Employee.Items.Count; iEmpId++)
    //    {
    //        chk = rg_Employee.Items[iEmpId].FindControl("chk_Select") as CheckBox;
    //        lbl_Emp_Id = rg_Employee.Items[iEmpId].FindControl("lbl_EmployeeID") as Label;
    //        if (chk.Checked)
    //        {
    //            I_ChkCount = I_ChkCount + 1;
    //            _obj_SMHR_EMPLOYEE = new SMHR_EMPLOYEE();
    //            _obj_SMHR_EMPLOYEE.OPERATION = operation.Select;
    //            _obj_SMHR_EMPLOYEE.EMP_ID = Convert.ToInt32(lbl_Emp_Id.Text);
    //            _obj_SMHR_EMPLOYEE.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //            dt_Details = BLL.get_Employee(_obj_SMHR_EMPLOYEE);
    //        }
    //    }
    //    if (I_ChkCount == 0)
    //    {
    //        BLL.ShowMessage(this, "Please Select Employees");
    //        return;
    //    }
    //}

    private void Calculate_AnnualBasic()
    {
        try
        {
            if (txt_AnnualGross.Text != string.Empty)
            {
                if (Convert.ToDouble(txt_AnnualGross.Text) >= 0)
                {
                    if (contracts)
                    {
                        txt_AnnualBasic.Text = txt_AnnualGross.Text;
                        txt_MonthlyGross.Text = Convert.ToString(Convert.ToDouble(txt_AnnualGross.Text) / 12);
                        txt_MonthlyBasic.Text = Convert.ToString(Convert.ToDouble(txt_AnnualBasic.Text) / 12);
                        if (lbl_DestinationJob.Text != "")
                        {
                            if (!((Convert.ToDouble(txt_AnnualGross.Text) >= minsal) && (Convert.ToDouble(txt_AnnualGross.Text) <= maxsal)))
                            {
                                BLL.ShowMessage(this, "Gross Must be in the range of Selected Job Min and Max Salary:" + minsal + "-" + maxsal);
                                txt_AnnualGross.Text = "";
                                txt_AnnualBasic.Text = "";
                                return;
                            }
                        }
                    }
                    else
                    {
                        //code for getting Basic percentage of Gross For the businessunit selected
                        _obj_SMHR_BUSINESSUNIT = new SMHR_BUSINESSUNIT();
                        _obj_SMHR_BUSINESSUNIT.OPERATION = operation.Select;
                        _obj_SMHR_BUSINESSUNIT.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_DestinationBU.SelectedValue);
                        _obj_SMHR_BUSINESSUNIT.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dt_BusinessUnit = BLL.get_BusinessUnit(_obj_SMHR_BUSINESSUNIT);
                        if ((dt_BusinessUnit.Rows.Count > 0) && (rcmb_DestinationBU.SelectedValue != string.Empty))
                        {
                            if (dt_BusinessUnit.Rows[0]["BUSINESSUNIT_BASICPERCENT"] != System.DBNull.Value)
                            {
                                float IBasicPercent = Convert.ToSingle(dt_BusinessUnit.Rows[0]["BUSINESSUNIT_BASICPERCENT"]);

                                float emp_GrossSal = Convert.ToSingle(txt_AnnualGross.Text.Replace("'", "''"));
                                //float emp_BasicSal = (55 * emp_GrossSal) / 100;
                                float emp_BasicSal = (IBasicPercent * emp_GrossSal) / 100;
                                txt_AnnualBasic.Text = Convert.ToString(emp_BasicSal);
                                txt_MonthlyGross.Text = Convert.ToString(Convert.ToDouble(txt_AnnualGross.Text) / 12);
                                txt_MonthlyBasic.Text = Convert.ToString(Convert.ToDouble(txt_AnnualBasic.Text) / 12);
                                txt_AnnualGross.Focus();
                                if (lbl_DestinationJob.Text != "")
                                {
                                    if (!((Convert.ToDouble(txt_MonthlyGross.Text) >= minsal) && (Convert.ToDouble(txt_MonthlyGross.Text) <= maxsal)))
                                    {
                                        BLL.ShowMessage(this, "Gross Must be in the range of Selected Job Min and Max Salary:" + minsal + "-" + maxsal);
                                        //txt_AnnualGross.Text = "";
                                        //txt_AnnualBasic.Text = "";
                                        //txt_MonthlyGross.Text = "";
                                        //txt_MonthlyBasic.Text = "";
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                BLL.ShowMessage(this, "Basic Is Not Defined For The Businessunit:" + rcmb_DestinationBU.SelectedItem.Text);
                                txt_AnnualGross.Text = "";
                                return;
                            }
                        }
                        else
                        {
                            BLL.ShowMessage(this, "Select Proper Businessunit");
                            txt_AnnualGross.Text = "";
                        }

                    }
                }
                else
                {
                    BLL.ShowMessage(this, "Gross Must be Greater Than Zero!");
                    txt_AnnualBasic.Text = "";
                    txt_AnnualGross.Focus();
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeCopy", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void Calculate_Basic()
    {
        try
        {
            if (txt_MonthlyGross.Text != string.Empty)
            {
                if (Convert.ToDouble(txt_MonthlyGross.Text) >= 0)
                {
                    if (contracts)
                    {
                        txt_MonthlyBasic.Text = txt_MonthlyGross.Text;
                        if (lbl_DestinationJob.Text != "")
                        {
                            if (!((Convert.ToDouble(txt_MonthlyGross.Text) >= minsal) && (Convert.ToDouble(txt_MonthlyGross.Text) <= maxsal)))
                            {
                                BLL.ShowMessage(this, "Gross Must be in the range of Selected Job Min and Max Salary:" + minsal + "-" + maxsal);
                                txt_MonthlyGross.Text = "";
                                txt_MonthlyBasic.Text = "";
                                return;
                            }
                        }
                    }
                    else
                    {
                        //code for getting Basic percentage of Gross For the businessunit selected
                        _obj_SMHR_BUSINESSUNIT = new SMHR_BUSINESSUNIT();
                        _obj_SMHR_BUSINESSUNIT.OPERATION = operation.Select;
                        _obj_SMHR_BUSINESSUNIT.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_DestinationBU.SelectedValue);
                        _obj_SMHR_BUSINESSUNIT.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dt_BusinessUnit = BLL.get_BusinessUnit(_obj_SMHR_BUSINESSUNIT);
                        if ((dt_BusinessUnit.Rows.Count > 0) && (rcmb_DestinationBU.SelectedValue != string.Empty))
                        {
                            if (dt_BusinessUnit.Rows[0]["BUSINESSUNIT_BASICPERCENT"] != System.DBNull.Value)
                            {
                                float IBasicPercent = Convert.ToSingle(dt_BusinessUnit.Rows[0]["BUSINESSUNIT_BASICPERCENT"]);

                                float emp_GrossSal = Convert.ToSingle(txt_MonthlyGross.Text.Replace("'", "''"));
                                //float emp_BasicSal = (55 * emp_GrossSal) / 100;
                                float emp_BasicSal = (IBasicPercent * emp_GrossSal) / 100;
                                txt_MonthlyBasic.Text = Convert.ToString(emp_BasicSal);
                                if (lbl_DestinationJob.Text != "")
                                {
                                    if (!((Convert.ToDouble(txt_MonthlyGross.Text) >= minsal) && (Convert.ToDouble(txt_MonthlyGross.Text) <= maxsal)))
                                    {
                                        BLL.ShowMessage(this, "Gross Must be in the range of Selected Job Min and Max Salary:" + minsal + "-" + maxsal);
                                        txt_MonthlyGross.Text = "";
                                        txt_MonthlyBasic.Text = "";
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                BLL.ShowMessage(this, "Basic Is Not Defined For The Businessunit:" + rcmb_DestinationBU.SelectedItem.Text);
                                txt_MonthlyGross.Text = "";
                                return;
                            }
                        }
                        else
                        {
                            BLL.ShowMessage(this, "Select Proper Businessunit");
                            txt_MonthlyGross.Text = "";
                        }

                    }
                }
                else
                {
                    BLL.ShowMessage(this, "Gross Must be Greater Than Zero!");
                    txt_MonthlyBasic.Text = "";
                    txt_MonthlyGross.Focus();
                }
            }
            //else
            //{
            //    BLL.ShowMessage(this, "Enter Gross Salary");
            //    txt_GrossSalary.Focus();
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeCopy", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    public void LoadAnnual()
    {
        try
        {
            _obj_SMHR_ORGANISATION = new SMHR_ORGANISATION();
            _obj_SMHR_ORGANISATION.MODE = 2;
            _obj_SMHR_ORGANISATION.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Organisation = BLL.get_Organisation(_obj_SMHR_ORGANISATION);
            if (dt_Organisation.Rows.Count != 0)
            {
                if (Convert.ToString(dt_Organisation.Rows[0]["ORGANISATION_ANNUALPROCESS"]) != "")
                {
                    if (Convert.ToString(dt_Organisation.Rows[0]["ORGANISATION_ANNUALPROCESS"]).ToUpper() == "TRUE")
                    {
                        tr_AnnualGross.Visible = true;
                        tr_AnnualBasic.Visible = true;
                        txt_MonthlyGross.Enabled = false;
                        txt_MonthlyBasic.Enabled = false;
                        //td_MonthlySalary.Visible = false;
                        //td_Empty.Visible = true;
                    }
                    else
                    {
                        tr_AnnualGross.Visible = false;
                        tr_AnnualBasic.Visible = false;
                        txt_MonthlyGross.Enabled = true;
                        txt_MonthlyBasic.Enabled = false;
                        //td_MonthlySalary.Visible = true;
                        //td_Empty.Visible = false;
                    }
                }
                else
                {
                    tr_AnnualGross.Visible = false;
                    tr_AnnualBasic.Visible = false;
                    txt_MonthlyGross.Enabled = true;
                    txt_MonthlyBasic.Enabled = false;
                    //td_MonthlySalary.Visible = true;
                    //td_Empty.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeCopy", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

}
