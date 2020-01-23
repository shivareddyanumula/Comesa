using SMHR;
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
using Telerik.Web.UI;
public partial class HR_TRAINING_frm_TrainingCosts : System.Web.UI.Page
{
    SMHR_MASTERS _obj_Smhr_Masters;
    SMHR_TRAINING_LOCATION _obj_Smhr_Location;
    SMHR_TRAININGCOST _obj_smhr_Cost;
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (!IsPostBack)
            {
                // LoadCourseName();
                //LoadCourseSchedule();
                //LoadGrid();

                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Training Costs");//COUNTRY");
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
                    Rg_Costs.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Save.Visible = false;
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
                Rg_InteretsQuarters.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingCosts", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private DataTable CreateGridDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("TRAININGCOST_TYPE_ID", typeof(int));
        dt.Columns.Add("TRAININGCOST_AMOUNT", typeof(int));

        return dt;
    }
    private void LoadCourseName()
    {
        try
        {
            SMHR_COURSE _obj_Course = new SMHR_COURSE();
            _obj_Course.OPERATION = operation.Select2;
            _obj_Course.COURSE_ORG_ID = Convert.ToInt32(Session["ORG_ID"].ToString()); //Convert.ToInt32(Session["ORG_ID"]);
            rcmb_CourseName.DataSource = BLL.get_Course(_obj_Course);
            rcmb_CourseName.DataTextField = "COURSE_NAME";
            rcmb_CourseName.DataValueField = "COURSE_ID";
            rcmb_CourseName.DataBind();
            rcmb_CourseName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingCosts", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rg_InteretsQuarters_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        LoadGrid();
    }
    private void LoadGrid()
    {
        try
        {
            _obj_smhr_Cost = new SMHR_TRAININGCOST();
            _obj_smhr_Cost.OPERATION = operation.Select;
            _obj_smhr_Cost.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT = BLL.get_CostType(_obj_smhr_Cost);
            Rg_InteretsQuarters.DataSource = DT;
            //Rg_InteretsQuarters.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingCosts", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    //protected void Rm_CY_page_PageViewCreated(object sender, Telerik.Web.UI.RadMultiPageEventArgs e)
    //{

    //}
    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            Rm_CY_page.SelectedIndex = 1;
            rcmb_CourseSchedule.Items.Clear();
            rcmb_CourseSchedule.ClearSelection();
            rcmb_CourseSchedule.Text = string.Empty;
            LoadCourseName();
            //LoadCourseSchedule();
            //_obj_smhr_Cost = new SMHR_TRAININGCOST();
            //_obj_smhr_Cost.OPERATION = operation.Select1;
            //_obj_smhr_Cost.TRAININGCOST_ORG_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            //DataTable dt = BLL.get_CostType(_obj_smhr_Cost);
            //Rg_Costs.DataSource = dt;
            //Rg_Costs.DataBind();
            Rg_Costs.Visible = false;
            btn_Save.Visible = false;
            rcmb_CourseName.Enabled = true;
            rcmb_CourseSchedule.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingCosts", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            Rm_CY_page.SelectedIndex = 1;
            _obj_smhr_Cost = new SMHR_TRAININGCOST();
            _obj_smhr_Cost.OPERATION = operation.Get;
            _obj_smhr_Cost.TRAININGCOST_COURSESCHEDULE_ID = Convert.ToInt32(e.CommandArgument);
            lblID.Text = _obj_smhr_Cost.TRAININGCOST_ID.ToString();
            _obj_smhr_Cost.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_CostType(_obj_smhr_Cost);
            Rg_Costs.DataSource = dt;
            Rg_Costs.DataBind();
            rcmb_CourseName.DataSource = dt;
            rcmb_CourseName.DataTextField = "COURSE_NAME";
            rcmb_CourseName.DataValueField = "COURSE_ID";
            rcmb_CourseName.DataBind();
            rcmb_CourseSchedule.DataSource = dt;
            rcmb_CourseSchedule.DataTextField = "CourseSchedule_Name";
            rcmb_CourseSchedule.DataValueField = "CourseSchedule_ID";
            rcmb_CourseSchedule.DataBind();
            rcmb_CourseName.Enabled = false;
            rcmb_CourseSchedule.Enabled = false;
            Rg_Costs.Visible = true;
            btn_Save.Visible = false;
            btn_Update.Visible = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingCosts", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_TRAININGCOST _obj_smhr_Cost = new SMHR_TRAININGCOST();
            _obj_smhr_Cost.TRAININGCOST_COURSESCHEDULE_ID = Convert.ToInt32(rcmb_CourseSchedule.SelectedItem.Value);
            DataTable dt = CreateGridDataTable();
            RadNumericTextBox r;
            foreach (GridDataItem g in Rg_Costs.Items)
            {
                r = new RadNumericTextBox();
                r = g.FindControl("txt_Amount") as RadNumericTextBox;
                dt.Rows.Add(Convert.ToInt32(g.Cells[2].Text), Convert.ToInt32(r.Text));
            }
            _obj_smhr_Cost.TRAININGCOST = dt;
            _obj_smhr_Cost.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_Cost.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_Cost.CREATEDDATE = DateTime.Now;
            _obj_smhr_Cost.LASTMDFDATE = DateTime.Now;
            _obj_smhr_Cost.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_UPDATE":

                    //  _obj_Smhr_Masters.QRTR_ID = Convert.ToInt32(lblID.Text);
                    _obj_smhr_Cost.OPERATION = operation.Insert;
                    if (BLL.set_CostType(_obj_smhr_Cost))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Updated");

                    break;
                case "BTN_SAVE":
                    _obj_smhr_Cost.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_Cost.OPERATION = operation.Insert;
                    if (BLL.set_CostType(_obj_smhr_Cost))
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                default:
                    break;
            }
            Rm_CY_page.SelectedIndex = 0;
            LoadGrid();
            Rg_InteretsQuarters.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingCosts", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            Rm_CY_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingCosts", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_CourseSchedule_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_CourseSchedule.SelectedIndex > 0)
            {
                _obj_smhr_Cost = new SMHR_TRAININGCOST();
                _obj_smhr_Cost.OPERATION = operation.Select1;
                _obj_smhr_Cost.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                DataTable dt = BLL.get_CostType(_obj_smhr_Cost);
                Rg_Costs.DataSource = dt;
                Rg_Costs.DataBind();
                Rg_Costs.Visible = true;
                btn_Save.Visible = true;
            }
            else
            {
                Rg_Costs.Visible = false;
                btn_Save.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingCosts", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void rcmb_CourseName_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_CourseName.SelectedIndex > 0)
            {
                SMHR_COURSESCHEDULE oSMHR_COURSESCHEDULE = new SMHR_COURSESCHEDULE();
                oSMHR_COURSESCHEDULE.OPERATION = operation.Course2;
                oSMHR_COURSESCHEDULE.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                oSMHR_COURSESCHEDULE.COURSESCHEDULE_COURSEID = Convert.ToInt32(rcmb_CourseName.SelectedItem.Value);
                rcmb_CourseSchedule.DataSource = BLL.get_CourseSchedule(oSMHR_COURSESCHEDULE);
                rcmb_CourseSchedule.DataTextField = "CourseSchedule_Name";
                rcmb_CourseSchedule.DataValueField = "CourseSchedule_ID";
                rcmb_CourseSchedule.DataBind();
                rcmb_CourseSchedule.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
            else
            {
                rcmb_CourseSchedule.ClearSelection();
                rcmb_CourseSchedule.Items.Clear();
                Rg_Costs.Visible = false;
                btn_Save.Visible = false;
            }
            Rg_Costs.Visible = false;
            btn_Save.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingCosts", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
