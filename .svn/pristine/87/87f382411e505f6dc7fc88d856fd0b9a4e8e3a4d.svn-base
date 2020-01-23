using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Data;
using Telerik.Web.UI;

public partial class Payroll_frm_YearEndLeaveProcess : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                LoadCombos();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_YearEndLeaveProcess", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        
    }

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }
    private void LoadCombos()
    {
        try
        {
            ddl_BusinessUnit.Items.Clear();
            SMHR_LEAVEAPP _obj_Smhr_LeaveApp = new SMHR_LEAVEAPP();
            _obj_Smhr_LeaveApp.MODE = 1;

            ddl_BusinessUnit.DataSource = BLL.get_EmpLeaveDetails(_obj_Smhr_LeaveApp);
            ddl_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            ddl_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            ddl_BusinessUnit.DataBind();
            ddl_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

            DataTable dt = BLL.get_Year(2);
            rtxt_Period.Text = Convert.ToString(dt.Rows[0][0]);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_YearEndLeaveProcess", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        
    }

    protected void btn_LYEtran_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = BLL.get_ConfigDetails(new SMHR_GLOBALCONFIG());
            if (Convert.ToBoolean(dt.Rows[0]["GLOBALCONFIG_LEAVETRANFLAG"]) == false)
            {
                BLL.ShowMessage(this, "Please set the flag to run Year End Processing for Leaves");
                return;
            }
            SMHR_LEAVEBALANCE _obj_smhr_leavebalance = new SMHR_LEAVEBALANCE();
            _obj_smhr_leavebalance.Year = Convert.ToString(rtxt_Period.Text);
            _obj_smhr_leavebalance.BUID = Convert.ToInt32(ddl_BusinessUnit.SelectedItem.Value);
            bool result = BLL.LeaveYearEndProcess(_obj_smhr_leavebalance);

            if (result == true)
            {
                BLL.ShowMessage(this, "Leave Year End Processing Done Successfully");

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_YearEndLeaveProcess", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    
}
