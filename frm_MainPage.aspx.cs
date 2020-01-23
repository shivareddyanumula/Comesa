using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;

public partial class frm_MainPage : System.Web.UI.Page
{
    SMHR_EMPLOYEE _obj_smhr_employee;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToString(Session["EMP_ID"]) == "")
            {
                Response.Redirect("Login.aspx", false);
            }
            if (!Page.IsPostBack)
            {
                lbl_Birthday.Text = "BIRTHDAY REMINDERS - " + DateTime.Now.ToLongDateString().ToUpper();
                getEmployeeData();
                getBirthday();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_MainPage", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    private void getEmployeeData()
    {
        _obj_smhr_employee = new SMHR_EMPLOYEE();
        _obj_smhr_employee.EMP_ID = Convert.ToInt32(Convert.ToString(Session["EMP_ID"]));
        DataTable dtDetails = BLL.get_EmpData(_obj_smhr_employee);
        if (dtDetails.Rows.Count != 0)
        {
            lblEmpCode.Text = Convert.ToString(dtDetails.Rows[0]["EMP_EMPCODE"]);
            lblEmpName.Text = Convert.ToString(dtDetails.Rows[0]["EMPNAME"]);
            lblDOB.Text = Convert.ToString(dtDetails.Rows[0]["APPLICANT_DOB"]);
            lblBusinessUnit.Text = Convert.ToString(dtDetails.Rows[0]["BUSINESSUNIT_CODE"]);
            lblDesignation.Text = Convert.ToString(dtDetails.Rows[0]["POSITIONS_CODE"]);
            lblGrade.Text = Convert.ToString(dtDetails.Rows[0]["HR_MASTER_CODE"]);
            //lblCurrency.Text = Convert.ToString(dtDetails.Rows[0]["CURR_CODE"]);
            lblStatus.Text = Convert.ToString(dtDetails.Rows[0]["EMP_EMPLOYEETYPE"]);
            Img_EmpSelfSerive.ToolTip = Convert.ToString(dtDetails.Rows[0]["EMPNAME"]);
            if ((Convert.ToString(dtDetails.Rows[0]["EMP_PICTURE"]) != "") && dtDetails.Rows[0]["EMP_PICTURE"] != System.DBNull.Value)
                Img_EmpSelfSerive.ImageUrl = Convert.ToString(dtDetails.Rows[0]["EMP_PICTURE"]);

        }
    }

    private void getBirthday()
    {
        SMHR_EMPLOYEE _obj_smhr_Employee = new SMHR_EMPLOYEE();
        _obj_smhr_Employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
        DataTable dtDetails = BLL.get_Birthday(_obj_smhr_Employee);
        if (dtDetails.Rows.Count != 0)
        {
            RTicker.DataSource = dtDetails;
            RTicker.DataTextField = "EMPNAME";
            RTicker.DataBind();
        }
        else
        {
            lbl_Reminders.Text = "NO BIRTHDAYS TODAY";
        }
    }
}
