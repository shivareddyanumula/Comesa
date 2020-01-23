using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using Telerik.Web.UI;
public partial class Masters_frm_TaxExempt : System.Web.UI.Page
{
    SMHR_TAX_EXEMPT _obj_smhr_TaxExempt;
    SMHR_COUNTRY _obj_smhr_Country;
    static string _lbl_ID = "";

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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("TAX EXEMPT MASTER");
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
                    RG_Tax_Exempt.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Add.Visible = false;
                    btn_Correct.Visible = false;
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TaxExempt", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    private void LoadDetails()
    {
        try
        {
            _obj_smhr_TaxExempt = new SMHR_TAX_EXEMPT();
            _obj_smhr_TaxExempt.Mode = 4;
            _obj_smhr_TaxExempt.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_Tax_Master(_obj_smhr_TaxExempt);
            RG_Tax_Exempt.DataSource = dt;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TaxExempt", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void RG_Tax_Exempt_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadDetails();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TaxExempt", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Click(object sender, EventArgs e)
    {
        try
        {
            RMP_Tax_Exempt.SelectedIndex = 1;
            clearFields();
            LoadCombos();
            btn_Correct.Visible = false;
            btn_Add.Visible = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TaxExempt", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void clearFields()
    {
        try
        {
            ddl_Country.Items.Clear();
            rtxt_TaxDesc.Text = string.Empty;
            rtxt_TaxName.Text = string.Empty;
            //chk_Active.Checked = false;
            ddl_Active.SelectedValue = "1";
            rntxt_MaxLimit.Value = null;
            ddl_Country.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TaxExempt", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadCombos()
    {
        try
        {
            _obj_smhr_Country = new SMHR_COUNTRY();
            _obj_smhr_Country.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_Country.OPERATION = operation.Select;
            DataTable DT = BLL.get_Country(_obj_smhr_Country);
            ddl_Country.Items.Clear();
            ddl_Country.DataSource = DT;
            ddl_Country.DataTextField = "COUNTRY_CODE";
            ddl_Country.DataValueField = "COUNTRY_ID";
            ddl_Country.DataBind();
            ddl_Country.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TaxExempt", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            LoadCombos();
            _lbl_ID = Convert.ToString(e.CommandArgument);
            getDetails(_lbl_ID);
            RMP_Tax_Exempt.SelectedIndex = 1;
            ddl_Country.Enabled = false;
            //code for security
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Correct.Visible = false;

            }

            else
            {
                btn_Correct.Visible = true;
            }

            btn_Add.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TaxExempt", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void getDetails(string ID)
    {
        try
        {
            _obj_smhr_TaxExempt = new SMHR_TAX_EXEMPT();
            _obj_smhr_TaxExempt.Mode = 5;
            _obj_smhr_TaxExempt.SMHR_TAX_ID = Convert.ToInt32(ID);
            DataTable dt = BLL.get_Tax_Master(_obj_smhr_TaxExempt);
            if (dt.Rows.Count != 0)
            {
                ddl_Country.SelectedIndex = ddl_Country.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["SMHR_TAX_COUNTRY_ID"]));
                rtxt_TaxName.Text = Convert.ToString(dt.Rows[0]["SMHR_TAX_NAME"]);
                rtxt_TaxDesc.Text = Convert.ToString(dt.Rows[0]["SMHR_TAX_DESC"]);
                rntxt_MaxLimit.Value = Convert.ToDouble(Convert.ToString(dt.Rows[0]["SMHR_TAX_MAXLIMIT"]));
                if (Convert.ToBoolean(dt.Rows[0]["SMHR_TAX_ACTIVE"]) == true)
                    ddl_Active.SelectedValue = "1";
                else
                    ddl_Active.SelectedValue = "0";

                //chk_Active.Checked = Convert.ToBoolean(dt.Rows[0]["SMHR_TAX_ACTIVE"]);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TaxExempt", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Add_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_smhr_TaxExempt = new SMHR_TAX_EXEMPT();

            //if (chk_Active.Checked)
            //    _obj_smhr_TaxExempt.SMHR_TAX_ACTIVE = true;
            //else
            //    _obj_smhr_TaxExempt.SMHR_TAX_ACTIVE = false;

            _obj_smhr_TaxExempt.Mode = 7;
            _obj_smhr_TaxExempt.SMHR_TAX_COUNTRY_ID = Convert.ToInt32(ddl_Country.SelectedValue);
            _obj_smhr_TaxExempt.SMHR_TAX_NAME = Convert.ToString(rtxt_TaxName.Text.Replace("'", "''"));
            DataTable dt = BLL.get_Tax_Master(_obj_smhr_TaxExempt);
            if (Convert.ToString(dt.Rows[0]["COUNT"]) == "0")
            {
                _obj_smhr_TaxExempt.Mode = 2;
                _obj_smhr_TaxExempt.SMHR_TAX_DESC = Convert.ToString(rtxt_TaxDesc.Text.Replace("'", "''"));
                _obj_smhr_TaxExempt.SMHR_TAX_MAXLIMIT = Convert.ToDouble(rntxt_MaxLimit.Value);
                if (ddl_Active.SelectedValue == "1")
                    _obj_smhr_TaxExempt.SMHR_TAX_ACTIVE = true;
                else
                    _obj_smhr_TaxExempt.SMHR_TAX_ACTIVE = false;
                _obj_smhr_TaxExempt.SMHR_TAX_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_smhr_TaxExempt.SMHR_TAX_CREATEDDATE = DateTime.Now;
                bool status = BLL.set_TaxExempt(_obj_smhr_TaxExempt);
                if (status == true)
                {
                    BLL.ShowMessage(this, "Element Added Successfully");
                    RMP_Tax_Exempt.SelectedIndex = 0;
                    LoadDetails();
                    RG_Tax_Exempt.DataBind();
                    return;
                }
                else
                {
                    BLL.ShowMessage(this, "An Error Occured while doing the process");
                    return;
                }
            }
            else
            {
                BLL.ShowMessage(this, "Tax Element Already Exists");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TaxExempt", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Correct_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_smhr_TaxExempt = new SMHR_TAX_EXEMPT();
            _obj_smhr_TaxExempt.Mode = 3;
            _obj_smhr_TaxExempt.SMHR_TAX_COUNTRY_ID = Convert.ToInt32(ddl_Country.SelectedValue);
            _obj_smhr_TaxExempt.SMHR_TAX_NAME = Convert.ToString(rtxt_TaxName.Text.Replace("'", "''"));
            _obj_smhr_TaxExempt.SMHR_TAX_DESC = Convert.ToString(rtxt_TaxDesc.Text.Replace("'", "''"));
            _obj_smhr_TaxExempt.SMHR_TAX_MAXLIMIT = Convert.ToDouble(rntxt_MaxLimit.Value);
            if (ddl_Active.SelectedValue == "1")
                _obj_smhr_TaxExempt.SMHR_TAX_ACTIVE = true;
            else
                _obj_smhr_TaxExempt.SMHR_TAX_ACTIVE = false;
            _obj_smhr_TaxExempt.SMHR_TAX_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_TaxExempt.SMHR_TAX_LASTMDFDATE = DateTime.Now;
            _obj_smhr_TaxExempt.SMHR_TAX_ID = Convert.ToInt32(_lbl_ID);
            bool status = BLL.set_TaxExempt(_obj_smhr_TaxExempt);
            if (status == true)
            {
                BLL.ShowMessage(this, "Element Updated Successfully");
                RMP_Tax_Exempt.SelectedIndex = 0;
                LoadDetails();
                RG_Tax_Exempt.DataBind();
                return;
            }
            else
            {
                BLL.ShowMessage(this, "An Error Occured while doing the process");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TaxExempt", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearFields();
            LoadDetails();
            RG_Tax_Exempt.DataBind();
            RMP_Tax_Exempt.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TaxExempt", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
