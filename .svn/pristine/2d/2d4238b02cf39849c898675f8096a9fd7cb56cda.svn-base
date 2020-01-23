using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using Telerik.Web.UI;
using System.Data;

public partial class Masters_frm_CopyTdsParams : System.Web.UI.Page
{
    SMHR_ORGANISATION _obj_smhr_Organisation;
    SMHR_BUSINESSUNIT _obj_smhr_BusinessUnit;
    //SMHR_TDS _obj_smhr_Tds;
    //SMHR_TDS_SLAB _obj_smhr_Tds_Slab;
    SMHR_TDS_PARAMS _obj_smhr_Tds_Params;
    SMHR_PERIOD obj_smhr_Period;
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
                    //Rg_Countries.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Copy.Visible = false;
                    //  btn_Update.Visible = false;
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
                loadDropdown();
                loadPreviousPeriod();
                loadCurrentPeriod();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CopyTdsParams", ex.StackTrace, DateTime.Now);
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

            rcmb_tdsname.Items.Clear();
            SMHR_TDS_SLAB _obj_smhr_Tds_Slab = new SMHR_TDS_SLAB();
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CopyTdsParams", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void loadPreviousPeriod()
    {
        try
        {
            obj_smhr_Period = new SMHR_PERIOD();
            obj_smhr_Period.OPERATION = operation.Empty1;
            obj_smhr_Period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Details = BLL.get_PeriodHeaderDetails(obj_smhr_Period);
            rcmb_PreviousPeriod.DataSource = dt_Details;
            rcmb_PreviousPeriod.DataValueField = "PERIOD_ID";
            rcmb_PreviousPeriod.DataTextField = "PERIOD_NAME";
            rcmb_PreviousPeriod.DataBind();
            rcmb_PreviousPeriod.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CopyTdsParams", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void loadCurrentPeriod()
    {
        try
        {
            obj_smhr_Period = new SMHR_PERIOD();
            //obj_smhr_Period.OPERATION = operation.Select;
            obj_smhr_Period.OPERATION = operation.Empty;
            obj_smhr_Period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Details = BLL.get_PeriodHeaderDetails(obj_smhr_Period);
            rcmb_CurrentPeriod.DataSource = dt_Details;
            rcmb_CurrentPeriod.DataValueField = "PERIOD_ID";
            rcmb_CurrentPeriod.DataTextField = "PERIOD_NAME";
            rcmb_CurrentPeriod.DataBind();
            rcmb_CurrentPeriod.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CopyTdsParams", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Copy_Click(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToInt32(rcmb_PreviousPeriod.SelectedItem.Value) == Convert.ToInt32(rcmb_CurrentPeriod.SelectedItem.Value))
            {
                BLL.ShowMessage(this, "Please Select different periods.");
                return;
            }
            _obj_smhr_Tds_Params = new SMHR_TDS_PARAMS();
            _obj_smhr_Tds_Params.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_Tds_Params.CREATEDDATE = Convert.ToDateTime(DateTime.Now);
            _obj_smhr_Tds_Params.TDS_PARAMS_CURRENTPERIOD_ID = Convert.ToInt32(rcmb_CurrentPeriod.SelectedValue);
            _obj_smhr_Tds_Params.TDS_PARAMS_PERIOD_ID = Convert.ToInt32(rcmb_PreviousPeriod.SelectedValue);
            _obj_smhr_Tds_Params.TDS_PARAMS_TDS_ID = Convert.ToInt32(rcmb_tdsname.SelectedItem.Value);
            _obj_smhr_Tds_Params.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_Tds_Params.OPERATION = operation.Get;
            DataTable dt = BLL.get_TDS_PARAMS(_obj_smhr_Tds_Params);
            if (dt.Rows.Count > 0)
            {
                _obj_smhr_Tds_Params.OPERATION = operation.Delete;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    _obj_smhr_Tds_Params.TDS_PARAMS_SLAB_ID = Convert.ToInt32(dt.Rows[i]["TDS_SLAB_ID"]);
                    if (BLL.set_TDS_PARAMS(_obj_smhr_Tds_Params))
                    {
                    }
                }
                _obj_smhr_Tds_Params.OPERATION = operation.Validate;
                if (BLL.set_TDS_PARAMS(_obj_smhr_Tds_Params))
                {
                    BLL.ShowMessage(this, "Tds Values of Previous Period Are Copied to Current Period");
                }
                else
                {
                    BLL.ShowMessage(this, "Error Ocurred");
                }

            }
            else
            {
                BLL.ShowMessage(this, "First define Slabs for Selected TDS");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CopyTdsParams", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
}
