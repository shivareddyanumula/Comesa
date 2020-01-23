using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using Telerik.Web.UI;
using System.Data;


public partial class Masters_frm_organisation : System.Web.UI.Page
{
    SMHR_ORGANISATION _obj_smhr_organisation;
    int count = 0;

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {




            if (!Page.IsPostBack)
            {

                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Organisation ");//COUNTRY");
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
                    Rg_Organisation.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Save.Visible = false;
                    //btn_Update.Visible = false;
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
                lbl_ORganisationID.Text = "";
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_organisation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            chk_empcode_manual.Enabled = true;
            chk_empcode_manual.Checked = false;
            //  chk_Variableamt.Checked = false;
            if (Convert.ToInt32(Session["EMP_ID"]) < 0)
            {
                lbl_Employees.Enabled = true;
                txt_Employees.Enabled = true;
                lbl_Applicant.Enabled = true;
                rntxt_Applicant.Enabled = true;
            }
            else
            {
                lbl_Employees.Visible = false;
                txt_Employees.Visible = false;
                lbl_Applicant.Visible = false;
                rntxt_Applicant.Visible = false;
            }
            ClearControls();
            LoadPackage();
            rtxt_OrganisationName.Enabled = true;
            btn_Save.Visible = true;
            RM_OG_page.SelectedIndex = 1;
            MinPercentage.Visible = false;
            MaxPercentage.Visible = false;
            temp.Value = 0;
            rntxt_zeros.Enabled = true;
            rntxt_zeros.Text = string.Empty;
            tr_noofzeros.Visible = true;
            ViewState["NOOFZEROS"] = null;
            //new added for applicant count
            rntxt_Applicant_Temp.Value = 0;
            btn_Save.Text = "Save";
            // chk_AnnualProcess.Checked = false;
            chk_Integration.Checked = false;
            chk_SmartOpsIntegration.Checked = false;
            Page.Validate();

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_organisation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void LoadMainGrid()
    {
        try
        {
            SMHR_ORGANISATION _obj_smhr_organisation = new SMHR_ORGANISATION();
            _obj_smhr_organisation.MODE = 1;
            Rg_Organisation.DataSource = BLL.get_Organisation(_obj_smhr_organisation);
            RM_OG_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_organisation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void ClearControls()
    {
        try
        {
            rtxt_OrganisationName.Text = string.Empty;
            rtxt_OrganisationDesc.Text = string.Empty;
            rtxt_Address1.Text = string.Empty;
            rtxt_Address1.Text = string.Empty;
            rtxt_Address2.Text = string.Empty;
            rtxtPINNumber.Text = string.Empty;
            rtxtPostBoxNo.Text = string.Empty;
            rtxtFax.Text = string.Empty;
            rtxt_ContactPerson.Text = string.Empty;
            rtxt_Cphone.Text = string.Empty;
            rtxt_URL.Text = string.Empty;
            txt_Email.Text = string.Empty;
            txt_Employees.Value = null;
            radNSSF.Text = string.Empty;
            radNHIF.Text = string.Empty;
            radVAT.Text = string.Empty;
            radaletrnateemail.Text = string.Empty;
            //new added for applicant count
            rntxt_Applicant.Value = null;
            txt_PhoneNumber.Text = string.Empty;
            rntxt_zeros.Text = string.Empty;
            // chk_AnnualProcess.Checked = false;
            chk_Integration.Checked = false;
            chk_SmartOpsIntegration.Checked = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_organisation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadPackage()
    {
        try
        {
            _obj_smhr_organisation = new SMHR_ORGANISATION();
            _obj_smhr_organisation.MODE = 7;
            rcb_Package.Items.Clear();
            DataTable dt = BLL.get_Package(_obj_smhr_organisation);
            ViewState["Package"] = dt;
            rcb_Package.DataSource = dt;
            rcb_Package.DataTextField = "smhr_Package_name";
            rcb_Package.DataValueField = "smhr_package_id";
            rcb_Package.DataBind();
            //rcb_Package.Items.Insert(0, new RadComboBoxItem("Select"));
            rcb_Package.SelectedIndex = rcb_Package.FindItemIndexByValue(dt.Rows[1]["smhr_package_id"].ToString());
            rcb_Package.Enabled = false;
            //To load super modules 
            _obj_smhr_organisation = new SMHR_ORGANISATION();
            _obj_smhr_organisation.MODE = 9;
            chklst_sup_module.Items.Clear();
            chklst_sup_module.DataSource = BLL.get_Package(_obj_smhr_organisation);
            chklst_sup_module.DataTextField = "SMHR_SUP_MODULE_NAME";
            chklst_sup_module.DataValueField = "SMHR_SUP_MODULE_ID";
            chklst_sup_module.DataBind();
            chklst_sup_module.Items[0].Enabled = false;
            chklst_sup_module.Items[0].Selected = true;

        }
        catch (Exception ex)
        {

            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_organisation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rg_Organisation_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadMainGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_organisation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_smhr_organisation = new SMHR_ORGANISATION();
            _obj_smhr_organisation.MODE = 3;
            _obj_smhr_organisation.ORGANISATION_NAME = rtxt_OrganisationName.Text;
            _obj_smhr_organisation.ORGANISATION_DESC = rtxt_OrganisationDesc.Text;
            _obj_smhr_organisation.ORGANISATION_ADDRESS1 = rtxt_Address1.Text;
            _obj_smhr_organisation.ORGANISATION_ADDRESS2 = rtxt_Address2.Text;
            _obj_smhr_organisation.ORGANISATION_PIN = rtxtPINNumber.Text.Trim();
            _obj_smhr_organisation.ORGANISATION_POSTBOXNO = rtxtPostBoxNo.Text.Trim();
            _obj_smhr_organisation.ORGANISATION_FAX = rtxtFax.Text.Trim();
            _obj_smhr_organisation.ORGANISATION_PHONE1 = txt_PhoneNumber.Text;
            _obj_smhr_organisation.ORGANISATION_PHONE2 = rtxt_Cphone.Text;
            _obj_smhr_organisation.ORGANISATION_EMAIL = txt_Email.Text;
            _obj_smhr_organisation.ORGANISATION_WEBSITE = rtxt_URL.Text;
            _obj_smhr_organisation.ORGANISATION_CONTACTPERSON = rtxt_ContactPerson.Text;
            _obj_smhr_organisation.ORGANISATION_PACKAGE_ID = Convert.ToInt32(rcb_Package.SelectedItem.Value);
            _obj_smhr_organisation.ORGANISATION_ALTERNATE_EMAIL = radaletrnateemail.Text;
            _obj_smhr_organisation.ORGANISATION_NSSF = radNSSF.Text;
            _obj_smhr_organisation.ORGANISATION_NHIF = radNHIF.Text;
            _obj_smhr_organisation.ORGANISATION_VAT = radVAT.Text;
            //string strVal = BLL.PasswordEncrypt(Convert.ToString(Convert.ToDouble(txt_Employees.Value)));
            //_obj_smhr_organisation.ORGANISATION_EMPLOYEES1 = strVal;
            ////_obj_smhr_organisation.ORGANISATION_EMPLOYEES1 = Convert.ToDouble(txt_Employees.Value);

            if (Convert.ToString(txt_Employees.Value) == "0")
            {
                _obj_smhr_organisation.ORGANISATION_EMPLOYEES1 = Convert.ToString(0);
            }
            else
            {
                string strVal = BLL.PasswordEncrypt(Convert.ToString(Convert.ToDouble(txt_Employees.Value)));
                _obj_smhr_organisation.ORGANISATION_EMPLOYEES1 = strVal;
                //_obj_smhr_organisation.ORGANISATION_EMPLOYEES1 = Convert.ToDouble(txt_Employees.Value);
            }
            if (Convert.ToString(rntxt_Applicant.Value) == "0")
            {
                _obj_smhr_organisation.ORGANISATION_APPLICANTS1 = Convert.ToString(0);
            }
            else
            {
                //new added for applicant count
                string strVal_Applicant = BLL.PasswordEncrypt(Convert.ToString(Convert.ToDouble(rntxt_Applicant.Value)));
                _obj_smhr_organisation.ORGANISATION_APPLICANTS1 = strVal_Applicant;
            }
            _obj_smhr_organisation.ORGANISATION_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_organisation.ORGANISATION_CREATEDDATE = DateTime.Now;
            _obj_smhr_organisation.ORGANISATION_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_organisation.ORGANISATION_LASTMDFDATE = DateTime.Now;
            // _obj_smhr_organisation.ORGANISATION_IS_VARIABLEPAY = chk_Variableamt.Checked;

            //_obj_smhr_organisation.ORGANISATION_NOOFZEROS = Convert.ToInt32(rntxt_zeros.Text);
            //if (chk_Variableamt.Checked)
            //{
            //    //if( (Convert.ToDouble(rntxt_MinPercentage.Text) > 0)&&(Convert.ToDouble(rntxt_MaxPercentage.Text)>0))
            //    //{
            //    //    if (Convert.ToDouble(rntxt_MaxPercentage.Text) > Convert.ToDouble(rntxt_MinPercentage.Text))
            //    //    {
            //    //        _obj_smhr_organisation.ORGANISATION_VP_MINPERCENTAGE = Convert.ToInt32(Math.Round(Convert.ToDouble(rntxt_MinPercentage.Text),0));
            //    //        _obj_smhr_organisation.ORGANISATION_VP_MAXPERCENTAGE = Convert.ToInt32(Math.Round(Convert.ToDouble(rntxt_MaxPercentage.Text),0));
            //    //    }
            //    //    else
            //    //    {
            //    //        BLL.ShowMessage(this, "Max Percentage Should Be Greater Than Min Percentage");
            //    //        rntxt_MinPercentage.Text = "";
            //    //        rntxt_MaxPercentage.Text="";
            //    //        return;
            //    //    }

            //    //}
            //    //else
            //    //{
            //    //    BLL.ShowMessage(this, "Enter Valid Variable Percentage");
            //    //    rntxt_MinPercentage.Text = "";
            //    //    rntxt_MaxPercentage.Text = "";
            //    //    return;
            //    //}

            //}
            _obj_smhr_organisation.ORGANISATION_VP_MINPERCENTAGE = 0;
            _obj_smhr_organisation.ORGANISATION_VP_MAXPERCENTAGE = 0;
            //else
            //{
            //    _obj_smhr_organisation.ORGANISATION_VP_MINPERCENTAGE = 0;
            //    _obj_smhr_organisation.ORGANISATION_VP_MAXPERCENTAGE = 0;
            //}
            string str = string.Empty;

            for (int i = 0; i < chklst_sup_module.Items.Count; i++)
            {
                if (chklst_sup_module.Items[i].Selected == true)
                {
                    str += Convert.ToInt32(chklst_sup_module.Items[i].Value) + ",";
                }
            }
            if (str.Length > 0)
            {
                str = str.Remove(str.Length - 1, 1);
            }

            _obj_smhr_organisation.ORG_SUPER_MODULE_ID = str;
            if (chk_empcode_manual.Checked)
            {
                _obj_smhr_organisation.ORG_IS_EMPCODE_MANUAL = true;

            }
            else
            {
                _obj_smhr_organisation.ORG_IS_EMPCODE_MANUAL = false;
                _obj_smhr_organisation.ORGANISATION_NOOFZEROS = Convert.ToInt32(rntxt_zeros.Text);
            }
            //if (chk_AnnualProcess.Checked)
            //    _obj_smhr_organisation.ORGANISATION_ANNUALPROCESS = true;
            //else
            //    _obj_smhr_organisation.ORGANISATION_ANNUALPROCESS = false;
            if (chk_Integration.Checked)
                _obj_smhr_organisation.ORGANISATION_INTEGRATION = true;
            else
                _obj_smhr_organisation.ORGANISATION_INTEGRATION = false;
            if (chk_SmartOpsIntegration.Checked)
                _obj_smhr_organisation.ORGANISATION_SMOPS_INTEGRATION = true;
            else
                _obj_smhr_organisation.ORGANISATION_SMOPS_INTEGRATION = false;

            if (!string.IsNullOrEmpty(Convert.ToString(txtErrorNotification.Text)))
            {
                _obj_smhr_organisation.NotificationMails = Convert.ToString(txtErrorNotification.Text).Replace("'", "''");
            }

            switch (((Button)sender).Text.ToUpper())
            {
                case "SAVE":
                    _obj_smhr_organisation.MODE = 6;
                    if (Convert.ToString(BLL.get_Organisation(_obj_smhr_organisation).Rows[0][0]) != "0")
                    {
                        BLL.ShowMessage(this, "Organisation with this Name Already Exists");
                        return;
                    }
                    _obj_smhr_organisation.MODE = 3;
                    if (BLL.set_Organisation(_obj_smhr_organisation))
                    {
                        BLL.ShowMessage(this, "Organisation created Successfully");
                    }
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;

                case "UPDATE":

                    _obj_smhr_organisation.ORGANISATION_ID = Convert.ToInt32(lbl_ORganisationID.Text);
                    _obj_smhr_organisation.MODE = 4;
                    if (BLL.set_Organisation(_obj_smhr_organisation))
                    {
                        BLL.ShowMessage(this, "Organisation updated Successfully");
                    }
                    else
                        BLL.ShowMessage(this, "Organisation Not updated");
                    break;
            }
            RM_OG_page.SelectedIndex = 0;
            LoadMainGrid();
            Rg_Organisation.DataBind();
            btn_Save.Text = "Save";
        }
        catch (Exception ex)
        {

            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_organisation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            RM_OG_page.SelectedIndex = 0;
            btn_Save.Text = "Save";
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_organisation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            chk_empcode_manual.Enabled = false;
            LoadPackage();
            ClearControls();
            Page.Validate();
            _obj_smhr_organisation = new SMHR_ORGANISATION();
            _obj_smhr_organisation.MODE = 2;
            rntxt_zeros.Enabled = false;
            _obj_smhr_organisation.ORGANISATION_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            lbl_ORganisationID.Text = Convert.ToString(e.CommandArgument);
            DataTable dt = BLL.get_Organisation(_obj_smhr_organisation);
            rtxt_OrganisationName.Text = Convert.ToString(dt.Rows[0]["ORGANISATION_NAME"]);
            rtxt_OrganisationDesc.Text = Convert.ToString(dt.Rows[0]["ORGANISATION_DESC"]);
            rtxt_Address1.Text = Convert.ToString(dt.Rows[0]["ORGANISATION_ADDRESS1"]);
            rtxt_Address2.Text = Convert.ToString(dt.Rows[0]["ORGANISATIon_ADDRESS2"]);
            rtxtPINNumber.Text = Convert.ToString(dt.Rows[0]["ORGANISATION_PIN"]);
            rtxtPostBoxNo.Text = Convert.ToString(dt.Rows[0]["ORGANISATION_POSTBOXNO"]);
            rtxtFax.Text = Convert.ToString(dt.Rows[0]["ORGANISATION_FAX"]);
            rcb_Package.SelectedValue = Convert.ToString(dt.Rows[0]["ORGANISATION_PACKAGE_ID"]);
            txt_PhoneNumber.Text = Convert.ToString(dt.Rows[0]["ORGANISATION_PHONE1"]);
            rtxt_Cphone.Text = Convert.ToString(dt.Rows[0]["ORGANISATION_PHONE2"]);
            rntxt_MinPercentage.Text = Convert.ToString(dt.Rows[0]["ORGANISATION_MINPERCENTAGEOFVA"]);
            rntxt_MaxPercentage.Text = Convert.ToString(dt.Rows[0]["ORGANISATION_MAXPERCENTAGEOFVA"]);
            radaletrnateemail.Text = Convert.ToString(dt.Rows[0]["ORGANISATION_ALTERNATEEMAIL"]);
            radNHIF.Text = dt.Rows[0]["ORGANISATION_NHIF"].ToString();
            radNSSF.Text = dt.Rows[0]["ORGANISATION_NSSF"].ToString();
            radVAT.Text = dt.Rows[0]["ORGANISATION_VAT"].ToString();
            //if (Convert.ToString(dt.Rows[0]["ORGANISATION_ISVARIABLEAMOUNT"]) == "True")
            //{
            //    chk_Variableamt.Checked = true;
            //}
            //else
            //{
            //    chk_Variableamt.Checked = false;
            //}
            if (dt.Rows[0]["ORGANISATION_EMPLOYEES"] != "" && dt.Rows[0]["ORGANISATION_EMPLOYEES"] != System.DBNull.Value)
                //temp.Value = Convert.ToDouble(dt.Rows[0]["ORGANISATION_EMPLOYEES"]);
                temp.Value = Convert.ToDouble(BLL.PasswordDecrypt(Convert.ToString(dt.Rows[0]["ORGANISATION_EMPLOYEES"])));
            else
                temp.Value = 0;
            //txt_Employees.Text = Convert.ToString(dt.Rows[0]["ORGANISATION_EMPLOYEES"]);
            txt_Employees.Text = BLL.PasswordDecrypt(Convert.ToString(dt.Rows[0]["ORGANISATION_EMPLOYEES"]));

            //new added for applicant count
            if (dt.Rows[0]["ORGANISATION_APPLICANTS"] != "" && dt.Rows[0]["ORGANISATION_APPLICANTS"] != System.DBNull.Value)
                //temp.Value = Convert.ToDouble(dt.Rows[0]["ORGANISATION_EMPLOYEES"]);
                rntxt_Applicant_Temp.Value = Convert.ToDouble(BLL.PasswordDecrypt(Convert.ToString(dt.Rows[0]["ORGANISATION_APPLICANTS"])));
            else
                rntxt_Applicant_Temp.Value = 0;

            //new addes to get super modules by sravani
            string str = string.Empty;
            str = Convert.ToString(dt.Rows[0]["ORGANISATION_SUPER_MODULES"]);
            foreach (string item in str.Split(new char[] { ',' }))
            {
                if (item != "")
                {
                    for (int i = 0; i < chklst_sup_module.Items.Count; i++)
                    {
                        if (chklst_sup_module.Items[i].Value == item)
                        {
                            chklst_sup_module.Items[i].Selected = true;
                        }
                    }
                }
            }
            if (dt.Rows[0]["ORGANISATION_EMPCODE_MANUAL"] != DBNull.Value)
            {
                if (Convert.ToString(dt.Rows[0]["ORGANISATION_EMPCODE_MANUAL"]) == "True")
                {
                    chk_empcode_manual.Checked = true;
                    tr_noofzeros.Visible = false;
                    chk_empcode_manual.Enabled = false;
                }
                else
                {
                    chk_empcode_manual.Checked = false;
                    tr_noofzeros.Visible = true;
                    chk_empcode_manual.Enabled = true;
                }
            }
            else
            {
                chk_empcode_manual.Checked = false;
                tr_noofzeros.Visible = true;
                chk_empcode_manual.Enabled = true;
            }
            if (dt.Rows[0]["ORGANISATION_INTEGRATION"] != DBNull.Value)
            {
                if (Convert.ToString(dt.Rows[0]["ORGANISATION_INTEGRATION"]) == "True")
                {
                    chk_Integration.Checked = true;
                }
                else
                {
                    chk_Integration.Checked = false;
                }
            }
            else
            {
                chk_Integration.Checked = false;
            }
            if (dt.Rows[0]["ORGANISATION_SMOPS_INTEGRATION"] != DBNull.Value)
            {
                if (Convert.ToString(dt.Rows[0]["ORGANISATION_SMOPS_INTEGRATION"]) == "True")
                {
                    chk_SmartOpsIntegration.Checked = true;
                }
                else
                {
                    chk_SmartOpsIntegration.Checked = false;
                }
            }
            else
            {
                chk_SmartOpsIntegration.Checked = false;
            }
            if (dt.Rows[0]["ORGANISATION_NOOFZEROS"] != DBNull.Value)
            {
                rntxt_zeros.Text = Convert.ToString(dt.Rows[0]["ORGANISATION_NOOFZEROS"]);
                ViewState["NOOFZEROS"] = rntxt_zeros.Text;
                //tr_noofzeros.Visible = true;
            }
            else
            {
                rntxt_zeros.Text = string.Empty;
            }

            //new added for applicant count
            if (Convert.ToString(dt.Rows[0]["ORGANISATION_APPLICANTS"]) != string.Empty)
            {
                rntxt_Applicant.Text = BLL.PasswordDecrypt(Convert.ToString(dt.Rows[0]["ORGANISATION_APPLICANTS"]));
            }
            else
            {
                rntxt_Applicant.Text = null;
            }
            //if (Convert.ToString(dt.Rows[0]["ORGANISATION_ANNUALPROCESS"]) != "")
            //{
            //    if (Convert.ToString(dt.Rows[0]["ORGANISATION_ANNUALPROCESS"]).ToUpper() == "TRUE")
            //    {
            //        chk_AnnualProcess.Checked = true;
            //    }
            //    else
            //    {
            //        chk_AnnualProcess.Checked = false;
            //    }
            //}
            rtxt_URL.Text = Convert.ToString(dt.Rows[0]["ORGANISATION_WEBSITE"]);
            rtxt_ContactPerson.Text = Convert.ToString(dt.Rows[0]["ORGANISATION_CONTACTPERSON"]);
            txt_Email.Text = Convert.ToString(dt.Rows[0]["ORGANISATION_EMAIL"]);
            txtErrorNotification.Text = Convert.ToString(dt.Rows[0]["NotificationMails"]);
            RM_OG_page.SelectedIndex = 1;
            rtxt_OrganisationName.Enabled = false;
            btn_Save.Text = "Update";
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_organisation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //protected void chk_Variableamt_CheckedChanged(object sender, EventArgs e)
    //{
    //    if (chk_Variableamt.Checked)
    //    {
    //        //MinPercentage.Visible = true;
    //        //MaxPercentage.Visible = true;
    //        //rntxt_MaxPercentage.Text = "";
    //        //rntxt_MinPercentage.Text = "";
    //    }
    //    else
    //    {
    //        MinPercentage.Visible = false;
    //        MaxPercentage.Visible = false;
    //        //rntxt_MaxPercentage.Text = "";
    //        //rntxt_MinPercentage.Text = "";
    //    }
    //}

    protected void chklst_sup_module_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //new added by sravani
            string errormsg = "";
            for (int i = 0; i < chklst_sup_module.Items.Count; i++)
            {
                if (chklst_sup_module.Items[i].Selected == true)
                {
                    count++;
                }
            }
            DataTable dt = ViewState["Package"] as DataTable;
            if (count == 11)
            {
                rcb_Package.SelectedIndex = rcb_Package.FindItemIndexByValue(dt.Rows[2]["smhr_package_id"].ToString());
                errormsg = "You have selected Platinum";
            }
            else if (count == 2 || count <= 11)
            {
                rcb_Package.SelectedIndex = rcb_Package.FindItemIndexByValue(dt.Rows[0]["smhr_package_id"].ToString());
                errormsg = "You have selected Gold";
            }
            else
            {
                rcb_Package.SelectedIndex = rcb_Package.FindItemIndexByValue(dt.Rows[1]["smhr_package_id"].ToString());
                errormsg = "You have selected Silver";
            }
            BLL.ShowMessage(this.chklst_sup_module, errormsg);
            //chk_Variableamt_CheckedChanged(null,null);
        }
        catch (Exception ex)
        {

            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_organisation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

        }

    }
    protected void chk_empcode_manual_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chk_empcode_manual.Checked)
            {
                rntxt_zeros.Text = string.Empty;
                tr_noofzeros.Visible = false;
                rfv_rntxt_zeros.Enabled = false;
            }
            else
            {
                tr_noofzeros.Visible = true;
                rntxt_zeros.Text = Convert.ToString(ViewState["NOOFZEROS"]);
                rfv_rntxt_zeros.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_organisation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
