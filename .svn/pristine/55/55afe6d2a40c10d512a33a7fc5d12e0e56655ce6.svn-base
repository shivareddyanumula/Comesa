using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Telerik.Web.UI;

public partial class Payroll_frm_downloadesi : System.Web.UI.Page
{
    #region Page Load
    /// <summary>
    /// from the esiexport screen we will pass session containg data table
    /// along with business unit,financial period, period element 
    /// those will be binded to grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Convert.ToString(Session["ESIInfo"]) != null)
                {
                    rg_ESIDownload.DataSource = Session["ESIInfo"] as DataTable;
                    rg_ESIDownload.DataBind();
                    for (int rows = 0; rows < rg_ESIDownload.Items.Count; rows++)
                    {
                        // adding businessunit,financial period and period element for more information
                        //Label lbl_businessunit = rg_ESIDownload.Items[rows].FindControl("lbl_Businessunit") as Label;
                        //Label lbl_financialperiod = rg_ESIDownload.Items[rows].FindControl("lbl_Financialperiod") as Label;
                        //Label lbl_periodelement = rg_ESIDownload.Items[rows].FindControl("lbl_Periodelement") as Label;
                        //lbl_businessunit.Text = Convert.ToString(Request.QueryString["Businessunit"]);
                        //lbl_financialperiod.Text = Convert.ToString(Request.QueryString["Period"]);
                        //lbl_periodelement.Text = Convert.ToString(Request.QueryString["Periodelement"]);
                        //Label lbl_total = rg_ESIDownload.Items[rows].FindControl("lbl_Total") as Label;
                        //Label lbl_reason = rg_ESIDownload.Items[rows].FindControl("lbl_reasoncode") as Label;
                        //if (lbl_total.Text == "0")
                        // {
                        //     lbl_reason.Text = "1";
                        // }
                        // else
                        // {
                        //     lbl_reason.Text = "0";
                        // }
                        //GridBoundColumn boundColumn = new GridBoundColumn();
                        //this.rg_ESIDownload.MasterTableView.Columns.Add(boundColumn);
                        //boundColumn.UniqueName = "Reason Code";
                        //boundColumn.DataField = "CustomerID";

                        //boundColumn.HeaderText = "CustomerID";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_downloadesi", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
#endregion
    #region Export Buttons
    /// <summary>
    /// this region will consists of exporting data from grid to excel or pdf
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_Exportopdf_Click(object sender, EventArgs e)
    {
        try
        {
            rg_ESIDownload.ExportSettings.Excel.Format = Telerik.Web.UI.GridExcelExportFormat.ExcelML;
            rg_ESIDownload.ExportSettings.ExportOnlyData = true;
            rg_ESIDownload.ExportSettings.IgnorePaging = true;
            rg_ESIDownload.MasterTableView.ExportToPdf();
            //Session.Remove("ESIInfo");
            //Session["ESIInfo"] = null;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_downloadesi", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Export_Click(object sender, EventArgs e)
    {
        try
        {
            rg_ESIDownload.ExportSettings.Excel.Format = Telerik.Web.UI.GridExcelExportFormat.ExcelML;
            rg_ESIDownload.ExportSettings.ExportOnlyData = true;
            rg_ESIDownload.ExportSettings.IgnorePaging = true;
            rg_ESIDownload.MasterTableView.ExportToExcel();
            //Session.Remove("ESIInfo");
            //Session["ESIInfo"] = null;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_downloadesi", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    #region Selection Changed
    /// <summary>
    ///  this region will take care of paging and filtering operations
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void rg_ESIDownload_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            if (Convert.ToString(Session["ESIInfo"]) != null)
            {
                rg_ESIDownload.DataSource = Session["ESIInfo"] as DataTable;
                foreach (GridBoundColumn item in rg_ESIDownload.Columns)
                {
                    if (item.UniqueName == "Businessunit")
                    {
                        //item.
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_downloadesi", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    #region Creating Style For Exported Data
    /// <summary>
    /// this region will format the headers i.e. columns and there data
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void rg_ESIDownload_ExcelMLExportStylesCreated1(object source, Telerik.Web.UI.GridExcelBuilder.GridExportExcelMLStyleCreatedArgs e)
    {
        try
        {
            foreach (Telerik.Web.UI.GridExcelBuilder.StyleElement style in e.Styles)
            {
                if (style.Id == "headerStyle")
                {
                style.FontStyle.Bold = true;
                style.FontStyle.Color = System.Drawing.Color.CadetBlue;
                style.InteriorStyle.Color = System.Drawing.Color.Wheat;
                style.InteriorStyle.Pattern = Telerik.Web.UI.GridExcelBuilder.InteriorPatternType.Solid;
                }
            }
            Telerik.Web.UI.GridExcelBuilder.StyleElement myStyle = new Telerik.Web.UI.GridExcelBuilder.StyleElement("MyCustomStyle");
            myStyle.FontStyle.Bold = true;
            myStyle.FontStyle.Italic = true;
            myStyle.InteriorStyle.Color = System.Drawing.Color.LightGray;
            myStyle.InteriorStyle.Pattern = Telerik.Web.UI.GridExcelBuilder.InteriorPatternType.Solid;
            e.Styles.Add(myStyle);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_downloadesi", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion
    
}
