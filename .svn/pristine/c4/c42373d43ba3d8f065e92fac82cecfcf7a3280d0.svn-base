using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frm_UnAuthorized : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Session.Remove("USERNAME");
            Session.Remove("USER_ID");
            Session.Remove("EMP_ID");
            Session.Remove("EMP_TYPE");
            Session.Remove("Control");
            lblyear.Text = Convert.ToString(DateTime.Now.Year);
        }
    }
    protected void lnk_Logout_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Login.aspx");
        Response.Cookies["PBLOGIN"].Values["UNAME"] = null;
        Response.Cookies["PBLOGIN"].Values["UPASS"] = null;

    }
}