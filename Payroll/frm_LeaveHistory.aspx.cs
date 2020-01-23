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
using Telerik.Web.UI;
using System.Text;
using System.Collections.Generic;


public partial class frm_LeaveHistory : System.Web.UI.Page
{
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    //SMHR_PERIOD _obj_smhr_period;
    DataTable dt_Details;
    //SMHR_LEAVEPROCESS obj_smhr_leave;
    //SMHR_PAYROLL _obj_smhr_payroll;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
            if (!Page.IsPostBack)
            {
                //loadDropdown();
                //LoadPeriods();
                //    LoadPeriodElements();
                LoadGrid();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveHistory", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    //protected void loadDropdown()
    //{
    //    rcmb_BusinessUnit.Items.Clear();
    //    _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
    //    _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //    _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
    //    rcmb_toperiod.Items.Clear();
    //   // rcmb_periodelement.Items.Clear();  
    //    DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
    //    rcmb_BusinessUnit.DataSource = dt_BUDetails;
    //    rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
    //    rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
    //    rcmb_BusinessUnit.DataBind();
    //    rcmb_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
    //    LoadPeriods();
    // //   LoadPeriodElements();
    //}
    //private void LoadPeriods()
    //{
    //    _obj_smhr_period = new SMHR_PERIOD();
    //    dt_Details = new DataTable();
    //    _obj_smhr_period.OPERATION = operation.Select;
    //    _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //    dt_Details = BLL.get_PeriodHeaderDetails(_obj_smhr_period);
    //    rcmb_toperiod.DataSource = dt_Details;
    //    rcmb_toperiod.DataValueField = "PERIOD_ID";
    //    rcmb_toperiod.DataTextField = "PERIOD_NAME";
    //    rcmb_toperiod.DataBind();
    //    rcmb_toperiod.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
    //}
    //private void LoadPeriodElements()
    //{
    //    _obj_smhr_payroll = new SMHR_PAYROLL();
    //    _obj_smhr_payroll.PERIODDTLID = Convert.ToInt32(rcmb_toperiod.SelectedValue);
    //    _obj_smhr_payroll.MODE = 11;
    //    dt_Details = new DataTable();
    //    dt_Details = BLL.get_payrolltrans(_obj_smhr_payroll);
    //    //if (dt_Details.Rows.Count != 0)
    //    //{
    //    rcmb_periodelement.DataSource = dt_Details;
    //    rcmb_periodelement.DataValueField = "PRDDTL_ID";
    //    rcmb_periodelement.DataTextField = "PRDDTL_NAME";
    //    rcmb_periodelement.DataBind();
    //    //rcmb_periodelement.SelectedIndex = 0;
    //    rcmb_periodelement.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select","0"));
    //}
    //private void LoadPeriodElements()
    //{
    //    obj_smhr_leave = new SMHR_LEAVEPROCESS();
    //    obj_smhr_leave.PERIODELEMENT = Convert.ToInt32(rcmb_toperiod.SelectedValue);
    //    obj_smhr_leave.MODE = 9;
    //    dt_Details = new DataTable();
    //    dt_Details = BLL.Get_LEAVEDETAILS(obj_smhr_leave);
    //    //if (dt_Details.Rows.Count != 0)
    //    //{
    //    rcmb_periodelement.DataSource = dt_Details;
    //    rcmb_periodelement.DataValueField = "PRDDTL_ID";
    //    rcmb_periodelement.DataTextField = "PRDDTL_NAME";
    //    rcmb_periodelement.DataBind();
    //    rcmb_periodelement.SelectedIndex = 0;
    //    rcmb_periodelement.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
    //}
    private void LoadGrid()
    {
        try
        {
            SMHR_LEAVEPROCESS obj_smhr_leave = new SMHR_LEAVEPROCESS();
            SMHR_LOGININFO obj_smhr_login = new SMHR_LOGININFO();

            dt_Details = new DataTable();
            DataTable dt_FormData = new DataTable();
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_LoginDetails = BLL.get_LoginInfo(_obj_SMHR_LoginInfo);
            obj_smhr_login.OPERATION = operation.Check;
            lblCreatedBy.Text = dt_LoginDetails.Rows[0]["LOGIN_USERNAME"].ToString();

            //obj_smhr_leave.MODE = 13;
            //obj_smhr_leave.BUID = Convert.ToInt32(Session["Buid"]);
            ////  lblExecutedDate.Text = dt_FormData.Rows[0]["SMHR_LP_CREATED_DATE"].ToString();
            ////lblFromPeriod.Text = Session["From_Period_id"].ToString();
            //obj_smhr_leave.FROMPERIOD = Convert.ToInt32(Session["From_Period_id"]);
            //obj_smhr_leave.TOPERIOD = Convert.ToInt32(Session["To_Period_id"]);
            //obj_smhr_leave.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            //obj_smhr_leave.CREATEDDATE = Convert.ToDateTime(Session["Executed_Date"]);

            //dt_Details = BLL.Get_LEAVEDETAILS(obj_smhr_leave);
            //    if (dt_Details.Rows.Count > 0)
            //    {
            //        lblBusinessUnit.Text = Convert.ToString(dt_Details.Rows[0]["BUSINESSUNIT_CODE"]);
            //        lblFromPeriod.Text = Convert.ToString(dt_Details.Rows[0]["FROM_PERIOD"]);
            //        lblToPeriod.Text = Convert.ToString(dt_Details.Rows[0]["TO_PERIOD"]);

            //    }
            lblBusinessUnit.Text = Convert.ToString(Session["Buid"].ToString());
            lblFromPeriod.Text = Convert.ToString(Session["From_Period_id"].ToString());
            lblToPeriod.Text = Convert.ToString(Session["To_Period_id"]);
            lblPayElements.Text = Convert.ToString(Session["payitem"]);
            lblExecutedDate.Text = Convert.ToString(Session["Executed_Date"]);

            //    lblBusinessUnit.Text = Session["Buid"].ToString();
            //////  lblExecutedDate.Text = dt_FormData.Rows[0]["SMHR_LP_CREATED_DATE"].ToString();
            //    lblFromPeriod.Text = Session["From_Period_id"].ToString();
            //    lblToPeriod.Text = Session["To_Period_id"].ToString();
            //    lblPayElements.Text = Session["payitem"].ToString();

            obj_smhr_leave.MODE = 7;
            obj_smhr_leave.BUID = Convert.ToInt32(Session["Bu_Id"]);
            obj_smhr_leave.TOPERIOD = Convert.ToInt32(Session["ToPeriod_id"]);
            dt_FormData = BLL.Get_LEAVEDETAILS(obj_smhr_leave);
            RG_ViewHistory.DataSource = dt_FormData;
            RG_ViewHistory.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveHistory", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
      }

    protected void rcmb_toperiod_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            //LoadPeriodElements();
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveHistory", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
      
    //protected void rcmb_periodelement_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    //{
    //    LoadGrid();
       
    //}
    
}
