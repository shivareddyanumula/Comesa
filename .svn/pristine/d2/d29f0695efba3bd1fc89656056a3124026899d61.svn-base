using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Telerik.Web.UI;
using SMHR;
using System.Drawing;

using SPMS;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;

public partial class Masters_frm_vapinp : System.Web.UI.Page
{
    #region References
    /// <summary>
    /// This Region consists of classes and their instances which were used
    /// in throughout the form
    /// </summary>
    SMHR_PERIOD _obj_smhr_period = new SMHR_PERIOD();
    SMHR_VARIABLEAMT _obj_vamt = new SMHR_VARIABLEAMT();
    DataTable dt_Result = new DataTable();
    DataTable dt_resultcomp = new DataTable();
    DataSet ds = new DataSet();

    static int exist = 0;
    DataTable dt_Null = null;
    string strfilename2;

    #endregion

    private void Loadcombos()
    {
        try
        {
            _obj_vamt.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_vamt.user_id = Convert.ToInt32(Session["USER_ID"].ToString());
            _obj_vamt.OPERATION = operation.Check;
            rcmb_Businessunit.Items.Clear();
            dt_Result = BLL.get_Employeevariableamt(_obj_vamt);
            rcmb_Businessunit.DataSource = dt_Result;
            rcmb_Businessunit.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_Businessunit.DataValueField = "BUSINESSUNIT_ID";
            rcmb_Businessunit.DataBind();
            rcmb_Businessunit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            // For Loading The Periods.
            _obj_smhr_period.OPERATION = operation.Select;//Method Related To Bonus
            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Result = BLL.get_PeriodHeaderDetails(_obj_smhr_period);
            rcmb_Financialperiod.DataSource = dt_Result;
            rcmb_Financialperiod.DataValueField = "PERIOD_ID";
            rcmb_Financialperiod.DataTextField = "PERIOD_NAME";
            rcmb_Financialperiod.DataBind();
            rcmb_Financialperiod.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            // btn_Save.Visible = false;
            //  btn_Update.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ImportEmpcomponents", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
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

                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("COUNTRY");
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
                    // Rg_Countries.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    Btn_upload.Visible = false;
                    //  btn_Update.Visible = false;
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
                Loadcombos();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ImportEmpcomponents", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_Businessunit_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rcmb_Financialperiod.ClearSelection();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ImportEmpcomponents", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ImportEmpcomponents", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }



    protected void Btn_upload_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_vamt.OPERATION = operation.Select;
            _obj_vamt.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            if ((rcmb_Businessunit.SelectedIndex > 0) && (rcmb_Financialperiod.SelectedIndex > 0))
            {
                _obj_vamt.BUID = Convert.ToInt32(rcmb_Businessunit.SelectedValue);
                dt_Result = BLL.get_Employeevariableamt(_obj_vamt);//GETTING ALL EMPLOYEES WHO ARE HAVING VARIABLE PAY
            }


            _obj_vamt.OPERATION = operation.Check;
            _obj_vamt.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_resultcomp = BLL.Get_Components(_obj_vamt);


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

            //string projecttype = null;
            Int32 rowno = 0;

            //DateTime dat;
            string columnno = null;
            //string projname = null;
            Boolean filestatus = true;
            Boolean filestatus1 = true;
            dtfail.Columns.Add("S.NO", typeof(Int32));
            dtfail.Columns.Add("ROWNO", typeof(Int32));
            dtfail.Columns.Add("COLUMNS NAMES", typeof(string));

            if (ds.Tables[0].Columns[0].ToString().Trim() == "EmployeeId*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[1].ToString().Trim() == "VariablePayComponent*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[2].ToString().Trim() == "Percentage*")
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
            DataTable dt_empexist = new DataTable();
            DataTable dt_empid = new DataTable();
            DataTable dt_failm = new DataTable();

            dt_failm.Columns.Add("S.NO", typeof(Int32));
            dt_failm.Columns.Add("ROWNO", typeof(Int32));
            dt_failm.Columns.Add("COLUMNS NAMES", typeof(string));
            DataColumn dc = new DataColumn();
            //dc.ColumnName = "Component";
            //dc.DataType = typeof(string);
            //dt_empexist.Columns.Add(dc);

            DataColumn dce0 = new DataColumn();
            dce0.ColumnName = "EmpId";
            dce0.DataType = typeof(string);
            dt_empid.Columns.Add(dce0);

            DataColumn dc1 = new DataColumn();
            dc1.ColumnName = "Percentage";
            dc1.DataType = typeof(double);
            dt_empexist.Columns.Add(dc1);

            DataColumn dc2 = new DataColumn();
            dc2.ColumnName = "Empcode";
            dc2.DataType = typeof(string);
            dt_empexist.Columns.Add(dc2);
            //@@@@@@@@@@@@@@@@@@

            DataTable dt_empexist1 = new DataTable();

            DataColumn dcl2 = new DataColumn();
            dcl2.ColumnName = "Empcode";
            dcl2.DataType = typeof(string);
            dt_empexist1.Columns.Add(dcl2);

            DataColumn dcl1 = new DataColumn();
            dcl1.ColumnName = "Percentage";
            dcl1.DataType = typeof(double);
            dt_empexist1.Columns.Add(dcl1);

            DataColumn dcl3 = new DataColumn();
            dcl3.ColumnName = "ErrorMessage";
            dcl3.DataType = typeof(string);
            dt_empexist1.Columns.Add(dcl3);
            bool varempcomp = false;





            for (int v = 0; v < ds.Tables[0].Rows.Count; v++)
            {
                for (int m = 0; m < ds.Tables[0].Rows.Count; m++)
                {
                    if ((ds.Tables[0].Rows[v]["EmployeeId*"].ToString().Trim() == ds.Tables[0].Rows[m]["EmployeeId*"].ToString().Trim()) && (ds.Tables[0].Rows[v]["VariablePayComponent*"].ToString().Trim() == ds.Tables[0].Rows[m]["VariablePayComponent*"].ToString().Trim()))
                    {
                        if (v != m)
                        {
                            varempcomp = true;
                            errormsg = "VariablePayComponent does not exist";
                            filestatus = false;
                            rowno = v + 2;
                            columnno = "VariablePayComponent*";
                            DataRow newrow = dtfail.NewRow();
                            newrow["S.NO"] = dtfail.Rows.Count + 1;


                            newrow["ROWNO"] = rowno;
                            newrow["COLUMNS NAMES"] = columnno;
                            dtfail.Rows.Add(newrow);
                            ds.Tables[0].Rows[v]["Error Message"] = errormsg;
                        }
                    }
                }

            }
            if (!(varempcomp))
            {


                for (int p = 0; p < ds.Tables[0].Rows.Count; p++)
                {
                    bool found1 = false;
                    int x = 0;
                    int per = 0;
                    DataRow dr = dt_empexist.NewRow();
                    string EMP_CODE1 = string.Empty;

                    // dr[0] = empcomponent;
                    if (ds.Tables[0].Rows[p]["EmployeeId*"].ToString().Trim() != "")
                    {
                        EMP_CODE1 = ds.Tables[0].Rows[p]["EmployeeId*"].ToString().Trim();
                        x = Convert.ToInt32(ds.Tables[0].Rows[p]["Percentage*"]);
                    }
                    for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                    {
                        if (ds.Tables[0].Rows[p]["EmployeeId*"].ToString().Trim() == ds.Tables[0].Rows[k]["EmployeeId*"].ToString().Trim())
                        {
                            if (p != k)
                            {
                                int y = Convert.ToInt32(ds.Tables[0].Rows[k]["Percentage*"]);
                                per = per + y;

                            }
                        }
                    }
                    x = x + per;
                    // compare the existance code which was recorded
                    for (int rowsrepeated = 0; rowsrepeated < dt_empexist.Rows.Count; rowsrepeated++)
                    {
                        if (dt_empexist.Rows[rowsrepeated][1].ToString() == EMP_CODE1)
                        {
                            found1 = true;
                            break;
                        }
                    }
                    if (found1 == false)
                    {
                        dr[0] = x;
                        //  x = x + percentage1;

                        dr[1] = EMP_CODE1;
                        dt_empexist.Rows.Add(dr);
                    }
                }
                for (int b = 0; b < dt_empexist.Rows.Count; b++)
                {
                    errormsg = string.Empty;

                    DataRow dr = dt_empexist1.NewRow();

                    if (Convert.ToInt32(dt_empexist.Rows[b]["Percentage"]) != 100)
                    {
                        filestatus = false;
                        errormsg = "Total Variable Componentpercentage should be 100 for this employee";
                        dr[0] = dt_empexist.Rows[b]["Empcode"].ToString().Trim();
                        dr[1] = Convert.ToInt32(dt_empexist.Rows[b]["Percentage"]);
                        dr[2] = errormsg;
                        dt_empexist1.Rows.Add(dr);

                    }

                }

                for (int msg = 0; msg < dt_empexist1.Rows.Count; msg++)
                {
                    for (int g = 0; g < ds.Tables[0].Rows.Count; g++)
                    {
                        if (dt_empexist1.Rows[msg]["Empcode"].ToString() == ds.Tables[0].Rows[g]["EmployeeId*"].ToString())
                        {
                            errormsg = "Employee Does Not exist";
                            filestatus1 = false;
                            rowno = g + 2;
                            columnno = "EmployeeId*";


                        }
                        if (filestatus1 == false)
                        {
                            DataRow newrow = dt_failm.NewRow();
                            newrow["S.NO"] = dt_failm.Rows.Count + 1;


                            newrow["ROWNO"] = rowno;
                            newrow["COLUMNS NAMES"] = columnno;
                            dt_failm.Rows.Add(newrow);
                            // ds.Tables[0].Rows[i]["Error Message"] = errormsg;
                        }
                        filestatus1 = true;

                    }

                }


                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    bool found = false;
                    errormsg = string.Empty;

                    columnno = string.Empty;

                    //int count = 0;
                    bool EMPCODE_EXISTS = false;
                    if (ds.Tables[0].Rows[i]["EmployeeId*"].ToString().Trim() != "")
                    {


                        // for looping the empcode for checking of the existence of the employee for that businessunit
                        string EMP_CODE = ds.Tables[0].Rows[i]["EmployeeId*"].ToString().Trim();
                        for (int Rows = 0; Rows < dt_Result.Rows.Count; Rows++)
                        {

                            // for checking employee existance whether exel employee is having variable pay or not
                            string EMP_ID = dt_Result.Rows[Rows]["EMP_NAME"].ToString();
                            int CUT = EMP_ID.LastIndexOf("-");
                            string EMP_CODES = EMP_ID.Substring(0, CUT);
                            if (EMP_CODES == EMP_CODE)
                            {

                                // int x = 0;

                                EMPCODE_EXISTS = true;
                            }
                        }
                        if (!(EMPCODE_EXISTS))
                        {
                            errormsg = "Employee Does Not exist";
                            filestatus = false;
                            rowno = i + 2;
                            columnno = "EmployeeId*";

                        }
                    }
                    else
                    {
                        errormsg = "Enter EmployeeId";
                        filestatus = false;
                        rowno = i + 2;
                        columnno = "EmployeeId*";

                    }

                    if (ds.Tables[0].Rows[i]["VariablePayComponent*"].ToString().Trim() != "")
                    {
                        bool varpaycomp1 = false;
                        string empcomponent = ds.Tables[0].Rows[i]["VariablePayComponent*"].ToString().Trim();
                        for (int k = 0; k < dt_resultcomp.Rows.Count; k++)
                        {
                            if (empcomponent == dt_resultcomp.Rows[k]["SMHR_VPCOMP_COMPNAME"].ToString())
                            {

                                varpaycomp1 = true;



                            }
                        }
                        if (varpaycomp1 == false)
                        {
                            errormsg = errormsg + "," + "VariablePayComponent does not exist";
                            filestatus = false;
                            rowno = i + 2;
                            columnno = "VariablePayComponent*";

                        }


                    }
                    else
                    {
                        errormsg = errormsg + "," + "Enter VariablePayComponent ";
                        filestatus = false;
                        rowno = i + 2;
                        columnno = "VariablePayComponent*";

                    }


                    if (ds.Tables[0].Rows[i]["Percentage*"].ToString().Trim() != "")
                    {
                        int VPMIN = 0;
                        int VPMAX = 0;
                        int SMVPCOMP_ID = 0;
                        bool varpaycomp = false;
                        string empcomponent1 = ds.Tables[0].Rows[i]["VariablePayComponent*"].ToString().Trim();
                        int percentage1 = Convert.ToInt32(ds.Tables[0].Rows[i]["Percentage*"].ToString().Trim());


                        for (int k = 0; k < dt_resultcomp.Rows.Count; k++)
                        {
                            if (empcomponent1 == dt_resultcomp.Rows[k]["SMHR_VPCOMP_COMPNAME"].ToString())
                            {
                                SMVPCOMP_ID = Convert.ToInt32(dt_resultcomp.Rows[k]["SMHR_VPCOMP_ID"]);
                                VPMIN = Convert.ToInt32(dt_resultcomp.Rows[k]["SMHR_VPCOMP_MIN"]);
                                VPMAX = Convert.ToInt32(dt_resultcomp.Rows[k]["SMHR_VPCOMP_MAX"]);
                                varpaycomp = true;

                            }
                        }
                        if (!((percentage1 >= VPMIN) && (percentage1 <= VPMAX)))
                        {
                            // string min = dt_resultcomp.Rows[exlrows]["SMHR_VPCOMP_MIN"].ToString();
                            //string max = dt_resultcomp.Rows[exlrows]["SMHR_VPCOMP_MAX"].ToString();
                            errormsg = errormsg + "," + "Percentage you have entered for variable component is out of range:" + "It Should be in Between(" + VPMIN + "," + VPMAX + ")";
                            filestatus = false;
                            rowno = i + 2;
                            columnno = "Percentage*";
                        }


                    }
                    else
                    {
                        errormsg = errormsg + "," + "Enter Percentage  ";
                        filestatus = false;
                        rowno = i + 2;
                        columnno = "Percentage*";

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


            }
            if (dtfail.Rows.Count > 0)
            {
                if (dtfail.Rows[0]["COLUMNS NAMES"].ToString() != string.Empty)
                {
                    //for (int d = 0; d < dtfail.Rows.Count; d++)
                    //{
                    //    for (int c = 0; c < dt_empexist1.Rows.Count; c++)
                    //    {
                    //        if (ds.Tables[0].Rows[d]["EmployeeId*"].ToString().Trim() == dt_empexist1.Rows[c]["Empcode"].ToString().Trim())
                    //        {
                    //            ds.Tables[0].Rows[d]["Error Message"] = ds.Tables[0].Rows[d]["Error Message"].ToString() + "," + dt_empexist1.Rows[c]["ErrorMessage"].ToString();
                    //            //  dtfail.Rows[d]["COLUMNS NAMES"] = dt_failm.Rows[d]["COLUMNS NAMES"].ToString() + dt_failm.Rows[c]["COLUMNS NAMES"].ToString();
                    //        }

                    //    }
                    //}


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
                else if (dtfail.Rows[0]["COLUMNS NAMES"].ToString() == string.Empty)
                {
                    for (int d = 0; d < dtfail.Rows.Count; d++)
                    {
                        for (int c = 0; c < dt_empexist1.Rows.Count; c++)
                        {
                            if (ds.Tables[0].Rows[d]["EmployeeId*"].ToString().Trim() == dt_empexist1.Rows[c]["Empcode"].ToString().Trim())
                            {
                                ds.Tables[0].Rows[d]["Error Message"] = ds.Tables[0].Rows[d]["Error Message"].ToString() + "," + dt_empexist1.Rows[c]["ErrorMessage"].ToString();
                                //  dtfail.Rows[d]["COLUMNS NAMES"] = dt_failm.Rows[d]["COLUMNS NAMES"].ToString() + dt_failm.Rows[c]["COLUMNS NAMES"].ToString();
                            }

                        }
                    }


                    Session["dt_fail"] = dt_failm;
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
            }
            else
            {
                int emp_ID1 = 0;
                bool exists = false;
                bool status = false;
                bool et = false;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    SMHR_EMPLOYEE1 _obj_SMHR_EMPLOYEE1 = new SMHR_EMPLOYEE1();
                    _obj_SMHR_EMPLOYEE1.MODE = 8;
                    _obj_SMHR_EMPLOYEE1.EMP_ID = ds.Tables[0].Rows[i]["EmployeeId*"].ToString().Trim();

                    _obj_SMHR_EMPLOYEE1.ORGID = Convert.ToInt32(Session["ORG_ID"]);

                    DataTable dtempid22 = Pms_Bll.get_Employee1(_obj_SMHR_EMPLOYEE1);
                    if (dtempid22.Rows.Count != 0)
                    {
                        emp_ID1 = Convert.ToInt32(dtempid22.Rows[0]["emp_id"]);
                    }
                    _obj_vamt.EMP_ID = emp_ID1;
                    _obj_vamt.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_vamt.BUID = Convert.ToInt32(rcmb_Businessunit.SelectedValue);
                    _obj_vamt.financial_period = Convert.ToInt32(rcmb_Financialperiod.SelectedValue);
                    _obj_vamt.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_vamt.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    string name = ds.Tables[0].Rows[i]["VariablePayComponent*"].ToString();
                    for (int comp = 0; comp < dt_resultcomp.Rows.Count; comp++)
                    {
                        if (name == dt_resultcomp.Rows[comp]["SMHR_VPCOMP_COMPNAME"].ToString())
                        {
                            _obj_vamt.component_id = Convert.ToInt32(dt_resultcomp.Rows[comp]["SMHR_VPCOMP_ID"].ToString());

                        }
                    }
                    for (int empid = 0; empid < dt_empid.Rows.Count; empid++)
                    {
                        if (emp_ID1 == Convert.ToInt32(dt_empid.Rows[empid][0].ToString()))
                            exists = true;
                    }
                    _obj_vamt.component_percentage = Convert.ToInt32(ds.Tables[0].Rows[i]["Percentage*"]);

                    if (!exists)
                    {
                        _obj_vamt.OPERATION = operation.Delete;
                        et = BLL.set_Component(_obj_vamt);
                    }

                    //_obj_vamt.OPERATION = operation.Insert;
                    _obj_vamt.OPERATION = operation.MODE1;
                    status = BLL.set_Component(_obj_vamt);


                    //DataRow dr = dt_empid.NewRow();
                    //dr[0] = emp_ID1;
                    //dt_empid.Rows.Add(dr);

                }
                if (status == true)
                {
                    BLL.ShowMessage(this, "Employee Components Set for the Selected Employees");
                }

            }




        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ImportEmpcomponents", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            rcmb_Businessunit.SelectedIndex = 0;
            rcmb_Financialperiod.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ImportEmpcomponents", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
}
