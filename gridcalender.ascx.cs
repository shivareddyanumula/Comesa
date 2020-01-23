using System;
using System.Data;
using System.Configuration;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using Telerik.Web.UI;
using System.Collections.Generic;
using SMHR;

public partial class gridcalender : System.Web.UI.UserControl
{

    int i, j;
    SMHR_EMPLOYEE _obj_smhr_employee = new SMHR_EMPLOYEE();
    static string prev_year = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string dt = Convert.ToString(DateTime.Now.Year);
            txtyear.Text = Convert.ToString(dt);
            DataTable table = new DataTable();
            table = GetMainTable(dt);
            RG_leavecalender.DataSource = table;
            SetUnAvailableDays(table, 1);
            SetSundays(table, Convert.ToInt32(dt), 2);
            SetWeekoffs(table, Convert.ToInt32(dt), 4);
            SetHolidys(table, Convert.ToInt32(dt), 8);
            SetLeaves(table, Convert.ToInt32(dt), 10);
            RG_leavecalender.DataBind();
            int month_no=1;
            foreach (GridDataItem dataItem in RG_leavecalender.MasterTableView.Items)
            {
                for (int i = 2; i <= 32; i++)
                {
                    if (dataItem.Cells[i + 3].Text != "&nbsp;" && dataItem.Cells[i + 3].Text != "null")
                    {
                        int cellValue = Convert.ToInt32(dataItem.Cells[i + 3].Text);
                        dataItem.Cells[i + 3].BackColor = GetColorForValue(cellValue);
                        dataItem.Cells[i + 3].ForeColor = Color.White;
                        dataItem.Cells[i + 3].Text = GetText(cellValue, i-1, month_no, dt);
                    }
                }
                month_no++;
            }
            txt1.BackColor = System.Drawing.Color.YellowGreen;
            txt2.BackColor = System.Drawing.Color.Blue;
            txt3.BackColor = System.Drawing.Color.Coral;
            string curr_year = Convert.ToString(DateTime.Now.Year);
            if (txtyear.Text == curr_year)
                btnNext.Enabled = false;
            else
                btnNext.Enabled = true;
            _obj_smhr_employee = new SMHR_EMPLOYEE();
            _obj_smhr_employee.OPERATION = operation.Select;
            _obj_smhr_employee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            //dt_Details = new DataTable();
            _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Details = BLL.get_Employee(_obj_smhr_employee);
            DateTime doj = Convert.ToDateTime(dt_Details.Rows[0]["EMP_DOJ"]);
            prev_year = Convert.ToString(doj.Year);
            if (txtyear.Text == prev_year)
                btnprevious.Enabled = false;
            else
                btnprevious.Enabled = true;
        }
    }

    private string GetText(int cellValue, int i, int month_no, string dt)
    {
        string str = string.Empty;
        if (cellValue == 8)
        {
            DataTable dtinex = new DataTable();
            _obj_smhr_employee = new SMHR_EMPLOYEE();
            _obj_smhr_employee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);// 59;
            _obj_smhr_employee.Mode = 4;
            dtinex = BLL.get_EmpLeaveCalender(_obj_smhr_employee);
            string mon=Convert.ToString(month_no);
            string day=Convert.ToString(i);
            if (mon.Length == 1)
                mon = string.Concat("0", mon);
            if (day.Length == 1)
                day = string.Concat("0", day);
            string date = string.Concat(day,"-", mon,"-", dt);
            for(int index=0;index < dtinex.Rows.Count;index++)
            {
                if (Convert.ToString(date) == Convert.ToString(dtinex.Rows[index]["HOLMST_DATE"]))
                {
                    str = Convert.ToString(dtinex.Rows[index]["HOLMST_CODE"]);
                    break;
                }
            }
        }
        if (cellValue == 10)
        {
            DataTable dtinex1 = new DataTable();
            _obj_smhr_employee = new SMHR_EMPLOYEE();
            _obj_smhr_employee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);//Convert.ToInt32(Session["EMP_ID"]);// 59;
            _obj_smhr_employee.Mode = 5;
            dtinex1 = BLL.get_EmpLeaveCalender(_obj_smhr_employee);
            string mon = Convert.ToString(month_no);
            string day = Convert.ToString(i);
            if (mon.Length == 1)
                mon = string.Concat("0", mon);
            if (day.Length == 1)
                day = string.Concat("0", day);
            string date = string.Concat(day, "-", mon, "-", dt);
            //DateTime dt1 = Convert.ToDateTime(date);
            DateTime dt1 = new DateTime();
            DateTime FromDate = new DateTime();
            DateTime ToDate = new DateTime();

            CultureInfo newCulture = (CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            newCulture.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";
            newCulture.DateTimeFormat.DateSeparator = "-";
            Thread.CurrentThread.CurrentCulture = newCulture;
            dt1 = DateTime.ParseExact(date, "dd/MM/yyyy", null);
            for (int index = 0; index < dtinex1.Rows.Count; index++)
            {
                FromDate = DateTime.ParseExact(Convert.ToString(dtinex1.Rows[index]["LEAVEAPP_FROMDATE"]), "dd/MM/yyyy", null);
                ToDate = DateTime.ParseExact(Convert.ToString(dtinex1.Rows[index]["LEAVEAPP_TODATE"]), "dd/MM/yyyy", null);
                if (Convert.ToDateTime(dt1) >= Convert.ToDateTime(FromDate) && Convert.ToDateTime(dt1) <= Convert.ToDateTime(ToDate))
                {
                    str = Convert.ToString(dtinex1.Rows[index]["LEAVEMASTER_CODE"]);
                    break;
                }
            }
        }

        return str;
    }

    #region Private Methods
    DataTable GetMainTable(string year)
    {
        DataTable table = new DataTable();
        table.Columns.Add("Year");
        table.Columns.Add("MonthNo");
        table.Columns.Add("MonthName");
        for (int day = 1; day <= 31; day++)
        {
            table.Columns.Add(day.ToString());
        }

        DateTime dt = new DateTime();

        for (int month = 1; month <= 12; month++)
        {
            DataRow row = table.NewRow();
            row["Year"] = year;
            row["MonthNo"] = month;
            System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
            row["MonthName"] = mfi.GetMonthName(month).ToString();
            table.Rows.Add(row);
        }
        return table;
    }

    private void SetCellValue(DataTable table, string year, string month, string day, string value)
    {
        DataRow[] rows = table.Select("Year = '" + year + "' and MonthNo = " + month);
        if (rows.Length == 1)
        {
            rows[0][day] = value;
        }
    }

    private void SetEmployeenonworkingdays(DataTable table, string year, string month, string day, string value)
    {
        DataRow[] rows = table.Select("Year = '" + year + "' and MonthNo = " + month);
        if (rows.Length == 1)
        {
            rows[0][day] = value;
        }
    }

    private void SetUnAvailableDays(DataTable table, int value)
    {
        int year = Convert.ToInt32(table.Rows[0][0]);
        int month = 1;
        foreach (DataRow row in table.Rows)
        {
            int daysInMonth = DateTime.DaysInMonth(year, month++);
            for (int day = daysInMonth + 1; day <= 31; day++)
            {
                row[day.ToString()] = value;
            }
        }
    }
    private void SetSundays(DataTable table, int year, int value)
    {
        for (int month = 0; month < 12; month++)
        {
            int[] sundays = GetSundaysInMonth(year, month + 1);
            foreach (int sunday in sundays)
            {
                table.Rows[month][Convert.ToString(sunday)] = value;
            }
        }
    }
    private void SetWeekoffs(DataTable table, int year, int value)
    {
        for (int month = 0; month < 12; month++)
        {
            int[] weekoffs = GetWeekoffs(year, month + 1);
            foreach (int weekoff in weekoffs)
            {
                table.Rows[month][weekoff.ToString()] = value;
                
            }
        }
    }
    private void SetHolidys(DataTable table, int year, int value)
    {
        for (int month = 0; month < 12; month++)
        {
            int[] holiday = GetHolidays(year, month + 1);
            foreach (int holidays in holiday)
            {
                table.Rows[month][holidays.ToString()] = value;
               
            }
        }
    }

    private void SetLeaves(DataTable table, int year, int value)
    {
        for (int month = 0; month < 12; month++)
        {
            int[] holiday = GetLeaves(year, month + 1);
            foreach (int holidays in holiday)
            {
                table.Rows[month][holidays.ToString()] = value;
            }
        }
    }

    private Color GetColorForValue(int value)
    {
        if (value == 1)
        {
            return Color.Gray;
        }
        if (value == 2)
        {
            return Color.Cornsilk;
        }
        if (value == 4)
        {
            return Color.YellowGreen;
        }
        if (value == 8)
        {
            return Color.Blue;
        }
        if (value == 10)
        {
            return Color.Coral;
        }

        return Color.White;
    }

    private int[] GetSundaysInMonth(int year, int month)
    {
        List<int> sundayDays = new List<int>();
        for (int day = 1; day <= DateTime.DaysInMonth(year, month); day++)
        {
            DateTime date = new DateTime(year, month, day);
            if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                sundayDays.Add(day);
            }
        }
        return sundayDays.ToArray();
    }

    private int[] GetWeekoffs(int year, int month)
    {
        DataTable dtinex = new DataTable();
        _obj_smhr_employee = new SMHR_EMPLOYEE();
        _obj_smhr_employee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]); //59;
        _obj_smhr_employee.Mode = 2;
        dtinex = BLL.get_EmpLeaveCalender(_obj_smhr_employee);
        List<int> weekoffs = new List<int>();

        if (dtinex.Rows.Count > 0)
        {
            for (int day = 1; day <= DateTime.DaysInMonth(year, month); day++)
            {
                DateTime date = new DateTime(year, month, day);
                if (date >= Convert.ToDateTime(dtinex.Rows[0][7]))
                {
                    string wkday = date.DayOfWeek.ToString();
                    switch (wkday)
                    {
                        case "Sunday":
                            {
                                if (Convert.ToString(dtinex.Rows[0][0]) == "1")
                                {
                                    weekoffs.Add(day);
                                }
                            }
                            break;
                        case "Monday":
                            {
                                if (Convert.ToString(dtinex.Rows[0][1]) == "2")
                                {
                                    weekoffs.Add(day);
                                }
                            }
                            break;
                        case "Tuesday":
                            {
                                if (Convert.ToString(dtinex.Rows[0][2]) == "3")
                                {
                                    weekoffs.Add(day);
                                }
                            }
                            break;
                        case "Wednesday":
                            {
                                if (Convert.ToString(dtinex.Rows[0][3]) == "4")
                                {
                                    weekoffs.Add(day);
                                }
                            }
                            break;
                        case "Thursday":
                            {
                                if (Convert.ToString(dtinex.Rows[0][4]) == "5")
                                {
                                    weekoffs.Add(day);
                                }
                            }
                            break;
                        case "Friday":
                            {
                                if (Convert.ToString(dtinex.Rows[0][5]) == "6")
                                {
                                    weekoffs.Add(day);
                                }
                            }
                            break;
                        case "Saturday":
                            {
                                if (Convert.ToString(dtinex.Rows[0][6]) == "7")
                                {
                                    weekoffs.Add(day);
                                }
                            }
                            break;
                        default: break;

                    }
                }
            }
        }
        return weekoffs.ToArray();
    }

    private int[] GetHolidays(int year, int month)
    {
        DataTable dtinex = new DataTable();
        _obj_smhr_employee = new SMHR_EMPLOYEE();
        _obj_smhr_employee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);// 59;
        _obj_smhr_employee.Mode = 1;
        dtinex = BLL.get_EmpLeaveCalender(_obj_smhr_employee);

        List<int> holidays = new List<int>();

        for (int day = 1; day <= DateTime.DaysInMonth(year, month); day++)
        {
            for (int h = 0; h <= dtinex.Rows.Count - 1; h++)
            {
                DateTime date = new DateTime(year, month, day);
                if (date.Date.ToString() == dtinex.Rows[h][0].ToString())
                {

                    holidays.Add(day);

                }
            }
        }
        return holidays.ToArray();
    }

    private int[] GetLeaves(int year, int month)
    {
        DataTable dtinex = new DataTable();
        _obj_smhr_employee = new SMHR_EMPLOYEE();
        _obj_smhr_employee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]); //59;
        _obj_smhr_employee.Mode = 3;
        dtinex = BLL.get_EmpLeaveCalender(_obj_smhr_employee);

        List<int> leaves = new List<int>();


        for (int day = 1; day <= DateTime.DaysInMonth(year, month); day++)
        {
            for (int dt = 0; dt <= dtinex.Rows.Count-1; dt++)
            {
                DateTime date = new DateTime(year, month, day);
                if (date.Date.ToString() == dtinex.Rows[dt][0].ToString())
                {

                    leaves.Add(day);

                }
            }
        }
        return leaves.ToArray();
    }


    #endregion
    protected void btnNext_Click(object sender, EventArgs e)
    {
        

    }

    protected void RG_leavecalender_PreRender(object sender, EventArgs e)
    {
        for (int i = 0; i < 31; i++)
        {
            RG_leavecalender.Columns[i + 3].ItemStyle.Width = 15;
        }
    }

    protected void RG_leavecalender_ItemCreated(object sender, GridItemEventArgs e)
    {

    }

    protected void RG_leavecalender_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if ((e.Item is GridDataItem))
        {
            GridDataItem dataItem = (GridDataItem)e.Item;
            for (int i = 0; i < 31; i++)
            {
                if (dataItem.Cells[i + 3].Text != null)
                {
                    int cellValue = Convert.ToInt32(dataItem.Cells[i + 3].Text);
                    dataItem.Cells[i + 3].BackColor = GetColorForValue(cellValue); ;
                }
            }
        }

    }
    protected void btnNext_Click1(object sender, EventArgs e)
    {
        string dt_year = Convert.ToString(DateTime.Now.Year);
        int I_year = Convert.ToInt32(txtyear.Text);
        string yr = Convert.ToString(I_year + 1);
        txtyear.Text = yr;
        DataTable table = GetMainTable(yr);
        RG_leavecalender.DataSource = table;
        SetUnAvailableDays(table, 1);
        SetSundays(table, Convert.ToInt32(yr), 2);
        SetWeekoffs(table, Convert.ToInt32(yr), 4);
        SetHolidys(table, Convert.ToInt32(yr), 8);
        SetLeaves(table, Convert.ToInt32(yr), 10);
        RG_leavecalender.DataBind();
        int month_no = 1;
        foreach (GridDataItem dataItem in RG_leavecalender.MasterTableView.Items)
        {
            for (int i = 2; i <= 32; i++)
            {
                if (dataItem.Cells[i + 3].Text != "&nbsp;" && dataItem.Cells[i + 3].Text != "null")
                {
                    int cellValue = Convert.ToInt32(dataItem.Cells[i + 3].Text);
                    dataItem.Cells[i + 3].BackColor = GetColorForValue(cellValue);
                    dataItem.Cells[i + 3].ForeColor = Color.White;
                    dataItem.Cells[i + 3].Text = GetText(cellValue, i - 1, month_no, yr);
                }
            }
            month_no++;
        }
        txt1.BackColor = System.Drawing.Color.YellowGreen;
        txt2.BackColor = System.Drawing.Color.Blue;
        txt3.BackColor = System.Drawing.Color.Coral;
        string curr_year = Convert.ToString(DateTime.Now.Year);
        if (txtyear.Text == curr_year)
            btnNext.Enabled = false;
        else
            btnNext.Enabled = true;
        if (txtyear.Text == prev_year)
            btnprevious.Enabled = false;
        else
            btnprevious.Enabled = true;
    }
    protected void btnprevious_Click(object sender, EventArgs e)
    {
        string dt_year = Convert.ToString(DateTime.Now.Year);
        int I_year = Convert.ToInt32(txtyear.Text);
        string yr = Convert.ToString(I_year - 1);
        txtyear.Text = yr;
        DataTable table = GetMainTable(yr);
        RG_leavecalender.DataSource = table;
        SetUnAvailableDays(table, 1);
        SetSundays(table, Convert.ToInt32(yr), 2);
        SetWeekoffs(table, Convert.ToInt32(yr), 4);
        SetHolidys(table, Convert.ToInt32(yr), 8);
        SetLeaves(table, Convert.ToInt32(yr), 10);
        RG_leavecalender.DataBind();
        int month_no = 1;
        foreach (GridDataItem dataItem in RG_leavecalender.MasterTableView.Items)
        {
            for (int i = 2; i <= 32; i++)
            {
                if (dataItem.Cells[i + 3].Text != "&nbsp;" && dataItem.Cells[i + 3].Text != "null")
                {
                    int cellValue = Convert.ToInt32(dataItem.Cells[i + 3].Text);
                    dataItem.Cells[i + 3].BackColor = GetColorForValue(cellValue);
                    dataItem.Cells[i + 3].ForeColor = Color.White;
                    dataItem.Cells[i + 3].Text = GetText(cellValue, i - 1, month_no, yr);
                }
            }
            month_no++;
        }
        txt1.BackColor = System.Drawing.Color.YellowGreen;
        txt2.BackColor = System.Drawing.Color.Blue;
        txt3.BackColor = System.Drawing.Color.Coral;
        string curr_year = Convert.ToString(DateTime.Now.Year);
        if (txtyear.Text == curr_year)
            btnNext.Enabled = false;
        else
            btnNext.Enabled = true;
        if (txtyear.Text == prev_year)
            btnprevious.Enabled = false;
        else
            btnprevious.Enabled = true;
    }
    //protected void btnCurrent_Click(object sender, EventArgs e)
    //{
    //    string dt = txtyear.Text;
    //    //txtyear.Text = Convert.ToString(dt);
    //    DataTable table = new DataTable();
    //    table = GetMainTable(dt);
    //    RG_leavecalender.DataSource = table;
    //    SetUnAvailableDays(table, 1);
    //    SetSundays(table, Convert.ToInt32(dt), 2);
    //    SetWeekoffs(table, Convert.ToInt32(dt), 4);
    //    SetHolidys(table, Convert.ToInt32(dt), 8);
    //    SetLeaves(table, Convert.ToInt32(dt), 10);
    //    RG_leavecalender.DataBind();
    //    int month_no = 1;
    //    foreach (GridDataItem dataItem in RG_leavecalender.MasterTableView.Items)
    //    {
    //        for (int i = 2; i <= 32; i++)
    //        {
    //            if (dataItem.Cells[i + 3].Text != "&nbsp;" && dataItem.Cells[i + 3].Text != "null")
    //            {
    //                int cellValue = Convert.ToInt32(dataItem.Cells[i + 3].Text);
    //                dataItem.Cells[i + 3].BackColor = GetColorForValue(cellValue);
    //                dataItem.Cells[i + 3].ForeColor = Color.White;
    //                dataItem.Cells[i + 3].Text = GetText(cellValue, i - 1, month_no, dt);
    //            }
    //        }
    //        month_no++;
    //    }
    //    txt1.BackColor = System.Drawing.Color.YellowGreen;
    //    txt2.BackColor = System.Drawing.Color.Blue;
    //    txt3.BackColor = System.Drawing.Color.Coral;
    //    string curr_year = Convert.ToString(DateTime.Now.Year);
    //    if (txtyear.Text == curr_year)
    //        btnNext.Enabled = false;
    //    else
    //        btnNext.Enabled = true;
    //    _obj_smhr_employee = new SMHR_EMPLOYEE();
    //    _obj_smhr_employee.OPERATION = operation.Select;
    //    _obj_smhr_employee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
    //    //dt_Details = new DataTable();
    //    _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //    DataTable dt_Details = BLL.get_Employee(_obj_smhr_employee);
    //    DateTime doj = Convert.ToDateTime(dt_Details.Rows[0]["EMP_DOJ"]);
    //    prev_year = Convert.ToString(doj.Year);
    //    if (txtyear.Text == prev_year)
    //        btnprevious.Enabled = false;
    //    else
    //        btnprevious.Enabled = true;
    //}
}


