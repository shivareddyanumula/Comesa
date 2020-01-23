using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Data;
using RECRUITMENT;
using System.Net.Mail;
using System.Configuration;
using Telerik.Web.UI;

public partial class Recruitment_AssignEmpRSL : System.Web.UI.Page
{
    RECRUITMENT_ASSIGNEMPTORSL _obj_Rec_AssignEmptoRSL;
    SMHR_DEPARTMENT _obj_SMHR_Department;
    RECRUITMENT_JOBREQUISITION _obj_Rec_JobRequisition;
    SMHR_LOGININFO _obj_Smhr_LoginInfo;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();
                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Assign Employee to Resume Short Listing");//Self Appraisal");
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
                    RG_AssignEmpRSL.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
                LoadGrid();
                RG_AssignEmpRSL.DataBind();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "AssignEmpRSL", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void RG_AssignEmpRSL_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        LoadGrid();
    }
    protected void LoadGrid()
    {
        try
        {
            _obj_Rec_AssignEmptoRSL = new RECRUITMENT_ASSIGNEMPTORSL();
            _obj_Rec_AssignEmptoRSL.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Rec_AssignEmptoRSL.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            _obj_Rec_AssignEmptoRSL.MODE = 1;
            DataTable dt = Recruitment_BLL.get_AssigmEMPtoRSL(_obj_Rec_AssignEmptoRSL);
            RG_AssignEmpRSL.DataSource = dt;

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "AssignEmpRSL", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadBU()
    {
        try
        {
            SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
            _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"].ToString());
            rcmb_BU.Items.Clear();
            rcmb_BU.DataSource = BLL.get_Business_Units(_obj_smhr_logininfo);
            rcmb_BU.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BU.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BU.DataBind();
            rcmb_BU.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "AssignEmpRSL", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            btn_Save.Visible = true;
            btn_Update.Visible = false;
            rcmb_BU.Enabled = true;
            rcmb_JobReq.Enabled = true;
            RMP_AssignEmpRSL.SelectedIndex = 1;
            rcmb_Dept.Items.Clear();
            rcmb_EMP.Items.Clear();
            rcmb_JobReq.Items.Clear();
            LoadBU();
            ViewState.Remove("EMP_ID");
            rcmb_EMP.ClearSelection();
            rcmb_EMP.Items.Clear();
            rcmb_EMP.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            rcmb_JobReq.ClearSelection();
            rcmb_JobReq.Items.Clear();
            rcmb_JobReq.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            rcmb_Dept.ClearSelection();
            rcmb_Dept.Items.Clear();
            rcmb_Dept.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "AssignEmpRSL", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_BU_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_BU.SelectedIndex > 0)
            {
                rcmb_Dept.Items.Clear();
                rcmb_JobReq.Items.Clear();
                _obj_SMHR_Department = new SMHR_DEPARTMENT();
                _obj_SMHR_Department.MODE = 9;
                _obj_SMHR_Department.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                _obj_SMHR_Department.BUID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
                DataTable dt_Details = BLL.get_Department(_obj_SMHR_Department);
                if (dt_Details.Rows.Count != 0)
                {
                    rcmb_Dept.DataSource = dt_Details;
                    rcmb_Dept.DataTextField = "DEPARTMENT_NAME";
                    rcmb_Dept.DataValueField = "DEPARTMENT_ID";
                    rcmb_Dept.DataBind();
                    rcmb_Dept.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                }
                //TO LOAD JOB REQUISITION
                _obj_Rec_AssignEmptoRSL = new RECRUITMENT_ASSIGNEMPTORSL();
                _obj_Rec_AssignEmptoRSL.ASSIGNEMP_BUID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
                _obj_Rec_AssignEmptoRSL.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Rec_AssignEmptoRSL.MODE = 4;
                DataTable DT = Recruitment_BLL.get_AssigmEMPtoRSL(_obj_Rec_AssignEmptoRSL);
                if (DT.Rows.Count > 0)
                {
                    rcmb_JobReq.DataSource = DT;
                    rcmb_JobReq.DataTextField = "JOBREQ_REQCODE";
                    rcmb_JobReq.DataValueField = "JOBREQ_ID";
                    rcmb_JobReq.DataBind();
                    rcmb_JobReq.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                }
            }
            else
            {
                rcmb_Dept.ClearSelection();
                rcmb_Dept.Items.Clear();
                rcmb_Dept.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

                rcmb_JobReq.ClearSelection();
                rcmb_JobReq.Items.Clear();
                rcmb_JobReq.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
            rcmb_EMP.ClearSelection();
            rcmb_EMP.Items.Clear();
            rcmb_EMP.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "AssignEmpRSL", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_Dept_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Dept.SelectedIndex > 0)
            {
                rcmb_EMP.Items.Clear();
                _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
                _obj_Rec_JobRequisition.JOBREQ_DEPARTMENT = Convert.ToInt32(rcmb_Dept.SelectedItem.Value);
                _obj_Rec_JobRequisition.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Rec_JobRequisition.MODE = 16;
                DataTable dt = Recruitment_BLL.get_JobRequisition(_obj_Rec_JobRequisition);
                if (dt.Rows.Count > 0)
                {
                    rcmb_EMP.DataSource = dt;
                    rcmb_EMP.DataTextField = "EMP_NAME";
                    rcmb_EMP.DataValueField = "EMP_ID";
                    rcmb_EMP.DataBind();
                    rcmb_EMP.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                }
            }
            else
            {
                rcmb_EMP.ClearSelection();
                rcmb_EMP.Items.Clear();
                rcmb_EMP.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "AssignEmpRSL", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_Rec_AssignEmptoRSL = new RECRUITMENT_ASSIGNEMPTORSL();
            _obj_Rec_AssignEmptoRSL.ASSIGNEMP_BUID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
            _obj_Rec_AssignEmptoRSL.ASSIGNEMP_EMP_ID = Convert.ToInt32(rcmb_EMP.SelectedItem.Value);
            _obj_Rec_AssignEmptoRSL.ASSIGNEMP_DEPT = Convert.ToInt32(rcmb_Dept.SelectedItem.Value);
            _obj_Rec_AssignEmptoRSL.ASSIGNEMP_JOBREQ = Convert.ToInt32(rcmb_JobReq.SelectedItem.Value);
            _obj_Rec_AssignEmptoRSL.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Rec_AssignEmptoRSL.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_Rec_AssignEmptoRSL.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_UPDATE":
                    _obj_Rec_AssignEmptoRSL.MODE = 3;
                    _obj_Rec_AssignEmptoRSL.ASSIGNEMP_ID = Convert.ToInt32(lbl_id.Text);
                    if (Recruitment_BLL.set_AssigmEMPtoRSL(_obj_Rec_AssignEmptoRSL))
                    {
                        BLL.ShowMessage(this, "Information Updated Successfully.");
                        if (Convert.ToInt32(ViewState["EMP_ID"]) != Convert.ToInt32(rcmb_EMP.SelectedItem.Value))
                            sendMail(Convert.ToInt32(rcmb_EMP.SelectedItem.Value), Convert.ToString(rcmb_JobReq.SelectedItem.Text));
                        RMP_AssignEmpRSL.SelectedIndex = 0;
                        LoadGrid();
                        RG_AssignEmpRSL.DataBind();
                        return;
                    }
                    break;
                case "BTN_SAVE":
                    _obj_Rec_AssignEmptoRSL.MODE = 2;
                    if (Recruitment_BLL.set_AssigmEMPtoRSL(_obj_Rec_AssignEmptoRSL))
                    {
                        BLL.ShowMessage(this, "Information Saved Successfully.");
                        sendMail(Convert.ToInt32(rcmb_EMP.SelectedItem.Value), Convert.ToString(rcmb_JobReq.SelectedItem.Text));
                        RMP_AssignEmpRSL.SelectedIndex = 0;
                        LoadGrid();
                        RG_AssignEmpRSL.DataBind();
                        return;
                    }
                    break;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "AssignEmpRSL", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            RMP_AssignEmpRSL.SelectedIndex = 1;
            btn_Save.Visible = false;
            btn_Update.Visible = true;
            rcmb_BU.Enabled = false;
            rcmb_JobReq.Enabled = false;
            LoadBU();
            _obj_Rec_AssignEmptoRSL = new RECRUITMENT_ASSIGNEMPTORSL();
            _obj_Rec_AssignEmptoRSL.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Rec_AssignEmptoRSL.ASSIGNEMP_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            lbl_id.Text = Convert.ToString(Convert.ToString(e.CommandArgument));
            _obj_Rec_AssignEmptoRSL.MODE = 5;
            DataTable dt = Recruitment_BLL.get_AssigmEMPtoRSL(_obj_Rec_AssignEmptoRSL);
            if (dt.Rows.Count > 0)
            {
                rcmb_BU.SelectedIndex = rcmb_BU.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["BUSINESSUNIT_ID"]));
                rcmb_BU_SelectedIndexChanged(null, null);
                rcmb_Dept.SelectedIndex = rcmb_Dept.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["DEPARTMENT_ID"]));
                //TO LOAD JOB REQUISITION
                rcmb_JobReq.Items.Clear();
                _obj_Rec_AssignEmptoRSL = new RECRUITMENT_ASSIGNEMPTORSL();
                _obj_Rec_AssignEmptoRSL.ASSIGNEMP_BUID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
                _obj_Rec_AssignEmptoRSL.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Rec_AssignEmptoRSL.MODE = 6;
                DataTable DT = Recruitment_BLL.get_AssigmEMPtoRSL(_obj_Rec_AssignEmptoRSL);
                if (DT.Rows.Count > 0)
                {
                    rcmb_JobReq.DataSource = DT;
                    rcmb_JobReq.DataTextField = "JOBREQ_REQCODE";
                    rcmb_JobReq.DataValueField = "JOBREQ_ID";
                    rcmb_JobReq.DataBind();
                    rcmb_JobReq.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                }
                rcmb_JobReq.SelectedIndex = rcmb_JobReq.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["JOBREQ_ID"]));
                rcmb_Dept_SelectedIndexChanged(null, null);
                rcmb_EMP.SelectedIndex = rcmb_EMP.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["EMP_ID"]));
            }
            ViewState["EMP_ID"] = Convert.ToInt32(rcmb_EMP.SelectedItem.Value);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "AssignEmpRSL", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            LoadGrid();
            RG_AssignEmpRSL.DataBind();
            RMP_AssignEmpRSL.SelectedIndex = 0;
            rcmb_BU.Items.Clear();
            rcmb_Dept.Items.Clear();
            rcmb_EMP.Items.Clear();
            rcmb_JobReq.Items.Clear();
            lbl_id.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "AssignEmpRSL", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    public void sendMail(int emp_id, string jobreq)
    {
        try
        {
            _obj_Smhr_LoginInfo = new SMHR_LOGININFO();
            _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_LoginInfo.LOGIN_EMP_ID = emp_id;
            _obj_Smhr_LoginInfo.OPERATION = operation.Select3;
            DataTable dt = BLL.get_LoginInfo(_obj_Smhr_LoginInfo);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["EMP_EMAILID"] != System.DBNull.Value && Convert.ToString(dt.Rows[0]["EMP_EMAILID"]) != string.Empty)
                {
                    string toAddress, subject, body;
                    toAddress=(Convert.ToString(dt.Rows[0]["EMP_EMAILID"]));
                    subject = "assigned to Resume Short Listing";
                    body = "<html>" +
                                    "<body> " +
                                    "<p>Dear, " + Convert.ToString(dt.Rows[0]["EMPNAME"]) + " </p> " +
                                    "<p>You have been assigned for Resume Short Listing for the Job Requisition " + jobreq + " <br>" +
                                    "</p> " +
                                    "<p>Best Regards,<br/><br/>" +
                                    "Team Smart HR</p>" +
                                    "</body>" +
                                    " </html>";
                    BLL.SendMail(toAddress, null, subject, body);
                    BLL.ShowMessage(this, "A Mail has been sent to the Assigned Employee.");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Test", "<script type='text/javascript'>Close()</" + "script>", false);
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "AssignEmpRSL", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
