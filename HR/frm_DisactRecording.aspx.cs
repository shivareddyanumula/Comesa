using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using System.IO;
using Telerik.Web.UI;

public partial class HR_frm_DisactRecording : System.Web.UI.Page
{
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
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
            if (!Page.IsPostBack)
            {
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();
                Control = Convert.ToString(Request.QueryString["Control"]);
                if (Control != null)
                {
                    if (Control.ToUpper() == "SELFDISCIPLINARYNOTES")
                    {
                        _obj_Smhr_LoginInfo.LOGIN_ID = 12;
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("DISCIPLINARY NOTES ON EMPLOYEE");
                    }
                }
                else
                {
                    _obj_Smhr_LoginInfo.LOGIN_ID = 2;
                    _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("DISPLINARYNOTESONEMPLOYEE");
                }
                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //_obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("DISPLINARYNOTESONEMPLOYEE");
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
                    Rg_DisactRec.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Save.Visible = false;
                    btn_Edit.Visible = false;
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


                BLL.ChangeDateFormat(Convert.ToString(Session["EMP_ID"]), rdtp_DisactRecDate, rdtp_DisactRecDOJ);
                BLL.gridDateFormat(Convert.ToString(Session["EMP_ID"]), Rg_DisactRec, "EMPDSPACT_DATE");

                //if (Control != null)
                //{
                //    if (Control.ToUpper() == "SELFDISCIPLINARYNOTES")
                //    {
                //        Session["SELF_DSPACT"] = "SELFDISCIPLINARYNOTES";
                //    }
                //}

            }
            Page.Validate();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_DisactRecording", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {

