﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SMHR;
using Telerik.Web.UI;

public partial class Masters_frm_LeaveStructure : System.Web.UI.Page
{
    DataTable dt_Details; // For Search
    static DataTable dt_Det; //For Temp Data
    static string _leavestruct_ID = "0";
    static string _leavestructdet_ID = "0";
    SMHR_LEAVESTRUCT _obj_smhr_leaveStruct;
    SMHR_PERIODTYPE _obj_Smhr_PeriodType;
    SMHR_LEAVEMASTER _obj_smhr_leavemaster;
    static int Mode = 0;
    //0 for New Add
    //1 for New Update
    //2 for Edit Add
    //3 for Edit Update

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (!IsPostBack)
            {

                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Leave Structure");//LEAVESTRUCTURE");
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
                    RG_LeaveStructure.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Save.Visible = false;
                    btn_Include.Visible = false;
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
                Page.Validate();
                BLL.gridDateFormat(Convert.ToString(Session["EMP_ID"]), RG_LeaveStructure, "LEAVESTRUCT_STARTDATE", "LEAVESTRUCT_ENDDATE");
                BLL.ChangeDateFormat(Convert.ToString(Session["EMP_ID"]), txt_endDate, txt_startDate);

            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveStructure", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Click(object sender, EventArgs e)
    {
        try
        {
            RMP_LeaveStructure.SelectedIndex = 1;
            btn_Update.Visible = false;
            dt_Det = new DataTable();
            createColumns();
            clearFields();
            LoadCombos();
            Mode = 0;

            rtxt_LeaveCode.Enabled = true;
            rtxt_LeaveCode.Text = string.Empty;
            rtxt_LeaveDesc.Text = string.Empty;
            txt_startDate.SelectedDate = null;
            txt_endDate.SelectedDate = null;
            btn_Save.Visible = true;
            btn_Update.Visible = false;
            txt_startDate.Enabled = true;
            chkAutoIncrmntLevs.Checked = false;
            rtxtAutoIncrmntLevs.Text = string.Empty;
            rtxtAutoIncrmntLevs.Enabled = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveStructure", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_SalStructEdit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            clearFields();
            _obj_smhr_leaveStruct = new SMHR_LEAVESTRUCT();
            RMP_LeaveStructure.SelectedIndex = 1;
            btn_Save.Visible = false;

            //code for security
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Update.Visible = false;

            }

            else
            {
                btn_Update.Visible = true;
            }

            LoadCombos();
            _obj_smhr_leaveStruct.OPERATION = operation.Select;
            string Code = Convert.ToString(e.CommandArgument);
            _leavestruct_ID = Code;
            _obj_smhr_leaveStruct.LEAVESTRUCT_ID = Convert.ToInt32(_leavestruct_ID);
            _obj_smhr_leaveStruct.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_LeaveStructHeaderDetails(_obj_smhr_leaveStruct);
            if (dt.Rows.Count != 0)
            {
                rtxt_LeaveCode.Text = Convert.ToString(dt.Rows[0]["LEAVESTRUCT_CODE"]);
                rtxt_LeaveDesc.Text = Convert.ToString(dt.Rows[0]["LEAVESTRUCT_NAME"]);
                txt_startDate.SelectedDate = Convert.ToDateTime(Convert.ToString(dt.Rows[0]["LEAVESTRUCT_STARTDATE"]));

                if (dt.Rows[0]["LEAVESTRUCT_ENDDATE"] == DBNull.Value)
                    txt_endDate.SelectedDate = null;
                else
                    txt_endDate.SelectedDate = Convert.ToDateTime(Convert.ToString(dt.Rows[0]["LEAVESTRUCT_ENDDATE"]));

                if (dt.Rows[0]["IsAutoIncrement"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(dt.Rows[0]["IsAutoIncrement"]) == true && Convert.ToString(dt.Rows[0]["AutoIncrementDays"]) != "0.00")
                    {
                        chkAutoIncrmntLevs.Checked = true;
                        rtxtAutoIncrmntLevs.Text = Convert.ToString(dt.Rows[0]["AutoIncrementDays"]);
                        rtxtAutoIncrmntLevs.Enabled = true;
                    }
                    else
                    {
                        chkAutoIncrmntLevs.Checked = false;
                        rtxtAutoIncrmntLevs.Text = string.Empty;
                        rtxtAutoIncrmntLevs.Enabled = false;
                    }
                }

                if (dt.Rows[0]["LEAVESTRUCT_ISWEEKLYOFF"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(dt.Rows[0]["LEAVESTRUCT_ISWEEKLYOFF"]) == true)
                        chk_holidays.Checked = true;
                    else
                        chk_holidays.Checked = false;
                }

                if (dt.Rows[0]["LEAVESTRUCT_ALLOWHALFDAYS"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(dt.Rows[0]["LEAVESTRUCT_ALLOWHALFDAYS"]) == true)
                        chk_HalfDays.Checked = true;
                    else
                        chk_HalfDays.Checked = false;
                }

                /*_obj_smhr_leaveStruct.OPERATION = operation.Select1;
                DataTable dtLvStrctDet = BLL.get_LeaveStructDetails(_obj_smhr_leaveStruct);

                if (dtLvStrctDet.Rows.Count > 0 && dtLvStrctDet.Rows[0]["IsAutoIncrement"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(dtLvStrctDet.Rows[0]["IsAutoIncrement"]) == true)
                    {
                        chkAutoIncrmntLevs.Checked = true;
                        rtxtAutoIncrmntLevs.Text = Convert.ToString(dtLvStrctDet.Rows[0]["AutoIncrementDays"]);
                        rtxtAutoIncrmntLevs.Enabled = true;
                    }
                }
                else
                {
                    if (dtLvStrctDet.Rows.Count > 0)
                        _leavestructdet_ID = Convert.ToString(dtLvStrctDet.Rows[0]["LEAVESTRUCTDET_ID"]);
                    
                    chkAutoIncrmntLevs.Checked = false;
                    rtxtAutoIncrmntLevs.Text = string.Empty;
                    rtxtAutoIncrmntLevs.Enabled = false;
                }
                _obj_smhr_leaveStruct.OPERATION = operation.Empty;
                _obj_smhr_leaveStruct.LEAVESTRUCTDET_LEAVESTR_ID = Convert.ToInt32(e.CommandArgument);
                _obj_smhr_leaveStruct.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtDet = BLL.get_LeaveStructDetails(_obj_smhr_leaveStruct);

                ViewState["dtDet"] = dtDet;

                if (dtDet.Rows.Count != 0)
                {
                    RG_LeaveDetails.DataSource = dtDet;
                    RG_LeaveDetails.DataBind();
                }*/
                rtxt_LeaveCode.Enabled = false;
            }
            Mode = 2;
            txt_startDate.Enabled = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveStructure", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToString(rtxt_LeaveCode.Text.Replace("'", "''")) == string.Empty)
            {
                BLL.ShowMessage(this, "Please Enter Leave Structure Name");
                return;
            }
            //if (dt_Det.Rows.Count == 0)
            //{
            //    BLL.ShowMessage(this, "Please Enter Atleast one Leave Item");
            //    return;
            //}
            if (chkAutoIncrmntLevs.Checked == true && rtxtAutoIncrmntLevs.Text == string.Empty)
            {
                BLL.ShowMessage(this, "Please enter No. of days to Increment before updating the record");
                rtxtAutoIncrmntLevs.Focus();
                return;
            }
            dt_Details = new DataTable();
            _obj_smhr_leaveStruct = new SMHR_LEAVESTRUCT();
            _obj_smhr_leaveStruct.OPERATION = operation.Check;
            _obj_smhr_leaveStruct.LEAVESTRUCT_CODE = Convert.ToString(rtxt_LeaveCode.Text.Replace("'", "''"));
            _obj_smhr_leaveStruct.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_LeaveStructHeaderDetails(_obj_smhr_leaveStruct);
            if (dt_Details.Rows.Count != 0)
            {
                BLL.ShowMessage(this, "Leave Structure Name already Exists");
                return;
            }

            //Leave Structure Header Details
            bool status = false;
            _obj_smhr_leaveStruct.OPERATION = operation.Insert;
            _obj_smhr_leaveStruct.LEAVESTRUCT_CODE = Convert.ToString(rtxt_LeaveCode.Text.Replace("'", "''"));
            _obj_smhr_leaveStruct.LEAVESTRUCT_NAME = Convert.ToString(rtxt_LeaveDesc.Text.Replace("'", "''"));
            _obj_smhr_leaveStruct.LEAVESTRUCT_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_leaveStruct.LEAVESTRUCT_STARTDATE = Convert.ToDateTime(txt_startDate.SelectedDate);
            _obj_smhr_leaveStruct.LEAVESTRUCT_ENDDATE = txt_endDate.SelectedDate;
            _obj_smhr_leaveStruct.LEAVESTRUCT_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_leaveStruct.LEAVESTRUCT_CREATEDDATE = DateTime.Now;
            _obj_smhr_leaveStruct.IsAutoIncrement = true;
            if (rtxtAutoIncrmntLevs.Text != string.Empty)
            {
                _obj_smhr_leaveStruct.AutoIncrementDays = Convert.ToDecimal(rtxtAutoIncrmntLevs.Text);
                chkAutoIncrmntLevs.Checked = true;
            }
            else
            {
                _obj_smhr_leaveStruct.AutoIncrementDays = 0;
                chkAutoIncrmntLevs.Checked = false;
            }

            if (chk_holidays.Checked)
                _obj_smhr_leaveStruct.LEAVESTRUCTDET_ISWEEKLYOFF = true;
            else
                _obj_smhr_leaveStruct.LEAVESTRUCTDET_ISWEEKLYOFF = false;

            if (chk_HalfDays.Checked)
                _obj_smhr_leaveStruct.LEAVESTRUCTDET_ALLOWHALFDAYS = true;
            else
                _obj_smhr_leaveStruct.LEAVESTRUCTDET_ALLOWHALFDAYS = false;

            status = BLL.set_LeaveStructHeaderDetails(_obj_smhr_leaveStruct);
            if (status == true)
            {
                BLL.ShowMessage(this, "Record Saved Successfully");
                RMP_LeaveStructure.SelectedIndex = 0;
                LoadData();
                return;
                #region Commented
                /*string str = string.Empty;
                dt_Details = new DataTable();
                _obj_smhr_leaveStruct.OPERATION = operation.Check;
                _obj_smhr_leaveStruct.LEAVESTRUCT_CODE = Convert.ToString(rtxt_LeaveCode.Text.Replace("'", "''"));
                dt_Details = BLL.get_LeaveStructHeaderDetails(_obj_smhr_leaveStruct);
                if (dt_Details.Rows.Count != 0)
                {
                    str = Convert.ToString(dt_Details.Rows[0][0]);
                }
                //Leave Structure Details
                if (str != String.Empty)
                {
                    foreach (DataRow row in dt_Det.Rows)
                    {
                        _obj_smhr_leaveStruct.OPERATION = operation.Insert;
                        _obj_smhr_leaveStruct.LEAVESTRUCTDET_LEAVESTR_ID = Convert.ToInt32(str);
                        _obj_smhr_leaveStruct.LEAVESTRUCTDET_LEAVETYPE_ID = Convert.ToInt32(Convert.ToString(row[1]));
                        _obj_smhr_leaveStruct.LEAVESTRUCTDET_ISWEEKLYOFF = Convert.ToBoolean(Convert.ToString(row[3]));
                        _obj_smhr_leaveStruct.LEAVESTRUCTDET_ALLOWHALFDAYS = Convert.ToBoolean(Convert.ToString(row[4]));
                        _obj_smhr_leaveStruct.LEAVESTRUCTDET_ACCUMULATE = Convert.ToBoolean(Convert.ToString(row[5]));
                        _obj_smhr_leaveStruct.LEAVESTRUCTDET_PERIOD_ID = 0;
                        _obj_smhr_leaveStruct.LEAVESTRUCTDET_DAYSPERYEAR = Convert.ToDouble(Convert.ToString(row[6]));
                        _obj_smhr_leaveStruct.LEAVESTRUCTDET_MAXDAYS = Convert.ToDouble(Convert.ToString(row[7]));
                        _obj_smhr_leaveStruct.LEAVESTRUCTDET_CFORWARD = Convert.ToBoolean(Convert.ToString(row[8]));
                        _obj_smhr_leaveStruct.LEAVESTRUCTDET_CFMAXDAYS = Convert.ToDouble(Convert.ToString(row[9]));
                        // _obj_smhr_leaveStruct.LEAVESTRUCTDET_ELIGIBLEDAYS = Convert.ToDouble(Convert.ToString(row[12]));
                        _obj_smhr_leaveStruct.LEAVESTRUCTDET_ENCASHMENT = Convert.ToBoolean(Convert.ToString(row[10]));
                        _obj_smhr_leaveStruct.LEAVESTRUCTDET_MAXENCASHDAYS = Convert.ToDouble(Convert.ToString(row[11]));
                        _obj_smhr_leaveStruct.LEAVESTRUCTDET_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_smhr_leaveStruct.LEAVESTRUCTDET_CREATEDDATE = DateTime.Now;
                        if (chkAutoIncrmntLevs.Checked)
                        {
                            _obj_smhr_leaveStruct.IsAutoIncrement = true;
                            _obj_smhr_leaveStruct.AutoIncrementDays = Convert.ToDecimal(rtxtAutoIncrmntLevs.Text);
                        }
                        else
                        {
                            _obj_smhr_leaveStruct.IsAutoIncrement = false;
                            _obj_smhr_leaveStruct.AutoIncrementDays = 0;
                        }
                        status = BLL.set_LeaveStructDetails(_obj_smhr_leaveStruct);
                    }
                    if (status == true)
                    {
                        BLL.ShowMessage(this, "Record Saved Successfully");
                        RMP_LeaveStructure.SelectedIndex = 0;
                        LoadData();
                        return;
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Exception Occured While Doing the Process");
                        return;
                    }
                }
                else
                {
                    BLL.ShowMessage(this, "Exception Occured While Doing the Process");
                    RMP_LeaveStructure.SelectedIndex = 0;
                    LoadData();
                    return;

                }*/
                #endregion
            }
            else
            {
                BLL.ShowMessage(this, "Exception Occured While Doing the Process");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveStructure", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void chk_Accumulate_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chk_Accumulate.Checked)
            {
                rntxt_MaxDaysAllow.Enabled = false;
                rntxt_MaxDaysAllow.Value = rntxt_DaysPerYear.Value;
            }
            else
            {
                rntxt_MaxDaysAllow.Enabled = false;
                rntxt_MaxDaysAllow.Value = null;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveStructure", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void chk_carryforward_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chk_carryforward.Checked)
            {
                rntxt_MaxDays.Enabled = true;
                rntxt_MaxDays.Value = null;
            }
            else
            {
                rntxt_MaxDays.Enabled = false;
                rntxt_MaxDays.Value = null;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveStructure", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void chk_Encashment_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chk_Encashment.Checked)
            {
                rntxt_MaxExncashable.Enabled = true;
                rntxt_MaxExncashable.Value = null;
            }
            else
            {
                rntxt_MaxExncashable.Enabled = false;
                rntxt_MaxExncashable.Value = null;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveStructure", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadData()
    {
        try
        {
            _obj_smhr_leaveStruct = new SMHR_LEAVESTRUCT();
            _obj_smhr_leaveStruct.OPERATION = operation.Select1;
            _obj_smhr_leaveStruct.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_leaveStruct.LEAVESTRUCT_ID = Convert.ToInt32(_leavestruct_ID);
            dt_Details = BLL.get_LeaveStructHeaderDetails(_obj_smhr_leaveStruct);
            if (dt_Details.Rows.Count != 0)
            {
                RG_LeaveStructure.DataSource = dt_Details;
                RG_LeaveStructure.DataBind();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveStructure", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Include_Click(object sender, EventArgs e)
    {
        try
        {
            int index;

            if (Mode == 0)
            {
                Label lblLeaveID = new Label();
                for (index = 0; index <= RG_LeaveDetails.Items.Count - 1; index++)
                {
                    lblLeaveID = RG_LeaveDetails.Items[index].FindControl("lbl_LEAVESTRUCTDET_LEAVETYPE_ID") as Label;
                    if (ddl_LeaveItem.SelectedItem.Value == lblLeaveID.Text)
                    {
                        BLL.ShowMessage(this, "Already Leave Item is added");
                        return;
                    }
                }

                if (!(ddl_LeaveItem.SelectedIndex == 0))
                {
                    DataRow dr = dt_Det.NewRow();
                    dr[0] = "0";
                    dr[1] = ddl_LeaveItem.SelectedItem.Value; // Leave Type ID
                    dr[2] = ddl_LeaveItem.SelectedItem.Text; // Leave Item Name
                    if (chk_holidays.Checked) // Holidays
                        dr[3] = true;
                    else
                        dr[3] = false;
                    if (chk_HalfDays.Checked) // Weekly offs
                        dr[4] = true;
                    else
                        dr[4] = false;
                    if (chk_Accumulate.Checked) // Accumulate
                        dr[5] = true;
                    else
                        dr[5] = false;
                    if (rntxt_DaysPerYear.Value.ToString() != "")
                        dr[6] = rntxt_DaysPerYear.Value; // Days Per Year
                    else
                        dr[6] = 0; // Days Per Year
                    if (rntxt_MaxDaysAllow.Value.ToString() != "")
                        dr[7] = rntxt_MaxDaysAllow.Value; // Max Days Allowed for Accumulate
                    else
                        dr[7] = 0; // Max Days Allowed for Accumulate
                    if (chk_carryforward.Checked) // Carry Forward
                        dr[8] = true;
                    else
                        dr[8] = false;
                    if (rntxt_MaxDays.Value.ToString() != "")
                        dr[9] = rntxt_MaxDays.Value; // Max Days for Carry Forward
                    else
                        dr[9] = 0; // Max Days for Carry Forward
                    if (chk_Encashment.Checked) // Encashment
                        dr[10] = true;
                    else
                        dr[10] = false;
                    if (rntxt_MaxExncashable.Value.ToString() != "")
                        dr[11] = rntxt_MaxExncashable.Value; // Maximum Encashable Days
                    else
                        dr[11] = 0; // Maximum Encashable Days
                    dt_Det.Rows.Add(dr);
                    RG_LeaveDetails.DataSource = dt_Det;
                    RG_LeaveDetails.DataBind();
                    clearFields();
                }
                else
                {
                    //BLL.ShowMessage(this,"Please Select Leave Item");
                }
            }
            else if (Mode == 1)
            {
                DataRow dr;
                int row = Convert.ToInt32(Session["Row"]);// To Know Which Was Edited
                dr = dt_Det.Rows[row];//To Get That Row Values
                // dr = dt_Det.Rows[0];Previous
                dr.BeginEdit();
                dr[0] = "0";
                dr[1] = ddl_LeaveItem.SelectedItem.Value; // Leave Type ID
                dr[2] = ddl_LeaveItem.SelectedItem.Text; // Leave Item Name
                if (chk_holidays.Checked) // Holidays
                    dr[3] = true;
                else
                    dr[3] = false;
                if (chk_HalfDays.Checked) // Weekly offs
                    dr[4] = true;
                else
                    dr[4] = false;
                if (chk_Accumulate.Checked) // Accumulate
                    dr[5] = true;
                else
                    dr[5] = false;
                if (rntxt_DaysPerYear.Value.ToString() != "")
                    dr[6] = rntxt_DaysPerYear.Value; // Days Per Year
                else
                    dr[6] = 0; // Days Per Year
                if (rntxt_MaxDaysAllow.Value.ToString() != "")
                    dr[7] = rntxt_MaxDaysAllow.Value; // Max Days Allowed for Accumulate
                else
                    dr[7] = 0; // Max Days Allowed for Accumulate
                if (chk_carryforward.Checked) // Carry Forward
                    dr[8] = true;
                else
                    dr[8] = false;
                if (rntxt_MaxDays.Value.ToString() != "")
                    dr[9] = rntxt_MaxDays.Value; // Max Days for Carry Forward
                else
                    dr[9] = 0; // Max Days for Carry Forward
                if (chk_Encashment.Checked) // Encashment
                    dr[10] = true;
                else
                    dr[10] = false;
                if (rntxt_MaxExncashable.Value.ToString() != "")
                    dr[11] = rntxt_MaxExncashable.Value; // Maximum Encashable Days
                else
                    dr[11] = 0; // Maximum Encashable Days
                dr.EndEdit();
                RG_LeaveDetails.DataSource = dt_Det;
                RG_LeaveDetails.DataBind();
                clearFields();
                ddl_LeaveItem.Enabled = true;
                Mode = 0;
            }
            else if (Mode == 2)
            {
                Label lblLeaveID = new Label();
                for (index = 0; index <= RG_LeaveDetails.Items.Count - 1; index++)
                {
                    lblLeaveID = RG_LeaveDetails.Items[index].FindControl("lbl_LEAVESTRUCTDET_LEAVETYPE_ID") as Label;
                    if (ddl_LeaveItem.SelectedItem.Value == lblLeaveID.Text)
                    {
                        BLL.ShowMessage(this, "Already Leave Item is added");
                        return;
                    }
                }

                _obj_smhr_leaveStruct = new SMHR_LEAVESTRUCT();
                bool status = false;
                _obj_smhr_leaveStruct.OPERATION = operation.Check;
                _obj_smhr_leaveStruct.LEAVESTRUCT_CODE = Convert.ToString(rtxt_LeaveCode.Text.Replace("'", "''"));
                _obj_smhr_leaveStruct.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                dt_Details = BLL.get_LeaveStructHeaderDetails(_obj_smhr_leaveStruct);
                if (dt_Details.Rows.Count != 0)
                {
                    _leavestruct_ID = Convert.ToString(dt_Details.Rows[0][0]);
                }
                //Leave Structure Details
                _obj_smhr_leaveStruct.OPERATION = operation.Insert;
                _obj_smhr_leaveStruct.LEAVESTRUCTDET_LEAVESTR_ID = Convert.ToInt32(_leavestruct_ID);
                _obj_smhr_leaveStruct.LEAVESTRUCTDET_LEAVETYPE_ID = Convert.ToInt32(ddl_LeaveItem.SelectedItem.Value);
                if (chk_HalfDays.Checked)
                    _obj_smhr_leaveStruct.LEAVESTRUCTDET_ALLOWHALFDAYS = true;
                else
                    _obj_smhr_leaveStruct.LEAVESTRUCTDET_ALLOWHALFDAYS = false;
                if (chk_holidays.Checked)
                    _obj_smhr_leaveStruct.LEAVESTRUCTDET_ISWEEKLYOFF = true;
                else
                    _obj_smhr_leaveStruct.LEAVESTRUCTDET_ISWEEKLYOFF = false;
                if (chk_Accumulate.Checked)
                    _obj_smhr_leaveStruct.LEAVESTRUCTDET_ACCUMULATE = true;
                else
                    _obj_smhr_leaveStruct.LEAVESTRUCTDET_ACCUMULATE = false;

                _obj_smhr_leaveStruct.LEAVESTRUCTDET_DAYSPERYEAR = Convert.ToDouble(rntxt_DaysPerYear.Value);
                _obj_smhr_leaveStruct.LEAVESTRUCTDET_MAXDAYS = Convert.ToDouble(rntxt_MaxDaysAllow.Value);
                if (chk_carryforward.Checked)
                    _obj_smhr_leaveStruct.LEAVESTRUCTDET_CFORWARD = true;
                else
                    _obj_smhr_leaveStruct.LEAVESTRUCTDET_CFORWARD = false;
                _obj_smhr_leaveStruct.LEAVESTRUCTDET_CFMAXDAYS = Convert.ToDouble(rntxt_MaxDays.Value);
                if (chk_Encashment.Checked)
                    _obj_smhr_leaveStruct.LEAVESTRUCTDET_ENCASHMENT = true;
                else
                    _obj_smhr_leaveStruct.LEAVESTRUCTDET_ENCASHMENT = false;
                _obj_smhr_leaveStruct.LEAVESTRUCTDET_MAXENCASHDAYS = Convert.ToDouble(rntxt_MaxExncashable.Value);
                _obj_smhr_leaveStruct.LEAVESTRUCTDET_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_smhr_leaveStruct.LEAVESTRUCTDET_CREATEDDATE = DateTime.Now;
                status = BLL.set_LeaveStructDetails(_obj_smhr_leaveStruct);
                if (status == true)
                {
                    _obj_smhr_leaveStruct.OPERATION = operation.Empty;
                    _obj_smhr_leaveStruct.LEAVESTRUCTDET_LEAVESTR_ID = Convert.ToInt32(Convert.ToString(_leavestruct_ID));
                    _obj_smhr_leaveStruct.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    dt_Det = BLL.get_LeaveStructDetails(_obj_smhr_leaveStruct);
                    if (dt_Det.Rows.Count != 0)
                    {
                        RG_LeaveDetails.DataSource = dt_Det;
                        RG_LeaveDetails.DataBind();
                        clearFields();
                        ddl_LeaveItem.Enabled = true;
                        Mode = 2;
                    }
                }
                else
                {
                    BLL.ShowMessage(this, "Error Occured While doing the Process");
                    return;
                }
            }
            else if (Mode == 3)
            {
                _obj_smhr_leaveStruct = new SMHR_LEAVESTRUCT();
                bool status = false;
                _obj_smhr_leaveStruct.OPERATION = operation.Check;
                _obj_smhr_leaveStruct.LEAVESTRUCT_CODE = Convert.ToString(rtxt_LeaveCode.Text.Replace("'", "''"));
                _obj_smhr_leaveStruct.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                dt_Details = BLL.get_LeaveStructHeaderDetails(_obj_smhr_leaveStruct);
                if (dt_Details.Rows.Count != 0)
                {
                    _leavestruct_ID = Convert.ToString(dt_Details.Rows[0][0]);
                }
                //Leave Structure Details
                _obj_smhr_leaveStruct.OPERATION = operation.Update;
                _obj_smhr_leaveStruct.LEAVESTRUCTDET_LEAVESTR_ID = Convert.ToInt32(_leavestruct_ID);
                _obj_smhr_leaveStruct.LEAVESTRUCTDET_ID = Convert.ToInt32(Convert.ToString(_leavestructdet_ID));
                _obj_smhr_leaveStruct.LEAVESTRUCTDET_LEAVETYPE_ID = Convert.ToInt32(ddl_LeaveItem.SelectedItem.Value);
                if (chk_HalfDays.Checked)
                    _obj_smhr_leaveStruct.LEAVESTRUCTDET_ALLOWHALFDAYS = true;
                else
                    _obj_smhr_leaveStruct.LEAVESTRUCTDET_ALLOWHALFDAYS = false;
                if (chk_holidays.Checked)
                    _obj_smhr_leaveStruct.LEAVESTRUCTDET_ISWEEKLYOFF = true;
                else
                    _obj_smhr_leaveStruct.LEAVESTRUCTDET_ISWEEKLYOFF = false;
                if (chk_Accumulate.Checked)
                    _obj_smhr_leaveStruct.LEAVESTRUCTDET_ACCUMULATE = true;
                else
                    _obj_smhr_leaveStruct.LEAVESTRUCTDET_ACCUMULATE = false;
                _obj_smhr_leaveStruct.LEAVESTRUCTDET_DAYSPERYEAR = Convert.ToDouble(rntxt_DaysPerYear.Value);
                _obj_smhr_leaveStruct.LEAVESTRUCTDET_MAXDAYS = Convert.ToDouble(rntxt_MaxDaysAllow.Value);
                if (chk_carryforward.Checked)
                    _obj_smhr_leaveStruct.LEAVESTRUCTDET_CFORWARD = true;
                else
                    _obj_smhr_leaveStruct.LEAVESTRUCTDET_CFORWARD = false;
                _obj_smhr_leaveStruct.LEAVESTRUCTDET_CFMAXDAYS = Convert.ToDouble(rntxt_MaxDays.Value);
                if (chk_Encashment.Checked)
                    _obj_smhr_leaveStruct.LEAVESTRUCTDET_ENCASHMENT = true;
                else
                    _obj_smhr_leaveStruct.LEAVESTRUCTDET_ENCASHMENT = false;
                _obj_smhr_leaveStruct.LEAVESTRUCTDET_MAXENCASHDAYS = Convert.ToDouble(rntxt_MaxExncashable.Value);
                _obj_smhr_leaveStruct.LEAVESTRUCTDET_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_smhr_leaveStruct.LEAVESTRUCTDET_LASTMDFDATE = DateTime.Now;
                status = BLL.set_LeaveStructDetails(_obj_smhr_leaveStruct);
                if (status == true)
                {
                    _obj_smhr_leaveStruct.OPERATION = operation.Empty;
                    _obj_smhr_leaveStruct.LEAVESTRUCTDET_LEAVESTR_ID = Convert.ToInt32(Convert.ToString(_leavestruct_ID));
                    _obj_smhr_leaveStruct.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    dt_Det = BLL.get_LeaveStructDetails(_obj_smhr_leaveStruct);
                    if (dt_Det.Rows.Count != 0)
                    {
                        RG_LeaveDetails.DataSource = dt_Det;
                        RG_LeaveDetails.DataBind();
                        clearFields();
                        ddl_LeaveItem.Enabled = true;
                        Mode = 2;
                    }
                }
                else
                {
                    BLL.ShowMessage(this, "Error Occured While doing the Process");
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveStructure", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void createColumns()
    {
        try
        {
            dt_Det.Columns.Clear();
            dt_Det.Columns.Add("LEAVESTRUCTDET_ID");
            dt_Det.Columns.Add("LEAVESTRUCTDET_LEAVETYPE_ID");
            dt_Det.Columns.Add("LEAVETYPE_NAME");
            dt_Det.Columns.Add("LEAVESTRUCTDET_ISWEEKLYOFF");
            dt_Det.Columns.Add("LEAVESTRUCTDET_ALLOWHALFDAYS");
            dt_Det.Columns.Add("LEAVESTRUCTDET_ACCUMULATE");
            dt_Det.Columns.Add("LEAVESTRUCTDET_DAYSPERYEAR");
            dt_Det.Columns.Add("LEAVESTRUCTDET_MAXDAYS");
            dt_Det.Columns.Add("LEAVESTRUCTDET_CFORWARD");
            dt_Det.Columns.Add("LEAVESTRUCTDET_CFMAXDAYS");
            dt_Det.Columns.Add("LEAVESTRUCTDET_ENCASHMENT");
            dt_Det.Columns.Add("LEAVESTRUCTDET_MAXENCASHDAYS");
            RG_LeaveDetails.DataSource = dt_Det;
            RG_LeaveDetails.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveStructure", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void clearFields()
    {
        try
        {
            ddl_LeaveItem.SelectedIndex = -1;
            ddl_LeaveItem.Enabled = true;
            rntxt_DaysPerYear.Value = null;
            rntxt_MaxDays.Value = null;
            rntxt_MaxDaysAllow.Value = null;
            rntxt_MaxExncashable.Value = null;
            chk_Accumulate.Checked = false;
            chk_carryforward.Checked = false;
            chk_HalfDays.Checked = false;
            chk_holidays.Checked = false;
            chk_Encashment.Checked = false;
            rntxt_MaxExncashable.Enabled = false;
            rntxt_MaxDays.Enabled = false;
            rntxt_MaxDaysAllow.Enabled = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveStructure", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void RG_LeaveStructure_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            Load_Data();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveStructure", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void Load_Data()
    {
        try
        {
            _obj_smhr_leaveStruct = new SMHR_LEAVESTRUCT();
            _obj_smhr_leaveStruct.OPERATION = operation.Select1;
            _obj_smhr_leaveStruct.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT = BLL.get_LeaveStructHeaderDetails(_obj_smhr_leaveStruct);
            RG_LeaveStructure.DataSource = DT;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveStructure", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadCombos()
    {
        try
        {
            _obj_smhr_leavemaster = new SMHR_LEAVEMASTER();
            _obj_smhr_leavemaster.OPERATION = operation.Select;
            _obj_smhr_leavemaster.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_LeaveMaster(_obj_smhr_leavemaster);
            ddl_LeaveItem.DataSource = dt_Details;
            ddl_LeaveItem.DataValueField = "LEAVEMASTER_ID";
            ddl_LeaveItem.DataTextField = "LEAVEMASTER_CODE";
            ddl_LeaveItem.DataBind();
            ddl_LeaveItem.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveStructure", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Update_Click(object sender, EventArgs e)
    {
        try
        {
            bool status = false;
            _obj_smhr_leaveStruct = new SMHR_LEAVESTRUCT();

            if (chkAutoIncrmntLevs.Checked == true && rtxtAutoIncrmntLevs.Text == string.Empty)
            {
                BLL.ShowMessage(this, "Please enter No. of days to Increment before updating the record");
                rtxtAutoIncrmntLevs.Focus();
                return;
            }
            _obj_smhr_leaveStruct.OPERATION = operation.Check;
            _obj_smhr_leaveStruct.LEAVESTRUCT_CODE = Convert.ToString(rtxt_LeaveCode.Text.Replace("'", "''"));
            _obj_smhr_leaveStruct.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_LeaveStructHeaderDetails(_obj_smhr_leaveStruct);
            if (dt_Details.Rows.Count != 0)
            {
                _leavestruct_ID = Convert.ToString(dt_Details.Rows[0][0]);
            }
            _obj_smhr_leaveStruct.OPERATION = operation.Update;
            _obj_smhr_leaveStruct.LEAVESTRUCT_ID = Convert.ToInt32(_leavestruct_ID);
            _obj_smhr_leaveStruct.LEAVESTRUCT_CODE = Convert.ToString(rtxt_LeaveCode.Text);
            _obj_smhr_leaveStruct.LEAVESTRUCT_NAME = Convert.ToString(rtxt_LeaveDesc.Text);
            _obj_smhr_leaveStruct.LEAVESTRUCT_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_leaveStruct.LEAVESTRUCT_STARTDATE = Convert.ToDateTime(txt_startDate.SelectedDate);
            _obj_smhr_leaveStruct.LEAVESTRUCT_ENDDATE = txt_endDate.SelectedDate;
            _obj_smhr_leaveStruct.LEAVESTRUCT_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_leaveStruct.LEAVESTRUCT_LASTMDFDATE = DateTime.Now;
            _obj_smhr_leaveStruct.IsAutoIncrement = true;
            if (rtxtAutoIncrmntLevs.Text != string.Empty)
            {
                _obj_smhr_leaveStruct.AutoIncrementDays = Convert.ToDecimal(rtxtAutoIncrmntLevs.Text);
                chkAutoIncrmntLevs.Checked = true;
            }
            else
            {
                _obj_smhr_leaveStruct.AutoIncrementDays = 0;
                chkAutoIncrmntLevs.Checked = false;
            }

            if (chk_holidays.Checked)
                _obj_smhr_leaveStruct.LEAVESTRUCTDET_ISWEEKLYOFF = true;
            else
                _obj_smhr_leaveStruct.LEAVESTRUCTDET_ISWEEKLYOFF = false;

            if (chk_HalfDays.Checked)
                _obj_smhr_leaveStruct.LEAVESTRUCTDET_ALLOWHALFDAYS = true;
            else
                _obj_smhr_leaveStruct.LEAVESTRUCTDET_ALLOWHALFDAYS = false;

            status = BLL.set_LeaveStructHeaderDetails(_obj_smhr_leaveStruct);

            if (status == true)
            {
                BLL.ShowMessage(this, "Leave Structure Updated Successfully");
                #region Commented
                /*DataTable dtDet = (DataTable)ViewState["dtDet"];

                if (dtDet.Rows.Count > 0)
                {
                    if (chkAutoIncrmntLevs.Checked)
                    {
                        _obj_smhr_leaveStruct.IsAutoIncrement = true;
                        _obj_smhr_leaveStruct.AutoIncrementDays = Convert.ToDecimal(rtxtAutoIncrmntLevs.Text);
                    }
                    else
                    {
                        _obj_smhr_leaveStruct.IsAutoIncrement = false;
                        _obj_smhr_leaveStruct.AutoIncrementDays = 0;
                    }
                    _obj_smhr_leaveStruct.LEAVESTRUCTDET_ID = Convert.ToInt32(Convert.ToString(_leavestructdet_ID));
                    _obj_smhr_leaveStruct.LEAVESTRUCTDET_LEAVESTR_ID = Convert.ToInt32(_leavestruct_ID);
                    //_obj_smhr_leaveStruct.LEAVESTRUCTDET_LEAVETYPE_ID = Convert.ToInt32(dtDet.Rows[0]["LEAVESTRUCTDET_LEAVETYPE_ID"]);
                    _obj_smhr_leaveStruct.LEAVESTRUCT_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_leaveStruct.LEAVESTRUCT_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);

                    status = BLL.set_LeaveStructDetails(_obj_smhr_leaveStruct);
                }*/
                #endregion
                LoadData();
                RMP_LeaveStructure.SelectedIndex = 0;
            }
            else
            {
                BLL.ShowMessage(this, "Leave Structure Not Updated");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveStructure", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            RMP_LeaveStructure.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveStructure", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

        }

    }

    protected void RG_LeaveDetails_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Edititem")
            {
                if (Mode != 2)
                {
                    GridDataItem dtItem = (GridDataItem)e.Item;
                    int index = dtItem.ItemIndex;
                    Session["Row"] = index;// To Retrieve The Row Which He Has Edited while Include Button clicked
                    Label lblStructID = new Label();
                    Label lblLeaveID = new Label();
                    Label lblWeeklyOff = new Label();
                    Label lblAllowHalfDays = new Label();
                    Label lblAccumulate = new Label();
                    Label lblPeriodID = new Label();
                    Label lblDaysPerYear = new Label();
                    Label lblMaxDays = new Label();
                    Label lblCForward = new Label();
                    Label lblCFMaxDays = new Label();
                    Label lblLeaveDays = new Label();
                    Label lblEligibleDays = new Label();
                    Label lblEncashment = new Label();
                    Label lblMaxEncashdays = new Label();
                    Label lblIncomeheads = new Label();
                    lblStructID = RG_LeaveDetails.Items[index].FindControl("lbl_LEAVESTRUCTDET_ID") as Label;
                    lblLeaveID = RG_LeaveDetails.Items[index].FindControl("lbl_LEAVESTRUCTDET_LEAVETYPE_ID") as Label;
                    lblWeeklyOff = RG_LeaveDetails.Items[index].FindControl("lbl_LEAVESTRUCTDET_ISWEEKLYOFF") as Label;
                    lblAllowHalfDays = RG_LeaveDetails.Items[index].FindControl("lbl_LEAVESTRUCTDET_ALLOWHALFDAYS") as Label;
                    lblAccumulate = RG_LeaveDetails.Items[index].FindControl("lbl_LEAVESTRUCTDET_ACCUMULATE") as Label;
                    lblCForward = RG_LeaveDetails.Items[index].FindControl("lbl_LEAVESTRUCTDET_CFORWARD") as Label;
                    lblPeriodID = RG_LeaveDetails.Items[index].FindControl("lbl_LEAVESTRUCTDET_PERIOD_ID") as Label;
                    lblDaysPerYear = RG_LeaveDetails.Items[index].FindControl("lbl_LEAVESTRUCTDET_DAYSPERYEAR") as Label;
                    lblMaxDays = RG_LeaveDetails.Items[index].FindControl("lbl_LEAVESTRUCTDET_MAXDAYS") as Label;
                    lblCFMaxDays = RG_LeaveDetails.Items[index].FindControl("lbl_LEAVESTRUCTDET_CFMAXDAYS") as Label;
                    lblEncashment = RG_LeaveDetails.Items[index].FindControl("lbl_LEAVESTRUCTDET_ENCASHMENT") as Label;
                    lblMaxEncashdays = RG_LeaveDetails.Items[index].FindControl("lbl_LEAVESTRUCTDET_MAXENCASHDAYS") as Label;
                    //Assigning Values to Controls
                    ddl_LeaveItem.SelectedIndex = ddl_LeaveItem.FindItemIndexByValue(lblLeaveID.Text);
                    ddl_LeaveItem.Enabled = false;
                    if (lblWeeklyOff.Text.ToString() == "True")
                        chk_holidays.Checked = true;
                    else
                        chk_holidays.Checked = false;
                    if (lblAllowHalfDays.Text.ToString() == "True")
                        chk_HalfDays.Checked = true;
                    else
                        chk_HalfDays.Checked = false;
                    if (lblAccumulate.Text.ToString() == "True")
                    {
                        chk_Accumulate.Checked = true;
                        rntxt_MaxDaysAllow.Enabled = true;
                    }
                    else
                    {
                        rntxt_MaxDaysAllow.Enabled = false;
                        chk_Accumulate.Checked = false;
                    }
                    if (lblCForward.Text.ToString() == "True")
                    {
                        chk_carryforward.Checked = true;
                        rntxt_MaxDays.Enabled = true;
                    }
                    else
                    {
                        chk_carryforward.Checked = false;
                        rntxt_MaxDays.Enabled = false;
                    }
                    rntxt_DaysPerYear.Value = Convert.ToDouble(lblDaysPerYear.Text);
                    rntxt_MaxDays.Value = Convert.ToDouble(lblCFMaxDays.Text);
                    rntxt_MaxDaysAllow.Value = Convert.ToDouble(lblMaxDays.Text);
                    if (lblEncashment.Text.ToString() == "True")
                    {
                        chk_Encashment.Checked = true;
                        rntxt_MaxExncashable.Enabled = true;
                    }
                    else
                    {
                        chk_Encashment.Checked = false;
                        rntxt_MaxExncashable.Enabled = true;
                    }
                    rntxt_MaxExncashable.Value = Convert.ToDouble(lblMaxEncashdays.Text);
                    Mode = 1;
                }
                else
                {
                    GridDataItem dtItem = (GridDataItem)e.Item;
                    int index = dtItem.ItemIndex;
                    Label lblStructID = new Label();
                    Label lblLeaveID = new Label();
                    Label lblWeeklyOff = new Label();
                    Label lblAllowHalfDays = new Label();
                    Label lblAccumulate = new Label();
                    Label lblPeriodID = new Label();
                    Label lblDaysPerYear = new Label();
                    Label lblMaxDays = new Label();
                    Label lblCForward = new Label();
                    Label lblCFMaxDays = new Label();
                    Label lblLeaveDays = new Label();
                    Label lblEligibleDays = new Label();
                    Label lblEncashment = new Label();
                    Label lblMaxEncashdays = new Label();
                    Label lblIncomeheads = new Label();
                    lblStructID = RG_LeaveDetails.Items[index].FindControl("lbl_LEAVESTRUCTDET_ID") as Label;
                    lblLeaveID = RG_LeaveDetails.Items[index].FindControl("lbl_LEAVESTRUCTDET_LEAVETYPE_ID") as Label;
                    lblWeeklyOff = RG_LeaveDetails.Items[index].FindControl("lbl_LEAVESTRUCTDET_ISWEEKLYOFF") as Label;
                    lblAllowHalfDays = RG_LeaveDetails.Items[index].FindControl("lbl_LEAVESTRUCTDET_ALLOWHALFDAYS") as Label;
                    lblAccumulate = RG_LeaveDetails.Items[index].FindControl("lbl_LEAVESTRUCTDET_ACCUMULATE") as Label;
                    lblCForward = RG_LeaveDetails.Items[index].FindControl("lbl_LEAVESTRUCTDET_CFORWARD") as Label;
                    lblPeriodID = RG_LeaveDetails.Items[index].FindControl("lbl_LEAVESTRUCTDET_PERIOD_ID") as Label;
                    lblDaysPerYear = RG_LeaveDetails.Items[index].FindControl("lbl_LEAVESTRUCTDET_DAYSPERYEAR") as Label;
                    lblMaxDays = RG_LeaveDetails.Items[index].FindControl("lbl_LEAVESTRUCTDET_MAXDAYS") as Label;
                    lblCFMaxDays = RG_LeaveDetails.Items[index].FindControl("lbl_LEAVESTRUCTDET_CFMAXDAYS") as Label;
                    lblEncashment = RG_LeaveDetails.Items[index].FindControl("lbl_LEAVESTRUCTDET_ENCASHMENT") as Label;
                    lblMaxEncashdays = RG_LeaveDetails.Items[index].FindControl("lbl_LEAVESTRUCTDET_MAXENCASHDAYS") as Label;
                    //Assigning Values to Controls
                    ddl_LeaveItem.SelectedIndex = ddl_LeaveItem.FindItemIndexByValue(lblLeaveID.Text);
                    ddl_LeaveItem.Enabled = false;
                    if (lblWeeklyOff.Text.ToString() == "True")
                        chk_holidays.Checked = true;
                    else
                        chk_holidays.Checked = false;
                    if (lblAllowHalfDays.Text.ToString() == "True")
                        chk_HalfDays.Checked = true;
                    else
                        chk_HalfDays.Checked = false;
                    if (lblAccumulate.Text.ToString() == "True")
                    {
                        chk_Accumulate.Checked = true;
                        rntxt_MaxDaysAllow.Enabled = true;
                    }
                    else
                    {
                        rntxt_MaxDaysAllow.Enabled = false;
                        chk_Accumulate.Checked = false;
                    }
                    if (lblCForward.Text.ToString() == "True")
                    {
                        chk_carryforward.Checked = true;
                        rntxt_MaxDays.Enabled = true;
                    }
                    else
                    {
                        chk_carryforward.Checked = false;
                        rntxt_MaxDays.Enabled = false;
                    }
                    rntxt_DaysPerYear.Value = Convert.ToDouble(lblDaysPerYear.Text);
                    rntxt_MaxDays.Value = Convert.ToDouble(lblCFMaxDays.Text);
                    rntxt_MaxDaysAllow.Value = Convert.ToDouble(lblMaxDays.Text);
                    if (lblEncashment.Text.ToString() == "True")
                    {
                        chk_Encashment.Checked = true;
                        rntxt_MaxExncashable.Enabled = true;
                    }
                    else
                    {
                        chk_Encashment.Checked = false;
                        rntxt_MaxExncashable.Enabled = true;
                    }
                    rntxt_MaxExncashable.Value = Convert.ToDouble(lblMaxEncashdays.Text);
                    Mode = 3;
                    _leavestructdet_ID = lblStructID.Text;
                }
            }

            if (e.CommandName == "Del_Rec")
            {
                if (Mode != 2)
                {
                    DataRow dr;
                    dr = dt_Det.Rows[0];
                    dr.Delete();
                    RG_LeaveDetails.DataSource = dt_Det;
                    RG_LeaveDetails.DataBind();
                }
                else
                {
                    _obj_smhr_leaveStruct = new SMHR_LEAVESTRUCT();
                    _obj_smhr_leaveStruct.LEAVESTRUCT_ID = Convert.ToInt32(_leavestruct_ID);
                    _obj_smhr_leaveStruct.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_leaveStruct.OPERATION = operation.Get;
                    DataTable dt = BLL.get_LeaveStructDetails(_obj_smhr_leaveStruct);
                    if (dt.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dt.Rows[0]["COUNT"]) > 0)
                        {
                            BLL.ShowMessage(this, "This LeaveStructure is already assigned to Employee.You can not delete the record.");
                            return;
                        }
                    }
                    GridDataItem dtItem = (GridDataItem)e.Item;
                    int index = dtItem.ItemIndex;
                    Label lblID = new Label();
                    lblID = RG_LeaveDetails.Items[index].FindControl("lbl_LEAVESTRUCTDET_ID") as Label;
                    _obj_smhr_leaveStruct = new SMHR_LEAVESTRUCT();
                    _obj_smhr_leaveStruct.OPERATION = operation.Delete;
                    _obj_smhr_leaveStruct.LEAVESTRUCTDET_ID = Convert.ToInt32(lblID.Text);
                    bool status = BLL.set_LeaveStructDetails(_obj_smhr_leaveStruct);
                    if (status == true)
                    {
                        _obj_smhr_leaveStruct = new SMHR_LEAVESTRUCT();
                        _obj_smhr_leaveStruct.OPERATION = operation.Empty;
                        _obj_smhr_leaveStruct.LEAVESTRUCTDET_LEAVESTR_ID = Convert.ToInt32(_leavestruct_ID);
                        _obj_smhr_leaveStruct.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtDet = BLL.get_LeaveStructDetails(_obj_smhr_leaveStruct);
                        RG_LeaveDetails.DataSource = dtDet;
                        RG_LeaveDetails.DataBind();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveStructure", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

        }

    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearFields();
            Mode = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveStructure", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

        }

    }

    protected void rntxt_DaysPerYear_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (chk_Accumulate.Checked)
            {
                if (rntxt_MaxDaysAllow.Value != null)
                {
                    rntxt_MaxDaysAllow.Value = null;
                    rntxt_MaxDaysAllow.Value = rntxt_DaysPerYear.Value;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveStructure", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

        }

    }

    protected void chkAutoIncrmntLevs_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkAutoIncrmntLevs.Checked)
            {
                rtxtAutoIncrmntLevs.Enabled = true;
                rtxtAutoIncrmntLevs.Value = null;
                rfvAutoIncrmntLevs.Enabled = true;
            }
            else
            {
                rtxtAutoIncrmntLevs.Enabled = false;
                rtxtAutoIncrmntLevs.Value = null;
                rfvAutoIncrmntLevs.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveStructure", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}