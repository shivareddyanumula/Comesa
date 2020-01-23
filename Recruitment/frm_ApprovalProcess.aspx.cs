using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using Telerik.Web.UI;
using RECRUITMENT;
using SMHR;
using System.Web.Services;

public partial class Recruitment_frm_ApprovalProcess : System.Web.UI.Page
{
    SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit;
    RECRUITMENT_GETEMPLOYEE _obj_Rec_GetEmployee;
    RECRUITMENT_APPROVALPROCESS _obj_Rec_ApprovalProcess;
    static int OrganizationID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {

            Page.Validate();
            if (!Page.IsPostBack)
            {

                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Approval Process");
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
                    Rg_ApproverProcess.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Save.Visible = false;
                    btn_update.Visible = false;
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
                LoadGrid();

                btn_update.Visible = false;
                OrganizationID = Convert.ToInt32(Session["ORG_ID"]);

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApprovalProcess", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;

        }


    }

    protected override void InitializeCulture()
    {
        Recruitment_BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    protected void rgap_needsource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            _obj_Rec_ApprovalProcess = new RECRUITMENT_APPROVALPROCESS();
            _obj_Rec_ApprovalProcess.Mode = 1;
            _obj_Rec_ApprovalProcess.APPRO_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = Recruitment_BLL.get_EmpSetup(_obj_Rec_ApprovalProcess);
            if (dt.Rows.Count != 0)
            {
                Rg_ApproverProcess.DataSource = dt;

            }
            if (Rg_ApproverProcess.Items.Count > 0)
            {
                Rg_ApproverProcess.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
            }
            else
            {
                Rg_ApproverProcess.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Top;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApprovalProcess", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void LoadGrid()
    {
        try
        {
            _obj_Rec_ApprovalProcess = new RECRUITMENT_APPROVALPROCESS();
            _obj_Rec_ApprovalProcess.Mode = 1;
            _obj_Rec_ApprovalProcess.APPRO_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = Recruitment_BLL.get_EmpSetup(_obj_Rec_ApprovalProcess);
            if (dt.Rows.Count != 0)
            {
                Rg_ApproverProcess.DataSource = dt;

                Rg_ApproverProcess.DataBind();
            }
            else
            {
                DataTable dt1 = new DataTable();

                Rg_ApproverProcess.DataSource = dt1;

                Rg_ApproverProcess.DataBind();
            }
            if (Rg_ApproverProcess.Items.Count > 0)
            {
                Rg_ApproverProcess.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                Rg_ApproverProcess.Rebind();
            }
            else
            {
                Rg_ApproverProcess.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Top;
                Rg_ApproverProcess.Rebind();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApprovalProcess", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void LoadBusinessUnit()
    {
        try
        {
            //_obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            //_obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //_obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            //DataTable dt_BUDetails = Recruitment_BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            //rcmb_BusinessUnitType.DataSource = dt_BUDetails;
            //rcmb_BusinessUnitType.DataTextField = "BUSINESSUNIT_CODE";
            //rcmb_BusinessUnitType.DataValueField = "BUSINESSUNIT_ID";
            //rcmb_BusinessUnitType.DataBind();
            //rcmb_BusinessUnitType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));





            //_obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
            //_obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            ////_obj_Smhr_BusinessUnit.ISDELETED = true;
            //_obj_Smhr_BusinessUnit.OPERATION = operation.Select;
            //DataTable dt_bus = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
            //rcmb_BusinessUnitType.Items.Clear();
            //rcmb_BusinessUnitType.DataSource = dt_bus;
            //rcmb_BusinessUnitType.DataTextField = "BUSINESSUNIT_CODE";
            //rcmb_BusinessUnitType.DataValueField = "BUSINESSUNIT_ID";
            //rcmb_BusinessUnitType.DataBind();
            //rcmb_BusinessUnitType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApprovalProcess", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_2Level_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
           

            if (rcmb_2Level.SelectedValue=="")
            {
                rcmb_2Level.Text = string.Empty;
                BLL.ShowMessage(this, "please select 2 Level approver");
                return;
            }
         
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApprovalProcess", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_3Level_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {


            if (rcmb_3Level.SelectedValue == "")
            {
                rcmb_3Level.Text = string.Empty;
                BLL.ShowMessage(this, "please select 3 Level approver");
                return;
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApprovalProcess", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_1Level_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {


            if (rcmb_1Level.SelectedValue == "")
            {
                rcmb_1Level.Text = string.Empty;
                BLL.ShowMessage(this, "please select 1 Level approver");
                return;
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApprovalProcess", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    private void LoadEmployees(RadComboBox rcmb)
    {
        try
        {

            _obj_Rec_GetEmployee = new RECRUITMENT_GETEMPLOYEE();
            _obj_Rec_GetEmployee.Mode = 1;
            DataTable DT_Details = new DataTable();
            ////if (rcmb_BusinessUnitType.SelectedItem.Value != "")
            ////{
            ////    _obj_Rec_GetEmployee.APPRO_BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
            //    DT_Details = Recruitment_BLL.get_Employee(_obj_Rec_GetEmployee);
            //    if (DT_Details.Rows.Count != 0)
            //    {
            //        BindEmployees(DT_Details, rcmb);
            //    }
            //    else
            //    {
            //        BindEmployees(DT_Details, rcmb);
            //    }
            //}
            //else
            //{
            BindEmployees(DT_Details, rcmb);
            // }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApprovalProcess", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    [WebMethod]
    public static RadComboBoxItemData[] GET_EmployeeBySearchString(object context)
    {
      
       
            IDictionary<string, object> contextDictionary = (IDictionary<string, object>)context;

            string filterString = ((string)contextDictionary["FilterString"]).Length > 2 ? ((string)contextDictionary["FilterString"]).ToLower() : "";

            DataTable dtEMPData = BLL.get_EmployeeBySearchString(OrganizationID, filterString);

            List<RadComboBoxItemData> result = new List<RadComboBoxItemData>(dtEMPData.Rows.Count);
            
            foreach (DataRow row in dtEMPData.Rows)
            {
                RadComboBoxItemData itemData = new RadComboBoxItemData();
                itemData.Text = row["EMPNAME"].ToString();
                itemData.Value = row["EMP_ID"].ToString();
                result.Add(itemData);
            }
      
        return result.ToArray();
    }
    protected void BindEmployees(DataTable dt, RadComboBox rcmb)
    {
        try
        {
            rcmb.Items.Clear();
            rcmb.DataSource = dt;
            rcmb.DataTextField = "EMPNAME";
            rcmb.DataValueField = "EMP_ID";
            rcmb.DataBind();
            rcmb.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            rcmb.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApprovalProcess", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //private void LoadLevel2()
    //{
    //    try
    //    {

    //        _obj_Rec_GetEmployee = new RECRUITMENT_GETEMPLOYEE();
    //        _obj_Rec_GetEmployee.Mode = 2;
    //        DataTable DT_Details = new DataTable();
    //        if (rcmb_1Level.SelectedValue != "")
    //        {
    //            _obj_Rec_GetEmployee.APPRO_BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
    //            _obj_Rec_GetEmployee.APPRO_EMP_ID = Convert.ToInt32(rcmb_1Level.SelectedValue);
    //            DT_Details = Recruitment_BLL.get_Employee(_obj_Rec_GetEmployee);
    //            if (DT_Details.Rows.Count != 0)
    //            {
    //                BindLevel2(DT_Details);
    //            }
    //            else
    //            {
    //                BindLevel2(DT_Details);
    //            }
    //        }
    //        else
    //        {
    //            BindLevel2(DT_Details);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApprovalProcess", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}

    protected void BindLevel2(DataTable dt)
    {
        try
        {
            rcmb_2Level.Items.Clear();
            rcmb_2Level.DataSource = dt;
            rcmb_2Level.DataTextField = "EMPNAME";
            rcmb_2Level.DataValueField = "EMP_ID";
            rcmb_2Level.DataBind();
            rcmb_2Level.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            rcmb_2Level.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApprovalProcess", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //private void LoadLevel3()
    //{
    //    try
    //    {

    //        _obj_Rec_GetEmployee = new RECRUITMENT_GETEMPLOYEE();
    //        _obj_Rec_GetEmployee.Mode = 3;
    //        DataTable DT_Details = new DataTable();
    //        if (rcmb_1Level.SelectedValue != "")
    //        {
    //            _obj_Rec_GetEmployee.APPRO_BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
    //            _obj_Rec_GetEmployee.APPRO_EMP_ID = Convert.ToInt32(rcmb_1Level.SelectedValue);
    //            _obj_Rec_GetEmployee.APPRO_APPROVER1_ID = Convert.ToInt32(rcmb_2Level.SelectedValue);
    //            DT_Details = Recruitment_BLL.get_Employee(_obj_Rec_GetEmployee);
    //            if (DT_Details.Rows.Count != 0)
    //            {
    //                BindLevel3(DT_Details);
    //            }
    //            else
    //            {
    //                BindLevel3(DT_Details);
    //            }
    //        }
    //        else
    //        {
    //            BindLevel3(DT_Details);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApprovalProcess", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}

    protected void BindLevel3(DataTable dt)
    {
        try
        {
            rcmb_3Level.Items.Clear();
            rcmb_3Level.DataSource = dt;
            rcmb_3Level.DataTextField = "EMPNAME";
            rcmb_3Level.DataValueField = "EMP_ID";
            rcmb_3Level.DataBind();
            rcmb_3Level.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApprovalProcess", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;

        }
    }


    //private void LoadHR()
    //{
    //    try
    //    {

    //        _obj_Rec_GetEmployee = new RECRUITMENT_GETEMPLOYEE();
    //        _obj_Rec_GetEmployee.Mode = 4;
    //        DataTable DT_Details = new DataTable();
    //        if (rcmb_EmployeeType.SelectedItem.Value != "")
    //        {
    //            _obj_Rec_GetEmployee.APPRO_BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
    //            _obj_Rec_GetEmployee.APPRO_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
    //            _obj_Rec_GetEmployee.APPRO_APPROVER1_ID = Convert.ToInt32(rcmb_Approver1.SelectedItem.Value);
    //            DT_Details = Recruitment_BLL.get_Employee(_obj_Rec_GetEmployee);
    //            if (DT_Details.Rows.Count != 0)
    //            {
    //                BindApprover2(DT_Details);
    //            }
    //            else
    //            {
    //                BindApprover2(DT_Details);
    //            }
    //        }
    //        else
    //        {
    //            BindApprover2(DT_Details);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApprovalProcess", ex.StackTrace, DateTime.Now);
    //        return;
    //    }
    //}

    //protected void BindApprover2(DataTable dt)
    //{
    //    rcmb_Approver2.Items.Clear();
    //    rcmb_Approver2.DataSource = dt;
    //    rcmb_Approver2.DataTextField = "EMPNAME";
    //    rcmb_Approver2.DataValueField = "EMP_ID";
    //    rcmb_Approver2.DataBind();
    //    rcmb_Approver2.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
    //}


    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {

            btn_Save.Text = "Save";
            DataTable dt = new DataTable();
            rcmb_1Level.DataSource = dt;
            rcmb_1Level.DataBind();
            rcmb_3Level.DataSource = dt;
            rcmb_3Level.DataBind();
            rcmb_2Level.DataSource = dt;
            rcmb_2Level.DataBind();
            Rm_ApproverProcess_PAGE.SelectedIndex = 1;
            // rcmb_BusinessUnitType.Enabled = true;
            rcmb_1Level.Enabled = true;
            rcmb_2Level.Enabled = true;
            btn_update.Visible = false;
            btn_Save.Visible = true;
            ClearControls();
            //LoadBusinessUnit();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApprovalProcess", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    //protected void rcmb_BusinessUnitType_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    //{
    //    LoadEmployees(rcmb_1Level);
    //    LoadEmployees(rcmb_2Level);
    //    LoadEmployees(rcmb_3Level);
    //}

    //protected void rcmb_1Level_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    //{

    //    //LoadLevel2();
    //}

    //protected void rcmb_2Level_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    //{

    //    //LoadLevel3();
    //}

    //protected void rcmb_3Level_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    //{

    //    // rcmb_Approver1.Enabled = false;
    //}

    private bool validateapprovers()
    {
        try
        {
            //if (rcmb_1Level.SelectedItem.Text == rcmb_2Level.SelectedItem.Text && rcmb_1Level.SelectedItem.Text != "Select")
            //{
            //    BLL.ShowMessage(this, "1 Level should not be equal to 2 Level");
            //    return false;
            //}
            //else if (rcmb_1Level.SelectedItem.Text == rcmb_3Level.SelectedItem.Text && rcmb_1Level.SelectedItem.Text != "Select")
            //{
            //    BLL.ShowMessage(this, "1 Level should not be equal to 3 Level");
            //    return false;
            //}

            //else if (rcmb_2Level.SelectedItem.Text == rcmb_3Level.SelectedItem.Text && rcmb_2Level.SelectedItem.Text != "Select")
            //{
            //    BLL.ShowMessage(this, "2 Level should not be equal to 3 Level");
            //    return false;
            //}

            //else
            //{
            //    return true;
            //}

            if (rcmb_1Level.Text == rcmb_2Level.Text && rcmb_1Level.Text != "Select")
            {
                BLL.ShowMessage(this, "1 Level should not be equal to 2 Level");
                return false;
            }
            else if (rcmb_1Level.Text == rcmb_3Level.Text && rcmb_1Level.Text != "Select")
            {
                BLL.ShowMessage(this, "1 Level should not be equal to 3 Level");
                return false;
            }

            else if (rcmb_2Level.Text == rcmb_3Level.Text && rcmb_2Level.Text != "Select")
            {
                BLL.ShowMessage(this, "2 Level should not be equal to 3 Level");
                return false;
            }
            else
            {
                return true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApprovalProcess", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return false;
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                if (validateapprovers())
                {
                    //_obj_Rec_ApprovalProcess = new RECRUITMENT_APPROVALPROCESS();
                    ////_obj_Rec_ApprovalProcess.APPRO_BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
                    //_obj_Rec_ApprovalProcess.APPRO_1LEVEL = Convert.ToInt32(rcmb_2Level.SelectedValue);
                    //_obj_Rec_ApprovalProcess.APPRO_3LEVEL = Convert.ToInt32(rcmb_3Level.SelectedValue);

                    ////if (rcmb_Approver1.SelectedItem.Value  == "0")
                    ////{
                    ////    Recruitment_BLL.ShowMessage(this, "Please Select Approval1");
                    ////    return;
                    ////}
                    //// _obj_Rec_ApprovalProcess.APPRO_APPROVER1_ID = Convert.ToInt32(rcmb_Approver1.SelectedItem.Value);
                    ////if (rcmb_Approver2.SelectedItem.Value != "0")
                    ////{

                    ////    if (chk_Approver2.Checked == false)
                    ////    {
                    ////        Recruitment_BLL.ShowMessage(this, "Please check an Approval2 ");
                    ////        return;

                    ////    }
                    ////}
                    ////if (chk_Approver2.Checked == true)
                    ////{

                    ////    if (rcmb_Approver2.SelectedItem.Value  == "0")
                    ////    {
                    ////        Recruitment_BLL.ShowMessage(this, "Please select approver2");
                    ////        return;

                    ////    }
                    ////}
                    ////_obj_Rec_ApprovalProcess.APPRO_3LEVEL = Convert.ToInt32(rcmb_3Level.SelectedValue);
                    //// _obj_Rec_ApprovalProcess.APPRO_ISAPPROVER2 = Convert.ToBoolean(chk_Approver2.Checked);
                    //_obj_Rec_ApprovalProcess.Mode = 6;
                    //_obj_Rec_ApprovalProcess.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                    //DataTable dtemp = Recruitment_BLL.get_EmpSetup(_obj_Rec_ApprovalProcess);
                    //if (Convert.ToInt32(dtemp.Rows[0]["Count"]) != 0)
                    //{

                    //    Recruitment_BLL.ShowMessage(this, "Business Unit already assigned");
                    //    rcmb_2Level.Enabled = true;
                    //}
                    //else
                    //{

                    _obj_Rec_ApprovalProcess = new RECRUITMENT_APPROVALPROCESS();
                    //_obj_Rec_ApprovalProcess.APPRO_BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
                    _obj_Rec_ApprovalProcess.APPRO_1LEVEL = Convert.ToInt32(rcmb_1Level.SelectedValue);
                    _obj_Rec_ApprovalProcess.APPRO_2LEVEL = Convert.ToInt32(rcmb_2Level.SelectedValue);
                    _obj_Rec_ApprovalProcess.APPRO_3LEVEL = Convert.ToInt32(rcmb_3Level.SelectedValue);
                    // _obj_Rec_ApprovalProcess.APPRO_ISAPPROVER2 = Convert.ToBoolean(chk_Approver2.Checked);
                    _obj_Rec_ApprovalProcess.APPRO_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_Rec_ApprovalProcess.APPRO_CREATEDDATE = DateTime.Now;
                    _obj_Rec_ApprovalProcess.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    //_obj_Rec_ApprovalProcess.APPRO_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    //_obj_Rec_ApprovalProcess.APPRO_LASTMDFDATE = DateTime.Now;
                    _obj_Rec_ApprovalProcess.Mode = 3;
                    bool status = Recruitment_BLL.set_EmpSetup(_obj_Rec_ApprovalProcess);
                    if (status == true)
                    {
                        Recruitment_BLL.ShowMessage(this, "Record Inserted Successfully");

                        btn_Save.Visible = true;
                        LoadGrid();
                        Rm_ApproverProcess_PAGE.SelectedIndex = 0;
                        //DataTable dt = new DataTable();
                        ////rcmb_BusinessUnitType.SelectedIndex = 0;
                        ////rcmb_EmployeeType.SelectedIndex = 0;
                        ////rcmb_Approver1.SelectedIndex = 0;
                        ////rcmb_Approver2.SelectedIndex = 0;
                        ////rcmb_Approver2.Enabled = true;
                        ////rcmb_BusinessUnitType.Enabled = true;
                        ////rcmb_EmployeeType.Enabled = true;
                        //// rcmb_Approver1.Enabled = true;
                        //rcmb_1Level.DataSource = dt;
                        //rcmb_1Level.DataBind();
                        //rcmb_3Level.DataSource = dt;
                        //rcmb_3Level.DataBind();
                        //rcmb_2Level.DataSource = dt;
                        //rcmb_2Level.DataBind();

                        ////chk_Approver2.Checked = false;
                        //return;
                    }

                    //        }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApprovalProcess", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            
            ClearControls();
            btn_update.Visible = true;

            _obj_Rec_ApprovalProcess = new RECRUITMENT_APPROVALPROCESS();
            _obj_Rec_ApprovalProcess.Mode = 2;


            _obj_Rec_ApprovalProcess.APPRO_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            DataTable DT = Recruitment_BLL.get_EmpSetup(_obj_Rec_ApprovalProcess);
            lbl_AP_Id.Text = Convert.ToString(DT.Rows[0]["APPRO_ID"]);

            LinkButton lnkTemp = sender as LinkButton;
            GridDataItem item = lnkTemp.NamingContainer as GridDataItem;

            rcmb_1Level.SelectedValue = item["APPRO_APPROVER1_ID"].Text != "&nbsp;" ? item["APPRO_APPROVER1_ID"].Text : string.Empty;
            rcmb_1Level.Text = item["APPRO_APPROVER1"].Text != "&nbsp;" ? item["APPRO_APPROVER1"].Text : string.Empty;

            rcmb_2Level.SelectedValue = item["APPRO_APPROVER2_ID"].Text != "&nbsp;" ? item["APPRO_APPROVER2_ID"].Text : string.Empty;
            rcmb_2Level.Text = item["APPRO_APPROVER2"].Text != "&nbsp;" ? item["APPRO_APPROVER2"].Text : string.Empty;

            rcmb_3Level.SelectedValue = item["APPRO_APPROVER3_ID"].Text != "&nbsp;" ? item["APPRO_APPROVER3_ID"].Text : string.Empty;
            rcmb_3Level.Text = item["APPRO_APPROVER3"].Text != "&nbsp;" ? item["APPRO_APPROVER3"].Text : string.Empty;


            // //LoadBusinessUnit();
            //// rcmb_BusinessUnitType.SelectedIndex = rcmb_BusinessUnitType.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["APPRO_BU_ID"]));
            // LoadEmployees(rcmb_1Level);
            // rcmb_1Level.SelectedIndex = rcmb_1Level.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["APPRO_APPROVER1_ID"]));

            // //LoadLevel2();
            // LoadEmployees(rcmb_2Level);
            // rcmb_2Level.SelectedIndex = rcmb_2Level.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["APPRO_APPROVER2_ID"]));

            // //LoadLevel3();
            // LoadEmployees(rcmb_3Level);
            // rcmb_3Level.SelectedIndex = rcmb_3Level.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["APPRO_APPROVER3_ID"]));
            //chk_Approver2.Checked = Convert.ToBoolean(DT.Rows[0]["APPRO_ISAPPROVER2"]);
         

            btn_Save.Visible = true;
            rcmb_2Level.Enabled = true;
            Rm_ApproverProcess_PAGE.SelectedIndex = 1;
            // rcmb_BusinessUnitType.Enabled = false;
            rcmb_1Level.Enabled = true;
            rcmb_1Level.Focus();
            btn_Save.Visible = false;

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApprovalProcess", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

  

    protected void btn_update_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                if (validateapprovers())
                {
                    _obj_Rec_ApprovalProcess = new RECRUITMENT_APPROVALPROCESS();

                    _obj_Rec_ApprovalProcess.APPRO_ID = Convert.ToInt32(lbl_AP_Id.Text);
                    // _obj_Rec_ApprovalProcess.APPRO_BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
                    _obj_Rec_ApprovalProcess.APPRO_1LEVEL = Convert.ToInt32(rcmb_1Level.SelectedValue);
                    _obj_Rec_ApprovalProcess.APPRO_2LEVEL = Convert.ToInt32(rcmb_2Level.SelectedValue);
                    _obj_Rec_ApprovalProcess.APPRO_3LEVEL = Convert.ToInt32(rcmb_3Level.SelectedValue);
                    // _obj_Rec_ApprovalProcess.APPRO_ISAPPROVER2 = Convert.ToBoolean(chk_Approver2.Checked);
                    _obj_Rec_ApprovalProcess.APPRO_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_Rec_ApprovalProcess.APPRO_LASTMDFDATE = DateTime.Now;
                    _obj_Rec_ApprovalProcess.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    //if (chk_Approver2.Checked == true)
                    //{

                    //    if (rcmb_Approver2.SelectedItem.Value == "0")
                    //    {
                    //        Recruitment_BLL.ShowMessage(this, "Please select approver2");
                    //        return;

                    //    }
                    //}
                    _obj_Rec_ApprovalProcess.Mode = 20;
                    bool status = Recruitment_BLL.set_EmpSetup(_obj_Rec_ApprovalProcess);
                    if (status == true)
                    {
                        Recruitment_BLL.ShowMessage(this, "Record Updated Successfully");
                        LoadGrid();
                        btn_Save.Visible = true;
                        Rm_ApproverProcess_PAGE.SelectedIndex = 0;
                        //chk_Approver2.Checked = false;
                        return;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApprovalProcess", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_Click1(object sender, EventArgs e)
    {
        try
        {
            LoadGrid();
            Rm_ApproverProcess_PAGE.SelectedIndex = 0;
            ClearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApprovalProcess", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void ClearControls()
    {
        try
        {
            // rcmb_BusinessUnitType.Items.Clear();
            //    rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
            //rcmb_1Level.Items.Clear();
            //rcmb_1Level.Items.Insert(0, new RadComboBoxItem("", ""));
            //rcmb_2Level.Items.Clear();
            //rcmb_2Level.Items.Insert(0, new RadComboBoxItem("", ""));
            //rcmb_3Level.Items.Clear();
            //rcmb_3Level.Items.Insert(0, new RadComboBoxItem("", ""));            
            //chk_Approver2.Checked = false;

            rcmb_1Level.Items.Clear();
            rcmb_2Level.Items.Clear();
            rcmb_3Level.Items.Clear();
            rcmb_1Level.Text = string.Empty;
            rcmb_2Level.Text = string.Empty;
            rcmb_3Level.Text = string.Empty;

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApprovalProcess", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

}
