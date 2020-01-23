using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using SPMS;

public partial class PMS_frm_PmsAppraisalEmpDetails : System.Web.UI.Page
{
    //int empID;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                //empID = Convert.ToInt32(Session["MGR_EMP_ID"]);
                LoadGrid();
                LoadValues();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisalEmpDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rgEmpDetails_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            if (Request.QueryString.HasKeys())
            {
                DataTable dtPrevEmpDtls = Pms_Bll.Get_Pms_App_Emp_Prev_Details(Convert.ToInt32(Request.QueryString["EMP_ID"]));
                rgEmpDetails.DataSource = dtPrevEmpDtls;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisalEmpDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadGrid()
    {
        try
        {
            if (Request.QueryString.HasKeys())
            {
                DataTable dtPrevEmpDtls = Pms_Bll.Get_Pms_App_Emp_Prev_Details(Convert.ToInt32(Request.QueryString["EMP_ID"]));

                rgEmpDetails.DataSource = dtPrevEmpDtls;
                rgEmpDetails.DataBind();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisalEmpDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadValues()
    {
        try
        {
            if (Request.QueryString.HasKeys())
            {
                DataTable dtEmpDtls = Pms_Bll.Get_PMS_App_Emp_Details(Convert.ToInt32(Request.QueryString["EMP_ID"]));

                if (dtEmpDtls.Rows.Count > 0)
                {
                    rtbEmpFullName.Text = Convert.ToString(dtEmpDtls.Rows[0]["APPLICANT_FULLNAME"]);
                    rtbPrsnlNo.Text = Convert.ToString(dtEmpDtls.Rows[0]["APPLICANT_MOBILE"]);
                    rtbDOB.Text = Convert.ToString(dtEmpDtls.Rows[0]["APPLICANT_DOB"]);
                    rtbCrntPstn.Text = Convert.ToString(dtEmpDtls.Rows[0]["POSITIONS_CODE"]);
                    rtbTypEmp.Text = Convert.ToString(dtEmpDtls.Rows[0]["EMP_EMPLOYEETYPE"]);
                    rtbCntExpDate.Text = Convert.ToString(dtEmpDtls.Rows[0]["EMP_CONTRACT_DATE"]);
                    rtbPscScale.Text = Convert.ToString(dtEmpDtls.Rows[0]["EMP_GRADE"]);
                    rtbDOC.Text = Convert.ToString(dtEmpDtls.Rows[0]["EMP_DOC"]);
                    rtbDept.Text = Convert.ToString(dtEmpDtls.Rows[0]["DEPARTMENT_NAME"]);
                    rtbSection.Text = Convert.ToString(dtEmpDtls.Rows[0]["SMHR_DIV_CODE"]);
                    rtbIPPH.Text = Convert.ToString(dtEmpDtls.Rows[0]["POSITIONS_CODE"]);
                    rtbPrsntBasicSal.Text = Convert.ToString(dtEmpDtls.Rows[0]["EMP_BASIC"]);
                }
                else
                {
                    Pms_Bll.ShowMessage(this, "There are No Records to Display..");

                    string script = "<script language='javascript' type='text/javascript'>Sys.Application.add_load(CloseAndRedirect);</script>";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Close", script);
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisalEmpDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}