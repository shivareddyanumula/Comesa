using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using Telerik.Web.UI;
using System.Threading;
using System.Globalization;

public partial class EmpTransDetails : System.Web.UI.Page
{
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_EMPLOYEE _obj_smhr_employee = new SMHR_EMPLOYEE();
    SMHR_PERIODDTL _obj_Smhr_Prddtl;
    DataTable dt_ds = new DataTable();
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Employee Bank Transaction Details");//COUNTRY");
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
                    rg_Attendence.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Save.Visible = false;
                    // btn_Update.Visible = false;
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
                    return;
                }
                loadDropdown();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmpTransDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void loadDropdown()
    {
        try
        {
            rcmb_AttBusinessUnit.Items.Clear();
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            rcmb_AttBusinessUnit.DataSource = dt_BUDetails;
            rcmb_AttBusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_AttBusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            rcmb_AttBusinessUnit.DataBind();
            rcmb_AttBusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

            SMHR_PERIOD _obj_smhr_period = new SMHR_PERIOD();
            DataTable dt_Details = new DataTable();
            _obj_smhr_period.OPERATION = operation.Select;
            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_PeriodHeaderDetails(_obj_smhr_period);
            rcmb_AttPeriod.DataSource = dt_Details;
            rcmb_AttPeriod.DataValueField = "PERIOD_ID";
            rcmb_AttPeriod.DataTextField = "PERIOD_NAME";
            rcmb_AttPeriod.DataBind();
            rcmb_AttPeriod.Items.Insert(0, new RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmpTransDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            bool selected = false;
            int records_saved = 0;
            SMHR_EMPLOYEETRANSACTION obj = new SMHR_EMPLOYEETRANSACTION();
            obj.EMPBNKTRN_BU_ID = Convert.ToInt32(rcmb_AttPeriod.SelectedItem.Value);
            obj.EMPBNKTRN_PRDDTL_ID = Convert.ToInt32(rcmb_AttPeriodElement.SelectedItem.Value);
            obj.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            obj.CREATEDDATE = DateTime.Now;
            obj.EMPBNKTRN_ORG_ID = Convert.ToInt32(Session["org_id"]);
            obj.EMPBNKTRN_PERIOD_ID = Convert.ToInt32(rcmb_AttPeriod.SelectedItem.Value);
            obj.EMPBNKTRN_TRAN_STATUS = Convert.ToInt32(rcmb_AttPeriod.SelectedItem.Value);

            for (int k = 0; k < rg_Attendence.Items.Count; k++)
            {
                CheckBox chk = rg_Attendence.Items[k].FindControl("chckbtn_Select") as CheckBox;
                if (chk.Checked)
                {
                    selected = true;
                    //Label lbl_emp_id = rg_Attendence.Items[k].FindControl("EMP_ID") as Label;
                    Label lbl_emp_id = rg_Attendence.Items[k].FindControl("lbl_Empid") as Label;
                    Label lbl_bank_id = rg_Attendence.Items[k].FindControl("lbl_Bankid") as Label;
                    RadNumericTextBox rnt = new Telerik.Web.UI.RadNumericTextBox();
                    rnt = rg_Attendence.Items[k].FindControl("RadNumericTextBox1") as RadNumericTextBox;
                    obj.EMPBNKTRN_AMOUNT = Convert.ToDouble(rnt.Value);
                    obj.EMPBNKTRN_BANK_DTLS_ID = Convert.ToInt32(lbl_bank_id.Text);
                    obj.EMPBNKTRN_EMP_ID = Convert.ToInt32(lbl_emp_id.Text);
                    obj.OPERATION = operation.Check;
                    //if (Convert.ToString(BLL.check_EmpTrans(obj).Rows[0]["Count"]) != "0")
                    DataTable dt_Exist = BLL.check_EmpTrans(obj);
                    if (dt_Exist.Rows[0][0].ToString() != "0")
                    {
                        BLL.ShowMessage(this, "Employee with this combination Already Exists");
                        return;
                    }
                    obj.OPERATION = operation.Insert;
                    if (BLL.set_EmpTrans(obj))
                        records_saved += 1;
                    //multiple times same message will be displayed
                    //    BLL.ShowMessage(this, "Information Saved Successfully");
                    //else
                    //    BLL.ShowMessage(this, "Information Not Saved");

                }


            }
            if (!selected)
            {
                BLL.ShowMessage(this, "Select Atleast One Employee");
                return;
            }
            else
            {
                BLL.ShowMessage(this, "Total Records Saved Are:" + records_saved);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmpTransDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }


    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            //rcmb_AttPeriod.SelectedIndex = -1;
            //rcmb_AttBusinessUnit.SelectedIndex = -1;
            //rcmb_AttPeriodElement.SelectedIndex = -1;
            rcmb_AttBusinessUnit.ClearSelection();
            rcmb_AttPeriod.ClearSelection();
            rcmb_AttPeriodElement.Items.Clear();
            rcmb_AttPeriodElement.Items.Insert(0, new RadComboBoxItem("", ""));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmpTransDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void rcmb_AttPeriod_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {

            if (rcmb_AttPeriod.SelectedIndex > 0)
            {
                rcmb_AttPeriodElement.Items.Clear();
                SMHR_PAYROLL _obj_smhr_payroll; _obj_smhr_payroll = new SMHR_PAYROLL();
                _obj_smhr_payroll.PERIODDTLID = Convert.ToInt32(rcmb_AttPeriod.SelectedValue);
                _obj_smhr_payroll.MODE = 28;
                DataTable dt_Details = BLL.get_payrolltrans(_obj_smhr_payroll);
                if (dt_Details.Rows.Count != 0)
                {
                    rcmb_AttPeriodElement.DataSource = dt_Details;
                    rcmb_AttPeriodElement.DataValueField = "PRDDTL_ID";
                    rcmb_AttPeriodElement.DataTextField = "PRDDTL_NAME";
                    rcmb_AttPeriodElement.DataBind();
                    rcmb_AttPeriodElement.Items.Insert(0, new RadComboBoxItem("Select"));
                    tblr_AttPeriodElement.Visible = true;

                }
                else
                {


                }
            }
            else
            {
                BLL.ShowMessage(this, "Select Period!");
                rcmb_AttPeriodElement.Items.Clear();
                rcmb_AttPeriodElement.Items.Insert(0, new RadComboBoxItem("", ""));
                rg_Attendence.DataSource = null;
                rg_Attendence.DataBind();
                rg_Attendence.Visible = false;
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmpTransDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void rcmb_AttPeriodElement_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_AttPeriodElement.SelectedIndex > 0)
            {
                SMHR_EMPLOYEETRANSACTION _obj_smhr_emptrans = new SMHR_EMPLOYEETRANSACTION();
                _obj_smhr_emptrans.EMPBNKTRN_BU_ID = Convert.ToInt32(rcmb_AttBusinessUnit.SelectedValue);
                _obj_smhr_emptrans.OPERATION = operation.Select;
                DataTable dt_Details = BLL.get_EmpTrans(_obj_smhr_emptrans);
                if (dt_Details.Rows.Count != 0)
                {
                    rg_Attendence.DataSource = dt_Details;
                    rg_Attendence.DataBind();
                    rg_Attendence.Visible = true;
                }
                else
                {
                    BLL.ShowMessage(this, "No Records to Display");
                    rg_Attendence.DataSource = dt_Details;
                    rg_Attendence.DataBind();
                    rg_Attendence.Visible = true;
                }
            }
            else
            {
                BLL.ShowMessage(this, "Select Period Element!");
                rg_Attendence.DataSource = null;
                rg_Attendence.DataBind();
                rg_Attendence.Visible = false;
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmpTransDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

    }

    protected void chk_selectall_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            //for (int i = 0; i < rg_Attendence.Items.Count; i++)
            //{
            CheckBox Chk_All = (CheckBox)sender;
            if (Chk_All.Checked)
            {
                for (int index = 0; index < rg_Attendence.Items.Count; index++)
                {
                    CheckBox c = (CheckBox)rg_Attendence.Items[index].FindControl("chckbtn_Select");
                    c.Checked = true; ;
                }
            }
            else
            {
                for (int index = 0; index < rg_Attendence.Items.Count; index++)
                {
                    CheckBox c = (CheckBox)rg_Attendence.Items[index].FindControl("chckbtn_Select");
                    c.Checked = false;
                }
            }
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmpTransDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void rcmb_AttBusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rcmb_AttPeriod.ClearSelection();
            rcmb_AttPeriodElement.Items.Clear();
            rcmb_AttPeriodElement.Items.Insert(0, new RadComboBoxItem("", ""));
            rg_Attendence.DataSource = null;
            rg_Attendence.DataBind();
            rg_Attendence.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmpTransDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
}
