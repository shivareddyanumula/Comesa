using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class HR_TRAINING_frm_TrainingRooms : System.Web.UI.Page
{
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_MASTERS _obj_Smhr_Masters;
    SMHR_TRAINING_ROOM _obj_Smhr_Room;
    SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit;

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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Training Rooms");//COURSE");
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
                    Rg_Course.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;

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
                lbl_CourseHeader.Visible = true;
                Page.Validate();
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRooms", ex.StackTrace, DateTime.Now);

            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            // lbl_CourseHeader.Visible = false;
            // rcmb_CC.Enabled = false;

            clearControls();
            LoadCombos();

            _obj_Smhr_Room = new SMHR_TRAINING_ROOM();
            _obj_Smhr_Room.ROOMID = Convert.ToInt32(e.CommandArgument);

            _obj_Smhr_Room.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Room.OPERATION = operation.Get;
            DataTable dt = BLL.get_TrainingRooms(_obj_Smhr_Room);
            if (dt.Rows.Count != 0)
            {
                radRoomName.Enabled = false;
                lblTrainingRoomsId.Text = dt.Rows[0]["ROOMS_ID"].ToString();
                radRoomName.Text = dt.Rows[0]["ROOMS_NAME"].ToString();
                radRoomStrength.Text = dt.Rows[0]["ROOMS_STRENGTH"].ToString();
                LoadCombos();
                radLocation.SelectedIndex = radLocation.FindItemIndexByValue(dt.Rows[0]["ROOMS_LOCATIONID"].ToString());
                rad_IsActive.Checked = Convert.ToBoolean(dt.Rows[0]["ROOMS_STATUS"]);

                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    btn_Update.Visible = false;

                }

                else
                {
                    btn_Update.Visible = true;
                }

                Rm_Course_page.SelectedIndex = 1;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRooms", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            radRoomName.Enabled = true;
            //lbl_CourseHeader.Visible = false;
            clearControls();
            LoadCombos();
            btn_Save.Visible = true;
            Rm_Course_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRooms", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void LoadGrid()
    {
        try
        {
            _obj_Smhr_Room = new SMHR_TRAINING_ROOM();
            _obj_Smhr_Room.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Room.OPERATION = operation.Select;
            DataTable DT = BLL.get_TrainingRooms(_obj_Smhr_Room);
            if (DT.Rows.Count != 0)
            {
                Rg_Course.DataSource = DT;
            }

            else
            {
                DataTable dt1 = new DataTable();
                Rg_Course.DataSource = dt1;
            }
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRooms", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Rg_Course_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        LoadGrid();
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_TRAINING_ROOM _obj_Smhr_Room = new SMHR_TRAINING_ROOM();
            _obj_Smhr_Room.ROOMNAME = radRoomName.Text;
            _obj_Smhr_Room.ROOMSTRENGTH = Convert.ToInt32(radRoomStrength.Text);
            _obj_Smhr_Room.ROOMS_LOCATION_ID = Convert.ToInt32(radLocation.SelectedValue);
            _obj_Smhr_Room.ROOM_STATUS = rad_IsActive.Checked;
            _obj_Smhr_Room.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_Room.CREATEDDATE = DateTime.Now;
            _obj_Smhr_Room.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Room.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_Room.LASTMDFDATE = DateTime.Now;

            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_UPDATE":
                    if (Convert.ToBoolean(rad_IsActive.Checked) == false)
                    {

                        SMHR_COURSESCHEDULE _obj_CS = new SMHR_COURSESCHEDULE();
                        _obj_CS.OPERATION = operation.Chk;
                        _obj_CS.COURSESCHEDULE_ROOMID = Convert.ToInt32(lblTrainingRoomsId.Text);
                        _obj_CS.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dtc = BLL.get_CourseSchedule(_obj_CS);
                        if (!Convert.ToBoolean(dtc.Rows[0]["Status"]))
                        {
                            BLL.ShowMessage(this, "Cannot make inactive");
                            rad_IsActive.Checked = true;
                            return;
                        }
                    }
                    _obj_Smhr_Room.OPERATION = operation.Update;
                    _obj_Smhr_Room.ROOMID = Convert.ToInt32(lblTrainingRoomsId.Text);
                    if (BLL.set_TrainingRooms(_obj_Smhr_Room))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                case "BTN_SAVE":
                    _obj_Smhr_Room.OPERATION = operation.Check;
                    if (Convert.ToString(BLL.get_TrainingRooms(_obj_Smhr_Room).Rows[0]["Count"]) != "0")
                    {
                        BLL.ShowMessage(this, "Room with this Name Already Exists");
                        return;
                    }
                    _obj_Smhr_Room.OPERATION = operation.Insert;
                    if (BLL.set_TrainingRooms(_obj_Smhr_Room))
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                default:
                    break;
            }
            Rm_Course_page.SelectedIndex = 0;
            LoadGrid();
            Rg_Course.DataBind();

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRooms", ex.StackTrace, DateTime.Now);

            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRooms", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadCombos()
    {
        try
        {
            SMHR_TRAINING_LOCATION _obj_Smhr_Location = new SMHR_TRAINING_LOCATION();
            _obj_Smhr_Location.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Location.OPERATION = operation.Select2;
            radLocation.DataSource = BLL.get_TrainingLocation(_obj_Smhr_Location);
            radLocation.DataValueField = "Location_ID";
            radLocation.DataTextField = "Location_Name";
            radLocation.DataBind();
            radLocation.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRooms", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void clearControls()
    {
        try
        {
            radLocation.Text = string.Empty;
            radRoomName.Text = string.Empty;
            radLocation.Items.Clear();
            radLocation.Text = string.Empty;
            radRoomStrength.Text = string.Empty;
            btn_Save.Visible = false;
            btn_Update.Visible = false;
            Rm_Course_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRooms", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


}
