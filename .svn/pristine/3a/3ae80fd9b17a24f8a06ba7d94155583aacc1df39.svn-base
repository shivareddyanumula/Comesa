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


public partial class Masters_frm_TdsSlab : System.Web.UI.Page
{
    SMHR_ORGANISATION _obj_smhr_Organisation;
    SMHR_BUSINESSUNIT _obj_smhr_BusinessUnit;
    SMHR_TDS _obj_smhr_Tds;
    SMHR_TDS_SLAB _obj_smhr_Tds_Slab;
    SMHR_MASTERS _obj_smhr_master;
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("TDS Slab");//TDSSLAB");
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
                loadGrid();
                loadDropdown();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TdsSlab", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TdsSlab", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    public void loadGrid()
    {
        try
        {
            _obj_smhr_Tds_Slab = new SMHR_TDS_SLAB();
            _obj_smhr_Tds_Slab.OPERATION = operation.Select;
            _obj_smhr_Tds_Slab.TDS_SLAB_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_GridBind = BLL.get_TdsSlab(_obj_smhr_Tds_Slab);
            rg_Main.DataSource = dt_GridBind;
            //rg_Main.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TdsSlab", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void loadDropdown()
    {
        try
        {
            //_obj_smhr_Organisation = new SMHR_ORGANISATION();
            //_obj_smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
            //_obj_smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //DataTable dt_BusinessUnit = BLL.get_BusinessUnit(_obj_smhr_BusinessUnit);
            //rcmb_BusinessUnit.DataSource = dt_BusinessUnit;
            //rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            //rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            //rcmb_BusinessUnit.DataBind();
            //rcmb_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

            _obj_smhr_Tds_Slab = new SMHR_TDS_SLAB();
            _obj_smhr_Tds_Slab.OPERATION = operation.Get;
            _obj_smhr_Tds_Slab.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Tds_Id = BLL.get_TdsSlab(_obj_smhr_Tds_Slab);
            rcmb_tdsname.DataSource = dt_Tds_Id;
            rcmb_tdsname.DataTextField = "TDS_NAME";
            rcmb_tdsname.DataValueField = "TDS_ID";
            rcmb_tdsname.DataBind();
            rcmb_tdsname.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TdsSlab", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    //protected void rcmb_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    //{
    //    try
    //    {
    //        _obj_smhr_Tds_Slab = new SMHR_TDS_SLAB();
    //        _obj_smhr_Tds_Slab.OPERATION = operation.Check;
    //        _obj_smhr_Tds_Slab.TDS_SLAB_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
    //        _obj_smhr_Tds_Slab.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //        //_obj_smhr_Tds_Slab.TDS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //        DataTable dt_Tds_Id = BLL.get_TdsSlab(_obj_smhr_Tds_Slab);
    //        if (dt_Tds_Id.Rows.Count > 0)
    //        {
    //            Session["TDS_ID"] = Convert.ToString(dt_Tds_Id.Rows[0][0]);

    //            load_Localisation_Id();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TdsSlab", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            string str_Localisation = Convert.ToString(Session["TDS_LOCALISATION_ID"]);
            _obj_smhr_Tds_Slab = new SMHR_TDS_SLAB();
            if (rtxt_TdsSlabName.Text == string.Empty)
            {
                _obj_smhr_Tds_Slab.TDS_SLAB_NAME = Convert.ToString(rcmbSlab.SelectedItem.Text.Replace("'", "''"));
                _obj_smhr_Tds_Slab.TDS_SLAB_HR_ID = Convert.ToInt32(rcmbSlab.SelectedValue);
            }
            else
            {
                _obj_smhr_Tds_Slab.TDS_SLAB_NAME = Convert.ToString(rtxt_TdsSlabName.Text.Replace("'", "''"));
            }
            _obj_smhr_Tds_Slab.TDS_SLAB_DESC = Convert.ToString(rtxt_TdsSlabDesc.Text.Replace("'", "''"));

            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_UPDATE":

                    //_obj_smhr_Tds_Slab.TDS_SLAB_TDS_ID = Convert.ToInt32(Session["TDS_ID"]);
                    //_obj_smhr_Tds_Slab.TDS_SLAB_ID = Convert.ToInt32(rcmb_tdsname.SelectedItem.Value);//Convert.ToInt32(Session["TDS_SLAB_ID"]);
                    _obj_smhr_Tds_Slab.TDS_SLAB_ID = Convert.ToInt32(Session["TDS_SLAB_ID"]);
                    _obj_smhr_Tds_Slab.OPERATION = operation.Update;
                    if (BLL.set_TdsSlab(_obj_smhr_Tds_Slab))
                    {
                        BLL.ShowMessage(this, "Record Updated Successfully");
                        rmp_Main.SelectedIndex = 0;
                    }
                    break;
                case "BTN_SAVE":
                    _obj_smhr_Tds = new SMHR_TDS();
                    _obj_smhr_Tds.OPERATION = operation.Empty;
                    //_obj_smhr_Tds.TDS_BUSINESSUNIT = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
                    _obj_smhr_Tds.TDS_ID = Convert.ToInt32(rcmb_tdsname.SelectedItem.Value);
                    _obj_smhr_Tds.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dt_Count = BLL.get_Tds(_obj_smhr_Tds);
                    if (Convert.ToInt32(dt_Count.Rows[0][0]) == 0)
                    {
                        BLL.ShowMessage(this, "TDS Locale not created for this Businessunit");
                        return;
                    }
                    _obj_smhr_Tds_Slab.OPERATION = operation.Empty1;
                    _obj_smhr_Tds_Slab.TDS_SLAB_TDS_ID = Convert.ToInt32(rcmb_tdsname.SelectedItem.Value);//Convert.ToInt32(Session["TDS_ID"]);
                    _obj_smhr_Tds_Slab.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dt = BLL.get_TdsSlab(_obj_smhr_Tds_Slab);
                    if (dt.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dt.Rows[0]["COUNT"]) != 0)
                        {
                            BLL.ShowMessage(this, "TDS Slab Name Already Exists for this TDS");
                            return;
                        }
                    }
                    _obj_smhr_Tds_Slab.TDS_SLAB_LOCALISATION_ID = Convert.ToInt32(Session["TDS_LOCALISATION_ID"]);//Convert.ToInt32(str_Localisation);
                    _obj_smhr_Tds_Slab.TDS_SLAB_BUSINESSUNIT_ID = Convert.ToInt32(Session["TDS_BU_ID"]);
                    _obj_smhr_Tds_Slab.TDS_SLAB_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_Tds_Slab.OPERATION = operation.Insert;
                    if (BLL.set_TdsSlab(_obj_smhr_Tds_Slab))
                    {
                        BLL.ShowMessage(this, "record inserted successfully");

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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TdsSlab", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TdsSlab", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void clearControls()
    {
        try
        {
            //rcmb_BusinessUnit.Items.Clear();
            rcmb_tdsname.Items.Clear();
            rtxt_TdsSlabName.Text = null;
            rtxt_TdsSlabDesc.Text = null;

            rmp_Main.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TdsSlab", ex.StackTrace, DateTime.Now);
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
            //rcmb_BusinessUnit.Enabled=false;
            rcmb_tdsname.Enabled = false;
            rtxt_TdsSlabName.Enabled = false;
            loadDropdown();

            _obj_smhr_Tds_Slab = new SMHR_TDS_SLAB();
            _obj_smhr_Tds_Slab.OPERATION = operation.Validate;
            _obj_smhr_Tds_Slab.TDS_SLAB_ID = Convert.ToInt32(e.CommandArgument);
            Session["TDS_SLAB_ID"] = Convert.ToString(e.CommandArgument);
            DataTable dt = BLL.get_TdsSlab(_obj_smhr_Tds_Slab);

            //rcmb_BusinessUnit.SelectedIndex = rcmb_BusinessUnit.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["BUSINESSUNIT_ID"]));
            rcmb_tdsname.SelectedIndex = rcmb_tdsname.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["TDS_SLAB_TDS_ID"]));
            rtxt_TdsSlabName.Text = Convert.ToString(dt.Rows[0]["TDS_SLAB_NAME"]);
            rtxt_TdsSlabDesc.Text = Convert.ToString(dt.Rows[0]["TDS_SLAB_DESC"]);

            _obj_smhr_Tds_Slab = new SMHR_TDS_SLAB();
            _obj_smhr_Tds_Slab.OPERATION = operation.Check;
            _obj_smhr_Tds_Slab.TDS_SLAB_TDS_ID = Convert.ToInt32(dt.Rows[0]["TDS_SLAB_TDS_ID"]);
            _obj_smhr_Tds_Slab.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Tds_Id = BLL.get_TdsSlab(_obj_smhr_Tds_Slab);
            if (dt_Tds_Id.Rows.Count > 0)
            {
                _obj_smhr_master = new SMHR_MASTERS();
                _obj_smhr_master.OPERATION = operation.Select;
                _obj_smhr_master.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_smhr_master.MASTER_TYPE = "LOCALISATION";
                _obj_smhr_master.MASTER_ID = Convert.ToInt32(dt_Tds_Id.Rows[0]["TDS_LOCALISATION_ID"]);
                DataTable dtlocalName = BLL.get_MasterRecords(_obj_smhr_master);
                if (dtlocalName.Rows.Count > 0)
                {
                    if (Convert.ToString(dtlocalName.Rows[0]["HR_MASTER_CODE"]).ToUpper() == "AUSTRALIA")
                    {
                        trRcmbSlab.Visible = true;
                        trTxtSlab.Visible = false;
                        rcmbSlab.Enabled = false;
                        loadSlab();
                        rcmbSlab.SelectedIndex = rcmbSlab.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["TDS_SLAB_HR_ID"]));
                    }
                    else
                    {
                        trRcmbSlab.Visible = false;
                        trTxtSlab.Visible = true;
                    }
                }
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TdsSlab", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            rmp_Main.SelectedIndex = 1;
            btn_Save.Visible = true;
            btn_Update.Visible = false;
            //rcmb_BusinessUnit.Enabled = true;
            trTxtSlab.Visible = false;
            rcmb_tdsname.Enabled = true;
            rtxt_TdsSlabName.Enabled = true;
            rtxt_TdsSlabName.Text = null;
            rtxt_TdsSlabDesc.Text = null;
            loadDropdown();
            trRcmbSlab.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TdsSlab", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //public void load_Localisation_Id()
    //{
    //    try
    //    {
    //        _obj_smhr_Tds = new SMHR_TDS();
    //        _obj_smhr_Tds.TDS_BUSINESSUNIT = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
    //        _obj_smhr_Tds.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //        _obj_smhr_Tds.OPERATION = operation.Check;
    //        DataTable dt_LocalisationID = BLL.get_Tds(_obj_smhr_Tds);
    //        Session["TDS_LOCALISATION_ID"] = Convert.ToInt32(dt_LocalisationID.Rows[0][0]);
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TdsSlab", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}
    protected void rcmb_tdsname_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            _obj_smhr_Tds_Slab = new SMHR_TDS_SLAB();
            _obj_smhr_Tds_Slab.OPERATION = operation.Check;
            _obj_smhr_Tds_Slab.TDS_SLAB_TDS_ID = Convert.ToInt32(rcmb_tdsname.SelectedItem.Value);
            _obj_smhr_Tds_Slab.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //_obj_smhr_Tds_Slab.TDS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Tds_Id = BLL.get_TdsSlab(_obj_smhr_Tds_Slab);
            if (dt_Tds_Id.Rows.Count > 0)
            {
                Session["TDS_BU_ID"] = Convert.ToInt32(dt_Tds_Id.Rows[0]["TDS_BUSINESSUNIT_ID"]);
                Session["TDS_LOCALISATION_ID"] = Convert.ToInt32(dt_Tds_Id.Rows[0]["TDS_LOCALISATION_ID"]);
                //load_Localisation_Id();

                _obj_smhr_master = new SMHR_MASTERS();
                _obj_smhr_master.OPERATION = operation.Select;
                _obj_smhr_master.MASTER_TYPE = "AUSRESIDENCYTYPE";
                _obj_smhr_master.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtlocal = BLL.get_MasterRecords(_obj_smhr_master);
                _obj_smhr_master.MASTER_TYPE = "LOCALISATION";
                _obj_smhr_master.MASTER_ID = Convert.ToInt32(dt_Tds_Id.Rows[0]["TDS_LOCALISATION_ID"]);
                DataTable dtlocalName = BLL.get_MasterRecords(_obj_smhr_master);
                if (dtlocalName.Rows.Count > 0)
                {
                    if (Convert.ToString(dtlocalName.Rows[0]["HR_MASTER_CODE"]).ToUpper() == "AUSTRALIA")
                    {
                        trRcmbSlab.Visible = true;
                        trTxtSlab.Visible = false;
                        rcmbSlab.Enabled = true;
                        if (dtlocal.Rows.Count > 0)
                        {
                            rcmbSlab.DataSource = dtlocal;
                            rcmbSlab.DataTextField = "HR_MASTER_CODE";
                            rcmbSlab.DataValueField = "HR_MASTER_ID";
                            rcmbSlab.DataBind();
                            rcmbSlab.Items.Insert(0, new RadComboBoxItem("Select", "0"));
                        }
                    }
                    else
                    {
                        trTxtSlab.Visible = true;
                        trRcmbSlab.Visible = false;
                    }
                }

            }


        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TdsSlab", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void loadSlab()
    {
        try
        {
            _obj_smhr_master = new SMHR_MASTERS();
            _obj_smhr_master.OPERATION = operation.Select;
            _obj_smhr_master.MASTER_TYPE = "AUSRESIDENCYTYPE";
            _obj_smhr_master.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtlocal = BLL.get_MasterRecords(_obj_smhr_master);
            if (dtlocal.Rows.Count > 0)
            {
                rcmbSlab.DataSource = dtlocal;
                rcmbSlab.DataTextField = "HR_MASTER_CODE";
                rcmbSlab.DataValueField = "HR_MASTER_ID";
                rcmbSlab.DataBind();
                rcmbSlab.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TdsSlab", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
