using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using Telerik.Web.UI;
using SMHR;
using System.Drawing;


public partial class Security_frm_LeaveChart : System.Web.UI.Page
{
    SMHR_DAHSBOARD _obj_smhr_Dashboard;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                loadPeriod();
                SMHR_PERIOD _obj_smhr_Period = new SMHR_PERIOD();
                _obj_smhr_Period.OPERATION = operation.Empty;
                _obj_smhr_Period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_DetailsLoad = BLL.get_PeriodHeaderDetails(_obj_smhr_Period);
                if (dt_DetailsLoad.Rows.Count > 0)
                {
                    rcmbPeriod.SelectedIndex = rcmbPeriod.Items.FindItemIndexByValue(Convert.ToString(dt_DetailsLoad.Rows[0][0]));
                }
                loadPeriodElement();
                SMHR_PERIODDTL obj_smhr_Prddtl = new SMHR_PERIODDTL();
                obj_smhr_Prddtl.OPERATION = operation.Empty;
                obj_smhr_Prddtl.PRDDTL_PERIOD_ID = Convert.ToInt32(dt_DetailsLoad.Rows[0][0]);
                DataTable dtPrddtl = BLL.get_PeriodDetails(obj_smhr_Prddtl);
                if (dtPrddtl.Rows.Count > 0)
                {
                    rcmbPeriodElement.SelectedIndex = rcmbPeriodElement.Items.FindItemIndexByValue(Convert.ToString(dtPrddtl.Rows[0][0]));
                }
            }

            #region Display Leave-Balance in Pie-Chart
            if (!Page.IsPostBack)
            {
                bool status = false;

                Color[] barColors = new Color[8]{
       Color.Purple,
       Color.SteelBlue,
       Color.Aqua,
       Color.Yellow,
       Color.Navy,
       Color.Green,
       Color.Blue,
       Color.Red
   };


                SMHR_PERIOD obj_smhr_Period = new SMHR_PERIOD();
                obj_smhr_Period.OPERATION = operation.Empty;
                obj_smhr_Period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_Details = BLL.get_PeriodHeaderDetails(obj_smhr_Period);
                if (dt_Details.Rows.Count != 0)
                {
                    _obj_smhr_Dashboard = new SMHR_DAHSBOARD();
                    _obj_smhr_Dashboard.OPERATION = operation.Select_New;
                    _obj_smhr_Dashboard.SMHR_DASHBOARD_PERIODID = Convert.ToInt32(dt_Details.Rows[0][0]);
                    _obj_smhr_Dashboard.SMHR_DASHBOARD_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                    DataTable dt_LeaveBalance = BLL.get_EMP_ID(_obj_smhr_Dashboard);
                    if (dt_LeaveBalance.Rows.Count != 0)
                    {

                        for (int dt_rowcount = 0; dt_rowcount < dt_LeaveBalance.Rows.Count; dt_rowcount++)
                        {
                            if (dt_LeaveBalance.Rows.Count == 1)
                            {
                                if (Convert.ToDouble(dt_LeaveBalance.Rows[dt_rowcount]["LT_CURRENTBALANCE"]) == 0.00)
                                {
                                    lbl_ZeroLeaves.Visible = true;
                                    lbl_ZeroLeaves.Text = "No leaves available";
                                    status = true;
                                }
                            }
                        }
                        if (status == false)
                        {
                            int i = 0;
                            RadChart2.Visible = true;
                            RadChart2.DataSource = dt_LeaveBalance;
                            RadChart2.DataBind();
                            foreach (var item in RadChart2.Series[0].Items)
                            {
                                item.Appearance.FillStyle.MainColor = barColors[i++];
                            }

                        }
                    }
                    else
                    {
                        lbl_ZeroLeaves.Visible = true;
                        lbl_ZeroLeaves.Text = "No leaves available";

                    }
                }
                else
                {
                    BLL.ShowMessage(this, "Current Period does not contains Leave Balances");
                }
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveChart", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
            #endregion
    }

    protected void RadChart2_ItemDataBound(object sender, Telerik.Charting.ChartItemDataBoundEventArgs e)
    {
        try
        {
            e.SeriesItem.Name = ((DataRowView)e.DataItem)["LEAVEMASTER_CODE"].ToString();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveChart", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmbPeriod_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            trLeaveBalance.Visible = false;
            if (rcmbPeriod.SelectedIndex > 0)
            {
                loadPeriodElement();
            }
            else
            {
                rcmbPeriodElement.Items.Clear();
                rcmbPeriodElement.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveChart", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmbPeriodElement_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmbPeriodElement.SelectedIndex > 0)
            {
                trLeaveBalance.Visible = true;
                bool status = false;

                Color[] barColors = new Color[8]{
       Color.Purple,
       Color.SteelBlue,
       Color.Aqua,
       Color.Yellow,
       Color.Navy,
       Color.Green,
       Color.Blue,
       Color.Red
   };
                _obj_smhr_Dashboard = new SMHR_DAHSBOARD();
                _obj_smhr_Dashboard.OPERATION = operation.Empty;
                _obj_smhr_Dashboard.SMHR_DASHBOARD_PRDDTL_ID = Convert.ToInt32(rcmbPeriodElement.SelectedValue);
                _obj_smhr_Dashboard.SMHR_DASHBOARD_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                DataTable dtLeaveDtl = BLL.get_EMP_ID(_obj_smhr_Dashboard);
                if (dtLeaveDtl.Rows.Count > 0)
                {
                    lbl_ZeroLeaves.Visible = false;
                    for (int dt_rowcount = 0; dt_rowcount < dtLeaveDtl.Rows.Count; dt_rowcount++)
                    {
                        if (dtLeaveDtl.Rows.Count == 1)
                        {
                            if (Convert.ToDouble(dtLeaveDtl.Rows[dt_rowcount]["LT_CURRENTBALANCE"]) == 0.00)
                            {
                                lbl_ZeroLeaves.Visible = true;
                                lbl_ZeroLeaves.Text = "No leaves available";
                                trLeaveBalance.Visible = false;
                                status = true;
                            }
                        }
                    }
                    if (status == false)
                    {
                        int i = 0;
                        RadChart2.Visible = true;
                        RadChart2.DataSource = dtLeaveDtl;
                        RadChart2.DataBind();
                        foreach (var item in RadChart2.Series[0].Items)
                        {
                            item.Appearance.FillStyle.MainColor = barColors[i++];
                        }
                    }
                }
                else
                {
                    lbl_ZeroLeaves.Visible = true;
                    lbl_ZeroLeaves.Text = "No leaves available";
                    trLeaveBalance.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveChart", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void loadPeriod()
    {
        try
        {
            SMHR_PERIOD _obj_smhr_period = new SMHR_PERIOD();
            DataTable dt_Details = new DataTable();
            _obj_smhr_period.OPERATION = operation.Select;
            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_PeriodHeaderDetails(_obj_smhr_period);
            if (dt_Details.Rows.Count > 0)
            {
                rcmbPeriod.DataSource = dt_Details;
                rcmbPeriod.DataTextField = "PERIOD_NAME";
                rcmbPeriod.DataValueField = "PERIOD_ID";
                rcmbPeriod.DataBind();
                rcmbPeriod.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveChart", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void loadPeriodElement()
    {
        try
        {
            SMHR_PAYROLL _obj_smhr_payroll = new SMHR_PAYROLL();
            _obj_smhr_payroll.PERIODDTLID = Convert.ToInt32(rcmbPeriod.SelectedValue);
            _obj_smhr_payroll.MODE = 28;
            DataTable dt_Details = BLL.get_payrolltrans(_obj_smhr_payroll);
            if (dt_Details.Rows.Count > 0)
            {
                rcmbPeriodElement.DataSource = dt_Details;
                rcmbPeriodElement.DataTextField = "PRDDTL_NAME";
                rcmbPeriodElement.DataValueField = "PRDDTL_ID";
                rcmbPeriodElement.DataBind();
                rcmbPeriodElement.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveChart", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
