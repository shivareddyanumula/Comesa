using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Masters_frm_Assets_Master : System.Web.UI.Page
{
    SMHR_DEPARTMENT _obj_SMHR_Department;
    SMHR_ASSET_MASTER _obj_SMHR_AssetMaster;
    static DataTable dt_Details = new DataTable();
    SMHR_BUSINESSUNIT _obj_SMHR_BusinessUnit;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }
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
            _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Asset Type");//COUNTRY");
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
                RG_Asset_Master.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
                return;
            }
            Page.Validate();
            LoadAssetsGrid();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Assets_Master", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    public void LoadAssetsGrid()
    {
        try
        {
            _obj_SMHR_AssetMaster = new SMHR_ASSET_MASTER();
            _obj_SMHR_AssetMaster.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_AssetMaster.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            dt_Details = BLL.get_AssetMaster_Details(_obj_SMHR_AssetMaster);
            if (dt_Details != null)
            {
                if (dt_Details.Rows.Count > 0)
                {
                    RG_Asset_Master.DataSource = dt_Details;
                }
                else
                {
                    DataTable dt = new DataTable();
                    RG_Asset_Master.DataSource = dt;
                }
            }
            else
            {
                DataTable dt = new DataTable();
                RG_Asset_Master.DataSource = dt;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Assets_Master", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            btn_Save.Visible = false;
            btn_Update.Visible = true;
            rm_MR_Page.SelectedIndex = 1;
            chk_IsAssetActive.Enabled = true;

            _obj_SMHR_AssetMaster = new SMHR_ASSET_MASTER();
            _obj_SMHR_AssetMaster.ASSET_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            _obj_SMHR_AssetMaster.DEPARTMENT_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_AssetMaster.OPERATION = operation.Select;
            DataTable dt = BLL.get_AssetMasterDetailsByAsset_ID(_obj_SMHR_AssetMaster);

            if (dt.Rows.Count > 0)
            {
                LoadBusinessUnit();
                rad_BusinessUnit.SelectedIndex = rad_BusinessUnit.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["BusinessUnit_id"]));
                Load_Directorate();
                rad_Directorate.SelectedIndex = rad_Directorate.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["Directorate_Id"]));
                LoadDepartment();
                lbl_Asset_ID.Text = dt.Rows[0]["ASSET_ID"].ToString();
                rtxt_AssetCode.Text = dt.Rows[0]["ASSET_NAME"].ToString();
                rtxt_AssetCode.Enabled = false;
                rtxt_AssetName.Text = dt.Rows[0]["ASSET_DESCRIPTION"].ToString();
                rtxt_AssetName.Enabled = false;
                rad_AssetDepartment.SelectedIndex = rad_AssetDepartment.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["ASSET_DEPARTMENT_ID"]));
                rad_AssetDepartment.Enabled = false;
                chk_IsAssetActive.Checked = Convert.ToBoolean(dt.Rows[0]["ASSET_IS_ACTIVE"].ToString());
                rad_BusinessUnit.Enabled = false;
                rad_Directorate.Enabled = false;

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Assets_Master", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void clearControls()
    {
        rad_Directorate.Items.Clear();
        rtxt_AssetName.Text = string.Empty;
        rtxt_AssetCode.Text = string.Empty;
        rad_AssetDepartment.ClearSelection();
        chk_IsAssetActive.Checked = false;
        rm_MR_Page.SelectedIndex = 1;
    }
    protected void rad_BusinessUnit_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rad_BusinessUnit.SelectedIndex > 0)
            {
                Load_Directorate();
                rad_Directorate.Focus();
            }
            else
            {
                rad_Directorate.Items.Clear();
                rad_Directorate.Items.Insert(0, new RadComboBoxItem("Select"));
                rad_AssetDepartment.Items.Clear();
                rad_AssetDepartment.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Assets_Master", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rad_Directorate_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rad_Directorate.SelectedIndex > 0)
            {
                LoadDepartment();
                rad_AssetDepartment.Focus();
            }
            else
            {
                rad_AssetDepartment.Items.Clear();
                rad_AssetDepartment.Items.Insert(0, new RadComboBoxItem("Select"));
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Assets_Master", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadBusinessUnit()
    {
        _obj_SMHR_BusinessUnit = new SMHR_BUSINESSUNIT();
        try
        {
            //if ((Convert.ToInt32(Session["EMP_ID"]) == 0))
            // {
            rad_BusinessUnit.Items.Clear();
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            if (dt_BUDetails.Rows.Count > 0)
            {
                rad_BusinessUnit.DataSource = dt_BUDetails;
                rad_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
                rad_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
                rad_BusinessUnit.DataBind();
            }
            rad_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));

            //}        
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Assets_Master", ex.StackTrace, DateTime.Now);
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
                if (rad_BusinessUnit.SelectedIndex > 0)
                {
                    SMHR_DIRECTORATE _obj_Smhr_Directorate = new SMHR_DIRECTORATE();
                    _obj_Smhr_Directorate.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Smhr_Directorate.BUSINESSUNIT_ID = Convert.ToInt32(rad_BusinessUnit.SelectedValue);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Assets_Master", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadDepartment()
    {
        #region MyRegion
        //try
        //{
        //    _obj_SMHR_Department = new SMHR_DEPARTMENT();
        //    _obj_SMHR_Department.MODE = 20;
        //    _obj_SMHR_Department.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
        //    dt_Details = BLL.get_Department(_obj_SMHR_Department);
        //    if (dt_Details.Rows.Count != 0)
        //    {
        //        rad_AssetDepartment.DataSource = dt_Details;
        //        rad_AssetDepartment.DataTextField = "DEPARTMENT_NAME";
        //        rad_AssetDepartment.DataValueField = "DEPARTMENT_ID";
        //        rad_AssetDepartment.DataBind();
        //        rad_AssetDepartment.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        //    }
        //}
        //catch (Exception ex)
        //{
        //    SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Assets_Master", ex.StackTrace, DateTime.Now);
        //    Response.Redirect("~/Frm_ErrorPage.aspx");
        //    return;
        //} 
        #endregion
        try
        {
            if (rad_BusinessUnit.SelectedIndex != 0)
            {
                _obj_SMHR_Department = new SMHR_DEPARTMENT();
                _obj_SMHR_Department.MODE = 7;
                _obj_SMHR_Department.DIRECTORATE_ID = Convert.ToInt32(rad_Directorate.SelectedValue);
                _obj_SMHR_Department.BUID = Convert.ToInt32(rad_BusinessUnit.SelectedValue);
                DataTable dt = BLL.get_Department(_obj_SMHR_Department);
                rad_AssetDepartment.DataSource = dt;
                rad_AssetDepartment.DataTextField = "DEPARTMENT_NAME";
                rad_AssetDepartment.DataValueField = "DEPARTMENT_ID";
                rad_AssetDepartment.DataBind();
                rad_AssetDepartment.Items.Insert(0, new RadComboBoxItem("Select"));
            }
            else
            {
                rad_AssetDepartment.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Assets_Master", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void RG_Asset_Master_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadAssetsGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Assets_Master", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        bool status = false;
        try
        {
            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_SAVE":
                    _obj_SMHR_AssetMaster = new SMHR_ASSET_MASTER();
                    _obj_SMHR_AssetMaster.OPERATION = operation.Insert;
                    _obj_SMHR_AssetMaster.ASSET_NAME = Convert.ToString(rtxt_AssetCode.Text);
                    _obj_SMHR_AssetMaster.ASSET_DESCRIPTION = Convert.ToString(rtxt_AssetName.Text);
                    _obj_SMHR_AssetMaster.ASSET_DEPARTMENT_ID = Convert.ToInt32(rad_AssetDepartment.SelectedValue);
                    _obj_SMHR_AssetMaster.ASSET_IS_ACTIVE = Convert.ToBoolean(chk_IsAssetActive.Checked);
                    _obj_SMHR_AssetMaster.ASSET_CREATED_BY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_SMHR_AssetMaster.ASSET_CREATED_DATE = DateTime.Now;
                    _obj_SMHR_AssetMaster.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    if (Convert.ToString(BLL.check_AssetCodeExists(_obj_SMHR_AssetMaster).Rows[0]["ASSET_COUNT"]) != "0")
                    {
                        BLL.ShowMessage(this, "Asset Code Already Exists");
                        return;
                    }
                    if (Convert.ToString(BLL.check_AssetExists(_obj_SMHR_AssetMaster).Rows[0]["ASSET_COUNT"]) != "0")
                    {
                        BLL.ShowMessage(this, "Asset Name With this Code Already Exists");
                        return;
                    }
                    status = BLL.set_AssetDetails(_obj_SMHR_AssetMaster);
                    if (status == true)
                    {
                        rm_MR_Page.SelectedIndex = 0;
                        LoadAssetsGrid();
                        RG_Asset_Master.DataBind();
                        rm_MR_Page.SelectedIndex = 0;
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    }
                    break;
                case "BTN_UPDATE":
                    DataTable dt_EmployeeAssets = new DataTable();
                    _obj_SMHR_AssetMaster = new SMHR_ASSET_MASTER();
                    _obj_SMHR_AssetMaster.OPERATION = operation.Update;
                    _obj_SMHR_AssetMaster.ASSET_ID = Convert.ToInt32(lbl_Asset_ID.Text);
                    _obj_SMHR_AssetMaster.ASSET_NAME = Convert.ToString(rtxt_AssetCode.Text);
                    _obj_SMHR_AssetMaster.ASSET_DESCRIPTION = Convert.ToString(rtxt_AssetName.Text);
                    _obj_SMHR_AssetMaster.ASSET_DEPARTMENT_ID = Convert.ToInt32(rad_AssetDepartment.SelectedValue);
                    dt_EmployeeAssets = BLL.check_AssetAllocationToEmployees(_obj_SMHR_AssetMaster);
                    if (chk_IsAssetActive.Checked == false)
                    {
                        DataRow[] dr_Assetexits = dt_EmployeeAssets.Select("items= " + Convert.ToInt32(lbl_Asset_ID.Text));
                        if (dr_Assetexits.Length > 0)
                        {
                            BLL.ShowMessage(this, "Cannot Deactivate the Asset as it is assigned to the Employee");
                            chk_IsAssetActive.Checked = true;
                            return;
                        }
                    }
                    _obj_SMHR_AssetMaster.ASSET_IS_ACTIVE = Convert.ToBoolean(chk_IsAssetActive.Checked);
                    _obj_SMHR_AssetMaster.ASSET_MODIFIED_BY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_SMHR_AssetMaster.ASSET_MODIFIED_DATE = DateTime.Now;
                    status = BLL.set_AssetDetails(_obj_SMHR_AssetMaster);
                    if (status == true)
                    {
                        rm_MR_Page.SelectedIndex = 0;
                        LoadAssetsGrid();
                        RG_Asset_Master.DataBind();
                        rm_MR_Page.SelectedIndex = 0;
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    }
                    break;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Assets_Master", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void lnk_Add_Click(object sender, EventArgs e)
    {
        try
        {
            btn_Update.Visible = false;
            btn_Save.Visible = true;
            clearControls();
            rad_BusinessUnit.Enabled = true;
            rtxt_AssetCode.Enabled = true;
            rtxt_AssetName.Enabled = true;
            rad_AssetDepartment.Enabled = true;
            rad_Directorate.Enabled = true;
            chk_IsAssetActive.Checked = true;
            chk_IsAssetActive.Enabled = false;
            rad_AssetDepartment.Items.Clear();
            LoadBusinessUnit();
            Load_Directorate();
            LoadAssetsGrid();
            LoadDepartment();

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Assets_Master", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            rm_MR_Page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Assets_Master", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}