using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Medical_UploadInvoice : System.Web.UI.Page
{
    string strfilename2;
    DataSet ds = new DataSet();
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    public string masterType = string.Empty;
    SMHR_MedicalInvoice oSMHR_MedicalInvoice;
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (RWM_POSTREPLY1.Windows.Count > 0)
            {
                RWM_POSTREPLY1.Windows.RemoveAt(0);
            }
            if (!IsPostBack)
            {

                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Upload Invoice");//CATEGORY");
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
                    Rg_Categories.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
                Page.Validate();
               // Page.Validate();



            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "UploadInvoice", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }



    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {

        try
        {
            clearControls();
            SMHR_MedicalInvoice oSMHR_MedicalInvoice = new SMHR_MedicalInvoice();
            oSMHR_MedicalInvoice.OPERATION = operation.Select;
            oSMHR_MedicalInvoice.InvoiceDocID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            oSMHR_MedicalInvoice.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_MedicalInvoice(oSMHR_MedicalInvoice);

            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Edit.Visible = false;

            }

            else
            {
                btn_Edit.Visible = true;
            }

            Rm_CG_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "UploadInvoice", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            BindServiceProviders();
            clearControls();
            btn_Save.Visible = true;
            Rm_CG_page.SelectedIndex = 1;
            //btn_Save.OnClientClick = "if (!confirm('Are you sure..?It updates with the same data.')) return false";
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "UploadInvoice", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void BindServiceProviders()
    {
        try
        {
            SMHR_SERVICEPROVIDER _obj_Smhr_ServiceProvider = new SMHR_SERVICEPROVIDER();
            _obj_Smhr_ServiceProvider.OPERATION = operation.Select2;
            _obj_Smhr_ServiceProvider.SERVICEPROVIDER_TYPE = "medical";
            _obj_Smhr_ServiceProvider.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT = BLL.get_ServiceProvider(_obj_Smhr_ServiceProvider);
            RadServiceProviderName.DataSource = DT;
            RadServiceProviderName.DataValueField = "SERVICEPROVIDER_ID";
            RadServiceProviderName.DataTextField = "SERVICEPROVIDER_NAME";
            RadServiceProviderName.DataBind();
            RadServiceProviderName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "UploadInvoice", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    public void LoadGrid()
    {
        try
        {

            SMHR_MedicalInvoice oSMHR_MedicalInvoice = new SMHR_MedicalInvoice();
            oSMHR_MedicalInvoice.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            oSMHR_MedicalInvoice.OPERATION = operation.Select;
            DataTable DT = BLL.get_MedicalInvoice(oSMHR_MedicalInvoice);
            Rg_Categories.DataSource = DT;
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "UploadInvoice", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {

        try
        {

            oSMHR_MedicalInvoice = new SMHR_MedicalInvoice();
            bool result = true;
            ValidateData(out oSMHR_MedicalInvoice, out result);
            if (result)
            {
                oSMHR_MedicalInvoice.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                switch (((Button)sender).ID.ToUpper())
                {
                    case "BTN_EDIT":
                        oSMHR_MedicalInvoice.InvoiceDocID = Convert.ToInt32(lbl_InvoiceDocID.Text);
                        oSMHR_MedicalInvoice.OPERATION = operation.Update;
                        if (BLL.set_MedicalInvoice(oSMHR_MedicalInvoice))
                            BLL.ShowMessage(this, "Information Updated Successfully");
                        else
                            BLL.ShowMessage(this, "Information Not Saved");


                        break;
                    case "BTN_SAVE":

                        oSMHR_MedicalInvoice.OPERATION = operation.Insert;
                        if (BLL.set_MedicalInvoice(oSMHR_MedicalInvoice))
                            BLL.ShowMessage(this, "Information Saved Successfully");
                        else
                            BLL.ShowMessage(this, "Information Not Saved");
                        break;
                    default:
                        break;
                }
                Rm_CG_page.SelectedIndex = 0;
                LoadGrid();
                Rg_Categories.DataBind();
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "UploadInvoice", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    private void ValidateData(out SMHR_MedicalInvoice oSMHR_MedicalInvoice, out bool result)
    {
        try
        {
            result = true;
            oSMHR_MedicalInvoice = new SMHR_MedicalInvoice();
            string strfilename = Guid.NewGuid().ToString() + FBrowse.FileName;
            strfilename2 = strfilename;
            if (FBrowse.HasFile)
            {
                FBrowse.PostedFile.SaveAs(Server.MapPath("~/MedicalInvoice/") + strfilename);
            }
            else
            {
                result = false;
                BLL.ShowMessage(this, "Please Select the File to upload");
                return;
            }

            string strpath = Server.MapPath("~/MedicalInvoice/") + strfilename;
            string ExcelPath = System.Configuration.ConfigurationManager.AppSettings["ExcelPath"];//"Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=Excel 8.0;";
            string strcon = ExcelPath + "Data Source='" + strpath + "';";
            DataTable dtExcelData = GetDatafromExcel(strcon);

            if (dtExcelData != null && ValidateHeader(dtExcelData))
            {
                if (dtExcelData.Rows.Count != 0)
                {

                    oSMHR_MedicalInvoice.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    oSMHR_MedicalInvoice.OPERATION = operation.Check;
                    DataTable dtBenficaryDetails = BLL.get_MedicalInvoice(oSMHR_MedicalInvoice);
                    oSMHR_MedicalInvoice.OPERATION = operation.Validate;
                    DataTable dtInvoiceValidate = BLL.get_MedicalInvoice(oSMHR_MedicalInvoice);
                    DataTable dtInvoices = CreateInvoiceTable();
                    SMHR_EXPENDITURE oSMHR_EXPENDITURE = new SMHR_EXPENDITURE();
                    oSMHR_EXPENDITURE.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    oSMHR_EXPENDITURE.OPERATION = operation.Select;
                    DataTable dtexpenditures = BLL.get_Expenditure(oSMHR_EXPENDITURE);
                    foreach (DataRow record in dtExcelData.Rows)
                    {
                        if (!string.IsNullOrEmpty(record["Beneficiary Name"].ToString().Trim()))
                        {
                            if (dtBenficaryDetails.Select("BenficaryName='" + record["Beneficiary Name"].ToString().Trim() + "'").Length == 0)
                            {
                                Delete_Excel_File();
                                result = false;
                                BLL.ShowMessage(this, "Benficary Name not exists");
                                return;
                            }
                        }
                        else
                        {
                            Delete_Excel_File();
                            result = false;
                            BLL.ShowMessage(this, "Benficary Name should not be empty");
                            return;

                        }

                        if (string.IsNullOrEmpty(record["Invoice ID"].ToString().Trim()))
                        {

                            Delete_Excel_File();
                            result = false;
                            BLL.ShowMessage(this, "Invoice ID should not be empty");
                            return;

                        }
                        if (string.IsNullOrEmpty(record["Invoice Date"].ToString().Trim()))
                        {
                            Delete_Excel_File();
                            result = false;
                            BLL.ShowMessage(this, "Invoice Date should not be empty");
                            return;

                        }
                        if (string.IsNullOrEmpty(record["Staff Name"].ToString().Trim()))
                        {
                            Delete_Excel_File();
                            result = false;
                            BLL.ShowMessage(this, "Staff Name should not be empty");
                            return;

                        }
                        if (!string.IsNullOrEmpty(record["Exp Name"].ToString().Trim()))
                        {
                            if (dtexpenditures.Select("expenditure_name='" + record["Exp Name"].ToString().Trim() + "'").Length == 0)
                            {
                                Delete_Excel_File();
                                result = false;
                                BLL.ShowMessage(this, "Exp Name not exists");
                                return;
                            }
                        }
                        else
                        {
                            Delete_Excel_File();
                            result = false;
                            BLL.ShowMessage(this, "Exp Name should not be empty");
                            return;
                        }
                        if (!string.IsNullOrEmpty(record["Service Provider"].ToString().Trim()) && string.Compare(record["Service Provider"].ToString().Trim(), "Select", true) != 0)
                        {
                            if (string.Compare(record["Service Provider"].ToString().Trim(), RadServiceProviderName.SelectedItem.Text.Trim(), true) != 0)
                            {
                                Delete_Excel_File();
                                result = false;
                                BLL.ShowMessage(this, "Service Provider mismatch");
                                return;
                            }
                        }
                        else
                        {
                            Delete_Excel_File();
                            result = false;
                            BLL.ShowMessage(this, "Service Provider should not be empty");
                            return;
                        }
                        if (!string.IsNullOrEmpty(record["Amount"].ToString().Trim()))
                        {
                            double d;
                            if (!double.TryParse(record["Amount"].ToString().Trim(), out d))
                            {
                                Delete_Excel_File();
                                result = false;
                                BLL.ShowMessage(this, "Amount should be a number");
                                return;
                            }
                        }
                        else
                        {
                            Delete_Excel_File();
                            result = false;
                            BLL.ShowMessage(this, "Amount should not be empty");
                            return;
                        }
                        if (dtInvoiceValidate.Select("SERVICEPROVIDERNAME='" + record["Service Provider"].ToString().Trim() + "' and INVOICEID='" + record["Invoice ID"].ToString().Trim() + "'").Length > 0)
                        {
                            Delete_Excel_File();
                            result = false;
                            BLL.ShowMessage(this, "Invoice ID already exists");
                            return;
                        }
                        DateTime drt = new DateTime();
                        try
                        {
                            drt = Convert.ToDateTime(record[1].ToString());
                        }
                        catch (Exception ex)
                        {
                            result = false;
                            BLL.ShowMessage(this, "Date Format should be mm/dd/yyyy");
                        }
                        dtInvoices.Rows.Add(record[0].ToString(), drt.ToString("MM/dd/yyyy"), record[2].ToString(), record[3].ToString(), record[4].ToString(), record[5].ToString(), record[6].ToString());
                    }
                    //if (dtInvoices.Select("Invoice ID='" + record["Exp Name"].ToString().Trim() + "'").Length == 0)
                    //{
                    //}
                    oSMHR_MedicalInvoice.ServiceProviderID = Convert.ToInt32(RadServiceProviderName.SelectedValue);
                    oSMHR_MedicalInvoice.InvoiceDoc = "~/MedicalInvoice/" + strfilename;
                    oSMHR_MedicalInvoice.MedicalInvoice = dtInvoices;
                    oSMHR_MedicalInvoice.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    oSMHR_MedicalInvoice.CREATEDDATE = DateTime.Now;
                    oSMHR_MedicalInvoice.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                }
                else
                {
                    Delete_Excel_File();
                    result = false;
                    BLL.ShowMessage(this, "There are no records to load");
                    return;
                }
            }
            else
            {
                Delete_Excel_File();
                result = false;
                BLL.ShowMessage(this, "Header mismatch");
                return;
            }

        }

        catch (Exception ex)
        {
            throw ex;

        }
    }

    private bool ValidateHeader(DataTable dtExcelData)
    {
        bool flag = false;
        //Invoice ID	Invoice Date	Staff Name	Exp Name	Beneficiary Account	Service Provider	Amount
        try
        {
            if (string.Compare(dtExcelData.Columns[0].ToString().Trim(), "Invoice ID", true) == 0 &&
                string.Compare(dtExcelData.Columns[1].ToString().Trim(), "Invoice Date", true) == 0 &&
                string.Compare(dtExcelData.Columns[2].ToString().Trim(), "Staff Name", true) == 0 &&
                string.Compare(dtExcelData.Columns[3].ToString().Trim(), "Exp Name", true) == 0 &&
                string.Compare(dtExcelData.Columns[4].ToString().Trim(), "Beneficiary Name", true) == 0 &&
                string.Compare(dtExcelData.Columns[5].ToString().Trim(), "Service Provider", true) == 0 &&
                string.Compare(dtExcelData.Columns[6].ToString().Trim(), "Amount", true) == 0)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "UploadInvoice", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return flag;
    }

    private DataTable GetDatafromExcel(string strcon)
    {
        DataSet dsExcelData = new DataSet();
        OleDbConnection objConn = null;
        try
        {
            objConn = new OleDbConnection(strcon);
            objConn.Open();
            DataTable dt_chk2 = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string sheetname;
            if (dt_chk2 != null && dt_chk2.Rows.Count > 0)
            {

                sheetname = Convert.ToString(dt_chk2.Rows[0]["TABLE_NAME"]);
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM  [" + sheetname + "]", strcon);
                da.Fill(dsExcelData);
                objConn.Close();
                return dsExcelData.Tables[0];
            }
            else
            {
                objConn.Close();
                Delete_Excel_File();
            }
        }
        catch (Exception ex)
        {
            // BLL.ShowMessage(this, e.Message);
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "UploadInvoice", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            objConn.Close();
            Delete_Excel_File();
        }
        finally
        {
            objConn.Close();
            // Delete_Excel_File();
        }
        return null;
    }

    private DataTable CreateInvoiceTable()
    {
        DataTable dt = new DataTable();
        try
        {
            dt.Columns.Add("Invoice ID", typeof(string));
            dt.Columns.Add("Invoice Date", typeof(string));
            dt.Columns.Add("Staff Name", typeof(string));
            dt.Columns.Add("Exp Name", typeof(string));
            dt.Columns.Add("Beneficiary Account", typeof(string));
            dt.Columns.Add("Service Provider", typeof(string));
            dt.Columns.Add("Amount", typeof(string));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "UploadInvoice", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return dt;
    }

    protected void clearControls()
    {
        try
        {
            btn_Save.Visible = false;
            btn_Edit.Visible = false;
            Rm_CG_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "UploadInvoice", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "UploadInvoice", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rg_Categories_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "UploadInvoice", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Delete_Excel_File()
    {
        try
        {
            ds.Dispose();
            if (System.IO.Directory.Exists(Server.MapPath("~/MedicalInvoice/")) == true)
            {
                string strpath = Server.MapPath("~/MedicalInvoice/");
                DirectoryInfo dirinfo = new DirectoryInfo(strpath);
                strpath = strpath + strfilename2;
                FileInfo fi = new FileInfo(strpath);
                {
                    fi.Delete();
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "UploadInvoice", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }



}