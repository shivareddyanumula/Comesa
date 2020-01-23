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

public partial class PMS_frm_Pms_ViewFeedBack : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
                //int KRAID = Request.QueryString["KRA_ID"] != null ? Convert.ToInt32(Request.QueryString["KRA_ID"]) : 0;
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_ViewFeedBack", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadGrid()
    {
        try
        {

            //string type = Convert.ToString(RG_All.Items[index]["A"].Text).Trim();
            //Label lblid = new Label();
            //lblid = RG_All.Items[index].FindControl("lbl_type") as Label;
            SPMS_PERIODICFEEDBACK _obj_Pms_PeriodicFeedback = new SPMS_PERIODICFEEDBACK();
            _obj_Pms_PeriodicFeedback.PF_PM_ID = Convert.ToInt32(Session["TYPE"]);
            _obj_Pms_PeriodicFeedback.Mode = 5;
            //_obj_Pms_PeriodicFeedback.PF_PM_ID = Convert.ToInt32(rcmb_feedback.SelectedItem.Value);
            _obj_Pms_PeriodicFeedback.PF_EMP_ID = Convert.ToInt32( Session["empid1"]);
            _obj_Pms_PeriodicFeedback.PF_TASK_ID = Convert.ToInt32(Session["rolekarid"]);
            _obj_Pms_PeriodicFeedback.PF_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Pms_PeriodicFeedback.GSLIFECYCLE = Convert.ToInt32(Session["APPCYCLE_ID"]);
            DataTable dttask = Pms_Bll.get_PeriodicFeedback(_obj_Pms_PeriodicFeedback);
            RG_ViewFeedBack.DataSource = dttask;
            RG_ViewFeedBack.DataBind();

            Session.Remove("rolekarid");
            Session.Remove("empid1");
            Session.Remove("APPCYCLE_ID");
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_ViewFeedBack", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void RG_ViewFeedBack_ItemDataBound(object sender, GridItemEventArgs e)
    {
        try
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;

                if (item["KRA_Name"].Text == "&nbsp;")
                {
                    if (RG_ViewFeedBack.Columns.Count > 0)
                        RG_ViewFeedBack.Columns[0].Visible = false;
                }
                else
                {
                    if (RG_ViewFeedBack.Columns.Count > 0)
                        RG_ViewFeedBack.Columns[0].Visible = true;
                }

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_ViewFeedBack", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
