using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SPMS;
using SMHR;

public partial class PMS_frm_CopyKRA : System.Web.UI.Page
{
    PMS_Appraisalcycle _obj_Pms_Appraisalcycle;
    PMS_GoalSettings _obj_GS;
    GOALSETTING_GOALKRA_DETAILS _obj_Pms_goalkradetails;
    GOALSETTING_IDP_DETAILS _obj_Pms_goalIDPdetails;
    PMS_GoalSettings_Details _obj_GSdetails;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                LoadAppraisalCycle();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CopyKRA", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadAppraisalCycle()
    {
        try
        {
            rcmb_AppCycle.Items.Clear();
            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            _obj_Pms_Appraisalcycle.MODE = 15;
            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(Convert.ToString(Request.QueryString["APPCYCLE_ID"]));
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT_AppraisalCycle = new DataTable();
            DT_AppraisalCycle = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
            rcmb_AppCycle.DataSource = DT_AppraisalCycle;
            rcmb_AppCycle.DataTextField = "APPRCYCLE_NAME";
            rcmb_AppCycle.DataValueField = "APPRCYCLE_ID";
            rcmb_AppCycle.DataBind();
            rcmb_AppCycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CopyKRA", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_AppCycle_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_AppCycle.SelectedIndex > 0)
            {
                LoadGrid();
                Rg_CopyKRA.DataBind();
                if (Rg_CopyKRA.Items.Count == 0)
                {
                    BLL.ShowMessage(this, "No Records to Display.");
                    btn_Copy.Visible = false;
                }
                else
                {
                    btn_Copy.Visible = true;
                }
                Rg_CopyKRA.Visible = true;
            }
            else
            {
                DataTable dt = new DataTable();
                Rg_CopyKRA.DataSource = dt;
                Rg_CopyKRA.DataBind();
                btn_Copy.Visible = false;
                Rg_CopyKRA.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CopyKRA", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadGrid()
    {
        try
        {
            _obj_GS = new PMS_GoalSettings();
            _obj_GS.GS_MODE = 34;
            _obj_GS.GS_APPRAISAL_CYCLE = Convert.ToString(Request.QueryString["APPCYCLE_ID"]);
            _obj_GS.BUID = Convert.ToInt32(rcmb_AppCycle.SelectedItem.Value);
            _obj_GS.GS_EMP_ID = Convert.ToInt32(Convert.ToString(Request.QueryString["EMP_ID"]));
            DataTable dt_details = Pms_Bll.get_GS(_obj_GS);
            Rg_CopyKRA.DataSource = dt_details;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CopyKRA", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void chk_selectall_checkedchanged(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < Rg_CopyKRA.Items.Count; i++)
            {
                CheckBox Chk_All = (CheckBox)sender;
                if (Chk_All.Checked)
                {
                    for (int index = 0; index < Rg_CopyKRA.Items.Count; index++)
                    {
                        CheckBox c = (CheckBox)Rg_CopyKRA.Items[index].FindControl("chckbtn_Select");
                        c.Checked = true; ;
                    }
                }
                else
                {
                    for (int index = 0; index < Rg_CopyKRA.Items.Count; index++)
                    {
                        CheckBox c = (CheckBox)Rg_CopyKRA.Items[index].FindControl("chckbtn_Select");
                        c.Checked = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CopyKRA", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Copy_Click(object sender, EventArgs e)
    {
        try
        {
            bool status = false;
            _obj_GS = new PMS_GoalSettings();
            _obj_Pms_goalkradetails = new GOALSETTING_GOALKRA_DETAILS();
            _obj_Pms_goalIDPdetails = new GOALSETTING_IDP_DETAILS();
            _obj_GSdetails=new PMS_GoalSettings_Details();
            int count = 0;
            for (int index = 0; index < Rg_CopyKRA.Items.Count; index++)
            {
                CheckBox chk = Rg_CopyKRA.Items[index].FindControl("chckbtn_Select") as CheckBox;
                if (chk.Checked)
                {
                    count++;
                    if (Rg_CopyKRA.Items[index]["A"].Text == "KRA")
                    {
                        _obj_Pms_goalkradetails.GS_KRA_KRA_ID = Convert.ToInt32(Rg_CopyKRA.Items[index]["ROLEKRA_ID"].Text);
                        _obj_Pms_goalkradetails.APPCYCLE = Convert.ToInt32(rcmb_AppCycle.SelectedItem.Value);
                        _obj_Pms_goalkradetails.BUID = Convert.ToInt32(Convert.ToString(Request.QueryString["APPCYCLE_ID"]));
                        _obj_Pms_goalkradetails.EMP_ID = Convert.ToInt32(Convert.ToString(Request.QueryString["EMP_ID"]));
                        _obj_Pms_goalkradetails.MODE = 13;
                        status = Pms_Bll.set_Gskra(_obj_Pms_goalkradetails);
                    }
                    else if (Rg_CopyKRA.Items[index]["A"].Text == "IDP")
                    {
                        _obj_Pms_goalIDPdetails.GS_IDP_IDP_ID = Convert.ToInt32(Rg_CopyKRA.Items[index]["ROLEKRA_ID"].Text);
                        _obj_Pms_goalIDPdetails.APPCYCLE = Convert.ToInt32(rcmb_AppCycle.SelectedItem.Value);
                        _obj_Pms_goalIDPdetails.BUID = Convert.ToInt32(Convert.ToString(Request.QueryString["APPCYCLE_ID"]));
                        _obj_Pms_goalIDPdetails.EMP_ID = Convert.ToInt32(Convert.ToString(Request.QueryString["EMP_ID"]));
                        _obj_Pms_goalIDPdetails.MODE = 13;
                        status = Pms_Bll.set_GsIDP(_obj_Pms_goalIDPdetails);
                    }
                    else
                    {
                        _obj_GSdetails.GSDTL_ID = Convert.ToInt32(Rg_CopyKRA.Items[index]["ROLEKRA_ID"].Text);
                        _obj_GSdetails.APPCYCLE = Convert.ToInt32(rcmb_AppCycle.SelectedItem.Value);
                        _obj_GSdetails.BUID = Convert.ToInt32(Convert.ToString(Request.QueryString["APPCYCLE_ID"]));
                        _obj_GSdetails.EMP_ID = Convert.ToInt32(Convert.ToString(Request.QueryString["EMP_ID"]));
                        _obj_GSdetails.GS_DETAILS_MODE = 15;
                        status = Pms_Bll.set_GSdetails(_obj_GSdetails);
                    }
                }
            }
            if (count == 0)
            {
                BLL.ShowMessage(this, "Please Select Atleast one KRA to Copy");
                return;
            }
            if (status)
            {
                LoadGrid();
                Rg_CopyKRA.DataBind();
                if (Rg_CopyKRA.Items.Count == 0)
                {
                    btn_Copy.Visible = false;
                }
                else
                {
                    btn_Copy.Visible = true;
                }
                BLL.ShowMessage(this, "Selected KRAs Copied Successfully.");
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Guid.NewGuid().ToString(), "refreshOpener();", true);
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CopyKRA", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            Rg_CopyKRA.Visible = false;
            rcmb_AppCycle.SelectedIndex = 0;
            btn_Copy.Visible = false;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Guid.NewGuid().ToString(), "refreshOpener();", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CopyKRA", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rg_CopyKRA_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            if (rcmb_AppCycle.SelectedIndex > 0)
            {
                LoadGrid();
                if (Rg_CopyKRA.Items.Count == 0)
                    BLL.ShowMessage(this, "No Records to Display.");
            }
            else
            {
                DataTable dt = new DataTable();
                Rg_CopyKRA.DataSource = dt;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CopyKRA", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
