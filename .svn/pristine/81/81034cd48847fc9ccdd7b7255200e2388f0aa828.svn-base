using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Health_and_Safety_frm_InspectionIsCompliant : System.Web.UI.Page
{
    SMHR_INSPECTION_SCHEDULE _obj_smhr_Inspection_Schedule;
    SMHR_INSPECTION_AREA _obj_smhr_inspection_area;
    static int OrganizationID = 0;
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
            _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Inspections Feedback");
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
                Rg_Areas_To_Inspected.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                btn_Submit.Visible = false;
                //  btn_Update.Visible = false;
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
            if (Convert.ToInt32(Session["EMP_ID"]) == 0)
            {
                BLL.ShowMessage(this, "You Dont have Permission for Accessing this Page..");

                lnkPastInsp.Visible = false;
                rad_InspectionName.Enabled = false;

                return;
            }
            else
            {
                //LoadInspectedBy();
                LoadInspections();
                LoadEmployees();

                rad_InspectionName.SelectedIndex = 0;
            }
        }
      }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InspectionIsCompliant", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadEmployees()
    {
        try
        {
            rad_InspectedBy.Items.Clear();
            if (Convert.ToInt32(Session["EMP_ID"]) != 0)
            {
                DataTable dtEmp = BLL.Get_Applicant_Names();

                if (dtEmp.Rows.Count > 0)
                {
                    rad_InspectedBy.DataSource = dtEmp;
                    rad_InspectedBy.DataTextField = "APPLICANT_FULLLNAME";
                    rad_InspectedBy.DataValueField = "EMP_ID";
                    rad_InspectedBy.DataBind();
                    rad_InspectedBy.SelectedValue = Convert.ToString(Session["EMP_ID"]);
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InspectionIsCompliant", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void LoadInspectedBy()
    {
        try
        {
            if (Convert.ToInt32(Session["EMP_ID"]) == 0)
            {
                _obj_smhr_Inspection_Schedule = new SMHR_INSPECTION_SCHEDULE();
                _obj_smhr_Inspection_Schedule.LOGIN_EMP_ID = 0;
                DataTable dt_InspectedBy = BLL.get_InspectedBy(_obj_smhr_Inspection_Schedule);
                rad_InspectedBy.DataSource = dt_InspectedBy;
                rad_InspectedBy.DataTextField = "EMP_NAME";
                rad_InspectedBy.DataValueField = "EMP_ID";
                rad_InspectedBy.DataBind();
                rad_InspectedBy.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            }
            else
            {
                _obj_smhr_Inspection_Schedule = new SMHR_INSPECTION_SCHEDULE();
                _obj_smhr_Inspection_Schedule.LOGIN_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                DataTable dt_InspectedBy = BLL.get_InspectedBy(_obj_smhr_Inspection_Schedule);
                rad_InspectedBy.DataSource = dt_InspectedBy;
                rad_InspectedBy.DataTextField = "EMP_NAME";
                rad_InspectedBy.DataValueField = "EMP_ID";
                rad_InspectedBy.DataBind();
                rad_InspectedBy.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                rad_InspectedBy.SelectedValue = Convert.ToString(dt_InspectedBy.Rows[0]["Emp_Id"]);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InspectionIsCompliant", ex.StackTrace, DateTime.Now);
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
    protected void LoadInspections()
    {
        try
        {
            rad_InspectionName.Items.Clear();
            string finalInspIDs = string.Empty;
            _obj_smhr_Inspection_Schedule = new SMHR_INSPECTION_SCHEDULE();
            if (Convert.ToInt32(Session["EMP_ID"]) == 0)
            {
                _obj_smhr_Inspection_Schedule.OPERATION = operation.GET_INSPECTIONS_ASSIGNEDTO;
                _obj_smhr_Inspection_Schedule.LOGIN_EMP_ID = 0;
                DataTable dt_Inspections = BLL.get_AllInspectionSchedules(_obj_smhr_Inspection_Schedule);
                rad_InspectionName.DataSource = dt_Inspections;
                rad_InspectionName.DataTextField = "INSPECTION_NAME";
                rad_InspectionName.DataValueField = "INSPECTION_ID";
                rad_InspectionName.DataBind();
                rad_InspectionName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            }
            else
            {
                //Commented by Eshwar_Dev on 20131116 due to change of Inspecitons to load below grid
                _obj_smhr_Inspection_Schedule.LOGIN_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                _obj_smhr_Inspection_Schedule.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_Inspections_InspectedBy = BLL.get_Inspections_InspectedBy(_obj_smhr_Inspection_Schedule);

                //if (Convert.ToInt32(dt_Inspections_InspectedBy.Rows.Count) > 0)
                //{
                for (int i = 0; i < dt_Inspections_InspectedBy.Rows.Count; i++)
                {
                    int inspID = Convert.ToInt32(dt_Inspections_InspectedBy.Rows[i]["INSPECTION_SCHEDULE_INSPECTION_ID"]);

                    DataTable dt_GetInspIDsforRecords = BLL.Get_MainInspectionsIds(_obj_smhr_Inspection_Schedule, inspID);

                    //if (Convert.ToInt32(dt_GetInspIDsforRecords.Rows.Count) > 0)
                    //{
                    for (int j = 0; j < dt_GetInspIDsforRecords.Rows.Count; j++)
                    {
                        finalInspIDs = finalInspIDs + Convert.ToString(inspID) + ",";
                    }
                    //}
                }
                //}

                if (finalInspIDs != string.Empty)
                {
                    finalInspIDs = finalInspIDs.Remove(finalInspIDs.Length - 1);

                    DataTable dt_FinalInspectionValues = BLL.Get_FinalInspectionsData(_obj_smhr_Inspection_Schedule, finalInspIDs);

                    rad_InspectionName.DataSource = dt_FinalInspectionValues;
                    rad_InspectionName.DataTextField = "INSPECTION_NAME";
                    rad_InspectionName.DataValueField = "INSPECTION_SCHEDULE_INSPECTION_ID";
                    rad_InspectionName.DataBind();
                }
                rad_InspectionName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

                //rad_InspectionName.Enabled = false;
                //LoadGrid();
                //LoadInspectionNames(Convert.ToInt32(Session["EMP_ID"]));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InspectionIsCompliant", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadInspectionsWhileSubmitting()
    {
        try
        {
            _obj_smhr_Inspection_Schedule = new SMHR_INSPECTION_SCHEDULE();

            _obj_smhr_Inspection_Schedule.LOGIN_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            _obj_smhr_Inspection_Schedule.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);


            //DataTable dt_FinalInspectionValues = BLL.Get_FinalInspectionsData(_obj_smhr_Inspection_Schedule, finalInspIDs);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InspectionIsCompliant", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    public void LoadGrid()
    {
        try
        {
            _obj_smhr_Inspection_Schedule.OPERATION = operation.GET_INSPECTIONS_ASSIGNEDTO;
            _obj_smhr_Inspection_Schedule.LOGIN_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            _obj_smhr_Inspection_Schedule.INSPECTION_SCHEDULE_INSPECTION_ID = Convert.ToInt32(rad_InspectionName.SelectedValue);
            DataTable dt_Inspections = BLL.get_AllInspectionSchedules2(_obj_smhr_Inspection_Schedule);
            if (dt_Inspections != null)
            {
                if (dt_Inspections.Rows.Count > 0)
                {
                    //rad_InspectionName.SelectedValue = Convert.ToString(dt_Inspections.Rows[0]["INSPECTION_SCHEDULE_ID"]);
                    ViewState["ScheduleId"] = Convert.ToString(dt_Inspections.Rows[0]["INSPECTION_SCHEDULE_ID"]);
                    rdtp_FromDate.SelectedDate = Convert.ToDateTime(dt_Inspections.Rows[0]["INSPECTION_SCHEDULE_FROMDATE"]);
                    rdtp_ToDate.SelectedDate = Convert.ToDateTime(dt_Inspections.Rows[0]["INSPECTION_SCHEDULE_TODATE"]);
                    rtp_FromTime.SelectedDate = Convert.ToDateTime(dt_Inspections.Rows[0]["INSPECTION_SCHEDULE_FROMTIME"]);
                    rtp_ToTime.SelectedDate = Convert.ToDateTime(dt_Inspections.Rows[0]["INSPECTION_SCHEDULE_TOTIME"]);
                    Rg_Areas_To_Inspected.DataSource = dt_Inspections;
                    Rg_Areas_To_Inspected.DataBind();
                    INSPECTION_AREA_ID.Text = dt_Inspections.Rows[0]["INSPECTION_AREA_ID"].ToString();
                    INSPECTION_AREA_SCHEDULE_ID.Text = dt_Inspections.Rows[0]["INSPECTION_AREA_SCHEDULE_ID"].ToString();
                    AREA_ID.Text = dt_Inspections.Rows[0]["AREA_ID"].ToString();

                    divNoRecords.Visible = false;
                    divControls.Visible = true;
                    btn_Submit.Visible = true;
                }
                else
                {
                    divNoRecords.Visible = true;
                    divControls.Visible = false;
                    btn_Submit.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InspectionIsCompliant", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rad_InspectionName_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            btn_Submit.Enabled = true;

            if (rad_InspectionName.SelectedIndex != 0)
            {
                int inspID = Convert.ToInt32(rad_InspectionName.SelectedValue);
                ViewState["inspID"] = inspID;

                //LoadGridbyInsID(inspID);
                _obj_smhr_Inspection_Schedule = new SMHR_INSPECTION_SCHEDULE();
                _obj_smhr_Inspection_Schedule.INSPECTION_SCHEDULE_INSPECTION_ID = inspID;
                _obj_smhr_Inspection_Schedule.INSPECTION_SCHEDULE_ASSIGNED_TO = Convert.ToInt32(Session["EMP_ID"]);
                _obj_smhr_Inspection_Schedule.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_getInspection = BLL.GET_INSPECTIONSCHEDULE_ISCOMPLIANT(_obj_smhr_Inspection_Schedule);
                if (dt_getInspection != null)
                {
                    if (dt_getInspection.Rows.Count > 0)
                    {
                        Rg_Areas_To_Inspected.DataSource = dt_getInspection;
                        Rg_Areas_To_Inspected.DataBind();
                        rdtp_FromDate.SelectedDate = Convert.ToDateTime(dt_getInspection.Rows[0]["INSPECTION_SCHEDULE_FROMDATE"].ToString());
                        rdtp_ToDate.SelectedDate = Convert.ToDateTime(dt_getInspection.Rows[0]["INSPECTION_SCHEDULE_TODATE"].ToString());
                        rtp_FromTime.SelectedDate = Convert.ToDateTime(dt_getInspection.Rows[0]["INSPECTION_SCHEDULE_FROMTIME"].ToString());
                        rtp_ToTime.SelectedDate = Convert.ToDateTime(dt_getInspection.Rows[0]["INSPECTION_SCHEDULE_TOTIME"].ToString());

                        divControls.Visible = true;
                        btn_Submit.Visible = true;
                        btn_Cancel.Visible = true;

                        //LoadGrid();
                    }
                }
            }
            else
            {
                divControls.Visible = false;
                btn_Submit.Visible = false;
                btn_Cancel.Visible = false;
                divNoRecords.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InspectionIsCompliant", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rad_InspectedBy_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rad_InspectionName.ClearSelection();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InspectionIsCompliant", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Clearcontrols()
    {
        try
        {
            LoadInspectedBy();
            LoadInspections();
            rad_InspectedBy.SelectedIndex = 0;
            rad_InspectionName.SelectedIndex = 0;
            rad_InspectionName.Enabled = true;
            rtp_FromTime.Clear();
            rtp_ToTime.Clear();
            rdtp_FromDate.Clear();
            rdtp_ToDate.Clear();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InspectionIsCompliant", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    //protected void LoadInspectionNames(int empID)
    //{
    //    try
    //    {
    //        if (Convert.ToInt32(Session["EMP_ID"]) != 0)
    //        {
    //            _obj_smhr_Inspection_Schedule = new SMHR_INSPECTION_SCHEDULE();
    //            _obj_smhr_Inspection_Schedule.INSPECTION_SCHEDULE_ASSIGNED_TO = empID;
    //            DataTable dtInspNames = BLL.GetInspectionsbyEmpID(_obj_smhr_Inspection_Schedule);

    //            if (dtInspNames.Rows.Count > 0)
    //            {
    //                rad_InspectedBy.DataSource = dtInspNames;
    //                rad_InspectedBy.DataTextField = "INSPECTION_NAME";
    //                rad_InspectedBy.DataValueField = "INSPECTION_ID";
    //                rad_InspectedBy.DataBind();
    //            }
    //            rad_InspectedBy.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select Inspeciton Name"));
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            int count = 0;
            bool status = false;
            _obj_smhr_inspection_area = new SMHR_INSPECTION_AREA();

            RadioButtonList radbuttonlist;
            RadTextBox radtextbox;
            Label lblAreaID;
            Label lbl_IA_ID;
            CheckBox chkSelect;
            RequiredFieldValidator rfv_IsCompliant;
            RequiredFieldValidator rfv_Comments;

            for (int index = 0; index <= Rg_Areas_To_Inspected.Items.Count - 1; index++)
            {
                radbuttonlist = Rg_Areas_To_Inspected.Items[index].FindControl("rbl_IsCompliant") as RadioButtonList;
                radtextbox = Rg_Areas_To_Inspected.Items[index].FindControl("Comments") as RadTextBox;
                lblAreaID = Rg_Areas_To_Inspected.Items[index].FindControl("lbl_Area_Id") as Label;
                lbl_IA_ID = Rg_Areas_To_Inspected.Items[index].FindControl("lbl_IA_ID") as Label;
                chkSelect = Rg_Areas_To_Inspected.Items[index].FindControl("chk_Choose") as CheckBox;
                rfv_IsCompliant = Rg_Areas_To_Inspected.Items[index].FindControl("rfv_IsCompliant") as RequiredFieldValidator;
                rfv_Comments = Rg_Areas_To_Inspected.Items[index].FindControl("rfv_Comments") as RequiredFieldValidator;
                _obj_smhr_inspection_area.OPERATION = operation.ISCOMPLIANT;

                //if (chkSelect.Checked)
                if ((chkSelect.Checked) && (Rg_Areas_To_Inspected.Items[index].Enabled == true))
                {
                    count++;
                    rfv_IsCompliant.Enabled = true;
                    rfv_Comments.Enabled = true;

                    if (radbuttonlist.SelectedIndex > -1)
                    {
                        _obj_smhr_inspection_area.OPERATION = operation.FeedBack;
                        _obj_smhr_inspection_area.AREA_ID = Convert.ToInt32(lblAreaID.Text);
                        _obj_smhr_inspection_area.INSPECTION_AREA_ID = Convert.ToInt32(lbl_IA_ID.Text);
                        _obj_smhr_inspection_area.INSPECTION_AREA_MODIFIED_BY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_smhr_inspection_area.INSPECTION_AREA_MODIFIEDDATE = DateTime.Now;

                        if (radbuttonlist.SelectedItem.Text == "Yes")
                        {
                            _obj_smhr_inspection_area.INSPECTION_AREA_ISCOMPLIANT = true;
                        }
                        else if (radbuttonlist.SelectedItem.Text == "No")
                        {
                            _obj_smhr_inspection_area.INSPECTION_AREA_ISCOMPLIANT = false;
                        }

                        if (Convert.ToString(radtextbox.Text) != string.Empty)
                            _obj_smhr_inspection_area.INSPECTION_AREA_COMMENTS = Convert.ToString(radtextbox.Text);
                        else
                        {
                            BLL.ShowMessage(this, "Please Enter Comments");
                            radtextbox.Focus();
                            return;
                        }
                        //status = BLL.set_Inspection_Area(_obj_smhr_inspection_area);
                        status = BLL.set_Inspection_Area_FeedBack(_obj_smhr_inspection_area);
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Please Choose Area Name");
                        return;
                    }
                }
            }

            if (count == 0)
            {
                BLL.ShowConfirmMessage(this, "Please Choose atleast one area");
                return;
            }

            if (status)
            {
                BLL.ShowMessage(this, "Inspection Area Information Successfully Saved");
            }

            ReLoadGrid(Convert.ToInt32(ViewState["inspID"]));

            rad_InspectionName.SelectedValue = Convert.ToString(ViewState["inspID"]);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InspectionIsCompliant", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadGridbyInsID(int inspID)
    {
        try
        {
            _obj_smhr_Inspection_Schedule = new SMHR_INSPECTION_SCHEDULE();
            _obj_smhr_Inspection_Schedule.INSPECTION_SCHEDULE_INSPECTION_ID = inspID;
            _obj_smhr_Inspection_Schedule.INSPECTION_SCHEDULE_ASSIGNED_TO = Convert.ToInt32(Session["EMP_ID"]);
            _obj_smhr_Inspection_Schedule.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_getInspection = BLL.GET_INSPECTIONSCHEDULE_ISCOMPLIANT(_obj_smhr_Inspection_Schedule);
            if (dt_getInspection != null)
            {
                if (dt_getInspection.Rows.Count > 0)
                {
                    Rg_Areas_To_Inspected.DataSource = dt_getInspection;
                    //Rg_Areas_To_Inspected.DataBind();
                    rdtp_FromDate.SelectedDate = Convert.ToDateTime(dt_getInspection.Rows[0]["INSPECTION_SCHEDULE_FROMDATE"].ToString());
                    rdtp_ToDate.SelectedDate = Convert.ToDateTime(dt_getInspection.Rows[0]["INSPECTION_SCHEDULE_TODATE"].ToString());
                    rtp_FromTime.SelectedDate = Convert.ToDateTime(dt_getInspection.Rows[0]["INSPECTION_SCHEDULE_FROMTIME"].ToString());
                    rtp_ToTime.SelectedDate = Convert.ToDateTime(dt_getInspection.Rows[0]["INSPECTION_SCHEDULE_TOTIME"].ToString());

                    divControls.Visible = true;
                    btn_Submit.Visible = true;
                    btn_Cancel.Visible = true;

                    //LoadGrid();
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InspectionIsCompliant", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void ReLoadGrid(int inspID)
    {
        try
        {
            int rowCount = 0;

            _obj_smhr_Inspection_Schedule = new SMHR_INSPECTION_SCHEDULE();
            _obj_smhr_Inspection_Schedule.INSPECTION_SCHEDULE_INSPECTION_ID = inspID;
            _obj_smhr_Inspection_Schedule.INSPECTION_SCHEDULE_ASSIGNED_TO = Convert.ToInt32(Session["EMP_ID"]);
            _obj_smhr_Inspection_Schedule.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            DataTable dt_getInspection = BLL.GET_INSPECTIONSCHEDULE_ISCOMPLIANT(_obj_smhr_Inspection_Schedule);

            if (dt_getInspection.Rows.Count > 0)
                Rg_Areas_To_Inspected.DataSource = dt_getInspection;

            Rg_Areas_To_Inspected.DataBind();

            for (int i = 0; i < dt_getInspection.Rows.Count; i++)
            {
                string isSelect = Convert.ToString(dt_getInspection.Rows[i]["INSPECTION_AREA_ISCOMPLIANT"]);
                string isComent = Convert.ToString(dt_getInspection.Rows[i]["INSPECTION_AREA_COMMENTS"]);

                if ((isSelect == string.Empty) && (isComent == string.Empty))
                    rowCount++;
            }

            //for (int index = 0; index <= Rg_Areas_To_Inspected.Items.Count - 1; index++)
            //{
            //    CheckBox chkSelect = Rg_Areas_To_Inspected.Items[index].FindControl("chk_Choose") as CheckBox;

            //    if ((chkSelect.Checked) && (Rg_Areas_To_Inspected.Items[index].Enabled == true))
            //        rowCount++;
            //}

            if (rowCount > 0)
                btn_Submit.Enabled = true;
            else
                btn_Submit.Enabled = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InspectionIsCompliant", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            LoadInspections();
            rad_InspectionName.SelectedIndex = 0;

            divNoRecords.Visible = false;
            divControls.Visible = false;
            btn_Submit.Visible = false;
            btn_Cancel.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InspectionIsCompliant", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rg_Areas_To_Inspected_ItemDataBound(object sender, GridItemEventArgs e)
    {
        try
        {
            Label lbl_IsCompliant;
            Label lbl_ItemComments;
            RadTextBox rad_Comments;
            RadioButtonList rbl_IsCompliant;
            CheckBox chk_Choose;

            for (int index = 0; index <= Rg_Areas_To_Inspected.Items.Count - 1; index++)
            {
                lbl_IsCompliant = Rg_Areas_To_Inspected.Items[index].FindControl("lbl_IsCompliant") as Label;
                lbl_ItemComments = Rg_Areas_To_Inspected.Items[index].FindControl("lbl_ItemComments") as Label;
                rad_Comments = Rg_Areas_To_Inspected.Items[index].FindControl("Comments") as RadTextBox;
                rbl_IsCompliant = Rg_Areas_To_Inspected.Items[index].FindControl("rbl_IsCompliant") as RadioButtonList;
                chk_Choose = Rg_Areas_To_Inspected.Items[index].FindControl("chk_Choose") as CheckBox;
                if (lbl_ItemComments.Text != string.Empty)
                {
                    rad_Comments.Text = lbl_ItemComments.Text;
                }
                if (lbl_IsCompliant.Text != string.Empty)
                {
                    if (Convert.ToBoolean(lbl_IsCompliant.Text) == true)
                        rbl_IsCompliant.SelectedValue = "1";
                    else
                        rbl_IsCompliant.SelectedValue = "0";

                    if ((lbl_ItemComments.Text != string.Empty) && ((rbl_IsCompliant.SelectedValue == "0") || (rbl_IsCompliant.SelectedValue == "1")))
                    {
                        Rg_Areas_To_Inspected.Items[index].Enabled = false;
                        chk_Choose.Checked = true;
                    }
                    else
                    {
                        Rg_Areas_To_Inspected.Items[index].Enabled = true;
                        chk_Choose.Checked = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InspectionIsCompliant", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rg_Areas_To_Inspected_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGridbyInsID(Convert.ToInt32(ViewState["inspID"]));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InspectionIsCompliant", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}