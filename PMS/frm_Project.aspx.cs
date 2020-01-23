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

public partial class PMS_frm_Project : System.Web.UI.Page
{
    SPMS_PROJECT _obj_Pms_Project;
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("PROJECT");
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
                    Rg_Project.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;

                  

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
                //COMMENTED ON 25.04.2012
                ////To check whether the organisation have integration with SMPM or not
                //SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
                //_obj_Smhr_BusinessUnit.OPERATION = operation.Get_BU;
                //_obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //DataTable dt_bu = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
                //if (dt_bu.Rows.Count > 0)
                //{
                //    if (dt_bu.Rows[0]["ORGANISATION_INTEGRATION"] != DBNull.Value)
                //    {
                //        if (Convert.ToString(dt_bu.Rows[0]["ORGANISATION_INTEGRATION"]) == "True")
                //        {
                //            Load_Integration_BU();
                //        }
                //        else
                //        {
                //            LoadCombos();
                //        }
                //    }
                //    else
                //    {
                //        LoadCombos();
                //    }
                //}
               
            }
        }
         
         catch (Exception ex)
         {
             SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Project", ex.StackTrace, DateTime.Now);
             Response.Redirect("~/Frm_ErrorPage.aspx");
         }
    }
    #endregion

    #region loadcombos,clear fields
    //COMMENTED ON 25.04.2012
    //private void LoadCombos()
    //{
    //    try
    //    {
    //        _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
    //        _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
    //        _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //        _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
    //        DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
    //        if (dt_BUDetails.Rows.Count != 0)
    //        {
    //            rcmb_BUI.DataSource = dt_BUDetails;
    //            rcmb_BUI.DataValueField = "BUSINESSUNIT_ID";
    //            rcmb_BUI.DataTextField = "BUSINESSUNIT_CODE";
    //            rcmb_BUI.DataBind();
    //            rcmb_BUI.Items.Insert(0, new RadComboBoxItem("Select"));
    //        }
    //        else
    //        {
    //            DataTable dt_Details = new DataTable();
    //            rcmb_BUI.DataSource = dt_Details;

    //            rcmb_BUI.DataBind();
    //            rcmb_BUI.Items.Insert(0, new RadComboBoxItem("Select"));
    //        }
    //    }

    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Project", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}
    //private void Load_Integration_BU()
    //{
    //    try
    //    {
    //        _obj_Pms_Project = new SPMS_PROJECT();
    //        _obj_Pms_Project.Mode = 8;
    //        _obj_Pms_Project.PROJECT_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
    //        _obj_Pms_Project.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
    //        DataTable dt = Pms_Bll.get_Project(_obj_Pms_Project);
    //        if (dt.Rows.Count != 0)
    //        {
    //            rcmb_BUI.DataSource = dt;
    //            rcmb_BUI.DataValueField = "BUSINESSUNIT_ID";
    //            rcmb_BUI.DataTextField = "BUSINESSUNIT_CODE";
    //            rcmb_BUI.DataBind();
    //            rcmb_BUI.Items.Insert(0, new RadComboBoxItem("Select"));
    //        }
    //        else
    //        {
    //            DataTable dt_Details = new DataTable();
    //            rcmb_BUI.DataSource = dt_Details;
    //            rcmb_BUI.DataBind();
    //            rcmb_BUI.Items.Insert(0, new RadComboBoxItem("Select"));
    //        }
    //    }

    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Project", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}

    /// <summary>
    ///IN THIS CLEAR CONTROLS METHOD CLEARING ALL CONTROLS
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>

    protected void clearControls()
    {
        try
        {
            lbl_ProjectId.Text = string.Empty;
            rtxt_ProjectName.Text = string.Empty;
            rtxt_ProjectDescription.Text = string.Empty;
            btn_Save.Visible = false;
            Rm_PROJECT_PAGE.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Project", ex.StackTrace, DateTime.Now);
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
    protected void Rg_Project_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
         try
        {

        _obj_Pms_Project = new SPMS_PROJECT();
        _obj_Pms_Project.Mode = 1;
        _obj_Pms_Project.PROJECT_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
        DataTable dt = Pms_Bll.get_Project(_obj_Pms_Project);
        if (dt.Rows.Count != 0)
        {
            Rg_Project.DataSource = dt;

        }
        }

         catch (Exception ex)
         {
             SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Project", ex.StackTrace, DateTime.Now);
             Response.Redirect("~/Frm_ErrorPage.aspx");
         }
    }
    protected void LoadGrid()
    {
        try
        {
            _obj_Pms_Project = new SPMS_PROJECT();
            _obj_Pms_Project.Mode = 1;
            _obj_Pms_Project.PROJECT_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = Pms_Bll.get_Project(_obj_Pms_Project);
            if (dt.Rows.Count != 0)
            {
                Rg_Project.DataSource = dt;

                Rg_Project.DataBind();
            }
            else
            {
                DataTable dt1 = new DataTable();

                Rg_Project.DataSource = dt1;

                Rg_Project.DataBind();
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Project", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    #region Add,Edit Command
    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            ////To check whether the organisation have integration with SMPM or not
            //SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
            //_obj_Smhr_BusinessUnit.OPERATION = operation.Get_BU;
            //_obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //DataTable dt_bu = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
            //if (dt_bu.Rows.Count > 0)
            //{
            //    if (dt_bu.Rows[0]["ORGANISATION_INTEGRATION"] != DBNull.Value)
            //    {
            //        if (Convert.ToString(dt_bu.Rows[0]["ORGANISATION_INTEGRATION"]) == "True")
            //        {
            //            Load_Integration_BU();
            //        }
            //        else
            //        {
            //            LoadCombos();
            //        }
            //    }
            //    else
            //    {
            //        LoadCombos();
            //    }
            //}

            clearControls();
            rtxt_ProjectName.Enabled = true;
            btn_Save.Visible = true;

            btn_Save.Text = "Save";
            //rcmb_BUI.Enabled = true;
            //rcmb_BUI.SelectedIndex = 0;
            Rm_PROJECT_PAGE.SelectedIndex = 1;
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Project", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
   


    /// <summary>
    ///IN THIS BASED ON Project_ID(COMMANDARGUMENT) ALL DATA WILL BE TAKEN TO DATATABLE THEN WE CAN BIND TO INDIVIDUAL FIELDS
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>

    protected void lnk_edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            //LoadCombos();
            clearControls();
            btn_Save.Text = "Update";
            rtxt_ProjectName.Enabled = false;
            _obj_Pms_Project = new SPMS_PROJECT();
            _obj_Pms_Project.Mode = 2;

            _obj_Pms_Project.PROJECT_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            DataTable DT = Pms_Bll.get_Project(_obj_Pms_Project);
            if (DT.Rows.Count != 0)
            {
                lbl_ProjectId.Text = Convert.ToString(DT.Rows[0]["PROJECT_ID"]);
                rtxt_ProjectName.Text = Convert.ToString(DT.Rows[0]["PROJECT_NAME"]);
                rtxt_ProjectDescription.Text = Convert.ToString(DT.Rows[0]["PROJECT_DESCRIPTION"]);
                //rcmb_BUI.SelectedIndex = rcmb_BUI.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["PROJECT_BUSINESSUNIT_ID"]));
                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                  

                    btn_Save.Visible = false;

                }
                else
                {
                    btn_Save.Visible = true;
                }
              
                //rcmb_BUI.Enabled = false;
                Rm_PROJECT_PAGE.SelectedIndex = 1;
            }


        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Project", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
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
            if (lbl_ProjectId.Text == "")
            {
                _obj_Pms_Project = new SPMS_PROJECT();
                _obj_Pms_Project.Mode = 5;
                _obj_Pms_Project.PROJECT_NAME = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_ProjectName.Text));
                //_obj_Pms_Project.BUID = Convert.ToInt32(rcmb_BUI.SelectedItem.Value);
                _obj_Pms_Project.PROJECT_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt = Pms_Bll.get_Project(_obj_Pms_Project);
                if (dt.Rows.Count != 0)
                {
                    Pms_Bll.ShowMessage(this, "Project Name Already Exist");
                    return;
                }
                else
                {
                    _obj_Pms_Project = new SPMS_PROJECT();
                    _obj_Pms_Project.PROJECT_NAME = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_ProjectName.Text));
                    _obj_Pms_Project.PROJECT_DESCRIPTION = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_ProjectDescription.Text));
                    //_obj_Pms_Project.BUID = Convert.ToInt32(rcmb_BUI.SelectedValue);
                    _obj_Pms_Project.PROJECT_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Pms_Project.PROJECT_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_Pms_Project.PROJECT_CREATEDDATE = DateTime.Now;


                    _obj_Pms_Project.Mode = 3;

                    bool status = Pms_Bll.set_Project(_obj_Pms_Project);
                    if (status == true)
                    {
                        Pms_Bll.ShowMessage(this, "Record Inserted Successfully");
                        LoadGrid();
                        btn_Save.Visible = true;
                        Rm_PROJECT_PAGE.SelectedIndex = 0;
                        return;
                    }
                }
            }
            else
            {
                _obj_Pms_Project = new SPMS_PROJECT();
                _obj_Pms_Project.PROJECT_ID = Convert.ToInt32(lbl_ProjectId.Text);
                _obj_Pms_Project.PROJECT_NAME = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_ProjectName.Text));
                _obj_Pms_Project.PROJECT_DESCRIPTION = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_ProjectDescription.Text));
                //_obj_Pms_Project.BUID = Convert.ToInt32(rcmb_BUI.SelectedValue);

                _obj_Pms_Project.PROJECT_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Pms_Project.PROJECT_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); 
                _obj_Pms_Project.PROJECT_LASTMDFDATE = DateTime.Now;
                _obj_Pms_Project.Mode = 4;

                bool status = Pms_Bll.set_Project(_obj_Pms_Project);
                if (status == true)
                {
                    Pms_Bll.ShowMessage(this, "Record Updated Successfully");
                    LoadGrid();
                    btn_Save.Visible = true;
                    Rm_PROJECT_PAGE.SelectedIndex = 0;
                    return;
                }


            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Project", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_Click1(object sender, EventArgs e)
    { try
        {
        LoadGrid();
        Rm_PROJECT_PAGE.SelectedIndex = 0;

        }

    catch (Exception ex)
    {
        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Project", ex.StackTrace, DateTime.Now);
        Response.Redirect("~/Frm_ErrorPage.aspx");
    }

    }
    #endregion
}
