﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Data;
using System.Data.SqlClient;
using Telerik.Web.UI;


public partial class Masters_frm_NHIFslab : System.Web.UI.Page
{
    SMHR_TAX_SLAB _obj_smhr_taxslab;
    static string _lbl_ID = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {


        try
        {
            Page.Validate();
            if (!Page.IsPostBack)
            {

                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("NHIF");//NHIF SLAB");
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

                    btn_Include.Visible = false;

                }
                else if (Convert.ToInt32(Session["WRITEFACILITY"]) == 3)
                {
                    btn_Include.Visible = true;
                    smhr_UNAUTHORIZED _obj_smhr_unauthorized = new smhr_UNAUTHORIZED();
                    _obj_smhr_unauthorized.UNAUTHORIZED_USERID = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_unauthorized.UNAUTHORIZED_FORMID = Convert.ToInt32(ViewState["FORMS_ID"]);
                    _obj_smhr_unauthorized.UNAUTHORIZED_MODULEID = Convert.ToInt32(ViewState["MODULE_ID"]);
                    _obj_smhr_unauthorized.UNAUTHORIZED_ACCESSDATE = Convert.ToDateTime(DateTime.Now.ToString());
                    SMHR.BLL.UnAuthorized_Log(_obj_smhr_unauthorized);
                    Response.Redirect("~/frm_UnAuthorized.aspx", false);
                }
                LoadBusinessUnit();
                rntxt_ToValue.Attributes.Add("OnUnload", "CheckValue()");
                clearFields();
                btn_Update.Visible = false;
                RG_TaxSlab.Visible = false;



            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_NHIFslab", ex.StackTrace, DateTime.Now);
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
            _obj_smhr_taxslab = new SMHR_TAX_SLAB();
            _obj_smhr_taxslab.SMHR_TAXMODE = 1;
            _obj_smhr_taxslab.SMHR_TAXBU = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
            DataTable dt = BLL.get_NHIFSlab(_obj_smhr_taxslab);
            RG_TaxSlab.DataSource = dt;
            RG_TaxSlab.DataBind();
            if (dt.Rows.Count <= 0)
            {
                rntxt_FromValue.Text = "";
                rntxt_ToValue.Text = "";
                rntxt_Value.Text = "";
                //rtxt_Serial.Text = "";
            }
            int fromval = RG_TaxSlab.Items.Count - 1;
            LinkButton lnkEdit = new LinkButton();
            LinkButton lnkDel = new LinkButton();

            if (RG_TaxSlab.Items.Count - 1 > 0)
            {
                for (int i = 0; i < RG_TaxSlab.Items.Count - 1; i++)
                {
                    lnkEdit = RG_TaxSlab.Items[i].FindControl("lnk_Edit") as LinkButton;
                    lnkDel = RG_TaxSlab.Items[i].FindControl("lnk_Delete") as LinkButton;
                    lnkDel.Attributes.Add("onclick", "return ConfirmationDelete();");
                    //lnkEdit.Visible = false;
                    lnkDel.Visible = false;
                }
                lnkEdit = RG_TaxSlab.Items[fromval].FindControl("lnk_Edit") as LinkButton;
                lnkDel = RG_TaxSlab.Items[fromval].FindControl("lnk_Delete") as LinkButton;
                lnkDel.Attributes.Add("onclick", "return ConfirmationDelete();");
                lnkEdit.Visible = true;
                lnkDel.Visible = true;
            }
            rntxt_ToValue.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_NHIFslab", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            _lbl_ID = Convert.ToString(e.CommandArgument);
            _obj_smhr_taxslab = new SMHR_TAX_SLAB();
            _obj_smhr_taxslab.SMHR_TAXMODE = 5;
            _obj_smhr_taxslab.SMHR_ID = Convert.ToInt32(_lbl_ID);
            DataTable dt = BLL.get_NHIFSlab(_obj_smhr_taxslab);
            if (dt.Rows.Count != 0)
            {
                rtxt_Serial.Text = Convert.ToString(dt.Rows[0]["SMHR_TAXSERIALNO"]);
                rntxt_FromValue.Value = Convert.ToDouble(Convert.ToString(dt.Rows[0]["SMHR_TAXFROMVALUE"]));
                rntxt_ToValue.Value = Convert.ToDouble(Convert.ToString(dt.Rows[0]["SMHR_TAXTOVALUE"]));
                rntxt_Value.Value = Convert.ToDouble(Convert.ToString(dt.Rows[0]["SMHR_TAXVALUE"]));
                btn_Include.Visible = false;

                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {

                    btn_Update.Visible = false;

                }
                else
                {
                    btn_Update.Visible = true;
                }

                rntxt_FromValue.Enabled = false;
                rntxt_ToValue.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_NHIFslab", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Del_Command(object sender, CommandEventArgs e)
    {
        try
        {
            Label lblID = new Label();
            lblID.Text = Convert.ToString(e.CommandArgument);
            _obj_smhr_taxslab = new SMHR_TAX_SLAB();
            _obj_smhr_taxslab.SMHR_TAXMODE = 4;
            _obj_smhr_taxslab.SMHR_ID = Convert.ToInt32(lblID.Text);
            bool status = BLL.set_NHIFSlab(_obj_smhr_taxslab);
            if (status == true)
            {
                BLL.ShowMessage(this, "Information Deleted Successfully");
                LoadDetails();
                clearFields();
                GetCount();
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_NHIFslab", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void clearFields()
    {
        try
        {
            rntxt_FromValue.Value = null;
            rntxt_ToValue.Value = null;
            rntxt_Value.Value = null;
            rntxt_FromValue.Text = "";
            rntxt_ToValue.Text = "";
            rntxt_Value.Text = "";
            //code for security
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Include.Visible = false;
            }

            else
            {
                btn_Include.Visible = true;
            }

            btn_Update.Visible = false;
            rntxt_FromValue.Enabled = true;

            int fromval = RG_TaxSlab.Items.Count - 1;
            Label lblFromVal = new Label();
            if (RG_TaxSlab.Items.Count > 0)
            {
                lblFromVal = RG_TaxSlab.Items[fromval].FindControl("lbl_TaxTovalue") as Label;
                rntxt_FromValue.Value = Convert.ToDouble(Convert.ToDouble(Convert.ToString(lblFromVal.Text)) + 1);
                rntxt_FromValue.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_NHIFslab", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void GetCount()
    {
        try
        {
            _obj_smhr_taxslab = new SMHR_TAX_SLAB();
            _obj_smhr_taxslab.SMHR_TAXMODE = 1;
            _obj_smhr_taxslab.SMHR_TAXBU = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
            DataTable dt = BLL.get_NHIFSlab(_obj_smhr_taxslab);
            if (dt.Rows.Count != 0)
            {
                rtxt_Serial.Text = Convert.ToString(Convert.ToInt32(dt.Rows.Count) + 1);
            }
            else
            {
                rtxt_Serial.Text = "1";
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_NHIFslab", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearFields();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_NHIFslab", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Include_Click(object sender, EventArgs e)
    {
        try
        {

            GetCount();
            _obj_smhr_taxslab = new SMHR_TAX_SLAB();
            _obj_smhr_taxslab.SMHR_TAXMODE = 2;
            if (ddl_BusinessUnit.SelectedIndex > 0)
                _obj_smhr_taxslab.SMHR_TAXBU = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
            else
                return;

            _obj_smhr_taxslab.SMHR_TAXSERIALNO = Convert.ToInt32(Convert.ToString(rtxt_Serial.Text));
            _obj_smhr_taxslab.SMHR_TAXFROMVALUE = Convert.ToDouble(rntxt_FromValue.Value);
            _obj_smhr_taxslab.SMHR_TAXTOVALUE = Convert.ToDouble(rntxt_ToValue.Value);
            _obj_smhr_taxslab.SMHR_TAXVALUE = Convert.ToDouble(rntxt_Value.Value);
            _obj_smhr_taxslab.SMHR_TAXCREATEDBY = Convert.ToInt32(Convert.ToString(Session["USER_ID"]));
            _obj_smhr_taxslab.SMHR_TAXCREATEDDATE = DateTime.Now;
            _obj_smhr_taxslab.SMHR_TAXMODE = 6;
            if (Convert.ToString(BLL.get_NHIFSlab(_obj_smhr_taxslab).Rows[0]["Count"]) != "0")
            {
                BLL.ShowMessage(this, "This Tax Value Alredy Exists.");
                return;
            }
            _obj_smhr_taxslab.SMHR_TAXMODE = 2;
            bool status = BLL.set_NHIFSlab(_obj_smhr_taxslab);
            if (status == true)
            {
                BLL.ShowMessage(this, "Information Inserted Successfully");
                LoadDetails();
                clearFields();
                GetCount();
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_NHIFslab", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Update_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_smhr_taxslab = new SMHR_TAX_SLAB();
            _obj_smhr_taxslab.SMHR_TAXMODE = 3;
            _obj_smhr_taxslab.SMHR_TAXBU = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
            _obj_smhr_taxslab.SMHR_TAXSERIALNO = Convert.ToInt32(Convert.ToString(rtxt_Serial.Text));
            int cnt;
            Label toval = new Label();
            //cnt = RG_TaxSlab.Items.Count - 2;
            cnt = RG_TaxSlab.Items.Count - 1;
            toval = RG_TaxSlab.Items[cnt].FindControl("lbl_TaxTovalue") as Label;
            if (Convert.ToDouble(rntxt_FromValue.Value) < Convert.ToDouble(rntxt_ToValue.Text.ToString()))
            {
                _obj_smhr_taxslab.SMHR_TAXFROMVALUE = Convert.ToDouble(rntxt_FromValue.Value);
                _obj_smhr_taxslab.SMHR_TAXTOVALUE = Convert.ToDouble(rntxt_ToValue.Value);
                _obj_smhr_taxslab.SMHR_TAXVALUE = Convert.ToDouble(rntxt_Value.Value);
                _obj_smhr_taxslab.SMHR_TAXLASTMDFBY = Convert.ToInt32(Convert.ToString(Session["USER_ID"]));
                _obj_smhr_taxslab.SMHR_TAXLASTMDFDATE = DateTime.Now;
                _obj_smhr_taxslab.SMHR_ID = Convert.ToInt32(Convert.ToString(_lbl_ID));
                bool status = BLL.set_NHIFSlab(_obj_smhr_taxslab);
                if (status == true)
                {
                    BLL.ShowMessage(this, "Information Updated Successfully");
                    LoadDetails();
                    clearFields();
                    GetCount();
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
                BLL.ShowMessage(this, "Fromvalue should be greater than the previous Tovalue");
                rntxt_FromValue.Focus();
                rntxt_FromValue.Text = "";
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_NHIFslab", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    private void LoadBusinessUnit()
    {
        try
        {
            SMHR_LOGININFO _obj_LoginInfo = new SMHR_LOGININFO();
            _obj_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            ddl_BusinessUnit.Items.Clear();
            ddl_BusinessUnit.DataSource = BLL.get_Business_Units(_obj_LoginInfo);
            ddl_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            ddl_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            ddl_BusinessUnit.DataBind();
            ddl_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_NHIFslab", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void ddl_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (ddl_BusinessUnit.SelectedIndex != 0)
            {
                LoadDetails();
                GetCount();
                int fromval = RG_TaxSlab.Items.Count - 1;
                Label lblFromVal = new Label();
                if (RG_TaxSlab.Items.Count > 0)
                {
                    lblFromVal = RG_TaxSlab.Items[fromval].FindControl("lbl_TaxTovalue") as Label;
                    rntxt_FromValue.Value = Convert.ToDouble(Convert.ToDouble(Convert.ToString(lblFromVal.Text)) + 1);
                    rntxt_FromValue.Enabled = false;
                }
                else
                {
                    rntxt_FromValue.Enabled = true;
                }



                RG_TaxSlab.Visible = true;


                //code for security
                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    RG_TaxSlab.Enabled = false;

                }


            }
            else
            {
                RG_TaxSlab.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_NHIFslab", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}