using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class HR_DepartmentHeads : System.Web.UI.Page
{

    SMHR_DEPARTMENTHEADS _obj_SMHR_DepartmentHeads;
    SMHR_DEPARTMENT _obj_SMHR_Department;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    DataSet ds = new DataSet();
    DataTable dt_Details = new DataTable();
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
                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Department Head Mapping");//DIRECTORATE");
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
                //if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                //{
                //    Rg_DepartmentHeadsMapping.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                //    btn_submit.Visible = false;               
                //}
                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    Rg_DepartmentHeadsMapping.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_submit.Visible = false;
                    // btn_Update.Visible = false;
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
                LoadBusinessUnits();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DepartmentHeads", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void chk_selectall_checkedchanged(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < Rg_DepartmentHeadsMapping.Items.Count; i++)
            {
                CheckBox Chk_All = (CheckBox)sender;
                if (Chk_All.Checked)
                {
                    for (int index = 0; index < Rg_DepartmentHeadsMapping.Items.Count; index++)
                    {
                        CheckBox c = (CheckBox)Rg_DepartmentHeadsMapping.Items[index].FindControl("chk_Select");
                        c.Checked = true;
                    }
                }
                else
                {
                    for (int index = 0; index < Rg_DepartmentHeadsMapping.Items.Count; index++)
                    {
                        CheckBox c = (CheckBox)Rg_DepartmentHeadsMapping.Items[index].FindControl("chk_Select");
                        c.Checked = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DepartmentHeads", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #region MyRegion
    //private void LoadDepartment()
    //{
    //    try
    //    {
    //        _obj_SMHR_Department = new SMHR_DEPARTMENT();
    //        _obj_SMHR_Department.MODE = 9;
    //        _obj_SMHR_Department.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
    //        _obj_SMHR_Department.BUID = Convert.ToInt32(ddl_BusinessUnit.SelectedItem.Value);
    //        dt_Details = BLL.get_Department(_obj_SMHR_Department);
    //        if (dt_Details.Rows.Count > 0)
    //        {
    //            Rg_DepartmentHeadsMapping.Visible = true;
    //            Rg_DepartmentHeadsMapping.DataSource = dt_Details;
    //            Rg_DepartmentHeadsMapping.DataBind();
    //            btn_submit.Visible = true;
    //            btn_Cancel.Visible = true;
    //        }
    //        else
    //        {
    //            Rg_DepartmentHeadsMapping.Visible = false;
    //            btn_submit.Visible = false;
    //            btn_Cancel.Visible = false;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_DepartmentHeads", ex.StackTrace, DateTime.Now);
    //    }
    //} 
    #endregion
    private void Load_Department()
    {
        try
        {
            if (ddl_BusinessUnit.SelectedIndex != 0)
            {
                _obj_SMHR_Department = new SMHR_DEPARTMENT();
                _obj_SMHR_Department.MODE = 7;
                _obj_SMHR_Department.DIRECTORATE_ID = Convert.ToInt32(rad_Directorate.SelectedValue);
                _obj_SMHR_Department.BUID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
                DataTable dt = BLL.get_Department(_obj_SMHR_Department);
                Rg_DepartmentHeadsMapping.Visible = true;
                Rg_DepartmentHeadsMapping.DataSource = dt;
                Rg_DepartmentHeadsMapping.DataBind();
                btn_submit.Visible = true;
                btn_Cancel.Visible = true;
            }
            else
            {
                Rg_DepartmentHeadsMapping.Visible = false;
                //Rg_DepartmentHeadsMapping.sele
                btn_submit.Visible = false;
                btn_Cancel.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DepartmentHeads", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void ddl_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (ddl_BusinessUnit.SelectedItem.Value != string.Empty)
            {
                Load_Directorate();
            }
            else
            {
                rad_Directorate.Items.Clear();
                rad_Directorate.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                // rad_Directorate.SelectedIndex = 0;
            }
            Load_Department();


        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DepartmentHeads", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rad_Directorate_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rad_Directorate.SelectedItem.Value != string.Empty)
            {
                Load_Department();
                AssignDepartmentswithHeads();
            }
            else
            {
                Rg_DepartmentHeadsMapping.Visible = false;
                btn_submit.Visible = false;
                btn_Cancel.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DepartmentHeads", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Load_Directorate()
    {
        try
        {
            rad_Directorate.Items.Clear();
            if (Convert.ToString(Session["ORG_ID"]) != string.Empty)
            {
                if (ddl_BusinessUnit.SelectedIndex > 0)
                {
                    SMHR_DIRECTORATE _obj_Smhr_Directorate = new SMHR_DIRECTORATE();
                    _obj_Smhr_Directorate.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Smhr_Directorate.BUSINESSUNIT_ID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
                    DataTable DT = BLL.get_Directorate(_obj_Smhr_Directorate);
                    rad_Directorate.DataTextField = "DIRECTORATE_CODE";
                    rad_Directorate.DataValueField = "DIRECTORATE_ID";
                    rad_Directorate.DataSource = DT;
                    rad_Directorate.DataBind();
                    rad_Directorate.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                }
                else
                {
                    rad_Directorate.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                }
            }
            else
            {
                rad_Directorate.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DepartmentHeads", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    private void AssignDepartmentswithHeads()
    {
        try
        {
            _obj_SMHR_DepartmentHeads = new SMHR_DEPARTMENTHEADS();
            _obj_SMHR_DepartmentHeads.DEPTHEAD_BU_ID = Convert.ToInt32(ddl_BusinessUnit.SelectedItem.Value);
            DataTable dt_DeptEmpHeads = BLL.get_DepartmentHeads(_obj_SMHR_DepartmentHeads);
            Label lblDepartmentID = new Label();
            RadComboBox rcmbEmployee = new RadComboBox();
            RadComboBox rcmbSubHead = new RadComboBox();
            CheckBox chkBox = new CheckBox();
            for (int index = 0; index <= Rg_DepartmentHeadsMapping.Items.Count - 1; index++)
            {
                rcmbEmployee = Rg_DepartmentHeadsMapping.Items[index].FindControl("rcmbEmployee") as RadComboBox;
                rcmbSubHead = Rg_DepartmentHeadsMapping.Items[index].FindControl("rcmbSubHead") as RadComboBox;
                lblDepartmentID = Rg_DepartmentHeadsMapping.Items[index].FindControl("Department_ID") as Label;
                //  chkBox = Rg_DepartmentHeadsMapping.Items[index].FindControl("chk_Select") as CheckBox;
                DataRow[] dr = dt_DeptEmpHeads.Select("DEPTHEAD_DEPT_ID=" + lblDepartmentID.Text);
                if (dr.Length > 0)
                {
                    //       chkBox.Checked = true;
                    rcmbEmployee.SelectedValue = dr[0][1].ToString();
                    rcmbSubHead.SelectedValue = dr[0][2].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DepartmentHeads", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadBusinessUnits()
    {
        try
        {
            ddl_BusinessUnit.Items.Clear();
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            ddl_BusinessUnit.DataSource = dt_BUDetails;
            ddl_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            ddl_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            ddl_BusinessUnit.DataBind();
            ddl_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DepartmentHeads", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    public DataTable LoadGridEmployees()
    {

        if (ddl_BusinessUnit.SelectedItem.Value != string.Empty)
        {
            SMHR_EMPASSETTRANSFER obj_smhr_EmpAssetTransfer = new SMHR_EMPASSETTRANSFER();
            DataTable DT_Details = new DataTable();

            obj_smhr_EmpAssetTransfer = new SMHR_EMPASSETTRANSFER();
            obj_smhr_EmpAssetTransfer.OPERATION = operation.Empty;
            obj_smhr_EmpAssetTransfer.EMPASSETTRANSFER_BUSINESSUNIT_ID = Convert.ToInt32(ddl_BusinessUnit.SelectedItem.Value);
            obj_smhr_EmpAssetTransfer.EMPASSETTRANSFER_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            return BLL.get_AssetEmpDetails(obj_smhr_EmpAssetTransfer);
        }
        else
            return null;
    }
    protected void Rg_DepartmentHeadsMapping_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            Load_Department();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DepartmentHeads", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        try
        {
            CheckBox chkBox = new CheckBox();
            Label lblDepartmentID = new Label();
            RadComboBox rcmbEmployee = new RadComboBox();
            RadComboBox rcmbSubHead = new RadComboBox();
            int count = 0;
            bool status = false;
            for (int index = 0; index <= Rg_DepartmentHeadsMapping.Items.Count - 1; index++)
            {
                chkBox = Rg_DepartmentHeadsMapping.Items[index].FindControl("chk_Select") as CheckBox;
                rcmbEmployee = Rg_DepartmentHeadsMapping.Items[index].FindControl("rcmbEmployee") as RadComboBox;
                lblDepartmentID = Rg_DepartmentHeadsMapping.Items[index].FindControl("Department_ID") as Label;
                rcmbSubHead = Rg_DepartmentHeadsMapping.Items[index].FindControl("rcmbSubHead") as RadComboBox;
                if (chkBox.Checked)
                {
                    if (string.Compare(rcmbEmployee.SelectedValue, "0", true) == 0)
                    {
                        BLL.ShowMessage(this, "Please Select Head Of the Department");
                        return;
                    }
                    if (string.Compare(rcmbSubHead.SelectedValue, "0", true) == 0 && string.Compare(rcmbEmployee.SelectedValue, rcmbSubHead.SelectedValue, true) == 0)
                    {
                        BLL.ShowMessage(this, "Please Select different employee for Sub Head Of the Department");
                        return;
                    }
                    _obj_SMHR_DepartmentHeads = new SMHR_DEPARTMENTHEADS();
                    _obj_SMHR_DepartmentHeads.DEPTHEAD_BU_ID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
                    _obj_SMHR_DepartmentHeads.DEPTHEAD_DEPT_ID = Convert.ToInt32(lblDepartmentID.Text);
                    _obj_SMHR_DepartmentHeads.DEPTHEAD_EMP_ID = Convert.ToInt32(rcmbEmployee.SelectedItem.Value);
                    _obj_SMHR_DepartmentHeads.DEPTHEAD_SUBHEAD_ID = Convert.ToInt32(rcmbSubHead.SelectedItem.Value);
                    _obj_SMHR_DepartmentHeads.DEPTHEAD_STATUS_IS_ACTIVE = true;
                    _obj_SMHR_DepartmentHeads.DEPTHEAD_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);//##Session Required Here
                    _obj_SMHR_DepartmentHeads.DEPTHEAD_CREATEDDATE = DateTime.Now;
                    _obj_SMHR_DepartmentHeads.DEPTHEAD_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);//##Session Required Here
                    _obj_SMHR_DepartmentHeads.DEPTHEAD_LASTMDFDATE = DateTime.Now;
                    status = BLL.set_DepartmentHeads(_obj_SMHR_DepartmentHeads);
                    count++;
                }
            }
            if (count == 0)
            {
                BLL.ShowConfirmMessage(this, "Please Select Atleast One Department to Assign the Head(s)");
            }
            if (status == true)
            {
                BLL.ShowMessage(this, "Department Head(s) Successfully Assigned");
                Rg_DepartmentHeadsMapping.Visible = false;
                ddl_BusinessUnit.SelectedIndex = 0;
                rad_Directorate.SelectedIndex = 0;
                btn_submit.Visible = false;
                btn_Cancel.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DepartmentHeads", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {

            CheckBox chkBox = new CheckBox();
            RadComboBox rcmbEmployee = new RadComboBox();
            RadComboBox rcmbSubHead = new RadComboBox();
            for (int index = 0; index <= Rg_DepartmentHeadsMapping.Items.Count - 1; index++)
            {
                chkBox = Rg_DepartmentHeadsMapping.Items[index].FindControl("chk_Select") as CheckBox;
                rcmbEmployee = Rg_DepartmentHeadsMapping.Items[index].FindControl("rcmbEmployee") as RadComboBox;
                rcmbSubHead = Rg_DepartmentHeadsMapping.Items[index].FindControl("rcmbSubHead") as RadComboBox;
                rcmbEmployee.ClearSelection();
                rcmbSubHead.ClearSelection();
                if (chkBox.Checked)
                {
                    chkBox.Checked = false;
                }
            }
            //written by rajasekhar to clear grid header checkbox 22/nov/2013
            GridHeaderItem headerItem = Rg_DepartmentHeadsMapping.MasterTableView.GetItems(GridItemType.Header)[0] as GridHeaderItem;
            (headerItem.FindControl("chk_selectall") as CheckBox).Checked = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DepartmentHeads", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}