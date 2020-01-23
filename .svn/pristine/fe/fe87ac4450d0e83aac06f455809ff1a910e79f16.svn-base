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

public partial class Payroll_frm_TDS_Consultant : System.Web.UI.Page
{
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    //public string masterType = string.Empty;
    SMHR_TDS_CONSULTANT _obj_smhr_tds_consultant;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TDS_Consultant", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            clearControls();
            LoadComboEdit();
            _obj_smhr_tds_consultant = new SMHR_TDS_CONSULTANT();
            _obj_smhr_tds_consultant.TDS_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            DataTable dt = BLL.get_TDS_CONSULTANT(_obj_smhr_tds_consultant);
            lbl_TDS_Consultant_ID.Text = Convert.ToString(dt.Rows[0]["TDS_ID"]);
            rcmb_TDS_Consultant_CtryCode.SelectedValue = Convert.ToString(dt.Rows[0]["TDS_COUNTRY_ID"]);
            rcmb_TDS_Consultant_CtryCode.Enabled = false;
            rntxt_TDS_Consultant_Value.Value = Convert.ToDouble(dt.Rows[0]["TDS_Value"]);

            btn_Edit.Visible = true;
            RM_TDS_Consultant_Page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TDS_Consultant", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            clearControls();
            LoadComboAdd();
            rcmb_TDS_Consultant_CtryCode.Enabled = true;
            btn_Save.Visible = true;
            RM_TDS_Consultant_Page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TDS_Consultant", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    public void LoadGrid()
    {
        try
        {
            _obj_smhr_tds_consultant = new SMHR_TDS_CONSULTANT();
            //_obj_smhr_tds_consultant.OPERATION = operation.Select;
            _obj_smhr_tds_consultant.OPERATION = operation.Check1;
            _obj_smhr_tds_consultant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT = BLL.get_TDS_CONSULTANT(_obj_smhr_tds_consultant);
            Rg_TDS_Consultant.DataSource = DT;
            //Rg_TDS_Consultant.DataBind();
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TDS_Consultant", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void LoadComboAdd()
    {
        try
        {
            _obj_smhr_tds_consultant = new SMHR_TDS_CONSULTANT();
            //_obj_smhr_tds_consultant.OPERATION = operation.Check;
            _obj_smhr_tds_consultant.OPERATION = operation.Validate1;
            _obj_smhr_tds_consultant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT = BLL.get_TDS_CONSULTANT(_obj_smhr_tds_consultant);
            rcmb_TDS_Consultant_CtryCode.DataSource = DT;
            rcmb_TDS_Consultant_CtryCode.DataTextField = "COUNTRY_CODE";
            rcmb_TDS_Consultant_CtryCode.DataValueField = "COUNTRY_ID";
            rcmb_TDS_Consultant_CtryCode.DataBind();
            rcmb_TDS_Consultant_CtryCode.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TDS_Consultant", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void LoadComboEdit()
    {
        try
        {
            _obj_smhr_tds_consultant = new SMHR_TDS_CONSULTANT();
            _obj_smhr_tds_consultant.OPERATION = operation.Validate;
            DataTable DT = BLL.get_TDS_CONSULTANT(_obj_smhr_tds_consultant);
            rcmb_TDS_Consultant_CtryCode.DataSource = DT;
            rcmb_TDS_Consultant_CtryCode.DataTextField = "COUNTRY_CODE";
            rcmb_TDS_Consultant_CtryCode.DataValueField = "COUNTRY_ID";
            rcmb_TDS_Consultant_CtryCode.DataBind();
            rcmb_TDS_Consultant_CtryCode.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TDS_Consultant", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_smhr_tds_consultant = new SMHR_TDS_CONSULTANT();
            _obj_smhr_tds_consultant.TDS_COUNTRY_ID = Convert.ToInt32(rcmb_TDS_Consultant_CtryCode.SelectedValue);
            _obj_smhr_tds_consultant.TDS_VALUE = Convert.ToDouble(rntxt_TDS_Consultant_Value.Value);

            _obj_smhr_tds_consultant.TDS_CREATED_BY = 1; // ### Need to Get the Session
            _obj_smhr_tds_consultant.TDS_CREATED_DATE = DateTime.Now;

            _obj_smhr_tds_consultant.TDS_LSTMDF_BY = 1; // ### Need to Get the Session
            _obj_smhr_tds_consultant.TDS_LSTMDF_DATE = DateTime.Now;

            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_EDIT":
                    _obj_smhr_tds_consultant.TDS_ID = Convert.ToInt32(lbl_TDS_Consultant_ID.Text);
                    _obj_smhr_tds_consultant.OPERATION = operation.Update;
                    if (BLL.set_TDS_CONSULTANT(_obj_smhr_tds_consultant))
                    {
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Information Not Saved");
                    }

                    break;
                case "BTN_SAVE":
                    _obj_smhr_tds_consultant.OPERATION = operation.Insert;
                    if (BLL.set_TDS_CONSULTANT(_obj_smhr_tds_consultant))
                    {
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Information Not Saved");
                    }
                    break;
                default:
                    break;
            }
            RM_TDS_Consultant_Page.SelectedIndex = 0;
            LoadGrid();
            Rg_TDS_Consultant.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TDS_Consultant", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void clearControls()
    {
        lbl_TDS_Consultant_ID.Text = string.Empty;
        rcmb_TDS_Consultant_CtryCode.SelectedIndex = -1;
        rntxt_TDS_Consultant_Value.Value = 0;

        btn_Save.Visible = false;
        btn_Edit.Visible = false;
        RM_TDS_Consultant_Page.SelectedIndex = 0;
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TDS_Consultant", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Rg_TDS_Consultant_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TDS_Consultant", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        //Rg_TDS_Consultant.DataBind();
    }
}
