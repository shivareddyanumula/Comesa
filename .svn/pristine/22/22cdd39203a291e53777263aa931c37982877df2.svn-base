using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Text;
using Telerik.Web.UI;

public partial class Payroll_Arrears : System.Web.UI.Page
{
    SMHR_PERIOD _Obj_Period;
    SMHR_LOGININFO _Obj_LoginInfo;
    SMHR_PAYROLL _obj_Payroll;
    SMHR_ARREARS _obj_Arrears;
    SMHR_ARREARS_DETAILS _obj_Arrears_Det;
    SMHR_PERIODDTL _obj_Smhr_Prddtl;

    private DataTable dtArrears = new DataTable();
    private StringBuilder str = new StringBuilder();
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("ARREARS");
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
                    Rg_Arrears.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Process.Visible = false;
                    btn_GetDet.Visible = false;
                    btn_Finalize.Visible = false;
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
                LoadPeriod();
                LoadBusinessUnit();
                CreateColums();



            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Arrears", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    private void Loadcombobox()
    {
        try
        {
            LoadPeriod();
            LoadBusinessUnit();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Arrears", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

    }
    private void LoadBusinessUnit()
    {
        try
        {
            _Obj_LoginInfo = new SMHR_LOGININFO();
            _Obj_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _Obj_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_Obj_LoginInfo);
            if (dt_BUDetails.Rows.Count != 0)
            {
                ddl_BusinessUnit.DataSource = dt_BUDetails;
                ddl_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
                ddl_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
                ddl_BusinessUnit.DataBind();
            }
            ddl_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Arrears", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void LoadPeriod()
    {
        try
        {
            ///////
            // Present Period 
            //////
            _Obj_Period = new SMHR_PERIOD();
            _Obj_Period.OPERATION = operation.Select;
            _Obj_Period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_PeriodHeaderDetails(_Obj_Period);
            if (dt.Rows.Count != 0)
            {
                ddl_Period.DataSource = dt;
                ddl_Period.DataTextField = "PERIOD_NAME";
                ddl_Period.DataValueField = "PERIOD_ID";
                ddl_Period.DataBind();
            }
            ddl_Period.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

            ///////
            // Effective Period 
            //////

            _Obj_Period = new SMHR_PERIOD();
            _Obj_Period.OPERATION = operation.Select;
            _Obj_Period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtEPeriod = BLL.get_PeriodHeaderDetails(_Obj_Period);
            if (dtEPeriod.Rows.Count != 0)
            {
                ddl_EPeriod.DataSource = dtEPeriod;
                ddl_EPeriod.DataTextField = "PERIOD_NAME";
                ddl_EPeriod.DataValueField = "PERIOD_ID";
                ddl_EPeriod.DataBind();
            }
            ddl_EPeriod.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Arrears", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void ddl_Period_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (ddl_Period.SelectedIndex != 0)
            {
                _obj_Smhr_Prddtl = new SMHR_PERIODDTL();
                _obj_Smhr_Prddtl.PRDDTL_PERIOD_ID = Convert.ToInt32(ddl_Period.SelectedValue);
                _obj_Smhr_Prddtl.MODE = 11;
                DataTable dt_Details = BLL.get_PeriodDetails(_obj_Smhr_Prddtl);
                if (dt_Details.Rows.Count != 0)
                {
                    ddl_PeriodElements.DataSource = dt_Details;
                    ddl_PeriodElements.DataValueField = "PRDDTL_ID";
                    ddl_PeriodElements.DataTextField = "PRDDTL_NAME";
                    ddl_PeriodElements.DataBind();
                }
                ddl_PeriodElements.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                ddl_EPeriod.SelectedIndex = ddl_Period.SelectedIndex;
                ddl_EPeriod.Enabled = false;
                ddl_EPeriod_SelectedIndexChanged(null, null);
            }
            else
            {
                ddl_PeriodElements.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Arrears", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void ddl_EPeriod_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (ddl_EPeriod.SelectedIndex != 0)
            {
                _obj_Payroll = new SMHR_PAYROLL();
                _obj_Payroll.PERIODDTLID = Convert.ToInt32(ddl_EPeriod.SelectedValue);
                _obj_Payroll.MODE = 11;
                DataTable dt_Details = BLL.get_payrolltrans(_obj_Payroll);
                if (dt_Details.Rows.Count != 0)
                {
                    ddl_EPeriodElements.DataSource = dt_Details;
                    ddl_EPeriodElements.DataValueField = "PRDDTL_ID";
                    ddl_EPeriodElements.DataTextField = "PRDDTL_NAME";
                    ddl_EPeriodElements.DataBind();
                }
                ddl_EPeriodElements.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            }
            else
            {
                ddl_EPeriodElements.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Arrears", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    private Boolean validations()
    {

        try
        {
            _obj_Arrears_Det = new SMHR_ARREARS_DETAILS();
            _obj_Arrears_Det.SMHR_ARR_BUID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
            _obj_Arrears_Det.SMHR_ARR_PERIOD = Convert.ToInt32(ddl_Period.SelectedValue);
            _obj_Arrears_Det.Mode = 11;
            _obj_Arrears_Det.SMHR_ARR_FROM_PERIODELEMENT = (Convert.ToInt32(ddl_PeriodElements.SelectedValue));

            DataTable dt2 = BLL.get_EmployeeArrears_Det(_obj_Arrears_Det);
            if (dt2.Rows.Count > 0)
            {
                BLL.ShowMessage(this, "CAN NOT RUN ARREARS BECAUSE PAYROLL ALREDY EXIST FOR THIS MONTH");
                return false;
            }


            _obj_Arrears_Det = new SMHR_ARREARS_DETAILS();
            _obj_Arrears_Det.SMHR_ARR_BUID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
            _obj_Arrears_Det.SMHR_ARR_PERIOD = Convert.ToInt32(ddl_Period.SelectedValue);
            _obj_Arrears_Det.Mode = 11;
            _obj_Arrears_Det.SMHR_ARR_FROM_PERIODELEMENT = (Convert.ToInt32(ddl_PeriodElements.SelectedValue) - 1);

            DataTable dt3 = BLL.get_EmployeeArrears_Det(_obj_Arrears_Det);
            if (dt3.Rows.Count <= 0)
            {
                BLL.ShowMessage(this, "RUN PAYROLL UP TO PREVIOUS MONTH");
                return false;
            }
            return true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Arrears", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return false;
        }
    }
    protected void btn_GetDet_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddl_EPeriodElements.SelectedIndex < ddl_PeriodElements.SelectedIndex)
            {
                if (Session["LNK"] == "ADD")
                {

                    btn_Process.Enabled = true;
                    btn_Finalize.Enabled = true;

                    _obj_Arrears_Det = new SMHR_ARREARS_DETAILS();
                    _obj_Arrears_Det.SMHR_ARR_BUID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
                    _obj_Arrears_Det.SMHR_ARR_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Arrears_Det.SMHR_ARR_PERIOD = Convert.ToInt32(ddl_Period.SelectedValue);
                    _obj_Arrears_Det.Mode = 10;
                    _obj_Arrears_Det.SMHR_ARR_FROM_PERIODELEMENT = Convert.ToInt32(ddl_PeriodElements.SelectedValue);
                    _obj_Arrears_Det.SMHR_ARR_TO_PERIODELEMENT = Convert.ToInt32(ddl_EPeriodElements.SelectedValue);

                    DataTable dtr = BLL.get_EmployeeArrears_Det(_obj_Arrears_Det);
                    if (dtr.Rows.Count > 0)
                    {
                        BLL.ShowMessage(this, "THE RECORD, YOU ARE TRYING TO ENTER ALREADY EXISTS");
                        return;
                    }
                    if (validations() == false)
                    {
                        return;
                    }
                    GRV_Arrears.Visible = true;
                    //code for security
                    if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                    {
                        btn_Process.Visible = false;
                        btn_Finalize.Visible = false;

                    }

                    else
                    {
                        btn_Process.Visible = true;
                        btn_Finalize.Visible = true;
                    }

                    _obj_Arrears = new SMHR_ARREARS();
                    _obj_Arrears.Mode = 4;
                    _obj_Arrears.SMHR_ARR_BUID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
                    _obj_Arrears.SMHR_ARR_PERIOD = Convert.ToInt32(ddl_PeriodElements.SelectedValue);
                    DataTable dt = BLL.get_EmployeeArrears(_obj_Arrears);
                    GRV_Arrears.DataSource = dt;
                    GRV_Arrears.DataBind();
                }
                else if (Session["LNK"] == "EDIT")
                {
                    //    GRV_Arrears.Visible = true;
                    //    if (Session["Status"] == "FINALIZED")
                    //    {
                    //        btn_Process.Visible = false;
                    //        btn_Finalize.Visible = false;
                    //    }
                    //    else
                    //    {
                    //        btn_Process.Visible = true;
                    //        btn_Finalize.Visible = true;
                    //    }
                    //    _obj_Arrears = new SMHR_ARREARS();
                    //    _obj_Arrears.Mode = 4;
                    //    _obj_Arrears.SMHR_ARR_BUID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
                    //    _obj_Arrears.SMHR_ARR_PERIOD = Convert.ToInt32(ddl_PeriodElements.SelectedValue);
                    //    DataTable dt = BLL.get_EmployeeArrears(_obj_Arrears);
                    //    GRV_Arrears.DataSource = dt;
                    //    GRV_Arrears.DataBind();
                    //    PopulateGrid();

                }
            }
            else
            {
                BLL.ShowMessage(this, "With Effective from should be less than Present Period");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Arrears", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void ClearFields()
    {
        try
        {
            ddl_PeriodElements.Items.Clear();
            ddl_EPeriodElements.Items.Clear();
            ddl_BusinessUnit.SelectedIndex = 0;
            ddl_EPeriod.SelectedIndex = 0;
            ddl_Period.SelectedIndex = 0;
            ddl_EPeriod.Enabled = true;
            GRV_Arrears.Visible = false;
            btn_Process.Visible = false;
            btn_Finalize.Visible = false;
            ddl_PeriodElements.Enabled = true;
            ddl_EPeriodElements.Enabled = true;
            ddl_BusinessUnit.Enabled = true;
            ddl_EPeriod.Enabled = true;
            ddl_Period.Enabled = true;

            ddl_Period.Enabled = true;
            ddl_PeriodElements.Enabled = true;
            ddl_EPeriodElements.Enabled = true;
            ddl_BusinessUnit.Enabled = true;
            ddl_EPeriod.Enabled = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Arrears", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            ClearFields();
            rm_Arrears.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Arrears", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            //clearControls();
            //btn_Save.Visible = true;
            ClearFields();
            rm_Arrears.SelectedIndex = 1;
            Session["LNK"] = "ADD";
            Session["Status"] = "NOTPROCESS";
            btn_GetDet.Visible = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Arrears", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            //clearControls();
            //rtxt_CountryCode.Enabled = false;
            ddl_Period.Enabled = false;
            ddl_PeriodElements.Enabled = false;
            ddl_EPeriodElements.Enabled = false;
            ddl_BusinessUnit.Enabled = false;
            ddl_EPeriod.Enabled = false;

            _obj_Arrears = new SMHR_ARREARS();
            _obj_Arrears.SMHR_ARR_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            Session["ARRID"] = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            _obj_Arrears.Mode = 7;
            //_obj_Smhr_Country = new SMHR_COUNTRY();
            //_obj_Smhr_Country.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT = BLL.get_EmployeeArrears(_obj_Arrears);
            if (DT.Rows.Count > 0)
            {
                Loadcombobox();
                ddl_Period.SelectedIndex = ddl_Period.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["SMHR_ARR_PERIOD"]));
                ddl_EPeriod.SelectedIndex = ddl_Period.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["SMHR_ARR_PERIOD"]));
                ddl_BusinessUnit.SelectedIndex = ddl_BusinessUnit.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["SMHR_ARR_BUID"]));

                if (ddl_Period.SelectedIndex != 0)
                {
                    //_obj_Payroll = new SMHR_PAYROLL();
                    //_obj_Payroll.PERIODDTLID = Convert.ToInt32(ddl_Period.SelectedValue);
                    //_obj_Payroll.MODE = 11;
                    //DataTable dt_Details = BLL.get_payrolltrans(_obj_Payroll);
                    //if (dt_Details.Rows.Count != 0)
                    //{
                    //    ddl_PeriodElements.DataSource = dt_Details;
                    //    ddl_PeriodElements.DataValueField = "PRDDTL_ID";
                    //    ddl_PeriodElements.DataTextField = "PRDDTL_NAME";
                    //    ddl_PeriodElements.DataBind();
                    //}
                    _obj_Smhr_Prddtl = new SMHR_PERIODDTL();
                    _obj_Smhr_Prddtl.PRDDTL_PERIOD_ID = Convert.ToInt32(ddl_Period.SelectedValue);
                    _obj_Smhr_Prddtl.MODE = 11;
                    DataTable dt_Details = BLL.get_PeriodDetails(_obj_Smhr_Prddtl);
                    if (dt_Details.Rows.Count != 0)
                    {
                        ddl_PeriodElements.DataSource = dt_Details;
                        ddl_PeriodElements.DataValueField = "PRDDTL_ID";
                        ddl_PeriodElements.DataTextField = "PRDDTL_NAME";
                        ddl_PeriodElements.DataBind();
                    }
                    ddl_PeriodElements.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                    ddl_EPeriod.SelectedIndex = ddl_Period.SelectedIndex;
                    ddl_EPeriod.Enabled = false;
                    ddl_EPeriod_SelectedIndexChanged(null, null);
                }

                ddl_PeriodElements.SelectedIndex = ddl_PeriodElements.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["SMHR_ARR_FROM_PERIODELEMENT"]));
                ddl_EPeriodElements.SelectedIndex = ddl_EPeriodElements.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["SMHR_ARR_TO_PERIODELEMENT"]));

                if (Convert.ToInt32(DT.Rows[0]["SMHR_ARR_STATUS"]) == 1)
                {
                    Session["Status"] = "FINALIZED";
                }
                else
                {
                    Session["Status"] = "PROCESS";
                }
                Session["LNK"] = "EDIT";
                rm_Arrears.SelectedIndex = 1;
                btn_GetDet.Visible = false;


                /////////////////////


                GRV_Arrears.Visible = true;
                if (Session["Status"] == "FINALIZED")
                {
                    btn_Process.Visible = false;
                    btn_Finalize.Visible = false;
                }
                else
                { //code for security
                    if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                    {
                        btn_Process.Visible = false;
                        btn_Finalize.Visible = false;

                    }

                    else
                    {
                        btn_Process.Visible = true;
                        btn_Finalize.Visible = true;
                    }

                }
                _obj_Arrears = new SMHR_ARREARS();
                _obj_Arrears.Mode = 4;
                _obj_Arrears.SMHR_ARR_BUID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
                _obj_Arrears.SMHR_ARR_PERIOD = Convert.ToInt32(ddl_PeriodElements.SelectedValue);
                DataTable dt = BLL.get_EmployeeArrears(_obj_Arrears);
                GRV_Arrears.DataSource = dt;
                GRV_Arrears.DataBind();
                PopulateGrid();
                //////////////////////////////////
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Arrears", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

    }
    protected void Rg_Arrears_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Arrears", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    public void LoadGrid()
    {
        try
        {
            _obj_Arrears_Det = new SMHR_ARREARS_DETAILS();
            _obj_Arrears_Det.SMHR_ARR_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Arrears_Det.Mode = 6;
            //_obj_Smhr_Country = new SMHR_COUNTRY();
            //_obj_Smhr_Country.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT = BLL.get_EmployeeArrears(_obj_Arrears_Det);
            Rg_Arrears.DataSource = DT;
            Rg_Arrears.ClientSettings.Scrolling.AllowScroll = true;
            //clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Arrears", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void btn_Process_Click(object sender, EventArgs e)
    {
        try
        {
            Boolean strstatus = false;
            string strType = string.Empty;
            string strValue = string.Empty;
            double oldGrossSalary = 0;
            double newGrossSalary = 0;
            double arrayvalue = 0;
            DataTable dtCheck = (DataTable)ViewState["DT"];
            dtCheck.Rows.Clear();
            ViewState["DT"] = dtCheck;

            int arrsid = 0;
            Session["Status"] = "NOTPROCESS";

            for (int i = 0; i < GRV_Arrears.Rows.Count; i++)
            {
                Label lblGross = new Label();
                Label lblEmpID = new Label();
                Label lblOldGross = new Label();
                DropDownList ddlList = new DropDownList();
                Telerik.Web.UI.RadNumericTextBox txt_Arr_Value = new Telerik.Web.UI.RadNumericTextBox();
                lblOldGross = GRV_Arrears.Rows[i].FindControl("lbl_Emp_Gross") as Label;
                lblGross = GRV_Arrears.Rows[i].FindControl("lbl_Emp_New_Gross") as Label;
                lblEmpID = GRV_Arrears.Rows[i].FindControl("lbl_Emp_ID") as Label;
                ddlList = GRV_Arrears.Rows[i].FindControl("ddl_Type") as DropDownList;
                txt_Arr_Value = GRV_Arrears.Rows[i].FindControl("txt_Value") as Telerik.Web.UI.RadNumericTextBox;
                if (txt_Arr_Value.Value != null)
                {

                    strstatus = true;
                }

            }


            if (strstatus == true)
            {


                _obj_Arrears_Det = new SMHR_ARREARS_DETAILS();
                _obj_Arrears_Det.SMHR_ARR_BUID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
                _obj_Arrears_Det.SMHR_ARR_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Arrears_Det.SMHR_ARR_PERIOD = Convert.ToInt32(ddl_Period.SelectedValue);
                _obj_Arrears_Det.Mode = 10;
                _obj_Arrears_Det.SMHR_ARR_FROM_PERIODELEMENT = Convert.ToInt32(ddl_PeriodElements.SelectedValue);
                _obj_Arrears_Det.SMHR_ARR_TO_PERIODELEMENT = Convert.ToInt32(ddl_EPeriodElements.SelectedValue);

                DataTable dtr = BLL.get_EmployeeArrears_Det(_obj_Arrears_Det);
                if (dtr.Rows.Count > 0)
                {
                    arrsid = Convert.ToInt32(Session["ARRID"]);
                    _obj_Arrears_Det = new SMHR_ARREARS_DETAILS();
                    _obj_Arrears_Det.SMHR_ARR_ID = arrsid;
                    _obj_Arrears_Det.Mode = 5;
                    BLL.set_Arrears_Details(_obj_Arrears_Det);

                    // BLL.ShowMessage(this, "THE RECORD, YOU ARE TRYING TO ENTER ALREADY EXISTS");
                    //return;
                }
                else
                {

                    _obj_Arrears = new SMHR_ARREARS();
                    _obj_Arrears.SMHR_ARR_BUID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
                    _obj_Arrears.SMHR_ARR_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Arrears.SMHR_ARR_PERIOD = Convert.ToInt32(ddl_Period.SelectedValue);
                    _obj_Arrears.SMHR_ARR_STATUS = 0;
                    _obj_Arrears.SMHR_ARR_FROM_PERIODELEMENT = Convert.ToInt32(ddl_PeriodElements.SelectedValue);
                    _obj_Arrears.SMHR_ARR_TO_PERIODELEMENT = Convert.ToInt32(ddl_EPeriodElements.SelectedValue);

                    if (BLL.set_Arrears(_obj_Arrears) == true)
                    {
                        _obj_Arrears_Det = new SMHR_ARREARS_DETAILS();
                        _obj_Arrears_Det.Mode = 5;
                        DataTable dtdt = BLL.get_EmployeeArrears_Det(_obj_Arrears_Det);
                        if (dtdt.Rows.Count > 0)
                        {
                            arrsid = Convert.ToInt32(dtdt.Rows[0]["SMHR_ARR_ID"]);
                            Session["ARRID"] = arrsid;
                        }
                    }
                }


                ///////////////////
                for (int i = 0; i < GRV_Arrears.Rows.Count; i++)
                {
                    Label lblGross = new Label();
                    Label lblEmpID = new Label();
                    Label lblOldGross = new Label();
                    DropDownList ddlList = new DropDownList();
                    Telerik.Web.UI.RadNumericTextBox txt_Arr_Value = new Telerik.Web.UI.RadNumericTextBox();
                    lblOldGross = GRV_Arrears.Rows[i].FindControl("lbl_Emp_Gross") as Label;
                    lblGross = GRV_Arrears.Rows[i].FindControl("lbl_Emp_New_Gross") as Label;
                    lblEmpID = GRV_Arrears.Rows[i].FindControl("lbl_Emp_ID") as Label;
                    ddlList = GRV_Arrears.Rows[i].FindControl("ddl_Type") as DropDownList;
                    txt_Arr_Value = GRV_Arrears.Rows[i].FindControl("txt_Value") as Telerik.Web.UI.RadNumericTextBox;
                    if (txt_Arr_Value.Value != null)
                    {
                        oldGrossSalary = 0;
                        arrayvalue = 0;
                        newGrossSalary = 0;
                        if (Convert.ToInt32(txt_Arr_Value.Value) > 0)
                        {

                            if (ddlList.SelectedItem.Text.ToString().Trim() == "%Age")
                            {
                                strType = "%";

                                oldGrossSalary = Convert.ToDouble(lblOldGross.Text);
                                arrayvalue = Convert.ToDouble(txt_Arr_Value.Value);
                                if (arrayvalue > 100)
                                {
                                    arrayvalue = 100;
                                }

                                newGrossSalary = oldGrossSalary + (arrayvalue * oldGrossSalary) / 100;

                            }
                            else
                            {
                                strType = "DIRECT";
                                oldGrossSalary = Convert.ToDouble(lblOldGross.Text);
                                arrayvalue = Convert.ToDouble(txt_Arr_Value.Value);
                                newGrossSalary = oldGrossSalary + arrayvalue;
                            }
                        }

                        for (int pe = Convert.ToInt32(ddl_EPeriodElements.SelectedValue); pe < Convert.ToInt32(ddl_PeriodElements.SelectedValue); pe++)
                        {
                            //writen by sridevi
                            //Inserting Individul payitem details(exept TDS)  in to SMHR_ARREARS_SALDETAILS Table
                            _obj_Arrears_Det = new SMHR_ARREARS_DETAILS();
                            _obj_Arrears_Det.SMHR_ARR_EMP_ID = Convert.ToInt32(lblEmpID.Text);
                            _obj_Arrears_Det.SMHR_ARR_PERIOD = Convert.ToInt32(ddl_Period.SelectedValue);
                            _obj_Arrears_Det.SMHR_ARR_FROM_PERIODELEMENT = Convert.ToInt32(pe);
                            _obj_Arrears_Det.SMHR_ARR_SALSTRUCT = Convert.ToInt32(ddl_Period.SelectedValue);
                            _obj_Arrears_Det.SMHR_ARR_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                            _obj_Arrears_Det.SMHR_ARR_CREATEDDATE = Convert.ToDateTime(DateTime.Now);
                            _obj_Arrears_Det.SMHR_ARR_BUID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
                            _obj_Arrears_Det.SMHR_ARR_EMP_NEW_GS = newGrossSalary;
                            _obj_Arrears_Det.SMHR_ARR_ID = arrsid;
                            _obj_Arrears_Det.SMHR_ARR_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Arrears_Det.Mode = 1;
                            if (BLL.set_Arrears_Details(_obj_Arrears_Det) == false)
                            {
                                return;
                            }

                        }

                        //Writen by Sridevi 02/01/11
                        // for TDS Caleculations.////////////
                        if (arrayvalue > 0)
                        {

                            string ACTUALGIVENPERIODS = null;
                            int NEWGROSSPERIODS = 0;
                            int EXTRAGROSSPERIODS = 0;
                            double newgrossamount = 0;
                            double extraarrearsamount = 0;

                            _obj_Arrears_Det = new SMHR_ARREARS_DETAILS();
                            _obj_Arrears_Det.SMHR_ARR_PERIOD = Convert.ToInt32(ddl_Period.SelectedValue);
                            _obj_Arrears_Det.SMHR_ARR_FROM_PERIODELEMENT = Convert.ToInt32(ddl_PeriodElements.SelectedValue);
                            _obj_Arrears_Det.Mode = 2;
                            DataTable dtpcnt = BLL.get_Arrears_tds(_obj_Arrears_Det);
                            for (int pc = 0; pc < dtpcnt.Rows.Count; pc++)
                            {
                                NEWGROSSPERIODS = Convert.ToInt32(dtpcnt.Rows[pc]["NEWGROSSPERIODS"]);

                            }

                            _obj_Arrears_Det = new SMHR_ARREARS_DETAILS();
                            _obj_Arrears_Det.SMHR_ARR_PERIOD = Convert.ToInt32(ddl_Period.SelectedValue);
                            _obj_Arrears_Det.SMHR_ARR_FROM_PERIODELEMENT = Convert.ToInt32(ddl_PeriodElements.SelectedValue) - 1;
                            _obj_Arrears_Det.SMHR_ARR_TO_PERIODELEMENT = Convert.ToInt32(ddl_EPeriodElements.SelectedValue);
                            _obj_Arrears_Det.Mode = 3;
                            DataTable dtpcnt2 = BLL.get_Arrears_tds(_obj_Arrears_Det);
                            for (int pc2 = 0; pc2 < dtpcnt2.Rows.Count; pc2++)
                            {
                                EXTRAGROSSPERIODS = Convert.ToInt32(dtpcnt2.Rows[pc2]["EXTRAGROSSPERIODS"]);

                            }
                            if (NEWGROSSPERIODS >= 0)
                            {
                                newgrossamount = newGrossSalary * NEWGROSSPERIODS;

                            }
                            if (EXTRAGROSSPERIODS >= 0)
                            {
                                extraarrearsamount = (newGrossSalary - oldGrossSalary) * EXTRAGROSSPERIODS;

                            }

                            _obj_Arrears_Det = new SMHR_ARREARS_DETAILS();
                            _obj_Arrears_Det.SMHR_ARR_PERIOD = Convert.ToInt32(ddl_Period.SelectedValue);
                            _obj_Arrears_Det.SMHR_ARR_FROM_PERIODELEMENT = Convert.ToInt32(ddl_PeriodElements.SelectedValue);
                            _obj_Arrears_Det.Mode = 1;
                            DataTable dtperiods = BLL.get_Arrears_tds(_obj_Arrears_Det);
                            for (int p = 0; p < dtperiods.Rows.Count; p++)
                            {
                                if (ACTUALGIVENPERIODS != null)
                                {
                                    ACTUALGIVENPERIODS = ACTUALGIVENPERIODS + "," + Convert.ToString(dtperiods.Rows[p]["ACTUALGIVENPERIODS"]);
                                }
                                else
                                {
                                    ACTUALGIVENPERIODS = Convert.ToString(dtperiods.Rows[p]["ACTUALGIVENPERIODS"]);

                                }
                            }


                            // Written by Sridevi
                            // Caleculating TDS amount For  Employee and inserting details in to SMHR_ARREARS_SALDETAILS

                            _obj_Arrears_Det = new SMHR_ARREARS_DETAILS();
                            _obj_Arrears_Det.SMHR_ARR_EMP_PRESENT_GS = Convert.ToDouble(newgrossamount);
                            _obj_Arrears_Det.SMHR_ARR_EMP_NEW_GS = Convert.ToDouble(extraarrearsamount);
                            _obj_Arrears_Det.SMHR_ARR_EMP_ID = Convert.ToInt32(lblEmpID.Text);
                            _obj_Arrears_Det.SMHR_ARR_PERIOD = Convert.ToInt32(ddl_Period.SelectedValue);
                            _obj_Arrears_Det.SMHR_ARR_TO_PERIODELEMENT = Convert.ToInt32(ddl_EPeriodElements.SelectedValue);
                            _obj_Arrears_Det.ACTUALGIVENPERIODS = Convert.ToString(ACTUALGIVENPERIODS);
                            _obj_Arrears_Det.SMHR_ARR_ID = arrsid;
                            _obj_Arrears_Det.SMHR_ARR_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Arrears_Det.SMHR_ARR_BUID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
                            _obj_Arrears_Det.Mode = 7;
                            BLL.set_Arrears_Details(_obj_Arrears_Det);


                            //Writen by Sridevi 02/01/11
                            //  // Updating Difference as arreas amount  in to SMHR_ARREARS_SALDETAILS Table
                            for (int pr = Convert.ToInt32(ddl_EPeriodElements.SelectedValue); pr < Convert.ToInt32(ddl_PeriodElements.SelectedValue); pr++)
                            {
                                _obj_Arrears_Det = new SMHR_ARREARS_DETAILS();
                                _obj_Arrears_Det.SMHR_ARR_EMP_ID = Convert.ToInt32(lblEmpID.Text);
                                _obj_Arrears_Det.SMHR_ARR_FROM_PERIODELEMENT = Convert.ToInt32(pr);
                                _obj_Arrears_Det.SMHR_ARR_BUID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
                                _obj_Arrears_Det.SMHR_ARR_ID = arrsid;
                                _obj_Arrears_Det.Mode = 2;
                                BLL.set_Arrears_Details(_obj_Arrears_Det);
                            }

                            //Inserting Arrears Details into arrears details table.
                            _obj_Arrears_Det = new SMHR_ARREARS_DETAILS();
                            _obj_Arrears_Det.SMHR_ARR_EMP_PRESENT_GS = Convert.ToDouble(oldGrossSalary);
                            _obj_Arrears_Det.SMHR_ARR_EMP_NEW_GS = Convert.ToDouble(newGrossSalary);
                            _obj_Arrears_Det.SMHR_ARR_EMP_ID = Convert.ToInt32(lblEmpID.Text);
                            _obj_Arrears_Det.SMHR_ARR_EMP_ARR_TYPE = strType;
                            _obj_Arrears_Det.SMHR_ARR_PERIOD = Convert.ToInt32(ddl_Period.SelectedValue);
                            _obj_Arrears_Det.SMHR_ARR_FROM_PERIODELEMENT = Convert.ToInt32(ddl_PeriodElements.SelectedValue);
                            _obj_Arrears_Det.SMHR_ARR_TO_PERIODELEMENT = Convert.ToInt32(ddl_EPeriodElements.SelectedValue);
                            _obj_Arrears_Det.SMHR_ARR_STATUS = 0;
                            _obj_Arrears_Det.SMHR_ARR_EMP_ARR_VALUE = arrayvalue;
                            _obj_Arrears_Det.SMHR_ARR_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Arrears_Det.SMHR_ARR_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                            _obj_Arrears_Det.SMHR_ARR_CREATEDDATE = Convert.ToDateTime(DateTime.Now);
                            _obj_Arrears_Det.SMHR_ARR_BUID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
                            _obj_Arrears_Det.SMHR_ARR_ID = arrsid;
                            _obj_Arrears_Det.ACTUALGIVENPERIODS = Convert.ToString(ACTUALGIVENPERIODS);
                            _obj_Arrears_Det.Mode = 3;
                            BLL.set_Arrears_Details(_obj_Arrears_Det);
                        }


                    }

                }

                PopulateGrid();
                Session["Status"] = "PROCESS";
                BLL.ShowMessage(this, "Arrears Processed Sucessfully.");
                //code for security
                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    btn_Finalize.Visible = false;

                }

                else
                {
                    btn_Finalize.Visible = true;
                }

                ddl_BusinessUnit.Enabled = false;
                ddl_EPeriod.Enabled = false;
                ddl_Period.Enabled = false;
                ddl_EPeriodElements.Enabled = false;
                ddl_PeriodElements.Enabled = false;



            }
            else
            {
                BLL.ShowMessage(this, "Atleast Enter One Value.");
                return;
                Session["Status"] = "NOTPROCESS";
            }


        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Arrears", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void CreateColums()
    {
        try
        {
            dtArrears.Columns.Clear();
            dtArrears.Columns.Add("EMP_ID");
            dtArrears.Columns.Add("EMP_GROSSSAL");
            dtArrears.Columns.Add("BASIC");
            dtArrears.Columns.Add("EMP_NEW_GROSS");
            dtArrears.Columns.Add("ARREARS");
            dtArrears.Columns.Add("EMP_NEW_PF");
            dtArrears.Columns.Add("EMP_NEW_ESI");
            dtArrears.Columns.Add("EMP_NEW_PT");
            dtArrears.Columns.Add("EMP_NEW_TDS");
            ViewState["DT"] = dtArrears;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Arrears", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void writeRows(DataTable dt)
    {
        try
        {
            if (dt.Rows.Count != 0)
            {
                DataTable dtA = (DataTable)ViewState["DT"];
                DataRow dr = dtA.NewRow();
                dr[0] = Convert.ToString(dt.Rows[0]["EMP_ID"]);
                dr[1] = Convert.ToString(dt.Rows[0]["EMP_GROSSSAL"]);
                dr[2] = Convert.ToString(dt.Rows[0]["BASIC"]);
                dr[3] = Convert.ToString(dt.Rows[0]["EMP_NEW_GROSS"]);
                dr[4] = Convert.ToString(dt.Rows[0]["ARREARS"]);
                dr[5] = Convert.ToString(dt.Rows[0]["EMP_NEW_PF"]);
                dr[6] = Convert.ToString(dt.Rows[0]["EMP_NEW_ESI"]);
                dtA.Rows.Add(dr);
                ViewState["DT"] = dtA;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Arrears", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void PopulateGrid()
    {
        try
        {
            _obj_Arrears_Det = new SMHR_ARREARS_DETAILS();
            _obj_Arrears_Det.SMHR_ARR_ID = Convert.ToInt32(Session["ARRID"]);
            _obj_Arrears_Det.Mode = 4;
            DataTable dtGrid = BLL.get_EmployeeArrears_Det(_obj_Arrears_Det);

            //DataTable dtGrid = (DataTable)ViewState["DT"];
            if (dtGrid.Rows.Count != 0)
            {
                for (int j = 0; j < dtGrid.Rows.Count; j++)
                {
                    for (int i = 0; i < GRV_Arrears.Rows.Count; i++)
                    {
                        Label lblGross = new Label();
                        Label lblEmpID = new Label();
                        Label lblArrears = new Label();
                        Label lblOldGross = new Label();
                        DropDownList ddlList = new DropDownList();
                        RadNumericTextBox txt_Arr_Value = new RadNumericTextBox();

                        lblGross = GRV_Arrears.Rows[i].FindControl("lbl_Emp_New_Gross") as Label;
                        lblEmpID = GRV_Arrears.Rows[i].FindControl("lbl_Emp_ID") as Label;
                        lblArrears = GRV_Arrears.Rows[i].FindControl("lbl_Emp_Arrears") as Label;
                        lblOldGross = GRV_Arrears.Rows[i].FindControl("lbl_Emp_Gross") as Label;
                        txt_Arr_Value = GRV_Arrears.Rows[i].FindControl("txt_Value") as Telerik.Web.UI.RadNumericTextBox;
                        ddlList = GRV_Arrears.Rows[i].FindControl("ddl_Type") as DropDownList;

                        if (Convert.ToString(dtGrid.Rows[j]["SMHR_ARR_EMP_ID"]) == Convert.ToString(lblEmpID.Text))
                        {
                            //lblOldGross.Text = String.Format("{0:0.00}", Convert.ToString(dtGrid.Rows[i]["SMHR_ARR_EMP_NEW_GS"]));
                            lblGross.Text = String.Format("{0:0.00}", Convert.ToString(dtGrid.Rows[j]["SMHR_ARR_EMP_NEW_GS"]));
                            txt_Arr_Value.Text = String.Format("{0:0.00}", Convert.ToInt32(dtGrid.Rows[j]["SMHR_ARR_EMP_ARR_VALUE"]));
                            if (Convert.ToInt32(dtGrid.Rows[j]["SMHR_ARR_EMP_ARR_VALUE"]) > 0)
                            {
                                lblArrears.Text = String.Format("{0:0.00}", Convert.ToString(dtGrid.Rows[j]["SMHR_ARR_PAY"]));

                            }
                            else
                            {
                                lblArrears.Text = "Not Processed";
                            }


                            //lblArrears.Text = String.Format("{0:0.00}", Convert.ToString(dtGrid.Rows[j]["SMHR_ARR_PAY"]));
                            if (Convert.ToString(dtGrid.Rows[j]["SMHR_ARR_EMP_ARR_TYPE"]).Trim() == "%")
                            {
                                ddlList.SelectedIndex = 0;
                            }
                            else
                            {
                                ddlList.SelectedIndex = 1;
                            }
                            break;
                        }
                        else
                        {
                            //lblArrears.Text = "Not Processed";

                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Arrears", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void SaveData(DataTable dt, string Type, string Value)
    {
        try
        {
            str.Append("EXEC USP_SMHR_ARREARS_DETAILS @SMHR_ARR_EMP_ID = '" + Convert.ToString(dt.Rows[0]["EMP_ID"]) + "'," +
                                  "@SMHR_ARR_EMP_PRESENT_GS = '" + Convert.ToString(dt.Rows[0]["EMP_GROSSSAL"]) + "'" +
                                 ", @SMHR_ARR_EMP_ARR_TYPE = '" + Convert.ToString(Type) + "', @SMHR_ARR_EMP_ARR_VALUE = '" + Convert.ToString(Value) + "'" +
                                 ",@SMHR_ARR_EMP_NEW_GS = '" + Convert.ToString(dt.Rows[0]["EMP_NEW_GROSS"]) + "'" +
                                 ",@SMHR_ARR_CREATEDBY = '" + Convert.ToString(1) + "'" +
                                 ",@SMHR_ARR_CREATEDDATE = '" + Convert.ToString(DateTime.Now) + "'" +
                                 ",@SMHR_ARR_STATUS = '0'" +
                                 ",@SMHR_ARR_ORG_ID = '" + Convert.ToString(Session["ORG_ID"]) + "'" +
                                ", @SMHR_ARR_BUID = '" + Convert.ToInt32(ddl_BusinessUnit.SelectedValue) + "'" +
                                ", @SMHR_ARR_PERIOD = '" + Convert.ToInt32(ddl_PeriodElements.SelectedValue) + "'" +
                                ", @SMHR_ARR_WEF = '" + Convert.ToInt32(ddl_EPeriodElements.SelectedValue) + "'" +
                                ",@SMHR_ARR_PAY = '" + Convert.ToString(dt.Rows[0]["ARREARS"]) + "'" +
                                 ",@MODE = '1'");
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Arrears", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private bool saveArrears()
    {
        try
        {
            bool status = false;
            status = BLL.set_Arrears_Details(str.ToString());
            if (status == true)
                return true;
            else
                return false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Arrears", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return false;
        }
    }

    private void deleteArrears()
    {
        try
        {
            DataTable dt = BLL.ExecuteQuery("SELECT * FROM SMHR_ARREARS_DETAILS WHERE SMHR_ARR_ORG_ID = '" + Convert.ToString(Session["ORG_ID"]) + "'" +
                                                              "  AND  SMHR_ARR_BUID = '" + ddl_BusinessUnit.SelectedValue + "'" +
                                                              "  AND SMHR_ARR_PERIOD = '" + ddl_PeriodElements.SelectedValue + "'" +
                                                              "  AND SMHR_ARR_WEF = '" + ddl_EPeriodElements.SelectedValue + "'");
            if (dt.Rows.Count != 0)
            {
                bool status = BLL.ExecuteNonQuery("DELETE FROM SMHR_ARREARS_DETAILS WHERE SMHR_ARR_ORG_ID = '" + Convert.ToString(Session["ORG_ID"]) + "'" +
                                                         " AND SMHR_ARR_BUID = '" + ddl_BusinessUnit.SelectedValue + "'" +
                                                         " AND SMHR_ARR_PERIOD = '" + ddl_PeriodElements.SelectedValue + "'" +
                                                         " AND SMHR_ARR_WEF = '" + ddl_EPeriodElements.SelectedValue + "'");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Arrears", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void btn_Finalize_Click(object sender, EventArgs e)
    {
        try
        {
            //DataTable dt = BLL.ExecuteQuery("SELECT * FROM SMHR_ARREARS_DETAILS WHERE SMHR_ARR_ORG_ID = '" + Convert.ToString(Session["ORG_ID"]) + "'" +
            //                                             "  AND  SMHR_ARR_BUID = '" + ddl_BusinessUnit.SelectedValue + "'" +
            //                                             "  AND SMHR_ARR_PERIOD = '" + ddl_PeriodElements.SelectedValue + "'" +
            //                                             "  AND SMHR_ARR_WEF = '" + ddl_EPeriodElements.SelectedValue + "'");
            //if (dt.Rows.Count != 0)
            //{
            if (Session["Status"] == "PROCESS")
            {
                if (validations() == false)
                {
                    return;
                }
                // CHANGING ARREARS STUS TO FINALIZE
                bool status = false;
                _obj_Arrears_Det = new SMHR_ARREARS_DETAILS();
                _obj_Arrears_Det.Mode = 4;
                _obj_Arrears_Det.SMHR_ARR_ID = Convert.ToInt32(Session["ARRID"]);
                status = BLL.set_Arrears_Details(_obj_Arrears_Det);

                if (status == true)
                {
                    _obj_Arrears_Det = new SMHR_ARREARS_DETAILS();
                    _obj_Arrears_Det.SMHR_ARR_ID = Convert.ToInt32(Session["ARRID"]);
                    _obj_Arrears_Det.SMHR_ARR_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Arrears_Det.Mode = 6;
                    BLL.set_Arrears_Details(_obj_Arrears_Det);


                    BLL.ShowMessage(this, "Arrears Finalized Successfully");
                    btn_Finalize.Enabled = false;
                    btn_Process.Enabled = false;
                    return;
                }
                else
                {
                    BLL.ShowMessage(this, "Error Occured While doing the process");
                    return;
                }
            }
            else
            {
                BLL.ShowMessage(this, "Can not  Finaliz Arrears With out Process");

                return;

            }

            //}
            //else
            //{
            //    BLL.ShowMessage(this, "No Arrears are processed for this period");
            //    return;
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Arrears", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
}
