using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SMHR;
using Telerik.Web.UI;
public partial class PMS_frm_HrCreation : System.Web.UI.Page
{
    #region References
    /// <summary>
    /// Contains The Classes Which Will Be Used In Other Methods Of This Forms
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    SMHR_LOGININFO _obj_logininfo = new SMHR_LOGININFO();
    PMS_HRCREATION _obj_hrcreation = new PMS_HRCREATION();
    DataTable dt_Result = new DataTable();
    DataTable dt_Null = new DataTable();
    #endregion

    #region PageLoad
    /// <summary>
    /// For Loading The Grid
    /// </summary>    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Add HR to Business Unit");//HRCREATION");
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
                    RG_Addhr.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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

                loadgrid();
                RG_Addhr.DataBind();
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_HrCreation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    #region Loading Methods
    /// <summary>
    /// All The Methods Like Loading Combos,Loading Grid Were Available In This Region
    /// </summary>
    private void loadgrid()
    {
        try
        {
            _obj_hrcreation.OPERATION = operation.Select;
            _obj_hrcreation.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Result = BLL.get_Hrinformation(_obj_hrcreation);
            if (dt_Result.Rows.Count > 0)
            {
                RG_Addhr.DataSource = dt_Result;
                // RG_Addhr.DataBind();
            }
            else
            {
                RG_Addhr.DataSource = dt_Null;
                //RG_Addhr.DataBind();
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_HrCreation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void loadbusinessunit()
    {

        try
        {
            _obj_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            rcmb_Businessunit.Items.Clear();
            dt_Result = BLL.get_Business_Units(_obj_logininfo);
            if (dt_Result.Rows.Count > 0)
            {
                rcmb_Businessunit.DataSource = dt_Result;
                rcmb_Businessunit.DataTextField = "BUSINESSUNIT_CODE";
                rcmb_Businessunit.DataValueField = "BUSINESSUNIT_ID";
                rcmb_Businessunit.DataBind();
                rcmb_Businessunit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_HrCreation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void RG_Addhr_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            loadgrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_HrCreation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    #region Page Redirecting
    /// <summary>
    /// For Moving The Control From One Page To Other Page
    /// </summary>    
    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            ClearControls();
            btn_Save.Visible = true;
            btn_Update.Visible = false;
            loadbusinessunit();
            rcmb_Businessunit.Enabled = true;
            RMP_Addhr.SelectedIndex = 1;
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_HrCreation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            ClearControls();
            loadbusinessunit();
            _obj_hrcreation.OPERATION = operation.Check1;
            _obj_hrcreation.HR_CREATION_ID = Convert.ToInt32(e.CommandArgument);
            dt_Result = BLL.get_Hrinformation(_obj_hrcreation);
            lbl_dummy.Text = Convert.ToString(e.CommandArgument);
            if (dt_Result.Rows.Count > 0)
            {
                rcmb_Businessunit.SelectedIndex = Convert.ToInt32(rcmb_Businessunit.FindItemIndexByValue(dt_Result.Rows[0]["PMS_HRCREATION_BUSINESSUNIT_ID"].ToString()));
                rtxt_Hrmailid.Text = Convert.ToString(dt_Result.Rows[0]["PMS_HRCREATION_HRMAILID"]);
                rcmb_Businessunit.Enabled = false;
                RMP_Addhr.SelectedIndex = 1;
            }
            else
            {
                BLL.ShowMessage(this, "Error Occured During The Process");
            }


            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {


                btn_Update.Visible = false;
                btn_Save.Visible = false;

            }
            else
            {
                btn_Update.Visible = true;
                btn_Save.Visible = false;
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_HrCreation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region Clear Selection
    /// <summary>
    /// For Clearing The Controls
    /// </summary>
    private void ClearControls()
    {
        try
        {
            rtxt_Hrmailid.Text = string.Empty;
            rcmb_Businessunit.Items.Clear();
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_HrCreation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region Button Click Events
    /// <summary>
    /// This Region Will Consists Of Save Methods And Clearing Controls
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_hrcreation.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_hrcreation.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_Businessunit.SelectedValue);
            _obj_hrcreation.HR_EMAIL_ID = rtxt_Hrmailid.Text;
            _obj_hrcreation.HR_CREATION_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_hrcreation.HR_CREATION_CREATEDDATE = DateTime.Now;
            _obj_hrcreation.HR_CREATION_LSTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_hrcreation.HR_CREATION_LSTMDFDATE = DateTime.Now;

            if (Convert.ToString(rtxt_Hrmailid.Text.Replace("'", "''")) != string.Empty)
            {
                _obj_hrcreation.HR_EMAIL_ID = BLL.ReplaceQuote(Convert.ToString(rtxt_Hrmailid.Text.Replace("'", "''")).Trim());
                _obj_hrcreation.OPERATION = operation.Check;
                if (Convert.ToInt32(BLL.get_Hrinformation(_obj_hrcreation).Rows[0][0]) > 0)
                {
                    BLL.ShowMessage(this, "Email ID Already Exists.Please enter another Email ID");
                    return;
                }
            }
            _obj_hrcreation.OPERATION = operation.Insert;
            if (BLL.set_Hrcreation(_obj_hrcreation))
            {
                BLL.ShowMessage(this, "Information Saved Successfully!");
                ClearControls();
                btn_Save.Visible = false;
                btn_Update.Visible = false;
                RMP_Addhr.SelectedIndex = 0;
                loadgrid();
                RG_Addhr.DataBind();

            }


            else
            {
                BLL.ShowMessage(this, "Error Occured During The Process!");
            }

        }


        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_HrCreation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void btn_update_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_hrcreation.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_hrcreation.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_Businessunit.SelectedValue);
            _obj_hrcreation.HR_EMAIL_ID = rtxt_Hrmailid.Text;
            _obj_hrcreation.HR_CREATION_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_hrcreation.HR_CREATION_CREATEDDATE = DateTime.Now;
            _obj_hrcreation.HR_CREATION_LSTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_hrcreation.HR_CREATION_LSTMDFDATE = DateTime.Now;

            _obj_hrcreation.HR_CREATION_ID = Convert.ToInt32(lbl_dummy.Text);
            if (Convert.ToString(rtxt_Hrmailid.Text.Replace("'", "''")) != string.Empty)
            {
                _obj_hrcreation.HR_EMAIL_ID = BLL.ReplaceQuote(Convert.ToString(rtxt_Hrmailid.Text.Replace("'", "''")).Trim());
                _obj_hrcreation.OPERATION = operation.Check;
                if (Convert.ToInt32(BLL.get_Hrinformation(_obj_hrcreation).Rows[0][0]) > 0)
                {
                    BLL.ShowMessage(this, "Email ID Already Exists.Please enter another Email ID");
                    return;
                }
            }

            _obj_hrcreation.OPERATION = operation.Update;


            if (BLL.set_Hrcreation(_obj_hrcreation))
            {
                BLL.ShowMessage(this, "Information Updated Successfully!");
                ClearControls();
                btn_Save.Visible = false;
                btn_Update.Visible = false;
                RMP_Addhr.SelectedIndex = 0;
                loadgrid();
                RG_Addhr.DataBind();
            }

            else
            {
                BLL.ShowMessage(this, "Error Occured During The Process!");
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_HrCreation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            ClearControls();
            btn_Save.Visible = false;
            btn_Update.Visible = false;
            RMP_Addhr.SelectedIndex = 0;
            loadgrid();
            RG_Addhr.DataBind();
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_HrCreation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

}
