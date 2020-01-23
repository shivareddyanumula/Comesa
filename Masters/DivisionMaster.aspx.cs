using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using System.Text;
using Telerik.Web.UI;

public partial class Masters_DivisionMaster : System.Web.UI.Page
{
    SMHR_DIVISION _obj_Smhr_Division;
    SMHR_DEPARTMENT _obj_SMHR_Department;
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }
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
                    return;
                }


                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    Rg_Division.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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

                LoadCombos();
            }
            Page.Validate();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DivisionMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadCombos()
    {
        try
        {
            SMHR_BUSINESSUNIT _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
            SMHR_LOGININFO _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            ddl_BusinessUnit.DataSource = dt_BUDetails;
            ddl_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            ddl_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            ddl_BusinessUnit.DataBind();
            ddl_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DivisionMaster", ex.StackTrace, DateTime.Now);
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
                if (ddl_BusinessUnit.SelectedIndex > 0)
                {
                    SMHR_DIRECTORATE _obj_Smhr_Directorate = new SMHR_DIRECTORATE();
                    _obj_Smhr_Directorate.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Smhr_Directorate.BUSINESSUNIT_ID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DivisionMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    private void LoadDepartment()
    {
        try
        {
            if (ddl_BusinessUnit.SelectedIndex != 0)
            {
                _obj_SMHR_Department = new SMHR_DEPARTMENT();
                _obj_SMHR_Department.MODE = 7;
                // if (rad_Directorate.SelectedIndex > 0)
                // {
                _obj_SMHR_Department.DIRECTORATE_ID = Convert.ToInt32(rad_Directorate.SelectedValue);
                // }
                //else
                //{
                //    _obj_SMHR_Department.MODE = 16;
                //    _obj_SMHR_Department.DIRECTORATE_ID = 0;
                //}
                _obj_SMHR_Department.BUID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
                DataTable dt = BLL.get_Department(_obj_SMHR_Department);
                rad_Department.DataSource = dt;
                rad_Department.DataTextField = "DEPARTMENT_NAME";
                rad_Department.DataValueField = "DEPARTMENT_ID";
                rad_Department.DataBind();
                rad_Department.Items.Insert(0, new RadComboBoxItem("Select"));
            }
            else
            {
                rad_Department.Items.Clear();
                rad_Department.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DivisionMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void ddl_BusinessUnit_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (ddl_BusinessUnit.SelectedIndex > 0)
            {
                Load_Directorate();
            }
            else
            {
                rad_Directorate.Items.Clear();
                rad_Directorate.Items.Insert(0, new RadComboBoxItem("Select"));
                rad_Department.Items.Clear();
                rad_Department.Items.Insert(0, new RadComboBoxItem("Select"));
            }
            //    LoadDepartment();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DivisionMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rad_Directorate_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rad_Department.Items.Clear();
            LoadDepartment();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DivisionMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            clearControls();


            rtxt_SubDepartment.Enabled = false;
            ddl_BusinessUnit.Enabled = false;
            DataTable dt = BLL.get_Division(new SMHR_DIVISION(Convert.ToInt32(Convert.ToString(e.CommandArgument))));
            LoadCombos();
            ddl_BusinessUnit.SelectedIndex = ddl_BusinessUnit.Items.FindItemIndexByText(Convert.ToString(dt.Rows[0]["BUSINESSUNIT_CODE"]));
            lbl_DivisionID.Text = Convert.ToString(dt.Rows[0]["SMHR_DIV_ID"]);
            rtxt_SubDepartment.Text = Convert.ToString(dt.Rows[0]["SMHR_DIV_CODE"]);
            rtxt_CountryName.Text = Convert.ToString(dt.Rows[0]["SMHR_DIV_DESC"]);
            Load_Directorate();
            rad_Directorate.SelectedIndex = rad_Directorate.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["DIRECTORATE_ID"]));
            LoadDepartment();
            rad_Department.SelectedIndex = rad_Department.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["SMHR_Department_id"]));
            rad_Directorate.Enabled = false;
            rad_Department.Enabled = false;
            //code for security
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Update.Visible = false;
            }
            else
            {
                btn_Update.Visible = true;
            }
            Rm_Division_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DivisionMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            clearControls();
            btn_Save.Visible = true;
            rad_Department.Enabled = true;
            rad_Directorate.Enabled = true;
            Rm_Division_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DivisionMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    public void LoadGrid()
    {
        try
        {
            SMHR_DIVISION _obj_Smhr_Division = new SMHR_DIVISION();
            _obj_Smhr_Division.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT = BLL.get_Division(_obj_Smhr_Division);
            Rg_Division.DataSource = DT;

            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DivisionMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_DIVISION _obj_Smhr_Division = new SMHR_DIVISION();
            _obj_Smhr_Division.DIVISION_CODE = BLL.ReplaceQuote(rtxt_SubDepartment.Text);
            _obj_Smhr_Division.DIVISION_DESCRIPTION = BLL.ReplaceQuote(rtxt_CountryName.Text);
            _obj_Smhr_Division.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Division.BUID = Convert.ToInt32(ddl_BusinessUnit.SelectedItem.Value);
            _obj_Smhr_Division.DEPARTMENT_ID = Convert.ToInt32(rad_Department.SelectedItem.Value);
            _obj_Smhr_Division.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_Division.CREATEDDATE = DateTime.Now;

            _obj_Smhr_Division.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_Division.LASTMDFDATE = DateTime.Now;

            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_UPDATE":
                    _obj_Smhr_Division.DIVISION_ID = Convert.ToInt32(lbl_DivisionID.Text);
                    _obj_Smhr_Division.OPERATION = operation.Update;
                    if (BLL.set_Division(_obj_Smhr_Division))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Updated");

                    break;
                case "BTN_SAVE":
                    _obj_Smhr_Division.OPERATION = operation.Check;
                    if (Convert.ToString(BLL.get_Division(_obj_Smhr_Division).Rows[0]["Count"]) != "0")
                    {
                        BLL.ShowMessage(this, "SubDepartment Already Exists");
                        return;
                    }
                    _obj_Smhr_Division.OPERATION = operation.Insert;
                    if (BLL.set_Division(_obj_Smhr_Division))
                    {
                        SMHR_DEPARTMENT_DIVISION_MAPPING _obj_Smhr_DDM = new SMHR_DEPARTMENT_DIVISION_MAPPING();
                        SMHR_DIVISION _obj_Smhr_Divisions = new SMHR_DIVISION();
                        _obj_Smhr_Division.OPERATION = operation.D;
                        DataTable dt = new DataTable();
                        dt = BLL.get_DivisionMapping(_obj_Smhr_Division);
                        if (dt.Rows.Count > 0)
                        {
                            _obj_Smhr_DDM.DIVISION_ID = Convert.ToInt32(dt.Rows[0][0]);
                        }
                        _obj_Smhr_DDM.Type = "Division";
                        _obj_Smhr_DDM.ERP_CODE = "0";
                        _obj_Smhr_DDM.OPERATION = operation.Approve;
                        _obj_Smhr_DDM.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                        _obj_Smhr_DDM.CREATEDDATE = DateTime.Now;

                        _obj_Smhr_DDM.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                        _obj_Smhr_DDM.LASTMDFDATE = DateTime.Now;

                        BLL.set_DivisionMapping(_obj_Smhr_DDM);
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    }
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                default:
                    break;
            }
            Rm_Division_page.SelectedIndex = 0;
            LoadGrid();
            Rg_Division.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DivisionMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void clearControls()
    {
        try
        {
            lbl_DivisionID.Text = string.Empty;
            rtxt_SubDepartment.Text = string.Empty;
            rtxt_SubDepartment.Enabled = true;
            rtxt_CountryName.Text = string.Empty;
            ddl_BusinessUnit.SelectedIndex = 0;
            rad_Directorate.Items.Clear();
            rad_Directorate.Items.Insert(0, new RadComboBoxItem("Select"));
            rad_Department.Items.Clear();
            rad_Department.Items.Insert(0, new RadComboBoxItem("Select"));
            btn_Save.Visible = false;
            btn_Update.Visible = false;
            Rm_Division_page.SelectedIndex = 0;
            rtxt_SubDepartment.Enabled = true;
            ddl_BusinessUnit.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DivisionMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DivisionMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rg_Countries_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DivisionMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

}
