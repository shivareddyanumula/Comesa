using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Data;
using Telerik.Web.UI;
using System.Text;

public partial class Approval_frm_OverTime : System.Web.UI.Page
{
    SMHR_EMPOTTRANS _obj_smhr_empottrans;
    DataTable dt_Details;
    int I_ChkCount = 0;
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("OVERTIME APPROVAL");
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
                    RG_OTpproval.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Approve.Visible = false;
                    btn_Reject.Visible = false;
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
                rtxt_ReportingMgr.Text = Convert.ToString(Session["EMP_ID"]);
                LoadData();
                rdp_ApprovalDate.SelectedDate = DateTime.Now;
                BLL.ChangeDateFormat(Convert.ToString(Session["EMP_ID"]), rdp_ApprovalDate, rdtp_OTDetOTDate);



            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_OverTime", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    private void LoadData()
    {
        try
        {
            _obj_smhr_empottrans = new SMHR_EMPOTTRANS();
            _obj_smhr_empottrans.OPERATION = operation.Empty;
            _obj_smhr_empottrans.EMPOTTRANS_APPROVEDBY = Convert.ToInt32(rtxt_ReportingMgr.Text);
            _obj_smhr_empottrans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = new DataTable();
            dt_Details = BLL.calculate_OT(_obj_smhr_empottrans);
            //dt_Details = BLL.get_EmpOTTrans(_obj_smhr_empottrans);
            RG_OTpproval.DataSource = dt_Details;
            RG_OTpproval.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_OverTime", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Approve_Click(object sender, EventArgs e)
    {
        try
        {
            StringBuilder strQry = new StringBuilder();
            CheckBox chkBox = new CheckBox();
            Label lblID = new Label();
            Label lbl_prddtl_ID = new Label();
            Label lbl_BUID = new Label();
            Label lbl_EMPid = new Label();
            string str = "";
            bool status = false;
            for (int index = 0; index <= RG_OTpproval.Items.Count - 1; index++)
            {
                chkBox = RG_OTpproval.Items[index].FindControl("chk_Choose") as CheckBox;
                if (chkBox.Checked)
                {
                    I_ChkCount = I_ChkCount + 1;
                }
            }
            if (I_ChkCount == 0)
            {
                BLL.ShowMessage(this, "Please Select Employees");
                return;
            }
            for (int index = 0; index <= RG_OTpproval.Items.Count - 1; index++)
            {
                string str1 = "";
                chkBox = RG_OTpproval.Items[index].FindControl("chk_Choose") as CheckBox;
                lblID = RG_OTpproval.Items[index].FindControl("lblempottrans_id") as Label;
                lbl_prddtl_ID = RG_OTpproval.Items[index].FindControl("lblempottrans_prddtl_ID") as Label;
                lbl_BUID = RG_OTpproval.Items[index].FindControl("lblempottrans_BU_ID") as Label;
                lbl_EMPid = RG_OTpproval.Items[index].FindControl("lblempID") as Label;
                if (chkBox.Checked)
                {
                    I_ChkCount = I_ChkCount + 1;
                    if (str == "")
                        str = "" + lblID.Text + "";
                    else
                        str = str + "," + lblID.Text + "";
                    if (str1 == "")
                        str1 = "" + lbl_EMPid.Text + "";

                }
                //if (I_ChkCount == 0)
                //{
                //    BLL.ShowMessage(this, "Please Select Employees");
                //    return;
                //}

                //bool status = false;
                _obj_smhr_empottrans = new SMHR_EMPOTTRANS();
                _obj_smhr_empottrans.EMPOTTRANS_EMPLOYEE = str1;
                _obj_smhr_empottrans.EMPOTTRANS_STATUS = 1;
                _obj_smhr_empottrans.BUID = Convert.ToInt32(lbl_BUID.Text);
                _obj_smhr_empottrans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_smhr_empottrans.EMPOTTRANS_PERIODDTL_ID = Convert.ToInt32(lbl_prddtl_ID.Text);
                _obj_smhr_empottrans.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_smhr_empottrans.LASTMDFDATE = DateTime.Now;
                _obj_smhr_empottrans.MODE = 5;
                strQry.Append("EXEC USP_SMHR_OTCALC ");
                string strQ = " @Mode = '" + _obj_smhr_empottrans.MODE + "'" +
                                           ",@BUID = '" + _obj_smhr_empottrans.BUID + "'" +
                                           ",@OTCALC_EMPID = '" + _obj_smhr_empottrans.EMPOTTRANS_EMPLOYEE + "'" +
                                           ",@EMPOTTRANS_PERIODDTL_ID = '" + _obj_smhr_empottrans.EMPOTTRANS_PERIODDTL_ID + "'" +
                                           ",@OTCALC_STATUS = '" + _obj_smhr_empottrans.EMPOTTRANS_STATUS + "'" +
                                           ",@OTCALC_ORG_ID='" + _obj_smhr_empottrans.ORGANISATION_ID + "'" +
                                           ",@OTCALC_LASTMDFBY = '" + _obj_smhr_empottrans.LASTMDFBY + "'" +
                                           ",@OTCALC_LASTMDFDATE = '" + Convert.ToDateTime(_obj_smhr_empottrans.LASTMDFDATE).ToString("MM/dd/yyyy") + "'";
                strQry.Append(strQ);
                status = BLL.Cal_OTAmount(_obj_smhr_empottrans, strQry.ToString());
                //if (status == true)
                //{
                //    BLL.ShowMessage(this, "Selected Overtime Details Approved");
                //    //LoadData();
                //    //return;
                //}
            }
            if (status == true)
            {
                BLL.ShowMessage(this, "Selected Overtime Details Approved");
                //LoadData();
                //return;
            }

            //if (I_ChkCount == 0)
            //{
            //    BLL.ShowMessage(this, "Please Select Employees");
            //    return;
            //}
            LoadData();
            return;
            //if (string.IsNullOrEmpty(str))
            //{
            //    BLL.ShowMessage(this, "Please Select Employees");
            //    return;
            //}
            //bool status = false;
            //_obj_smhr_empottrans = new SMHR_EMPOTTRANS();
            //_obj_smhr_empottrans.EMPOTTRANS_EMPLOYEE = str;
            //_obj_smhr_empottrans.EMPOTTRANS_STATUS = 1;
            //_obj_smhr_empottrans.BUID = Convert.ToInt32(lbl_BUID.Text);
            //_obj_smhr_empottrans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //_obj_smhr_empottrans.EMPOTTRANS_PERIODDTL_ID = Convert.ToInt32(lbl_prddtl_ID.Text);
            //_obj_smhr_empottrans.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            //_obj_smhr_empottrans.LASTMDFDATE = DateTime.Now;
            //_obj_smhr_empottrans.MODE = 5;
            //strQry.Append("EXEC USP_SMHR_OTCALC ");
            //string strQ = " @Mode = '" + _obj_smhr_empottrans.MODE + "'" +
            //                           ",@BUID = '" + _obj_smhr_empottrans.BUID + "'" +
            //                           ",@OTCALC_EMPID = '" + _obj_smhr_empottrans.EMPOTTRANS_EMPLOYEE + "'" +
            //                           ",@EMPOTTRANS_PERIODDTL_ID = '" + _obj_smhr_empottrans.EMPOTTRANS_PERIODDTL_ID + "'" +
            //                           ",@OTCALC_STATUS = '" + _obj_smhr_empottrans.EMPOTTRANS_STATUS + "'" +
            //                           ",@OTCALC_ORG_ID='" + _obj_smhr_empottrans.ORGANISATION_ID + "'" +
            //                           ",@OTCALC_LASTMDFBY = '" + _obj_smhr_empottrans.LASTMDFBY + "'" +
            //                           ",@OTCALC_LASTMDFDATE = '" + Convert.ToDateTime(_obj_smhr_empottrans.LASTMDFDATE).ToString("MM/dd/yyyy") + "'";
            //strQry.Append(strQ);
            //status = BLL.Cal_OTAmount(_obj_smhr_empottrans,strQry.ToString());
            //if (status == true)
            //{
            //    BLL.ShowMessage(this, "Selected Overtime Details Approved");
            //    LoadData();
            //    return;
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_OverTime", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Reject_Click(object sender, EventArgs e)
    {
        try
        {
            StringBuilder strQry = new StringBuilder();
            CheckBox chkBox = new CheckBox();
            Label lblID = new Label();
            Label lbl_prddtl_ID = new Label();
            Label lbl_BUID = new Label();
            Label lbl_EMPid = new Label();
            int i = 0;
            string str = "";
            bool status = false;
            for (int index = 0; index <= RG_OTpproval.Items.Count - 1; index++)
            {
                string str1 = "";
                chkBox = RG_OTpproval.Items[index].FindControl("chk_Choose") as CheckBox;
                lblID = RG_OTpproval.Items[index].FindControl("lblempottrans_id") as Label;
                lbl_prddtl_ID = RG_OTpproval.Items[index].FindControl("lblempottrans_prddtl_ID") as Label;
                lbl_BUID = RG_OTpproval.Items[index].FindControl("lblempottrans_BU_ID") as Label;
                lbl_EMPid = RG_OTpproval.Items[index].FindControl("lblempID") as Label;
                if (chkBox.Checked)
                {
                    if (str == "")
                        str = "" + lblID.Text + "";
                    else
                        str = str + "," + lblID.Text + "";
                    if (str1 == "")
                        str1 = "" + lbl_EMPid.Text + "";
                }
            }
            if (string.IsNullOrEmpty(str))
            {
                BLL.ShowMessage(this, "Please Select Employees");
                return;
            }
            for (int index = 0; index <= RG_OTpproval.Items.Count - 1; index++)
            {
                string str1 = "";
                chkBox = RG_OTpproval.Items[index].FindControl("chk_Choose") as CheckBox;
                lblID = RG_OTpproval.Items[index].FindControl("lblempottrans_id") as Label;
                lbl_prddtl_ID = RG_OTpproval.Items[index].FindControl("lblempottrans_prddtl_ID") as Label;
                lbl_BUID = RG_OTpproval.Items[index].FindControl("lblempottrans_BU_ID") as Label;
                lbl_EMPid = RG_OTpproval.Items[index].FindControl("lblempID") as Label;
                if (chkBox.Checked)
                {
                    if (str == "")
                        str = "" + lblID.Text + "";
                    else
                        str = str + "," + lblID.Text + "";
                    if (str1 == "")
                        str1 = "" + lbl_EMPid.Text + "";
                }
                //}

                //if (string.IsNullOrEmpty(str))
                //{
                //    BLL.ShowMessage(this, "Please Select Employees");
                //    return;
                //}
                //bool status = false;
                _obj_smhr_empottrans = new SMHR_EMPOTTRANS();
                _obj_smhr_empottrans.EMPOTTRANS_EMPLOYEE = str1;
                _obj_smhr_empottrans.EMPOTTRANS_STATUS = 2;
                _obj_smhr_empottrans.BUID = Convert.ToInt32(lbl_BUID.Text);
                _obj_smhr_empottrans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_smhr_empottrans.EMPOTTRANS_PERIODDTL_ID = Convert.ToInt32(lbl_prddtl_ID.Text);
                _obj_smhr_empottrans.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_smhr_empottrans.LASTMDFDATE = DateTime.Now;
                _obj_smhr_empottrans.MODE = 5;
                strQry.Append("EXEC USP_SMHR_OTCALC");
                string strQ = " @Mode = '" + _obj_smhr_empottrans.MODE + "'" +
                                           ",@BUID = '" + _obj_smhr_empottrans.BUID + "'" +
                                           ",@OTCALC_EMPID = '" + _obj_smhr_empottrans.EMPOTTRANS_EMPLOYEE + "'" +
                                           ",@EMPOTTRANS_PERIODDTL_ID = '" + _obj_smhr_empottrans.EMPOTTRANS_PERIODDTL_ID + "'" +
                                           ",@OTCALC_STATUS = '" + _obj_smhr_empottrans.EMPOTTRANS_STATUS + "'" +
                                           ",@OTCALC_ORG_ID='" + _obj_smhr_empottrans.ORGANISATION_ID + "'" +
                                           ",@OTCALC_LASTMDFBY = '" + _obj_smhr_empottrans.LASTMDFBY + "'" +
                                           ",@OTCALC_LASTMDFDATE = '" + Convert.ToDateTime(_obj_smhr_empottrans.LASTMDFDATE).ToString("MM/dd/yyyy") + "'";
                strQry.Append(strQ);
                status = BLL.Cal_OTAmount(_obj_smhr_empottrans, strQry.ToString());
                //if (status == true)
                //{
                //    BLL.ShowMessage(this, "Selected Overtime Details Rejected");
                //    //LoadData();
                //    //return;
                //}
            }
            if (status == true)
            {
                BLL.ShowMessage(this, "Selected Overtime Details Rejected");
                //LoadData();
                //return;
            }
            LoadData();
            return;
            //_obj_smhr_empottrans.OPERATION = operation.Check;
            //status = BLL.set_EmpOTTrans(_obj_smhr_empottrans);
            //if (status == true)
            //{
            //    BLL.ShowMessage(this, "Selected Overtime Details Rejected");
            //    LoadData();
            //    return;
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_OverTime", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Refresh_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["DASHBOARD"] != null)
            {
                Response.Redirect("~/Security/frm_Dashboradmngr.aspx", false);
            }
            else
            {
                Response.Redirect("~/Masters/Default.aspx", false);
            }
            return;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_OverTime", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void clearControls()
    {
        try
        {
            lbl_OTDetID.Text = string.Empty;
            rcmb_OTDetEmployeeID.SelectedIndex = -1;
            rcmb_OTDetOTType.SelectedIndex = -1;
            rcmb_OTDetPeriodMain.SelectedIndex = -1;
            rcmb_OTDetPeriodDetails.SelectedIndex = -1;
            rdtp_OTDetOTDate.SelectedDate = null;
            rtxt_OTDetOTHours.Text = string.Empty;

            btn_Save.Visible = false;
            btn_Update.Visible = false;
            Rm_AOT_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_OverTime", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_OverTime", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            loadDropdown();
            clearControls();
            DataTable dt = BLL.get_EmpOTTrans(new SMHR_EMPOTTRANS(Convert.ToInt32(Convert.ToString(e.CommandArgument))));
            if (dt.Rows.Count > 0)
            {
                lbl_OTDetID.Text = Convert.ToString(e.CommandArgument);
                rcmb_OTDetEmployeeID.SelectedIndex = rcmb_OTDetEmployeeID.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["EMPOTTRANS_EMPID"]));
                rcmb_OTDetEmployeeID_SelectedIndexChanged(null, null);
                rcmb_OTDetOTType.SelectedIndex = rcmb_OTDetOTType.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["EMPOTTRANS_TYPEID"]));
                rcmb_OTDetPeriodMain.SelectedIndex = rcmb_OTDetPeriodMain.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["PERIODMAIN"]));
                rcmb_OTDetPeriodMain_SelectedIndexChanged(null, null);
                rcmb_OTDetPeriodDetails.SelectedIndex = rcmb_OTDetPeriodDetails.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["EMPOTTRANS_PERIOD_ID"]));
                rdtp_OTDetOTDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["EMPOTTRANS_DATE"]);
                rtxt_OTDetOTHours.Text = Convert.ToString(dt.Rows[0]["EMPOTTRANS_HOURS"]);

