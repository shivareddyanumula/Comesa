using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using SMHR;
using Telerik.Web.UI;

public partial class Approval_frm_PastInspections : System.Web.UI.Page
{
    SMHR_INSPECTION_SCHEDULE _obj_smhr_inspection_schedule;
    DataTable dtInspectionGrid;
    static int empID;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            rdtp_FromDate.MaxDate = DateTime.Now;
            rdtp_ToDate.SelectedDate = DateTime.Now;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PastInspections", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Generate_Click(object sender, EventArgs e)
    {
        try
        {
            if ((rdtp_FromDate.SelectedDate != null) && (rdtp_ToDate.SelectedDate != null))
            {
                Rg_Areas_To_Inspected.Visible = true;
                LoadGrid();
            }
            else
            {
                if (rdtp_FromDate.SelectedDate == null)
                {
                    BLL.ShowMessage(this, "Please Select From Date");
                    rdtp_FromDate.Focus();
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PastInspections", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadGrid()
    {
        try
        {
            _obj_smhr_inspection_schedule = new SMHR_INSPECTION_SCHEDULE();
            dtInspectionGrid = new DataTable();

            _obj_smhr_inspection_schedule.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            if (rdtp_FromDate.SelectedDate != null)
                _obj_smhr_inspection_schedule.INSPECTION_SCHEDULE_FROMDATE = Convert.ToDateTime(rdtp_FromDate.SelectedDate);
            else
            {
                BLL.ShowMessage(this, "Please Select From Date");
                rdtp_FromDate.Focus();
            }

            if (rdtp_ToDate.SelectedDate != null)
                _obj_smhr_inspection_schedule.INSPECTION_SCHEDULE_TODATE = Convert.ToDateTime(rdtp_ToDate.SelectedDate);
            else
            {
                BLL.ShowMessage(this, "Please Select To Date");
                rdtp_ToDate.Focus();
            }

            empID = Convert.ToInt32(Session["EMP_ID"]);

            if ((empID != 0) && ((rdtp_FromDate.SelectedDate != null)) && ((rdtp_ToDate.SelectedDate != null)))
            {
                dtInspectionGrid = BLL.Get_Past_Inspection_Data(_obj_smhr_inspection_schedule, empID);
            }
            else
            {
                BLL.ShowMessage(this, "There is No Employee to show Records..");
                return;
            }

            Rg_Areas_To_Inspected.DataSource = dtInspectionGrid;
            Rg_Areas_To_Inspected.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PastInspections", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            Rg_Areas_To_Inspected.Visible = false;
            rdtp_FromDate.Clear();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PastInspections", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rg_Areas_To_Inspected_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            _obj_smhr_inspection_schedule = new SMHR_INSPECTION_SCHEDULE();
            dtInspectionGrid = new DataTable();

            _obj_smhr_inspection_schedule.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            if (rdtp_FromDate.SelectedDate != null)
                _obj_smhr_inspection_schedule.INSPECTION_SCHEDULE_FROMDATE = Convert.ToDateTime(rdtp_FromDate.SelectedDate);
            else
            {
                BLL.ShowMessage(this, "Please Select From Date");
                rdtp_FromDate.Focus();
            }

            if (rdtp_ToDate.SelectedDate != null)
                _obj_smhr_inspection_schedule.INSPECTION_SCHEDULE_TODATE = Convert.ToDateTime(rdtp_ToDate.SelectedDate);
            else
            {
                BLL.ShowMessage(this, "Please Select To Date");
                rdtp_ToDate.Focus();
            }

            empID = Convert.ToInt32(Session["EMP_ID"]);

            if ((empID != 0) && ((rdtp_FromDate.SelectedDate != null)) && ((rdtp_ToDate.SelectedDate != null)))
            {
                dtInspectionGrid = BLL.Get_Past_Inspection_Data(_obj_smhr_inspection_schedule, empID);
            }
            else
            {
                BLL.ShowMessage(this, "There is No Employee to show Records..");
                return;
            }

            Rg_Areas_To_Inspected.DataSource = dtInspectionGrid;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PastInspections", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rg_Areas_To_Inspected_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        try
        {
            Label lbl_IsCompliant;
            Label lbl_ItemComments;
            RadTextBox rad_Comments;
            RadioButtonList rbl_IsCompliant;
            CheckBox chk_Choose;

            for (int index = 0; index <= Rg_Areas_To_Inspected.Items.Count - 1; index++)
            {
                lbl_IsCompliant = Rg_Areas_To_Inspected.Items[index].FindControl("lbl_IsCompliant") as Label;
                lbl_ItemComments = Rg_Areas_To_Inspected.Items[index].FindControl("lbl_ItemComments") as Label;
                rad_Comments = Rg_Areas_To_Inspected.Items[index].FindControl("Comments") as RadTextBox;
                rbl_IsCompliant = Rg_Areas_To_Inspected.Items[index].FindControl("rbl_IsCompliant") as RadioButtonList;
                chk_Choose = Rg_Areas_To_Inspected.Items[index].FindControl("chk_Choose") as CheckBox;
                if (lbl_ItemComments.Text != string.Empty)
                {
                    rad_Comments.Text = lbl_ItemComments.Text;
                }
                if (lbl_IsCompliant.Text != string.Empty)
                {
                    if (Convert.ToBoolean(lbl_IsCompliant.Text) == true)
                        rbl_IsCompliant.SelectedValue = "1";
                    else
                        rbl_IsCompliant.SelectedValue = "0";

                    Rg_Areas_To_Inspected.Items[index].Enabled = false;

                    if ((lbl_ItemComments.Text != string.Empty) && ((rbl_IsCompliant.SelectedValue == "0") || (rbl_IsCompliant.SelectedValue == "1")))
                        chk_Choose.Checked = true;
                    else
                        chk_Choose.Checked = false;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PastInspections", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rdtp_FromDate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        try
        {
            if (rdtp_FromDate.SelectedDate != null)
            {
                rdtp_ToDate.MinDate = Convert.ToDateTime(rdtp_FromDate.SelectedDate);
            }
            else
            {
                BLL.ShowMessage(this, "Please Select From Date");
                rdtp_FromDate.Focus();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PastInspections", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}