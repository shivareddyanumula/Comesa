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

public partial class Payroll_frm_Previousdtls : System.Web.UI.Page
{
    SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
    SMHR_GRATUITY _obj_smhr_gratuity = new SMHR_GRATUITY();
    DataTable dt_null = new DataTable();
    #region Loading Businessunit
    /// <summary>
    /// loads the business units
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                DataTable dt_Businessunit = new DataTable();
                _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                _obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"].ToString());
                dt_Businessunit = BLL.get_Business_Units(_obj_smhr_logininfo);
                rcmb_Businessunit.DataSource = dt_Businessunit;
                rcmb_Businessunit.DataTextField = "BUSINESSUNIT_CODE";
                rcmb_Businessunit.DataValueField = "BUSINESSUNIT_ID";
                rcmb_Businessunit.DataBind();
                rcmb_Businessunit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                RG_grattuity.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Previousdtls", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion
    #region Loading Periods
    /// <summary>
    /// based on the businessunit selection we will retrieve the time periods
    /// </summary>
    /// <param name="o"></param>
    /// <param name="e"></param>
    protected void rcmb_Businessunit_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            DataTable dt_periods = new DataTable();
            if (rcmb_Businessunit.SelectedIndex != 0)
            {
                rcmb_Period.Enabled = true;
                _obj_smhr_gratuity.EMP_BUID = Convert.ToInt32(rcmb_Businessunit.SelectedValue.ToString());
                _obj_smhr_gratuity.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                dt_periods = BLL.get_Gratuityperiod(_obj_smhr_gratuity);
                if (dt_periods.Rows.Count > 0)
                {
                    rcmb_Period.DataSource = dt_periods;
                    rcmb_Period.DataTextField = "PERIOD";
                    rcmb_Period.DataBind();
                    rcmb_Period.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                }
                else
                {
                    BLL.ShowMessage(this, "No Employee Has Recieved The Gratuity!");
                    rcmb_Period.Enabled = false;
                }
                RG_grattuity.Visible = true;
                RG_grattuity.DataSource = dt_null;
                RG_grattuity.DataBind();
            }
            else
            {
                BLL.ShowMessage(this, "Select A Businessunit!");
                rcmb_Period.Items.Clear();
                RG_grattuity.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Previousdtls", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion
    #region Selected Period
    /// <summary>
    /// Based On the selected period we will display the employee who got gratuity previously
    /// </summary>
    /// <param name="o"></param>
    /// <param name="e"></param>
    protected void rcmb_Period_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            RG_grattuity.Visible = true;
            DataTable dt_list = new DataTable();
            if (rcmb_Period.SelectedIndex != 0)
            {
                _obj_smhr_gratuity.EMP_PERIOD = Convert.ToDateTime(rcmb_Period.SelectedItem.Text);
                _obj_smhr_gratuity.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                dt_list = BLL.get_emplist(_obj_smhr_gratuity);
                RG_grattuity.DataSource = dt_list;
                RG_grattuity.DataBind();
            }
            else
            {
                BLL.ShowMessage(this, "Select A Period!");
                RG_grattuity.DataSource = dt_null;
                RG_grattuity.DataBind();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Previousdtls", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion
}
