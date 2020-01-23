﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using Telerik.Web.UI;

public partial class HR_frm_Resignation : System.Web.UI.Page
{
    protected SMHR_MASTERS _obj_Smhr_Masters;
    SMHR_BUSINESSUNIT _obj_smhr_businessunit;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_DIVISION _obj_Smhr_Division;
    SMHR_DEPARTMENT _obj_SMHR_Department;
    string Control;

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            Page.Validate();
            Control = Convert.ToString(Request.QueryString["Control"]);
            hdncontrol.Value = Control;
            if (!Page.IsPostBack)
            {



                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();
                if (Control != null)
                {
                    if (Control.ToUpper() == "SELFRESIGNATION")
                    {
                        _obj_Smhr_LoginInfo.LOGIN_ID = 12;
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("EMPLOYEE RESIGNATION");
                    }

                }
                else
                {
                    _obj_Smhr_LoginInfo.LOGIN_ID = 2;
                    _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("EMPLOYEE RESIGNATION");
                }
                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //_obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("EMPLOYEE RESIGNATION");
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
                    Rg_EmpResg.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Save.Visible = false;
                    btn_Edit.Visible = false;
                    btn_Type_Save.Visible = false;

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
                //table_ExitInterview.Attributes.Add("style", "visibility:hidden;display:none");
                try
                {
                    loadDropdown();
                    BLL.ChangeDateFormat(Convert.ToString(Session["EMP_ID"]), rdtp_ResignationDate, rdtp_RelievingDate);
                    BLL.gridDateFormat(Convert.ToString(Session["EMP_ID"]), Rg_EmpResg, "EMPREG_REGDATE");
                }
                catch (Exception ex)
                {
                    SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Resignation", ex.StackTrace, DateTime.Now);
                    Response.Redirect("~/Frm_ErrorPage.aspx");
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Resignation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            clearControls();
            SMHR_EMPRESIGNATION _obj_Smhr_Empresignation = new SMHR_EMPRESIGNATION();
            _obj_Smhr_Empresignation.EMPREG_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            _obj_Smhr_Empresignation.OPERATION = operation.Check;
            DataTable dtstatus = BLL.get_Empresignation(_obj_Smhr_Empresignation);

            #region MyRegion
            //get exit_interview

            //SMHR_EMPLOYEE_EXIT_INTERVIEW _obj_smhr_emp_exit_interview = new SMHR_EMPLOYEE_EXIT_INTERVIEW();
            //_obj_smhr_emp_exit_interview.EMP_EXIT_INTERVIEW_EMP_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            //DataTable dtExitInterview = BLL.get_EmpresignationExitInterview(_obj_smhr_emp_exit_interview);

            //txt_jobfrustrating.Text = dtExitInterview.Rows[0]["EMP_EXIT_INTERVIEW_JOB_FRUSTRATION"].ToString();
            //txt_jobSatisfying.Text = dtExitInterview.Rows[0]["EMP_EXIT_INTERVIEW_JOB_SATISFACTION"].ToString();
            //txt_jobsuggestion.Text = dtExitInterview.Rows[0]["EMP_EXIT_INTERVIEW_SUGGESTION"].ToString();
            //txt_PrimaryReason.Text = dtExitInterview.Rows[0]["EMP_EXIT_INTERVIEW_PRIMARY_REASON"].ToString();
            //txt_Resignationprevention.Text = dtExitInterview.Rows[0]["EMP_EXIT_INTERVIEW_COMPANY_MEASURES"].ToString();


            //get exit_interview 
            #endregion

            int status = Convert.ToInt32(dtstatus.Rows[0]["EMPREG_STATUS"]);
            //if ((status == 1) || (status == 2))
            //{
            //    //BLL.ShowMessage(this, " Resignation for this employee is already processed, cannot be edited");
            //    //return;
            //    btn_Edit.Visible = false;
            //}

            //else
            //{
            loadDropdown();
            SMHR_EMPRESIGNATION _Obj_Smhr_EmpResignation = new SMHR_EMPRESIGNATION();
            _Obj_Smhr_EmpResignation.EMPREG_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            _Obj_Smhr_EmpResignation.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_Empresignation(_Obj_Smhr_EmpResignation);
            string strBU = LoadEmpBU(Convert.ToInt32(dt.Rows[0]["EMPREG_EMP_ID"]));
            rcmb_EmpReg_BU.SelectedValue = Convert.ToString(strBU);
            Load_Directorate();
            rad_Directorate.SelectedValue = Convert.ToString(dt.Rows[0]["DIRECTORATE_ID"]);
            rad_Directorate.Enabled = false;
            LoadDepartment();
            rad_Department.SelectedValue = Convert.ToString(dt.Rows[0]["DEPARTMENT_ID"]);
            rad_Department.Enabled = false;
            //rcmb_EmpReg_BU_SelectedIndexChanged(null, null);
            LoadEmployees_Edit();
            lbl_EmpregID.Text = Convert.ToString(dt.Rows[0]["EMPREG_ID"]);
            //rcmb_EmployeeCode.SelectedValue = Convert.ToString(dt.Rows[0]["EMPREG_EMP_ID"]);
            rcmb_EmployeeCode.SelectedIndex = rcmb_EmployeeCode.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["EMPREG_EMP_ID"]));
            //rcmb_EmployeeCode_SelectedIndexChanged(null, null);
            rcmb_Reasonresg.SelectedIndex = rcmb_Reasonresg.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["EMPREG_REASON"]));
            rtxt_Remarks.Text = Convert.ToString(dt.Rows[0]["EMPREG_REMARKS"]);
            rdtp_ResignationDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["EMPREG_REGDATE"]);
            if (Convert.ToBoolean(dt.Rows[0]["EMPREG_IS_TERMINATED"] != DBNull.Value))
            {
                chk_ImmediateTermination.Checked = Convert.ToBoolean(dt.Rows[0]["EMPREG_IS_TERMINATED"]);
                if (chk_ImmediateTermination.Checked)
                    chk_ImmediateTermination.Enabled = false;
            }

            if (Convert.ToBoolean(dt.Rows[0]["EMPREG_IsRsgndWthOutApprvl"] != DBNull.Value))
            {
                chkResignApproval.Checked = Convert.ToBoolean(dt.Rows[0]["EMPREG_IsRsgndWthOutApprvl"]);
                if (chkResignApproval.Checked)
                    chkResignApproval.Enabled = false;
            }

            //Exit Interview Information
            SMHR_EMPLOYEE_EXIT_INTERVIEW _obj_smhr_empExitInterview = new SMHR_EMPLOYEE_EXIT_INTERVIEW();
            _obj_smhr_empExitInterview.EMP_EXIT_INTERVIEW_EMPREG_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            DataTable dtExitInterview = BLL.get_EmpresignationExitInterview(_obj_smhr_empExitInterview);
            if (dtExitInterview != null)
            {
                if (dtExitInterview.Rows.Count > 0)
                {
                    pnl_ExitInterview.Visible = true;
                    btn_ExitInterview.Visible = true;
                    btn_ExitInterview.Text = "Hide ExitInterview";
                    txt_jobfrustrating.Text = Convert.ToString(dtExitInterview.Rows[0]["EMP_EXIT_INTERVIEW_JOB_FRUSTRATION"]);
                    txt_jobSatisfying.Text = Convert.ToString(dtExitInterview.Rows[0]["EMP_EXIT_INTERVIEW_JOB_SATISFACTION"]);
                    txt_jobsuggestion.Text = Convert.ToString(dtExitInterview.Rows[0]["EMP_EXIT_INTERVIEW_SUGGESTION"]);
                    txt_PrimaryReason.Text = Convert.ToString(dtExitInterview.Rows[0]["EMP_EXIT_INTERVIEW_PRIMARY_REASON"]);
                    txt_Resignationprevention.Text = Convert.ToString(dtExitInterview.Rows[0]["EMP_EXIT_INTERVIEW_COMPANY_MEASURES"]);
                }
                else
                {
                    btn_ExitInterview.Visible = false;
                    pnl_ExitInterview.Visible = false;
                }
            }
            //Exit Interview Information

            //TO MAKE EMPLOYEE DOJ AS MIN DATE,22.06.2011
            SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
            _obj_smhr_logininfo.OPERATION = operation.Select3;
            _obj_smhr_logininfo.LOGIN_EMP_ID = Convert.ToInt32(rcmb_EmployeeCode.SelectedItem.Value);
            _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_emp = BLL.get_LoginInfo(_obj_smhr_logininfo);
            if (dt_emp.Rows.Count > 0)
            {
                rdtp_ResignationDate.MinDate = Convert.ToDateTime(dt_emp.Rows[0]["EMP_DOJ"]);
            }

            if (dt.Rows[0]["EMPREG_RELDATE"] != System.DBNull.Value)
            {
                rdtp_RelievingDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["EMPREG_RELDATE"]);
            }
            else
            {
                rdtp_RelievingDate.SelectedDate = null;
            }

            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {

                btn_Edit.Visible = false;


            }

            else
            {
                if ((status == 1) || (status == 2))
                {
                    btn_Edit.Visible = false;
                }
                else
                {
                    btn_Edit.Visible = true;
                }

            }

            rcmb_EmployeeCode.Enabled = false;
            rcmb_EmpReg_BU.Enabled = false;
            Rm_EmpResg_page.SelectedIndex = 1;
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Resignation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    public void loadDropdown()
    {
        try
        {
            //if (Convert.ToInt32(Session["EMP_ID"]) == 0)
            if (Control != null)
            {
                if ((Convert.ToString(Session["SELFSERVICE"]) == "true" && Control.ToUpper() == "SELFRESIGNATION") || (Convert.ToString(Session["SELFSERVICE"]) == "" && Control.ToUpper() == "SELFRESIGNATION"))
                {

                    //FOR SELF EMPLOYEE
                    // Loading Business Unit 
                    rcmb_EmpReg_BU.Items.Clear();
                    _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
                    _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                    DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
                    rcmb_EmpReg_BU.DataSource = dt_BUDetails;
                    rcmb_EmpReg_BU.DataValueField = "BUSINESSUNIT_ID";
                    rcmb_EmpReg_BU.DataTextField = "BUSINESSUNIT_CODE";
                    rcmb_EmpReg_BU.DataBind();
                    rcmb_EmpReg_BU.Items.Insert(0, new RadComboBoxItem("Select"));
                    rcmb_EmployeeCode.Items.Clear();
                    //rcmb_EmployeeCode.Items.Insert(0, new RadComboBoxItem("Select"));


                    SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
                    _obj_smhr_emp_payitems.OPERATION = operation.Self;
                    _obj_smhr_emp_payitems.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                    _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable DT_SELF = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
                    rcmb_EmpReg_BU.SelectedIndex = rcmb_EmpReg_BU.FindItemIndexByValue(DT_SELF.Rows[0]["EMP_BUSINESSUNIT_ID"].ToString());
                    Load_Directorate();
                    rad_Directorate.SelectedIndex = rad_Directorate.FindItemIndexByValue(DT_SELF.Rows[0]["DIRECTORATE_ID"].ToString());
                    LoadDepartment();
                    rad_Department.SelectedIndex = rad_Department.FindItemIndexByValue(DT_SELF.Rows[0]["DEPARTMENT_ID"].ToString());
                    LoadEmployees();
                    rcmb_EmployeeCode.SelectedIndex = rcmb_EmployeeCode.FindItemIndexByValue(DT_SELF.Rows[0]["EMP_ID"].ToString());
                    // rcmb_EmpReg_BU.Enabled = false;
                    //rcmb_EmployeeCode.Enabled = false;
                }
                //else
                //{
                //    BLL.ShowMessage(this, "You do not have Access on this Screen.");
                //    return;
                //}
            }
            else
            {
                //FOR ADMIM
                // Loading Business Unit 
                rcmb_EmpReg_BU.Items.Clear();
                _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
                _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
                rcmb_EmpReg_BU.DataSource = dt_BUDetails;
                rcmb_EmpReg_BU.DataValueField = "BUSINESSUNIT_ID";
                rcmb_EmpReg_BU.DataTextField = "BUSINESSUNIT_CODE";
                rcmb_EmpReg_BU.DataBind();
                rcmb_EmpReg_BU.Items.Insert(0, new RadComboBoxItem("Select"));
                rcmb_EmployeeCode.Items.Clear();
                rcmb_EmployeeCode.Items.Insert(0, new RadComboBoxItem("Select"));

            }



            //Loading Reason Dropdown
            _obj_Smhr_Masters = new SMHR_MASTERS();
            rcmb_Reasonresg.Items.Clear();
            _obj_Smhr_Masters.MASTER_TYPE = "RESIGNATION";
            _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            rcmb_Reasonresg.DataSource = BLL.get_MasterRecords(_obj_Smhr_Masters);
            rcmb_Reasonresg.DataTextField = "HR_MASTER_CODE";
            rcmb_Reasonresg.DataValueField = "HR_MASTER_ID";
            rcmb_Reasonresg.DataBind();
            rcmb_Reasonresg.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select ", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Resignation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    public void LoadGrid()
    {
        try
        {
            //if (Convert.ToInt32(Session["EMP_ID"]) == 0)
            //{
            //    //FOR ADMIN
            //    SMHR_EMPRESIGNATION _obj_Resg = new SMHR_EMPRESIGNATION();
            //    _obj_Resg.OPERATION = operation.Select;
            //    _obj_Resg.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //    DataTable dt = BLL.get_Empresignation(_obj_Resg);
            //    Rg_EmpResg.DataSource = dt;
            //}
            //else if (Convert.ToString(Session["SELFSERVICE"]) == "")
            //{
            //    //FOR MANAGER
            //    SMHR_EMPRESIGNATION _obj_smhr_resignation = new SMHR_EMPRESIGNATION();
            //    _obj_smhr_resignation.MODE = 12;
            //    _obj_smhr_resignation.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //    _obj_smhr_resignation.EMPREG_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            //    DataTable dtDetails = BLL.get_Resignation(_obj_smhr_resignation);
            //    Rg_EmpResg.DataSource = dtDetails;
            //    //Rg_EmpResg.DataBind();
            //}
            //else
            //{
            //    //FOR SELF EMPLOYEE
            //    SMHR_EMPRESIGNATION _obj_smhr_resignation = new SMHR_EMPRESIGNATION();
            //    _obj_smhr_resignation.MODE = 11;
            //    _obj_smhr_resignation.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //    _obj_smhr_resignation.EMPREG_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            //    DataTable dtDetails = BLL.get_Resignation(_obj_smhr_resignation);
            //    Rg_EmpResg.DataSource = dtDetails;
            //}
            if (Control != null)
            {
                if ((Convert.ToString(Session["SELFSERVICE"]) == "true" && Control.ToUpper() == "SELFRESIGNATION") || (Convert.ToString(Session["SELFSERVICE"]) == "" && Control.ToUpper() == "SELFRESIGNATION"))
                {
                    //FOR SELF EMPLOYEE
                    SMHR_EMPRESIGNATION _obj_smhr_resignation = new SMHR_EMPRESIGNATION();
                    _obj_smhr_resignation.MODE = 11;
                    _obj_smhr_resignation.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_resignation.EMPREG_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                    DataTable dtDetails = BLL.get_Resignation(_obj_smhr_resignation);
                    Rg_EmpResg.DataSource = dtDetails;
                }
                else
                {
                    BLL.ShowMessage(this, "You do not have Access on this Screen.");
                    return;
                }
            }
            else
            {
                //FOR ADMIN
                SMHR_EMPRESIGNATION _obj_Resg = new SMHR_EMPRESIGNATION();
                _obj_Resg.OPERATION = operation.Select;
                _obj_Resg.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Resg.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                DataTable dt = BLL.get_Empresignation(_obj_Resg);
                Rg_EmpResg.DataSource = dt;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Resignation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        bool NotificationStatus = false;
        try
        {
            SMHR_EMPRESIGNATION _obj_Smhr_Empresignation = new SMHR_EMPRESIGNATION();
            SMHR_EMPLOYEE_EXIT_INTERVIEW _obj_smhr_Empexitinterview = new SMHR_EMPLOYEE_EXIT_INTERVIEW();

            _obj_Smhr_Empresignation.EMPREG_EMP_ID = Convert.ToInt32(rcmb_EmployeeCode.SelectedItem.Value);
            //if (Convert.ToDateTime(rdtp_ResignationDate.SelectedDate) >= Convert.ToDateTime(DateTime.Now.Date))
            //{
            _obj_Smhr_Empresignation.EMPREG_REGDATE = Convert.ToDateTime(rdtp_ResignationDate.SelectedDate);
            //}
            //else
            //{
            //    BLL.ShowMessage(this, "Applied date should be current or future date");
            //    return;
            //}
            _obj_Smhr_Empresignation.EMPREG_REASON = Convert.ToInt32(rcmb_Reasonresg.SelectedItem.Value);
            _obj_Smhr_Empresignation.EMPREG_REMARKS = BLL.ReplaceQuote(rtxt_Remarks.Text);

            if (rdtp_RelievingDate.SelectedDate != null)
                _obj_Smhr_Empresignation.EMPREG_RELDATE = Convert.ToDateTime(rdtp_RelievingDate.SelectedDate);
            else
                _obj_Smhr_Empresignation.EMPREG_RELDATE = null;


            _obj_Smhr_Empresignation.EMPREG_CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_Empresignation.EMPREG_CREATEDDATE = DateTime.Now;

            _obj_Smhr_Empresignation.EMPREG_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_Empresignation.EMPREG_LASTMDFDATE = DateTime.Now;
            if (rad_Department.SelectedIndex > 0)
            {
                _obj_Smhr_Empresignation.EMPREG_DEPT_ID = Convert.ToInt32(rad_Department.SelectedValue);
            }
            else
            {
                _obj_Smhr_Empresignation.EMPREG_DEPT_ID = 0;
            }
            _obj_Smhr_Empresignation.EMPREG_IS_TERMINATED = Convert.ToBoolean(chk_ImmediateTermination.Checked);
            _obj_Smhr_Empresignation.EMP_EXIT_INTERVIEW_PRIMARY_REASON = txt_PrimaryReason.Text;
            _obj_Smhr_Empresignation.EMP_EXIT_INTERVIEW_JOB_SATISFACTION = txt_jobSatisfying.Text;
            _obj_Smhr_Empresignation.EMP_EXIT_INTERVIEW_JOB_FRUSTRATION = txt_jobfrustrating.Text;
            _obj_Smhr_Empresignation.EMP_EXIT_INTERVIEW_SUGGESTION = txt_jobsuggestion.Text;
            _obj_Smhr_Empresignation.EMP_EXIT_INTERVIEW_COMPANY_MEASURES = txt_Resignationprevention.Text;


            _obj_smhr_Empexitinterview.EMP_EXIT_INTERVIEW_EMP_ID = Convert.ToInt32(rcmb_EmployeeCode.SelectedItem.Value);

            //_obj_smhr_Empexitinterview.EMP_EXIT_INTERVIEW_PRIMARY_REASON = txt_PrimaryReason.Text;
            //_obj_smhr_Empexitinterview.EMP_EXIT_INTERVIEW_JOB_SATISFACTION = txt_jobSatisfying.Text;
            //_obj_smhr_Empexitinterview.EMP_EXIT_INTERVIEW_JOB_FRUSTRATION = txt_jobfrustrating.Text;
            //_obj_smhr_Empexitinterview.EMP_EXIT_INTERVIEW_SUGGESTION = txt_jobsuggestion.Text;
            //_obj_smhr_Empexitinterview.EMP_EXIT_INTERVIEW_COMPANY_MEASURES = txt_Resignationprevention.Text;

            //To add EMPREG_IsRsgndWthOutApprvl
            string qrystrng = Convert.ToString(Request.QueryString["Control"]);
            if (string.IsNullOrEmpty(qrystrng))
            {
                if (chkResignApproval.Checked)
                    _obj_Smhr_Empresignation.EMPREG_IsRsgndWthOutApprvl = Convert.ToBoolean(chkResignApproval.Checked);
            }

            if (hdncontrol.Value != string.Empty)
            {
                if (Control.ToUpper() == "SELFRESIGNATION")
                    _obj_Smhr_Empresignation.EMPREG_FRM_STS = "S";
            }
            else
                _obj_Smhr_Empresignation.EMPREG_FRM_STS = "A";


            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_EDIT":

                    _obj_Smhr_Empresignation.EMPREG_ID = Convert.ToInt32(lbl_EmpregID.Text);
                    _obj_Smhr_Empresignation.OPERATION = operation.Empty;
                    //_obj_Smhr_Empresignation.OPERATION = operation.Check1;
                    _obj_Smhr_Empresignation.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    if (BLL.set_Empresignation(_obj_Smhr_Empresignation))
                    {
                        if (chk_ImmediateTermination.Checked)
                        {
                            BLL.ShowMessage(this, "Employee Terminated");
                            //Ragha Sudha on 15-Nov-2013
                            NotificationStatus = BLL.send_EmployeeTerminationNotification(_obj_Smhr_Empresignation);
                            if (NotificationStatus)
                            {
                                BLL.ShowMessage(this, "Termination Notification Sent");
                            }
                        }
                        else
                        {
                            if (!chkResignApproval.Checked)
                                BLL.ShowMessage(this, "Submitted for Approval");
                        }
                        //if (BLL.set_EmpresignationExitInterview(_obj_smhr_Empexitinterview))
                        //{
                        //BLL.ShowMessage(this, "Exit Interview results Captured");
                        Rm_EmpResg_page.SelectedIndex = 0;
                        LoadGrid();
                        Rg_EmpResg.DataBind();
                        //}
                    }
                    else
                        BLL.ShowMessage(this, "Information Not Saved");

                    break;
                case "BTN_SAVE":
                    //_obj_Smhr_Empresignation.OPERATION = operation.EMPTY1;
                    _obj_Smhr_Empresignation.OPERATION = operation.Validate;
                    _obj_Smhr_Empresignation.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Smhr_Empresignation.EMPREG_EMP_ID = Convert.ToInt32(rcmb_EmployeeCode.SelectedValue);

                    ////To add EMPREG_IsRsgndWthOutApprvl
                    //string qrystrng = Convert.ToString(Request.QueryString["Control"]);
                    //if (string.IsNullOrEmpty(qrystrng))
                    //{
                    //    if (chkResignApproval.Checked)
                    //        _obj_Smhr_Empresignation.EMPREG_IsRsgndWthOutApprvl = Convert.ToBoolean(chkResignApproval.Checked);
                    //}

                    DataTable dt = BLL.get_Empresignation(_obj_Smhr_Empresignation);
                    if (dt.Rows.Count == 0)
                    {
                        _obj_Smhr_Empresignation.OPERATION = operation.Insert;
                        _obj_Smhr_Empresignation.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        if (BLL.set_Empresignation(_obj_Smhr_Empresignation))
                        {
                            if (chk_ImmediateTermination.Checked)
                            {
                                BLL.ShowMessage(this, "Employee Terminated");
                                //Ragha Sudha on 15-Nov-2013
                                NotificationStatus = BLL.send_EmployeeTerminationNotification(_obj_Smhr_Empresignation);
                                if (NotificationStatus)
                                {
                                    BLL.ShowMessage(this, "Termination Notification Sent");
                                }
                            }
                            else
                            {
                                if (!chkResignApproval.Checked)
                                    BLL.ShowMessage(this, "Submitted for Approval");
                            }
                            //if (BLL.set_EmpresignationExitInterview(_obj_smhr_Empexitinterview))
                            //{

                            //    BLL.ShowMessage(this, "Exit Interview results Captured");
                            Rm_EmpResg_page.SelectedIndex = 0;
                            LoadGrid();
                            Rg_EmpResg.DataBind();
                            return;
                            //  }
                        }
                        else
                        {
                            BLL.ShowMessage(this, "Information Not Saved");
                            return;
                        }

                    }
                    else
                    {
                        BLL.ShowMessage(this, "Selected Employee Applied Resignation already done");
                        return;
                    }
                    break;
                default:
                    break;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Resignation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

    }

    protected void clearControls()
    {
        try
        {
            pnl_ExitInterview.Visible = false;
            lbl_EmpregID.Text = string.Empty;
            rcmb_EmployeeCode.SelectedIndex = -1;
            rcmb_Reasonresg.SelectedIndex = -1;
            rdtp_ResignationDate.SelectedDate = null;
            rdtp_RelievingDate.SelectedDate = null;
            rtxt_Remarks.Text = string.Empty;
            rdtp_ResignationDate.MinDate = Convert.ToDateTime("01/01/1900");
            rdtp_ResignationDate.MaxDate = Convert.ToDateTime("12/12/2099");
            btn_Save.Visible = false;
            btn_Edit.Visible = false;
            Rm_EmpResg_page.SelectedIndex = 0;
            chk_ImmediateTermination.Checked = false;
            chk_ImmediateTermination.Enabled = true;
            txt_jobfrustrating.Text = string.Empty;
            txt_jobSatisfying.Text = string.Empty;
            txt_jobsuggestion.Text = string.Empty;
            txt_PrimaryReason.Text = string.Empty;
            txt_Resignationprevention.Text = string.Empty;
            rad_Directorate.Items.Clear();
            rad_Directorate.Items.Insert(0, new RadComboBoxItem("Select"));
            rad_Department.Items.Clear();
            rad_Department.Items.Insert(0, new RadComboBoxItem("Select"));
            rad_Directorate.Enabled = true;
            rad_Department.Enabled = true;
            chkResignApproval.Checked = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Resignation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            // clearControls();
            Rm_EmpResg_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Resignation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            //if (Convert.ToString(Session["SELFSERVICE"]) == "")
            //if (Convert.ToInt32(Session["EMP_ID"]) == 0)
            //if ((Convert.ToString(Session["SELFSERVICE"]) == "") || (Convert.ToInt32(Session["EMP_ID"]) == 0))
            if (Control == null)
            {
                loadDropdown();
                clearControls();
                rcmb_EmployeeCode.Enabled = true;
                rcmb_EmpReg_BU.Enabled = true;
                Rm_EmpResg_page.SelectedIndex = 1;
                btn_Save.Visible = true;
                btn_ExitInterview.Visible = true;
                btn_ExitInterview.Text = "Show ExitInterview";
                rad_Directorate.Enabled = true;
                rad_Department.Enabled = true;
                chkResignApproval.Enabled = true;
            }
            else
            {
                clearControls();
                loadDropdown();
                // rcmb_EmpReg_BU.SelectedIndex = 1;
                // rcmb_EmpReg_BU_SelectedIndexChanged(null, null);
                rcmb_EmployeeCode.SelectedIndex = rcmb_EmployeeCode.FindItemIndexByValue(Convert.ToString(Session["EMP_ID"]));
                rcmb_EmployeeCode.Enabled = false;
                rcmb_EmpReg_BU.Enabled = false;
                rad_Directorate.Enabled = false;
                rad_Department.Enabled = false;
                chk_ImmediateTermination.Enabled = false;
                chkResignApproval.Enabled = false;
                Rm_EmpResg_page.SelectedIndex = 1;
                btn_Save.Visible = true;
            }
            rdtp_ResignationDate.SelectedDate = DateTime.Now;
            rdtp_ResignationDate.MaxDate = DateTime.Now;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Resignation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void lnk_Delete_Command(object sender, CommandEventArgs e)
    { }

    protected void Rg_EmpResg_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Resignation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void LoadEmployees()
    {
        try
        {
            SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
            //_obj_smhr_emp_payitems.OPERATION = operation.Empty;
            DataTable DT_Details = new DataTable();
            if (rcmb_EmpReg_BU.SelectedItem.Value != "")
            {
                #region MyRegion
                //if (Convert.ToString(Session["SELFSERVICE"]) == "")
                //{
                //    _obj_smhr_emp_payitems.OPERATION = operation.Empty_Self;
                //    _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(rcmb_EmpReg_BU.SelectedItem.Value);
                //    _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //    _obj_smhr_emp_payitems.REPORTING_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                //    DT_Details = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
                //    if (DT_Details.Rows.Count != 0)
                //    {
                //        BindEmployees(DT_Details);
                //    }
                //    else
                //    {
                //        BindEmployees(DT_Details);
                //    }
                //}
                //else
                //{ 
                #endregion

                _obj_smhr_emp_payitems.OPERATION = operation.Empty;
                _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(rcmb_EmpReg_BU.SelectedItem.Value);
                _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                if (rad_Directorate.SelectedIndex > 0)
                {
                    _obj_smhr_emp_payitems.OPERATION = operation.EmployeesDirectoratewise;
                    _obj_smhr_emp_payitems.DIRECTORATE_ID = Convert.ToInt32(rad_Directorate.SelectedItem.Value);
                }
                if (rad_Department.SelectedIndex > 0)
                {
                    _obj_smhr_emp_payitems.OPERATION = operation.EmployeesDepartmentwise;
                    _obj_smhr_emp_payitems.DEPARTMENT_ID = Convert.ToInt32(rad_Department.SelectedItem.Value);
                }
                DT_Details = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
                if (DT_Details.Rows.Count != 0)
                {
                    BindEmployees(DT_Details);
                }
                else
                {
                    BindEmployees(DT_Details);
                }
                //}
            }
            else
            {
                BindEmployees(DT_Details);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Resignation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void LoadEmployees_Edit()
    {
        try
        {
            SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
            //_obj_smhr_emp_payitems.OPERATION = operation.Empty;
            DataTable DT_Details = new DataTable();
            if (rcmb_EmpReg_BU.SelectedItem.Value != "")
            {
                _obj_smhr_emp_payitems.OPERATION = operation.Empty1;
                _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(rcmb_EmpReg_BU.SelectedItem.Value);
                _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DT_Details = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
                if (DT_Details.Rows.Count != 0)
                {
                    BindEmployees(DT_Details);
                }
                else
                {
                    BindEmployees(DT_Details);
                }

            }
            else
            {
                BindEmployees(DT_Details);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Resignation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    private void BindEmployees(DataTable DT_Details)
    {
        try
        {
            rcmb_EmployeeCode.DataSource = DT_Details;
            rcmb_EmployeeCode.DataTextField = "EMPNAME";
            rcmb_EmployeeCode.DataValueField = "EMP_ID";
            rcmb_EmployeeCode.DataBind();
            rcmb_EmployeeCode.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Resignation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

        }
    }

    private string LoadEmpBU(int EMP_ID)
    {
        try
        {
            //rcmb_EmpReg_BU.Items.Clear();
            SMHR_EMPASSETDOC _obj_smhr_empassetdoc = new SMHR_EMPASSETDOC();
            _obj_smhr_empassetdoc.EMPASSETDOC_EMP_ID = Convert.ToInt32(EMP_ID);
            _obj_smhr_empassetdoc.OPERATION = operation.Select;
            _obj_smhr_empassetdoc.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_BU = BLL.get_EmpAssetDocBU(_obj_smhr_empassetdoc);
            if (dt_BU.Rows.Count > 0)
                return Convert.ToString(dt_BU.Rows[0]["BUSINESSUNIT_ID"]);

            else
                return "";
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Resignation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return null;

        }

    }

    protected void rad_Directorate_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rad_Department.Items.Clear();
            LoadDepartment();
            rcmb_EmployeeCode.Items.Clear();
            LoadEmployees();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Resignation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void rcmb_EmpReg_BU_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            LoadEmployees();
            Load_Directorate();
            LoadDepartment();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Resignation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

        }
    }
    protected void rcmb_EmployeeCode_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
            _obj_smhr_logininfo.OPERATION = operation.Select3;
            if (rcmb_EmployeeCode.SelectedIndex > 0)
            {
                _obj_smhr_logininfo.LOGIN_EMP_ID = Convert.ToInt32(rcmb_EmployeeCode.SelectedItem.Value);
            }
            else
            {
                _obj_smhr_logininfo.LOGIN_EMP_ID = 0;
            }
            _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_emp = BLL.get_LoginInfo(_obj_smhr_logininfo);
            if (dt_emp != null)
            {
                if (dt_emp.Rows.Count > 0)
                {
                    rdtp_ResignationDate.MinDate = Convert.ToDateTime(dt_emp.Rows[0]["EMP_DOJ"]);
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Resignation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Type_Save_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_Smhr_Masters = new SMHR_MASTERS();
            _obj_Smhr_Masters.MASTER_TYPE = "RESIGNATION";
            _obj_Smhr_Masters.MASTER_CODE = txt_Asset_Type.Text.Replace("'", "''");
            _obj_Smhr_Masters.MASTER_DESC = txt_Asset_Type.Text.Replace("'", "''");
            _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_Smhr_Masters.ISDELETED = false;
            _obj_Smhr_Masters.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_Masters.CREATEDDATE = DateTime.Now;
            _obj_Smhr_Masters.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_Masters.LASTMDFDATE = DateTime.Now;

            _obj_Smhr_Masters.OPERATION = operation.Check;
            if (Convert.ToString(BLL.get_MasterRecords(_obj_Smhr_Masters).Rows[0]["Count"]) != "0")
            {
                BLL.ShowMessage(this, "Type Already Exists");
                return;

            }
            _obj_Smhr_Masters.OPERATION = operation.Insert;
            if (BLL.set_Master(_obj_Smhr_Masters))
            {
                _obj_Smhr_Masters = new SMHR_MASTERS();
                rcmb_Reasonresg.Items.Clear();
                _obj_Smhr_Masters.OPERATION = operation.Select;
                _obj_Smhr_Masters.MASTER_TYPE = "RESIGNATION";
                _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                rcmb_Reasonresg.DataSource = BLL.get_MasterRecords(_obj_Smhr_Masters);
                rcmb_Reasonresg.DataTextField = "HR_MASTER_CODE";
                rcmb_Reasonresg.DataValueField = "HR_MASTER_ID";
                rcmb_Reasonresg.DataBind();
                rcmb_Reasonresg.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select ", "0"));
                txt_Asset_Type.Text = string.Empty;
            }
            else
                BLL.ShowMessage(this, "Information Not Saved");
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Resignation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

        }
    }
    protected void btn_ExitInterview_Click(object sender, EventArgs e)
    {
        try
        {
            if (!pnl_ExitInterview.Visible)
            {
                pnl_ExitInterview.Visible = true;
                btn_ExitInterview.Text = "Hide ExitInterview";
            }
            else
            {
                pnl_ExitInterview.Visible = false;
                btn_ExitInterview.Text = "Show ExitInterview";
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Resignation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

        }

    }
    protected void Load_Directorate()
    {
        try
        {
            rad_Directorate.Items.Clear();
            if (Convert.ToString(Session["ORG_ID"]) != string.Empty)
            {
                if (rcmb_EmpReg_BU.SelectedIndex > 0)
                {
                    SMHR_DIRECTORATE _obj_Smhr_Directorate = new SMHR_DIRECTORATE();
                    _obj_Smhr_Directorate.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Smhr_Directorate.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_EmpReg_BU.SelectedValue);
                    DataTable DT = BLL.get_Directorate(_obj_Smhr_Directorate);
                    rad_Directorate.DataTextField = "DIRECTORATE_CODE";
                    rad_Directorate.DataValueField = "DIRECTORATE_ID";
                    rad_Directorate.DataSource = DT;
                    rad_Directorate.DataBind();
                    rad_Directorate.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                }
                else
                {
                    rad_Directorate.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                }
            }
            else
            {
                rad_Directorate.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Resignation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

    }
    private void LoadDepartment()
    {
        try
        {
            if (rcmb_EmpReg_BU.SelectedIndex != 0)
            {
                _obj_SMHR_Department = new SMHR_DEPARTMENT();
                _obj_SMHR_Department.MODE = 7;
                if (rad_Directorate.SelectedIndex > 0)
                {
                    _obj_SMHR_Department.DIRECTORATE_ID = Convert.ToInt32(rad_Directorate.SelectedValue);
                }
                else
                {
                    _obj_SMHR_Department.MODE = 16;
                    _obj_SMHR_Department.DIRECTORATE_ID = 0;
                }
                _obj_SMHR_Department.BUID = Convert.ToInt32(rcmb_EmpReg_BU.SelectedValue);
                DataTable dt = BLL.get_Department(_obj_SMHR_Department);
                rad_Department.DataSource = dt;
                rad_Department.DataTextField = "DEPARTMENT_NAME";
                rad_Department.DataValueField = "DEPARTMENT_ID";
                rad_Department.DataBind();
                rad_Department.Items.Insert(0, new RadComboBoxItem("Select"));
            }
            else
            {
                rad_Department.Items.Clear();
                rad_Department.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Resignation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void rad_Department_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            LoadEmployees();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Resignation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
}
