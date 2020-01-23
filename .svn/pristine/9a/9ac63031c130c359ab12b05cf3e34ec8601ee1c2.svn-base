using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class HR_frm_Activity : System.Web.UI.Page
{
    SMHR_MASTERS _obj_Smhr_Masters;
    SMHR_ACTIVITY _obj_smhr_Activity;
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
                Rg_Actvities.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
            }
            Page.Validate();
            LoadGrid();
            LoadProtectiveUniforms();
        }
      }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Activity", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadProtectiveUniforms()
    {
        try
        {
            _obj_Smhr_Masters = new SMHR_MASTERS();
            _obj_Smhr_Masters.MASTER_TYPE = "PROTECTIVEUNIFORM";
            _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            rcmb_UniformName.DataSource = BLL.get_MasterRecords(_obj_Smhr_Masters);
            rcmb_UniformName.DataTextField = "HR_MASTER_CODE";
            rcmb_UniformName.DataValueField = "HR_MASTER_ID";
            rcmb_UniformName.DataBind();
            rcmb_UniformName.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Activity", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        bool status = false;
        try
        {
            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_SAVE":
                    _obj_smhr_Activity = new SMHR_ACTIVITY();
                    _obj_smhr_Activity.OPERATION = operation.Insert;
                    _obj_smhr_Activity.SMHR_ACTIVITY_NAME = Convert.ToString(rad_Activity.Text);
                    _obj_smhr_Activity.SMHR_ACTIVITY_PROTECTIVEUNIFORM_ID = Convert.ToInt32(rcmb_UniformName.SelectedValue);
                    _obj_smhr_Activity.SMHR_ACTIVITY_DESCRIPTION = Convert.ToString(rad_Description.Text);
                    _obj_smhr_Activity.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_Activity.CREATEDDATE = DateTime.Now;
                    _obj_smhr_Activity.SMHR_ACTIVITY_ISACTIVE = Convert.ToBoolean(rad_IsActive.Checked);
                    _obj_smhr_Activity.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

                    if (Convert.ToString(BLL.checkexists(_obj_smhr_Activity).Rows[0]["Count"]) != "0")
                    {
                        BLL.ShowMessage(this, "This Activity Already Exists");
                        return;
                    }
                    status = BLL.set_Activity(_obj_smhr_Activity);
                    if (status == true)
                    {
                        BLL.ShowMessage(this, "Information Successfully Saved");
                    }
                    break;
                case "BTN_UPDATE":
                    _obj_smhr_Activity = new SMHR_ACTIVITY();
                    _obj_smhr_Activity.OPERATION = operation.Update;
                    _obj_smhr_Activity.SMHR_ACTIVITY_ID = Convert.ToInt32(lbl_ActivityID.Text);
                    _obj_smhr_Activity.SMHR_ACTIVITY_NAME = Convert.ToString(rad_Activity.Text);
                    _obj_smhr_Activity.SMHR_ACTIVITY_PROTECTIVEUNIFORM_ID = Convert.ToInt32(rcmb_UniformName.SelectedValue);
                    _obj_smhr_Activity.SMHR_ACTIVITY_DESCRIPTION = Convert.ToString(rad_Description.Text);
                    _obj_smhr_Activity.SMHR_ACTIVITY_MODIFIEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_Activity.SMHR_ACTIVITY_MODIFIEDDATE = DateTime.Now;
                    _obj_smhr_Activity.SMHR_ACTIVITY_ISACTIVE = Convert.ToBoolean(rad_IsActive.Checked);
                    _obj_smhr_Activity.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

                    status = BLL.set_Activity(_obj_smhr_Activity);
                    if (status == true)
                    {
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    }
                    break;
            }
            Rm_HDPT_page.SelectedIndex = 0;
            LoadGrid();
            Rg_Actvities.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Activity", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadGrid()
    {
        try
        {
            _obj_smhr_Activity = new SMHR_ACTIVITY();
            _obj_smhr_Activity.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            Rg_Actvities.DataSource = BLL.get_AllActivities(_obj_smhr_Activity);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Activity", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void ClearFields()
    {
        try
        {
            rad_Activity.Text = String.Empty;
            rad_Description.Text = String.Empty;
            BTN_SAVE.Visible = false;
            rad_IsActive.Checked = false;
            Rm_HDPT_page.SelectedIndex = 0;
            rcmb_UniformName.Items.Clear();
            rcmb_UniformName.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Activity", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            ClearFields();
            BTN_SAVE.Visible = true;
            rad_Activity.Enabled = true;
            btn_Cancel.Visible = true;
            btn_Update.Visible = false;
            rad_IsActive.Checked = true;
            rad_IsActive.Enabled = false;
            rcmb_UniformName.Enabled = true;
            Rm_HDPT_page.SelectedIndex = 1;
            LoadProtectiveUniforms();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Activity", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Edit(object sender, CommandEventArgs e)
    {
        try
        {
            ClearFields();
            LoadProtectiveUniforms();
            rad_Activity.Enabled = false;
            rcmb_UniformName.Enabled = false;
            rad_IsActive.Enabled = true;
            _obj_smhr_Activity = new SMHR_ACTIVITY();
            _obj_smhr_Activity.SMHR_ACTIVITY_ID = Convert.ToInt32(e.CommandArgument);
            _obj_smhr_Activity.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_Activity(_obj_smhr_Activity);
            lbl_ActivityID.Text = Convert.ToString(dt.Rows[0]["SMHR_ACTIVITY_ID"]);
            rad_Activity.Text = Convert.ToString(dt.Rows[0]["SMHR_ACTIVITY_NAME"]);
            rcmb_UniformName.SelectedValue = Convert.ToString(dt.Rows[0]["SMHR_ACTIVITY_PROTECTIVEUNIFORM_ID"]);
            rad_Description.Text = Convert.ToString(dt.Rows[0]["SMHR_ACTIVITY_DESCRIPTION"]);
            rad_IsActive.Checked = Convert.ToBoolean(dt.Rows[0]["SMHR_ACTIVITY_ISACTIVE"]);
            Rm_HDPT_page.SelectedIndex = 1;
            BTN_SAVE.Visible = false;
            btn_Update.Visible = true;

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Activity", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            ClearFields();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Activity", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Update_Click(object sender, EventArgs e)
    {

    }

    protected void Rg_Actvities_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        LoadGrid();
    }
}