using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Web.Security;
using Telerik.Web.UI;

public partial class MasterPage : System.Web.UI.MasterPage
{
    SMHR_GLOBALCONFIG _obj_GlobalConfig;
    SMHR_EMPLOYEE _obj_smhr_employee;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                if (BLL.ExecuteQuery(" EXEC USP_SMHR_GLOBALCONFIG @OPERATION = 'Check'").Rows[0]["GLOBALCONFIG_COMPANYLOGO"] != System.DBNull.Value)
                {
                    string temp = Convert.ToString(BLL.ExecuteQuery(" EXEC USP_SMHR_GLOBALCONFIG @OPERATION = 'Check'").Rows[0]["GLOBALCONFIG_COMPANYLOGO"]);
                    img_CompLogo.ImageUrl = temp;
                }
                if (Session["EMP_TYPE"] != null)
                {
                    GetMenu(Convert.ToString(Session["EMP_TYPE"]));
                    getDetails();
                }
                else
                {
                    if (Request.FilePath.IndexOf("Login.aspx") == -1)
                        Response.Redirect("~/Login.aspx", false);
                }
            }
            this.Page.Title = " :: Smart HR - Kenya ::";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "function pageLoad(){ }", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MasterPage", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Home_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["SELFSERVICE"] == "")
            {
                Response.Redirect("~/Masters/Default.aspx", false);
            }
            else
            {
                Response.Redirect("~/Main_Page.aspx", false);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MasterPage", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Logout_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["USER_ID"] != null)
            {
                Session.Remove("USERNAME");
                Session.Remove("USER_ID");
                Session.Remove("EMP_ID");
                Session.Remove("EMP_TYPE");
                Session.Remove("Control");
                Session.Remove("SELFSERVICE");
                FormsAuthentication.SignOut();
                Response.Redirect("~/Login.aspx", false);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MasterPage", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void GetMenu(string LoginType)
    {
        try
        {
            DataTable DT = BLL.get_Menus(Convert.ToString(LoginType), Convert.ToInt32(Session["SUPERMODULE_ID"]));
            foreach (DataRow item in DT.Rows)
            {
                foreach (RadMenuItem items in RadMenu1.GetAllItems())
                {
                    if (items.TabIndex == Convert.ToInt32(item["TYPSEC_FORMS_ID"]))
                        items.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MasterPage", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_ChangePassword_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "function pageLoad(){  ShowPopForm(); }", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MasterPage", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void getDetails()
    {
        _obj_smhr_employee = new SMHR_EMPLOYEE();
        _obj_smhr_employee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
        _obj_smhr_employee.Mode = 1;
        DataTable dt = BLL.get_EmpESS(_obj_smhr_employee);
        if (dt.Rows.Count != 0)
        {
            lbl_Welcome.Text = "Welcome, " + Convert.ToString(dt.Rows[0]["APPLICANT_TITLE"]) + ' ' + Convert.ToString(dt.Rows[0]["APPLICANT_FIRSTNAME"]) + ' ' +
                                 Convert.ToString(dt.Rows[0]["APPLICANT_MIDDLENAME"]) + ' ' + Convert.ToString(dt.Rows[0]["APPLICANT_LASTNAME"]);
        }
    }
}
