using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Data;
using Telerik.Web.UI;
using SPMS;
using System.Text;

public partial class Masters_frm_LoanSetup : System.Web.UI.Page
{
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Loan Setup");//TRAINING APPROVAL");
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
                    RG_TrainingApproval.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_submit.Visible = false;
                    // btn_Update.Visible = false;
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
                //RG_TrainingApproval.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;

                BindFinancialPeriod();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LoanSetup", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }





    }
    protected void BindFinancialPeriod()
    {
        try
        {
            SMHR_PERIOD _obj_smhr_period = new SMHR_PERIOD();
            DataTable dt_Details = new DataTable();
            _obj_smhr_period.OPERATION = operation.Select;
            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_PeriodHeaderDetails(_obj_smhr_period);
            rc_financialPeriod.DataSource = dt_Details;
            rc_financialPeriod.DataValueField = "PERIOD_ID";
            rc_financialPeriod.DataTextField = "PERIOD_NAME";
            rc_financialPeriod.DataBind();
            rc_financialPeriod.Items.Insert(0, new RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LoanSetup", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rc_FinalicalPeriod_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rc_financialPeriod.SelectedIndex > 0)
            {
                RG_TrainingApproval.Visible = true;
                btn_submit.Visible = true;
                btn_Cancel.Visible = true;
                SMHR_PAYITEMS _obj_Smhr_PayItems = new SMHR_PAYITEMS();
                _obj_Smhr_PayItems.OPERATION = operation.Check2;
                _obj_Smhr_PayItems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_PayItems.PAYITEM_FINPERIODID = Convert.ToInt32(rc_financialPeriod.SelectedValue);
                DataTable dt = BLL.get_PayItems(_obj_Smhr_PayItems);

                RG_TrainingApproval.DataSource = dt;
                RG_TrainingApproval.DataBind();

                RadComboBox rc_LoanProcessType;

                for (int i = 0; i < RG_TrainingApproval.Items.Count; i++)
                {
                    
                    rc_LoanProcessType = RG_TrainingApproval.Items[i].FindControl("rc_LoanProcessType") as RadComboBox;
                    //rc_LoanProcessType.SelectedValue = Convert.ToString(dt.Rows[i]["LOANSETUP_LOANPROCESSTYPE"]);
                    rc_LoanProcessType.SelectedIndex = rc_LoanProcessType.Items.FindItemIndexByText(Convert.ToString(dt.Rows[i]["LOANSETUP_LOANPROCESSTYPE"]));
                }

                SMHR_PERIOD osmhr_period = new SMHR_PERIOD();
                osmhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                osmhr_period.PERIOD_ID = Convert.ToInt32(rc_financialPeriod.SelectedValue);
                DataTable dtCurrentFinPeriod = BLL.IscurrentFinPeriod(osmhr_period);

                if (string.Compare(dtCurrentFinPeriod.Rows[0]["ISEXISTS"].ToString(), "0", true) == 0)
                {
                    RG_TrainingApproval.Enabled = false;
                    btn_submit.Visible = false;
                    btn_Cancel.Visible = false;
                }
                else
                {
                    RG_TrainingApproval.Enabled = true;
                    btn_submit.Visible = true;
                    btn_Cancel.Visible = true;
                }
            }
            else
            {
                RG_TrainingApproval.Visible = false;
                btn_submit.Visible = false;
                btn_Cancel.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LoanSetup", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            RG_TrainingApproval.Visible = false;
            btn_submit.Visible = false;
            btn_Cancel.Visible = false;
            rc_financialPeriod.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LoanSetup", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        try
        {
            if (rc_financialPeriod.SelectedIndex <= 0)
            {
                BLL.ShowMessage(this, "Please Select Financial Period");
                return;
            }
            DataTable dtGadeWiseData = GetGadeWiseAMount();
            SMHR_LOANSETUP smhr_LoanSetup = new SMHR_LOANSETUP();
            smhr_LoanSetup.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            smhr_LoanSetup.LOANSETUP_GRIDDATA = dtGadeWiseData;
            smhr_LoanSetup.LOANSETUP_FINPERIODID = Convert.ToInt32(rc_financialPeriod.SelectedValue);
            smhr_LoanSetup.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            smhr_LoanSetup.CREATEDDATE = DateTime.Now;
            smhr_LoanSetup.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            smhr_LoanSetup.LASTMDFDATE = DateTime.Now;
            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_SUBMIT":
                    smhr_LoanSetup.OPERATION = operation.Insert;
                    if (BLL.set_LoanSetup(smhr_LoanSetup))
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                default:
                    break;
            }
            rc_financialPeriod.ClearSelection();
            rc_financialPeriod.Text = string.Empty;
            RG_TrainingApproval.Visible = false;
            btn_submit.Visible = false;
            btn_Cancel.Visible = false;

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LoanSetup", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private DataTable GetGadeWiseAMount()
    {
        DataTable dt = GetGridDataTable();
        try
        {
            RadNumericTextBox txtMinTenureMonths, txtMaxTenureMonths, txtInterest;
            RadComboBox rdProcessType;
            foreach (GridDataItem d in RG_TrainingApproval.Items)
            {

                txtMinTenureMonths = new RadNumericTextBox();
                txtMinTenureMonths = d.FindControl("rtxt_Min") as RadNumericTextBox;

                txtMaxTenureMonths = new RadNumericTextBox();
                txtMaxTenureMonths = d.FindControl("rtxt_Max") as RadNumericTextBox;

                txtInterest = new RadNumericTextBox(); 
                txtInterest = d.FindControl("rtxt_Interest") as RadNumericTextBox;

                rdProcessType = new RadComboBox(); 
                rdProcessType = d.FindControl("rc_LoanProcessType") as RadComboBox; 

                dt.Rows.Add(Convert.ToInt32(d.Cells[2].Text), rdProcessType.SelectedItem.Text, Convert.ToInt32(txtMinTenureMonths.Text), Convert.ToInt32(txtMaxTenureMonths.Text), Convert.ToDecimal(txtInterest.Text));
            }
        }
        catch (Exception ex) 
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LoanSetup", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return dt;
    }

    private DataTable GetGridDataTable()
    {
        DataTable dt = new DataTable();
        try
        {
            dt.Columns.Add("LOANSETUP_LOANTYPE_ID", typeof(int));
            dt.Columns.Add("LOANSETUP_LOANPROCESSTYPE", typeof(string));
            dt.Columns.Add("LOANSETUP_MINTENUREMONTHS", typeof(int));
            dt.Columns.Add("LOANSETUP_MAXTENUREMONTHS", typeof(int));
            dt.Columns.Add("LOANSETUP_LOANINTEREST", typeof(decimal));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LoanSetup", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return dt;
    }
}