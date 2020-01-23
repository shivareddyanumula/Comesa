using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using Telerik.Web.UI;
using System.Xml;

public partial class Payroll_Postings : System.Web.UI.Page
{
    SMHR_PERIOD _obj_smhr_period;
    SMHR_PERIODDTL _obj_smhr_perioddtl;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {

                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("AX POSTINGS");
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
                    btn_Submit.Visible = false;
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
                LoadCombos();
                btn_Generate.Visible = false;
                RG_Details.Visible = false;


            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Postings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadCombos()
    {
        try
        {
            ddl_BusinessUnit.Items.Clear();
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            ddl_BusinessUnit.DataSource = dt_BUDetails;
            ddl_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            ddl_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            ddl_BusinessUnit.DataBind();
            ddl_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));

            _obj_smhr_period = new SMHR_PERIOD();
            _obj_smhr_period.OPERATION = operation.Select;
            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Details = BLL.get_PeriodHeaderDetails(_obj_smhr_period);
            ddl_Period.DataSource = dt_Details;
            ddl_Period.DataValueField = "PERIOD_ID";
            ddl_Period.DataTextField = "PERIOD_NAME";
            ddl_Period.DataBind();
            ddl_Period.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Postings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void ddl_Period_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            LoadDetail_Combo();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Postings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadDetail_Combo()
    {
        try
        {
            if (ddl_Period.SelectedIndex != 0)
            {
                _obj_smhr_perioddtl = new SMHR_PERIODDTL();
                _obj_smhr_perioddtl.OPERATION = operation.Select;
                _obj_smhr_perioddtl.PRDDTL_PERIOD_ID = Convert.ToInt32(ddl_Period.SelectedItem.Value);
                DataTable dt_Details = new DataTable();
                dt_Details = BLL.get_PeriodDetails(_obj_smhr_perioddtl);
                if (dt_Details.Rows.Count != 0)
                {
                    ddl_PeriodDetails.DataSource = dt_Details;
                    ddl_PeriodDetails.DataValueField = "PRDDTL_ID";
                    ddl_PeriodDetails.DataTextField = "PRDDTL_NAME";
                    ddl_PeriodDetails.DataBind();
                    ddl_PeriodDetails.Items.Insert(0, new RadComboBoxItem("Select"));
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Postings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void RG_Details_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            Load_Details();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Postings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void Load_Details()
    {
        try
        {
            DataTable dt = BLL.ExecuteQuery("EXEC USP_SMHR_AX_INTEGRATION @MODE = 1, @PERIOD_ID = '" + ddl_PeriodDetails.SelectedValue + "'" +
                                            ", @GLOBALCONFIG_ORGANISATION_ID = '" + Convert.ToInt32(Session["ORG_ID"]) + "'," +
                                            " @BU_ID = '" + ddl_BusinessUnit.SelectedValue + "'");
            RG_Details.DataSource = dt;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Postings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Submit_Click1(object sender, EventArgs e)
    {
        try
        {
            Load_Details();
            RG_Details.DataBind();

            btn_Generate.Visible = true;
            RG_Details.Visible = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Postings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Generate_Click(object sender, EventArgs e)
    {
        try
        {
            if (RG_Details.Items.Count != 0)
            {
                int i = 0;
                DataTable dtDimension = BLL.ExecuteQuery("SELECT SMHR_AX_BU_ID, SMHR_AX_DIM1, SMHR_AX_DIM2, SMHR_AX_DIM3 FROM SMHR_AX " +
                                            " WHERE SMHR_AX_BU_ID = '" + ddl_BusinessUnit.SelectedValue + "'");

                DataTable dt = BLL.ExecuteQuery("EXEC USP_SMHR_AX_INTEGRATION @MODE = 1, @PERIOD_ID = '" + ddl_PeriodDetails.SelectedValue + "'" +
                                            ", @GLOBALCONFIG_ORGANISATION_ID = '" + Convert.ToInt32(Session["ORG_ID"]) + "'," +
                                            " @BU_ID = '" + ddl_BusinessUnit.SelectedValue + "'");

                string JournalNo = string.Empty;
                if (dt.Rows.Count != 0)
                {
                    DateTime dt1 = DateTime.Now;
                    string FileName1 = string.Empty;
                    string DateVal = dt1.ToString("ddMMyyyy");
                    DataTable dt_1 = BLL.ExecuteQuery("SELECT FILENO FROM SMHR_GLOBALCONFIG WHERE GLOBALCONFIG_ORGANISATION_ID = '" + Convert.ToInt32(Session["ORG_ID"]) + "'");
                    if (dt_1.Rows.Count != 0)
                    {
                        FileName1 = "~//XML//CIL_SMHR_TRN_" + DateVal + "_" + dt_1.Rows[0]["FILENO"] + ".xml";
                        bool status = BLL.ExecuteNonQuery("UPDATE SMHR_GLOBALCONFIG SET FILENO = FILENO + 1 WHERE " +
                                                "GLOBALCONFIG_ORGANISATION_ID = '" + Convert.ToInt32(Session["ORG_ID"]) + "'");
                    }
                    else
                    {
                        FileName1 = "~//XML//CIL_SMHR_TRN_" + DateVal + "_1.xml";
                    }
                    JournalNo = Convert.ToString(dt.Rows[0]["JOURNAL_NO"]);
                    string strPath = Server.MapPath(FileName1);
                    XmlTextWriter myXmlTextWriter = new XmlTextWriter(strPath, null);
                    myXmlTextWriter.Formatting = Formatting.Indented;
                    myXmlTextWriter.WriteStartDocument(false);
                    myXmlTextWriter.WriteStartElement("xml");

                    myXmlTextWriter.WriteStartElement("LedgerJournalTable", null);
                    myXmlTextWriter.WriteElementString("JournalNum", null, Convert.ToString(dt.Rows[0]["JOURNAL_NO"]));
                    myXmlTextWriter.WriteElementString("JournalName", null, "SMHR");
                    myXmlTextWriter.WriteEndElement();

                    /////////// WRITING FOR LEDGER ACCOUNTS

                    for (i = 0; i < dt.Rows.Count; i++)
                    {
                        myXmlTextWriter.WriteStartElement("LedgerJournalTrans", null);
                        myXmlTextWriter.WriteElementString("JournalNum", null, Convert.ToString(dt.Rows[i]["JOURNAL_NO"]));
                        myXmlTextWriter.WriteElementString("LineNum", null, Convert.ToString(i));
                        myXmlTextWriter.WriteElementString("AccountType", null, Convert.ToString(dt.Rows[i]["ACCT_TYPE"]));
                        myXmlTextWriter.WriteElementString("AccountNum", null, Convert.ToString(dt.Rows[i]["PAYITEM_ACCOUNTHEAD"]));
                        myXmlTextWriter.WriteElementString("PostingProfile", null, Convert.ToString(dt.Rows[i]["PAYITEM_POSTINGPROFILE"]));
                        myXmlTextWriter.WriteElementString("Company", null, Convert.ToString(dt.Rows[i]["BU_CODE"]));
                        myXmlTextWriter.WriteElementString("Txt", null, Convert.ToString(dt.Rows[i]["TXT"]));
                        myXmlTextWriter.WriteElementString("AmountCurDebit", null, Convert.ToString(dt.Rows[i]["ACCT_DEBIT"]));
                        myXmlTextWriter.WriteElementString("AmountCurCredit", null, Convert.ToString(dt.Rows[i]["ACCT_CREDIT"]));
                        myXmlTextWriter.WriteElementString("CurrencyCode", null, Convert.ToString(dt.Rows[i]["CURRENCY"]));
                        myXmlTextWriter.WriteElementString("ExchRate", null, Convert.ToString(dt.Rows[i]["EXCH_RATE"]));
                        myXmlTextWriter.WriteElementString("Voucher", null, Convert.ToString(dt.Rows[i]["VOUCHER"]));
                        if (dtDimension.Rows.Count != 0)
                        {
                            myXmlTextWriter.WriteElementString("Dimension1", null, Convert.ToString(dtDimension.Rows[0]["SMHR_AX_DIM1"]));
                            myXmlTextWriter.WriteElementString("Dimension2", null, Convert.ToString(dtDimension.Rows[0]["SMHR_AX_DIM2"]));
                            myXmlTextWriter.WriteElementString("Dimension3", null, Convert.ToString(dtDimension.Rows[0]["SMHR_AX_DIM3"]));
                        }
                        myXmlTextWriter.WriteElementString("TransDate", null, Convert.ToString(dt.Rows[i]["DOC_DATE"]));
                        myXmlTextWriter.WriteElementString("PaymMode", null, Convert.ToString(dt.Rows[i]["MODE_OF_PAY"]));
                        myXmlTextWriter.WriteEndElement();
                    }

                    //Write the XML to file and close the myXmlTextWriter
                    myXmlTextWriter.Flush();
                    myXmlTextWriter.Close();
                    string FileName = "CIL_SMHR_TRN_" + DateVal + "_" + dt_1.Rows[0]["FILENO"] + ".xml";
                    BLL.ShowMessage(this, "XML Generate Successfully named " + FileName + ".xml");
                    clearFields();
                    return;
                }
            }
            else
            {
                BLL.ShowMessage(this, "There is no data to Generate XML");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Postings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void clearFields()
    {
        try
        {
            ddl_PeriodDetails.Items.Clear();
            ddl_PeriodDetails.Items.Insert(0, new RadComboBoxItem("", ""));
            LoadCombos();
            RG_Details.Visible = false;
            btn_Generate.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Postings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            ddl_PeriodDetails.Items.Clear();
            ddl_PeriodDetails.Items.Insert(0, new RadComboBoxItem("", ""));
            LoadCombos();
            RG_Details.Visible = false;
            btn_Generate.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Postings", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
