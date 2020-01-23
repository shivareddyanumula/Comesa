using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using SMHR;
using System.Data;
using Telerik.Web.UI;
public partial class Payroll_frm_comoffrequest : System.Web.UI.Page
{
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_EMPLOYEE _obj_smhr_employee;
    string Control;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
            Control = Convert.ToString(Request.QueryString["Control"]);
            if (!Page.IsPostBack)
            {

                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("COMPENSATORY OFF REQUEST");
                if (Control != null)
                {
                    if (Control.ToUpper() == "SELFCOMP")
                    {
                        _obj_Smhr_LoginInfo.LOGIN_ID = 12;
                    }

                }
                else
                {
                    _obj_Smhr_LoginInfo.LOGIN_ID = 3;
                }
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
                    Rg_CmpOffDet.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Save.Visible = false;
                    btn_Update.Visible = false;
                    // added to support Only-View functionality.
                    foreach (GridColumn col in Rg_CmpOffDet.Columns)
                    {
                        if (col.UniqueName == "ColEdit")
                        {
                            col.Visible = false;
                        }
                    }
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
                BLL.ChangeDateFormat(Convert.ToString(Session["EMP_ID"]), rdtp_Dateofwork, rdp_AppDate);
                BLL.gridDateFormat(Convert.ToString(Session["EMP_ID"]), Rg_CmpOffDet, "EMPCOMPOFF_WORKDAY");
                loaddropdowns();



                //LoadMainGrid();
                Rg_CmpOffDet.DataBind();

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_comoffrequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    protected void LoadMainGrid()
    {
        try
        {
            SMHR_EMPCOMOFF _obj_smhr_empcompoff = new SMHR_EMPCOMOFF();
            _obj_smhr_empcompoff.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_empcompoff.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt = new DataTable();
            dt = BLL.get_empcompffs(_obj_smhr_empcompoff);
            for (int index = 0; index < dt.Rows.Count; index++)
            {
                if (!(Convert.ToString(dt.Rows[index]["COMPOFF_STATUS"]) == "PENDING"))
                {
                    if (Convert.ToString(dt.Rows[index]["APPROVED_BY"]) == string.Empty)
                    {
                        dt.Rows[index]["APPROVED_BY"] = "ADMIN";
                    }
                }
            }
            if (Control != null)
            {
                //if (Session["SELFSERVICE"] == "true")
                if ((Convert.ToString(Session["SELFSERVICE"]) == "true" && Control.ToUpper() == "SELFCOMP") || (Convert.ToString(Session["SELFSERVICE"]) == "" && Control.ToUpper() == "SELFCOMP"))
                {
                    dt.DefaultView.RowFilter = " EMP_ID='" + Convert.ToString(Session["EMP_ID"]) + "'";
                    dt = dt.DefaultView.ToTable();
                }
            }
            Rg_CmpOffDet.DataSource = dt;

            if (Convert.ToInt32(Session["EMP_ID"]) > 0 && Control != null)
            {
                if (Session["DASHBOARD"] != null)
                {
                    //Rm_CMPOFF_page.SelectedIndex = 1;
                    //lnk_Add_Command(null, null);
                }

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_comoffrequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            Session.Remove("EMPCOMPOFF_WORKDAY");
            //load leave type for which CompOff is allowed.
            if (rcmb_Compoff.Items.Count < 2)
            {
                Rm_CMPOFF_page.SelectedIndex = 0;
                BLL.ShowMessage(this, "Please Select Check Comp Off in Leave Master screen for atleast 1 leave type");
                return;
            }
            ///
            rcmb_CmpOffEmployeeID.Items.Clear();
            rcmb_CmpOffEmployeeID.Items.Insert(0, new RadComboBoxItem("", ""));
            SMHR_GLOBALCONFIG _obj_SMHR_GlobalConfig = new SMHR_GLOBALCONFIG();
            _obj_SMHR_GlobalConfig.OPERATION = operation.Validate;
            _obj_SMHR_GlobalConfig.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_ConfigDetails(_obj_SMHR_GlobalConfig);
            Rm_CMPOFF_page.SelectedIndex = 1;
            btn_Save.Visible = true;
            btn_Update.Visible = false;
            if (Convert.ToBoolean(dt.Rows[0]["GLOBALCONFIG_LEAVETRANFLAG"]) == true)
            {
                BLL.ShowMessage(this, "Year end process for leaves is in progress, no comp off request is considered");
                btn_Save.Visible = false;
            }

            //if (Convert.ToInt32(Session["EMP_ID"]) > 0)
            //if (Session["SELFSERVICE"] == "true")
            if (Control != null)
            {
                if ((Convert.ToString(Session["SELFSERVICE"]) == "true" && Control.ToUpper() == "SELFCOMP") || (Convert.ToString(Session["SELFSERVICE"]) == "" && Control.ToUpper() == "SELFCOMP"))
                {
                    SMHR_EMPASSETDOC _obj_smhr_empAssetDoc = new SMHR_EMPASSETDOC();
                    _obj_smhr_empAssetDoc.EMPASSETDOC_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                    _obj_smhr_empAssetDoc.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable Dt_Details = BLL.get_EmpAssetDocBU(_obj_smhr_empAssetDoc);
                    if (Dt_Details.Rows.Count == 1)
                    {
                        rcmb_BusinessUnit.DataSource = Dt_Details;
                        rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
                        rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
                        rcmb_BusinessUnit.DataBind();
                        LoadEmployees();
                        rcmb_CmpOffEmployeeID.SelectedIndex = rcmb_CmpOffEmployeeID.FindItemIndexByValue(Convert.ToString(Session["EMP_ID"]));
                        rcmb_CmpOffEmployeeID.Enabled = false;
                        rcmb_BusinessUnit.Enabled = false;
                    }
                }
            }
            else
            {
                rcmb_BusinessUnit.Enabled = true;
                rcmb_CmpOffEmployeeID.Enabled = true;

            }
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                Rg_CmpOffDet.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                btn_Save.Visible = false;
                btn_Update.Visible = false;
                // added to support Only-View functionality.
                foreach (GridColumn col in Rg_CmpOffDet.Columns)
                {
                    if (col.UniqueName == "ColEdit")
                    {
                        col.Visible = false;
                    }
                }
            }
            rdp_AppDate.SelectedDate = System.DateTime.Now;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_comoffrequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void loaddropdowns()
    {
        try
        {
            //load businessunit.
            rcmb_BusinessUnit.Items.Clear();
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            rcmb_BusinessUnit.DataSource = dt_BUDetails;
            rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BusinessUnit.DataBind();
            rcmb_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));


            //load leave type for which CompOff is allowed.
            SMHR_LEAVEMASTER _obj_smhr_leavemaster = new SMHR_LEAVEMASTER();
            _obj_smhr_leavemaster.OPERATION = operation.Empty;
            _obj_smhr_leavemaster.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtid = new DataTable();
            dtid = BLL.get_LeaveMaster(_obj_smhr_leavemaster);
            rcmb_Compoff.DataSource = dtid;
            rcmb_Compoff.DataValueField = "LEAVEMASTER_ID";
            rcmb_Compoff.DataTextField = "LEAVEMASTER_CODE";
            rcmb_Compoff.DataBind();
            rcmb_Compoff.Items.Insert(0, new RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_comoffrequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_EMPCOMOFF _obj_smhr_compoff = new SMHR_EMPCOMOFF();
            _obj_smhr_compoff.EMPCOMPOFF_WORKDAY = Convert.ToDateTime(rdtp_Dateofwork.SelectedDate);
            _obj_smhr_compoff.EMPCOMPOFF_LOGINTIME = Convert.ToString(Convert.ToDateTime(rtp_LoginTime.SelectedDate).TimeOfDay);
            _obj_smhr_compoff.EMPCOMPOFF_LOGOUTTIME = Convert.ToString(Convert.ToDateTime(rtp_LogoutTime.SelectedDate).TimeOfDay);
            if (Convert.ToDateTime(rtp_LoginTime.SelectedDate).TimeOfDay > Convert.ToDateTime(rtp_LogoutTime.SelectedDate).TimeOfDay)
            {
                BLL.ShowMessage(this, "Login time should be less than Logout time.");
                return;
            }
            _obj_smhr_compoff.EMPCOMPOFF_EMPID = Convert.ToInt32(rcmb_CmpOffEmployeeID.SelectedItem.Value);
            _obj_smhr_compoff.EMPCOMPOFF_DAYS = 1;//Convert.ToInt32(rtxt_NDays.Text);
            //string strTest = rtxt_Reason.Text;
            //StringBuilder sb = new StringBuilder();
            //for (int i = 0; i < strTest.Length; i++)
            //{
            //    if (i % 12 == 0)
            //        sb.Append("</br>");
            //    sb.Append(strTest[i]);
            //}
            //string strReason = sb.ToString();
            //_obj_smhr_compoff.EMPCOMPOFF_REASON = strReason;
            _obj_smhr_compoff.EMPCOMPOFF_REASON = Convert.ToString(BLL.ReplaceQuote(rtxt_Reason.Text));
            _obj_smhr_compoff.EMPCOMPOFF_APPLIEDDATE = Convert.ToDateTime(rdp_AppDate.SelectedDate);
            _obj_smhr_compoff.EMPCOMPOFF_STATUS = 0;
            _obj_smhr_compoff.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_smhr_compoff.CREATEDDATE = DateTime.Now;

            _obj_smhr_compoff.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_smhr_compoff.LASTMDFDATE = DateTime.Now;
            //_obj_smhr_compoff.EMPCOMPOFF_COMPOFFDAY = Convert.ToDateTime(rdtp_compoffday.SelectedDate);
            //DataTable dt_comp = BLL.CheckCompoffDay(_obj_smhr_compoff);
            //if (dt_comp.Rows[0]["RESULT"].ToString() == "1")
            //{
            //    BLL.ShowMessage(this, "Entered Compoff Day is Not a Working Day");
            //    return;
            //}
            DataTable dt_val = BLL.CheckWorkDay(_obj_smhr_compoff);
            _obj_smhr_compoff.EMPCOMPOFF_WORKDAY = Convert.ToDateTime(rdtp_Dateofwork.SelectedDate);
            _obj_smhr_compoff.EMPCOMPOFF_EMPID = Convert.ToInt32(rcmb_CmpOffEmployeeID.SelectedItem.Value);
            _obj_smhr_compoff.EMPCOMPOFF_LEAVETYPE = Convert.ToInt32(rcmb_Compoff.SelectedItem.Value);
            //_obj_smhr_compoff.OPERATION = operation.Validate;
            //if (Convert.ToString(BLL.get_empcompffs(_obj_smhr_compoff).Rows[0]["Count"]) == "1")
            //{
            //    BLL.ShowMessage(this, "Compensatory off is already approved for this work day");
            //    return;
            //}
            if (dt_val.Rows[0]["RESULT"].ToString() == "1")
            {
                switch (((Button)sender).ID.ToUpper())
                {
                    case "BTN_UPDATE":
                        _obj_smhr_compoff.OPERATION = operation.Update;
                        _obj_smhr_compoff.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_smhr_compoff.EMPCOMPOFF_ID = Convert.ToInt32(lbl_CmpDetID.Text);
                        BLL.set_empcompoffs(_obj_smhr_compoff);
                        BLL.ShowMessage(this, "Comp Off Request Updated successfully");
                        break;
                    case "BTN_SAVE":
                        _obj_smhr_compoff.OPERATION = operation.Validate;
                        if (Convert.ToString(BLL.get_empcompffs(_obj_smhr_compoff).Rows[0]["Count"]) == "1")
                        {
                            BLL.ShowMessage(this, "Compensatory off is already approved for this work day");
                            return;
                        }
                        //_obj_smhr_compoff.OPERATION = operation.Validate1;
                        //if (Convert.ToString(BLL.get_empcompffs(_obj_smhr_compoff).Rows[0]["Count"]) == "1")
                        //{
                        //    BLL.ShowMessage(this, "Compensatory off is already applied for this Compoff day");
                        //    return;
                        //}
                        _obj_smhr_compoff.OPERATION = operation.Insert;
                        _obj_smhr_compoff.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        BLL.set_empcompoffs(_obj_smhr_compoff);
                        BLL.ShowMessage(this, "Comp Off Request Submitted successfully");
                        break;
                    default:
                        break;
                }
                clearcontrols();
                Rm_CMPOFF_page.SelectedIndex = 0;
                LoadMainGrid();
                Rg_CmpOffDet.DataBind();
                //clearcontrols();
            }
            else
            {
                BLL.ShowMessage(this, "Not a valid day to apply for Compensatory Off");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_comoffrequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    protected void Rg_CmpOffDet_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadMainGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_comoffrequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            btn_Save.Visible = false;

            SMHR_EMPCOMOFF _obj_smhr_empcompoff = new SMHR_EMPCOMOFF();
            _obj_smhr_empcompoff.OPERATION = operation.Select;
            DataTable dtdet = BLL.get_empcompffs(new SMHR_EMPCOMOFF(Convert.ToInt32(Convert.ToString(e.CommandArgument))));
            loaddropdowns();

            if ((Convert.ToInt32(dtdet.Rows[0]["EMP_STATUS"]) == 0) || (Convert.ToInt32(dtdet.Rows[0]["EMP_STATUS"]) == 1))
            {
                btn_Update.Visible = true;
                _obj_smhr_empcompoff.BUID = Convert.ToInt32(Convert.ToString(dtdet.Rows[0]["BUSINESSUNIT_ID"]));
                _obj_smhr_empcompoff.EMPCOMPOFF_EMPID = Convert.ToInt32(Convert.ToString(dtdet.Rows[0]["EMPCOMPOFF_EMPID"]));
                _obj_smhr_empcompoff.OPERATION = operation.Empty;
                DataTable dtemp = BLL.get_empcompffs(_obj_smhr_empcompoff);
                rcmb_CmpOffEmployeeID.DataSource = dtemp;
                //lbl_Curr.Text = Convert.ToString(dtemp.Rows[0]["CURRENCY"]);
                rcmb_CmpOffEmployeeID.DataTextField = "EMPNAME";
                rcmb_CmpOffEmployeeID.DataValueField = "EMP_ID";
                rcmb_CmpOffEmployeeID.DataBind();
                rcmb_CmpOffEmployeeID.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
                rcmb_CmpOffEmployeeID.SelectedIndex = rcmb_CmpOffEmployeeID.Items.FindItemIndexByValue(Convert.ToString(dtdet.Rows[0]["EMPCOMPOFF_EMPID"]));
            }
            else if ((Convert.ToInt32(dtdet.Rows[0]["EMP_STATUS"]) == 2) || (Convert.ToInt32(dtdet.Rows[0]["EMP_STATUS"]) == 3))
            {
                btn_Update.Visible = false;
                _obj_smhr_empcompoff.BUID = Convert.ToInt32(Convert.ToString(dtdet.Rows[0]["BUSINESSUNIT_ID"]));
                _obj_smhr_empcompoff.EMPCOMPOFF_EMPID = Convert.ToInt32(Convert.ToString(dtdet.Rows[0]["EMPCOMPOFF_EMPID"]));
                _obj_smhr_empcompoff.OPERATION = operation.EMPTY_R;
                DataTable dtemp = BLL.get_empcompffs(_obj_smhr_empcompoff);
                rcmb_CmpOffEmployeeID.DataSource = dtemp;
                //lbl_Curr.Text = Convert.ToString(dtemp.Rows[0]["CURRENCY"]);
                rcmb_CmpOffEmployeeID.DataTextField = "EMPNAME";
                rcmb_CmpOffEmployeeID.DataValueField = "EMP_ID";
                rcmb_CmpOffEmployeeID.DataBind();
                rcmb_CmpOffEmployeeID.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
                rcmb_CmpOffEmployeeID.SelectedIndex = rcmb_CmpOffEmployeeID.Items.FindItemIndexByValue(Convert.ToString(dtdet.Rows[0]["EMPCOMPOFF_EMPID"]));
            }

            lbl_CmpDetID.Text = Convert.ToString(e.CommandArgument);
            rcmb_BusinessUnit.SelectedIndex = rcmb_BusinessUnit.Items.FindItemIndexByValue(Convert.ToString(dtdet.Rows[0]["BUSINESSUNIT_ID"]));
            rdtp_Dateofwork.SelectedDate = Convert.ToDateTime(dtdet.Rows[0]["EMPCOMPOFF_WORKDAY"]);
            Session["EMPCOMPOFF_WORKDAY"] = Convert.ToDateTime(dtdet.Rows[0]["EMPCOMPOFF_WORKDAY"]);
            //if (dtdet.Rows[0]["EMPCOMPOFF_COMPOFFDAY"] != System.DBNull.Value)
            //{
            //    rdtp_compoffday.SelectedDate = Convert.ToDateTime(dtdet.Rows[0]["EMPCOMPOFF_COMPOFFDAY"]);
            //}
            //else
            //{
            //    rdtp_compoffday.SelectedDate = null;
            //}
            rtp_LoginTime.SelectedDate = Convert.ToDateTime(dtdet.Rows[0]["EMPCOMPOFF_LOGINTIME"]);
            rtp_LogoutTime.SelectedDate = Convert.ToDateTime(dtdet.Rows[0]["EMPCOMPOFF_LOGOUTTIME"]);
            rtxt_NDays.Text = Convert.ToString(dtdet.Rows[0]["EMPCOMPOFF_DAYS"]);
            bool result = Convert.ToString(dtdet.Rows[0]["EMPCOMPOFF_REASON"]).Contains("</br>");
            string strReason = string.Empty;
            if (result)
            {
                strReason = Convert.ToString(dtdet.Rows[0]["EMPCOMPOFF_REASON"]).Replace("</br>", "");
            }
            else
            {
                strReason = Convert.ToString(dtdet.Rows[0]["EMPCOMPOFF_REASON"]);
            }
            rtxt_Reason.Text = strReason;
            //rtxt_Reason.Text = Convert.ToString(dtdet.Rows[0]["EMPCOMPOFF_REASON"]);
            rdp_AppDate.SelectedDate = Convert.ToDateTime(dtdet.Rows[0]["EMPCOMPOFF_APPLIEDDATE"]);
            rcmb_Compoff.SelectedIndex = rcmb_Compoff.FindItemIndexByValue(Convert.ToString(dtdet.Rows[0]["EMPCOMPOFF_LEAVETYPE"]));
            if (Convert.ToInt32(dtdet.Rows[0]["EMPCOMPOFF_STATUS"]) == 0)
            {
                Rm_CMPOFF_page.SelectedIndex = 1;
                if ((Convert.ToInt32(Session["WRITEFACILITY"]) == 2) || ((Convert.ToInt32(dtdet.Rows[0]["EMP_STATUS"]) == 2) || (Convert.ToInt32(dtdet.Rows[0]["EMP_STATUS"]) == 3)))
                {

                    btn_Update.Visible = false;


                }

                else
                {
                    btn_Update.Visible = true;

                }

                rcmb_BusinessUnit.Enabled = false;
                rcmb_CmpOffEmployeeID.Enabled = false;
            }
            else
            {
                if (Convert.ToString(dtdet.Rows[0]["EMPCOMPOFF_STATUS"]) == "2")
                {
                    BLL.ShowMessage(this, " Request had already been rejected, cannot be edited");
                }
                else
                {
                    BLL.ShowMessage(this, " Request had already been approved, cannot be edited");
                }
                Rm_CMPOFF_page.SelectedIndex = 1;
                btn_Update.Visible = false;
                EnabledFields(false);
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_comoffrequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void clearcontrols()
    {
        try
        {
            rcmb_BusinessUnit.SelectedIndex = -1;
            rcmb_CmpOffEmployeeID.SelectedIndex = -1;
            rcmb_Compoff.SelectedIndex = -1;
            rdtp_Dateofwork.SelectedDate = null;
            //rdtp_compoffday.SelectedDate = null;
            rdp_AppDate.SelectedDate = null;
            rtp_LoginTime.SelectedDate = null;
            rtp_LogoutTime.SelectedDate = null;
            rtxt_NDays.Text = string.Empty;
            rtxt_Reason.Text = string.Empty;
            btn_Save.Visible = false;
            EnabledFields(true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_comoffrequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearcontrols();
            bool status = Convert.ToBoolean(Session["checkRole"]);
            //if (Session["DASHBOARD"] != null)
            //{
            //    if (status == true)
            //    {

            //        Response.Redirect("~/Security/frm_Dashboard.aspx", false);
            //    }
            //    else
            //    {

            //        Response.Redirect("~/Security/frm_Dashboradmngr.aspx", false);
            //    }
            //}
            //else
            //{
            Rm_CMPOFF_page.SelectedIndex = 0;
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_comoffrequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //protected void rcmb_BusinessUnit_SelectedIndexChanged1(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    //{
    //    rcmb_CmpOffEmployeeID.Items.Clear();
    //    SMHR_EMPCOMOFF _obj_smhr_compoff = new SMHR_EMPCOMOFF();
    //    _obj_smhr_compoff.BUID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
    //    _obj_smhr_compoff.OPERATION = operation.Empty;

    //    rcmb_CmpOffEmployeeID.DataSource = BLL.get_empcompffs(_obj_smhr_compoff);
    //    rcmb_CmpOffEmployeeID.DataTextField = "EMPNAME";
    //    rcmb_CmpOffEmployeeID.DataValueField = "EMP_ID";
    //    rcmb_CmpOffEmployeeID.DataBind();
    //    rcmb_CmpOffEmployeeID.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
    //}

    private void LoadEmployees()
    {
        try
        {

            //if (Convert.ToString(Session["SELFSERVICE"]) == "")
            //{
            //    //FOR MANAGER
            //    rcmb_CmpOffEmployeeID.Items.Clear();
            //    SMHR_EMPCOMOFF _obj_smhr_compoff = new SMHR_EMPCOMOFF();
            //    _obj_smhr_compoff.BUID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
            //    _obj_smhr_compoff.EMPCOMPOFF_EMPID = Convert.ToInt32(Session["EMP_ID"]);
            //    _obj_smhr_compoff.OPERATION = operation.Empty_Self;

            //    rcmb_CmpOffEmployeeID.DataSource = BLL.get_empcompffs(_obj_smhr_compoff);
            //    rcmb_CmpOffEmployeeID.DataTextField = "EMPNAME";
            //    rcmb_CmpOffEmployeeID.DataValueField = "EMP_ID";
            //    rcmb_CmpOffEmployeeID.DataBind();
            //    rcmb_CmpOffEmployeeID.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
            //}
            //else
            //{
            //FRO ADMIN
            rcmb_CmpOffEmployeeID.Items.Clear();
            SMHR_EMPCOMOFF _obj_smhr_compoff = new SMHR_EMPCOMOFF();
            _obj_smhr_compoff.BUID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
            _obj_smhr_compoff.OPERATION = operation.Empty;

            rcmb_CmpOffEmployeeID.DataSource = BLL.get_empcompffs(_obj_smhr_compoff);
            rcmb_CmpOffEmployeeID.DataTextField = "EMPNAME";
            rcmb_CmpOffEmployeeID.DataValueField = "EMP_ID";
            rcmb_CmpOffEmployeeID.DataBind();
            rcmb_CmpOffEmployeeID.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_comoffrequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_BusinessUnit_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            LoadEmployees();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_comoffrequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void EnabledFields(bool b)
    {
        try
        {
            rcmb_BusinessUnit.Enabled = b;
            rcmb_CmpOffEmployeeID.Enabled = b;
            rdtp_Dateofwork.Enabled = b;
            rdp_AppDate.Enabled = b;
            rtp_LoginTime.Enabled = b;
            rtp_LogoutTime.Enabled = b;
            rtxt_NDays.Enabled = b;
            rtxt_Reason.Enabled = b;
            rcmb_Compoff.Enabled = b;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_comoffrequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_CmpOffEmployeeID_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            ////if (rcmb_CmpOffEmployeeID.SelectedIndex > 0)
            ////{
            ////    rdtp_Dateofwork.Enabled = true;
            ////}
            SMHR_EMPTRANSFER _obj_Emptransfer = new SMHR_EMPTRANSFER();
            _obj_Emptransfer.EMP_EMPID = Convert.ToInt32(rcmb_CmpOffEmployeeID.SelectedValue.ToString());
            _obj_Emptransfer.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable Dt_loadcombos = BLL.get_Employeelist(_obj_Emptransfer);
            rdp_AppDate.MinDate = Convert.ToDateTime(Dt_loadcombos.Rows[0]["EMP_DOJ"]);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_comoffrequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }




    protected void rdtp_Dateofwork_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        try
        {
            if (rdtp_Dateofwork.SelectedDate < System.DateTime.Now)
            {
                _obj_smhr_employee = new SMHR_EMPLOYEE();
                if (Convert.ToInt32(rcmb_CmpOffEmployeeID.SelectedIndex) == 0)
                {
                    BLL.ShowMessage(this, "Please Select Employee");
                    rdtp_Dateofwork.SelectedDate = null;
                    return;
                }
                _obj_smhr_employee.EMPWOFF_EMP_ID = Convert.ToInt32(rcmb_CmpOffEmployeeID.SelectedValue.ToString());
                _obj_smhr_employee.OPERATION = operation.Check;
                DataTable dt = BLL.get_EmpWeeklyoff(_obj_smhr_employee);
                if (dt.Rows.Count > 0 && Convert.ToString(dt.Rows[0]["EMPWOFF_EFFDATE"]) != string.Empty)
                {
                    if ((Convert.ToDateTime(rdtp_Dateofwork.SelectedDate)) < (Convert.ToDateTime(Convert.ToString(dt.Rows[0]["EMPWOFF_EFFDATE"]))))
                    {
                        BLL.ShowMessage(this, "Not a valid date");
                        if (Convert.ToString(Session["EMPCOMPOFF_WORKDAY"]) == "")
                        {
                            rdtp_Dateofwork.SelectedDate = null;
                            rtxt_NDays.Text = string.Empty;
                        }
                        else
                        {
                            rdtp_Dateofwork.SelectedDate = Convert.ToDateTime(Session["EMPCOMPOFF_WORKDAY"]);
                        }
                        return;
                    }
                }
                else
                {
                    BLL.ShowMessage(this, "Not a valid date");
                    rdtp_Dateofwork.SelectedDate = null;
                    rtxt_NDays.Text = string.Empty;
                    return;
                }
                rtxt_NDays.Text = "1";
            }
            else
            {
                BLL.ShowMessage(this, "Not a Valid Date");
                if (Convert.ToString(Session["EMPCOMPOFF_WORKDAY"]) == "")
                {
                    rdtp_Dateofwork.SelectedDate = null;
                    rtxt_NDays.Text = string.Empty;
                }
                else
                {
                    rdtp_Dateofwork.SelectedDate = Convert.ToDateTime(Session["EMPCOMPOFF_WORKDAY"]);
                }
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_comoffrequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
