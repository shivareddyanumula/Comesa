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

public partial class Pension_frm_employeescheme_ : System.Web.UI.Page
{
    string strfilename2;
    DataSet ds = new DataSet();


    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    SMHR_EMPPENSIONSCHEME _obj_Smhr_EMPPENSIONSCHEME;

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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Employee Scheme Details");
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
                    return;
                }

                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    Rg_MedicalClaim.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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

                if (RWM_POSTREPLY1.Windows.Count > 0)
                {
                    RWM_POSTREPLY1.Windows.RemoveAt(0);
                }
                Page.Validate();
                BindDropDowns();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_employeescheme", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void BindDropDowns()
    {
        try
        {
            DataSet ds = BLL.GetPensionEmployeeFilterDtls(Convert.ToInt32(Session["ORG_ID"]), null, null, null, operation.Select);
            BindBusinessUnit(ds.Tables[0]);
            RadDepartment.Items.Insert(0, new RadComboBoxItem("ALL"));
            RadDirectorate.Items.Insert(0, new RadComboBoxItem("ALL"));
            //BindDirectorate(ds.Tables[1]);
            //BindDepartment(ds.Tables[2]);
            BindEmployee(ds.Tables[3]);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_employeescheme", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            clearControls();
            _obj_Smhr_EMPPENSIONSCHEME = new SMHR_EMPPENSIONSCHEME();
            _obj_Smhr_EMPPENSIONSCHEME.OPERATION = operation.Get;
            _obj_Smhr_EMPPENSIONSCHEME.EMPPENSIONSCHEME_EMPID = Convert.ToInt32(e.CommandArgument);
            //lblSchemeID.Text = _obj_Smhr_EMPPENSIONSCHEME.EMPPENSIONSCHEMEID.ToString();
            _obj_Smhr_EMPPENSIONSCHEME.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_PensionScheme(_obj_Smhr_EMPPENSIONSCHEME);
            AssignvaluesToUserControl(dt);
            ControlsEnableorDisable(false);
            
            if (Convert.ToBoolean(dt.Rows[0]["IsRelievedEmp"]))
            {
                ControlsonRelievedEmp(false);   //To enable/disable controls
            }
            else
            {
                ControlsonRelievedEmp(true);    //To enable/disable controls
            }
            radPensionIDNo.Text = dt.Rows[0]["EMP_MEMBERID"].ToString();
            rdpDateofJoiningScheme.MinDate = Convert.ToDateTime("01/01/1900");
            rdpDateofJoiningScheme.SelectedDate = Convert.ToDateTime(dt.Rows[0]["EMP_PENSION_DOJ"]);
            //rdpDateofJoiningScheme.Enabled = false;
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_employeescheme", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void ControlsonRelievedEmp(bool p)
    {
        try
        {
            radPensionIDNo.Enabled = p;
            rdpDateofJoiningScheme.Enabled = p;
            btn_Update.Enabled = p;
            btn_Save.Enabled = p;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_employeescheme", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void AssignvaluesToUserControl(DataTable dt)
    {
        try
        {
            //RadComboBox RadBusinessUnit = (RadComboBox)BU1.FindControl("RadBusinessUnit");
            RadBusinessUnit.DataSource = dt;
            RadBusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            RadBusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            RadBusinessUnit.DataBind();

            //RadComboBox RadDirectorate = (RadComboBox)BU1.FindControl("RadDirectorate");
            RadDirectorate.DataSource = dt;
            RadDirectorate.DataTextField = "DIRECTORATE_CODE";
            RadDirectorate.DataValueField = "DIRECTORATE_ID";
            RadDirectorate.DataBind();

            //RadComboBox RadDepartment = (RadComboBox)BU1.FindControl("RadDepartment");
            RadDepartment.DataSource = dt;
            RadDepartment.DataTextField = "DEPARTMENT_NAME";
            RadDepartment.DataValueField = "DEPARTMENT_ID";
            RadDepartment.DataBind();

            //RadComboBox RadEmployee = (RadComboBox)BU1.FindControl("RadEmployee");
            RadEmployee.DataSource = dt;
            RadEmployee.DataTextField = "EMP_NAME";
            RadEmployee.DataValueField = "EMP_ID";
            RadEmployee.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_employeescheme", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void ControlsEnableorDisable(bool result)
    {
        try
        {
            //RadComboBox RadBusinessUnit = (RadComboBox)BU1.FindControl("RadBusinessUnit");
            RadBusinessUnit.Enabled = result;

            //RadComboBox RadDirectorate = (RadComboBox)BU1.FindControl("RadDirectorate");
            RadDirectorate.Enabled = result;

            //RadComboBox RadDepartment = (RadComboBox)BU1.FindControl("RadDepartment");
            RadDepartment.Enabled = result;

            //RadComboBox RadEmployee = (RadComboBox)BU1.FindControl("RadEmployee");
            RadEmployee.Enabled = result;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_employeescheme", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            clearControls();
            ControlsEnableorDisable(true);
            ControlsonRelievedEmp(true);
            BindDropDowns();
            btn_Save.Visible = true;
            Rm_CY_page.SelectedIndex = 1;
            rdpDateofJoiningScheme.MinDate = DateTime.Today;
            rdpDateofJoiningScheme.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_employeescheme", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    public void LoadGrid()
    {
        try
        {
            _obj_Smhr_EMPPENSIONSCHEME = new SMHR_EMPPENSIONSCHEME();
            _obj_Smhr_EMPPENSIONSCHEME.OPERATION = operation.Select;
            _obj_Smhr_EMPPENSIONSCHEME.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT = BLL.get_PensionScheme(_obj_Smhr_EMPPENSIONSCHEME);
            Rg_MedicalClaim.DataSource = DT;
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_employeescheme", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            //RadComboBox RadBusinessUnit = (RadComboBox)BU1.FindControl("RadBusinessUnit");
            if (!string.IsNullOrEmpty(RadBusinessUnit.SelectedItem.Text) && string.Compare(RadBusinessUnit.SelectedItem.Text, "Select", true) != 0)
            {
                //RadComboBox RadEmployee = (RadComboBox)BU1.FindControl("RadEmployee");
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
            _obj_Smhr_EMPPENSIONSCHEME = new SMHR_EMPPENSIONSCHEME();
            //_obj_Smhr_EMPPENSIONSCHEME.EMPPENSIONSCHEME_EMPID = BU1.EmployeeID;
            _obj_Smhr_EMPPENSIONSCHEME.EMPPENSIONSCHEME_EMPID = Convert.ToInt32(RadEmployee.SelectedValue);

            _obj_Smhr_EMPPENSIONSCHEME.EMPPENSIONSCHEME_JOINDATE = (DateTime)rdpDateofJoiningScheme.SelectedDate;
            _obj_Smhr_EMPPENSIONSCHEME.EMPPENSIONSCHEME_PENSIONID = Convert.ToString(radPensionIDNo.Text);
            _obj_Smhr_EMPPENSIONSCHEME.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_EMPPENSIONSCHEME.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_Smhr_EMPPENSIONSCHEME.CREATEDDATE = DateTime.Now;
            _obj_Smhr_EMPPENSIONSCHEME.LASTMDFDATE = DateTime.Now;
            _obj_Smhr_EMPPENSIONSCHEME.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);

            //To check if Pension joining date is before Employee_DOJ
            _obj_Smhr_EMPPENSIONSCHEME.OPERATION = operation.Check;
            DateTime dtEmpDOJ = BLL.get_EmployeeDoj(_obj_Smhr_EMPPENSIONSCHEME);
            if (Convert.ToDateTime(rdpDateofJoiningScheme.SelectedDate) < dtEmpDOJ)
            {
                BLL.ShowMessage(this, "Provident Fund Scheme Joining Date Must Be Greater Than Employee DOJ");
                return;
            }

            //To check if pensionID already exists
            _obj_Smhr_EMPPENSIONSCHEME.OPERATION = operation.Check1;
            bool isPensionIDExists = BLL.get_PensionID(_obj_Smhr_EMPPENSIONSCHEME);
            if (isPensionIDExists)
            {
                BLL.ShowMessage(this, "Provident Fund ID already exists.");
                return;
            }


            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_UPDATE":
                    //_obj_Smhr_EMPPENSIONSCHEME.EMPPENSIONSCHEMEID = Convert.ToInt32(lblSchemeID.Text);
                    _obj_Smhr_EMPPENSIONSCHEME.OPERATION = operation.Update;
                    if (BLL.set_PensionScheme(_obj_Smhr_EMPPENSIONSCHEME))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Updated");

                    break;
                case "BTN_SAVE":

                    _obj_Smhr_EMPPENSIONSCHEME.OPERATION = operation.Insert;
                    if (BLL.set_PensionScheme(_obj_Smhr_EMPPENSIONSCHEME))
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_employeescheme", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }



    protected void clearControls()
    {
        try
        {
            //  lbl_MedicalClaimID.Text = string.Empty;

            radPensionIDNo.Text = string.Empty;

            RadBusinessUnit.Items.Clear();
            RadBusinessUnit.Text = string.Empty;
            RadDirectorate.Items.Clear();
            RadDirectorate.Text = string.Empty;
            RadDepartment.Items.Clear();
            RadDepartment.Text = string.Empty;
            RadEmployee.Items.Clear();
            RadEmployee.Text = string.Empty;
            //BU1.ClearControls();

            btn_Save.Visible = false;
            btn_Update.Visible = false;
            Rm_CY_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_employeescheme", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_employeescheme", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_employeescheme", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void RadBusinessUnit_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {

            if (RadBusinessUnit.SelectedIndex > 0)
            {
                DataSet ds = BLL.GetPensionEmployeeFilterDtls(Convert.ToInt32(Session["ORG_ID"]), Convert.ToInt32(RadBusinessUnit.SelectedValue), null, null, operation.Select);
                BindDirectorate(ds.Tables[1]);
                //BindDepartment(ds.Tables[2]);



                //To populate employee details
                BindEmployee(ds.Tables[3]);

                //To clear Departments
                RadDepartment.Items.Clear();
                RadDepartment.ClearSelection();
                RadDepartment.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
            else
            {
                RadDirectorate.Items.Clear();
                RadDirectorate.ClearSelection();
                RadDirectorate.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("ALL", "0"));
                RadDepartment.Items.Clear();
                RadDepartment.ClearSelection();
                RadDepartment.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("ALL", "0"));

                //RadEmployee.Items.Clear();
                //RadEmployee.ClearSelection();

                DataSet ds = BLL.GetPensionEmployeeFilterDtls(Convert.ToInt32(Session["ORG_ID"]), null, null, null, operation.Select);

                //To populate employee details
                BindEmployee(ds.Tables[3]);


                //RadComboBox rcbparent = (RadComboBox)Parent.FindControl("radGradeName");
                //if (rcbparent != null)
                //{
                //    rcbparent.Items.Clear();
                //    rcbparent.ClearSelection();
                //}
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_employeescheme", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void RadDirectorate_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (RadDirectorate.SelectedIndex > 0)
            {
                DataSet ds = BLL.GetPensionEmployeeFilterDtls(Convert.ToInt32(Session["ORG_ID"]), Convert.ToInt32(RadBusinessUnit.SelectedValue), Convert.ToInt32(RadDirectorate.SelectedValue), null, operation.Select);
                BindDepartment(ds.Tables[2]);

                //To populate employee details
                BindEmployee(ds.Tables[3]);
            }
            else
            {
                DataSet ds = BLL.GetPensionEmployeeFilterDtls(Convert.ToInt32(Session["ORG_ID"]), Convert.ToInt32(RadBusinessUnit.SelectedValue), null, null, operation.Select);
                BindEmployee(ds.Tables[3]);
                RadDepartment.Items.Clear();
                RadDepartment.ClearSelection();
                RadDepartment.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

                //RadComboBox rcbparent = (RadComboBox)Parent.FindControl("radGradeName");
                //if (rcbparent != null)
                //{
                //    rcbparent.Items.Clear();
                //    rcbparent.ClearSelection();
                //}
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_employeescheme", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void RadDepartment_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (RadDepartment.SelectedIndex > 0)
            {
                //if (!HideEmployee)
                //{
                //To populate employee details
                DataSet ds = BLL.GetPensionEmployeeFilterDtls(Convert.ToInt32(Session["ORG_ID"]), Convert.ToInt32(RadBusinessUnit.SelectedValue), Convert.ToInt32(RadDirectorate.SelectedValue), Convert.ToInt32(RadDepartment.SelectedValue), operation.Select);
                BindEmployee(ds.Tables[3]);
                //}
            }
            else
            {
                DataSet ds = BLL.GetPensionEmployeeFilterDtls(Convert.ToInt32(Session["ORG_ID"]), Convert.ToInt32(RadBusinessUnit.SelectedValue), Convert.ToInt32(RadDirectorate.SelectedValue), null, operation.Select);
                BindEmployee(ds.Tables[3]);
                //RadComboBox rcbparent = (RadComboBox)Parent.FindControl("radGradeName");
                //if (rcbparent != null)
                //{
                //    rcbparent.Items.Clear();
                //    rcbparent.ClearSelection();
                //}
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_employeescheme", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void RadEmployee_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rdpDateofJoiningScheme.SelectedDate = null;
            radPensionIDNo.Text = string.Empty;
            if (RadEmployee.SelectedIndex > 0)
            {
                _obj_Smhr_EMPPENSIONSCHEME = new SMHR_EMPPENSIONSCHEME();
                _obj_Smhr_EMPPENSIONSCHEME.OPERATION = operation.Get;
                _obj_Smhr_EMPPENSIONSCHEME.EMPPENSIONSCHEME_EMPID = Convert.ToInt32(RadEmployee.SelectedValue);
                _obj_Smhr_EMPPENSIONSCHEME.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt = BLL.get_PensionScheme(_obj_Smhr_EMPPENSIONSCHEME);
                radPensionIDNo.Text = dt.Rows[0]["EMP_MEMBERID"].ToString();
                //rdpDateofJoiningScheme.MinDate = Convert.ToDateTime("01/01/1900");
                rdpDateofJoiningScheme.MinDate = Convert.ToDateTime(dt.Rows[0]["EMP_DOJ"]);
                if (Convert.ToString(dt.Rows[0]["EMP_PENSION_DOJ"]) != "")
                {
                    rdpDateofJoiningScheme.SelectedDate = Convert.ToDateTime(dt.Rows[0]["EMP_PENSION_DOJ"]);
                    rdpDateofJoiningScheme.Enabled = true;
                }
                else
                {
                    rdpDateofJoiningScheme.Enabled = true;
                    rdpDateofJoiningScheme.SelectedDate = Convert.ToDateTime(dt.Rows[0]["EMP_DOJ"]);
                }

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_employeescheme", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void BindBusinessUnit(DataTable dt)
    {
        try
        {
            RadBusinessUnit.DataSource = dt;
            RadBusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            RadBusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            RadBusinessUnit.DataBind();
            //RadBusinessUnit.Items.Insert(0,new RadComboBoxItem("Select"));
            RadBusinessUnit.Items.Insert(0, new RadComboBoxItem(Convert.ToString(Session["ORG_NAME"]), Convert.ToString(Session["ORG_ID"])));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_employeescheme", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void BindDirectorate(DataTable dt)
    {
        try
        {
            RadDirectorate.DataSource = dt;
            RadDirectorate.DataTextField = "DIRECTORATE_CODE";
            RadDirectorate.DataValueField = "DIRECTORATE_ID";
            RadDirectorate.DataBind();
            RadDirectorate.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_employeescheme", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void BindDepartment(DataTable dt)
    {
        try
        {
            RadDepartment.DataSource = dt;
            RadDepartment.DataTextField = "DEPARTMENT_NAME";
            RadDepartment.DataValueField = "DEPARTMENT_ID";
            RadDepartment.DataBind();
            RadDepartment.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_employeescheme", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void BindEmployee(DataTable dt)
    {
        try
        {
            RadEmployee.DataSource = dt;
            RadEmployee.DataTextField = "EMPNAME";
            RadEmployee.DataValueField = "EMP_ID";
            RadEmployee.DataBind();
            RadEmployee.Items.Insert(0, new RadComboBoxItem("Select"));

            rdpDateofJoiningScheme.SelectedDate = null;
            radPensionIDNo.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_employeescheme", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
