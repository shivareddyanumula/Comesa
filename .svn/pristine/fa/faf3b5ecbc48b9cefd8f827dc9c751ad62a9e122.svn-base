using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SMHR;
using Telerik.Web.UI;
using System.IO;
using System.Text;
public partial class frm_EmpTransfer : System.Web.UI.Page
{
    DataTable Dtempty = new DataTable();
    DataTable Dt_loadcombos = new DataTable();
    SMHR_LOGININFO _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
    SMHR_EMPTRANSFER _obj_Emptransfer = new SMHR_EMPTRANSFER();
    SMHR_BUSINESSUNIT _obj_SMHR_BusinessUnit;
    int PERIOD = 0;
    static double minsal = 0.0;
    static double maxsal = 0.0;
    #region Pageload
    /// <summary>
    /// this method will load the grid,combos and also disapbles
    /// date of joining,date of conform,length of service
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("EMPLOYEE TRANSFER");
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
                    rg_Emptransfer.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Submit.Visible = false;
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
                loadgrid();
                rg_Emptransfer.DataBind();
                LOADBU();
                LoadPeriod();

                //if (dt_executiondate.Rows[0]["MINDATE"].ToString() == string.Empty)
                //{
                //   // BLL.ShowMessage(this, "NO Transaction Is Runned Till Now!");
                //}
                //else
                //{
                //    rdtp_Executiondate.MinDate = Convert.ToDateTime(dt_executiondate.Rows[0]["MINDATE"].ToString());                
                //}
                // rdtp_Executiondate.MaxDate = dt;
                // loadcombos();
                rdtp_DOC.Enabled = false;
                rdtp_DOJ.Enabled = false;
                rtxt_LOS.Enabled = false;

                rcmb_Businessunit.Enabled = false;
                rcmb_Directorate.Enabled = false;
                rcmb_Department.Enabled = false;
                rcmb_BusinessunitReportingemp.Enabled = false;
                rcmb_Salstruct.Enabled = false;
                rcmb_Shifts.Enabled = false;
                rdtp_Reportingdate.Enabled = false;
                rcmb_Leavestruct.Enabled = false;
                rdtp_Executiondate.Enabled = false;
                rbtnlst_Coform.Enabled = false;
                rcmb_Position.Enabled = false;
                rcmb_Reportingemp.Items.Clear();
                lnkbtn_Check.Enabled = false;

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpTransfer", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

