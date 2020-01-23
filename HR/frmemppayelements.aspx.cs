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
using Telerik.Web.UI;
using System.Text;

public partial class HR_frmemppayelements : System.Web.UI.Page
{
    SMHR_SALARYSTRUCT _obj_smhr_salaryStruct;
    SMHR_BUSINESSUNIT _obj_smhr_businessunit;
    SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems;
    SMHR_POSITIONS _obj_smhr_positions;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_PENSION_CONTRIBUTION _obj_SMHR_PENSION_CONTRIBUTION;
    SMHR_EMPPENSIONSCHEME _obj_Smhr_EMPPENSIONSCHEME;

    string emplPF = Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["EmployeePension"]);
    string emprPF = Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["EmployerPension"]);

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
            if (!Page.IsPostBack)
            {

                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("EMPLOYEE PAY ELEMENTS");
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
                    RG_SalaryStruct.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Save.Visible = false;
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
                LoadEmptyData();
                LoadCombos();
                // RG_SalaryStruct.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemppayelements", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void LoadEmptyData()
    {
        try
        {
            _obj_smhr_salaryStruct = new SMHR_SALARYSTRUCT();
            _obj_smhr_salaryStruct.OPERATION = operation.Empty;
            _obj_smhr_salaryStruct.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Details = BLL.get_EmptyValues(_obj_smhr_salaryStruct);
            RG_SalaryStruct.DataSource = dt_Details;
            RG_SalaryStruct.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemppayelements", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void LoadCombos()
    {
        try
        {
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            rcb_BussinessUnit.DataSource = dt_BUDetails;
            rcb_BussinessUnit.DataValueField = "BUSINESSUNIT_ID";
            rcb_BussinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            rcb_BussinessUnit.DataBind();
            rcb_BussinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));
            rcb_Employee.Items.Clear();
            rcb_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemppayelements", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

    }

    protected void rcb_Employee_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            DataTable dtEmpPensionDetails = new DataTable();
            DataTable dtpf = new DataTable();

            if (rcb_Employee.SelectedIndex != 0)
            {
                _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
                _obj_smhr_emp_payitems.SMHR_EMP_PAYITEMS_EMPID = Convert.ToInt32(rcb_Employee.SelectedValue);
                _obj_smhr_emp_payitems.OPERATION = operation.Check;
                _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_smhr_emp_payitems.BUID = Convert.ToInt32(rcb_BussinessUnit.SelectedValue);
                // _obj_smhr_emp_payitems.SMHR_EMP_PAYITEMS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
                if (dt.Rows.Count != 0)
                {
                    RG_SalaryStruct.DataSource = dt;
                    RG_SalaryStruct.DataBind();
                }
                else
                {
                    LoadEmptyData();
                }
                _obj_smhr_emp_payitems.OPERATION = operation.Select;
                _obj_smhr_emp_payitems.SMHR_EMP_PAYITEMS_EMPID = Convert.ToInt32(rcb_Employee.SelectedValue);
                _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt1 = BLL.get_EmpSalaryStruct(_obj_smhr_emp_payitems);
                if (dt1.Rows.Count != 0)
                {
                    rtxt_SalaryStruct.Text = Convert.ToString(dt1.Rows[0]["SALARYSTRUCT_CODE"]);
                    rtxt_Positions.Text = Convert.ToString(dt1.Rows[0]["POSITIONS_CODE"]);
                    rtxt_Basic.Text = Convert.ToString(dt1.Rows[0]["EMP_BASIC"]);
                    string strVal = Convert.ToString(dt1.Rows[0]["POSITIONS_ID"]);
                    getJob(strVal);
                }

                int i;
                for (i = 0; i <= RG_SalaryStruct.Items.Count - 1; i++)
                {
                    CheckBox chkChoose = new CheckBox();
                    TextBox txtgetVal = new TextBox();
                    RadNumericTextBox txtgetVal1 = new RadNumericTextBox();
                    Label lblPAYITEMNAME = new Label();
                    TextBox txtMRPID = new TextBox();
                    Label lblPAYITEM_ID = new Label();
                    chkChoose = RG_SalaryStruct.Items[i].FindControl("chk_Choose") as CheckBox;
                    txtgetVal = RG_SalaryStruct.Items[i].FindControl("txtNumber") as TextBox;
                    txtgetVal1 = RG_SalaryStruct.Items[i].FindControl("rntbAmount") as RadNumericTextBox;
                    lblPAYITEMNAME = RG_SalaryStruct.Items[i].FindControl("lblPAYITEMNAME") as Label;
                    lblPAYITEM_ID = RG_SalaryStruct.Items[i].FindControl("lblPAYITEM_ID") as Label;
                    txtMRPID = RG_SalaryStruct.Items[i].FindControl("txtMRPID") as TextBox;
                    if(lblPAYITEMNAME.Text== "Housing Allowance" ||lblPAYITEMNAME.Text== "Housing_Allowance")
                    {
                        if (txtgetVal1.Text != string.Empty)
                            txtgetVal1.Enabled = false;                        
                    }
                               
                    //if (Convert.ToString(txtgetVal.Text) != string.Empty)
                    //{


                    //    if (dt.Rows.Count > 0)
                    //    {
                    //        chkChoose.Checked = true;
                    //    }
                    //}

                    if (txtMRPID.Text == "22" || txtMRPID.Text == "23")
                    {
                        txtgetVal.Enabled = false;

                        _obj_Smhr_EMPPENSIONSCHEME = new SMHR_EMPPENSIONSCHEME();
                        _obj_Smhr_EMPPENSIONSCHEME.OPERATION = operation.Check1;
                        _obj_Smhr_EMPPENSIONSCHEME.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Smhr_EMPPENSIONSCHEME.EMPPENSIONSCHEME_EMPID = Convert.ToInt32(rcb_Employee.SelectedValue);

                        dtpf = BLL.get_PensionScheme(_obj_Smhr_EMPPENSIONSCHEME);

                        if (dtpf.Rows.Count == 0)
                            txtgetVal.Text = string.Empty;
                    }
                    //if (lblPAYITEMNAME.Text == "Employer PF" || lblPAYITEMNAME.Text == "Employee PF" )
                    //{
                    //    string str;

                    //}
                    //else
                    if (Convert.ToString(txtgetVal.Text) != string.Empty)   //04042016
                    {

                        if (dt.Rows.Count > 0)
                            chkChoose.Checked = true;
                        else
                            chkChoose.Checked = false;

                        if (txtMRPID.Text == "22" || txtMRPID.Text == "23")
                            txtgetVal.Enabled = false;
                        else
                            txtgetVal.Enabled = true;

                        /*if (txtMRPID.Text == "22" || txtMRPID.Text == "23")
                        {
                            txtgetVal.Enabled = false;

                            _obj_Smhr_EMPPENSIONSCHEME = new SMHR_EMPPENSIONSCHEME();
                            _obj_Smhr_EMPPENSIONSCHEME.OPERATION = operation.Check1;
                            _obj_Smhr_EMPPENSIONSCHEME.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Smhr_EMPPENSIONSCHEME.EMPPENSIONSCHEME_EMPID = Convert.ToInt32(rcb_Employee.SelectedValue);
                            
                            dtpf = BLL.get_PensionScheme(_obj_Smhr_EMPPENSIONSCHEME);

                            if (dtpf.Rows.Count > 0)
                                chkChoose.Checked = true;
                            else
                                chkChoose.Checked = false;
                        }
                        else
                            txtgetVal.Enabled = true;*/
                    }
                    else
                    {
                        chkChoose.Checked = false;
                        txtgetVal.Enabled = true;
                    }

                    /*if ((lblPAYITEMNAME.Text == System.Configuration.ConfigurationSettings.AppSettings["EmployeePension"])
                                || (lblPAYITEMNAME.Text == System.Configuration.ConfigurationSettings.AppSettings["EmployerPension"]))
                    {

                    }

                    if ((Convert.ToString(txtgetVal.Text) != string.Empty) || ((lblPAYITEMNAME.Text == emplPF) || (lblPAYITEMNAME.Text == emprPF)))
                    {
                        chkChoose.Checked = true;

                        if (((lblPAYITEMNAME.Text == System.Configuration.ConfigurationSettings.AppSettings["EmployeePension"])
                                || (lblPAYITEMNAME.Text == System.Configuration.ConfigurationSettings.AppSettings["EmployerPension"])))
                        {
                            txtgetVal.Text = Convert.ToString(dtEmpPensionDetails.Rows[0]["PENSION_EMPLOYEE_VALUE"]);
                        }
                    }
                    else
                    {
                        chkChoose.Checked = false;
                    }*/
                }

                /*_obj_SMHR_PENSION_CONTRIBUTION = new SMHR_PENSION_CONTRIBUTION();

                _obj_SMHR_PENSION_CONTRIBUTION.OPERATION = operation.Available;
                _obj_SMHR_PENSION_CONTRIBUTION.LOGIN_ID = Convert.ToInt32(rcb_Employee.SelectedValue);
                _obj_SMHR_PENSION_CONTRIBUTION.PENSION_EMPTYPE = Convert.ToString(dt1.Rows[0]["EMP_EMPLOYEETYPE"]);

                dtEmpPensionDetails = BLL.get_PensionContribution(_obj_SMHR_PENSION_CONTRIBUTION);

                if (dtEmpPensionDetails.Rows.Count > 0 && RG_SalaryStruct.Items.Count > 0)
                {
                    for (int k = 0; k < RG_SalaryStruct.Items.Count; k++)
                    {
                        CheckBox chkChoose = new CheckBox();
                        Label lblPAYITEMNAME = new Label();
                        TextBox txtNumber = new TextBox();

                        chkChoose = RG_SalaryStruct.Items[k].FindControl("chk_Choose") as CheckBox;
                        txtNumber = RG_SalaryStruct.Items[k].FindControl("txtNumber") as TextBox;
                        lblPAYITEMNAME = RG_SalaryStruct.Items[k].FindControl("lblPAYITEMNAME") as Label;

                        if ((lblPAYITEMNAME.Text == System.Configuration.ConfigurationSettings.AppSettings["EmployeePension"])
                                || (lblPAYITEMNAME.Text == System.Configuration.ConfigurationSettings.AppSettings["EmployerPension"]))
                        //Convert.ToString(Configuration.AppSettings["EmployeePension"]))
                        {
                            chkChoose.Checked = true;
                            txtNumber.Text = Convert.ToString(dtEmpPensionDetails.Rows[0]["PENSION_EMPLOYEE_VALUE"]);
                        }
                        else
                        {
                            chkChoose.Checked = false;
                            txtNumber.Text = string.Empty;
                        }
                    }
                }*/
            }
            else
            {
                //RG_SalaryStruct.Visible = false;
                rtxt_SalaryStruct.Text = string.Empty;
                rtxt_Jobs.Text = string.Empty;
                rtxt_Positions.Text = string.Empty;
                rtxt_Basic.Text = string.Empty;
                LoadEmptyData();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemppayelements", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void rcb_BussinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcb_BussinessUnit.SelectedIndex != 0)
            {
                _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
                _obj_smhr_emp_payitems.OPERATION = operation.Get;
                _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(rcb_BussinessUnit.SelectedValue);
                _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_Details = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
                if (dt_Details.Rows.Count != 0)
                {

                    rcb_Employee.Items.Clear();
                    rtxt_SalaryStruct.Text = string.Empty;
                    rtxt_Jobs.Text = string.Empty;
                    rtxt_Basic.Text = string.Empty;
                    rtxt_Positions.Text = string.Empty;
                    rcb_Employee.DataSource = dt_Details;
                    rcb_Employee.DataTextField = "Empname";
                    rcb_Employee.DataValueField = "EMP_ID";
                    rcb_Employee.DataBind();
                    rcb_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
                    LoadEmptyData();
                }
                else
                {
                    //ClearFields();
                    rcb_Employee.Items.Clear();
                    rcb_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
                    rtxt_SalaryStruct.Text = string.Empty;
                    rtxt_Jobs.Text = string.Empty;
                    rtxt_Positions.Text = string.Empty;
                    rtxt_Basic.Text = string.Empty;
                    LoadEmptyData();
                }
            }
            else
            {
                rcb_Employee.Items.Clear();
                rcb_Employee.Items.Insert(0, new RadComboBoxItem());
                rtxt_SalaryStruct.Text = string.Empty;
                rtxt_Jobs.Text = string.Empty;
                rtxt_Positions.Text = string.Empty;
                rtxt_Basic.Text = string.Empty;
                LoadEmptyData();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemppayelements", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (rcb_Employee.SelectedIndex > 0)
            {
                StringBuilder str = new StringBuilder();
                SMHR_EMPLOYEE _obj_smhr_employee = new SMHR_EMPLOYEE();
                _obj_smhr_employee.OPERATION = operation.Select;
                _obj_smhr_employee.EMP_ID = Convert.ToInt32(rcb_Employee.SelectedItem.Value);
                //dt_Details = new DataTable();
                _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_Details = BLL.get_Employee(_obj_smhr_employee);
                #region MyRegion
                //if (Convert.ToInt32(dt_Details.Rows[0]["EMP_STATUS"]) == 1)
                //{
                //    BLL.ShowMessage(this, "Employee is Resigned.You can not Save the record.");
                //    return;
                //}
                //else if (Convert.ToInt32(dt_Details.Rows[0]["EMP_STATUS"]) == 2)
                //{
                //    BLL.ShowMessage(this, "Employee is Relieved.You can not Save the record.");
                //    return;
                //}
                //else if (Convert.ToInt32(dt_Details.Rows[0]["EMP_STATUS"]) == 3)
                //{
                //    BLL.ShowMessage(this, "Employee is Rehired.You can not Save the record.");
                //    return;
                //}
                //else if (Convert.ToInt32(dt_Details.Rows[0]["EMP_STATUS"]) == 4)
                //{
                //    BLL.ShowMessage(this, "Employee is Transfered.You can not Save the record.");
                //    return;
                //}
                //else
                //{ 
                #endregion
                int i;
                int j = 0;
                int k = 0;
                int validateminimumvalue = 0;
                for (i = 0; i <= RG_SalaryStruct.Items.Count - 1; i++)
                {
                    Label lblCalMode = new Label();
                    Label lblMinimumPercentage = new Label();
                    Label lblPAYITEMNAME = new Label();
                    //TextBox txtgetVal = new TextBox();
                    CheckBox chkChoose = new CheckBox();
                    RadNumericTextBox txtgetVal = new RadNumericTextBox();
                    chkChoose = RG_SalaryStruct.Items[i].FindControl("chk_Choose") as CheckBox;
                    //txtgetVal = RG_SalaryStruct.Items[i].FindControl("txtNumber") as TextBox;
                    txtgetVal = RG_SalaryStruct.Items[i].FindControl("rntbAmount") as RadNumericTextBox;
                    lblCalMode = RG_SalaryStruct.Items[i].FindControl("lblCALMODE_1") as Label;
                    lblMinimumPercentage = RG_SalaryStruct.Items[i].FindControl("lbl_MinimumPercentageValue") as Label;
                    lblPAYITEMNAME = RG_SalaryStruct.Items[i].FindControl("lblPAYITEMNAME") as Label;
                    if (Convert.ToString(txtgetVal.Text) != "")
                    {
                        if (Convert.ToString(lblCalMode.Text).ToUpper() == "%AGE")  //if (Convert.ToString(lblCalMode.Text).ToUpper() == "Percentage")
                        {
                            if (Convert.ToDouble(txtgetVal.Text) >= 101)
                            {
                                BLL.ShowMessage(this, "Percentage Value should not exceed 100%");
                                return;
                            }
                        }
                        if (chkChoose.Checked == false)
                        {
                            BLL.ShowMessage(this, "Please check the pay element to which you want to give Value");
                            return;
                        }
                    }
                    else if (chkChoose.Checked && txtgetVal.Text == string.Empty)
                        k++;
                    else
                    {
                        j = j + 1;
                    }
                    if (Convert.ToString(lblMinimumPercentage.Text) != "" && Convert.ToString(txtgetVal.Text) != "")
                    {
                        if (Convert.ToDouble(txtgetVal.Text) < Convert.ToDouble(lblMinimumPercentage.Text))
                        {
                            str.Append(lblPAYITEMNAME.Text.ToLower());
                            str.Append("-");
                            str.Append(lblMinimumPercentage.Text.ToUpper());
                            str.Append(",");
                        }
                    }
                }
                //str.ToString().Remove(str.ToString().LastIndexOf(","));

                if (str.Length > 0)
                {
                    str.Remove(str.Length - 1, 1);
                    str.Append(" values diminishing below minimum % values");
                    BLL.ShowMessage(this, str.ToString());
                    return;
                }
                if (j == RG_SalaryStruct.Items.Count)
                {
                    BLL.ShowMessage(this, "Please Enter atleast one value");
                    return;
                }
                if (k > 0)
                {
                    BLL.ShowMessage(this, "Please Enter value for checked item(s)");
                    return;
                }

                bool status = false;
                _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
                _obj_smhr_emp_payitems.OPERATION = operation.Delete;
                _obj_smhr_emp_payitems.SMHR_EMP_PAYITEMS_EMPID = Convert.ToInt32(rcb_Employee.SelectedValue);
                _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_smhr_emp_payitems.BUID = Convert.ToInt32(rcb_BussinessUnit.SelectedItem.Value);
                status = BLL.set_EmpPayElements(_obj_smhr_emp_payitems);

                _obj_smhr_emp_payitems.OPERATION = operation.getEmp;
                _obj_smhr_emp_payitems.SMHR_EMP_PAYITEMS_EMPID = Convert.ToInt32(rcb_Employee.SelectedValue);

                DataTable dt = BLL.get_EmpDetails(_obj_smhr_emp_payitems);

                string oldIDs = string.Empty;

                if (dt.Rows.Count > 0)
                {
                    for (int p = 0; p < dt.Rows.Count; p++)
                        oldIDs = oldIDs + Convert.ToString(dt.Rows[p]["SMHR_EMP_PAYITEMS_ID"]) + ",";

                    if (oldIDs != string.Empty)
                        oldIDs = oldIDs.Remove(oldIDs.Length - 1);
                }

                if (status == true)
                {
                    int index;
                    string ids = string.Empty;

                    for (index = 0; index <= RG_SalaryStruct.Items.Count - 1; index++)
                    {
                        Label lblCode = new Label(); // Pay item Code
                        Label lblMode = new Label(); // Pay item Mode
                        //TextBox txtVal = new TextBox(); // Salary Structure Entered Value
                        Label lblformula = new Label(); //Salary Structure Entered Formula
                        Label lblEmpPayItemID = new Label();    //To get Employee Pay Item ID
                        RadNumericTextBox txtVal = new RadNumericTextBox();
                        lblCode = RG_SalaryStruct.Items[index].FindControl("lblPAYITEM_ID") as Label;
                        lblMode = RG_SalaryStruct.Items[index].FindControl("lblCALMODE_1") as Label;
                        //txtVal = RG_SalaryStruct.Items[index].FindControl("txtNumber") as TextBox;
                        txtVal = RG_SalaryStruct.Items[index].FindControl("rntbAmount") as RadNumericTextBox;
                        lblformula = RG_SalaryStruct.Items[index].FindControl("lblformula") as Label;
                        lblEmpPayItemID = RG_SalaryStruct.Items[index].FindControl("lblEmpPayItemID") as Label;

                        if (Convert.ToString(txtVal.Text) != "")
                        {
                            _obj_smhr_emp_payitems.SMHR_EMP_PAYITEMS_EMPID = Convert.ToInt32(rcb_Employee.SelectedValue);
                            _obj_smhr_emp_payitems.SMHR_EMP_PAYITEMS_PAYITEMID = Convert.ToInt32(lblCode.Text);
                            _obj_smhr_emp_payitems.SMHR_EMP_PAYITEMS_CALMODE = Convert.ToString(lblMode.Text);
                            _obj_smhr_emp_payitems.SMHR_EMP_PAYITEMS_VALUE = Convert.ToDouble(txtVal.Text);
                            _obj_smhr_emp_payitems.SMHR_EMP_PAYITEMS_CHECKED = true;
                            _obj_smhr_emp_payitems.OPERATION = operation.Insert;
                            _obj_smhr_emp_payitems.SMHR_EMP_PAYITEMS_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                            _obj_smhr_emp_payitems.SMHR_EMP_PAYITEMS_CREATEDDATE = DateTime.Now;
                            _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_smhr_emp_payitems.BUID = Convert.ToInt32(rcb_BussinessUnit.SelectedItem.Value);
                            status = BLL.set_EmpPayElements(_obj_smhr_emp_payitems);
                        }

                        if (Convert.ToString(txtVal.Text) == string.Empty && lblEmpPayItemID.Text != string.Empty)
                        {
                            _obj_smhr_emp_payitems.OPERATION = operation.Insert1;
                            _obj_smhr_emp_payitems.SMHR_EMP_PAYITEMS_ID = Convert.ToInt32(lblEmpPayItemID.Text);

                            status = BLL.set_EmpPayElements(_obj_smhr_emp_payitems);
                        }
                        if ((lblEmpPayItemID.Text != string.Empty) && (Convert.ToString(txtVal.Text) != string.Empty))
                            ids = ids + lblEmpPayItemID.Text + ",";
                    }

                    if (ids != string.Empty)
                        ids = ids.Remove(ids.Length - 1);

                    _obj_smhr_emp_payitems.OPERATION = operation.Delete1;

                    _obj_smhr_emp_payitems.SDATE = ids;     //for new IDs
                    _obj_smhr_emp_payitems.EDATE = oldIDs;  //for old IDs
                    _obj_smhr_emp_payitems.SMHR_EMP_PAYITEMS_EMPID = Convert.ToInt32(rcb_Employee.SelectedValue);
                    _obj_smhr_emp_payitems.SMHR_EMP_PAYITEMS_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);

                    status = BLL.set_EmpPayElements(_obj_smhr_emp_payitems);

                    BLL.ShowMessage(this, "Employee Pay Elements Saved Succesfully");
                    //RG_SalaryStruct.Visible = false;
                    LoadEmptyData();
                    ClearFields();
                    return;
                }
                else
                {
                    BLL.ShowMessage(this, "Error Occured While doing the process");
                    return;
                }
                //}
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemppayelements", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            LoadEmptyData();
            rcb_BussinessUnit.SelectedIndex = -1;
            ClearFields();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemppayelements", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void getJob(string strPosition)
    {
        try
        {
            if (strPosition != "")
            {
                _obj_smhr_positions = new SMHR_POSITIONS();
                _obj_smhr_positions.OPERATION = operation.Empty;
                _obj_smhr_positions.POSITIONS_ID = Convert.ToInt32(strPosition);
                _obj_smhr_positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt = BLL.get_Positions(_obj_smhr_positions);
                if (dt.Rows.Count != 0)
                {
                    rtxt_Jobs.Text = Convert.ToString(dt.Rows[0]["JOBS_CODE"]);
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemppayelements", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void ClearFields()
    {
        try
        {
            rcb_Employee.Items.Clear();
            rcb_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
            rtxt_SalaryStruct.Text = string.Empty;
            rcb_BussinessUnit.SelectedIndex = -1;
            rtxt_Jobs.Text = string.Empty;
            rtxt_Positions.Text = string.Empty;
            rtxt_Basic.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemppayelements", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //protected void chk_Choose_CheckedChanged(object sender, CommandEventArgs e)
    //{
    //    try
    //    {
    //        GridDataItem item = RG_SalaryStruct.Items[(int)e.CommandArgument];
    //        for (int i = 0; i <= RG_SalaryStruct.Items.Count - 1; i++)
    //        {
    //            CheckBox chkChoose = new CheckBox();
    //            TextBox txtgetVal = new TextBox();
    //            chkChoose = RG_SalaryStruct.Items[i].FindControl("chk_Choose") as CheckBox;
    //            txtgetVal = RG_SalaryStruct.Items[i].FindControl("txtNumber") as TextBox;

    //            if (chkChoose.Checked == false)
    //            {
    //                txtgetVal.Text = string.Empty;
    //            }
    //        }
    //    }
    //        catch(Exception ex)
    //        {
    //            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemppayelements", ex.StackTrace, DateTime.Now);
    //            Response.Redirect("~/Frm_ErrorPage.aspx");

    //}

    protected void chk_Choose_CheckedChanged1(object sender, EventArgs e)
    {
        try
        {
            CheckBox chk = sender as CheckBox;
            TextBox rtxt_GrossSalary = chk.NamingContainer.FindControl("txtNumber") as TextBox;
            if (chk.Checked == false)
            {
                rtxt_GrossSalary.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemppayelements", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void RG_SalaryStruct_ItemDataBound(object sender, GridItemEventArgs e)
    {
        try
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                Label lblIsEnabled = item.FindControl("lblIsEnabled") as Label;
                CheckBox chk_Choose = item.FindControl("chk_Choose") as CheckBox;
                TextBox txtNumber = item.FindControl("txtNumber") as TextBox;
                if (lblIsEnabled.Text != "")
                {
                    int isEnabled = Convert.ToInt32((item.FindControl("lblIsEnabled") as Label).Text);
                    chk_Choose.Enabled = Convert.ToBoolean(isEnabled);
                    txtNumber.Enabled = Convert.ToBoolean(isEnabled);
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemppayelements", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}