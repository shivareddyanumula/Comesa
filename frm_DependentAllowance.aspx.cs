using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;


public partial class frm_DependentAllowance : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Session.Remove("WRITEFACILITY");

            SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

            _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
            _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
            _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Mapping Vote Codes");//TRAINING APPROVAL");
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
                //RG_TrainingApproval.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
            LoadPeriod();
        }
    }
    private void LoadPeriod()
    {
        try
        {
            rcmb_FromPeriod.Items.Clear();
            SMHR_PERIOD PRD = new SMHR_PERIOD();
            PRD.OPERATION = operation.PERIOD;
            PRD.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT = new DataTable();
            DT = BLL.GetEmployeePeriod(PRD);
            
            if (DT.Rows.Count > 0)
            {
                rcmb_FromPeriod.DataSource = DT;
                rcmb_FromPeriod.DataTextField = "PERIOD_NAME";
                rcmb_FromPeriod.DataValueField = "PERIOD_ID";
                rcmb_FromPeriod.DataBind();
            }
            rcmb_FromPeriod.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Allowance", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_FromPeriod_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_FromPeriod.SelectedIndex > 0)
            {
                RG_Allowance.Visible = true;
                btn_submit.Visible = true;
                btn_Cancel.Visible = true;
                SMHR_ALLOWANCE _obj_smhr_allowance = new SMHR_ALLOWANCE();
                _obj_smhr_allowance.OPERATION = operation.Get;
                _obj_smhr_allowance.ALLOWANCE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_smhr_allowance.ALLOWANCE_PERIOD_ID = Convert.ToInt32(rcmb_FromPeriod.SelectedValue);
                DataTable DT = new DataTable();
                DT = BLL.GET_ALLOWANCE(_obj_smhr_allowance);
                RG_Allowance.DataSource = DT;
                RG_Allowance.DataBind();

            }
            else
            {
                rcmb_FromPeriod.SelectedIndex = 0;
                BLL.ShowMessage(this, "Please Select Financial Period");
                return;
            }


        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Allowance", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    private DataTable GetAllowance(out string errorMsg)
    {
        errorMsg = string.Empty;
        DataTable dt = GetGridAllowance();
        try
        {
            RadTextBox txtDependent, txtEligible;
            SMHR_ALLOWANCE _obj_allowance = new SMHR_ALLOWANCE();
            _obj_allowance.OPERATION = operation.Select;
            _obj_allowance.ALLOWANCE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtallowance = BLL.GET_ALLOWANCE(_obj_allowance);
            foreach (GridDataItem d in RG_Allowance.Items)
            {

                txtDependent = new RadTextBox();

                txtDependent = d.FindControl("txtDependent") as RadTextBox;

                txtEligible = new RadTextBox();
                txtEligible = d.FindControl("txtEligible") as RadTextBox;
                dt.Rows.Add(Convert.ToInt32(Session["ORG_ID"]), Convert.ToInt32(rcmb_FromPeriod.SelectedValue), Convert.ToInt32(d.Cells[2].Text), txtDependent.Text, txtEligible.Text);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Allowance", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return dt;
    }
    private DataTable GetGridAllowance()
    {
        DataTable dt = new DataTable();
        try
        {
            dt.Columns.Add("ALLOWANCE_ORG_ID", typeof(int));
            dt.Columns.Add("ALLOWANCE_PERIOD_ID", typeof(int));
            dt.Columns.Add("ALLOWANCE_EMPLOYEEGRADE_ID", typeof(int));
            dt.Columns.Add("ALLOWANCE_DEPENDENT", typeof(int));
            dt.Columns.Add("ALLOWANCE_ELIGIBLE", typeof(int));


        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Allowance", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return dt;
    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        try
        {
            if (rcmb_FromPeriod.SelectedIndex <= 0)
            {
                BLL.ShowMessage(this, "Please Select Financial Period");
                return;
            }

            string errorMsg = string.Empty;
            DataTable dtallowance = GetAllowance(out errorMsg);
            if (!string.IsNullOrEmpty(errorMsg))
            {
                BLL.ShowMessage(this, errorMsg);
                return;
            }
            SMHR_ALLOWANCE all = new SMHR_ALLOWANCE();
            all.ALLOWANCE_GRIDDATA = dtallowance;
            all.ALLOWANCE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            all.ALLOWANCE_PERIOD_ID = Convert.ToInt32(rcmb_FromPeriod.SelectedValue);
            all.ALLOWANCE_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            all.ALLOWANCE_CREATEDDATE = DateTime.Now;
            all.ALLOWANCE_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            all.ALLOWANCE_LASTMDFDATE = DateTime.Now;
            switch (((Button)sender).Text.ToUpper())
            {

                case "SAVE":
                    all.OPERATION = operation.Insert;
                    if (BLL.Set_Allowance(all))
                    {
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    }
                    else

                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                default:
                    break;
            }
            rcmb_FromPeriod.ClearSelection();
            rcmb_FromPeriod.Text = string.Empty;
            RG_Allowance.Visible = false;
            btn_submit.Visible = false;
            btn_Cancel.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Allowance", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            RG_Allowance.Visible = false;
            btn_submit.Visible = false;
            btn_Cancel.Visible = false;
            rcmb_FromPeriod.SelectedIndex = -1;

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Allowance", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}