            return;
        }
    }

    /// <summary>
    /// will loads the all business units of the logined person it he is capable of accessing 
    /// multiple businessunits then those all will be loaded
    /// </summary>
    private void LOADBU()
    {

        try
        {
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            if (Convert.ToString(Session["ORG_ID"]) != string.Empty)
            {
                _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"].ToString());
                rcmb_Bu.Items.Clear();
                DataTable dt_bu = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
                //Session["BU"] = dt_bu;
                rcmb_Bu.DataSource = dt_bu;
                rcmb_Bu.DataTextField = "BUSINESSUNIT_CODE";
                rcmb_Bu.DataValueField = "BUSINESSUNIT_ID";
                rcmb_Bu.DataBind();
                rcmb_Bu.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
            else
            {
                Response.Redirect("~/Login.aspx", false);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpTransfer", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

            return;
        }



    }

    #endregion

    #region Loading Employees
    /// <summary>
    /// it will take organisation id from the login and get
    /// all the employees who are there for that organisation and also the employee who are transferred previously
    /// 
    /// </summary>
    private void loadcombos()
    {
        try
        {
            rcmb_Reportingemp.Items.Clear();
            //_obj_SMHR_LoginInfo.ORGANISATION_ID = 18;//Convert.ToInt32(Session["ORG_ID"]);
            //_obj_SMHR_LoginInfo.LOGIN_ID = 53;//Convert.ToInt32(Session["USER_ID"]);
            // _obj_SMHR_LoginInfo.BUID = 39;//WE NEED TO GET THIS FROM LOGIN
            lbl_Bu.Visible = true;
            rcmb_Bu.Visible = true;
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            Dt_loadcombos = BLL.get_Employees(_obj_SMHR_LoginInfo);
            rcmb_Employees.DataSource = Dt_loadcombos;
            rcmb_Employees.DataTextField = "EMP_NAME";//"APPLICANT_FIRSTNAME";
            rcmb_Employees.DataValueField = "EMP_ID";
            rcmb_Employees.DataBind();
            rcmb_Employees.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            rcmb_Employees.Enabled = true;
            //rntxt_Gross.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpTransfer", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    private void loadgrid()
    {
        try
        {
            DataTable Dt_Transferdemp = new DataTable();
            _obj_Emptransfer.OPERATION = operation.Empty;
            _obj_Emptransfer.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            Dt_Transferdemp = BLL.get_Transferedemp(_obj_Emptransfer);
            rg_Emptransfer.DataSource = Dt_Transferdemp;


            //code for security
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                for (int i = 0; i < rg_Emptransfer.Items.Count; i++)
                {
                    LinkButton lnkdel = new LinkButton();
                    lnkdel = (LinkButton)rg_Emptransfer.Items[i].FindControl("lnkbtn_Rollback") as LinkButton;
                    lnkdel.Visible = false;

                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpTransfer", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    #endregion

    #region Redirect
    /// <summary>
    /// for navigating the pages from one pageview to other by clearing the controls
    /// of the existed one
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearcontrols();
            //_obj_Emptransfer.EMP_REPORTINGEMPLOYEE = Convert.ToInt32(rcmb_Reportingemp.SelectedValue.ToString());
            RM_Transfer.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpTransfer", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    #region ClearControls
    /// <summary>
    /// this will clear the contrils when we move from one page to other page
    /// </summary>
    private void clearcontrols()
    {
        try
        {
            rcmb_Bu.Visible = true;
            rtxt_Basic.Text = string.Empty;
            //rntxt_Gross.Text = string.Empty;
            rcmb_Currencytype.Items.Clear();
            rcmb_Businessunit.Items.Clear();
            rcmb_Directorate.Items.Clear();
            rcmb_Department.Items.Clear();
            rcmb_Leavestruct.Items.Clear();
            rcmb_BusinessunitReportingemp.Items.Clear();
            rcmb_Salstruct.Items.Clear();
            //rbtnlst_Coform.Controls.Clear();
            rbtnlst_Coform.SelectedIndex = -1;
            rcmb_Shifts.Items.Clear();
            rdtp_DOC.SelectedDate = null;
            rdtp_DOJ.SelectedDate = null;
            rdtp_Executiondate.SelectedDate = null;
            rdtp_Reportingdate.SelectedDate = null;
            lbl_Businessunitdesc.Text = string.Empty;
            lbl_Departmentdesc.Text = string.Empty;
            lbl_Leavestructuredesc.Text = string.Empty;
            lbl_Reportingempdesc.Text = string.Empty;
            lbl_Shiftdesc.Text = string.Empty;
            lbl_Positiondesc.Text = "";
            rcmb_Position.Items.Clear();
            lbl_Grade_ID.Text = string.Empty;
            rcmb_Grade.Items.Clear();
            rcmb_Grade.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            lbl_Slab_ID.Text = string.Empty;
            rcmb_Slabs.Items.Clear();
            rtxt_LOS.Text = string.Empty;
            lbl_Salstructuredesc.Text = string.Empty;
            lbl_Grossdesc.Text = string.Empty;
            lbl_Basicdesc.Text = string.Empty;
            lbl_Currencydesc.Text = string.Empty;
            //lbl_empcode.Text = string.Empty;

            rdtp_Executiondate.MinDate = Convert.ToDateTime("01.01.1900");
            rcmbCategory.Items.Clear();
            lbl_category_from.Text = string.Empty;
            lbl_category_id.Text = string.Empty;
            lbl_Directorate_ID.Text = string.Empty;
            rcmb_Slabs.Enabled = true;
            rcmb_Grade.Enabled = true;
            rcmb_Grade.Items.Clear();
            rcmb_Grade.Items.Insert(0, new RadComboBoxItem("", ""));
            rcmb_Slabs.Items.Clear();
            rcmb_Slabs.Items.Insert(0, new RadComboBoxItem("", ""));
            rcmb_Directorate.Items.Clear();
            rcmb_Directorate.Items.Insert(0, new RadComboBoxItem("", ""));
            lbl_Grade_from.Text = string.Empty;
            lbl_Slab_From.Text = string.Empty;
            rcmb_Businessunit.Items.Clear();
            rcmb_Businessunit.Items.Insert(0, new RadComboBoxItem("", ""));
            rcmb_Department.Items.Clear();
            rcmb_Department.Items.Insert(0, new RadComboBoxItem("", ""));
            lbl_DirectorateDesc.Text = string.Empty;
            rcmb_Shifts.Items.Clear();
            rcmb_Shifts.Items.Insert(0, new RadComboBoxItem("", ""));
            rbtnlst_Coform.ClearSelection();
            rcmb_Businessunit.Items.Clear();
            rcmb_Businessunit.Items.Insert(0, new RadComboBoxItem("", ""));
            rcmb_Directorate.Items.Clear();
            rcmb_Directorate.Items.Insert(0, new RadComboBoxItem("", ""));
            rcmb_Department.Items.Clear();
            rcmb_Department.Items.Insert(0, new RadComboBoxItem("", ""));
            rcmb_Currencytype.Items.Clear();
            rcmb_Currencytype.Items.Insert(0, new RadComboBoxItem("", ""));
            rcmb_Leavestruct.Items.Clear();
            rcmb_Leavestruct.Items.Insert(0, new RadComboBoxItem("", ""));
            rcmb_Position.Items.Clear();
            rcmb_Position.Items.Insert(0, new RadComboBoxItem("", ""));
            rcmb_Salstruct.Items.Clear();
            rcmb_Salstruct.Items.Insert(0, new RadComboBoxItem("", ""));
            rcmb_Shifts.Items.Clear();
            rcmb_Shifts.Items.Insert(0, new RadComboBoxItem("", ""));
            rcmb_BusinessunitReportingemp.Items.Clear();
            rcmb_BusinessunitReportingemp.Items.Insert(0, new RadComboBoxItem("", ""));
            rcmb_Reportingemp.Items.Clear();
            rcmb_Reportingemp.Items.Insert(0, new RadComboBoxItem("", ""));
            rdtp_Executiondate.SelectedDate = null;
            rdtp_Executiondate.MinDate = Convert.ToDateTime("01.01.1900");
            rdtp_Reportingdate.SelectedDate = null;
            rcmbCategory.Items.Clear();
            rcmbCategory.Items.Insert(0, new RadComboBoxItem("", ""));
            lblJobFrom.Text = string.Empty;
            lblJobID.Text = string.Empty;
            lbl_financialperiod_id.Text = string.Empty;
            rcmb_Job.Items.Clear();
            rcmb_Job.Items.Insert(0, new RadComboBoxItem("", ""));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpTransfer", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

            return;
        }
    }

    private void enablecontrols()
    {
        try
        {
            rdtp_DOC.Enabled = false;
            rdtp_DOJ.Enabled = false;
            rtxt_LOS.Enabled = false;
            rcmb_Businessunit.Enabled = false;
            rcmb_Directorate.Enabled = false;
            rcmb_Department.Enabled = false;
            rcmb_BusinessunitReportingemp.Enabled = false;
            rcmb_Salstruct.Enabled = false;
            rcmb_Shifts.Enabled = false;
            rdtp_Reportingdate.Enabled = false;
            rcmb_Leavestruct.Enabled = false;
            rdtp_Executiondate.Enabled = false;
            rbtnlst_Coform.Enabled = false;
            lbl_Conform.Visible = false;
            rcmb_Position.Enabled = false;
            rcmb_Employees.Enabled = false;
            btn_Submit.Visible = false;
            rcmbCategory.Enabled = false;
            rcmb_Grade.Enabled = false;
            rcmb_Slabs.Enabled = false;
            rcmb_Job.Enabled = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpTransfer", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

            return;
        }
    }
    #endregion

    #region Loading Current Information
    /// <summary>
    /// loading the details of selected employee of that organisation
    /// </summary>
    /// <param name="o"></param>
    /// <param name="e"></param>
    protected void rcmb_Employees_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            clearcontrols();
            lnkbtn_Cancel_Click(o, e);
            rbtnlst_Coform.Enabled = true;

            rcmb_BusinessunitReportingemp.Visible = true;
            rcmb_BusinessunitReportingemp.Items.Clear();
            rcmb_Reportingemp.Enabled = true;
            if (rcmb_Employees.SelectedIndex != 0)
            {
                _obj_Emptransfer.EMP_EMPID = Convert.ToInt32(rcmb_Employees.SelectedValue.ToString());
                _obj_Emptransfer.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                Dt_loadcombos = BLL.get_Employeelist(_obj_Emptransfer);
                if (Dt_loadcombos.Rows.Count > 0)
                {
                    rdtp_DOJ.SelectedDate = Convert.ToDateTime(Dt_loadcombos.Rows[0]["EMP_DOJ"].ToString());
                    rtxt_LOS.Text = Dt_loadcombos.Rows[0]["LENGTHOFEXPERIENCE"].ToString();
                    lbl_Businessunitdesc.Text = Dt_loadcombos.Rows[0]["BUSINESSUNIT_CODE"].ToString();
                    lbl_DirectorateDesc.Text = Dt_loadcombos.Rows[0]["DIRECTORATE_CODE"].ToString();
                    lbl_Departmentdesc.Text = Dt_loadcombos.Rows[0]["DEPARTMENT_NAME"].ToString();
                    lbl_Leavestructuredesc.Text = Dt_loadcombos.Rows[0]["LEAVESTRUCT_CODE"].ToString();
                    lbl_Reportingempdesc.Text = Dt_loadcombos.Rows[0]["REPORTING_EMPNAME"].ToString();
                    lbl_Salstructuredesc.Text = Dt_loadcombos.Rows[0]["SALARYSTRUCT_CODE"].ToString();
                    //double BALANCED = Convert.ToDouble(Dt_loadcombos.Rows[0].ItemArray[12].ToString());
                    //Session["Balanced"] = BALANCED;
                    lbl_Shiftdesc.Text = Dt_loadcombos.Rows[0]["SHIFT_CODE"].ToString();
                    lblJobFrom.Text = Dt_loadcombos.Rows[0]["JOBS_CODE"].ToString();
                    lblJobID.Text = Dt_loadcombos.Rows[0]["JOBS_ID"].ToString();
                    lbl_Positiondesc.Text = Dt_loadcombos.Rows[0]["POSITIONS_CODE"].ToString();
                    lbl_FinancialPeriod.Text = Dt_loadcombos.Rows[0]["PERIOD_NAME"].ToString();
                    lbl_financialperiod_id.Text = Dt_loadcombos.Rows[0]["PERIOD_ID"].ToString();

                    lbl_Grade_ID.Text = Dt_loadcombos.Rows[0]["EMPLOYEEGRADE_ID"].ToString();
                    lbl_Grade_from.Text = Dt_loadcombos.Rows[0]["EMPLOYEEGRADE_CODE"].ToString();
                    lbl_Slab_ID.Text = Dt_loadcombos.Rows[0]["EMPLOYEEGRADE_SLAB_SRNO"].ToString();

                    Double x;
                    x = Convert.ToDouble(Dt_loadcombos.Rows[0]["EMPLOYEEGRADE_SLAB_AMOUNT"]);
                    lbl_Slab_From.Text = x.ToString("0.00");

                    // lbl_Slab_From.Text = Dt_loadcombos.Rows[0]["EMPLOYEEGRADE_SLAB_AMOUNT"].ToString();
                    Double x1;
                    x1 = Convert.ToDouble(Dt_loadcombos.Rows[0]["EMP_BASIC"]);
                    lbl_Basicdesc.Text = x1.ToString("0.00");
                    //lbl_Basicdesc.Text = Dt_loadcombos.Rows[0]["EMP_BASIC"].ToString();
                    lbl_Grossdesc.Text = Dt_loadcombos.Rows[0]["EMP_GROSSSAL"].ToString();
                    lbl_Currencydesc.Text = Dt_loadcombos.Rows[0]["CURR_SYMBOL"].ToString();
                    Session["LEAVESTRUCT"] = Dt_loadcombos.Rows[0]["EMP_LEAVESTRUCT_ID"].ToString();

                    lbl_Businessunitid.Text = Dt_loadcombos.Rows[0]["EMP_BUSINESSUNIT_ID"].ToString();
                    lbl_Departmentid.Text = Dt_loadcombos.Rows[0]["EMP_DEPARTMENT_ID"].ToString();

                    lbl_Leavestructid.Text = Dt_loadcombos.Rows[0]["EMP_LEAVESTRUCT_ID"].ToString();
                    lbl_Salarystructid.Text = Dt_loadcombos.Rows[0]["SALARYSTRUCT_ID"].ToString();
                    lbl_Positionid.Text = Dt_loadcombos.Rows[0]["EMP_DESIGNATION_ID"].ToString();
                    lbl_Shiftid.Text = Dt_loadcombos.Rows[0]["SHIFT_ID"].ToString();
                    lbl_Reportingempid.Text = Dt_loadcombos.Rows[0]["EMP_REPORTINGEMPLOYEE"].ToString();
                    lbl_Currencyid.Text = Dt_loadcombos.Rows[0]["CURR_ID"].ToString();
                    if (Dt_loadcombos.Rows[0]["CATEGORY"] != System.DBNull.Value)
                        lbl_category_from.Text = Convert.ToString(Dt_loadcombos.Rows[0]["CATEGORY"]);
                    else
                        lbl_category_from.Text = string.Empty;
                    if (Dt_loadcombos.Rows[0]["EMP_CATEGORY_ID"] != System.DBNull.Value)
                        lbl_category_id.Text = Convert.ToString(Dt_loadcombos.Rows[0]["EMP_CATEGORY_ID"]);
                    else
                        lbl_category_id.Text = string.Empty;
                    if (Dt_loadcombos.Rows[0]["EMP_DIRECTORATE_ID"] != System.DBNull.Value)
                        lbl_Directorate_ID.Text = Convert.ToString(Dt_loadcombos.Rows[0]["EMP_DIRECTORATE_ID"]);
                    else
                        lbl_Directorate_ID.Text = string.Empty;
                    rcmb_Businessunit.Enabled = true;
                    rcmb_Directorate.Enabled = true;
                    rcmb_Department.Enabled = true;
                    rcmb_BusinessunitReportingemp.Enabled = true;
                    rcmb_Salstruct.Enabled = true;
                    rcmb_Shifts.Enabled = true;
                    rdtp_Reportingdate.Enabled = true;
                    rcmb_Leavestruct.Enabled = true;
                    rdtp_Executiondate.Enabled = true;
                    rbtnlst_Coform.Visible = true;
                    rbtnlst_Coform.Enabled = true;
                    rcmb_Position.Enabled = true;
                    btn_Submit.Visible = true;
                    //rntxt_Gross.Enabled = true;
                    lnkbtn_Check.Enabled = true;
                    rcmbCategory.Enabled = true;
                    rcmb_Job.Enabled = true;

                    string CHECK = Dt_loadcombos.Rows[0].ItemArray[14].ToString();
                    if (CHECK == string.Empty)
                    {
                        rdtp_DOC.SelectedDate = Convert.ToDateTime(Dt_loadcombos.Rows[0].ItemArray[13].ToString());
                    }
                    else
                    {
                        rdtp_DOC.SelectedDate = Convert.ToDateTime(Dt_loadcombos.Rows[0].ItemArray[14].ToString());
                    }
                    rdtp_Executiondate.MinDate = Convert.ToDateTime(Dt_loadcombos.Rows[0]["EMP_DOJ"]);

                    load_businessunit();

                }
                else
                {
                    rbtnlst_Coform.Visible = true;
                    BLL.ShowMessage(this, "Employee Information Is Not Found!");
                    lnkbtn_Check.Enabled = false;
                }
            }
            else
            {
                BLL.ShowMessage(this, "Select a employee!");
                lnkbtn_Check.Enabled = false;
                clearcontrols();
                rbtnlst_Coform.ClearSelection();
                rcmb_Businessunit.Items.Clear();
                rcmb_Businessunit.Items.Insert(0, new RadComboBoxItem("", ""));
                rcmb_Directorate.Items.Clear();
                rcmb_Directorate.Items.Insert(0, new RadComboBoxItem("", ""));
                rcmb_Department.Items.Clear();
                rcmb_Department.Items.Insert(0, new RadComboBoxItem("", ""));
                rcmb_Currencytype.Items.Clear();
                rcmb_Currencytype.Items.Insert(0, new RadComboBoxItem("", ""));
                rcmb_Leavestruct.Items.Clear();
                rcmb_Leavestruct.Items.Insert(0, new RadComboBoxItem("", ""));
                rcmb_Position.Items.Clear();
                rcmb_Position.Items.Insert(0, new RadComboBoxItem("", ""));
                rcmb_Salstruct.Items.Clear();
                rcmb_Salstruct.Items.Insert(0, new RadComboBoxItem("", ""));
                rcmb_Shifts.Items.Clear();
                rcmb_Shifts.Items.Insert(0, new RadComboBoxItem("", ""));
                rcmb_BusinessunitReportingemp.Items.Clear();
                rcmb_BusinessunitReportingemp.Items.Insert(0, new RadComboBoxItem("", ""));
                rcmb_Reportingemp.Items.Clear();
                rcmb_Reportingemp.Items.Insert(0, new RadComboBoxItem("", ""));
                rdtp_Executiondate.SelectedDate = null;
                rdtp_Executiondate.MinDate = Convert.ToDateTime("01.01.1900");
                rdtp_Reportingdate.SelectedDate = null;
                rcmbCategory.Items.Clear();
                rcmbCategory.Items.Insert(0, new RadComboBoxItem("", ""));
                //loadcombos();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpTransfer", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion



    private void LoadPeriod()
    {
        try
        {
            rcmb_period.Items.Clear();
            SMHR_PERIOD PRD = new SMHR_PERIOD();
            PRD.OPERATION = operation.PERIOD;
            PRD.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT = new DataTable();
            DT = BLL.GetEmployeePeriod(PRD);

            if (DT.Rows.Count > 0)
            {
                rcmb_period.DataSource = DT;
                rcmb_period.DataTextField = "PERIOD_NAME";
                rcmb_period.DataValueField = "PERIOD_ID";
                rcmb_period.DataBind();
            }
            rcmb_period.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpTransfer", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #region Loading Business Units

    private void Load_Directorate()
    {
        try
        {
            rcmb_Directorate.Items.Clear();

            if (Convert.ToString(Session["ORG_ID"]) != string.Empty)
            {
                //Load Directorate
                SMHR_DIRECTORATE _obj_Smhr_Directorate = new SMHR_DIRECTORATE();
                _obj_Smhr_Directorate.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_Directorate.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_Businessunit.SelectedValue);
                DataTable DT = BLL.get_Directorate(_obj_Smhr_Directorate);
                rcmb_Directorate.DataTextField = "DIRECTORATE_CODE";
                rcmb_Directorate.DataValueField = "DIRECTORATE_ID";
                rcmb_Directorate.DataSource = DT;
                rcmb_Directorate.DataBind();
                rcmb_Directorate.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpTransfer", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void load_businessunit()
    {
        try
        {
            rcmb_Businessunit.Items.Clear();
            //rcmb_Bu.Items.Clear();
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            if (Convert.ToString(Session["ORG_ID"]) != string.Empty)
            {
                _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                _obj_SMHR_LoginInfo.BUID = Convert.ToInt32(rcmb_Bu.SelectedValue.ToString());
                DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
                for (int row = 0; dt_BUDetails.Rows.Count > row; row++)
                {
                    if (dt_BUDetails.Rows[row]["BUSINESSUNIT_ID"].ToString() == Convert.ToString(_obj_SMHR_LoginInfo.BUID))
                    {
                        dt_BUDetails.Rows.RemoveAt(row);
                        break;
                    }
                }
                rcmb_Businessunit.DataSource = dt_BUDetails;
                rcmb_Businessunit.DataTextField = "BUSINESSUNIT_CODE";
                rcmb_Businessunit.DataValueField = "BUSINESSUNIT_ID";
                rcmb_Businessunit.DataBind();
                rcmb_Businessunit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));


            }
            else
            {
                Response.Redirect("~/Login.aspx", false);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpTransfer", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

        }
    }

    #endregion

    #region On Businessunit Selection
    /// <summary>
    /// this method is for filling the all combos of the current form when ever businessunit is selected
    /// based on the organisation of the business unit we will display the complete details
    /// </summary>
    /// <param name="o"></param>
    /// <param name="e"></param>
    protected void rcmb_Businessunit_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            //string Maxdate = "";
            rcmb_BusinessunitReportingemp.Items.Clear();
            rcmb_Position.Items.Clear();
            rcmb_Leavestruct.Items.Clear();
            rcmb_Shifts.Items.Clear();
            rcmb_Salstruct.Items.Clear();
            rcmbCategory.Items.Clear();
            _obj_Emptransfer.OPERATION = operation.Check;
            rtxt_Basic.Text = "";
            //rntxt_Gross.Text = ""; 
            rcmb_Reportingemp.Items.Clear();
            rcmb_BusinessunitReportingemp.Items.Clear();
            if (rcmb_Businessunit.SelectedIndex > 0)
            {
                _obj_Emptransfer.BUID = Convert.ToInt32(rcmb_Businessunit.SelectedValue.ToString());
                if (Convert.ToString(Session["ORG_ID"]) != string.Empty)
                {
                    //To populate jobs
                    rcmb_Job.Items.Clear();
                    SMHR_JOBS _obj_Jobs = new SMHR_JOBS();
                    _obj_Jobs.OPERATION = operation.Get;
                    _obj_Jobs.BUID = Convert.ToInt32(rcmb_Businessunit.SelectedValue);
                    _obj_Jobs.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable DT = BLL.get_Jobs(_obj_Jobs);
                    rcmb_Job.DataSource = DT;
                    rcmb_Job.DataTextField = "JOBS_CODE";
                    rcmb_Job.DataValueField = "JOBS_ID";
                    rcmb_Job.DataBind();
                    rcmb_Job.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

                    rcmb_Position.Items.Clear();
                    rcmb_Position.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

                    //SMHR_POSITIONS _obj_smhr_positions = new SMHR_POSITIONS();
                    //_obj_smhr_positions.OPERATION = operation.Select;
                    //_obj_smhr_positions.JOBLOC_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_Businessunit.SelectedValue);
                    //_obj_smhr_positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    //DataTable dtPos = BLL.get_BUPositions(_obj_smhr_positions);
                    //rcmb_Position.DataSource = dtPos;
                    //rcmb_Position.DataTextField = "POSITIONS_CODE";
                    //rcmb_Position.DataValueField = "POSITIONS_ID";
                    //rcmb_Position.DataBind();
                    //rcmb_Position.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

                    _obj_Emptransfer.EMP_ORG_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                    //Dt_loadcombos = BLL.get_businessunitdetails(_obj_Emptransfer);
                    //rcmb_Position.DataSource = Dt_loadcombos;
                    //rcmb_Position.DataTextField = "POSITIONS_CODE";
                    //rcmb_Position.DataValueField = "POSITIONS_ID";
                    //rcmb_Position.DataBind();
                    //rcmb_Position.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                    //Dt_loadcombos = null;
                    rcmb_Grade.Enabled = true;
                    rcmb_Grade.ClearSelection();
                    rcmb_Grade.Items.Clear();
                    rcmb_Grade.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                    rcmb_Slabs.Text = string.Empty;
                    rcmb_Slabs.ClearSelection();
                    rcmb_Slabs.Items.Clear();
                    rcmb_Slabs.Text = string.Empty;


                    _obj_Emptransfer.EMP_SALALRYSTRUCT_ID = 1;
                    _obj_Emptransfer.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    Dt_loadcombos = BLL.get_Departments(_obj_Emptransfer);
                    rcmb_Salstruct.DataSource = Dt_loadcombos;
                    rcmb_Salstruct.DataTextField = "SALARYSTRUCT_CODE";
                    rcmb_Salstruct.DataValueField = "SALARYSTRUCT_ID";
                    rcmb_Salstruct.DataBind();
                    rcmb_Salstruct.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                    _obj_Emptransfer.EMP_SALALRYSTRUCT_ID = 0;
                    Dt_loadcombos = null;

                    _obj_Emptransfer.EMP_SHIFT_ID = 1;
                    _obj_Emptransfer.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    Dt_loadcombos = BLL.get_Departments(_obj_Emptransfer);
                    rcmb_Shifts.DataSource = Dt_loadcombos;
                    rcmb_Shifts.DataTextField = "SHIFT_CODE";
                    rcmb_Shifts.DataValueField = "SHIFT_ID";
                    rcmb_Shifts.DataBind();
                    rcmb_Shifts.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                    _obj_Emptransfer.EMP_SHIFT_ID = 0;
                    Dt_loadcombos = null;

                    _obj_Emptransfer.EMP_LEAVESTRUCT_ID = 1;
                    _obj_Emptransfer.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    Dt_loadcombos = BLL.get_Departments(_obj_Emptransfer);
                    rcmb_Leavestruct.DataSource = Dt_loadcombos;
                    rcmb_Leavestruct.DataTextField = "LEAVESTRUCT_CODE";
                    rcmb_Leavestruct.DataValueField = "EMP_LEAVESTRUCT_ID";
                    rcmb_Leavestruct.DataBind();
                    rcmb_Leavestruct.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                    _obj_Emptransfer.EMP_LEAVESTRUCT_ID = 0;
                    Dt_loadcombos = null;

                    //_obj_Emptransfer.EMP_DEPARTMENT_ID = 1;
                    //_obj_Emptransfer.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    //Dt_loadcombos = BLL.get_Departments(_obj_Emptransfer);
                    //rcmb_Department.DataSource = Dt_loadcombos;
                    //rcmb_Department.DataTextField = "DEPARTMENT_NAME";
                    //rcmb_Department.DataValueField = "EMP_DEPARTMENT_ID";
                    //rcmb_Department.DataBind();
                    //rcmb_Department.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                    //_obj_Emptransfer.EMP_DEPARTMENT_ID = 0;
                    Dt_loadcombos = null;

                    Load_Directorate();

                    _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                    DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
                    rcmb_BusinessunitReportingemp.DataSource = dt_BUDetails;
                    rcmb_BusinessunitReportingemp.DataTextField = "BUSINESSUNIT_CODE";
                    rcmb_BusinessunitReportingemp.DataValueField = "BUSINESSUNIT_ID";
                    rcmb_BusinessunitReportingemp.DataBind();
                    rcmb_BusinessunitReportingemp.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

                    rcmb_Currencytype.Visible = true;
                    rtxt_Currency.Visible = false;
                    _obj_Emptransfer.BUID = Convert.ToInt32(rcmb_Businessunit.SelectedValue.ToString());
                    _obj_Emptransfer.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    Dt_loadcombos = BLL.get_Departments(_obj_Emptransfer);
                    rcmb_Currencytype.DataSource = Dt_loadcombos;
                    rcmb_Currencytype.DataTextField = "CURR_SYMBOL";
                    rcmb_Currencytype.DataValueField = "CURR_ID";
                    rcmb_Currencytype.DataBind();
                    rcmb_Currencytype.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                    rcmb_BusinessunitReportingemp_SelectedIndexChanged(null, null);


                    DataTable DT_reportingemp = new DataTable();
                    rcmb_Reportingemp.Items.Clear();
                    _obj_Emptransfer.OPERATION = operation.Check1;
                    _obj_Emptransfer.BUID = Convert.ToInt32(rcmb_Businessunit.SelectedValue.ToString());
                    _obj_Emptransfer.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DT_reportingemp = BLL.get_Reportingemployees(_obj_Emptransfer);
                    ViewState["REPORTING_EMPLOYEES"] = DT_reportingemp;
                    rcmb_Reportingemp.DataSource = DT_reportingemp;
                    rcmb_Reportingemp.DataTextField = "EMP_REPOTRINGEMPNAME";
                    rcmb_Reportingemp.DataValueField = "REPORTING_EMPLOYEE_ID";
                    rcmb_Reportingemp.DataBind();
                    rcmb_Reportingemp.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));


                    //Employee Category
                    //rcmbCategory.Items.Clear();
                    //SMHR_MASTERS _obj_smhr_Master = new SMHR_MASTERS();
                    //_obj_smhr_Master.MASTER_TYPE = "CATEGORY";
                    //_obj_smhr_Master.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    //_obj_smhr_Master.OPERATION = operation.Select;
                    //DataTable dtCategory = BLL.get_MasterRecords(_obj_smhr_Master);
                    //if (dtCategory.Rows.Count > 0)
                    //{
                    //    rcmbCategory.DataSource = dtCategory;
                    //    rcmbCategory.DataTextField = "HR_MASTER_CODE";
                    //    rcmbCategory.DataValueField = "HR_MASTER_ID";
                    //    rcmbCategory.DataBind();
                    //    rcmbCategory.Items.Insert(0, new RadComboBoxItem("Select", "0"));
                    //}

                    //DataTable dt_executiondate = new DataTable();
                    //_obj_Emptransfer.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    //_obj_Emptransfer.BUID = Convert.ToInt32(rcmb_Businessunit.SelectedValue.ToString());
                    //dt_executiondate = BLL.GET_LASTPAYROLL(_obj_Emptransfer);
                    //if (dt_executiondate.Rows.Count > 0)
                    //{
                    //    rdtp_Executiondate.MinDate = Convert.ToDateTime(dt_executiondate.Rows[0]["MINDATE"].ToString());                                              
                    //    Maxdate = Convert.ToString(dt_executiondate.Rows[0]["PAYTRAN_DTLID"].ToString());
                    //    dt_executiondate = null;
                    //    _obj_Emptransfer.CREATEDBY = 1;
                    //    _obj_Emptransfer.BUID = Convert.ToInt32(rcmb_Businessunit.SelectedValue.ToString());
                    //    _obj_Emptransfer.MODE = Convert.ToInt32(Maxdate);
                    //    dt_executiondate = BLL.GET_LASTPAYROLL(_obj_Emptransfer);
                    //    DateTime min = rdtp_Executiondate.MinDate;
                    //    DateTime max = Convert.ToDateTime(dt_executiondate.Rows[0]["DATE"].ToString());
                    //    //DateTime diff = Convert.ToDateTime(max - min);
                    //    if (max > min)
                    //        rdtp_Executiondate.MaxDate = Convert.ToDateTime(dt_executiondate.Rows[0]["DATE"].ToString());
                    //    else
                    //        rdtp_Executiondate.MaxDate = DateTime.Now;
                    //}
                    //else
                    //{
                    //    string S = "Payroll is not Processed for the Selected Businessunit ";
                    //    string Sa = "so, there is no validation for the execution date ";
                    //    string msg = S + " " + Sa;
                    //    BLL.ShowMessage(this, msg);
                    //}

                }
                else
                {
                    Response.Redirect("~/Login.aspx", false);
                }
            }
            else
            {
                BLL.ShowMessage(this, "Select A Businessunit");
                rcmb_Currencytype.Items.Clear();
                rcmb_Department.Items.Clear();
                rcmb_Department.Items.Insert(0, new RadComboBoxItem("", ""));
                rcmb_Currencytype.Items.Insert(0, new RadComboBoxItem("", ""));
                rcmb_Leavestruct.Items.Clear();
                rcmb_Leavestruct.Items.Insert(0, new RadComboBoxItem("", ""));
                rcmb_Position.Items.Clear();
                rcmb_Position.Items.Insert(0, new RadComboBoxItem("", ""));
                rcmb_Shifts.Items.Clear();
                rcmb_Salstruct.Items.Clear();
                rcmb_Salstruct.Items.Insert(0, new RadComboBoxItem("", ""));
                rcmb_Shifts.Items.Insert(0, new RadComboBoxItem("", ""));
                rcmb_BusinessunitReportingemp.Items.Clear();
                rcmb_BusinessunitReportingemp.Items.Insert(0, new RadComboBoxItem("", ""));
                rcmb_Reportingemp.Items.Clear();
                rcmb_Reportingemp.Items.Insert(0, new RadComboBoxItem("", ""));
                rcmbCategory.Items.Clear();
                rcmbCategory.Items.Insert(0, new RadComboBoxItem("", ""));
                rcmb_Businessunit.Focus();
                rbtnlst_Coform.ClearSelection();
                rdtp_Executiondate.SelectedDate = null;
                rdtp_Reportingdate.SelectedDate = null;
                //rcmb_Grade
                //rcmb_period.Items.Clear();
                //rcmb_period.Text = string.Empty;
                //rcmb_period.Items.Insert(0, new RadComboBoxItem("0", "Select"));
                rcmb_period.SelectedIndex = 0;
                rcmb_Grade.Items.Clear();
                rcmb_Grade.Items.Insert(0, new RadComboBoxItem("", ""));
                rcmb_Slabs.Items.Clear();
                rcmb_Slabs.Items.Insert(0, new RadComboBoxItem("", ""));
                rcmb_Directorate.Items.Clear();
                rcmb_Directorate.Items.Insert(0, new RadComboBoxItem("", ""));
                rcmb_Job.Items.Clear();
                rcmb_Job.Items.Insert(0, new RadComboBoxItem("", ""));
                //rcmb_Directorate
                //rcmb_Businessunit.Enabled = false;
                //rcmb_Department.Enabled = false;
                //rcmb_BusinessunitReportingemp.Enabled = false;
                //rcmb_Salstruct.Enabled = false;
                //rcmb_Shifts.Enabled = false;
                //rdtp_Reportingdate.Enabled = false;
                //rcmb_Leavestruct.Enabled = false;
                //rdtp_Executiondate.Enabled = false;
                //rbtnlst_Coform.Enabled = false;
                //rcmb_Position.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpTransfer", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

            return;
        }
    }
    #endregion

    protected void rcmb_Position_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            //Load Scales
            //rcmb_Grade.Items.Clear();
            rcmb_Grade.Text = string.Empty;
            rcmb_Slabs.Items.Clear();
            rcmb_Slabs.Text = string.Empty;
            // rntxt_Gross.Text = string.Empty;
            rtxt_Basic.Text = string.Empty;

            //if (rcmb_Position.SelectedIndex > 0 && string.Compare(lbl_Positionid.Text, rcmb_Position.SelectedValue, true) != 0)

            //to validate position

            if (rcmb_period.SelectedIndex <= 0)
            {
                BLL.ShowMessage(this, "Please Select Financial Period");
                rcmb_period.Focus();
                rcmb_Position.SelectedIndex = -1;
                return;
            }
            if (rcmb_Position.SelectedIndex > 0)
            {
                SMHR_POSITIONS _obj_smhr_positions = new SMHR_POSITIONS();
                _obj_smhr_positions.POSITIONS_ID = Convert.ToInt32(rcmb_Position.SelectedValue);
                _obj_smhr_positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_smhr_positions.POSITIN_PERIOD_ID = Convert.ToInt32(rcmb_period.SelectedValue);
                _obj_smhr_positions.OPERATION = operation.GETVACANCY;
                DataTable dtVacancy = BLL.get_Positions(_obj_smhr_positions);
                if (Convert.ToInt32(dtVacancy.Rows[0][0]) == 0)
                {
                    rcmb_Position.SelectedIndex = -1;
                    BLL.ShowMessage(this, "Establishment not done for this position");
                }
                //else if (Convert.ToInt32(dtVacancy.Rows[0][0]) == 1)
                //{
                //    rcmb_Position.SelectedIndex = -1;
                //    BLL.ShowMessage(this, "Establishment not finalised for this position");
                //}
                else if (Convert.ToInt32(dtVacancy.Rows[0][0]) == 3)
                {
                    rcmb_Position.SelectedIndex = -1;
                    BLL.ShowMessage(this, "There is no vacancy for this position");
                }
                /*else
                {
                    ////Load Scales
                    //rcmb_Grade.Items.Clear();
                    //rcmb_Grade.Text = string.Empty;
                    //rcmb_Slabs.Items.Clear();
                    //rcmb_Slabs.Text = string.Empty;
                    ////rntxt_Gross.Text = string.Empty;
                    //rtxt_Basic.Text = string.Empty;

                    SMHR_POSITIONS _obj_smhr_position = new SMHR_POSITIONS();
                    _obj_smhr_position.OPERATION = operation.POSITIONSGRADE;
                    _obj_smhr_position.POSITIONS_ID = Convert.ToInt32(rcmb_Position.SelectedValue);
                    _obj_smhr_position.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtPos = BLL.get_Positions(_obj_smhr_position);
                    if (dtPos.Rows.Count > 0)
                    {
                        rcmb_Grade.DataSource = dtPos;
                        rcmb_Grade.DataTextField = "CODERANK";
                        rcmb_Grade.DataValueField = "EMPLOYEEGRADE_ID";
                        rcmb_Grade.DataBind();
                        rcmb_Grade.Enabled = false;

                        rcmb_Slabs.Items.Clear();
                        rcmb_Slabs.DataValueField = "EMPLOYEEGRADE_SLAB_ID"; //"EMPLOYEEGRADE_SLAB_SRNO";
                        rcmb_Slabs.DataTextField = "EMPLOYEEGRADE_SLAB_AMOUNT";
                        rcmb_Slabs.DataSource = LoadSalarySlabs();
                        rcmb_Slabs.DataBind();
                        //rcmb_Slabs.Items.Insert(0, new RadComboBoxItem { Text = "Select", Value = "0" });
                        rcmb_Slabs.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

                    }
                }*/
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpTransfer", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

            return;
        }

    }
    #region Transfer Employee
    /// <summary>
    /// this will update the businessunit and all other information related to the employee
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            if (rcmb_Shifts.SelectedIndex <= 0)
            {
                BLL.ShowMessage(this, "Please Select Shift");
                rcmb_Shifts.Focus();
                return;
            }
            else if (rcmb_Salstruct.SelectedIndex <= 0)
            {
                BLL.ShowMessage(this, "Please Select Salary Structure");
                rcmb_Salstruct.Focus();
                return;
            }
            else if (rcmb_Leavestruct.SelectedIndex <= 0)
            {
                BLL.ShowMessage(this, "Please Select Leave Structure");
                rcmb_Leavestruct.Focus();
                return;
            }
            else if (rcmb_Currencytype.SelectedIndex <= 0)
            {
                BLL.ShowMessage(this, "Please Select Currency");
                rcmb_Currencytype.Focus();
                return;
            }
            else if (rcmb_Job.SelectedIndex <= 0)
            {
                BLL.ShowMessage(this, "Please Select Job");
                rcmb_Position.Focus();
                return;
            }
            else if (rcmb_Position.SelectedIndex <= 0)
            {
                BLL.ShowMessage(this, "Please Select Position");
                rcmb_Position.Focus();
                return;
            }
            else if (rcmb_Slabs.SelectedIndex <= 0)
            {
                BLL.ShowMessage(this, "Please Select Salary Slab");
                rcmb_Slabs.Focus();
                return;
            }
            //if (((rcmb_Department.SelectedIndex) != 0) && 
            if ((rcmb_Leavestruct.SelectedIndex != 0) && (rcmb_Position.SelectedIndex != 0) && (rcmb_Shifts.SelectedIndex != 0)
            && (rcmb_Currencytype.SelectedIndex != 0) && (rcmb_Slabs.SelectedIndex != 0))
            {
                SMHR_EMPLOYEE _obj_SMHR_EMPLOYEE = new SMHR_EMPLOYEE();
                _obj_SMHR_EMPLOYEE.OPERATION = operation.Check_Emp;

                _obj_SMHR_EMPLOYEE.EMP_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_Businessunit.SelectedItem.Value);

                _obj_SMHR_EMPLOYEE.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_Check = BLL.get_Employee(_obj_SMHR_EMPLOYEE);
                if (dt_Check.Rows.Count > 0)
                {
                    if (!(Convert.ToInt32(dt_Check.Rows[0][0]) > 0))
                    {
                        if ((lbl_Departmentdesc.Text != rcmb_Department.SelectedItem.Text) || (rcmb_Businessunit.SelectedItem.Text != lbl_Businessunitdesc.Text))
                        {
                            lnkbtn_Cancel_Click(sender, e);
                            _obj_Emptransfer.EMP_EMPID = Convert.ToInt32(rcmb_Employees.SelectedValue.ToString());
                            _obj_Emptransfer.EMP_DESIGNATION_ID = Convert.ToInt32(rcmb_Position.SelectedValue.ToString());
                            _obj_Emptransfer.EMP_EXECUTIONDATE = Convert.ToDateTime(rdtp_Executiondate.SelectedDate);
                            _obj_Emptransfer.EMP_LEAVESTRUCT_ID = Convert.ToInt32(rcmb_Leavestruct.SelectedValue.ToString());
                            _obj_Emptransfer.EMP_SALALRYSTRUCT_ID = Convert.ToInt32(rcmb_Salstruct.SelectedValue.ToString());
                            _obj_Emptransfer.EMP_SHIFT_ID = Convert.ToInt32(rcmb_Shifts.SelectedValue.ToString());
                            //_obj_Emptransfer.STARTDATE = Convert.ToDateTime(rdtp_Reportingdate.SelectedDate);
                            if (rdtp_Reportingdate.SelectedDate != null)
                            {
                                _obj_Emptransfer.STARTDATE = Convert.ToDateTime(rdtp_Reportingdate.SelectedDate);
                            }

                            if (rcmb_Reportingemp.SelectedIndex > 0)
                            {
                                _obj_Emptransfer.EMP_REPORTINGEMPLOYEE = Convert.ToInt32(rcmb_Reportingemp.SelectedValue.ToString());
                            }
                            else
                            {
                                _obj_Emptransfer.EMP_REPORTINGEMPLOYEE = 0;
                            }
                            _obj_Emptransfer.BUID = Convert.ToInt32(rcmb_Businessunit.SelectedValue.ToString());
                            if (rcmb_Department.SelectedIndex != 0)
                            {

                                _obj_Emptransfer.EMP_DEPARTMENT_ID = Convert.ToInt32(rcmb_Department.SelectedValue.ToString());
                            }
                            _obj_Emptransfer.EMP_Directorate_ID = Convert.ToInt32(rcmb_Directorate.SelectedValue.ToString());
                            _obj_Emptransfer.EMP_OLDLEAVESTRUCT = lbl_Leavestructuredesc.Text;
                            _obj_Emptransfer.OPERATION = operation.Insert;
                            //_obj_Emptransfer.EMP_LEAVEBALANCE = Convert.ToInt32(Session["Leaves"]);
                            // _obj_Emptransfer.EMP_DATEOFTRANSFER = DateTime.Now;
                            _obj_Emptransfer.EMP_LEAVESTRUCTS_ID = Convert.ToInt32(Session["LEAVESTRUCT"]);

                            _obj_Emptransfer.EMP_OLDSHIFT = lbl_Shiftid.Text;
                            _obj_Emptransfer.EMP_OLDSALSTRUCT = lbl_Salarystructid.Text;
                            if (lbl_Reportingempid.Text != "")
                            {
                                _obj_Emptransfer.EMP_OLDREPORTINGEMP = lbl_Reportingempid.Text;
                            }
                            else
                            {
                                _obj_Emptransfer.EMP_OLDREPORTINGEMP = "0";
                            }
                            _obj_Emptransfer.EMP_OLDDESIGNATION = lbl_Positionid.Text;
                            _obj_Emptransfer.EMP_OLDDEPARTMENT = lbl_Departmentid.Text;
                            _obj_Emptransfer.EMP_OLDBU = lbl_Businessunitid.Text;
                            _obj_Emptransfer.EMP_PREVIOUS_CURRID = Convert.ToInt32(lbl_Currencyid.Text);
                            _obj_Emptransfer.EMP_CURR_ID = Convert.ToInt32(rcmb_Currencytype.SelectedValue.ToString());
                            //_obj_Emptransfer.EMP_GROSSSAL = Convert.ToDouble(rntxt_Gross.Text);
                            //_obj_Emptransfer.EMP_GROSSSAL = Convert.ToDouble(rtxt_Basic.Text);
                            if (rtxt_Basic.Text != string.Empty)
                            {
                                //string[] str = Convert.ToString(rcmb_Slabs.Text).Replace(" )", "").Split('(');
                                string[] str = Convert.ToString(rcmb_Slabs.Text).Replace(" )", "").Replace(")", "").Split('(');
                                _obj_Emptransfer.EMP_GROSSSAL = Convert.ToDouble(str[1].Trim());
                                //_obj_Emptransfer.EMP_BASIC = _obj_Emptransfer.EMP_GROSSSAL;
                                _obj_Emptransfer.EMP_BASIC = Convert.ToDouble(rtxt_Basic.Text);
                            }
                            else
                            {
                                _obj_Emptransfer.EMP_GROSSSAL = 0;
                                _obj_Emptransfer.EMP_BASIC = 0;
                            }
                            //_obj_Emptransfer.EMP_BASIC = Convert.ToDouble(rtxt_Basic.Text);
                            _obj_Emptransfer.EMP_PREVIOUS_CURRENCY = lbl_Currencydesc.Text;
                            _obj_Emptransfer.EMP_PREVIOUS_GROSS = Convert.ToDouble(lbl_Grossdesc.Text);
                            if (rcmb_period.SelectedValue != string.Empty)
                                _obj_Emptransfer.EMP_period_id = Convert.ToInt32(rcmb_period.SelectedValue);
                            else
                                _obj_Emptransfer.EMP_period_id = 0;
                            _obj_Emptransfer.EMP_LEAVEBALANCE = Convert.ToInt32(Session["LEAVES"]);

                            _obj_Emptransfer.EMP_PREVIOUS_BASIC = Convert.ToDouble(lbl_Basicdesc.Text);
                            _obj_Emptransfer.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Emptransfer.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                            _obj_Emptransfer.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                            _obj_Emptransfer.EMPCODE_CHECKED = false;

                            //if (lbl_AnnualGross.Text != string.Empty)
                            //    _obj_Emptransfer.EMP_ANNUAL_GROSS = Convert.ToDouble(lbl_AnnualGross.Text);
                            //else
                            _obj_Emptransfer.EMP_ANNUAL_GROSS = 0.0;
                            if (lbl_AnnualBasic.Text != string.Empty)
                                _obj_Emptransfer.EMP_ANNUAL_BASIC = Convert.ToDouble(lbl_AnnualBasic.Text);
                            else
                                _obj_Emptransfer.EMP_ANNUAL_BASIC = 0.0;

                            if (rcmb_BusinessunitReportingemp.SelectedIndex > 0)
                                _obj_Emptransfer.EMP_SUPBUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessunitReportingemp.SelectedItem.Value);
                            else
                                _obj_Emptransfer.EMP_SUPBUSINESSUNIT_ID = Convert.ToInt32(rcmb_Businessunit.SelectedItem.Value);

                            // _obj_Emptransfer.EMP_CATEGORY_ID = Convert.ToInt32(rcmbCategory.SelectedItem.Value);
                            //  if (lbl_category_id.Text != string.Empty)
                            //      _obj_Emptransfer.PREV_EMP_CATEGORY_ID = Convert.ToInt32(lbl_category_id.Text);
                            //  else
                            _obj_Emptransfer.PREV_EMP_CATEGORY_ID = null;
                            //_obj_Emptransfer.PREVIOUS_PERIOD = rcmb_period.SelectedValue != string.Empty ? Convert.ToInt32(rcmb_period.SelectedValue) : 0;
                            _obj_Emptransfer.PREVIOUS_PERIOD = lbl_FinancialPeriod.Text != string.Empty ? Convert.ToInt32(lbl_financialperiod_id.Text) : 0;
                            _obj_Emptransfer.EMP_GRADE = rcmb_Grade.SelectedValue != string.Empty ? Convert.ToInt32(rcmb_Grade.SelectedValue) : 0;
                            _obj_Emptransfer.PREVIOUS_EMP_GRADE = lbl_Grade_ID.Text != string.Empty ? Convert.ToInt32(lbl_Grade_ID.Text) : 0;
                            _obj_Emptransfer.EMP_SLAB_ID = rcmb_Slabs.SelectedValue != string.Empty ? Convert.ToInt32(rcmb_Slabs.SelectedValue) : 0;
                            _obj_Emptransfer.PREVIOUS_EMP_SLAB_ID = lbl_Slab_ID.Text != string.Empty ? Convert.ToInt32(lbl_Slab_ID.Text) : 0;
                            _obj_Emptransfer.PREV_EMP_Directorate_ID = lbl_Directorate_ID.Text != string.Empty ? Convert.ToInt32(lbl_Directorate_ID.Text) : 0;

                            int IResult = Convert.ToInt32(BLL.set_Emptransfer(_obj_Emptransfer));

                            if (IResult >= 1)
                            {
                                if (Convert.ToDateTime(DateTime.Now) >= Convert.ToDateTime(Convert.ToDateTime(rdtp_Executiondate.SelectedDate).ToShortDateString()))
                                {
                                    BLL.set_Emptransferjob(_obj_Emptransfer);
                                }
                                BLL.ShowMessage(this, "Employee  " + rcmb_Employees.SelectedItem.Text + " Is Transfered From  " + lbl_Businessunitdesc.Text + "  To  " + rcmb_Businessunit.SelectedItem.Text + " !");
                                loadgrid();
                                rg_Emptransfer.DataBind();
                                RM_Transfer.SelectedIndex = 0;
                                clearcontrols();
                            }
                        }
                        else
                        {
                            BLL.ShowMessage(this, "Cannot Transfer An Employee To Same Businessunit of Same Department!");
                        }
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Employee  " + rcmb_Employees.SelectedItem.Text + " Is Transfered From  " + lbl_Businessunitdesc.Text + "  To  " + rcmb_Businessunit.SelectedItem.Text + " !");
                        loadgrid();
                        rg_Emptransfer.DataBind();
                        RM_Transfer.SelectedIndex = 0;
                        clearcontrols();
                    }
                }
                else
                {

                }
            }
            else
            {
                BLL.ShowMessage(this, "Select A Correct BusinessUnit Information!");
                rcmb_Department.Focus();
                rcmb_Department.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpTransfer", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

            return;
        }
    }
    #endregion


    #region Viewing The Transferred employee information
    /// <summary>
    /// this method will show the selected employees current information i.e Transferred to Business unit
    /// and also the old businessunit along with positions,departments and etc.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtn_View_Click(object sender, CommandEventArgs e)
    {
        try
        {
            SMHR_EMPTRANSFER _obj_Emptransfer = new SMHR_EMPTRANSFER();
            lnkbtn_Cancel_Click(sender, e);
            DataTable dt_load = new DataTable();
            _obj_Emptransfer.EMP_EMPID = Convert.ToInt32(e.CommandArgument);
            RM_Transfer.SelectedIndex = 1;
            clearcontrols();
            rcmb_Employees.Items.Clear();
            rtxt_Basic.Enabled = false;
            // rntxt_Gross.Enabled = false;
            rtxt_Currency.Enabled = false;
            rcmb_Bu.Visible = false;
            _obj_Emptransfer.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_load = BLL.get_Employee(_obj_Emptransfer);
            LoadPeriod();
            if (dt_load.Rows.Count > 0)
            {
                //string SBusinessunit=dt_load.Rows[0]["BUSINESSUNIT_CODE"].ToString();
                //double DLeaves=Convert.ToDouble(dt_load.Rows[0].ItemArray[12].ToString());
                //Session["Balanced"] = DLeaves;
                rdtp_DOJ.SelectedDate = Convert.ToDateTime(dt_load.Rows[0]["EMP_DOJ"].ToString());
                string CHECK = dt_load.Rows[0]["EMP_DOC"].ToString();
                lnkbtn_Check.Enabled = false;
                if (CHECK == string.Empty)
                {
                    rdtp_DOC.SelectedDate = Convert.ToDateTime(dt_load.Rows[0]["EMP_DOJ"].ToString());
                }
                else
                {
                    rdtp_DOC.SelectedDate = Convert.ToDateTime(dt_load.Rows[0]["EMP_DOC"].ToString());
                }
                rtxt_LOS.Text = dt_load.Rows[0]["LENGTHOFEXPERIENCE"].ToString();
                lbl_Businessunitdesc.Text = dt_load.Rows[0]["PREVIOUSBU"].ToString();
                lbl_Departmentdesc.Text = dt_load.Rows[0]["PREVIOUSDEPT"].ToString();
                lbl_DirectorateDesc.Text = dt_load.Rows[0]["PREV_DIRECTORATE_CODE"].ToString();
                lbl_Leavestructuredesc.Text = dt_load.Rows[0]["PREVIOUSLEAVE"].ToString();
                lbl_Salstructuredesc.Text = dt_load.Rows[0]["PREVIOUSSAL"].ToString();
                lbl_Shiftdesc.Text = dt_load.Rows[0]["PREVIOUSSHIFT"].ToString();
                lblJobFrom.Text = Convert.ToString(dt_load.Rows[0]["PREVIOUS_JOBS_CODE"]);
                lbl_Positiondesc.Text = dt_load.Rows[0]["PREVIOUSDESG"].ToString();
                lbl_Reportingempdesc.Text = dt_load.Rows[0]["PREVIOUS_REPORTING_EMPNAME"].ToString();
                // lbl_Basicdesc.Text = dt_load.Rows[0]["EMP_BASIC"].ToString();
                lbl_Basicdesc.Text = dt_load.Rows[0]["CURRENTBASIC"].ToString();
                //lbl_Grossdesc.Text = dt_load.Rows[0]["EMP_GROSSSAL"].ToString();
                rdtp_Executiondate.SelectedDate = Convert.ToDateTime(dt_load.Rows[0]["EXECUTION_DATE"].ToString());
                if (!string.IsNullOrEmpty(dt_load.Rows[0]["REPORTING_DATE"].ToString()))
                    rdtp_Reportingdate.SelectedDate = Convert.ToDateTime(dt_load.Rows[0]["REPORTING_DATE"].ToString());
                lbl_Currencydesc.Text = dt_load.Rows[0]["PREVIOUSCURRENCY"].ToString();
                lbl_Grossdesc.Text = dt_load.Rows[0]["PREVIOUSGROSS"].ToString();

                Double x1;
                x1= Convert.ToDouble(dt_load.Rows[0]["PREVIOUSBASIC"]);
                lbl_Basicdesc.Text = x1.ToString("0.00");

                //lbl_Basicdesc.Text = dt_load.Rows[0]["PREVIOUSBASIC"].ToString();
                lbl_category_from.Text = dt_load.Rows[0]["PREV_CATEGORY"].ToString();
                rtxt_Currency.Visible = true;
                lbl_Bu.Visible = false;
                //rcmb_BusinessunitReportingemp.Visible = false;
                rcmb_Currencytype.Visible = false;
                rtxt_Currency.Text = dt_load.Rows[0]["CURRENTCURRENCY"].ToString();

                lbl_Grade_from.Text = dt_load.Rows[0]["PREVIOUS_EMP_GRADE"].ToString();   //Previous Emp Grade/Scale

                //rcmb_Grade.Text = dt_load.Rows[0]["EMP_GRADE"].ToString();   //Current Emp Grade/Scale
                rcmb_Grade.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem(dt_load.Rows[0]["EMP_GRADE"].ToString(), "0"));
                rcmb_Grade.DataBind();
                lbl_FinancialPeriod.Text = dt_load.Rows[0]["PREVIOUS_PERIOD"].ToString();
                rcmb_period.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem(dt_load.Rows[0]["CURRENT_PERIOD"].ToString(), "0"));
                //rcmb_period.SelectedIndex = rcmb_period.Items.FindItemIndexByValue(Convert.ToString(dt_load.Rows[0]["PERIOD_ID"]));
                rcmb_period.Enabled = false;
                rcmb_period.DataBind();

                Double x;
                x = Convert.ToDouble(dt_load.Rows[0]["PREVIOUS_SLAB"]);
                lbl_Slab_From.Text = x.ToString("0.00");

                //lbl_Slab_From.Text = dt_load.Rows[0]["PREVIOUS_SLAB"].ToString();   //Previous Slab
                //rcmb_Slabs.Text = dt_load.Rows[0]["EMP_SLAB"].ToString();   //Current Slab

                Double y;
                y = Convert.ToDouble(dt_load.Rows[0]["EMP_SLAB"]);
                // lbl_Scale_From.Text = Y.ToString("0.00");

                rcmb_Slabs.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem(y.ToString("0.00"), "0"));

               // rcmb_Slabs.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem(dt_load.Rows[0]["EMP_SLAB"].ToString(), "0"));
                rcmb_Slabs.DataBind();

                //rntxt_Gross.Text = dt_load.Rows[0]["CURRENTGROSS"].ToString();
                Double y1;
                y1 = Convert.ToDouble(dt_load.Rows[0]["CURRENTBASIC"]);
                rtxt_Basic.Text = y1.ToString("0.00");

                //rtxt_Basic.Text = dt_load.Rows[0]["CURRENTBASIC"].ToString();

                //if (Convert.ToString(dt_load.Rows[0]["EMPCODE_CHECKED"]) == "True")
                //{
                //    chk_empcode.Checked = true;
                //    tr_empcode.Visible = true;
                //    lbl_old_empcode.Text = Convert.ToString(dt_load.Rows[0]["PREV_EMP_EMPCODE"]);
                //    rtxt_empcode.Text = Convert.ToString(dt_load.Rows[0]["EMP_EMPCODE"]);
                //}
                //else
                //{
                //    chk_empcode.Checked = false;
                //    tr_empcode.Visible = false;
                //}


                string Businessunit = dt_load.Rows[0]["CURRENTBU"].ToString();
                rcmb_Businessunit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem(Businessunit, "0"));
                rcmb_Businessunit.DataBind();

                rcmb_Reportingemp.Items.Clear();
                string REPORTINGEMP = dt_load.Rows[0]["CURRENT_REPORTING_EMPNAME"].ToString();
                rcmb_Reportingemp.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem(REPORTINGEMP, "0"));
                rcmb_Reportingemp.DataBind();
                rcmb_Reportingemp.Enabled = false;

                string employee = dt_load.Rows[0]["EMP_NAME"].ToString();
                rcmb_Employees.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem(employee, "0"));
                rcmb_Employees.DataBind();

                string SHIFT = dt_load.Rows[0]["CURRENTSHIFT"].ToString();
                rcmb_Shifts.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem(SHIFT, "0"));
                rcmb_Shifts.DataBind();

                string SAL = dt_load.Rows[0]["CURRENTSAL"].ToString();
                rcmb_Salstruct.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem(SAL, "0"));
                rcmb_Salstruct.DataBind();

                string LEAVE = dt_load.Rows[0]["CURRENTLEAVE"].ToString();
                rcmb_Leavestruct.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem(LEAVE, "0"));
                rcmb_Leavestruct.DataBind();

                string job = dt_load.Rows[0]["JOBS_CODE"].ToString();
                rcmb_Job.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem(job, "0"));
                rcmb_Job.DataBind();

                string POSITION = dt_load.Rows[0]["CURRENTDESG"].ToString();
                rcmb_Position.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem(POSITION, "0"));
                rcmb_Position.DataBind();

                string DEPARTMENT = dt_load.Rows[0]["CURRENTDEPT"].ToString();
                rcmb_Department.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem(DEPARTMENT, "0"));
                rcmb_Department.DataBind();

                string DIRECTORATE_CODE = dt_load.Rows[0]["DIRECTORATE_CODE"].ToString();
                rcmb_Directorate.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem(DIRECTORATE_CODE, "0"));
                rcmb_Directorate.DataBind();

                string REPORTEMP_BU = dt_load.Rows[0]["BUSINESSUNIT_CODE"].ToString();
                rcmb_BusinessunitReportingemp.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem(REPORTEMP_BU, "0"));
                rcmb_BusinessunitReportingemp.DataBind();

                string CATEGORY = dt_load.Rows[0]["CATEGORY"].ToString();
                rcmbCategory.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem(CATEGORY, "0"));
                rcmbCategory.DataBind();

                if (Convert.ToString(dt_load.Rows[0]["EMP_MODE"]) == "1")
                {
                    rbtnlst_Coform.SelectedIndex = 0;
                }
                else
                {
                    rbtnlst_Coform.SelectedIndex = 1;
                }
                //if (Convert.ToString(dt_load.Rows[0][""]) == "True")
                //    chk_empcode.Checked = true;
                //else
                //    chk_empcode.Checked = false;
                //if (dt_load.Rows[0]["PREV_EMP_EMPCODE"] != System.DBNull.Value)
                //    lbl_empcode.Text = Convert.ToString(dt_load.Rows[0]["PREV_EMP_EMPCODE"]);
                //else
                //    lbl_empcode.Text = string.Empty;
                //if (dt_load.Rows[0]["EMP_EMPCODE"] != System.DBNull.Value)
                //    rtxt_empcode.Text = Convert.ToString(dt_load.Rows[0]["EMP_EMPCODE"]);
                enablecontrols();
            }
            else
            {
                BLL.ShowMessage(this, "This Employee Doesn't Belongs to your organisation");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpTransfer", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

            return;
        }
    }
    #endregion

    #region To Transfer A Employee
    /// <summary>
    /// This will loads the form where we can get the employees of selected businessunit
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtn_Add_Click(object sender, CommandEventArgs e)
    {
        try
        {
            RM_Transfer.SelectedIndex = 1;
            rcmb_period.Enabled = true;
            clearcontrols();
            loadcombos();
            LoadPeriod();
            rcmb_Businessunit.Items.Insert(0, new RadComboBoxItem("", ""));
            rcmb_Department.Items.Insert(0, new RadComboBoxItem("", ""));
            rcmb_Currencytype.Items.Insert(0, new RadComboBoxItem("", ""));
            rcmb_Leavestruct.Items.Insert(0, new RadComboBoxItem("", ""));
            rcmb_Position.Items.Insert(0, new RadComboBoxItem("", ""));
            rcmb_Salstruct.Items.Insert(0, new RadComboBoxItem("", ""));
            rcmb_Shifts.Items.Insert(0, new RadComboBoxItem("", ""));
            rcmb_BusinessunitReportingemp.Items.Insert(0, new RadComboBoxItem("", ""));
            rcmb_Reportingemp.Items.Clear();
            rcmb_Reportingemp.Items.Insert(0, new RadComboBoxItem("", ""));
            rcmbCategory.Items.Clear();
            rcmbCategory.Items.Insert(0, new RadComboBoxItem("", ""));
            rbtnlst_Coform.ClearSelection();
            btn_Submit.Visible = true;
            rbtnlst_Coform.Visible = true;
            lbl_Conform.Visible = true;
            rtxt_Currency.Enabled = false;
            //rntxt_Gross.Enabled = false;
            rtxt_Basic.Enabled = false;
            rbtnlst_Coform.Enabled = false;
            lbl_Currencydesc.Text = "";
            rtxt_Currency.Text = "";
            rcmb_Currencytype.Visible = true;
            LOADBU();
            lnkbtn_Check.Enabled = false;
            rdtp_Executiondate.SelectedDate = null;
            rdtp_Reportingdate.SelectedDate = null;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpTransfer", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

            return;
        }

    }
    #endregion

    #region For Updation Of Leave Balances
    /// <summary>
    /// this will get the selected employees remaining leavebalance list
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rbtnlst_Coform_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string checkedvalue = rbtnlst_Coform.SelectedItem.Text;
            if (checkedvalue == "Update")
            {
                //string remained1 = Convert.ToString(Session["FIRST"]);
                // string remained2 = Convert.ToString(Session["SECOND"]);
                // _obj_Emptransfer.EMP_LEAVEBALANCE1 =Convert.ToDouble(remained1);
                // _obj_Emptransfer.EMP_LEAVEBALANCE1 =Convert.ToDouble(remained2);
                _obj_Emptransfer.EMP_LEAVEBALANCE = 1;

            }
            else
            {
                // _obj_Emptransfer.EMP_LEAVEBALANCE1 = 0;
                //  _obj_Emptransfer.EMP_LEAVEBALANCE2 = 0;
                _obj_Emptransfer.EMP_LEAVEBALANCE = 0;
            }
            Session["LEAVES"] = _obj_Emptransfer.EMP_LEAVEBALANCE;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpTransfer", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

            return;
        }
    }
    #endregion

    //protected void rcmb_Department_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    //{
    //    if (rcmb_Department.SelectedIndex!=0)
    //    {
    //        DataTable dt_loaddetails = new DataTable();
    //        _obj_Emptransfer.EMP_DEPARTMENT_ID = Convert.ToInt32(rcmb_Department.SelectedValue.ToString());

    //    }
    //    else
    //    {
    //        BLL.ShowMessage(this, "Select A Department!");
    //    }
    //}
    protected void lnkbtn_Check_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_Emptransfer.EMP_EMPID = Convert.ToInt32(rcmb_Employees.SelectedValue.ToString());
            RG_Leaves.DataSource = null;
            RG_Leaves.DataBind();
            _obj_Emptransfer.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_leaves = BLL.get_empleaves(_obj_Emptransfer);
            if (dt_leaves.Rows.Count > 0)
            {
                RG_Leaves.DataSource = dt_leaves;
                //Session["FIRST"] = dt_leaves.Rows[0][0].ToString();
                //Session["SECOND"] = dt_leaves.Rows[1][0].ToString();
                RG_Leaves.DataBind();
            }
            else
            {
                BLL.ShowMessage(this, "Leave Structure is Not Defined Properly For The Selected Employee");
            }
            lnkbtn_Check.Visible = false;
            lnkbtn_Cancel.Visible = true;
            RG_Leaves.Visible = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpTransfer", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void lnkbtn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            RG_Leaves.Visible = false;
            lnkbtn_Cancel.Visible = false;
            lnkbtn_Check.Visible = true;
            rtxt_Currency.Visible = false;
            rcmb_Currencytype.Visible = true;

            //rcmb_Bu.Items.Clear();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpTransfer", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

            return;
        }
    }

    #region Reporting employees from businessunit
    /// <summary>
    /// loading various business units and also the corresponding employees in that
    /// </summary>
    /// <param name="o"></param>
    /// <param name="e"></param>
    protected void rcmb_BusinessunitReportingemp_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_BusinessunitReportingemp.SelectedIndex != 0)
            {
                DataTable DT_reportingemp = new DataTable();
                rcmb_Reportingemp.Items.Clear();
                _obj_Emptransfer.OPERATION = operation.Check1;
                _obj_Emptransfer.BUID = Convert.ToInt32(rcmb_BusinessunitReportingemp.SelectedValue.ToString());
                _obj_Emptransfer.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DT_reportingemp = BLL.get_Reportingemployees(_obj_Emptransfer);
                rcmb_Reportingemp.DataSource = DT_reportingemp;
                rcmb_Reportingemp.DataTextField = "EMP_REPOTRINGEMPNAME";
                rcmb_Reportingemp.DataValueField = "REPORTING_EMPLOYEE_ID";
                rcmb_Reportingemp.DataBind();
                rcmb_Reportingemp.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                if (rcmb_Bu.SelectedValue == rcmb_BusinessunitReportingemp.SelectedValue)
                {
                    int position = rcmb_Reportingemp.FindItemIndexByValue(rcmb_Employees.SelectedValue);
                    rcmb_Reportingemp.Items.Remove(position);
                }

            }
            else
            {//LOADING THE  TRANSFERED BUSINESSUNIT EMPLOYEE IF REPORTING EMPLOYEE BUSINESSUNIT NOT SELECTED
                if (rcmb_Businessunit.SelectedIndex > 0)
                {
                    DataTable Dt = ViewState["REPORTING_EMPLOYEES"] as DataTable;
                    rcmb_Reportingemp.Items.Clear();

                    rcmb_Reportingemp.DataSource = Dt;
                    rcmb_Reportingemp.DataTextField = "EMP_REPOTRINGEMPNAME";
                    rcmb_Reportingemp.DataValueField = "REPORTING_EMPLOYEE_ID";
                    rcmb_Reportingemp.DataBind();
                    rcmb_Reportingemp.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                    if (rcmb_Bu.SelectedValue == rcmb_BusinessunitReportingemp.SelectedValue)
                    {
                        int position = rcmb_Reportingemp.FindItemIndexByValue(rcmb_Employees.SelectedValue);
                        rcmb_Reportingemp.Items.Remove(position);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpTransfer", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

            return;
        }
        //else
        //{
        //    DataTable DT_reportingemp = new DataTable();
        //    rcmb_Reportingemp.Items.Clear();
        //    _obj_Emptransfer.OPERATION = operation.Check1;
        //    _obj_Emptransfer.BUID = Convert.ToInt32(rcmb_Businessunit.SelectedValue.ToString());
        //    DT_reportingemp = BLL.get_Reportingemployees(_obj_Emptransfer);
        //    rcmb_Reportingemp.DataSource = DT_reportingemp;
        //    rcmb_Reportingemp.DataTextField = "EMP_REPOTRINGEMPNAME";
        //    rcmb_Reportingemp.DataValueField = "REPORTING_EMPLOYEE_ID";
        //    rcmb_Reportingemp.DataBind();
        //    rcmb_Reportingemp.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        //}
    }
    #endregion




    protected void rcmb_Bu_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            clearcontrols();
            lnkbtn_Check.Enabled = false;
            _obj_SMHR_LoginInfo.BUID = Convert.ToInt32(rcmb_Bu.SelectedValue.ToString());
            if (rcmb_Bu.SelectedIndex != 0)
            {
                loadcombos();
                string Maxdate = "";
                DataTable dt_executiondate = new DataTable();
                _obj_Emptransfer.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Emptransfer.BUID = Convert.ToInt32(rcmb_Bu.SelectedValue.ToString());
                dt_executiondate = BLL.GET_LASTPAYROLL(_obj_Emptransfer);
                if (dt_executiondate.Rows.Count > 0)
                {
                    rdtp_Executiondate.MinDate = Convert.ToDateTime(dt_executiondate.Rows[0]["MINDATE"].ToString());
                    rdtp_Executiondate.MinDate = rdtp_Executiondate.MinDate.AddDays(1);
                    Maxdate = Convert.ToString(dt_executiondate.Rows[0]["PAYTRAN_DTLID"].ToString());
                    dt_executiondate = null;
                    _obj_Emptransfer.CREATEDBY = 1;
                    _obj_Emptransfer.BUID = Convert.ToInt32(rcmb_Bu.SelectedValue.ToString());
                    _obj_Emptransfer.MODE = Convert.ToInt32(Maxdate);
                    dt_executiondate = BLL.GET_LASTPAYROLL(_obj_Emptransfer);
                    DateTime min = rdtp_Executiondate.MinDate;
                    DateTime max = Convert.ToDateTime(dt_executiondate.Rows[0]["DATE"].ToString());
                    //DateTime diff = Convert.ToDateTime(max - min);
                    //if (max > min)
                    //    rdtp_Executiondate.MaxDate = Convert.ToDateTime(dt_executiondate.Rows[0]["DATE"].ToString());
                    //else
                    //    rdtp_Executiondate.MaxDate = DateTime.Now;
                }
                else
                {
                    string S = "Payroll is not Processed for the Selected Businessunit ";
                    string Sa = "so, there is no validation for the execution date ";
                    string msg = S + " " + Sa;
                    BLL.ShowMessage(this, msg);
                }
            }
            else
            {
                BLL.ShowMessage(this, "Select A Business Unit!");
                rcmb_Employees.Items.Clear();
                rcmb_Businessunit.Items.Clear();
                rcmb_Businessunit.Items.Insert(0, new RadComboBoxItem("", ""));
                rcmb_Department.Items.Clear();
                rcmb_Department.Items.Insert(0, new RadComboBoxItem("", ""));
                rcmb_Currencytype.Items.Clear();
                rcmb_Currencytype.Items.Insert(0, new RadComboBoxItem("", ""));
                rcmb_Leavestruct.Items.Clear();
                rcmb_Leavestruct.Items.Insert(0, new RadComboBoxItem("", ""));
                rcmb_Position.Items.Clear();
                rcmb_Position.Items.Insert(0, new RadComboBoxItem("", ""));
                rcmb_Salstruct.Items.Clear();
                rcmb_Salstruct.Items.Insert(0, new RadComboBoxItem("", ""));
                rcmb_Shifts.Items.Clear();
                rcmb_Shifts.Items.Insert(0, new RadComboBoxItem("", ""));
                rcmb_BusinessunitReportingemp.Items.Clear();
                rcmb_BusinessunitReportingemp.Items.Insert(0, new RadComboBoxItem("", ""));
                rcmb_Reportingemp.Items.Clear();
                rcmb_Reportingemp.Items.Insert(0, new RadComboBoxItem("", ""));
                rcmb_Bu.Items.Clear();
                rbtnlst_Coform.ClearSelection();
                LOADBU();
                rdtp_Executiondate.SelectedDate = null;
                rdtp_Reportingdate.SelectedDate = null;
                //rcmb_Employees.Items.Clear();
                //rcmb_Employees.Items.Insert(0, new RadComboBoxItem("", ""));

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpTransfer", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    #region Rollback Transfer
    /// <summary>
    /// To Rollback Transferred employees to previous businessunit
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtn_Roolback_Click(object sender, CommandEventArgs e)
    {

        try
        {
            //_obj_Emptransfer.OPERATION = operation.Delete;
            _obj_Emptransfer.EMP_EMPID = Convert.ToInt32(e.CommandArgument);
            DataTable dt_Rollback = new DataTable();
            //_obj_Emptransfer.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Rollback = BLL.get_RollbackTransfer(_obj_Emptransfer);
            if (dt_Rollback.Rows.Count > 0)
            {
                if (dt_Rollback.Rows[0][0].ToString() == "1")
                {
                    _obj_Emptransfer.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    int Rollback = Convert.ToInt32(BLL.get_Dorollback(_obj_Emptransfer));
                    if (Rollback > 0)
                    {
                        BLL.ShowMessage(this, "Employee Is Rollbacked Succesfully!");
                    }
                    loadgrid();
                    rg_Emptransfer.DataBind();
                }
                else
                {
                    BLL.ShowMessage(this, "Employee Is Transferred You Cannot Rollback Him!");
                }
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpTransfer", ex.StackTrace, DateTime.Now);
            return;
        }
    }
    #endregion
    protected void rg_Emptransfer_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            loadgrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpTransfer", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

            return;
        }
    }
    //protected void chk_empcode_CheckedChanged(object sender, EventArgs e)
    //{
    //    if (chk_empcode.Checked)
    //    {
    //        tr_empcode.Visible = true;
    //        if (Convert.ToBoolean(ViewState["EMPCODE_MANUAL"]) == true)
    //        {
    //            rtxt_empcode.Enabled = true;
    //            rfv_rtxt_empcode.Enabled = true;
    //        }
    //        else
    //        {
    //            rtxt_empcode.Enabled = false;
    //            rfv_rtxt_empcode.Enabled = false;
    //        }
    //    }
    //    else
    //    {
    //        tr_empcode.Visible = false;
    //        rfv_rtxt_empcode.Enabled = false;
    //    }
    //}

    //}
    protected void rcmb_Grade_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            SMHR_EMPLOYEEGRADE_SLAB _obj_SMHR_EMPLOYEEGRADE_SLAB = new SMHR_EMPLOYEEGRADE_SLAB();
            // rcmb_period.Items.Clear();

            if (rcmb_Grade.SelectedIndex > 0 && rcmb_period.SelectedIndex > 0)
            {
                _obj_SMHR_EMPLOYEEGRADE_SLAB.OPERATION = operation.Get;
                _obj_SMHR_EMPLOYEEGRADE_SLAB.EMPLOYEEGRADE_SLAB_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_SMHR_EMPLOYEEGRADE_SLAB.EMPLOYEEGRADE_SLAB_EMPLOYEEGRADE_ID = Convert.ToInt32(rcmb_Grade.SelectedValue);

                DataTable dtSlabs = LoadSalarySlabs1();

                if (dtSlabs.Rows.Count > 0)
                {
                    rcmb_Slabs.DataSource = dtSlabs;
                    rcmb_Slabs.DataTextField = "EMPLOYEEGRADE_SLAB_AMOUNT";
                    rcmb_Slabs.DataValueField = "EMPLOYEEGRADE_SLAB_ID";
                    rcmb_Slabs.DataBind();
                }
                rcmb_Slabs.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            }
            else
            {
                if (rcmb_period.SelectedIndex == 0)
                {
                    BLL.ShowMessage(this, "Please select Financial Period before selecting scale");
                    rcmb_period.Focus();
                    return;
                }
                rcmb_Slabs.SelectedIndex = 0;
                rtxt_Basic.Text = string.Empty;


            }

            //rcmb_Slabs.Items.Clear();
            //rcmb_Slabs.DataValueField = "EMPLOYEEGRADE_SLAB_ID"; //"EMPLOYEEGRADE_SLAB_SRNO";
            //rcmb_Slabs.DataTextField = "EMPLOYEEGRADE_SLAB_AMOUNT";
            //rcmb_Slabs.DataSource = LoadSalarySlabs();
            //rcmb_Slabs.DataBind();
            ////rcmb_Slabs.Items.Insert(0, new RadComboBoxItem { Text = "Select", Value = "0" });
            //rcmb_Slabs.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpTransfer", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private DataTable LoadSalarySlabs()
    {
        try
        {
            SMHR_EMPLOYEEGRADE _obj_Smhr_EmployeeGrade = new SMHR_EMPLOYEEGRADE();
            _obj_Smhr_EmployeeGrade.EMPLOYEEGRADE_ID = rcmb_Grade.SelectedValue != string.Empty ? Convert.ToInt32(rcmb_Grade.SelectedValue) : 0;
            _obj_Smhr_EmployeeGrade.OPERATION = operation.EmployeeSlabs;
            _obj_Smhr_EmployeeGrade.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataSet ds = BLL.get_EmployeeGrade(_obj_Smhr_EmployeeGrade);
            return ds.Tables[0];
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpTransfer", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return null;
        }
    }

    private DataTable LoadSalarySlabs1()
    {

        try
        {
            SMHR_EMPLOYEEGRADE_SLAB _obj_Smhr_EmployeeGrade = new SMHR_EMPLOYEEGRADE_SLAB();
            _obj_Smhr_EmployeeGrade.EMPLOYEEGRADE_SLAB_EMPLOYEEGRADE_ID = rcmb_Grade.SelectedValue != string.Empty ? Convert.ToInt32(rcmb_Grade.SelectedValue) : 0;
            _obj_Smhr_EmployeeGrade.OPERATION = operation.EmployeeSlabs;
            _obj_Smhr_EmployeeGrade.EMPLOYEEGRADE_SLAB_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_EmployeeGrade.EMPLOYEEGRADE_SLAB_PERIOD_ID = Convert.ToInt32(rcmb_period.SelectedValue);
            DataTable dt = new DataTable();
            dt = BLL.get_EmployeeGrades(_obj_Smhr_EmployeeGrade);
            return dt;
        }


        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpTransfer", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return null;
        }

    }

    protected void rcmb_Slabs_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {

            /* //rntxt_Gross.Text = string.Empty;
             rtxt_Basic.Text = rcmb_Slabs.Text;
             //if (rcmb_Slabs.SelectedIndex > 0)
             //{
             //    rntxt_Gross.Text = rcmb_Slabs.Text;
             //    Calculate_Basic();
             //}*/

            if (rcmb_Slabs.SelectedIndex > 0)
            {
                //txt_GrossSalary.Text = ddl_Slabs.Text;
                string[] str = Convert.ToString(rcmb_Slabs.Text).Replace(" )", "").Replace(")", "").Split('(');
                rtxt_Basic.Value = Convert.ToDouble(Convert.ToString(str[1].Trim())) / 12;
                //ddl_EmpStatus_SelectedIndexChanged(null, null);
                //Calculate_Basic();
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpTransfer", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    //private void Calculate_Basic()
    //{
    //    if (rntxt_Gross.Text != string.Empty)
    //    {
    //        if (Convert.ToDouble(rntxt_Gross.Text) >= 0)
    //        {

    //            //code for getting Basic percentage of Gross For the businessunit selected
    //            SMHR_BUSINESSUNIT _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
    //            _obj_smhr_businessunit.OPERATION = operation.Select;
    //            _obj_smhr_businessunit.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_Businessunit.SelectedValue);
    //            _obj_smhr_businessunit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //            DataTable dt_BusinessUnit = BLL.get_BusinessUnit(_obj_smhr_businessunit);
    //            if ((dt_BusinessUnit.Rows.Count > 0) && (rcmb_Businessunit.SelectedValue != string.Empty))
    //            {
    //                _obj_smhr_businessunit.OPERATION = operation.Get_BULocalization;
    //                DataTable dtBuLocal = BLL.get_BusinessUnit(_obj_smhr_businessunit);
    //                if (dtBuLocal.Rows.Count > 0)
    //                {
    //                    float strSuperAnnuation = Convert.ToSingle(0.00);

    //                    if (dt_BusinessUnit.Rows[0]["BUSINESSUNIT_BASICPERCENT"] != System.DBNull.Value)
    //                    {
    //                        float IBasicPercent = Convert.ToSingle(dt_BusinessUnit.Rows[0]["BUSINESSUNIT_BASICPERCENT"]);

    //                        float emp_GrossSal = Convert.ToSingle(rntxt_Gross.Text.Replace("'", "''"));
    //                        //float emp_BasicSal = (55 * emp_GrossSal) / 100;
    //                        float emp_BasicSal = (IBasicPercent * emp_GrossSal) / 100;
    //                        rtxt_Basic.Text = Convert.ToString(emp_BasicSal);
    //                        //if (ddl_Jobs.SelectedValue != "Select")
    //                        //{
    //                        //    if (!((Convert.ToDouble(rntxt_Gross.Text) >= minsal) && (Convert.ToDouble(rntxt_Gross.Text) <= maxsal)))
    //                        //    {
    //                        //        BLL.ShowMessage(this, "Gross Must be in the range of Selected Job Min and Max Salary:" + minsal + "-" + maxsal);
    //                        //        rntxt_Gross.Text = "";
    //                        //        rtxt_Basic.Text = "";
    //                        //        return;
    //                        //    }
    //                        //}
    //                    }
    //                    else
    //                    {
    //                        BLL.ShowMessage(this, "Basic Is Not Defined For The Businessunit:" + rcmb_Businessunit.SelectedItem.Text);
    //                        rntxt_Gross.Text = "";
    //                        return;
    //                    }
    //                    //}
    //                }
    //            }
    //            else
    //            {
    //                BLL.ShowMessage(this, "Select Proper Businessunit");
    //                rntxt_Gross.Text = "";
    //            }

    //        }
    //    }
    //    else
    //    {
    //        BLL.ShowMessage(this, "Gross Must be Greater Than Zero!");
    //        rtxt_Basic.Text = "";
    //        rntxt_Gross.Focus();
    //    }
    //}
    protected void rdtp_Executiondate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        try
        {
            if (rdtp_Executiondate.SelectedDate != null && rcmb_Grade.SelectedValue != string.Empty)
            {
                SMHR_EMPPROMOTIONS _obj_Smhr_Promotions = new SMHR_EMPPROMOTIONS();
                SMHR_EMPPROMOTIONS _obj_Smhr_Promotions_2 = new SMHR_EMPPROMOTIONS();
                _obj_Smhr_Promotions.OPERATION = operation.CHECKSLABPERIODS;
                _obj_Smhr_Promotions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_Promotions.EMPPRO_GRADE = Convert.ToInt32(rcmb_Grade.SelectedValue);
                _obj_Smhr_Promotions.VALIDATEPERIOD = Convert.ToDateTime(rdtp_Executiondate.SelectedDate);

                bool status = BLL.set_EmpPromotion(_obj_Smhr_Promotions, _obj_Smhr_Promotions_2);
                if (status == false)
                {
                    BLL.ShowMessage(this, "Slabs Not Finalized For Selected Scale");
                    rdtp_Executiondate.SelectedDate = null;
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpTransfer", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

        }
    }



    //#region Calculating Basic
    ///// <summary>
    ///// this will take the input as gross salary from the user and automatically calcultes basic as 
    ///// 55% of gross
    ///// </summary>
    ///// <param name="sender"></param>
    ///// <param name="e"></param>
    //protected void rntxt_Gross_TextChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        //code for getting basic percent of gross of the selected businessunit.
    //        _obj_SMHR_BusinessUnit = new SMHR_BUSINESSUNIT();
    //        _obj_SMHR_BusinessUnit.OPERATION = operation.Select;
    //        _obj_SMHR_BusinessUnit.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_Businessunit.SelectedValue);
    //        _obj_SMHR_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //        DataTable dt_BusinessUnit = BLL.get_BusinessUnit(_obj_SMHR_BusinessUnit);
    //        if (dt_BusinessUnit.Rows.Count != 0)
    //        {
    //            int IBasicPercent = Convert.ToInt32(dt_BusinessUnit.Rows[0]["BUSINESSUNIT_BASICPERCENT"]);
    //            if (Convert.ToDouble(rntxt_Gross.Text) > 0)
    //            {
    //                if (Convert.ToInt32(rcmb_Position.SelectedItem.Value) > 0)
    //                {
    //                    //TO GET EMPLOYEE TYPE
    //                    SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
    //                    _obj_smhr_logininfo.OPERATION = operation.Select3;
    //                    _obj_smhr_logininfo.LOGIN_EMP_ID = Convert.ToInt32(rcmb_Employees.SelectedItem.Value);
    //                    _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                    DataTable dt_emp = BLL.get_LoginInfo(_obj_smhr_logininfo);
    //                    if (dt_emp.Rows.Count != 0)
    //                    {
    //                        if (Convert.ToString(dt_emp.Rows[0]["EMP_EMPLOYEETYPE"]).Trim() == "Contract")
    //                        {
    //                            //getJob(rcmb_Position.SelectedItem.Value);
    //                            rtxt_Basic.Text = rntxt_Gross.Text;
    //                            Calculate_AnnualBasic();
    //                        }
    //                        else
    //                        {
    //                            //getJob(rcmb_Position.SelectedItem.Value);
    //                            double IGross = Convert.ToDouble(rntxt_Gross.Text);
    //                            //int IBasic = (IGross * 55) / 100;
    //                            double IBasic = (IGross * IBasicPercent) / 100;
    //                            rtxt_Basic.Text = Convert.ToString(IBasic);

    //                            SMHR_ORGANISATION _obj_SMHR_ORGANISATION = new SMHR_ORGANISATION();
    //                            _obj_SMHR_ORGANISATION.MODE = 2;
    //                            _obj_SMHR_ORGANISATION.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                            DataTable dt_Organisation = BLL.get_Organisation(_obj_SMHR_ORGANISATION);
    //                            if (dt_Organisation.Rows.Count != 0)
    //                            {
    //                                if (Convert.ToString(dt_Organisation.Rows[0]["ORGANISATION_ANNUALPROCESS"]) != "")
    //                                {
    //                                    if (Convert.ToString(dt_Organisation.Rows[0]["ORGANISATION_ANNUALPROCESS"]).ToUpper() == "TRUE")
    //                                    {
    //                                        SMHR_SALARYSTRUCT _obj_smhr_salaryStruct = new SMHR_SALARYSTRUCT();
    //                                        _obj_smhr_salaryStruct.OPERATION = operation.Select;
    //                                        _obj_smhr_salaryStruct.SALARYSTRUCT_ID = Convert.ToInt32(rcmb_Salstruct.SelectedItem.Value);
    //                                        _obj_smhr_salaryStruct.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                                        DataTable dt_PeriodType = BLL.get_SalaryHeaderDetails(_obj_smhr_salaryStruct);
    //                                        _obj_smhr_salaryStruct.SALARYSTRUCT_TYPE = Convert.ToInt32(dt_PeriodType.Rows[0]["SALARYSTRUCT_TYPE"]);
    //                                        _obj_smhr_salaryStruct.OPERATION = operation.Validate;
    //                                        DataTable dt_PeriodTypeName = BLL.get_SalaryHeaderDetails(_obj_smhr_salaryStruct);
    //                                        if (dt_PeriodTypeName.Rows.Count != 0)
    //                                        {
    //                                            if (Convert.ToString(dt_PeriodTypeName.Rows[0]["PERIODTYPE_NAME"]).ToUpper() == "MONTHLY")
    //                                            {
    //                                                lbl_AnnualGross.Text = Convert.ToString(Convert.ToDouble(rntxt_Gross.Text) * 12);
    //                                                double IAnnualGross = Convert.ToDouble(lbl_AnnualGross.Text);
    //                                                //int IBasic = (IGross * 55) / 100;
    //                                                double IAnnualBasic = (IAnnualGross * IBasicPercent) / 100;
    //                                                lbl_AnnualBasic.Text = Convert.ToString(IAnnualBasic);
    //                                            }
    //                                            else if (Convert.ToString(dt_PeriodTypeName.Rows[0]["PERIODTYPE_NAME"]).ToUpper() == "FORTNIGHT")
    //                                            {
    //                                                lbl_AnnualGross.Text = Convert.ToString(Convert.ToDouble(rntxt_Gross.Text) * 26);
    //                                                double IAnnualGross = Convert.ToDouble(lbl_AnnualGross.Text);
    //                                                //int IBasic = (IGross * 55) / 100;
    //                                                double IAnnualBasic = (IAnnualGross * IBasicPercent) / 100;
    //                                                lbl_AnnualBasic.Text = Convert.ToString(IAnnualBasic);
    //                                            }
    //                                        }
    //                                        getJobAnnual(rcmb_Position.SelectedItem.Value);
    //                                    }
    //                                    else
    //                                    {
    //                                        lbl_AnnualBasic.Text = string.Empty;
    //                                        lbl_AnnualGross.Text = string.Empty;
    //                                        getJob(rcmb_Position.SelectedItem.Value);
    //                                    }
    //                                }
    //                                else
    //                                {
    //                                    lbl_AnnualBasic.Text = string.Empty;
    //                                    lbl_AnnualGross.Text = string.Empty;
    //                                    getJob(rcmb_Position.SelectedItem.Value);
    //                                }
    //                            }
    //                        }
    //                    }
    //                }
    //                else
    //                {
    //                    BLL.ShowMessage(this, "Please Select Position");
    //                    rntxt_Gross.Text = "";
    //                    rtxt_Basic.Text = "";
    //                    rntxt_Gross.Focus();
    //                }
    //            }
    //            else
    //            {
    //                BLL.ShowMessage(this, "Gross Must Be Greater Than 0 !");
    //                rntxt_Gross.Text = "";
    //                rtxt_Basic.Text = "";
    //                rntxt_Gross.Focus();
    //            }
    //        }
    //        else
    //        {
    //            BLL.ShowMessage(this, "Select Transferred BusinessUnit for the Transferring employee");
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpTransfer", ex.StackTrace, DateTime.Now);
    //        return;
    //    }
    //}

    //private void Calculate_AnnualBasic()
    //{
    //    try
    //    {
    //        SMHR_ORGANISATION _obj_SMHR_ORGANISATION = new SMHR_ORGANISATION();
    //        _obj_SMHR_ORGANISATION.MODE = 2;
    //        _obj_SMHR_ORGANISATION.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //        DataTable dt_Organisation = BLL.get_Organisation(_obj_SMHR_ORGANISATION);
    //        if (dt_Organisation.Rows.Count != 0)
    //        {
    //            if (Convert.ToString(dt_Organisation.Rows[0]["ORGANISATION_ANNUALPROCESS"]) != "")
    //            {
    //                if (Convert.ToString(dt_Organisation.Rows[0]["ORGANISATION_ANNUALPROCESS"]).ToUpper() == "TRUE")
    //                {
    //                    SMHR_SALARYSTRUCT _obj_smhr_salaryStruct = new SMHR_SALARYSTRUCT();
    //                    _obj_smhr_salaryStruct.OPERATION = operation.Select;
    //                    _obj_smhr_salaryStruct.SALARYSTRUCT_ID = Convert.ToInt32(rcmb_Salstruct.SelectedItem.Value);
    //                    _obj_smhr_salaryStruct.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                    DataTable dt_PeriodType = BLL.get_SalaryHeaderDetails(_obj_smhr_salaryStruct);
    //                    _obj_smhr_salaryStruct.SALARYSTRUCT_TYPE = Convert.ToInt32(dt_PeriodType.Rows[0]["SALARYSTRUCT_TYPE"]);
    //                    _obj_smhr_salaryStruct.OPERATION = operation.Validate;
    //                    DataTable dt_PeriodTypeName = BLL.get_SalaryHeaderDetails(_obj_smhr_salaryStruct);
    //                    if (dt_PeriodTypeName.Rows.Count != 0)
    //                    {
    //                        if (Convert.ToString(dt_PeriodTypeName.Rows[0]["PERIODTYPE_NAME"]).ToUpper() == "MONTHLY")
    //                        {
    //                            lbl_AnnualGross.Text = Convert.ToString(Convert.ToDouble(rntxt_Gross.Text) * 12);
    //                            lbl_AnnualBasic.Text = lbl_AnnualGross.Text;
    //                        }
    //                        else if (Convert.ToString(dt_PeriodTypeName.Rows[0]["PERIODTYPE_NAME"]).ToUpper() == "FORTNIGHT")
    //                        {
    //                            lbl_AnnualGross.Text = Convert.ToString(Convert.ToDouble(rntxt_Gross.Text) * 26);
    //                            lbl_AnnualBasic.Text = lbl_AnnualGross.Text;
    //                        }
    //                    }
    //                    getJobAnnual(rcmb_Position.SelectedItem.Value);
    //                }
    //                else
    //                {
    //                    lbl_AnnualBasic.Text = string.Empty;
    //                    lbl_AnnualGross.Text = string.Empty;
    //                    getJob(rcmb_Position.SelectedItem.Value);
    //                }
    //            }
    //            else
    //            {
    //                lbl_AnnualBasic.Text = string.Empty;
    //                lbl_AnnualGross.Text = string.Empty;
    //                getJob(rcmb_Position.SelectedItem.Value);
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpTransfer", ex.StackTrace, DateTime.Now);
    //        return;
    //    }
    //}
    //private void getJob(string strPosition)
    //{
    //    if (strPosition != "")
    //    {
    //        SMHR_POSITIONS _obj_smhr_positions = new SMHR_POSITIONS();
    //        _obj_smhr_positions.OPERATION = operation.Empty;
    //        _obj_smhr_positions.POSITIONS_ID = Convert.ToInt32(strPosition);
    //        _obj_smhr_positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //        DataTable dt = BLL.get_Positions(_obj_smhr_positions);
    //        if (dt.Rows.Count != 0)
    //        {
    //            //lbl_jobName.Text = Convert.ToString(dt.Rows[0]["JOBS_CODE"]);
    //            if (Convert.ToString(dt.Rows[0]["JOBS_ID"]) != "")
    //            {
    //                SMHR_JOBS _obj_Jobs = new SMHR_JOBS();
    //                _obj_Jobs.JOBS_ID = Convert.ToInt32(dt.Rows[0]["JOBS_ID"]);
    //                DataTable dt1 = BLL.get_Jobs(_obj_Jobs);
    //                maxsal = Convert.ToDouble(dt1.Rows[0]["JOBS_MAXSAL"]);
    //                minsal = Convert.ToDouble(dt1.Rows[0]["JOBS_MINSAL"]);
    //                if (rntxt_Gross.Text != "")
    //                {
    //                    //for validating job minsal and maxsal with the gross                        
    //                    if (!((Convert.ToDouble(rntxt_Gross.Text) >= minsal) && (Convert.ToDouble(rntxt_Gross.Text) <= maxsal)))
    //                    {
    //                        BLL.ShowMessage(this, "Gross Must be in the range of Selected Job Min and Max Salary:" + minsal + "-" + maxsal);
    //                        rntxt_Gross.Text = "";
    //                        rtxt_Basic.Text = "";
    //                        return;
    //                    }

    //                }
    //            }
    //        }
    //    }
    //}
    //private void getJobAnnual(string strPosition)
    //{
    //    if (strPosition != "")
    //    {
    //        SMHR_POSITIONS _obj_smhr_positions = new SMHR_POSITIONS();
    //        _obj_smhr_positions.OPERATION = operation.Empty;
    //        _obj_smhr_positions.POSITIONS_ID = Convert.ToInt32(strPosition);
    //        _obj_smhr_positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //        DataTable dt = BLL.get_Positions(_obj_smhr_positions);
    //        if (dt.Rows.Count != 0)
    //        {
    //            //lbl_jobName.Text = Convert.ToString(dt.Rows[0]["JOBS_CODE"]);
    //            if (Convert.ToString(dt.Rows[0]["JOBS_ID"]) != "")
    //            {
    //                SMHR_JOBS _obj_Jobs = new SMHR_JOBS();
    //                _obj_Jobs.JOBS_ID = Convert.ToInt32(dt.Rows[0]["JOBS_ID"]);
    //                DataTable dt1 = BLL.get_Jobs(_obj_Jobs);
    //                maxsal = Convert.ToDouble(dt1.Rows[0]["JOBS_MAXSAL"]);
    //                minsal = Convert.ToDouble(dt1.Rows[0]["JOBS_MINSAL"]);
    //                if (rntxt_Gross.Text != "")
    //                {
    //                    //for validating job minsal and maxsal with the gross                        
    //                    if (!((Convert.ToDouble(lbl_AnnualGross.Text) >= minsal) && (Convert.ToDouble(lbl_AnnualGross.Text) <= maxsal)))
    //                    {
    //                        BLL.ShowMessage(this, "Annual Gross Must be in the range of Selected Job Min and Max Salary:" + minsal + "-" + maxsal);
    //                        rntxt_Gross.Text = "";
    //                        rtxt_Basic.Text = "";
    //                        lbl_AnnualGross.Text = string.Empty;
    //                        lbl_AnnualBasic.Text = string.Empty;
    //                        return;
    //                    }

    //                }
    //            }
    //        }
    //    }
    //}
    //#endregion
    protected void rcmb_Directorate_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rcmb_Department.Items.Clear();
            rcmb_Department.Text = string.Empty;
            if (rcmb_Directorate.SelectedIndex > 0)
            {
                SMHR_DEPARTMENT _obj_Department = new SMHR_DEPARTMENT();
                _obj_Department.MODE = 7;
                _obj_Department.DIRECTORATE_ID = rcmb_Directorate.SelectedValue != string.Empty ? Convert.ToInt32(rcmb_Directorate.SelectedValue) : 0;
                _obj_Department.BUID = Convert.ToInt32(rcmb_Businessunit.SelectedValue);
                DataTable dt = BLL.get_Department(_obj_Department);
                rcmb_Department.DataSource = dt;
                rcmb_Department.DataTextField = "DEPARTMENT_NAME";
                rcmb_Department.DataValueField = "DEPARTMENT_ID";
                rcmb_Department.DataBind();
                rcmb_Department.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpTransfer", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void rcmb_Job_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (Session["ORG_ID"] != "")
            {
                if (rcmb_Businessunit.SelectedIndex > 0 && rcmb_Job.SelectedValue != string.Empty)
                {
                    rcmb_Position.Items.Clear();
                    SMHR_POSITIONS _obj_smhr_positions = new SMHR_POSITIONS();
                    _obj_smhr_positions.OPERATION = operation.JOBPOSITIONS;
                    _obj_smhr_positions.POSITIONS_JOBSID = Convert.ToInt32(rcmb_Job.SelectedValue);
                    _obj_smhr_positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtPos = BLL.get_Positions(_obj_smhr_positions);
                    rcmb_Position.DataSource = dtPos;
                    rcmb_Position.DataTextField = "POSITIONS_CODE";
                    rcmb_Position.DataValueField = "POSITIONS_ID";
                    rcmb_Position.DataBind();
                    rcmb_Position.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                }
                else
                {
                    rcmb_Position.Items.Clear();
                    rcmb_Position.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                    rcmb_Grade.Items.Clear();
                    rcmb_Grade.Text = string.Empty;
                    rcmb_Slabs.Items.Clear();
                    rcmb_Slabs.Text = string.Empty;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpTransfer", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_period_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_period.SelectedIndex > 0)
            {
                rcmb_Grade.Items.Clear();
                //rcmb_period.Items.Clear();

                SMHR_EMPLOYEEGRADE_SLAB _obj_Smhr_EmployeeGrade = new SMHR_EMPLOYEEGRADE_SLAB();
                _obj_Smhr_EmployeeGrade.EMPLOYEEGRADE_SLAB_EMPLOYEEGRADE_ID = Convert.ToInt32(rcmb_Grade.SelectedItem);
                _obj_Smhr_EmployeeGrade.OPERATION = operation.Employeegrades;
                _obj_Smhr_EmployeeGrade.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_EmployeeGrade.EMPLOYEEGRADE_SLAB_PERIOD_ID = Convert.ToInt32(rcmb_period.SelectedValue);

                DataTable dt = new DataTable();
                dt = BLL.get_EmployeeGrades(_obj_Smhr_EmployeeGrade);

                if (dt.Rows.Count > 0)
                {
                    rcmb_Grade.DataSource = dt;
                    rcmb_Grade.DataTextField = "EMPLOYEEGRADE_SLAB_EMPLOYEEGRADE_CODE";
                    rcmb_Grade.DataValueField = "EMPLOYEEGRADE_SLAB_EMPLOYEEGRADE_ID";
                    rcmb_Grade.DataBind();
                }
                rcmb_Grade.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                //rcmb_period.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                rcmb_Grade.Enabled = true;
                rcmb_period.Enabled = true;
            }
            else
            {
                rcmb_Grade.SelectedIndex = 0;
                rcmb_Slabs.Items.Clear();
                rcmb_period.ClearSelection();
                rcmb_period.Text = string.Empty;
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpTransfer", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
