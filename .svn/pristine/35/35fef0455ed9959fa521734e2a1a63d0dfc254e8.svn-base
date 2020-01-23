using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using SMHR;


public partial class Selfservice_Family : System.Web.UI.Page
{
    SMHR_EMPLOYEE _obj_smhr_employee;
    SMHR_MASTERS _obj_smhr_masters;
    static string _lbl_ID = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                //BLL.ChangeDateFormat(Convert.ToString(Session["EMP_ID"]), txt_FDOB);
                LoadCombos();
                LoadFamily();
                clearFamilyFields();
                int Serial = getFamilySerial();
                // txt_FSerial.Text = Convert.ToString(Serial);
                //txt_AnnualIncome.Value = 0.00;
                LoadFamily();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Family", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        
    }
    protected void ddlRelation_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
       // trDOBorID.Visible = true;
        //if (string.Compare(ddlRelation.SelectedItem.Text.ToLower(), "wife", true) == 0)
        //{
        //    lbl_FDOB.Visible = false;
        //    txt_FDOB.Visible = false;
        //    lblFIDNumber.Visible = true;
        //    radFIDNumber.Visible = true;
        //    chk_EmergencyCont.Visible = true;
        //}
        //else
        //{
        //    lbl_FDOB.Visible = true;
        //    txt_FDOB.Visible = true;
        //    lblFIDNumber.Visible = false;
        //    radFIDNumber.Visible = false;
        //    chk_EmergencyCont.Visible = false;
        //}
    }
    private void LoadFamily()
    {
        try
        {
            _obj_smhr_employee = new SMHR_EMPLOYEE();
            _obj_smhr_employee.EMPFMDTL_EMP_ID = Convert.ToInt32(Request.QueryString["ID"]); //Convert.ToInt32(_lbl_Emp_ID);
            _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_employee.OPERATION = operation.Check;
            DataTable dt = BLL.get_EmployeeFamily(_obj_smhr_employee);
            RG_Family.DataSource = dt;
            RG_Family.DataBind();
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Family", ex.StackTrace, DateTime.Now);
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
               // return serialMax;
            }
            catch (System.Exception ex)
            {
                SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Family", ex.StackTrace, DateTime.Now);
                Response.Redirect("~/Frm_ErrorPage.aspx");
            }
            return serialMax;
       
    }

    protected void btn_Fam_Correct_Click(object sender, EventArgs e)
    {
        try
        {
            //bool status = false;
            //_obj_smhr_employee = new SMHR_EMPLOYEE();
            //_obj_smhr_employee.OPERATION = operation.Update;
            //_obj_smhr_employee.EMPFMDTL_ID = Convert.ToInt32(_lbl_ID);
            //_obj_smhr_employee.EMPFMDTL_EMP_ID = Convert.ToInt32(Request.QueryString["ID"]);
            //_obj_smhr_employee.EMPFMDTL_SERIAL = Convert.ToInt32(txt_FSerial.Text);
            //_obj_smhr_employee.EMPFMDTL_EMPREL_ID = Convert.ToInt32(ddlRelation.SelectedValue);
            //_obj_smhr_employee.EMPFMDTL_NAME = Convert.ToString(txt_Name.Text);
            //_obj_smhr_employee.EMPFMDTL_RELDOB = Convert.ToDateTime(txt_FDOB.SelectedDate.Value);
            //if (chkDependant.Checked)
            //    _obj_smhr_employee.EMPFMDTL_RELDEPENDENT = true;
            //else
            //    _obj_smhr_employee.EMPFMDTL_RELDEPENDENT = false;
            //_obj_smhr_employee.EMPFMDTL_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            //_obj_smhr_employee.EMPFMDTL_LASTMDFDATE = DateTime.Now;
            //if (txt_AnnualIncome.Text != string.Empty)
            //    _obj_smhr_employee.EMPFMDTL_ANNUALINCOME = Convert.ToDouble(txt_AnnualIncome.Text);
            //else
            //    _obj_smhr_employee.EMPFMDTL_ANNUALINCOME = 0.00;
            //_obj_smhr_employee.EMPFMDTL_OCCUPATION = Convert.ToString(txt_Occupation.Text);
            //if (chk_Nominee.Checked)
            //    _obj_smhr_employee.EMPFMDTL_NOMINEE = true;
            //else
            //    _obj_smhr_employee.EMPFMDTL_NOMINEE = false;
            //if (chk_EmergencyCont.Checked)
            //    _obj_smhr_employee.EMPFMDTL_EMERGENCYCONTACT = true;
            //else
            //    _obj_smhr_employee.EMPFMDTL_EMERGENCYCONTACT = false;
            //if (chk_NextToKin.Checked)
            //    _obj_smhr_employee.EMPFMDTL_ISNEXTTOKIN = true;
            //else
            //    _obj_smhr_employee.EMPFMDTL_ISNEXTTOKIN = false;
            //status = BLL.set_EmpFamily(_obj_smhr_employee);
            //if (status == true)
            //{
            //    LoadFamily();
            //    clearFamilyFields();
            //    int Serial = getFamilySerial();
            //    txt_FSerial.Text = Convert.ToString(Serial);
            //}
            bool status = false;
            _obj_smhr_employee = new SMHR_EMPLOYEE();
            _obj_smhr_employee.OPERATION = operation.Update;
            _obj_smhr_employee.EMPFMDTL_ID = Convert.ToInt32(_lbl_ID);
            _obj_smhr_employee.EMPFMDTL_EMP_ID = Convert.ToInt32(Request.QueryString["ID"]); //Convert.ToInt32(_lbl_Emp_ID);
            // _obj_smhr_employee.EMPFMDTL_SERIAL = Convert.ToInt32(txt_FSerial.Text);
            // _obj_smhr_employee.EMPFMDTL_EMPREL_ID = Convert.ToInt32(ddlRelation.SelectedValue);
            // _obj_smhr_employee.EMPFMDTL_EMPREL_NAME = ddlRelation.SelectedItem.Text;
            // _obj_smhr_employee.EMPFMDTL_SURNAME = radSurName.Text;
            //  _obj_smhr_employee.EMPFMDTL_NAME = Convert.ToString(txt_Name.Text);
            //if (string.Compare(ddlRelation.SelectedItem.Text.ToLower(), "wife", true) == 0)
            //{
            //    if (string.IsNullOrEmpty(radFIDNumber.Text))
            //    {
            //        BLL.ShowMessage(this, "please enter ID Number");
            //        btn_Fam_Add.Enabled = true;
            //        return;
            //    }
            //    _obj_smhr_employee.EMPFMDTL_WIFEIDNUMBER = radFIDNumber.Text;
            //}
            //else
            //{
            //    if (txt_FDOB.SelectedDate == null)
            //    {
            //        BLL.ShowMessage(this, "please select dependent DOB");
            //        btn_Fam_Add.Enabled = true;
            //        return;
            //    }
            //    _obj_smhr_employee.EMPFMDTL_RELDOB = Convert.ToDateTime(txt_FDOB.SelectedDate.Value);
            //}
            //_obj_smhr_employee.EMPFMDTL_ANNUALINCOME = Convert.ToDouble(rntxt_Annual.Text.Replace("'", "''"));
            //if (chk_EmergencyCont.Checked)
            //    _obj_smhr_employee.EMPFMDTL_EMERGENCYCONTACT = true;
            //else
            //    _obj_smhr_employee.EMPFMDTL_EMERGENCYCONTACT = false;

            //_obj_smhr_employee.EMPFMDTL_LASTMDFBY = 1;
            //_obj_smhr_employee.EMPFMDTL_LASTMDFDATE = DateTime.Now;


            //if (FBrowsePhoto.HasFile)
            //{
            //    string imagename = txt_Name.Text + "_" + Guid.NewGuid().ToString() + "_FIMG" + FBrowsePhoto.FileName;
            //    string strPath = "~/EmpUploads/" + imagename;
            //    FBrowsePhoto.PostedFile.SaveAs(Server.MapPath("~/EmpUploads/") + imagename);
            //    _obj_smhr_employee.EMPFMDTL_PHOTO = strPath;
            //}
            //if (FBioData.HasFile)
            //{
            //    string pdfName = txt_Name.Text + "_" + Guid.NewGuid().ToString() + "_FBIO" + FBioData.FileName;
            //    string strPath = "~/EmpUploads/" + pdfName;
            //    FBioData.PostedFile.SaveAs(Server.MapPath("~/EmpUploads/") + pdfName);
            //    _obj_smhr_employee.EMPFMDTL_BIODATA = strPath;
            //}
            //if (FBioMetricData.HasFile)
            //{
            //    string pdfName = txt_Name.Text + "_" + Guid.NewGuid().ToString() + "_FBIOMETRIC" + FBioMetricData.FileName;
            //    string strPath = "~/EmpUploads/" + pdfName;
            //    FBioMetricData.PostedFile.SaveAs(Server.MapPath("~/EmpUploads/") + pdfName);
            //    _obj_smhr_employee.EMPFMDTL_BIOMETRICDOC = strPath;
            //}

            //status = BLL.set_EmpFamily(_obj_smhr_employee);
            //if (status == true)
            //{
            //    LoadFamily();
            //    clearFamilyFields();
            //    int Serial = getFamilySerial();
            //    txt_FSerial.Text = Convert.ToString(Serial);
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Family", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        
    }

    protected void RG_Family_ItemCommand(object source, GridCommandEventArgs e)
    {
        //if (e.CommandName == "Edit_Rec")
        //{
        //    GridDataItem dtItem = (GridDataItem)e.Item;
        //    int index = dtItem.ItemIndex;
        //    Label lblID = new Label();
        //    Label lblSerial = new Label();
        //    Label lblRelID = new Label();
        //    Label lblName = new Label();
        //    Label lblDOB = new Label();
        //    CheckBox _chkDep = new CheckBox();
        //    Label lblAnnualIncome = new Label();
        //    Label lblOccupation = new Label();
        //    CheckBox _chkNominee = new CheckBox();
        //    CheckBox _chkEmergency = new CheckBox();
        //    CheckBox _chkNexttoKin = new CheckBox();
        //    lblID = RG_Family.Items[index].FindControl("lblID") as Label;
        //    lblSerial = RG_Family.Items[index].FindControl("lbl_Serial") as Label;
        //    lblRelID = RG_Family.Items[index].FindControl("lbl_ID") as Label;
        //    lblName = RG_Family.Items[index].FindControl("lbl_Name") as Label;
        //    lblDOB = RG_Family.Items[index].FindControl("lbl_DOB") as Label;
        //    _chkDep = RG_Family.Items[index].FindControl("chk_Dep") as CheckBox;
        //    lblAnnualIncome = RG_Family.Items[index].FindControl("lbl_AnnualIncome") as Label;
        //    lblOccupation = RG_Family.Items[index].FindControl("lbl_Occupation") as Label;
        //    _chkNominee = RG_Family.Items[index].FindControl("chk_Nominee") as CheckBox;
        //    _chkEmergency = RG_Family.Items[index].FindControl("chk_Emergency") as CheckBox;
        //    _chkNexttoKin = RG_Family.Items[index].FindControl("chk_NextToKin") as CheckBox;
        //    _lbl_ID = lblID.Text;
        //    txt_FSerial.Text = lblSerial.Text;
        //    ddlRelation.SelectedIndex = ddlRelation.FindItemIndexByValue(lblRelID.Text);
        //    txt_Name.Text = lblName.Text;
        //    ////string[] strSpilt = lblDOB.Text.Split('/');
        //    ////lblDOB.Text = strSpilt[1] + "/" + strSpilt[0] + "/" + strSpilt[2];
        //    //txt_FDOB.SelectedDate = DateTime.ParseExact(lblDOB.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
        //    txt_FDOB.SelectedDate = DateTime.ParseExact(lblDOB.Text, Convert.ToString(Session["DATE_FORMAT"]), System.Globalization.CultureInfo.InvariantCulture);

        //     if (_chkDep.Checked)
        //        chkDependant.Checked = true;
        //    else
        //        chkDependant.Checked = false;
        //    txt_AnnualIncome.Text = lblAnnualIncome.Text;
        //    txt_Occupation.Text = lblOccupation.Text;
        //    if (_chkNominee.Checked)
        //        chk_Nominee.Checked = true;
        //    else
        //        chk_Nominee.Checked = false;
        //    if (_chkEmergency.Checked)
        //        chk_EmergencyCont.Checked = true;
        //    else
        //        chk_EmergencyCont.Checked = false;
        //    if (_chkNexttoKin.Checked)
        //        chk_NextToKin.Checked = true;
        //    else
        //        chk_NextToKin.Checked = false;
        //    btn_Fam_Add.Visible = false;
        //    btn_Fam_Correct.Visible = true;
        //    ddlRelation.Enabled = false;
        //}
        //if (e.CommandName == "Edit_Rec")
        //{
        //    GridDataItem dtItem = (GridDataItem)e.Item;
        //    int index = dtItem.ItemIndex;
        //    Label lblSerial = new Label();
        //    Label lblRelID = new Label();
        //    Label lblRelName = new Label();
        //    Label lblSurname = new Label();
        //    Label lblName = new Label();
        //    Label lblDOB = new Label();
        //    Label lblWifeIDNumber = new Label();
        //    Label lblannual = new Label();
        //    Label lblID = new Label();
        //    CheckBox _chkEmergency = new CheckBox();
        //    lblID = RG_Family.Items[index].FindControl("lblID") as Label;
        //    lblSerial = RG_Family.Items[index].FindControl("lbl_Serial") as Label;
        //    lblRelID = RG_Family.Items[index].FindControl("lbl_ID") as Label;
        //    lblRelName = RG_Family.Items[index].FindControl("lbl_Relation") as Label;
        //    lblName = RG_Family.Items[index].FindControl("lbl_Name") as Label;
        //    lblSurname = RG_Family.Items[index].FindControl("lbl_Surname") as Label;
        //    lblDOB = RG_Family.Items[index].FindControl("lbl_DOB") as Label;
        //    lblWifeIDNumber = RG_Family.Items[index].FindControl("lbl_WifeIDNumber") as Label;
        //    lblannual = RG_Family.Items[index].FindControl("lbl_Annual") as Label;
        //    _chkEmergency = RG_Family.Items[index].FindControl("chk_Emergency") as CheckBox;
        //    txt_FSerial.Text = lblSerial.Text;
        //    ddlRelation.SelectedIndex = ddlRelation.FindItemIndexByValue(lblRelID.Text);
        //    txt_Name.Text = lblName.Text;
        //    radSurName.Text = lblSurname.Text;
        //    _lbl_ID = lblID.Text;
        //    trDOBorID.Visible = true;
        //    if (string.Compare(lblRelName.Text.ToLower(), "wife", true) == 0)
        //    {
        //        radFIDNumber.Visible = true;
        //        lblFIDNumber.Visible = true;
        //        lbl_FDOB.Visible = false;
        //        txt_FDOB.Visible = false;
        //        radFIDNumber.Text = lblWifeIDNumber.Text;
        //    }
        //    else
        //    {
        //        lbl_FDOB.Visible = true;
        //        lblFIDNumber.Visible = false;
        //        radFIDNumber.Visible = false;
        //        txt_FDOB.Visible = true;
        //        txt_FDOB.SelectedDate = Convert.ToDateTime(lblDOB.Text);// DateTime.ParseExact(lblDOB.Text, Convert.ToString(Session["DATE_FORMAT"]), System.Globalization.CultureInfo.InvariantCulture);
        //    }
        //    rntxt_Annual.Text = lblannual.Text;



        //    btn_Fam_Add.Visible = false;
        //    btn_Fam_Correct.Visible = true;
            

        //}
    }

    protected void btn_Fam_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearFamilyFields();
            int Serial = getFamilySerial();
            //txt_FSerial.Text = Convert.ToString(Serial);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Family", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void clearFamilyFields()
    {
        //txt_FDOB.SelectedDate = null;
        //radSurName.Text = string.Empty;
        //txt_Name.Text = string.Empty;
        //trDOBorID.Visible = false;
        //radFIDNumber.Text = string.Empty;
        //radFIDNumber.Visible = false;
        //txt_FDOB.Visible = false;
        //chk_EmergencyCont.Visible = false;
        //ddlRelation.SelectedIndex = -1;
        //chk_EmergencyCont.Checked = false;
        //btn_Fam_Add.Visible = true;
        //btn_Fam_Correct.Visible = false;
        ////rntxt_Annual.Text = "";
        //rntxt_Annual.Value = 0.0;
    }

    protected void btn_Fam_Add_Click(object sender, EventArgs e)
    {
        try
        {
            {
                //if (Check_Combo(RG_Family, "lbl_Serial", txt_FSerial))
                //{
                //    if (RG_Family.Items.Count >= 5)
                //    {
                //        BLL.ShowMessage(this, "you cant declare more than 5 dependents");
                //        btn_Fam_Add.Enabled = true;
                //        return;
                //    }
                //    //bool status = false;
                //    //_obj_smhr_employee = new SMHR_EMPLOYEE();
                //    //_obj_smhr_employee.OPERATION = operation.Insert;
                //    //_obj_smhr_employee.EMPFMDTL_EMP_ID = Convert.ToInt32(Request.QueryString["ID"]);
                //    //_obj_smhr_employee.EMPFMDTL_SERIAL = Convert.ToInt32(txt_FSerial.Text);
                //    //_obj_smhr_employee.EMPFMDTL_EMPREL_ID = Convert.ToInt32(ddlRelation.SelectedValue);
                //    //_obj_smhr_employee.EMPFMDTL_EMPREL_NAME = Convert.ToString(ddlRelation.SelectedItem.Text);
                //    //_obj_smhr_employee.EMPFMDTL_NAME = Convert.ToString(txt_Name.Text);
                //    //_obj_smhr_employee.EMPFMDTL_RELDOB = Convert.ToDateTime(txt_FDOB.SelectedDate.Value);
                //    //if (chkDependant.Checked)
                //    //    _obj_smhr_employee.EMPFMDTL_RELDEPENDENT = true;
                //    //else
                //    //    _obj_smhr_employee.EMPFMDTL_RELDEPENDENT = false;
                //    //_obj_smhr_employee.EMPFMDTL_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                //    //_obj_smhr_employee.EMPFMDTL_CREATEDDATE = DateTime.Now;
                //    //if (txt_AnnualIncome.Text != string.Empty)
                //    //    _obj_smhr_employee.EMPFMDTL_ANNUALINCOME = Convert.ToDouble(txt_AnnualIncome.Text);
                //    //else
                //    //    _obj_smhr_employee.EMPFMDTL_ANNUALINCOME = 0.00;
                //    //_obj_smhr_employee.EMPFMDTL_OCCUPATION = Convert.ToString(txt_Occupation.Text);
                //    //if (chk_Nominee.Checked)
                //    //    _obj_smhr_employee.EMPFMDTL_NOMINEE = true;
                //    //else
                //    //    _obj_smhr_employee.EMPFMDTL_NOMINEE = false;
                //    //if (chk_EmergencyCont.Checked)
                //    //    _obj_smhr_employee.EMPFMDTL_EMERGENCYCONTACT = true;
                //    //else
                //    //    _obj_smhr_employee.EMPFMDTL_EMERGENCYCONTACT = false;
                //    //if (chk_NextToKin.Checked)
                //    //    _obj_smhr_employee.EMPFMDTL_ISNEXTTOKIN = true;
                //    //else
                //    //    _obj_smhr_employee.EMPFMDTL_ISNEXTTOKIN = false;
                //    if (RG_Family.Items.Count > 0)
                //    {
                //        //EMPFMDTL_EMPREL_NAME
                //        Label lbRel;
                //        foreach (GridDataItem r in RG_Family.Items)
                //        {
                //            lbRel = new Label();
                //            lbRel = (Label)r.FindControl("lbl_Relation");
                //            if (string.Compare(lbRel.Text.ToLower(), "wife", true) == 0 && string.Compare(ddlRelation.SelectedItem.Text.ToLower(), "wife", true) == 0)
                //            {
                //                BLL.ShowMessage(this, "Dependent already declared");
                //                btn_Fam_Add.Enabled = true;
                //                return;
                //            }
                //        }
                //    }
                //    //WHEN SAVE IS CLICKED DUMPING  RECORD TO THE TABLE
                //    btn_Fam_Add.Enabled = false;
                //    bool status = false;
                //    _obj_smhr_employee = new SMHR_EMPLOYEE();
                //    _obj_smhr_employee.OPERATION = operation.Insert;
                //    _obj_smhr_employee.EMPFMDTL_EMP_ID = Convert.ToInt32(Request.QueryString["ID"]); //Convert.ToInt32(_lbl_Emp_ID);
                //    _obj_smhr_employee.EMPFMDTL_SERIAL = Convert.ToInt32(txt_FSerial.Text);
                //    _obj_smhr_employee.EMPFMDTL_EMPREL_ID = Convert.ToInt32(ddlRelation.SelectedValue);
                //    _obj_smhr_employee.EMPFMDTL_EMPREL_NAME = ddlRelation.SelectedItem.Text;
                //    _obj_smhr_employee.EMPFMDTL_SURNAME = radSurName.Text;
                //    _obj_smhr_employee.EMPFMDTL_NAME = Convert.ToString(txt_Name.Text);

                //    if (string.Compare(ddlRelation.SelectedItem.Text.ToLower(), "wife", true) == 0)
                //    {
                //        if (string.IsNullOrEmpty(radFIDNumber.Text))
                //        {
                //            BLL.ShowMessage(this, "please enter ID Number");
                //            btn_Fam_Add.Enabled = true;
                //            return;
                //        }
                //        _obj_smhr_employee.EMPFMDTL_WIFEIDNUMBER = radFIDNumber.Text;
                //    }
                //    else
                //    {
                //        if (txt_FDOB.SelectedDate == null)
                //        {
                //            BLL.ShowMessage(this, "please select dependent DOB");
                //            btn_Fam_Add.Enabled = true;
                //            return;
                //        }
                //        _obj_smhr_employee.EMPFMDTL_RELDOB = Convert.ToDateTime(txt_FDOB.SelectedDate.Value);
                //    }

                //    if (chk_EmergencyCont.Checked)
                //        _obj_smhr_employee.EMPFMDTL_EMERGENCYCONTACT = true;
                //    else
                //        _obj_smhr_employee.EMPFMDTL_EMERGENCYCONTACT = false;

                //    _obj_smhr_employee.EMPFMDTL_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                //    _obj_smhr_employee.EMPFMDTL_CREATEDDATE = DateTime.Now;
                //    _obj_smhr_employee.EMPFMDTL_ANNUALINCOME = Convert.ToDouble(rntxt_Annual.Text.Replace("'", "''"));
                //    if (FBrowsePhoto.HasFile)
                //    {
                //        string imagename = txt_Name.Text + "_" + Guid.NewGuid().ToString() + "_FIMG" + FBrowsePhoto.FileName;
                //        string strPath = "~/EmpUploads/" + imagename;
                //        FBrowsePhoto.PostedFile.SaveAs(Server.MapPath("~/EmpUploads/") + imagename);
                //        _obj_smhr_employee.EMPFMDTL_PHOTO = strPath;
                //    }
                //    if (FBioData.HasFile)
                //    {
                //        string pdfName = txt_Name.Text + "_" + Guid.NewGuid().ToString() + "_FBIO" + FBioData.FileName;
                //        string strPath = "~/EmpUploads/" + pdfName;
                //        FBioData.PostedFile.SaveAs(Server.MapPath("~/EmpUploads/") + pdfName);
                //        _obj_smhr_employee.EMPFMDTL_BIODATA = strPath;
                //    }
                //    if (FBioMetricData.HasFile)
                //    {
                //        string pdfName = txt_Name.Text + "_" + Guid.NewGuid().ToString() + "_FBIOMETRIC" + FBioMetricData.FileName;
                //        string strPath = "~/EmpUploads/" + pdfName;
                //        FBioMetricData.PostedFile.SaveAs(Server.MapPath("~/EmpUploads/") + pdfName);
                //        _obj_smhr_employee.EMPFMDTL_BIOMETRICDOC = strPath;
                //    }
                //    status = BLL.set_EmpFamily(_obj_smhr_employee);//no organisation column is found in this table

                //    if (status == true)
                //    {
                //        btn_Fam_Add.Enabled = true;
                //        LoadFamily();
                //        clearFamilyFields();
                //        int Serial = getFamilySerial();
                //        txt_FSerial.Text = Convert.ToString(Serial);
                //    }
                //}
                //else
                //{
                //    clearFamilyFields();
                //}
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Family", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadCombos()
    {
        //ddlRelation.Items.Clear();
        //_obj_smhr_masters = new SMHR_MASTERS();
        //_obj_smhr_masters.MASTER_TYPE = "RELATIONSHIP";
        //_obj_smhr_masters.OPERATION = operation.Select;
        //_obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
        //DataTable dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);
        //ddlRelation.DataSource = dt_Details;
        //ddlRelation.DataTextField = "HR_MASTER_CODE";
        //ddlRelation.DataValueField = "HR_MASTER_ID";
        //ddlRelation.DataBind();
        //ddlRelation.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
    }

    public bool Check_Combo(RadGrid rdGrid, string lbl_validate, RadTextBox txt_FSerial)
    {
        try
        {
            bool status = true;
            if (rdGrid.Items.Count > 0)
            {
                for (int i = 0; i < rdGrid.Items.Count; i++)
                {
                    Label lbl_Control = new Label();
                    lbl_Control = rdGrid.Items[i].FindControl("" + lbl_validate + "") as Label;
                    if (Convert.ToInt32(lbl_Control.Text) == Convert.ToInt32(txt_FSerial.Text))
                    {
                        status = false;
                    }
                }
            }
            return status;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Family", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return false;
        }
    }
}
