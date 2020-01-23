using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SMHR;
using System.Data.SqlClient;
using System.Data.Sql;
using Telerik.Web.UI;
using System.IO;
using System.Data.OleDb;
using System.Text;
using System.Collections.Generic;

public partial class Masters_frm_Position : System.Web.UI.Page
{
    #region References

    DataSet ds = new DataSet();
    //SqlDataAdapter da;
    string filedatetime;
    #endregion
    
    public void btnFinalise_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_POSITIONS _obj_smhr_Position = new SMHR_POSITIONS();
            if (!string.IsNullOrEmpty(hdnEstablishmentID.Value))
            {
                _obj_smhr_Position.POSITION_ESTABLISHMENT_ID = Convert.ToInt32(hdnEstablishmentID.Value);
                _obj_smhr_Position.POSITIN_PERIOD_ID = Convert.ToInt32(rcmb_Period.SelectedValue);
                _obj_smhr_Position.POSITIONS_NOESTABLISHMENT = rtxtNoEstablishment.Text;
                _obj_smhr_Position.OPERATION = operation.UpdateSTATUS;
                if (BLL.set_Establishment(_obj_smhr_Position))
                {
                    BLL.ShowMessage(this, "Information Updated Successfully");
                    LoadEstablishments();
                    BindFinancialPeriod();
                    rtxtNoEstablishment.Text = string.Empty;
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;

                    rcmb_Period.Enabled = true;
                    hdnEstablishmentID.Value = null;
                }
                else
                    BLL.ShowMessage(this, "Information Not Saved");
            }
            else
            {
                _obj_smhr_Position = new SMHR_POSITIONS();
                _obj_smhr_Position.POSITIONS_ID = Convert.ToInt32(lbl_PositionsID.Text);
                _obj_smhr_Position.POSITIN_PERIOD_ID = Convert.ToInt32(rcmb_Period.SelectedValue);
                _obj_smhr_Position.POSITIONS_NOESTABLISHMENT = rtxtNoEstablishment.Text;

                _obj_smhr_Position.OPERATION = operation.Check;
                DataTable dtEstablishment = BLL.get_Establishment(_obj_smhr_Position);

                if (dtEstablishment.Rows.Count == 0)
                {
                    _obj_smhr_Position.OPERATION = operation.Insert_New;
                    if (BLL.set_Establishment(_obj_smhr_Position))
                    {
                        BLL.ShowMessage(this, "Information Updated Successfully");
                        LoadEstablishments();
                        BindFinancialPeriod();
                        rtxtNoEstablishment.Text = string.Empty;
                    }
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                }
                else
                    BLL.ShowMessage(this, "Establishment already defined for this period");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Positions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_POSITIONS _obj_smhr_Position = new SMHR_POSITIONS();
            _obj_smhr_Position.POSITION_ESTABLISHMENT_ID = Convert.ToInt32(hdnEstablishmentID.Value);
            _obj_smhr_Position.POSITIN_PERIOD_ID = Convert.ToInt32(rcmb_Period.SelectedValue);
            _obj_smhr_Position.POSITIONS_NOESTABLISHMENT = rtxtNoEstablishment.Text;
            _obj_smhr_Position.ESTABLISHMENTS_LSTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_Position.ESTABLISHMENTS_LSTMDFDATE = DateTime.Now;
            _obj_smhr_Position.OPERATION = operation.Select1;
            _obj_smhr_Position.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            int employeesCount = Convert.ToInt32(BLL.get_Establishment(_obj_smhr_Position).Rows[0]["EMPLOYEECOUNT"]);
            if (employeesCount > Convert.ToInt32(rtxtNoEstablishment.Text))
            {
                BLL.ShowMessage(this, "Establishment should be greater than: " + employeesCount);
                return;
            }
            _obj_smhr_Position.OPERATION = operation.Update;
            if (BLL.set_Establishment(_obj_smhr_Position))
            {
                BLL.ShowMessage(this, "Information Updated Successfully");
                LoadEstablishments();
                BindFinancialPeriod();
                rtxtNoEstablishment.Text = string.Empty;
                btnUpdate.Visible = false;
                btnAdd.Visible = true;

                rcmb_Period.Enabled = true;
                hdnEstablishmentID.Value = null;
            }
            else
                BLL.ShowMessage(this, "Information Not Saved");
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Positions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_POSITIONS _obj_smhr_Position = new SMHR_POSITIONS();
            _obj_smhr_Position.POSITIONS_ID = Convert.ToInt32(lbl_PositionsID.Text);
            _obj_smhr_Position.POSITIN_PERIOD_ID = Convert.ToInt32(rcmb_Period.SelectedValue);
            _obj_smhr_Position.POSITIONS_NOESTABLISHMENT = rtxtNoEstablishment.Text;
            _obj_smhr_Position.ESTABLISHMENTS_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_Position.ESTABLISHMENTS_CREATEDDATE = DateTime.Now;

            _obj_smhr_Position.OPERATION = operation.Check;
            DataTable dtEstablishment = BLL.get_Establishment(_obj_smhr_Position);

            if (dtEstablishment.Rows.Count == 0)
            {
                _obj_smhr_Position.OPERATION = operation.Insert;
                if (BLL.set_Establishment(_obj_smhr_Position))
                {
                    BLL.ShowMessage(this, "Information Updated Successfully");
                    LoadEstablishments();
                    BindFinancialPeriod();
                    rtxtNoEstablishment.Text = string.Empty;
                }
                else
                    BLL.ShowMessage(this, "Information Not Saved");
            }
            else
                BLL.ShowMessage(this, "Establishment already defined for this period");
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Positions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadEstablishments()
    {
        try
        {
            SMHR_POSITIONS _obj_smhr_Position = new SMHR_POSITIONS();
            _obj_smhr_Position.POSITIONS_ID = Convert.ToInt32(lbl_PositionsID.Text);
            _obj_smhr_Position.OPERATION = operation.Select2;
            DataTable DT = BLL.get_Positions(_obj_smhr_Position);
            RadEstablishMents.DataSource = DT;
            
            RadEstablishMents.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Positions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //public void rcmb_Period_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    //{
    //    if (!string.IsNullOrEmpty(lbl_PositionsID.Text))
    //    {
    //        SMHR_POSITIONS oSMHR_POSITIONS = new SMHR_POSITIONS();
    //        oSMHR_POSITIONS.POSITIN_PERIOD_ID = Convert.ToInt32(rcmb_Period.SelectedValue);
    //        oSMHR_POSITIONS.POSITIONS_ID = Convert.ToInt32(lbl_PositionsID.Text);
    //        oSMHR_POSITIONS.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //        oSMHR_POSITIONS.OPERATION = operation.Select2;
    //        DataTable dt = BLL.get_Positions(oSMHR_POSITIONS);
    //        if (dt.Rows.Count > 0)
    //        {
    //            rtxtNoEstablishment.Text = Convert.ToString(dt.Rows[0]["ESTABLISHMENTS_NO"]);
    //            oSMHR_POSITIONS.OPERATION = operation.Get;
    //            if ((Convert.ToInt32(BLL.GetCurrentFinancialPeriodID(oSMHR_POSITIONS).Rows[0][0]) == oSMHR_POSITIONS.POSITIN_PERIOD_ID))
    //            {
    //                if(BLL.IsEstablishMentsUpdated(oSMHR_POSITIONS))
    //                    rtxtNoEstablishment.Enabled = false;
    //                else
    //                    rtxtNoEstablishment.Enabled = true;
    //            }
    //            else
    //                rtxtNoEstablishment.Enabled = true;
    //        }
    //        else
    //        {
    //            rtxtNoEstablishment.Text = string.Empty;
    //            rtxtNoEstablishment.Enabled = true;
    //        }

    //    }
    //}

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (RWM_POSITIONPOSTREPLY.Windows.Count > 0)
            {
                RWM_POSITIONPOSTREPLY.Windows.RemoveAt(0);
            }
            if (!Page.IsPostBack)
            {

                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("POSITION");
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
                    Rg_Positions.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Save.Visible = false;
                    btn_Edit.Visible = false;
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
                BLL.ChangeDateFormat(Convert.ToString(Session["EMP_ID"]), rdtp_PositionsStartDate, rdtp_PositionsEndDate);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Positions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Establish_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {

            BindFinancialPeriod();
            rtxtNoEstablishment.Text = string.Empty;
            SMHR_POSITIONS oSMHR_POSITIONS = new SMHR_POSITIONS();
            oSMHR_POSITIONS.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            oSMHR_POSITIONS.OPERATION = operation.Select;
            oSMHR_POSITIONS.POSITION_ESTABLISHMENT_ID = Convert.ToInt32(e.CommandArgument.ToString());
            DataTable dtEstablishment = BLL.get_Establishment(oSMHR_POSITIONS);
            //if (Convert.ToBoolean(dtEstablishment.Rows[0]["ESTABLISHMENTS_FINALISE"]))
            //{
            //    btnUpdate.Visible = false;
            //    btnAdd.Visible = true;
            //    BLL.ShowMessage(this, "Establishment is already finalised");
            //}
            //else
            //{
            btnUpdate.Visible = true;
            btnAdd.Visible = false;
            rcmb_Period.Enabled = false;
            rcmb_Period.SelectedIndex = rcmb_Period.FindItemIndexByValue(dtEstablishment.Rows[0]["ESTABLISHMENTS_PERIODID"].ToString());
            rtxtNoEstablishment.Text = dtEstablishment.Rows[0]["ESTABLISHMENTS_NO"].ToString();
            hdnEstablishmentID.Value = dtEstablishment.Rows[0]["ESTABLISHMENTS_ID"].ToString();
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Positions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            loadDropdown1();
            clearControls();
            SMHR_POSITIONS _obj_Smhr_Positions = new SMHR_POSITIONS();
            _obj_Smhr_Positions.POSITIONS_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            Session.Remove("position_id");
            Session["position_id"] = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            LinkButton lnk = (LinkButton)sender;
            GridDataItem ditem = (GridDataItem)lnk.NamingContainer;
            String celltext = ditem["POSITIONS_JOBSID"].Text;
            _obj_Smhr_Positions.POSITIONS_JOBSID = Convert.ToInt32(celltext);
            _obj_Smhr_Positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            DataTable dt = BLL.get_Positions(_obj_Smhr_Positions);
            //rtxt_PositionsCode.Enabled = false;
            rcmb_PositionsJobs.Enabled = false;
            rtxt_PositionsCode.Enabled = false;
            lbl_PositionsID.Text = Convert.ToString(dt.Rows[0]["POSITIONS_ID"]);
            lbl_PositionJobsID.Text = Convert.ToString(dt.Rows[0]["POSITIONS_JOBSID"]);
            rtxt_PositionsCode.Text = Convert.ToString(dt.Rows[0]["POSITIONS_CODE"]);
            rtxt_PositionsDesc.Text = Convert.ToString(dt.Rows[0]["POSITIONS_DESC"]);
            //if (dt.Rows[0]["POSITIONS_NOESTABLISHMENT"] != null)
            //{
            //    rtxtNoEstablishment.Text = Convert.ToString(dt.Rows[0]["POSITIONS_NOESTABLISHMENT"]);
            //}
            //else
            //{
            //    rtxtNoEstablishment.Text = "0";
            //}
            //rcmb_Period.SelectedValue = dt.Rows[0]["POSITIONS_PERIOD_ID"].ToString();
            rcmb_PositionsJobs.SelectedIndex = rcmb_PositionsJobs.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["POSITIONS_JOBSID"]));
            rcmb_PositionsJobs_SelectedIndexChanged(null, null);
            rcmb_PositionsStatus.SelectedIndex = rcmb_PositionsStatus.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["POSITIONS_STATUS"]));

            if (string.Compare(rcmb_PositionsStatus.SelectedItem.Text, "InActive", true) == 0)
            {
                tdEstablishMents.Visible = true;
                btn_Save.Visible = false;
                btn_Edit.Visible = true;
                btnAdd.Visible = true;
                //btnFinalise.Visible = true;
                // rcmb_PositionsStatus.Enabled = false;
                LoadEstablishments(); btnAdd.Visible = true; btnAdd.Enabled = false;
                //btnFinalise.Visible = true;btnFinalise.Enabled=false; 
                RadEstablishMents.Enabled = false;
            }
            else
            {
                RadEstablishMents.Enabled = true;
                rcmb_PositionsStatus.Enabled = true;
                tdEstablishMents.Visible = true;
                // btn_Save.Visible = true;
                btnAdd.Visible = true; btnAdd.Enabled = true; //btnFinalise.Enabled = true;
                //btnFinalise.Visible = true;
                LoadEstablishments();
                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    btn_Edit.Visible = false;

                }
                else
                {
                    btn_Edit.Visible = true;
                }
            }
            //btnUpdate.Visible = false;
            rdtp_PositionsStartDate.SelectedDate = null;
            rdtp_PositionsEndDate.SelectedDate = null;

