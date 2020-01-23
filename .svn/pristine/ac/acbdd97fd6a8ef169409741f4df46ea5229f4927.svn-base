using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using SMHR;

public partial class HR_frm_emppastinfo : System.Web.UI.Page
{
    SMHR_LOGININFO _obj_LoginInfo;
    SMHR_PAYITEMS_EMP _obj_Emp_Payitems;
    SMHR_PAYITEMS _obj_Payitems;
    SMHR_PERIOD obj_smhr_Period;
    SMHR_EMP_TDS _obj_smhr_EMP_TDS;
    bool checkedvalue = false;
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Period Wise Employee Past Gross & TDS Info");//EMPLOYEE PAST GROSS & TDS INFO");
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
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emppastinfo", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
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
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emppastinfo", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearFields();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emppastinfo", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void clearFields()
    {
        try
        {
            //rcb_BussinessUnit.SelectedIndex = 0;
            rcb_BussinessUnit.ClearSelection();
            rcmb_Period.Items.Clear();
            rcmb_Period.Items.Insert(0, new RadComboBoxItem("", ""));
            RG_PayElements.Visible = false;

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emppastinfo", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void rcb_BussinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcb_BussinessUnit.SelectedIndex != 0)
            {
                //_obj_smhr_EMP_TDS = new SMHR_EMP_TDS();
                //_obj_smhr_EMP_TDS.MODE = 1;
                //_obj_smhr_EMP_TDS.TDS_BUID = Convert.ToInt32(rcb_BussinessUnit.SelectedValue);
                //DataTable dtDetails = BLL.get_EMP_TDS_DETAILS(_obj_smhr_EMP_TDS);
                //DataTable dtDetails = new DataTable();
                //RG_PayElements.DataSource = dtDetails;
                //RG_PayElements.DataBind();

                //RG_PayElements.Visible = true;

                rcmb_Period.Items.Clear();
                obj_smhr_Period = new SMHR_PERIOD();
                obj_smhr_Period.OPERATION = operation.Select;
                obj_smhr_Period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_Details = BLL.get_PeriodHeaderDetails(obj_smhr_Period);
                rcmb_Period.DataSource = dt_Details;
                rcmb_Period.DataValueField = "PERIOD_ID";
                rcmb_Period.DataTextField = "PERIOD_NAME";
                rcmb_Period.DataBind();
                rcmb_Period.Items.Insert(0, new RadComboBoxItem("Select"));
            }
            else
            {
                RG_PayElements.Visible = false;
                rcmb_Period.Items.Clear();
                rcmb_Period.Items.Insert(0, new RadComboBoxItem("", ""));

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emppastinfo", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    //protected void rcmb_Payitem_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    //{
    //    try
    //    {
    //        if (rcmb_Period.SelectedIndex != 0)
    //        {
    //            _obj_Emp_Payitems = new SMHR_PAYITEMS_EMP();
    //            _obj_Emp_Payitems.MODE = 2;
    //            _obj_Emp_Payitems.BUID = Convert.ToInt32(rcb_BussinessUnit.SelectedValue);
    //            _obj_Emp_Payitems.SMHR_EMP_PAYITEMS_ID = Convert.ToInt32(rcmb_Period.SelectedValue);
    //            DataTable dtDetails = BLL.get_EmpDetails(_obj_Emp_Payitems);
    //            RG_PayElements.DataSource = dtDetails;
    //            RG_PayElements.DataBind();

    //            CheckBox chk = new CheckBox();
    //            TextBox txt_Box = new TextBox();
    //            for (int i = 0; i < dtDetails.Rows.Count - 1; i++)
    //            {
    //                chk = RG_PayElements.Items[i].FindControl("chk_Select") as CheckBox;
    //                txt_Box = RG_PayElements.Items[i].FindControl("txt_Value") as TextBox;
    //                if (txt_Box.Text != "")
    //                {
    //                    if (Convert.ToString(dtDetails.Rows[i]["SMHR_EMP_PAYITEMS_CHECKED"]) == "0")
    //                        chk.Checked = false;
    //                    else
    //                        chk.Checked = true;
    //                }
    //                else
    //                {
    //                    chk.Checked = false;
    //                }
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpPay", ex.StackTrace, DateTime.Now);
    //    }
    //}
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            CheckBox chk_box1 = new CheckBox();
            TextBox txt_Val1 = new TextBox();
            TextBox txt_Val2 = new TextBox();
            int j = 0;
            for (int i = 0; i < RG_PayElements.Items.Count; i++)
            {
                chk_box1 = RG_PayElements.Items[i].FindControl("chk_Select") as CheckBox;
                txt_Val1 = RG_PayElements.Items[i].FindControl("txt_Value") as TextBox;
                txt_Val2 = RG_PayElements.Items[i].FindControl("txt_tds_Value") as TextBox;
                if (chk_box1.Checked && txt_Val1.Text != "" && txt_Val2.Text != "")
                {
                    j = j + 1;
                }
                if (((txt_Val1.Text != "") || (txt_Val2.Text != "")) && (chk_box1.Checked == false))
                {
                    checkedvalue = true;
                }
            }
            if (checkedvalue)
            {
                BLL.ShowMessage(this, "Please Select The Employee");
                return;
            }
            if (j != 0)
            {

                _obj_smhr_EMP_TDS = new SMHR_EMP_TDS();
                _obj_smhr_EMP_TDS.MODE = 4;
                _obj_smhr_EMP_TDS.TDS_PERIOD = Convert.ToInt32(rcmb_Period.SelectedValue);
                _obj_smhr_EMP_TDS.TDS_BUID = Convert.ToInt32(rcb_BussinessUnit.SelectedItem.Value);
                bool status1 = BLL.set_EMP_TDS1(_obj_smhr_EMP_TDS);

                //_obj_Payitems = new SMHR_PAYITEMS();
                //_obj_Payitems.OPERATION = operation.Select;
                //_obj_Payitems.PAYITEM_ID = Convert.ToInt32(rcmb_Period.SelectedValue);
                //DataTable dt = BLL.get_PayItems(_obj_Payitems);

                Label lbl_ID = new Label();
                TextBox txt_Val = new TextBox();
                TextBox txt_tds_val = new TextBox();
                CheckBox chk_box = new CheckBox();
                for (int i = 0; i < RG_PayElements.Items.Count; i++)
                {
                    chk_box = RG_PayElements.Items[i].FindControl("chk_Select") as CheckBox;
                    if (chk_box.Checked)
                    {
                        lbl_ID = RG_PayElements.Items[i].FindControl("lbl_EmpID") as Label;
                        txt_Val = RG_PayElements.Items[i].FindControl("txt_Value") as TextBox;
                        txt_tds_val = RG_PayElements.Items[i].FindControl("txt_tds_Value") as TextBox;
                        _obj_smhr_EMP_TDS = new SMHR_EMP_TDS();
                        _obj_smhr_EMP_TDS.MODE = 3;
                        _obj_smhr_EMP_TDS.TDS_CHECKED = true;
                        _obj_smhr_EMP_TDS.TDS_EMPID = Convert.ToInt32(lbl_ID.Text);
                        _obj_smhr_EMP_TDS.TDS_BUID = Convert.ToInt32(rcb_BussinessUnit.SelectedItem.Value);
                        _obj_smhr_EMP_TDS.TDS_PERIOD = Convert.ToInt32(rcmb_Period.SelectedValue);
                        //_obj_smhr_EMP_TDS.SMHR_EMP_PAYITEMS_CALMODE = Convert.ToString(dt.Rows[0]["PAYITEM_CALMODE"]);
                        if (txt_Val.Text != "")
                            _obj_smhr_EMP_TDS.PREV_GROSS_AMOUNT = Convert.ToDouble(txt_Val.Text);
                        else
                            _obj_smhr_EMP_TDS.PREV_GROSS_AMOUNT = 0.0;
                        if (txt_tds_val.Text != "")
                            _obj_smhr_EMP_TDS.PREV_TDS_AMOUNT = Convert.ToDouble(txt_tds_val.Text);
                        else
                            _obj_smhr_EMP_TDS.PREV_TDS_AMOUNT = 0.0;
                        _obj_smhr_EMP_TDS.TDS_ORGID = Convert.ToInt32(Session["ORG_ID"]);
                        //_obj_smhr_EMP_TDS.SMHR_EMP_PAYITEMS_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                        //_obj_smhr_EMP_TDS.SMHR_EMP_PAYITEMS_CREATEDDATE = DateTime.Now;
                        bool status = BLL.set_EMP_TDS1(_obj_smhr_EMP_TDS);
                    }
                }
                BLL.ShowMessage(this, "TDS & Gross Values Saved for the Selected Employees");
                clearFields();
            }
            else
            {
                BLL.ShowMessage(this, "Please Select atleast one employee or Enter Values for Selected Employee");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emppastinfo", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

    }
    protected void rcmb_Period_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Period.SelectedIndex != 0)
            {
                _obj_smhr_EMP_TDS = new SMHR_EMP_TDS();
                _obj_smhr_EMP_TDS.MODE = 2;
                _obj_smhr_EMP_TDS.TDS_BUID = Convert.ToInt32(rcb_BussinessUnit.SelectedValue);
                _obj_smhr_EMP_TDS.TDS_PERIOD = Convert.ToInt32(rcmb_Period.SelectedValue);
                DataTable dtDetails = BLL.get_EMP_TDS_DETAILS(_obj_smhr_EMP_TDS);
                RG_PayElements.DataSource = dtDetails;
                RG_PayElements.DataBind();
                RG_PayElements.Visible = true;
                CheckBox chk = new CheckBox();
                TextBox txt_Box = new TextBox();
                for (int i = 0; i < dtDetails.Rows.Count; i++)
                {
                    chk = RG_PayElements.Items[i].FindControl("chk_Select") as CheckBox;
                    txt_Box = RG_PayElements.Items[i].FindControl("txt_Value") as TextBox;
                    if (txt_Box.Text != "")
                    {
                        if (Convert.ToString(dtDetails.Rows[i]["EMP_TDS_CHECKED"]) == "0")
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
            else
            {
                RG_PayElements.DataSource = null;
                RG_PayElements.DataBind();
                RG_PayElements.Visible = false;

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emppastinfo", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emppastinfo", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
}
