using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Masters_frm_Areas : System.Web.UI.Page
{
    SMHR_AREA _obj_Smhr_Area;
    SMHR_BUSINESSUNIT _obj_SMHR_BusinessUnit;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_DEPARTMENT obj_SMHR_Department;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        try
        {

            if (!(IsPostBack))
            {
               
            //code for security privilage
            Session.Remove("WRITEFACILITY");
            SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();
            _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
            _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
            _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("AREAS");
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
                return;
            }


            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                Rg_Areas.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                BTN_SAVE.Visible = false;
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
                return;
            }
            LoadAreasGrid();
                //LoadBusinessUnit();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Areas", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Load_Directorate()
    {
        try
        {
            rad_Directorate.Items.Clear();
            if (Convert.ToString(Session["ORG_ID"]) != string.Empty)
            {
                if (rcmb_EmpReg_BU.SelectedIndex > 0)
                {
                    SMHR_DIRECTORATE _obj_Smhr_Directorate = new SMHR_DIRECTORATE();
                    _obj_Smhr_Directorate.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Smhr_Directorate.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_EmpReg_BU.SelectedValue);
                    DataTable DT = BLL.get_Directorate(_obj_Smhr_Directorate);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Areas", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadDivision()
    {
        try
        {
            if (rad_Department.SelectedValue != null)
            {
                rad_SubDepartment.Items.Clear();
                _obj_SMHR_BusinessUnit = new SMHR_BUSINESSUNIT();
                _obj_SMHR_BusinessUnit.OPERATION = operation.Select1;
                _obj_SMHR_BusinessUnit.BUID = Convert.ToInt32(rcmb_EmpReg_BU.SelectedValue);
                if (rad_Department.SelectedIndex > 0)
                {
                    _obj_SMHR_BusinessUnit.DEPARTMENT_ID = Convert.ToInt32(rad_Department.SelectedValue);
                }
                else
                {
                    _obj_SMHR_BusinessUnit.DEPARTMENT_ID = 0;
                }
                _obj_SMHR_BusinessUnit.DIRECTORATE_ID = Convert.ToInt32(rad_Directorate.SelectedValue);
                _obj_SMHR_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable Dt_Divisions = BLL.Get_Divisions(_obj_SMHR_BusinessUnit);
                if (Dt_Divisions.Rows.Count > 0)
                {

                    rad_SubDepartment.DataSource = Dt_Divisions;
                    rad_SubDepartment.DataTextField = "SMHR_DIV_CODE";
                    rad_SubDepartment.DataValueField = "SMHR_DIV_ID";
                    rad_SubDepartment.DataBind();
                }
                rad_SubDepartment.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            }
            else
                rad_SubDepartment.Items.Clear();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Areas", ex.StackTrace, DateTime.Now);
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

            if (rcmb_EmpReg_BU.SelectedIndex > 0)
            {
                Load_Directorate();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Areas", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rad_SubDepartment_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rad_SubDepartment.SelectedIndex > 0)
            {

            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Areas", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rad_Department_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rad_SubDepartment.ClearSelection();
            rad_SubDepartment.Items.Clear();
            rad_SubDepartment.Items.Insert(0, new RadComboBoxItem("Select", "0"));

            if (rad_Department.SelectedIndex > 0)
            {
                LoadDivision();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Areas", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rad_Directorate_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rad_Department.Items.Clear();
            rad_Department.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            rad_SubDepartment.Items.Clear();
            rad_SubDepartment.Items.Insert(0, new RadComboBoxItem("Select", "0"));

            if (rad_Directorate.SelectedIndex > 0)
            {
                LoadDepartment();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Areas", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadBusinessUnit()
    {
        try
        {
            _obj_SMHR_BusinessUnit = new SMHR_BUSINESSUNIT();
            try
            {
                if ((Convert.ToInt32(Session["EMP_ID"]) == 0))
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

                }
                else
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
                }
            }
            catch (Exception ex)
            {
                SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_jobrequisition", ex.StackTrace, DateTime.Now);
                Response.Redirect("~/Frm_ErrorPage.aspx");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Areas", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadDepartment()
    {
        try
        {
            if (rcmb_EmpReg_BU.SelectedIndex != 0)
            {
                obj_SMHR_Department = new SMHR_DEPARTMENT();
                obj_SMHR_Department.MODE = 7;
                obj_SMHR_Department.DIRECTORATE_ID = Convert.ToInt32(rad_Directorate.SelectedValue);
                obj_SMHR_Department.BUID = Convert.ToInt32(rcmb_EmpReg_BU.SelectedValue);
                DataTable dt = BLL.get_Department(obj_SMHR_Department);
                if (dt.Rows.Count > 0)
                {
                    //rfv_Department.Enabled = true;
                    rad_Department.DataSource = dt;
                    rad_Department.DataTextField = "DEPARTMENT_NAME";
                    rad_Department.DataValueField = "DEPARTMENT_ID";
                    rad_Department.DataBind();
                    rad_Department.Items.Insert(0, new RadComboBoxItem("Select"));
                }
                else
                {
                    //rfv_Department.Enabled = false;
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Areas", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void BTN_SAVE_Click(object sender, EventArgs e)
    {
        try
        {
            bool status = false;
            int buID = Convert.ToInt32(rcmb_EmpReg_BU.SelectedValue);
            DataTable dtAreaExists = new DataTable();

            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_SAVE":

                    _obj_Smhr_Area = new SMHR_AREA();
                    _obj_Smhr_Area.OPERATION = operation.Insert;
                    _obj_Smhr_Area.AREA_NAME = Convert.ToString(rad_AreaName.Text);
                    _obj_Smhr_Area.AREA_DESCRIPTION = rad_Description.Text;

                    _obj_Smhr_Area.AREA_CREATED_BY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_Smhr_Area.AREA_CREATED_DATE = DateTime.Now;
                    _obj_Smhr_Area.AREA_IS_ACTIVE = Convert.ToBoolean(rad_IsActive.Checked);

                    if (buID != 0)
                        _obj_Smhr_Area.AREA_BUSINESSUNIT_ID = buID;
                    else
                    {
                        BLL.ShowMessage(this, "Please Select Business Unit");
                        return;
                    }

                    if (rad_Directorate.SelectedIndex > 0)
                    {
                        _obj_Smhr_Area.AREA_DIRECTORATE_ID = Convert.ToInt32(rad_Directorate.SelectedValue);
                    }
                    else
                    {
                        _obj_Smhr_Area.AREA_DIRECTORATE_ID = 0;
                    }
                    if (rad_Department.SelectedIndex > 0)
                    {
                        _obj_Smhr_Area.AREA_DEPARTMENT_ID = Convert.ToInt32(rad_Department.SelectedValue);
                    }
                    else
                    {
                        _obj_Smhr_Area.AREA_DEPARTMENT_ID = 0;
                    }
                    if (rad_SubDepartment.SelectedIndex > 0)
                    {
                        _obj_Smhr_Area.AREA_SUBDEPARTMENT_ID = Convert.ToInt32(rad_SubDepartment.SelectedValue);
                    }
                    else
                    {
                        _obj_Smhr_Area.AREA_SUBDEPARTMENT_ID = 0;
                    }
                    _obj_Smhr_Area.AREA_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_EmpReg_BU.SelectedValue);

                    dtAreaExists = BLL.checkAreaexistsbyBuID(_obj_Smhr_Area);

                    if (dtAreaExists.Rows.Count == 0)
                    {
                        status = BLL.set_Areas(_obj_Smhr_Area);

                        if (status == true)
                        {
                            BLL.ShowMessage(this, "Information Successfully Saved");
                        }
                    }
                    else
                    {
                        BLL.ShowMessage(this, "This Area Already Exists");
                        return;
                    }

                    break;

                case "BTN_UPDATE":
                    _obj_Smhr_Area = new SMHR_AREA(); ;
                    _obj_Smhr_Area.OPERATION = operation.Update;
                    _obj_Smhr_Area.AREA_NAME = Convert.ToString(rad_AreaName.Text);
                    _obj_Smhr_Area.AREA_DESCRIPTION = rad_Description.Text;
                    _obj_Smhr_Area.AREA_DIRECTORATE_ID = Convert.ToInt32(rad_Directorate.SelectedValue);
                    if (rad_Department.SelectedIndex > 0)
                    {
                        _obj_Smhr_Area.AREA_DEPARTMENT_ID = Convert.ToInt32(rad_Department.SelectedValue);
                    }
                    else
                    {
                        _obj_Smhr_Area.AREA_DEPARTMENT_ID = 0;
                    }
                    if (rad_SubDepartment.SelectedIndex > 0)
                    {
                        _obj_Smhr_Area.AREA_SUBDEPARTMENT_ID = Convert.ToInt32(rad_SubDepartment.SelectedValue);
                    }
                    else
                    {
                        _obj_Smhr_Area.AREA_SUBDEPARTMENT_ID = 0;
                    }
                    _obj_Smhr_Area.AREA_MODIFIED_BY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_Smhr_Area.AREA_MODIFIED_DATE = DateTime.Now;
                    _obj_Smhr_Area.AREA_ID = Convert.ToInt32(lbl_AreaID.Text);
                    _obj_Smhr_Area.AREA_IS_ACTIVE = Convert.ToBoolean(rad_IsActive.Checked);
                    _obj_Smhr_Area.AREA_DIRECTORATE_ID = Convert.ToInt32(rad_Directorate.SelectedValue);

                    if (Convert.ToString(rad_Department.SelectedValue) != "")
                        _obj_Smhr_Area.AREA_DEPARTMENT_ID = Convert.ToInt32(rad_Department.SelectedValue);
                    else
                        _obj_Smhr_Area.AREA_DEPARTMENT_ID = 0;

                    _obj_Smhr_Area.AREA_SUBDEPARTMENT_ID = Convert.ToInt32(rad_SubDepartment.SelectedValue);
                    _obj_Smhr_Area.AREA_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_EmpReg_BU.SelectedValue);

                    if (buID != 0)
                        _obj_Smhr_Area.AREA_BUSINESSUNIT_ID = buID;
                    else
                    {
                        BLL.ShowMessage(this, "Please Select Business Unit");
                        return;
                    }

                    status = BLL.set_Areas(_obj_Smhr_Area);
                    if (status == true)
                    {
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    }

                    break;
            }
            Rm_HDPT_page.SelectedIndex = 0;
            LoadAreasGrid();
            Rg_Areas.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Areas", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Areas", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Edit(object sender, CommandEventArgs e)
    {
        try
        {
            ClearControls();
            _obj_Smhr_Area = new SMHR_AREA();
            rcmb_EmpReg_BU.Enabled = false;
            rad_Directorate.Enabled = false;
            rad_Department.Enabled = false;
            rad_SubDepartment.Enabled = false;
            rad_AreaName.Enabled = false;
            rad_Description.Enabled = true;
            rad_IsActive.Enabled = true;
            _obj_Smhr_Area.AREA_ID = Convert.ToInt32(e.CommandArgument);
            DataTable dt = BLL.get_Area(_obj_Smhr_Area);
            LoadBusinessUnit();
            lbl_AreaID.Text = Convert.ToString(dt.Rows[0]["AREA_ID"]);
            rad_AreaName.Text = Convert.ToString(dt.Rows[0]["Area_Name"]);
            rad_IsActive.Checked = Convert.ToBoolean(dt.Rows[0]["Area_IS_ACTIVE"]);
            rcmb_EmpReg_BU.SelectedValue = Convert.ToString(dt.Rows[0]["BUSINESSUNIT_ID"]);
            Load_Directorate();

            if (Convert.ToInt32(dt.Rows[0]["AREA_DIRECTORATE_ID"]) != 0)
                rad_Directorate.SelectedValue = Convert.ToString(dt.Rows[0]["AREA_DIRECTORATE_ID"]);
            else
                rad_Directorate.SelectedValue = Convert.ToString(0);

            LoadDepartment();
            rad_Department.SelectedValue = Convert.ToString(dt.Rows[0]["AREA_DEPARTMENT_ID"]);
            LoadDivision();
            rad_SubDepartment.SelectedValue = Convert.ToString(dt.Rows[0]["AREA_SUBDEPARTMENT_ID"]);
            rad_Description.Text = Convert.ToString(dt.Rows[0]["AREA_DESCRIPTION"]);
            Rm_HDPT_page.SelectedIndex = 1;
            rad_IsActive.Enabled = true;
            BTN_SAVE.Visible = false;
            btn_Update.Visible = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Areas", ex.StackTrace, DateTime.Now);
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
            rad_AreaName.Text = string.Empty;
            BTN_SAVE.Visible = false;
            rad_IsActive.Checked = false;
            Rm_HDPT_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Areas", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            ClearControls();
            rad_AreaName.Enabled = true;
            rcmb_EmpReg_BU.ClearSelection();
            LoadBusinessUnit();
            rcmb_EmpReg_BU.Enabled = true;
            rad_IsActive.Enabled = true;
            rad_SubDepartment.Enabled = true;
            rad_Department.Enabled = true;
            rad_Directorate.Enabled = true;
            BTN_SAVE.Visible = true;
            btn_Cancel.Visible = true;
            btn_Update.Visible = false;
            rad_IsActive.Checked = true;
            rad_IsActive.Enabled = false;
            rad_Description.Text = string.Empty;
            rad_Description.Enabled = true;
            Rm_HDPT_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Areas", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadAreasGrid()
    {
        try
        {
            _obj_Smhr_Area = new SMHR_AREA();
            _obj_Smhr_Area.OPERATION = operation.GET_ALLAREAS;
            _obj_Smhr_Area.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            Rg_Areas.DataSource = BLL.get_AllAreas(_obj_Smhr_Area);
            //Rg_Areas.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Areas", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rg_Areas_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadAreasGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Areas", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}