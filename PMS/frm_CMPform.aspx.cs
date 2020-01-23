using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using Telerik.Web.UI;
using SPMS;

public partial class PMS_frm_CMPform : System.Web.UI.Page
{
    PMS_CMP _obj_cmp;
    SMHR_BUSINESSUNIT _obj_smhr_businessunit;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SPMS_PROJECT _obj_Pms_Project;

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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Competencies");//KEY RESULT AREA");
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
                    RG_CMPform.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
                RM_CMPform.SelectedIndex = 0;
                LoadCombos();

            }
            Page.Validate();
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CMPform", ex.StackTrace, DateTime.Now);
            //Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CMPform", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void clearfields()
    {
        try
        {
            txt_cmpname.Text = string.Empty;
            txt_description.Text = string.Empty;
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CMPform", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void RG_cmpform_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            _obj_cmp = new PMS_CMP();
            _obj_cmp.OPERATION = operation.Select;
            _obj_cmp.CMP_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_cmp.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);

            DataTable dt = Pms_Bll.get_cmp(_obj_cmp);
            if (dt.Rows.Count != 0)
            {
                RG_CMPform.DataSource = dt;
            }
            else
            {
                DataTable dt1 = new DataTable();

                RG_CMPform.DataSource = dt1;
            }

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CMPform", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void loadgrid()
    {
        try
        {
            _obj_cmp = new PMS_CMP();
            _obj_cmp.OPERATION = operation.Select;
            _obj_cmp.CMP_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_cmp.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);

            DataTable dt = Pms_Bll.get_cmp(_obj_cmp);
            if (dt.Rows.Count != 0)
            {
                RG_CMPform.DataSource = dt;
                RG_CMPform.DataBind();
            }
            else
            {
                DataTable dt1 = new DataTable();

                RG_CMPform.DataSource = dt1;
            }

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CMPform", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            clearfields();
            LoadCombos();
            RM_CMPform.SelectedIndex = 1;
            btn_SAVE.Visible = true;
            btn_Update.Visible = false;
            txt_description.Enabled = true;
            txt_cmpname.Enabled = true;
            //rtxt_KRAID.Enabled = true;
            //txt_Measure.Enabled = true;
            //rcmb_BUI.SelectedIndex = 0;
            rcmb_BUI.Enabled = true;
            lbl_status.Visible = true;
            cln_status.Visible = true;
            chkbx_status.Checked = false;
            chkbx_status.Visible = true;
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CMPform", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Commnad(object sender, CommandEventArgs e)
    {
        try
        {
            clearfields();
            LoadCombos();
            _obj_cmp = new PMS_CMP();
            _obj_cmp.OPERATION = operation.Get;
            _obj_cmp.CMP_ID = Convert.ToInt32(e.CommandArgument);
            _obj_cmp.CMP_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT = Pms_Bll.get_cmp(_obj_cmp);
            if (DT.Rows.Count != 0)
            {
                lbl_id.Text = Convert.ToString(DT.Rows[0]["CMP_ID"]);
                txt_cmpname.Text = Pms_Bll.ReplaceQuote(Convert.ToString(DT.Rows[0]["CMP_NAME"]));
                txt_description.Text = Pms_Bll.ReplaceQuote(Convert.ToString(DT.Rows[0]["CMP_DESCRIPTION"]));
                rcmb_BUI.SelectedIndex = rcmb_BUI.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["CMP_BU_ID"]));
                if (Convert.ToInt32(DT.Rows[0]["CMP_STATUS"]) == 0)
                {
                    chkbx_status.Checked = true;
                }
                else if (Convert.ToInt32(DT.Rows[0]["CMP_STATUS"]) == 1)
                {
                    chkbx_status.Checked = false;
                }
                RM_CMPform.SelectedIndex = 1;
                btn_SAVE.Visible = true;
                btn_SAVE.Visible = false;
                btn_Update.Visible = true;
                txt_description.Enabled = true;
                txt_cmpname.Enabled = false;
                //rtxt_KRAID.Enabled = false;
                //txt_Measure.Enabled = true;
                rcmb_BUI.Enabled = false;
                lbl_status.Visible = true;
                cln_status.Visible = true;
                chkbx_status.Visible = true;

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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CMPform", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Update_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_cmp = new PMS_CMP();
            _obj_cmp.CMP_ID = Convert.ToInt32(lbl_id.Text);
            _obj_cmp.CMP_NAME = Pms_Bll.ReplaceQuote(Convert.ToString(txt_cmpname.Text));
            _obj_cmp.CMP_DESCRIPTION = Pms_Bll.ReplaceQuote(Convert.ToString(txt_description.Text));
            _obj_cmp.CMP_BU_ID = Convert.ToInt32(rcmb_BUI.SelectedValue);
            //_obj_cmp.KRA_MEASURE = Convert.ToString(txt_Measure.Text.Replace("'", "''"));
            _obj_cmp.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_cmp.LASTMDFDATE = DateTime.Now;
            _obj_cmp.OPERATION = operation.Update;
            //_obj_cmp.KRA_KRAID = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_KRAID.Text));
            //_obj_kra.KRA_WEIGHTAGE = Convert.ToInt32(RNT_KraWeightage.Value);
            if (chkbx_status.Checked == true)
            {
                _obj_cmp.CMP_STATUS = 0;
            }
            else if (chkbx_status.Checked == false)
            {
                _obj_cmp.CMP_STATUS = 1;
            }
            bool status = Pms_Bll.set_cmp(_obj_cmp);
            if (status == true)
            {
                Pms_Bll.ShowMessage(this, "Competency Updated Successfully");
                loadgrid();
                btn_Update.Visible = true;
                RM_CMPform.SelectedIndex = 0;
            }
            else
            {
                Pms_Bll.ShowMessage(this, "Unable to Update the record,Execption Occured");
                return;
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CMPform", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            RM_CMPform.SelectedIndex = 0;
            loadgrid();
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CMPform", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void btn_SAVE_Click1(object sender, EventArgs e)
    {
        try
        {
            string s = Convert.ToString(txt_description.Text);
            if (s.Length > 1000)
            {
                Pms_Bll.ShowMessage(this, "Description Cannot Greater Than 1000 Characters");
                return;

            }
            _obj_cmp = new PMS_CMP();
            _obj_cmp.OPERATION = operation.Check;
            _obj_cmp.CMP_NAME = Pms_Bll.ReplaceQuote(Convert.ToString(txt_cmpname.Text));
            _obj_cmp.CMP_BU_ID = Convert.ToInt32(rcmb_BUI.SelectedValue);
            _obj_cmp.CMP_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = Pms_Bll.get_cmp(_obj_cmp);
            if (Convert.ToInt32(dt.Rows[0]["Count"]) != 0)
            {
                Pms_Bll.ShowMessage(this, "Competency Already Exist");
                return;
            }
            else
            {
                _obj_cmp = new PMS_CMP();

                _obj_cmp.OPERATION = operation.Insert;
                _obj_cmp.CMP_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_cmp.CMP_NAME = Pms_Bll.ReplaceQuote(Convert.ToString(txt_cmpname.Text));

                _obj_cmp.CMP_DESCRIPTION = Pms_Bll.ReplaceQuote(Convert.ToString(txt_description.Text));
                _obj_cmp.CMP_BU_ID = Convert.ToInt32(rcmb_BUI.SelectedItem.Value);
                _obj_cmp.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                _obj_cmp.LASTMDFDATE = DateTime.Now;
                _obj_cmp.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                _obj_cmp.CREATEDDATE = DateTime.Now;
                if (chkbx_status.Checked)
                {
                    _obj_cmp.CMP_STATUS = 0;
                }
                else
                {
                    _obj_cmp.CMP_STATUS = 1;
                }
                // _obj_cmp.CMP_STATUS = true;
                //_obj_cmp.KRA_KRAID = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_KRAID.Text));
                //_obj_kra.KRA_WEIGHTAGE = Convert.ToInt32(RNT_KraWeightage.Value);

                bool status = Pms_Bll.set_cmp(_obj_cmp);
                if (status == true)
                {
                    Pms_Bll.ShowMessage(this, "Competency Inserted Successfully");
                    loadgrid();
                    clearfields();
                    RM_CMPform.SelectedIndex = 0;
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CMPform", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
}