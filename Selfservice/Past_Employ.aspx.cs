using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using Telerik.Web.UI;

public partial class Selfservice_Past_Employ : System.Web.UI.Page
{
    SMHR_EMPLOYEE _obj_smhr_employee;
    SMHR_APPLICANT _obj_smhr_applicant;
    static string _lbl_Emp_Id = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                LoadExperience();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Past_Employ", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadExperience()
    {
        _obj_smhr_employee = new SMHR_EMPLOYEE();
        _obj_smhr_employee.EMP_ID = Convert.ToInt32(Request.QueryString["ID"]);
        _obj_smhr_employee.Mode = 1;
        DataTable dt1 = BLL.get_EmpESS(_obj_smhr_employee);
        if (dt1.Rows.Count != 0)
        {
            _lbl_Emp_Id = Convert.ToString(dt1.Rows[0]["EMP_APPLICANT_ID"]);
        }
        _obj_smhr_applicant = new SMHR_APPLICANT();
        _obj_smhr_applicant.APPEXP_APPLICANT_ID = Convert.ToInt32(_lbl_Emp_Id);
        _obj_smhr_applicant.OPERATION = operation.Check;
        DataTable dt = BLL.get_ApplicantExperience(_obj_smhr_applicant);
        RG_Experience.DataSource = dt;
        RG_Experience.DataBind();
    }
}
