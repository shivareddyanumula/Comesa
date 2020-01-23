using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using Telerik.Web.UI;
public partial class Masters_frm_shiftDefinition : System.Web.UI.Page
{
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Shift Definition");//SHIFTDEFINITATION");
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
                    Rg_Shift.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Save.Visible = false;
                    btn_Edit.Visible = false;
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

                LoadGrid();
                Rg_Shift.DataBind();
                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    for (int i = 0; i < Rg_Shift.Items.Count; i++)
                    {
                        LinkButton lnkdel = new LinkButton();
                        lnkdel = (LinkButton)Rg_Shift.Items[i].FindControl("lnk_Delete") as LinkButton;
                        lnkdel.Visible = false;

                    }

                }

                Page.Validate();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_shiftDefinition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            clearControls();
            SMHR_SHIFTDEFINITION _obj_Smhr_ShiftDefinition = new SMHR_SHIFTDEFINITION();
            _obj_Smhr_ShiftDefinition.SHIFT_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            _obj_Smhr_ShiftDefinition.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());

            DataTable dt = BLL.get_ShiftDefinition(_obj_Smhr_ShiftDefinition);

            lbl_ShiftID.Text = Convert.ToString(dt.Rows[0]["SHIFT_ID"]);

            rtxt_ShiftCode.Text = Convert.ToString(dt.Rows[0]["SHIFT_CODE"]);
            rtxt_ShiftDesc.Text = Convert.ToString(dt.Rows[0]["SHIFT_DESC"]);
            rtp_ShiftStartTime.SelectedDate = Convert.ToDateTime(dt.Rows[0]["SHIFT_STARTTIME"]);
            rtp_ShiftEndTime.SelectedDate = Convert.ToDateTime(dt.Rows[0]["SHIFT_ENDTIME"]);

            //code for security
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Edit.Visible = false;

            }

            else
            {
                btn_Edit.Visible = true;
            }
            Rm_Shift_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_shiftDefinition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            clearControls();
            btn_Save.Visible = true;
            Rm_Shift_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_shiftDefinition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    public void LoadGrid()
    {
        try
        {
            SMHR_SHIFTDEFINITION _obj_Smhr_ShiftDefinition = new SMHR_SHIFTDEFINITION();
            _obj_Smhr_ShiftDefinition.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            DataTable DT = BLL.get_ShiftDefinition(_obj_Smhr_ShiftDefinition);
            Rg_Shift.DataSource = DT;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_shiftDefinition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        //  clearControls();


    }
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_SHIFTDEFINITION _obj_Smhr_ShiftDefinition = new SMHR_SHIFTDEFINITION();

            _obj_Smhr_ShiftDefinition.SHIFT_CODE = Convert.ToString(rtxt_ShiftCode.Text);
            _obj_Smhr_ShiftDefinition.SHIFT_DESC = Convert.ToString(rtxt_ShiftDesc.Text);
            _obj_Smhr_ShiftDefinition.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_Smhr_ShiftDefinition.SHIFT_STARTTIME = Convert.ToString(Convert.ToDateTime(rtp_ShiftStartTime.SelectedDate).TimeOfDay);
            _obj_Smhr_ShiftDefinition.SHIFT_ENDTIME = Convert.ToString(Convert.ToDateTime(rtp_ShiftEndTime.SelectedDate).TimeOfDay);

            _obj_Smhr_ShiftDefinition.SHIFT_CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_ShiftDefinition.SHIFT_CREATEDDATE = DateTime.Now;

            _obj_Smhr_ShiftDefinition.SHIFT_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_ShiftDefinition.SHIFT_LASTMDFDATE = DateTime.Now;

            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_EDIT":
                    _obj_Smhr_ShiftDefinition.SHIFT_ID = Convert.ToInt32(lbl_ShiftID.Text);
                    //_obj_Smhr_ShiftDefinition.OPERATION = operation.Check;
                    //if (Convert.ToString(BLL.get_ShiftDefinition(_obj_Smhr_ShiftDefinition).Rows[0]["Count"]) != "1")
                    //{
                    //    BLL.ShowMessage(this, "Shift is already defined with this code");
                    //    return;
                    //}
                    _obj_Smhr_ShiftDefinition.OPERATION = operation.Update;
                    if (BLL.set_ShiftDefinition(_obj_Smhr_ShiftDefinition))
                        BLL.ShowMessage(this, "Information updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");

                    break;
                case "BTN_SAVE":
                    _obj_Smhr_ShiftDefinition.OPERATION = operation.Check;
                    if (Convert.ToString(BLL.get_ShiftDefinition(_obj_Smhr_ShiftDefinition).Rows[0]["Count"]) != "0")
                    {
                        BLL.ShowMessage(this, "Shift Definition With this Name Already Exists");
                        return;
                    }
                    _obj_Smhr_ShiftDefinition.OPERATION = operation.Insert;
                    if (BLL.set_ShiftDefinition(_obj_Smhr_ShiftDefinition))
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                default:
                    break;
            }
            Rm_Shift_page.SelectedIndex = 0;
            LoadGrid();
            Rg_Shift.DataBind();

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_shiftDefinition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void clearControls()
    {
        try
        {
            lbl_ShiftID.Text = string.Empty;
            rtxt_ShiftCode.Text = string.Empty;
            rtxt_ShiftDesc.Text = string.Empty;
            rtp_ShiftStartTime.SelectedDate = null;
            rtp_ShiftEndTime.SelectedDate = null;

            btn_Save.Visible = false;
            btn_Edit.Visible = false;
            Rm_Shift_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_shiftDefinition", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_shiftDefinition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Rg_Shift_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_shiftDefinition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void lnk_Delete_Command(object sender, CommandEventArgs e)
    {
        try
        {
            SMHR_SHIFTDEFINITION _obj_Smhr_ShiftDefinition = new SMHR_SHIFTDEFINITION();
            _obj_Smhr_ShiftDefinition.SHIFT_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            _obj_Smhr_ShiftDefinition.OPERATION = operation.Check;

            if (Convert.ToString(BLL.get_ShiftDefinition(_obj_Smhr_ShiftDefinition).Rows[0]["Count"]) != "0")
            {
                BLL.ShowMessage(this, "This Shift is Already assigned to Employee, so cannot be deleted");
                return;
            }


            _obj_Smhr_ShiftDefinition.OPERATION = operation.Delete;
            if (BLL.set_ShiftDefinition(_obj_Smhr_ShiftDefinition))
                BLL.ShowMessage(this, "Deleted Successfully");

            else
                BLL.ShowMessage(this, "Deletion failed");
            LoadGrid();
            Rg_Shift.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_shiftDefinition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
}
