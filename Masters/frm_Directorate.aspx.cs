using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Masters_frm_Directorate : System.Web.UI.Page
{
    string strfilename2;
    DataSet ds = new DataSet();
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }
    SMHR_DIRECTORATE _obj_Smhr_Directorate;
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("DIRECTORATE");
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
                    Rg_Directorates.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
                Page.Validate();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Directorate", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    public void loadstatus()
    {
        try
        {
            Rcm_status.Items.Clear();
            SMHR_MASTERS _obj_smhr_masters = new SMHR_MASTERS();
            _obj_smhr_masters.MASTER_TYPE = "STATUS";
            _obj_smhr_masters.OPERATION = operation.Select;
            _obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);//as it is c data done nothing
            Rcm_status.DataSource = dt_Details;
            Rcm_status.DataTextField = "HR_MASTER_CODE";
            Rcm_status.DataValueField = "HR_MASTER_ID";
            Rcm_status.DataBind();
            Rcm_status.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Directorate", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void statuschanged_click(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {

    }
    private void LoadBusinessUnits()
    {
        try
        {
            //Business Unit
            SMHR_LOGININFO _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            ddl_BusinessUnit.Items.Clear();
            ddl_BusinessUnit.DataSource = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            ddl_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            ddl_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            ddl_BusinessUnit.DataBind();
            ddl_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Directorate", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void clearControls()
    {
        try
        {
            lbl_DirectorateID.Text = string.Empty;
            rtxt_DirectorateCode.Text = string.Empty;
            rtxt_DirectorateCode.Enabled = true;
            ddl_BusinessUnit.Enabled = true;
            ddl_Directorate.Enabled = true;
            rtxt_DirectorateName.Text = string.Empty;
            ddl_BusinessUnit.SelectedIndex = -1;
            ddl_Directorate.SelectedIndex = -1;
            btn_Save.Visible = false;
            Rcm_status.SelectedIndex = 0;
            btn_Update.Visible = false;
            Rm_CY_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Directorate", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            clearControls();
            LoadBusinessUnits();
            loadstatus();
            Rcm_status.Enabled = true;
            rtxt_DirectorateCode.Enabled = false;
            ddl_BusinessUnit.Enabled = false;
            ddl_Directorate.Enabled = true;
            DataTable dt = BLL.get_Directorate(new SMHR_DIRECTORATE(Convert.ToInt32(Convert.ToString(e.CommandArgument))));
            lbl_DirectorateID.Text = Convert.ToString(dt.Rows[0]["Directorate_ID"]);
            rtxt_DirectorateCode.Text = Convert.ToString(dt.Rows[0]["Directorate_CODE"]);
            rtxt_DirectorateName.Text = Convert.ToString(dt.Rows[0]["Directorate_NAME"]);
            ddl_BusinessUnit.SelectedValue = Convert.ToString(dt.Rows[0]["DIRECTORATE_BUSINESSUNIT_ID"]);
            ddl_BusinessUnit.SelectedIndex = Convert.ToInt32(ddl_BusinessUnit.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["DIRECTORATE_BUSINESSUNIT_ID"])));
            //Rcm_status.SelectedValue = Convert.ToString(dt.Rows[0]["DIRECTORATE_STATUS"]);
            Rcm_status.SelectedIndex = Convert.ToInt32(Rcm_status.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["DIRECTORATE_STATUS"])));
            //  Load_Directorate(Convert.ToInt32(ddl_BusinessUnit.SelectedValue));
            Load_DirectrateEdit(Convert.ToInt32(ddl_BusinessUnit.SelectedValue), Convert.ToInt32(e.CommandArgument));

            ddl_Directorate.SelectedValue = Convert.ToString(dt.Rows[0]["DIRECTORATE_PARENTDIRECTORATE_ID"]);
            //code for security
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Update.Visible = false;
            }
            else
            {
                btn_Update.Visible = true;
            }
            Rm_CY_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Directorate", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            clearControls();
            LoadBusinessUnits();
            loadstatus();
            Rcm_status.SelectedIndex = Rcm_status.Items.FindItemIndexByText(Convert.ToString("Active"));
            Rcm_status.Enabled = false;
            btn_Save.Visible = true;
            Rm_CY_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Directorate", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rg_Counties_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Directorate", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    public void LoadGrid()
    {
        try
        {
            _obj_Smhr_Directorate = new SMHR_DIRECTORATE();
            _obj_Smhr_Directorate.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT = BLL.get_Directorate(_obj_Smhr_Directorate);
            Rg_Directorates.DataSource = DT;
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Directorate", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_Smhr_Directorate = new SMHR_DIRECTORATE();

            _obj_Smhr_Directorate.DIRECTORATE_CODE = BLL.ReplaceQuote(rtxt_DirectorateCode.Text);
            _obj_Smhr_Directorate.DIRECTORATE_NAME = BLL.ReplaceQuote(rtxt_DirectorateName.Text);
            _obj_Smhr_Directorate.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            if (ddl_Directorate.SelectedValue != "0")
                _obj_Smhr_Directorate.DIRECTORATE_PARENTDIRECTORATE_ID = Convert.ToInt32(ddl_Directorate.SelectedValue);
            _obj_Smhr_Directorate.BUSINESSUNIT_ID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
            _obj_Smhr_Directorate.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_Directorate.CREATEDDATE = DateTime.Now;
            _obj_Smhr_Directorate.DIRECTORATE_STATUS = Convert.ToInt32(Rcm_status.SelectedItem.Value);
            _obj_Smhr_Directorate.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_Directorate.LASTMDFDATE = DateTime.Now;

            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_UPDATE":
                    _obj_Smhr_Directorate.DIRECTORATE_ID = Convert.ToInt32(lbl_DirectorateID.Text);

                    _obj_Smhr_Directorate.OPERATION = operation.Delete1;
                    if (Convert.ToString(Rcm_status.SelectedItem.Text.ToUpper()) == "INACTIVE")
                    {
                        DataTable DT_DETAIL = BLL.get_Directorate(_obj_Smhr_Directorate);
                        if (DT_DETAIL.Rows.Count > 0)
                        {
                            BLL.ShowMessage(this, "Directorate cannot be Inactive as it is assigned to Department "); return;
                        }
                        _obj_Smhr_Directorate.OPERATION = operation.Available;
                        DataTable dt_parent = BLL.get_Directorate(_obj_Smhr_Directorate);
                        if (dt_parent.Rows.Count > 0)
                        {

                            BLL.ShowMessage(this, "Directorate cannot be Inactive as it is Parent to Other Directorate "); return;
                        }
                    }

                    _obj_Smhr_Directorate.OPERATION = operation.Update;
                    if (BLL.set_Directorate(_obj_Smhr_Directorate))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Updated");

                    break;
                case "BTN_SAVE":
                    _obj_Smhr_Directorate.OPERATION = operation.FILLEMP_Edit;
                    if (Convert.ToString(BLL.get_Directorate(_obj_Smhr_Directorate).Rows[0]["Count"]) != "0")
                    {
                        BLL.ShowMessage(this, "Directorate Name Already Exists");
                        return;
                    }
                    _obj_Smhr_Directorate.OPERATION = operation.Insert;
                    if (BLL.set_Directorate(_obj_Smhr_Directorate))
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                default:
                    break;
            }
            Rm_CY_page.SelectedIndex = 0;
            LoadGrid();
            Rg_Directorates.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Directorate", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Directorate", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void ddl_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            Load_Directorate(Convert.ToInt32(ddl_BusinessUnit.SelectedValue));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Directorate", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Load_DirectrateEdit(int intBusinessUnit, int direct)
    {
        try
        {
            ddl_Directorate.Items.Clear();
            SMHR_DIRECTORATE _obj_Smhr_Directorate = new SMHR_DIRECTORATE();
            _obj_Smhr_Directorate.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Directorate.BUSINESSUNIT_ID = intBusinessUnit;
            _obj_Smhr_Directorate.DIRECTORATE_ID = direct;
            _obj_Smhr_Directorate.OPERATION = operation.Delete;
            ddl_Directorate.DataTextField = "DIRECTORATE_CODE";
            ddl_Directorate.DataValueField = "DIRECTORATE_ID";
            ddl_Directorate.DataSource = BLL.get_Directorate(_obj_Smhr_Directorate);
            ddl_Directorate.DataBind();
            ddl_Directorate.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Directorate", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Load_Directorate(int intBusinessUnit)
    {
        try
        {
            ddl_Directorate.Items.Clear();
            SMHR_DIRECTORATE _obj_Smhr_Directorate = new SMHR_DIRECTORATE();
            _obj_Smhr_Directorate.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Directorate.BUSINESSUNIT_ID = intBusinessUnit;
            _obj_Smhr_Directorate.OPERATION = operation.Check;
            ddl_Directorate.DataTextField = "DIRECTORATE_CODE";
            ddl_Directorate.DataValueField = "DIRECTORATE_ID";
            ddl_Directorate.DataSource = BLL.get_Directorate(_obj_Smhr_Directorate);
            ddl_Directorate.DataBind();
            ddl_Directorate.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Directorate", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}