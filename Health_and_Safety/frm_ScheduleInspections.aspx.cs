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

public partial class Health_and_Safety_frm_ScheduleInspections : System.Web.UI.Page
{
    static int OrganizationID = 0;
    SMHR_BUSINESSUNIT _obj_SMHR_BusinessUnit;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_DEPARTMENT obj_SMHR_Department;
    SMHR_INSPECTION _obj_SMHR_Inspection;
    SMHR_INSPECTION_SCHEDULE _obj_smhr_schedule_Inspection;
    SMHR_INSPECTION_AREA _obj_smhr_Inspection_Area;
    SMHR_AREA _obj_smhr_Area;
    protected SMHR_EMP_PAYITEMS _obj_smhr_payitems;
    int fbCount = 0;

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
            _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("COUNTRY");
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
                Rg_InspectionsSchedules.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                btn_Submit.Visible = false;
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
            Rm_HDPT_page.SelectedIndex = 0;
            OrganizationID = Convert.ToInt32(Session["ORG_ID"].ToString());
            //Rm_HDPT_page.SelectedIndex = 1;
            // LoadInspectionsGrid();
            //  LoadBusinessUnit();
        }
      }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ScheduleInspections", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void ClearControls()
    {
        try
        {
            rad_Directorate.Items.Clear();
            rad_Directorate.Items.Insert(0, new RadComboBoxItem("Select"));
            rad_Department.Items.Clear();
            rad_Department.Items.Insert(0, new RadComboBoxItem("Select"));
            rad_SubDepartment.Items.Clear();
            rad_SubDepartment.Items.Insert(0, new RadComboBoxItem("Select"));
            rad_InspectionName.Text = string.Empty;
            rad_Description.Text = string.Empty;
            rad_InspectionName.Items.Clear();
            rcmb_Employees.Items.Clear();
            rdtp_FromDate.Clear();
            rdtp_ToDate.Clear();
            rtp_ToTime.Clear();
            rtp_FromTime.Clear();
            rcmb_Employees.Text = string.Empty;
            rlb_SelectArea.Items.Clear();
            Rm_HDPT_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ScheduleInspections", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Edit(object sender, CommandEventArgs e)
    {
        try
        {
            ClearControls();

            _obj_smhr_schedule_Inspection = new SMHR_INSPECTION_SCHEDULE();
            _obj_smhr_Inspection_Area = new SMHR_INSPECTION_AREA();
            _obj_SMHR_Inspection = new SMHR_INSPECTION();
            _obj_smhr_Area = new SMHR_AREA();

            DataTable dt_AreaDetails = new DataTable();
            RadComboBoxItem ITEM = new RadComboBoxItem();

            _obj_smhr_schedule_Inspection.INSPECTION_SCHEDULE_ID = Convert.ToInt32(e.CommandArgument);
            DataTable dt = BLL.get_Inspection(_obj_smhr_schedule_Inspection);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if ((Convert.ToString(dt.Rows[i]["INSPECTION_AREA_COMMENTS"]) != string.Empty))
                    fbCount++;
            }

            if (fbCount > 0)
            {
                BLL.ShowMessage(this, "This Schedule Inspection is in Feed Back mode..");
                Rm_HDPT_page.SelectedIndex = 0;
                return;
            }

            btn_Submit.Visible = false;
            btn_Update.Visible = true;
            rcmb_EmpReg_BU.Enabled = false;
            rad_Directorate.Enabled = false;
            rad_Department.Enabled = false;
            rad_SubDepartment.Enabled = false;
            rad_InspectionName.Enabled = false;

            if (Convert.ToInt32(dt.Rows.Count) == 0)
            {
                BLL.ShowMessage(this, "Not a valid Record to display..");
                return;
            }

            //int areID = Convert.ToInt32(dt.Rows[0]["AREA_ID"]);
            int buID = Convert.ToInt32(dt.Rows[0]["BUSINESSUNIT_ID"]);
            int dirID = Convert.ToInt32(dt.Rows[0]["DIRECTORATE_ID"]);
            int depID = Convert.ToInt32(dt.Rows[0]["DEPARTMENT_ID"]);
            int sdpID = Convert.ToInt32(dt.Rows[0]["SMHR_DIV_ID"]);
            int insID = Convert.ToInt32(dt.Rows[0]["INSPECTION_ID"]);
            int orgID = Convert.ToInt32(Session["ORG_ID"]);
            int empid = Convert.ToInt32(dt.Rows[0]["EMP_ID"]);

            ViewState["buID"] = buID;
            ViewState["dirID"] = dirID;
            ViewState["depID"] = depID;

            LoadBusinessUnit();

            if (buID != 0)
                Load_Directorate();
            if (dirID != 0)
                LoadDepartment();
            if (depID != 0)
                LoadDivision();

            LoadAllInspectionValues();

            lbl_InspectionID.Text = Convert.ToString(dt.Rows[0]["INSPECTION_SCHEDULE_ID"]);
            rad_Description.Text = Convert.ToString(dt.Rows[0]["INSPECTION_DESCRIPTION"]);

            //ITEM.Text = Convert.ToString(dt.Rows[0]["EMP_NAME"]);
            //ITEM.Value = Convert.ToString(dt.Rows[0]["EMP_ID"]);
            //rcmb_Employees.Items.Insert(0, ITEM);
            //ViewState["employee"] = ITEM.Value;

            rdtp_FromDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["INSPECTION_SCHEDULE_FROMDATE"]);
            rdtp_ToDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["INSPECTION_SCHEDULE_TODATE"]);
            rtp_FromTime.SelectedDate = Convert.ToDateTime(dt.Rows[0]["INSPECTION_SCHEDULE_FROMTIME"]);
            rtp_ToTime.SelectedDate = Convert.ToDateTime(dt.Rows[0]["INSPECTION_SCHEDULE_TOTIME"]);

            #region Eshwar_Code

            rcmb_EmpReg_BU.SelectedValue = Convert.ToString(buID);
            rad_Directorate.SelectedValue = Convert.ToString(dirID);
            rad_Department.SelectedValue = Convert.ToString(depID);
            rad_SubDepartment.SelectedValue = Convert.ToString(sdpID);
            rad_InspectionName.SelectedValue = Convert.ToString(insID);
            LoadEmployees();
            //rcmb_Employees.SelectedValue = Convert.ToString(empid);
            rcmb_Employees.SelectedIndex = rcmb_Employees.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["EMP_ID"]));


            //_obj_smhr_Area.AREA_ID = areID;
            _obj_smhr_Area.AREA_BUSINESSUNIT_ID = buID;
            _obj_smhr_Area.ORGANISATION_ID = orgID;

            if (sdpID != 0)         //Areas Loading based upon Sub Department
            {
                _obj_smhr_Area.AREA_SUBDEPARTMENT_ID = sdpID;
                _obj_smhr_Area.AREA_DEPARTMENT_ID = depID;
                _obj_smhr_Area.AREA_DIRECTORATE_ID = dirID;

                //dt_AreaDetails = BLL.get_Area_SubDepartmentWise(_obj_smhr_Area);
                dt_AreaDetails = BLL.GET_AREA_BU_DI_DP_SD_WISE(_obj_smhr_Area);
            }
            else if (depID != 0)    //Areas Loading based upon Department
            {
                _obj_smhr_Area.AREA_DEPARTMENT_ID = depID;
                _obj_smhr_Area.AREA_DIRECTORATE_ID = dirID;

                //dt_AreaDetails = BLL.get_Area_DepartmentWise(_obj_smhr_Area);
                dt_AreaDetails = BLL.GET_AREA_BU_DI_DP_WISE(_obj_smhr_Area);
            }
            else if (dirID != 0)    //Areas Loading based upon Directorate
            {
                _obj_smhr_Area.AREA_DIRECTORATE_ID = dirID;

                //dt_AreaDetails = BLL.get_Area_BU_Directoratewise(_obj_smhr_Area);
                dt_AreaDetails = BLL.GET_AREA_BU_DI_WISE(_obj_smhr_Area);
            }
            else
            {
                //dt_AreaDetails = BLL.get_allareas_by_buID(_obj_smhr_Area);
                dt_AreaDetails = BLL.GET_AREA_BU_WISE(_obj_smhr_Area);
            }

            rlb_SelectArea.DataSource = dt_AreaDetails;
            rlb_SelectArea.DataTextField = "AREA_NAME";
            rlb_SelectArea.DataValueField = "AREA_ID";
            rlb_SelectArea.DataBind();

            string areaID = Convert.ToString(dt.Rows[0]["AREA_ID"]);
            for (int index = 0; index <= rlb_SelectArea.Items.Count - 1; index++)
            {
                foreach (string item in areaID.Split(new char[] { ',' }))
                {
                    if (item != "" && item == rlb_SelectArea.Items[index].Value)
                    {
                        rlb_SelectArea.Items[index].Checked = true;
                    }
                }
            }

            Rm_HDPT_page.SelectedIndex = 1;

            #endregion

            #region Commented
            //if (rad_Directorate.SelectedIndex > 0)
            //{
            //    LoadDepartment();           
            //    _obj_smhr_Inspection_Area = new SMHR_INSPECTION_AREA();
            //    _obj_smhr_Inspection_Area.OPERATION = operation.Select;
            //    _obj_smhr_Inspection_Area.AREA_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_EmpReg_BU.SelectedValue);
            //    _obj_smhr_Inspection_Area.AREA_DIRECTORATE_ID = Convert.ToInt32(rad_Directorate.SelectedValue);
            //    dt_AreaDetails = BLL.get_Area_BU_Directoratewise(_obj_smhr_Inspection_Area);
            //    _obj_SMHR_Inspection = new SMHR_INSPECTION();
            //    _obj_SMHR_Inspection.INSPECTION_BU_ID = Convert.ToInt32(rcmb_EmpReg_BU.SelectedValue);
            //    _obj_SMHR_Inspection.INSPECTION_DIRECTORATE_ID = Convert.ToInt32(rad_Directorate.SelectedValue);
            //    DataTable dt_BU_DirectorateWise = BLL.get_InspectionsBUDirectorateWise(_obj_SMHR_Inspection);
            //    if (dt_BU_DirectorateWise != null)
            //    {
            //        if (dt_BU_DirectorateWise.Rows.Count > 0)
            //        {
            //            rad_InspectionName.Items.Clear();
            //            rad_InspectionName.DataSource = dt_BU_DirectorateWise;
            //            rad_InspectionName.DataTextField = "INSPECTION_NAME";
            //            rad_InspectionName.DataValueField = "INSPECTION_ID";
            //            rad_InspectionName.DataBind();
            //            rad_InspectionName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            //        }
            //    }
            //}

            //rad_Department.SelectedValue = Convert.ToString(dt.Rows[0]["DEPARTMENT_ID"]);
            //if (rad_Department.SelectedIndex > 0)
            //{
            //    LoadDivision();
            //    rad_InspectionName.Items.Clear();
            //    _obj_smhr_Inspection_Area = new SMHR_INSPECTION_AREA();
            //    _obj_smhr_Inspection_Area.OPERATION = operation.Select;
            //    _obj_smhr_Inspection_Area.AREA_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_EmpReg_BU.SelectedValue);
            //    _obj_smhr_Inspection_Area.AREA_DIRECTORATE_ID = Convert.ToInt32(rad_Directorate.SelectedValue);
            //    _obj_smhr_Inspection_Area.AREA_DEPARTMENT_ID = Convert.ToInt32(rad_Department.SelectedValue);
            //    dt_AreaDetails = BLL.get_Area_DepartmentWise(_obj_smhr_Inspection_Area);
            //    _obj_SMHR_Inspection = new SMHR_INSPECTION();
            //    _obj_SMHR_Inspection.INSPECTION_BU_ID = Convert.ToInt32(rcmb_EmpReg_BU.SelectedValue);
            //    _obj_SMHR_Inspection.INSPECTION_DIRECTORATE_ID = Convert.ToInt32(rad_Directorate.SelectedValue);
            //    _obj_SMHR_Inspection.INSPECTION_DEPARTMENT_ID = Convert.ToInt32(rad_Department.SelectedValue);
            //    DataTable dt_DepartmentWise = BLL.get_InspectionsDepartmentWise(_obj_SMHR_Inspection);
            //    if (dt_DepartmentWise != null)
            //    {
            //        if (dt_DepartmentWise.Rows.Count > 0)
            //        {
            //            rad_InspectionName.Items.Clear();
            //            rad_InspectionName.DataSource = dt_DepartmentWise;
            //            rad_InspectionName.DataTextField = "INSPECTION_NAME";
            //            rad_InspectionName.DataValueField = "INSPECTION_ID";
            //            rad_InspectionName.DataBind();
            //            rad_InspectionName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            //        }
            //    }
            //}

            //rad_SubDepartment.SelectedValue = Convert.ToString(dt.Rows[0]["SMHR_DIV_ID"]);
            //if (rad_SubDepartment.SelectedIndex > 0)
            //{
            //    rad_InspectionName.Items.Clear();
            //    _obj_smhr_Inspection_Area = new SMHR_INSPECTION_AREA();
            //    _obj_smhr_Inspection_Area.OPERATION = operation.Select;
            //    _obj_smhr_Inspection_Area.AREA_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_EmpReg_BU.SelectedValue);
            //    _obj_smhr_Inspection_Area.AREA_DIRECTORATE_ID = Convert.ToInt32(rad_Directorate.SelectedValue);
            //    _obj_smhr_Inspection_Area.AREA_DEPARTMENT_ID = Convert.ToInt32(rad_Department.SelectedValue);
            //    _obj_smhr_Inspection_Area.AREA_SUBDEPARTMENT_ID = Convert.ToInt32(rad_SubDepartment.SelectedValue);
            //    dt_AreaDetails = BLL.get_Area_SubDepartmentWise(_obj_smhr_Inspection_Area);
            //    _obj_SMHR_Inspection = new SMHR_INSPECTION();
            //    _obj_SMHR_Inspection.INSPECTION_BU_ID = Convert.ToInt32(rcmb_EmpReg_BU.SelectedValue);
            //    _obj_SMHR_Inspection.INSPECTION_DIRECTORATE_ID = Convert.ToInt32(rad_Directorate.SelectedValue);
            //    _obj_SMHR_Inspection.INSPECTION_DEPARTMENT_ID = Convert.ToInt32(rad_Department.SelectedValue);
            //    _obj_SMHR_Inspection.INSPECTION_SUBDEPARTMENT_ID = Convert.ToInt32(rad_SubDepartment.SelectedValue);
            //    DataTable dt_DepartmentWise = BLL.get_InspectionsDepartmentWise(_obj_SMHR_Inspection);
            //    if (dt_DepartmentWise != null)
            //    {
            //        if (dt_DepartmentWise.Rows.Count > 0)
            //        {
            //            rad_InspectionName.DataSource = dt_DepartmentWise;
            //            rad_InspectionName.DataTextField = "INSPECTION_NAME";
            //            rad_InspectionName.DataValueField = "INSPECTION_ID";
            //            rad_InspectionName.DataBind();
            //            rad_InspectionName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            //        }
            //    }
            //}
            //rlb_SelectArea.DataSource = dt_AreaDetails;
            //rlb_SelectArea.DataTextField = "AREA_NAME";
            //rlb_SelectArea.DataValueField = "AREA_ID";
            //rlb_SelectArea.DataBind();
            ////rlb_SelectArea.Items.Insert(0, new Telerik.Web.UI.RadListBoxItem("Select"));
            ////rfvSelectArea.Enabled = true;

            //string str = Convert.ToString(dt.Rows[0]["AREA_ID"]);
            //for (int index = 0; index <= rlb_SelectArea.Items.Count - 1; index++)
            //{

            //    foreach (string item in str.Split(new char[] { ',' }))
            //    {
            //        if (item != "" && item ==rlb_SelectArea.Items[index].Value)
            //        {
            //            rlb_SelectArea.Items[index].Checked = true;
            //        }
            //    }
            //}

            //rad_Description.Text = Convert.ToString(dt.Rows[0]["INSPECTION_DESCRIPTION"]);
            //rad_InspectionName.SelectedValue = Convert.ToString(dt.Rows[0]["INSPECTION_ID"]);

            //Rm_HDPT_page.SelectedIndex = 1;
            //_obj_smhr_Inspection_Area = new SMHR_INSPECTION_AREA();
            //_obj_smhr_Inspection_Area.INSPECTION_AREA_SCHEDULE_ID = Convert.ToInt32(e.CommandArgument);
            //DataTable dt_InspectionAreas = BLL.get_INSPECTION_SCHEDULEAREA(_obj_smhr_Inspection_Area);
            //foreach (DataRow dr in dt_InspectionAreas.Rows)
            //{
            //    foreach (RadListBoxItem item in rlb_SelectArea.Items)
            //    {
            //        if (item.Value == dr["AREA_ID"].ToString())
            //        {
            //            item.Checked = true;
            //        }
            //    }
            //}     
            #endregion
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ScheduleInspections", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            btn_Submit.Visible = true;
            ClearControls();
            rad_InspectionName.Enabled = true;
            rcmb_EmpReg_BU.ClearSelection();
            LoadBusinessUnit();
            rcmb_EmpReg_BU.Enabled = true;
            rdtp_FromDate.MinDate = DateTime.Now;
            rlb_SelectArea.Enabled = true;
            rad_Description.Text = string.Empty;
            rad_SubDepartment.Enabled = true;
            rad_Department.Enabled = true;
            rad_Directorate.Enabled = true;
            btn_Update.Visible = false;
            Rm_HDPT_page.SelectedIndex = 1;

            rad_InspectionName.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ScheduleInspections", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_EmpReg_BU_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rad_Directorate.ClearSelection();
            rad_Directorate.Items.Clear();
            rad_Directorate.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            rad_Department.ClearSelection();
            rad_Department.Items.Clear();
            rad_Department.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            rad_SubDepartment.ClearSelection();
            rad_SubDepartment.Items.Clear();
            rad_SubDepartment.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            rad_InspectionName.ClearSelection();
            rad_InspectionName.Items.Clear();
            rad_InspectionName.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            rlb_SelectArea.Items.Clear();

            rad_Description.Text = string.Empty;
            rcmb_Employees.Items.Clear();
            rcmb_Employees.Text = string.Empty;

            if (rcmb_EmpReg_BU.SelectedIndex > 0)
            {
                Load_Directorate();
                rad_Directorate.Focus();
                LoadEmployees();
                LoadAreasbyBUID(Convert.ToInt32(rcmb_EmpReg_BU.SelectedValue));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ScheduleInspections", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadAreasbyBUID(int buID)
    {
        try
        {
            if (buID != 0)
            {
                _obj_smhr_Area = new SMHR_AREA();
                _obj_SMHR_Inspection = new SMHR_INSPECTION();

                _obj_smhr_Area.AREA_BUSINESSUNIT_ID = buID;
                _obj_smhr_Area.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtAreas = BLL.GET_AREA_BU_WISE(_obj_smhr_Area);// BLL.get_allareas_by_buID(_obj_smhr_Area);

                rlb_SelectArea.DataSource = dtAreas;
                rlb_SelectArea.DataTextField = "AREA_NAME";
                rlb_SelectArea.DataValueField = "AREA_ID";
                rlb_SelectArea.DataBind();

                _obj_SMHR_Inspection.INSPECTION_BU_ID = buID;
                _obj_SMHR_Inspection.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtInspections = BLL.get_allInspections_by_buID(_obj_SMHR_Inspection);

                rad_InspectionName.DataSource = dtInspections;
                rad_InspectionName.DataTextField = "INSPECTION_NAME";
                rad_InspectionName.DataValueField = "INSPECTION_ID";
                rad_InspectionName.DataBind();
                rad_InspectionName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

                ViewState["InspectionNames"] = dtInspections;
                rfv_InspectionName.Enabled = true;
            }
            else
            {
                BLL.ShowMessage(this, "Please Select Business Unit");
                rcmb_EmpReg_BU.Focus();
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ScheduleInspections", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rad_Directorate_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rlb_SelectArea.Items.Clear();
            rad_InspectionName.Items.Clear();
            rad_Department.Items.Clear();
            rad_SubDepartment.Items.Clear();
            rad_Department.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            rad_SubDepartment.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            rad_Description.Text = string.Empty;

            if (rad_Directorate.SelectedIndex > 0)
            {
                _obj_smhr_Area = new SMHR_AREA();

                LoadDepartment();
                LoadEmployees();
                //_obj_smhr_Inspection_Area = new SMHR_INSPECTION_AREA();
                //_obj_smhr_Inspection_Area.OPERATION = operation.Select;
                //_obj_smhr_Inspection_Area.AREA_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_EmpReg_BU.SelectedValue);
                //_obj_smhr_Inspection_Area.AREA_DIRECTORATE_ID = Convert.ToInt32(rad_Directorate.SelectedValue);
                _obj_smhr_Area.AREA_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_EmpReg_BU.SelectedValue);
                _obj_smhr_Area.AREA_DIRECTORATE_ID = Convert.ToInt32(rad_Directorate.SelectedValue);
                _obj_smhr_Area.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_AreaDetails = BLL.GET_AREA_BU_DI_WISE(_obj_smhr_Area);//BLL.get_Area_BU_Directoratewise(_obj_smhr_Inspection_Area);
                rlb_SelectArea.DataSource = dt_AreaDetails;
                rlb_SelectArea.DataTextField = "AREA_NAME";
                rlb_SelectArea.DataValueField = "AREA_ID";
                rlb_SelectArea.DataBind();

                _obj_SMHR_Inspection = new SMHR_INSPECTION();
                _obj_SMHR_Inspection.INSPECTION_BU_ID = Convert.ToInt32(rcmb_EmpReg_BU.SelectedValue);
                _obj_SMHR_Inspection.INSPECTION_DIRECTORATE_ID = Convert.ToInt32(rad_Directorate.SelectedValue);
                _obj_SMHR_Inspection.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_BU_DirectorateWise = BLL.get_InspectionsBUDirectorateWise(_obj_SMHR_Inspection);
                ViewState["InspectionNames"] = dt_BU_DirectorateWise;
                rad_InspectionName.DataSource = dt_BU_DirectorateWise;
                rad_InspectionName.DataTextField = "INSPECTION_NAME";
                rad_InspectionName.DataValueField = "INSPECTION_ID";
                rad_InspectionName.DataBind();
                rad_InspectionName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                rad_SubDepartment.Focus();
            }
            else
            {
                rcmb_EmpReg_BU_SelectedIndexChanged(o, e);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ScheduleInspections", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rad_SubDepartment_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            _obj_smhr_Area = new SMHR_AREA();
            rlb_SelectArea.Items.Clear();
            rad_Description.Text = string.Empty;

            if (rad_SubDepartment.SelectedIndex > 0)
            {
                LoadEmployees();
                //_obj_smhr_Inspection_Area = new SMHR_INSPECTION_AREA();
                //_obj_smhr_Inspection_Area.OPERATION = operation.Select;
                //_obj_smhr_Inspection_Area.AREA_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_EmpReg_BU.SelectedValue);
                //_obj_smhr_Inspection_Area.AREA_DIRECTORATE_ID = Convert.ToInt32(rad_Directorate.SelectedValue);
                //_obj_smhr_Inspection_Area.AREA_DEPARTMENT_ID = Convert.ToInt32(rad_Department.SelectedValue);
                //_obj_smhr_Inspection_Area.AREA_SUBDEPARTMENT_ID = Convert.ToInt32(rad_SubDepartment.SelectedValue);
                _obj_smhr_Area.AREA_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_EmpReg_BU.SelectedValue);
                _obj_smhr_Area.AREA_DIRECTORATE_ID = Convert.ToInt32(rad_Directorate.SelectedValue);
                _obj_smhr_Area.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_smhr_Area.AREA_DEPARTMENT_ID = Convert.ToInt32(rad_Department.SelectedValue);
                _obj_smhr_Area.AREA_SUBDEPARTMENT_ID = Convert.ToInt32(rad_SubDepartment.SelectedValue);
                DataTable dt_AreaDetails = BLL.GET_AREA_BU_DI_DP_SD_WISE(_obj_smhr_Area);//BLL.get_Area_SubDepartmentWise(_obj_smhr_Area);
                rlb_SelectArea.DataSource = dt_AreaDetails;
                rlb_SelectArea.DataTextField = "AREA_NAME";
                rlb_SelectArea.DataValueField = "AREA_ID";
                rlb_SelectArea.DataBind();
                //rlb_SelectArea.Items.Insert(0, new Telerik.Web.UI.RadListBoxItem("Select"));
                //rfvSelectArea.Enabled = true;

                _obj_SMHR_Inspection = new SMHR_INSPECTION();
                _obj_SMHR_Inspection.INSPECTION_BU_ID = Convert.ToInt32(rcmb_EmpReg_BU.SelectedValue);
                _obj_SMHR_Inspection.INSPECTION_DIRECTORATE_ID = Convert.ToInt32(rad_Directorate.SelectedValue);
                _obj_SMHR_Inspection.INSPECTION_DEPARTMENT_ID = Convert.ToInt32(rad_Department.SelectedValue);
                _obj_SMHR_Inspection.INSPECTION_SUBDEPARTMENT_ID = Convert.ToInt32(rad_SubDepartment.SelectedValue);
                _obj_SMHR_Inspection.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_SubDepartmentWises = BLL.get_InspectionsSubDepartmentWises(_obj_SMHR_Inspection);
                ViewState["InspectionNames"] = dt_SubDepartmentWises;
                rad_InspectionName.DataSource = dt_SubDepartmentWises;
                rad_InspectionName.DataTextField = "INSPECTION_NAME";
                rad_InspectionName.DataValueField = "INSPECTION_ID";
                rad_InspectionName.DataBind();
                rad_InspectionName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            }
            else
            {
                rad_Department_SelectedIndexChanged(o, e);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ScheduleInspections", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rad_InspectionName_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            DataTable dt_Inspections = (DataTable)ViewState["InspectionNames"];
            if (rad_InspectionName.SelectedIndex > 0)
            {
                DataRow[] dr = dt_Inspections.Select("INSPECTION_ID=" + Convert.ToInt32(rad_InspectionName.SelectedValue));
                rad_Description.Text = dr[0]["INSPECTION_DESCRIPTION"].ToString();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ScheduleInspections", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rad_Department_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rlb_SelectArea.Items.Clear();
            rad_SubDepartment.ClearSelection();
            rad_SubDepartment.Items.Clear();
            rad_SubDepartment.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            rad_Description.Text = string.Empty;

            if (rad_Department.SelectedIndex > 0)
            {
                _obj_smhr_Area = new SMHR_AREA();

                LoadDivision();
                LoadEmployees();
                //_obj_smhr_Inspection_Area = new SMHR_INSPECTION_AREA();
                //_obj_smhr_Inspection_Area.OPERATION = operation.Select;
                //_obj_smhr_Inspection_Area.AREA_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_EmpReg_BU.SelectedValue);
                //_obj_smhr_Inspection_Area.AREA_DIRECTORATE_ID = Convert.ToInt32(rad_Directorate.SelectedValue);
                //_obj_smhr_Inspection_Area.AREA_DEPARTMENT_ID = Convert.ToInt32(rad_Department.SelectedValue); 
                _obj_smhr_Area.AREA_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_EmpReg_BU.SelectedValue);
                _obj_smhr_Area.AREA_DIRECTORATE_ID = Convert.ToInt32(rad_Directorate.SelectedValue);
                _obj_smhr_Area.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_smhr_Area.AREA_DEPARTMENT_ID = Convert.ToInt32(rad_Department.SelectedValue);
                DataTable dt_AreaDetails = BLL.GET_AREA_BU_DI_DP_WISE(_obj_smhr_Area);// BLL.get_Area_DepartmentWise(_obj_smhr_Inspection_Area);
                rlb_SelectArea.DataSource = dt_AreaDetails;
                rlb_SelectArea.DataTextField = "AREA_NAME";
                rlb_SelectArea.DataValueField = "AREA_ID";
                rlb_SelectArea.DataBind();

                _obj_SMHR_Inspection = new SMHR_INSPECTION();
                _obj_SMHR_Inspection.INSPECTION_BU_ID = Convert.ToInt32(rcmb_EmpReg_BU.SelectedValue);
                _obj_SMHR_Inspection.INSPECTION_DIRECTORATE_ID = Convert.ToInt32(rad_Directorate.SelectedValue);
                _obj_SMHR_Inspection.INSPECTION_DEPARTMENT_ID = Convert.ToInt32(rad_Department.SelectedValue);
                _obj_SMHR_Inspection.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_DepartmentWise = BLL.get_InspectionsDepartmentWise(_obj_SMHR_Inspection);
                ViewState["InspectionNames"] = dt_DepartmentWise;
                rad_InspectionName.DataSource = dt_DepartmentWise;
                rad_InspectionName.DataTextField = "INSPECTION_NAME";
                rad_InspectionName.DataValueField = "INSPECTION_ID";
                rad_InspectionName.DataBind();
                rad_InspectionName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            }
            else
            {
                rad_Directorate_SelectedIndexChanged(o, e);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ScheduleInspections", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadEmployees()
    {
        //try
        //{

        //    rcmb_Employees.Items.Clear();
        //    _obj_smhr_payitems = new SMHR_EMP_PAYITEMS();
        //    //_obj_smhr_payitems.OPERATION = operation.Empty;
        //    _obj_smhr_payitems.OPERATION = operation.Empty_PH;
        //    _obj_smhr_payitems.SMHR_BUSUNIT = Convert.ToInt32(rcmb_EmpReg_BU.SelectedItem.Value);
        //    _obj_smhr_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
        //    DataTable DT_Details = BLL.get_EmpDetails(_obj_smhr_payitems);//NOT NEEDED AS WE ARE LOADING RELAVENT TO ORG.
        //    if (DT_Details.Rows.Count != 0)
        //    {
        //        rcmb_Employees.DataSource = DT_Details;
        //        rcmb_Employees.DataTextField = "Empname";
        //        rcmb_Employees.DataValueField = "EMP_ID";
        //        rcmb_Employees.DataBind();
        //        rcmb_Employees.Items.Insert(0, new RadComboBoxItem("Select"));
        //    }
        //    else
        //    {
        //        rcmb_Employees.Items.Clear();
        //        rcmb_Employees.Text = string.Empty;
        //        rcmb_Employees.Items.Insert(0, new RadComboBoxItem("Select"));


        //    }
        //}
        //catch (Exception ex)
        //{
        //    SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ScheduleInspections", ex.StackTrace, DateTime.Now);
        //    Response.Redirect("~/Frm_ErrorPage.aspx");
        //}
        try
        {
            SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
            DataTable DT_Details = new DataTable();
            if (rcmb_EmpReg_BU.SelectedItem.Value != "")
            {
                _obj_smhr_emp_payitems.OPERATION = operation.EmployeesBUwise;
                _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(rcmb_EmpReg_BU.SelectedItem.Value);
                _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                if (rad_Directorate.SelectedIndex > 0)
                {
                    _obj_smhr_emp_payitems.DIRECTORATE_ID = Convert.ToInt32(rad_Directorate.SelectedItem.Value);
                    _obj_smhr_emp_payitems.OPERATION = operation.EmployeesDirectoratewise; //Inserted BY Ragha Sudha on 4th oct 2013 for directoratewise
                }
                if (rad_Department.SelectedIndex > 0)
                {
                    _obj_smhr_emp_payitems.OPERATION = operation.EmployeesDepartmentwise;
                    _obj_smhr_emp_payitems.DEPARTMENT_ID = Convert.ToInt32(rad_Department.SelectedItem.Value);
                }
                if (rad_SubDepartment.SelectedIndex > 0)
                {
                    _obj_smhr_emp_payitems.OPERATION = operation.EmployeesSubDepartmentWise; //Inserted BY Ragha Sudha on 4th oct 2013 for directoratewise
                    _obj_smhr_emp_payitems.SUBDEPARTMENT_ID = Convert.ToInt32(rad_SubDepartment.SelectedItem.Value);
                }
                DT_Details = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
                if (DT_Details.Rows.Count != 0)
                {
                    BindEmployees(DT_Details);
                }
                else
                {
                    BindEmployees(DT_Details);
                }
                //}
            }
            else
            {
                BindEmployees(DT_Details);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEmployeePensionComputations", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    private void BindEmployees(DataTable DT_Details)
    {
        try
        {
            rcmb_Employees.DataSource = DT_Details;
            rcmb_Employees.DataTextField = "EMPNAME";
            rcmb_Employees.DataValueField = "EMP_ID";
            rcmb_Employees.DataBind();
            rcmb_Employees.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEmployeePensionComputations", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_Employees_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (Convert.ToString(rcmb_Employees.SelectedValue) != string.Empty)
                ViewState["employee"] = rcmb_Employees.SelectedValue;
            else
            {
                BLL.ShowMessage(this, "Please Select Employee Name");
                rcmb_Employees.Focus();
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ScheduleInspections", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadBusinessUnit()
    {
        _obj_SMHR_BusinessUnit = new SMHR_BUSINESSUNIT();
        try
        {
            rcmb_EmpReg_BU.Items.Clear();
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            if (dt_BUDetails.Rows.Count > 0)
            {
                rcmb_EmpReg_BU.DataSource = dt_BUDetails;
                rcmb_EmpReg_BU.DataValueField = "BUSINESSUNIT_ID";
                rcmb_EmpReg_BU.DataTextField = "BUSINESSUNIT_CODE";
                rcmb_EmpReg_BU.DataBind();
            }
            rcmb_EmpReg_BU.Items.Insert(0, new RadComboBoxItem("Select"));
            if ((Convert.ToInt32(Session["EMP_ID"]) == 0))
            {

            }
            else
            {
                rcmb_EmpReg_BU.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ScheduleInspections", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void Load_Directorate()
    {
        try
        {
            rad_Directorate.Items.Clear();

            SMHR_DIRECTORATE _obj_Smhr_Directorate = new SMHR_DIRECTORATE();

            if (Convert.ToString(Session["ORG_ID"]) != string.Empty)
            {
                _obj_Smhr_Directorate.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

                if (rcmb_EmpReg_BU.SelectedIndex > 0)
                    _obj_Smhr_Directorate.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_EmpReg_BU.SelectedValue);
                else if (Convert.ToInt32(ViewState["buID"]) > 0)
                    _obj_Smhr_Directorate.BUSINESSUNIT_ID = Convert.ToInt32(ViewState["buID"]);

                DataTable DT = BLL.get_Directorate(_obj_Smhr_Directorate);

                if (DT.Rows.Count > 0)
                {
                    rad_Directorate.DataTextField = "DIRECTORATE_CODE";
                    rad_Directorate.DataValueField = "DIRECTORATE_ID";
                    rad_Directorate.DataSource = DT;
                    rad_Directorate.DataBind();
                    rad_Directorate.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                }
                else
                {
                    rad_Directorate.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                }
            }
            else
            {
                rad_Directorate.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ScheduleInspections", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadDivision()
    {
        try
        {
            rad_SubDepartment.Items.Clear();
            if (Convert.ToString(Session["ORG_ID"]) != string.Empty)
            {
                _obj_SMHR_BusinessUnit = new SMHR_BUSINESSUNIT();
                _obj_SMHR_BusinessUnit.OPERATION = operation.Select1;

                if (rcmb_EmpReg_BU.SelectedIndex > 0)
                    _obj_SMHR_BusinessUnit.BUID = Convert.ToInt32(rcmb_EmpReg_BU.SelectedValue);
                else
                    _obj_SMHR_BusinessUnit.BUID = Convert.ToInt32(ViewState["buID"]);

                if (rad_Department.SelectedIndex > 0)
                    _obj_SMHR_BusinessUnit.DEPARTMENT_ID = Convert.ToInt32(rad_Department.SelectedValue);
                else
                    _obj_SMHR_BusinessUnit.DEPARTMENT_ID = Convert.ToInt32(ViewState["depID"]);

                if (rad_Directorate.SelectedIndex > 0)
                    _obj_SMHR_BusinessUnit.DIRECTORATE_ID = Convert.ToInt32(rad_Directorate.SelectedValue);
                else
                    _obj_SMHR_BusinessUnit.DIRECTORATE_ID = Convert.ToInt32(ViewState["dirID"]);

                _obj_SMHR_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

                DataTable Dt_Divisions = BLL.Get_Divisions(_obj_SMHR_BusinessUnit);
                if (Dt_Divisions.Rows.Count > 0)
                {
                    rad_SubDepartment.DataTextField = "SMHR_DIV_CODE";
                    rad_SubDepartment.DataValueField = "SMHR_DIV_ID";
                    rad_SubDepartment.DataSource = Dt_Divisions;
                    rad_SubDepartment.DataBind();
                    rad_SubDepartment.Items.Insert(0, new RadComboBoxItem("Select", "0"));
                }
                else
                {
                    rad_SubDepartment.Items.Insert(0, new RadComboBoxItem("Select", "0"));
                }
            }
            else
                rad_SubDepartment.Items.Clear();
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ScheduleInspections", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadDepartment()
    {
        try
        {
            rad_Department.Items.Clear();
            if (Convert.ToString(Session["ORG_ID"]) != string.Empty)
            {
                obj_SMHR_Department = new SMHR_DEPARTMENT();
                obj_SMHR_Department.MODE = 7;

                if (rad_Directorate.SelectedIndex > 0)
                    obj_SMHR_Department.DIRECTORATE_ID = Convert.ToInt32(rad_Directorate.SelectedValue);
                else
                    obj_SMHR_Department.DIRECTORATE_ID = Convert.ToInt32(ViewState["dirID"]);

                if (rcmb_EmpReg_BU.SelectedIndex > 0)
                    obj_SMHR_Department.BUID = Convert.ToInt32(rcmb_EmpReg_BU.SelectedValue);
                else
                    obj_SMHR_Department.BUID = Convert.ToInt32(ViewState["buID"]);

                DataTable dt = BLL.get_Department(obj_SMHR_Department);
                if (dt.Rows.Count > 0)
                {
                    rad_Department.DataSource = dt;
                    rad_Department.DataTextField = "DEPARTMENT_NAME";
                    rad_Department.DataValueField = "DEPARTMENT_ID";
                    rad_Department.DataBind();
                    rad_Department.Items.Insert(0, new RadComboBoxItem("Select"));
                }
                else
                {
                    rad_Department.Items.Insert(0, new RadComboBoxItem("Select"));
                }
            }
            else
            {
                rad_Department.Items.Insert(0, new RadComboBoxItem("Select"));

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ScheduleInspections", ex.StackTrace, DateTime.Now);
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
    private void LoadInspectionsGrid()
    {
        try
        {
            _obj_smhr_schedule_Inspection = new SMHR_INSPECTION_SCHEDULE();
            _obj_smhr_schedule_Inspection.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            Rg_InspectionsSchedules.DataSource = BLL.get_AllInspectionSchedules(_obj_smhr_schedule_Inspection);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ScheduleInspections", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rg_InspectionsSchedules_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        LoadInspectionsGrid();
    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            bool status = false;
            bool status1 = false;
            DataTable identityid = new DataTable();
            DataTable dtSchInsptnExists = new DataTable();
            _obj_smhr_Inspection_Area = new SMHR_INSPECTION_AREA();
            _obj_SMHR_Inspection = new SMHR_INSPECTION();
            if (rlb_SelectArea.CheckedItems.Count == 0)
            {
                BLL.ShowMessage(this, "Please Select Atleast One Area");
                return;
            }
            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_UPDATE":

                    _obj_smhr_schedule_Inspection = new SMHR_INSPECTION_SCHEDULE();

                    _obj_smhr_schedule_Inspection.OPERATION = operation.Update;
                    _obj_smhr_schedule_Inspection.INSPECTION_SCHEDULE_ID = Convert.ToInt32(lbl_InspectionID.Text);
                    _obj_smhr_schedule_Inspection.INSPECTION_SCHEDULE_INSPECTION_ID = Convert.ToInt32(rad_InspectionName.SelectedValue);
                    //_obj_smhr_schedule_Inspection.INSPECTION_SCHEDULE_ASSIGNED_TO = Convert.ToInt32(Convert.ToInt32(ViewState["employee"]));
                    _obj_smhr_schedule_Inspection.INSPECTION_SCHEDULE_ASSIGNED_TO = Convert.ToInt32(rcmb_Employees.SelectedValue);
                    _obj_smhr_schedule_Inspection.INSPECTION_SCHEDULE_FROMDATE = Convert.ToDateTime(rdtp_FromDate.SelectedDate);
                    _obj_smhr_schedule_Inspection.INSPECTION_SCHEDULE_TODATE = Convert.ToDateTime(rdtp_ToDate.SelectedDate);
                    _obj_smhr_schedule_Inspection.INSPECTION_SCHEDULE_FROMTIME = Convert.ToDateTime(rtp_FromTime.SelectedDate.Value.ToShortTimeString());
                    _obj_smhr_schedule_Inspection.INSPECTION_SCHEDULE_TOTIME = Convert.ToDateTime(rtp_ToTime.SelectedDate.Value.ToShortTimeString());
                    _obj_smhr_schedule_Inspection.INSPECTION_SCHEDULE_MODIFIEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_schedule_Inspection.INSPECTION_SCHEDULE_MODIFIEDDATE = DateTime.Now;
                    _obj_smhr_schedule_Inspection.BUID = Convert.ToInt32(rcmb_EmpReg_BU.SelectedValue);

                    status = BLL.set_Inspection(_obj_smhr_schedule_Inspection);

                    _obj_smhr_Inspection_Area.INSPECTION_AREA_SCHEDULE_ID = Convert.ToInt32(lbl_InspectionID.Text);
                    status1 = BLL.delete_Inspection_Area(_obj_smhr_Inspection_Area);

                    if (status1)
                    {
                        _obj_smhr_Inspection_Area.OPERATION = operation.Update;
                        //_obj_SMHR_Inspection.INSPECTION_AREA_ISCOMPLIANT = false;
                        for (int index = 0; index <= rlb_SelectArea.Items.Count - 1; index++)
                        {
                            if (rlb_SelectArea.Items[index].Checked == true)
                            {
                                _obj_smhr_Inspection_Area.INSPECTION_AREA_SCHEDULE_ID = Convert.ToInt32(lbl_InspectionID.Text);
                                _obj_smhr_Inspection_Area.AREA_ID = Convert.ToInt32(rlb_SelectArea.Items[index].Value);
                                _obj_smhr_Inspection_Area.INSPECTION_AREA_MODIFIED_BY = Convert.ToInt32(Session["USER_ID"]);
                                _obj_smhr_Inspection_Area.INSPECTION_AREA_MODIFIEDDATE = DateTime.Now;
                                status = BLL.set_Inspection_Area(_obj_smhr_Inspection_Area);
                            }
                        }

                        if (status == true)
                        {
                            BLL.ShowMessage(this, "Information Updated Successfully");
                        }
                    }
                    break;

                case "BTN_SUBMIT":


                    if (rcmb_Employees.SelectedIndex == 0)
                    {
                        BLL.ShowMessage(this, "Please Select Assigned To");
                        rcmb_Employees.Focus();
                        return;
                    }
                    int areaCount = 0;

                    _obj_smhr_schedule_Inspection = new SMHR_INSPECTION_SCHEDULE();
                    _obj_smhr_schedule_Inspection.OPERATION = operation.Insert;
                    _obj_smhr_schedule_Inspection.INSPECTION_SCHEDULE_INSPECTION_ID = Convert.ToInt32(rad_InspectionName.SelectedValue);
                    _obj_smhr_schedule_Inspection.INSPECTION_SCHEDULE_ASSIGNED_TO = Convert.ToInt32(rcmb_Employees.SelectedValue);
                    _obj_smhr_schedule_Inspection.INSPECTION_SCHEDULE_FROMDATE = Convert.ToDateTime(rdtp_FromDate.SelectedDate);
                    _obj_smhr_schedule_Inspection.INSPECTION_SCHEDULE_TODATE = Convert.ToDateTime(rdtp_ToDate.SelectedDate);
                    _obj_smhr_schedule_Inspection.INSPECTION_SCHEDULE_FROMTIME = Convert.ToDateTime(rtp_FromTime.SelectedDate.Value.ToShortTimeString());
                    _obj_smhr_schedule_Inspection.INSPECTION_SCHEDULE_TOTIME = Convert.ToDateTime(rtp_ToTime.SelectedDate.Value.ToShortTimeString());
                    _obj_smhr_schedule_Inspection.INSPECTION_SCHEDULE_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_schedule_Inspection.INSPECTION_SCHEDULE_CREATEDDATE = DateTime.Now;
                    _obj_smhr_schedule_Inspection.BUID = Convert.ToInt32(rcmb_EmpReg_BU.SelectedValue);

                    dtSchInsptnExists = BLL.checkInspectionScheduleexistsbyBuID(_obj_smhr_schedule_Inspection);

                    if (dtSchInsptnExists.Rows.Count == 0)
                    {
                        status = BLL.set_Inspection(_obj_smhr_schedule_Inspection);

                        if (status == true)
                        {
                            identityid = BLL.get_Identity_value(_obj_smhr_schedule_Inspection);
                        }
                        if (identityid != null)
                        {
                            if (identityid.Rows.Count > 0)
                            {
                                _obj_smhr_Inspection_Area.OPERATION = operation.Insert;
                                //_obj_smhr_Inspection_Area.INSPECTION_AREA_ISCOMPLIANT = false;
                                for (int index = 0; index <= rlb_SelectArea.Items.Count - 1; index++)
                                {
                                    if (rlb_SelectArea.Items[index].Checked == true)
                                    {
                                        areaCount++;

                                        _obj_smhr_Inspection_Area.INSPECTION_AREA_SCHEDULE_ID = Convert.ToInt32(identityid.Rows[0]["INSPECTION_SCHEDULE_ID"].ToString());
                                        _obj_smhr_Inspection_Area.AREA_ID = Convert.ToInt32(rlb_SelectArea.Items[index].Value);
                                        _obj_smhr_Inspection_Area.INSPECTION_AREA_CREATED_BY = Convert.ToInt32(Session["USER_ID"]);
                                        _obj_smhr_Inspection_Area.INSPECTION_AREA_CREATEDDATE = DateTime.Now;
                                        status = BLL.set_Inspection_Area(_obj_smhr_Inspection_Area);
                                    }
                                }
                                if (areaCount == 0)
                                {
                                    BLL.ShowMessage(this, "Please Select Area");
                                    rlb_SelectArea.Focus();
                                    return;
                                }
                            }
                        }
                        if (status == true)
                        {
                            BLL.ShowMessage(this, "Information Successfully Saved");
                        }
                    }
                    else
                    {
                        BLL.ShowMessage(this, "This Inspection Already Scheduled");
                        return;
                    }
                    break;
                default:
                    break;
            }
            Rm_HDPT_page.SelectedIndex = 0;
            LoadInspectionsGrid();
            Rg_InspectionsSchedules.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ScheduleInspections", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadAllInspectionValues()
    {
        try
        {
            _obj_SMHR_Inspection = new SMHR_INSPECTION();
            _obj_SMHR_Inspection.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            rad_InspectionName.DataSource = BLL.get_AllInspections(_obj_SMHR_Inspection); ;
            rad_InspectionName.DataTextField = "INSPECTION_NAME";
            rad_InspectionName.DataValueField = "INSPECTION_ID";
            rad_InspectionName.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ScheduleInspections", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            ClearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ScheduleInspections", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}