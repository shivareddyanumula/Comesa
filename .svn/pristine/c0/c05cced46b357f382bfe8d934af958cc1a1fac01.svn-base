using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SMHR;
using System.Text;
using Telerik.Web.UI;

public partial class Masters_HrManagerLoan : System.Web.UI.Page
{
    //static string s = string.Empty;
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
            _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("HR MANAGER LOAN");
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
                //RadGrid1.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                btn_Save.Visible = false;
                btn_Cancel.Visible = false;
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "HrManagerLoan", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rg_HrMamager_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadData();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "HrManagerLoan", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadData()
    {
        try
        {
            SMHR_LOANREQUEST _obj_smhr_empcompoff = new SMHR_LOANREQUEST();
            _obj_smhr_empcompoff.OPERATION = operation.Check1;
            _obj_smhr_empcompoff.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_Loanstatus1(_obj_smhr_empcompoff);
            Rg_HrMamager.DataSource = dt;
            if (dt.Rows.Count != 0)
            {
                btn_Save.Visible = true;
                // btn_Cancel.Visible = true;
            }
            else
            {
                btn_Save.Visible = false;
                btn_Cancel.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "HrManagerLoan", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            string Status = string.Empty;
            SMHR_LOANREQUEST _obj_Smhr_Loan = new SMHR_LOANREQUEST();
            _obj_Smhr_Loan.OPERATION = operation.Update1;
            RadComboBox lblCode = new RadComboBox();
            Label lblid = new Label();
            RadComboBox lblCode1 = new RadComboBox();
            CheckBox chk_Open = new CheckBox();
            RadDatePicker lblMode = new RadDatePicker();
            for (int i = 0; i < Rg_HrMamager.Items.Count; i++)
            {
                lblid = Rg_HrMamager.Items[i].FindControl("Label1") as Label;
                lblCode = Rg_HrMamager.Items[i].FindControl("rcmb_Status") as RadComboBox;
                lblCode1 = Rg_HrMamager.Items[i].FindControl("rcmb_Loan") as RadComboBox;

                chk_Open = Rg_HrMamager.Items[i].FindControl("chkOpen") as CheckBox;
                if (chk_Open.Checked == true)
                {
                    _obj_Smhr_Loan.APPROVEDDATE = DateTime.Now;
                    _obj_Smhr_Loan.APPROVEDBY = Convert.ToInt32(Session["EMP_ID"]);
                    _obj_Smhr_Loan.SMHR_LOANREQUEST_ID = Convert.ToInt32(lblid.Text);
                    //if (lblCode.Text == "Approved")
                    //{
                    //    _obj_Smhr_Loan.STATUS = "B";
                    //}
                    //else if (lblCode.Text == "Declined")
                    //{
                    //    _obj_Smhr_Loan.STATUS = "D";
                    //}
                    _obj_Smhr_Loan.LoanMode = Convert.ToInt32(lblCode1.SelectedItem.Value);
                    if (lblCode1.SelectedItem.Value == "1")
                    {
                        Session["LOANTYPE"] = 1;
                    }
                    else
                    {
                        Session["LOANTYPE"] = 2;
                    }
                    _obj_Smhr_Loan.STATUS = Convert.ToInt32(lblCode.SelectedItem.Value);
                    _obj_Smhr_Loan.LEVEL2 = Convert.ToInt32(lblCode.SelectedItem.Value);
                    _obj_Smhr_Loan.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_Smhr_Loan.LASTMDFDATE = DateTime.Now;
                    if (BLL.set_HRLoanRequest(_obj_Smhr_Loan))
                        Status = "yes";
                    else
                        Status = "no";
                }

            }
            if (string.IsNullOrEmpty(Status))
            {
                BLL.ShowMessage(this, "Please Select atleast one");
                return;
            }
            if (Status == "yes")
            {
                BLL.ShowMessage(this, "Information Saved Successfully");
                LoadData();
                Rg_HrMamager.DataBind();
            }
            else
            {
                BLL.ShowMessage(this, "Information Not Saved");
                return;

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "HrManagerLoan", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_LOANREQUEST _obj_Smhr_Loan = new SMHR_LOANREQUEST();
            _obj_Smhr_Loan.OPERATION = operation.Select2;
            Label lblid = new Label();
            for (int i = 0; i < Rg_HrMamager.Items.Count; i++)
            {
                lblid = Rg_HrMamager.Items[i].FindControl("Label1") as Label;

            }
            if (lblid.Text != "")
            {
                _obj_Smhr_Loan.SMHR_LOANREQUEST_ID = Convert.ToInt32(lblid.Text);

            }

            DataTable dt = BLL.get_Loanstatus2(_obj_Smhr_Loan);
            int j = 0;
            if (dt.Rows.Count > 0)
            {
                j = Convert.ToInt32(dt.Rows[0]["LOANREQUESTSTATUS"]);


            }
            if (j == 1025)
            {
                BLL.ShowMessage(this, "You are not authoried to proceed");
                return;
            }
            else
            {
                if (Session["LOANTYPE"] != null)
                {
                    string str = "1";
                    if (str == Convert.ToString(Session["LOANTYPE"]))
                    {
                        Response.Redirect("~/Payroll/frm_EmpLoanTran.aspx");
                    }
                    else
                    {
                        Session["LOANTYPE"] = 2;
                        Response.Redirect("~/Payroll/frm_EmpReducingLoanTran.aspx");
                    }
                }


            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "HrManagerLoan", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void Rg_HrMamager_ItemDataBound(object sender, GridItemEventArgs e)
    {

    }
    protected void Rg_HrMamager_ItemDataBound1(object sender, GridItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                SMHR_LOANREQUEST _obj_Smhr_BusinessUnit = new SMHR_LOANREQUEST();
                _obj_Smhr_BusinessUnit.OPERATION = operation.Get;
                RadComboBox ddlAccount = (RadComboBox)e.Item.FindControl("rcmb_Status");
                ddlAccount.DataSource = BLL.get_EmployeeStatus1(_obj_Smhr_BusinessUnit);
                ddlAccount.DataTextField = "hr_master_desc";
                ddlAccount.DataValueField = "Hr_master_id";
                ddlAccount.DataBind();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "HrManagerLoan", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
