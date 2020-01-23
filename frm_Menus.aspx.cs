using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Collections;
using System.Globalization;
using System.Data;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

public partial class frm_Menus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Session["SUPERMODULE_ID"] = null;
                if (Convert.ToInt32(Session["EMP_ID"]) == (-1))
                {
                    Response.Redirect("~/Masters/Default.aspx", false);
                }
                else
                {
                    SMHR_FORMS _obj_Smhr_forms = new SMHR_FORMS();
                    _obj_Smhr_forms.MODE = 7;
                    _obj_Smhr_forms.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dt = BLL.get_Modules(_obj_Smhr_forms);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (Convert.ToInt32(dt.Rows[i]["SMHR_SUP_MODULE_ID"]) == 1)
                            {
                                btn_hrpayroll.Visible = true;
                            }
                            else if (Convert.ToInt32(dt.Rows[i]["SMHR_SUP_MODULE_ID"]) == 2)
                            {
                                btn_pms.Visible = true;
                            }
                            else if (Convert.ToInt32(dt.Rows[i]["SMHR_SUP_MODULE_ID"]) == 3)
                            {
                                btn_training.Visible = true;
                            }
                            else
                            {
                                btn_recruitment.Visible = true;
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Menus", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_hrpayroll_Click(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToString(Session["SELFSERVICE"]) == "ADMIN")
            {
                Response.Redirect("~/Masters/Default.aspx", false);
            }
            else if (Convert.ToString(Session["SELFSERVICE"]) == "true")
            {
                Response.Redirect("~/Security/frm_Dashboard.aspx", false);
            }
            else
            {
                Response.Redirect("~/Security/frm_Dashboradmngr.aspx", false);
            }
            Session["SUPERMODULE_ID"] = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Menus", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_pms_Click(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToString(Session["SELFSERVICE"]) == "ADMIN")
            {
                Response.Redirect("~/Masters/Default.aspx", false);
            }
            else if (Convert.ToString(Session["SELFSERVICE"]) == "true")
            {
                Response.Redirect("~/Security/frm_Dashboard.aspx", false);
            }
            else
            {
                Response.Redirect("~/Security/frm_Dashboradmngr.aspx", false);
            }
            Session["SUPERMODULE_ID"] = 2;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Menus", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_recruitment_Click(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToString(Session["SELFSERVICE"]) == "ADMIN")
            {
                Response.Redirect("~/Masters/Default.aspx", false);
            }
            else if (Convert.ToString(Session["SELFSERVICE"]) == "true")
            {
                Response.Redirect("~/Security/frm_Dashboard.aspx", false);
            }
            else
            {
                Response.Redirect("~/Security/frm_Dashboradmngr.aspx", false);
            }
            Session["SUPERMODULE_ID"] = 4;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Menus", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_training_Click(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToString(Session["SELFSERVICE"]) == "ADMIN")
            {
                Response.Redirect("~/Masters/Default.aspx", false);
            }
            else if (Convert.ToString(Session["SELFSERVICE"]) == "true")
            {
                Response.Redirect("~/Security/frm_Dashboard.aspx", false);
            }
            else
            {
                Response.Redirect("~/Security/frm_Dashboradmngr.aspx", false);
            }
            Session["SUPERMODULE_ID"] = 3;
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Menus", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
