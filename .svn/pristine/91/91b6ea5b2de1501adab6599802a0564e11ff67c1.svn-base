using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using Telerik.Web.UI;

public partial class Masters_frm_Tds_Params : System.Web.UI.Page
{
    SMHR_BUSINESSUNIT _obj_smhr_BusinessUnit;
    SMHR_TDS _obj_smhr_Tds;
    SMHR_TDS_SLAB _obj_smhr_Tds_Slab;
    SMHR_TDS_PARAMS _obj_smhr_Tds_Params;
    SMHR_PERIOD obj_smhr_Period;
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("PAYE Params - Add/Edit Existing Values");//TDSPARAMS");
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
                //loadPeriod();
                loadGrid();
                //loadCountryId();
                //loadBusinessUnit();
                //loadSlabName();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Tds_Params", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (rntxt_TdsVal.Text == string.Empty && rntxt_TdsPercent.Text == string.Empty)
            {
                BLL.ShowMessage(this, "Please Enter Tds Value or Tds Percent");
                return;
            }
            if (Convert.ToDouble(rntxt_TdsFromVal.Text) >= Convert.ToDouble(rntxt_TdsToVal.Text))
            {
                BLL.ShowMessage(this, "From value Should be Less Than To Value.");
                rntxt_TdsFromVal.Text = null;
                rntxt_TdsToVal.Text = null;
                return;
            }
            string str_Params_Id = Convert.ToString(Session["str_Params_Id"]);
            _obj_smhr_Tds_Params = new SMHR_TDS_PARAMS();
            _obj_smhr_Tds_Params.TDS_PARAMS_SLAB_ID = Convert.ToInt32(rcmb_Slab.SelectedValue);
            _obj_smhr_Tds_Params.TDS_PARAMS_FROMVAL = Convert.ToSingle(rntxt_TdsFromVal.Text.Replace("'", "''"));
            _obj_smhr_Tds_Params.TDS_PARAMS_TOVAL = Convert.ToSingle(rntxt_TdsToVal.Text.Replace("'", "''"));
            if (rntxt_TdsVal.Text != string.Empty)
            {
                _obj_smhr_Tds_Params.TDS_PARAMS_VALUE = Convert.ToSingle(rntxt_TdsVal.Text.Replace("'", "''"));
            }
            if (rntxt_TdsPercent.Text != string.Empty)
            {
                _obj_smhr_Tds_Params.TDS_PARAMS_PERCENT = Convert.ToSingle(rntxt_TdsPercent.Text.Replace("'", "''"));
            }
            _obj_smhr_Tds_Params.TDS_PARAMS_PERIOD_ID = Convert.ToInt32(rcmb_Period.SelectedValue);
            _obj_smhr_Tds_Params.OPERATION = operation.Check1;
            DataTable dt = BLL.get_TDS_PARAMS(_obj_smhr_Tds_Params);
            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_UPDATE":

