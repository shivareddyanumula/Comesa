using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ReportingServices;
using System.Net;
using Telerik.Web.UI;



public partial class Grievances_RecordIncident : System.Web.UI.Page
{
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }
    public static int OrganizationID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (!IsPostBack)
            {

                //code for security privilage
                Session.Remove("WRITEFACILITY");
                OrganizationID = Convert.ToInt32(Session["ORG_ID"]);
                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Record Incident");//COUNTRY");
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
                    Rg_RecordIncident.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Save.Visible = false;
                    btn_Update.Visible = false;
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
                rdp_DiscussionDate.MaxDate = DateTime.Now;
                rdp_ReportedDate.MaxDate = DateTime.Now;
                Page.Validate();

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "RecordIncident", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Rg_RecordIncident_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            Rg_RecordIncident.DataSource = LoadIncidentGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "RecordIncident", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private DataTable LoadIncidentGrid()
    {
        SMHR_GRIEVANCE _obj_Smhr_Grievance = new SMHR_GRIEVANCE();
        try
        {

            _obj_Smhr_Grievance.GRIEVANCE_ID = 0;
            _obj_Smhr_Grievance.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Grievance.OPERATION = operation.Select;

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "RecordIncident", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return BLL.get_Incidents(_obj_Smhr_Grievance);
    }


    protected void btn_lettermail_Click(object sender, EventArgs e)
    {
        try
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToInt32(comlainton_empid.Text) + "','" + Convert.ToString(Session["GREVE_ID"]) + "','" + rcmb_DisciplinaryGrievanceAction.SelectedItem.Text.ToUpper() + "');", true);


        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "RecordIncident", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_GRIEVANCE _obj_Smhr_Grievance = new SMHR_GRIEVANCE();
            _obj_Smhr_Grievance.GRIEVANCE_INCIDENT = rcmb_Incident.SelectedItem.Text;
            _obj_Smhr_Grievance.GRIEVANCE_INCIDENTID = rtxt_IncidentID.Text;
            _obj_Smhr_Grievance.GRIEVANCE_INCIDENTTYPE_ID = Convert.ToInt32(rcmb_IncidentType.SelectedValue);
            _obj_Smhr_Grievance.GRIEVANCE_REPORTEDDATE = rdp_ReportedDate.SelectedDate;
            _obj_Smhr_Grievance.GRIEVANCE_INCIDENTDESCRIPTION = rtxt_Description.Text;
            if (Convert.ToString(rcmb_ReportedByEmployee.SelectedValue) == string.Empty)
            {
                BLL.ShowMessage(this, "Plrase select Complaint By clearly"); return;

            }
            else
            {
                _obj_Smhr_Grievance.GRIEVANCE_REPORTEDBY = Convert.ToInt32(rcmb_ReportedByEmployee.SelectedValue);
            }
            if (Convert.ToString(rcmb_ReportedOnEmployee.SelectedValue) == string.Empty)
            {
                BLL.ShowMessage(this, "Plrase select Complaint On clearly"); return;
            }
            else
            {
                _obj_Smhr_Grievance.GRIEVANCE_REPORTEDON = Convert.ToInt32(rcmb_ReportedOnEmployee.SelectedValue);
            }
            if ((Convert.ToString(rcmb_ReportedByEmployee.SelectedValue) != string.Empty) && (Convert.ToString(rcmb_ReportedOnEmployee.SelectedValue) != string.Empty))
            {
                if ((Convert.ToString(rcmb_ReportedByEmployee.SelectedValue)) == (Convert.ToString(rcmb_ReportedOnEmployee.SelectedValue)))
                {
                    BLL.ShowMessage(this, "Complaint By and Complaint On cannot be same");
                    return;
                }
            }
            _obj_Smhr_Grievance.GRIEVANCE_COMMITTEEID = Convert.ToInt32(rcmb_Committee.SelectedValue);
            _obj_Smhr_Grievance.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Grievance.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_Grievance.CREATEDDATE = DateTime.Now;
            _obj_Smhr_Grievance.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_Grievance.LASTMDFDATE = DateTime.Now;

            SMHR_EMPLOYEE _obj_employee = new SMHR_EMPLOYEE();
            _obj_employee.EMP_ID = Convert.ToInt32(rcmb_ReportedOnEmployee.SelectedValue);
            _obj_employee.OPERATION = operation.Select;
            DataTable dt_employee = BLL.get_Employeedetail(_obj_employee);
            if (rdp_ReportedDate.SelectedDate < Convert.ToDateTime(dt_employee.Rows[0]["EMP_DOJ"]))
            {
                BLL.ShowMessage(this, "Report Date Should not be less than complaint On employee join date"); return;
            }
            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_UPDATE":
                    _obj_Smhr_Grievance.GRIEVANCE_ID = Convert.ToInt32(ViewState["GRIEVANCE_ID"]);
                    _obj_Smhr_Grievance.GRIEVANCE_INCIDENTDESCRIPTION = rtxt_Description.Text;
                    _obj_Smhr_Grievance.OPERATION = operation.Update;
                    if (BLL.record_Incident(_obj_Smhr_Grievance))
                        BLL.ShowMessage(this, "Record Complaint Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Record Complaint Not Updated");

                    break;
                case "BTN_SAVE":

                    _obj_Smhr_Grievance.OPERATION = operation.Insert;
                    if (BLL.record_Incident(_obj_Smhr_Grievance))
                    {

                        BLL.ShowMessage(this, "Record Complaint Saved Successfully");
                    }
                    else
                        BLL.ShowMessage(this, "Record Complaint Not Saved");
                    break;
                default:
                    break;
            }
            Rm_CY_page.SelectedIndex = 0;
            Rg_RecordIncident.DataSource = LoadIncidentGrid();

            Rg_RecordIncident.DataBind();
            ViewState["GRIEVANCE_ID"] = null;
            Rm_CY_page.SelectedIndex = 0;

            // Response.Redirect("RecordIncident.aspx");
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "RecordIncident", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearControls();
            Rm_CY_page.SelectedIndex = 0;
            Rg_RecordIncident.DataSource = LoadIncidentGrid();
            Rg_RecordIncident.DataBind();
            ViewState["GRIEVANCE_ID"] = null;
            comlainton_empid.Text = string.Empty;
            DataTable dtMember = new DataTable();
            dtMember.Columns.Add("COMMITTEEMEMBERID");
            dtMember.Columns.Add("COMMITTEEMEMBER");
            dtMember.Columns.Add("POSITIONS_CODE");

            rg_OtherMembers.DataSource = null;
            rg_OtherMembers.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "RecordIncident", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            clearControls();
            SMHR_GLOBALCONFIG _obj_smhr_globalconfig = new SMHR_GLOBALCONFIG();
            _obj_smhr_globalconfig.OPERATION = operation.Select;
            _obj_smhr_globalconfig.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_ConfigDetails(_obj_smhr_globalconfig);

            if (dt.Rows.Count > 0)
            {
                if (Convert.ToString(dt.Rows[0]["GLOBALCONFIG_INCIDENT_PREFIX"]) == string.Empty || Convert.ToString(dt.Rows[0]["GLOBALCONFIG_INCIDENT_ID"]) == string.Empty)
                {
                    BLL.ShowMessage(this, "Please Select Incident & Disciplinary Prefixs in Global Configuration");
                    return;
                }
                else
                {

                    rtxt_IncidentID.Text = dt.Rows[0]["GLOBALCONFIG_INCIDENT_PREFIX"].ToString() + (Convert.ToInt32(dt.Rows[0]["GLOBALCONFIG_INCIDENT_ID"].ToString()) + 1).ToString();
                }
            }

            LoadCommittee();
            btn_Save.Visible = true;
            btn_Update.Visible = false;
            Rm_CY_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "RecordIncident", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadCommittee()
    {
        try
        {
            SMHR_MAIN _obj_smhr_Main = new SMHR_MAIN();
            _obj_smhr_Main.OPERATION = operation.COMMITTEE;
            _obj_smhr_Main.ORGANISATION_ID = OrganizationID;
            rcmb_Committee.DataTextField = "COMMITTEE_CODE";
            rcmb_Committee.DataValueField = "COMMITTEE_ID";
            rcmb_Committee.DataSource = BLL.get_GrievanceDisciplinaryMasters(_obj_smhr_Main);
            rcmb_Committee.DataBind();
            rcmb_Committee.Items.Insert(0, new RadComboBoxItem { Value = "0", Text = "Select" });
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "RecordIncident", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void clearControls()
    {
        try
        {
            rtxt_ReportedByBU.Text = string.Empty;
            rtxt_ReportedByDepartment.Text = string.Empty;
            rtxt_ReportedByDirectorate.Text = string.Empty;
            //rtxt_ReportedByEmpName.Text = string.Empty;
            rtxt_ReportedByEmpPosition.Text = string.Empty;
            HIDN_COMETID.Value = string.Empty;
            rtxt_ReportedOnBU.Text = string.Empty;
            rtxt_ReportedOnDepartment.Text = string.Empty;
            rtxt_ReportedOnDirectorate.Text = string.Empty;
            //rtxt_ReportedOnEmpName.Text = string.Empty;
            rtxt_ReportedOnEmpPosition.Text = string.Empty;
            Rm_CY_page.SelectedIndex = 0;
            rtxt_ActionIncidentID.Text = "";
            rtxt_ActionIncident.Text = "";
            rtxt_ActionIncidentType.Text = "";
            rtxt_ActionReportedDate.Text = "";
            rtxt_ActionCommittee.Text = "";
            rcmb_DisciplinaryGrievanceAction.SelectedIndex = 0;
            rtxt_IncidentID.Text = string.Empty;
            rtxt_Description.Text = string.Empty;
            rcmb_ReportedByEmployee.Items.Clear();
            rcmb_ReportedByEmployee.Text = string.Empty;
            rcmb_ReportedOnEmployee.Items.Clear();
            rcmb_ReportedOnEmployee.Text = string.Empty;
            rcmb_Incident.SelectedIndex = -1;
            rcmb_IncidentType.Items.Clear();
            rdp_ReportedDate.SelectedDate = null;
            rcmb_Committee.Items.Clear();

            rcmb_ReportedByEmployee.Enabled = true;
            rcmb_ReportedOnEmployee.Enabled = true;
            rcmb_Incident.Enabled = true;
            rcmb_IncidentType.Enabled = true;
            rdp_ReportedDate.Enabled = true;
            rcmb_Committee.Enabled = true;
            Rm_CY_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "RecordIncident", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            clearControls();

            LinkButton lnkTemp = sender as LinkButton;
            GridDataItem item = lnkTemp.NamingContainer as GridDataItem;
            ViewState["GRIEVANCE_ID"] = item["GRIEVANCE_ID"].Text;

            rtxt_IncidentID.Text = item["GRIEVANCE_INCIDENTID"].Text;

            rcmb_ReportedByEmployee.SelectedValue = item["GRIEVANCE_REPORTEDBY"].Text;
            rcmb_ReportedByEmployee.Text = item["GRIEVANCE_REPORTEDBYNAME"].Text;
            rcmb_ReportedByEmployee_SelectedIndexChanged(null, null);

            rcmb_ReportedByEmployee.Enabled = false;

            rcmb_ReportedOnEmployee.SelectedValue = item["GRIEVANCE_REPORTEDON"].Text;
            rcmb_ReportedOnEmployee.Text = item["GRIEVANCE_REPORTEDONNAME"].Text;
            rcmb_ReportedOnEmployee_SelectedIndexChanged(null, null);

            rcmb_ReportedOnEmployee.Enabled = false;

            rcmb_Incident.FindItemByText(item["GRIEVANCE_INCIDENT"].Text).Selected = true;
            rcmb_Incident.Enabled = false;

            rcmb_Incident_SelectedIndexChanged(null, null);

            rcmb_IncidentType.FindItemByText(item["GRIEVANCE_INCIDENTTYPE"].Text).Selected = true;
            rcmb_IncidentType.Enabled = false;
            btn_Save.Visible = false;
            CultureInfo newCulture = (CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            newCulture.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";

            Thread.CurrentThread.CurrentCulture = newCulture;
            DateTime dt1 = DateTime.ParseExact(item["GRIEVANCE_REPORTEDDATE"].Text, "dd/MM/yyyy", null);

            rdp_ReportedDate.SelectedDate = dt1;

            rdp_ReportedDate.Enabled = false;

            rtxt_Description.Text = item["GRIEVANCE_INCIDENTDESCRIPTION"].Text;

            LoadCommittee();
            rcmb_Committee.SelectedValue = item["GRIEVANCE_COMMITTEEID"].Text;
            rcmb_Committee.Enabled = false;

            Rm_CY_page.SelectedIndex = 1;

            //code for security
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Update.Visible = false;
            }
            else
            {
                btn_Update.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "RecordIncident", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    [WebMethod]
    public static RadComboBoxItemData[] GET_EmployeeBySearchString(object context)
    {
        IDictionary<string, object> contextDictionary = (IDictionary<string, object>)context;

        string filterString = ((string)contextDictionary["FilterString"]).Length > 2 ? ((string)contextDictionary["FilterString"]).ToLower() : "";

        DataTable dtEMPData = BLL.get_EmployeeBySearchString(OrganizationID, filterString);

        List<RadComboBoxItemData> result = new List<RadComboBoxItemData>(dtEMPData.Rows.Count);
        foreach (DataRow row in dtEMPData.Rows)
        {
            RadComboBoxItemData itemData = new RadComboBoxItemData();
            itemData.Text = row["EMPNAME"].ToString();
            itemData.Value = row["EMP_ID"].ToString();
            result.Add(itemData);
        }
        return result.ToArray();
    }
    // [WebMethod]
    //public static RadComboBoxItemData[] GET_EmployeeBySearchString(object context)
    //{
    //    IDictionary<string, object> contextDictionary = (IDictionary<string, object>)context;

    //    string filterString = ((string)contextDictionary["FilterString"]).Length > 2 ? ((string)contextDictionary["FilterString"]).ToLower() : "";

    //    DataTable dtEMPData = BLL.get_EmployeeBySearchString(OrganizationID, filterString);

    //    List<RadComboBoxItemData> result = new List<RadComboBoxItemData>(dtEMPData.Rows.Count);
    //    foreach (DataRow row in dtEMPData.Rows)
    //    {
    //        RadComboBoxItemData itemData = new RadComboBoxItemData();
    //        itemData.Text = row["EMPNAME"].ToString();
    //        itemData.Value = row["EMP_ID"].ToString();
    //        result.Add(itemData);
    //    }
    //    return result.ToArray();
    //}

    protected void rcmb_DisciplinaryGrievanceAction_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_DisciplinaryGrievanceAction.SelectedItem.Text.ToUpper() == "SUSPEND")
            {
                susdfd.Visible = true;
                susdtd.Visible = true;
            }
            else
            {
                susdfd.Visible = false;
                susdtd.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "RecordIncident", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_ReportedByEmployee_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_ReportedByEmployee.SelectedValue != string.Empty)
            {
                SMHR_EMPLOYEE _obj_Smhr_Employee = new SMHR_EMPLOYEE();
                _obj_Smhr_Employee.ORGANISATION_ID = OrganizationID;
                _obj_Smhr_Employee.EMP_ID = Convert.ToInt32(rcmb_ReportedByEmployee.SelectedValue);

                DataTable dtData = BLL.get_GrievanceEmployee(_obj_Smhr_Employee);

                if (dtData.Rows.Count <= 0)
                {
                    BLL.ShowMessage(this, "Please Select Reported By correctly");
                    return;
                }
                //rtxt_ReportedByEmpName.Text = dtData.Rows[0]["EMPNAME"].ToString();
                rtxt_ReportedByEmpPosition.Text = dtData.Rows[0]["POSITIONS_CODE"].ToString();
                rtxt_ReportedByDirectorate.Text = dtData.Rows[0]["DIRECTORATE_CODE"].ToString();
                rtxt_ReportedByDepartment.Text = dtData.Rows[0]["DEPARTMENT_CODE"].ToString();
                rtxt_ReportedByBU.Text = dtData.Rows[0]["BUSINESSUNIT_CODE"].ToString();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "RecordIncident", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_ReportedOnEmployee_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_ReportedOnEmployee.SelectedValue != string.Empty)
            {
                SMHR_EMPLOYEE _obj_Smhr_Employee = new SMHR_EMPLOYEE();
                _obj_Smhr_Employee.ORGANISATION_ID = OrganizationID;
                _obj_Smhr_Employee.EMP_ID = Convert.ToInt32(rcmb_ReportedOnEmployee.SelectedValue);

                DataTable dtData = BLL.get_GrievanceEmployee(_obj_Smhr_Employee);
                if (dtData.Rows.Count <= 0)
                {
                    BLL.ShowMessage(this, "Please Select Reported On correctly");
                    return;
                }
                if (dtData.Rows[0]["EMPNAME"].ToString() == string.Empty)
                {
                    BLL.ShowMessage(this, "Please Select Reported On correctly");
                    return;
                }
                //else
                //    rtxt_ReportedOnEmpName.Text = dtData.Rows[0]["EMPNAME"].ToString();
                rtxt_ReportedOnEmpPosition.Text = dtData.Rows[0]["POSITIONS_CODE"].ToString();
                rtxt_ReportedOnDirectorate.Text = dtData.Rows[0]["DIRECTORATE_CODE"].ToString();
                rtxt_ReportedOnDepartment.Text = dtData.Rows[0]["DEPARTMENT_CODE"].ToString();
                rtxt_ReportedOnBU.Text = dtData.Rows[0]["BUSINESSUNIT_CODE"].ToString();
                rtxt_ReportingManager.Text = dtData.Rows[0]["REPORTINGMANAGER"].ToString();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "RecordIncident", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_Incident_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Incident.SelectedIndex > 0)
            {
                rcmb_IncidentType.Items.Clear();
                if (rcmb_Incident.SelectedItem.Text == "Grievance")
                {
                    SMHR_MAIN _obj_smhr_Main = new SMHR_MAIN();
                    _obj_smhr_Main.OPERATION = operation.GRIEVANCETYPE;
                    _obj_smhr_Main.ORGANISATION_ID = OrganizationID;
                    rcmb_IncidentType.DataTextField = "HR_MASTER_CODE";
                    rcmb_IncidentType.DataValueField = "HR_MASTER_ID";
                    rcmb_IncidentType.DataSource = BLL.get_GrievanceDisciplinaryMasters(_obj_smhr_Main);
                    rcmb_IncidentType.DataBind();
                    rcmb_IncidentType.Items.Insert(0, new RadComboBoxItem { Value = "0", Text = "Select" });
                }
                else if (rcmb_Incident.SelectedItem.Text == "Discipline")
                {
                    SMHR_MAIN _obj_smhr_Main = new SMHR_MAIN();
                    _obj_smhr_Main.OPERATION = operation.DISCIPLINARYTYPE;
                    _obj_smhr_Main.ORGANISATION_ID = OrganizationID;
                    rcmb_IncidentType.DataTextField = "HR_MASTER_CODE";
                    rcmb_IncidentType.DataValueField = "HR_MASTER_ID";
                    rcmb_IncidentType.DataSource = BLL.get_GrievanceDisciplinaryMasters(_obj_smhr_Main);
                    rcmb_IncidentType.DataBind();
                    rcmb_IncidentType.Items.Insert(0, new RadComboBoxItem { Value = "0", Text = "Select" });
                }

            }
            else
            {
                rcmb_IncidentType.Items.Clear();
                rcmb_IncidentType.Items.Insert(0, new RadComboBoxItem { Value = "0", Text = "Select" });
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "RecordIncident", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_TakeAction_Command(object sender, CommandEventArgs e)
    {
        try
        {
            CheckBox chk = new CheckBox();
            CheckBox chk1 = new CheckBox();
            Rm_CY_page.SelectedIndex = 0;
            rdp_ActionDate.Clear();
            rdp_DiscussionDate.Clear();
            rdp_SuspendedTo.Clear();
            rdp_SuspendedFrom.Clear();
            Txt_reason.Text = string.Empty;
            btn_TakeAction.Visible = true;
            rdp_ActionDate.Enabled = true;
            rdp_DiscussionDate.Enabled = true;
            rdp_SuspendedTo.Enabled = true;
            HIDN_COMETID.Value = string.Empty;
            rdp_SuspendedFrom.Enabled = true;
            Txt_reason.Enabled = true;
            susdfd.Visible = false;
           
            Btn_letter.Visible = true;
            susdtd.Visible = false;
            rg_CommitteeMembers.Enabled = true;
            //rg_OtherMembers.Enabled = true;
            //rg_OtherMembers.DataSource = new DataTable();
            //rg_OtherMembers.DataBind();
            lnk_AddOtherMembers.Enabled = true;
            rcmb_OtherMembers.Enabled = true;
            rcmb_DisciplinaryGrievanceAction.SelectedIndex = -1;

            SMHR_ACTIONTAKEN _OBJ_SMHR_ACTIONTAKEN = new SMHR_ACTIONTAKEN();
            LinkButton lnkTakeAction = sender as LinkButton;
            Session.Remove("GREVE_ID");
            Session["GREVE_ID"] = Convert.ToString(e.CommandArgument);
            GridDataItem item = lnkTakeAction.NamingContainer as GridDataItem;
            rtxt_ActionIncidentID.Text = item["GRIEVANCE_INCIDENTID"].Text;
            rtxt_ActionIncident.Text = item["GRIEVANCE_INCIDENT"].Text;
            rtxt_ActionIncidentType.Text = item["GRIEVANCE_INCIDENTTYPE"].Text;
            rtxt_ActionReportedDate.Text = item["GRIEVANCE_REPORTEDDATE"].Text;
            rtxt_ActionCommittee.Text = item["COMMITTEE_CODE"].Text;
            rtxt_cmplantby.Text = item["GRIEVANCE_REPORTEDBYNAME"].Text;
            rtxt_cmplainton.Text = item["GRIEVANCE_REPORTEDONNAME"].Text;
            comlainton_empid.Text = item["GRIEVANCE_REPORTEDON"].Text;


            LoadActionDropDowns();

            LoadActionCommittee(Convert.ToInt32(item["GRIEVANCE_COMMITTEEID"].Text));
            rg_CommitteeMembers.DataBind();
            HIDN_COMETID.Value = item["GRIEVANCE_COMMITTEEID"].Text;
            _OBJ_SMHR_ACTIONTAKEN.ACTION_GRIVENCE_ID = Convert.ToInt32(e.CommandArgument);
            _OBJ_SMHR_ACTIONTAKEN.OPERATION = operation.Edit;
            DataTable dt_edit = BLL.get_SMHR_ACTIONTAKEN(_OBJ_SMHR_ACTIONTAKEN);
            if (dt_edit.Rows.Count > 0)
            {
                Btn_updatetakeactin.Visible = true;
                rcmb_DisciplinaryGrievanceAction.Enabled = false;
                btn_TakeAction.Visible = false;
                rdp_ActionDate.Enabled = false;
                rdp_DiscussionDate.Enabled = false;
                Txt_reason.Enabled = false;
                rdp_SuspendedTo.Enabled = false;
                rdp_SuspendedFrom.Enabled = false;
                rg_CommitteeMembers.Enabled = false;
                lnk_AddOtherMembers.Enabled = false;
                rcmb_OtherMembers.Enabled = false;
                rg_OtherMembers.Enabled = false;
                rcmb_DisciplinaryGrievanceAction.SelectedIndex = rcmb_DisciplinaryGrievanceAction.FindItemIndexByValue((dt_edit.Rows[0]["ACTION_DISPORGRIV_ID"]).ToString());
                if ((rcmb_DisciplinaryGrievanceAction.SelectedItem.Text.ToUpper() == "SUSPEND"))
                {
                    susdfd.Visible = true;
                    susdtd.Visible = true;
                    //   Btn_letter.Visible = true;
                    if (Convert.ToString(dt_edit.Rows[0]["ACTION_SUSPDFROMDATE"]) != string.Empty)
                        rdp_SuspendedFrom.SelectedDate = Convert.ToDateTime(dt_edit.Rows[0]["ACTION_SUSPDFROMDATE"]);
                    if (Convert.ToString(dt_edit.Rows[0]["ACTION_SUSPDTODATE"]) != string.Empty)
                        rdp_SuspendedTo.SelectedDate = Convert.ToDateTime(dt_edit.Rows[0]["ACTION_SUSPDTODATE"]);
                }
                else
                {
                    susdfd.Visible = false;
                    susdtd.Visible = false;
                    // Btn_letter.Visible = false;
                }
                if ((rcmb_DisciplinaryGrievanceAction.SelectedItem.Text.ToUpper() == "SUSPEND") || (rcmb_DisciplinaryGrievanceAction.SelectedItem.Text.ToUpper() == "TERMINATE"))
                {
                    Btn_letter.Visible = true;
                }
                else
                {
                    Btn_letter.Visible = false;
                }
                rdp_ActionDate.SelectedDate = Convert.ToDateTime(dt_edit.Rows[0]["ACTION_DATE"]);
                rdp_DiscussionDate.SelectedDate = Convert.ToDateTime(dt_edit.Rows[0]["ACTION_DISCUSSEDDATE"]);
                Txt_reason.Text = Convert.ToString(dt_edit.Rows[0]["ACTION_REASON"]);

                // Lnk_Download.Text = Convert.ToString(dt_edit.Rows[0]["ACTION_COURT_ATTACHMENT"]);
                if (Convert.ToString(dt_edit.Rows[0]["ACTION_COURT_ATTACHMENT"]) != string.Empty)
                    D1.Visible = true;
                else
                    D1.Visible = false;

                D1.HRef = "~/Attachments/" + Convert.ToString(dt_edit.Rows[0]["ACTION_COURT_ATTACHMENT"]);
                _OBJ_SMHR_ACTIONTAKEN.OPERATION = operation.Delete1;
                DataTable dt_cmtimem = BLL.get_SMHR_ACTIONTAKEN(_OBJ_SMHR_ACTIONTAKEN);

                _OBJ_SMHR_ACTIONTAKEN.OPERATION = operation.Delete;
                DataTable dt_othmem = BLL.get_SMHR_ACTIONTAKEN(_OBJ_SMHR_ACTIONTAKEN);
                rg_OtherMembers.DataSource = dt_othmem;
                rg_OtherMembers.DataBind();
                for (int index = 0; index < dt_cmtimem.Rows.Count; index++)
                {
                    for (int j = 0; j < rg_CommitteeMembers.Items.Count; j++)
                    {
                        chk = rg_CommitteeMembers.Items[index].FindControl("chkSelect") as CheckBox;
                        GridDataItem itemcm = (GridDataItem)rg_CommitteeMembers.MasterTableView.Items[j];
                        if (Convert.ToInt32(dt_cmtimem.Rows[index]["COMMITTEEMEMBERID"]) == Convert.ToInt32(itemcm["COMMITTEEMEMBERID"].Text))
                        {
                            chk.Checked = true;
                        }
                    }

                }
            }
            else
            {
                D1.Visible = false;
                Btn_updatetakeactin.Visible = false;
                btn_TakeAction.Visible = true;
                rg_OtherMembers.DataSource = new DataTable();
                rg_OtherMembers.DataBind();
                rg_OtherMembers.Enabled = true;
                rcmb_DisciplinaryGrievanceAction.Enabled = true;
                rg_CommitteeMembers.Enabled = true;
            }
            Rm_CY_page.SelectedIndex = 2;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "RecordIncident", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void gridMembersList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            var id = Int32.Parse(e.CommandArgument.ToString());
            //  rg_OtherMembers.DeleteRow(id);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "RecordIncident", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void btn_TakeAction_Click(object sender, EventArgs e)
    {
        try
        {
            string filename = string.Empty;
            if (upload_CourtRuling.HasFile)
            {


                filename = Convert.ToString(DateTime.Now) + "_" + (upload_CourtRuling.FileName).Replace(" ", "_");

                filename = filename.Replace("/", "").Replace(":", "");
                string path = MapPath(filename);
                string name = Path.GetFileName(path);
                string ext = Path.GetExtension(filename);
                if (System.IO.Directory.Exists(Server.MapPath("~/Attachments/")) == false)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath("~/Attachments/"));
                }
                upload_CourtRuling.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Attachments/"), filename));

            }
            SMHR_ACTIONTAKEN _OBJ_SMHR_ACTIONTAKEN = new SMHR_ACTIONTAKEN();
            _OBJ_SMHR_ACTIONTAKEN.ACTION_COURT_ATTACHMENT = filename;
            _OBJ_SMHR_ACTIONTAKEN.ACTION_DISPORGRIV_ID = Convert.ToInt32(rcmb_DisciplinaryGrievanceAction.SelectedItem.Value);
            _OBJ_SMHR_ACTIONTAKEN.ACTION_DATE = Convert.ToDateTime(rdp_ActionDate.SelectedDate);
            if (rdp_SuspendedFrom.Visible == true)
            {
                _OBJ_SMHR_ACTIONTAKEN.ACTION_SUSPDFROMDATE = Convert.ToDateTime(rdp_SuspendedFrom.SelectedDate);
                _OBJ_SMHR_ACTIONTAKEN.ACTION_SUSPDTODATE = Convert.ToDateTime(rdp_SuspendedTo.SelectedDate);
            }
            else
            {
                //_OBJ_SMHR_ACTIONTAKEN.ACTION_SUSPDFROMDATE = null;
                //_OBJ_SMHR_ACTIONTAKEN.ACTION_SUSPDTODATE = null;
            }
            _OBJ_SMHR_ACTIONTAKEN.ACTION_DISCUSSEDDATE = Convert.ToDateTime(rdp_DiscussionDate.SelectedDate);
            _OBJ_SMHR_ACTIONTAKEN.ACTION_GRIVENCE_ID = Convert.ToInt32(Session["GREVE_ID"]);
            _OBJ_SMHR_ACTIONTAKEN.ACTION_CREATED_DATE = DateTime.Now;
            _OBJ_SMHR_ACTIONTAKEN.ACTION_LASTMODIFIEDDATE = DateTime.Now;
            _OBJ_SMHR_ACTIONTAKEN.ACTION_LASTMODIFIED_BY = Convert.ToInt32(Session["USER_ID"]);
            _OBJ_SMHR_ACTIONTAKEN.ACTION_CREATED_BY = Convert.ToInt32(Session["USER_ID"]);
            _OBJ_SMHR_ACTIONTAKEN.ACTION_REASON = Txt_reason.Text;

            CheckBox chk = new CheckBox();
            string strEMPIDs = string.Empty;
            string strotherIDs = string.Empty;

            int count = 0;
            for (int index = 0; index < rg_CommitteeMembers.Items.Count; index++)
            {
                chk = rg_CommitteeMembers.Items[index].FindControl("chkSelect") as CheckBox;
                if (chk.Checked)
                {
                    GridDataItem item = (GridDataItem)rg_CommitteeMembers.MasterTableView.Items[index];
                    strEMPIDs += item["COMMITTEEMEMBERID"].Text + ",";
                }
            }
            if (strEMPIDs == string.Empty)
            {
                BLL.ShowMessage(this, "Please Select Committee Members");
                return;
            }
            _OBJ_SMHR_ACTIONTAKEN.ACTION_DISCUSSEDWITH = strEMPIDs;
            //_OBJ_SMHR_ACTIONTAKEN.ACTION_CREATED_BY= rg_OtherMembers
            if (rg_OtherMembers.Items.Count > 0)
            {
                for (int index = 0; index < rg_OtherMembers.Items.Count; index++)
                {
                    GridDataItem item = (GridDataItem)rg_OtherMembers.MasterTableView.Items[index];
                    strotherIDs += item["COMMITTEEMEMBERID"].Text + ",";
                }
            }
            _OBJ_SMHR_ACTIONTAKEN.ACTION_OTHERMEMBERS = strotherIDs;
            _OBJ_SMHR_ACTIONTAKEN.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_TAKEACTION":
                    _OBJ_SMHR_ACTIONTAKEN.OPERATION = operation.Insert;
                    if (BLL.set_SMHR_ACTIONTAKEN(_OBJ_SMHR_ACTIONTAKEN))
                    {

                        if ((rdp_SuspendedFrom.Visible == true) || (Convert.ToString(rcmb_DisciplinaryGrievanceAction.SelectedItem.Text).ToUpper() == "TERMINATE"))
                        {

                            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToInt32(comlainton_empid.Text) + "','" + Convert.ToString(Session["GREVE_ID"]) + "');", true);
                            BLL.ShowMessage(this, "Information Saved Successfully");
                            Rm_CY_page.SelectedIndex = 0;

                        }

                        else
                        {
                            BLL.ShowMessage(this, "Information Saved Successfully");
                            Rm_CY_page.SelectedIndex = 0;
                        }

                    }
                    break;
                case "BTN_UPDATETAKEACTIN":

                    _OBJ_SMHR_ACTIONTAKEN.OPERATION = operation.Update;
                    if (BLL.set_SMHR_ACTIONTAKEN(_OBJ_SMHR_ACTIONTAKEN))
                    {
                        BLL.ShowMessage(this, "Information Updated Successfully");
                        Rm_CY_page.SelectedIndex = 0;

                    }
                    break;
            }


            Rm_CY_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "RecordIncident", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    private void LoadActionDropDowns()
    {
        try
        {
            rcmb_DisciplinaryGrievanceAction.Items.Clear();
            if (rtxt_ActionIncident.Text == "Grievance")
            {
                SMHR_MAIN _obj_smhr_Main = new SMHR_MAIN();
                _obj_smhr_Main.OPERATION = operation.GRIEVANCEACTION;
                _obj_smhr_Main.ORGANISATION_ID = OrganizationID;
                rcmb_DisciplinaryGrievanceAction.DataTextField = "HR_MASTER_CODE";
                rcmb_DisciplinaryGrievanceAction.DataValueField = "HR_MASTER_ID";
                rcmb_DisciplinaryGrievanceAction.DataSource = BLL.get_GrievanceDisciplinaryMasters(_obj_smhr_Main);
                rcmb_DisciplinaryGrievanceAction.DataBind();
                rcmb_DisciplinaryGrievanceAction.Items.Insert(0, new RadComboBoxItem { Value = "0", Text = "Select" });
            }
            else if (rtxt_ActionIncident.Text == "Discipline")
            {
                SMHR_MAIN _obj_smhr_Main = new SMHR_MAIN();
                _obj_smhr_Main.OPERATION = operation.DISCIPLINARYACTION;
                _obj_smhr_Main.ORGANISATION_ID = OrganizationID;
                rcmb_DisciplinaryGrievanceAction.DataTextField = "HR_MASTER_CODE";
                rcmb_DisciplinaryGrievanceAction.DataValueField = "HR_MASTER_ID";
                rcmb_DisciplinaryGrievanceAction.DataSource = BLL.get_GrievanceDisciplinaryMasters(_obj_smhr_Main);
                rcmb_DisciplinaryGrievanceAction.DataBind();
                rcmb_DisciplinaryGrievanceAction.Items.Insert(0, new RadComboBoxItem { Value = "0", Text = "Select" });
            }
            else
            {
                rcmb_DisciplinaryGrievanceAction.Items.Clear();
                rcmb_DisciplinaryGrievanceAction.Items.Insert(0, new RadComboBoxItem { Value = "0", Text = "Select" });
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "RecordIncident", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadActionCommittee(int COMMITTEEID)
    {
        try
        {
            SMHR_MAIN _obj_smhr_Main = new SMHR_MAIN();
            _obj_smhr_Main.OPERATION = operation.COMMITTEE;
            _obj_smhr_Main.ORGANISATION_ID = OrganizationID;
            _obj_smhr_Main.COMMITTEE_ID = COMMITTEEID;
            rg_CommitteeMembers.DataSource = BLL.get_GrievanceDisciplinaryMasters(_obj_smhr_Main);
            //  rg_CommitteeMembers.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "RecordIncident", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rg_CommitteeMembers_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            //rg_CommitteeMembers.DataSource = new DataTable();LoadCommittee()
            if (Convert.ToString(HIDN_COMETID.Value) != string.Empty)
            {
                LoadActionCommittee(Convert.ToInt32(HIDN_COMETID.Value));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "RecordIncident", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rg_OtherMembers_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        //rg_OtherMembers.DataSource = new DataTable();
    }
    protected void lnkDelete_Click(object sender, EventArgs e)
    {

    }

    protected void btn_ActionCancel_Click(object sender, EventArgs e)
    {
        try
        {
            Rm_CY_page.SelectedIndex = 0;

            rdp_ActionDate.Clear();
            rdp_DiscussionDate.Clear();
            rdp_SuspendedTo.Clear();
            rdp_SuspendedFrom.Clear();
            rcmb_DisciplinaryGrievanceAction.SelectedIndex = 0;
            // rg_CommitteeMembers.Enabled = false;
            //rg_OtherMembers.Enabled = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "RecordIncident", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_AddOtherMembers_Click(object sender, EventArgs e)
    {
        try
        {
            if (rcmb_OtherMembers.SelectedValue == string.Empty)
            {
                BLL.ShowMessage(this, "Please Select Other Member");
                return;
            }
            DataTable dtMember = new DataTable();
            dtMember.Columns.Add("COMMITTEEMEMBERID");
            dtMember.Columns.Add("COMMITTEEMEMBER");
            dtMember.Columns.Add("POSITIONS_CODE");


            foreach (GridDataItem item in rg_OtherMembers.Items)
            {
                if (item["COMMITTEEMEMBERID"].Text == "&nbsp;")
                {
                    item.Dispose();
                }
                if (item["COMMITTEEMEMBERID"].Text != "&nbsp;")
                {
                    if (rcmb_OtherMembers.SelectedValue != item["COMMITTEEMEMBERID"].Text)
                        dtMember.Rows.Add(item["COMMITTEEMEMBERID"].Text, item["COMMITTEEMEMBER"].Text, item["POSITIONS_CODE"].Text);
                    else
                    {
                        BLL.ShowMessage(this, "Member Already Added");
                        return;
                    }
                }
            }
            if (Convert.ToString(rcmb_OtherMembers.SelectedValue) != string.Empty)
            {

                SMHR_ACTIONTAKEN _obj = new SMHR_ACTIONTAKEN();
                _obj.OPERATION = operation.Check;
                _obj.ACTION_CREATED_BY = Convert.ToInt32(rcmb_OtherMembers.SelectedValue);
                DataTable dt = BLL.get_SMHR_ACTIONTAKEN(_obj);


                dtMember.Rows.Add(rcmb_OtherMembers.SelectedValue, rcmb_OtherMembers.Text, Convert.ToString(dt.Rows[0]["POSITIONS_CODE"]));
            }

            rg_OtherMembers.DataSource = dtMember;
            rg_OtherMembers.DataBind();
            rcmb_OtherMembers.SelectedValue = string.Empty;
            rcmb_OtherMembers.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "RecordIncident", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

}


