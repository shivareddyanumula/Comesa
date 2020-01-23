using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;

public partial class Main_Page : System.Web.UI.Page
{
    SMHR_EMPLOYEE _obj_smhr_employee;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToString(Session["EMP_ID"]) == "")
            {
                Response.Redirect("Login.aspx", false);
            }
            if (!Page.IsPostBack)
            {
                lbl_Birthday.Text = "BIRTHDAY REMINDERS - " + DateTime.Now.ToLongDateString().ToUpper();
                getBirthday();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Main_Page", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    private void getBirthday()
    {
        SMHR_EMPLOYEE _obj_smhr_Employee = new SMHR_EMPLOYEE();
        _obj_smhr_Employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
        DataTable dtDetails = BLL.get_Birthday(_obj_smhr_Employee);
        if (dtDetails.Rows.Count != 0)
        {
            RTicker.DataSource = dtDetails;
            RTicker.DataTextField = "EMPNAME";
            RTicker.DataBind();
        }
        else
        {
            lbl_Reminders.Text = "NO BIRTHDAYS TODAY";
        }
    }
}
