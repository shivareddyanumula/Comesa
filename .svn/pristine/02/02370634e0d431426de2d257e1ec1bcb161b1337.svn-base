using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;

public partial class Selfservice_Personal : System.Web.UI.Page
{
    SMHR_EMPLOYEE _obj_smhr_employee;
    SMHR_APPLICANT _obj_smhr_applicant;
    static string _lbl_Emp_Id = "";
    static string _lbl_empCode = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                getDetails();
            }
            btn_Update.Visible = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Personal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void getDetails()
    {
        try
        {
            txt_Address.Text = string.Empty;
            _obj_smhr_employee = new SMHR_EMPLOYEE();
            _obj_smhr_employee.EMP_ID = Convert.ToInt32(Request.QueryString["ID"]);
            _obj_smhr_employee.Mode = 1;
            DataTable dt = BLL.get_EmpESS(_obj_smhr_employee);
            if (dt.Rows.Count != 0)
            {
                _lbl_Emp_Id = Convert.ToString(dt.Rows[0]["EMP_APPLICANT_ID"]);
                _lbl_empCode = Convert.ToString(dt.Rows[0]["EMP_EMPCODE"]);
                lblTitle.Text = Convert.ToString(dt.Rows[0]["APPLICANT_TITLE"]);
                lblfirstname.Text = Convert.ToString(dt.Rows[0]["APPLICANT_FIRSTNAME"]);
                lblLastName.Text = Convert.ToString(dt.Rows[0]["APPLICANT_LASTNAME"]);
                lblMiddlename.Text = Convert.ToString(dt.Rows[0]["APPLICANT_MIDDLENAME"]);
                lblMaritalstatus.Text = Convert.ToString(dt.Rows[0]["APPLICANT_MARITALSTATUS"]);
                lblDOB.Text = Convert.ToString(dt.Rows[0]["APPLICANT_DOB"]);
                lblDOJ.Text = Convert.ToString(dt.Rows[0]["EMP_DOJ"]);
                lblGender.Text = Convert.ToString(dt.Rows[0]["APPLICANT_GENDER"]);
                txt_Address.Text = Convert.ToString(dt.Rows[0]["APPLICANT_ADDRESS"]);
                lblGrosssal.Text = Convert.ToString(dt.Rows[0]["EMP_GROSSSAL"]);
                lblBasicPay.Text = Convert.ToString(dt.Rows[0]["EMP_BASIC"]);
                lblBusinessunit.Text = Convert.ToString(dt.Rows[0]["BUSINESSUNIT_CODE"]);
                lblempstatus.Text = Convert.ToString(dt.Rows[0]["EMP_EMPLOYEETYPE"]);
                lblGrade.Text = Convert.ToString(dt.Rows[0]["EMPLOYEEGRADE_CODE"]);
                lblJob.Text = Convert.ToString(dt.Rows[0]["JOB"]);
                lblLeaveStruct.Text = Convert.ToString(dt.Rows[0]["LEAVESTRUCT_CODE"]);
                lblNoticeperiod.Text = Convert.ToString(dt.Rows[0]["EMP_NOTICEPERIOD"]);
                lblPosition.Text = Convert.ToString(dt.Rows[0]["POSITIONS"]);
                lblsalarystruct.Text = Convert.ToString(dt.Rows[0]["SALARYSTRUCT_CODE"]);
                lblShift.Text = Convert.ToString(dt.Rows[0]["SHIFT"]);
                //rtxt_Supervisor.Text = Convert.ToString(dt.Rows[0]["REPORTINGEMPLOYEE"]);
                lblPaymode.Text = Convert.ToString(dt.Rows[0]["PAYMENTMODE"]);
                //lblGrade.Text = Convert.ToString(dt.Rows[0]["GRADE"]);

                if (Convert.ToString(dt.Rows[0]["EMPREPORTINGEMPLOYEE"]) != "")
                    lblSupervisor.Text = Convert.ToString(dt.Rows[0]["EMPREPORTINGEMPLOYEE"]);
                else
                    BLL.ShowMessage(this, "No Supervisor is Assigned for this Employee");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Personal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Update_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_smhr_applicant = new SMHR_APPLICANT();
            _obj_smhr_applicant.APPLICANT_ADDRESS = Convert.ToString(txt_Address.Text);
            _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(_lbl_Emp_Id);
            bool status = BLL.set_empSelfservicePersonal(_obj_smhr_applicant);
            if (status == true)
            {
                BLL.ShowMessage(this, "Employee Details Updated");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Test", "<script type='text/javascript'>Close()</" + "script>", false);
                return;
            }
            else
            {
                BLL.ShowMessage(this, "An Error Occured while doing the process");
                return;
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Personal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
