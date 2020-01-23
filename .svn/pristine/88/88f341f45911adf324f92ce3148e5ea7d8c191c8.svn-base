using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using System.Threading;
using System.Globalization;
using Telerik.Web.UI;

public partial class Payroll_frm_Attendance3 : System.Web.UI.Page
{
    SMHR_PAYROLL _obj_smhr_payroll;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    //SMHR_EMPLOYEE _obj_smhr_Employee;
    SMHR_ATTENDANCE _obj_Smhr_Attendance;
    SMHR_PERIODDTL _obj_Smhr_Prddtl;
    DropDownList rcmbList = null;
    DataTable dt_ds = new DataTable();
    //static int count = 0;
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
                    // rg_Attendence.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
                loadDropdown();

                /* Removing Session */
                ViewState.Remove("CurrentPageIndex");
                rg_Attendence.Visible = false;
                /* Removing Session */
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Attendance3", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

        # region CommentedCode
        //if (Page.IsPostBack)
        //{
        //    if (rcmb_AttBusinessUnit.SelectedIndex > 0 && rcmb_AttPeriod.SelectedIndex > 0 && rcmb_AttPeriodElement.SelectedIndex > 0)
        //    {
        //        int CurrentPageIndex = 0;
        //        if (ViewState["CurrentPageIndex"] != null)
        //        {
        //            int.TryParse(Convert.ToString(ViewState["CurrentPageIndex"]), out CurrentPageIndex);
        //        }                
        //        rg_Attendence.CurrentPageIndex = CurrentPageIndex;
        //    }
        //}
        // GridView1.PageIndex = 0;

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

        //if (!IsPostBack)
        //{
        //    loadGrid();
        //}
        #endregion CommentedCode
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Attendance3", ex.StackTrace, DateTime.Now);
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
                rg_Attendence.Visible = false;
                btn_Save.Visible = false;
                //btn_Finalize.Visible = false;
                //tblr_AttPeriodElement.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Attendance3", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

   //protected void rcmb_AttPeriodElement_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
   // {
   //     try
   //     {
   //         ViewState.Remove("CurrentPageIndex");
   //         //ViewState.Remove("Att_Record");
   //         ViewState.Remove("EmployeeDtls");
   //         ViewState.Remove("maxRowIndex");
   //         ViewState.Remove("startRowIndex");

   //         //To clear gridview headers
   //         rg_Attendence.DataSource = null;
   //         rg_Attendence.DataBind();
   //         btn_Save.Visible = false;

   //         if (rcmb_AttBusinessUnit.SelectedIndex > 0)
   //         {
   //             if (rcmb_AttPeriodElement.SelectedIndex > 0)
   //             {
   //                 ViewState["DT_Employee"] = null;
   //                 ViewState["isDynamic"] = Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue);
   //                 _obj_Smhr_Attendance = new SMHR_ATTENDANCE();
   //                 _obj_Smhr_Attendance.OPERATION = operation.GET_MONTH;
   //                 _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_AttBusinessUnit.SelectedItem.Value);
   //                 _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue);
   //                 DataTable dt_GetMonth = new DataTable();
   //                 dt_GetMonth = BLL.get_Attendance(_obj_Smhr_Attendance);

   //                 //foreach (GridTemplateColumn col in rg_Attendence.Columns)
   //                 //{
   //                 //    string str_DataField = col.DataField;
   //                 //    if (str_DataField != string.Empty)
   //                 //    {
   //                 //        col.HeaderText = string.Empty;
   //                 //    }
   //                 //}

   //                 /* To update grid Header Text with dates */
   //                 //for (int I_index = 0; I_index <= dt_GetMonth.Rows.Count + 1; I_index++)
   //                 for (int I_index = 0; I_index <= dt_GetMonth.Rows.Count - 1; I_index++)
   //                 {
   //                     //string str_HeaderText = rg_Attendence.Columns[I_index].HeaderText;
   //                     //if (str_HeaderText == string.Empty)
   //                     //{
   //                     //string[] str_GetMonth = Convert.ToString(dt_GetMonth.Rows[I_index - 2]["MONTH_ID"]).Split(new char[] { '-' });
   //                     string[] str_GetMonth = Convert.ToString(dt_GetMonth.Rows[I_index]["MONTH_ID"]).Split(new char[] { '-' });
   //                     //rg_Attendence.Columns[I_index].HeaderText = str_GetMonth[0];
   //                     rg_Attendence.Columns[I_index + 1].HeaderText = str_GetMonth[0];    //To update grid headertext with dates from index = 1
   //                     //}
   //                 }
   //                 /* To update grid Header Text with dates */

   //                 //string str_CurrentDate = DateTime.Now.ToShortDateString();
   //                 //string[] str_Split = str_CurrentDate.Split(new char[] { '/' });
   //                 //string str_Month = str_Split[0];
   //                 //string str_Date = str_Split[1];
   //                 //string str_Year = str_Split[2];


   //                 _obj_Smhr_Prddtl = new SMHR_PERIODDTL();
   //                 _obj_Smhr_Prddtl.PRDDTL_ID = Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue);
   //                 _obj_Smhr_Prddtl.OPERATION = operation.Select;
   //                 DataTable dt_Prddtl_EndDate = BLL.get_PeriodDetails(_obj_Smhr_Prddtl);
   //                 DateTime DT_Prddtl_EndDate = Convert.ToDateTime(dt_Prddtl_EndDate.Rows[0]["PRDDTL_ENDDATE"]);

   //                 //string str_Prddtl_EndDate = DT_Prddtl_EndDate.ToShortDateString();

   //                 //string[] str_Prddtl_EndDateSplit = str_Prddtl_EndDate.Split(new char[] { '/' });
   //                 //string str_EndMonth = str_Prddtl_EndDateSplit[0];
   //                 //string str_EndDate = str_Prddtl_EndDateSplit[1];
   //                 //string str_EndYear = str_Prddtl_EndDateSplit[2];

   //                 if (DT_Prddtl_EndDate.Year < DateTime.Now.Year)
   //                 {
   //                     btn_Save.Visible = true;
   //                     //btn_Finalize.Visible = true;
   //                 }
   //                 else if (DT_Prddtl_EndDate.Year == DateTime.Now.Year)
   //                 {
   //                     if (Convert.ToInt32(DT_Prddtl_EndDate.Month) <= Convert.ToInt32(DateTime.Now.Month))
   //                     {
   //                         btn_Save.Visible = true;
   //                         //btn_Finalize.Visible = true;
   //                     }
   //                     else
   //                     {
   //                         btn_Save.Visible = false;
   //                         //btn_Finalize.Visible = false;
   //                     }
   //                 }

   //                 //if (Convert.ToInt32(str_EndYear) < Convert.ToInt32(str_Year))
   //                 //{
   //                 //    btn_Save.Visible = true;
   //                 //    btn_Finalize.Visible = true;
   //                 //}
   //                 //else if (Convert.ToInt32(str_EndYear) == Convert.ToInt32(str_Year))
   //                 //{
   //                 //    if (Convert.ToInt32(str_EndMonth) <= Convert.ToInt32(str_Month))
   //                 //    {
   //                 //        btn_Save.Visible = true;
   //                 //        btn_Finalize.Visible = true;
   //                 //    }
   //                 //    else
   //                 //    {
   //                 //        btn_Save.Visible = false;
   //                 //        btn_Finalize.Visible = false;
   //                 //    }
   //                 //}

   //                 rg_Attendence.Visible = true;
   //                 loadGrid();
   //                 //GridView1.UseAccessibleHeader = false;
   //                 //GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
   //             }
   //         }
   //     }
   //     catch (Exception ex)
   //     {
   //         SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Attendance3", ex.StackTrace, DateTime.Now);
   //         Response.Redirect("~/Frm_ErrorPage.aspx");
   //         return;
   //     }
   // }