                if (Convert.ToString(dt.Rows[0]["EMPOTTRANS_STATUS"]) == "0")
                    btn_Update.Visible = true;
                else
                    BLL.ShowMessage(this, "This Record cannot be editing as it is already " + (Convert.ToString(dt.Rows[0]["EMPOTTRANS_STATUS"]) == "1" ? "Approved" : "Rejected"));

                Rm_AOT_page.SelectedIndex = 1;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_OverTime", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_OTDetEmployeeID_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_OTDetEmployeeID.SelectedItem.Text.ToUpper() != "SELECT")
            {
                SMHR_EMPOTTRANS _obj_Smhr_EmpOTTrans = new SMHR_EMPOTTRANS();
                _obj_Smhr_EmpOTTrans.OPERATION = operation.Insert;
                _obj_Smhr_EmpOTTrans.EMPOTTRANS_EMPID = Convert.ToInt32(rcmb_OTDetEmployeeID.SelectedItem.Value);


                rcmb_OTDetOTType.Items.Clear();
                rcmb_OTDetOTType.DataSource = BLL.get_EmpOTTrans(_obj_Smhr_EmpOTTrans);
                rcmb_OTDetOTType.DataTextField = "OT";
                rcmb_OTDetOTType.DataValueField = "OT_ID";
                rcmb_OTDetOTType.DataBind();
                rcmb_OTDetOTType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

                _obj_Smhr_EmpOTTrans = new SMHR_EMPOTTRANS();
                _obj_Smhr_EmpOTTrans.OPERATION = operation.Check;

                rcmb_OTDetPeriodMain.Items.Clear();
                rcmb_OTDetPeriodMain.DataSource = BLL.get_EmpOTTrans(_obj_Smhr_EmpOTTrans);
                rcmb_OTDetPeriodMain.DataTextField = "PERIOD_NAME";
                rcmb_OTDetPeriodMain.DataValueField = "PERIOD_ID";
                rcmb_OTDetPeriodMain.DataBind();
                rcmb_OTDetPeriodMain.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

            }

