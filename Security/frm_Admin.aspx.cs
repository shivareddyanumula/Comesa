using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using Telerik.Web.UI;

public partial class Security_frm_Admin : System.Web.UI.Page
{
    SMHR_BUSINESSUNIT _obj_businessunit;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Page.Validate();
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
            clearControls();
            DataTable dt = BLL.get_LoginInfo(new SMHR_LOGININFO(Convert.ToInt32(Convert.ToString(e.CommandArgument))));
            lbl_UserManagerID.Text = Convert.ToString(dt.Rows[0]["LOGIN_ID"]);
            rcmb_Organisation.SelectedIndex = rcmb_Organisation.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LOGIN_ORGANISATION_ID"]));
            rcmb_UserManagersEmployee.SelectedIndex = rcmb_UserManagersEmployee.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LOGIN_EMP_ID"]));
            rcmb_UserManagerUserGroups.SelectedIndex = rcmb_UserManagerUserGroups.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LOGIN_TYPE"]));
            rtxt_UserManagerUserName.Text = Convert.ToString(dt.Rows[0]["LOGIN_USERNAME"]);
            string strPass = BLL.PasswordDecrypt(Convert.ToString(dt.Rows[0]["LOGIN_PASSWORD"]));
            string strPass1 = BLL.PasswordDecrypt(Convert.ToString(dt.Rows[0]["LOGIN_PASS_CODE"]));
            //string strPass = Convert.ToString(dt.Rows[0]["LOGIN_PASSWORD"]);
            rtxt_UserManagerPassword.Attributes.Add("value", strPass);
            txt_PassCode.Attributes.Add("value", strPass1);
            rtxt_UserManagerEmail.Text = Convert.ToString(dt.Rows[0]["LOGIN_EMAILID"]);
            //chk_UserManagerStatus.Checked = Convert.ToBoolean(dt.Rows[0]["LOGIN_STATUS"]);
            if (Convert.ToBoolean(dt.Rows[0]["LOGIN_STATUS"]) == true)
                rcmb_UserManagerStatus.SelectedValue = "1";
            else
                rcmb_UserManagerStatus.SelectedValue = "0";

            LoadBusinessUnit();

            string str = Convert.ToString(dt.Rows[0]["LOGIN_BUSINESSUNITID"]);
            foreach (string item in str.Split(new char[] { ',' }))
            {
                if (item != "")
                    rlst_BusinessUnit.Items.Add(new Telerik.Web.UI.RadListBoxItem(rcmb_UserManagerBusinessUnit.FindItemByValue(item).Text, rcmb_UserManagerBusinessUnit.FindItemByValue(item).Value));
            }

