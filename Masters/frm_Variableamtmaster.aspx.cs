using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SMHR;
using Telerik.Web.UI;

public partial class Masters_frm_Variableamtmaster : System.Web.UI.Page
{
    #region References
    /// <summary>
    /// Declaration of classes and also there object with Intialisation
    /// </summary>
    SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
    SMHR_PERIOD _obj_smhr_period = new SMHR_PERIOD();
    SMHR_VARIABLEAMT _obj_vamt = new SMHR_VARIABLEAMT();
    DataTable dt_Result = new DataTable();
    DataTable dt_Compare = new DataTable();
    #endregion

    #region Page Load
    /// <summary>
    /// Loading The Business Units and also the Financial Periods to that particular Oragnisation
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (!IsPostBack)
            {
                _obj_vamt.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                _obj_vamt.user_id = Convert.ToInt32(Session["USER_ID"].ToString());
                _obj_vamt.OPERATION = operation.Check;
                rcmb_Businessunit.Items.Clear();
                dt_Result = BLL.get_Employeevariableamt(_obj_vamt);
                rcmb_Businessunit.DataSource = dt_Result;
                rcmb_Businessunit.DataTextField = "BUSINESSUNIT_CODE";
                rcmb_Businessunit.DataValueField = "BUSINESSUNIT_ID";
                rcmb_Businessunit.DataBind();
                rcmb_Businessunit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

                _obj_smhr_period.OPERATION = operation.Select;//Method Related To Bonus
                _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                dt_Result = BLL.get_PeriodHeaderDetails(_obj_smhr_period);
                rcmb_FinancialPeriod.DataSource = dt_Result;
                rcmb_FinancialPeriod.DataValueField = "PERIOD_ID";
                rcmb_FinancialPeriod.DataTextField = "PERIOD_NAME";
                rcmb_FinancialPeriod.DataBind();
                rcmb_FinancialPeriod.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                RG_Variableallowance.Visible = false;
                btn_Save.Visible = false;
                btn_Update.Visible = false;


                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Variable Pay Master");//COUNTRY");
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
                    RG_Variableallowance.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Variableamtmaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


    }
    #endregion

    #region Load Methods

    /// <summary>
    /// This method will load all employees who are having the variable pay
    /// </summary>
    protected void Loadgrid()
    {
        try
        {
            _obj_vamt.OPERATION = operation.Select;
            _obj_vamt.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_vamt.BUID = Convert.ToInt32(rcmb_Businessunit.SelectedValue);
            rcmb_FinancialPeriod.Enabled = false;
            rcmb_Businessunit.Enabled = false;
            dt_Result = BLL.get_Employeevariableamt(_obj_vamt);//GETTING ALL EMPLOYEES WHO ARE HAVING VARIABLE PAY
            if (dt_Result.Rows.Count > 0)
            {
                RG_Variableallowance.DataSource = dt_Result;
            }
            else
            {
                if ((rcmb_Businessunit.SelectedIndex > 0) && (rcmb_FinancialPeriod.SelectedIndex > 0))
                    BLL.ShowMessage(this, "No Employee Is Having Variable Pay!");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Variableamtmaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    /// <summary>
    /// This method will load the period elements which are under that financial period
    /// </summary>
    protected void Load_Periodelements()
    {
        try
        {
            CheckBoxList c = new CheckBoxList();
            _obj_vamt.financial_period = Convert.ToInt32(rcmb_FinancialPeriod.SelectedValue);
            dt_Compare = BLL.get_Employeevariableamt(_obj_vamt);//FOR LOADING PERIOD UNDER THE FINANCIAL PERIODS
            for (int i = 0; i < RG_Variableallowance.Items.Count; i++)
            {
                c = (CheckBoxList)RG_Variableallowance.Items[i].FindControl("chk_Periods");
                c.DataSource = dt_Compare;
                c.DataTextField = "PRDDTL_NAME";
                c.DataValueField = "PRDDTL_ID";
                c.DataBind();
                //GridColumn periods = (GridColumn)c.Parent;
                Label selectedcount = (Label)RG_Variableallowance.Items[i].FindControl("lbl_Vary");
                selectedcount.Text = Convert.ToString(0);
                selectedcount.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Variableamtmaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    /// <summary>
    /// This method will load the employee who are already selected their periods for the selected
    /// financial period
    /// </summary>
    protected void Loadempdata()
    {
        try
        {
            string checkedvalue = "";
            bool check = false;
            _obj_vamt.OPERATION = operation.Edit;
            _obj_vamt.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_vamt.BUID = Convert.ToInt32(rcmb_Businessunit.SelectedValue);
            DataTable dt_Verify = new DataTable();
            dt_Verify = BLL.get_Employeevariableamt(_obj_vamt);//CHECKING EMPLOYEES WHO ARE THERE FOR THAT FINANCIAL PERIOD ALREADY
            //for (int index = 0; (dt_Verify.Rows.Count > index) && (RG_Variableallowance.Items.Count > index); index++)
            for (int index = 0; (RG_Variableallowance.Items.Count > index); index++)
            {
                Label selectedcountv = (Label)RG_Variableallowance.Items[index].FindControl("lbl_Vary");
                Label selectedcounts = (Label)RG_Variableallowance.Items[index].FindControl("lbl_Same");
                Label count = (Label)RG_Variableallowance.Items[index].FindControl("lbl_Count");
                for (int increment = 0; increment < dt_Verify.Rows.Count; increment++)
                {
                    if (RG_Variableallowance.Items[index]["EMP_ID"].Text.ToString() == dt_Verify.Rows[increment]["EMP_ID"].ToString())
                    {
                        checkedvalue = Convert.ToString(dt_Verify.Rows[increment]["EMP_PAYABLEPERIOD"]);
                        _obj_vamt.financial_period = Convert.ToInt32(rcmb_FinancialPeriod.SelectedValue);
                        _obj_vamt.selected_period = checkedvalue;
                        dt_Result = BLL.get_CheckedPeriods(_obj_vamt);//GETTING THE LIST OF PERIODS THAT EMPLOYEE HAS PREVIOUSLY
                        CheckBoxList chklist = new CheckBoxList();
                        chklist = (CheckBoxList)RG_Variableallowance.Items[index].FindControl("chk_Periods");
                        int selectedlist = dt_Result.Rows.Count;
                        if (selectedlist == Convert.ToInt32(count.Text))
                        {
                            selectedcounts.Text = Convert.ToString(selectedlist);
                            selectedcountv.Visible = false;
                            selectedcounts.Visible = true;
                        }
                        else
                        {
                            selectedcountv.Text = Convert.ToString(selectedlist);
                            selectedcountv.Visible = true;
                            selectedcounts.Visible = false;
                        }
                        for (int Selected = 0, temp = 0; (Selected < chklist.Items.Count) && (temp < selectedlist); Selected++)
                        {
                            int i = Convert.ToInt32(dt_Result.Rows[temp]["PRDDTL_ID"].ToString());
                            if (Convert.ToInt32(chklist.Items[Selected].Value) == i)
                            {
                                chklist.Items[Selected].Selected = true;
                                temp++;
                            }
                        }
                        check = true;
                        btn_Update.Visible = true;
                        btn_Save.Visible = false;
                    }
                }
            }

            if (!check)
            {
                btn_Save.Visible = true;
                btn_Update.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Variableamtmaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    /// <summary>
    /// If the payable periods of an employee is exceeds or less than the selection
    /// we alert the user by asking do you want to proceed.
    /// </summary>
    protected void Confirm_Save()
    {
        try
        {
            bool status = false;
            string selectedcount = "";
            for (int row = 0; row < RG_Variableallowance.Items.Count; row++)
            {
                Label count = (Label)RG_Variableallowance.Items[row].FindControl("lbl_Vary");
                Label same = (Label)RG_Variableallowance.Items[row].FindControl("lbl_Same");
                if (same.Text != string.Empty)
                {
                    status = true;
                }
                else
                {
                    if (count.Text != string.Empty)
                    {
                        if (selectedcount == "")
                        { selectedcount = Convert.ToString(row); }
                        else
                        { selectedcount = selectedcount + "," + Convert.ToString(row); }
                        status = true;
                    }
                }
            }
            ViewState["Confirm"] = "";
            if ((selectedcount != string.Empty) && (status))
            {
                BLL.ShowMessage(this, "You Have Exceeded or not Selected the Specified Range of Count For Some Employees");
                ViewState["Confirm"] = "Yes";
                //return;
                //System.Windows.Forms.DialogResult dialog ;
                //dialog= System.Windows.Forms.MessageBox.Show("You Have Exceeded or not Selected the Specified Range of Count For Some Employees","Do You Want to Proceed", System.Windows.Forms.MessageBoxButtons.YesNo);
                //if (dialog == System.Windows.Forms.DialogResult.Yes)
                //{
                //    ViewState["Confirm"] = "Yes";
                //}
                //else
                //{
                //    ViewState["Confirm"] = "No";
                //}
            }
            else
            {
                if (!status)
                    BLL.ShowMessage(this, "Select Periods For All Employees");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Variableamtmaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region Selected Index Methods
    /// <summary>
    /// We are checking businessunit,financial period selected or not 
    /// and also Loading The employees Who Are Having Variable amount and Belongs To the Selected Businessunit
    /// </summary>
    /// <param name="o"></param>
    /// <param name="e"></param>
    protected void rcmb_FinancialPeriod_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {

            if ((rcmb_Businessunit.SelectedIndex > 0) && (rcmb_FinancialPeriod.SelectedIndex > 0))
            {
                RG_Variableallowance.Visible = true;
                Loadgrid();
                RG_Variableallowance.DataBind();
                Load_Periodelements();
                Loadempdata();
            }
            else
            {
                BLL.ShowMessage(this, "Select Proper Business Unit and Financial Period");
                rcmb_FinancialPeriod.ClearSelection();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Variableamtmaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    /// <summary>
    /// This method will check whether a particular employee is joined for the selected period or not
    /// if he is not joined then we are disabling that checkbox for that employee.
    /// here we also checking the count of payable periods and intimate the user if he exceeds the count.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chk_Periods_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int count = 0;
            CheckBoxList chk_period = sender as CheckBoxList;
            GridItem row;
            row = (GridItem)chk_period.Parent.Parent;
            for (int checkedpayitems = 0; checkedpayitems < chk_period.Items.Count; checkedpayitems++)
            {
                _obj_vamt.emp_period = Convert.ToInt32(chk_period.Items[checkedpayitems].Value);
                _obj_vamt.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                GridItem ROW = (GridItem)chk_period.Parent.Parent;
                _obj_vamt.emp_id = Convert.ToInt32(ROW.Cells[3].Text);
                _obj_vamt.financial_period = Convert.ToInt32(rcmb_FinancialPeriod.SelectedValue);
                _obj_vamt.BUID = Convert.ToInt32(rcmb_Businessunit.SelectedItem.Value);
                if (chk_period.Items[checkedpayitems].Selected)
                {
                    _obj_vamt.OPERATION = operation.Validate1;
                    // FOR CHECKING THE EXISTANCE OF THE EMPLOYEE DURING THE CHECKED PERIOD
                    dt_Compare = BLL.get_empdoj(_obj_vamt);//need to write a method in bll
                    if (dt_Compare.Rows[0][0].ToString() == Convert.ToString("TRUE"))
                    {
                        ////TO CHECK WHETHER PAYROLL IS APPROVED FOR SELECTED PERIOD ELEMENT OR NOT
                        //_obj_vamt.OPERATION = operation.Empty1;
                        //DataTable dt_payroll = BLL.get_empdoj(_obj_vamt);
                        //if (dt_payroll.Rows.Count > 0)
                        //{
                        //    BLL.ShowMessage(this, "Payroll is Approved for this Period Element.Please Select other Element.");
                        //    chk_period.Items[checkedpayitems].Selected = false;
                        //    chk_period.Items[checkedpayitems].Enabled = false;

                        //}
                        //else
                        //{
                        count += 1;
                        //}

                    }
                    else
                    {
                        chk_period.Items[checkedpayitems].Selected = false;
                        chk_period.Items[checkedpayitems].Enabled = false;
                        BLL.ShowMessage(this, "Employee is not Joined in to the Organisation For The Selected Period");
                    }
                }
                else
                {
                    // FOR CHECKING WHETHER THAT PARTICULAR PERIOD IS FINALISED OR NOT IN PERFORMANCE BONUS SCREEN FOR PARTICULAR EMPLOYEE 
                    _obj_vamt.OPERATION = operation.Check_New;
                    dt_Compare = BLL.get_empdoj(_obj_vamt);
                    if (dt_Compare.Rows[0][0].ToString() == Convert.ToString("TRUE"))
                    {
                        chk_period.Items[checkedpayitems].Selected = true;
                        chk_period.Items[checkedpayitems].Enabled = false;
                        BLL.ShowMessage(this, "This Employee is already Finalised For The Selected Period");
                    }
                }
            }
            _obj_vamt.OPERATION = operation.Empty2;
            DataTable dt_periods = BLL.get_empdoj(_obj_vamt);
            string str_period;
            int index = 0;
            if (dt_periods.Rows.Count > 0)
            {
                string str = Convert.ToString(dt_periods.Rows[0]["EMP_PAYABLEPERIOD"]);
                int flag;
                for (int i = 0; i < chk_period.Items.Count; i++)
                {
                    flag = 0;
                    if (chk_period.Items[i].Selected)
                    {
                        foreach (string item in str.Split(new char[] { ',' }))
                        {
                            if (item != "" && item == Convert.ToString(chk_period.Items[i].Value))
                            {
                                flag = 1;
                                break;
                            }

                        }
                        if (flag == 0)
                        {
                            str_period = Convert.ToString(chk_period.Items[i].Value);
                            index = i;
                        }
                    }
                }
            }
            //TO CHECK WHETHER PAYROLL IS APPROVED FOR SELECTED PERIOD ELEMENT OR NOT
            _obj_vamt.OPERATION = operation.Empty1;
            DataTable dt_payroll = BLL.get_empdoj(_obj_vamt);
            if (dt_payroll.Rows.Count > 0)
            {
                BLL.ShowMessage(this, "Payroll is Approved for this Period Element.Please Select other Element.");
                chk_period.Items[index].Selected = false;
                chk_period.Items[index].Enabled = false;
                count -= 1;

            }
            Label lbl_counts = (Label)row.FindControl("lbl_Count");
            Label lbl_same = (Label)row.FindControl("lbl_Same");
            Label lbl_diff = (Label)row.FindControl("lbl_Vary");
            if (Convert.ToInt32(lbl_counts.Text) != count)
            {
                lbl_same.Visible = false;
                lbl_same.Text = string.Empty;
                lbl_diff.Text = Convert.ToString(count);
                lbl_diff.Visible = true;
            }
            else
            {
                lbl_diff.Visible = false;
                lbl_diff.Text = string.Empty;
                lbl_same.Text = Convert.ToString(count);
                lbl_same.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Variableamtmaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void RG_Variableallowance_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            Loadgrid();
            Load_Periodelements();
            Loadempdata();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Variableamtmaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    #region Button Clicks
    /// <summary>
    /// THIS REGION WILL CONTAINS WHAT SHOULD HAPPEN WHEN A BUTTON IS RAISED AN EVENT
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            rcmb_Businessunit.ClearSelection();
            rcmb_FinancialPeriod.ClearSelection();
            RG_Variableallowance.Visible = false;
            btn_Update.Visible = false;
            btn_Save.Visible = false;
            rcmb_Businessunit.Enabled = true;
            rcmb_FinancialPeriod.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Variableamtmaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    /// <summary>
    /// saving each record with the corresponding periods that an employee has
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            int Count = 0;
            bool status = false;
            string row_no = string.Empty;
            string periods = "";
            if (RG_Variableallowance.Items.Count > 0)
            {
                Confirm_Save();
                string result = ViewState["Confirm"] as string;
                if ((result == "Yes") || (result == "No"))
                {
                    if (result != "Yes")
                    {
                        BLL.ShowMessage(this, "Aborted By the User");
                        return;
                    }
                }
                for (int rows = 0; rows < RG_Variableallowance.Items.Count; rows++)
                {
                    _obj_vamt.emp_id = Convert.ToInt32(RG_Variableallowance.Items[rows]["EMP_ID"].Text);
                    _obj_vamt.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_vamt.BUID = Convert.ToInt32(rcmb_Businessunit.SelectedValue);
                    _obj_vamt.financial_period = Convert.ToInt32(rcmb_FinancialPeriod.SelectedValue);
                    double va = 0;
                    int countva = 0;
                    Label amount = (Label)RG_Variableallowance.Items[rows].FindControl("lbl_Amount");
                    Label count = (Label)RG_Variableallowance.Items[rows].FindControl("lbl_Vary");
                    if (count.Text != string.Empty)
                    {
                        countva = Convert.ToInt32(count.Text);
                    }
                    else
                    {
                        Label scount = (Label)RG_Variableallowance.Items[rows].FindControl("lbl_Same");
                        if (scount.Text != string.Empty)
                            countva = Convert.ToInt32(scount.Text);
                    }
                    va = Convert.ToDouble(amount.Text);

                    _obj_vamt.emp_va = va;
                    _obj_vamt.emp_countva = countva;
                    _obj_vamt.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_vamt.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    CheckBoxList chk_lst = new CheckBoxList();
                    chk_lst = (CheckBoxList)RG_Variableallowance.Items[rows].FindControl("chk_Periods");
                    for (int payableperiods = 0; payableperiods < chk_lst.Items.Count; payableperiods++)
                    {
                        if (chk_lst.Items[payableperiods].Selected)
                        {
                            if (periods == "")
                                periods = Convert.ToString(chk_lst.Items[payableperiods].Value);
                            else
                                periods = periods + "," + Convert.ToString(chk_lst.Items[payableperiods].Value);
                        }
                    }
                    _obj_vamt.selected_period = periods;
                    status = BLL.set_Empvaraiablamtmaster(_obj_vamt);
                    if (periods != string.Empty)
                    {
                        //_obj_vamt.selected_period = periods;
                        //status = BLL.set_Empvaraiablamtmaster(_obj_vamt);                          
                        //RG_Variableallowance.Items[rows].Visible = false;
                        //RG_Variableallowance.Items[rows].RemoveChildSelectedItems();
                        periods = "";
                        Count += 1;
                    }
                    else
                    {
                        if (row_no == string.Empty)
                            row_no = Convert.ToString(rows + 1);
                        else
                            row_no = row_no + "," + Convert.ToString(rows + 1);
                        //BLL.ShowMessage(this, "No Periods Were Selected For the Employee In the row :" + rows);

                        //return;
                    }
                }
                if (row_no != string.Empty)
                {
                    BLL.ShowMessage(this, "No Periods Were Selected For the Employee In the row :" + row_no);
                }
                BLL.ShowMessage(this, "Total Employees Who Has Selected Their Periods Are:" + Count);
                btn_Save.Visible = false;
                btn_Update.Visible = false;
            }

            //}
            else
            {
                BLL.ShowMessage(this, "No Employee Found");
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Variableamtmaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Update_Click(object sender, EventArgs e)
    {
        try
        {
            btn_Save_Click(null, null);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Variableamtmaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

}

