using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Data;
using Telerik.Web.UI;
using System.Text;
using System.Collections;

public partial class Payroll_frm_leaveopeningbalances : System.Web.UI.Page
{
    SMHR_BUSINESSUNIT _obj_smhr_businessunit;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    StringBuilder strQry = new StringBuilder();
    SMHR_PERIOD _obj_smhr_period;
    SMHR_LEAVESTRUCT _obj_smhr_leaveStruct;

    static int bu = 0;
    static int period = 0;
    static int leaveStruct = 0;

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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("LEAVE OPENING BALANCES");
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
                    Rg_Details.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    //btn_Save.Visible = false;
                    Rg_Details.Enabled = false;
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
                loadLeaveStruct();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leaveopeningbalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }
    private void getData()
    {
        try
        {
            DataTable dt;
            if (ViewState["DataTable"] == null)
            {
                dt = BLL.get_EmpLOB(Convert.ToInt32(Session["ORG_ID"]), Convert.ToInt32(rcmb_BUID.SelectedItem.Value), Convert.ToInt32(rcmb_Period.SelectedItem.Value), Convert.ToInt32(rcmbLeaveStruct.SelectedValue));
                ViewState["DataTable"] = dt;
            }
            else
            {
                if (rcmbLeaveStruct.SelectedItem.Value == "")
                {
                    dt = ViewState["DataTable"] as DataTable;
                }
                else
                {
                    if ((bu == Convert.ToInt32(rcmb_BUID.SelectedItem.Value)) && (period == Convert.ToInt32(rcmb_Period.SelectedItem.Value)) && (leaveStruct == Convert.ToInt32(rcmbLeaveStruct.SelectedItem.Value)))
                    {
                        dt = ViewState["DataTable"] as DataTable;
                    }
                    else
                    {
                        dt = BLL.get_EmpLOB(Convert.ToInt32(Session["ORG_ID"]), Convert.ToInt32(rcmb_BUID.SelectedItem.Value), Convert.ToInt32(rcmb_Period.SelectedItem.Value), Convert.ToInt32(rcmbLeaveStruct.SelectedValue));
                        ViewState["DataTable"] = dt;
                        bu = Convert.ToInt32(rcmb_BUID.SelectedItem.Value);
                        period = Convert.ToInt32(rcmb_Period.SelectedItem.Value);
                        leaveStruct = Convert.ToInt32(rcmbLeaveStruct.SelectedItem.Value);
                    }
                }
            }
            Rg_Details.DataSource = dt;

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leaveopeningbalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    private void LoadCombos()
    {
        try
        {
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);

            rcmb_BUID.DataSource = dt_BUDetails;
            rcmb_BUID.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BUID.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BUID.DataBind();
            rcmb_BUID.Items.Insert(0, new RadComboBoxItem("Select", "0"));

            _obj_smhr_period = new SMHR_PERIOD();
            DataTable dt_Details = new DataTable();
            _obj_smhr_period.OPERATION = operation.Select;
            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_PeriodHeaderDetails_Calendar(_obj_smhr_period);
            rcmb_Period.DataSource = dt_Details;
            rcmb_Period.DataValueField = "PERIOD_ID";
            rcmb_Period.DataTextField = "PERIOD_NAME";
            rcmb_Period.DataBind();
            rcmb_Period.Items.Insert(0, new RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leaveopeningbalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void LoadEmployees()
    {
        try
        {
            SMHR_EMPLOYEE _obj_smhr_employee = new SMHR_EMPLOYEE();

            _obj_smhr_employee.OPERATION = operation.Select;
            _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_employee.EMP_LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dtEmp = BLL.get_Employee(_obj_smhr_employee);

            rcbEmp.DataSource = dtEmp;
            rcbEmp.DataTextField = "EMP_NAME";
            rcbEmp.DataValueField = "EMP_ID";
            rcbEmp.DataBind();
            rcbEmp.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leaveopeningbalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    private void LoadPeriods()
    {
        try
        {
            _obj_smhr_period = new SMHR_PERIOD();
            DataTable dt_Details = new DataTable();
            _obj_smhr_period.OPERATION = operation.Select;
            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_PeriodHeaderDetails_Calendar(_obj_smhr_period);
            rcmb_Period.DataSource = dt_Details;
            rcmb_Period.DataValueField = "PERIOD_ID";
            rcmb_Period.DataTextField = "PERIOD_NAME";
            rcmb_Period.DataBind();
            rcmb_Period.Items.Insert(0, new RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leaveopeningbalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    private DataTable GridSource()
    {
        DataTable dt = (DataTable)ViewState["DataTable"];
        try
        {
            if (dt != null)
            {
                return (DataTable)dt;
            }

            dt = BLL.get_EmpLOB(Convert.ToInt32(Session["ORG_ID"]), Convert.ToInt32(rcmb_BUID.SelectedItem.Value), Convert.ToInt32(rcmb_Period.SelectedItem.Value), Convert.ToInt32(rcmbLeaveStruct.SelectedItem.Value));
            ViewState["DataTable"] = dt;
            Rg_Details.DataSource = dt;

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leaveopeningbalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return dt;
    }
    private string InsertGridDetails(StringBuilder strQry)
    {
        try
        {
            SMHR_LOB _obj_smhr_lob = new SMHR_LOB();
            _obj_smhr_lob.OPERATION = operation.Delete;


            foreach (GridDataItem item in this.Rg_Details.MasterTableView.Items)
            {
                _obj_smhr_lob.LOB_EMPID = Convert.ToInt32(item.Cells[2].Text);
                for (int j = 0; j < Rg_Details.Columns.Count - 5; j++)
                {
                    strQry.Append("EXEC USP_SMHR_LEAVEOPENINGBALANCES ");
                    _obj_smhr_lob.LOB_EMPID = Convert.ToInt32(item.Cells[2].Text);
                    string LT = Convert.ToString(Rg_Details.MasterTableView.Columns[j + 4].UniqueName);
                    string[] T = LT.Split(new char[] { '-' });
                    _obj_smhr_lob.LOB_LEAVETYPEID = Convert.ToInt32(T[0]);
                    _obj_smhr_lob.LOB_NOOFDAYS = Convert.ToInt32(item[LT].Text);
                    _obj_smhr_lob.LOB_FINALISE = 0;
                    _obj_smhr_lob.LOB_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_lob.LOB_CREATEDDATE = System.DateTime.Now;
                    _obj_smhr_lob.LOB_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_lob.LOB_LASTMDFDATE = System.DateTime.Now;
                    _obj_smhr_lob.OPERATION = operation.Insert;
                    string str = "@Operation = 'Insert'" +
                                 ",@LOB_EMPID = '" + _obj_smhr_lob.LOB_EMPID + "'" +
                                 ",@LOB_LEAVETYPEID = '" + _obj_smhr_lob.LOB_LEAVETYPEID + "'" +
                                 ",@LOB_NOOFDAYS = '" + _obj_smhr_lob.LOB_NOOFDAYS + "'" +
                                 ",@LOB_FINALISE = '" + _obj_smhr_lob.LOB_FINALISE + "'" +
                                 ",@LOB_CREATEDBY = '" + _obj_smhr_lob.LOB_CREATEDBY + "'" +
                                 ",@LOB_CREATEDDATE = '" + _obj_smhr_lob.LOB_CREATEDDATE + "'" +
                                 ",@LOB_LASTMDFBY = '" + _obj_smhr_lob.LOB_LASTMDFBY + "'" +
                                 ",@LOB_LASTMDFDATE = '" + _obj_smhr_lob.LOB_LASTMDFDATE + "'";
                    strQry.Append(str);

                }

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leaveopeningbalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return Convert.ToString(strQry);

    }
    public void loadLeaveStruct()
    {
        try
        {
            _obj_smhr_leaveStruct = new SMHR_LEAVESTRUCT();
            _obj_smhr_leaveStruct.OPERATION = operation.Select;
            _obj_smhr_leaveStruct.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtLeaveStruct = BLL.get_LeaveStructHeaderDetails(_obj_smhr_leaveStruct);
            if (dtLeaveStruct.Rows.Count > 0)
            {
                rcmbLeaveStruct.DataSource = dtLeaveStruct;
                rcmbLeaveStruct.DataTextField = "LEAVESTRUCT_CODE";
                rcmbLeaveStruct.DataValueField = "LEAVESTRUCT_ID";
                rcmbLeaveStruct.DataBind();
                rcmbLeaveStruct.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leaveopeningbalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Update_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_LOB _obj_smhr_lob = new SMHR_LOB();
            btn_Finalise.Enabled = true;
            StringBuilder strQry = new StringBuilder();

            for (int i = 0; i < Rg_Details.Items.Count; i++)
            {
                _obj_smhr_lob.LOB_EMPID = null;


                for (int j = 0; j < Rg_Details.MasterTableView.AutoGeneratedColumns.Count() - 4; j++)
                {
                    strQry.Append("EXEC USP_SMHR_LEAVEOPENINGBALANCES ");
                    _obj_smhr_lob.LT_EMPID = Convert.ToInt32(Rg_Details.Items[i]["EMP_ID"].Text);
                    string LT = Convert.ToString(Rg_Details.MasterTableView.AutoGeneratedColumns[j + 4].UniqueName);
                    string[] T = LT.Split(new char[] { '-' });
                    _obj_smhr_lob.LT_PERIOD = Convert.ToInt32(rcmb_Period.SelectedItem.Value);
                    _obj_smhr_lob.LT_LEAVETYPEID = Convert.ToInt32(T[0]);
                    _obj_smhr_lob.LT_CURRENTBALANCE = Convert.ToDouble(Rg_Details.Items[i][LT].Text);
                    _obj_smhr_lob.OPERATION = operation.Update;
                    string str = "@Operation = 'Update'" +
                                 ",@LT_EMPID = '" + _obj_smhr_lob.LT_EMPID + "'" +
                                 ",@LT_PERIOD='" + _obj_smhr_lob.LT_PERIOD + "'" +
                                 ",@LT_LEAVETYPEID = '" + _obj_smhr_lob.LT_LEAVETYPEID + "'" +
                                 ",@LT_CURRENTBALANCE='" + _obj_smhr_lob.LT_CURRENTBALANCE + "'";

                    strQry.Append(str);
                }

            }
            bool rs = BLL.set_EMpLOB(_obj_smhr_lob, strQry.ToString());
            if (rs == true)
                BLL.ShowMessage(this, "Leave Opening Balances updated Successfully");
            else
                BLL.ShowMessage(this, "Error found");

            getData();
            Rg_Details.DataBind();
            btn_Finalise.Visible = true;
            //btn_Save.Enabled = false;
            btn_Update.Enabled = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leaveopeningbalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    //protected void btn_Save_Click(object sender, EventArgs e)
    //{
    //    try
    //    {

    //        SMHR_LOB _obj_smhr_lob = new SMHR_LOB();
    //        btn_Finalise.Enabled = true;
    //        StringBuilder strQry = new StringBuilder();

    //        for (int i = 0; i < Rg_Details.Items.Count; i++)
    //        {
    //            _obj_smhr_lob.LOB_EMPID = null;

    //            for (int j = 0; j < Rg_Details.MasterTableView.AutoGeneratedColumns.Count() - 4; j++)
    //            {
    //                //strQry.Append("EXEC USP_SMHR_LEAVEOPENINGBALANCES ");
    //                _obj_smhr_lob.LT_EMPID = Convert.ToInt32(Rg_Details.Items[i]["EMP_ID"].Text);
    //                string LT = Convert.ToString(Rg_Details.MasterTableView.AutoGeneratedColumns[j + 4].UniqueName);
    //                string[] T = LT.Split(new char[] { '-' });
    //                _obj_smhr_lob.LT_PERIOD = Convert.ToInt32(rcmb_Period.SelectedItem.Value);
    //                _obj_smhr_lob.LT_LEAVETYPEID = Convert.ToInt32(T[0]);

    //                _obj_smhr_lob.OPERATION = operation.Check1;
    //                //  _obj_smhr_lob.OPERATION = operation.Check; 
    //                DataTable dt_Check1 = BLL.get_UpdateEmpLOB(_obj_smhr_lob);
    //                //if (dt_Check1.Rows.Count != 0)
    //                //{
    //                strQry.Append("EXEC USP_SMHR_LEAVEOPENINGBALANCES ");
    //                _obj_smhr_lob.LT_CURRENTBALANCE = Convert.ToDouble(Rg_Details.Items[i][LT].Text);
    //                _obj_smhr_lob.OPERATION = operation.Update;
    //                string str = "@Operation = 'Update'" +
    //                             ",@LT_EMPID = '" + _obj_smhr_lob.LT_EMPID + "'" +
    //                             ",@LT_PERIOD='" + _obj_smhr_lob.LT_PERIOD + "'" +
    //                             ",@LT_LEAVETYPEID = '" + _obj_smhr_lob.LT_LEAVETYPEID + "'" +
    //                             ",@LT_CURRENTBALANCE='" + _obj_smhr_lob.LT_CURRENTBALANCE + "'";

    //                strQry.Append(str);
    //                //bool rs = BLL.set_EMpLOB(_obj_smhr_lob, strQry.ToString());
    //                //if (rs == true)
    //                //    BLL.ShowMessage(this, "Leave Opening Balances updated Successfully");
    //                //else
    //                //    BLL.ShowMessage(this, "Error found");
    //                //getData();
    //                //Rg_Details.DataBind();
    //                //btn_Finalise.Visible = true;
    //                //btn_Save.Enabled = false;
    //                //btn_Update.Enabled = false;
    //                //}
    //                // commneted by aravinda
    //                //else
    //                //{
    //                //    _obj_smhr_lob.LT_LOB = 0;
    //                //    _obj_smhr_lob.LT_LEAVEENTITLED = Convert.ToInt32(Rg_Details.Items[i][LT].Text);
    //                //    _obj_smhr_lob.LT_CURRENTBALANCE = Convert.ToInt32(Rg_Details.Items[i][LT].Text);
    //                //    _obj_smhr_lob.OPERATION = operation.Insert;
    //                //    string str = "@Operation = 'Insert'" +
    //                //                 ",@LT_EMPID = '" + _obj_smhr_lob.LT_EMPID + "'" +
    //                //                 ",@LT_PERIOD='" + _obj_smhr_lob.LT_PERIOD + "'" +
    //                //                 ",@LT_LEAVETYPEID = '" + _obj_smhr_lob.LT_LEAVETYPEID + "'" +
    //                //                 ",@LT_LOB='" + _obj_smhr_lob.LT_LOB + "'" +
    //                //                 ",@LT_LEAVEENTITLED = '" + _obj_smhr_lob.LT_LEAVEENTITLED + "'" +
    //                //                 ",@LT_CURRENTBALANCE='" + _obj_smhr_lob.LT_CURRENTBALANCE + "'";
    //                //    strQry.Append(str);


    //                //}// commneted by aravinda till here
    //            }

    //        }
    //        _obj_smhr_lob.OPERATION = operation.Update;
    //        bool rs = BLL.set_EMpLOB(_obj_smhr_lob, strQry.ToString());
    //        if (rs == true)
    //            BLL.ShowMessage(this, "Leave Opening Balances Inserted Successfully");
    //        else
    //            BLL.ShowMessage(this, "Error found");

    //        getData();
    //        Rg_Details.DataBind();
    //        btn_Finalise.Visible = true;
    //        //btn_Save.Visible = false;
    //        //Rg_Details.Visible = false;
    //        //LoadCombos();
    //        //LoadPeriods();
    //        //loadLeaveStruct();
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leaveopeningbalances", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //        return;
    //    }
    //}
    protected void btn_Finalise_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_LOB _obj_smhr_lob = new SMHR_LOB();
            btn_Finalise.Enabled = true;

            for (int i = 0; i < Rg_Details.Items.Count; i++)
            {
                _obj_smhr_lob.LOB_EMPID = null;
                for (int j = 0; j < Rg_Details.MasterTableView.AutoGeneratedColumns.Count() - 4; j++)
                {
                    strQry.Append("EXEC USP_SMHR_LEAVEOPENINGBALANCES ");
                    _obj_smhr_lob.LOB_EMPID = Convert.ToInt32(Rg_Details.Items[i]["EMP_ID"].Text);
                    string LT = Convert.ToString(Rg_Details.MasterTableView.AutoGeneratedColumns[j + 4].UniqueName);
                    //string[] T = LT.Split(new char[] { '-' });
                    //TO GET LEAVE TYPE ID
                    _obj_smhr_lob.LT_LEAVECODE = Convert.ToString(LT);
                    _obj_smhr_lob.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_lob.OPERATION = operation.Empty1;
                    DataTable dt_id = BLL.get_UpdateEmpLOB(_obj_smhr_lob);
                    if (dt_id.Rows.Count > 0)
                    {
                        int ID = Convert.ToInt32(dt_id.Rows[0]["LEAVEMASTER_ID"]);
                        _obj_smhr_lob.LT_PERIOD = Convert.ToInt32(rcmb_Period.SelectedItem.Value);
                        //_obj_smhr_lob.LT_LEAVETYPEID = Convert.ToInt32(T[0]);
                        _obj_smhr_lob.LT_LEAVETYPEID = Convert.ToInt32(ID);
                        _obj_smhr_lob.LT_LOB = 0;
                        if ((Rg_Details.Items[i][LT].Text == "&nbsp;"))
                        {
                            _obj_smhr_lob.LT_LEAVEENTITLED = Convert.ToDouble(0.00);
                            _obj_smhr_lob.LT_CURRENTBALANCE = Convert.ToDouble(0.00);
                        }
                        else if (Rg_Details.Items[i][LT].Text == string.Empty)
                        {
                            _obj_smhr_lob.LT_LEAVEENTITLED = Convert.ToDouble(0.00);
                            _obj_smhr_lob.LT_CURRENTBALANCE = Convert.ToDouble(0.00);
                        }
                        else
                        {
                            _obj_smhr_lob.LT_LEAVEENTITLED = Convert.ToDouble(Rg_Details.Items[i][LT].Text);
                            _obj_smhr_lob.LT_CURRENTBALANCE = Convert.ToDouble(Rg_Details.Items[i][LT].Text);
                        }
                        _obj_smhr_lob.OPERATION = operation.Insert;
                        string str = "@Operation = 'UPDATE'" +
                                     ",@LT_EMPID = '" + _obj_smhr_lob.LOB_EMPID + "'" +
                                     ",@LT_PERIOD='" + _obj_smhr_lob.LT_PERIOD + "'" +
                            //",@LT_LEAVETYPEID = '" + _obj_smhr_lob.LT_LEAVETYPEID + "'" +
                            //",@LT_LOB='" + _obj_smhr_lob.LT_LOB + "'" +
                            //",@LT_LEAVEENTITLED = '" + _obj_smhr_lob.LT_LEAVEENTITLED + "'" +
                                     ",@LT_CURRENTBALANCE='" + _obj_smhr_lob.LT_CURRENTBALANCE + "'";
                        strQry.Append(str);
                    }
                }

            }
            bool rs = BLL.set_EMpLOB(_obj_smhr_lob, strQry.ToString());
            if (rs == true)
            {
                BLL.ShowMessage(this, "Leave Opening Balances finalised Successfully");
                //  btn_Finalise.Enabled = false;
                //Rg_Details.Enabled = false;
                btn_Finalise.Visible = false;
                Rg_Details.Visible = false;
                btn_Cancel.Visible = false;
                LoadCombos();
                LoadPeriods();
                loadLeaveStruct();
                ViewState["DataTable"] = null;
                return;
            }
            else
                BLL.ShowMessage(this, "Error found");
            return;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leaveopeningbalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void Rg_Details_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            if (rcmb_BUID.SelectedIndex > 0 && rcmb_Period.SelectedIndex > 0 && rcmbLeaveStruct.SelectedIndex > 0)
            {
                DataTable dt = BLL.get_EmpLOB(Convert.ToInt32(Session["ORG_ID"]), Convert.ToInt32(rcmb_BUID.SelectedItem.Value), Convert.ToInt32(rcmb_Period.SelectedItem.Value), Convert.ToInt32(rcmbLeaveStruct.SelectedValue));
                Rg_Details.DataSource = dt;
                //Rg_Details.DataBind();

                //getData();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leaveopeningbalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rg_Details_UpdateCommand(object source, GridCommandEventArgs e)
    {
        try
        {
            SMHR_LOB _obj_smhr_lob = new SMHR_LOB();
            GridEditableItem editedItem = e.Item as GridEditableItem;
            int index = editedItem.DataSetIndex;
            DataTable newTable = GridSource();
            Hashtable newValues = new Hashtable();
            string ID = e.Item.OwnerTableView.Items[index]["EMP_ID"].Text;
            DataRow[] ChangedRows = newTable.Select("EMP_ID = " + Convert.ToString(ID));
            e.Item.OwnerTableView.ExtractValuesFromItem(newValues, editedItem);
            ChangedRows[0].BeginEdit();
            foreach (DictionaryEntry entry in newValues)
            {
                if ((entry.Value == null) || Convert.ToString(entry.Value) == string.Empty)
                {
                    ChangedRows[0][(string)entry.Key] = 0.00;
                }
                else
                {
                    ChangedRows[0][(string)entry.Key] = entry.Value;
                }
            }
            ChangedRows[0].EndEdit();
            DataTable dt = (DataTable)ViewState["DataTable"];

            Rg_Details.DataSource = dt;
            //dt.PrimaryKey = new DataColumn[] { dt.Columns["EMP_ID"] };
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leaveopeningbalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void Rg_Details_ColumnCreated(object sender, GridColumnCreatedEventArgs e)
    {
        try
        {
            bool status;
            GridBoundColumn boundColumn = e.Column as GridBoundColumn;
            switch (e.Column.HeaderText)
            {
                //case "EMP_ID":
                case "EMPLOYEE ID":
                    {
                        e.Column.Visible = false;
                        boundColumn.ReadOnly = true;
                        break;
                    }
             //   case "EMP_EMPCODE":
                case "EMPLOYEE CODE":
                    {

                        boundColumn.ReadOnly = true;
                        break;
                    }
                case "EMPLOYEE NAME":
                    {

                        boundColumn.ReadOnly = true;
                        break;
                    }
                case "DATE OF JOIN":
                    {
                        e.Column.Visible = false;
                        boundColumn.ReadOnly = true;
                        break;

                    }
                default:
                    {
                        string strHeaderText = e.Column.HeaderText;
                        status = e.Column.IsEditable;

                    }
                    break;
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leaveopeningbalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void Rg_Details_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (!this.IsPostBack)
            {
                this.Rg_Details.EditIndexes.Add(1);
                this.Rg_Details.MasterTableView.Rebind();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leaveopeningbalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void Rg_Details_EditCommand(object source, GridCommandEventArgs e)
    {
        try
        {
            getData();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leaveopeningbalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void rcmb_BUID_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            LoadPeriods();
            loadLeaveStruct();
            Rg_Details.Visible = false;
            //if (!(rcmb_BUID.SelectedIndex > 0))
            //{
            //    Rg_Details.Visible = false;
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leaveopeningbalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void rcmb_Period_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Period.SelectedIndex > 0)
            {
                loadLeaveStruct();
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leaveopeningbalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void rcmbLeaveStruct_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_BUID.SelectedIndex > 0)
            {
                if (rcmb_Period.SelectedIndex > 0)
                {
                    if (period == 0)
                    {
                        period = Convert.ToInt32(rcmb_Period.SelectedItem.Value);
                    }
                    getData();

                    Rg_Details.DataBind();
                    Rg_Details.Visible = true;
                    btn_Finalise.Visible = true;
                    btn_Finalise.Enabled = true;
                    btn_Cancel.Visible = true;
                    //btn_Save.Visible = true;
                    //btn_Save.Enabled = true;
                    if (Rg_Details.Items.Count > 0)
                    {
                        btn_Finalise.Visible = true;
                        //btn_Save.Visible = true;
                    }
                    else
                    {
                        btn_Finalise.Visible = false;
                        //btn_Save.Visible = false;
                    }
                    btn_Update.Visible = false;
                    //btn_Finalise.Visible = false;
                }
                else
                {
                    //getData();
                    //Rg_Details.DataBind();
                    Rg_Details.Visible = false;
                    //btn_Save.Visible = false;
                    //BLL.ShowMessage(this, "Select Period ");
                }
            }
            else
                BLL.ShowMessage(this, "Select BusinessUnit");
            
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                Rg_Details.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                //btn_Save.Visible = false;
                Rg_Details.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leaveopeningbalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            ViewState["DataTable"] = null;
            Rg_Details.Visible = false;
            btn_Finalise.Visible = false;
            btn_Cancel.Visible = false;
            LoadCombos();
            LoadPeriods();
            loadLeaveStruct();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leaveopeningbalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            LoadEmployees();

            rcbEmp.SelectedIndex = rcbEmp.Items.FindItemIndexByValue(Convert.ToString(e.CommandArgument));
            rntbOpenBal.Text = Convert.ToString(e.CommandName);

            rmpLOB.SelectedIndex = 1;
            //pnlMain.Visible = false;
            //pnlControls.Visible = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leaveopeningbalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_LOB _obj_SMHR_LOB = new SMHR_LOB();

            _obj_SMHR_LOB.LT_EMPID = Convert.ToInt32(rcbEmp.SelectedValue);
            _obj_SMHR_LOB.LT_BAL = Convert.ToDouble(rntbOpenBal.Text);
            _obj_SMHR_LOB.LT_PERIOD = Convert.ToInt32(rcmb_Period.SelectedValue);
            //_obj_SMHR_LOB.LASTMDFBY = Convert.ToInt32(Session["EMP_ID"]);
            _obj_SMHR_LOB.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_SMHR_LOB.CREATEDDATE = DateTime.Now;
            _obj_SMHR_LOB.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_SMHR_LOB.LASTMDFDATE = DateTime.Now;


            bool status = BLL.setEmpLOB(_obj_SMHR_LOB);

            if (status == true)
                BLL.ShowMessage(this, "Leave Balances updated successfully");
            else
                BLL.ShowMessage(this, "Leave Balances not updated");

            DataTable dt = BLL.get_EmpLOB(Convert.ToInt32(Session["ORG_ID"]), Convert.ToInt32(rcmb_BUID.SelectedItem.Value), 
                                    Convert.ToInt32(rcmb_Period.SelectedItem.Value), Convert.ToInt32(rcmbLeaveStruct.SelectedValue));
            Rg_Details.DataSource = dt;
            Rg_Details.DataBind();

            rmpLOB.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leaveopeningbalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = BLL.get_EmpLOB(Convert.ToInt32(Session["ORG_ID"]), Convert.ToInt32(rcmb_BUID.SelectedItem.Value), 
                                        Convert.ToInt32(rcmb_Period.SelectedItem.Value), Convert.ToInt32(rcmbLeaveStruct.SelectedValue));
            Rg_Details.DataSource = dt;
            Rg_Details.DataBind();

            rmpLOB.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leaveopeningbalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
}