            LoadBusinessUnit();
            btn_Update.Visible = true;
            Rm_UM_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Admin", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            loadDropdown();
            LoadBusinessUnit();
            clearControls();
            btn_Save.Visible = true;
            Rm_UM_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Admin", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void LoadGrid()
    {
        try
        {
            DataTable DT = BLL.get_LoginInfo(new SMHR_LOGININFO());
            Rg_UserManager.DataSource = DT;
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Admin", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void loadDropdown()
    {
        try
        {
            rcmb_UserManagerUserGroups.Items.Clear();
            rcmb_UserManagerUserGroups.DataSource = BLL.get_LoginType(new SMHR_LOGINTYPE());
            rcmb_UserManagerUserGroups.DataTextField = "LOGTYP_CODE";
            rcmb_UserManagerUserGroups.DataValueField = "LOGTYP_ID";
            rcmb_UserManagerUserGroups.DataBind();
            rcmb_UserManagerUserGroups.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            SMHR_EMPDISCIPLINARYACTION _obj_Smhr_EmpDisciplinaryAction = new SMHR_EMPDISCIPLINARYACTION();
            _obj_Smhr_EmpDisciplinaryAction.OPERATION = operation.Empty;
            DataTable dt = BLL.get_EmpDiscNotes(_obj_Smhr_EmpDisciplinaryAction);

            rcmb_UserManagersEmployee.Items.Clear();
            rcmb_UserManagersEmployee.DataSource = dt;
            rcmb_UserManagersEmployee.DataTextField = "EMPNAME";
            rcmb_UserManagersEmployee.DataValueField = "EMP_ID";
            rcmb_UserManagersEmployee.DataBind();
            rcmb_UserManagersEmployee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            SMHR_ORGANISATION _obj_Organisation = new SMHR_ORGANISATION();
            _obj_Organisation.MODE = 1;
            DataTable dtorg = BLL.get_Organisation(_obj_Organisation);
            rcmb_Organisation.DataSource = dtorg;
            rcmb_Organisation.DataTextField = "ORGANISATION_NAME";
            rcmb_Organisation.DataValueField = "ORGANISATION_ID";
            rcmb_Organisation.DataBind();
            rcmb_Organisation.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Admin", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();
            _obj_Smhr_LoginInfo.LOGIN_EMP_ID = Convert.ToInt32(rcmb_UserManagersEmployee.SelectedItem.Value);
            _obj_Smhr_LoginInfo.LOGIN_TYPE = Convert.ToInt32(rcmb_UserManagerUserGroups.SelectedItem.Value);
            _obj_Smhr_LoginInfo.LOGIN_USERNAME = BLL.ReplaceQuote(rtxt_UserManagerUserName.Text);
            _obj_Smhr_LoginInfo.LOGIN_PASSWORD = BLL.PasswordEncrypt(BLL.ReplaceQuote(rtxt_UserManagerPassword.Text));
            _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = BLL.PasswordEncrypt(BLL.ReplaceQuote(txt_PassCode.Text));
            _obj_Smhr_LoginInfo.LOGIN_EMAILID = BLL.ReplaceQuote(rtxt_UserManagerEmail.Text);
            //_obj_Smhr_LoginInfo.LOGIN_STATUS = chk_UserManagerStatus.Checked;

            if (rcmb_UserManagerStatus.SelectedValue == "1")
                _obj_Smhr_LoginInfo.LOGIN_STATUS = true;
            else
                _obj_Smhr_LoginInfo.LOGIN_STATUS = false;
            _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(rcmb_Organisation.SelectedValue);
            _obj_Smhr_LoginInfo.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_LoginInfo.CREATEDDATE = DateTime.Now;

            _obj_Smhr_LoginInfo.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_LoginInfo.LASTMDFDATE = DateTime.Now;

            string str = string.Empty;

            foreach (RadListBoxItem item in rlst_BusinessUnit.Items)
            {
                str += item.Value + ",";
            }
            if (str.Length > 0)
            {
                str = str.Remove(str.Length - 1, 1);
            }

            _obj_Smhr_LoginInfo.LOGIN_BUSINESSUNITID = str;


            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_UPDATE":
                    _obj_Smhr_LoginInfo.LOGIN_ID = Convert.ToInt32(lbl_UserManagerID.Text);
                    _obj_Smhr_LoginInfo.OPERATION = operation.Check;
                    if (Convert.ToString(BLL.get_LoginInfo(_obj_Smhr_LoginInfo).Rows[0]["Count"]) != "1")
                    {
                        BLL.ShowMessage(this, "User Name Already Exists");
                        return;
                    }
                    _obj_Smhr_LoginInfo.OPERATION = operation.Update;
                    if (BLL.set_LoginInfo(_obj_Smhr_LoginInfo))
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");

                    break;
                case "BTN_SAVE":
                    _obj_Smhr_LoginInfo.OPERATION = operation.Check;
                    if (Convert.ToString(BLL.get_LoginInfo(_obj_Smhr_LoginInfo).Rows[0]["Count"]) != "0")
                    {
                        BLL.ShowMessage(this, "User Name already Exists");
                        return;
                    }
                    _obj_Smhr_LoginInfo.OPERATION = operation.Insert;
                    if (BLL.set_LoginInfo(_obj_Smhr_LoginInfo))
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                default:
                    break;
            }
            Rm_UM_page.SelectedIndex = 0;
            LoadGrid();
            Rg_UserManager.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Admin", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void clearControls()
    {
        lbl_UserManagerID.Text = string.Empty;
        rcmb_UserManagersEmployee.SelectedIndex = -1;
        rcmb_UserManagerUserGroups.SelectedIndex = -1;
        rtxt_UserManagerUserName.Text = string.Empty;
        rtxt_UserManagerPassword.Text = string.Empty;
        rtxt_UserManagerEmail.Text = string.Empty;
        rlst_BusinessUnit.Items.Clear();
        //chk_UserManagerStatus.Checked = false;
        rtxt_UserManagerPassword.Text = string.Empty;
        rcmb_UserManagerStatus.SelectedValue = "1";
        btn_Save.Visible = false;
        btn_Update.Visible = false;
        Rm_UM_page.SelectedIndex = 0;
        ViewState["PASSCODE"] = "";
        ViewState["PASSWORD"] = "";
        txt_PassCode.Attributes.Add("value", "");
        rtxt_UserManagerPassword.Attributes.Add("value", "");
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Admin", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Rg_UserManager_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        LoadGrid();
    }

    protected void btn_AddBusinessUnit_Click(object sender, EventArgs e)
    {
        try
        {
            ViewState["PASSCODE"] = txt_PassCode.Text;
            ViewState["PASSWORD"] = rtxt_UserManagerPassword.Text;
            if (rcmb_UserManagerBusinessUnit.SelectedItem.Value != "0")
            {
                rlst_BusinessUnit.Items.Add(new Telerik.Web.UI.RadListBoxItem(rcmb_UserManagerBusinessUnit.SelectedItem.Text, rcmb_UserManagerBusinessUnit.SelectedItem.Value));
                LoadBusinessUnit();
            }
            txt_PassCode.Attributes.Add("value", Convert.ToString(ViewState["PASSCODE"]));
            rtxt_UserManagerPassword.Attributes.Add("value", Convert.ToString(ViewState["PASSWORD"]));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Admin", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void LoadBusinessUnit()
    {
        _obj_businessunit = new SMHR_BUSINESSUNIT();
        _obj_businessunit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
        _obj_businessunit.OPERATION = operation.Select;
        DataTable dt_bus = BLL.get_BusinessUnit(_obj_businessunit);

        string str = string.Empty;

        foreach (RadListBoxItem item in rlst_BusinessUnit.Items)
        {
            str += item.Value + ",";
        }
        if (str.Length > 0)
        {
            str = str.Remove(str.Length - 1, 1);
            dt_bus.DefaultView.RowFilter = " BUSINESSUNIT_ID not in (" + str + ")";
            dt_bus = dt_bus.DefaultView.ToTable();
        }

        rcmb_UserManagerBusinessUnit.Items.Clear();
        rcmb_UserManagerBusinessUnit.DataSource = dt_bus;
        rcmb_UserManagerBusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
        rcmb_UserManagerBusinessUnit.DataValueField = "BUSINESSUNIT_ID";
        rcmb_UserManagerBusinessUnit.DataBind();
        rcmb_UserManagerBusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

    }

    protected void rlst_BusinessUnit_Deleted(object sender, RadListBoxEventArgs e)
    {
        try
        {
            LoadBusinessUnit();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Admin", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