                    _obj_smhr_Tds_Params.OPERATION = operation.Update;
                    _obj_smhr_Tds_Params.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_Tds_Params.LASTMDFDATE = Convert.ToDateTime(DateTime.Now);
                    _obj_smhr_Tds_Params.TDS_PARAMS_ID = Convert.ToInt32(str_Params_Id);
                    if (BLL.set_TDS_PARAMS(_obj_smhr_Tds_Params))
                    {
                        BLL.ShowMessage(this, "Record Updated Successfully");

                    }
                    else
                    {
                        BLL.ShowMessage(this, "Unable to Update the Record");
                    }
                    break;
                case "BTN_SAVE":
                    _obj_smhr_Tds_Params.OPERATION = operation.Insert;
                    if (dt.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dt.Rows[0]["COUNT"]) != 0)
                        {
                            BLL.ShowMessage(this, "Slab for this values Already Exists!");
                            return;
                        }

                    }
                    _obj_smhr_Tds_Params.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_Tds_Params.CREATEDDATE = Convert.ToDateTime(DateTime.Now);
                    if (BLL.set_TDS_PARAMS(_obj_smhr_Tds_Params))
                    {
                        BLL.ShowMessage(this, "Record Inserted Successfully");

                    }
                    else
                    {
                        BLL.ShowMessage(this, "Unable to Save the Record");
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Tds_Params", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Tds_Params", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        rmp_Main.SelectedIndex = 0;
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

            btn_Save.Visible = false;
            btn_Update.Visible = true;
            loadBusinessUnit();
            loadPeriod();
            //loadSlabName();

            //rcmb_BusinessUnit.Enabled = false;
            rcmb_tdsname.Enabled = false;
            rcmb_Slab.Enabled = false;
            rcmb_Period.Enabled = false;
            rmp_Main.SelectedIndex = 1;
            Session["str_Params_Id"] = Convert.ToString(e.CommandArgument);
            string str_Params_Id = Convert.ToString(Session["str_Params_Id"]);

            _obj_smhr_Tds_Params = new SMHR_TDS_PARAMS();
            _obj_smhr_Tds_Params.OPERATION = operation.Validate1;
            _obj_smhr_Tds_Params.TDS_PARAMS_ID = Convert.ToInt32(str_Params_Id);
            DataTable dt_ComboBox = BLL.get_TDS_PARAMS(_obj_smhr_Tds_Params);
            if (dt_ComboBox.Rows.Count != 0)
            {
                //rcmb_BusinessUnit.SelectedIndex = rcmb_BusinessUnit.Items.FindItemIndexByValue(Convert.ToString(dt_ComboBox.Rows[0]["BUSINESSUNIT_ID"]));

                _obj_smhr_Tds = new SMHR_TDS();
                _obj_smhr_Tds.TDS_BUSINESSUNIT = Convert.ToInt32(dt_ComboBox.Rows[0]["BUSINESSUNIT_ID"]);
                _obj_smhr_Tds.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_smhr_Tds.OPERATION = operation.Check;
                DataTable dt_LocalisationID = BLL.get_Tds(_obj_smhr_Tds);
                Session["TDS_LOCALISATION_ID"] = Convert.ToInt32(dt_LocalisationID.Rows[0][0]);
                string str_Localisation_Id = Convert.ToString(Session["TDS_LOCALISATION_ID"]);
                rcmb_tdsname.SelectedIndex = rcmb_tdsname.Items.FindItemIndexByValue(Convert.ToString(dt_ComboBox.Rows[0]["TDS_ID"]));
                _obj_smhr_Tds_Slab = new SMHR_TDS_SLAB();
                _obj_smhr_Tds_Slab.OPERATION = operation.Check1;
                _obj_smhr_Tds_Slab.TDS_SLAB_LOCALISATION_ID = Convert.ToInt32(str_Localisation_Id);
                _obj_smhr_Tds_Slab.TDS_SLAB_BUSINESSUNIT_ID = Convert.ToInt32(dt_ComboBox.Rows[0]["BUSINESSUNIT_ID"]);
                _obj_smhr_Tds_Slab.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_smhr_Tds_Slab.TDS_SLAB_TDS_ID = Convert.ToInt32(rcmb_tdsname.SelectedItem.Value);
                DataTable dt_SlabName = BLL.get_TdsSlab(_obj_smhr_Tds_Slab);
                rcmb_Slab.DataSource = dt_SlabName;
                rcmb_Slab.DataTextField = "TDS_SLAB_NAME";
                rcmb_Slab.DataValueField = "TDS_SLAB_ID";
                rcmb_Slab.DataBind();
                rcmb_Slab.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

                rcmb_Slab.SelectedIndex = rcmb_Slab.Items.FindItemIndexByValue(Convert.ToString(dt_ComboBox.Rows[0]["TDS_SLAB_ID"]));
                rcmb_tdsname.SelectedIndex = rcmb_tdsname.Items.FindItemIndexByValue(Convert.ToString(dt_ComboBox.Rows[0]["TDS_ID"]));
                if (dt_ComboBox.Rows[0]["TDS_PARAMS_PERIOD_ID"] != System.DBNull.Value)
                {
                    rcmb_Period.SelectedIndex = rcmb_Period.Items.FindItemIndexByValue(Convert.ToString(dt_ComboBox.Rows[0]["TDS_PARAMS_PERIOD_ID"]));
                }
            }
            _obj_smhr_Tds_Params = new SMHR_TDS_PARAMS();
            _obj_smhr_Tds_Params.OPERATION = operation.Empty;
            _obj_smhr_Tds_Params.TDS_PARAMS_ID = Convert.ToInt32(str_Params_Id);
            DataTable dt_Params = BLL.get_TDS_PARAMS(_obj_smhr_Tds_Params);
            if (dt_Params.Rows.Count != 0)
            {
                rntxt_TdsFromVal.Text = Convert.ToString(dt_Params.Rows[0]["TDS_PARAMS_FROMVAL"]);
                rntxt_TdsToVal.Text = Convert.ToString(dt_Params.Rows[0]["TDS_PARAMS_TOVAL"]);
                rntxt_TdsVal.Text = Convert.ToString(dt_Params.Rows[0]["TDS_PARAMS_VALUE"]);
                rntxt_TdsPercent.Text = Convert.ToString(dt_Params.Rows[0]["TDS_PARAMS_PERCENT"]);
                //rcmb_Period.SelectedIndex = rcmb_Period.Items.FindItemIndexByValue(Convert.ToString(dt_Params.Rows[0]["PERIOD_ID"]));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Tds_Params", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Commnad(object sender, CommandEventArgs e)
    {
        try
        {
            rmp_Main.SelectedIndex = 1;
            rcmb_tdsname.Enabled = true;
            rcmb_Period.Enabled = true;
            rntxt_TdsFromVal.Text = null;
            rntxt_TdsToVal.Text = null;
            rntxt_TdsVal.Text = null;
            rntxt_TdsPercent.Text = null;
            btn_Update.Visible = false;
            btn_Save.Visible = true;
            loadBusinessUnit();
            loadPeriod();
            rcmb_Slab.Enabled = true;
            rcmb_Slab.Items.Clear();
            rcmb_Slab.Items.Insert(0, new RadComboBoxItem("", ""));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Tds_Params", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //COMMENTED BY SRAVANI 10.03.2011
    //protected void rcmb_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    //{
    //    try
    //    {
    //        _obj_smhr_Tds = new SMHR_TDS();
    //        _obj_smhr_Tds.TDS_BUSINESSUNIT = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
    //        _obj_smhr_Tds.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //        _obj_smhr_Tds.OPERATION = operation.Check;
    //        DataTable dt_LocalisationID = BLL.get_Tds(_obj_smhr_Tds);
    //        Session["TDS_LOCALISATION_ID"] = Convert.ToInt32(dt_LocalisationID.Rows[0][0]);
    //        //loadCountryId();
    //        loadSlabName();
    //    }
    //    catch(Exception ex)
    //    {   
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Tds_Params", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}

    //public void loadCountryId()
    //{
    //    if (rcmb_BusinessUnit.SelectedIndex > 0)
    //    {
    //        _obj_smhr_Tds = new SMHR_TDS();
    //        _obj_smhr_Tds.TDS_BUSINESSUNIT = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
    //        _obj_smhr_Tds.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //        _obj_smhr_Tds.OPERATION = operation.Check;
    //        DataTable dt_CountryID = BLL.get_Tds(_obj_smhr_Tds);
    //        Session["TDS_COUNTRY_ID"] = Convert.ToInt32(dt_CountryID.Rows[0][0]);
    //    }
    //}

    public void loadSlabName()
    {
        try
        {
            string str_Localisation_Id = Convert.ToString(Session["TDS_LOCALISATION_ID"]);
            _obj_smhr_Tds_Slab = new SMHR_TDS_SLAB();
            _obj_smhr_Tds_Slab.OPERATION = operation.Check1;
            _obj_smhr_Tds_Slab.TDS_SLAB_LOCALISATION_ID = Convert.ToInt32(Session["TDS_LOCALISATION_ID"]); //Convert.ToInt32(str_Localisation_Id);
            _obj_smhr_Tds_Slab.TDS_SLAB_BUSINESSUNIT_ID = Convert.ToInt32(Session["TDS_BU_ID"]); //Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
            _obj_smhr_Tds_Slab.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_Tds_Slab.TDS_SLAB_TDS_ID = Convert.ToInt32(rcmb_tdsname.SelectedItem.Value);
            DataTable dt_SlabName = BLL.get_TdsSlab(_obj_smhr_Tds_Slab);
            rcmb_Slab.DataSource = dt_SlabName;
            rcmb_Slab.DataTextField = "TDS_SLAB_NAME";
            rcmb_Slab.DataValueField = "TDS_SLAB_ID";
            rcmb_Slab.DataBind();
            rcmb_Slab.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Tds_Params", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void loadBusinessUnit()
    {
        try
        {
            //_obj_smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
            //_obj_smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //DataTable dt_BusinessUnit = BLL.get_BusinessUnit(_obj_smhr_BusinessUnit);
            //rcmb_BusinessUnit.DataSource = dt_BusinessUnit;
            //rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            //rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            //rcmb_BusinessUnit.DataBind();
            //rcmb_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
            rcmb_tdsname.Items.Clear();
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Tds_Params", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void loadGrid()
    {
        try
        {
            _obj_smhr_Tds_Params = new SMHR_TDS_PARAMS();
            _obj_smhr_Tds_Params.OPERATION = operation.Select;
            _obj_smhr_Tds_Params.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Params = BLL.get_TDS_PARAMS(_obj_smhr_Tds_Params);
            rg_Main.DataSource = dt_Params;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Tds_Params", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        //rg_Main.DataBind();
    }
    protected void rg_Main_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            loadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Tds_Params", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void clearControls()
    {
        try
        {
            //rcmb_BusinessUnit.SelectedIndex = 0;
            rcmb_tdsname.SelectedIndex = 0;
            rcmb_Slab.SelectedValue = null;
            rcmb_Period.SelectedIndex = 0;
            rntxt_TdsFromVal.Text = null;
            rntxt_TdsToVal.Text = null;
            rntxt_TdsVal.Text = null;
            rntxt_TdsPercent.Text = null;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Tds_Params", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void loadPeriod()
    {
        try
        {
            rcmb_Period.Items.Clear();
            obj_smhr_Period = new SMHR_PERIOD();
            obj_smhr_Period.OPERATION = operation.Select;
            obj_smhr_Period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Details = BLL.get_PeriodHeaderDetails(obj_smhr_Period);
            rcmb_Period.DataSource = dt_Details;
            rcmb_Period.DataValueField = "PERIOD_ID";
            rcmb_Period.DataTextField = "PERIOD_NAME";
            rcmb_Period.DataBind();
            rcmb_Period.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Tds_Params", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_UsePreviousData_Click(object sender, EventArgs e)
    {
        //_obj_smhr_Tds_Params = new SMHR_TDS_PARAMS();
        //_obj_smhr_Tds_Params.TDS_PARAMS_ID=
    }
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
            }
            loadSlabName();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Tds_Params", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
