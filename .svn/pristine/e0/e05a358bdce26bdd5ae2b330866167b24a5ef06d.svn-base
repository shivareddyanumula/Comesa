using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using Telerik.Web.UI;


public partial class Reportss_MembersofParliament_ : System.Web.UI.Page
{
    SMHR_BUSINESSUNIT obj_smhr_Businessunit;
    SMHR_LOGININFO obj_smhr_Logininfo;
    SMHR_PERIOD obj_smhr_Period;
    SMHR_PERIODDTL _obj_Smhr_Prddtl;
    SMHR_SALARYSTRUCT _obj_smhr_salaryStruct;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                string control = string.Empty;
                //code for security privilage
                Session.Remove("WRITEFACILITY");
                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();
                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                if (Request.QueryString.HasKeys())
                {
                    control = Convert.ToString(Request.QueryString["Control"]);
                    if (control == "StaffContribution") // for Staff Contribution  Report
                    {
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Staff Contribution");
                        
                        lbl_header.Text = "Staff Contribution";
                    }
                    else if (control == "MembersofParliamentContribution") //for Members of Parliament Contribution Report
                    {
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Members of Parliament Contribution");
                       
                        lbl_header.Text = "Members of Parliament Contribution";

                    }
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
                    btn_Generate.Visible = false;
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
                LoadBusinessUnit();
                LoadPeriod();
                LoadSalaryStructure();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MembersofParliament", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


    }
    protected void LoadBusinessUnit()
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
        //rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));
        rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem(Convert.ToString(Session["ORG_NAME"]), "-1"));
    }
    private void LoadSalaryStructure()
    {
        rcmb_SalStruct.Items.Clear();
        _obj_smhr_salaryStruct = new SMHR_SALARYSTRUCT();
        _obj_smhr_salaryStruct.ISDELETED = false;
        _obj_smhr_salaryStruct.OPERATION = operation.Select;
        _obj_smhr_salaryStruct.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
        DataTable dt_Details = BLL.get_SalaryHeaderDetails(_obj_smhr_salaryStruct);
        if (dt_Details.Rows.Count > 0)
        {
            rcmb_SalStruct.DataSource = dt_Details;
            rcmb_SalStruct.DataTextField = "SALARYSTRUCT_CODE";
            rcmb_SalStruct.DataValueField = "SALARYSTRUCT_ID";
            rcmb_SalStruct.DataBind();
        }
        rcmb_SalStruct.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("ALL", "-1"));
        //rcmb_SalStruct.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

        if (rcmb_SalStruct.Items.Count > 0)
        {
            string control = Convert.ToString(Request.QueryString["Control"]);
            if (control == "StaffContribution") // for Staff Contribution  Report
            {
                rcmb_SalStruct.Items.Remove(1);
            }
            else
            {
                rcmb_SalStruct.Items.Remove(3);
                rcmb_SalStruct.Items.Remove(2);
            }
        }



    }
    private void LoadPeriod()
    {
        try
        {
            obj_smhr_Period = new SMHR_PERIOD();
            obj_smhr_Period.OPERATION = operation.Select;
            obj_smhr_Period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //DataTable dt_Details = BLL.get_PeriodHeaderDetails_Calendar(obj_smhr_Period);
            DataTable dt_Details = BLL.get_PeriodHeaderDetails(obj_smhr_Period);
            rcmb_Period.DataSource = dt_Details;
            rcmb_Period.DataValueField = "PERIOD_ID";
            rcmb_Period.DataTextField = "PERIOD_NAME";
            rcmb_Period.DataBind();
            rcmb_Period.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MembersofParliament", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_Period_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Period.SelectedIndex != 0)
            {
                _obj_Smhr_Prddtl = new SMHR_PERIODDTL();
                _obj_Smhr_Prddtl.OPERATION = operation.Select;
                _obj_Smhr_Prddtl.PRDDTL_PERIOD_ID = Convert.ToInt32(rcmb_Period.SelectedValue);
                DataTable dt_Details = BLL.get_PeriodDetails(_obj_Smhr_Prddtl);
                if (dt_Details.Rows.Count != 0)
                {
                    rcmb_Periodelement.DataSource = dt_Details;
                    rcmb_Periodelement.DataValueField = "PRDDTL_ID";
                    rcmb_Periodelement.DataTextField = "PRDDTL_NAME";
                    rcmb_Periodelement.DataBind();
                    rcmb_Periodelement.Items.Insert(0, new RadComboBoxItem("Select"));
                }
            }
            else
            {
                rcmb_Periodelement.Items.Clear();
                rcmb_Periodelement.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MembersofParliament", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void btn_Generate_Click(object sender, EventArgs e)
    {
        try
        {
          ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToInt32(Session["ORG_ID"]) + "','" + Convert.ToString(rcmb_BusinessUnit.SelectedValue) + "','" + Convert.ToString(rcmb_SalStruct.SelectedValue) + "','" + Convert.ToString(rcmb_Period.SelectedValue) + "','" + Convert.ToString(rcmb_Periodelement.SelectedValue) + "','" + Convert.ToString(Request.QueryString["Control"]) + "');", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MembersofParliament", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            rcmb_Period.SelectedIndex = 0;
            rcmb_Periodelement.SelectedIndex = 0;
            rcmb_SalStruct.SelectedIndex = 0;
            rcmb_SalStruct.Text = string.Empty;
            rcmb_BusinessUnit.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MembersofParliament", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}