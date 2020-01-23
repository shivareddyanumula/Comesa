using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Reportss_EmployeeRetirment : System.Web.UI.Page
{
    SMHR_ORGANISATION obj_smhr_Organisation;
    SMHR_BUSINESSUNIT obj_smhr_Businessunit;
    SMHR_EMPLOYEE obj_smhr_Employee;
    SMHR_PERIOD obj_smhr_Period;
    SMHR_LOGININFO obj_smhr_Logininfo;
    string Control;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Control = Convert.ToString(Request.QueryString["Control"]);
            //code for security privilage
            Session.Remove("WRITEFACILITY");

            SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

            _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
            _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
            _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString(lbl_header.Text);
            if (Control!=null)
            { 
            switch (Control)
            {
                case "HealthandSafety":
                    _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Health And Safety");
                    break;
                case "SpecificDuration":
                    _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Chapters");
                    break;
               
                case "MyApprovedTrainings":
                    _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("My Approved Trainings");

                    break;
                case "TrainingSchedule":
                    _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Course Schedule");

                    break;
                case "MedicalInvoiceDetails":
                    _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString(" Medical Service Provider wise Invoice Details");
                    break;
            }
            }
                else
                {

                    _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Employee Due To Retire");
     
                }
            
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
                // Rg_Countries.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                btn_Generate.Visible = false;
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
            Page.Validate();
            Control = Convert.ToString(Request.QueryString["Control"]);
            if (!Page.IsPostBack)
            {
                lblStartDate.Text = "From Date";
                lblEndDate.Text = "To Date";
                if (Control != null)
                {

                    if (Control == "HealthandSafety")
                    {
                        lbl_header.Text = "Health And Safety";//Health and Safety";
                        lblStartDate.Text = "Start Date";
                        lblEndDate.Text = "End Date";
                    }
                    else if (Control == "SpecificDuration")
                    {
                        lbl_header.Text = "Specific Duration Report";
                    }
                    else if (Control == "MyApprovedTrainings")
                    {
                        lbl_header.Text = "My Approved Trainings";
                    }
                    else if (Control == "TrainingSchedule")
                    {
                        lbl_header.Text = "Course Schedule";
                    }
                    else if (Control == "MedicalInvoiceDetails")
                    {
                        lbl_header.Text = "Medical Service Provider wise Invoice Details";
                        trServiceProvider.Visible = true;
                    }
                }

                else
                {
                    lbl_header.Text = "Employee Due to Retire";
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeRetirment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    //private void LoadOrganisation()
    //{

    //    SMHR_LOGININFO _obj_LoginInfo = new SMHR_LOGININFO();
    //    _obj_LoginInfo.OPERATION = operation.Login1;
    //    _obj_LoginInfo.LOGIN_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //    DataTable dt_logindetails = BLL.get_Logindetails(_obj_LoginInfo);
    //    rcmb_Organisation.DataSource = dt_logindetails;
    //    rcmb_Organisation.DataTextField = "organisation_name";
    //    rcmb_Organisation.DataValueField = "organisation_id";
    //    rcmb_Organisation.DataBind();
    //}

    //protected void rdpStartDate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    //{
    //    if (Convert.ToDateTime(rdpStartDate.SelectedDate) != null)
    //    {
    //        rdpEndDate.Clear();
    //        rdpEndDate.MinDate = Convert.ToDateTime(rdpStartDate.SelectedDate);
    //    }
    //}

    protected void btn_Generate_Click(object sender, EventArgs e)
    {
        try
        {
            String RPT_NAME = String.Empty;
            if (Control != null)
            {
                if (Control == "HealthandSafety")
                    RPT_NAME = "Health And Safety";
                else if (Control == "SpecificDuration")
                    RPT_NAME = "Workmans compensation";
                else if (Control == "MyApprovedTrainings")
                    RPT_NAME = "My Approved Trainings";
                else if (Control == "TrainingSchedule")
                    RPT_NAME = "Course Schedule";
                else if (Control == "MedicalInvoiceDetails")
                    RPT_NAME = "Medical Service Provider Wise Invoice Details";
            }
            else
            {
                RPT_NAME = "Employees Due to Retire";
            }
            if (Control == "SpecificDuration")
            {
                if (rdpEndDate.SelectedDate == null)
                    rdpEndDate.SelectedDate = DateTime.Now;
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPopUp('" + rdpStartDate.SelectedDate + "', '" + rdpEndDate.SelectedDate + "','" + RPT_NAME + "');", true);
                rdpEndDate.SelectedDate = null;
            }
            else if (Control == "MedicalInvoiceDetails")
            {
                if (string.IsNullOrEmpty(rcmb_ServiceProvider.SelectedValue))
                {
                    BLL.ShowMessage(this, "There is no data in the selected date range");
                    return;
                }
                else if (rdpStartDate.SelectedDate != null && rdpEndDate.SelectedDate != null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowMedicalInvoicePopUp('" + rdpStartDate.SelectedDate + "', '" + rdpEndDate.SelectedDate + "','" + RPT_NAME + "','" + rcmb_ServiceProvider.SelectedValue + "');", true);
                }
            }
            else
            {
                if (rdpEndDate.SelectedDate == null)
                    rdpEndDate.SelectedDate = DateTime.Now;
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + rdpStartDate.SelectedDate + "', '" + rdpEndDate.SelectedDate + "','" + RPT_NAME + "');", true);
                rdpEndDate.SelectedDate = null;
                rdpStartDate.SelectedDate = null;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeRetirment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            // rcmb_Organisation.SelectedIndex = 0;
            rdpStartDate.Clear();
            rdpEndDate.Clear();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeRetirment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rdpEndDate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        try
        {
            rcmb_ServiceProvider.Items.Clear();
            rcmb_ServiceProvider.Text = string.Empty;
            if (Control == "MedicalInvoiceDetails" && rdpStartDate.SelectedDate != null && rdpEndDate.SelectedDate != null)
            {
                SMHR_INSPECTION objInspection = new SMHR_INSPECTION();
                objInspection.INSPECTION_FROMDATE = Convert.ToDateTime(rdpStartDate.SelectedDate);
                objInspection.INSPECTION_TODATE = Convert.ToDateTime(rdpEndDate.SelectedDate);
                objInspection.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                objInspection.MODE = 3;
                DataTable dtServiceProviders = new DataTable();
                dtServiceProviders = BLL.get_MedicalServiceProvider(objInspection);
                if (dtServiceProviders.Rows.Count > 0)
                {
                    rcmb_ServiceProvider.DataSource = dtServiceProviders;
                    rcmb_ServiceProvider.DataTextField = "SERVICEPROVIDERNAME";
                    rcmb_ServiceProvider.DataValueField = "SERVICEPROVIDERNAME";
                    rcmb_ServiceProvider.DataBind();
                    rcmb_ServiceProvider.Items.Insert(0, new RadComboBoxItem("Select", "-1"));
                }
                else
                    BLL.ShowMessage(this, "There is no data in the selected date range");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeRetirment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}