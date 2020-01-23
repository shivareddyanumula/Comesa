using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Data;
using Telerik.Web.UI;
using System.Globalization;

public partial class Approval_frm_CompOffApproval : System.Web.UI.Page
{
    SMHR_EMPCOMOFF _obj_smhr_empcompoff;
    DataTable dt_Details;

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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Compensatory Off Approval");//COMP_APPROVAL");
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
                    RG_CompoffApproval.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
                RG_CompoffApproval.Visible = true;
                // DateTime str =Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy"));
                //  string str = DateTime.Today.ToString("MM-dd-yyyy", CultureInfo.CreateSpecificCulture("en-US"));


                // string sDate = DateTime.Now.ToString();  
                // DateTime dDate=new DateTime(); 

                ////rdp_ApprovalDate.SelectedDate = DateTime.Now;
                // DateTime sDate = dDate.ToString("MM/dd/yyyy");

                rdp_ApprovalDate.SelectedDate = DateTime.Now;
                // BLL.ChangeDateFormat(Convert.ToString(Session["EMP_ID"]), rdp_ApprovalDate);
                //rdp_ApprovalDate.SelectedDate =Convert.ToDateTime(DateTime.Today.ToString("MM/dd/yyyy"));
            }




        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CompOffApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "function pageLoad(){ }", true);
    }
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    private void LoadData()
    {
        try
        {
            _obj_smhr_empcompoff = new SMHR_EMPCOMOFF();
            _obj_smhr_empcompoff.OPERATION = operation.Check;
            if (Session["EMP_ID"] != null)
                _obj_smhr_empcompoff.EMPCOMPOFF_EMPID = Convert.ToInt32(Session["EMP_ID"]);
            _obj_smhr_empcompoff.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            RG_CompoffApproval.DataSource = BLL.get_empcompffs(_obj_smhr_empcompoff);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CompOffApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Approve_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_LEAVEBALANCE _obj_smhr_leavebal = new SMHR_LEAVEBALANCE();
            CheckBox chkBox = new CheckBox();
            Label lblid = new Label();
            Label lblempid = new Label();
            Label lblleave = new Label();
            TextBox txt = new TextBox();
            string str = "";
            string str1 = "";
            for (int index = 0; index <= RG_CompoffApproval.Items.Count - 1; index++)
            {
                chkBox = RG_CompoffApproval.Items[index].FindControl("chk_choose") as CheckBox;
                lblid = RG_CompoffApproval.Items[index].FindControl("lblCompoffID") as Label;
                lblempid = RG_CompoffApproval.Items[index].FindControl("lblEMPID") as Label;
                txt = RG_CompoffApproval.Items[index].FindControl("txt_AppRemarks") as TextBox;
                if (chkBox.Checked)
                {
                    if (str == "")
                        str = "" + lblid.Text + "";
                    else
                        str = str + "," + lblid.Text + "";

                    if (str1 == "")
                        str1 = "" + lblempid.Text + "";
                    else
                        str1 = str1 + "," + lblempid.Text + "";

                }

            }

            if (string.IsNullOrEmpty(str))
            {
                BLL.ShowMessage(this, "please select employees");
                return;
            }
            bool status = false;
            _obj_smhr_empcompoff = new SMHR_EMPCOMOFF();
            //_obj_smhr_empcompoff.EMPNAME = str1;
            _obj_smhr_empcompoff.EMPCOMPOFF_STATUS = 1;
            _obj_smhr_empcompoff.EMPCOMPOFF_REASON = str;
            _obj_smhr_empcompoff.EMPCOMPOFF_APPROVEDBY = Convert.ToInt32(rtxt_ReportingMgr.Text);

            //string[] strSpilt = (rdp_ApprovalDate.SelectedDate).ToString().Split('/');
            //_obj_smhr_empcompoff.EMPCOMPOFF_APPROVEDDATE = Convert.ToDateTime(strSpilt[1] + "/" + strSpilt[0] + "/" + strSpilt[2]);        
            _obj_smhr_empcompoff.EMPCOMPOFF_APPROVEDDATE = Convert.ToDateTime(rdp_ApprovalDate.SelectedDate.Value);
            _obj_smhr_empcompoff.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            if (txt.Text != string.Empty)
            {
                _obj_smhr_empcompoff.EMPCOMPOFF_APPROVALREMARKS = "a";
            }
            else
                _obj_smhr_empcompoff.EMPCOMPOFF_APPROVALREMARKS = null;
            _obj_smhr_empcompoff.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_empcompoff.LASTMDFDATE = DateTime.Now;
            _obj_smhr_empcompoff.OPERATION = operation.Update1;
            status = BLL.set_empcompoffs(_obj_smhr_empcompoff);
            if (status == true)
            {
                bool rs = false;
                for (int index = 0; index <= RG_CompoffApproval.Items.Count - 1; index++)
                {
                    chkBox = RG_CompoffApproval.Items[index].FindControl("chk_choose") as CheckBox;
                    if (chkBox.Checked)
                    {
                        lblid = RG_CompoffApproval.Items[index].FindControl("lblCompoffID") as Label;
                        lblempid = RG_CompoffApproval.Items[index].FindControl("lblEMPID") as Label;
                        lblleave = RG_CompoffApproval.Items[index].FindControl("lblleavetype") as Label;
                        _obj_smhr_leavebal.OPERATION = operation.Update;
                        _obj_smhr_leavebal.EMPNAME = lblempid.Text;
                        _obj_smhr_leavebal.MODE = 4;
                        _obj_smhr_leavebal.LT_LEAVETYPEID = Convert.ToInt32(lblleave.Text);
                        rs = BLL.set_leavebalances(_obj_smhr_leavebal);
                    }

                }
                if (rs == true)
                {
                    BLL.ShowMessage(this, "Selected Compoffs approved and Leave Balance Updated");
                    LoadData();
                    RG_CompoffApproval.DataBind();
                    return;
                }
                //_obj_smhr_leavebal.OPERATION = operation.Update;
                //_obj_smhr_leavebal.EMPNAME = str1;
                //_obj_smhr_leavebal.MODE = 4;
                //SMHR_LEAVEMASTER _obj_smhr_leavemaster = new SMHR_LEAVEMASTER();
                //_obj_smhr_leavemaster.OPERATION = operation.Empty;
                //_obj_smhr_leavemaster.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //DataTable dtid = new DataTable();
                //dtid = BLL.get_LeaveMaster(_obj_smhr_leavemaster);
                //if (dtid.Rows.Count > 0)
                //{
                //    _obj_smhr_leavebal.LT_LEAVETYPEID = Convert.ToInt32(dtid.Rows[0]["LEAVEMASTER_ID"]);
                //    bool rs = BLL.set_leavebalances(_obj_smhr_leavebal);
                //    BLL.ShowMessage(this, "selected Compoffs approved and Leave Balance Updated");
                //    LoadData();
                //    RG_CompoffApproval.DataBind();
                //    return;
                //}


                //else 
                //{
                //    BLL.ShowMessage(this,"Please select allow Comp-off check in either of the leaves in Leave Master screen");
                //}


            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CompOffApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Reject_Click(object sender, EventArgs e)
    {

        try
        {
            CheckBox chkBox = new CheckBox();
            Label lblid = new Label();
            TextBox txt = new TextBox();
            string str = "";
            for (int index = 0; index <= RG_CompoffApproval.Items.Count - 1; index++)
            {
                chkBox = RG_CompoffApproval.Items[index].FindControl("chk_choose") as CheckBox;
                lblid = RG_CompoffApproval.Items[index].FindControl("lblCompoffID") as Label;
                txt = RG_CompoffApproval.Items[index].FindControl("txt_AppRemarks") as TextBox;
                if (chkBox.Checked)
                {
                    if (str == "")
                        str = "" + lblid.Text + "";
                    else
                        str = str + "," + lblid.Text + "";
                }
            }

            if (string.IsNullOrEmpty(str))
            {
                BLL.ShowMessage(this, "Please select employees");
                return;
            }
            bool status = false;
            _obj_smhr_empcompoff = new SMHR_EMPCOMOFF();
            _obj_smhr_empcompoff.EMPCOMPOFF_EMPID = Convert.ToInt32(Session["EMP_ID"]);
            _obj_smhr_empcompoff.EMPCOMPOFF_STATUS = 2;
            _obj_smhr_empcompoff.EMPCOMPOFF_REASON = str;
            _obj_smhr_empcompoff.EMPCOMPOFF_APPROVEDBY = Convert.ToInt32(rtxt_ReportingMgr.Text);

            //string[] strSpilt = lblDOB.Text.Split('/');
            //lblDOB.Text = strSpilt[1] + "/" + strSpilt[0] + "/" + strSpilt[2];
            //txt_FDOB.SelectedDate = Convert.ToDateTime(lblDOB.Text);
            _obj_smhr_empcompoff.EMPCOMPOFF_APPROVEDDATE = Convert.ToDateTime(rdp_ApprovalDate.SelectedDate.Value); //Convert.ToDateTime(rdp_ApprovalDate.SelectedDate.Value.ToString("MM/dd/YYYy"));
            _obj_smhr_empcompoff.EMPCOMPOFF_APPROVALREMARKS = txt.Text;
            if (txt.Text == "")
                _obj_smhr_empcompoff.EMPCOMPOFF_APPROVALREMARKS = null;
            _obj_smhr_empcompoff.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_empcompoff.LASTMDFDATE = DateTime.Now;
            _obj_smhr_empcompoff.OPERATION = operation.Update1;
            status = BLL.set_empcompoffs(_obj_smhr_empcompoff);
            if (status == true)
            {
                BLL.ShowMessage(this, "Selected Compoffs Rejected");
                LoadData();
                RG_CompoffApproval.DataBind();
                //rg_expenseapproval.visible = false;
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CompOffApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void RG_CompoffApproval_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadData();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CompOffApproval", ex.StackTrace, DateTime.Now);
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
            //return;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CompOffApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

}


