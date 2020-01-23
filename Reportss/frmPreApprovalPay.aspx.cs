using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Reportss_frmPreApprovalPay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
            if (!IsPostBack)
            {
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();
                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Pre Approval Pay");//PAYROLLPROCESS");
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


                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 3)
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
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmPreApprovalPay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadCombos()
    {
        try
        {
            //SMHR_BUSINESSUNIT _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
            SMHR_PERIOD _obj_smhr_period = new SMHR_PERIOD();
            DataTable dt_Details = new DataTable();

            SMHR_LOGININFO _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            rcmb_BUI.DataSource = dt_BUDetails;
            rcmb_BUI.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BUI.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BUI.DataBind();
            rcmb_BUI.Items.Insert(0, new RadComboBoxItem("Select"));


            _obj_smhr_period.OPERATION = operation.Select;
            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_PeriodHeaderDetails(_obj_smhr_period);
            rcmb_PeriodMaster.DataSource = dt_Details;
            rcmb_PeriodMaster.DataValueField = "PERIOD_ID";
            rcmb_PeriodMaster.DataTextField = "PERIOD_NAME";
            rcmb_PeriodMaster.DataBind();
            rcmb_PeriodMaster.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmPreApprovalPay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_BUI_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rcmb_PeriodElement.Items.Clear();
            rcmb_PeriodMaster.ClearSelection();
            rcmb_PeriodElement.Items.Insert(0, new RadComboBoxItem("", ""));
            rcb_Transaction.Items.Clear();
            rcb_Transaction.Text = string.Empty;

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmPreApprovalPay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_PeriodMaster_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rcb_Transaction.Items.Clear();
            rcb_Transaction.Items.Insert(0, new RadComboBoxItem("", ""));
            if (rcmb_PeriodMaster.SelectedIndex != 0)
            {
                SMHR_PERIODDTL _obj_smhr_perioddtl = new SMHR_PERIODDTL();
                _obj_smhr_perioddtl.OPERATION = operation.Select;
                _obj_smhr_perioddtl.PRDDTL_PERIOD_ID = Convert.ToInt32(rcmb_PeriodMaster.SelectedItem.Value);
                DataTable dt_Details = new DataTable();
                dt_Details = BLL.get_PeriodDetails(_obj_smhr_perioddtl);
                if (dt_Details.Rows.Count != 0)
                {
                    rcmb_PeriodElement.DataSource = dt_Details;
                    rcmb_PeriodElement.DataValueField = "PRDDTL_ID";
                    rcmb_PeriodElement.DataTextField = "PRDDTL_NAME";
                    rcmb_PeriodElement.DataBind();
                    rcmb_PeriodElement.Items.Insert(0, new RadComboBoxItem("Select"));
                }
            }
            else
            {
                rcmb_PeriodElement.Items.Clear();
                rcmb_PeriodElement.Items.Insert(0, new RadComboBoxItem("", ""));
                rcb_Transaction.Items.Clear();
                rcb_Transaction.Items.Insert(0, new RadComboBoxItem("", ""));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmPreApprovalPay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_PeriodElement_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rcb_Transaction.Items.Clear();
            rcb_Transaction.Items.Insert(0, new RadComboBoxItem("", ""));

            if ((rcmb_BUI.SelectedIndex > 0) && (rcmb_PeriodMaster.SelectedIndex > 0) && (rcmb_PeriodElement.SelectedIndex > 0))
            {
                rcb_Transaction.Items.Clear();
                SMHR_PAYROLL _obj_smhr_payroll = new SMHR_PAYROLL();
                _obj_smhr_payroll.MODE = 22;
                _obj_smhr_payroll.PERIODDTLID = Convert.ToInt32(rcmb_PeriodElement.SelectedItem.Value);
                _obj_smhr_payroll.BUID = Convert.ToInt32(rcmb_BUI.SelectedItem.Value);
                DataTable dt = BLL.get_PayDetails(_obj_smhr_payroll);
                if (dt.Rows.Count != 0)
                {
                    //_obj_smhr_payroll = new SMHR_PAYROLL();
                    //_obj_smhr_payroll.MODE = 22;
                    //_obj_smhr_payroll.PERIODDTLID = Convert.ToInt32(rcmb_PeriodElement.SelectedItem.Value);
                    //_obj_smhr_payroll.BUID = Convert.ToInt32(rcmb_businessunit.SelectedItem.Value);
                    //DataTable dt = BLL.get_PayDetails(_obj_smhr_payroll);
                    rcb_Transaction.Items.Clear();
                    rcb_Transaction.DataSource = dt;
                    rcb_Transaction.DataTextField = "TEMP_PAYTRAN_NAME";
                    rcb_Transaction.DataValueField = "TEMP_PAYTRAN_ID";
                    rcb_Transaction.DataBind();
                    rcb_Transaction.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                    //RG_Transaction.Visible = false;
                    //btn_Rollback.Visible = false;
                }
                else
                {
                    //RG_Transaction.Visible = false;
                    //btn_Rollback.Visible = false;
                }
            }
            //else
            //{
            //    BLL.ShowMessage(this, "Select All Paramaters.");
            //    return;
            //}

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmPreApprovalPay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        try
        {
            if (rcmb_BUI.SelectedIndex < 0)
            {
                BLL.ShowMessage(this, "Please Select Business Unit");
                return;
            }
            else if (rcmb_PeriodMaster.SelectedIndex < 0)
            {
                BLL.ShowMessage(this, "Please Select Period");
                return;
            }
            else if (rcmb_PeriodElement.SelectedIndex < 0)
            {
                BLL.ShowMessage(this, "Please Select Period Element");
                return;
            }
            else if (rcb_Transaction.SelectedIndex < 0)
            {
                BLL.ShowMessage(this, "Please Select Transaction");
                return;
            }

            //DataTable dt_Local = BLL.ExecuteQuery("SELECT BUSINESSUNIT_LOCALISATION,HR_MASTER_CODE FROM SMHR_BUSINESSUNIT " +
            //                                          "  JOIN SMHR_HR_MASTER ON " +
            //                                          "  BUSINESSUNIT_LOCALISATION = HR_MASTER_ID WHERE BUSINESSUNIT_ID = '" + Convert.ToInt32(rcmb_BUI.SelectedValue) + "'");
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop_Pending('" + Convert.ToString(rcmb_PeriodMaster.SelectedValue)
            //    + "','" + Convert.ToString(Session["ORG_ID"]) + "','" + Convert.ToString(rcmb_BUI.SelectedValue)
            //    + "','" + Convert.ToInt32(rcmb_PeriodElement.SelectedValue) + "','" + Convert.ToInt32(rcb_Transaction.SelectedValue)
            //    + "','" + Convert.ToString(dt_Local.Rows[0]["HR_MASTER_CODE"]) + "');", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop_Pending('" + Convert.ToString(rcmb_PeriodMaster.SelectedValue)
                + "','" + Convert.ToString(Session["ORG_ID"]) + "','" + Convert.ToString(rcmb_BUI.SelectedValue)
                + "','" + Convert.ToInt32(rcmb_PeriodElement.SelectedValue) + "','" + Convert.ToInt32(rcb_Transaction.SelectedValue) + "');", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmPreApprovalPay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            rcmb_BUI.ClearSelection();
            rcmb_PeriodMaster.ClearSelection();
            rcmb_PeriodElement.Items.Clear();
            rcmb_PeriodElement.Text = string.Empty;
            rcb_Transaction.Items.Clear();
            rcb_Transaction.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmPreApprovalPay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}