using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Selfservice_frm_Emp_MedicalClaims : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                LoadGrid();
                RG_EmpMedicalClaims.DataBind();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Emp_MedicalClaims", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void RG_EmpMedicalClaims_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        LoadGrid();
    }

    private void LoadGrid()
    {
        try
        {
            if (Request.QueryString.HasKeys())
            {

                SMHR_MedicalClaim _obj_Smhr_MedicalClaim = new SMHR_MedicalClaim();
                _obj_Smhr_MedicalClaim.EmpID = Convert.ToInt32(Request.QueryString["EMP_ID"]);
                _obj_Smhr_MedicalClaim.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_MedicalClaim.OPERATION = operation.Select1;
                DataTable dtEmpBeneficiaryDtls = BLL.get_MedicalClaim(_obj_Smhr_MedicalClaim);

                RG_EmpMedicalClaims.DataSource = dtEmpBeneficiaryDtls;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Emp_MedicalClaims", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}