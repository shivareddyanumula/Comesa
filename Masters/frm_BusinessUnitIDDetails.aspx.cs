﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using Telerik.Web.UI;
using System.IO;
using System.Data.OleDb;


public partial class Masters_frm_BusinessUnitIDDetails : System.Web.UI.Page
{
    SMHR_BUSINESSUNITIDDETAILS _obj_Smhr_BuIDDetails;
    SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    string strfilename2;
    DataSet ds = new DataSet();
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

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


                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Business Unit Other Information");//BUSINESS UNIT DETAILS");
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
                    Rg_BUIDDetails.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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

                lbl_BUIDHeader.Visible = true;
                //Rm_BUIDDetails_page.SelectedIndex = 0;
                Page.Validate();


            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BusinessUnitIDDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            //lbl_BUIDHeader.Visible = false;
            //loadDropdown();
            clearControls();
            LoadCombos();
            rtxt_BUIDDetails_Name.Enabled = false;
            rcmb_BUCode.Enabled = false;
            DataTable dt = BLL.get_BusinessUnitIDDetails(new SMHR_BUSINESSUNITIDDETAILS(Convert.ToInt32(Convert.ToString(e.CommandArgument))));
            lbl_BUIDDetails_ID.Text = Convert.ToString(dt.Rows[0]["BUIDDETAILS_ID"]);
            rtxt_BUIDDetails_Name.Text = Convert.ToString(dt.Rows[0]["BUIDDETAILS_NAME"]);
            rtxt_BUIDDetails_Desc.Text = Convert.ToString(dt.Rows[0]["BUIDDETAILS_DESCRIPTION"]);
            rtxt_BUIDDetails_Value.Text = Convert.ToString(dt.Rows[0]["BUIDDETAILS_VALUE"]);
            rcmb_BUCode.SelectedIndex = rcmb_BUCode.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["BUIDDETAILS_BUID"]));

            //code for security
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Update.Visible = false;

            }

            else
            {
                btn_Update.Visible = true;
            }

            Rm_BUIDDetails_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BusinessUnitIDDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            //lbl_BUIDHeader.Visible = false;
            //loadDropdown();
            clearControls();
            LoadCombos();
            btn_Save.Visible = true;
            Rm_BUIDDetails_page.SelectedIndex = 1;
            rtxt_BUIDDetails_Name.Enabled = true;
            rcmb_BUCode.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BusinessUnitIDDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void LoadGrid()
    {

        try
        {
            //_obj_Smhr_BuIDDetails.OPERATION = operation.Select;
            SMHR_BUSINESSUNITIDDETAILS _obj_Smhr_BuIDDetails = new SMHR_BUSINESSUNITIDDETAILS();
            _obj_Smhr_BuIDDetails.OPERATION = operation.Check1;
            _obj_Smhr_BuIDDetails.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT = BLL.get_BusinessUnitIDDetails(_obj_Smhr_BuIDDetails);
            Rg_BUIDDetails.DataSource = DT;
            //Rg_BUIDDetails.DataBind();
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BusinessUnitIDDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_Smhr_BuIDDetails = new SMHR_BUSINESSUNITIDDETAILS();
            _obj_Smhr_BuIDDetails.BUIDDETAILS_NAME = BLL.ReplaceQuote(rtxt_BUIDDetails_Name.Text.ToUpper());
            _obj_Smhr_BuIDDetails.BUIDDETAILS_DESCRIPTION = BLL.ReplaceQuote(rtxt_BUIDDetails_Desc.Text);
            _obj_Smhr_BuIDDetails.BUIDDETAILS_VALUE = BLL.ReplaceQuote(rtxt_BUIDDetails_Value.Text);
            _obj_Smhr_BuIDDetails.BUIDDETAILS_BUID = rcmb_BUCode.SelectedItem.Value;

            _obj_Smhr_BuIDDetails.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_BuIDDetails.CREATEDDATE = DateTime.Now;

            _obj_Smhr_BuIDDetails.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_BuIDDetails.LASTMDFDATE = DateTime.Now;
            _obj_Smhr_BuIDDetails.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_UPDATE":
                    _obj_Smhr_BuIDDetails.BUIDDETAILS_ID = Convert.ToInt32(lbl_BUIDDetails_ID.Text);
                    //_obj_Smhr_BuIDDetails.OPERATION = operation.Check;
                    _obj_Smhr_BuIDDetails.OPERATION = operation.Validate;
                    if (Convert.ToString(BLL.get_BusinessUnitIDDetails(_obj_Smhr_BuIDDetails).Rows[0]["Count"]) != "1")
                    {
                        BLL.ShowMessage(this, "Other Information Already Exists.");
                        return;
                    }
                    _obj_Smhr_BuIDDetails.OPERATION = operation.Update;
                    _obj_Smhr_BuIDDetails.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    if (BLL.set_BusinessUnitIDDetails(_obj_Smhr_BuIDDetails))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                case "BTN_SAVE":
                    //_obj_Smhr_BuIDDetails.OPERATION = operation.Check;
                    _obj_Smhr_BuIDDetails.OPERATION = operation.Validate;
                    if (Convert.ToString(BLL.get_BusinessUnitIDDetails(_obj_Smhr_BuIDDetails).Rows[0]["Count"]) != "0")
                    {
                        BLL.ShowMessage(this, "Other Information Already Exists.");
                        return;
                    }
                    _obj_Smhr_BuIDDetails.OPERATION = operation.Insert;
                    _obj_Smhr_BuIDDetails.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    if (BLL.set_BusinessUnitIDDetails(_obj_Smhr_BuIDDetails))
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                default:
                    break;
            }
            Rm_BUIDDetails_page.SelectedIndex = 0;
            LoadGrid();
            Rg_BUIDDetails.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BusinessUnitIDDetails", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BusinessUnitIDDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rg_BUIDDetails_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
            //SMHR_BUSINESSUNITIDDETAILS _obj_Smhr_BuIDDetails = new SMHR_BUSINESSUNITIDDETAILS();
            //_obj_Smhr_BuIDDetails.OPERATION = operation.Select;
            //DataTable DT = BLL.get_BusinessUnitIDDetails(new SMHR_BUSINESSUNITIDDETAILS());
            //Rg_BUIDDetails.DataSource = DT;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BusinessUnitIDDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadCombos()
    {
        try
        {
            rcmb_BUCode.Items.Clear();
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            rcmb_BUCode.DataSource = dt_BUDetails;
            rcmb_BUCode.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BUCode.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BUCode.DataBind();
            rcmb_BUCode.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BusinessUnitIDDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void clearControls()
    {
        try
        {
            rtxt_BUIDDetails_Name.Text = string.Empty;
            rtxt_BUIDDetails_Desc.Text = string.Empty;
            rtxt_BUIDDetails_Value.Text = string.Empty;
            rcmb_BUCode.SelectedIndex = -1;
            btn_Save.Visible = false;
            btn_Update.Visible = false;
            Rm_BUIDDetails_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BusinessUnitIDDetails", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BusinessUnitIDDetails", ex.StackTrace, DateTime.Now);
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
    //        if (ds.Tables[0].Columns[0].ToString().Trim() == "Business Unit*")
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
    //        if (ds.Tables[0].Columns[2].ToString().Trim() == "Description*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        } if (ds.Tables[0].Columns[3].ToString().Trim() == "Value*")
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
    //            if (ds.Tables[0].Rows[i]["Business Unit*"].ToString().Trim() != "")
    //            {
    //                SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
    //                _obj_Smhr_BusinessUnit.BUSINESSUNIT_CODE = ds.Tables[0].Rows[i]["Business Unit*"].ToString().Trim();
    //                _obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                _obj_Smhr_BusinessUnit.OPERATION = operation.Validate;
    //                DataTable dt_businessunit = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
    //                if (Convert.ToInt32(dt_businessunit.Rows[0]["COUNT"]) == 0)
    //                {
    //                    errormsg = "Busines Unit with this Name Does not Exists";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = "Business Unit*";
    //                }
    //                else
    //                {

    //                }

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = "Business Unit*";

    //            }

    //            if (ds.Tables[0].Rows[i]["Name*"].ToString().Trim() != "")
    //            {
    //                _obj_Smhr_BuIDDetails = new SMHR_BUSINESSUNITIDDETAILS();
    //                _obj_Smhr_BuIDDetails.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                _obj_Smhr_BuIDDetails.BUIDDETAILS_NAME = ds.Tables[0].Rows[i]["Name*"].ToString().Trim();
    //                _obj_Smhr_BuIDDetails.OPERATION = operation.Validate;
    //                DataTable dt_Buidname = BLL.get_BusinessUnitIDDetails(_obj_Smhr_BuIDDetails);
    //                if (Convert.ToInt32(dt_Buidname.Rows[0]["COUNT"]) > 0)
    //                {
    //                    errormsg = errormsg + "," + "Businessunit Name with this Businessunit Code Already Exists";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = columnno + "," + "Name*";
    //                }
    //                else
    //                {
    //                }


    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Name*";
    //            }

    //            if (ds.Tables[0].Rows[i]["Description*"].ToString().Trim() != "")
    //            {
    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Description*";
    //            }
    //            if (ds.Tables[0].Rows[i]["Value*"].ToString().Trim() != "")
    //            {
    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = columnno + "," + "Value*";
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

    //                _obj_Smhr_BusinessUnit.BUSINESSUNIT_CODE = ds.Tables[0].Rows[i]["Business Unit*"].ToString().Trim();
    //                _obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                _obj_Smhr_BusinessUnit.OPERATION = operation.Get;
    //                DataTable dt_businessunit = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
    //                if (dt_businessunit.Rows.Count > 0)
    //                {
    //                    businessunitid = Convert.ToInt32(dt_businessunit.Rows[0]["BUSINESSUNIT_ID"]);

    //                }

    //                _obj_Smhr_BuIDDetails = new SMHR_BUSINESSUNITIDDETAILS();
    //                _obj_Smhr_BuIDDetails.BUIDDETAILS_BUID = Convert.ToString(businessunitid);
    //                _obj_Smhr_BuIDDetails.BUIDDETAILS_NAME = ds.Tables[0].Rows[i]["Name*"].ToString().Trim();
    //                _obj_Smhr_BuIDDetails.BUIDDETAILS_DESCRIPTION = ds.Tables[0].Rows[i]["Description*"].ToString().Trim();
    //                _obj_Smhr_BuIDDetails.BUIDDETAILS_VALUE = ds.Tables[0].Rows[i]["Value*"].ToString().Trim();

    //                _obj_Smhr_BuIDDetails.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
    //                _obj_Smhr_BuIDDetails.CREATEDDATE = DateTime.Now;

    //                _obj_Smhr_BuIDDetails.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
    //                _obj_Smhr_BuIDDetails.LASTMDFDATE = DateTime.Now;
    //                _obj_Smhr_BuIDDetails.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                _obj_Smhr_BuIDDetails.OPERATION = operation.Insert;
    //                //_obj_Smhr_BuIDDetails.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                status = BLL.set_BusinessUnitIDDetails(_obj_Smhr_BuIDDetails);




    //            }
    //            if (status == true)
    //            {
    //                BLL.ShowMessage(this, "Information Saved Successfully");
    //            }
    //            LoadGrid();
    //            Rg_BUIDDetails.DataBind();

    //        }



    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;

    //    }
    //}
}