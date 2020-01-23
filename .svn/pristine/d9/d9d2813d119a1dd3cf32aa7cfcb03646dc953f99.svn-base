using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using RECRUITMENT;
using SMHR;

public partial class Recruitment_frm_ViewJobReq : System.Web.UI.Page
{
    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    string JOBREQ_ID = Convert.ToString(Request.QueryString["JOBREQ_ID"]);
    //    Response.Redirect("~/Recruitment/frm_JobRequisition.aspx?JOBREQ_ID=" + JOBREQ_ID + "&Buttons=0", false);
    //}

    SMHR_GLOBALCONFIG _obj_smhr_globalConfig;
    SMHR_MASTERS _obj_Smhr_Masters;
    SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit;
    SMHR_EMPLOYEE _obj_smhr_employee;
    SMHR_DEPARTMENT _obj_SMHR_Department;
    SMHR_POSITIONS _obj_smhr_Position;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    RECRUITMENT_JOBREQUISITION _obj_Rec_JobRequisition;
    RECRUITMENT_JOBREQSKILLS _obj_Rec_JobReqSkills;
    SMHR_MASTERS _obj_smhr_masters;

    static DataTable dt_Details = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
            if (!Page.IsPostBack)
            {
                LoadPeriod();
                if (Request.QueryString["JOBREQ_ID"] != null)
                {
                    lnk_Edit_Command(null, null);
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ViewJobReq", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }



    protected override void InitializeCulture()
    {
        Recruitment_BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }
    private void LoadPeriod()
    {
        try
        {
            rcmb_financialPeriod.Items.Clear();
            SMHR_PERIOD PRD = new SMHR_PERIOD();
            PRD.OPERATION = operation.PERIOD;
            PRD.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT = new DataTable();
            DT = BLL.GetEmployeePeriod(PRD);
            //rcbFinPeriod.DataSource = BLL.GetEmployeePeriod(PRD);
            if (DT.Rows.Count > 0)
            {
                rcmb_financialPeriod.DataSource = DT;
                rcmb_financialPeriod.DataTextField = "PERIOD_NAME";
                rcmb_financialPeriod.DataValueField = "PERIOD_ID";
                rcmb_financialPeriod.DataBind();
            }
            rcmb_financialPeriod.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
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

    //#region Previous code   

    //private void LoadCombos()
    //{
    //    try
    //    {
    //        _obj_smhr_Position = new SMHR_POSITIONS();
    //        //  _obj_Smhr_Masters.OPERATION = operation.Select;
    //        _obj_smhr_Position.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
    //        dt_Details = BLL.get_Positions(_obj_smhr_Position);
    //        if (dt_Details.Rows.Count > 0)
    //        {
    //            rcmb_Designation.DataSource = dt_Details;
    //            rcmb_Designation.DataTextField = "POSITIONS_CODE";
    //            rcmb_Designation.DataValueField = "POSITIONS_ID";
    //            rcmb_Designation.DataBind();
    //            rcmb_Designation.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0")); //Modified By Ragha Sudha on 27th July 2013
    //        }

    //        _obj_Smhr_Masters = new SMHR_MASTERS();
    //        _obj_Smhr_Masters.OPERATION = operation.Select;
    //        _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
    //        _obj_Smhr_Masters.MASTER_TYPE = "QUALIFICATION";
    //        dt_Details = BLL.get_MasterRecords(_obj_Smhr_Masters);
    //        if (dt_Details.Rows.Count > 0)
    //        {
    //            rcmb_Qualification.DataSource = dt_Details;
    //            rcmb_Qualification.DataTextField = "HR_MASTER_CODE";
    //            rcmb_Qualification.DataValueField = "HR_MASTER_ID";
    //            rcmb_Qualification.DataBind();
    //            rcmb_Qualification.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0")); //Modified by sudha 27/07/2013
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
    //        //   rcmb_Grade.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
    //        rcmb_Grade.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
    //        rcmb_Grade.Focus();

    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_jobrequisition", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //        return;
    //    }
    //}

    //private void LoadBusinessUnit()
    //{
    //    try
    //    {
    //        //_obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
    //        //_obj_Smhr_BusinessUnit.OPERATION = operation.Select;
    //        //_obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
    //        //_obj_Smhr_BusinessUnit.ISDELETED = true;
    //        //// _obj_Smhr_BusinessUnit.BUSINESSUNIT_ID = Convert.ToInt32(Session["BUSINESSUNIT_ID"].ToString());
    //        //rcmb_BU.Items.Clear();
    //        //DataTable dt = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
    //        //if (dt.Rows.Count != 0)
    //        //{
    //        //    rcmb_BU.DataSource = dt;
    //        //    rcmb_BU.DataTextField = "BUSINESSUNIT_CODE";
    //        //    rcmb_BU.DataValueField = "BUSINESSUNIT_ID";
    //        //    rcmb_BU.DataBind();
    //        //    rcmb_BU.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
    //        //}
    //        //else
    //        //{
    //        //    DataTable dt1 = new DataTable();
    //        //    rcmb_BU.DataSource = dt1;
    //        //    rcmb_BU.DataBind();
    //        //    rcmb_BU.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
    //        //    return;
    //        //}


    //        if ((Convert.ToInt32(Session["EMP_ID"]) == 0))
    //        {
    //            //FOR ADMIN
    //            // Loading Business Unit 
    //            rcmb_BU.Items.Clear();
    //            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
    //            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
    //            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
    //            if (dt_BUDetails.Rows.Count > 0)
    //            {
    //                rcmb_BU.DataSource = dt_BUDetails;
    //                rcmb_BU.DataValueField = "BUSINESSUNIT_ID";
    //                rcmb_BU.DataTextField = "BUSINESSUNIT_CODE";
    //                rcmb_BU.DataBind();
    //            }
    //            rcmb_BU.Items.Insert(0, new RadComboBoxItem("Select", "0"));
    //            rcmb_RaisedBy.Items.Clear();
    //            rcmb_RaisedBy.Items.Insert(0, new RadComboBoxItem("Select", "0"));

    //            //SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
    //            //_obj_smhr_emp_payitems.OPERATION = operation.Self;
    //            //_obj_smhr_emp_payitems.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
    //            //_obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //            //DataTable DT_SELF = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
    //            //if (DT_SELF.Rows.Count > 0)
    //            //{
    //            //    //rcmb_BU.SelectedIndex  = rcmb_BU.FindItemIndexByValue(Convert.ToString(DT_SELF.Rows[0]["EMP_BUSINESSUNIT_ID"]));
    //            //    rcmb_BU.SelectedValue = Convert.ToString(DT_SELF.Rows[0]["EMP_BUSINESSUNIT_ID"]);
    //            //}
    //            //  LoadEmployee();
    //            //rcmb_RaisedBy.SelectedIndex = rcmb_RaisedBy.FindItemIndexByValue(DT_SELF.Rows[0]["EMP_ID"].ToString());
    //            //rcmb_BU.Enabled = false;
    //            //hdn_RaisedBy.Value = DT_SELF.Rows[0]["EMP_ID"].ToString();   //Inserted By Sudha for Raised By Value 0n 26th July 2013
    //            //rcmb_RaisedBy.Enabled = false;

    //            //    rcmb_RaisedBy.Items.Insert(0, new RadComboBoxItem("Select"));
    //        }
    //        else
    //        {
    //            //FOR SELF EMPLOYEE and MANAGER
    //            // Loading Business Unit 
    //            rcmb_BU.Items.Clear();
    //            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
    //            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
    //            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
    //            if (dt_BUDetails.Rows.Count > 0)
    //            {
    //                rcmb_BU.DataSource = dt_BUDetails;
    //                rcmb_BU.DataValueField = "BUSINESSUNIT_ID";
    //                rcmb_BU.DataTextField = "BUSINESSUNIT_CODE";
    //                rcmb_BU.DataBind();
    //            }
    //            rcmb_BU.Items.Insert(0, new RadComboBoxItem("Select"));
    //            rcmb_RaisedBy.Items.Clear();
    //            //rcmb_EmployeeCode.Items.Insert(0, new RadComboBoxItem("Select"));


    //            SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
    //            _obj_smhr_emp_payitems.OPERATION = operation.Self;
    //            _obj_smhr_emp_payitems.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
    //            _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //            DataTable DT_SELF = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
    //            if (DT_SELF.Rows.Count > 0)
    //            {
    //                //rcmb_BU.SelectedIndex  = rcmb_BU.FindItemIndexByValue(Convert.ToString(DT_SELF.Rows[0]["EMP_BUSINESSUNIT_ID"]));
    //                rcmb_BU.SelectedValue = Convert.ToString(DT_SELF.Rows[0]["EMP_BUSINESSUNIT_ID"]);
    //            }
    //            LoadEmployee();
    //            rcmb_RaisedBy.SelectedIndex = rcmb_RaisedBy.FindItemIndexByValue(DT_SELF.Rows[0]["EMP_ID"].ToString());
    //            LoadDepartment();
    //            rcmb_Department.SelectedIndex = rcmb_Department.FindItemIndexByValue(DT_SELF.Rows[0]["DEPARTMENT_ID"].ToString());
    //            rcmb_Department.Enabled = false;
    //            //  rcmb_BU.Enabled = false;
    //            hdn_RaisedBy.Value = DT_SELF.Rows[0]["EMP_ID"].ToString();   //Inserted By Sudha for Raised By Value 0n 26th July 2013
    //            rcmb_RaisedBy.Enabled = false;
    //        }
    //        Load_Department_Interviewer();
    //    }

    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_jobrequisition", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //        return;
    //    }
    //}

    //private void LoadEmployee()
    //{
    //    try
    //    {
    //        #region MyRegion
    //        //if (Session["EMP_ID"] != null)
    //        //{
    //        //    _obj_smhr_employee = new SMHR_EMPLOYEE();
    //        //    _obj_smhr_employee.OPERATION = operation.load;
    //        //    _obj_smhr_employee.EMP_ID = Convert.ToInt32(Session["EMP_ID"].ToString());
    //        //    rcmb_RaisedBy.Items.Clear();
    //        //    DataTable dt = BLL.get_Employee(_obj_smhr_employee);
    //        //    if (dt.Rows.Count != 0)
    //        //    {
    //        //        rcmb_RaisedBy.DataSource = dt;
    //        //        rcmb_RaisedBy.DataTextField = "EMPNAME";
    //        //        rcmb_RaisedBy.DataValueField = "EMP_ID";
    //        //        rcmb_RaisedBy.DataBind();
    //        //    }
    //        //    else
    //        //    {
    //        //        DataTable dt1 = new DataTable();
    //        //        rcmb_RaisedBy.DataSource = dt1;
    //        //        rcmb_RaisedBy.DataBind();
    //        //        return;
    //        //    }
    //        //}

    //        #endregion
    //        SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
    //        //_obj_smhr_emp_payitems.OPERATION = operation.Empty;
    //        DataTable DT_Details = new DataTable();
    //        if (rcmb_BU.SelectedItem.Value != "")
    //        {
    //            //if (Convert.ToString(Session["SELFSERVICE"]) == "" || Convert.ToString(Session["SELFSERVICE"]) == "true")
    //            //{
    //            //    _obj_smhr_emp_payitems.OPERATION = operation.Empty_Self;
    //            //    _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
    //            //    _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //            //    _obj_smhr_emp_payitems.REPORTING_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
    //            //    DT_Details = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
    //            //    if (DT_Details.Rows.Count != 0)
    //            //    {
    //            //        BindEmployees(DT_Details);
    //            //    }
    //            //    else
    //            //    {
    //            //        BindEmployees(DT_Details);
    //            //    }
    //            //}
    //            //else
    //            //{

    //            _obj_smhr_emp_payitems.OPERATION = operation.Empty;
    //            _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
    //            _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //            DT_Details = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
    //            if (DT_Details.Rows.Count != 0)
    //            {
    //                BindEmployees(DT_Details);
    //            }
    //            else
    //            {
    //                BindEmployees(DT_Details);
    //            }
    //            //}
    //        }
    //        else
    //        {
    //            BindEmployees(DT_Details);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_jobrequisition", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //        return;
    //    }
    //}

    //private void LoadEmployee2()
    //{
    //    _obj_smhr_employee = new SMHR_EMPLOYEE();
    //    //_obj_smhr_employee.OPERATION = operation.Department;
    //    _obj_smhr_employee.EMP_ID = Convert.ToInt32(Session["EMP_ID"].ToString());
    //    rcmb_RaisedBy.Items.Clear();
    //    DataTable dt = BLL.get_Employee(_obj_smhr_employee);
    //    if (dt.Rows.Count != 0)
    //    {
    //        rcmb_RaisedBy.DataSource = dt;
    //        rcmb_RaisedBy.DataTextField = "EMPNAME";
    //        rcmb_RaisedBy.DataValueField = "EMP_ID";
    //        rcmb_RaisedBy.DataBind();
    //        rcmb_RaisedBy.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
    //    }
    //}

    //private void BindEmployees(DataTable DT_Details)
    //{
    //    try
    //    {
    //        rcmb_RaisedBy.DataSource = DT_Details;
    //        rcmb_RaisedBy.DataTextField = "EMPNAME";
    //        rcmb_RaisedBy.DataValueField = "EMP_ID";
    //        rcmb_RaisedBy.DataBind();
    //        rcmb_RaisedBy.Items.Insert(0, new RadComboBoxItem("Select", "0"));
    //        if (Convert.ToInt32(Session["EMP_ID"]) == 0)
    //        {
    //            rcmb_RaisedBy.Enabled = true;
    //        }
    //        else
    //        {
    //            rcmb_RaisedBy.SelectedIndex = rcmb_RaisedBy.Items.FindItemIndexByValue(Convert.ToString(Session["EMP_ID"]));
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_jobrequisition", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //        return;
    //    }
    //}

    //protected void rcmb_BU_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    //{
    //    LoadCurrSymbol();
    //    if (Convert.ToInt32(Session["EMP_ID"]) == 0)
    //    {
    //        LoadDepartment();
    //        LoadEmployee();
    //    }
    //}
    //protected void rcmb_Department_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    //{
    //    LoadEmployee2();
    //}

    //protected void rcmb_RaisedBy_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    //{
    //    hdn_RaisedBy.Value = rcmb_RaisedBy.SelectedValue;   //Inserted By Sudha for Raised By Value 0n 26th July 2013
    //    // rcmb_RaisedBy.Enabled = false;
    //}

    ////protected void Rg_JobRequisition_PreRender(object sender, EventArgs e)
    ////{
    ////    GridColumn gridCol = Rg_JobRequisition.MasterTableView.GetColumn("JOBREQ_Approved/Rejected");
    ////    gridCol.HeaderStyle.Width = Unit.Pixel(200);
    ////}

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
    //                rcmb_interviewer.DataSource = dt;
    //                rcmb_interviewer.DataBind();
    //                rcmb_interviewer.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

    //            }
    //        }
    //        else
    //        {
    //            rcmb_interviewer.Items.Clear();
    //            //rlst_interviewer.Items.Clear();
    //            rcmb_interviewer.ClearSelection();
    //            rcmb_interviewer.Items.Insert(0, new RadComboBoxItem("Select", "0")); //Inserted By Ragha Sudha on July30th 2013

    //            SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
    //            _obj_smhr_emp_payitems.OPERATION = operation.ADMIN;
    //            //_obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
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
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ViewJobReq", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //        return;
    //    }
    //}
    //private void Load_Department_Interviewer()
    //{
    //    try
    //    {
    //        SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
    //        _obj_smhr_emp_payitems.OPERATION = operation.ADMIN;
    //        //_obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
    //        _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //        DataTable DT_Details = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
    //        if (dt_Details.Rows.Count > 0)
    //        {
    //            rcmb_interviewer.DataSource = DT_Details;
    //            rcmb_interviewer.DataTextField = "EMPNAME";
    //            rcmb_interviewer.DataValueField = "EMP_ID";
    //            rcmb_interviewer.DataBind();
    //            rcmb_interviewer.Items.Insert(0, new RadComboBoxItem("Select"));
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ViewJobReq", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //        return;
    //    }
    //}
    //protected void LoadCurrSymbol()
    //{
    //    if (rcmb_BU.SelectedItem != null)
    //    {
    //        _obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
    //        _obj_Smhr_BusinessUnit.OPERATION = operation.load;
    //        //  if (Session["ORG_ID"] != null)                                        <telerik:RadComboBox ID="rcmb_RaisedBy" runat="server" AutoPostBack="true" Skin="WebBlue"

    //        //if (rcmb_BU.SelectedItem.Value=)
    //        //{
    //        _obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
    //        _obj_Smhr_BusinessUnit.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
    //        // }
    //        DataTable dt = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
    //        if (dt.Rows.Count != 0)
    //        {
    //            lbl_ctc.Visible = true;
    //            lbl_ctc.Text = Convert.ToString(dt.Rows[0]["CURR_SYMBOL"]);
    //        }
    //        else
    //        {
    //            lbl_ctc.Visible = true;
    //            lbl_ctc.Text = "";
    //        }
    //    }
    //}

    //private void LoadDepartment()
    //{
    //    try
    //    {
    //        _obj_SMHR_Department = new SMHR_DEPARTMENT();
    //        _obj_SMHR_Department.MODE = 9;
    //        _obj_SMHR_Department.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
    //        _obj_SMHR_Department.BUID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
    //        dt_Details = BLL.get_Department(_obj_SMHR_Department);
    //        if (dt_Details.Rows.Count != 0)
    //        {
    //            rcmb_Department.DataSource = dt_Details;
    //            rcmb_Department.DataTextField = "DEPARTMENT_NAME";
    //            rcmb_Department.DataValueField = "DEPARTMENT_ID";
    //            rcmb_Department.DataBind();
    //            rcmb_Department.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0")); //Modified by sudha 27/07/2013

    //            //Interviewer Department
    //            rcmb_dept_interviewer.DataSource = dt_Details;
    //            rcmb_dept_interviewer.DataTextField = "DEPARTMENT_NAME";
    //            rcmb_dept_interviewer.DataValueField = "DEPARTMENT_ID";
    //            rcmb_dept_interviewer.DataBind();
    //            rcmb_dept_interviewer.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
    //        }
    //        else
    //        {
    //            rcmb_Department.DataSource = dt_Details;
    //            rcmb_Department.DataBind();
    //            rcmb_Department.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

    //            rcmb_dept_interviewer.DataSource = dt_Details;
    //            rcmb_dept_interviewer.DataBind();
    //            rcmb_dept_interviewer.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
    //            return;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ViewJobReq", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //        return;
    //    }
    //}

    //private void getJrNo()
    //{
    //    try
    //    {
    //        DataTable dt_code;
    //        string code = string.Empty;
    //        string str = string.Empty;
    //        string Series = string.Empty;
    //        //_obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
    //        _obj_Rec_JobRequisition.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
    //        _obj_Rec_JobRequisition.OPERATION = operation.load;
    //        dt_code = Recruitment_BLL.get_JrCode(_obj_Rec_JobRequisition);
    //        if (dt_code.Rows.Count != 0)
    //        {
    //            str = dt_code.Rows[0][0].ToString().Trim();
    //            if (str.Length == 1)
    //            {
    //                Series = "000";
    //            }
    //            else if (str.Length == 2)
    //            {
    //                Series = "00";
    //            }
    //            else if (str.Length == 3)
    //            {
    //                Series = "00";
    //            }
    //            else if (str.Length == 4)
    //            {
    //                Series = "0";
    //            }
    //            _obj_smhr_globalConfig = new SMHR_GLOBALCONFIG();
    //            _obj_smhr_globalConfig.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
    //            _obj_smhr_globalConfig.OPERATION = operation.Select;
    //            DataTable dt = BLL.get_ConfigDetails(_obj_smhr_globalConfig);
    //            if (dt.Rows.Count != 0)
    //            {
    //                rtxt_JRCode.Text = dt.Rows[0]["GLOBALCONFIG_RECRUIT_JOBREQ_CODE"].ToString().Trim() + Convert.ToString(Series) + Convert.ToString(str);
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ViewJobReq", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //        return;
    //    }
    //}

    //public void LoadGrid()
    //{
    //    if (Convert.ToInt32(Session["EMP_ID"]) == 0)
    //    {
    //        _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
    //        _obj_Rec_JobRequisition.MODE = 6;
    //        _obj_Rec_JobRequisition.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
    //        DataTable DT = Recruitment_BLL.get_JobRequisition(_obj_Rec_JobRequisition);
    //        Rg_JobRequisition.DataSource = DT;
    //    }
    //    else
    //    {
    //        _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
    //        _obj_Rec_JobRequisition.OPERATION = operation.Select;
    //        _obj_Rec_JobRequisition.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
    //        _obj_Rec_JobRequisition.JOBREQ_RAISEDBY = Convert.ToInt32(Session["EMP_ID"].ToString());
    //        DataTable DT = Recruitment_BLL.get_JobRequisition(_obj_Rec_JobRequisition);
    //        Rg_JobRequisition.DataSource = DT;
    //    }

    //}

    //protected void Rg_JobRequisition_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    //{
    //    LoadGrid();
    //}

    //protected void lnk_Add_Command(object sender, CommandEventArgs e)
    //{
    //    try
    //    {
    //        //if ((Convert.ToInt32(Session["EMP_ID"]) != (-1)))
    //        //{
    //        //if (Convert.ToInt32(Session["EMP_ID"]) != 0)
    //        //{

    //        //clearControls();
    //        //LoadCombos();
    //        //LoadBusinessUnit();
    //        //LoadEmployee();

    //        //rcmb_Status.SelectedItem.Text = "open";
    //        //rcmb_Status.Enabled = false;

    //        //rcmb_RaisedBy.Enabled = false;
    //        //btn_Save.Visible = true;
    //        //btn_Update.Visible = false;

    //        //tr_ActDate.Visible = false;
    //        //Rm_JobRequisition_page.SelectedIndex = 1;

    //        if ((Convert.ToInt32(Session["EMP_ID"]) == 0))
    //        {
    //            clearControls();
    //            LoadCombos();
    //            LoadBusinessUnit();
    //            LoadDropDowns();
    //            rcmb_RaisedBy.Enabled = true;
    //            rtxt_Desc.Enabled = true;
    //            rcmb_BU.Enabled = true;
    //            //          rcmb_Status.SelectedItem.Text = "open";
    //            //         rcmb_Status.Enabled = false;
    //            //btn_Save.Visible = true;
    //            //btn_Update.Visible = false;
    //            tr_ActDate.Visible = false;
    //            Rm_JobRequisition_page.SelectedIndex = 1;
    //            rfv_RaisedBy.Visible = false;
    //            rdtp_ExpectedDate.MinDate = DateTime.Now;
    //        }
    //        else
    //        {
    //            clearControls();
    //            LoadCombos();
    //            LoadBusinessUnit();
    //            LoadDropDowns();
    //            Load_Department_Interviewer();
    //            rcmb_RaisedBy.Enabled = false;
    //            rcmb_BU.Enabled = false;
    //            //      rcmb_Status.SelectedItem.Text = "open";
    //            //     rcmb_Status.Enabled = false;
    //            //btn_Save.Visible = true;
    //            //btn_Update.Visible = false;
    //            tr_ActDate.Visible = false;
    //            Rm_JobRequisition_page.SelectedIndex = 1;

    //            rcmb_BU.SelectedIndex = 1;
    //            rcmb_BU_SelectedIndexChanged(null, null);
    //            // rcmb_RaisedBy.SelectedIndex = rcmb_RaisedBy.FindItemIndexByValue(Convert.ToString(Session["EMP_ID"]));
    //            rdtp_ExpectedDate.MinDate = DateTime.Now;
    //            rtxt_Desc.Enabled = true;
    //        }

    //        //}
    //        //    else

    //        //        BLL.ShowMessage(this, "You do not have permissions to login");
    //        //}
    //        //else
    //        //    BLL.ShowMessage(this, "You do not have permissions to login");
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_jobrequisition", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //        return;
    //    }

    //}

    //protected void btn_Save_Click(object sender, EventArgs e)
    //{
    //    //Session["Expected_date"] = rdtp_ExpectedDate.SelectedDate.Value;
    //    //String  dt1=  Session["Expected_date"].ToString ();
    //    //if(dt1 <= Session["Interview_Date"] 
    //    //{

    //    //}
    //    if (rlst_interviewer.Items.Count < 2) //Modified BY Ragha Sudha on 29th July 2013
    //    {
    //        BLL.ShowMessage(this, "Please Assign Minimum two Interviewer(s)");  //Earlier it was 1 interviewer
    //        return;
    //    }
    //    _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
    //    _obj_Rec_JobRequisition.JOBREQ_BUDGETESTIMATION = Convert.ToInt32(Convert.ToInt32(RNT_Openings.Text) * Convert.ToInt32(RNT_Appctc.Text));
    //    _obj_Rec_JobRequisition.JOBREQ_REQEXPIRY = Convert.ToDateTime(rdtp_ExpectedDate.SelectedDate.Value);

    //    //commneted by aravinda from here
    //    //if (rdtp_ActualClosedDate.SelectedDate < rdtp_ExpectedDate.SelectedDate)
    //    //{
    //    //    Recruitment_BLL.ShowMessage(this, "Job Requisition Actual Closed Date cannot be less than Expected Closer Date");
    //    //    return;
    //    //}

    //    /* //else
    //     //{
    //     //    _obj_Rec_JobRequisition.JOBREQ_ACTUALCLOSEDDATE = Convert.ToDateTime(rdtp_ActualClosedDate.SelectedDate);
    //     //}*/
    //    //commneted by aravinda till here


    //    //if (RNT_Experience.Text != string.Empty && rcmb_Qualification.SelectedItem.Value != string.Empty)
    //    //{
    //    //    if (chk_IsExperienceReq.Checked == false && chk_IsQualificationReQ.Checked == false)
    //    //    {
    //    //        Recruitment_BLL.ShowMessage(this, @"\n-Please check an Experience to which you want to give Value \n -Please check an Qualification to which you want to give Value");
    //    //        return;
    //    //    }
    //    //}
    //    //if (chk_IsExperienceReq.Checked == true && chk_IsQualificationReQ.Checked == true)
    //    //{
    //    //    if (RNT_Experience.Text == string.Empty && rcmb_Qualification.SelectedItem.Value == string.Empty)
    //    //    {
    //    //        Recruitment_BLL.ShowMessage(this, "\n-Please enter Experience value \n Please enter Percentage value ");
    //    //        return;
    //    //    }
    //    //}

    //    if (rlb_SkillReq.CheckedItems.Count == 0)
    //    {
    //        Recruitment_BLL.ShowMessage(this, "Please select Resource Requisition skills from list");
    //        return;
    //    }
    //    if (RNT_Openings.Value == 0)
    //    {
    //        Recruitment_BLL.ShowMessage(this, "Please Enter The Number of openings");
    //        return;
    //    }

    //    string str = string.Empty;

    //    foreach (RadListBoxItem item in rlst_interviewer.Items)
    //    {
    //        str += item.Value + ",";
    //    }
    //    if (str.Length > 0)
    //    {
    //        str = str.Remove(str.Length - 1, 1);
    //    }
    //    //if(RNT_Appctc.Value == 0)
    //    //{
    //    //    rcmb_RecruitmentFor.SelectedItem.Value  = "Fresher";
    //    //}



    //    _obj_Rec_JobRequisition.JOBREQ_INTERVIEWER = str;
    //    //  _obj_Rec_JobRequisition.JOBREQ_REQFOR = Convert.ToString(rcmb_req_for.SelectedItem.Text);
    //    if (rcmb_reqto_work.SelectedIndex > 0)
    //    {
    //        _obj_Rec_JobRequisition.JOBREQ_REQTOWORK = Convert.ToString(rcmb_reqto_work.SelectedItem.Text);
    //    }
    //    else
    //    {
    //        _obj_Rec_JobRequisition.JOBREQ_REQTOWORK = "";
    //    }
    //    _obj_Rec_JobRequisition.JOBREQ_GRADE = Convert.ToInt32(rcmb_Grade.SelectedItem.Value);
    //    _obj_Rec_JobRequisition.JOBREQ_LOCATION = Convert.ToString(rtxt_location.Text.Replace("'", "''"));
    //    _obj_Rec_JobRequisition.JOBREQ_EMPTYPE = Convert.ToString(rcmb_Emptype.SelectedItem.Value);

    //    _obj_Rec_JobRequisition.JOBREQ_STATUS = "Open";
    //    _obj_Rec_JobRequisition.JOBREQ_RAISEDBY = Convert.ToInt32(hdn_RaisedBy.Value); //Insetred By Sudha 26th July 2013
    //    _obj_Rec_JobRequisition.JOBREQ_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
    //    _obj_Rec_JobRequisition.JOBREQ_DEPARTMENT = Convert.ToInt32(rcmb_Department.SelectedItem.Value);
    //    _obj_Rec_JobRequisition.JOBREQ_DESIGNATION = Convert.ToInt32(rcmb_Designation.SelectedItem.Value);
    //    _obj_Rec_JobRequisition.JOBREQ_REQCODE = Convert.ToString(rtxt_JRCode.Text);
    //    _obj_Rec_JobRequisition.JOBREQ_APPROVALSTATUS = 0;
    //    _obj_Rec_JobRequisition.JOBREQ_OPENINGS = Convert.ToInt32(RNT_Openings.Text);
    //    _obj_Rec_JobRequisition.JOBREQ_EXPYEARS = Convert.ToInt32(RNT_Experience.Text);
    //    _obj_Rec_JobRequisition.JOBREQ_AppCTC = Convert.ToInt32(RNT_Appctc.Text);
    //    _obj_Rec_JobRequisition.JOBREQ_ISYEARSREQ = Convert.ToBoolean(chk_IsExperienceReq.Checked);
    //    _obj_Rec_JobRequisition.JOBREQ_QUALIFICATION = Convert.ToInt32(rcmb_Qualification.SelectedItem.Value);
    //    //    _obj_Rec_JobRequisition.JOBREQ_PERCENTAGE = Convert.ToInt32(RNT_Percentage.Text);
    //    _obj_Rec_JobRequisition.JOBREQ_ISQUALREQ = Convert.ToBoolean(chk_IsQualificationReQ.Checked);
    //    _obj_Rec_JobRequisition.JOBREQ_COMMENTS = Recruitment_BLL.ReplaceQuote(Convert.ToString(rtxt_Comments.Text));
    //    _obj_Rec_JobRequisition.CREATEDBY = 1; // ### Need to Get the Session
    //    _obj_Rec_JobRequisition.CREATEDDATE = DateTime.Now;

    //    _obj_Rec_JobRequisition.LASTMDFBY = 1; // ### Need to Get the Session
    //    _obj_Rec_JobRequisition.LASTMDFDATE = DateTime.Now;
    //    _obj_Rec_JobRequisition.JOBREQ_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
    //    _obj_Rec_JobRequisition.JOBREQ_RECRUITMENTFOR = Convert.ToString(rcmb_RecruitmentFor.SelectedValue);
    //    _obj_Rec_JobRequisition.JOBREQ_CURRENTSTATUS = "Raised";
    //    switch (((Button)sender).ID.ToUpper())
    //    {
    //        case "BTN_UPDATE":
    //            //_obj_Rec_JobRequisition.MODE = 15;
    //            //_obj_Rec_JobRequisition.JOBREQ_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
    //            //_obj_Rec_JobRequisition.JOBREQ_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
    //            //DataTable DTJR1 = Recruitment_BLL.get_JobRequisition(_obj_Rec_JobRequisition);
    //            //lbl_JRID.Text = Convert.ToString(DTJR1.Rows[0]["JOBREQ_ID"]);

    //            //_obj_Rec_JobRequisition.MODE = 14;
    //            //_obj_Rec_JobRequisition.JOBREQ_ID = Convert.ToInt32(lbl_JRID.Text);
    //            //_obj_Rec_JobRequisition.JOBREQ_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
    //            //DataTable DT = Recruitment_BLL.get_JobRequisition(_obj_Rec_JobRequisition);
    //            //if (Convert.ToDateTime(DT.Rows[0]["JOBREQ_REQEXPIRY"]) > Convert.ToDateTime(DT.Rows[0]["PHASE_INTERVIEWDATE"]))
    //            //{
    //            //    Recruitment_BLL.ShowMessage(this, "Job Requisition Expected Closure date must be less than or Equal to Interview Date");
    //            //    return;
    //            //}
    //            _obj_Rec_JobRequisition.OPERATION = operation.Check;
    //            _obj_Rec_JobRequisition.JOBREQ_ID = Convert.ToInt32(lbl_JRID.Text);
    //            _obj_Rec_JobRequisition.JOBREQ_REQNAME = Recruitment_BLL.ReplaceQuote(Convert.ToString(rtxt_Desc.Text));
    //            //if (Convert.ToString(Recruitment_BLL.get_JobRequisition(_obj_Rec_JobRequisition).Rows[0]["Count"]) != "1")
    //            //{
    //            //    Recruitment_BLL.ShowMessage(this, "Job Requisition with this Name Already Exists");
    //            //    return;
    //            //}
    //            //if (rdtp_ExpectedDate.MinDate =ViewState["ExpectedCloserDate"].ToString())
    //            //{
    //            //    Recruitment_BLL.ShowMessage(this, " Resource Requisition Expected Closer Date cannot be less than or Equal to Current Date");
    //            //    return;
    //            //}
    //            //if (rdtp_ActualClosedDate.SelectedDate < rdtp_ExpectedDate.SelectedDate)
    //            //{
    //            //    Recruitment_BLL.ShowMessage(this, "Resource Requisition Actual Closed Date cannot be less than Expected Closer Date");
    //            //    return;
    //            //}

    //            //else
    //            //{

    //            //    if (rdtp_ActualClosedDate.SelectedDate != null)
    //            //        _obj_Rec_JobRequisition.JOBREQ_ACTUALCLOSEDDATE = Convert.ToDateTime(rdtp_ActualClosedDate.SelectedDate);
    //            //    else
    //            //        _obj_Rec_JobRequisition.JOBREQ_ACTUALCLOSEDDATE = null;
    //            //}
    //            _obj_Rec_JobRequisition.OPERATION = operation.Update;
    //            if (Recruitment_BLL.set_JobRequisition(_obj_Rec_JobRequisition))
    //            {
    //                _obj_Rec_JobReqSkills = new RECRUITMENT_JOBREQSKILLS();
    //                _obj_Rec_JobReqSkills.JR_ID = Convert.ToInt32(lbl_JRID.Text);
    //                _obj_Rec_JobReqSkills.MODE = 4;
    //                Recruitment_BLL.set_Jr_Skills(_obj_Rec_JobReqSkills);

    //                for (int i = 0; i <= rlb_SkillReq.CheckedItems.Count - 1; i++)
    //                {
    //                    _obj_Rec_JobReqSkills.MODE = 3;
    //                    _obj_Rec_JobReqSkills.JR_ID = Convert.ToInt32(lbl_JRID.Text);
    //                    _obj_Rec_JobReqSkills.SKILL_ID = Convert.ToInt32(rlb_SkillReq.CheckedItems[i].Value);
    //                    _obj_Rec_JobReqSkills.JOBREQ_ISSKILLREQ = true;
    //                    _obj_Rec_JobReqSkills.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);//##Session Required Here
    //                    _obj_Rec_JobReqSkills.CREATEDDATE = DateTime.Now;
    //                    _obj_Rec_JobReqSkills.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                    Recruitment_BLL.set_Jr_Skills(_obj_Rec_JobReqSkills);


    //                }
    //                if (Convert.ToString(ViewState["PRIORITY"]) == "1")
    //                {
    //                    _obj_Rec_JobRequisition.JOBREQ_ID = Convert.ToInt32(lbl_JRID.Text);
    //                    //_obj_Rec_JobRequisition.JOBREQUISTIONPRIORITY = Convert.ToString(rcmb_Priority.SelectedValue);
    //                    _obj_Rec_JobRequisition.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
    //                    _obj_Rec_JobRequisition.OPERATION = operation.Update1;
    //                    Recruitment_BLL.set_JobRequisition(_obj_Rec_JobRequisition);
    //                }
    //                Recruitment_BLL.ShowMessage(this, "Information Updated Successfully");
    //                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

    //                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
    //                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["EMP_ID"]).Trim();
    //                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

    //                _obj_Rec_JobRequisition.JOBREQ_RAISEDBY = Convert.ToInt32(Session["EMP_ID"]);
    //                bool status1 = Recruitment_BLL.get_JobReqAprover(_obj_Rec_JobRequisition);
    //                if (status1)
    //                {
    //                    Recruitment_BLL.ShowMessage(this, "Notification Sent");
    //                }
    //                getJrNo();
    //            }
    //            else
    //                Recruitment_BLL.ShowMessage(this, "Information Not Saved");
    //            if (Convert.ToString(Request.QueryString["JOBREQ_ID"]) != null)
    //            {
    //                Response.Redirect("~/Approval/frm_JobRequisitionApproval.aspx?JOBREQ=" + "JOBREQ");

    //            }
    //            LoadGrid();
    //            Rg_JobRequisition.DataBind();
    //            Rm_JobRequisition_page.SelectedIndex = 0;

    //            break;
    //        case "BTN_SAVE":
    //            getJrNo();
    //            //_obj_Rec_JobRequisition.MODE = 15;
    //            //_obj_Rec_JobRequisition.JOBREQ_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
    //            //_obj_Rec_JobRequisition.JOBREQ_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
    //            //DataTable DTJR = Recruitment_BLL.get_JobRequisition(_obj_Rec_JobRequisition);
    //            //lbl_JRID.Text = Convert.ToString(DTJR.Rows[0]["JOBREQ_ID"]);

    //            //_obj_Rec_JobRequisition.MODE = 14;
    //            //_obj_Rec_JobRequisition.JOBREQ_ID = Convert.ToInt32(lbl_JRID.Text);
    //            //_obj_Rec_JobRequisition.JOBREQ_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
    //            //DataTable DT_ = Recruitment_BLL.get_JobRequisition(_obj_Rec_JobRequisition);

    //            //if (Convert.ToDateTime(DT_.Rows[0]["JOBREQ_REQEXPIRY"]) > Convert.ToDateTime(DT_.Rows[0]["PHASE_INTERVIEWDATE"]))
    //            //{
    //            //    Recruitment_BLL.ShowMessage(this, "Job Requisition Expected Closure date must be less than or Equal to Interview Date");
    //            //    return;
    //            //}

    //            _obj_Rec_JobRequisition.JOBREQ_REQCODE = Convert.ToString(rtxt_JRCode.Text);
    //            _obj_Rec_JobRequisition.JOBREQ_REQNAME = Recruitment_BLL.ReplaceQuote(Convert.ToString(rtxt_Desc.Text));
    //            // _obj_Rec_JobRequisition.JOBREQ_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
    //            _obj_Rec_JobRequisition.MODE = 20;
    //            DataTable dt_ = Recruitment_BLL.get_JobRequisition(_obj_Rec_JobRequisition);//.Rows[0]["COUNT"]);
    //            if (Convert.ToString(Recruitment_BLL.get_JobRequisition(_obj_Rec_JobRequisition).Rows[0]["COUNT"]) != "0")
    //            {
    //                Recruitment_BLL.ShowMessage(this, "Resource Requisition with this Name Already Exists");
    //                return;
    //            }
    //            if (rdtp_ExpectedDate.SelectedDate < DateTime.Now.Date)
    //            {
    //                Recruitment_BLL.ShowMessage(this, " Resource Requisition Expected Closer Date cannot be less than or Equal to Current Date");
    //                return;
    //            }
    //            //_obj_Rec_JobRequisition.JOBREQ_REQEXPIRY = Convert.ToDateTime(rdtp_ExpectedDate.SelectedDate);
    //            //_obj_Rec_JobRequisition.CREATEDDATE = DateTime.Now;
    //            _obj_Rec_JobRequisition.OPERATION = operation.Insert;

    //            if (Recruitment_BLL.set_JobRequisition(_obj_Rec_JobRequisition))
    //            {
    //                rtxt_JRCode.Enabled = false;
    //                _obj_Rec_JobRequisition.MODE = 2;
    //                //  _obj_Rec_JobRequisition.JOBREQ_STATUS = 'Open';
    //                DataTable dt_findMax = Recruitment_BLL.get_JobRequisition(_obj_Rec_JobRequisition);
    //                if (dt_findMax.Rows.Count > 0)
    //                {
    //                    _obj_Rec_JobReqSkills = new RECRUITMENT_JOBREQSKILLS();
    //                    _obj_Rec_JobReqSkills.JR_ID = Convert.ToInt32(dt_findMax.Rows[0]["MAX"]);
    //                    for (int i = 0; i <= rlb_SkillReq.CheckedItems.Count - 1; i++)
    //                    {
    //                        _obj_Rec_JobReqSkills.MODE = 3;
    //                        //   _obj_Rec_JobReqSkills.JR_ID = Convert.ToInt32(lbl_JRID.Text);


    //                        _obj_Rec_JobReqSkills.SKILL_ID = Convert.ToInt32(rlb_SkillReq.CheckedItems[i].Value);

    //                        _obj_Rec_JobReqSkills.JOBREQ_ISSKILLREQ = true;
    //                        _obj_Rec_JobReqSkills.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); //##Session Required Here
    //                        _obj_Rec_JobReqSkills.CREATEDDATE = DateTime.Now;
    //                        _obj_Rec_JobReqSkills.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                        Recruitment_BLL.set_Jr_Skills(_obj_Rec_JobReqSkills);
    //                    }

    //                }
    //                Recruitment_BLL.ShowMessage(this, "Information Saved Successfully");

    //                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

    //                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
    //                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["EMP_ID"]).Trim();
    //                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

    //                _obj_Rec_JobRequisition.JOBREQ_RAISEDBY = Convert.ToInt32(Session["EMP_ID"]);
    //                bool status1 = Recruitment_BLL.get_JobReqAprover(_obj_Rec_JobRequisition);
    //                if (status1)
    //                {
    //                    Recruitment_BLL.ShowMessage(this, "Notification Sent");
    //                }
    //                getJrNo();
    //            }

    //            else
    //                Recruitment_BLL.ShowMessage(this, "Information Not Saved");
    //            LoadGrid();
    //            Rg_JobRequisition.DataBind();
    //            Rm_JobRequisition_page.SelectedIndex = 0;
    //            break;
    //        default:
    //            break;
    //    }
    //    //if (track == "add")
    //    //{
    //    //    _obj_Rec_JobReqSkills = new SMHR_JOBREQSKILLS();
    //    //    pnl_multipage2.Visible = true;
    //    //    RM_Skills.SelectedIndex = 0;
    //    //    DataTable DT1 = Recruitment_BLL.get_JobRequisition_jrid(new RECRUITMENT_JOBREQUISITION());
    //    //    lbl_id.Text = Convert.ToString(DT1.Rows[0]["jobreq_id"]);
    //    //    LoadGridskills(Convert .ToInt32 (lbl_id .Text));
    //    //    return;
    //    //}
    //    //Rm_JobRequisition_page.SelectedIndex = 1;      
    //    //LoadGrid();
    //    //Rg_JobRequisition.DataBind();

    //}

    ////protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    ////{
    ////    try
    ////    {
    ////        rcmb_BU.Enabled = false;
    ////        rtxt_JRCode.Enabled = false;
    ////        //    rcmb_Status.Enabled = true;
    ////        rtxt_Desc.Enabled = false;
    ////        //rdtp_ActualClosedDate.Visible = true;
    ////        //lbl_ActualDate.Visible = true;india
    ////        tr_ActDate.Visible = true;
    ////        // rcmb_BU.Enabled = false;

    ////        rdtp_ExpectedDate.MinDate = Convert.ToDateTime("01-01-1900");
    ////        //rcmb_Priority.SelectedIndex = 0;

    ////        rcmb_RaisedBy.Enabled = false;
    ////        _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
    ////        if (Request.QueryString["JOBREQ_ID"] != null)
    ////            _obj_Rec_JobRequisition.JOBREQ_ID = Convert.ToInt32(Convert.ToString(Request.QueryString["JOBREQ_ID"]));
    ////        else
    ////            _obj_Rec_JobRequisition.JOBREQ_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
    ////        _obj_Rec_JobRequisition.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    ////        _obj_Rec_JobRequisition.OPERATION = operation.Select;
    ////        DataTable dt = Recruitment_BLL.get_JobRequisition(_obj_Rec_JobRequisition);

    ////        if (dt.Rows.Count > 0)
    ////        {
    ////            string Reject_status = Convert.ToString(dt.Rows[0]["JOBREQ_APPROVALSTATUS"]);
    ////            //if (Reject_status == "REJECTED")
    ////            ////if (Reject_status == 3)
    ////            //{
    ////            //    btn_Update.Enabled = false;
    ////            //}
    ////            //else
    ////            //    btn_Update.Enabled = true;

    ////            lbl_JRID.Text = Convert.ToString(dt.Rows[0]["JOBREQ_ID"]);
    ////            rtxt_JRCode.Text = Convert.ToString(dt.Rows[0]["JOBREQ_REQCODE"]);
    ////            rtxt_Desc.Text = Convert.ToString(dt.Rows[0]["JOBREQ_REQNAME"]);
    ////            rdtp_ExpectedDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["JOBREQ_REQEXPIRY"]);
    ////            rdtp_ExpectedDate.MinDate = Convert.ToDateTime(dt.Rows[0]["JOBREQ_CREATEDDATE"]);
    ////            if (!String.IsNullOrEmpty(dt.Rows[0]["JOBREQ_ACTUALCLOSEDDATE"].ToString()))  //inserted by sudha 29th july 2013
    ////            {
    ////                rdtp_ActualClosedDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["JOBREQ_REQDATE"]);  //inserted by sudha 26th july 2013
    ////            }
    ////            else  //inserted by sudha 29th july 2013
    ////            {
    ////                rdtp_ActualClosedDate.SelectedDate = null;
    ////            }
    ////            rdtp_ActualClosedDate.Enabled = false;
    ////            //rdtx_JobRequistionStatus.Text = Convert.ToString(dt.Rows[0]["JOBREQ_APPROVALSTATUS"]);
    ////            //rdtx_JobRequistionStatus.Enabled = false;
    ////            rcmb_RecruitmentFor.SelectedIndex = rcmb_RecruitmentFor.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["JOBREQ_RECRUITMENTFOR"])); //inserted by sudha 26th july 2013
    ////            //rlst_interviewerra
    ////            //lbl_ActualDate


    ////            //rdtp_ActualClosedDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["JOBREQ_ACTUALCLOSEDDATE"]);
    ////            //     rcmb_Status.SelectedItem.Text = Convert.ToString((Convert.ToString(dt.Rows[0]["JOBREQ_STATUS"])));
    ////            LoadBusinessUnit();
    ////            rcmb_BU.SelectedIndex = rcmb_BU.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["JOBREQ_BUSINESSUNIT_ID"]));
    ////            int bu_id = Convert.ToInt32(dt.Rows[0]["JOBREQ_BUSINESSUNIT_ID"]);
    ////            //  Load_raisedby(bu_id);
    ////            LoadEmployee();
    ////            rcmb_RaisedBy.SelectedIndex = rcmb_RaisedBy.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["JOBREQ_RAISEDBY"]));
    ////            hdn_RaisedBy.Value = Convert.ToString(dt.Rows[0]["JOBREQ_RAISEDBY"]);
    ////            LoadDepartment();
    ////            //rcmb_dept_interviewer.SelectedIndex = rcmb_dept_interviewer.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["JOBREQ_INTERVIEWER"]));
    ////            rcmb_Department.SelectedIndex = rcmb_Department.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["JOBREQ_DEPARTMENT"]));
    ////            rcmb_interviewer.SelectedIndex = rcmb_interviewer.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["JOBREQ_INTERVIEWER"]));
    ////            LoadCombos();
    ////            LoadDropDowns();
    ////            rcmb_Designation.SelectedIndex = rcmb_Designation.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["JOBREQ_DESIGNATION"]));
    ////            RNT_Openings.Text = Convert.ToString(dt.Rows[0]["JOBREQ_POSITIONS"]);
    ////            RNT_Experience.Text = Convert.ToString(dt.Rows[0]["JOBREQ_EXPYEARS"]);
    ////            rcmb_Qualification.SelectedIndex = rcmb_Qualification.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["JOBREQ_QUALIFICATION"]));
    ////            chk_IsQualificationReQ.Checked = Convert.ToBoolean(dt.Rows[0]["JOBREQ_ISQUALREQ"]);
    ////            chk_IsExperienceReq.Checked = Convert.ToBoolean(dt.Rows[0]["JOBREQ_ISYEARSREQ"]);
    ////            //   RNT_Percentage.Text = Convert.ToString(dt.Rows[0]["JOBREQ_PERCENTAGE"]);
    ////            LoadCurrSymbol();
    ////            RNT_Appctc.Text = Convert.ToString(dt.Rows[0]["JOBREQ_APPCTC"]);
    ////            rtxt_Comments.Text = Convert.ToString(dt.Rows[0]["JOBREQ_COMMENTS"]);

    ////            //     rcmb_req_for.SelectedIndex=rcmb_req_for.FindItemIndexByText(Convert.ToString(dt.Rows[0]["JOBREQ_REQFOR"]));
    ////            rcmb_reqto_work.SelectedIndex = rcmb_reqto_work.FindItemIndexByText(Convert.ToString(dt.Rows[0]["JOBREQ_REQTOWORK"]));
    ////            rcmb_Grade.SelectedIndex = rcmb_Grade.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["JOBREQ_GRADE"]));
    ////            rcmb_Emptype.SelectedIndex = rcmb_Emptype.FindItemIndexByText(Convert.ToString(dt.Rows[0]["JOBREQ_EMPTYPE"]));
    ////            rtxt_location.Text = Convert.ToString(dt.Rows[0]["JOBREQ_LOCATION"]);
    ////            //   rcmb_RecruitmentFor.SelectedIndex = rcmb_RecruitmentFor.FindItemIndexByText(Convert.ToString(dt.Rows[0]["JOBREQ_RECRUITMENTFOR"]));
    ////            //if (dt.Rows[0]["JOBREQ_PRIORITY"] != System.DBNull.Value)
    ////            //    rcmb_Priority.SelectedIndex = rcmb_Priority.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["JOBREQ_PRIORITY"]));

    ////            SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
    ////            _obj_smhr_emp_payitems.OPERATION = operation.Empty;
    ////            _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
    ////            _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    ////            DataTable DT_Details = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
    ////            if (dt_Details.Rows.Count > 0)
    ////            {
    ////                rcmb_interviewer.DataSource = DT_Details;

    ////                rcmb_interviewer.DataTextField = "EMPNAME";
    ////                rcmb_interviewer.DataValueField = "EMP_ID";
    ////                rcmb_interviewer.DataBind();
    ////                rcmb_interviewer.Items.Insert(0, new RadComboBoxItem("Select"));

    ////                rlst_interviewer.Items.Clear();
    ////                string str = Convert.ToString(dt.Rows[0]["JOBREQ_INTERVIEWER"]);
    ////                foreach (string item in str.Split(new char[] { ',' }))
    ////                {
    ////                    if (item != "" && rcmb_interviewer.FindItemByValue(item) != null)
    ////                    {
    ////                        rlst_interviewer.Items.Add(new Telerik.Web.UI.RadListBoxItem(rcmb_interviewer.FindItemByValue(item).Text, rcmb_interviewer.FindItemByValue(item).Value));
    ////                    }
    ////                }
    ////            }

    ////            _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
    ////            _obj_Rec_JobRequisition.MODE = 5;
    ////            _obj_Rec_JobRequisition.JOBREQ_ID = Convert.ToInt32(lbl_JRID.Text);
    ////            DataTable dt_skillid = Recruitment_BLL.get_JobRequisition(_obj_Rec_JobRequisition);
    ////            if (dt_skillid.Rows.Count > 0)
    ////            {
    ////                for (int a = 0; a <= rlb_SkillReq.Items.Count - 1; a++)
    ////                {
    ////                    for (int b = 0; b <= dt_skillid.Rows.Count - 1; b++)
    ////                    {
    ////                        if (dt_skillid.Rows[b]["SKILL_ID"] != System.DBNull.Value)
    ////                        {
    ////                            if (rlb_SkillReq.Items[a].Value == Convert.ToString(dt_skillid.Rows[b]["SKILL_ID"]))
    ////                            {
    ////                                rlb_SkillReq.Items[a].Checked = true; ;// = Convert.ToBoolean(dt_skillid.Rows[b]["SKILL_ID"]);
    ////                            }
    ////                        }
    ////                    }
    ////                }
    ////            }
    ////            if (Convert.ToString(dt.Rows[0]["JOBREQ_APPROVALSTATUS"]) == "PENDING")
    ////            {
    ////                //btn_Update.Visible = true;
    ////                ViewState["PRIORITY"] = 0;
    ////                tr_Priority.Visible = false;
    ////                RFV_rcmb_Priority.Enabled = false;
    ////            }
    ////            else if (Convert.ToString(dt.Rows[0]["JOBREQ_APPROVALSTATUS"]) == "REJECTED")
    ////            {
    ////                ViewState["PRIORITY"] = 0;
    ////                //btn_Update.Visible = false;
    ////                tr_Priority.Visible = false;
    ////                RFV_rcmb_Priority.Enabled = false;
    ////                BLL.ShowMessage(this, "Resource Requisition is Rejected.You Can Not Update.");
    ////            }
    ////            else
    ////            {
    ////                //if (dt.Rows[0]["JOBREQ_PRIORITY"] == System.DBNull.Value)
    ////                if (Convert.ToString(dt.Rows[0]["JOBREQ_STATUS"]).ToUpper().Trim() == "CLOSED")
    ////                {
    ////                    ViewState["PRIORITY"] = 0;
    ////                    BLL.ShowMessage(this, "Resource Requisition Is Closed.You Can Not Update.");
    ////                    //btn_Update.Visible = false;
    ////                    tr_Priority.Visible = false;
    ////                    RFV_rcmb_Priority.Enabled = false;
    ////                }
    ////                else
    ////                {
    ////                    ViewState["PRIORITY"] = 1;
    ////                    BLL.ShowMessage(this, "Resource Requisition is Approved.You Can Update Only Priority.");
    ////                    //btn_Update.Visible = true;
    ////                    tr_Priority.Visible = true;
    ////                    RFV_rcmb_Priority.Enabled = true;
    ////                }
    ////            }
    ////            if (Request.QueryString["Buttons"] != null)
    ////            {
    ////                if (Convert.ToString(Request.QueryString["Buttons"]) == "0")
    ////                {
    ////                    btn_Update.Visible = false;
    ////                    btn_Cancel.Visible = false;
    ////                }
    ////            }

    ////            btn_Save.Visible = false;
    ////            Rm_JobRequisition_page.SelectedIndex = 1;

    ////            //track = "edit";
    ////            //pnl_multipage2.Visible = true;
    ////            //RM_Skills .SelectedIndex =0;
    ////            //lbl_id.Text = Convert.ToString(lbl_JRID.Text);
    ////            //int param_jrid = Convert.ToInt32(lbl_JRID.Text);
    ////            //LoadGridskills(param_jrid);
    ////        }
    ////    }
    ////    catch (Exception ex)
    ////    {
    ////        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_JobRequisitionApproval", ex.StackTrace, DateTime.Now);
    ////        Response.Redirect("~/Frm_ErrorPage.aspx");
    ////    }
    ////}     

    //protected void clearControls()
    //{

    //    rtxt_JRCode.Text = string.Empty;
    //    rtxt_Desc.Text = string.Empty;
    //    rdtp_ExpectedDate.Clear();
    //    rcmb_RaisedBy.Items.Clear();
    //    rcmb_RaisedBy.ClearSelection();
    //    //  rcmb_RecruitmentFor.Items.Clear();
    //    rcmb_RecruitmentFor.ClearSelection();
    //    rcmb_BU.ClearSelection();
    //    rcmb_Department.ClearSelection();
    //    rcmb_Designation.ClearSelection();
    //    //   rcmb_Status.ClearSelection();
    //    RNT_Openings.Text = string.Empty;
    //    RNT_Experience.Text = string.Empty;
    //    chk_IsExperienceReq.Checked = false;
    //    rcmb_Qualification.Items.Clear();
    //    //  RNT_Percentage.Text = string.Empty;
    //    RNT_Appctc.Text = string.Empty;
    //    chk_IsQualificationReQ.Checked = false;
    //    //pnl_multipage2.Visible = false;
    //    rtxt_Comments.Text = string.Empty;
    //    rdtp_ActualClosedDate.Clear();
    //    rlb_SkillReq.ClearChecked();

    //    //    rcmb_req_for.ClearSelection();
    //    rcmb_reqto_work.ClearSelection();
    //    rcmb_Grade.ClearSelection();
    //    rcmb_interviewer.Items.Clear();
    //    rcmb_interviewer.ClearSelection();
    //    rcmb_dept_interviewer.ClearSelection();
    //    rcmb_Emptype.ClearSelection();
    //    rlst_interviewer.Items.Clear();
    //    rtxt_location.Text = string.Empty;
    //    //  rcmb_RecruitmentFor.SelectedIndex = 0;
    //    rdtp_ExpectedDate.MinDate = Convert.ToDateTime("01-01-1900");
    //    tr_Priority.Visible = false;
    //    RFV_rcmb_Priority.Enabled = false;
    //    rcmb_Priority.SelectedIndex = 0;
    //}

    //protected void btn_Cancel_Click(object sender, EventArgs e)
    //{
    //    if (Request.QueryString["JOBREQ_ID"] != null)
    //        Response.Redirect("~/Approval/frm_JobRequisitionApproval.aspx", false);
    //    else
    //        Rm_JobRequisition_page.SelectedIndex = 0;
    //    clearControls();
    //}
    //protected void rlst_interviewer_Deleted(object sender, RadListBoxEventArgs e)
    //{
    //    rcmb_dept_interviewer_SelectedIndexChanged(null, null);
    //}
    //protected void btn_AddInterviewer_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (rcmb_interviewer.SelectedItem != null)
    //        {
    //            if (rcmb_interviewer.SelectedIndex > 0)
    //            {
    //                if (rlst_interviewer.Items.Count > 0)
    //                {
    //                    foreach (RadListBoxItem item in rlst_interviewer.Items)
    //                    {
    //                        if (rcmb_interviewer.SelectedItem.Value == item.Value)
    //                        {
    //                            Recruitment_BLL.ShowMessage(this, "Selected Interviewer Is Already Assigned");
    //                            rcmb_interviewer.SelectedIndex = 0;
    //                            return;
    //                        }
    //                    }
    //                }
    //                rlst_interviewer.Items.Add(new Telerik.Web.UI.RadListBoxItem(rcmb_interviewer.SelectedItem.Text, rcmb_interviewer.SelectedItem.Value));
    //                rcmb_dept_interviewer_SelectedIndexChanged(null, null);
    //            }
    //            else
    //            {
    //                Recruitment_BLL.ShowMessage(this, "Please select Interviewer Name");
    //                return;
    //            }

    //        }
    //        else
    //        {
    //            Recruitment_BLL.ShowMessage(this, "Please select Interviewer Name");
    //            return;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Users", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}



    //#endregion

    #region Added From JobRequisition
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            rcmb_BU.Enabled = false;
            rtxt_JRCode.Enabled = false;
            rcmb_Status.Enabled = true;
            rtxt_Desc.Enabled = false;
            rcmb_Directorate.Enabled = false;
            rcmb_financialPeriod.Enabled = false;
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
                //if (Reject_status == "REJECTED")
                ////if (Reject_status == 3)
                //{
                EnableDisableControls(false);
                //    btn_Update.Enabled = false;
                //}
                //else if (Reject_status == "APPROVED1")
                //{
                //    EnableDisableControls(false);
                //    btn_Update.Enabled = false;
                //}
                //else if (Reject_status == "APPROVED2")
                //{
                //    EnableDisableControls(false);
                //    btn_Update.Enabled = false;
                //}
                //else if (Reject_status == "APPROVED3")
                //{
                //    EnableDisableControls(false);
                //    btn_Update.Enabled = false;
                //}
                //else
                //{
                //    EnableDisableControls(true);
                //    btn_Update.Enabled = true;
                //}
                lbl_JRID.Text = Convert.ToString(dt.Rows[0]["JOBREQ_ID"]);
                rtxt_JRCode.Text = Convert.ToString(dt.Rows[0]["JOBREQ_REQCODE"]);
                rtxt_Desc.Text = Convert.ToString(dt.Rows[0]["JOBREQ_REQNAME"]);
                rdtp_ExpectedDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["JOBREQ_REQEXPIRY"]);
                if ((dt.Rows[0]["JOBREQ_ACTUALCLOSEDDATE"]) != null && (dt.Rows[0]["JOBREQ_ACTUALCLOSEDDATE"]) != System.DBNull.Value)
                {
                    rdtp_ActualClosedDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["JOBREQ_ACTUALCLOSEDDATE"]);
                }
                //rcmb_Status.SelectedItem.Text = Convert.ToString((Convert.ToString(dt.Rows[0]["JOBREQ_STATUS"])));

                rcmb_Status.SelectedIndex = rcmb_Status.FindItemIndexByText(Convert.ToString((Convert.ToString(dt.Rows[0]["JOBREQ_STATUS"]))));
                rcmb_Status.Enabled = false;
                LoadBusinessUnit();
                LoadPeriod(); //to load period
                LoadPositions();    //To load positions based on Organisation_ID
                //loadQualSkills();     //To load Qualifications, Grades/Scales, Skills
                LoadEmployeeType();    //To load employee types
                LoadAssignedInterviewers(dt); //To load assigned Interviewers


                rcmb_BU.SelectedIndex = rcmb_BU.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["JOBREQ_BUSINESSUNIT_ID"]));
                int bu_id = Convert.ToInt32(dt.Rows[0]["JOBREQ_BUSINESSUNIT_ID"]);
                //  Load_raisedby(bu_id);
                LoadEmployee();
                rcmb_RaisedBy.SelectedIndex = rcmb_RaisedBy.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["JOBREQ_RAISEDBY"]));
                rcmb_RaisedBy_SelectedIndexChanged(null, null);
                //LoadDepartment();
                rcmb_Department.SelectedIndex = rcmb_Department.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["JOBREQ_DEPARTMENT"]));
                //LoadCombos();
                //LoadDropDowns();
                //load period
                rcmb_financialPeriod.SelectedIndex = rcmb_financialPeriod.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["JOBREQ_PERIOD_ID"]));
                rcmb_Designation.SelectedIndex = rcmb_Designation.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["JOBREQ_DESIGNATION"]));
                if (rcmb_Designation.SelectedValue != "")
                {
                    rcmb_Designation_SelectedIndexChanged(null, null);  //To fill grades/scales and slabs based on selected position
                }
                RNT_Openings.Text = Convert.ToString(dt.Rows[0]["JOBREQ_POSITIONS"]);
                RNT_Experience.Text = Convert.ToString(dt.Rows[0]["JOBREQ_EXPYEARS"]);
                //rcmb_Qualification.SelectedIndex = rcmb_Qualification.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["JOBREQ_QUALIFICATION"]));
                //chk_IsQualificationReQ.Checked = Convert.ToBoolean(dt.Rows[0]["JOBREQ_ISQUALREQ"]);
                chk_IsExperienceReq.Checked = Convert.ToBoolean(dt.Rows[0]["JOBREQ_ISYEARSREQ"]);
                RNT_Percentage.Text = Convert.ToString(dt.Rows[0]["JOBREQ_PERCENTAGE"]);
                //LoadCurrSymbol();
                //RNT_Appctc.Text = Convert.ToString(dt.Rows[0]["JOBREQ_APPCTC"]);
                //rtxt_Comments.Text = Convert.ToString(dt.Rows[0]["JOBREQ_COMMENTS"]);

                //rtxt_Commentss.Text = "Sample comments";
                rtxt_Comments.Text = Convert.ToString(dt.Rows[0]["JOBREQ_COMMENTS"]);

                SMHR_EMPLOYEEGRADE _obj_Emp_Grade = new SMHR_EMPLOYEEGRADE();

                _obj_Emp_Grade.OPERATION = operation.EmployeeGrade;
                _obj_Emp_Grade.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

                DataTable dtGrades = BLL.GetEmployeeGrade(_obj_Emp_Grade);

                if (dtGrades.Rows.Count > 0)
                {
                    rcmb_Grade.DataSource = dtGrades;
                    rcmb_Grade.DataTextField = "EMPLOYEEGRADE_CODE";
                    rcmb_Grade.DataValueField = "EMPLOYEEGRADE_ID";
                    rcmb_Grade.DataBind();
                    rcmb_Grade.Items.Insert(0, new RadComboBoxItem("Select"));
                    rcmb_Grade.Enabled = false;

                    rcmb_Grade.SelectedIndex = rcmb_Grade.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["JOBREQ_GRADE"]));

                    DataTable dtSlabs = BLL.GetEmployeeGradeSlab(Convert.ToInt32(dt.Rows[0]["JOBREQ_APPCTC"]));

                    if (dtSlabs.Rows.Count > 0)
                        rtbGrade.Text = Convert.ToString(dtSlabs.Rows[0]["EMPLOYEEGRADE_SLAB_SRNO"]) + " ( " + Convert.ToString(dtSlabs.Rows[0]["EMPLOYEEGRADE_SLAB_AMOUNT"]) + " )";
                    else
                        rtbGrade.Text = string.Empty;

                    /*rcmb_Slab.DataValueField = "EMPLOYEEGRADE_SLAB_ID";
                    rcmb_Slab.DataTextField = "EMPLOYEEGRADE_SLAB_AMOUNT";
                    rcmb_Slab.DataSource = LoadSalarySlabs();
                    rcmb_Slab.DataBind();
                    rcmb_Slab.Items.Insert(0, new RadComboBoxItem { Text = "Select", Value = "0" });

                    rcmb_Slab.SelectedIndex = rcmb_Slab.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["JOBREQ_APPCTC"]));*/
                }

                //rcmb_req_for.SelectedIndex = rcmb_req_for.FindItemIndexByText(Convert.ToString(dt.Rows[0]["JOBREQ_REQFOR"]));
                //rcmb_reqto_work.SelectedIndex=rcmb_reqto_work.FindItemIndexByText(Convert.ToString(dt.Rows[0]["JOBREQ_REQTOWORK"]));

                //rcmb_Slab.DataValueField = "EMPLOYEEGRADE_SLAB_ID";
                //rcmb_Slab.DataTextField = "EMPLOYEEGRADE_SLAB_AMOUNT";
                //rcmb_Slab.DataSource = LoadSalarySlabs();
                //rcmb_Slab.DataBind();
                //rcmb_Slab.Items.Insert(0, new RadComboBoxItem { Text = "Select", Value = "0" });


                //rcmb_Emptype.SelectedIndex = rcmb_Emptype.FindItemIndexByText(Convert.ToString(dt.Rows[0]["JOBREQ_EMPTYPE"]));
                rcmb_Emptype.SelectedIndex = rcmb_Emptype.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["JOBREQ_EMPTYPE"]));
                //rtxt_location.Text = Convert.ToString(dt.Rows[0]["JOBREQ_LOCATION"]);
                //rcmb_RecruitmentFor.SelectedIndex = rcmb_RecruitmentFor.FindItemIndexByText(Convert.ToString(dt.Rows[0]["JOBREQ_RECRUITMENTFOR"]));

                //SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
                //_obj_smhr_emp_payitems.OPERATION = operation.Empty;
                //_obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
                //_obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //DataTable DT_Details = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
                //if (dt_Details.Rows.Count > 0)
                //{
                //    //rcmb_interviewer.DataSource = DT_Details;
                //    //rcmb_interviewer.DataTextField = "EMPNAME";
                //    //rcmb_interviewer.DataValueField = "EMP_ID";
                //    //rcmb_interviewer.DataBind();
                //    //rcmb_interviewer.Items.Insert(0, new RadComboBoxItem("Select"));

                //    rlst_interviewer.Items.Clear();
                //    string str = Convert.ToString(dt.Rows[0]["JOBREQ_INTERVIEWER"]);
                //    foreach (string item in str.Split(new char[] { ',' }))
                //    {
                //        //if (item != "")
                //            //rlst_interviewer.Items.Add(new Telerik.Web.UI.RadListBoxItem(rcmb_interviewer.FindItemByValue(item).Text, rcmb_interviewer.FindItemByValue(item).Value));
                //    }
                //}

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
                //if (Convert.ToString(dt.Rows[0]["JOBREQ_APPROVALSTATUS"]) == "PENDING")
                //    //btn_Update.Visible = true;
                //else if (Convert.ToString(dt.Rows[0]["JOBREQ_APPROVALSTATUS"]) == "REJECTED")
                //{
                //    BLL.ShowMessage(this, "Job Requisition is Rejected.You can not edit.");
                //    //btn_Update.Visible = false;
                //}
                //else
                //{
                //    BLL.ShowMessage(this, "Job Requisition is Approved.You can not edit.");
                //    //btn_Update.Visible = false;
                //}

                //btn_Save.Visible = false;
                Rm_JobRequisition_page.SelectedIndex = 0;

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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ViewJobReq", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

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
                SMHR_LOGININFO obj_smhr_logininfo = new SMHR_LOGININFO();
                //FOR SELF EMPLOYEE and MANAGER
                // Loading Business Unit 
                rcmb_BU.Items.Clear();
                _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
                //_obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //_obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                //DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
                obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                obj_smhr_logininfo.OPERATION = operation.Select;
                DataTable dt_BUDetails = BLL.get_Sup_BusinessUnit(obj_smhr_logininfo);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ViewJobReq", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ViewJobReq", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
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

            //rcmb_interviewer.DataSource = DT_Details;
            //rcmb_interviewer.DataTextField = "EMPNAME";
            //rcmb_interviewer.DataValueField = "EMP_ID";
            //rcmb_interviewer.DataBind();
            //rcmb_interviewer.Items.Insert(0, new RadComboBoxItem("Select/Enter Name"));


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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ViewJobReq", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void LoadPositions()
    {
        try
        {
            if (Session["ORG_ID"] != "")
            {
                if (rcmb_BU.SelectedIndex > 0)
                {
                    SMHR_POSITIONS _obj_smhr_positions = new SMHR_POSITIONS();
                    _obj_smhr_positions.OPERATION = operation.Select;
                    _obj_smhr_positions.JOBLOC_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BU.SelectedValue);
                    _obj_smhr_positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtPos = BLL.get_BUPositions(_obj_smhr_positions);
                    rcmb_Designation.DataSource = dtPos;
                    rcmb_Designation.DataTextField = "POSITIONS_CODE";
                    rcmb_Designation.DataValueField = "POSITIONS_ID";
                    rcmb_Designation.DataBind();
                    rcmb_Designation.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

                    //SMHR_EMPTRANSFER _obj_Emptransfer = new SMHR_EMPTRANSFER();
                    //DataTable Dt_loadcombos = new DataTable();

                    //_obj_Emptransfer.EMP_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    //Dt_loadcombos = BLL.get_businessunitdetails(_obj_Emptransfer);
                    //rcmb_Designation.Items.Clear();
                    //if (Dt_loadcombos.Rows.Count > 0)
                    //{
                    //    rcmb_Designation.DataSource = Dt_loadcombos;
                    //    rcmb_Designation.DataTextField = "POSITIONS_CODE";
                    //    rcmb_Designation.DataValueField = "POSITIONS_ID";
                    //    rcmb_Designation.DataBind();
                    //    rcmb_Designation.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                    //    Dt_loadcombos = null;
                    //    _obj_Emptransfer = null;
                }
                else
                {
                    BLL.ShowMessage(this, "Please Select Business Unit");
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ViewJobReq", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
        //else
        //{
        //    rcmb_BU.Items.Clear();
        //    rcmb_BU.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        //}
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ViewJobReq", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ViewJobReq", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void rcmb_Designation_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rcmb_Grade.Items.Clear();
            rcmb_Grade.Text = string.Empty;
            //rcmb_Slab.Items.Clear();
            //rcmb_Slab.Text = string.Empty;
            rtbGrade.Text = string.Empty;
            lblSkills.Text = string.Empty;
            lblQualifications.Text = string.Empty;
            RNT_Openings.Text = string.Empty;
            if (rcmb_Designation.SelectedIndex > 0)
            {
                //To check for vacancy
                SMHR_POSITIONS _obj_smhr_positions = new SMHR_POSITIONS();
                _obj_smhr_positions.OPERATION = operation.GETVACANCY;
                _obj_smhr_positions.POSITIONS_ID = Convert.ToInt32(rcmb_Designation.SelectedValue);
                _obj_smhr_positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_smhr_positions.POSITIN_PERIOD_ID = Convert.ToInt32(rcmb_financialPeriod.SelectedValue);
                DataTable dtVacancy = BLL.get_Positions(_obj_smhr_positions);
                if (Convert.ToInt32(dtVacancy.Rows[0][0]) == 0)
                {
                    rcmb_Designation.ClearSelection();
                    //ddl_Grade.Items.Clear();
                    BLL.ShowMessage(this, "Establishment not done for this position");
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
                    objEmpPositions.POSITIN_PERIOD_ID = Convert.ToInt32(rcmb_financialPeriod.SelectedValue);
                    objEmpPositions.OPERATION = operation.Select;
                    int VacancyCount = Recruitment_BLL.GetEmpVacancyCount(objEmpPositions);
                    if (VacancyCount > 0)
                    {
                        RNT_Openings.Text = VacancyCount.ToString();
                    }

                    //To fetch Grades/Scales based on Position
                    rcmb_Grade.Items.Clear();
                    rcmb_Grade.Text = string.Empty;
                    //rcmb_Slab.Items.Clear();
                    //rcmb_Slab.Text = string.Empty;
                    rtbGrade.Text = string.Empty;
                    SMHR_POSITIONS _objGradesByPos = new SMHR_POSITIONS();
                    _objGradesByPos.OPERATION = operation.POSITIONSGRADE;
                    _objGradesByPos.POSITIONS_ID = Convert.ToInt32(rcmb_Designation.SelectedValue);
                    _objGradesByPos.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtGrades = BLL.get_Positions(_objGradesByPos);
                    if (dtGrades.Rows.Count > 0)
                    {
                        rcmb_Grade.DataSource = dtGrades;

                        //rcmb_Grade.DataTextField = "CODERANK";
                        //rcmb_Grade.DataValueField = "EMPLOYEEGRADE_ID";
                        rcmb_Grade.DataTextField = "JOBS_ID";
                        rcmb_Grade.DataValueField = "JOBS_CODE";
                        rcmb_Grade.DataBind();
                        rcmb_Grade.Enabled = false;

                        /*rcmb_Slab.DataValueField = "EMPLOYEEGRADE_SLAB_ID";
                        rcmb_Slab.DataTextField = "EMPLOYEEGRADE_SLAB_AMOUNT";
                        rcmb_Slab.DataSource = LoadSalarySlabs();
                        rcmb_Slab.DataBind();
                        rcmb_Slab.Items.Insert(0, new RadComboBoxItem { Text = "Select", Value = "0" });*/
                    }

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


            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ViewJobReq", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ViewJobReq", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            
        }
        return ds.Tables[0];
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
            //rcmb_interviewer.Enabled = flag;
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
            //rcmb_Slab.Enabled = flag;
            rtbGrade.Enabled = flag;
            rcmb_Emptype.Enabled = flag;
            rtxt_Comments.Enabled = flag;
            rdtp_ActualClosedDate.Enabled = flag;
            //btn_Update.Enabled = flag;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ViewJobReq", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    #endregion

}
