using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using SMHR;
using Telerik.Web.UI;

public partial class bonuspast : System.Web.UI.Page
{
    smhr_Bonus_trans _OBJ_BONUS_TRANS;
    SMHR_PERIOD _obj_smhr_period;
    SMHR_PAYROLL _obj_smhr_payroll;
    static DataTable dt_Details;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_BONUSMASTER1 _obj_smhr_bonusmaster = new SMHR_BONUSMASTER1();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                LoadCombos();
            }
        }
        catch(Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("", ""), "bonuspast",ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
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
            rcmb_businessunit.DataSource = dt_BUDetails;
            rcmb_businessunit.DataValueField = "BUSINESSUNIT_ID";
            rcmb_businessunit.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_businessunit.DataBind();
            rcmb_businessunit.Items.Insert(0, new RadComboBoxItem("Select"));
            rg_bonuspast.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "bonuspast", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    protected void rcmb_businessunit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_businessunit.SelectedIndex > 0)
            {
                _obj_smhr_period = new SMHR_PERIOD();
                dt_Details = new DataTable();
                _obj_smhr_period.OPERATION = operation.Select;
                _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
                _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //_obj_SMHR_LoginInfo.LOGIN_ID = 53;
                dt_Details = BLL.get_PeriodHeaderDetails(_obj_smhr_period);
                rcmb_period.DataSource = dt_Details;
                rcmb_period.DataValueField = "PERIOD_ID";
                rcmb_period.DataTextField = "PERIOD_NAME";
                rcmb_period.DataBind();
                rcmb_period.Items.Insert(0, new RadComboBoxItem("Select"));
                rg_bonuspast.Visible = false;
            }
            else
            {
                rcmb_period.Items.Clear();
                rg_bonuspast.Visible = false;
                rcmb_periodelements.Items.Clear();
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "bonuspast", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


    }
    protected void rcmb_period_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_period.SelectedIndex > 0)
            {
                _obj_smhr_payroll = new SMHR_PAYROLL();
                _obj_smhr_payroll.PERIODDTLID = Convert.ToInt32(rcmb_period.SelectedValue.ToString());
                _obj_smhr_payroll.MODE = 11;
                dt_Details = new DataTable();
                dt_Details = BLL.get_payrolltrans(_obj_smhr_payroll);
                rcmb_periodelements.DataSource = dt_Details;
                rcmb_periodelements.DataValueField = "PRDDTL_ID";
                rcmb_periodelements.DataTextField = "PRDDTL_NAME";
                rcmb_periodelements.DataBind();
                rcmb_periodelements.Items.Insert(0, new RadComboBoxItem("Select"));
            }
            else
            {
                rcmb_periodelements.Items.Clear();
                rg_bonuspast.Visible = false;
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "bonuspast", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_periodelements_SelectedIndexChanged1(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_periodelements.SelectedIndex > 0)
            {
                SMHR_BONUSMASTER1 _obj_bm = new SMHR_BONUSMASTER1();
                _OBJ_BONUS_TRANS = new smhr_Bonus_trans();
                _OBJ_BONUS_TRANS.BONUS_BU_ID = Convert.ToInt32(rcmb_businessunit.SelectedItem.Value);
                _OBJ_BONUS_TRANS.BONUS_PERIOD_ID = Convert.ToInt32(rcmb_period.SelectedItem.Value);
                _OBJ_BONUS_TRANS.BONUS_PERIOD_ELEMENTS = Convert.ToInt32(rcmb_periodelements.SelectedItem.Value);
                _OBJ_BONUS_TRANS.OPERATION = operation.Get;
                DataTable dt_details_past = BLL.Get_SMHR_BONUS_TRANS1(_OBJ_BONUS_TRANS);
                ViewState["BONUS_TRANS"] = dt_details_past;
                dt_details_past.Columns.Add("SI_NO");
                if (dt_details_past.Rows.Count != 0)
                {
                    for (int j = 0; j < dt_details_past.Rows.Count; j++)
                    {
                        dt_details_past.Rows[j]["SI_NO"] = j + 1;
                    }
                }
                rg_bonuspast.DataSource = dt_details_past;
                rg_bonuspast.DataBind();
                rg_bonuspast.Visible = true;
            }
            else
            {
                rg_bonuspast.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "bonuspast", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
}
