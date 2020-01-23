using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;

public partial class Workman_Compensation_frm_IncidentDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //string control = string.Empty;
            if (!Page.IsPostBack)
            {

                if (Request.QueryString.HasKeys())
                {
                    int empID = Convert.ToInt32(Request.QueryString["empID"]);
                    int IncidentID = Convert.ToInt32(Request.QueryString["incID"]);
                    if (empID > 0 && IncidentID > 0)
                    {
                        LoadIncidentsGrid(empID, IncidentID);

                    }
                }
                //control = Convert.ToString(Request.QueryString["Control"]);
                //if (control == "incident")
                //{
                //    LoadIncidentsGrid();
                //}

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IncidentDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadIncidentsGrid(int empID, int IncidentID)
    {
        //To populate incidents which are mapped with employees in radgrid - "RG_Incident"
        try
        {
            SMHR_WorkmanCompensation ObjWrkComp = new SMHR_WorkmanCompensation();
            ObjWrkComp.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            ObjWrkComp.EmpID = Convert.ToInt32(empID);
            ObjWrkComp.IncidentID = Convert.ToInt32(IncidentID);
            ObjWrkComp.OPERATION = operation.EMPDETAILS;
            RG_Incident.DataSource = BLL.GET_SMHR_INCIDENTS(ObjWrkComp).Tables[0];
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IncidentDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadIncidentsGrid()
    {
        //To populate incidents which are mapped with employees in radgrid - "RG_Incident"
        try
        {
            //SMHR_WorkmanCompensation ObjWrkComp = new SMHR_WorkmanCompensation();
            //ObjWrkComp.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            //ObjWrkComp.EmpID = Convert.ToInt32(rcmb_LeaveAppEmployeeID.SelectedValue);
            //ObjWrkComp.IncidentID = Convert.ToInt32(rcmb_IncidentLeave.SelectedValue);
            //ObjWrkComp.OPERATION = operation.EMPDETAILS;
            //RG_Incident.DataSource = BLL.GET_SMHR_INCIDENTS(ObjWrkComp).Tables[0];
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IncidentDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void RG_Incident_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            if (Request.QueryString.HasKeys())
            {
                int empID = Convert.ToInt32(Request.QueryString["empID"]);
                int IncidentID = Convert.ToInt32(Request.QueryString["incID"]);
                if (empID > 0 && IncidentID > 0)
                {
                    LoadIncidentsGrid(empID, IncidentID);

                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IncidentDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}