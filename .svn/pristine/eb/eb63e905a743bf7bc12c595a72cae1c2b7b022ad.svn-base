using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using System.Text;
using Telerik.Web.UI;

public partial class Masters_DepartmentDivisionMapping : System.Web.UI.Page
{
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_DEPARTMENT_DIVISION_MAPPING _obj_Smhr_DDM;
    SMHR_DEPARTMENT _obj_Department;
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                LoadBusinessUnit();
                //LoadCombos();
            }
            Page.Validate();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DepartmentDivisionMapping", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadBusinessUnit()
    {
        try
        { 
        _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
        _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
        _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
        rcmb_BU.Items.Clear();
        rcmb_BU.DataSource = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
        rcmb_BU.DataTextField = "BUSINESSUNIT_CODE";
        rcmb_BU.DataValueField = "BUSINESSUNIT_ID";
        rcmb_BU.DataBind();
        rcmb_BU.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DepartmentDivisionMapping", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadCombos()
    {
        try
        {
        _obj_Department = new SMHR_DEPARTMENT();
        _obj_Department.MODE = 7;
        _obj_Department.BUID = Convert.ToInt32(rcmb_BU.SelectedValue);
        DataTable dt = BLL.get_Department(_obj_Department);
        ddl_Department.DataSource = dt;
        ddl_Department.DataTextField = "DEPARTMENT_NAME";
        ddl_Department.DataValueField = "DEPARTMENT_ID";
        ddl_Department.DataBind();
        ddl_Department.Items.Insert(0, new RadComboBoxItem("Select"));

        SMHR_DIVISION _obj_Smhr_Division=new SMHR_DIVISION();
        _obj_Smhr_Division.OPERATION = operation.Approve;
        _obj_Smhr_Division.BUID = Convert.ToInt32(rcmb_BU.SelectedValue);
        _obj_Smhr_Division.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
        DataTable dt1 = BLL.get_DivisionMapping(_obj_Smhr_Division);
        ddl_Diviison.DataSource = dt1;
        ddl_Diviison.DataValueField = "SMHR_DIV_ID";
        ddl_Diviison.DataTextField = "SMHR_DIV_CODE";
        ddl_Diviison.DataBind();
        ddl_Diviison.Items.Insert(0, new RadComboBoxItem("Select"));
    }
    catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DepartmentDivisionMapping", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {

            clearControls();
            // rtxt_CountryCode.Enabled = false;
            LoadBusinessUnit();

            DataTable dt = BLL.get_DeptMapping(new SMHR_DEPARTMENT_DIVISION_MAPPING(Convert.ToInt32(Convert.ToString(e.CommandArgument))));
            rcmb_BU.SelectedIndex = rcmb_BU.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["BUSINESSUNIT_ID"]));
            rcmb_BU_SelectedIndexChanged(null, null);
            lbl_DivisionID.Text = Convert.ToString(dt.Rows[0]["SMHR_ERPDIV_DEPMAPPING_ID"]);
            //rtxt_CountryCode.Text = Convert.ToString(dt.Rows[0]["SMHR_ERPDIV_DEPMAPPING_ERPCODE"]);
            ddl_Department.SelectedIndex = ddl_Department.Items.FindItemIndexByText(Convert.ToString(dt.Rows[0]["DEPARTMENT_NAME"]));
            ddl_Diviison.SelectedIndex = ddl_Diviison.Items.FindItemIndexByText(Convert.ToString(dt.Rows[0]["SMHR_DIV_CODE"]));
            rcmb_Status.SelectedIndex = rcmb_Status.Items.FindItemIndexByText(Convert.ToString(dt.Rows[0]["SMHR_ERPDIV_DEPMAPPING_STATUS"]));
            ddl_Department.Enabled = false;
            ddl_Diviison.Enabled = false;
            rcmb_BU.Enabled = false;
            //code for security
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Update.Visible = false;

            }

            else
            {
                btn_Update.Visible = true;
            }
            Rm_DDM_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DepartmentDivisionMapping", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            clearControls();
            ddl_Department.Enabled = true;
            ddl_Diviison.Enabled = true;
            btn_Save.Visible = true;
            Rm_DDM_page.SelectedIndex = 1;
            rcmb_BU.Enabled = true;
            rcmb_Status.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DepartmentDivisionMapping", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    public void LoadGrid()
    {
        try
        {
            SMHR_DEPARTMENT_DIVISION_MAPPING _obj_Smhr_DDM = new SMHR_DEPARTMENT_DIVISION_MAPPING();
            _obj_Smhr_DDM.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT = BLL.get_DeptMapping(_obj_Smhr_DDM);
            Rg_DDM.DataSource = DT;
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DepartmentDivisionMapping", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_DEPARTMENT_DIVISION_MAPPING _obj_Smhr_DDM = new SMHR_DEPARTMENT_DIVISION_MAPPING();
            //_obj_Smhr_DDM.ERP_CODE = BLL.ReplaceQuote(rtxt_CountryCode.Text);
            _obj_Smhr_DDM.DEPARTMENT_ID = Convert.ToInt32(ddl_Department.SelectedItem.Value);
            _obj_Smhr_DDM.DIVISION_ID = Convert.ToInt32(ddl_Diviison.SelectedItem.Value);
            _obj_Smhr_DDM.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_DDM.CREATEDDATE = DateTime.Now;
            _obj_Smhr_DDM.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_DDM.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_DDM.LASTMDFDATE = DateTime.Now;
            _obj_Smhr_DDM.BUID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
            _obj_Smhr_DDM.STATUS = Convert.ToString(rcmb_Status.SelectedValue);
            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_UPDATE":
                    _obj_Smhr_DDM.SMHR_DEPARTMENT_DIVISION_MAPPING_ID = Convert.ToInt32(lbl_DivisionID.Text);
                    _obj_Smhr_DDM.OPERATION = operation.Update;
                    if (BLL.set_SMHR_DEPARTMENT_DIVISION_MAPPING(_obj_Smhr_DDM))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Updated");

                    break;
                case "BTN_SAVE":
                    _obj_Smhr_DDM.OPERATION = operation.Check;
                    if (Convert.ToString(BLL.get_DeptMapping(_obj_Smhr_DDM).Rows[0]["Count"]) != "0")
                    {
                        BLL.ShowMessage(this, "Mapping Already Exists for Selected Function.");
                        return;
                    }
                    _obj_Smhr_DDM.OPERATION = operation.Insert;
                    if (BLL.set_SMHR_DEPARTMENT_DIVISION_MAPPING(_obj_Smhr_DDM))
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                default:
                    break;
            }
            clearControls();
            Rm_DDM_page.SelectedIndex = 0;
            LoadGrid();
            Rg_DDM.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DepartmentDivisionMapping", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void clearControls()
    {
        lbl_DivisionID.Text = string.Empty;
        //rtxt_CountryCode.Text = string.Empty;
        //rtxt_CountryCode.Enabled = true;
        btn_Save.Visible = false;
        btn_Update.Visible = false;
        Rm_DDM_page.SelectedIndex = 0;
        rcmb_BU.SelectedIndex = 0;
        rcmb_Status.SelectedIndex = 0;
        ddl_Department.ClearSelection();
        ddl_Department.Items.Clear();
        ddl_Department.Items.Insert(0, new RadComboBoxItem("Select", "0"));
        ddl_Diviison.ClearSelection();
        ddl_Diviison.Items.Clear();
        ddl_Diviison.Items.Insert(0, new RadComboBoxItem("Select", "0"));    
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DepartmentDivisionMapping", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
   
     protected void Rg_DDM_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
     {
         try
         {
             LoadGrid();
         }
         catch (Exception ex)
         {
             SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DepartmentDivisionMapping", ex.StackTrace, DateTime.Now);
             Response.Redirect("~/Frm_ErrorPage.aspx");
         }
     }
     protected void rcmb_BU_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
     {
         try
         {
             if (rcmb_BU.SelectedIndex > 0)
             {
                 LoadCombos();
             }
             else
             {
                 ddl_Department.ClearSelection();
                 ddl_Department.Items.Clear();
                 ddl_Department.Items.Insert(0, new RadComboBoxItem("Select", "0"));
                 ddl_Diviison.ClearSelection();
                 ddl_Diviison.Items.Clear();
                 ddl_Diviison.Items.Insert(0, new RadComboBoxItem("Select", "0"));
             }
         }
         catch (Exception ex)
         {
             SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DepartmentDivisionMapping", ex.StackTrace, DateTime.Now);
             Response.Redirect("~/Frm_ErrorPage.aspx");
         }
     }
}
