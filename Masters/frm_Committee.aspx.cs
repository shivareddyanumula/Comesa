using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Masters_frm_Committee : System.Web.UI.Page
{
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }
    SMHR_COMMITTEE _obj_Smhr_Committee;
    static int OrganizationID = 0;
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("COMMITTEE");
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
                    Rg_COMMITTEE.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Save.Visible = false;
                    btn_Update.Visible = false;
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
                OrganizationID = Convert.ToInt32(Session["ORG_ID"].ToString());

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Committee", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


    }
    protected void Rg_COMMITTEE_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Committee", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    public void LoadGrid()
    {
        try
        {
            _obj_Smhr_Committee = new SMHR_COMMITTEE();
            _obj_Smhr_Committee.COMMITTEE_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT = BLL.get_Committee(_obj_Smhr_Committee).Tables[0];
            Rg_COMMITTEE.DataSource = DT;

            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Committee", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void clearControls()
    {
        try
        {
            lbl_CommiteeID.Text = string.Empty;
            rtxt_CommiteeName.Text = string.Empty;
            rtxt_CommiteeName.Enabled = true;
            rtxt_CommitteeDesc.Text = string.Empty;
            rcmb_CommitteeEmployees.Text = string.Empty;
            lstEmployees.Items.Clear();

            rtxt_Review.Text = string.Empty;
            rtxt_CommitteeReason.Text = string.Empty;
            rtxt_CommitteeOutcome.Text = string.Empty;

            rdtp_CommitteeStartDate.SelectedDate = null;
            rdtp_CommitteeEndDate.SelectedDate = null;

            rcmb_Status.SelectedIndex = 0;

            btn_Save.Visible = false;
            btn_Update.Visible = false;
            Rm_CY_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Committee", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            clearControls();
            btn_Save.Visible = true;
            Rm_CY_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Committee", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            clearControls();
            _obj_Smhr_Committee = new SMHR_COMMITTEE();
            _obj_Smhr_Committee.COMMITTEE_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            _obj_Smhr_Committee.COMMITTEE_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataSet dt = BLL.get_Committee(_obj_Smhr_Committee);

            rtxt_CommiteeName.Enabled = false;
            lbl_CommiteeID.Text = Convert.ToString(dt.Tables[0].Rows[0]["COMMITTEE_ID"]);
            rtxt_CommiteeName.Text = Convert.ToString(dt.Tables[0].Rows[0]["COMMITTEE_CODE"]);
            rtxt_CommitteeDesc.Text = Convert.ToString(dt.Tables[0].Rows[0]["COMMITTEE_DESC"]);


            rcmb_CommitteeEmployees.SelectedValue = Convert.ToString(dt.Tables[0].Rows[0]["COMMITTEE_EMP_ID"]);
            rtxt_CommitteeReason.Text = Convert.ToString(dt.Tables[0].Rows[0]["COMMITTEE_REASON"]);
            rtxt_Review.Text = Convert.ToString(dt.Tables[0].Rows[0]["COMMITTEE_REVIEW"]);
            rtxt_CommitteeOutcome.Text = Convert.ToString(dt.Tables[0].Rows[0]["COMMITTEE_OUTCOME"]);

            rcmb_Status.SelectedValue = Convert.ToBoolean(dt.Tables[0].Rows[0]["COMMITTEE_STATUS"]) == true ? "1" : "0";
            if (dt.Tables[0].Rows[0]["COMMITTEE_STARTDATE"] != string.Empty)
                rdtp_CommitteeStartDate.SelectedDate = Convert.ToDateTime(dt.Tables[0].Rows[0]["COMMITTEE_STARTDATE"]);
            if (dt.Tables[0].Rows[0]["COMMITTEE_ENDDATE"] != string.Empty)
                rdtp_CommitteeEndDate.SelectedDate = Convert.ToDateTime(dt.Tables[0].Rows[0]["COMMITTEE_ENDDATE"]);

            lstEmployees.DataSource = dt.Tables[1];
            lstEmployees.DataBind();

            //code for security
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Update.Visible = false;
            }
            else
            {
                btn_Update.Visible = true;
            }
            Rm_CY_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Committee", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    [WebMethod]
    public static RadComboBoxItemData[] GET_EmployeeBySearchString(object context)
    {
        DataTable dtEMPData = new DataTable();
        List<RadComboBoxItemData> result = new List<RadComboBoxItemData>();
        try
        {
            IDictionary<string, object> contextDictionary = (IDictionary<string, object>)context;

            string filterString = ((string)contextDictionary["FilterString"]).Length > 2 ? ((string)contextDictionary["FilterString"]).ToLower() : "";

            dtEMPData = BLL.get_EmployeeBySearchString(OrganizationID, filterString);

           // List<RadComboBoxItemData> result = new List<RadComboBoxItemData>(dtEMPData.Rows.Count);
            foreach (DataRow row in dtEMPData.Rows)
            {
                RadComboBoxItemData itemData = new RadComboBoxItemData();
                itemData.Text = row["EMPNAME"].ToString();
                itemData.Value = row["EMP_ID"].ToString();
                result.Add(itemData);
            }
            //return result.ToArray();
        }
           
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(HttpContext.Current.Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Catagory", ex.StackTrace, DateTime.Now);
            HttpContext.Current.Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return result.ToArray(); 
    }
    protected void rcmb_CommitteeEmployee_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {

    }
    protected void btn_AddEmployees_Click(object sender, EventArgs e)
    {
        try
        {
            if (rcmb_CommitteeEmployees.SelectedValue == string.Empty)
            {
                BLL.ShowMessage(this, "Please Select Committee Member");
                return;
            }
            ListItem item = new ListItem();

            item.Value = rcmb_CommitteeEmployees.SelectedValue;
            item.Text = rcmb_CommitteeEmployees.Text;

            if (lstEmployees.Items.Contains(item))
            {
                BLL.ShowMessage(this, "  Member Already Added");
                return;
            }
            lstEmployees.Items.Add(item);
            rcmb_CommitteeEmployees.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Committee", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Committee", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_Smhr_Committee = new SMHR_COMMITTEE();
            _obj_Smhr_Committee.COMMITTEE_CODE = BLL.ReplaceQuote(rtxt_CommiteeName.Text);
            _obj_Smhr_Committee.COMMITTEE_DESC = BLL.ReplaceQuote(rtxt_CommitteeDesc.Text);

            if (lstEmployees.Items.Count == 0)
            {
                BLL.ShowMessage(this, "Please Add Members to Committee");
                return;
            }
            string strEMPIDs = string.Empty;
            foreach (ListItem item in lstEmployees.Items)
            {
                strEMPIDs += item.Value + ",";
            }
            _obj_Smhr_Committee.COMMITTEE_EMP_ID = strEMPIDs;

            _obj_Smhr_Committee.COMMITTEE_REASON = BLL.ReplaceQuote(rtxt_CommitteeReason.Text);
            _obj_Smhr_Committee.COMMITTEE_REVIEW = BLL.ReplaceQuote(rtxt_Review.Text);
            _obj_Smhr_Committee.COMMITTEE_OUTCOME = BLL.ReplaceQuote(rtxt_CommitteeOutcome.Text);
            _obj_Smhr_Committee.COMMITTEE_STATUS = rcmb_Status.SelectedValue == "1" ? true : false;
            _obj_Smhr_Committee.COMMITTEE_STARTDATE = rdtp_CommitteeStartDate.SelectedDate.ToString();
            _obj_Smhr_Committee.COMMITTEE_ENDDATE = rdtp_CommitteeEndDate.SelectedDate.ToString();
            _obj_Smhr_Committee.COMMITTEE_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //_obj_Smhr_Committee.COMMITTEE_COMMITTEE_ID = Convert.ToInt32(rcmb_Country.SelectedValue);
            _obj_Smhr_Committee.COMMITTEE_CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_Committee.COMMITTEE_CREATEDDATE = DateTime.Now.ToShortDateString();
            _obj_Smhr_Committee.COMMITTEE_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_Committee.COMMITTEE_LASTMDFDATE = DateTime.Now.ToShortDateString();

            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_UPDATE":
                    _obj_Smhr_Committee.COMMITTEE_ID = Convert.ToInt32(lbl_CommiteeID.Text);
                    _obj_Smhr_Committee.OPERATION = operation.Update;
                    if (BLL.set_Committee(_obj_Smhr_Committee))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Updated");

                    break;
                case "BTN_SAVE":
                    _obj_Smhr_Committee.OPERATION = operation.Check;
                    if (Convert.ToString(BLL.get_Committee(_obj_Smhr_Committee).Tables[0].Rows[0]["Count"]) != "0")
                    {
                        BLL.ShowMessage(this, "Committee Name Already Exists");
                        return;
                    }
                    _obj_Smhr_Committee.OPERATION = operation.Insert;
                    if (BLL.set_Committee(_obj_Smhr_Committee))
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                default:
                    break;
            }
            Rm_CY_page.SelectedIndex = 0;
            LoadGrid();
            Rg_COMMITTEE.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Committee", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_RemoveEmployees_Click(object sender, EventArgs e)
    {
        try
        {
            //foreach (ListItem listItem in lstEmployees.Items)
            //{
            //    if (listItem.Selected)
            //        lstEmployees.Items.Remove(listItem);       //To remove selected items from lstEmployees
            //}
            for (int i = 0; i < lstEmployees.Items.Count; i++)
            {
                if (lstEmployees.Items[i].Selected)
                    lstEmployees.Items.RemoveAt(i);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Committee", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}