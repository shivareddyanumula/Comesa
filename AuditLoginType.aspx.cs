﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using Telerik.Web.UI;

public partial class AuditLoginType : System.Web.UI.Page
{
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("User Group");//USERGROUP");
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
                    Rg_LoginType.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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

                rmpAuditDetails.Visible = true;
                rmpAuditDetails.SelectedIndex = 0;

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LoginType", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    //protected override void InitializeCulture()
    //{
    //    BLL.SetCulture_Theme(Page, Request);
    //    base.InitializeCulture();
    //}
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            clearControls();

            DataTable dt = BLL.get_LoginType(new SMHR_LOGINTYPE(Convert.ToInt32(Convert.ToString(e.CommandArgument))));
            rtxt_LoginTypeCode.Enabled = false;
            lbl_LoginTypeID.Text = Convert.ToString(dt.Rows[0]["LOGTYP_ID"]);
            rtxt_LoginTypeCode.Text = Convert.ToString(dt.Rows[0]["LOGTYP_CODE"]);
            rtxt_LoginTypeName.Text = Convert.ToString(dt.Rows[0]["LOGTYP_DESC"]);
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Update.Visible = false;
            }
            else
            {
                btn_Update.Visible = true;

            }
            Rm_LT_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LoginType", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            clearControls();
            btn_Save.Visible = true;
            Rm_LT_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LoginType", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    public void LoadGrid()
    {
        try
        {
            SMHR_LOGINTYPE _obj_Smhr_LoginInfo = new SMHR_LOGINTYPE();
            _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT = BLL.get_LoginType(_obj_Smhr_LoginInfo);
            Rg_LoginType.DataSource = DT;
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LoginType", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_LOGINTYPE _obj_Smhr_LoginType = new SMHR_LOGINTYPE();
            _obj_Smhr_LoginType.LOGTYP_CODE = BLL.ReplaceQuote(rtxt_LoginTypeCode.Text.ToUpper());
            _obj_Smhr_LoginType.LOGTYP_DESC = BLL.ReplaceQuote(rtxt_LoginTypeName.Text);

            _obj_Smhr_LoginType.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_LoginType.CREATEDDATE = DateTime.Now;

            _obj_Smhr_LoginType.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_LoginType.LASTMDFDATE = DateTime.Now;

            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_UPDATE":
                    _obj_Smhr_LoginType.LOGTYP_ID = Convert.ToInt32(lbl_LoginTypeID.Text);
                    _obj_Smhr_LoginType.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Smhr_LoginType.OPERATION = operation.Check;

                    if (Convert.ToString(BLL.get_LoginType(_obj_Smhr_LoginType).Rows[0]["Count"]) != "1")
                    {
                        BLL.ShowMessage(this, "LoginType with this Code Already Exists");
                        return;
                    }

                    _obj_Smhr_LoginType.OPERATION = operation.Update;
                    if (BLL.set_LoginType(_obj_Smhr_LoginType))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Updated");

                    break;
                case "BTN_SAVE":
                    _obj_Smhr_LoginType.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Smhr_LoginType.OPERATION = operation.Check;
                    if (Convert.ToString(BLL.get_LoginType(_obj_Smhr_LoginType).Rows[0]["Count"]) != "0")
                    {
                        BLL.ShowMessage(this, "LoginType with this Code Already Exists");
                        return;
                    }
                    _obj_Smhr_LoginType.OPERATION = operation.Insert;
                    _obj_Smhr_LoginType.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);//sravani
                    if (BLL.set_LoginType(_obj_Smhr_LoginType))
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                default:
                    break;
            }
            Rm_LT_page.SelectedIndex = 0;
            LoadGrid();
            Rg_LoginType.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LoginType", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void clearControls()
    {
        try
        {
            lbl_LoginTypeID.Text = string.Empty;
            rtxt_LoginTypeCode.Text = string.Empty;
            rtxt_LoginTypeName.Text = string.Empty;
            btn_Save.Visible = false;
            btn_Update.Visible = false;
            Rm_LT_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LoginType", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LoginType", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rg_LoginType_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LoginType", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rtsAuditDetails_TabClick(object sender, RadTabStripEventArgs e)
    {
        try
        {
            if (rtsAuditDetails.SelectedTab.Value == "MainScreenTab")
                rmpAuditDetails.SelectedIndex = 0;

            if (rtsAuditDetails.SelectedTab.Value == "AuditScreenTab")
            {
                rmpAuditDetails.SelectedIndex = 1;

                LoadAuditGrid();
                rgAudit.DataBind();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LoginType", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rgAudit_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadAuditGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LoginType", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void LoadAuditGrid()
    {
        try
        {
            rgAudit.DataSource = BLL.ExecuteQuery("EXEC USP_SMHR_AUDITTRAILS @OPERATION = 'GET_AUDIT_DATA', @SMHR_AUDIT_FORM_ID = 159");
            rgAudit.Visible = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LoginType", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}