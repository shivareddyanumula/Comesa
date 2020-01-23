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

public partial class HR_frm_Relieving : System.Web.UI.Page
{
    SMHR_MASTERS _obj_Smhr_Masters;
    SMHR_EMPLOYEE _obj_Smhr_Employee;
    SMHR_EMPASSETDOC _obj_Smhr_EmpAssetDoc;
    SMHR_EMPNODUE _obj_Smhr_EmpNoDue;
    DataTable dt_null;

    public string Status = "0";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
            if (!Page.IsPostBack)
            {
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Employee Relieving");//EMPLOYEE RELIEVING");
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
                    Rg_EmpRelive.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Submit.Visible = false;

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
                // rd_Rel.Visible = false;
                BLL.ChangeDateFormat(Convert.ToString(Session["EMP_ID"]), rdtp_RelDate, rdtp_ResgDate);
                BLL.gridDateFormat(Convert.ToString(Session["EMP_ID"]), Rg_EmpRelive, "EMP_RESGDATE", "EMP_RELDATE");

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Relieving", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadEmployee()
    {
        try
        {
            string s = "SELECT";
            rcmb_Employee.Items.Clear();
            //CHECK AS IT IS STRING...
            rcmb_Employee.DataSource = BLL.get_EmpReliving(s, string.Empty, Convert.ToInt32(Session["ORG_ID"]), Convert.ToInt32(Session["USER_ID"]));
            rcmb_Employee.DataTextField = "EMPNAME";
            rcmb_Employee.DataValueField = "EMP_ID";
            rcmb_Employee.DataBind();
            rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
            s = string.Empty;
            //rdtp_RelDate.MinDate = DateTime.Now;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Relieving", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void LoadEmployee_edit()
    {
        try
        {
            string s = "SELECT1";
            rcmb_Employee.Items.Clear();
            //CHECK AS IT IS STRING...
            rcmb_Employee.DataSource = BLL.get_EmpReliving_Edit(s, string.Empty, Convert.ToInt32(Session["ORG_ID"]));
            rcmb_Employee.DataTextField = "EMPNAME";
            rcmb_Employee.DataValueField = "EMP_ID";
            rcmb_Employee.DataBind();
            rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
            s = string.Empty;
            //rdtp_RelDate.MinDate = DateTime.Now;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Relieving", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadNoDueGrid()
    {
        try
        {
            _obj_Smhr_Masters = new SMHR_MASTERS();
            _obj_Smhr_Masters.OPERATION = operation.Select;
            _obj_Smhr_Masters.MASTER_TYPE = "NODUE";
            _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt1 = BLL.get_MasterRecords(_obj_Smhr_Masters);
            if (dt1.Rows.Count != 0)
            {
                Rg_VNoDues.DataSource = dt1;
                Rg_VNoDues.DataBind();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Relieving", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadAssetGrid()
    {
        try
        {
            _obj_Smhr_EmpAssetDoc = new SMHR_EMPASSETDOC();
            _obj_Smhr_EmpAssetDoc.OPERATION = operation.Empty;

            _obj_Smhr_EmpAssetDoc.EMPASSETDOC_TYPE = "Assets";
            _obj_Smhr_EmpAssetDoc.EMPASSETDOC_EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedItem.Value.ToString());
            _obj_Smhr_EmpAssetDoc.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt2 = BLL.get_EmpAssetDoc(_obj_Smhr_EmpAssetDoc);
            if (dt2.Rows.Count != 0)
            {
                Rg_AssetDetails.DataSource = dt2;
                Rg_AssetDetails.DataBind();
            }
            else
            {
                lbl_AsstMessage.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Relieving", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }
    protected void LoadDocumentGrid()
    {
        try
        {
            _obj_Smhr_EmpAssetDoc = new SMHR_EMPASSETDOC();
            _obj_Smhr_EmpAssetDoc.OPERATION = operation.Empty;
            _obj_Smhr_EmpAssetDoc.EMPASSETDOC_TYPE = "Documents";
            _obj_Smhr_EmpAssetDoc.EMPASSETDOC_EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedItem.Value.ToString());
            _obj_Smhr_EmpAssetDoc.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt3 = BLL.get_EmpAssetDoc(_obj_Smhr_EmpAssetDoc);
            if (dt3.Rows.Count != 0)
            {
                Rg_Document.DataSource = dt3;
                Rg_Document.DataBind();
            }
            else
            {
                lbl_DOCMSG.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Relieving", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private bool ValidateDate()
    {
        bool flag = false;
        try
        {
            _obj_Smhr_Employee = new SMHR_EMPLOYEE();
            DataTable dtDet = new DataTable();
            _obj_Smhr_Employee.OPERATION = operation.Select;
            _obj_Smhr_Employee.EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedItem.Value);
            _obj_Smhr_EmpAssetDoc.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dtDet = BLL.get_Employee(_obj_Smhr_Employee);
            if (dtDet == null)
            {
                flag = true;
            }
            else if (dtDet.Rows.Count == 0)
            {
                flag = true;
            }
            else
            {
                if (Convert.ToDateTime(rdtp_RelDate.SelectedDate.ToString()) <= Convert.ToDateTime(dtDet.Rows[0]["EMP_RESGDATE"].ToString()))
                {
                    BLL.ShowMessage(this, "Resignation Date Should not be ahead of Relieving Date");
                    flag = false;
                }
                else
                {
                    flag = true;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Relieving", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return flag;
    }
    protected void rcmb_Employee_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            _obj_Smhr_Employee = new SMHR_EMPLOYEE();
            if (rcmb_Employee.SelectedItem.Value != "-1")
            {
                string s = "SELECT";
                _obj_Smhr_Employee.EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedItem.Value);
                SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
                _obj_smhr_logininfo.OPERATION = operation.Select3;
                _obj_smhr_logininfo.LOGIN_EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedItem.Value);
                _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_emp = BLL.get_LoginInfo(_obj_smhr_logininfo);
                if (dt_emp.Rows.Count > 0)
                {
                    rdtp_RelDate.MinDate = Convert.ToDateTime(dt_emp.Rows[0]["EMP_RESGDATE"]);
                }
                lnk_PersonalDetails.Enabled = true;
                //TO GET EMPLOYEES REPORTED TO HIM
                LoadReportees();
                rg_Reportees.DataBind();
                if (rg_Reportees.Items.Count > 0)
                {
                    //  rd_Rel.Visible = false;
                    RM_EMPREL_PAGE.Visible = false;
                    BLL.ShowMessage(this, "Please Assign Supervisor To The Below List Of Employees, Reporting To " + Convert.ToString(rcmb_Employee.SelectedItem.Text) + ".");
                    rg_Reportees.Visible = true;
                    btn_Submit.Enabled = false;
                    return;
                }
                else
                {
                    rg_Reportees.Visible = false;
                }
                LoadNoDueGrid();
                LoadAssetGrid();
                LoadDocumentGrid();
                //NEED TO CHECK AS IT IS STRING

                DataTable dt = BLL.get_EmpReliving(s, rcmb_Employee.SelectedItem.Value, Convert.ToInt32(Session["ORG_ID"]), Convert.ToInt32(Session["USER_ID"]));
                rdtp_ResgDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["EMP_RESGDATE"]);
                RM_EMPREL_PAGE.PageViews[0].Selected = true;
                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    btn_Submit.Enabled = false;
                }
                else
                {
                    btn_Submit.Enabled = true;
                }
                //   rd_Rel.Visible = true;
                RM_EMPREL_PAGE.Visible = true;
                //Session["empid"] = Convert.ToInt32(rcmb_Employee.SelectedItem.Value);
                //lnk_PersonalDetails.OnClientClick = " openRadWin('frmemppersonal.aspx?empid=" + Convert.ToInt32(rcmb_Employee.SelectedItem.Value) + "'); return false; ";
                int mode = 2;
                lnk_PersonalDetails.OnClientClick = " openRadWin('frmemppersonal.aspx?empid=" + Convert.ToInt32(rcmb_Employee.SelectedItem.Value) + " &mode=" + Convert.ToInt32(mode) + "'); return false; ";


            }
            else
            {
                ClearFields();
                lnk_PersonalDetails.Enabled = false;
                lnk_PersonalDetails.OnClientClick = null;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Relieving", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime dtime = Convert.ToDateTime(rdtp_RelDate.SelectedDate.ToString());
            StringBuilder strQry = new StringBuilder();
            _obj_Smhr_Employee = new SMHR_EMPLOYEE();
            _obj_Smhr_EmpNoDue = new SMHR_EMPNODUE();
            _obj_Smhr_EmpAssetDoc = new SMHR_EMPASSETDOC();
            _obj_Smhr_Employee.EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedItem.Value);
            _obj_Smhr_Employee.EMP_RELDATE = Convert.ToDateTime(rdtp_RelDate.SelectedDate.ToString());
            _obj_Smhr_Employee.EMP_STATUS = 1;
            //_obj_Smhr_Employee.EMP_STATUS = 2;
            _obj_Smhr_Employee.EMP_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_Smhr_Employee.EMP_LASTMDFDATE = DateTime.Now;
            _obj_Smhr_Employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Employee.OPERATION = operation.Update;
            // BLL.set_Employee(_obj_Smhr_Employee);

            if (Convert.ToString(ViewState["Status"]) == "False")
            {

                # region comment
                //for (int i = 0; i < Rg_VNoDues.Items.Count; i++)
                //{
                //    int temp = Convert.ToInt32(Rg_VNoDues.Items[i].Cells[2].Text);
                //    string temp1 = Rg_VNoDues.Items[i].Cells[3].Text;
                //    RadComboBox ddlList;
                //    ddlList = (RadComboBox)Rg_VNoDues.Items[i].Cells[4].FindControl("rcmb_ChooseType");
                //    RadTextBox txt_Remarks;
                //    txt_Remarks = (RadTextBox)Rg_VNoDues.Items[i].FindControl("txtRemarks");
                //    _obj_Smhr_EmpNoDue = new SMHR_EMPNODUE();
                //    _obj_Smhr_EmpNoDue.EMPNODUE_EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedItem.Value);
                //    _obj_Smhr_EmpNoDue.EMPNODUE_HR_MASTER_ID = temp;
                //    if (Convert.ToInt32(ddlList.SelectedItem.Value) == 1 || Convert.ToInt32(ddlList.SelectedItem.Value) == 4)
                //    {
                //        _obj_Smhr_EmpNoDue.EMPNODUE_STATUS = Convert.ToInt32(ddlList.SelectedItem.Value);
                //    }
                //    else
                //    {
                //       // BLL.ShowMessage(this, "No Dues are not cleared, Please check it out");
                //        //return;
                //    }
                //    _obj_Smhr_EmpNoDue.EMPNODUE_REMARKS = txt_Remarks.Text.ToString().Trim();
                //    _obj_Smhr_EmpNoDue.OPERATION = operation.Insert;
                //    _obj_Smhr_EmpNoDue.EMPNODUE_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                //    _obj_Smhr_EmpNoDue.EMPNODUE_CREATEDDATE = DateTime.Now;
                //    _obj_Smhr_EmpNoDue.EMPNODUE_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                //    _obj_Smhr_EmpNoDue.EMPNODUE_LASTMDFDATE = DateTime.Now;
                //    //ORG
                //    strQry.Append(BLL.set_EmpNoDue(_obj_Smhr_EmpNoDue, _obj_Smhr_EmpAssetDoc) + " \n");
                //}

                //for (int i = 0; i < Rg_AssetDetails.Items.Count; i++)
                //{
                //    string temp2 = Rg_AssetDetails.Items[i].Cells[2].Text;
                //    RadComboBox ddlList;
                //    ddlList = (RadComboBox)Rg_AssetDetails.Items[i].FindControl("rcmb_AssetType");
                //    RadTextBox txt_Remarks;
                //    txt_Remarks = (RadTextBox)Rg_AssetDetails.Items[i].FindControl("rtxt_Assetremarks");
                //    _obj_Smhr_EmpNoDue = new SMHR_EMPNODUE();
                //    _obj_Smhr_EmpNoDue.OPERATION = operation.Update;
                //    _obj_Smhr_EmpAssetDoc = new SMHR_EMPASSETDOC();
                //    _obj_Smhr_EmpAssetDoc.EMPASSETDOC_EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedItem.Value);
                //    _obj_Smhr_EmpAssetDoc.EMPASSETDOC_NAME = temp2.ToString().Trim();
                //    _obj_Smhr_EmpAssetDoc.EMPASSETDOC_TYPE = "Assets";
                //    if (Convert.ToInt32(ddlList.SelectedItem.Value) == 1)
                //    {
                //        _obj_Smhr_EmpAssetDoc.EMP_ASSETDOC_STATUS = Convert.ToInt32(ddlList.SelectedItem.Value);
                //    }
                //    else
                //    {
                //        BLL.ShowMessage(this, "Assets Clearence is not completed, please check it out");
                //        return;
                //    }

                //    _obj_Smhr_EmpAssetDoc.EMP_ASSETDOC_REMARKS = txt_Remarks.Text.ToString().Trim();
                //    _obj_Smhr_EmpAssetDoc.OPERATION = operation.Update;
                //    //ORG
                //    strQry.Append(BLL.set_EmpNoDue(_obj_Smhr_EmpNoDue, _obj_Smhr_EmpAssetDoc) + " \n");
                //}

                //for (int i = 0; i < Rg_Document.Items.Count; i++)
                //{
                //    Label lblDoc;
                //    string temp3 = Rg_Document.Items[i].Cells[2].Text;
                //    lblDoc = (Label)Rg_Document.Items[i].FindControl("lblDocumentType");
                //    RadComboBox ddlDoc;
                //    ddlDoc = (RadComboBox)Rg_Document.Items[i].FindControl("rcmb_DocType");
                //    RadTextBox txtDoc;
                //    txtDoc = (RadTextBox)Rg_Document.Items[i].FindControl("rtxt_DocRemarks");
                //    _obj_Smhr_EmpNoDue = new SMHR_EMPNODUE();
                //    _obj_Smhr_EmpNoDue.OPERATION = operation.Update;
                //    _obj_Smhr_EmpAssetDoc = new SMHR_EMPASSETDOC();
                //    _obj_Smhr_EmpAssetDoc.EMPASSETDOC_EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedItem.Value);
                //    _obj_Smhr_EmpAssetDoc.EMPASSETDOC_NAME = temp3.ToString().Trim();
                //    _obj_Smhr_EmpAssetDoc.EMPASSETDOC_TYPE = "Documents";
                //    if (Convert.ToInt32(ddlDoc.SelectedItem.Value) == 1)
                //    {
                //        _obj_Smhr_EmpAssetDoc.EMP_ASSETDOC_STATUS = Convert.ToInt32(ddlDoc.SelectedItem.Value);
                //    }
                //    else
                //    {
                //        BLL.ShowMessage(this, "Documents Clearence is not completed, please check it out");
                //        return;
                //    }

                //    _obj_Smhr_EmpAssetDoc.EMP_ASSETDOC_REMARKS = txtDoc.Text.ToString().Trim();
                //    _obj_Smhr_EmpAssetDoc.OPERATION = operation.Update;
                //    //ORG
                //    strQry.Append(BLL.set_EmpNoDue(_obj_Smhr_EmpNoDue, _obj_Smhr_EmpAssetDoc) + " \n");
                //}

                #endregion
            }

            //To check whether organisation has Integration with Smart PM or not 
            //SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
            //_obj_Smhr_BusinessUnit.OPERATION = operation.Get_BU;
            //_obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //DataTable dt_bu = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
            //if(dt_bu.Rows.Count>0)
            //{
            //    if (dt_bu.Rows[0]["ORGANISATION_INTEGRATION"] != DBNull.Value && Convert.ToString(dt_bu.Rows[0]["ORGANISATION_INTEGRATION"]) == "True")
            //    {
            //        SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
            //        _obj_smhr_logininfo.OPERATION = operation.Select3;
            //        _obj_smhr_logininfo.LOGIN_EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedItem.Value);
            //        _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //        DataTable dt_emp = BLL.get_LoginInfo(_obj_smhr_logininfo);
            //        if (dt_emp.Rows.Count > 0)
            //        {
            //            _obj_smhr_logininfo.BUID = Convert.ToInt32(dt_emp.Rows[0]["EMP_BUSINESSUNIT_ID"]);
            //            _obj_smhr_logininfo.OPERATION = operation.Empty;
            //            DataTable dt_org = BLL.get_LoginInfo(_obj_smhr_logininfo);
            //            if (dt_org.Rows.Count > 0)
            //            {
            //                _obj_Smhr_Employee.EMP_EMPCODE = Convert.ToString(dt_emp.Rows[0]["EMP_EMPCODE"]);
            //                _obj_Smhr_Employee.ORGANISATION_ID = Convert.ToInt32(dt_org.Rows[0]["SMPM_ORG"]);
            //                DataTable dt = BLL.get_EmpTask(_obj_Smhr_Employee);
            //                if (dt.Rows.Count > 0)
            //                {
            //                    if (Convert.ToInt32(dt.Rows[0]["COUNT"]) > 0)
            //                    {
            //                        BLL.ShowMessage(this, "Employee has Pending Tasks in Smart PM.You can not Relieve this Employee.");
            //                        return;
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            //DataTable dt = BLL.get_EmpTask(_obj_Smhr_Employee);
            //if (dt.Rows.Count > 0)
            //{
            //    if (Convert.ToInt32(dt.Rows[0]["COUNT"]) > 0)
            //    {
            //        BLL.ShowMessage(this, "Employee has Pending Tasks in Smart PM.You can not Relieve this Employee.");
            //        return;
            //    }
            //}
            _obj_Smhr_Employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //ORG
            if (BLL.set_EmpReliving(_obj_Smhr_Employee, strQry.ToString(), Convert.ToInt32(Session["ORG_ID"])))
            {
                BLL.ShowMessage(this, "Relieving process completed successfully");
                LoadGrid();
                Rg_EmpRelive.DataBind();
                ClearFields();
                Rm_EmpRelive_page.SelectedIndex = 0;
            }
            else
            {
                BLL.ShowMessage(this, "Process failed");
            }

            LoadEmployee();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Relieving", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rdtp_RelDate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        try
        {
            if (!(ValidateDate() == true))
            {
                rdtp_RelDate.SelectedDate = null;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Relieving", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void ClearFields()
    {
        try
        {
            rcmb_Employee.SelectedIndex = -1;

            rdtp_RelDate.SelectedDate = null;
            lnk_PersonalDetails.Enabled = false;
            Rg_VNoDues.DataSource = null;
            Rg_VNoDues.DataBind();
            Rg_AssetDetails.DataSource = null;
            Rg_AssetDetails.DataBind();
            Rg_Document.DataSource = dt_null;
            Rg_Document.DataBind();
            rdtp_ResgDate.SelectedDate = null;
            btn_Submit.Enabled = false;
            //Rm_EmpRelive_page.SelectedIndex = 0;
            //  rd_Rel.Visible = false;
            rg_Reportees.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Relieving", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            ClearFields();
            //   rd_Rel.Visible = false;
            Rm_EmpRelive_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Relieving", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_PersonalDetails_Click(object sender, EventArgs e)
    {
        // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Guid.NewGuid().ToString(), "function pageLoad() {if(test==1){openRadWin('http://google.com'); test=0;} } ", true);
        //   Status = "1"; 
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            LoadEmployee();
            ClearFields();
            Rm_EmpRelive_page.SelectedIndex = 1;
            rcmb_Employee.Enabled = true;
            btn_Submit.Enabled = false;
            ViewState["Status"] = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Relieving", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    public void LoadGrid()
    {
        try
        {
            //ORG
            DataTable DT = BLL.get_EmpReliving("", "-1", Convert.ToInt32(Session["ORG_ID"]), Convert.ToInt32(Session["USER_ID"]));
            Rg_EmpRelive.DataSource = DT;
            // clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Relieving", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Rg_EmpRelive_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Relieving", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            ClearFields();
            LoadEmployee();
            //Rg_Document.DataSource = null;
            //Rg_Document.DataBind();
            LoadEmployee_edit();
            Rm_EmpRelive_page.SelectedIndex = 1;
            string s = "Get";
            DataTable dt = BLL.get_EmpReliving_Edit(s, Convert.ToString(e.CommandArgument), Convert.ToInt32(Session["ORG_ID"]));
            if ((Convert.ToInt32(dt.Rows[0]["EMP_STATUS"]) == 2) || (Convert.ToInt32(dt.Rows[0]["EMP_STATUS"]) == 3))
            {
                BLL.ShowMessage(this, "Employee is Already Relieved.You can not edit this record.");
                Rm_EmpRelive_page.SelectedIndex = 0;
                return;
            }
            else
            {
                rcmb_Employee.SelectedIndex = rcmb_Employee.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["EMP_ID"]));
                int mode = 1;// for personal details
                lnk_PersonalDetails.OnClientClick = " openRadWin('frmemppersonal.aspx?empid=" + Convert.ToInt32(rcmb_Employee.SelectedItem.Value) + " &mode=" + Convert.ToInt32(mode) + "'); return false; ";
                rdtp_ResgDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["EMP_RESGDATE"]);
                rdtp_RelDate.MinDate = Convert.ToDateTime(dt.Rows[0]["EMPREG_REGDATE"]);
                rdtp_RelDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["EMP_RELDATE"]);
                //rdtp_ResgDate.SelectedDate = DateTime.ParseExact(Convert.ToString(dt.Rows[0]["EMP_RESGDATE"]), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                //rdtp_RelDate.SelectedDate = DateTime.ParseExact(Convert.ToString(dt.Rows[0]["EMP_RELDATE"]), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                rcmb_Employee.Enabled = false;
                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    btn_Submit.Enabled = false;
                }
                else
                {
                    btn_Submit.Enabled = true;
                }
                //   rd_Rel.Visible = false;
                RM_EMPREL_PAGE.Visible = false;
                //Rg_Document.DataSource = null;
                //Rg_Document.DataBind();
            }
            ViewState["Status"] = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Relieving", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void rg_Reportees_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadReportees();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Relieving", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadReportees()
    {
        try
        {
            if (rcmb_Employee.SelectedIndex > 0)
            {
                //TO GET EMPLOYEES REPORTED TO HIM
                _obj_Smhr_Employee = new SMHR_EMPLOYEE();
                _obj_Smhr_Employee.EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedItem.Value);
                _obj_Smhr_Employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_Employee.OPERATION = operation.Select_Emp;
                DataTable dt_emp = BLL.get_Reportees(_obj_Smhr_Employee);
                rg_Reportees.DataSource = dt_emp;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Relieving", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}

