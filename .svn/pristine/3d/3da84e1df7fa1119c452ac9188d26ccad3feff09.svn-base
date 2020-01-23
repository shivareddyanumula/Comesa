using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Data;
using Telerik.Web.UI;
using SPMS;

public partial class Training_frm_TrainingApproval : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (!Page.IsPostBack)
            {
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("TRAINING APPROVAL");
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
                    RG_TrainingApproval.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    //btn_Save.Visible = false;
                    //btn_Update.Visible = false;
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

                BindBatches();
                RG_TrainingApproval.Visible = true;
                //LoadCombos();
                //LoadData();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


        //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "function pageLoad(){ }", true);
    }


    //private void LoadCombos()
    //{
    //    try
    //    {
    //        SMHR_COURSE _obj_Course = new SMHR_COURSE();
    //        _obj_Course.OPERATION = operation.Select2;
    //        _obj_Course.COURSE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
    //        radCourse.DataSource = BLL.get_Course(_obj_Course);
    //        radCourse.DataTextField = "COURSE_NAME";
    //        radCourse.DataValueField = "COURSE_ID";
    //        radCourse.DataBind();
    //        radCourse.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Course", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}
    protected void lnk_Apply_Command(object sender, CommandEventArgs e)
    {
        try
        {
            SMHR_TRAINING_REQUST _obj_Smhr_TrgRqst = new SMHR_TRAINING_REQUST();
            _obj_Smhr_TrgRqst.TRAINING_REQUST_ID = Convert.ToInt32(e.CommandArgument);
            _obj_Smhr_TrgRqst.OPERATION = operation.Update;
            _obj_Smhr_TrgRqst.TRAINING_APPROVEDBY = Convert.ToInt32(Session["EMP_ID"]);
            _obj_Smhr_TrgRqst.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_TrgRqst.LASTMDFDATE = DateTime.Now;
            switch (((LinkButton)sender).ID.ToUpper())
            {
                case "LNK_APPLY":
                    _obj_Smhr_TrgRqst.TRAINING_ISAPPROVED = 1;
                    _obj_Smhr_TrgRqst.OPERATION = operation.Check;
                    if (string.Compare(Convert.ToString(BLL.get_TrainigRequest(_obj_Smhr_TrgRqst).Rows[0][0]), "1", true) == 0)
                    {
                        BLL.ShowMessage(this, "There is No Vacancy for this Training");
                        return;
                    }
                    _obj_Smhr_TrgRqst.OPERATION = operation.Update;
                    if (BLL.set_TrainigRequest(_obj_Smhr_TrgRqst))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                case "LNK_REJECT":
                    _obj_Smhr_TrgRqst.TRAINING_ISAPPROVED = 2;
                    if (BLL.set_TrainigRequest(_obj_Smhr_TrgRqst))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                default:
                    break;
            }
            BindBatches();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }




    //protected void radCourse_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    //{
    //    if (string.Compare(radCourse.SelectedItem.Text, "Select", true) != 0)
    //    {
    //        BindBatches();
    //        RG_TrainingApproval.Visible = true;
    //    }
    //}
    private void BindBatches()
    {
        try
        {
            SMHR_TRAINING_REQUST _obj_Smhr_TrgRqst = new SMHR_TRAINING_REQUST();
            _obj_Smhr_TrgRqst.OPERATION = operation.Get;
            //_obj_Smhr_TrgRqst.TRAINING_COURSEID = Convert.ToInt32(radCourse.SelectedValue);
            _obj_Smhr_TrgRqst.TRAINING_APPROVEDBY = Convert.ToInt32(Session["EMP_ID"]);
            _obj_Smhr_TrgRqst.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);//YYY
            DataTable DT = BLL.get_TrainigRequest(_obj_Smhr_TrgRqst);
            if (DT.Rows.Count != 0)
            {
                RG_TrainingApproval.DataSource = DT;
                RG_TrainingApproval.DataBind();
            }
            else
            {
                DataTable DT1 = new DataTable();
                RG_TrainingApproval.DataSource = DT1;
                RG_TrainingApproval.DataBind();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    /*added  by anusha 21/05/2015*/
    private void BindBatchesDatasource()
    {
        try
        {
            SMHR_TRAINING_REQUST _obj_Smhr_TrgRqst = new SMHR_TRAINING_REQUST();
            _obj_Smhr_TrgRqst.OPERATION = operation.Get;
            //_obj_Smhr_TrgRqst.TRAINING_COURSEID = Convert.ToInt32(radCourse.SelectedValue);
            _obj_Smhr_TrgRqst.TRAINING_APPROVEDBY = Convert.ToInt32(Session["EMP_ID"]);
            _obj_Smhr_TrgRqst.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);//YYY
            DataTable DT = BLL.get_TrainigRequest(_obj_Smhr_TrgRqst);
            if (DT.Rows.Count != 0)
            {
                RG_TrainingApproval.DataSource = DT;
               // RG_TrainingApproval.DataBind();
            }
            else
            {
                DataTable DT1 = new DataTable();
                RG_TrainingApproval.DataSource = DT1;
               // RG_TrainingApproval.DataBind();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /*added by anusha 21/05/2015*/
    protected void RG_TrainingApproval_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            BindBatchesDatasource();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        
    }
}
