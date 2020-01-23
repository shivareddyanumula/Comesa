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

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lblyear.Text = Convert.ToString(DateTime.Now.Year);
            //lbl_Exit.Text = "You have successfully logged out.";// with username" + Convert.ToString(Session["USERNAME"]) + "<br>";
            Session.Remove("USERNAME");
            Session.Remove("USER_ID");
            Session.Remove("EMP_ID");
            Session.Remove("EMP_TYPE");
            Session.Remove("Control");
            FormsAuthentication.SignOut();
        }
    }

    protected void lnk_Logout_Click(object sender, EventArgs e)
    {
        
        Response.Redirect("~/Login.aspx");
        Response.Cookies["PBLOGIN"].Values["UNAME"] = null;
        Response.Cookies["PBLOGIN"].Values["UPASS"] = null;
       
    }
}