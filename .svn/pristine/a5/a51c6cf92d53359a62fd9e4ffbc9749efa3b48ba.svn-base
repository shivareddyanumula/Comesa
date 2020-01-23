using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using SMHR;

public partial class Selfservice_Qualification : System.Web.UI.Page
{
    SMHR_EMPLOYEE _obj_smhr_employee;
    SMHR_MASTERS _obj_smhr_masters;
    SMHR_APPLICANT _obj_smhr_applicant;
    static string _lbl_ID = "";
    static string _lbl_Emp_Id = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {


                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Qualification");
                DataTable dtformdtls = BLL.get_LoginInfo(_obj_Smhr_LoginInfo);
                if (dtformdtls.Rows.Count != 0)
                {
                    if ((Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_READ"]) == true) && (Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_WRITE"]) == true))
                    {
                        Session["WRITEFACILITY"] = 1;//WHICH MEANS READ AND WRITE
                    }
                    else if ((Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_READ"]) == true) && (Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_WRITE"]) == false))
                    {
                        Session["WRITEFACILITY"] = 2;//WHICH MEANS READ NO WRITE
                    }
                    else if ((Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_READ"]) == false) && (Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_WRITE"]) == false))
                    {
                        Session["WRITEFACILITY"] = 3;//WHICH MEANS NO READ AND NO WRITE
                    }

                }
                else
                {
                    smhr_UNAUTHORIZED _obj_smhr_unauthorized = new smhr_UNAUTHORIZED();
                    _obj_smhr_unauthorized.UNAUTHORIZED_USERID = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_unauthorized.UNAUTHORIZED_FORMID = Convert.ToInt32(ViewState["FORMS_ID"]);
                    _obj_smhr_unauthorized.UNAUTHORIZED_MODULEID = Convert.ToInt32(ViewState["MODULE_ID"]);
                    _obj_smhr_unauthorized.UNAUTHORIZED_ACCESSDATE = Convert.ToDateTime(DateTime.Now.ToString());
                    SMHR.BLL.UnAuthorized_Log(_obj_smhr_unauthorized);
                    Response.Redirect("~/frm_UnAuthorized.aspx", false);
                }


                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    RG_Qualification.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Qual_Correct.Visible = false;
                    // btn_Update.Visible = false;
                }
                else if (Convert.ToInt32(Session["WRITEFACILITY"]) == 3)
                {
                    smhr_UNAUTHORIZED _obj_smhr_unauthorized = new smhr_UNAUTHORIZED();
                    _obj_smhr_unauthorized.UNAUTHORIZED_USERID = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_unauthorized.UNAUTHORIZED_FORMID = Convert.ToInt32(ViewState["FORMS_ID"]);
                    _obj_smhr_unauthorized.UNAUTHORIZED_MODULEID = Convert.ToInt32(ViewState["MODULE_ID"]);
                    _obj_smhr_unauthorized.UNAUTHORIZED_ACCESSDATE = Convert.ToDateTime(DateTime.Now.ToString());
                    SMHR.BLL.UnAuthorized_Log(_obj_smhr_unauthorized);
                    Response.Redirect("~/frm_UnAuthorized.aspx", false);
                }
                LoadCombos();
                clearQualFields();
                LoadQualification();
            }
            LoadQualification();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Qualification", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadCombos()
    {
        try
        {
            ddl_Category.Items.Clear();
            _obj_smhr_masters = new SMHR_MASTERS();
            _obj_smhr_masters.MASTER_TYPE = "QUALIFICATION";
            _obj_smhr_masters.OPERATION = operation.Select;
            _obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);
            ddl_Category.DataSource = dt_Details;
            ddl_Category.DataTextField = "HR_MASTER_CODE";
            ddl_Category.DataValueField = "HR_MASTER_ID";
            ddl_Category.DataBind();
            ddl_Category.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Qualification", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void RG_Qualification_ItemCommand(object source, GridCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Edit_Rec")
            {
                GridDataItem dtItem = (GridDataItem)e.Item;
                int index = dtItem.ItemIndex;
                Label lbl_ID = new Label();
                Label lblID = new Label();
                Label lblInstitute = new Label();
                Label lblYearPass = new Label();
                Label lblPercent = new Label();
                Label lblGrade = new Label();
                lbl_ID = RG_Qualification.Items[index].FindControl("lblID") as Label;
                lblID = RG_Qualification.Items[index].FindControl("lbl_ID") as Label;
                lblInstitute = RG_Qualification.Items[index].FindControl("lbl_AppInstitute") as Label;
                lblYearPass = RG_Qualification.Items[index].FindControl("lbl_AppYearPass") as Label;
                lblPercent = RG_Qualification.Items[index].FindControl("lbl_AppPercentage") as Label;
                lblGrade = RG_Qualification.Items[index].FindControl("lbl_AppGrade") as Label;
                ddl_Category.SelectedIndex = ddl_Category.FindItemIndexByValue(lblID.Text);
                _lbl_ID = lbl_ID.Text;
                txt_Institute.Text = Convert.ToString(lblInstitute.Text);
                txt_YearofPass.Value = Convert.ToDouble(lblYearPass.Text);
                txt_Percentage.Value = Convert.ToDouble(lblPercent.Text);
                ddl__Grade.SelectedIndex = ddl__Grade.FindItemIndexByValue(lblGrade.Text);
                btn_Qual_Add.Visible = false;
                btn_Qual_Correct.Visible = true;
                ddl_Category.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Qualification", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Qual_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearQualFields();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Qualification", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Qual_Add_Click(object sender, EventArgs e)
    {
        try
        {
            if (Check_Combo(RG_Qualification, "lbl_ID", ddl_Category))
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
                bool status = false;
                _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(_lbl_Emp_Id);
                _obj_smhr_applicant.APPQFN_QUALIFICATION_ID = Convert.ToInt32(ddl_Category.SelectedValue);
                _obj_smhr_applicant.APPQFN_INSTITUTE = Convert.ToString(txt_Institute.Text.Replace("'", "''"));
                _obj_smhr_applicant.APPQFN_PASSEDYEAR = Convert.ToInt32(txt_YearofPass.Value);
                _obj_smhr_applicant.APPQFN_PERCENTAGE = Convert.ToDouble(Convert.ToString(txt_Percentage.Value));
                _obj_smhr_applicant.APPQFN_GRADE = Convert.ToString(ddl__Grade.SelectedItem.Value);
                _obj_smhr_applicant.APPQFN_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_smhr_applicant.APPQFN_CREATEDDATE = DateTime.Now;
                _obj_smhr_applicant.OPERATION = operation.Insert;
                status = BLL.set_AppQualification(_obj_smhr_applicant);
                LoadQualification();
                clearQualFields();
                ddl_Category.Enabled = true;
            }
            else
            {
                BLL.ShowMessage(this, "This Qualification is already added");
                clearQualFields();
                ddl_Category.Focus();
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Qualification", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void clearQualFields()
    {
        try
        {
            ddl_Category.SelectedIndex = -1;
            txt_Institute.Text = string.Empty;
            txt_YearofPass.Value = null;
            txt_Percentage.Value = null;
            ddl__Grade.SelectedIndex = -1;
            btn_Qual_Add.Visible = true;
            btn_Qual_Correct.Visible = false;
            ddl_Category.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Qualification", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadQualification()
    {
        try
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
            _obj_smhr_applicant.APPQFN_APPLICANT_ID = Convert.ToInt32(_lbl_Emp_Id);
            _obj_smhr_applicant.OPERATION = operation.Check;
            DataTable dt = BLL.get_ApplicantQualification(_obj_smhr_applicant);
            RG_Qualification.DataSource = dt;
            RG_Qualification.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Qualification", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Qual_Correct_Click(object sender, EventArgs e)
    {
        try
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
            bool status = false;
            _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(_lbl_Emp_Id);
            _obj_smhr_applicant.APPQFN_ID = Convert.ToInt32(_lbl_ID);
            _obj_smhr_applicant.APPQFN_QUALIFICATION_ID = Convert.ToInt32(ddl_Category.SelectedValue);
            _obj_smhr_applicant.APPQFN_INSTITUTE = Convert.ToString(txt_Institute.Text.Replace("'", "''"));
            _obj_smhr_applicant.APPQFN_PASSEDYEAR = Convert.ToInt32(txt_YearofPass.Value);
            _obj_smhr_applicant.APPQFN_PERCENTAGE = Convert.ToDouble(Convert.ToString(txt_Percentage.Value));
            _obj_smhr_applicant.APPQFN_GRADE = Convert.ToString(ddl__Grade.SelectedItem.Value);
            _obj_smhr_applicant.APPQFN_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_applicant.APPQFN_LASTMDFDATE = DateTime.Now;
            _obj_smhr_applicant.OPERATION = operation.Update;
            status = BLL.set_AppQualification(_obj_smhr_applicant);
            LoadQualification();
            clearQualFields();
            ddl_Category.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Qualification", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    public bool Check_Combo(RadGrid rdGrid, string lbl_validate, RadComboBox rcmb_Validate)
    {
        bool status = true;
        try
        {

            if (rdGrid.Items.Count > 0)
            {
                for (int i = 0; i < rdGrid.Items.Count; i++)
                {
                    Label lbl_Control = new Label();
                    lbl_Control = rdGrid.Items[i].FindControl("" + lbl_validate + "") as Label;
                    if (Convert.ToInt32(lbl_Control.Text) == Convert.ToInt32(rcmb_Validate.SelectedValue))
                    {
                        status = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Qualification", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return status;
    }

}
