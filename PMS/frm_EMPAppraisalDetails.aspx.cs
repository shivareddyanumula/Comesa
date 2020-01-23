using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;
using System.Data.SqlClient;
using SPMS;
using SMHR;

public partial class PMS_frm_EMPAppraisalDetails : System.Web.UI.Page
{
    PMS_EMPSETUP _obj_pms_EmployeeSetup;
    PMS_Appraisalcycle _obj_Pms_Appraisalcycle;
    PMS_GoalSettings _obj_GS;
    SPMS_EMPGOALSETTING _obj_Pms_EmpGoalSetting;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
            if (!Page.IsPostBack)
            {
                LoadGrid();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EMPAppraisalDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadGrid()
    {
        try
        {
            _obj_pms_EmployeeSetup = new PMS_EMPSETUP();
            _obj_pms_EmployeeSetup.EMP_ID = Convert.ToInt32(Convert.ToString(Request.QueryString["EMP_ID"]));
            _obj_pms_EmployeeSetup.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtbuid1 = Pms_Bll.get_LoginInfo(_obj_pms_EmployeeSetup);
            if (dtbuid1.Rows.Count != 0)
            {
                lbl_RPMgr_Name.Text = Convert.ToString(dtbuid1.Rows[0]["REPORTINGMANAGER"]);
                lbl_ApprMgr_Name.Text = Convert.ToString(dtbuid1.Rows[0]["APPROVALMANAGER"]);

                _obj_GS = new PMS_GoalSettings();
                _obj_GS.GS_MODE = 9;
                _obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_GS.GS_EMP_ID = Convert.ToInt32(Convert.ToString(Request.QueryString["EMP_ID"]));
                _obj_GS.GS_APPRAISAL_CYCLE = Convert.ToString(Request.QueryString["APPCYCLE_ID"]);//Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
                DataTable dt1 = Pms_Bll.get_GS(_obj_GS);
                if (dt1.Rows.Count != 0)
                {
                    lbl_Role_Name.Text = Convert.ToString(dt1.Rows[0]["ROLE_NAMES"]);
                    //lbl_Project_Name.Text = Convert.ToString(dt1.Rows[0]["PROJECT_NAME"]);
                }
            }
            //TO GET SELFAPPRAISAL FOR THE APPRAISAL CYCLE ENABLE OR NOT,18.09.2012
            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            _obj_Pms_Appraisalcycle.MODE = 2;
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(Convert.ToString(Request.QueryString["APPCYCLE_ID"]));
            DataTable DT = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
            if (DT.Rows.Count > 0)
            {
                if (DT.Rows[0]["APPRCYCLE_SELFAPPRAISAL"] != System.DBNull.Value)
                {
                    if (Convert.ToBoolean(DT.Rows[0]["APPRCYCLE_SELFAPPRAISAL"]) == true)
                    {
                        //RG_EmpAppraisalDetails.Columns[6].Visible = true;
                        //RG_EmpAppraisalDetails.Columns[7].Visible = true;
                        RG_EmpAppraisalDetails.Columns[4].Visible = true;
                    }
                    else
                    {
                        //RG_EmpAppraisalDetails.Columns[6].Visible = false;
                        //RG_EmpAppraisalDetails.Columns[7].Visible = false;
                        RG_EmpAppraisalDetails.Columns[4].Visible = false;
                    }
                }
            }

            //TO LOAD THE GRID
            _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
            _obj_Pms_EmpGoalSetting.Mode = 8;
            _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(Convert.ToString(Request.QueryString["EMP_ID"]));
            _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(Request.QueryString["APPCYCLE_ID"]); //Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
            _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
            _obj_GS = new PMS_GoalSettings();
            DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
            if (dt.Rows.Count != 0)
                _obj_GS.GS_ID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
            else
                _obj_GS.GS_ID = 0;
            if (Convert.ToString(Request.QueryString["STR"].Trim()) == "GS_APPROVAL")
            {
                _obj_GS.GS_MODE = 33;
                //RG_EmpAppraisalDetails.Columns[6].Visible = false;
                //RG_EmpAppraisalDetails.Columns[7].Visible = false;
                //RG_EmpAppraisalDetails.Columns[8].Visible = false;
                //RG_EmpAppraisalDetails.Columns[9].Visible = false;
                RG_EmpAppraisalDetails.Columns[4].Visible = false;
                RG_EmpAppraisalDetails.Columns[5].Visible = false;
                RG_EmpAppraisalDetails.Columns[6].Visible = false;

            }
            else
            {
                _obj_GS.GS_MODE = 37;
                RG_EmpAppraisalDetails.Columns[2].Visible = false;
                RG_EmpAppraisalDetails.Columns[3].Visible = false;
                //RG_EmpAppraisalDetails.Columns[4].Visible = false;
                //RG_EmpAppraisalDetails.Columns[5].Visible = false;
            }

            _obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //_obj_GS.GS_ID = Convert.ToInt32(Session["GSID"]);
            DataTable dt_details = new DataTable();
            dt_details = Pms_Bll.get_GS(_obj_GS);
            if (dt_details.Rows.Count > 0)
            {
                RG_EmpAppraisalDetails.DataSource = dt_details;
                RG_EmpAppraisalDetails.DataBind();
            }
            else
            {
                RG_EmpAppraisalDetails.DataSource = dt_details;
                RG_EmpAppraisalDetails.DataBind();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EMPAppraisalDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
