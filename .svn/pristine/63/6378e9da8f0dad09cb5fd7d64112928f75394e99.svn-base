using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Text;
using Telerik.Web.UI;
using System.Data.OleDb;
using System.IO;
using System.Data;

public partial class HR_TRAINING_TrainerProfile : System.Web.UI.Page
{



    static double minsal = 0.0;
    static double maxsal = 0.0;
    static double int_DOBS = 0;
    static double int_DOBE = 0;
    static int int_MIN = 18;
    static string int_DF = "";
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

                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Trainer Profile");//COUNTRY");
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
                    Rg_Countries.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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

                Page.Validate();
            }
            LoadGrid();

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "TrainerProfile", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }



    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            Clear();
            rad_IsActive.Checked = true;
            Rp_CY_ViewDetails.Selected = true;
            Rm_Course_page.SelectedIndex = 0;
            btn_Save.Visible = true;
            LoadDropDowns();
            btn_Update.Visible = false;
            txt_Email.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "TrainerProfile", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            txt_Email.Enabled = false;
            btn_Save.Visible = false;
            LoadDropDowns();
            SMHR_TRAINERPROFILE _obj_smhr_Trainerprofile = new SMHR_TRAINERPROFILE();
            _obj_smhr_Trainerprofile.OPERATION = operation.Get;
            _obj_smhr_Trainerprofile.Trainer_TrainerProfile_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            ld_ID.Text = Convert.ToString(Convert.ToString(e.CommandArgument));
            _obj_smhr_Trainerprofile.TRAINER_ORGID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_TrainingProfile(_obj_smhr_Trainerprofile);
            if (dt.Rows.Count != 0)
            {
                txt_FirstName.Text = Convert.ToString(dt.Rows[0]["Trainer_FirstName"]);
                txt_MiddleName.Text = Convert.ToString(dt.Rows[0]["Trainer_MiddleName"]);
                txt_LastName.Text = Convert.ToString(dt.Rows[0]["Trainer_LastName"]);
                txt_Address1.Text = Convert.ToString(dt.Rows[0]["Trainer_Address1"]);
                txt_Address2.Text = Convert.ToString(dt.Rows[0]["Trainer_Address2"]);
                txt_Age.Text = Convert.ToString(dt.Rows[0]["Trainer_Age"]);
                txt_mobileNo.Text = Convert.ToString(dt.Rows[0]["Trainer_MoblieNo"]);
                txt_LandLineNo.Text = Convert.ToString(dt.Rows[0]["Trainer_LandlineNo"]);
                txt_Email.Text = Convert.ToString(dt.Rows[0]["Trainer_EmailID"]);
                rc_Country.SelectedIndex = rc_Country.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["Trainer_CountryID"]));
                rc_Country_SelectedIndexChanged(null, null);
                rc_County.SelectedIndex = rc_County.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["Trainer_CountyID"]));
                rc_County_SelectedIndexChanged(null, null);
                rc_Qualification.SelectedIndex = rc_Qualification.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["Trainer_Qualification"]));
                rc_Town.SelectedIndex = rc_Town.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["Trainer_TownID"]));
                rad_IsActive.Checked = Convert.ToBoolean(dt.Rows[0]["Trainer_Status"]);
                txt_DOB.SelectedDate = Convert.ToDateTime(dt.Rows[0]["Trainer_DOB"]);
                rc_CourseCategory.SelectedIndex = rc_CourseCategory.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["Trainer_CourseCategory"]));
                rc_ServiceProvider.SelectedIndex = rc_ServiceProvider.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["Trainer_ServiceProvider"]));
                txt_YeaofPass.Text = Convert.ToString(dt.Rows[0]["Trainer_YearOfPass"]);
                txt_Institute.Text = Convert.ToString(dt.Rows[0]["Trainer_Institute"]);
                txt_Percentage.Text = Convert.ToString(dt.Rows[0]["Trainer_Percentage"]);
                txt_ZipCode.Text = Convert.ToString(dt.Rows[0]["Trainer_ZipCode"]);

                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    btn_Update.Visible = false;

                }

                else
                {
                    btn_Update.Visible = true;
                }

                Rp_CY_ViewDetails.Selected = true;
                Rm_Course_page.SelectedIndex = 0;
            }





        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "TrainerProfile", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadDropDowns()
    {
        try
        {
            BindServiceProviders();
            CountryBind();

            BindQualification();
            BindCourseCategory();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "TrainerProfile", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void BindCourseCategory()
    {
        try
        {
            SMHR_COURSE _obj_Course = new SMHR_COURSE();
            _obj_Course.OPERATION = operation.Select2;
            _obj_Course.COURSE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            rc_CourseCategory.DataSource = BLL.get_Course(_obj_Course);
            rc_CourseCategory.DataTextField = "COURSE_NAME";
            rc_CourseCategory.DataValueField = "COURSE_ID";
            rc_CourseCategory.DataBind();
            rc_CourseCategory.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "TrainerProfile", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void BindQualification()
    {
        try
        {
            SMHR_MASTERS _obj_Smhr_Masters = new SMHR_MASTERS();
            _obj_Smhr_Masters.MASTER_TYPE = "QUALIFICATION";
            _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            rc_Qualification.DataSource = BLL.get_MasterRecords(_obj_Smhr_Masters);
            rc_Qualification.DataValueField = "HR_MASTER_ID";
            rc_Qualification.DataTextField = "HR_MASTER_CODE";
            rc_Qualification.DataBind();
            rc_Qualification.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "TrainerProfile", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    protected void clck_tab(object sender, RadTabStripEventArgs e)
    {
        try
        {

            if (Rm_Course_page.SelectedIndex == 1)
            {
                Rp_Course_ViewDetails.Selected = false;
                Rp_Course_ViewDetails.Visible = false;
                rad_Qualifiaction.Selected = true;
                rad_Qualifiaction.Visible = true;

            }
            else
            {
                Rp_Course_ViewDetails.Selected = true;
                Rp_Course_ViewDetails.Visible = true;
                rad_Qualifiaction.Selected = false;
                rad_Qualifiaction.Visible = false;
                Rm_Course_page.SelectedIndex = 0;

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "TrainerProfile", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    private void CheckDOB()
    {
        try
        {
           
            txt_Age.Text = string.Empty;
            DateTime dt = Convert.ToDateTime(txt_DOB.SelectedDate.Value);
            ///////////////// Added By Joseph///////////////
            DateTime presentdate = DateTime.Now;
           TimeSpan dt1 = presentdate - dt;
            
           
            if (dt < DateTime.Now)
            {
                string str = Convert.ToString(Convert.ToDouble((dt1.TotalDays) / 365.25));

                if (str.Contains('.'))
                    str = str.Substring(0, (str.IndexOf('.')));
                
                double Days = Convert.ToDouble(str);
               //double Days = Math.Round((dt1.TotalDays) / 365.25, 0);
                if (int_DOBS < Days)
                {
                    if (int_DOBE < Days)
                    {
                        if (Days > 80)
                        {

                            txt_DOB.SelectedDate = null;
                            txt_DOB.Focus();
                            BLL.ShowMessage(this, "Trainer should not be more than 80 years of age");

                        }
                        else if (Days < 18)
                        {
                            txt_DOB.SelectedDate = null;
                            txt_DOB.Focus();
                            BLL.ShowMessage(this, "Trainer should not be less than 18 years of age");
                        }
                        else
                        {
                            txt_Age.Text = Convert.ToString(Days);
                        }
                    }
                    else
                    {
                        txt_Age.Text = Convert.ToString(Days);
                    }
                }
                else
                {
                    txt_DOB.SelectedDate = null;
                    txt_DOB.Focus();
                    BLL.ShowMessage(this, "Trainer should not be less than 18 years of age");
                }

            }
            else
            {
                txt_DOB.SelectedDate = null;
                txt_DOB.Focus();
                BLL.ShowMessage(this, "Date of Birth should not be less than Current Date");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "TrainerProfile", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


    }
    protected void txt_DOB_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        try
        {
            if (txt_DOB.SelectedDate < DateTime.Now)
            {
                CheckDOB();//return;
            }
            else
            {
                BLL.ShowMessage(this, "Date of Birth should not be less than Current Date");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "TrainerProfile", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadGrid()
    {
        try
        {
            SMHR_TRAINERPROFILE _obj_smhr_Trainerprofile = new SMHR_TRAINERPROFILE();
            _obj_smhr_Trainerprofile.OPERATION = operation.Select;
            _obj_smhr_Trainerprofile.TRAINER_ORGID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_TrainingProfile(_obj_smhr_Trainerprofile);
            Rg_Countries.DataSource = dt;
            //SMHR_COUNTRY bh = new SMHR_COUNTRY();
            //bh.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //DataTable dt = BLL.get_Country(bh);
            //Rg_Countries.DataSource = dt;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "TrainerProfile", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void BindServiceProviders()
    {
        try
        {
            SMHR_SERVICEPROVIDER _obj_Smhr_ServiceProvider = new SMHR_SERVICEPROVIDER();
            _obj_Smhr_ServiceProvider.OPERATION = operation.Select2;
            _obj_Smhr_ServiceProvider.SERVICEPROVIDER_TYPE = "Trainer";
            _obj_Smhr_ServiceProvider.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT = BLL.get_ServiceProvider(_obj_Smhr_ServiceProvider);
            rc_ServiceProvider.DataSource = DT;
            rc_ServiceProvider.DataValueField = "SERVICEPROVIDER_ID";
            rc_ServiceProvider.DataTextField = "SERVICEPROVIDER_NAME";
            rc_ServiceProvider.DataBind();
            rc_ServiceProvider.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "TrainerProfile", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void CountryBind()
    {
        try
        {
            SMHR_COUNTRY _obj_Country = new SMHR_COUNTRY();
            _obj_Country.OPERATION = operation.Select;
            _obj_Country.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            rc_Country.DataSource = BLL.get_Country(_obj_Country);
            rc_Country.DataTextField = "COUNTRY_CODE";
            rc_Country.DataValueField = "COUNTRY_ID";
            rc_Country.DataBind();
            rc_Country.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "TrainerProfile", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rc_Country_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rc_County.SelectedIndex = -1;
            rc_Town.SelectedIndex = -1;
            SMHR_COUNTY _obj_Smhr_County = new SMHR_COUNTY();
            _obj_Smhr_County.OPERATION = operation.Select2;
            _obj_Smhr_County.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_County.COUNTRY_ID = Convert.ToInt32(rc_Country.SelectedValue);
            rc_County.DataSource = BLL.get_County(_obj_Smhr_County);
            rc_County.DataTextField = "COUNTY_CODE";
            rc_County.DataValueField = "COUNTY_ID";
            rc_County.DataBind();
            rc_County.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "TrainerProfile", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rc_County_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rc_Town.SelectedIndex = -1;
            SMHR_TOWN _obj_Smhr_Town = new SMHR_TOWN();
            _obj_Smhr_Town.OPERATION = operation.Select2;
            _obj_Smhr_Town.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Town.COUNTY_ID = Convert.ToInt32(rc_County.SelectedValue);
            rc_Town.DataSource = BLL.get_Town(_obj_Smhr_Town);
            rc_Town.DataTextField = "TOWN_CODE";
            rc_Town.DataValueField = "TOWN_ID";
            rc_Town.DataBind();
            rc_Town.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "TrainerProfile", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            string ErrorMesage = string.Empty;
            if (ValiadteQualification(out ErrorMesage))
            {
                SMHR_TRAINERPROFILE _obj_smhr_Trainerprofile = new SMHR_TRAINERPROFILE();


                _obj_smhr_Trainerprofile.Trainer_ServiceProvider = Convert.ToInt32(rc_ServiceProvider.SelectedItem.Value);
                _obj_smhr_Trainerprofile.Trainer_CourseCategory = Convert.ToInt32(rc_CourseCategory.SelectedItem.Value);
                _obj_smhr_Trainerprofile.Trainer_FirstName = txt_FirstName.Text;
                _obj_smhr_Trainerprofile.Trainer_MiddleName = txt_MiddleName.Text;
                _obj_smhr_Trainerprofile.Trainer_LastName = txt_LastName.Text;
                _obj_smhr_Trainerprofile.Trainer_Address1 = txt_Address1.Text;
                _obj_smhr_Trainerprofile.Trainer_Address2 = txt_Address2.Text;
                _obj_smhr_Trainerprofile.Trainer_Age = Convert.ToInt32(txt_Age.Text);
                _obj_smhr_Trainerprofile.Trainer_CountryID = Convert.ToInt32(rc_Country.SelectedItem.Value);
                _obj_smhr_Trainerprofile.Trainer_CountyID = Convert.ToInt32(rc_County.SelectedItem.Value);
                _obj_smhr_Trainerprofile.Trainer_TownID = Convert.ToInt32(rc_Town.SelectedItem.Value);
                _obj_smhr_Trainerprofile.Trainer_MoblieNo = Convert.ToString(txt_mobileNo.Text);
                _obj_smhr_Trainerprofile.Trainer_LandlineNo = Convert.ToString(txt_LandLineNo.Text);
                _obj_smhr_Trainerprofile.Trainer_EmailID = Convert.ToString(txt_Email.Text);
                _obj_smhr_Trainerprofile.Trainer_DOB = txt_DOB.SelectedDate.Value;
                _obj_smhr_Trainerprofile.Trainer_Status = rad_IsActive.Checked;
                _obj_smhr_Trainerprofile.Trainer_Qualification = Convert.ToInt32(rc_Qualification.SelectedItem.Value);
                _obj_smhr_Trainerprofile.Trainer_Institute = Convert.ToString(txt_Institute.Text);
                _obj_smhr_Trainerprofile.Trainer_Percentage = Convert.ToString(txt_Percentage.Text);
                _obj_smhr_Trainerprofile.Trainer_YearOfPass = Convert.ToString(txt_YeaofPass.Text);
                _obj_smhr_Trainerprofile.TRAINER_CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                _obj_smhr_Trainerprofile.TRAINER_CREATEDDATE = DateTime.Now;
                _obj_smhr_Trainerprofile.TRAINER_ORGID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_smhr_Trainerprofile.TRAINER_MODIFYEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                _obj_smhr_Trainerprofile.TRAINER_MODIIFYEDDATE = DateTime.Now;
                _obj_smhr_Trainerprofile.Trainer_ZipCode = Convert.ToString(txt_ZipCode.Text);

                switch (((Button)sender).ID.ToUpper())
                {
                    case "BTN_UPDATE":

                        if (Convert.ToBoolean(rad_IsActive.Checked) == false)
                        {

                            SMHR_COURSESCHEDULE _obj_CS = new SMHR_COURSESCHEDULE();
                            _obj_CS.OPERATION = operation.Offline;
                            _obj_CS.COURSESCHEDULE_TRAINERID = Convert.ToInt32(ld_ID.Text);
                            _obj_CS.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dtc = BLL.get_CourseSchedule(_obj_CS);
                            if (!Convert.ToBoolean(dtc.Rows[0]["Status"]))
                            {
                                BLL.ShowMessage(this, "Cannot make inactive");
                                rad_IsActive.Checked = true;
                                return;
                            }
                        }
                        _obj_smhr_Trainerprofile.Trainer_TrainerProfile_ID = Convert.ToInt32(ld_ID.Text);
                        _obj_smhr_Trainerprofile.OPERATION = operation.Update;
                        if (BLL.set_TrainingProfile(_obj_smhr_Trainerprofile))
                            BLL.ShowMessage(this, "Information Updated Successfully");
                        else
                            BLL.ShowMessage(this, "Information Not Saved");
                        break;
                    case "BTN_SAVE":

                        _obj_smhr_Trainerprofile.OPERATION = operation.CountEmailID;
                        if (Convert.ToInt32(BLL.get_TrainingProfile(_obj_smhr_Trainerprofile).Rows[0][0]) > 0)
                        {

                            BLL.ShowMessage(this, "Email ID Already Exists.Please Enter another Email ID");
                            return;
                        }
                        else
                        {
                            _obj_smhr_Trainerprofile.OPERATION = operation.Insert;
                            if (BLL.set_TrainingProfile(_obj_smhr_Trainerprofile))
                                BLL.ShowMessage(this, "Information Saved Successfully");
                            else
                                BLL.ShowMessage(this, "Information Not Saved");
                            break;
                        }
                    default:
                        break;
                }
                LoadGrid();
                Rm_CY_page.SelectedIndex = 0;
                Rg_Countries.DataBind();
            }
            else
            {
                BLL.ShowMessage(this, ErrorMesage);
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "TrainerProfile", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    private bool ValiadteQualification(out string ErrorMessage)
    {
        ErrorMessage = string.Empty;
        if (rc_Qualification.SelectedIndex > 0)
        {
            if (!string.IsNullOrEmpty(txt_Institute.Text))
            {
                if (!string.IsNullOrEmpty(txt_YeaofPass.Text))
                {
                    if (!string.IsNullOrEmpty(txt_Percentage.Text))
                    {
                        return true;
                    }
                    else
                    {
                        ErrorMessage = "Please Select Percentage";
                        return false;
                    }
                }
                else
                {
                    ErrorMessage = "Please Select Year of Pass";
                    return false;
                }
            }
            else
            {
                ErrorMessage = "Please Select Institute";
                return false;
            }
        }
        else
        {
            ErrorMessage = "Please Select Qualification";
            return false;
        }

    }


    //    protected void btn_Update_Click(object sender, EventArgs e)
    //    {
    //        SMHR_TRAINERPROFILE _obj_smhr_Trainerprofile = new SMHR_TRAINERPROFILE();

    //        _obj_smhr_Trainerprofile.Trainer_ServiceProvider = Convert.ToInt32(rc_ServiceProvider.SelectedItem.Value);
    //        _obj_smhr_Trainerprofile.Trainer_CourseCategory = Convert.ToInt32(rc_CourseCategory.SelectedItem.Value);
    //        _obj_smhr_Trainerprofile.Trainer_FirstName = txt_FirstName.Text;
    //        _obj_smhr_Trainerprofile.Trainer_MiddleName = txt_MiddleName.Text;
    //        _obj_smhr_Trainerprofile.Trainer_LastName = txt_LastName.Text;
    //        _obj_smhr_Trainerprofile.Trainer_Address1 = txt_Address1.Text;
    //        _obj_smhr_Trainerprofile.Trainer_Address2 = txt_Address2.Text;
    //        _obj_smhr_Trainerprofile.Trainer_Age = Convert.ToInt32(txt_Age.Text);
    //        _obj_smhr_Trainerprofile.Trainer_CountryID = Convert.ToInt32(rc_Country.SelectedItem.Value);
    //        _obj_smhr_Trainerprofile.Trainer_CountyID = Convert.ToInt32(rc_County.SelectedItem.Value);
    //        _obj_smhr_Trainerprofile.Trainer_TownID = Convert.ToInt32(rc_Town.SelectedItem.Value);
    //        _obj_smhr_Trainerprofile.Trainer_MoblieNo = Convert.ToString(txt_mobileNo.Text);
    //        _obj_smhr_Trainerprofile.Trainer_LandlineNo = Convert.ToString(txt_LandLineNo.Text);
    //        _obj_smhr_Trainerprofile.Trainer_EmailID = Convert.ToString(txt_Email.Text);
    //        _obj_smhr_Trainerprofile.Trainer_DOB = txt_DOB.SelectedDate.Value;
    //        _obj_smhr_Trainerprofile.Trainer_Status = rad_IsActive.Checked;
    //        _obj_smhr_Trainerprofile.Trainer_Qualification = Convert.ToInt32(rc_Qualification.SelectedItem.Value);
    //        _obj_smhr_Trainerprofile.Trainer_Institute = Convert.ToString(txt_Institute.Text);
    //        _obj_smhr_Trainerprofile.Trainer_Percentage = Convert.ToString(txt_Percentage.Text);
    //        _obj_smhr_Trainerprofile.Trainer_YearOfPass = Convert.ToString(txt_YeaofPass.Text);

    //        BLL.set_TrainingProfile(_obj_smhr_Trainerprofile);
    //    }


    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            Clear();
            LoadGrid();
            Rm_CY_page.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "TrainerProfile", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    private void Clear()
    {
        try
        {
            rc_Town.Items.Clear();
            rc_County.Items.Clear();
            rc_County.Text = string.Empty;
            rc_Town.Text = string.Empty;
            txt_MiddleName.Text = string.Empty;
            txt_Address1.Text = string.Empty;
            txt_Address2.Text = string.Empty;
            txt_Age.Text = string.Empty;
            txt_ConfirmPassword.Text = string.Empty;
            txt_DOB.SelectedDate = null;
            txt_Email.Text = string.Empty;
            txt_FirstName.Text = string.Empty;
            txt_HintAnswer.Text = string.Empty;
            txt_Institute.Text = string.Empty;
            txt_LandLineNo.Text = string.Empty;
            txt_LastName.Text = string.Empty;
            rc_Country.SelectedIndex = -1;
            txt_Password.Text = string.Empty;
            txt_Percentage.Text = string.Empty;
            txt_username.Text = string.Empty;
            rc_Qualification.SelectedIndex = -1;
            rc_Town.SelectedIndex = -1;
            rc_CourseCategory.SelectedIndex = -1;
            rc_ServiceProvider.SelectedIndex = -1;
            txt_YeaofPass.Text = string.Empty;
            txt_ZipCode.Text = string.Empty;
            txt_mobileNo.Text = string.Empty;
            rc_County.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "TrainerProfile", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void btn_Profile_Click(object sender, EventArgs e)
    {

    }
}