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
using System.IO;
using Telerik.Web.UI;
using SPMS;

public partial class Payroll_frm_ExpenseTrans : System.Web.UI.Page
{
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    bool status;
    string Control;
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    public string masterType = string.Empty;
    SMHR_EXPENSE _obj_Smhr_Expense;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Control = Convert.ToString(Request.QueryString["Control"]);
            if (!Page.IsPostBack)
            {


                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("EXPENSE ENTRY");
                if (Control != null)
                {
                    if (Control.ToUpper() == "SELFEXPENSE")
                    {
                        _obj_Smhr_LoginInfo.LOGIN_ID = 12;
                    }

                }
                else
                {
                    _obj_Smhr_LoginInfo.LOGIN_ID = 3;
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
                    Rg_ExpenseTrans.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    Rg_ExpenseDetails.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Save.Visible = false;
                    btn_Edit.Visible = false;
                    btn_Details_Save.Visible = false;
                    btn_Details_Edit.Visible = false;
                    btn_ExpenseType_Refresh.Visible = false;
                    btn_Currency_Refresh.Visible = false;
                    // added to support Only-View functionality.
                    //foreach (GridColumn col in Rg_ExpenseTrans.Columns)
                    //{
                    //    if (col.UniqueName == "ColEdit")
                    //    {
                    //        col.Visible = false;
                    //    }
                    //}
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
                Page.Validate();
                BLL.ChangeDateFormat(Convert.ToString(Session["EMP_ID"]), rdp_AppliedDate, rdp_ExpenseDate);
                BLL.gridDateFormat(Convert.ToString(Session["EMP_ID"]), Rg_ExpenseTrans, "EXPENSE_APPDATE");
                BLL.gridDateFormat(Convert.ToString(Session["EMP_ID"]), Rg_ExpenseDetails, "EXPENSEDTL_EXPENSEDATE");
                Control = Convert.ToString(Request.QueryString["Control"]);
                Get_Table();
                if (Request.QueryString["POP"] != null)
                {
                    //((HtmlTableRow)Master.FindControl("M_Header")).Style.Add("display", "none");
                    //((HtmlTableRow)Master.FindControl("M_Footer")).Style.Add("display", "none");
                    //((RadMenu)Master.FindControl("MainMenu")).Style.Add("display", "none");
                    //((RadComboBox)Master.FindControl("cmbCulture")).Style.Add("display", "none");
                    //((LinkButton)Master.FindControl("Lnk_LogOut")).Style.Add("display", "none");
                    //((LinkButton)Master.FindControl("lnk_Home")).Style.Add("display", "none");

                    if (Request.QueryString["EXPID"] != null)
                    {
                        lnk_Edit_Command(null, new CommandEventArgs("test", Convert.ToString(Request.QueryString["EXPID"])));
                        Rp_RT_ViewMain.Visible = false;
                        btn_Cancel.Visible = false;
                        btn_Edit.Visible = false;
                        btn_Save.Visible = false;
                    }
                }
                if (Control != null && Convert.ToInt32(Session["EMP_ID"]) == 0)
                {
                    BLL.ShowMessage(this, "You do not have Access on this Screen");
                    return;
                }

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ExpenseTrans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            loadDropdown();
            _loadDropdown();
            clearControls();
            //LoadEmployees();
            string Temp = string.Empty;
            //if (Request.QueryString["EXPID"] != null)
            //{
            //    Temp = Convert.ToString(Request.QueryString["EXPID"]);
            //}
            //else
            //{
            Temp = Convert.ToString(e.CommandArgument);
            //}

            DataTable dt = BLL.get_Expense(new SMHR_EXPENSE(Convert.ToInt32(Convert.ToString(Temp))));
            if ((Convert.ToInt32(dt.Rows[0]["EMP_STATUS"]) == 0) || (Convert.ToInt32(dt.Rows[0]["EMP_STATUS"]) == 1))
            {
                LoadEmployees();
            }
            else if ((Convert.ToInt32(dt.Rows[0]["EMP_STATUS"]) == 2) || (Convert.ToInt32(dt.Rows[0]["EMP_STATUS"]) == 3))
            {
                SMHR_EMPNOTES _obj_Smhr_EmpNotes = new SMHR_EMPNOTES();
                _obj_Smhr_EmpNotes.OPERATION = operation.EMPTY_R;
                _obj_Smhr_EmpNotes.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_EmpNotes.EMPNOTES_EMPID = Convert.ToInt32(Session["EMP_ID"]);
                DataTable dt_Employees = BLL.get_EmpNotes(_obj_Smhr_EmpNotes);
                rcmb_Employee.DataSource = dt_Employees;
                rcmb_Employee.DataTextField = "EMPNAME";
                rcmb_Employee.DataValueField = "EMP_ID";
                rcmb_Employee.DataBind();
                rcmb_Employee.SelectedIndex = rcmb_Employee.FindItemIndexByValue(Convert.ToString(Session["EMP_ID"]));
                rcmb_Employee.Enabled = false;
            }
            ViewState["DTLEMP"] = dt.Rows[0]["EXPENSE_EMP_ID"];

            lbl_ExpenseID.Text = Convert.ToString(dt.Rows[0]["EXPENSE_ID"]);
            //lbl_ExpenseDetailID.Text = Convert.ToString(dt.Rows[0]["EXPENSEDTL_ID"]);
            rtxt_ExpenseName.Enabled = false;
            rcmb_Employee.Enabled = false;
            rtxt_ExpenseName.Text = Convert.ToString(dt.Rows[0]["EXPENSE_NAME"]);
            rcmb_Employee.SelectedIndex = rcmb_Employee.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["EXPENSE_EMP_ID"]));
            rcmb_BusinessUnit.SelectedIndex = rcmb_BusinessUnit.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["EXPENSE_BUSINESSUNIT_ID"]));
            rdp_AppliedDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["EXPENSE_APPDATE"]);


            SMHR_EXPENSEDETAIL _obj_Smhr_ExpenseDetail = new SMHR_EXPENSEDETAIL();

            _obj_Smhr_ExpenseDetail.OPERATION = operation.Select;
            _obj_Smhr_ExpenseDetail.EXPENSEDTL_EXPENSE_ID = Convert.ToInt32(lbl_ExpenseID.Text);

            ViewState["DTEXPDTL"] = BLL.get_ExpenseDetails(_obj_Smhr_ExpenseDetail);
            DataTable dt_date = BLL.get_ExpenseDetails(_obj_Smhr_ExpenseDetail);
            ViewState["ExpenseDate"] = Convert.ToString(dt_date.Rows[0]["EXPENSEDTL_EXPENSEDATE"]);

            if (Request.QueryString["EXPID"] == null)
            {

                if (Convert.ToString(dt.Rows[0]["EXPENSE_STATUS"]) == "1")
                {
                    btn_Edit.Visible = false;
                    btn_Details_Edit.Enabled = false;
                    Rg_ExpenseDetails.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    BLL.ShowMessage(this, "This record is Already Approved cannot be Edited");
                }
                else
                {
                    if ((Convert.ToInt32(dt.Rows[0]["EMP_STATUS"]) == 2) || (Convert.ToInt32(dt.Rows[0]["EMP_STATUS"]) == 3))
                    {
                        btn_Edit.Visible = false;
                        btn_Details_Edit.Enabled = false;
                        //Rg_ExpenseDetails.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    }
                    else
                    {
                        if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                        {
                            btn_Edit.Visible = false;
                            Rg_ExpenseDetails.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                            btn_Details_Edit.Enabled = false;
                        }
                        else
                        {
                            btn_Edit.Visible = true;
                            Rg_ExpenseDetails.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Top;
                            btn_Details_Edit.Enabled = true;
                        }
                    }
                }
            }
            else
            {
                btn_Edit.Visible = true;
                Rg_ExpenseDetails.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
            }
            Rg_ExpenseDetails.DataSource = (DataTable)ViewState["DTEXPDTL"];
            Rg_ExpenseDetails.DataBind();
            Rm_RT_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ExpenseTrans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            rcmb_Employee.Items.Clear();
            rcmb_Employee.Items.Insert(0, new RadComboBoxItem("", ""));
            loadDropdown();

            //btn_Cancel_Click(null, null);

            clearControls();
            DataTable dt = (DataTable)ViewState["DTEXPDTL"];
            dt.Rows.Clear();
            Rg_ExpenseDetails.DataSource = dt;
            Rg_ExpenseDetails.DataBind();

            //if (Convert.ToString(Session["SELFSERVICE"]) == "")
            //{
            //    rcmb_Employee.Enabled = true;
            //    if (Request.QueryString["EMPID"] != null)
            //    {
            //        rcmb_Employee.Enabled = false;
            //        rcmb_Employee.SelectedIndex = rcmb_Employee.FindItemIndexByValue(Convert.ToString(Request.QueryString["EMPID"]));
            //    }
            //}
            if (Control != null)
            {
                //if (Convert.ToString(Session["SELFSERVICE"]) == "true")
                if ((Convert.ToString(Session["SELFSERVICE"]) == "true" && Control.ToUpper() == "SELFEXPENSE") || (Convert.ToString(Session["SELFSERVICE"]) == "" && Control.ToUpper() == "SELFEXPENSE"))
                {
                    LoadEmployees();
                    rcmb_BusinessUnit.Enabled = false;
                    rcmb_Employee.SelectedIndex = rcmb_Employee.FindItemIndexByValue(Convert.ToString(Session["EMP_ID"]));
                    rcmb_Employee.Enabled = false;
                }
            }
            else
            {
                rcmb_Employee.Enabled = true;
            }

            btn_Save.Visible = true;
            Rm_RT_page.SelectedIndex = 1;
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                Rg_ExpenseTrans.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                Rg_ExpenseDetails.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                btn_Save.Visible = false;
                btn_Edit.Visible = false;
                btn_Details_Save.Visible = false;
                btn_Details_Edit.Visible = false;
                btn_ExpenseType_Refresh.Visible = false;
                btn_Currency_Refresh.Visible = false;
                // added to support Only-View functionality.
                foreach (GridColumn col in Rg_ExpenseTrans.Columns)
                {
                    if (col.UniqueName == "ColEdit")
                    {
                        col.Visible = false;
                    }
                }
                foreach (GridColumn col in Rg_ExpenseDetails.Columns)
                {
                    if (col.UniqueName == "ColEdit")
                    {
                        col.Visible = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ExpenseTrans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Details_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            int Index = Convert.ToInt32(e.CommandArgument) - 1;
            _loadDropdown();

            Rm_Expense.SelectedIndex = 1;

            btn_Save.Enabled = false;
            btn_Edit.Enabled = false;
            btn_Cancel.Enabled = false;


            DataTable dt_det_Edit = (DataTable)ViewState["DTEXPDTL"];

            lbl_Sno.Text = Convert.ToString(dt_det_Edit.Rows[Index]["SNO"]);
            lbl_ExpenseDetailsID.Text = Convert.ToString(dt_det_Edit.Rows[Index]["EXPENSEDTL_ID"]);
            rcmb_ExpenseType.SelectedIndex = rcmb_ExpenseType.FindItemIndexByValue(Convert.ToString(dt_det_Edit.Rows[Index]["EXPENSEDTL_TYPE_ID"]));
            rdp_ExpenseDate.SelectedDate = Convert.ToDateTime(dt_det_Edit.Rows[Index]["EXPENSEDTL_EXPENSEDATE"]);
            rtxt_ExpenseAmt.Text = Convert.ToString(dt_det_Edit.Rows[Index]["EXPENSEDTL_AMOUNT"]);
            rcmb_ExpenseCurrency.SelectedIndex = rcmb_ExpenseCurrency.FindItemIndexByValue(Convert.ToString(dt_det_Edit.Rows[Index]["EXPENSEDTL_CURRID"]));
            rtxt_Description.Text = Convert.ToString(dt_det_Edit.Rows[Index]["EXPENSEDTL_DESC"]);

            if (!string.IsNullOrEmpty(Convert.ToString(dt_det_Edit.Rows[Index]["EXPENSEDTL_ATTACHMENT"])))
            {
                if (File.Exists(Server.MapPath(Convert.ToString(dt_det_Edit.Rows[Index]["EXPENSEDTL_ATTACHMENT"]))))
                {
                    lnk_fup_ExpenseUpload.Visible = true;
                    lnk_fup_ExpenseUpload.OnClientClick = "javascript:window.open('../" + Convert.ToString(dt_det_Edit.Rows[Index]["EXPENSEDTL_ATTACHMENT"]).TrimStart('~', '/') + "');return false;";
                    ViewState["fileLocation"] = Convert.ToString(dt_det_Edit.Rows[Index]["EXPENSEDTL_ATTACHMENT"]);
                }
            }

            if (Request.QueryString["EXPID"] != null)
            {
                btn_Details_Edit.Visible = false;
            }
            else
            {

                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {

                    btn_Details_Edit.Visible = false;


                }

                else
                {
                    btn_Details_Edit.Visible = true;

                }

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ExpenseTrans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void lnk_Details_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            _loadDropdown();
            btn_Details_Save.Visible = true;
            Rm_Expense.SelectedIndex = 1;

            btn_Save.Enabled = false;
            btn_Edit.Enabled = false;
            btn_Cancel.Enabled = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ExpenseTrans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //public void loadDropdown()
    //{
    //    rcmb_Employee.Items.Clear();
    //    SMHR_EMPNOTES _obj_Smhr_EmpNotes = new SMHR_EMPNOTES();
    //    _obj_Smhr_EmpNotes.OPERATION = operation.Empty;
    //    _obj_Smhr_EmpNotes.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //    rcmb_Employee.DataSource = BLL.get_EmpNotes(_obj_Smhr_EmpNotes);
    //    rcmb_Employee.DataTextField = "EMPNAME";
    //    rcmb_Employee.DataValueField = "EMP_ID";
    //    rcmb_Employee.DataBind();
    //    rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

    //    rcmb_BusinessUnit.Items.Clear();
    //    _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
    //    _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //    _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
    //    DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
    //    rcmb_BusinessUnit.DataSource = dt_BUDetails;
    //    rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
    //    rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
    //    rcmb_BusinessUnit.DataBind();
    //    rcmb_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
    //}


    //added by Anirudh to differentiate between Self-Service And Non-Self-Service Employees
    public void loadDropdown()
    {
        try
        {
            if (Control == null)
            {
                //if (Convert.ToString(Session["SELFSERVICE"]) == "" || Convert.ToInt32(Session["EMP_ID"]) == 0)
                //{
                _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
                _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
                rcmb_BusinessUnit.DataSource = dt_BUDetails;
                rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
                rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
                rcmb_BusinessUnit.DataBind();
                rcmb_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
                //}
            }
            else if ((Convert.ToString(Session["SELFSERVICE"]) == "true" && Control.ToUpper() == "SELFEXPENSE") || (Convert.ToString(Session["SELFSERVICE"]) == "" && Control.ToUpper() == "SELFEXPENSE"))
            {
                _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
                _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
                rcmb_BusinessUnit.DataSource = dt_BUDetails;
                rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
                rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
                rcmb_BusinessUnit.DataBind();
                rcmb_BusinessUnit.SelectedIndex = rcmb_BusinessUnit.FindItemIndexByValue(Convert.ToString(Session["BUSINESSUNIT_ID"]));
                rcmb_BusinessUnit.Enabled = false;
            }
            else
            {
                BLL.ShowMessage(this, "You do not have Access on this Screen");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ExpenseTrans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    public void LoadEmployees()
    {
        try
        {
            //if (Convert.ToString(Session["SELFSERVICE"]) == "")
            //{
            //    SMHR_EMPNOTES _obj_Smhr_EmpNotes = new SMHR_EMPNOTES();
            //    _obj_Smhr_EmpNotes.OPERATION = operation.Empty;
            //    _obj_Smhr_EmpNotes.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //    DataTable dt_Employees = BLL.get_EmpNotes(_obj_Smhr_EmpNotes);
            //    rcmb_Employee.DataSource = dt_Employees;
            //    rcmb_Employee.DataTextField = "EMPNAME";
            //    rcmb_Employee.DataValueField = "EMP_ID";
            //    rcmb_Employee.DataBind();
            //    rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
            //}
            //else
            //{
            SMHR_EMPNOTES _obj_Smhr_EmpNotes = new SMHR_EMPNOTES();
            _obj_Smhr_EmpNotes.OPERATION = operation.Empty;
            _obj_Smhr_EmpNotes.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_EmpNotes.EMPNOTES_EMPID = Convert.ToInt32(Session["EMP_ID"]);
            DataTable dt_Employees = BLL.get_EmpNotes(_obj_Smhr_EmpNotes);
            rcmb_Employee.DataSource = dt_Employees;
            rcmb_Employee.DataTextField = "EMPNAME";
            rcmb_Employee.DataValueField = "EMP_ID";
            rcmb_Employee.DataBind();
            rcmb_Employee.SelectedIndex = rcmb_Employee.FindItemIndexByValue(Convert.ToString(Session["EMP_ID"]));
            rcmb_Employee.Enabled = false;
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ExpenseTrans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void _loadDropdown()
    {
        try
        {
            SMHR_MASTERS _obj_smhr_masters = new SMHR_MASTERS();
            _obj_smhr_masters.MASTER_TYPE = "EXPENSE";
            _obj_smhr_masters.OPERATION = operation.Select;
            _obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            rcmb_ExpenseType.DataSource = BLL.get_MasterRecords(_obj_smhr_masters);
            rcmb_ExpenseType.DataTextField = "HR_MASTER_CODE";
            rcmb_ExpenseType.DataValueField = "HR_MASTER_ID";
            rcmb_ExpenseType.DataBind();
            rcmb_ExpenseType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

            SMHR_CURRENCY _obj_Currency = new SMHR_CURRENCY();
            _obj_Currency.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            rcmb_ExpenseCurrency.Items.Clear();
            rcmb_ExpenseCurrency.DataSource = BLL.get_Currency(_obj_Currency);
            rcmb_ExpenseCurrency.DataTextField = "CURR_CODE";
            rcmb_ExpenseCurrency.DataValueField = "CURR_ID";
            rcmb_ExpenseCurrency.DataBind();
            rcmb_ExpenseCurrency.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ExpenseTrans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void clearControls()
    {
        try
        {
            lbl_ExpenseID.Text = string.Empty;
            rtxt_ExpenseName.Text = string.Empty;
            rtxt_ExpenseName.Enabled = true;
            rcmb_Employee.Enabled = true;
            rcmb_Employee.SelectedIndex = -1;
            rdp_AppliedDate.SelectedDate = null;

            btn_Save.Visible = false;
            btn_Edit.Visible = false;
            Rm_RT_page.SelectedIndex = 0;
            _clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ExpenseTrans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void _clearControls()
    {
        try
        {
            lbl_ExpenseDetailsID.Text = string.Empty;
            rcmb_ExpenseType.SelectedIndex = -1;
            rdp_ExpenseDate.SelectedDate = null;
            rtxt_ExpenseAmt.Text = string.Empty;
            rcmb_ExpenseCurrency.SelectedIndex = -1;
            rtxt_Description.Text = string.Empty;
            // fup_ExpenseUpload.= string.Empty; 
            lnk_fup_ExpenseUpload.Visible = false;

            btn_Details_Save.Visible = false;
            btn_Details_Edit.Visible = false;
            Rm_Expense.SelectedIndex = 0;

            btn_Save.Enabled = true;
            btn_Edit.Enabled = true;
            btn_Cancel.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ExpenseTrans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void LoadGrid()
    {
        try
        {
            if (Control != null)
            {
                if ((Convert.ToString(Session["SELFSERVICE"]) == "true" && Control.ToUpper() == "SELFEXPENSE") || (Convert.ToString(Session["SELFSERVICE"]) == "" && Control.ToUpper() == "SELFEXPENSE"))
                {
                    //if (Convert.ToString(Session["SELFSERVICE"]) == "")
                    //{
                    //    _obj_Smhr_Expense = new SMHR_EXPENSE();
                    //    _obj_Smhr_Expense.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    //    DataTable DT_grid = BLL.get_Expense(_obj_Smhr_Expense);
                    //    if (Request.QueryString["EMPID"] == null)
                    //    {
                    //        Rg_ExpenseTrans.DataSource = DT_grid;
                    //        clearControls();
                    //    }
                    //    else
                    //    {
                    //        DT_grid.DefaultView.RowFilter = " EMP_ID='" + Convert.ToString(Request.QueryString["EMPID"]) + "'";
                    //        DT_grid = DT_grid.DefaultView.ToTable();
                    //        Rg_ExpenseTrans.DataSource = DT_grid;
                    //        clearControls();
                    //    }

                    //    if (Session["DASHBOARD"] != null)
                    //    {
                    //        Rm_RT_page.SelectedIndex = 1;
                    //        lnk_Add_Command(null, null);
                    //    }
                    //}
                    //else
                    //{
                    SMHR_EXPENSE _obj_smhr_expense = new SMHR_EXPENSE();
                    _obj_smhr_expense.EXPENSE_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                    DataTable dt_details = BLL.get_EmpExpenseTrans(_obj_smhr_expense);
                    Rg_ExpenseTrans.DataSource = dt_details;

                    //if (Session["DASHBOARD"] != null)
                    //{
                    //    Rm_RT_page.SelectedIndex = 1;
                    //    lnk_Add_Command(null, null);
                    //}
                    //}
                }
            }
            else
            {
                _obj_Smhr_Expense = new SMHR_EXPENSE();
                _obj_Smhr_Expense.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable DT_grid = BLL.get_Expense(_obj_Smhr_Expense);
                Rg_ExpenseTrans.DataSource = DT_grid;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ExpenseTrans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        //clearControls();
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt_dtl_Save = (DataTable)ViewState["DTEXPDTL"];

            if (dt_dtl_Save.Rows.Count != 0)
            {

                SMHR_EXPENSEDETAIL _obj_Smhr_ExpenseDetail;
                string TempQuery;
                _obj_Smhr_Expense = new SMHR_EXPENSE();
                _obj_Smhr_Expense.EXPENSE_APPDATE = Convert.ToDateTime(rdp_AppliedDate.SelectedDate);
                _obj_Smhr_Expense.EXPENSE_NAME = BLL.ReplaceQuote(rtxt_ExpenseName.Text);
                _obj_Smhr_Expense.EXPENSE_EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedItem.Value);
                _obj_Smhr_Expense.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
                _obj_Smhr_Expense.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                _obj_Smhr_Expense.CREATEDDATE = DateTime.Now;
                _obj_Smhr_Expense.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
                _obj_Smhr_Expense.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                _obj_Smhr_Expense.LASTMDFDATE = DateTime.Now;

                switch (((Button)sender).ID.ToUpper())
                {
                    case "BTN_SAVE":
                        SMHR_EMPLOYEE1 _obj_SMHR_EMPLOYEE1 = new SMHR_EMPLOYEE1();
                        _obj_SMHR_EMPLOYEE1.MODE = 13;

                        _obj_SMHR_EMPLOYEE1.EMP_ID = Convert.ToString(rcmb_Employee.SelectedItem.Value);


                        DataTable dtdoj = Pms_Bll.get_Employee1(_obj_SMHR_EMPLOYEE1);
                        if (Convert.ToDateTime(rdp_AppliedDate.SelectedDate) > (Convert.ToDateTime(dtdoj.Rows[0]["EMP_DOJ"])))
                        {


                            _obj_Smhr_Expense.OPERATION = operation.Insert;

                            TempQuery = " DECLARE @TEMP INT \n SET @TEMP = IDENT_CURRENT('SMHR_EXPENSE') \n";

                            foreach (DataRow item in dt_dtl_Save.Rows)
                            {
                                _obj_Smhr_ExpenseDetail = new SMHR_EXPENSEDETAIL();
                                _obj_Smhr_ExpenseDetail.OPERATION = operation.Insert;
                                _obj_Smhr_ExpenseDetail.EXPENSEDTL_TYPE_ID = Convert.ToInt32(item["EXPENSEDTL_TYPE_ID"]);
                                _obj_Smhr_ExpenseDetail.EXPENSEDTL_EXPENSEDATE = Convert.ToDateTime(item["EXPENSEDTL_EXPENSEDATE"]);
                                _obj_Smhr_ExpenseDetail.EXPENSEDTL_AMOUNT = decimal.Parse(Convert.ToString(item["EXPENSEDTL_AMOUNT"]));
                                _obj_Smhr_ExpenseDetail.EXPENSEDTL_CURRID = Convert.ToInt32(item["EXPENSEDTL_CURRID"]);
                                _obj_Smhr_ExpenseDetail.EXPENSEDTL_DESC = BLL.ReplaceQuote(Convert.ToString(item["EXPENSEDTL_DESC"]));

                                _obj_Smhr_ExpenseDetail.EXPENSEDTL_ATTACHMENT = Convert.ToString(item["EXPENSEDTL_ATTACHMENT"]);

                                _obj_Smhr_ExpenseDetail.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                                _obj_Smhr_ExpenseDetail.CREATEDDATE = DateTime.Now;
                                _obj_Smhr_ExpenseDetail.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                                _obj_Smhr_ExpenseDetail.LASTMDFDATE = DateTime.Now;
                                _obj_Smhr_ExpenseDetail.EXPENSEDTL_STATUS = 0;
                                TempQuery = TempQuery + BLL.set_ExpenseDetail(_obj_Smhr_ExpenseDetail);
                            }

                            status = get_DOJ();
                            if (status == true)
                            {
                                _obj_Smhr_Expense.QUERY = BLL.ReplaceQuote(TempQuery);

                                if (BLL.set_Expense(_obj_Smhr_Expense))
                                    BLL.ShowMessage(this, "Information Updated Successfully");
                                else
                                    BLL.ShowMessage(this, "Information Not Saved");
                            }
                            else
                            {
                                BLL.ShowMessage(this, "expense date cannot be less than date of joining");
                            }
                        }

                        else
                        {
                            BLL.ShowMessage(this, "expense date cannot be less than date of joining");
                        }
                        break;
                    case "BTN_EDIT":
                        _obj_SMHR_EMPLOYEE1 = new SMHR_EMPLOYEE1();
                        _obj_SMHR_EMPLOYEE1.MODE = 13;

                        _obj_SMHR_EMPLOYEE1.EMP_ID = Convert.ToString(rcmb_Employee.SelectedItem.Value);


                        DataTable dtdoj2 = Pms_Bll.get_Employee1(_obj_SMHR_EMPLOYEE1);
                        if (Convert.ToDateTime(rdp_AppliedDate.SelectedDate) > (Convert.ToDateTime(dtdoj2.Rows[0]["EMP_DOJ"])))
                        {
                            _obj_Smhr_Expense.OPERATION = operation.Update;
                            _obj_Smhr_Expense.EXPENSE_ID = Convert.ToInt32(lbl_ExpenseID.Text);
                            TempQuery = " DECLARE @TEMP INT \n SET @TEMP = '" + Convert.ToString(lbl_ExpenseID.Text) + "' \n";

                            foreach (DataRow item in dt_dtl_Save.Rows)
                            {
                                _obj_Smhr_ExpenseDetail = new SMHR_EXPENSEDETAIL();

                                if (Convert.ToString(item["EXPENSEDTL_ID"]) == "0")
                                {
                                    _obj_Smhr_ExpenseDetail.OPERATION = operation.Insert;
                                }
                                else
                                {
                                    _obj_Smhr_ExpenseDetail.OPERATION = operation.Update;
                                    _obj_Smhr_ExpenseDetail.EXPENSEDTL_ID = Convert.ToInt32(item["EXPENSEDTL_ID"]);
                                }

                                _obj_Smhr_ExpenseDetail.EXPENSEDTL_EXPENSE_ID = Convert.ToInt32(lbl_ExpenseID.Text);
                                _obj_Smhr_ExpenseDetail.EXPENSEDTL_TYPE_ID = Convert.ToInt32(item["EXPENSEDTL_TYPE_ID"]);
                                _obj_Smhr_ExpenseDetail.EXPENSEDTL_EXPENSEDATE = Convert.ToDateTime(item["EXPENSEDTL_EXPENSEDATE"]);
                                _obj_Smhr_ExpenseDetail.EXPENSEDTL_AMOUNT = decimal.Parse(Convert.ToString(item["EXPENSEDTL_AMOUNT"]));
                                _obj_Smhr_ExpenseDetail.EXPENSEDTL_CURRID = Convert.ToInt32(item["EXPENSEDTL_CURRID"]);
                                _obj_Smhr_ExpenseDetail.EXPENSEDTL_DESC = BLL.ReplaceQuote(Convert.ToString(item["EXPENSEDTL_DESC"]));

                                _obj_Smhr_ExpenseDetail.EXPENSEDTL_ATTACHMENT = Convert.ToString(item["EXPENSEDTL_ATTACHMENT"]);

                                _obj_Smhr_ExpenseDetail.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                                _obj_Smhr_ExpenseDetail.CREATEDDATE = DateTime.Now;
                                _obj_Smhr_ExpenseDetail.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                                _obj_Smhr_ExpenseDetail.LASTMDFDATE = DateTime.Now;

                                TempQuery = TempQuery + BLL.set_ExpenseDetail(_obj_Smhr_ExpenseDetail);
                            }

                            status = get_DOJ();
                            if (status == true)
                            {
                                _obj_Smhr_Expense.QUERY = BLL.ReplaceQuote(TempQuery);

                                if (BLL.set_Expense(_obj_Smhr_Expense))
                                    BLL.ShowMessage(this, "Information Updated Successfully");
                                else
                                    BLL.ShowMessage(this, "Information Not Saved");
                            }
                            else
                            {
                                BLL.ShowMessage(this, "expense date cannot be less than date of joining");
                            }
                        }

                        else
                        {
                            BLL.ShowMessage(this, "expense date cannot be less than date of joining");
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                BLL.ShowMessage(this, "Please Add More details to proceed further.....");
                return;
            }

            //btn_Cancel_Click(null, null);

            clearControls();
            DataTable dt = (DataTable)ViewState["DTEXPDTL"];
            dt.Rows.Clear();
            Rg_ExpenseDetails.DataSource = dt;
            Rg_ExpenseDetails.DataBind();


            Rm_RT_page.SelectedIndex = 0;
            LoadGrid();
            Rg_ExpenseTrans.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ExpenseTrans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearControls();
            DataTable dt = (DataTable)ViewState["DTEXPDTL"];
            dt.Rows.Clear();
            Rg_ExpenseDetails.DataSource = dt;
            Rg_ExpenseDetails.DataBind();
            //bool status = Convert.ToBoolean(Session["checkRole"]);
            //if (Session["DASHBOARD"] != null)
            //{
            //    if (status == true)
            //    {

            //        Response.Redirect("~/Security/frm_Dashboard.aspx", false);
            //    }
            //    else
            //    {

            //        Response.Redirect("~/Security/frm_Dashboradmngr.aspx", false);
            //    }
            //}
            //else
            //{
            //    DataTable dt = (DataTable)ViewState["DTEXPDTL"];
            //    dt.Rows.Clear();
            //    Rg_ExpenseDetails.DataSource = dt;
            //    Rg_ExpenseDetails.DataBind();
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ExpenseTrans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        //clearControls();
        //DataTable dt = (DataTable)ViewState["DTEXPDTL"];
        //dt.Rows.Clear();
        //Rg_ExpenseDetails.DataSource = dt;
        //Rg_ExpenseDetails.DataBind();
    }

    protected void Rg_ExpenseTrans_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ExpenseTrans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Rg_ExpenseDetails_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            Rg_ExpenseDetails.DataSource = (DataTable)ViewState["DTEXPDTL"];
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ExpenseTrans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Get_Table()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = BLL.get_ExpenseDetails(new SMHR_EXPENSEDETAIL());
            dt.Rows.Clear();
            ViewState["DTEXPDTL"] = dt;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ExpenseTrans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Details_Save_Click(object sender, EventArgs e)
    {
        try
        {
            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_DETAILS_EDIT":
                    DataTable dt_edit = (DataTable)ViewState["DTEXPDTL"];
                    int Index = Convert.ToInt32(lbl_Sno.Text) - 1;

                    dt_edit.Rows[Index]["SNO"] = lbl_Sno.Text;
                    dt_edit.Rows[Index]["EXPENSEDTL_ID"] = Convert.ToInt32(lbl_ExpenseDetailsID.Text);
                    dt_edit.Rows[Index]["EXPENSEDTL_TYPE_ID"] = Convert.ToInt32(rcmb_ExpenseType.SelectedItem.Value);
                    dt_edit.Rows[Index]["_EXPENSEDTL_TYPE_ID"] = Convert.ToString(rcmb_ExpenseType.SelectedItem.Text);
                    dt_edit.Rows[Index]["EXPENSEDTL_EXPENSEDATE"] = Convert.ToString(Convert.ToDateTime(rdp_ExpenseDate.SelectedDate));
                    dt_edit.Rows[Index]["EXPENSEDTL_AMOUNT"] = Convert.ToString(decimal.Parse(rtxt_ExpenseAmt.Text));
                    dt_edit.Rows[Index]["EXPENSEDTL_CURRID"] = Convert.ToString(Convert.ToInt32(rcmb_ExpenseCurrency.SelectedItem.Value));
                    dt_edit.Rows[Index]["_EXPENSEDTL_CURRID"] = Convert.ToString(rcmb_ExpenseCurrency.SelectedItem.Text);
                    dt_edit.Rows[Index]["EXPENSEDTL_DESC"] = BLL.ReplaceQuote(rtxt_Description.Text);

                    ViewState["ExpenseDate"] = Convert.ToString(rdp_ExpenseDate.SelectedDate);
                    if (!string.IsNullOrEmpty(fup_ExpenseUpload.PostedFile.FileName))
                    {
                        fup_ExpenseUpload.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Attachments"), DateTime.Now.ToString("yyyy_MM_dd_hh_mm_") + fup_ExpenseUpload.FileName));
                        dt_edit.Rows[Index]["EXPENSEDTL_ATTACHMENT"] = "~/Attachments/" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_") + fup_ExpenseUpload.FileName;
                    }
                    else
                    {
                        if (ViewState["fileLocation"] != null)
                            dt_edit.Rows[Index]["EXPENSEDTL_ATTACHMENT"] = Convert.ToString(ViewState["fileLocation"]);
                    }
                    bool status = get_DOJ();
                    if (status == true)
                    {
                        ViewState["DTEXPDTL"] = dt_edit;
                        Rg_ExpenseDetails.DataSource = dt_edit;
                        Rg_ExpenseDetails.DataBind();
                        _clearControls();
                    }
                    else
                    {
                        BLL.ShowMessage(this, "expense date cannot be less than date of joining");
                    }
                    break;
                case "BTN_DETAILS_SAVE":
                    DataTable dt_save = (DataTable)ViewState["DTEXPDTL"];

                    DataRow dr = dt_save.NewRow();
                    dr["SNO"] = Convert.ToString(dt_save.Rows.Count + 1);
                    dr["EXPENSEDTL_ID"] = 0;
                    dr["EXPENSEDTL_TYPE_ID"] = Convert.ToString(Convert.ToInt32(rcmb_ExpenseType.SelectedItem.Value));
                    dr["_EXPENSEDTL_TYPE_ID"] = Convert.ToString(rcmb_ExpenseType.SelectedItem.Text);
                    dr["EXPENSEDTL_EXPENSEDATE"] = Convert.ToString(Convert.ToDateTime(rdp_ExpenseDate.SelectedDate));
                    dr["EXPENSEDTL_AMOUNT"] = Convert.ToString(decimal.Parse(rtxt_ExpenseAmt.Text));
                    dr["EXPENSEDTL_CURRID"] = Convert.ToString(Convert.ToInt32(rcmb_ExpenseCurrency.SelectedItem.Value));
                    dr["_EXPENSEDTL_CURRID"] = Convert.ToString(rcmb_ExpenseCurrency.SelectedItem.Text);
                    dr["EXPENSEDTL_DESC"] = BLL.ReplaceQuote(rtxt_Description.Text);

                    ViewState["ExpenseDate"] = Convert.ToString(rdp_ExpenseDate.SelectedDate);

                    if (!string.IsNullOrEmpty(fup_ExpenseUpload.PostedFile.FileName))
                    {
                        fup_ExpenseUpload.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Attachments"), DateTime.Now.ToString("yyyy_MM_dd_hh_mm_") + fup_ExpenseUpload.FileName));
                        dr["EXPENSEDTL_ATTACHMENT"] = "~/Attachments/" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_") + fup_ExpenseUpload.FileName;
                        ViewState["fileLocation"] = Convert.ToString(dr["EXPENSEDTL_ATTACHMENT"]);
                    }
                    else
                    {
                        dr["EXPENSEDTL_ATTACHMENT"] = "";
                    }

                    status = get_DOJ();
                    if (status == true)
                    {
                        dt_save.Rows.Add(dr);
                        ViewState["DTEXPDTL"] = dt_save;
                        Rg_ExpenseDetails.DataSource = dt_save;
                        Rg_ExpenseDetails.DataBind();
                        _clearControls();
                    }
                    else
                    {
                        BLL.ShowMessage(this, "expense date and applied date should not be less than date of joining");
                    }
                    break;
                default:
                    break;
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ExpenseTrans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void btn_Details_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            _clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ExpenseTrans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_BusinessUnit_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            //if (Convert.ToInt32(Session["EMP_ID"]) == 0)
            //{
            DataTable dt_getEMP = new DataTable();
            rcmb_Employee.Items.Clear();
            //SMHR_EMPCOMOFF _obj_smhr_compoff = new SMHR_EMPCOMOFF();
            //_obj_smhr_compoff.BUID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
            //_obj_smhr_compoff.OPERATION = operation.Empty;

            //rcmb_Employee.DataSource = BLL.get_empcompffs(_obj_smhr_compoff);
            //rcmb_Employee.DataTextField = "EMPNAME";
            //rcmb_Employee.DataValueField = "EMP_ID";
            //rcmb_Employee.DataBind();
            //rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.OPERATION = operation.Check;
            string str_BusinessUnit_ID = Convert.ToString(rcmb_BusinessUnit.SelectedValue).ToUpper();
            _obj_SMHR_LoginInfo.OPERATION = operation.Check;
            _obj_SMHR_LoginInfo.BUID = Convert.ToInt32(str_BusinessUnit_ID);
            dt_getEMP = BLL.get_Sup_BusinessUnit(_obj_SMHR_LoginInfo);
            //ViewState["DTLEMP"] = dt_getEMP.Rows[0]["EMP_ID"];
            rcmb_Employee.Items.Clear();
            rcmb_Employee.DataSource = dt_getEMP;
            rcmb_Employee.DataTextField = "EMP_NAME";
            rcmb_Employee.DataValueField = "EMP_ID";
            rcmb_Employee.DataBind();
            rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            //}
            //else
            //{
            //    //FOR MANAGER
            //    rcmb_Employee.Items.Clear();
            //    SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
            //    _obj_smhr_emp_payitems.OPERATION = operation.Empty_Self;
            //    _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
            //    _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //    _obj_smhr_emp_payitems.REPORTING_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            //    DataTable DT_Details = BLL.get_EmpDetails(_obj_smhr_emp_payitems);//NOT NEEDED AS WE ARE LOADING RELAVENT TO ORG.
            //    if (DT_Details.Rows.Count != 0)
            //    {
            //        rcmb_Employee.DataSource = DT_Details;
            //        rcmb_Employee.DataTextField = "EMPNAME";
            //        rcmb_Employee.DataValueField = "EMP_ID";
            //        rcmb_Employee.DataBind();
            //        rcmb_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
            //    }
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ExpenseTrans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Currency_Refresh_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            SMHR_CURRENCY _obj_Currency = new SMHR_CURRENCY();
            _obj_Currency.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            rcmb_ExpenseCurrency.Items.Clear();
            rcmb_ExpenseCurrency.DataSource = BLL.get_Currency(_obj_Currency);
            rcmb_ExpenseCurrency.DataTextField = "CURR_CODE";
            rcmb_ExpenseCurrency.DataValueField = "CURR_ID";
            rcmb_ExpenseCurrency.DataBind();
            rcmb_ExpenseCurrency.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ExpenseTrans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_ExpenseType_Refresh_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            SMHR_MASTERS _obj_smhr_masters = new SMHR_MASTERS();
            _obj_smhr_masters.MASTER_TYPE = "EXPENSE";
            _obj_smhr_masters.OPERATION = operation.Select;
            _obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_MasterRecords(_obj_smhr_masters);
            rcmb_ExpenseType.DataSource = dt;
            rcmb_ExpenseType.DataTextField = "HR_MASTER_CODE";
            rcmb_ExpenseType.DataValueField = "HR_MASTER_ID";
            rcmb_ExpenseType.DataBind();
            rcmb_ExpenseType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ExpenseTrans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected bool get_DOJ()
    {
        try
        {
            //string str_ExpenseDate = Convert.ToString(ViewState["ExpenseDate"]);
            DateTime str_ExpenseDate = Convert.ToDateTime(ViewState["ExpenseDate"]);
            SMHR_EMPLOYEE obj_smhr_employee = new SMHR_EMPLOYEE();
            ViewState["DTLEMP"] = rcmb_Employee.SelectedItem.Value;
            obj_smhr_employee.OPERATION = operation.Select;
            obj_smhr_employee.EMP_ID = Convert.ToInt32(ViewState["DTLEMP"]);
            obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_EMP = BLL.get_Employee(obj_smhr_employee);
            if (dt_EMP.Rows.Count != 0)
            {
                if ((Convert.ToDateTime(dt_EMP.Rows[0]["EMP_DOJ"])) < (Convert.ToDateTime(str_ExpenseDate)) && (Convert.ToDateTime(dt_EMP.Rows[0]["EMP_DOJ"])) < (Convert.ToDateTime(rdp_AppliedDate.SelectedDate)))
                {
                    return true;
                }
                //else if ((Convert.ToDateTime(dt_EMP.Rows[0]["EMP_DOJ"])) < (Convert.ToDateTime(rdp_AppliedDate.SelectedDate)))
                //{
                //    return true;
                //}
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ExpenseTrans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return false;
        }
    }
}
