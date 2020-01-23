using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Data;

public partial class Masters_frmProject : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                SMHR_BUSINESSUNIT businessUnit = new SMHR_BUSINESSUNIT();
                businessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                businessUnit.OPERATION = operation.Select;
                rcmbBusinessUnit.DataSource = BLL.get_BusinessUnit(businessUnit);
                rcmbBusinessUnit.DataValueField = "BUSINESSUNIT_ID";
                rcmbBusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
                rcmbBusinessUnit.DataBind();
                rcmbBusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmProject", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #region Load Grid

    protected void rgProject_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmProject", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void LoadGrid()
    {
        try
        {
            SMHR_PROJECT smhrProject = new SMHR_PROJECT();
            smhrProject.OPERATION = operation.Select;
            smhrProject.PROJECT_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            rgProject.DataSource = BLL.GetProject(smhrProject);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmProject", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


    }

    #endregion

    #region Link Button Events

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            ClearControls();
            rtxt_ProjectCode.Enabled = false;
            SMHR_PROJECT smhrProject = new SMHR_PROJECT();
            smhrProject.PROJECT_ID = Convert.ToInt32(e.CommandArgument);
            DataTable dt = BLL.GetProject(smhrProject);
            lbl_ProjectID.Text = Convert.ToString(dt.Rows[0]["PROJECT_ID"]);
            rtxt_ProjectCode.Text = Convert.ToString(dt.Rows[0]["PROJECT_CODE"]);
            rtxt_ProjectName.Text = Convert.ToString(dt.Rows[0]["PROJECT_NAME"]);
            rtxtProjectDesc.Text = Convert.ToString(dt.Rows[0]["PROJECT_DESC"]);
            rcmbBusinessUnit.SelectedValue = Convert.ToString(dt.Rows[0]["PROJECT_BUSINESSUNIT_ID"]);
            rdpStartDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["PROJECT_STARTDATE"]);
            rdpEndDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["PROJECT_ENDDATE"]);
            rcmbStatus.SelectedValue = Convert.ToString(dt.Rows[0]["PROJECT_ISDELETED"]);
            btn_Update.Visible = true;
            btn_Save.Visible = false;
            //code for security
            //if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            //{
            //    btn_Update.Visible = false;
            //}

            //else
            //{
            //    btn_Update.Visible = true;
            //}
            rmpProject.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmProject", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            ClearControls();
            rmpProject.SelectedIndex = 1;
            //rtxt_ProjectCode.Focus();
            btn_Save.Visible = true;
            btn_Update.Visible = false;
            rtxt_ProjectCode.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmProject", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    #region Button Click Events

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            ClearControls();
            rmpProject.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmProject", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_PROJECT smhrProject = new SMHR_PROJECT();
            smhrProject.PROJECT_CODE = BLL.ReplaceQuote(rtxt_ProjectCode.Text);
            smhrProject.PROJECT_NAME = BLL.ReplaceQuote(rtxt_ProjectName.Text);
            smhrProject.PROJECT_DESC = BLL.ReplaceQuote(rtxtProjectDesc.Text);
            smhrProject.PROJECT_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            smhrProject.PROJECT_BUSINESSUNIT_ID = Convert.ToInt32(rcmbBusinessUnit.SelectedValue);
            smhrProject.PROJECT_STARTDATE = Convert.ToDateTime(rdpStartDate.SelectedDate);
            smhrProject.PROJECT_ENDDATE = Convert.ToDateTime(rdpEndDate.SelectedDate);
            smhrProject.PROJECT_CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            smhrProject.PROJECT_CREATEDDATE = DateTime.Now;
            smhrProject.PROJECT_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            smhrProject.PROJECT_LASTMDFDATE = DateTime.Now;
            smhrProject.PROJECT_ISDELETED = Convert.ToString(rcmbStatus.SelectedValue);

            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_UPDATE":
                    smhrProject.PROJECT_ID = Convert.ToInt32(lbl_ProjectID.Text);
                    smhrProject.OPERATION = operation.Update;
                    if (BLL.SetProject(smhrProject))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Updated");

                    break;
                case "BTN_SAVE":
                    smhrProject.OPERATION = operation.Check;
                    if (Convert.ToString(BLL.GetProject(smhrProject).Rows[0]["Count"]) != "0")
                    {
                        BLL.ShowMessage(this, "Project Code Already Exists");
                        return;
                    }
                    smhrProject.OPERATION = operation.Insert;
                    if (BLL.SetProject(smhrProject))
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                default:
                    break;
            }
            rmpProject.SelectedIndex = 0;
            LoadGrid();
            rgProject.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmProject", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region Clear Controls

    protected void ClearControls()
    {
        try
        {
            rtxt_ProjectCode.Text = string.Empty;
            rtxt_ProjectName.Text = string.Empty;
            rdpEndDate.SelectedDate = null;
            rdpStartDate.SelectedDate = null;
            rtxtProjectDesc.Text = string.Empty;
            rcmbBusinessUnit.SelectedIndex = 0;
            rcmbStatus.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmProject", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    protected void rdpStartDate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        try
        {
            rdpEndDate.MinDate = Convert.ToDateTime(rdpStartDate.SelectedDate);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmProject", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}