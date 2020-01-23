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
using System.Data.OleDb;

public partial class Masters_frm_Master : System.Web.UI.Page
{
    SMHR_MASTERS _obj_Smhr_Masters;
    //bool result;
    DataTable dt;
    string control = string.Empty;
    string strfilename2;
    DataSet ds = new DataSet();
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
 //             ////code for security privilage
                control = Convert.ToString(Request.QueryString["Control"]);
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //_obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString(lbl_Heading.Text);
                switch (control)
                {
                    case "BANK":
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Bank");
                        break;
                    case "EMPLOYEECATEGORY":
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Employee Category");
                        break;
                    case "SERVICE_PROVIDER_TYPE":
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Service Provider Type");
                        break;
                    case "Injury_Cause":
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Injury Cause");

                        break;
                    case "Injury_Type":
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Injury Type");

                        break;
                    case "Severity":
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Severity");
                        break;
                    case "COURSECATEGORY":
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Master Course");
                        break;
                    case "COURSETYPE":
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Course Type");
                        break;
                    case "GrievanceTypeMaster":
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Grievance Type Master");
                        break;
                    case "DisciplinaryTypeMaster":
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Disciplinary Type Master");
                        break;
                    case "GrievanceActionsMaster":
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Grievance Actions Master");
                        break;
                    case "DisciplinaryActionsMaster":
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Disciplinary Actions Master ");
                        break;
                    case "TRAININGCOSTTYPE":
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Cost Type");
                        break;
                    //               default:
                    //                       _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("89 ");
                    //                   RG_Master.Columns[1].HeaderText = "Name";
                    //break;

                    case "PAYMENTMODE":
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Payment Mode");
                        break;
                    case "IDENTIFICATIONTYPE":
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Identification Type");
                        break;
                    case "TYPECOST":
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Type of Cost");
                        break;


                    case "ProtectiveUniform":
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Protective Uniform");
                        break;
                    case "DOCUMENTS":
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Document Type");
                        break;
                    case "RESIGNATION":
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Reason for Resignation");
                        break;
                    case "LANGUAGE":
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Language");
                        break;
                    case "NATIONALITY":
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Nationality");
                        break;
                    case "QUALIFICATION":
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Qualification");
                        break;
                    case "RELATIONSHIP":
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Relationship");
                        break;
                    default:
                        lbl_Heading.Text = Convert.ToString(changetoTitle_Case(control));
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString(lbl_Heading.Text);
                        
                        break;
                }

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
                    RG_Master.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Save.Visible = false;
                    btn_Edit.Visible = false;
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
             rad_isactive1.Checked = false;
            }

            isactive.Visible = false;
            //  rad_isactive1.Checked = false;
            
               
            tblImportTemplate.Visible = false;

            if (RWM_MASTERS.Windows.Count > 0)
            {
                RWM_MASTERS.Windows.RemoveAt(0);
            }
            Page.Validate();
            control = Convert.ToString(Request.QueryString["Control"]);
            if ((Convert.ToString(control) == "SKILL") || (Convert.ToString(control) == "GRADE") || (Convert.ToString(control) == "BANK") || (Convert.ToString(control) == "EMPLOYEE CATEGORY") || (Convert.ToString(control) == "TRIBE") || (Convert.ToString(control) == "InjuryCause") || (Convert.ToString(control) == "InjuryType"))
            {
                rev_rtxt_MasterCode.Enabled = false;
            }
            else
            {
                rev_rtxt_MasterCode.Enabled = true;
            }
            SetHeaderNames(control);


            RG_Master.Columns[3].Visible = false;
            RG_Master.Columns[2].HeaderText = "Description";
            lbl_Desc.Text = "Description";
            //lbl_Details.Text = Convert.ToString(control + "&nbsp;DETAILS");
            switch (control)
            {
                case "BANK":
                    //lbl_Code.Text = Convert.ToString(changetoTitle_Case(control) + "&nbsp;Code");
                    //lbl_Desc.Text = Convert.ToString(changetoTitle_Case(control) + "&nbsp;Name");
                    lbl_Code.Text = Convert.ToString("Code");
                    lbl_Desc.Text = Convert.ToString("Name");
                    rftxt_MasterCode.ErrorMessage = "Please Enter Code";
                    rftxt_MasterDesc.Enabled = true;
                    RG_Master.Columns[1].HeaderText = "Code";
                    RG_Master.Columns[2].HeaderText = "Name";
                    break;
                case "EMPLOYEECATEGORY":
                    //lbl_Code.Text = Convert.ToString(strPageName + "&nbsp;Name");
                    lbl_Code.Text = "Name";
                    RG_Master.Columns[1].HeaderText = "Name";
                    break;
                case "SERVICE_PROVIDER_TYPE":
                    lbl_Code.Text = "Type";
                    RG_Master.Columns[1].HeaderText = "Name";
                    break;
                case "Injury_Cause":

                    //lbl_Code.Text = "Cause";
                    lbl_Code.Text = Convert.ToString("Cause");
                    lbl_Desc.Text = Convert.ToString("Description");
                    RG_Master.Columns[1].HeaderText = "Cause";
                    RG_Master.Columns[3].Visible = false;
                    break;
                case "Injury_Type":
                    lbl_Code.Text = "Type";
                    RG_Master.Columns[1].HeaderText = "Type";
                    RG_Master.Columns[3].Visible = false;

                    break;
                case "Severity":
                    lbl_Code.Text = "Name";
                    RG_Master.Columns[1].HeaderText = "Name";
                    RG_Master.Columns[3].Visible = false;
                    break;
                case "COURSECATEGORY":
                    lbl_Code.Text = "Master Course";//Course Category Name";
                    RG_Master.Columns[1].HeaderText = "Master Course";//Course Category Name";
                    RG_Master.Columns[3].Visible = true;
                    break;
                case "COURSETYPE":
                    lbl_Code.Text = "Course Type";
                    RG_Master.Columns[1].HeaderText = "Name";
                    RG_Master.Columns[3].Visible = false;
                    break;
                case "GrievanceTypeMaster":
                    lbl_Code.Text = "Grievance Type Master";//Grievance Type";
                    RG_Master.Columns[1].HeaderText = "Grievance Type";
                    break;
                case "DisciplinaryTypeMaster":
                    lbl_Code.Text = "Disciplinary Type Master";//Disciplinary Type";
                    RG_Master.Columns[1].HeaderText = "Disciplinary Type";
                    break;
                case "GrievanceActionsMaster":
                    lbl_Code.Text = "Grievance Actions Master";//Grievance Action";
                    RG_Master.Columns[1].HeaderText = "Grievance Action";
                    break;
                case "DisciplinaryActionsMaster":
                    lbl_Code.Text = "Disciplinary Actions Master";//Disciplinary Action";
                    RG_Master.Columns[1].HeaderText = "Disciplinary Action";
                    rftxt_MasterCode.ErrorMessage = "Please Enter Disciplinary Action";
                    break;
                case "TRAININGCOSTTYPE":
                    lbl_Code.Text = "Cost Type";
                    RG_Master.Columns[1].HeaderText = "Cost Type";
                    RG_Master.Columns[3].Visible = false;
                    rftxt_MasterCode.ErrorMessage = "Please Enter Cost Type";
                    break;
                default:
                    lbl_Code.Text = "&nbsp;Name";
                    RG_Master.Columns[1].HeaderText = "Name";
                    break;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Master", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void SetHeaderNames(string controlName)
    {
        try
        {
            string strPage = string.Empty;
            switch (controlName)
            {
                case "EMPLOYEECATEGORY":
                    strPage = "Employee&nbsp;Category";
                    lbl_Heading.Text = Convert.ToString(strPage);
                    lblheader.Text = Convert.ToString(strPage);
                    ldl_dl.Text = Convert.ToString(strPage);
                    break;
                case "EMPLOYEETYPE":
                    strPage = "Employee&nbsp;Type";
                    lbl_Heading.Text = Convert.ToString(strPage);
                    lblheader.Text = Convert.ToString(strPage);
                    ldl_dl.Text = Convert.ToString(strPage);
                    break;
                case "SERVICE_PROVIDER_TYPE":
                    strPage = "Service Provider Type";
                    lbl_Heading.Text = strPage;
                    lblheader.Text = strPage;
                    ldl_dl.Text = strPage;
                    break;
                case "Injury_Cause":
                    strPage = "Injury Cause";//Cause of Injury";
                    lbl_Code.Text = Convert.ToString("Cause");
                    lbl_Desc.Text = Convert.ToString("Description");
                    lbl_Heading.Text = Convert.ToString(strPage);
                    lblheader.Text = Convert.ToString(strPage);
                    ldl_dl.Text = Convert.ToString(strPage);
                    tblImportTemplate.Visible = false; //To hide Excel template
                    RG_Master.Columns[3].Visible = false;
                    rftxt_MasterCode.ErrorMessage = "Please Enter Cause";
                    break;
                case "Injury_Type":
                    strPage = "Injury Type";//Type of Injury";
                    lbl_Heading.Text = Convert.ToString(strPage);
                    lblheader.Text = Convert.ToString(strPage);
                    ldl_dl.Text = Convert.ToString(strPage);
                    tblImportTemplate.Visible = false;  //To hide Excel template
                    RG_Master.Columns[3].Visible = false;
                    rftxt_MasterCode.ErrorMessage = "Please Enter Type";
                    break;
                case "Severity":
                    strPage = "Severity";
                    lbl_Heading.Text = Convert.ToString(strPage);
                    lblheader.Text = Convert.ToString(strPage);
                    ldl_dl.Text = Convert.ToString(strPage);
                    tblImportTemplate.Visible = false;  //To hide Excel template
                    RG_Master.Columns[3].Visible = false;
                    rftxt_MasterCode.ErrorMessage = "Please Enter Name";
                    break;
                case "COURSECATEGORY":
                    strPage = "Course Category";
                    lbl_Heading.Text = Convert.ToString(strPage);
                    lblheader.Text = Convert.ToString(strPage);
                    ldl_dl.Text = Convert.ToString(strPage);
                    isactive.Visible = true;
                    RG_Master.Columns[3].Visible = true;
                    break;
                case "COURSETYPE":
                    strPage = "Course Type";
                    lbl_Heading.Text = Convert.ToString(strPage);
                    lblheader.Text = Convert.ToString(strPage);
                    ldl_dl.Text = Convert.ToString(strPage);
                    RG_Master.Columns[3].Visible = false;
                    break;
                case "GrievanceTypeMaster":
                    strPage = "Grievance Type ";
                    lbl_Heading.Text = Convert.ToString(strPage);
                    lblheader.Text = Convert.ToString(strPage);
                    ldl_dl.Text = Convert.ToString(strPage);
                    isactive.Visible = true;
                    RG_Master.Columns[3].Visible = true;
                    tblImportTemplate.Visible = false;
                    isactive.Visible = false;
                    rftxt_MasterCode.ErrorMessage = "Please Enter Grievance Type";
                    break;
                case "DisciplinaryTypeMaster":
                    strPage = "Disciplinary Type";
                    lbl_Heading.Text = Convert.ToString(strPage);
                    lblheader.Text = Convert.ToString(strPage);
                    ldl_dl.Text = Convert.ToString(strPage);
                    isactive.Visible = true;
                    tblImportTemplate.Visible = false;
                    RG_Master.Columns[3].Visible = true;
                    isactive.Visible = false;
                    rftxt_MasterCode.ErrorMessage = "Please Enter Disciplinary Type";
                    break;
                case "GrievanceActionsMaster":
                    strPage = "Grievance Action";
                    lbl_Heading.Text = Convert.ToString(strPage);
                    lblheader.Text = Convert.ToString(strPage);
                    ldl_dl.Text = Convert.ToString(strPage);
                    isactive.Visible = true;
                    tblImportTemplate.Visible = false;
                    RG_Master.Columns[3].Visible = true;
                    isactive.Visible = false;
                    rftxt_MasterCode.ErrorMessage = "Please Enter Grievance Action";
                    break;
                case "DisciplinaryActionsMaster":
                    strPage = "Disciplinary Action ";
                    lbl_Heading.Text = Convert.ToString(strPage);
                    lblheader.Text = Convert.ToString(strPage);
                    ldl_dl.Text = Convert.ToString(strPage); isactive.Visible = true;
                    tblImportTemplate.Visible = false;
                    RG_Master.Columns[3].Visible = true;
                    isactive.Visible = false;
                    break;
                case "PAYMENTMODE":
                    strPage = "Payment Mode";
                    lbl_Heading.Text = Convert.ToString(strPage);
                    lblheader.Text = Convert.ToString(strPage);
                    ldl_dl.Text = Convert.ToString(strPage);
                    break;
                case "IDENTIFICATIONTYPE":
                    strPage = "Identification Type";
                    lbl_Heading.Text = Convert.ToString(strPage);
                    lblheader.Text = Convert.ToString(strPage);
                    ldl_dl.Text = Convert.ToString(strPage);
                    break;
                case "TYPECOST":
                    strPage = "Type of Cost";
                    lblheader.Text = Convert.ToString(strPage);
                    ldl_dl.Text = Convert.ToString(strPage);
                    lbl_Heading.Text = strPage;   //lbl_Heading.Text = "Name";
                    RG_Master.Columns[3].Visible = false;
                    break;
                case "TRAININGCOSTTYPE":
                    strPage = "Cost Type";
                    lblheader.Text = Convert.ToString(strPage);
                    ldl_dl.Text = Convert.ToString(strPage);
                    RG_Master.Columns[3].Visible = false;
                    lbl_Heading.Text = "Cost Type";
                    break;
                case "ProtectiveUniform":
                    lbl_Heading.Text = Convert.ToString(changetoTitle_Case(control));
                    lblheader.Text = Convert.ToString(changetoTitle_Case(control));
                    ldl_dl.Text = Convert.ToString(changetoTitle_Case(control));
                    if (Convert.ToString(control) == "ProtectiveUniform")
                        lbl_Heading.Text = "Protective Uniform";
                    break;
                case "DOCUMENTS":
                    lbl_Heading.Text = "Document Type";
                    lblheader.Text = "Document Type";
                    ldl_dl.Text = "Document Type";
                    break;
                case "RESIGNATION":
                    lbl_Heading.Text = "Reason for Resignation";
                    lblheader.Text = "Reason for Resignation";
                    ldl_dl.Text = "Reason for Resignation";
                    break;
                default:
                    lbl_Heading.Text = Convert.ToString(changetoTitle_Case(control));
                    lblheader.Text = Convert.ToString(changetoTitle_Case(control));
                    ldl_dl.Text = Convert.ToString(changetoTitle_Case(control));
                    break;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Master", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private string changetoTitle_Case(string strParam)
    {
        String strTitleCase = strParam.Substring(0, 1).ToUpper();
        try
        {

            strParam = strParam.Substring(1).ToLower();
            String strPrev = "";

            for (int iIndex = 0; iIndex < strParam.Length; iIndex++)
            {
                if (iIndex > 1)
                {
                    strPrev = strParam.Substring(iIndex - 1, 1);
                }
                if (strPrev.Equals(" ") ||
                    strPrev.Equals("\t") ||
                    strPrev.Equals("\n") ||
                    strPrev.Equals("."))
                {
                    strTitleCase += strParam.Substring(iIndex, 1).ToUpper();
                }
                else
                {
                    strTitleCase += strParam.Substring(iIndex, 1);
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Master", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return strTitleCase;

    }

    protected void LoadGrid()
    {
        try
        {
            _obj_Smhr_Masters = new SMHR_MASTERS();
            _obj_Smhr_Masters.MASTER_TYPE = control.ToUpper();

            if (control.ToUpper() == "EMPLOYEECATEGORY")
            {
                _obj_Smhr_Masters.MASTER_TYPE = "CATEGORY";
            }
            else if (string.Compare(control, "SERVICE_PROVIDER_TYPE", true) == 0)
            {
                _obj_Smhr_Masters.MASTER_TYPE = "SERVICEPROVIDERTYPE";
            }
            else if (string.Compare(control, "COURSECATEGORY", true) == 0)
            {
                _obj_Smhr_Masters.MASTER_TYPE = "COURSE";
            }

            if (Convert.ToString(control) == "TYPECOST")
            {
                RG_Master.MasterTableView.Columns[1].HeaderText = "Name";
                //lbl_Code.Text = "Type of Cost";
            }
            //else
            //{
            //    //RG_Master.MasterTableView.Columns[1].HeaderText = "Name";
            //    //lbl_Code.Text = "Name";
            //}

            _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            RG_Master.DataSource = BLL.get_MasterRecords(_obj_Smhr_Masters);
            rm_MR_Page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Master", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void RG_Master_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Master", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            string popup_name = string.Empty;
            _obj_Smhr_Masters = new SMHR_MASTERS();

            _obj_Smhr_Masters.MASTER_TYPE = control.ToUpper();
            if (control.ToUpper() == "EMPLOYEECATEGORY")
            {
                _obj_Smhr_Masters.MASTER_TYPE = "CATEGORY";
            }
            else if (string.Compare(control, "SERVICE_PROVIDER_TYPE", true) == 0)
            {
                _obj_Smhr_Masters.MASTER_TYPE = "SERVICEPROVIDERTYPE";
                popup_name = "Service Provider Type";
            }
            else if (string.Compare(control, "COURSECATEGORY", true) == 0)
            {
                _obj_Smhr_Masters.MASTER_TYPE = "COURSE";
            }
            else if (string.Compare(control, "TRAININGCOSTTYPE", true) == 0)
            {
                _obj_Smhr_Masters.MASTER_TYPE = "TRAININGCOSTTYPE";
            }
            _obj_Smhr_Masters.MASTER_CODE = rtxt_MasterCode.Text.Replace("'", "''");
            _obj_Smhr_Masters.MASTER_DESC = rtxt_MasterDesc.Text.Replace("'", "''");
            if ((Convert.ToString(control) == "GrievanceTypeMaster") || (Convert.ToString(control) == "DisciplinaryTypeMaster") || (Convert.ToString(control) == "GrievanceActionsMaster") || (Convert.ToString(control) == "DisciplinaryActionsMaster") || string.Compare(control, "COURSECATEGORY", true) == 0)
                _obj_Smhr_Masters.IsActive = Convert.ToBoolean(rad_isactive1.Checked);
            _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_Smhr_Masters.ISDELETED = false;
            _obj_Smhr_Masters.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_Masters.CREATEDDATE = DateTime.Now;
            _obj_Smhr_Masters.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_Masters.LASTMDFDATE = DateTime.Now;

            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_SAVE":
                    _obj_Smhr_Masters.OPERATION = operation.Check;
                    if (Convert.ToString(BLL.get_MasterRecords(_obj_Smhr_Masters).Rows[0]["Count"]) != "0")
                    {
                        //BLL.ShowMessage(this, "This  " + changetoTitle_Case(popup_name) + " Already Exists");
                        BLL.ShowMessage(this, "The Record is Already Exists");
                        ClearFields();
                        rm_MR_Page.SelectedIndex = 1;
                        btn_Save.Visible = true;
                        return;

                    }
                    _obj_Smhr_Masters.OPERATION = operation.Insert;
                    if (BLL.set_Master(_obj_Smhr_Masters))
                    {
                        BLL.ShowMessage(this, "Information Saved Successfully");
                        rm_MR_Page.SelectedIndex = 0;
                        LoadGrid();
                        RG_Master.DataBind();

                    }

                    else
                        BLL.ShowMessage(this, "Information Not Saved");

                    break;

                case "BTN_EDIT":
                    _obj_Smhr_Masters.MASTER_ID = Convert.ToInt32(lbl_Master_ID.Text);
                    _obj_Smhr_Masters.OPERATION = operation.Check;
                    if (Convert.ToString(control) == "GrievanceTypeMaster" || Convert.ToString(control) == "DisciplinaryTypeMaster")
                    {
                        if (Convert.ToBoolean(rad_isactive1.Checked) == false)
                        {
                            SMHR_GRIEVANCE _obj_SMHR_GRIEVANCE = new SMHR_GRIEVANCE();
                            _obj_SMHR_GRIEVANCE.GRIEVANCE_INCIDENTTYPE_ID = Convert.ToInt32(lbl_Master_ID.Text);
                            _obj_SMHR_GRIEVANCE.OPERATION = operation.Check;
                            _obj_SMHR_GRIEVANCE.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                            DataTable dt = BLL.get_Incidents(_obj_SMHR_GRIEVANCE);
                            if (dt.Rows.Count > 0)
                            {
                                BLL.ShowMessage(this, "Cannot make inactive");
                                rad_isactive1.Checked = true;
                                return;
                            }
                        }
                    }
                    if (Convert.ToString(control) == "GrievanceActionsMaster" || Convert.ToString(control) == "DisciplinaryActionsMaster")
                    {
                        if (Convert.ToBoolean(rad_isactive1.Checked) == false)
                        {

                            SMHR_ACTIONTAKEN _obj_SMHR_ACTIONTAKEN = new SMHR_ACTIONTAKEN();
                            _obj_SMHR_ACTIONTAKEN.OPERATION = operation.Check;
                            _obj_SMHR_ACTIONTAKEN.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                            _obj_SMHR_ACTIONTAKEN.ACTION_DISPORGRIV_ID = Convert.ToInt32(lbl_Master_ID.Text);
                            DataTable dtaction = BLL.get_SMHR_ACTIONTAKEN1(_obj_SMHR_ACTIONTAKEN);
                            if (dtaction.Rows.Count > 0)
                            {
                                BLL.ShowMessage(this, "Cannot make inactive");
                                rad_isactive1.Checked = true;
                                return;
                            }
                        }
                    }
                    if (Convert.ToString(BLL.get_MasterRecords(_obj_Smhr_Masters).Rows[0]["Count"]) != "1")
                    {
                        BLL.ShowMessage(this, "This  " + changetoTitle_Case(_obj_Smhr_Masters.MASTER_TYPE) + " Already Exists");
                        return;

                    }

                    if (string.Compare(control, "COURSECATEGORY", true) == 0)
                    {
                        if (Convert.ToBoolean(rad_isactive1.Checked) == false)
                        {
                            SMHR_COURSE _obj_course = new SMHR_COURSE();
                            _obj_course.OPERATION = operation.Scale;
                            _obj_course.COURSE_ORG_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                            _obj_course.COURSE_CATEGORYID = (lbl_Master_ID.Text);
                            DataTable dtc = BLL.get_Course(_obj_course);
                            if (!Convert.ToBoolean(dtc.Rows[0]["Status"]))
                            {
                                BLL.ShowMessage(this, "Please Change Course Status to InActive for this Course Category");
                                rad_isactive1.Checked = true;
                                return;
                            }
                        }
                    }

                    _obj_Smhr_Masters.OPERATION = operation.Update;
                    if (BLL.set_Master(_obj_Smhr_Masters))
                    {
                        BLL.ShowMessage(this, "Information Updated Successfully");
                        rm_MR_Page.SelectedIndex = 0;
                        LoadGrid();
                        RG_Master.DataBind();

                    }
                    else
                        BLL.ShowMessage(this, "Information Not Updated");

                    break;



            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Master", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        //rm_MR_Page.SelectedIndex = 0;
        //LoadGrid();
        //RG_Master.DataBind();


    }

    protected void lnk_Add_Click(object sender, EventArgs e)
    {
        try
        {
            control = Convert.ToString(Request.QueryString["Control"]);
            ClearFields();
            rad_isactive1.Checked = true;
            btn_Save.Visible = true;
            btn_Edit.Visible = false;
            rm_MR_Page.SelectedIndex = 1;
            if (Convert.ToString(control) == "GrievanceTypeMaster" || Convert.ToString(control) == "DisciplinaryTypeMaster" || Convert.ToString(control) == "GrievanceActionsMaster" || Convert.ToString(control) == "DisciplinaryActionsMaster")
            {

                rad_isactive1.Checked = true;


            }
            //if (Convert.ToString(control) == "TYPECOST")
            //    lbl_Code.Text = "Type of Cost";
            //else 
            if (Convert.ToString(control) == "BANK")
                lbl_Code.Text = "Code";
            else if (string.Compare(control, "TRAININGCOSTTYPE", true) == 0)
            {
                lbl_Code.Text = "Cost Type";
            }
            else if (string.Compare(control, "Injury_Cause", true) == 0)
            {
                lbl_Code.Text = Convert.ToString("Cause");
            }
            else if (string.Compare(control, "Injury_Type", true) == 0)
            {
                lbl_Code.Text = Convert.ToString("Type");
            }
            else if (string.Compare(control, "DisciplinaryActionsMaster", true) == 0)
            {
                lbl_Code.Text = "Disciplinary Action";
            }
            else if (string.Compare(control, "GrievanceActionsMaster", true) == 0)
            {
                lbl_Code.Text = "Grievance Action";
            }
            else if (string.Compare(control, "DisciplinaryTypeMaster", true) == 0)
            {
                lbl_Code.Text = "Disciplinary Type";
            }
            else if (string.Compare(control, "GrievanceTypeMaster", true) == 0)
            {
                lbl_Code.Text = "Grievance Type";
            }
            else
                lbl_Code.Text = "Name";

            //rad_IsActive.Checked = true;
            //rad_IsActive.Enabled = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Master", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_MasterEdit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            //  rad_IsActive.Enabled = true;
            lbl_Master_ID.Text = Convert.ToString(e.CommandArgument);
            _obj_Smhr_Masters = new SMHR_MASTERS();
            _obj_Smhr_Masters.MASTER_ID = Convert.ToInt32(lbl_Master_ID.Text);
            _obj_Smhr_Masters.MASTER_TYPE = control.ToUpper();

            if (Convert.ToString(control) == "TYPECOST")
                lbl_Code.Text = "Name";
            else if (Convert.ToString(control) == "BANK")
                lbl_Code.Text = "Code";
            else if (string.Compare(control, "Injury_Type", true) == 0)
            {
                lbl_Code.Text = Convert.ToString("Type");
            }
            else if (string.Compare(control, "Injury_Cause", true) == 0)
            {
                lbl_Code.Text = Convert.ToString("Cause");
            }
            else if (string.Compare(control, "DisciplinaryActionsMaster", true) == 0)
            {
                lbl_Code.Text = "Disciplinary Action";
            }
            else if (string.Compare(control, "GrievanceActionsMaster", true) == 0)
            {
                lbl_Code.Text = "Grievance Action";
            }
            else if (string.Compare(control, "DisciplinaryTypeMaster", true) == 0)
            {
                lbl_Code.Text = "Disciplinary Type";
            }
            else if (string.Compare(control, "GrievanceTypeMaster", true) == 0)
            {
                lbl_Code.Text = "Grievance Type";
            }
            else if (string.Compare(control, "TRAININGCOSTTYPE", true) == 0)
            {
                lbl_Code.Text = "Cost Type";
            }
            else
                lbl_Code.Text = "Name";

            if (control.ToUpper() == "EMPLOYEECATEGORY")
            {
                _obj_Smhr_Masters.MASTER_TYPE = "CATEGORY";
            }
            else if (string.Compare(control, "SERVICE_PROVIDER_TYPE", true) == 0)
            {
                _obj_Smhr_Masters.MASTER_TYPE = "SERVICEPROVIDERTYPE";
            }
            else if (string.Compare(control, "COURSECATEGORY", true) == 0)
            {
                _obj_Smhr_Masters.MASTER_TYPE = "COURSE";
            }
            else if (string.Compare(control, "TRAININGCOSTTYPE", true) == 0)
            {
                _obj_Smhr_Masters.MASTER_TYPE = "TRAININGCOSTTYPE";
            }

            _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt = BLL.get_MasterRecords(_obj_Smhr_Masters);

            rtxt_MasterCode.Text = Convert.ToString(dt.Rows[0]["HR_MASTER_CODE"]);
            rtxt_MasterDesc.Text = Convert.ToString(dt.Rows[0]["HR_MASTER_DESC"]);
            rad_isactive1.Checked = Convert.ToBoolean(dt.Rows[0]["HR_MASTER_STATUS"]);

            if ((Convert.ToString(control) == "GrievanceTypeMaster") || (Convert.ToString(control) == "DisciplinaryTypeMaster") || (Convert.ToString(control) == "GrievanceActionsMaster") || (Convert.ToString(control) == "DisciplinaryActionsMaster"))
                rad_isactive1.Checked = Convert.ToBoolean(dt.Rows[0]["HR_MASTER_STATUS"]);

            btn_Save.Visible = false;

            //code for security
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Edit.Visible = false;

            }

            else
            {
                btn_Edit.Visible = true;
            }

            rm_MR_Page.SelectedIndex = 1;
            //if (Convert.ToString(control) == "BANK")
            //{
            //    rtxt_MasterCode.Enabled = true;
            //}
            //else
            //{
            rtxt_MasterCode.Enabled = false;
            //}

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Master", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void ClearFields()
    {
        try
        {
            rtxt_MasterCode.Text = String.Empty;
            rtxt_MasterDesc.Text = String.Empty;
            btn_Save.Visible = false;
            btn_Edit.Visible = false;
            rtxt_MasterCode.Enabled = true;
            rm_MR_Page.SelectedIndex = 0;
            rad_isactive1.Checked = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Master", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            ClearFields();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Master", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_import_Click(object sender, EventArgs e)
    {
        try
        {
            string strcon = null;

            string strfilename1 = fu_masters.FileName;
            strfilename2 = Convert.ToString(DateTime.Now.TimeOfDay) + "_" + strfilename1;
            strfilename2 = strfilename2.Replace("/", "").Replace(":", ".");
            if (fu_masters.HasFile)
            {

                if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == false)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath("~/IMPORT_EXCEL/"));

                }



                fu_masters.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/IMPORT_EXCEL/"), strfilename2));
                string filename1 = Server.MapPath("~/IMPORT_EXCEL/") + ("") + (Convert.ToString(strfilename2));
                FileInfo fileInfo = new FileInfo(filename1);
                if (fileInfo.Exists)
                {
                    string path = MapPath(strfilename1);
                    // string name = Path.GetFileName( path );
                    string ext = Path.GetExtension(path);

                    string type = string.Empty;
                    //  set known types based on file extension  
                    if (ext != null)
                    {
                        switch (ext.ToLower())
                        {

                            case ".xls":

                                type = "excel";
                                break;
                            case ".xlsx":
                                type = "excel";
                                break;

                            default:
                                type = string.Empty;
                                break;
                        }
                    }
                    if (type == string.Empty)
                    {
                        if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == true)
                        {

                            string path1 = Server.MapPath("~/IMPORT_EXCEL/") + ("") + (Convert.ToString(strfilename2));
                            System.IO.File.Delete(path1);
                        }
                        BLL.ShowMessage(this, "Please select the Excel File  (Eg: Excel.xlsx). ");
                        return;
                    }
                }
            }


            else
            {
                BLL.ShowMessage(this, "Please Select the File to be uploaded");
                return;
            }
            string strpath = Server.MapPath("~/IMPORT_EXCEL/");

            strpath = strpath + strfilename2;


            // Getting data from excell file to dataset.
            strcon = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source='" + strpath + "';" + "Extended Properties=Excel 12.0;";


            OleDbConnection objConn = null;
            objConn = new OleDbConnection(strcon);
            objConn.Open();

            DataTable dt_chk2 = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string sheetname;
            if (dt_chk2 == null)
            {
                objConn.Close();
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            else
            {
                sheetname = Convert.ToString(dt_chk2.Rows[0]["TABLE_NAME"]);
            }
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM  [" + sheetname + "]", strcon);



            da.Fill(ds);

            objConn.Close();
            DataTable dt = new DataTable();
            DataTable dtfail = new DataTable();


            string errormsg = string.Empty;

            string projecttype = null;
            Int32 rowno = 0;


            string columnno = null;

            Boolean filestatus = true;
            dtfail.Columns.Add("S.NO", typeof(Int32));
            dtfail.Columns.Add("ROWNO", typeof(Int32));
            dtfail.Columns.Add("COLUMNS NAMES", typeof(string));

            if (!(ds.Tables[0].Columns[0].ToString().Trim() == "Name*"))
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }


            if (!(ds.Tables[0].Columns[1].ToString().Trim() == "Description"))
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (!(ds.Tables[0].Columns[2].ToString().Trim() == "Error Message"))
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Rows.Count == 0)
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Successfully processed Excel file. No Records are Imported.");
                return;
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                if (ds.Tables[0].Rows[i]["Name*"].ToString().Trim() != "")
                {
                    _obj_Smhr_Masters = new SMHR_MASTERS();

                    _obj_Smhr_Masters.MASTER_TYPE = control.ToUpper();
                    if (control.ToUpper() == "EMPLOYEECATEGORY")
                    {
                        _obj_Smhr_Masters.MASTER_TYPE = "CATEGORY";
                    }
                    _obj_Smhr_Masters.MASTER_CODE = ds.Tables[0].Rows[i]["Name*"].ToString().Trim();
                    _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                    _obj_Smhr_Masters.OPERATION = operation.Check;
                    if (Convert.ToString(BLL.get_MasterRecords(_obj_Smhr_Masters).Rows[0]["Count"]) != "0")
                    {
                        errormsg = lblheader.Text + " with this Name Already Exists";
                        filestatus = false;
                        rowno = i + 2;
                        columnno = "Name*";
                    }
                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = "Name*";
                }
                //if (!(ds.Tables[0].Rows[i]["Description"].ToString().Trim() != ""))
                //{
                //    filestatus = false;
                //    rowno = i + 2;
                //    columnno = columnno + "," + "Description";

                //}
                if (filestatus == false)
                {
                    DataRow newrow = dtfail.NewRow();
                    newrow["S.NO"] = dtfail.Rows.Count + 1;


                    newrow["ROWNO"] = rowno;
                    newrow["COLUMNS NAMES"] = columnno;
                    dtfail.Rows.Add(newrow);
                    ds.Tables[0].Rows[i]["Error Message"] = errormsg;
                }
            }
            if (dtfail.Rows.Count > 0)
            {
                Session["dt_fail"] = dtfail;
                Session["ds_data"] = ds;
                Delete_Excel_File();
                //LinkButton lnk_Import_process = (LinkButton)RadPanelBar1.FindItemByValue("AddAttachment").FindControl("lnk_Import_process");
                Telerik.Web.UI.RadWindow newwindow = new Telerik.Web.UI.RadWindow();
                // RWM_POSTREPLY.Windows.Remove(newwindow);
                newwindow.ID = "RadWindow_import";

                newwindow.NavigateUrl = "~/Payroll/frm_AttendanceImportProcess.aspx";
                newwindow.Title = "Import Process";
                newwindow.Width = 1150;
                newwindow.Height = 580;
                newwindow.VisibleOnPageLoad = true;
                if (RWM_MASTERS.Windows.Count > 1)
                {
                    RWM_MASTERS.Windows.RemoveAt(1);
                }
                RWM_MASTERS.Windows.Add(newwindow);



                RWM_MASTERS.Visible = true;
                return;

            }
            else
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    _obj_Smhr_Masters = new SMHR_MASTERS();

                    _obj_Smhr_Masters.MASTER_TYPE = control.ToUpper();
                    if (control.ToUpper() == "EMPLOYEECATEGORY")
                    {
                        _obj_Smhr_Masters.MASTER_TYPE = "CATEGORY";
                    }
                    _obj_Smhr_Masters.MASTER_CODE = ds.Tables[0].Rows[i]["Name*"].ToString().Trim();
                    _obj_Smhr_Masters.MASTER_DESC = ds.Tables[0].Rows[i]["Description"].ToString().Trim();
                    _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                    _obj_Smhr_Masters.ISDELETED = false;
                    _obj_Smhr_Masters.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                    _obj_Smhr_Masters.CREATEDDATE = DateTime.Now;
                    _obj_Smhr_Masters.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                    _obj_Smhr_Masters.LASTMDFDATE = DateTime.Now;
                    _obj_Smhr_Masters.OPERATION = operation.Insert;
                    if (BLL.set_Master(_obj_Smhr_Masters))
                    {
                        BLL.ShowMessage(this, " Successfully processed Excel file.");
                    }

                }
                rm_MR_Page.SelectedIndex = 0;
                LoadGrid();
                RG_Master.DataBind();

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Master", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void Delete_Excel_File()
    {
        try
        {
            ds.Dispose();
            if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == true)
            {
                // FileUpload_Task.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Corporate_Contract_Docs/") + Convert.ToString(rcmb_taskPorjectname.SelectedItem.Text.Replace("/", "_")), filename));

                string strpath = Server.MapPath("~/IMPORT_EXCEL/");


                DirectoryInfo dirinfo = new DirectoryInfo(strpath);
                strpath = strpath + strfilename2;
                FileInfo fi = new FileInfo(strpath);
                {
                    fi.Delete();
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Master", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
