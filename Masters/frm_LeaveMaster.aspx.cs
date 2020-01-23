using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Data;
using Telerik.Web.UI;
using System.Data.OleDb;
using System.IO;




public partial class Masters_frm_LeaveMaster : System.Web.UI.Page
{
    string strfilename2;
    DataSet ds = new DataSet();


    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Leave Type");//LEAVE ITEM");
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
                    RG_LeaveMaster.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
                LoadGrid();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            clearControls();
            rtxt_LeaveMasterCode.Enabled = false;
            DataTable dt = BLL.get_LeaveMaster(new SMHR_LEAVEMASTER(Convert.ToInt32(Convert.ToString(e.CommandArgument))));
            lbl_LeaveMaster_ID.Text = Convert.ToString(dt.Rows[0]["LEAVEMASTER_ID"]);
            rtxt_LeaveMasterCode.Text = Convert.ToString(dt.Rows[0]["LEAVEMASTER_CODE"]);
            rtxt_LeaveMasterDesc.Text = Convert.ToString(dt.Rows[0]["LEAVEMASTER_DESCRIPTION"]);
            //if (Convert.ToString(dt.Rows[0]["LEAVEMASTER_COMPOFF"]) == "True")
            //{
            //    rchk_compoff.Checked = true;
            //}
            //else
            //{
            //    rchk_compoff.Checked = false;
            //}
            if (Convert.ToString(dt.Rows[0]["LEAVEMASTER_ALLOWPAY"]) == "True")
            {
                chk_allowpay.Checked = true;
            }
            else
            {
                chk_allowpay.Checked = false;
            }

            if (Convert.ToBoolean(dt.Rows[0]["LEAVEMASTER_ISINCIDENT"]) == true)
            {
                chk_IncidentLeave.Checked = true;
            }
            else
            {
                chk_IncidentLeave.Checked = false;
            }
            //code for security
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Edit.Visible = false;

            }

            else
            {
                btn_Edit.Visible = true;
            }
            rm_MR_Page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            clearControls();
            btn_Save.Visible = true;
            rm_MR_Page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void LoadGrid()
    {
        try
        {
            SMHR_LEAVEMASTER _obj_smhr_leavemaster = new SMHR_LEAVEMASTER();
            _obj_smhr_leavemaster.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            DataTable DT = BLL.get_LeaveMaster(_obj_smhr_leavemaster);
            RG_LeaveMaster.DataSource = DT;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        //clearControls();
    }
    protected void clearControls()
    {
        try
        {
            lbl_LeaveMaster_ID.Text = string.Empty;
            rtxt_LeaveMasterCode.Text = string.Empty;
            rtxt_LeaveMasterCode.Enabled = true;
            rtxt_LeaveMasterDesc.Text = string.Empty;
            //rchk_compoff.Checked = false;
            chk_allowpay.Checked = false;
            chk_IncidentLeave.Checked = false;
            btn_Save.Visible = false;
            btn_Edit.Visible = false;
            rm_MR_Page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Save_Click1(object sender, EventArgs e)
    {
        try
        {
            SMHR_LEAVEMASTER _obj_smhr_leavemaster = new SMHR_LEAVEMASTER();
            //_obj_smhr_leavemaster = new SMHR_LEAVEMASTER();
            _obj_smhr_leavemaster.LEAVEMASTER_CODE = BLL.ReplaceQuote(rtxt_LeaveMasterCode.Text);
            _obj_smhr_leavemaster.LEAVEMASTER_DESCRIPTION = BLL.ReplaceQuote(rtxt_LeaveMasterDesc.Text);
            _obj_smhr_leavemaster.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            if (chk_allowpay.Checked)
            {
                _obj_smhr_leavemaster.LEAVEMASTER_ALLOWPAY = true;
            }
            else
            {
                _obj_smhr_leavemaster.LEAVEMASTER_ALLOWPAY = false;
            }
            if (rchk_compoff.Checked)
            {
                _obj_smhr_leavemaster.LEAVEMASTER_COMPOFF = 1;
            }
            else
            {
                _obj_smhr_leavemaster.LEAVEMASTER_COMPOFF = 0;
            }
            if (chk_IncidentLeave.Checked)
            {
                _obj_smhr_leavemaster.LEAVEMASTER_ISINCIDENT = true;
            }
            else
            {
                _obj_smhr_leavemaster.LEAVEMASTER_ISINCIDENT = false;
            }


            _obj_smhr_leavemaster.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_smhr_leavemaster.CREATEDDATE = DateTime.Now;

            _obj_smhr_leavemaster.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_smhr_leavemaster.LASTMDFDATE = DateTime.Now;

            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_EDIT":
                    _obj_smhr_leavemaster.LEAVEMASTER_ID = Convert.ToInt32(lbl_LeaveMaster_ID.Text);
                    _obj_smhr_leavemaster.OPERATION = operation.Check;
                    if (Convert.ToString(BLL.get_LeaveMaster(_obj_smhr_leavemaster).Rows[0]["Count"]) != "1")
                    {
                        BLL.ShowMessage(this, "Leave Type with this name Already Exists");
                        return;
                    }
                    _obj_smhr_leavemaster.LEAVEMASTER_ID = Convert.ToInt32(lbl_LeaveMaster_ID.Text);
                    _obj_smhr_leavemaster.OPERATION = operation.Update;
                    if (BLL.set_LeaveMaster(_obj_smhr_leavemaster))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, " Leave Type Not Saved");

                    break;
                case "BTN_SAVE":
                    _obj_smhr_leavemaster.OPERATION = operation.Check;
                    _obj_smhr_leavemaster.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    if (Convert.ToString(BLL.get_LeaveMaster(_obj_smhr_leavemaster).Rows[0]["Count"]) != "0")
                    {
                        BLL.ShowMessage(this, "Leave Type with this name Already Exists");
                        return;
                    }
                    _obj_smhr_leavemaster.OPERATION = operation.Insert;
                    if (BLL.set_LeaveMaster(_obj_smhr_leavemaster))
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    else
                        BLL.ShowMessage(this, "Leave Type Not Saved");
                    break;
                default:
                    break;
            }
            rm_MR_Page.SelectedIndex = 0;
            LoadGrid();
            RG_LeaveMaster.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_Click1(object sender, EventArgs e)
    {
        try
        {
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveMaster", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //protected void Btn_Imp_LeaveMaster_click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        // written by Rajasekhar
    //        // to import LeaveMaster details
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
    //        if (ds.Tables[0].Columns[2].ToString().Trim() == "Check Comp Off")
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
    //            errormsg = string.Empty;
    //            columnno = string.Empty;

    //            if (ds.Tables[0].Rows[i]["Name*"].ToString().Trim() != "")
    //            {
    //                SMHR_LEAVEMASTER _obj_smhr_leavemaster = new SMHR_LEAVEMASTER();
    //                _obj_smhr_leavemaster.LEAVEMASTER_CODE = ds.Tables[0].Rows[i]["Name*"].ToString().Trim();
    //                _obj_smhr_leavemaster.OPERATION = operation.Check;
    //                _obj_smhr_leavemaster.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                if (Convert.ToString(BLL.get_LeaveMaster(_obj_smhr_leavemaster).Rows[0]["Count"]) != "0")
    //                {
    //                    errormsg = "Leave Type with this name Already Exists";
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

    //                SMHR_LEAVEMASTER _obj_smhr_leavemaster = new SMHR_LEAVEMASTER();
    //                _obj_smhr_leavemaster = new SMHR_LEAVEMASTER();
    //                _obj_smhr_leavemaster.LEAVEMASTER_CODE = ds.Tables[0].Rows[i]["Name*"].ToString().Trim();
    //                _obj_smhr_leavemaster.LEAVEMASTER_DESCRIPTION = ds.Tables[0].Rows[i]["Description"].ToString().Trim();
    //                _obj_smhr_leavemaster.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());

    //                _obj_smhr_leavemaster.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
    //                _obj_smhr_leavemaster.CREATEDDATE = DateTime.Now;

    //                _obj_smhr_leavemaster.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
    //                _obj_smhr_leavemaster.LASTMDFDATE = DateTime.Now;
    //                _obj_smhr_leavemaster.OPERATION = operation.Insert;
    //                status = BLL.set_LeaveMaster(_obj_smhr_leavemaster);
    //            }
    //            if (status == true)

    //                BLL.ShowMessage(this, "Information Saved Successfully");
    //            LoadGrid();
    //            RG_LeaveMaster.DataBind();
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;

    //    }

    //}
    protected void AllowPay_click(object sender, EventArgs e)
    {
        try
        {
            if (rtxt_LeaveMasterCode.Text != string.Empty)
            {
                SMHR_LEAVEMASTER _obj_smhr_leavemaster = new SMHR_LEAVEMASTER();


                _obj_smhr_leavemaster.OPERATION = operation.Delete;
                _obj_smhr_leavemaster.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                _obj_smhr_leavemaster.LEAVEMASTER_CODE = rtxt_LeaveMasterCode.Text;
                DataTable dt = BLL.get_LeaveMaster(_obj_smhr_leavemaster);
                if (chk_allowpay.Checked)
                {
                    if (dt.Rows.Count != 0)
                    {
                        if (Convert.ToInt32(dt.Rows[0]["count"]) != 0)
                        {
                            chk_allowpay.Checked = false;
                            BLL.ShowMessage(this, " Already Exists");

                            return;
                        }
                    }
                    else
                    {
                    }
                }
            }
            else
            {
                BLL.ShowMessage(this, "Please Enter Name");
                return;
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void chk_IncidentLeave_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (rtxt_LeaveMasterCode.Text != string.Empty)
            {
                if (chk_IncidentLeave.Checked)
                {
                    SMHR_LEAVEMASTER _obj_smhr_leavemaster = new SMHR_LEAVEMASTER();
                    _obj_smhr_leavemaster.OPERATION = operation.CHECKEXISTS;
                    _obj_smhr_leavemaster.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                    _obj_smhr_leavemaster.LEAVEMASTER_CODE = rtxt_LeaveMasterCode.Text;
                    DataTable dt = BLL.get_LeaveMaster(_obj_smhr_leavemaster);  //To check if any Incident leavetype exists

                    if (dt.Rows.Count != 0)
                    {   //If exists then, must not allow to insert again
                        {
                            if (Convert.ToInt32(dt.Rows[0]["count"]) != 0)
                            {
                                chk_IncidentLeave.Checked = false;
                                BLL.ShowMessage(this, "Already Exists");
                                return;
                            }
                        }
                    }
                }
            }
            else
            {
                BLL.ShowMessage(this, "Please Enter Name");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void RG_LeaveMaster_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
