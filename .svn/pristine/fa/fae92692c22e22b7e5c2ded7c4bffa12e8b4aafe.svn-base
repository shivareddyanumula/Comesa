using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
public partial class Payroll_SelectLoanType : System.Web.UI.Page
{
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void rb_EMI_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (rb_EMI.Checked == true)
            {
                Session["LOANTYPE"] = 1;
            }

            Response.Redirect("frm_EmpLoanTran.aspx");
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "SelectLoanType", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
   
    protected void rb_red_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (rb_red.Checked == true)
            {
                Session["LOANTYPE"] = 2;
            }
            Response.Redirect("frm_EmpReducingLoanTran.aspx");
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "SelectLoanType", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        
    }
}
