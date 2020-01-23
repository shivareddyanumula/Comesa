using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;

using System.Web.UI.WebControls;
using Telerik.Web.UI;
using SMHR;
using System.Data;

public partial class Masters_frm_ApprovalProcess : System.Web.UI.Page
{
    PMS_APPROVAL_PROCESS _obj_pms_approval_process = new PMS_APPROVAL_PROCESS();
    static int OrganizationID = 0;
    int rcmbEmp1ID = 0;
    int rcmbEmp2ID = 0;
    int rcmbEmp3ID = 0;

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
            _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Approver Process");
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
                Rg_ApprovalProcess.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                btn_Submit.Visible = false;
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
            if (Session["ORG_ID"] == null)
            {
                Response.Redirect("~/frm_SesstionExp.aspx", false);
                return;
            }
            LoadAppProcessGrid();
            OrganizationID = Convert.ToInt32(Session["ORG_ID"].ToString());
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApproverProcess", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    [WebMethod]
    public static RadComboBoxItemData[] GET_EmployeeBySearchString(object context)
    {
        IDictionary<string, object> contextDictionary = (IDictionary<string, object>)context;

        string filterString = ((string)contextDictionary["FilterString"]).Length > 2 ? ((string)contextDictionary["FilterString"]).ToLower() : "";

        DataTable dtEMPData = BLL.get_EmployeeBySearchString(OrganizationID, filterString);

        List<RadComboBoxItemData> result = new List<RadComboBoxItemData>(dtEMPData.Rows.Count);
        foreach (DataRow row in dtEMPData.Rows)
        {
            RadComboBoxItemData itemData = new RadComboBoxItemData();
            itemData.Text = row["EMPNAME"].ToString();
            itemData.Value = row["EMP_ID"].ToString();
            result.Add(itemData);
        }
        return result.ToArray();
    }

