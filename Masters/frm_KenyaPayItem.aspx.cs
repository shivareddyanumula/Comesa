using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Data;
using Telerik.Web.UI;

public partial class Masters_frm_KenyaPayItem : System.Web.UI.Page
{
    SMHR_ORGANISATION _obj_smhr_Organisation;
    SMHR_BUSINESSUNIT _obj_smhr_BusinessUnit;
    SMHR_PAYITEMS _obj_smhr_PayItems;
    SMHR_KENYA_PAYITEM _obj_smhr_KenyaPayItem;
    SMHR_PERIOD _obj_smhr_period;
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Setup for Tax Deductions");//KENYAPAYITEM");
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
                    rg_Main.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
                loadDropDown();
                loadGrid();
            }
            loadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_KenyaPayItem", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void loadDropDown()
    {
        try
        {
            // load Business Unit

            _obj_smhr_KenyaPayItem = new SMHR_KENYA_PAYITEM();
            _obj_smhr_KenyaPayItem.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_KenyaPayItem.OPERATION = operation.Check;
            DataTable dt_BusinessUnit = BLL.get_Kenya_PayItem(_obj_smhr_KenyaPayItem);
            rcmb_BusinessUnit.DataSource = dt_BusinessUnit;
            rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BusinessUnit.DataBind();
            rcmb_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
            //_obj_smhr_Organisation = new SMHR_ORGANISATION();
            //_obj_smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
            //_obj_smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //_obj_smhr_BusinessUnit.OPERATION = operation.Select;
            //DataTable dt_BusinessUnit = BLL.get_BusinessUnit(_obj_smhr_BusinessUnit);
            //rcmb_BusinessUnit.DataSource = dt_BusinessUnit;
            //rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            //rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            //rcmb_BusinessUnit.DataBind();
            //rcmb_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

            // load Pay Items
            _obj_smhr_KenyaPayItem.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_KenyaPayItem.OPERATION = operation.Check1;
            DataTable dt_PayItems = BLL.get_Kenya_PayItem(_obj_smhr_KenyaPayItem);
            rcmb_PayItem.DataSource = dt_PayItems;
            rcmb_PayItem.DataTextField = "PAYITEM_PAYITEMNAME";
            rcmb_PayItem.DataValueField = "PAYITEM_ID";
            rcmb_PayItem.DataBind();
            rcmb_PayItem.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
            //rcmb_PayItem.Items.Clear();
            //_obj_smhr_PayItems = new SMHR_PAYITEMS();
            //_obj_smhr_PayItems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //_obj_smhr_PayItems.OPERATION = operation.Select;
            //DataTable dt_PayItems = BLL.get_PayItems(_obj_smhr_PayItems);
            //rcmb_PayItem.DataSource = dt_PayItems;
            //rcmb_PayItem.DataTextField = "PAYITEM_PAYITEMNAME";
            //rcmb_PayItem.DataValueField = "PAYITEM_ID";
            //rcmb_PayItem.DataBind();
            //rcmb_PayItem.Items.Insert(0,new Telerik.Web.UI.RadComboBoxItem("Select","-1"));

            //To load Financial Periods
            _obj_smhr_period = new SMHR_PERIOD();
            _obj_smhr_period.OPERATION = operation.Select;
            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Details = BLL.get_PeriodHeaderDetails(_obj_smhr_period);
            rcmb_period.DataSource = dt_Details;
            rcmb_period.DataValueField = "PERIOD_ID";
            rcmb_period.DataTextField = "PERIOD_NAME";
            rcmb_period.DataBind();
            rcmb_period.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_KenyaPayItem", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_smhr_KenyaPayItem = new SMHR_KENYA_PAYITEM();
            int Status = Convert.ToInt32(rcmb_Status.SelectedItem.Value);
            _obj_smhr_KenyaPayItem.KENYA_PAYITEM_STATUS = Convert.ToBoolean(Status);
            _obj_smhr_KenyaPayItem.KENYA_PAYITEM_ID = Convert.ToInt32(Session["KENYA_PAYITEM_ID"]);

            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_SAVE":
                    _obj_smhr_KenyaPayItem.KENYA_PAYITEM_PAYITEM_ID = Convert.ToInt32(rcmb_PayItem.SelectedValue);
                    _obj_smhr_KenyaPayItem.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_KenyaPayItem.KENYA_PAYITEM_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
                    _obj_smhr_KenyaPayItem.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_KenyaPayItem.CREATEDDATE = Convert.ToDateTime(DateTime.Now);
                    _obj_smhr_KenyaPayItem.KENYA_PAYITEM_PERIOD_ID = Convert.ToInt32(rcmb_period.SelectedItem.Value);
                    _obj_smhr_KenyaPayItem.OPERATION = operation.Validate1;
                    if (Convert.ToString(BLL.get_Kenya_PayItem(_obj_smhr_KenyaPayItem).Rows[0]["Count"]) != "0")
                    {
                        BLL.ShowMessage(this, "Business unit with this Combination Already Exists!");
                        return;
                    }
                    _obj_smhr_KenyaPayItem.OPERATION = operation.Insert;

                    if (BLL.set_Kenya_PayItem(_obj_smhr_KenyaPayItem))
                    {
                        BLL.ShowMessage(this, "Record Inserted Successfully");
                    }
                    break;
                case "BTN_UPDATE":
                    _obj_smhr_KenyaPayItem.OPERATION = operation.Update;
                    _obj_smhr_KenyaPayItem.KENYA_PAYITEM_PAYITEM_ID = Convert.ToInt32(rcmb_PayItem.SelectedValue);
                    _obj_smhr_KenyaPayItem.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_KenyaPayItem.KENYA_PAYITEM_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
                    _obj_smhr_KenyaPayItem.KENYA_PAYITEM_PERIOD_ID = Convert.ToInt32(rcmb_period.SelectedItem.Value);
                    _obj_smhr_KenyaPayItem.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_KenyaPayItem.LASTMDFDATE = Convert.ToDateTime(DateTime.Now);
                    if (BLL.set_Kenya_PayItem(_obj_smhr_KenyaPayItem))
                    {
                        BLL.ShowMessage(this, "Record Updated Successfully");
                    }
                    break;
                default:
                    break;
            }
            rmp_Main.SelectedIndex = 0;
            loadGrid();
            rg_Main.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_KenyaPayItem", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearFields();
            rmp_Main.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_KenyaPayItem", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void loadGrid()
    {
        try
        {
            _obj_smhr_KenyaPayItem = new SMHR_KENYA_PAYITEM();
            _obj_smhr_KenyaPayItem.OPERATION = operation.Select;
            _obj_smhr_KenyaPayItem.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_loadGrid = BLL.get_Kenya_PayItem(_obj_smhr_KenyaPayItem);
            rg_Main.DataSource = dt_loadGrid;

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_KenyaPayItem", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rg_Main_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            loadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_KenyaPayItem", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void clearFields()
    {
        try
        {
            rcmb_BusinessUnit.Items.Clear();
            rcmb_PayItem.Items.Clear();
            rcmb_period.Items.Clear();
            // chk_Status.Checked = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_KenyaPayItem", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            rmp_Main.SelectedIndex = 1;
            btn_Save.Visible = true;
            btn_Update.Visible = false;
            loadDropDown();
            rcmb_PayItem.Enabled = true;
            rcmb_period.Enabled = true;
            rcmb_BusinessUnit.Enabled = true;
            //chk_Status.Checked = false;
            rcmb_Status.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_KenyaPayItem", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Update.Visible = false;

            }

            else
            {
                btn_Update.Visible = true;
            }

            rmp_Main.SelectedIndex = 1;
            btn_Save.Visible = false;
            btn_Update.Visible = true;
            rcmb_BusinessUnit.Enabled = false;
            rcmb_period.Enabled = false;
            rcmb_PayItem.Enabled = false;
            loadDropDown();
            _obj_smhr_KenyaPayItem = new SMHR_KENYA_PAYITEM();
            _obj_smhr_KenyaPayItem.KENYA_PAYITEM_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            Session["KENYA_PAYITEM_ID"] = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            _obj_smhr_KenyaPayItem.OPERATION = operation.Validate;
            DataTable dt_EditGrid = BLL.get_Kenya_PayItem(_obj_smhr_KenyaPayItem);
            rcmb_BusinessUnit.SelectedIndex = rcmb_BusinessUnit.FindItemIndexByValue(Convert.ToString(dt_EditGrid.Rows[0]["KENYA_PAYITEM_BUSINESSUNIT_ID"]));
            rcmb_PayItem.SelectedIndex = rcmb_PayItem.FindItemIndexByValue(Convert.ToString(dt_EditGrid.Rows[0]["KENYA_PAYITEM_PAYITEM_ID"]));
            rcmb_period.SelectedIndex = rcmb_period.FindItemIndexByValue(Convert.ToString(dt_EditGrid.Rows[0]["KENYA_PAYITEM_PERIOD_ID"]));
            if (Convert.ToString(dt_EditGrid.Rows[0]["KENYA_PAYITEM_STATUS"]) != null)
            {
                // int Status = Convert.ToInt32(dt_EditGrid.Rows[0]["KENYA_PAYITEM_STATUS"]);
                rcmb_Status.SelectedIndex = rcmb_Status.FindItemIndexByValue(Convert.ToString(dt_EditGrid.Rows[0]["KENYA_PAYITEM_STATUS"]));
            }
            else
            {
                //chk_Status.Checked = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_KenyaPayItem", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
