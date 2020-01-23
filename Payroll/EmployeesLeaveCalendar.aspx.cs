using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SPMS;

public partial class Payroll_EmployeesLeaveCalendar : System.Web.UI.Page
{
    PMS_GETEMPLOYEE _obj_PMS_getemployee;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "function pageLoad(){   }", true);
            if (!Page.IsPostBack)
            {
                LoadEmployees();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeesLeaveCalendar", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadEmployees()
    {
        try
        {
            _obj_PMS_getemployee = new PMS_GETEMPLOYEE();
            _obj_PMS_getemployee.Mode = 1;
            _obj_PMS_getemployee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            _obj_PMS_getemployee.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = Pms_Bll.get_RMEmployees(_obj_PMS_getemployee);
            rcmb_Employee.Items.Clear();
            rcmb_Employee.DataSource = dt;
            rcmb_Employee.DataTextField = "employee";
            rcmb_Employee.DataValueField = "EMPID";
            rcmb_Employee.DataBind();
            rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            rcmb_Employee.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeesLeaveCalendar", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Cal_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "function pageLoad(){  ShowPopForm(); }", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeesLeaveCalendar", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_Employee_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Employee.SelectedIndex > 0)
                Session["CAL_EMP_ID"] = Convert.ToInt32(rcmb_Employee.SelectedItem.Value);
            else
                Session.Remove("CAL_EMP_ID");
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeesLeaveCalendar", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
