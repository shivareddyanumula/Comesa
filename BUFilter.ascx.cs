using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

[ValidationProperty("EmployeeID")]
public partial class BUFilter : System.Web.UI.UserControl
{
    #region get/set RadCombobox Values

    //private int _BusinessUnitID;
    public int BusinessUnitID
    {
        get { return (string.IsNullOrEmpty(RadBusinessUnit.SelectedValue) ? 0 : Convert.ToInt32(RadBusinessUnit.SelectedValue)); }
        set { RadBusinessUnit.SelectedIndex = RadBusinessUnit.Items.IndexOf(RadBusinessUnit.Items.FindItemByValue(Convert.ToString(value)));
        if (RadBusinessUnit.SelectedIndex > 0)
            RadBusinessUnit_SelectedIndexChanged(null, null);
        }
    }

    //private int _DirectorateID;
    public int DirectorateID
    {
        get { return (string.IsNullOrEmpty(RadDirectorate.SelectedValue) ? 0 : Convert.ToInt32(RadDirectorate.SelectedValue)); }
        set { RadDirectorate.SelectedIndex = RadDirectorate.Items.IndexOf(RadDirectorate.Items.FindItemByValue(Convert.ToString(value)));
        if (RadDirectorate.SelectedIndex > 0)
            RadDirectorate_SelectedIndexChanged(null, null);
        }
        //set { _DirectorateID = value; }
    }

    //private int _DepartmentID;
    public int DepartmentID
    {
        get { return (string.IsNullOrEmpty(RadDepartment.SelectedValue) ? 0 : Convert.ToInt32(RadDepartment.SelectedValue)); }
        set { RadDepartment.SelectedIndex = RadDepartment.Items.IndexOf(RadDepartment.Items.FindItemByValue(Convert.ToString(value)));
        if (RadDepartment.SelectedIndex > 0)
            RadDepartment_SelectedIndexChanged(null, null);
        }
        //set { _DepartmentID = value; }
    }

    //private int _employeeid;
    public int EmployeeID
    {
        get { return (string.IsNullOrEmpty(RadEmployee.SelectedValue) ? 0 : Convert.ToInt32(RadEmployee.SelectedValue)); }
        set
        {
            if (value > 0)
            {
                RadEmployee.SelectedIndex = RadEmployee.Items.IndexOf(RadEmployee.Items.FindItemByValue(Convert.ToString(value)));
                RadEmployee_SelectedIndexChanged(null, null);
            }
            else
                RadEmployee.SelectedIndex = 0;
        }
        //set { this._employeeid = value; }
    }

    #endregion

    private string _businessUnit;
    public string BusinessUnit
    {
        get { return this._businessUnit; }
        set { this._businessUnit = value; }
    }

    private string _directorate;
    public string Directorate
    {
        get { return this._directorate; }
        set { this._directorate = value; }
    }

    private string _department;
    public string Department
    {
        get { return this._department; }
        set { this._department = value; }
    }

    private string _employee;
    public string Employee
    {
        get { return RadEmployee.SelectedItem.Text; }
        set { this._employee = value; }
    }
    

    #region Hide RadCombos
    //to hide RadComboBoxes
    private bool _HideEmployee;
    public bool HideEmployee
    {
        get { return _HideEmployee; }
        set { this._HideEmployee = value; }
    }

    private bool _HideDepartment;
    public bool HideDepartment
    {
        get { return _HideDepartment; }
        set { this._HideDepartment = value; }
    }

    private bool _HideDirectorate;
    public bool HideDirectorate
    {
        get { return _HideDirectorate; }
        set { this._HideDirectorate = value; }
    }
    #endregion

    #region Enable/Disable RadCombos
    //to enable/disable RadComboBoxes
    
    private bool _DisableEmployee;
    public bool DisableEmployee
    {
        get { return _DisableEmployee; }
        set
        {
            if (value)
                RadEmployee.Enabled = true;
            else
                RadEmployee.Enabled = false;
        }
    }

    private bool _DisableDepartment;
    public bool DisableDepartment
    {
        get { return _DisableDepartment; }
        set
        {
            if (value)
                RadDepartment.Enabled = true;
            else
                RadDepartment.Enabled = false;
        }
    }

    private bool _DisableDirectorate;
    public bool DisableDirectorate
    {
        get { return _DisableDirectorate; }
        set
        {
            if (value)
                RadDirectorate.Enabled = true;
            else
                RadDirectorate.Enabled = false;
        }
    }

