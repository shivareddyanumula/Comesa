using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
//using SPMS;
using Telerik.Web.UI;
using SMHR;
using System.Text;

public partial class PMS_frm_Smhr_HRA : System.Web.UI.Page
{
    SMHR_BUSINESSUNIT _obj_smhr_businessunit;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_HRA _obj_Smhr_Hra;
    SMHR_EMP_HRA _obj_Smhr_emp_Hra = new SMHR_EMP_HRA();
    SMHR_PERIOD _obj_smhr_period;
    double hra;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
            if (!Page.IsPostBack)
            {

                //lbl_Period.Visible = false;
                //ddl_Period.Visible = false; 

                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("HRA CALCULATION");
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
                    Rg_EmployeeTaxHra.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_save.Visible = false;
                    //btn_Update.Visible = false;
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
                LoadCombos();
                clearControls();
                btn_Cancel.Visible = false;
                tr_prd.Visible = false;
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Smhr_HRA", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/frm_UnAuthorized.aspx", false);

            return;
        }
    }

    #region loadcombos,clearfields
    protected void clearControls()
    {
        try
        {
            //lbl_payitem.Visible = false;
            //rcm_Recur_payitem.Visible = false;
            //lbl_ExcessPayitems.Visible = false;
            //rlb_ExcessPayitems.Visible = false;
            lbl_TaxExemptedelements.Visible = false;
            rcm_TaxExemptedelements.Visible = false;
            Rg_EmployeeTaxHra.Visible = false;
            lbl_Period.Visible = false;
            //ddl_Period.Enabled = false; 
            btn_view.Visible = false;
            btn_calculate.Visible = false;
            btn_save.Visible = false;
            btn_Finalise.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Smhr_HRA", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/frm_UnAuthorized.aspx", false);

            return;
        }
    }


    private void LoadCombos()
    {
        try
        {
            _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();


            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            if (dt_BUDetails.Rows.Count != 0)
            {
                rcm_bu_type.DataSource = dt_BUDetails;
                rcm_bu_type.DataValueField = "BUSINESSUNIT_ID";
                rcm_bu_type.DataTextField = "BUSINESSUNIT_CODE";
                rcm_bu_type.DataBind();
                rcm_bu_type.Items.Insert(0, new RadComboBoxItem("Select"));
            }

            else
            {
                DataTable dt_Details = new DataTable();
                rcm_bu_type.DataSource = dt_Details;

                rcm_bu_type.DataBind();
                rcm_bu_type.Items.Insert(0, new RadComboBoxItem("Select"));
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Smhr_HRA", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/frm_UnAuthorized.aspx", false);
            return;
        }
    }
    #endregion


    #region businessunit index changed
    protected void rcm_bu_type_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {

            if ((rcm_bu_type.SelectedItem.Text == "Select"))
            {

                BLL.ShowMessage(this, "Please Select Business Unit");
                lbl_Period.Visible = true;
                ddl_Period.Enabled = true;
                ddl_Period.ClearSelection();
                rcm_TaxExemptedelements.ClearSelection();
                //  clearControls();
                rcm_TaxExemptedelements.Enabled = true;

                // ddl_Period.Enabled  = true; 

                //LoadPeriods();
                btn_Cancel.Visible = false;
                return;
            }
            else
            {
                clearControls();
                tr_prd.Visible = true;
                LoadPeriods();
                LoadTaxExemptElements();
                //lbl_payitem.Visible = true;
                //rcm_Recur_payitem.Visible = true;
                //lbl_ExcessPayitems.Visible = true;
                //rlb_ExcessPayitems.Visible = true;
                lbl_TaxExemptedelements.Visible = true;
                rcm_TaxExemptedelements.Visible = true;
                lbl_Period.Visible = true;
                ddl_Period.Visible = true;
                //rlb_ExcessPayitems.Enabled = true;
                btn_view.Enabled = true;

                _obj_Smhr_Hra = new SMHR_HRA();
                _obj_Smhr_Hra.SMHR_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_Hra.Mode = 1;
                DataTable dt_payitem = BLL.get_Smhr_Hra(_obj_Smhr_Hra);
                if (dt_payitem.Rows.Count != 0)
                {
                    //rcm_Recur_payitem.DataSource = dt_payitem;
                    //rcm_Recur_payitem.DataValueField = "PAYITEM_ID";
                    //rcm_Recur_payitem.DataTextField = "PAYITEM_PAYITEMNAME";
                    //rcm_Recur_payitem.DataBind();
                    //rcm_Recur_payitem.Items.Insert(0, new RadComboBoxItem("Select"));

                    //rcm_Recur_payitem.Enabled = true;

                    //rcm_Recur_payitem.SelectedIndex = rcm_Recur_payitem.Items.FindItemIndexByText(Convert.ToString("HRA").Trim().ToUpper());

                }

                else
                {
                    BLL.ShowMessage(this, "PayItems Are Not Available");
                    DataTable dt_Details = new DataTable();
                    //rcm_Recur_payitem.DataSource = dt_Details;

                    //rcm_Recur_payitem.DataBind();
                    //rcm_Recur_payitem.Items.Insert(0, new RadComboBoxItem("Select"));

                }

                #region tax elements


                _obj_Smhr_Hra = new SMHR_HRA();
                _obj_Smhr_Hra.Mode = 2;
                _obj_Smhr_Hra.SMHR_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                //if (rcm_Recur_payitem.SelectedIndex != 0)
                //{
                //    _obj_Smhr_Hra.SMHR_PAYITEMID1 = Convert.ToInt32(rcm_Recur_payitem.SelectedItem.Value);
                //}
                //DataTable dt_excesspayitems = BLL.get_Smhr_Hra(_obj_Smhr_Hra);
                //if (dt_excesspayitems.Rows.Count != 0)
                //{
                //    rlb_ExcessPayitems.DataSource = dt_excesspayitems;
                //    rlb_ExcessPayitems.DataTextField = "PAYITEM_PAYITEMNAME";
                //    rlb_ExcessPayitems.DataValueField = "PAYITEM_ID";
                //    rlb_ExcessPayitems.DataBind();
                //}

                //else
                //{

                //    DataTable dt_Details = new DataTable();
                //    rlb_ExcessPayitems.DataSource = dt_Details;

                //    rlb_ExcessPayitems.DataBind();


                //}
                //LoadPeriods();
                //_obj_Smhr_Hra = new SMHR_HRA();
                //_obj_Smhr_Hra.Mode = 3;
                //_obj_Smhr_Hra.SMHR_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);

                //DataTable dt_TAXEXEMPT = BLL.get_Smhr_Hra(_obj_Smhr_Hra);
                //if (dt_TAXEXEMPT.Rows.Count != 0)
                //{
                //    rcm_TaxExemptedelements.DataSource = dt_TAXEXEMPT;
                //    rcm_TaxExemptedelements.DataValueField = "SMHR_TAX_ID";
                //    rcm_TaxExemptedelements.DataTextField = "SMHR_TAX_NAME";
                //    rcm_TaxExemptedelements.DataBind();
                //    rcm_TaxExemptedelements.Items.Insert(0, new RadComboBoxItem("Select"));
                //    //code for security
                //    if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                //    {
                //        btn_view.Visible = false;

                //    }

                //    else
                //    {
                //        btn_view.Visible = true;
                //    }

                //    //rcm_TaxExemptedelements.SelectedIndex = rcm_TaxExemptedelements.Items.FindItemIndexByText(Convert.ToString("HRA").Trim().ToUpper());
                //    rcm_TaxExemptedelements.Enabled = true;
                //}

                //else
                //{

                //    DataTable dt_Details = new DataTable();
                //    rcm_TaxExemptedelements.DataSource = dt_Details;

                //    rcm_TaxExemptedelements.DataBind();
                //    rcm_TaxExemptedelements.Items.Insert(0, new RadComboBoxItem("Select"));


                //}

                #endregion

                btn_Cancel.Visible = false;

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Smhr_HRA", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/frm_UnAuthorized.aspx", false);
            return;
        }
    }

    #endregion


    private void LoadTaxExemptElements()
    {
        try
        {
            _obj_Smhr_Hra = new SMHR_HRA();
            _obj_Smhr_Hra.Mode = 3;
            _obj_Smhr_Hra.SMHR_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);

            DataTable dt_TAXEXEMPT = BLL.get_Smhr_Hra(_obj_Smhr_Hra);
            //  ViewState["dt_TAXEXEMPT"]=dt_TAXEXEMPT;
            if (dt_TAXEXEMPT.Rows.Count != 0)
            {
                rcm_TaxExemptedelements.DataSource = dt_TAXEXEMPT;
                rcm_TaxExemptedelements.DataValueField = "SMHR_TAX_ID";
                rcm_TaxExemptedelements.DataTextField = "SMHR_TAX_NAME";
                rcm_TaxExemptedelements.DataBind();
                rcm_TaxExemptedelements.Items.Insert(0, new RadComboBoxItem("Select"));
                //code for security
                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    btn_view.Visible = false;

                }

                else
                {
                    btn_view.Visible = true;
                }

                //rcm_TaxExemptedelements.SelectedIndex = rcm_TaxExemptedelements.Items.FindItemIndexByText(Convert.ToString("HRA").Trim().ToUpper());
                rcm_TaxExemptedelements.Enabled = true;
            }

            else
            {

                DataTable dt_Details = new DataTable();
                rcm_TaxExemptedelements.DataSource = dt_Details;

                rcm_TaxExemptedelements.DataBind();
                rcm_TaxExemptedelements.Items.Insert(0, new RadComboBoxItem("Select"));

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Smhr_HRA", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/frm_UnAuthorized.aspx", false);
        }

    }
    private void LoadPeriods()
    {
        try
        {
            if (ddl_Period.SelectedIndex != 0)
            {
                _obj_smhr_period = new SMHR_PERIOD();
                _obj_smhr_period.OPERATION = operation.Select;
                _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_Details = BLL.get_PeriodHeaderDetails(_obj_smhr_period);
                ddl_Period.DataSource = dt_Details;
                ddl_Period.DataValueField = "PERIOD_ID";
                ddl_Period.DataTextField = "PERIOD_NAME";
                ddl_Period.DataBind();
                ddl_Period.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Smhr_HRA", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #region view click method
    protected void btn_view_Click(object sender, EventArgs e)
    {

        try
        {
            _obj_Smhr_Hra = new SMHR_HRA();
            _obj_Smhr_Hra.Mode = 11;
            _obj_Smhr_Hra.SMHR_ORG_ID = Convert.ToInt32(rcm_bu_type.SelectedItem.Value);
            _obj_Smhr_Hra.SMHR_HRA_LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
            //  _obj_Smhr_Hra.SMHR_PAYITEMID1 = Convert.ToInt32(rcm_Recur_payitem.SelectedItem.Value);
            // _obj_Smhr_Hra.SMHR_HRA_MUL_ID = Convert.ToString(Label1.Text);
            _obj_Smhr_Hra.SMHR_HRA_TAXEXEMPTEDELEMENTS = Convert.ToInt32(rcm_TaxExemptedelements.SelectedItem.Value);
            DataTable dt_fianltable1 = BLL.get_Smhr_Hra(_obj_Smhr_Hra);

            //if suppose that employee already has the data
            if (dt_fianltable1.Rows.Count == 0)
            {
                //_obj_Smhr_Hra = new SMHR_HRA();
                //_obj_Smhr_Hra.Mode = 5;
                //_obj_Smhr_Hra.SMHR_ORG_ID = Convert.ToInt32(rcm_bu_type.SelectedItem.Value);
                //_obj_Smhr_Hra.SMHR_PAYITEMID1 = Convert.ToInt32(rcm_Recur_payitem.SelectedItem.Value);
                //DataTable dt_emppayitesvalue = BLL.get_Smhr_Hra(_obj_Smhr_Hra);

                //_obj_Smhr_Hra = new SMHR_HRA();
                //_obj_Smhr_Hra.Mode = 6;
                //_obj_Smhr_Hra.SMHR_ORG_ID = Convert.ToInt32(rcm_bu_type.SelectedItem.Value);
                //_obj_Smhr_Hra.SMHR_HRA_MUL_ID = Convert.ToString(Label1.Text);
                //DataTable dt_10EXCESS = BLL.get_Smhr_Hra(_obj_Smhr_Hra);

                _obj_Smhr_Hra = new SMHR_HRA();
                _obj_Smhr_Hra.Mode = 7;

                _obj_Smhr_Hra.SMHR_ORG_ID = Convert.ToInt32(rcm_bu_type.SelectedItem.Value);
                _obj_Smhr_Hra.SMHR_PERIOD_ID = Convert.ToInt32(ddl_Period.SelectedItem.Value);
                _obj_Smhr_Hra.SMHR_HRA_TAXEXEMPTEDELEMENTS = Convert.ToInt32(rcm_TaxExemptedelements.SelectedItem.Value);


                //  _obj_Smhr_Hra.SMHR_PAYITEMID1 = Convert.ToInt32(rcm_Recur_payitem.SelectedItem.Value);
                //  _obj_Smhr_Hra.SMHR_HRA_MUL_ID = Convert.ToString(Label1.Text);
                _obj_Smhr_Hra.SMHR_HRA_LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_fianltable = BLL.get_Smhr_Hra(_obj_Smhr_Hra);
                if (dt_fianltable.Rows.Count != 0)
                {
                    Rg_EmployeeTaxHra.DataSource = dt_fianltable;
                    Rg_EmployeeTaxHra.DataBind();
                    btn_calculate.Visible = true;
                }
                else
                {
                    BLL.ShowMessage(this, "No Employee Available");
                    DataTable DTEMPTY = new DataTable();
                    Rg_EmployeeTaxHra.DataSource = DTEMPTY;
                    Rg_EmployeeTaxHra.DataBind();
                    btn_calculate.Visible = false;
                }


                //TO ADD LIMIT FOR GRID
                _obj_Smhr_Hra = new SMHR_HRA();
                _obj_Smhr_Hra.Mode = 4;
                _obj_Smhr_Hra.SMHR_ORG_ID = Convert.ToInt32(rcm_TaxExemptedelements.SelectedItem.Value);

                DataTable dt_excessamountlimit = BLL.get_Smhr_Hra(_obj_Smhr_Hra);
                if (dt_fianltable.Rows.Count != 0)
                {

                    if (dt_excessamountlimit.Rows.Count != 0)
                    {
                        for (int i = 0; i < Rg_EmployeeTaxHra.Items.Count; i++)
                        {

                            TextBox txtlimit = new TextBox();
                            txtlimit = Rg_EmployeeTaxHra.Items[i].FindControl("TXT_Limit") as TextBox;

                            //addedd by Aravinda
                            RadNumericTextBox txtexcessamount10 = new RadNumericTextBox();
                            txtexcessamount10 = Rg_EmployeeTaxHra.Items[i].FindControl("TXT_EXCESSAMOUNT10") as RadNumericTextBox;
                            RadNumericTextBox txtactualrent = new RadNumericTextBox();
                            txtactualrent = Rg_EmployeeTaxHra.Items[i].FindControl("rnt_TXT_ACTUALRENT") as RadNumericTextBox;
                            if (txtactualrent.Value == 0)
                            {
                                //txtexcessamount10.Value  =Convert.ToDouble( Rg_EmployeeTaxHra.Items[i].FindControl("TXT_EXCESSAMOUNT10") as RadNumericTextBox);
                                txtexcessamount10.Value = 0;
                            }

                            TextBox txtexemptedhra = new TextBox();
                            txtexemptedhra = Rg_EmployeeTaxHra.Items[i].FindControl("TXT_EXCESSAMOUNTL") as TextBox;


                            Label lbl_Excess = new Label();
                            lbl_Excess = Rg_EmployeeTaxHra.Items[i].FindControl("lbl_Excess") as Label;
                            CheckBox CHK_OWNED = new CheckBox();
                            CHK_OWNED = Rg_EmployeeTaxHra.Items[i].FindControl("chk_ownedprop") as CheckBox;
                            CheckBox chkselect = new CheckBox();
                            chkselect = Rg_EmployeeTaxHra.Items[i].FindControl("chk_select") as CheckBox;


                            // CHECKING FOR THE EXISTING DATA FOR THAT EMPLOYEE

                            Label lblempid = new Label();
                            lblempid = Rg_EmployeeTaxHra.Items[i].FindControl("lbl_emp_id") as Label;
                            SMHR_EMP_HRA _obj_smhr_emp_hra = new SMHR_EMP_HRA();
                            _obj_smhr_emp_hra.Mode = 6;
                            _obj_smhr_emp_hra.SMHR_HRA_EMP_ID = Convert.ToInt32(lblempid.Text);
                            _obj_smhr_emp_hra.SMHR_HRA_PERIOD = Convert.ToInt32(ddl_Period.SelectedItem.Value);
                            DataTable dt_exess = BLL.get_Smhr_emp_Hra(_obj_smhr_emp_hra);
                            if (dt_exess.Rows.Count > 0)
                            {
                                if (dt_exess.Rows[0]["SMHR_EMP_SELECT"] != System.DBNull.Value)
                                {
                                    chkselect.Checked = true;
                                }
                                //    //else
                                //    //{
                                //    //    chkselect.Checked = false; 
                                //    //}
                            }
                            if (dt_exess.Rows.Count > 0)
                            {

                                if (Convert.ToBoolean(dt_exess.Rows[0]["SMHR_ISCHECKED"]))
                                {
                                    CHK_OWNED.Checked = true;
                                }

                                txtexcessamount10.Text = dt_exess.Rows[0][0].ToString();
                                txtactualrent.Text = dt_exess.Rows[0]["SMHR_HRA_EMP_ACTUALRENT_PAID"].ToString();
                                txtexemptedhra.Text = dt_exess.Rows[0]["SMHR_HRA_EMP_EXEMPTAMOUNT"].ToString();
                            }

                            else
                            {
                                // txtactualrent.Text = lbl_Excess.Text;
                            }


                            TextBox txthra_ = new TextBox();
                            txthra_ = Rg_EmployeeTaxHra.Items[i].FindControl("TXT_hra") as TextBox;

                            txtlimit.Text = Convert.ToString(dt_excessamountlimit.Rows[0]["SMHR_TAX_MAXLIMIT"]);


                            ////////////if (Convert.ToDouble (lbl_Excess.Text)  >= 0)
                            ////////////{

                            ////////////}
                            ////////////else
                            ////////////{
                            ////////////    //txtexcessamount10.Value = 0;
                            ////////////    lbl_Excess.Text = null; 
                            ////////////}
                            if ((txthra_.Text == null))
                            {
                                txthra_.Text = "0";
                            }

                        }
                    }
                }
                _obj_Smhr_Hra = new SMHR_HRA();
                _obj_Smhr_Hra.Mode = 10;
                _obj_Smhr_Hra.SMHR_ORG_ID = Convert.ToInt32(rcm_bu_type.SelectedItem.Value);

                DataTable dt_metro = BLL.get_Smhr_Hra(_obj_Smhr_Hra);
                if (dt_metro.Rows.Count != 0)
                {
                    //if ((rcm_bu_type.SelectedItem.Text.ToString().Trim().ToUpper() == "Hyderabad") || (rcm_bu_type.SelectedItem.Text.ToString().Trim().ToUpper() == "Mumbai") || (rcm_bu_type.SelectedItem.Text.ToString().Trim().ToUpper() == "Delhi") || (rcm_bu_type.SelectedItem.Text.ToString().Trim().ToUpper() == "Chennai") || (rcm_bu_type.SelectedItem.Text.ToString().Trim().ToUpper() == "kolkata") || (rcm_bu_type.SelectedItem.Text.ToString().Trim().ToUpper() == "Bengaluru") || (rcm_bu_type.SelectedItem.Text.ToString().Trim().ToUpper() == "Ahmedabad") || (rcm_bu_type.SelectedItem.Text.ToString().Trim().ToUpper() == "Pune"))
                    //{
                    //which gives 50% of salary for 
                    if (dt_fianltable.Rows.Count != 0)
                    {
                        for (int a = 0; a < Rg_EmployeeTaxHra.Items.Count; a++)
                        {
                            Label lbl_emp_id = new Label();
                            lbl_emp_id = Rg_EmployeeTaxHra.Items[a].FindControl("LBL_EMP_ID") as Label;
                            TextBox txt40basic = new TextBox();
                            txt40basic = Rg_EmployeeTaxHra.Items[a].FindControl("TXT_40ofbasic") as TextBox;

                            _obj_Smhr_Hra = new SMHR_HRA();
                            _obj_Smhr_Hra.Mode = 8;
                            _obj_Smhr_Hra.SMHR_ORG_ID = Convert.ToInt32(lbl_emp_id.Text);

                            DataTable dt_40basic = BLL.get_Smhr_Hra(_obj_Smhr_Hra);
                            if (dt_40basic.Rows.Count != 0)
                            {
                                txt40basic.Text = Convert.ToString(dt_40basic.Rows[0]["EMP_BASIC"]);

                            }
                        }
                    }
                }

                else
                {
                    if (dt_fianltable.Rows.Count != 0)
                    {
                        for (int a = 0; a < Rg_EmployeeTaxHra.Items.Count; a++)
                        {
                            Label lbl_emp_id = new Label();
                            lbl_emp_id = Rg_EmployeeTaxHra.Items[a].FindControl("LBL_EMP_ID") as Label;
                            TextBox txt40basic = new TextBox();
                            txt40basic = Rg_EmployeeTaxHra.Items[a].FindControl("TXT_40ofbasic") as TextBox;

                            _obj_Smhr_Hra = new SMHR_HRA();
                            _obj_Smhr_Hra.Mode = 9;
                            _obj_Smhr_Hra.SMHR_ORG_ID = Convert.ToInt32(lbl_emp_id.Text);

                            DataTable dt_40basic = BLL.get_Smhr_Hra(_obj_Smhr_Hra);
                            if (dt_40basic.Rows.Count != 0)
                            {
                                txt40basic.Text = Convert.ToString(dt_40basic.Rows[0]["EMP_BASIC"]);

                            }
                        }
                    }
                }


                Rg_EmployeeTaxHra.Visible = true;


                btn_Cancel.Visible = true;

                //     rcm_bu_type.Enabled = false;

                //     ddl_Period.Enabled = false; 

                rcm_TaxExemptedelements.Enabled = false;
                //  ddl_Period.Enabled = false; 
                btn_view.Enabled = false;
            }

            else
            {
                _obj_Smhr_Hra = new SMHR_HRA();
                _obj_Smhr_Hra.Mode = 11;
                _obj_Smhr_Hra.BUID = Convert.ToInt32(rcm_bu_type.SelectedItem.Value);
                _obj_Smhr_Hra.SMHR_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                // _obj_Smhr_Hra.SMHR_PAYITEMID1 = Convert.ToInt32(rcm_Recur_payitem.SelectedItem.Value);
                // _obj_Smhr_Hra.SMHR_HRA_MUL_ID = Convert.ToString(Label1.Text);
                _obj_Smhr_Hra.SMHR_HRA_LASTMDFBY = Convert.ToInt32(rcm_TaxExemptedelements.SelectedItem.Value);
                DataTable dt_fianltable12 = BLL.get_Smhr_Hra(_obj_Smhr_Hra);


                Rg_EmployeeTaxHra.DataSource = dt_fianltable12;
                Rg_EmployeeTaxHra.DataBind();

                for (int b = 0; b < Rg_EmployeeTaxHra.Items.Count; b++)
                {
                    CheckBox CHK_OWNED = new CheckBox();
                    CHK_OWNED = Rg_EmployeeTaxHra.Items[b].FindControl("chk_ownedprop") as CheckBox;

                    CheckBox CHK_SELECT1 = new CheckBox();
                    CHK_SELECT1 = Rg_EmployeeTaxHra.Items[b].FindControl("chk_select") as CheckBox;


                    TextBox txtmetro = new TextBox();//metro city
                    txtmetro = Rg_EmployeeTaxHra.Items[b].FindControl("TXT_40ofbasic") as TextBox;

                    RadNumericTextBox txtactualrententer = new RadNumericTextBox();
                    txtactualrententer = Rg_EmployeeTaxHra.Items[b].FindControl("rnt_TXT_ACTUALRENT") as RadNumericTextBox;

                    Label lbl_Excess = new Label();
                    lbl_Excess = Rg_EmployeeTaxHra.Items[b].FindControl("lbl_Excess") as Label;
                    RadNumericTextBox txtexcessamount10 = new RadNumericTextBox();
                    txtexcessamount10 = Rg_EmployeeTaxHra.Items[b].FindControl("TXT_EXCESSAMOUNT10") as RadNumericTextBox;


                    TextBox txtexceessamt = new TextBox();
                    txtexceessamt = Rg_EmployeeTaxHra.Items[b].FindControl("TXT_EXCESSAMOUNTL") as TextBox;


                    TextBox txtlimitamount = new TextBox();
                    txtlimitamount = Rg_EmployeeTaxHra.Items[b].FindControl("TXT_Limit") as TextBox;

                    if (Convert.ToBoolean(dt_fianltable12.Rows[b]["SMHR_EMP_SELECT"]) == true)
                    {

                        CHK_SELECT1.Checked = true;
                    }

                    else
                    {
                        CHK_SELECT1.Checked = false;

                    }

                    if (Convert.ToBoolean(dt_fianltable12.Rows[b]["SMHR_ISCHECKED"]) == true)
                    {

                        CHK_OWNED.Checked = true;
                    }

                    else
                    {
                        CHK_OWNED.Checked = false;

                    }

                    txtmetro.Text = Convert.ToString(dt_fianltable12.Rows[b]["SMHR_METRO_HRA"]);
                    // Label lblempid = new Label();
                    //lblempid = Rg_EmployeeTaxHra.Items[b].FindControl("LBL_EMP_ID") as Label;
                    //_obj_Smhr_emp_Hra.Mode = 6;
                    //_obj_Smhr_emp_Hra.SMHR_HRA_EMP_ID = Convert.ToInt32(lblempid.Text);
                    //bool status3 = BLL.set_Smhr_EMP_hra(_obj_Smhr_emp_Hra);


                    if (Convert.ToString(dt_fianltable12.Rows[b]["SMHR_HRA_EMP_EXCESSSALARY"]) != "")
                    {

                        if (Convert.ToDouble(dt_fianltable12.Rows[b]["SMHR_HRA_EMP_ACTUALRENT_PAID"]) > 0)
                        {
                            // lbl_Excess.Text = Convert.ToDouble(dt_fianltable12.Rows[b]["SMHR_HRA_EMP_EXCESSSALARY"]).ToString();
                            txtexcessamount10.Value = Convert.ToDouble(dt_fianltable12.Rows[b]["EXCESS10"]);

                            txtactualrententer.Value = Convert.ToDouble(dt_fianltable12.Rows[b]["SMHR_HRA_EMP_ACTUALRENT_PAID"]);
                        }
                        else
                        {
                            txtactualrententer.Value = null;
                        }
                    }

                    //else
                    //{
                    //txtactualrententer.Value = 0;

                    //}
                    txtexceessamt.Text = Convert.ToString(dt_fianltable12.Rows[b]["SMHR_HRA_EMP_EXEMPTAMOUNT"]);
                    txtlimitamount.Text = Convert.ToString(dt_fianltable12.Rows[b]["SMHR_HRA_EMP_TAX_LIMIT"]);
                }
                btn_calculate.Visible = true;
                Rg_EmployeeTaxHra.Visible = true;


                btn_Cancel.Visible = true;

                //rcm_bu_type.Enabled = false;
                //ddl_Period.Enabled = false; 
                //     ddl_Period.Enabled = false; 
                //rcm_Recur_payitem.Enabled = false;
                //rlb_ExcessPayitems.Enabled = false;
                rcm_TaxExemptedelements.Enabled = false;
                btn_view.Enabled = false;

            }


            //}

            //else
            //{
            //    BLL.ShowMessage(this, "Please Select Payitems");
            //    return;

            //}
            _obj_Smhr_Hra = new SMHR_HRA();
            _obj_Smhr_Hra.Mode = 12;

            _obj_Smhr_Hra.SMHR_ORG_ID = Convert.ToInt32(rcm_bu_type.SelectedItem.Value);
            _obj_Smhr_Hra.SMHR_PERIOD_ID = Convert.ToInt32(ddl_Period.SelectedItem.Value);
            _obj_Smhr_Hra.SMHR_HRA_TAXEXEMPTEDELEMENTS = Convert.ToInt32(rcm_TaxExemptedelements.SelectedItem.Value);
            DataTable dt_period = BLL.get_Smhr_Hra(_obj_Smhr_Hra);
            if (dt_period.Rows.Count != 0)
            {
                if (dt_period.Rows[0][0].ToString() != "0")
                {
                    BLL.ShowMessage(this, "Period Already Finalised");
                    ddl_Period.Enabled = false;
                    btn_calculate.Enabled = false;
                    //  rcm_bu_type.Enabled = false;
                    //  rcm_TaxExemptedelements.Enabled = false;
                    btn_view.Enabled = false;
                    btn_Finalise.Visible = false;


                    //        // return;
                }

            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Smhr_HRA", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/frm_UnAuthorized.aspx", false);
        }

    }

    #endregion

    //#region calculate click
    //protected void btn_calculate_Click(object sender, EventArgs e)
    //{



    //    double txtexcessamount1 = 0;
    //    for (int l = 0; l < Rg_EmployeeTaxHra.Items.Count; l++)
    //    {
    //        CheckBox chkvalue = new CheckBox();
    //        chkvalue = Rg_EmployeeTaxHra.Items[l].FindControl("chk_ownedprop") as CheckBox;

    //        TextBox TXT_EXCESSAMOUNTL2 = new TextBox();
    //        TXT_EXCESSAMOUNTL2 = Rg_EmployeeTaxHra.Items[l].FindControl("TXT_EXCESSAMOUNTL") as TextBox;

    //        RadNumericTextBox rnt_TXT_ACTUALRENT = new RadNumericTextBox();
    //        rnt_TXT_ACTUALRENT = Rg_EmployeeTaxHra.Items[l].FindControl("rnt_TXT_ACTUALRENT") as RadNumericTextBox;


    //        TextBox TXT_hra = new TextBox();
    //        TXT_hra = Rg_EmployeeTaxHra.Items[l].FindControl("TXT_hra") as TextBox;


    //        RadNumericTextBox TXT_EXCESSAMOUNT10 = new RadNumericTextBox();
    //        TXT_EXCESSAMOUNT10 = Rg_EmployeeTaxHra.Items[l].FindControl("TXT_EXCESSAMOUNT10") as RadNumericTextBox;


    //        TextBox TXT_Limit = new TextBox();
    //        TXT_Limit = Rg_EmployeeTaxHra.Items[l].FindControl("TXT_Limit") as TextBox;

    //        if (chkvalue.Checked)
    //        {
    //            //chkvalue.Enabled = false;
    //            TXT_EXCESSAMOUNTL2.Text = "0";
    //            //rnt_TXT_ACTUALRENT.Enabled = false;
    //            chkvalue.BackColor = System.Drawing.Color.Red;
    //        }

    //        else
    //        {

    //            if (chkvalue.BackColor == System.Drawing.Color.Red)
    //            {
    //                chkvalue.BackColor = System.Drawing.Color.LightBlue;
    //            }
    //            //chkvalue.Enabled = false;
    //            double hra = Convert.ToDouble(TXT_hra.Text);
    //            double actualrent = 0;
    //            double excessrent10 = 0;
    //            if (rnt_TXT_ACTUALRENT.Text != "")
    //            {
    //                actualrent = Convert.ToDouble(rnt_TXT_ACTUALRENT.Text);
    //            }
    //            if (TXT_EXCESSAMOUNT10.Value >= 0)
    //            {
    //                excessrent10 = Convert.ToDouble(TXT_EXCESSAMOUNT10.Text);
    //            }
    //            if ((hra < actualrent) && (hra < excessrent10))
    //            {
    //                txtexcessamount1 = hra;
    //            }
    //            if ((actualrent < hra) && (actualrent < excessrent10))
    //            {
    //                txtexcessamount1 = actualrent;
    //            }

    //            if ((excessrent10 < hra) && (excessrent10 < actualrent))
    //            {
    //                txtexcessamount1 = excessrent10;

    //            }



    //            double txtlimit = Convert.ToDouble(TXT_Limit.Text);

    //            if (txtexcessamount1 > txtlimit)
    //            {
    //                //rnt_TXT_ACTUALRENT.Enabled = false;
    //                TXT_EXCESSAMOUNTL2.Text = Convert.ToString(txtlimit);
    //                TXT_EXCESSAMOUNTL2.BackColor = System.Drawing.Color.Yellow;

    //            }
    //            else
    //            {
    //                if (TXT_EXCESSAMOUNTL2.BackColor == System.Drawing.Color.Yellow)
    //                {
    //                    TXT_EXCESSAMOUNTL2.BackColor = System.Drawing.Color.LightBlue;
    //                }

    //                TXT_EXCESSAMOUNTL2.Text = Convert.ToString(txtexcessamount1);

    //                //rnt_TXT_ACTUALRENT.Enabled = false;
    //                //TXT_EXCESSAMOUNT10.Enabled = false;
    //            }



    //        }

    //        if ((TXT_EXCESSAMOUNT10.Value >= 0) || (TXT_EXCESSAMOUNT10.Text != null))
    //        {
    //            btn_save.Visible = true;
    //        }
    //        else if (TXT_EXCESSAMOUNT10.Value < 0)
    //        {
    //            btn_save.Visible = false;
    //        }
    //        else
    //        {
    //            btn_save.Visible = false;
    //        }

    //    }


    //    btn_calculate.Visible = true;


    //}

    //#endregion


    #region calculate click
    protected void btn_calculate_Click(object sender, EventArgs e)
    {
        try
        {
            int index1;
            //   bool res1;
            int i = 0;
            CheckBox chk_Box = new CheckBox();
            for (index1 = 0; index1 <= Rg_EmployeeTaxHra.Items.Count - 1; index1++)
            {
                chk_Box = Rg_EmployeeTaxHra.Items[index1].FindControl("chk_select") as CheckBox;
                if (chk_Box.Checked)
                {
                    chk_Box.Enabled = false;
                }
                else
                {
                    i = i + 1;
                }
            }
            if (i == Rg_EmployeeTaxHra.Items.Count)
            {
                BLL.ShowMessage(this, "Please Select atleast one Employee for Calculation");
                return;
            }


            double txtexcessamount1 = 0;
            for (int l = 0; l < Rg_EmployeeTaxHra.Items.Count; l++)
            {
                CheckBox chkvalue = new CheckBox();
                chkvalue = Rg_EmployeeTaxHra.Items[l].FindControl("chk_ownedprop") as CheckBox;

                CheckBox chkselect1 = new CheckBox();
                chkselect1 = Rg_EmployeeTaxHra.Items[l].FindControl("chk_select") as CheckBox;
                if (chkselect1.Checked)
                {

                    TextBox TXT_EXCESSAMOUNTL2 = new TextBox();
                    TXT_EXCESSAMOUNTL2 = Rg_EmployeeTaxHra.Items[l].FindControl("TXT_EXCESSAMOUNTL") as TextBox;

                    RadNumericTextBox rnt_TXT_ACTUALRENT = new RadNumericTextBox();
                    rnt_TXT_ACTUALRENT = Rg_EmployeeTaxHra.Items[l].FindControl("rnt_TXT_ACTUALRENT") as RadNumericTextBox;

                    TextBox TXT_hra = new TextBox();
                    TXT_hra = Rg_EmployeeTaxHra.Items[l].FindControl("TXT_hra") as TextBox;
                    RadNumericTextBox TXT_EXCESSAMOUNT10 = new RadNumericTextBox();
                    TXT_EXCESSAMOUNT10 = Rg_EmployeeTaxHra.Items[l].FindControl("TXT_EXCESSAMOUNT10") as RadNumericTextBox; ;

                    Telerik.Web.UI.RadNumericTextBox rtxt_actualrent_ = sender as Telerik.Web.UI.RadNumericTextBox;

                    Telerik.Web.UI.RadNumericTextBox rtxt_excessamount10rent_ = sender as Telerik.Web.UI.RadNumericTextBox;

                    //TextBox TXT_EXCESSAMOUNT103 = sender as TextBox;
                    GridItem gvRow1 = Rg_EmployeeTaxHra.Items[l] as GridItem;
                    //GridItem gvRow = rtxt_actualrent_.Parent.Parent as GridItem;
                    rtxt_actualrent_ = (RadNumericTextBox)gvRow1.FindControl("rnt_TXT_ACTUALRENT");
                    rtxt_excessamount10rent_ = (RadNumericTextBox)gvRow1.FindControl("TXT_EXCESSAMOUNT10");
                    Label lbl_excessamount10 = (Label)gvRow1.FindControl("lbl_EXCESS");

                    //////if (rtxt_actualrent_.Value > 0)
                    //////{
                    //////    rtxt_actualrent_.Value = ((rtxt_actualrent_.Value) * 12);
                    //////  //  double k = Convert.ToDouble((rtxt_actualrent_.Value) - (Convert.ToDouble(lbl_excessamount10.Text)));
                    //////    double k = Convert.ToDouble((rtxt_actualrent_.Value) - (Convert.ToDouble(rtxt_excessamount10rent_.Value )));
                    //////    if (k > 0)
                    //////    {
                    //////        //rtxt_excessamount10rent_.BackColor = System.Drawing.Color.Aqua;
                    //////        gvRow1.BackColor = System.Drawing.Color.White;
                    //////        //rtxt_excessamount10rent_.Text = Convert.ToString((Convert.ToDouble(rtxt_actualrent_.Text) - Convert.ToDouble(lbl_excessamount10.Text)));
                    //////        //rtxt_excessamount10rent_.Text = Convert.ToString((Convert.ToDouble(rtxt_actualrent_.Text) - Convert.ToDouble(rtxt_excessamount10rent_.Value)));
                    //////        rtxt_excessamount10rent_.Text = Convert.ToString(k);
                    //////        //ViewState["excessamountsession"] = rtxt_excessamount10rent_.Text;
                    //////        //btn_save.Visible = true;
                    //////    }
                    //////    else
                    //////    {
                    //////      //  rtxt_excessamount10rent_.Text = Convert.ToString((Convert.ToDouble(rtxt_actualrent_.Value) - Convert.ToDouble(rtxt_excessamount10rent_.Value )));
                    //////        //rtxt_excessamount10rent_.BackColor = System.Drawing.Color.BlueViolet;
                    //////        rtxt_excessamount10rent_.Text = Convert.ToString(k);
                    //////        gvRow1.BackColor = System.Drawing.Color.Pink;
                    //////        //btn_save.Visible = false;
                    //////        //rtxt_excessamount10rent_.Text = "0";
                    //////    }

                    //////    if (k == null)
                    //////    {
                    //////        //btn_save.Visible = false;
                    //////    }

                    //////}

                    ////////else if (rtxt_actualrent_.Value == 0)
                    ////////{
                    ////////    rtxt_actualrent_.Value = 0;
                    ////////}

                    //else
                    //{
                    //    //rtxt_excessamount10rent_.Text  = Convert.ToString(ViewState["excessamountsession"]);

                    //}

                    //  }
                    //RadNumericTextBox TXT_EXCESSAMOUNT10 = new RadNumericTextBox();
                    //TXT_EXCESSAMOUNT10 = Rg_EmployeeTaxHra.Items[l].FindControl("TXT_EXCESSAMOUNT10") as RadNumericTextBox;

                    TextBox TXT_Limit = new TextBox();
                    TXT_Limit = Rg_EmployeeTaxHra.Items[l].FindControl("TXT_Limit") as TextBox;

                    if (chkvalue.Checked)
                    {
                        //chkvalue.Enabled = false;
                        TXT_EXCESSAMOUNTL2.Text = "0";
                        rnt_TXT_ACTUALRENT.Text = "0";
                        //rnt_TXT_ACTUALRENT.Enabled = false;
                        chkvalue.BackColor = System.Drawing.Color.Red;
                    }

                    else
                    {
                        //if ((TXT_EXCESSAMOUNTL2.Text == string.Empty) && (TXT_EXCESSAMOUNTL2.Text == "0"))
                        //{

                        if (chkvalue.BackColor == System.Drawing.Color.Red)
                        {
                            chkvalue.BackColor = System.Drawing.Color.LightBlue;
                        }
                        //chkvalue.Enabled = false;

                        if (TXT_hra.Text != "")
                        {
                            hra = Convert.ToDouble(TXT_hra.Text);
                        }

                        else
                        {
                            hra = 0;
                        }
                        double actualrent = 0;
                        double excessrent10 = 0;


                        if (TXT_EXCESSAMOUNT10.Value >= 0)
                        {
                            excessrent10 = Convert.ToDouble(TXT_EXCESSAMOUNT10.Text);
                        }
                        if (rnt_TXT_ACTUALRENT.Text != "")
                        {
                            actualrent = Convert.ToDouble(rnt_TXT_ACTUALRENT.Text);

                            if ((hra < actualrent) && (hra < excessrent10))
                            {
                                txtexcessamount1 = hra;
                            }
                            if ((actualrent < hra) && (actualrent < excessrent10))
                            {
                                txtexcessamount1 = actualrent;
                            }

                            if ((excessrent10 < hra) && (excessrent10 < actualrent))
                            {
                                txtexcessamount1 = excessrent10;
                            }
                        }

                        else
                        {
                            txtexcessamount1 = hra;
                        }
                        double txtlimit = Convert.ToDouble(TXT_Limit.Text);

                        if (txtexcessamount1 > txtlimit)
                        {
                            //rnt_TXT_ACTUALRENT.Enabled = false;
                            TXT_EXCESSAMOUNTL2.Text = Convert.ToString(txtlimit);
                            TXT_EXCESSAMOUNTL2.BackColor = System.Drawing.Color.Yellow;

                        }
                        else
                        {
                            if (TXT_EXCESSAMOUNTL2.BackColor == System.Drawing.Color.Yellow)
                            {
                                TXT_EXCESSAMOUNTL2.BackColor = System.Drawing.Color.White;
                            }
                            ///commented by aravinda
                            TXT_EXCESSAMOUNTL2.Text = Convert.ToString(txtexcessamount1);
                            // TXT_EXCESSAMOUNTL2.Text = Convert.ToString(excessrent10);

                            //rnt_TXT_ACTUALRENT.Enabled = false;
                            //TXT_EXCESSAMOUNT10.Enabled = false;
                        }

                    }
                    //if ((rnt_TXT_ACTUALRENT.Text == "0") && (chkvalue.Checked.ToString().ToUpper() == "FALSE"))
                    //{
                    //    continue;
                    //}

                }
                else
                {
                    continue;
                }
            }


            btn_save.Visible = true;
            btn_calculate.Visible = true;
            btn_Finalise.Visible = true;
        }

            //string chk_excessamount10 = string.Empty;
        //chk_excessamount10 = "false";
        //for (int o = 0; o <= Rg_EmployeeTaxHra.Items.Count - 1; o++)
        //{
        //    RadNumericTextBox TXT_EXCESSAMOUNT10 = new RadNumericTextBox();
        //    TXT_EXCESSAMOUNT10 = Rg_EmployeeTaxHra.Items[o].FindControl("TXT_EXCESSAMOUNT10") as RadNumericTextBox;

            //    if (TXT_EXCESSAMOUNT10.Value < 0)
        //    {
        //        btn_save.Visible = false;
        //        chk_excessamount10 = "true";
        //    }
        //    else if (TXT_EXCESSAMOUNT10.Value == null)
        //    {
        //        btn_save.Visible = false;
        //        chk_excessamount10 = "true";
        //    }

            //}
        //if (chk_excessamount10 == "false")
        //{
        //    btn_save.Visible = true;
        //}

        //}

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Smhr_HRA", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

            return;
        }
    }

    #endregion

    //protected void rnt_TXT_ACTUALRENT_textchanged(object sender, EventArgs e)
    //{
    //    Telerik.Web.UI.RadNumericTextBox rtxt_actualrent_ = sender as Telerik.Web.UI.RadNumericTextBox;

    //    Telerik.Web.UI.RadNumericTextBox rtxt_excessamount10rent_ = sender as Telerik.Web.UI.RadNumericTextBox;

    //    //TextBox TXT_EXCESSAMOUNT103 = sender as TextBox;
    //    GridItem gvRow1 = rtxt_excessamount10rent_.Parent.Parent as GridItem;
    //    GridItem gvRow = rtxt_actualrent_.Parent.Parent as GridItem;

    //    rtxt_actualrent_ = (RadNumericTextBox)gvRow.FindControl("rnt_TXT_ACTUALRENT");
    //    rtxt_excessamount10rent_ = (RadNumericTextBox)gvRow1.FindControl("TXT_EXCESSAMOUNT10");
    //    rtxt_excessamount10rent_.BackColor = System.Drawing.Color.White;
    //    rtxt_actualrent_.Value = ((rtxt_actualrent_.Value) * 12);
    //    double k = Convert.ToDouble((rtxt_actualrent_.Value) - (Convert.ToDouble(rtxt_excessamount10rent_.Value)));
    //    if (k >= 0)
    //    {
    //        gvRow1.BackColor = System.Drawing.Color.White;
    //        rtxt_excessamount10rent_.Text = Convert.ToString((rtxt_actualrent_.Value) - (Convert.ToDouble(rtxt_excessamount10rent_.Value)));

    //        btn_save.Visible = true;
    //    }
    //    else
    //    {
    //        rtxt_excessamount10rent_.Text = Convert.ToString((rtxt_actualrent_.Value) - (Convert.ToDouble(rtxt_excessamount10rent_.Value)));
    //        gvRow1.BackColor = System.Drawing.Color.BlueViolet;
    //        btn_save.Visible = false;
    //    }

    //    if (k == null)
    //    {
    //        btn_save.Visible = false;
    //    }
    //}

    protected void chk_ownedprop_checkedchange(object sender, EventArgs e)
    {
        try
        {
            CheckBox chk_ownpro = sender as CheckBox;
            GridItem gvRow1 = chk_ownpro.Parent.Parent as GridItem;
            chk_ownpro = (CheckBox)gvRow1.FindControl("chk_ownedprop");

            if (chk_ownpro.BackColor == System.Drawing.Color.Red)
            {
                chk_ownpro.BackColor = System.Drawing.Color.White;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Smhr_HRA", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

            return;
        }
    }


    protected void rnt_TXT_ACTUALRENT_textchanged(object sender, EventArgs e)
    {
        try
        {

            Telerik.Web.UI.RadNumericTextBox rtxt_actualrent_ = sender as Telerik.Web.UI.RadNumericTextBox;

            Telerik.Web.UI.RadNumericTextBox rtxt_excessamount10rent_ = sender as Telerik.Web.UI.RadNumericTextBox;

            //TextBox TXT_EXCESSAMOUNT103 = sender as TextBox;
            GridItem gvRow1 = rtxt_excessamount10rent_.Parent.Parent as GridItem;
            GridItem gvRow = rtxt_actualrent_.Parent.Parent as GridItem;

            Label lbl_Excess = new Label();
            lbl_Excess = (Label)gvRow.FindControl("lbl_Excess");
            rtxt_actualrent_ = (RadNumericTextBox)gvRow.FindControl("rnt_TXT_ACTUALRENT");
            rtxt_excessamount10rent_ = (RadNumericTextBox)gvRow1.FindControl("TXT_EXCESSAMOUNT10");


            //if (rtxt_exemptamount_.Text != "")
            //{
            //    rtxt_exemptamount_.Value = 0;

            //}

            //else
            //{

            if (rtxt_actualrent_.Value == 0)
            {
                // rtxt_excessamount10rent_.Value =Convert.ToDouble(lbl_Excess.Text)  ;
                rtxt_excessamount10rent_.Value = 0;

            }
            //if (rtxt_excessamount10rent_.Value < 0)
            //{
            //    rtxt_excessamount10rent_.Value = 0;
            //}
            if (rtxt_actualrent_.Value > 0)
            {
                rtxt_actualrent_.Value = ((rtxt_actualrent_.Value) * 12);
                //  double k = Convert.ToDouble((rtxt_actualrent_.Value) - (Convert.ToDouble(rtxt_excessamount10rent_.Value)));
                double k = Convert.ToDouble((rtxt_actualrent_.Value) - (Convert.ToDouble(lbl_Excess.Text)));
                if (k > 0)
                {
                    //rtxt_excessamount10rent_.BackColor = System.Drawing.Color.Aqua;
                    gvRow1.BackColor = System.Drawing.Color.White;
                    // rtxt_excessamount10rent_.Text = Convert.ToString((rtxt_actualrent_.Value) - (Convert.ToDouble(rtxt_excessamount10rent_.Value)));
                    rtxt_excessamount10rent_.Text = Convert.ToString((rtxt_actualrent_.Value) - (Convert.ToDouble(lbl_Excess.Text)));
                    //ViewState["excessamountsession"] = rtxt_excessamount10rent_.Text;
                    //btn_save.Visible = true;
                }
                else
                {
                    // rtxt_excessamount10rent_.Text = Convert.ToString((rtxt_actualrent_.Value) - (Convert.ToDouble(rtxt_excessamount10rent_.Value)));
                    rtxt_excessamount10rent_.Text = Convert.ToString((rtxt_actualrent_.Value) - (Convert.ToDouble(lbl_Excess.Text)));
                    //rtxt_excessamount10rent_.BackColor = System.Drawing.Color.BlueViolet;
                    gvRow1.BackColor = System.Drawing.Color.Pink;
                    //btn_save.Visible = false;
                    //rtxt_excessamount10rent_.Text = "0";
                }

                if (k == null)
                {
                    //btn_save.Visible = false;
                }

            }

            else if (rtxt_actualrent_.Value == 0)
            {
                rtxt_actualrent_.Value = 0;

            }

            else
            {
                //rtxt_excessamount10rent_.Text  = Convert.ToString(ViewState["excessamountsession"]);

            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Smhr_HRA", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

            return;
        }
    }

    #region Save Click
    protected void btn_save_Click(object sender, EventArgs e)
    {
        try
        {
            // bool status = false;


            for (int l = 0; l < Rg_EmployeeTaxHra.Items.Count; l++)
            {
                CheckBox CHK_OWNED = new CheckBox();
                CHK_OWNED = Rg_EmployeeTaxHra.Items[l].FindControl("chk_ownedprop") as CheckBox;


                CheckBox chkselect2 = new CheckBox();
                chkselect2 = Rg_EmployeeTaxHra.Items[l].FindControl("chk_select") as CheckBox;
                if (chkselect2.Checked)
                {
                    Label lblempid = new Label();
                    lblempid = Rg_EmployeeTaxHra.Items[l].FindControl("LBL_EMP_ID") as Label;

                    TextBox TXT_hra3 = new TextBox();
                    TXT_hra3 = Rg_EmployeeTaxHra.Items[l].FindControl("TXT_hra") as TextBox;

                    RadNumericTextBox rnt_TXT_ACTUALRENT = new RadNumericTextBox();
                    rnt_TXT_ACTUALRENT = Rg_EmployeeTaxHra.Items[l].FindControl("rnt_TXT_ACTUALRENT") as RadNumericTextBox;

                    RadNumericTextBox TXT_EXCESSAMOUNT103 = new RadNumericTextBox();
                    TXT_EXCESSAMOUNT103 = Rg_EmployeeTaxHra.Items[l].FindControl("TXT_EXCESSAMOUNT10") as RadNumericTextBox;


                    TextBox TXT_EXCESSAMOUNTL = new TextBox();
                    TXT_EXCESSAMOUNTL = Rg_EmployeeTaxHra.Items[l].FindControl("TXT_EXCESSAMOUNTL") as TextBox;

                    TextBox TXT_Limit = new TextBox();
                    TXT_Limit = Rg_EmployeeTaxHra.Items[l].FindControl("TXT_Limit") as TextBox;

                    TextBox TXT_METRO_HRA = new TextBox();
                    TXT_METRO_HRA = Rg_EmployeeTaxHra.Items[l].FindControl("TXT_40ofbasic") as TextBox;


                    _obj_Smhr_emp_Hra = new SMHR_EMP_HRA();

                    _obj_Smhr_emp_Hra.SMHR_HRA_BU_ID = Convert.ToInt32(rcm_bu_type.SelectedItem.Value);
                    //  _obj_Smhr_emp_Hra.SMHR_HRA_PAYITEM_ID = Convert.ToInt32(rcm_Recur_payitem.SelectedItem.Value);
                    //  _obj_Smhr_emp_Hra.SMHR_HRA_EXCESS_PAYITEM_ID = Convert.ToString(Label1.Text);
                    _obj_Smhr_emp_Hra.SMHR_HRA_TAX_EXEMPT_ID = Convert.ToInt32(rcm_TaxExemptedelements.SelectedItem.Value);
                    if (TXT_hra3.Text != "")
                    {
                        _obj_Smhr_emp_Hra.SMHR_HRA_EMP_HRAVALUE = Convert.ToString(TXT_hra3.Text);
                    }
                    else
                    {
                        _obj_Smhr_emp_Hra.SMHR_HRA_EMP_HRAVALUE = "0";
                    }
                    if (rnt_TXT_ACTUALRENT.Text != "")
                    {
                        _obj_Smhr_emp_Hra.SMHR_HRA_EMP_ACTUALRENT_PAID = Convert.ToString(rnt_TXT_ACTUALRENT.Text);
                    }

                    else
                    {
                        _obj_Smhr_emp_Hra.SMHR_HRA_EMP_ACTUALRENT_PAID = "0";
                    }

                    _obj_Smhr_emp_Hra.SMHR_HRA_EMP_ID = Convert.ToInt32(lblempid.Text);
                    if (Convert.ToDouble(TXT_EXCESSAMOUNT103.Value) >= 0)
                    {
                        _obj_Smhr_emp_Hra.SMHR_HRA_EMP_EXCESSSALARY = Convert.ToString(TXT_EXCESSAMOUNT103.Value);
                        //Label lbl_Excess = new Label();
                        //lbl_Excess = Rg_EmployeeTaxHra.Items[l].FindControl("lbl_Excess") as Label;

                    }
                    else
                    {
                        _obj_Smhr_emp_Hra.SMHR_HRA_EMP_EXCESSSALARY = "0";
                    }


                    if (TXT_Limit.Text != "")
                    {
                        _obj_Smhr_emp_Hra.SMHR_HRA_EMP_TAX_LIMIT = Convert.ToString(TXT_Limit.Text);
                    }
                    else
                    {
                        _obj_Smhr_emp_Hra.SMHR_HRA_EMP_TAX_LIMIT = "0";
                    }

                    if (TXT_EXCESSAMOUNTL.Text != "")
                    {
                        _obj_Smhr_emp_Hra.SMHR_HRA_EMP_EXEMPTAMOUNT = Convert.ToString(TXT_EXCESSAMOUNTL.Text);
                    }
                    else
                    {
                        _obj_Smhr_emp_Hra.SMHR_HRA_EMP_EXEMPTAMOUNT = "0";
                    }

                    if (TXT_METRO_HRA.Text != "")
                    {
                        _obj_Smhr_emp_Hra.SMHR_METRO_HRA = Convert.ToString(TXT_METRO_HRA.Text);
                    }
                    else
                    {
                        _obj_Smhr_emp_Hra.SMHR_METRO_HRA = "0";
                    }

                    _obj_Smhr_emp_Hra.SMHR_ISCHECKED = CHK_OWNED.Checked;
                    _obj_Smhr_emp_Hra.SMHR_ISSELECT = chkselect2.Checked;
                    _obj_Smhr_emp_Hra.SMHR_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Smhr_emp_Hra.SMHR_HRA_CREATEDBY = 1;
                    _obj_Smhr_emp_Hra.SMHR_HRA_CREATEDDATE = DateTime.Now;


                    _obj_Smhr_emp_Hra.Mode = 4;
                    _obj_Smhr_emp_Hra.SMHR_HRA_EMP_ID = Convert.ToInt32(lblempid.Text);

                    DataTable dtempexists = BLL.get_Smhr_emp_Hra(_obj_Smhr_emp_Hra);
                    if (dtempexists.Rows.Count != 0)
                    {
                        _obj_Smhr_emp_Hra.Mode = 5;
                        _obj_Smhr_emp_Hra.SMHR_HRA_EMP_ID = Convert.ToInt32(lblempid.Text);
                        //_obj_Smhr_Hra.SMHR_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);BCZ SOME WHERE HE IS USING THIS AS EMPID AND SOME WHERE BUID
                        bool status4 = BLL.set_Smhr_EMP_hra(_obj_Smhr_emp_Hra);

                        _obj_Smhr_emp_Hra.Mode = 3;
                        _obj_Smhr_emp_Hra.SMHR_HRA_EMP_ID = Convert.ToInt32(lblempid.Text);
                        _obj_Smhr_emp_Hra.SMHR_HRA_PERIOD = Convert.ToInt32(ddl_Period.SelectedItem.Value);
                        _obj_Smhr_emp_Hra.SMHR_HRA_EMP_ISFINALISED = false;
                        _obj_Smhr_emp_Hra.SMHR_ISSELECT = true;
                        //_obj_Smhr_Hra.SMHR_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        bool status5 = BLL.set_Smhr_EMP_hra(_obj_Smhr_emp_Hra);


                        _obj_Smhr_emp_Hra.Mode = 7;
                        _obj_Smhr_emp_Hra.SMHR_HRA_EMP_ID = Convert.ToInt32(lblempid.Text);
                        _obj_Smhr_emp_Hra.SMHR_HRA_TAX_EXEMPT_ID = Convert.ToInt32(rcm_TaxExemptedelements.SelectedItem.Value);
                        _obj_Smhr_emp_Hra.SMHR_HRA_PERIOD = Convert.ToInt32(ddl_Period.SelectedItem.Value);
                        bool dt = BLL.set_Smhr_EMP_hra(_obj_Smhr_emp_Hra);

                    }
                    else
                    {
                        _obj_Smhr_emp_Hra.Mode = 3;
                        _obj_Smhr_emp_Hra.SMHR_HRA_EMP_ID = Convert.ToInt32(lblempid.Text);
                        _obj_Smhr_emp_Hra.SMHR_HRA_PERIOD = Convert.ToInt32(ddl_Period.SelectedItem.Value);
                        _obj_Smhr_emp_Hra.SMHR_HRA_EMP_ISFINALISED = false;
                        _obj_Smhr_emp_Hra.SMHR_ISSELECT = true;
                        bool status3 = BLL.set_Smhr_EMP_hra(_obj_Smhr_emp_Hra);

                        _obj_Smhr_emp_Hra.Mode = 7;
                        _obj_Smhr_emp_Hra.SMHR_HRA_EMP_ID = Convert.ToInt32(lblempid.Text);
                        _obj_Smhr_emp_Hra.SMHR_HRA_TAX_EXEMPT_ID = Convert.ToInt32(rcm_TaxExemptedelements.SelectedItem.Value);
                        _obj_Smhr_emp_Hra.SMHR_HRA_PERIOD = Convert.ToInt32(ddl_Period.SelectedItem.Value);
                        bool dt = BLL.set_Smhr_EMP_hra(_obj_Smhr_emp_Hra);
                    }
                }
                else
                {
                    continue;
                }
            }

            BLL.ShowMessage(this, "Record Saved Successfully");

            LoadCombos();
            clearControls();

            //     rcm_TaxExemptedelements.Enabled = true; 
            tr_prd.Visible = false;
            //    lbl_Period.Visible = false; 
            //    ddl_Period.Visible = false; 
            rcm_bu_type.Enabled = true;
            btn_Cancel.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Smhr_HRA", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

            return;
        }
    }

    #endregion


    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            LoadCombos();
            clearControls();
            rcm_bu_type.Enabled = true;
            btn_Cancel.Visible = false;
            tr_prd.Visible = false;
            btn_calculate.Enabled = true;
            rcm_TaxExemptedelements.Enabled = true;
            ddl_Period.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Smhr_HRA", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

            return;
        }

    }
    protected void ddl_Period_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            // LoadTaxExemptElements();
            // DataTable dt_TE = (DataTable)ViewState["dt_TAXEXEMPT"];
            if (ddl_Period.SelectedIndex > 0)
            {
                _obj_Smhr_Hra = new SMHR_HRA();
                _obj_Smhr_Hra.Mode = 13;
                //if directly financial period getting selected it will through exception
                if (rcm_bu_type.SelectedIndex > 0)
                {
                    _obj_Smhr_Hra.SMHR_ORG_ID = Convert.ToInt32(rcm_bu_type.SelectedItem.Value);
                    _obj_Smhr_Hra.SMHR_PERIOD_ID = Convert.ToInt32(ddl_Period.SelectedItem.Value);
                    //_obj_Smhr_Hra.SMHR_HRA_TAXEXEMPTEDELEMENTS = Convert.ToInt32(rcm_TaxExemptedelements.SelectedItem.Value);
                    DataTable dt_period = BLL.get_Smhr_Hra(_obj_Smhr_Hra);
                    if (dt_period.Rows.Count != 0)
                    {
                        //if (Convert.ToString(dt_period.Rows[0][0]) == "0")
                        //{
                        rcm_TaxExemptedelements.SelectedIndex = rcm_TaxExemptedelements.FindItemIndexByValue(Convert.ToString(dt_period.Rows[0][0]));
                        //  btn_calculate.Enabled = false;
                        rcm_TaxExemptedelements.Enabled = false;
                        //    BLL.ShowMessage(this, "Exemped Tax Element Already Selected");
                        btn_view.Enabled = true;

                        //}
                    }
                }
                else
                {
                    // clearing period and business unit
                    //rcm_bu_type.ClearSelection();
                    ddl_Period.ClearSelection();
                    rcm_TaxExemptedelements.ClearSelection();
                }
            }
            // first selecting the period then after selecting select will through exception
            // for that only if and this else were added
            else
            {
                BLL.ShowMessage(this, "Select Financial Period");
                rcm_TaxExemptedelements.ClearSelection();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Smhr_HRA", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

            return;
        }
    }


    protected void btn_Finalise_Click(object sender, EventArgs e)
    {
        try
        {
            for (int l = 0; l < Rg_EmployeeTaxHra.Items.Count; l++)
            {
                CheckBox CHK_OWNED = new CheckBox();
                CHK_OWNED = Rg_EmployeeTaxHra.Items[l].FindControl("chk_ownedprop") as CheckBox;


                CheckBox chkselect = new CheckBox();
                chkselect = Rg_EmployeeTaxHra.Items[l].FindControl("chk_select") as CheckBox;
                if (chkselect.Checked)
                {
                    Label lblempid = new Label();
                    lblempid = Rg_EmployeeTaxHra.Items[l].FindControl("LBL_EMP_ID") as Label;

                    TextBox TXT_hra3 = new TextBox();
                    TXT_hra3 = Rg_EmployeeTaxHra.Items[l].FindControl("TXT_hra") as TextBox;

                    RadNumericTextBox rnt_TXT_ACTUALRENT = new RadNumericTextBox();
                    rnt_TXT_ACTUALRENT = Rg_EmployeeTaxHra.Items[l].FindControl("rnt_TXT_ACTUALRENT") as RadNumericTextBox;

                    RadNumericTextBox TXT_EXCESSAMOUNT103 = new RadNumericTextBox();
                    TXT_EXCESSAMOUNT103 = Rg_EmployeeTaxHra.Items[l].FindControl("TXT_EXCESSAMOUNT10") as RadNumericTextBox;


                    TextBox TXT_EXCESSAMOUNTL = new TextBox();
                    TXT_EXCESSAMOUNTL = Rg_EmployeeTaxHra.Items[l].FindControl("TXT_EXCESSAMOUNTL") as TextBox;

                    TextBox TXT_Limit = new TextBox();
                    TXT_Limit = Rg_EmployeeTaxHra.Items[l].FindControl("TXT_Limit") as TextBox;

                    TextBox TXT_METRO_HRA = new TextBox();
                    TXT_METRO_HRA = Rg_EmployeeTaxHra.Items[l].FindControl("TXT_40ofbasic") as TextBox;


                    StringBuilder sb = new StringBuilder();
                    //  IList<RadListBoxItem> collection = rlb_ExcessPayitems.CheckedItems;

                    //foreach (RadListBoxItem item in collection)
                    //{
                    //    if (sb.Length == 0)
                    //    {
                    //        sb.Append(item.Value);
                    //    }
                    //    else
                    //    {
                    //        sb.Append("," + item.Value);
                    //    }

                    //}
                    //  Label1.Text = sb.ToString();


                    _obj_Smhr_emp_Hra = new SMHR_EMP_HRA();

                    _obj_Smhr_emp_Hra.SMHR_HRA_BU_ID = Convert.ToInt32(rcm_bu_type.SelectedItem.Value);
                    //  _obj_Smhr_emp_Hra.SMHR_HRA_PAYITEM_ID = Convert.ToInt32(rcm_Recur_payitem.SelectedItem.Value);
                    //  _obj_Smhr_emp_Hra.SMHR_HRA_EXCESS_PAYITEM_ID = Convert.ToString(Label1.Text);
                    _obj_Smhr_emp_Hra.SMHR_HRA_TAX_EXEMPT_ID = Convert.ToInt32(rcm_TaxExemptedelements.SelectedItem.Value);
                    if (TXT_hra3.Text != "")
                    {
                        _obj_Smhr_emp_Hra.SMHR_HRA_EMP_HRAVALUE = Convert.ToString(TXT_hra3.Text);
                    }
                    else
                    {
                        _obj_Smhr_emp_Hra.SMHR_HRA_EMP_HRAVALUE = "0";
                    }
                    if (rnt_TXT_ACTUALRENT.Text != "")
                    {
                        _obj_Smhr_emp_Hra.SMHR_HRA_EMP_ACTUALRENT_PAID = Convert.ToString(rnt_TXT_ACTUALRENT.Text);
                    }

                    else
                    {
                        _obj_Smhr_emp_Hra.SMHR_HRA_EMP_ACTUALRENT_PAID = "0";
                    }

                    _obj_Smhr_emp_Hra.SMHR_HRA_EMP_ID = Convert.ToInt32(lblempid.Text);
                    if (Convert.ToDouble(TXT_EXCESSAMOUNT103.Value) >= 0)
                    {
                        _obj_Smhr_emp_Hra.SMHR_HRA_EMP_EXCESSSALARY = Convert.ToString(TXT_EXCESSAMOUNT103.Value);
                        //Label lbl_Excess = new Label();
                        //lbl_Excess = Rg_EmployeeTaxHra.Items[l].FindControl("lbl_Excess") as Label;
                    }
                    else
                    {
                        _obj_Smhr_emp_Hra.SMHR_HRA_EMP_EXCESSSALARY = "0";
                    }


                    if (TXT_Limit.Text != "")
                    {
                        _obj_Smhr_emp_Hra.SMHR_HRA_EMP_TAX_LIMIT = Convert.ToString(TXT_Limit.Text);
                    }
                    else
                    {
                        _obj_Smhr_emp_Hra.SMHR_HRA_EMP_TAX_LIMIT = "0";
                    }

                    if (TXT_EXCESSAMOUNTL.Text != "")
                    {
                        _obj_Smhr_emp_Hra.SMHR_HRA_EMP_EXEMPTAMOUNT = Convert.ToString(TXT_EXCESSAMOUNTL.Text);
                    }
                    else
                    {
                        _obj_Smhr_emp_Hra.SMHR_HRA_EMP_EXEMPTAMOUNT = "0";
                    }

                    if (TXT_METRO_HRA.Text != "")
                    {
                        _obj_Smhr_emp_Hra.SMHR_METRO_HRA = Convert.ToString(TXT_METRO_HRA.Text);
                    }
                    else
                    {
                        _obj_Smhr_emp_Hra.SMHR_METRO_HRA = "0";
                    }

                    _obj_Smhr_emp_Hra.SMHR_ISCHECKED = CHK_OWNED.Checked;
                    _obj_Smhr_emp_Hra.SMHR_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Smhr_emp_Hra.SMHR_HRA_CREATEDBY = 1;
                    _obj_Smhr_emp_Hra.SMHR_HRA_CREATEDDATE = DateTime.Now;

                    _obj_Smhr_emp_Hra.Mode = 4;
                    _obj_Smhr_emp_Hra.SMHR_HRA_EMP_ID = Convert.ToInt32(lblempid.Text);
                    //switch (((Button)sender).ID.ToUpper())
                    //{

                    //    case "BTN_SAVE":
                    //        _obj_Smhr_emp_Hra.SMHR_HRA_EMP_ISFINALISED = false;
                    //        status = _obj_Smhr_emp_Hra.SMHR_HRA_EMP_ISFINALISED;
                    //        break;

                    //    case "BTN_FINALISE":
                    //        _obj_Smhr_emp_Hra.SMHR_HRA_EMP_ISFINALISED = true;
                    //        status = _obj_Smhr_emp_Hra.SMHR_HRA_EMP_ISFINALISED;
                    //        break;
                    //    default:
                    //        break;
                    //}
                    DataTable dtempexists = BLL.get_Smhr_emp_Hra(_obj_Smhr_emp_Hra);
                    if (dtempexists.Rows.Count != 0)
                    {
                        _obj_Smhr_emp_Hra.Mode = 5;
                        _obj_Smhr_emp_Hra.SMHR_HRA_EMP_ID = Convert.ToInt32(lblempid.Text);
                        //_obj_Smhr_Hra.SMHR_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);BCZ SOME WHERE HE IS USING THIS AS EMPID AND SOME WHERE BUID
                        bool status4 = BLL.set_Smhr_EMP_hra(_obj_Smhr_emp_Hra);

                        _obj_Smhr_emp_Hra.Mode = 3;
                        _obj_Smhr_emp_Hra.SMHR_HRA_EMP_ID = Convert.ToInt32(lblempid.Text);
                        _obj_Smhr_emp_Hra.SMHR_HRA_PERIOD = Convert.ToInt32(ddl_Period.SelectedItem.Value);
                        _obj_Smhr_emp_Hra.SMHR_HRA_EMP_ISFINALISED = true;
                        _obj_Smhr_emp_Hra.SMHR_ISSELECT = true;

                        //_obj_Smhr_Hra.SMHR_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        bool status5 = BLL.set_Smhr_EMP_hra(_obj_Smhr_emp_Hra);
                    }
                    else
                    {
                        _obj_Smhr_emp_Hra.Mode = 3;
                        _obj_Smhr_emp_Hra.SMHR_HRA_EMP_ID = Convert.ToInt32(lblempid.Text);
                        _obj_Smhr_emp_Hra.SMHR_HRA_PERIOD = Convert.ToInt32(ddl_Period.SelectedItem.Value);
                        _obj_Smhr_emp_Hra.SMHR_HRA_EMP_ISFINALISED = true;

                        _obj_Smhr_emp_Hra.SMHR_ISSELECT = true;
                        bool status3 = BLL.set_Smhr_EMP_hra(_obj_Smhr_emp_Hra);
                    }
                }
                else
                {
                    continue;
                }
            }

            BLL.ShowMessage(this, "Records Finalised");

            LoadCombos();
            clearControls();

            btn_view.Enabled = false;
            rcm_bu_type.Enabled = true;
            ddl_Period.Visible = false;
            rcm_TaxExemptedelements.Enabled = false;
            btn_calculate.Enabled = false;

            btn_Cancel.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Smhr_HRA", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

            return;
        }
    }

    protected void chk_selectall_checkedchanged(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < Rg_EmployeeTaxHra.Items.Count; i++)
            {
                CheckBox Chk_All = (CheckBox)sender;
                if (Chk_All.Checked)
                {
                    for (int index = 0; index < Rg_EmployeeTaxHra.Items.Count; index++)
                    {
                        CheckBox c = (CheckBox)Rg_EmployeeTaxHra.Items[index].FindControl("chk_Select");
                        c.Checked = true; ;
                    }
                }
                else
                {
                    for (int index = 0; index < Rg_EmployeeTaxHra.Items.Count; index++)
                    {
                        CheckBox c = (CheckBox)Rg_EmployeeTaxHra.Items[index].FindControl("chk_Select");
                        c.Checked = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Smhr_HRA", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

            return;
        }
    }

}
