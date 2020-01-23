using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using Telerik.Web.UI;

public partial class Payroll_frmHoldPayrollProcess1 : System.Web.UI.Page
{
    SMHR_LOGININFO _obj_Smhr_LoginInfo;
    SMHR_PERIOD _obj_smhr_period;
    SMHR_EMPLOYEE _obj_smhr_employee;
    SMHR_PAYROLL _obj_smhr_payroll;
    SMHR_ATTENDANCE _obj_Smhr_Attendance;
    SMHR_EMPLOYEE_INHOLD _obj_Smhr_Employee_Inhold;
    DataTable dt_Details;
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Hold Payroll Process");//EMPLOYEEPAYROLLHOLDPROCESS");
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
                    //rgMain.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    //btnSave.Visible = false;
                    //btnUpdate.Visible = false;
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
                //rgMain.Visible = false;
                loadCombos();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmHoldPayrollProcess", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmbBusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (!(rcmbBusinessUnit.SelectedIndex > 0))
            {
                ClearingControls();
            }
            else
            {
                loadPeriod();
                rcmbPeriodElement.Items.Clear();
                //trNote.Visible = false;
                //trChkAll.Visible = false;
                //rgMain.Visible = false;
                //btnSave.Visible = false;
                //btnUpdate.Visible = false;
                //btnCancel.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmHoldPayrollProcess", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmbPeriod_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmbBusinessUnit.SelectedIndex > 0)
            {
                if (rcmbPeriod.SelectedIndex > 0)
                {
                    _obj_smhr_payroll = new SMHR_PAYROLL();
                    _obj_smhr_payroll.PERIODDTLID = Convert.ToInt32(rcmbPeriod.SelectedValue);
                    _obj_smhr_payroll.MODE = 28;
                    dt_Details = BLL.get_payrolltrans(_obj_smhr_payroll);
                    if (dt_Details.Rows.Count != 0)
                    {
                        rcmbPeriodElement.DataSource = dt_Details;
                        rcmbPeriodElement.DataValueField = "PRDDTL_ID";
                        rcmbPeriodElement.DataTextField = "PRDDTL_NAME";
                        rcmbPeriodElement.DataBind();
                        rcmbPeriodElement.Items.Insert(0, new RadComboBoxItem("Select"));
                        //chkList.Items.Clear();
                        //trStruct.Visible = false;
                    }
                }
                else
                {
                    rcmbPeriodElement.Items.Clear();
                    rcmbPeriodElement.Items.Insert(0, new RadComboBoxItem("", ""));
                    //trStruct.Visible = false;
                }
            }
            else
            {
                rcmbPeriodElement.Items.Clear();
                rcmbPeriodElement.Items.Insert(0, new RadComboBoxItem("", ""));
                rcmbPeriod.ClearSelection();
                //chkList.Items.Clear();
                //trStruct.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmHoldPayrollProcess", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmbPeriodElement_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            loadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmHoldPayrollProcess", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void loadCombos()
    {
        try
        {
            // for loading the businessunits
            _obj_Smhr_LoginInfo = new SMHR_LOGININFO();
            _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            dt_Details = BLL.get_Business_Units(_obj_Smhr_LoginInfo);
            rcmbBusinessUnit.DataSource = dt_Details;
            rcmbBusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            rcmbBusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            rcmbBusinessUnit.DataBind();
            rcmbBusinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));

            // for loading the periods
            _obj_smhr_period = new SMHR_PERIOD();
            _obj_smhr_period.OPERATION = operation.Select;
            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_PeriodHeaderDetails(_obj_smhr_period);
            rcmbPeriod.DataSource = dt_Details;
            rcmbPeriod.DataTextField = "PERIOD_NAME";
            rcmbPeriod.DataValueField = "PERIOD_ID";
            rcmbPeriod.DataBind();
            rcmbPeriod.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmHoldPayrollProcess", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    protected void ClearingControls()
    {
        try
        {
            rcmbBusinessUnit.ClearSelection();
            rcmbPeriod.ClearSelection();
            rcmbPeriodElement.Items.Clear();
            rcmbPeriodElement.Items.Insert(0, new RadComboBoxItem("", ""));
            //trChkAll.Visible = false;
            //rgMain.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmHoldPayrollProcess", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void loadPeriod()
    {
        try
        {
            // for loading the periods
            _obj_smhr_period = new SMHR_PERIOD();
            _obj_smhr_period.OPERATION = operation.Select;
            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_PeriodHeaderDetails(_obj_smhr_period);
            rcmbPeriod.DataSource = dt_Details;
            rcmbPeriod.DataTextField = "PERIOD_NAME";
            rcmbPeriod.DataValueField = "PERIOD_ID";
            rcmbPeriod.DataBind();
            rcmbPeriod.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmHoldPayrollProcess", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void loadGrid()
    {
        try
        {
            if (rcmbPeriodElement.SelectedIndex > 0)
            {
                Label lblempid = new Label();
                CheckBox chk1 = new CheckBox();
                _obj_Smhr_Attendance = new SMHR_ATTENDANCE();
                //comented on 06.03.2013
                ////_obj_Smhr_Attendance = new SMHR_ATTENDANCE();
                ////_obj_Smhr_Attendance.OPERATION = operation.Select4;
                ////_obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmbBusinessUnit.SelectedValue);
                ////_obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmbPeriodElement.SelectedValue);
                ////_obj_Smhr_Attendance.ATTENDANCE_PERIOD_ID = Convert.ToInt32(rcmbPeriod.SelectedValue);
                ////DataTable dtPay = BLL.get_Attendance(_obj_Smhr_Attendance);
                ////if (dtPay.Rows.Count > 0)
                ////{
                ////    if ((Convert.ToString(dtPay.Rows.Count) == "2"))
                ////    {
                ////        if ((Convert.ToInt32(dtPay.Rows[0][0]) == 0) && (Convert.ToInt32(dtPay.Rows[1][0]) > 0))
                ////        {
                ////            rgMain.Visible = true;
                ////            trNote.Visible = true;
                ////            lblNote.Text = "NOTE : Operations not allowed as payroll has been approved";
                ////            loadPayGrid();

                ////        }
                ////        else if ((Convert.ToInt32(dtPay.Rows[0][0]) > 0) && (Convert.ToInt32(dtPay.Rows[1][0]) == 0))
                ////        {
                ////            rgMain.Visible = true;
                ////            trNote.Visible = true;
                ////            lblNote.Text = "NOTE : Operations not allowed as payroll is in pending status";
                ////            loadPayGrid();
                ////        }
                ////        else
                ////        {
                //trNote.Visible = false;
                rgMain.Visible = true;
                rgMain.Enabled = true;
                //trBtn.Visible = true;
                //trChkAll.Visible = true;
                _obj_Smhr_Employee_Inhold = new SMHR_EMPLOYEE_INHOLD();
                _obj_Smhr_Employee_Inhold.OPERATION = operation.Check;
                _obj_Smhr_Employee_Inhold.INH_BU_ID = Convert.ToInt32(rcmbBusinessUnit.SelectedValue);
                _obj_Smhr_Employee_Inhold.INH_FIN_PRDDTL_ID = Convert.ToInt32(rcmbPeriodElement.SelectedValue);
                _obj_Smhr_Employee_Inhold.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtChk = BLL.get_Employee_Inhold(_obj_Smhr_Employee_Inhold);
                if (dtChk.Rows.Count > 0)
                {
                    if (Convert.ToString(dtChk.Rows[0][0]) == "0")
                    {
                        _obj_Smhr_Attendance.OPERATION = operation.CHKATT;
                        _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmbBusinessUnit.SelectedValue);
                        _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmbPeriodElement.SelectedValue);
                        DataTable dtEmp = BLL.get_Attendance(_obj_Smhr_Attendance);
                        if (dtEmp.Rows.Count > 0)
                        {
                            rgMain.DataSource = dtEmp;
                            rgMain.DataBind();

                            return;


                            int empcount = 0;
                            for (int index = 0; index < rgMain.Items.Count; index++)
                            {
                                lblempid = rgMain.Items[index].FindControl("lblEmpId") as Label;
                                chk1 = rgMain.Items[index].FindControl("chkEmployee") as CheckBox;

                                _obj_Smhr_Attendance.OPERATION = operation.Select1;
                                _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmbBusinessUnit.SelectedItem.Value);
                                _obj_Smhr_Attendance.ATTENDANCE_PERIOD_ID = Convert.ToInt32(rcmbPeriod.SelectedItem.Value);
                                _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmbPeriodElement.SelectedItem.Value);
                                _obj_Smhr_Attendance.ATTENDANCE_EMP_ID = Convert.ToInt32(lblempid.Text);
                                DataTable dt_status = BLL.get_Attendance(_obj_Smhr_Attendance);
                                bool st = false;
                                if (dt_status.Rows.Count > 0)
                                {
                                    for (int count = 0; count < dt_status.Rows.Count; count++)
                                    {
                                        if (Convert.ToString(dt_status.Rows[count]["COUNT"]) != "0")
                                        {
                                            st = true;//IF PAYROLL IS IN PENDING OR APPROVED
                                        }
                                    }
                                }
                                if (st)
                                    chk1.Enabled = false;
                                else
                                {
                                    chk1.Enabled = true;
                                    empcount++;
                                }
                            }
                            //if (empcount == 0)
                            //{
                            //    btnSave.Visible = false;
                            //    btnUpdate.Visible = false;
                            //}
                            //else
                            //{
                            //    btnSave.Visible = true;
                            //    btnUpdate.Visible = false;
                            //}
                            //btnCancel.Visible = true;
                        }
                    }
                    else
                    {
                        _obj_Smhr_Employee_Inhold.OPERATION = operation.Select;
                        DataTable dtEmp = BLL.get_Employee_Inhold(_obj_Smhr_Employee_Inhold);
                        if (dtEmp.Rows.Count > 0)
                        {
                            rgMain.DataSource = dtEmp;
                            rgMain.DataBind();
                            CheckBox chk = new CheckBox();
                            int empcount = 0;
                            for (int dtIndex = 0; dtIndex < dtEmp.Rows.Count; dtIndex++)
                            {
                                chk = rgMain.Items[dtIndex].FindControl("chkEmployee") as CheckBox;
                                lblempid = rgMain.Items[dtIndex].FindControl("lblEmpId") as Label;
                                if (Convert.ToString(dtEmp.Rows[dtIndex]["HOLD_STATUS"]) == "1")
                                {
                                    chk.Checked = true;
                                }
                                else
                                {
                                    chk.Checked = false;
                                }
                                //TO GET THE PAYROLL STATUS
                                _obj_Smhr_Attendance.OPERATION = operation.Select1;
                                _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmbBusinessUnit.SelectedItem.Value);
                                _obj_Smhr_Attendance.ATTENDANCE_PERIOD_ID = Convert.ToInt32(rcmbPeriod.SelectedItem.Value);
                                _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmbPeriodElement.SelectedItem.Value);
                                _obj_Smhr_Attendance.ATTENDANCE_EMP_ID = Convert.ToInt32(lblempid.Text);
                                DataTable dt_status = BLL.get_Attendance(_obj_Smhr_Attendance);
                                bool st = false;
                                if (dt_status.Rows.Count > 0)
                                {
                                    for (int count = 0; count < dt_status.Rows.Count; count++)
                                    {
                                        if (Convert.ToString(dt_status.Rows[count]["COUNT"]) != "0")
                                        {
                                            st = true;//IF PAYROLL IS IN PENDING OR APPROVED
                                        }
                                    }
                                }
                                if (st)
                                    chk.Enabled = false;
                                else
                                {
                                    chk.Enabled = true;
                                    empcount++;
                                }
                            }
                            //if (empcount == 0)
                            //{
                            //    btnSave.Visible = false;
                            //    btnUpdate.Visible = false;
                            //}
                            //else
                            //{
                            //    btnSave.Visible = false;
                            //    btnUpdate.Visible = true;
                            //}
                            //btnCancel.Visible = true;
                        }
                    }
                }
                ////        }

                ////    }
                ////    else
                ////    {

                ////    }
                ////}
                //rgMain.Visible = true;
                //trBtn.Visible = true;
                //trChkAll.Visible = true;
                //_obj_Smhr_Employee_Inhold = new SMHR_EMPLOYEE_INHOLD();
                //_obj_Smhr_Employee_Inhold.OPERATION = operation.Check;
                //_obj_Smhr_Employee_Inhold.INH_BU_ID = Convert.ToInt32(rcmbBusinessUnit.SelectedValue);
                //_obj_Smhr_Employee_Inhold.INH_FIN_PRDDTL_ID = Convert.ToInt32(rcmbPeriodElement.SelectedValue);
                //_obj_Smhr_Employee_Inhold.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //DataTable dtChk = BLL.get_Employee_Inhold(_obj_Smhr_Employee_Inhold);
                //if (dtChk.Rows.Count > 0)
                //{
                //    if (Convert.ToString(dtChk.Rows[0][0]) == "0")
                //    {
                //        _obj_Smhr_Attendance.OPERATION = operation.CHKATT;
                //        _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmbBusinessUnit.SelectedValue);
                //        _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmbPeriodElement.SelectedValue);
                //        DataTable dtEmp = BLL.get_Attendance(_obj_Smhr_Attendance);
                //        if (dtEmp.Rows.Count > 0)
                //        {
                //            rgMain.DataSource = dtEmp;
                //            rgMain.DataBind();
                //            btnSave.Visible = true;
                //            btnUpdate.Visible = false;
                //            btnCancel.Visible = true;
                //        }
                //    }
                //    else
                //    {
                //        _obj_Smhr_Employee_Inhold.OPERATION = operation.Select;
                //        DataTable dtEmp = BLL.get_Employee_Inhold(_obj_Smhr_Employee_Inhold);
                //        if (dtEmp.Rows.Count > 0)
                //        {
                //            rgMain.DataSource = dtEmp;
                //            rgMain.DataBind();
                //            CheckBox chk = new CheckBox();
                //            for (int dtIndex = 0; dtIndex < dtEmp.Rows.Count; dtIndex++)
                //            {
                //                chk = rgMain.Items[dtIndex].FindControl("chkEmployee") as CheckBox;
                //                if (Convert.ToString(dtEmp.Rows[dtIndex]["HOLD_STATUS"]) == "1")
                //                {
                //                    chk.Checked = true;
                //                }
                //                else
                //                {
                //                    chk.Checked = false;
                //                }
                //            }
                //            btnSave.Visible = false;
                //            btnUpdate.Visible = true;
                //            btnCancel.Visible = true;
                //        }
                //    }
                //}
            }
            else
            {
                BLL.ShowMessage(this, "Select Period Element");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmHoldPayrollProcess", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        CheckBox chk = new CheckBox();
    //        if (chkSelectAll.Checked)
    //        {
    //            for (int index = 0; index < rgMain.Items.Count; index++)
    //            {
    //                chk = rgMain.Items[index].FindControl("chkEmployee") as CheckBox;
    //                if (chk.Enabled)
    //                    chk.Checked = true;
    //            }
    //        }
    //        else
    //        {
    //            for (int index = 0; index < rgMain.Items.Count; index++)
    //            {
    //                chk = rgMain.Items[index].FindControl("chkEmployee") as CheckBox;
    //                if (chk.Enabled)
    //                    chk.Checked = false;
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmHoldPayrollProcess", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}

}