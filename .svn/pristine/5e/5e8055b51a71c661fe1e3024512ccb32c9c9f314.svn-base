using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Data;
using Telerik.Web.UI;

public partial class HR_frm_Identification : System.Web.UI.Page
{
    SMHR_IDENTIFICATION _obj_smhr_identification;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_MASTERS _obj_Smhr_Masters;
    static int Mode = 0;
    static string _lbl_ID = "";
    string Control;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Control = Convert.ToString(Request.QueryString["Control"]);
            if (!Page.IsPostBack)
            {
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();
                if (Control != null)
                {
                    if (Control.ToUpper() == "SELFIDENTIFICATION")
                    {
                        _obj_Smhr_LoginInfo.LOGIN_ID = 12;
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Employee Identification Details");//EMPLOYEE IDENTIFICATION");
                    }
                }
                else
                {
                    _obj_Smhr_LoginInfo.LOGIN_ID = 2;
                    _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Employee Identification Details");//EMPLOYEE IDENTIFICATION");
                }
                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //_obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("EMPLOYEE IDENTIFICATION");
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
                    RG_Identification.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Submit.Visible = false;                    
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

                ClearFields();
                RG_Identification.Visible = false;
                Mode = 1;
                rtxt_IssuedOrg.Enabled = false;
                rdp_ExpiryDate.Enabled = false;
                rdp_IssueDate.Enabled = false;

                BLL.ChangeDateFormat(Convert.ToString(Session["EMP_ID"]), rdp_IssueDate, rdp_ExpiryDate);
                BLL.gridDateFormat(Convert.ToString(Session["EMP_ID"]), RG_Identification, "IDNTMASTER_ISSUEDT", "IDNTMASTER_EXPIRYDT");
                Control = Convert.ToString(Request.QueryString["Control"]);
                //if (Control != null)
                //{
                //    if (Control.ToUpper() == "SELFIDENTIFICATION")
                //    {
                //        Session["SELF"] = "SELFIDENTIFICATION";

                //    }
                //}

                LoadCombos();

                LoadEmployees();
                LoadIdentificationType();
            }
            Page.Validate();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Identification", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }
    private void LoadCombos()
    {
        //if (Control != null)
        //{
        //    if (Convert.ToInt32(Session["EMP_ID"]) != 0)
        //    {
        //if (Convert.ToString(Session["SELF"]) == "SELFIDENTIFICATION")
        try
        {
            if (Control != null)
            {
                if ((Convert.ToString(Session["SELFSERVICE"]) == "true" && Control.ToUpper() == "SELFIDENTIFICATION") || (Convert.ToString(Session["SELFSERVICE"]) == "" && Control.ToUpper() == "SELFIDENTIFICATION"))
                {
                    rcb_BusinessUnit.Items.Clear();
                    _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
                    _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                    DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
                    rcb_BusinessUnit.DataSource = dt_BUDetails;
                    rcb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
                    rcb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
                    rcb_BusinessUnit.DataBind();

                    rcb_Employee.Items.Clear();
                    SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
                    _obj_smhr_emp_payitems.OPERATION = operation.Self;
                    _obj_smhr_emp_payitems.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                    _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable DT_SELF = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
                    rcb_BusinessUnit.SelectedIndex = rcb_BusinessUnit.FindItemIndexByValue(DT_SELF.Rows[0]["EMP_BUSINESSUNIT_ID"].ToString());
                    LoadEmployees();
                    rcb_Employee.SelectedIndex = rcb_Employee.FindItemIndexByValue(DT_SELF.Rows[0]["EMP_ID"].ToString());
                    rcb_BusinessUnit.Enabled = false;
                    rcb_Employee.Enabled = false;
                    LoadData();
                    btn_Submit.Visible = false;
                    btn_Cancel.Visible = false;
                    RG_Identification.Visible = true;
                    LoadData();
                }
                else
                {
                    BLL.ShowMessage(this, "You do not have Accecc on this Screen!");
                    return;
                }
            }

    //    }
            //}
            else
            {
                rcb_BusinessUnit.Items.Clear();
                _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
                _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
                rcb_BusinessUnit.DataSource = dt_BUDetails;
                rcb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
                rcb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
                rcb_BusinessUnit.DataBind();
                rcb_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));
                rcb_BusinessUnit.SelectedIndex = -1;
                btn_Submit.Visible = true;
                btn_Cancel.Visible = true;
                rcb_BusinessUnit.Enabled = true;
                rcb_Employee.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Identification", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

    }
    private void LoadData()
    {
        try
        {
            rcb_Type.Items.Clear();
            rcb_Type.Text = string.Empty;
            LoadIdentificationType();
            rcb_Type.SelectedIndex = 0;
           rdp_ExpiryDate.SelectedDate = null;
            rdp_IssueDate.SelectedDate = null;
            rtb_Code.Text = string.Empty;
            rtxt_IssuedOrg.Text = string.Empty;
            rtxt_Name.Text = string.Empty;
            rcb_Type.Enabled = true;
            rtb_Code.Enabled = true;
            rtxt_IssuedOrg.Enabled = true;
            _obj_smhr_identification = new SMHR_IDENTIFICATION();
            _obj_smhr_identification.OPERATION = operation.Check;
            //if (Convert.ToString(Session["SELF"]) == "SELF_IDENTIFICATION")
            if (Control != null)
            {
                if ((Convert.ToString(Session["SELFSERVICE"]) == "true" && Control.ToUpper() == "SELFIDENTIFICATION") || (Convert.ToString(Session["SELFSERVICE"]) == "" && Control.ToUpper() == "SELFIDENTIFICATION"))
                {
                    _obj_smhr_identification.IDNTMASTER_EMPID = Convert.ToInt32(Session["EMP_ID"]);
                }
            }
            else
            {
                _obj_smhr_identification.IDNTMASTER_EMPID = Convert.ToInt32(rcb_Employee.SelectedItem.Value);
            }
            _obj_smhr_identification.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_IdentityDetails(_obj_smhr_identification);
            if (dt.Rows.Count != 0)
            {
                lbl_Message.Visible = false;
                RG_Identification.Visible = true;
                RG_Identification.DataSource = dt;
                RG_Identification.DataBind();
            }
            else
            {
                lbl_Message.Visible = true;
                RG_Identification.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Identification", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void rcb_Employee_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcb_Employee.SelectedIndex > 0)
            {
                LoadData();
            }
            else
            {
                rcb_Type.Items.Clear();
                rcb_Type.Text = string.Empty;
                LoadIdentificationType();
                rcb_Type.SelectedIndex = 0;
                rdp_ExpiryDate.SelectedDate = null;
                rdp_IssueDate.SelectedDate = null;
                rtb_Code.Text = string.Empty;
                rtxt_IssuedOrg.Text = string.Empty;
                rtxt_Name.Text = string.Empty;
                rcb_Type.Enabled = true;
                rtb_Code.Enabled = true;
                rtxt_IssuedOrg.Enabled = true;
                lbl_Message.Visible = false;
                RG_Identification.Visible = false;

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Identification", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    private void ClearFields()
    {
        try
        {
            rcb_Type.SelectedIndex = 0;
            rdp_ExpiryDate.SelectedDate = null;
            rdp_IssueDate.SelectedDate = null;
            rtb_Code.Text = string.Empty;
            rtxt_IssuedOrg.Text = string.Empty;
            rtxt_Name.Text = string.Empty;
            //rcb_BusinessUnit.SelectedIndex = 0;
            rcb_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Identification", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void LoadIdentificationType()
    {
        try
        {
            _obj_Smhr_Masters = new SMHR_MASTERS();
            _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_Smhr_Masters.OPERATION = operation.Select;
            //  _obj_Smhr_Masters.MASTER_TYPE = "GRADESET"; 
            _obj_Smhr_Masters.MASTER_TYPE = "IDENTIFICATIONTYPE";
            DataTable dt_Details = BLL.get_MasterRecords(_obj_Smhr_Masters);
            rcb_Type.DataSource = dt_Details;
            rcb_Type.DataTextField = "HR_MASTER_CODE";
            rcb_Type.DataValueField = "HR_MASTER_ID";
            rcb_Type.DataBind();
            rcb_Type.Items.Insert(0, new RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Identification", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            ClearFields();
            rcb_Type.Enabled = true;
            rtb_Code.Enabled = true;
            rcb_Employee.SelectedIndex = -1;
            rcb_BusinessUnit.Enabled = true;
            rcb_Employee.Enabled = true;
            RG_Identification.Visible = false;
            lbl_Message.Visible = false;
            Response.Redirect("~/Masters/Default.aspx", false);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Identification", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            if ((rcb_Employee.SelectedIndex > 0) && (rcb_BusinessUnit.SelectedIndex > 0))
            {
                SMHR_EMPLOYEE _obj_smhr_employee = new SMHR_EMPLOYEE();
                _obj_smhr_employee.OPERATION = operation.Select;
                _obj_smhr_employee.EMP_ID = Convert.ToInt32(rcb_Employee.SelectedItem.Value);
                //dt_Details = new DataTable();
                _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_Details = BLL.get_Employee(_obj_smhr_employee);
                if (Convert.ToInt32(dt_Details.Rows[0]["EMP_STATUS"]) == 1)
                {
                    BLL.ShowMessage(this, "Employee is Resigned.You can not Submit the record.");
                    return;
                }
                else if (Convert.ToInt32(dt_Details.Rows[0]["EMP_STATUS"]) == 2)
                {
                    BLL.ShowMessage(this, "Employee is Relieved.You can not Submit the record.");
                    return;
                }
                else if (Convert.ToInt32(dt_Details.Rows[0]["EMP_STATUS"]) == 3)
                {
                    BLL.ShowMessage(this, "Employee is Rehired.You can not Submit the record.");
                    return;
                }
                else
                {
                    if (Mode == 1)
                    {
                        _obj_smhr_identification = new SMHR_IDENTIFICATION();
                        _obj_smhr_identification.OPERATION = operation.Insert;
                        _obj_smhr_identification.IDNTMASTER_EMPID = Convert.ToInt32(rcb_Employee.SelectedItem.Value);
                        _obj_smhr_identification.IDNTMASTER_CODE = Convert.ToString(rtb_Code.Text);
                        _obj_smhr_identification.IDNTMASTER_NAME = Convert.ToString(rtxt_Name.Text);
                        _obj_smhr_identification.IDNTMASTER_TYPE = Convert.ToString(rcb_Type.SelectedItem.Text);
                        if (rdp_IssueDate.SelectedDate.HasValue)
                            _obj_smhr_identification.IDNTMASTER_ISSUEDT = Convert.ToDateTime(rdp_IssueDate.SelectedDate.Value);
                        else
                            _obj_smhr_identification.IDNTMASTER_ISSUEDT = null;
                        if (rdp_ExpiryDate.SelectedDate.HasValue)
                            _obj_smhr_identification.IDNTMASTER_EXPIRYDT = Convert.ToDateTime(rdp_ExpiryDate.SelectedDate.Value);
                        else
                            _obj_smhr_identification.IDNTMASTER_EXPIRYDT = null;
                        if (Convert.ToString(rtxt_IssuedOrg.Text) != "")
                            _obj_smhr_identification.IDNTMASTER_ISSUEDORG = Convert.ToString(rtxt_IssuedOrg.Text);
                        else
                            _obj_smhr_identification.IDNTMASTER_ISSUEDORG = "";
                        _obj_smhr_identification.IDNTMASTER_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_smhr_identification.IDNTMASTER_CREATEDDATE = DateTime.Now;
                        _obj_smhr_identification.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        //as user is able to add duplicate identification details this will restrict the user not to select same type
                        if (RG_Identification.Items.Count > 0)
                        {
                            for (int rows = 0; rows < RG_Identification.Items.Count; rows++)
                            {
                                if (RG_Identification.Items[rows]["IDNTMASTER_TYPE"].Text == _obj_smhr_identification.IDNTMASTER_TYPE)
                                {
                                    BLL.ShowMessage(this, "Selected Employee Has Already Submitted This Identification Type");
                                    return;
                                }
                            }
                        }
                        bool status = BLL.set_IdentityDetails(_obj_smhr_identification);
                        if (status == true)
                        {
                            BLL.ShowMessage(this, "Identity Element Inserted Successfully");
                            ClearFields();
                            LoadData();
                            Mode = 1;
                            rcb_Employee.Enabled = false;
                            rcb_BusinessUnit.Enabled = false;
                        }
                    }
                    else
                    {
                        _obj_smhr_identification = new SMHR_IDENTIFICATION();
                        _obj_smhr_identification.OPERATION = operation.Update;
                        _obj_smhr_identification.IDNTMASTER_EMPID = Convert.ToInt32(rcb_Employee.SelectedItem.Value);
                        _obj_smhr_identification.IDNTMASTER_CODE = Convert.ToString(rtb_Code.Text);
                        _obj_smhr_identification.IDNTMASTER_NAME = Convert.ToString(rtxt_Name.Text);
                        _obj_smhr_identification.IDNTMASTER_TYPE = Convert.ToString(rcb_Type.SelectedItem.Text);
                        if (rdp_IssueDate.SelectedDate.HasValue)
                            _obj_smhr_identification.IDNTMASTER_ISSUEDT = Convert.ToDateTime(rdp_IssueDate.SelectedDate.Value);
                        else
                            _obj_smhr_identification.IDNTMASTER_ISSUEDT = null;
                        if (rdp_ExpiryDate.SelectedDate.HasValue)
                            _obj_smhr_identification.IDNTMASTER_EXPIRYDT = Convert.ToDateTime(rdp_ExpiryDate.SelectedDate.Value);
                        else
                            _obj_smhr_identification.IDNTMASTER_EXPIRYDT = null;
                        if (Convert.ToString(rtxt_IssuedOrg.Text) != "")
                            _obj_smhr_identification.IDNTMASTER_ISSUEDORG = Convert.ToString(rtxt_IssuedOrg.Text);
                        else
                            _obj_smhr_identification.IDNTMASTER_ISSUEDORG = "";
                        _obj_smhr_identification.IDNTMASTER_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_smhr_identification.IDNTMASTER_LASTMDFDATE = DateTime.Now;
                        _obj_smhr_identification.IDNTMASTER_ID = Convert.ToInt32(HF_ID.Value); //Convert.ToInt32(_lbl_ID);
                        _obj_smhr_identification.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        bool status = BLL.set_IdentityDetails(_obj_smhr_identification);
                        if (status == true)
                        {
                            BLL.ShowMessage(this, "Identity Element Updated Successfully");
                            ClearFields();
                            LoadData();
                            rcb_Type.Enabled = true;
                            rtb_Code.Enabled = true;
                            Mode = 1;
                            rcb_BusinessUnit.Enabled = false;
                            rcb_Employee.Enabled = false;
                        }
                    }
                }
            }
            else
            {
                BLL.ShowMessage(this, "Select Employee");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Identification", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void lnk_Edit_Command(Object sender, CommandEventArgs e)
    {
        try
        {
            //_lbl_ID = Convert.ToString(e.CommandArgument);
            HF_ID.Value = Convert.ToString(e.CommandArgument);
            getDetails(HF_ID.Value);
            Mode = 2;
            rcb_Type.Enabled = false;
            rtb_Code.Enabled = false;
            rtxt_IssuedOrg.Enabled = false;
            rdp_ExpiryDate.Enabled = false;
            rdp_IssueDate.Enabled = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Identification", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    private void getDetails(string ID)
    {
        try
        {
            _obj_smhr_identification = new SMHR_IDENTIFICATION();
            _obj_smhr_identification.OPERATION = operation.Select;
            _obj_smhr_identification.IDNTMASTER_ID = Convert.ToInt32(ID);
            _obj_smhr_identification.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_IdentityDetails(_obj_smhr_identification);
            if (dt.Rows.Count != 0)
            {
                rcb_Employee.SelectedIndex = rcb_Employee.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["IDNTMASTER_EMPID"]));
                rtb_Code.Text = Convert.ToString(dt.Rows[0]["IDNTMASTER_CODE"]);
                rtxt_Name.Text = Convert.ToString(dt.Rows[0]["IDNTMASTER_NAME"]);
                rcb_Type.SelectedItem.Text = Convert.ToString(dt.Rows[0]["IDNTMASTER_TYPE"]);
                if (dt.Rows[0]["IDNTMASTER_ISSUEDT"] != System.DBNull.Value)
                    rdp_IssueDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["IDNTMASTER_ISSUEDT"]);
                else
                    rdp_IssueDate.SelectedDate = null;
                if (dt.Rows[0]["IDNTMASTER_EXPIRYDT"] != System.DBNull.Value)
                    rdp_ExpiryDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["IDNTMASTER_EXPIRYDT"]);
                else
                    rdp_ExpiryDate.SelectedDate = null;
                if (Convert.ToString(dt.Rows[0]["IDNTMASTER_ISSUEDORG"]) != "")
                    rtxt_IssuedOrg.Text = Convert.ToString(dt.Rows[0]["IDNTMASTER_ISSUEDORG"]);
                else
                    rtxt_IssuedOrg.Text = "";
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Identification", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

    }
    private void LoadEmployees()
    {
        try
        {
            rcb_Employee.Items.Clear();
            SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
            //_obj_smhr_emp_payitems.OPERATION = operation.Empty;
            if (rcb_BusinessUnit.SelectedItem.Value != "")
            {
                //if (Control != null)
                //{
                //if (Convert.ToString(Session["SELFSERVICE"]) == "true" && Control.ToUpper() == "SELFIDENTIFICATION")
                //{
                //    //FOR MANAGER
                //    _obj_smhr_emp_payitems.OPERATION = operation.Empty_Self;
                //    _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(rcb_BusinessUnit.SelectedItem.Value);
                //    _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //    _obj_smhr_emp_payitems.REPORTING_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                //    DataTable DT_Details = BLL.get_EmpDetails(_obj_smhr_emp_payitems);//NOT NEEDED AS WE ARE LOADING RELAVENT TO ORG.
                //    if (DT_Details.Rows.Count != 0)
                //    {
                //        rcb_Employee.DataSource = DT_Details;
                //        rcb_Employee.DataTextField = "EMPNAME";
                //        rcb_Employee.DataValueField = "EMP_ID";
                //        rcb_Employee.DataBind();
                //        rcb_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
                //    }
                //    else
                //    {
                //        rcb_Employee.DataSource = DT_Details;
                //        rcb_Employee.DataTextField = "EMPNAME";
                //        rcb_Employee.DataValueField = "EMP_ID";
                //        rcb_Employee.DataBind();
                //        rcb_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
                //    }
                //}
                //}
                //else
                //{
                //FOR ADMIN
                _obj_smhr_emp_payitems.OPERATION = operation.Empty1;
                _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(rcb_BusinessUnit.SelectedItem.Value);
                _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable DT_Details = BLL.get_EmpDetails(_obj_smhr_emp_payitems);//NOT NEEDED AS WE ARE LOADING RELAVENT TO ORG.
                if (DT_Details.Rows.Count != 0)
                {
                    rcb_Employee.DataSource = DT_Details;
                    rcb_Employee.DataTextField = "EMPNAME";
                    rcb_Employee.DataValueField = "EMP_ID";
                    rcb_Employee.DataBind();
                }
                else
                {
                    ////rcb_Employee.DataSource = DT_Details;
                    ////rcb_Employee.DataTextField = "EMPNAME";
                    ////rcb_Employee.DataValueField = "EMP_ID";
                    ////rcb_Employee.DataBind();
                    ////rcb_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
                }
                rcb_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
                //}
            }
            else
            {
                rcb_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Identification", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void rcb_Type_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            switch (rcb_Type.SelectedItem.Text)
            {
                case "Passport":
                    rtxt_IssuedOrg.Enabled = true;
                    rtxt_IssuedOrg.Text = String.Empty;
                    rdp_ExpiryDate.Enabled = true;
                    rdp_ExpiryDate.Clear();
                    rdp_IssueDate.Enabled = true;
                    rdp_IssueDate.Clear();
                    rtb_Code.Text = string.Empty;
                    rtxt_Name.Text = string.Empty;
                    break;
                case "License":
                    rtxt_IssuedOrg.Enabled = true;
                    rtxt_IssuedOrg.Text = String.Empty;
                    rdp_ExpiryDate.Enabled = true;
                    rdp_ExpiryDate.Clear();
                    rdp_IssueDate.Enabled = true;
                    rdp_IssueDate.Clear();
                    rtb_Code.Text = string.Empty;
                    rtxt_Name.Text = string.Empty;
                    break;
                case "Contact":
                    rtxt_IssuedOrg.Enabled = false;
                    rtxt_IssuedOrg.Text = String.Empty;
                    rdp_ExpiryDate.Enabled = false;
                    rdp_ExpiryDate.Clear();
                    rdp_IssueDate.Enabled = false;
                    rdp_IssueDate.Clear();
                    rtb_Code.Text = string.Empty;
                    rtxt_Name.Text = string.Empty;
                    break;
                case "Email":
                    rtxt_IssuedOrg.Enabled = false;
                    rtxt_IssuedOrg.Text = String.Empty;
                    rdp_ExpiryDate.Enabled = false;
                    rdp_ExpiryDate.Clear();
                    rdp_IssueDate.Enabled = false;
                    rdp_IssueDate.Clear();
                    rtb_Code.Text = string.Empty;
                    rtxt_Name.Text = string.Empty;
                    break;
                case "PF":
                    rtxt_IssuedOrg.Enabled = false;
                    rtxt_IssuedOrg.Text = String.Empty;
                    rdp_ExpiryDate.Enabled = false;
                    rdp_ExpiryDate.Clear();
                    rdp_IssueDate.Enabled = false;
                    rdp_IssueDate.Clear();
                    rtb_Code.Text = string.Empty;
                    rtxt_Name.Text = string.Empty;
                    break;
                case "ESI":
                    rtxt_IssuedOrg.Enabled = false;
                    rtxt_IssuedOrg.Text = String.Empty;
                    rdp_ExpiryDate.Enabled = false;
                    rdp_ExpiryDate.Clear();
                    rdp_IssueDate.Enabled = false;
                    rdp_IssueDate.Clear();
                    rtb_Code.Text = string.Empty;
                    rtxt_Name.Text = string.Empty;
                    break;
                case "PAN":
                    rtxt_IssuedOrg.Enabled = true;
                    rtxt_IssuedOrg.Text = String.Empty;
                    rdp_ExpiryDate.Enabled = true;
                    rdp_ExpiryDate.Clear();
                    rdp_IssueDate.Enabled = true;
                    rdp_IssueDate.Clear();
                    rtb_Code.Text = string.Empty;
                    break;
                default:
                    rtxt_IssuedOrg.Enabled = false;
                    rtxt_IssuedOrg.Text = String.Empty;
                    rdp_ExpiryDate.Enabled = false;
                    rdp_ExpiryDate.Clear();
                    rdp_IssueDate.Enabled = false;
                    rtb_Code.Text = string.Empty;
                    rtxt_Name.Text = string.Empty;
                    rdp_IssueDate.Clear();
                    break;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Identification", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

    }
    protected void rcb_BusinessUnit_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rcb_Type.Items.Clear();
            rcb_Type.Text = string.Empty;
            LoadIdentificationType();
            rcb_Type.SelectedIndex = 0;
            rdp_ExpiryDate.SelectedDate = null;
            rdp_IssueDate.SelectedDate = null;
            rtb_Code.Text = string.Empty;
            rtxt_IssuedOrg.Text = string.Empty;
            rtxt_Name.Text = string.Empty;
            rcb_Type.Enabled = true;
            rtb_Code.Enabled = true;
            rtxt_IssuedOrg.Enabled = true;
            lbl_Message.Visible = false;
            RG_Identification.Visible = false;

            LoadEmployees();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Identification", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
}