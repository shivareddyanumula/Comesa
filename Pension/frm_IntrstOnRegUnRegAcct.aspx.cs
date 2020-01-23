using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Pension_frm_IntrstOnRegUnRegAcct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //code for security privilage
            Session.Remove("WRITEFACILITY");

            SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

            _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
            _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
            _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Interest On Regd & UnRegd");
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
                Rg_IntrstOnRegstUnRegstAcct.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IntrstOnRegUnRegAcct", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rg_IntrstOnRegstUnRegstAcct_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IntrstOnRegUnRegAcct", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadGrid()
    {
        try
        {
            SMHR_PENSION_INT_REG_UNREG objPensionInt = new SMHR_PENSION_INT_REG_UNREG();
            objPensionInt.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            objPensionInt.OPERATION = operation.Select;
            DataTable dtPensionInt = BLL.get_PensionIntOnRegtUnRegtAmt(objPensionInt);
            Rg_IntrstOnRegstUnRegstAcct.DataSource = dtPensionInt;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IntrstOnRegUnRegAcct", ex.StackTrace, DateTime.Now);
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
            SMHR_PENSION_INT_REG_UNREG _objPensionInt = new SMHR_PENSION_INT_REG_UNREG();
            _objPensionInt.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _objPensionInt.INT_ID = Convert.ToInt32(e.CommandArgument);
            _objPensionInt.OPERATION = operation.Get;

            DataTable dt = BLL.get_PensionIntOnRegtUnRegtAmt(_objPensionInt);

            if (dt.Rows.Count > 0)
            {
                lblInterestID.Text = Convert.ToString(dt.Rows[0]["INT_ID"]);
                rcmb_FinancialYear.SelectedIndex = rcmb_FinancialYear.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["INT_PERIOD_ID"]));
                rtxt_Registered.Text = Convert.ToString(dt.Rows[0]["INT_REGISTERED_AMT"]);
                rtxt_UnRegistered.Text = Convert.ToString(dt.Rows[0]["INT_UNREGISTERED_AMT"]);
                rtxt_Normal.Text = Convert.ToString(dt.Rows[0]["INT_NORMAL_AMT"]);
            }
            else
            {
                ClearControls();
            }
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                btn_Update.Visible = false;
            else
                btn_Update.Visible = true;
                
            btn_Save.Visible = false;
            RMP_IntrstOnRegstUnRegstAcct.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IntrstOnRegUnRegAcct", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            ClearControls();
            rcmb_FinancialYear.Enabled = true;
            LoadFinancialPeriods();
            btn_Save.Visible = true;
            btn_Update.Visible = false;
            RMP_IntrstOnRegstUnRegstAcct.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IntrstOnRegUnRegAcct", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void ClearControls()
    {
        try
        {
            lblInterestID.Text = string.Empty;
            rcmb_FinancialYear.Items.Clear();
            rcmb_FinancialYear.Text = string.Empty;
            rtxt_Registered.Text = string.Empty;
            rtxt_UnRegistered.Text = string.Empty;
            rtxt_Normal.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IntrstOnRegUnRegAcct", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IntrstOnRegUnRegAcct", ex.StackTrace, DateTime.Now);
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
            RMP_IntrstOnRegstUnRegstAcct.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IntrstOnRegUnRegAcct", ex.StackTrace, DateTime.Now);
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

            SMHR_PENSION_INT_REG_UNREG _objPensionInt = new SMHR_PENSION_INT_REG_UNREG();
            _objPensionInt.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _objPensionInt.INT_PERIOD_ID = Convert.ToInt32(rcmb_FinancialYear.SelectedValue);
            _objPensionInt.INT_REGISTERED_AMT = Convert.ToDecimal(rtxt_Registered.Text);
            _objPensionInt.INT_UNREGISTERED_AMT = Convert.ToDecimal(rtxt_UnRegistered.Text);
            _objPensionInt.INT_NORMAL_AMT = Convert.ToDecimal(rtxt_Normal.Text);

            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_SAVE":

                    //To check if similar record exists
                    _objPensionInt.OPERATION = operation.Check;
                    if (BLL.set_PensionIntOnRegtUnRegtAcct(_objPensionInt))
                    {
                        BLL.ShowMessage(this, "Record already exists with similar data");
                        return;
                    }

                    _objPensionInt.OPERATION = operation.Insert;
                    _objPensionInt.CREATEDBY = Convert.ToInt32(Session["User_ID"]);
                    _objPensionInt.CREATEDDATE = DateTime.Now;

                    if (BLL.set_PensionIntOnRegtUnRegtAcct(_objPensionInt))
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;

                case "BTN_UPDATE":
                    _objPensionInt.OPERATION = operation.Update;
                    _objPensionInt.INT_ID = Convert.ToInt32(lblInterestID.Text);
                    _objPensionInt.CREATEDBY = Convert.ToInt32(Session["User_ID"]);
                    _objPensionInt.CREATEDDATE = DateTime.Now;

                    if (BLL.set_PensionIntOnRegtUnRegtAcct(_objPensionInt))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Updated");
                    break;

                default:
                    break;
            }
            RMP_IntrstOnRegstUnRegstAcct.SelectedIndex = 0;
            ClearControls();
            LoadGrid();
            Rg_IntrstOnRegstUnRegstAcct.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IntrstOnRegUnRegAcct", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}