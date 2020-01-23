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
using System.Data.OleDb;
using System.IO;

public partial class Masters_frm_Catagory : System.Web.UI.Page
{
    string strfilename2;
    DataSet ds = new DataSet();
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    public string masterType = string.Empty;
    SMHR_CATEGORY _obj_Smhr_Category;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (RWM_POSTREPLY1.Windows.Count > 0)
        {
            RWM_POSTREPLY1.Windows.RemoveAt(0);
        }

        try
        {

            if (!IsPostBack)
            {

                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("CATEGORY");
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


            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Catagory", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }



    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {

        try
        {
            clearControls();
            SMHR_CATEGORY _obj_Smhr_Category = new SMHR_CATEGORY();
            _obj_Smhr_Category.CATEGORY_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            _obj_Smhr_Category.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_Category(_obj_Smhr_Category);
            lbl_CategoryID.Text = Convert.ToString(dt.Rows[0]["CATEGORY_ID"]);
            rtxt_CategoryCode.Text = Convert.ToString(dt.Rows[0]["CATEGORY_CODE"]);
            rtxt_CategoryDesc.Text = Convert.ToString(dt.Rows[0]["CATEGORY_DESC"]);
            chk_CategoryOverTime.Checked = Convert.ToBoolean(dt.Rows[0]["CATEGORY_ISOVERTIME"]);
            chk_CategoryNeedBankInfo.Checked = Convert.ToBoolean(dt.Rows[0]["CATEGORY_NEEDBANKINFO"]);
            chk_CategoryFiscalYearNeeded.Checked = Convert.ToBoolean(dt.Rows[0]["CATEGORY_ISFISCALYEAR"]);
            chk_CategoryCurrencyNeeded.Checked = Convert.ToBoolean(dt.Rows[0]["CATEGORY_ISCURRENCY"]);
            chk_CategoryDateFormatNeeded.Checked = Convert.ToBoolean(dt.Rows[0]["CATEGORY_ISDATEFORMAT"]);
            chk_CategoryCountryNeeded.Checked = Convert.ToBoolean(dt.Rows[0]["CATEGORY_ISCOUNTRY"]);
            chk_CategoryAddressNeeded.Checked = Convert.ToBoolean(dt.Rows[0]["CATEGORY_ISADDRESS"]);
            chk_CategoryAgeNeeded.Checked = Convert.ToBoolean(dt.Rows[0]["CATEGORY_ISAGE"]);
            chk_CategoryPaymentMethodsNeeded.Checked = Convert.ToBoolean(dt.Rows[0]["CATEGORY_ISPAYMENTMODE"]);
            chk_CategoryCalendarYear.Checked = Convert.ToBoolean(dt.Rows[0]["CATEGORY_ISCALENDERYEAR"]);
            chk_Localisation.Checked = Convert.ToBoolean(dt.Rows[0]["CATEGORY_LOCALISATION"]);

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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Catagory", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            clearControls();
            btn_Save.Visible = true;
            Rm_CG_page.SelectedIndex = 1;
            rtxt_CategoryCode.Focus();
            chk_Localisation.Checked = true;
            chk_CategoryPaymentMethodsNeeded.Checked = true;
            chk_CategoryCountryNeeded.Checked = true;
            chk_CategoryAgeNeeded.Checked = true;
            chk_CategoryDateFormatNeeded.Checked = true;
            chk_CategoryCurrencyNeeded.Checked = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Catagory", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }


    public void LoadGrid()
    {
        try
        {

            SMHR_CATEGORY _obj_Smhr_Category = new SMHR_CATEGORY();
            _obj_Smhr_Category.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT = BLL.get_Category(_obj_Smhr_Category);
            Rg_Categories.DataSource = DT;
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Catagory", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {

        try
        {
            _obj_Smhr_Category = new SMHR_CATEGORY();
            _obj_Smhr_Category.CATEGORY_CODE = rtxt_CategoryCode.Text.Replace("'", "''");
            _obj_Smhr_Category.CATEGORY_DESC = rtxt_CategoryDesc.Text.Replace("'", "''");
            _obj_Smhr_Category.CATEGORY_ISOVERTIME = chk_CategoryOverTime.Checked;
            _obj_Smhr_Category.CATEGORY_NEEDBANKINFO = chk_CategoryNeedBankInfo.Checked;
            _obj_Smhr_Category.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Category.CATEGORY_ISFISCALYEAR = chk_CategoryFiscalYearNeeded.Checked;
            _obj_Smhr_Category.CATEGORY_ISCURRENCY = chk_CategoryCurrencyNeeded.Checked;
            _obj_Smhr_Category.CATEGORY_ISDATEFORMAT = chk_CategoryDateFormatNeeded.Checked;
            _obj_Smhr_Category.CATEGORY_ISCOUNTRY = chk_CategoryCountryNeeded.Checked;
            _obj_Smhr_Category.CATEGORY_ISADDRESS = chk_CategoryAddressNeeded.Checked;
            _obj_Smhr_Category.CATEGORY_ISAGE = chk_CategoryAgeNeeded.Checked;
            _obj_Smhr_Category.CATEGORY_ISPAYMENTMODE = chk_CategoryPaymentMethodsNeeded.Checked;
            _obj_Smhr_Category.CATEGORY_ISCALENDERYEAR = chk_CategoryCalendarYear.Checked;
            _obj_Smhr_Category.CATEGORY_LOCALISATION = chk_Localisation.Checked;

            _obj_Smhr_Category.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_Category.CREATEDDATE = DateTime.Now;

            _obj_Smhr_Category.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_Category.LASTMDFDATE = DateTime.Now;
            _obj_Smhr_Category.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_EDIT":
                    _obj_Smhr_Category.CATEGORY_ID = Convert.ToInt32(lbl_CategoryID.Text);
                    _obj_Smhr_Category.OPERATION = operation.Check;
                    if (Convert.ToString(BLL.get_Category(_obj_Smhr_Category).Rows[0]["Count"]) != "1")
                    {
                        BLL.ShowMessage(this, "Category with this Name Already Exists");
                        return;
                    }
                    _obj_Smhr_Category.OPERATION = operation.Update;
                    if (BLL.set_Category(_obj_Smhr_Category))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");


                    break;
                case "BTN_SAVE":
                    _obj_Smhr_Category.OPERATION = operation.Check;
                    if (Convert.ToString(BLL.get_Category(_obj_Smhr_Category).Rows[0]["Count"]) != "0")
                    {
                        BLL.ShowMessage(this, "Category with this Name Already Exists");
                        return;
                    }
                    _obj_Smhr_Category.OPERATION = operation.Insert;
                    if (BLL.set_Category(_obj_Smhr_Category))
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
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Catagory", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void clearControls()
    {
        lbl_CategoryID.Text = string.Empty;
        rtxt_CategoryCode.Text = string.Empty;
        rtxt_CategoryDesc.Text = string.Empty;
        chk_CategoryOverTime.Checked = false;
        chk_CategoryNeedBankInfo.Checked = false;

        chk_CategoryFiscalYearNeeded.Checked = false;
        //chk_CategoryCurrencyNeeded.Checked = false;
        //chk_CategoryDateFormatNeeded.Checked = false;
        chk_CategoryCountryNeeded.Checked = false;
        chk_CategoryAddressNeeded.Checked = false;
        chk_CategoryAgeNeeded.Checked = false;
        chk_CategoryPaymentMethodsNeeded.Checked = false;
        chk_CategoryCalendarYear.Checked = false;
        chk_Localisation.Checked = false;
        btn_Save.Visible = false;
        btn_Edit.Visible = false;
        Rm_CG_page.SelectedIndex = 0;
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Catagory", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Catagory", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Delete_Excel_File()
    {
        try
        {
            ds.Dispose();
            if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == true)
            {
                // FileUpload_Task.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Corporate_Contract_Docs/") + Convert.ToString(rcmb_taskPorjectname.SelectedItem.Text.Replace("/", "_")), filename));

                string strpath = Server.MapPath("~/IMPORT_EXCEL/");


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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Catagory", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Btn_Imp_Category_click(object sender, EventArgs e)
    {
        try
        {
            //written by Rajasekhar
            //To Import category Excel Sheet

            string strcon = null;

            string strfilename1 = FileUpload1.FileName;
            strfilename2 = Convert.ToString(DateTime.Now.TimeOfDay) + "_" + strfilename1;
            strfilename2 = strfilename2.Replace("/", "").Replace(":", ".");
            if (FileUpload1.HasFile)
            {

                if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == false)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath("~/IMPORT_EXCEL/"));

                }



                FileUpload1.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/IMPORT_EXCEL/"), strfilename2));
                string filename1 = Server.MapPath("~/IMPORT_EXCEL/") + ("") + (Convert.ToString(strfilename2));
                FileInfo fileInfo = new FileInfo(filename1);
                if (fileInfo.Exists)
                {
                    string path = MapPath(strfilename1);
                    // string name = Path.GetFileName( path );
                    string ext = Path.GetExtension(path);

                    string type = string.Empty;
                    //  set known types based on file extension  
                    if (ext != null)
                    {
                        switch (ext.ToLower())
                        {

                            case ".xls":

                                type = "excel";
                                break;
                            case ".xlsx":
                                type = "excel";
                                break;

                            default:
                                type = string.Empty;
                                break;
                        }
                    }
                    if (type == string.Empty)
                    {
                        if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == true)
                        {

                            string path1 = Server.MapPath("~/IMPORT_EXCEL/") + ("") + (Convert.ToString(strfilename2));
                            System.IO.File.Delete(path1);
                        }
                        BLL.ShowMessage(this, "Please select the Excel File  (Eg: Excel.xlsx). ");
                        return;
                    }
                }
            }


            else
            {
                BLL.ShowMessage(this, "Please Select the File to be uploaded");
                return;
            }

            string strpath = Server.MapPath("~/IMPORT_EXCEL/");

            strpath = strpath + strfilename2;


            // Getting data from excell file to dataset.
            strcon = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source='" + strpath + "';" + "Extended Properties=Excel 12.0;";


            OleDbConnection objConn = null;
            objConn = new OleDbConnection(strcon);
            objConn.Open();

            DataTable dt_chk2 = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string sheetname;
            if (dt_chk2 == null)
            {
                objConn.Close();
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            else
            {
                sheetname = Convert.ToString(dt_chk2.Rows[0]["TABLE_NAME"]);
            }
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM  [" + sheetname + "]", strcon);



            da.Fill(ds);
            ds.Tables[0].Columns.Add("Error Message");

            objConn.Close();
            DataTable dt = new DataTable();
            DataTable dtfail = new DataTable();


            string errormsg = string.Empty;

            string projecttype = null;
            Int32 rowno = 0;

            DateTime dat;
            string columnno = null;
            string projname = null;
            Boolean filestatus = true;
            dtfail.Columns.Add("S.NO", typeof(Int32));
            dtfail.Columns.Add("ROWNO", typeof(Int32));
            dtfail.Columns.Add("COLUMNS NAMES", typeof(string));

            if (ds.Tables[0].Columns[0].ToString().Trim() == "Name*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[1].ToString().Trim() == "Description")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }

            if (ds.Tables[0].Columns[2].ToString().Trim() == "OverTime Enabled")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[3].ToString().Trim() == "Bank Info")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[4].ToString().Trim() == "Currency")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[5].ToString().Trim() == "Age")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;

            }
            if (ds.Tables[0].Columns[6].ToString().Trim() == "DateFormat")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[7].ToString().Trim() == "Address")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[8].ToString().Trim() == "Country")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[9].ToString().Trim() == "Fiscal Year")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[10].ToString().Trim() == "Calendar")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[11].ToString().Trim() == "Payment Methods")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[12].ToString().Trim() == "Localisation")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Rows.Count == 0)
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Successfully processed Excel file. No Records are Imported.");
                return;
            }

            //to check the data in excel
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                errormsg = string.Empty;
                columnno = string.Empty;
                if (ds.Tables[0].Rows[i]["Name*"].ToString().Trim() != "")
                {
                    _obj_Smhr_Category = new SMHR_CATEGORY();
                    _obj_Smhr_Category.CATEGORY_CODE = Convert.ToString(ds.Tables[0].Rows[i]["Name*"]).Trim();
                    _obj_Smhr_Category.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Smhr_Category.OPERATION = operation.Check;
                    if (Convert.ToString(BLL.get_Category(_obj_Smhr_Category).Rows[0]["Count"]) != "0")
                    {
                        // BLL.ShowMessage(this, "Category with this Name Already Exists");
                        // return;
                        errormsg = "Category with this Name Already Exists";
                        filestatus = false;
                        rowno = i + 2;
                        columnno = "Name*";
                    }

                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = "Name*";

                }
                for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                {
                    if (ds.Tables[0].Rows[i]["Name*"].ToString().Trim() == ds.Tables[0].Rows[k]["Name*"].ToString().Trim())
                    {
                        if (i != k)
                        {
                            errormsg = "Category with this Name is repeated in Excel Sheet";
                            filestatus = false;
                            rowno = i + 2;
                            columnno = "Name*";
                        }
                    }
                }

                if (ds.Tables[0].Rows[i]["Description"].ToString().Trim() != "")
                {

                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Description";

                }
                if (ds.Tables[0].Rows[i]["OverTime Enabled"].ToString().Trim() != "")
                {

                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "OverTime Enabled";

                }
                if (ds.Tables[0].Rows[i]["Bank Info"].ToString().Trim() != "")
                {

                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Bank Info";

                }
                if (ds.Tables[0].Rows[i]["Currency"].ToString().Trim() != "")
                {

                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Currency";

                }
                if (ds.Tables[0].Rows[i]["Age"].ToString().Trim() != "")
                {

                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Age";

                }
                if (ds.Tables[0].Rows[i]["DateFormat"].ToString().Trim() != "")
                {

                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "DateFormat";

                }
                if (ds.Tables[0].Rows[i]["Address"].ToString().Trim() != "")
                {

                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Address";

                }
                if (ds.Tables[0].Rows[i]["Country"].ToString().Trim() != "")
                {

                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Country";

                }
                if (ds.Tables[0].Rows[i]["Fiscal Year"].ToString().Trim() != "")
                {

                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Fiscal Year";

                }
                if (ds.Tables[0].Rows[i]["Calendar"].ToString().Trim() != "")
                {

                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Calendar";

                }
                if (ds.Tables[0].Rows[i]["Payment Methods"].ToString().Trim() != "")
                {

                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Payment Methods";

                }
                if (ds.Tables[0].Rows[i]["Localisation"].ToString().Trim() != "")
                {

                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Localisation";

                }
                if (filestatus == false)
                {
                    DataRow newrow = dtfail.NewRow();
                    newrow["S.NO"] = dtfail.Rows.Count + 1;


                    newrow["ROWNO"] = rowno;
                    newrow["COLUMNS NAMES"] = columnno;
                    dtfail.Rows.Add(newrow);
                    ds.Tables[0].Rows[i]["Error Message"] = errormsg;
                }
            }
            if (dtfail.Rows.Count > 0)
            {
                Session["dt_fail"] = dtfail;
                Session["ds_data"] = ds;
                Delete_Excel_File();
                //LinkButton lnk_Import_process = (LinkButton)RadPanelBar1.FindItemByValue("AddAttachment").FindControl("lnk_Import_process");
                Telerik.Web.UI.RadWindow newwindow = new Telerik.Web.UI.RadWindow();
                // RWM_POSTREPLY.Windows.Remove(newwindow);
                newwindow.ID = "RadWindow_import";

                newwindow.NavigateUrl = "~/Payroll/frm_AttendanceImportProcess.aspx";
                newwindow.Title = "Import Process";
                newwindow.Width = 1150;
                newwindow.Height = 580;
                newwindow.VisibleOnPageLoad = true;
                if (RWM_POSTREPLY1.Windows.Count > 1)
                {
                    RWM_POSTREPLY1.Windows.RemoveAt(1);
                }
                RWM_POSTREPLY1.Windows.Add(newwindow);



                RWM_POSTREPLY1.Visible = true;
                return;

            }
            else
            {

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    bool status = false;
                    _obj_Smhr_Category.CATEGORY_CODE = Convert.ToString(ds.Tables[0].Rows[i]["Name*"]).Trim();
                    _obj_Smhr_Category.CATEGORY_DESC = Convert.ToString(ds.Tables[0].Rows[i]["Description"]).Trim();
                    _obj_Smhr_Category.CATEGORY_ISOVERTIME = Convert.ToBoolean(ds.Tables[0].Rows[i]["OverTime Enabled"]);
                    _obj_Smhr_Category.CATEGORY_NEEDBANKINFO = Convert.ToBoolean(ds.Tables[0].Rows[i]["Bank Info"]);
                    _obj_Smhr_Category.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Smhr_Category.CATEGORY_ISFISCALYEAR = Convert.ToBoolean(ds.Tables[0].Rows[i]["Fiscal Year"]);
                    _obj_Smhr_Category.CATEGORY_ISCURRENCY = Convert.ToBoolean(ds.Tables[0].Rows[i]["Currency"]);
                    _obj_Smhr_Category.CATEGORY_ISDATEFORMAT = Convert.ToBoolean(ds.Tables[0].Rows[i]["DateFormat"]);
                    _obj_Smhr_Category.CATEGORY_ISCOUNTRY = Convert.ToBoolean(ds.Tables[0].Rows[i]["Country"]);
                    _obj_Smhr_Category.CATEGORY_ISADDRESS = Convert.ToBoolean(ds.Tables[0].Rows[i]["Address"]);
                    _obj_Smhr_Category.CATEGORY_ISAGE = Convert.ToBoolean(ds.Tables[0].Rows[i]["Age"]);
                    _obj_Smhr_Category.CATEGORY_ISPAYMENTMODE = Convert.ToBoolean(ds.Tables[0].Rows[i]["Payment Methods"]);
                    _obj_Smhr_Category.CATEGORY_ISCALENDERYEAR = Convert.ToBoolean(ds.Tables[0].Rows[i]["Calendar"]);
                    _obj_Smhr_Category.CATEGORY_LOCALISATION = Convert.ToBoolean(ds.Tables[0].Rows[i]["Localisation"]);

                    _obj_Smhr_Category.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                    _obj_Smhr_Category.CREATEDDATE = DateTime.Now;

                    _obj_Smhr_Category.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                    _obj_Smhr_Category.LASTMDFDATE = DateTime.Now;
                    _obj_Smhr_Category.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Smhr_Category.OPERATION = operation.Insert;
                    status = BLL.set_Category(_obj_Smhr_Category);

                    if (status == true)
                    {
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    }
                    ////else
                    ////    BLL.ShowMessage(this, "Information Not Saved");

                }
                LoadGrid();

                Rg_Categories.DataBind();

            }




        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Catagory", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

}
