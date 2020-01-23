using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SMHR;
using System.Text;
using Telerik.Web.UI;
using System.IO;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.OleDb;

public partial class Masters_frm_Jobs : System.Web.UI.Page
{
    #region References
    DataSet ds = new DataSet();
    //SqlDataAdapter da;
    string filedatetime = "";
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
            if (RWM_JOBPOSTREPLY.Windows.Count > 0)
            {
                RWM_JOBPOSTREPLY.Windows.RemoveAt(0);
            }
            if (!Page.IsPostBack)
            {


                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("JOB");
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
                    Rg_Jobs.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
                BLL.ChangeDateFormat(Convert.ToString(Session["EMP_ID"]), rdtp_JobStartDate, rdtp_JobsEndDate);

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Jobs", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            Rcm_status.Enabled = true;
            loadDropdown();
            clearControls();
            loadstatus();
            DataTable dt = BLL.get_Jobs(new SMHR_JOBS(Convert.ToInt32(Convert.ToString(e.CommandArgument))));
            Session.Remove("JOB_ID");
            Session["JOB_ID"] = Convert.ToInt32(Convert.ToString(e.CommandArgument));

            lbl_JobsID.Text = Convert.ToString(dt.Rows[0]["JOBS_ID"]);
            rtxt_JobsCode.Text = Convert.ToString(dt.Rows[0]["JOBS_CODE"]);
            rtxt_JobsDesc.Text = Convert.ToString(dt.Rows[0]["JOBS_DESC"] == DBNull.Value ? "" : dt.Rows[0]["JOBS_DESC"]);
            Rcm_status.SelectedIndex = Rcm_status.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["JOBS_STATUS"]));
            //rntxt_JobsMaxSalary.Text = Convert.ToString(dt.Rows[0]["JOBS_MAXSAL"] == DBNull.Value ? "" : dt.Rows[0]["JOBS_MAXSAL"]);
            //rntxt_JobsMinSalary.Text = Convert.ToString(dt.Rows[0]["JOBS_MINSAL"] == DBNull.Value ? "" : dt.Rows[0]["JOBS_MINSAL"]);
            //rcmb_JobsSkills.Text = Convert.ToString(dt.Rows[0]["JOBS_SKILLS"]);
            //Label1.Text = Convert.ToString(dt.Rows[0]["JOBS_SKILLS_ID"]);
            //getCheckedItems(RadListBox1, Label1);
            //rcmb_JobsLocations.Text = Convert.ToString(dt.Rows[0]["JOBS_LOCATIONS"] == DBNull.Value ? "" : dt.Rows[0]["JOBS_LOCATIONS"]);
            Label2.Text = Convert.ToString(dt.Rows[0]["JOBS_LOCATIONS_ID"] == DBNull.Value ? "" : dt.Rows[0]["JOBS_LOCATIONS_ID"]);
            getCheckedItems(RadListBox2, Label2);
            rdtp_JobStartDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["JOBS_STARTDATE"]);
            if (dt.Rows[0]["JOBS_ENDDATE"] != DBNull.Value)
                rdtp_JobsEndDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["JOBS_ENDDATE"]);
            //code for security
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Edit.Visible = false;

            }

            else
            {
                btn_Edit.Visible = true;
            }

            Rm_JB_page.SelectedIndex = 1;
            rtxt_JobsCode.Enabled = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Jobs", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void loadDropdown()
    {
        try
        {
            //SMHR_MASTERS _obj_Smhr_Master = new SMHR_MASTERS();
            //_obj_Smhr_Master.MASTER_TYPE = "GRADE";
            //_obj_Smhr_Master.OPERATION = operation.Select;
            //_obj_Smhr_Master.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //rcmb_JobsGrade.Items.Clear();
            //rcmb_JobsGrade.DataSource = BLL.get_MasterRecords(_obj_Smhr_Master);
            //rcmb_JobsGrade.DataTextField = "HR_MASTER_CODE";
            //rcmb_JobsGrade.DataValueField = "HR_MASTER_ID";
            //rcmb_JobsGrade.DataBind();
            //rcmb_JobsGrade.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            //_obj_Smhr_Master = new SMHR_MASTERS();
            //_obj_Smhr_Master.MASTER_TYPE = "SKILL";
            //_obj_Smhr_Master.OPERATION = operation.Select;
            //_obj_Smhr_Master.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //RadListBox1.Items.Clear();
            //RadListBox1.DataSource = BLL.get_MasterRecords(_obj_Smhr_Master);
            //RadListBox1.DataTextField = "HR_MASTER_CODE";
            //RadListBox1.DataValueField = "HR_MASTER_ID";
            //RadListBox1.DataBind();


            SMHR_LOGININFO _obj_LoginInfo = new SMHR_LOGININFO();
            _obj_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            RadListBox2.Items.Clear();
            RadListBox2.DataSource = BLL.get_Business_Units(_obj_LoginInfo);
            RadListBox2.DataTextField = "BUSINESSUNIT_CODE";
            RadListBox2.DataValueField = "BUSINESSUNIT_ID";
            RadListBox2.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Jobs", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            loadstatus();
            loadDropdown();
            clearControls();
            btn_Save.Visible = true;
            Rm_JB_page.SelectedIndex = 1;
            Page.Validate();
            Rcm_status.SelectedIndex = Rcm_status.Items.FindItemIndexByText(Convert.ToString("Active"));
            Rcm_status.Enabled = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Jobs", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void LoadGrid()
    {
        try
        {
            SMHR_JOBS _obj_Jobs = new SMHR_JOBS();
            _obj_Jobs.OPERATION = operation.Select;
            _obj_Jobs.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT = BLL.get_Jobs(_obj_Jobs);
            Rg_Jobs.DataSource = DT;
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Jobs", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void statuschanged_click(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (Convert.ToString(Rcm_status.SelectedItem.Text).ToUpper().Trim() == "INACTIVE")
            {
                SMHR_JOBS _OBJ_SMHR_JOBS = new SMHR_JOBS();

                _OBJ_SMHR_JOBS.OPERATION = operation.Edit;
                _OBJ_SMHR_JOBS.JOBS_ID = Convert.ToInt32(Session["JOB_ID"]);
                _OBJ_SMHR_JOBS.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable DTDETAILS = BLL.get_Jobs(_OBJ_SMHR_JOBS);
                if (DTDETAILS.Rows.Count > 0)
                {

                    BLL.ShowMessage(this, "You cannot Inactive Job, As it is already assigned ");
                    Rcm_status.SelectedIndex = 0;
                }
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Jobs", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    public void loadstatus()
    {
        try
        {
            Rcm_status.Items.Clear();
            SMHR_MASTERS _obj_smhr_masters = new SMHR_MASTERS();
            _obj_smhr_masters.MASTER_TYPE = "STATUS";
            _obj_smhr_masters.OPERATION = operation.Select;
            _obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Details = BLL.get_MasterRecords(_obj_smhr_masters);//as it is c data done nothing
            Rcm_status.DataSource = dt_Details;
            Rcm_status.DataTextField = "HR_MASTER_CODE";
            Rcm_status.DataValueField = "HR_MASTER_ID";
            Rcm_status.DataBind();
            Rcm_status.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Jobs", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            StringBuilder sb = new StringBuilder();
            //bool status = false;
            IList<RadListBoxItem> collection = RadListBox2.CheckedItems;
            if (collection.Count != 0)
            {
                SMHR_JOBS _obj_Smhr_jobs = new SMHR_JOBS();
                _obj_Smhr_jobs.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                // comparing job start date and enddate with selected business unit start date and enddate
                for (int checkeditems = 0; checkeditems < RadListBox2.Items.Count; checkeditems++)
                {
                    if (RadListBox2.Items[checkeditems].Checked == true)
                    {
                        _obj_Smhr_jobs.BUID = Convert.ToInt32(RadListBox2.Items[checkeditems].Value);
                        _obj_Smhr_jobs.STARTDATE = rdtp_JobStartDate.SelectedDate;
                        _obj_Smhr_jobs.ENDDATE = rdtp_JobsEndDate.SelectedDate;
                        _obj_Smhr_jobs.OPERATION = operation.Validate;
                        DataTable Dt_Bu = BLL.get_Jobs(_obj_Smhr_jobs);
                        if (Dt_Bu.Rows[0][0].ToString().ToUpper() == "TRUE")
                        {
                            BLL.ShowMessage(this, "The Job Startdate is not Matching with Businessunit " + RadListBox2.Items[checkeditems].Text + " Startdate");
                            return;
                        }
                    }
                }


                _obj_Smhr_jobs.JOBS_CODE = BLL.ReplaceQuote(rtxt_JobsCode.Text);
                _obj_Smhr_jobs.JOBS_DESC = BLL.ReplaceQuote(rtxt_JobsDesc.Text);

                //if (rcmb_JobsGrade.SelectedItem.Value.ToString() != "0")
                //    _obj_Smhr_jobs.JOBS_GRADE_ID = Convert.ToInt32(rcmb_JobsGrade.SelectedItem.Value);

                //if (rntxt_JobsMaxSalary.Text != "")
                //    _obj_Smhr_jobs.JOBS_MAXSAL = Convert.ToDecimal(rntxt_JobsMaxSalary.Text);

                //if (rntxt_JobsMinSalary.Text != "")
                //    _obj_Smhr_jobs.JOBS_MINSAL = Convert.ToDecimal(rntxt_JobsMinSalary.Text);
                //ShowCheckedItems(RadListBox1, Label1);
                //_obj_Smhr_jobs.JOBS_SKILLS = Convert.ToString(Label1.Text);
                ShowCheckedItems(RadListBox2, Label2);
                _obj_Smhr_jobs.JOBS_LOCATIONS = Convert.ToString(Label2.Text);

                _obj_Smhr_jobs.STARTDATE = rdtp_JobStartDate.SelectedDate;
                _obj_Smhr_jobs.ENDDATE = rdtp_JobsEndDate.SelectedDate;
                _obj_Smhr_jobs.JOBS_STATUS = Convert.ToInt32(Rcm_status.SelectedItem.Value);

                _obj_Smhr_jobs.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                _obj_Smhr_jobs.CREATEDDATE = DateTime.Now;

                _obj_Smhr_jobs.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                _obj_Smhr_jobs.LASTMDFDATE = DateTime.Now;
                _obj_Smhr_jobs.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                switch (((Button)sender).ID.ToUpper())
                {
                    case "BTN_EDIT":
                        _obj_Smhr_jobs.JOBS_ID = Convert.ToInt32(lbl_JobsID.Text);
                        _obj_Smhr_jobs.OPERATION = operation.Check;
                        if (Convert.ToString(BLL.get_Jobs(_obj_Smhr_jobs).Rows[0]["Count"]) != "1")
                        {
                            BLL.ShowMessage(this, "Job with this Name Already Exists");
                            return;
                        }
                        _obj_Smhr_jobs.OPERATION = operation.Update;
                        if (BLL.set_Jobs(_obj_Smhr_jobs))
                            BLL.ShowMessage(this, "Information Updated Successfully");
                        else
                            BLL.ShowMessage(this, "Information Not Saved");

                        break;
                    case "BTN_SAVE":
                        _obj_Smhr_jobs.OPERATION = operation.Check;
                        if (Convert.ToString(BLL.get_Jobs(_obj_Smhr_jobs).Rows[0]["Count"]) != "0")
                        {
                            BLL.ShowMessage(this, "Job with this Name Already Exists");
                            return;
                        }
                        _obj_Smhr_jobs.OPERATION = operation.Insert;
                        if (BLL.set_Jobs(_obj_Smhr_jobs))
                            BLL.ShowMessage(this, "Information Saved Successfully");
                        else
                            BLL.ShowMessage(this, "Information Not Saved");
                        break;
                    default:
                        break;
                }
                Rm_JB_page.SelectedIndex = 0;
                LoadGrid();
                Rg_Jobs.DataBind();

            }

            else
            {
                BLL.ShowMessage(this, "Please Select Business Unit");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Jobs", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void clearControls()
    {
        try
        {
            lbl_JobsID.Text = string.Empty;
            rtxt_JobsCode.Text = string.Empty;
            rtxt_JobsDesc.Text = string.Empty;
            //rcmb_JobsGrade.SelectedIndex = -1;
            //rntxt_JobsMaxSalary.Text = string.Empty;
            //rntxt_JobsMinSalary.Text = string.Empty;
            //rcmb_JobsSkills.Text = string.Empty;
            //rcmb_JobsLocations.Text = string.Empty;
            rdtp_JobStartDate.SelectedDate = null;
            rdtp_JobsEndDate.SelectedDate = null;
            btn_Save.Visible = false;
            btn_Edit.Visible = false;
            Rm_JB_page.SelectedIndex = 0;
            rtxt_JobsCode.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Jobs", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Jobs", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Rg_Jobs_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Jobs", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private static void ShowCheckedItems(RadListBox listBox, Label label)
    {
        try
        {
            StringBuilder sb = new StringBuilder();
            IList<RadListBoxItem> collection = listBox.CheckedItems;

            foreach (RadListBoxItem item in collection)
            {
                if (sb.Length == 0)
                {
                    sb.Append(item.Value);
                }
                else
                {
                    sb.Append("," + item.Value);
                }
            }

            label.Text = sb.ToString();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(HttpContext.Current.Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Jobs", ex.StackTrace, DateTime.Now);
            HttpContext.Current.Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void getCheckedItems(RadListBox listBox, Label label)
    {
        try
        {
            string strVal = label.Text;
            string[] Ar = strVal.Split(new Char[] { ',' });
            for (int i = 0; i < Ar.Length; i++)
            {
                string strTemp = Ar[i].Trim();

                if (listBox.FindItemByValue(strTemp) != null)
                    listBox.FindItemByValue(strTemp).Checked = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Jobs", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    #region Import Job
    /// <summary>
    /// For Importing Multiple Jobs At A Time Through Excel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void btn_Import_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        string strcon = null;
    //        string errormsg = "";
    //        string filename = fupld_Job.FileName;
    //        filedatetime = Convert.ToString(DateTime.Now.TimeOfDay) + "_" + filename;
    //        filedatetime = filedatetime.Replace("/", "").Replace(":", ".");
    //        if (fupld_Job.HasFile)
    //        {
    //            if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == false)
    //            {
    //                System.IO.Directory.CreateDirectory(Server.MapPath("~/IMPORT_EXCEL/"));
    //            }
    //            fupld_Job.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/IMPORT_EXCEL/"), filedatetime));
    //            string filename1 = Server.MapPath("~/IMPORT_EXCEL/") + ("") + (Convert.ToString(filedatetime));
    //            FileInfo fileInfo = new FileInfo(filename1);
    //            if (fileInfo.Exists)
    //            {
    //                string path = MapPath(filename);
    //                string ext = Path.GetExtension(path);
    //                string type = string.Empty;

    //                //  set known types based on file extension  
    //                if (ext != null)
    //                {
    //                    switch (ext.ToLower())
    //                    {
    //                        case ".xls": type = "excel";
    //                            break;
    //                        case ".xlsx": type = "excel";
    //                            break;
    //                        default: type = string.Empty;
    //                            break;
    //                    }
    //                }
    //                if (type == string.Empty)
    //                {
    //                    if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == true)
    //                    {
    //                        string path1 = Server.MapPath("~/IMPORT_EXCEL/") + ("") + (Convert.ToString(filedatetime));
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
    //        strpath = strpath + filedatetime;


    //        // Getting data from excell file to dataset.
    //        strcon = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source='" + strpath + "';" + "Extended Properties=Excel 12.0;";
    //        OleDbConnection objConn = null;
    //        objConn = new OleDbConnection(strcon);
    //        objConn.Open();

    //        DataTable dt_check = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
    //        string sheetname;
    //        if (dt_check == null)
    //        {
    //            objConn.Close();
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        else
    //        {
    //            sheetname = Convert.ToString(dt_check.Rows[0]["TABLE_NAME"]);
    //        }
    //        OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM  [" + sheetname + "]", strcon);
    //        da.Fill(ds);
    //        ds.Tables[0].Columns.Add("Error Message");
    //        objConn.Close();
    //        DataTable dt = new DataTable();
    //        DataTable dtfail = new DataTable();
    //        string projecttype = null;
    //        Int32 rowno = 0;
    //        string columnno = null;
    //        //Boolean filestatus = true;
    //        dtfail.Columns.Add("S.NO", typeof(Int32));
    //        dtfail.Columns.Add("ROWNO", typeof(Int32));
    //        dtfail.Columns.Add("COLUMNS NAME", typeof(string));
    //        //For Checking The Job Name Field Is There or not in the excel sheet
    //        if (!(ds.Tables[0].Columns[0].ToString().Trim() == "Name*"))
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        //For Checking The Job Description Field Is There or not in the excel sheet
    //        if (!(ds.Tables[0].Columns[1].ToString().Trim() == "Description"))
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        //For Checking The Availability of Grade Field
    //        if (!(ds.Tables[0].Columns[2].ToString() == "Grade"))
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        //For Checking The Availability of Minimum Salary
    //        if (!(ds.Tables[0].Columns[3].ToString() == "Min Salary *"))
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        //For Checking The Availability of Max Salary
    //        if (!(ds.Tables[0].Columns[4].ToString() == "Max Salary *"))
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }

    //        //For Checking The Availability of Skills
    //        if (!(ds.Tables[0].Columns[5].ToString() == "Skills"))
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        //For Checking The Availability of Businessunit 
    //        if (!(ds.Tables[0].Columns[6].ToString() == "Businessunit *"))
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        //For Checking The Availability of Start Date 
    //        if (!(ds.Tables[0].Columns[7].ToString() == "Start Date *(DD/MM/YYYY)"))
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;

    //        }
    //        //For Checking The Availability of End Date 
    //        if (!(ds.Tables[0].Columns[8].ToString() == "End Date *(DD/MM/YYYY)"))
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }

    //        //For Checking The Availability of the Records In The Excel Sheet
    //        if (ds.Tables[0].Rows.Count == 0)
    //        {
    //            BLL.ShowMessage(this, "Imported Successfully But There is No Record Available!");
    //            Delete_Excel_File();
    //            return;
    //        }
    //        else
    //        {
    //            bool IsCorrect = true;
    //            bool found = false;
    //            SMHR_JOBS _obj_Jobs = new SMHR_JOBS();
    //            //For Validating The Excel Sheet
    //            for (int rowindex = 0; rowindex < ds.Tables[0].Rows.Count; rowindex++)
    //            {
    //                loadDropdown();
    //                if (Convert.ToString(ds.Tables[0].Rows[rowindex][0]) != string.Empty)
    //                {
    //                    _obj_Jobs.OPERATION = operation.Check;
    //                    _obj_Jobs.JOBS_CODE = Convert.ToString(ds.Tables[0].Rows[rowindex][0]);
    //                    _obj_Jobs.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                    if (Convert.ToString(BLL.get_Jobs(_obj_Jobs).Rows[0]["Count"]) == "1")
    //                    {
    //                        IsCorrect = false;
    //                        rowno = rowindex + 2;
    //                        columnno = columnno + "," + "Name*";
    //                        errormsg = "Job Name Is Already Exists  ";
    //                    }
    //                }
    //                //if (Convert.ToString(ds.Tables[0].Rows[rowindex][2]) != string.Empty)
    //                //{
    //                //    for (int count = 0; count < rcmb_JobsGrade.Items.Count; count++)
    //                //    {
    //                //        if (Convert.ToString(ds.Tables[0].Rows[rowindex][2]) == rcmb_JobsGrade.Items[count].Text)
    //                //        {
    //                //            found = true;
    //                //            break;
    //                //        }
    //                //    }
    //                //    if (!found)
    //                //    {
    //                //        IsCorrect = false;
    //                //        rowno = rowindex + 2;
    //                //        columnno = columnno + "," + "Grade";
    //                //        errormsg = errormsg + "," + "Grade Which You Have Entered Is Not Exists   ";
    //                //    }
    //                //}
    //                //if (!(Convert.ToString(ds.Tables[0].Rows[rowindex][3]) != string.Empty))
    //                //{
    //                //    IsCorrect = false;
    //                //    rowno = rowindex + 2;
    //                //    columnno = columnno + "," + "Min Salary *";
    //                //    errormsg = errormsg + "," + "Min Salary Can't Be Blank   ";
    //                //}
    //                //if (!(Convert.ToString(ds.Tables[0].Rows[rowindex][4]) != string.Empty))
    //                //{
    //                //    IsCorrect = false;
    //                //    rowno = rowindex + 2;
    //                //    columnno = columnno + "," + "Max Salary *";
    //                //    errormsg = errormsg + "," + "Max Salary Can't Be Blank   ";
    //                //}
    //                //if (((ds.Tables[0].Rows[rowindex][4].ToString()) != string.Empty) && (ds.Tables[0].Rows[rowindex][3].ToString() != string.Empty))
    //                //{
    //                //    if (!(Convert.ToInt64(ds.Tables[0].Rows[rowindex][4].ToString()) > (Convert.ToInt32(ds.Tables[0].Rows[rowindex][3].ToString()))))
    //                //    {
    //                //        IsCorrect = false;
    //                //        rowno = rowindex + 2;
    //                //        columnno = columnno + "," + "Max Salary *";
    //                //        columnno = columnno + "," + "Min Salary *";
    //                //        errormsg = errormsg + "," + "Max Salary Should Be Greater Than Min Salary   ";
    //                //    }
    //                //}
    //                //if (Convert.ToString(ds.Tables[0].Rows[rowindex][5]) != string.Empty)
    //                //{
    //                //    string skills = "";
    //                //    found = false;
    //                //    skills = Convert.ToString(ds.Tables[0].Rows[rowindex][5]);
    //                //    int x = 0;
    //                //    Array Ar = skills.Split(new Char[] { ',' });                        
    //                //    for (int i = 0; i < Ar.Length; i++)
    //                //    {
    //                //        for (int j = 0; j < RadListBox1.Items.Count; j++)
    //                //        {
    //                //            if (RadListBox1.Items[j].Text == Convert.ToString(Ar.GetValue(i)))
    //                //            {
    //                //                found = true;
    //                //            }
    //                //        }
    //                //    }
    //                //    if (found==false)
    //                //    {
    //                //        IsCorrect = false;
    //                //        rowno = rowindex + 2;
    //                //        columnno = columnno + "," + "Skills";
    //                //        errormsg = errormsg + "," + "Entered Skills Are Not Exists   ";

    //                //    }
    //                //}
    //                if (Convert.ToString(ds.Tables[0].Rows[rowindex][6]) != string.Empty)
    //                {
    //                    string Businessunit = "";
    //                    Businessunit = Convert.ToString(ds.Tables[0].Rows[rowindex][6]);
    //                    found = false;
    //                    Array Ar = Businessunit.Split(new Char[] { ',' });
    //                    for (int i = 0; i < Ar.Length; i++)
    //                    {
    //                        if (RadListBox2.Items[i].Text == Convert.ToString(Ar.GetValue(i)))
    //                        {
    //                            found = true;
    //                        }
    //                    }
    //                    if (!found)
    //                    {
    //                        IsCorrect = false;
    //                        rowno = rowindex + 2;
    //                        columnno = columnno + "," + "Businessunit *";
    //                        errormsg = errormsg + "," + "Entered BusinessUnit Is Not Available   ";
    //                    }
    //                }
    //                if (!(Convert.ToString(ds.Tables[0].Rows[rowindex][7]) != string.Empty))
    //                {
    //                    IsCorrect = false;
    //                    rowno = rowindex + 2;
    //                    columnno = columnno + "," + "Start Date *(DD/MM/YYYY)";
    //                    errormsg = errormsg + "," + "Enter Start Date   ";
    //                }
    //                if (!(Convert.ToString(ds.Tables[0].Rows[rowindex][8]) != string.Empty))
    //                {
    //                    IsCorrect = false;
    //                    rowno = rowindex + 2;
    //                    columnno = columnno + "," + "End Date *(DD/MM/YYYY)";
    //                    errormsg = errormsg + "," + "Enter End Date   ";
    //                }
    //                if ((Convert.ToString(ds.Tables[0].Rows[rowindex][7]) != string.Empty) && (Convert.ToString(ds.Tables[0].Rows[rowindex][8]) != string.Empty))
    //                {

    //                    bool stdatetime = true;
    //                    if (!(BLL.CheckDateFormat(Convert.ToString(ds.Tables[0].Rows[rowindex]["Start Date *(DD/MM/YYYY)"]))))
    //                    {
    //                        stdatetime = false;
    //                        IsCorrect = false;
    //                        rowno = rowindex + 2;
    //                        columnno = columnno + "," + "Start Date *(DD/MM/YYYY)";
    //                        errormsg = errormsg + "," + "Enter Correct Date Format For Start Date   ";
    //                        // break;
    //                    }
    //                    if (!(BLL.CheckDateFormat(Convert.ToString(ds.Tables[0].Rows[rowindex]["End Date *(DD/MM/YYYY)"]))))
    //                    {
    //                        stdatetime = false;
    //                        IsCorrect = false;
    //                        rowno = rowindex + 2;
    //                        columnno = columnno + "," + "End Date *(DD/MM/YYYY)";
    //                        errormsg = errormsg + "," + "Enter Correct Date Format For End Date   ";
    //                        //break;
    //                    }

    //                    //string sdate = "";
    //                    //string edate = "";
    //                    //sdate = ds.Tables[0].Rows[rowindex][7].ToString();
    //                    //edate = ds.Tables[0].Rows[rowindex][8].ToString();
    //                    //bool wrongsdformat = sdate.Contains(".");
    //                    //bool wrongedformat = edate.Contains(".");
    //                    //if (wrongsdformat)
    //                    //    sdate = sdate.Replace(".", "/");
    //                    //if (wrongedformat)
    //                    //    edate = edate.Replace(".", "/");
    //                    System.Globalization.DateTimeFormatInfo dateInfo1 = new System.Globalization.DateTimeFormatInfo();
    //                    dateInfo1.ShortDatePattern = "dd/MM/yyyy"; 
    //                    if (!(Convert.ToDateTime(ds.Tables[0].Rows[rowindex][8].ToString(),dateInfo1) > Convert.ToDateTime(ds.Tables[0].Rows[rowindex][7].ToString(),dateInfo1)))
    //                        {
    //                            IsCorrect = false;
    //                            rowno = rowindex + 2;
    //                            columnno = columnno + "," + "End Date *(DD/MM/YYYY)";
    //                            columnno = columnno + "," + "Start Date *(DD/MM/YYYY)";
    //                            errormsg = errormsg + "," + "End Date Should Be Greater Than Start Date   ";
    //                        }                        
    //                }
    //                if (!IsCorrect)
    //                {
    //                    DataRow newrow = dtfail.NewRow();
    //                    newrow["S.NO"] = dtfail.Rows.Count + 1;
    //                    newrow["ROWNO"] = rowno;
    //                    newrow["COLUMNS NAME"] = columnno;
    //                    dtfail.Rows.Add(newrow);
    //                    ds.Tables[0].Rows[rowindex]["Error Message"] = errormsg;
    //                }
    //                // For checking The Duplicate Row in Excel
    //                for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
    //                {
    //                    if (ds.Tables[0].Rows[rowindex]["Name*"].ToString().Trim() == ds.Tables[0].Rows[k]["Name*"].ToString().Trim())
    //                    {
    //                        if (rowindex != k)
    //                        {
    //                            errormsg = errormsg + "," + " Job Name is repeated in Excel Sheet";
    //                            IsCorrect = false;
    //                            rowno = rowindex + 2;
    //                            columnno = "Name*";
    //                        }
    //                    }
    //                }
    //            }
    //            if (dtfail.Rows.Count > 0)
    //            {
    //                Session["dt_fail"] = dtfail;
    //                Session["ds_data"] = ds;
    //                Delete_Excel_File();
    //                Telerik.Web.UI.RadWindow newwindow = new Telerik.Web.UI.RadWindow();
    //                newwindow.ID = "RadWindow_import";
    //                newwindow.NavigateUrl = "~/Masters/Importresult.aspx";
    //                newwindow.Title = "Import Job Process";
    //                newwindow.Width = 1150;
    //                newwindow.Height = 580;
    //                newwindow.VisibleOnPageLoad = true;
    //                if (RWM_JOBPOSTREPLY.Windows.Count > 1)
    //                {
    //                    RWM_JOBPOSTREPLY.Windows.RemoveAt(1);
    //                }
    //                RWM_JOBPOSTREPLY.Windows.Add(newwindow);
    //                RWM_JOBPOSTREPLY.Visible = true;
    //                return;
    //            }
    //            else
    //            {

    //                // For Dumping Each Record In To The Database
    //                for (int xlrows = 0; xlrows < ds.Tables[0].Rows.Count; xlrows++)
    //                {
    //                    _obj_Jobs.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                    _obj_Jobs.JOBS_CODE = Convert.ToString(ds.Tables[0].Rows[xlrows][0]);
    //                    _obj_Jobs.JOBS_DESC = Convert.ToString(ds.Tables[0].Rows[xlrows][1]);
    //                    //if (Convert.ToString(ds.Tables[0].Rows[xlrows][2]) != string.Empty)
    //                    //{
    //                    //    for (int count = 0; count < rcmb_JobsGrade.Items.Count; count++)
    //                    //    {
    //                    //        if (Convert.ToString(ds.Tables[0].Rows[xlrows][2]) == rcmb_JobsGrade.Items[count].Text)
    //                    //        {
    //                    //            _obj_Jobs.JOBS_GRADE_ID = Convert.ToInt32(rcmb_JobsGrade.Items[count].Value);
    //                    //            break;
    //                    //        }
    //                    //    }
    //                    //}
    //                    if ((Convert.ToString(ds.Tables[0].Rows[xlrows][3]) != string.Empty) && (Convert.ToString(ds.Tables[0].Rows[xlrows][4]) != string.Empty))
    //                    {
    //                        _obj_Jobs.JOBS_MINSAL = Convert.ToInt32(Math.Round(Convert.ToDouble((ds.Tables[0].Rows[xlrows][3]))));
    //                        _obj_Jobs.JOBS_MAXSAL = Convert.ToInt32(Math.Round(Convert.ToDouble(ds.Tables[0].Rows[xlrows][4])));
    //                    }
    //                    //if (Convert.ToString(ds.Tables[0].Rows[xlrows][5]) != string.Empty)
    //                    //{
    //                    //    string skills = "";
    //                    //    skills = Convert.ToString(ds.Tables[0].Rows[xlrows][5]);
    //                    //    int x = 0;
    //                    //    Array Ar = skills.Split(new Char[] { ',' });
    //                    //    for (int arindex = 0; arindex < Ar.Length; arindex++)
    //                    //    {
    //                    //        for (int i = 0; i < RadListBox1.Items.Count; i++)
    //                    //        {
    //                    //            if ((RadListBox1.Items[i].Text == Convert.ToString(Ar.GetValue(x))) && (x < Ar.Length))
    //                    //            {
    //                    //                if (x == 0)
    //                    //                {
    //                    //                    _obj_Jobs.JOBS_SKILLS = Convert.ToString(RadListBox1.Items[i].Value);
    //                    //                    x++;
    //                    //                    break;
    //                    //                }
    //                    //                else
    //                    //                {
    //                    //                    _obj_Jobs.JOBS_SKILLS += "," +Convert.ToString(RadListBox1.Items[i].Value);
    //                    //                    x++;
    //                    //                    break;
    //                    //                }
    //                    //            }
    //                    //        }
    //                    //    }
    //                    //}
    //                    if (Convert.ToString(ds.Tables[0].Rows[xlrows][6]) != string.Empty)
    //                    {
    //                        string Businessunit = "";
    //                        Businessunit = Convert.ToString(ds.Tables[0].Rows[xlrows][6]);
    //                        int x = 0;
    //                        Array Ar = Businessunit.Split(new Char[] { ',' });
    //                        for (int i = 0; i < RadListBox2.Items.Count; i++)
    //                        {
    //                            if ((RadListBox2.Items[i].Text == Convert.ToString(Ar.GetValue(x))) && (x < Ar.Length))
    //                            {
    //                                if (x == 0)
    //                                {
    //                                    _obj_Jobs.JOBS_LOCATIONS = Convert.ToString(RadListBox2.Items[i].Value);
    //                                    x++;
    //                                }
    //                                else
    //                                {
    //                                    _obj_Jobs.JOBS_LOCATIONS +=","+Convert.ToString(RadListBox2.Items[i].Value);
    //                                    x++;
    //                                }
    //                            }
    //                        }
    //                    }
    //                    string sdate = "";
    //                    string edate = "";
    //                    sdate = ds.Tables[0].Rows[xlrows][7].ToString();
    //                    edate = ds.Tables[0].Rows[xlrows][8].ToString();
    //                    bool wrongsdformat = sdate.Contains(".");
    //                    bool wrongedformat = edate.Contains(".");
    //                    if (wrongsdformat)
    //                        sdate = sdate.Replace(".", "/");
    //                    if (wrongedformat)
    //                        edate = edate.Replace(".", "/");



    //                    _obj_Jobs.EDATE = edate;
    //                    _obj_Jobs.SDATE = sdate;
    //                    _obj_Jobs.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
    //                    _obj_Jobs.CREATEDDATE = DateTime.Now;

    //                    _obj_Jobs.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
    //                    _obj_Jobs.LASTMDFDATE = DateTime.Now;
    //                    _obj_Jobs.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                    _obj_Jobs.OPERATION = operation.Insert1;
    //                    IsCorrect = Convert.ToBoolean(BLL.set_Jobs(_obj_Jobs));
    //                }
    //                Rm_JB_page.SelectedIndex = 0;
    //                LoadGrid();
    //                Rg_Jobs.DataBind();
    //                if (IsCorrect)
    //                    BLL.ShowMessage(this, "Information Uploaded Successfully");
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Jobs", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }

    //}
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Jobs", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion




}
