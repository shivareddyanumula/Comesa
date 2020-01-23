using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using SMHR;
using RECRUITMENT;

public partial class Recruitment_frm_InterviewPriority : System.Web.UI.Page
{
    RECRUITMENT_INTERVIEW_PRIORITY _obj_Rec_Priority;
    SMHR_MASTERS _obj_Smhr_Masters;
    static string priorityid;

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (!Page.IsPostBack)
            {

                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Interview Priority");
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
                    RG_InterviewPriority.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Submit.Visible = false;
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
                Page.Validate();
                LoadGrid();
                RG_InterviewPriority.DataBind();

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewPriority", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    public void LoadGrid()
    {
        try
        {
            DataTable DT = new DataTable();
            _obj_Rec_Priority = new RECRUITMENT_INTERVIEW_PRIORITY();
            _obj_Rec_Priority.PRIORITY_ORGANIZATIONID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_Rec_Priority.MODE = 1;
            DT = Recruitment_BLL.get_InterviewPriority(_obj_Rec_Priority);
            if (DT.Rows.Count != 0)
            {
                RG_InterviewPriority.DataSource = DT;

            }
            else
            {
                DataTable dt1 = new DataTable();
                RG_InterviewPriority.DataSource = dt1;
                return;
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewPriority", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }


    protected void ClearControls()
    {
        try
        {
            RNTB_PriorityValue.Visible = false;
            txt_Priorityname.Visible = false;

            btn_Submit.Visible = false;
            btn_Update.Visible = false;
            btn_Cancel.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewPriority", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    #region Grid NeedDataSource Event

    protected void RG_InterviewPriority_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            DataTable DT = new DataTable();
            _obj_Rec_Priority = new RECRUITMENT_INTERVIEW_PRIORITY();
            _obj_Rec_Priority.PRIORITY_ORGANIZATIONID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_Rec_Priority.MODE = 1;
            DT = Recruitment_BLL.get_InterviewPriority(_obj_Rec_Priority);
            if (DT.Rows.Count != 0)
            {
                RG_InterviewPriority.DataSource = DT;
                //  RG_InterviewPriority.DataBind(); 

            }
            //  LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewPriority", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    #endregion

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_Rec_Priority = new RECRUITMENT_INTERVIEW_PRIORITY();
            _obj_Rec_Priority.PRIORITY_ORGANIZATIONID = Convert.ToInt32(Session["ORG_ID"].ToString());


            switch (((Button)sender).ID.ToUpper())
            {

                case "BTN_UPDATE":
                    _obj_Rec_Priority.PRIORITY_VALUE = Convert.ToInt32(RNTB_PriorityValue.Value);
                    _obj_Rec_Priority.PRIORITY_NAME = Recruitment_BLL.ReplaceQuote(Convert.ToString(txt_Priorityname.Text));
                    _obj_Rec_Priority.PRIORITY_ID = Convert.ToInt32(lbl_Id.Text);
                    //   _obj_Rec_Priority.PRIORITY_ID = Convert.ToInt32(priorityid);
                    _obj_Rec_Priority.MODE = 2;
                    _obj_Rec_Priority.PRIORITY_ORGANIZATIONID = Convert.ToInt32(Session["ORG_ID"].ToString());

                    if (Convert.ToString(Recruitment_BLL.get_InterviewPriority(_obj_Rec_Priority).Rows[0]["Count"]) != "1")
                    {
                        Recruitment_BLL.ShowMessage(this, "This Combination Already Exists");
                        return;
                    }

                    _obj_Rec_Priority.MODE = 3;

                    if (Recruitment_BLL.set_InterviewPriority(_obj_Rec_Priority))
                        Recruitment_BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        Recruitment_BLL.ShowMessage(this, "Information Not Updated");

                    LoadGrid();
                    RG_InterviewPriority.DataBind();
                    RM_InterviewPriority.SelectedIndex = 0;

                    break;
                case "BTN_SUBMIT":
                    _obj_Rec_Priority.PRIORITY_VALUE = Convert.ToInt32(RNTB_PriorityValue.Value);
                    _obj_Rec_Priority.PRIORITY_NAME = Recruitment_BLL.ReplaceQuote(Convert.ToString(txt_Priorityname.Text));
                    _obj_Rec_Priority.PRIORITY_ORGANIZATIONID = Convert.ToInt32(Session["ORG_ID"].ToString());
                    _obj_Rec_Priority.MODE = 2;

                    if (Convert.ToString(Recruitment_BLL.get_InterviewPriority(_obj_Rec_Priority).Rows[0]["Count"]) != "0")
                    {
                        Recruitment_BLL.ShowMessage(this, "This Combination Already Exists");
                        return;
                    }

                    _obj_Rec_Priority.MODE = 4;

                    if (Recruitment_BLL.set_InterviewPriority(_obj_Rec_Priority))
                        Recruitment_BLL.ShowMessage(this, "Information Saved Successfully");
                    else
                        Recruitment_BLL.ShowMessage(this, "Information Not Saved");

                    LoadGrid();
                    RG_InterviewPriority.DataBind();
                    RM_InterviewPriority.SelectedIndex = 0;

                    break;
                default:
                    break;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewPriority", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            //ClearControls();
            //   LoadGrade();

            _obj_Rec_Priority = new RECRUITMENT_INTERVIEW_PRIORITY();


            _obj_Rec_Priority.MODE = 5;
            _obj_Rec_Priority.PRIORITY_ID = Convert.ToInt32(e.CommandArgument);
            priorityid = Convert.ToString(e.CommandArgument);
            DataTable DT = Recruitment_BLL.get_InterviewPriority(_obj_Rec_Priority);

            if (DT.Rows.Count != 0)
            {
                lbl_Id.Text = Convert.ToString(DT.Rows[0]["PRIORITY_ID"]);
                RNTB_PriorityValue.Value = Convert.ToInt32(DT.Rows[0]["PRIORITY_VALUE"]);
                RNTB_PriorityValue.Enabled = false;
                txt_Priorityname.Text = Convert.ToString(DT.Rows[0]["PRIORITY_NAME"]);


            }

            btn_Update.Visible = true;
            btn_Submit.Visible = false;
            RM_InterviewPriority.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewPriority", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            RNTB_PriorityValue.Text = string.Empty;
            txt_Priorityname.Text = string.Empty;
            RNTB_PriorityValue.Enabled = true;
            txt_Priorityname.Enabled = true;

            btn_Update.Visible = false;
            btn_Submit.Visible = true;
            RM_InterviewPriority.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewPriority", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            RM_InterviewPriority.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewPriority", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void btn_Update_Click(object sender, EventArgs e)
    {

    }

    protected void clearfields() // CHANGE IT
    {
        //RT_SkillDesc.Text = string.Empty;
        //RT_Skillname.Text = string.Empty;


    }

}