    public void loadGrid()
    {
        try
        {
            //foreach (GridTemplateColumn col in rg_Attendence.Columns)
            //{
            //    col.Visible = false;

            //    //To show last template column
            //    if (col.UniqueName == "Edit" || col.UniqueName == "Edit1")
            //        col.Visible = true;
            //}

            for (int i = 1; i <= rg_Attendence.Columns.Count - 1; i++)
            {
                rg_Attendence.Columns[i].Visible = false;
                if (i == rg_Attendence.Columns.Count - 1)
                    rg_Attendence.Columns[i].Visible = true;
            }

            if (rcmb_AttPeriodElement.SelectedValue != "")
            {
                DataTable dt_NoOfDays = Dal.ExecuteQuery("SELECT DATEDIFF(DD,PRDDTL_STARTDATE,PRDDTL_ENDDATE)+1 as NoOfDays FROM SMHR_PERIODDETAILS WHERE PRDDTL_ID='" + Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue) + "'");
                int I_Days = Convert.ToInt32(dt_NoOfDays.Rows[0][0]);
                ViewState["No_of_Days"] = I_Days;
                for (int i = 1; i <= I_Days; i++)
                //for (int i = 1; i <= I_Days + 1; i++)
                {
                    rg_Attendence.Columns[i].Visible = true;

                    ////string str = rg_Attendence.Columns[i].UniqueName;
                    ////int I_DaysCount = ((I_Days + 1) / 2);
                    //if (i <= I_Days + 1)
                    ////if (i <= 3)
                    //{
                    //    rg_Attendence.Columns[i].Visible = true;
                    //}
                }
                loadEmployees();
                rg_Attendence.DataBind();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Attendance3", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void loadEmployees()
    {
        try
        {
            //int i;
            //int startRowIndex = 0, maxRowIndex = 0;
            //int I_PageIndex = 0;
            //int I_PageSize = 0;
            //int I_dtRow = 0;
            //int I_dtRow1 = 0;
            DataTable dtEmpAtt = new DataTable();
            DataTable DT_Employee = GetEmptyDataTable();   //To create empty datatable
            //if (ViewState["DT_Employee"] == null)
            //{
            _obj_Smhr_Attendance = new SMHR_ATTENDANCE();
            _obj_Smhr_Attendance.OPERATION = operation.GetAttendance;
            _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_AttBusinessUnit.SelectedItem.Value);
            _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue);
            //DT_Employee = BLL.get_Attendance(_obj_Smhr_Attendance);

            /* Start of code for Custom paging */

            //int PageSize = 10, PageCnt = 1;
            //if (rg_Attendence.Visible == false)
            //{
            //    PageSize = rg_Attendence.PageSize;
            //    PageCnt = rg_Attendence.PageCount;
            //}
            //else
            //{
            //    PageSize = rg_Attendence.PageSize;
            //    //PageCnt = rg_Attendence.PageCount;
            //    PageCnt += Convert.ToInt32(Session["CurrentPageIndex"]);
            //}


            /* If ViewState is null, then get new data */
            if (ViewState["EmployeeDtls"] == null)
            {
                //DT_Employee = BLL.get_Attendance1(_obj_Smhr_Attendance, PageSize, PageCnt);
                dtEmpAtt = BLL.get_Attendance(_obj_Smhr_Attendance);

                /* Code to copy DB results to local DataTable */

                //if (DT_Employee.Rows.Count > 0)
                //{

                /* To create temp datatable */
                //DataTable dtEmpAtt = GetEmptyDataTable();
                //dtEmpAtt = dtEmployeeAtt.Clone();    //To copy data from existing datatable

                foreach (DataRow dr in dtEmpAtt.Rows)
                {
                    DT_Employee.Rows.Add(dr.ItemArray);
                }

                //int differenceCount = ((DT_Employee.Columns.Count-1) - dtEmpAtt.Columns.Count);
                //for (int i = 0; i <= dtEmpAtt.Columns.Count - 1;i++)
                //{
                //    if(dtEmpAtt.Columns.Count < (DT_Employee.Columns.Count-1) && i == differenceCount)
                //    {

                //    }
                //}


                //}
                /* End of code to copy DB results to local DataTable */

                ViewState["EmployeeDtls"] = DT_Employee;
                //rg_Attendence.VirtualItemCount = DT_Employee.Rows.Count;    //To display no. of items in grid
                //rg_Attendence.CurrentPageIndex = 0;
            }
            else
            {
                DT_Employee = (DataTable)ViewState["EmployeeDtls"];
                //createPaging(DT_Employee.Rows.Count);
            }

            if (DT_Employee.Rows.Count > 0)
            {
                rg_Attendence.Visible = true;
                //createPaging(Convert.ToInt32(DT_Employee.Rows[0]["TOTALROWS"]));
            }
            /* End of code for Custom paging */


            if (DT_Employee.Rows.Count != 0)
            {
                rg_Attendence.DataSource = DT_Employee;
                //rg_Attendence.DataBind();
                return;

            }
            #region commented old code

            //if (DT_Employee.Rows.Count != 0)
            //{
            //    //rg_Attendence.Rebind();

            //    //DataTable dt_NoOfDays = Dal.ExecuteQuery("SELECT DATEDIFF(DD,PRDDTL_STARTDATE,PRDDTL_ENDDATE)+1 as NoOfDays FROM SMHR_PERIODDETAILS WHERE PRDDTL_ID='" + Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue) + "'");
            //    //int I_Days = Convert.ToInt32(dt_NoOfDays.Rows[0][0]);
            //    int I_Days = ViewState["No_of_Days"] != null ? Convert.ToInt32(ViewState["No_of_Days"]) : 0;

            //    _obj_Smhr_Attendance = new SMHR_ATTENDANCE();
            //    _obj_Smhr_Attendance.OPERATION = operation.GET_MONTH;
            //    _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_AttBusinessUnit.SelectedItem.Value);
            //    _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue);
            //    DataTable dt_GetMonth = new DataTable();
            //    dt_GetMonth = BLL.get_Attendance(_obj_Smhr_Attendance);
            //    /* To set custom paging */
            //    if (ViewState["maxRowIndex"] != null && ViewState["startRowIndex"] != null)
            //    {
            //        startRowIndex = Convert.ToInt32(ViewState["startRowIndex"]) - 1;
            //        maxRowIndex = Convert.ToInt32(ViewState["maxRowIndex"]);
            //    }
            //    else
            //    {
            //        maxRowIndex = rg_Attendence.PageSize;
            //    }
            //    /* To set custom paging */

            //    for (i = 0; i <= rg_Attendence.Rows.Count - 1; i++)
            //    {
            //        for (int I_ColumnCount = 1; I_ColumnCount <= I_Days; I_ColumnCount++)
            //        {
            //            rcmbList = rg_Attendence.Rows[i].FindControl(Convert.ToString("rcmbList" + I_ColumnCount)) as DropDownList;

            //            int str_ColumnName = Convert.ToInt32(DT_Employee.Columns[I_ColumnCount].ColumnName);
            //            string str_CurrentDate = DateTime.Now.ToShortDateString();
            //            string[] str_Split = str_CurrentDate.Split(new char[] { '/' });
            //            //string str_Month = str_Split[0];
            //            string str_Month = Convert.ToString(DateTime.Now.Month);
            //            //int str_Date = Convert.ToInt32(str_Split[1]);
            //            string date = Convert.ToString(DateTime.Now.Date);
            //            int str_Date = Convert.ToInt32(DateTime.Now.Day);
            //            //string str_Year = str_Split[2];
            //            string str_Year = Convert.ToString(DateTime.Now.Year);

            //            //_obj_Smhr_Attendance = new SMHR_ATTENDANCE();
            //            //_obj_Smhr_Attendance.OPERATION = operation.GET_MONTH;
            //            //_obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_AttBusinessUnit.SelectedItem.Value);
            //            //_obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue);
            //            //DataTable dt_GetMonth = new DataTable();
            //            //dt_GetMonth = BLL.get_Attendance(_obj_Smhr_Attendance);

            //            string str_MonthDate = Convert.ToString(dt_GetMonth.Rows[I_ColumnCount - 1]["MONTH_ID"]);

            //            string[] str_MonthSplit = str_MonthDate.Split(new char[] { '-' });
            //            string str_Monthd = str_MonthSplit[0];
            //            string str_Monthm = str_MonthSplit[1];
            //            string str_Monthy = str_MonthSplit[2];

            //            if (Convert.ToInt32(str_Monthy) < Convert.ToInt32(str_Year))
            //            {
            //                //if (Convert.ToInt32(str_EndMonth) <= Convert.ToInt32(str_Month))
            //                //{
            //                //    if (I_ColumnCount <= Convert.ToInt32(str_Date))
            //                //    {
            //                rcmbList.Enabled = true;
            //                Label1.Text = "Insert";
            //                //    }
            //                //}
            //            }
            //            else if (Convert.ToInt32(str_Monthy) == Convert.ToInt32(str_Year))
            //            {
            //                if (Convert.ToInt32(str_Monthm) < Convert.ToInt32(str_Month))
            //                {
            //                    rcmbList.Enabled = true;
            //                    Label1.Text = "Insert";
            //                }
            //                else if (Convert.ToInt32(str_Monthm) == Convert.ToInt32(str_Month))
            //                {
            //                    if (I_ColumnCount <= Convert.ToInt32(str_Date))
            //                    {
            //                        rcmbList.Enabled = true;
            //                        Label1.Text = "Insert";
            //                    }
            //                    else
            //                    {
            //                        rcmbList.Enabled = false;
            //                    }
            //                }
            //                else
            //                {
            //                    rcmbList.Enabled = false;
            //                }
            //            }

            //            //if (Convert.ToString(Convert.ToString(DT_Employee.Rows[i][I_ColumnCount])).Trim() != "")
            //            if (Convert.ToString(Convert.ToString(DT_Employee.Rows[startRowIndex][I_ColumnCount])).Trim() != "")
            //            {
            //                //string str_Status = Convert.ToString(DT_Employee.Rows[i][I_ColumnCount]);
            //                string str_Status = Convert.ToString(DT_Employee.Rows[startRowIndex][I_ColumnCount]);
            //                string[] str_StatusSplit = str_Status.Split(new char[] { '-' });
            //                string str_EmpStatus = str_StatusSplit[0];

            //                //string str = Convert.ToString(DT_Employee.Rows[i][I_ColumnCount]);
            //                string str = Convert.ToString(DT_Employee.Rows[startRowIndex][I_ColumnCount]);
            //                string[] s1 = str.Split(new char[] { '-' });

            //                //TO GET WHETHER PAYROLL IS APPROVED OR NOT
            //                _obj_Smhr_Attendance.OPERATION = operation.Select3;
            //                _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_AttBusinessUnit.SelectedItem.Value);
            //                _obj_Smhr_Attendance.ATTENDANCE_PERIOD_ID = Convert.ToInt32(rcmb_AttPeriod.SelectedItem.Value);
            //                _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmb_AttPeriodElement.SelectedItem.Value);
            //                DataTable dt_status = BLL.get_Attendance(_obj_Smhr_Attendance);
            //                bool st = false;
            //                if (dt_status.Rows.Count > 0)
            //                {
            //                    for (int count = 0; count < dt_status.Rows.Count; count++)
            //                    {
            //                        if (Convert.ToString(dt_status.Rows[count]["COUNT"]) != "0")
            //                        {
            //                            st = true;//IF PAYROLL IS IN PENDING OR APPROVED
            //                        }
            //                    }
            //                }
            //                if (st == true)
            //                {
            //                    rcmbList.Enabled = false;
            //                    btn_Save.Enabled = false;
            //                    //btn_Finalize.Enabled = false;
            //                    //rntxt.Enabled = false;
            //                }
            //                else
            //                {
            //                    rcmbList.Enabled = true;
            //                    btn_Save.Enabled = true;
            //                    //btn_Finalize.Enabled = true;
            //                    //rntxt.Enabled = true;
            //                }

            //                //if (s1[1] == "1")
            //                //{
            //                //    rcmbList.Enabled = false;
            //                //}
            //                //else
            //                //{
            //                //    Label1.Text = "Update";
            //                //}

            //                rcmbList.SelectedIndex = rcmbList.Items.IndexOf(rcmbList.Items.FindByValue(str_EmpStatus.Trim()));

            //                if (Convert.ToString(Convert.ToString(str_EmpStatus)).Trim() == "P")
            //                {
            //                    rcmbList.SelectedIndex = rcmbList.Items.IndexOf(rcmbList.Items.FindByValue(Convert.ToString("P")));
            //                }
            //                else if (Convert.ToString(Convert.ToString(str_EmpStatus)).Trim() == "A")
            //                {
            //                    rcmbList.SelectedIndex = rcmbList.Items.IndexOf(rcmbList.Items.FindByValue(Convert.ToString("A")));

            //                }
            //                else if (Convert.ToString(Convert.ToString(str_EmpStatus)).Trim() == "L")
            //                {
            //                    rcmbList.SelectedIndex = rcmbList.Items.IndexOf(rcmbList.Items.FindByValue(Convert.ToString("L")));
            //                }
            //                else if (Convert.ToString(Convert.ToString(str_EmpStatus)).Trim() == "W")
            //                {
            //                    rcmbList.SelectedIndex = rcmbList.Items.IndexOf(rcmbList.Items.FindByValue(Convert.ToString("W")));
            //                }
            //                else if (Convert.ToString(Convert.ToString(str_EmpStatus)).Trim() == "T")
            //                {
            //                    rcmbList.SelectedIndex = rcmbList.Items.IndexOf(rcmbList.Items.FindByValue(Convert.ToString("T")));
            //                }
            //                else if (Convert.ToString(Convert.ToString(str_EmpStatus)).Trim() == "C")
            //                {
            //                    rcmbList.SelectedIndex = rcmbList.Items.IndexOf(rcmbList.Items.FindByValue(Convert.ToString("C")));
            //                }
            //                else if (Convert.ToString(Convert.ToString(str_EmpStatus)).Trim() == "H")
            //                {
            //                    rcmbList.SelectedIndex = rcmbList.Items.IndexOf(rcmbList.Items.FindByValue(Convert.ToString("H")));
            //                }
            //                else if (Convert.ToString(Convert.ToString(str_EmpStatus)).Trim() == "HD")
            //                {
            //                    rcmbList.SelectedIndex = rcmbList.Items.IndexOf(rcmbList.Items.FindByValue(Convert.ToString("HD")));
            //                }
            //                else if (Convert.ToString(Convert.ToString(str_EmpStatus)).Trim() == "HL")
            //                {
            //                    rcmbList.SelectedIndex = rcmbList.Items.IndexOf(rcmbList.Items.FindByValue(Convert.ToString("HL")));
            //                }
            //            }
            //            //else if (Convert.ToString(Convert.ToString(DT_Employee.Rows[i][I_ColumnCount])).Trim() == "")
            //            else if (Convert.ToString(Convert.ToString(DT_Employee.Rows[startRowIndex][I_ColumnCount])).Trim() == "")
            //            {
            //                rcmbList.Enabled = false;
            //                //rcmbList.SelectedIndex = 1;
            //                rcmbList.ClearSelection();
            //            }
            //            else
            //            {
            //                rcmbList.SelectedIndex = 1;
            //                string str_CurrentDate1 = DateTime.Now.ToShortDateString();
            //                string[] str_Split1 = str_CurrentDate1.Split(new char[] { '/' });
            //                //string str_Date1 = str_Split1[1];
            //                string str_Date1 = Convert.ToString(DateTime.Now.Day);
            //                if (Convert.ToInt32(I_ColumnCount) > Convert.ToInt32(str_Date1))
            //                {
            //                    rcmbList.Enabled = false;
            //                }
            //            }
            //        }
            //        startRowIndex += 1; //To increment rowindex
            //    }
            //}
            ////if datatable is empty
            //else
            //{
            //    _obj_Smhr_Attendance.OPERATION = operation.Check1;
            //    DT_Employee = BLL.get_Attendance(_obj_Smhr_Attendance);
            //    if (DT_Employee.Rows.Count != 0)
            //    {

            //        rg_Attendence.DataSource = DT_Employee;
            //        rg_Attendence.DataBind();
            //        //rg_Attendence.Rebind();
            //        string str_CurrentDate = DateTime.Now.ToShortDateString();
            //        string[] str_Split = str_CurrentDate.Split(new char[] { '/' });
            //        //string str_Month = str_Split[0];
            //        string str_Month = Convert.ToString(DateTime.Now.Month);
            //        //string str_Date = str_Split[1];
            //        string date = Convert.ToString(DateTime.Now.Date);
            //        int str_Date = Convert.ToInt32(DateTime.Now.Day);
            //        //string str_Year = str_Split[2];
            //        string str_Year = Convert.ToString(DateTime.Now.Year);

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

            //        DataTable dt_NoOfDays = Dal.ExecuteQuery("SELECT DATEDIFF(DD,PRDDTL_STARTDATE,PRDDTL_ENDDATE)+1 as NoOfDays FROM SMHR_PERIODDETAILS WHERE PRDDTL_ID='" + Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue) + "'");
            //        int I_Days = Convert.ToInt32(dt_NoOfDays.Rows[0][0]);
            //        for (i = 0; i <= rg_Attendence.Rows.Count - 1; i++)
            //        {
            //            for (int I_ColumnCount = 1; I_ColumnCount <= I_Days; I_ColumnCount++)
            //            {
            //                _obj_Smhr_Attendance.OPERATION = operation.GET_MONTH;
            //                _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_AttBusinessUnit.SelectedItem.Value);
            //                _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue);
            //                DataTable dt_GetMonth_ = new DataTable();
            //                dt_GetMonth_ = BLL.get_Attendance(_obj_Smhr_Attendance);
            //                string[] str_Get_Month = Convert.ToString(dt_GetMonth_.Rows[I_ColumnCount - 1]["MONTH_ID"]).Split(new char[] { '-' });
            //                string str_PeriodElementDate = str_Get_Month[0];
            //                string str_PeriodElementMonth = str_Get_Month[1];
            //                string str_PeriodYear = str_Get_Month[2];
            //                string str_Check = Convert.ToString(DT_Employee.Rows[i][I_ColumnCount]);
            //                rcmbList = rg_Attendence.Rows[i].FindControl(Convert.ToString("rcmbList" + I_ColumnCount)) as DropDownList;
            //                rcmbList.Enabled = false;
            //                if (Convert.ToInt32(str_EndYear) < Convert.ToInt32(str_Year))
            //                {
            //                    //if (Convert.ToInt32(str_EndMonth) <= Convert.ToInt32(str_Month))
            //                    //{
            //                    //    if (I_ColumnCount <= Convert.ToInt32(str_Date))
            //                    //    {
            //                    rcmbList.Enabled = true;
            //                    Label1.Text = "Insert";
            //                    //    }
            //                    //}
            //                }
            //                else if (Convert.ToInt32(str_EndYear) == Convert.ToInt32(str_Year))
            //                {
            //                    if (Convert.ToInt32(str_EndMonth) < Convert.ToInt32(str_Month))
            //                    {
            //                        rcmbList.Enabled = true;
            //                        Label1.Text = "Insert";
            //                    }
            //                    else if (Convert.ToInt32(str_EndMonth) == Convert.ToInt32(str_Month))
            //                    {
            //                        if (I_ColumnCount <= Convert.ToInt32(str_Date))
            //                        {
            //                            rcmbList.Enabled = true;
            //                            Label1.Text = "Insert";
            //                        }
            //                    }
            //                }

            //                if (Convert.ToString(Convert.ToString(DT_Employee.Rows[i][Convert.ToString(str_PeriodElementDate)])).Trim() != "")
            //                {
            //                    if (Convert.ToString(Convert.ToString(DT_Employee.Rows[i][Convert.ToString(str_PeriodElementDate)])).Trim() == "0")
            //                    {
            //                        rcmbList.SelectedIndex = rcmbList.Items.IndexOf(rcmbList.Items.FindByValue(Convert.ToString("P")));
            //                    }
            //                    else if (Convert.ToString(Convert.ToString(DT_Employee.Rows[i][Convert.ToString(str_PeriodElementDate)])).Trim() == "1")
            //                    {
            //                        rcmbList.SelectedIndex = rcmbList.Items.IndexOf(rcmbList.Items.FindByValue(Convert.ToString("L")));
            //                    }
            //                    else if (Convert.ToString(Convert.ToString(DT_Employee.Rows[i][Convert.ToString(str_PeriodElementDate)])).Trim() == "2")
            //                    {
            //                        rcmbList.SelectedIndex = rcmbList.Items.IndexOf(rcmbList.Items.FindByValue(Convert.ToString("W")));
            //                    }
            //                    else if (Convert.ToString(Convert.ToString(DT_Employee.Rows[i][Convert.ToString(str_PeriodElementDate)])).Trim() == "3")
            //                    {
            //                        rcmbList.SelectedIndex = rcmbList.Items.IndexOf(rcmbList.Items.FindByValue(Convert.ToString("H")));
            //                    }
            //                }
            //                else
            //                {
            //                    rcmbList.Enabled = true;
            //                    rcmbList.SelectedIndex = 1;
            //                }
            //            }
            //        }
            //    }
            //}

            #endregion
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Attendance3", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    //private void createPaging(int count)
    //{
    //    try
    //    {
    //        /* variables declarations */
    //        int pageSize = rg_Attendence.PageSize;
    //        /* variables declarations */


    //        int rowCount = count;
    //        if (rowCount <= pageSize)
    //            // don't create the pager if there are less rows than specified pageSize.
    //            return;

    //        // e.g. 9 % 5 = 4 - means we have an extra page,
    //        // so add 1 to rowCount otherwise add 0
    //        rowCount = rowCount / pageSize + (rowCount % pageSize != 0 ? 1 : 0);

    //        //rg_Attendence.VirtualItemCount = count;

    //        //To create paging for local DataTable
    //        int maxRowIndex = rg_Attendence.PageSize * (rg_Attendence.PageIndex + 1);
    //        int startRowIndex = (maxRowIndex - rg_Attendence.PageSize) + 1;

    //        //int maxRowIndex = rg_Attendence.PageSize * e.NewPageIndex;

    //        ViewState["maxRowIndex"] = maxRowIndex;
    //        ViewState["startRowIndex"] = startRowIndex;
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Attendance3", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //        return;
    //    }
    //}
    protected void rcmb_AttBusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rg_Attendence.Visible = false;
            rcmb_AttPeriod.SelectedIndex = 0;
            rcmb_AttPeriodElement.Items.Clear();
            btn_Save.Visible = false;
            //btn_Finalize.Visible = false;
            ViewState["DT_Employee"] = null;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Attendance3", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    //protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    //{

    //}
    //protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    //if (ViewState["DT_Employee"] != null)
    //    //{
    //    //    DataTable DT_Employee = (DataTable)ViewState["DT_Employee"];
    //    //    int intNoofDays = ViewState["No_of_Days"] != null ? Convert.ToInt32(ViewState["No_of_Days"]) : 0;


    //    //    foreach (GridViewRow gvRow in GridView1.Rows)
    //    //    {
    //    //        Label lbl_Empid = gvRow.FindControl("lbl_Empid") as Label;
    //    //        DataRow[] drRows = DT_Employee.Select("ATTENDANCE_EMP_ID = '" + lbl_Empid.Text + "'");


    //    //        for (int cnt = 1; cnt <= 28; cnt++)
    //    //        {
    //    //            RadComboBox rcmbList = gvRow.FindControl("rcmbList" + cnt) as RadComboBox;


    //    //            if (drRows.Length > 0)
    //    //            {
    //    //                DataRow drRow = drRows[0];

    //    //                if (drRow["" + cnt + ""].ToString().IndexOf('-') > 0)
    //    //                {
    //    //                    drRow["" + cnt + ""] = rcmbList.SelectedValue + "-" + drRow["" + cnt + ""].ToString().Split('-')[1];
    //    //                }

    //    //                if (cnt > 29)
    //    //                {
    //    //                    switch (intNoofDays)
    //    //                    {
    //    //                        case 29:
    //    //                            RadComboBox rcmb_29 = gvRow.FindControl("rcmbList29") as RadComboBox;
    //    //                            if (drRow["29"].ToString().IndexOf('-') > 0)
    //    //                            {
    //    //                                drRow["29"] = rcmb_29.SelectedValue + "-" + drRow["29"].ToString().Split('-')[1];
    //    //                            }
    //    //                            break;
    //    //                        case 30:
    //    //                            RadComboBox rcmbList29 = gvRow.FindControl("rcmbList29") as RadComboBox;
    //    //                            RadComboBox rcmbList30 = gvRow.FindControl("rcmbList30") as RadComboBox;

    //    //                            if (drRow["29"].ToString().IndexOf('-') > 0)
    //    //                            {
    //    //                                drRow["29"] = rcmbList29.SelectedValue + "-" + drRow["29"].ToString().Split('-')[1];
    //    //                            }
    //    //                            if (drRow["30"].ToString().IndexOf('-') > 0)
    //    //                            {
    //    //                                drRow["30"] = rcmbList30.SelectedValue + "-" + drRow["30"].ToString().Split('-')[1];
    //    //                            }
    //    //                            break;
    //    //                        case 31:
    //    //                            RadComboBox rcmb29 = gvRow.FindControl("rcmbList29") as RadComboBox;
    //    //                            RadComboBox rcmb30 = gvRow.FindControl("rcmbList30") as RadComboBox;
    //    //                            RadComboBox rcmb31 = gvRow.FindControl("rcmbList31") as RadComboBox;

    //    //                            if (drRow["29"].ToString().IndexOf('-') > 0)
    //    //                            {
    //    //                                drRow["29"] = rcmb29.SelectedValue + "-" + drRow["29"].ToString().Split('-')[1];
    //    //                            }
    //    //                            if (drRow["30"].ToString().IndexOf('-') > 0)
    //    //                            {
    //    //                                drRow["30"] = rcmb30.SelectedValue + "-" + drRow["30"].ToString().Split('-')[1];
    //    //                            }
    //    //                            if (drRow["31"].ToString().IndexOf('-') > 0)
    //    //                            {
    //    //                                drRow["31"] = rcmb31.SelectedValue + "-" + drRow["31"].ToString().Split('-')[1];
    //    //                            }
    //    //                            break;
    //    //                    }
    //    //                }
    //    //            }

    //    //        }
    //    //    }
    //    //    ViewState["DT_Employee"] = DT_Employee;
    //    //}
    //    ////int pi = rg_Attendence.PageIndex;
    //    ////ViewState["page_index"] = e.NewPageIndex;
    //    ////rg_Attendence.PageIndex = e.NewPageIndex;
    //    //DataTable DT_Employee=(DataTable)ViewState["DT_Employee"];

    //    DataTable dt = new DataTable();
    //    //for (int I_GridRow = 0; I_GridRow < GridView1.Rows.Count; I_GridRow++)
    //    //{
    //    //    DataRow dr;
    //    //    dr = dt.NewRow();

    //    //    for (int I_GridCol = 0; I_GridCol < GridView1.Columns.Count; I_GridCol++)
    //    //    {
    //    //        DataColumn dc = new DataColumn();
    //    //        dc.ColumnName = GridView1.Columns[I_GridCol].HeaderText;
    //    //        dt.Columns.Add(dc);

    //    //        dt.Rows[I_GridRow][dc] = GridView1.Columns[I_GridCol];
    //    //    }
    //    //    dt.Rows.Add(dr);
    //    //}




    //    loadGrid();


    //}

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dtEmployeeAtt = new DataTable();    //declaration
            dtEmployeeAtt = (DataTable)ViewState["EmployeeDtls"];

            ///* To update existing records in DataTable */
            //DataTable dt_NoOfDays1 = Dal.ExecuteQuery("SELECT DATEDIFF(DD,PRDDTL_STARTDATE,PRDDTL_ENDDATE)+1 as NoOfDays FROM SMHR_PERIODDETAILS WHERE PRDDTL_ID='" + Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue) + "'");
            //int I_Days1 = Convert.ToInt32(dt_NoOfDays1.Rows[0][0]);

            //Label lbl_Empid = null;
            //for (int I_GridCount = 0; I_GridCount <= rg_Attendence.Rows.Count - 1; I_GridCount++)
            //{
            //    lbl_Empid = rg_Attendence.Rows[I_GridCount].FindControl("lbl_Empid") as Label;
            //    dtEmployeeAtt = (DataTable)ViewState["EmployeeDtls"];
            //    DataRow[] employeeRow = dtEmployeeAtt.Select("ATTENDANCE_EMP_ID = " + Convert.ToInt32(lbl_Empid.Text));

            //    for (int I_GridColCount = 1; I_GridColCount <= Convert.ToInt32(I_Days1); I_GridColCount++)
            //    {
            //        rcmbList = rg_Attendence.Rows[I_GridCount].FindControl(Convert.ToString("rcmbList" + I_GridColCount)) as DropDownList;
            //        employeeRow[0][I_GridColCount] = (string.IsNullOrEmpty(rcmbList.SelectedValue) ? "" : Convert.ToString(rcmbList.SelectedValue));    //Updating new data over existing data
            //    }
            //}
            /* To update existing records in DataTable */


            /* To bulk insert data */

            //DataTable dtEmployeeAtt = (DataTable)ViewState["EmployeeDtls"];
            if (dtEmployeeAtt.Rows.Count > 0)
            {

                ///* To create temp datatable */
                //DataTable dtEmpAtt = GetEmptyDataTable();
                ////dtEmpAtt = dtEmployeeAtt.Clone();    //To copy data from existing datatable
                //foreach (DataRow dr in dtEmployeeAtt.Rows)
                //{
                //    dtEmpAtt.Rows.Add(dr.ItemArray);

                //}


                ///* To create temp datatable */


                switch (((Button)sender).ID.ToUpper())
                {
                    case "BTN_SAVE":
                        _obj_Smhr_Attendance = new SMHR_ATTENDANCE();
                        _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_AttBusinessUnit.SelectedValue);
                        _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue);
                        _obj_Smhr_Attendance.ATTENDANCE_PERIOD_ID = Convert.ToInt32(rcmb_AttPeriod.SelectedValue);
                        _obj_Smhr_Attendance.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Smhr_Attendance.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_Smhr_Attendance.CREATEDDATE = DateTime.Now;
                        _obj_Smhr_Attendance.dtEmpAttendance = dtEmployeeAtt;
                        _obj_Smhr_Attendance.OPERATION = operation.Insert2;
                        if (BLL.set_BulkAttendance(_obj_Smhr_Attendance))
                        //if (BLL.set_Attendance(_obj_Smhr_Attendance))
                        {
                            BLL.ShowMessage(this, "Attendance data has been saved");
                            return;
                        }
                        else
                        {
                            BLL.ShowMessage(this, "Attendance details not saved");
                            return;
                        }
                        break;
                    default:
                        break;
                }
            }
            return;
            /* To bulk insert data */

