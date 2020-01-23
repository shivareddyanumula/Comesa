using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Workman_Compensation_frm_AddIncidentsToEmp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Employee Incidents");
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
                    RG_Incident.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btnAddRemarks.Visible = false;
                    //btn_Update.Visible = false;
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
                LoadGrid(); //To populate grid
                RG_Incident.DataBind();
                //LoadIncident_Injury(); //To populate radcomboboxes - RD_cmbIncident, RD_cmbInjuryType, RD_cmbInjuryCause
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AddIncidentsToEmp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadIncident_Injury()
    {
        try
        {
            //To populate radcomboboxes - RD_cmbIncident, RD_cmbInjuryType, RD_cmbInjuryCause

            SMHR_WorkmanCompensation objWorkComp = new SMHR_WorkmanCompensation();
            objWorkComp.OPERATION = operation.Select;
            objWorkComp.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            DataSet dsInicidentInjury = new DataSet();
            dsInicidentInjury = BLL.GET_SMHR_INCIDENTS(objWorkComp);
            //To populate incidents from SMHR_INCIDENTS_MASTER table
            if (dsInicidentInjury.Tables.Count > 0)
            {
                if (dsInicidentInjury.Tables[0].Rows.Count > 0)
                {
                    RD_cmbIncident.DataSource = dsInicidentInjury.Tables[0];
                    RD_cmbIncident.DataTextField = "INCIDENT_NAME";
                    RD_cmbIncident.DataValueField = "INCIDENT_ID";
                    RD_cmbIncident.DataBind();
                    RD_cmbIncident.Items.Insert(0, new RadComboBoxItem("Select"));
                }
                else
                {
                    RD_cmbIncident.Items.Clear();
                }
                //To populate Injury_Cause from SMHR_HR_MASTER table
                if (dsInicidentInjury.Tables[1].Rows.Count > 0)
                {
                    RD_cmbInjuryCause.DataSource = dsInicidentInjury.Tables[1];
                    RD_cmbInjuryCause.DataTextField = "HR_MASTER_CODE";
                    RD_cmbInjuryCause.DataValueField = "HR_MASTER_ID";
                    RD_cmbInjuryCause.DataBind();
                    RD_cmbInjuryCause.Items.Insert(0, new RadComboBoxItem("Select"));
                }
                else
                {
                    RD_cmbInjuryCause.Items.Clear();
                }
                //To populate Injury_Type from SMHR_HR_MASTER table
                if (dsInicidentInjury.Tables[2].Rows.Count > 0)
                {
                    RD_cmbInjuryType.DataSource = dsInicidentInjury.Tables[2];
                    RD_cmbInjuryType.DataTextField = "HR_MASTER_CODE";
                    RD_cmbInjuryType.DataValueField = "HR_MASTER_ID";
                    RD_cmbInjuryType.DataBind();
                    RD_cmbInjuryType.Items.Insert(0, new RadComboBoxItem("Select"));
                }
                else
                {
                    RD_cmbInjuryType.Items.Clear();
                }
                //To populate Severity from SMHR_HR_MASTER table
                if (dsInicidentInjury.Tables[3].Rows.Count > 0)
                {
                    RD_cmbSeverity.DataSource = dsInicidentInjury.Tables[3];
                    RD_cmbSeverity.DataTextField = "HR_MASTER_CODE";
                    RD_cmbSeverity.DataValueField = "HR_MASTER_ID";
                    RD_cmbSeverity.DataBind();
                    RD_cmbSeverity.Items.Insert(0, new RadComboBoxItem("Select"));
                }
                else
                {
                    RD_cmbSeverity.Items.Clear();
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AddIncidentsToEmp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadGrid()
    {
        //To populate incidents which are mapped with employees in radgrid - "RG_Incident"
        try
        {
            SMHR_WorkmanCompensation ObjWrkComp = new SMHR_WorkmanCompensation();
            ObjWrkComp.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            ObjWrkComp.OPERATION = operation.Get;
            RG_Incident.DataSource = BLL.GET_SMHR_INCIDENTS(ObjWrkComp).Tables[0];
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AddIncidentsToEmp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        //to save or edit Incidents to map with employees
        SMHR_WorkmanCompensation objWrkComp = new SMHR_WorkmanCompensation();
        try
        {
            switch (((Button)sender).ID.ToUpper())
            {
                case "BTNEDIT":

                    //objWrkComp.IncidentID = Convert.ToInt32(RD_cmbIncident.SelectedValue);
                    objWrkComp.IncidentID = Convert.ToInt32(lblIncidentID.Text);
                    objWrkComp.IncidentCauseID = Convert.ToInt32(RD_cmbInjuryCause.SelectedValue);
                    objWrkComp.InicidentTypeID = Convert.ToInt32(RD_cmbInjuryType.SelectedValue);
                    objWrkComp.SeverityID = Convert.ToInt32(RD_cmbSeverity.SelectedValue);
                    objWrkComp.DIRECTORATE_ID = 0;
                    objWrkComp.DEPARTMENT_ID = 0;

                    //To check if incident is already assigned to selected Employee
                    objWrkComp.OPERATION = operation.Check;
                    if (BLL.SET_SMHR_INCIDENTS(objWrkComp))
                    {
                        BLL.ShowMessage(this, "Incident is already assigned to the selected Employee");
                        return;
                    }

                    objWrkComp.OPERATION = operation.Update;
                    if (BLL.SET_SMHR_INCIDENTS(objWrkComp))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Updated");

                    ClearFields();
                    rm_MR_Page.SelectedIndex = 0;
                    LoadGrid();
                    RG_Incident.DataBind();
                    break;

                case "BTNSAVE":
                    //To validate BusinessUnit
                    if (BUFilter1.BusinessUnitID <= 0)
                    {
                        BLL.ShowMessage(this, "Please select Business Unit");
                        return;
                    }
                    else if (BUFilter1.EmployeeID <= 0)
                    {
                        BLL.ShowMessage(this, "Please select an Employee");
                        return;
                    }


                    objWrkComp.IncidentID = Convert.ToInt32(RD_cmbIncident.SelectedValue);
                    objWrkComp.EmpID = Convert.ToInt32(BUFilter1.EmployeeID);
                    objWrkComp.IncidentCauseID = Convert.ToInt32(RD_cmbInjuryCause.SelectedValue);
                    objWrkComp.InicidentTypeID = Convert.ToInt32(RD_cmbInjuryType.SelectedValue);
                    objWrkComp.SeverityID = Convert.ToInt32(RD_cmbSeverity.SelectedValue);
                    objWrkComp.Remarks = Convert.ToString(BLL.ReplaceQuote(RD_txtRemarks.Text));
                    objWrkComp.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                    objWrkComp.BUID = BUFilter1.BusinessUnitID;
                    objWrkComp.DIRECTORATE_ID = BUFilter1.DirectorateID;
                    objWrkComp.DEPARTMENT_ID = BUFilter1.DepartmentID;
                    objWrkComp.SUBDEPARTMENT_ID = 0;    //Add the sub-department

                    //To check if incident is already assigned to selected Employee
                    objWrkComp.OPERATION = operation.Check;
                    if (BLL.SET_SMHR_INCIDENTS(objWrkComp))
                    {
                        BLL.ShowMessage(this, "Incident is already assigned to the selected Employee");
                        return;
                    }

                    objWrkComp.OPERATION = operation.Insert;
                    if (BLL.SET_SMHR_INCIDENTS(objWrkComp))
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");

                    ClearFields();
                    rm_MR_Page.SelectedIndex = 0;
                    LoadGrid();
                    RG_Incident.DataBind();
                    break;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AddIncidentsToEmp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            ClearFields();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AddIncidentsToEmp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void RG_Incident_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AddIncidentsToEmp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_IncidentEdit_Command(object sender, CommandEventArgs e)
    {
        //To edit Incident details which are mapped with employee
        DataSet dsEmpIncidents = new DataSet();
        try
        {
            LoadIncident_Injury(); //To populate radcomboboxes - RD_cmbIncident, RD_cmbInjuryType, RD_cmbInjuryCause

            SMHR_WorkmanCompensation objWrkComp = new SMHR_WorkmanCompensation();
            objWrkComp.IncidentID = Convert.ToInt32(e.CommandArgument);
            objWrkComp.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            objWrkComp.OPERATION = operation.Edit;
            dsEmpIncidents = BLL.GET_SMHR_INCIDENTS(objWrkComp);  //FOR Employee incidents


            if (dsEmpIncidents.Tables[0].Rows.Count > 0)
            {
                //lblIncidentID.Text = Convert.ToString(dt.Rows[0]["INCIDENT_ID"]);
                //RD_txtIncidentCode.Text = Convert.ToString(dt.Rows[0]["INCIDENT_CODE"]);
                //RD_txtIncidentName.Text = Convert.ToString(dt.Rows[0]["INCIDENT_NAME"]);
                //RD_txtPlaceOfIncident.Text = Convert.ToString(dt.Rows[0]["PLACE_OF_INCIDENT"]);
                //RD_dtIncidentDtTime.SelectedDate = Convert.ToDateTime(dt.Rows[0]["INCIDENT_DATE"]);


                BUFilter1.BusinessUnitID = Convert.ToInt32(dsEmpIncidents.Tables[0].Rows[0]["INC_BUSINESSUNIT_ID"]);
                BUFilter1.DirectorateID = Convert.ToInt32(dsEmpIncidents.Tables[0].Rows[0]["INC_DIRECTORATE_ID"]);
                BUFilter1.DepartmentID = Convert.ToInt32(dsEmpIncidents.Tables[0].Rows[0]["INC_DEPARTMENT_ID"]);
                BUFilter1.EmployeeID = Convert.ToInt32(dsEmpIncidents.Tables[0].Rows[0]["INC_EMP_ID"]);
                BUFilter1.Visible = false;

                RD_cmbIncident.SelectedIndex = RD_cmbIncident.Items.IndexOf(RD_cmbIncident.Items.FindItemByValue(Convert.ToString(dsEmpIncidents.Tables[0].Rows[0]["INCIDENT_ID"])));
                RD_cmbIncident_SelectedIndexChanged(null, null);
                RD_cmbIncident.Enabled = false;
                RD_cmbInjuryCause.SelectedIndex = RD_cmbInjuryCause.Items.IndexOf(RD_cmbInjuryCause.Items.FindItemByValue(Convert.ToString(dsEmpIncidents.Tables[0].Rows[0]["INC_CAUSE_ID"])));
                RD_cmbInjuryType.SelectedIndex = RD_cmbInjuryType.Items.IndexOf(RD_cmbInjuryType.Items.FindItemByValue(Convert.ToString(dsEmpIncidents.Tables[0].Rows[0]["INC_TYPE_ID"])));

                RD_cmbSeverity.SelectedIndex = RD_cmbSeverity.Items.IndexOf(RD_cmbSeverity.Items.FindItemByValue(Convert.ToString(dsEmpIncidents.Tables[0].Rows[0]["INC_SEVERITY_ID"])));

                //RD_txtSeverity.Text = Convert.ToString(dsEmpIncidents.Tables[0].Rows[0]["SEVERITY"]);

                lblIncidentID.Text = Convert.ToString(dsEmpIncidents.Tables[0].Rows[0]["INC_ID"]);


                for (int i = 0; i <= dsEmpIncidents.Tables[1].Rows.Count - 1; i++)
                {
                    if (i == 0 && dsEmpIncidents.Tables[1].Rows[i]["REMARKS"] == "")
                    {
                        break;
                    }
                    RadTextBox txtAddedRemarks = new RadTextBox();
                    txtAddedRemarks.ID = "lblAddedRemarks" + (i + 1);
                    txtAddedRemarks.Text = Convert.ToString(dsEmpIncidents.Tables[1].Rows[i]["REMARKS"]);
                    txtAddedRemarks.TextMode = InputMode.MultiLine;
                    txtAddedRemarks.Enabled = false;
                    phRemarks.Controls.Add(txtAddedRemarks);
                    phRemarks.Controls.Add(new LiteralControl("<br />"));
                    continue;
                }
                btnAddRemarks.Visible = true;
            }
            else
            {
                BLL.ShowMessage(this, "No data found");
            }

            btnSave.Visible = false;
            //code for security
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btnEdit.Visible = false;
            }
            else
            {
                btnEdit.Visible = true;
            }
            rm_MR_Page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AddIncidentsToEmp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //private void DisplayFields(bool flag)
    //{
    //    BUFilter1.Visible = flag;
    //    lblDesignation.Visible = flag;
    //    RD_txtDesignation.Visible = flag;
    //    lblAge.Visible = flag;
    //    RD_txtAge.Visible = flag;
    //    lblSex.Visible = flag;
    //    RD_txtSex.Visible = flag;
    //    lblIncident.Visible = flag;
    //    RD_cmbIncident.Visible = flag;
    //    lblPlaceOfIncident.Visible = flag;
    //    RD_txtPlaceOfIncident.Visible = flag;
    //    lblDateTime.Visible = flag;
    //    RD_dtIncidentDtTime.Visible = flag;
    //    lblInjuryCause.Visible = flag;
    //    RD_cmbInjuryCause.Visible = flag;
    //    lblInjuryType.Visible = flag;
    //    RD_cmbInjuryType.Visible = flag;
    //    lblSeverity.Visible = flag;
    //    RD_txtSeverity.Visible = flag;
    //}

    protected void lnk_Add_Click(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
            ClearFields();
            RD_cmbIncident.Enabled = true;
            btnSave.Visible = true;
            BUFilter1.Visible = true;
            btnEdit.Visible = false;
            rm_MR_Page.SelectedIndex = 1;
            BUFilter1.ClearControls();

            BUFilter1.BusinessUnitID = 0;
            BUFilter1.DirectorateID = 0;
            BUFilter1.DepartmentID = 0;
            BUFilter1.EmployeeID = 0;
            //rad_IsActive.Checked = true;
            //rad_IsActive.Enabled = false;
            LoadIncident_Injury(); //To populate radcomboboxes - RD_cmbIncident, RD_cmbInjuryType, RD_cmbInjuryCause
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AddIncidentsToEmp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void ClearFields()
    {
        try
        {
            RD_txtEmployee.Text = string.Empty;
            RD_txtDesignation.Text = string.Empty;
            RD_txtAge.Text = string.Empty;
            RD_txtSex.Text = string.Empty;
            RD_cmbIncident.ClearSelection();
            RD_txtPlaceOfIncident.Text = string.Empty;
            RD_dtIncidentDtTime.SelectedDate = null;
            RD_cmbInjuryCause.ClearSelection();
            RD_cmbInjuryType.ClearSelection();
            //RD_txtSeverity.Text = string.Empty;
            RD_cmbSeverity.ClearSelection();
            RD_txtRemarks.Text = string.Empty;
            lblIncidentID.Text = string.Empty;

            btnAddRemarks.Visible = false;
            btnSave.Visible = false;
            btnEdit.Visible = false;
            rm_MR_Page.SelectedIndex = 0;
            ////rad_IsActive.Checked = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AddIncidentsToEmp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btnAddRemarks_Click(object sender, EventArgs e)
    {
        //To add remarks to the selected incident
        try
        {
            if (RD_txtRemarks.Text.Trim() == "")
            {
                BLL.ShowMessage(this, "Please Enter Remarks to Save");

                //To load remarks
                SMHR_WorkmanCompensation objWrkComp = new SMHR_WorkmanCompensation();
                objWrkComp.IncidentID = Convert.ToInt32(lblIncidentID.Text);
                objWrkComp.OPERATION = operation.Edit;
                DataTable dtIncidentRemarks = new DataTable();
                dtIncidentRemarks = BLL.GET_SMHR_INCIDENTS(objWrkComp).Tables[1];  //To fetch remarks for the selected Employee_Incident
                objWrkComp = null;
                if (dtIncidentRemarks.Rows.Count > 0)
                {
                    for (int i = 0; i <= dtIncidentRemarks.Rows.Count - 1; i++)
                    {
                        RadTextBox txtAddedRemarks = new RadTextBox();
                        txtAddedRemarks.ID = "lblAddedRemarks" + (i + 1);
                        txtAddedRemarks.Text = Convert.ToString(dtIncidentRemarks.Rows[i]["REMARKS"]);
                        txtAddedRemarks.TextMode = InputMode.MultiLine;
                        txtAddedRemarks.Enabled = false;
                        phRemarks.Controls.Add(txtAddedRemarks);
                        phRemarks.Controls.Add(new LiteralControl("<br />"));
                    }
                    btnAddRemarks.Visible = true;
                }
                return; //So that remarks doesn't insert
            }
            if (lblIncidentID.Text != string.Empty)
            {
                SMHR_WorkmanCompensation objWrkComp = new SMHR_WorkmanCompensation();
                objWrkComp.IncidentID = Convert.ToInt32(lblIncidentID.Text);
                objWrkComp.DIRECTORATE_ID = 0;
                objWrkComp.DEPARTMENT_ID = 0;
                objWrkComp.Remarks = Convert.ToString(BLL.ReplaceQuote(RD_txtRemarks.Text));
                objWrkComp.OPERATION = operation.Insert_New;   //To insert a new remark for the selected Incident
                if (BLL.SET_SMHR_INCIDENTS(objWrkComp))
                {
                    RD_txtRemarks.Text = string.Empty;
                    //To load remarks
                    //objWrkComp = null;
                    objWrkComp.IncidentID = Convert.ToInt32(lblIncidentID.Text);
                    objWrkComp.OPERATION = operation.Edit;
                    DataTable dtIncidentRemarks = new DataTable();
                    dtIncidentRemarks = BLL.GET_SMHR_INCIDENTS(objWrkComp).Tables[1];  //To fetch remarks for the selected Employee_Incident

                    if (dtIncidentRemarks.Rows.Count > 0)
                    {
                        for (int i = 0; i <= dtIncidentRemarks.Rows.Count - 1; i++)
                        {
                            RadTextBox txtAddedRemarks = new RadTextBox();
                            txtAddedRemarks.ID = "lblAddedRemarks" + (i + 1);
                            txtAddedRemarks.Text = Convert.ToString(dtIncidentRemarks.Rows[i]["REMARKS"]);
                            txtAddedRemarks.TextMode = InputMode.MultiLine;
                            txtAddedRemarks.Enabled = false;
                            phRemarks.Controls.Add(txtAddedRemarks);
                            phRemarks.Controls.Add(new LiteralControl("<br />"));
                        }
                        btnAddRemarks.Visible = true;
                    }
                }
                else
                    BLL.ShowMessage(this, "Remark Not Saved");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AddIncidentsToEmp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void RD_cmbIncident_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        //To populate incident master details based on the Incident selection
        try
        {
            if (RD_cmbIncident.SelectedValue != "")
            {
                SMHR_WorkmanCompensation objWorkComp = new SMHR_WorkmanCompensation();
                objWorkComp.IncidentID = Convert.ToInt32(RD_cmbIncident.SelectedValue);
                objWorkComp.OPERATION = operation.Get_ID;
                DataSet dsInicident = new DataSet();
                dsInicident = BLL.GET_SMHR_INCIDENTS(objWorkComp);
                if (dsInicident.Tables[0].Rows.Count > 0)
                {
                    RD_txtPlaceOfIncident.Text = Convert.ToString(dsInicident.Tables[0].Rows[0]["PLACE_OF_INCIDENT"]);
                    RD_dtIncidentDtTime.SelectedDate = Convert.ToDateTime(dsInicident.Tables[0].Rows[0]["INCIDENT_DATE"]);
                }
                else
                {
                    RD_txtPlaceOfIncident.Text = string.Empty;
                    RD_dtIncidentDtTime.SelectedDate = null;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AddIncidentsToEmp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void BUFilter1Emp_SelectedIndexChanged(object sender, EventArgs e)
    {
        //To fetch employee details based on the "BUFilter" (User Control) employee selection
        try
        {
            if (BUFilter1.EmployeeID>0  )
            {
            SMHR_WorkmanCompensation objWrkComp = new SMHR_WorkmanCompensation();
            objWrkComp.EmpID = Convert.ToInt32(BUFilter1.EmployeeID);
            objWrkComp.OPERATION = operation.Select;
            DataTable dtEmpDetails = new DataTable();
            dtEmpDetails = BLL.USP_GET_EMP_BY_EMP_ID(objWrkComp);
            if (dtEmpDetails.Rows.Count > 0)
            {
                RD_txtEmployee.Text = Convert.ToString(dtEmpDetails.Rows[0]["EMP_NAME"]);
                RD_txtDesignation.Text = Convert.ToString(dtEmpDetails.Rows[0]["POSITIONS_CODE"]);
                RD_txtAge.Text = Convert.ToString(dtEmpDetails.Rows[0]["Age"]);
                RD_txtSex.Text = Convert.ToString(dtEmpDetails.Rows[0]["APPLICANT_GENDER"]);
            }
            else
            {
                RD_txtDesignation.Text = string.Empty;
                RD_txtAge.Text = string.Empty;
                RD_txtSex.Text = string.Empty;
            }
            }
            else
            {
                RD_txtEmployee.Text = string.Empty;
                RD_txtDesignation.Text = string.Empty;
                RD_txtAge.Text = string.Empty;
                RD_txtSex.Text = string.Empty;

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AddIncidentsToEmp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}