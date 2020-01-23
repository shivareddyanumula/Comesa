using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using SPMS;
using SMHR;
using Telerik.Web.UI;
//NEED LOADGRID KRA NEED DATASOURCE
public partial class PMS_frm_Role : System.Web.UI.Page
{
    SPMS_ROLES _obj_Pms_Roles;
    SPMS_ROLEKRA _obj_Pms_RoleKra;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_BUSINESSUNIT _obj_smhr_businessunit;
    SPMS_KRA _obj_Spms_Kras;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
            if (!Page.IsPostBack)
            {

                //LoadGrid();
                ////LoadKra();
                //btn_Close.Visible = false;
                //rtxt_RoleName.Enabled = true;
                //rtxt_RoleID.Enabled = true;
                //btn_Save.Visible = true;
                //btn_cancel.Visible = true;
                //btn_Save.Text = "Save";
                //rcmb_KraType.Visible = false;
                //lbl_Kra.Visible = false;
                //lnk_Kra.Visible = false;
                //Rg_RoleKra.Visible = false;
                //Rm_ROLE_PAGE.SelectedIndex = 0;


                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("ROLES");
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
                    //Rg_role.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;

                    //Rg_role.DataBind();

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
                LoadBusinessUnit();

            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsRole", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /// <summary>
    ///IN THIS CLEAR CONTROLS METHOD I AM MAKING ALL CONTROLS FIELDS AS NULL
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>

    //protected void clearControls()
    //{
    //    //lbl_Role_Id.Text = string.Empty;
    //    //rtxt_RoleName.Text = string.Empty;
    //    //rtxt_RoleID.Text = string.Empty;

    //    //rtxt_RoleDescription.Text = string.Empty;
    //    //rcmb_KraType.SelectedIndex = 0;



    //    //Rm_ROLE_PAGE.SelectedIndex = 0;

    //}



    //#region Add Command,load combos


    ////protected void lnk_Add_Command(object sender, CommandEventArgs e)
    ////{
    ////    try
    ////    {
    ////        clearControls();
    ////        rtxt_RoleName.Enabled = true;
    ////        rtxt_RoleID.Enabled = true;
    ////        btn_Save.Visible = true;
    ////        btn_cancel.Visible = true;
    ////        btn_Save.Text = "Save";
    ////        btn_Save.Enabled = true;
    ////        rcmb_KraType.Visible = false;
    ////        lnk_Kra.Visible = false;
    ////        btn_Close.Visible = false;
    ////        lbl_Kra.Visible = false;
    ////        rtxt_RoleDescription.Enabled = true;
    ////        Rg_RoleKra.Visible = false;
    ////        Rm_ROLE_PAGE.SelectedIndex = 1;
    ////        Rp_ROLE_VIEWDETAILS.Visible = true;
    ////        Rp_ROLE_VIEWMAIN.Visible = false;
    ////        LoadCombos();
    ////        rcmb_BusinessUnitType.Enabled = true;
    ////        DataTable dt_dt = new DataTable();
    ////        Rg_RoleKra.DataSource = dt_dt;
    ////        Rg_RoleKra.DataBind();
    ////    }

    ////    catch (Exception ex)
    ////    {
    ////        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsRole", ex.StackTrace, DateTime.Now);
    ////        Response.Redirect("~/Frm_ErrorPage.aspx");
    ////    }
    ////}


    ////private void LoadCombos()
    ////{
    ////    try
    ////    {
    ////        _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();


    ////        _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
    ////        _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    ////        _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
    ////        DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
    ////        if (dt_BUDetails.Rows.Count != 0)
    ////        {
    ////            rcmb_BusinessUnitType.DataSource = dt_BUDetails;
    ////            rcmb_BusinessUnitType.DataValueField = "BUSINESSUNIT_ID";
    ////            rcmb_BusinessUnitType.DataTextField = "BUSINESSUNIT_CODE";
    ////            rcmb_BusinessUnitType.DataBind();
    ////            rcmb_BusinessUnitType.Items.Insert(0, new RadComboBoxItem("Select"));
    ////        }

    ////        else
    ////        {
    ////            DataTable dt_Details = new DataTable();
    ////            rcmb_BusinessUnitType.DataSource = dt_BUDetails;

    ////            rcmb_BusinessUnitType.DataBind();
    ////            rcmb_BusinessUnitType.Items.Insert(0, new RadComboBoxItem("Select"));
    ////        }

    ////    }

    ////    catch (Exception ex)
    ////    {
    ////        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsRole", ex.StackTrace, DateTime.Now);
    ////        Response.Redirect("~/Frm_ErrorPage.aspx");
    ////    }
    ////}

    //#endregion

    //#region LoadGrid
    ///// <summary>
    ///// HERE DATANEEDSOURCE IS USED TO BIND DATA TO GRID 
    ///// </summary>
    ///// <param name="source"></param>
    ///// <param name="e"></param>

    //protected void Rg_Role_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    //{
    //    try
    //    {
    //        _obj_Pms_Roles = new SPMS_ROLES();
    //        _obj_Pms_Roles.Mode = 1;
    //        _obj_Pms_Roles.ROLES_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
    //        _obj_Pms_Roles.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
    //        DataTable dt = Pms_Bll.get_Roles(_obj_Pms_Roles);
    //        if (dt.Rows.Count != 0)
    //        {
    //            Rg_role.DataSource = dt;

    //        }
    //        else
    //        {

    //            DataTable dt1 = new DataTable();
    //            Rg_role.DataSource = dt1;
    //        }
    //    }

    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsRole", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}
    ///// <summary>
    /////IN THIS data binding from database to datatable binding to radgrid
    ///// </summary>
    ///// <param name="source"></param>
    ///// <param name="e"></param>

    //protected void LoadGrid()
    //{
    //    try
    //    {
    //        _obj_Pms_Roles = new SPMS_ROLES();
    //        _obj_Pms_Roles.Mode = 1;
    //        _obj_Pms_Roles.ROLES_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
    //        _obj_Pms_Roles.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
    //        DataTable dt = Pms_Bll.get_Roles(_obj_Pms_Roles);
    //        if (dt.Rows.Count != 0)
    //        {
    //            Rg_role.DataSource = dt;


    //            Rg_role.DataBind();
    //        }
    //        else
    //        {
    //            DataTable dt1 = new DataTable();
    //            Rg_role.DataSource = dt1;


    //            Rg_role.DataBind();
    //        }
    //    }

    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsRole", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}

    //#endregion

    //#region LoadKra
    ///// <summary>
    ///// HERE I AM LOADING KRA DETAILS FROM PREVIOUS KRA TABLE
    ///// </summary>

    //protected void LoadKra()
    //{
    //    try
    //    {
    //        rcmb_KraType.Items.Clear();
    //        _obj_Spms_Kras = new SPMS_KRA();
    //        _obj_Spms_Kras.Mode = 8;
    //        _obj_Spms_Kras.BUID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
    //        _obj_Spms_Kras.KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
    //        DataTable dt = Pms_Bll.get_Kras(_obj_Spms_Kras);
    //        if (dt.Rows.Count != 0)
    //        {
    //            for (int index = 0; index < Rg_RoleKra.Items.Count; index++)
    //            {
    //                for (int count = 0; count < dt.Rows.Count; count++)
    //                {
    //                    if (Convert.ToString(Rg_RoleKra.Items[index]["ROLE_KRA_ID"].Text) == Convert.ToString(dt.Rows[count]["KRA_ID"]))
    //                    {
    //                        dt.Rows[count].Delete();
    //                        dt.AcceptChanges();
    //                    }
    //                }
    //            }

    //            rcmb_KraType.DataSource = dt;
    //            rcmb_KraType.DataTextField = "KRA_NAME";
    //            rcmb_KraType.DataValueField = "KRA_ID";
    //            rcmb_KraType.DataBind();
    //            rcmb_KraType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
    //        }

    //        else
    //        {
    //            DataTable dt1 = new DataTable();
    //            rcmb_KraType.DataSource = dt1;

    //            rcmb_KraType.DataBind();
    //            rcmb_KraType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

    //        }
    //    }

    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsRole", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}
    //#endregion

    //#region EditCommand


    ///// <summary>
    /////IN THIS BASED ON ROLE_ID(COMMANDARGUMENT) ALL DATA WILL BE TAKEN TO DATATABLE THEN WE CAN BIND TO INDIVIDUAL FIELDS
    ///// </summary>
    ///// <param name="source"></param>
    ///// <param name="e"></param>

    //protected void lnk_edit_command(object sender, CommandEventArgs e)
    //{
    //    try
    //    {
    //        clearControls();
    //        btn_Save.Text = "Update";
    //        btn_Close.Visible = true;
    //        _obj_Pms_Roles = new SPMS_ROLES();
    //        _obj_Pms_Roles.Mode = 2;
    //        _obj_Pms_Roles.ROLES_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
    //        DataTable DT = Pms_Bll.get_Roles(_obj_Pms_Roles);
    //        if (DT.Rows.Count != 0)
    //        {
    //            lbl_Role_Id.Text = Convert.ToString(DT.Rows[0]["ROLE_ID"]);
    //            rtxt_RoleName.Text = Convert.ToString(DT.Rows[0]["ROLE_NAME"]);
    //            rtxt_RoleDescription.Text = Convert.ToString(DT.Rows[0]["ROLE_DESCRIPTION"]);
    //            LoadCombos();
    //            rcmb_BusinessUnitType.SelectedIndex = rcmb_BusinessUnitType.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["ROLE_BUSINESSUNIT_ID"]));
    //            rtxt_RoleID.Text = Convert.ToString(DT.Rows[0]["ROLE_ROLEID"]);
    //            btn_Save.Visible = true;
    //            rtxt_RoleDescription.Enabled = true;
    //            Rm_ROLE_PAGE.SelectedIndex = 1;
    //            //loading data to child grid
    //            _obj_Pms_Roles = new SPMS_ROLES();
    //            _obj_Pms_Roles.Mode = 9;
    //            _obj_Pms_Roles.ROLES_NAME = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_RoleName.Text));
    //            _obj_Pms_Roles.BUID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
    //            _obj_Pms_Roles.ROLES_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
    //            DataTable dt = Pms_Bll.get_Roles(_obj_Pms_Roles);

    //            _obj_Pms_RoleKra = new SPMS_ROLEKRA();
    //            if (dt.Rows.Count != 0)
    //            {
    //                _obj_Pms_RoleKra.ROLE_ID = Convert.ToInt32(dt.Rows[0]["ROLE_ID"]);
    //            }

    //            else
    //            {
    //                _obj_Pms_RoleKra.ROLE_ID = 0;
    //            }
    //            _obj_Pms_RoleKra.Mode = 6;
    //            _obj_Pms_RoleKra.ROLEKRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
    //            DataTable dt1 = Pms_Bll.get_RoleKra(_obj_Pms_RoleKra);
    //            if (dt1.Rows.Count != 0)
    //            {
    //                Rg_RoleKra.DataSource = dt1;
    //                Rg_RoleKra.DataBind();
    //                rcmb_KraType.SelectedIndex = 0;
    //            }
    //            else
    //            {
    //                Pms_Bll.ShowMessage(this, "No KRA Assigned");
    //                DataTable dt2 = new DataTable();
    //                Rg_RoleKra.DataSource = dt2;
    //                Rg_RoleKra.DataBind();
    //                rcmb_KraType.SelectedIndex = 0;

    //            }
    //            rcmb_KraType.Visible = true;
    //            //rcmb_KraType.SelectedIndex = rcmb_KraType.Items.FindItemIndexByValue(Convert.ToString(dt1.Rows[0]["ROLE_KRA_ID"]));
    //            Rg_RoleKra.Visible = true;
    //            btn_Save.Visible = true;
    //            btn_Save.Enabled = true;
    //            lbl_Kra.Visible = true;
    //            lnk_Kra.Visible = true;
    //            rtxt_RoleName.Enabled = false;
    //            rtxt_RoleID.Enabled = false;

    //            rcmb_BusinessUnitType.Enabled = false;

    //            //LoadKra();


    //            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
    //            {
    //                btn_Save.Visible = false;
    //                lnk_Kra.Visible = false;
    //                Rg_RoleKra.Enabled = false;
    //            }

    //            else
    //            {
    //                lnk_Kra.Visible = true;
    //                btn_Save.Visible = true;
    //                Rg_RoleKra.Enabled = true;
    //            }
    //            Rm_ROLE_PAGE.SelectedIndex = 1;
    //            rcmb_KraType.SelectedIndex = 0;
    //            Rp_ROLE_VIEWDETAILS.Visible = true;
    //            Rp_ROLE_VIEWMAIN.Visible = false;
    //        }


    //    }

    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsRole", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}
    //#endregion

    //#region Save,update And Cancel Methods
    ///// <summary>
    ///// WHILE INSERTING THERE IS NO NEED TO ADD LAST MDF BY,LAST MDF DATE,BASED ON LABEL _ROLEID IF IT IS NULL THEN PERFORM INSERTION 
    ///// IF END DATE IS NULL THEN WE HAVE TO USE THIS AND IT IS TO BE DEFINED IN TRANSLAYER
    ///// </summary>
    ///// <param name="sender"></param>
    ///// <param name="e"></param>


    //protected void btn_Save_Click(object sender, EventArgs e)
    //{

    //    try
    //    {
    //        //if (lbl_Role_Id.Text == "")
    //        //{
    //        //    _obj_Pms_Roles = new SPMS_ROLES();
    //        //    _obj_Pms_Roles.Mode = 7;
    //        //    _obj_Pms_Roles.ROLES_NAME = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_RoleName.Text));
    //        //    _obj_Pms_Roles.BUID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
    //        //    _obj_Pms_Roles.ROLES_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
    //        //    DataTable dt5 = Pms_Bll.get_Roles(_obj_Pms_Roles);
    //        //    if (dt5.Rows.Count != 0)
    //        //    {
    //        //        Pms_Bll.ShowMessage(this, "Role Name Already Exist");
    //        //        return;
    //        //    }
    //        //    else
    //        //    {
    //        //        _obj_Pms_Roles = new SPMS_ROLES();
    //        //        _obj_Pms_Roles.ROLES_NAME = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_RoleName.Text));
    //        //        _obj_Pms_Roles.ROLES_DESCRIPTION = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_RoleDescription.Text));

    //        //        //_obj_Pms_Roles.ROLES_KRA_ID = Convert.ToInt32(rcmb_KraType.SelectedItem.Value);

    //        //        _obj_Pms_Roles.ROLES_CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
    //        //        _obj_Pms_Roles.ROLES_CREATEDDATE = DateTime.Now;
    //        //        _obj_Pms_Roles.BUID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
    //        //        _obj_Pms_Roles.ROLES_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
    //        //        _obj_Pms_Roles.ROLES_ROLEID = Convert.ToString(rtxt_RoleID.Text);
    //        //        _obj_Pms_Roles.Mode = 3;

    //        //        bool status = Pms_Bll.set_Roles(_obj_Pms_Roles);
    //        //        if (status == true)
    //        //        {
    //        //            Pms_Bll.ShowMessage(this, "Role Inserted Successfully");
    //        //            LoadGrid();
    //        //            btn_Save.Visible = true;
    //        //            rtxt_RoleName.Visible = true;
    //        //            rtxt_RoleDescription.Visible = true;
    //        //            rtxt_RoleName.Enabled = false;
    //        //            rtxt_RoleID.Enabled = false;
    //        //            rtxt_RoleDescription.Enabled = false;
    //        //            btn_Save.Enabled = false;
    //        //            lnk_Kra.Visible = true;
    //        //            rcmb_KraType.Visible = true;
    //        //            lbl_Kra.Visible = true;

    //        //            Rg_RoleKra.Visible = false;
    //        //            Rm_ROLE_PAGE.SelectedIndex = 1;
    //        //            rcmb_BusinessUnitType.Enabled = false;
    //        //            Rp_ROLE_VIEWDETAILS.Visible = true;
    //        //            LoadKra();

    //        //            return;
    //        //        }
    //        //    }
    //        //}

    //        //else
    //        //{
    //        //    _obj_Pms_Roles = new SPMS_ROLES();
    //        //    _obj_Pms_Roles.ROLES_ID = Convert.ToInt32(lbl_Role_Id.Text);
    //        //    _obj_Pms_Roles.ROLES_NAME = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_RoleName.Text));
    //        //    _obj_Pms_Roles.ROLES_DESCRIPTION = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_RoleDescription.Text));

    //        //    //_obj_Pms_Roles.ROLES_KRA_ID = Convert.ToInt32(rcmb_KraType.SelectedItem.Value);

    //        //    _obj_Pms_Roles.ROLES_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
    //        //    _obj_Pms_Roles.ROLES_LASTMDFDATE = DateTime.Now;
    //        //    _obj_Pms_Roles.BUID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
    //        //    _obj_Pms_Roles.ROLES_ROLEID = Convert.ToString(rtxt_RoleID.Text);
    //        //    _obj_Pms_Roles.Mode = 4;

    //        //    bool status = Pms_Bll.set_Roles(_obj_Pms_Roles);
    //        //    if (status == true)
    //        //    {
    //        //        Pms_Bll.ShowMessage(this, "Role Updated Successfully");
    //        //        LoadGrid();
    //        //        lbl_Kra.Visible = true;

    //        //        btn_Save.Visible = true;
    //        //        Rp_ROLE_VIEWMAIN.Visible = true;
    //        //        Rp_ROLE_VIEWDETAILS.Visible = false;
    //        //        Rm_ROLE_PAGE.SelectedIndex = 0;
    //        //        return;
    //        //    }

    //        //}
    //    }

    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsRole", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}

    //protected void btn_cancel_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        LoadGrid();
    //        Rm_ROLE_PAGE.SelectedIndex = 0;
    //        Rp_ROLE_VIEWMAIN.Visible = true;
    //        Rp_ROLE_VIEWDETAILS.Visible = false;
    //    }

    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsRole", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}
    //#endregion

    //#region addkra command
    //protected void lnk_Kra_Command(object sender, CommandEventArgs e)
    //{
    //    try
    //    {
    //        if (lblRolekra_Id.Text == "")
    //        {
    //            if (Check_Combo(Rg_RoleKra, "lblRolekra_Id", rcmb_KraType))
    //            {
    //                _obj_Pms_Roles = new SPMS_ROLES();
    //                _obj_Pms_Roles.Mode = 9;
    //                _obj_Pms_Roles.ROLES_NAME = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_RoleName.Text));
    //                _obj_Pms_Roles.BUID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
    //                _obj_Pms_Roles.ROLES_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                DataTable dt = Pms_Bll.get_Roles(_obj_Pms_Roles);


    //                _obj_Pms_RoleKra = new SPMS_ROLEKRA();
    //                if (dt.Rows.Count != 0)
    //                {
    //                    _obj_Pms_RoleKra.ROLE_ID = Convert.ToInt32(dt.Rows[0]["ROLE_ID"]);
    //                }
    //                else
    //                {
    //                    _obj_Pms_RoleKra.ROLE_ID = 0;
    //                }
    //                _obj_Pms_RoleKra.ROLE_KRA_ID = Convert.ToInt32(rcmb_KraType.SelectedItem.Value);
    //                _obj_Pms_RoleKra.ROLEKRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                _obj_Pms_RoleKra.ROLEKRA_CREATED_BY = 1; // ### Need to Get the Session
    //                _obj_Pms_RoleKra.ROLEKRA_CREATED_DATE = DateTime.Now;
    //                _obj_Pms_RoleKra.Mode = 3;

    //                bool status = Pms_Bll.set_RoleKra(_obj_Pms_RoleKra);
    //                if (status == true)
    //                {
    //                    Pms_Bll.ShowMessage(this, "KRA Inserted Successfully");
    //                    //LoadGridKra();
    //                    _obj_Pms_RoleKra = new SPMS_ROLEKRA();
    //                    if (dt.Rows.Count != 0)
    //                    {

    //                        _obj_Pms_RoleKra.ROLE_ID = Convert.ToInt32(dt.Rows[0]["ROLE_ID"]);
    //                    }
    //                    else
    //                    {
    //                        _obj_Pms_RoleKra.ROLE_ID = 0;
    //                    }
    //                    _obj_Pms_RoleKra.ROLEKRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                    _obj_Pms_RoleKra.Mode = 6;
    //                    DataTable dt1 = Pms_Bll.get_RoleKra(_obj_Pms_RoleKra);
    //                    Rg_RoleKra.DataSource = dt1;
    //                    Rg_RoleKra.DataBind();
    //                    //LoadKra();
    //                    btn_Save.Visible = true;
    //                    rtxt_RoleName.Visible = true;
    //                    rtxt_RoleDescription.Visible = true;
    //                    rtxt_RoleName.Enabled = false;
    //                    rtxt_RoleDescription.Enabled = false;
    //                    btn_Save.Enabled = false;
    //                    rcmb_KraType.Visible = true;
    //                    btn_Close.Visible = true;
    //                    lnk_Kra.Visible = true;
    //                    rcmb_KraType.SelectedValue = "Select";
    //                    Rg_RoleKra.Visible = true;
    //                    Rm_ROLE_PAGE.SelectedIndex = 1;

    //                    return;


    //                }
    //            }

    //            else
    //            {
    //                Pms_Bll.ShowMessage(this, "This KRA is Already Assigned");
    //            }
    //        }
    //    }

    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsRole", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}
    //#endregion
    //#region LoadGridKra
    ///// <summary>
    ///// HERE DATANEEDSOURCE IS USED TO BIND DATA TO GRID 
    ///// </summary>
    ///// <param name="source"></param>
    ///// <param name="e"></param>

    //protected void Rg_RoleKra_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    //{
    //    try
    //    {

    //        _obj_Pms_Roles = new SPMS_ROLES();
    //        _obj_Pms_Roles.Mode = 9;
    //        _obj_Pms_Roles.ROLES_NAME = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_RoleName.Text));
    //        _obj_Pms_Roles.BUID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
    //        _obj_Pms_Roles.ROLES_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
    //        DataTable dt = Pms_Bll.get_Roles(_obj_Pms_Roles);

    //        _obj_Pms_RoleKra = new SPMS_ROLEKRA();
    //        if (dt.Rows.Count != 0)
    //        {
    //            _obj_Pms_RoleKra.ROLE_ID = Convert.ToInt32(dt.Rows[0]["ROLE_ID"]);
    //        }
    //        _obj_Pms_RoleKra.Mode = 6;
    //        _obj_Pms_RoleKra.ROLEKRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
    //        DataTable dt1 = Pms_Bll.get_RoleKra(_obj_Pms_RoleKra);
    //        if (dt1.Rows.Count != 0)
    //        {
    //            Rg_RoleKra.DataSource = dt1;
    //        }
    //    }

    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsRole", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}
    ///// <summary>
    /////IN THIS data binding from database to datatable binding to radgrid
    ///// </summary>
    ///// <param name="source"></param>
    ///// <param name="e"></param>

    //protected void LoadGridKra()
    //{
    //    try
    //    {
    //        _obj_Pms_RoleKra = new SPMS_ROLEKRA();
    //        _obj_Pms_RoleKra.Mode = 1;
    //        _obj_Pms_RoleKra.ROLEKRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
    //        DataTable dt = Pms_Bll.get_RoleKra(_obj_Pms_RoleKra);
    //        if (dt.Rows.Count != 0)
    //        {
    //            Rg_RoleKra.DataSource = dt;

    //            //Rg_RoleKra.DataBind();
    //        }
    //    }

    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsRole", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}

    //#endregion

    //#region DeleteCommand
    ///// <summary>
    ///// BASED ON ROLE ID(COMMAND ARGUMENT) DATA ROW WILL BE TAKEN TO STATUS VARIABLE
    ///// </summary>
    ///// <param name="sender"></param>
    ///// <param name="e"></param>

    //protected void lnk_delete_command(object sender, CommandEventArgs e)
    //{
    //    try
    //    {

    //        _obj_Pms_RoleKra = new SPMS_ROLEKRA();
    //        _obj_Pms_RoleKra.Mode = 5;

    //        _obj_Pms_RoleKra.ROLEKRA_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
    //        bool status = Pms_Bll.set_RoleKra(_obj_Pms_RoleKra);
    //        if (status == true)
    //        {

    //            Pms_Bll.ShowMessage(this, "KRA Deleted Succesfully");
    //            //LoadGridKra();
    //            _obj_Pms_Roles = new SPMS_ROLES();
    //            _obj_Pms_Roles.Mode = 9;
    //            _obj_Pms_Roles.BUID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
    //            _obj_Pms_Roles.ROLES_NAME = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_RoleName.Text));
    //            _obj_Pms_Roles.ROLES_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
    //            DataTable dt = Pms_Bll.get_Roles(_obj_Pms_Roles);


    //            _obj_Pms_RoleKra = new SPMS_ROLEKRA();
    //            if (dt.Rows.Count != 0)
    //            {
    //                _obj_Pms_RoleKra.ROLE_ID = Convert.ToInt32(dt.Rows[0]["ROLE_ID"]);
    //            }
    //            _obj_Pms_RoleKra.Mode = 6;
    //            _obj_Pms_RoleKra.ROLEKRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
    //            DataTable dt1 = Pms_Bll.get_RoleKra(_obj_Pms_RoleKra);
    //            Rg_RoleKra.DataSource = dt1;
    //            Rg_RoleKra.DataBind();
    //            btn_Save.Visible = true;
    //            rtxt_RoleName.Visible = true;
    //            rtxt_RoleDescription.Visible = true;
    //            rtxt_RoleName.Enabled = false;
    //            rtxt_RoleDescription.Enabled = false;
    //            btn_Save.Enabled = false;
    //            rcmb_KraType.Visible = true;
    //            lnk_Kra.Visible = true;
    //            Rg_RoleKra.Visible = true;
    //            Rm_ROLE_PAGE.SelectedIndex = 1;
    //            //LoadKra();
    //            return;

    //        }
    //        else
    //        {
    //            Pms_Bll.ShowMessage(this, "Not Deleted");

    //            return;

    //        }
    //    }

    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsRole", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}

    //#endregion

    //protected void btn_Close_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        LoadGrid();
    //        Rm_ROLE_PAGE.SelectedIndex = 0;
    //        Rp_ROLE_VIEWDETAILS.Visible = false;
    //        Rp_ROLE_VIEWMAIN.Visible = true;
    //    }

    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsRole", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}


    //public bool Check_Combo(RadGrid rdGrid, string lbl_validate, RadComboBox rcmb_Validate)
    //{

    //    Label lbl_KRANAME = new Label();
    //    lbl_KRANAME = (Label)Rg_RoleKra.FindControl("lbl_KRANAME") as Label;

    //    bool status = true;
    //    if (Rg_RoleKra.Items.Count > 0)
    //    {
    //        for (int i = 0; i < Rg_RoleKra.Items.Count; i++)
    //        {
    //            Label lbl_Control = new Label();
    //            lbl_KRANAME = (Label)Rg_RoleKra.Items[i].FindControl("lbl_KRANAME") as Label;
    //            //lbl_Control = (Label)Rg_KRA.Items[i].FindControl("" + lbl_KRANAME + "") as Label;
    //            if (Convert.ToString(lbl_KRANAME.Text) == Convert.ToString(rcmb_KraType.SelectedItem.Text))
    //            {
    //                status = false;
    //            }
    //        }
    //    }
    //    return status;
    //}

    private void LoadBusinessUnit()
    {
        try
        {
            //_obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            if (dt_BUDetails.Rows.Count != 0)
            {
                rcmb_BusinessUnitType.DataSource = dt_BUDetails;
                rcmb_BusinessUnitType.DataValueField = "BUSINESSUNIT_ID";
                rcmb_BusinessUnitType.DataTextField = "BUSINESSUNIT_CODE";
                rcmb_BusinessUnitType.DataBind();
                rcmb_BusinessUnitType.Items.Insert(0, new RadComboBoxItem("Select"));
            }

            else
            {
                DataTable dt_Details = new DataTable();
                rcmb_BusinessUnitType.DataSource = dt_BUDetails;

                rcmb_BusinessUnitType.DataBind();
                rcmb_BusinessUnitType.Items.Insert(0, new RadComboBoxItem("Select"));
            }

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsRole", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_BusinessUnitType_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_BusinessUnitType.SelectedIndex > 0)
            {
                LoadPositions();
            }
            else
            {
                rcmb_Position.Items.Clear();
                rcmb_Position.Text = string.Empty;
                Rm_BU_page.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsRole", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadPositions()
    {
        try
        {
            if (Session["ORG_ID"] != "")
            {
                if (rcmb_BusinessUnitType.SelectedIndex > 0)
                {
                    SMHR_POSITIONS _obj_smhr_positions = new SMHR_POSITIONS();
                    _obj_smhr_positions.OPERATION = operation.Select;
                    _obj_smhr_positions.JOBLOC_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedValue);
                    _obj_smhr_positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtPos = BLL.get_BUPositions(_obj_smhr_positions);
                    rcmb_Position.DataSource = dtPos;
                    rcmb_Position.DataTextField = "POSITIONS_CODE";
                    rcmb_Position.DataValueField = "POSITIONS_ID";
                    rcmb_Position.DataBind();
                    rcmb_Position.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                }
                else
                {
                    BLL.ShowMessage(this, "Please Select Business Unit");
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsRole", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_Position_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Position.SelectedIndex > 0)
            {
                LoadKRACompValues();
                //Rm_ROLE_PAGE.Visible = false;
                Rm_BU_page.Visible = true;
                //RMP_KRADetails.SelectedIndex = 0;
                RTS_Details.SelectedIndex = 0;
                RMP_KRADetails.SelectedIndex = 0;
                LoadKRAGrid();
                RG_KRA.DataBind();
                LoadCMPGrid();
                RG_Competencies.DataBind();
                LoadValuesGrid();
                RG_Values.DataBind();
            }
            else
            {
                //Rm_ROLE_PAGE.Visible = false;
                Rm_BU_page.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsRole", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadKRACompValues()
    {
        try
        {
            if (rcmb_BusinessUnitType.SelectedIndex > 0 && rcmb_Position.SelectedIndex > 0)
            {
                _obj_Pms_RoleKra = new SPMS_ROLEKRA();
                _obj_Pms_RoleKra.ROLEKRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Pms_RoleKra.BUID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedValue);
                _obj_Pms_RoleKra.OPERATION = operation.Select;
                DataSet dsResult = Pms_Bll.getKRACompetenciesValues(_obj_Pms_RoleKra);
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    rcmb_KRA.DataSource = dsResult.Tables[0];
                    rcmb_KRA.DataTextField = "KRA_NAME";
                    rcmb_KRA.DataValueField = "KRA_ID";
                    rcmb_KRA.DataBind();
                    rcmb_KRA.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                }
                if (dsResult.Tables[1].Rows.Count > 0)
                {
                    rcmb_Competencies.DataSource = dsResult.Tables[1];
                    rcmb_Competencies.DataTextField = "CMP_NAME";
                    rcmb_Competencies.DataValueField = "CMP_ID";
                    rcmb_Competencies.DataBind();
                    rcmb_Competencies.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                }
                if (dsResult.Tables[2].Rows.Count > 0)
                {
                    rcmb_Values.DataSource = dsResult.Tables[2];
                    rcmb_Values.DataTextField = "IDP_NAME";
                    rcmb_Values.DataValueField = "IDP_ID";
                    rcmb_Values.DataBind();
                    rcmb_Values.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsRole", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #region Add Items

    protected void lnk_AddKRA_Click(object sender, EventArgs e)
    {
        try
        {
            if ((Convert.ToString(Session["ORG_ID"]) == "") || (Convert.ToInt32(Session["ORG_ID"]) == 0))
            {
                Response.Redirect("~/frm_SesstionExp.aspx", false);
            }
            else if (rcmb_KRA.SelectedIndex <= 0)
            {
                Pms_Bll.ShowMessage(this, "Please select KRA");
                return;
            }
            bool status = false;
            if (rcmb_BusinessUnitType.SelectedIndex > 0 && rcmb_Position.SelectedIndex > 0 && rcmb_KRA.SelectedIndex > 0)
            {
                _obj_Pms_RoleKra = new SPMS_ROLEKRA();
                _obj_Pms_RoleKra.ROLEKRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Pms_RoleKra.BUID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedValue);
                _obj_Pms_RoleKra.PositionID = Convert.ToInt32(rcmb_Position.SelectedValue);
                _obj_Pms_RoleKra.ROLE_KRA_ID = Convert.ToInt32(rcmb_KRA.SelectedValue);
                _obj_Pms_RoleKra.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_Pms_RoleKra.CREATEDDATE = DateTime.Now;
                _obj_Pms_RoleKra.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_Pms_RoleKra.LASTMDFDATE = DateTime.Now;
                _obj_Pms_RoleKra.PMS_Type = 1;  //1 = KRA

                /* To check if KRA is already assigned for the selected Position */
                _obj_Pms_RoleKra.OPERATION = operation.Check;
                status = Pms_Bll.IsRoleKRAExits(_obj_Pms_RoleKra);
                if (status)
                {
                    Pms_Bll.ShowMessage(this, "KRA already assigned for the Position");
                    return;
                }

                _obj_Pms_RoleKra.OPERATION = operation.Insert;
                status = Pms_Bll.set_RoleKra(_obj_Pms_RoleKra);
                if (status)
                {
                    Pms_Bll.ShowMessage(this, "KRA saved successfully");
                    LoadKRAGrid();
                    RG_KRA.DataBind();
                    rcmb_KRA.ClearSelection();
                    return;
                }
                else
                {
                    Pms_Bll.ShowMessage(this, "KRA not saved");
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsRole", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_AddCompetencies_Click(object sender, EventArgs e)
    {
        try
        {
            if ((Convert.ToString(Session["ORG_ID"]) == "") || (Convert.ToInt32(Session["ORG_ID"]) == 0))
            {
                Response.Redirect("~/frm_SesstionExp.aspx", false);
            }
            else if (rcmb_Competencies.SelectedIndex <= 0)
            {
                Pms_Bll.ShowMessage(this, "Please select Competency");
                return;
            }
            bool status = false;
            if (rcmb_BusinessUnitType.SelectedIndex > 0 && rcmb_Position.SelectedIndex > 0 && rcmb_Competencies.SelectedIndex > 0)
            {
                _obj_Pms_RoleKra = new SPMS_ROLEKRA();
                _obj_Pms_RoleKra.ROLEKRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Pms_RoleKra.BUID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedValue);
                _obj_Pms_RoleKra.PositionID = Convert.ToInt32(rcmb_Position.SelectedValue);
                _obj_Pms_RoleKra.ROLE_KRA_ID = Convert.ToInt32(rcmb_Competencies.SelectedValue);
                _obj_Pms_RoleKra.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_Pms_RoleKra.CREATEDDATE = DateTime.Now;
                _obj_Pms_RoleKra.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_Pms_RoleKra.LASTMDFDATE = DateTime.Now;
                _obj_Pms_RoleKra.PMS_Type = 2;  //Competencie

                /* To check if Competency is already assigned for the selected Position */
                _obj_Pms_RoleKra.OPERATION = operation.Check;
                status = Pms_Bll.IsRoleKRAExits(_obj_Pms_RoleKra);
                if (status)
                {
                    Pms_Bll.ShowMessage(this, "Competency already assigned for the Position");
                    return;
                }

                _obj_Pms_RoleKra.OPERATION = operation.Insert;
                status = Pms_Bll.set_RoleKra(_obj_Pms_RoleKra);
                if (status)
                {
                    Pms_Bll.ShowMessage(this, "Competency saved successfully");
                    LoadCMPGrid();
                    RG_Competencies.DataBind();
                    rcmb_Competencies.ClearSelection();
                    return;
                }
                else
                {
                    Pms_Bll.ShowMessage(this, "Competency not saved");
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsRole", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_AddValues_Click(object sender, EventArgs e)
    {
        try
        {
            if ((Convert.ToString(Session["ORG_ID"]) == "") || (Convert.ToInt32(Session["ORG_ID"]) == 0))
            {
                Response.Redirect("~/frm_SesstionExp.aspx", false);
            }
            else if (rcmb_Values.SelectedIndex <= 0)
            {
                Pms_Bll.ShowMessage(this, "Please select Value");
                return;
            }
            bool status = false;
            if (rcmb_BusinessUnitType.SelectedIndex > 0 && rcmb_Position.SelectedIndex > 0 && rcmb_Values.SelectedIndex > 0)
            {
                _obj_Pms_RoleKra = new SPMS_ROLEKRA();
                _obj_Pms_RoleKra.ROLEKRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Pms_RoleKra.BUID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedValue);
                _obj_Pms_RoleKra.PositionID = Convert.ToInt32(rcmb_Position.SelectedValue);
                _obj_Pms_RoleKra.ROLE_KRA_ID = Convert.ToInt32(rcmb_Values.SelectedValue);
                _obj_Pms_RoleKra.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_Pms_RoleKra.CREATEDDATE = DateTime.Now;
                _obj_Pms_RoleKra.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_Pms_RoleKra.LASTMDFDATE = DateTime.Now;
                _obj_Pms_RoleKra.PMS_Type = 3;  //Values

                /* To check if Value is already assigned for the selected Position */
                _obj_Pms_RoleKra.OPERATION = operation.Check;
                status = Pms_Bll.IsRoleKRAExits(_obj_Pms_RoleKra);
                if (status)
                {
                    Pms_Bll.ShowMessage(this, "Values already assigned for the Position");
                    return;
                }

                _obj_Pms_RoleKra.OPERATION = operation.Insert;
                status = Pms_Bll.set_RoleKra(_obj_Pms_RoleKra);
                if (status)
                {
                    Pms_Bll.ShowMessage(this, "Values saved successfully");
                    LoadValuesGrid();
                    RG_Values.DataBind();
                    rcmb_Values.ClearSelection();
                    return;
                }
                else
                {
                    Pms_Bll.ShowMessage(this, "Values not saved");
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsRole", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region LoadGrids

    private void LoadKRAGrid()
    {
        try
        {
            //To load KRA's
            _obj_Pms_RoleKra = new SPMS_ROLEKRA();
            _obj_Pms_RoleKra.BUID = (rcmb_BusinessUnitType.SelectedIndex > 0 ? Convert.ToInt32(rcmb_BusinessUnitType.SelectedValue) : 0);
            _obj_Pms_RoleKra.PositionID = (rcmb_Position.SelectedIndex > 0 ? Convert.ToInt32(rcmb_Position.SelectedValue) : 0);
            _obj_Pms_RoleKra.ROLEKRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Pms_RoleKra.OPERATION = operation.Get;
            _obj_Pms_RoleKra.PMS_Type = 1;
            DataTable dtKRA = Pms_Bll.getPositionKRA(_obj_Pms_RoleKra);
            RG_KRA.DataSource = dtKRA;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsRole", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadCMPGrid()
    {
        try
        {
            //To load Competencies
            _obj_Pms_RoleKra = new SPMS_ROLEKRA();
            _obj_Pms_RoleKra.BUID = (rcmb_BusinessUnitType.SelectedIndex > 0 ? Convert.ToInt32(rcmb_BusinessUnitType.SelectedValue) : 0);
            _obj_Pms_RoleKra.PositionID = (rcmb_Position.SelectedIndex > 0 ? Convert.ToInt32(rcmb_Position.SelectedValue) : 0);
            _obj_Pms_RoleKra.ROLEKRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Pms_RoleKra.OPERATION = operation.Get;
            _obj_Pms_RoleKra.PMS_Type = 2;
            DataTable dtCMP = Pms_Bll.getPositionKRA(_obj_Pms_RoleKra);
            RG_Competencies.DataSource = dtCMP;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsRole", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadValuesGrid()
    {
        try
        {
            //To load Values
            _obj_Pms_RoleKra = new SPMS_ROLEKRA();
            _obj_Pms_RoleKra.BUID = (rcmb_BusinessUnitType.SelectedIndex > 0 ? Convert.ToInt32(rcmb_BusinessUnitType.SelectedValue) : 0);
            _obj_Pms_RoleKra.PositionID = (rcmb_Position.SelectedIndex > 0 ? Convert.ToInt32(rcmb_Position.SelectedValue) : 0);
            _obj_Pms_RoleKra.ROLEKRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Pms_RoleKra.OPERATION = operation.Get;
            _obj_Pms_RoleKra.PMS_Type = 3;
            DataTable dtIDP = Pms_Bll.getPositionKRA(_obj_Pms_RoleKra);
            RG_Values.DataSource = dtIDP;

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsRole", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region NeedDataSource

    protected void RG_KRA_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadKRAGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsRole", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void RG_Competencies_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadCMPGrid();

            //_obj_Pms_RoleKra = new SPMS_ROLEKRA();
            //_obj_Pms_RoleKra.BUID = (rcmb_BusinessUnitType.SelectedIndex > 0 ? Convert.ToInt32(rcmb_BusinessUnitType.SelectedValue) : 0);
            //_obj_Pms_RoleKra.PositionID = (rcmb_Position.SelectedIndex > 0 ? Convert.ToInt32(rcmb_Position.SelectedValue) : 0);
            //_obj_Pms_RoleKra.ROLEKRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            //_obj_Pms_RoleKra.OPERATION = operation.Get;
            //DataTable dtCMP = Pms_Bll.getKRACompetenciesValues(_obj_Pms_RoleKra).Tables[1];
            //RG_Competencies.DataSource = dtCMP;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsRole", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void RG_Values_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadValuesGrid();
            //_obj_Pms_RoleKra = new SPMS_ROLEKRA();
            //_obj_Pms_RoleKra.BUID = (rcmb_BusinessUnitType.SelectedIndex > 0 ? Convert.ToInt32(rcmb_BusinessUnitType.SelectedValue) : 0);
            //_obj_Pms_RoleKra.PositionID = (rcmb_Position.SelectedIndex > 0 ? Convert.ToInt32(rcmb_Position.SelectedValue) : 0);
            //_obj_Pms_RoleKra.ROLEKRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            //_obj_Pms_RoleKra.OPERATION = operation.Get;
            //DataTable dtIDP = Pms_Bll.getKRACompetenciesValues(_obj_Pms_RoleKra).Tables[2];
            //RG_Competencies.DataSource = dtIDP;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsRole", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region Delete commands

    protected void lnk_delKRA_Command(object sender, CommandEventArgs e)
    {
        try
        {
            bool status = false;
            if (e.CommandArgument != null)
            {
                _obj_Pms_RoleKra = new SPMS_ROLEKRA();
                _obj_Pms_RoleKra.ROLEKRA_ID = Convert.ToInt32(e.CommandArgument);
                _obj_Pms_RoleKra.OPERATION = operation.Delete;
                status = Pms_Bll.del_KRA(_obj_Pms_RoleKra);
                if (status)
                {
                    Pms_Bll.ShowMessage(this, "KRA Deleted Successfully");
                    LoadKRAGrid();
                    RG_KRA.DataBind();
                    return;
                }
                else
                {
                    Pms_Bll.ShowMessage(this, "KRA Not Deleted");
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsRole", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_delCMP_Command(object sender, CommandEventArgs e)
    {
        try
        {
            bool status = false;
            if (e.CommandArgument != null)
            {
                _obj_Pms_RoleKra = new SPMS_ROLEKRA();
                _obj_Pms_RoleKra.ROLEKRA_ID = Convert.ToInt32(e.CommandArgument);
                _obj_Pms_RoleKra.OPERATION = operation.Delete;
                status = Pms_Bll.del_KRA(_obj_Pms_RoleKra);
                if (status)
                {
                    Pms_Bll.ShowMessage(this, "Competency Deleted Successfully");
                    LoadCMPGrid();
                    RG_Competencies.DataBind();
                    return;
                }
                else
                {
                    Pms_Bll.ShowMessage(this, "Competency Not Deleted");
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsRole", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_delValue_Command(object sender, CommandEventArgs e)
    {
        try
        {
            bool status = false;
            if (e.CommandArgument != null)
            {
                _obj_Pms_RoleKra = new SPMS_ROLEKRA();
                _obj_Pms_RoleKra.ROLEKRA_ID = Convert.ToInt32(e.CommandArgument);
                _obj_Pms_RoleKra.OPERATION = operation.Delete;
                status = Pms_Bll.del_KRA(_obj_Pms_RoleKra);
                if (status)
                {
                    Pms_Bll.ShowMessage(this, "Value Deleted Successfully");
                    LoadValuesGrid();
                    RG_Values.DataBind();
                    return;
                }
                else
                {
                    Pms_Bll.ShowMessage(this, "Value Not Deleted");
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsRole", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

}