            #region commented old code


            //bool status = false;
            //string str_PeriodElementMonth = null;
            //string str_PeriodYear = null;
            //string str_CurrentDate = DateTime.Now.ToShortDateString();
            //string[] str_Split = str_CurrentDate.Split(new char[] { '/' });
            ////string str_Date = str_Split[1];
            //string str_Date = Convert.ToString(DateTime.Now.Day);
            //_obj_Smhr_Attendance = new SMHR_ATTENDANCE();
            //DataTable dt_NoOfDays1 = Dal.ExecuteQuery("SELECT DATEDIFF(DD,PRDDTL_STARTDATE,PRDDTL_ENDDATE)+1 as NoOfDays FROM SMHR_PERIODDETAILS WHERE PRDDTL_ID='" + Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue) + "'");
            //int I_Days1 = Convert.ToInt32(dt_NoOfDays1.Rows[0][0]);

            //Label lbl_Empid = null; //new Label();
            //Label lbl_EmpCode = new Label();
            //for (int I_GridCount = 0; I_GridCount <= rg_Attendence.Rows.Count - 1; I_GridCount++)
            //{
            //    lbl_Empid = rg_Attendence.Rows[I_GridCount].FindControl("lbl_Empid") as Label;
            //    for (int I_GridColCount = 1; I_GridColCount <= Convert.ToInt32(I_Days1); I_GridColCount++)
            //    {
            //        string str_month = Convert.ToString("rcmbList" + I_GridColCount);
            //        rcmbList = rg_Attendence.Rows[I_GridCount].FindControl(Convert.ToString("rcmbList" + I_GridColCount)) as DropDownList;
            //        if (!rcmbList.Enabled)
            //        {
            //            string str_ID = rcmbList.ID;
            //        }
            //    }
            //}

