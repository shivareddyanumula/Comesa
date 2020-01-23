using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Data;
using System.Data.SqlClient;

public partial class Payroll_frm_tranDetails : System.Web.UI.Page
{
    SMHR_PAYROLL _obj_smhr_payroll;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            lbl_Header.Text = "Pay roll Transaction details for : " + Convert.ToString(Request.QueryString["PDID"]);
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_tranDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    private void LoadGrid()
    {
        try
        {
            _obj_smhr_payroll = new SMHR_PAYROLL();
            _obj_smhr_payroll.OPERATION = operation.Check;
            _obj_smhr_payroll.MODE = 2;
            _obj_smhr_payroll.TRANID = Convert.ToInt32(Convert.ToString(Request.QueryString["ID"]));
            DataTable dt_Details = BLL.get_Payroll(_obj_smhr_payroll);
            RG_PayTran.DataSource = dt_Details;
            RG_PayTran.DataBind();
        }
        catch(Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_tranDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
