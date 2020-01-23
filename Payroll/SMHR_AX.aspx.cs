using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using SPMS;
using Telerik.Web.UI;
using SMHR;

public partial class PMS_SMHR_AX : System.Web.UI.Page
{
    SMHR_AX _obj_Smhr_Ax = new SMHR_AX();
    SMHR_BUSINESSUNIT _obj_smhr_businessunit;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;

    #region Page Load Method
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
            if (!Page.IsPostBack)
            {

                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Financial Dimension");//AX DIMENSION");
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
                    Rg_AXINTEGRATION.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Save.Visible = false;

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
                LoadGrid();
                LoadCombos();


            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "SMHR_AX", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region Add Command
    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            clearControls();
            rtxt_DIM1Name.Enabled = true;
            btn_Save.Visible = true;
            //btn_cancel.Visible = true;
            btn_Save.Text = "Save";
            rcmb_BUI.Enabled = true;
            rcmb_BUI.SelectedIndex = 0;
            lbl_Id.Text = string.Empty;
            Rm_AXINTEGRATION_PAGE.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "SMHR_AX", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadCombos()
    {
        try
        {
            _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
            DataTable dt_Details = new DataTable();

            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            rcmb_BUI.DataSource = dt_BUDetails;
            rcmb_BUI.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BUI.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BUI.DataBind();
            rcmb_BUI.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "SMHR_AX", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /// <summary>
    ///IN THIS CLEAR CONTROLS METHOD CLEARING ALL CONTROLS
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>

    protected void clearControls()
    {
        try
        {
            lbl_Id.Text = string.Empty;
            rtxt_DIM1Name.Text = string.Empty;
            rtxt_DIM2Name.Text = string.Empty;
            rtxt_Dim3.Text = string.Empty;

            btn_Save.Visible = false;
            Rm_AXINTEGRATION_PAGE.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "SMHR_AX", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    #region LoadGrid
    /// <summary>
    ///IN THIS data binding from database to datatable binding to radgrid
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void Rg_AXINTEGRATION_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            _obj_Smhr_Ax.Mode = 1;
            _obj_Smhr_Ax.SMHR_AX_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Ax.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt = Pms_Bll.get_Smhr_Ax(_obj_Smhr_Ax);
            if (dt.Rows.Count != 0)
            {
                Rg_AXINTEGRATION.DataSource = dt;

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "SMHR_AX", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadGrid()
    {
        try
        {
            _obj_Smhr_Ax.Mode = 1;
            _obj_Smhr_Ax.SMHR_AX_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Ax.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt = Pms_Bll.get_Smhr_Ax(_obj_Smhr_Ax);
            if (dt.Rows.Count != 0)
            {
                Rg_AXINTEGRATION.DataSource = dt;

                Rg_AXINTEGRATION.DataBind();
            }
            else
            {
                DataTable dt1 = new DataTable();

                Rg_AXINTEGRATION.DataSource = dt1;

                Rg_AXINTEGRATION.DataBind();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "SMHR_AX", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            Pms_Bll.ShowMessage(this, ex.Message.ToString());
            return;
        }
    }
    #endregion

    #region EditCommand


    /// <summary>
    ///IN THIS BASED ON Project_ID(COMMANDARGUMENT) ALL DATA WILL BE TAKEN TO DATATABLE THEN WE CAN BIND TO INDIVIDUAL FIELDS
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>

    protected void lnk_edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            LoadCombos();
            clearControls();
            btn_Save.Text = "Update";
            //code for security
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Save.Visible = false;

            }

            else
            {
                btn_Save.Visible = true;
            }

            _obj_Smhr_Ax.Mode = 2;
            _obj_Smhr_Ax.SMHR_AX_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            DataTable DT = Pms_Bll.get_Smhr_Ax(_obj_Smhr_Ax);
            lbl_Id.Text = Convert.ToString(DT.Rows[0]["SMHR_AX_ID"]);

            rtxt_DIM1Name.Text = Convert.ToString(DT.Rows[0]["SMHR_AX_DIM1"]);

            rtxt_DIM2Name.Text = Convert.ToString(DT.Rows[0]["SMHR_AX_DIM2"]);
            rtxt_Dim3.Text = Convert.ToString(DT.Rows[0]["SMHR_AX_DIM3"]);


            rcmb_BUI.SelectedIndex = rcmb_BUI.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["SMHR_AX_BU_ID"]));

            btn_Save.Visible = true;
            rcmb_BUI.Enabled = false;
            Rm_AXINTEGRATION_PAGE.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "SMHR_AX", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            Pms_Bll.ShowMessage(this, ex.Message.ToString());
            return;
        }
    }
    #endregion

    #region Save And Cancel Methods

    /// <summary>
    /// WHILE INSERTING THERE IS NO NEED TO ADD LAST MDF BY,LAST MDF DATE,BASED ON LABEL _PROJECTID IF IT IS NULL THEN PERFORM INSERTION 
    /// IF END DATE IS NULL THEN WE HAVE TO USE THIS AND IT IS TO BE DEFINED IN TRANSLAYER
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (lbl_Id.Text == "")
            {

                _obj_Smhr_Ax.Mode = 5;
                //_obj_Smhr_Ax.SMHR_AX_DIM1 = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_DIM1Name.Text));
                _obj_Smhr_Ax.SMHR_AX_BU_ID = Convert.ToInt32(rcmb_BUI.SelectedItem.Value);

                DataTable dt = Pms_Bll.get_Smhr_Ax(_obj_Smhr_Ax);
                if (dt.Rows.Count != 0)
                {
                    Pms_Bll.ShowMessage(this, "Business Unit Already Exist");
                    rtxt_DIM1Name.Text = string.Empty;
                    return;
                }
                else
                {
                    _obj_Smhr_Ax.Mode = 3;
                    _obj_Smhr_Ax.SMHR_AX_DIM1 = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_DIM1Name.Text));
                    _obj_Smhr_Ax.SMHR_AX_DIM2 = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_DIM2Name.Text));
                    _obj_Smhr_Ax.SMHR_AX_DIM3 = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_Dim3.Text));

                    _obj_Smhr_Ax.SMHR_AX_BU_ID = Convert.ToInt32(rcmb_BUI.SelectedValue);

                    _obj_Smhr_Ax.SMHR_AX_CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                    _obj_Smhr_Ax.SMHR_AX_CREATEDDATE = DateTime.Now;
                    _obj_Smhr_Ax.SMHR_AX_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);



                    bool status = Pms_Bll.set_Smhr_Ax(_obj_Smhr_Ax);
                    if (status == true)
                    {
                        Pms_Bll.ShowMessage(this, "Record Inserted Successfully");
                        LoadGrid();
                        btn_Save.Visible = true;
                        Rm_AXINTEGRATION_PAGE.SelectedIndex = 0;
                        return;
                    }
                }
            }
            else
            {
                _obj_Smhr_Ax.Mode = 4;
                _obj_Smhr_Ax.SMHR_AX_DIM1 = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_DIM1Name.Text));
                _obj_Smhr_Ax.SMHR_AX_DIM2 = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_DIM2Name.Text));
                _obj_Smhr_Ax.SMHR_AX_DIM3 = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_Dim3.Text));

                _obj_Smhr_Ax.SMHR_AX_BU_ID = Convert.ToInt32(rcmb_BUI.SelectedValue);

                _obj_Smhr_Ax.SMHR_AX_ID = Convert.ToInt32(lbl_Id.Text);

                _obj_Smhr_Ax.SMHR_AX_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                _obj_Smhr_Ax.SMHR_AX_LASTMDFDATE = DateTime.Now;

                bool status = Pms_Bll.set_Smhr_Ax(_obj_Smhr_Ax);
                if (status == true)
                {
                    Pms_Bll.ShowMessage(this, "Record Updated Successfully");
                    LoadGrid();
                    btn_Save.Visible = true;
                    Rm_AXINTEGRATION_PAGE.SelectedIndex = 0;
                    return;
                }


            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "SMHR_AX", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            Pms_Bll.ShowMessage(this, ex.Message.ToString());
            return;
        }
    }

    protected void btn_Cancel_Click1(object sender, EventArgs e)
    {
        try
        {
            LoadGrid();
            Rm_AXINTEGRATION_PAGE.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "SMHR_AX", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            Pms_Bll.ShowMessage(this, ex.Message.ToString());
            return;
        }

    }
    #endregion

    protected void rcmb_BUI_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_BUI.SelectedIndex != 0)
            {
                rtxt_Dim3.Text = rcmb_BUI.SelectedItem.Text.ToString().Trim();
            }
            else
            {
                rtxt_Dim3.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "SMHR_AX", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