            //for (int I_GridCount = 0; I_GridCount <= rg_Attendence.Rows.Count - 1; I_GridCount++)
            //{
            //    lbl_Empid = rg_Attendence.Rows[I_GridCount].FindControl("lbl_Empid") as Label;

            //    /* To update existing records in DataTable */
            //    //DataTable dtEmployeeAtt = (DataTable)ViewState["EmployeeDtls"];

            //    DataRow[] employeeRow = dtEmployeeAtt.Select("ATTENDANCE_EMP_ID = " + Convert.ToInt32(lbl_Empid.Text));

            //    //DataRow[] customerRow = dataSet1.Tables["Customers"].Select("CustomerID = 'ALFKI'");
            //    //customerRow[0]["CompanyName"] = "Updated Company Name";
            //    //customerRow[0]["City"] = "Seattle";

            //    /* To update existing records in DataTable */



            //    //lbl_EmpCode=rg_Attendence.Items[I_GridCount].FindControl("lbl_EmpCode") as Label;
            //    //_obj_smhr_Employee= new SMHR_EMPLOYEE();
            //    //_obj_smhr_Employee.EMP_EMPCODE=Convert.ToString(lbl_EmpCode.Text);
            //    //_obj_smhr_Employee.ORGANISATION_ID=Convert.ToInt32(Session["ORG_ID"]);
            //    //DataTable dt_EmpCode=BLL.get_Employee(_obj_smhr_Employee);
            //    //for (int I_ID = 0; I_ID < dt_EmpCode.Rows.Count; I_ID++)
            //    //{
            //    //string strEmpId = Convert.ToString(dt_EmpCode.Rows[I_ID]["EMP_ID"]);
            //    //string strEmpBu = Convert.ToString(dt_EmpCode.Rows[I_ID]["EMP_BUSINESSUNIT_ID"]);
            //    //lbl_Empid.Text = strEmpId;
            //    for (int I_GridColCount = 1; I_GridColCount <= Convert.ToInt32(I_Days1); I_GridColCount++)
            //    {
            //        /* To update existing records in DataTable */
            //        rcmbList = rg_Attendence.Rows[I_GridCount].FindControl(Convert.ToString("rcmbList" + I_GridColCount)) as DropDownList;
            //        employeeRow[0][I_GridColCount] = (string.IsNullOrEmpty(rcmbList.SelectedValue) ? "" : Convert.ToString(rcmbList.SelectedValue));
            //        /* To update existing records in DataTable */