            else
            {
                rcmb_OTDetOTType.Items.Clear();
                rcmb_OTDetOTType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

                rcmb_OTDetPeriodMain.Items.Clear();
                rcmb_OTDetPeriodMain.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_OverTime", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_OTDetPeriodMain_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_OTDetPeriodMain.SelectedItem.Text.ToUpper() != "SELECT")
            {
                SMHR_EMPOTTRANS _obj_Smhr_EmpOTTrans = new SMHR_EMPOTTRANS();
                _obj_Smhr_EmpOTTrans.OPERATION = operation.Update;
                _obj_Smhr_EmpOTTrans.EMPOTTRANS_PERIOD_ID = Convert.ToInt32(rcmb_OTDetPeriodMain.SelectedItem.Value);

                rcmb_OTDetPeriodDetails.Items.Clear();
                rcmb_OTDetPeriodDetails.DataSource = BLL.get_EmpOTTrans(_obj_Smhr_EmpOTTrans);
                rcmb_OTDetPeriodDetails.DataTextField = "PRDDTL_NAME";
                rcmb_OTDetPeriodDetails.DataValueField = "PRDDTL_ID";
                rcmb_OTDetPeriodDetails.DataBind();
                rcmb_OTDetPeriodDetails.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
            }
            else
            {
                rcmb_OTDetPeriodDetails.Items.Clear();
                rcmb_OTDetPeriodDetails.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_OverTime", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void loadDropdown()
    {
        try
        {
            SMHR_EMPNOTES _obj_Smhr_EmpNotes = new SMHR_EMPNOTES();
            _obj_Smhr_EmpNotes.OPERATION = operation.Empty;

            rcmb_OTDetEmployeeID.Items.Clear();
            rcmb_OTDetEmployeeID.DataSource = BLL.get_EmpNotes(_obj_Smhr_EmpNotes);
            rcmb_OTDetEmployeeID.DataTextField = "EMPNAME";
            rcmb_OTDetEmployeeID.DataValueField = "EMP_ID";
            rcmb_OTDetEmployeeID.DataBind();
            rcmb_OTDetEmployeeID.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

            rcmb_OTDetOTType.Items.Clear();
            rcmb_OTDetOTType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

            rcmb_OTDetPeriodMain.Items.Clear();
            rcmb_OTDetPeriodMain.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

            rcmb_OTDetPeriodDetails.Items.Clear();
            rcmb_OTDetPeriodDetails.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_OverTime", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_EMPOTTRANS _obj_Smhr_EmpOTTrans = new SMHR_EMPOTTRANS();

            _obj_Smhr_EmpOTTrans.EMPOTTRANS_EMPID = Convert.ToInt32(rcmb_OTDetEmployeeID.SelectedItem.Value);
            _obj_Smhr_EmpOTTrans.EMPOTTRANS_TYPEID = Convert.ToInt32(rcmb_OTDetOTType.SelectedItem.Value);
            _obj_Smhr_EmpOTTrans.EMPOTTRANS_PERIOD_ID = Convert.ToInt32(rcmb_OTDetPeriodDetails.SelectedItem.Value);
            _obj_Smhr_EmpOTTrans.EMPOTTRANS_DATE = Convert.ToDateTime(rdtp_OTDetOTDate.SelectedDate);
            //_obj_Smhr_EmpOTTrans.EMPOTTRANS_HOURS = float.Parse(rtxt_OTDetOTHours.Text);
            _obj_Smhr_EmpOTTrans.EMPOTTRANS_HOURS = Convert.ToInt32(rtxt_OTDetOTHours.Text);
            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_UPDATE":
                    _obj_Smhr_EmpOTTrans.EMPOTTRANS_ID = Convert.ToInt32(lbl_OTDetID.Text);
                    _obj_Smhr_EmpOTTrans.OPERATION = operation.Update;
                    if (BLL.set_EmpOTTrans(_obj_Smhr_EmpOTTrans))
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                case "BTN_SAVE":
                    _obj_Smhr_EmpOTTrans.OPERATION = operation.Insert;
                    if (BLL.set_EmpOTTrans(_obj_Smhr_EmpOTTrans))
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                default:
                    break;
            }
            Rm_AOT_page.SelectedIndex = 0;
            LoadData();
            RG_OTpproval.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_OverTime", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}