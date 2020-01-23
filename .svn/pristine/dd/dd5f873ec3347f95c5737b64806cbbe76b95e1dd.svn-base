using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Pension_frm_IntrstOnNormlContribution : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (!IsPostBack)
            {
                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Interest On Normal Contributions");//COUNTRY");
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
                    Rg_IntrstOnNormalContributions.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IntrstOnNormlContribution", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void Rg_IntrstOnNormalContributions_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IntrstOnNormlContribution", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadGrid()
    {
        try
        {
            SMHR_PNCN_INTRST _objPnCn = new SMHR_PNCN_INTRST();
            _objPnCn.OPERATION = operation.Select;
            _objPnCn.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtPensionCbn = BLL.get_PensionContributionInterest(_objPnCn);
            Rg_IntrstOnNormalContributions.DataSource = dtPensionCbn;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IntrstOnNormlContribution", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            ClearControls();
            rcmb_FinancialYear.Enabled = true;
            LoadFinancialPeriods(); //To load financial periods
            btn_Save.Visible = false;
            btn_Update.Visible = false;
            RMP_IntrstOnNormalContributions.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IntrstOnNormlContribution", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void ClearControls()
    {
        try
        {
            lblPNCN_ID.Text = string.Empty;
            rcmb_FinancialYear.Items.Clear();
            rcmb_FinancialYear.Text = string.Empty;
            rtxt_Qrtr1.Text = string.Empty;
            rtxt_Qrtr2.Text = string.Empty;
            rtxt_Qrtr3.Text = string.Empty;
            rtxt_Qrtr4.Text = string.Empty;
            trQrtr1.Visible = false;
            trQrtr2.Visible = false;
            trQrtr3.Visible = false;
            trQrtr4.Visible = false;
            trYearlyIntrst.Visible = false;
            rtxt_YearlyInterest.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IntrstOnNormlContribution", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadFinancialPeriods()
    {
        try
        {
            SMHR_PERIOD _obj_smhr_period = new SMHR_PERIOD();
            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtFinancialPeriods = BLL.get_PeriodHeaderDetails(_obj_smhr_period);
            rcmb_FinancialYear.DataSource = dtFinancialPeriods;
            rcmb_FinancialYear.DataValueField = "PERIOD_ID";
            rcmb_FinancialYear.DataTextField = "PERIOD_NAME";
            rcmb_FinancialYear.DataBind();
            rcmb_FinancialYear.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IntrstOnNormlContribution", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            //to clear controls
            ClearControls();
            rcmb_FinancialYear.Enabled = false;
            LoadFinancialPeriods(); //To load financial periods

            //To fetch data based on CommandArgument
            SMHR_PNCN_INTRST _objPNCNIntrst = new SMHR_PNCN_INTRST();
            _objPNCNIntrst.PNCN_ID = Convert.ToInt32(e.CommandArgument);
            _objPNCNIntrst.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _objPNCNIntrst.OPERATION = operation.Get;
            DataTable dtPensionCbn = BLL.get_PensionContributionInterest(_objPNCNIntrst);

            if (dtPensionCbn.Rows.Count > 0)    //If data exists, fill the data in respective controls
            {
                lblPNCN_ID.Text = Convert.ToString(dtPensionCbn.Rows[0]["PNCN_ID"]);
                rcmb_FinancialYear.SelectedIndex = rcmb_FinancialYear.Items.FindItemIndexByValue(Convert.ToString(dtPensionCbn.Rows[0]["PNCN_PERIOD_ID"]));
                rcmb_FinancialYear_SelectedIndexChanged(null, null);

                rtxt_Qrtr1.Text = Convert.ToString(dtPensionCbn.Rows[0]["PNCN_QRTR1"]);
                rtxt_Qrtr2.Text = Convert.ToString(dtPensionCbn.Rows[0]["PNCN_QRTR2"]);
                rtxt_Qrtr3.Text = Convert.ToString(dtPensionCbn.Rows[0]["PNCN_QRTR3"]);
                rtxt_Qrtr4.Text = Convert.ToString(dtPensionCbn.Rows[0]["PNCN_QRTR4"]);
                rtxt_YearlyInterest.Text = Convert.ToString(dtPensionCbn.Rows[0]["PNCN_YEARLY_INTEREST"]);
            }
            else
            {
                ClearControls();
            }

            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                btn_Update.Visible = false;
            else
                btn_Update.Visible = true;

            btn_Save.Visible = false;   //hide save button as the user clicks on Edit
            RMP_IntrstOnNormalContributions.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IntrstOnNormlContribution", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (rcmb_FinancialYear.SelectedIndex <= 0)
            {
                BLL.ShowMessage(this, "Please Select Financial Year");
                return;
            }
            else if (string.IsNullOrEmpty(rtxt_YearlyInterest.Text))
            {
                BLL.ShowMessage(this, "No details exists to save");
                return;
            }

            SMHR_PNCN_INTRST _objPNCNIntrst = new SMHR_PNCN_INTRST();
            _objPNCNIntrst.PNCN_PERIOD_ID = Convert.ToInt32(rcmb_FinancialYear.SelectedValue);
            _objPNCNIntrst.PNCN_QRTR1 = string.IsNullOrEmpty(rtxt_Qrtr1.Text) ? 0 : Convert.ToDecimal(rtxt_Qrtr1.Text);
            _objPNCNIntrst.PNCN_QRTR2 = string.IsNullOrEmpty(rtxt_Qrtr2.Text) ? 0 : Convert.ToDecimal(rtxt_Qrtr2.Text);
            _objPNCNIntrst.PNCN_QRTR3 = string.IsNullOrEmpty(rtxt_Qrtr3.Text) ? 0 : Convert.ToDecimal(rtxt_Qrtr3.Text);
            _objPNCNIntrst.PNCN_QRTR4 = string.IsNullOrEmpty(rtxt_Qrtr4.Text) ? 0 : Convert.ToDecimal(rtxt_Qrtr4.Text);
            _objPNCNIntrst.PNCN_YEARLY_INTEREST = string.IsNullOrEmpty(rtxt_YearlyInterest.Text) ? 0 : Convert.ToDecimal(rtxt_YearlyInterest.Text);
            _objPNCNIntrst.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            switch (((Button)sender).ID.ToUpper())
            {

                case "BTN_SAVE":

                    //To check if similar record exists
                    _objPNCNIntrst.OPERATION = operation.Check;
                    if (BLL.set_PensionContributionInterest(_objPNCNIntrst))
                    {
                        BLL.ShowMessage(this, "Record already exists for the selected Financial Year");
                        return;
                    }


                    _objPNCNIntrst.CREATEDBY = Convert.ToInt32(Session["User_ID"]);
                    _objPNCNIntrst.CREATEDDATE = DateTime.Now;
                    _objPNCNIntrst.OPERATION = operation.Insert;

                    if (BLL.set_PensionContributionInterest(_objPNCNIntrst))
                        BLL.ShowMessage(this, "Information Saved Sucessfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;

                case "BTN_UPDATE":

                    _objPNCNIntrst.PNCN_ID = Convert.ToInt32(lblPNCN_ID.Text);
                    _objPNCNIntrst.PNCN_MODIFIEDBY = Convert.ToInt32(Session["User_ID"]);
                    _objPNCNIntrst.PNCN_MODIFIEDDATE = DateTime.Now;
                    _objPNCNIntrst.OPERATION = operation.Update;

                    if (BLL.set_PensionContributionInterest(_objPNCNIntrst))
                        BLL.ShowMessage(this, "Information Updated Sucessfully");
                    else
                        BLL.ShowMessage(this, "Information Not Updated");
                    break;

                default:
                    break;
            }

            RMP_IntrstOnNormalContributions.SelectedIndex = 0;
            ClearControls();
            LoadGrid();
            Rg_IntrstOnNormalContributions.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IntrstOnNormlContribution", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            ClearControls();
            btn_Save.Visible = false;
            btn_Update.Visible = false;
            RMP_IntrstOnNormalContributions.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IntrstOnNormlContribution", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_FinancialYear_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_FinancialYear.SelectedIndex > 0)
            {
                btn_Save.Visible = true;
            }
            else
            {
                btn_Save.Visible = false;
            }
            //clear controls
            trQrtr1.Visible = false;
            trQrtr2.Visible = false;
            trQrtr3.Visible = false;
            trQrtr4.Visible = false;
            trYearlyIntrst.Visible = false;

            SMHR_PENSION_QUARTERS _obj_Smhr_PensionQrtrs = new SMHR_PENSION_QUARTERS();
            _obj_Smhr_PensionQrtrs.OPERATION = operation.Select_New;
            _obj_Smhr_PensionQrtrs.QRTR_PERIODID = Convert.ToInt32(rcmb_FinancialYear.SelectedValue);
            _obj_Smhr_PensionQrtrs.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_PensionQuarters(_obj_Smhr_PensionQrtrs);

            if (dt.Rows.Count > 0)
            {
                btn_Save.Visible = true;
                int noOfQrtrs = Convert.ToInt32(dt.Rows[0]["QRTR_NOOFQRTRS"]);
                if (noOfQrtrs > 0)
                {
                    trYearlyIntrst.Visible = true;

                    for (int i = 1; i <= noOfQrtrs; i++)
                    {
                        if (i == 1)
                            trQrtr1.Visible = true;
                        else if (i == 2)
                            trQrtr2.Visible = true;
                        else if (i == 3)
                            trQrtr3.Visible = true;
                        else if (i == 4)
                            trQrtr4.Visible = true;
                    }
                }
            }
            else
            {
                btn_Save.Visible = false;
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IntrstOnNormlContribution", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}