            //        _obj_Smhr_Attendance = new SMHR_ATTENDANCE();
            //        _obj_Smhr_Attendance.OPERATION = operation.GET_MONTH;
            //        _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_AttBusinessUnit.SelectedItem.Value);
            //        _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue);
            //        DataTable dt_GetMonth = new DataTable();
            //        dt_GetMonth = BLL.get_Attendance(_obj_Smhr_Attendance);
            //        string[] str_Get_Month = Convert.ToString(dt_GetMonth.Rows[I_GridColCount - 1]["MONTH_ID"]).Split(new char[] { '-' });
            //        str_PeriodElementMonth = str_Get_Month[1];
            //        str_PeriodYear = str_Get_Month[2];
            //        string str_month = Convert.ToString("rcmbList" + I_GridColCount);
            //        rcmbList = rg_Attendence.Rows[I_GridCount].FindControl(Convert.ToString("rcmbList" + I_GridColCount)) as DropDownList;
            //        string str_DayCount = rg_Attendence.Columns[I_GridColCount + 1].HeaderText;
            //        //DateTime str_Attendance = Convert.ToDateTime(dt_GetMonth.Rows[I_GridColCount - 1]["MONTH_ID"] + " " + Convert.ToString(DateTime.Now.ToLongTimeString()));
            //        string sysFormat = Convert.ToString(CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
            //        string str_Attendance = string.Empty;
            //        if (sysFormat == "MM/dd/yyyy")
            //        {
            //            str_Attendance = str_PeriodElementMonth + "/" + str_DayCount + "/" + str_PeriodYear + " " + Convert.ToString(DateTime.Now.ToLongTimeString());
            //        }
            //        else if (sysFormat == "dd/MM/yyyy")
            //        {
            //            str_Attendance = str_DayCount + "/" + str_PeriodElementMonth + "/" + str_PeriodYear + " " + Convert.ToString(DateTime.Now.ToLongTimeString());
            //        }

            //        continue;


            //        switch (((Button)sender).ID.ToUpper())
            //        {
            //            case "BTN_SAVE":
            //                _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_AttBusinessUnit.SelectedValue);
            //                //_obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(strEmpBu);
            //                _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue);
            //                _obj_Smhr_Attendance.ATTENDANCE_DATE = Convert.ToDateTime(str_Attendance);
            //                _obj_Smhr_Attendance.ATTENDANCE_EMP_ID = Convert.ToInt32(lbl_Empid.Text);
            //                //_obj_Smhr_Attendance.ATTENDANCE_EMP_ID = Convert.ToInt32(lbl_Empid.Text);
            //                _obj_Smhr_Attendance.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //                _obj_Smhr_Attendance.OPERATION = operation.Validate;
            //                DataTable dt_ChkAttendance = BLL.get_Attendance(_obj_Smhr_Attendance);
            //                if (dt_ChkAttendance.Rows.Count != 0)
            //                {
            //                    if (Convert.ToString(dt_ChkAttendance.Rows[0]["ATTENDANCE_FINALIZE"]) == "1")
            //                    {

