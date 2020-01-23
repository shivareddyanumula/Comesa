using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Data;
using Telerik.Web.UI;
using System.IO;
using System.Data.OleDb;
using System.Configuration;
using System.Collections;

public partial class Masters_frm_Location : System.Web.UI.Page
{
    protected SMHR_LOCATION _obj_smhr_loc;

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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("LOCATION");
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
                    Rg_Location.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
                Page.Validate();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Location", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    public void LoadMainGrid()
    {
        try
        {
            _obj_smhr_loc = new SMHR_LOCATION();
            _obj_smhr_loc.MODE = 0;
            _obj_smhr_loc.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            Rg_Location.DataSource = BLL.get_Location(_obj_smhr_loc);
            Rm_HDPT_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Location", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {

            _obj_smhr_loc = new SMHR_LOCATION();
            DataTable dt_Values = new DataTable();
            _obj_smhr_loc.MODE = 1;
            _obj_smhr_loc.LOC_ID = Convert.ToInt32(e.CommandArgument);
            dt_Values = BLL.get_Location(_obj_smhr_loc);
            lbl_LOCID.Text = Convert.ToString(dt_Values.Rows[0]["LOCATION_ID"]);
            //rtbCode.Text = Convert.ToString(dt_Values.Rows[0]["DEPARTMENT_CODE"]);
            rtxt_Locname.Text = Convert.ToString(dt_Values.Rows[0]["LOCATION_NAME"]);
            rtxt_Desc.Text = Convert.ToString(dt_Values.Rows[0]["LOCATION_DESC"]);

            if (dt_Values.Rows[0]["LOCATION_ISACTIVE"] != System.DBNull.Value)
            {
                int Status = Convert.ToInt32(dt_Values.Rows[0]["LOCATION_ISACTIVE"]);
                rcmb_Status.SelectedIndex = rcmb_Status.Items.FindItemIndexByValue(Convert.ToString(Status));
            }
            else
            {
                //chk_Active.Checked = false;
            }
            //code for security
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Edit.Visible = false;

            }

            else
            {
                btn_Edit.Visible = true;
            }
            //rtbCode.Enabled = false;
            rtxt_Locname.Enabled = false;

            btn_Save.Visible = false;
            Rm_HDPT_page.SelectedIndex = 1;
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

            clearControls();
            btn_Save.Visible = true;
            btn_Edit.Visible = false;
            rtxt_Locname.Enabled = true;
            Rm_HDPT_page.SelectedIndex = 1;

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Location", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Rg_Location_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadMainGrid();
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

            //rtbCode.Text = string.Empty;
            rtxt_Locname.Text = string.Empty;
            rtxt_Desc.Text = string.Empty;
            //chk_Active.Checked = false;
            btn_Save.Visible = false;
            btn_Edit.Visible = false;
            Rm_HDPT_page.SelectedIndex = 0;
            rcmb_Status.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Location", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Rg_Department_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadMainGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Location", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_smhr_loc = new SMHR_LOCATION();

            _obj_smhr_loc.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());

            //_obj_smhr_Department.DEPARTMENT_CODE = Convert.ToString(rtbCode.Text);
            _obj_smhr_loc.LOC_NAME = Convert.ToString(rtxt_Locname.Text);
            _obj_smhr_loc.LOC_DESC = Convert.ToString(rtxt_Desc.Text);
            int Status = Convert.ToInt32(rcmb_Status.SelectedItem.Value);
            //   if (chk_Active.Checked)
            _obj_smhr_loc.ISACTIVE = Convert.ToBoolean(Status);
            // else
            //_obj_smhr_Department.DEPARTMENT_ISACTIVE = false;
            _obj_smhr_loc.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_loc.CREATEDDATE = DateTime.Now;
            _obj_smhr_loc.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_loc.LASTMDFDATE = DateTime.Now;

            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_SAVE":
                    _obj_smhr_loc.LOC_NAME = Convert.ToString(rtxt_Locname.Text.Replace("'", "''"));

                    _obj_smhr_loc.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                    _obj_smhr_loc.MODE = 2;
                    DataTable dt = BLL.get_Location(_obj_smhr_loc);
                    if (dt.Rows.Count != 0)
                    {
                        BLL.ShowMessage(this, "This Loaction is already created for this Organisation");
                        rtxt_Locname.Text = string.Empty;
                        rtxt_Desc.Text = string.Empty;
                        return;
                    }
                    _obj_smhr_loc.OPERATION = operation.Insert;
                    if (BLL.set_Location(_obj_smhr_loc))
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;

                case "BTN_EDIT":

                    int Exist = 0;
                    _obj_smhr_loc.LOC_ID = Convert.ToInt32(lbl_LOCID.Text);

                    if (_obj_smhr_loc.ISACTIVE == true)
                    {
                        _obj_smhr_loc.MODE = 3;
                        Exist = Convert.ToInt32(BLL.get_Location(_obj_smhr_loc).Rows[0]["COUNT"]);
                        if (Exist == 1)
                        {
                            BLL.ShowMessage(this, "There Are Employee With The Location Name  " + rtxt_Locname.Text + "  So You can not Make this as Inactive!");
                            Rm_HDPT_page.SelectedIndex = 0;
                            LoadMainGrid();
                            Rg_Location.DataBind();
                            return;
                        }
                    }
                    _obj_smhr_loc.LOC_DESC = rtxt_Desc.Text;
                    _obj_smhr_loc.OPERATION = operation.Update;
                    if (BLL.set_Location(_obj_smhr_loc))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
            }
            Rm_HDPT_page.SelectedIndex = 0;
            LoadMainGrid();
            Rg_Location.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Location", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearControls();
            Rm_HDPT_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Location", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

}
