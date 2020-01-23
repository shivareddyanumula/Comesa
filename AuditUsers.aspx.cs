using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using Telerik.Web.UI;
using System.Collections;
using System.Text;
using PWDEncryprt;

public partial class AuditUsers : System.Web.UI.Page
{
    SMHR_BUSINESSUNIT _obj_businessunit;
    SMHR_LOGININFO _obj_LoginInfo;
    SMHR_LOGINTYPE _obj_Smhr_LoginInfo;

    private PWDEncryprt.PWDEncrypt pwdEncrypt = new PWDEncrypt();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                //Page.Validate();
                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("USERS");
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
                    Rg_UserManager.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Save.Visible = false;
                    btn_Update.Visible = false;
                    btn_AddBusinessUnit.Visible = false;
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

                if (!string.IsNullOrEmpty(Convert.ToString(Session["USERNAME"])))
                {
                    if (Convert.ToString(Session["USERNAME"]) != "SUPERADMIN")
                    {
                        Rg_UserManager.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    }
                }

                rmpAuditDetails.Visible = true;
                rmpAuditDetails.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Users", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            loadDropdown();
            LoadEmployees();
            clearControls();
            rcmb_Organisation.Enabled = false;
            rcmb_UserManagersEmployee.Enabled = false;
            rcmb_UserManagerUserGroups.Enabled = false;
            rtxt_UserManagerUserName.Enabled = false;
            rtxt_UserManagerEmail.Enabled = false;
            DataTable dt = BLL.get_LoginInfo(new SMHR_LOGININFO(Convert.ToInt32(Convert.ToString(e.CommandArgument))));
            if (dt.Rows.Count > 0)
            {
                ViewState["dt"] = dt;
                lbl_UserManagerID.Text = Convert.ToString(dt.Rows[0]["LOGIN_ID"]);
                rcmb_Organisation.SelectedIndex = rcmb_Organisation.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LOGIN_ORGANISATION_ID"]));
                if (Convert.ToInt32(Session["EMP_ID"]) == (-1))
                {
                    _obj_Smhr_LoginInfo = new SMHR_LOGINTYPE();
                    rcmb_UserManagerUserGroups.Items.Clear();
                    _obj_Smhr_LoginInfo.OPERATION = operation.Select;
                    _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(dt.Rows[0]["LOGIN_ORGANISATION_ID"]);  //Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dt_usergroup = BLL.get_LoginType(_obj_Smhr_LoginInfo);
                    rcmb_UserManagerUserGroups.DataSource = dt_usergroup;
                    rcmb_UserManagerUserGroups.DataTextField = "LOGTYP_CODE";
                    rcmb_UserManagerUserGroups.DataValueField = "LOGTYP_ID";
                    rcmb_UserManagerUserGroups.DataBind();
                    rcmb_UserManagerUserGroups.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                    //rcmb_UserManagerUserGroups.SelectedIndex = rcmb_UserManagerUserGroups.FindItemIndexByValue(dt_usergroup.Rows[0]["LOGTYP_CODE"].ToString());
                    LoadBusinessUnit();
                }
                if (Convert.ToString(dt.Rows[0]["LOGIN_EMP_ID"]) == "0")
                {
                    rcmb_UserManagersEmployee.SelectedIndex = 0;
                }
                else
                {
                    rcmb_UserManagersEmployee.SelectedIndex = rcmb_UserManagersEmployee.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LOGIN_EMP_ID"]));
                }
                rcmb_UserManagerUserGroups.SelectedIndex = rcmb_UserManagerUserGroups.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LOGIN_TYPE"]));
                rtxt_UserManagerUserName.Text = Convert.ToString(dt.Rows[0]["LOGIN_USERNAME"]);
                string strPass = BLL.PasswordDecrypt(Convert.ToString(dt.Rows[0]["LOGIN_PASSWORD"]));
                string strPass1 = BLL.PasswordDecrypt(Convert.ToString(dt.Rows[0]["LOGIN_PASS_CODE"]));
                //string strPass = Convert.ToString(dt.Rows[0]["LOGIN_PASSWORD"]);
                rtxt_UserManagerPassword.Attributes.Add("value", strPass);
                txt_PassCode.Attributes.Add("value", strPass1);
                rtxt_UserManagerEmail.Text = Convert.ToString(dt.Rows[0]["LOGIN_EMAILID"]);
                //chk_UserManagerStatus.Checked = Convert.ToBoolean(dt.Rows[0]["LOGIN_STATUS"]);
                if (Convert.ToBoolean(dt.Rows[0]["LOGIN_STATUS"]) == true)
                    rcmb_UserManagerStatus.SelectedValue = "1";
                else
                    rcmb_UserManagerStatus.SelectedValue = "0";

                if (Convert.ToInt32(Session["EMP_ID"]) != (-1))
                {
                    LoadBusinessUnit();
                }

                string str = Convert.ToString(dt.Rows[0]["LOGIN_BUSINESSUNITID"]);
                foreach (string item in str.Split(new char[] { ',' }))
                {
                    if (item != "")
                        rlst_BusinessUnit.Items.Add(new Telerik.Web.UI.RadListBoxItem(rcmb_UserManagerBusinessUnit.FindItemByValue(item).Text, rcmb_UserManagerBusinessUnit.FindItemByValue(item).Value));
                }

                //LoadBusinessUnit();
                //code for security
                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    btn_Update.Visible = false;

                }

