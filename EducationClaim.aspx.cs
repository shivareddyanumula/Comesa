using SMHR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class EducationClaim : System.Web.UI.Page
{
    SMHR_EDU_ALLOWANCE _OBJ_SMHR_EDU_ALLOWANCE = new SMHR_EDU_ALLOWANCE();

    static int allowanceID = 0;
    static int eduClmID = 0;
    static int val = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if ((Convert.ToString(Request.QueryString["control"]) == "SelfService") && Convert.ToInt32(Session["EMP_ID"]) == 0)
                Response.Redirect("~/Masters/Default.aspx?ctrl=SS", false);
            else
            {
                LoadGrid();
                Rg_Educationdet.DataBind();
            }
        }
    }
    private void LoadGrid()
    {
        try
        {
            if (Convert.ToInt32(Session["EMP_ID"]) == 0)
                _OBJ_SMHR_EDU_ALLOWANCE.OPERATION = operation.load;
            _OBJ_SMHR_EDU_ALLOWANCE.EDU_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _OBJ_SMHR_EDU_ALLOWANCE.EDU_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            _OBJ_SMHR_EDU_ALLOWANCE.MODE = 0;
            Rg_Educationdet.DataSource = BLL.GetEduAllowance(_OBJ_SMHR_EDU_ALLOWANCE);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void Rg_Educationdet_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnk_View_Command(object sender, CommandEventArgs e)
    {
        try
        {
            val = 2;
            btn_Submit.Visible = false;
            LoadEmployees();
            LoadBusinessUnits();
            LoadDepartments();
            LoadScales();
            LoadFinancialPeriod();

            eduClmID = Convert.ToInt32(e.CommandArgument);
            rcbFinPeriod.Enabled = false;

            _OBJ_SMHR_EDU_ALLOWANCE.OPERATION = operation.Get;
            _OBJ_SMHR_EDU_ALLOWANCE.EDU_ID = eduClmID;

            DataTable dtEduClm = BLL.GetEduAllowance(_OBJ_SMHR_EDU_ALLOWANCE);

            if (dtEduClm.Rows.Count > 0)
            {
                rcmb_Employee.SelectedIndex = rcmb_Employee.Items.FindItemIndexByValue(Convert.ToString(dtEduClm.Rows[0]["EDU_EMP_ID"]));
                rcmb_BusinessUnit.SelectedIndex = rcmb_BusinessUnit.Items.FindItemIndexByValue(Convert.ToString(dtEduClm.Rows[0]["EDU_BU_ID"]));
                rcmb_Department.SelectedIndex = rcmb_Department.Items.FindItemIndexByValue(Convert.ToString(dtEduClm.Rows[0]["EDU_DEPT_ID"]));
                rcbScale.SelectedIndex = rcbScale.Items.FindItemIndexByValue(Convert.ToString(dtEduClm.Rows[0]["EDU_EMPLOYEEGRADE_ID"]));
                rcbFinPeriod.SelectedIndex = rcbFinPeriod.Items.FindItemIndexByValue(Convert.ToString(dtEduClm.Rows[0]["EDU_PERIOD_ID"]));

                LoadEmpFamilyDetails();

                _OBJ_SMHR_EDU_ALLOWANCE.OPERATION = operation.Count;
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedValue);
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);

                DataTable dtEmpEduData = BLL.GetEduAllowance(_OBJ_SMHR_EDU_ALLOWANCE);

                rcbDependentName.SelectedIndex = rcbDependentName.Items.FindItemIndexByValue(Convert.ToString(dtEduClm.Rows[0]["EDU_EMPFMDTL_ID"]));
                rntbEduAllScale.Text = Convert.ToString(dtEduClm.Rows[0]["EDU_ALLOWANCE_DEPENDENT"]);
                //rntb_bal.Text = Convert.ToString(dtEduClm.Rows[0]["EDU_BAL_AVL"]);
                //if (dtEmpEduData.Rows.Count > 0)
                //    rntb_bal.Text = Convert.ToString(Convert.ToDecimal(rntbEduAllScale.Text) - Convert.ToDecimal(dtEmpEduData.Rows[0]["CLAIM"]));
                //else
                //    rntb_bal.Text = rntbEduAllScale.Text;
                rcbDependentName_SelectedIndexChanged(null, null);
                rtxt_Expenditure.Text = Convert.ToString(dtEduClm.Rows[0]["EDU_EXPEN_NAME"]);
                rad_ClaimAmount.Text = Convert.ToString(dtEduClm.Rows[0]["EDU_CLAIM_AMT"]);
                rntbReceiptNo.Text = Convert.ToString(dtEduClm.Rows[0]["EDU_RECPT_NO"]);
                rdpt_ReceiptDate.SelectedDate = Convert.ToDateTime(dtEduClm.Rows[0]["EDU_RECPT_DATE"]);
                rntbRule75.Text = Convert.ToString(dtEduClm.Rows[0]["EDU_FINAL_AMNT"]);
                ViewState["rntbRule75"] = rntbRule75.Text;
                //ViewState["invDoc"] = Convert.ToString(dtEduClm.Rows[0]["EDU_UPLOAD_RECPTDOC"]);
                //ViewState["invDocs"] = Convert.ToString(dtEduClm.Rows[0]["EDU_UPLOAD_ATTDCERT"]);
                if (Convert.ToString(dtEduClm.Rows[0]["EDU_STATUS"]) == "0")
                    btn_Finalize.Visible = true;
                else
                    btn_Finalize.Visible = false;
                rad_ClaimAmount.Enabled = rcmb_Employee.Enabled = rcbDependentName.Enabled = false;
            }
          /*  if ((dtEduClm.Rows[0]["EDU_UPLOAD_RECPTDOC"] != System.DBNull.Value) && (dtEduClm.Rows[0]["EDU_UPLOAD_RECPTDOC"] != ""))
            {
                if (File.Exists(Server.MapPath(Convert.ToString(dtEduClm.Rows[0]["EDU_UPLOAD_RECPTDOC"]))))
                {
                    lnk_Download.Visible = true;
                    lnk_Download.OnClientClick = "javascript:window.open('../" + Convert.ToString(dtEduClm.Rows[0]["EDU_UPLOAD_RECPTDOC"]).TrimStart('~', '/') + "');return false;";
                    ViewState["fileLocation"] = dtEduClm.Rows[0]["EDU_UPLOAD_RECPTDOC"];
                }
            }
            else
            {
                lnk_Download.Visible = false;
            }*/
            Rm_Education_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            val = 1;
            btn_Submit.Visible = true;
            LoadEmployees();
            clearControls();
            Rm_Education_page.SelectedIndex = 1;
            rcbFinPeriod.Enabled = true;
            if (Convert.ToString(Request.QueryString["control"]) != "SelfService")
                rcmb_Employee.Enabled = true;
            else
            {
                rcmb_Employee.Enabled = false;
                rcmb_Employee.SelectedIndex = rcmb_Employee.Items.FindItemIndexByValue(Convert.ToString(Session["EMP_ID"]));
                rcmb_Employee_SelectedIndexChanged(null, null);
            }
            btn_Finalize.Visible = false;
            rad_ClaimAmount.Enabled = rcmb_Employee.Enabled = rcbDependentName.Enabled = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void rcmb_Employee_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rcbScale.SelectedIndex = 0;
            rntbEduAllScale.Text = rad_ClaimAmount.Text = rntbRule75.Text = rntb_bal.Text = string.Empty;

            if (rcmb_Employee.SelectedIndex > 0)
            {
                int empID = Convert.ToInt32(rcmb_Employee.SelectedValue);

                SMHR_EMPLOYEE _obj_smhr_employee = new SMHR_EMPLOYEE();
                SMHR_ALLOWANCE _obj_SMHR_ALLOWANCE = new SMHR_ALLOWANCE();

                _obj_smhr_employee.OPERATION = operation.Select;
                _obj_smhr_employee.EMP_ID = empID;
                _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

                DataTable dt_Details = BLL.get_Employee(_obj_smhr_employee);

                if (dt_Details.Rows.Count > 0)
                {
                    LoadBusinessUnits();
                    LoadDepartments();
                    LoadScales();
                    LoadFinancialPeriod();
                    LoadEmpFamilyDetails();

                    rcmb_BusinessUnit.SelectedIndex = rcmb_BusinessUnit.Items.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["EMP_BUSINESSUNIT_ID"]));
                    rcmb_Department.SelectedIndex = rcmb_Department.Items.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["EMP_DEPARTMENT_ID"]));
                    rcbScale.SelectedIndex = rcbScale.Items.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["EMP_GRADE"]));
                    //rcbFinPeriod.SelectedIndex = rcbFinPeriod.Items.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["EMP_PERIOD_ID"]));

                    /*_obj_SMHR_ALLOWANCE.OPERATION = operation.Check;
                    _obj_SMHR_ALLOWANCE.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_SMHR_ALLOWANCE.ALLOWANCE_PERIOD_ID = Convert.ToInt32(rcbFinPeriod.SelectedValue);
                    _obj_SMHR_ALLOWANCE.ALLOWANCE_EMPLOYEEGRADE_ID = Convert.ToInt32(rcbScale.SelectedValue);
                    _obj_SMHR_ALLOWANCE.ALLOWANCE_CONFG_ID = 1; //for getting Education allowance
                     
                    DataTable dtEmpFmlyAlwnces = BLL.GET_ALLOWANCE(_obj_SMHR_ALLOWANCE);

                    _OBJ_SMHR_EDU_ALLOWANCE.OPERATION = operation.Count;
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_EMP_ID = empID;
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);

                    DataTable dtEmpEduData = BLL.GetEduAllowance(_OBJ_SMHR_EDU_ALLOWANCE);

                    if (dtEmpFmlyAlwnces.Rows.Count > 0)
                        rntbEduAllScale.Text = Convert.ToString(dtEmpFmlyAlwnces.Rows[0]["ALLOWANCE_DEPENDENT"]);
                    else
                        rntbEduAllScale.Text = "0";
                    if (dtEmpEduData.Rows.Count > 0)
                        rntb_bal.Text = Convert.ToString(Convert.ToDecimal(rntbEduAllScale.Value) - Convert.ToDecimal(dtEmpEduData.Rows[0]["CLAIM"]));
                    else
                        rntb_bal.Text = rntbEduAllScale.Text;*/
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void rcmb_BusinessUnit_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {

    }
    protected void rcmb_Department_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {

    }
    protected void rcbFinPeriod_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rcbDependentName.SelectedIndex = 0;
            rntb_bal.Text = string.Empty;
            if (rcbFinPeriod.SelectedIndex > 0)
            {
                SMHR_ALLOWANCE _obj_SMHR_ALLOWANCE = new SMHR_ALLOWANCE();

                _obj_SMHR_ALLOWANCE.OPERATION = operation.Check;
                _obj_SMHR_ALLOWANCE.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_SMHR_ALLOWANCE.ALLOWANCE_PERIOD_ID = Convert.ToInt32(rcbFinPeriod.SelectedValue);
                _obj_SMHR_ALLOWANCE.ALLOWANCE_EMPLOYEEGRADE_ID = Convert.ToInt32(rcbScale.SelectedValue);
                _obj_SMHR_ALLOWANCE.ALLOWANCE_CONFG_ID = 1; //for getting Education allowance
                DataTable dtEmpFmlyAlwnces = BLL.GET_ALLOWANCE(_obj_SMHR_ALLOWANCE);
                if (dtEmpFmlyAlwnces.Rows.Count > 0)
                    rntbEduAllScale.Text = Convert.ToString(dtEmpFmlyAlwnces.Rows[0]["ALLOWANCE_DEPENDENT"]);
                else
                    rntbEduAllScale.Text = "0";
            }
            else
            {
                rntbEduAllScale.Text = string.Empty;
                BLL.ShowMessage(this, "Please select Financial Period");
                rcbFinPeriod.Focus();
                return;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void rcbDependentName_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcbDependentName.SelectedIndex > 0 && rcmb_Employee.SelectedIndex > 0)
            {
                _OBJ_SMHR_EDU_ALLOWANCE.OPERATION = operation.Chk;
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedValue);
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_EMPFMDTL_ID = Convert.ToInt32(rcbDependentName.SelectedValue);
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_EMPLOYEEGRADE_ID = Convert.ToInt32(rcbScale.SelectedValue);
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_PERIOD_ID = Convert.ToInt32(rcbFinPeriod.SelectedValue);
                _OBJ_SMHR_EDU_ALLOWANCE.MODE = val;

                DataTable dtEmpEduData = BLL.GetEduAllowance(_OBJ_SMHR_EDU_ALLOWANCE);

                if (dtEmpEduData.Rows.Count > 0)
                    rntb_bal.Text = Convert.ToString(dtEmpEduData.Rows[0]["CLAIM"]);
                else
                    rntb_bal.Text = rntbEduAllScale.Text;
            }
            else
            {
                BLL.ShowMessage(this, "Please select Dependent name to get balance available amount");
                rntb_bal.Text = string.Empty;
                rcbDependentName.Focus();
                return;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void rad_ClaimAmount_TextChanged(object sender, EventArgs e)
    {
        try
        {
            rntbRule75.Text = string.Empty;

            if (rad_ClaimAmount.Text != string.Empty)
            {
                if (rad_ClaimAmount.Text == "0")
                {
                    BLL.ShowMessage(this, "You are not supposed to claim any amounts as available balance amount is 0..");
                    rad_ClaimAmount.Text = string.Empty;
                    rad_ClaimAmount.Focus();
                    return;
                }
                if (val == 2)
                {
                    if ((Convert.ToDouble(rad_ClaimAmount.Text) * 0.75) > (Convert.ToDouble(rntb_bal.Text) + Convert.ToDouble(ViewState["rntbRule75"])))
                    {
                        BLL.ShowMessage(this, "You can enter amount upto " + Convert.ToString(Convert.ToDouble(rntb_bal.Text) + Convert.ToDouble(ViewState["rntbRule75"])) + " only which consists of old rule amount and available balance amount");
                        rad_ClaimAmount.Text = string.Empty;
                        rad_ClaimAmount.Focus();
                        return;
                    }
                }
                else if (val == 1)
                {
                    if ((Convert.ToDouble(rad_ClaimAmount.Text) * 0.75) > Convert.ToDouble(rntb_bal.Text))
                    {
                        BLL.ShowMessage(this, "Claim amount is exceeding Balance Available amount..");
                        rad_ClaimAmount.Text = string.Empty;
                        rad_ClaimAmount.Focus();
                        return;
                    }
                }
                rntbRule75.Text = Convert.ToString(Convert.ToDouble(rad_ClaimAmount.Text) * 0.75);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            Rm_Education_page.SelectedIndex = 0;
            clearControls();
            LoadGrid();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            if (rntb_bal.Text == "0")
            {
                BLL.ShowMessage(this, "You are not having any balance amount to initiate this claim");
                return;
            }

            bool status;

            _OBJ_SMHR_EDU_ALLOWANCE.EDU_EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedValue);
            _OBJ_SMHR_EDU_ALLOWANCE.EDU_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _OBJ_SMHR_EDU_ALLOWANCE.EDU_BU_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
            if (rcmb_Department.SelectedValue != string.Empty)
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_DEPT_ID = Convert.ToInt32(rcmb_Department.SelectedValue);
            else
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_DEPT_ID = 0;
            if (rcbScale.SelectedValue != string.Empty)
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_EMPLOYEEGRADE_ID = Convert.ToInt32(rcbScale.SelectedValue);
            else
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_EMPLOYEEGRADE_ID = 0;
            if (rntbEduAllScale.Text != string.Empty)
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_ALLOWANCE_DEPENDENT = Convert.ToInt32(rntbEduAllScale.Text);
            else
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_ALLOWANCE_DEPENDENT = 0;
            _OBJ_SMHR_EDU_ALLOWANCE.EDU_EMPFMDTL_ID = Convert.ToInt32(rcbDependentName.SelectedValue);
            if (rntb_bal.Text != string.Empty)
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_BAL_AVL = Convert.ToDecimal(rntb_bal.Text);
            else
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_BAL_AVL = 0;
            _OBJ_SMHR_EDU_ALLOWANCE.EDU_EXPEN_NAME = rtxt_Expenditure.Text;
            _OBJ_SMHR_EDU_ALLOWANCE.EDU_CLAIM_AMT = Convert.ToDecimal(rad_ClaimAmount.Text);
            if (rntbRule75.Text != string.Empty)
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_FINAL_AMNT = Convert.ToDecimal(rntbRule75.Text);
            else
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_FINAL_AMNT = 0;
            _OBJ_SMHR_EDU_ALLOWANCE.EDU_RECPT_NO = Convert.ToInt32(rntbReceiptNo.Text);
            _OBJ_SMHR_EDU_ALLOWANCE.EDU_RECPT_DATE = Convert.ToDateTime(rdpt_ReceiptDate.SelectedDate);
            _OBJ_SMHR_EDU_ALLOWANCE.EDU_CREATEDBY = Convert.ToInt32(Session["EMP_ID"]);
            _OBJ_SMHR_EDU_ALLOWANCE.EDU_LASTMDFBY = Convert.ToInt32(Session["EMP_ID"]);
            if (rcbFinPeriod.SelectedValue != string.Empty)
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_PERIOD_ID = Convert.ToInt32(rcbFinPeriod.SelectedValue);
            else
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_PERIOD_ID = 0;
            /*if (FBrowse.HasFile)
            {
                string pdfName = rcmb_Employee.SelectedValue + "_" + Guid.NewGuid().ToString() + "_" + FBrowse.FileName;
                string strPath = "~/Download/EducationInvoice/" + pdfName;
                FBrowse.PostedFile.SaveAs(Server.MapPath("~/Download/EducationInvoice/") + pdfName);
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_UPLOAD_RECPTDOC = strPath;
            }*/

            if (!string.IsNullOrEmpty(FBrowse.PostedFile.FileName))
            {
                FBrowse.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Download/EducationInvoice/"), "EDUALL_" + rcmb_Employee.SelectedItem.Value + "_" + FBrowse.FileName));
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_UPLOAD_RECPTDOC = "~/Download/EducationInvoice/" + "EDUALL_" + rcmb_Employee.SelectedItem.Value + "_" + FBrowse.FileName;
            }
            else
            {
                if (ViewState["fileLocation"] != null)
                {
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_UPLOAD_RECPTDOC = Convert.ToString(ViewState["fileLocation"]);
                }
            }
           /* if (fu_Browse.HasFile)
            {
                string pdfName = rcmb_Employee.SelectedValue + "_" + Guid.NewGuid().ToString() + "_" + fu_Browse.FileName;
                string strPath = "~/Download/EducationInvoice/" + pdfName;
                FBrowse.PostedFile.SaveAs(Server.MapPath("~/Download/EducationInvoice/") + pdfName);
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_UPLOAD_ATTDCERT = strPath;
            }*/

            if (!string.IsNullOrEmpty(FBrowse.PostedFile.FileName))
            {
                FBrowse.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Download/EducationInvoice/"), "EDUALL_" + rcmb_Employee.SelectedItem.Value + "_" + fu_Browse.FileName));
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_UPLOAD_ATTDCERT = "~/Download/EducationInvoice/" + "EDUALL_" + rcmb_Employee.SelectedItem.Value + "_" + fu_Browse.FileName;
            }
            else
            {
                if (ViewState["fileLocation"] != null)
                {
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_UPLOAD_ATTDCERT = Convert.ToString(ViewState["fileLocation"]);
                }
            }

            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_SUBMIT":

                    _OBJ_SMHR_EDU_ALLOWANCE.OPERATION = operation.Insert;
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_STATUS = 0;
                    status = BLL.SetEduAllowance(_OBJ_SMHR_EDU_ALLOWANCE);

                    if (status == true)
                        BLL.ShowMessage(this, "Information Saved successfully");
                    else
                        BLL.ShowMessage(this, "Information not Saved");

                    break;
                case "BTN_UPDATE":

                    _OBJ_SMHR_EDU_ALLOWANCE.OPERATION = operation.Update;
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_ID = eduClmID;
                    status = BLL.SetEduAllowance(_OBJ_SMHR_EDU_ALLOWANCE);

                    if (status == true)
                        BLL.ShowMessage(this, "Information Updated successfully");
                    else
                        BLL.ShowMessage(this, "Information not Updated");

                    break;
                case "BTN_FINALIZE":

                    _OBJ_SMHR_EDU_ALLOWANCE.OPERATION = operation.Finalized;
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_STATUS = 1;
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_ID = eduClmID;

                    status = BLL.SetEduAllowance(_OBJ_SMHR_EDU_ALLOWANCE);

                    if (status == true)
                        BLL.ShowMessage(this, "Information Finalised successfully");
                    else
                        BLL.ShowMessage(this, "Information not Finalised");

                    break;
                default:
                    break;
            }
            Rm_Education_page.SelectedIndex = 0;
            LoadGrid();
            Rg_Educationdet.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void LoadEmployees()
    {
        try
        {
            SMHR_EMPLOYEE _obj_smhr_employee = new SMHR_EMPLOYEE();

            _obj_smhr_employee.OPERATION = operation.Select;
            _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_employee.EMP_LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dtEmp = BLL.get_Employee(_obj_smhr_employee);

            rcmb_Employee.DataSource = dtEmp;
            rcmb_Employee.DataTextField = "EMP_NAME";
            rcmb_Employee.DataValueField = "EMP_ID";
            rcmb_Employee.DataBind();
            rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void LoadBusinessUnits()
    {
        SMHR_LOGININFO _obj_SMHR_LOGININFO = new SMHR_LOGININFO();

        _obj_SMHR_LOGININFO.OPERATION = operation.Select;
        _obj_SMHR_LOGININFO.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

        DataTable dtBU = BLL.get_Sup_BusinessUnit(_obj_SMHR_LOGININFO);

        rcmb_BusinessUnit.DataSource = dtBU;
        rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
        rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
        rcmb_BusinessUnit.DataBind();
        rcmb_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
    }

    protected void LoadDepartments()
    {
        SMHR_DEPARTMENT _obj_SMHR_Department = new SMHR_DEPARTMENT();

        _obj_SMHR_Department.MODE = 20;
        _obj_SMHR_Department.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

        DataTable dtDept = BLL.get_Department(_obj_SMHR_Department);

        rcmb_Department.DataSource = dtDept;
        rcmb_Department.DataTextField = "DEPARTMENT_NAME";
        rcmb_Department.DataValueField = "DEPARTMENT_ID";
        rcmb_Department.DataBind();
        rcmb_Department.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
    }

    protected void LoadScales()
    {
        SMHR_EMPLOYEEGRADE _obj_Smhr_EmployeeGrade = new SMHR_EMPLOYEEGRADE();

        _obj_Smhr_EmployeeGrade.OPERATION = operation.EmployeeGrade;
        _obj_Smhr_EmployeeGrade.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

        DataTable dtEmpGrade = BLL.GetEmployeeGrade(_obj_Smhr_EmployeeGrade);

        rcbScale.DataSource = dtEmpGrade;
        rcbScale.DataTextField = "EMPLOYEEGRADE_CODE";
        rcbScale.DataValueField = "EMPLOYEEGRADE_ID";
        rcbScale.DataBind();
        rcbScale.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
    }

    protected void LoadEmpFamilyDetails()
    {
        if (rcmb_Employee.SelectedIndex > 0)
        {
            SMHR_EMPLOYEE _obj_SMHR_EMPLOYEE = new SMHR_EMPLOYEE();

            _obj_SMHR_EMPLOYEE.OPERATION = operation.CheckEmp;
            _obj_SMHR_EMPLOYEE.EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedValue);

            DataTable dtEmpFmlys = BLL.get_EmployeeFamily(_obj_SMHR_EMPLOYEE);

            rcbDependentName.DataSource = dtEmpFmlys;
            rcbDependentName.DataTextField = "EMPFMDTL_NAME";
            rcbDependentName.DataValueField = "EMPFMDTL_ID";
            rcbDependentName.DataBind();
            rcbDependentName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        }
    }

    protected void LoadFinancialPeriod()
    {
        SMHR_PERIOD _obj_smhr_period = new SMHR_PERIOD();

        _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

        DataTable dtFinPrd = BLL.GET_FIN_PERIOD(_obj_smhr_period);

        rcbFinPeriod.DataSource = dtFinPrd;
        rcbFinPeriod.DataTextField = "PERIOD_NAME";
        rcbFinPeriod.DataValueField = "PERIOD_ID";
        rcbFinPeriod.DataBind();
        rcbFinPeriod.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
    }

    protected void clearControls()
    {
        rcmb_BusinessUnit.SelectedIndex = 0;
        rcmb_Department.SelectedIndex = 0;
        rcbFinPeriod.SelectedIndex = 0;
        rcbScale.SelectedIndex = 0;
        rcbDependentName.SelectedIndex = 0;
        rntbEduAllScale.Text = string.Empty;
        rntb_bal.Text = string.Empty;
        rtxt_Expenditure.Text = string.Empty;
        rad_ClaimAmount.Text = string.Empty;
        rntbReceiptNo.Text = string.Empty;
        rntbRule75.Text = string.Empty;
        rdpt_ReceiptDate.Clear();
        btn_Finalize.Visible = false;
    }
}