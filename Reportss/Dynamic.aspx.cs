using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SMHR;
using Telerik.Web.UI;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Data.OleDb;


public partial class Reportss_Dynamic : System.Web.UI.Page
{
    SMHR_ORGANISATION obj_smhr_Organisation;
    SMHR_BUSINESSUNIT obj_smhr_Businessunit;
    SMHR_PERIOD obj_smhr_Period;
    SMHR_LOGININFO obj_smhr_Logininfo;
    SMHR_EMPLOYEE obj_smhr_employee;
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("DYNAMIC REPORT");
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

                    btn_Generate.Visible = false;


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
                    return;
                }
                LoadBusinessUnit();
                LoadColumns();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Dynamic", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    private void LoadBusinessUnit()
    {
        string qrystrng = string.Empty;
        try
        {
            obj_smhr_Businessunit = new SMHR_BUSINESSUNIT();
            obj_smhr_Logininfo = new SMHR_LOGININFO();
            obj_smhr_Logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            obj_smhr_Logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(obj_smhr_Logininfo);
            rcmbBusinessUnit.DataSource = dt_BUDetails;
            rcmbBusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            rcmbBusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            rcmbBusinessUnit.DataBind();
            //rcmbBusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
          //  rcmbBusinessUnit.Items.Insert(0, new RadComboBoxItem(Convert.ToString(Session["ORG_NAME"])));
            
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Dynamic", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


    }
    private void LoadColumns()
    {
        try
        {
            obj_smhr_employee = new SMHR_EMPLOYEE();
            obj_smhr_employee.OPERATION = operation.FeedBack;
            DataTable dt_Dynamiccolums = BLL.get_EMP(obj_smhr_employee);
            RLB_Colums.DataSource = dt_Dynamiccolums;
            RLB_Colums.DataValueField = "COLUMN_NAME";
            RLB_Colums.DataTextField = "DISPLAY_NAME";
            RLB_Colums.DataBind();
         }
        
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Dynamic", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    private static void ShowCheckedItems(RadListBox listBox, Label label)
    {
        try
        {
            StringBuilder sb = new StringBuilder();
            IList<RadListBoxItem> collection = listBox.CheckedItems;
            foreach (RadListBoxItem item in collection)
            {
                if (sb.Length == 0)
                {
                    sb.Append(item.Value);
                }
                else
                {
                    sb.Append("," + item.Value);
                }
            }

            label.Text = sb.ToString();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(HttpContext.Current.Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Dynamic", ex.StackTrace, DateTime.Now);
            HttpContext.Current.Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Generate_Click(object sender, EventArgs e)
    {
        try
        {
            bool selected = false;
            for (int selecteditems = 0; selecteditems < RLB_Colums.Items.Count; selecteditems++)
            {
                if (RLB_Colums.Items[selecteditems].Checked)
                    selected = true;
            }
            if (!selected)
            {
                BLL.ShowMessage(this, "Please Select Atleast One Employee By");
                return;
            }

            ShowCheckedItems(RLB_Colums, Label1);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToInt32(Session["ORG_ID"]) + "','" + Convert.ToString(rcmbBusinessUnit.SelectedValue) + "','" + Convert.ToString(Label1.Text) + "');", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Dynamic", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            RadListBox chk = new RadListBox();
            if (chkcheckall.Checked)
            {
                for (int index = 0; index < RLB_Colums.Items.Count; index++)
                {
                    RLB_Colums.Items[index].Checked = true;
                       
                }
            }
            else
            {
                for (int index = 0; index < RLB_Colums.Items.Count; index++)
                {
                    RLB_Colums.Items[index].Checked = false;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Dynamic", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            RLB_Colums.ClearChecked();
            rcmbBusinessUnit.SelectedIndex = 0;
            chkcheckall.Checked = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Dynamic", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

}