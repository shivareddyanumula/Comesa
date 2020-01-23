using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class HR_TRAINING_frm_Location : System.Web.UI.Page
{
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_MASTERS _obj_Smhr_Masters;
    SMHR_TRAINING_LOCATION _obj_Smhr_Location;
    SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit;

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {

            if (!Page.IsPostBack)
            {
               
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Location");//COURSE");
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
                    Rg_Course.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;

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

                lbl_CourseHeader.Visible = true;
                Page.Validate();
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Location", ex.StackTrace, DateTime.Now);

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
            // lbl_CourseHeader.Visible = false;
            // rcmb_CC.Enabled = false;

            clearControls();
            LoadCombos();
            _obj_Smhr_Location = new SMHR_TRAINING_LOCATION();
            _obj_Smhr_Location.LocationID = Convert.ToInt32(e.CommandArgument);
            _obj_Smhr_Location.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Location.OPERATION = operation.Get;
            DataTable dt = BLL.get_TrainingLocation(_obj_Smhr_Location);
            if (dt.Rows.Count != 0)
            {
                radLocation.Enabled = false;
                lblLocationId.Text = dt.Rows[0]["Location_ID"].ToString();
                radLocation.Text = dt.Rows[0]["Location_Name"].ToString();
                rtxt_StreetName.Text = dt.Rows[0]["Location_StreetName"].ToString();
                LoadCombos();
                radCountry.SelectedIndex = radCountry.FindItemIndexByValue(dt.Rows[0]["Location_CountryID"].ToString());
                radCountry_SelectedIndexChanged(null, null);
                radCounty.SelectedIndex = radCounty.FindItemIndexByValue(dt.Rows[0]["Location_CountyID"].ToString());
                radCounty_SelectedIndexChanged(null, null);
                radTown.SelectedIndex = radTown.FindItemIndexByValue(dt.Rows[0]["Location_TownID"].ToString());
                radContactName.Text = dt.Rows[0]["Location_ContactPerson"].ToString();
                radContactNo.Text = dt.Rows[0]["Location_ContactNo"].ToString();
                radEmailID.Text = dt.Rows[0]["Location_EmailID"].ToString();
                radAlternateContact1.Text = dt.Rows[0]["Location_AlternateContactNo"].ToString();
                rad_IsActive.Checked = Convert.ToBoolean(dt.Rows[0]["Location_Status"]);

                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    btn_Update.Visible = false;

                }

                else
                {
                    btn_Update.Visible = true;
                }

                Rm_Course_page.SelectedIndex = 1;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Location", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            radLocation.Enabled = true;
            // lbl_CourseHeader.Visible = false;
            clearControls();
            LoadCombos();
            btn_Save.Visible = true;
            Rm_Course_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Location", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void LoadGrid()
    {
        try
        {
            _obj_Smhr_Location = new SMHR_TRAINING_LOCATION();
            _obj_Smhr_Location.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Location.OPERATION = operation.Select;
            DataTable DT = BLL.get_TrainingLocation(_obj_Smhr_Location);
            if (DT.Rows.Count != 0)
            {
                Rg_Course.DataSource = DT;
            }

            else
            {
                DataTable dt1 = new DataTable();
                Rg_Course.DataSource = dt1;
            }
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Location", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Rg_Course_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        LoadGrid();
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_Smhr_Location = new SMHR_TRAINING_LOCATION();
            _obj_Smhr_Location.LocationName = radLocation.Text;
            _obj_Smhr_Location.Location_StreetName = rtxt_StreetName.Text;
            _obj_Smhr_Location.Location_CountryID = Convert.ToInt32(radCountry.SelectedValue);
            _obj_Smhr_Location.Location_CountyID = Convert.ToInt32(radCounty.SelectedValue);
            _obj_Smhr_Location.Location_TownID = Convert.ToInt32(radTown.SelectedValue);
            _obj_Smhr_Location.Location_ContactPerson = radContactName.Text;
            _obj_Smhr_Location.Location_EmailID = radEmailID.Text;
            _obj_Smhr_Location.Location_ContactNo = radContactNo.Text;
            _obj_Smhr_Location.Location_AlternateContactNo = radAlternateContact1.Text;
            _obj_Smhr_Location.Location_Status = rad_IsActive.Checked;

            _obj_Smhr_Location.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_Location.CREATEDDATE = DateTime.Now;
            _obj_Smhr_Location.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Location.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_Location.LASTMDFDATE = DateTime.Now;

            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_UPDATE":

                    if (Convert.ToBoolean(rad_IsActive.Checked) == false)
                    {

                        SMHR_COURSESCHEDULE _obj_CS = new SMHR_COURSESCHEDULE();
                        _obj_CS.OPERATION = operation.Scale;
                        _obj_CS.COURSESCHEDULE_LOCATIONID = Convert.ToInt32(lblLocationId.Text);
                        _obj_CS.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtc = BLL.get_CourseSchedule(_obj_CS);
                        if (!Convert.ToBoolean(dtc.Rows[0]["Status"]))
                        {
                            BLL.ShowMessage(this, "Cannot make inactive");
                            rad_IsActive.Checked = true;
                            return;
                        }
                    }

                    _obj_Smhr_Location.OPERATION = operation.Update;
                    _obj_Smhr_Location.LocationID = Convert.ToInt32(lblLocationId.Text);
                    if (BLL.set_TrainingLocation(_obj_Smhr_Location))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                case "BTN_SAVE":
                    _obj_Smhr_Location.OPERATION = operation.Check;
                    if (Convert.ToString(BLL.get_TrainingLocation(_obj_Smhr_Location).Rows[0]["Count"]) != "0")
                    {
                        BLL.ShowMessage(this, "Location with this Name Already Exists");
                        return;
                    }
                    _obj_Smhr_Location.OPERATION = operation.Insert;
                    if (BLL.set_TrainingLocation(_obj_Smhr_Location))
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                default:
                    break;
            }
            Rm_Course_page.SelectedIndex = 0;
            LoadGrid();
            Rg_Course.DataBind();

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Location", ex.StackTrace, DateTime.Now);

            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        clearControls();
    }

    private void LoadCombos()
    {
        try
        {
            SMHR_COUNTRY _obj_Country = new SMHR_COUNTRY();
            _obj_Country.OPERATION = operation.Select;
            _obj_Country.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            radCountry.DataSource = BLL.get_Country(_obj_Country);
            radCountry.DataTextField = "COUNTRY_CODE";
            radCountry.DataValueField = "COUNTRY_ID";
            radCountry.DataBind();
            radCountry.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Location", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void clearControls()
    {
        try
        {
            radLocation.Text = string.Empty;
            rtxt_StreetName.Text = string.Empty;
            radCountry.Items.Clear();
            radCountry.Text = string.Empty;
            radCounty.Items.Clear();
            radCounty.Text = string.Empty;
            radTown.Items.Clear();
            radTown.Text = string.Empty;
            radContactName.Text = string.Empty;
            radContactNo.Text = string.Empty;
            radEmailID.Text = string.Empty;
            radAlternateContact1.Text = string.Empty;
            //rfv_txt_PhoneNumber.Text = string.Empty;
            btn_Save.Visible = false;
            btn_Update.Visible = false;
            Rm_Course_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Location", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void radCountry_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (string.Compare(radCountry.SelectedItem.Text, "Select", true) != 0)
            {
                SMHR_COUNTY _obj_Smhr_County = new SMHR_COUNTY();
                _obj_Smhr_County.OPERATION = operation.Select2;
                _obj_Smhr_County.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_County.COUNTRY_ID = Convert.ToInt32(radCountry.SelectedValue);
                radCounty.DataSource = BLL.get_County(_obj_Smhr_County);
                radCounty.DataTextField = "COUNTY_CODE";
                radCounty.DataValueField = "COUNTY_ID";
                radCounty.DataBind();
                radCounty.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Location", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void radCounty_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (string.Compare(radCounty.SelectedItem.Text, "Select", true) != 0)
            {
                SMHR_TOWN _obj_Smhr_Town = new SMHR_TOWN();
                _obj_Smhr_Town.OPERATION = operation.Select2;
                _obj_Smhr_Town.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_Town.COUNTY_ID = Convert.ToInt32(radCounty.SelectedValue);
                radTown.DataSource = BLL.get_Town(_obj_Smhr_Town);
                radTown.DataTextField = "TOWN_CODE";
                radTown.DataValueField = "TOWN_ID";
                radTown.DataBind();
                radTown.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Location", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
