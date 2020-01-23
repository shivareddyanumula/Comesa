﻿using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Masters_frm_EmployeeType : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    SMHR_EMPLOYEETYPE _obj_Smhr_EmployeeType;
    string strfilename2;

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Employee Type");//COUNTRY");
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
                    Rg_EmployeeTypes.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeType", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void clearControls()
    {
        try
        {
            lbl_EmployeeTypeID.Text = string.Empty;
            rtxt_EmployeeTypeCode.Text = string.Empty;
            rtxt_EmployeeTypeDesc.Text = string.Empty;
            rtxt_EmployeeTypePrefix.Text = string.Empty;
            rtxt_EmployeeTypeSerialNo.Text = string.Empty;
            btn_Save.Visible = false;
            btn_Update.Visible = false;
            Rm_CY_page.SelectedIndex = 0;
            rmtxt_EmpTypeAge.Value = 18;
            rmtxt_EmpTypeAgeM.Value = 18;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeType", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            clearControls();
            _obj_Smhr_EmployeeType = new SMHR_EMPLOYEETYPE();
            _obj_Smhr_EmployeeType.EMPLOYEETYPE_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            _obj_Smhr_EmployeeType.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_EmployeeType(_obj_Smhr_EmployeeType);
            lbl_EmployeeTypeID.Text = Convert.ToString(dt.Rows[0]["EmployeeType_ID"]);

            rtxt_EmployeeTypeCode.Text = Convert.ToString(dt.Rows[0]["EMPLOYEETYPE_CODE"]);
            rtxt_EmployeeTypeDesc.Text = Convert.ToString(dt.Rows[0]["EMPLOYEETYPE_DESC"]);
            rtxt_EmployeeTypePrefix.Text = Convert.ToString(dt.Rows[0]["EMPLOYEETYPE_PREFIX"]);
            rtxt_EmployeeTypeSerialNo.Text = Convert.ToString(dt.Rows[0]["EMPLOYEETYPE_SERIALNO"]);
            string[] empTypeAge = Convert.ToString(dt.Rows[0]["EmployeeTypeAge"]).Split(new char[] { '-' });
            if (empTypeAge.Length > 1)
            {
                rmtxt_EmpTypeAge.Text = empTypeAge[0];
                rmtxt_EmpTypeAgeM.Text = empTypeAge[1];
            }

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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeType", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeType", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rg_EmployeeTypes_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeType", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    public void LoadGrid()
    {
        try
        {
            _obj_Smhr_EmployeeType = new SMHR_EMPLOYEETYPE();
            _obj_Smhr_EmployeeType.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            DataTable DT = BLL.get_EmployeeType(_obj_Smhr_EmployeeType);
            Rg_EmployeeTypes.DataSource = DT;

            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeType", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_Smhr_EmployeeType = new SMHR_EMPLOYEETYPE();
            _obj_Smhr_EmployeeType.EMPLOYEETYPE_CODE = BLL.ReplaceQuote(rtxt_EmployeeTypeCode.Text);
            _obj_Smhr_EmployeeType.EMPLOYEETYPE_DESC = BLL.ReplaceQuote(rtxt_EmployeeTypeDesc.Text);
            _obj_Smhr_EmployeeType.EMPLOYEETYPE_PREFIX = BLL.ReplaceQuote(rtxt_EmployeeTypePrefix.Text);
            _obj_Smhr_EmployeeType.EMPLOYEETYPE_SERIALNO = BLL.ReplaceQuote(rtxt_EmployeeTypeSerialNo.Text);
            _obj_Smhr_EmployeeType.EMPLOYEETYPE_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //_obj_Smhr_EmployeeType.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            //_obj_Smhr_EmployeeType.CREATEDDATE = DateTime.Now;
            
                _obj_Smhr_EmployeeType.EmployeeTypeAge = BLL.ReplaceQuote(rmtxt_EmpTypeAge.Text) + "-" + BLL.ReplaceQuote(rmtxt_EmpTypeAgeM.Text);

            _obj_Smhr_EmployeeType.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_EmployeeType.LASTMDFDATE = DateTime.Now;

            _obj_Smhr_EmployeeType.EMPLOYEETYPE_ID = Convert.ToInt32(lbl_EmployeeTypeID.Text);
            _obj_Smhr_EmployeeType.OPERATION = operation.Update;
            if (BLL.set_EmployeeType(_obj_Smhr_EmployeeType))
                BLL.ShowMessage(this, "Information Updated Successfully");
            else
                BLL.ShowMessage(this, "Information Not Updated");


            Rm_CY_page.SelectedIndex = 0;
            LoadGrid();
            Rg_EmployeeTypes.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeType", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeType", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeType", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //protected void Btn_Imp_Businessunit_click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        // written by rajasekhar
    //        // to import EmployeeType details

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
    //        if (ds.Tables[0].Columns[2].ToString().Trim() == "")
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

    //            errormsg = string.Empty;
    //            columnno = string.Empty;
    //            if (ds.Tables[0].Rows[i]["Name*"].ToString().Trim() != "")
    //            {
    //                _obj_Smhr_EmployeeType = new SMHR_EMPLOYEETYPE();
    //                _obj_Smhr_EmployeeType.EMPLOYEETYPE_CODE = ds.Tables[0].Rows[i]["Name*"].ToString().Trim();
    //                _obj_Smhr_EmployeeType.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);


    //                _obj_Smhr_EmployeeType.OPERATION = operation.Check;
    //                if (Convert.ToString(BLL.get_EmployeeType(_obj_Smhr_EmployeeType).Rows[0]["Count"]) != "0")
    //                {
    //                    errormsg = "EmployeeType Name Already Exists";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = "Name*";
    //                }
    //                else
    //                {

    //                }
    //                for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
    //                {
    //                    if (ds.Tables[0].Rows[i]["Name*"].ToString().Trim() == ds.Tables[0].Rows[k]["Name*"].ToString().Trim())
    //                    {
    //                        if (i != k)
    //                        {
    //                            errormsg = errormsg + "," + " EmployeeType Name is repeated in Excel Sheet";
    //                            filestatus = false;
    //                            rowno = i + 2;
    //                            columnno = "Name*";
    //                        }
    //                    }
    //                }

    //            }

    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = "Name*";
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

    //                _obj_Smhr_EmployeeType = new SMHR_EMPLOYEETYPE();
    //                _obj_Smhr_EmployeeType.EMPLOYEETYPE_CODE = ds.Tables[0].Rows[i]["Name*"].ToString().Trim();
    //                _obj_Smhr_EmployeeType.EMPLOYEETYPE_DESC = ds.Tables[0].Rows[i]["Description"].ToString().Trim();
    //                _obj_Smhr_EmployeeType.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                _obj_Smhr_EmployeeType.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
    //                _obj_Smhr_EmployeeType.CREATEDDATE = DateTime.Now;

    //                _obj_Smhr_EmployeeType.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
    //                _obj_Smhr_EmployeeType.LASTMDFDATE = DateTime.Now;
    //                _obj_Smhr_EmployeeType.OPERATION = operation.Insert;
    //                status = BLL.set_EmployeeType(_obj_Smhr_EmployeeType);

    //            }
    //            if (status == true)
    //            {
    //                BLL.ShowMessage(this, "Information Saved Successfully");
    //            }
    //            else
    //            {
    //            }
    //            LoadGrid();
    //            Rg_EmployeeTypes.DataBind();

    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}
}