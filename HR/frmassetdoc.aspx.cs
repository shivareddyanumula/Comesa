using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SMHR;
using Telerik.Web.UI;
using System.IO;
using System.Threading;

public partial class HR_frmassetdoc : System.Web.UI.Page
{
    static DataTable DT_Details = new DataTable();
    static DataTable DTDetails;
    SMHR_MASTERS _obj_smhr_masters;
    SMHR_EMPASSETDOC _obj_smhr_empAssetDoc = new SMHR_EMPASSETDOC();
    SMHR_EMPLOYEE _obj_smhr_employee;
    SMHR_DEPARTMENT _obj_SMHR_Department; //Inserted By Sudha sep 13th 2013
    DataTable dt_Details = new DataTable(); //Inserted By Sudha sep 13th 2013
    SMHR_ASSET_MASTER _obj_Smhr_AssetMaster; //Inserted By Sudha sep 13th 2013
    SMHR_LOGININFO _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
    string Control;
    static string _lbl_ID = "";
    static int Mode = 0;
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();

    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Validate();
        hyp_Link.Visible = false;
        lbl_EmployeeName.Visible = false;
        Control = Convert.ToString(Request.QueryString["Control"]);
        if (!Page.IsPostBack)
        {
            try
            {
                //RL_Type.Visible = false;
                ddlType.Visible = true;
                BLL.ChangeDateFormat(Convert.ToString(Session["EMP_ID"]), txt_Date);
                BLL.gridDateFormat(Convert.ToString(Session["EMP_ID"]), RG_AssetDoc, "EMP_ASSETDOC_ISSUEDATE");

                if (Convert.ToString(Request.QueryString["type"]) != null)
                {
                    if (Convert.ToString(Request.QueryString["type"]) == "asset")
                    {
                        lbl_Name.Text = GetLocalResourceObject("EmployeeAsset").ToString();
                        lbl_DetName.Text = GetLocalResourceObject("AssetDetails").ToString();
                        //  lbl_Code.Text = GetLocalResourceObject("AssetCode").ToString();
                        lbl_IssueDate.Text = "Issued Date";
                        //  lblName.Text = GetLocalResourceObject("AssetName").ToString();
                        lbl_Serial.Text = GetLocalResourceObject("lbl_Serial").ToString();
                        lbl_Type.Text = GetLocalResourceObject("lbl_Type").ToString();
                        lblEmployee.Text = GetLocalResourceObject("lbl_Employee").ToString();
                        lblRemarks.Text = GetLocalResourceObject("AssetRemarks").ToString();
                        lblReturnable.Text = GetLocalResourceObject("lblReturnable").ToString();
                        lblType.Text = GetLocalResourceObject("AssetType").ToString();
                        txt_Type.Text = "Assets";
                        txt_Type.Enabled = false;
                        lnk_Download.Visible = false;
                        lnkDelete.Visible = false;
                        lblUpload.Visible = false;
                        FUpload.Visible = false;
                        tr_rg_docs.Visible = false;
                        //btn_Upload.Visible = false;
                        lbl_bold.Visible = false;
                        lbl_Type.Visible = false;
                        txt_Type.Visible = false;
                        //lblReceived.Visible = false;
                        //lblReceivedDate.Visible = false;
                        //lbl_bold1.Visible = false;
                        //lbl_bold2.Visible = false;
                        //  lbl_bold3.Visible = false;
                        //   lbl_Bu.Visible = false;
                        //lbl_Bu.Visible = false;
                        //rtxt_Received.Visible = false;//Previously
                        // rcmb_Employee.Visible = false;//newly
                        //   rcmb_Businessunit.Visible = false;
                        // txt_Receiveddate.Visible = false;
                        //LoadData();
                        // lblReceived_tr.Visible = false;
                        // lblReceivedDate_tr.Visible = false;


                        Session.Remove("WRITEFACILITY");

                        SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();
                        if (Control != null)
                        {
                            if (Control.ToUpper() == "SELF")
                            {
                                _obj_Smhr_LoginInfo.LOGIN_ID = 12;
                                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("EMPLOYEE ASSETS");
                            }

                        }
                        else
                        {
                            _obj_Smhr_LoginInfo.LOGIN_ID = 2;
                            _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("EMPLOYEE ASSETS");
                        }
                        _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                        _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                        _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        //_obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Employee Assets");

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
                            RG_AssetDoc.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
                        }

                        ddlType.Visible = true;
                    }
                    else if (Convert.ToString(Request.QueryString["type"]) == "doc")
                    {
                        //RL_Type.Visible = true;
                        lbl_Name.Text = GetLocalResourceObject("EmployeeDoc").ToString();
                        lbl_DetName.Text = GetLocalResourceObject("DocDetails").ToString();
                        // lbl_Code.Text = GetLocalResourceObject("DocCode").ToString();
                        lbl_IssueDate.Text = GetLocalResourceObject("lbl_IssueDate").ToString();
                        //  lblName.Text = GetLocalResourceObject("DocName").ToString();
                        lbl_Serial.Text = GetLocalResourceObject("lbl_Serial").ToString();
                        lbl_Type.Text = GetLocalResourceObject("lbl_Type").ToString();
                        lblEmployee.Text = GetLocalResourceObject("lbl_Employee").ToString();
                        lblRemarks.Text = GetLocalResourceObject("DocRemarks").ToString();
                        lblReturnable.Text = GetLocalResourceObject("lblReturnable").ToString();
                        lblType.Text = GetLocalResourceObject("DocType").ToString();
                        txt_Type.Text = "Documents";
                        txt_Type.Enabled = false;
                        lblUpload.Visible = true;
                        FUpload.Visible = true;
                        tr_rg_docs.Visible = true;
                        //btn_Upload.Visible = true;
                        lbl_bold.Visible = true;
                        lbl_Type.Visible = false;
                        txt_Type.Visible = false;
                        //lblReceived.Visible = false;
                        //lblReceivedDate.Visible = false;
                        //lbl_bold1.Visible = false;
                        //lbl_bold2.Visible = false;
                        //  lbl_bold3.Visible = false;
                        //   lbl_Bu.Visible = false;
                        //rtxt_Received.Visible = false;//Previously
                        // rcmb_Employee.Visible = false;//newly
                        //   rcmb_Businessunit.Visible = false;
                        // txt_Receiveddate.Visible = false;
                        // lblReceived_tr.Visible = false;
                        // lblReceivedDate_tr.Visible = false;
                        trDelete.Visible = true;
                        LoadData();

                        DataTable dt = new DataTable();
                        rg_docs.DataSource = dt;
                        rg_docs.DataBind();

                        Session.Remove("WRITEFACILITY");

                        SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();
                        if (Control != null)
                        {
                            if (Control.ToUpper() == "SELF")
                            {
                                _obj_Smhr_LoginInfo.LOGIN_ID = 12;
                                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("EMPLOYEE DOCUMENTS");
                                trDelete.Visible = false;
                            }

                        }
                        else
                        {
                            _obj_Smhr_LoginInfo.LOGIN_ID = 2;
                            _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("EMPLOYEE DOCUMENTS");
                        }
                        _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                        _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                        _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        //_obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("EMPLOYEE DOCUMENTS");

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
                            RG_AssetDoc.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
                        }
                    }
                }
                LoadCombos();
            }
            catch (Exception ex)
            {
                SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmassetdoc", ex.StackTrace, DateTime.Now);
                Response.Redirect("~/Frm_ErrorPage.aspx");
                return;
            }
        }
    }
    private void LoadDepartments()
    {
        try
        {
            _obj_SMHR_Department = new SMHR_DEPARTMENT();
            //_obj_SMHR_Department.MODE = 9;
            _obj_SMHR_Department.MODE = 16;
            _obj_SMHR_Department.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_SMHR_Department.BUID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
            //if (rad_Directorate.SelectedIndex > 0) Commneted for Bug 71 Raghasudha 
            //{
            //    _obj_SMHR_Department.MODE = 7;
            //    _obj_SMHR_Department.DIRECTORATE_ID = Convert.ToInt32(rad_Directorate.SelectedItem.Value);
            //}
            //else
            //{               
            //    _obj_SMHR_Department.DIRECTORATE_ID = 0;
            //}
            if (ddl_BusinessUnit.SelectedIndex > 0)
            {
                _obj_SMHR_Department.MODE = 7;
                _obj_SMHR_Department.DIRECTORATE_ID = Convert.ToInt32(rad_Directorate.SelectedItem.Value);
            }
            else
            {
                _obj_SMHR_Department.DIRECTORATE_ID = 0;
            }
            dt_Details = BLL.get_Department(_obj_SMHR_Department);
            if (dt_Details.Rows.Count > 0)
            {
                rad_AssetDepartment.DataSource = dt_Details;
                rad_AssetDepartment.DataValueField = "DEPARTMENT_ID";
                rad_AssetDepartment.DataTextField = "DEPARTMENT_NAME";
                rad_AssetDepartment.DataBind();
                rad_AssetDepartment.Items.Insert(0, new RadComboBoxItem("Select"));
                rad_Department.DataSource = dt_Details;
                rad_Department.DataValueField = "DEPARTMENT_ID";
                rad_Department.DataTextField = "DEPARTMENT_NAME";
                rad_Department.DataBind();
                rad_Department.Items.Insert(0, new RadComboBoxItem("Select"));
            }
            else
            {
                rad_Department.Items.Insert(0, new RadComboBoxItem("Select"));
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmassetdoc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    private void LoadData()
    {
        try
        {
            if (Convert.ToString(Request.QueryString["type"]) == "asset")
            {

                //if (Convert.ToInt32(Session["EMP_ID"]) == 0)
                //if (Convert.ToInt32(Session["EMP_ID"]) == 0)
                //{
                //    DTDetails = new DataTable();
                //    _obj_smhr_empAssetDoc.OPERATION = operation.Select;
                //    _obj_smhr_empAssetDoc.EMPASSETDOC_TYPE = "Assets";
                //    _obj_smhr_empAssetDoc.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //    DTDetails = BLL.get_EmpAssetDoc(_obj_smhr_empAssetDoc);
                //    RG_AssetDoc.DataSource = DTDetails;

                //}
                //else if (Convert.ToString(Session["SELFSERVICE"]) == "")
                //{
                //    DTDetails = new DataTable();
                //    _obj_smhr_empAssetDoc.MODE = 13;
                //    _obj_smhr_empAssetDoc.EMPASSETDOC_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                //    _obj_smhr_empAssetDoc.EMPASSETDOC_TYPE = "Assets";
                //    _obj_smhr_empAssetDoc.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //    DTDetails = BLL.get_AssetDoc(_obj_smhr_empAssetDoc);
                //    RG_AssetDoc.DataSource = DTDetails;
                //    //RG_AssetDoc.DataBind();
                //    //RG_AssetDoc.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                //}
                //else
                //{
                //    DTDetails = new DataTable();
                //    _obj_smhr_empAssetDoc.MODE = 1;
                //    _obj_smhr_empAssetDoc.EMPASSETDOC_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                //    _obj_smhr_empAssetDoc.EMPASSETDOC_TYPE = "Assets";
                //    _obj_smhr_empAssetDoc.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //    DTDetails = BLL.get_AssetDoc(_obj_smhr_empAssetDoc);
                //    RG_AssetDoc.DataSource = DTDetails;
                //    RG_AssetDoc.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                //}
                if (Control != null)
                {
                    if ((Convert.ToString(Session["SELFSERVICE"]) == "true" && Control.ToUpper() == "SELF") || (Convert.ToString(Session["SELFSERVICE"]) == "" && Control.ToUpper() == "SELF"))
                    {
                        DTDetails = new DataTable();
                        _obj_smhr_empAssetDoc = new SMHR_EMPASSETDOC();
                        _obj_smhr_empAssetDoc.MODE = 1;
                        _obj_smhr_empAssetDoc.EMPASSETDOC_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                        _obj_smhr_empAssetDoc.EMPASSETDOC_TYPE = "Assets";
                        _obj_smhr_empAssetDoc.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DTDetails = BLL.get_AssetDoc(_obj_smhr_empAssetDoc);
                        RG_AssetDoc.DataSource = DTDetails;
                        RG_AssetDoc.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    }
                    else
                    {
                        BLL.ShowMessage(this, "You do not have Access on this Screen.");
                        return;

                    }
                }
                else
                {
                    DTDetails = new DataTable();
                    _obj_smhr_empAssetDoc = new SMHR_EMPASSETDOC();
                    _obj_smhr_empAssetDoc.OPERATION = operation.Select;
                    _obj_smhr_empAssetDoc.EMPASSETDOC_TYPE = "Assets";
                    _obj_smhr_empAssetDoc.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_empAssetDoc.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                    DTDetails = BLL.get_EmpAssetDoc(_obj_smhr_empAssetDoc);
                    RG_AssetDoc.DataSource = DTDetails;
                }


            }
            else if (Convert.ToString(Request.QueryString["type"]) == "doc")
            {
                //if (Convert.ToString(Session["SELFSERVICE"]) == "")
                //if (Convert.ToInt32(Session["EMP_ID"]) == 0)
                //{
                //    DTDetails = new DataTable();
                //    _obj_smhr_empAssetDoc.OPERATION = operation.Select;
                //    _obj_smhr_empAssetDoc.EMPASSETDOC_TYPE = "Documents";
                //    _obj_smhr_empAssetDoc.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //    DTDetails = BLL.get_EmpAssetDoc(_obj_smhr_empAssetDoc);
                //    RG_AssetDoc.DataSource = DTDetails;
                //}
                //else if (Convert.ToString(Session["SELFSERVICE"]) == "")
                //{
                //    DTDetails = new DataTable();
                //    _obj_smhr_empAssetDoc.MODE = 13;
                //    _obj_smhr_empAssetDoc.EMPASSETDOC_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                //    _obj_smhr_empAssetDoc.EMPASSETDOC_TYPE = "Documents";
                //    _obj_smhr_empAssetDoc.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //    DTDetails = BLL.get_AssetDoc(_obj_smhr_empAssetDoc);
                //    RG_AssetDoc.DataSource = DTDetails;
                //    //RG_AssetDoc.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                //}
                //else
                //{
                //    DTDetails = new DataTable();
                //    _obj_smhr_empAssetDoc.MODE = 1;
                //    _obj_smhr_empAssetDoc.EMPASSETDOC_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                //    _obj_smhr_empAssetDoc.EMPASSETDOC_TYPE = "Documents";
                //    _obj_smhr_empAssetDoc.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //    DTDetails = BLL.get_AssetDoc(_obj_smhr_empAssetDoc);
                //    RG_AssetDoc.DataSource = DTDetails;
                //    RG_AssetDoc.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                //}
                if (Control != null)
                {
                    if ((Convert.ToString(Session["SELFSERVICE"]) == "true" && Control.ToUpper() == "SELF") || (Convert.ToString(Session["SELFSERVICE"]) == "" && Control.ToUpper() == "SELF"))
                    {
                        DTDetails = new DataTable();
                        _obj_smhr_empAssetDoc = new SMHR_EMPASSETDOC();
                        _obj_smhr_empAssetDoc.MODE = 1;
                        _obj_smhr_empAssetDoc.EMPASSETDOC_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                        _obj_smhr_empAssetDoc.EMPASSETDOC_TYPE = "Documents";
                        _obj_smhr_empAssetDoc.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DTDetails = BLL.get_AssetDoc(_obj_smhr_empAssetDoc);
                        RG_AssetDoc.DataSource = DTDetails;
                        RG_AssetDoc.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    }
                    else
                    {
                        BLL.ShowMessage(this, "You do not have Access on this Screen.");
                        return;

                    }
                }
                else
                {
                    DTDetails = new DataTable();
                    _obj_smhr_empAssetDoc = new SMHR_EMPASSETDOC();
                    _obj_smhr_empAssetDoc.OPERATION = operation.Select;
                    _obj_smhr_empAssetDoc.EMPASSETDOC_TYPE = "Documents";
                    //_obj_smhr_empAssetDoc.EMPASSETDOC_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                    _obj_smhr_empAssetDoc.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_empAssetDoc.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                    DTDetails = BLL.get_EmpAssetDoc(_obj_smhr_empAssetDoc);
                    RG_AssetDoc.DataSource = DTDetails;
                    RG_AssetDoc.Columns[4].Visible = false;

                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmassetdoc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void lnk_Add_Click(object sender, EventArgs e)
    {
        tr_rg_assets.Visible = false;
        try
        {
            ddlType.Text = string.Empty;
            rg_Assets.DataSource = null;
            rg_Assets.DataBind();
            if (Convert.ToString(Request.QueryString["type"]) == "doc")
            {
                Session.Remove("dt_Docs");
                Mode = 1;
                createcontrols();
                DataTable dt = Session["dt_Docs"] as DataTable;
                rg_docs.DataSource = dt;
                rg_docs.DataBind();
                rfv_rad_Directorate.Enabled = false;
            }
            RFV_Employee.InitialValue = "Select";
            btn_Update.Visible = false;
            btn_Save.Visible = true;
            lnk_Download.Visible = false;
            lnkDelete.Visible = false;
            // rcmb_Businessunit.SelectedIndex = -1;
            // Businessunit.Visible = false;
            //ddl_Employee.Items.Clear();
            //ddl_Employee.Items.Insert(0, new RadComboBoxItem("Select"));

            //ddl_Employee.Enabled = true;
            clearFields();
            //if (Convert.ToString(Session["SELFSERVICE"]) == "")
            //if ((Convert.ToString(Session["SELFSERVICE"]) == "") || (Convert.ToInt32(Session["EMP_ID"]) == 0))
            if (Control == null)
            {
                ddl_Employee.Enabled = true;
                ddl_BusinessUnit.Enabled = true;
                rad_Department.Enabled = true;
                rad_AssetDepartment.Enabled = true;
                rad_Directorate.Enabled = true;
                RMP_AssetDoc.SelectedIndex = 1;
                if (Convert.ToInt32(Session["WRITEFACILITY"]) != 2)
                {
                    btn_Save.Visible = true;
                }
            }
            else
            {
                _obj_smhr_empAssetDoc.EMPASSETDOC_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                _obj_smhr_empAssetDoc.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable Dt_Details = BLL.get_EmpAssetDocBU(_obj_smhr_empAssetDoc);
                if (Dt_Details.Rows.Count == 1)
                {
                    ddl_BusinessUnit.DataSource = Dt_Details;
                    ddl_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
                    ddl_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
                    ddl_BusinessUnit.DataBind();
                }
                LoadEmployees();
                ddl_Employee.SelectedValue = Convert.ToString(Session["EMP_ID"]);
                ddl_Employee.Enabled = false;
                ddl_BusinessUnit.Enabled = false;
                BLL.ShowMessage(this, "Not Authorised to Add");
                return;
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmassetdoc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void lnk_Docs_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            _obj_smhr_masters = new SMHR_MASTERS();
            _obj_smhr_masters.OPERATION = operation.Select;
            _obj_smhr_masters.MASTER_TYPE = "DOCUMENTS";
            _obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);
            ddlType.DataSource = dt_Details;
            ddlType.DataValueField = "HR_MASTER_ID";
            ddlType.DataTextField = "HR_MASTER_CODE";
            ddlType.DataBind();
            ddlType.Items.Insert(0, new RadComboBoxItem("Select"));
            ddlType.SelectedIndex = ddlType.FindItemIndexByText(Convert.ToString(rg_docs.Items[Convert.ToString(e.CommandArgument)].Cells[5].Text));
            hdndocsEMPASSET_ID.Value = rg_docs.Items[Convert.ToInt32(e.CommandArgument)].Cells[2].Text;
            hdnEMPDOCS_ID.Value = rg_docs.Items[Convert.ToInt32(e.CommandArgument)].Cells[10].Text;


            string dateString = rg_docs.Items[Convert.ToInt32(0)].Cells[8].Text;
            DateTime date2 = BLL.GetDateTimefromDDMMYYYY(dateString);// Convert.ToDateTime(dateString, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
            txt_Date.SelectedDate = date2;
            // txt_Date.SelectedDate = Convert.ToDateTime(Convert.ToDateTime(rg_docs.Items[Convert.ToInt32(e.CommandArgument)].Cells[8].Text).ToString("dd/MM/yyyy"));
            txt_Remarks.Text = rg_docs.Items[Convert.ToInt32(e.CommandArgument)].Cells[7].Text;
            chk_Returnable.Checked = Convert.ToBoolean(rg_docs.Items[Convert.ToInt32(e.CommandArgument)].Cells[6].Text);
            DataTable dt = LoadAssetsAssigned();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if ((dr["EMPASSET_ASSETID"]) != (System.DBNull.Value))
                    {
                        //string s=rg_Assets.Items[Convert.ToInt32(e.CommandArgument)].Cells[3].Text;
                        if (string.Compare(Convert.ToString(dr["EMPASSET_ASSETID"]), rg_docs.Items[Convert.ToInt32(e.CommandArgument)].Cells[3].Text, true) != 0)
                        {
                            if (ddlType.Items != null && ddlType.Items.Count > 0)
                            {
                                ddlType.Items.Remove(ddlType.FindItemIndexByValue(Convert.ToString(dr["EMPASSET_ASSETID"])));
                                //ddlType.Items.Insert(0, new RadComboBoxItem("Select"));
                            }
                        }

                    }
                }
                btn_Save.Visible = false;
                btn_Update.Visible = true;
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmassetdoc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void lnk_Asset_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {

            LoadAllAssets();
            hdnEMPASSET_ID.Value = rg_Assets.Items[Convert.ToInt32(e.CommandArgument)].Cells[2].Text;

            string dateString = rg_Assets.Items[Convert.ToInt32(0)].Cells[7].Text;
            DateTime date2 = BLL.GetDateTimefromDDMMYYYY(dateString);
            txt_Date.SelectedDate = date2;

            txt_Remarks.Text = HttpUtility.HtmlDecode(rg_Assets.Items[Convert.ToInt32(e.CommandArgument)].Cells[6].Text).Trim();

            chk_Returnable.Checked = Convert.ToBoolean(rg_Assets.Items[Convert.ToInt32(e.CommandArgument)].Cells[5].Text);
            DataTable dt = LoadAssetsAssigned();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if ((dr["EMPASSET_ASSETID"]) != (System.DBNull.Value))
                    {
                        //string s=rg_Assets.Items[Convert.ToInt32(e.CommandArgument)].Cells[3].Text;
                        if (string.Compare(Convert.ToString(dr["EMPASSET_ASSETID"]), rg_Assets.Items[Convert.ToInt32(e.CommandArgument)].Cells[3].Text, true) != 0)
                        {
                            if (ddlType.Items != null && ddlType.Items.Count > 0)
                            {
                                //ddlType.Items.Remove(ddlType.FindItemIndexByValue(Convert.ToString(dr["EMPASSET_ASSETID"])));
                                ddlType.Items.Remove(ddlType.FindItemIndexByValue(Convert.ToString(dr["EMPDOCS_ID"])));
                                //ddlType.Items.Insert(0, new RadComboBoxItem("Select"));
                            }
                        }

                    }
                }
                ddlType.SelectedValue = dt.Rows[0]["EMPASSET_ASSETID"].ToString();
                btn_Save.Visible = false;
                btn_Update.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmassetdoc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void lnk_AssetDoc_Edit_Command(object sender, CommandEventArgs e)
    {

        try
        {
            if (Convert.ToString(Request.QueryString["type"]) == "doc")
            {
                Mode = 2;
                Session.Remove("dt_Docs");
                createcontrols();
            }
            HF_ID.Value = Convert.ToString(e.CommandArgument);
            ViewState["ID"] = Convert.ToString(e.CommandArgument);
            clearFields();
            RMP_AssetDoc.SelectedIndex = 1;
            getDetails(HF_ID.Value);
            btn_Save.Visible = true;
            btn_Update.Visible = false;

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmassetdoc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            RMP_AssetDoc.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmassetdoc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    private void LoadCombos()
    {
        try
        {
            //Business Unit




            if (Convert.ToString(Request.QueryString["type"]) == "asset")
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
                ddl_Employee.Items.Clear();
                ddl_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
            }
            else
            {
                tr_AssetDepartment.Visible = false;
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
                _obj_smhr_masters = new SMHR_MASTERS();
                _obj_smhr_masters.OPERATION = operation.Select;
                _obj_smhr_masters.MASTER_TYPE = "DOCUMENTS";
                _obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);
                ddlType.DataSource = dt_Details;
                ddlType.DataValueField = "HR_MASTER_ID";
                ddlType.DataTextField = "HR_MASTER_CODE";
                ddlType.DataBind();

                ddlType.Items.Insert(0, new RadComboBoxItem("Select"));
                // ddlType.Items.Insert(0, new RadComboBoxItem("Select"));
            }
            //// Commneted By Sudha sep 13th 2013
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmassetdoc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            string Assettype = string.Empty;
            lbl_EmployeeName.Text = ddl_Employee.SelectedValue;
            bool status1 = chk_Validate();
            if (status1 == true)
            {
                BLL.ShowMessage(this, "Date Should be Greater than Employee Join Date");
                return;
            }
            else
            {

                if (Convert.ToString(Request.QueryString["type"]) == "asset")
                {

                    bool status = false;
                    _obj_smhr_empAssetDoc.EMPASSETDOC_TYPE = Convert.ToString(txt_Type.Text);
                    _obj_smhr_empAssetDoc.EMPASSETDOC_BU_ID = Convert.ToInt32(ddl_BusinessUnit.SelectedItem.Value);
                    //   _obj_smhr_empAssetDoc.EMPASSETDOC_DEPT_ID = Convert.ToInt32(rad_Department.SelectedValue); //Inserted By Sudha on sep 13th 2013 
                    if (rad_AssetDepartment.SelectedIndex > 0)
                    {
                        _obj_smhr_empAssetDoc.EMPASSETDOC_DEPT_ID = Convert.ToInt32(rad_AssetDepartment.SelectedValue); //Inserted By Sudha on sep 13th 2013 
                    }
                    else
                    {
                        _obj_smhr_empAssetDoc.EMPASSETDOC_DEPT_ID = 0; //Inserted By Sudha on sep 13th 2013 
                    }
                    if (ddl_Employee.SelectedIndex > 0)
                    {
                        _obj_smhr_empAssetDoc.EMPASSETDOC_EMP_ID = Convert.ToInt32(ddl_Employee.SelectedItem.Value);
                    }
                    else
                    {
                        _obj_smhr_empAssetDoc.EMPASSETDOC_DEPT_ID = 0; //Inserted By Sudha on sep 13th 2013 
                    }
                    if (txt_Serial.Text == "")
                    {
                        getSerialID();
                    }
                    _obj_smhr_empAssetDoc.OPERATION = operation.Insert;
                    if (Convert.ToDateTime(txt_Date.SelectedDate.Value) <= System.DateTime.Now)
                    {
                        _obj_smhr_empAssetDoc.EMP_ASSETDOC_ISSUEDATE = Convert.ToDateTime(txt_Date.SelectedDate.Value);
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Issue date cannot be ahead of Today Date");
                        return;
                    }
                    if (chk_Returnable.Checked)
                    {
                        _obj_smhr_empAssetDoc.EMP_ASSETDOC_RETURNABLE = true;
                    }
                    else
                    {
                        _obj_smhr_empAssetDoc.EMP_ASSETDOC_RETURNABLE = false;
                    }
                    if (ddlType.SelectedIndex > 0)
                    {
                        _obj_smhr_empAssetDoc.EMP_ASSETDOC_AD_Type = ddlType.SelectedValue;//added By Shiva Reddy on oct 11th 2019
                    }
                    else
                    {
                        _obj_smhr_empAssetDoc.EMP_ASSETDOC_AD_Type = "0"; //added By  Shiva Reddy on oct 11th 2019
                    }
                   // _obj_smhr_empAssetDoc.EMP_ASSETDOC_AD_Type = ddlType.SelectedItem.Value;
                    _obj_smhr_empAssetDoc.EMP_ASSETDOC_REMARKS = Convert.ToString(txt_Remarks.Text.Replace("'", "''"));
                    _obj_smhr_empAssetDoc.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_empAssetDoc.CREATEDDATE = DateTime.Now;
                    _obj_smhr_empAssetDoc.ASSETDOC_UPLOAD = string.Empty;
                    _obj_smhr_empAssetDoc.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_empAssetDoc.EMPASSETDOC_CREATED_BY = Convert.ToInt32(Session["USER_ID"]); ;
                    _obj_smhr_empAssetDoc.EMPASSETDOC_CREATEDDATE = DateTime.Now;

                    _obj_smhr_empAssetDoc.EMPASSETDOC_LSTMDFBY = Convert.ToInt32(Session["USER_ID"]); ;
                    _obj_smhr_empAssetDoc.EMPASSETDOC_LSTMDFDATE = DateTime.Now;

                    _obj_smhr_empAssetDoc.EMP_ASSETDOC_STATUS = 1;
                    _obj_smhr_empAssetDoc.EMPASSETDOC_TYPE = "Assets";//Convert.ToString(txt_Type.Text);                    
                    _obj_smhr_empAssetDoc.OPERATION = operation.Insert;
                    status = BLL.set_EmpAssetDoc(_obj_smhr_empAssetDoc);
                    if (status == true)
                    {
                        BLL.ShowMessage(this, "Employee Assets Inserted Successfully");
                        RMP_AssetDoc.SelectedIndex = 0;
                        LoadData();
                        RG_AssetDoc.DataBind();
                        return;
                    }
                }
                else
                {
                    //if (rg_docs.Items.Count > 0)
                    //{
                    bool status = false;
                    _obj_smhr_empAssetDoc.EMPASSETDOC_TYPE = "Documents";//Convert.ToString(txt_Type.Text);
                    _obj_smhr_empAssetDoc.EMPASSETDOC_BU_ID = Convert.ToInt32(ddl_BusinessUnit.SelectedItem.Value);
                    if (rad_Department.SelectedIndex > 0)
                    {
                        _obj_smhr_empAssetDoc.EMPASSETDOC_DEPT_ID = Convert.ToInt32(rad_Department.SelectedValue); //Inserted By Sudha on sep 13th 2013
                    }
                    else
                    {
                        _obj_smhr_empAssetDoc.EMPASSETDOC_DEPT_ID = 0; //Inserted By Sudha on sep 13th 2013
                    }
                    _obj_smhr_empAssetDoc.EMPASSETDOC_EMP_ID = Convert.ToInt32(ddl_Employee.SelectedValue);
                    _obj_smhr_empAssetDoc.OPERATION = operation.Insert;
                    if (txt_Serial.Text == "")
                    {
                        getSerialID();
                    }
                    else
                    {
                        _obj_smhr_empAssetDoc.EMPASSETDOC_SERIAL = Convert.ToInt32(txt_Serial.Text);
                    }
                    if (Convert.ToDateTime(txt_Date.SelectedDate.Value) <= System.DateTime.Now)
                    {
                        _obj_smhr_empAssetDoc.EMP_ASSETDOC_ISSUEDATE = Convert.ToDateTime(txt_Date.SelectedDate.Value);
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Issue date cannot be ahead of Today Date");
                        return;
                    }
                    if (chk_Returnable.Checked)
                    {
                        _obj_smhr_empAssetDoc.EMP_ASSETDOC_RETURNABLE = true;
                    }
                    else
                    {
                        _obj_smhr_empAssetDoc.EMP_ASSETDOC_RETURNABLE = false;
                    }
                    if (ddlType.SelectedIndex > 0)
                    {
                        _obj_smhr_empAssetDoc.EMP_ASSETDOC_AD_Type = ddlType.SelectedValue;//added By Shiva on oct 11th 2019
                    }
                    else
                    {
                        _obj_smhr_empAssetDoc.EMP_ASSETDOC_AD_Type = "0"; //added By Shiva on oct 11th 2019
                    }
                   // _obj_smhr_empAssetDoc.EMP_ASSETDOC_AD_Type = ddlType.SelectedValue;
                    _obj_smhr_empAssetDoc.EMP_ASSETDOC_REMARKS = Convert.ToString(txt_Remarks.Text.Replace("'", "''"));
                    _obj_smhr_empAssetDoc.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);//1;
                    _obj_smhr_empAssetDoc.CREATEDDATE = DateTime.Now;

                    _obj_smhr_empAssetDoc.EMPASSETDOC_CREATED_BY = Convert.ToInt32(Session["USER_ID"]); ;
                    _obj_smhr_empAssetDoc.EMPASSETDOC_CREATEDDATE = DateTime.Now;

                    _obj_smhr_empAssetDoc.EMPASSETDOC_LSTMDFBY = Convert.ToInt32(Session["USER_ID"]); ;
                    _obj_smhr_empAssetDoc.EMPASSETDOC_LSTMDFDATE = DateTime.Now;


                    _obj_smhr_empAssetDoc.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

                    _obj_smhr_empAssetDoc.EMP_ASSETDOC_STATUS = 1;
                    if (FUpload.HasFile)
                    {
                        string filename = Convert.ToString(FUpload.FileName.Trim().Replace("'", "''"));
                        FUpload.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/EmpUploads/DocUploads/"), ddl_Employee.SelectedItem.Value + "_" + filename));

                        _obj_smhr_empAssetDoc.EMPDOCS_UPLOAD = "~/EmpUploads/DocUploads/" + ddl_Employee.SelectedValue + "_" + filename;
                        _obj_smhr_empAssetDoc.EMPDOCS_NAME = Convert.ToString(FUpload.FileName);
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Please select a document to upload");
                        return;
                    }
                    _obj_smhr_empAssetDoc.OPERATION = operation.Insert;
                    status = BLL.set_EmpAssetDoc(_obj_smhr_empAssetDoc);
                    if (status == true)
                    {
                        //_obj_smhr_empAssetDoc.OPERATION = operation.Empty1;
                        //DataTable dt_id = BLL.get_EmpAssetDoc(_obj_smhr_empAssetDoc);
                        //for (int index = 0; index < rg_docs.Items.Count; index++)
                        //{
                        //    _obj_smhr_empAssetDoc.EMPDOCS_ASSETDOC_ID = Convert.ToInt32(dt_id.Rows[0][0]);
                        //    _obj_smhr_empAssetDoc.EMPDOCS_NAME = Convert.ToString(rg_docs.Items[index]["EMPDOCS_NAME"].Text.Trim().Replace("'", "''"));
                        //    string filename = Convert.ToString(rg_docs.Items[index]["EMPDOCS_NAME"].Text.Trim().Replace("'", "''"));
                        //    _obj_smhr_empAssetDoc.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                        //    _obj_smhr_empAssetDoc.ASSETDOC_UPLOAD = string.Empty;
                        //    if (!string.IsNullOrEmpty(filename))
                        //    {
                        //        _obj_smhr_empAssetDoc.EMPDOCS_UPLOAD = "~/EmpUploads/DocUploads/" + ddl_Employee.SelectedValue + "_" + filename;
                        //    }
                        //    else
                        //    {
                        //        _obj_smhr_empAssetDoc.EMPDOCS_UPLOAD = string.Empty;
                        //    }
                        //    _obj_smhr_empAssetDoc.OPERATION = operation.Insert1;
                        //    if (BLL.set_EmpAssetDoc(_obj_smhr_empAssetDoc))
                        //    {
                        //    }
                        //}
                        BLL.ShowMessage(this, "Employee Documents Uploaded Successfully");
                        RMP_AssetDoc.SelectedIndex = 0;
                        LoadData();
                        RG_AssetDoc.DataBind();
                        Session.Remove("dt_Docs");
                        return;
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Employee Documents Not Uploaded");
                    }
                    //}
                    //else
                    //{
                    //    BLL.ShowMessage(this, "Upload Your Document");
                    //}
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmassetdoc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void btn_Update_Click(object sender, EventArgs e)
    {
        try
        {
            string assetID = hdnEMPASSET_ID.Value;
            string DOC_ID = hdnEMPDOCS_ID.Value;
            string Assettype = string.Empty;

            SMHR_EMPLOYEE _obj_smhr_employee = new SMHR_EMPLOYEE();
            _obj_smhr_employee.OPERATION = operation.Select;
            _obj_smhr_employee.EMP_ID = Convert.ToInt32(ddl_Employee.SelectedItem.Value);
            //dt_Details = new DataTable();
            _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Details = BLL.get_Employee(_obj_smhr_employee);
            if (Convert.ToInt32(dt_Details.Rows[0]["EMP_STATUS"]) == 2)
            {
                BLL.ShowMessage(this, "Employee is Relieved.You can not update the record.");
                return;
            }
            else if (Convert.ToInt32(dt_Details.Rows[0]["EMP_STATUS"]) == 3)
            {
                BLL.ShowMessage(this, "Employee is Rehired.You can not update the record.");
                return;
            }
            else if (Convert.ToInt32(dt_Details.Rows[0]["EMP_STATUS"]) == 4)
            {
                BLL.ShowMessage(this, "Employee is Transfered.You can not update the record.");
                return;
            }
            else
            {
                bool status1 = chk_Validate();
                if (status1 == true)
                {
                    BLL.ShowMessage(this, "Date Should be Greater than Employee Join Date");
                    return;
                }
                else
                {
                    if (Convert.ToString(Request.QueryString["type"]) == "asset")
                    {
                        bool status = false;
                        _obj_smhr_empAssetDoc.OPERATION = operation.Update;
                        //_obj_smhr_empAssetDoc.EMPASSETDOC_TYPE = Convert.ToString(txt_Type.Text);
                        _obj_smhr_empAssetDoc.EMPASSETDOC_ID = Convert.ToInt32(hdnEMPASSET_ID.Value);
                        //  _obj_smhr_empAssetDoc.COMMITTEE_ID = Convert.ToInt32(hdndocsEMPASSET_ID.Value);//Convert.ToInt32(_lbl_ID);
                        //_obj_smhr_empAssetDoc.EMPASSETDOC_BU_ID = Convert.ToInt32(ddl_BusinessUnit.SelectedItem.Value);
                        //_obj_smhr_empAssetDoc.EMPASSETDOC_EMP_ID = Convert.ToInt32(lbl_EmployeeName.Text);
                        //_obj_smhr_empAssetDoc.EMPASSETDOC_SERIAL = Convert.ToInt32(txt_Serial.Text);
                        if (Convert.ToDateTime(txt_Date.SelectedDate.Value) <= System.DateTime.Now)
                        {
                            _obj_smhr_empAssetDoc.EMP_ASSETDOC_ISSUEDATE = Convert.ToDateTime(txt_Date.SelectedDate.Value);
                        }
                        else
                        {
                            BLL.ShowMessage(this, "Issue date cannot be ahead of Today Date");
                            return;
                        }
                        _obj_smhr_empAssetDoc.EMP_ASSETDOC_AD_Type = ddlType.SelectedValue;
                        if (chk_Returnable.Checked)
                        {
                            _obj_smhr_empAssetDoc.EMP_ASSETDOC_RETURNABLE = true;
                        }
                        else
                        {
                            _obj_smhr_empAssetDoc.EMP_ASSETDOC_RETURNABLE = false;
                        }
                        _obj_smhr_empAssetDoc.EMP_ASSETDOC_REMARKS = Convert.ToString(txt_Remarks.Text.Replace("'", "''"));
                        _obj_smhr_empAssetDoc.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_smhr_empAssetDoc.CREATEDDATE = DateTime.Now;
                        _obj_smhr_empAssetDoc.ASSETDOC_UPLOAD = string.Empty;
                        _obj_smhr_empAssetDoc.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);


                        _obj_smhr_empAssetDoc.EMPASSETDOC_CREATED_BY = Convert.ToInt32(Session["USER_ID"]); ;
                        _obj_smhr_empAssetDoc.EMPASSETDOC_CREATEDDATE = DateTime.Now;

                        _obj_smhr_empAssetDoc.EMPASSETDOC_LSTMDFBY = Convert.ToInt32(Session["USER_ID"]); ;
                        _obj_smhr_empAssetDoc.EMPASSETDOC_LSTMDFDATE = DateTime.Now;

                        _obj_smhr_empAssetDoc.EMP_ASSETDOC_STATUS = 1;
                        _obj_smhr_empAssetDoc.OPERATION = operation.Update;

                        status = BLL.set_EmpAssetDoc(_obj_smhr_empAssetDoc);
                        if (status == true)
                        {
                            getDetails(HF_ID.Value);
                            BLL.ShowMessage(this, "Employee Assets Updated Successfully");
                            RMP_AssetDoc.SelectedIndex = 1;
                            txt_Date.SelectedDate = null;
                            txt_Remarks.Text = string.Empty;
                            ddlType.SelectedIndex = 0;
                            ddlType.Items.Clear();
                            ddlType.Text = string.Empty;

                            chk_Returnable.Checked = false;
                            btn_Save.Visible = true;
                            btn_Update.Visible = false;
                            HF_ID.Value = Convert.ToString(ViewState["ID"]);
                            getDetails(HF_ID.Value);
                            return;
                        }
                    }
                    else
                    {

                        bool status = false;
                        _obj_smhr_empAssetDoc.OPERATION = operation.Update;
                        _obj_smhr_empAssetDoc.EMPASSETDOC_TYPE = Convert.ToString(txt_Type.Text);
                        _obj_smhr_empAssetDoc.EMPASSETDOC_ID = Convert.ToInt32(hdnEMPDOCS_ID.Value);//Convert.ToInt32(_lbl_ID);
                        _obj_smhr_empAssetDoc.COMMITTEE_ID = Convert.ToInt32(hdndocsEMPASSET_ID.Value); // hdndocsEMPASSET_IDasset ID
                        _obj_smhr_empAssetDoc.EMPASSETDOC_BU_ID = Convert.ToInt32(ddl_BusinessUnit.SelectedItem.Value);
                        _obj_smhr_empAssetDoc.EMPASSETDOC_EMP_ID = Convert.ToInt32(lbl_EmployeeName.Text);
                        _obj_smhr_empAssetDoc.EMPASSETDOC_SERIAL = Convert.ToInt32(txt_Serial.Text);

                        if (Convert.ToDateTime(txt_Date.SelectedDate.Value) <= System.DateTime.Now)
                        {
                            _obj_smhr_empAssetDoc.EMP_ASSETDOC_ISSUEDATE = Convert.ToDateTime(txt_Date.SelectedDate.Value);
                        }
                        else
                        {
                            BLL.ShowMessage(this, "Issue date cannot be ahead of Today Date");
                            return;
                        }
                        if (chk_Returnable.Checked)
                        {
                            _obj_smhr_empAssetDoc.EMP_ASSETDOC_RETURNABLE = true;
                        }
                        else
                        {
                            _obj_smhr_empAssetDoc.EMP_ASSETDOC_RETURNABLE = false;
                        }
                        _obj_smhr_empAssetDoc.EMP_ASSETDOC_AD_Type = ddlType.SelectedValue;// RL_Type.SelectedItem.Value;
                        _obj_smhr_empAssetDoc.EMP_ASSETDOC_REMARKS = Convert.ToString(txt_Remarks.Text.Replace("'", "''"));
                        _obj_smhr_empAssetDoc.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); ;
                        _obj_smhr_empAssetDoc.CREATEDDATE = DateTime.Now;

                        _obj_smhr_empAssetDoc.EMPASSETDOC_CREATED_BY = Convert.ToInt32(Session["USER_ID"]); ;
                        _obj_smhr_empAssetDoc.EMPASSETDOC_CREATEDDATE = DateTime.Now;

                        _obj_smhr_empAssetDoc.EMPASSETDOC_LSTMDFBY = Convert.ToInt32(Session["USER_ID"]); ;
                        _obj_smhr_empAssetDoc.EMPASSETDOC_LSTMDFDATE = DateTime.Now;


                        _obj_smhr_empAssetDoc.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

                        _obj_smhr_empAssetDoc.EMP_ASSETDOC_STATUS = 1;
                        _obj_smhr_empAssetDoc.OPERATION = operation.Update;

                        _obj_smhr_empAssetDoc.ASSETDOC_UPLOAD = string.Empty;
                        if (FUpload.HasFile)
                        {
                            string filename = Convert.ToString(FUpload.FileName.Trim().Replace("'", "''"));
                            FUpload.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/EmpUploads/DocUploads/"), ddl_Employee.SelectedItem.Value + "_" + filename));

                            _obj_smhr_empAssetDoc.EMPDOCS_UPLOAD = "~/EmpUploads/DocUploads/" + ddl_Employee.SelectedValue + "_" + filename;
                            _obj_smhr_empAssetDoc.EMPDOCS_NAME = Convert.ToString(FUpload.FileName);
                        }
                        status = BLL.set_EmpAssetDoc(_obj_smhr_empAssetDoc);
                        if (status == true)
                        {
                            getDetails(HF_ID.Value);
                            BLL.ShowMessage(this, "Employee Documents Updated Successfully");
                            RMP_AssetDoc.SelectedIndex = 1;
                            //LoadData();
                            //RG_AssetDoc.DataBind();
                            Session.Remove("dt_Docs");
                            txt_Date.SelectedDate = null;
                            txt_Remarks.Text = string.Empty;
                            chk_Returnable.Checked = false;
                            btn_Save.Visible = true;
                            btn_Update.Visible = false;
                            return;
                        }
                        else
                        {
                            BLL.ShowMessage(this, "Employee Documents Not Updated");
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmassetdoc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void ddl_Employee_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {



            //  }

            if (ddl_Employee.SelectedIndex > 0)
            {
                getSerialID();
                //if (Convert.ToString(Request.QueryString["type"]) == "asset")
                //{
                SMHR_EMPLOYEE _obj_smhr_employee = new SMHR_EMPLOYEE();
                _obj_smhr_employee.OPERATION = operation.Delete;
                if (ddl_Employee.SelectedIndex > 0)
                {
                    _obj_smhr_employee.EMP_ID = Convert.ToInt32(ddl_Employee.SelectedValue);
                }
                else
                {
                    _obj_smhr_employee.EMP_ID = 0;
                }

                DataTable dtemp = BLL.get_Employeedetail(_obj_smhr_employee);
                if (dtemp != null)
                {
                    if (dtemp.Rows.Count > 0)
                    {
                        txt_Date.MinDate = Convert.ToDateTime(dtemp.Rows[0]["EMP_DOJ"]);
                    }
                }
                if (string.Compare(Convert.ToString(Request.QueryString["type"]), "doc", true) == 0)
                {
                    SMHR_EMPASSETDOC _obj_smhr_empassetdoc = new SMHR_EMPASSETDOC();
                    _obj_smhr_empassetdoc.EMPASSETDOC_EMP_ID = Convert.ToInt32(ddl_Employee.SelectedValue);
                    _obj_smhr_empassetdoc.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_empassetdoc.EMPASSETDOC_TYPE = "Documents";
                    DataTable dtAssetsDoc = BLL.get_EmpAssetDoc(_obj_smhr_empassetdoc);
                    if (dtAssetsDoc.Rows.Count > 0)
                    {
                        ddl_Employee.SelectedIndex = 0;
                        BLL.ShowMessage(this, "Employee is already assigned with documents");
                        return;
                    }
                }

                SMHR_EMPRESIGNATION _obj_Smhr_Empresignation = new SMHR_EMPRESIGNATION();
                _obj_Smhr_Empresignation.OPERATION = operation.Validate;
                _obj_Smhr_Empresignation.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_Empresignation.EMPREG_EMP_ID = Convert.ToInt32(ddl_Employee.SelectedValue);
                if (Convert.ToString(Request.QueryString["type"]) == "asset")
                {
                    DataTable dt = BLL.get_Empresignation(_obj_Smhr_Empresignation);
                    if (dt.Rows.Count == 1)
                    {
                        BLL.ShowMessage(this, "Selected Employee Resignation done. Cannot Assign the Asset(s)");
                        return;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmassetdoc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

    }
    protected DataTable LoadAssetsAssigned()
    {
        DataTable dt_EmpAssets = new DataTable();
        try
        {

            _obj_smhr_empAssetDoc.OPERATION = operation.get_Assets_Assigned;

            _obj_smhr_empAssetDoc.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            if (Convert.ToString(Request.QueryString["type"]) == "asset")
            {
                _obj_smhr_empAssetDoc.EMPASSETDOC_TYPE = "Assets";
            }
            else
            {
                _obj_smhr_empAssetDoc.EMPASSETDOC_TYPE = "Documents";
            }


            if (rad_AssetDepartment.SelectedIndex > 0)
            {
                _obj_smhr_empAssetDoc.EMPASSETDOC_DEPT_ID = Convert.ToInt32(rad_AssetDepartment.SelectedValue);
            }
            if (ddl_Employee.SelectedIndex > 0)
            {
                _obj_smhr_empAssetDoc.EMPASSETDOC_EMP_ID = Convert.ToInt32(ddl_Employee.SelectedValue);
            }
            dt_EmpAssets = BLL.get_EmpAssetDoc(_obj_smhr_empAssetDoc);
            return dt_EmpAssets;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmassetdoc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return dt_EmpAssets;
        }
        #region MyRegion
        //  if (dt_EmpAssets.Rows.Count > 0)
        //  {          
        //for (int a = 0; a < RL_Type.Items.Count; a++)
        //{
        //    if ((dt_EmpAssets.Rows[0]["EMP_ASSETDOC_AD_Type"]) != (System.DBNull.Value))
        //    {
        //        string strAdType = Convert.ToString(dt_EmpAssets.Rows[0]["EMP_ASSETDOC_AD_Type"]);
        //        string[] strSplit = strAdType.Split(new char[] { ',' });
        //        for (int c = 0; c < strSplit.Length; c++)
        //        {
        //            if ((RL_Type.Items[a].Value) == Convert.ToString(strSplit[c]))
        //            {
        //                RL_Type.Items[a].Checked = true;
        //            }
        //        }
        //    }
        //}           
        //  BLL.ShowMessage(this, "Employee is already assigned with the asset(s) from the below Department");
        //     return;
        #endregion
    }
    private void getSerialID()
    {
        try
        {
            if (Convert.ToString(Request.QueryString["type"]) == "asset")
            {
                if (ddl_Employee.SelectedIndex != 0 && ddl_Employee.SelectedItem.Value != "")
                {
                    _obj_smhr_empAssetDoc.OPERATION = operation.Check;
                    _obj_smhr_empAssetDoc.EMPASSETDOC_EMP_ID = Convert.ToInt32(ddl_Employee.SelectedItem.Value);
                    _obj_smhr_empAssetDoc.EMPASSETDOC_TYPE = txt_Type.Text;
                    _obj_smhr_empAssetDoc.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DT_Details = BLL.get_EmpAssetDoc(_obj_smhr_empAssetDoc);
                    if (DT_Details.Rows.Count != 0)
                    {
                        txt_Serial.Text = Convert.ToString(Convert.ToInt32(DT_Details.Rows.Count + 1) + 1);
                    }
                    else
                    {
                        txt_Serial.Text = "1";
                    }
                }
            }
            else
            {
                if (ddl_Employee.SelectedIndex != 1 && ddl_Employee.SelectedItem.Value != "")
                {
                    _obj_smhr_empAssetDoc.OPERATION = operation.Check;
                    _obj_smhr_empAssetDoc.EMPASSETDOC_EMP_ID = Convert.ToInt32(ddl_Employee.SelectedItem.Value);
                    _obj_smhr_empAssetDoc.EMPASSETDOC_TYPE = txt_Type.Text;
                    _obj_smhr_empAssetDoc.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DT_Details = BLL.get_EmpAssetDoc(_obj_smhr_empAssetDoc);
                    if (DT_Details.Rows.Count != 0)
                    {
                        txt_Serial.Text = Convert.ToString(Convert.ToInt32(DT_Details.Rows.Count + 1) + 1);

                    }
                    else
                    {
                        txt_Serial.Text = "1";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmassetdoc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    private static void getCheckedItems(RadListBox listBox, Label label)
    {
        try
        {
            string strVal = label.Text;
            int i = 0;
            Array Ar = strVal.Split(new Char[] { ',' });
            for (i = 0; i < Ar.Length; i++)
            {
                //listBox.SelectedIndex = listBox.FindItemIndexByValue(Convert.ToString(Ar.GetValue(i)).Trim());
                listBox.SelectedValue = Convert.ToString(Ar.GetValue(i));
                listBox.Items[i].Checked = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(HttpContext.Current.Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmassetdoc", ex.StackTrace, DateTime.Now);
            HttpContext.Current.Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

    }
    private void getDetails(string ID)
    {
        try
        {
            _obj_smhr_empAssetDoc.OPERATION = operation.Insert;
            _obj_smhr_empAssetDoc.EMPASSETDOC_ID = Convert.ToInt32(ID);
            _obj_smhr_empAssetDoc.EMPASSETDOC_TYPE = Convert.ToString(Request.QueryString["type"]);
            _obj_smhr_empAssetDoc.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DT_Details = BLL.get_EmpAssetDoc(_obj_smhr_empAssetDoc);
            if (DT_Details.Rows.Count != 0)
            {
                ddl_BusinessUnit.SelectedIndex = ddl_BusinessUnit.Items.FindItemIndexByValue(Convert.ToString(DT_Details.Rows[0]["EMPASSETDOC_BU_ID"]));
                Load_Directorate();
                rad_Directorate.SelectedValue = Convert.ToString(DT_Details.Rows[0]["DIRECTORATE_ID"]);
                rad_Directorate.Enabled = false;
                LoadDepartments();

                rad_Department.SelectedValue = Convert.ToString(DT_Details.Rows[0]["EMP_DEPARTMENT_ID"]);
                rad_Department.Enabled = false;
                rad_AssetDepartment.SelectedValue = Convert.ToString(DT_Details.Rows[0]["EMPASSETDOC_DEPT_ID"]); ;
                rad_AssetDepartment.Enabled = false;
                SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
                _obj_smhr_emp_payitems.OPERATION = operation.Empty;
                ////LoadEmployees();
                LoadEmployees_Edit();
                lbl_EmployeeName.Text = Convert.ToString(DT_Details.Rows[0]["EMPASSETDOC_EMP_ID"]);
                ddl_Employee.SelectedValue = Convert.ToString(DT_Details.Rows[0]["EMPASSETDOC_EMP_ID"]);
                if (Convert.ToString(Request.QueryString["type"]) == "asset")
                {
                    LoadAllAssets();
                }
                else
                {
                    _obj_smhr_masters = new SMHR_MASTERS();
                    _obj_smhr_masters.OPERATION = operation.Select;
                    _obj_smhr_masters.MASTER_TYPE = "DOCUMENTS";
                    _obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);
                    ddlType.DataSource = dt_Details;
                    ddlType.DataValueField = "HR_MASTER_ID";
                    ddlType.DataTextField = "HR_MASTER_CODE";
                    ddlType.DataBind();

                    ddlType.Items.Insert(0, new RadComboBoxItem("Select"));
                }
                // LoadAllAssets();
                RFV_Employee.InitialValue = "";

                txt_Type.Text = Convert.ToString(DT_Details.Rows[0]["EMPASSETDOC_TYPE"]);
                txt_Serial.Text = Convert.ToString(DT_Details.Rows[0]["EMPASSETDOC_SERIAL"]);
                //loop ing values
                if (Convert.ToString(Request.QueryString["type"]) == "asset")
                {
                    foreach (DataRow dr in DT_Details.Rows)
                    {
                        if ((dr["EMPASSET_ASSETID"]) != (System.DBNull.Value))
                        {
                            if (ddlType.Items != null && ddlType.Items.Count > 0)
                            {
                                ddlType.Items.Remove(ddlType.FindItemIndexByValue(Convert.ToString(dr["EMPASSET_ASSETID"])));
                                //ddlType.Items.Insert(0, new RadComboBoxItem("Select"));
                            }

                        }
                    }
                }
                if (Convert.ToString(Request.QueryString["type"]) == "doc")
                {
                    //_obj_smhr_empAssetDoc.OPERATION = operation.Get;
                    //_obj_smhr_empAssetDoc.EMPDOCS_ASSETDOC_ID = Convert.ToInt32(ID);
                    //DataTable dt_docs = BLL.get_EmpAssetDoc(_obj_smhr_empAssetDoc);
                    rg_docs.DataSource = DT_Details;
                    rg_docs.DataBind();
                    Session["dt_Docs"] = DT_Details;
                    tr_rg_docs.Visible = true;
                    tr_rg_assets.Visible = false;
                }
                else
                {
                    rg_Assets.DataSource = DT_Details;


                    rg_Assets.DataBind();
                    /*added by anusha*/
                    Session["dt_ASEET"] = DT_Details;
                    tr_rg_assets.Visible = true;
                    tr_rg_docs.Visible = false;
                }

            }
            else
            {
                tr_rg_assets.Visible = false;
                rg_Assets.DataSource = null;
                rg_Assets.DataBind();
            }
            ddl_Employee.Enabled = false;
            ddl_BusinessUnit.Enabled = false;

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmassetdoc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    private void clearFields()
    {
        ddl_BusinessUnit.SelectedIndex = -1;
        ddlType.Text = string.Empty;
        ddl_Employee.Items.Clear();
        //ddl_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
        //    ddlType.SelectedIndex = -1;
        // rcmb_Businessunit.Items.Clear();
        //  rcmb_Businessunit.Items.Insert(0, new RadComboBoxItem("Select"));
        txt_Serial.Text = "";
        chk_Returnable.Checked = false;
        txt_Date.MinDate = Convert.ToDateTime("01/01/1900");
        txt_Remarks.Text = "";
        txt_Date.SelectedDate = null;
        // txt_Name.Text = "";
        //  txt_Code.Text = "";
        if (Convert.ToString(Request.QueryString["type"]) == "asset")
        {
            ddlType.Items.Clear();
            ddlType.ClearSelection();
        }
        else
        {
            ddlType.ClearSelection();
        }
        rad_Department.ClearSelection();
        // txt_Receiveddate.SelectedDate = null;
        //rtxt_Received.Text = string.Empty;//Previously
        //  rcmb_Employee.ClearSelection();//newly
        ddl_Employee.Items.Clear();
        ddl_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
        //  lblReceived_tr.Visible = false;
        // lblReceivedDate_tr.Visible = false;
        rad_Department.Items.Clear();
        rad_Department.Items.Insert(0, new RadComboBoxItem("Select"));
        rad_AssetDepartment.Items.Clear();
        rad_AssetDepartment.Items.Insert(0, new RadComboBoxItem("Select"));
        rad_Directorate.Items.Clear();
        rad_Directorate.Items.Insert(0, new RadComboBoxItem("Select"));


    }
    protected void RG_AssetDoc_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadData();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmassetdoc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    private bool chk_Validate()
    {
        try
        {
            _obj_smhr_employee = new SMHR_EMPLOYEE();
            _obj_smhr_employee.OPERATION = operation.Select;
            _obj_smhr_employee.EMP_ID = Convert.ToInt32(ddl_Employee.SelectedValue);
            _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Details = BLL.get_Employee(_obj_smhr_employee);
            if (dt_Details.Rows.Count != 0)
            {
                if (Convert.ToDateTime(Convert.ToString(dt_Details.Rows[0]["EMP_DOJ"])) > Convert.ToDateTime(txt_Date.SelectedDate.Value))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmassetdoc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return false;
        }
    }
    public static DataTable removeNullColumnFromDataTable(DataTable dt)
    {
        try
        {
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                if (dt.Rows[i][0].ToString() == null)
                    dt.Rows[0].Delete();
            }
            return dt;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(HttpContext.Current.Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmassetdoc", ex.StackTrace, DateTime.Now);
            HttpContext.Current.Response.Redirect("~/Frm_ErrorPage.aspx");
            return dt;
        }
    }
    private void LoadEmployees()
    {
        try
        {
            SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
            //_obj_smhr_emp_payitems.OPERATION = operation.Empty;
            DataTable DT_Details = new DataTable();
            if (ddl_BusinessUnit.SelectedItem.Value != "")
            {
                #region MyRegion
                //if (Convert.ToString(Session["SELFSERVICE"]) == "")
                //{
                //    _obj_smhr_emp_payitems.OPERATION = operation.Empty_Self;
                //    _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(ddl_BusinessUnit.SelectedItem.Value);
                //    _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //    _obj_smhr_emp_payitems.REPORTING_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                //    DT_Details = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
                //    if (DT_Details.Rows.Count != 0)
                //    {
                //        BindEmployees(DT_Details);
                //    }
                //    else
                //    {
                //        BindEmployees(DT_Details);
                //    }
                //}
                //else
                //{

                //    _obj_smhr_emp_payitems.OPERATION = operation.Empty; Commneted as the employees are filtered BU Wise BY Ragha Sudha on 4th oct 2013
                // _obj_smhr_emp_payitems.OPERATION = operation.EmployeesDirectoratewise; //Inserted BY Ragha Sudha on 4th oct 2013 for directoratewise 
                #endregion
                _obj_smhr_emp_payitems.OPERATION = operation.Empty;
                _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(ddl_BusinessUnit.SelectedItem.Value);
                _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                if (rad_Directorate.SelectedIndex > 0)
                {
                    _obj_smhr_emp_payitems.OPERATION = operation.EmployeesDirectoratewise;
                    _obj_smhr_emp_payitems.DIRECTORATE_ID = Convert.ToInt32(rad_Directorate.SelectedItem.Value);
                }
                if (rad_Department.SelectedIndex > 0)
                {
                    _obj_smhr_emp_payitems.OPERATION = operation.EmployeesDepartmentwise;
                    _obj_smhr_emp_payitems.DEPARTMENT_ID = Convert.ToInt32(rad_Department.SelectedItem.Value);
                }
                DT_Details = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
                if (DT_Details.Rows.Count != 0)
                {
                    BindEmployees(DT_Details);
                }
                else
                {
                    BindEmployees(DT_Details);
                }
                //}
            }
            else
            {
                BindEmployees(DT_Details);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmassetdoc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    private void LoadEmployees_Edit()
    {
        try
        {
            SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
            //_obj_smhr_emp_payitems.OPERATION = operation.Empty;
            DataTable DT_Details = new DataTable();
            if (ddl_BusinessUnit.SelectedItem.Value != "")
            {
                //if (Convert.ToString(Session["SELFSERVICE"]) == "")
                //{
                //    _obj_smhr_emp_payitems.OPERATION = operation.Empty_Self;
                //    _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(ddl_BusinessUnit.SelectedItem.Value);
                //    _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //    _obj_smhr_emp_payitems.REPORTING_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                //    DT_Details = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
                //    if (DT_Details.Rows.Count != 0)
                //    {
                //        BindEmployees(DT_Details);
                //    }
                //    else
                //    {
                //        BindEmployees(DT_Details);
                //    }
                //}
                //else
                //{
                _obj_smhr_emp_payitems.OPERATION = operation.Empty1;
                _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(ddl_BusinessUnit.SelectedItem.Value);
                _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DT_Details = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
                if (DT_Details.Rows.Count != 0)
                {
                    BindEmployees(DT_Details);
                }
                else
                {
                    BindEmployees(DT_Details);
                }
                //}
            }
            else
            {
                BindEmployees(DT_Details);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmassetdoc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    private void BindEmployees(DataTable DT_Details)
    {
        try
        {
            ddl_Employee.DataSource = DT_Details;
            ddl_Employee.DataTextField = "EMPNAME";
            ddl_Employee.DataValueField = "EMP_ID";
            ddl_Employee.DataBind();
            ddl_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmassetdoc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void ddl_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (ddl_BusinessUnit.SelectedIndex > 0)
            {
                ddl_Employee.Items.Clear();
                rad_Department.Items.Clear();
                rad_AssetDepartment.Items.Clear();
                rad_AssetDepartment.Items.Clear();
                ddl_Employee.ClearSelection();
                rad_Directorate.Items.Clear();
                //RL_Type.Items.Clear();
                //RL_Type.ClearChecked();
                ddl_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
                rad_AssetDepartment.Items.Insert(0, new RadComboBoxItem("Select"));
                Load_Directorate();
                LoadDepartments();
                LoadEmployees();
            }
            else
            {
                ddl_Employee.Items.Clear();
                rad_Department.Items.Clear();
                rad_AssetDepartment.Items.Clear();
                ddl_Employee.ClearSelection();
                rad_Directorate.Items.Clear();
                rad_Department.Items.Insert(0, new RadComboBoxItem("Select"));
                rad_AssetDepartment.Items.Insert(0, new RadComboBoxItem("Select"));
                rad_Directorate.Items.Insert(0, new RadComboBoxItem("Select"));
                ddl_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
                if (Convert.ToString(Request.QueryString["type"]) == "asset")
                {
                    ddlType.Items.Clear();
                }
                else
                {
                    ddlType.ClearSelection();
                }
            }
            tr_rg_assets.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmassetdoc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void rad_Department_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            tr_rg_assets.Visible = false;
            ddl_Employee.Items.Clear();
            if (rad_Department.SelectedIndex > 0)
            {
                LoadEmployees();
            }
            else
            {
                ddl_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmassetdoc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void rad_Directorate_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            tr_rg_assets.Visible = false;
            rad_Department.Items.Clear();
            if (Convert.ToString(Request.QueryString["type"]) == "asset")
            {
                ddlType.Items.Clear();
            }
            rad_AssetDepartment.Items.Clear();
            rad_AssetDepartment.Text = string.Empty;
            if (rad_Directorate.SelectedIndex > 0)
            {
                LoadDepartments();
                LoadEmployees();
            }
            else
            {
                if (Convert.ToString(Request.QueryString["type"]) == "asset")
                {

                    rad_Department.Text = string.Empty;
                    rad_Department.Items.Clear();
                    rad_Department.Items.Insert(0, new RadComboBoxItem("Select"));
                    rad_AssetDepartment.Text = string.Empty;
                    rad_AssetDepartment.ClearSelection();
                    rad_AssetDepartment.Items.Clear();
                    rad_AssetDepartment.Items.Insert(0, new RadComboBoxItem("Select"));
                    ddl_Employee.Text = string.Empty;
                    ddl_Employee.Items.Clear();
                    ddl_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
                    ddlType.Items.Clear();
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmassetdoc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void rad_AssetDepartment_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            tr_rg_assets.Visible = false;
            if (rad_AssetDepartment.SelectedIndex > 0)
            {
                ddlType.Visible = true;
                if (Convert.ToString(Request.QueryString["type"]) == "asset")
                {
                    DataTable dt_Count = LoadAssetsAssigned();
                    if (dt_Count != null)
                    {
                        if (dt_Count.Rows.Count > 0)
                        {
                            BLL.ShowMessage(this, "Employee is already assigned with the asset(s) from the below department");
                            //RL_Type.Items.Clear();
                            return;
                        }
                    }
                    ddlType.Visible = true;
                    LoadAllAssets();
                }
            }
            else
            {
                ddlType.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmassetdoc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmassetdoc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

    }
    protected void LoadAssets()
    {
        try
        {
            DataTable dt_EmpAssets = new DataTable();
            ArrayList ar_EmpAssets = new ArrayList();
            string str_EmpAssets = string.Empty;

            _obj_smhr_empAssetDoc.OPERATION = operation.get_Employee_Assets_Assigned;

            _obj_smhr_empAssetDoc.EMPASSETDOC_EMP_ID = Convert.ToInt32(ddl_Employee.SelectedValue);

            _obj_smhr_empAssetDoc.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            ddlType.Items.Clear();
            _obj_Smhr_AssetMaster = new SMHR_ASSET_MASTER();

            _obj_smhr_empAssetDoc.EMPASSETDOC_DEPT_ID = Convert.ToInt32(rad_AssetDepartment.SelectedValue);

            dt_EmpAssets = BLL.get_EmpAssetDoc(_obj_smhr_empAssetDoc);

            if (dt_EmpAssets.Rows.Count > 0)
            {
                ddlType.DataSource = dt_EmpAssets;
                ddlType.DataValueField = "ASSET_ID";
                ddlType.DataTextField = "ASSET_NAME";
                ddlType.DataBind();
                ddlType.Items.Insert(0, new RadComboBoxItem("Select"));
                ddlType.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmassetdoc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void LoadAllAssets()
    {
        try
        {
            DataTable dt_EmpAssets = new DataTable();
            ArrayList ar_EmpAssets = new ArrayList();
            string str_EmpAssets = string.Empty;
            _obj_smhr_empAssetDoc.OPERATION = operation.get_All_Assets;
            _obj_smhr_empAssetDoc.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            ddlType.Items.Clear();
            _obj_Smhr_AssetMaster = new SMHR_ASSET_MASTER();
            if (rad_AssetDepartment.SelectedIndex > 0)
            {
                _obj_smhr_empAssetDoc.EMPASSETDOC_DEPT_ID = Convert.ToInt32(rad_AssetDepartment.SelectedValue);
            }
            if (ddl_Employee.SelectedIndex > 0)
            {
                _obj_smhr_empAssetDoc.EMPASSETDOC_EMP_ID = Convert.ToInt32(ddl_Employee.SelectedValue);
            }
            dt_EmpAssets = BLL.get_EmpAssetDoc(_obj_smhr_empAssetDoc);
            if (dt_EmpAssets.Rows.Count > 0)
            {

                ddlType.DataSource = dt_EmpAssets;
                ddlType.DataValueField = "ASSET_ID";
                ddlType.DataTextField = "ASSET_NAME";
                ddlType.DataBind();
                ddlType.Items.Insert(0, new RadComboBoxItem("Select"));
            }
            else
            {
                if (rad_AssetDepartment.SelectedIndex > 0)
                {
                    BLL.ShowMessage(this, "Assets not existing in the Department");
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmassetdoc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    private void LoadType()
    {
        try
        {
            if (Convert.ToString(Request.QueryString["type"]) == "asset")
            {
                _obj_smhr_masters = new SMHR_MASTERS();
                _obj_smhr_masters.OPERATION = operation.Select;
                _obj_smhr_masters.MASTER_TYPE = "ASSETS";
                _obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);
                ddlType.DataSource = dt_Details;
                ddlType.DataValueField = "HR_MASTER_ID";
                ddlType.DataTextField = "HR_MASTER_CODE";
                ddlType.DataBind();
                // ddlType.Items.Insert(0, new RadComboBoxItem("Select"));
            }
            else
            {
                _obj_smhr_masters = new SMHR_MASTERS();
                _obj_smhr_masters.OPERATION = operation.Select;
                _obj_smhr_masters.MASTER_TYPE = "DOCUMENTS";
                _obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);
                ddlType.DataSource = dt_Details;
                ddlType.DataValueField = "HR_MASTER_ID";
                ddlType.DataTextField = "HR_MASTER_CODE";
                ddlType.DataBind();
                //  ddlType.Items.Insert(0, new RadComboBoxItem("Select"));
            }
            ddlType.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmassetdoc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void btn_Type_Save_Click1(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToString(Request.QueryString["type"]) == "asset")
            {
                SMHR_MASTERS _obj_Smhr_Masters = new SMHR_MASTERS();
                _obj_Smhr_Masters.MASTER_TYPE = "ASSETS";
                _obj_Smhr_Masters.MASTER_CODE = txt_Asset_Type.Text.Replace("'", "''");
                _obj_Smhr_Masters.MASTER_DESC = txt_Asset_Type.Text.Replace("'", "''");
                _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                _obj_Smhr_Masters.ISDELETED = false;
                _obj_Smhr_Masters.CREATEDBY = 1; // ### Need to Get the Session
                _obj_Smhr_Masters.CREATEDDATE = DateTime.Now;
                _obj_Smhr_Masters.LASTMDFBY = 1; // ### Need to Get the Session
                _obj_Smhr_Masters.LASTMDFDATE = DateTime.Now;
                _obj_Smhr_Masters.OPERATION = operation.Check;
                if (Convert.ToString(BLL.get_MasterRecords(_obj_Smhr_Masters).Rows[0]["Count"]) != "0")
                {
                    BLL.ShowMessage(this, "This  " + _obj_Smhr_Masters.MASTER_TYPE + " Already Exists");
                    return;

                }
                _obj_Smhr_Masters.OPERATION = operation.Insert;
                _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                if (BLL.set_Master(_obj_Smhr_Masters))
                {
                    LoadType();
                    txt_Asset_Type.Text = string.Empty;
                }
                else
                    BLL.ShowMessage(this, "Information Not Saved");

            }
            else
            {
                SMHR_MASTERS _obj_Smhr_Masters = new SMHR_MASTERS();
                _obj_Smhr_Masters.MASTER_TYPE = "DOCUMENTS";
                _obj_Smhr_Masters.MASTER_CODE = txt_Asset_Type.Text.Replace("'", "''");
                _obj_Smhr_Masters.MASTER_DESC = txt_Asset_Type.Text.Replace("'", "''");
                _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                _obj_Smhr_Masters.ISDELETED = false;
                _obj_Smhr_Masters.CREATEDBY = 1; // ### Need to Get the Session
                _obj_Smhr_Masters.CREATEDDATE = DateTime.Now;
                _obj_Smhr_Masters.LASTMDFBY = 1; // ### Need to Get the Session
                _obj_Smhr_Masters.LASTMDFDATE = DateTime.Now;
                _obj_Smhr_Masters.OPERATION = operation.Check;
                if (Convert.ToString(BLL.get_MasterRecords(_obj_Smhr_Masters).Rows[0]["Count"]) != "0")
                {
                    BLL.ShowMessage(this, "This  " + _obj_Smhr_Masters.MASTER_TYPE + " Already Exists");
                    return;

                }
                _obj_Smhr_Masters.OPERATION = operation.Insert;
                _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                if (BLL.set_Master(_obj_Smhr_Masters))
                {
                    LoadType();
                    txt_Asset_Type.Text = string.Empty;
                }
                else
                    BLL.ShowMessage(this, "Information Not Saved");

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmassetdoc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    #region MyRegion
    //protected void rcmb_Businessunit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    //{
    //    try
    //    {
    //        if (rcmb_Businessunit.SelectedIndex != 0)
    //        {
    //            _obj_SMHR_LoginInfo.BUID = Convert.ToInt32(rcmb_Businessunit.SelectedValue);
    //            _obj_smhr_empAssetDoc.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //            DataTable Dt_loadcombos = BLL.get_Employees(_obj_SMHR_LoginInfo);
    //         //   rcmb_Employee.DataSource = Dt_loadcombos;
    //          //  rcmb_Employee.DataTextField = "EMP_NAME";//"APPLICANT_FIRSTNAME";
    //          //  rcmb_Employee.DataValueField = "EMP_ID";
    //           // rcmb_Employee.DataBind();
    //            //rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
    //        }
    //        else
    //        {
    //            rcmb_Businessunit.ClearSelection();
    //            BLL.ShowMessage(this, "Select Businessunit");
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmassetdoc", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //        return;
    //    }
    //} 
    #endregion
    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        try
        {
            bool status = false;
            int emp_assetdoc_id = Convert.ToInt32(HF_ID.Value);
            _obj_smhr_empAssetDoc.OPERATION = operation.DelDoc;
            _obj_smhr_empAssetDoc.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_empAssetDoc.EMPASSETDOC_ID = Convert.ToInt32(emp_assetdoc_id);
            status = BLL.set_EmpAssetDoc(_obj_smhr_empAssetDoc);
            if (status == true)
            {
                BLL.ShowMessage(this, "The uploaded document has been deleted");
                RMP_AssetDoc.SelectedIndex = 0;
                LoadData();
                RG_AssetDoc.DataBind();
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmassetdoc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void createcontrols()
    {
        try
        {
            DataTable dt_Docs = new DataTable();
            dt_Docs.Rows.Clear();
            dt_Docs.Columns.Clear();
            dt_Docs.Columns.Add("EMPDOCS_ID");
            dt_Docs.Columns.Add("EMPDOCS_ASSETDOC_ID");
            dt_Docs.Columns.Add("EMPDOCS_NAME");
            dt_Docs.Columns.Add("EMPDOCS_UPLOAD");
            dt_Docs.PrimaryKey = new DataColumn[] { dt_Docs.Columns["EMPDOCS_ID"] };
            Session["dt_Docs"] = dt_Docs;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmassetdoc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Upload_Click(object sender, EventArgs e)
    {
        try
        {
            if (FUpload.HasFile)
            {
                if (Check_Combo(FUpload.FileName))
                {
                    if (Mode == 1)
                    {

                        DataTable dt_Docs = (DataTable)Session["dt_Docs"];
                        DataRow dr = dt_Docs.NewRow();
                        string filename = Convert.ToString(FUpload.FileName.Trim().Replace("'", "''"));
                        dr[0] = dt_Docs.Rows.Count + 1;
                        dr[2] = Convert.ToString(FUpload.FileName);
                        dt_Docs.Rows.Add(dr);
                        if (!string.IsNullOrEmpty(filename))
                        {
                            FUpload.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/EmpUploads/DocUploads/"), ddl_Employee.SelectedItem.Value + "_" + filename));
                            dr[3] = "~/EmpUploads/DocUploads/" + ddl_Employee.SelectedValue + "_" + filename;
                        }
                        dt_Docs.DefaultView.Sort = "EMPDOCS_NAME";
                        dt_Docs = dt_Docs.DefaultView.ToTable();
                        rg_docs.DataSource = dt_Docs;
                        rg_docs.DataBind();
                        Session["dt_Docs"] = dt_Docs;
                    }
                    else
                    {

                        _obj_smhr_empAssetDoc.EMPDOCS_ASSETDOC_ID = Convert.ToInt32(HF_ID.Value);
                        _obj_smhr_empAssetDoc.EMPDOCS_NAME = Convert.ToString(FUpload.FileName.Trim().Replace("'", "''"));
                        string filename = Convert.ToString(FUpload.FileName.Trim().Replace("'", "''"));
                        _obj_smhr_empAssetDoc.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                        if (!string.IsNullOrEmpty(filename))
                        {
                            FUpload.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/EmpUploads/DocUploads/"), ddl_Employee.SelectedItem.Value + "_" + filename));
                            _obj_smhr_empAssetDoc.EMPDOCS_UPLOAD = "~/EmpUploads/DocUploads/" + ddl_Employee.SelectedValue + "_" + filename;
                        }
                        else
                        {
                            _obj_smhr_empAssetDoc.EMPDOCS_UPLOAD = string.Empty;
                        }
                        _obj_smhr_empAssetDoc.OPERATION = operation.Insert1;
                        if (BLL.set_EmpAssetDoc(_obj_smhr_empAssetDoc))
                        {
                            _obj_smhr_empAssetDoc.OPERATION = operation.Get;
                            _obj_smhr_empAssetDoc.EMPDOCS_ASSETDOC_ID = Convert.ToInt32(HF_ID.Value);
                            DataTable dt_docs = BLL.get_EmpAssetDoc(_obj_smhr_empAssetDoc);
                            rg_docs.DataSource = dt_docs;
                            rg_docs.DataBind();
                            Session["dt_Docs"] = dt_docs;
                        }
                    }
                }
                else
                {
                    BLL.ShowMessage(this, "Selected file is already Uploaded.");
                    return;
                }
            }
            else
            {
                BLL.ShowMessage(this, "Please Browse Document before Upload.");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmassetdoc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    public bool Check_Combo(string filename)
    {
        try
        {
            DataTable dt_Docs = Session["dt_Docs"] as DataTable;
            bool status = true;

            for (int i = 0; i < dt_Docs.Rows.Count; i++)
            {
                if (Convert.ToString(dt_Docs.Rows[i][2]) == Convert.ToString(filename))
                {
                    status = false;
                }
            }

            return status;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmassetdoc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return false;
        }
    }
    protected void lbtn_download_OnCommand(object sender, CommandEventArgs e)
    {
        try
        {
            string str1 = Convert.ToString(e.CommandArgument).TrimStart('~', '/');
            string str2 = "../";
            string str = string.Concat(str2, str1);
            //string str_file = Server.MapPath(str);
            //string filename = Server.MapPath(Convert.ToString(e.CommandArgument));
            //FileInfo fileInfo = new FileInfo(filename);
            //if (fileInfo.Exists)
            //{
            //    //Response.Clear();//both are working

            //    //Response.AppendHeader("Content-Disposition", "attachment;filename=" + Convert.ToString(e.CommandName));

            //    //Response.ContentType = "application/octet-stream";
            //    //Response.Flush();
            //    //Response.WriteFile(fileInfo.FullName);
            //    Response.Clear();
            //    Response.AddHeader("Content-Disposition", "attachment;filename=" + fileInfo.Name);
            //    Response.AddHeader("Content-Length", fileInfo.Length.ToString());
            //    Response.ContentType = "application/octet-stream";
            //    Response.Flush();
            //    Response.WriteFile(fileInfo.FullName);
            //    // Response.End();

            //}

            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "<script>window.open('" + Convert.ToString(str) + "');</script>", false);

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmassetdoc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lbtn_delete_OnCommand(object sender, CommandEventArgs e)
    {
        try
        {
            _obj_smhr_empAssetDoc = new SMHR_EMPASSETDOC();
            string path = e.CommandArgument.ToString();
            _obj_smhr_empAssetDoc.OPERATION = operation.Delete;
            _obj_smhr_empAssetDoc.EMPDOCS_ID = Convert.ToInt32(Convert.ToString(e.CommandName));
            if (BLL.set_EmpAssetDoc(_obj_smhr_empAssetDoc))
                BLL.ShowMessage(this, "Document Deleted Successfully.");
            string strpath1 = Convert.ToString(e.CommandArgument);
            File.Delete(Server.MapPath(strpath1));
            int pos = strpath1.LastIndexOf(@"/");
            string filename = strpath1.Remove(pos);
            GetFileCount(filename);
            if (Mode == 1)
            {
                DataTable dt_Docs = Session["dt_Docs"] as DataTable;
                for (int index = 0; index < dt_Docs.Rows.Count; index++)
                {
                    if (Convert.ToString(dt_Docs.Rows[index][3]) == Convert.ToString(e.CommandArgument))
                    {
                        dt_Docs.Rows[index].Delete();
                        dt_Docs.AcceptChanges();
                    }
                }
                dt_Docs.DefaultView.Sort = "EMPDOCS_NAME";
                dt_Docs = dt_Docs.DefaultView.ToTable();
                rg_docs.DataSource = dt_Docs;
                rg_docs.DataBind();
                Session["dt_Docs"] = dt_Docs;
            }
            else
            {
                _obj_smhr_empAssetDoc.OPERATION = operation.Get;
                _obj_smhr_empAssetDoc.EMPDOCS_ASSETDOC_ID = Convert.ToInt32(HF_ID.Value);
                DataTable dt_docs = BLL.get_EmpAssetDoc(_obj_smhr_empAssetDoc);
                rg_docs.DataSource = dt_docs;
                rg_docs.DataBind();
                Session["dt_Docs"] = dt_docs;
            }
        }
        catch (Exception ex)
        {
            BLL.ShowMessage(this, "File Doesnt exist in this directory");
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmassetdoc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

    }
    public int GetFileCount(string filename)
    {
        int fileCount = 0;
        try
        {
            DirectoryInfo dirinfo = new DirectoryInfo(Server.MapPath(filename));
            DirectoryInfo[] subdirinfo = dirinfo.GetDirectories("*.*");
            FileInfo[] files = dirinfo.GetFiles();
            if (files.Length > 0)
            {
                fileCount = fileCount + files.Length;
            }
            else
            {
                dirinfo.Delete(true);
            }
        }
        catch (System.Exception ex)
        {
            BLL.ShowMessage(this, "File or Directory doesnt exist");
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmassetdoc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return fileCount;
    }
    public static bool ResponseFile(HttpRequest _Request, HttpResponse _Response, string _fileName, string _fullPath, long _speed)
    {

        FileStream myFile = new FileStream(_fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        BinaryReader br = new BinaryReader(myFile);
        try
        {

            _Response.AddHeader("Accept-Ranges", "bytes");
            _Response.Buffer = false;
            long fileLength = myFile.Length;
            long startBytes = 0;

            int pack = 10240; //10K bytes
            int sleep = (int)Math.Floor((double)(1000 * pack / _speed)) + 1;
            if (_Request.Headers["Range"] != null)
            {
                _Response.StatusCode = 206;
                string[] range = _Request.Headers["Range"].Split(new char[] { '=', '-' });
                startBytes = Convert.ToInt64(range[1]);
            }
            _Response.AddHeader("Content-Length", (fileLength - startBytes).ToString());
            if (startBytes != 0)
            {
                _Response.AddHeader("Content-Range", string.Format(" bytes {0}-{1}/{2}", startBytes, fileLength - 1, fileLength));
            }
            _Response.AddHeader("Connection", "Keep-Alive");
            _Response.ContentType = "application/octet-stream";
            _Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(_fileName, System.Text.Encoding.UTF8));

            br.BaseStream.Seek(startBytes, SeekOrigin.Begin);
            int maxCount = (int)Math.Floor((double)((fileLength - startBytes) / pack)) + 1;

            for (int i = 0; i < maxCount; i++)
            {
                if (_Response.IsClientConnected)
                {
                    _Response.BinaryWrite(br.ReadBytes(pack));
                    Thread.Sleep(sleep);
                }
                else
                {
                    i = maxCount;
                }
            }
        }

        catch (Exception ex)
        {
            BLL.Error_Log(HttpContext.Current.Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_upload", ex.StackTrace, DateTime.Now);
            HttpContext.Current.Response.Redirect("~/Frm_ErrorPage.aspx");
            return false;
        }
        finally
        {
            br.Close();
            myFile.Close();
        }
        //}
        //catch(Exception ex1)
        //{

        //    SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex1.TargetSite.ToString(), ex1.Message.Replace("'", "''"), "frm_upload", ex1.StackTrace, DateTime.Now);
        //    Response.Redirect("~/Frm_ErrorPage.aspx");
        //    return false;
        //}
        return true;
    }

    protected void rg_docs_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            DataTable dt_Docs = Session["dt_Docs"] as DataTable;
            rg_docs.DataSource = dt_Docs;
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmassetdoc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}