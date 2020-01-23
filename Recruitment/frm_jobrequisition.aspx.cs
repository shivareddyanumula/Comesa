﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using Telerik.Web.UI;
using RECRUITMENT;
using SMHR;


public partial class Recruitment_frm_JobRequisition : System.Web.UI.Page
{

    SMHR_GLOBALCONFIG _obj_smhr_globalConfig;
    //SMHR_MASTERS _obj_Smhr_Masters;
    SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit;
    //SMHR_EMPLOYEE _obj_smhr_employee;
    //SMHR_DEPARTMENT _obj_SMHR_Department;
    //SMHR_POSITIONS _obj_smhr_Position;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    RECRUITMENT_JOBREQUISITION _obj_Rec_JobRequisition;
    //RECRUITMENT_JOBREQSKILLS _obj_Rec_JobReqSkills;
    //SMHR_MASTERS _obj_smhr_masters;

    static DataTable dt_Details = new DataTable();
    //remove the foll
    static int OrganizationID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
            if (!Page.IsPostBack)
            {
                LoadPeriod();
                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Job Requisition");//COUNTRY");
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
                    Rg_JobRequisition.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
                if (Request.QueryString["JOBREQ_ID"] != null)
                {
                    lnk_Edit_Command(null, null);
                }

                OrganizationID = Convert.ToInt32(Session["ORG_ID"]);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_jobrequisition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected override void InitializeCulture()
    {
        Recruitment_BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    //private void LoadCombos()
    //{
    //    try
    //    {
    //        _obj_Smhr_Masters = new SMHR_MASTERS();
    //        _obj_Smhr_Masters.OPERATION = operation.Select;
    //        _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
    //        _obj_Smhr_Masters.MASTER_TYPE = "QUALIFICATION";
    //        dt_Details = BLL.get_MasterRecords(_obj_Smhr_Masters);
    //        if (dt_Details.Rows.Count > 0)
    //        {
    //            //rcmb_Qualification.DataSource = dt_Details;
    //            rlb_Qualification.DataSource = dt_Details;
    //            rlb_Qualification.DataTextField = "HR_MASTER_CODE";
    //            rlb_Qualification.DataValueField = "HR_MASTER_ID";
    //            rlb_Qualification.DataBind();
    //            //rcmb_Qualification.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
    //        }

    //        _obj_Smhr_Masters.OPERATION = operation.Select;
    //        _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
    //        _obj_Smhr_Masters.MASTER_TYPE = "SKILL";
    //        dt_Details = BLL.get_MasterRecords(_obj_Smhr_Masters);
    //        if (dt_Details.Rows.Count > 0)
    //        {
    //            rlb_SkillReq.DataSource = dt_Details;
    //            rlb_SkillReq.DataTextField = "HR_MASTER_CODE";
    //            rlb_SkillReq.DataValueField = "HR_MASTER_ID";
    //            rlb_SkillReq.DataBind();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_jobrequisition", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //        return;
    //    }
    //}
    //private void LoadDropDowns()
    //{
    //    try
    //    {
    //        //Grade
    //        _obj_smhr_masters = new SMHR_MASTERS();
    //        rcmb_Grade.Items.Clear();
    //        _obj_smhr_masters.MASTER_TYPE = "GRADE";
    //        _obj_smhr_masters.OPERATION = operation.Select;
    //        _obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //        dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);
    //        rcmb_Grade.DataSource = dt_Details;
    //        rcmb_Grade.DataTextField = "HR_MASTER_CODE";
    //        rcmb_Grade.DataValueField = "HR_MASTER_ID";
    //        rcmb_Grade.DataBind();
    //        rcmb_Grade.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_jobrequisition", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //        return;
    //    }
    //}

    private void LoadBusinessUnit()
    {
        try
        {
            #region comments
            //_obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
            //_obj_Smhr_BusinessUnit.OPERATION = operation.Select;
            //_obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            //_obj_Smhr_BusinessUnit.ISDELETED = true;
            //// _obj_Smhr_BusinessUnit.BUSINESSUNIT_ID = Convert.ToInt32(Session["BUSINESSUNIT_ID"].ToString());
            //rcmb_BU.Items.Clear();
            //DataTable dt = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
            //if (dt.Rows.Count != 0)
            //{
            //    rcmb_BU.DataSource = dt;
            //    rcmb_BU.DataTextField = "BUSINESSUNIT_CODE";
            //    rcmb_BU.DataValueField = "BUSINESSUNIT_ID";
            //    rcmb_BU.DataBind();
            //    rcmb_BU.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            //}
            //else
            //{
            //    DataTable dt1 = new DataTable();
            //    rcmb_BU.DataSource = dt1;
            //    rcmb_BU.DataBind();
            //    rcmb_BU.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            //    return;
            //}
            #endregion comments

            if ((Convert.ToInt32(Session["EMP_ID"]) == 0))
            {
                //FOR ADMIN
                // Loading Business Unit 
                rcmb_BU.Items.Clear();
                _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
                _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
                if (dt_BUDetails.Rows.Count > 0)
                {
                    rcmb_BU.DataSource = dt_BUDetails;
                    rcmb_BU.DataValueField = "BUSINESSUNIT_ID";
                    rcmb_BU.DataTextField = "BUSINESSUNIT_CODE";
                    rcmb_BU.DataBind();
                }
                rcmb_BU.Items.Insert(0, new RadComboBoxItem("Select"));
                rcmb_RaisedBy.Items.Clear();
                //rcmb_RaisedBy.Items.Insert(0, new RadComboBoxItem("Select"));
            }
            else
            {
                //FOR SELF EMPLOYEE and MANAGER
                // Loading Business Unit 
                rcmb_BU.Items.Clear();
                _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
                _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
                if (dt_BUDetails.Rows.Count > 0)
                {
                    rcmb_BU.DataSource = dt_BUDetails;
                    rcmb_BU.DataValueField = "BUSINESSUNIT_ID";
                    rcmb_BU.DataTextField = "BUSINESSUNIT_CODE";
                    rcmb_BU.DataBind();
                }
                rcmb_BU.Items.Insert(0, new RadComboBoxItem("Select"));
                rcmb_RaisedBy.Items.Clear();
                //rcmb_EmployeeCode.Items.Insert(0, new RadComboBoxItem("Select"));


                SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
                _obj_smhr_emp_payitems.OPERATION = operation.Self;
                _obj_smhr_emp_payitems.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable DT_SELF = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
                if (DT_SELF.Rows.Count > 0)
                {
                    //rcmb_BU.SelectedIndex  = rcmb_BU.FindItemIndexByValue(Convert.ToString(DT_SELF.Rows[0]["EMP_BUSINESSUNIT_ID"]));
                    rcmb_BU.SelectedValue = Convert.ToString(DT_SELF.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                }
                LoadEmployee();
                rcmb_RaisedBy.SelectedIndex = rcmb_RaisedBy.FindItemIndexByValue(DT_SELF.Rows[0]["EMP_ID"].ToString());
                rcmb_BU.Enabled = false;
                rcmb_RaisedBy.Enabled = false;
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_jobrequisition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void LoadEmployee()
    {
        try
        {
            //if (Session["EMP_ID"] != null)
            //{
            //    _obj_smhr_employee = new SMHR_EMPLOYEE();
            //    _obj_smhr_employee.OPERATION = operation.load;
            //    _obj_smhr_employee.EMP_ID = Convert.ToInt32(Session["EMP_ID"].ToString());
            //    rcmb_RaisedBy.Items.Clear();
            //    DataTable dt = BLL.get_Employee(_obj_smhr_employee);
            //    if (dt.Rows.Count != 0)
            //    {
            //        rcmb_RaisedBy.DataSource = dt;
            //        rcmb_RaisedBy.DataTextField = "EMPNAME";
            //        rcmb_RaisedBy.DataValueField = "EMP_ID";
            //        rcmb_RaisedBy.DataBind();
            //    }
            //    else
            //    {
            //        DataTable dt1 = new DataTable();
            //        rcmb_RaisedBy.DataSource = dt1;
            //        rcmb_RaisedBy.DataBind();
            //        return;
            //    }
            //}

            SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
            //_obj_smhr_emp_payitems.OPERATION = operation.Empty;
            DataTable DT_Details = new DataTable();
            if (rcmb_BU.SelectedItem.Value != "")
            {
                if (Convert.ToString(Session["SELFSERVICE"]) == "")
                {
                    _obj_smhr_emp_payitems.OPERATION = operation.Empty_Self;
                    _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
                    _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_emp_payitems.REPORTING_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                    DT_Details = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
                    if (DT_Details.Rows.Count != 0)
                    {
                        BindEmployees(DT_Details);
                    }
                    else
                    {
                        BindEmployees(DT_Details);
                    }
                }
                else
                {

                    _obj_smhr_emp_payitems.OPERATION = operation.Empty;
                    _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
                    _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DT_Details = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
                    if (DT_Details.Rows.Count != 0)
                    {
                        BindEmployees(DT_Details);
                    }
                    else
                    {
                        BindEmployees(DT_Details);
                    }
                }
            }
            else
            {
                BindEmployees(DT_Details);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_jobrequisition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void LoadPeriod()
    {
        try
        {
            rcbFinPeriod.Items.Clear();
            SMHR_PERIOD PRD = new SMHR_PERIOD();
            PRD.OPERATION = operation.PERIOD;
            PRD.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT = new DataTable();
            DT = BLL.GetEmployeePeriod(PRD);
            //rcbFinPeriod.DataSource = BLL.GetEmployeePeriod(PRD);
            if (DT.Rows.Count > 0)
            {
                rcbFinPeriod.DataSource = DT;
                rcbFinPeriod.DataTextField = "PERIOD_NAME";
                rcbFinPeriod.DataValueField = "PERIOD_ID";
                rcbFinPeriod.DataBind();
            }
            rcbFinPeriod.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void BindEmployees(DataTable DT_Details)
    {
        try
        {
            rcmb_RaisedBy.DataSource = DT_Details;
            rcmb_RaisedBy.DataTextField = "EMPNAME";
            rcmb_RaisedBy.DataValueField = "EMP_ID";
            rcmb_RaisedBy.DataBind();
            rcmb_RaisedBy.Items.Insert(0, new RadComboBoxItem("Select/Enter Name"));

            rcmb_interviewer.DataSource = DT_Details;
            rcmb_interviewer.DataTextField = "EMPNAME";
            rcmb_interviewer.DataValueField = "EMP_ID";
            rcmb_interviewer.DataBind();
            rcmb_interviewer.Items.Insert(0, new RadComboBoxItem("Select/Enter Name"));


            //if (Convert.ToInt32(Session["EMP_ID"]) == 0)
            //{
            //    rcmb_RaisedBy.Enabled = true;
            //}
            //else
            //{
            //    rcmb_RaisedBy.SelectedIndex = rcmb_RaisedBy.Items.FindItemIndexByValue(Convert.ToString(Session["EMP_ID"]));
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_jobrequisition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void rcmb_BU_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            //LoadCurrSymbol();
            //LoadDepartment();
            ClearControl1();
            if (rcmb_BU.SelectedIndex > 0)
            {
                LoadJobs();
                //LoadPositions();
                LoadEmployee();
                LoadEmployeeType();
                //LoadGrades();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_jobrequisition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadJobs()
    {
        try
        {
            // SMHR_JOBS _obj_Smhr_Jobs = new SMHR_JOBS();
            //// _obj_Smhr_Jobs.OPERATION = operation.Select;
            // _obj_Smhr_Jobs.OPERATION = operation.Delete1;//load only active jobs
            // _obj_Smhr_Jobs.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            // _obj_Smhr_Jobs.ISDELETED = false;
            // rcmb_Job.DataSource = BLL.get_Jobs(_obj_Smhr_Jobs);
            // rcmb_Job.DataTextField = "JOBS_CODE";
            // rcmb_Job.DataValueField = "JOBS_ID";
            // rcmb_Job.DataBind();
            // rcmb_Job.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

            if (rcmb_BU.SelectedIndex > 0)
            {
                rcmb_Job.Items.Clear();
                SMHR_JOBS _obj_Jobs = new SMHR_JOBS();
                _obj_Jobs.OPERATION = operation.Get;
                _obj_Jobs.BUID = Convert.ToInt32(rcmb_BU.SelectedValue);
                _obj_Jobs.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable DT = BLL.get_Jobs(_obj_Jobs);
                rcmb_Job.DataSource = DT;
                rcmb_Job.DataTextField = "JOBS_CODE";
                rcmb_Job.DataValueField = "JOBS_ID";
                rcmb_Job.DataBind();
                rcmb_Job.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            }
            else
            {
                rcmb_Job.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                rcmb_Designation.Items.Clear();
                rcmb_Designation.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                //rcmb_Grade.Items.Clear();
                //ddl_Grade.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_jobrequisition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    //protected void rcmb_dept_interviewer_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    //{
    //    try
    //    {
    //        if (rcmb_dept_interviewer.SelectedIndex > 0)
    //        {
    //            rcmb_interviewer.Items.Clear();
    //            _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
    //            _obj_Rec_JobRequisition.JOBREQ_DEPARTMENT = Convert.ToInt32(rcmb_dept_interviewer.SelectedItem.Value);
    //            _obj_Rec_JobRequisition.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //            _obj_Rec_JobRequisition.MODE = 16;
    //            DataTable dt = Recruitment_BLL.get_JobRequisition(_obj_Rec_JobRequisition);
    //            if (dt.Rows.Count > 0)
    //            {
    //                string str = string.Empty;

    //                foreach (RadListBoxItem item in rlst_interviewer.Items)
    //                {
    //                    str += item.Value + ",";
    //                }
    //                if (str.Length > 0)
    //                {
    //                    str = str.Remove(str.Length - 1, 1);
    //                    dt.DefaultView.RowFilter = " EMP_ID not in (" + str + ")";
    //                    dt = dt.DefaultView.ToTable();
    //                }

    //                rcmb_interviewer.DataSource = dt;
    //                rcmb_interviewer.DataTextField = "EMP_NAME";
    //                rcmb_interviewer.DataValueField = "EMP_ID";
    //                rcmb_interviewer.DataBind();
    //                rcmb_interviewer.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
    //            }
    //            else
    //            {
    //                rcmb_interviewer.DataSource = dt_Details;
    //                rcmb_interviewer.DataBind();
    //                rcmb_interviewer.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
    //            }
    //        }
    //        else
    //        {
    //            rcmb_interviewer.Items.Clear();
    //            SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
    //            _obj_smhr_emp_payitems.OPERATION = operation.Empty;
    //            _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
    //            _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //            DataTable DT_Details = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
    //            if (dt_Details.Rows.Count > 0)
    //            {
    //                rcmb_interviewer.DataSource = DT_Details;
    //                rcmb_interviewer.DataTextField = "EMPNAME";
    //                rcmb_interviewer.DataValueField = "EMP_ID";
    //                rcmb_interviewer.DataBind();
    //                rcmb_interviewer.Items.Insert(0, new RadComboBoxItem("Select"));
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_jobrequisition", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //        return;
    //    }
    //}
    //protected void LoadCurrSymbol()
    //{
    //    if (rcmb_BU.SelectedIndex > 0)
    //    {
    //        _obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
    //        _obj_Smhr_BusinessUnit.OPERATION = operation.load;
    //        //  if (Session["ORG_ID"] != null)
    //        //if (rcmb_BU.SelectedItem.Value=)
    //        //{
    //        _obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
    //        _obj_Smhr_BusinessUnit.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
    //        // }
    //        DataTable dt = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
    //        if (dt.Rows.Count != 0)
    //        {
    //            //lbl_ctc.Visible = true;
    //            //lbl_ctc.Text = Convert.ToString(dt.Rows[0]["CURR_SYMBOL"]);
    //        }
    //        else
    //        {
    //            //lbl_ctc.Visible = true;
    //            //lbl_ctc.Text = "";
    //        }
    //    }
    //}

    //private void LoadDepartment()
    //{
    //    _obj_SMHR_Department = new SMHR_DEPARTMENT();
    //    _obj_SMHR_Department.MODE = 9;
    //    _obj_SMHR_Department.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
    //    _obj_SMHR_Department.BUID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
    //    dt_Details = BLL.get_Department(_obj_SMHR_Department);
    //    if (dt_Details.Rows.Count != 0)
    //    {
    //        rcmb_Department.DataSource = dt_Details;
    //        rcmb_Department.DataTextField = "DEPARTMENT_NAME";
    //        rcmb_Department.DataValueField = "DEPARTMENT_ID";
    //        rcmb_Department.DataBind();
    //        rcmb_Department.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

    //        ////Interviewer Department
    //        //rcmb_dept_interviewer.DataSource = dt_Details;
    //        //rcmb_dept_interviewer.DataTextField = "DEPARTMENT_NAME";
    //        //rcmb_dept_interviewer.DataValueField = "DEPARTMENT_ID";
    //        //rcmb_dept_interviewer.DataBind();
    //        //rcmb_dept_interviewer.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
    //    }
    //    else
    //    {
    //        rcmb_Department.DataSource = dt_Details;
    //        rcmb_Department.DataBind();
    //        rcmb_Department.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

    //        //rcmb_dept_interviewer.DataSource = dt_Details;
    //        //rcmb_dept_interviewer.DataBind();
    //        //rcmb_dept_interviewer.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
    //        return;
    //    }

    //}

    private void getJrNo()
    {
        try
        {
            DataTable dt_code;
            string code = string.Empty;
            string str = string.Empty;
            string Series = string.Empty;
            //_obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
            _obj_Rec_JobRequisition.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Rec_JobRequisition.OPERATION = operation.load;
            dt_code = Recruitment_BLL.get_JrCode(_obj_Rec_JobRequisition);
            if (dt_code.Rows.Count != 0)
            {
                str = dt_code.Rows[0][0].ToString().Trim();
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
                _obj_smhr_globalConfig = new SMHR_GLOBALCONFIG();
                _obj_smhr_globalConfig.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_smhr_globalConfig.OPERATION = operation.Select;
                DataTable dt = BLL.get_ConfigDetails(_obj_smhr_globalConfig);
                if (dt.Rows.Count != 0)
                {
                    rtxt_JRCode.Text = dt.Rows[0]["GLOBALCONFIG_RECRUIT_JOBREQ_CODE"].ToString().Trim() + Convert.ToString(Series) + Convert.ToString(str);
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_jobrequisition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void LoadGrid()
    {
        try
        {
            if (Convert.ToInt32(Session["EMP_ID"]) == 0)
            {
                _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
                _obj_Rec_JobRequisition.MODE = 6;
                _obj_Rec_JobRequisition.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable DT = Recruitment_BLL.get_JobRequisition(_obj_Rec_JobRequisition);
                Rg_JobRequisition.DataSource = DT;
            }
            else
            {
                _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
                _obj_Rec_JobRequisition.OPERATION = operation.Select;
                _obj_Rec_JobRequisition.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Rec_JobRequisition.JOBREQ_RAISEDBY = Convert.ToInt32(Session["EMP_ID"]);
                DataTable DT = Recruitment_BLL.get_JobRequisition(_obj_Rec_JobRequisition);
                Rg_JobRequisition.DataSource = DT;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_jobrequisition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Rg_JobRequisition_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_jobrequisition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            //if ((Convert.ToInt32(Session["EMP_ID"]) != (-1)))
            //{
            //if (Convert.ToInt32(Session["EMP_ID"]) != 0)
            //{

            //clearControls();
            //LoadCombos();
            //LoadBusinessUnit();
            //LoadEmployee();

            //rcmb_Status.SelectedItem.Text = "open";
            //rcmb_Status.Enabled = false;

            //rcmb_RaisedBy.Enabled = false;
            //btn_Save.Visible = true;
            //btn_Update.Visible = false;

            //tr_ActDate.Visible = false;
            //Rm_JobRequisition_page.SelectedIndex = 1;

            if ((Convert.ToInt32(Session["EMP_ID"]) == 0))
            {
                clearControls();
                //LoadCombos(); //Commented bcoz qualifications & skills were loading from HR_MASTER table
                LoadBusinessUnit();
                LoadPeriod();
                //LoadGrades();
                //LoadDropDowns();  //Commented bcoz grades werer populating from HR_MASTER table
                rcmb_RaisedBy.Enabled = true;
                rtxt_Desc.Enabled = true;
                rcmb_BU.Enabled = true;
                //rcmb_Status.SelectedItem.Text = "open";
                rcmb_Status.Enabled = false;
                btn_Save.Visible = true;
                btn_Update.Visible = false;
                tr_ActDate.Visible = false;
                Rm_JobRequisition_page.SelectedIndex = 1;
                //rfv_RaisedBy.Visible = false;

                //LoadPositions();    //To load positions based on Organisation_ID
                //loadQualSkills();     //To load Qualifications, Grades/Scales, Skills
                LoadEmployeeType();    //To load employee types
            }
            else
            {
                clearControls();
                //LoadCombos();
                LoadBusinessUnit();
                LoadPeriod();
                //LoadGrades();
                //LoadDropDowns();
                rcmb_RaisedBy.Enabled = false;
                rcmb_BU.Enabled = false;
                rcmb_Status.SelectedItem.Text = "open";
                rcmb_Status.Enabled = false;
                btn_Save.Visible = true;
                btn_Update.Visible = false;
                tr_ActDate.Visible = false;
                Rm_JobRequisition_page.SelectedIndex = 1;

                rcmb_BU.SelectedIndex = 1;
                //rcmb_BU_SelectedIndexChanged(null, null);
                rcmb_RaisedBy.SelectedIndex = rcmb_RaisedBy.FindItemIndexByValue(Convert.ToString(Session["EMP_ID"]));
                rcmb_RaisedBy_SelectedIndexChanged(null, null);

                rtxt_Desc.Enabled = true;

                LoadJobs();
                //LoadPositions();    //To load positions based on Organisation_ID
                LoadEmployeeType();    //To load employee types
            }

            //}
            //    else

            //        BLL.ShowMessage(this, "You do not have permissions to login");
            //}
            //else
            //    BLL.ShowMessage(this, "You do not have permissions to login");
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_jobrequisition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

    }

    private void LoadEmployeeType()
    {
        try
        {
            _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
            _obj_Rec_JobRequisition.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Rec_JobRequisition.OPERATION = operation.Select;
            DataTable dtEmpType = Recruitment_BLL.GetEmpType(_obj_Rec_JobRequisition);
            rcmb_Emptype.Items.Clear();
            if (dtEmpType.Rows.Count > 0)
            {
                rcmb_Emptype.DataSource = dtEmpType;
                rcmb_Emptype.DataTextField = "EMPLOYEETYPE_CODE";
                rcmb_Emptype.DataValueField = "EMPLOYEETYPE_ID";
                rcmb_Emptype.DataBind();
            }
            rcmb_Emptype.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_jobrequisition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //public void loadQualSkills()
    //{
    //    try
    //    {

    //        SMHR_MASTERS _obj_Smhr_Masters = new SMHR_MASTERS();
    //        _obj_Smhr_Masters.OPERATION = operation.Select;
    //        _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
    //        _obj_Smhr_Masters.MASTER_TYPE = "QUALIFICATION";
    //        DataTable dt_Details = BLL.get_MasterRecords(_obj_Smhr_Masters);    //To load Qualifications
    //        if (dt_Details.Rows.Count > 0)
    //        {
    //            //rcmb_Qualification.DataSource = dt_Details;
    //            //rcmb_Qualification.DataTextField = "HR_MASTER_CODE";
    //            //rcmb_Qualification.DataValueField = "HR_MASTER_ID";
    //            //rcmb_Qualification.DataBind();
    //            rlb_Qualification.DataSource = dt_Details;
    //            rlb_Qualification.DataTextField = "HR_MASTER_CODE";
    //            rlb_Qualification.DataValueField = "HR_MASTER_ID";
    //            rlb_Qualification.DataBind();
    //        }

    //        //SMHR_JOBS _obj_Smhr_Jobs = new SMHR_JOBS();
    //        //_obj_Smhr_Jobs.OPERATION = operation.Select;
    //        //_obj_Smhr_Jobs.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
    //        //_obj_Smhr_Jobs.ISDELETED = false;
    //        //rcmb_PositionsJobs.DataSource = BLL.get_Jobs(_obj_Smhr_Jobs);
    //        //rcmb_PositionsJobs.DataTextField = "JOBS_CODE";
    //        //rcmb_PositionsJobs.DataValueField = "JOBS_ID";
    //        //rcmb_PositionsJobs.DataBind();
    //        //rcmb_PositionsJobs.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

    //        //BindFinancialPeriod();

    //        //SMHR_EMPLOYEEGRADE _obj_Smhr_EmployeeGrade = new SMHR_EMPLOYEEGRADE();
    //        //_obj_Smhr_EmployeeGrade.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //        //DataTable DT = BLL.get_EmployeeGrade(_obj_Smhr_EmployeeGrade).Tables[0];    //To fetch employee Grades/Scales
    //        //rcmb_Grade.Items.Clear();
    //        //rcmb_Grade.DataSource = DT;
    //        //rcmb_Grade.DataTextField = "CODERANK";
    //        //rcmb_Grade.DataValueField = "EMPLOYEEGRADE_ID";
    //        //rcmb_Grade.DataBind();
    //        //rcmb_Grade.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

    //        _obj_Smhr_Masters = new SMHR_MASTERS();
    //        _obj_Smhr_Masters.MASTER_TYPE = "SKILL";
    //        _obj_Smhr_Masters.OPERATION = operation.Select;
    //        _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //        rlb_SkillReq.Items.Clear();
    //        rlb_SkillReq.DataSource = BLL.get_MasterRecords(_obj_Smhr_Masters);     //To load skills
    //        rlb_SkillReq.DataTextField = "HR_MASTER_CODE";
    //        rlb_SkillReq.DataValueField = "HR_MASTER_ID";
    //        rlb_SkillReq.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Position", ex.StackTrace, DateTime.Now);
    //    }
    //}

    private void LoadPositions()
    {
        try
        {
            if (Session["ORG_ID"] != "")
            {
                if (rcmb_BU.SelectedIndex > 0 && rcmb_Job.SelectedValue != string.Empty)
                {
                    // added by joseph on 2009-11-21
                    rcmb_Designation.Items.Clear();
                    SMHR_POSITIONS _obj_smhr_positions = new SMHR_POSITIONS();
                    _obj_smhr_positions.OPERATION = operation.JOBPOSITIONS;
                    _obj_smhr_positions.POSITIONS_JOBSID = Convert.ToInt32(rcmb_Job.SelectedValue);
                    _obj_smhr_positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtPos = BLL.get_Positions(_obj_smhr_positions);
                    rcmb_Designation.DataSource = dtPos;
                    rcmb_Designation.DataTextField = "POSITIONS_CODE";
                    rcmb_Designation.DataValueField = "POSITIONS_ID";
                    rcmb_Designation.DataBind();
                    rcmb_Designation.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                    //
                }
                else
                {
                    rcmb_Designation.Items.Clear();
                    rcmb_Designation.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

                    //rcmb_Grade.Items.Clear();
                    //rcmb_Grade.Text = string.Empty;
                    //rcmb_Slab.Items.Clear();
                    //rcmb_Slab.Text = string.Empty;

                    //ddl_Grade.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                }

                //if (rcmb_BU.SelectedIndex > 0)
                //{
                //    SMHR_POSITIONS _obj_smhr_positions = new SMHR_POSITIONS();
                //    _obj_smhr_positions.OPERATION = operation.Select;
                //    _obj_smhr_positions.JOBLOC_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BU.SelectedValue);
                //    _obj_smhr_positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //    DataTable dtPos = BLL.get_BUPositions(_obj_smhr_positions);
                //    rcmb_Designation.DataSource = dtPos;
                //    rcmb_Designation.DataTextField = "POSITIONS_CODE";
                //    rcmb_Designation.DataValueField = "POSITIONS_ID";
                //    rcmb_Designation.DataBind();
                //    rcmb_Designation.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));                   
                //}
                //else
                //{
                //    BLL.ShowMessage(this, "Please Select Business Unit");
                //    return;
                //}
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_jobrequisition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private static bool IsBuSelected(RadComboBox rcmb_BU)
    {
        int OrganizationID = 0;
        int BusinessUnitID = 0;
        bool flag = false;
        try
        {

            OrganizationID = Convert.ToInt32(HttpContext.Current.Session["ORG_ID"].ToString());

            if (rcmb_BU.SelectedIndex > 0)
            {
                BusinessUnitID = Convert.ToInt32(rcmb_BU.SelectedValue);
                flag = true;
            }
            else
            {
                BLL.ShowMessage(rcmb_BU, "Select Business Unit");
                flag = false;
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(HttpContext.Current.Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_jobrequisition", ex.StackTrace, DateTime.Now);
            HttpContext.Current.Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return flag;
    }

    /*private void LoadGrades()
    {
        try
        {
            rcmb_Grade.Items.Clear();

            SMHR_EMPLOYEEGRADE _obj_Emp_Grade = new SMHR_EMPLOYEEGRADE();

            rcmb_Grade.Items.Clear();
            //rcmb_Grade.ClearSelection();

            _obj_Emp_Grade.OPERATION = operation.EmployeeGrade;
            _obj_Emp_Grade.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            DataTable dt = BLL.GetEmployeeGrade(_obj_Emp_Grade);

            if (dt.Rows.Count > 0)
            {
                rcmb_Grade.DataSource = dt;
                rcmb_Grade.DataTextField = "EMPLOYEEGRADE_CODE";
                rcmb_Grade.DataValueField = "EMPLOYEEGRADE_ID";
                rcmb_Grade.DataBind();
            }
            rcmb_Grade.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }*/

    //[WebMethod]
    //public static RadComboBoxItemData[] GET_EmployeeBySearchString(object context)
    //{
    //    IDictionary<string, object> contextDictionary = (IDictionary<string, object>)context;

    //    string filterString = ((string)contextDictionary["FilterString"]).Length > 2 ? ((string)contextDictionary["FilterString"]).ToLower() : "";

    //    DataTable dtEMPData = BLL.get_EmployeeBySearchString(OrganizationID, filterString);

    //    List<RadComboBoxItemData> result = new List<RadComboBoxItemData>(dtEMPData.Rows.Count);
    //    foreach (DataRow row in dtEMPData.Rows)
    //    {
    //        RadComboBoxItemData itemData = new RadComboBoxItemData();
    //        itemData.Text = row["EMPNAME"].ToString();
    //        itemData.Value = row["EMP_ID"].ToString();
    //        result.Add(itemData);
    //    }
    //    return result.ToArray();
    //}

    [WebMethod]
    //public static RadComboBoxItemData[] GET_EmployeeBySearchStr(object context, RadComboBox rcmb_BU)
    public static RadComboBoxItemData[] GET_EmployeeBySearchStr(object context) //, RadComboBox rcmb_BU)
    {
        //try
        //{
        int OrganizationID = 0;
        int BusinessUnitID = 0;

        OrganizationID = Convert.ToInt32(HttpContext.Current.Session["ORG_ID"].ToString());

        //if (rcmb_BU.SelectedIndex > 0)
        //{
        //    BusinessUnitID = Convert.ToInt32(rcmb_BU.SelectedValue);
        //}
        //else
        //{
        //    BLL.ShowMessage(rcmb_BU, "Select Business Unit");
        //    return null;
        //}
        IDictionary<string, object> contextDictionary = (IDictionary<string, object>)context;

        string filterString = ((string)contextDictionary["FilterString"]).Length > 2 ? ((string)contextDictionary["FilterString"]).ToLower() : "";
        if (Convert.ToInt32(contextDictionary["BUID"]) == 0)
        {
            return null;
        }
        BusinessUnitID = Convert.ToInt32(((string)contextDictionary["BUID"]).Length > 0 ? ((string)contextDictionary["BUID"]) : "");


        DataTable dtEMPData = Recruitment_BLL.get_EmployeeBySearchString(OrganizationID, BusinessUnitID, filterString);

        List<RadComboBoxItemData> result = new List<RadComboBoxItemData>(dtEMPData.Rows.Count);
        foreach (DataRow row in dtEMPData.Rows)
        {
            RadComboBoxItemData itemData = new RadComboBoxItemData();
            itemData.Text = row["EMPNAME"].ToString();
            itemData.Value = row["EMP_ID"].ToString();
            result.Add(itemData);
        }

        return result.ToArray();
        //}
        //catch (Exception ex)
        //{
        //    if (ex.Message == "The given key was not present in the dictionary.")
        //        BLL.ShowMessage(null, "Please Select Business Unit");
        //}
    }

    protected void rcmb_RaisedBy_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_RaisedBy.SelectedValue != "")
            {
                //To fetch Departments
                _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
                _obj_Rec_JobRequisition.JOBREQ_RAISEDBY = Convert.ToInt32(rcmb_RaisedBy.SelectedValue);
                _obj_Rec_JobRequisition.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //_obj_Rec_JobRequisition.OPERATION = operation.Select;
                DataTable dtDept = Recruitment_BLL.GetEmpDept(_obj_Rec_JobRequisition);
                rcmb_Department.Items.Clear();
                if (dtDept.Rows.Count > 0)
                {
                    rcmb_Department.DataSource = dtDept;
                    rcmb_Department.DataTextField = "DEPARTMENT_NAME";
                    rcmb_Department.DataValueField = "DEPARTMENT_ID";
                    rcmb_Department.DataBind();
                    rcmb_Department.Enabled = false;
                }
                else
                {
                    rcmb_Department.Text = string.Empty;
                    rcmb_Department.Items.Clear();
                    rcmb_Department.Enabled = false;
                }

                //To fetch Directorates
                _obj_Rec_JobRequisition.OPERATION = operation.EmployeesDirectoratewise;
                DataTable dtDirectorates = Recruitment_BLL.GetEmpDirectorate(_obj_Rec_JobRequisition);
                if (dtDirectorates.Rows.Count > 0)
                {
                    rcmb_Directorate.DataSource = dtDirectorates;
                    rcmb_Directorate.DataValueField = "DIRECTORATE_ID";
                    rcmb_Directorate.DataTextField = "DIRECTORATE_CODE";
                    rcmb_Directorate.DataBind();
                    rcmb_Directorate.Enabled = false;
                }
                else
                {
                    rcmb_Directorate.Text = string.Empty;
                    rcmb_Directorate.Items.Clear();
                    rcmb_Directorate.Enabled = false;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_jobrequisition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {

        //Session["Expected_date"] = rdtp_ExpectedDate.SelectedDate.Value;
        //String  dt1=  Session["Expected_date"].ToString ();
        //if(dt1 <= Session["Interview_Date"] 
        //{

        //}
        if (rlst_interviewer.Items.Count == 0)
        {
            BLL.ShowMessage(this, "Please Assign Atleast One Interviewer");
            return;
        }
        else if (rdtp_ExpectedDate.SelectedDate < DateTime.Now)   //((DateTime.Compare(rdtp_ExpectedDate.SelectedDate, DateTime.Now)) > 0)
        {
            BLL.ShowMessage(this, "Expected Closure Date Should not be less than or equal to Current Date");
            return;
        }
        else if (rcmb_Slab.SelectedIndex <= 0)
        {
            BLL.ShowMessage(this, "Please Select Slab");
            return;
        }
        else if (rcmb_RaisedBy.SelectedIndex <= 0)
        {
            BLL.ShowMessage(this, "Please Select Raised By");
            return;
        }
        try
        {
            _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
            //_obj_Rec_JobRequisition.JOBREQ_BUDGETESTIMATION = Convert.ToInt32(Convert.ToInt32(RNT_Openings.Text) * Convert.ToInt32(RNT_Appctc.Text));
            _obj_Rec_JobRequisition.JOBREQ_REQEXPIRY = Convert.ToDateTime(rdtp_ExpectedDate.SelectedDate.Value);

            //commneted by aravinda from here
            //if (rdtp_ActualClosedDate.SelectedDate < rdtp_ExpectedDate.SelectedDate)
            //{
            //    Recruitment_BLL.ShowMessage(this, "Job Requisition Actual Closed Date cannot be less than Expected Closer Date");
            //    return;
            //}

            /* //else
             //{
             //    _obj_Rec_JobRequisition.JOBREQ_ACTUALCLOSEDDATE = Convert.ToDateTime(rdtp_ActualClosedDate.SelectedDate);
             //}*/
            //commneted by aravinda till here


            //if (RNT_Experience.Text != string.Empty && rcmb_Qualification.SelectedItem.Value != string.Empty)
            //{
            //    if (chk_IsExperienceReq.Checked == false && chk_IsQualificationReQ.Checked == false)
            //    {
            //        Recruitment_BLL.ShowMessage(this, @"\n-Please check an Experience to which you want to give Value \n -Please check an Qualification to which you want to give Value");
            //        return;
            //    }
            //}
            //if (chk_IsExperienceReq.Checked == true && chk_IsQualificationReQ.Checked == true)
            //{
            //    if (RNT_Experience.Text == string.Empty && rcmb_Qualification.SelectedItem.Value == string.Empty)
            //    {
            //        Recruitment_BLL.ShowMessage(this, "\n-Please enter Experience value \n Please enter Percentage value ");
            //        return;
            //    }
            //}

            //if (rlb_SkillReq.CheckedItems.Count == 0)
            //{
            //    Recruitment_BLL.ShowMessage(this, "Please select Job Requisition skills from list");
            //    return;
            //}
            if (RNT_Openings.Value == 0)
            {
                Recruitment_BLL.ShowMessage(this, "Please Enter The Number of openings");
                return;
            }

            string str = string.Empty;

            foreach (RadListBoxItem item in rlst_interviewer.Items)
            {
                str += item.Value + ",";
            }
            if (str.Length > 0)
            {
                str = str.Remove(str.Length - 1, 1);
            }

            _obj_Rec_JobRequisition.JOBREQ_INTERVIEWER = str;
            //_obj_Rec_JobRequisition.JOBREQ_REQFOR = Convert.ToString(rcmb_req_for.SelectedItem.Text);
            //_obj_Rec_JobRequisition.JOBREQ_REQTOWORK = Convert.ToString(rcmb_reqto_work.SelectedItem.Text);
            _obj_Rec_JobRequisition.JOBREQ_GRADE = Convert.ToInt32(rcmb_Grade.SelectedItem.Value);
            //_obj_Rec_JobRequisition.JOBREQ_LOCATION = Convert.ToString(rtxt_location.Text.Replace("'", "''"));
            _obj_Rec_JobRequisition.JOBREQ_EMPTYPE = Convert.ToString(rcmb_Emptype.SelectedItem.Value);
            _obj_Rec_JobRequisition.JOBREQ_PERIOD_ID = Convert.ToInt32(rcbFinPeriod.SelectedValue);
            _obj_Rec_JobRequisition.JOBREQ_STATUS = Convert.ToString(rcmb_Status.SelectedItem.Text);
            _obj_Rec_JobRequisition.JOBREQ_RAISEDBY = Convert.ToInt32(rcmb_RaisedBy.SelectedValue);
            _obj_Rec_JobRequisition.JOBREQ_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
            //_obj_Rec_JobRequisition.JOBREQ_DEPARTMENT = Convert.ToInt32(rcmb_Department.SelectedItem.Value);
            _obj_Rec_JobRequisition.JOBREQ_DEPARTMENT = Convert.ToInt32((string.IsNullOrEmpty(rcmb_Department.SelectedValue) ? 0 : Convert.ToInt32(rcmb_Department.SelectedValue)));
            _obj_Rec_JobRequisition.JOBREQ_DESIGNATION = Convert.ToInt32(rcmb_Designation.SelectedItem.Value);
            _obj_Rec_JobRequisition.JOBREQ_REQCODE = Convert.ToString(rtxt_JRCode.Text);
            _obj_Rec_JobRequisition.JOBREQ_APPROVALSTATUS = 0;
            _obj_Rec_JobRequisition.JOBREQ_OPENINGS = Convert.ToInt32(RNT_Openings.Text);
            _obj_Rec_JobRequisition.JOBREQ_EXPYEARS = Math.Round(Convert.ToDecimal(RNT_Experience.Text), 2); //Convert.ToDouble(RNT_Experience.Text);
            _obj_Rec_JobRequisition.JOBREQ_AppCTC = Convert.ToInt32(rcmb_Slab.SelectedValue);
            //_obj_Rec_JobRequisition.JOBREQ_AppCTC = Convert.ToInt32(RNT_Appctc.Text);
            _obj_Rec_JobRequisition.JOBREQ_ISYEARSREQ = Convert.ToBoolean(chk_IsExperienceReq.Checked);
            //_obj_Rec_JobRequisition.JOBREQ_QUALIFICATION = Convert.ToInt32(rcmb_Qualification.SelectedItem.Value);
            _obj_Rec_JobRequisition.JOBREQ_PERCENTAGE = Convert.ToSingle(RNT_Percentage.Text);
            //_obj_Rec_JobRequisition.JOBREQ_ISQUALREQ = Convert.ToBoolean(chk_IsQualificationReQ.Checked);
            _obj_Rec_JobRequisition.JOBREQ_COMMENTS = Recruitment_BLL.ReplaceQuote(Convert.ToString(rtxt_Comments.Text));
            _obj_Rec_JobRequisition.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); ; // ### Need to Get the Session
            _obj_Rec_JobRequisition.CREATEDDATE = DateTime.Now;

            _obj_Rec_JobRequisition.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); ; // ### Need to Get the Session
            _obj_Rec_JobRequisition.LASTMDFDATE = DateTime.Now;
            _obj_Rec_JobRequisition.JOBREQ_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Rec_JobRequisition.JOBREQ_OPENINGS = Convert.ToInt32(RNT_Openings.Text);
            //_obj_Rec_JobRequisition.JOBREQ_RECRUITMENTFOR = Convert.ToString(rcmb_RecruitmentFor.SelectedValue);
            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_UPDATE":
                    //_obj_Rec_JobRequisition.MODE = 15;
                    //_obj_Rec_JobRequisition.JOBREQ_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                    //_obj_Rec_JobRequisition.JOBREQ_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
                    //DataTable DTJR1 = Recruitment_BLL.get_JobRequisition(_obj_Rec_JobRequisition);
                    //lbl_JRID.Text = Convert.ToString(DTJR1.Rows[0]["JOBREQ_ID"]);

                    //_obj_Rec_JobRequisition.MODE = 14;
                    //_obj_Rec_JobRequisition.JOBREQ_ID = Convert.ToInt32(lbl_JRID.Text);
                    //_obj_Rec_JobRequisition.JOBREQ_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                    //DataTable DT = Recruitment_BLL.get_JobRequisition(_obj_Rec_JobRequisition);
                    //if (Convert.ToDateTime(DT.Rows[0]["JOBREQ_REQEXPIRY"]) > Convert.ToDateTime(DT.Rows[0]["PHASE_INTERVIEWDATE"]))
                    //{
                    //    Recruitment_BLL.ShowMessage(this, "Job Requisition Expected Closure date must be less than or Equal to Interview Date");
                    //    return;
                    //}
                    _obj_Rec_JobRequisition.OPERATION = operation.Check;
                    _obj_Rec_JobRequisition.JOBREQ_ID = Convert.ToInt32(lbl_JRID.Text);
                    _obj_Rec_JobRequisition.JOBREQ_REQNAME = Recruitment_BLL.ReplaceQuote(Convert.ToString(rtxt_Desc.Text));
                    //if (Convert.ToString(Recruitment_BLL.get_JobRequisition(_obj_Rec_JobRequisition).Rows[0]["Count"]) != "1")
                    //{
                    //    Recruitment_BLL.ShowMessage(this, "Job Requisition with this Name Already Exists");
                    //    return;
                    //}

                    if (rdtp_ActualClosedDate.SelectedDate < rdtp_ExpectedDate.SelectedDate)
                    {
                        Recruitment_BLL.ShowMessage(this, "Job Requisition Actual Closed Date cannot be less than Expected Closer Date");
                        return;
                    }

                    else
                    {

                        if (rdtp_ActualClosedDate.SelectedDate != null)
                            _obj_Rec_JobRequisition.JOBREQ_ACTUALCLOSEDDATE = Convert.ToDateTime(rdtp_ActualClosedDate.SelectedDate);
                        else
                            _obj_Rec_JobRequisition.JOBREQ_ACTUALCLOSEDDATE = null;
                    }
                    _obj_Rec_JobRequisition.OPERATION = operation.Update;
                    if (Recruitment_BLL.set_JobRequisition(_obj_Rec_JobRequisition))
                    {

                        Recruitment_BLL.ShowMessage(this, "Information Updated Successfully");
                        //SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();
                        //_obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                        //_obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["EMP_ID"]).Trim();
                        //_obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        ////_obj_Rec_JobRequisition.JOBREQ_RAISEDBY = Convert.ToInt32(Session["EMP_ID"]);
                        //_obj_Rec_JobRequisition.MODE = 1;
                        //bool status1 = Recruitment_BLL.get_JobReqAprover(_obj_Rec_JobRequisition);

                        ////to test notification
                        //// bool status1 = Recruitment_BLL.get_JobReqAprover_Test();

                        //Recruitment_BLL.ShowMessage(this, "Notification Sent");


                        /*
                        //To send notification
                        //SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();
                        //_obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                        //_obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["EMP_ID"]).Trim();
                        //_obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Rec_JobRequisition.JOBREQ_RAISEDBY = Convert.ToInt32(rcmb_RaisedBy.SelectedValue);
                        _obj_Rec_JobRequisition.MODE = 2;
                        _obj_Rec_JobRequisition.JOBREQ_ID = Convert.ToInt32(lbl_JRID.Text);
                        bool status1 = Recruitment_BLL.get_JobReqAprover(_obj_Rec_JobRequisition);
                        if (status1)
                        {
                            Recruitment_BLL.ShowMessage(this, "Notification Sent");
                        }

                        */
                    }
                    else
                        Recruitment_BLL.ShowMessage(this, "Information Not Saved");
                    if (Convert.ToString(Request.QueryString["JOBREQ_ID"]) != null)
                    {
                        Response.Redirect("~/Approval/frm_JobRequisitionApproval.aspx?JOBREQ=" + "JOBREQ");

                    }
                    LoadGrid();
                    Rg_JobRequisition.DataBind();
                    Rm_JobRequisition_page.SelectedIndex = 0;

                    break;
                case "BTN_SAVE":
                    getJrNo();
                    //_obj_Rec_JobRequisition.MODE = 15;
                    //_obj_Rec_JobRequisition.JOBREQ_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                    //_obj_Rec_JobRequisition.JOBREQ_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
                    //DataTable DTJR = Recruitment_BLL.get_JobRequisition(_obj_Rec_JobRequisition);
                    //lbl_JRID.Text = Convert.ToString(DTJR.Rows[0]["JOBREQ_ID"]);

                    //_obj_Rec_JobRequisition.MODE = 14;
                    //_obj_Rec_JobRequisition.JOBREQ_ID = Convert.ToInt32(lbl_JRID.Text);
                    //_obj_Rec_JobRequisition.JOBREQ_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                    //DataTable DT_ = Recruitment_BLL.get_JobRequisition(_obj_Rec_JobRequisition);

                    //if (Convert.ToDateTime(DT_.Rows[0]["JOBREQ_REQEXPIRY"]) > Convert.ToDateTime(DT_.Rows[0]["PHASE_INTERVIEWDATE"]))
                    //{
                    //    Recruitment_BLL.ShowMessage(this, "Job Requisition Expected Closure date must be less than or Equal to Interview Date");
                    //    return;
                    //}

                    _obj_Rec_JobRequisition.JOBREQ_REQCODE = Convert.ToString(rtxt_JRCode.Text);
                    _obj_Rec_JobRequisition.JOBREQ_REQNAME = Recruitment_BLL.ReplaceQuote(Convert.ToString(rtxt_Desc.Text));
                    // _obj_Rec_JobRequisition.JOBREQ_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                    _obj_Rec_JobRequisition.MODE = 20;
                    DataTable dt_ = Recruitment_BLL.get_JobRequisition(_obj_Rec_JobRequisition);//.Rows[0]["COUNT"]);
                    if (Convert.ToString(Recruitment_BLL.get_JobRequisition(_obj_Rec_JobRequisition).Rows[0]["COUNT"]) != "0")
                    {
                        Recruitment_BLL.ShowMessage(this, "Job Requisition with this Name Already Exists");
                        return;
                    }
                    if (rdtp_ExpectedDate.SelectedDate < DateTime.Now.Date)
                    {
                        Recruitment_BLL.ShowMessage(this, "Job Requisition Expected Closer Date cannot be less than Current Date");
                        return;
                    }
                    //_obj_Rec_JobRequisition.JOBREQ_REQEXPIRY = Convert.ToDateTime(rdtp_ExpectedDate.SelectedDate);
                    //_obj_Rec_JobRequisition.CREATEDDATE = DateTime.Now;
                    _obj_Rec_JobRequisition.OPERATION = operation.Insert;

                    ////Parameters for notification
                    //_obj_Rec_JobRequisition.LOGIN_ID = Convert.ToInt32(Session["EMP_ID"]);
                    if (Recruitment_BLL.set_JobRequisition(_obj_Rec_JobRequisition))
                    {

                        Recruitment_BLL.ShowMessage(this, "Information Saved Successfully");


                        // To send notification
                        //SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();
                        //_obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                        //_obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["EMP_ID"]).Trim();
                        //_obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        ////_obj_Rec_JobRequisition.JOBREQ_RAISEDBY = Convert.ToInt32(Session["EMP_ID"]);
                        //_obj_Rec_JobRequisition.MODE = 1;
                        //bool status1 = Recruitment_BLL.get_JobReqAprover(_obj_Rec_JobRequisition);

                        //to test notification
                        // bool status1 = Recruitment_BLL.get_JobReqAprover_Test();

                        //Recruitment_BLL.ShowMessage(this, "Notification Sent");
                        //getJrNo();  


                    }

                    else
                        Recruitment_BLL.ShowMessage(this, "Information Not Saved");
                    LoadGrid();
                    Rg_JobRequisition.DataBind();
                    Rm_JobRequisition_page.SelectedIndex = 0;
                    break;
                default:
                    break;
            }
            //if (track == "add")
            //{
            //    _obj_Rec_JobReqSkills = new SMHR_JOBREQSKILLS();
            //    pnl_multipage2.Visible = true;
            //    RM_Skills.SelectedIndex = 0;
            //    DataTable DT1 = Recruitment_BLL.get_JobRequisition_jrid(new RECRUITMENT_JOBREQUISITION());
            //    lbl_id.Text = Convert.ToString(DT1.Rows[0]["jobreq_id"]);
            //    LoadGridskills(Convert .ToInt32 (lbl_id .Text));
            //    return;
            //}
            //Rm_JobRequisition_page.SelectedIndex = 1;      
            //LoadGrid();
            //Rg_JobRequisition.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_jobrequisition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            //LoadGrades();
            LoadPeriod();
            rcmb_BU.Enabled = false;
            rtxt_JRCode.Enabled = false;
            rcmb_Status.Enabled = true;
            rtxt_Desc.Enabled = false;
            //rdtp_ActualClosedDate.Visible = true;
            //lbl_ActualDate.Visible = true;india
            tr_ActDate.Visible = true;
            // rcmb_BU.Enabled = false;
            rcmb_RaisedBy.Enabled = false;
            _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
            if (Request.QueryString["JOBREQ_ID"] != null)
                _obj_Rec_JobRequisition.JOBREQ_ID = Convert.ToInt32(Convert.ToString(Request.QueryString["JOBREQ_ID"]));
            else
                _obj_Rec_JobRequisition.JOBREQ_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            _obj_Rec_JobRequisition.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Rec_JobRequisition.OPERATION = operation.Select;
            DataTable dt = Recruitment_BLL.get_JobRequisition(_obj_Rec_JobRequisition);

            if (dt.Rows.Count > 0)
            {
                string Reject_status = Convert.ToString(dt.Rows[0]["JOBREQ_APPROVALSTATUS"]);
                if (Reject_status == "REJECTED")
                //if (Reject_status == 3)
                {
                    EnableDisableControls(false);
                    btn_Update.Enabled = false;
                }
                else if (Reject_status == "APPROVED1")
                {
                    EnableDisableControls(false);
                    btn_Update.Enabled = false;
                }
                else if (Reject_status == "APPROVED2")
                {
                    EnableDisableControls(false);
                    btn_Update.Enabled = false;
                }
                else if (Reject_status == "APPROVED3")
                {
                    EnableDisableControls(false);
                    btn_Update.Enabled = false;
                    //rcmb_BU.Enabled = true;
                }
                else
                {
                    EnableDisableControls(true);
                    btn_Update.Enabled = true;
                }
                lbl_JRID.Text = Convert.ToString(dt.Rows[0]["JOBREQ_ID"]);
                rtxt_JRCode.Text = Convert.ToString(dt.Rows[0]["JOBREQ_REQCODE"]);
                rtxt_Desc.Text = Convert.ToString(dt.Rows[0]["JOBREQ_REQNAME"]);
                rdtp_ExpectedDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["JOBREQ_REQEXPIRY"]);

                if (Convert.ToString(dt.Rows[0]["JOBREQ_PERIOD_ID"]) != string.Empty)
                {
                    rcbFinPeriod.SelectedIndex = rcbFinPeriod.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["JOBREQ_PERIOD_ID"]));
                    rcbFinPeriod_SelectedIndexChanged(null, null);
                }
                if ((dt.Rows[0]["JOBREQ_ACTUALCLOSEDDATE"]) != null && (dt.Rows[0]["JOBREQ_ACTUALCLOSEDDATE"]) != System.DBNull.Value)
                {
                    rdtp_ActualClosedDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["JOBREQ_ACTUALCLOSEDDATE"]);
                }
                //rcmb_Status.SelectedItem.Text = Convert.ToString((Convert.ToString(dt.Rows[0]["JOBREQ_STATUS"])));

                rcmb_Status.SelectedIndex = rcmb_Status.FindItemIndexByText(Convert.ToString((Convert.ToString(dt.Rows[0]["JOBREQ_STATUS"]))));
                rcmb_Status.Enabled = false;
                LoadBusinessUnit();
                rcmb_BU.SelectedIndex = rcmb_BU.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["JOBREQ_BUSINESSUNIT_ID"]));
                LoadJobs(); //To load jobs on BU
                rcmb_Job.SelectedIndex = rcmb_Job.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["JOBS_ID"]));
                LoadPositions();    //To load positions based on Organisation_ID
                //loadQualSkills();     //To load Qualifications, Grades/Scales, Skills
                LoadEmployeeType();    //To load employee types
                LoadAssignedInterviewers(dt); //To load assigned Interviewers

                //financial period loading & grades loading event

                int bu_id = Convert.ToInt32(dt.Rows[0]["JOBREQ_BUSINESSUNIT_ID"]);
                //  Load_raisedby(bu_id);
                LoadEmployee();
                rcmb_RaisedBy.SelectedIndex = rcmb_RaisedBy.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["JOBREQ_RAISEDBY"]));
                rcmb_RaisedBy_SelectedIndexChanged(null, null);
                //LoadDepartment();
                rcmb_Department.SelectedIndex = rcmb_Department.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["JOBREQ_DEPARTMENT"]));
                //LoadCombos();
                //LoadDropDowns();
                rcmb_Designation.SelectedIndex = rcmb_Designation.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["JOBREQ_DESIGNATION"]));
                if (rcmb_Designation.SelectedValue != "")
                {
                    rcmb_Designation_SelectedIndexChanged(null, null);  //To fill grades/scales and slabs based on selected position
                }
                RNT_Openings.Text = Convert.ToString(dt.Rows[0]["JOBREQ_POSITIONS"]);
                RNT_Experience.Text = Convert.ToString(dt.Rows[0]["JOBREQ_EXPYEARS"]);
                //lblQualifications.Text = Convert.ToString(dt.Rows[0]["JOBREQ_QUALIFICATION"]);
                //rcmb_Qualification.SelectedIndex = rcmb_Qualification.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["JOBREQ_QUALIFICATION"]));
                //chk_IsQualificationReQ.Checked = Convert.ToBoolean(dt.Rows[0]["JOBREQ_ISQUALREQ"]);
                chk_IsExperienceReq.Checked = Convert.ToBoolean(dt.Rows[0]["JOBREQ_ISYEARSREQ"]);
                RNT_Percentage.Text = Convert.ToString(dt.Rows[0]["JOBREQ_PERCENTAGE"]);
                //LoadCurrSymbol();
                //RNT_Appctc.Text = Convert.ToString(dt.Rows[0]["JOBREQ_APPCTC"]);
                rtxt_Comments.Text = Convert.ToString(dt.Rows[0]["JOBREQ_COMMENTS"]);

                //rcmb_req_for.SelectedIndex = rcmb_req_for.FindItemIndexByText(Convert.ToString(dt.Rows[0]["JOBREQ_REQFOR"]));
                //rcmb_reqto_work.SelectedIndex=rcmb_reqto_work.FindItemIndexByText(Convert.ToString(dt.Rows[0]["JOBREQ_REQTOWORK"]));
                rcmb_Grade.SelectedIndex = rcmb_Grade.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["JOBREQ_GRADE"]));
                rcmb_Grade_SelectedIndexChanged(null, null);
                rcmb_Slab.SelectedIndex = rcmb_Slab.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["JOBREQ_APPCTC"]));

                //rcmb_Emptype.SelectedIndex = rcmb_Emptype.FindItemIndexByText(Convert.ToString(dt.Rows[0]["JOBREQ_EMPTYPE"]));
                rcmb_Emptype.SelectedIndex = rcmb_Emptype.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["JOBREQ_EMPTYPE"]));
                //rtxt_location.Text = Convert.ToString(dt.Rows[0]["JOBREQ_LOCATION"]);
                //rcmb_RecruitmentFor.SelectedIndex = rcmb_RecruitmentFor.FindItemIndexByText(Convert.ToString(dt.Rows[0]["JOBREQ_RECRUITMENTFOR"]));

                SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
                _obj_smhr_emp_payitems.OPERATION = operation.Empty;
                _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
                _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable DT_Details = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
                if (dt_Details.Rows.Count > 0)
                {
                    rcmb_interviewer.DataSource = DT_Details;
                    rcmb_interviewer.DataTextField = "EMPNAME";
                    rcmb_interviewer.DataValueField = "EMP_ID";
                    rcmb_interviewer.DataBind();
                    rcmb_interviewer.Items.Insert(0, new RadComboBoxItem("Select"));

                    rlst_interviewer.Items.Clear();
                    string str = Convert.ToString(dt.Rows[0]["JOBREQ_INTERVIEWER"]);
                    foreach (string item in str.Split(new char[] { ',' }))
                    {
                        if (item != "")
                            rlst_interviewer.Items.Add(new Telerik.Web.UI.RadListBoxItem(rcmb_interviewer.FindItemByValue(item).Text, rcmb_interviewer.FindItemByValue(item).Value));
                    }
                }

                ////To select skills 
                //_obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
                //_obj_Rec_JobRequisition.MODE = 5;
                //_obj_Rec_JobRequisition.JOBREQ_ID = Convert.ToInt32(lbl_JRID.Text);
                //DataTable dt_skillid = Recruitment_BLL.get_JobRequisition(_obj_Rec_JobRequisition);
                //if (dt_skillid.Rows.Count > 0)
                //{
                //    for (int a = 0; a <= rlb_SkillReq.Items.Count - 1; a++)
                //    {
                //        for (int b = 0; b <= dt_skillid.Rows.Count - 1; b++)
                //        {
                //            if (dt_skillid.Rows[b]["SKILL_ID"] != System.DBNull.Value)
                //            {
                //                if (rlb_SkillReq.Items[a].Value == Convert.ToString(dt_skillid.Rows[b]["SKILL_ID"]))
                //                {
                //                    rlb_SkillReq.Items[a].Checked = true; ;// = Convert.ToBoolean(dt_skillid.Rows[b]["SKILL_ID"]);
                //                }
                //            }
                //        }
                //    }
                //}
                //rcmb_BU.Enabled = false;
                //lblSkills.Enabled = false;
                //lblQualifications.Enabled = false;
                if (Convert.ToString(dt.Rows[0]["JOBREQ_APPROVALSTATUS"]) == "PENDING")
                    btn_Update.Visible = true;
                else if (Convert.ToString(dt.Rows[0]["JOBREQ_APPROVALSTATUS"]) == "REJECTED")
                {
                    BLL.ShowMessage(this, "Job Requisition is Rejected.You can not edit.");
                    btn_Update.Visible = false;
                }
                else
                {
                    BLL.ShowMessage(this, "Job Requisition is Approved.You can not edit.");
                    btn_Update.Visible = false;
                }

                btn_Save.Visible = false;
                Rm_JobRequisition_page.SelectedIndex = 1;

                //track = "edit";
                //pnl_multipage2.Visible = true;
                //RM_Skills .SelectedIndex =0;
                //lbl_id.Text = Convert.ToString(lbl_JRID.Text);
                //int param_jrid = Convert.ToInt32(lbl_JRID.Text);
                //LoadGridskills(param_jrid);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_jobrequisition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    private void LoadAssignedInterviewers(DataTable dt)
    {
        try
        {
            if (dt.Rows.Count > 0)
            {
                SMHR_JOBREQUISITION objGetEmp = new SMHR_JOBREQUISITION();
                objGetEmp.JOBREQ_ID = Convert.ToInt32(dt.Rows[0]["JOBREQ_ID"]);
                DataTable dtEmps = Recruitment_BLL.GetEmployees(objGetEmp);
                rlst_interviewer.Items.Clear();
                if (dtEmps.Rows.Count > 0)
                {
                    rlst_interviewer.DataSource = dtEmps;
                    rlst_interviewer.DataTextField = "EMP_NAME";
                    rlst_interviewer.DataValueField = "EMP_ID";
                    rlst_interviewer.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_jobrequisition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void clearControls()
    {
        try
        {
            rtxt_JRCode.Text = string.Empty;
            rtxt_Desc.Text = string.Empty;
            rdtp_ExpectedDate.Clear();
            rcmb_BU.ClearSelection();
            rcmb_Department.ClearSelection();
            rcmb_Designation.ClearSelection();
            rcmb_Status.ClearSelection();
            RNT_Openings.Text = string.Empty;
            RNT_Experience.Text = string.Empty;
            chk_IsExperienceReq.Checked = false;
            //rcmb_Qualification.Items.Clear();
            RNT_Percentage.Text = string.Empty;
            //RNT_Appctc.Text = string.Empty;
            //chk_IsQualificationReQ.Checked = false;
            //pnl_multipage2.Visible = false;
            rtxt_Comments.Text = string.Empty;
            rdtp_ActualClosedDate.Clear();
            //rlb_SkillReq.ClearChecked();

            //rcmb_req_for.ClearSelection();
            //rcmb_reqto_work.ClearSelection(); ;
            rcmb_Grade.ClearSelection();
            rcmb_interviewer.ClearSelection();
            //rcmb_dept_interviewer.ClearSelection();
            rcmb_Emptype.ClearSelection();
            rlst_interviewer.Items.Clear();
            //rtxt_location.Text = string.Empty;
            //rcmb_RecruitmentFor.SelectedIndex = 0;

            rcmb_BU.Items.Clear();
            rcmb_RaisedBy.Items.Clear();
            rcmb_RaisedBy.Text = string.Empty;
            rcmb_Designation.Items.Clear();
            rcmb_Department.Text = string.Empty;
            rcmb_Department.Items.Clear();
            rcmb_Grade.Items.Clear();
            rcmb_Grade.Text = string.Empty;
            rcmb_Slab.Items.Clear();
            rcmb_Slab.Text = string.Empty;
            rcmb_interviewer.Items.Clear();
            rcmb_interviewer.Text = string.Empty;
            lblSkills.Text = string.Empty;
            lblQualifications.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_jobrequisition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void ClearControl1()
    {
        try
        {
            rcmb_RaisedBy.Items.Clear();
            rcmb_RaisedBy.Text = string.Empty;
            rcmb_Directorate.Items.Clear();
            rcmb_Department.Items.Clear();
            rcmb_Department.Text = string.Empty;
            rdtp_ExpectedDate.Clear();
            rcmb_Grade.Items.Clear();
            rcmb_Designation.Items.Clear();
            rcmb_Designation.Text = string.Empty;
            rcmb_interviewer.Items.Clear();
            rcmb_interviewer.Text = string.Empty;
            rtxt_Desc.Text = string.Empty;
            rlst_interviewer.Items.Clear();
            //rcmb_Status.Items.Clear();
            //rcmb_Status.Text = string.Empty;
            rcmb_Grade.Text = string.Empty;
            RNT_Openings.Text = string.Empty;
            lblSkills.Text = string.Empty;
            rcmb_Slab.Items.Clear();
            rcmb_Slab.Text = string.Empty;
            RNT_Percentage.Text = string.Empty;
            RNT_Experience.Text = string.Empty;
            rcmb_Emptype.Items.Clear();
            rcmb_Emptype.Text = string.Empty;
            //rcmb_Emptype.Text = string.Empty;
            rtxt_Comments.Text = string.Empty;
            lblQualifications.Text = string.Empty;
            rcmb_Directorate.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_jobrequisition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["JOBREQ_ID"] != null)
            {
                EnableDisableControls(true);
                Response.Redirect("~/Approval/frm_JobRequisitionApproval.aspx", false);
            }
            else
            {
                Rm_JobRequisition_page.SelectedIndex = 0;
                EnableDisableControls(true);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_jobrequisition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    //protected void rlst_interviewer_Deleted(object sender, RadListBoxEventArgs e)
    //{
    //    rcmb_dept_interviewer_SelectedIndexChanged(null, null);
    //}
    protected void btn_AddInterviewer_Click(object sender, EventArgs e)
    {
        try
        {
            bool flag = false;
            if (rcmb_interviewer.SelectedValue != "")
            {
                if (rlst_interviewer.Items.Count > 0)
                {
                    foreach (RadListBoxItem item in rlst_interviewer.Items)
                    {
                        if (item.Value == rcmb_interviewer.SelectedValue)
                        {
                            flag = true;
                        }
                    }

                }
                if (!flag)   //To add Employees to listbox
                {
                    rlst_interviewer.Items.Add(new Telerik.Web.UI.RadListBoxItem(rcmb_interviewer.Text, rcmb_interviewer.SelectedValue));
                    rcmb_interviewer.Text = "Select/Enter Name";
                    //rcmb_dept_interviewer_SelectedIndexChanged(null, null);
                }
                else
                    BLL.ShowMessage(this, "Interviewer already exists");
            }
            else
            {
                BLL.ShowMessage(this, "Please select an Interviewer");
            }

            //if (rcmb_interviewer.SelectedItem.Value != "0")
            //{
            //    rlst_interviewer.Items.Add(new Telerik.Web.UI.RadListBoxItem(rcmb_interviewer.SelectedItem.Text, rcmb_interviewer.SelectedItem.Value));
            //    rcmb_dept_interviewer_SelectedIndexChanged(null, null);
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_jobrequisition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_Designation_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            //rcmb_Grade.Items.Clear();
            //rcmb_Grade.Text = string.Empty;
            //rcmb_Slab.Items.Clear();
            //rcmb_Slab.Text = string.Empty;
            lblSkills.Text = string.Empty;
            lblQualifications.Text = string.Empty;
            RNT_Openings.Text = string.Empty;
            if (rcbFinPeriod.SelectedIndex <= 0)
            {
                BLL.ShowMessage(this,"Please Select Financial Period");
                rcbFinPeriod.Focus();
                rcmb_Designation.SelectedIndex = -1;
                return;
            }
            if (rcmb_Designation.SelectedIndex > 0)
            {
                //To check for vacancy
                SMHR_POSITIONS _obj_smhr_positions = new SMHR_POSITIONS();
                _obj_smhr_positions.OPERATION = operation.GETVACANCY;
                _obj_smhr_positions.POSITIONS_ID = Convert.ToInt32(rcmb_Designation.SelectedValue);
                _obj_smhr_positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_smhr_positions.POSITIN_PERIOD_ID = Convert.ToInt32(rcbFinPeriod.SelectedValue);

                DataTable dtVacancy = BLL.get_Positions(_obj_smhr_positions);
                if (Convert.ToInt32(dtVacancy.Rows[0][0]) == 0)
                {
                    rcmb_Designation.ClearSelection();
                    //ddl_Grade.Items.Clear();
                    BLL.ShowMessage(this, "Establishment not defined for this position");
                }
                else if (Convert.ToInt32(dtVacancy.Rows[0][0]) == 1)
                {
                    rcmb_Designation.ClearSelection();
                    //ddl_Grade.Items.Clear();
                    BLL.ShowMessage(this, "Establishment not finalised for this position");
                }
                else if (Convert.ToInt32(dtVacancy.Rows[0][0]) == 3)
                {
                    rcmb_Designation.ClearSelection();
                    //ddl_Grade.Items.Clear();
                    BLL.ShowMessage(this, "There is no vacancy for this position");
                }
                else if (Convert.ToInt32(dtVacancy.Rows[0][0]) == 2)
                {
                    //To fetch no. of vacancies for the selected PositionID
                    SMHR_POSITIONS objEmpPositions = new SMHR_POSITIONS();
                    objEmpPositions.POSITIONS_ID = Convert.ToInt32(rcmb_Designation.SelectedValue);
                    objEmpPositions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    objEmpPositions.POSITIN_PERIOD_ID = Convert.ToInt32(rcbFinPeriod.SelectedValue);
                    objEmpPositions.OPERATION = operation.Select;
                    int VacancyCount = Recruitment_BLL.GetEmpVacancyCount(objEmpPositions);
                    if (VacancyCount > 0)
                    {
                        RNT_Openings.Text = VacancyCount.ToString();
                    }
                    //To fetch Grades/Scales based on Position
                    /*rcmb_Grade.Items.Clear();
                    rcmb_Grade.Text = string.Empty;
                    rcmb_Slab.Items.Clear();
                    rcmb_Slab.Text = string.Empty;
                    SMHR_POSITIONS _objGradesByPos = new SMHR_POSITIONS();
                    _objGradesByPos.OPERATION = operation.POSITIONSGRADE;
                    _objGradesByPos.POSITIONS_ID = Convert.ToInt32(rcmb_Designation.SelectedValue);
                    _objGradesByPos.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtGrades = BLL.get_Positions(_objGradesByPos);
                    if (dtGrades.Rows.Count > 0)
                    {
                        rcmb_Grade.DataSource = dtGrades;
                        rcmb_Grade.DataTextField = "CODERANK";
                        rcmb_Grade.DataValueField = "EMPLOYEEGRADE_ID";
                        rcmb_Grade.DataBind();
                        rcmb_Grade.Enabled = false;

                        rcmb_Slab.DataValueField = "EMPLOYEEGRADE_SLAB_ID";
                        rcmb_Slab.DataTextField = "EMPLOYEEGRADE_SLAB_AMOUNT";
                        rcmb_Slab.DataSource = LoadSalarySlabs();
                        rcmb_Slab.DataBind();
                        rcmb_Slab.Items.Insert(0, new RadComboBoxItem { Text = "Select", Value = "0" });
                    }*/

                    //To fetch Qualifications and Skills using PositionID
                    SMHR_POSITIONS _objSkillQualPos = new SMHR_POSITIONS();
                    _objSkillQualPos.POSITIONS_ID = Convert.ToInt32(rcmb_Designation.SelectedValue);
                    _objSkillQualPos.OPERATION = operation.Empty1;
                    DataTable dtSkillQual = BLL.get_Positions(_objSkillQualPos);

                    if (dtSkillQual.Rows.Count > 0)
                    {
                        lblSkills.Text = Convert.ToString(dtSkillQual.Rows[0]["POSITION_SKILLS"]);
                        lblQualifications.Text = Convert.ToString(dtSkillQual.Rows[0]["POSITIONS_QUALIFICATION"]);
                    }



                    //SMHR_POSITIONS _obj_Smhr_Positions = new SMHR_POSITIONS();
                    //_obj_Smhr_Positions.POSITIONS_ID = Convert.ToInt32(rcmb_Designation.SelectedValue);
                    //_obj_Smhr_Positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

                    //DataTable dt = BLL.get_Positions(_obj_Smhr_Positions);


                    ////rcmb_Grade.SelectedIndex = rcmb_Grade.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["POSITIONS_GRADE_ID"]));
                    //string strCsvSkills = Convert.ToString(dt.Rows[0]["JOBS_SKILLS_ID"]);
                    //getCheckedItems(rlb_SkillReq, strCsvSkills);   //To select Skills

                    //string strCsvQualifications = dt.Rows[0]["POSITIONS_QUALIFICATION"].ToString();
                    //getCheckedItems(rlb_Qualification, strCsvQualifications);   //To select Qualifications
                }

                //else
                //{
                //    BLL.ShowMessage(this, "No Establishments are defined for this Position");
                //    rcmb_Designation.ClearSelection();
                //    return;
                //}
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_jobrequisition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private DataTable LoadSalarySlabs()
    {
        DataSet ds = new DataSet();
        try
        {
            SMHR_EMPLOYEEGRADE _obj_Smhr_EmployeeGrade = new SMHR_EMPLOYEEGRADE();
            _obj_Smhr_EmployeeGrade.EMPLOYEEGRADE_ID = rcmb_Grade.SelectedValue != string.Empty ? Convert.ToInt32(rcmb_Grade.SelectedValue) : 0;
            _obj_Smhr_EmployeeGrade.OPERATION = operation.EmployeeSlabs;
            _obj_Smhr_EmployeeGrade.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            ds = BLL.get_EmployeeGrade(_obj_Smhr_EmployeeGrade);

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_jobrequisition", ex.StackTrace, DateTime.Now);
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
            _obj_Smhr_EmployeeGrade.EMPLOYEEGRADE_SLAB_EMPLOYEEGRADE_ID = rcmb_Grade.SelectedValue != string.Empty ? Convert.ToInt32(rcmb_Grade.SelectedValue) : 0;
            _obj_Smhr_EmployeeGrade.OPERATION = operation.EmployeeSlabs;
            _obj_Smhr_EmployeeGrade.EMPLOYEEGRADE_SLAB_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_EmployeeGrade.EMPLOYEEGRADE_SLAB_PERIOD_ID = Convert.ToInt32(rcbFinPeriod.SelectedValue);

            dt = BLL.get_EmployeeGrades(_obj_Smhr_EmployeeGrade);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_jobrequisition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

        }
        return dt;
    }

    private void getCheckedItems(RadListBox listBox, string CsvIDs)
    {
        try
        {
            //To check the list of items in listbox based on CsvIDs
            string strVal = CsvIDs;
            string[] Ar = strVal.Split(new Char[] { ',' });
            for (int i = 0; i < Ar.Length; i++)
            {
                string strTemp = Ar[i].Trim();

                if (listBox.FindItemByValue(strTemp) != null)
                    listBox.FindItemByValue(strTemp).Checked = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_jobrequisition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    //protected void loadskills()
    //{
    //    _obj_Smhr_Masters.MASTER_TYPE = "SKILL";
    //    _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
    //    dt_Details = Recruitment_BLL.get_MasterRecords(_obj_Smhr_Masters);
    //    RCMB_Skills.DataSource = dt_Details;
    //    RCMB_Skills.DataTextField = "HR_MASTER_CODE";
    //    RCMB_Skills.DataValueField = "HR_MASTER_ID";
    //    RCMB_Skills.DataBind();
    //    RCMB_Skills.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
    //}

    //public void Load_raisedby(int buid)
    //{
    //    rcmb_RaisedBy.Items.Clear();
    //    _obj_smhr_employee = new SMHR_EMPLOYEE();
    //    _obj_smhr_employee.OPERATION = operation.Validate;
    //    _obj_smhr_employee.EMP_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
    //    _obj_smhr_employee.EMP_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
    //    _obj_smhr_employee.EMP_ID = Convert.ToInt32(Session["EMP_ID"].ToString());
    //    DataTable dtemp = Recruitment_BLL.get_Employee(_obj_smhr_employee);
    //    rcmb_RaisedBy.DataSource = dtemp;
    //    if (dtemp.Rows.Count != 0)
    //    {
    //        rcmb_RaisedBy.DataTextField = "EMPNAME";
    //        rcmb_RaisedBy.DataValueField = "EMP_ID";
    //        rcmb_RaisedBy.DataBind();       
    //    }
    //    else
    //    {
    //        rcmb_RaisedBy.Text = "no records";
    //    }
    //}

    //public void LoadGridskills(int int_jrid)
    //{
    //    SMHR_JOBREQSKILLS _obj_Rec_JobReqSkills = new SMHR_JOBREQSKILLS();
    //    _obj_Rec_JobReqSkills.JR_ID = Convert.ToInt32(int_jrid);
    //    _obj_Rec_JobReqSkills.MODE = 1;
    //    DataTable DT = Recruitment_BLL.get_SKILLSJOBREQ(_obj_Rec_JobReqSkills);
    //    RG_Skills.DataSource = DT;
    //    RG_Skills.DataBind();
    //}

    //protected void lnk_Add_CommandSkills(object sender, CommandEventArgs e)
    //{    
    //    clearcontrolskills();
    //    //loadskills();
    //    //RM_Skills.SelectedIndex = 1;
    //}

    //protected void btn_Save_Click1(object sender, EventArgs e)
    //{
    //    SMHR_JOBREQSKILLS _obj_Rec_JobReqSkills = new SMHR_JOBREQSKILLS();
    //    _obj_Rec_JobReqSkills.SKILL_ID = Convert.ToInt32(RCMB_Skills.SelectedItem.Value);
    //    _obj_Rec_JobReqSkills.JR_ID = Convert.ToInt32(lbl_id.Text);
    //    int int_param = Convert.ToInt32(lbl_id.Text);
    //    _obj_Rec_JobReqSkills.CREATEDBY = 1;
    //    _obj_Rec_JobReqSkills.CREATEDDATE = DateTime.Now;
    //    _obj_Rec_JobReqSkills.JOBREQ_ISSKILLREQ = Convert.ToBoolean(chk_IsSkillReq.Checked);
    //    _obj_Rec_JobReqSkills.MODE = 6;
    //   if (Convert.ToString(Recruitment_BLL.get_SKILLSJOBREQ(_obj_Rec_JobReqSkills).Rows[0]["Count"]) != "0")
    //    {
    //        Recruitment_BLL.ShowMessage(this, "Skill with this name Already Exists");
    //        return;
    //    }
    //    _obj_Rec_JobReqSkills.OPERATION = operation.Insert;
    //    if (Recruitment_BLL.set_SKILLSJOBREQ(_obj_Rec_JobReqSkills))
    //    {
    //        Recruitment_BLL.ShowMessage(this, "Skills Saved Successfully");
    //    }
    //    else
    //    {
    //        Recruitment_BLL.ShowMessage(this, "Skills Not Saved");
    //    }
    //    RM_Skills.SelectedIndex = 0;
    //    LoadGridskills(int_param);
    //    RG_Skills.DataBind();      
    //}

    //protected void clearcontrolskills()
    //{
    //    RCMB_Skills.ClearSelection();
    //    chk_IsSkillReq.Checked = false;       
    //}

    //protected void lnk_Delete_Command(object sender, CommandEventArgs e)
    //{
    //    SMHR_JOBREQSKILLS _obj_deleteskills = new SMHR_JOBREQSKILLS();
    //    _obj_deleteskills.JR_SKILLS_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));    
    //    int int_param = Convert.ToInt32(lbl_JRID.Text);
    //    _obj_deleteskills.OPERATION = operation.Delete;
    //    bool status = Recruitment_BLL.set_DELETESKILLS(_obj_deleteskills);
    //    if (status == true)
    //    {
    //        Recruitment_BLL.ShowMessage(this, "Skill Deleted Successfully");
    //    }
    //    else
    //    {
    //        Recruitment_BLL.ShowMessage(this, "Skill not Deleted");
    //    }
    //    RM_Skills.SelectedIndex = 0;
    //    LoadGridskills(int_param);
    //    RG_Skills.DataBind();
    //}

    protected void RNT_Openings_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (rcmb_Designation.Text == string.Empty || rcmb_Designation.Text=="Select")
            {
                BLL.ShowMessage(this, "Please Select Position before assigning Target Openings ");
                RNT_Openings.Text = string.Empty;
                rcmb_Designation.Focus();
                return;
            }
            if (rcmb_Designation.SelectedIndex > 0 && rcbFinPeriod.SelectedIndex>0)
            {
                //To fetch no. of vacancies for the selected PositionID
                SMHR_POSITIONS objEmpPositions = new SMHR_POSITIONS();
                objEmpPositions.POSITIONS_ID = Convert.ToInt32(rcmb_Designation.SelectedValue);
                objEmpPositions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                objEmpPositions.POSITIN_PERIOD_ID = Convert.ToInt32(rcbFinPeriod.SelectedValue);
                objEmpPositions.OPERATION = operation.Select;
                int VacancyCount = Recruitment_BLL.GetEmpVacancyCount(objEmpPositions);
                if (VacancyCount > 0)
                {
                    if (RNT_Openings.Text != String.Empty)
                    {
                        if (Convert.ToInt32(RNT_Openings.Text) > VacancyCount)
                        {
                            BLL.ShowMessage(this, "Maximum openings exceeded. Vacancies available: " + VacancyCount + "");
                            //RNT_Openings.Text = VacancyCount.ToString();
                            RNT_Openings.Text = string.Empty;
                        }
                        //else
                        //{
                        //    BLL.ShowMessage(this, "No Establishments are defined for this Position while assigning Target Openings");
                        //    RNT_Openings.Text = string.Empty;
                        //    RNT_Openings.Focus();
                        //    return;
                        //}
                    }
                }
                //else
                //{
                //    BLL.ShowMessage(this, "No Establishments are defined for this Position while assigning Target Openings");
                //    RNT_Openings.Text = string.Empty;
                //    RNT_Openings.Focus();
                //    return;
                //}
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_jobrequisition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void EnableDisableControls(bool flag)
    {
        try
        {
            rcmb_BU.Enabled = flag;
            rcmb_RaisedBy.Enabled = flag;
            rcmb_Department.Enabled = flag;
            rtxt_JRCode.Enabled = flag;
            rtxt_Desc.Enabled = flag;
            rdtp_ExpectedDate.Enabled = flag;
            rcmb_interviewer.Enabled = flag;
            btn_AddInterviewer.Enabled = flag;
            rlst_interviewer.Enabled = flag;
            rcmb_Status.Enabled = flag;
            rcmb_Designation.Enabled = flag;
            RNT_Openings.Enabled = flag;
            lblSkills.Enabled = flag;
            lblQualifications.Enabled = flag;
            RNT_Percentage.Enabled = flag;
            RNT_Experience.Enabled = flag;
            chk_IsExperienceReq.Enabled = flag;
            rcmb_Grade.Enabled = flag;
            rcmb_Slab.Enabled = flag;
            rcmb_Emptype.Enabled = flag;
            rtxt_Comments.Enabled = flag;
            rdtp_ActualClosedDate.Enabled = flag;
            btn_Update.Enabled = flag;
            rcmb_Job.Enabled = flag;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_jobrequisition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_Job_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            LoadPositions();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_jobrequisition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_Grade_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            SMHR_EMPLOYEEGRADE_SLAB _obj_SMHR_EMPLOYEEGRADE_SLAB = new SMHR_EMPLOYEEGRADE_SLAB();
            //rcmb_Slab.Items.Clear();

            if (rcmb_Grade.SelectedIndex > 0 && rcbFinPeriod.SelectedIndex > 0)
            {
                _obj_SMHR_EMPLOYEEGRADE_SLAB.OPERATION = operation.Get;
                _obj_SMHR_EMPLOYEEGRADE_SLAB.EMPLOYEEGRADE_SLAB_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_SMHR_EMPLOYEEGRADE_SLAB.EMPLOYEEGRADE_SLAB_EMPLOYEEGRADE_ID = Convert.ToInt32(rcmb_Grade.SelectedValue);

                DataTable dtSlabs = LoadSalarySlabs1();

                if (dtSlabs.Rows.Count > 0)
                {
                    rcmb_Slab.DataSource = dtSlabs;
                    rcmb_Slab.DataTextField = "EMPLOYEEGRADE_SLAB_AMOUNT";
                    rcmb_Slab.DataValueField = "EMPLOYEEGRADE_SLAB_ID";
                    rcmb_Slab.DataBind();
                }
                rcmb_Slab.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            }
            else
            {
                if (rcbFinPeriod.SelectedIndex == 0)
                {
                    BLL.ShowMessage(this, "Please select Financial Period before selecting Grade");
                    rcbFinPeriod.Focus();
                    rcmb_Grade.SelectedIndex = -1;
                    //rcmb_Slab.SelectedIndex = -1;
                    rcmb_Slab.Items.Clear();
                    rcmb_Slab.Items.Insert(0,new RadComboBoxItem("",""));
                    return;
                }
                rcmb_Slab.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_jobrequisition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcbFinPeriod_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcbFinPeriod.SelectedIndex > 0)
            {
                rcmb_Grade.Items.Clear();
                rcmb_Slab.Items.Clear();

                SMHR_EMPLOYEEGRADE_SLAB _obj_Smhr_EmployeeGrade = new SMHR_EMPLOYEEGRADE_SLAB();
                _obj_Smhr_EmployeeGrade.EMPLOYEEGRADE_SLAB_EMPLOYEEGRADE_ID = Convert.ToInt32(rcmb_Grade.SelectedItem);
                _obj_Smhr_EmployeeGrade.OPERATION = operation.Employeegrades;
                _obj_Smhr_EmployeeGrade.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_EmployeeGrade.EMPLOYEEGRADE_SLAB_PERIOD_ID = Convert.ToInt32(rcbFinPeriod.SelectedValue);

                DataTable dt = new DataTable();
                dt = BLL.get_EmployeeGrades(_obj_Smhr_EmployeeGrade);

                if (dt.Rows.Count > 0)
                {
                    rcmb_Grade.DataSource = dt;
                    rcmb_Grade.DataTextField = "EMPLOYEEGRADE_SLAB_EMPLOYEEGRADE_CODE";
                    rcmb_Grade.DataValueField = "EMPLOYEEGRADE_SLAB_EMPLOYEEGRADE_ID";
                    rcmb_Grade.DataBind();
                }
                rcmb_Grade.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                rcmb_Slab.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                rcmb_Grade.Enabled = true;
                rcmb_Slab.Enabled = true;
            }
            else
            {
                rcmb_Grade.SelectedIndex = 0;
                rcmb_Slab.SelectedIndex = 0;
                //rcmb_Grade.Items.Clear();
                //rcmb_Slab.Items.Clear();
                rcbFinPeriod.ClearSelection();
                rcbFinPeriod.Text = string.Empty;
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_jobrequisition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}