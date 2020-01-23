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
using SPMS;

public partial class PMS_frm_Pms_Rating_chart : System.Web.UI.Page
{
    SMHR_DAHSBOARD _obj_smhr_Dashboard;
    PMS_Appraisalcycle _obj_Pms_Appraisalcycle;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                Load_BU();
                RadChart2.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_Rating_chart", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Load_BU()
    {
        try
        {
            SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
            _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"].ToString());
            rcmb_BU.Items.Clear();
            DataTable dtBU= BLL.get_Business_Units(_obj_smhr_logininfo);
            if (dtBU.Rows.Count > 0)
            {
                rcmb_BU.DataSource = dtBU;
                rcmb_BU.DataTextField = "BUSINESSUNIT_CODE";
                rcmb_BU.DataValueField = "BUSINESSUNIT_ID";
                rcmb_BU.DataBind();
                rcmb_BU.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
            rcmb_AppCycle.Items.Clear();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_Rating_chart", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void RadChart2_ItemDataBound(object sender, Telerik.Charting.ChartItemDataBoundEventArgs e)
    {
        try
        {
            e.SeriesItem.Name = ((DataRowView)e.DataItem)["label"].ToString();
            e.SeriesItem.YValue = -e.SeriesItem.YValue; 
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_Rating_chart", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_BU_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            RadChart2.Visible = false;
            if (rcmb_BU.SelectedIndex > 0)
            {
                rcmb_AppCycle.ClearSelection();
                rcmb_AppCycle.Items.Clear();
                rcmb_AppCycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

                _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                _obj_Pms_Appraisalcycle.MODE = 9;
                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["org_id"]);
                DataTable DT_AppraisalCycle = new DataTable();
                DT_AppraisalCycle = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                if (DT_AppraisalCycle.Rows.Count != 0)
                {
                    rcmb_AppCycle.Items.Clear();
                    rcmb_AppCycle.DataSource = DT_AppraisalCycle;
                    rcmb_AppCycle.DataTextField = "APPRCYCLE_NAME";
                    rcmb_AppCycle.DataValueField = "APPRCYCLE_ID";
                    rcmb_AppCycle.DataBind();
                    rcmb_AppCycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                }
            }
            else
            {
                rcmb_AppCycle.ClearSelection();
                rcmb_AppCycle.Items.Clear();
                rcmb_AppCycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_Rating_chart", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_AppCycle_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_AppCycle.SelectedIndex > 0)
            {

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
                DataTable dt = Dal.ExecuteQuery("EXEC USP_PMS_APPRAISALSTATUS @MODE=9, @APP_STATUS_APPRAISALCYCLE =" + Convert.ToInt32(rcmb_AppCycle.SelectedItem.Value));
                if (dt.Rows.Count > 0)
                {
                    String[] Rating = new String[] { "A", "B", "C" };
                    List<String> diffRating = new List<String>();
                    String[] diffRatingArr = new String[] { };
                    for (int dtIndex = 0; dtIndex < dt.Rows.Count; dtIndex++)
                    {
                        diffRating.Add(Convert.ToString(dt.Rows[dtIndex][0]));
                    }
                    diffRatingArr = diffRating.ToArray();
                    String[] array = new String[] { };
                    IEnumerable<String> diff = Rating.Except(diffRatingArr);
                    array = diff.Cast<String>().ToArray<String>();
                    for (int arrayIndex = 0; arrayIndex < array.Count<String>(); arrayIndex++)
                    {
                        dt.Rows.Add(array[arrayIndex], 0, 0, array[arrayIndex] + "-" + 0);
                    }
                    DataColumn dc = new DataColumn();
                    dc.ColumnName = "value";
                    dt.Columns.Add(dc);
                    dt.Rows[0][4] = "1";
                    dt.Rows[1][4] = "2";
                    dt.Rows[2][4] = "3";
                    RadChart2.DataSource = dt;
                    RadChart2.DataBind();
                    int i = 0;
                    foreach (var item in RadChart2.Series[0].Items)
                    {
                        item.Appearance.FillStyle.MainColor = barColors[i++];
                    }
                    RadChart2.Visible = true;
                }
                else
                {
                    RadChart2.Visible = false;
                    BLL.ShowMessage(this, "No Records are Available for the Selected Parameters.");
                    return;
                }
            }
            else
            {
                RadChart2.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_Rating_chart", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
