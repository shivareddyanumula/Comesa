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

public partial class Security_ForgotPassword : System.Web.UI.Page
{
    PWDEncryprt.PWDEncrypt PWD = new PWDEncryprt.PWDEncrypt();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                txt_PassCode.Text = string.Empty;
                txt_PassCode.Attributes.Add("value", "");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "ForgotPassword", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Type_Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["NAME"] != "")
            {
                //if (Request.QueryString["ORG"] != "" && Request.QueryString["ORG"] != "0")
                //{
                string strMail = string.Empty;
                SMHR_LOGININFO _obj_Login = new SMHR_LOGININFO();
                _obj_Login.OPERATION = operation.Check1;
                _obj_Login.LOGIN_USERNAME = Convert.ToString(Request.QueryString["NAME"]);
                _obj_Login.LOGIN_PASS_CODE = Convert.ToString(PWD.PasswordEncrypt(txt_PassCode.Text));
                //_obj_Login.ORGANISATION_ID = Convert.ToInt32(Request.QueryString["ORG"]);
                DataTable dt = BLL.get_Login_Validate(_obj_Login);
                if (dt.Rows.Count != 0)
                {
                    string emp_name = string.Empty;
                    if (dt.Rows[0]["EMP_NAME"] != System.DBNull.Value && Convert.ToString(dt.Rows[0]["EMP_NAME"]).Trim() != string.Empty)
                    {
                        emp_name = Convert.ToString(dt.Rows[0]["EMP_NAME"]);
                    }
                    else
                    {
                        emp_name = Convert.ToString(Request.QueryString["NAME"]);
                    }
                    strMail = Convert.ToString(dt.Rows[0]["LOGIN_EMAILID"]);
                    if (!(strMail == string.Empty))
                    {
                        ////MailMessage msgMail = new MailMessage();
                        ////string From = string.Empty;
                        ////string To = string.Empty;
                        ////string Body = string.Empty;
                        ////msgMail.From = new MailAddress("smtpmail@dhanushinfotech.com", "Smart HR");
                        //////msgMail.To.Add("dinesh.g@dhanushinfotech.com");
                        string toAddress, subject, body;
                        toAddress=Convert.ToString(dt.Rows[0]["LOGIN_EMAILID"]);
                        subject = "Smart HR Password";
                        body = "<html>" +
                                        "<body> " +
                                        "<p>Dear " + Convert.ToString(emp_name) + ", </p> " +
                                        "<p>Welcome to Smart HR Online !</p>" +
                                        "<p>Your credentials for accessing Smart HR for " + Convert.ToString(dt.Rows[0]["ORGANISATION_NAME"]) + " are <br>" +
                                        "</p> " +
                                        "<p>User name: " + Convert.ToString(Request.QueryString["NAME"]) + " </p> " +
                                        "<p>Password:  " + Convert.ToString(BLL.PasswordDecrypt(Convert.ToString(dt.Rows[0]["LOGIN_PASSWORD"]))) + " </p> " +
                                        "<p>Best Regards,<br/><br/>" +
                                        "Team Smart HR</p>" +
                                        "</body>" +
                                        " </html>";
                        //SmtpClient smtpC = new SmtpClient();
                        //smtpC.Host = Convert.ToString(ConfigurationManager.AppSettings["MAIL_HOST"]);
                        //smtpC.Credentials = new System.Net.NetworkCredential(Convert.ToString(ConfigurationManager.AppSettings["MAIL_ID"]), Convert.ToString(ConfigurationManager.AppSettings["MAIL_PWD"]));
                        ////smtpC.Credentials = new System.Net.NetworkCredential("anirudh.thapliyal@dhanushinfotech.net", "euro2012");
                        ////smtpC.EnableSsl = true;
                        //smtpC.Send(msgMail);
                        BLL.SendMail(toAddress,null,subject,body);
                        //txt_PassCode.Text = string.Empty;
                        BLL.ShowMessage(this, "A Mail has been sent to the user");
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Test", "<script type='text/javascript'>Close()</" + "script>", false);
                        txt_PassCode.Text = string.Empty;
                    }
                    //else
                    //{

                    //}
                }
                else
                {
                    BLL.ShowMessage(this, "Security Code is Invalid");
                    txt_PassCode.Text = string.Empty;
                    txt_PassCode.Attributes.Add("value", "");
                    return;
                }
                //}
                //else
                //{
                //    BLL.ShowMessage(this, "Please Select Organisation before you try to get your password");
                //    txt_PassCode.Text = string.Empty;
                //    txt_PassCode.Attributes.Add("value", "");
                //    return;
                //}
            }
            else
            {
                BLL.ShowMessage(this, "Please Enter User name before you try to get your password");
                txt_PassCode.Text = string.Empty;
                txt_PassCode.Attributes.Add("value", "");
                return;
            }
        }

        //catch (Exception ex)
        //{
        //    BLL.ShowMessage(this, "Exception Occured Please Contact Administrator");
        //    return;
        //}
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "ForgotPassword", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
