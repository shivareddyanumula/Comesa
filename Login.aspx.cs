using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SMHR;
using System.Net.Mail;
using System.Security.Principal;
using System.Threading;
using System.Web.Configuration;
using System.Management;
using System.Text;

public partial class Login : System.Web.UI.Page
{
    PWDEncryprt.PWDEncrypt PWD = new PWDEncryprt.PWDEncrypt();
    SMHR_LOGININFO _obj_smhr_logininfo;
    SMHR_EMPLOYEE _obj_Smhr_Employee;
    SMHR_APPLICANT _obj_smhr_applicant;
    bool blnVerified = false;
    bool s = false;
    string Control;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "function pageLoad(){   }", true);
            if (!Page.IsPostBack)
            {
                rtxtUserName.Focus();
                lblyear.Text = Convert.ToString(DateTime.Now.Year);
                if (Request.Browser.Cookies)
                {
                    //gjhj
                    if (Request.Cookies["PBLOGIN"] != null)
                    {
                        if (Request.Cookies["PBLOGIN"]["UNAME"] != null)
                        {
                            rtxtUserName.Text = Request.Cookies["PBLOGIN"]["UNAME"].ToString();
                            chk_Remember.Checked = true;
                            //DataTable dt = new DataTable();
                            //dt = BLL.get_Users(rtxtUserName.Text);
                            //if (dt.Rows.Count > 0)
                            //{
                            //rcmb_org.Items.Clear();
                            //rcmb_org.DataSource = dt;
                            //rcmb_org.DataTextField = "ORGANISATION_NAME";
                            //rcmb_org.DataValueField = "ORGANISATION_ID";
                            //rcmb_org.DataBind();
                            //rcmb_org.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                            //if (Request.Cookies["PBLOGIN"]["UORG"] != null)
                            //{
                            //    rcmb_org.SelectedIndex = rcmb_org.FindItemIndexByValue(Request.Cookies["PBLOGIN"]["UORG"].ToString());
                            //}

                            if (Request.Cookies["PBLOGIN"]["UPASS"] != null)
                            {
                                string strPass = Request.Cookies["PBLOGIN"]["UPASS"].ToString();

                                rtxtPassword.Attributes.Add("value", strPass);
                            }
                            //}
                        }
                        //if (Request.Cookies["PBLOGIN"]["UPASS"] != null)
                        //{
                        //    string strPass = Request.Cookies["PBLOGIN"]["UPASS"].ToString();

                        //    rtxtPassword.Attributes.Add("value", strPass);
                        //}
                        //btnLogin.Focus();
                    }
                    else
                    {
                        rtxtPassword.Text = "";
                        rtxtUserName.Text = "";
                        chk_Remember.Checked = false;
                        //rcmb_org.ClearSelection();
                        //rcmb_org.Items.Clear();
                        //rcmb_org.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("", "0"));
                    }
                    Control = Convert.ToString(Request.QueryString["Control"]);
                    if (Control != null)
                    {
                        _obj_smhr_logininfo = new SMHR_LOGININFO();
                        _obj_smhr_logininfo.OPERATION = operation.Select4;
                        _obj_smhr_logininfo.LOGIN_EMP_ID = Convert.ToInt32(Control);
                        DataTable dt_login = BLL.get_LoginInfo(_obj_smhr_logininfo);
                        if (dt_login.Rows.Count > 0)
                        {
                            //rcmb_org.Items.Clear();
                            //rcmb_org.DataSource = dt_login;
                            //rcmb_org.DataTextField = "ORGANISATION_NAME";
                            //rcmb_org.DataValueField = "ORGANISATION_ID";
                            //rcmb_org.DataBind();
                            //rcmb_org.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

                            rtxtUserName.Text = Convert.ToString(dt_login.Rows[0]["LOGIN_USERNAME"]);
                            rtxtPassword.Attributes.Add("value", BLL.PasswordDecrypt(Convert.ToString(dt_login.Rows[0]["LOGIN_PASSWORD"])));
                            //rcmb_org.SelectedIndex = rcmb_org.Items.FindItemIndexByValue(Convert.ToString(dt_login.Rows[0]["LOGIN_ORGANISATION_ID"]));
                        }
                        else
                        {
                            rtxtPassword.Text = "";
                            rtxtUserName.Text = "";
                            chk_Remember.Checked = false;
                            //rcmb_org.ClearSelection();
                            //rcmb_org.Items.Clear();
                            //rcmb_org.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("", "0"));
                        }
                    }
                    //EncryptConnString();
                    //DecryptConnString();
                }
            }
            this.Page.Title = ":: Smart HR ::";
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Login", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    // ----------------------------------------------------------------------------------------
    // Author:                        gunti.dheeraj
    // Company:                       Dhanush InfoTech Pvt Ltd
    // Date:                          7/22/2010
    // Time:                          18:29
    // Project Item Name:             Login.aspx
    // Project Item Filename:         Login.aspx.cs
    // Project Item Kind:             ASPX Code Behind
    // Class FullName:                Login
    // Class Name:                    Login
    // Class Kind Description:        Class
    // Class Kind Keyword:            class
    // Procedure FullName:            Login.GetCredentials
    // Procedure Name:                GetCredentials
    // Procedure Kind Description:    Function
    // Function Return Type Name:     Boolean
    // Function Return Type FullName: System.Boolean
    // Function Return Type Alias:    bool
    // Parameters:
    // ----------------------------------------------------------------------------------------
    private bool GetCredentials()
    {
        SMHR_MAIN _obj_smhr_main = new SMHR_MAIN();
        DataTable dt_mode = new DataTable();
        dt_mode = BLL.get_TBL_LSINFO(1);
        string col3 = Convert.ToString(dt_mode.Rows[0]["COL3"]);

        //if (col3 == (BLL.PasswordEncrypt("E")))
        //{
        //    return true;
        //}
        return true; ;
    }
    private void EncryptConnString()
    {
        // string a = "~/SMHRBASE/";  
        Configuration config =
        WebConfigurationManager.
        OpenWebConfiguration("~");
        ConfigurationSection section =
        config.GetSection("connectionStrings");
        if (section != null &&
        !section.SectionInformation.IsProtected)
        {
            section.SectionInformation.ProtectSection("RsaProtectedConfigurationProvider");
            config.Save();
        }
    }
    private void DecryptConnString()
    {
        Configuration config =
        WebConfigurationManager.
        OpenWebConfiguration("~");
        ConfigurationSection section =
        config.GetSection("connectionStrings");
        if (section != null &&
        section.SectionInformation.IsProtected)
        {
            section.SectionInformation.UnprotectSection();
            config.Save();
        }
    }
    public bool GetMACAddress()
    {
        // newly added by sravani to get MAC address 23.02.2011
        ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
        ManagementObjectCollection moc = mc.GetInstances();
        string MACAddress = String.Empty;
        _obj_smhr_logininfo = new SMHR_LOGININFO();
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
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            if (rtxtUserName.Text.Trim() == string.Empty || rtxtPassword.Text.Trim() == string.Empty)
            {
                if (rtxtUserName.Text.Trim() == string.Empty && rtxtPassword.Text.Trim() == string.Empty)
                {
                    BLL.ShowMessage(this, " - User Name & Password cannot be empty");
                    rtxtUserName.Focus();
                }
                else if (rtxtUserName.Text.Trim() == string.Empty)
                {
                    BLL.ShowMessage(this, " - User Name cannot be empty");
                    rtxtUserName.Focus();
                }
                else 
                {
                    BLL.ShowMessage(this, " - Password cannot be empty");
                    rtxtPassword.Focus();
                }
                return;
            }

            // string str3;
            //str3= BLL.PasswordEncrypt("krishna.k");
            //string str4;
            //str4= BLL.PasswordEncrypt("123456kK");
            //bool rs1 = GetCredentials();
            //if (rs1 == true)
            //{
            //    Response.Redirect("~/Masters/frm_error.aspx", false);
            //}
            //else
            //{
            Session.Remove("USERNAME");
            Session.Remove("USER_ID");
            Session.Remove("EMP_ID");
            Session.Remove("EMP_TYPE");
            Session.Remove("Control");
            Session.Remove("SELFSERVICE");
            Session.Remove("BUSINESSUNIT_ID");
            Session.Remove("DASHBOARD");
            Session.Remove("window");
            Session.Remove("ORG_NAME");
            Session.Remove("EMPNAME");
            Session.Remove("USER_GROUP");
           

            //newly added by sravani 23.02.2011
            //#if  (DEBUG)
            blnVerified = true;

            //#else
            //blnVerified = GetMACAddress();


            //#endif
            if (blnVerified == true)
            {
                DataTable dt = new DataTable();
                dt = BLL.get_Users(rtxtUserName.Text);
                //dt = BLL.get_pwd(rtxtUserName.Text, Convert.ToInt32(rcmb_org.SelectedItem.Value));
                if (dt.Rows.Count != 0)
                {
                    if (rtxtUserName.Text.ToUpper() == Convert.ToString(dt.Rows[0]["LOGIN_USERNAME"]).ToUpper().Trim() && rtxtPassword.Text == BLL.PasswordDecrypt(Convert.ToString(dt.Rows[0]["LOGIN_PASSWORD"])) && Convert.ToString(dt.Rows[0]["LOGIN_STATUS"]).ToUpper() == "TRUE")
                    {
                        Session["USERNAME"] = rtxtUserName.Text.ToUpper();
                        Session["USER_ID"] = Convert.ToString(dt.Rows[0]["LOGIN_ID"]);
                        Session["EMP_ID"] = Convert.ToString(dt.Rows[0]["LOGIN_EMP_ID"]);
                        Session["EMP_TYPE"] = Convert.ToString(dt.Rows[0]["LOGIN_TYPE"]);
                        Session["ORG_ID"] = Convert.ToString(dt.Rows[0]["LOGIN_ORGANISATION_ID"]);
                        Session["BUSINESSUNIT_ID"] = Convert.ToString(dt.Rows[0]["LOGIN_BUSINESSUNITID"]);
                        Session["ORG_NAME"] = Convert.ToString(dt.Rows[0]["ORGANISATION_NAME"]);
                        Session["USER_GROUP"] = Convert.ToString(dt.Rows[0]["LOGTYP_UNIQUEID"]);
                        Session["LOGTYP_CODE"] = Convert.ToString(dt.Rows[0]["LOGTYP_CODE"]); 
                        //Session["EMPNAME"] = dt.Rows[0]["NAME"] != null ? Convert.ToString(dt.Rows[0]["NAME"]).Trim() : "";

                        USER_LOG();
                        if (BLL.PasswordDecrypt(Convert.ToString(dt.Rows[0]["LOGIN_PASSWORD"])) == "123456aA")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "function pageLoad(){  lnk_pass_Click(); }", true);
                            return;
                        }
                        if (chk_Remember.Checked)
                        {
                            if (Request.Browser.Cookies)
                            {
                                if (Request.Cookies["PBLOGIN"] == null)
                                {
                                    Response.Cookies["PBLOGIN"].Values["UNAME"] = rtxtUserName.Text;
                                    //Response.Cookies["PBLOGIN"].Values["UORG"] = rcmb_org.SelectedItem.Value;
                                    Response.Cookies["PBLOGIN"].Values["UPASS"] = rtxtPassword.Text.ToString().Trim();
                                }
                                else
                                {
                                    Response.Cookies["PBLOGIN"].Values["UNAME"] = rtxtUserName.Text;
                                    //Response.Cookies["PBLOGIN"].Values["UORG"] = rcmb_org.SelectedItem.Value;
                                    Response.Cookies["PBLOGIN"].Values["UPASS"] = rtxtPassword.Text.ToString().Trim();
                                }
                            }
                        }
                        //FormsAuthentication.RedirectFromLoginPage(rtxtUserName.Text.ToUpper(), false);
                        DataTable dt1 = BLL.get_1259735();
                        if (dt1.Rows.Count != 0)
                        {
                            switch (Convert.ToString(dt1.Rows[0][0]))
                            {
                                case "6rAoGC7EbQxz7FSee5gSCKsSCWJkUsWCvt4EVz99O0s=":
                                    //Enterprise : 1543768902
                                    Response.Redirect("Loading.aspx", false);
                                    break;
                                case "z061eEXQ5RKrb9W21ltqmiD1EhZ16HzTcS1OK9Mx4rg=":
                                    //LimitedUser : 1457386092
                                    Response.Redirect("Loading.aspx", false);
                                    break;
                                case "R6pOj1wf7Gz42/BLR+nWbxodHDQ6SWsDL2NbzyQPlTw=":
                                    //Hosted Model : 290683754
                                    string str = BLL.PasswordDecrypt(Convert.ToString(dt1.Rows[0][2]));
                                    //DateTime dtTime = new DateTime(); 
                                    //DateTime dtTime = DateTime.ParseExact(str, "dd/MM/yyyy", null);
                                    if (str != null)
                                    {
                                        DateTime dtTime = DateTime.ParseExact(str, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                                        //DateTime dtTime = Convert.ToDateTime(str);
                                        //DateTime dtTime=DateTime.Parse(str, System.Globalization.CultureInfo.CreateSpecificCulture("en-GB"));
                                        //DateTime dtTime = DateTime.ParseExact(str, "dd/MM/yyyy", null);
                                        DateTime Today = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                                        TimeSpan dt_1 = dtTime - Today;
                                        double Days = (dt_1.TotalDays) / 365.25;
                                        if (Days < 0)
                                        {
                                            Response.Redirect("Default.aspx", false);
                                            return;
                                        }
                                        else
                                        {


                                            bool status = false;
                                            status = checkRole();
                                            Session["checkRole"] = status;
                                            if (Convert.ToInt32(Session["EMP_ID"]) > 0)
                                            {
                                                //TO GET D DATEFORMAT FOR D BUSINESSUNIT, 21.03.2012
                                                _obj_smhr_logininfo = new SMHR_LOGININFO();
                                                _obj_smhr_logininfo.OPERATION = operation.Empty1;
                                                _obj_smhr_logininfo.LOGIN_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                                                DataTable dt_date = BLL.get_DateFormat(_obj_smhr_logininfo);
                                                if (dt_date.Rows.Count > 0)
                                                {
                                                    if (Convert.ToString(dt_date.Rows[0]["DATEFORMAT_FORMAT"]).ToUpper() == "DD/MM/YYYY")
                                                        Session["DATE_FORMAT"] = Convert.ToString(dt_date.Rows[0]["DATEFORMAT_FORMAT"]);
                                                    else if (Convert.ToString(dt_date.Rows[0]["DATEFORMAT_FORMAT"]).ToUpper() == "MM/DD/YYYY")
                                                        Session["DATE_FORMAT"] = Convert.ToString(dt_date.Rows[0]["DATEFORMAT_FORMAT"]);
                                                    else
                                                        Session["DATE_FORMAT"] = Convert.ToString(dt_date.Rows[0]["DATEFORMAT_FORMAT"]);
                                                }
                                                _obj_Smhr_Employee = new SMHR_EMPLOYEE();
                                                _obj_Smhr_Employee.OPERATION = operation.Select;
                                                _obj_Smhr_Employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                                _obj_Smhr_Employee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                                                DataTable dtEmp = BLL.get_Employee(_obj_Smhr_Employee);
                                                if (dtEmp.Rows.Count > 0)
                                                {
                                                    _obj_smhr_applicant = new SMHR_APPLICANT();
                                                    _obj_smhr_applicant.APPSKL_APPLICANT_ID = Convert.ToInt32(dtEmp.Rows[0]["EMP_APPLICANT_ID"]);
                                                    _obj_smhr_applicant.OPERATION = operation.Check;
                                                    DataTable dtAppSkill = BLL.get_ApplicantSkills(_obj_smhr_applicant);
                                                    //if (dtAppSkill.Rows.Count > 0)
                                                    //{
                                                    FormsAuthentication.RedirectFromLoginPage(rtxtUserName.Text.ToUpper(), false);
                                                    if (status == true)
                                                    {
                                                        Session["SELFSERVICE"] = "true";
                                                        lblSession.Value = Convert.ToString(Session["SELFSERVICE"]);
                                                        Response.Redirect("~/Security/frm_Dashboard.aspx", false);
                                                        Session["PendingKra"] = 1;
                                                        //To show HR & Payroll by default by sravani
                                                        Session["SUPERMODULE_ID"] = 1;
                                                        //To select super modules
                                                        //Response.Redirect("frm_Menus.aspx", false);
                                                    }
                                                    else
                                                    {
                                                        Session["SELFSERVICE"] = "";
                                                        lblSession.Value = Convert.ToString(Session["SELFSERVICE"]);
                                                        Response.Redirect("~/Security/frm_Dashboradmngr.aspx", false);
                                                        Session["PendingKra"] = 1;
                                                        //To show HR & Payroll by default by sravani
                                                        Session["SUPERMODULE_ID"] = 1;
                                                        //Response.Redirect("frm_Menus.aspx", false);
                                                    }
                                                    //}
                                                    //else
                                                    //{
                                                    //    if (Convert.ToInt32(Session["EMP_ID"]) > 0)
                                                    //    {
                                                    //        Session["SUPERMODULE_ID"] = 1;
                                                    //        if (status == true)
                                                    //        {
                                                    //            Session["SELFSERVICE"] = "true";
                                                    //            lblSession.Value = Convert.ToString(Session["SELFSERVICE"]);
                                                    //            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "function pageLoad(){  ShowPop(); }", true);
                                                    //            return;
                                                    //        }
                                                    //        else
                                                    //        {
                                                    //            Session["SELFSERVICE"] = "";
                                                    //            lblSession.Value = Convert.ToString(Session["SELFSERVICE"]);
                                                    //            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "function pageLoad(){  ShowPop(); }", true);
                                                    //            return;
                                                    //        }
                                                    //    }
                                                    //}
                                                }
                                                //FormsAuthentication.RedirectFromLoginPage(rtxtUserName.Text.ToUpper(), false);
                                                //if (status == true)
                                                //{
                                                //    Session["SELFSERVICE"] = "true";
                                                //    Response.Redirect("~/Security/frm_Dashboard.aspx", false);
                                                //    //To show HR & Payroll by default by sravani
                                                //    Session["SUPERMODULE_ID"] = 1;
                                                //    //To select super modules
                                                //    //Response.Redirect("frm_Menus.aspx", false);
                                                //}
                                                //else
                                                //{
                                                //    Session["SELFSERVICE"] = "";
                                                //    Response.Redirect("~/Security/frm_Dashboradmngr.aspx", false);
                                                //    //To show HR & Payroll by default by sravani
                                                //    Session["SUPERMODULE_ID"] = 1;
                                                //    //Response.Redirect("frm_Menus.aspx", false);
                                                //}

                                            }
                                            else
                                            {
                                                //TO GET D DATEFORMAT FOR THE ORGANISATION, 21.03.2012
                                                _obj_smhr_logininfo = new SMHR_LOGININFO();
                                                _obj_smhr_logininfo.OPERATION = operation.Empty2;
                                                _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                                DataTable dt_date = BLL.get_DateFormat(_obj_smhr_logininfo);
                                                if (dt_date.Rows.Count > 0)
                                                {
                                                    if (Convert.ToString(dt_date.Rows[0]["DATEFORMAT_FORMAT"]).ToUpper() == "DD/MM/YYYY")
                                                        Session["DATE_FORMAT"] = Convert.ToString(dt_date.Rows[0]["DATEFORMAT_FORMAT"]);
                                                    else if (Convert.ToString(dt_date.Rows[0]["DATEFORMAT_FORMAT"]).ToUpper() == "MM/DD/YYYY")
                                                        Session["DATE_FORMAT"] = Convert.ToString(dt_date.Rows[0]["DATEFORMAT_FORMAT"]);
                                                    else
                                                        Session["DATE_FORMAT"] = Convert.ToString(dt_date.Rows[0]["DATEFORMAT_FORMAT"]);
                                                }

                                                FormsAuthentication.RedirectFromLoginPage(rtxtUserName.Text.ToUpper(), false);
                                                Session["SELFSERVICE"] = "ADMIN";
                                                Response.Redirect("~/Masters/Default.aspx", false);
                                                //To show HR & Payroll by default by sravani
                                                Session["SUPERMODULE_ID"] = 1;

                                            }
                                        }
                                    }

                                    break;
                                default:
                                    return;
                            }
                        }
                        else
                        {
                            FormsAuthentication.RedirectFromLoginPage(rtxtUserName.Text.ToUpper(), false);
                            Response.Redirect("~/Masters/Default.aspx", false);
                            //To show HR & Payroll by default by sravani
                            Session["SUPERMODULE_ID"] = 1;
                            //Response.Redirect("frm_Menus.aspx", false);
                            return;
                        }
                    }
                    else
                    {
                        failure.Visible = true;
                        BLL.ShowMessage(this, "Login Failed. Incorrect User Name/Password");
                        //rtxtUserName_TextChanged(null, null);
                        //lbl_failure.Visible = true;
                        return;
                    }

                }
                else
                {
                    failure.Visible = true;
                    BLL.ShowMessage(this, "Login Failed. Incorrect User Name.");
                    //lbl_failure.Visible = true;
                    return;
                }
            }
            else
            {
                BLL.ShowMessage(this, "Please contact Dhanush Infotech");
                return;
            }

            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Login", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void USER_LOG()
    {
        string ipaddress;
        string strHostName = System.Net.Dns.GetHostName();
        ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        ipaddress = Convert.ToString(Request.ServerVariables["REMOTE_ADDR"]);
        SMHR_USERLOG SMHR_USER_LOG = new SMHR_USERLOG();
        SMHR_USER_LOG.USERLOG_USER_ID = Convert.ToInt32(Session["USER_ID"]);
        SMHR_USER_LOG.USERLOG_IP = Convert.ToString(ipaddress);
        SMHR_USER_LOG.USERLOG_LOGSTART = DateTime.Now;
        SMHR_USER_LOG.USERLOG_CREATEDBY = Convert.ToInt32(Session["Userid"]);
        SMHR_USER_LOG.USERLOG_CREATEDDATE = DateTime.Now;
        Boolean saveUserLog = BLL.GET_USER_LOG_INSERT(SMHR_USER_LOG); //userLogEngine.SaveUserLog(SMHRUserLog);
        DataTable userLog = BLL.GET_LATEST_USER_LOG_ID(SMHR_USER_LOG);
        Session["UserlogID"] = Convert.ToInt32(userLog.Rows[0]["MAX_ID"]);
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            rtxtUserName.Text = string.Empty;
            string strPass = "";
            rtxtPassword.Attributes.Add("value", strPass);
            Response.Cookies["PBLOGIN"].Values["UNAME"] = null;
            Response.Cookies["PBLOGIN"].Values["UPASS"] = null;
            chk_Remember.Checked = false;
            failure.Visible = false;
            lbl_failure.Visible = false;
            //rcmb_org.ClearSelection();
            //rcmb_org.Items.Clear();
            //rcmb_org.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Login", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //private bool checkRole()
    //{

    //    bool status = false;
    //    SMHR_LOGININFO _obj_smhr_loginInfo = new SMHR_LOGININFO();
    //    _obj_smhr_loginInfo.LOGIN_USERNAME = Convert.ToString(rtxtUserName.Text);
    //    _obj_smhr_loginInfo.OPERATION = operation.Select;
    //    DataTable dt = BLL.get_Login(_obj_smhr_loginInfo);
    //    if (dt.Rows.Count != 0)
    //    {
    //        if (Convert.ToString(dt.Rows[0]["LOGTYP_CODE"]) == "USERS")
    //        {
    //            status = true;
    //        }
    //        else
    //        {
    //            status = false;
    //        }
    //    }
    //    return status;
    //}

    private bool checkRole()
    {

        bool status = false;
        bool flag = false;
        SMHR_EMPLOYEE _obj_smhr_employee = new SMHR_EMPLOYEE();
        _obj_smhr_employee.OPERATION = operation.Select;
        _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
        DataTable dt = BLL.get_EMP(_obj_smhr_employee);
        if (dt.Rows.Count != 0)
        {
            for (int int_count = 0; int_count < dt.Rows.Count; int_count++)
            {
                if (Convert.ToString(Session["EMP_ID"]) == Convert.ToString(dt.Rows[int_count]["EMP_REPORTINGEMPLOYEE"]))
                {
                    flag = true;
                    status = false;
                }

            }
            if (flag == false)
                status = true;


        }
        return status;
    }

    protected void lnk_Forgot_Click(object sender, EventArgs e)
    {
        try
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "function pageLoad(){  ShowPopForm('" + Convert.ToString(rtxtUserName.Text) + "', '" + Convert.ToString(rcmb_org.SelectedValue) + "'); }", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "function pageLoad(){  ShowPopForm('" + Convert.ToString(rtxtUserName.Text) + "'); }", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Login", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void chk_Windows_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            AppDomain.CurrentDomain.SetPrincipalPolicy(System.Security.Principal.PrincipalPolicy.WindowsPrincipal);
            WindowsPrincipal WPrincipal = (WindowsPrincipal)Thread.CurrentPrincipal;
            WindowsIdentity WIdentity = (WindowsIdentity)WPrincipal.Identity;
            if (WPrincipal.Identity.IsAuthenticated)
            {
                bool rs1 = GetCredentials();
                if (rs1 == true)
                {
                    Response.Redirect("~/Masters/frm_error.aspx", false);
                }
                else
                {
                    Session.Remove("USERNAME");
                    Session.Remove("USER_ID");
                    Session.Remove("EMP_ID");
                    Session.Remove("EMP_TYPE");
                    Session.Remove("Control");
                    Session.Remove("SELFSERVICE");
                    Session.Remove("ORG_NAME");

                    DataTable dt = new DataTable();
                    string str_name = WPrincipal.Identity.Name;
                    string[] Ar = str_name.Split(new Char[] { '\\' });
                    dt = BLL.get_Users(Ar[1]);
                    if (dt.Rows.Count != 0)
                    {
                        Session["USERNAME"] = str_name.ToString();
                        Session["USER_ID"] = Convert.ToString(dt.Rows[0]["LOGIN_ID"]);
                        Session["EMP_ID"] = Convert.ToString(dt.Rows[0]["LOGIN_EMP_ID"]);
                        Session["EMP_TYPE"] = Convert.ToString(dt.Rows[0]["LOGIN_TYPE"]);
                        Session["ORG_ID"] = Convert.ToString(dt.Rows[0]["LOGIN_ORGANISATION_ID"]);
                        Session["ORG_NAME"] = Convert.ToString(dt.Rows[0]["ORG_NAME"]);
                        if (chk_Remember.Checked)
                        {
                            if (Request.Browser.Cookies)
                            {
                                if (Request.Cookies["PBLOGIN"] == null)
                                {
                                    Response.Cookies["PBLOGIN"].Values["UNAME"] = rtxtUserName.Text;
                                    Response.Cookies["PBLOGIN"].Values["UPASS"] = rtxtPassword.Text.ToString().Trim();
                                }
                                else
                                {
                                    Response.Cookies["PBLOGIN"].Values["UNAME"] = rtxtUserName.Text;
                                    Response.Cookies["PBLOGIN"].Values["UPASS"] = rtxtPassword.Text.ToString().Trim();
                                }
                            }
                        }
                        FormsAuthentication.RedirectFromLoginPage(rtxtUserName.Text.ToUpper(), false);

                        DataTable dt1 = BLL.get_1259735();
                        if (dt1.Rows.Count != 0)
                        {
                            switch (Convert.ToString(dt1.Rows[0][0]))
                            {
                                case "6rAoGC7EbQxz7FSee5gSCKsSCWJkUsWCvt4EVz99O0s=":
                                    //Enterprise : 1543768902
                                    Response.Redirect("~/Masters/Default.aspx", false);
                                    break;
                                case "z061eEXQ5RKrb9W21ltqmiD1EhZ16HzTcS1OK9Mx4rg=":
                                    //LimitedUser : 1457386092
                                    Response.Redirect("~/Masters/Default.aspx", false);
                                    break;
                                case "R6pOj1wf7Gz42/BLR+nWbxodHDQ6SWsDL2NbzyQPlTw=":
                                    //Hosted Model : 290683754
                                    string str = BLL.PasswordDecrypt(Convert.ToString(dt1.Rows[0][2]));
                                    // DateTime dtTime = new DateTime(); 
                                    //DateTime dtTime = DateTime.ParseExact(str, "dd/MM/yyyy", null);
                                    DateTime dtTime = Convert.ToDateTime(str);
                                    DateTime Today = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                                    TimeSpan dt_1 = dtTime - Today;
                                    double Days = (dt_1.TotalDays) / 365.25;
                                    if (Days < 0)
                                    {
                                        Response.Redirect("Default.aspx", false);
                                        return;
                                    }
                                    else
                                    {
                                        bool status = false;
                                        status = checkRole();
                                        if (status == true)
                                        {
                                            Session["SELFSERVICE"] = "true";
                                            Response.Redirect("Main_Page.aspx", false);
                                        }
                                        else
                                        {
                                            Session["SELFSERVICE"] = "";
                                            Response.Redirect("~/Masters/Default.aspx", false);
                                        }
                                    }
                                    break;
                                default:
                                    return;
                            }
                        }
                        else
                        {
                            Response.Redirect("~/Masters/Default.aspx", false);
                            return;
                        }
                    }
                    else
                    {
                        failure.Visible = true;
                        BLL.ShowMessage(this, "Login Failed. Incorrect User Name/Password");
                        //lbl_failure.Visible = true;
                        return;
                    }
                }
            }
            else
            {
                chk_Windows.Checked = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Login", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    //protected void rcmb_org_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    //{
    //if (Convert.ToInt32(rcmb_org.SelectedItem.Value) > 0)
    //{
    //    if (Request.Cookies["PBLOGIN"] != null)
    //    {
    //        if (Request.Cookies["PBLOGIN"]["UPASS"] != null)
    //        {
    //            if (chk_Remember.Checked)
    //            {
    //                //string strPass = Request.Cookies["PBLOGIN"]["UPASS"].ToString();
    //                DataTable dt = BLL.get_pwd(rtxtUserName.Text, Convert.ToInt32(rcmb_org.SelectedItem.Value));
    //                string strPass = BLL.PasswordDecrypt(Convert.ToString(dt.Rows[0]["LOGIN_PASSWORD"]));
    //                rtxtPassword.Attributes.Add("value", strPass);
    //            }
    //            else
    //            {
    //                string strPass = "";
    //                rtxtPassword.Attributes.Add("value", strPass);
    //            }
    //        }                         
    //    }
    //    else
    //    {
    //        string strPass = "";
    //        rtxtPassword.Attributes.Add("value", strPass);
    //    }
    //}
    //else
    //{
    //    string strPass = "";
    //    rtxtPassword.Attributes.Add("value", strPass);
    //}
    //}

    //protected void rtxtUserName_TextChanged(object sender, EventArgs e)
    //{
    //    if (rtxtUserName.Text != string.Empty)
    //    {

    //DataTable dt = new DataTable();
    //dt = BLL.get_Users(BLL.ReplaceQuote(rtxtUserName.Text.Trim()));
    //rcmb_org.ClearSelection();
    //rcmb_org.Items.Clear();
    //rcmb_org.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("", "0"));
    //string strPass = "";
    //rtxtPassword.Attributes.Add("value", strPass);
    //if (dt.Rows.Count > 0)
    //{
    //    rcmb_org.Items.Clear();
    //    rcmb_org.DataSource = dt;
    //    rcmb_org.DataTextField = "ORGANISATION_NAME";
    //    rcmb_org.DataValueField = "ORGANISATION_ID";
    //    rcmb_org.DataBind();
    //    if (dt.Rows.Count > 1)
    //    {
    //        rcmb_org.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
    //        rcmb_org.Focus();
    //    }
    //    else
    //    {
    //        rtxtPassword.Focus();
    //    }
    //if (Request.Cookies["PBLOGIN"] != null)
    //{
    //    //if (Request.Cookies["PBLOGIN"]["UORG"] != null)
    //    //{
    //    //    rcmb_org.SelectedIndex = rcmb_org.FindItemIndexByValue(Request.Cookies["PBLOGIN"]["UORG"].ToString());
    //    //}

    //    if (Request.Cookies["PBLOGIN"]["UPASS"] != null)
    //    {
    //        string strPass = Request.Cookies["PBLOGIN"]["UPASS"].ToString();
    //        rtxtPassword.Attributes.Add("value", strPass);
    //    }
    //}
    //rcmb_org.Focus();
    //}
    //else
    //{
    //    rcmb_org.ClearSelection();
    //    rcmb_org.Items.Clear();
    //    rcmb_org.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("", "0"));
    //    rtxtUserName.Focus();
    //    BLL.ShowMessage(this, "You have entered Incorrect User Name.");
    //}
    //    }
    //}
}