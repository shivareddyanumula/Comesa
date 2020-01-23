using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Data;
using Telerik.Web.UI;

public partial class Approval_frm_ExpenseApproval : System.Web.UI.Page
{
    SMHR_EXPENSE _obj_smhr_expense;
    DataTable dt_Details;
    int I_ChkCount = 0;
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("EXPENSE APPROVAL");
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
                    RG_ExpenseApproval.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Approve.Visible = false;
                    btn_Reject.Visible = false;
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


                rtxt_ReportingMgr.Text = Convert.ToString(Session["EMP_ID"]);
                RG_ExpenseApproval.Visible = true;
                rdp_ApprovalDate.SelectedDate = DateTime.Now;
                BLL.ChangeDateFormat(Convert.ToString(Session["EMP_ID"]), rdp_ApprovalDate);
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "function pageLoad(){ }", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ExpenseApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    //protected void lnk_Edit_Command(Object sender, CommandEventArgs e)
    //{
    //    string lbl_ID = Convert.ToString(e.CommandArgument);
    //    Response.Redirect("~/Payroll/frm_ExpenseTrans.aspx?ID=" + Convert.ToString(lbl_ID));
    //}

    private void LoadData()
    {
        try
        {
            _obj_smhr_expense = new SMHR_EXPENSE();
            _obj_smhr_expense.OPERATION = operation.Check;
            if (Session["EMP_ID"] != null)
                _obj_smhr_expense.EXPENSE_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            _obj_smhr_expense.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            RG_ExpenseApproval.DataSource = BLL.get_Expense(_obj_smhr_expense);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ExpenseApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Approve_Click(object sender, EventArgs e)
    {
        try
        {
            CheckBox chkBox = new CheckBox();
            Label lblID = new Label();
            Label lblExpId = new Label();
            string str = "";
            for (int index = 0; index <= RG_ExpenseApproval.Items.Count - 1; index++)
            {
                chkBox = RG_ExpenseApproval.Items[index].FindControl("chk_Choose") as CheckBox;
                lblID = RG_ExpenseApproval.Items[index].FindControl("lblexpID") as Label;
                lblExpId = RG_ExpenseApproval.Items[index].FindControl("lblExpdtl_Id") as Label;
                if (chkBox.Checked)
                {
                    I_ChkCount = I_ChkCount + 1;
                    if (str == "")
                        str = "" + lblID.Text + "";
                    else
                        str = str + "," + lblID.Text + "";

                    bool status = false;
                    _obj_smhr_expense = new SMHR_EXPENSE();
                    _obj_smhr_expense = new SMHR_EXPENSE();
                    _obj_smhr_expense.EXPENSE_STATUS = 1;
                    _obj_smhr_expense.EXPENSE_NAME = str;
                    _obj_smhr_expense.EXPENSE_APPROVEDBY = Convert.ToInt32(rtxt_ReportingMgr.Text);
                    _obj_smhr_expense.EXPENSE_APPROVEDDATE = Convert.ToDateTime(rdp_ApprovalDate.SelectedDate.Value);
                    _obj_smhr_expense.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_expense.LASTMDFDATE = DateTime.Now;
                    _obj_smhr_expense.OPERATION = operation.Chk;
                    _obj_smhr_expense.EXPDTL_ID = Convert.ToInt32(lblExpId.Text);
                    status = BLL.set_Expense(_obj_smhr_expense);
                    if (status == true)
                    {
                        BLL.ShowMessage(this, "Selected Expenses Approved");
                        LoadData();
                        RG_ExpenseApproval.DataBind();
                        return;
                    }
                }
            }
            if (I_ChkCount == 0)
            {
                BLL.ShowMessage(this, "Please Select Employees");
                return;
            }

            //if (string.IsNullOrEmpty(str))
            //{
            //    BLL.ShowMessage(this, "Please Select Employees");
            //    return;
            //}
            //bool status = false;
            //_obj_smhr_expense = new SMHR_EXPENSE();
            //_obj_smhr_expense = new SMHR_EXPENSE();
            //_obj_smhr_expense.EXPENSE_STATUS = 1;
            //_obj_smhr_expense.EXPENSE_NAME = str;
            //_obj_smhr_expense.EXPENSE_APPROVEDBY = Convert.ToInt32(rtxt_ReportingMgr.Text);
            //_obj_smhr_expense.EXPENSE_APPROVEDDATE = Convert.ToDateTime(rdp_ApprovalDate.SelectedDate.Value);
            //_obj_smhr_expense.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            //_obj_smhr_expense.LASTMDFDATE = DateTime.Now;
            //_obj_smhr_expense.OPERATION = operation.Update;

            //status = BLL.set_Expense(_obj_smhr_expense);
            //if (status == true)
            //{
            //    BLL.ShowMessage(this, "Selected Expenses Approved");
            //    LoadData();
            //    RG_ExpenseApproval.DataBind();
            //    //RG_ExpenseApproval.Visible = false;
            //    return;
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ExpenseApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Reject_Click(object sender, EventArgs e)
    {
        try
        {
            CheckBox chkBox = new CheckBox();
            Label lblID = new Label();
            int index;
            int i = 0;
            string str = "";
            for (index = 0; index <= RG_ExpenseApproval.Items.Count - 1; index++)
            {
                chkBox = RG_ExpenseApproval.Items[index].FindControl("chk_Choose") as CheckBox;
                lblID = RG_ExpenseApproval.Items[index].FindControl("lblexpID") as Label;
                if (chkBox.Checked)
                {
                    I_ChkCount = I_ChkCount + 1;
                    if (str == "")
                        str = "" + lblID.Text + "";
                    else
                        str = str + "," + lblID.Text + "";

                    bool status = false;
                    _obj_smhr_expense = new SMHR_EXPENSE();
                    _obj_smhr_expense.EXPENSE_STATUS = 2;
                    _obj_smhr_expense.EXPENSE_NAME = str;
                    _obj_smhr_expense.EXPENSE_APPROVEDBY = Convert.ToInt32(rtxt_ReportingMgr.Text);
                    _obj_smhr_expense.EXPENSE_APPROVEDDATE = Convert.ToDateTime(rdp_ApprovalDate.SelectedDate.Value);
                    _obj_smhr_expense.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_expense.LASTMDFDATE = DateTime.Now;
                    _obj_smhr_expense.OPERATION = operation.Update;
                    status = BLL.set_Expense(_obj_smhr_expense);
                    if (status == true)
                    {
                        BLL.ShowMessage(this, "Selected Expenses Rejected");
                        LoadData();
                        RG_ExpenseApproval.DataBind();
                        return;
                    }
                }
                else
                {
                    i = i + 1;
                }
            }
            if (I_ChkCount == 0)
            {
                BLL.ShowMessage(this, "Please Select Employees");
                return;
            }

            //if (i == RG_ExpenseApproval.Items.Count)
            //{
            //    BLL.ShowMessage(this, "Please Select Employees");
            //    return;
            //}
            //bool status = false;
            //_obj_smhr_expense = new SMHR_EXPENSE();
            //_obj_smhr_expense.EXPENSE_STATUS = 2;
            //_obj_smhr_expense.EXPENSE_NAME = str;
            //_obj_smhr_expense.EXPENSE_APPROVEDBY = Convert.ToInt32(rtxt_ReportingMgr.Text);
            //_obj_smhr_expense.EXPENSE_APPROVEDDATE = Convert.ToDateTime(rdp_ApprovalDate.SelectedDate.Value);
            //_obj_smhr_expense.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            //_obj_smhr_expense.LASTMDFDATE = DateTime.Now;
            //_obj_smhr_expense.OPERATION = operation.Update;
            //status = BLL.set_Expense(_obj_smhr_expense);
            //if (status == true)
            //{
            //    BLL.ShowMessage(this, "Selected Expenses Rejected");
            //    LoadData();
            //    RG_ExpenseApproval.DataBind();
            //    //RG_ExpenseApproval.Visible = false;
            //    return;
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ExpenseApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void RG_ExpenseApproval_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadData();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ExpenseApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    //{
    //    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "function pageLoad(){  ShowPopForm('" + Convert.ToString(e.CommandArgument) + "'); }", true);
    //}

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            //Response.Redirect("~/Masters/Default.aspx", false);
            //return; 
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ExpenseApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
