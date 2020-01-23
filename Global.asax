﻿<%@ Application Language="C#" %>
<%@ Import Namespace="System.Reflection" %>
<%@ Import Namespace="System.Management" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="SMHR" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Import Namespace="System.Globalization" %>

<script RunAt="server">
    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        //Response.Redirect("~/Default.aspx", false);
        PropertyInfo p = typeof(System
.Web.HttpRuntime).GetProperty("FileChangesMonitor", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
        object o = p.GetValue(null, null);
        FieldInfo f = o.GetType().GetField("_dirMonSubdirs", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.IgnoreCase);
        object monitor = f.GetValue(o);
        MethodInfo m = monitor.GetType().GetMethod("StopMonitoring", BindingFlags.Instance | BindingFlags.NonPublic);
        m.Invoke(monitor
        , new object[] { });

    }
    void Application_End(object sender, EventArgs e)
    {
        SMHR_USERLOG _obj_SMHR_USER_LOG = new SMHR_USERLOG();

        _obj_SMHR_USER_LOG.USERLOG_ID = Convert.ToInt32(Session["UserlogID"]);
        _obj_SMHR_USER_LOG.USERLOG_LOGEND = DateTime.Now;

        if (BLL.GET_USER_LOG_UPDATE(_obj_SMHR_USER_LOG))
        {
            Session.Clear();
            Session.RemoveAll();
            //  Code that runs on application shutdown
            Session.Abandon();
        }
    }
    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

        if (Context.Handler is IRequiresSessionState || Context.Handler is IReadOnlySessionState)
        {
            Exception ex = Server.GetLastError().GetBaseException();
            //SMHR.BLL.Error_Log(Session["Userid"].ToString(), ex.TargetSite.ToString(), ex.Message, ex.StackTrace, DateTime.Now.ToString());
        }
        else
        {
            Response.Redirect("~/Frm_Error.aspx");
        }


    }
    public bool blnVerified = false;
    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started
        Session.Timeout = 15;
        bool blnVerified = false;
        //newly added 10.3.2011
        //#if  (DEBUG)
        blnVerified = true;

        //#else
        //blnVerified = GetMACAddress();


        //#endif
        if (blnVerified == false)
        {
            //BLL.ShowMessage(,"Please contact Dhanush Infotech");
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
            //ScriptManager.RegisterStartupScript(
            //  ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert(' Please contact Dhanush Infotech ');", true);
        }
    }
    void Session_End(object sender, EventArgs e)
    {
        SMHR_USERLOG _obj_SMHR_USER_LOG = new SMHR_USERLOG();

        _obj_SMHR_USER_LOG.USERLOG_ID = Convert.ToInt32(Session["UserlogID"]);
        _obj_SMHR_USER_LOG.USERLOG_LOGEND = DateTime.Now;

        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

        if (BLL.GET_USER_LOG_UPDATE(_obj_SMHR_USER_LOG))
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
        }
    }
    public bool GetMACAddress()
    {
        // newly added by sravani to get MAC address 23.02.2011
        ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
        ManagementObjectCollection moc = mc.GetInstances();
        string MACAddress = String.Empty;
        SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
        DataTable dt = BLL.get_mac(_obj_smhr_logininfo);
        if ((dt.Rows[0]["GLOBAL_URL_MACADDRESS"]) != System.DBNull.Value)
        {
            foreach (ManagementObject mo in moc)
            {

                if ((bool)mo["IPEnabled"] == true)
                {

                    MACAddress = mo["MacAddress"].ToString();
                    MACAddress = MACAddress.Replace(":", "-");
                    // Please  verify for MAc address and if encrypted MAc address is stored in db matches that of the server then proceed furthur . otherwise show message please contact dhanush infotech
                    //if they match set blnVerified = true and break 

                    if (Convert.ToString(BLL.PasswordDecrypt(Convert.ToString(dt.Rows[0]["GLOBAL_URL_MACADDRESS"]))) == MACAddress)
                    {
                        blnVerified = true;
                        break;
                    }

                }
                mo.Dispose();
            }

            //MACAddress = MACAddress.Replace(":", "");
            //return true/false

        }
        else
        {
            blnVerified = false;

        }
        return blnVerified;
    }

    protected void Application_BeginRequest()
    {
        CultureInfo info = new CultureInfo(System.Threading.Thread.CurrentThread.CurrentCulture.ToString());
        info.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy";
        System.Threading.Thread.CurrentThread.CurrentCulture = info;
    }


</script>