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

public partial class Masters_frm_tds : System.Web.UI.Page
{
    SMHR_ORGANISATION _obj_smhr_Organisation;
    SMHR_BUSINESSUNIT _obj_smhr_BusinessUnit;
    SMHR_TDS _obj_smhr_Tds;
    Label lbl_tdsid = new Label();
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Define TDS Name");//TDS");
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
                    rg_Main.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
                loadDropdown();
                loadGrid();
                //loadCountryID();
            }
            loadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_tds", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    //public void loadCountryID()
    //{
    //    _obj_smhr_Tds = new SMHR_TDS();
    //    _obj_smhr_Tds.TDS_BUSINESSUNIT = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
    //    _obj_smhr_Tds.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //    _obj_smhr_Tds.OPERATION = operation.Check;
    //    DataTable dt_CountryID = BLL.get_Tds(_obj_smhr_Tds);
    //    Session["TDS_COUNTRY_ID"] = Convert.ToInt32(dt_CountryID.Rows[0][0]);
    //}
    public void loadGrid()
    {
        try
        {
            _obj_smhr_Tds = new SMHR_TDS();
            _obj_smhr_Tds.OPERATION = operation.Select;
            _obj_smhr_Tds.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_GridBind = BLL.get_Tds(_obj_smhr_Tds);
            rg_Main.DataSource = dt_GridBind;
            //rg_Main.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_tds", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void loadDropdown()
    {
        try
        {
            //To load Business unit
            SMHR_LOGININFO _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            //DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            //_obj_smhr_Organisation = new SMHR_ORGANISATION();
            //_obj_smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
            //_obj_smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //DataTable dt_BusinessUnit = BLL.get_BusinessUnit(_obj_smhr_BusinessUnit);
            DataTable dt_BusinessUnit = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            rcmb_BusinessUnit.DataSource = dt_BusinessUnit;
            rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BusinessUnit.DataBind();
            rcmb_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_tds", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            _obj_smhr_Tds = new SMHR_TDS();
            _obj_smhr_Tds.TDS_BUSINESSUNIT = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
            _obj_smhr_Tds.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_Tds.OPERATION = operation.Check;
            DataTable dt_LocalisationID = BLL.get_Tds(_obj_smhr_Tds);
            Session["TDS_LOCALISATION_ID"] = Convert.ToInt32(dt_LocalisationID.Rows[0][0]);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_tds", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_smhr_Tds = new SMHR_TDS();
            _obj_smhr_Tds.TDS_NAME = Convert.ToString(rtxt_TdsName.Text.Replace("'", "''"));
            _obj_smhr_Tds.TDS_DESC = Convert.ToString(rtxt_TdsDesc.Text.Replace("'", "''"));
            _obj_smhr_Tds.TDS_BUSINESSUNIT = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
            //_obj_smhr_Tds.TDS_ID = Convert.ToInt32(ViewState["TD_ID"]);
            _obj_smhr_Tds.TDS_ID = Convert.ToInt32(Session["TDS_ID"]);
            //if (chk_TdsStatus.Checked)
            //{
            //    _obj_smhr_Tds.TDS_STATUS = true;
            //}
            //else
            //{
            //    _obj_smhr_Tds.TDS_STATUS = false;
            //}
            int Status = Convert.ToInt32(rcmb_Status.SelectedItem.Value);
            _obj_smhr_Tds.TDS_STATUS = Convert.ToBoolean(Status);
            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_UPDATE":
                    //_obj_smhr_Tds.TDS_COUNTRY_ID = Convert.ToInt32(Session["TDS_COUNTRY_ID"]);
                    _obj_smhr_Tds.TDS_BUSINESSUNIT = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
                    _obj_smhr_Tds.OPERATION = operation.Empty;
                    DataTable dt_Count = BLL.get_Tds(_obj_smhr_Tds);
                    _obj_smhr_Tds.OPERATION = operation.Check1;
                    _obj_smhr_Tds.TDS_BUSINESSUNIT = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
                    _obj_smhr_Tds.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_Tds.TDS_LOCALISATION_ID = Convert.ToInt32(Session["TDS_LOCALISATION_ID"]);
                    DataTable dt_Status = BLL.get_Tds(_obj_smhr_Tds);
                    if (Convert.ToInt32(dt_Count.Rows[0][0]) != 0)
                    {
                        if (Convert.ToString(dt_Status.Rows[0]["TDS_STATUS"]) == "True")
                        {
                            BLL.ShowMessage(this, "TDS record for this Businessunit already exists");
                            return;
                        }
                    }
                    _obj_smhr_Tds.TDS_MODIFIEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_Tds.TDS_MODIFIEDDATE = Convert.ToDateTime(DateTime.Now);
                    _obj_smhr_Tds.OPERATION = operation.Update;

                    if (BLL.set_Tds(_obj_smhr_Tds))
                    {
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    }
                    break;
                case "BTN_SAVE":
                    _obj_smhr_Tds.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_Tds.OPERATION = operation.Empty;
                    DataTable dt_Count_Save = BLL.get_Tds(_obj_smhr_Tds);
                    _obj_smhr_Tds.OPERATION = operation.Check1;
                    _obj_smhr_Tds.TDS_BUSINESSUNIT = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
                    _obj_smhr_Tds.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_Tds.TDS_LOCALISATION_ID = Convert.ToInt32(Session["TDS_LOCALISATION_ID"]);
                    DataTable dt_Status_Save = BLL.get_Tds(_obj_smhr_Tds);
                    if (Convert.ToInt32(dt_Status_Save.Rows.Count) != 0)
                    {
                        for (int i = 0; i < dt_Status_Save.Rows.Count; i++)
                        {
                            if (Convert.ToString(dt_Status_Save.Rows[i]["TDS_STATUS"]) == "True")
                            {
                                BLL.ShowMessage(this, "TDS record for this Businessunit already exists.If you want to create new Localisation, inactive the earlier record.");
                                return;
                            }
                        }
                    }
                    _obj_smhr_Tds.TDS_LOCALISATION_ID = Convert.ToInt32(Session["TDS_LOCALISATION_ID"]);
                    _obj_smhr_Tds.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_Tds.TDS_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_Tds.TDS_CREATEDDATE = DateTime.Now;
                    _obj_smhr_Tds.OPERATION = operation.Insert;
                    if (BLL.set_Tds(_obj_smhr_Tds))
                    {

                        BLL.ShowMessage(this, "Information Saved Successfully");
                    }
                    break;
                default:
                    break;
            }
            rmp_Main.SelectedIndex = 0;
            loadGrid();
            rg_Main.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_tds", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_tds", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Update_Click(object sender, EventArgs e)
    {

    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            rmp_Main.SelectedIndex = 1;
            rcmb_Status.SelectedIndex = 0;
            btn_Update.Visible = false;
            btn_Save.Visible = true;
            rcmb_BusinessUnit.Enabled = true;
            //chk_TdsStatus.Checked = false;
            loadDropdown();
            rtxt_TdsName.Text = string.Empty;
            rtxt_TdsDesc.Text = string.Empty;
            rtxt_TdsName.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_tds", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Update.Visible = false;

            }

            else
            {
                btn_Update.Visible = true;
            }
            rmp_Main.SelectedIndex = 1;
            btn_Save.Visible = false;
            btn_Update.Visible = true;
            rcmb_BusinessUnit.Enabled = false;
            //chk_TdsStatus.Checked = false;
            rtxt_TdsName.Enabled = false;
            loadDropdown();
            _obj_smhr_Tds = new SMHR_TDS();
            _obj_smhr_Tds.OPERATION = operation.Validate;
            //_obj_smhr_Tds.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_Tds.TDS_ID = Convert.ToInt32(e.CommandArgument);

            Session["TDS_ID"] = Convert.ToString(e.CommandArgument);
            //ViewState["TDS_ID"] = Convert.ToInt32(e.CommandArgument);
            DataTable dt = BLL.get_Tds(_obj_smhr_Tds);

            rcmb_BusinessUnit.SelectedIndex = rcmb_BusinessUnit.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["BUSINESSUNIT_ID"]));
            rtxt_TdsName.Text = Convert.ToString(dt.Rows[0]["TDS_NAME"]);
            rtxt_TdsDesc.Text = Convert.ToString(dt.Rows[0]["TDS_DESC"]);
            if (Convert.ToString(dt.Rows[0]["TDS_STATUS"]) != null)
            {
                int Status = Convert.ToInt32(dt.Rows[0]["TDS_STATUS"]);
                rcmb_Status.SelectedIndex = rcmb_Status.FindItemIndexByValue(Convert.ToString(Status));
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_tds", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void clearControls()
    {
        try
        {
            rcmb_BusinessUnit.Items.Clear();
            rtxt_TdsName.Text = null;
            rtxt_TdsDesc.Text = null;
            rmp_Main.SelectedIndex = 0;
            loadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_tds", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rg_Main_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            loadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_tds", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //public void loadLocalisation()
    //{

    //}
}
