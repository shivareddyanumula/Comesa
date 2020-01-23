﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using SMHR;
using System.Data.OleDb;
using System.IO;
using System.Configuration;

public partial class HR_frm_EmpPay : System.Web.UI.Page
{
    SMHR_LOGININFO _obj_LoginInfo;
    SMHR_PAYITEMS_EMP _obj_Emp_Payitems;
    SMHR_PAYITEMS _obj_Payitems;
    SMHR_EMPLOYEEGRADE _obj_Emp_Grade;

    string strfilename1;

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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("PAY ITEM WISE EMPLOYEE INFORMATION");
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
                    RG_PayElements.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Save.Visible = false;
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
                LoadCombos();
                btn_Save.Visible = false;
                btn_Cancel.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpPay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadCombos()
    {
        try
        {
            rcb_BussinessUnit.Items.Clear();
            _obj_LoginInfo = new SMHR_LOGININFO();
            _obj_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_LoginInfo);
            rcb_BussinessUnit.DataSource = dt_BUDetails;
            rcb_BussinessUnit.DataValueField = "BUSINESSUNIT_ID";
            rcb_BussinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            rcb_BussinessUnit.DataBind();
            rcb_BussinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));

            if (Convert.ToInt32(Session["ORG_ID"]) > 0)
            {
                _obj_Emp_Grade = new SMHR_EMPLOYEEGRADE();

                rcbGrade.Items.Clear();
                //rcbGrade.ClearSelection();
                _obj_Emp_Grade.OPERATION = operation.EmployeeGrade;
                _obj_Emp_Grade.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

                DataTable dt = BLL.GetEmployeeGrade(_obj_Emp_Grade);

                if (dt.Rows.Count > 0)
                {
                    rcbGrade.DataSource = dt;
                    rcbGrade.DataTextField = "EMPLOYEEGRADE_CODE";
                    rcbGrade.DataValueField = "EMPLOYEEGRADE_ID";
                    rcbGrade.DataBind();
                }
                rcbGrade.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpPay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearFields();
            btn_Save.Visible = false;
            btn_Cancel.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpPay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void clearFields()
    {
        try
        {


            rcb_BussinessUnit.SelectedIndex = 0;
            rcmb_Payitem.Items.Clear();
            rcmb_Payitem.Items.Insert(0, new RadComboBoxItem("", ""));//to make the selected item refresh
            RG_PayElements.Visible = false;
            //lnk_clear.Visible = false;
            td_lnk.Visible = false;
            txt_Value.Text = string.Empty;
            rcbGrade.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpPay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcb_BussinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcb_BussinessUnit.SelectedIndex != 0)
            {
                //_obj_Emp_Payitems = new SMHR_PAYITEMS_EMP();
                //_obj_Emp_Payitems.MODE = 1;
                //_obj_Emp_Payitems.BUID = Convert.ToInt32(rcb_BussinessUnit.SelectedValue);
                //DataTable dtDetails = BLL.get_EmpDetails(_obj_Emp_Payitems);
                //RG_PayElements.DataSource = dtDetails;
                //RG_PayElements.DataBind();
                //RG_PayElements.Visible = true;

                rcbGrade.Items.Clear();  //to load grades
                rcbGrade.Items.Insert(0, new RadComboBoxItem("", ""));
                _obj_Emp_Grade = new SMHR_EMPLOYEEGRADE();

                rcbGrade.Items.Clear();
                //rcbGrade.ClearSelection();
                _obj_Emp_Grade.OPERATION = operation.EmployeeGrade;
                _obj_Emp_Grade.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

                DataTable dt = BLL.GetEmployeeGrade(_obj_Emp_Grade);

                if (dt.Rows.Count > 0)
                {
                    rcbGrade.DataSource = dt;
                    rcbGrade.DataTextField = "EMPLOYEEGRADE_CODE";
                    rcbGrade.DataValueField = "EMPLOYEEGRADE_ID";
                    rcbGrade.DataBind();
                }
                rcbGrade.Items.Insert(0, new RadComboBoxItem("Select"));

                rcmb_Payitem.Items.Clear();  // to load payitems
                rcmb_Payitem.Items.Insert(0, new RadComboBoxItem("", ""));//to make the selected item refresh
                _obj_Payitems = new SMHR_PAYITEMS();
                _obj_Payitems.OPERATION = operation.EMPTY1;
                _obj_Payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_Details = BLL.get_PayItems(_obj_Payitems);
                rcmb_Payitem.DataSource = dt_Details;
                rcmb_Payitem.DataTextField = "PAYITEM_PAYITEMNAME";
                rcmb_Payitem.DataValueField = "PAYITEM_ID";
                rcmb_Payitem.DataBind();
                rcmb_Payitem.Items.Insert(0, new RadComboBoxItem("Select"));
            }
            else
            {
                RG_PayElements.Visible = false;
                btn_Save.Visible = false;
                btn_Cancel.Visible = false;
                //lnk_clear.Visible = false;
                td_lnk.Visible = false;
                txt_Value.Text = string.Empty;
                rcbGrade.Items.Clear();   //to clear grades
                rcbGrade.Items.Insert(0, new RadComboBoxItem("Select"));
                rcmb_Payitem.Items.Clear();
                rcmb_Payitem.Items.Insert(0, new RadComboBoxItem("Select"));//to make the selected item refresh
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpPay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcbGrade_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {

            if (rcbGrade.SelectedIndex > 0)
            {
                _obj_Emp_Payitems = new SMHR_PAYITEMS_EMP();

                _obj_Emp_Payitems.MODE = 6;
                _obj_Emp_Payitems.BUID = Convert.ToInt32(rcb_BussinessUnit.SelectedValue);
                _obj_Emp_Payitems.SMHR_EMP_GRADEID = Convert.ToInt32(rcbGrade.SelectedValue);

                if (rcmb_Payitem.SelectedIndex > 0)
                {
                    _obj_Emp_Payitems.MODE = 7;
                    _obj_Emp_Payitems.SMHR_EMP_PAYITEMS_ID = Convert.ToInt32(rcmb_Payitem.SelectedValue);
                    _obj_Emp_Payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

                }

                DataTable dtDetails = BLL.get_EmpDetails(_obj_Emp_Payitems);

                RG_PayElements.DataSource = dtDetails;
                RG_PayElements.DataBind();
                RG_PayElements.Visible = true;
                // rcmb_Payitem.Items.Clear();
                //rcmb_Payitem.Items.Insert(0, new RadComboBoxItem("", ""));
                if (rcmb_Payitem.SelectedIndex > 0)
                {
                    //To get distinct value from Calculation mode
                    var calc_mode = dtDetails.DefaultView.ToTable(true, new String[] { "SMHR_EMP_PAYITEMS_CALMODE" });
                    string mode = string.Empty;
                    foreach (DataRow dr in calc_mode.Rows)
                    {
                        if (!string.IsNullOrEmpty(dr[0].ToString()))
                            mode = dr[0].ToString();
                    }
                    if (mode == "%Age")
                    {
                        txt_Value.MinValue = 0;
                        txt_Value.MaxValue = 100;
                        txt_Value.Type = NumericType.Percent;
                    }
                    else
                    {
                        txt_Value.MinValue = 0;
                        txt_Value.MaxValue = 9999999999;
                        txt_Value.Type = NumericType.Number;
                    }

                    CheckBox chk = new CheckBox();
                    TextBox txt_Box = new TextBox();

                    for (int i = 0; i < dtDetails.Rows.Count; i++)
                    {
                        chk = RG_PayElements.Items[i].FindControl("chk_Select") as CheckBox;
                        txt_Box = RG_PayElements.Items[i].FindControl("txt_Value") as TextBox;

                        if (txt_Box.Text != "")
                        {
                            if (Convert.ToString(dtDetails.Rows[i]["SMHR_EMP_PAYITEMS_CHECKED"]) == "0")
                                chk.Checked = false;
                            else
                                chk.Checked = true;
                        }
                        else
                        {
                            chk.Checked = false;
                        }
                    }
                }

                if (RG_PayElements.Items.Count > 0 && rcmb_Payitem.SelectedIndex > 0)
                {
                    btn_Save.Visible = true;
                    btn_Cancel.Visible = true;
                    td_lnk.Visible = true;
                    txt_Value.Text = string.Empty;
                }
                else
                {
                    btn_Save.Visible = false;
                    btn_Cancel.Visible = false;
                    td_lnk.Visible = false;
                    txt_Value.Text = string.Empty;
                }
            }
            else
            {
                RG_PayElements.Visible = false;
                //lnk_clear.Visible = false;
                td_lnk.Visible = false;
                txt_Value.Text = string.Empty;
                rcmb_Payitem.Items.Clear();
                rcmb_Payitem.Items.Insert(0, new RadComboBoxItem("", ""));//to make the selected item refresh
                rcb_BussinessUnit_SelectedIndexChanged(null, null);
                btn_Save.Visible = false;
                btn_Cancel.Visible = false;
            }
            //RG_PayElements.Visible = false;     //written by Eshwar_Dev 20170516 due to audit trail
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpPay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_Payitem_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            /*if (rcbGrade.SelectedValue==string.Empty)
            {
            }*/
            DataTable dtpf = new DataTable();
            if (rcmb_Payitem.SelectedIndex != 0 && rcbGrade.SelectedIndex != 0)
            {
                _obj_Emp_Payitems = new SMHR_PAYITEMS_EMP();
                _obj_Emp_Payitems.MODE = 7; //2;
                _obj_Emp_Payitems.BUID = Convert.ToInt32(rcb_BussinessUnit.SelectedValue);
                _obj_Emp_Payitems.SMHR_EMP_PAYITEMS_ID = Convert.ToInt32(rcmb_Payitem.SelectedValue);
                _obj_Emp_Payitems.SMHR_EMP_GRADEID = Convert.ToInt32(Convert.ToString(rcbGrade.SelectedValue));
                _obj_Emp_Payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

                DataTable dtDetails = BLL.get_EmpDetails(_obj_Emp_Payitems);
                RG_PayElements.DataSource = dtDetails;
                RG_PayElements.DataBind();

                //To get distinct value from Calculation mode
                var calc_mode = dtDetails.DefaultView.ToTable(true, new String[] { "SMHR_EMP_PAYITEMS_CALMODE" });
                string mode = string.Empty;
                foreach (DataRow dr in calc_mode.Rows)
                {
                    if (!string.IsNullOrEmpty(dr[0].ToString()))
                        mode = dr[0].ToString();
                }
                if (mode == "%Age")
                {
                    txt_Value.MinValue = 0;
                    txt_Value.MaxValue = 100;
                    txt_Value.Type = NumericType.Percent;
                }
                else
                {
                    txt_Value.MinValue = 0;
                    txt_Value.MaxValue = 9999999999;
                    txt_Value.Type = NumericType.Number;
                }

                CheckBox chk = new CheckBox();
                TextBox txt_Box = new TextBox();

                for (int i = 0; i < dtDetails.Rows.Count; i++)
                {
                    chk = RG_PayElements.Items[i].FindControl("chk_Select") as CheckBox;
                    txt_Box = RG_PayElements.Items[i].FindControl("txt_Value") as TextBox;
                    Label lbl_ID = new Label();

                    /*for pf*/
                    /* if (txt_Value.Text == "22" || txt_Value.Text == "23")
                     {

                         txt_Box.Enabled = false;
                         SMHR_EMPPENSIONSCHEME _obj_Smhr_EMPPENSIONSCHEME = new SMHR_EMPPENSIONSCHEME();
                         _obj_Smhr_EMPPENSIONSCHEME = new SMHR_EMPPENSIONSCHEME();
                         _obj_Smhr_EMPPENSIONSCHEME.OPERATION = operation.Check1;
                         _obj_Smhr_EMPPENSIONSCHEME.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                         _obj_Smhr_EMPPENSIONSCHEME.EMPPENSIONSCHEME_EMPID = Convert.ToInt32(lbl_ID.Text);

                         dtpf = BLL.get_PensionScheme(_obj_Smhr_EMPPENSIONSCHEME);

                         if (dtpf.Rows.Count == 0)
                             txt_Box.Text = string.Empty;
                     }
                     if (Convert.ToString(txt_Box.Text) != string.Empty)   //04042016
                     {

                         chk.Checked = true;


                             if (txt_Value.Text == "22" || txt_Value.Text == "23")
                                 txt_Box.Enabled = false;
                         else
                                 txt_Box.Enabled = true;
                     }
                     else
                     {
                         chk.Checked = false;
                         chk.Enabled = true;
                     }

                     */

                    ///////////////////  2242016
                    if (txt_Box.Text != "")
                    {
                        if (Convert.ToString(dtDetails.Rows[i]["SMHR_EMP_PAYITEMS_CHECKED"]) == "0")
                            chk.Checked = false;
                        else
                            chk.Checked = true;
                    }
                    else
                    {
                        chk.Checked = false;
                    }

                }
                //lnk_clear.Visible = true;
                td_lnk.Visible = true;
                txt_Value.Text = string.Empty;

                RG_PayElements.Visible = true;       //written by Eshwar_Dev 20170516 due to audit trail
            }
            else
            {

                // for clearing the payitem values for each employee
                rcb_BussinessUnit_SelectedIndexChanged(null, null);
                //lnk_clear.Visible = false;
                td_lnk.Visible = false;
                txt_Value.Text = string.Empty;

                if (rcbGrade.SelectedIndex == 0)
                    BLL.ShowMessage(this, "Please select grade before choose payitem");
                //rcbGrade.SelectedValue = null;

                RG_PayElements.Visible = btn_Save.Visible = btn_Cancel.Visible = false;       //written by Eshwar_Dev 20170516 due to audit trail
                return;
            }

            /*else
            {
               BLL.ShowMessage(this, "Please select grade before choose payitem");
                return;
            }*/
            if (RG_PayElements.Items.Count == 0)
            {
                // for clearing the payitem values for each employee
                //rcb_BussinessUnit_SelectedIndexChanged(null, null);
                //lnk_clear.Visible = false;
                td_lnk.Visible = false;
                txt_Value.Text = string.Empty;

                btn_Save.Visible = false;
                btn_Cancel.Visible = false;
            }
            else
            {
                if (rcmb_Payitem.SelectedIndex > 0)
                {
                    btn_Save.Visible = true;
                    btn_Cancel.Visible = true;
                }
                else
                {
                    btn_Save.Visible = false;
                    btn_Cancel.Visible = false;
                }
            }

            if (rcb_BussinessUnit.SelectedIndex > 0 && rcbGrade.SelectedIndex > 0 && rcmb_Payitem.SelectedIndex > 0)
                btn_Imp_payitem.Enabled = true;
            else
            {
                btn_Imp_payitem.Enabled = false;
                BLL.ShowMessage(this, "Plese select all fields to import excel doc..");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpPay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void chk_selectall_checkedchanged(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < RG_PayElements.Items.Count; i++)
            {
                CheckBox Chk_All = (CheckBox)sender;
                if (Chk_All.Checked)
                {
                    for (int index = 0; index < RG_PayElements.Items.Count; index++)
                    {
                        CheckBox c = (CheckBox)RG_PayElements.Items[index].FindControl("chk_Select");
                        c.Checked = true; ;
                    }
                }
                else
                {
                    for (int index = 0; index < RG_PayElements.Items.Count; index++)
                    {
                        CheckBox c = (CheckBox)RG_PayElements.Items[index].FindControl("chk_Select");
                        c.Checked = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpPay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    CheckBox chk_box1 = new CheckBox();
        //    TextBox txt_Val1 = new TextBox();
        //    int j = 0;
        //    int j1 = 0;
        //    for (int i = 0; i < RG_PayElements.Items.Count; i++)
        //    {
        //        chk_box1 = RG_PayElements.Items[i].FindControl("chk_Select") as CheckBox;
        //        txt_Val1 = RG_PayElements.Items[i].FindControl("txt_Value") as TextBox;
        //        if (chk_box1.Checked)
        //        {
        //            j = j + 1;
        //        }
        //        if (txt_Val1.Text != "")
        //        {
        //            j1 = j1 + 1;
        //        }
        //    }
        //    _obj_Emp_Payitems = new SMHR_PAYITEMS_EMP();
        //    _obj_Emp_Payitems.MODE = 4;
        //    _obj_Emp_Payitems.SMHR_EMP_PAYITEMS_PAYITEMID = Convert.ToInt32(rcmb_Payitem.SelectedValue);
        //    _obj_Emp_Payitems.BUID = Convert.ToInt32(rcb_BussinessUnit.SelectedItem.Value);
        //    _obj_Emp_Payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
        //    bool status1 = BLL.set_EmpPayElements_1(_obj_Emp_Payitems);
        //    if (j1 != 0 && j != 0)
        //    {
        //        _obj_Payitems = new SMHR_PAYITEMS();
        //        _obj_Payitems.OPERATION = operation.Select;
        //        _obj_Payitems.PAYITEM_ID = Convert.ToInt32(rcmb_Payitem.SelectedValue);
        //        DataTable dt = BLL.get_PayItems(_obj_Payitems);
        //        Label lbl_ID = new Label();
        //        TextBox txt_Val = new TextBox();
        //        CheckBox chk_box = new CheckBox();
        //        DataTable dtPayItemData = GetPayItemTable();
        //        for (int i = 0; i < RG_PayElements.Items.Count; i++)
        //        {
        //            chk_box = RG_PayElements.Items[i].FindControl("chk_Select") as CheckBox;
        //            if (chk_box.Checked)
        //            {
        //                lbl_ID = RG_PayElements.Items[i].FindControl("lbl_EmpID") as Label;
        //                txt_Val = RG_PayElements.Items[i].FindControl("txt_Value") as TextBox;
        //                Label lbl_Ename = RG_PayElements.Items[i].FindControl("lbl_EmpName") as Label;
        //                if (txt_Val.Text != string.Empty)
        //                {
        //                    //_obj_Emp_Payitems = new SMHR_PAYITEMS_EMP();
        //                    //_obj_Emp_Payitems.MODE = 3;
        //                    //_obj_Emp_Payitems.SMHR_EMP_PAYITEMS_CHECKED = true;
        //                    //_obj_Emp_Payitems.SMHR_EMP_PAYITEMS_EMPID = Convert.ToInt32(lbl_ID.Text);
        //                    //_obj_Emp_Payitems.BUID = Convert.ToInt32(rcb_BussinessUnit.SelectedItem.Value);
        //                    //_obj_Emp_Payitems.SMHR_EMP_PAYITEMS_PAYITEMID = Convert.ToInt32(rcmb_Payitem.SelectedValue);
        //                    //_obj_Emp_Payitems.SMHR_EMP_PAYITEMS_CALMODE = Convert.ToString(dt.Rows[0]["PAYITEM_CALMODE"]);
        //                    //_obj_Emp_Payitems.SMHR_EMP_PAYITEMS_VALUE = Convert.ToDouble(txt_Val.Text);
        //                    //_obj_Emp_Payitems.SMHR_EMP_PAYITEMS_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
        //                    //_obj_Emp_Payitems.SMHR_EMP_PAYITEMS_CREATEDDATE = DateTime.Now;
        //                    //_obj_Emp_Payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

        //                    dtPayItemData.Rows.Add(Convert.ToInt32(lbl_ID.Text), Convert.ToInt32(Session["ORG_ID"]), Convert.ToInt32(rcmb_Payitem.SelectedValue),
        //                        Convert.ToString(dt.Rows[0]["PAYITEM_CALMODE"]), Convert.ToDouble(txt_Val.Text), true, Convert.ToInt32(Session["USER_ID"]), DateTime.Now, Convert.ToInt32(rcb_BussinessUnit.SelectedItem.Value));

        //                }
        //            }
        //        }

        //        bool status = BLL.set_EmpPayElements_1(dtPayItemData, Convert.ToInt32(rcmb_Payitem.SelectedValue));
        //        BLL.ShowMessage(this, "Pay Item Value Saved for the selected employees");

        //        btn_Save.Visible = false;
        //        btn_Cancel.Visible = false;
        //    }
        //    else if (j == 0)
        //    {
        //        BLL.ShowMessage(this, "Please select atleast one Employee");
        //        return;
        //    }
        //    else if (j != 0 && j1 == 0)
        //    {
        //        BLL.ShowMessage(this, "Please enter value for selected Employee");
        //        return;
        //    }

        //    clearFields();
        //}



        try
        {
            _obj_Emp_Payitems = new SMHR_PAYITEMS_EMP();
            _obj_Emp_Payitems.MODE = 5;
            _obj_Emp_Payitems.SMHR_EMP_PAYITEMS_ID = Convert.ToInt32(rcmb_Payitem.SelectedValue);
            // _obj_Emp_Payitems.BUID = Convert.ToInt32(rcb_BussinessUnit.SelectedValue);
            DataTable dtDetails = BLL.get_EmpDetails(_obj_Emp_Payitems);
            if (dtDetails.Rows.Count > 0)
            {
                TextBox txtgetVal = new TextBox();
                CheckBox chkChoose = new CheckBox();
                int jj = 0;
                for (int i = 0; i <= RG_PayElements.Items.Count - 1; i++)
                {
                    //Label lblCalMode = new Label();

                    chkChoose = RG_PayElements.Items[i].FindControl("chk_Select") as CheckBox;
                    txtgetVal = RG_PayElements.Items[i].FindControl("txt_Value") as TextBox;
                    //lblCalMode = RG_PayElements.Items[i].FindControl("lblCALMODE_1") as Label;
                    if (Convert.ToString(txtgetVal.Text) != "")
                    {
                        if (Convert.ToString(dtDetails.Rows[0]["PAYITEM_CALMODE"]).ToUpper() == "%AGE")
                        {
                            if (Convert.ToDouble(txtgetVal.Text) > 100)
                            {
                                BLL.ShowMessage(this, "Percentage Value Should Not Exceed 100%");
                                return;
                            }
                        }
                        if (chkChoose.Checked == false)
                        {
                            BLL.ShowMessage(this, "Please Check The Pay Element To Which You Want To Give Value");
                            return;
                        }
                    }
                    else
                    {
                        jj = jj + 1;
                    }
                }
                //if (jj == RG_PayElements.Items.Count)
                //{
                //    BLL.ShowMessage(this, "Please Enter Atleaset One Value");
                //    return;
                //}
            }

            CheckBox chk_box1 = new CheckBox();
            TextBox txt_Val1 = new TextBox();
            int j = 0;
            int j1 = 0;
            for (int i = 0; i < RG_PayElements.Items.Count; i++)
            {
                chk_box1 = RG_PayElements.Items[i].FindControl("chk_Select") as CheckBox;
                txt_Val1 = RG_PayElements.Items[i].FindControl("txt_Value") as TextBox;
                if (chk_box1.Checked)
                {
                    j = j + 1;
                }
                if (txt_Val1.Text != "")
                {
                    j1 = j1 + 1;
                }
            }
            _obj_Emp_Payitems = new SMHR_PAYITEMS_EMP();
            _obj_Emp_Payitems.MODE = 4;
            _obj_Emp_Payitems.SMHR_EMP_PAYITEMS_PAYITEMID = Convert.ToInt32(rcmb_Payitem.SelectedValue);
            _obj_Emp_Payitems.BUID = Convert.ToInt32(rcb_BussinessUnit.SelectedItem.Value);
            _obj_Emp_Payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            bool status1 = BLL.set_EmpPayElements_1(_obj_Emp_Payitems);

            SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();

            _obj_smhr_emp_payitems.OPERATION = operation.GETGRADE;
            _obj_smhr_emp_payitems.SMHR_EMP_PAYITEMS_PAYITEMID = Convert.ToInt32(rcmb_Payitem.SelectedValue);

            DataTable dtOldIDs = BLL.get_EmpDetails(_obj_smhr_emp_payitems);

            string oldIDs = string.Empty;

            if (dtOldIDs.Rows.Count > 0)
            {
                for (int p = 0; p < dtOldIDs.Rows.Count; p++)
                    oldIDs = oldIDs + Convert.ToString(dtOldIDs.Rows[p]["SMHR_EMP_PAYITEMS_ID"]) + ",";

                if (oldIDs != string.Empty)
                    oldIDs = oldIDs.Remove(oldIDs.Length - 1);
            }

            if (j1 != 0 && j != 0)
            {
                string ids = string.Empty;

                _obj_Payitems = new SMHR_PAYITEMS();
                _obj_Payitems.OPERATION = operation.Select;
                _obj_Payitems.PAYITEM_ID = Convert.ToInt32(rcmb_Payitem.SelectedValue);
                DataTable dt = BLL.get_PayItems(_obj_Payitems);
                Label lbl_ID = new Label();

                Label lblEmpPayItemID = new Label();    //To get Employee Pay Item ID

                TextBox txt_Val = new TextBox();
                CheckBox chk_box = new CheckBox();
                for (int i = 0; i < RG_PayElements.Items.Count; i++)
                {
                    chk_box = RG_PayElements.Items[i].FindControl("chk_Select") as CheckBox;
                    if (chk_box.Checked)
                    {
                        lbl_ID = RG_PayElements.Items[i].FindControl("lbl_EmpID") as Label;
                        txt_Val = RG_PayElements.Items[i].FindControl("txt_Value") as TextBox;
                        Label lbl_Ename = RG_PayElements.Items[i].FindControl("lbl_EmpName") as Label;

                        lblEmpPayItemID = RG_PayElements.Items[i].FindControl("lblEmpPayItemID") as Label;

                        if (txt_Val.Text != string.Empty)
                        {
                            _obj_Emp_Payitems = new SMHR_PAYITEMS_EMP();
                            _obj_Emp_Payitems.MODE = 3;
                            _obj_Emp_Payitems.SMHR_EMP_PAYITEMS_CHECKED = true;
                            _obj_Emp_Payitems.SMHR_EMP_PAYITEMS_EMPID = Convert.ToInt32(lbl_ID.Text);
                            _obj_Emp_Payitems.BUID = Convert.ToInt32(rcb_BussinessUnit.SelectedItem.Value);
                            _obj_Emp_Payitems.SMHR_EMP_PAYITEMS_PAYITEMID = Convert.ToInt32(rcmb_Payitem.SelectedValue);
                            _obj_Emp_Payitems.SMHR_EMP_PAYITEMS_CALMODE = Convert.ToString(dt.Rows[0]["PAYITEM_CALMODE"]);
                            _obj_Emp_Payitems.SMHR_EMP_PAYITEMS_VALUE = Convert.ToDouble(txt_Val.Text);
                            _obj_Emp_Payitems.SMHR_EMP_PAYITEMS_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                            _obj_Emp_Payitems.SMHR_EMP_PAYITEMS_CREATEDDATE = DateTime.Now;
                            _obj_Emp_Payitems.SMHR_EMP_PAYITEMS_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                            _obj_Emp_Payitems.SMHR_EMP_PAYITEMS_LASTMDFDATE = DateTime.Now;
                            _obj_Emp_Payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            bool status = BLL.set_EmpPayElements_1(_obj_Emp_Payitems);
                        }

                        if ((lblEmpPayItemID.Text != string.Empty) && (Convert.ToString(txt_Val.Text) != string.Empty))
                            ids = ids + lblEmpPayItemID.Text + ",";
                    }
                }

                if (ids != string.Empty)
                    ids = ids.Remove(ids.Length - 1);

                _obj_smhr_emp_payitems.OPERATION = operation.DelPic;

                _obj_smhr_emp_payitems.SDATE = ids;     //for new IDs
                _obj_smhr_emp_payitems.EDATE = oldIDs;  //for old IDs
                _obj_smhr_emp_payitems.SMHR_EMP_PAYITEMS_PAYITEMID = Convert.ToInt32(rcmb_Payitem.SelectedValue);
                _obj_smhr_emp_payitems.SMHR_EMP_PAYITEMS_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);

                BLL.set_EmpPayElements(_obj_smhr_emp_payitems);
            }

            BLL.ShowMessage(this, "Pay Item Value Saved For The Selected Employees");
            // upload.Visible = false;
            //A1.Visible = false;
            //FileUpload2.Visible = false;
            //btn_Imp_payitem.Visible = false;
            btn_Imp_payitem.Enabled = false;
            clearFields();
            btn_Save.Visible = false;
            btn_Cancel.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpPay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    private DataTable GetPayItemTable()
    {
        DataTable dtPayItemTable = new DataTable();
        try
        {
            //DataTable dtPayItemTable = new DataTable();
            dtPayItemTable.Columns.Add("SMHR_EMP_PAYITEMS_EMPID", typeof(int));
            dtPayItemTable.Columns.Add("SMHR_EMP_PAYITEMS_ORGANISATION_ID", typeof(int));
            dtPayItemTable.Columns.Add("SMHR_EMP_PAYITEMS_PAYITEMID", typeof(int));
            dtPayItemTable.Columns.Add("SMHR_EMP_PAYITEMS_CALMODE", typeof(string));
            dtPayItemTable.Columns.Add("SMHR_EMP_PAYITEMS_VALUE", typeof(double));
            dtPayItemTable.Columns.Add("SMHR_EMP_PAYITEMS_CHECKED", typeof(bool));
            dtPayItemTable.Columns.Add("SMHR_EMP_PAYITEMS_CREATEDBY", typeof(int));
            dtPayItemTable.Columns.Add("SMHR_EMP_PAYITEMS_CREATEDDATE", typeof(DateTime));
            dtPayItemTable.Columns.Add("SMHR_EMP_PAYITEMS_BUID", typeof(int));
            return dtPayItemTable;
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpPay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return dtPayItemTable;
        }
    }

    protected void lnk_clear_Click(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < RG_PayElements.Items.Count; i++)
            {
                CheckBox chk = RG_PayElements.Items[i].FindControl("chk_Select") as CheckBox;
                TextBox txt_val = RG_PayElements.Items[i].FindControl("txt_Value") as TextBox;
                chk.Checked = false;
                txt_val.Text = "";
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpPay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void loadGrid()
    {
        try
        {
            _obj_Emp_Payitems = new SMHR_PAYITEMS_EMP();
            _obj_Emp_Payitems.MODE = 1;
            _obj_Emp_Payitems.BUID = Convert.ToInt32(rcb_BussinessUnit.SelectedValue);
            DataTable dtDetails = BLL.get_EmpDetails(_obj_Emp_Payitems);
            RG_PayElements.DataSource = dtDetails;
            RG_PayElements.DataBind();
            RG_PayElements.Visible = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpPay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnkApplyAll_Click(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(txt_Value.Text.Trim()))
            {
                for (int i = 0; i < RG_PayElements.Items.Count; i++)
                {
                    CheckBox chk = RG_PayElements.Items[i].FindControl("chk_Select") as CheckBox;
                    TextBox txt_val = RG_PayElements.Items[i].FindControl("txt_Value") as TextBox;
                    if (!chk.Checked)
                        chk.Checked = true;
                    txt_val.Text = txt_Value.Text;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpPay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void RG_PayElements_ItemDataBound(object sender, GridItemEventArgs e)
    {
        try
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                Label lblIsEnabled = item.FindControl("lblIsEnabled") as Label;
                CheckBox chk_Select = item.FindControl("chk_Select") as CheckBox;
                TextBox txt_Value = item.FindControl("txt_Value") as TextBox;
                if (lblIsEnabled.Text != "")
                {
                    int isEnabled = Convert.ToInt32((item.FindControl("lblIsEnabled") as Label).Text);
                    chk_Select.Enabled = Convert.ToBoolean(isEnabled);
                    txt_Value.Enabled = Convert.ToBoolean(isEnabled);
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpPay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Btn_Imp_payitem_click(object sender, EventArgs e)
    {
        try
        {
            if (rcb_BussinessUnit.SelectedIndex > 0 && rcbGrade.SelectedIndex > 0 && rcmb_Payitem.SelectedIndex > 0)
            {

                _obj_Emp_Payitems = new SMHR_PAYITEMS_EMP();
                _obj_Emp_Payitems.MODE = 2;
                _obj_Emp_Payitems.BUID = Convert.ToInt32(rcb_BussinessUnit.SelectedValue);
                _obj_Emp_Payitems.SMHR_EMP_PAYITEMS_ID = Convert.ToInt32(rcmb_Payitem.SelectedValue);
                _obj_Emp_Payitems.ORGANISATION_ID = Convert.ToInt32(Session["org_id"]);

                DataTable dtdetails = BLL.get_EmpDetails(_obj_Emp_Payitems);

                string strcon = null;
                DataSet ds_directemp = new DataSet();
                DataSet ds = new DataSet();

                strfilename1 = FileUpload2.FileName;

                // string fn = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                // strfilename2 = Convert.ToString(DateTime.Now.TimeOfDay) + "_" + strfilename1;
                // strfilename2 = strfilename2.Replace("/", "").Replace(":", ".");

                if (FileUpload2.HasFile)
                {
                    if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == false)
                    {
                        System.IO.Directory.CreateDirectory(Server.MapPath("~/IMPORT_EXCEL/"));
                    }
                    FileUpload2.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/IMPORT_EXCEL/"), strfilename1));
                    string filename1 = Server.MapPath("~/IMPORT_EXCEL/") + ("") + (Convert.ToString(strfilename1));
                    FileInfo fileInfo = new FileInfo(filename1);

                    if (fileInfo.Exists)
                    {
                        string path = MapPath(strfilename1);
                        string ext = Path.GetExtension(path);
                        string type = string.Empty;
                        // string name = Path.GetFileName( path );
                        if (ext != null)
                        {
                            switch (ext.ToLower())
                            {
                                case ".xls":
                                    type = "excel";
                                    break;

                                case ".xlsx":
                                    type = "excel";
                                    break;

                                default:
                                    type = string.Empty;
                                    break;
                            }
                        }
                        if (type == string.Empty)
                        {
                            if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == true)
                            {
                                string path1 = Server.MapPath("~/IMPORT_EXCEL/") + ("") + (Convert.ToString(strfilename1));
                                System.IO.File.Delete(path1);
                            }

                            BLL.ShowMessage(this, "Please Select Excel File (Eg: Excel.xlsx).");
                            return;
                        }
                    }
                }
                else
                {
                    BLL.ShowMessage(this, "Please Select The File To Be Uploaded");
                    return;
                }

                string strpath = Server.MapPath("~/IMPORT_EXCEL/");
                strpath = strpath + strfilename1;

                // Getting data from excell file to dataset.
                // strcon = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source='" + strpath + "';" + "Extended Properties=Excel 12.0;";
                strcon = "Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=Excel 8.0;Data Source={0}";
                OleDbConnection objConn = null;
                objConn = new OleDbConnection(strcon);
                objConn.Open();

                DataTable dt_chk2 = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string sheetname;
                if (dt_chk2 == null)
                {
                    objConn.Close();
                    //  Delete_Excel_File();
                    BLL.ShowMessage(this, "Please Select Correct Excel Template Sheet.");
                    return;
                }
                else
                {
                    sheetname = Convert.ToString(dt_chk2.Rows[0]["TABLE_NAME"]);// personal details
                }

                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM  [" + sheetname + "]", strcon);
                da.Fill(ds);
                ds.Tables[0].Columns.Add("Error Message");

                objConn.Close();
                DataTable dt = new DataTable();
                DataTable dtfail = new DataTable();

                string errormsg = string.Empty;
                string columnno = null;

                Int32 rowno = 0;
                Boolean filestatus = true;

                dtfail.Columns.Add("S.NO", typeof(Int32));
                dtfail.Columns.Add("ROWNO", typeof(Int32));
                dtfail.Columns.Add("COLUMNS NAMES", typeof(string));

                if (ds.Tables[0].Columns[0].ToString().Trim() == "Employee Code*")
                {

                }
                else
                {
                    Delete_Excel_File();
                    BLL.ShowMessage(this, "Please Select Correct Excel Template Sheet.");
                    return;
                }
                if (ds.Tables[0].Columns[1].ToString().Trim() == "Employee Name")
                {

                }
                else
                {
                    Delete_Excel_File();
                    BLL.ShowMessage(this, "Please Select Correct Excel Template Sheet.");
                    return;
                }
                if (ds.Tables[0].Columns[2].ToString().Trim() == "Scale*")
                {

                }
                else
                {
                    Delete_Excel_File();
                    BLL.ShowMessage(this, "Please Select Correct Excel Template Sheet.");
                    return;
                }
                if (ds.Tables[0].Columns[3].ToString().Trim() == "Value*")
                {

                }
                else
                {
                    Delete_Excel_File();
                    BLL.ShowMessage(this, "Please Select Correct Excel Template Sheet.");
                    return;
                }

                CheckBox chk = new CheckBox();
                TextBox txt_box = new TextBox();
                Label lbl_EmpITDS = new Label();

                //if (ds_directemp.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() != "")
                //{
                //    for (int j = 0; j < ds_directemp.Tables[0].Rows.Count; j++)
                //    {
                //        if (i != j)
                //        {
                //            if (ds_directemp.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() == ds_directemp.Tables[0].Rows[j]["Applicant SNO*"].ToString().Trim())
                //            {
                //                errormsg = "Applicant SNO is repeated in excel Sheet";
                //                filestatus = false;
                //                rowno = i + 2;
                //                columnno = columnno + "," + "Applicant SNO*";
                //            }
                //        }
                //    }
                //}
                //else
                //{
                //    filestatus = false;
                //    rowno = i + 2;
                //    columnno = columnno + "," + "Applicant SNO*";
                //}

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    errormsg = "";

                    if (ds.Tables[0].Rows[i]["Employee Code*"].ToString().Trim() != "")
                    {
                        for (int J = 0; J < ds.Tables[0].Rows.Count; J++)
                        {
                            if (i != J)
                            {
                                if (ds.Tables[0].Rows[i]["Employee Code*"].ToString().Trim() == ds.Tables[0].Rows[J]["Employee Code*"].ToString().Trim())
                                {
                                    errormsg = "Employee Code Is Repeated In Excel Sheet";

                                    filestatus = false;
                                    rowno = i + 2;
                                    columnno = columnno + "," + "Employee Code*";
                                }
                            }
                        }
                    }

                    if (ds.Tables[0].Rows[i]["Value*"].ToString().Trim() != "")
                    {
                        bool containsLetter = false;
                        string val = ds.Tables[0].Rows[i]["Value*"].ToString().Trim();
                        //   string v = "-23";

                        for (int B = 0; B < val.Length; B++)
                        {
                            if (!char.IsNumber(val[B]) && val[B].ToString() != ".")
                            {
                                if (B == 0 && val[B].ToString() != "-")
                                    containsLetter = true;
                            }
                        }

                        if (containsLetter)
                        {
                            errormsg = errormsg + "," + "Enter Numerics In Value Column ";

                            filestatus = false;
                            rowno = i + 2;
                            columnno = columnno + "," + "Value*";
                        }
                    }

                    if (ds.Tables[0].Rows[i]["Employee Code*"].ToString().Trim() != "")
                    {
                        bool v = false;

                        for (int count = 0; count < dtdetails.Rows.Count; count++)
                        {
                            if (((ds.Tables[0].Rows[i]["Employee Code*"].ToString().Trim()) == dtdetails.Rows[count]["SMHR_EMP_ITDS_ID"].ToString().Trim()) || ((ds.Tables[0].Rows[i]["Employee Code*"].ToString().Trim()) == dtdetails.Rows[count]["EMP_EMPCODE"].ToString().Trim()))
                            {
                                v = true;
                                continue;
                            }
                        }

                        if (v == false)
                        {
                            errormsg = errormsg + "," + "Employee Code Does Not Exist";

                            filestatus = false;
                            rowno = i + 2;
                            columnno = columnno + "," + "Employee Code*";
                        }
                    }

                    if (filestatus == false)
                    {
                        DataRow newrow = dtfail.NewRow();
                        newrow["S.NO"] = dtfail.Rows.Count + 1;

                        newrow["ROWNO"] = rowno;
                        newrow["COLUMNS NAMES"] = columnno;
                        ds.Tables[0].Rows[i]["Error Message"] = errormsg;
                        dtfail.Rows.Add(newrow);
                    }
                }

                if (dtfail.Rows.Count > 0)
                {
                    Session["dt_fail"] = dtfail;
                    Session["ds_data"] = ds;
                    Delete_Excel_File();
                    //LinkButton lnk_Import_process = (LinkButton)RadPanelBar1.FindItemByValue("AddAttachment").FindControl("lnk_Import_process");
                    Telerik.Web.UI.RadWindow newwindow = new Telerik.Web.UI.RadWindow();
                    // RWM_POSTREPLY.Windows.Remove(newwindow);
                    newwindow.ID = "RadWindow_import";

                    newwindow.NavigateUrl = "~/HR/frm_payitemImport.aspx";
                    newwindow.Title = "Import Process";
                    newwindow.Width = 1150;
                    newwindow.Height = 580;
                    newwindow.VisibleOnPageLoad = true;

                    if (RWM_POSTREPLY1.Windows.Count > 1)
                    {
                        RWM_POSTREPLY1.Windows.RemoveAt(1);
                    }

                    RWM_POSTREPLY1.Windows.Add(newwindow);
                    RWM_POSTREPLY1.Visible = true;

                    return;
                }
                else
                {
                    int ui = 0;
                    bool verify = false;

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        verify = false;
                        errormsg = "";

                        if (ds.Tables[0].Rows[i]["Employee Code*"].ToString().Trim() != "")
                        {
                            for (int count = 0; count < dtdetails.Rows.Count; count++)
                            {
                                if (((ds.Tables[0].Rows[i]["Employee Code*"].ToString().Trim()) == dtdetails.Rows[count]["SMHR_EMP_ITDS_ID"].ToString().Trim()) || ((ds.Tables[0].Rows[i]["Employee Code*"].ToString().Trim()) == dtdetails.Rows[count]["EMP_EMPCODE"].ToString().Trim()))
                                {
                                    txt_box = RG_PayElements.Items[count].FindControl("txt_value") as TextBox;
                                    chk = RG_PayElements.Items[count].FindControl("chk_Select") as CheckBox;
                                    lbl_EmpITDS = RG_PayElements.Items[count].FindControl("lbl_EmpITDS") as Label;

                                    txt_box.Text = ds.Tables[0].Rows[i]["Value*"].ToString().Trim();

                                    if (ds.Tables[0].Rows[i]["Value*"].ToString().Trim() != null)
                                    {
                                        chk.Checked = true;
                                    }

                                    verify = true;
                                    continue;
                                }
                            }

                            if (verify == false)
                            {
                                errormsg = "Employee Code Does Not Exist";

                                filestatus = false;
                                rowno = i + 2;
                                columnno = columnno + "," + "Employee Code*";
                            }
                        }

                        if (filestatus == false)
                        {
                            DataRow newrow = dtfail.NewRow();
                            newrow["S.NO"] = dtfail.Rows.Count + 1;


                            newrow["ROWNO"] = rowno;
                            newrow["COLUMNS NAMES"] = columnno;
                            ds.Tables[0].Rows[i]["Error Message"] = errormsg;
                            dtfail.Rows.Add(newrow);
                        }
                    }

                    if (dtfail.Rows.Count > 0)
                    {
                        Session["dt_fail"] = dtfail;
                        Session["ds_data"] = ds;
                        Delete_Excel_File();
                        //LinkButton lnk_Import_process = (LinkButton)RadPanelBar1.FindItemByValue("AddAttachment").FindControl("lnk_Import_process");
                        Telerik.Web.UI.RadWindow newwindow = new Telerik.Web.UI.RadWindow();
                        // RWM_POSTREPLY.Windows.Remove(newwindow);
                        newwindow.ID = "RadWindow_import";

                        newwindow.NavigateUrl = "~/HR/frm_payitemImport.aspx";
                        newwindow.Title = "Import Process";
                        newwindow.Width = 1150;
                        newwindow.Height = 580;
                        newwindow.VisibleOnPageLoad = true;

                        if (RWM_POSTREPLY1.Windows.Count > 1)
                        {
                            RWM_POSTREPLY1.Windows.RemoveAt(1);
                        }

                        RWM_POSTREPLY1.Windows.Add(newwindow);
                        RWM_POSTREPLY1.Visible = true;

                        return;
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Data Imported Successfully");
                    }
                    // upload.Visible = false;
                    //A1.Visible = false;
                    //FileUpload2.Visible = false;
                    //btn_Imp_payitem.Visible = false;
                    btn_Imp_payitem.Enabled = false;
                }
            }
            else
            {
                BLL.ShowMessage(this, "Plese select all fields to import excel doc..");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpPay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Delete_Excel_File()
    {
        try
        {
            if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == true)
            {
                string strpath = Server.MapPath("~/IMPORT_EXCEL/");

                DirectoryInfo dirinfo = new DirectoryInfo(strpath);
                strpath = strpath + strfilename1;

                FileInfo fi = new FileInfo(strpath);
                {
                    fi.Delete();
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpPay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}