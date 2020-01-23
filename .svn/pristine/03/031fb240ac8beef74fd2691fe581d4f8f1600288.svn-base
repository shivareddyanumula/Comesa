using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Data;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using System.Data.OleDb;
using System.IO;

public partial class Masters_frm_BusinessUnitBanks : System.Web.UI.Page
{
    string strfilename2;
    DataSet ds = new DataSet();
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    protected SMHR_BUSINESSUNITBANK _obj_Smhr_BusinessUnitBank;

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

                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Businessunit Bank");//BANKS");
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
                    Rg_BusinessUnitBank.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
                if (Request.QueryString["POP"] != null)
                {
                    ((HtmlTableRow)Master.FindControl("M_Header")).Style.Add("display", "none");
                    ((HtmlTableRow)Master.FindControl("M_Footer")).Style.Add("display", "none");
                    ((RadMenu)Master.FindControl("MainMenu")).Style.Add("display", "none");
                    ((RadComboBox)Master.FindControl("cmbCulture")).Style.Add("display", "none");
                    ((LinkButton)Master.FindControl("Lnk_LogOut")).Style.Add("display", "none");
                    ((LinkButton)Master.FindControl("lnk_Home")).Style.Add("display", "none");

                }
                LoadGrid();
                Rg_BusinessUnitBank.DataBind();
                //MarkData();
                rtxt_BusinessUnitBankName.Enabled = true;



            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BusinessUnitBanks", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            rtxt_BusinessUnitBankAccountNo.Enabled = false;
            loadDropdown();
            clearControls();
            DataTable dt = BLL.get_BusinessUnitBank(new SMHR_BUSINESSUNITBANK(Convert.ToInt32(Convert.ToString(e.CommandArgument))));
            lbl_BusinessUnitBankID.Text = Convert.ToString(e.CommandArgument);
            rcmb_BusinessUnits.SelectedIndex = rcmb_BusinessUnits.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["BUSUNTBANK_BUSINESSUNIT_ID"]));
            rtxt_BusinessUnitBankName.Text = Convert.ToString(dt.Rows[0]["BUSUNTBANK_NAME"]); ;
            rtxt_BusinessUnitBankBranch.Text = Convert.ToString(dt.Rows[0]["BUSUNTBANK_BRANCH"]); ;
            rtxt_BusinessUnitBankAccountNo.Text = Convert.ToString(dt.Rows[0]["BUSUNTBANK_ACCOUNTNO"]); ;
            rtxt_BusinessUnitBankAddress.Text = Convert.ToString(dt.Rows[0]["BUSUNTBANK_ADDRESS"]); ;
            rtxt_BSBCode.Text = Convert.ToString(dt.Rows[0]["BUSUNTBANK_SWIFT"]); ;

            //chk_BusinessUnitBankIsActive.Checked = Convert.ToBoolean(dt.Rows[0]["BUSUNTBANK_ISACTIVE"]);
            if (Convert.ToBoolean(dt.Rows[0]["BUSUNTBANK_ISACTIVE"]) == false)
                rcmb_BusinessUnitBankIsActive.SelectedValue = "0";
            else
                rcmb_BusinessUnitBankIsActive.SelectedValue = "1";
            chk_BusinessUnitBankIsDefault.Checked = Convert.ToBoolean(dt.Rows[0]["BUSUNTBANK_ISDEFAULT"]);
            //code for security
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Update.Visible = false;

            }

            else
            {
                btn_Update.Visible = true;
            }

            Rm_BB_page.SelectedIndex = 1;
            if (Convert.ToString(Request.QueryString["ID"]) == null)
            {
                rcmb_BusinessUnits.Enabled = false;
                rtxt_BusinessUnitBankName.Enabled = false;
            }
            else
                rcmb_BusinessUnits.Enabled = false;

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BusinessUnitBanks", ex.StackTrace, DateTime.Now);
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
            Rm_BB_page.SelectedIndex = 1;
            rtxt_BusinessUnitBankName.Enabled = true;
            rtxt_BusinessUnitBankAccountNo.Enabled = true;
            if (Convert.ToString(Request.QueryString["ID"]) == null)
            {
                rcmb_BusinessUnits.SelectedIndex = 0;
                rcmb_BusinessUnits.Enabled = true;
            }
            else
            {
                rcmb_BusinessUnits.SelectedIndex = rcmb_BusinessUnits.FindItemIndexByValue(Convert.ToString(Request.QueryString["ID"]));
                rcmb_BusinessUnits.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BusinessUnitBanks", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void loadDropdown()
    {
        //_obj_Smhr_BusinessUnitBank = new SMHR_BUSINESSUNITBANK();
        //_obj_Smhr_BusinessUnitBank.OPERATION = operation.Check;
        //rcmb_BusinessUnits.Items.Clear();
        //rcmb_BusinessUnits.DataSource = BLL.get_BusinessUnitBank(_obj_Smhr_BusinessUnitBank);
        //rcmb_BusinessUnits.DataTextField = "BUSINESSUNIT_CODE";
        //rcmb_BusinessUnits.DataValueField = "BUSINESSUNIT_ID";
        //rcmb_BusinessUnits.DataBind();
        //rcmb_BusinessUnits.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        try
        {
            SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
            _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"].ToString());
            rcmb_BusinessUnits.Items.Clear();
            rcmb_BusinessUnits.DataSource = BLL.get_Business_Units(_obj_smhr_logininfo);
            rcmb_BusinessUnits.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BusinessUnits.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BusinessUnits.DataBind();
            rcmb_BusinessUnits.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BusinessUnitBanks", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    public void LoadGrid()
    {
        try
        {

            _obj_Smhr_BusinessUnitBank = new SMHR_BUSINESSUNITBANK();
            if (Convert.ToString(Request.QueryString["ID"]) == null)
            {
                _obj_Smhr_BusinessUnitBank.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                Rg_BusinessUnitBank.DataSource = BLL.get_BusinessUnitBank(_obj_Smhr_BusinessUnitBank);
                clearControls();
            }
            else
            {
                _obj_Smhr_BusinessUnitBank = new SMHR_BUSINESSUNITBANK();
                _obj_Smhr_BusinessUnitBank.OPERATION = operation.Empty;
                _obj_Smhr_BusinessUnitBank.BUSUNTBANK_BUSINESSUNIT_ID = Convert.ToInt32(Convert.ToString(Request.QueryString["ID"]));
                Rg_BusinessUnitBank.DataSource = BLL.get_BusinessUnitBank(_obj_Smhr_BusinessUnitBank);
                clearControls();
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BusinessUnitBanks", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_Smhr_BusinessUnitBank = new SMHR_BUSINESSUNITBANK();
            _obj_Smhr_BusinessUnitBank.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_Smhr_BusinessUnitBank.BUSUNTBANK_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnits.SelectedItem.Value);
            _obj_Smhr_BusinessUnitBank.BUSUNTBANK_NAME = BLL.ReplaceQuote(rtxt_BusinessUnitBankName.Text);
            _obj_Smhr_BusinessUnitBank.BUSUNTBANK_BRANCH = BLL.ReplaceQuote(rtxt_BusinessUnitBankBranch.Text);
            _obj_Smhr_BusinessUnitBank.BUSUNTBANK_ACCOUNTNO = BLL.ReplaceQuote(rtxt_BusinessUnitBankAccountNo.Text);
            _obj_Smhr_BusinessUnitBank.BUSUNTBANK_ADDRESS = BLL.ReplaceQuote(rtxt_BusinessUnitBankAddress.Text);
            _obj_Smhr_BusinessUnitBank.BUSUNTBANK_BSBCODE = BLL.ReplaceQuote(rtxt_BSBCode.Text);
            //_obj_Smhr_BusinessUnitBank.BUSUNTBANK_ISACTIVE = chk_BusinessUnitBankIsActive.Checked;
            _obj_Smhr_BusinessUnitBank.BUSUNTBANK_ISACTIVE = Convert.ToInt32(rcmb_BusinessUnitBankIsActive.SelectedValue);
            _obj_Smhr_BusinessUnitBank.BUSUNTBANK_ISDEFAULT = chk_BusinessUnitBankIsDefault.Checked;

            _obj_Smhr_BusinessUnitBank.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_BusinessUnitBank.CREATEDDATE = DateTime.Now;

            _obj_Smhr_BusinessUnitBank.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_BusinessUnitBank.LASTMDFDATE = DateTime.Now;

            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_UPDATE":
                    _obj_Smhr_BusinessUnitBank.BUSUNTBANK_ID = Convert.ToInt32(lbl_BusinessUnitBankID.Text);
                    _obj_Smhr_BusinessUnitBank.BUSUNTBANK_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnits.SelectedItem.Value);

                    _obj_Smhr_BusinessUnitBank.OPERATION = operation.Combination;

                    if (Convert.ToString(BLL.get_BusinessUnitBank(_obj_Smhr_BusinessUnitBank).Rows[0]["Count"]) != "1")
                    {
                        BLL.ShowMessage(this, "This Combination Already Exists");
                        return;
                    }
                    _obj_Smhr_BusinessUnitBank.OPERATION = operation.Update;

                    if (BLL.set_BusinessUnitBank(_obj_Smhr_BusinessUnitBank))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");

                    break;
                case "BTN_SAVE":
                    _obj_Smhr_BusinessUnitBank.OPERATION = operation.Combination;
                    _obj_Smhr_BusinessUnitBank.BUSUNTBANK_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnits.SelectedItem.Value);

                    if (Convert.ToString(BLL.get_BusinessUnitBank(_obj_Smhr_BusinessUnitBank).Rows[0]["Count"]) != "0")
                    {
                        BLL.ShowMessage(this, "This Combination Already Exists");
                        return;
                    }
                    _obj_Smhr_BusinessUnitBank.OPERATION = operation.Insert;
                    if (BLL.set_BusinessUnitBank(_obj_Smhr_BusinessUnitBank))
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                default:
                    break;
            }
            Rm_BB_page.SelectedIndex = 0;
            LoadGrid();
            Rg_BusinessUnitBank.DataBind();
            //MarkData();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BusinessUnitBanks", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void clearControls()
    {
        try
        {
            lbl_BusinessUnitBankID.Text = string.Empty;
            rcmb_BusinessUnits.SelectedIndex = -1;
            rtxt_BusinessUnitBankName.Text = string.Empty;
            rtxt_BusinessUnitBankBranch.Text = string.Empty;
            rtxt_BusinessUnitBankAccountNo.Text = string.Empty;
            rtxt_BusinessUnitBankAddress.Text = string.Empty;
            rtxt_BSBCode.Text = string.Empty;
            rcmb_BusinessUnitBankIsActive.SelectedValue = "1";
            //chk_BusinessUnitBankIsActive.Checked = false;
            chk_BusinessUnitBankIsDefault.Checked = false;
            btn_Save.Visible = false;
            btn_Update.Visible = false;
            Rm_BB_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BusinessUnitBanks", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BusinessUnitBanks", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Rg_BusinessUnitBank_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BusinessUnitBanks", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void MarkData()
    {

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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BusinessUnitBanks", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //protected void Btn_Imp_Businessunit_click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        // written by rajasekhar
    //        // to import business unit bank details

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
    //        if (ds.Tables[0].Columns[0].ToString().Trim() == "BusinessUnit*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds.Tables[0].Columns[1].ToString().Trim() == "Name*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds.Tables[0].Columns[2].ToString().Trim() == "Branch")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds.Tables[0].Columns[3].ToString().Trim() == "Account No*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds.Tables[0].Columns[4].ToString().Trim() == "Address*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds.Tables[0].Columns[5].ToString().Trim() == "Status")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds.Tables[0].Columns[6].ToString().Trim() == "Default")
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
    //        //to check the data in excel
    //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //        {
    //            if (ds.Tables[0].Rows[i]["BusinessUnit*"].ToString().Trim() != "")
    //            {
    //                SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
    //                _obj_Smhr_BusinessUnit.BUSINESSUNIT_CODE = ds.Tables[0].Rows[i]["BusinessUnit*"].ToString().Trim();
    //                _obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                _obj_Smhr_BusinessUnit.OPERATION = operation.Validate;
    //                DataTable dt_businessunit = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
    //                if (Convert.ToInt32(dt_businessunit.Rows[0]["COUNT"]) == 0)
    //                {
    //                    errormsg = "Busines Unit with this Name Does not Exists";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = "BusinessUnit*";
    //                }
    //                else
    //                {

    //                }

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = "BusinessUnit*";

    //            }
    //            if (ds.Tables[0].Rows[i]["Name*"].ToString().Trim() != "")
    //            {

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Name*";
    //            }
    //            if (ds.Tables[0].Rows[i]["Account No*"].ToString().Trim() != "")
    //            {

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Account No*";
    //            }
    //            if (ds.Tables[0].Rows[i]["Address*"].ToString().Trim() != "")
    //            {

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Address*";
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

    //            bool status = false;
    //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //            {
    //                int businessunitid = 0;
    //                SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();

    //                _obj_Smhr_BusinessUnit.BUSINESSUNIT_CODE = ds.Tables[0].Rows[i]["BusinessUnit*"].ToString().Trim();
    //                _obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                _obj_Smhr_BusinessUnit.OPERATION = operation.Get;
    //                DataTable dt_businessunit = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
    //                if (dt_businessunit.Rows.Count > 0)
    //                {
    //                    businessunitid = Convert.ToInt32(dt_businessunit.Rows[0]["BUSINESSUNIT_ID"]);
    //                }
    //                _obj_Smhr_BusinessUnitBank = new SMHR_BUSINESSUNITBANK();
    //                _obj_Smhr_BusinessUnitBank.BUSUNTBANK_BUSINESSUNIT_ID = businessunitid;
    //                _obj_Smhr_BusinessUnitBank.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
    //                _obj_Smhr_BusinessUnitBank.BUSUNTBANK_NAME = ds.Tables[0].Rows[i]["Name*"].ToString().Trim();
    //                _obj_Smhr_BusinessUnitBank.BUSUNTBANK_ACCOUNTNO = Convert.ToString(ds.Tables[0].Rows[i]["Account No*"]);
    //                _obj_Smhr_BusinessUnitBank.BUSUNTBANK_ADDRESS = Convert.ToString(ds.Tables[0].Rows[i]["Address*"]);
    //                if (ds.Tables[0].Rows[i]["Branch"].ToString().Trim() == "")
    //                {
    //                    _obj_Smhr_BusinessUnitBank.BUSUNTBANK_BRANCH = string.Empty;
    //                }
    //                else
    //                {

    //                    _obj_Smhr_BusinessUnitBank.BUSUNTBANK_BRANCH = Convert.ToString(ds.Tables[0].Rows[i]["Branch"]);
    //                }
    //                if (ds.Tables[0].Rows[i]["Status"].ToString().Trim() == "Active")
    //                {
    //                    _obj_Smhr_BusinessUnitBank.BUSUNTBANK_ISACTIVE = 1;
    //                }
    //                else
    //                {
    //                    _obj_Smhr_BusinessUnitBank.BUSUNTBANK_ISACTIVE = 0;
    //                }
    //                if (ds.Tables[0].Rows[i]["Default"].ToString().Trim() == "")
    //                {
    //                    _obj_Smhr_BusinessUnitBank.BUSUNTBANK_ISDEFAULT = false;

    //                }
    //                else
    //                {
    //                    _obj_Smhr_BusinessUnitBank.BUSUNTBANK_ISDEFAULT = Convert.ToBoolean(ds.Tables[0].Rows[i]["Default"]);
    //                }

    //                _obj_Smhr_BusinessUnitBank.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
    //                _obj_Smhr_BusinessUnitBank.CREATEDDATE = DateTime.Now;

    //                _obj_Smhr_BusinessUnitBank.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
    //                _obj_Smhr_BusinessUnitBank.LASTMDFDATE = DateTime.Now;
    //                _obj_Smhr_BusinessUnitBank.OPERATION = operation.Insert;
    //                status = BLL.set_BusinessUnitBank(_obj_Smhr_BusinessUnitBank);
    //                //    BLL.ShowMessage(this, "Information Saved Successfully");
    //                //else
    //                //    BLL.ShowMessage(this, "Information Not Saved");

    //            }
    //            if (status == true)
    //                BLL.ShowMessage(this, "Information Saved Successfully");
    //            else
    //            {
    //            }
    //            LoadGrid();
    //            Rg_BusinessUnitBank.DataBind();

    //        }


    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}
    protected void Rg_BusinessUnitBank_ItemDataBound(object sender, GridItemEventArgs e) //Inserted By Ragha Sudha for BUg:53 on 05-Nov-2013
    {
        try
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;

                string str = item["BUSUNTBANK_ACCOUNTNO"].Text;
                if (str.Length > 4)
                {
                    string str1 = str.Substring(str.Length - 4);
                    string str2 = str.Substring(0, str.Length - 4);
                    string str3 = "";
                    for (int i = 0; i <= str2.Length - 1; i++)
                    {
                        if (str3 == "")
                            str3 = "X";
                        else
                            str3 = str3 + "X";
                    }
                    string Final = str3 + str1;


                    item["BUSUNTBANK_ACCOUNTNO"].Text = Convert.ToString(Final);
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BusinessUnitBanks", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
