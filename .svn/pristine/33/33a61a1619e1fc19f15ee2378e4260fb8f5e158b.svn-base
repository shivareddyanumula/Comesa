using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using System.Data.OleDb;
using System.IO;

public partial class Masters_frm_Currency : System.Web.UI.Page
{
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }
    SMHR_CURRENCY _obj_Smhr_Currency;
    SMHR_COUNTRY _obj_Country;
    string strfilename2;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (RWM_POSTREPLY1.Windows.Count > 0)
        {
            RWM_POSTREPLY1.Windows.RemoveAt(0);
        }

      
            //if (Request.QueryString["POP"] != null)
            //{
            //    ((HtmlTableRow)Master.FindControl("M_Header")).Style.Add("display", "none");
            //    ((HtmlTableRow)Master.FindControl("M_Footer")).Style.Add("display", "none");
            //    ((RadMenu)Master.FindControl("MainMenu")).Style.Add("display", "none");
            //    ((RadComboBox)Master.FindControl("cmbCulture")).Style.Add("display", "none");
            //    ((LinkButton)Master.FindControl("Lnk_LogOut")).Style.Add("display", "none");
            //    ((LinkButton)Master.FindControl("lnk_Home")).Style.Add("display", "none");
            //}



        
        try
        {
            if (!IsPostBack)
            {
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("CURRRENCY");
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
                    Rg_Currency.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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

            }
            Page.Validate();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Currency", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {

        try
        {
            loadDropdown();
            clearControls();
            rtxt_CurrencyCode.Enabled = false;
            _obj_Smhr_Currency = new SMHR_CURRENCY();
            _obj_Smhr_Currency.OPERATION = operation.Select;
            _obj_Smhr_Currency.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Currency.CURR_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            DataTable dt = BLL.get_Currency(_obj_Smhr_Currency);
            lbl_CurrencyID.Text = Convert.ToString(dt.Rows[0]["CURR_ID"]);
            rtxt_CurrencyCode.Text = Convert.ToString(dt.Rows[0]["CURR_CODE"]);
            rtxt_CurrencyDesc.Text = Convert.ToString(dt.Rows[0]["CURR_DESCRIPTION"]);
            rcmb_CurrencyCountry.SelectedIndex = rcmb_CurrencyCountry.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["CURR_COUNTRY_ID"]));
            rtxt_CurrencySymbol.Text = Convert.ToString(dt.Rows[0]["CURR_SYMBOL"]);
            rntxt_CurrencyPrecision.Text = Convert.ToString(dt.Rows[0]["CURR_PRECESION"]);

            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Update.Visible = false;

            }

            else
            {
                btn_Update.Visible = true;
            }
            Rm_CU_page.SelectedIndex = 1;
            rcmb_CurrencyCountry.Enabled = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Currency", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            loadDropdown();
            clearControls();
            btn_Save.Visible = true;
            Rm_CU_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Currency", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void loadDropdown()
    {
        try
        {
            rcmb_CurrencyCountry.Items.Clear();
            _obj_Country = new SMHR_COUNTRY();
            _obj_Country.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Country.OPERATION = operation.Select;
            rcmb_CurrencyCountry.DataSource = BLL.get_Country(_obj_Country);
            rcmb_CurrencyCountry.DataTextField = "COUNTRY_CODE";
            rcmb_CurrencyCountry.DataValueField = "COUNTRY_ID";
            rcmb_CurrencyCountry.DataBind();
            rcmb_CurrencyCountry.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Currency", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void LoadGrid()
    {
        try
        {
            SMHR_CURRENCY _obj_Currency = new SMHR_CURRENCY();
            _obj_Currency.OPERATION = operation.Select;
            _obj_Currency.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT = BLL.get_Currency(_obj_Currency);
            Rg_Currency.DataSource = DT;
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Currency", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_Smhr_Currency = new SMHR_CURRENCY();
            _obj_Smhr_Currency.CURR_CODE = BLL.ReplaceQuote(rtxt_CurrencyCode.Text.ToUpper());
            _obj_Smhr_Currency.CURR_DESCRIPTION = BLL.ReplaceQuote(rtxt_CurrencyDesc.Text);
            _obj_Smhr_Currency.CURR_COUNTRY_ID = Convert.ToInt32(rcmb_CurrencyCountry.SelectedItem.Value);
            _obj_Smhr_Currency.CURR_SYMBOL = BLL.ReplaceQuote(rtxt_CurrencySymbol.Text);
            _obj_Smhr_Currency.CURR_PRECESION = Convert.ToInt32(rntxt_CurrencyPrecision.Text);
            _obj_Smhr_Currency.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Currency.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_Currency.CREATEDDATE = DateTime.Now;
            //_obj_Smhr_Currency.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Currency.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_Currency.LASTMDFDATE = DateTime.Now;

            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_UPDATE":
                    _obj_Smhr_Currency.OPERATION = operation.Update;
                    _obj_Smhr_Currency.CURR_ID = Convert.ToInt32(lbl_CurrencyID.Text);
                    if (BLL.set_Currency(_obj_Smhr_Currency))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                case "BTN_SAVE":
                    _obj_Smhr_Currency.OPERATION = operation.Check;
                    if (Convert.ToString(BLL.get_Currency(_obj_Smhr_Currency).Rows[0]["Count"]) != "0")
                    {
                        BLL.ShowMessage(this, "Currency with this Code Already Exists");
                        return;
                    }
                    _obj_Smhr_Currency.OPERATION = operation.Validate;
                    if (Convert.ToString(BLL.get_Currency(_obj_Smhr_Currency).Rows[0]["Count"]) != "0")
                    {
                        BLL.ShowMessage(this, "Currency for this Country Already Exists");
                        return;
                    }
                    _obj_Smhr_Currency.OPERATION = operation.Insert;
                    if (BLL.set_Currency(_obj_Smhr_Currency))
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                default:
                    break;
            }
            Rm_CU_page.SelectedIndex = 0;
            LoadGrid();
            Rg_Currency.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Currency", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void clearControls()
    {
        try
        {
            lbl_CurrencyID.Text = string.Empty;
            rtxt_CurrencyCode.Text = string.Empty;
            rtxt_CurrencyCode.Enabled = true;
            rtxt_CurrencyDesc.Text = string.Empty;
            rcmb_CurrencyCountry.SelectedIndex = -1;
            rtxt_CurrencySymbol.Text = string.Empty;
            rntxt_CurrencyPrecision.Text = string.Empty;
            btn_Save.Visible = false;
            btn_Update.Visible = false;
            Rm_CU_page.SelectedIndex = 0;
            rcmb_CurrencyCountry.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Currency", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Currency", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rg_Currency_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Currency", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Currency", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //protected void Btn_Imp_Currency_click(object sender, EventArgs e)
    //{
    //    try
    //    {

    //        // written by rajasekhar
    //        // to import Currency details

    //        string strcon = null;

    //        string strfilename1 = FileUpload1.FileName;
    //        strfilename2 = Convert.ToString(DateTime.Now.TimeOfDay) + "_" + strfilename1;
    //        strfilename2 = strfilename2.Replace("/", "").Replace(":", ".");
    //        if (FileUpload1.HasFile)
    //        {

    //            if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == false)
    //            {
    //                System.IO.Directory.CreateDirectory(Server.MapPath("~/IMPORT_EXCEL/"));

    //            }



    //            FileUpload1.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/IMPORT_EXCEL/"), strfilename2));
    //            string filename1 = Server.MapPath("~/IMPORT_EXCEL/") + ("") + (Convert.ToString(strfilename2));
    //            FileInfo fileInfo = new FileInfo(filename1);
    //            if (fileInfo.Exists)
    //            {
    //                string path = MapPath(strfilename1);
    //                // string name = Path.GetFileName( path );
    //                string ext = Path.GetExtension(path);

    //                string type = string.Empty;
    //                //  set known types based on file extension  
    //                if (ext != null)
    //                {
    //                    switch (ext.ToLower())
    //                    {

    //                        case ".xls":

    //                            type = "excel";
    //                            break;
    //                        case ".xlsx":
    //                            type = "excel";
    //                            break;

    //                        default:
    //                            type = string.Empty;
    //                            break;
    //                    }
    //                }
    //                if (type == string.Empty)
    //                {
    //                    if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == true)
    //                    {

    //                        string path1 = Server.MapPath("~/IMPORT_EXCEL/") + ("") + (Convert.ToString(strfilename2));
    //                        System.IO.File.Delete(path1);
    //                    }
    //                    BLL.ShowMessage(this, "Please select the Excel File  (Eg: Excel.xlsx). ");
    //                    return;
    //                }
    //            }
    //        }


    //        else
    //        {
    //            BLL.ShowMessage(this, "Please Select the File to be uploaded");
    //            return;
    //        }

    //        string strpath = Server.MapPath("~/IMPORT_EXCEL/");

    //        strpath = strpath + strfilename2;


    //        // Getting data from excell file to dataset.
    //        strcon = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source='" + strpath + "';" + "Extended Properties=Excel 12.0;";


    //        OleDbConnection objConn = null;
    //        objConn = new OleDbConnection(strcon);
    //        objConn.Open();

    //        DataTable dt_chk2 = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
    //        string sheetname;
    //        if (dt_chk2 == null)
    //        {
    //            objConn.Close();
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        else
    //        {
    //            sheetname = Convert.ToString(dt_chk2.Rows[0]["TABLE_NAME"]);
    //        }
    //        OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM  [" + sheetname + "]", strcon);



    //        da.Fill(ds);
    //        ds.Tables[0].Columns.Add("Error Message");

    //        objConn.Close();
    //        DataTable dt = new DataTable();
    //        DataTable dtfail = new DataTable();


    //        string errormsg = string.Empty;


    //        Int32 rowno = 0;


    //        string columnno = null;

    //        Boolean filestatus = true;
    //        dtfail.Columns.Add("S.NO", typeof(Int32));
    //        dtfail.Columns.Add("ROWNO", typeof(Int32));
    //        dtfail.Columns.Add("COLUMNS NAMES", typeof(string));

    //        if (ds.Tables[0].Columns[0].ToString().Trim() == "Name*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }

    //        if (ds.Tables[0].Columns[1].ToString().Trim() == "Description")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }

    //        if (ds.Tables[0].Columns[2].ToString().Trim() == "Country*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }

    //        if (ds.Tables[0].Columns[3].ToString().Trim() == "Symbol")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }


    //        if (ds.Tables[0].Columns[4].ToString().Trim() == "Precision*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        if (ds.Tables[0].Rows.Count == 0)
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Successfully processed Excel file. No Records are Imported.");
    //            return;
    //        }

    //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //        {
    //            loadDropdown();
    //            errormsg = string.Empty;
    //            if (ds.Tables[0].Rows[i]["Name*"].ToString().Trim() != "")
    //            {
    //                _obj_Smhr_Currency = new SMHR_CURRENCY();
    //                _obj_Smhr_Currency.CURR_CODE = ds.Tables[0].Rows[i]["Name*"].ToString().Trim();
    //                _obj_Smhr_Currency.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                _obj_Smhr_Currency.OPERATION = operation.Check;
    //                if (Convert.ToString(BLL.get_Currency(_obj_Smhr_Currency).Rows[0]["Count"]) != "0")
    //                {
    //                    //BLL.ShowMessage(this, "Currency with this Code Already Exists");
    //                    //return;
    //                    errormsg = "Currency with this Code Already Exists";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = "Name*";
    //                }
    //                else
    //                {
    //                }



    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = "Name*";
    //            }
    //            if (ds.Tables[0].Rows[i]["Country*"].ToString().Trim() != "")
    //            {


    //                int curr_country_id = 0;


    //                for (int count = 0; count < rcmb_CurrencyCountry.Items.Count; count++)
    //                {
    //                    if ((ds.Tables[0].Rows[i]["Country*"].ToString().Trim().ToUpper()) == rcmb_CurrencyCountry.Items[count].Text.ToUpper())
    //                    {
    //                        curr_country_id = Convert.ToInt32(rcmb_CurrencyCountry.Items[count].Value);

    //                    }





    //                }
    //                if (curr_country_id == 0)
    //                {
    //                    errormsg = errormsg + "," + "Country with this Name Does not  Exists";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = columnno + "," + "Country*";

    //                }


    //                _obj_Smhr_Currency = new SMHR_CURRENCY();

    //                _obj_Smhr_Currency.CURR_COUNTRY_ID = curr_country_id;

    //                _obj_Smhr_Currency.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                _obj_Smhr_Currency.OPERATION = operation.Validate;
    //                if (Convert.ToString(BLL.get_Currency(_obj_Smhr_Currency).Rows[0]["Count"]) != "0")
    //                {


    //                    errormsg = errormsg + "," + "Currency for this Country Already Exists";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = columnno + "," + "Country*";
    //                }
    //                else
    //                {
    //                }



    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Country*";
    //            }

    //            if (ds.Tables[0].Rows[i]["Precision*"].ToString().Trim() != "")
    //            {
    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Country*";
    //            }
    //            if (filestatus == false)
    //            {
    //                DataRow newrow = dtfail.NewRow();
    //                newrow["S.NO"] = dtfail.Rows.Count + 1;


    //                newrow["ROWNO"] = rowno;
    //                newrow["COLUMNS NAMES"] = columnno;
    //                dtfail.Rows.Add(newrow);
    //                ds.Tables[0].Rows[i]["Error Message"] = errormsg;
    //            }
    //        }
    //        if (dtfail.Rows.Count > 0)
    //        {
    //            Session["dt_fail"] = dtfail;
    //            Session["ds_data"] = ds;
    //            Delete_Excel_File();
    //            //LinkButton lnk_Import_process = (LinkButton)RadPanelBar1.FindItemByValue("AddAttachment").FindControl("lnk_Import_process");
    //            Telerik.Web.UI.RadWindow newwindow = new Telerik.Web.UI.RadWindow();
    //            // RWM_POSTREPLY.Windows.Remove(newwindow);
    //            newwindow.ID = "RadWindow_import";

    //            newwindow.NavigateUrl = "~/Payroll/frm_AttendanceImportProcess.aspx";
    //            newwindow.Title = "Import Process";
    //            newwindow.Width = 1150;
    //            newwindow.Height = 580;
    //            newwindow.VisibleOnPageLoad = true;
    //            if (RWM_POSTREPLY1.Windows.Count > 1)
    //            {
    //                RWM_POSTREPLY1.Windows.RemoveAt(1);
    //            }
    //            RWM_POSTREPLY1.Windows.Add(newwindow);



    //            RWM_POSTREPLY1.Visible = true;
    //            return;

    //        }
    //        else
    //        {
    //            int ccid = 0;
    //            bool status = false;
    //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //            {



    //                _obj_Smhr_Currency = new SMHR_CURRENCY();
    //                _obj_Smhr_Currency.CURR_CODE = ds.Tables[0].Rows[i]["Name*"].ToString().Trim().ToUpper();
    //                _obj_Smhr_Currency.CURR_DESCRIPTION = ds.Tables[0].Rows[i]["Description"].ToString().Trim();
    //                for (int count = 0; count < rcmb_CurrencyCountry.Items.Count; count++)
    //                {
    //                    if ((ds.Tables[0].Rows[i]["Country*"].ToString().Trim()) == rcmb_CurrencyCountry.Items[count].Text)
    //                    {
    //                        ccid = Convert.ToInt32(rcmb_CurrencyCountry.Items[count].Value);

    //                    }

    //                }
    //                _obj_Smhr_Currency.CURR_COUNTRY_ID = ccid;
    //                _obj_Smhr_Currency.CURR_SYMBOL = ds.Tables[0].Rows[i]["Symbol"].ToString().Trim();
    //                _obj_Smhr_Currency.CURR_PRECESION = Convert.ToInt32(ds.Tables[0].Rows[i]["Precision*"]);
    //                _obj_Smhr_Currency.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                _obj_Smhr_Currency.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
    //                _obj_Smhr_Currency.CREATEDDATE = DateTime.Now;
    //                //_obj_Smhr_Currency.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                _obj_Smhr_Currency.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
    //                _obj_Smhr_Currency.LASTMDFDATE = DateTime.Now;
    //                _obj_Smhr_Currency.OPERATION = operation.Insert;
    //                status = BLL.set_Currency(_obj_Smhr_Currency);


    //            }
    //            if (status == true)
    //            {
    //                BLL.ShowMessage(this, "Information Saved Successfully");
    //                LoadGrid();
    //                Rg_Currency.DataBind();
    //            }

    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }

    //}
}
