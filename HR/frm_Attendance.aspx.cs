using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using SMHR;
using Microsoft.Office.Interop.Excel;
using System.IO;
using Microsoft.Reporting.WebForms;


public partial class HR_Attendance : System.Web.UI.Page
{

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
                loadDropdown();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Attendance", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


    }

    protected void loadDropdown()
    {
        try
        {
            rcmb_BusinessUnitID.Items.Clear();
            SMHR_ATTENDANCE _obj_Smhr_Attendance = new SMHR_ATTENDANCE();
            _obj_Smhr_Attendance.OPERATION = operation.Empty;

            rcmb_BusinessUnitID.Items.Clear();
            rcmb_BusinessUnitID.DataSource = BLL.get_Attendance(_obj_Smhr_Attendance);
            rcmb_BusinessUnitID.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BusinessUnitID.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BusinessUnitID.DataBind();
            rcmb_BusinessUnitID.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            rcmb_Period.Items.Clear();
            _obj_Smhr_Attendance = new SMHR_ATTENDANCE();
            _obj_Smhr_Attendance.OPERATION = operation.Delete;

            rcmb_Period.Items.Clear();
            rcmb_Period.DataSource = BLL.get_Attendance(_obj_Smhr_Attendance);
            rcmb_Period.DataTextField = "PERIOD_NAME";
            rcmb_Period.DataValueField = "PERIOD_ID";
            rcmb_Period.DataBind();
            rcmb_Period.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            rcmb_PeriodDetails.Items.Clear();
            rcmb_PeriodDetails.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Attendance", ex.StackTrace, DateTime.Now);
        }
    }
    protected void rcmb_Period_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {

        try
        {
            rcmb_PeriodDetails.Items.Clear();
            if (rcmb_Period.SelectedItem.Value != "0")
            {

                SMHR_ATTENDANCE _obj_Smhr_Attendance = new SMHR_ATTENDANCE();
                _obj_Smhr_Attendance.OPERATION = operation.Check;
                _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmb_Period.SelectedItem.Value);

                rcmb_PeriodDetails.Items.Clear();
                rcmb_PeriodDetails.DataSource = BLL.get_Attendance(_obj_Smhr_Attendance);
                rcmb_PeriodDetails.DataTextField = "PRDDTL_NAME";
                rcmb_PeriodDetails.DataValueField = "PRDDTL_ID";
                rcmb_PeriodDetails.DataBind();
                rcmb_PeriodDetails.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
            else
            {
                rcmb_PeriodDetails.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Attendance", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_DownloadSheet_Click(object sender, EventArgs e)
    {
        try
        {
            GenerateExcel();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Attendance", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        //ReportDataSource AttendreportDS = new ReportDataSource("SMHRDataSet_RPT_GENERATEATTENDENCE", BLL.ExecuteQuery("EXEC RPT_GENERATEATTENDENCE  @BUSSINESSUNITID='" + Convert.ToString(rcmb_BusinessUnitID.SelectedItem.Value) + "', @PERIODID='" + Convert.ToString(rcmb_PeriodDetails.SelectedItem.Value) + "'"));
        //rv_GenerateAttendance.LocalReport.ReportPath = @"Report_rdlc\Gen_Attendance.rdlc";
        //rv_GenerateAttendance.LocalReport.DataSources.Clear();
        //rv_GenerateAttendance.LocalReport.DataSources.Add(AttendreportDS);
        //rv_GenerateAttendance.LocalReport.Refresh();

    }
    private void releaseObject(object obj)
    {
        try
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            obj = null;
        }
        catch (Exception)
        {
            obj = null;
        }
        finally
        {
            GC.Collect();
        }
    }

    protected void GenerateExcel()
    {
        try
        {
            LocalReport LocalReport = new LocalReport();
            ReportDataSource reportDS = new ReportDataSource("SMHRDataSet_RPT_GENERATEATTENDENCE", BLL.ExecuteQuery("EXEC RPT_GENERATEATTENDENCE  @BUSSINESSUNITID='" + Convert.ToString(rcmb_BusinessUnitID.SelectedItem.Value) + "', @PERIODID='" + Convert.ToString(rcmb_PeriodDetails.SelectedItem.Value) + "'"));
            LocalReport.ReportPath = @"Report_rdlc\Gen_Attendance.rdlc";
            LocalReport.DataSources.Clear();
            LocalReport.DataSources.Add(reportDS);
            LocalReport.Refresh();


            string reportType = "Excel";
            string mimeType;
            string encoding;
            string fileNameExtension;


            string deviceInfo = "<DeviceInfo>" + " <OutputFormat>Excel</OutputFormat>" + " <PageWidth>8.5in</PageWidth>" + " <PageHeight>11in</PageHeight>" + " <MarginTop>0.3in</MarginTop>" + " <MarginLeft>0.0in</MarginLeft>" + " <MarginRight>0.0in</MarginRight>" + " <MarginBottom>0.3in</MarginBottom>" + "</DeviceInfo>";
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;//Render the report

            renderedBytes = LocalReport.Render(reportType, deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);

            string fileName = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".xls"; // Server.MapPath("~/download") + "\\Attendance.xls";  

            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(renderedBytes);
            bw.Close();

            FileInfo fi = new FileInfo(fileName);
            String tempFileCopy = (Path.Combine(Path.GetTempPath(), "copy_" + Guid.NewGuid().ToString()));
            fi.CopyTo(tempFileCopy, true);

            object misValue = System.Reflection.Missing.Value;
            Application _excelApp = new Application();
            Workbook workBook = _excelApp.Workbooks.Open(tempFileCopy,
                0, false, 5, "", "", false, XlPlatform.xlWindows, "", true, false, 0, true, false, false);

            Worksheet sheet = (Worksheet)workBook.Sheets[1];
            sheet.get_Range("A1", "Z1").UnMerge();


            sheet.get_Range("a1", misValue).FormulaR1C1 = "BUID";
            sheet.get_Range("b1", misValue).FormulaR1C1 = "S. No";
            sheet.get_Range("c1", misValue).FormulaR1C1 = "EMP_ID";
            sheet.get_Range("d1", misValue).FormulaR1C1 = "Employee Code";
            sheet.get_Range("e1", misValue).FormulaR1C1 = "Employee Name";

            sheet.get_Range("a1", misValue).EntireColumn.UseStandardWidth = 0;

            //      sheet.get_Range("a1", misValue).Hidden = true;

            //   sheet.get_Range("a1", "a10").Hidden = true;



            Range a1 = sheet.get_Range("A1", Type.Missing);
            a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, Type.Missing);




            string downAddress = sheet.UsedRange.get_Address(false, false, XlReferenceStyle.xlA1, Type.Missing, Type.Missing);
            Range excelRange = sheet.get_Range("e10", downAddress.Split(new char[] { ':' })[1]);

            excelRange.Validation.Add(XlDVType.xlValidateList, XlDVAlertStyle.xlValidAlertStop, XlFormatConditionOperator.xlBetween, "=$A$2:$A$7", Type.Missing);
            excelRange.Validation.IgnoreBlank = true;
            excelRange.Validation.InputTitle = "Please Enter Any of Following";
            excelRange.Validation.ErrorTitle = "Invalid Information";
            excelRange.Validation.InputMessage = " P – Present \nW – Weekly Off \nA – Absent (No Leave)\n O – Loss of Pay \n H – Holiday \n T – Travel";
            excelRange.Validation.ErrorMessage = "Please select a Valid Information";
            excelRange.Validation.ShowInput = true;
            excelRange.Validation.ShowError = true;
            excelRange.Locked = false;

            sheet.Protect("dhanush", true, true, true, true, true, true, true, false, false, true, false, false, true, true, true);

            String _tempFileCopy = (Path.Combine(Path.GetTempPath(), "copy_" + Guid.NewGuid().ToString() + ".xls"));

            workBook.Protect("", true, false);

            workBook.SaveAs(_tempFileCopy, XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            workBook.Close(true, Type.Missing, Type.Missing);
            _excelApp.Quit();

            releaseObject(_excelApp);
            releaseObject(workBook);
            releaseObject(sheet);

            Response.Redirect("../Reports/DownloadHandler.ashx?fileName=" + rcmb_BusinessUnitID.SelectedItem.Text + "__" + rcmb_PeriodDetails.SelectedItem.Text + ".xls" + "&filePath=" + _tempFileCopy, false);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Attendance", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

   }
