using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SMHR;
using System.Text;
using Telerik.Web.UI;

public partial class Masters_Error_Log : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnk_Delete_Command(object sender, CommandEventArgs e)
    {
        try
        {
            SMHR_LOANREQUEST _obj_smhr_empcompoff = new SMHR_LOANREQUEST();
            _obj_smhr_empcompoff.ERROR_LOG_ID  = Convert.ToInt32(e.CommandArgument);
            if(BLL.set_ErrorLog(_obj_smhr_empcompoff)==true)
            {
                BLL.ShowMessage(this, "Record deleted successfully");
                LoadData1();
              
            }
            else
            {
                BLL.ShowMessage(this, "Record not deleted successfully");
            }
            
            
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Error_Log", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rg_Mamager_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadData();
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Error_Log", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadData()
    {
        try
        {
            SMHR_LOANREQUEST _obj_smhr_empcompoff = new SMHR_LOANREQUEST();
            _obj_smhr_empcompoff.OPERATION = operation.Select3;
            Rg_Mamager.DataSource = BLL.get_Error_Log(_obj_smhr_empcompoff);
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Error_Log", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadData1()
    {
        try
        {
            SMHR_LOANREQUEST _obj_smhr_empcompoff = new SMHR_LOANREQUEST();
            _obj_smhr_empcompoff.OPERATION = operation.Select3;
            Rg_Mamager.DataSource = BLL.get_Error_Log(_obj_smhr_empcompoff);
            Rg_Mamager.DataBind();
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Error_Log", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

}
