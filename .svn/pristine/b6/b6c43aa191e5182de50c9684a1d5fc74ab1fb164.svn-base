using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Masters_frm_userMissionandVission : System.Web.UI.Page
{
    SMHR_MISSION_ABOUTUS _obj_SMHR_MISSION_ABOUTUS = new SMHR_MISSION_ABOUTUS();


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

            LoadMissionandAboutus();
        }
        
            ////code for security privilage
            //Session.Remove("WRITEFACILITY");

            //SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

            //_obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
            //_obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
            //_obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //_obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("COUNTRY");
            //DataTable dtformdtls = BLL.get_LoginInfo(_obj_Smhr_LoginInfo);
            //if (dtformdtls.Rows.Count != 0)
            //{
            //    if ((Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_READ"]) == true) && (Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_WRITE"]) == true))
            //    {
            //        Session["WRITEFACILITY"] = 1;//WHICH MEANS READ AND WRITE
            //    }
            //    else if ((Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_READ"]) == true) && (Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_WRITE"]) == false))
            //    {
            //        Session["WRITEFACILITY"] = 2;//WHICH MEANS READ NO WRITE
            //    }
            //    else if ((Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_READ"]) == false) && (Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_WRITE"]) == false))
            //    {
            //        Session["WRITEFACILITY"] = 3;//WHICH MEANS NO READ AND NO WRITE
            //    }

            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Mission_AboutUs", ex.StackTrace, DateTime.Now);
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
                        lblAssemblyMission.Text = dr["MISSION_ABOUTUS_MISSIONDESC"].ToString();
                        lblAssemblyAboutUs.Text = dr["MISSION_ABOUTUS_ABOUTUSDESC"].ToString();
                    }
                    else
                    {
                        lblSenateMission.Text = dr["MISSION_ABOUTUS_MISSIONDESC"].ToString();
                        lblSenateAboutUs.Text = dr["MISSION_ABOUTUS_ABOUTUSDESC"].ToString();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Mission_AboutUs", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}