            if (dt.Rows[0]["POSITIONS_STARTDATE"] != DBNull.Value)
                rdtp_PositionsStartDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["POSITIONS_STARTDATE"]);
            if (dt.Rows[0]["POSITIONS_ENDDATE"] != DBNull.Value)
                rdtp_PositionsEndDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["POSITIONS_ENDDATE"]);

            rcmb_JobsGrade.SelectedIndex = rcmb_JobsGrade.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["POSITIONS_GRADE_ID"]));
            //rntxt_JobsMaxSalary.Text = Convert.ToString(dt.Rows[0]["POSITIONS_MAXSAL"] == DBNull.Value ? "" : dt.Rows[0]["POSITIONS_MAXSAL"]);
            //rntxt_JobsMinSalary.Text = Convert.ToString(dt.Rows[0]["POSITIONS_MINSAL"] == DBNull.Value ? "" : dt.Rows[0]["POSITIONS_MINSAL"]);
            //rcmb_JobsSkills.Text = Convert.ToString(dt.Rows[0]["JOBS_SKILLS"]);
            Label1.Text = Convert.ToString(dt.Rows[0]["JOBS_SKILLS_ID"]);
            // _obj_Smhr_Positions.POSITIN_PERIOD_ID = Convert.ToInt32(dt.Rows[0]["POSITIONS_PERIOD_ID"]);

            //if ((Convert.ToInt32(BLL.GetCurrentFinancialPeriodID(_obj_Smhr_Positions).Rows[0][0]) == Convert.ToInt32(dt.Rows[0]["POSITIONS_PERIOD_ID"])) && (BLL.IsEstablishMentsUpdated(_obj_Smhr_Positions)))
            //{
            //    rtxtNoEstablishment.Enabled = false;
            //}
            //else
            //    rtxtNoEstablishment.Enabled = true;

            getCheckedItems(RadListBox1, Label1);

            Label lQualification = new Label();
            lQualification.Text = dt.Rows[0]["POSITIONS_QUALIFICATION"].ToString();
            getCheckedItems(rcmb_Qualification, lQualification);



            Rm_PO_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Positions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            RadEstablishMents.Enabled = true; btnAdd.Enabled = true; //btnFinalise.Enabled = true;
            rcmb_PositionsStatus.Enabled = true;
            rtxt_PositionsCode.Enabled = true;
            loadDropdown();
            tdEstablishMents.Visible = false;
            clearControls();
            btn_Save.Visible = true;
            rcmb_PositionsJobs.Enabled = true;
            rtxtNoEstablishment.Enabled = true;
            Rm_PO_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Positions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    public void LoadGrid()
    {
        try
        {
            SMHR_POSITIONS _obj_smhr_Position = new SMHR_POSITIONS();
            _obj_smhr_Position.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            DataTable DT = BLL.get_Positions(_obj_smhr_Position);
            Rg_Positions.DataSource = DT;
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Positions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void loadDropdown()
    {
        try
        {

            SMHR_MASTERS _obj_Smhr_Masters = new SMHR_MASTERS();
            _obj_Smhr_Masters.OPERATION = operation.Select;
            _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_Smhr_Masters.MASTER_TYPE = "QUALIFICATION";
            DataTable dt_Details = BLL.get_MasterRecords(_obj_Smhr_Masters);
            if (dt_Details.Rows.Count > 0)
            {
                rcmb_Qualification.DataSource = dt_Details;
                rcmb_Qualification.DataTextField = "HR_MASTER_CODE";
                rcmb_Qualification.DataValueField = "HR_MASTER_ID";
                rcmb_Qualification.DataBind();
            }

            SMHR_JOBS _obj_Smhr_Jobs = new SMHR_JOBS();
            // _obj_Smhr_Jobs.OPERATION = operation.Select;
            _obj_Smhr_Jobs.OPERATION = operation.Delete1;//load only active jobs
            _obj_Smhr_Jobs.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_Smhr_Jobs.ISDELETED = false;
            rcmb_PositionsJobs.DataSource = BLL.get_Jobs(_obj_Smhr_Jobs);
            rcmb_PositionsJobs.DataTextField = "JOBS_CODE";
            rcmb_PositionsJobs.DataValueField = "JOBS_ID";
            rcmb_PositionsJobs.DataBind();
            rcmb_PositionsJobs.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

            BindFinancialPeriod();

            SMHR_EMPLOYEEGRADE _obj_Smhr_EmployeeGrade = new SMHR_EMPLOYEEGRADE();
            _obj_Smhr_EmployeeGrade.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT = BLL.get_EmployeeGrade(_obj_Smhr_EmployeeGrade).Tables[0];
            rcmb_JobsGrade.Items.Clear();
            rcmb_JobsGrade.DataSource = DT;
            rcmb_JobsGrade.DataTextField = "CODERANK";
            rcmb_JobsGrade.DataValueField = "EMPLOYEEGRADE_ID";
            rcmb_JobsGrade.DataBind();
            rcmb_JobsGrade.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            _obj_Smhr_Masters = new SMHR_MASTERS();
            _obj_Smhr_Masters.MASTER_TYPE = "SKILL";
            _obj_Smhr_Masters.OPERATION = operation.Select;
            _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            RadListBox1.Items.Clear();
            RadListBox1.DataSource = BLL.get_MasterRecords(_obj_Smhr_Masters);
            RadListBox1.DataTextField = "HR_MASTER_CODE";
            RadListBox1.DataValueField = "HR_MASTER_ID";
            RadListBox1.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Positions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void loadDropdown1()
    {
        try
        {

            SMHR_MASTERS _obj_Smhr_Masters = new SMHR_MASTERS();
            _obj_Smhr_Masters.OPERATION = operation.Select;
            _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_Smhr_Masters.MASTER_TYPE = "QUALIFICATION";
            DataTable dt_Details = BLL.get_MasterRecords(_obj_Smhr_Masters);
            if (dt_Details.Rows.Count > 0)
            {
                rcmb_Qualification.DataSource = dt_Details;
                rcmb_Qualification.DataTextField = "HR_MASTER_CODE";
                rcmb_Qualification.DataValueField = "HR_MASTER_ID";
                rcmb_Qualification.DataBind();
            }

            SMHR_JOBS _obj_Smhr_Jobs = new SMHR_JOBS();
            _obj_Smhr_Jobs.OPERATION = operation.Select;
            // _obj_Smhr_Jobs.OPERATION = operation.Delete1;
            _obj_Smhr_Jobs.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_Smhr_Jobs.ISDELETED = false;
            rcmb_PositionsJobs.DataSource = BLL.get_Jobs(_obj_Smhr_Jobs);
            rcmb_PositionsJobs.DataTextField = "JOBS_CODE";
            rcmb_PositionsJobs.DataValueField = "JOBS_ID";
            rcmb_PositionsJobs.DataBind();
            rcmb_PositionsJobs.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

            BindFinancialPeriod();

            SMHR_EMPLOYEEGRADE _obj_Smhr_EmployeeGrade = new SMHR_EMPLOYEEGRADE();
            _obj_Smhr_EmployeeGrade.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT = BLL.get_EmployeeGrade(_obj_Smhr_EmployeeGrade).Tables[0];
            rcmb_JobsGrade.Items.Clear();
            rcmb_JobsGrade.DataSource = DT;
            rcmb_JobsGrade.DataTextField = "CODERANK";
            rcmb_JobsGrade.DataValueField = "EMPLOYEEGRADE_ID";
            rcmb_JobsGrade.DataBind();
            rcmb_JobsGrade.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            _obj_Smhr_Masters = new SMHR_MASTERS();
            _obj_Smhr_Masters.MASTER_TYPE = "SKILL";
            _obj_Smhr_Masters.OPERATION = operation.Select;
            _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            RadListBox1.Items.Clear();
            RadListBox1.DataSource = BLL.get_MasterRecords(_obj_Smhr_Masters);
            RadListBox1.DataTextField = "HR_MASTER_CODE";
            RadListBox1.DataValueField = "HR_MASTER_ID";
            RadListBox1.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Positions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void BindFinancialPeriod()
    {
        try
        {
            SMHR_PERIOD _obj_smhr_period = new SMHR_PERIOD();
            DataTable dt_Details = new DataTable();
            _obj_smhr_period.OPERATION = operation.Select;
            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_PeriodHeaderDetails(_obj_smhr_period);
            rcmb_Period.DataSource = dt_Details;
            rcmb_Period.DataValueField = "PERIOD_ID";
            rcmb_Period.DataTextField = "PERIOD_NAME";
            rcmb_Period.DataBind();
            rcmb_Period.Items.Insert(0, new RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Positions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            //if (RadListBox1.CheckedItems.Count == 0)
            //{
            //    BLL.ShowMessage(this, "Please check atleast one Skill");
            //    return;
            //}
            //else if (rcmb_Qualification.CheckedItems.Count == 0)
            //{
            //    BLL.ShowMessage(this, "Please check atleast one Qualification");
            //    return;
            //}

            SMHR_POSITIONS _obj_Smhr_Positions = new SMHR_POSITIONS();
            _obj_Smhr_Positions.POSITIONS_CODE = BLL.ReplaceQuote(rtxt_PositionsCode.Text);
            _obj_Smhr_Positions.POSITIONS_DESC = BLL.ReplaceQuote(rtxt_PositionsDesc.Text);
            _obj_Smhr_Positions.POSITIONS_NOESTABLISHMENT = BLL.ReplaceQuote(rtxtNoEstablishment.Text);
            _obj_Smhr_Positions.POSITIN_PERIOD_ID = Convert.ToInt32(rcmb_Period.SelectedValue);
            _obj_Smhr_Positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());

            _obj_Smhr_Positions.POSITIONS_JOBSID = Convert.ToInt32(rcmb_PositionsJobs.SelectedItem.Value);
            _obj_Smhr_Positions.POSITIONS_STATUS = Convert.ToInt32(rcmb_PositionsStatus.SelectedItem.Value);

            _obj_Smhr_Positions.STARTDATE = rdtp_PositionsStartDate.SelectedDate;
            _obj_Smhr_Positions.ENDDATE = rdtp_PositionsEndDate.SelectedDate;


            if (rcmb_JobsGrade.SelectedItem.Value.ToString() != "0")
                _obj_Smhr_Positions.POSITIONS_GRADE_ID = Convert.ToInt32(rcmb_JobsGrade.SelectedItem.Value);

            //if (rntxt_JobsMaxSalary.Text != "")
            //    _obj_Smhr_Positions.POSITIONS_MAXSAL = Convert.ToDecimal(rntxt_JobsMaxSalary.Text);

            //if (rntxt_JobsMinSalary.Text != "")
            //    _obj_Smhr_Positions.POSITIONS_MINSAL = Convert.ToDecimal(rntxt_JobsMinSalary.Text);
            ShowCheckedItems(RadListBox1, Label1);
            _obj_Smhr_Positions.POSITIONS_SKILLS = Convert.ToString(Label1.Text);
            Label lblqualification = new Label();
            ShowCheckedItems(rcmb_Qualification, lblqualification);
            _obj_Smhr_Positions.POSITIONS_QUALIFICATION = lblqualification.Text;


            _obj_Smhr_Positions.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_Positions.CREATEDDATE = DateTime.Now;

            _obj_Smhr_Positions.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_Positions.LASTMDFDATE = DateTime.Now;

            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_EDIT":
                    _obj_Smhr_Positions.POSITIONS_ID = Convert.ToInt32(lbl_PositionsID.Text);
                    _obj_Smhr_Positions.POSITIONS_JOBSID = Convert.ToInt32(lbl_PositionJobsID.Text);

                    _obj_Smhr_Positions.OPERATION = operation.Update;
                    if (BLL.set_Positions(_obj_Smhr_Positions))
                    {
                        BLL.ShowMessage(this, "Information Updated Successfully");
                        // tdEstablishMents.Visible = true;
                    }
                    else
                        BLL.ShowMessage(this, "Information Not Saved");

                    break;
                case "BTN_SAVE":

                    _obj_Smhr_Positions.OPERATION = operation.Check;
                    if (Convert.ToString(BLL.get_Positions(_obj_Smhr_Positions).Rows[0]["Count"]) != "0")
                    {
                        BLL.ShowMessage(this, "Positions with this Name Already Exists for this Job");
                        return;
                    }
                    _obj_Smhr_Positions.OPERATION = operation.Insert;
                    if (BLL.set_Positions(_obj_Smhr_Positions))
                    {
                        BLL.ShowMessage(this, "Information Saved Successfully");
                        // tdEstablishMents.Visible = true;
                    }
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                default:
                    break;
            }
            Rm_PO_page.SelectedIndex = 0;
            LoadGrid();
            Rg_Positions.DataBind();

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Positions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void clearControls()
    {
        try
        {
            lbl_PositionsID.Text = string.Empty;
            lbl_PositionJobsID.Text = string.Empty;
            rtxt_PositionsCode.Text = string.Empty;
            rtxt_PositionsDesc.Text = string.Empty;
            rtxtNoEstablishment.Text = string.Empty;
            rcmb_PositionsJobs.SelectedIndex = -1;
            rcmb_PositionsStatus.SelectedIndex = -1;
            rdtp_PositionsStartDate.SelectedDate = null;
            rdtp_PositionsEndDate.SelectedDate = null;
            rtxt_PositionsCode.Enabled = true;
            lbl_PositionsStartDate0.SelectedDate = null;
            lbl_PositionsEndDate0.SelectedDate = null;
            rcmb_JobsGrade.SelectedIndex = -1;
            //rntxt_JobsMaxSalary.Text = string.Empty;
            //rntxt_JobsMinSalary.Text = string.Empty;

            btn_Save.Visible = false;
            btn_Edit.Visible = false;
            Rm_PO_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Positions", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Positions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rg_Positions_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Positions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_status_selectedchanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (Convert.ToInt32(rcmb_PositionsStatus.SelectedItem.Value) == 1)
            {
                SMHR_EMPLOYEE _obj_smhr_employee = new SMHR_EMPLOYEE();
                _obj_smhr_employee.OPERATION = operation.CHECKDUPLICATE;
                _obj_smhr_employee.EMP_DESIGNATION_ID = Convert.ToInt32(Session["position_id"]);
                _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtemp = BLL.get_Employeedetail(_obj_smhr_employee);
                if (dtemp.Rows.Count > 0)
                {
                    BLL.ShowMessage(this, "You cannot inactive this position as employees are already assigned.");
                    rcmb_PositionsStatus.SelectedIndex = 1;
                    return;

                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Positions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_PositionsJobs_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_PositionsJobs.SelectedIndex == -1 || rcmb_PositionsJobs.SelectedIndex == 0)
            {
                lbl_PositionsStartDate0.SelectedDate = null;
                lbl_PositionsEndDate0.SelectedDate = null;
            }
            else
            {
                DataTable dttemp = new DataTable();
                dttemp = BLL.get_Jobs(new SMHR_JOBS(Convert.ToInt32(rcmb_PositionsJobs.SelectedItem.Value)));
                if (dttemp.Rows.Count != 0)
                {
                    if (dttemp.Rows[0]["JOBS_STARTDATE"] != DBNull.Value)
                        lbl_PositionsStartDate0.SelectedDate = Convert.ToDateTime(dttemp.Rows[0]["JOBS_STARTDATE"]);
                    if (dttemp.Rows[0]["JOBS_ENDDATE"] != DBNull.Value)
                        lbl_PositionsEndDate0.SelectedDate = Convert.ToDateTime(dttemp.Rows[0]["JOBS_ENDDATE"]);
                }
                else
                {
                    lbl_PositionsStartDate0.SelectedDate = null;
                    lbl_PositionsEndDate0.SelectedDate = null;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Positions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private static void ShowCheckedItems(RadListBox listBox, Label label)
    {
        try
        {
            StringBuilder sb = new StringBuilder();
            IList<RadListBoxItem> collection = listBox.CheckedItems;
            foreach (RadListBoxItem item in collection)
            {
                if (sb.Length == 0)
                {
                    sb.Append(item.Value);
                }
                else
                {
                    sb.Append("," + item.Value);
                }
            }

            label.Text = sb.ToString();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(HttpContext.Current.Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Positions", ex.StackTrace, DateTime.Now);
            HttpContext.Current.Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void getCheckedItems(RadListBox listBox, Label label)
    {
        try
        {
            string strVal = label.Text;
            string[] Ar = strVal.Split(new Char[] { ',' });
            for (int i = 0; i < Ar.Length; i++)
            {
                string strTemp = Ar[i].Trim();

                if (listBox.FindItemByValue(strTemp) != null)
                    listBox.FindItemByValue(strTemp).Checked = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Positions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    #region Import Position

    //protected void btn_Import_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        string strcon = null;
    //        string errormsg = "";
    //        string filename = fupld_Position.FileName;
    //        filedatetime = Convert.ToString(DateTime.Now.TimeOfDay) + "_" + filename;
    //        filedatetime = filedatetime.Replace("/", "").Replace(":", ".");
    //        if (fupld_Position.HasFile)
    //        {
    //            if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == false)
    //            {
    //                System.IO.Directory.CreateDirectory(Server.MapPath("~/IMPORT_EXCEL/"));
    //            }
    //            fupld_Position.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/IMPORT_EXCEL/"), filedatetime));
    //            string filename1 = Server.MapPath("~/IMPORT_EXCEL/") + ("") + (Convert.ToString(filedatetime));
    //            FileInfo fileInfo = new FileInfo(filename1);
    //            if (fileInfo.Exists)
    //            {
    //                string path = MapPath(filename);
    //                string ext = Path.GetExtension(path);
    //                string type = string.Empty;

    //                //  set known types based on file extension  
    //                if (ext != null)
    //                {
    //                    switch (ext.ToLower())
    //                    {
    //                        case ".xls": type = "excel";
    //                            break;
    //                        case ".xlsx": type = "excel";
    //                            break;
    //                        default: type = string.Empty;
    //                            break;
    //                    }
    //                }
    //                if (type == string.Empty)
    //                {
    //                    if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == true)
    //                    {
    //                        string path1 = Server.MapPath("~/IMPORT_EXCEL/") + ("") + (Convert.ToString(filedatetime));
    //                        System.IO.File.Delete(path1);
    //                    }
    //                    BLL.ShowMessage(this, "Please select the Excel File  (Eg: Excel.xlsx). ");
    //                    return;
    //                }
    //            }
    //        }
    //        else
    //        {
    //            BLL.ShowMessage(this, "Please Select the File to be uploaded");
    //            return;
    //        }
    //        string strpath = Server.MapPath("~/IMPORT_EXCEL/");
    //        strpath = strpath + filedatetime;


    //        // Getting data from excell file to dataset.
    //        strcon = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source='" + strpath + "';" + "Extended Properties=Excel 12.0;";
    //        OleDbConnection objConn = null;
    //        objConn = new OleDbConnection(strcon);
    //        objConn.Open();

    //        DataTable dt_check = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
    //        string sheetname;
    //        if (dt_check == null)
    //        {
    //            objConn.Close();
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        else
    //        {
    //            sheetname = Convert.ToString(dt_check.Rows[0]["TABLE_NAME"]);
    //        }
    //        OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM  [" + sheetname + "]", strcon);
    //        da.Fill(ds);
    //        ds.Tables[0].Columns.Add("Error Message");
    //        objConn.Close();
    //        DataTable dt = new DataTable();
    //        DataTable dtfail = new DataTable();
    //        string projecttype = null;
    //        Int32 rowno = 0;
    //        string columnno = null;
    //        //Boolean filestatus = true;
    //        dtfail.Columns.Add("S.NO", typeof(Int32));
    //        dtfail.Columns.Add("ROWNO", typeof(Int32));
    //        dtfail.Columns.Add("COLUMNS NAME", typeof(string));
    //        //For Checking The Position Name Field Is There or not in the excel sheet
    //        if (!(ds.Tables[0].Columns[0].ToString().Trim() == "Name *"))
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        //For Checking The Position Description Field Is There or not in the excel sheet
    //        if (!(ds.Tables[0].Columns[1].ToString().Trim() == "Description"))
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        //For Checking The Availability of Job Field
    //        if (!(ds.Tables[0].Columns[2].ToString() == "Job *"))
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }

    //        //For Checking The Availability of Status
    //        if (!(ds.Tables[0].Columns[3].ToString() == "Status *"))
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }

    //        //For Checking The Availability of Start Date 
    //        if (!(ds.Tables[0].Columns[4].ToString() == "Start Date *(DD/MM/YYYY)"))
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        //For Checking The Availability of End Date 
    //        if (!(ds.Tables[0].Columns[5].ToString() == "End Date (DD/MM/YYYY)"))
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }

    //        //For Checking The Availability of the Records In The Excel Sheet
    //        if (ds.Tables[0].Rows.Count == 0)
    //        {
    //            BLL.ShowMessage(this, "Imported Successfully But There is No Record Available!");
    //            Delete_Excel_File();
    //            return;
    //        }
    //        else
    //        {
    //            bool IsCorrect = true;
    //            bool found = false;
    //            int jobid = 0;
    //            SMHR_POSITIONS _obj_Smhr_Positions = new SMHR_POSITIONS();
    //            loadDropdown();
    //            //For Validating The Excel Sheet
    //            for (int rowindex = 0; rowindex < ds.Tables[0].Rows.Count; rowindex++)
    //            {

    //                if (Convert.ToString(ds.Tables[0].Rows[rowindex][0]) != string.Empty)
    //                {
    //                    _obj_Smhr_Positions.OPERATION = operation.Check;
    //                    _obj_Smhr_Positions.POSITIONS_CODE = Convert.ToString(ds.Tables[0].Rows[rowindex][0]);
    //                    _obj_Smhr_Positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                    if (Convert.ToString(BLL.get_Positions(_obj_Smhr_Positions).Rows[0]["Count"]) == "1")
    //                    {
    //                        IsCorrect = false;
    //                        rowno = rowindex + 2;
    //                        columnno = columnno + "," + "Name *";
    //                        errormsg = "Position Name Is Already Exists  ";
    //                    }
    //                }
    //                if (Convert.ToString(ds.Tables[0].Rows[rowindex][2]) != string.Empty)
    //                {
    //                    for (int count = 0; count < rcmb_PositionsJobs.Items.Count; count++)
    //                    {
    //                        if (Convert.ToString(ds.Tables[0].Rows[rowindex][2]) == rcmb_PositionsJobs.Items[count].Text)
    //                        {
    //                            found = true;
    //                            jobid = Convert.ToInt32(rcmb_PositionsJobs.Items[count].Value);
    //                        }
    //                    }
    //                    if (!found)
    //                    {
    //                        IsCorrect = false;
    //                        rowno = rowindex + 2;
    //                        columnno = columnno + "," + "Job";
    //                        if (errormsg != string.Empty)
    //                            errormsg = errormsg + "," + "Job Which You Have Entered Is Not Exists   ";
    //                        else
    //                            errormsg = "Job Which You Have Entered Is Not Exists   ";
    //                    }
    //                }
    //                if (Convert.ToString(ds.Tables[0].Rows[rowindex][3]) == string.Empty)
    //                {
    //                    IsCorrect = false;
    //                    rowno = rowindex + 2;
    //                    columnno = columnno + "," + "Status *";
    //                    if (errormsg != string.Empty)
    //                        errormsg = errormsg + "," + "Job Status Should Be Active Or In Active   ";
    //                    else
    //                        errormsg = "Job Status Should Be Active Or In Active  ";

    //                }
    //                else
    //                {
    //                    if (!((Convert.ToString(ds.Tables[0].Rows[rowindex][3]).ToUpper() == "ACTIVE") || (Convert.ToString(ds.Tables[0].Rows[rowindex][3]).ToUpper() == "INACTIVE")))
    //                    {
    //                        IsCorrect = false;
    //                        rowno = rowindex + 2;
    //                        columnno = columnno + "," + "Status *";
    //                        if (errormsg != string.Empty)
    //                            errormsg = errormsg + "," + "Job Status Should Be Active Or In Active   ";
    //                        else
    //                            errormsg = "Job Status Should Be Active Or In Active  ";
    //                    }
    //                }
    //                if ((Convert.ToString(ds.Tables[0].Rows[rowindex][4]) != string.Empty))
    //                {
    //                    if (!(BLL.CheckDateFormat(Convert.ToString(ds.Tables[0].Rows[rowindex][4].ToString()))))
    //                    {
    //                        IsCorrect = false;
    //                        rowno = rowindex + 2;
    //                        columnno = columnno + "," + "Start Date *(DD/MM/YYYY)";
    //                        errormsg = errormsg + "," + "Enter Start Date In The Correct Format  ";
    //                    }
    //                }
    //                else
    //                {
    //                    IsCorrect = false;
    //                    rowno = rowindex + 2;
    //                    columnno = columnno + "," + "Start Date *(DD/MM/YYYY)";
    //                    errormsg = errormsg + "," + "Enter Start Date   ";
    //                }
    //                if ((Convert.ToString(ds.Tables[0].Rows[rowindex][4]) != string.Empty) && (Convert.ToString(ds.Tables[0].Rows[rowindex][5]) != string.Empty))
    //                {

    //                    bool stdatetime = true;
    //                    if (!(BLL.CheckDateFormat(Convert.ToString(ds.Tables[0].Rows[rowindex]["Start Date *(DD/MM/YYYY)"]))))
    //                    {
    //                        stdatetime = false;
    //                        IsCorrect = false;
    //                        rowno = rowindex + 2;
    //                        columnno = columnno + "," + "Start Date *(DD/MM/YYYY)";
    //                        errormsg = errormsg + "," + "Enter Correct Date Format For Start Date   ";
    //                        // break;
    //                    }

    //                    if (!(BLL.CheckDateFormat(Convert.ToString(ds.Tables[0].Rows[rowindex]["End Date (DD/MM/YYYY)"]))))
    //                    {
    //                        stdatetime = false;
    //                        IsCorrect = false;
    //                        rowno = rowindex + 2;
    //                        columnno = columnno + "," + "End Date (DD/MM/YYYY)";
    //                        errormsg = errormsg + "," + "Enter Correct Date Format For End Date   ";
    //                        //break;
    //                    }
    //                    if (!stdatetime)
    //                    {
    //                        if (!(Convert.ToDateTime(ds.Tables[0].Rows[rowindex][4].ToString()) > (Convert.ToDateTime(ds.Tables[0].Rows[rowindex][5].ToString()))))
    //                        {
    //                            IsCorrect = false;
    //                            rowno = rowindex + 2;
    //                            columnno = columnno + "," + "End Date (DD/MM/YYYY)";
    //                            columnno = columnno + "," + "Start Date *(DD/MM/YYYY)";
    //                            errormsg = errormsg + "," + "Start Date Should Be Greater Than End Date   ";
    //                        }
    //                    }
    //                }
    //                if (!IsCorrect)
    //                {
    //                    DataRow newrow = dtfail.NewRow();
    //                    newrow["S.NO"] = dtfail.Rows.Count + 1;
    //                    newrow["ROWNO"] = rowno;
    //                    newrow["COLUMNS NAME"] = columnno;
    //                    dtfail.Rows.Add(newrow);
    //                    ds.Tables[0].Rows[rowindex]["Error Message"] = errormsg;
    //                }
    //                // For checking The Duplicate Row in Excel
    //                for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
    //                {
    //                    if (ds.Tables[0].Rows[rowindex]["Name *"].ToString().Trim() == ds.Tables[0].Rows[k]["Name *"].ToString().Trim())
    //                    {
    //                        if (rowindex != k)
    //                        {
    //                            errormsg = errormsg + "," + " Position Name is repeated in Excel Sheet";
    //                            IsCorrect = false;
    //                            rowno = rowindex + 2;
    //                            columnno = "Name *";
    //                        }
    //                    }
    //                }
    //            }
    //            if (dtfail.Rows.Count > 0)
    //            {
    //                Session["dt_fail"] = dtfail;
    //                Session["ds_data"] = ds;
    //                Delete_Excel_File();
    //                Telerik.Web.UI.RadWindow newwindow = new Telerik.Web.UI.RadWindow();
    //                newwindow.ID = "RadWindow_import";
    //                newwindow.NavigateUrl = "~/Masters/Importresult.aspx";
    //                newwindow.Title = "Import Job Process";
    //                newwindow.Width = 1150;
    //                newwindow.Height = 580;
    //                newwindow.VisibleOnPageLoad = true;
    //                if (RWM_POSITIONPOSTREPLY.Windows.Count > 1)
    //                {
    //                    RWM_POSITIONPOSTREPLY.Windows.RemoveAt(1);
    //                }
    //                RWM_POSITIONPOSTREPLY.Windows.Add(newwindow);
    //                RWM_POSITIONPOSTREPLY.Visible = true;
    //                return;
    //            }
    //            else
    //            {

    //                // For Dumping Each Record In To The Database
    //                for (int xlrows = 0; xlrows < ds.Tables[0].Rows.Count; xlrows++)
    //                {
    //                    _obj_Smhr_Positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                    _obj_Smhr_Positions.POSITIONS_CODE = Convert.ToString(ds.Tables[0].Rows[xlrows][0]);
    //                    _obj_Smhr_Positions.POSITIONS_DESC = Convert.ToString(ds.Tables[0].Rows[xlrows][1]);
    //                    if (Convert.ToString(ds.Tables[0].Rows[xlrows][2]) != string.Empty)
    //                    {
    //                        for (int count = 0; count < rcmb_PositionsJobs.Items.Count; count++)
    //                        {
    //                            if (Convert.ToString(ds.Tables[0].Rows[xlrows][2]) == rcmb_PositionsJobs.Items[count].Text)
    //                            {
    //                                _obj_Smhr_Positions.POSITIONS_ID = Convert.ToInt32(rcmb_PositionsJobs.Items[count].Value);
    //                                break;
    //                            }
    //                        }
    //                    }

    //                    if (Convert.ToString(ds.Tables[0].Rows[xlrows][2]) != string.Empty)
    //                    {
    //                        _obj_Smhr_Positions.POSITIONS_JOBSID = jobid;
    //                    }
    //                    if (Convert.ToString(ds.Tables[0].Rows[xlrows][3]) != string.Empty)
    //                    {
    //                        if (Convert.ToString(ds.Tables[0].Rows[xlrows][3]).ToUpper() == "ACTIVE")
    //                            _obj_Smhr_Positions.POSITIONS_STATUS = 0;
    //                        else
    //                            _obj_Smhr_Positions.POSITIONS_STATUS = 1;

    //                    }
    //                    string sdate = "";
    //                    string edate = "";
    //                    sdate = ds.Tables[0].Rows[xlrows][4].ToString();
    //                    edate = ds.Tables[0].Rows[xlrows][5].ToString();
    //                    bool wrongsdformat = sdate.Contains(".");
    //                    bool wrongedformat = edate.Contains(".");
    //                    if (wrongsdformat)
    //                        sdate = sdate.Replace(".", "/");
    //                    if (wrongedformat)
    //                        edate = edate.Replace(".", "/");

    //                    _obj_Smhr_Positions.SDATE = sdate;
    //                    _obj_Smhr_Positions.EDATE = edate;

    //                    _obj_Smhr_Positions.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
    //                    _obj_Smhr_Positions.CREATEDDATE = DateTime.Now;

    //                    _obj_Smhr_Positions.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
    //                    _obj_Smhr_Positions.LASTMDFDATE = DateTime.Now;
    //                    _obj_Smhr_Positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

    //                    _obj_Smhr_Positions.OPERATION = operation.Check;
    //                    _obj_Smhr_Positions.POSITIONS_CODE = Convert.ToString(ds.Tables[0].Rows[xlrows][0]);
    //                    _obj_Smhr_Positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                    if (Convert.ToString(BLL.get_Positions(_obj_Smhr_Positions).Rows[0]["Count"]) == "1")
    //                    {
    //                        continue;
    //                        //IsCorrect = true;
    //                    }
    //                    else
    //                    {
    //                        _obj_Smhr_Positions.OPERATION = operation.Insert1;
    //                        if (BLL.set_Positions(_obj_Smhr_Positions))
    //                            IsCorrect = true;
    //                    }

    //                }
    //                Rm_PO_page.SelectedIndex = 0;
    //                LoadGrid();
    //                Rm_PO_page.DataBind();
    //                if (IsCorrect)
    //                    BLL.ShowMessage(this, "Information Uploaded Successfully");
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_position.aspx", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("Frm_ErrorPage.aspx");
    //    }

    //}

    protected void Delete_Excel_File()
    {
        try
        {

            ds.Dispose();
            if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == true)
            {
                // FileUpload_Task.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Corporate_Contract_Docs/") + Convert.ToString(rcmb_taskPorjectname.SelectedItem.Text.Replace("/", "_")), filename));
                string strpath = Server.MapPath("~/IMPORT_EXCEL/");
                DirectoryInfo dirinfo = new DirectoryInfo(strpath);
                strpath = strpath + filedatetime;
                FileInfo fi = new FileInfo(strpath);
                {
                    fi.Delete();
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Positions", ex.StackTrace, DateTime.Now);
            Response.Redirect("Frm_ErrorPage.aspx");
        }
    }
    #endregion
    protected void RadEstablishMents_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            SMHR_POSITIONS _obj_smhr_Position = new SMHR_POSITIONS();
            _obj_smhr_Position.POSITIONS_ID = Convert.ToInt32(lbl_PositionsID.Text);
            _obj_smhr_Position.OPERATION = operation.Select2;
            DataTable DT = BLL.get_Positions(_obj_smhr_Position);
            RadEstablishMents.DataSource = DT;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Positions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}