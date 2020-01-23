using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using SPMS;
using SMHR;
using Telerik.Web.UI;
using System.IO;
using System.Text;
using System.Drawing;
using System.Data.OleDb;
using Telerik.Web.UI.GridExcelBuilder;
using System.Globalization;
using System.Threading;

public partial class PMS_frm_attendancereport : System.Web.UI.Page
{
    #region References
    DateTime ln_time = new DateTime();
    DateTime DT_att;
    DateTime attendance_startdate = new DateTime();
    DateTime DtInTime = new DateTime();
    string strfilename2;
    DataSet ds = new DataSet();
    bool employeestatus;
    bool employeebusinessunit;
    int employeecorret;
    int emp_ID1;
    bool empcodeempty;
    bool stdatetime;
    SMHR_ATTENDANCE _obj_Smhr_Attendance = new SMHR_ATTENDANCE();
    #endregion

    #region Page Load
    /// <summary>
    /// this region will load the combo boxes that is business unit and financial periods
    /// </summary>    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
            if (!Page.IsPostBack)
            {

                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("ATTENDANCE IMPORT");
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
                    btn_uploadattendance.Enabled = false;
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
                Rg_Attendancedtls.Visible = false;
                //btn_Submit.Visible = false;
                btn_cancel.Visible = false;
                BTN_FINALISE.Visible = false;
                Rg_Attendancedtls.PageSize = 2000;
                RWM_POSTREPLY1.Visible = false;
                rdbList.SelectedIndex = -1;
                rdbList.Visible = false;



            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_attendancereport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            //BLL.ShowMessage(this, ex.Message.ToString());
            //return;
        }
    }
    #endregion

    #region Loading methods
    /// <summary>
    /// Loads business unit and financial period
    /// </summary>
    private void LoadCombos()
    {
        try
        {
            SMHR_BUSINESSUNIT _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
            DataTable dt_Details = new DataTable();

            SMHR_LOGININFO _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            rcmb_BusinessUnitType.DataSource = dt_BUDetails;
            rcmb_BusinessUnitType.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BusinessUnitType.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BusinessUnitType.DataBind();
            rcmb_BusinessUnitType.Items.Insert(0, new RadComboBoxItem("Select"));


            SMHR_PERIOD _obj_smhr_period = new SMHR_PERIOD();
            DataTable dt_Details22 = new DataTable();
            _obj_smhr_period.OPERATION = operation.Select;

            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details22 = BLL.get_PeriodHeaderDetails(_obj_smhr_period);
            rcm_period.DataSource = dt_Details22;
            rcm_period.DataValueField = "PERIOD_ID";
            rcm_period.DataTextField = "PERIOD_NAME";
            rcm_period.DataBind();
            rcm_period.Items.Insert(0, new RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_attendancereport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            //BLL.ShowMessage(this, ex.Message.ToString());
            //return;
        }
    }
    #endregion

    #region Validation Methods
    /// <summary>
    /// validations for the intime, outtime  and etc .
    /// </summary>    
    public static DateTime ParseMilitaryTime(string time, int year, int month, int day)
    {

        //
        // Convert hour part of string to integer.
        //
        string hour = time.Substring(0, 2);
        int hourInt = int.Parse(hour);
        if (hourInt >= 24)
        {
            throw new ArgumentOutOfRangeException("Invalid hour");
        }
        //
        // Convert minute part of string to integer.
        //

        string minute = time.Substring(2, 2);
        int minuteInt = int.Parse(minute);
        if (minuteInt >= 60)
        {
            throw new ArgumentOutOfRangeException("Invalid minute");
        }
        //
        // Return the DateTime.
        //
        return new DateTime(year, month, day, hourInt, minuteInt, 0);

    }


    public static bool CheckStringValue(string str)
    {
        try
        {
            //
            // Convert true if number  or false if not
            //
            int Num;
            if (int.TryParse(str, out Num) == true)
            {
                if (Num > 2359)
                {
                    return false;
                }
                if (str.Length != 4)
                {
                    return false;

                }
                if (str.Length == 4)
                {
                    string minute = str.Substring(2, 2);
                    int minuteInt = int.Parse(minute);
                    if (minuteInt >= 60)
                    {
                        return false;
                    }
                }

            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(HttpContext.Current.Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_attendancereport", ex.StackTrace, DateTime.Now);
            HttpContext.Current.Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return true;
    }
    public static bool CheckDateFormat(string strin)
    {
        try
        {
            if (strin.Length > 10)
            {
                return false;
            }
            char[] c = null;
            string strFinal = string.Empty;
            Array ar = strin.Split(new char[] { '/' });
            string yeararray = Convert.ToString(ar.GetValue(2));
            if (yeararray.Length > 4)
            {
                return false;
            }
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar.GetValue(i).ToString().Length == 1)
                {
                    strFinal = strFinal + "0" + ar.GetValue(i) + "/";
                }
                else if (ar.GetValue(i).ToString().Length == 2)
                {
                    strFinal = strFinal + ar.GetValue(i) + "/";
                }
                else
                {
                    if (strFinal.Length == 6)
                        strFinal = strFinal + ar.GetValue(i).ToString();
                    else
                        strFinal = strFinal + "/" + ar.GetValue(i).ToString();
                }
            }
            c = strFinal.ToCharArray();
            if ((c[2] != '/') || c[5] != '/')
            {
                return false;
            }

            if (Convert.ToInt32(strFinal.Substring(0, 2).Trim()) > 31)
            {
                return false;
            }
            if (Convert.ToInt32(strFinal.Substring(3, 2).Trim()) > 12)
            {
                return false;
            }

            if (Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 2)
            {
                if (Convert.ToInt32(strFinal.Substring(6, 4).Trim()) / 4 == 0)
                { // check leap year

                    if (Convert.ToInt32(strFinal.Substring(0, 2).Trim()) > 29)
                    {
                        return false;
                    }

                }
                else
                {
                    if (Convert.ToInt32(strFinal.Substring(0, 2).Trim()) > 28)
                    {
                        return false;
                    }
                }

            }
            if (Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 1 || Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 3 || Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 5 || Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 7 || Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 8 || Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 10 || Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 12)
            {
                if (Convert.ToInt32(strFinal.Substring(0, 2).Trim()) > 31)
                {
                    return false;
                }
            }
            if (Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 4 || Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 6 || Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 9 || Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 11)
            {
                if (Convert.ToInt32(strFinal.Substring(0, 2).Trim()) > 30)
                {
                    return false;
                }
            }
            return true;
        }
        catch (Exception ex)
        {
           SMHR.BLL.Error_Log(HttpContext.Current.Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_attendancereport", ex.StackTrace, DateTime.Now);
            HttpContext.Current.Response.Redirect("~/Frm_ErrorPage.aspx");
            return false;
        }
    }
    public static void WriteMilitaryTime(DateTime date)
    {
        //
        // Convert hours and minutes to 24-hour scale.
        //
        string value = date.ToString("HHmm");
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_attendancereport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    #region Button Clicks
    /// <summary>
    /// this region will consists of all methods when a button event is fired
    /// </summary>
    protected void btn_upload_onclick(object sender, EventArgs e)
    {
        try
        {
            RWM_POSTREPLY1.Visible = true;
            Session.Remove("dt_fail");
            Session.Remove("ds_data");
            Session.Remove("ds_data2");
            string strcon = null;
            string strfilename1 = fileupload_attendance.FileName;
            strfilename2 = Convert.ToString(DateTime.Now.TimeOfDay) + "_" + strfilename1;
            strfilename2 = strfilename2.Replace("/", "").Replace(":", ".");
            if (fileupload_attendance.HasFile) //fetch the data from view state and pass in to temp query
            {

                if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == false)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath("~/IMPORT_EXCEL/"));

                }



                fileupload_attendance.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/IMPORT_EXCEL/"), strfilename2));
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

                string strpath = Server.MapPath("~/IMPORT_EXCEL/");
                strpath = strpath + strfilename2;

                // Getting data from excell file to dataset.
                strcon = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source='" + strpath + "';" + "Extended Properties=Excel 12.0;";
                OleDbConnection objConn = null;
                objConn = new OleDbConnection(strcon);
                objConn.Open();

                // Get the data table containg the schema guid.
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
                objConn.Close();
                ds.Tables[0].Columns.Add("Error Message");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (Convert.ToString(dr[0]) == "" && Convert.ToString(dr[1]) == "" && Convert.ToString(dr[2]) == "" && Convert.ToString(dr[3]) == "" && Convert.ToString(dr[4]) == "")
                    {
                        dr.Delete();
                    }
                }
                ds.Tables[0].AcceptChanges();
                DataTable dt = new DataTable();
                DataTable dtfail = new DataTable();
                Boolean filestatus = true;
                string columnno = null;
                string errormsg = string.Empty;
                string empid = null;

                Int32 rowno = 0;
                empcodeempty = true;


                dtfail.Columns.Add("S.NO", typeof(Int32));
                dtfail.Columns.Add("PROJECT", typeof(Int32));
                dtfail.Columns.Add("ROWNO", typeof(Int32));
                dtfail.Columns.Add("COLUMNS NAMES", typeof(string));

                if (ds.Tables[0].Rows.Count == 0)
                {
                    BLL.ShowMessage(this, "Successfully processed Excel file. No Records are Imported.");
                    return;
                }
                else
                {
                    if (!(ds.Tables[0].Columns[0].ToString().Trim() == "Employee ID*"))
                    {
                        Delete_Excel_File();
                        BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                        return;
                    }
                    if (!(ds.Tables[0].Columns[1].ToString().Trim() == "Employee Name*"))
                    {
                        Delete_Excel_File();
                        BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                        return;
                    }
                    if (!(ds.Tables[0].Columns[2].ToString().Trim() == "Date of Attendance*(dd/mm/yyyy)"))
                    {
                        Delete_Excel_File();
                        BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                        return;
                    }
                    if (!(ds.Tables[0].Columns[3].ToString().Trim() == "In Time*(hh:mm)24 Hrs"))
                    {
                        Delete_Excel_File();
                        BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                        return;
                    }
                    if (!(ds.Tables[0].Columns[4].ToString().Trim() == "Out Time*(hh:mm)24 Hrs"))
                    {
                        Delete_Excel_File();
                        BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                        return;
                    }
                    if (!(ds.Tables[0].Columns[5].ToString().Trim() == "Attendance Status*"))
                    {
                        Delete_Excel_File();
                        BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                        return;
                    }
                    #region Validating Each row in excel
                    ///<summary>
                    ///this will loop all the records in excel and validating each cell
                    ///</summary>
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        emp_ID1 = 0;
                        filestatus = true;
                        columnno = "";
                        employeecorret = 0;
                        employeebusinessunit = true;
                        employeestatus = true;
                        errormsg = "";
                        rowno = 0;
                        empcodeempty = true;

                        #region Validation Employee Code
                        ///<summary>
                        /// checking for the existance of the employee code corresponding to the logined
                        /// user organisation and selected business unit.
                        /// </summary>

                        if (ds.Tables[0].Rows[i]["Employee ID*"].ToString().Trim() != "")
                        {
                            SMHR_EMPLOYEE1 _obj_SMHR_EMPLOYEE1 = new SMHR_EMPLOYEE1();
                            _obj_SMHR_EMPLOYEE1.MODE = 8;
                            _obj_SMHR_EMPLOYEE1.EMP_ID = ds.Tables[0].Rows[i]["Employee ID*"].ToString().Trim();
                            _obj_SMHR_EMPLOYEE1.BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
                            //IF EMPLOYEE CODE IS GENERATED MANUALLY WE ARE CHECKING THAT EXISTANCE OF THE CODE 
                            //IN ONLY THAT ORGANISATION IF SAME CODE IS GENERATED BY THE OTHER THEN IT WILL BE A PROBLEM SO I ADDED ORGID HERE.
                            _obj_SMHR_EMPLOYEE1.ORGID = Convert.ToInt32(Session["ORG_ID"]);

                            //employee in organisation or not if exists picking the employee id which is unique

                            DataTable dtempid22 = Pms_Bll.get_Employee1(_obj_SMHR_EMPLOYEE1);
                            if (dtempid22.Rows.Count != 0)
                            {
                                emp_ID1 = Convert.ToInt32(dtempid22.Rows[0]["emp_id"]);
                                _obj_SMHR_EMPLOYEE1.MODE = 2;
                                _obj_SMHR_EMPLOYEE1.EMP_ID = Convert.ToString(emp_ID1);
                                _obj_SMHR_EMPLOYEE1.BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);

                                //employee in selected business unit or not 

                                dt = Pms_Bll.get_Employee1(_obj_SMHR_EMPLOYEE1);
                                if (dt.Rows.Count == 0)
                                {
                                    errormsg = errormsg + "," + "Employee does not belongs to this Business Unit";
                                    employeebusinessunit = false;
                                    employeestatus = false;
                                    filestatus = false;
                                    rowno = i + 2;
                                    columnno = "Employee ID*";
                                }

                                // checking for the status of the employee
                                if (employeebusinessunit != false)
                                {
                                    _obj_SMHR_EMPLOYEE1.MODE = 1;
                                    _obj_SMHR_EMPLOYEE1.EMP_ID = Convert.ToString(emp_ID1);
                                    _obj_SMHR_EMPLOYEE1.BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
                                    _obj_SMHR_EMPLOYEE1.DATE1 = Convert.ToString(ds.Tables[0].Rows[i]["Date of Attendance*(dd/mm/yyyy)"]);
                                    string date = Convert.ToString(ds.Tables[0].Rows[i]["Date of Attendance*(dd/mm/yyyy)"]).Trim();
                                    int monthposition = date.IndexOf("/");
                                    string day = date.Substring(monthposition + 1, monthposition + 1);
                                    if (day.Contains("/"))
                                        day = day.Remove(day.Length - 1);
                                    string month = date.Substring(0, monthposition);
                                    int position = date.LastIndexOf("/");
                                    string year = date.Substring(position + 1, 4);
                                    if ((month == "0") || (day == "0") || (year.Length != 4))
                                    {
                                        errormsg = errormsg + "," + "In Valid Date";
                                        filestatus = false;
                                        rowno = i + 2;
                                        columnno = columnno + "," + "Date of Attendance*(dd/mm/yyyy)";
                                        continue;
                                    }
                                    //date = day + "/" + month + "/" + year;
                                    date = month + "/" + day + "/" + year;
                                    //position += 5;
                                    bool Chkdate = BLL.CheckDateFormat(date.Trim());
                                    if (Chkdate == true)
                                    {
                                        //_obj_SMHR_EMPLOYEE1.DATE = Convert.ToDateTime(ds.Tables[0].Rows[i]["Date of Attendance*(dd/mm/yyyy)"]);
                                        //_obj_SMHR_EMPLOYEE1.DATE = Convert.ToDateTime(DateTime.ParseExact(Convert.ToString(ds.Tables[0].Rows[i]["Date of Attendance*(dd/mm/yyyy)"]), "MM/dd/yyyy", CultureInfo.InvariantCulture));
                                        dt = Pms_Bll.get_Employee1(_obj_SMHR_EMPLOYEE1);
                                        if (dt.Rows.Count > 0)
                                        {
                                            if (Convert.ToInt32(dt.Rows[0][0].ToString()) == 2)
                                            {
                                                //errormsg = "Employee is Inactive";
                                                //filestatus = false;
                                                rowno = i + 2;
                                                //columnno = "Employee ID*";
                                                //employeestatus = false;
                                            }
                                        }
                                        else
                                        {
                                            errormsg = "Employee is Resigned From the Selected Businessunit";
                                            filestatus = false;
                                            rowno = i + 2;
                                            columnno = "Employee ID*";
                                            employeestatus = false;
                                        }
                                    }
                                    else
                                    {
                                        errormsg = errormsg + "," + "Attendance Date format is not correct";
                                        filestatus = false;
                                        rowno = i + 2;
                                        columnno = columnno + "," + "Date of Attendance*(dd/mm/yyyy)";
                                    }
                                }
                            }
                            else
                            {
                                errormsg = "Entered EmployeeId is not Found!";
                                filestatus = false;
                                rowno = i + 2;
                                columnno = "Employee ID*";
                                emp_ID1 = 0;
                            }
                        }
                        else
                        {
                            errormsg = "Please enter the EmployeeId";
                            filestatus = false;
                            rowno = i + 2;
                            columnno = "Employee ID*";
                            emp_ID1 = 0;
                        }
                        #endregion

                        //=====================
                        #region Validating Date Of Attendance
                        ///<summary>
                        ///here we are validating the date of attendance with given employee code
                        ///whether that particular employee is joined in to the organisation or not ,
                        ///whether the selected date is weekly off  for the given employee code
                        ///and is he given attendance already for the selected date or not
                        ///</summary>

                        if ((ds.Tables[0].Rows[i]["Date of Attendance*(dd/mm/yyyy)"]).ToString().Trim() != "")
                        {
                            //string date = Convert.ToString(ds.Tables[0].Rows[i]["Date of Attendance*(dd/mm/yyyy)"]).Trim();
                            //int position = date.LastIndexOf("/");
                            //position += 5;
                            //bool Chkdate = BLL.CheckDateFormat(date.Substring(0, position).Trim());
                            string date = Convert.ToString(ds.Tables[0].Rows[i]["Date of Attendance*(dd/mm/yyyy)"]).Trim();
                            int monthposition = date.IndexOf("/");
                            string day = date.Substring(monthposition + 1, monthposition + 1);
                            if (day.Contains("/"))
                                day = day.Remove(day.Length - 1);
                            string month = date.Substring(0, monthposition);
                            int position = date.LastIndexOf("/");
                            string year = date.Substring(position + 1, 4);
                            if ((month == "0") || (day == "0") || (year.Length != 4))
                            {
                                errormsg = errormsg + "," + "In Valid Date";
                                filestatus = false;
                                rowno = i + 2;
                                columnno = columnno + "," + "Date of Attendance*(dd/mm/yyyy)";
                                continue;
                            }
                            //date = day + "/" + month + "/" + year;

                            if (Convert.ToString(month.Length) == "2")
                            {
                                if (Convert.ToString(day.Length) == "2")
                                {
                                    if (day.Contains("/"))
                                    {
                                        date = month + "/" + day + year;
                                    }
                                    else
                                    {
                                        date = month + "/" + day + "/" + year;
                                    }
                                }
                                else
                                {
                                    date = month + "/" + day + year;
                                }
                            }
                            else
                            {
                                date = month + "/" + day + "/" + year;
                            }
                            //position += 5;
                            bool Chkdate = BLL.CheckDateFormat(date.Trim());
                            if (Chkdate == true)
                            {
                                SMHR_EMPLOYEE1 _obj_SMHR_EMPLOYEE1 = new SMHR_EMPLOYEE1();
                                _obj_SMHR_EMPLOYEE1.MODE = 14;
                                _obj_SMHR_EMPLOYEE1.DATE_STRING = date;
                                //_obj_SMHR_EMPLOYEE1.DATE_STRING = Convert.ToString(ds.Tables[0].Rows[i]["Date of Attendance*(dd/mm/yyyy)"]);
                                DataTable dtdatecheck = Pms_Bll.get_Employee1(_obj_SMHR_EMPLOYEE1);

                                if (Convert.ToInt32(dtdatecheck.Rows[0]["Status1"]) == 1)
                                    stdatetime = true;
                                else
                                    stdatetime = false;

                                if (stdatetime == true)
                                {
                                    _obj_SMHR_EMPLOYEE1.MODE = 4;
                                    _obj_SMHR_EMPLOYEE1.EMP_ID = Convert.ToString(emp_ID1);
                                    _obj_SMHR_EMPLOYEE1.DATE_STRING = date;
                                    //_obj_SMHR_EMPLOYEE1.DATE_STRING = Convert.ToString(ds.Tables[0].Rows[i]["Date of Attendance*(dd/mm/yyyy)"]);
                                    _obj_SMHR_EMPLOYEE1.BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);

                                    //is any attendance in table with same date for employee
                                    dt = Pms_Bll.get_Employee1(_obj_SMHR_EMPLOYEE1);
                                    if (dt.Rows.Count != 0)
                                    {
                                        errormsg = errormsg + "," + "Already Attendance Taken On This Date";
                                        filestatus = false;
                                        rowno = i + 2;
                                        columnno = columnno + "," + "Date of Attendance*(dd/mm/yyyy)";
                                    }

                                    else
                                    {
                                        _obj_SMHR_EMPLOYEE1.MODE = 6;
                                        _obj_SMHR_EMPLOYEE1.DATE_STRING = date;
                                        //_obj_SMHR_EMPLOYEE1.DATE_STRING = Convert.ToString(ds.Tables[0].Rows[i]["Date of Attendance*(dd/mm/yyyy)"]);
                                        _obj_SMHR_EMPLOYEE1.BU_ID = Convert.ToInt32(rcm_period.SelectedItem.Value);
                                        DataTable dtperiod1 = Pms_Bll.get_Employee1(_obj_SMHR_EMPLOYEE1);
                                        if (dtperiod1.Rows.Count <= 0)
                                        {
                                            errormsg = errormsg + "," + "No Period is Available With this Date For the Selected Financial Period";
                                            filestatus = false;
                                            rowno = i + 2;
                                            columnno = columnno + "," + "Date of Attendance*(dd/mm/yyyy)";
                                        }
                                        DataTable dtperiod = Pms_Bll.get_Employee1(_obj_SMHR_EMPLOYEE1);
                                        _obj_SMHR_EMPLOYEE1.MODE = 5;
                                        if (employeestatus != false)
                                        {
                                            _obj_SMHR_EMPLOYEE1.EMP_ID = Convert.ToString(emp_ID1);
                                        }
                                        if (dtperiod.Rows.Count != 0)
                                        {
                                            _obj_SMHR_EMPLOYEE1.emp_code = Convert.ToString(dtperiod.Rows[0]["PRDDTL_ID"]);
                                        }
                                        else
                                        {
                                            _obj_SMHR_EMPLOYEE1.emp_code = Convert.ToString(0);
                                        }
                                        if (employeestatus != false)
                                        {
                                            _obj_SMHR_EMPLOYEE1.BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
                                        }
                                        _obj_SMHR_EMPLOYEE1.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);

                                        //is any attendance in table with same date for employee
                                        DataTable dt2 = Pms_Bll.get_Employee1(_obj_SMHR_EMPLOYEE1);
                                        if (dt2.Rows.Count != 0)
                                        {
                                            errormsg = errormsg + "," + "Payroll For This Period Already Done";
                                            filestatus = false;
                                            rowno = i + 2;
                                            columnno = columnno + "," + "   Date of Attendance*(dd/mm/yyyy)";
                                        }

                                        //_obj_SMHR_EMPLOYEE1.MODE = 13;
                                        //_obj_SMHR_EMPLOYEE1.DATE_STRING=Convert.ToString(ds.Tables[0].Rows[i]["Date of Attendance*(dd/mm/yyyy)"]).Trim();                                        
                                        //_obj_SMHR_EMPLOYEE1.EMP_ID = Convert.ToString(emp_ID1);
                                        // dt = Pms_Bll.get_Employee1(_obj_SMHR_EMPLOYEE1);
                                        // if (dt.Rows.Count > 0)
                                        // {
                                        //     if (!(Convert.ToDateTime(dt.Rows[0][0]) <= Convert.ToDateTime(ds.Tables[0].Rows[i]["Date of Attendance*(dd/mm/yyyy)"])))
                                        //     {
                                        //         errormsg = errormsg + "," + "Employee is not Joined for the Given Date Of Attendance";
                                        //         filestatus = false;
                                        //         rowno = i + 2;
                                        //         columnno = columnno + "," + "Date of Attendance*(dd/mm/yyyy)";
                                        //     }
                                        // }

                                    }
                                }
                                else
                                {
                                    errormsg = errormsg + "," + "Date Of Attendance Greater Than Today Date";
                                    filestatus = false;
                                    rowno = i + 2;
                                    columnno = columnno + "," + "Date of Attendance*(dd/mm/yyyy)";
                                }
                                // checking for the date of join of the selected employee on attendance date 
                                _obj_SMHR_EMPLOYEE1.MODE = 15;
                                if (employeestatus != false)
                                {
                                    _obj_SMHR_EMPLOYEE1.DATE1 = Convert.ToString(ds.Tables[0].Rows[i]["Date of Attendance*(dd/mm/yyyy)"]);
                                    //_obj_SMHR_EMPLOYEE1.DATE = Convert.ToDateTime(ds.Tables[0].Rows[i]["Date of Attendance*(dd/mm/yyyy)"]);
                                    //_obj_SMHR_EMPLOYEE1.DATE = Convert.ToDateTime(DateTime.ParseExact(Convert.ToString(ds.Tables[0].Rows[i]["Date of Attendance*(dd/mm/yyyy)"]), "MM/dd/yyyy", CultureInfo.InvariantCulture));
                                    _obj_SMHR_EMPLOYEE1.EMP_ID = emp_ID1.ToString();
                                    dt = Pms_Bll.get_Employee1(_obj_SMHR_EMPLOYEE1);
                                    if (Convert.ToString(dt.Rows[0][0]).ToUpper() != "TRUE")
                                    {
                                        errormsg = errormsg + "," + "This Employee has not Joined for Selected Attendance Date";
                                        filestatus = false;
                                        rowno = i + 2;
                                        columnno = columnno + "," + "Date of Attendance*(dd/mm/yyyy)";
                                    }
                                }
                                // checking attendance date is  between financial period start date and end date 
                                _obj_SMHR_EMPLOYEE1.MODE = 18;
                                if (employeestatus != false)
                                {
                                    _obj_SMHR_EMPLOYEE1.DATE1 = Convert.ToString(ds.Tables[0].Rows[i]["Date of Attendance*(dd/mm/yyyy)"]);
                                    //_obj_SMHR_EMPLOYEE1.DATE = Convert.ToDateTime(ds.Tables[0].Rows[i]["Date of Attendance*(dd/mm/yyyy)"]);
                                    //_obj_SMHR_EMPLOYEE1.DATE = Convert.ToDateTime(DateTime.ParseExact(Convert.ToString(ds.Tables[0].Rows[i]["Date of Attendance*(dd/mm/yyyy)"]), "MM/dd/yyyy", CultureInfo.InvariantCulture));
                                    _obj_SMHR_EMPLOYEE1.finperiod = Convert.ToInt32(rcm_period.SelectedValue);
                                    DataTable dt_exist = Pms_Bll.get_Employee1(_obj_SMHR_EMPLOYEE1);
                                    if (dt_exist.Rows.Count > 0)
                                    {
                                        if (Convert.ToString(dt_exist.Rows[0][0]) == "0")
                                        {
                                            errormsg = errormsg + "," + "This Attendance Date won't Fall Under Selected Financial Period";
                                            filestatus = false;
                                            rowno = i + 2;
                                            columnno = columnno + "," + "Date of Attendance*(dd/mm/yyyy)";
                                        }
                                    }

                                }
                            }
                            else
                            {
                                errormsg = errormsg + "," + "Attendance Date format is not correct";
                                filestatus = false;
                                rowno = i + 2;
                                columnno = columnno + "," + "Date of Attendance*(dd/mm/yyyy)";

                            }
                        }

                        else
                        {
                            errormsg = errormsg + "," + "Please enter the Attendance Date";
                            filestatus = false;
                            rowno = i + 2;
                            columnno = columnno + "," + "Date of Attendance*(dd/mm/yyyy)";

                        }


                        #endregion

                        #region Validating Intime
                        ///<summary>
                        ///validating in time  whether it is greater than zero or not 
                        ///and also the time format
                        ///</summary>

                        if (ds.Tables[0].Rows[i]["In Time*(hh:mm)24 Hrs"].ToString().Trim() != "")
                        {//i have to compare in time with time format

                            if (CheckStringValue(ds.Tables[0].Rows[i]["In Time*(hh:mm)24 Hrs"].ToString().Trim()) == true)
                            {
                                //string str_time = attendance_startdate.Day + "/" + attendance_startdate.Month + "/" +attendance_startdate.Year + " " + Convert.ToString(ds.Tables[0].Rows[i]["In Time*(hh:mm)24 Hrs"].ToString().Trim());
                                String strChktime = ds.Tables[0].Rows[i]["In Time*(hh:mm)24 Hrs"].ToString().Trim();

                                string str_time = ParseMilitaryTime(ds.Tables[0].Rows[i]["In Time*(hh:mm)24 Hrs"].ToString().Trim(), attendance_startdate.Year, attendance_startdate.Month, attendance_startdate.Day).ToString();
                                DtInTime = ParseMilitaryTime(ds.Tables[0].Rows[i]["In Time*(hh:mm)24 Hrs"].ToString().Trim(), attendance_startdate.Year, attendance_startdate.Month, attendance_startdate.Day);
                                bool isDtformat = DateTime.TryParse(str_time, out ln_time);
                                if (!isDtformat)
                                {

                                    errormsg = errormsg + "," + "In Time Incorrect Format";
                                    filestatus = false;
                                    rowno = i + 2;
                                    columnno = columnno + "," + "In Time*(hh:mm)24 Hrs";
                                }
                                else
                                {
                                    if ((ln_time.Hour == 00) && (ln_time.Minute == 00))
                                    {
                                        errormsg = errormsg + "," + "In Time should be greater than zero";
                                        filestatus = false;
                                        rowno = i + 2;
                                        columnno = columnno + "," + "In Time*(hh:mm)24 Hrs";

                                    }

                                }

                            }
                            else
                            {
                                errormsg = errormsg + "," + "In Time format Is not correct ";
                                filestatus = false;
                                rowno = i + 2;
                                columnno = columnno + "," + "In Time*(hh:mm)24 Hrs";
                            }
                        }
                        else
                        {
                            errormsg = errormsg + "," + "Please enter In Time";
                            filestatus = false;
                            rowno = i + 2;
                            columnno = columnno + "," + "In Time*(hh:mm)24 Hrs";

                        }
                        #endregion

                        #region Validating  Outtime
                        ///<summary>
                        ///validating out time  whether it is greater than zero or not,
                        ///it should be greater than in time
                        ///and also the time format
                        ///</summary>
                        if (ds.Tables[0].Rows[i]["Out Time*(hh:mm)24 Hrs"].ToString().Trim() != "")
                        {
                            if (CheckStringValue(ds.Tables[0].Rows[i]["Out Time*(hh:mm)24 Hrs"].ToString().Trim()) == true)
                            {

                                DateTime ln_out_time;
                                string str_out_time = ParseMilitaryTime(ds.Tables[0].Rows[i]["Out Time*(hh:mm)24 Hrs"].ToString().Trim(), attendance_startdate.Year, attendance_startdate.Month, attendance_startdate.Day).ToString();
                                DateTime DtOutTime = ParseMilitaryTime(ds.Tables[0].Rows[i]["Out Time*(hh:mm)24 Hrs"].ToString().Trim(), attendance_startdate.Year, attendance_startdate.Month, attendance_startdate.Day);
                                bool isNum = DateTime.TryParse(str_out_time, out ln_out_time);

                                if (!isNum)
                                {
                                    errormsg = errormsg + "," + "Out Time Format Not Correct";
                                    filestatus = false;
                                    rowno = i + 2;
                                    columnno = columnno + "," + "Out Time*(hh:mm)24 Hrs";
                                }
                                else
                                {
                                    if ((ln_out_time.Hour == 00) && (ln_out_time.Minute == 00))
                                    {
                                        errormsg = errormsg + "," + "Out Time should be greater than zero";
                                        filestatus = false;
                                        rowno = i + 2;
                                        columnno = columnno + "," + "Out Time*(hh:mm)24 Hrs";

                                    }

                                    //    str_out_time = attendance_startdate.Day + "/" + attendance_startdate.Month + "/" + attendance_startdate.Year + " " + strouttime;

                                    if (DtOutTime.TimeOfDay < DtInTime.TimeOfDay)
                                    {
                                        errormsg = errormsg + "," + "Out Time should be greater than in time";
                                        filestatus = false;
                                        rowno = i + 2;
                                        columnno = columnno + "," + "Out Time*(hh:mm)24 Hrs";

                                    }

                                }
                            }
                            else
                            {
                                errormsg = errormsg + "," + "Out format Is not correct ";
                                filestatus = false;
                                rowno = i + 2;
                                columnno = columnno + "," + "Out Time*(hh:mm)24 Hrs";
                            }
                        }
                        else
                        {
                            errormsg = errormsg + "," + "Please enter Out Time";
                            filestatus = false;
                            rowno = i + 2;
                            columnno = columnno + "," + "Out Time*(hh:mm)24 Hrs";
                        }

                        if (ds.Tables[0].Rows[i]["Attendance Status*"].ToString().Trim() != "")
                        {

                            if ((ds.Tables[0].Rows[i]["Attendance Status*"].ToString().Trim().ToUpper() == "P") || (ds.Tables[0].Rows[i]["Attendance Status*"].ToString().Trim().ToUpper() == "A") || (ds.Tables[0].Rows[i]["Attendance Status*"].ToString().Trim().ToUpper() == "L") || (ds.Tables[0].Rows[i]["Attendance Status*"].ToString().Trim().ToUpper() == "W") || (ds.Tables[0].Rows[i]["Attendance Status*"].ToString().Trim().ToUpper() == "T") || (ds.Tables[0].Rows[i]["Attendance Status*"].ToString().Trim().ToUpper() == "C") || (ds.Tables[0].Rows[i]["Attendance Status*"].ToString().Trim().ToUpper() == "H") || (ds.Tables[0].Rows[i]["Attendance Status*"].ToString().Trim().ToUpper() == "HD") || (ds.Tables[0].Rows[i]["Attendance Status*"].ToString().Trim().ToUpper() == "HL"))
                            {

                            }
                            else
                            {
                                errormsg = errormsg + "," + "Attendance Status Not Correct";
                                filestatus = false;
                                rowno = i + 2;
                                columnno = columnno + "," + "Attendance Status*";


                            }
                        }
                        else
                        {

                            errormsg = errormsg + "," + "Please enter Attendance Status";
                            filestatus = false;
                            rowno = i + 2;
                            columnno = columnno + "," + "Attendance Status*";
                        }

                        #endregion

                        #region Checking for Duplicate Entry
                        ///<summary>
                        ///// checking for the duplicate data in excel sheet
                        for (int duplicaterecord = 0; duplicaterecord < ds.Tables[0].Rows.Count; duplicaterecord++)
                        {
                            if (((ds.Tables[0].Rows[i]["Date of Attendance*(dd/mm/yyyy)"]).ToString().Trim() == (ds.Tables[0].Rows[duplicaterecord]["Date of Attendance*(dd/mm/yyyy)"]).ToString().Trim()) && (ds.Tables[0].Rows[i]["Employee ID*"].ToString().Trim() == ds.Tables[0].Rows[duplicaterecord]["Employee ID*"].ToString().Trim()))
                            {
                                if (i != duplicaterecord)
                                {
                                    errormsg = errormsg + "," + " Employee id and Date of Attendance is Repeated in Excel Sheet";
                                    filestatus = false;
                                    rowno = i + 2;
                                    columnno = "Date of Attendance*(dd/mm/yyyy)";
                                    break;
                                }
                            }
                        }

                        #endregion

                        if (filestatus == false)
                        {
                            DataRow newrow = dtfail.NewRow();
                            newrow["S.NO"] = dtfail.Rows.Count + 1;
                            newrow["PROJECT"] = emp_ID1;
                            if (errormsg != string.Empty)
                            {
                                columnno = columnno + "," + "Error Message";
                            }
                            //rowno = rowno + 2;
                            newrow["ROWNO"] = rowno;
                            newrow["COLUMNS NAMES"] = columnno;
                            dtfail.Rows.Add(newrow);
                            ds.Tables[0].Rows[i]["Error Message"] = errormsg;

                        }


                    } // this is the closing of for loop
                    #endregion

                    #region Checking for the existence of error message
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
                        //newwindow.Width = Unit.Parse(this.Rm_Attenadnce_PAGE.Width.ToString());
                        newwindow.Width = 1150;
                        newwindow.Height = 500;
                        newwindow.VisibleOnPageLoad = true;
                        if (RWM_POSTREPLY1.Windows.Count > 1)
                        {
                            RWM_POSTREPLY1.Windows.RemoveAt(1);
                        }
                        RWM_POSTREPLY1.Windows.Add(newwindow);
                        employeestatus = true;

                        Rg_Attendancedtls.Visible = false;
                        //btn_Submit.Visible = false;
                        rdbList.Visible = false;
                        btn_cancel.Visible = false;
                        BTN_FINALISE.Visible = false;
                        RWM_POSTREPLY1.Visible = true;
                        return;

                    }
                    #endregion
                    //else
                    //{
                    //    for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
                    //    {
                    //        //for (int k = r + 1; k < ds.Tables[0].Rows.Count; k++)
                    //        for (int k =0; k < ds.Tables[0].Rows.Count; k++)
                    //        {

                    //            if (Convert.ToString(ds.Tables[0].Rows[r]["Employee ID*"]) == Convert.ToString(ds.Tables[0].Rows[k]["Employee ID*"]) && Convert.ToDateTime(ds.Tables[0].Rows[r]["Date of Attendance*(dd/mm/yyyy)"]) == Convert.ToDateTime(ds.Tables[0].Rows[k]["Date of Attendance*(dd/mm/yyyy)"]))
                    //            {
                    //                DataRow newrow = dtfail.NewRow();
                    //                newrow["S.NO"] = dtfail.Rows.Count + 1;
                    //                newrow["PROJECT"] = ds.Tables[0].Rows[r]["Employee ID*"];
                    //                errormsg = "Duplicate Record";
                    //                if (errormsg != string.Empty)
                    //                {
                    //                    columnno = "Employee ID*";
                    //                    columnno = columnno + "," + "Date of Attendance*(dd/mm/yyyy)";
                    //                    columnno = columnno + "," + "Error Message";
                    //                }
                    //                rowno = r + 2;
                    //                newrow["ROWNO"] = rowno;

                    //                newrow["COLUMNS NAMES"] = columnno;
                    //                dtfail.Rows.Add(newrow);
                    //                DataRow newrow1 = dtfail.NewRow();
                    //                newrow1["S.NO"] = dtfail.Rows.Count + 1;
                    //                newrow1["PROJECT"] = ds.Tables[0].Rows[k]["Employee ID*"];
                    //                errormsg = "Duplicate Record";
                    //                if (errormsg != string.Empty)
                    //                {
                    //                    columnno = "Employee ID*";
                    //                    columnno = columnno + "," + "Date of Attendance*(dd/mm/yyyy)";
                    //                    columnno = columnno + "," + "Error Message";
                    //                }
                    //                rowno = k + 2;
                    //                newrow1["ROWNO"] = rowno;

                    //                newrow1["COLUMNS NAMES"] = columnno;
                    //                dtfail.Rows.Add(newrow1);
                    //                // ds.Tables[0].Columns.Add("Error Message");
                    //                ds.Tables[0].Rows[r]["Error Message"] = errormsg;
                    //                ds.Tables[0].Rows[k]["Error Message"] = errormsg;
                    //            }
                    //        }
                    //    }
                    //    if (dtfail.Rows.Count > 0)
                    //    {
                    //        Session["dt_fail"] = dtfail;
                    //        Session["ds_data"] = ds;
                    //        Delete_Excel_File();
                    //        //LinkButton lnk_Import_process = (LinkButton)RadPanelBar1.FindItemByValue("AddAttachment").FindControl("lnk_Import_process");
                    //        Telerik.Web.UI.RadWindow newwindow = new Telerik.Web.UI.RadWindow();
                    //        // RWM_POSTREPLY.Windows.Remove(newwindow);
                    //        newwindow.ID = "RadWindow_import";

                    //        newwindow.NavigateUrl = "~/Payroll/frm_AttendanceImportProcess.aspx";
                    //        newwindow.Title = "Import Process";
                    //        newwindow.Width = 1150;
                    //        newwindow.Height = 580;
                    //        newwindow.VisibleOnPageLoad = true;
                    //        if (RWM_POSTREPLY1.Windows.Count > 1)
                    //        {
                    //            RWM_POSTREPLY1.Windows.RemoveAt(1);
                    //        }
                    //        RWM_POSTREPLY1.Windows.Add(newwindow);
                    //        employeestatus = true;

                    //        Rg_Attendancedtls.Visible = false;
                    //        btn_Submit.Visible = false;
                    //        btn_cancel.Visible = false;
                    //        BTN_FINALISE.Visible = false;
                    //        RWM_POSTREPLY1.Visible = true;
                    //        return;
                    //    }

                    //}
                    //end or else

                    Rg_Attendancedtls.DataSource = ds;
                    Session["ds_data2"] = ds;
                    DataSet dt_sample = (DataSet)Session["ds_data2"];
                    Rg_Attendancedtls.DataBind();

                    for (int h = 0; h <= Rg_Attendancedtls.Items.Count - 1; h++)
                    {
                        Label lblempid1 = new System.Web.UI.WebControls.Label();
                        lblempid1 = Rg_Attendancedtls.Items[h].FindControl("lbl_empid") as Label;

                        TextBox txt__in_time_ = new TextBox();
                        txt__in_time_ = Rg_Attendancedtls.Items[h].FindControl("txt_intime") as TextBox;

                        TextBox txt__out_time_ = new TextBox();
                        txt__out_time_ = Rg_Attendancedtls.Items[h].FindControl("txt_outime") as TextBox;

                        RadComboBox ddlList = new RadComboBox();
                        ddlList = Rg_Attendancedtls.Items[h].FindControl("rcmb_AttDtls_Status1") as RadComboBox;

                        if ((Convert.ToString(Convert.ToString(ds.Tables[0].Rows[h][5]))).Trim() == "P")
                        {
                            ddlList.SelectedIndex = ddlList.FindItemIndexByValue((Convert.ToString("P")).Trim());
                        }
                        else if ((Convert.ToString(Convert.ToString(ds.Tables[0].Rows[h][5]))).Trim() == "A")
                        {
                            ddlList.SelectedIndex = ddlList.FindItemIndexByValue((Convert.ToString("A")).Trim());
                        }
                        else if ((Convert.ToString(Convert.ToString(ds.Tables[0].Rows[h][5]))).Trim() == "L")
                        {
                            ddlList.SelectedIndex = ddlList.FindItemIndexByValue((Convert.ToString("L")).Trim());
                        }
                        else if ((Convert.ToString(Convert.ToString(ds.Tables[0].Rows[h][5]))).Trim() == "W")
                        {
                            ddlList.SelectedIndex = ddlList.FindItemIndexByValue((Convert.ToString("W")).Trim());
                        }
                        else if ((Convert.ToString(Convert.ToString(ds.Tables[0].Rows[h][5]))).Trim() == "T")
                        {
                            ddlList.SelectedIndex = ddlList.FindItemIndexByValue((Convert.ToString("T")).Trim());
                        }
                        else if ((Convert.ToString(Convert.ToString(ds.Tables[0].Rows[h][5]))).Trim() == "C")
                        {
                            ddlList.SelectedIndex = ddlList.FindItemIndexByValue((Convert.ToString("C")).Trim());
                        }
                        else if ((Convert.ToString(Convert.ToString(ds.Tables[0].Rows[h][5]))).Trim() == "H")
                        {
                            ddlList.SelectedIndex = ddlList.FindItemIndexByValue((Convert.ToString("H")).Trim());

                        }
                        else if ((Convert.ToString(Convert.ToString(ds.Tables[0].Rows[h][5]))).Trim() == "HD")
                        {
                            ddlList.SelectedIndex = ddlList.FindItemIndexByValue((Convert.ToString("HD")).Trim());
                        }
                        else if ((Convert.ToString(Convert.ToString(ds.Tables[0].Rows[h][5]))).Trim() == "HL")
                        {
                            ddlList.SelectedIndex = ddlList.FindItemIndexByValue((Convert.ToString("HL")).Trim());
                        }
                        if (CheckStringValue(ds.Tables[0].Rows[h]["In Time*(hh:mm)24 Hrs"].ToString().Trim()) == true)
                        {



                            //string str_time = attendance_startdate.Day + "/" + attendance_startdate.Month + "/" +attendance_startdate.Year + " " + Convert.ToString(ds.Tables[0].Rows[i]["In Time*(hh:mm)24 Hrs"].ToString().Trim());
                            String strChktime1 = ds.Tables[0].Rows[h]["In Time*(hh:mm)24 Hrs"].ToString().Trim();

                            string str_time1 = ParseMilitaryTime(ds.Tables[0].Rows[h]["In Time*(hh:mm)24 Hrs"].ToString().Trim(), attendance_startdate.Year, attendance_startdate.Month, attendance_startdate.Day).ToString();
                            DateTime DtInTime1 = ParseMilitaryTime(ds.Tables[0].Rows[h]["In Time*(hh:mm)24 Hrs"].ToString().Trim(), attendance_startdate.Year, attendance_startdate.Month, attendance_startdate.Day);

                            //txt__in_time_.Text = Convert.ToString(DtInTime1.TimeOfDay);

                            txt__in_time_.Text = DtInTime1.ToString("hh:mm tt");
                        }

                        if (CheckStringValue(ds.Tables[0].Rows[h]["Out Time*(hh:mm)24 Hrs"].ToString().Trim()) == true)
                        {



                            //string str_time = attendance_startdate.Day + "/" + attendance_startdate.Month + "/" +attendance_startdate.Year + " " + Convert.ToString(ds.Tables[0].Rows[i]["In Time*(hh:mm)24 Hrs"].ToString().Trim());
                            String strChktime12 = ds.Tables[0].Rows[h]["Out Time*(hh:mm)24 Hrs"].ToString().Trim();

                            string str_time12 = ParseMilitaryTime(ds.Tables[0].Rows[h]["Out Time*(hh:mm)24 Hrs"].ToString().Trim(), attendance_startdate.Year, attendance_startdate.Month, attendance_startdate.Day).ToString();
                            DateTime DtInTime12 = ParseMilitaryTime(ds.Tables[0].Rows[h]["Out Time*(hh:mm)24 Hrs"].ToString().Trim(), attendance_startdate.Year, attendance_startdate.Month, attendance_startdate.Day);

                            //txt__out_time_.Text = Convert.ToString(DtInTime12.TimeOfDay);

                            txt__out_time_.Text = DtInTime12.ToString("hh:mm tt");
                        }

                        // checking for the weekly off and holiday
                        SMHR_EMPLOYEE1 _obj_employee1 = new SMHR_EMPLOYEE1();
                        _obj_employee1.MODE = 17;
                        _obj_employee1.EMP_ID = ((Rg_Attendancedtls.Items[h].FindControl("lbl_empid") as Label).Text).Trim();
                        _obj_employee1.DATE_STRING = Convert.ToString(dt_sample.Tables[0].Rows[h]["Date of Attendance*(dd/mm/yyyy)"]);
                        _obj_employee1.ORGID = Convert.ToInt32(Session["ORG_ID"]);
                        dt = Pms_Bll.get_Employee1(_obj_employee1);
                        if (dt.Rows.Count > 0)
                        {
                            if (Convert.ToInt32(dt.Rows[0][0]) == 1)
                            {
                                ddlList.SelectedIndex = ddlList.FindItemIndexByValue(Convert.ToString("W"));
                                continue;
                            }
                        }
                        else
                        {
                            if (Convert.ToString(Convert.ToString(ds.Tables[0].Rows[h][5])) == "W")
                            {
                                int Index = ddlList.FindItemIndexByValue(Convert.ToString("W"));
                                ddlList.Items[Index].Enabled = false;
                                ddlList.Items.Remove(Index);
                                ddlList.ClearSelection();
                                continue;
                            }
                        }
                        // CHECKING FOR HOLIDAY
                        _obj_employee1.MODE = 16;
                        _obj_employee1.BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedValue);
                        _obj_employee1.DATE_STRING = Convert.ToString(dt_sample.Tables[0].Rows[h]["Date of Attendance*(dd/mm/yyyy)"]);
                        dt = Pms_Bll.get_Employee1(_obj_employee1);
                        if (dt.Rows.Count > 0)
                        {
                            if (Convert.ToInt32(dt.Rows[0][0]) == 1)
                            {
                                ddlList.SelectedIndex = Convert.ToInt32(ddlList.FindItemIndexByValue(Convert.ToString("H")));
                                continue;
                            }
                        }
                        //   




                    }//for
                    Rg_Attendancedtls.Visible = true;
                    //btn_Submit.Visible = true;
                    trSelect.Visible = true;
                    rdbList.Visible = true;
                    btn_cancel.Visible = true;
                    BTN_FINALISE.Enabled = false;
                    BTN_FINALISE.Visible = true;
                    lbl_BusinessUnitName.Visible = true;
                    lbl_Period.Visible = true;
                    rcmb_BusinessUnitType.Enabled = false;
                    rcm_period.Enabled = false;
                    linkdownload.Visible = false;
                    fileupload_attendance.Visible = false;
                    btn_uploadattendance.Visible = false;

                    RWM_POSTREPLY1.Visible = false;
                    //}

                }
            }

            else
            {
                BLL.ShowMessage(this, "Please Select the File to be uploaded");
                return;
            }


        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_attendancereport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    //protected void btn_Submit_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        bool status1 = false;
    //        DataSet dt1 = new DataSet();
    //        dt1 = (DataSet)Session["ds_data2"];
    //        Label lblempid = new System.Web.UI.WebControls.Label();
    //        RadComboBox ddlList = new RadComboBox();
    //        if (Rg_Attendancedtls.Items.Count > 0)
    //        {

    //            for (int o = 0; o <= Rg_Attendancedtls.Items.Count - 1; o++)
    //            {
    //                TextBox txt__in_time_ = new TextBox();
    //                txt__in_time_ = Rg_Attendancedtls.Items[o].FindControl("txt_intime") as TextBox;

    //                TextBox txt__out_time_ = new TextBox();
    //                txt__out_time_ = Rg_Attendancedtls.Items[o].FindControl("txt_outime") as TextBox;


    //                ddlList = Rg_Attendancedtls.Items[o].FindControl("rcmb_AttDtls_Status1") as RadComboBox;

    //                lblempid = Rg_Attendancedtls.Items[o].FindControl("lbl_empid") as Label;
    //                _obj_Smhr_Attendance.OPERATION = operation.Insert1;
    //                _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);


    //                SMHR_EMPLOYEE1 _obj_SMHR_EMPLOYEE1 = new SMHR_EMPLOYEE1();
    //                _obj_SMHR_EMPLOYEE1.MODE = 8;

    //                _obj_SMHR_EMPLOYEE1.EMP_ID = dt1.Tables[0].Rows[o]["Employee ID*"].ToString().Trim();
    //                _obj_SMHR_EMPLOYEE1.BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
    //                _obj_SMHR_EMPLOYEE1.ORGID = Convert.ToInt32(Session["ORG_ID"]);

    //                DataTable dtempid223 = Pms_Bll.get_Employee1(_obj_SMHR_EMPLOYEE1);

    //                if (dtempid223.Rows.Count != 0)
    //                {
    //                    _obj_Smhr_Attendance.ATTENDANCE_EMP_ID = Convert.ToInt32(dtempid223.Rows[0]["emp_id"]);
    //                }

    //                _obj_Smhr_Attendance.DATE_STRING = Convert.ToString(dt1.Tables[0].Rows[o]["Date of Attendance*(dd/mm/yyyy)"]);



    //                _obj_SMHR_EMPLOYEE1.MODE = 6;
    //                Label lbl_Date=new Label();
    //                lbl_Date.Text = Rg_Attendancedtls.Items[o].Cells[4].Text;// attendance date
    //                //_obj_SMHR_EMPLOYEE1.DATE_STRING = Convert.ToString(dt1.Tables[0].Rows[o]["Date of Attendance*(dd/mm/yyyy)"]);
    //                _obj_SMHR_EMPLOYEE1.DATE_STRING = lbl_Date.Text; 
    //                _obj_SMHR_EMPLOYEE1.BU_ID = Convert.ToInt32(rcm_period.SelectedItem.Value);
    //                DataTable dtperiod = Pms_Bll.get_Employee1(_obj_SMHR_EMPLOYEE1);
    //                if (dtperiod.Rows.Count != 0)
    //                {
    //                    _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(dtperiod.Rows[0]["PRDDTL_ID"]);
    //                }


    //                _obj_Smhr_Attendance.ATTENDANCE_INTIME = Convert.ToString(txt__in_time_.Text);


    //                _obj_Smhr_Attendance.ATTENDANCE_OUTTIME = Convert.ToString(txt__out_time_.Text);
    //                _obj_Smhr_Attendance.ATTENDANCE_STATUS = Convert.ToString(ddlList.SelectedValue);
    //                _obj_Smhr_Attendance.ATTENDANCE_FINALIZE = 0;
    //                _obj_Smhr_Attendance.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);


    //                _obj_SMHR_EMPLOYEE1.MODE = 9;
    //                if (dtempid223.Rows.Count != 0)
    //                {
    //                    _obj_SMHR_EMPLOYEE1.EMP_ID = Convert.ToString(dtempid223.Rows[0]["emp_id"]);


    //                }

    //                //_obj_SMHR_EMPLOYEE1.DATE_STRING = Convert.ToString(dt1.Tables[0].Rows[o]["Date of Attendance*(dd/mm/yyyy)"]);
    //                _obj_SMHR_EMPLOYEE1.DATE_STRING = lbl_Date.Text; 
    //                //_obj_SMHR_EMPLOYEE1.DATE = Convert.ToDateTime(dt1.Tables[0].Rows[o]["Date of Attendance*(dd/mm/yyyy)"]);
    //                _obj_SMHR_EMPLOYEE1.BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);

    //                DataTable dtempexist = Pms_Bll.get_Employee1(_obj_SMHR_EMPLOYEE1);
    //                if (dtempexist.Rows.Count != 0)
    //                {

    //                }
    //                else
    //                {

    //                    _obj_SMHR_EMPLOYEE1.MODE = 12;
    //                    if (dtempid223.Rows.Count != 0)
    //                    {
    //                        _obj_SMHR_EMPLOYEE1.EMP_ID = Convert.ToString(dtempid223.Rows[0]["emp_id"]);


    //                    }
    //                    //_obj_SMHR_EMPLOYEE1.DATE_STRING = Convert.ToString(dt1.Tables[0].Rows[o]["Date of Attendance*(dd/mm/yyyy)"]);
    //                    _obj_SMHR_EMPLOYEE1.DATE_STRING = lbl_Date.Text; 
    //                    _obj_SMHR_EMPLOYEE1.BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);

    //                    DataTable dtindex = Pms_Bll.get_Employee1(_obj_SMHR_EMPLOYEE1);
    //                    if (dtindex.Rows.Count == 0)
    //                    {
    //                        _obj_Smhr_Attendance.CREATEDDATE = DateTime.Now;
    //                        _obj_Smhr_Attendance.LASTMDFDATE = DateTime.Now;
    //                        status1 = BLL.set_Attendance(_obj_Smhr_Attendance);
    //                    }

    //                }

    //            }

    //        }



    //        Pms_Bll.ShowMessage(this, "Attendance Details Inserted Successfully");


    //        LoadCombos();
    //        Session.Remove("dt_fail");
    //        Session.Remove("ds_data");
    //        Session.Remove("ds_data2");
    //        Rg_Attendancedtls.Visible = false;
    //        btn_Submit.Visible = false;
    //        btn_cancel.Visible = false;
    //        BTN_FINALISE.Visible = false;
    //        linkdownload.Visible = true;
    //        fileupload_attendance.Visible = true;
    //        btn_uploadattendance.Visible = true;
    //        RWM_POSTREPLY1.Visible = false;
    //        rcmb_BusinessUnitType.Enabled = true;
    //        rcm_period.Enabled = true;
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_attendancereport", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //        return;
    //    }

    //}
    protected void BTN_FINALISE_Click(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToString(rdbList.SelectedValue) == "1")
            {
                bool status1 = false;
                DataSet dt1 = new DataSet();
                dt1 = (DataSet)Session["ds_data2"];
                Label lblempid = new System.Web.UI.WebControls.Label();
                RadComboBox ddlList = new RadComboBox();
                if (Rg_Attendancedtls.Items.Count > 0)
                {

                    for (int o = 0; o <= Rg_Attendancedtls.Items.Count - 1; o++)
                    {
                        TextBox txt__in_time_ = new TextBox();
                        txt__in_time_ = Rg_Attendancedtls.Items[o].FindControl("txt_intime") as TextBox;

                        TextBox txt__out_time_ = new TextBox();
                        txt__out_time_ = Rg_Attendancedtls.Items[o].FindControl("txt_outime") as TextBox;


                        ddlList = Rg_Attendancedtls.Items[o].FindControl("rcmb_AttDtls_Status1") as RadComboBox;

                        lblempid = Rg_Attendancedtls.Items[o].FindControl("lbl_empid") as Label;
                        _obj_Smhr_Attendance.OPERATION = operation.Insert1;
                        _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);


                        SMHR_EMPLOYEE1 _obj_SMHR_EMPLOYEE1 = new SMHR_EMPLOYEE1();
                        _obj_SMHR_EMPLOYEE1.MODE = 8;

                        _obj_SMHR_EMPLOYEE1.EMP_ID = dt1.Tables[0].Rows[o]["Employee ID*"].ToString().Trim();
                        _obj_SMHR_EMPLOYEE1.BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
                        _obj_SMHR_EMPLOYEE1.ORGID = Convert.ToInt32(Session["ORG_ID"]);

                        DataTable dtempid223 = Pms_Bll.get_Employee1(_obj_SMHR_EMPLOYEE1);

                        if (dtempid223.Rows.Count != 0)
                        {
                            _obj_Smhr_Attendance.ATTENDANCE_EMP_ID = Convert.ToInt32(dtempid223.Rows[0]["emp_id"]);
                        }

                        _obj_Smhr_Attendance.DATE_STRING = Convert.ToString(dt1.Tables[0].Rows[o]["Date of Attendance*(dd/mm/yyyy)"]);



                        _obj_SMHR_EMPLOYEE1.MODE = 6;
                        Label lbl_Date = new Label();
                        lbl_Date.Text = Rg_Attendancedtls.Items[o].Cells[4].Text;// attendance date
                        //_obj_SMHR_EMPLOYEE1.DATE_STRING = Convert.ToString(dt1.Tables[0].Rows[o]["Date of Attendance*(dd/mm/yyyy)"]);
                        _obj_SMHR_EMPLOYEE1.DATE_STRING = lbl_Date.Text;
                        _obj_SMHR_EMPLOYEE1.BU_ID = Convert.ToInt32(rcm_period.SelectedItem.Value);
                        DataTable dtperiod = Pms_Bll.get_Employee1(_obj_SMHR_EMPLOYEE1);
                        if (dtperiod.Rows.Count != 0)
                        {
                            _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(dtperiod.Rows[0]["PRDDTL_ID"]);
                        }


                        _obj_Smhr_Attendance.ATTENDANCE_INTIME = Convert.ToString(txt__in_time_.Text);


                        _obj_Smhr_Attendance.ATTENDANCE_OUTTIME = Convert.ToString(txt__out_time_.Text);
                        _obj_Smhr_Attendance.ATTENDANCE_STATUS = Convert.ToString(ddlList.SelectedValue);
                        _obj_Smhr_Attendance.ATTENDANCE_FINALIZE = 0;
                        _obj_Smhr_Attendance.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);


                        _obj_SMHR_EMPLOYEE1.MODE = 9;
                        if (dtempid223.Rows.Count != 0)
                        {
                            _obj_SMHR_EMPLOYEE1.EMP_ID = Convert.ToString(dtempid223.Rows[0]["emp_id"]);


                        }

                        //_obj_SMHR_EMPLOYEE1.DATE_STRING = Convert.ToString(dt1.Tables[0].Rows[o]["Date of Attendance*(dd/mm/yyyy)"]);
                        _obj_SMHR_EMPLOYEE1.DATE_STRING = lbl_Date.Text;
                        //_obj_SMHR_EMPLOYEE1.DATE = Convert.ToDateTime(dt1.Tables[0].Rows[o]["Date of Attendance*(dd/mm/yyyy)"]);
                        _obj_SMHR_EMPLOYEE1.BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);

                        DataTable dtempexist = Pms_Bll.get_Employee1(_obj_SMHR_EMPLOYEE1);
                        if (dtempexist.Rows.Count != 0)
                        {

                        }
                        else
                        {

                            _obj_SMHR_EMPLOYEE1.MODE = 12;
                            if (dtempid223.Rows.Count != 0)
                            {
                                _obj_SMHR_EMPLOYEE1.EMP_ID = Convert.ToString(dtempid223.Rows[0]["emp_id"]);


                            }
                            //_obj_SMHR_EMPLOYEE1.DATE_STRING = Convert.ToString(dt1.Tables[0].Rows[o]["Date of Attendance*(dd/mm/yyyy)"]);
                            _obj_SMHR_EMPLOYEE1.DATE_STRING = lbl_Date.Text;
                            _obj_SMHR_EMPLOYEE1.BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);

                            DataTable dtindex = Pms_Bll.get_Employee1(_obj_SMHR_EMPLOYEE1);
                            if (dtindex.Rows.Count == 0)
                            {
                                _obj_Smhr_Attendance.CREATEDDATE = DateTime.Now;
                                _obj_Smhr_Attendance.LASTMDFDATE = DateTime.Now;
                                status1 = BLL.set_Attendance(_obj_Smhr_Attendance);
                            }

                        }

                    }

                }



                Pms_Bll.ShowMessage(this, "Attendance Details Inserted Successfully");


                LoadCombos();
                Session.Remove("dt_fail");
                Session.Remove("ds_data");
                Session.Remove("ds_data2");
                Rg_Attendancedtls.Visible = false;
                //btn_Submit.Visible = false;
                trSelect.Visible = false;
                rdbList.Visible = false;
                rdbList.SelectedIndex = -1;
                btn_cancel.Visible = false;
                BTN_FINALISE.Visible = false;
                linkdownload.Visible = true;
                fileupload_attendance.Visible = true;
                btn_uploadattendance.Visible = true;
                RWM_POSTREPLY1.Visible = false;
                rcmb_BusinessUnitType.Enabled = true;
                rcm_period.Enabled = true;
            }
            else if (Convert.ToString(rdbList.SelectedValue) == "2")
            {



                bool status1 = false;
                DataSet dt1 = new DataSet();
                dt1 = (DataSet)Session["ds_data2"];
                Label lblempid = new System.Web.UI.WebControls.Label();
                RadComboBox ddlList = new RadComboBox();
                if (Rg_Attendancedtls.Items.Count > 0)
                {

                    for (int o = 0; o <= Rg_Attendancedtls.Items.Count - 1; o++)
                    {
                        TextBox txt__in_time_ = new TextBox();
                        txt__in_time_ = Rg_Attendancedtls.Items[o].FindControl("txt_intime") as TextBox;

                        TextBox txt__out_time_ = new TextBox();
                        txt__out_time_ = Rg_Attendancedtls.Items[o].FindControl("txt_outime") as TextBox;


                        ddlList = Rg_Attendancedtls.Items[o].FindControl("rcmb_AttDtls_Status1") as RadComboBox;

                        lblempid = Rg_Attendancedtls.Items[o].FindControl("lbl_empid") as Label;

                        _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);

                        SMHR_EMPLOYEE1 _obj_SMHR_EMPLOYEE1 = new SMHR_EMPLOYEE1();
                        _obj_SMHR_EMPLOYEE1.MODE = 8;
                        _obj_SMHR_EMPLOYEE1.BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
                        _obj_SMHR_EMPLOYEE1.EMP_ID = dt1.Tables[0].Rows[o]["Employee ID*"].ToString().Trim();

                        _obj_SMHR_EMPLOYEE1.ORGID = Convert.ToInt32(Session["ORG_ID"]);

                        DataTable dtempid223 = Pms_Bll.get_Employee1(_obj_SMHR_EMPLOYEE1);

                        if (dtempid223.Rows.Count != 0)
                        {
                            _obj_Smhr_Attendance.ATTENDANCE_EMP_ID = Convert.ToInt32(dtempid223.Rows[0]["emp_id"]);
                        }

                        //_obj_SMHR_EMPLOYEE1.DATE_str1 = Condt1.Tables[0].Rows[o]["Date of Attendance*(dd/mm/yyyy)"]);
                        _obj_Smhr_Attendance.DATE_STRING = Convert.ToString(dt1.Tables[0].Rows[o]["Date of Attendance*(dd/mm/yyyy)"]);


                        _obj_SMHR_EMPLOYEE1.MODE = 6;
                        Label lbl_Date = new Label();
                        string date1 = Rg_Attendancedtls.Items[o].Cells[4].Text;// attendance date
                        string date = Convert.ToString(date1).Trim();
                        int monthposition = date.IndexOf("/");
                        string day = date.Substring(monthposition + 1, monthposition + 1);
                        if (day.Contains("/"))
                            day = day.Remove(day.Length - 1);
                        string month = date.Substring(0, monthposition);
                        int position = date.LastIndexOf("/");
                        string year = date.Substring(position + 1, 4);
                        if (Convert.ToString(month.Length) == "2")
                        {
                            if (Convert.ToString(day.Length) == "2")
                            {
                                if (day.Contains("/"))
                                {
                                    lbl_Date.Text = month + "/" + day + year;
                                }
                                else
                                {
                                    lbl_Date.Text = month + "/" + day + "/" + year;
                                }
                            }
                            else
                            {
                                lbl_Date.Text = month + "/" + day + year;
                            }
                        }
                        else
                        {
                            lbl_Date.Text = month + "/" + day + "/" + year;
                        }

                        //lbl_Date.Text = month + "/" + day + "/" + year;
                        //_obj_SMHR_EMPLOYEE1.DATE_STRING = Convert.ToString(dt1.Tables[0].Rows[o]["Date of Attendance*(dd/mm/yyyy)"]);
                        _obj_SMHR_EMPLOYEE1.DATE_STRING = lbl_Date.Text;
                        _obj_SMHR_EMPLOYEE1.BU_ID = Convert.ToInt32(rcm_period.SelectedItem.Value);
                        DataTable dtperiod = Pms_Bll.get_Employee1(_obj_SMHR_EMPLOYEE1);
                        if (dtperiod.Rows.Count != 0)
                        {
                            _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(dtperiod.Rows[0]["PRDDTL_ID"]);
                        }
                        _obj_Smhr_Attendance.ATTENDANCE_INTIME = Convert.ToString(txt__in_time_.Text);


                        _obj_Smhr_Attendance.ATTENDANCE_OUTTIME = Convert.ToString(txt__out_time_.Text);
                        _obj_Smhr_Attendance.ATTENDANCE_STATUS = Convert.ToString(ddlList.SelectedValue);
                        _obj_Smhr_Attendance.ATTENDANCE_FINALIZE = 1;
                        _obj_Smhr_Attendance.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        //////////////////// 
                        _obj_SMHR_EMPLOYEE1.MODE = 9;
                        if (dtempid223.Rows.Count != 0)
                        {
                            _obj_SMHR_EMPLOYEE1.EMP_ID = Convert.ToString(dtempid223.Rows[0]["emp_id"]);


                        }

                        //_obj_SMHR_EMPLOYEE1.DATE_str1 = Convert.ToString(dt1.Tables[0].Rows[o]["Date of Attendance*(dd/mm/yyyy)"]);

                        //_obj_SMHR_EMPLOYEE1.DATE_STRING = Convert.ToString(dt1.Tables[0].Rows[o]["Date of Attendance*(dd/mm/yyyy)"]);
                        _obj_SMHR_EMPLOYEE1.DATE_STRING = lbl_Date.Text;
                        //_obj_SMHR_EMPLOYEE1.DATE = Convert.ToDateTime(dt1.Tables[0].Rows[o]["Date of Attendance*(dd/mm/yyyy)"]);
                        _obj_SMHR_EMPLOYEE1.BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);

                        DataTable dtempexist = Pms_Bll.get_Employee1(_obj_SMHR_EMPLOYEE1);
                        if (dtempexist.Rows.Count > 0)
                        {
                            _obj_SMHR_EMPLOYEE1.MODE = 10;
                            if (dtempid223.Rows.Count != 0)
                            {
                                _obj_SMHR_EMPLOYEE1.EMP_ID = Convert.ToString(dtempid223.Rows[0]["emp_id"]);


                            }
                            _obj_SMHR_EMPLOYEE1.DATE_STRING = lbl_Date.Text;
                            //_obj_SMHR_EMPLOYEE1.DATE_STRING = Convert.ToString(dt1.Tables[0].Rows[o]["Date of Attendance*(dd/mm/yyyy)"]);
                            //_obj_SMHR_EMPLOYEE1.DATE = Convert.ToDateTime(dt1.Tables[0].Rows[o]["Date of Attendance*(dd/mm/yyyy)"]);
                            _obj_SMHR_EMPLOYEE1.ATTENDANCE_STATUS1 = Convert.ToString(ddlList.SelectedValue);
                            _obj_SMHR_EMPLOYEE1.BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
                            status1 = Pms_Bll.set_Employee1(_obj_SMHR_EMPLOYEE1);

                        }

                        else
                        {
                            _obj_SMHR_EMPLOYEE1.MODE = 12;
                            if (dtempid223.Rows.Count != 0)
                            {
                                _obj_SMHR_EMPLOYEE1.EMP_ID = Convert.ToString(dtempid223.Rows[0]["emp_id"]);


                            }
                            _obj_SMHR_EMPLOYEE1.DATE_STRING = lbl_Date.Text;
                            //_obj_SMHR_EMPLOYEE1.DATE_STRING = Convert.ToString(dt1.Tables[0].Rows[o]["Date of Attendance*(dd/mm/yyyy)"]);
                            //_obj_SMHR_EMPLOYEE1.DATE = Convert.ToDateTime(dt1.Tables[0].Rows[o]["Date of Attendance*(dd/mm/yyyy)"]);
                            _obj_SMHR_EMPLOYEE1.BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);

                            DataTable dtindex1 = Pms_Bll.get_Employee1(_obj_SMHR_EMPLOYEE1);
                            if (dtindex1.Rows.Count == 0)
                            {
                                _obj_Smhr_Attendance.OPERATION = operation.Insert1;
                                _obj_Smhr_Attendance.CREATEDDATE = DateTime.Now;
                                status1 = BLL.set_Attendance(_obj_Smhr_Attendance);
                            }
                        }





                    }

                }


                Pms_Bll.ShowMessage(this, "Attendance Details Finalsed Successfully");
                LoadCombos();
                Session.Remove("dt_fail");
                Session.Remove("ds_data");
                Session.Remove("ds_data2");
                Rg_Attendancedtls.Visible = false;
                //btn_Submit.Visible = false;
                trSelect.Visible = false;
                rdbList.Visible = false;
                rdbList.SelectedIndex = -1;
                btn_cancel.Visible = false;
                BTN_FINALISE.Visible = false;
                linkdownload.Visible = true;
                fileupload_attendance.Visible = true;
                btn_uploadattendance.Visible = true;
                RWM_POSTREPLY1.Visible = false;
                rcmb_BusinessUnitType.Enabled = true;
                rcm_period.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_attendancereport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }


    }
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        try
        {
            LoadCombos();
            Rg_Attendancedtls.Visible = false;
            //btn_Submit.Visible = false;
            trSelect.Visible = false;
            rdbList.Visible = false;
            rdbList.SelectedIndex = -1;
            btn_cancel.Visible = false;
            BTN_FINALISE.Visible = false;
            rcmb_BusinessUnitType.Enabled = true;
            rcm_period.Enabled = true;
            RWM_POSTREPLY1.Visible = false;
            linkdownload.Visible = true;
            fileupload_attendance.Visible = true;
            btn_uploadattendance.Visible = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_attendancereport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    #endregion

    //protected void rdbList_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (rdbList.SelectedIndex > -1)
    //    {
    //        BTN_FINALISE.Visible = true;
    //        BTN_FINALISE.Enabled = true;
    //    }
    //    else
    //    {
    //        BTN_FINALISE.Visible = false;
    //        BTN_FINALISE.Enabled = false;
    //    }
    //}
}
