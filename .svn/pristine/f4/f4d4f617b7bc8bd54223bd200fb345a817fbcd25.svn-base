using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using SPMS;
using Telerik.Web.UI;

public partial class PMS_frm_AppraisalStatus : System.Web.UI.Page
{
    SPMS_APPRAISAL _obj_Spms_Appraisal;
    SMHR_BUSINESSUNIT _obj_smhr_businessunit;
    SPMS_APRAISALSTATUS _obj_Pms_AppStatus;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    PMS_Appraisalcycle _obj_Pms_Appraisalcycle;
    SPMS_APRAISALDISCUSSION _obj_Pms_AppDiscDtls;

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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Appraisal Status");//AppraisalStatus");
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
                    RG_AppraisalStatus.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_save.Visible = false;
                    // btn_Update.Visible = false;
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
                //loadgrid();
                loadBusinessUnit();
                btn_save.Visible = false;
                btn_finalise.Visible = false;
                //RG_AppraisalStatus.Visible = false;
                RG_AppraisalStatus.Visible = false;
                //rcmb_status.Visible = false;
                //lbl_status.Visible = false;
                tr_status.Visible = false;
                RM_AppraisalStatus.SelectedIndex = 0;


            }

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AppraisalStatus", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region load businessunit

    protected void loadBusinessUnit()
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
                RCB_BusinessUnit.DataSource = dt_BUDetails;
                RCB_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
                RCB_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
                RCB_BusinessUnit.DataBind();
                RCB_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));
            }

            else
            {
                DataTable dt_Details = new DataTable();
                RCB_BusinessUnit.DataSource = dt_Details;

                RCB_BusinessUnit.DataBind();
                RCB_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AppraisalStatus", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    #endregion

    #region businessunit index changed event

    protected void RCB_BusinessUnit_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (RCB_BusinessUnit.SelectedItem.Text != "Select")
            {
                LoadAppraisalCycle();
                tr_status.Visible = false;
                btn_save.Visible = false;
                //rcmb_status.Visible = false;
                //lbl_status.Visible = false;
            }

            else
            {
                Pms_Bll.ShowMessage(this, "Please Select Business Unit");
                //DataTable dt5 = new DataTable();
                //RCB_AppraisalCycle.DataSource = dt5;
                //RCB_AppraisalCycle.DataBind();
                RCB_AppraisalCycle.ClearSelection();
                RCB_AppraisalCycle.Items.Clear();
                RCB_AppraisalCycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                RG_AppraisalStatus.Visible = false;
                //rcmb_status.DataSource = dt5;
                //rcmb_status.DataBind();
                //rcmb_status.Visible = false;
                //lbl_status.Visible = false;
                tr_status.Visible = false;
                btn_save.Visible = false;
                return;

            }

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AppraisalStatus", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion
    
    #region appraisal cycle

    protected void LoadAppraisalCycle()
    {
        try
        {

            RCB_AppraisalCycle.Items.Clear();
            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            _obj_Pms_Appraisalcycle.OPERATION = operation.Empty;
            _obj_Pms_Appraisalcycle.MODE = 8;
            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(RCB_BusinessUnit.SelectedItem.Value);
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT_AppraisalCycle = new DataTable();

            DT_AppraisalCycle = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
            if (DT_AppraisalCycle.Rows.Count != 0)
            {
                RCB_AppraisalCycle.DataSource = DT_AppraisalCycle;
                RCB_AppraisalCycle.DataTextField = "APPRCYCLE_NAME";
                RCB_AppraisalCycle.DataValueField = "APPRCYCLE_ID";
                RCB_AppraisalCycle.DataBind();
                RCB_AppraisalCycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
            else
            {
                DataTable dt1 = new DataTable();
                RCB_AppraisalCycle.DataSource = dt1;

                RCB_AppraisalCycle.DataBind();
                RCB_AppraisalCycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AppraisalStatus", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    #endregion

    #region appraisal cycle changed

    protected void RCB_AppraisalCycle_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            //loadgrid();
            //RG_AppraisalStatus.Visible = true;
            //btn_save.Visible = true;
            //btn_finalise.Visible = false;
            //btn_save.Visible = false;
            if (RCB_AppraisalCycle.SelectedItem.Text != "Select")
            {
                rcmb_status.Enabled = true;
                rcmb_status.SelectedIndex = 0;
                //rcmb_status.Visible = true;
                //lbl_status.Visible = true;
                tr_status.Visible = true;
                RG_AppraisalStatus.Visible = false;
                btn_save.Visible = false;
            }
            else
            {
                Pms_Bll.ShowMessage(this, "Please Select Appraisal Cycle");
                DataTable dt5 = new DataTable();
                RG_AppraisalStatus.Visible = false;
                btn_save.Visible = false;
                //rcmb_status.DataSource = dt5;
                //rcmb_status.DataBind();
                //rcmb_status.Visible = false;
                //lbl_status.Visible = false;
                tr_status.Visible = false;
                return;

            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AppraisalStatus", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region loadgrid for uncompleted

    protected void loadgrid1()
    {
        try
        {

            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            _obj_Pms_Appraisalcycle.MODE = 8;
            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(RCB_BusinessUnit.SelectedValue);
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtappidzz1 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
            if (dtappidzz1.Rows.Count != 0)
            {

                _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                _obj_Spms_Appraisal.APPRAISAL_BUSSINESS_UNIT = Convert.ToInt32(RCB_BusinessUnit.SelectedValue);
                _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(RCB_AppraisalCycle.SelectedItem.Value);//Convert.ToInt32(dtappidzz1.Rows[0]["APPRCYCLE_ID"]);
                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Spms_Appraisal.Mode = 29;
                DataTable dt = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

                if (dt.Rows.Count != 0)
                {
                    RG_AppraisalStatus.DataSource = dt;
                    dt.Columns.Add("SI_NO");
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        dt.Rows[j]["SI_NO"] = j;
                    }

                    RG_AppraisalStatus.DataBind();




                    for (int i = 0; i < RG_AppraisalStatus.Items.Count; i++)
                    {
                        int count_status = Convert.ToInt32(RG_AppraisalStatus.Items[i]["Appraisal_status"].Text);
                        string REPORT_MANAGER = Convert.ToString(RG_AppraisalStatus.Items[i]["REPORTINGMANAGER"].Text);
                        string GROUP_MANAGER = Convert.ToString(RG_AppraisalStatus.Items[i]["APPROVALMANAGER"].Text);
                        string EMP_NAME1 = Convert.ToString(RG_AppraisalStatus.Items[i]["EMP_NAME"].Text);
                        if (count_status == 1)
                        {
                            ImageButton imge1;
                            imge1 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight1") as ImageButton;
                            imge1.Visible = true;
                            imge1.ToolTip = EMP_NAME1;

                            ImageButton imge11 = new ImageButton();
                            imge11 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight11") as ImageButton;
                            imge11.Visible = false;
                            imge11.ToolTip = EMP_NAME1;
                            //---------------------------------------------------------------------------------
                            ImageButton imge2 = new ImageButton();
                            imge2 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight2") as ImageButton;
                            imge2.Visible = false;
                            imge2.ToolTip = REPORT_MANAGER;

                            ImageButton imge22 = new ImageButton();
                            imge22 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight22") as ImageButton;
                            imge22.Visible = true;
                            imge22.ToolTip = REPORT_MANAGER;
                            //---------------------------------------------------------------------------------
                            ImageButton imge3 = new ImageButton();
                            imge3 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight3") as ImageButton;
                            imge3.Visible = false;
                            imge3.ToolTip = GROUP_MANAGER;

                            ImageButton imge33 = new ImageButton();
                            imge33 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight33") as ImageButton;
                            imge33.Visible = true;
                            imge33.ToolTip = GROUP_MANAGER;
                            //-            --------------------------------------------------------------------------------

                            _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                            _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(dt.Rows[i]["EMPID"]);
                            _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(RCB_AppraisalCycle.SelectedItem.Value); //Convert.ToInt32(dtappidzz1.Rows[0]["APPRCYCLE_ID"]);

                            _obj_Spms_Appraisal.Mode = 5;

                            DataTable dtgoal4 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                            if (dtgoal4.Rows.Count != 0)
                            {
                                _obj_Spms_Appraisal.APPRAISAL_ID = Convert.ToInt32(dtgoal4.Rows[0]["APPRAISAL_ID"]);
                            }

                            //_obj_Spms_AppraisalKra.APP_KRA_FIXED = 1;
                            _obj_Spms_Appraisal.EMPID = Convert.ToInt32(dt.Rows[i]["EMPID"]);
                            _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Spms_Appraisal.Mode = 4;
                            if (Convert.ToString(Pms_Bll.get_EmpRatingDetails(_obj_Spms_Appraisal).Rows[0]["Count"]) == "0")
                            {
                                ImageButton imge41 = new ImageButton();
                                imge41 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight4") as ImageButton;
                                imge41.Visible = false;
                                imge41.ToolTip = GROUP_MANAGER;

                                ImageButton imge441 = new ImageButton();
                                imge441 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight44") as ImageButton;
                                imge441.Visible = true;
                                imge441.ToolTip = GROUP_MANAGER;
                            }
                            else
                            {
                                ImageButton imge4 = new ImageButton();
                                imge4 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight4") as ImageButton;
                                imge4.Visible = true;
                                imge4.ToolTip = GROUP_MANAGER;

                                ImageButton imge44 = new ImageButton();
                                imge44 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight44") as ImageButton;
                                imge44.Visible = false;
                                imge44.ToolTip = GROUP_MANAGER;
                            }

                        }
                        else if (count_status == 2)
                        {
                            ImageButton imge1;
                            imge1 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight1") as ImageButton;
                            imge1.Visible = true;
                            imge1.ToolTip = EMP_NAME1;

                            ImageButton imge11 = new ImageButton();
                            imge11 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight11") as ImageButton;
                            imge11.Visible = false;
                            imge11.ToolTip = EMP_NAME1;
                            //---------------------------------------------------------------------------------
                            ImageButton imge2 = new ImageButton();
                            imge2 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight2") as ImageButton;
                            imge2.Visible = true;
                            imge2.ToolTip = REPORT_MANAGER;

                            ImageButton imge22 = new ImageButton();
                            imge22 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight22") as ImageButton;
                            imge22.Visible = false;
                            imge22.ToolTip = REPORT_MANAGER;
                            //---------------------------------------------------------------------------------
                            ImageButton imge3 = new ImageButton();
                            imge3 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight3") as ImageButton;
                            imge3.Visible = false;
                            imge3.ToolTip = GROUP_MANAGER;

                            ImageButton imge33 = new ImageButton();
                            imge33 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight33") as ImageButton;
                            imge33.Visible = true;
                            imge33.ToolTip = GROUP_MANAGER;
                            //---------------------------------------------------------------------------------
                            _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                            _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(dt.Rows[i]["EMPID"]);
                            _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(RCB_AppraisalCycle.SelectedItem.Value); //Convert.ToInt32(dtappidzz1.Rows[0]["APPRCYCLE_ID"]);

                            _obj_Spms_Appraisal.Mode = 5;

                            DataTable dtgoal4 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                            if (dtgoal4.Rows.Count != 0)
                            {
                                _obj_Spms_Appraisal.APPRAISAL_ID = Convert.ToInt32(dtgoal4.Rows[0]["APPRAISAL_ID"]);
                            }

                            //_obj_Spms_AppraisalKra.APP_KRA_FIXED = 1;
                            _obj_Spms_Appraisal.EMPID = Convert.ToInt32(dt.Rows[i]["EMPID"]);
                            _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Spms_Appraisal.Mode = 4;
                            if (Convert.ToString(Pms_Bll.get_EmpRatingDetails(_obj_Spms_Appraisal).Rows[0]["Count"]) == "0")
                            {
                                ImageButton imge41 = new ImageButton();
                                imge41 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight4") as ImageButton;
                                imge41.Visible = false;
                                imge41.ToolTip = GROUP_MANAGER;

                                ImageButton imge441 = new ImageButton();
                                imge441 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight44") as ImageButton;
                                imge441.Visible = true;
                                imge441.ToolTip = GROUP_MANAGER;
                            }
                            else
                            {
                                ImageButton imge4 = new ImageButton();
                                imge4 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight4") as ImageButton;
                                imge4.Visible = true;
                                imge4.ToolTip = GROUP_MANAGER;

                                ImageButton imge44 = new ImageButton();
                                imge44 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight44") as ImageButton;
                                imge44.Visible = false;
                                imge44.ToolTip = GROUP_MANAGER;
                            }
                        }
                        else if (count_status == 3)
                        {
                            ImageButton imge1;
                            imge1 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight1") as ImageButton;
                            imge1.Visible = true;
                            imge1.ToolTip = EMP_NAME1;

                            ImageButton imge11 = new ImageButton();
                            imge11 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight11") as ImageButton;
                            imge11.Visible = false;
                            imge11.ToolTip = EMP_NAME1;
                            //---------------------------------------------------------------------------------
                            ImageButton imge2 = new ImageButton();
                            imge2 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight2") as ImageButton;
                            imge2.Visible = true;
                            imge2.ToolTip = REPORT_MANAGER;

                            ImageButton imge22 = new ImageButton();
                            imge22 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight22") as ImageButton;
                            imge22.Visible = false;
                            imge22.ToolTip = REPORT_MANAGER;
                            //---------------------------------------------------------------------------------
                            ImageButton imge3 = new ImageButton();
                            imge3 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight3") as ImageButton;
                            imge3.Visible = true;
                            imge3.ToolTip = GROUP_MANAGER;

                            ImageButton imge33 = new ImageButton();
                            imge33 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight33") as ImageButton;
                            imge33.Visible = false;
                            imge33.ToolTip = GROUP_MANAGER;
                            //---------------------------------------------------------------------------------
                            _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                            _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(dt.Rows[i]["EMPID"]);
                            _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(RCB_AppraisalCycle.SelectedItem.Value); //Convert.ToInt32(dtappidzz1.Rows[0]["APPRCYCLE_ID"]);

                            _obj_Spms_Appraisal.Mode = 5;

                            DataTable dtgoal4 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                            if (dtgoal4.Rows.Count != 0)
                            {
                                _obj_Spms_Appraisal.APPRAISAL_ID = Convert.ToInt32(dtgoal4.Rows[0]["APPRAISAL_ID"]);
                            }

                            //_obj_Spms_AppraisalKra.APP_KRA_FIXED = 1;
                            _obj_Spms_Appraisal.EMPID = Convert.ToInt32(dt.Rows[i]["EMPID"]);
                            _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Spms_Appraisal.Mode = 4;
                            if (Convert.ToString(Pms_Bll.get_EmpRatingDetails(_obj_Spms_Appraisal).Rows[0]["Count"]) == "0")
                            {
                                ImageButton imge41 = new ImageButton();
                                imge41 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight4") as ImageButton;
                                imge41.Visible = false;
                                imge41.ToolTip = GROUP_MANAGER;

                                ImageButton imge441 = new ImageButton();
                                imge441 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight44") as ImageButton;
                                imge441.Visible = true;
                                imge441.ToolTip = GROUP_MANAGER;
                            }
                            else
                            {
                                ImageButton imge4 = new ImageButton();
                                imge4 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight4") as ImageButton;
                                imge4.Visible = true;
                                imge4.ToolTip = GROUP_MANAGER;

                                ImageButton imge44 = new ImageButton();
                                imge44 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight44") as ImageButton;
                                imge44.Visible = false;
                                imge44.ToolTip = GROUP_MANAGER;
                            }
                        }
                        else
                        {
                            ImageButton imge1;
                            imge1 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight1") as ImageButton;
                            imge1.Visible = true;
                            imge1.ToolTip = EMP_NAME1;

                            ImageButton imge11 = new ImageButton();
                            imge11 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight11") as ImageButton;
                            imge11.Visible = false;
                            imge11.ToolTip = EMP_NAME1;
                            //---------------------------------------------------------------------------------
                            ImageButton imge2 = new ImageButton();
                            imge2 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight2") as ImageButton;
                            imge2.Visible = true;
                            imge2.ToolTip = REPORT_MANAGER;

                            ImageButton imge22 = new ImageButton();
                            imge22 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight22") as ImageButton;
                            imge22.Visible = false;
                            imge22.ToolTip = REPORT_MANAGER;
                            //---------------------------------------------------------------------------------
                            ImageButton imge3 = new ImageButton();
                            imge3 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight3") as ImageButton;
                            imge3.Visible = true;
                            imge3.ToolTip = GROUP_MANAGER;

                            ImageButton imge33 = new ImageButton();
                            imge33 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight33") as ImageButton;
                            imge33.Visible = false;
                            imge33.ToolTip = GROUP_MANAGER;
                            //---------------------------------------------------------------------------------
                            _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                            _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(dt.Rows[i]["EMPID"]);
                            _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(RCB_AppraisalCycle.SelectedItem.Value);// Convert.ToInt32(dtappidzz1.Rows[0]["APPRCYCLE_ID"]);

                            _obj_Spms_Appraisal.Mode = 5;

                            DataTable dtgoal4 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                            if (dtgoal4.Rows.Count != 0)
                            {
                                _obj_Spms_Appraisal.APPRAISAL_ID = Convert.ToInt32(dtgoal4.Rows[0]["APPRAISAL_ID"]);
                            }

                            //_obj_Spms_AppraisalKra.APP_KRA_FIXED = 1;
                            _obj_Spms_Appraisal.EMPID = Convert.ToInt32(dt.Rows[i]["EMPID"]);
                            _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Spms_Appraisal.Mode = 4;
                            if (Convert.ToString(Pms_Bll.get_EmpRatingDetails(_obj_Spms_Appraisal).Rows[0]["Count"]) == "0")
                            {
                                ImageButton imge41 = new ImageButton();
                                imge41 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight4") as ImageButton;
                                imge41.Visible = false;
                                imge41.ToolTip = GROUP_MANAGER;

                                ImageButton imge441 = new ImageButton();
                                imge441 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight44") as ImageButton;
                                imge441.Visible = true;
                                imge441.ToolTip = GROUP_MANAGER;
                            }
                            else
                            {
                                ImageButton imge4 = new ImageButton();
                                imge4 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight4") as ImageButton;
                                imge4.Visible = true;
                                imge4.ToolTip = GROUP_MANAGER;

                                ImageButton imge44 = new ImageButton();
                                imge44 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight44") as ImageButton;
                                imge44.Visible = false;
                                imge44.ToolTip = GROUP_MANAGER;
                            }
                        }
                    }
                }

                else
                {
                    DataTable dt1 = new DataTable();
                    RG_AppraisalStatus.DataSource = dt1;
                    RG_AppraisalStatus.DataBind();
                }

                RadRating rdrtgpotential = new Telerik.Web.UI.RadRating();
                RadRating rdrtgbusiness = new Telerik.Web.UI.RadRating();
                RadRating txtfinal = new Telerik.Web.UI.RadRating();
                Button btngenerate = new Button();



                //SPMS_APRAISALSTATUS _obj_Pms_AppStatus = new SPMS_APRAISALSTATUS();
                //_obj_Pms_AppStatus.Mode = 1;
                //DataTable dtemp = Pms_Bll.get_AppStatus(_obj_Pms_AppStatus);
                //for (int l = 0; l <= dtemp.Rows.Count - 1; l++)
                //{
                //    int k = RG_AppraisalStatus.Items.Count - 1;
                //    rdrtgpotential = RG_AppraisalStatus.Items[k].FindControl("rdrtg_potential") as RadRating;
                //    rdrtgbusiness = RG_AppraisalStatus.Items[k].FindControl("rdrtg_business") as RadRating;
                //    btngenerate = RG_AppraisalStatus.Items[k].FindControl("btn_generat") as Button;
                //    int m = RG_AppraisalStatus.Items.Count - 1;
                //    Label lbl = new System.Web.UI.WebControls.Label();
                //    lbl = RG_AppraisalStatus.Items[m].FindControl("lbl_empid") as Label;
                //    CheckBox chk = new CheckBox();
                //    chk = RG_AppraisalStatus.Items[m].FindControl("chk") as CheckBox;

                //    string s = Convert.ToString(dtemp.Rows[l]["APP_EMP_ID"]);

                //    if (Convert.ToString(lbl.Text) == s)
                //    {

                //        chk.Enabled = false;
                //        rdrtgpotential.Enabled = false;
                //        rdrtgbusiness.Enabled = false;
                //        btngenerate.Enabled = false;
                //        chk.Visible = false;
                //    }
                //    else
                //    {
                //        chk.Enabled = true;
                //        rdrtgpotential.Enabled = true;
                //        rdrtgbusiness.Enabled = true;
                //        btngenerate.Enabled = true;
                //        chk.Visible = true;
                //    }

                //}

            }

            else
            {
                Pms_Bll.ShowMessage(this, "Busineeunit Has No Active AppraisalCycle");
                return;
            }

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AppraisalStatus", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region completed

    protected void loadgrid()
    {
        try
        {
            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            _obj_Pms_Appraisalcycle.MODE = 8;
            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(RCB_BusinessUnit.SelectedValue);
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtappidzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
            if (dtappidzz.Rows.Count != 0)
            {
                _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                _obj_Spms_Appraisal.APPRAISAL_BUSSINESS_UNIT = Convert.ToInt32(RCB_BusinessUnit.SelectedValue);
                _obj_Spms_Appraisal.Mode = 19;
                _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(RCB_AppraisalCycle.SelectedItem.Value); //Convert.ToInt32(dtappidzz.Rows[0]["APPRCYCLE_ID"]);
                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

                if (dt.Rows.Count != 0)
                {

                    dt.Columns.Add("SI_NO");
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        dt.Rows[j]["SI_NO"] = j;
                    }
                    RG_AppraisalStatus.DataSource = dt;
                    RG_AppraisalStatus.DataBind();
                    int index = RG_AppraisalStatus.Items.Count;

                    for (int i = 0; i < RG_AppraisalStatus.Items.Count; i++)
                    {
                        int count_status = Convert.ToInt32(RG_AppraisalStatus.Items[i]["Appraisal_status"].Text);
                        string REPORT_MANAGER = Convert.ToString(RG_AppraisalStatus.Items[i]["REPORTINGMANAGER"].Text);
                        string GROUP_MANAGER = Convert.ToString(RG_AppraisalStatus.Items[i]["APPROVALMANAGER"].Text);
                        string EMP_NAME1 = Convert.ToString(RG_AppraisalStatus.Items[i]["EMP_NAME"].Text);
                        bool slfAprslVAl = Convert.ToBoolean(dt.Rows[i]["APPRCYCLE_SELFAPPRAISAL"]);

                        if (count_status == 1)
                        {
                            ImageButton imge1;
                            imge1 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight1") as ImageButton;
                            imge1.Visible = true;
                            imge1.ToolTip = EMP_NAME1;

                            ImageButton imge11 = new ImageButton();
                            imge11 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight11") as ImageButton;
                            imge11.Visible = false;
                            imge11.ToolTip = EMP_NAME1;
                            //---------------------------------------------------------------------------------
                            ImageButton imge2 = new ImageButton();
                            imge2 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight2") as ImageButton;
                            imge2.Visible = false;
                            imge2.ToolTip = REPORT_MANAGER;

                            ImageButton imge22 = new ImageButton();
                            imge22 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight22") as ImageButton;
                            imge22.Visible = true;
                            imge22.ToolTip = REPORT_MANAGER;
                            //---------------------------------------------------------------------------------
                            ImageButton imge3 = new ImageButton();
                            imge3 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight3") as ImageButton;
                            imge3.Visible = false;
                            imge3.ToolTip = GROUP_MANAGER;

                            ImageButton imge33 = new ImageButton();
                            imge33 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight33") as ImageButton;
                            imge33.Visible = true;
                            imge33.ToolTip = GROUP_MANAGER;
                            //-            --------------------------------------------------------------------------------
                            ImageButton imge4 = new ImageButton();
                            imge4 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight4") as ImageButton;
                            imge4.Visible = false;
                            imge4.ToolTip = GROUP_MANAGER;

                            ImageButton imge44 = new ImageButton();
                            imge44 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight44") as ImageButton;
                            imge44.Visible = true;
                            imge44.ToolTip = GROUP_MANAGER;
                        }
                        else if (count_status == 2)
                        {
                            ImageButton imge1;
                            imge1 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight1") as ImageButton;
                            imge1.Visible = true;
                            imge1.ToolTip = EMP_NAME1;

                            ImageButton imge11 = new ImageButton();
                            imge11 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight11") as ImageButton;
                            imge11.Visible = false;
                            imge11.ToolTip = EMP_NAME1;
                            //---------------------------------------------------------------------------------
                            ImageButton imge2 = new ImageButton();
                            imge2 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight2") as ImageButton;
                            imge2.Visible = true;
                            imge2.ToolTip = REPORT_MANAGER;

                            ImageButton imge22 = new ImageButton();
                            imge22 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight22") as ImageButton;
                            imge22.Visible = false;
                            imge22.ToolTip = REPORT_MANAGER;
                            //---------------------------------------------------------------------------------
                            ImageButton imge3 = new ImageButton();
                            imge3 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight3") as ImageButton;
                            imge3.Visible = false;
                            imge3.ToolTip = GROUP_MANAGER;

                            ImageButton imge33 = new ImageButton();
                            imge33 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight33") as ImageButton;
                            imge33.Visible = true;
                            imge33.ToolTip = GROUP_MANAGER;
                            //---------------------------------------------------------------------------------
                            ImageButton imge4 = new ImageButton();
                            imge4 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight4") as ImageButton;
                            imge4.Visible = false;
                            imge4.ToolTip = GROUP_MANAGER;

                            ImageButton imge44 = new ImageButton();
                            imge44 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight44") as ImageButton;
                            imge44.Visible = true;
                            imge44.ToolTip = GROUP_MANAGER;
                        }
                        else if (count_status == 3)
                        {
                            ImageButton imge1;
                            imge1 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight1") as ImageButton;
                            imge1.Visible = true;
                            imge1.ToolTip = EMP_NAME1;

                            ImageButton imge11 = new ImageButton();
                            imge11 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight11") as ImageButton;
                            imge11.Visible = false;
                            imge11.ToolTip = EMP_NAME1;
                            //---------------------------------------------------------------------------------
                            ImageButton imge2 = new ImageButton();
                            imge2 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight2") as ImageButton;
                            imge2.Visible = true;
                            imge2.ToolTip = REPORT_MANAGER;

                            ImageButton imge22 = new ImageButton();
                            imge22 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight22") as ImageButton;
                            imge22.Visible = false;
                            imge22.ToolTip = REPORT_MANAGER;
                            //---------------------------------------------------------------------------------
                            ImageButton imge3 = new ImageButton();
                            imge3 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight3") as ImageButton;
                            imge3.Visible = true;
                            imge3.ToolTip = GROUP_MANAGER;

                            ImageButton imge33 = new ImageButton();
                            imge33 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight33") as ImageButton;
                            imge33.Visible = false;
                            imge33.ToolTip = GROUP_MANAGER;
                            //---------------------------------------------------------------------------------
                            ImageButton imge4 = new ImageButton();
                            imge4 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight4") as ImageButton;
                            imge4.Visible = false;
                            imge4.ToolTip = GROUP_MANAGER;

                            ImageButton imge44 = new ImageButton();
                            imge44 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight44") as ImageButton;
                            imge44.Visible = true;
                            imge44.ToolTip = GROUP_MANAGER;
                        }
                        else
                        {
                            /*ImageButton imge1;
                            imge1 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight1") as ImageButton;
                            imge1.Visible = true;
                            imge1.ToolTip = EMP_NAME1;

                            ImageButton imge11 = new ImageButton();
                            imge11 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight11") as ImageButton;
                            imge11.Visible = false;
                            imge11.ToolTip = EMP_NAME1;*/

                            if (slfAprslVAl == false)
                            {
                                ImageButton imge1;
                                imge1 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight1") as ImageButton;
                                imge1.Visible = false;
                                imge1.ToolTip = EMP_NAME1;

                                ImageButton imge11 = new ImageButton();
                                imge11 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight11") as ImageButton;
                                imge11.Visible = true;
                                imge11.ToolTip = EMP_NAME1;

                                //imge1.Visible = true;
                                //imge11.Visible = true;
                            }
                            else
                            {
                                ImageButton imge1;
                                imge1 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight1") as ImageButton;
                                imge1.Visible = true;
                                imge1.ToolTip = EMP_NAME1;

                                ImageButton imge11 = new ImageButton();
                                imge11 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight11") as ImageButton;
                                imge11.Visible = false;
                                imge11.ToolTip = EMP_NAME1;

                                //imge1.Visible = true;
                                //imge11.Visible = false;
                            }

                            //---------------------------------------------------------------------------------
                            ImageButton imge2 = new ImageButton();
                            imge2 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight2") as ImageButton;
                            imge2.Visible = true;
                            imge2.ToolTip = REPORT_MANAGER;

                            ImageButton imge22 = new ImageButton();
                            imge22 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight22") as ImageButton;
                            imge22.Visible = false;
                            imge22.ToolTip = REPORT_MANAGER;
                            //---------------------------------------------------------------------------------
                            ImageButton imge3 = new ImageButton();
                            imge3 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight3") as ImageButton;
                            imge3.Visible = true;
                            imge3.ToolTip = GROUP_MANAGER;

                            ImageButton imge33 = new ImageButton();
                            imge33 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight33") as ImageButton;
                            imge33.Visible = false;
                            imge33.ToolTip = GROUP_MANAGER;
                            //---------------------------------------------------------------------------------

                            _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                            _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(dt.Rows[i]["EMPID"]);
                            _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(RCB_AppraisalCycle.SelectedItem.Value);//Convert.ToInt32(dtappidzz.Rows[0]["APPRCYCLE_ID"]);

                            _obj_Spms_Appraisal.Mode = 5;

                            DataTable dtgoal4 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                            if (dtgoal4.Rows.Count != 0)
                            {
                                _obj_Spms_Appraisal.APPRAISAL_ID = Convert.ToInt32(dtgoal4.Rows[0]["APPRAISAL_ID"]);
                            }

                            //_obj_Spms_AppraisalKra.APP_KRA_FIXED = 1;
                            _obj_Spms_Appraisal.EMPID = Convert.ToInt32(dt.Rows[i]["EMPID"]);
                            _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Spms_Appraisal.Mode = 4;
                            if (Convert.ToString(Pms_Bll.get_EmpRatingDetails(_obj_Spms_Appraisal).Rows[0]["Count"]) == "0")
                            {
                                ImageButton imge41 = new ImageButton();
                                imge41 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight4") as ImageButton;
                                imge41.Visible = false;
                                imge41.ToolTip = GROUP_MANAGER;

                                ImageButton imge441 = new ImageButton();
                                imge441 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight44") as ImageButton;
                                imge441.Visible = true;
                                imge441.ToolTip = GROUP_MANAGER;
                            }
                            else
                            {
                                ImageButton imge4 = new ImageButton();
                                imge4 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight4") as ImageButton;
                                imge4.Visible = true;
                                imge4.ToolTip = GROUP_MANAGER;

                                ImageButton imge44 = new ImageButton();
                                imge44 = RG_AppraisalStatus.Items[i].FindControl("IB_Reight44") as ImageButton;
                                imge44.Visible = false;
                                imge44.ToolTip = GROUP_MANAGER;
                            }
                        }
                    }
                }

                else
                {
                    DataTable dt1 = new DataTable();
                    RG_AppraisalStatus.DataSource = dt1;
                    RG_AppraisalStatus.DataBind();
                }

                //RadRating rdrtgpotential = new Telerik.Web.UI.RadRating();
                //RadRating rdrtgbusiness = new Telerik.Web.UI.RadRating();
                //RadRating txtfinal = new Telerik.Web.UI.RadRating();
                RadNumericTextBox txtfinal = new Telerik.Web.UI.RadNumericTextBox();
                RadNumericTextBox rdrtgpotential = new Telerik.Web.UI.RadNumericTextBox();
                RadNumericTextBox rdrtgbusiness = new Telerik.Web.UI.RadNumericTextBox();
                Button btngenerate = new Button();
                CheckBox chk = new CheckBox();
                _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                _obj_Pms_Appraisalcycle.MODE = 8;
                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(RCB_BusinessUnit.SelectedValue);
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtappidzz1 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                if (dtappidzz1.Rows.Count != 0)
                {
                    _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                    _obj_Spms_Appraisal.APPRAISAL_BUSSINESS_UNIT = Convert.ToInt32(RCB_BusinessUnit.SelectedValue);
                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(RCB_AppraisalCycle.SelectedItem.Value);//Convert.ToInt32(dtappidzz1.Rows[0]["APPRCYCLE_ID"]);
                    _obj_Spms_Appraisal.Mode = 19;
                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dt10 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                    if (dt10.Rows.Count != 0)
                    {
                        for (int l = 0; l < dt10.Rows.Count; l++)
                        {
                            //int k = RG_AppraisalStatus.Items.Count - 1;
                            //rdrtgpotential = RG_AppraisalStatus.Items[l].FindControl("rdrtg_potential") as RadNumericTextBox;
                            //rdrtgbusiness = RG_AppraisalStatus.Items[l].FindControl("rdrtg_business") as RadNumericTextBox;
                            //btngenerate = RG_AppraisalStatus.Items[l].FindControl("btn_generat") as Button;
                            chk = RG_AppraisalStatus.Items[l].FindControl("chk") as CheckBox;
                            //btngenerate.Enabled = false;
                            //rdrtgpotential.Value = Convert.ToDouble(dt10.Rows[l]["app_potentialrtg"]);
                            //rdrtgbusiness.Value = Convert.ToDouble(dt10.Rows[l]["app_businessrtg"]);
                            //rdrtgbusiness.Enabled = false;
                            //rdrtgpotential.Enabled = false;
                            //btngenerate.Text = Convert.ToString(dt10.Rows[l]["app_overallrtg"]);
                            chk.Visible = false;
                        }
                    }
                }

            }

            else
            {
                Pms_Bll.ShowMessage(this, "Busineeunit Has No Active AppraisalCycle");
                return;
            }

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AppraisalStatus", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region generate grade method

    protected void btn_genrate_command(object sender, CommandEventArgs e)
    {

        try
        {
            //RadRating rdrtgpotential = new Telerik.Web.UI.RadRating();
            //RadRating rdrtgbusiness = new Telerik.Web.UI.RadRating();
            //RadRating txtfinal = new Telerik.Web.UI.RadRating();
            //RadNumericTextBox txtfinal = new Telerik.Web.UI.RadNumericTextBox();
            RadNumericTextBox rdrtgpotential = new Telerik.Web.UI.RadNumericTextBox();
            RadNumericTextBox rdrtgbusiness = new Telerik.Web.UI.RadNumericTextBox();
            Button btngenerate = new Button();
            int i = Convert.ToInt32(e.CommandArgument);
            string txtfinal = Convert.ToString(RG_AppraisalStatus.Items[i]["FINAL_RATING"].Text);// RG_AppraisalStatus.Items[i].FindControl("rdrtg_final") as RadNumericTextBox;
            decimal s = Convert.ToDecimal(txtfinal);
            rdrtgpotential = RG_AppraisalStatus.Items[i].FindControl("rdrtg_potential") as RadNumericTextBox;
            rdrtgbusiness = RG_AppraisalStatus.Items[i].FindControl("rdrtg_business") as RadNumericTextBox;
            btngenerate = RG_AppraisalStatus.Items[i].FindControl("btn_generat") as Button;
            decimal m = Convert.ToDecimal(rdrtgpotential.Value);
            decimal k = Convert.ToDecimal(rdrtgbusiness.Value);
            Label lblgrade = new System.Web.UI.WebControls.Label();
            lblgrade = RG_AppraisalStatus.Items[i].FindControl("lbl_grade") as Label;
            lblgrade.Text = Convert.ToString((Convert.ToDecimal(s * m * k)));

            string o = lblgrade.Text;
            if (Convert.ToDecimal(o) <= 45)
            {
                lblgrade.Text = "C";
                btn_save.Visible = true;
                lblgrade.Visible = true;
                btngenerate.Visible = false;
                rdrtgpotential.Enabled = false;
                rdrtgbusiness.Enabled = false;


            }

            else if ((Convert.ToDecimal(o) > 45) && (Convert.ToDecimal(o) < 80))
            {
                lblgrade.Text = "B";
                btn_save.Visible = true;
                lblgrade.Visible = true;
                btngenerate.Visible = false;
                rdrtgpotential.Enabled = false;
                rdrtgbusiness.Enabled = false;
            }
            else
            {
                lblgrade.Text = "A";
                btn_save.Visible = true;
                lblgrade.Visible = true;
                btngenerate.Visible = false;
                rdrtgpotential.Enabled = false;
                rdrtgbusiness.Enabled = false;
            }

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AppraisalStatus", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void imagevisible1()
    {

    }

    #endregion

    #region save clik

    protected void btn_save_Click(object sender, EventArgs e)
    {
        try
        {

            //RadRating rdrtgpotential = new Telerik.Web.UI.RadRating();
            //RadRating rdrtgbusiness = new Telerik.Web.UI.RadRating();
            //RadRating txtfinal = new Telerik.Web.UI.RadRating();
            //RadNumericTextBox txtfinal = new Telerik.Web.UI.RadNumericTextBox();
            string txtfinal = string.Empty;
            RadNumericTextBox rdrtgpotential = new Telerik.Web.UI.RadNumericTextBox();
            RadNumericTextBox rdrtgbusiness = new Telerik.Web.UI.RadNumericTextBox();

            Label lbloverall = new System.Web.UI.WebControls.Label();
            CheckBox chk = new CheckBox();
            Label lblempid = new System.Web.UI.WebControls.Label();
            Button btngenerate = new Button();
            //int u = RG_AppraisalStatus.Items.Count;
            //if (u < 0)
            //{
            string chk_emp = string.Empty;
            chk_emp = "false";
            for (int o = 0; o <= RG_AppraisalStatus.Items.Count - 1; o++)
            {
                CheckBox chk1 = new CheckBox();
                chk1 = RG_AppraisalStatus.Items[o].FindControl("chk") as CheckBox;
                if (chk1.Checked)
                {
                    chk_emp = "true";
                }

            }
            if (chk_emp == "false")
            {
                Pms_Bll.ShowMessage(this, "Please Select Record");
                return;
            }


            for (int i = 0; i <= RG_AppraisalStatus.Items.Count - 1; i++)
            {
                chk = RG_AppraisalStatus.Items[i].FindControl("chk") as CheckBox;
                //rdrtgpotential = RG_AppraisalStatus.Items[i].FindControl("rdrtg_potential") as RadNumericTextBox;
                //rdrtgbusiness = RG_AppraisalStatus.Items[i].FindControl("rdrtg_business") as RadNumericTextBox;
                txtfinal = Convert.ToString(RG_AppraisalStatus.Items[i]["FINAL_RATING"].Text);//RG_AppraisalStatus.Items[i].FindControl("rdrtg_final") as RadNumericTextBox;
                lbloverall = RG_AppraisalStatus.Items[i].FindControl("lbl_grade") as Label;
                lblempid = RG_AppraisalStatus.Items[i].FindControl("lbl_empid") as Label;
                btngenerate = RG_AppraisalStatus.Items[i].FindControl("btn_generat") as Button;
                if (chk.Checked)
                {
                    _obj_Pms_AppStatus = new SPMS_APRAISALSTATUS();
                    _obj_Pms_AppStatus.Mode = 3;
                    _obj_Pms_AppStatus.APP_EMP_ID = Convert.ToInt32(lblempid.Text);
                    _obj_Pms_AppStatus.APP_FINALRTG = Convert.ToDecimal(txtfinal);
                    //_obj_Pms_AppStatus.APP_POTENTIALRTG = Convert.ToDecimal(rdrtgpotential.Value);
                    // _obj_Pms_AppStatus.APP_BUSINEESRTG = Convert.ToDecimal(rdrtgbusiness.Value);
                    _obj_Pms_AppStatus.APP_STATUS_APPRAISALCYCLE = Convert.ToInt32(RCB_AppraisalCycle.SelectedItem.Value);
                    // _obj_Pms_AppStatus.APP_OVERALLRTG = Convert.ToString(lbloverall.Text);
                    _obj_Pms_AppStatus.APP_STATUS_ORG_ID = Convert.ToInt32(Session["org_id"]);
                    _obj_Pms_AppStatus.APP_STATUS = 1;
                    _obj_Pms_AppStatus.APP_CREATEDBY = Convert.ToInt32(Session["user_id"]);
                    _obj_Pms_AppStatus.APP_CREATEDDATE = DateTime.Now;
                    bool status1 = Pms_Bll.set_AppStatus(_obj_Pms_AppStatus);
                    if (status1 == true)
                    {
                        _obj_Pms_AppDiscDtls = new SPMS_APRAISALDISCUSSION();
                        _obj_Pms_AppDiscDtls.Mode = 9;
                        _obj_Pms_AppDiscDtls.APP_DISCUSSION_ORG_ID = Convert.ToInt32(Session["org_id"]);
                        DataTable dtemployee223 = Pms_Bll.get_AppDiscDtls(_obj_Pms_AppDiscDtls);

                        _obj_Pms_AppStatus = new SPMS_APRAISALSTATUS();
                        _obj_Pms_AppStatus.Mode = 2;
                        _obj_Pms_AppStatus.APP_EMP_ID = Convert.ToInt32(lblempid.Text);
                        _obj_Pms_AppStatus.APP_STATUS_ORG_ID = Convert.ToInt32(Session["org_id"]);
                        DataTable dtappstt = Pms_Bll.get_AppStatus(_obj_Pms_AppStatus);


                        _obj_Pms_AppDiscDtls.Mode = 6;
                        _obj_Pms_AppDiscDtls.APP_DISCUSSION_LASTMDFBY = Convert.ToInt32(lblempid.Text);
                        _obj_Pms_AppDiscDtls.APP_DISCUSSION_ORG_ID = Convert.ToInt32(Session["org_id"]);
                        DataTable dtemployee22 = Pms_Bll.get_AppDiscDtls(_obj_Pms_AppDiscDtls);
                        //aaa
                        //TO SEND MAIL TO EMPLOYEE, COMMNETED ON 21.09.2012
                        //if (dtemployee22.Rows.Count != 0)
                        //{
                        //    Dal.ExecuteNonQuery("EXEC USP_SEND_EMAIL_PMS_APPRAISALstatus @hr_name='" + Convert.ToString("HR") + "',@EMPLOYEE='" + Convert.ToString(dtemployee22.Rows[0]["employeename"]) + "',@EMPLOYEEmail='" + Convert.ToString(dtemployee22.Rows[0]["employee_EMAILID"]) + "',@APP_OVERALLRTG='" + Convert.ToString(dtappstt.Rows[0]["APP_OVERALLRTG"]) + "',@APP_BUSINEESRTG='" + Convert.ToString(dtappstt.Rows[0]["APP_BUSINEESRTG"]) + "',@APP_POTENTIALRTG='" + Convert.ToString(dtappstt.Rows[0]["APP_POTENTIALRTG"]) + "',@APP_FINALRTG='" + Convert.ToString(dtappstt.Rows[0]["APP_FINALRTG"]) + "'");



                        //}

                        _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                        _obj_Pms_Appraisalcycle.MODE = 11;
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(lblempid.Text);//where i am passing employee to get bunit
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtemzz01F = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                        _obj_Pms_Appraisalcycle.MODE = 8;
                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz01F.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtappidzz1F = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                        _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                        _obj_Spms_Appraisal.Mode = 28;
                        _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(lblempid.Text);
                        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(RCB_AppraisalCycle.SelectedItem.Value);//Convert.ToInt32(dtappidzz1F.Rows[0]["APPRCYCLE_ID"]);
                        _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        bool status2 = Pms_Bll.set_Appraisal(_obj_Spms_Appraisal);
                        if (status2 == true)
                        {






                            //_obj_Pms_AppStatus = new SPMS_APRAISALSTATUS();
                            //_obj_Pms_AppStatus.Mode = 5;
                            //_obj_Pms_AppStatus.APP_EMP_ID = Convert.ToInt32(lblempid.Text);
                            //DataTable dt = Pms_Bll.get_AppStatus(_obj_Pms_AppStatus);

                            //if (dt.Rows.Count != 0)
                            //{
                            //    btn_finalise.Visible = true;

                            //}
                        }
                    }


                }
                else
                {
                    //Pms_Bll.ShowMessage(this, "Please Select Record");

                    //btngenerate.Visible = true;
                    //lbloverall.Visible = false;
                    //RG_AppraisalStatus.Visible = true;

                }
            }
            Pms_Bll.ShowMessage(this, "Status Saved Successfully");
            //Pms_Bll.ShowMessage(this, "Notification Send");
            loadBusinessUnit();
            // RCB_AppraisalCycle.Items.Clear(); 
            btn_save.Visible = false;
            btn_finalise.Visible = false;
            //RG_AppraisalStatus.Visible = false;
            RG_AppraisalStatus.Visible = false;
            //rcmb_status.Visible = false;
            //lbl_status.Visible = false;
            tr_status.Visible = false;
            ///added by aravinda
            //lbl_AppraisalCycle.Visible = false;
            //RCB_AppraisalCycle.Visible = false; 
            //DataTable dt5 = new DataTable();
            //RCB_AppraisalCycle.DataSource = dt5;
            //RCB_AppraisalCycle.DataBind();
            RM_AppraisalStatus.SelectedIndex = 0;
            RCB_AppraisalCycle.ClearSelection();
            RCB_AppraisalCycle.Items.Clear();
            RCB_AppraisalCycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));


        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AppraisalStatus", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }




    }
    protected void btn_finalise_Click(object sender, EventArgs e)
    {
        //RadRating rdrtgpotential = new Telerik.Web.UI.RadRating();
        //RadRating rdrtgbusiness = new Telerik.Web.UI.RadRating();
        //RadNumericTextBox txtfinal = new Telerik.Web.UI.RadNumericTextBox();
        //Label lbloverall = new System.Web.UI.WebControls.Label();
        //CheckBox chk = new CheckBox();
        //Label lblempid = new System.Web.UI.WebControls.Label();

        //for (int i = 0; i <= RG_AppraisalStatus.Items.Count - 1; i++)
        //{
        //    chk = RG_AppraisalStatus.Items[i].FindControl("chk") as CheckBox;
        //    rdrtgpotential = RG_AppraisalStatus.Items[i].FindControl("rdrtg_potential") as RadRating;
        //    rdrtgbusiness = RG_AppraisalStatus.Items[i].FindControl("rdrtg_business") as RadRating;
        //    txtfinal = RG_AppraisalStatus.Items[i].FindControl("rnt_finalrtg") as RadNumericTextBox;
        //    lbloverall = RG_AppraisalStatus.Items[i].FindControl("lbl_grade") as Label;
        //    lblempid = RG_AppraisalStatus.Items[i].FindControl("lbl_empid") as Label;

        //    if (chk.Checked)
        //    {
        //        _obj_Pms_AppStatus = new SPMS_APRAISALSTATUS();
        //        _obj_Pms_AppStatus.Mode = 3;
        //        _obj_Pms_AppStatus.APP_EMP_ID = Convert.ToInt32(lblempid.Text);
        //        _obj_Pms_AppStatus.APP_FINALRTG = Convert.ToInt32(txtfinal.Value);
        //        _obj_Pms_AppStatus.APP_POTENTIALRTG = Convert.ToInt32(rdrtgpotential.Value);
        //        _obj_Pms_AppStatus.APP_BUSINEESRTG = Convert.ToInt32(rdrtgbusiness.Value);
        //        _obj_Pms_AppStatus.APP_OVERALLRTG = Convert.ToString(lbloverall.Text);
        //        _obj_Pms_AppStatus.APP_STATUS = 2;
        //        _obj_Pms_AppStatus.APP_CREATEDBY = 1;
        //        _obj_Pms_AppStatus.APP_CREATEDDATE = DateTime.Now;
        //        bool status1 = Pms_Bll.set_AppStatus(_obj_Pms_AppStatus);
        //        if (status1 == true)
        //        {
        //            Pms_Bll.ShowMessage(this, "Appraisal Status Inserted Successfully");


        //        }

        //    }


        //}

    }
    #endregion

    #region status changed event
    protected void rcmb_status_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if ((rcmb_status.SelectedItem.Text == "Completed"))
            {
                loadgrid();

                RG_AppraisalStatus.Visible = true;
                btn_save.Visible = true;
                btn_finalise.Visible = false;
                btn_save.Visible = false;
            }
            else if ((rcmb_status.SelectedItem.Text == "NotCompleted"))
            {

                loadgrid1();
                RG_AppraisalStatus.Visible = true;
                btn_save.Visible = true;
                btn_finalise.Visible = false;
                //btn_save.Visible = false;

                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    RG_AppraisalStatus.Enabled = false;
                }
                else
                {
                    RG_AppraisalStatus.Enabled = true;
                }
            }
            else
            {
                Pms_Bll.ShowMessage(this, "Please Select Status");

                RG_AppraisalStatus.Visible = false;
                btn_save.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AppraisalStatus", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion
}