using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SMHR;
using Telerik.Web.UI;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Data.OleDb;


public partial class Masters_frm_BusinessUnit : System.Web.UI.Page
{
    string strfilename2;
    string strPath = "";
    DataSet ds = new DataSet();
    protected SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit;
    SMHR_CURRENCY _obj_Curreny;
    SMHR_CATEGORY _obj_Category;
    SMHR_DATEFORMAT _obj_Dateformat;
    SMHR_COUNTRY _obj_Country;
    SMHR_GLOBALCONFIG _obj_smhr_globalConfig;
    SMHR_LOGININFO _obj_LoginInfo;
    SMHR_DIRECTORATE _obj_Smhr_Directorate;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Page.Validate();
        if (RWM_POSTREPLY1.Windows.Count > 0)
        {
            RWM_POSTREPLY1.Windows.RemoveAt(0);
        }

        try
        {
            Page.Validate();
            if (!IsPostBack)
            {

                //chk_Isvariablepay.Visible = false;

                //     metro_id.Visible = false;
                //FOR CHECKING THAT ORGANISATION HAS VARIABLE PAY OR NOT
                //DataTable dt = BLL.get_Organisation_Isvp(Convert.ToString(Session["ORG_ID"]), "");
                //if (dt.Rows.Count > 0)
                //{
                //    if (Convert.ToString(dt.Rows[0]["ORGANISATION_ISVARIABLEAMOUNT"]) == "True")// 1 MEANS THAT ORGANISATION IS HAVING VARIABLE PAY
                //    {
                //        Variablepay.Visible = true;
                //    }
                //}




                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("BUSINESSUNIT");
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
                    Rg_BusinessUnit.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
                //_obj_smhr_globalConfig = new SMHR_GLOBALCONFIG();
                BLL.ChangeDateFormat(Convert.ToString(Session["EMP_ID"]), rdtp_BusinessUnitEndDate, rdtp_BusinessUnitStartDate);
                //_obj_smhr_globalConfig.OPERATION = operation.Select;
                //_obj_smhr_globalConfig.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //DataTable dttemp = BLL.get_ConfigDetails(_obj_smhr_globalConfig);
                //if (dttemp.Rows.Count != 0)
                //{
                //    rmtxt_BusinessUnitAge.MinValue = Convert.ToInt32(dttemp.Rows[0]["GLOBALCONFIG_MINAGE"]);
                //    rmtxt_BusinessUnitAge.MaxValue = Convert.ToInt32(dttemp.Rows[0]["GLOBALCONFIG_MAXAGE"]);

                //    rmtxt_BusinessUnitAgeM.MinValue = Convert.ToInt32(dttemp.Rows[0]["GLOBALCONFIG_MINAGE"]);
                //    rmtxt_BusinessUnitAgeM.MaxValue = Convert.ToInt32(dttemp.Rows[0]["GLOBALCONFIG_MAXAGE"]);
                //}
                PayType.Visible = false;
                BusinessSuffix.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BusinessUnit", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

        // trChkNoOfHours.Visible = false;
        //    trNote.Visible = false;
    }

    //public void loadstatus()
    //{
    //    Rcm_status.Items.Clear();
    //    SMHR_MASTERS _obj_smhr_masters = new SMHR_MASTERS();
    //    _obj_smhr_masters.MASTER_TYPE = "STATUS";
    //    _obj_smhr_masters.OPERATION = operation.Select;
    //    _obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //    DataTable dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);//as it is c data done nothing
    //    Rcm_status.DataSource = dt_Details;
    //    Rcm_status.DataTextField = "HR_MASTER_CODE";
    //    Rcm_status.DataValueField = "HR_MASTER_ID";
    //    Rcm_status.DataBind();
    //    Rcm_status.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
    //}
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            // loadstatus();
            rdtp_BusinessUnitEndDate.MinDate = Convert.ToDateTime("01-01-1900");
            //rdtp_BusinessUnitEndDate.MaxDate = DateTime.Now;
            chkNoOfHours.Enabled = false;
            //rntxt_noofhours.Enabled = false;
            //    metro_id.Visible = false;
            loadDropdown();
            tr_rcmb_BusinessUnitDateFormat.Visible = true;
            tr_rmtxt_BusinessUnitFiscalYear.Visible = false;
            tr_rmtxt_BusinessUnitCalendarYear.Visible = false;
            rcmb_BusinessUnitDateFormat.Enabled = false;
            rcmb_Localisation.Enabled = false;
            rcmb_BusinessUnitCountry.Enabled = false;
            rcmb_BusinessUnitCurrency.Enabled = false;
            //rcmb_BusinessDirectorate.Enabled = false;
            clearControls();
            lbl_Value.Visible = true;
            _obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
            _obj_Smhr_BusinessUnit.OPERATION = operation.Select;
            _obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_BusinessUnit.BUSINESSUNIT_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            DataTable dt = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
            if (dt.Rows.Count > 0)
            {
                if (rcmb_BusinessUnitParent.Items.FindItemByValue(Convert.ToString(dt.Rows[0]["BUSINESSUNIT_ID"])) != null)
                    rcmb_BusinessUnitParent.Items.FindItemByValue(Convert.ToString(dt.Rows[0]["BUSINESSUNIT_ID"])).Visible = false;
                rtxt_BusinessUnitCode.Enabled = false;

                lbl_BusinessUnitID.Text = Convert.ToString(dt.Rows[0]["BUSINESSUNIT_ID"]);
                rtxt_BusinessUnitCode.Text = Convert.ToString(dt.Rows[0]["BUSINESSUNIT_CODE"]);
                rtxt_BusinessUnitDesc.Text = Convert.ToString(dt.Rows[0]["BUSINESSUNIT_DESC"]);
                rad_PensionFactor.Text = Convert.ToString(dt.Rows[0]["BUSINESSUNIT_FACTOR"]);
                // rcmb_BusinessUnitCategory.SelectedIndex = rcmb_BusinessUnitCategory.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["BUSINESSUNIT_CATAGORY_ID"]));
                //rcmb_BusinessUnitCategory_SelectedIndexChanged(null, null);
                rcmb_BusinessUnitParent.SelectedIndex = rcmb_BusinessUnitParent.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["BUSINESSUNIT_PARENT_BUSINESSUNIT_ID"]));
                //rcmb_BusinessUnitCurrency.SelectedIndex = rcmb_BusinessUnitCurrency.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["BUSINESSUNIT_CURRENCY_ID"]));
                rcmb_BusinessUnitDateFormat.SelectedIndex = rcmb_BusinessUnitDateFormat.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["BUSINESSUNIT_DATEFORMAT_ID"]));
                rtxt_BusinessUnitAddress.Text = Convert.ToString(dt.Rows[0]["BUSINESSUNIT_ADDRESS"]);
                chk_BusinessUnitOverTime.Checked = Convert.ToBoolean(dt.Rows[0]["BUSINESSUNIT_OVERTIME"] == DBNull.Value ? false : dt.Rows[0]["BUSINESSUNIT_OVERTIME"]);
                rcmb_BusinessUnitCountry.SelectedIndex = rcmb_BusinessUnitCountry.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["BUSINESSUNIT_COUNTRY_ID"]));
                //rcmb_BusinessDirectorate.SelectedIndex = rcmb_BusinessDirectorate.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["BUSINESSUNIT_DIRECTORATE_ID"]));
                //LoadCurrency();
                rcmb_BusinessUnitCurrency.SelectedIndex = rcmb_BusinessUnitCurrency.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["BUSINESSUNIT_CURRENCY_ID"]));

                //string[] temp = Convert.ToString(dt.Rows[0]["BUSINESSUNIT_AGE"]).Split(new char[] { '-' });
                //if (temp.Length > 1)
                //{
                //    rmtxt_BusinessUnitAge.Text = temp[0];
                //    rmtxt_BusinessUnitAgeM.Text = temp[1];
                //}
                //      rmtxt_BusinessUnitFiscalYear.Text = Convert.ToString(dt.Rows[0]["BUSINESSUNIT_FISCALYEAR"]);
                //   rmtxt_BusinessUnitCalendarYear.Text = Convert.ToString(dt.Rows[0]["BUSINESSUNIT_CALENDERYEAR"]);
                RBI_BU_Image.ImageUrl = Convert.ToString(dt.Rows[0]["BUSINESSUNIT_LOGO"]);
                // RBI_BU_Image.ImageUrl = Convert.ToString(dt.Rows[0]["BUSINESSUNIT_LOGO_FULLPATH"]);

                string Paymentmodes = Convert.ToString(dt.Rows[0]["BUSINESSUNIT_PAYMENTMETHODS"]);//.Split(new char[] { ',' });
                // for (int index = 0; Paymentmodes.Length > index; index++)
                //{
                Label1.Text = Convert.ToString(Paymentmodes);//[index]);
                getCheckedItems(RLB_BusinessUnitPaymentMode, Label1);
                //}

                rtxt_PayType.Text = Convert.ToString(dt.Rows[0]["BUSINESSUNIT_PAYTYPE"]);

                if (dt.Rows[0]["BUSINESSUNIT_SUPERVISOR"] == System.DBNull.Value || Convert.ToInt32(dt.Rows[0]["BUSINESSUNIT_SUPERVISOR"]) == 0)
                {
                    rcmb_BusinessUnitSupervisor.SelectedIndex = 0;
                }
                else
                {
                    rcmb_BusinessUnitSupervisor.SelectedValue = Convert.ToString(dt.Rows[0]["BUSINESSUNIT_SUPERVISOR"]);
                }

                if (dt.Rows[0]["BUSINESSUNIT_STARTDATE"] != DBNull.Value)
                    rdtp_BusinessUnitStartDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["BUSINESSUNIT_STARTDATE"]);
                if (dt.Rows[0]["BUSINESSUNIT_ENDDATE"] != DBNull.Value)
                {
                    rdtp_BusinessUnitEndDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["BUSINESSUNIT_ENDDATE"]);
                    rdtp_BusinessUnitEndDate.Enabled = false;
                    btn_Update.Enabled = false;
                }
                else
                {
                    rdtp_BusinessUnitEndDate.MinDate = DateTime.Now;
                    //rdtp_BusinessUnitEndDate.MaxDate = DateTime.Now;
                    rdtp_BusinessUnitEndDate.Enabled = true;
                    btn_Update.Enabled = true;
                }

                if (dt.Rows[0]["BUSINESSUNIT_EMPCODE"] != DBNull.Value)
                    rtxt_BusinessSuffix.Text = Convert.ToString(dt.Rows[0]["BUSINESSUNIT_EMPCODE"]);
                else
                    rtxt_BusinessSuffix.Text = null;
                if (dt.Rows[0]["BUSINESSUNIT_LOCALISATION"] == System.DBNull.Value || Convert.ToInt32(dt.Rows[0]["BUSINESSUNIT_LOCALISATION"]) == 0)
                {
                    rcmb_Localisation.SelectedIndex = 0;
                }
                else
                {
                    rcmb_Localisation.SelectedValue = Convert.ToString(dt.Rows[0]["BUSINESSUNIT_LOCALISATION"]);
                    if (rcmb_Localisation.SelectedItem.Text.Trim().ToUpper() == "AUSTRALIA")
                    {
                        //tr_ABNNo.Visible = true;
                        //rfv_rtxt_ABNNumber.Enabled = true;
                        //rtxt_ABNNumber.Text = Convert.ToString(dt.Rows[0]["BUSINESSUNIT_ABN_NO"]);
                    }
                    else
                    {
                        //tr_ABNNo.Visible = false;
                        //rfv_rtxt_ABNNumber.Enabled = false;
                        //rtxt_ABNNumber.Text = string.Empty;
                    }
                }
                if (dt.Rows[0]["BUSINESSUNIT_BASICPERCENT"] != DBNull.Value)
                    rntxt_BasicPercent.Text = Convert.ToString(dt.Rows[0]["BUSINESSUNIT_BASICPERCENT"]);
                else
                    rntxt_BasicPercent.Text = "";
                if (dt.Rows[0]["BUSINESSUNIT_NOOFHOURS"] != DBNull.Value)
                {
                    rntxt_noofhours.Text = Convert.ToString(dt.Rows[0]["BUSINESSUNIT_NOOFHOURS"]);
                    if (Convert.ToDouble(dt.Rows[0]["BUSINESSUNIT_NOOFHOURS"]) > 0.00)
                    {
                        //trChkNoOfHours.Visible = true;
                        chkNoOfHours.Checked = true;
                        trNoOfHours.Visible = true;
                    }
                    else
                    {
                        //trChkNoOfHours.Visible = false;
                        chkNoOfHours.Checked = false;
                        trNoOfHours.Visible = false;
                    }
                }
                else
                {
                    //trChkNoOfHours.Visible = false;
                    trNoOfHours.Visible = false;
                    chkNoOfHours.Checked = false;
                    rntxt_noofhours.Text = "";
                }
                //if (dt.Rows[0]["BUSINESSUNIT_NOOFHOURS"] != DBNull.Value)
                //{
                //    if (Convert.ToString(dt.Rows[0]["BUSINESSUNIT_ISVARIABLEAMOUNT"]) == "True")
                //    {
                //        chk_Isvariablepay.Checked = true;
                //    }
                //    else
                //    {
                //        chk_Isvariablepay.Checked = false;
                //    }
                //    DataTable dtcheck = BLL.get_Organisation_Isvp(Convert.ToString(Session["ORG_ID"]), "");
                //    if (Convert.ToString(dtcheck.Rows[0]["ORGANISATION_ISVARIABLEAMOUNT"]) == "True")// 1 MEANS THAT ORGANISATION IS HAVING VARIABLE PAY
                //    {
                //        Variablepay.Visible = true;
                //    }
                //    else
                //    {
                //        Variablepay.Visible = false;
                //    }
                //}
                //else
                //{
                //    chk_Isvariablepay.Checked = false;
                //}
                //checking for metro or not
                //raj
                //if (Convert.ToString(dt.Rows[0]["BUSINESSUNIT_ISMETRO"]) != "")
                //{
                //    if (Convert.ToString(dt.Rows[0]["BUSINESSUNIT_ISMETRO"]).ToUpper() == "TRUE")
                //    {
                //        metro_id.Visible = true;
                //        CB_Ismetro.Checked = true;
                //    }
                //}
                //else
                //{
                //    if (rcmb_Localisation.SelectedItem.Text.Trim().ToUpper() == "INDIA")
                //    {
                //        metro_id.Visible = true;
                //        CB_Ismetro.Checked = false;
                //    }

                //    else
                //    {
                //        metro_id.Visible = false;
                //        CB_Ismetro.Checked = false;
                //    }
                //}..raj
                //if (Convert.ToString(dt.Rows[0]["BUSINESSUNIT_ANNUALPROCESS"]) != "")
                //{
                //    if (Convert.ToString(dt.Rows[0]["BUSINESSUNIT_ANNUALPROCESS"]).ToUpper() == "TRUE")
                //    {
                //        chk_AnnualProcess.Checked = true;
                //    }
                //    else
                //    {
                //        chk_AnnualProcess.Checked = false;
                //    }
                //}

                //code for security
                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    btn_Update.Visible = false;

                }

                else
                {
                    btn_Update.Visible = true;
                }

                if (Convert.ToString(dt.Rows[0]["BUSINESSUNIT_LOGO"]) != string.Empty)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = Convert.ToString(dt.Rows[0]["BUSINESSUNIT_LOGO"]);
                }
                else
                {
                    lblMsg.Visible = false;
                    lblMsg.Text = string.Empty;
                }
            }

            Rm_BU_page.SelectedIndex = 1;
            tr_rmtxt_BusinessUnitFiscalYear.Visible = false;
            tr_rmtxt_BusinessUnitCalendarYear.Visible = false;


            //lnk_BankDetails.OnClientClick = "ShowPopForm('frm_BusinessUnitbanks.aspx?pop=1&ID=" + lbl_BusinessUnitID.Text + "'); return false;";
            //lnk_overtime.OnClientClick = "ShowPopForm('frm_Master.aspx?Control=OT&pop=1'); return false;";
            //lnk_Holiday.OnClientClick = "ShowPopForm('frm_HolidayCalendar.aspx?pop=1&ID=" + lbl_BusinessUnitID.Text + "'); return false;";
            //lnk_payPeriod.OnClientClick = "ShowPopForm('frm_Period.aspx?pop=1'); return false;";
            //lnk_Workinghours.OnClientClick = "ShowPopForm('frm_workinghours.aspx?pop=1&ID=" + lbl_BusinessUnitID.Text + "'); return false;";
            //lnk_Currency.OnClientClick = "ShowPopForm('frm_Currency.aspx?pop=1'); return false;";
            //rtxt_BusinessUnitCode.Focus();
            //lnk_Currency.Visible = false;
            //lnk_Holiday.Visible = false;
            //lnk_overtime.Visible = false;
            //lnk_payPeriod.Visible = false;
            //lnk_Workinghours.Visible = false;
            //lnk_BankDetails.Visible = false;
            //lbl_Header.Visible = false;

            //  ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "setselection();", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BusinessUnit", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            //    metro_id.Visible = false;
            loadDropdown();
            clearControls();
            //loadstatus();
            btn_Save.Visible = true;
            Rm_BU_page.SelectedIndex = 1;
            // pnl_BusinessUnit.Visible = false;
            tr_rmtxt_BusinessUnitFiscalYear.Visible = false;
            tr_rmtxt_BusinessUnitCalendarYear.Visible = false;
            tr_chk_BusinessUnitOverTime.Visible = true;
            rcmb_BusinessUnitDateFormat.Enabled = true;
            tr_rcmb_BusinessUnitDateFormat.Visible = true;
            tr_rcmb_BusinessUnitCountry.Visible = true;
            tr_rtxt_BusinessUnitAddress.Visible = true;
            //tr_rmtxt_BusinessUnitAge.Visible = true;
            tr_rcmb_BusinessUnitCurrency.Visible = true;
            tr_rcmb_BusinessUnitPaymentMode.Visible = true;
            //chk_Isvariablepay.Checked = false;
            //  CB_Ismetro.Checked = false;
            rcmb_Localisation.Enabled = true;
            rcmb_BusinessUnitCountry.Enabled = true;
            rcmb_BusinessUnitCurrency.Enabled = true;
            //rcmb_BusinessDirectorate.Enabled = true;
            //rfv_rcmb_BusinessUnitDateFormat.ValidationGroup = "Controls";
            //rfv_rcmb_BusinessUnitCountry.ValidationGroup = "Controls";
            //rfv_rtxt_BusinessUnitAddress.ValidationGroup = "Controls";
            //rfv_rcmb_BusinessUnitCurrency.ValidationGroup = "Controls";
            //rfv_rcmb_BusinessUnitPaymentMode.ValidationGroup = "Controls";
            //if (rcmb_BusinessUnitCountry.FindItemByText("Kenya") != null)
            //    rcmb_BusinessUnitCountry.FindItemByText("Kenya").Selected = true;
            //if (rcmb_Localisation.FindItemByText("Kenya") != null)
            //    rcmb_Localisation.FindItemByText("Kenya").Selected = true;
            //LoadCurrency();
            // LoadCurrency1();
            Page.Validate();
            rtxt_BusinessUnitCode.Focus();

            rntxt_BasicPercent.Value = 0.00;
            rntxt_noofhours.Value = 0.00;
            trNoOfHours.Visible = false;
            chkNoOfHours.Checked = false;
            rdtp_BusinessUnitEndDate.MinDate = DateTime.Now;
            //rdtp_BusinessUnitEndDate.MaxDate = DateTime.Now;

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BusinessUnit", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void loadDropdown()
    {
        try
        {
            rcmb_BusinessUnitCategory.Items.Clear();
            _obj_Category = new SMHR_CATEGORY();
            _obj_Category.OPERATION = operation.Select;
            _obj_Category.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            rcmb_BusinessUnitCategory.DataSource = BLL.get_Category(_obj_Category);
            rcmb_BusinessUnitCategory.DataTextField = "CATEGORY_CODE";
            rcmb_BusinessUnitCategory.DataValueField = "CATEGORY_ID";
            rcmb_BusinessUnitCategory.DataBind();
            rcmb_BusinessUnitCategory.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            rcmb_BusinessUnitCurrency.Items.Clear();
            _obj_Curreny = new SMHR_CURRENCY();
            _obj_Curreny.OPERATION = operation.Selects;
            _obj_Curreny.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            rcmb_BusinessUnitCurrency.DataSource = BLL.get_Currency(_obj_Curreny);
            rcmb_BusinessUnitCurrency.DataTextField = "CURR_CODE";
            rcmb_BusinessUnitCurrency.DataValueField = "CURR_ID";
            rcmb_BusinessUnitCurrency.DataBind();
            rcmb_BusinessUnitCurrency.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));


            rcmb_BusinessUnitDateFormat.Items.Clear();
            _obj_Dateformat = new SMHR_DATEFORMAT();
            _obj_Dateformat.OPERATION = operation.Select;
            _obj_Dateformat.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            rcmb_BusinessUnitDateFormat.DataSource = BLL.get_DateFormat(_obj_Dateformat);
            rcmb_BusinessUnitDateFormat.DataTextField = "DATEFORMAT_CODE";
            rcmb_BusinessUnitDateFormat.DataValueField = "DATEFORMAT_ID";
            rcmb_BusinessUnitDateFormat.DataBind();
            rcmb_BusinessUnitDateFormat.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));


            _obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
            _obj_Smhr_BusinessUnit.OPERATION = operation.Select;
            _obj_Smhr_BusinessUnit.ISDELETED = true;
            _obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            rcmb_BusinessUnitParent.Items.Clear();
            rcmb_BusinessUnitParent.DataSource = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
            rcmb_BusinessUnitParent.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BusinessUnitParent.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BusinessUnitParent.DataBind();
            rcmb_BusinessUnitParent.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            //Load Directorate
            //_obj_Smhr_Directorate = new SMHR_DIRECTORATE();
            //_obj_Smhr_Directorate.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //DataTable DT = BLL.get_Directorate(_obj_Smhr_Directorate);
            //rcmb_BusinessDirectorate.DataTextField = "DIRECTORATE_CODE";
            //rcmb_BusinessDirectorate.DataValueField = "DIRECTORATE_ID";
            //rcmb_BusinessDirectorate.DataSource = DT;
            //rcmb_BusinessDirectorate.DataBind();
            //rcmb_BusinessDirectorate.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            SMHR_MASTERS _obj_Smhr_Master = new SMHR_MASTERS();
            _obj_Smhr_Master.MASTER_TYPE = "PAYMENTMODE";
            _obj_Smhr_Master.OPERATION = operation.Select;
            // RLB_BusinessUnitPaymentMode.Items.Clear();
            _obj_Smhr_Master.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            RLB_BusinessUnitPaymentMode.DataSource = BLL.get_MasterRecords(_obj_Smhr_Master);
            RLB_BusinessUnitPaymentMode.DataTextField = "HR_MASTER_CODE";
            RLB_BusinessUnitPaymentMode.DataValueField = "HR_MASTER_ID";
            RLB_BusinessUnitPaymentMode.DataBind();

            _obj_Smhr_Master.MASTER_TYPE = "LOCALISATION";
            _obj_Smhr_Master.OPERATION = operation.Select;
            rcmb_Localisation.Items.Clear();
            _obj_Smhr_Master.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            rcmb_Localisation.DataSource = BLL.get_MasterRecords(_obj_Smhr_Master);
            rcmb_Localisation.DataTextField = "HR_MASTER_CODE";
            rcmb_Localisation.DataValueField = "HR_MASTER_ID";
            rcmb_Localisation.DataBind();
            rcmb_Localisation.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));


            rcmb_BusinessUnitCountry.Items.Clear();


            _obj_Country = new SMHR_COUNTRY();
            _obj_Country.OPERATION = operation.Select;
            _obj_Country.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            rcmb_BusinessUnitCountry.DataSource = BLL.get_Country(_obj_Country);
            rcmb_BusinessUnitCountry.DataTextField = "COUNTRY_CODE";
            rcmb_BusinessUnitCountry.DataValueField = "COUNTRY_ID";
            rcmb_BusinessUnitCountry.DataBind();
            rcmb_BusinessUnitCountry.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            rcmb_BusinessUnitSupervisor.Items.Clear();
            SMHR_EMPLOYEE _obj_smhr_employee = new SMHR_EMPLOYEE();
            _obj_smhr_employee.OPERATION = operation.Select;
            _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //_obj_smhr_employee.EMP_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnitSupervisor.SelectedValue);
            rcmb_BusinessUnitSupervisor.DataSource = BLL.get_Employee(_obj_smhr_employee);
            rcmb_BusinessUnitSupervisor.DataTextField = "EMP_NAME";
            rcmb_BusinessUnitSupervisor.DataValueField = "EMP_ID";
            rcmb_BusinessUnitSupervisor.DataBind();
            rcmb_BusinessUnitSupervisor.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BusinessUnit", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }
    //protected void rcmb_BusinessUnitCountry_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    //{
    //    try
    //    {
    //        LoadCurrency();
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BusinessUnit", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}
    //protected void LoadCurrency()
    //{
    //    try
    //    {
    //        //if (rcmb_BusinessUnitCountry.SelectedIndex > 0)
    //        //{
    //        rcmb_BusinessUnitCurrency.Items.Clear();
    //        _obj_Curreny = new SMHR_CURRENCY();
    //        _obj_Curreny.OPERATION = operation.Select1;
    //        _obj_Curreny.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //        //_obj_Curreny.CURR_COUNTRY_ID = Convert.ToInt32(rcmb_BusinessUnitCountry.SelectedItem.Value);
    //        rcmb_BusinessUnitCurrency.DataSource = BLL.get_Currency(_obj_Curreny);
    //        rcmb_BusinessUnitCurrency.DataTextField = "CURR_CODE";
    //        rcmb_BusinessUnitCurrency.DataValueField = "CURR_ID";
    //        rcmb_BusinessUnitCurrency.DataBind();
    //        rcmb_BusinessUnitCurrency.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
    //        // }
    //        //else
    //        //{
    //        //    rcmb_BusinessUnitCurrency.Items.Clear();
    //        //}
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BusinessUnit", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}

    //protected void LoadCurrency1()
    //{
    //    try
    //    {

    //        //rcmb_BusinessUnitCurrency.Items.Clear();
    //        _obj_Curreny = new SMHR_CURRENCY();
    //        _obj_Curreny.OPERATION = operation.Selects;
    //        _obj_Curreny.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

    //        rcmb_BusinessUnitCurrency.DataSource = BLL.get_Currency(_obj_Curreny);
    //        rcmb_BusinessUnitCurrency.DataTextField = "CURR_CODE";
    //        rcmb_BusinessUnitCurrency.DataValueField = "CURR_ID";
    //        rcmb_BusinessUnitCurrency.DataBind();
    //        rcmb_BusinessUnitCurrency.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BusinessUnit", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}
    public void LoadGrid()
    {
        try
        {
            _obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
            _obj_Smhr_BusinessUnit.OPERATION = operation.Select;
            _obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            Rg_BusinessUnit.DataSource = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
            //clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BusinessUnit", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            //if (RLB_BusinessUnitPaymentMode.SelectedIndex < 0)
            //{
            //    BLL.ShowMessage(this, "Select Atleast One Payment Mode");
            //    return;
            //}
            bool selected = false;
            for (int selecteditems = 0; selecteditems < RLB_BusinessUnitPaymentMode.Items.Count; selecteditems++)
            {
                if (RLB_BusinessUnitPaymentMode.Items[selecteditems].Checked)
                    selected = true;
            }
            if (!selected)
            {
                BLL.ShowMessage(this, "Please Select Atleast One Payment Mode");
                return;
            }
            if (rcmb_BusinessUnitCountry.SelectedItem.Text == "Select" || rcmb_BusinessUnitCountry.SelectedIndex == null)
            {
                BLL.ShowMessage(this, "Please Select Country");
                return;
            }
            if (rcmb_BusinessUnitDateFormat.SelectedItem.Text == "Select" || rcmb_BusinessUnitDateFormat.SelectedIndex == null)
            {
                BLL.ShowMessage(this, "Please Select Date Format");
                return;
            }
            _obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
            //Validate();
            _obj_Smhr_BusinessUnit.BUSINESSUNIT_CODE = BLL.ReplaceQuote(rtxt_BusinessUnitCode.Text);
            _obj_Smhr_BusinessUnit.BUSINESSUNIT_DESC = BLL.ReplaceQuote(rtxt_BusinessUnitDesc.Text);
            //  _obj_Smhr_BusinessUnit.BUSINESSUNIT_CATAGORY_ID = Convert.ToInt32(rcmb_BusinessUnitCategory.SelectedItem.Value.ToString());
            _obj_Smhr_BusinessUnit.BUSINESSUNIT_PARENT_BUSINESSUNIT_ID = null;
            _obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_BusinessUnit.OPERATION = operation.Select2;
            _obj_Smhr_BusinessUnit.STARTDATE = rdtp_BusinessUnitStartDate.SelectedDate;
            _obj_Smhr_BusinessUnit.ENDDATE = rdtp_BusinessUnitEndDate.SelectedDate;
            // checking parent business unit start date with creating business unit start date and end date
            //if (rcmb_BusinessUnitParent.SelectedIndex > 0)
            //{
            //    DataTable dt = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
            //    if (dt.Rows[0][0].ToString().ToUpper() == "FALSE")
            //    {
            //        BLL.ShowMessage(this, "Parent Businessunit " + rcmb_BusinessUnitParent.SelectedItem.Text + "Startdate and Enddate is not matching");
            //        return;
            //    }
            //}

            if (rcmb_BusinessUnitSupervisor.SelectedItem.Value == "")
            {
                _obj_Smhr_BusinessUnit.BUSINESSUNIT_SUPERVISOR = 0;
            }
            else
            {
                _obj_Smhr_BusinessUnit.BUSINESSUNIT_SUPERVISOR = Convert.ToInt32(rcmb_BusinessUnitSupervisor.SelectedItem.Value.ToString());
            }
            if (tr_chk_BusinessUnitOverTime.Visible)
                _obj_Smhr_BusinessUnit.BUSINESSUNIT_OVERTIME = chk_BusinessUnitOverTime.Checked;
            else
                _obj_Smhr_BusinessUnit.BUSINESSUNIT_OVERTIME = null;

            if (tr_rcmb_BusinessUnitDateFormat.Visible)
                _obj_Smhr_BusinessUnit.BUSINESSUNIT_DATEFORMAT_ID = Convert.ToInt32(rcmb_BusinessUnitDateFormat.SelectedItem.Value.ToString());
            else
                _obj_Smhr_BusinessUnit.BUSINESSUNIT_DATEFORMAT_ID = null;

            if (tr_rcmb_BusinessUnitCountry.Visible)
                _obj_Smhr_BusinessUnit.BUSINESSUNIT_COUNTRY_ID = Convert.ToInt32(rcmb_BusinessUnitCountry.SelectedItem.Value.ToString());
            else
                _obj_Smhr_BusinessUnit.BUSINESSUNIT_COUNTRY_ID = null;

            //_obj_Smhr_BusinessUnit.BUSINESSUNIT_DIRECTORATE_ID = Convert.ToInt32(rcmb_BusinessDirectorate.SelectedItem.Value.ToString());

            if (tr_rtxt_BusinessUnitAddress.Visible)
                _obj_Smhr_BusinessUnit.BUSINESSUNIT_ADDRESS = BLL.ReplaceQuote(rtxt_BusinessUnitAddress.Text);
            else
                _obj_Smhr_BusinessUnit.BUSINESSUNIT_ADDRESS = null;

            if (tr_rmtxt_BusinessUnitFiscalYear.Visible)
                _obj_Smhr_BusinessUnit.BUSINESSUNIT_FISCALYEAR = BLL.ReplaceQuote(rmtxt_BusinessUnitFiscalYear.Text);
            else
                _obj_Smhr_BusinessUnit.BUSINESSUNIT_FISCALYEAR = null;

            //if (tr_rmtxt_BusinessUnitAge.Visible)
            //    _obj_Smhr_BusinessUnit.BUSINESSUNIT_AGE = BLL.ReplaceQuote(rmtxt_BusinessUnitAge.Text) + "-" + BLL.ReplaceQuote(rmtxt_BusinessUnitAgeM.Text);
            //else
            //    _obj_Smhr_BusinessUnit.BUSINESSUNIT_AGE = null;

            if (tr_rmtxt_BusinessUnitCalendarYear.Visible)
                _obj_Smhr_BusinessUnit.BUSINESSUNIT_CALENDERYEAR = BLL.ReplaceQuote(rmtxt_BusinessUnitCalendarYear.Text);
            else
                _obj_Smhr_BusinessUnit.BUSINESSUNIT_CALENDERYEAR = null;

            if (tr_rcmb_BusinessUnitCurrency.Visible)
                _obj_Smhr_BusinessUnit.BUSINESSUNIT_CURRENCY_ID = Convert.ToInt32(rcmb_BusinessUnitCurrency.SelectedItem.Value.ToString());
            else
                _obj_Smhr_BusinessUnit.BUSINESSUNIT_CURRENCY_ID = null;
            ShowCheckedItems(RLB_BusinessUnitPaymentMode, Label1);
            _obj_Smhr_BusinessUnit.BUSINESSUNIT_PAYMENTMETHODS = Convert.ToString(Label1.Text);
            if (rtxt_BusinessSuffix.Text != "")
                _obj_Smhr_BusinessUnit.BUSINESSUNIT_EMPCODE = BLL.ReplaceQuote(rtxt_BusinessSuffix.Text.ToUpper());
            else
                _obj_Smhr_BusinessUnit.BUSINESSUNIT_EMPCODE = null;

            if (rtxt_PayType.Text != "")
                _obj_Smhr_BusinessUnit.BUSINESSUNIT_PAYTYPE = Convert.ToString(rtxt_PayType.Text);
            else
                _obj_Smhr_BusinessUnit.BUSINESSUNIT_PAYTYPE = null;

            _obj_Smhr_BusinessUnit.BUSINESSUNIT_LOCALISATION1 = Convert.ToInt32(rcmb_Localisation.SelectedValue);
            _obj_Smhr_BusinessUnit.STARTDATE = rdtp_BusinessUnitStartDate.SelectedDate;
            _obj_Smhr_BusinessUnit.ENDDATE = rdtp_BusinessUnitEndDate.SelectedDate;
            //_obj_Smhr_BusinessUnit.BUSINESSUNIT_FACTOR = Convert.ToDouble(rad_PensionFactor.Text);

            _obj_Smhr_BusinessUnit.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);  // ### Need to Get the Session
            _obj_Smhr_BusinessUnit.CREATEDDATE = DateTime.Now;

            _obj_Smhr_BusinessUnit.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);  // ### Need to Get the Session
            _obj_Smhr_BusinessUnit.LASTMDFDATE = DateTime.Now;
            _obj_Smhr_BusinessUnit.BUSINESSUNIT_ISMETRO = false;
            //raj
            //if (metro_id.Visible == true)
            //{
            //    _obj_Smhr_BusinessUnit.BUSINESSUNIT_ISMETRO = CB_Ismetro.Checked;
            //}
            //else
            //{
            //    _obj_Smhr_BusinessUnit.BUSINESSUNIT_ISMETRO = false;
            //} raj
            _obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //if (chk_Isvariablepay.Checked)
            //    _obj_Smhr_BusinessUnit.IS_VARIABLEPAY = true;
            //else
            //    _obj_Smhr_BusinessUnit.IS_VARIABLEPAY = false;
            if (rntxt_BasicPercent.Text == "")
                _obj_Smhr_BusinessUnit.BUSINESSUNIT_BASICPERCENT = 0.00;
            else
                _obj_Smhr_BusinessUnit.BUSINESSUNIT_BASICPERCENT = Convert.ToDouble(rntxt_BasicPercent.Text);
            if (chkNoOfHours.Checked)
            {
                if (Convert.ToDouble(rntxt_noofhours.Text) == 0.00)
                {
                    BLL.ShowMessage(this, "Invalid value for Minimum No. Of Hours.Please assign greater value or uncheck the checkbox.");
                    return;
                }
                _obj_Smhr_BusinessUnit.BUSINESSUNIT_NOOFHOURS = Convert.ToDouble(rntxt_noofhours.Text);
            }
            else
            {
                _obj_Smhr_BusinessUnit.BUSINESSUNIT_NOOFHOURS = 0.00;
            }
            //if (rntxt_noofhours.Text == "")
            //    _obj_Smhr_BusinessUnit.BUSINESSUNIT_NOOFHOURS = 0.00;
            //else
            //    _obj_Smhr_BusinessUnit.BUSINESSUNIT_NOOFHOURS = Convert.ToDouble(rntxt_noofhours.Text);
            //raj
            //if (chk_AnnualProcess.Checked)
            //    _obj_Smhr_BusinessUnit.BUSINESSUNIT_ANNUALPROCESS = true;
            //else

            _obj_Smhr_BusinessUnit.BUSINESSUNIT_ANNUALPROCESS = false;
            _obj_Smhr_BusinessUnit.BUSINESSUNIT_ABN_NO = Convert.ToString(rtxt_ABNNumber.Text);
            //_obj_Smhr_BusinessUnit.BUSINESSUNIT_LOGO = RBI_BU_Image.ImageUrl.ToString();
            _obj_Smhr_BusinessUnit.BUSINESSUNIT_LOGO = Convert.ToString(RBI_BU_Image.ImageUrl);
            _obj_Smhr_BusinessUnit.BUSINESSUNIT_LOGO_FULLPATH = Server.MapPath(Convert.ToString(RBI_BU_Image.ImageUrl));
            //  _obj_Smhr_BusinessUnit.BUSINESSUNIT_STATUS = Convert.ToInt32(Rcm_status.SelectedItem.Value);

            /*
            if (FUpload.HasFile)
            {
                string pdfName = Guid.NewGuid().ToString() + "_" + FUpload.FileName;
                string strPath = "~/BULogo/" + pdfName;
                FUpload.PostedFile.SaveAs(Server.MapPath("~/BULogo/") + pdfName);
                _obj_Smhr_BusinessUnit.BUSINESSUNIT_LOGO_FULLPATH = strPath;
            }
            */



            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_UPDATE":
                    _obj_Smhr_BusinessUnit.BUSINESSUNIT_ID = Convert.ToInt32(lbl_BusinessUnitID.Text);
                    _obj_Smhr_BusinessUnit.OPERATION = operation.Check;
                    //_obj_Smhr_BusinessUnit.OPERATION = operation.Validate;
                    if (Convert.ToString(BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit).Rows[0]["Count"]) != "1")
                    {
                        BLL.ShowMessage(this, "Business unit with this Name Already Exists");
                        return;
                    }
                    if (rdtp_BusinessUnitEndDate.SelectedDate != null)
                    {
                        _obj_Smhr_BusinessUnit.OPERATION = operation.Select3;
                        if (Convert.ToString(BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit).Rows[0]["COUNT"]) != "0")
                        {
                            BLL.ShowMessage(this, "Business unit has Active Employees.First Relieve all Employees and then give End Date.");
                            rdtp_BusinessUnitEndDate.SelectedDate = null;
                            return;
                        }
                    }
                    _obj_Smhr_BusinessUnit.OPERATION = operation.Update;
                    if (BLL.set_BusinessUnit(_obj_Smhr_BusinessUnit))
                    {
                        //_obj_Smhr_BusinessUnit.OPERATION = operation.Insert_New;
                        //BLL.set_BusinessUnit(_obj_Smhr_BusinessUnit);
                        BLL.ShowMessage(this, "Information Updated Successfully");
                        Rm_BU_page.SelectedIndex = 0;
                        LoadGrid();

                        Rg_BusinessUnit.DataBind();
                        return;
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Information Not Saved");
                    }

                    break;
                case "BTN_SAVE":
                    //_obj_Smhr_BusinessUnit.OPERATION = operation.Check;
                    _obj_Smhr_BusinessUnit.OPERATION = operation.Validate;
                    if (Convert.ToString(BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit).Rows[0]["Count"]) != "0")
                    {
                        BLL.ShowMessage(this, "Business Unit with this Name Already Exists");
                        return;
                    }
                    _obj_Smhr_BusinessUnit.OPERATION = operation.Insert;
                    if (BLL.set_BusinessUnit(_obj_Smhr_BusinessUnit))
                    {
                        UpdateAdmins();
                        BLL.ShowMessage(this, "Information Saved Successfully");
                        Rm_BU_page.SelectedIndex = 0;
                        LoadGrid();
                        Rg_BusinessUnit.DataBind();
                        return;


                    }
                    else
                    {
                        BLL.ShowMessage(this, "Information Not Saved");
                        return;
                    }
                default:
                    break;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BusinessUnit", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void UpdateAdmins()
    {
        try
        {
            _obj_LoginInfo = new SMHR_LOGININFO();
            _obj_LoginInfo.OPERATION = operation.Select_admins;
            _obj_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT = BLL.get_adminlogins(_obj_LoginInfo);
            DataTable dt_BU = BLL.get_BU_Admins(_obj_LoginInfo);
            _obj_LoginInfo.OPERATION = operation.Update_Bu;

            for (int k = 0; k < DT.Rows.Count; k++)
            {
                string str = string.Empty;
                str = Convert.ToString(DT.Rows[k]["LOGIN_BUSINESSUNITID"]);
                if (str == string.Empty)
                {
                    str = Convert.ToString(dt_BU.Rows[0]["BUSINESSUNIT_ID"]);
                }
                else
                {
                    str = str + "," + Convert.ToInt32(dt_BU.Rows[0]["BUSINESSUNIT_ID"]);
                }
                _obj_LoginInfo.LOGIN_BUSINESSUNITID = str;
                _obj_LoginInfo.LOGIN_ID = Convert.ToInt32(DT.Rows[k]["LOGIN_ID"]);
                BLL.Upadate_Admins(_obj_LoginInfo);
            }
            if (Convert.ToInt32(Session["EMP_ID"]) > 0)
            {
                _obj_LoginInfo.OPERATION = operation.Login;
                _obj_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                DataTable dt_login = BLL.get_Loginval(_obj_LoginInfo);
                string str = string.Empty;
                str = Convert.ToString(dt_login.Rows[0]["LOGIN_BUSINESSUNITID"]);
                if (str == string.Empty)
                {
                    str = Convert.ToString(dt_BU.Rows[0]["BUSINESSUNIT_ID"]);
                }
                else
                {
                    str = str + "," + Convert.ToInt32(dt_BU.Rows[0]["BUSINESSUNIT_ID"]);
                }

                _obj_LoginInfo.LOGIN_BUSINESSUNITID = str;
                _obj_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                BLL.Upadate_Admins(_obj_LoginInfo);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BusinessUnit", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void clearControls()
    {
        try
        {
            lbl_BusinessUnitID.Text = string.Empty;
            rtxt_BusinessUnitCode.Text = string.Empty;
            rtxt_BusinessUnitDesc.Text = string.Empty;
            rcmb_BusinessUnitCategory.SelectedIndex = -1;
            rcmb_BusinessUnitParent.SelectedIndex = -1;
            rcmb_BusinessUnitCurrency.SelectedIndex = -1;
            rcmb_BusinessUnitDateFormat.SelectedIndex = -1;
            rtxt_BusinessUnitAddress.Text = string.Empty;
            chk_BusinessUnitOverTime.Checked = false;
            rad_PensionFactor.Text = string.Empty;
            //lbl_Value.Text = string.Empty;
            rdtp_BusinessUnitStartDate.Enabled = true;
            rdtp_BusinessUnitEndDate.SelectedDate = null;
            rdtp_BusinessUnitEndDate.Enabled = true;
            rdtp_BusinessUnitStartDate.SelectedDate = null;
            btn_Save.Visible = false;
            btn_Update.Visible = false;
            Rm_BU_page.SelectedIndex = 0;
            //   rmtxt_BusinessUnitCalendarYear.Text = "1  JAN1  JAN";
            //    rmtxt_BusinessUnitFiscalYear.Text = "1  JAN1  JAN";
            //rmtxt_BusinessUnitAge.Text = "18";
            //rmtxt_BusinessUnitAgeM.Text = "55";
            rtxt_BusinessSuffix.Text = string.Empty;
            rtxt_PayType.Text = string.Empty;
            rcmb_BusinessUnitSupervisor.SelectedIndex = -1;
            rtxt_BusinessUnitCode.Enabled = true;
            tr_chk_BusinessUnitOverTime.Visible = false;
            //  tr_rcmb_BusinessUnitDateFormat.Visible = false;
            //   tr_rcmb_BusinessUnitCountry.Visible = false;
            //    tr_rtxt_BusinessUnitAddress.Visible = false;
            //   tr_rmtxt_BusinessUnitAge.Visible = false;
            //   tr_rcmb_BusinessUnitCurrency.Visible = false;
            //   tr_rcmb_BusinessUnitPaymentMode.Visible = false;

            rfv_rcmb_BusinessUnitDateFormat.ValidationGroup = "test";
            rfv_rcmb_BusinessUnitCountry.ValidationGroup = "test";
            //     rfv_rtxt_BusinessUnitAddress.ValidationGroup = "test";
            //    rfv_rcmb_BusinessUnitCurrency.ValidationGroup = "test";
            //rfv_rcmb_BusinessUnitPaymentMode.ValidationGroup = "test";

            rntxt_BasicPercent.Text = "";
            rntxt_noofhours.Text = "";

            //    tr_ABNNo.Visible = false;
            // rfv_rtxt_ABNNumber.Enabled = false;
            // rtxt_ABNNumber.Text = string.Empty;

            lblMsg.Visible = false;
            lblMsg.Text = string.Empty;
            RBI_BU_Image.ImageUrl = "";
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BusinessUnit", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearControls();
            LoadGrid();
            Rg_BusinessUnit.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BusinessUnit", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Rg_BusinessUnit_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BusinessUnit", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_BusinessUnitCategory_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            SMHR_CATEGORY _obj_Smhr_Category = new SMHR_CATEGORY();
            _obj_Smhr_Category.OPERATION = operation.Select;
            _obj_Smhr_Category.CATEGORY_ID = Convert.ToInt32(rcmb_BusinessUnitCategory.SelectedItem.Value.ToString());
            _obj_Smhr_Category.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            DataTable dt = BLL.get_Category(_obj_Smhr_Category);

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                switch (dt.Columns[i].ColumnName.ToUpper())
                {
                    case "CATEGORY_ISOVERTIME":
                        tr_chk_BusinessUnitOverTime.Visible = Convert.ToBoolean(dt.Rows[0]["CATEGORY_ISOVERTIME"].ToString());
                        //lnk_overtime.Visible = Convert.ToBoolean(dt.Rows[0]["CATEGORY_ISOVERTIME"].ToString());
                        break;
                    case "CATEGORY_ISDATEFORMAT":
                        tr_rcmb_BusinessUnitDateFormat.Visible = Convert.ToBoolean(dt.Rows[0]["CATEGORY_ISDATEFORMAT"].ToString());
                        rfv_rcmb_BusinessUnitDateFormat.ValidationGroup = Convert.ToBoolean(dt.Rows[0]["CATEGORY_ISDATEFORMAT"].ToString()) == true ? "Controls" : "test";
                        break;
                    case "CATEGORY_ISCOUNTRY":
                        tr_rcmb_BusinessUnitCountry.Visible = Convert.ToBoolean(dt.Rows[0]["CATEGORY_ISCOUNTRY"].ToString());
                        rfv_rcmb_BusinessUnitCountry.ValidationGroup = Convert.ToBoolean(dt.Rows[0]["CATEGORY_ISOVERTIME"].ToString()) == true ? "Controls" : "test";
                        break;
                    case "CATEGORY_ISADDRESS":
                        tr_rtxt_BusinessUnitAddress.Visible = Convert.ToBoolean(dt.Rows[0]["CATEGORY_ISADDRESS"].ToString());
                        //    rfv_rtxt_BusinessUnitAddress.ValidationGroup = Convert.ToBoolean(dt.Rows[0]["CATEGORY_ISADDRESS"].ToString()) == true ? "Controls" : "test";
                        break;
                    case "CATEGORY_ISFISCALYEAR":
                        tr_rmtxt_BusinessUnitFiscalYear.Visible = Convert.ToBoolean(dt.Rows[0]["CATEGORY_ISFISCALYEAR"].ToString()); ;
                        break;
                    //case "CATEGORY_ISAGE":
                    //    tr_rmtxt_BusinessUnitAge.Visible = Convert.ToBoolean(dt.Rows[0]["CATEGORY_ISAGE"].ToString());
                    //    break;
                    case "CATEGORY_ISCALENDERYEAR":
                        tr_rmtxt_BusinessUnitCalendarYear.Visible = Convert.ToBoolean(dt.Rows[0]["CATEGORY_ISCALENDERYEAR"].ToString()); ;
                        //lnk_payPeriod.Visible = Convert.ToBoolean(dt.Rows[0]["CATEGORY_ISCALENDERYEAR"].ToString());
                        break;
                    case "CATEGORY_ISCURRENCY":
                        tr_rcmb_BusinessUnitCurrency.Visible = Convert.ToBoolean(dt.Rows[0]["CATEGORY_ISCURRENCY"].ToString());
                        rfv_rcmb_BusinessUnitCurrency.ValidationGroup = Convert.ToBoolean(dt.Rows[0]["CATEGORY_ISCURRENCY"].ToString()) == true ? "Controls" : "test";
                        //lnk_Currency.Visible = Convert.ToBoolean(dt.Rows[0]["CATEGORY_ISCURRENCY"].ToString());
                        break;
                    case "CATEGORY_ISPAYMENTMODE":
                        tr_rcmb_BusinessUnitPaymentMode.Visible = Convert.ToBoolean(dt.Rows[0]["CATEGORY_ISPAYMENTMODE"].ToString());
                        //rfv_rcmb_BusinessUnitPaymentMode.ValidationGroup = Convert.ToBoolean(dt.Rows[0]["CATEGORY_ISPAYMENTMODE"].ToString()) == true ? "Controls" : "test";
                        break;
                    case "CATEGORY_NEEDBANKINFO":
                        //lnk_BankDetails.Visible = Convert.ToBoolean(dt.Rows[0]["CATEGORY_NEEDBANKINFO"].ToString());
                        break;
                    case "CATEGORY_LOCALISATION":
                        //lnk_BankDetails.Visible = Convert.ToBoolean(dt.Rows[0]["CATEGORY_NEEDBANKINFO"].ToString());
                        tr_rmtxt_BusinessUnitLocalisation.Visible = Convert.ToBoolean(dt.Rows[0]["CATEGORY_LOCALISATION"].ToString());
                        break;
                    default:
                        break;
                }
            }

            rcmb_BusinessUnitCategory.Focus();
            lbl_Value.Visible = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BusinessUnit", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rwm_BusinessUnit_Disposed(object sender, EventArgs e)
    {
        try
        {
            Session["WINDOW_VALUE"] = null;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BusinessUnit", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private static void ShowCheckedItems(RadListBox listBox, Label label)
    {

        try
        {
            StringBuilder sb = new StringBuilder();
            IList<RadListBoxItem> collection = listBox.CheckedItems;
            foreach (RadListBoxItem item in collection)
            {
                if (sb.Length == 0)
                {
                    sb.Append(item.Value);
                }
                else
                {
                    sb.Append("," + item.Value);
                }
            }

            label.Text = sb.ToString();
        }
        catch (Exception ex)
        {

            SMHR.BLL.Error_Log(HttpContext.Current.Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BusinessUnit", ex.StackTrace, DateTime.Now);
            HttpContext.Current.Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    private static void getCheckedItems(RadListBox listBox, Label label)
    {
        try
        {
            string strVal = label.Text;
            int i = 0;
            Array Ar = strVal.Split(new Char[] { ',' });
            for (i = 0; i < Ar.Length; i++)
            {
                //listBox.SelectedIndex = listBox.FindItemIndexByValue(Convert.ToString(Ar.GetValue(i)).Trim());
                listBox.SelectedValue = Convert.ToString(Ar.GetValue(i));

                for (int j = 0; j < listBox.Items.Count; j++)
                {
                    if (Convert.ToString(listBox.Items[j].Value) == Convert.ToString(Ar.GetValue(i)))
                        listBox.Items[j].Checked = true;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(HttpContext.Current.Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BusinessUnit", ex.StackTrace, DateTime.Now);
            HttpContext.Current.Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_Localisation_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        //if (rcmb_Localisation.SelectedIndex > 0)
        //{
        //    if (rcmb_Localisation.SelectedItem.Text.Trim().ToUpper() == "INDIA")
        //    {
        //       // metro_id.Visible = true;
        //      //  tr_ABNNo.Visible = false;
        //       // rfv_rtxt_ABNNumber.Enabled = false;
        //    }
        //    else
        //    {
        //      //  metro_id.Visible = false;
        //        if ((rcmb_Localisation.SelectedItem.Text.Trim().ToUpper() == "AUSTRALIA") || (rcmb_Localisation.SelectedItem.Text.Trim().ToUpper() == "PNG"))
        //        {
        //            //trChkNoOfHours.Visible = true;
        //         //   trNote.Visible = true;
        //       //     tr_ABNNo.Visible = false;
        //           // rfv_rtxt_ABNNumber.Enabled = false;
        //        }
        //        if (rcmb_Localisation.SelectedItem.Text.Trim().ToUpper() == "AUSTRALIA")
        //        {
        //         //   tr_ABNNo.Visible = true;
        //         //   rfv_rtxt_ABNNumber.Enabled = true;
        //        }
        //    }
        //}
        //else
        //{
        // //   tr_ABNNo.Visible = false;
        //  //  rfv_rtxt_ABNNumber.Enabled = false;
        //   // metro_id.Visible = false;
        //    //trChkNoOfHours.Visible = false;
        // //   trNote.Visible = false;
        //}


    }
    protected void Delete_Excel_File()
    {
        try
        {
            ds.Dispose();
            if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == true)
            {
                // FileUpload_Task.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Corporate_Contract_Docs/") + Convert.ToString(rcmb_taskPorjectname.SelectedItem.Text.Replace("/", "_")), filename));

                string strpath = Server.MapPath("~/IMPORT_EXCEL/");


                DirectoryInfo dirinfo = new DirectoryInfo(strpath);
                strpath = strpath + strfilename2;
                FileInfo fi = new FileInfo(strpath);
                {
                    fi.Delete();
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BusinessUnit", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    public static bool CheckStringValue(string str)
    {
        //
        // Convert true if number  or false if not
        //
        int Num;
        if (int.TryParse(str, out Num) == true)
        {
            if (Num > 2359)
            {
                return false;
            }
            if (str.Length != 4)
            {
                return false;

            }
            if (str.Length == 4)
            {
                string minute = str.Substring(2, 2);
                int minuteInt = int.Parse(minute);
                if (minuteInt >= 60)
                {
                    return false;
                }
            }

        }
        else
        {
            return false;
        }
        return true;
    }
    //*********************************

    public static bool CheckDateFormat(string strin)
    {
        try
        {
            if (strin.Length > 10)
            {
                return false;
            }
            char[] c = null;
            string strFinal = string.Empty;
            Array ar = strin.Split(new char[] { '/' });
            string yeararray = Convert.ToString(ar.GetValue(2));
            if (yeararray.Length > 4)
            {
                return false;
            }
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar.GetValue(i).ToString().Length == 1)
                {
                    strFinal = strFinal + "0" + ar.GetValue(i) + "/";
                }
                else if (ar.GetValue(i).ToString().Length == 2)
                {
                    strFinal = strFinal + ar.GetValue(i) + "/";
                }
                else
                {
                    if (strFinal.Length == 6)
                        strFinal = strFinal + ar.GetValue(i).ToString();
                    else
                        strFinal = strFinal + "/" + ar.GetValue(i).ToString();
                }
            }
            c = strFinal.ToCharArray();
            if ((c[2] != '/') || c[5] != '/')
            {
                return false;
            }

            if (Convert.ToInt32(strFinal.Substring(0, 2).Trim()) > 31)
            {
                return false;
            }
            if (Convert.ToInt32(strFinal.Substring(3, 2).Trim()) > 12)
            {
                return false;
            }

            if (Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 2)
            {
                if (Convert.ToInt32(strFinal.Substring(6, 4).Trim()) / 4 == 0)
                { // check leap year

                    if (Convert.ToInt32(strFinal.Substring(0, 2).Trim()) > 29)
                    {
                        return false;
                    }

                }
                else
                {
                    if (Convert.ToInt32(strFinal.Substring(0, 2).Trim()) > 28)
                    {
                        return false;
                    }
                }

            }
            if (Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 1 || Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 3 || Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 5 || Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 7 || Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 8 || Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 10 || Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 12)
            {
                if (Convert.ToInt32(strFinal.Substring(0, 2).Trim()) > 31)
                {
                    return false;
                }
            }
            if (Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 4 || Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 6 || Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 9 || Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 11)
            {
                if (Convert.ToInt32(strFinal.Substring(0, 2).Trim()) > 30)
                {
                    return false;
                }
            }



            return true;
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
    }
    //*************************

    //protected void Btn_Imp_Businessunit_click(object sender, EventArgs e)
    //{
    //    try
    //    {

    //        //written by Rajasekhar
    //        //To Import BusinessUnit Excel Sheet

    //        string strcon = null;

    //        string strfilename1 = FileUpload1.FileName;
    //        strfilename2 = Convert.ToString(DateTime.Now.TimeOfDay) + "_" + strfilename1;
    //        strfilename2 = strfilename2.Replace("/", "").Replace(":", ".");
    //        if (FileUpload1.HasFile)
    //        {

    //            if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == false)
    //            {
    //                System.IO.Directory.CreateDirectory(Server.MapPath("~/IMPORT_EXCEL/"));

    //            }



    //            FileUpload1.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/IMPORT_EXCEL/"), strfilename2));
    //            string filename1 = Server.MapPath("~/IMPORT_EXCEL/") + ("") + (Convert.ToString(strfilename2));
    //            FileInfo fileInfo = new FileInfo(filename1);
    //            if (fileInfo.Exists)
    //            {
    //                string path = MapPath(strfilename1);
    //                // string name = Path.GetFileName( path );
    //                string ext = Path.GetExtension(path);

    //                string type = string.Empty;
    //                //  set known types based on file extension  
    //                if (ext != null)
    //                {
    //                    switch (ext.ToLower())
    //                    {

    //                        case ".xls":

    //                            type = "excel";
    //                            break;
    //                        case ".xlsx":
    //                            type = "excel";
    //                            break;

    //                        default:
    //                            type = string.Empty;
    //                            break;
    //                    }
    //                }
    //                if (type == string.Empty)
    //                {
    //                    if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == true)
    //                    {

    //                        string path1 = Server.MapPath("~/IMPORT_EXCEL/") + ("") + (Convert.ToString(strfilename2));
    //                        System.IO.File.Delete(path1);
    //                    }
    //                    BLL.ShowMessage(this, "Please select the Excel File  (Eg: Excel.xlsx). ");
    //                    return;
    //                }
    //            }
    //        }


    //        else
    //        {
    //            BLL.ShowMessage(this, "Please Select the File to be uploaded");
    //            return;
    //        }

    //        string strpath = Server.MapPath("~/IMPORT_EXCEL/");

    //        strpath = strpath + strfilename2;


    //        // Getting data from excell file to dataset.
    //        strcon = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source='" + strpath + "';" + "Extended Properties=Excel 12.0;";


    //        OleDbConnection objConn = null;
    //        objConn = new OleDbConnection(strcon);
    //        objConn.Open();

    //        DataTable dt_chk2 = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
    //        string sheetname;
    //        if (dt_chk2 == null)
    //        {
    //            objConn.Close();
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        else
    //        {
    //            sheetname = Convert.ToString(dt_chk2.Rows[0]["TABLE_NAME"]);
    //        }
    //        OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM  [" + sheetname + "]", strcon);



    //        da.Fill(ds);
    //        ds.Tables[0].Columns.Add("Error Message");

    //        objConn.Close();
    //        DataTable dt = new DataTable();
    //        DataTable dtfail = new DataTable();


    //        string errormsg = string.Empty;


    //        Int32 rowno = 0;


    //        string columnno = null;

    //        Boolean filestatus = true;
    //        dtfail.Columns.Add("S.NO", typeof(Int32));
    //        dtfail.Columns.Add("ROWNO", typeof(Int32));
    //        dtfail.Columns.Add("COLUMNS NAMES", typeof(string));
    //        if (ds.Tables[0].Columns[0].ToString().Trim() == "Name*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds.Tables[0].Columns[1].ToString().Trim() == "Description")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds.Tables[0].Columns[2].ToString().Trim() == "Category*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        } if (ds.Tables[0].Columns[3].ToString().Trim() == "Parent Business Unit")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        } if (ds.Tables[0].Columns[4].ToString().Trim() == "Country*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds.Tables[0].Columns[5].ToString().Trim() == "Currency*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds.Tables[0].Columns[6].ToString().Trim() == "Date Format*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds.Tables[0].Columns[7].ToString().Trim() == "Address*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds.Tables[0].Columns[8].ToString().Trim() == "Min Age")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds.Tables[0].Columns[9].ToString().Trim() == "Max Age")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds.Tables[0].Columns[10].ToString().Trim() == "Localisation")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds.Tables[0].Columns[11].ToString().Trim() == "OverTime")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds.Tables[0].Columns[12].ToString().Trim() == "Payment Modes")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds.Tables[0].Columns[13].ToString().Trim() == "Start Date*(dd/mm/yyyy)")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds.Tables[0].Columns[14].ToString().Trim() == "End Date(dd/mm/yyyy)")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds.Tables[0].Columns[15].ToString().Trim() == "Supervisor")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds.Tables[0].Columns[16].ToString().Trim() == "Is Metro")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }

    //        if (ds.Tables[0].Columns[17].ToString().Trim() == "Is VariablePay")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }

    //        if (ds.Tables[0].Columns[18].ToString().Trim() == "Basic Percent")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }


    //        if (ds.Tables[0].Rows.Count == 0)
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Successfully processed Excel file. No Records are Imported.");
    //            return;
    //        }


    //        //to check the data in excel
    //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //        {
    //            string startdate = string.Empty;
    //            string enddate = string.Empty;
    //            DateTime sdate;
    //            DateTime edate;

    //            if (ds.Tables[0].Rows[i]["Name*"].ToString().Trim() != "")
    //            {
    //                _obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
    //                _obj_Smhr_BusinessUnit.BUSINESSUNIT_CODE = ds.Tables[0].Rows[i]["Name*"].ToString().Trim();
    //                _obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                _obj_Smhr_BusinessUnit.OPERATION = operation.Validate;
    //                if (Convert.ToString(BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit).Rows[0]["Count"]) != "0")
    //                {
    //                    errormsg = "Business unit with this code Already Exists";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = "Name*";

    //                }

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = "Name*";

    //            }
    //            for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
    //            {
    //                if (ds.Tables[0].Rows[i]["Name*"].ToString().Trim() == ds.Tables[0].Rows[k]["Name*"].ToString().Trim())
    //                {
    //                    if (i != k)
    //                    {
    //                        errormsg = errormsg + "," + "Business unit with this Name is repeated in Excel Sheet";
    //                        filestatus = false;
    //                        rowno = i + 2;
    //                        columnno = "Name*";
    //                    }
    //                }
    //            }

    //            if (ds.Tables[0].Rows[i]["Description"].ToString().Trim() != "")
    //            {

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Description";

    //            }
    //            if (ds.Tables[0].Rows[i]["Category*"].ToString().Trim() != "")
    //            {
    //                SMHR_CATEGORY _obj_Smhr_Category = new SMHR_CATEGORY();
    //                _obj_Smhr_Category.CATEGORY_CODE = ds.Tables[0].Rows[i]["Category*"].ToString().Trim();
    //                _obj_Smhr_Category.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                _obj_Smhr_Category.OPERATION = operation.Check;
    //                DataTable dt_categoty = BLL.get_Category(_obj_Smhr_Category);
    //                if (Convert.ToInt32(dt_categoty.Rows[0]["COUNT"]) == 0)
    //                {
    //                    errormsg = errormsg + "," + "Category with this Name Does not Exists";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = columnno + "," + "Category*";
    //                }
    //                else
    //                {


    //                }


    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Category*";

    //            }
    //            if (ds.Tables[0].Rows[i]["Parent Business Unit"].ToString().Trim() != "")
    //            {
    //                SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
    //                _obj_Smhr_BusinessUnit.BUSINESSUNIT_CODE = ds.Tables[0].Rows[i]["Parent Business Unit"].ToString().Trim();
    //                _obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                _obj_Smhr_BusinessUnit.OPERATION = operation.Validate;
    //                DataTable dt_businessunit = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
    //                if (Convert.ToInt32(dt_businessunit.Rows[0]["COUNT"]) == 0)
    //                {
    //                    errormsg = errormsg + "," + "Busines Unit with this Name Does not Exists";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = columnno + "," + "Parent Business Unit";
    //                }
    //                else
    //                {

    //                }


    //            }
    //            else
    //            {
    //                //filestatus = false;
    //                //rowno = i + 2;
    //                //columnno = columnno + "," + "Parent Business Unit";

    //            }
    //            if (ds.Tables[0].Rows[i]["Country*"].ToString().Trim() != "")
    //            {
    //                SMHR_COUNTRY _obj_Smhr_Country = new SMHR_COUNTRY();
    //                _obj_Smhr_Country.COUNTRY_CODE = ds.Tables[0].Rows[i]["Country*"].ToString().Trim();
    //                _obj_Smhr_Country.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                _obj_Smhr_Country.OPERATION = operation.Check;
    //                DataTable dt_country = BLL.get_Country(_obj_Smhr_Country);
    //                if (Convert.ToInt32(dt_country.Rows[0]["COUNT"]) == 0)
    //                {
    //                    errormsg = errormsg + "," + "Country with this Name Does not Exists";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = columnno + "," + "Country*";
    //                }

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Country*";

    //            }

    //            if (ds.Tables[0].Rows[i]["Currency*"].ToString().Trim() != "")
    //            {
    //                SMHR_CURRENCY _obj_Smhr_Currency = new SMHR_CURRENCY();
    //                _obj_Smhr_Currency.CURR_CODE = ds.Tables[0].Rows[i]["Currency*"].ToString().Trim().ToUpper();
    //                _obj_Smhr_Currency.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                _obj_Smhr_Currency.OPERATION = operation.Check;
    //                DataTable dt_currency = BLL.get_Currency(_obj_Smhr_Currency);
    //                if (Convert.ToInt32(dt_currency.Rows[0]["COUNT"]) == 0)
    //                {
    //                    errormsg = errormsg + "," + "currency with this Name Does not Exists";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = columnno + "," + "Currency*";
    //                }



    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Currency*";

    //            }
    //            if (ds.Tables[0].Rows[i]["Date Format*"].ToString().Trim() != "")
    //            {

    //                SMHR_DATEFORMAT _obj_Smhr_DateFormat = new SMHR_DATEFORMAT();
    //                _obj_Smhr_DateFormat.DATEFORMAT_CODE = ds.Tables[0].Rows[i]["Date Format*"].ToString();
    //                _obj_Smhr_DateFormat.OPERATION = operation.Check;
    //                DataTable dt_dateformate = BLL.get_DateFormat(_obj_Smhr_DateFormat);
    //                if (Convert.ToInt32(dt_dateformate.Rows[0]["COUNT"]) == 0)
    //                {
    //                    errormsg = errormsg + "," + "Date formate with this Name Does not Exists";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = columnno + "," + "Currency*";

    //                }

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Date Format*";

    //            }
    //            if (ds.Tables[0].Rows[i]["Address*"].ToString().Trim() != "")
    //            {
    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Address*";//

    //            }
    //            if (ds.Tables[0].Rows[i]["Min Age"].ToString().Trim() != "")
    //            {
    //                if (Convert.ToInt32(ds.Tables[0].Rows[i]["Min Age"]) < 18)
    //                {
    //                    errormsg = errormsg + "," + "Min Age  Should be more than 18";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = columnno + "," + "Min Age";


    //                }
    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Min Age";//

    //            }
    //            if (ds.Tables[0].Rows[i]["Max Age"].ToString().Trim() != "")
    //            {
    //                if (Convert.ToInt32(ds.Tables[0].Rows[i]["Max Age"]) < 55)
    //                {
    //                    errormsg = errormsg + "," + "Max Age  Should be more than 55";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = columnno + "," + "Max Age";


    //                }
    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Max Age";//


    //            }
    //            //if (ds.Tables[0].Rows[i]["Localisation*"].ToString().Trim() != "")
    //            //{





    //            //}
    //            //else
    //            //{
    //            //    filestatus = false;
    //            //    rowno = i + 2;
    //            //    columnno = columnno + "," + "Localisation*";

    //            //}
    //            if (ds.Tables[0].Rows[i]["Start Date*(dd/mm/yyyy)"].ToString().Trim() != "")
    //            {

    //                string sdate1 = "";

    //                sdate1 = ds.Tables[0].Rows[i]["Start Date*(dd/mm/yyyy)"].ToString();

    //                bool wrongsdformat = sdate1.Contains(".");

    //                if (wrongsdformat)
    //                    sdate1 = sdate1.Replace(".", "/");

    //                bool Chkdate = CheckDateFormat(sdate1);
    //                if (Chkdate == false)
    //                {
    //                    errormsg = errormsg + "," + "Enter Correct Start Date";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = columnno + "," + "Start Date*(dd/mm/yyyy)";

    //                }
    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Start Date*(dd/mm/yyyy)";

    //            }
    //            if (ds.Tables[0].Rows[i]["End Date(dd/mm/yyyy)"].ToString().Trim() != "")
    //            {
    //                string edate1 = "";
    //                edate1 = ds.Tables[0].Rows[i]["End Date(dd/mm/yyyy)"].ToString();
    //                bool wrongedformat = edate1.Contains(".");
    //                if (wrongedformat)
    //                    edate1 = edate1.Replace(".", "/");
    //                bool Chkdate = CheckDateFormat(edate1);
    //                if (Chkdate == false)
    //                {
    //                    errormsg = errormsg + "," + "Enter Correct End Date ";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = columnno + "," + "End Date(dd/mm/yyyy)";

    //                }
    //                else
    //                {
    //                    string sdate2 = "";

    //                    sdate2 = ds.Tables[0].Rows[i]["Start Date*(dd/mm/yyyy)"].ToString();

    //                    bool wrongsdformat = sdate2.Contains(".");

    //                    if (wrongsdformat)
    //                        sdate2 = sdate2.Replace(".", "/");

    //                    startdate = sdate2;
    //                    enddate = edate1;

    //                    sdate = new DateTime();
    //                    sdate = DateTime.ParseExact(startdate, "dd/MM/yyyy", null);
    //                    edate = new DateTime();
    //                    edate = DateTime.ParseExact(enddate, "dd/MM/yyyy", null);
    //                    if (edate < sdate)
    //                    {
    //                        errormsg = errormsg + "," + "End Date should not be less than Start Date";
    //                        filestatus = false;
    //                        rowno = i + 2;
    //                        columnno = columnno + "," + "End Date(dd/mm/yyyy)";
    //                    }
    //                    else
    //                    {
    //                    }


    //                }

    //            }
    //            //else
    //            //{
    //            //    filestatus = false;
    //            //    rowno = i + 2;
    //            //    columnno = columnno + "," + "End Date";

    //            //}
    //            ////if (ds.Tables[0].Rows[i]["Basic Percent"].ToString().Trim() != "")
    //            ////{
    //            ////    if (Convert.ToInt32(ds.Tables[0].Rows[i]["Basic Percent"]) > 100)
    //            ////    {
    //            ////        errormsg = errormsg + "," + "Basic Percent  Should be more than 100";
    //            ////        filestatus = false;
    //            ////        rowno = i + 2;
    //            ////        columnno = columnno + "," + "Max Age";
    //            ////    }
    //            ////}
    //            ////else
    //            ////{
    //            ////    filestatus = false;
    //            ////    rowno = i + 2;
    //            ////    columnno = columnno + "," + "Basic Percent";

    //            ////}
    //            if (filestatus == false)
    //            {
    //                DataRow newrow = dtfail.NewRow();
    //                newrow["S.NO"] = dtfail.Rows.Count + 1;


    //                newrow["ROWNO"] = rowno;
    //                newrow["COLUMNS NAMES"] = columnno;
    //                dtfail.Rows.Add(newrow);
    //                ds.Tables[0].Rows[i]["Error Message"] = errormsg;
    //            }
    //        }

    //        if (dtfail.Rows.Count > 0)
    //        {
    //            Session["dt_fail"] = dtfail;
    //            Session["ds_data"] = ds;
    //            Delete_Excel_File();
    //            //LinkButton lnk_Import_process = (LinkButton)RadPanelBar1.FindItemByValue("AddAttachment").FindControl("lnk_Import_process");
    //            Telerik.Web.UI.RadWindow newwindow = new Telerik.Web.UI.RadWindow();
    //            // RWM_POSTREPLY.Windows.Remove(newwindow);
    //            newwindow.ID = "RadWindow_import";

    //            newwindow.NavigateUrl = "~/Payroll/frm_AttendanceImportProcess.aspx";
    //            newwindow.Title = "Import Process";
    //            newwindow.Width = 1150;
    //            newwindow.Height = 580;
    //            newwindow.VisibleOnPageLoad = true;
    //            if (RWM_POSTREPLY1.Windows.Count > 1)
    //            {
    //                RWM_POSTREPLY1.Windows.RemoveAt(1);
    //            }
    //            RWM_POSTREPLY1.Windows.Add(newwindow);



    //            RWM_POSTREPLY1.Visible = true;
    //            return;

    //        }

    //        else
    //        {
    //            bool stus = false;
    //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //            {
    //                //bool status = false;
    //                int businessunitid = 0;
    //                int countryid = 0;
    //                int currencyid = 0;
    //                int dateformateid = 0;
    //                int masterid = 0;
    //                int master_paymentmodeid = 0;
    //                _obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
    //                if (ds.Tables[0].Rows[i]["Parent Business Unit"].ToString().Trim() != "")
    //                {
    //                    //########## businessunitid
    //                    _obj_Smhr_BusinessUnit.BUSINESSUNIT_CODE = ds.Tables[0].Rows[i]["Parent Business Unit"].ToString().Trim();
    //                    _obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                    _obj_Smhr_BusinessUnit.OPERATION = operation.Get;
    //                    DataTable dt_businessunit = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
    //                    if (dt_businessunit.Rows.Count > 0)
    //                    {
    //                        businessunitid = Convert.ToInt32(dt_businessunit.Rows[0]["BUSINESSUNIT_ID"]);
    //                    }



    //                    _obj_Smhr_BusinessUnit.BUSINESSUNIT_PARENT_BUSINESSUNIT_ID = businessunitid;
    //                }

    //                _obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

    //                _obj_Smhr_BusinessUnit.BUSINESSUNIT_CODE = ds.Tables[0].Rows[i]["Name*"].ToString().Trim();

    //                SMHR_CATEGORY _obj_Smhr_Category = new SMHR_CATEGORY();
    //                _obj_Smhr_Category.CATEGORY_CODE = ds.Tables[0].Rows[i]["Category*"].ToString().Trim();
    //                _obj_Smhr_Category.CATEGORY_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                _obj_Smhr_Category.OPERATION = operation.Get;
    //                DataTable dt_categoty = BLL.get_Category(_obj_Smhr_Category);
    //                if (dt_categoty.Rows.Count > 0)
    //                {

    //                    int CategoryId = Convert.ToInt32(dt_categoty.Rows[0]["CATEGORY_ID"]);
    //                   // _obj_Smhr_BusinessUnit.BUSINESSUNIT_CATAGORY_ID = CategoryId;
    //                }

    //                _obj_Smhr_BusinessUnit.BUSINESSUNIT_DESC = Convert.ToString(ds.Tables[0].Rows[i]["Description"]).Trim();




    //                //########## countryid


    //                SMHR_COUNTRY _obj_Smhr_Country = new SMHR_COUNTRY();
    //                _obj_Smhr_Country.COUNTRY_CODE = ds.Tables[0].Rows[i]["Country*"].ToString().Trim();
    //                _obj_Smhr_Country.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                _obj_Smhr_Country.OPERATION = operation.Get;
    //                DataTable dt_country = BLL.get_Country(_obj_Smhr_Country);
    //                if (dt_country.Rows.Count > 0)
    //                {
    //                    countryid = Convert.ToInt32(dt_country.Rows[0]["COUNTRY_ID"]);
    //                }

    //                _obj_Smhr_BusinessUnit.BUSINESSUNIT_COUNTRY_ID = countryid;




    //                //#######  currencyid
    //                SMHR_CURRENCY _obj_Smhr_Currency = new SMHR_CURRENCY();
    //                _obj_Smhr_Currency.CURR_CODE = ds.Tables[0].Rows[i]["Currency*"].ToString().Trim().ToUpper();
    //                _obj_Smhr_Currency.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                _obj_Smhr_Currency.OPERATION = operation.Get;
    //                DataTable dt_currency = BLL.get_Currency(_obj_Smhr_Currency);
    //                if (dt_currency.Rows.Count > 0)
    //                {
    //                    currencyid = Convert.ToInt32(dt_currency.Rows[0]["CURR_ID"]);
    //                }
    //                _obj_Smhr_BusinessUnit.BUSINESSUNIT_CURRENCY_ID = currencyid;

    //                //###### DATEFORMATEID


    //                SMHR_DATEFORMAT _obj_Smhr_DateFormat = new SMHR_DATEFORMAT();
    //                _obj_Smhr_DateFormat.DATEFORMAT_CODE = ds.Tables[0].Rows[i]["Date Format*"].ToString();
    //                _obj_Smhr_DateFormat.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                _obj_Smhr_DateFormat.OPERATION = operation.Get;
    //                DataTable dt_dateformate = BLL.get_DateFormat(_obj_Smhr_DateFormat);
    //                if (dt_dateformate.Rows.Count > 0)
    //                {
    //                    dateformateid = Convert.ToInt32(dt_dateformate.Rows[0]["DATEFORMAT_ID"]);
    //                }
    //                _obj_Smhr_BusinessUnit.BUSINESSUNIT_DATEFORMAT_ID = dateformateid;
    //                _obj_Smhr_BusinessUnit.BUSINESSUNIT_ADDRESS = ds.Tables[0].Rows[i]["Address*"].ToString();
    //                string minage;
    //                string maxage;
    //                string age;
    //                minage = Convert.ToString(ds.Tables[0].Rows[i]["Min Age"]);
    //                maxage = ds.Tables[0].Rows[i]["Max Age"].ToString();
    //                age = minage + "-" + maxage;

    //                //#####    masterid for localisation
    //                SMHR_MASTERS _obj_Smhr_Masters = new SMHR_MASTERS();
    //                if (ds.Tables[0].Rows[i]["Localisation"].ToString().Trim() == "")
    //                {
    //                    _obj_Smhr_BusinessUnit.BUSINESSUNIT_LOCALISATION1 = 0;
    //                }
    //                else
    //                {
    //                    _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                    _obj_Smhr_Masters.MASTER_TYPE = "LOCALISATION";
    //                    _obj_Smhr_Masters.MASTER_CODE = ds.Tables[0].Rows[i]["Localisation"].ToString();
    //                    _obj_Smhr_Masters.OPERATION = operation.Get;
    //                    DataTable dt_masterid = BLL.get_MasterRecords(_obj_Smhr_Masters);
    //                    if (dt_masterid.Rows.Count > 0)
    //                    {
    //                        masterid = Convert.ToInt32(dt_masterid.Rows[0]["HR_MASTER_ID"]);
    //                    }
    //                    _obj_Smhr_BusinessUnit.BUSINESSUNIT_LOCALISATION1 = masterid;
    //                }
    //                if (ds.Tables[0].Rows[i]["Localisation"].ToString().ToUpper() == "INDIA")
    //                {

    //                    _obj_Smhr_BusinessUnit.BUSINESSUNIT_AGE = age;




    //                    if (ds.Tables[0].Rows[i]["Is Metro"].ToString().Trim() == "")
    //                    {
    //                        _obj_Smhr_BusinessUnit.BUSINESSUNIT_ISMETRO = Convert.ToBoolean(null);
    //                    }
    //                    else
    //                    {

    //                        _obj_Smhr_BusinessUnit.BUSINESSUNIT_ISMETRO = Convert.ToBoolean(ds.Tables[0].Rows[i]["Is Metro"]);
    //                    }

    //                    //########## MASTERID FOR PAYMENTMODE
    //                    _obj_Smhr_Masters.MASTER_TYPE = "PAYMENTMODE";
    //                    _obj_Smhr_Masters.MASTER_CODE = ds.Tables[0].Rows[i]["Payment Modes"].ToString();
    //                    _obj_Smhr_Masters.OPERATION = operation.Get;
    //                    DataTable dt_masterid_PAYMOD = BLL.get_MasterRecords(_obj_Smhr_Masters);
    //                    if (dt_masterid_PAYMOD.Rows.Count > 0)
    //                    {
    //                        master_paymentmodeid = Convert.ToInt32(dt_masterid_PAYMOD.Rows[0]["HR_MASTER_ID"]);
    //                    }
    //                    _obj_Smhr_BusinessUnit.BUSINESSUNIT_PAYMENTMETHODS = Convert.ToString(master_paymentmodeid);
    //                }
    //                else
    //                {
    //                    _obj_Smhr_BusinessUnit.BUSINESSUNIT_AGE = null;
    //                    _obj_Smhr_BusinessUnit.BUSINESSUNIT_ISMETRO = false;
    //                }

    //                _obj_Smhr_BusinessUnit.BUSINESSUNIT_SUPERVISOR = 0;
    //                if (Convert.ToString(ds.Tables[0].Rows[i]["Start Date*(dd/mm/yyyy)"]).Contains("."))
    //                {
    //                    _obj_Smhr_BusinessUnit.SDATE = Convert.ToString(ds.Tables[0].Rows[i]["Start Date*(dd/mm/yyyy)"]).Replace(".", "/");

    //                }
    //                else
    //                {
    //                    _obj_Smhr_BusinessUnit.SDATE = Convert.ToString(ds.Tables[0].Rows[i]["Start Date*(dd/mm/yyyy)"]);

    //                }
    //                if (Convert.ToString(ds.Tables[0].Rows[i]["End Date(dd/mm/yyyy)"]).Contains("."))
    //                {
    //                    _obj_Smhr_BusinessUnit.EDATE = Convert.ToString(ds.Tables[0].Rows[i]["End Date(dd/mm/yyyy)"]).Replace(".", "/");

    //                }
    //                else
    //                {
    //                    _obj_Smhr_BusinessUnit.EDATE = Convert.ToString(ds.Tables[0].Rows[i]["End Date(dd/mm/yyyy)"]);
    //                }

    //                _obj_Smhr_BusinessUnit.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);  // ### Need to Get the Session
    //                _obj_Smhr_BusinessUnit.CREATEDDATE = DateTime.Now;
    //                if (ds.Tables[0].Rows[i]["OverTime"].ToString().Trim() == "")
    //                {
    //                    _obj_Smhr_BusinessUnit.BUSINESSUNIT_OVERTIME = null;

    //                }
    //                else
    //                {
    //                    _obj_Smhr_BusinessUnit.BUSINESSUNIT_OVERTIME = Convert.ToBoolean(ds.Tables[0].Rows[i]["OverTime"]);
    //                }
    //                _obj_Smhr_BusinessUnit.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);  // ### Need to Get the Session
    //                _obj_Smhr_BusinessUnit.LASTMDFDATE = DateTime.Now;

    //                if (ds.Tables[0].Rows[i]["Is VariablePay"].ToString().Trim() == "")
    //                {
    //                    _obj_Smhr_BusinessUnit.IS_VARIABLEPAY = false;

    //                }
    //                else
    //                {

    //                    _obj_Smhr_BusinessUnit.IS_VARIABLEPAY = Convert.ToBoolean(ds.Tables[0].Rows[i]["Is VariablePay"]);
    //                }

    //                if (ds.Tables[0].Rows[i]["Basic Percent"].ToString().Trim() == "")
    //                {
    //                    _obj_Smhr_BusinessUnit.BUSINESSUNIT_BASICPERCENT = 0.00;
    //                }
    //                else
    //                {
    //                    _obj_Smhr_BusinessUnit.BUSINESSUNIT_BASICPERCENT = Convert.ToDouble(ds.Tables[0].Rows[i]["Basic Percent"]);
    //                }
    //                //_obj_Smhr_BusinessUnit.OPERATION = operation.Validate;
    //                //if (Convert.ToString(BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit).Rows[0]["Count"]) != "0")
    //                //{
    //                //    BLL.ShowMessage(this, "Business Unit with this code Already Exists");
    //                //    return;
    //                //}
    //                _obj_Smhr_BusinessUnit.OPERATION = operation.Insert1;
    //                stus = BLL.set_BusinessUnit(_obj_Smhr_BusinessUnit);

    //                UpdateAdmins();
    //                //  BLL.ShowMessage(this, "Information Saved Successfully");
    //                //  Rm_BU_page.SelectedIndex = 0;






    //            }
    //            if (stus == true)
    //            {
    //                LoadGrid();
    //                Rg_BusinessUnit.DataBind();
    //                BLL.ShowMessage(this, "Information Saved Successfully");
    //            }
    //        }




    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;


    //    }

    //}

    protected void chkNoOfHours_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkNoOfHours.Checked)
            {
                trNoOfHours.Visible = true;
                //  trNote.Visible = true;
                //trChkNoOfHours.Visible = true;
            }
            else
            {
                trNoOfHours.Visible = false;
                //   trNote.Visible = false;
                //trChkNoOfHours.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BusinessUnit", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #region Upload Image

    /// <summary>
    /// this method will show the selected image
    /// </summary>    
    protected void btn_Upload_Click(object sender, EventArgs e)
    {
        try
        {
            if (FUpload.HasFile)
            {
                string fileExt =
                   System.IO.Path.GetExtension(FUpload.FileName);

                if (fileExt == ".jpeg" || fileExt == ".jpg" || fileExt == ".png")
                {
                    if (FUpload.HasFile)
                    {
                        strPath = "~/BULogo/" + FUpload.FileName;     //+ txt_AppLastName.Text 
                        //strPath = "E:\\SMHR_BASE_VSS2013\\EmpUploads\\_Chrysanthemum.gif";     //+ txt_AppLastName.Text 
                        FUpload.PostedFile.SaveAs(Server.MapPath("~/BULogo/") + FUpload.FileName); //+ txt_AppLastName.Text 
                        RBI_BU_Image.ImageUrl = strPath;
                        RBI_BU_Image.Visible = true;
                        lblMsg.Visible = true;
                        lblMsg.Text = Convert.ToString(strPath);
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Please Upload Image");
                        return;
                    }
                }
                else
                {
                    //lbl_UploadImg.Text = "Only .jpeg files allowed!";
                    BLL.ShowMessage(this, "Only .jpeg and .png files are allowed!");
                }
            }
            else
            {
                BLL.ShowMessage(this, "You have not specified a file");
            }
            //int intImageSize;
            //    string strImageType;
            //    Stream imageStream;

            //    // Gets the Size of the Image
            //    intImageSize = FUpload.PostedFile.ContentLength;
            //    //if (intImageSize < 16000)
            //    //{
            //        // Gets the Image Type
            //        strImageType = FUpload.PostedFile.ContentType;

            //        // Reads the Image stream
            //        imageStream = FUpload.PostedFile.InputStream;

            //        byte[] btImageContent = new byte[intImageSize];
            //        //int intStatus;
            //        //intStatus = imageStream.Read(imageContent, 0, imageSize);

            //        FUpload.PostedFile.InputStream.Read(btImageContent, 0, intImageSize);


            //        Session["imageContent"] = btImageContent;
            //        byte[] _Img = System.IO.File.ReadAllBytes(strPath);
            //        //byte[] _Img = (byte[])strPath.ToString() ;
            //        MemoryStream ms = new MemoryStream(_Img);
            //        //byte imgData = Convert.ToByte();

            //        //objPatientDemography.PATIENT_PHOTO = Session["imageContent"] as byte[];
            //    //}

            //lnkPicDelete.Visible = true;
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BusinessUnit", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //protected void lnkPicDelete_Click(object sender, EventArgs e)
    //{
    //    bool status = false;
    //    _obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
    //    _obj_Smhr_BusinessUnit.OPERATION = operation.DelPic;
    //    _obj_Smhr_BusinessUnit.BUSINESSUNIT_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);   //Convert.ToInt32(HF_EMPID.Value);
    //    _obj_Smhr_BusinessUnit.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnitParent.SelectedValue);
    //    _obj_Smhr_BusinessUnit.BUSINESSUNIT_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //    //status = BLL.getBU(_obj_Smhr_BusinessUnit);
    //    DataTable dtBU = BLL.getBU(_obj_Smhr_BusinessUnit);
    //    if (status == true)
    //    {
    //        RBI_BU_Image.ImageUrl = "";
    //        lnkPicDelete.Visible = false;
    //    }
    //}

    #endregion
}