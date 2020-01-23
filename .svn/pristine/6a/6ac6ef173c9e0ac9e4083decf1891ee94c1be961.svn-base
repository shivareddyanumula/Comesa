using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Data;
using System.Collections;
using System.Text;
using Telerik.Web.UI;

public partial class frm_mapingrefpaytype : System.Web.UI.Page
{
    SMHR_PAYROLL_REFEREPAYTYPE _OBJ_PAYROLL_REFEREPAYTYPE = new SMHR_PAYROLL_REFEREPAYTYPE();
    SMHR_LOGININFO _obj_LoginInfo;

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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Mapping  Reference Pay Items");//MAPPING PAY ITEMS");
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
                    rg_payrollrefitm.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_save.Visible = false;
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
                loadPayitemrefid();
                loadDropdown();
                Load_GRID();


            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_mapingrefpaytype", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void loadDropdown()
    {
        //SMHR_ORGANISATION _obj_Organisation = new SMHR_ORGANISATION();
        //_obj_Organisation.MODE = 1;
        //DataTable dtorg = BLL.get_Organisation(_obj_Organisation);
        //rcmb_Organisation.DataSource = dtorg;
        //rcmb_Organisation.DataTextField = "ORGANISATION_NAME";
        //rcmb_Organisation.DataValueField = "ORGANISATION_ID";
        //rcmb_Organisation.DataBind();
        //rcmb_Organisation.Items.Insert(0, new RadComboBoxItem("Select"));
        try
        {
            _obj_LoginInfo = new SMHR_LOGININFO();
            _obj_LoginInfo.OPERATION = operation.Login1;
            _obj_LoginInfo.LOGIN_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_logindetails = BLL.get_Logindetails(_obj_LoginInfo);
            if (dt_logindetails.Rows.Count > 0)
            {
                rcmb_Organisation.DataSource = dt_logindetails;
                rcmb_Organisation.DataTextField = "organisation_name";
                rcmb_Organisation.DataValueField = "organisation_id";
                rcmb_Organisation.DataBind();
                //rcmb_Organisation.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                rcmb_Organisation.SelectedIndex = rcmb_Organisation.FindItemIndexByValue(dt_logindetails.Rows[0]["ORGANISATION_NAME"].ToString());
            }

            //to load pay items
            DataTable dt_payitems = new DataTable();
            _OBJ_PAYROLL_REFEREPAYTYPE.ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _OBJ_PAYROLL_REFEREPAYTYPE.OPERATION = operation.Select;
            dt_payitems = BLL.get_payitems(_OBJ_PAYROLL_REFEREPAYTYPE);
            if (dt_payitems.Rows.Count > 0)
            {
                rcmd_orgpayitem.DataSource = dt_payitems;
                rcmd_orgpayitem.DataTextField = "PAYITEM_PAYITEMNAME";
                rcmd_orgpayitem.DataValueField = "PAYITEM_ID";
                rcmd_orgpayitem.DataBind();
                rcmd_orgpayitem.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }

            //To load Business unit
            _obj_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_LoginInfo);
            if (dt_BUDetails.Rows.Count > 0)
            {
                rcmb_businessunit.DataSource = dt_BUDetails;

                rcmb_businessunit.DataValueField = "BUSINESSUNIT_ID";
                rcmb_businessunit.DataTextField = "BUSINESSUNIT_CODE";
                rcmb_businessunit.DataBind();
                rcmb_businessunit.Items.Insert(0, new RadComboBoxItem("Select"));
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_mapingrefpaytype", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void loadPayitemrefid()
    {
        try
        {
            DataTable dt_payroll_refid = new DataTable();
            _OBJ_PAYROLL_REFEREPAYTYPE.OPERATION = operation.EMPTY;
            dt_payroll_refid = BLL.Get_PayRefer(_OBJ_PAYROLL_REFEREPAYTYPE);
            rcmb_Payitemrefer.DataSource = dt_payroll_refid;
            rcmb_Payitemrefer.DataTextField = "TYPE";
            rcmb_Payitemrefer.DataValueField = "ID";
            rcmb_Payitemrefer.DataBind();
            rcmb_Payitemrefer.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_mapingrefpaytype", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //protected void rcmb_Organisation_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    //{
    //    //DataTable dt_payitems = new DataTable();
    //    //_OBJ_PAYROLL_REFEREPAYTYPE.ORG_ID = Convert.ToInt32(rcmb_Organisation.SelectedItem.Value);
    //    //_OBJ_PAYROLL_REFEREPAYTYPE.OPERATION = operation.Select;
    //    //dt_payitems = BLL.get_payitems(_OBJ_PAYROLL_REFEREPAYTYPE);
    //    //rcmd_orgpayitem.DataSource = dt_payitems;
    //    //rcmd_orgpayitem.DataTextField = "PAYITEM_PAYITEMNAME";
    //    //rcmd_orgpayitem.DataValueField = "PAYITEM_ID";
    //    //rcmd_orgpayitem.DataBind();

    //}

    protected void Load_GRID()
    {
        try
        {
            SMHR_MAPING_REFERPAYITEM _OBJ_SMHR_MAPING_REFERPAYITEM = new SMHR_MAPING_REFERPAYITEM();

            _OBJ_SMHR_MAPING_REFERPAYITEM.OPERATION = operation.Check1;
            _OBJ_SMHR_MAPING_REFERPAYITEM.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_grid = new DataTable();
            dt_grid = BLL.get_mappingrefpayitem(_OBJ_SMHR_MAPING_REFERPAYITEM);
            rg_payrollrefitm.DataSource = dt_grid;
            // rg_payrollrefitm.DataBind();
        }
        catch (Exception ex)
        {
            //throw ex;
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_mapingrefpaytype", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

        }

    }

    protected void rg_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            Load_GRID();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_mapingrefpaytype", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void link_Add_Command(object sender, EventArgs e)
    {
        try
        {
            loadPayitemrefid();
            loadDropdown();
            rcmb_Payitemrefer.SelectedIndex = 0;
            rcmd_orgpayitem.DataSource = "";
            rcmd_orgpayitem.DataBind();

            RadMultiPage1.SelectedIndex = 1;
            rcmb_Payitemrefer.Enabled = true;
            rcmb_status.SelectedIndex = 0;
            rcmd_orgpayitem.Enabled = true;
            rcmb_Organisation.Enabled = true;
            btn_save.Visible = true;
            btn_update.Visible = false;
            rcmb_businessunit.Enabled = true;

            loadDropdown();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_mapingrefpaytype", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void link_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            rcmb_Payitemrefer.Enabled = false;
            rcmd_orgpayitem.Enabled = false;
            rcmb_Organisation.Enabled = false;
            btn_save.Visible = false;
            rcmb_businessunit.Enabled = false;
            //btn_update.Visible = true;
            //code for security
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_update.Visible = false;
            }

            else
            {
                btn_update.Visible = true;
            }


            SMHR_MAPING_REFERPAYITEM _OBJ_SMHR_MAPING_REFERPAYITEM = new SMHR_MAPING_REFERPAYITEM();
            _OBJ_SMHR_MAPING_REFERPAYITEM.ID = Convert.ToInt32(e.CommandArgument);
            Label5.Text = Convert.ToString(e.CommandArgument);
            _OBJ_SMHR_MAPING_REFERPAYITEM.OPERATION = operation.Edit;
            DataTable dt_edit = new DataTable();
            dt_edit = BLL.get_mappingrefpayitem(_OBJ_SMHR_MAPING_REFERPAYITEM);

            rcmb_Payitemrefer.DataSource = dt_edit;
            rcmb_Payitemrefer.DataTextField = "TYPE";
            rcmb_Payitemrefer.DataValueField = "PAYITEMREFERID";
            rcmb_Payitemrefer.DataBind();

            rcmd_orgpayitem.DataSource = dt_edit;
            rcmd_orgpayitem.DataTextField = "PAYITEM_PAYITEMNAME";
            rcmd_orgpayitem.DataValueField = "ORGPAYITEM_ID";
            rcmd_orgpayitem.DataBind();

            rcmb_Organisation.DataSource = dt_edit;
            rcmb_Organisation.DataTextField = "ORGANISATION_NAME";
            rcmb_Organisation.DataValueField = "ORGANISATION_ID";
            rcmb_Organisation.DataBind();
            rcmb_businessunit.SelectedIndex = rcmb_businessunit.FindItemIndexByValue(dt_edit.Rows[0]["BUSINESSUNIT_ID"].ToString());

            //        rcmb_status.SelectedItem.Text = "ACTIVE";

            if (dt_edit.Rows[0]["STATUS"].ToString() == "0")
                rcmb_status.SelectedIndex = 0;//dt_edit.Rows[0]["STATUS"].ToString();
            else
                rcmb_status.SelectedIndex = 1;

            //rcmb_Payitemrefer.SelectedItem.Value = Convert.ToString(dt_edit.Rows[0]["PAYITEMREFERID"]);
            //rcmb_Organisation.SelectedItem.Value = Convert.ToString(dt_edit.Rows[0]["ORGANISATION_ID"]);
            //rcmd_orgpayitem.SelectedItem.Value = Convert.ToString(dt_edit.Rows[0]["ORGPAYITEM_ID"]);
            //rcmb_status.SelectedItem.Value = Convert.ToString(dt_edit.Rows[0]["STATUS"]);
            RadMultiPage1.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_mapingrefpaytype", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void btn_save_Click(object sender, EventArgs e)
    {
        try
        {

            SMHR_MAPING_REFERPAYITEM _OBJ_SMHR_MAPING_REFERPAYITEM = new SMHR_MAPING_REFERPAYITEM();


            _OBJ_SMHR_MAPING_REFERPAYITEM.PAYITEMREFERID = Convert.ToInt32(rcmb_Payitemrefer.SelectedItem.Value);
            _OBJ_SMHR_MAPING_REFERPAYITEM.ORGANISATION_ID = Convert.ToInt32(rcmb_Organisation.SelectedItem.Value);
            _OBJ_SMHR_MAPING_REFERPAYITEM.ORGPAYITEM_ID = Convert.ToInt32(rcmd_orgpayitem.SelectedItem.Value);
            _OBJ_SMHR_MAPING_REFERPAYITEM.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_businessunit.SelectedItem.Value);
            _OBJ_SMHR_MAPING_REFERPAYITEM.MP_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _OBJ_SMHR_MAPING_REFERPAYITEM.MP_CREATEDDATE=DateTime.Now;


            _OBJ_SMHR_MAPING_REFERPAYITEM.OPERATION = operation.Check;
            DataTable dt = new DataTable();

            dt = BLL.get_mappingrefpayitem(_OBJ_SMHR_MAPING_REFERPAYITEM);
            if (dt.Rows[0]["COUNT"].ToString() == "1")
            {
                BLL.ShowMessage(this, "Selected Payitem is Already Mapped");
            }
            else
            {
                _OBJ_SMHR_MAPING_REFERPAYITEM.STATUS = Convert.ToInt32(rcmb_status.SelectedItem.Value);
                _OBJ_SMHR_MAPING_REFERPAYITEM.OPERATION = operation.Insert;

                if (BLL.set_mappingrefpayitem(_OBJ_SMHR_MAPING_REFERPAYITEM))
                {
                    BLL.ShowMessage(this, "Information Saved Successfully");

                }
                else
                {
                    BLL.ShowMessage(this, "Not saved");
                }
                RadMultiPage1.SelectedIndex = 0;
                Load_GRID();
                rg_payrollrefitm.DataBind();
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_mapingrefpaytype", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_update_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_MAPING_REFERPAYITEM _OBJ_SMHR_MAPING_REFERPAYITEM = new SMHR_MAPING_REFERPAYITEM();
            _OBJ_SMHR_MAPING_REFERPAYITEM.ID = Convert.ToInt32(Label5.Text);
            _OBJ_SMHR_MAPING_REFERPAYITEM.STATUS = Convert.ToInt32(rcmb_status.SelectedItem.Value);
            _OBJ_SMHR_MAPING_REFERPAYITEM.PAYITEMREFERID = Convert.ToInt32(rcmb_Payitemrefer.SelectedItem.Value);
            _OBJ_SMHR_MAPING_REFERPAYITEM.ORGANISATION_ID = Convert.ToInt32(rcmb_Organisation.SelectedItem.Value);
            _OBJ_SMHR_MAPING_REFERPAYITEM.ORGPAYITEM_ID = Convert.ToInt32(rcmd_orgpayitem.SelectedItem.Value);
            _OBJ_SMHR_MAPING_REFERPAYITEM.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_businessunit.SelectedItem.Value);

            _OBJ_SMHR_MAPING_REFERPAYITEM.MP_LSTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            _OBJ_SMHR_MAPING_REFERPAYITEM.MP_LSTMDFDATE = DateTime.Now;

            //_OBJ_SMHR_MAPING_REFERPAYITEM.OPERATION = operation.Validate;
            //DataTable dt = BLL.get_mappingrefpayitem(_OBJ_SMHR_MAPING_REFERPAYITEM);
            if (Convert.ToInt32(rcmb_status.SelectedItem.Value) == 0)
            {
                _OBJ_SMHR_MAPING_REFERPAYITEM.OPERATION = operation.Check;
                DataTable dt1 = BLL.get_mappingrefpayitem(_OBJ_SMHR_MAPING_REFERPAYITEM);
                if (Convert.ToInt32(dt1.Rows[0]["COUNT"].ToString()) > 1)
                {
                    BLL.ShowMessage(this, "Selected Payitem is Already Mapped");
                    return;
                }
                else
                {
                    _OBJ_SMHR_MAPING_REFERPAYITEM.OPERATION = operation.Validate;
                    DataTable dt = BLL.get_mappingrefpayitem(_OBJ_SMHR_MAPING_REFERPAYITEM);
                    if (dt.Rows.Count > 0 && Convert.ToString(dt.Rows[0]["ID"]) != Convert.ToString(Label5.Text))
                    {
                        BLL.ShowMessage(this, "Selected Payitem is Already Mapped");
                        return;
                    }
                }
            }

            _OBJ_SMHR_MAPING_REFERPAYITEM.OPERATION = operation.Update;

            if (BLL.set_mappingrefpayitem(_OBJ_SMHR_MAPING_REFERPAYITEM))
            {
                BLL.ShowMessage(this, "Information Updated Successfully");
            }
            else
            {
                BLL.ShowMessage(this, "Information is not Saved");
            }
            RadMultiPage1.SelectedIndex = 0;

            Load_GRID();
            rg_payrollrefitm.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_mapingrefpaytype", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        try
        {
            RadMultiPage1.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_mapingrefpaytype", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_status_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            //if (Convert.ToInt32(rcmb_status.SelectedItem.Value) == 0)
            //{
            //    SMHR_MAPING_REFERPAYITEM _OBJ_SMHR_MAPING_REFERPAYITEM = new SMHR_MAPING_REFERPAYITEM();
            //    _OBJ_SMHR_MAPING_REFERPAYITEM.PAYITEMREFERID = Convert.ToInt32(rcmb_Payitemrefer.SelectedItem.Value);
            //    _OBJ_SMHR_MAPING_REFERPAYITEM.ORGANISATION_ID = Convert.ToInt32(rcmb_Organisation.SelectedItem.Value);
            //    _OBJ_SMHR_MAPING_REFERPAYITEM.ORGPAYITEM_ID = Convert.ToInt32(rcmd_orgpayitem.SelectedItem.Value);
            //    _OBJ_SMHR_MAPING_REFERPAYITEM.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_businessunit.SelectedItem.Value);
            //    _OBJ_SMHR_MAPING_REFERPAYITEM.OPERATION = operation.Check;
            //    DataTable dt = new DataTable();

            //    dt = BLL.get_mappingrefpayitem(_OBJ_SMHR_MAPING_REFERPAYITEM);
            //    if (dt.Rows[0]["COUNT"].ToString() == "1")
            //    {
            //        BLL.ShowMessage(this, "Selected Payitem is Already Mapped");
            //    }
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_mapingrefpaytype", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}