using System;
using System.Data;
using System.Configuration;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Reporting.WebForms;
using Microsoft.ReportingServices;
using PWDEncryprt;

/// <summary>
/// Summary description for Reports
/// </summary>
public class Reports
{
    public Reports()
    {

    }
    [Serializable]
    public sealed class ReportServerNetworkCredentials : IReportServerCredentials
    {
        #region IReportServerCredentials Members
        public bool GetFormsCredentials(out System.Net.Cookie authCookie, out string userName,
        out string password, out string authority)
        {
            authCookie = null;
            userName = null;
            password = null;
            authority = null;
            return false;
        }
        // Specifies the user to impersonate when connecting to a report server.
        //A WindowsIdentity object representing the user to impersonate.
        public WindowsIdentity ImpersonationUser
        {
            get
            {
                return null;
            }
        }
        // Returns network credentials to be used for authentication with the report server.
        //A NetworkCredentials object.
        public System.Net.ICredentials NetworkCredentials
        {
            get
            {
                //you can place below settings in configuration xml file
                string userName = System.Configuration.ConfigurationSettings.AppSettings["MyReportViewerUser"];
                string domainName = System.Configuration.ConfigurationSettings.AppSettings["MyReportViewerDomainName"];
                string password = System.Configuration.ConfigurationSettings.AppSettings["MyReportViewerPwd"];

                PWDEncryprt.PWDEncrypt obj = new PWDEncryprt.PWDEncrypt();
                //userName = obj.PasswordDecrypt(userName);
                //password = obj.PasswordDecrypt(password);
                return new System.Net.NetworkCredential(userName, password, domainName);
            }
        }
        #endregion
    }

}
