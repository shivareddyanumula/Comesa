using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using Telerik.Web.UI;
using System.Threading;
using System.Globalization;


public partial class Payroll_Default2 : System.Web.UI.Page
{
    SMHR_PAYROLL _obj_smhr_payroll;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_EMPLOYEE _obj_smhr_Employee;
    SMHR_ATTENDANCE _obj_Smhr_Attendance;
    SMHR_PERIODDTL _obj_Smhr_Prddtl;
    RadComboBox rcmbList = null;
    DataTable dt_ds = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                Session.Remove("WRITEFACILITY");
                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("ATTENDANCE");
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
                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    // rg_Attendence.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                }

                loadDropdown();


                //if (ViewState["isDynamic"] != null)
                //{
                //    loadGridNDS();
                //    loadEmployeeNDS();
                //}
            }
            GridView1.PageIndex = 0;
            //ViewState["DT_Employee"] = null;

            //if (ViewState["isDynamic"] != null)
            //{
            //    loadGrid();

            //}
            //  rg_Attendence.ClientSettings.ReorderColumnsOnClient = true;
            //  rg_Attendence.ClientSettings.Scrolling.SaveScrollPosition = false;
            //if (ViewState["isDynamic"] != null)
            //{
            //    UpdatePanel up = new UpdatePanel();
            //    Control ctl = GetPostBackControl(Page);
            //    string str_Ctl = ctl.ID;
            //    DataTable dt_NoOfDays = Dal.ExecuteQuery("SELECT DATEDIFF(DD,PRDDTL_STARTDATE,PRDDTL_ENDDATE)+1 as NoOfDays FROM SMHR_PERIODDETAILS WHERE PRDDTL_ID='" + Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue) + "'");
            //    int I_Days = Convert.ToInt32(dt_NoOfDays.Rows[0][0]);
            //    for (int i = 0; i <= rg_Attendence.Items.Count - 1; i++)
            //    {
            //        for (int I_ColumnCount = 1; I_ColumnCount <= I_Days; I_ColumnCount++)
            //        {
            //            string str_CtlId = (Convert.ToString("rcmbList" + I_ColumnCount));
            //            if (str_Ctl == str_CtlId)
            //            {
            //                up.ContentTemplateContainer.Controls.Add(ctl);
            //                this.Controls.Add(up);
            //            }
            //        }
            //    }
            //}

            //if (ViewState["isDynamic"] != null)
            //{
            //    if (rcmb_AttPeriodElement.SelectedIndex > 0)
            //    {
            //        ViewState["isDynamic"] = Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue);
            //        _obj_Smhr_Attendance = new SMHR_ATTENDANCE();
            //        _obj_Smhr_Attendance.OPERATION = operation.GET_MONTH;
            //        _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_AttBusinessUnit.SelectedItem.Value);
            //        _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue);
            //        DataTable dt_GetMonth = new DataTable();
            //        dt_GetMonth = BLL.get_Attendance(_obj_Smhr_Attendance);

            //        foreach (GridTemplateColumn col in rg_Attendence.Columns)
            //        {
            //            string str_DataField = col.DataField;
            //            if (str_DataField != string.Empty)
            //            {
            //                col.HeaderText = string.Empty;
            //            }
            //        }

            //        for (int I_index = 0; I_index <= dt_GetMonth.Rows.Count + 1; I_index++)
            //        {
            //            string str_HeaderText = rg_Attendence.Columns[I_index].HeaderText;
            //            if (str_HeaderText == string.Empty)
            //            {
            //                string[] str_GetMonth = Convert.ToString(dt_GetMonth.Rows[I_index - 2]["MONTH_ID"]).Split(new char[] { '-' });
            //                rg_Attendence.Columns[I_index].HeaderText = str_GetMonth[0];
            //            }
            //        }

            //        string str_CurrentDate = DateTime.Now.ToShortDateString();
            //        string[] str_Split = str_CurrentDate.Split(new char[] { '/' });
            //        string str_Month = str_Split[0];
            //        string str_Date = str_Split[1];
            //        string str_Year = str_Split[2];
            //        _obj_Smhr_Prddtl = new SMHR_PERIODDTL();
            //        _obj_Smhr_Prddtl.PRDDTL_ID = Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue);
            //        _obj_Smhr_Prddtl.OPERATION = operation.Select;
            //        DataTable dt_Prddtl_EndDate = BLL.get_PeriodDetails(_obj_Smhr_Prddtl);
            //        DateTime DT_Prddtl_EndDate = Convert.ToDateTime(dt_Prddtl_EndDate.Rows[0]["PRDDTL_ENDDATE"]);
            //        string str_Prddtl_EndDate = DT_Prddtl_EndDate.ToShortDateString();
            //        string[] str_Prddtl_EndDateSplit = str_Prddtl_EndDate.Split(new char[] { '/' });
            //        string str_EndMonth = str_Prddtl_EndDateSplit[0];
            //        string str_EndDate = str_Prddtl_EndDateSplit[1];
            //        string str_EndYear = str_Prddtl_EndDateSplit[2];
            //        if (Convert.ToInt32(str_EndYear) < Convert.ToInt32(str_Year))
            //        {
            //            btn_Save.Visible = true;
            //            btn_Finalize.Visible = true;
            //        }
            //        else if (Convert.ToInt32(str_EndYear) == Convert.ToInt32(str_Year))
            //        {
            //            if (Convert.ToInt32(str_EndMonth) <= Convert.ToInt32(str_Month))
            //            {
            //                btn_Save.Visible = true;
            //                btn_Finalize.Visible = true;
            //            }
            //            else
            //            {
            //                btn_Save.Visible = false;
            //                btn_Finalize.Visible = false;
            //            }
            //        }

            //        rg_Attendence.Visible = true;
            //        loadGrid();
            //    }
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Default2", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void loadDropdown()
    {
        try
        {
            rcmb_AttBusinessUnit.Items.Clear();
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            rcmb_AttBusinessUnit.DataSource = dt_BUDetails;
            rcmb_AttBusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_AttBusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            rcmb_AttBusinessUnit.DataBind();
            rcmb_AttBusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

            SMHR_PERIOD _obj_smhr_period = new SMHR_PERIOD();
            DataTable dt_Details = new DataTable();
            _obj_smhr_period.OPERATION = operation.Select;
            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_PeriodHeaderDetails(_obj_smhr_period);
            rcmb_AttPeriod.DataSource = dt_Details;
            rcmb_AttPeriod.DataValueField = "PERIOD_ID";
            rcmb_AttPeriod.DataTextField = "PERIOD_NAME";
            rcmb_AttPeriod.DataBind();
            rcmb_AttPeriod.Items.Insert(0, new RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Default2", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void rcmb_Period_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            _obj_smhr_payroll = new SMHR_PAYROLL();
            _obj_smhr_payroll.PERIODDTLID = Convert.ToInt32(rcmb_AttPeriod.SelectedValue);
            _obj_smhr_payroll.MODE = 28;
            DataTable dt_Details = BLL.get_payrolltrans(_obj_smhr_payroll);
            if (dt_Details.Rows.Count != 0)
            {
                rcmb_AttPeriodElement.DataSource = dt_Details;
                rcmb_AttPeriodElement.DataValueField = "PRDDTL_ID";
                rcmb_AttPeriodElement.DataTextField = "PRDDTL_NAME";
                rcmb_AttPeriodElement.DataBind();
                rcmb_AttPeriodElement.Items.Insert(0, new RadComboBoxItem("Select"));
                tblr_AttPeriodElement.Visible = true;
                ViewState["DT_Employee"] = null;
            }
            else
            {
                rcmb_AttPeriodElement.Items.Clear();
                GridView1.Visible = false;
                btn_Save.Visible = false;
                btn_Finalize.Visible = false;
                //tblr_AttPeriodElement.Visible = false;

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Default2", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void rcmb_AttPeriodElement_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        //rg_Attendence_NeedDataSource(null,null);
        try
        {
            if (rcmb_AttPeriodElement.SelectedIndex > 0)
            {
                ViewState["DT_Employee"] = null;
                ViewState["isDynamic"] = Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue);
                _obj_Smhr_Attendance = new SMHR_ATTENDANCE();
                _obj_Smhr_Attendance.OPERATION = operation.GET_MONTH;
                _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_AttBusinessUnit.SelectedItem.Value);
                _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue);
                DataTable dt_GetMonth = new DataTable();
                dt_GetMonth = BLL.get_Attendance(_obj_Smhr_Attendance);

                //foreach (GridTemplateColumn col in rg_Attendence.Columns)
                //{
                //    string str_DataField = col.DataField;
                //    if (str_DataField != string.Empty)
                //    {
                //        col.HeaderText = string.Empty;
                //    }
                //}

                for (int I_index = 0; I_index <= dt_GetMonth.Rows.Count + 1; I_index++)
                {
                    string str_HeaderText = GridView1.Columns[I_index].HeaderText;
                    if (str_HeaderText == string.Empty)
                    {
                        string[] str_GetMonth = Convert.ToString(dt_GetMonth.Rows[I_index - 2]["MONTH_ID"]).Split(new char[] { '-' });
                        GridView1.Columns[I_index].HeaderText = str_GetMonth[0];
                    }
                }

                //string str_CurrentDate = DateTime.Now.ToShortDateString();
                //string[] str_Split = str_CurrentDate.Split(new char[] { '/' });
                //string str_Month = str_Split[0];
                //string str_Date = str_Split[1];
                //string str_Year = str_Split[2];


                _obj_Smhr_Prddtl = new SMHR_PERIODDTL();
                _obj_Smhr_Prddtl.PRDDTL_ID = Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue);
                _obj_Smhr_Prddtl.OPERATION = operation.Select;
                DataTable dt_Prddtl_EndDate = BLL.get_PeriodDetails(_obj_Smhr_Prddtl);
                DateTime DT_Prddtl_EndDate = Convert.ToDateTime(dt_Prddtl_EndDate.Rows[0]["PRDDTL_ENDDATE"]);

                //string str_Prddtl_EndDate = DT_Prddtl_EndDate.ToShortDateString();

                //string[] str_Prddtl_EndDateSplit = str_Prddtl_EndDate.Split(new char[] { '/' });
                //string str_EndMonth = str_Prddtl_EndDateSplit[0];
                //string str_EndDate = str_Prddtl_EndDateSplit[1];
                //string str_EndYear = str_Prddtl_EndDateSplit[2];

                if (DT_Prddtl_EndDate.Year < DateTime.Now.Year)
                {
                    btn_Save.Visible = true;
                    btn_Finalize.Visible = true;
                }
                else if (DT_Prddtl_EndDate.Year == DateTime.Now.Year)
                {
                    if (Convert.ToInt32(DT_Prddtl_EndDate.Month) <= Convert.ToInt32(DateTime.Now.Month))
                    {
                        btn_Save.Visible = true;
                        btn_Finalize.Visible = true;
                    }
                    else
                    {
                        btn_Save.Visible = false;
                        btn_Finalize.Visible = false;
                    }
                }

                //if (Convert.ToInt32(str_EndYear) < Convert.ToInt32(str_Year))
                //{
                //    btn_Save.Visible = true;
                //    btn_Finalize.Visible = true;
                //}
                //else if (Convert.ToInt32(str_EndYear) == Convert.ToInt32(str_Year))
                //{
                //    if (Convert.ToInt32(str_EndMonth) <= Convert.ToInt32(str_Month))
                //    {
                //        btn_Save.Visible = true;
                //        btn_Finalize.Visible = true;
                //    }
                //    else
                //    {
                //        btn_Save.Visible = false;
                //        btn_Finalize.Visible = false;
                //    }
                //}

                GridView1.Visible = true;
                loadGrid();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Default2", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    public void loadGrid()
    {
        try
        {
            foreach (TemplateField col in GridView1.Columns)
            {
                col.Visible = false;
            }

            DataTable dt_NoOfDays = Dal.ExecuteQuery("SELECT DATEDIFF(DD,PRDDTL_STARTDATE,PRDDTL_ENDDATE)+1 as NoOfDays FROM SMHR_PERIODDETAILS WHERE PRDDTL_ID='" + Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue) + "'");
            int I_Days = Convert.ToInt32(dt_NoOfDays.Rows[0][0]);
            ViewState["No_of_Days"] = I_Days;
            for (int i = 1; i <= I_Days + 1; i++)
            {
                GridView1.Columns[i].Visible = true;

                ////string str = rg_Attendence.Columns[i].UniqueName;
                ////int I_DaysCount = ((I_Days + 1) / 2);
                //if (i <= I_Days + 1)
                ////if (i <= 3)
                //{
                //    rg_Attendence.Columns[i].Visible = true;
                //}
            }
            loadEmployees();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Default2", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void loadEmployees()
    {
        try
        {
            int i;
            int I_PageIndex = 0;
            int I_PageSize = 0;
            int I_dtRow = 0;
            int I_dtRow1 = 0;
            DataTable DT_Employee = new DataTable();
            if (ViewState["DT_Employee"] == null)
            {
                _obj_Smhr_Attendance = new SMHR_ATTENDANCE();
                _obj_Smhr_Attendance.OPERATION = operation.GetAttendance;
                _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_AttBusinessUnit.SelectedItem.Value);
                _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue);
                DT_Employee = BLL.get_Attendance(_obj_Smhr_Attendance);

                if (DT_Employee.Rows.Count != 0)
                {
                    GridView1.DataSource = DT_Employee;
                    GridView1.DataBind();

                    //rg_Attendence.Rebind();

                    //DataTable dt_NoOfDays = Dal.ExecuteQuery("SELECT DATEDIFF(DD,PRDDTL_STARTDATE,PRDDTL_ENDDATE)+1 as NoOfDays FROM SMHR_PERIODDETAILS WHERE PRDDTL_ID='" + Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue) + "'");
                    //int I_Days = Convert.ToInt32(dt_NoOfDays.Rows[0][0]);
                    int I_Days = ViewState["No_of_Days"] != null ? Convert.ToInt32(ViewState["No_of_Days"]) : 0;

                    _obj_Smhr_Attendance = new SMHR_ATTENDANCE();
                    _obj_Smhr_Attendance.OPERATION = operation.GET_MONTH;
                    _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_AttBusinessUnit.SelectedItem.Value);
                    _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue);
                    DataTable dt_GetMonth = new DataTable();
                    dt_GetMonth = BLL.get_Attendance(_obj_Smhr_Attendance);

                    for (i = 0; i <= GridView1.Rows.Count - 1; i++)
                    {
                        for (int I_ColumnCount = 1; I_ColumnCount <= I_Days; I_ColumnCount++)
                        {
                            rcmbList = GridView1.Rows[i].FindControl(Convert.ToString("rcmbList" + I_ColumnCount)) as RadComboBox;

                            int str_ColumnName = Convert.ToInt32(DT_Employee.Columns[I_ColumnCount].ColumnName);
                            string str_CurrentDate = DateTime.Now.ToShortDateString();
                            string[] str_Split = str_CurrentDate.Split(new char[] { '/' });
                            //string str_Month = str_Split[0];
                            string str_Month = Convert.ToString(DateTime.Now.Month);
                            //int str_Date = Convert.ToInt32(str_Split[1]);
                            string date = Convert.ToString(DateTime.Now.Date);
                            int str_Date = Convert.ToInt32(DateTime.Now.Day);
                            //string str_Year = str_Split[2];
                            string str_Year = Convert.ToString(DateTime.Now.Year);

                            //_obj_Smhr_Attendance = new SMHR_ATTENDANCE();
                            //_obj_Smhr_Attendance.OPERATION = operation.GET_MONTH;
                            //_obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_AttBusinessUnit.SelectedItem.Value);
                            //_obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue);
                            //DataTable dt_GetMonth = new DataTable();
                            //dt_GetMonth = BLL.get_Attendance(_obj_Smhr_Attendance);

                            string str_MonthDate = Convert.ToString(dt_GetMonth.Rows[I_ColumnCount - 1]["MONTH_ID"]);

                            string[] str_MonthSplit = str_MonthDate.Split(new char[] { '-' });
                            string str_Monthd = str_MonthSplit[0];
                            string str_Monthm = str_MonthSplit[1];
                            string str_Monthy = str_MonthSplit[2];

                            if (Convert.ToInt32(str_Monthy) < Convert.ToInt32(str_Year))
                            {
                                //if (Convert.ToInt32(str_EndMonth) <= Convert.ToInt32(str_Month))
                                //{
                                //    if (I_ColumnCount <= Convert.ToInt32(str_Date))
                                //    {
                                rcmbList.Enabled = true;
                                Label1.Text = "Insert";
                                //    }
                                //}
                            }
                            else if (Convert.ToInt32(str_Monthy) == Convert.ToInt32(str_Year))
                            {
                                if (Convert.ToInt32(str_Monthm) < Convert.ToInt32(str_Month))
                                {
                                    rcmbList.Enabled = true;
                                    Label1.Text = "Insert";
                                }
                                else if (Convert.ToInt32(str_Monthm) == Convert.ToInt32(str_Month))
                                {
                                    if (I_ColumnCount <= Convert.ToInt32(str_Date))
                                    {
                                        rcmbList.Enabled = true;
                                        Label1.Text = "Insert";
                                    }
                                    else
                                    {
                                        rcmbList.Enabled = false;
                                    }
                                }
                                else
                                {
                                    rcmbList.Enabled = false;
                                }
                            }



                            if (Convert.ToString(Convert.ToString(DT_Employee.Rows[i][I_ColumnCount])).Trim() != "")
                            {
                                string str_Status = Convert.ToString(DT_Employee.Rows[i][I_ColumnCount]);
                                string[] str_StatusSplit = str_Status.Split(new char[] { '-' });
                                string str_EmpStatus = str_StatusSplit[0];

                                string str = Convert.ToString(DT_Employee.Rows[i][I_ColumnCount]);
                                string[] s1 = str.Split(new char[] { '-' });
                                if (s1[1] == "1")
                                {
                                    rcmbList.Enabled = false;
                                }
                                else
                                {
                                    Label1.Text = "Update";
                                }

                                rcmbList.SelectedIndex = rcmbList.FindItemIndexByValue(str_EmpStatus.Trim());

                                if (Convert.ToString(Convert.ToString(str_EmpStatus)).Trim() == "P")
                                {
                                    rcmbList.SelectedIndex = rcmbList.FindItemIndexByValue(Convert.ToString("P"));
                                }
                                else if (Convert.ToString(Convert.ToString(str_EmpStatus)).Trim() == "A")
                                {
                                    rcmbList.SelectedIndex = rcmbList.FindItemIndexByValue(Convert.ToString("A"));

                                }
                                else if (Convert.ToString(Convert.ToString(str_EmpStatus)).Trim() == "L")
                                {
                                    rcmbList.SelectedIndex = rcmbList.FindItemIndexByValue(Convert.ToString("L"));
                                }
                                else if (Convert.ToString(Convert.ToString(str_EmpStatus)).Trim() == "W")
                                {
                                    rcmbList.SelectedIndex = rcmbList.FindItemIndexByValue(Convert.ToString("W"));
                                }
                                else if (Convert.ToString(Convert.ToString(str_EmpStatus)).Trim() == "T")
                                {
                                    rcmbList.SelectedIndex = rcmbList.FindItemIndexByValue(Convert.ToString("T"));
                                }
                                else if (Convert.ToString(Convert.ToString(str_EmpStatus)).Trim() == "C")
                                {
                                    rcmbList.SelectedIndex = rcmbList.FindItemIndexByValue(Convert.ToString("C"));
                                }
                                else if (Convert.ToString(Convert.ToString(str_EmpStatus)).Trim() == "H")
                                {
                                    rcmbList.SelectedIndex = rcmbList.FindItemIndexByValue(Convert.ToString("H"));
                                }
                                else if (Convert.ToString(Convert.ToString(str_EmpStatus)).Trim() == "HD")
                                {
                                    rcmbList.SelectedIndex = rcmbList.FindItemIndexByValue(Convert.ToString("HD"));
                                }
                                else if (Convert.ToString(Convert.ToString(str_EmpStatus)).Trim() == "HDL")
                                {
                                    rcmbList.SelectedIndex = rcmbList.FindItemIndexByValue(Convert.ToString("HDL"));
                                }


                            }
                            else if (Convert.ToString(Convert.ToString(DT_Employee.Rows[i][I_ColumnCount])).Trim() == "")
                            {
                                rcmbList.Enabled = false;
                                rcmbList.SelectedIndex = 1;

                            }
                            else
                            {
                                rcmbList.SelectedIndex = 1;
                                string str_CurrentDate1 = DateTime.Now.ToShortDateString();
                                string[] str_Split1 = str_CurrentDate1.Split(new char[] { '/' });
                                //string str_Date1 = str_Split1[1];
                                string str_Date1 = Convert.ToString(DateTime.Now.Day);
                                if (Convert.ToInt32(I_ColumnCount) > Convert.ToInt32(str_Date1))
                                {
                                    rcmbList.Enabled = false;
                                }
                            }



                        }
                    }
                }
                //if datatable is empty
                else
                {
                    _obj_Smhr_Attendance.OPERATION = operation.Check1;
                    DT_Employee = BLL.get_Attendance(_obj_Smhr_Attendance);
                    if (DT_Employee.Rows.Count != 0)
                    {

                        GridView1.DataSource = DT_Employee;
                        GridView1.DataBind();
                        //rg_Attendence.Rebind();
                        string str_CurrentDate = DateTime.Now.ToShortDateString();
                        string[] str_Split = str_CurrentDate.Split(new char[] { '/' });
                        //string str_Month = str_Split[0];
                        string str_Month = Convert.ToString(DateTime.Now.Month);
                        //string str_Date = str_Split[1];
                        string date = Convert.ToString(DateTime.Now.Date);
                        int str_Date = Convert.ToInt32(DateTime.Now.Day);
                        //string str_Year = str_Split[2];
                        string str_Year = Convert.ToString(DateTime.Now.Year);

                        _obj_Smhr_Prddtl = new SMHR_PERIODDTL();
                        _obj_Smhr_Prddtl.PRDDTL_ID = Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue);
                        _obj_Smhr_Prddtl.OPERATION = operation.Select;
                        DataTable dt_Prddtl_EndDate = BLL.get_PeriodDetails(_obj_Smhr_Prddtl);
                        DateTime DT_Prddtl_EndDate = Convert.ToDateTime(dt_Prddtl_EndDate.Rows[0]["PRDDTL_ENDDATE"]);
                        string str_Prddtl_EndDate = DT_Prddtl_EndDate.ToShortDateString();
                        string[] str_Prddtl_EndDateSplit = str_Prddtl_EndDate.Split(new char[] { '/' });
                        string str_EndMonth = str_Prddtl_EndDateSplit[0];
                        string str_EndDate = str_Prddtl_EndDateSplit[1];
                        string str_EndYear = str_Prddtl_EndDateSplit[2];

                        DataTable dt_NoOfDays = Dal.ExecuteQuery("SELECT DATEDIFF(DD,PRDDTL_STARTDATE,PRDDTL_ENDDATE)+1 as NoOfDays FROM SMHR_PERIODDETAILS WHERE PRDDTL_ID='" + Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue) + "'");
                        int I_Days = Convert.ToInt32(dt_NoOfDays.Rows[0][0]);
                        for (i = 0; i <= GridView1.Rows.Count - 1; i++)
                        {
                            for (int I_ColumnCount = 1; I_ColumnCount <= I_Days; I_ColumnCount++)
                            {
                                _obj_Smhr_Attendance.OPERATION = operation.GET_MONTH;
                                _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_AttBusinessUnit.SelectedItem.Value);
                                _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue);
                                DataTable dt_GetMonth_ = new DataTable();
                                dt_GetMonth_ = BLL.get_Attendance(_obj_Smhr_Attendance);
                                string[] str_Get_Month = Convert.ToString(dt_GetMonth_.Rows[I_ColumnCount - 1]["MONTH_ID"]).Split(new char[] { '-' });
                                string str_PeriodElementDate = str_Get_Month[0];
                                string str_PeriodElementMonth = str_Get_Month[1];
                                string str_PeriodYear = str_Get_Month[2];
                                string str_Check = Convert.ToString(DT_Employee.Rows[i][I_ColumnCount]);
                                rcmbList = GridView1.Rows[i].FindControl(Convert.ToString("rcmbList" + I_ColumnCount)) as RadComboBox;
                                rcmbList.Enabled = false;
                                if (Convert.ToInt32(str_EndYear) < Convert.ToInt32(str_Year))
                                {
                                    //if (Convert.ToInt32(str_EndMonth) <= Convert.ToInt32(str_Month))
                                    //{
                                    //    if (I_ColumnCount <= Convert.ToInt32(str_Date))
                                    //    {
                                    rcmbList.Enabled = true;
                                    Label1.Text = "Insert";
                                    //    }
                                    //}
                                }
                                else if (Convert.ToInt32(str_EndYear) == Convert.ToInt32(str_Year))
                                {
                                    if (Convert.ToInt32(str_EndMonth) < Convert.ToInt32(str_Month))
                                    {
                                        rcmbList.Enabled = true;
                                        Label1.Text = "Insert";
                                    }
                                    else if (Convert.ToInt32(str_EndMonth) == Convert.ToInt32(str_Month))
                                    {
                                        if (I_ColumnCount <= Convert.ToInt32(str_Date))
                                        {
                                            rcmbList.Enabled = true;
                                            Label1.Text = "Insert";
                                        }
                                    }
                                }

                                if (Convert.ToString(Convert.ToString(DT_Employee.Rows[i][Convert.ToString(str_PeriodElementDate)])).Trim() != "")
                                {
                                    if (Convert.ToString(Convert.ToString(DT_Employee.Rows[i][Convert.ToString(str_PeriodElementDate)])).Trim() == "0")
                                    {
                                        rcmbList.SelectedIndex = rcmbList.FindItemIndexByValue(Convert.ToString("P"));
                                    }
                                    else if (Convert.ToString(Convert.ToString(DT_Employee.Rows[i][Convert.ToString(str_PeriodElementDate)])).Trim() == "1")
                                    {
                                        rcmbList.SelectedIndex = rcmbList.FindItemIndexByValue(Convert.ToString("L"));
                                    }
                                    else if (Convert.ToString(Convert.ToString(DT_Employee.Rows[i][Convert.ToString(str_PeriodElementDate)])).Trim() == "2")
                                    {
                                        rcmbList.SelectedIndex = rcmbList.FindItemIndexByValue(Convert.ToString("W"));
                                    }
                                    else if (Convert.ToString(Convert.ToString(DT_Employee.Rows[i][Convert.ToString(str_PeriodElementDate)])).Trim() == "3")
                                    {
                                        rcmbList.SelectedIndex = rcmbList.FindItemIndexByValue(Convert.ToString("H"));
                                    }
                                }
                                else
                                {
                                    rcmbList.Enabled = true;
                                    rcmbList.SelectedIndex = 1;
                                }
                            }
                        }
                    }
                }
                ViewState["DT_Employee"] = DT_Employee;

            }

                // if paging
            else
            {
                DT_Employee = (DataTable)ViewState["DT_Employee"];
                I_PageIndex = GridView1.PageIndex;
                I_PageSize = GridView1.PageSize;
                I_dtRow = (I_PageIndex * I_PageSize);
                I_dtRow1 = (I_PageIndex * I_PageSize) + 1;
                if (DT_Employee.Rows.Count != 0)
                {
                    GridView1.DataSource = DT_Employee;
                    GridView1.DataBind();

                    //rg_Attendence.Rebind();

                    //DataTable dt_NoOfDays = Dal.ExecuteQuery("SELECT DATEDIFF(DD,PRDDTL_STARTDATE,PRDDTL_ENDDATE)+1 as NoOfDays FROM SMHR_PERIODDETAILS WHERE PRDDTL_ID='" + Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue) + "'");
                    //int I_Days = Convert.ToInt32(dt_NoOfDays.Rows[0][0]);
                    int I_Days = ViewState["No_of_Days"] != null ? Convert.ToInt32(ViewState["No_of_Days"]) : 0;

                    _obj_Smhr_Attendance = new SMHR_ATTENDANCE();
                    _obj_Smhr_Attendance.OPERATION = operation.GET_MONTH;
                    _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_AttBusinessUnit.SelectedItem.Value);
                    _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue);
                    DataTable dt_GetMonth = new DataTable();
                    dt_GetMonth = BLL.get_Attendance(_obj_Smhr_Attendance);

                    for (i = 0; i <= GridView1.Rows.Count - 1; i++)
                    {
                        for (int I_ColumnCount = 1; I_ColumnCount <= I_Days; I_ColumnCount++)
                        {
                            rcmbList = GridView1.Rows[i].FindControl(Convert.ToString("rcmbList" + I_ColumnCount)) as RadComboBox;

                            int str_ColumnName = Convert.ToInt32(DT_Employee.Columns[I_ColumnCount].ColumnName);
                            string str_CurrentDate = DateTime.Now.ToShortDateString();
                            string[] str_Split = str_CurrentDate.Split(new char[] { '/' });
                            //string str_Month = str_Split[0];
                            string str_Month = Convert.ToString(DateTime.Now.Month);
                            //int str_Date = Convert.ToInt32(str_Split[1]);
                            string date = Convert.ToString(DateTime.Now.Date);
                            int str_Date = Convert.ToInt32(DateTime.Now.Day);
                            //string str_Year = str_Split[2];
                            string str_Year = Convert.ToString(DateTime.Now.Year);

                            //_obj_Smhr_Attendance = new SMHR_ATTENDANCE();
                            //_obj_Smhr_Attendance.OPERATION = operation.GET_MONTH;
                            //_obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_AttBusinessUnit.SelectedItem.Value);
                            //_obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue);
                            //DataTable dt_GetMonth = new DataTable();
                            //dt_GetMonth = BLL.get_Attendance(_obj_Smhr_Attendance);

                            string str_MonthDate = Convert.ToString(dt_GetMonth.Rows[I_ColumnCount - 1]["MONTH_ID"]);

                            string[] str_MonthSplit = str_MonthDate.Split(new char[] { '-' });
                            string str_Monthd = str_MonthSplit[0];
                            string str_Monthm = str_MonthSplit[1];
                            string str_Monthy = str_MonthSplit[2];

                            if (Convert.ToInt32(str_Monthy) < Convert.ToInt32(str_Year))
                            {
                                //if (Convert.ToInt32(str_EndMonth) <= Convert.ToInt32(str_Month))
                                //{
                                //    if (I_ColumnCount <= Convert.ToInt32(str_Date))
                                //    {
                                rcmbList.Enabled = true;
                                Label1.Text = "Insert";
                                //    }
                                //}
                            }
                            else if (Convert.ToInt32(str_Monthy) == Convert.ToInt32(str_Year))
                            {
                                if (Convert.ToInt32(str_Monthm) < Convert.ToInt32(str_Month))
                                {
                                    rcmbList.Enabled = true;
                                    Label1.Text = "Insert";
                                }
                                else if (Convert.ToInt32(str_Monthm) == Convert.ToInt32(str_Month))
                                {
                                    if (I_ColumnCount <= Convert.ToInt32(str_Date))
                                    {
                                        rcmbList.Enabled = true;
                                        Label1.Text = "Insert";
                                    }
                                    else
                                    {
                                        rcmbList.Enabled = false;
                                    }
                                }
                                else
                                {
                                    rcmbList.Enabled = false;
                                }
                            }


                            //for (I_dtRow = I_dtRow1; I_dtRow <= 5; I_dtRow++)
                            //{
                            //    for (I_ColumnCount = 1; I_ColumnCount <= I_Days; I_ColumnCount++)
                            //    {
                            if (Convert.ToString(Convert.ToString(DT_Employee.Rows[I_dtRow][I_ColumnCount])).Trim() != "")
                            {
                                string str_Status = Convert.ToString(DT_Employee.Rows[I_dtRow][I_ColumnCount]);
                                string[] str_StatusSplit = str_Status.Split(new char[] { '-' });
                                string str_EmpStatus = str_StatusSplit[0];

                                string str = Convert.ToString(DT_Employee.Rows[I_dtRow][I_ColumnCount]);
                                string[] s1 = str.Split(new char[] { '-' });
                                if (s1[1] == "1")
                                {
                                    rcmbList.Enabled = false;
                                }
                                else
                                {
                                    Label1.Text = "Update";
                                }

                                rcmbList.SelectedIndex = rcmbList.FindItemIndexByValue(str_EmpStatus.Trim());

                                if (Convert.ToString(Convert.ToString(str_EmpStatus)).Trim() == "P")
                                {
                                    rcmbList.SelectedIndex = rcmbList.FindItemIndexByValue(Convert.ToString("P"));
                                }
                                else if (Convert.ToString(Convert.ToString(str_EmpStatus)).Trim() == "A")
                                {
                                    rcmbList.SelectedIndex = rcmbList.FindItemIndexByValue(Convert.ToString("A"));

                                }
                                else if (Convert.ToString(Convert.ToString(str_EmpStatus)).Trim() == "L")
                                {
                                    rcmbList.SelectedIndex = rcmbList.FindItemIndexByValue(Convert.ToString("L"));
                                }
                                else if (Convert.ToString(Convert.ToString(str_EmpStatus)).Trim() == "W")
                                {
                                    rcmbList.SelectedIndex = rcmbList.FindItemIndexByValue(Convert.ToString("W"));
                                }
                                else if (Convert.ToString(Convert.ToString(str_EmpStatus)).Trim() == "T")
                                {
                                    rcmbList.SelectedIndex = rcmbList.FindItemIndexByValue(Convert.ToString("T"));
                                }
                                else if (Convert.ToString(Convert.ToString(str_EmpStatus)).Trim() == "C")
                                {
                                    rcmbList.SelectedIndex = rcmbList.FindItemIndexByValue(Convert.ToString("C"));
                                }
                                else if (Convert.ToString(Convert.ToString(str_EmpStatus)).Trim() == "H")
                                {
                                    rcmbList.SelectedIndex = rcmbList.FindItemIndexByValue(Convert.ToString("H"));
                                }
                                else if (Convert.ToString(Convert.ToString(str_EmpStatus)).Trim() == "HD")
                                {
                                    rcmbList.SelectedIndex = rcmbList.FindItemIndexByValue(Convert.ToString("HD"));
                                }
                                else if (Convert.ToString(Convert.ToString(str_EmpStatus)).Trim() == "HDL")
                                {
                                    rcmbList.SelectedIndex = rcmbList.FindItemIndexByValue(Convert.ToString("HDL"));
                                }


                            }
                            else if (Convert.ToString(Convert.ToString(DT_Employee.Rows[I_dtRow][I_ColumnCount])).Trim() == "")
                            {
                                rcmbList.Enabled = false;
                                rcmbList.SelectedIndex = 1;

                            }
                            else
                            {
                                rcmbList.SelectedIndex = 1;
                                string str_CurrentDate1 = DateTime.Now.ToShortDateString();
                                string[] str_Split1 = str_CurrentDate1.Split(new char[] { '/' });
                                //string str_Date1 = str_Split1[1];
                                string str_Date1 = Convert.ToString(DateTime.Now.Day);
                                if (Convert.ToInt32(I_ColumnCount) > Convert.ToInt32(str_Date1))
                                {
                                    rcmbList.Enabled = false;
                                }
                            }
                            //    }
                            //}


                        }
                        I_dtRow++;
                    }
                }
                //if datatable is empty
                else
                {
                    _obj_Smhr_Attendance.OPERATION = operation.Check1;
                    DT_Employee = BLL.get_Attendance(_obj_Smhr_Attendance);
                    if (DT_Employee.Rows.Count != 0)
                    {

                        GridView1.DataSource = DT_Employee;
                        GridView1.DataBind();
                        //rg_Attendence.Rebind();
                        string str_CurrentDate = DateTime.Now.ToShortDateString();
                        string[] str_Split = str_CurrentDate.Split(new char[] { '/' });
                        //string str_Month = str_Split[0];
                        string str_Month = Convert.ToString(DateTime.Now.Month);
                        //string str_Date = str_Split[1];
                        string date = Convert.ToString(DateTime.Now.Date);
                        int str_Date = Convert.ToInt32(DateTime.Now.Day);
                        //string str_Year = str_Split[2];
                        string str_Year = Convert.ToString(DateTime.Now.Year);

                        _obj_Smhr_Prddtl = new SMHR_PERIODDTL();
                        _obj_Smhr_Prddtl.PRDDTL_ID = Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue);
                        _obj_Smhr_Prddtl.OPERATION = operation.Select;
                        DataTable dt_Prddtl_EndDate = BLL.get_PeriodDetails(_obj_Smhr_Prddtl);
                        DateTime DT_Prddtl_EndDate = Convert.ToDateTime(dt_Prddtl_EndDate.Rows[0]["PRDDTL_ENDDATE"]);
                        string str_Prddtl_EndDate = DT_Prddtl_EndDate.ToShortDateString();
                        string[] str_Prddtl_EndDateSplit = str_Prddtl_EndDate.Split(new char[] { '/' });
                        string str_EndMonth = str_Prddtl_EndDateSplit[0];
                        string str_EndDate = str_Prddtl_EndDateSplit[1];
                        string str_EndYear = str_Prddtl_EndDateSplit[2];

                        DataTable dt_NoOfDays = Dal.ExecuteQuery("SELECT DATEDIFF(DD,PRDDTL_STARTDATE,PRDDTL_ENDDATE)+1 as NoOfDays FROM SMHR_PERIODDETAILS WHERE PRDDTL_ID='" + Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue) + "'");
                        int I_Days = Convert.ToInt32(dt_NoOfDays.Rows[0][0]);
                        for (i = 0; i <= GridView1.Rows.Count - 1; i++)
                        {
                            for (int I_ColumnCount = 1; I_ColumnCount <= I_Days; I_ColumnCount++)
                            {
                                _obj_Smhr_Attendance.OPERATION = operation.GET_MONTH;
                                _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_AttBusinessUnit.SelectedItem.Value);
                                _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue);
                                DataTable dt_GetMonth_ = new DataTable();
                                dt_GetMonth_ = BLL.get_Attendance(_obj_Smhr_Attendance);
                                string[] str_Get_Month = Convert.ToString(dt_GetMonth_.Rows[I_ColumnCount - 1]["MONTH_ID"]).Split(new char[] { '-' });
                                string str_PeriodElementDate = str_Get_Month[0];
                                string str_PeriodElementMonth = str_Get_Month[1];
                                string str_PeriodYear = str_Get_Month[2];
                                string str_Check = Convert.ToString(DT_Employee.Rows[i][I_ColumnCount]);
                                rcmbList = GridView1.Rows[i].FindControl(Convert.ToString("rcmbList" + I_ColumnCount)) as RadComboBox;
                                rcmbList.Enabled = false;
                                if (Convert.ToInt32(str_EndYear) < Convert.ToInt32(str_Year))
                                {
                                    //if (Convert.ToInt32(str_EndMonth) <= Convert.ToInt32(str_Month))
                                    //{
                                    //    if (I_ColumnCount <= Convert.ToInt32(str_Date))
                                    //    {
                                    rcmbList.Enabled = true;
                                    Label1.Text = "Insert";
                                    //    }
                                    //}
                                }
                                else if (Convert.ToInt32(str_EndYear) == Convert.ToInt32(str_Year))
                                {
                                    if (Convert.ToInt32(str_EndMonth) < Convert.ToInt32(str_Month))
                                    {
                                        rcmbList.Enabled = true;
                                        Label1.Text = "Insert";
                                    }
                                    else if (Convert.ToInt32(str_EndMonth) == Convert.ToInt32(str_Month))
                                    {
                                        if (I_ColumnCount <= Convert.ToInt32(str_Date))
                                        {
                                            rcmbList.Enabled = true;
                                            Label1.Text = "Insert";
                                        }
                                    }
                                }

                                if (Convert.ToString(Convert.ToString(DT_Employee.Rows[I_dtRow][Convert.ToString(str_PeriodElementDate)])).Trim() != "")
                                {
                                    if (Convert.ToString(Convert.ToString(DT_Employee.Rows[I_dtRow][Convert.ToString(str_PeriodElementDate)])).Trim() == "0")
                                    {
                                        rcmbList.SelectedIndex = rcmbList.FindItemIndexByValue(Convert.ToString("P"));
                                    }
                                    else if (Convert.ToString(Convert.ToString(DT_Employee.Rows[I_dtRow][Convert.ToString(str_PeriodElementDate)])).Trim() == "1")
                                    {
                                        rcmbList.SelectedIndex = rcmbList.FindItemIndexByValue(Convert.ToString("L"));
                                    }
                                    else if (Convert.ToString(Convert.ToString(DT_Employee.Rows[I_dtRow][Convert.ToString(str_PeriodElementDate)])).Trim() == "2")
                                    {
                                        rcmbList.SelectedIndex = rcmbList.FindItemIndexByValue(Convert.ToString("W"));
                                    }
                                    else if (Convert.ToString(Convert.ToString(DT_Employee.Rows[I_dtRow][Convert.ToString(str_PeriodElementDate)])).Trim() == "3")
                                    {
                                        rcmbList.SelectedIndex = rcmbList.FindItemIndexByValue(Convert.ToString("H"));
                                    }
                                }
                                else
                                {
                                    rcmbList.Enabled = true;
                                    rcmbList.SelectedIndex = 1;
                                }
                            }
                        }
                    }
                }
            }



        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Default2", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void rcmb_AttBusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            GridView1.Visible = false;
            rcmb_AttPeriod.SelectedIndex = 0;
            rcmb_AttPeriodElement.Items.Clear();
            btn_Save.Visible = false;
            btn_Finalize.Visible = false;
            ViewState["DT_Employee"] = null;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Default2", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView1.PageIndex = e.NewPageIndex;
            ViewState["page_index"] = e.NewPageIndex;
            loadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Default2", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {


            bool status = false;
            string str_PeriodElementMonth = null;
            string str_PeriodYear = null;
            string str_CurrentDate = DateTime.Now.ToShortDateString();
            string[] str_Split = str_CurrentDate.Split(new char[] { '/' });
            //string str_Date = str_Split[1];
            string str_Date = Convert.ToString(DateTime.Now.Day);
            _obj_Smhr_Attendance = new SMHR_ATTENDANCE();
            DataTable dt_NoOfDays1 = Dal.ExecuteQuery("SELECT DATEDIFF(DD,PRDDTL_STARTDATE,PRDDTL_ENDDATE)+1 as NoOfDays FROM SMHR_PERIODDETAILS WHERE PRDDTL_ID='" + Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue) + "'");
            int I_Days1 = Convert.ToInt32(dt_NoOfDays1.Rows[0][0]);

            Label lbl_Empid = null; //new Label();
            for (int I_GridCount = 0; I_GridCount <= GridView1.Rows.Count - 1; I_GridCount++)
            {
                lbl_Empid = GridView1.Rows[I_GridCount].FindControl("lbl_Empid") as Label;
                for (int I_GridColCount = 1; I_GridColCount <= Convert.ToInt32(I_Days1); I_GridColCount++)
                {
                    string str_month = Convert.ToString("rcmbList" + I_GridColCount);
                    rcmbList = GridView1.Rows[I_GridCount].FindControl(Convert.ToString("rcmbList" + I_GridColCount)) as RadComboBox;
                    if (!rcmbList.Enabled)
                    {
                        string str_ID = rcmbList.ID;
                    }
                }
            }

            for (int I_GridCount = 0; I_GridCount <= GridView1.Rows.Count - 1; I_GridCount++)
            {
                lbl_Empid = GridView1.Rows[I_GridCount].FindControl("lbl_Empid") as Label;
                for (int I_GridColCount = 1; I_GridColCount <= Convert.ToInt32(I_Days1); I_GridColCount++)
                {
                    _obj_Smhr_Attendance = new SMHR_ATTENDANCE();
                    _obj_Smhr_Attendance.OPERATION = operation.GET_MONTH;
                    _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_AttBusinessUnit.SelectedItem.Value);
                    _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue);
                    DataTable dt_GetMonth = new DataTable();
                    dt_GetMonth = BLL.get_Attendance(_obj_Smhr_Attendance);
                    string[] str_Get_Month = Convert.ToString(dt_GetMonth.Rows[I_GridColCount - 1]["MONTH_ID"]).Split(new char[] { '-' });
                    str_PeriodElementMonth = str_Get_Month[1];
                    str_PeriodYear = str_Get_Month[2];
                    string str_month = Convert.ToString("rcmbList" + I_GridColCount);
                    rcmbList = GridView1.Rows[I_GridCount].FindControl(Convert.ToString("rcmbList" + I_GridColCount)) as RadComboBox;
                    string str_DayCount = GridView1.Columns[I_GridColCount + 1].HeaderText;
                    //DateTime str_Attendance = Convert.ToDateTime(dt_GetMonth.Rows[I_GridColCount - 1]["MONTH_ID"] + " " + Convert.ToString(DateTime.Now.ToLongTimeString()));
                    string sysFormat = Convert.ToString(CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
                    string str_Attendance = string.Empty;
                    if (sysFormat == "MM/dd/yyyy")
                    {
                        str_Attendance = str_PeriodElementMonth + "/" + str_DayCount + "/" + str_PeriodYear + " " + Convert.ToString(DateTime.Now.ToLongTimeString());
                    }
                    else if (sysFormat == "dd/MM/yyyy")
                    {
                        str_Attendance = str_DayCount + "/" + str_PeriodElementMonth + "/" + str_PeriodYear + " " + Convert.ToString(DateTime.Now.ToLongTimeString());
                    }
                    switch (((Button)sender).ID.ToUpper())
                    {
                        case "BTN_SAVE":
                            _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_AttBusinessUnit.SelectedValue);
                            _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue);
                            _obj_Smhr_Attendance.ATTENDANCE_DATE = Convert.ToDateTime(str_Attendance);
                            _obj_Smhr_Attendance.ATTENDANCE_EMP_ID = Convert.ToInt32(lbl_Empid.Text);
                            _obj_Smhr_Attendance.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Smhr_Attendance.OPERATION = operation.Validate;
                            DataTable dt_ChkAttendance = BLL.get_Attendance(_obj_Smhr_Attendance);
                            if (dt_ChkAttendance.Rows.Count != 0)
                            {
                                if (Convert.ToString(dt_ChkAttendance.Rows[0]["ATTENDANCE_FINALIZE"]) == "1")
                                {

                                }
                                else
                                {
                                    _obj_Smhr_Attendance.OPERATION = operation.Update;
                                    _obj_Smhr_Attendance.ATTENDANCE_MODE = true;
                                    _obj_Smhr_Attendance.ATTENDANCE_FINALIZE = 0;
                                    _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_AttBusinessUnit.SelectedValue);
                                    _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue);
                                    _obj_Smhr_Attendance.ATTENDANCE_DATE = Convert.ToDateTime(str_Attendance);
                                    _obj_Smhr_Attendance.ATTENDANCE_EMP_ID = Convert.ToInt32(lbl_Empid.Text);
                                    _obj_Smhr_Attendance.ATTENDANCE_STATUS = Convert.ToString(rcmbList.SelectedValue);
                                    _obj_Smhr_Attendance.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                    if (BLL.set_Attendance(_obj_Smhr_Attendance))
                                    {
                                        status = true;

                                    }
                                    else
                                    {
                                        status = false;
                                    }
                                }
                            }
                            else
                            {
                                _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_AttBusinessUnit.SelectedValue);
                                _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue);
                                _obj_Smhr_Attendance.ATTENDANCE_DATE = Convert.ToDateTime(str_Attendance);
                                _obj_Smhr_Attendance.ATTENDANCE_EMP_ID = Convert.ToInt32(lbl_Empid.Text);
                                _obj_Smhr_Attendance.ATTENDANCE_STATUS = Convert.ToString(rcmbList.SelectedValue);
                                _obj_Smhr_Attendance.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                _obj_Smhr_Attendance.ATTENDANCE_FINALIZE = 0;
                                _obj_Smhr_Attendance.OPERATION = operation.Insert;
                                if (rcmbList.Enabled)
                                {
                                    if (BLL.set_Attendance(_obj_Smhr_Attendance))
                                    {
                                        status = true;
                                    }
                                    else
                                    {
                                        status = false;
                                    }
                                }
                                else
                                {

                                }
                            }
                            break;
                        case "BTN_FINALIZE":
                            _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_AttBusinessUnit.SelectedValue);
                            _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue);
                            _obj_Smhr_Attendance.ATTENDANCE_DATE = Convert.ToDateTime(str_Attendance);
                            _obj_Smhr_Attendance.ATTENDANCE_EMP_ID = Convert.ToInt32(lbl_Empid.Text);
                            _obj_Smhr_Attendance.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Smhr_Attendance.OPERATION = operation.Validate;
                            DataTable dt_ChkAttendance1 = BLL.get_Attendance(_obj_Smhr_Attendance);
                            if (dt_ChkAttendance1.Rows.Count != 0)
                            {
                                if (Convert.ToString(dt_ChkAttendance1.Rows[0]["ATTENDANCE_FINALIZE"]) == "1")
                                {
                                    status = false;
                                }
                                else
                                {
                                    _obj_Smhr_Attendance = new SMHR_ATTENDANCE();
                                    _obj_Smhr_Attendance.OPERATION = operation.Update;
                                    _obj_Smhr_Attendance.ATTENDANCE_MODE = false;
                                    _obj_Smhr_Attendance.ATTENDANCE_FINALIZE = 1;
                                    _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_AttBusinessUnit.SelectedValue);
                                    _obj_Smhr_Attendance.ATTENDANCE_DATE = Convert.ToDateTime(str_Attendance);
                                    _obj_Smhr_Attendance.ATTENDANCE_EMP_ID = Convert.ToInt32(lbl_Empid.Text);
                                    if (BLL.set_Attendance(_obj_Smhr_Attendance))
                                    {
                                        status = true;
                                        rcmbList.Enabled = false;
                                    }
                                    else
                                    {
                                        status = false;
                                    }
                                }
                            }
                            else
                            {
                                _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_AttBusinessUnit.SelectedValue);
                                _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue);
                                _obj_Smhr_Attendance.ATTENDANCE_DATE = Convert.ToDateTime(str_Attendance);
                                _obj_Smhr_Attendance.ATTENDANCE_EMP_ID = Convert.ToInt32(lbl_Empid.Text);
                                _obj_Smhr_Attendance.ATTENDANCE_STATUS = Convert.ToString(rcmbList.SelectedValue);
                                _obj_Smhr_Attendance.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                _obj_Smhr_Attendance.ATTENDANCE_FINALIZE = 1;
                                _obj_Smhr_Attendance.OPERATION = operation.Insert;
                                if (rcmbList.Enabled)
                                {
                                    if (BLL.set_Attendance(_obj_Smhr_Attendance))
                                    {
                                        status = true;
                                        rcmbList.Enabled = false;
                                    }
                                    else
                                    {
                                        status = false;
                                    }
                                }
                                else
                                {
                                    if (BLL.set_Attendance(_obj_Smhr_Attendance))
                                    {
                                        status = true;
                                        rcmbList.Enabled = false;
                                    }
                                    else
                                    {
                                        status = false;
                                    }
                                }
                            }
                            break;
                        default:
                            break;
                    }

                }

            }
            if (status == true && (((Button)sender).ID.ToUpper()) == "BTN_FINALIZE")
            {
                BLL.ShowMessage(this, "Attendance data has been finalized");
                //rcmbList.Enabled = false;
            }
            else if ((status == false) && (((Button)sender).ID.ToUpper()) == "BTN_FINALIZE")
            {
                BLL.ShowMessage(this, "Attendance has already been finalized");
            }
            else if ((status == true) && (((Button)sender).ID.ToUpper()) == "BTN_SAVE")
            {
                BLL.ShowMessage(this, "Attendance data has been saved");
            }
            else
            {
                BLL.ShowMessage(this, "Attendance data has not been saved");
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Default2", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void btn_Finalize_Click(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex == 0)
                    e.Row.Style.Add("height", "40px");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Default2", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

        //if (e.Row.RowType == DataControlRowType.Header)
        //{
        //    foreach (TableCell cell in e.Row.Cells)
        //    {

        //        if(cell.Text<=1))
        //        {
        //        _obj_Smhr_Attendance = new SMHR_ATTENDANCE();
        //        _obj_Smhr_Attendance.OPERATION = operation.GET_MONTH;
        //        _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_AttBusinessUnit.SelectedItem.Value);
        //        _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue);
        //        DataTable dt_GetMonth = new DataTable();
        //        dt_GetMonth = BLL.get_Attendance(_obj_Smhr_Attendance);
        //        string str_MonthDate = Convert.ToString(dt_GetMonth.Rows[Convert.ToInt32(cell.Text)]["MONTH_ID"]);
        //        string[] str_MonthSplit = str_MonthDate.Split(new char[] { '-' });
        //        string str_DayCount = cell.Text;
        //        string str_PeriodElementMonth = str_MonthSplit[1];
        //        string str_PeriodYear = str_MonthSplit[2];
        //        string sysFormat = Convert.ToString(CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
        //        if (sysFormat == "MM/dd/yyyy")
        //        {
        //            DateTime str_Attendance = Convert.ToDateTime(str_PeriodElementMonth + "/" + str_DayCount + "/" + str_PeriodYear + " " + Convert.ToString(DateTime.Now.ToLongTimeString()));
        //            string str_DayOfWeek = Convert.ToString(str_Attendance.DayOfWeek);
        //            cell.Attributes.Add("title", str_DayOfWeek);
        //        }
        //        else if (sysFormat == "dd/MM/yyyy")
        //        {
        //            DateTime str_Attendance = Convert.ToDateTime(str_DayCount + "/" + str_PeriodElementMonth + "/" + str_PeriodYear + " " + Convert.ToString(DateTime.Now.ToLongTimeString()));
        //            string str_DayOfWeek = Convert.ToString(str_Attendance.DayOfWeek);
        //            cell.Attributes.Add("title", str_DayOfWeek);
        //        }
        //        }


        //    }
        //}
    }
}
