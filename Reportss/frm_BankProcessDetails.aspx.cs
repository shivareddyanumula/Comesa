using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Web.Configuration;
using SMHR;
using System.Net;
using Microsoft.ReportingServices;

public partial class Reportss_frm_BankProcessDetails : System.Web.UI.Page
{
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                rv_BankDetails.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                string sDomain = Convert.ToString(WebConfigurationManager.ConnectionStrings["ReportServerUrl"]);
                System.Uri sUri = new Uri(sDomain);
                rv_BankDetails.ServerReport.ReportServerUrl = sUri;
                rv_BankDetails.ServerReport.ReportPath = "/SmartHR/" + "BankProcess";
                rv_BankDetails.ServerReport.Refresh();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BankProcessDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
