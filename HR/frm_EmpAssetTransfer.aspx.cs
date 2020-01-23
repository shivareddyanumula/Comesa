using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class HR_frm_EmpAssetTransfer : System.Web.UI.Page
{
    SMHR_EMPASSETTRANSFER obj_smhr_EmpAssetTransfer;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    DataSet ds = new DataSet();
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
      try
      {
        if (!IsPostBack)
        {
           //code for security privilage
            Session.Remove("WRITEFACILITY");
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.OPERATION = operation.Empty1;
            _obj_SMHR_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Employee Asset Transfer");//EMPASSETTRANSFER");
            DataTable dtformdtls = BLL.get_LoginInfo(_obj_SMHR_LoginInfo);
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
                Rg_EmpAssetTransfer.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                //btn_Save.Visible = false;
                //btn_Update.Visible = false;
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
            LoadBusinessUnits();
            Page.Validate();
        }
      }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpAssetTransfer", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    public void LoadGrid()
    {
        try
        {
            if (ddl_Employee.SelectedItem.Value != string.Empty)
            {
                obj_smhr_EmpAssetTransfer = new SMHR_EMPASSETTRANSFER();
                obj_smhr_EmpAssetTransfer.EMPASSETTRANSFER_BUSINESSUNIT_ID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
                obj_smhr_EmpAssetTransfer.EMPASSETTRANSFER_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                obj_smhr_EmpAssetTransfer.EMPASSETTRANSFER_FROMEMP_ID = Convert.ToInt32(ddl_Employee.SelectedValue);
                DataTable DT = BLL.get_EmployeeAssetsTransfer(obj_smhr_EmpAssetTransfer);
                Rg_EmpAssetTransfer.DataSource = DT;
                Rg_EmpAssetTransfer.DataBind();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpAssetTransfer", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void Rg_EmpAssetTransfer_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpAssetTransfer", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    private void LoadBusinessUnits()
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
            ddl_Employee.Items.Clear();
            ddl_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpAssetTransfer", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void ddl_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            ddl_Employee.Items.Clear();
            Rg_EmpAssetTransfer.Visible = false;
            btn_Transfer.Visible = false;
            btn_Cancel.Visible = false;
            LoadEmployees();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpAssetTransfer", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    private void LoadEmployees()
    {
        try
        {
            if (ddl_BusinessUnit.SelectedItem.Value != string.Empty)
            {
                obj_smhr_EmpAssetTransfer = new SMHR_EMPASSETTRANSFER();
                DataTable DT_Details = new DataTable();
                obj_smhr_EmpAssetTransfer.OPERATION = operation.Empty;
                obj_smhr_EmpAssetTransfer.EMPASSETTRANSFER_BUSINESSUNIT_ID = Convert.ToInt32(ddl_BusinessUnit.SelectedItem.Value);
                obj_smhr_EmpAssetTransfer.EMPASSETTRANSFER_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DT_Details = BLL.get_AssetEmpDetails(obj_smhr_EmpAssetTransfer);
                ddl_Employee.DataSource = DT_Details;
                ddl_Employee.DataTextField = "EMPNAME";
                ddl_Employee.DataValueField = "EMP_ID";
                ddl_Employee.DataBind();
                ddl_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
            }
            else
            {
                ddl_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpAssetTransfer", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    public DataTable LoadGridEmployees()
    {
        try
        {
            if (ddl_BusinessUnit.SelectedItem.Value != string.Empty)
            {
                obj_smhr_EmpAssetTransfer = new SMHR_EMPASSETTRANSFER();
                obj_smhr_EmpAssetTransfer.OPERATION = operation.Empty;
                obj_smhr_EmpAssetTransfer.EMPASSETTRANSFER_BUSINESSUNIT_ID = Convert.ToInt32(ddl_BusinessUnit.SelectedItem.Value);
                obj_smhr_EmpAssetTransfer.EMPASSETTRANSFER_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                obj_smhr_EmpAssetTransfer.EMPASSETTRANSFER_FROMEMP_ID = Convert.ToInt32(ddl_Employee.SelectedValue);
                DataTable dt = BLL.get_AssetEmpDetails(obj_smhr_EmpAssetTransfer);

                return dt;
            }
            else
                return null;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpAssetTransfer", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return null;
        }
    }
    protected void ddl_Employee_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (ddl_Employee.SelectedItem.Value != string.Empty)
            {
                LoadGrid();
                Rg_EmpAssetTransfer.Visible = true;
                btn_Transfer.Visible = true;
                btn_Cancel.Visible = true;
            }
            else
            {
                Rg_EmpAssetTransfer.Visible = false;
                btn_Transfer.Visible = false;
                btn_Cancel.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpAssetTransfer", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void btn_Transfer_Click(object sender, EventArgs e)
    {
        try
        {
            CheckBox chkBox = new CheckBox();
            Label EMPASSETDOC_ID = new Label();
            RadComboBox rcmbToEmployee = new RadComboBox();
            RadDatePicker rdpIssuedDate = new RadDatePicker();
            bool status = false;
            bool emptyFlag = false;
            if (Rg_EmpAssetTransfer.Items.Count == 0)
            {
                BLL.ShowMessage(this, "No Assets Data Found for Selected Employee");
                return;
            }
            foreach (GridDataItem item in Rg_EmpAssetTransfer.Items)
            {
                CheckBox chk = item.FindControl("chkCheck") as CheckBox;
                if (chk.Checked == true)
                    emptyFlag = true;
            }
            if (emptyFlag == false)
            {
                BLL.ShowMessage(this, "Please Select Employees to Transfer");
                return;
            }

            for (int index = 0; index <= Rg_EmpAssetTransfer.Items.Count - 1; index++)
            {
                chkBox = Rg_EmpAssetTransfer.Items[index].FindControl("chkCheck") as CheckBox;
                //EMPASSETDOC_ID = Rg_EmpAssetTransfer.Items[index]["EMPASSETDOC_ID"].Text;  .FindControl("EMPASSETDOC_ID") as Label;
                rcmbToEmployee = Rg_EmpAssetTransfer.Items[index].FindControl("rcmbToEmployee") as RadComboBox;
                rdpIssuedDate = Rg_EmpAssetTransfer.Items[index].FindControl("rdpIssuedDate") as RadDatePicker;

                if (chkBox.Checked)
                {
                    if (rcmbToEmployee.SelectedValue == "0")
                    {
                        BLL.ShowMessage(this, "Please Select Transfer Employee");
                        return;
                    }
                    if (ddl_Employee.SelectedValue == rcmbToEmployee.SelectedValue)
                    {
                        BLL.ShowMessage(this, "Asset cannot be Transferred to Same Employee");
                        return;
                    }
                    if (rdpIssuedDate.SelectedDate == null)
                    {
                        BLL.ShowMessage(this, "Please Select Valid Date of Transfer");
                        return;
                    }
                    SMHR_EMPLOYEE oSmhrEmployee = new SMHR_EMPLOYEE();
                    oSmhrEmployee.EMP_ID = Convert.ToInt32(rcmbToEmployee.SelectedValue);
                    DataTable dt = BLL.get_Employeedetail(oSmhrEmployee);
                    if (rdpIssuedDate.SelectedDate < Convert.ToDateTime(dt.Rows[0]["EMP_DOJ"]))
                    {
                        BLL.ShowMessage(this, "Transfer Date Should be Future Date");
                        return;
                    }

                    obj_smhr_EmpAssetTransfer = new SMHR_EMPASSETTRANSFER();
                    obj_smhr_EmpAssetTransfer.EMPASSETDOC_ID = Convert.ToInt32(Rg_EmpAssetTransfer.Items[index]["ASSET_ID"].Text);
                    obj_smhr_EmpAssetTransfer.DEPARTMENT_ID = Convert.ToInt32(Rg_EmpAssetTransfer.Items[index]["ASSET_DEPARTMENT_ID"].Text);
                    obj_smhr_EmpAssetTransfer.EMPASSETTRANSFER_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    obj_smhr_EmpAssetTransfer.EMPASSETTRANSFER_FROMEMP_ID = Convert.ToInt32(ddl_Employee.SelectedValue);
                    obj_smhr_EmpAssetTransfer.EMPASSETTRANSFER_TOEMP_ID = Convert.ToInt32(rcmbToEmployee.SelectedValue);
                    obj_smhr_EmpAssetTransfer.EMPASSETTRANSFER_BUSINESSUNIT_ID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
                    obj_smhr_EmpAssetTransfer.EMPASSETTRANSFER_ISSUEDDATE = Convert.ToDateTime(rdpIssuedDate.SelectedDate).ToShortDateString();
                    obj_smhr_EmpAssetTransfer.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    obj_smhr_EmpAssetTransfer.CREATEDDATE = DateTime.Now;
                    obj_smhr_EmpAssetTransfer.OPERATION = operation.Insert;

                    status = BLL.set_EmployeeAssetsTransfer(obj_smhr_EmpAssetTransfer);


                }

            }
            if (status == true)
            {
                LoadGrid();
                BLL.ShowMessage(this, "Assets Transferred Successfully");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpAssetTransfer", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            Rg_EmpAssetTransfer.Visible = false;
            btn_Transfer.Visible = false;
            btn_Cancel.Visible = false;
            LoadBusinessUnits();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpAssetTransfer", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

}