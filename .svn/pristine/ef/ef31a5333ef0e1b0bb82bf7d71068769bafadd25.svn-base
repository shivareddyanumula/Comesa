using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using SPMS;
using System.Data.SqlClient;
using Telerik.Web.UI;
using System.Data;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.ComponentModel;
using Telerik.Charting;
public partial class PMS_FrmEmployeeRating : System.Web.UI.Page
{
    SPMS_APRAISALSTATUS _obj_Pms_AppStatus;
    PMS_Appraisalcycle _obj_Pms_Appraisalcycle;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
            if (!Page.IsPostBack)
            {


                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("My Final Rating Details");
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
                    RG_Employeertg.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    //btn_Save.Visible = false;
                    //btn_Update.Visible = false;
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
                if (Convert.ToInt32(Session["EMP_ID"]) == 0)
                {
                    BLL.ShowConfirmMessage(this, "You Can Not Access This Screen.");
                    //Response.Redirect("~/Masters/Default.aspx", false);
                    return;
                }
                RG_Employeertg.Visible = false;
                //loadgrid();
                LoadAppraisalCycle();

            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "FrmEmployeeRating", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadAppraisalCycle()
    {
        try
        {
            rcmb_appcycle.ClearSelection();
            rcmb_appcycle.Items.Clear();
            rcmb_appcycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            _obj_Pms_Appraisalcycle.MODE = 11;
            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(Session["EMP_ID"]);//where i am passing employee to get bunit
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtemzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            _obj_Pms_Appraisalcycle.MODE = 9;
            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz.Rows[0]["EMP_BUSINESSUNIT_ID"]);
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["org_id"]);
            DataTable DT_AppraisalCycle = new DataTable();
            DT_AppraisalCycle = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
            if (DT_AppraisalCycle.Rows.Count != 0)
            {
                rcmb_appcycle.DataSource = DT_AppraisalCycle;
                rcmb_appcycle.DataTextField = "APPRCYCLE_NAME";
                rcmb_appcycle.DataValueField = "APPRCYCLE_ID";
                rcmb_appcycle.DataBind();
                rcmb_appcycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
            else
            {
                rcmb_appcycle.ClearSelection();
                rcmb_appcycle.Items.Clear();
                rcmb_appcycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "FrmEmployeeRating", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #region loadgrid()
    /// <summary>
    /// Here loadgrid() method for load a grid...
    /// </summary>
    protected void loadgrid()
    {
        try
        {
            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            _obj_Pms_Appraisalcycle.MODE = 11;
            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(Session["EMP_ID"]);//where i am passing employee to get bunit
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtemzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

            _obj_Pms_Appraisalcycle.MODE = 8;
            if (dtemzz.Rows.Count != 0)
            {
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                DataTable dtappidzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                if (dtappidzz.Rows.Count != 0)
                {
                    _obj_Pms_AppStatus = new SPMS_APRAISALSTATUS();
                    _obj_Pms_AppStatus.APP_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                    _obj_Pms_AppStatus.APP_LASTMDFBY = Convert.ToInt32(rcmb_appcycle.SelectedItem.Value);//Convert.ToInt32(dtappidzz.Rows[0]["APPRCYCLE_ID"]);
                    _obj_Pms_AppStatus.Mode = 6;
                    _obj_Pms_AppStatus.APP_STATUS_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dt = Pms_Bll.get_AppStatus(_obj_Pms_AppStatus);
                    if (dt.Rows.Count != 0)
                    {
                        RG_Employeertg.DataSource = dt;
                        RG_Employeertg.DataBind();
                    }
                    else
                    {
                        DataTable dt1 = new DataTable();
                        RG_Employeertg.DataSource = dt1;
                        RG_Employeertg.DataBind();
                    }
                }
                else
                {
                    DataTable dt1 = new DataTable();
                    RG_Employeertg.DataSource = dt1;
                    RG_Employeertg.DataBind();
                }
            }

            else
            {
                DataTable dt1 = new DataTable();
                RG_Employeertg.DataSource = dt1;
                RG_Employeertg.DataBind();
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "FrmEmployeeRating", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void RG_Employeertg_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            _obj_Pms_Appraisalcycle.MODE = 11;
            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(Session["EMP_ID"]);//where i am passing employee to get bunit
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtemzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

            _obj_Pms_Appraisalcycle.MODE = 8;
            if (dtemzz.Rows.Count != 0)
            {
                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtappidzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                _obj_Pms_AppStatus = new SPMS_APRAISALSTATUS();
                _obj_Pms_AppStatus.APP_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                _obj_Pms_AppStatus.Mode = 6;
                _obj_Pms_AppStatus.APP_LASTMDFBY = Convert.ToInt32(rcmb_appcycle.SelectedItem.Value);// Convert.ToInt32(dtappidzz.Rows[0]["APPRCYCLE_ID"]);
                _obj_Pms_AppStatus.APP_STATUS_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt = Pms_Bll.get_AppStatus(_obj_Pms_AppStatus);
                if (dt.Rows.Count != 0)
                {
                    RG_Employeertg.DataSource = dt;

                }
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "FrmEmployeeRating", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion


    protected void rcmb_appcycle_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_appcycle.SelectedIndex > 0)
            {
                loadgrid();
                RG_Employeertg.Visible = true;
            }
            else
            {
                RG_Employeertg.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "FrmEmployeeRating", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
