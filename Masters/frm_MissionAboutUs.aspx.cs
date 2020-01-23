using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Masters_frm_MissionAboutUs : System.Web.UI.Page
{
    SMHR_MISSION_ABOUTUS _obj_SMHR_MISSION_ABOUTUS = new SMHR_MISSION_ABOUTUS();
    public void btnSenate_Save_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_SMHR_MISSION_ABOUTUS = new SMHR_MISSION_ABOUTUS();
            _obj_SMHR_MISSION_ABOUTUS.MISSION_ABOUTUS_ISASSEMBLY = false;
            _obj_SMHR_MISSION_ABOUTUS.MISSION_ABOUTUS_ABOUTUSDESC = BLL.ReplaceQuote(rtxtSenateAboutUs.Text);
            _obj_SMHR_MISSION_ABOUTUS.MISSION_ABOUTUS_MISSIONDESC = BLL.ReplaceQuote(rtxtSenateMission.Text);
            _obj_SMHR_MISSION_ABOUTUS.MISSION_ABOUTUS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            _obj_SMHR_MISSION_ABOUTUS.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_SMHR_MISSION_ABOUTUS.CREATEDDATE = DateTime.Now;

            _obj_SMHR_MISSION_ABOUTUS.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_SMHR_MISSION_ABOUTUS.LASTMDFDATE = DateTime.Now;

            switch (((Button)sender).ID.ToUpper())
            {
                case "BTNSENATE_UPDATE":
                    _obj_SMHR_MISSION_ABOUTUS.MISSION_ABOUTUS_ID = Convert.ToInt32(hdnSenateMissionID.Value);
                    _obj_SMHR_MISSION_ABOUTUS.OPERATION = operation.Update;
                    if (BLL.set_MISSION_ABOUTUS(_obj_SMHR_MISSION_ABOUTUS))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Updated");

                    break;
                case "BTNSENATE_SAVE":
                    _obj_SMHR_MISSION_ABOUTUS.OPERATION = operation.Insert;
                    if (BLL.set_MISSION_ABOUTUS(_obj_SMHR_MISSION_ABOUTUS))
                    {
                        BLL.ShowMessage(this, "Information Saved Successfully");
                        LoadMissionandAboutus();
                    }
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                default:
                    break;
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_MissionAboutUs", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

        }
    }

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (!IsPostBack)
            {


                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Mission and Vision");//COUNTRY");
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

                    btn_Save.Visible = false;
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
                LoadMissionandAboutus();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_MissionAboutUs", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadMissionandAboutus()
    {
        try
        {
            _obj_SMHR_MISSION_ABOUTUS = new SMHR_MISSION_ABOUTUS();
            _obj_SMHR_MISSION_ABOUTUS.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_MISSION_ABOUTUS.OPERATION = operation.Select;
            DataTable dt = BLL.get_MISSION_ABOUTUS(_obj_SMHR_MISSION_ABOUTUS);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (Convert.ToBoolean(dr["MISSION_ABOUTUS_ISASSEMBLY"]))
                    {
                        hdnAssemblyMissionID.Value = dr["MISSION_ABOUTUS_ID"].ToString();
                        rtxtAssemblyMission.Text = dr["MISSION_ABOUTUS_MISSIONDESC"].ToString();
                        rtxtAssemblyAboutUs.Text = dr["MISSION_ABOUTUS_ABOUTUSDESC"].ToString();
                        btn_Save.Visible = false;
                        btn_Update.Visible = true;
                    }
                    else
                    {
                        hdnSenateMissionID.Value = dr["MISSION_ABOUTUS_ID"].ToString();
                        rtxtSenateMission.Text = dr["MISSION_ABOUTUS_MISSIONDESC"].ToString();
                        rtxtSenateAboutUs.Text = dr["MISSION_ABOUTUS_ABOUTUSDESC"].ToString();
                        btnSenate_Save.Visible = false;
                        btnSenate_Update.Visible = true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_MissionAboutUs", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_SMHR_MISSION_ABOUTUS = new SMHR_MISSION_ABOUTUS();
            if (rts_TabStrip.SelectedIndex == 0)
            {
                _obj_SMHR_MISSION_ABOUTUS.MISSION_ABOUTUS_ISASSEMBLY = true;
            }
            else
            {
                _obj_SMHR_MISSION_ABOUTUS.MISSION_ABOUTUS_ISASSEMBLY = false;
            }
            _obj_SMHR_MISSION_ABOUTUS.MISSION_ABOUTUS_ABOUTUSDESC = BLL.ReplaceQuote(rtxtAssemblyAboutUs.Text);
            _obj_SMHR_MISSION_ABOUTUS.MISSION_ABOUTUS_MISSIONDESC = BLL.ReplaceQuote(rtxtAssemblyMission.Text);
            _obj_SMHR_MISSION_ABOUTUS.MISSION_ABOUTUS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            _obj_SMHR_MISSION_ABOUTUS.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_SMHR_MISSION_ABOUTUS.CREATEDDATE = DateTime.Now;

            _obj_SMHR_MISSION_ABOUTUS.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_SMHR_MISSION_ABOUTUS.LASTMDFDATE = DateTime.Now;

            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_UPDATE":
                    _obj_SMHR_MISSION_ABOUTUS.MISSION_ABOUTUS_ID = Convert.ToInt32(hdnAssemblyMissionID.Value);
                    _obj_SMHR_MISSION_ABOUTUS.OPERATION = operation.Update;
                    if (BLL.set_MISSION_ABOUTUS(_obj_SMHR_MISSION_ABOUTUS))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Updated");

                    break;
                case "BTN_SAVE":
                    _obj_SMHR_MISSION_ABOUTUS.OPERATION = operation.Insert;
                    if (BLL.set_MISSION_ABOUTUS(_obj_SMHR_MISSION_ABOUTUS))
                    {
                        BLL.ShowMessage(this, "Information Saved Successfully");
                        LoadMissionandAboutus();
                    }
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                default:
                    break;
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_MissionAboutUs", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            rtxtAssemblyMission.Text = string.Empty;
            rtxtAssemblyAboutUs.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_MissionAboutUs", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}