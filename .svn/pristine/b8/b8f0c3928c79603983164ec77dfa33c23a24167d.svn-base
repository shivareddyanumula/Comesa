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
using SMHR;

public partial class Payroll_frm_Gratuity : System.Web.UI.Page
{
    SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
    SMHR_GRATUITY _obj_smhr_gratuity = new SMHR_GRATUITY();
    DataTable dt_Payitems = new DataTable();
    #region Pageload
    /// <summary>
    /// this will loads all business units corresponding with the user login
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                DateTime dt = new DateTime();
                dt = DateTime.Now;
                rdtp_Period.SelectedDate = dt;
                DataTable dt_Businessunit = new DataTable();
                //rdtp_Period.Enabled = true;
                _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                _obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"].ToString());
                dt_Businessunit = BLL.get_Business_Units(_obj_smhr_logininfo);
                rcmb_Businessunit.DataSource = dt_Businessunit;
                rcmb_Businessunit.DataTextField = "BUSINESSUNIT_CODE";
                rcmb_Businessunit.DataValueField = "BUSINESSUNIT_ID";
                rcmb_Businessunit.DataBind();
                rcmb_Businessunit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                if (Convert.ToString(Session["EMP_TYPE"]) == "10")
                {

                    rlist_Payitems.Visible = false;
                    rdtp_Period.Visible = false;
                    btn_Approve.Visible = true;
                    // btn_Reject.Visible = true;
                    btn_Approve.Enabled = true;
                    DataTable dt_BUDetails = new DataTable();
                    lbl_Period.Visible = false;
                    lbl_Payitems.Visible = false;
                    LBL_SYMBOL0.Visible = false;
                    LBL_SYMBOL1.Visible = false;
                    btn_Calculate.Visible = false;
                    btn_Save.Visible = false;
                    btn_Cancel.Visible = true;
                    rcmb_Businessunit.Items.Clear();
                    _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    dt_BUDetails = BLL.get_Business_Units(_obj_smhr_logininfo);
                    rcmb_Businessunit.DataSource = dt_BUDetails;
                    rcmb_Businessunit.DataTextField = "BUSINESSUNIT_CODE";
                    rcmb_Businessunit.DataValueField = "BUSINESSUNIT_ID";
                    rcmb_Businessunit.DataBind();
                    rcmb_Businessunit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                }
                else
                {
                    rlist_Payitems.Enabled = false;
                    btn_Calculate.Enabled = false;
                    btn_Save.Visible = true;
                    btn_Cancel.Visible = true;
                }
                rlist_Payitems.Enabled = false;
                btn_Calculate.Enabled = false;
                btn_Approve.Enabled = false;
                btn_Reject.Enabled = false;
                btn_Save.Enabled = false;
                btn_Cancel.Enabled = false;

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Gratuity", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion
    #region Selection of Payitems For Gratuity
    /// <summary>
    /// For selection of the elements while calculating the gratuity
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rlist_Payitems_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            rg_Gratuity.DataSource = null;
            rg_Gratuity.DataBind();
            rg_Gratuity.Visible = false;
            btn_Calculate.Enabled = false;
            btn_Calculate.Visible = true;
            btn_Save.Visible = false;
            RadioButtonList payitem = new RadioButtonList();
            payitem = (RadioButtonList)sender;
            if (payitem.SelectedIndex == 0)
            {
                chklst_Payitems.Items.Clear();
                btn_Calculate.Enabled = true;
                btn_Calculate.Visible = true;
            }
            else
            {
                _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                _obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"].ToString());
                _obj_smhr_logininfo.BUID = Convert.ToInt32(rcmb_Businessunit.SelectedValue.ToString());
                dt_Payitems = BLL.get_PayItemdtls(_obj_smhr_logininfo);
                chklst_Payitems.DataSource = dt_Payitems.DefaultView;
                chklst_Payitems.DataTextField = "PAYITEM_PAYDESC";
                chklst_Payitems.DataValueField = "PAYITEM_ID";
                chklst_Payitems.DataBind();
                btn_Calculate.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Gratuity", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    #endregion

    #region Businessunit Selction
    /// <summary>
    /// this method will show functionality based on the login type
    /// </summary>
    /// <param name="o"></param>
    /// <param name="e"></param>
    protected void rcmb_Businessunit_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (Convert.ToString(Session["EMP_TYPE"]) == "10")
            {
                rg_Gratuity.Visible = true;
                rlist_Payitems.Visible = false;
                chklst_Payitems.Visible = false;
                btn_Calculate.Visible = false;
                btn_Cancel.Visible = true;
                btn_Cancel.Enabled = true;
                btn_Save.Visible = false;
                btn_Approve.Enabled = true;
                btn_Approve.Visible = true;
                btn_Save.Visible = false;
                lbl_Payitems.Visible = false;
                lbl_Period.Visible = false;

                if (rcmb_Businessunit.SelectedIndex == 0)
                {
                    BLL.ShowMessage(this, "Select A Businessunit");
                    rlist_Payitems.Enabled = false;
                    btn_Calculate.Enabled = false;
                    btn_Approve.Enabled = false;
                    rg_Gratuity.Visible = false;
                    rlist_Payitems.ClearSelection();
                }
                else
                {
                    DataTable dt = new DataTable();
                    _obj_smhr_gratuity.EMP_BUID = Convert.ToInt32(rcmb_Businessunit.SelectedValue.ToString());
                    dt = BLL.get_gratuityemp(_obj_smhr_gratuity);
                    if (dt.Rows.Count > 0)
                    {
                        rg_Gratuity.DataSource = dt;
                        rg_Gratuity.DataBind();
                        for (int index = 0; index < rg_Gratuity.Items.Count; index++)
                        {
                            CheckBox c = (CheckBox)rg_Gratuity.Items[index].FindControl("Chk_Check");
                            c.Checked = false;
                            c.Enabled = false;
                        }
                    }
                    else
                    {
                        BLL.ShowMessage(this, "All Employees Were Approved For The Selected Business unit");
                        btn_Approve.Enabled = false;
                        rg_Gratuity.DataSource = null;
                        rg_Gratuity.DataBind();
                        rg_Gratuity.Visible = false;
                    }
                }
            }
            else
            {
                chklst_Payitems.Items.Clear();
                rg_Gratuity.Visible = false;
                btn_Calculate.Enabled = false;
                btn_Calculate.Visible = true;
                btn_Save.Visible = false;
                rg_Gratuity.DataSource = null;
                rlist_Payitems.ClearSelection();
                rg_Gratuity.Visible = false;
                if (rcmb_Businessunit.SelectedIndex == 0)
                {
                    BLL.ShowMessage(this, "Select A Businessunit");
                    rlist_Payitems.Enabled = false;
                    btn_Calculate.Enabled = false;
                    rlist_Payitems.ClearSelection();
                }
                else
                {
                    rlist_Payitems.Enabled = true;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Gratuity", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion
    #region Calculating Gratuity
    /// <summary>
    /// this method will calculate the gratuity of corresponding businessunit
    /// based on the selected payitem
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_Calculate_Click(object sender, EventArgs e)
    {
        try
        {
            bool flag = false;
            string payitems = "";
            int count = 0;
            DataTable dt_grid = new DataTable();
            string payitemid = "";
            bool exist = false;
            string PERIOD = rdtp_Period.SelectedDate.ToString();
            if (rlist_Payitems.SelectedIndex == 1)
            {
                bool Payitem;
                int last = chklst_Payitems.Items.Count;
                for (int i = 0, counts = 0; i < chklst_Payitems.Items.Count; i++)
                {
                    Payitem = chklst_Payitems.Items[i].Selected;
                    if (Payitem)
                    {
                        if (counts == 0)
                        {
                            payitems = chklst_Payitems.SelectedValue.ToString();
                            counts++;
                        }
                        else
                        {
                            payitemid = chklst_Payitems.Items[i].Value;

                        }
                        payitemid = payitems + "," + payitemid;
                    }
                }
                if (payitemid == string.Empty)
                {
                    BLL.ShowMessage(this, "Select A PayItem!");
                    //btn_Calculate.Enabled = false;
                    rg_Gratuity.Visible = false;

                }
                _obj_smhr_gratuity.EMP_PAYITEM = payitemid;
            }
            else
            {
                _obj_smhr_gratuity.EMP_PAYITEM = rlist_Payitems.SelectedValue.ToString();
            }
            DataTable dt_Calculation = new DataTable();//FOR CALCULATING 
            _obj_smhr_gratuity.SELECTED_PERIOD = Convert.ToDateTime(rdtp_Period.SelectedDate.ToString());
            _obj_smhr_gratuity.EMP_BUID = Convert.ToInt32(rcmb_Businessunit.SelectedValue.ToString());
            dt_Calculation = BLL.get_empgratuity(_obj_smhr_gratuity);
            if (dt_Calculation.Rows.Count > 0)
            {

                DataTable dt_emp = new DataTable();

                dt_emp = BLL.get_emp(_obj_smhr_gratuity);//validate2
                if (dt_emp.Rows.Count > 0)
                {
                    exist = true;
                    foreach (DataRow dr in dt_Calculation.Rows)
                    {
                        for (int compare = 0; compare < dt_emp.Rows.Count; compare++)
                        {
                            if (dr["EMP_ID"].ToString() == dt_emp.Rows[compare]["EMP_ID"].ToString())
                            {
                                flag = false;
                                count = 1;
                                DataTable dt_exist = new DataTable();
                                _obj_smhr_gratuity.EMP_ID = Convert.ToInt32(dr["EMP_ID"].ToString());
                                dt_exist = BLL.get_Employee(_obj_smhr_gratuity);//already got persons
                                if (dt_exist.Rows.Count > 0)
                                {
                                    if (dr["EMP_ID"].ToString() == dt_exist.Rows[compare]["EMP_ID"].ToString())
                                    {
                                        flag = true;
                                        dr["COMPLETION_DATE"] = Convert.ToDateTime(dt_exist.Rows[0]["COMPLETION_DATE"].ToString());
                                        return;
                                    }
                                }
                            }
                        }
                        if (flag)
                        {
                            dt_grid.Rows.Add(dr);
                        }
                        if ((count == 1) && (flag == false))
                        {
                            dr.Delete();
                        }
                    }
                    //if (flag == false)
                    //{
                    //    BLL.ShowMessage(this, "All Employee Taken The Gratuity In The Selected Businessunit!");
                    //}
                }
                else
                {
                    if (exist == false)
                    {
                        rg_Gratuity.DataSource = dt_Calculation;
                        rg_Gratuity.DataBind();
                        DateTime dt = new DateTime();
                        dt = DateTime.Now;
                        int year = dt.Year;
                        int month = dt.Month;
                        int max = Convert.ToInt32(DateTime.DaysInMonth(year, month));
                        rg_Gratuity.Visible = true;
                        int diff = (rdtp_Period.SelectedDate.Value.Day);
                        if (diff == max)
                        {
                            btn_Save.Visible = true;
                            btn_Calculate.Visible = false;
                            btn_Save.Enabled = true;
                            btn_Cancel.Visible = true;
                            btn_Cancel.Enabled = true;
                        }
                        return;
                    }
                }
            }
            else
            {
                BLL.ShowMessage(this, "No Employee Is Having More Than Five Years Of Service Till The Selected Date");
            }
            DateTime dt1 = new DateTime();
            dt1 = DateTime.Now;
            int currentyear = dt1.Year;
            int currentmonth = dt1.Month;
            int maxofcurrent = Convert.ToInt32(DateTime.DaysInMonth(currentyear, currentmonth));
            rg_Gratuity.Visible = true;
            // ViewState["Grid"] = dt_Calculation;//
            if (dt_grid.Rows.Count > 0)
            {
                rg_Gratuity.DataSource = dt_grid;
                rg_Gratuity.DataBind();
            }
            else
            {
                BLL.ShowMessage(this, "No Employee Has Finished Five Years Till The Selected Month!");
                btn_Save.Enabled = false;
                rg_Gratuity.Visible = false;
            }
            btn_Calculate.Visible = false;
            btn_Save.Visible = true;
            btn_Cancel.Visible = false;

            int selected = (rdtp_Period.SelectedDate.Value.Day);
            if (selected == maxofcurrent)
            {
                btn_Save.Enabled = true;
                btn_Cancel.Visible = true;
                btn_Cancel.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Gratuity", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion
    #region Sending For Approval
    /// <summary>
    /// this will send the employee who are selected by the hr person 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            // string semp = "";
            // string sall = "";
            int count = 0;
            bool flag = false;
            int exist = 0;
            for (int index = 0; index < rg_Gratuity.Items.Count; index++)
            {
                CheckBox CHECK = new CheckBox();
                CHECK = rg_Gratuity.Items[index].FindControl("chk_Check") as CheckBox;
                if (CHECK.Checked)
                {
                    //GridViewRow row = rg_Gratuity.Items[index];      

                    //rg_Gratuity.Columns.Remove[index];
                    flag = true;
                    _obj_smhr_gratuity.OPERATION = operation.Insert;
                    _obj_smhr_gratuity.EMP_ID = Convert.ToInt32(rg_Gratuity.Items[index]["EMP_ID"].Text);
                    _obj_smhr_gratuity.EMP_COMPLETION = Convert.ToDateTime(rg_Gratuity.Items[index]["COMPLETION_DATE"].Text);
                    _obj_smhr_gratuity.Emp_name = rg_Gratuity.Items[index]["EMP_NAME"].Text;
                    _obj_smhr_gratuity.BUID = Convert.ToInt32(rcmb_Businessunit.SelectedValue.ToString());
                    _obj_smhr_gratuity.Emp_exp = Convert.ToInt32(rg_Gratuity.Items[index]["EXPERIENCE"].Text);
                    _obj_smhr_gratuity.EMP_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_Businessunit.SelectedValue.ToString());
                    _obj_smhr_gratuity.Emp_amount = Convert.ToDouble(Convert.ToString(rg_Gratuity.Items[index]["AMOUNT"].Text));
                    _obj_smhr_gratuity.EMP_DOJ = Convert.ToDateTime(rg_Gratuity.Items[index]["DOJ"].Text);
                    //_obj_smhr_gratuity.EMP_COMPLETION = Convert.ToDateTime(dt_exist.Rows[0]["COMPLETION_DATE"].ToString());
                    //_obj_smhr_gratuity.EMP_COMPLETION = Convert.ToDateTime(rg_Gratuity.Items[index]["COMPLETION_DATE"].ToString());
                    _obj_smhr_gratuity.EMP_PERIOD = DateTime.Now;
                    int Iresult = Convert.ToInt32(BLL.set_Gratutityemp(_obj_smhr_gratuity));
                    if (Iresult > 0)
                    {
                        exist += Iresult;
                        CHECK = rg_Gratuity.Items[index].FindControl("chk_Check") as CheckBox;
                        CHECK.Enabled = false;
                        CHECK.Checked = false;
                        //    CHECK.Text = "Approved";
                        rg_Gratuity.Items[index].Visible = false;

                    }
                }
            }

            if (flag == true)
            {
                BLL.ShowMessage(this, "" + exist + "  Employees Sent For Approval!");
            }
            else
            {
                BLL.ShowMessage(this, "Select Employee To Sent Them For Approval!");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Gratuity", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion
    #region Check All
    /// <summary>
    /// For Checking The All Rows
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Chk_All_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i <= rg_Gratuity.Items.Count - 1; i++)
            {
                CheckBox Chk_All = (CheckBox)sender;
                if (Convert.ToString(Session["EMP_TYPE"]) == "10")
                {
                    Chk_All.Enabled = false;
                    Chk_All.Checked = false;
                    for (int index = 0; index < rg_Gratuity.Items.Count; index++)
                    {
                        CheckBox c = (CheckBox)rg_Gratuity.Items[index].FindControl("Chk_Check");
                        c.Enabled = false;
                        c.Checked = false;
                    }
                }
                else
                {
                    if (Chk_All.Checked)
                    {
                        for (int index = 0; index < rg_Gratuity.Items.Count; index++)
                        {
                            CheckBox c = (CheckBox)rg_Gratuity.Items[index].FindControl("Chk_Check");
                            if (c.Visible != false)
                            {
                                c.Checked = true;
                            }
                        }
                    }
                    else
                    {
                        for (int index = 0; index < rg_Gratuity.Items.Count; index++)
                        {
                            CheckBox c = (CheckBox)rg_Gratuity.Items[index].FindControl("Chk_Check");
                            c.Checked = false;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Gratuity", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            rlist_Payitems.ClearSelection();
            rg_Gratuity.Visible = false;
            rcmb_Businessunit.SelectedIndex = 0;
            btn_Save.Enabled = false;
            chklst_Payitems.ClearSelection();
            btn_Calculate.Enabled = false;
            rlist_Payitems.Enabled = false;
            btn_Approve.Enabled = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Gratuity", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Approve_Click(object sender, EventArgs e)
    {
        try
        {
            int count = 0;
            for (int index = 0; index < rg_Gratuity.Items.Count; index++)
            {
                _obj_smhr_gratuity.OPERATION = operation.Update;
                _obj_smhr_gratuity.EMP_ID = Convert.ToInt32(rg_Gratuity.Items[index]["EMP_ID"].Text);
                _obj_smhr_gratuity.Emp_status = 1;
                int Iresult = Convert.ToInt32(BLL.set_Gratutityemp(_obj_smhr_gratuity));
                if (Iresult >= 1)
                {
                    count++;
                }
            }
            BLL.ShowMessage(this, "Total Records Approved Are:" + count);
            btn_Approve.Enabled = false;
            rg_Gratuity.DataSource = null;
            rg_Gratuity.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Gratuity", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #region Showing Window
    /// <summary>
    /// Displaying history
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtn_History_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "Gratuity_History()", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Gratuity", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion
}