            //                    }
            //                    else
            //                    {
            //                        _obj_Smhr_Attendance.OPERATION = operation.Update;
            //                        _obj_Smhr_Attendance.ATTENDANCE_MODE = true;
            //                        _obj_Smhr_Attendance.ATTENDANCE_FINALIZE = 0;
            //                        _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_AttBusinessUnit.SelectedValue);
            //                        _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue);
            //                        _obj_Smhr_Attendance.ATTENDANCE_DATE = Convert.ToDateTime(str_Attendance);
            //                        _obj_Smhr_Attendance.ATTENDANCE_EMP_ID = Convert.ToInt32(lbl_Empid.Text);
            //                        _obj_Smhr_Attendance.ATTENDANCE_STATUS = Convert.ToString(rcmbList.SelectedValue);
            //                        _obj_Smhr_Attendance.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);


            //                        if (BLL.set_Attendance(_obj_Smhr_Attendance))
            //                        {
            //                            status = true;

            //                        }
            //                        else
            //                        {
            //                            status = false;
            //                        }
            //                    }
            //                }
            //                else
            //                {
            //                    _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_AttBusinessUnit.SelectedValue);
            //                    _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue);
            //                    _obj_Smhr_Attendance.ATTENDANCE_DATE = Convert.ToDateTime(str_Attendance);
            //                    _obj_Smhr_Attendance.ATTENDANCE_EMP_ID = Convert.ToInt32(lbl_Empid.Text);
            //                    _obj_Smhr_Attendance.ATTENDANCE_STATUS = Convert.ToString(rcmbList.SelectedValue);
            //                    _obj_Smhr_Attendance.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //                    _obj_Smhr_Attendance.ATTENDANCE_FINALIZE = 0;
            //                    _obj_Smhr_Attendance.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            //                    _obj_Smhr_Attendance.CREATEDDATE = DateTime.Now;
            //                    _obj_Smhr_Attendance.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            //                    _obj_Smhr_Attendance.LASTMDFDATE = DateTime.Now;
            //                    _obj_Smhr_Attendance.OPERATION = operation.Insert;
            //                    if (rcmbList.Enabled)
            //                    {
            //                        if (BLL.set_Attendance(_obj_Smhr_Attendance))
            //                        {
            //                            status = true;
            //                        }
            //                        else
            //                        {
            //                            status = false;
            //                        }
            //                    }
            //                    else
            //                    {

            //                    }
            //                }
            //                break;
            //            case "BTN_FINALIZE":
            //                _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_AttBusinessUnit.SelectedValue);
            //                _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue);
            //                _obj_Smhr_Attendance.ATTENDANCE_DATE = Convert.ToDateTime(str_Attendance);
            //                _obj_Smhr_Attendance.ATTENDANCE_EMP_ID = Convert.ToInt32(lbl_Empid.Text);
            //                _obj_Smhr_Attendance.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //                _obj_Smhr_Attendance.OPERATION = operation.Validate;
            //                DataTable dt_ChkAttendance1 = BLL.get_Attendance(_obj_Smhr_Attendance);
            //                if (dt_ChkAttendance1.Rows.Count != 0)
            //                {
            //                    if (Convert.ToString(dt_ChkAttendance1.Rows[0]["ATTENDANCE_FINALIZE"]) == "1")
            //                    {
            //                        status = false;
            //                    }
            //                    else
            //                    {
            //                        _obj_Smhr_Attendance = new SMHR_ATTENDANCE();
            //                        _obj_Smhr_Attendance.OPERATION = operation.Update;
            //                        _obj_Smhr_Attendance.ATTENDANCE_MODE = false;
            //                        _obj_Smhr_Attendance.ATTENDANCE_FINALIZE = 1;
            //                        _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue);
            //                        _obj_Smhr_Attendance.ATTENDANCE_STATUS = Convert.ToString(rcmbList.SelectedValue);
            //                        _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_AttBusinessUnit.SelectedValue);
            //                        _obj_Smhr_Attendance.ATTENDANCE_DATE = Convert.ToDateTime(str_Attendance);
            //                        _obj_Smhr_Attendance.ATTENDANCE_EMP_ID = Convert.ToInt32(lbl_Empid.Text);
            //                        _obj_Smhr_Attendance.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            //                        _obj_Smhr_Attendance.CREATEDDATE = DateTime.Now;
            //                        _obj_Smhr_Attendance.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            //                        _obj_Smhr_Attendance.LASTMDFDATE = DateTime.Now;
            //                        if (BLL.set_Attendance(_obj_Smhr_Attendance))
            //                        {
            //                            status = true;
            //                            rcmbList.Enabled = false;
            //                        }
            //                        else
            //                        {
            //                            status = false;
            //                        }
            //                    }
            //                }
            //                else
            //                {
            //                    _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_AttBusinessUnit.SelectedValue);
            //                    _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue);
            //                    _obj_Smhr_Attendance.ATTENDANCE_DATE = Convert.ToDateTime(str_Attendance);
            //                    _obj_Smhr_Attendance.ATTENDANCE_EMP_ID = Convert.ToInt32(lbl_Empid.Text);
            //                    _obj_Smhr_Attendance.ATTENDANCE_STATUS = Convert.ToString(rcmbList.SelectedValue);
            //                    _obj_Smhr_Attendance.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //                    _obj_Smhr_Attendance.ATTENDANCE_FINALIZE = 1;
            //                    _obj_Smhr_Attendance.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            //                    _obj_Smhr_Attendance.CREATEDDATE = DateTime.Now;
            //                    _obj_Smhr_Attendance.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            //                    _obj_Smhr_Attendance.LASTMDFDATE = DateTime.Now;
            //                    _obj_Smhr_Attendance.OPERATION = operation.Insert;
            //                    if (rcmbList.Enabled)
            //                    {
            //                        if (BLL.set_Attendance(_obj_Smhr_Attendance))
            //                        {
            //                            status = true;
            //                            rcmbList.Enabled = false;
            //                        }
            //                        else
            //                        {
            //                            status = false;
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if (BLL.set_Attendance(_obj_Smhr_Attendance))
            //                        {
            //                            status = true;
            //                            rcmbList.Enabled = false;
            //                        }
            //                        else
            //                        {
            //                            status = false;
            //                        }
            //                    }
            //                }
            //                break;
            //            default:
            //                break;
            //        }

            //    }
            //    //}

