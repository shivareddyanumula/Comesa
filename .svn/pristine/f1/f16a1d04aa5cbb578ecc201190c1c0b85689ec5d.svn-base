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

public partial class Pension_frm_AVC : System.Web.UI.Page
{
    string strfilename2;
    DataSet ds = new DataSet();


    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    SMHR_EMPAVC _obj_Smhr_EMPAVC;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (RWM_POSTREPLY1.Windows.Count > 0)
        {
            RWM_POSTREPLY1.Windows.RemoveAt(0);
        }
        if (!IsPostBack)
        {

            Page.Validate();
            // BindExpen
        }
        try
        {

            //code for security privilage
            Session.Remove("WRITEFACILITY");

            SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

            _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
            _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
            _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("COUNTRY");
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



            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                Rg_MedicalClaim.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                btn_Save.Visible = false;
                btn_Update.Visible = false;
            }


        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AVC", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            clearControls();

            _obj_Smhr_EMPAVC = new SMHR_EMPAVC();
            _obj_Smhr_EMPAVC.OPERATION = operation.Get;
            _obj_Smhr_EMPAVC.EMPAVCID = Convert.ToInt32(e.CommandArgument);
            lblAVCID.Text = _obj_Smhr_EMPAVC.EMPAVCID.ToString();
            _obj_Smhr_EMPAVC.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_AVC(_obj_Smhr_EMPAVC);
            AssignvaluesToUserControl(dt);
            ControlsEnableorDisable(false);
            radPensionIDNo.Text = dt.Rows[0]["AVC_PENSION_AMOUNT"].ToString();
            //rdpDateofJoiningScheme.SelectedDate = Convert.ToDateTime(dt.Rows[0]["PENSIONSCHEME_JOINDATE"]);
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Update.Visible = false;

            }

            else
            {
                btn_Update.Visible = true;
            }
            Rm_CY_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AVC", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void AssignvaluesToUserControl(DataTable dt)
    {
        try
        {
            RadComboBox RadBusinessUnit = (RadComboBox)BU1.FindControl("RadBusinessUnit");
            RadBusinessUnit.DataSource = dt;
            RadBusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            RadBusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            RadBusinessUnit.DataBind();

            RadComboBox RadDirectorate = (RadComboBox)BU1.FindControl("RadDirectorate");
            RadDirectorate.DataSource = dt;
            RadDirectorate.DataTextField = "DIRECTORATE_CODE";
            RadDirectorate.DataValueField = "DIRECTORATE_ID";
            RadDirectorate.DataBind();

            RadComboBox RadDepartment = (RadComboBox)BU1.FindControl("RadDepartment");
            RadDepartment.DataSource = dt;
            RadDepartment.DataTextField = "DEPARTMENT_NAME";
            RadDepartment.DataValueField = "DEPARTMENT_ID";
            RadDepartment.DataBind();

            RadComboBox RadEmployee = (RadComboBox)BU1.FindControl("RadEmployee");
            RadEmployee.DataSource = dt;
            RadEmployee.DataTextField = "EMPLOYEENAME";
            RadEmployee.DataValueField = "AVC_EMPID";
            RadEmployee.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AVC", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void ControlsEnableorDisable(bool result)
    {
        try
        {
            RadComboBox RadBusinessUnit = (RadComboBox)BU1.FindControl("RadBusinessUnit");
            RadBusinessUnit.Enabled = result;

            RadComboBox RadDirectorate = (RadComboBox)BU1.FindControl("RadDirectorate");
            RadDirectorate.Enabled = result;

            RadComboBox RadDepartment = (RadComboBox)BU1.FindControl("RadDepartment");
            RadDepartment.Enabled = result;

            RadComboBox RadEmployee = (RadComboBox)BU1.FindControl("RadEmployee");
            RadEmployee.Enabled = result;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AVC", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            clearControls();
            ControlsEnableorDisable(true);
            btn_Save.Visible = true;
            Rm_CY_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AVC", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    public void LoadGrid()
    {
        try
        {
            _obj_Smhr_EMPAVC = new SMHR_EMPAVC();
            _obj_Smhr_EMPAVC.OPERATION = operation.Select;
            _obj_Smhr_EMPAVC.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT = BLL.get_AVC(_obj_Smhr_EMPAVC);
            Rg_MedicalClaim.DataSource = DT;

            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AVC", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            RadComboBox RadBusinessUnit = (RadComboBox)BU1.FindControl("RadBusinessUnit");
            if (!string.IsNullOrEmpty(RadBusinessUnit.SelectedItem.Text) && string.Compare(RadBusinessUnit.SelectedItem.Text, "Select", true) != 0)
            {
                RadComboBox RadEmployee = (RadComboBox)BU1.FindControl("RadEmployee");
                if (string.IsNullOrEmpty(RadEmployee.SelectedItem.Text) || string.Compare(RadEmployee.SelectedItem.Text, "Select", true) == 0)
                {
                    BLL.ShowMessage(this, "Please select Employee");
                    return;
                }
            }
            else
            {
                BLL.ShowMessage(this, "Please select Business Unit");
                return;
            }
            _obj_Smhr_EMPAVC = new SMHR_EMPAVC();
            _obj_Smhr_EMPAVC.EMPAVC_EMPID = BU1.EmployeeID;
            //_obj_Smhr_EMPPENSIONSCHEME.EMPPENSIONSCHEME_JOINDATE = (DateTime)rdpDateofJoiningScheme.SelectedDate;
            _obj_Smhr_EMPAVC.EMPAVC_PENSION_AMOUNT = Convert.ToInt32(radPensionIDNo.Text);
            _obj_Smhr_EMPAVC.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_EMPAVC.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_Smhr_EMPAVC.CREATEDDATE = DateTime.Now;
            _obj_Smhr_EMPAVC.LASTMDFDATE = DateTime.Now;
            _obj_Smhr_EMPAVC.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);


            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_UPDATE":
                    _obj_Smhr_EMPAVC.EMPAVCID = Convert.ToInt32(lblAVCID.Text);
                    _obj_Smhr_EMPAVC.OPERATION = operation.Update;
                    if (BLL.set_AVC(_obj_Smhr_EMPAVC))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Updated");

                    break;
                case "BTN_SAVE":

                    _obj_Smhr_EMPAVC.OPERATION = operation.Insert;
                    if (BLL.set_AVC(_obj_Smhr_EMPAVC))
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                default:
                    break;
            }
            Rm_CY_page.SelectedIndex = 0;
            LoadGrid();
            Rg_MedicalClaim.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AVC", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }



    protected void clearControls()
    {
        try
        {
            //  lbl_MedicalClaimID.Text = string.Empty;

            radPensionIDNo.Text = string.Empty;

            BU1.ClearControls();

            btn_Save.Visible = false;
            btn_Update.Visible = false;
            Rm_CY_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AVC", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AVC", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rg_MedicalClaim_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AVC", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}