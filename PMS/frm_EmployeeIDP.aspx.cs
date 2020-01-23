using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using SPMS;
using System.Data.SqlClient;
using Telerik.Web.UI;


using System.Data;
public partial class PMS_frm_EmployeeIDP : System.Web.UI.Page
{
    pms_IDPSCREEN _obj_idp;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {//Employee IDP
        Page.Validate();
        if (!Page.IsPostBack)
        {

            loadgrid();
        }

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeIDP", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #region loadgrid()
    /// <summary>
    /// Here loadgrid() method for load a grid...
    /// </summary>
    protected void loadgrid()
    { try
        {
        _obj_idp = new pms_IDPSCREEN();
        _obj_idp.IDP_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
        _obj_idp.IDP_MODE = 3;
        _obj_idp.IDP_ORGANISATION_ID = Convert.ToInt32(Session["org_id"]);
        DataTable dt = Pms_Bll.get_idp(_obj_idp);
        if (dt.Rows.Count != 0)
        {
            RG_Idpform.DataSource = dt;
            RG_Idpform.DataBind();
        }
        else
        {
            DataTable dt1 = new DataTable();
            RG_Idpform.DataSource = dt1;
            RG_Idpform.DataBind();
        }

        }

    catch (Exception ex)
    {
        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeIDP", ex.StackTrace, DateTime.Now);
        Response.Redirect("~/Frm_ErrorPage.aspx");
    }
    }

    protected void RG_Idpform_NeedDataSource1(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
        _obj_idp = new pms_IDPSCREEN();
        _obj_idp.IDP_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
        _obj_idp.IDP_MODE = 3;
        _obj_idp.IDP_ORGANISATION_ID = Convert.ToInt32(Session["org_id"]);
        DataTable dt = Pms_Bll.get_idp(_obj_idp);
        if (dt.Rows.Count != 0)
        {
            RG_Idpform.DataSource = dt;
        }

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeIDP", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion
}
