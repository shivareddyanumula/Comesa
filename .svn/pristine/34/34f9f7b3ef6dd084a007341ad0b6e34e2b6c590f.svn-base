using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SMHR;
using System.Data;

public partial class Approval_frmEmpPayElmntsApproval : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                LoadGrid();
                rgEmpPayElmntsApproval.DataBind();

                if (rgEmpPayElmntsApproval.Items.Count == 0)
                    btnApprove.Visible = btnReject.Visible = rgEmpPayElmntsApproval.MasterTableView.Columns[0].Visible = false;
                else
                    btnApprove.Visible = btnReject.Visible = rgEmpPayElmntsApproval.MasterTableView.Columns[0].Visible = true;

                //Code for Security Privileges
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Pay Elements Approval");

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
                    btnApprove.Visible = btnReject.Visible = false;
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEmpPayElmntsApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /// <summary>
    /// To Load the Grid Data
    /// </summary>
    protected void LoadGrid()
    {
        try
        {
            rgEmpPayElmntsApproval.DataSource = BLL.GetEmpPayElmntsData(Convert.ToInt32(rblStatus.SelectedValue));

            if (rgEmpPayElmntsApproval.Items.Count == 0)
                btnApprove.Visible = btnReject.Visible = rgEmpPayElmntsApproval.MasterTableView.Columns[0].Visible = false;
            else
                btnApprove.Visible = btnReject.Visible = rgEmpPayElmntsApproval.MasterTableView.Columns[0].Visible = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEmpPayElmntsApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /// <summary>
    /// On Need data source of Rad Grid
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void rgEmpPayElmntsApproval_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();

            rgEmpPayElmntsApproval.MasterTableView.Columns[0].Visible = true;

            if (rblStatus.SelectedValue == "0")     //for Submit Status
            {
                if (rgEmpPayElmntsApproval.Items.Count > 0)
                    btnApprove.Visible = btnReject.Visible = true;
                else
                    btnApprove.Visible = btnReject.Visible = false;
            }
            else if (rblStatus.SelectedValue == "1")//for Approve Status
            {
                if (rgEmpPayElmntsApproval.Items.Count > 0)
                    btnReject.Visible = true;
                else
                    btnReject.Visible = false;

                btnApprove.Visible = false;
            }
            else                                    //for Reject Status
            {
                rgEmpPayElmntsApproval.MasterTableView.Columns[0].Visible = false;
                btnApprove.Visible = btnReject.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEmpPayElmntsApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /// <summary>
    /// To Check all the available records to be checked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox chkAll = (CheckBox)sender;
            CheckBox chk;

            for (int i = 0; i < rgEmpPayElmntsApproval.Items.Count; i++)
            {
                chk = rgEmpPayElmntsApproval.Items[i].FindControl("chk") as CheckBox;

                if (chkAll.Checked)
                    chk.Checked = true;
                else
                    chk.Checked = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEmpPayElmntsApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /// <summary>
    /// Status Changed Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rblStatus_TextChanged(object sender, EventArgs e)
    {
        try
        {
            LoadGrid();
            rgEmpPayElmntsApproval.DataBind();

            rgEmpPayElmntsApproval.MasterTableView.Columns[5].Visible = true;

            if (rblStatus.SelectedValue == "0")     //for Submit Status
            {
                if (rgEmpPayElmntsApproval.Items.Count > 0)
                    btnApprove.Visible = btnReject.Visible = rgEmpPayElmntsApproval.MasterTableView.Columns[0].Visible = true;
                else
                    btnApprove.Visible = btnReject.Visible = rgEmpPayElmntsApproval.MasterTableView.Columns[0].Visible = false;
            }
            else if (rblStatus.SelectedValue == "1")//for Approve Status
            {
                if (rgEmpPayElmntsApproval.Items.Count > 0)
                    btnReject.Visible = rgEmpPayElmntsApproval.MasterTableView.Columns[0].Visible = true;
                else
                    btnReject.Visible = rgEmpPayElmntsApproval.MasterTableView.Columns[0].Visible = false;

                btnApprove.Visible = false;
            }
            else                                    //for Reject Status
            {
                btnApprove.Visible = btnReject.Visible = false;
                rgEmpPayElmntsApproval.MasterTableView.Columns[0].Visible = rgEmpPayElmntsApproval.MasterTableView.Columns[5].Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEmpPayElmntsApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /// <summary>
    /// Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_Click(object sender, EventArgs e)
    {
        try
        {
            int chkCnt = 0;
            int mode = 0;

            string ids = string.Empty;

            CheckBox chk;
            Label lblID;

            for (int i = 0; i < rgEmpPayElmntsApproval.Items.Count; i++)
            {
                chk = rgEmpPayElmntsApproval.Items[i].FindControl("chk") as CheckBox;

                if (chk.Checked)
                    chkCnt++;
            }

            if (chkCnt == 0)
            {
                BLL.ShowMessage(this, "Please check at least one record before clicking the button..!");
                return;
            }
            else
            {
                for (int i = 0; i < rgEmpPayElmntsApproval.Items.Count; i++)
                {
                    chk = rgEmpPayElmntsApproval.Items[i].FindControl("chk") as CheckBox;
                    lblID = rgEmpPayElmntsApproval.Items[i].FindControl("lblID") as Label;

                    if (chk.Checked)
                        ids = ids + lblID.Text + ",";
                }

                if (ids != string.Empty)
                {
                    ids = ids.Remove(ids.Length - 1);

                    if ((((Button)sender).ID.ToUpper()) == "BTNAPPROVE")    //to Approve the records
                        mode = 4;
                    if ((((Button)sender).ID.ToUpper()) == "BTNREJECT")     //to Reject the records
                        mode = 5;

                    BLL.SetEmpPayElmntsData(mode, ids,Convert.ToInt32(Session["USER_ID"]));

                    if (mode == 4)
                        BLL.ShowMessage(this, "Selected record(s) Approved successfully..!");
                    if (mode == 5)
                        BLL.ShowMessage(this, "Selected record(s) Rejected successfully..!");

                    LoadGrid();
                    rgEmpPayElmntsApproval.DataBind();

                    if (rblStatus.SelectedValue == "0")     //for Submit Status
                    {
                        if (rgEmpPayElmntsApproval.Items.Count > 0)
                            btnApprove.Visible = btnReject.Visible = rgEmpPayElmntsApproval.MasterTableView.Columns[0].Visible = true;
                        else
                            btnApprove.Visible = btnReject.Visible = rgEmpPayElmntsApproval.MasterTableView.Columns[0].Visible = false;
                    }
                    else if (rblStatus.SelectedValue == "1")//for Approve Status
                    {
                        if (rgEmpPayElmntsApproval.Items.Count > 0)
                            btnReject.Visible = rgEmpPayElmntsApproval.MasterTableView.Columns[0].Visible = true;
                        else
                            btnReject.Visible = rgEmpPayElmntsApproval.MasterTableView.Columns[0].Visible = false;

                        btnApprove.Visible = false;
                    }
                    else                                    //for Reject Status
                        btnApprove.Visible = btnReject.Visible = rgEmpPayElmntsApproval.MasterTableView.Columns[0].Visible = false;
                }
                else
                    BLL.ShowMessage(this, "Gotta error., records does not processed successfully..!");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEmpPayElmntsApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}