    private bool _DisableBusinessUnit;
    public bool DisableBusinessUnit
    {
        get { return _DisableBusinessUnit; }
        set
        {
            if (value)
                RadBusinessUnit.Enabled = true;
            else
                RadBusinessUnit.Enabled = false;
        }
    }
    #endregion
    
    #region Hide * symbol (span )
    //to hide * symbol
    private bool _ShowEmployeeSpan;
    public bool ShowEmployeeSpan
    {
        get { return _ShowEmployeeSpan; }
        set { this._ShowEmployeeSpan = value; }
    }

    private bool _ShowDepartmentSpan;
    public bool ShowDepartmentSpan
    {
        get { return _ShowDepartmentSpan; }
        set { this._ShowDepartmentSpan = value; }
    }

    private bool _ShowDirectorateSpan;
    public bool ShowDirectorateSpan
    {
        get { return _ShowDirectorateSpan; }
        set { this._ShowDirectorateSpan = value; }
    }

    private bool _ShowBusinessUnitSpan;
    public bool ShowBusinessUnitSpan
    {
        get { return _ShowBusinessUnitSpan; }
        set { this._ShowBusinessUnitSpan = value; }
    }
    #endregion

    public event EventHandler BUFilterRadEmployee_SelectedIndexChanged;

    SMHR_BUSINESSUNIT _obj_smhr_bu = new SMHR_BUSINESSUNIT();
    int organisationID;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            organisationID = Convert.ToInt32(Session["ORG_ID"]);
            if (!Page.IsPostBack)
            {

                BindDropDowns();
                if (HideEmployee)
                    trEmp.Visible = false;
                if (HideDepartment)
                    trDept.Visible = false;
                if (HideDirectorate)
                    trDirec.Visible = false;
                if (DisableBusinessUnit)
                    RadBusinessUnit.Enabled = false;
                if (DisableDirectorate)
                    RadDirectorate.Enabled = false;
                if (DisableDepartment)
                    RadDepartment.Enabled = false;

                //To hide * symbol
                if (ShowEmployeeSpan)
                    spEmp.Visible = true;
                if (ShowDepartmentSpan)
                    spDep.Visible = true;
                if (ShowDirectorateSpan)
                    spDir.Visible = true;
                if (ShowBusinessUnitSpan)
                    spBU.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "BUFilter", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void BindDropDowns()
    {

        DataSet ds = BLL.GetEmployeeFilterDetails(organisationID, null, null, null);
        BindBusinessUnit(ds.Tables[0]);
        //BindDirectorate(ds.Tables[1]);
        //BindDepartment(ds.Tables[2]);
       //BindEmployee(ds.Tables[3]);

    }

    private void BindBusinessUnit(DataTable dt)
    {
        RadBusinessUnit.DataSource = dt;
        RadBusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
        RadBusinessUnit.DataValueField = "BUSINESSUNIT_ID";
        RadBusinessUnit.DataBind();
        RadBusinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));
    }
    private void BindDirectorate(DataTable dt)
    {
        RadDirectorate.DataSource = dt;
        RadDirectorate.DataTextField = "DIRECTORATE_CODE";
        RadDirectorate.DataValueField = "DIRECTORATE_ID";
        RadDirectorate.DataBind();
        RadDirectorate.Items.Insert(0, new RadComboBoxItem("Select"));
    }
    private void BindDepartment(DataTable dt)
    {
        RadDepartment.DataSource = dt;
        RadDepartment.DataTextField = "DEPARTMENT_NAME";
        RadDepartment.DataValueField = "DEPARTMENT_ID";
        RadDepartment.DataBind();
        RadDepartment.Items.Insert(0, new RadComboBoxItem("All"));
    }
    private void BindEmployee(DataTable dt)
    {
        RadEmployee.DataSource = dt;
        RadEmployee.DataTextField = "EMPNAME";
        RadEmployee.DataValueField = "EMP_ID";
        RadEmployee.DataBind();
        RadEmployee.Items.Insert(0, new RadComboBoxItem("Select"));
    }
    protected void RadBusinessUnit_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (RadBusinessUnit.SelectedIndex > 0)
            {
                DataSet ds = BLL.GetEmployeeFilterDetails(organisationID, Convert.ToInt32(RadBusinessUnit.SelectedValue), null, null);
                BindDirectorate(ds.Tables[1]);
                //BindDepartment(ds.Tables[2]);

                //To populate employee details
                BindEmployee(ds.Tables[3]);

                //To clear Departments
                RadDepartment.Items.Clear();
                RadDepartment.ClearSelection();
            }
            else
            {
                RadDirectorate.Items.Clear();
                RadDirectorate.ClearSelection();
                RadDirectorate.Text = string.Empty;
                RadDepartment.Items.Clear();
                RadDepartment.ClearSelection();
                RadDepartment.Text = string.Empty;
                RadEmployee.Items.Clear();
                RadEmployee.ClearSelection();
                RadEmployee.Text = string.Empty;

                RadComboBox rcbparent = (RadComboBox)Parent.FindControl("radGradeName");
                if (rcbparent != null)
                {
                    rcbparent.Items.Clear();
                    rcbparent.ClearSelection();
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "BUFilter", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void RadDirectorate_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (RadDirectorate.SelectedIndex > 0)
            {
                DataSet ds = BLL.GetEmployeeFilterDetails(organisationID, Convert.ToInt32(RadBusinessUnit.SelectedValue), Convert.ToInt32(RadDirectorate.SelectedValue), null);
                BindDepartment(ds.Tables[2]);

                //To populate employee details
                BindEmployee(ds.Tables[3]);
            }
            else
            {
                DataSet ds = BLL.GetEmployeeFilterDetails(organisationID, Convert.ToInt32(RadBusinessUnit.SelectedValue), null, null);
                BindEmployee(ds.Tables[3]);
                RadDepartment.Items.Clear();
                RadDepartment.ClearSelection();
                RadDepartment.Text = string.Empty;
                RadComboBox rcbparent = (RadComboBox)Parent.FindControl("radGradeName");
                if (rcbparent != null)
                {
                    rcbparent.Items.Clear();
                    rcbparent.ClearSelection();
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "BUFilter", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void RadDepartment_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (RadDepartment.SelectedIndex > 0)
            {
                if (!HideEmployee)
                {
                    //To populate employee details
                    DataSet ds = BLL.GetEmployeeFilterDetails(organisationID, Convert.ToInt32(RadBusinessUnit.SelectedValue), Convert.ToInt32(RadDirectorate.SelectedValue), Convert.ToInt32(RadDepartment.SelectedValue));
                    BindEmployee(ds.Tables[3]);
                }
            }
            else
            {
                DataSet ds = BLL.GetEmployeeFilterDetails(organisationID, Convert.ToInt32(RadBusinessUnit.SelectedValue), Convert.ToInt32(RadDirectorate.SelectedValue), null);
                BindEmployee(ds.Tables[3]);
                RadComboBox rcbparent = (RadComboBox)Parent.FindControl("radGradeName");
                if (rcbparent != null)
                {
                    rcbparent.Items.Clear();
                    rcbparent.ClearSelection();
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "BUFilter", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    
    }
    protected void RadEmployee_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            //To pass emp_id to property, to use in another page
            //if (!string.IsNullOrEmpty(RadEmployee.SelectedValue))
            //{
            //this.EmployeeID = Convert.ToInt32(RadEmployee.SelectedValue);
            //this.Employee = Convert.ToString(RadEmployee.SelectedValue);
            //if (BUFilterRadEmployee_SelectedIndexChanged != null)
            //BUFilterRadEmployee_SelectedIndexChanged(this, EventArgs.Empty);
            //}


            RadComboBox rcbparent = (RadComboBox)Parent.FindControl("radGradeName");
            if (rcbparent != null)
            {
                if (RadEmployee.SelectedIndex > 0)
                {

                    SMHR_EMPLOYEE obj_smhr_employee = new SMHR_EMPLOYEE();
                    obj_smhr_employee.OPERATION = operation.GETGRADE;
                    obj_smhr_employee.EMP_ID = Convert.ToInt32(RadEmployee.SelectedValue);
                    DataTable dt = BLL.get_Employee(obj_smhr_employee);
                    rcbparent.DataSource = dt;
                    rcbparent.DataValueField = "EMPLOYEEGRADE_ID";
                    rcbparent.DataTextField = "EMPLOYEEGRADE_CODE";
                    rcbparent.DataBind();
                }
                else
                {
                    rcbparent.Items.Clear();
                    rcbparent.ClearSelection();
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "BUFilter", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    public void ClearControls()
    {
        try
        {
            BindDropDowns();
            RadDirectorate.Items.Clear();
            RadDirectorate.Text = string.Empty;
            RadDepartment.Items.Clear();
            RadDepartment.Text = string.Empty;
            RadEmployee.Items.Clear();
            RadEmployee.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "BUFilter", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}