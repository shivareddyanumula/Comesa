using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using SMHR;

public partial class Payroll_leaveYearEnd : System.Web.UI.Page
{
    SMHR_LEAVE_YEAR_END_PROCESS _obj_Leave;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                Load_Combos();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "leaveYearEnd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Process_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddl_FromYear.SelectedIndex >= ddl_ToYear.SelectedIndex)
            {
                BLL.ShowMessage(this, "You Cannot run process. From Year is greater than to Year");
                return;
            }
            else
            {
                _obj_Leave = new SMHR_LEAVE_YEAR_END_PROCESS();
                _obj_Leave.MODE = 4;
                _obj_Leave.FROM_PERIOD = Convert.ToInt32(ddl_FromYear.SelectedValue);
                DataTable dt = BLL.get_From_Period(_obj_Leave);
                if (dt.Rows.Count == 0)
                {
                    bool status = false;
                    _obj_Leave = new SMHR_LEAVE_YEAR_END_PROCESS();
                    _obj_Leave.MODE = 3;
                    _obj_Leave.FROM_PERIOD = Convert.ToInt32(ddl_FromYear.SelectedValue);
                    _obj_Leave.TO_PERIOD = Convert.ToInt32(ddl_ToYear.SelectedValue);
                    status = BLL.set_Leave_Year_Proces(_obj_Leave);
                    if (status == true)
                    {
                        BLL.ShowMessage(this, "Leave Year End Process Successfully Completed");
                        ddl_FromYear.SelectedIndex = 0;
                        ddl_ToYear.Items.Clear();
                        return;
                    }
                    else
                    {
                        BLL.ShowMessage(this, "An Error Occured While doing the process");
                        return;
                    }
                }
                else
                {
                    BLL.ShowMessage(this, "Leave Year End Process Already done for this period");
                    return;
                }
            }
        }
        catch(Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "leaveYearEnd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void Load_Combos()
    {
        try
        {
            _obj_Leave = new SMHR_LEAVE_YEAR_END_PROCESS();
            _obj_Leave.MODE = 1;
            DataTable dt = BLL.get_From_Period(_obj_Leave);
            ddl_FromYear.DataSource = dt;
            ddl_FromYear.DataTextField = "PERIOD_NAME";
            ddl_FromYear.DataValueField = "PERIOD_ID";
            ddl_FromYear.DataBind();
            ddl_FromYear.Items.Insert(0, new RadComboBoxItem("- Select -"));
        }
        catch(Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "leaveYearEnd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void ddl_FromYear_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (ddl_FromYear.SelectedIndex != 0)
            {
                _obj_Leave = new SMHR_LEAVE_YEAR_END_PROCESS();
                _obj_Leave.MODE = 1;
                DataTable dt = BLL.get_From_Period(_obj_Leave);
                ddl_ToYear.DataSource = dt;
                ddl_ToYear.DataTextField = "PERIOD_NAME";
                ddl_ToYear.DataValueField = "PERIOD_ID";
                ddl_ToYear.DataBind();
                ddl_ToYear.Items.Insert(0, new RadComboBoxItem("- Select -"));
            }
            else
            {
                ddl_ToYear.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "leaveYearEnd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            ddl_FromYear.SelectedIndex = 0;
            ddl_ToYear.Items.Clear();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "leaveYearEnd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
