using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Data;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

public partial class Masters_ManagerViewLoanStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "ManagerViewLoanStatus", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rg_MamagerLoanStatus_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadDetails();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "ManagerViewLoanStatus", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadDetails()
    {
        try
        {
            SMHR_LOANTRANSDTL obj = new SMHR_LOANTRANSDTL();
            obj.OPERATION = operation.Approve;
            Rg_MamagerLoanStatus.DataSource = BLL.get_LoanDetails(obj);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "ManagerViewLoanStatus", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

        //Rg_MamagerLoanStatus.DataBind();
    }
}
