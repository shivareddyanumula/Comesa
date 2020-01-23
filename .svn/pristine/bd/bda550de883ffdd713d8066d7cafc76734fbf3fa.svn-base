using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Text;
using System.Collections;
using Telerik.Web.UI;
using System.Web.UI.HtmlControls;
using System.Globalization;

public partial class Masters_frm_PeriodCalendar : System.Web.UI.Page
{
    protected SMHR_PERIOD _obj_Smhr_Period;
    protected SMHR_PERIODTYPE _obj_Smhr_PeriodType;
    protected SMHR_PERIODDTL _obj_Smhr_Prddtl;

    DataTable dt1;
    DataTable dt;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {

                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Calendar Period");
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
                    Rg_Period.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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

                duration.Visible = false;
                rtxt_Duration.Value = 1;

                LoadCombos();
                BLL.ChangeDateFormat(Convert.ToString(Session["EMP_ID"]), rdtp_StartDate, rdtp_EndDate);
                if (Request.QueryString["POP"] != null)
                {
                    ((HtmlTableRow)Master.FindControl("M_Header")).Style.Add("display", "none");
                    ((HtmlTableRow)Master.FindControl("M_Footer")).Style.Add("display", "none");
                    ((RadMenu)Master.FindControl("MainMenu")).Style.Add("display", "none");
                    ((RadComboBox)Master.FindControl("cmbCulture")).Style.Add("display", "none");
                    ((LinkButton)Master.FindControl("Lnk_LogOut")).Style.Add("display", "none");
                    ((LinkButton)Master.FindControl("lnk_Home")).Style.Add("display", "none");
                }

                BLL.gridDateFormat(Convert.ToString(Session["EMP_ID"]), Rg_Period, "PERIOD_STARTDATE", "PERIOD_ENDDATE");
                BLL.gridDateFormat(Convert.ToString(Session["EMP_ID"]), Rg_PeriodDetails, "PRDDTL_STARTDATE", "PRDDTL_ENDDATE");


            }
            Rg_PeriodDetails.CurrentPageIndex = 0;

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PeriodCalender", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    public void LoadCombos()
    {
        try
        {
            _obj_Smhr_PeriodType = new SMHR_PERIODTYPE();
            rcmb_PeriodType.DataSource = BLL.get_PeriodType(_obj_Smhr_PeriodType);
            rcmb_PeriodType.DataTextField = "PERIODTYPE_NAME";
            rcmb_PeriodType.DataValueField = "PERIODTYPE_ID";
            rcmb_PeriodType.DataBind();
            rcmb_PeriodType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PeriodCalender", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_Smhr_Period = new SMHR_PERIOD();
            _obj_Smhr_Prddtl = new SMHR_PERIODDTL();
            StringBuilder strQry = new StringBuilder();

            //Entities of PERIOD TABLE
            _obj_Smhr_Period = new SMHR_PERIOD();
            // _obj_Smhr_Period.ORGANISATION_ID = 2;
            _obj_Smhr_Period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Period.PERIOD_NAME = Convert.ToString(rtxt_PeriodName.Text);
            _obj_Smhr_Period.PERIOD_TYPE = Convert.ToInt32(rcmb_PeriodType.SelectedItem.Value);
            _obj_Smhr_Period.PERIOD_STARTDATE = (Convert.ToDateTime(Convert.ToDateTime(rdtp_StartDate.SelectedDate).ToShortDateString()));
            _obj_Smhr_Period.PERIOD_ENDDATE = Convert.ToDateTime(rdtp_EndDate.SelectedDate);
            _obj_Smhr_Period.PERIOD_DURATION = Convert.ToInt32(rtxt_Duration.Text);
            _obj_Smhr_Period.PERIOD_DURATIONTYPE = Convert.ToInt32(rcmb_DurationType.SelectedIndex);
            _obj_Smhr_Period.PERIOD_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_Smhr_Period.PERIOD_CREATEDDATE = DateTime.Now;
            _obj_Smhr_Period.PERIOD_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_Smhr_Period.PERIOD_LASTMDFDATE = DateTime.Now;

            if (((Button)sender).ID.ToUpper() == "BTN_EDIT")
            {
                for (int i = 0; i < Rg_PeriodDetails.Items.Count; i++)
                {
                    _obj_Smhr_Prddtl.PRDDTL_ID = Convert.ToInt32(Rg_PeriodDetails.Items[i].Cells[2].Text);
                    _obj_Smhr_Prddtl.PRDDTL_NAME = Convert.ToString(Rg_PeriodDetails.Items[i].Cells[3].Text);
                    //_obj_Smhr_Prddtl.PRDDTL_STARTDATE = Convert.ToDateTime(Rg_PeriodDetails.Items[i].Cells[4].Text);
                    //string date =Rg_PeriodDetails.Items[i].Cells[5].Text;
                    //DateTime dt = DateTime.ParseExact(date, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    //_obj_Smhr_Prddtl.ENDDATE = Convert.ToDateTime(dt);
                    RadComboBox rdcmbstatus;
                    rdcmbstatus = (RadComboBox)Rg_PeriodDetails.Items[i].FindControl("rcmb_Status");
                    _obj_Smhr_Prddtl.PRDDTL_STATUS = Convert.ToInt32(rdcmbstatus.SelectedItem.Value);
                    _obj_Smhr_Prddtl.PRDDTL_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_Smhr_Prddtl.PRDDTL_LASTMDFDATE = DateTime.Now;


                    _obj_Smhr_Prddtl.OPERATION = operation.Update;

                    strQry.Append(BLL.set_PeriodDetails_Calendar(_obj_Smhr_Prddtl) + " \n");


                }

                if (BLL.ExecuteNonQuery(strQry.ToString()))
                    BLL.ShowMessage(this, "Information Updated Successfully");
                else
                    BLL.ShowMessage(this, "Information Not Saved");

            }
            else
            {
                _obj_Smhr_Period.OPERATION = operation.Check;
                if (Convert.ToString(BLL.get_PeriodHeaderDetails_Calendar(_obj_Smhr_Period).Rows[0]["Count"]) != "0")
                {
                    BLL.ShowMessage(this, "Period with this Name Already Exists");
                    return;
                }
                //// to validate the PERIOD START DATE
                //_obj_Smhr_Period.OPERATION = operation.Validate;
                //if (Convert.ToInt32(BLL.get_PeriodHeaderDetails_Calendar(_obj_Smhr_Period).Rows[0]["Count"]) > 0)
                //{
                //    BLL.ShowMessage(this, "Period had already been defined using this date, please select another date");
                //    return;
                //}

                // to validate the PERIOD START DATE
                _obj_Smhr_Period.OPERATION = operation.Validate1;
                _obj_Smhr_Period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_Period.PERIOD_STARTDATE = Convert.ToDateTime(rdtp_StartDate.SelectedDate);
                _obj_Smhr_Period.PERIOD_ENDDATE = Convert.ToDateTime(rdtp_EndDate.SelectedDate);
                if (Convert.ToInt32(BLL.get_PeriodHeaderDetails_Calendar(_obj_Smhr_Period).Rows[0]["Count"]) > 0)
                {
                    BLL.ShowMessage(this, "Period had already been defined using this date, please select another date");
                    return;
                }
                _obj_Smhr_Period.OPERATION = operation.Insert;
                if (BLL.set_PeriodHeaderdetails_Calendar(_obj_Smhr_Period))
                {
                    BLL.ShowMessage(this, "Information Saved Successfully");

                }
                else
                    BLL.ShowMessage(this, "Information Not Saved");



            }
            Rm_Period_page.SelectedIndex = 0;
            LoadMainGrid();
            Rg_Period.DataBind();
            ViewState["Rg_PeriodDetails"] = null;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PeriodCalender", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearControls();
            Rm_Period_page.SelectedIndex = 0;
            ViewState["Rg_PeriodDetails"] = null;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PeriodCalender", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    public void LoadMainGrid()
    {
        try
        {
            _obj_Smhr_Period = new SMHR_PERIOD();
            _obj_Smhr_Period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt = BLL.get_PeriodHeaderDetails_Calendar(_obj_Smhr_Period);
            Rg_Period.DataSource = dt;
            ViewState["Table"] = dt;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PeriodCalender", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Rg_Period_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadMainGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PeriodCalender", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            clearControls();
            Rm_Period_page.SelectedIndex = 1;
            btn_Save.Visible = false;
            ViewState["Rg_PeriodDetails"] = null;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PeriodCalender", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Generate_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_Smhr_Period = new SMHR_PERIOD();
            _obj_Smhr_Period.OPERATION = operation.Empty;
            //_obj_Smhr_Period.PERIOD_ID = null; ;
            _obj_Smhr_Period.PERIOD_NAME = Convert.ToString(rtxt_PeriodName.Text);
            _obj_Smhr_Period.PERIOD_STARTDATE = Convert.ToDateTime(rdtp_StartDate.SelectedDate);
            _obj_Smhr_Period.PERIOD_TYPE = Convert.ToInt32(rcmb_PeriodType.SelectedItem.Value);
            _obj_Smhr_Period.PERIOD_DURATION = Convert.ToInt32(rtxt_Duration.Text);
            if (rcmb_DurationType.SelectedItem.Value != "-1")
            {
                _obj_Smhr_Period.PERIOD_DURATIONTYPE = Convert.ToInt32(rcmb_DurationType.SelectedIndex);
            }
            else
            {
                BLL.ShowMessage(this, "Please select Durtaion Type");
                return;
            }

            dt1 = BLL.GeneratePeriodDetails_Calendar(_obj_Smhr_Period);

            Rg_PeriodDetails.DataSource = dt1;
            ViewState["Rg_PeriodDetails"] = dt1;
            Rg_PeriodDetails.DataBind();
            btn_Save.Visible = true;

            rdtp_EndDate.SelectedDate = Convert.ToDateTime(dt1.Rows[dt1.Rows.Count - 1]["prddtl_enddate"]);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PeriodCalender", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {

            ViewState["Rg_PeriodDetails"] = null;
            _obj_Smhr_Period = new SMHR_PERIOD();
            _obj_Smhr_Prddtl = new SMHR_PERIODDTL();
            _obj_Smhr_Period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Period.PERIOD_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            dt = BLL.get_PeriodHeaderDetails_Calendar(_obj_Smhr_Period);
            if (dt.Rows.Count > 0)
            {
                rtxt_PeriodName.Text = Convert.ToString(dt.Rows[0]["PERIOD_NAME"]);
                rcmb_PeriodType.SelectedIndex = rcmb_PeriodType.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["PERIOD_TYPE"]));
                rdtp_StartDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["PERIOD_STARTDATE"]);
                rdtp_EndDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["PERIOD_ENDDATE"]);
                rtxt_Duration.Text = Convert.ToString(dt.Rows[0]["PERIOD_DURATION"]);
                rcmb_PeriodType_SelectedIndexChanged(null, null);
                rcmb_DurationType.SelectedIndex = rcmb_DurationType.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["PERIOD_DURATIONTYPE"]));

                rtxt_PeriodName.Enabled = false;
                rcmb_PeriodType.Enabled = false;
                rdtp_StartDate.Enabled = false;
                rdtp_EndDate.Enabled = false;
                rtxt_Duration.Enabled = false;
                rcmb_DurationType.Enabled = false;

                Rm_Period_page.SelectedIndex = 1;
                btn_GeneratePeriods.Visible = false;
                btn_Save.Visible = false;
                //code for security
                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    btn_Edit.Visible = false;

                }

                else
                {
                    btn_Edit.Visible = true;
                }

                _obj_Smhr_Prddtl.OPERATION = operation.Select;
                _obj_Smhr_Prddtl.PRDDTL_PERIOD_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));

                DataTable dttemp = BLL.get_PeriodDetails_Calendar(_obj_Smhr_Prddtl);

                ViewState["Rg_PeriodDetails"] = dttemp;
                Rg_PeriodDetails.DataSource = dttemp;
                Rg_PeriodDetails.DataBind();
            }
            else
            {
                BLL.ShowMessage(this, "The End Date for the Period Define has been completed");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PeriodCalender", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void clearControls()
    {
        try
        {
            rtxt_PeriodName.Enabled = true;
            rcmb_PeriodType.Enabled = true;
            rdtp_StartDate.Enabled = true;
            rtxt_Duration.Enabled = true;
            rcmb_DurationType.Enabled = true;

            Rg_PeriodDetails.DataSource = null;
            Rg_PeriodDetails.DataBind();
            rtxt_PeriodName.Text = string.Empty;
            rcmb_PeriodType.SelectedIndex = -1;
            rdtp_StartDate.SelectedDate = null;
            rdtp_EndDate.SelectedDate = null;
            //rtxt_Duration.Text = string.Empty;
            rcmb_DurationType.SelectedIndex = -1;
            btn_Save.Visible = false;
            btn_Edit.Visible = false;
            //code for security
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_GeneratePeriods.Visible = false;

            }

            else
            {
                btn_GeneratePeriods.Visible = true;
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PeriodCalender", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_PeriodType_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rcmb_DurationType.Items.Clear();
            _obj_Smhr_PeriodType = new SMHR_PERIODTYPE();
            _obj_Smhr_PeriodType.PERIODTYPE_ID = Convert.ToInt32(rcmb_PeriodType.SelectedItem.Value);
            DataTable dtperiodtype = BLL.get_PeriodType(_obj_Smhr_PeriodType);
            int days = Convert.ToInt32(dtperiodtype.Rows[0]["PERIODTYPE_NOOFDAYS"]);

            if (days >= 31)
            {
                rcmb_DurationType.Items.Add(new RadComboBoxItem("Select", "-1"));
                rcmb_DurationType.Items.Add(new RadComboBoxItem("Years", "1"));

            }
            else
            {
                rcmb_DurationType.Items.Add(new RadComboBoxItem("Select", "-1"));
                rcmb_DurationType.Items.Add(new RadComboBoxItem("Years", "1"));
                rcmb_DurationType.Items.Add(new RadComboBoxItem("Months", "2"));
            }

            Rg_PeriodDetails.DataSource = null;
            Rg_PeriodDetails.DataBind();
            rcmb_DurationType.SelectedIndex = 1;
            btn_Save.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PeriodCalender", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Rg_PeriodDetails_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            if (ViewState["Rg_PeriodDetails"] != null)
            {
                DataTable dttemp = (DataTable)ViewState["Rg_PeriodDetails"];
                Rg_PeriodDetails.DataSource = dttemp;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PeriodCalender", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}