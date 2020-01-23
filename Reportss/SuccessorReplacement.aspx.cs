﻿using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Reportss_SuccessorReplacement : System.Web.UI.Page
{
    SMHR_ORGANISATION obj_smhr_Organisation;
    SMHR_BUSINESSUNIT obj_smhr_Businessunit;
    SMHR_LOGININFO obj_smhr_Logininfo;
    SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems;
    string Control;
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (!Page.IsPostBack)
            {
                Control = Convert.ToString(Request.QueryString["Control"]);
                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //_obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString(lbl_header.Text);
                switch (Control)
                {
                    case "EmployeeLeaveData":
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Employee Leave Data");
                        break;
                    case "1":
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Successor Replacement Report");
                        break;
                }

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
                    //Rg_Countries.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Generate.Visible = false;
                    //  btn_Update.Visible = false;
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
                Page.Validate();
                Control = Convert.ToString(Request.QueryString["Control"]);

                //1=Successor Replacement
                if (Control != "1")
                {
                    lbl_header.Text = "Employee Leave Data";
                }
                else
                {
                    lbl_header.Text = "Successor Replacement";
                }
                LoadBusinessUnit();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "SuccessorReplacement", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    //private void LoadOrganisation()
    //{
    //    SMHR_LOGININFO _obj_LoginInfo = new SMHR_LOGININFO();
    //    _obj_LoginInfo.OPERATION = operation.Login1;
    //    _obj_LoginInfo.LOGIN_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //    DataTable dt_logindetails = BLL.get_Logindetails(_obj_LoginInfo);
    //    rcmb_Organisation.DataSource = dt_logindetails;
    //    rcmb_Organisation.DataTextField = "organisation_name";
    //    rcmb_Organisation.DataValueField = "organisation_id";
    //    rcmb_Organisation.DataBind();
    //}
    private void LoadBusinessUnit()
    {
        try
        {
            obj_smhr_Businessunit = new SMHR_BUSINESSUNIT();
            obj_smhr_Logininfo = new SMHR_LOGININFO();

            obj_smhr_Logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            obj_smhr_Logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(obj_smhr_Logininfo);
            rcmb_BusinessUnit.DataSource = dt_BUDetails;
            rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BusinessUnit.DataBind();
           // rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem(Convert.ToString(Session["ORG_NAME"])));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "SuccessorReplacement", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Generate_Click(object sender, EventArgs e)
    {
        try
        {
            Control = Convert.ToString(Request.QueryString["Control"]);
            String RPT_NAME = String.Empty;

            if (Control != "1")
            {
                if (Control == "EmployeeLeaveData")
                    RPT_NAME = "Employee Leave Data";
                else
                    RPT_NAME = "Successor Replacement Report";
            }
            else
            {
                RPT_NAME = "Successor Replacement Report";
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToString(rcmb_BusinessUnit.SelectedValue) + "','" + rdt_StartDate.SelectedDate + "','" + rdt_todate.SelectedDate + "','" + RPT_NAME + "');", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "SuccessorReplacement", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            rcmb_BusinessUnit.SelectedIndex = 0;
            rdt_todate.SelectedDate = null;
            rdt_StartDate.SelectedDate = null;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "SuccessorReplacement", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}