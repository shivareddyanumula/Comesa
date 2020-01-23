using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using SPMS;
using System.Text;

public partial class PMS_frm_GoalSettingKra : System.Web.UI.Page
{
    DataTable dt; 
    GOALSETTING_GOALKRA_DETAILS _obj_Pms_goalkradetails;
    PMS_GOALKRA _obj_Pms_GOALKRA;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            loadgrid_Kra();
            RMP_KraDetails.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GoalSettingKra", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void loadgrid_Kra()
    {
        try
        {
            _obj_Pms_goalkradetails = new GOALSETTING_GOALKRA_DETAILS();
            _obj_Pms_goalkradetails.MODE = 6;
            DataTable dt = Pms_Bll.get_Gskra(_obj_Pms_goalkradetails);
            RG_KraDetails.DataSource = dt;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GoalSettingKra", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Submit_Kra_Click1(object sender, EventArgs e)
    {
        try
        {
            string a;
            int i;
            string str;

            CheckBox chkChoose = new CheckBox();
            Label lbl_Id = new Label();
            Label lbl_name = new Label();
            //DataTable dt_datalist = new DataTable();

            //dt_datalist.Columns.Add("KRAID");
            //dt_datalist.Columns.Add("KRANAME");
            //DataRow row = null;
            string str1 = "";
            //Session["str"] = null;
            for (i = 0; i <= RG_KraDetails.Items.Count - 1; i++)
            {
                chkChoose = RG_KraDetails.Items[i].FindControl("Chb_id") as CheckBox;
                lbl_Id = RG_KraDetails.Items[i].FindControl("lblID") as Label;
                lbl_name = RG_KraDetails.Items[i].FindControl("lbl_name") as Label;
                if (chkChoose.Checked)
                {
                    if (str1 == "")
                        str1 = "" + lbl_Id.Text + "";
                    else
                        str1 = str1 + "," + lbl_Id.Text + "";
                }


            }
            Session["str"] = str1;

            string scriptString = "<script language='JavaScript'> ";
            scriptString = scriptString + " window.opener.document.forms[0].submit(); ";
            scriptString = scriptString + " self.close();";
            scriptString = scriptString + "</script>";
            Page.ClientScript.RegisterStartupScript(typeof(Page), string.Empty, scriptString);
            //ScriptManager.RegisterClientScriptBlock(this,this.GetType(), "script", scriptString,true);

            //Response.Redirect("~/PMS/frm_goalsettings.aspx", false);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "javascript:Close();", true);
            // ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), scriptString, true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GoalSettingKra", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void RG_Kra_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            loadgrid_Kra();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GoalSettingKra", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
}