                else
                {
                    btn_Update.Visible = true;
                }


                Rm_UM_page.SelectedIndex = 1;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Users", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            loadDropdown();
            LoadBusinessUnit();
            clearControls();
            rtxt_UserManagerEmail.Enabled = true;
            btn_Save.Visible = true;
            if (Convert.ToInt32(Session["EMP_ID"]) == (-1))
            {
                rcmb_UserManagersEmployee.Enabled = false;
            }
            else
            {
                rcmb_UserManagersEmployee.Enabled = false;
            }
            Rm_UM_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Users", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void LoadGrid()
    {
        try
        {
            if (Convert.ToInt32(Session["EMP_ID"]) > 0)
            {
                _obj_LoginInfo = new SMHR_LOGININFO();
                _obj_LoginInfo.OPERATION = operation.Select;
                _obj_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable DT = BLL.get_LoginInfo(_obj_LoginInfo);
                Rg_UserManager.DataSource = DT;
                clearControls();
            }
            else if (Convert.ToInt32(Session["EMP_ID"]) == 0)
            {
                _obj_LoginInfo = new SMHR_LOGININFO();
                _obj_LoginInfo.OPERATION = operation.Select2;
                _obj_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable DT = BLL.get_LoginInfo1(_obj_LoginInfo);
                Rg_UserManager.DataSource = DT;
                clearControls();
            }
            else
            {
                _obj_LoginInfo = new SMHR_LOGININFO();
                _obj_LoginInfo.OPERATION = operation.Select1;
                //_obj_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable DT = BLL.get_LoginInfo1(_obj_LoginInfo);
                Rg_UserManager.DataSource = DT;
                clearControls();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Users", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void loadDropdown()
    {
        try
        {
            if (Convert.ToInt32(Session["EMP_ID"]) == (-1))
            {
                //_obj_Smhr_LoginInfo = new SMHR_LOGINTYPE();
                //rcmb_UserManagerUserGroups.Items.Clear();
                //_obj_Smhr_LoginInfo.OPERATION = operation.Select;
                //_obj_Smhr_LoginInfo.ORGANISATION_ID = 0; //Convert.ToInt32(Session["ORG_ID"]);
                //DataTable dt_usergroup = BLL.get_LoginType(_obj_Smhr_LoginInfo);
                //rcmb_UserManagerUserGroups.DataSource = dt_usergroup;
                //rcmb_UserManagerUserGroups.DataTextField = "LOGTYP_CODE";
                //rcmb_UserManagerUserGroups.DataValueField = "LOGTYP_ID";
                //rcmb_UserManagerUserGroups.DataBind();
                //rcmb_UserManagerUserGroups.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                //rcmb_UserManagerUserGroups.SelectedIndex = rcmb_UserManagerUserGroups.FindItemIndexByValue(dt_usergroup.Rows[0]["LOGTYP_CODE"].ToString());

                SMHR_EMPDISCIPLINARYACTION _obj_Smhr_EmpDisciplinaryAction = new SMHR_EMPDISCIPLINARYACTION();
                _obj_Smhr_EmpDisciplinaryAction.OPERATION = operation.Empty;
                DataTable dt = BLL.get_EmpDiscNotes(_obj_Smhr_EmpDisciplinaryAction);

                rcmb_UserManagersEmployee.Items.Clear();
                rcmb_UserManagersEmployee.DataSource = dt;
                rcmb_UserManagersEmployee.DataTextField = "EMPNAME";
                rcmb_UserManagersEmployee.DataValueField = "EMP_ID";
                rcmb_UserManagersEmployee.DataBind();
                rcmb_UserManagersEmployee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                rcmb_UserManagersEmployee.Enabled = false;

                SMHR_ORGANISATION _obj_Organisation = new SMHR_ORGANISATION();
                _obj_Organisation.MODE = 1;
                DataTable dtorg = BLL.get_Organisation(_obj_Organisation);
                rcmb_Organisation.DataSource = dtorg;
                rcmb_Organisation.DataTextField = "ORGANISATION_NAME";
                rcmb_Organisation.DataValueField = "ORGANISATION_ID";
                rcmb_Organisation.DataBind();
                rcmb_Organisation.Items.Insert(0, new RadComboBoxItem("Select"));
            }
            else
            {

                _obj_Smhr_LoginInfo = new SMHR_LOGINTYPE();
                rcmb_UserManagerUserGroups.Items.Clear();
                _obj_Smhr_LoginInfo.OPERATION = operation.Select;
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                rcmb_UserManagerUserGroups.DataSource = BLL.get_LoginType(_obj_Smhr_LoginInfo);
                rcmb_UserManagerUserGroups.DataTextField = "LOGTYP_CODE";
                rcmb_UserManagerUserGroups.DataValueField = "LOGTYP_ID";
                rcmb_UserManagerUserGroups.DataBind();
                rcmb_UserManagerUserGroups.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

                SMHR_EMPDISCIPLINARYACTION _obj_Smhr_EmpDisciplinaryAction = new SMHR_EMPDISCIPLINARYACTION();
                _obj_Smhr_EmpDisciplinaryAction.OPERATION = operation.Empty;
                _obj_Smhr_EmpDisciplinaryAction.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt = BLL.get_EmpDiscNotes(_obj_Smhr_EmpDisciplinaryAction);

                rcmb_UserManagersEmployee.Items.Clear();
                rcmb_UserManagersEmployee.DataSource = dt;
                rcmb_UserManagersEmployee.DataTextField = "EMPNAME";
                rcmb_UserManagersEmployee.DataValueField = "EMP_ID";
                rcmb_UserManagersEmployee.DataBind();
                rcmb_UserManagersEmployee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                rcmb_UserManagersEmployee.Enabled = false;

                //SMHR_ORGANISATION _obj_Organisation = new SMHR_ORGANISATION();
                //_obj_Organisation.MODE = 1;
                //DataTable dtorg = BLL.get_Organisation(_obj_Organisation);
                //rcmb_Organisation.DataSource = dtorg;
                //rcmb_Organisation.DataTextField = "ORGANISATION_NAME";
                //rcmb_Organisation.DataValueField = "ORGANISATION_ID";
                //rcmb_Organisation.DataBind();
                //rcmb_Organisation.Items.Insert(0, new RadComboBoxItem("Select"));

                _obj_LoginInfo = new SMHR_LOGININFO();
                _obj_LoginInfo.OPERATION = operation.Login1;
                _obj_LoginInfo.LOGIN_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_logindetails = BLL.get_Logindetails(_obj_LoginInfo);
                rcmb_Organisation.DataSource = dt_logindetails;
                rcmb_Organisation.DataTextField = "organisation_name";
                rcmb_Organisation.DataValueField = "organisation_id";
                rcmb_Organisation.DataBind();
                //rcmb_Organisation.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                rcmb_Organisation.SelectedIndex = rcmb_Organisation.FindItemIndexByValue(dt_logindetails.Rows[0]["ORGANISATION_NAME"].ToString());

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Users", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void LoadEmployees()
    {
        try
        {
            if (Convert.ToInt32(Session["EMP_ID"]) == (-1))
            {
                SMHR_EMPDISCIPLINARYACTION _obj_Smhr_EmpDisciplinaryAction = new SMHR_EMPDISCIPLINARYACTION();
                _obj_Smhr_EmpDisciplinaryAction.OPERATION = operation.FILLEMP_Edit;
                DataTable dt = BLL.get_EmpDiscNotes(_obj_Smhr_EmpDisciplinaryAction);

                rcmb_UserManagersEmployee.Items.Clear();
                rcmb_UserManagersEmployee.DataSource = dt;
                rcmb_UserManagersEmployee.DataTextField = "EMPNAME";
                rcmb_UserManagersEmployee.DataValueField = "EMP_ID";
                rcmb_UserManagersEmployee.DataBind();
                rcmb_UserManagersEmployee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                rcmb_UserManagersEmployee.Enabled = false;
            }
            else
            {
                SMHR_EMPDISCIPLINARYACTION _obj_Smhr_EmpDisciplinaryAction = new SMHR_EMPDISCIPLINARYACTION();
                _obj_Smhr_EmpDisciplinaryAction.OPERATION = operation.FILLEMP_Edit;
                _obj_Smhr_EmpDisciplinaryAction.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt = BLL.get_EmpDiscNotes(_obj_Smhr_EmpDisciplinaryAction);

                rcmb_UserManagersEmployee.Items.Clear();
                rcmb_UserManagersEmployee.DataSource = dt;
                rcmb_UserManagersEmployee.DataTextField = "EMPNAME";
                rcmb_UserManagersEmployee.DataValueField = "EMP_ID";
                rcmb_UserManagersEmployee.DataBind();
                rcmb_UserManagersEmployee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                rcmb_UserManagersEmployee.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Users", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToInt32(rcmb_UserManagersEmployee.SelectedItem.Value) > 0 && rtxt_UserManagerEmail.Text == string.Empty)
            {
                ViewState["PASSCODE"] = txt_PassCode.Text;
                ViewState["PASSWORD"] = rtxt_UserManagerPassword.Text;
                txt_PassCode.Attributes.Add("value", Convert.ToString(ViewState["PASSCODE"]));
                rtxt_UserManagerPassword.Attributes.Add("value", Convert.ToString(ViewState["PASSWORD"]));
                BLL.ShowMessage(this, "Please enter Email ID for this Employee in Employee screen");
                return;
            }
            if ((rcmb_UserManagersEmployee.SelectedItem.Text == "Select") && rtxt_UserManagerEmail.Text == string.Empty)
            {
                ViewState["PASSCODE"] = txt_PassCode.Text;
                ViewState["PASSWORD"] = rtxt_UserManagerPassword.Text;
                txt_PassCode.Attributes.Add("value", Convert.ToString(ViewState["PASSCODE"]));
                rtxt_UserManagerPassword.Attributes.Add("value", Convert.ToString(ViewState["PASSWORD"]));
                BLL.ShowMessage(this, "Please Enter Email ID");
                return;
            }
            if (rtxt_UserManagerPassword.Text.Length < 4 || rtxt_UserManagerPassword.Text.Length > 14)
            {
                BLL.ShowMessage(this, "Password Length Should be Minimum 4 & Maximum 14 Characters.");
                return;
            }
            if (txt_PassCode.Text.Length < 4 || txt_PassCode.Text.Length > 14)
            {
                BLL.ShowMessage(this, "PassCode Length Should be Minimum 4 & Maximum 14 Characters.");
                return;
            }
            if (Convert.ToInt32(Session["EMP_ID"]) != (-1))
            {
                StringBuilder sb = new StringBuilder();
                IList<RadListBoxItem> collection = rlst_BusinessUnit.Items;
                if (collection.Count != 0)
                {

                    SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();
                    //_obj_Smhr_LoginInfo.OPERATION = operation.CheckEmp;
                    //_obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    //_obj_Smhr_LoginInfo.LOGIN_EMP_ID = Convert.ToInt32(rcmb_UserManagersEmployee.SelectedItem.Value);
                    //DataTable dt_emp1 = new DataTable();
                    //dt_emp1 = BLL.get_emp(_obj_Smhr_LoginInfo);
                    //if (Convert.ToInt32(dt_emp1.Rows[0]["count"]) == 0)
                    //{ 
                    _obj_Smhr_LoginInfo.LOGIN_EMP_ID = Convert.ToInt32(rcmb_UserManagersEmployee.SelectedItem.Value);
                    _obj_Smhr_LoginInfo.LOGIN_TYPE = Convert.ToInt32(rcmb_UserManagerUserGroups.SelectedItem.Value);
                    _obj_Smhr_LoginInfo.LOGIN_USERNAME = BLL.ReplaceQuote(rtxt_UserManagerUserName.Text);
                    _obj_Smhr_LoginInfo.LOGIN_PASSWORD = BLL.PasswordEncrypt(BLL.ReplaceQuote(rtxt_UserManagerPassword.Text));
                    _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = BLL.PasswordEncrypt(BLL.ReplaceQuote(txt_PassCode.Text));
                    _obj_Smhr_LoginInfo.LOGIN_EMAILID = BLL.ReplaceQuote(rtxt_UserManagerEmail.Text);
                    //_obj_Smhr_LoginInfo.LOGIN_STATUS = chk_UserManagerStatus.Checked;

                    if (rcmb_UserManagerStatus.SelectedValue == "1")
                        _obj_Smhr_LoginInfo.LOGIN_STATUS = true;
                    else
                        _obj_Smhr_LoginInfo.LOGIN_STATUS = false;
                    _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(rcmb_Organisation.SelectedValue);
                    _obj_Smhr_LoginInfo.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                    _obj_Smhr_LoginInfo.CREATEDDATE = DateTime.Now;

                    _obj_Smhr_LoginInfo.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                    _obj_Smhr_LoginInfo.LASTMDFDATE = DateTime.Now;

                    string str = string.Empty;

                    foreach (RadListBoxItem item in rlst_BusinessUnit.Items)
                    {
                        str += item.Value + ",";
                    }
                    if (str.Length > 0)
                    {
                        str = str.Remove(str.Length - 1, 1);
                    }

                    _obj_Smhr_LoginInfo.LOGIN_BUSINESSUNITID = str;


                    switch (((Button)sender).ID.ToUpper())
                    {
                        case "BTN_UPDATE":
                            _obj_Smhr_LoginInfo.LOGIN_ID = Convert.ToInt32(lbl_UserManagerID.Text);
                            _obj_Smhr_LoginInfo.OPERATION = operation.Check;
                            _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            if (Convert.ToString(BLL.get_LoginInfo(_obj_Smhr_LoginInfo).Rows[0]["Count"]) != "0")
                            {
                                BLL.ShowMessage(this, "User Name Already Exists");
                                return;
                            }
                            _obj_Smhr_LoginInfo.OPERATION = operation.Update;
                            _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(rcmb_Organisation.SelectedValue);
                            if (BLL.set_LoginInfo(_obj_Smhr_LoginInfo))
                                BLL.ShowMessage(this, "Information Updated Successfully");
                            else
                                BLL.ShowMessage(this, "Information Not Updated");

                            break;
                        case "BTN_SAVE":
                            _obj_Smhr_LoginInfo.OPERATION = operation.Check;
                            _obj_Smhr_LoginInfo.ORGANISATION_ID = 0;
                            if (Convert.ToString(BLL.get_LoginInfo(_obj_Smhr_LoginInfo).Rows[0]["Count"]) != "0")
                            {
                                BLL.ShowMessage(this, "User Name already Exists");
                                return;
                            }
                            _obj_Smhr_LoginInfo.OPERATION = operation.CheckEmp;
                            _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Smhr_LoginInfo.LOGIN_EMP_ID = Convert.ToInt32(rcmb_UserManagersEmployee.SelectedItem.Value);
                            DataTable dt_emp = new DataTable();
                            dt_emp = BLL.get_emp(_obj_Smhr_LoginInfo);
                            if (Convert.ToInt32(dt_emp.Rows[0]["count"]) == 0)
                            {
                                _obj_Smhr_LoginInfo.OPERATION = operation.Insert;
                                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(rcmb_Organisation.SelectedValue);
                                if (BLL.set_LoginInfo(_obj_Smhr_LoginInfo))
                                    BLL.ShowMessage(this, "Information Saved Successfully");
                                else
                                    BLL.ShowMessage(this, "Information Not Saved");

                            }
                            else
                            {
                                BLL.ShowMessage(this, "Selected Employee is already assigned");
                                return;
                            }
                            break;

                        default:
                            break;
                    }
                    Rm_UM_page.SelectedIndex = 0;
                    LoadGrid();
                    Rg_UserManager.DataBind();
                    //}
                    //else
                    //{
                    //    BLL.ShowMessage(this, "Selected Employee is already assigned");
                    //    return;
                    //}
                }
                else
                {
                    BLL.ShowMessage(this, "Please Add Business Unit");
                    DataTable dt = ViewState["dt"] as DataTable;
                    //string strPass = BLL.PasswordDecrypt(Convert.ToString(dt.Rows[0]["LOGIN_PASSWORD"]));
                    //string strPass1 = BLL.PasswordDecrypt(Convert.ToString(dt.Rows[0]["LOGIN_PASS_CODE"]));
                    ViewState["PASSCODE"] = txt_PassCode.Text;
                    ViewState["PASSWORD"] = rtxt_UserManagerPassword.Text;
                    txt_PassCode.Attributes.Add("value", Convert.ToString(ViewState["PASSCODE"]));
                    rtxt_UserManagerPassword.Attributes.Add("value", Convert.ToString(ViewState["PASSWORD"]));
                    //string strPass = Convert.ToString(dt.Rows[0]["LOGIN_PASSWORD"]);
                    //rtxt_UserManagerPassword.Attributes.Add("value", strPass);
                    //txt_PassCode.Attributes.Add("value", strPass1);
                }

            }
            else
            {
                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();
                _obj_Smhr_LoginInfo.LOGIN_EMP_ID = Convert.ToInt32(rcmb_UserManagersEmployee.SelectedItem.Value);
                _obj_Smhr_LoginInfo.LOGIN_TYPE = Convert.ToInt32(rcmb_UserManagerUserGroups.SelectedItem.Value);
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = BLL.ReplaceQuote(rtxt_UserManagerUserName.Text);
                _obj_Smhr_LoginInfo.LOGIN_PASSWORD = BLL.PasswordEncrypt(BLL.ReplaceQuote(rtxt_UserManagerPassword.Text));
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = BLL.PasswordEncrypt(BLL.ReplaceQuote(txt_PassCode.Text));
                _obj_Smhr_LoginInfo.LOGIN_EMAILID = BLL.ReplaceQuote(rtxt_UserManagerEmail.Text);
                //_obj_Smhr_LoginInfo.LOGIN_STATUS = chk_UserManagerStatus.Checked;

                if (rcmb_UserManagerStatus.SelectedValue == "1")
                    _obj_Smhr_LoginInfo.LOGIN_STATUS = true;
                else
                    _obj_Smhr_LoginInfo.LOGIN_STATUS = false;
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(rcmb_Organisation.SelectedValue);
                _obj_Smhr_LoginInfo.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                _obj_Smhr_LoginInfo.CREATEDDATE = DateTime.Now;

                _obj_Smhr_LoginInfo.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                _obj_Smhr_LoginInfo.LASTMDFDATE = DateTime.Now;

                string str = string.Empty;

                foreach (RadListBoxItem item in rlst_BusinessUnit.Items)
                {
                    str += item.Value + ",";
                }
                if (str.Length > 0)
                {
                    str = str.Remove(str.Length - 1, 1);
                }

                _obj_Smhr_LoginInfo.LOGIN_BUSINESSUNITID = str;


                switch (((Button)sender).ID.ToUpper())
                {
                    case "BTN_UPDATE":
                        _obj_Smhr_LoginInfo.LOGIN_ID = Convert.ToInt32(lbl_UserManagerID.Text);
                        _obj_Smhr_LoginInfo.OPERATION = operation.Check;
                        _obj_Smhr_LoginInfo.ORGANISATION_ID = 0;
                        if (Convert.ToString(BLL.get_LoginInfo(_obj_Smhr_LoginInfo).Rows[0]["Count"]) != "0")
                        {
                            BLL.ShowMessage(this, "User Name Already Exists");
                            return;
                        }
                        _obj_Smhr_LoginInfo.OPERATION = operation.Update;
                        _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(rcmb_Organisation.SelectedValue);
                        if (BLL.set_LoginInfo(_obj_Smhr_LoginInfo))
                            BLL.ShowMessage(this, "Information Saved Successfully");
                        else
                            BLL.ShowMessage(this, "Information Not Saved");

                        break;
                    case "BTN_SAVE":
                        _obj_Smhr_LoginInfo.OPERATION = operation.Check;
                        _obj_Smhr_LoginInfo.ORGANISATION_ID = 0;
                        if (Convert.ToString(BLL.get_LoginInfo(_obj_Smhr_LoginInfo).Rows[0]["Count"]) != "0")
                        {
                            BLL.ShowMessage(this, "User Name already Exists");
                            return;
                        }
                        _obj_Smhr_LoginInfo.OPERATION = operation.Insert;
                        _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(rcmb_Organisation.SelectedValue);
                        if (BLL.set_LoginInfo(_obj_Smhr_LoginInfo))
                            BLL.ShowMessage(this, "Information Saved Successfully");
                        else
                            BLL.ShowMessage(this, "Information Not Saved");
                        break;
                    default:
                        break;
                }
                Rm_UM_page.SelectedIndex = 0;
                LoadGrid();
                Rg_UserManager.DataBind();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Users", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void clearControls()
    {
        lbl_UserManagerID.Text = string.Empty;
        rcmb_UserManagersEmployee.SelectedIndex = -1;
        rcmb_UserManagerUserGroups.SelectedIndex = -1;
        rtxt_UserManagerUserName.Text = string.Empty;
        rtxt_UserManagerPassword.Text = string.Empty;
        rtxt_UserManagerEmail.Text = string.Empty;
        rlst_BusinessUnit.Items.Clear();
        //chk_UserManagerStatus.Checked = false;
        rtxt_UserManagerPassword.Text = string.Empty;
        rcmb_UserManagerStatus.SelectedValue = "1";
        btn_Save.Visible = false;
        btn_Update.Visible = false;
        Rm_UM_page.SelectedIndex = 0;
        ViewState["PASSCODE"] = "";
        ViewState["PASSWORD"] = "";
        txt_PassCode.Attributes.Add("value", "");
        rtxt_UserManagerPassword.Attributes.Add("value", "");
        rcmb_Organisation.Enabled = true;
        rcmb_UserManagersEmployee.Enabled = false;
        rcmb_UserManagerUserGroups.Enabled = true;
        rtxt_UserManagerUserName.Enabled = true;
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Users", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Rg_UserManager_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        LoadGrid();
    }

    protected void btn_AddBusinessUnit_Click(object sender, EventArgs e)
    {
        try
        {
            ViewState["PASSCODE"] = txt_PassCode.Text;
            ViewState["PASSWORD"] = rtxt_UserManagerPassword.Text;
            if (rcmb_UserManagerBusinessUnit.SelectedItem.Value != "0")
            {
                rlst_BusinessUnit.Items.Add(new Telerik.Web.UI.RadListBoxItem(rcmb_UserManagerBusinessUnit.SelectedItem.Text, rcmb_UserManagerBusinessUnit.SelectedItem.Value));
                LoadBusinessUnit();
            }
            txt_PassCode.Attributes.Add("value", Convert.ToString(ViewState["PASSCODE"]));
            rtxt_UserManagerPassword.Attributes.Add("value", Convert.ToString(ViewState["PASSWORD"]));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Users", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void LoadBusinessUnit()
    {
        try
        {
            if (Convert.ToInt32(Session["EMP_ID"]) != (-1))
            {
                _obj_businessunit = new SMHR_BUSINESSUNIT();
                _obj_businessunit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_businessunit.OPERATION = operation.Select;
                DataTable dt_bus = BLL.get_BusinessUnit(_obj_businessunit);

                string str = string.Empty;

                foreach (RadListBoxItem item in rlst_BusinessUnit.Items)
                {
                    str += item.Value + ",";
                }
                if (str.Length > 0)
                {
                    str = str.Remove(str.Length - 1, 1);
                    dt_bus.DefaultView.RowFilter = " BUSINESSUNIT_ID not in (" + str + ")";
                    dt_bus = dt_bus.DefaultView.ToTable();
                }

                rcmb_UserManagerBusinessUnit.Items.Clear();
                rcmb_UserManagerBusinessUnit.DataSource = dt_bus;
                rcmb_UserManagerBusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
                rcmb_UserManagerBusinessUnit.DataValueField = "BUSINESSUNIT_ID";
                rcmb_UserManagerBusinessUnit.DataBind();
                rcmb_UserManagerBusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            }
            else
            {
                if (rcmb_Organisation.SelectedItem.Text != "Select")
                {
                    _obj_businessunit = new SMHR_BUSINESSUNIT();
                    _obj_businessunit.ORGANISATION_ID = Convert.ToInt32(rcmb_Organisation.SelectedItem.Value);// Convert.ToInt32(Session["ORG_ID"]);
                    _obj_businessunit.OPERATION = operation.Select;
                    DataTable dt_bus = BLL.get_BusinessUnit(_obj_businessunit);

                    string str = string.Empty;

                    foreach (RadListBoxItem item in rlst_BusinessUnit.Items)
                    {
                        str += item.Value + ",";
                    }
                    if (str.Length > 0)
                    {
                        str = str.Remove(str.Length - 1, 1);
                        dt_bus.DefaultView.RowFilter = " BUSINESSUNIT_ID not in (" + str + ")";
                        dt_bus = dt_bus.DefaultView.ToTable();
                    }

                    rcmb_UserManagerBusinessUnit.Items.Clear();
                    rcmb_UserManagerBusinessUnit.DataSource = dt_bus;
                    rcmb_UserManagerBusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
                    rcmb_UserManagerBusinessUnit.DataValueField = "BUSINESSUNIT_ID";
                    rcmb_UserManagerBusinessUnit.DataBind();
                    rcmb_UserManagerBusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                }
                else
                {
                    DataTable dt_bus = new DataTable();
                    rcmb_UserManagerBusinessUnit.Items.Clear();
                    rcmb_UserManagerBusinessUnit.DataSource = dt_bus;
                    rcmb_UserManagerBusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
                    rcmb_UserManagerBusinessUnit.DataValueField = "BUSINESSUNIT_ID";
                    rcmb_UserManagerBusinessUnit.DataBind();
                    rcmb_UserManagerBusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Users", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rlst_BusinessUnit_Deleted(object sender, RadListBoxEventArgs e)
    {
        LoadBusinessUnit();
    }

    protected void rcmb_Organisation_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            LoadBusinessUnit();
            _obj_Smhr_LoginInfo = new SMHR_LOGINTYPE();
            rcmb_UserManagerUserGroups.Items.Clear();
            _obj_Smhr_LoginInfo.OPERATION = operation.Select;
            _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(rcmb_Organisation.SelectedItem.Value); //Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_usergroup = BLL.get_LoginType(_obj_Smhr_LoginInfo);
            rcmb_UserManagerUserGroups.DataSource = dt_usergroup;
            rcmb_UserManagerUserGroups.DataTextField = "LOGTYP_CODE";
            rcmb_UserManagerUserGroups.DataValueField = "LOGTYP_ID";
            rcmb_UserManagerUserGroups.DataBind();
            rcmb_UserManagerUserGroups.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            //rcmb_UserManagerUserGroups.SelectedIndex = rcmb_UserManagerUserGroups.FindItemIndexByValue(dt_usergroup.Rows[0]["LOGTYP_CODE"].ToString());
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Users", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_UserManagersEmployee_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();
            _obj_Smhr_LoginInfo.OPERATION = operation.Select_New;
            _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_LoginInfo.LOGIN_EMP_ID = Convert.ToInt32(rcmb_UserManagersEmployee.SelectedItem.Value);
            DataTable dt = BLL.get_emp(_obj_Smhr_LoginInfo);
            if (Convert.ToInt32(rcmb_UserManagersEmployee.SelectedItem.Value) > 0)
            {
                if (dt.Rows.Count > 0 && dt.Rows[0]["EMP_EMAILID"] != System.DBNull.Value)
                {
                    rtxt_UserManagerEmail.Text = Convert.ToString(dt.Rows[0]["EMP_EMAILID"]);
                }
                else
                {
                    rtxt_UserManagerEmail.Text = string.Empty;
                }
                rtxt_UserManagerEmail.Enabled = false;
            }
            else
            {
                rtxt_UserManagerEmail.Enabled = true;
                rtxt_UserManagerEmail.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Users", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rtsAuditDetails_TabClick(object sender, RadTabStripEventArgs e)
    {
        try
        {
            if (rtsAuditDetails.SelectedTab.Value == "MainScreenTab")
                rmpAuditDetails.SelectedIndex = 0;

            if (rtsAuditDetails.SelectedTab.Value == "AuditScreenTab")
            {
                rmpAuditDetails.SelectedIndex = 1;

                LoadAuditGrid();
                rgAudit.DataBind();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "AuditOrganisation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rgAudit_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadAuditGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "AuditOrganisation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void LoadAuditGrid()
    {
        try
        {
            //rgAudit.DataSource = BLL.ExecuteQuery("EXEC USP_SMHR_AUDITTRAILS @OPERATION = 'GET_AUDIT_DATA', @SMHR_AUDIT_FORM_ID = 160");
            //rgAudit.Visible = true;
            DataTable dtGrid = BLL.ExecuteQuery("EXEC USP_SMHR_AUDITTRAILS @OPERATION = 'GET_AUDIT_DATA', @SMHR_AUDIT_FORM_ID = 160");

            DataTable dtGridNew = new DataTable();
            DataRow drGrid = null;

            if (dtGrid.Rows.Count > 0)
            {
                dtGridNew.Columns.Add(new DataColumn("SMHR_AUDIT_ID", typeof(string)));
                dtGridNew.Columns.Add(new DataColumn("EMP_NAME", typeof(string)));
                dtGridNew.Columns.Add(new DataColumn("LOGIN_USERNAME", typeof(string)));
                dtGridNew.Columns.Add(new DataColumn("LOGTYP_CODE", typeof(string)));
                dtGridNew.Columns.Add(new DataColumn("FORMS_NAME", typeof(string)));
                dtGridNew.Columns.Add(new DataColumn("SMHR_AUDIT_COLUMN", typeof(string)));
                dtGridNew.Columns.Add(new DataColumn("SMHR_AUDIT_TRANSACTIONDESC", typeof(string)));
                dtGridNew.Columns.Add(new DataColumn("SMHR_AUDIT_OLDVALUE", typeof(string)));
                dtGridNew.Columns.Add(new DataColumn("SMHR_AUDIT_NEWVALUE", typeof(string)));
                dtGridNew.Columns.Add(new DataColumn("DATE", typeof(string)));
                dtGridNew.Columns.Add(new DataColumn("SMHR_AUDIT_CONTROL_COLUMN", typeof(string)));

                for (int i = 0; i < dtGrid.Rows.Count; i++)
                {
                    drGrid = dtGridNew.NewRow();

                    drGrid["SMHR_AUDIT_ID"] = Convert.ToString(dtGrid.Rows[i]["SMHR_AUDIT_ID"]);
                    drGrid["EMP_NAME"] = Convert.ToString(dtGrid.Rows[i]["EMP_NAME"]);
                    drGrid["LOGIN_USERNAME"] = Convert.ToString(dtGrid.Rows[i]["LOGIN_USERNAME"]);
                    drGrid["LOGTYP_CODE"] = Convert.ToString(dtGrid.Rows[i]["LOGTYP_CODE"]);
                    drGrid["FORMS_NAME"] = Convert.ToString(dtGrid.Rows[i]["FORMS_NAME"]);
                    drGrid["SMHR_AUDIT_COLUMN"] = Convert.ToString(dtGrid.Rows[i]["SMHR_AUDIT_COLUMN"]);
                    drGrid["SMHR_AUDIT_TRANSACTIONDESC"] = Convert.ToString(dtGrid.Rows[i]["SMHR_AUDIT_TRANSACTIONDESC"]);
                    if ((Convert.ToString(dtGrid.Rows[i]["SMHR_AUDIT_COLUMN"]) == "LOGIN_PASSWORD") ||
                        (Convert.ToString(dtGrid.Rows[i]["SMHR_AUDIT_COLUMN"]) == "LOGIN_PASS_CODE"))
                    {
                        drGrid["SMHR_AUDIT_OLDVALUE"] = Convert.ToString(pwdEncrypt.PasswordDecrypt(Convert.ToString(dtGrid.Rows[i]["SMHR_AUDIT_OLDVALUE"])));
                        drGrid["SMHR_AUDIT_NEWVALUE"] = Convert.ToString(pwdEncrypt.PasswordDecrypt(Convert.ToString(dtGrid.Rows[i]["SMHR_AUDIT_NEWVALUE"])));
                    }
                    else
                    {
                        drGrid["SMHR_AUDIT_OLDVALUE"] = Convert.ToString(dtGrid.Rows[i]["SMHR_AUDIT_OLDVALUE"]);
                        drGrid["SMHR_AUDIT_NEWVALUE"] = Convert.ToString(dtGrid.Rows[i]["SMHR_AUDIT_NEWVALUE"]);
                    }
                    drGrid["DATE"] = Convert.ToString(dtGrid.Rows[i]["DATE"]);
                    drGrid["SMHR_AUDIT_CONTROL_COLUMN"] = Convert.ToString(dtGrid.Rows[i]["SMHR_AUDIT_CONTROL_COLUMN"]);

                    dtGridNew.Rows.Add(drGrid);
                }
            }

            rgAudit.DataSource = dtGridNew;
            rgAudit.Visible = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "AuditOrganisation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}