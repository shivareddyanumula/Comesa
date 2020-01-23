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

public partial class Payroll_frm_CopyExemptions : System.Web.UI.Page
{
    #region References
    /// <summary>
    /// this region will consists of classes and there instances 
    /// which were used throughout this class
    /// </summary>
     SMHR_LOGININFO _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
     SMHR_HRA _obj_Smhr_Hra = new SMHR_HRA();
     SMHR_PERIOD _obj_smhr_period = new SMHR_PERIOD();
     SMHR_TAX_TRANS _obj_smhr_tax_trans = new SMHR_TAX_TRANS();
     DataTable dt_Details = new DataTable();
    #endregion

    #region Page Load
    /// <summary>
    /// this region will load the information when first time page is loaded
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Loadcombos();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CopyExemptions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
   
     #endregion

    #region Loading Methods
    /// <summary>
    /// this region will load the combo boxes and even clears the combo boxes
    /// </summary>
    private void Loadcombos()
    {
        try
        {
            //clearing controls
            rcmb_Businessunit.Items.Clear();
            rcmb_Exempteditem.Items.Clear();
            rcmb_Newfinperiod.Items.Clear();
            rcmb_Oldfinperiod.Items.Clear();
            btn_Copy.Enabled = false;

            // loading Business units
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            dt_Details = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            rcmb_Businessunit.DataSource = dt_Details;
            rcmb_Businessunit.DataValueField = "BUSINESSUNIT_ID";
            rcmb_Businessunit.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_Businessunit.DataBind();
            rcmb_Businessunit.Items.Insert(0, new RadComboBoxItem("Select"));


            // loading all financial period elements
            _obj_smhr_period.OPERATION = operation.Select;
            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_PeriodHeaderDetails(_obj_smhr_period);
            rcmb_Oldfinperiod.DataSource = dt_Details;
            rcmb_Oldfinperiod.DataTextField = "PERIOD_NAME";
            rcmb_Oldfinperiod.DataValueField = "PERIOD_ID";
            rcmb_Oldfinperiod.DataBind();
            rcmb_Oldfinperiod.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CopyExemptions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void Clearcontrols()
    {
        try
        {
            // clearing the selection of combo boxes
            rcmb_Businessunit.ClearSelection();
            rcmb_Oldfinperiod.ClearSelection();
            rcmb_Newfinperiod.Items.Clear();
            rcmb_Newfinperiod.Items.Insert(0, new RadComboBoxItem("", ""));
            rcmb_Exempteditem.Items.Clear();
            rcmb_Exempteditem.Items.Insert(0, new RadComboBoxItem("", ""));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CopyExemptions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    #region Selection Changed Methods
    /// <summary>
    /// this region will load the information based on the selection of each combo box
    /// </summary>
    /// <param name="o"></param>
    /// <param name="e"></param>
    protected void rcmb_Businessunit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Businessunit.SelectedIndex <= 0)
            {
                Clearcontrols();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CopyExemptions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }   

    protected void rcmb_Oldfinperiod_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Businessunit.SelectedIndex <= 0)
                Clearcontrols();
            else
            {
                if (rcmb_Oldfinperiod.SelectedIndex <= 0)
                {
                    rcmb_Newfinperiod.Items.Clear();
                    rcmb_Exempteditem.Items.Clear();
                    rcmb_Exempteditem.Items.Insert(0, new RadComboBoxItem(""));
                    // rcmb_Oldfinperiod.Items.Insert(0, new RadComboBoxItem(""));
                    BLL.ShowMessage(this, "Select Old Financial Period");
                }
                else
                {
                    // loading the financail period which is greater than the old financial period
                    _obj_smhr_tax_trans.Mode = 5;
                    _obj_smhr_tax_trans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_tax_trans.SMHR_EMPTAX_PERIOD_ID = Convert.ToInt32(rcmb_Oldfinperiod.SelectedValue);
                    dt_Details = BLL.get_Tax_trans(_obj_smhr_tax_trans);
                    if (dt_Details.Rows.Count > 0)
                    {
                        rcmb_Newfinperiod.Items.Clear();
                        rcmb_Newfinperiod.DataSource = dt_Details;
                        rcmb_Newfinperiod.DataTextField = "PERIOD_NAME";
                        rcmb_Newfinperiod.DataValueField = "PERIOD_ID";
                        rcmb_Newfinperiod.DataBind();
                        rcmb_Newfinperiod.Items.Insert(0, new RadComboBoxItem("Select", "0"));
                        btn_Copy.Enabled = true;
                    }
                    else
                    {
                        BLL.ShowMessage(this, "No Other Period Found Which is Greater than Selected Old Financial Period");
                        rcmb_Newfinperiod.Items.Clear();
                        rcmb_Newfinperiod.Items.Insert(0, new RadComboBoxItem(""));
                        btn_Copy.Enabled = false;
                        return;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CopyExemptions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_Newfinperiod_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Oldfinperiod.SelectedIndex > 0)
            {

                // loading exampted elements
                _obj_Smhr_Hra.Mode = 3;
                _obj_Smhr_Hra.SMHR_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                dt_Details = BLL.get_Smhr_Hra(_obj_Smhr_Hra);
                rcmb_Exempteditem.DataSource = dt_Details;
                rcmb_Exempteditem.DataValueField = "SMHR_TAX_ID";
                rcmb_Exempteditem.DataTextField = "SMHR_TAX_NAME";
                rcmb_Exempteditem.DataBind();
                rcmb_Exempteditem.Items.Insert(0, new RadComboBoxItem("Select"));
            }
            else
            {
                BLL.ShowMessage(this, "Select Old financial period");
                rcmb_Newfinperiod.Items.Clear();
                rcmb_Newfinperiod.Items.Insert(0, new RadComboBoxItem(""));
                rcmb_Exempteditem.Items.Clear();
                rcmb_Exempteditem.Items.Insert(0, new RadComboBoxItem(""));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CopyExemptions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_Exempteditem_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Exempteditem.SelectedIndex <= 0)
                BLL.ShowMessage(this, "Select Exempted Element");

            if (rcmb_Newfinperiod.SelectedIndex <= 0)
            {
                rcmb_Exempteditem.Items.Clear();
                rcmb_Exempteditem.Items.Insert(0, new RadComboBoxItem(""));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CopyExemptions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
       
    }
#endregion

    #region Button Clicks
    /// <summary>
    /// this region will set the information when any button is clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_Copy_Click(object sender, EventArgs e)
    {
        try
        {
            if ((rcmb_Businessunit.SelectedIndex > 0) && (rcmb_Oldfinperiod.SelectedIndex > 0) && (rcmb_Newfinperiod.SelectedIndex > 0) && (rcmb_Exempteditem.SelectedIndex > 0))
            {
                _obj_smhr_tax_trans.Mode = 8;
                _obj_smhr_tax_trans.SMHR_EMPTAX_BU = Convert.ToInt32(rcmb_Businessunit.SelectedValue);
                _obj_smhr_tax_trans.SMHR_EMPTAX_PERIOD_ID = Convert.ToInt32(rcmb_Oldfinperiod.SelectedValue);
                _obj_smhr_tax_trans.SMHR_EMPTAX_NEWPERIODID = Convert.ToInt32(rcmb_Newfinperiod.SelectedValue);
                _obj_smhr_tax_trans.SMHR_EMPTAX_ID = Convert.ToInt32(rcmb_Exempteditem.SelectedValue);
                _obj_smhr_tax_trans.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                bool status = BLL.set_Tax_Trans(_obj_smhr_tax_trans);
                if (status)
                {
                    BLL.ShowMessage(this, "Information Saved Succesfully");
                    _obj_smhr_tax_trans.Mode = 10;
                    _obj_smhr_tax_trans.SMHR_EMPTAX_PERIOD_ID = Convert.ToInt32(rcmb_Oldfinperiod.SelectedValue);
                    _obj_smhr_tax_trans.SMHR_EMPTAX_NEWPERIODID = Convert.ToInt32(rcmb_Newfinperiod.SelectedValue);
                    _obj_smhr_tax_trans.SMHR_EMPTAX_TAXID = Convert.ToInt32(rcmb_Exempteditem.SelectedValue);
                    dt_Details = BLL.get_Tax_trans(_obj_smhr_tax_trans);
                    if (dt_Details.Rows.Count > 0)
                    {
                        BLL.ShowMessage(this, "Number Records Inserted are :" + dt_Details.Rows[0][0].ToString());
                    }
                }
                else
                    BLL.ShowMessage(this, "Already Exemption Information is Saved for the New Financial Period:" + rcmb_Newfinperiod.SelectedItem.Text);

            }
            else
            {
                BLL.ShowMessage(this, "Select Proper Inforamtion");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CopyExemptions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            Clearcontrols();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CopyExemptions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion
}
