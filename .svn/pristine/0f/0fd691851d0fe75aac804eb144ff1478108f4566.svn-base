using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Data;
using Telerik.Web.UI;


public partial class Payroll_frm_leavetran : System.Web.UI.Page
{
    int i;
    string emp, empname;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Session.Remove("WRITEFACILITY");

            SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

            _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
            _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
            _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Leave Reports");//ALL LEAVE DATA ");
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
                rg_EmployeeLeavedetail.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                //btn_Save.Visible = false;
                //btn_Update.Visible = false;
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
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leavetran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    protected void rtn_Reportlist_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            switch (rtn_Reportlist.SelectedValue)
            {
                case "0":
                    Rm_RT_page.SelectedIndex = 1;
                    loadDropdown();
                    break;
                case "1":
                    Rm_RT_page.SelectedIndex = 2;
                    LoadLeaveTypes();
                    break;
                case "3":
                    Rm_RT_page.SelectedIndex = 3;
                    _loadBusinessunit();
                    break;
                default:
                    return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leavetran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void loadDropdown()
    {
        try
        {
            rcmb_BusinessUnit.Items.Clear();
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            rcmb_BusinessUnit.DataSource = dt_BUDetails;
            rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BusinessUnit.DataBind();
            rcmb_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leavetran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void LoadLeaveTypes()
    {
        try
        {
            rcmb_Leaves.Items.Clear();
            SMHR_LEAVEMASTER _obj_Smhr_LeaveMaster = new SMHR_LEAVEMASTER();
            _obj_Smhr_LeaveMaster.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            rcmb_Leaves.DataSource = BLL.get_LeaveMaster(_obj_Smhr_LeaveMaster);
            rcmb_Leaves.DataTextField = "LEAVEMASTER_CODE";
            rcmb_Leaves.DataValueField = "LEAVEMASTER_ID";
            rcmb_Leaves.DataBind();
            rcmb_Leaves.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leavetran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void _loadBusinessunit()
    {
        try
        {
            rcmb_BU.Items.Clear();
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            rcmb_BU.DataSource = dt_BUDetails;
            rcmb_BU.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BU.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BU.DataBind();
            rcmb_BU.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leavetran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_BusinessUnit_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rcmb_Employee.Items.Clear();
            SMHR_LEAVEAPP _obj_Smhr_LeaveApp = new SMHR_LEAVEAPP();
            _obj_Smhr_LeaveApp.MODE = 2;
            _obj_Smhr_LeaveApp.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
            DataTable dt = BLL.get_EmpLeaveDetails(_obj_Smhr_LeaveApp);
            rcmb_Employee.DataSource = dt;
            rcmb_Employee.DataTextField = "EMPNAME";
            rcmb_Employee.DataValueField = "EMP_ID";
            rcmb_Employee.DataBind();
            rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            // if we select other businessunit only employees get loading but grid is not refreshing
            rg_EmployeeWise.DataSource = null;
            rg_EmployeeWise.DataBind();
            rg_EmployeeWise.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leavetran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_Employee_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            SMHR_LEAVEBALANCE _obj_smhr_leavebal = new SMHR_LEAVEBALANCE();
            _obj_smhr_leavebal.MODE = 1;
            _obj_smhr_leavebal.LT_EMPID = Convert.ToInt32(rcmb_Employee.SelectedItem.Value);

            rg_EmployeeWise.DataSource = BLL.get_leavebalances(_obj_smhr_leavebal);
            rg_EmployeeWise.DataBind();
            rg_EmployeeWise.Visible = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leavetran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void rcmb_Leaves_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            SMHR_LEAVEBALANCE _obj_smhr_leavebal = new SMHR_LEAVEBALANCE();
            _obj_smhr_leavebal.MODE = 2;
            _obj_smhr_leavebal.LT_LEAVETYPEID = Convert.ToInt32(rcmb_Leaves.SelectedItem.Value);

            rg_leavetypewise.DataSource = BLL.get_leavebalances(_obj_smhr_leavebal);
            rg_leavetypewise.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leavetran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_BU_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rcmb_emp.Items.Clear();
            SMHR_LEAVEAPP _obj_Smhr_LeaveApp = new SMHR_LEAVEAPP();
            _obj_Smhr_LeaveApp.MODE = 2;
            _obj_Smhr_LeaveApp.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);

            rcmb_emp.DataSource = BLL.get_EmpLeaveDetails(_obj_Smhr_LeaveApp);
            rcmb_emp.DataTextField = "EMPNAME";
            rcmb_emp.DataValueField = "EMP_ID";
            rcmb_emp.DataBind();
            rcmb_emp.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
            rg_EmployeeLeavedetail.Visible = false;
            rd_Periodlist.ClearSelection();

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leavetran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rd_Periodlist_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            switch (rd_Periodlist.SelectedValue)
            {
                case "1":
                    i = 1;
                    ShowEmployeeLeaveDetailsGrid();
                    break;
                case "3":
                    i = 3;
                    ShowEmployeeLeaveDetailsGrid();
                    break;
                case "6":
                    i = 6;
                    ShowEmployeeLeaveDetailsGrid();
                    break;
                case "12":
                    i = 12;
                    ShowEmployeeLeaveDetailsGrid();
                    break;
                default:
                    return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leavetran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void ShowEmployeeLeaveDetailsGrid()
    {
        try
        {
            string emp;

            SMHR_LEAVEBALANCE _obj_smhr_leavebal = new SMHR_LEAVEBALANCE();
            _obj_smhr_leavebal.MODE = 3;
            if (rcmb_emp.SelectedIndex <= 0)
            {
                BLL.ShowMessage(this, "Select Business Unit and Employee then check the Balance");
                rd_Periodlist.ClearSelection();
                return;
            }
            _obj_smhr_leavebal.LT_EMPID = Convert.ToInt32(rcmb_emp.SelectedItem.Value);
            if (_obj_smhr_leavebal.LT_EMPID <= 0)
            {
                BLL.ShowMessage(this, "Select An Employee");
                rg_EmployeeLeavedetail.Visible = false;
                return;
            }
            _obj_smhr_leavebal.Months = i;

            rg_EmployeeLeavedetail.DataSource = BLL.get_leavebalances(_obj_smhr_leavebal);
            rg_EmployeeLeavedetail.DataBind();
            rg_EmployeeLeavedetail.Visible = true;

            Label lbl = (Label)FindControlIterative(rg_EmployeeLeavedetail, "lbl_Header");
            emp = rcmb_emp.SelectedItem.Text;
            if (lbl != null)
            {
                string[] T = emp.Split(new char[] { '-' });
                empname = T[1];
                //lbl.Text = "LEAVE TRANSACTION DETAILS OF " + empname + by bharat
                //for displaying name on top of the grid
                lbl.Text = "Leave Transaction Details Of " + emp +
                (Label)rg_EmployeeLeavedetail.MasterTableView.FindControl("lbl_Header");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leavetran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected Control FindControlIterative(Control myRoot, string myIDOfControlToFind)
    {
        try
        {
            Control myRootControl = new Control();
            myRootControl = myRoot;
            LinkedList<Control> setOfChildControls = new LinkedList<Control>();

            while ((myRootControl != null))
            {
                if (myRootControl.ID == myIDOfControlToFind)
                {
                    return myRootControl;
                }
                foreach (Control childControl in myRootControl.Controls)
                {
                    if (childControl.ID == myIDOfControlToFind)
                    {
                        return childControl;
                    }
                    if (childControl.HasControls())
                    {
                        setOfChildControls.AddLast(childControl);
                    }
                }
                myRootControl = setOfChildControls.First.Value;
                setOfChildControls.Remove(myRootControl);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leavetran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

        return null;
    }

    protected void rg_EmployeeLeavedetail_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        try
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                string strText = Convert.ToString(((System.Data.DataRowView)(e.Item.DataItem)).Row.ItemArray[1]);// item..ToString();
                switch (strText)
                {
                    case "PENDING":
                        item.ForeColor = System.Drawing.Color.Orchid;
                        break;
                    case "APPROVED":
                        item.ForeColor = System.Drawing.Color.Green;
                        break;
                    case "REJECTED":
                        item.ForeColor = System.Drawing.Color.Black;
                        break;
                    case "CANCELLED":
                        item.ForeColor = System.Drawing.Color.Red;
                        break;
                    default:
                        return;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leavetran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    //bharadwaj.
    // as we are dispalying the data based on the employee selection
    // but at present we are displaying the data relavent to the employee when radio button selection changed
    protected void rcmb_emp_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_BU.SelectedIndex > 0)
            {
                if (rcmb_emp.Items.Count > 0)
                {
                    if (Convert.ToInt32(rcmb_emp.SelectedItem.Value) <= 0)
                    {
                        rg_EmployeeLeavedetail.Visible = false;
                        rg_EmployeeLeavedetail.DataSource = null;
                        rg_EmployeeLeavedetail.DataBind();
                        rd_Periodlist.ClearSelection();

                    }
                    else
                    {
                        rd_Periodlist_SelectedIndexChanged(null, null);
                    }
                }

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leavetran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
}
