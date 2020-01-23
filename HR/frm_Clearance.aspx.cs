using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using SMHR;
using Telerik;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class HR_frm_Clearance : System.Web.UI.Page
{
    DataTable dt_details = new DataTable();
    DataTable dt_resignedEmpDetails;
    SMHR_DEPARTMENTHEADS _obj_Smhr_DepartmentHeads;
    SMHR_EMPASSETDOC _obj_Smhr_AssetDoc;
    SMHR_EMPLOYEE _obj_Smhr_Employee;
    SMHR_APPLICANT _obj_Smhr_Applicant;
    SMHR_EMP_ASSET_CLEARANCE _obj_Smhr_Asset_Clearance;
    SMHR_DEPARTMENT _obj_SMHR_Department;
    SMHR_LOGININFO _obj_smhr_logininfo;
    DataTable dt_Details = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
      try
      {
        if (!IsPostBack)
        {
            //code for security privilage
            Session.Remove("WRITEFACILITY");
            SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();
           _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
            _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
            _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Clearance Certificate");//COUNTRY");
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
                Rg_DepartmentswithAssets.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                btn_Submit.Visible = false;
                // btn_Update.Visible = false;
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
            tr_EmpDetails.Attributes.Add("style", "visibility:hidden;display:none");
            table_AssetDetails.Attributes.Add("style", "visibility:hidden;display:none");
            LoadBusinessUnits();
            // LoadEmployees();
            // LoadDepartment();
        }
      }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Clearance", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadBusinessUnits()
    {
        try
        {
            radBU.Items.Clear();
            SMHR_LOGININFO _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            radBU.DataSource = dt_BUDetails;
            radBU.DataValueField = "BUSINESSUNIT_ID";
            radBU.DataTextField = "BUSINESSUNIT_CODE";
            radBU.DataBind();
            radBU.Items.Insert(0, new RadComboBoxItem("Select"));
            rad_Employees.Items.Clear();
            rad_Employees.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Clearance", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void LoadEmployees()
    {
        try
        {
            DataTable deptid = new DataTable();
            if (Session["EMP_ID"] != null)
            {
                deptid = BLL.Get_Emp_Dept_id(Convert.ToInt32(Session["EMP_ID"]));
                if (deptid != null)
                {
                    if (deptid.Rows.Count > 0)
                    {
                        ViewState["deptid"] = deptid.Rows[0][0].ToString();
                    }
                }
            }
            _obj_smhr_logininfo = new SMHR_LOGININFO();
            _obj_smhr_logininfo.LOGIN_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            _obj_smhr_logininfo.LOGIN_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_logininfo.BUID = Convert.ToInt32(radBU.SelectedValue);
            dt_details = BLL.get_GETRESIGNEDEMPLOYEE(_obj_smhr_logininfo);
            dt_details = removeNullColumnFromDataTable(dt_details);
            rad_Employees.DataSource = dt_details;
            rad_Employees.DataTextField = "empname";
            rad_Employees.DataValueField = "EMP_ID";
            rad_Employees.DataBind();
            rad_Employees.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Clearance", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            rad_Employees.ClearSelection();
            Rad_Department.Items.Clear();
            Rad_Department.ClearSelection();
            radBU.SelectedIndex = 0;
            rad_Employees.Items.Clear();
            if (radBU.SelectedIndex > 0)
            {
                LoadEmployees();
            }
            tr_EmpDetails.Attributes.Add("style", "visibility:hidden;display:none");
            table_AssetDetails.Attributes.Add("style", "visibility:hidden;display:none");
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Clearance", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    public static DataTable removeNullColumnFromDataTable(DataTable dt)
    {
        try
        {
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                if (dt.Rows[i][1].ToString() == string.Empty)
                    dt.Rows[i].Delete();
            }
        }
        catch (Exception ex)
        {
            throw ex;

        }
        return dt;
    }
    protected void radReceivedPayable_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            RadComboBox cmb = (RadComboBox)sender;
            GridDataItem item = (GridDataItem)cmb.NamingContainer;

            if (e.Text == "Received")
            {
                Label lbl_Amount = item.FindControl("lbl_Amount") as Label;
                lbl_Amount.Visible = false;
                Label lbl_Reason = item.FindControl("lbl_Reason") as Label;
                lbl_Reason.Visible = true;
                RadNumericTextBox rad_Amount = item.FindControl("rad_Amount") as RadNumericTextBox;
                rad_Amount.Visible = false;
                RadTextBox rad_Reason = (RadTextBox)item.FindControl("rad_Reason");
                rad_Reason.Text = string.Empty;
                rad_Reason.Visible = true;

            }
            else if (e.Text == "Amount Payable")
            {
                Label lbl_Amount = item.FindControl("lbl_Amount") as Label;
                lbl_Amount.Visible = true;
                Label lbl_Reason = item.FindControl("lbl_Reason") as Label;
                lbl_Reason.Visible = true;
                RadNumericTextBox rad_Amount = item.FindControl("rad_Amount") as RadNumericTextBox;
                rad_Amount.Visible = true;
                RadTextBox rad_Reason = (RadTextBox)item.FindControl("rad_Reason");
                rad_Reason.Text = string.Empty;
                rad_Reason.Visible = true;
            }
            else if (e.Text == "Select")
            {
                Label lbl_Amount = item.FindControl("lbl_Amount") as Label;
                lbl_Amount.Visible = false;
                Label lbl_Reason = item.FindControl("lbl_Reason") as Label;
                lbl_Reason.Visible = false;
                RadNumericTextBox rad_Amount = item.FindControl("rad_Amount") as RadNumericTextBox;
                rad_Amount.Visible = false;
                RadTextBox rad_Reason = (RadTextBox)item.FindControl("rad_Reason");
                rad_Reason.Text = string.Empty;
                rad_Reason.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Clearance", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    private void LoadDepartment()
    {
        try
        {
            _obj_SMHR_Department = new SMHR_DEPARTMENT();
            _obj_SMHR_Department.MODE = 9;
            if ((Convert.ToInt32(Session["EMP_ID"]) == 0))
            {
                _obj_SMHR_Department.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                _obj_SMHR_Department.BUID = 5;//Convert.ToInt32(ViewState["Emp_BusinessUnitID"].ToString());
                dt_Details = BLL.get_Department(_obj_SMHR_Department);

                if (dt_Details.Rows.Count > 0)
                {
                    Rad_Department.Visible = true;
                    Rad_Department.DataSource = dt_Details;
                    Rad_Department.DataTextField = "DEPARTMENT_NAME";
                    Rad_Department.DataValueField = "DEPARTMENT_ID";
                    Rad_Department.DataBind();
                    Rad_Department.Items.Insert(0, new RadComboBoxItem("Select"));
                }
            }
            else
            {

                _obj_SMHR_Department.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                _obj_SMHR_Department.BUID = Convert.ToInt32(Session["BUSINESSUNIT_ID"].ToString().Split(',')[0]);
                dt_Details = BLL.get_Department(_obj_SMHR_Department);
                if (dt_Details.Rows.Count > 0)
                {
                    Rad_Department.Visible = true;
                    Rad_Department.DataSource = dt_Details;
                    Rad_Department.DataTextField = "DEPARTMENT_NAME";
                    Rad_Department.DataValueField = "DEPARTMENT_ID";
                    Rad_Department.DataBind();
                    Rad_Department.Items.Insert(0, new RadComboBoxItem("Select"));
                }
                Rad_Department.SelectedValue = Convert.ToString(ViewState["deptid"].ToString());
                Rad_Department.Enabled = false;
            }


        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Clearance", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void rad_Employees_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            _obj_Smhr_AssetDoc = new SMHR_EMPASSETDOC();
            _obj_Smhr_Employee = new SMHR_EMPLOYEE();
            dt_resignedEmpDetails = new DataTable();

            if (rad_Employees.SelectedIndex != 0)
            {
                ViewState["SelectedEmployee"] = rad_Employees.SelectedValue;
                _obj_Smhr_Employee.OPERATION = operation.Select_Dept;
                _obj_Smhr_Employee.EMP_ID = Convert.ToInt32(rad_Employees.SelectedValue);
                dt_resignedEmpDetails = BLL.get_ResignedEmployeeDetails(_obj_Smhr_Employee);

                if (dt_resignedEmpDetails.Rows.Count > 0)
                {
                    ViewState["Emp_BusinessUnitID"] = dt_resignedEmpDetails.Rows[0]["EMP_BUSINESSUNIT_ID"].ToString();
                    if (Convert.ToInt32(Session["EMP_ID"]) == 0)
                    {
                        // LoadDepartment();
                        Rad_Department.Visible = true;
                        Rad_Department.DataSource = dt_resignedEmpDetails;
                        Rad_Department.DataTextField = "DEPARTMENT_Name";
                        Rad_Department.DataValueField = "EMPASSETDOC_DEPT_ID";
                        Rad_Department.DataBind();
                        Rad_Department.Items.Insert(0, new RadComboBoxItem("Select"));
                    }
                    else
                    {
                        _obj_Smhr_Employee = new SMHR_EMPLOYEE();
                        _obj_Smhr_Employee.OPERATION = operation.Select_DeptHead;
                        _obj_Smhr_Employee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                        dt_Details = BLL.get_ResignedEmployeeDetails(_obj_Smhr_Employee);
                        if (dt_Details.Rows.Count > 0)
                        {
                            Rad_Department.Visible = true;
                            Rad_Department.DataSource = dt_Details;
                            Rad_Department.DataTextField = "DEPARTMENT_NAME";
                            Rad_Department.DataValueField = "DEPARTMENT_ID";
                            Rad_Department.DataBind();
                            Rad_Department.Items.Insert(0, new RadComboBoxItem("Select"));
                        }
                        //Rad_Department.SelectedValue = Convert.ToString(ViewState["deptid"].ToString());
                        //Rad_Department.Enabled = false;
                    }
                    tr_EmpDetails.Attributes.Add("style", "visibility:visible;display:block");
                    txt_EmployeeName.Text = dt_resignedEmpDetails.Rows[0]["EMPLOYEENAME"].ToString();
                    txt_EmployeeName.Enabled = false;
                    txt_Address.Text = dt_resignedEmpDetails.Rows[0]["APPLICANT_ADDRESS"].ToString();
                    txt_Department.Text = dt_resignedEmpDetails.Rows[0]["DEPARTMENT_NAME"].ToString();
                    txt_Department.Enabled = false;
                    txt_EmployeeCode.Text = dt_resignedEmpDetails.Rows[0]["EMP_EMPCODE"].ToString();
                    txt_EmployeeCode.Enabled = false;
                    txt_Telephone.Text = dt_resignedEmpDetails.Rows[0]["EMP_MOBILENO"].ToString();
                    rdp_DateOfRetirement.SelectedDate = Convert.ToDateTime(dt_resignedEmpDetails.Rows[0]["EMPREG_REGDATE"].ToString());
                    rdp_DateOfRetirement.Enabled = false;

                }
                lbl_Department_Name.Text = string.Empty;
                //tr_EmpDetails.Attributes.Add("style", "visibility:hidden;display:none");
                table_AssetDetails.Attributes.Add("style", "visibility:hidden;display:none");
                //Get_Employee_Assets(rad_Employees.SelectedItem.ToString());

            }
            else
            {
                Rad_Department.Items.Clear();
                Rad_Department.ClearSelection();
                if (Convert.ToInt32(Session["EMP_ID"]) == 0)
                {
                    Rad_Department.ClearSelection();
                    tr_EmpDetails.Attributes.Add("style", "visibility:hidden;display:none");
                    table_AssetDetails.Attributes.Add("style", "visibility:hidden;display:none");
                }
                else
                {
                    tr_EmpDetails.Attributes.Add("style", "visibility:hidden;display:none");
                    table_AssetDetails.Attributes.Add("style", "visibility:hidden;display:none");
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Clearance", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void Rad_Department_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (Rad_Department.SelectedIndex > 0)
            {
                rad_DeptHeadRemarks.Text = string.Empty;
                Rg_DepartmentswithAssets.DataSource = null;
                Rg_DepartmentswithAssets.DataBind();
                Get_Employee_Assets(rad_Employees.SelectedValue);
            }
            else
            {
                lbl_Department_Name.Text = string.Empty;
                Rg_DepartmentswithAssets.DataSource = null;
                Rg_DepartmentswithAssets.DataBind();
                // tr_EmpDetails.Attributes.Add("style", "visibility:hidden;display:none");
                table_AssetDetails.Attributes.Add("style", "visibility:hidden;display:none");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Clearance", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    private void Get_Employee_Assets(string emp_id)
    {
        try
        {
            _obj_Smhr_AssetDoc = new SMHR_EMPASSETDOC();
            _obj_Smhr_AssetDoc.EMPASSETDOC_EMP_ID = Convert.ToInt32(ViewState["SelectedEmployee"]);
            if (Rad_Department.SelectedIndex > 0)
            {
                if (rad_Employees.SelectedIndex > 0)
                {
                    if (Convert.ToInt32(rad_Employees.SelectedValue) != Convert.ToInt32(Rad_Department.SelectedValue))
                    {
                        _obj_Smhr_AssetDoc.EMPASSETDOC_DEPT_ID = Convert.ToInt32(Rad_Department.SelectedValue);
                    }
                    else
                    {
                        _obj_Smhr_AssetDoc.EMPASSETDOC_DEPT_ID = Convert.ToInt32(ViewState["SelectedEmployee"].ToString().Split('~')[1]);
                    }
                    dt_details = BLL.get_EmployeeAssets(_obj_Smhr_AssetDoc);
                    if (dt_details.Rows.Count > 0)
                    {
                        table_AssetDetails.Attributes.Add("style", "visibility:visible;display:block");
                        Rg_DepartmentswithAssets.DataSource = dt_details;
                        Rg_DepartmentswithAssets.DataBind();
                        lbl_Department_Name.Text = Rad_Department.SelectedItem.Text;
                        ViewState["DEPARTMENT_ID"] = dt_details.Rows[0]["DEPARTMENT_ID"].ToString();
                    }
                    else
                    {
                        table_AssetDetails.Attributes.Add("style", "visibility:hidden;display:none");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Clearance", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void Rg_DepartmentswithAssets_OnItemDataBound(object sender, GridItemEventArgs e)
    {
        try
        {
            if (e.Item is GridDataItem)
            {
                GridEditableItem edititem = (GridEditableItem)e.Item;
                RadComboBox radcombo = (RadComboBox)edititem.FindControl("radReceivedPayable");
                string str = radcombo.SelectedValue.ToString();
                // RadTextBox radTextBox = (RadTextBox)edititem.FindControl("radNameSignature");
                //  radTextBox.Text = Session["USERNAME"].ToString();           
                // radTextBox.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Clearance", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }


    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_Smhr_Applicant = new SMHR_APPLICANT();
            _obj_Smhr_Employee = new SMHR_EMPLOYEE();
            _obj_Smhr_Asset_Clearance = new SMHR_EMP_ASSET_CLEARANCE();
            int count = 0;

            if (rad_Employees.SelectedItem.Text == "Select")
            {
                BLL.ShowMessage(this, "Please select an Employee");
                return;
            }
            if (Rad_Department.SelectedItem.Text == "Select")
            {
                BLL.ShowMessage(this, "Please select a Department");
                return;
            }
            if (Rg_DepartmentswithAssets.Items.Count == 0)
            {
                BLL.ShowMessage(this, "No Assets for the Employee");
                return;
            }
            if (rad_Employees.SelectedIndex > 0)
            {
                _obj_Smhr_Employee.EMP_ID = Convert.ToInt32(rad_Employees.SelectedValue);
            }
            else
            {
                if (ViewState["SelectedEmployee"] != null)
                {
                    _obj_Smhr_Employee.EMP_ID = Convert.ToInt32(ViewState["SelectedEmployee"]);
                }
                else
                {
                    BLL.ShowMessage(this, "No Employees for Clearance");
                    return;
                }
            }
            if (txt_Address != null && txt_Address.Text != string.Empty)
            {
                _obj_Smhr_Applicant.APPLICANT_ADDRESS = Convert.ToString(txt_Address.Text);
            }
            if (txt_Telephone != null && txt_Telephone.Text != string.Empty)
            {
                _obj_Smhr_Employee.EMP_MOBILENO = Convert.ToString(txt_Telephone.Text);
            }
            Label lbl_Asset_Id = new Label();
            CheckBox chkBox = new CheckBox();
            bool status = false;

            foreach (GridDataItem item in Rg_DepartmentswithAssets.Items)
            {
                chkBox = item.FindControl("chkChoose") as CheckBox;
                if (chkBox.Checked)
                {
                    count++;
                    RadComboBox radReceivedPayable = item.FindControl("radReceivedPayable") as RadComboBox;
                    lbl_Asset_Id = item.FindControl("lbl_Asset_Id") as Label;
                    if (radReceivedPayable.SelectedItem.Text != "Select")
                    {
                        RadTextBox rad_Reason = item.FindControl("rad_Reason") as RadTextBox;
                        _obj_Smhr_Asset_Clearance.EMP_ASSET_CLEARANCE_REMARKS = Convert.ToString(rad_Reason.Text);
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Please select Received/Amount Payable");
                        return;
                    }
                    RadTextBox rad_Amount = item.FindControl("rad_Amount") as RadTextBox;
                    if (rad_Amount != null && rad_Amount.Text != string.Empty)
                    {
                        _obj_Smhr_Asset_Clearance.EMP_ASSET_CLEARANCE_AMOUNT = Convert.ToDecimal(rad_Amount.Text);
                    }
                    RadDatePicker rad_ReceievedDate = item.FindControl("rad_ReceivedDate") as RadDatePicker;
                    if (rad_ReceievedDate.SelectedDate == null)
                    {
                        BLL.ShowMessage(this, "Please select Date");
                        return;
                    }
                    else
                    {
                        _obj_Smhr_Asset_Clearance.EMP_ASSET_CLEARANCE_RECEIVED_DATE = Convert.ToDateTime(rad_ReceievedDate.SelectedDate.Value);
                    }
                    _obj_Smhr_Asset_Clearance.EMP_ASSET_CLEARANCE_ASSET_ID = Convert.ToInt32(lbl_Asset_Id.Text);
                    _obj_Smhr_Asset_Clearance.EMP_ASSET_CLEARANCE_DEPT_ID = Convert.ToInt32(Rad_Department.SelectedValue);
                    _obj_Smhr_Asset_Clearance.EMP_ASSET_CLEARANCE_RECEIEVED_BY = Convert.ToInt32(Session["EMP_ID"]);
                    _obj_Smhr_Asset_Clearance._EMP_ASSET_CLEARANCE_DEPTHEADREMARKS = Convert.ToString(rad_DeptHeadRemarks.Text);
                    _obj_Smhr_Asset_Clearance.EMP_ASSET_CLEARANCE_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_Smhr_Asset_Clearance.EMP_ASSET_CLEARANCE_CREATEDDATE = DateTime.Now;
                    _obj_Smhr_Asset_Clearance.EMP_ASSET_CLEARANCE_LSTMFDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_Smhr_Asset_Clearance.EMP_ASSET_CLEARANCE_LSTMFDDATE = DateTime.Now;


                    _obj_Smhr_Employee = new SMHR_EMPLOYEE();
                    _obj_Smhr_Employee.OPERATION = operation.Select;
                    _obj_Smhr_Employee.EMP_ID = Convert.ToInt32(rad_Employees.SelectedValue);
                    _obj_Smhr_Employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dt_Details = BLL.get_Employee(_obj_Smhr_Employee);
                    if (dt_Details != null)
                    {
                        if (dt_Details.Rows.Count != 0)
                        {
                            if (!(Convert.ToBoolean(dt_Details.Rows[0]["EMPREG_IS_TERMINATED"])))//Normal Resignation
                            {
                                if (Convert.ToDateTime(Convert.ToString(dt_Details.Rows[0]["EMP_DOJ"])) > Convert.ToDateTime(rad_ReceievedDate.SelectedDate))
                                {
                                    BLL.ShowMessage(this, "Date Should be Greater than Employee Joining Date");
                                    return;
                                }
                                else if (Convert.ToDateTime(Convert.ToString(dt_Details.Rows[0]["EMPREG_APPROVEDDATE"])) > Convert.ToDateTime(rad_ReceievedDate.SelectedDate))
                                {
                                    BLL.ShowMessage(this, "Date Should be Greater than Employee Resignation Approved Date");
                                    return;
                                }
                                else
                                {
                                    status = BLL.set_Assets_Clearance(_obj_Smhr_Asset_Clearance, _obj_Smhr_Employee, _obj_Smhr_Applicant);
                                }
                            }
                            else
                            {
                                if (Convert.ToBoolean(dt_Details.Rows[0]["EMPREG_IS_TERMINATED"]))// Is Terminated
                                {
                                    if (Convert.ToDateTime(Convert.ToString(dt_Details.Rows[0]["EMP_DOJ"])) > Convert.ToDateTime(rad_ReceievedDate.SelectedDate))
                                    {
                                        BLL.ShowMessage(this, "Date Should be Greater than Employee Join Date");
                                        return;
                                    }
                                    else if (Convert.ToDateTime(Convert.ToString(dt_Details.Rows[0]["EMP_RESGDATE"])) > Convert.ToDateTime(rad_ReceievedDate.SelectedDate))
                                    {
                                        BLL.ShowMessage(this, "Date Should be Greater than Employee Resignation Date");
                                        return;
                                    }
                                    else
                                    {
                                        status = BLL.set_Assets_Clearance(_obj_Smhr_Asset_Clearance, _obj_Smhr_Employee, _obj_Smhr_Applicant);
                                    }
                                }
                            }
                        }
                        if (status == true)
                        {
                            BLL.ShowMessage(this, "Asset(s) Successfully Received");
                        }
                        else
                        {
                            BLL.ShowMessage(this, "Asset(s) not Received");
                        }

                    }
                }

            }

            if (Rg_DepartmentswithAssets.Items.Count > 0)
            {
                if (count == 0)
                {
                    BLL.ShowMessage(this, "Please Select Atleast One Asset");
                    return;
                }
            }
            Get_Employee_Assets(rad_Employees.SelectedValue);
            LoadEmployees();
            //LoadDepartment();
            Rad_Department.Items.Clear();
            Rad_Department.ClearSelection();
            radBU.Items.Clear();
            LoadBusinessUnits();
            tr_EmpDetails.Attributes.Add("style", "visibility:hidden;display:none");
            table_AssetDetails.Attributes.Add("style", "visibility:hidden;display:none");
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Clearance", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    #region MyRegion
    //private bool chk_Validate(DateTime? rad_ReceievedDate)
    //{
    //    try
    //    {
    //        _obj_Smhr_Employee = new SMHR_EMPLOYEE();
    //        _obj_Smhr_Employee.OPERATION = operation.Select;
    //        _obj_Smhr_Employee.EMP_ID = Convert.ToInt32(rad_Employees.SelectedValue.ToString().Split('~')[0]);
    //        _obj_Smhr_Employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //        DataTable dt_Details = BLL.get_Employee(_obj_Smhr_Employee);
    //        if (dt_Details.Rows.Count != 0)
    //        {
    //            if (Convert.ToBoolean(dt_Details.Rows[0]["EMPREG_IS_TERMINATED"]) == 0)//Normal Resignation
    //            {
    //                if (Convert.ToDateTime(Convert.ToString(dt_Details.Rows[0]["EMP_DOJ"])) > Convert.ToDateTime(rad_ReceievedDate))
    //                {
    //                    BLL.ShowMessage(this, "Date Should be Greater than Employee Join Date");
    //                    return true;
    //                }
    //                if (Convert.ToDateTime(Convert.ToString(dt_Details.Rows[0]["EMPREG_APPROVEDDATE"])) > Convert.ToDateTime(rad_ReceievedDate))
    //                {
    //                    BLL.ShowMessage(this, "Date Should be Greater than Employee Resignation Approved Date");
    //                    return true;
    //                }
    //            }
    //            else
    //            {
    //                if (Convert.ToBoolean(dt_Details.Rows[0]["EMPREG_IS_TERMINATED"]) == 1)// Is Terminated
    //                {
    //                    if (Convert.ToDateTime(Convert.ToString(dt_Details.Rows[0]["EMP_DOJ"])) > Convert.ToDateTime(rad_ReceievedDate))
    //                    {
    //                        BLL.ShowMessage(this, "Date Should be Greater than Employee Join Date");
    //                        return true;
    //                    }
    //                    if (Convert.ToDateTime(Convert.ToString(dt_Details.Rows[0]["EMP_RESGDATE"])) > Convert.ToDateTime(rad_ReceievedDate))
    //                    {
    //                        BLL.ShowMessage(this, "Date Should be Greater than Employee Resignation Date");
    //                        return true;
    //                    }
    //                }
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmassetdoc", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //        return false;
    //    }
    //} 
    #endregion
    protected void btn_Cancel_Click1(object sender, EventArgs e)
    {
        try
        {
            Rad_Department.Items.Clear();
            Rad_Department.ClearSelection();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Clearance", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void radBU_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rad_Employees.Items.Clear();
            rad_Employees.ClearSelection();
            Rad_Department.Items.Clear();
            Rad_Department.ClearSelection();
            tr_EmpDetails.Attributes.Add("style", "visibility:hidden;display:none");
            table_AssetDetails.Attributes.Add("style", "visibility:hidden;display:none");
            if (radBU.SelectedIndex > 0)
            {
                LoadEmployees();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Clearance", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
}
