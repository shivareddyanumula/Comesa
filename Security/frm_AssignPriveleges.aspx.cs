using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using Telerik.Web.UI;
public partial class Security_frm_AssignPriveleges : System.Web.UI.Page
{
    SMHR_LOGINTYPE _obj_LoginType;
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("ASSIGNPRIVILEGES");
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
                    Rg_AssignPrivilage.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AssignPriveleges", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            loadDropdown();
            get_forms();
            clearControls();
            DataTable dt = BLL.get_AssignPrivilage(new SMHR_TYPESECURITY(Convert.ToInt32(Convert.ToString(e.CommandArgument))));
            lbl_AssignPrivilageID.Text = Convert.ToString(dt.Rows[0]["TYPSEC_ID"]);
            rcmb_Module.SelectedIndex = rcmb_Module.Items.FindItemIndexByText(Convert.ToString(dt.Rows[0]["SMHR_MODULE_NAME"]));
            rcmb_Module_SelectedIndexChanged(null, null);
            rcmb_AssignPrivilagesForms.SelectedIndex = rcmb_AssignPrivilagesForms.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["TYPSEC_FORMS_ID"]));
            rcmb_AssignPrivilageUserGroups.SelectedIndex = rcmb_AssignPrivilageUserGroups.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["TYPSEC_LOGTYP_ID"]));
            chk_AssignPrivilageRead.Checked = Convert.ToBoolean(dt.Rows[0]["TYPSEC_READ"]);
            chk_AssignPrivilageWrite.Checked = Convert.ToBoolean(dt.Rows[0]["TYPSEC_WRITE"]);
            //disabling comboboxes
            rcmb_AssignPrivilageUserGroups.Enabled = false;
            rcmb_Module.Enabled = false;
            rcmb_AssignPrivilagesForms.Enabled = false;
            //code for security
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Update.Visible = false;

            }

            else
            {
                btn_Update.Visible = true;
            }

            Rm_AP_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AssignPriveleges", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            loadDropdown();
            clearControls();
            btn_Save.Visible = true;
            Rm_AP_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AssignPriveleges", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void LoadGrid()
    {
        try
        {
            DataTable DT = BLL.get_AssignPrivilage(new SMHR_TYPESECURITY());
            Rg_AssignPrivilage.DataSource = DT;
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AssignPriveleges", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void loadDropdown()
    {
        try
        {
            rcmb_AssignPrivilageUserGroups.Items.Clear();
            _obj_LoginType = new SMHR_LOGINTYPE();
            _obj_LoginType.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_LoginType.OPERATION = operation.Select;
            DataTable dt = BLL.get_LoginType(_obj_LoginType);
            rcmb_AssignPrivilageUserGroups.DataSource = dt;
            rcmb_AssignPrivilageUserGroups.DataTextField = "LOGTYP_CODE";
            rcmb_AssignPrivilageUserGroups.DataValueField = "LOGTYP_ID";
            rcmb_AssignPrivilageUserGroups.DataBind();
            rcmb_AssignPrivilageUserGroups.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));


            //method to get module names
            rcmb_Module.Items.Clear();
            SMHR_FORMS _obj_Smhr_forms = new SMHR_FORMS();
            _obj_Smhr_forms.MODE = 2;
            rcmb_Module.DataSource = BLL.get_Modules(_obj_Smhr_forms);
            rcmb_Module.DataTextField = "SMHR_MODULE_NAME";
            rcmb_Module.DataValueField = "SMHR_MODULE_ID";
            rcmb_Module.DataBind();
            rcmb_Module.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AssignPriveleges", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void get_forms()
    {
        try
        {
            SMHR_FORMS _obj_Smhr_forms = new SMHR_FORMS();
            rcmb_AssignPrivilagesForms.Items.Clear();
            _obj_Smhr_forms.OPERATION = operation.Validate;
            _obj_Smhr_forms.FORMS_MODULE_ID = Convert.ToInt32(rcmb_Module.SelectedItem.Value);
            rcmb_AssignPrivilagesForms.DataSource = BLL.get_FormsbyModule(_obj_Smhr_forms);
            rcmb_AssignPrivilagesForms.DataTextField = "FORMS_NAME";
            rcmb_AssignPrivilagesForms.DataValueField = "FORMS_ID";
            rcmb_AssignPrivilagesForms.DataBind();
            rcmb_AssignPrivilagesForms.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AssignPriveleges", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_TYPESECURITY _obj_Smhr_AssignPrivilage = new SMHR_TYPESECURITY();
            _obj_Smhr_AssignPrivilage.TYPSEC_FORMS_ID = Convert.ToInt32(rcmb_AssignPrivilagesForms.SelectedItem.Value);
            _obj_Smhr_AssignPrivilage.TYPSEC_LOGTYP_ID = Convert.ToInt32(rcmb_AssignPrivilageUserGroups.SelectedItem.Value);
            _obj_Smhr_AssignPrivilage.MODULE_ID = Convert.ToInt32(rcmb_Module.SelectedItem.Value);
            _obj_Smhr_AssignPrivilage.TYPSEC_READ = chk_AssignPrivilageRead.Checked;
            _obj_Smhr_AssignPrivilage.TYPSEC_WRITE = chk_AssignPrivilageWrite.Checked;
            _obj_Smhr_AssignPrivilage.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_AssignPrivilage.CREATEDDATE = DateTime.Now;

            _obj_Smhr_AssignPrivilage.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_AssignPrivilage.LASTMDFDATE = DateTime.Now;

            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_UPDATE":
                    _obj_Smhr_AssignPrivilage.TYPSEC_ID = Convert.ToInt32(lbl_AssignPrivilageID.Text);
                    _obj_Smhr_AssignPrivilage.OPERATION = operation.Check;
                    if (Convert.ToString(BLL.get_AssignPrivilage(_obj_Smhr_AssignPrivilage).Rows[0]["Count"]) != "1")
                    {
                        BLL.ShowMessage(this, "This Combination of the Privilage Already Exists");
                        return;
                    }
                    _obj_Smhr_AssignPrivilage.OPERATION = operation.Update;
                    if (BLL.set_AssignPrivilage(_obj_Smhr_AssignPrivilage))
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");

                    break;
                case "BTN_SAVE":
                    _obj_Smhr_AssignPrivilage.OPERATION = operation.Check;
                    if (Convert.ToString(BLL.get_AssignPrivilage(_obj_Smhr_AssignPrivilage).Rows[0]["Count"]) != "0")
                    {
                        BLL.ShowMessage(this, "This Combination of the Privilage Already Exists");
                        return;
                    }
                    _obj_Smhr_AssignPrivilage.OPERATION = operation.Insert;
                    if (BLL.set_AssignPrivilage(_obj_Smhr_AssignPrivilage))
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                default:
                    break;
            }
            Rm_AP_page.SelectedIndex = 0;
            LoadGrid();
            Rg_AssignPrivilage.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AssignPriveleges", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void clearControls()
    {
        try
        {
            lbl_AssignPrivilageID.Text = string.Empty;
            rcmb_AssignPrivilagesForms.SelectedIndex = -1;
            rcmb_AssignPrivilageUserGroups.SelectedIndex = -1;
            chk_AssignPrivilageRead.Checked = false;
            chk_AssignPrivilageWrite.Checked = false;
            btn_Save.Visible = false;
            btn_Update.Visible = false;
            Rm_AP_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AssignPriveleges", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AssignPriveleges", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Rg_AssignPrivilage_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AssignPriveleges", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_Module_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            get_forms();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AssignPriveleges", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