        try
        {
            loadDropdown();
            clearControls();
            SMHR_EMPDISCIPLINARYACTION _obj_Displinary = new SMHR_EMPDISCIPLINARYACTION();
            _obj_Displinary.OPERATION = operation.Select;
            _obj_Displinary.EMPDSPACT_ID = Convert.ToInt32(e.CommandArgument);
            _obj_Displinary.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_EmpDiscNotes(_obj_Displinary);
            rcmb_DisactRecBU.SelectedIndex = rcmb_DisactRecBU.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["EMPDSPACT_BUID"]));
            LoadEmployees_Edit();
            //lbl_DisactRecID.Text = Convert.ToString(dt.Rows[0]["EMPDSPACT_ID"]);
            HF_ID.Value = Convert.ToString(dt.Rows[0]["EMPDSPACT_ID"]);
            rcmb_DisactRecEmpID.SelectedIndex = rcmb_DisactRecEmpID.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["EMPDSPACT_EMPID"]));
            rcmb_DisactRecEmpID_SelectedIndexChanged(null, null);
            rcmb_DisactRecManagerID.SelectedIndex = rcmb_DisactRecManagerID.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["EMPDSPACT_RPTMNGID"]));
            rcmb_DisactRecManagerID.Enabled = false;
            rtxt_DisactRecRemarks.Text = Convert.ToString(dt.Rows[0]["EMPDSPACT_REMARKS"]);
            rtxt_DisactRecReason.Text = Convert.ToString(dt.Rows[0]["EMPDSPACT_REASON"]);
            rdtp_DisactRecDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["EMPDSPACT_DATE"]);

            if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["EMPDSPACT_ATTACHMENT"])))
            {
                if (File.Exists(Server.MapPath(Convert.ToString(dt.Rows[0]["EMPDSPACT_ATTACHMENT"]))))
                {
                    lnk_fupAttachment.Visible = true;
                    lnk_fupAttachment.OnClientClick = "javascript:window.open('../" + Convert.ToString(dt.Rows[0]["EMPDSPACT_ATTACHMENT"]).TrimStart('~', '/') + "');return false;";
                    ViewState["fileLocation"] = Convert.ToString(dt.Rows[0]["EMPDSPACT_ATTACHMENT"]);
                }
            }

            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Edit.Visible = false;

            }

            else
            {

                //if (Control != null)
                //{
                //if (Convert.ToString(Session["SELF_DSPACT"]) == "SELFIDENTIFICATION")
                if (Control != null)
                {
                    if ((Convert.ToString(Session["SELFSERVICE"]) == "true" && Control.ToUpper() == "SELFDISCIPLINARYNOTES") || (Convert.ToString(Session["SELFSERVICE"]) == "" && Control.ToUpper() == "SELFDISCIPLINARYNOTES"))
                    {
                        btn_Edit.Visible = false;
                    }
                }
                //}
                else
                {
                    btn_Edit.Visible = true;
                }
            }

            rcmb_DisactRecBU.Enabled = false;
            rcmb_DisactRecEmpID.Enabled = false;
            Rm_DR_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_DisactRecording", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            loadDropdown();
            clearControls();
            rcmb_DisactRecManagerID.Enabled = true;
            btn_Save.Visible = true;
            Rm_DR_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_DisactRecording", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void LoadGrid()
    {

        try
        {
            if (Control != null)
            {
                if ((Convert.ToString(Session["SELFSERVICE"]) == "true" && Control.ToUpper() == "SELFDISCIPLINARYNOTES") || (Convert.ToString(Session["SELFSERVICE"]) == "" && Control.ToUpper() == "SELFDISCIPLINARYNOTES"))
                {
                    SMHR_EMPDISCIPLINARYACTION _obj_Smhr_EmpdisciplinaryAction = new SMHR_EMPDISCIPLINARYACTION();
                    _obj_Smhr_EmpdisciplinaryAction.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Smhr_EmpdisciplinaryAction.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                    _obj_Smhr_EmpdisciplinaryAction.OPERATION = operation.Self;
                    DataTable DT = BLL.get_EmpDiscNotes(_obj_Smhr_EmpdisciplinaryAction);
                    Rg_DisactRec.DataSource = DT;
                    //Rg_DisactRec.DataBind();
                    clearControls();
                    Rg_DisactRec.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;


                }
                else
                {
                    BLL.ShowMessage(this, "You do not have access on this screen.");
                    return;
                }

            }
            //}
            //else if (Convert.ToString(Session["SELFSERVICE"]) == "")
            //{
            //    SMHR_EMPDISCIPLINARYACTION _obj_Smhr_EmpdisciplinaryAction = new SMHR_EMPDISCIPLINARYACTION();
            //    _obj_Smhr_EmpdisciplinaryAction.OPERATION = operation.Select_Self;
            //    _obj_Smhr_EmpdisciplinaryAction.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //    _obj_Smhr_EmpdisciplinaryAction.EMPDSPACT_RPTMNGID = Convert.ToInt32(Session["EMP_ID"]);
            //    DataTable DT = BLL.get_EmpDiscNotes(_obj_Smhr_EmpdisciplinaryAction);
            //    Rg_DisactRec.DataSource = DT;
            //    //Rg_DisactRec.DataBind();
            //    clearControls();
            //}
            else
            {
                SMHR_EMPDISCIPLINARYACTION _obj_Smhr_EmpdisciplinaryAction = new SMHR_EMPDISCIPLINARYACTION();
                _obj_Smhr_EmpdisciplinaryAction.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_EmpdisciplinaryAction.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                DataTable DT = BLL.get_EmpDiscNotes(_obj_Smhr_EmpdisciplinaryAction);
                Rg_DisactRec.DataSource = DT;
                //Rg_DisactRec.DataBind();
                clearControls();

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_DisactRecording", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void loadDropdown()
    {
        try
        {
            rcmb_DisactRecBU.Items.Clear();
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            rcmb_DisactRecBU.DataSource = dt_BUDetails;
            rcmb_DisactRecBU.DataValueField = "BUSINESSUNIT_ID";
            rcmb_DisactRecBU.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_DisactRecBU.DataBind();
            rcmb_DisactRecBU.Items.Insert(0, new RadComboBoxItem("Select"));
            rcmb_DisactRecEmpID.Items.Clear();
            rcmb_DisactRecManagerID.Items.Clear();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_DisactRecording", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_EMPDISCIPLINARYACTION _obj_Smhr_EmpDisciplinaryAction = new SMHR_EMPDISCIPLINARYACTION();
            _obj_Smhr_EmpDisciplinaryAction.EMPDSPACT_BUID = Convert.ToInt32(rcmb_DisactRecBU.SelectedValue);
            _obj_Smhr_EmpDisciplinaryAction.EMPDSPACT_EMPID = Convert.ToInt32(rcmb_DisactRecEmpID.SelectedItem.Value);
            _obj_Smhr_EmpDisciplinaryAction.EMPDSPACT_RPTMNGID = Convert.ToInt32(rcmb_DisactRecManagerID.SelectedItem.Value);
            _obj_Smhr_EmpDisciplinaryAction.EMPDSPACT_REMARKS = BLL.ReplaceQuote(rtxt_DisactRecRemarks.Text);
            _obj_Smhr_EmpDisciplinaryAction.EMPDSPACT_REASON = BLL.ReplaceQuote(rtxt_DisactRecReason.Text);
            _obj_Smhr_EmpDisciplinaryAction.EMPDSPACT_DATE = Convert.ToDateTime(rdtp_DisactRecDate.SelectedDate);

            if (!string.IsNullOrEmpty(fupAttachment.PostedFile.FileName))
            {
                fupAttachment.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Attachments"), fupAttachment.FileName));
                _obj_Smhr_EmpDisciplinaryAction.EMPDSPACT_ATTACHMENT = "~/Attachments/" + fupAttachment.FileName;
            }
            else
            {
                if (ViewState["fileLocation"] != null)
                    _obj_Smhr_EmpDisciplinaryAction.EMPDSPACT_ATTACHMENT = Convert.ToString(ViewState["fileLocation"]);
            }
            // _obj_Smhr_EmpDisciplinaryAction.EMPDSPACT_ATTACHMENT = "";
            _obj_Smhr_EmpDisciplinaryAction.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_EmpDisciplinaryAction.CREATEDDATE = DateTime.Now;

            _obj_Smhr_EmpDisciplinaryAction.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_EmpDisciplinaryAction.LASTMDFDATE = DateTime.Now;
            _obj_Smhr_EmpDisciplinaryAction.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            SMHR_EMPLOYEE _obj_smhr_employee = new SMHR_EMPLOYEE();
            _obj_smhr_employee.OPERATION = operation.Select;
            _obj_smhr_employee.EMP_ID = Convert.ToInt32(rcmb_DisactRecEmpID.SelectedItem.Value);
            //dt_Details = new DataTable();
            _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Details = BLL.get_Employee(_obj_smhr_employee);
            if (Convert.ToInt32(dt_Details.Rows[0]["EMP_STATUS"]) == 2)
            {
                BLL.ShowMessage(this, "Employee is Relieved.You can not update the record.");
                return;
            }
            else if (Convert.ToInt32(dt_Details.Rows[0]["EMP_STATUS"]) == 3)
            {
                BLL.ShowMessage(this, "Employee is Rehired.You can not update the record.");
                return;
            }
            //else if (Convert.ToInt32(dt_Details.Rows[0]["EMP_STATUS"]) == 3)
            //{
            //    BLL.ShowMessage(this, "Employee is Rehired.You can not update the record.");
            //    return;
            //}
            else
            {
                switch (((Button)sender).ID.ToUpper())
                {
                    case "BTN_EDIT":
                        _obj_Smhr_EmpDisciplinaryAction.EMPDSPACT_ID = Convert.ToInt32(HF_ID.Value);//Convert.ToInt32(lbl_DisactRecID.Text);
                        _obj_Smhr_EmpDisciplinaryAction.OPERATION = operation.Update;
                        if (BLL.set_EmpDiscNotes(_obj_Smhr_EmpDisciplinaryAction))
                            BLL.ShowMessage(this, "Information Updated Successfully");
                        else
                            BLL.ShowMessage(this, "Information Not Saved");

                        break;
                    case "BTN_SAVE":
                        _obj_Smhr_EmpDisciplinaryAction.OPERATION = operation.Insert;
                        if (BLL.set_EmpDiscNotes(_obj_Smhr_EmpDisciplinaryAction))
                            BLL.ShowMessage(this, "Information Saved Successfully");
                        else
                            BLL.ShowMessage(this, "Information Not Saved");
                        break;
                    default:
                        break;
                }
            }
            Rm_DR_page.SelectedIndex = 0;
            LoadGrid();
            Rg_DisactRec.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_DisactRecording", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void clearControls()
    {
        try
        {
            //lbl_DisactRecID.Text = string.Empty;
            HF_ID.Value = null;
            rcmb_DisactRecEmpID.SelectedIndex = -1;
            rcmb_DisactRecManagerID.SelectedIndex = -1;
            rtxt_DisactRecRemarks.Text = string.Empty;
            rtxt_DisactRecReason.Text = string.Empty;
            rdtp_DisactRecDate.SelectedDate = null;
            lnk_fupAttachment.Visible = false;
            rdtp_DisactRecDOJ.SelectedDate = null;
            rcmb_DisactRecBU.Enabled = true;
            rcmb_DisactRecEmpID.Enabled = true;
            btn_Save.Visible = false;
            btn_Edit.Visible = false;
            Rm_DR_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_DisactRecording", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_DisactRecording", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rg_DisactRec_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_DisactRecording", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_DisactRecEmpID_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {

        try
        {
            LoadReportingEmployees();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_DisactRecording", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_DisactRecBU_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_DisactRecBU.SelectedIndex != 0)
            {
                LoadEmployees();
            }
            else
            {
                rcmb_DisactRecEmpID.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_DisactRecording", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadReportingEmployees()
    {
        try
        {
            //if (Convert.ToString(rcmb_DisactRecEmpID.SelectedItem.Value) != "-1")
            if (rcmb_DisactRecEmpID.SelectedIndex > 0)
            {
                SMHR_EMPDISCIPLINARYACTION _obj_Smhr_EmpDisciplinaryAction = new SMHR_EMPDISCIPLINARYACTION();
                _obj_Smhr_EmpDisciplinaryAction.OPERATION = operation.Empty;
                _obj_Smhr_EmpDisciplinaryAction.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt = BLL.get_EmpDiscNotes(_obj_Smhr_EmpDisciplinaryAction);
                dt.DefaultView.RowFilter = " EMP_ID <> " + Convert.ToString(rcmb_DisactRecEmpID.SelectedItem.Value);
                dt = dt.DefaultView.ToTable();
                rcmb_DisactRecManagerID.Items.Clear();
                rcmb_DisactRecManagerID.DataSource = dt;
                rcmb_DisactRecManagerID.DataTextField = "EMPNAME";
                rcmb_DisactRecManagerID.DataValueField = "EMP_ID";
                rcmb_DisactRecManagerID.DataBind();


                SMHR_EMPLOYEE _obj_Smhr_Employee = new SMHR_EMPLOYEE();
                _obj_Smhr_Employee.OPERATION = operation.Select;
                _obj_Smhr_Employee.EMP_ID = Convert.ToInt32(rcmb_DisactRecEmpID.SelectedItem.Value);
                _obj_Smhr_Employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);//BASED ON THE ORGANISATION DISPLAYING EMPLOYEE
                dt = new DataTable();
                dt = BLL.get_Employee(_obj_Smhr_Employee);
                if (dt.Rows.Count > 0)
                {
                    rcmb_DisactRecManagerID.SelectedIndex = rcmb_DisactRecManagerID.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["EMP_REPORTINGEMPLOYEE"]));
                    if (dt.Rows[0]["EMP_DOJ"] != DBNull.Value)
                        rdtp_DisactRecDOJ.SelectedDate = Convert.ToDateTime(Convert.ToString(dt.Rows[0]["EMP_DOJ"]));
                    // need to check with archan madam and sridevi madam
                }
                rcmb_DisactRecManagerID.Enabled = true;
            }
            else
            {
                rcmb_DisactRecManagerID.Items.Clear();
                rdtp_DisactRecDOJ.SelectedDate = null;
            }
            rcmb_DisactRecManagerID.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_DisactRecording", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadReportingEmployees_Edit()
    {
        try
        {
            //if (Convert.ToString(rcmb_DisactRecEmpID.SelectedItem.Value) != "-1")
            if (rcmb_DisactRecEmpID.SelectedIndex > 0)
            {
                SMHR_EMPDISCIPLINARYACTION _obj_Smhr_EmpDisciplinaryAction = new SMHR_EMPDISCIPLINARYACTION();
                _obj_Smhr_EmpDisciplinaryAction.OPERATION = operation.FILLEMP_Edit;
                _obj_Smhr_EmpDisciplinaryAction.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt = BLL.get_EmpDiscNotes(_obj_Smhr_EmpDisciplinaryAction);
                dt.DefaultView.RowFilter = " EMP_ID <> " + Convert.ToString(rcmb_DisactRecEmpID.SelectedItem.Value);
                dt = dt.DefaultView.ToTable();
                rcmb_DisactRecManagerID.Items.Clear();
                rcmb_DisactRecManagerID.DataSource = dt;
                rcmb_DisactRecManagerID.DataTextField = "EMPNAME";
                rcmb_DisactRecManagerID.DataValueField = "EMP_ID";
                rcmb_DisactRecManagerID.DataBind();


                SMHR_EMPLOYEE _obj_Smhr_Employee = new SMHR_EMPLOYEE();
                _obj_Smhr_Employee.OPERATION = operation.Select;
                _obj_Smhr_Employee.EMP_ID = Convert.ToInt32(rcmb_DisactRecEmpID.SelectedItem.Value);
                _obj_Smhr_Employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);//BASED ON THE ORGANISATION DISPLAYING EMPLOYEE
                dt = new DataTable();
                dt = BLL.get_Employee(_obj_Smhr_Employee);
                if (dt.Rows.Count > 0)
                {
                    rcmb_DisactRecManagerID.SelectedIndex = rcmb_DisactRecManagerID.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["EMP_REPORTINGEMPLOYEE"]));
                    if (dt.Rows[0]["EMP_DOJ"] != DBNull.Value)
                        rdtp_DisactRecDOJ.SelectedDate = Convert.ToDateTime(Convert.ToString(dt.Rows[0]["EMP_DOJ"]));
                    // need to check with archan madam and sridevi madam
                }
                rcmb_DisactRecManagerID.Enabled = true;
            }
            else
            {
                rcmb_DisactRecManagerID.Items.Clear();
                rdtp_DisactRecDOJ.SelectedDate = null;
            }
            rcmb_DisactRecManagerID.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_DisactRecording", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadEmployees()
    {
        try
        {
            SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
            //_obj_smhr_emp_payitems.OPERATION = operation.Empty;
            DataTable DT_Details = new DataTable();
            if (rcmb_DisactRecBU.SelectedItem.Value != "")
            {
                if (Convert.ToString(Session["SELFSERVICE"]) == "")
                {
                    //FOR MANAGER
                    _obj_smhr_emp_payitems.OPERATION = operation.Empty_Self;
                    _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(rcmb_DisactRecBU.SelectedItem.Value);
                    _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_emp_payitems.REPORTING_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
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
                    //FOR ADMIN
                    _obj_smhr_emp_payitems.OPERATION = operation.Empty;
                    _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(rcmb_DisactRecBU.SelectedItem.Value);
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
            }
            else
            {
                BindEmployees(DT_Details);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_DisactRecording", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadEmployees_Edit()
    {
        try
        {
            SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
            //_obj_smhr_emp_payitems.OPERATION = operation.Empty;
            DataTable DT_Details = new DataTable();
            if (rcmb_DisactRecBU.SelectedItem.Value != "")
            {
                //if (Convert.ToString(Session["SELFSERVICE"]) == "")
                //{
                //    //FOR MANAGER
                //    _obj_smhr_emp_payitems.OPERATION = operation.Empty_Self;
                //    _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(rcmb_DisactRecBU.SelectedItem.Value);
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
                //FOR ADMIN
                _obj_smhr_emp_payitems.OPERATION = operation.Empty1;
                _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(rcmb_DisactRecBU.SelectedItem.Value);
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
                //}
            }
            else
            {
                BindEmployees(DT_Details);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_DisactRecording", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void BindEmployees(DataTable DT_Details)
    {
        try
        {
            rcmb_DisactRecEmpID.DataSource = DT_Details;
            rcmb_DisactRecEmpID.DataTextField = "EMPNAME";
            rcmb_DisactRecEmpID.DataValueField = "EMP_ID";
            rcmb_DisactRecEmpID.DataBind();
            rcmb_DisactRecEmpID.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_DisactRecording", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
