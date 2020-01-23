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
using SPMS;
public partial class Training_frm_CourseMaster : System.Web.UI.Page
{
    SMHR_COURSEMASTER _obj_trainee = new SMHR_COURSEMASTER();
    DataTable dt_Courses = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    { 
        try
    {
        // as the types are static and code is user editable colunm nothing loaded except grid

        if (!IsPostBack)
        {
            Session.Remove("WRITEFACILITY");

            SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

            _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
            _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
            _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("MASTER COURSE");
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
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                rg_Courses.Enabled = false;

            }
            else
            {
                rg_Courses.Enabled = true;
            }
            loadgrid();
            rg_Courses.DataBind();
            Page.Validate();
        }
    }
    catch (Exception ex)
    {
        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CourseMaster", ex.StackTrace, DateTime.Now);
        Response.Redirect("~/Frm_ErrorPage.aspx");
    }
    }

    private void loadgrid()
    {
        try
        {
        _obj_trainee.ORGANISATION_ID=Convert.ToInt32(Session["ORG_ID"]);
        dt_Courses = BLL.get_coursemaster(_obj_trainee);//[USP_Smhr_Trainee] operation as select
        rg_Courses.DataSource = dt_Courses;       
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CourseMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #region Button click
    /// <summary>
    /// All Buttons Functionalities
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            if ((rcmb_Course.SelectedItem.Text != "Select"))
            {
                if ((rcmb_Course.SelectedItem.Text != string.Empty) && (rtxt_Code.Text != string.Empty))
                {
                    SMHR_COURSEMASTER _obj_trainee = new SMHR_COURSEMASTER();
                    _obj_trainee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                   
                    _obj_trainee.CODE = BLL.ReplaceQuote(rtxt_Code.Text);
                    _obj_trainee.COURSE = rcmb_Course.SelectedItem.Text;
                    _obj_trainee.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_trainee.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_trainee.HR_MASTER_ISDELETED = false;
                    // CHECKING FOR THE DUPLICATE
                    _obj_trainee.OPERATION = operation.Check;
                    DataTable Dt_duplicates = BLL.get_coursemaster(_obj_trainee);
                    if (Dt_duplicates.Rows.Count > 0)
                    {
                        if (Dt_duplicates.Rows[0][0].ToString() == "1")
                        {
                            BLL.ShowMessage(this, "Master Which You have Entered is Already Exists");
                            return;
                        }
                    }
                    _obj_trainee.OPERATION = operation.Insert;
                    bool status = BLL.set_Coursemaster(_obj_trainee);//[USP_Smhr_Trainee] operation as insert1
                    if (status==true)
                    {
                        BLL.ShowMessage(this, rcmb_Course.SelectedItem.Text + " Inserted Successfully");
                        rcmb_Course.ClearSelection();
                        rtxt_Code.Text = "";
                        RMP_CourseMaster.SelectedIndex = 0;
                        loadgrid();
                        rg_Courses.DataBind();
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Error Occured In the Process");
                    }

                }
                else
                {
                    BLL.ShowMessage(this, "Please Enter Name");
                    return;
                }
            }
            else
            {
                BLL.ShowMessage(this, "Please Select Type");
                return;
            }


        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Training_frm_CourseMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        rcmb_Course.ClearSelection();
        rtxt_Code.Text = "";
        RMP_CourseMaster.SelectedIndex = 0;
        loadgrid();
        rg_Courses.DataBind();
    }
    #endregion
    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            RMP_CourseMaster.SelectedIndex = 1;
            rcmb_Course.ClearSelection();
            rtxt_Code.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CourseMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    //protected void rcm_course_indexchanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    //{

        //if (rcmb_Course.SelectedItem.Text != "SELECT")
        //{
        //    if (rcmb_Course.SelectedItem.Text == "COURSE")
        //    {
        //        skil_id.Visible = true;
        //    }
        //    else
        //    {
        //        skil_id.Visible = false;
        //    }
        //}

        //else
        //{
        //    BLL.ShowMessage(this, "Select Type");
        //    return;
        //}


    //}
    protected void rg_Courses_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        loadgrid();
    }
}
