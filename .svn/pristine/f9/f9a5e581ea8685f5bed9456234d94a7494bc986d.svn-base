using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Data;
using Telerik.Web.UI;

public partial class Payroll_frm_OTDetails : System.Web.UI.Page
{
    SMHR_BUSINESSUNIT _obj_smhr_businessunit;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
            if (!Page.IsPostBack)
            {
                BLL.ChangeDateFormat(Convert.ToString(Session["EMP_ID"]), rdtp_OTDetOTDate);
                BLL.gridDateFormat(Convert.ToString(Session["EMP_ID"]), Rg_OTDet, "EMPOTTRANS_DATE");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_OTDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            loadDropdown();
            clearControls();
            DataTable dt = BLL.get_EmpOTTrans(new SMHR_EMPOTTRANS(Convert.ToInt32(Convert.ToString(e.CommandArgument))));

            lbl_OTDetID.Text = Convert.ToString(e.CommandArgument);
            rcmb_BusinessUnit.SelectedIndex = rcmb_BusinessUnit.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["BUSINESSUNIT_ID"]));
            rcmb_BusinessUnit_SelectedIndexChanged(null, null);
            if (Request.QueryString["BUSINESSUNIT_ID"] != null)
            {
                rcmb_BusinessUnit.Enabled = false;
            }
            SMHR_LEAVEAPP _obj_Smhr_LeaveApp = new SMHR_LEAVEAPP();
            _obj_Smhr_LeaveApp.BUSINESSUNIT_ID = Convert.ToInt32(Convert.ToString(dt.Rows[0]["BUSINESSUNIT_ID"]));
            _obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID = Convert.ToInt32(Convert.ToString(dt.Rows[0]["EMPOTTRANS_EMPID"]));
            _obj_Smhr_LeaveApp.MODE = 3;
            DataTable dtemp = BLL.get_EmpLeaveDetails(_obj_Smhr_LeaveApp);
            rcmb_OTDetEmployeeID.DataSource = dtemp;
            //lbl_Curr.Text = Convert.ToString(dtemp.Rows[0]["CURRENCY"]);
            rcmb_OTDetEmployeeID.DataTextField = "EMPNAME";
            rcmb_OTDetEmployeeID.DataValueField = "EMP_ID";
            rcmb_OTDetEmployeeID.DataBind();
            rcmb_OTDetEmployeeID.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
            rcmb_OTDetEmployeeID.SelectedIndex = rcmb_OTDetEmployeeID.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["EMPOTTRANS_EMPID"]));
            rcmb_OTDetEmployeeID_SelectedIndexChanged(null, null);
            LoadOTandPeriod();
            rcmb_OTDetOTType.SelectedIndex = rcmb_OTDetOTType.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["EMPOTTRANS_TYPEID"]));
            rcmb_OTDetPeriodMain.SelectedIndex = rcmb_OTDetPeriodMain.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["PERIODMAIN"]));
            rcmb_OTDetPeriodMain_SelectedIndexChanged(null, null);
            rcmb_OTDetPeriodDetails.SelectedIndex = rcmb_OTDetPeriodDetails.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["EMPOTTRANS_PERIOD_ID"]));
            rdtp_OTDetOTDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["EMPOTTRANS_DATE"]);
            rtxt_OTDetOTHours.Text = Convert.ToString(dt.Rows[0]["EMPOTTRANS_HOURS"]);

            if (Convert.ToString(dt.Rows[0]["EMPOTTRANS_STATUS"]) == "0")
                btn_Update.Visible = true;
            else
                BLL.ShowMessage(this, "This Record cannot be editing as it is already " + (Convert.ToString(dt.Rows[0]["EMPOTTRANS_STATUS"]) == "1" ? "Approved" : "Rejected"));

            Rm_OT_page.SelectedIndex = 1;
            rcmb_BusinessUnit.Enabled = false;
            rcmb_OTDetEmployeeID.Enabled = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_OTDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            loadDropdown();
            clearControls();
            btn_Save.Visible = true;
            Rm_OT_page.SelectedIndex = 1;

            rcmb_BusinessUnit.Enabled = true;
            rcmb_OTDetEmployeeID.Enabled = true;
            if (Request.QueryString["EMPID"] != null)
            {
                rcmb_OTDetEmployeeID.SelectedIndex = rcmb_OTDetEmployeeID.FindItemIndexByValue(Convert.ToString(Request.QueryString["EMPID"]));
                rcmb_OTDetEmployeeID_SelectedIndexChanged(null, null);
                rcmb_OTDetEmployeeID.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_OTDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void loadDropdown()
    {
        try
        {
            //Business Unit
            rcmb_BusinessUnit.Items.Clear();
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            rcmb_BusinessUnit.DataSource = dt_BUDetails;
            rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BusinessUnit.DataBind();
            rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));


            rcmb_OTDetOTType.Items.Clear();
            rcmb_OTDetOTType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

            rcmb_OTDetPeriodMain.Items.Clear();
            rcmb_OTDetPeriodMain.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

            rcmb_OTDetPeriodDetails.Items.Clear();
            rcmb_OTDetPeriodDetails.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_OTDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void LoadGrid()
    {
        try
        {
            DataTable dt = new DataTable();

            dt = BLL.get_EmpOTTrans(new SMHR_EMPOTTRANS());
            //if (Request.QueryString["EMPID"] != null && !string.IsNullOrEmpty(Request.QueryString["EMPID"]))
            if (Convert.ToString(Session["SELFSERVICE"]) == "true")
            {
                dt.DefaultView.RowFilter = " EMP_ID='" + Convert.ToString(Session["EMP_ID"]) + "'";
                dt = dt.DefaultView.ToTable();
            }

            Rg_OTDet.DataSource = dt;
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_OTDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (rdtp_OTDetOTDate.SelectedDate <= Convert.ToDateTime(lbl_EmpJoinDate.Text))
            {
                BLL.ShowMessage(this, " OT Date cannot be Less than of Join Date");
                rdtp_OTDetOTDate.Focus();
                return;
            }
            else
            {
                SMHR_EMPOTTRANS _obj_Smhr_EmpOTTrans = new SMHR_EMPOTTRANS();

                _obj_Smhr_EmpOTTrans.EMPOTTRANS_EMPID = Convert.ToInt32(rcmb_OTDetEmployeeID.SelectedItem.Value);
                _obj_Smhr_EmpOTTrans.EMPOTTRANS_TYPEID = Convert.ToInt32(rcmb_OTDetOTType.SelectedItem.Value);
                _obj_Smhr_EmpOTTrans.EMPOTTRANS_PERIOD_ID = Convert.ToInt32(rcmb_OTDetPeriodDetails.SelectedItem.Value);
                _obj_Smhr_EmpOTTrans.EMPOTTRANS_DATE = Convert.ToDateTime(rdtp_OTDetOTDate.SelectedDate);
                _obj_Smhr_EmpOTTrans.EMPOTTRANS_HOURS = Convert.ToInt32(rtxt_OTDetOTHours.Text);

                switch (((Button)sender).ID.ToUpper())
                {
                    case "BTN_UPDATE":
                        _obj_Smhr_EmpOTTrans.EMPOTTRANS_ID = Convert.ToInt32(lbl_OTDetID.Text);
                        _obj_Smhr_EmpOTTrans.OPERATION = operation.Update;
                        if (BLL.set_EmpOTTrans(_obj_Smhr_EmpOTTrans))
                            BLL.ShowMessage(this, "Information Saved Successfully");
                        else
                            BLL.ShowMessage(this, "Information Not Saved");
                        break;
                    case "BTN_SAVE":
                        _obj_Smhr_EmpOTTrans.OPERATION = operation.Insert;
                        if (BLL.set_EmpOTTrans(_obj_Smhr_EmpOTTrans))
                            BLL.ShowMessage(this, "Information Saved Successfully");
                        else
                            BLL.ShowMessage(this, "Information Not Saved");
                        break;
                    default:
                        break;
                }
                Rm_OT_page.SelectedIndex = 0;
                LoadGrid();
                Rg_OTDet.DataBind();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_OTDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void clearControls()
    {
        try
        {
            lbl_OTDetID.Text = string.Empty;
            rcmb_OTDetEmployeeID.SelectedIndex = -1;
            rcmb_OTDetOTType.SelectedIndex = -1;
            rcmb_OTDetPeriodMain.SelectedIndex = -1;
            rcmb_OTDetPeriodDetails.SelectedIndex = -1;
            rdtp_OTDetOTDate.SelectedDate = null;
            rtxt_OTDetOTHours.Text = string.Empty;

            btn_Save.Visible = false;
            btn_Update.Visible = false;
            Rm_OT_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_OTDetails", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_OTDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Rg_OTDet_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_OTDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_OTDetEmployeeID_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            LoadOTandPeriod();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_OTDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void rcmb_OTDetPeriodMain_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_OTDetPeriodMain.SelectedItem.Text.ToUpper() != "SELECT")
            {
                SMHR_EMPOTTRANS _obj_Smhr_EmpOTTrans = new SMHR_EMPOTTRANS();
                _obj_Smhr_EmpOTTrans.OPERATION = operation.Update;
                _obj_Smhr_EmpOTTrans.EMPOTTRANS_PERIOD_ID = Convert.ToInt32(rcmb_OTDetPeriodMain.SelectedItem.Value);

                rcmb_OTDetPeriodDetails.Items.Clear();
                rcmb_OTDetPeriodDetails.DataSource = BLL.get_EmpOTTrans(_obj_Smhr_EmpOTTrans);
                rcmb_OTDetPeriodDetails.DataTextField = "PRDDTL_NAME";
                rcmb_OTDetPeriodDetails.DataValueField = "PRDDTL_ID";
                rcmb_OTDetPeriodDetails.DataBind();
                rcmb_OTDetPeriodDetails.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
            }
            else
            {
                rcmb_OTDetPeriodDetails.Items.Clear();
                rcmb_OTDetPeriodDetails.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_OTDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_BusinessUnit_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            LoadEmployee();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_OTDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rdtp_OTDetOTDate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {


    }

    protected void LoadEmployee()
    {
        try
        {
            if (rcmb_BusinessUnit.SelectedItem.Text.ToUpper() != "SELECT")
            {
                SMHR_EMPOTTRANS _obj_Smhr_EmpOTTrans = new SMHR_EMPOTTRANS();
                _obj_Smhr_EmpOTTrans.BUID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);

                rcmb_OTDetEmployeeID.Items.Clear();
                rcmb_OTDetEmployeeID.DataSource = BLL.getValues_EmpOTTrans(_obj_Smhr_EmpOTTrans);
                rcmb_OTDetEmployeeID.DataTextField = "EMPNAME";
                rcmb_OTDetEmployeeID.DataValueField = "EMP_ID";
                rcmb_OTDetEmployeeID.DataBind();
                rcmb_OTDetEmployeeID.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_OTDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void LoadOTandPeriod()
    {
        try
        {
            if (rcmb_OTDetEmployeeID.SelectedItem.Text.ToUpper() != "SELECT")
            {
                SMHR_EMPOTTRANS _obj_Smhr_EmpOTTrans = new SMHR_EMPOTTRANS();
                _obj_Smhr_EmpOTTrans.OPERATION = operation.Insert;
                _obj_Smhr_EmpOTTrans.EMPOTTRANS_EMPID = Convert.ToInt32(rcmb_OTDetEmployeeID.SelectedItem.Value);


                rcmb_OTDetOTType.Items.Clear();
                rcmb_OTDetOTType.DataSource = BLL.get_EmpOTTrans(_obj_Smhr_EmpOTTrans);
                rcmb_OTDetOTType.DataTextField = "OT";
                rcmb_OTDetOTType.DataValueField = "OT_ID";
                rcmb_OTDetOTType.DataBind();
                rcmb_OTDetOTType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));


                rcmb_OTDetPeriodMain.Items.Clear();
                _obj_Smhr_EmpOTTrans.OPERATION = operation.Check;
                rcmb_OTDetPeriodMain.DataSource = BLL.get_EmpOTTrans(_obj_Smhr_EmpOTTrans);
                rcmb_OTDetPeriodMain.DataTextField = "PERIOD_NAME";
                rcmb_OTDetPeriodMain.DataValueField = "PERIOD_ID";
                rcmb_OTDetPeriodMain.DataBind();
                rcmb_OTDetPeriodMain.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));


                _obj_Smhr_EmpOTTrans = new SMHR_EMPOTTRANS();
                _obj_Smhr_EmpOTTrans.OPERATION = operation.Check;
                //_obj_Smhr_EmpOTTrans.BUID = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
                _obj_Smhr_EmpOTTrans.EMPOTTRANS_EMPID = Convert.ToInt32(rcmb_OTDetEmployeeID.SelectedValue);
                DataTable dtdoj = BLL.getValues_EmpOTTrans(_obj_Smhr_EmpOTTrans);
                lbl_EmpJoinDate.Text = Convert.ToString(dtdoj.Rows[0]["EMP_DOJ"]);
            }
            else
            {
                rcmb_OTDetOTType.Items.Clear();
                rcmb_OTDetOTType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

                rcmb_OTDetPeriodMain.Items.Clear();
                rcmb_OTDetPeriodMain.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_OTDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_OTDetPeriodDetails_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            SMHR_PERIODDTL _obj_Smhr_Prddtl = new SMHR_PERIODDTL();
            _obj_Smhr_Prddtl.OPERATION = operation.Select;
            _obj_Smhr_Prddtl.PRDDTL_ID = Convert.ToInt32(rcmb_OTDetPeriodDetails.SelectedValue);
            DataTable dt_Period = BLL.get_PeriodDetails(_obj_Smhr_Prddtl);
            if (dt_Period.Rows.Count == 1)
            {
                rdtp_OTDetOTDate.MinDate = Convert.ToDateTime(dt_Period.Rows[0]["PRDDTL_STARTDATE"]);
                rdtp_OTDetOTDate.MaxDate = Convert.ToDateTime(dt_Period.Rows[0]["PRDDTL_ENDDATE"]);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_OTDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
