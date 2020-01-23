using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Data;
using System.Data.SqlClient;

public partial class Payroll_frm_PayRejectHist : System.Web.UI.Page
{
    SMHR_PAYREJECT _obj_smhr_payreject;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                LoadDetails();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayRejectHist", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    private void LoadDetails()
    {
        try
        {
            _obj_smhr_payreject = new SMHR_PAYREJECT();
            _obj_smhr_payreject.MODE = 2;
            _obj_smhr_payreject.TRANID = Convert.ToInt32(Convert.ToString(Request.QueryString["ID"]));
            DataTable dt = BLL.get_payrejectEmpDet(_obj_smhr_payreject);
            RG_PayTran.DataSource = dt;
            RG_PayTran.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayRejectHist", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
