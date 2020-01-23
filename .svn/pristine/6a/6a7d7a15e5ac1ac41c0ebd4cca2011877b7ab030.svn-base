/*using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Web.Configuration;
using SMHR;
using System.Net;
using Microsoft.ReportingServices;
using Telerik.Web.UI;*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using Telerik.Web.UI;
using System.Configuration;
using System.Net;

public partial class Reportss_DivisionalwiseEmployee : System.Web.UI.Page
{

    SMHR_BUSINESSUNIT obj_smhr_Businessunit;
    SMHR_LOGININFO _obj_Smhr_LoginInfo;

    SMHR_DEPARTMENT _obj_SMHR_Department;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {

                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("DivisionalwiseEmployee");
                System.Data.DataTable dtformdtls = BLL.get_LoginInfo(_obj_Smhr_LoginInfo);
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
                LoadOrganisation();
                LoadBusinessUnit();

            }
            Page.Validate();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeMonthly", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    private void LoadOrganisation()
    {
        try
        {
            SMHR_LOGININFO _obj_LoginInfo = new SMHR_LOGININFO();
            _obj_LoginInfo.OPERATION = operation.Login1;
            _obj_LoginInfo.LOGIN_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            System.Data.DataTable dt_logindetails = BLL.get_Logindetails(_obj_LoginInfo);
            rcmb_Organisation.DataSource = dt_logindetails;
            rcmb_Organisation.DataTextField = "organisation_name";
            rcmb_Organisation.DataValueField = "organisation_id";
            rcmb_Organisation.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DivisionalwiseEmployee", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadBusinessUnit()
    {
        try
        {
            obj_smhr_Businessunit = new SMHR_BUSINESSUNIT();
            _obj_Smhr_LoginInfo = new SMHR_LOGININFO();
            _obj_Smhr_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            System.Data.DataTable dt_BUDetails = BLL.get_Business_Units(_obj_Smhr_LoginInfo);
            rcmb_BusinessUnit.DataSource = dt_BUDetails;
            rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BusinessUnit.DataBind();
            rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DivisionalwiseEmployee", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Generate_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToString(rcmb_Organisation.SelectedValue)
            + "','" + Convert.ToString(rcmb_BusinessUnit.SelectedValue) + "', '" + rcmb_Department.SelectedValue + "');", true);
        LoadReport();
    }

    protected void LoadReport()
    {
        try
        {
            rwDivWiseEmp.VisibleOnPageLoad = true;
            RPT_DivisionalwiseEmployeereport.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
            serverReport = RPT_DivisionalwiseEmployeereport.ServerReport;

            Microsoft.Reporting.WebForms.ReportParameter Organisation;
            Microsoft.Reporting.WebForms.ReportParameter Businessunit;
            Microsoft.Reporting.WebForms.ReportParameter Department;

            string sDomain = ConfigurationSettings.AppSettings["MyReportViewerDomain"];
            WebClient wc = new WebClient();
            Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
            serverReport.ReportServerCredentials = _ObjNC;
            serverReport.ReportServerUrl = new Uri(sDomain);
            string MyReportPath = System.Configuration.ConfigurationSettings.AppSettings["MyReportPath"];
            serverReport.ReportPath = MyReportPath + "DivisionalwiseEmploye";

            if (Convert.ToString(Request.QueryString["ORG_ID"]) != "")
            {
                Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Session["ORG_ID"]));
            }
            else
            {
                Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", "-1");
            }
            if (Convert.ToString(Request.QueryString["BU"]) != "")
            {
                Businessunit = new Microsoft.Reporting.WebForms.ReportParameter("Businessunit", Convert.ToString(rcmb_BusinessUnit.SelectedValue));
            }
            else
            {
                Businessunit = new Microsoft.Reporting.WebForms.ReportParameter("Businessunit", "-1");
            }
            if (Convert.ToString(Request.QueryString["Dept"]) != "")
            {
                Department = new Microsoft.Reporting.WebForms.ReportParameter("Department", Convert.ToString(rcmb_Department.SelectedValue));
            }
            else
            {
                Department = new Microsoft.Reporting.WebForms.ReportParameter("Department", "-1");
            }
            Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, Businessunit, Department };
            serverReport.SetParameters(parameters);
            serverReport.Refresh();
            RPT_DivisionalwiseEmployeereport.Visible = true;
        }
        catch (Exception ex)
        {
             SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DivisionalwiseEmployee", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        rcmb_BusinessUnit.SelectedIndex = 0;
        rcmb_Department.SelectedIndex = 0;

    }
    protected void rcmb_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        LoadDepartments();
    }
    private void LoadDepartments()
    {
        rcmb_Department.Items.Clear();
        try
        {
            _obj_SMHR_Department = new SMHR_DEPARTMENT();
            //_obj_SMHR_Department.MODE = 9;
            _obj_SMHR_Department.MODE = 9;
            _obj_SMHR_Department.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_SMHR_Department.BUID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);



            System.Data.DataTable DT = BLL.get_Department(_obj_SMHR_Department);
            if (DT.Rows.Count > 0)
            {
                rcmb_Department.DataSource = DT;
                rcmb_Department.DataValueField = "DEPARTMENT_ID";
                rcmb_Department.DataTextField = "DEPARTMENT_NAME";
                rcmb_Department.DataBind();
                rcmb_Department.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            }
            else
            {
                rcmb_Department.Items.Clear();
                rcmb_Department.Text = string.Empty;
                rcmb_Department.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DivisionalwiseEmployee", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
}