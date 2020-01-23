using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using Telerik.Web.UI;


public partial class HR_frm_employeeNotes : System.Web.UI.Page
{
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
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
            _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Notes On Employee");//NOTESONEMPLOYEE");
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
                Rg_NotesRec.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                btn_Save.Visible = false;
                btn_Edit.Visible = false;
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
            BLL.ChangeDateFormat(Convert.ToString(Session["EMP_ID"]), rdtp_NotesRecDate, rdtp_NotesRecDOJ);
            BLL.gridDateFormat(Convert.ToString(Session["EMP_ID"]), Rg_NotesRec, "EMPNOTES_DATE");
        }
       Page.Validate();
      }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_employeeNotes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            loadDropdown();
            clearControls();
            ddl_BusinessUnit.Enabled = false;
            rcmb_NotesRecEmpID.Enabled = false;
            SMHR_EMPNOTES _obj_Smhr_EmpNotes = new SMHR_EMPNOTES();
            _obj_Smhr_EmpNotes.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_EmpNotes.EMPNOTES_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            DataTable dt = BLL.get_EmpNotes(_obj_Smhr_EmpNotes);
            ddl_BusinessUnit.SelectedIndex = ddl_BusinessUnit.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["EMPNOTES_BU"]));
            lbl_NotesRecID.Text = Convert.ToString(dt.Rows[0]["EMPNOTES_ID"]);
            //ddl_BusinessUnit_SelectedIndexChanged(null, null);
            LoadEmployees_Edit();
            rcmb_NotesRecEmpID.SelectedIndex = rcmb_NotesRecEmpID.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["EMPNOTES_EMPID"]));
            //rcmb_NotesRecEmpID_SelectedIndexChanged(null, null);
            LoadReportEmployees_Edit();
            rcmb_NotesRecManagerID.SelectedIndex = rcmb_NotesRecManagerID.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["EMPNOTES_RPTMNGID"]));
            rtxt_NotesRecRemarks.Text = Convert.ToString(dt.Rows[0]["EMPNOTES_REMARKS"]);
            rtxt_NotesRecReason.Text = Convert.ToString(dt.Rows[0]["EMPNOTES_REASON"]);
            rdtp_NotesRecDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["EMPNOTES_DATE"]);
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Edit.Visible = false;

            }

            else
            {
                btn_Edit.Visible = true;
            }


            Rm_NR_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_employeeNotes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
       
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            loadDropdown();
            clearControls();
            btn_Save.Visible = true;
            Rm_NR_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_employeeNotes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void LoadGrid()
    {
        try
        {
            SMHR_EMPNOTES _obj_Smhr_EmpNotes = new SMHR_EMPNOTES();
            _obj_Smhr_EmpNotes.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_EmpNotes.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            //        DataTable DT = BLL.get_EmpNotes(new SMHR_EMPNOTES());BHARADWAJ
            DataTable DT = BLL.get_EmpNotes(_obj_Smhr_EmpNotes);
            Rg_NotesRec.DataSource = DT;
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_employeeNotes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void loadDropdown()
    {
        try
        {
            ddl_BusinessUnit.Items.Clear();
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            ddl_BusinessUnit.DataSource = dt_BUDetails;
            ddl_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            ddl_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            ddl_BusinessUnit.DataBind();
            ddl_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));

            rcmb_NotesRecEmpID.Items.Clear();
            rcmb_NotesRecEmpID.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_employeeNotes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {

        try
        {
            SMHR_EMPNOTES _obj_Smhr_EmpNotes = new SMHR_EMPNOTES();

            _obj_Smhr_EmpNotes.EMPNOTES_BU = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
            _obj_Smhr_EmpNotes.EMPNOTES_EMPID = Convert.ToInt32(rcmb_NotesRecEmpID.SelectedItem.Value);
            _obj_Smhr_EmpNotes.EMPNOTES_RPTMNGID = Convert.ToInt32(rcmb_NotesRecManagerID.SelectedItem.Value);
            _obj_Smhr_EmpNotes.EMPNOTES_REMARKS = BLL.ReplaceQuote(rtxt_NotesRecRemarks.Text);
            _obj_Smhr_EmpNotes.EMPNOTES_REASON = BLL.ReplaceQuote(rtxt_NotesRecReason.Text);
            _obj_Smhr_EmpNotes.EMPNOTES_DATE = Convert.ToDateTime(rdtp_NotesRecDate.SelectedDate);

            _obj_Smhr_EmpNotes.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_EmpNotes.CREATEDDATE = DateTime.Now;

            _obj_Smhr_EmpNotes.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_EmpNotes.LASTMDFDATE = DateTime.Now;
            _obj_Smhr_EmpNotes.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            SMHR_EMPLOYEE _obj_smhr_employee = new SMHR_EMPLOYEE();
            _obj_smhr_employee.OPERATION = operation.Select;
            _obj_smhr_employee.EMP_ID = Convert.ToInt32(rcmb_NotesRecEmpID.SelectedItem.Value);
            //dt_Details = new DataTable();
            _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Details = BLL.get_Employee(_obj_smhr_employee);
            if (Convert.ToInt32(dt_Details.Rows[0]["EMP_STATUS"]) == 1)
            {
                BLL.ShowMessage(this, "Employee is Resigned.You can not update the record.");
                return;
            }
            else if (Convert.ToInt32(dt_Details.Rows[0]["EMP_STATUS"]) == 2)
            {
                BLL.ShowMessage(this, "Employee is Relieved.You can not update the record.");
                return;
            }
            else if (Convert.ToInt32(dt_Details.Rows[0]["EMP_STATUS"]) == 3)
            {
                BLL.ShowMessage(this, "Employee is Rehired.You can not update the record.");
                return;
            }
            else
            {
                switch (((Button)sender).ID.ToUpper())
                {
                    case "BTN_EDIT":
                        _obj_Smhr_EmpNotes.EMPNOTES_ID = Convert.ToInt32(lbl_NotesRecID.Text);
                        _obj_Smhr_EmpNotes.OPERATION = operation.Update;
                        if (BLL.set_EmpNotes(_obj_Smhr_EmpNotes))
                            BLL.ShowMessage(this, "Information Updated Successfully");
                        else
                            BLL.ShowMessage(this, "Information Not Saved");

                        break;
                    case "BTN_SAVE":
                        _obj_Smhr_EmpNotes.OPERATION = operation.Insert;
                        if (BLL.set_EmpNotes(_obj_Smhr_EmpNotes))
                            BLL.ShowMessage(this, "Information Saved Successfully");
                        else
                            BLL.ShowMessage(this, "Information Not Saved");
                        break;
                    default:
                        break;
                }
                Rm_NR_page.SelectedIndex = 0;
                LoadGrid();
                Rg_NotesRec.DataBind();
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_employeeNotes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void clearControls()
    {
        try
        {
            lbl_NotesRecID.Text = string.Empty;
            rcmb_NotesRecEmpID.SelectedIndex = -1;
            rcmb_NotesRecManagerID.SelectedIndex = -1;
            rtxt_NotesRecRemarks.Text = string.Empty;
            rtxt_NotesRecReason.Text = string.Empty;
            rdtp_NotesRecDate.SelectedDate = null;
            rdtp_NotesRecDOJ.SelectedDate = null;
            rcmb_NotesRecManagerID.Enabled = true;
            btn_Save.Visible = false;
            btn_Edit.Visible = false;
            Rm_NR_page.SelectedIndex = 0;
            ddl_BusinessUnit.Enabled = true;
            rcmb_NotesRecEmpID.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_employeeNotes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_employeeNotes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rg_NotesRec_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_employeeNotes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_NotesRecEmpID_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            LoadReportEmployees();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_employeeNotes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void ddl_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (ddl_BusinessUnit.SelectedIndex != 0)
            {
                LoadEmployees();
            }
            else
            {
                rcmb_NotesRecEmpID.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_employeeNotes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadEmployees()
    {

        try
        {
            SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
            _obj_smhr_emp_payitems.OPERATION = operation.Empty;
            DataTable DT_Details = new DataTable();
            if (ddl_BusinessUnit.SelectedItem.Value != "")
            {
                if (Convert.ToString(Session["SELFSERVICE"]) == "")
                {
                    //FOR MANAGER
                    _obj_smhr_emp_payitems.OPERATION = operation.Empty_Self;
                    _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(ddl_BusinessUnit.SelectedItem.Value);
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
                    // FOR ADMIN
                    _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(ddl_BusinessUnit.SelectedItem.Value);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_employeeNotes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadEmployees_Edit()
    {

        try
        {
            SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
            _obj_smhr_emp_payitems.OPERATION = operation.Empty1;
            DataTable DT_Details = new DataTable();
            if (ddl_BusinessUnit.SelectedItem.Value != "")
            {
                if (Convert.ToString(Session["SELFSERVICE"]) == "")
                {
                    //FOR MANAGER
                    _obj_smhr_emp_payitems.OPERATION = operation.Empty_Self_Edit;
                    _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(ddl_BusinessUnit.SelectedItem.Value);
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
                    // FOR ADMIN
                    _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(ddl_BusinessUnit.SelectedItem.Value);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_employeeNotes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadReportEmployees_Edit()
    {

        try
        {
            if (Convert.ToString(rcmb_NotesRecEmpID.SelectedItem.Value) != "-1")
            {
                SMHR_EMPNOTES _obj_Smhr_EmpNotes = new SMHR_EMPNOTES();
                _obj_Smhr_EmpNotes.OPERATION = operation.EMPTY_R;
                _obj_Smhr_EmpNotes.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt = BLL.get_EmpNotes(_obj_Smhr_EmpNotes);
                dt.DefaultView.RowFilter = " EMP_ID <> " + Convert.ToString(rcmb_NotesRecEmpID.SelectedItem.Value);
                dt = dt.DefaultView.ToTable();
                rcmb_NotesRecManagerID.Items.Clear();
                rcmb_NotesRecManagerID.DataSource = dt;
                rcmb_NotesRecManagerID.DataTextField = "EMPNAME";
                rcmb_NotesRecManagerID.DataValueField = "EMP_ID";
                rcmb_NotesRecManagerID.DataBind();


                SMHR_EMPLOYEE _obj_Smhr_Employee = new SMHR_EMPLOYEE();
                _obj_Smhr_Employee.OPERATION = operation.Select;
                _obj_Smhr_Employee.EMP_ID = Convert.ToInt32(rcmb_NotesRecEmpID.SelectedItem.Value);
                dt = new DataTable();
                _obj_Smhr_Employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                dt = BLL.get_Employee(_obj_Smhr_Employee);
                rcmb_NotesRecManagerID.SelectedIndex = rcmb_NotesRecManagerID.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["EMP_REPORTINGEMPLOYEE"]));
                if (dt.Rows[0]["EMP_DOJ"] != DBNull.Value)
                    rdtp_NotesRecDOJ.SelectedDate = Convert.ToDateTime(Convert.ToString(dt.Rows[0]["EMP_DOJ"]));
                rcmb_NotesRecManagerID.Enabled = false;
            }
            else
            {
                rcmb_NotesRecManagerID.Items.Clear();
                rdtp_NotesRecDOJ.SelectedDate = null;
            }
            rcmb_NotesRecManagerID.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_employeeNotes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadReportEmployees()
    {

        try
        {
            if (Convert.ToString(rcmb_NotesRecEmpID.SelectedItem.Value) != "-1")
            {
                SMHR_EMPNOTES _obj_Smhr_EmpNotes = new SMHR_EMPNOTES();
                _obj_Smhr_EmpNotes.OPERATION = operation.Empty;
                _obj_Smhr_EmpNotes.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt = BLL.get_EmpNotes(_obj_Smhr_EmpNotes);
                dt.DefaultView.RowFilter = " EMP_ID <> " + Convert.ToString(rcmb_NotesRecEmpID.SelectedItem.Value);
                dt = dt.DefaultView.ToTable();
                rcmb_NotesRecManagerID.Items.Clear();
                rcmb_NotesRecManagerID.DataSource = dt;
                rcmb_NotesRecManagerID.DataTextField = "EMPNAME";
                rcmb_NotesRecManagerID.DataValueField = "EMP_ID";
                rcmb_NotesRecManagerID.DataBind();


                SMHR_EMPLOYEE _obj_Smhr_Employee = new SMHR_EMPLOYEE();
                _obj_Smhr_Employee.OPERATION = operation.Select;
                _obj_Smhr_Employee.EMP_ID = Convert.ToInt32(rcmb_NotesRecEmpID.SelectedItem.Value);
                dt = new DataTable();
                _obj_Smhr_Employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                dt = BLL.get_Employee(_obj_Smhr_Employee);
                rcmb_NotesRecManagerID.SelectedIndex = rcmb_NotesRecManagerID.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["EMP_REPORTINGEMPLOYEE"]));
                if (dt.Rows[0]["EMP_DOJ"] != DBNull.Value)
                    rdtp_NotesRecDOJ.SelectedDate = Convert.ToDateTime(Convert.ToString(dt.Rows[0]["EMP_DOJ"]));
                rcmb_NotesRecManagerID.Enabled = false;
            }
            else
            {
                rcmb_NotesRecManagerID.Items.Clear();
                rdtp_NotesRecDOJ.SelectedDate = null;
            }
            rcmb_NotesRecManagerID.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_employeeNotes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void BindEmployees(DataTable DT_Details)
    {
        try
        {
            rcmb_NotesRecEmpID.DataSource = DT_Details;
            rcmb_NotesRecEmpID.DataTextField = "EMPNAME";
            rcmb_NotesRecEmpID.DataValueField = "EMP_ID";
            rcmb_NotesRecEmpID.DataBind();
            rcmb_NotesRecEmpID.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_employeeNotes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