            //}
            //if (status == true && (((Button)sender).ID.ToUpper()) == "BTN_FINALIZE")
            //{
            //    BLL.ShowMessage(this, "Attendance data has been finalized");
            //    //rcmbList.Enabled = false;
            //}
            //else if ((status == false) && (((Button)sender).ID.ToUpper()) == "BTN_FINALIZE")
            //{
            //    BLL.ShowMessage(this, "Attendance has already been finalized");
            //}
            //else if ((status == true) && (((Button)sender).ID.ToUpper()) == "BTN_SAVE")
            //{
            //    BLL.ShowMessage(this, "Attendance data has been saved");
            //}
            //else if ((status == false) && (((Button)sender).ID.ToUpper()) == "BTN_SAVE")
            //{
            //    BLL.ShowMessage(this, "Attendance data has already been saved");
            //}
            //else
            //{
            //    BLL.ShowMessage(this, "Attendance data has not been saved");
            //}
            #endregion

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Attendance3", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private DataTable GetEmptyDataTable()
    {
        DataTable dtEmpAtt = new DataTable();
        try
        {
            dtEmpAtt.Columns.Add("ATTENDANCE_EMP_NAME", typeof(string));
            dtEmpAtt.Columns.Add("ATTENDANCE_EMP_ID", typeof(int));
            dtEmpAtt.Columns.Add("EMP_EMPCODE", typeof(string));
            dtEmpAtt.Columns.Add("D1", typeof(string));
            dtEmpAtt.Columns.Add("D2", typeof(string));
            dtEmpAtt.Columns.Add("D3", typeof(string));
            dtEmpAtt.Columns.Add("D4", typeof(string));
            dtEmpAtt.Columns.Add("D5", typeof(string));
            dtEmpAtt.Columns.Add("D6", typeof(string));
            dtEmpAtt.Columns.Add("D7", typeof(string));
            dtEmpAtt.Columns.Add("D8", typeof(string));
            dtEmpAtt.Columns.Add("D9", typeof(string));
            dtEmpAtt.Columns.Add("D10", typeof(string));
            dtEmpAtt.Columns.Add("D11", typeof(string));
            dtEmpAtt.Columns.Add("D12", typeof(string));
            dtEmpAtt.Columns.Add("D13", typeof(string));
            dtEmpAtt.Columns.Add("D14", typeof(string));
            dtEmpAtt.Columns.Add("D15", typeof(string));
            dtEmpAtt.Columns.Add("D16", typeof(string));
            dtEmpAtt.Columns.Add("D17", typeof(string));
            dtEmpAtt.Columns.Add("D18", typeof(string));
            dtEmpAtt.Columns.Add("D19", typeof(string));
            dtEmpAtt.Columns.Add("D20", typeof(string));
            dtEmpAtt.Columns.Add("D21", typeof(string));
            dtEmpAtt.Columns.Add("D22", typeof(string));
            dtEmpAtt.Columns.Add("D23", typeof(string));
            dtEmpAtt.Columns.Add("D24", typeof(string));
            dtEmpAtt.Columns.Add("D25", typeof(string));
            dtEmpAtt.Columns.Add("D26", typeof(string));
            dtEmpAtt.Columns.Add("D27", typeof(string));
            dtEmpAtt.Columns.Add("D28", typeof(string));
            dtEmpAtt.Columns.Add("D29", typeof(string));
            dtEmpAtt.Columns.Add("D30", typeof(string));
            dtEmpAtt.Columns.Add("D31", typeof(string));
            //DataColumn dc = dtEmpAtt.Columns.Add("ID", typeof(int));
            //dc.AutoIncrement = true;
            //dc.AutoIncrementSeed = 1;
            //dc.AutoIncrementStep = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Attendance3", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return dtEmpAtt;
    }
    //protected void btn_Finalize_Click(object sender, EventArgs e)
    //{

    //}

    //protected void rg_Attendence_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    //{
    //    try
    //    {
    //        if (rcmb_AttBusinessUnit.SelectedIndex > 0 && rcmb_AttPeriod.SelectedIndex > 0 && rcmb_AttPeriodElement.SelectedIndex > 0 && ViewState["EmployeeDtls"] != null)
    //        {
    //            loadEmployees();
    //            //rg_Attendence.DataSource = (DataTable)ViewState["EmployeeDtls"];
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Attendence", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //        return;
    //    }
    //}

    //protected void rg_Attendence_PageIndexChanged(object source, GridPageChangedEventArgs e)
    //{
    //    try
    //    {
    //        rg_Attendence.PageIndex = e.NewPageIndex;
    //        ViewState["CurrentPageIndex"] = e.NewPageIndex;
    //        //       int maxRowIndex = rg_Attendence.PageSize * e.NewPageIndex;
    //        //       int startRowIndex = (maxRowIndex - rg_Attendence.PageSize) + 1;
    //        //       ViewState["maxRowIndex"] = maxRowIndex;
    //        //       ViewState["startRowIndex"] = startRowIndex;
    //        ////       SET @MaxRowIndex = @P_PageSize * @P_CurrentPageIndex
    //        ////SET @StartRowIndex = (@MaxRowIndex - @P_PageSize) + 1


    //        /* To update existing records in DataTable */
    //        DataTable dt_NoOfDays1 = Dal.ExecuteQuery("SELECT DATEDIFF(DD,PRDDTL_STARTDATE,PRDDTL_ENDDATE)+1 as NoOfDays FROM SMHR_PERIODDETAILS WHERE PRDDTL_ID='" + Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue) + "'");
    //        int I_Days1 = Convert.ToInt32(dt_NoOfDays1.Rows[0][0]);

    //        Label lbl_Empid = null;
    //        for (int I_GridCount = 0; I_GridCount <= rg_Attendence.Rows.Count - 1; I_GridCount++)
    //        {
    //            lbl_Empid = rg_Attendence.Rows[I_GridCount].FindControl("lbl_Empid") as Label;
    //            DataTable dtEmployeeAtt = (DataTable)ViewState["EmployeeDtls"];
    //            DataRow[] employeeRow = dtEmployeeAtt.Select("ATTENDANCE_EMP_ID = " + Convert.ToInt32(lbl_Empid.Text));

    //            for (int I_GridColCount = 1; I_GridColCount <= Convert.ToInt32(I_Days1); I_GridColCount++)
    //            {
    //                rcmbList = rg_Attendence.Rows[I_GridCount].FindControl(Convert.ToString("rcmbList" + I_GridColCount)) as DropDownList;
    //                employeeRow[0][I_GridColCount] = (string.IsNullOrEmpty(rcmbList.SelectedValue) ? "" : Convert.ToString(rcmbList.SelectedValue));    //Updating new data over existing data
    //            }
    //        }
    //        /* To update existing records in DataTable */
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Attendence", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //        return;
    //    }
    //}
    //protected void rg_Attendence_PreRender(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (rcmb_AttBusinessUnit.SelectedIndex > 0 && rcmb_AttPeriod.SelectedIndex > 0 && rcmb_AttPeriodElement.SelectedIndex > 0 && ViewState["CurrentPageIndex"] != null)
    //        {
    //            loadEmployees();
    //            //rcmb_AttPeriodElement_SelectedIndexChanged(null, null);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Attendence", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //        return;
    //    }
    //}
    //protected void lnkAttendanceEdit_Command(object sender, CommandEventArgs e)
    //{
    //    try
    //    {


    //        rg_Attendence.EditIndex = Convert.ToInt32(e.CommandArgument);
    //        DataTable DT_Employee = (DataTable)ViewState["EmployeeDtls"];
    //        rg_Attendence.DataSource = DT_Employee;
    //        rg_Attendence.DataBind();
    //        ////rg_Attendence.MasterTableView.Rebind();
    //        //return;


    //        //DataTable dtEmployeeAtt = (DataTable)ViewState["EmployeeDtls"];
    //        ////DataRow[] employeeRow = dtEmployeeAtt.Select("ATTENDANCE_EMP_ID = " + Convert.ToInt32(e.CommandArgument));

    //        //int I_GridCount = Convert.ToInt32(e.CommandArgument);
    //        //Label lbl_Empid = rg_Attendence.Rows[I_GridCount].FindControl("lbl_Empid") as Label;
    //        //DataRow[] employeeRow = dtEmployeeAtt.Select("ATTENDANCE_EMP_ID = " + Convert.ToInt32(lbl_Empid.Text));

    //        ////for (int I_GridColCount = 1; I_GridColCount <= Convert.ToInt32(I_Days1); I_GridColCount++)
    //        //for (int I_GridColCount = 1; I_GridColCount <= rg_Attendence.Columns.Count - 2; I_GridColCount++)
    //        //{
    //        //    rcmbList = rg_Attendence.Rows[I_GridCount].FindControl(Convert.ToString("rcmbList" + I_GridColCount)) as DropDownList;
    //        //    //employeeRow[0][I_GridColCount] = (string.IsNullOrEmpty(rcmbList.SelectedValue) ? "" : Convert.ToString(rcmbList.SelectedValue));    //Updating new data over existing data
    //        //    rcmbList.SelectedIndex = rcmbList.Items.IndexOf(rcmbList.Items.FindByValue(Convert.ToString(employeeRow[I_GridColCount])));
    //        //}

    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Attendence", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //        return;
    //    }
    //}
    //protected void rg_Attendence_EditCommand(object source, GridCommandEventArgs e)
    //{
    //    try
    //    {
    //        GridEditableItem editableItem = e.Item as GridEditableItem;

    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Attendence", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //        return;
    //    }
    //}
    //protected void rg_Attendence_UpdateCommand(object source, GridCommandEventArgs e)
    //{
    //    try
    //    {

    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Attendence", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //        return;
    //    }
    //}
    //protected void rg_Attendence_CancelCommand(object source, GridCommandEventArgs e)
    //{
    //    try
    //    {
    //        DataTable DT_Employee = (DataTable)ViewState["EmployeeDtls"];
    //        rg_Attendence.DataSource = DT_Employee;
    //        rg_Attendence.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Attendence", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //        return;
    //    }
    //}
    /*protected void rg_Attendence_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            rg_Attendence.EditIndex = e.NewEditIndex;
            DataTable DT_Employee = (DataTable)ViewState["EmployeeDtls"];
            rg_Attendence.DataSource = DT_Employee;
            rg_Attendence.DataBind();
            if (DT_Employee.Rows.Count > 0)
            {
                int I_GridCount = Convert.ToInt32(e.NewEditIndex);
                Label lbl_Empid = rg_Attendence.Rows[I_GridCount].FindControl("lbl_Empid") as Label;
                DataRow[] employeeRow = DT_Employee.Select("ATTENDANCE_EMP_ID = " + Convert.ToInt32(lbl_Empid.Text));

                //for (int I_GridColCount = 1; I_GridColCount <= Convert.ToInt32(I_Days1); I_GridColCount++)
                for (int I_GridColCount = 1; I_GridColCount <= rg_Attendence.Columns.Count - 4; I_GridColCount++)
                {
                    DropDownList rcmbList = rg_Attendence.Rows[I_GridCount].FindControl(Convert.ToString("rcmbList" + I_GridColCount)) as DropDownList;

                    //To set focus to 1st record
                    if (I_GridColCount == 1)
                        rcmbList.Focus();

                    //rcmbList.SelectedIndex = rcmbList.Items.IndexOf(rcmbList.Items.FindByValue(Convert.ToString(employeeRow[I_GridColCount])));
                    if (!string.IsNullOrEmpty(Convert.ToString(employeeRow[0].ItemArray[I_GridColCount + 2]).Trim()))
                    {
                        rcmbList.SelectedIndex = rcmbList.Items.IndexOf(rcmbList.Items.FindByValue(Convert.ToString(employeeRow[0].ItemArray[I_GridColCount + 2]).Trim()));
                    }
                    else
                    {
                        //rcmbList.SelectedIndex = rcmbList.Items.IndexOf(rcmbList.Items.FindByValue(Convert.ToString(employeeRow[0].ItemArray[I_GridColCount])));
                        rcmbList.Items.Clear();
                        //rcmbList.ClearSelection();
                        rcmbList.Text = string.Empty;
                        rcmbList.Enabled = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Attendance3", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }*/
    //protected void rg_Attendence_RowUpdating(object sender, GridViewUpdateEventArgs e)
    //{
    //    try
    //    {
    //        /* To update existing records in DataTable */
    //        Label lbl_Empid = null;
    //        int rowIndex = e.RowIndex;
    //        lbl_Empid = rg_Attendence.Rows[rowIndex].FindControl("lbl_Empid") as Label;
    //        DataTable dtEmployeeAtt = (DataTable)ViewState["EmployeeDtls"];
    //        DataRow[] employeeRow = dtEmployeeAtt.Select("ATTENDANCE_EMP_ID = " + Convert.ToInt32(lbl_Empid.Text));

    //        for (int I_GridColCount = 1; I_GridColCount <= rg_Attendence.Columns.Count - 4; I_GridColCount++)
    //        {
    //            DropDownList rcmbList = rg_Attendence.Rows[rowIndex].FindControl(Convert.ToString("rcmbList" + I_GridColCount)) as DropDownList;
    //            employeeRow[0][I_GridColCount + 2] = (string.IsNullOrEmpty(rcmbList.SelectedValue) ? "" : Convert.ToString(rcmbList.SelectedValue));    //Updating new data over existing data
    //        }
    //        rg_Attendence.EditIndex = -1;
    //        rg_Attendence.DataSource = dtEmployeeAtt;
    //        rg_Attendence.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Attendance3", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //        return;
    //    }
    //}
   
    //protected void rg_Attendence_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    //{
    //    try
    //    {
    //        rg_Attendence.EditIndex = -1;
    //        DataTable dtEmployeeAtt = (DataTable)ViewState["EmployeeDtls"];
    //        rg_Attendence.DataSource = dtEmployeeAtt;
    //        rg_Attendence.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Attendance3", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //        return;
    //    }
    //}
    //protected void rg_Attendence_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) == DataControlRowState.Edit)
    //        {
    //            // Here you will get the Control you need like:
    //            DropDownList dl = (DropDownList)e.Row.FindControl("ddlPBXTypeNS");
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Attendence", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //        return;
    //    }
    //}
    protected void rg_Attendence_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    Label lblEmpID = e.Row.FindControl("lbl_Empid") as Label;
                    if (!string.IsNullOrEmpty(lblEmpID.Text))
                    {
                        _obj_Smhr_Attendance = new SMHR_ATTENDANCE();
                        _obj_Smhr_Attendance.OPERATION = operation.Select1;
                        _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_AttBusinessUnit.SelectedValue);
                        _obj_Smhr_Attendance.ATTENDANCE_PERIOD_ID = Convert.ToInt32(rcmb_AttPeriod.SelectedValue);
                        _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue);
                        _obj_Smhr_Attendance.ATTENDANCE_EMP_ID = Convert.ToInt32(lblEmpID.Text);
                        DataTable dt_status = BLL.get_Attendance(_obj_Smhr_Attendance);
                        bool flag = false;
                        if (dt_status.Rows.Count > 0)
                        {
                            for (int count = 0; count < dt_status.Rows.Count; count++)
                            {
                                if (Convert.ToString(dt_status.Rows[count]["COUNT"]) != "0")
                                {
                                    flag = true;//IF PAYROLL IS IN PENDING OR APPROVED
                                }
                            }
                        }
                        if (flag)   //If payroll is pending/approved
                        {
                            e.Row.Cells[34].Enabled = false;    //disable the edit button
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Attendance3", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void rg_Attendence_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        loadEmployees();
        
    }
    protected void rg_Attendence_ItemDataBound(object sender, GridItemEventArgs e)
    {
        try
        {
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                int rowIndex = e.Item.RowIndex;

                if (ViewState["EmployeeDtls"] != null)
                {
                    DataTable DT_Employee = (DataTable)ViewState["EmployeeDtls"];
                    if (DT_Employee.Rows.Count > 0)
                    {
                        DataRow dr = DT_Employee.Rows[rowIndex - 2];

                        //to bind data to edited column ddls

                        DataTable dt_NoOfDays = Dal.ExecuteQuery("SELECT DATEDIFF(DD,PRDDTL_STARTDATE,PRDDTL_ENDDATE)+1 as NoOfDays FROM SMHR_PERIODDETAILS WHERE PRDDTL_ID='" + Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue) + "'");
                        int I_Days = Convert.ToInt32(dt_NoOfDays.Rows[0][0]);
                        for (int i = 1; i <= I_Days; i++)
                        //for (int i = 1; i <= I_Days + 1; i++)
                        {
                            GridEditableItem item = e.Item as GridEditableItem;
                            DropDownList rcmbList = item.FindControl("rcmbList" + i) as DropDownList;
                            if (string.IsNullOrEmpty(Convert.ToString(dr[i + 2]).Trim()))
                            {
                                rcmbList.Visible = false;
                            }
                            else
                            {
                                rcmbList.SelectedIndex = rcmbList.Items.IndexOf(rcmbList.Items.FindByValue(Convert.ToString(dr[i + 2]).Trim()));
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Attendance3", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

    }
    protected void rg_Attendence_UpdateCommand(object source, GridCommandEventArgs e)
    {
        try
        {
            int rowIndex = e.Item.RowIndex;
            if (e.Item.IsInEditMode)
            {
                DataTable dt_NoOfDays = Dal.ExecuteQuery("SELECT DATEDIFF(DD,PRDDTL_STARTDATE,PRDDTL_ENDDATE)+1 as NoOfDays FROM SMHR_PERIODDETAILS WHERE PRDDTL_ID='" + Convert.ToInt32(rcmb_AttPeriodElement.SelectedValue) + "'");
                int I_Days = Convert.ToInt32(dt_NoOfDays.Rows[0][0]);
                for (int i = 1; i <= I_Days; i++)
                //for (int i = 1; i <= I_Days + 1; i++)
                {
                    GridEditableItem item = e.Item as GridEditableItem;
                    DropDownList rcmbList = item.FindControl("rcmbList" + i) as DropDownList;
                    //rcmbList.SelectedIndex = rcmbList.Items.IndexOf(rcmbList.Items.FindByValue(Convert.ToString(dr[i + 2]).Trim()));
                    if (!rcmbList.Visible)  //if no controls exists doesn't save the value
                    {
                        continue;
                    }

                    Label lbl_Empid = item.FindControl("lbl_Empid") as Label;
                    DataTable dtEmployeeAtt = (DataTable)ViewState["EmployeeDtls"];
                    DataRow[] employeeRow = dtEmployeeAtt.Select("ATTENDANCE_EMP_ID = " + Convert.ToInt32(lbl_Empid.Text));

                    employeeRow[0][i + 2] = (string.IsNullOrEmpty(rcmbList.SelectedValue) ? "" : Convert.ToString(rcmbList.SelectedValue));    //Updating new data over existing data

                }

            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Attendance3", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void rcmb_AttPeriodElement_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            ViewState.Remove("CurrentPageIndex");
            //ViewState.Remove("Att_Record");
            ViewState.Remove("EmployeeDtls");
            ViewState.Remove("maxRowIndex");
            ViewState.Remove("startRowIndex");

            //To clear gridview headers
            rg_Attendence.DataSource = null;
            rg_Attendence.DataBind();

            if (rcmb_AttBusinessUnit.SelectedIndex > 0)
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

                    /* To update grid Header Text with dates */
                    //for (int I_index = 0; I_index <= dt_GetMonth.Rows.Count + 1; I_index++)
                    for (int I_index = 0; I_index <= dt_GetMonth.Rows.Count - 1; I_index++)
                    {
                        //string str_HeaderText = rg_Attendence.Columns[I_index].HeaderText;
                        //if (str_HeaderText == string.Empty)
                        //{
                        //string[] str_GetMonth = Convert.ToString(dt_GetMonth.Rows[I_index - 2]["MONTH_ID"]).Split(new char[] { '-' });
                        string[] str_GetMonth = Convert.ToString(dt_GetMonth.Rows[I_index]["MONTH_ID"]).Split(new char[] { '-' });
                        //rg_Attendence.Columns[I_index].HeaderText = str_GetMonth[0];
                        rg_Attendence.Columns[I_index + 1].HeaderText = str_GetMonth[0];    //To update grid headertext with dates from index = 1
                        //}
                    }
                    /* To update grid Header Text with dates */

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
                        //btn_Finalize.Visible = true;
                    }
                    else if (DT_Prddtl_EndDate.Year == DateTime.Now.Year)
                    {
                        if (Convert.ToInt32(DT_Prddtl_EndDate.Month) <= Convert.ToInt32(DateTime.Now.Month))
                        {
                            btn_Save.Visible = true;
                            //btn_Finalize.Visible = true;
                        }
                        else
                        {
                            btn_Save.Visible = false;
                            //btn_Finalize.Visible = false;
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

                    rg_Attendence.Visible = true;
                    loadGrid();
                    //GridView1.UseAccessibleHeader = false;
                    //GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                else
                {
                    rg_Attendence.Visible = false;
                    btn_Save.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Attendance3", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
}