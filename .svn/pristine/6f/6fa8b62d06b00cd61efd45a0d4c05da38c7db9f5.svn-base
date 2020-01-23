using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using SPMS;
using Telerik.Web.UI;
public partial class PMS_frmIDP : System.Web.UI.Page
{
    pms_IDPSCREEN _obj_idp;
    PMS_EMPSETUP _obj_Pms_EmpSetup;
    PMS_GETEMPLOYEE _obj_PMS_getemployee;
    PMS_GoalSettings _obj_GS;
    PMS_Appraisalcycle _obj_Pms_Appraisalcycle;
    #region Page_load
    /// <summary>
    /// Here Page_Load Method...For Load a Page..
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    { try
        {
        if (!Page.IsPostBack)
        {
            Session.Remove("WRITEFACILITY");

            SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

            _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
            _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
            _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("IDP");
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

            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                RG_Idpform.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;



            }
            clearfields();
          
            loadgrid();
            RG_Idpform.DataBind();
            RM_Idpform.SelectedIndex = 0;
            RP_Idpform.Visible = true;
            RP_Idpform2.Visible = false;

        }
        Page.Validate();
        //RDP_StartDate.MinDate = DateTime.Now;
        //RDP_EndDate.MinDate = DateTime.Now;
        }

    catch (Exception ex)
    {
        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_idp", ex.StackTrace, DateTime.Now);
        Response.Redirect("~/Frm_ErrorPage.aspx");
    }
    }
    #endregion

    #region loadgrid()
    /// <summary>
    /// Here loadgrid() method for load a grid...
    /// </summary>
    protected void loadgrid()
    {
        try
        {
        _obj_idp = new pms_IDPSCREEN();
        _obj_idp.IDP_MODE = 1;
        _obj_idp.IDP_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
        _obj_idp.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
        DataTable dt = Pms_Bll.get_idp(_obj_idp);
        if (dt.Rows.Count != 0)
        {

            RG_Idpform.DataSource = dt;
        }
        else
        {
            DataTable dt1 = new DataTable();
            RG_Idpform.DataSource = dt1;
        }

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_idp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    #region clearfields()
    /// <summary>
    /// Here clearfields() method for clearfields..
    /// </summary>
    protected void clearfields()
    {
        try
        {
            RCB_BusinessUnit.SelectedValue = string.Empty;
            RCB_EmployeeName.ClearSelection();
            RCB_EmployeeName.Items.Clear();
            RCB_EmployeeName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            //rcm_apprcycle.ClearSelection();
            //rcm_apprcycle.Items.Clear();
            //rcm_apprcycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            //RCB_EmployeeName.SelectedValue = string.Empty;
            txt_IDP.Text = string.Empty;
            txt_Description.Text = string.Empty;
            RDP_StartDate.SelectedDate = null;
            //RDP_EndDate.SelectedDate = null;
            txt_Comments.Text = string.Empty;
            rcmb_status.SelectedValue = "1";
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_idp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


    }
    #endregion

    #region  lnk_Add_Command
    /// <summary>
    /// Here Transfer To Next View..
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {try
        {
        clearfields();
        btn_SAVE.Visible = true;
        btn_UPDATE.Visible = false;
       
        RM_Idpform.SelectedIndex = 1;
        RP_Idpform.Visible = false;
        RP_Idpform2.Visible = true;
        
        //_obj_Pms_EmpSetup = new PMS_EMPSETUP();

        //_obj_PMS_getemployee = new PMS_GETEMPLOYEE();

        //if ((Convert.ToString(Session["EMP_TYPE"])) == "5")
        //{
        //    _obj_PMS_getemployee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
        //}
        //else
        //{
        //    _obj_PMS_getemployee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);

        //}
        //_obj_PMS_getemployee.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
        //_obj_PMS_getemployee.Mode = 1;
        //DataTable dtbuid = Pms_Bll.get_RMEmployees(_obj_PMS_getemployee);



        //if (dtbuid.Rows.Count != 0)
        //{
        //    RCB_EmployeeName.DataSource = dtbuid;
        //    RCB_EmployeeName.DataTextField = "employee";
        //    RCB_EmployeeName.DataValueField = "EMPID";
        //    RCB_EmployeeName.DataBind();
        //    RCB_EmployeeName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        //    //RCB_BusinessUnit.Visible = false;
        //    //lbl_BusinessUnit.Visible = false;

        //}
        //else
        //{
        //    DataTable dt1 = new DataTable();

        //    RCB_EmployeeName.DataSource = dt1;
        //    RCB_EmployeeName.DataBind();
        //    //lbl_BusinessUnit.Visible = false;
        //    //RCB_BusinessUnit.Visible = false;


        //}
        loadBusinessUnit();
        //DataTable dt1 = new DataTable();

        //RCB_EmployeeName.DataSource = dt1;
        //RCB_EmployeeName.DataBind();
        RCB_BusinessUnit.Enabled = true;
        RCB_EmployeeName.Enabled = true;
        txt_IDP.Enabled = true;
        RDP_StartDate.Enabled = true;
        rcmb_status.SelectedValue = "1";
        //RDP_EndDate.Enabled = true;
        //DataTable dt6 = new DataTable();
        //rcm_apprcycle.DataSource = dt6;
        //rcm_apprcycle.DataBind();
        //rcm_apprcycle.SelectedIndex = 0;
        //rcm_apprcycle.Enabled = true;


        }

    catch (Exception ex)
    {
        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_idp", ex.StackTrace, DateTime.Now);
        Response.Redirect("~/Frm_ErrorPage.aspx");
    }
    }
    #endregion



    #region LoadAppraisalcycle
    /// <summary>
    /// HERE I AM LOADING Goals DETAILS FROM PREVIOUS GOAL SETTING DETAILS TABLE
    /// </summary>

    //protected void LoadAppraisalCycle()
    //{
    //    try
    //    {
    //    //PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
    //    //_obj_Pms_Appraisalcycle.MODE = 11;
    //    //_obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(Session["EMP_ID"]);//where i am passing employee to get bunit
    //    //DataTable dtem = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


    //    //_obj_Pms_Appraisalcycle.MODE = 7;
    //    //_obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem.Rows[0]["EMP_BUSINESSUNIT_ID"]);

    //        //COMMENTED ON 21.12.2011
    //    // _obj_GS = new PMS_GoalSettings();
    //    //_obj_GS.GS_MODE = 22;//YYY
    //    //_obj_GS.GS_EMP_ID = Convert.ToInt32((RCB_EmployeeName.SelectedItem.Value));

    //    //_obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["org_id"]);


    //    //DataTable dt = Pms_Bll.get_GS(_obj_GS);
    //    //if (dt.Rows.Count != 0)
    //    //{
    //    //    rcm_apprcycle.DataSource = dt;
    //    //    rcm_apprcycle.DataTextField = "APPRCYCLE_NAME";
    //    //    rcm_apprcycle.DataValueField = "APPRCYCLE_ID";
    //    //    rcm_apprcycle.DataBind();
    //    //    rcm_apprcycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
    //    //}
    //    //else
    //    //{
    //    //    DataTable dt44 = new DataTable();
    //    //    rcm_apprcycle.DataSource = dt44;
    //    //    rcm_apprcycle.DataBind();
    //    //    rcm_apprcycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

    //    //}


    //        rcm_apprcycle.Items.Clear();
    //        _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();

    //        _obj_Pms_Appraisalcycle.MODE = 9;
    //        if (Convert.ToInt32(RCB_BusinessUnit.SelectedItem.Value) > 0)
    //        {
    //            //_obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dt.Rows[0]["BUSINESSUNIT_ID"]);
    //            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(RCB_BusinessUnit.SelectedItem.Value);
    //        }
    //        else
    //        {
    //            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;
    //        }
    //        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["org_id"]);
    //        DataTable DT_AppraisalCycle = new DataTable();
    //        DT_AppraisalCycle = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
    //        if (DT_AppraisalCycle.Rows.Count != 0)
    //        {
    //            rcm_apprcycle.DataSource = DT_AppraisalCycle;
    //            rcm_apprcycle.DataTextField = "APPRCYCLE_NAME";
    //            rcm_apprcycle.DataValueField = "APPRCYCLE_ID";
    //            rcm_apprcycle.DataBind();
    //            rcm_apprcycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
    //        }
    //        else
    //        {
    //            DataTable dt6 = new DataTable();

    //            rcm_apprcycle.DataSource = dt6;

    //            rcm_apprcycle.DataBind();
    //            rcm_apprcycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

    //        }

    //    }

    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_idp", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}
    #endregion

    #region LoadAppraisalcycle
    /// <summary>
    /// HERE I AM LOADING Goals DETAILS FROM PREVIOUS GOAL SETTING DETAILS TABLE
    /// </summary>

    //protected void LoadAppraisalCycle1()
    //{ try
    //    {
    //     _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
    //    _obj_Pms_Appraisalcycle.MODE = 11;
    //    _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(Session["empid1"]);
    //    //where i am passing employee to get bunit
    //    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
    //    DataTable dtem = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


    //    _obj_Pms_Appraisalcycle.MODE = 7;
    //    if (dtem.Rows.Count != 0)
    //    {
    //        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem.Rows[0]["EMP_BUSINESSUNIT_ID"]);
    //    }

    //    else
    //    {
    //        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;
    //    }

    //    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);

    //    DataTable dt = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
    //    if (dt.Rows.Count != 0)
    //    {
    //        rcm_apprcycle.DataSource = dt;
    //        rcm_apprcycle.DataTextField = "APPRCYCLE_NAME";
    //        rcm_apprcycle.DataValueField = "APPRCYCLE_ID";
    //        rcm_apprcycle.DataBind();
    //        rcm_apprcycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
    //    }
    //    else
    //    {
    //        DataTable dt44 = new DataTable();
    //        rcm_apprcycle.DataSource = dt44;
    //        rcm_apprcycle.DataBind();
    //        rcm_apprcycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

    //    }

    //    }

    //catch (Exception ex)
    //{
    //    SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_idp", ex.StackTrace, DateTime.Now);
    //    Response.Redirect("~/Frm_ErrorPage.aspx");
    //}
    //}
    #endregion
    #region loadBusinessUnit()
    /// <summary>
    /// Here LoadBusinesssUnit() For Load BusinessUnit ComboBox..
    /// </summary>
    protected void loadBusinessUnit()
    {
        try
        {
        SMHR_BUSINESSUNIT _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
        DataTable dt_Details = new DataTable();

        SMHR_LOGININFO _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
        _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
        _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
        DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
        if (dt_BUDetails.Rows.Count != 0)
        {
            RCB_BusinessUnit.DataSource = dt_BUDetails;
            RCB_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            RCB_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            RCB_BusinessUnit.DataBind();
            RCB_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

        }

        else
        {
            DataTable dt2 = new DataTable();
            RCB_BusinessUnit.DataSource = dt2;
            RCB_BusinessUnit.DataBind();
            RCB_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

        }
       
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_idp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    #region RCB_BusinessUnit_SelectedIndexChanged
    /// <summary>
    /// Here RCB_BusinessUnit_SelectedIndexChanged for Getting Business Unit From SMHR...
    /// </summary>
    /// <param name="o"></param>
    /// <param name="e"></param>
    protected void RCB_BusinessUnit_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            //LoadEmployees();

            if (RCB_BusinessUnit.SelectedIndex > 0)
            {
                _obj_Pms_EmpSetup = new PMS_EMPSETUP();

                _obj_PMS_getemployee = new PMS_GETEMPLOYEE();

                if ((Convert.ToString(Session["EMP_TYPE"])) == "5")
                {
                    _obj_PMS_getemployee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                }
                else
                {
                    _obj_PMS_getemployee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);

                }
                _obj_PMS_getemployee.BU_ID = Convert.ToInt32(RCB_BusinessUnit.SelectedItem.Value);
                _obj_PMS_getemployee.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                _obj_PMS_getemployee.Mode = 4;
                DataTable dtbuid = Pms_Bll.get_RMEmployees(_obj_PMS_getemployee);

                if (dtbuid.Rows.Count != 0)
                {
                    RCB_EmployeeName.DataSource = dtbuid;
                    RCB_EmployeeName.DataTextField = "employee";
                    RCB_EmployeeName.DataValueField = "EMPID";
                    RCB_EmployeeName.DataBind();
                    RCB_EmployeeName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                    //RCB_BusinessUnit.Visible = false;
                    //lbl_BusinessUnit.Visible = false;

                }
                else
                {
                    DataTable dt1 = new DataTable();

                    RCB_EmployeeName.DataSource = dt1;
                    RCB_EmployeeName.DataBind();
                    //lbl_BusinessUnit.Visible = false;
                    //RCB_BusinessUnit.Visible = false;


                }
                //LoadAppraisalCycle();
            }
            else
            {
                RCB_EmployeeName.ClearSelection();
                RCB_EmployeeName.Items.Clear();
                RCB_EmployeeName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                //rcm_apprcycle.ClearSelection();
                //rcm_apprcycle.Items.Clear();
                //rcm_apprcycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_idp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    #region BindEmployees()
    /// <summary>
    /// Here BindEmployees() for EmployeeName Combobox.. 
    /// </summary>
    /// <param name="dt"></param>
    protected void BindEmployees(DataTable dt)
    {
        try
        {
        RCB_EmployeeName.Items.Clear();
        RCB_EmployeeName.DataSource = dt;
        RCB_EmployeeName.DataTextField = "Empname";
        RCB_EmployeeName.DataValueField = "EMP_ID";
        RCB_EmployeeName.DataBind();
        RCB_EmployeeName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_idp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    #region LoadEmployees()
    /// <summary>
    /// Here LoadEmployees() for LoadEmployee..
    /// </summary>
    private void LoadEmployees()
    {try
        {
        SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
        _obj_smhr_emp_payitems.OPERATION = operation.Empty;
        DataTable DT_Details = new DataTable();

        if (RCB_BusinessUnit.SelectedItem.Value != "")
        {
            _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(RCB_BusinessUnit.SelectedItem.Value);
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
            BindEmployees(DT_Details);
        }

        }

    catch (Exception ex)
    {
        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_idp", ex.StackTrace, DateTime.Now);
        Response.Redirect("~/Frm_ErrorPage.aspx");
    }
    }
    #endregion

    #region btn_SAVE_Click
    /// <summary>
    /// Here Insert a Record..
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_SAVE_Click(object sender, EventArgs e)
    {
        try
        {
        _obj_idp = new pms_IDPSCREEN();
        _obj_idp.IDP_MODE = 7;
        _obj_idp.IDP_NAME = Pms_Bll.ReplaceQuote(Convert.ToString(txt_IDP.Text));
        _obj_idp.IDP_EMP_ID = Convert.ToInt32(RCB_EmployeeName.SelectedItem.Value);
        _obj_idp.IDP_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
        DataTable dt = Pms_Bll.get_idp(_obj_idp);
        if (dt.Rows.Count != 0)
        {
            Pms_Bll.ShowMessage(this, "IDP Already Exist");
            return;
        }
        else
        {
            //COMMENTED ON 11.01.2012
            //if (Convert.ToDateTime(Convert.ToDateTime(RDP_StartDate.SelectedDate).ToShortDateString()) < Convert.ToDateTime(DateTime.Now.Date))
            //{
            //    RDP_StartDate.Clear();
            //    //RDP_EndDate.Clear();
            //    Pms_Bll.ShowMessage(this, "StartDate Should Be Greater Than Current Date");
            //    return;
            //}

            //COMMENTED ON 23.12.2011
            //PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            ////_obj_Pms_Appraisalcycle.MODE = 11;
            ////_obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(Session["EMP_ID"]);//where i am passing employee to get bunit
            ////_obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            ////DataTable dtem = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


            //_obj_Pms_Appraisalcycle.MODE = 7;
            ////if (dtem.Rows.Count != 0)
            ////{
            //    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(RCB_BusinessUnit.SelectedItem.Value);
            ////}
            ////else
            ////{
            ////    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;
            ////}


            //_obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            //DataTable dt22 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

          

            //    DateTime dt_st = Convert.ToDateTime(dt22.Rows[0]["APPCYCLE_STARTDATE"]);
            //    DateTime dt_et = Convert.ToDateTime(dt22.Rows[0]["APPCYCLE_ENDDATE"]);


            //    if ((RDP_StartDate.SelectedDate.Value > dt_et) || (RDP_StartDate.SelectedDate.Value < dt_st))
            //    {
            //        BLL.ShowMessage(this, "Date Should Validate With Appraisal Cycle Date");
            //        return;
            //    }
            //    if ((RDP_EndDate.SelectedDate.Value > dt_et) || (RDP_EndDate.SelectedDate.Value < dt_st))
            //    {
            //        BLL.ShowMessage(this, "Date Should Validate With Appraisal Cycle Date");
            //        return;
            //    }

            if (txt_Comments.Text.Length > 1000)
            {
                BLL.ShowMessage(this, "Comments length should be Less Than 1000.");
                return;
            }
            if (txt_IDP.Text.Length > 1000)
            {
                BLL.ShowMessage(this, "IDP length should be Less Than 1000.");
                return;
            }
            if (txt_Description.Text.Length > 1000)
            {
                BLL.ShowMessage(this, "Description length should be Less Than 1000.");
                return;
            }
            _obj_idp = new pms_IDPSCREEN();
            _obj_idp.IDP_MODE = 4;
           
            _obj_idp.IDP_EMP_ID = Convert.ToInt32(RCB_EmployeeName.SelectedValue);
            _obj_idp.IDP_NAME = Pms_Bll.ReplaceQuote(Convert.ToString(txt_IDP.Text));
            _obj_idp.IDP_DESCRIPTION = Pms_Bll.ReplaceQuote(Convert.ToString(txt_Description.Text));
            _obj_idp.IDP_STARTDATE = RDP_StartDate.SelectedDate.Value;
            //_obj_idp.IDP_ENDDATE = RDP_EndDate.SelectedDate.Value;
            _obj_idp.LASTMDFBY = Convert.ToInt32(Session["user_id"]);
            _obj_idp.LASTMDFDATE = DateTime.Now;
            _obj_idp.CREATEDBY = Convert.ToInt32(Session["user_id"]);// ### Need to Get the Session
            _obj_idp.CREATEDDATE = DateTime.Now;
            //_obj_idp.IDP_APPRAISALCYCLE = Convert.ToInt32(rcm_apprcycle.SelectedItem.Value);
            _obj_idp.IDP_COMMENTS = Convert.ToString(txt_Comments.Text.Replace("'", "''"));
            _obj_idp.IDP_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_idp.IDP_STATUS = Convert.ToInt32(rcmb_status.SelectedItem.Text);
            bool status = Pms_Bll.set_idp(_obj_idp);
            if (status == true)
            {
                Pms_Bll.ShowMessage(this, "IDP Inserted Succesfully");
                loadgrid();
                RG_Idpform.DataBind();
                clearfields();





                RM_Idpform.SelectedIndex = 0;
                RP_Idpform.Visible = true;
                RP_Idpform2.Visible = false;
                return;

            }
        }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_idp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    #region  lnk_Edit_Commnad
    /// <summary>
    /// Here Edit a Particular Record..
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnk_Edit_Commnad(object sender, CommandEventArgs e)
    {
      
        try
        {
        clearfields();
        _obj_idp = new pms_IDPSCREEN();
        _obj_idp.IDP_MODE = 2;
        _obj_idp.IDP_ID = Convert.ToInt32(e.CommandArgument);
        DataTable DT = Pms_Bll.get_idp(_obj_idp);
        if (DT.Rows.Count != 0)
        {
            lbl_id.Text = Convert.ToString(DT.Rows[0]["IDP_ID"]);
            Session["empid1"] = (DT.Rows[0]["IDP_EMP_ID"]);
            _obj_idp = new pms_IDPSCREEN();
            _obj_idp.IDP_MODE = 6;
            _obj_idp.IDP_EMP_ID = Convert.ToInt32(Convert.ToString(DT.Rows[0]["IDP_EMP_ID"]));
            _obj_idp.IDP_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Bus = Pms_Bll.get_idp(_obj_idp);
            loadBusinessUnit();

            if (dt_Bus.Rows.Count != 0)
            {
                RCB_BusinessUnit.SelectedIndex = RCB_BusinessUnit.Items.FindItemIndexByValue(Convert.ToString(dt_Bus.Rows[0]["EMP_BUSINESSUNIT_ID"]));
            }
                //LoadEmployees();

            _obj_Pms_EmpSetup = new PMS_EMPSETUP();

            _obj_PMS_getemployee = new PMS_GETEMPLOYEE();

            if ((Convert.ToString(Session["EMP_TYPE"])) == "5")
            {
                _obj_PMS_getemployee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            }
            else
            {
                _obj_PMS_getemployee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);

            }

            _obj_PMS_getemployee.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
            _obj_PMS_getemployee.BU_ID = Convert.ToInt32(RCB_BusinessUnit.SelectedItem.Value);
            _obj_PMS_getemployee.Mode = 5;
            DataTable dtbuid = Pms_Bll.get_RMEmployees(_obj_PMS_getemployee);



            if (dtbuid.Rows.Count != 0)
            {
                RCB_EmployeeName.DataSource = dtbuid;
                RCB_EmployeeName.DataTextField = "employee";
                RCB_EmployeeName.DataValueField = "EMPID";
                RCB_EmployeeName.DataBind();
                RCB_EmployeeName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                //RCB_BusinessUnit.Visible = false;
                //lbl_BusinessUnit.Visible = false;

            }
            else
            {
                DataTable dt1 = new DataTable();

                RCB_EmployeeName.DataSource = dt1;
                RCB_EmployeeName.DataBind();
                //lbl_BusinessUnit.Visible = false;
                //RCB_BusinessUnit.Visible = false;


            }
            RCB_EmployeeName.SelectedIndex = RCB_EmployeeName.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["IDP_EMP_ID"]));
            //LoadAppraisalCycle1();
            //rcm_apprcycle.SelectedIndex = rcm_apprcycle.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["IDP_APPRAISALCYCLE"]));
            txt_IDP.Text = Pms_Bll.ReplaceQuote(Convert.ToString(DT.Rows[0]["IDP_NAME"]));
            txt_Description.Text = Pms_Bll.ReplaceQuote(Convert.ToString(DT.Rows[0]["IDP_DESCRIPTION"]));
            RDP_StartDate.SelectedDate = Convert.ToDateTime(DT.Rows[0]["IDP_STARTDATE"]);
            //RDP_EndDate.SelectedDate = Convert.ToDateTime(DT.Rows[0]["IDP_ENDDATE"]);
            txt_Comments.Text = Convert.ToString(DT.Rows[0]["IDP_COMMENTS"]);
            if (DT.Rows[0]["IDP_STATUS"] != System.DBNull.Value)
            {
                if (Convert.ToString(DT.Rows[0]["IDP_STATUS"]).Trim() == "Active")
                    rcmb_status.SelectedValue = "1";
                else
                    rcmb_status.SelectedValue = "0";
            }
            else
            {
                rcmb_status.SelectedValue = "0";
            }
            RM_Idpform.SelectedIndex = 1;
            RP_Idpform.Visible = false;
            RP_Idpform2.Visible = true;
            btn_SAVE.Visible = false;
            btn_UPDATE.Visible = true;
            RCB_BusinessUnit.Enabled = false;
            RCB_EmployeeName.Enabled = false;
            txt_IDP.Enabled = false;
            //lbl_BusinessUnit.Visible = false;
            //RCB_BusinessUnit.Visible = false;
            txt_Comments.Enabled = true;
            RDP_StartDate.Enabled = false;
            //RDP_EndDate.Enabled = true;
            //rcm_apprcycle.Enabled = false;
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {


                btn_UPDATE.Visible = false;

            }
            else
            {
                btn_UPDATE.Visible = true;
                if (rcmb_status.SelectedValue == "0")
                {
                    BLL.ShowMessage(this, "IDP is Inactive.You can not Update the record.");
                    btn_UPDATE.Visible = false;
                }
            }
            
        }

        else
        {

        }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_idp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    #endregion

    #region btn_CANCEL_Click
    /// <summary>
    /// Here Cancel Operation..
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_CANCEL_Click(object sender, EventArgs e)
    {try
        {
        loadgrid();
        RM_Idpform.SelectedIndex = 0;
        RP_Idpform.Visible = true;
        RP_Idpform2.Visible = false;
        }

    catch (Exception ex)
    {
        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_idp", ex.StackTrace, DateTime.Now);
        Response.Redirect("~/Frm_ErrorPage.aspx");
    }
    }
    #endregion

    #region btn_UPDATE_Click
    /// <summary>
    /// Here Update the Record..
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_UPDATE_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_Comments.Text.Length > 1000)
            {
                BLL.ShowMessage(this, "Comments length should be Less Than 1000.");
                return;
            }
            if (txt_Description.Text.Length > 1000)
            {
                BLL.ShowMessage(this, "Description length should be Less Than 1000.");
                return;
            }
            _obj_idp = new pms_IDPSCREEN();
            _obj_idp.IDP_ID = Convert.ToInt32(lbl_id.Text);
            _obj_idp.IDP_EMP_ID = Convert.ToInt32(RCB_EmployeeName.SelectedValue);
            _obj_idp.IDP_NAME = Pms_Bll.ReplaceQuote(Convert.ToString(txt_IDP.Text));
            _obj_idp.IDP_DESCRIPTION = Pms_Bll.ReplaceQuote(Convert.ToString(txt_Description.Text));
          
            //_obj_idp.IDP_EMP_ID = 6;
            _obj_idp.IDP_STARTDATE = RDP_StartDate.SelectedDate.Value;
            //_obj_idp.IDP_ENDDATE = RDP_EndDate.SelectedDate.Value;
            _obj_idp.IDP_COMMENTS = Convert.ToString(txt_Comments.Text.Replace("'", "''"));
            _obj_idp.LASTMDFBY = Convert.ToInt32(Session["user_id"]);
            _obj_idp.LASTMDFDATE = DateTime.Now;
            _obj_idp.IDP_MODE = 5;
            //_obj_idp.IDP_APPRAISALCYCLE = Convert.ToInt32(rcm_apprcycle.SelectedItem.Value);
           
            bool status = Pms_Bll.set_idp(_obj_idp);
            if (status == true)
            {
                Pms_Bll.ShowMessage(this, "IDP Updated Succesfully");
                loadgrid();

                RG_Idpform.DataBind();
                btn_SAVE.Visible = false;
                RM_Idpform.SelectedIndex = 0;
                RP_Idpform.Visible = true;
                RP_Idpform2.Visible = false;
            }
            else
            {
                Pms_Bll.ShowMessage(this, "Unable to Update the record,Execption Occured");
                return;
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_idp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    #endregion

    #region RG_Idpform_NeedDataSource1()
    /// <summary>
    /// Here Grid Binding..
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void RG_Idpform_NeedDataSource1(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    { try
        {
        loadgrid();

        }

    catch (Exception ex)
    {
        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_idp", ex.StackTrace, DateTime.Now);
        Response.Redirect("~/Frm_ErrorPage.aspx");
    }
    }
    #endregion

    protected void RCB_EmployeeName_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
        //if (RCB_EmployeeName.SelectedItem.Text != "Select")
        //{
        //    LoadAppraisalCycle();
        //}

        //else
        //{
        //    Pms_Bll.ShowMessage(this, "Please Select Employee");
        //    DataTable dt3 = new DataTable();
        //    rcm_apprcycle.DataSource = dt3;
        //    rcm_apprcycle.DataBind();

        //    rcm_apprcycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        //}


        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_idp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