    protected void Rg_ApprovalProcess_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadAppProcessGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApproverProcess", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void LoadAppProcessGrid()
    {
        try
        {
            OrganizationID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtLoadGrid = BLL.Load_PMS_APPROVAL_PROCESS_GRID(OrganizationID);

            Rg_ApprovalProcess.DataSource = dtLoadGrid;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApproverProcess", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Clears()
    {
        try
        {
            rcmb_Emp1.Text = string.Empty;
            rcmb_Emp1.Items.Clear();
            rcmb_Emp1.ClearSelection();
            rcmb_Emp2.Text = string.Empty;
            rcmb_Emp2.Items.Clear();
            rcmb_Emp2.ClearSelection();
            rcmb_Emp3.Text = string.Empty;
            rcmb_Emp3.Items.Clear();
            rcmb_Emp3.ClearSelection();

            ChkStatus.Checked = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApproverProcess", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_Emp1_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            //if (rcmb_Emp2.SelectedIndex > 0)
            //    rcmbEmp1ID = Convert.ToInt32(rcmb_Emp1.SelectedValue);
            //if (rcmb_Emp2.SelectedIndex > 0)
            //    rcmbEmp2ID = Convert.ToInt32(rcmb_Emp2.SelectedValue);
            //if (rcmb_Emp3.SelectedIndex > 0)
            //    rcmbEmp3ID = Convert.ToInt32(rcmb_Emp3.SelectedValue);

            //if ((rcmbEmp1ID == rcmbEmp2ID) || (rcmbEmp1ID == rcmbEmp3ID))
            //{
            //    BLL.ShowMessage(this, "Plese Select Another Employee..");

            //    if (rcmbEmp1ID == rcmbEmp2ID)
            //        rcmb_Emp2.Focus();
            //    else
            //        rcmb_Emp3.Focus();
            //}

            rcmbEmp1ID = (string.IsNullOrEmpty(rcmb_Emp1.SelectedValue) ? 0 : Convert.ToInt32(rcmb_Emp1.SelectedValue));
            rcmbEmp2ID = (string.IsNullOrEmpty(rcmb_Emp2.SelectedValue) ? 0 : Convert.ToInt32(rcmb_Emp2.SelectedValue)); //Convert.ToInt32(rcmb_Emp2.SelectedValue);
            rcmbEmp3ID = (string.IsNullOrEmpty(rcmb_Emp3.SelectedValue) ? 0 : Convert.ToInt32(rcmb_Emp3.SelectedValue)); //Convert.ToInt32(rcmb_Emp2.SelectedValue);
            if (rcmb_Emp1.SelectedValue.ToString() == "")
            {
                BLL.ShowMessage(this, "Please Select Emp Name");
                rcmb_Emp1.Text = string.Empty;
                rcmb_Emp1.Focus();
                return;
            }
            else if (rcmbEmp1ID == rcmbEmp2ID || rcmbEmp1ID == rcmbEmp3ID)
            {
                BLL.ShowMessage(this, "Please Enter Another Employee");
                rcmb_Emp2.Text = string.Empty;
                rcmb_Emp2.Items.Clear();
                rcmb_Emp2.Focus();
            }
            else
            {
                //rcmb_Emp1.Enabled = false;
                //rcmb_Emp2.Enabled = true;
                rcmb_Emp2.Focus();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApproverProcess", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_Emp2_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            /*if (rcmb_Emp2.SelectedIndex > 0)
                rcmbEmp1ID = Convert.ToInt32(rcmb_Emp1.SelectedValue);
            if (rcmb_Emp2.SelectedIndex > 0)
                rcmbEmp2ID = Convert.ToInt32(rcmb_Emp2.SelectedValue);
            if (rcmb_Emp3.SelectedIndex > 0)
                rcmbEmp3ID = Convert.ToInt32(rcmb_Emp3.SelectedValue);

            if ((rcmbEmp1ID == rcmbEmp2ID) || (rcmbEmp2ID == rcmbEmp3ID))
            {
                BLL.ShowMessage(this, "Plese Select Another Employee..");

                if (rcmbEmp1ID == rcmbEmp2ID)
                    rcmb_Emp1.Focus();
                else
                    rcmb_Emp3.Focus();
            }
            */
            rcmbEmp1ID = (string.IsNullOrEmpty(rcmb_Emp1.SelectedValue) ? 0 : Convert.ToInt32(rcmb_Emp1.SelectedValue));
            rcmbEmp3ID = (string.IsNullOrEmpty(rcmb_Emp3.SelectedValue) ? 0 : Convert.ToInt32(rcmb_Emp3.SelectedValue));

            if (rcmb_Emp2.SelectedValue.ToString() == "")
            {
                BLL.ShowMessage(this, "Please Select Emp Name");
                rcmb_Emp2.Text = string.Empty;
                rcmb_Emp2.Focus();
                return;
            }
            else
            {
                rcmbEmp2ID = Convert.ToInt32(rcmb_Emp2.SelectedValue);
            }
            if (rcmbEmp1ID == rcmbEmp2ID || rcmbEmp2ID == rcmbEmp3ID)
            {
                BLL.ShowMessage(this, "Please Enter Another Employee");
                rcmb_Emp2.Text = string.Empty;
                rcmb_Emp2.Items.Clear();
                rcmb_Emp2.Focus();
            }
            else
            {
                //rcmb_Emp2.Enabled = false;
                //rcmb_Emp3.Enabled = true;
                rcmb_Emp3.Focus();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApproverProcess", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_Emp3_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            /*if (rcmb_Emp2.SelectedIndex > 0)
                rcmbEmp1ID = Convert.ToInt32(rcmb_Emp1.SelectedValue);
            if (rcmb_Emp2.SelectedIndex > 0)
                rcmbEmp2ID = Convert.ToInt32(rcmb_Emp2.SelectedValue);
            if (rcmb_Emp3.SelectedIndex > 0)
                rcmbEmp3ID = Convert.ToInt32(rcmb_Emp3.SelectedValue);

            if ((rcmbEmp3ID == rcmbEmp2ID) || (rcmbEmp1ID == rcmbEmp3ID))
            {
                BLL.ShowMessage(this, "Plese Select Another Employee..");

                if (rcmbEmp1ID == rcmbEmp3ID)
                    rcmb_Emp1.Focus();
                else
                    rcmb_Emp2.Focus();
            }
            */
            rcmbEmp1ID = (string.IsNullOrEmpty(rcmb_Emp1.SelectedValue) ? 0 : Convert.ToInt32(rcmb_Emp1.SelectedValue));
            rcmbEmp2ID = (string.IsNullOrEmpty(rcmb_Emp2.SelectedValue) ? 0 : Convert.ToInt32(rcmb_Emp2.SelectedValue)); //Convert.ToInt32(rcmb_Emp2.SelectedValue);
            if (rcmb_Emp3.SelectedValue.ToString() == "")
            {
                BLL.ShowMessage(this, "Please Select Emp Name");
                rcmb_Emp3.Text = string.Empty;
                rcmb_Emp3.Focus();
                return;
            }
            else
            {
                rcmbEmp3ID = Convert.ToInt32(rcmb_Emp3.SelectedValue);

            }
            if ((rcmbEmp3ID == rcmbEmp1ID) || (rcmbEmp3ID == rcmbEmp2ID))
            {
                BLL.ShowMessage(this, "Please Enter Another Employee");
                rcmb_Emp3.Text = string.Empty;
                rcmb_Emp3.Items.Clear();
                rcmb_Emp3.Focus();
            }
            else
            {
                //rcmb_Emp3.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApproverProcess", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            RadComboBoxItem rcb1 = new RadComboBoxItem();
            RadComboBoxItem rcb2 = new RadComboBoxItem();
            RadComboBoxItem rcb3 = new RadComboBoxItem();
            RadComboBoxItem rcmb_BU = new RadComboBoxItem();


            ChkStatus.Enabled = true;

            btn_Submit.Visible = false;
            btn_Update.Visible = true;

            rcmb_Emp1.Enabled = false;
            rcmb_Emp2.Enabled = false;
            rcmb_Emp3.Enabled = false;
            rcmb_BusinessUnit.Enabled = false;

            LoadBusinessUnit();

            int appPrcsID = Convert.ToInt32(e.CommandArgument);
            ViewState["appPrcsID"] = appPrcsID;
            DataTable dtAppPrcs = BLL.get_PMS_APPROVAL_PROCESS(appPrcsID);

            if (dtAppPrcs.Rows.Count == 1)
            {
                rcmb_BU.Text = Convert.ToString(dtAppPrcs.Rows[0]["BUSINESSUNIT_CODE"]);
                rcmb_BU.Value = Convert.ToString(dtAppPrcs.Rows[0]["BUSINESSUNIT_ID"]);
                rcmb_BusinessUnit.Items.Insert(0, rcmb_BU);

                rcb1.Text = Convert.ToString(dtAppPrcs.Rows[0]["EMP_NAME_1"]);
                rcb1.Value = Convert.ToString(dtAppPrcs.Rows[0]["PMS_APPROVAL_PROCESS_EMP_ID_1"]);
                rcmb_Emp1.Items.Insert(0, rcb1);

                rcb2.Text = Convert.ToString(dtAppPrcs.Rows[0]["EMP_NAME_2"]);
                rcb2.Value = Convert.ToString(dtAppPrcs.Rows[0]["PMS_APPROVAL_PROCESS_EMP_ID_2"]);
                rcmb_Emp2.Items.Insert(0, rcb2);

                rcb3.Text = Convert.ToString(dtAppPrcs.Rows[0]["EMP_NAME_3"]);
                rcb3.Value = Convert.ToString(dtAppPrcs.Rows[0]["PMS_APPROVAL_PROCESS_EMP_ID_3"]);
                rcmb_Emp3.Items.Insert(0, rcb3);

                ChkStatus.Checked = Convert.ToBoolean(dtAppPrcs.Rows[0]["PMS_APPROVAL_PROCESS_STATUS"].ToString());
            }

            Rm_ApprovalProcess_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApproverProcess", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            Clears();

            LoadBusinessUnit();
            ChkStatus.Enabled = false;

            btn_Submit.Visible = true;
            btn_Update.Visible = false;

            rcmb_Emp1.Enabled = true;
            rcmb_Emp2.Enabled = true;
            rcmb_Emp3.Enabled = true;
            rcmb_BusinessUnit.Enabled = true;

            Rm_ApprovalProcess_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApproverProcess", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadBusinessUnit()
    {
        try
        {
            SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
            _obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_BusinessUnit.OPERATION = operation.Select;
            DataTable dt_bus = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
            rcmb_BusinessUnit.Items.Clear();
            rcmb_BusinessUnit.DataSource = dt_bus;
            rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BusinessUnit.DataBind();
            rcmb_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApproverProcess", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dtCheckExists = new DataTable();
            bool status = false;
            int mode = 0;

            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_SUBMIT":

                    if (rcmb_BusinessUnit.SelectedIndex <= 0)
                    {
                        BLL.ShowMessage(this, "Please Select BusinessUnit");
                        return;
                    }
                    else if ((rcmb_Emp1.SelectedIndex == 0) || (rcmb_Emp3.SelectedIndex == 0))   // || (rcmb_Emp1.SelectedIndex == 0))
                    {
                        if (rcmb_Emp1.SelectedIndex == 0)
                        {
                            BLL.ShowMessage(this, "Please Select Directorate General");
                            rcmb_Emp1.Focus();
                        }
                        //else if (rcmb_Emp1.SelectedIndex == 0)
                        //{
                        //    BLL.ShowMessage(this, "Please Select Employee 2");
                        //    rcmb_Emp2.Focus();
                        //}
                        else
                        {
                            BLL.ShowMessage(this, "Please Select Clerk Senate");
                            rcmb_Emp3.Focus();
                        }
                    }

                    _obj_pms_approval_process.OPERATION = operation.Insert;
                    _obj_pms_approval_process.PMS_APPROVAL_PROCESS_EMP_ID_1 = (string.IsNullOrEmpty(rcmb_Emp1.SelectedValue) ? 0 : Convert.ToInt32(rcmb_Emp1.SelectedValue));
                    _obj_pms_approval_process.PMS_APPROVAL_PROCESS_EMP_ID_2 = (string.IsNullOrEmpty(rcmb_Emp2.SelectedValue) ? 0 : Convert.ToInt32(rcmb_Emp2.SelectedValue));
                    _obj_pms_approval_process.PMS_APPROVAL_PROCESS_EMP_ID_3 = (string.IsNullOrEmpty(rcmb_Emp3.SelectedValue) ? 0 : Convert.ToInt32(rcmb_Emp3.SelectedValue));
                    _obj_pms_approval_process.BUID = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
                    _obj_pms_approval_process.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_pms_approval_process.PMS_APPROVAL_PROCESS_STATUS = true;
                    //_obj_pms_approval_process.CREATEDBY = Convert.ToInt32(Session["EMP_ID"]);
                    _obj_pms_approval_process.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_pms_approval_process.CREATEDDATE = DateTime.Now;

                    dtCheckExists = BLL.Check_PMS_Approval_Process_Exists(_obj_pms_approval_process);

                    if (Convert.ToInt32(dtCheckExists.Rows[0]["COUNT"]) == 0)
                    {
                        status = BLL.set_PMS_APPROVAL_PROCESS(_obj_pms_approval_process);
                        if (status == true)
                        {
                            BLL.ShowMessage(this, "Information Saved Successfully");
                        }
                    }
                    else
                    {
                        //BLL.ShowMessage(this, "This Approval Process Already Exists");
                        BLL.ShowMessage(this, "An Active Record for Approver Process Already Exists");
                        return;
                    }
                    break;

                case "BTN_UPDATE":

                    _obj_pms_approval_process.OPERATION = operation.Update;
                    _obj_pms_approval_process.PMS_APPROVAL_PROCESS_ID = Convert.ToInt32(ViewState["appPrcsID"]);
                    _obj_pms_approval_process.PMS_APPROVAL_PROCESS_STATUS = Convert.ToBoolean(ChkStatus.Checked);
                   // _obj_pms_approval_process.LASTMDFBY = Convert.ToInt32(Session["EMP_ID"]);
                    _obj_pms_approval_process.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_pms_approval_process.LASTMDFDATE = DateTime.Now;

                    if (ChkStatus.Checked)
                    //mode = 1;
                    {
                        dtCheckExists = BLL.Check_PMS_Approval_Process_Update_Exists(Convert.ToInt32(Session["ORG_ID"]), Convert.ToInt32(rcmb_BusinessUnit.SelectedValue));   //, mode

                        if (Convert.ToInt32(dtCheckExists.Rows[0]["COUNT"]) == 0)
                        {
                            status = BLL.set_PMS_APPROVAL_PROCESS(_obj_pms_approval_process);
                            if (status == true)
                            {
                                BLL.ShowMessage(this, "Information Updated Successfully");
                            }
                        }
                        else
                        {
                            //BLL.ShowMessage(this, "This Approval Process Already Exists");
                            BLL.ShowMessage(this, "An Active Record for Approver Process Already Exists");
                            Rm_ApprovalProcess_page.SelectedIndex = 0;
                            return;
                        }
                    }
                    else
                    {
                        status = BLL.set_PMS_APPROVAL_PROCESS(_obj_pms_approval_process);
                        if (status == true)
                        {
                            BLL.ShowMessage(this, "Information Updated Successfully");
                        }
                    }
                    break;
            }

            LoadAppProcessGrid();
            Rg_ApprovalProcess.DataBind();
            Rm_ApprovalProcess_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApproverProcess", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            Clears();
            Rm_ApprovalProcess_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApproverProcess", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}