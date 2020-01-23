using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SPMS;
using SMHR;
using Telerik.Web.UI;


public partial class PMS_frm_KRA : System.Web.UI.Page
{
    pms_kraform _obj_kra;
    SMHR_BUSINESSUNIT _obj_smhr_businessunit;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SPMS_PROJECT _obj_Pms_Project;
    PMS_KRA_OBJECTIVES _obj_pms_kra_objectives = new PMS_KRA_OBJECTIVES();
    static int i = 0;

    #region page load methods

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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("KEY RESULT AREA");
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
                    RG_kraform.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
                clearfields();
                RM_kraform.SelectedIndex = 0;
                LoadCombos();
            }
            Page.Validate();
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Kraform", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region loadcombos,clear fields

    private void LoadCombos()
    {
        try
        {
            _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();


            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            if (dt_BUDetails.Rows.Count != 0)
            {
                rcmb_BUI.DataSource = dt_BUDetails;
                rcmb_BUI.DataValueField = "BUSINESSUNIT_ID";
                rcmb_BUI.DataTextField = "BUSINESSUNIT_CODE";
                rcmb_BUI.DataBind();
                rcmb_BUI.Items.Insert(0, new RadComboBoxItem("Select"));
            }
            else
            {
                DataTable dt_Details = new DataTable();
                rcmb_BUI.DataSource = dt_Details;

                rcmb_BUI.DataBind();
                rcmb_BUI.Items.Insert(0, new RadComboBoxItem("Select"));
            }

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Kraform", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void clearfields()
    {
        try
        {
            txt_kraname.Text = string.Empty;
            txt_description.Text = string.Empty;
            //txt_Measure.Text = string.Empty;
            //rtxt_KRAID.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Kraform", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region  loadgrid methods

    protected void RG_kraform_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            _obj_kra = new pms_kraform();
            _obj_kra.KRA_MODE = 1;
            _obj_kra.KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_kra.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);

            DataTable dt = Pms_Bll.get_kra(_obj_kra);
            if (dt.Rows.Count != 0)
            {
                RG_kraform.DataSource = dt;
            }
            else
            {
                DataTable dt1 = new DataTable();

                RG_kraform.DataSource = dt1;
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Kraform", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void loadgrid()
    {
        try
        {
            _obj_kra = new pms_kraform();
            _obj_kra.KRA_MODE = 1;
            _obj_kra.KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_kra.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt = Pms_Bll.get_kra(_obj_kra);
            if (dt.Rows.Count != 0)
            {
                RG_kraform.DataSource = dt;
                RG_kraform.DataBind();
            }
            else
            {
                DataTable dt1 = new DataTable();

                RG_kraform.DataSource = dt1;

                RG_kraform.DataBind();
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Kraform", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region add,edit command

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            i = 0;
            clearfields();

            pnlAddObj.Visible = false;
            rpKraObj.Selected = false;
            chkActive.Checked = false;
            divActive.Visible = true;
            RM_kraform.SelectedIndex = 1;
            btn_SAVE.Visible = true;
            btn_SAVE.Enabled = true;
            btn_Update.Visible = false;
            txt_description.Enabled = true;
            txt_kraname.Enabled = true;
            //rtxt_KRAID.Enabled = true;
            //txt_Measure.Enabled = true;
            rcmb_BUI.SelectedIndex = 0;
            rcmb_BUI.Enabled = true;
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Kraform", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Commnad(object sender, CommandEventArgs e)
    {
        try
        {
            i++;
            clearfields();
            chkActive.Checked = false;
            divActive.Visible = true;
            LoadCombos();
            _obj_kra = new pms_kraform();
            _obj_kra.KRA_MODE = 2;
            _obj_kra.KRA_ID = Convert.ToInt32(e.CommandArgument);
            ViewState["EditKraID"] = Convert.ToInt32(e.CommandArgument);
            txt_Objectives.Text = "";
            DataTable DT = Pms_Bll.get_kra(_obj_kra);
            if (DT.Rows.Count != 0)
            {
                lbl_id.Text = Convert.ToString(DT.Rows[0]["KRA_ID"]);
                txt_kraname.Text = Pms_Bll.ReplaceQuote(Convert.ToString(DT.Rows[0]["KRA_NAME"]));
                txt_description.Text = Pms_Bll.ReplaceQuote(Convert.ToString(DT.Rows[0]["KRA_DESCRIPTION"]));
                //txt_Measure.Text = Convert.ToString(DT.Rows[0]["KRA_MEASURE"]);
                rcmb_BUI.SelectedIndex = rcmb_BUI.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["KRA_BU_ID"]));
                //rtxt_KRAID.Text = Pms_Bll.ReplaceQuote(Convert.ToString(DT.Rows[0]["KRA_KRAID"]));

                chkActive.Checked = (!Convert.ToBoolean(DT.Rows[0]["KRA_STATUS"]));

                pnlAddObj.Visible = true;
                rpKraObj.Selected = true;
                LoadKraObjDatabyKraID(Convert.ToInt32(e.CommandArgument));

                RM_kraform.SelectedIndex = 1;
                btn_SAVE.Visible = true;
                btn_SAVE.Visible = false;
                btn_Update.Visible = true;
                txt_description.Enabled = true;
                txt_kraname.Enabled = false;
                //rtxt_KRAID.Enabled = false;
                //txt_Measure.Enabled = true;
                rcmb_BUI.Enabled = false;

                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    btn_Update.Visible = false;
                }

                else
                {
                    btn_Update.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Kraform", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region save,cancel,update methods

    protected void btn_Update_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_kra = new pms_kraform();
            _obj_kra.KRA_ID = Convert.ToInt32(lbl_id.Text);
            _obj_kra.KRA_NAME = Pms_Bll.ReplaceQuote(Convert.ToString(txt_kraname.Text));
            _obj_kra.KRA_DESCRIPTION = Pms_Bll.ReplaceQuote(Convert.ToString(txt_description.Text));
            _obj_kra.BU_ID = Convert.ToInt32(rcmb_BUI.SelectedValue);
            //_obj_kra.KRA_MEASURE = Convert.ToString(txt_Measure.Text.Replace("'", "''"));
            _obj_kra.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_kra.LASTMDFDATE = DateTime.Now;
            _obj_kra.KRA_MODE = 4;
            //_obj_kra.KRA_KRAID = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_KRAID.Text));
            //_obj_kra.KRA_WEIGHTAGE = Convert.ToInt32(RNT_KraWeightage.Value);

            if (chkActive.Checked)
                _obj_kra.KRA_STATUS = 0;
            else
                _obj_kra.KRA_STATUS = 1;

            bool status = Pms_Bll.set_kra(_obj_kra);
            if (status == true)
            {
                Pms_Bll.ShowMessage(this, "KRA Updated Successfully");
                loadgrid();
                btn_Update.Visible = true;
                RM_kraform.SelectedIndex = 0;
            }
            else
            {
                Pms_Bll.ShowMessage(this, "Unable to Update the record,Execption Occured");
                return;
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Kraform", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            RM_kraform.SelectedIndex = 0;
            loadgrid();
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Kraform", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void btn_SAVE_Click1(object sender, EventArgs e)
    {
        try
        {
            string s = Convert.ToString(txt_description.Text);
            //string z = Convert.ToString(txt_Measure.Text);
            if (s.Length > 1000)
            {
                Pms_Bll.ShowMessage(this, "Description Cannot Greater Than 1000 Characters");
                return;

            }
            //if (z.Length > 50)
            //{
            //    Pms_Bll.ShowMessage(this, "Measure Cannot Greater Than 50 Characters");
            //    return;

            //}
            _obj_kra = new pms_kraform();
            _obj_kra.KRA_MODE = 7;
            _obj_kra.KRA_NAME = Pms_Bll.ReplaceQuote(Convert.ToString(txt_kraname.Text));
            _obj_kra.BU_ID = Convert.ToInt32(rcmb_BUI.SelectedValue);
            _obj_kra.KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = Pms_Bll.get_kra(_obj_kra);
            if (dt.Rows.Count != 0)
            {
                Pms_Bll.ShowMessage(this, "KRA Already Exist");
                return;
            }
            else
            {
                _obj_kra = new pms_kraform();

                _obj_kra.KRA_MODE = 3;
                _obj_kra.KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_kra.KRA_NAME = Pms_Bll.ReplaceQuote(Convert.ToString(txt_kraname.Text));

                _obj_kra.KRA_DESCRIPTION = Pms_Bll.ReplaceQuote(Convert.ToString(txt_description.Text));
                //_obj_kra.KRA_MEASURE = Pms_Bll.ReplaceQuote(Convert.ToString(txt_Measure.Text));
                _obj_kra.BU_ID = Convert.ToInt32(rcmb_BUI.SelectedItem.Value);
                _obj_kra.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                _obj_kra.LASTMDFDATE = DateTime.Now;
                _obj_kra.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                _obj_kra.CREATEDDATE = DateTime.Now;
                //_obj_kra.KRA_STATUS = 1;
                if (chkActive.Checked)
                    _obj_kra.KRA_STATUS = 0;
                else
                    _obj_kra.KRA_STATUS = 1;
                //_obj_kra.KRA_KRAID = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_KRAID.Text));
                //_obj_kra.KRA_WEIGHTAGE = Convert.ToInt32(RNT_KraWeightage.Value);

                bool status = Pms_Bll.set_kra(_obj_kra);
                if (status == true)
                {
                    Pms_Bll.ShowMessage(this, "KRA Inserted Successfully");

                    btn_SAVE.Enabled = false;
                    rpKraObj.Selected = true;
                    pnlAddObj.Visible = true;
                    LoadKraObjDatabyKraID(0);

                    rcmb_BUI.Enabled = false;
                    txt_description.Enabled = false;
                    txt_kraname.Enabled = false;

                    //loadgrid();
                    //clearfields();
                    //RM_kraform.SelectedIndex = 0;
                    //return;
                }
                else
                {
                    Pms_Bll.ShowMessage(this, "Unable to Update the record,Execption Occured");
                    return;
                }
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Kraform", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    #endregion

    #region Eshwar_KRA_OBJ

    protected void LoadKraObjDatabyKraID(int kraID)
    {
        try
        {
            DataTable dtKraObj = new DataTable();
            if (kraID != 0 )
            {
                _obj_pms_kra_objectives.KRA_OBJ_KRA_ID = Convert.ToInt32(kraID);
                _obj_pms_kra_objectives.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                dtKraObj = BLL.GET_PMS_KRA_OBJECTIVES(_obj_pms_kra_objectives);
            }
            rgKraObj.DataSource = dtKraObj;
            rgKraObj.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Kraform", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rgKraObj_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            if (i == 0)
                LoadKraObjDatabyKraID(1);
            else
                LoadKraObjDatabyKraID(Convert.ToInt32(ViewState["EditKraID"]));
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Kraform", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Kra_Obj_Command(object sender, CommandEventArgs e)
    {
        try
        {
            LinkButton lnk_Edit_Kra_Obj;
            LinkButton lnk_Update_Kra_Obj;
            LinkButton lnk_Del_Kra_Obj;
            LinkButton lnk_Cancel_Kra_Obj;

            for (int index = 0; index < rgKraObj.Items.Count; index++)
            {
                lnk_Edit_Kra_Obj = rgKraObj.Items[index].FindControl("lnk_Edit_Kra_Obj") as LinkButton;
                lnk_Update_Kra_Obj = rgKraObj.Items[index].FindControl("lnk_Update_Kra_Obj") as LinkButton;
                lnk_Del_Kra_Obj = rgKraObj.Items[index].FindControl("lnk_Del_Kra_Obj") as LinkButton;
                lnk_Cancel_Kra_Obj = rgKraObj.Items[index].FindControl("lnk_Cancel_Kra_Obj") as LinkButton;

                if (e.CommandName == "EditKraObj")
                {
                    lnk_Edit_Kra_Obj.Visible = false;
                    lnk_Del_Kra_Obj.Visible = false;
                    lnk_Cancel_Kra_Obj.Visible = true;
                    lnk_Update_Kra_Obj.Visible = true;
                }
                else
                {
                    lnk_Edit_Kra_Obj.Visible = true;
                    lnk_Del_Kra_Obj.Visible = true;
                    lnk_Cancel_Kra_Obj.Visible = false;
                    lnk_Update_Kra_Obj.Visible = false;
                }
            }

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Kraform", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Del_Kra_Obj_Command(object sender, CommandEventArgs e)
    {
        try
        {
            _obj_pms_kra_objectives.KRA_OBJ_ID = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Inactive")
                _obj_pms_kra_objectives.OPERATION = operation.Insert1;

            bool getIAKraObj = BLL.GET_INACTIVE_KRA_OBJ(_obj_pms_kra_objectives);

            DataTable getKraObjData = BLL.GET_PMS_KRA_OBJECTIVESBY_OBJ_ID(_obj_pms_kra_objectives);
            LoadKraObjDatabyKraID(Convert.ToInt32(getKraObjData.Rows[0]["KRA_OBJ_KRA_ID"]));
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Kraform", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Update_Kra_Obj_Command(object sender, CommandEventArgs e)
    {
        try
        {
            _obj_pms_kra_objectives.KRA_OBJ_ID = Convert.ToInt32(e.CommandArgument);
            //_obj_pms_kra_objectives.KRA_OBJ_NAME=
            _obj_pms_kra_objectives.KRA_OBJ_KRA_ID = Convert.ToInt32(ViewState["EditKraID"]);
            _obj_pms_kra_objectives.BUID = Convert.ToInt32(rcmb_BUI.SelectedValue);
            _obj_pms_kra_objectives.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_pms_kra_objectives.LASTMDFBY = Convert.ToInt32(Session["EMP_ID"]);
            _obj_pms_kra_objectives.LASTMDFDATE = DateTime.Now;
            //_obj_pms_kra_objectives.KRA_OBJ_ISACTIVE=

            bool getIAKraObj = BLL.set_PMS_KRA_OBJECTIVES(_obj_pms_kra_objectives);

            if (getIAKraObj == true)
            {

            }

            LoadKraObjDatabyKraID(Convert.ToInt32(ViewState["EditKraID"]));
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Kraform", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_AddObjectives_Command(object sender, CommandEventArgs e)
    {
        try
        {
            if (txt_Objectives.Text != string.Empty)
            {
                int kraObjKraID = 0;
                _obj_pms_kra_objectives.KRA_OBJ_NAME = BLL.ReplaceQuote(txt_Objectives.Text);

                DataTable kraObjStatus = BLL.CHECK_KRA_NAME_EXISTS(_obj_pms_kra_objectives);
                DataTable dtKraID = BLL.Get_Max_Kra_ID();

                if (i == 0)
                    kraObjKraID = Convert.ToInt32(dtKraID.Rows[0]["KRA_ID"]);
                else
                    kraObjKraID = Convert.ToInt32(ViewState["EditKraID"]);

                if (Convert.ToInt32(kraObjStatus.Rows[0]["COUNT"]) > 0)
                {
                    BLL.ShowMessage(this, "This Objective Name is Already Exists");
                    txt_Objectives.Text = "";
                    txt_Objectives.Focus();
                    return;
                }
                else
                {
                    _obj_pms_kra_objectives.OPERATION = operation.Insert;
                    _obj_pms_kra_objectives.BUID = Convert.ToInt32(rcmb_BUI.SelectedValue);
                    _obj_pms_kra_objectives.KRA_OBJ_KRA_ID = kraObjKraID;
                    _obj_pms_kra_objectives.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_pms_kra_objectives.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_pms_kra_objectives.CREATEDDATE = DateTime.Now;
                    _obj_pms_kra_objectives.KRA_OBJ_ISACTIVE = 1;

                    bool saveKraObj = BLL.set_PMS_KRA_OBJECTIVES(_obj_pms_kra_objectives);

                    if (saveKraObj == true)
                        txt_Objectives.Text = "";
                }
                LoadKraObjDatabyKraID(kraObjKraID);
            }
            else
            {
                BLL.ShowMessage(this, "Please Enter Objective Name to Add");
                txt_Objectives.Focus();
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Kraform", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Cancel_Kra_Obj_Command(object sender, CommandEventArgs e)
    {
        try
        {
            LinkButton lnk_Edit_Kra_Obj;
            LinkButton lnk_Update_Kra_Obj;
            LinkButton lnk_Del_Kra_Obj;
            LinkButton lnk_Cancel_Kra_Obj;

            for (int index = 0; index < rgKraObj.Items.Count; index++)
            {
                lnk_Edit_Kra_Obj = rgKraObj.Items[index].FindControl("lnk_Edit_Kra_Obj") as LinkButton;
                lnk_Update_Kra_Obj = rgKraObj.Items[index].FindControl("lnk_Update_Kra_Obj") as LinkButton;
                lnk_Del_Kra_Obj = rgKraObj.Items[index].FindControl("lnk_Del_Kra_Obj") as LinkButton;
                lnk_Cancel_Kra_Obj = rgKraObj.Items[index].FindControl("lnk_Cancel_Kra_Obj") as LinkButton;

                if (e.CommandName == "CancelKraObj")
                {
                    lnk_Edit_Kra_Obj.Visible = true;
                    lnk_Del_Kra_Obj.Visible = true;
                    lnk_Cancel_Kra_Obj.Visible = false;
                    lnk_Update_Kra_Obj.Visible = false;
                }
                else
                {
                    lnk_Edit_Kra_Obj.Visible = false;
                    lnk_Del_Kra_Obj.Visible = false;
                    lnk_Cancel_Kra_Obj.Visible = true;
                    lnk_Update_Kra_Obj.Visible = true;
                }
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Kraform", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnkBtnEdit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            int kraObjID = Convert.ToInt32(e.CommandArgument);
            ViewState["objID"] = kraObjID;

            _obj_pms_kra_objectives.KRA_OBJ_ID = kraObjID;

            DataTable dtKraObj = BLL.GET_PMS_KRA_OBJECTIVESBY_OBJ_ID(_obj_pms_kra_objectives);

            rtbKraObjName.Text = Convert.ToString(dtKraObj.Rows[0]["KRA_OBJ_NAME"]);
            int chkBtn = Convert.ToInt32(dtKraObj.Rows[0]["KRA_OBJ_ISACTIVE"]);

            if (chkBtn == 1)
                chkBoxIsActive.Checked = false;
            else
                chkBoxIsActive.Checked = true;

            lbl_Objectives.Visible = false;
            lbl.Visible = false;
            btn_AddObjectives.Visible = false;
            txt_Objectives.Visible = false;

            txt_description.Enabled = false;
            btn_Update.Visible = false;
            btn_Cancel.Visible = false;

            rmpKraObj.SelectedIndex = 1;
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Kraform", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btnKraObjUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_pms_kra_objectives.KRA_OBJ_NAME = rtbKraObjName.Text;
            DataTable kraObjStatus = BLL.CHECK_KRA_NAME_EXISTS(_obj_pms_kra_objectives);

            if (Convert.ToInt32(kraObjStatus.Rows[0]["COUNT"]) > 0)
            {
                BLL.ShowMessage(this, "This Objective Name is Already Exists");
                txt_Objectives.Text = "";
                txt_Objectives.Focus();
                return;
            }
            else
            {
                _obj_pms_kra_objectives.KRA_OBJ_ID = Convert.ToInt32(ViewState["objID"]);
                _obj_pms_kra_objectives.LASTMDFBY = Convert.ToInt32(Session["EMP_ID"]);
                _obj_pms_kra_objectives.LASTMDFDATE = DateTime.Now;

                bool updateKraObj = BLL.CHANGE_KRA_NAME(_obj_pms_kra_objectives);

                if (updateKraObj == true)
                    btnKraObjCancel_Click(sender, e);
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Kraform", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btnKraObjCancel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable maxKraObj = BLL.Get_Max_Kra_ID();

            lbl_Objectives.Visible = true;
            lbl.Visible = true;
            btn_AddObjectives.Visible = true;
            txt_Objectives.Visible = true;

            txt_description.Enabled = true;
            btn_Update.Visible = true;
            btn_Cancel.Visible = true;

            rmpKraObj.SelectedIndex = 0;

            if (i != 0)
                LoadKraObjDatabyKraID(Convert.ToInt32(ViewState["EditKraID"]));
            else
                LoadKraObjDatabyKraID(Convert.ToInt32(maxKraObj.Rows[0]["KRA_ID"]));
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Kraform", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rgKraObj_ItemDataBound(object sender, GridItemEventArgs e)
    {
        try
        {
            LinkButton lnk_Del_Kra_Obj;
            LinkButton lnk_Cancel_Kra_Obj;

            DataTable dtKraObj = BLL.GET_PMS_KRA_OBJECTIVES(_obj_pms_kra_objectives);

            for (int index = 0; index < rgKraObj.Items.Count; index++)
            {
                lnk_Del_Kra_Obj = rgKraObj.Items[index].FindControl("lnk_Del_Kra_Obj") as LinkButton;
                lnk_Cancel_Kra_Obj = rgKraObj.Items[index].FindControl("lnk_Cancel_Kra_Obj") as LinkButton;

                if (Convert.ToInt32(dtKraObj.Rows[index]["KRA_OBJ_ISACTIVE"]) == 1)
                {
                    lnk_Del_Kra_Obj.Visible = true;
                    lnk_Cancel_Kra_Obj.Visible = false;
                }
                else
                {
                    lnk_Del_Kra_Obj.Visible = false;
                    lnk_Cancel_Kra_Obj.Visible = true;
                }
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Kraform", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    protected void lnkBtnEditNew_Command(object sender, CommandEventArgs e)
    {
        try
        {
            int kraObjId = Convert.ToInt32(e.CommandArgument);

            Label lblObjId;
            Label lblObj;
            RadTextBox rtxtObjNameNew;
            LinkButton lnkBtnEditNew;
            LinkButton lnkBtnUpdateNew;
            LinkButton lnkBtnCancelNew;

            for (int index = 0; index < rgKraObj.Items.Count; index++)
            {
                lblObj = rgKraObj.Items[index].FindControl("lblObj") as Label;
                lblObjId = rgKraObj.Items[index].FindControl("lblObjId") as Label;
                rtxtObjNameNew = rgKraObj.Items[index].FindControl("rtxtObjNameNew") as RadTextBox;
                lnkBtnEditNew = rgKraObj.Items[index].FindControl("lnkBtnEditNew") as LinkButton;
                lnkBtnUpdateNew = rgKraObj.Items[index].FindControl("lnkBtnUpdateNew") as LinkButton;
                lnkBtnCancelNew = rgKraObj.Items[index].FindControl("lnkBtnCancelNew") as LinkButton;

                if ((e.CommandName == "lnkBtnNewEdit") && (kraObjId == Convert.ToInt32(lblObjId.Text)))
                {
                    lblObj.Visible = false;
                    rtxtObjNameNew.Visible = true;
                    rtxtObjNameNew.Text = lblObj.Text;

                    lnkBtnEditNew.Visible = false;
                    lnkBtnUpdateNew.Visible = true;
                    lnkBtnCancelNew.Visible = true;
                }
                else
                {
                    lblObj.Visible = true;
                    rtxtObjNameNew.Visible = false;

                    lnkBtnEditNew.Visible = true;
                    lnkBtnUpdateNew.Visible = false;
                    lnkBtnCancelNew.Visible = false;
                }
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Kraform", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnkBtnUpdateNew_Command(object sender, CommandEventArgs e)
    {
        try
        {
            int kraID = 0;
            int kraObjId = Convert.ToInt32(e.CommandArgument);

            Label lblObjId;
            Label lblObj;
            RadTextBox rtxtObjNameNew;
            LinkButton lnkBtnEditNew;
            LinkButton lnkBtnUpdateNew;
            LinkButton lnkBtnCancelNew;

            for (int index = 0; index < rgKraObj.Items.Count; index++)
            {
                lblObj = rgKraObj.Items[index].FindControl("lblObj") as Label;
                lblObjId = rgKraObj.Items[index].FindControl("lblObjId") as Label;
                rtxtObjNameNew = rgKraObj.Items[index].FindControl("rtxtObjNameNew") as RadTextBox;
                lnkBtnEditNew = rgKraObj.Items[index].FindControl("lnkBtnEditNew") as LinkButton;
                lnkBtnUpdateNew = rgKraObj.Items[index].FindControl("lnkBtnUpdateNew") as LinkButton;
                lnkBtnCancelNew = rgKraObj.Items[index].FindControl("lnkBtnCancelNew") as LinkButton;

                if ((e.CommandName == "lnkBtnUpdateNew") && (kraObjId == Convert.ToInt32(lblObjId.Text)))
                {
                    _obj_pms_kra_objectives.KRA_OBJ_NAME = rtxtObjNameNew.Text;

                    DataTable kraObjStatus = BLL.CHECK_KRA_NAME_EXISTS(_obj_pms_kra_objectives);

                    if (Convert.ToInt32(kraObjStatus.Rows[0]["COUNT"]) > 0)
                    {
                        BLL.ShowMessage(this, "This Objective Name is Already Exists");
                        txt_Objectives.Text = "";
                        txt_Objectives.Focus();
                        return;
                    }
                    else
                    {
                        _obj_pms_kra_objectives.KRA_OBJ_ID = kraObjId;
                        _obj_pms_kra_objectives.LASTMDFBY = Convert.ToInt32(Session["EMP_ID"]);
                        _obj_pms_kra_objectives.LASTMDFDATE = DateTime.Now;

                        bool updateKraObj = BLL.CHANGE_KRA_NAME(_obj_pms_kra_objectives);
                        DataTable dtkraID = BLL.GET_PMS_KRA_OBJECTIVESBY_OBJ_ID(_obj_pms_kra_objectives);
                        DataTable dtMaxKraID = BLL.Get_Max_Kra_ID();

                        if (updateKraObj == true)
                        {
                            if (i != 0)
                                LoadKraObjDatabyKraID(Convert.ToInt32(dtkraID.Rows[0]["KRA_OBJ_KRA_ID"]));
                            else
                                LoadKraObjDatabyKraID(Convert.ToInt32(dtMaxKraID.Rows[0]["KRA_ID"]));
                        }
                    }
                }
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Kraform", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnkBtnCancelNew_Command(object sender, CommandEventArgs e)
    {
        try
        {
            DataTable dtMaxKraID = BLL.Get_Max_Kra_ID();

            if (i != 0)
                LoadKraObjDatabyKraID(Convert.ToInt32(ViewState["EditKraID"]));
            else
                LoadKraObjDatabyKraID(Convert.ToInt32(dtMaxKraID.Rows[0]["KRA_ID"]));
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Kraform", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}