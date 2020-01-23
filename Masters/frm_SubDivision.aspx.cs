using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using Telerik.Web.UI;

public partial class Masters_frm_SubDivision : System.Web.UI.Page
{
    SMHR_SUBDIVISION _obj_Smhr_SubDivision;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_DEPARTMENT _obj_Department;
    SMHR_BUSINESSUNIT _obj_smhr_businessunit;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {

                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Sub Function");
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
                    rg_SubDivision.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
                LoadBusinessUnit();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_SubDivision", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rg_SubDivision_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_SubDivision", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadGrid()
    {
        try
        {
            _obj_Smhr_SubDivision = new SMHR_SUBDIVISION();
            _obj_Smhr_SubDivision.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_SubDivision.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            _obj_Smhr_SubDivision.MODE = 3;
            DataTable dt = BLL.get_SubDivision(_obj_Smhr_SubDivision);
            rg_SubDivision.DataSource = dt;
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                rg_SubDivision.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_SubDivision", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_Smhr_SubDivision = new SMHR_SUBDIVISION();
            _obj_Smhr_SubDivision.SUBDIVISION_BU_ID = Convert.ToInt32(rcmb_Bu.SelectedItem.Value);
            _obj_Smhr_SubDivision.SUBDIVISION_DEPARTMENT_ID = Convert.ToInt32(rcmb_Department.SelectedItem.Value);
            _obj_Smhr_SubDivision.SUBDIVISION_DIVISION_ID = Convert.ToInt32(rcmb_Division.SelectedItem.Value);
            _obj_Smhr_SubDivision.SUBDIVISION_NAME = Convert.ToString(rtxt_SubDivisionName.Text.Replace("'", "''"));
            _obj_Smhr_SubDivision.SUBDIVISION_DESC = Convert.ToString(rtxt_SubDivisionDesc.Text.Replace("'", "''"));
            _obj_Smhr_SubDivision.SUBDIVISION_STATUS = Convert.ToString(rcmb_Status.SelectedValue);
            _obj_Smhr_SubDivision.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_SubDivision.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_Smhr_SubDivision.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_SAVE":
                    _obj_Smhr_SubDivision.MODE = 5;
                    if (Convert.ToString(BLL.get_SubDivision(_obj_Smhr_SubDivision).Rows[0]["Count"]) != "0")
                    {
                        BLL.ShowMessage(this, "Name Already Exist for Selected Function.");
                        return;
                    }
                    _obj_Smhr_SubDivision.MODE = 1;
                    if (BLL.set_SubDivision(_obj_Smhr_SubDivision))
                        BLL.ShowMessage(this, "Information Saved Successfully.");
                    else
                        BLL.ShowMessage(this, "Information Not Saved.");
                    break;
                case "BTN_UPDATE":
                    _obj_Smhr_SubDivision.MODE = 5;
                    if (Convert.ToString(BLL.get_SubDivision(_obj_Smhr_SubDivision).Rows[0]["Count"]) != "1")
                    {
                        BLL.ShowMessage(this, "Name Already Exist for Selected Function.");
                        return;
                    }
                    _obj_Smhr_SubDivision.MODE = 2;
                    _obj_Smhr_SubDivision.SUBDIVISION_ID = Convert.ToInt32(lbl_ID.Text);
                    if (BLL.set_SubDivision(_obj_Smhr_SubDivision))
                        BLL.ShowMessage(this, "Information Updated Successfully.");
                    else
                        BLL.ShowMessage(this, "Information Not Updated.");
                    break;
            }
            ClearControls();
            RMP_SubDivision.SelectedIndex = 0;
            LoadGrid();
            rg_SubDivision.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_SubDivision", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void ClearControls()
    {
        try
        {
            rcmb_Bu.SelectedIndex = 0;
            rcmb_Department.ClearSelection();
            rcmb_Department.Items.Clear();
            rcmb_Department.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            rcmb_Division.ClearSelection();
            rcmb_Division.Items.Clear();
            rcmb_Division.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            rtxt_SubDivisionName.Text = string.Empty;
            rtxt_SubDivisionDesc.Text = string.Empty;
            rcmb_Status.SelectedIndex = 0;
            lbl_ID.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_SubDivision", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            ClearControls();
            EnableControls(true);
            RMP_SubDivision.SelectedIndex = 1;
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                btn_Save.Visible = false;
            else
                btn_Save.Visible = true;
            btn_Update.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_SubDivision", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void EnableControls(bool p)
    {
        try
        {
            rcmb_Bu.Enabled = p;
            rcmb_Department.Enabled = p;
            rcmb_Division.Enabled = p;
            rtxt_SubDivisionName.Enabled = p;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_SubDivision", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            ClearControls();
            RMP_SubDivision.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_SubDivision", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            EnableControls(false);
            RMP_SubDivision.SelectedIndex = 1;
            _obj_Smhr_SubDivision = new SMHR_SUBDIVISION();
            _obj_Smhr_SubDivision.MODE = 4;
            _obj_Smhr_SubDivision.SUBDIVISION_ID = Convert.ToInt32(e.CommandArgument);
            lbl_ID.Text = Convert.ToString(e.CommandArgument);
            _obj_Smhr_SubDivision.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_SubDivision(_obj_Smhr_SubDivision);
            if (dt.Rows.Count > 0)
            {
                rcmb_Bu.SelectedIndex = rcmb_Bu.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["SUBDIVISION_BU_ID"]));
                rcmb_Bu_SelectedIndexChanged(null, null);
                rcmb_Department.SelectedIndex = rcmb_Department.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["SUBDIVISION_DEPARTMENT_ID"]));
                rcmb_Department_SelectedIndexChanged(null, null);
                rcmb_Division.SelectedIndex = rcmb_Division.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["SUBDIVISION_DIVISION_ID"]));
                rtxt_SubDivisionName.Text = Convert.ToString(dt.Rows[0]["SUBDIVISION_NAME"]);
                rtxt_SubDivisionDesc.Text = Convert.ToString(dt.Rows[0]["SUBDIVISION_DESC"]);
                rcmb_Status.SelectedIndex = rcmb_Status.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["SUBDIVISION_STATUS"]));
            }
            btn_Save.Visible = false;
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                btn_Update.Visible = false;
            else
                btn_Update.Visible = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_SubDivision", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadBusinessUnit()
    {
        try
        {
            rcmb_Bu.Items.Clear();
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            rcmb_Bu.Items.Clear();
            rcmb_Bu.DataSource = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            rcmb_Bu.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_Bu.DataValueField = "BUSINESSUNIT_ID";
            rcmb_Bu.DataBind();
            rcmb_Bu.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_SubDivision", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_Bu_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Bu.SelectedIndex > 0)
            {
                rcmb_Department.Items.Clear();
                _obj_Department = new SMHR_DEPARTMENT();
                _obj_Department.MODE = 7;
                _obj_Department.BUID = Convert.ToInt32(rcmb_Bu.SelectedValue);
                DataTable dt = BLL.get_Department(_obj_Department);
                rcmb_Department.DataSource = dt;
                rcmb_Department.DataTextField = "DEPARTMENT_NAME";
                rcmb_Department.DataValueField = "DEPARTMENT_ID";
                rcmb_Department.DataBind();
                rcmb_Department.Items.Insert(0, new RadComboBoxItem("Select"));
            }
            else
            {
                rcmb_Department.ClearSelection();
                rcmb_Department.Items.Clear();
                rcmb_Department.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            }
            rcmb_Division.ClearSelection();
            rcmb_Division.Items.Clear();
            rcmb_Division.Items.Insert(0, new RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_SubDivision", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_Department_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Department.SelectedIndex > 0)
            {
                rcmb_Division.Items.Clear();
                _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
                _obj_smhr_businessunit.OPERATION = operation.Select1;
                _obj_smhr_businessunit.BUID = Convert.ToInt32(rcmb_Department.SelectedValue);
                _obj_smhr_businessunit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable Dt_Divisions = BLL.Get_Divisions(_obj_smhr_businessunit);
                if (Dt_Divisions.Rows.Count > 0)
                {
                    rcmb_Division.DataSource = Dt_Divisions;
                    rcmb_Division.DataTextField = "SMHR_DIV_CODE";
                    rcmb_Division.DataValueField = "SMHR_DIV_ID";
                    rcmb_Division.DataBind();
                }
                rcmb_Division.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            }
            else
            {
                rcmb_Division.ClearSelection();
                rcmb_Division.Items.Clear();
                rcmb_Division.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_SubDivision", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
