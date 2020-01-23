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
using System.Data.SqlClient;
using System.Data.Sql;
using Telerik.Web.UI;
using System.IO;
using System.Data.OleDb;

public partial class Masters_frmPosition : System.Web.UI.Page
{
    smhr_UNAUTHORIZED _obj_smhr_unauthorized;

    #region References

    DataSet ds = new DataSet();
    //SqlDataAdapter da;
    string filedatetime;
    #endregion

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (RWM_POSITIONPOSTREPLY.Windows.Count > 0)
            {
                RWM_POSITIONPOSTREPLY.Windows.RemoveAt(0);
            }
            if (!Page.IsPostBack)
            {
                BLL.ChangeDateFormat(Convert.ToString(Session["EMP_ID"]), rdtp_PositionsStartDate, rdtp_PositionsEndDate);


                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("POSITION");
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
                        ViewState["FORMS_ID"] = dtformdtls.Rows[0]["TYPSEC_FORMS_ID"];
                        ViewState["MODULE_ID"] = dtformdtls.Rows[0]["MODULE_ID"];
                    }
                }

                else
                {
                    _obj_smhr_unauthorized = new smhr_UNAUTHORIZED();
                    _obj_smhr_unauthorized.UNAUTHORIZED_USERID = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_unauthorized.UNAUTHORIZED_FORMID = Convert.ToInt32(ViewState["FORMS_ID"]);
                    _obj_smhr_unauthorized.UNAUTHORIZED_MODULEID = Convert.ToInt32(ViewState["MODULE_ID"]);
                    _obj_smhr_unauthorized.UNAUTHORIZED_ACCESSDATE = Convert.ToDateTime(DateTime.Now.ToString());
                    SMHR.BLL.UnAuthorized_Log(_obj_smhr_unauthorized);
                    Response.Redirect("~/frm_UnAuthorized.aspx", false);
                }


                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    Rg_Positions.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Save.Visible = false;
                    btn_Edit.Visible = false;
                }
                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 3)
                {
                    _obj_smhr_unauthorized = new smhr_UNAUTHORIZED();
                    _obj_smhr_unauthorized.UNAUTHORIZED_USERID = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_unauthorized.UNAUTHORIZED_FORMID = Convert.ToInt32(ViewState["FORMS_ID"]);
                    _obj_smhr_unauthorized.UNAUTHORIZED_MODULEID = Convert.ToInt32(ViewState["MODULE_ID"]);
                    _obj_smhr_unauthorized.UNAUTHORIZED_ACCESSDATE = Convert.ToDateTime(DateTime.Now.ToString());
                    SMHR.BLL.UnAuthorized_Log(_obj_smhr_unauthorized);
                    Response.Redirect("~/frm_UnAuthorized.aspx", false);
                }
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmPosition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            loadDropdown();
            clearControls();
            SMHR_POSITIONS _obj_Smhr_Positions = new SMHR_POSITIONS();
            _obj_Smhr_Positions.POSITIONS_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            _obj_Smhr_Positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_Positions(_obj_Smhr_Positions);
            //rtxt_PositionsCode.Enabled = false;
            rcmb_PositionsJobs.Enabled = false;
            lbl_PositionsID.Text = Convert.ToString(dt.Rows[0]["POSITIONS_ID"]);
            rtxt_PositionsCode.Text = Convert.ToString(dt.Rows[0]["POSITIONS_CODE"]);
            rtxt_PositionsDesc.Text = Convert.ToString(dt.Rows[0]["POSITIONS_DESC"]);
            rcmb_PositionsJobs.SelectedIndex = rcmb_PositionsJobs.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["POSITIONS_JOBSID"]));
            rcmb_PositionsJobs_SelectedIndexChanged(null, null);
            rcmb_PositionsStatus.SelectedIndex = rcmb_PositionsStatus.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["POSITIONS_STATUS"]));
            rdtp_PositionsStartDate.SelectedDate = null;
            rdtp_PositionsEndDate.SelectedDate = null;

            if (dt.Rows[0]["POSITIONS_STARTDATE"] != DBNull.Value)
                rdtp_PositionsStartDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["POSITIONS_STARTDATE"]);
            if (dt.Rows[0]["POSITIONS_ENDDATE"] != DBNull.Value)
                rdtp_PositionsEndDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["POSITIONS_ENDDATE"]);
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Edit.Visible = false;

            }

            else
            {
                btn_Edit.Visible = true;
            }

            Rm_PO_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmPosition", ex.StackTrace, DateTime.Now);
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
            rcmb_PositionsJobs.Enabled = true;
            Rm_PO_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmPosition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    public void LoadGrid()
    {
        try
        {
            SMHR_POSITIONS _obj_smhr_Position = new SMHR_POSITIONS();
            _obj_smhr_Position.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            DataTable DT = BLL.get_Positions(_obj_smhr_Position);
            Rg_Positions.DataSource = DT;
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmPosition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void loadDropdown()
    {
        try
        {
            rcmb_PositionsJobs.Items.Clear();
            SMHR_JOBS _obj_Smhr_Jobs = new SMHR_JOBS();
            _obj_Smhr_Jobs.OPERATION = operation.Select;
            _obj_Smhr_Jobs.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_Smhr_Jobs.ISDELETED = false;
            rcmb_PositionsJobs.DataSource = BLL.get_Jobs(_obj_Smhr_Jobs);
            rcmb_PositionsJobs.DataTextField = "JOBS_CODE";
            rcmb_PositionsJobs.DataValueField = "JOBS_ID";
            rcmb_PositionsJobs.DataBind();
            rcmb_PositionsJobs.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmPosition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_POSITIONS _obj_Smhr_Positions = new SMHR_POSITIONS();
            _obj_Smhr_Positions.POSITIONS_CODE = BLL.ReplaceQuote(rtxt_PositionsCode.Text);
            _obj_Smhr_Positions.POSITIONS_DESC = BLL.ReplaceQuote(rtxt_PositionsDesc.Text);
            _obj_Smhr_Positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());

            _obj_Smhr_Positions.POSITIONS_JOBSID = Convert.ToInt32(rcmb_PositionsJobs.SelectedItem.Value);
            _obj_Smhr_Positions.POSITIONS_STATUS = Convert.ToInt32(rcmb_PositionsStatus.SelectedItem.Value);

            _obj_Smhr_Positions.STARTDATE = rdtp_PositionsStartDate.SelectedDate;
            _obj_Smhr_Positions.ENDDATE = rdtp_PositionsEndDate.SelectedDate;


            _obj_Smhr_Positions.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_Positions.CREATEDDATE = DateTime.Now;

            _obj_Smhr_Positions.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_Positions.LASTMDFDATE = DateTime.Now;

            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_EDIT":
                    _obj_Smhr_Positions.POSITIONS_ID = Convert.ToInt32(lbl_PositionsID.Text);
                    _obj_Smhr_Positions.OPERATION = operation.Check;
                    if (Convert.ToString(BLL.get_Positions(_obj_Smhr_Positions).Rows[0]["Count"]) != "1")
                    {
                        //BLL.ShowMessage(this, "Position with this Name Already Exists");
                        //return;
                    }
                    _obj_Smhr_Positions.OPERATION = operation.Update;
                    if (BLL.set_Positions(_obj_Smhr_Positions))
                        BLL.ShowMessage(this, "Information Updated SuccessFully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");

                    break;
                case "BTN_SAVE":
                    _obj_Smhr_Positions.OPERATION = operation.Check;
                    if (Convert.ToString(BLL.get_Positions(_obj_Smhr_Positions).Rows[0]["Count"]) != "0")
                    {
                        BLL.ShowMessage(this, "Positions with this Name Already Exists");
                        return;
                    }
                    _obj_Smhr_Positions.OPERATION = operation.Insert;
                    if (BLL.set_Positions(_obj_Smhr_Positions))
                        BLL.ShowMessage(this, "Information Saved SuccessFully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                default:
                    break;
            }
            Rm_PO_page.SelectedIndex = 0;
            LoadGrid();
            Rg_Positions.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmPosition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void clearControls()
    {
        lbl_PositionsID.Text = string.Empty;
        rtxt_PositionsCode.Text = string.Empty;
        rtxt_PositionsDesc.Text = string.Empty;
        rcmb_PositionsJobs.SelectedIndex = -1;
        rcmb_PositionsStatus.SelectedIndex = -1;
        rdtp_PositionsStartDate.SelectedDate = null;
        rdtp_PositionsEndDate.SelectedDate = null;
        rtxt_PositionsCode.Enabled = true;
        lbl_PositionsStartDate0.SelectedDate = null;
        lbl_PositionsEndDate0.SelectedDate = null;

        btn_Save.Visible = false;
        btn_Edit.Visible = false;
        Rm_PO_page.SelectedIndex = 0;
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmPosition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rg_Positions_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        LoadGrid();
    }

    protected void rcmb_PositionsJobs_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_PositionsJobs.SelectedIndex == -1 || rcmb_PositionsJobs.SelectedIndex == 0)
            {
                lbl_PositionsStartDate0.SelectedDate = null;
                lbl_PositionsEndDate0.SelectedDate = null;
            }
            else
            {
                DataTable dttemp = new DataTable();
                dttemp = BLL.get_Jobs(new SMHR_JOBS(Convert.ToInt32(rcmb_PositionsJobs.SelectedItem.Value)));
                if (dttemp.Rows.Count != 0)
                {
                    if (dttemp.Rows[0]["JOBS_STARTDATE"] != DBNull.Value)
                        lbl_PositionsStartDate0.SelectedDate = Convert.ToDateTime(dttemp.Rows[0]["JOBS_STARTDATE"]);
                    if (dttemp.Rows[0]["JOBS_ENDDATE"] != DBNull.Value)
                        lbl_PositionsEndDate0.SelectedDate = Convert.ToDateTime(dttemp.Rows[0]["JOBS_ENDDATE"]);
                }
                else
                {
                    lbl_PositionsStartDate0.SelectedDate = null;
                    lbl_PositionsEndDate0.SelectedDate = null;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmPosition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #region Import Position

    protected void btn_Import_Click(object sender, EventArgs e)
    {
        try
        {
            string strcon = null;
            string errormsg = "";
            string filename = fupld_Position.FileName;
            filedatetime = Convert.ToString(DateTime.Now.TimeOfDay) + "_" + filename;
            filedatetime = filedatetime.Replace("/", "").Replace(":", ".");
            if (fupld_Position.HasFile)
            {
                if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == false)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath("~/IMPORT_EXCEL/"));
                }
                fupld_Position.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/IMPORT_EXCEL/"), filedatetime));
                string filename1 = Server.MapPath("~/IMPORT_EXCEL/") + ("") + (Convert.ToString(filedatetime));
                FileInfo fileInfo = new FileInfo(filename1);
                if (fileInfo.Exists)
                {
                    string path = MapPath(filename);
                    string ext = Path.GetExtension(path);
                    string type = string.Empty;

                    //  set known types based on file extension  
                    if (ext != null)
                    {
                        switch (ext.ToLower())
                        {
                            case ".xls": type = "excel";
                                break;
                            case ".xlsx": type = "excel";
                                break;
                            default: type = string.Empty;
                                break;
                        }
                    }
                    if (type == string.Empty)
                    {
                        if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == true)
                        {
                            string path1 = Server.MapPath("~/IMPORT_EXCEL/") + ("") + (Convert.ToString(filedatetime));
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
            strpath = strpath + filedatetime;


            // Getting data from excell file to dataset.
            strcon = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source='" + strpath + "';" + "Extended Properties=Excel 12.0;";
            OleDbConnection objConn = null;
            objConn = new OleDbConnection(strcon);
            objConn.Open();

            DataTable dt_check = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string sheetname;
            if (dt_check == null)
            {
                objConn.Close();
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            else
            {
                sheetname = Convert.ToString(dt_check.Rows[0]["TABLE_NAME"]);
            }
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM  [" + sheetname + "]", strcon);
            da.Fill(ds);
            ds.Tables[0].Columns.Add("Error Message");
            objConn.Close();
            DataTable dt = new DataTable();
            DataTable dtfail = new DataTable();
            string projecttype = null;
            Int32 rowno = 0;
            string columnno = null;
            //Boolean filestatus = true;
            dtfail.Columns.Add("S.NO", typeof(Int32));
            dtfail.Columns.Add("ROWNO", typeof(Int32));
            dtfail.Columns.Add("COLUMNS NAME", typeof(string));
            //For Checking The Position Name Field Is There or not in the excel sheet
            if (!(ds.Tables[0].Columns[0].ToString().Trim() == "Name *"))
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            //For Checking The Position Description Field Is There or not in the excel sheet
            if (!(ds.Tables[0].Columns[1].ToString().Trim() == "Description"))
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            //For Checking The Availability of Job Field
            if (!(ds.Tables[0].Columns[2].ToString() == "Job *"))
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }

            //For Checking The Availability of Status
            if (!(ds.Tables[0].Columns[3].ToString() == "Status *"))
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }

            //For Checking The Availability of Start Date 
            if (!(ds.Tables[0].Columns[4].ToString() == "Start Date *(DD/MM/YYYY)"))
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;

            }
            //For Checking The Availability of End Date 
            if (!(ds.Tables[0].Columns[5].ToString() == "End Date (DD/MM/YYYY)"))
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }

            //For Checking The Availability of the Records In The Excel Sheet
            if (ds.Tables[0].Rows.Count == 0)
            {
                BLL.ShowMessage(this, "Imported Successfully But There is No Record Available!");
                Delete_Excel_File();
                return;
            }
            else
            {
                bool IsCorrect = true;
                bool found = false;
                int jobid = 0;
                SMHR_POSITIONS _obj_Smhr_Positions = new SMHR_POSITIONS();
                loadDropdown();
                //For Validating The Excel Sheet
                for (int rowindex = 0; rowindex < ds.Tables[0].Rows.Count; rowindex++)
                {

                    if (Convert.ToString(ds.Tables[0].Rows[rowindex][0]) != string.Empty)
                    {
                        _obj_Smhr_Positions.OPERATION = operation.Check;
                        _obj_Smhr_Positions.POSITIONS_CODE = Convert.ToString(ds.Tables[0].Rows[rowindex][0]);
                        _obj_Smhr_Positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        if (Convert.ToString(BLL.get_Positions(_obj_Smhr_Positions).Rows[0]["Count"]) == "1")
                        {
                            IsCorrect = false;
                            rowno = rowindex + 2;
                            columnno = columnno + "," + "Name *";
                            errormsg = "Position Name Is Already Exists  ";
                        }
                    }
                    if (Convert.ToString(ds.Tables[0].Rows[rowindex][2]) != string.Empty)
                    {
                        for (int count = 0; count < rcmb_PositionsJobs.Items.Count; count++)
                        {
                            if (Convert.ToString(ds.Tables[0].Rows[rowindex][2]) == rcmb_PositionsJobs.Items[count].Text)
                            {
                                found = true;
                                jobid = Convert.ToInt32(rcmb_PositionsJobs.Items[count].Value);
                            }
                        }
                        if (!found)
                        {
                            IsCorrect = false;
                            rowno = rowindex + 2;
                            columnno = columnno + "," + "Job";
                            if (errormsg != string.Empty)
                                errormsg = errormsg + "," + "Job Which You Have Entered Is Not Exists   ";
                            else
                                errormsg = "Job Which You Have Entered Is Not Exists   ";
                        }
                    }
                    if (Convert.ToString(ds.Tables[0].Rows[rowindex][3]) == string.Empty)
                    {
                        IsCorrect = false;
                        rowno = rowindex + 2;
                        columnno = columnno + "," + "Status *";
                        if (errormsg != string.Empty)
                            errormsg = errormsg + "," + "Job Status Should Be Active Or In Active   ";
                        else
                            errormsg = "Job Status Should Be Active Or In Active  ";

                    }
                    else
                    {
                        if (!((Convert.ToString(ds.Tables[0].Rows[rowindex][3]).ToUpper() == "ACTIVE") || (Convert.ToString(ds.Tables[0].Rows[rowindex][3]).ToUpper() == "INACTIVE")))
                        {
                            IsCorrect = false;
                            rowno = rowindex + 2;
                            columnno = columnno + "," + "Status *";
                            if (errormsg != string.Empty)
                                errormsg = errormsg + "," + "Job Status Should Be Active Or In Active   ";
                            else
                                errormsg = "Job Status Should Be Active Or In Active  ";
                        }
                    }
                    if ((Convert.ToString(ds.Tables[0].Rows[rowindex][4]) != string.Empty))
                    {
                        if (!(BLL.CheckDateFormat(Convert.ToString(ds.Tables[0].Rows[rowindex][4].ToString()))))
                        {
                            IsCorrect = false;
                            rowno = rowindex + 2;
                            columnno = columnno + "," + "Start Date *(DD/MM/YYYY)";
                            errormsg = errormsg + "," + "Enter Start Date In The Correct Format  ";
                        }
                    }
                    else
                    {
                        IsCorrect = false;
                        rowno = rowindex + 2;
                        columnno = columnno + "," + "Start Date *(DD/MM/YYYY)";
                        errormsg = errormsg + "," + "Enter Start Date   ";
                    }
                    if ((Convert.ToString(ds.Tables[0].Rows[rowindex][4]) != string.Empty) && (Convert.ToString(ds.Tables[0].Rows[rowindex][5]) != string.Empty))
                    {

                        bool stdatetime = true;
                        if (!(BLL.CheckDateFormat(Convert.ToString(ds.Tables[0].Rows[rowindex]["Start Date *(DD/MM/YYYY)"]))))
                        {
                            stdatetime = false;
                            IsCorrect = false;
                            rowno = rowindex + 2;
                            columnno = columnno + "," + "Start Date *(DD/MM/YYYY)";
                            errormsg = errormsg + "," + "Enter Correct Date Format For Start Date   ";
                            // break;
                        }

                        if (!(BLL.CheckDateFormat(Convert.ToString(ds.Tables[0].Rows[rowindex]["End Date (DD/MM/YYYY)"]))))
                        {
                            stdatetime = false;
                            IsCorrect = false;
                            rowno = rowindex + 2;
                            columnno = columnno + "," + "End Date (DD/MM/YYYY)";
                            errormsg = errormsg + "," + "Enter Correct Date Format For End Date   ";
                            //break;
                        }
                        if (!stdatetime)
                        {
                            if (!(Convert.ToDateTime(ds.Tables[0].Rows[rowindex][4].ToString()) > (Convert.ToDateTime(ds.Tables[0].Rows[rowindex][5].ToString()))))
                            {
                                IsCorrect = false;
                                rowno = rowindex + 2;
                                columnno = columnno + "," + "End Date (DD/MM/YYYY)";
                                columnno = columnno + "," + "Start Date *(DD/MM/YYYY)";
                                errormsg = errormsg + "," + "Start Date Should Be Greater Than End Date   ";
                            }
                        }
                    }
                    if (!IsCorrect)
                    {
                        DataRow newrow = dtfail.NewRow();
                        newrow["S.NO"] = dtfail.Rows.Count + 1;
                        newrow["ROWNO"] = rowno;
                        newrow["COLUMNS NAME"] = columnno;
                        dtfail.Rows.Add(newrow);
                        ds.Tables[0].Rows[rowindex]["Error Message"] = errormsg;
                    }
                    // For checking The Duplicate Row in Excel
                    for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                    {
                        if (ds.Tables[0].Rows[rowindex]["Name *"].ToString().Trim() == ds.Tables[0].Rows[k]["Name *"].ToString().Trim())
                        {
                            if (rowindex != k)
                            {
                                errormsg = errormsg + "," + " Position Name is repeated in Excel Sheet";
                                IsCorrect = false;
                                rowno = rowindex + 2;
                                columnno = "Name *";
                            }
                        }
                    }
                }
                if (dtfail.Rows.Count > 0)
                {
                    Session["dt_fail"] = dtfail;
                    Session["ds_data"] = ds;
                    Delete_Excel_File();
                    Telerik.Web.UI.RadWindow newwindow = new Telerik.Web.UI.RadWindow();
                    newwindow.ID = "RadWindow_import";
                    newwindow.NavigateUrl = "~/Masters/Importresult.aspx";
                    newwindow.Title = "Import Job Process";
                    newwindow.Width = 1150;
                    newwindow.Height = 580;
                    newwindow.VisibleOnPageLoad = true;
                    if (RWM_POSITIONPOSTREPLY.Windows.Count > 1)
                    {
                        RWM_POSITIONPOSTREPLY.Windows.RemoveAt(1);
                    }
                    RWM_POSITIONPOSTREPLY.Windows.Add(newwindow);
                    RWM_POSITIONPOSTREPLY.Visible = true;
                    return;
                }
                else
                {

                    // For Dumping Each Record In To The Database
                    for (int xlrows = 0; xlrows < ds.Tables[0].Rows.Count; xlrows++)
                    {
                        _obj_Smhr_Positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Smhr_Positions.POSITIONS_CODE = Convert.ToString(ds.Tables[0].Rows[xlrows][0]);
                        _obj_Smhr_Positions.POSITIONS_DESC = Convert.ToString(ds.Tables[0].Rows[xlrows][1]);
                        if (Convert.ToString(ds.Tables[0].Rows[xlrows][2]) != string.Empty)
                        {
                            for (int count = 0; count < rcmb_PositionsJobs.Items.Count; count++)
                            {
                                if (Convert.ToString(ds.Tables[0].Rows[xlrows][2]) == rcmb_PositionsJobs.Items[count].Text)
                                {
                                    _obj_Smhr_Positions.POSITIONS_ID = Convert.ToInt32(rcmb_PositionsJobs.Items[count].Value);
                                    break;
                                }
                            }
                        }

                        if (Convert.ToString(ds.Tables[0].Rows[xlrows][2]) != string.Empty)
                        {
                            _obj_Smhr_Positions.POSITIONS_JOBSID = jobid;
                        }
                        if (Convert.ToString(ds.Tables[0].Rows[xlrows][3]) != string.Empty)
                        {
                            if (Convert.ToString(ds.Tables[0].Rows[xlrows][3]).ToUpper() == "ACTIVE")
                                _obj_Smhr_Positions.POSITIONS_STATUS = 0;
                            else
                                _obj_Smhr_Positions.POSITIONS_STATUS = 1;

                        }
                        string sdate = "";
                        string edate = "";
                        sdate = ds.Tables[0].Rows[xlrows][4].ToString();
                        edate = ds.Tables[0].Rows[xlrows][5].ToString();
                        bool wrongsdformat = sdate.Contains(".");
                        bool wrongedformat = edate.Contains(".");
                        if (wrongsdformat)
                            sdate = sdate.Replace(".", "/");
                        if (wrongedformat)
                            edate = edate.Replace(".", "/");

                        _obj_Smhr_Positions.SDATE = sdate;
                        _obj_Smhr_Positions.EDATE = edate;

                        _obj_Smhr_Positions.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_Smhr_Positions.CREATEDDATE = DateTime.Now;

                        _obj_Smhr_Positions.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_Smhr_Positions.LASTMDFDATE = DateTime.Now;
                        _obj_Smhr_Positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

                        _obj_Smhr_Positions.OPERATION = operation.Check;
                        _obj_Smhr_Positions.POSITIONS_CODE = Convert.ToString(ds.Tables[0].Rows[xlrows][0]);
                        _obj_Smhr_Positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        if (Convert.ToString(BLL.get_Positions(_obj_Smhr_Positions).Rows[0]["Count"]) == "1")
                        {
                            continue;
                            //IsCorrect = true;
                        }
                        else
                        {
                            _obj_Smhr_Positions.OPERATION = operation.Insert1;
                            if (BLL.set_Positions(_obj_Smhr_Positions))
                                IsCorrect = true;
                        }

                    }
                    Rm_PO_page.SelectedIndex = 0;
                    LoadGrid();
                    Rm_PO_page.DataBind();
                    if (IsCorrect)
                        BLL.ShowMessage(this, "Information Uploaded SuccessFully");
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmposition.aspx", ex.StackTrace, DateTime.Now);
            Response.Redirect("Frm_ErrorPage.aspx");
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
                strpath = strpath + filedatetime;
                FileInfo fi = new FileInfo(strpath);
                {
                    fi.Delete();
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmposition.aspx", ex.StackTrace, DateTime.Now);
            Response.Redirect("Frm_ErrorPage.aspx");
        }
    }
    #endregion
}