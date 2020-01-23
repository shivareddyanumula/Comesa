using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SPMS;
using SMHR;
using Telerik.Web.UI;

public partial class PMS_frm_KRAApprove : System.Web.UI.Page
{
    pms_kraform _obj_kra;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();
                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("KRA Approval");
                DataTable dtformdtls = BLL.get_LoginInfo(_obj_Smhr_LoginInfo);
                if (dtformdtls.Rows.Count > 0)
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
                    RG_kraform.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Approve.Visible = false;
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
                LoadGrid();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_KRAApprove", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadGrid()
    {
        try
        {
            _obj_kra = new pms_kraform();
            _obj_kra.KRA_MODE = 9;
            _obj_kra.KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_kra.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt = Pms_Bll.get_kra(_obj_kra);
            RG_kraform.DataSource = dt;
            RG_kraform.DataBind();
            if (RG_kraform.Items.Count > 0)
            {
                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 1)
                    tr_btns.Visible = true;
                else
                    tr_btns.Visible = false;
            }
            else
            {
                tr_btns.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_KRAApprove", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void chk_selectall_checkedchanged(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < RG_kraform.Items.Count; i++)
            {
                CheckBox Chk_All = (CheckBox)sender;
                if (Chk_All.Checked)
                {
                    for (int index = 0; index < RG_kraform.Items.Count; index++)
                    {
                        CheckBox c = (CheckBox)RG_kraform.Items[index].FindControl("chckbtn_Select");
                        if (c.Enabled)
                            c.Checked = true;
                        else
                            c.Checked = false;
                    }
                }
                else
                {
                    for (int index = 0; index < RG_kraform.Items.Count; index++)
                    {
                        CheckBox c = (CheckBox)RG_kraform.Items[index].FindControl("chckbtn_Select");
                        c.Checked = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_KRAApprove", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Approve_Click(object sender, EventArgs e)
    {
        try
        {
            bool status = false;
            int count = 0;
            for (int index = 0; index < RG_kraform.Items.Count; index++)
            {
                CheckBox chk = (CheckBox)RG_kraform.Items[index].FindControl("chckbtn_Select");
                if (chk.Checked)
                {
                    count++;
                    _obj_kra = new pms_kraform();
                    _obj_kra.KRA_ID = Convert.ToInt32(Convert.ToString(RG_kraform.Items[index]["KRA_ID"].Text));
                    _obj_kra.KRA_STATUS = 1;
                    _obj_kra.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_kra.KRA_MODE = 10;
                    status = Pms_Bll.set_kra(_obj_kra);
                }
            }
            if (count == 0)
            {
                BLL.ShowMessage(this, "Please Select atleast one KRA to Approve.");
                return;
            }
            if (status)
            {
                BLL.ShowMessage(this, "Selected KRA Approved Successfully.");
                LoadGrid();
                return;
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_KRAApprove", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Reject_Click(object sender, EventArgs e)
    {
        try
        {
            bool status = false;
            int count = 0;
            for (int index = 0; index < RG_kraform.Items.Count; index++)
            {
                CheckBox chk = (CheckBox)RG_kraform.Items[index].FindControl("chckbtn_Select");
                if (chk.Checked)
                {
                    count++;
                    _obj_kra = new pms_kraform();
                    _obj_kra.KRA_ID = Convert.ToInt32(Convert.ToString(RG_kraform.Items[index]["KRA_ID"].Text));
                    _obj_kra.KRA_STATUS = 2;
                    _obj_kra.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_kra.KRA_MODE = 10;
                    status = Pms_Bll.set_kra(_obj_kra);
                }
            }
            if (count == 0)
            {
                BLL.ShowMessage(this, "Please Select atleast one KRA to Reject.");
                return;
            }
            if (status)
            {
                BLL.ShowMessage(this, "Selected KRA Rejected Successfully.");
                LoadGrid();
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_KRAApprove", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
