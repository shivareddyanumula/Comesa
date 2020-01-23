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

public partial class PMS_frm_Mgr_Kra : System.Web.UI.Page
{
    pms_kraform _obj_kra;
    SMHR_BUSINESSUNIT _obj_smhr_businessunit;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SPMS_PROJECT _obj_Pms_Project;

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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Mgr_Kra", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Mgr_Kra", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void clearfields()
    {
        try
        {
            txt_kraname.Text = string.Empty;
            txt_description.Text = string.Empty;
            txt_Measure.Text = string.Empty;
            rtxt_KRAID.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Mgr_Kra", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Mgr_Kra", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Mgr_Kra", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion
    #region add,edit command
    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            clearfields();

            RM_kraform.SelectedIndex = 1;
            btn_SAVE.Visible = true;
            btn_Update.Visible = false;
            txt_description.Enabled = true;
            txt_kraname.Enabled = true;
            txt_Measure.Enabled = true;
            rcmb_BUI.SelectedIndex = 0;
            rcmb_BUI.Enabled = true;
            rtxt_KRAID.Enabled = true;
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Mgr_Kra", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Commnad(object sender, CommandEventArgs e)
    {

        try
        {
            clearfields();
            LoadCombos();
            _obj_kra = new pms_kraform();
            _obj_kra.KRA_MODE = 2;
            _obj_kra.KRA_ID = Convert.ToInt32(e.CommandArgument);
            DataTable DT = Pms_Bll.get_kra(_obj_kra);
            if (DT.Rows.Count != 0)
            {
                lbl_id.Text = Convert.ToString(DT.Rows[0]["KRA_ID"]);
                txt_kraname.Text = Pms_Bll.ReplaceQuote(Convert.ToString(DT.Rows[0]["KRA_NAME"]));
                txt_description.Text = Pms_Bll.ReplaceQuote(Convert.ToString(DT.Rows[0]["KRA_DESCRIPTION"]));
                txt_Measure.Text = Convert.ToString(DT.Rows[0]["KRA_MEASURE"]);
                rcmb_BUI.SelectedIndex = rcmb_BUI.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["KRA_BU_ID"]));
                rtxt_KRAID.Text = Pms_Bll.ReplaceQuote(Convert.ToString(DT.Rows[0]["KRA_KRAID"]));

                RM_kraform.SelectedIndex = 1;
                btn_SAVE.Visible = true;
                btn_SAVE.Visible = false;
                btn_Update.Visible = true;
                txt_description.Enabled = true;
                txt_kraname.Enabled = false;
                txt_Measure.Enabled = true;
                rcmb_BUI.Enabled = false;
                rtxt_KRAID.Enabled = false;
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Mgr_Kra", ex.StackTrace, DateTime.Now);
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
            _obj_kra.KRA_MEASURE = Convert.ToString(txt_Measure.Text.Replace("'", "''"));
            _obj_kra.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_kra.LASTMDFDATE = DateTime.Now;
            _obj_kra.KRA_MODE = 4;
            _obj_kra.KRA_KRAID = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_KRAID.Text));
            //_obj_kra.KRA_WEIGHTAGE = Convert.ToInt32(RNT_KraWeightage.Value);

            bool status = Pms_Bll.set_kra(_obj_kra);
            if (status == true)
            {
                Pms_Bll.ShowMessage(this, "KRA Updated Succesfully");
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Mgr_Kra", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Mgr_Kra", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }


    protected void btn_SAVE_Click1(object sender, EventArgs e)
    {
        try
        {
            string s = Convert.ToString(txt_description.Text);
            string z = Convert.ToString(txt_Measure.Text);
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
                _obj_kra.KRA_MEASURE = Pms_Bll.ReplaceQuote(Convert.ToString(txt_Measure.Text));
                _obj_kra.BU_ID = Convert.ToInt32(rcmb_BUI.SelectedItem.Value);
                _obj_kra.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                _obj_kra.LASTMDFDATE = DateTime.Now;
                _obj_kra.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                _obj_kra.CREATEDDATE = DateTime.Now;
                _obj_kra.KRA_STATUS = 0;
                //_obj_kra.KRA_WEIGHTAGE = Convert.ToInt32(RNT_KraWeightage.Value);
                _obj_kra.KRA_KRAID = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_KRAID.Text));
                bool status = Pms_Bll.set_kra(_obj_kra);
                if (status == true)
                {
                    Pms_Bll.ShowMessage(this, "KRA Inserted Succesfully");
                    loadgrid();
                    clearfields();
                    RM_kraform.SelectedIndex = 0;
                    return;
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Mgr_Kra", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    #endregion

}
