using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;
using System.Data.SqlClient;
using SPMS;
using SMHR;


public partial class PMS_frm_PmsAppraisalCycle : System.Web.UI.Page
{
    PMS_Appraisalcycle _obj_Pms_Appraisalcycle;
    SMHR_BUSINESSUNIT _obj_smhr_businessunit;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    PMS_GoalSettings _obj_GS;
    SPMS_APRAISALSTATUS _obj_Pms_AppStatus;

    #region pageload methods,clearfields methods

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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Appraisal Cycle");//APPRAISALCYCLE");
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
                    RG_Appraisalcycle.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;



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
                ClearFields();
                RMP_AppraisalCycle.SelectedIndex = 0;
                Page.Validate();

            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisalCycle", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void ClearFields()
    {
        try
        {
            txt_Appraisalcycle.Text = string.Empty;
            txt_AppraisalDescription.Text = string.Empty;
            RDP_StartDate.SelectedDate = null;
            RDP_EndDate.SelectedDate = null;
            // CB_IsActive.Checked = false;
            chk_SelfAppraisal.Checked = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisalCycle", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    #endregion

    #region loadcombos

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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisalCycle", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    #endregion

    #region loadgrid methods

    protected void loadgrid()
    {
        try
        {
            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            _obj_Pms_Appraisalcycle.MODE = 1;
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["org_id"]);
            DataTable dt = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
            if (dt.Rows.Count != 0)
            {
                RG_Appraisalcycle.DataSource = dt;
                RG_Appraisalcycle.DataBind();
            }

            else
            {
                DataTable dt_Details = new DataTable();
                RG_Appraisalcycle.DataSource = dt_Details;

                RG_Appraisalcycle.DataBind();

            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisalCycle", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    protected void RG_Appraisalcycle_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            _obj_Pms_Appraisalcycle.MODE = 1;
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["org_id"]);
            DataTable dt = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
            if (dt.Rows.Count != 0)
            {
                RG_Appraisalcycle.DataSource = dt;
            }

            else
            {
                DataTable dt_Details = new DataTable();
                RG_Appraisalcycle.DataSource = dt_Details;
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisalCycle", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region add,edit command methods

    protected void lnk_Add_command(object sender, CommandEventArgs e)
    {
        try
        {
            ClearFields();
            RMP_AppraisalCycle.SelectedIndex = 1;
            btn_Save.Visible = true;
            //CB_IsActive.Enabled = true;
            btn_Update.Visible = false;
            rcmb_Status.SelectedIndex = 0;
            txt_Appraisalcycle.Enabled = true;
            RDP_StartDate.Enabled = true;
            RDP_EndDate.Enabled = true;
            rcmb_BUI.SelectedIndex = 0;
            rcmb_BUI.Enabled = true;
            //chk_SelfAppraisal.Enabled = true;
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisalCycle", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Commnad(object sender, CommandEventArgs e)
    {

        try
        {
            ClearFields();
            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            _obj_Pms_Appraisalcycle.MODE = 2;
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["org_id"]);
            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(e.CommandArgument);
            lbl_ID.Text = Convert.ToString(e.CommandArgument);
            DataTable DT = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
            int Status = Convert.ToInt32(DT.Rows[0]["APPRCYCLE_ISACTIVE"]);
            if (DT.Rows.Count != 0)
            {

                lbl_ID.Text = Convert.ToString(DT.Rows[0]["APPRCYCLE_ID"]);
                txt_Appraisalcycle.Text = Convert.ToString(DT.Rows[0]["APPRCYCLE_NAME"]);
                txt_AppraisalDescription.Text = Convert.ToString(DT.Rows[0]["APPRCYCLE_DESC"]);
                LoadCombos();
                rcmb_BUI.SelectedIndex = rcmb_BUI.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["APPRCYCLE_BU_ID"]));
                RDP_StartDate.SelectedDate = Convert.ToDateTime(DT.Rows[0]["APPCYCLE_STARTDATE"]);
                RDP_EndDate.SelectedDate = Convert.ToDateTime(DT.Rows[0]["APPCYCLE_ENDDATE"]);
                rcmb_Status.SelectedIndex = rcmb_Status.FindItemIndexByValue(Convert.ToString(Status));
                if (DT.Rows[0]["APPRCYCLE_SELFAPPRAISAL"] != System.DBNull.Value)
                    chk_SelfAppraisal.Checked = Convert.ToBoolean(DT.Rows[0]["APPRCYCLE_SELFAPPRAISAL"]);
                else
                    chk_SelfAppraisal.Checked = false;
                RMP_AppraisalCycle.SelectedIndex = 1;

                btn_Save.Visible = true;
                btn_Save.Visible = false;
                btn_Update.Visible = true;
                txt_Appraisalcycle.Enabled = false;
                RDP_StartDate.Enabled = false;
                RDP_EndDate.Enabled = false;
                rcmb_BUI.Enabled = false;
                //chk_SelfAppraisal.Enabled = false;

                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {

                    btn_Save.Visible = false;
                    btn_Update.Visible = false;

                }

                else
                {
                    btn_Save.Visible = false;
                    btn_Update.Visible = true;
                }
            }

            else
            {
                Pms_Bll.ShowMessage(this, "Error Occured");
                return;
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisalCycle", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region save,cancel,update methods

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            _obj_Pms_Appraisalcycle.MODE = 12;
            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(rcmb_BUI.SelectedItem.Value);
            _obj_Pms_Appraisalcycle.APPRCYCLE_NAME = Convert.ToString(txt_Appraisalcycle.Text.Replace("'", "''"));
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["org_id"]);
            DataTable dtname = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
            if (dtname.Rows.Count != 0)
            {
                Pms_Bll.ShowMessage(this, "Appraisal Cycle Name Already Exist");
                return;

            }
            else
            {
                //if (Convert.ToDateTime(RDP_EndDate.SelectedDate.Value) < DateTime.Now)
                //{
                //    //RDP_StartDate.Clear();
                //    RDP_EndDate.Clear();
                //    Pms_Bll.ShowMessage(this, "End Date Should Be Greater Than Current Date");
                //    return;
                //}
                //if (RDP_EndDate.SelectedDate <RDP_StartDate.SelectedDate)
                //{
                //    Pms_Bll.ShowMessage(this, "end date");
                //    return;
                //}

                int Status = Convert.ToInt32(rcmb_Status.SelectedItem.Value);
                if (Status == 1)
                {
                    //DataTable dt = new DataTable();
                    //_obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                    //_obj_Pms_Appraisalcycle.MODE = 7;
                    //_obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(rcmb_BUI.SelectedItem.Value);
                    //_obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["org_id"]);
                    //dt = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                    ////in which if there is any active appraisal cycle under that business unit
                    //if (dt.Rows.Count != 0)
                    //{
                    //    Pms_Bll.ShowMessage(this, "There is Already Active Appraisal Cycle");
                    //    return;
                    //}

                    //else
                    //{

                    _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                    _obj_Pms_Appraisalcycle.MODE = 10;


                    _obj_Pms_Appraisalcycle.APPCYCLE_STARTDATE = RDP_StartDate.SelectedDate.Value;
                    _obj_Pms_Appraisalcycle.APPCYCLE_ENDDATE = RDP_EndDate.SelectedDate.Value;
                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(rcmb_BUI.SelectedItem.Value);
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["org_id"]);
                    DataTable dt2 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                    if (Convert.ToString(dt2.Rows[0][0]).Trim() == "0")
                    {


                        _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                        _obj_Pms_Appraisalcycle.MODE = 3;
                        _obj_Pms_Appraisalcycle.APPRCYCLE_NAME = Pms_Bll.ReplaceQuote(Convert.ToString(txt_Appraisalcycle.Text));
                        _obj_Pms_Appraisalcycle.APPRCYCLE_DESC = Pms_Bll.ReplaceQuote(Convert.ToString(txt_AppraisalDescription.Text));
                        _obj_Pms_Appraisalcycle.APPCYCLE_STARTDATE = RDP_StartDate.SelectedDate.Value;
                        _obj_Pms_Appraisalcycle.APPCYCLE_ENDDATE = RDP_EndDate.SelectedDate.Value;

                        _obj_Pms_Appraisalcycle.CREATEDBY = Convert.ToInt32(Session["user_id"]); // ### Need to Get the Session
                        _obj_Pms_Appraisalcycle.CREATEDDATE = DateTime.Now;
                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(rcmb_BUI.SelectedValue);
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["org_id"]);

                        _obj_Pms_Appraisalcycle.APPRCYCLE_ISACTIVE = Convert.ToBoolean(Status);
                        _obj_Pms_Appraisalcycle.APPRCYCLE_SELFAPPRAISAL = chk_SelfAppraisal.Checked;
                        bool status = Pms_Bll.set_Appraisalcycle(_obj_Pms_Appraisalcycle);
                        if (status == true)
                        {
                            Pms_Bll.ShowMessage(this, "Record Inserted Successfully");
                            loadgrid();

                            ClearFields();

                            RMP_AppraisalCycle.SelectedIndex = 0;
                            RP_AppraisalCycle.Visible = true;


                            return;
                        }
                    }
                    else
                    {

                        Pms_Bll.ShowMessage(this, "Appraisal Cycle Already Exists for this Date.");
                        return;
                    }
                    //}
                }
                else
                {
                    _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                    _obj_Pms_Appraisalcycle.MODE = 10;

                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["org_id"]);
                    _obj_Pms_Appraisalcycle.APPCYCLE_STARTDATE = RDP_StartDate.SelectedDate.Value;
                    _obj_Pms_Appraisalcycle.APPCYCLE_ENDDATE = RDP_EndDate.SelectedDate.Value;
                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(rcmb_BUI.SelectedItem.Value); //0;//bbb

                    DataTable dt2 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                    if (Convert.ToString(dt2.Rows[0][0]).Trim() == "0")
                    {


                        _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                        _obj_Pms_Appraisalcycle.MODE = 3;
                        _obj_Pms_Appraisalcycle.APPRCYCLE_NAME = Pms_Bll.ReplaceQuote(Convert.ToString(txt_Appraisalcycle.Text));
                        _obj_Pms_Appraisalcycle.APPRCYCLE_DESC = Pms_Bll.ReplaceQuote(Convert.ToString(txt_AppraisalDescription.Text));
                        _obj_Pms_Appraisalcycle.APPCYCLE_STARTDATE = RDP_StartDate.SelectedDate.Value;
                        _obj_Pms_Appraisalcycle.APPCYCLE_ENDDATE = RDP_EndDate.SelectedDate.Value;

                        _obj_Pms_Appraisalcycle.CREATEDBY = Convert.ToInt32(Session["user_id"]); // ### Need to Get the Session
                        _obj_Pms_Appraisalcycle.CREATEDDATE = DateTime.Now;
                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(rcmb_BUI.SelectedValue);
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["org_id"]);
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ISACTIVE = Convert.ToBoolean(Status);
                        _obj_Pms_Appraisalcycle.APPRCYCLE_SELFAPPRAISAL = chk_SelfAppraisal.Checked;
                        bool status = Pms_Bll.set_Appraisalcycle(_obj_Pms_Appraisalcycle);
                        if (status == true)
                        {
                            Pms_Bll.ShowMessage(this, "Record Inserted Successfully");
                            loadgrid();

                            ClearFields();

                            RMP_AppraisalCycle.SelectedIndex = 0;
                            RP_AppraisalCycle.Visible = true;


                            return;
                        }
                    }
                    else
                    {

                        Pms_Bll.ShowMessage(this, "End Date Should Be Greater Existed End Date");
                        return;
                    }
                }


            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisalCycle", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    
    protected void btn_Update_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_GS = new PMS_GoalSettings();
            _obj_GS.GS_MODE = 23;//YYY
            _obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["org_id"]);
            _obj_GS.GS_APPRAISAL_CYCLE = Convert.ToString(lbl_ID.Text);
            DataTable dtgsemp = Pms_Bll.get_GS(_obj_GS);

            _obj_Pms_AppStatus = new SPMS_APRAISALSTATUS();
            _obj_Pms_AppStatus.Mode = 8;//YYY
            _obj_Pms_AppStatus.APP_STATUS_ORG_ID = Convert.ToInt32(Session["org_id"]);
            _obj_Pms_AppStatus.APP_STATUS_APPRAISALCYCLE = Convert.ToInt32(lbl_ID.Text);
            DataTable dtappstatusemp = Pms_Bll.get_AppStatus(_obj_Pms_AppStatus);
            int Status = Convert.ToInt32(rcmb_Status.SelectedItem.Value);
            if ((dtgsemp.Rows.Count == dtappstatusemp.Rows.Count) || (dtappstatusemp.Rows.Count == 0))
            {

                _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(lbl_ID.Text);

                _obj_Pms_Appraisalcycle.APPRCYCLE_DESC = Pms_Bll.ReplaceQuote(Convert.ToString(txt_AppraisalDescription.Text));
                _obj_Pms_Appraisalcycle.APPRCYCLE_ISACTIVE = Convert.ToBoolean(Status);
                _obj_Pms_Appraisalcycle.APPRCYCLE_MODIFIEDBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_Pms_Appraisalcycle.APPRCYCLE_MODIFIED_DATE = DateTime.Now;
                _obj_Pms_Appraisalcycle.APPRCYCLE_SELFAPPRAISAL = chk_SelfAppraisal.Checked;
                if (Status == 1)
                {
                    DataTable dt_chk = new DataTable();
                    _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                    _obj_Pms_Appraisalcycle.MODE = 7;
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["org_id"]);
                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(rcmb_BUI.SelectedItem.Value);
                    dt_chk = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                    _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();

                    _obj_Pms_Appraisalcycle.MODE = 14;
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["org_id"]);
                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(rcmb_BUI.SelectedItem.Value);

                    DataTable dt_chk1 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                    //if ((dt_chk.Rows.Count != 0) && ((Convert.ToInt32(dt_chk1.Rows[0]["APPRCYCLE_ID"])) != (Convert.ToInt32(lbl_ID.Text))))
                    //  {
                    //      Pms_Bll.ShowMessage(this, "There is Already Active Appraisal Cycle");
                    //  }
                    //  else
                    //  {
                    _obj_Pms_Appraisalcycle.MODE = 4;
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ISACTIVE = Convert.ToBoolean(Status);
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(lbl_ID.Text);
                    _obj_Pms_Appraisalcycle.APPRCYCLE_MODIFIEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_Pms_Appraisalcycle.APPRCYCLE_MODIFIED_DATE = DateTime.Now;
                    _obj_Pms_Appraisalcycle.APPRCYCLE_DESC = Convert.ToString(txt_AppraisalDescription.Text.Replace("'", "''"));
                    _obj_Pms_Appraisalcycle.APPRCYCLE_SELFAPPRAISAL = chk_SelfAppraisal.Checked;
                    bool status = Pms_Bll.set_Appraisalcycle(_obj_Pms_Appraisalcycle);
                    if (status == true)
                    {
                        Pms_Bll.ShowMessage(this, "Record Updated Successfully");
                        _obj_GS = new PMS_GoalSettings();
                        _obj_GS.GS_MODE = 20;//YYY
                        _obj_GS.GS_APPRAISAL_CYCLE = Convert.ToString(lbl_ID.Text);
                        bool status22 = Pms_Bll.set_GS(_obj_GS);

                        loadgrid();
                        btn_Update.Visible = true;
                        RMP_AppraisalCycle.SelectedIndex = 0;



                    }
                    else
                    {
                        Pms_Bll.ShowMessage(this, "Unable to Update the record,Execption Occured");
                        return;
                    }
                    //}
                }
                else
                {
                    _obj_Pms_Appraisalcycle.MODE = 4;
                    bool status = Pms_Bll.set_Appraisalcycle(_obj_Pms_Appraisalcycle);
                    if (status == true)
                    {
                        Pms_Bll.ShowMessage(this, "Record Updated Successfully");
                        _obj_GS = new PMS_GoalSettings();
                        _obj_GS.GS_MODE = 20;//YYY
                        _obj_GS.GS_APPRAISAL_CYCLE = Convert.ToString(lbl_ID.Text);
                        bool status22 = Pms_Bll.set_GS(_obj_GS);
                        loadgrid();
                        btn_Update.Visible = true;
                        RMP_AppraisalCycle.SelectedIndex = 0;
                    }
                    else
                    {
                        Pms_Bll.ShowMessage(this, "Unable to Update the record,Execption Occured");
                        return;
                    }
                }
            }

            else
            {
                Pms_Bll.ShowMessage(this, "Appraisal Cycle In Process");
                return;


            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisalCycle", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            Pms_Bll.ShowMessage(this, ex.Message.ToString());
            return;
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            RMP_AppraisalCycle.SelectedIndex = 0;
            loadgrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisalCycle", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            Pms_Bll.ShowMessage(this, ex.Message.ToString());
            return;
        }
    }

    #endregion

}
