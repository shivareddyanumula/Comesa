using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Medical_frm_EmpFamDetails_Medical : System.Web.UI.Page
{
    static int Mode = 0;
    DataTable dtFamily;
    SMHR_EMPLOYEE _obj_smhr_employee;
    static string _lbl_ID = "";
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Family Details");//COUNTRY");
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
                    RG_Employee.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Fam_Correct.Visible = false;
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
                txt_FDOB.MaxDate = DateTime.Now;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpFamDetails_Medical", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Fam_Add_Click(object sender, EventArgs e)
    {
        try
        {
            //if (Check_Combo(RG_Family, "lbl_ID", ddlRelation))
            //{
            if (string.IsNullOrEmpty(radSurName.Text))
            {
                BLL.ShowMessage(this, "please enter surname");
                return;
            }
            if (string.IsNullOrEmpty(txt_Name.Text))
            {
                BLL.ShowMessage(this, "please enter name");
                return;
            }
            if (txt_FSerial.Text == string.Empty)
            {
                if (RG_Family.Items.Count == 0)
                    txt_FSerial.Text = "1";
                else
                {
                    int countserialno = RG_Family.Items.Count;
                    countserialno += 1;
                    txt_FSerial.Text = Convert.ToString(countserialno);
                }
            }

            if (RG_Family.Items.Count >= 5)
            {
                BLL.ShowMessage(this, "you cant declare more than 5 dependents");
                btn_Fam_Add.Enabled = true;
                return;
            }
            if (RG_Family.Items.Count > 0)
            {


                //EMPFMDTL_EMPREL_NAME
                Label lbRel; int count = 0;
                foreach (GridDataItem r in RG_Family.Items)
                {
                    lbRel = new Label();
                    lbRel = (Label)r.FindControl("lbl_Relation");
                    if (string.Compare(lbRel.Text.ToLower(), "son", true) == 0 || string.Compare(lbRel.Text.ToLower(), "daughter", true) == 0)
                    {
                        count++;
                        if (count == 4 && (string.Compare(ddlRelation.Text.ToLower(), "son", true) == 0 || string.Compare(ddlRelation.Text.ToLower(), "daughter", true) == 0)) //RG_Family.Items.Count>=4)
                        {
                            BLL.ShowMessage(this, "only four son/daughters can delcare");
                            btn_Fam_Add.Enabled = true;
                            return;
                        }

                    }
                    else if (string.Compare(lbRel.Text.ToLower(), ddlRelation.SelectedItem.Text.ToLower(), true) == 0)
                    {
                        BLL.ShowMessage(this, "Dependent already declared");
                        btn_Fam_Add.Enabled = true;
                        return;
                    }
                }
            }
            //WHEN SAVE IS CLICKED DUMPING  RECORD TO THE TABLE
            btn_Fam_Add.Enabled = false;
            bool status = false;
            _obj_smhr_employee = new SMHR_EMPLOYEE();
            _obj_smhr_employee.OPERATION = operation.Insert;
            _obj_smhr_employee.EMPFMDTL_EMP_ID = Convert.ToInt32(HF_EMPID.Value); //Convert.ToInt32(_lbl_Emp_ID);
            _obj_smhr_employee.EMPFMDTL_SERIAL = Convert.ToInt32(txt_FSerial.Text);
            _obj_smhr_employee.EMPFMDTL_EMPREL_ID = Convert.ToInt32(ddlRelation.SelectedValue);
            _obj_smhr_employee.EMPFMDTL_EMPREL_NAME = ddlRelation.SelectedItem.Text;
            _obj_smhr_employee.EMPFMDTL_SURNAME = radSurName.Text;
            _obj_smhr_employee.EMPFMDTL_NAME = Convert.ToString(txt_Name.Text);

            if (string.Compare(ddlRelation.SelectedItem.Text.ToLower(), "spouse", true) != 0)
            {
                if (txt_FDOB.SelectedDate == null)
                {
                    BLL.ShowMessage(this, "please select dependent DOB");
                    btn_Fam_Add.Enabled = true;
                    return;
                }
                _obj_smhr_employee.EMPFMDTL_RELDOB = Convert.ToDateTime(txt_FDOB.SelectedDate.Value);
            }

            if (chk_EmergencyCont.Checked)
                _obj_smhr_employee.EMPFMDTL_EMERGENCYCONTACT = true;
            else
                _obj_smhr_employee.EMPFMDTL_EMERGENCYCONTACT = false;

            _obj_smhr_employee.EMPFMDTL_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_employee.EMPFMDTL_CREATEDDATE = DateTime.Now;
            if (FBrowsePhoto.HasFile)
            {
                string imagename = txt_Name.Text + "_" + Guid.NewGuid().ToString() + "_FIMG" + FBrowsePhoto.FileName;
                string strPath = "~/EmpUploads/" + imagename;
                FBrowsePhoto.PostedFile.SaveAs(Server.MapPath("~/EmpUploads/") + imagename);
                _obj_smhr_employee.EMPFMDTL_PHOTO = strPath;
            }
            if (FBioData.HasFile)
            {
                string pdfName = txt_Name.Text + "_" + Guid.NewGuid().ToString() + "_FBIO" + FBioData.FileName;
                string strPath = "~/EmpUploads/" + pdfName;
                FBioData.PostedFile.SaveAs(Server.MapPath("~/EmpUploads/") + pdfName);
                _obj_smhr_employee.EMPFMDTL_BIODATA = strPath;
            }
            if (FBioMetricData.HasFile)
            {
                string pdfName = txt_Name.Text + "_" + Guid.NewGuid().ToString() + "_FBIOMETRIC" + FBioMetricData.FileName;
                string strPath = "~/EmpUploads/" + pdfName;
                FBioMetricData.PostedFile.SaveAs(Server.MapPath("~/EmpUploads/") + pdfName);
                _obj_smhr_employee.EMPFMDTL_BIOMETRICDOC = strPath;
            }
            status = BLL.set_EmpFamily(_obj_smhr_employee);//no organisation column is found in this table
            Mode = 2;
            if (status == true)
            {
                LoadFamily();
                clearFamilyFields();
                int Serial = getFamilySerial();
                txt_FSerial.Text = Convert.ToString(Serial);
            }
            btn_Fam_Add.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpFamDetails_Medical", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    private int getFamilySerial()
    {
        int serialMax = 0;
        try
        {
            if (RG_Family.Items.Count == 0)
            {
                serialMax = 1;
            }
            else
            {
                serialMax = RG_Family.Items.Count + 1;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpFamDetails_Medical", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return serialMax;
    }
    protected void btn_Fam_Correct_Click(object sender, EventArgs e)
    {
        try
        {
            if (RG_Family.Items.Count > 0)
            {
                Label lbRel; int count = 0; Label relID;
                foreach (GridDataItem r in RG_Family.Items)
                {
                    lbRel = new Label();
                    lbRel = (Label)r.FindControl("lbl_Relation");
                    relID = new Label();
                    relID = (Label)r.FindControl("lblID");

                    if (string.Compare(lbRel.Text.ToLower(), "son", true) == 0 || string.Compare(lbRel.Text.ToLower(), "daughter", true) == 0)
                    {
                        if (string.Compare(_lbl_ID, relID.Text, true) != 0)
                            count++;
                    }
                    else if (string.Compare(_lbl_ID, relID.Text, true) != 0 && string.Compare(lbRel.Text.ToLower(), ddlRelation.SelectedItem.Text.ToLower(), true) == 0)
                    {
                        BLL.ShowMessage(this, "Dependent already declared");
                        btn_Fam_Add.Enabled = true;
                        return;
                    }
                }
                if (count == 4 && (string.Compare(ddlRelation.Text.ToLower(), "son", true) == 0 || string.Compare(ddlRelation.Text.ToLower(), "daughter", true) == 0) && string.Compare(ddlRelation.SelectedValue, _lbl_ID, true) != 0)
                {
                    BLL.ShowMessage(this, "only four son/daughters can delcare");
                    btn_Fam_Add.Enabled = true;
                    return;
                }
            }

            bool status = false;
            _obj_smhr_employee = new SMHR_EMPLOYEE();
            _obj_smhr_employee.OPERATION = operation.Update;
            _obj_smhr_employee.EMPFMDTL_ID = Convert.ToInt32(_lbl_ID);
            _obj_smhr_employee.EMPFMDTL_EMP_ID = Convert.ToInt32(HF_EMPID.Value); //Convert.ToInt32(_lbl_Emp_ID);
            _obj_smhr_employee.EMPFMDTL_SERIAL = Convert.ToInt32(txt_FSerial.Text);
            _obj_smhr_employee.EMPFMDTL_EMPREL_ID = Convert.ToInt32(ddlRelation.SelectedValue);
            _obj_smhr_employee.EMPFMDTL_EMPREL_NAME = ddlRelation.SelectedItem.Text;
            _obj_smhr_employee.EMPFMDTL_SURNAME = radSurName.Text;
            _obj_smhr_employee.EMPFMDTL_NAME = Convert.ToString(txt_Name.Text);
            if (string.Compare(ddlRelation.SelectedItem.Text.ToLower(), "spouse", true) != 0)
            {
                if (txt_FDOB.SelectedDate == null)
                {
                    BLL.ShowMessage(this, "please select dependent DOB");
                    btn_Fam_Add.Enabled = true;
                    return;
                }
                _obj_smhr_employee.EMPFMDTL_RELDOB = Convert.ToDateTime(txt_FDOB.SelectedDate.Value);
            }
            if (chk_EmergencyCont.Checked)
                _obj_smhr_employee.EMPFMDTL_EMERGENCYCONTACT = true;
            else
                _obj_smhr_employee.EMPFMDTL_EMERGENCYCONTACT = false;

            _obj_smhr_employee.EMPFMDTL_LASTMDFBY = 1;
            _obj_smhr_employee.EMPFMDTL_LASTMDFDATE = DateTime.Now;


            if (FBrowsePhoto.HasFile)
            {
                string imagename = txt_Name.Text + "_" + Guid.NewGuid().ToString() + "_FIMG" + FBrowsePhoto.FileName;
                string strPath = "~/EmpUploads/" + imagename;
                FBrowsePhoto.PostedFile.SaveAs(Server.MapPath("~/EmpUploads/") + imagename);
                _obj_smhr_employee.EMPFMDTL_PHOTO = strPath;
            }
            if (FBioData.HasFile)
            {
                string pdfName = txt_Name.Text + "_" + Guid.NewGuid().ToString() + "_FBIO" + FBioData.FileName;
                string strPath = "~/EmpUploads/" + pdfName;
                FBioData.PostedFile.SaveAs(Server.MapPath("~/EmpUploads/") + pdfName);
                _obj_smhr_employee.EMPFMDTL_BIODATA = strPath;
            }
            if (FBioMetricData.HasFile)
            {
                string pdfName = txt_Name.Text + "_" + Guid.NewGuid().ToString() + "_FBIOMETRIC" + FBioMetricData.FileName;
                string strPath = "~/EmpUploads/" + pdfName;
                FBioMetricData.PostedFile.SaveAs(Server.MapPath("~/EmpUploads/") + pdfName);
                _obj_smhr_employee.EMPFMDTL_BIOMETRICDOC = strPath;
            }
            Mode = 2;
            status = BLL.set_EmpFamily(_obj_smhr_employee);
            if (status == true)
            {
                LoadFamily();
                clearFamilyFields();
                int Serial = getFamilySerial();
                txt_FSerial.Text = Convert.ToString(Serial);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpFamDetails_Medical", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void clearFamilyFields()
    {
        try
        {
            txt_FDOB.SelectedDate = null;
            radSurName.Text = string.Empty;
            txt_Name.Text = string.Empty;
            // trDOBorID.Visible = false;
            lbl_FDOB.Visible = false;
            txt_FDOB.Visible = false;
            //radFIDNumber.Text = string.Empty;
            //radFIDNumber.Visible = false;
            txt_FDOB.Visible = false;
            chk_EmergencyCont.Visible = false;
            ddlRelation.SelectedIndex = -1;
            chk_EmergencyCont.Checked = false;
            btn_Fam_Add.Visible = true;
            btn_Fam_Correct.Visible = false;
            //rntxt_Annual.Text = "";
            // rntxt_Annual.Value = 0.0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpFamDetails_Medical", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void RG_Family_ItemCommand(object source, GridCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Edit_Rec")
            {
                GridDataItem dtItem = (GridDataItem)e.Item;
                int index = dtItem.ItemIndex;
                Label lblID = new Label();
                Label lblSerial = new Label();
                Label lblRelID = new Label();
                Label lblRelName = new Label();
                Label lblSurname = new Label();
                Label lblName = new Label();
                Label lbl_AccountName = new Label();
                Label lblDOB = new Label();
                Label lblWifeIDNumber = new Label();
                Label lblannual = new Label();
                CheckBox _chkEmergency = new CheckBox();
                lblID = RG_Family.Items[index].FindControl("lblID") as Label;
                lblSerial = RG_Family.Items[index].FindControl("lbl_Serial") as Label;
                lblRelID = RG_Family.Items[index].FindControl("lbl_ID") as Label;
                lblRelName = RG_Family.Items[index].FindControl("lbl_Relation") as Label;
                lblName = RG_Family.Items[index].FindControl("lbl_Name") as Label;
                lbl_AccountName = RG_Family.Items[index].FindControl("lbl_AccountName") as Label;
                lblSurname = RG_Family.Items[index].FindControl("lbl_Surname") as Label;
                lblDOB = RG_Family.Items[index].FindControl("lbl_DOB") as Label;
                _chkEmergency = RG_Family.Items[index].FindControl("chk_Emergency") as CheckBox;
                _lbl_ID = lblID.Text;
                txt_FSerial.Text = lblSerial.Text;
                ddlRelation.SelectedIndex = ddlRelation.FindItemIndexByValue(lblRelID.Text);
                txt_Name.Text = lblName.Text;
                radSurName.Text = lblSurname.Text;
                //trDOBorID.Visible = true;
                lbl_FDOB.Visible = false;
                txt_FDOB.Visible = false;
                if (string.Compare(lblRelName.Text.ToLower(), "spouse", true) == 0)
                {
                    lbl_FDOB.Visible = false;
                    txt_FDOB.Visible = false;
                    chk_EmergencyCont.Visible = true;
                }
                else
                {
                    lbl_FDOB.Visible = true;
                    chk_EmergencyCont.Visible = false;
                    txt_FDOB.Visible = true;
                    txt_FDOB.SelectedDate = DateTime.ParseExact(lblDOB.Text, "dd/MM/yyyy", null);//Convert.ToDateTime(lblDOB.Text);//
                }
                if (_chkEmergency.Checked)
                    chk_EmergencyCont.Checked = true;
                else
                    chk_EmergencyCont.Checked = false;

                Mode = 2;
                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    btn_Fam_Correct.Visible = false;
                }
                else
                {
                    btn_Fam_Correct.Visible = true;
                }
                btn_Fam_Add.Visible = false;

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpFamDetails_Medical", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void btn_Fam_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearFamilyFields();
            int Serial = getFamilySerial();
            txt_FSerial.Text = Convert.ToString(Serial);
            Rm_CY_page.SelectedIndex = 0;
            btn_Fam_Add.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpFamDetails_Medical", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void ddlRelation_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            //trDOBorID.Visible = true;
            lbl_FDOB.Visible = false;
            txt_FDOB.Visible = false;
            chk_EmergencyCont.Visible = false;
            if (ddlRelation.SelectedIndex > 0)
            {
                if (string.Compare(ddlRelation.SelectedItem.Text.ToLower(), "spouse", true) == 0)
                {
                    lbl_FDOB.Visible = false;
                    txt_FDOB.Visible = false;
                    chk_EmergencyCont.Visible = true;
                }
                else
                {
                    lbl_FDOB.Visible = true;
                    txt_FDOB.Visible = true;
                    chk_EmergencyCont.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpFamDetails_Medical", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Employee_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            ddlRelation.Items.Clear();
            SMHR_MASTERS _obj_smhr_masters = new SMHR_MASTERS();
            _obj_smhr_masters.MASTER_TYPE = "RELATIONSHIP";
            _obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_masters.OPERATION = operation.Select;
            ddlRelation.DataSource = BLL.get_MasterRecords(_obj_smhr_masters);
            ddlRelation.DataTextField = "HR_MASTER_CODE";
            ddlRelation.DataValueField = "HR_MASTER_ID";
            ddlRelation.DataBind();
            ddlRelation.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            string str_Query = RG_Employee.MasterTableView.FilterExpression;
            string _lbl_Emp_ID = Convert.ToString(e.CommandArgument);
            HF_EMPID.Value = _lbl_Emp_ID;
            _obj_smhr_employee = new SMHR_EMPLOYEE();
            _obj_smhr_employee.EMPFMDTL_EMP_ID = Convert.ToInt32(_lbl_Emp_ID); //Convert.ToInt32(_lbl_Emp_ID);
            _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_employee.OPERATION = operation.Check;
            DataTable dt = BLL.get_EmployeeFamily(_obj_smhr_employee);
            RG_Family.DataSource = dt;
            RG_Family.DataBind();
            Rm_CY_page.SelectedIndex = 1;
            btn_Fam_Correct.Visible = false;
            clearFamilyFields();
            int Serial = getFamilySerial();
            txt_FSerial.Text = Convert.ToString(Serial);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpFamDetails_Medical", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadFamily()
    {
        try
        {
            _obj_smhr_employee = new SMHR_EMPLOYEE();
            _obj_smhr_employee.EMPFMDTL_EMP_ID = Convert.ToInt32(HF_EMPID.Value); //Convert.ToInt32(_lbl_Emp_ID);
            _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_employee.OPERATION = operation.Check;
            DataTable dt = BLL.get_EmployeeFamily(_obj_smhr_employee);
            RG_Family.DataSource = dt;
            RG_Family.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpFamDetails_Medical", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadData()
    {
        try
        {

            _obj_smhr_employee = new SMHR_EMPLOYEE();
            _obj_smhr_employee.OPERATION = operation.Select1;
            _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_employee.EMP_LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_Details = BLL.get_Employee(_obj_smhr_employee);
            RG_Employee.DataSource = dt_Details;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpFamDetails_Medical", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void RG_Employee_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            if (ViewState["btnAdd"] == null)
            {
                LoadData();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpFamDetails_Medical", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}