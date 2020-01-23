using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Data;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

public partial class Masters_frm_HolidayCalendar : System.Web.UI.Page
{
    protected SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit;
    protected SMHR_CATEGORY _obj_Smhr_Category;
    protected SMHR_HOLIDAY _obj_Smhr_Holiday;
    static string lbl_HID = "";

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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Holiday Calender");//HOLIDAY");
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
                    Rg_HolidayCalendar.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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


                LoadMainGrid();
                Rg_HolidayCalendar.DataBind();
                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    for (int i = 0; i < Rg_HolidayCalendar.Items.Count; i++)
                    {
                        LinkButton lnkdel = new LinkButton();
                        lnkdel = (LinkButton)Rg_HolidayCalendar.Items[i].FindControl("lnk_Delete") as LinkButton;
                        lnkdel.Visible = false;

                    }
                }
                Page.Validate();
                if (Request.QueryString["POP"] != null)
                {
                    ((HtmlTableRow)Master.FindControl("M_Header")).Style.Add("display", "none");
                    ((HtmlTableRow)Master.FindControl("M_Footer")).Style.Add("display", "none");
                    ((RadMenu)Master.FindControl("MainMenu")).Style.Add("display", "none");
                    ((RadComboBox)Master.FindControl("cmbCulture")).Style.Add("display", "none");
                    ((LinkButton)Master.FindControl("Lnk_LogOut")).Style.Add("display", "none");
                    ((LinkButton)Master.FindControl("lnk_Home")).Style.Add("display", "none");
                }

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_HolidayCalendar", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_Smhr_Holiday = new SMHR_HOLIDAY();

            _obj_Smhr_Holiday.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_Smhr_Holiday.HOLMST_BUSINESSUNITID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
            _obj_Smhr_Holiday.HOLMST_CODE = Convert.ToString(rtxt_HCCode.Text);
            if (_obj_Smhr_Holiday.HOLMST_CODE.Contains("'"))
                _obj_Smhr_Holiday.HOLMST_CODE = _obj_Smhr_Holiday.HOLMST_CODE.Replace("'", "''");

            _obj_Smhr_Holiday.HOLMST_DESCRIPTION = Convert.ToString(rtxt_HCDesc.Text);
            if (_obj_Smhr_Holiday.HOLMST_DESCRIPTION.Contains("'"))
                _obj_Smhr_Holiday.HOLMST_DESCRIPTION = _obj_Smhr_Holiday.HOLMST_DESCRIPTION.Replace("'", "''");

            _obj_Smhr_Holiday.HOLMST_DATE = Convert.ToDateTime(rdtp_HCDATE.SelectedDate);
            _obj_Smhr_Holiday.HOLMST_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_Smhr_Holiday.HOLMST_CREATEDDATE = DateTime.Now;
            _obj_Smhr_Holiday.HOLMST_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_Smhr_Holiday.HOLMST_LASTMDFDATE = DateTime.Now;

            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_SAVE":
                    _obj_Smhr_Holiday.OPERATION = operation.Check;
                    if (Convert.ToString(BLL.get_HolidayMaster(_obj_Smhr_Holiday).Rows[0][0]) != "0")
                    {
                        BLL.ShowMessage(this, "This Holiday Name Is Already Exists");
                        rtxt_HCCode.Text = String.Empty;
                        return;
                    }
                    _obj_Smhr_Holiday.OPERATION = operation.Insert;
                    if (BLL.set_HolidayMaster(_obj_Smhr_Holiday))
                    {
                        BLL.ShowMessage(this, "Information Saved Successfully");
                        Rm_HolidayCalendar_page.SelectedIndex = 0;
                        LoadMainGrid();
                        Rg_HolidayCalendar.DataBind();
                    }
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;

                case "BTN_EDIT":

                    _obj_Smhr_Holiday.HOLMST_ID = Convert.ToInt32(lbl_HID);
                    _obj_Smhr_Holiday.OPERATION = operation.Check;
                    if (Convert.ToString(BLL.get_HolidayMaster(_obj_Smhr_Holiday).Rows[0][0]) != "1")
                    {

                        BLL.ShowMessage(this, "This Holiday Name Is Already Exists");
                        rtxt_HCCode.Text = String.Empty;
                        return;
                    }

                    _obj_Smhr_Holiday.OPERATION = operation.Update;
                    if (BLL.set_HolidayMaster(_obj_Smhr_Holiday))
                    {
                        BLL.ShowMessage(this, "Information Updated Successfully");
                        Rm_HolidayCalendar_page.SelectedIndex = 0;
                        LoadMainGrid();
                        Rg_HolidayCalendar.DataBind();
                    }
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_HolidayCalendar", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void LoadCombos()
    {
        try
        {
            //rcmb_BusinessUnit.Items.Clear();
            //SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
            //_obj_Smhr_BusinessUnit.OPERATION = operation.Select;
            //_obj_Smhr_BusinessUnit.ISDELETED = true;
            //rcmb_BusinessUnit.DataSource = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
            //rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            //rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            //rcmb_BusinessUnit.DataBind();
            //rcmb_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));


            SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
            _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"].ToString());
            rcmb_BusinessUnit.Items.Clear();
            rcmb_BusinessUnit.DataSource = BLL.get_Business_Units(_obj_smhr_logininfo);
            rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BusinessUnit.DataBind();
            rcmb_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_HolidayCalendar", ex.StackTrace, DateTime.Now);
        }
    }

    public void LoadMainGrid()
    {
        try
        {
            if (Convert.ToString(Request.QueryString["ID"]) == null)
            {
                _obj_Smhr_Holiday = new SMHR_HOLIDAY();
                _obj_Smhr_Holiday.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                Rg_HolidayCalendar.DataSource = BLL.get_HolidayMaster(_obj_Smhr_Holiday);

                for (int h = 0; h <= Rg_HolidayCalendar.Items.Count - 1; h++)
                {
                    LinkButton lnk_Delete = new LinkButton();
                    lnk_Delete = Rg_HolidayCalendar.Items[h].FindControl("lnk_Delete") as LinkButton;
                    lnk_Delete.Visible = false;
                }
                Rm_HolidayCalendar_page.SelectedIndex = 0;
            }
            else
            {
                _obj_Smhr_Holiday = new SMHR_HOLIDAY();
                _obj_Smhr_Holiday.OPERATION = operation.Empty;
                _obj_Smhr_Holiday.HOLMST_BUSINESSUNITID = Convert.ToInt32(Convert.ToString(Request.QueryString["ID"]));
                _obj_Smhr_Holiday.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                Rg_HolidayCalendar.DataSource = BLL.get_HolidayMaster(_obj_Smhr_Holiday);

                for (int h = 0; h <= Rg_HolidayCalendar.Items.Count - 1; h++)
                {
                    LinkButton lnk_Delete = new LinkButton();
                    lnk_Delete = Rg_HolidayCalendar.Items[h].FindControl("lnk_Delete") as LinkButton;
                    lnk_Delete.Visible = false;
                }
                Rm_HolidayCalendar_page.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_HolidayCalendar", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            LoadCombos();
            btn_Save.Visible = false;
            _obj_Smhr_Holiday = new SMHR_HOLIDAY();
            _obj_Smhr_Holiday.HOLMST_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            lbl_HID = Convert.ToString(e.CommandArgument);
            DataTable dt = new DataTable();
            dt = BLL.get_HolidayMaster(_obj_Smhr_Holiday);

            rcmb_BusinessUnit.SelectedIndex = rcmb_BusinessUnit.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["HOLMST_BUSINESSUNITID"]));
            // rcmb_BusinessUnit.SelectedIndex = Convert.ToInt32(dt.Rows[0]["HOLMST_BUSINESSUNITID"]);
            rtxt_HCCode.Text = Convert.ToString(dt.Rows[0]["HOLMST_CODE"]);
            rtxt_HCDesc.Text = Convert.ToString(dt.Rows[0]["HOLMST_DESCRIPTION"]);
            rdtp_HCDATE.SelectedDate = Convert.ToDateTime(dt.Rows[0]["HOLMST_DATE"]);
            rtxt_HCCode.Enabled = false;
            Rm_HolidayCalendar_page.SelectedIndex = 1;
            //code for security
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Edit.Visible = false;

            }

            else
            {
                btn_Edit.Visible = true;
            }
            //if (Convert.ToString(Request.QueryString["ID"]) == null)
            //{
            //    rcmb_BusinessUnit.Enabled = true;
            //}
            //else
            //{
            rcmb_BusinessUnit.Enabled = false;
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_HolidayCalendar", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            LoadCombos();
            clearControls();
            btn_Save.Visible = true;
            btn_Edit.Visible = false;
            rtxt_HCCode.Enabled = true;
            Rm_HolidayCalendar_page.SelectedIndex = 1;
            if (Convert.ToString(Request.QueryString["ID"]) == null)
            {
                rcmb_BusinessUnit.SelectedIndex = 0;
                rcmb_BusinessUnit.Enabled = true;
            }
            else
            {
                rcmb_BusinessUnit.SelectedIndex = rcmb_BusinessUnit.Items.FindItemIndexByValue(Convert.ToString(Request.QueryString["ID"]));
                rcmb_BusinessUnit.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_HolidayCalendar", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Delete_Command(object sender, CommandEventArgs e)
    {
        try
        {
            _obj_Smhr_Holiday = new SMHR_HOLIDAY();
            _obj_Smhr_Holiday.HOLMST_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            lbl_HID = Convert.ToString(e.CommandArgument);
            DataTable dt = new DataTable();
            _obj_Smhr_Holiday.OPERATION = operation.Delete;
            if (BLL.set_HolidayMaster(_obj_Smhr_Holiday))
                BLL.ShowMessage(this, "Row deleted Successfully");
            else
                BLL.ShowMessage(this, "Row Could Not be Deleted");

            LoadMainGrid();
            Rg_HolidayCalendar.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_HolidayCalendar", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearControls();
            Rm_HolidayCalendar_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_HolidayCalendar", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rg_HolidayCalendar_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadMainGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_HolidayCalendar", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void clearControls()
    {
        try
        {
            rcmb_BusinessUnit.SelectedIndex = -1;
            rtxt_HCCode.Text = string.Empty;
            rtxt_HCDesc.Text = string.Empty;
            rdtp_HCDATE.SelectedDate = null;

            btn_Save.Visible = false;
            btn_Edit.Visible = false;
            Rm_HolidayCalendar_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_HolidayCalendar", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}