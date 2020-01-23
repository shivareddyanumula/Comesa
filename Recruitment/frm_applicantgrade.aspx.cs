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

public partial class Recruitment_frm_applicantgrade : System.Web.UI.Page
{
    SMHR_MASTERS _obj_Smhr_Masters;
    RECRUITMENT_APPLICANTGRADE _obj_Rec_ApplicantGrade;
    static DataTable dt_Details = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Validate();
        try
        {
            //code for security privilage
            Session.Remove("WRITEFACILITY");

            SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

            _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
            _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
            _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Applicant Grade");
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
                RG_ApplicantGrade.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantgrade", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void RG_ApplicantGrade_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantgrade", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_Rec_ApplicantGrade = new RECRUITMENT_APPLICANTGRADE();
            //   _obj_Rec_ApplicantGrade = new RECRUITMENT_APPLICANTGRADE

            _obj_Rec_ApplicantGrade.APPLGRADE_DESCRIPTION = txt_Description.Text.Replace("'", "''");
            _obj_Rec_ApplicantGrade.APPLGRADE_CREATEDBY = Convert.ToInt32(Session["UserId"]);
            _obj_Rec_ApplicantGrade.APPLGRADE_CREADTEDATE = DateTime.Now;
            _obj_Rec_ApplicantGrade.APPLGRADE_LASTMDFBY = Convert.ToInt32(Session["UserId"]);
            _obj_Rec_ApplicantGrade.APPLGRADE_LASTMDFDATE = DateTime.Now;
            _obj_Rec_ApplicantGrade.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            switch (((Button)sender).ID.ToUpper())
            {

                case "BTN_UPDATE":

                    _obj_Rec_ApplicantGrade.APPLGRADE_ID = Convert.ToInt32(lbl_GradeId.Text);
                    _obj_Rec_ApplicantGrade.APPGRADE_SETID = Convert.ToInt32(RCMB_Type.SelectedItem.Value);
                    _obj_Rec_ApplicantGrade.APPGRADE_NAME = txt_Name.Text.Replace("'", "''");

                    _obj_Rec_ApplicantGrade.MODE = 4;

                    if (Convert.ToString(Recruitment_BLL.get_ApplicantGrade(_obj_Rec_ApplicantGrade).Rows[0]["Count"]) != "1")
                    {
                        Recruitment_BLL.ShowMessage(this, "This Combination Already Exists");
                        return;
                    }

                    _obj_Rec_ApplicantGrade.MODE = 3;

                    if (Recruitment_BLL.set_ApplicantGrade(_obj_Rec_ApplicantGrade))
                        Recruitment_BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        Recruitment_BLL.ShowMessage(this, "Information Not Updated");

                    LoadGrid();
                    RG_ApplicantGrade.DataBind();
                    RM_ApplicantGrade.SelectedIndex = 0;

                    break;
                case "BTN_SUBMIT":
                    _obj_Rec_ApplicantGrade.APPGRADE_SETID = Convert.ToInt32(RCMB_Type.SelectedItem.Value);
                    _obj_Rec_ApplicantGrade.APPGRADE_NAME = txt_Name.Text.Replace("'", "''");

                    _obj_Rec_ApplicantGrade.MODE = 4;

                    if (Convert.ToString(Recruitment_BLL.get_ApplicantGrade(_obj_Rec_ApplicantGrade).Rows[0]["Count"]) != "0")
                    {
                        Recruitment_BLL.ShowMessage(this, "This Combination Already Exists");
                        return;
                    }

                    _obj_Rec_ApplicantGrade.MODE = 2;

                    if (Recruitment_BLL.set_ApplicantGrade(_obj_Rec_ApplicantGrade))
                        Recruitment_BLL.ShowMessage(this, "Information Saved Successfully");
                    else
                        Recruitment_BLL.ShowMessage(this, "Information Not Saved");

                    LoadGrid();
                    RG_ApplicantGrade.DataBind();
                    RM_ApplicantGrade.SelectedIndex = 0;

                    break;
                default:
                    break;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantgrade", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            ClearControls();
            RM_ApplicantGrade.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantgrade", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            ClearControls();
            LoadGrade();
            btn_Submit.Visible = true;
            RM_ApplicantGrade.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantgrade", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            ClearControls();
            LoadGrade();

            _obj_Rec_ApplicantGrade = new RECRUITMENT_APPLICANTGRADE();


            _obj_Rec_ApplicantGrade.MODE = 6;
            _obj_Rec_ApplicantGrade.APPLGRADE_ID = Convert.ToInt32(e.CommandArgument);

            DataTable DT = Recruitment_BLL.get_ApplicantGrade(_obj_Rec_ApplicantGrade);

            if (DT.Rows.Count != 0)
            {
                lbl_GradeId.Text = Convert.ToString(DT.Rows[0]["APPLGRADE_ID"]);
                RCMB_Type.SelectedIndex = RCMB_Type.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["APPGRADE_SETID"]));
                txt_Name.Text = Convert.ToString(DT.Rows[0]["APPGRADE_NAME"]);
                txt_Description.Text = Convert.ToString(DT.Rows[0]["APPLGRADE_DESCRIPTION"]);
                RCMB_Type.Enabled = false;
                txt_Name.Enabled = false;
            }

            btn_Update.Visible = true;
            RM_ApplicantGrade.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantgrade", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    public void LoadGrid()
    {
        try
        {
            DataTable DT = new DataTable();
            _obj_Rec_ApplicantGrade = new RECRUITMENT_APPLICANTGRADE();
            _obj_Rec_ApplicantGrade.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_Rec_ApplicantGrade.MODE = 5;
            DT = Recruitment_BLL.get_ApplicantGrade(_obj_Rec_ApplicantGrade);
            if (DT.Rows.Count != 0)
            {
                RG_ApplicantGrade.DataSource = DT;
                // RG_ApplicantGrade.DataBind();
            }
            else
            {
                DataTable dt1 = new DataTable();
                RG_ApplicantGrade.DataSource = dt1;
                // RG_ApplicantGrade.DataBind();

                return;
            }
            //  RG_ApplicantGrade.DataSource = DT;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantgrade", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void ClearControls()
    {
        try
        {
            lbl_GradeId.Text = string.Empty;
            txt_Name.Text = string.Empty;
            txt_Description.Text = string.Empty;
            btn_Submit.Visible = false;
            btn_Update.Visible = false;
            RCMB_Type.Enabled = true;
            txt_Name.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantgrade", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void LoadGrade()
    {
        try
        {
            _obj_Smhr_Masters = new SMHR_MASTERS();
            _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_Smhr_Masters.OPERATION = operation.Select;
            //  _obj_Smhr_Masters.MASTER_TYPE = "GRADESET"; 
            _obj_Smhr_Masters.MASTER_TYPE = "INTERVIEW ROUNDS";
            DataTable dt_Details = BLL.get_MasterRecords(_obj_Smhr_Masters);
            RCMB_Type.DataSource = dt_Details;
            RCMB_Type.DataTextField = "HR_MASTER_CODE";
            RCMB_Type.DataValueField = "HR_MASTER_ID";
            RCMB_Type.DataBind();
            RCMB_Type.Items.Insert(0, new RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_applicantgrade", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

}
