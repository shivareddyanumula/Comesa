﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using System.Text;
using Telerik.Web.UI;
using RECRUITMENT;
using System.Net.Mail;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using System.Configuration;
using System.Collections;
using System.Globalization;
using System.Threading;

public partial class Approval_frm_JobRequisitionApproval : System.Web.UI.Page
{
    RECRUITMENT_APPROVALPROCESS _obj_Rec_ApprovalProcess;
    RECRUITMENT_JOBREQUISITION _obj_Rec_JobRequisition;

    DataTable dt_Details;

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Resource Requisition Approval");
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
                    RG_JRApproval.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_JRApprove.Visible = false;
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
                if (Request.QueryString["JOBREQ"] != null)
                {
                    BLL.ShowMessage(this, "Information Updated Successfully.");
                }
                rtxt_Approver.Text = Convert.ToString(Session["EMP_ID"]);
                LoadData();
                RG_JRApproval.DataBind();
                rdp_JRApprovalDate.SelectedDate = DateTime.Now;
                BLL.ChangeDateFormat(Convert.ToString(Session["EMP_ID"]), rdp_JRApprovalDate);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_JobRequisitionApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void rgap_needsource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadData();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_JobRequisitionApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    private void LoadData()
    {
        try
        {


            _obj_Rec_ApprovalProcess = new RECRUITMENT_APPROVALPROCESS();
            //_obj_Rec_ApprovalProcess.OPERATION = operation.Check;
            _obj_Rec_ApprovalProcess.OPERATION = operation.Get;
            _obj_Rec_ApprovalProcess.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            //_obj_Rec_ApprovalProcess.APPRO_2LEVEL = Convert.ToInt32(Convert.ToString(Session["EMP_ID"]));
            _obj_Rec_ApprovalProcess.APPRO_ID = Convert.ToInt32(Convert.ToString(Session["EMP_ID"]));

            dt_Details = new DataTable();
            dt_Details = Recruitment_BLL.get_JRApp(_obj_Rec_ApprovalProcess);
            RG_JRApproval.DataSource = dt_Details;
            //  RG_JRApproval.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_JobRequisitionApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void btn_JRApprove_Click(object sender, EventArgs e)
    {
        try
        {


            if (RG_JRApproval.Items.Count == 0)
            {
                BLL.ShowMessage(this, "No Records to Approve");
                return;
            }
            CheckBox chkBoxt = new CheckBox();
            Label lblID = new Label();
            string strg = "";
            for (int index = 0; index <= RG_JRApproval.Items.Count - 1; index++)
            {
                chkBoxt = RG_JRApproval.Items[index].FindControl("chk_Choose") as CheckBox;
                lblID = RG_JRApproval.Items[index].FindControl("lbljrID") as Label;
                if (chkBoxt.Checked)
                {
                    if (strg == "")
                        strg = "" + lblID.Text + "";
                    else
                        strg = strg + "," + lblID.Text + "";
                }
            }

            if (string.IsNullOrEmpty(strg))
            {
                BLL.ShowMessage(this, "Please Select Atleast one Record to Approve ");
                return;
            }

            CheckBox chkBox = new CheckBox();
            Label lblempid = new Label();
            Label lblstatus = new Label();
            Label lblJRID = new Label();
            bool status1 = false;
            bool status = false;
            string str = string.Empty;
            for (int index = 0; index <= RG_JRApproval.Items.Count - 1; index++)
            {
                chkBox = RG_JRApproval.Items[index].FindControl("chk_Choose") as CheckBox;
                lblempid = RG_JRApproval.Items[index].FindControl("lblempID") as Label;
                lblstatus = RG_JRApproval.Items[index].FindControl("lbljrstatus") as Label;
                lblJRID = RG_JRApproval.Items[index].FindControl("lbljrID") as Label;
                string t = Convert.ToString(RG_JRApproval.Items[index]["APPROVER2_EMAIL"].Text);
                if (chkBox.Checked)
                {
                    if (Convert.ToString(lblstatus.Text) == "PENDING")
                    {
                        _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
                        _obj_Rec_JobRequisition.JOBREQ_APPROVALSTATUS = 1;
                        _obj_Rec_JobRequisition.JOBREQ_LEVEL = Convert.ToInt32(Session["USER_ID"]);   //Approval level 1
                        _obj_Rec_JobRequisition.JOBREQ_APPROVEDBY = Convert.ToInt32(Convert.ToString(Session["EMP_ID"]));
                        _obj_Rec_JobRequisition.JOBREQ_APPROVEDDATE = Convert.ToDateTime(rdp_JRApprovalDate.SelectedDate.Value);
                        _obj_Rec_JobRequisition.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_Rec_JobRequisition.LASTMDFDATE = DateTime.Now;
                        _obj_Rec_JobRequisition.JOBREQ_ID = Convert.ToInt32(lblJRID.Text);
                        _obj_Rec_JobRequisition.JOBREQ_CURRENTSTATUS = lblstatus.Text;
                        _obj_Rec_JobRequisition.OPERATION = operation.Check1;

                        status = Recruitment_BLL.set_JobRequisition(_obj_Rec_JobRequisition);
                        if (status == true)
                        {
                            /*
                            if (Convert.ToString(RG_JRApproval.Items[index]["APPROVER1_EMAIL"].Text) != string.Empty && Convert.ToString(RG_JRApproval.Items[index]["EMAIL"].Text) != string.Empty)
                            {
                                sendMail(Convert.ToString(RG_JRApproval.Items[index]["APPROVER1_EMAIL"].Text), Convert.ToString(RG_JRApproval.Items[index]["EMAIL"].Text),
                                    Convert.ToString(RG_JRApproval.Items[index]["EMPNAME_APPROVER1"].Text), Convert.ToString(RG_JRApproval.Items[index]["EMPNAME"].Text),
                                    Convert.ToString(RG_JRApproval.Items[index]["JOBREQ_REQCODE"].Text), "Approved");
                                status1 = true;
                                str = "Approver1";
                            }
                            */
                            if (status)
                                BLL.ShowMessage(this, "Selected Job Requisition(s) has been approved");

                            _obj_Rec_JobRequisition.JOBREQ_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Rec_JobRequisition.JOBREQ_RAISEDBY = Convert.ToInt32(Session["USER_ID"]);
                            _obj_Rec_JobRequisition.MODE = 1;
                            bool status2 = Recruitment_BLL.get_JobReqAprover(_obj_Rec_JobRequisition);
                            if (status2)
                            {
                                BLL.ShowMessage(this, "A Mail has been sent to the user");
                            }

                            //LoadData();
                            //RG_JRApproval.DataBind();

                        }

                    }
                    else if (Convert.ToString(lblstatus.Text) == "APPROVED1")
                    {
                        _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
                        _obj_Rec_JobRequisition.JOBREQ_APPROVALSTATUS = 2;
                        _obj_Rec_JobRequisition.JOBREQ_LEVEL = 2;   //Approval level 2
                        _obj_Rec_JobRequisition.JOBREQ_APPROVEDBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_Rec_JobRequisition.JOBREQ_APPROVEDDATE = Convert.ToDateTime(rdp_JRApprovalDate.SelectedDate.Value);
                        _obj_Rec_JobRequisition.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); ;
                        _obj_Rec_JobRequisition.LASTMDFDATE = DateTime.Now;
                        _obj_Rec_JobRequisition.JOBREQ_ID = Convert.ToInt32(lblJRID.Text);
                        _obj_Rec_JobRequisition.JOBREQ_CURRENTSTATUS = lblstatus.Text;
                        _obj_Rec_JobRequisition.OPERATION = operation.Check1;


                        status = Recruitment_BLL.set_JobRequisition(_obj_Rec_JobRequisition);
                        if (status == true)
                        {
                            //BLL.ShowMessage(this, " selected Job Requisition Approved by Approver2 ");
                            /*
                            if (Convert.ToString(RG_JRApproval.Items[index]["APPROVER2_EMAIL"].Text) != string.Empty &&
                                Convert.ToString(RG_JRApproval.Items[index]["EMAIL"].Text) != string.Empty)
                            {
                                sendMail(Convert.ToString(RG_JRApproval.Items[index]["APPROVER2_EMAIL"].Text), Convert.ToString(RG_JRApproval.Items[index]["EMAIL"].Text),
                                    Convert.ToString(RG_JRApproval.Items[index]["EMPNAME_APPROVER2"].Text), Convert.ToString(RG_JRApproval.Items[index]["EMPNAME"].Text),
                                    Convert.ToString(RG_JRApproval.Items[index]["JOBREQ_REQCODE"].Text), "Approved");
                                status1 = true;
                                str = "Approver2";
                            }
                              */

                            if (status)
                                BLL.ShowMessage(this, "Selected Job Requisition(s) has been approved");

                            _obj_Rec_JobRequisition.JOBREQ_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Rec_JobRequisition.JOBREQ_RAISEDBY = Convert.ToInt32(Session["USER_ID"]);
                            _obj_Rec_JobRequisition.MODE = 1;
                            bool status2 = Recruitment_BLL.get_JobReqAprover(_obj_Rec_JobRequisition);
                            if (status2)
                            {
                                BLL.ShowMessage(this, "A Mail has been sent to the user");
                            }

                            //LoadData();
                            //RG_JRApproval.DataBind();
                        }

                    }
                    else if (Convert.ToString(lblstatus.Text) == "APPROVED2")
                    {
                        _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
                        _obj_Rec_JobRequisition.JOBREQ_APPROVALSTATUS = 3;
                        _obj_Rec_JobRequisition.JOBREQ_LEVEL = 3;   //Approval level 3
                        _obj_Rec_JobRequisition.JOBREQ_APPROVEDBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_Rec_JobRequisition.JOBREQ_APPROVEDDATE = Convert.ToDateTime(rdp_JRApprovalDate.SelectedDate.Value);
                        _obj_Rec_JobRequisition.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); ;
                        _obj_Rec_JobRequisition.LASTMDFDATE = DateTime.Now;
                        _obj_Rec_JobRequisition.JOBREQ_ID = Convert.ToInt32(lblJRID.Text);
                        _obj_Rec_JobRequisition.JOBREQ_CURRENTSTATUS = lblstatus.Text;
                        _obj_Rec_JobRequisition.OPERATION = operation.Check1;


                        status = Recruitment_BLL.set_JobRequisition(_obj_Rec_JobRequisition);
                        if (status == true)
                        {
                            //BLL.ShowMessage(this, " selected Job Requisition Approved by Approver2 ");
                            /*
                            if (Convert.ToString(RG_JRApproval.Items[index]["APPROVER3_EMAIL"].Text) != string.Empty &&
                                Convert.ToString(RG_JRApproval.Items[index]["EMAIL"].Text) != string.Empty)
                            {
                                sendMail(Convert.ToString(RG_JRApproval.Items[index]["APPROVER3_EMAIL"].Text), Convert.ToString(RG_JRApproval.Items[index]["EMAIL"].Text),
                                    Convert.ToString(RG_JRApproval.Items[index]["EMPNAME_APPROVER3"].Text), Convert.ToString(RG_JRApproval.Items[index]["EMPNAME"].Text),
                                    Convert.ToString(RG_JRApproval.Items[index]["JOBREQ_REQCODE"].Text), "Approved");
                                status1 = true;
                                str = "Approver3";
                            }
                            */

                            if (status)
                                BLL.ShowMessage(this, "Selected Job Requisition(s) has been approved");

                            _obj_Rec_JobRequisition.JOBREQ_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Rec_JobRequisition.JOBREQ_RAISEDBY = Convert.ToInt32(Session["USER_ID"]);
                            _obj_Rec_JobRequisition.MODE = 1;
                            bool status2 = Recruitment_BLL.get_JobReqAprover(_obj_Rec_JobRequisition);
                            if (status2)
                            {
                                BLL.ShowMessage(this, "A Mail has been sent to the user");
                            }

                            //LoadData();
                            //RG_JRApproval.DataBind();

                            // return;

                            //This code is for mailing purpose

                            ////////SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                            ////////_obj_Rec_JobRequisition.JOBREQ_RAISEDBY = Convert.ToInt32(Session["EMP_ID"]);
                            ////////bool status1 = Recruitment_BLL.get_JobReqAprover(_obj_Rec_JobRequisition);
                            ////////Recruitment_BLL.ShowMessage(this, "Notification Sent"); 
                        }

                    }
                }

            }
            LoadData();
            RG_JRApproval.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_JobRequisitionApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_JRReject_Click(object sender, EventArgs e)
    {
        try
        {

            if (RG_JRApproval.Items.Count == 0)
            {
                BLL.ShowMessage(this, "No Records to Reject");
                return;
            }
            CheckBox chkBoxt = new CheckBox();
            Label lblID = new Label();
            string strg = "";
            for (int index = 0; index <= RG_JRApproval.Items.Count - 1; index++)
            {
                chkBoxt = RG_JRApproval.Items[index].FindControl("chk_Choose") as CheckBox;
                lblID = RG_JRApproval.Items[index].FindControl("lbljrID") as Label;
                if (chkBoxt.Checked)
                {
                    if (strg == "")
                        strg = "" + lblID.Text + "";
                    else
                        strg = strg + "," + lblID.Text + "";
                }
            }

            if (string.IsNullOrEmpty(strg))
            {
                BLL.ShowMessage(this, "Please Select Atleast one Record to Reject");
                return;
            }
            CheckBox chkBox = new CheckBox();
            Label lblempid = new Label();
            Label lblstatus = new Label();
            Label lblJRID = new Label();
            bool status1 = false;
            string str = string.Empty;
            for (int index = 0; index <= RG_JRApproval.Items.Count - 1; index++)
            {
                chkBox = RG_JRApproval.Items[index].FindControl("chk_Choose") as CheckBox;
                lblempid = RG_JRApproval.Items[index].FindControl("lblempID") as Label;
                lblstatus = RG_JRApproval.Items[index].FindControl("lbljrstatus") as Label;
                lblJRID = RG_JRApproval.Items[index].FindControl("lbljrID") as Label;
                if (chkBox.Checked)
                {
                    if (Convert.ToString(lblstatus.Text) == "PENDING")
                    {
                        bool status = false;
                        _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
                        _obj_Rec_JobRequisition.JOBREQ_APPROVALSTATUS = 4;
                        _obj_Rec_JobRequisition.JOBREQ_LEVEL = 1;   //Rejection level 1
                        _obj_Rec_JobRequisition.JOBREQ_APPROVEDBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_Rec_JobRequisition.JOBREQ_APPROVEDDATE = Convert.ToDateTime(rdp_JRApprovalDate.SelectedDate.Value);
                        _obj_Rec_JobRequisition.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); ;
                        _obj_Rec_JobRequisition.LASTMDFDATE = DateTime.Now;
                        _obj_Rec_JobRequisition.JOBREQ_ID = Convert.ToInt32(lblJRID.Text);
                        _obj_Rec_JobRequisition.OPERATION = operation.Check1;

                        status = Recruitment_BLL.set_JobRequisition(_obj_Rec_JobRequisition);
                        if (status == true)
                        {
                            //BLL.ShowMessage(this, " selected Job Requisition Rejected by Approver1");
                            /*
                            if (Convert.ToString(RG_JRApproval.Items[index]["APPROVAR1_EMAIL"].Text) != string.Empty && Convert.ToString(RG_JRApproval.Items[index]["EMAIL"].Text) != string.Empty)
                            {
                                sendMail(Convert.ToString(RG_JRApproval.Items[index]["APPROVER1_EMAIL"].Text), Convert.ToString(RG_JRApproval.Items[index]["EMAIL"].Text),
                                    Convert.ToString(RG_JRApproval.Items[index]["EMPNAME_APPROVER1"].Text), Convert.ToString(RG_JRApproval.Items[index]["EMPNAME"].Text),
                                    Convert.ToString(RG_JRApproval.Items[index]["JOBREQ_REQCODE"].Text), "Rejected");
                                status1 = true;
                                str = "Approver1";
                            }
                            */

                            //SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();
                            //_obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                            //_obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["EMP_ID"]).Trim();
                            //_obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            //_obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
                            _obj_Rec_JobRequisition.JOBREQ_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Rec_JobRequisition.JOBREQ_RAISEDBY = Convert.ToInt32(Session["USER_ID"]);
                            //_obj_Rec_JobRequisition.JOBREQ_ID = Convert.ToInt32(lblJRID.Text);
                            _obj_Rec_JobRequisition.MODE = 1;
                            bool status2 = Recruitment_BLL.get_JobReqAprover(_obj_Rec_JobRequisition);
                            if (status2)
                            {
                                BLL.ShowMessage(this, "A Mail has been sent to the user");
                            }
                            //BLL.ShowMessage(this, "A Mail has been sent to the user");

                            //LoadData();
                            //RG_JRApproval.DataBind();

                            //return;
                        }
                    }
                    else if (Convert.ToString(lblstatus.Text) == "APPROVED1")
                    {
                        bool status = false;
                        _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
                        _obj_Rec_JobRequisition.JOBREQ_APPROVALSTATUS = 4;
                        _obj_Rec_JobRequisition.JOBREQ_LEVEL = 2;   //Rejection level 2
                        _obj_Rec_JobRequisition.JOBREQ_APPROVEDBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_Rec_JobRequisition.JOBREQ_APPROVEDDATE = Convert.ToDateTime(rdp_JRApprovalDate.SelectedDate.Value);
                        _obj_Rec_JobRequisition.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_Rec_JobRequisition.LASTMDFDATE = DateTime.Now;
                        _obj_Rec_JobRequisition.JOBREQ_ID = Convert.ToInt32(lblJRID.Text);
                        _obj_Rec_JobRequisition.OPERATION = operation.Check1;

                        status = Recruitment_BLL.set_JobRequisition(_obj_Rec_JobRequisition);
                        if (status == true)
                        {
                            //BLL.ShowMessage(this, " selected Job Requisition Rejected by Approver2 ");
                            /*
                            if (Convert.ToString(RG_JRApproval.Items[index]["APPROVAR2_EMAIL"].Text) != string.Empty && Convert.ToString(RG_JRApproval.Items[index]["EMAIL"].Text) != string.Empty)
                            {
                                sendMail(Convert.ToString(RG_JRApproval.Items[index]["APPROVER2_EMAIL"].Text), Convert.ToString(RG_JRApproval.Items[index]["EMAIL"].Text),
                                    Convert.ToString(RG_JRApproval.Items[index]["EMPNAME_APPROVER2"].Text), Convert.ToString(RG_JRApproval.Items[index]["EMPNAME"].Text),
                                    Convert.ToString(RG_JRApproval.Items[index]["JOBREQ_REQCODE"].Text), "Rejected");
                                status1 = true;
                                str = "Approver2";
                            }
                            */

                            //_obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
                            _obj_Rec_JobRequisition.JOBREQ_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Rec_JobRequisition.JOBREQ_RAISEDBY = Convert.ToInt32(Session["USER_ID"]);
                            _obj_Rec_JobRequisition.MODE = 1;
                            bool status2 = Recruitment_BLL.get_JobReqAprover(_obj_Rec_JobRequisition);
                            if (status2)
                            {
                                BLL.ShowMessage(this, "A Mail has been sent to the user");
                            }
                            //LoadData();
                            //RG_JRApproval.DataBind();

                            //return;
                        }
                    }
                    else if (Convert.ToString(lblstatus.Text) == "APPROVED2")
                    {
                        bool status = false;
                        _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
                        _obj_Rec_JobRequisition.JOBREQ_APPROVALSTATUS = 4;
                        _obj_Rec_JobRequisition.JOBREQ_LEVEL = 3;   //Rejection level 3
                        _obj_Rec_JobRequisition.JOBREQ_APPROVEDBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_Rec_JobRequisition.JOBREQ_APPROVEDDATE = Convert.ToDateTime(rdp_JRApprovalDate.SelectedDate.Value);
                        _obj_Rec_JobRequisition.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); ;
                        _obj_Rec_JobRequisition.LASTMDFDATE = DateTime.Now;
                        _obj_Rec_JobRequisition.JOBREQ_ID = Convert.ToInt32(lblJRID.Text);
                        _obj_Rec_JobRequisition.OPERATION = operation.Check1;

                        status = Recruitment_BLL.set_JobRequisition(_obj_Rec_JobRequisition);
                        if (status == true)
                        {
                            //BLL.ShowMessage(this, " selected Job Requisition Rejected by Approver3 ");
                            /*
                            if (Convert.ToString(RG_JRApproval.Items[index]["APPROVER3_EMAIL"].Text) != string.Empty && Convert.ToString(RG_JRApproval.Items[index]["EMAIL"].Text) != string.Empty)
                            {
                                sendMail(Convert.ToString(RG_JRApproval.Items[index]["APPROVER3_EMAIL"].Text), Convert.ToString(RG_JRApproval.Items[index]["EMAIL"].Text),
                                    Convert.ToString(RG_JRApproval.Items[index]["EMPNAME_APPROVER3"].Text), Convert.ToString(RG_JRApproval.Items[index]["EMPNAME"].Text),
                                    Convert.ToString(RG_JRApproval.Items[index]["JOBREQ_REQCODE"].Text), "Rejected");
                                status1 = true;
                                str = "Approver3";
                            }
                            */

                            //_obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
                            _obj_Rec_JobRequisition.JOBREQ_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Rec_JobRequisition.JOBREQ_RAISEDBY = Convert.ToInt32(Session["USER_ID"]);
                            _obj_Rec_JobRequisition.MODE = 1;
                            bool status2 = Recruitment_BLL.get_JobReqAprover(_obj_Rec_JobRequisition);
                            if (status2)
                            {
                                BLL.ShowMessage(this, "A Mail has been sent to the user");
                            }
                            //LoadData();
                            //RG_JRApproval.DataBind();

                            //return;
                        }
                    }
                }
            }
            LoadData();
            RG_JRApproval.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_JobRequisitionApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void btn_JRCancel_Click(object sender, EventArgs e)
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_JobRequisitionApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_ViewDetailsCommand(object sender, CommandEventArgs e)
    {
        try
        {
            string JOBREQ_ID = Convert.ToString(e.CommandArgument);
            //Response.Redirect("~/Recruitment/frm_JobRequisition.aspx?JOBREQ_ID="+ JOBREQ_ID,false);
            if (JOBREQ_ID != "")
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToString(JOBREQ_ID) + "');", true);

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_JobRequisitionApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void sendMail(string email1, string email2, string appr_name, string emp_name, string jobreq_code, string status)
    {
        try
        {
            //msgMail.From = new MailAddress("smtpmail@dhanushinfotech.com", "Smart HR");
            //msgMail.To.Add(Convert.ToString("priya.bulusu@dhanushinfotech.net"));
            string toAddress, subject, body;
            toAddress = email2;
            subject = "Job Requisition Status";
            body = "<html>" +
                            "<body> " +
                            "<p>Dear, " + Convert.ToString(emp_name) + " </p> " +
                            "<p>The Job Reuisition " + jobreq_code + " is " + status + " by " + appr_name + " <br>" +
                            "</p> " +
                            "<p>Best Regards,<br/><br/>" +
                            "Team Smart HR</p>" +
                            "</body>" +
                            " </html>";
            BLL.SendMail(toAddress, null, subject, body);
            //BLL.ShowMessage(this, "A Mail has been sent to the user");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Test", "<script type='text/javascript'>Close()</" + "script>", false);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_JobRequisitionApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}