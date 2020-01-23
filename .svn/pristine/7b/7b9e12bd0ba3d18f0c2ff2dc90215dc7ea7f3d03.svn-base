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
using RECRUITMENT;
using Telerik.Web.UI;

public partial class Recruitment_frm_AssessmentType : System.Web.UI.Page
{
    RECRUITMENT_ASSESSMENTS _obj_Rec_Assessments;
    SMHR_MASTERS _obj_smhr_masters;
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            Page.Validate();
            if (!Page.IsPostBack)
            {
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();
                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Assessment Type");
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
                    if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                    {
                        rg_AssessmentType.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
                    rg_AssessmentType.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Save.Visible = false;
                    btn_Update.Visible = false;
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
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AssessmentType", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

    }

    private void LoadGrid()
    {
        try
        {
            _obj_Rec_Assessments = new RECRUITMENT_ASSESSMENTS();
            _obj_Rec_Assessments.MODE = 3;
            _obj_Rec_Assessments.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = Recruitment_BLL.get_Assessments(_obj_Rec_Assessments);
            rg_AssessmentType.DataSource = dt;
            rg_AssessmentType.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AssessmentType", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void rg_AssessmentType_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            _obj_Rec_Assessments = new RECRUITMENT_ASSESSMENTS();
            _obj_Rec_Assessments.MODE = 3;
            _obj_Rec_Assessments.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = Recruitment_BLL.get_Assessments(_obj_Rec_Assessments);
            rg_AssessmentType.DataSource = dt;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AssessmentType", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            RMP_AssessmentType.SelectedIndex = 1;
            LoadCombos();
            ClearControls();
            btn_Save.Visible = true;
            btn_Update.Visible = false;
            rcmb_Type.Enabled = true;
            rtxt_Name.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AssessmentType", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void ClearControls()
    {
        try
        {
            rcmb_Type.SelectedIndex = 0;
            rtxt_Name.Text = string.Empty;
            rtxt_Desc.Text = string.Empty;
            //rcmb_ApplicableFor.SelectedIndex = 0;
            lbl_ID.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AssessmentType", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void LoadCombos()
    {
        try
        {
            rcmb_Type.Items.Clear();
            _obj_smhr_masters = new SMHR_MASTERS();
            _obj_smhr_masters.MASTER_TYPE = "ASSESSMENT_TYPE";
            _obj_smhr_masters.OPERATION = operation.Select;
            _obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);
            rcmb_Type.DataSource = dt_Details;
            rcmb_Type.DataTextField = "HR_MASTER_CODE";
            rcmb_Type.DataValueField = "HR_MASTER_ID";
            rcmb_Type.DataBind();
            rcmb_Type.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AssessmentType", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            RMP_AssessmentType.SelectedIndex = 1;
            LoadCombos();
            _obj_Rec_Assessments = new RECRUITMENT_ASSESSMENTS();
            _obj_Rec_Assessments.MODE = 4;
            _obj_Rec_Assessments.ASSESSMENT_ID = Convert.ToInt32(e.CommandArgument);
            lbl_ID.Text = Convert.ToString(e.CommandArgument);
            DataTable dt = Recruitment_BLL.get_Assessments(_obj_Rec_Assessments);
            if (dt.Rows.Count > 0)
            {
                rcmb_Type.SelectedIndex = rcmb_Type.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["HR_MASTER_ID"]));
                rtxt_Name.Text = Convert.ToString(dt.Rows[0]["ASSESSMENT_NAME"]);
                rtxt_Desc.Text = Convert.ToString(dt.Rows[0]["ASSESSMENT_DESC"]);
                //rcmb_ApplicableFor.SelectedIndex =rcmb_ApplicableFor.Items.FindItemIndexByText(Convert.ToString(dt.Rows[0]["ASSESSMENT_APPLICABLEFOR"]));
            }
            btn_Save.Visible = false;
            rcmb_Type.Enabled = false;
            rtxt_Name.Enabled = false;
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 1)
                btn_Update.Visible = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AssessmentType", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_Rec_Assessments = new RECRUITMENT_ASSESSMENTS();
            _obj_Rec_Assessments.ASSESSMENT_NAME = Convert.ToString(rtxt_Name.Text.Replace("'", "''"));
            _obj_Rec_Assessments.ASSESSMENT_DESC = Convert.ToString(rtxt_Desc.Text.Replace("'", "''"));
            _obj_Rec_Assessments.ASSESSMENT_TYPE = Convert.ToInt32(rcmb_Type.SelectedItem.Value);
            //_obj_Rec_Assessments.ASSESSMENT_APPLICABLEFOR = Convert.ToString(rcmb_ApplicableFor.SelectedItem.Text);
            _obj_Rec_Assessments.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Rec_Assessments.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_Rec_Assessments.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_UPDATE":
                    _obj_Rec_Assessments.MODE = 5;
                    if (Convert.ToString(Recruitment_BLL.get_Assessments(_obj_Rec_Assessments).Rows[0]["COUNT"]) != "1")
                    {
                        BLL.ShowMessage(this, "Asset Name already exist for this type.");
                        return;
                    }
                    _obj_Rec_Assessments.MODE = 2;
                    _obj_Rec_Assessments.ASSESSMENT_ID = Convert.ToInt32(lbl_ID.Text);
                    if (Recruitment_BLL.set_Assessments(_obj_Rec_Assessments))
                        BLL.ShowMessage(this, "Information Updated Successfully.");
                    break;
                case "BTN_SAVE":
                    _obj_Rec_Assessments.MODE = 5;
                    if (Convert.ToString(Recruitment_BLL.get_Assessments(_obj_Rec_Assessments).Rows[0]["COUNT"]) != "0")
                    {
                        BLL.ShowMessage(this, "Asset Name already exist for this type.");
                        return;
                    }
                    _obj_Rec_Assessments.MODE = 1;
                    if (Recruitment_BLL.set_Assessments(_obj_Rec_Assessments))
                        BLL.ShowMessage(this, "Information Saved Successfully.");
                    break;
            }
            RMP_AssessmentType.SelectedIndex = 0;
            LoadGrid();
            return;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AssessmentType", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            ClearControls();
            RMP_AssessmentType.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AssessmentType", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
}
