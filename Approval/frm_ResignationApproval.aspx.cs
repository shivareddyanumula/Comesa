using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Data;
using Telerik.Web.UI;

public partial class Approval_frm_ResignationApproval : System.Web.UI.Page
{
    SMHR_EMPRESIGNATION _obj_smhr_Resg;

    DataTable dt_details;

    protected override void InitializeCulture()
    {
        if (!Page.IsPostBack)
        {
            BLL.SetCulture_Theme(Page, Request);
            base.InitializeCulture();
        }
    }

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
            _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("RESIGNATION APPROVAL");
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
                RG_ResgApproval.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
            RG_ResgApproval.Visible = true;
            rdp_ApprovalDate.SelectedDate = DateTime.Now;
            LoadData();
            BLL.ChangeDateFormat(Convert.ToString(Session["EMP_ID"]), rdp_ApprovalDate);
        }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ResignationApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadData()
    {
        try
        {
            _obj_smhr_Resg = new SMHR_EMPRESIGNATION();
            //_obj_smhr_Resg.OPERATION = operation.Empty;
            _obj_smhr_Resg.OPERATION = operation.Check1;
            _obj_smhr_Resg.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_Resg.EMPREG_EMP_ID = Convert.ToInt32(rtxt_ReportingMgr.Text);
            _obj_smhr_Resg.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            //if ((_obj_smhr_Resg.EMPREG_EMP_ID == 0) || (_obj_smhr_Resg.EMPREG_EMP_ID == -1))
            //{
            //    chkSelectAll.Visible = false;
            //    BLL.ShowMessage(this, "Admin or Superadmin does not have resignation approval");
            //}
            //else
            //{
            dt_details = new DataTable();

            dt_details = BLL.get_Empresignation(_obj_smhr_Resg);
            RG_ResgApproval.DataSource = dt_details;
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ResignationApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Approve_Click(object sender, EventArgs e)
    {
        try
        {
            CheckBox chkBox = new CheckBox();
            Label lblID = new Label();
            string str = "";
            for (int index = 0; index <= RG_ResgApproval.Items.Count - 1; index++)
            {
                chkBox = RG_ResgApproval.Items[index].FindControl("chk_Choose") as CheckBox;
                lblID = RG_ResgApproval.Items[index].FindControl("lblresgID") as Label;
                if (chkBox.Checked)
                {
                    if (str == "")
                        str = "" + lblID.Text + "";
                    else
                        str = str + "," + lblID.Text + "";
                }
            }

            if (string.IsNullOrEmpty(str))
            {
                BLL.ShowMessage(this, "Please Select Employees");
                return;
            }
            bool status = false;
            _obj_smhr_Resg = new SMHR_EMPRESIGNATION();

            _obj_smhr_Resg.EMPREG_STATUS = 1;
            _obj_smhr_Resg.EMPREG_REMARKS = str;
            _obj_smhr_Resg.EMPREG_APPROVEDBY = Convert.ToInt32(rtxt_ReportingMgr.Text);
            _obj_smhr_Resg.EMPREG_APPROVEDDATE = Convert.ToDateTime(rdp_ApprovalDate.SelectedDate.Value);
            _obj_smhr_Resg.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_Resg.LASTMDFDATE = DateTime.Now;
            _obj_smhr_Resg.OPERATION = operation.Update;
            status = BLL.set_Empresignation(_obj_smhr_Resg);
            if (status == true)
            {
                BLL.ShowMessage(this, "Selected Employee Resignations Approved");
                LoadData();
                RG_ResgApproval.DataBind();
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ResignationApproval", ex.StackTrace, DateTime.Now);
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
            for (index = 0; index <= RG_ResgApproval.Items.Count - 1; index++)
            {
                chkBox = RG_ResgApproval.Items[index].FindControl("chk_Choose") as CheckBox;
                lblID = RG_ResgApproval.Items[index].FindControl("lblresgID") as Label;
                if (chkBox.Checked)
                {
                    if (str == "")
                        str = "" + lblID.Text + "";
                    else
                        str = str + "," + lblID.Text + "";
                }
                else
                {
                    i = i + 1;
                }
            }

            if (i == RG_ResgApproval.Items.Count)
            {
                BLL.ShowMessage(this, "Please Select Employees");
                return;
            }
            bool status = false;
            _obj_smhr_Resg = new SMHR_EMPRESIGNATION();
            _obj_smhr_Resg.EMPREG_STATUS = 2;
            _obj_smhr_Resg.EMPREG_REMARKS = str;
            _obj_smhr_Resg.EMPREG_APPROVEDBY = Convert.ToInt32(rtxt_ReportingMgr.Text);
            _obj_smhr_Resg.EMPREG_APPROVEDDATE = Convert.ToDateTime(rdp_ApprovalDate.SelectedDate.Value);
            _obj_smhr_Resg.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_Resg.LASTMDFDATE = DateTime.Now;
            _obj_smhr_Resg.OPERATION = operation.Update;
            status = BLL.set_Empresignation(_obj_smhr_Resg);
            if (status == true)
            {
                BLL.ShowMessage(this, "Selected Employee Resignations  Rejected");
                LoadData();
                RG_ResgApproval.DataBind();
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ResignationApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Refresh_Click(object sender, EventArgs e)
    {
        try
        {
            LoadData();
            RG_ResgApproval.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ResignationApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void RG_ResgApproval_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadData();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ResignationApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["DASHBOARD"] != null)
            {
                Response.Redirect("~/Security/frm_Dashboradmngr.aspx", false);
            }
            else
            {
                Response.Redirect("~/Masters/Default.aspx", false);
            }
            return;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ResignationApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkSelectAll.Checked)
            {
                CheckBox chk = new CheckBox();
                for (int iChkCount = 0; iChkCount < RG_ResgApproval.Items.Count; iChkCount++)
                {
                    chk = RG_ResgApproval.Items[iChkCount].FindControl("chk_Choose") as CheckBox;
                    chk.Checked = true;
                }
            }
            else
            {
                CheckBox chk = new CheckBox();
                for (int iChkCount = 0; iChkCount < RG_ResgApproval.Items.Count; iChkCount++)
                {
                    chk = RG_ResgApproval.Items[iChkCount].FindControl("chk_Choose") as CheckBox;
                    chk.Checked = false;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ResignationApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}