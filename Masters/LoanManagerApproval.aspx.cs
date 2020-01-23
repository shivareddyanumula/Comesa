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

public partial class Masters_LoanManagerApproval : System.Web.UI.Page
{
    static string s = "";
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Loan Manager Approval");//COUNTRY");
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
                    Rg_Mamager.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Save.Visible = false;
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
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanManagerApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            CheckBox chk_box1 = new CheckBox();

            int j = 0;

            for (int i = 0; i < Rg_Mamager.Items.Count; i++)
            {
                chk_box1 = Rg_Mamager.Items[i].FindControl("chk_Select") as CheckBox;

                if (chk_box1.Checked)
                {
                    j = j + 1;
                }

            }
            SMHR_LOANREQUEST _obj_Smhr_Loan = new SMHR_LOANREQUEST();
            _obj_Smhr_Loan.OPERATION = operation.Update;
            Label lbl_approveid = new Label();
            Label lbl_sanctionid = new Label();
            SMHR_LOANREQUEST _obj_Smhr_BusinessUnit = new SMHR_LOANREQUEST();
            _obj_Smhr_BusinessUnit.OPERATION = operation.New;
            //as we are getting the status of the loans by passing loanstatus id but not checking corresponding with organisation
            _obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_status = BLL.get_EmployeeStatus(_obj_Smhr_BusinessUnit);
            if (dt_status.Rows.Count > 0)
            {
                for (int i = 0; i < dt_status.Rows.Count; i++)
                {
                    if (Convert.ToString(dt_status.Rows[i]["hr_master_desc"]).Trim() == "Approved")
                    {
                        lbl_approveid.Text = Convert.ToString(dt_status.Rows[i]["hr_master_id"]);
                    }
                    else
                    {
                        lbl_sanctionid.Text = Convert.ToString(dt_status.Rows[i]["hr_master_id"]);
                    }
                }
            }
            RadComboBox lblCode = new RadComboBox();
            Label lblid = new Label();
            Label date = new Label();
            CheckBox chk_Open = new CheckBox();
            RadDatePicker lblMode = new RadDatePicker();
            int count = 0;
            for (int i = 0; i < Rg_Mamager.Items.Count; i++)
            {
                chk_Open = Rg_Mamager.Items[i].FindControl("chk_Select") as CheckBox;
                if (chk_Open.Checked == true)
                {
                    count++;
                }
            }
            if (count == 0)
            {
                BLL.ShowMessage(this, "Please Select atleast one Employee");
                return;
            }
            for (int i = 0; i < Rg_Mamager.Items.Count; i++)
            {
                lblid = Rg_Mamager.Items[i].FindControl("Label1") as Label;
                lblCode = Rg_Mamager.Items[i].FindControl("rcmb_Status") as RadComboBox;
                lblMode = Rg_Mamager.Items[i].FindControl("lbl_DPname") as RadDatePicker;
                chk_Open = Rg_Mamager.Items[i].FindControl("chk_Select") as CheckBox;
                if (chk_Open.Checked == true)
                {
                    date.Text = DateTime.Now.ToShortDateString();
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
                    _obj_Smhr_Loan.LOANNAME = Convert.ToString(Rg_Mamager.Items[i].Cells[7].Text).Replace("'", "''");
                    _obj_Smhr_Loan.STATUS = Convert.ToInt32(lblCode.SelectedItem.Value);
                    _obj_Smhr_Loan.LEVEL1 = Convert.ToInt32(lblCode.SelectedItem.Value);
                    _obj_Smhr_Loan.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_Smhr_Loan.LASTMDFDATE = DateTime.Now;
                    if (Convert.ToInt32(lbl_approveid.Text) == Convert.ToInt32(lblCode.SelectedItem.Value))
                    {
                        _obj_Smhr_Loan.OPERATION = operation.Update;
                    }
                    else
                    {
                        _obj_Smhr_Loan.OPERATION = operation.Update1;
                    }
                    if (BLL.set_LoanRequest(_obj_Smhr_Loan))
                    {
                        s = "yes";
                    }
                    else
                    {
                        s = "no";
                    }
                }
                //else
                //{
                //    //BLL.ShowMessage(this, "Please select Choose Option");
                //    //return;
                //    s = "no";
                //}

            }
            if (s == "yes")
            {
                BLL.ShowMessage(this, "Information Saved Sucessfully.");
                LoadData();
                Rg_Mamager.DataBind();
            }
            else
            {
                BLL.ShowMessage(this, "Error Occured While Saving Information.");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanManagerApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            bool status = Convert.ToBoolean(Session["checkRole"]);
            if (Session["DASHBOARD"] != null)
            {
                if (status == true)
                {

                    Response.Redirect("~/Security/frm_Dashboard.aspx", false);
                }
                else
                {

                    Response.Redirect("~/Security/frm_Dashboradmngr.aspx", false);
                }
            }
            else
            {
                Response.Redirect("~/Masters/Default.aspx", false);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanManagerApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void Rg_Mamager_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadData();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanManagerApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rg_Mamager_ItemCreated(object sender, GridItemEventArgs e)
    {
        //if (e.Item is GridCommandItem)
        //    {
        //        GridCommandItem commandItem = e.Item
        //            as GridCommandItem;
        //        LinkButton button = commandItem.FindControl("lnk_Add") as LinkButton;
        //        button.Visible = false;
        //    }

    }
    private void LoadData()
    {
        try
        {
            SMHR_LOANREQUEST _obj_smhr_empcompoff = new SMHR_LOANREQUEST();
            _obj_smhr_empcompoff.OPERATION = operation.Delete;
            _obj_smhr_empcompoff.lOANREQUEST_EMPLOYEEID = Convert.ToInt32(Session["EMP_ID"]);
            _obj_smhr_empcompoff.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_Loanstatus(_obj_smhr_empcompoff);
            Rg_Mamager.DataSource = dt;
            if (dt.Rows.Count != 0)
            {
                btn_Save.Visible = true;
                btn_Cancel.Visible = true;
            }
            else
            {
                btn_Save.Visible = false;
                btn_Cancel.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanManagerApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Proceed_Click(object sender, EventArgs e)
    {

    }
    protected void Rg_Mamager_ItemDataBound(object sender, GridItemEventArgs e)
    {
        try
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                Label lblIsEnabled = item.FindControl("lblIsEnabled") as Label;
                CheckBox chk_Select = item.FindControl("chk_Select") as CheckBox;

                if (lblIsEnabled.Text != "")
                {
                    int isEnabled = Convert.ToInt32((item.FindControl("lblIsEnabled") as Label).Text);
                    chk_Select.Enabled = Convert.ToBoolean(isEnabled);

                }
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                SMHR_LOANREQUEST _obj_Smhr_BusinessUnit = new SMHR_LOANREQUEST();
                _obj_Smhr_BusinessUnit.OPERATION = operation.New;
                //as we are getting the status of the loans by passing loanstatus id but not checking corresponding with organisation
                _obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                RadComboBox ddlAccount = (RadComboBox)e.Item.FindControl("rcmb_Status");
                ddlAccount.DataSource = BLL.get_EmployeeStatus(_obj_Smhr_BusinessUnit);
                ddlAccount.DataTextField = "hr_master_desc";
                ddlAccount.DataValueField = "Hr_master_id";
                ddlAccount.DataBind();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanManagerApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

        }
    }
    protected void Rg_Mamager_DataBinding(object sender, EventArgs e)
    {

    }
    protected void lnkVoucher_OnCommand(object sender, CommandEventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToString(e.CommandArgument) + "');", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanManagerApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void chk_selectall_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < Rg_Mamager.Items.Count; i++)
            {
                CheckBox Chk_All = (CheckBox)sender;
                if (Chk_All.Checked)
                {
                    for (int index = 0; index < Rg_Mamager.Items.Count; index++)
                    {
                        CheckBox c = (CheckBox)Rg_Mamager.Items[index].FindControl("chk_Select");
                        c.Checked = true; ;
                    }
                }
                else
                {
                    for (int index = 0; index < Rg_Mamager.Items.Count; index++)
                    {
                        CheckBox c = (CheckBox)Rg_Mamager.Items[index].FindControl("chk_Select");
                        c.Checked = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanManagerApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}