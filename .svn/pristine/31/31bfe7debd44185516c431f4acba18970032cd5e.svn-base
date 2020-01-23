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
using System.Net;

public partial class Reportss_LoanVoucherReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                RPT_LoanVoucher.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = RPT_LoanVoucher.ServerReport;

                Microsoft.Reporting.WebForms.ReportParameter RequestId;

                string sDomain = ConfigurationSettings.AppSettings["MyReportViewerDomain"];
                WebClient wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                string MyReportPath = System.Configuration.ConfigurationSettings.AppSettings["MyReportPath"];
                serverReport.ReportPath = MyReportPath + "Loan Voucher";
                if (Convert.ToString(Request.QueryString["LRID"]) != "")
                {
                    RequestId = new Microsoft.Reporting.WebForms.ReportParameter("RequestId", Convert.ToString(Request.QueryString["LRID"]));
                }
                else
                {
                    RequestId = new Microsoft.Reporting.WebForms.ReportParameter("RequestId", "-1");
                }
                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { RequestId };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_LoanVoucher.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanVoucherReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
}
