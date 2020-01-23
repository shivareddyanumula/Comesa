using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Pension_frm_PensionContribution : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();
                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Provident Fund ");
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
                    Rg_PensionContribution.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Save.Visible = false;
                    btn_Update.Visible = false;
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
                    return;
                }

                LoadEmployeeTypes();

                Page.Validate();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PensionContribution", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rg_PensionContribution_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PensionContribution", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadEmployeeTypes()
    {
        try
        {
            rcmb_EmployeeType.Items.Clear();

            SMHR_EMPLOYEETYPE _obj_smhr_Emp_type = new SMHR_EMPLOYEETYPE();

            _obj_smhr_Emp_type.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_Emp_type.OPERATION = operation.load;

            DataTable dtCategory = BLL.get_EmployeeType(_obj_smhr_Emp_type);

            if (dtCategory.Rows.Count > 0)
            {
                rcmb_EmployeeType.DataSource = dtCategory;
                rcmb_EmployeeType.DataTextField = "EMPLOYEETYPE_CODE";
                rcmb_EmployeeType.DataValueField = "EMPLOYEETYPE_ID";
                rcmb_EmployeeType.DataBind();
            }
            rcmb_EmployeeType.Items.Insert(0, new RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void LoadGrid()
    {
        try
        {
            SMHR_PENSION_CONTRIBUTION objPensionContribution = new SMHR_PENSION_CONTRIBUTION();
            objPensionContribution.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            objPensionContribution.OPERATION = operation.Get;
            DataTable dtPensionCont = new DataTable();
            dtPensionCont = BLL.get_PensionContribution(objPensionContribution);
            Rg_PensionContribution.DataSource = dtPensionCont;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PensionContribution", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            LoadEmployeeTypes();
            //clearControls();
            //ControlsEnableorDisable(true);
            btn_Save.Visible = true;
            Rm_CY_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PensionContribution", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            btn_Save.Visible = false;
            btn_Update.Visible = true;
            Rm_CY_page.SelectedIndex = 1;
            LoadEmployeeTypes();

            SMHR_PENSION_CONTRIBUTION objPensionContribution = new SMHR_PENSION_CONTRIBUTION();
            objPensionContribution.PENSION_CONTRIBUTION_ID = Convert.ToInt32(e.CommandArgument);
            hdnPensionCntID.Value = Convert.ToString(e.CommandArgument);
            objPensionContribution.OPERATION = operation.Edit;
            DataTable dtPensionContribution = BLL.get_PensionContribution(objPensionContribution);
            if (dtPensionContribution.Rows.Count > 0)
            {
                rcmb_EmployeeType.SelectedIndex = rcmb_EmployeeType.FindItemIndexByValue(Convert.ToString(dtPensionContribution.Rows[0]["PENSION_EMPTYPE"]));
                rcmb_EmployeeType.Enabled = false;
                rtxt_EmployeeValue.Value = Convert.ToDouble(dtPensionContribution.Rows[0]["PENSION_EMPLOYEE_VALUE"]);
                rtxt_EmployerValue.Value = Convert.ToDouble(dtPensionContribution.Rows[0]["PENSION_EMPLOYER_VALUE"]);
            }
            else
            {
                rcmb_EmployeeType.ClearSelection();
                rcmb_EmployeeType.Enabled = false;
                rtxt_EmployeeValue.Value = null;
                rtxt_EmployerValue.Value = null;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PensionContribution", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_PENSION_CONTRIBUTION objPensionContribution = new SMHR_PENSION_CONTRIBUTION();

            objPensionContribution.PENSION_EMPTYPE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedValue);
            objPensionContribution.PENSION_EMPTYPE = rcmb_EmployeeType.SelectedItem.Text;
            objPensionContribution.PENSION_EMPLOYEE_VALUE = Convert.ToDouble(rtxt_EmployeeValue.Value);
            objPensionContribution.PENSION_EMPLOYER_VALUE = Convert.ToDouble(rtxt_EmployerValue.Value);
            objPensionContribution.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_UPDATE":
                    objPensionContribution.PENSION_CONTRIBUTION_ID = Convert.ToInt32(hdnPensionCntID.Value);
                    objPensionContribution.LASTMDFDATE = DateTime.Now;
                    objPensionContribution.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    objPensionContribution.OPERATION = operation.Update;
                    //if (BLL.set_PensionScheme(objPensionContribution))
                    if (BLL.set_PensionContribution(objPensionContribution))

                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Updated");
                    break;

                case "BTN_SAVE":
                    objPensionContribution.OPERATION = operation.Check;

                    DataTable dt = BLL.get_PensionContribution(objPensionContribution);
                    if (dt.Rows.Count > 0)
                    {
                        BLL.ShowMessage(this, "A Record For Selected Employee Type Already Exists.");
                        return;
                    }

                    objPensionContribution.CREATEDDATE = DateTime.Now;
                    objPensionContribution.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    objPensionContribution.OPERATION = operation.Insert;

                    if (BLL.set_PensionContribution(objPensionContribution))

                        BLL.ShowMessage(this, "Information Saved Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                default:
                    break;
            }
            Rm_CY_page.SelectedIndex = 0;
            LoadGrid();
            Rg_PensionContribution.DataBind();

            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PensionContribution", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PensionContribution", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void clearControls()
    {
        try
        {
            btn_Save.Visible = false;
            btn_Update.Visible = false;
            Rm_CY_page.SelectedIndex = 0;
            rcmb_EmployeeType.ClearSelection();
            rcmb_EmployeeType.Enabled = true;
            rtxt_EmployeeValue.Value = null;
            rtxt_EmployerValue.Value = null;
            hdnPensionCntID.Value = null;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PensionContribution", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}