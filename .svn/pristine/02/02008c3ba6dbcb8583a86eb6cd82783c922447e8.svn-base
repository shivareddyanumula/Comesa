using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using SPMS;
using Telerik.Web.UI;
using SMHR;

public partial class Payroll_DOWNLOADESI : System.Web.UI.Page
{
    SMHR_ESIMASTER _obj_Smhr_ESIMASTER;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_BUSINESSUNIT _obj_smhr_businessunit;
    static bool Is_Active = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
            if (!Page.IsPostBack)
            {
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("ESI Master");//ESIMASTER");
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
                    Rg_ESI.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;

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
                lbl_ESI1.Visible = true;
                lbl_ESI.Visible = false;
                Rm_ESI_PAGE.SelectedIndex = 0;
                LoadGrid();
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DOWNLOADESI", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #region LoadGrid
    /// <summary>
    ///IN THIS data binding from database to datatable binding to radgrid
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void Rg_ESI_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {

            _obj_Smhr_ESIMASTER = new SMHR_ESIMASTER();
            _obj_Smhr_ESIMASTER.Mode = 1;
            _obj_Smhr_ESIMASTER.SMHR_ESI_MASTER_ORGID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_ESIMASTER(_obj_Smhr_ESIMASTER);
            if (dt.Rows.Count != 0)
            {
                Rg_ESI.DataSource = dt;

            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DOWNLOADESI", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadGrid()
    {
        try
        {
            _obj_Smhr_ESIMASTER = new SMHR_ESIMASTER();
            _obj_Smhr_ESIMASTER.Mode = 1;
            _obj_Smhr_ESIMASTER.SMHR_ESI_MASTER_ORGID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_ESIMASTER(_obj_Smhr_ESIMASTER);
            if (dt.Rows.Count != 0)
            {
                Rg_ESI.DataSource = dt;

                Rg_ESI.DataBind();
            }
            else
            {
                DataTable dt1 = new DataTable();

                Rg_ESI.DataSource = dt1;

                Rg_ESI.DataBind();
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DOWNLOADESI", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion
    #region loadcombos,clear fields
    private void LoadCombos()
    {
        try
        {

            _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();


            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            if (dt_BUDetails.Rows.Count != 0)
            {
                rcmb_BUI.DataSource = dt_BUDetails;
                rcmb_BUI.DataValueField = "BUSINESSUNIT_ID";
                rcmb_BUI.DataTextField = "BUSINESSUNIT_CODE";
                rcmb_BUI.DataBind();
                rcmb_BUI.Items.Insert(0, new RadComboBoxItem("Select"));
            }

            else
            {
                DataTable dt_Details = new DataTable();
                rcmb_BUI.DataSource = dt_Details;

                rcmb_BUI.DataBind();
                rcmb_BUI.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DOWNLOADESI", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void clearControls()
    {
        try
        {
            rcmb_BUI.Enabled = true;
            rcm_employee.Enabled = true;
            RNT_IPNUMBER.Enabled = true;
            rtxt_IPName.Enabled = true;
            rcmb_BUI.SelectedIndex = 0;
            rcm_employee.SelectedIndex = 0;
            RNT_IPNUMBER.Text = string.Empty;
            rtxt_IPName.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DOWNLOADESI", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    #endregion

    #region Add,Edit Command
    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            lbl_ESI1.Visible = false;
            lbl_ESI.Visible = true;
            clearControls();
            Rm_ESI_PAGE.SelectedIndex = 1;
            btn_Save.Visible = true;
            btn_Cancel.Visible = true;
            btn_update.Visible = false;
            //chk_Status.Checked = false;
            rcmb_Status.SelectedIndex = 0;
            LoadCombos();
            rcmb_BUI.SelectedIndex = 0;
            DataTable DT1 = new DataTable();
            rcm_employee.DataSource = DT1;
            rcm_employee.DataBind();
            rcm_employee.Items.Insert(0, new RadComboBoxItem("Select"));

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DOWNLOADESI", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }



    /// <summary>
    ///IN THIS BASED ON Project_ID(COMMANDARGUMENT) ALL DATA WILL BE TAKEN TO DATATABLE THEN WE CAN BIND TO INDIVIDUAL FIELDS
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>

    protected void lnk_edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            LoadCombos();
            clearControls();
            btn_Save.Visible = false;

            btn_Cancel.Visible = true;
            rcmb_BUI.Enabled = false;
            _obj_Smhr_ESIMASTER = new SMHR_ESIMASTER();
            _obj_Smhr_ESIMASTER.Mode = 2;

            _obj_Smhr_ESIMASTER.SMHR_ESI_MASTER_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            DataTable DT = BLL.get_ESIMASTER(_obj_Smhr_ESIMASTER);
            if (DT.Rows.Count != 0)
            {
                lbl_ESIDUMMYID.Text = Convert.ToString(DT.Rows[0]["SMHR_ESI_MASTER_ID"]);
                rcmb_BUI.SelectedIndex = rcmb_BUI.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["SMHR_ESI_MASTER_BUID"]));
                LoadEmployees();
                rcm_employee.SelectedIndex = rcm_employee.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["SMHR_ESI_MASTER_EMPID"]));
                RNT_IPNUMBER.Text = Convert.ToString(DT.Rows[0]["SMHR_ESI_MASTER_IPNO"]);
                rtxt_IPName.Text = Convert.ToString(DT.Rows[0]["SMHR_ESI_MASTER_IPNAME"]);
                //chk_Status.Checked = Convert.ToBoolean(DT.Rows[0]["SMHR_ESI_MASTER_STATUS"]);
                int Status = Convert.ToInt32(DT.Rows[0]["SMHR_ESI_MASTER_STATUS"]);
                rcmb_Status.SelectedIndex = rcmb_Status.FindItemIndexByValue(Convert.ToString(Status));
                Is_Active = Convert.ToBoolean(Status);
                lbl_ESI1.Visible = false;
                lbl_ESI.Visible = true;
                Rm_ESI_PAGE.SelectedIndex = 1;
            }

            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {


                btn_update.Visible = false;

            }
            else
            {
                btn_update.Visible = true;
            }


        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DOWNLOADESI", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    private void LoadEmployees()
    {
        try
        {
            _obj_Smhr_ESIMASTER = new SMHR_ESIMASTER();
            _obj_Smhr_ESIMASTER.Mode = 6;
            _obj_Smhr_ESIMASTER.SMHR_ESI_MASTER_BUID = Convert.ToInt32(rcmb_BUI.SelectedItem.Value);

            _obj_Smhr_ESIMASTER.SMHR_ESI_MASTER_ORGID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_ESIMASTER(_obj_Smhr_ESIMASTER);
            if (dt.Rows.Count != 0)
            {
                rcm_employee.DataSource = dt;
                rcm_employee.DataValueField = "EMP_ID";
                rcm_employee.DataTextField = "EMPLOYEE_NAME";
                rcm_employee.DataBind();
                rcm_employee.Items.Insert(0, new RadComboBoxItem("Select"));
            }
            else
            {
                DataTable dt_Details = new DataTable();
                rcm_employee.DataSource = dt_Details;

                rcm_employee.DataBind();
                rcm_employee.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DOWNLOADESI", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    protected void rcmb_BUI_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {

            if (rcmb_BUI.SelectedItem.Text.Trim() != "Select")
            {
                LoadEmployees();
            }
            else
            {
                Pms_Bll.ShowMessage(this, "Please Select Businessunit");
                DataTable dt_Details = new DataTable();
                rcm_employee.DataSource = dt_Details;

                rcm_employee.DataBind();
                rcm_employee.Items.Insert(0, new RadComboBoxItem("Select"));

                return;

            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DOWNLOADESI", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {

            // checking whether ip number consists of 10 digits or not
            if (RNT_IPNUMBER.Text.Length == 10)
            {
                _obj_Smhr_ESIMASTER = new SMHR_ESIMASTER();
                _obj_Smhr_ESIMASTER.Mode = 8;
                _obj_Smhr_ESIMASTER.SMHR_ESI_MASTER_IPNO = Convert.ToString(RNT_IPNUMBER.Text);
                // as there should not be duplicate of ip number even for different organisations we are not passing orgid here
                DataTable dt1 = BLL.get_ESIMASTER(_obj_Smhr_ESIMASTER);
                if (dt1.Rows.Count > 0)
                {
                    if (dt1.Rows[0][0].ToString() == "1")
                    {
                        BLL.ShowMessage(this, "IP Number is already in Use:");
                        return;
                    }
                }
                // CHECKING FOR THE EXISTANCE OF EMPLOYEE WITH SOME OTHER IP IN ACTIVE STATE
                if (Convert.ToInt32(rcmb_Status.SelectedItem.Value) == 1)
                {
                    _obj_Smhr_ESIMASTER.Mode = 9;
                    _obj_Smhr_ESIMASTER.SMHR_ESI_MASTER_EMPID = Convert.ToInt32(rcm_employee.SelectedItem.Value);
                    dt1 = BLL.get_ESIMASTER(_obj_Smhr_ESIMASTER);
                    if (dt1.Rows.Count > 0)
                    {
                        if (dt1.Rows[0][0].ToString() == "1")
                        {
                            BLL.ShowMessage(this, "this Employee is having another IP which is in Active State");
                            return;
                        }
                    }
                }
                _obj_Smhr_ESIMASTER.Mode = 5;
                DataTable dt = BLL.get_ESIMASTER(_obj_Smhr_ESIMASTER);
                if (dt.Rows.Count != 0)
                {
                    BLL.ShowMessage(this, "Record Already Exist");
                    return;
                }
                else
                {
                    _obj_Smhr_ESIMASTER = new SMHR_ESIMASTER();
                    _obj_Smhr_ESIMASTER.Mode = 3;
                    _obj_Smhr_ESIMASTER.SMHR_ESI_MASTER_BUID = Convert.ToInt32(rcmb_BUI.SelectedItem.Value);
                    _obj_Smhr_ESIMASTER.SMHR_ESI_MASTER_IPNO = Convert.ToString(RNT_IPNUMBER.Text);
                    _obj_Smhr_ESIMASTER.SMHR_ESI_MASTER_IPNAME = BLL.ReplaceQuote(Convert.ToString(rtxt_IPName.Text));
                    _obj_Smhr_ESIMASTER.SMHR_ESI_MASTER_EMPID = Convert.ToInt32(rcm_employee.SelectedValue);
                    _obj_Smhr_ESIMASTER.SMHR_ESI_MASTER_ORGID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Smhr_ESIMASTER.SMHR_ESI_MASTER_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_Smhr_ESIMASTER.SMHR_ESI_MASTER_CREATEDATE = DateTime.Now;
                    int Status = Convert.ToInt32(rcmb_Status.SelectedItem.Value);
                    _obj_Smhr_ESIMASTER.HR_MASTER_ISDELETED = Convert.ToBoolean(Status);




                    bool status = BLL.set_ESIMASTER(_obj_Smhr_ESIMASTER);
                    if (status == true)
                    {
                        BLL.ShowMessage(this, "Record Inserted Successfully");
                        LoadGrid();
                        lbl_ESI1.Visible = true;
                        lbl_ESI.Visible = false;
                        Rm_ESI_PAGE.SelectedIndex = 0;
                        return;
                    }
                }
            }
            else
            {
                BLL.ShowMessage(this, "Ip Number Must be a Ten Digit Number");
                RNT_IPNUMBER.Focus();
                return;
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DOWNLOADESI", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_update_Click(object sender, EventArgs e)
    {
        try
        {
            // checking whether ip number consists of 10 digits or not
            if (RNT_IPNUMBER.Text.Length == 10)
            {
                _obj_Smhr_ESIMASTER = new SMHR_ESIMASTER();
                _obj_Smhr_ESIMASTER.Mode = 8;
                _obj_Smhr_ESIMASTER.SMHR_ESI_MASTER_IPNO = Convert.ToString(RNT_IPNUMBER.Text);
                // as there should not be duplicate of ip number even for different organisations we are not passing orgid here
                DataTable dt1 = BLL.get_ESIMASTER(_obj_Smhr_ESIMASTER);
                if (dt1.Rows.Count > 0)
                {
                    if (dt1.Rows[0][0].ToString() == "1")
                    {
                        // CHECKING IP NUMBER EXISTS FOR THE SAME EMPLOYEE OR NOT
                        if (dt1.Rows[0][1].ToString() != Convert.ToString(rcm_employee.SelectedValue))
                        {
                            BLL.ShowMessage(this, "IP Number is already in Use:");
                            return;
                        }
                    }
                }
                // SOME THING HE HAS MODIFIED
                int Status = Convert.ToInt32(rcmb_Status.SelectedItem.Value);
                if (Is_Active != Convert.ToBoolean(Status))
                {
                    // CHECKING FOR THE EXISTANCE OF EMPLOYEE WITH SOME OTHER IP IN ACTIVE STATE
                    if (Status == 1)
                    {
                        _obj_Smhr_ESIMASTER.Mode = 9;
                        _obj_Smhr_ESIMASTER.SMHR_ESI_MASTER_EMPID = Convert.ToInt32(rcm_employee.SelectedItem.Value);
                        dt1 = BLL.get_ESIMASTER(_obj_Smhr_ESIMASTER);
                        if (dt1.Rows.Count > 0)
                        {
                            if (dt1.Rows[0][0].ToString() == "1")
                            {
                                BLL.ShowMessage(this, "this Employee is having another IP which is in Active State");
                                return;
                            }
                        }
                    }

                }

                _obj_Smhr_ESIMASTER = new SMHR_ESIMASTER();
                _obj_Smhr_ESIMASTER.Mode = 4;
                _obj_Smhr_ESIMASTER.SMHR_ESI_MASTER_ID = Convert.ToInt32(lbl_ESIDUMMYID.Text);
                _obj_Smhr_ESIMASTER.SMHR_ESI_MASTER_BUID = Convert.ToInt32(rcmb_BUI.SelectedItem.Value);
                _obj_Smhr_ESIMASTER.SMHR_ESI_MASTER_EMPID = Convert.ToInt32(rcm_employee.SelectedValue);
                _obj_Smhr_ESIMASTER.SMHR_ESI_MASTER_EMPID = Convert.ToInt32(rcm_employee.SelectedItem.Value);
                _obj_Smhr_ESIMASTER.SMHR_ESI_MASTER_IPNO = Convert.ToString(RNT_IPNUMBER.Text);
                _obj_Smhr_ESIMASTER.SMHR_ESI_MASTER_IPNAME = BLL.ReplaceQuote(Convert.ToString(rtxt_IPName.Text));
                _obj_Smhr_ESIMASTER.HR_MASTER_ISDELETED = Convert.ToBoolean(Status);
                _obj_Smhr_ESIMASTER.SMHR_ESI_MASTER_ORGID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_ESIMASTER.SMHR_ESI_MASTER_MODIFIEDBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_Smhr_ESIMASTER.SMHR_ESI_MASTER_MODIFIEDDATE = DateTime.Now;




                bool status = BLL.set_ESIMASTER(_obj_Smhr_ESIMASTER);
                if (status == true)
                {
                    BLL.ShowMessage(this, "Record Updated Successfully");
                    LoadGrid();
                    lbl_ESI1.Visible = true;
                    lbl_ESI.Visible = false;
                    Rm_ESI_PAGE.SelectedIndex = 0;
                    return;
                }
            }
            else
            {
                BLL.ShowMessage(this, "Ip Number Must be a Ten Digit Number");
                RNT_IPNUMBER.Focus();
                return;
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DOWNLOADESI", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcm_employee_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcm_employee.SelectedItem.Text != "Select")
            {
                if (rcm_employee.SelectedItem.Text.Contains("-"))
                {
                    int position = rcm_employee.SelectedItem.Text.IndexOf("-");
                    rtxt_IPName.Text = rcm_employee.SelectedItem.Text.Substring(0, position);
                }
                // rtxt_IPName.Text = Convert.ToString(rcm_employee.SelectedItem.Text);

            }
            else
            {
                BLL.ShowMessage(this, "Please Select Employee");

                rtxt_IPName.Text = string.Empty;
                return;
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DOWNLOADESI", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {

            lbl_ESI1.Visible = true;
            lbl_ESI.Visible = false;
            Rm_ESI_PAGE.SelectedIndex = 0;
            LoadGrid();
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DOWNLOADESI", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
