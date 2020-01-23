using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using Telerik.Web.UI;

public partial class Masters_frm_PeriodType : System.Web.UI.Page
{
    protected SMHR_PERIODTYPE _obj_smhr_periodtype;
    DataTable dt;

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (!Page.IsPostBack)
            {
                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Salary Structure");//SALARYSTRUCTURE");
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
                    Rg_PeriodType.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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

                Page.Validate();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PeriodType", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void LoadGrid()
    {
        try
        {
            dt = BLL.get_PeriodType(new SMHR_PERIODTYPE());
            Rg_PeriodType.DataSource = dt;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PeriodType", ex.StackTrace, DateTime.Now);
        }
    }

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }
    protected void Rg_PeriodType_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PeriodType", ex.StackTrace, DateTime.Now);
        }
    }
    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            Rm_PT_page.SelectedIndex = 1;
            btn_Save.Visible = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PeriodType", ex.StackTrace, DateTime.Now);
        }

    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            _obj_smhr_periodtype = new SMHR_PERIODTYPE();

            _obj_smhr_periodtype.PERIODTYPE_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            lbl_PeriodTypeID.Text = Convert.ToString(e.CommandArgument);
            dt = BLL.get_PeriodType(_obj_smhr_periodtype);

            rtxt_PeriodTypeCode.Text = Convert.ToString(dt.Rows[0]["PERIODTYPE_NAME"]);
            rtxt_noofdays.Text = Convert.ToString(dt.Rows[0]["PERIODTYPE_NOOFDAYS"]);

            btn_Edit.Visible = true;
            Rm_PT_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PeriodType", ex.StackTrace, DateTime.Now);
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_smhr_periodtype = new SMHR_PERIODTYPE();
            _obj_smhr_periodtype.PERIODTYPE_NAME = Convert.ToString(rtxt_PeriodTypeCode.Text);
            _obj_smhr_periodtype.PERIODTYPE_NOOFDAYS = Convert.ToInt32(rtxt_noofdays.Text);
            _obj_smhr_periodtype.PERIODTYPE_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_periodtype.PERIODTYPE_CREATEDDATE = DateTime.Now;
            _obj_smhr_periodtype.PERIODTYPE_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_periodtype.PERIODTYPE_LASTMDFDATE = DateTime.Now;

            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_EDIT":
                    _obj_smhr_periodtype.PERIODTYPE_ID = Convert.ToInt32(lbl_PeriodTypeID.Text);
                    _obj_smhr_periodtype.OPERATION = operation.Check;
                    if (Convert.ToString(BLL.get_PeriodType(_obj_smhr_periodtype).Rows[0]["Count"]) != "1")
                    {
                        BLL.ShowMessage(this, "Period Type with this Name Already Exists");
                        return;
                    }
                    _obj_smhr_periodtype.OPERATION = operation.Update;
                    if (BLL.set_PeriodType(_obj_smhr_periodtype))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");

                    break;
                case "BTN_SAVE":
                    _obj_smhr_periodtype.OPERATION = operation.Check;
                    if (Convert.ToString(BLL.get_PeriodType(_obj_smhr_periodtype).Rows[0]["Count"]) != "0")
                    {
                        BLL.ShowMessage(this, "Period Type with this Name Already Exists");
                        return;
                    }
                    _obj_smhr_periodtype.OPERATION = operation.Insert;
                    if (BLL.set_PeriodType(_obj_smhr_periodtype))
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                default:
                    break;
            }
            Rm_PT_page.SelectedIndex = 0;
            LoadGrid();
            Rg_PeriodType.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PeriodType", ex.StackTrace, DateTime.Now);
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            ClearControls();
            Rm_PT_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PeriodType", ex.StackTrace, DateTime.Now);
        }
    }

    public void ClearControls()
    {
        try
        {
            rtxt_PeriodTypeCode.Text = string.Empty;
            rtxt_noofdays.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PeriodType", ex.StackTrace, DateTime.Now);
        }
    }

    protected void lnk_Delete_Command(object sender, CommandEventArgs e)
    {
        try
        {
            SMHR_PERIODTYPE _obj_smhr_periodtype = new SMHR_PERIODTYPE();
            _obj_smhr_periodtype.PERIODTYPE_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            _obj_smhr_periodtype.PERIODTYPE_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_periodtype.PERIODTYPE_LASTMDFDATE = DateTime.Now;
            _obj_smhr_periodtype.OPERATION = operation.Check;

            if (Convert.ToString(BLL.get_PeriodType(_obj_smhr_periodtype).Rows[0]["Count"]) != "0")
            {
                BLL.ShowMessage(this, "This type is Already assigned to Period, so cannot be deleted");
                return;
            }


            _obj_smhr_periodtype.OPERATION = operation.Delete;
            if (BLL.set_PeriodType(_obj_smhr_periodtype))
                BLL.ShowMessage(this, "Deleted Successfully");

            else
                BLL.ShowMessage(this, "Deletion failed");
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PeriodType", ex.StackTrace, DateTime.Now);
        }
    }
}
