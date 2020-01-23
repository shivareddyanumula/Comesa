using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using Telerik.Web.UI;
using System.Text;
using System.Collections;

public partial class Payroll_Default : System.Web.UI.Page
{
    SMHR_BUSINESSUNIT _obj_smhr_businessunit;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    StringBuilder strQry = new StringBuilder();
    SMHR_PERIOD _obj_smhr_period;
    SMHR_LEAVESTRUCT _obj_smhr_leaveStruct;
    static int bu = 0;
    static int period = 0;
    static int leaveStruct = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                LoadCombos();
                loadLeaveStruct();

            }


            Session.Remove("WRITEFACILITY");

            SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

            _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
            _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
            _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("LEAVE OPENING BALANCES");
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
                RG_Details.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                RG_Details.Enabled = false;


            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Default", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    private void getData()
    {
        try
        {
            DataTable dt;
            if (ViewState["DataTable"] == null)
            {
                dt = BLL.get_EmpLOB(Convert.ToInt32(Session["ORG_ID"]), Convert.ToInt32(rcmb_BUID.SelectedItem.Value), Convert.ToInt32(rcmb_Period.SelectedItem.Value), Convert.ToInt32(rcmbLeaveStruct.SelectedValue));
                ViewState["DataTable"] = dt;
            }
            else
            {
                if (rcmbLeaveStruct.SelectedItem.Value == "")
                {
                    dt = ViewState["DataTable"] as DataTable;
                }
                else
                {
                    if ((bu == Convert.ToInt32(rcmb_BUID.SelectedItem.Value)) && (period == Convert.ToInt32(rcmb_Period.SelectedItem.Value)) && (leaveStruct == Convert.ToInt32(rcmbLeaveStruct.SelectedItem.Value)))
                    {
                        dt = ViewState["DataTable"] as DataTable;
                    }
                    else
                    {
                        dt = BLL.get_EmpLOB(Convert.ToInt32(Session["ORG_ID"]), Convert.ToInt32(rcmb_BUID.SelectedItem.Value), Convert.ToInt32(rcmb_Period.SelectedItem.Value), Convert.ToInt32(rcmbLeaveStruct.SelectedValue));
                        ViewState["DataTable"] = dt;
                        bu = Convert.ToInt32(rcmb_BUID.SelectedItem.Value);
                        period = Convert.ToInt32(rcmb_Period.SelectedItem.Value);
                        leaveStruct = Convert.ToInt32(rcmbLeaveStruct.SelectedItem.Value);
                    }
                }
            }
            RG_Details.DataSource = dt;

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Default", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void LoadCombos()
    {
        try
        {
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);

            rcmb_BUID.DataSource = dt_BUDetails;
            rcmb_BUID.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BUID.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BUID.DataBind();
            rcmb_BUID.Items.Insert(0, new RadComboBoxItem("Select", "0"));

            _obj_smhr_period = new SMHR_PERIOD();
            DataTable dt_Details = new DataTable();
            _obj_smhr_period.OPERATION = operation.Select;
            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_PeriodHeaderDetails_Calendar(_obj_smhr_period);
            rcmb_Period.DataSource = dt_Details;
            rcmb_Period.DataValueField = "PERIOD_ID";
            rcmb_Period.DataTextField = "PERIOD_NAME";
            rcmb_Period.DataBind();
            rcmb_Period.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Default", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void LoadPeriods()
    {
        try
        {
            _obj_smhr_period = new SMHR_PERIOD();
            DataTable dt_Details = new DataTable();
            _obj_smhr_period.OPERATION = operation.Select;
            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_PeriodHeaderDetails_Calendar(_obj_smhr_period);
            rcmb_Period.DataSource = dt_Details;
            rcmb_Period.DataValueField = "PERIOD_ID";
            rcmb_Period.DataTextField = "PERIOD_NAME";
            rcmb_Period.DataBind();
            rcmb_Period.Items.Insert(0, new RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Default", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void rcmb_BUID_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            LoadPeriods();
            loadLeaveStruct();
            if (!(rcmb_BUID.SelectedIndex > 0))
            {
                RG_Details.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Default", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void RG_Details_UpdateCommand(object source, GridCommandEventArgs e)
    {
        try
        {
            SMHR_LOB _obj_smhr_lob = new SMHR_LOB();
            GridEditableItem editedItem = e.Item as GridEditableItem;
            int index = editedItem.DataSetIndex;
            DataTable newTable = GridSource();
            Hashtable newValues = new Hashtable();
            string ID = e.Item.OwnerTableView.Items[index]["emp_id"].Text;
            DataRow[] ChangedRows = newTable.Select("emp_id = " + Convert.ToString(ID));
            e.Item.OwnerTableView.ExtractValuesFromItem(newValues, editedItem);
            ChangedRows[0].BeginEdit();
            foreach (DictionaryEntry entry in newValues)
            {
                ChangedRows[0][(string)entry.Key] = entry.Value;
            }
            ChangedRows[0].EndEdit();
            DataTable dt = (DataTable)ViewState["DataTable"];
            
            RG_Details.DataSource = dt;
            dt.PrimaryKey = new DataColumn[] { dt.Columns["emp_id"] };
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Default", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void RG_Details_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        //string strVal = Convert.ToString(rcmb_BUID.SelectedItem.Value);
        //DataTable dt = this.GridSource();
        //RG_Details.DataSource = dt;
        //dt.PrimaryKey = new DataColumn[] { dt.Columns["emp_id"] };
    }

    protected void RG_Details_PreRender(object sender, System.EventArgs e)
    {
        try
        {
            if (!this.IsPostBack)
            {
                this.RG_Details.EditIndexes.Add(1);
                this.RG_Details.MasterTableView.Rebind();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Default", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private DataTable GridSource()
    {
        DataTable dt=new DataTable();
        try
        {
             dt = (DataTable)ViewState["DataTable"];
            if (dt != null)
            {
                return (DataTable)dt;
            }
            //dt = BLL.get_EmpLOB(Convert.ToInt32(Session["ORG_ID"]));
            dt = BLL.get_EmpLOB(Convert.ToInt32(Session["ORG_ID"]), Convert.ToInt32(rcmb_BUID.SelectedItem.Value), Convert.ToInt32(rcmbLeaveStruct.SelectedItem.Value), Convert.ToInt32(rcmb_Period.SelectedItem.Value));
            ViewState["DataTable"] = dt;
            RG_Details.DataSource = dt;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Default", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            //return;
        }
        return dt;
    }
    protected void RG_Details_ColumnCreated(object sender, GridColumnCreatedEventArgs e)
    {
        try
        {
            GridBoundColumn boundColumn = e.Column as GridBoundColumn;
            //if (e.Column.HeaderText == "EMP_ID")
            //{
            //    e.Column.Visible = false;
            //    boundColumn.ReadOnly = true;


            //}
            switch (e.Column.HeaderText)
            {
                case "EMP_ID":
                    {
                        e.Column.Visible = false;
                        boundColumn.ReadOnly = true;
                        break;
                    }
                case "EMPLOYEE CODE":
                    {
                        //e.Column.Visible = false;
                        boundColumn.ReadOnly = true;
                        break;
                    }
                case "EMPLOYEE NAME":
                    {
                        //e.Column.Visible = false;
                        boundColumn.ReadOnly = true;
                        break;
                    }
                case "DATE OF JOIN":
                    {
                        e.Column.Visible = false;
                        boundColumn.ReadOnly = true;
                        break;
                    }
                default: break;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Default", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void btn_Finalise_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_LOB _obj_smhr_lob = new SMHR_LOB();
            btn_Finalise.Enabled = true;

            for (int i = 0; i < RG_Details.Items.Count; i++)
            {
                _obj_smhr_lob.LOB_EMPID = null;
                for (int j = 0; j < RG_Details.MasterTableView.AutoGeneratedColumns.Count() - 4; j++)
                {
                    strQry.Append("EXEC USP_SMHR_LEAVEOPENINGBALANCES ");
                    _obj_smhr_lob.LOB_EMPID = Convert.ToInt32(RG_Details.Items[i]["EMP_ID"].Text);
                    string LT = Convert.ToString(RG_Details.MasterTableView.AutoGeneratedColumns[j + 4].UniqueName);
                    string[] T = LT.Split(new char[] { '-' });
                    _obj_smhr_lob.LOB_LEAVETYPEID = Convert.ToInt32(T[0]);
                    _obj_smhr_lob.LOB_NOOFDAYS = Convert.ToInt32(RG_Details.Items[i][LT].Text);
                    _obj_smhr_lob.LOB_FINALISE = 1;
                    _obj_smhr_lob.LOB_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_lob.LOB_CREATEDDATE = System.DateTime.Now;
                    _obj_smhr_lob.LOB_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_lob.LOB_LASTMDFDATE = System.DateTime.Now;
                    _obj_smhr_lob.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_lob.OPERATION = operation.Insert;
                    string str = "@Operation = 'UPDATE'" +
                                 ",@LOB_EMPID = '" + _obj_smhr_lob.LOB_EMPID + "'" +
                                 ",@LOB_LEAVETYPEID = '" + _obj_smhr_lob.LOB_LEAVETYPEID + "'" +
                                 ",@LOB_NOOFDAYS = '" + _obj_smhr_lob.LOB_NOOFDAYS + "'" +
                                 ",@LOB_FINALISE = '" + _obj_smhr_lob.LOB_FINALISE + "'" +
                                 ",@LOB_CREATEDBY = '" + _obj_smhr_lob.LOB_CREATEDBY + "'" +
                                 ",@LOB_CREATEDDATE = '" + _obj_smhr_lob.LOB_CREATEDDATE + "'" +
                                 ",@LOB_LASTMDFBY = '" + _obj_smhr_lob.LOB_LASTMDFBY + "'" +
                                 ",@LOB_LASTMDFDATE = '" + _obj_smhr_lob.LOB_LASTMDFDATE + "'" +
                                 ",@LOB_ORGANISATIONID='" + _obj_smhr_lob.ORGANISATION_ID + "'";
                    strQry.Append(str);

                }

            }
            bool rs = BLL.set_EMpLOB(_obj_smhr_lob, strQry.ToString());
            if (rs == true)
            {
                BLL.ShowMessage(this, "Leave Opening Balances finalised Successfully");
                btn_Finalise.Enabled = false;
            }
            else
                BLL.ShowMessage(this, "Error found");
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Default", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
       
    protected void btn_Update_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_LOB _obj_smhr_lob = new SMHR_LOB();
            btn_Finalise.Enabled = true;
            StringBuilder strQry = new StringBuilder();

            for (int i = 0; i < RG_Details.Items.Count; i++)
            {
                _obj_smhr_lob.LOB_EMPID = null;
                //_obj_smhr_lob.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //_obj_smhr_lob.LOB_PERIODID = Convert.ToInt32(rcmb_Period.SelectedItem.Value);

                for (int j = 0; j < RG_Details.MasterTableView.AutoGeneratedColumns.Count() - 4; j++)
                {
                    strQry.Append("EXEC USP_SMHR_LEAVEOPENINGBALANCES ");
                    _obj_smhr_lob.LOB_EMPID = Convert.ToInt32(RG_Details.Items[i]["EMP_ID"].Text);
                    string LT = Convert.ToString(RG_Details.MasterTableView.AutoGeneratedColumns[j + 4].UniqueName);
                    string[] T = LT.Split(new char[] { '-' });
                    _obj_smhr_lob.LOB_LEAVETYPEID = Convert.ToInt32(T[0]);
                    _obj_smhr_lob.LOB_NOOFDAYS = Convert.ToInt32(RG_Details.Items[i][LT].Text);
                    _obj_smhr_lob.LOB_FINALISE = 0;
                    _obj_smhr_lob.LOB_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_lob.LOB_CREATEDDATE = System.DateTime.Now;
                    _obj_smhr_lob.LOB_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_lob.LOB_LASTMDFDATE = System.DateTime.Now;
                    _obj_smhr_lob.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_lob.LOB_PERIODID = Convert.ToInt32(rcmb_Period.SelectedItem.Value);
                    _obj_smhr_lob.OPERATION = operation.Update;
                    string str = "@Operation = 'Update'" +
                                 ",@LOB_EMPID = '" + _obj_smhr_lob.LOB_EMPID + "'" +
                                 ",@LOB_LEAVETYPEID = '" + _obj_smhr_lob.LOB_LEAVETYPEID + "'" +
                                 ",@LOB_NOOFDAYS = '" + _obj_smhr_lob.LOB_NOOFDAYS + "'" +
                                 ",@LOB_FINALISE = '" + _obj_smhr_lob.LOB_FINALISE + "'" +
                                 ",@LOB_LASTMDFBY = '" + _obj_smhr_lob.LOB_LASTMDFBY + "'" +
                                 ",@LOB_LASTMDFDATE = '" + _obj_smhr_lob.LOB_LASTMDFDATE + "'" +
                                 ",@LOB_ORGANISATIONID='" + _obj_smhr_lob.ORGANISATION_ID + "'" +
                                 ",@LOB_PERIODID='" + _obj_smhr_lob.LOB_PERIODID + "'";
                    strQry.Append(str);
                }

            }
            bool rs = BLL.set_EMpLOB(_obj_smhr_lob, strQry.ToString());
            if (rs == true)
                BLL.ShowMessage(this, "Leave Opening Balances updated Successfully");
            else
                BLL.ShowMessage(this, "Error found");

            //RG_Details.DataBind();
            getData();
            RG_Details.DataBind();
            btn_Finalise.Visible = true;
            btn_Save.Enabled = false;
            btn_Update.Enabled = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Default", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_LOB _obj_smhr_lob = new SMHR_LOB();
            btn_Finalise.Enabled = true;
            StringBuilder strQry = new StringBuilder();

            for (int i = 0; i < RG_Details.Items.Count; i++)
            {
                _obj_smhr_lob.LOB_EMPID = null;

                for (int j = 0; j < RG_Details.MasterTableView.AutoGeneratedColumns.Count() - 4; j++)
                {
                    strQry.Append("EXEC USP_SMHR_LEAVEOPENINGBALANCES ");
                    _obj_smhr_lob.LOB_EMPID = Convert.ToInt32(RG_Details.Items[i]["EMP_ID"].Text);
                    string LT = Convert.ToString(RG_Details.MasterTableView.AutoGeneratedColumns[j + 4].UniqueName);
                    string[] T = LT.Split(new char[] { '-' });
                    _obj_smhr_lob.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_lob.LOB_PERIODID = Convert.ToInt32(rcmb_Period.SelectedItem.Value);
                    _obj_smhr_lob.LOB_LEAVETYPEID = Convert.ToInt32(T[0]);
                    _obj_smhr_lob.LOB_NOOFDAYS = Convert.ToInt32(RG_Details.Items[i][LT].Text);
                    _obj_smhr_lob.LOB_FINALISE = 0;
                    _obj_smhr_lob.LOB_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_lob.LOB_CREATEDDATE = System.DateTime.Now;
                    _obj_smhr_lob.LOB_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_lob.LOB_LASTMDFDATE = System.DateTime.Now;
                    _obj_smhr_lob.OPERATION = operation.Insert;
                    string str = "@Operation = 'Insert'" +
                                 ",@LOB_EMPID = '" + _obj_smhr_lob.LOB_EMPID + "'" +
                                 ",@LOB_ORGANISATIONID='" + _obj_smhr_lob.ORGANISATION_ID + "'" +
                                 ",@LOB_PERIODID='" + _obj_smhr_lob.LOB_PERIODID + "'" +
                                 ",@LOB_LEAVETYPEID = '" + _obj_smhr_lob.LOB_LEAVETYPEID + "'" +
                                 ",@LOB_NOOFDAYS = '" + _obj_smhr_lob.LOB_NOOFDAYS + "'" +
                                 ",@LOB_FINALISE = '" + _obj_smhr_lob.LOB_FINALISE + "'" +
                                 ",@LOB_CREATEDBY = '" + _obj_smhr_lob.LOB_CREATEDBY + "'" +
                                 ",@LOB_CREATEDDATE = '" + _obj_smhr_lob.LOB_CREATEDDATE + "'" +
                                 ",@LOB_LASTMDFBY = '" + _obj_smhr_lob.LOB_LASTMDFBY + "'" +
                                 ",@LOB_LASTMDFDATE = '" + _obj_smhr_lob.LOB_LASTMDFDATE + "'";
                    strQry.Append(str);
                }

            }
            bool rs = BLL.set_EMpLOB(_obj_smhr_lob, strQry.ToString());
            if (rs == true)
                BLL.ShowMessage(this, "Leave Opening Balances inserted Successfully");
            else
                BLL.ShowMessage(this, "Error found");

            getData();
            RG_Details.DataBind();
            btn_Finalise.Visible = true;
            btn_Save.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Default", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

    }
    private string InsertGridDetails(StringBuilder strQry)
    {
        try
        {
            SMHR_LOB _obj_smhr_lob = new SMHR_LOB();
            _obj_smhr_lob.OPERATION = operation.Delete;


            foreach (GridDataItem item in this.RG_Details.MasterTableView.Items)
            {
                _obj_smhr_lob.LOB_EMPID = Convert.ToInt32(item.Cells[2].Text);
                for (int j = 0; j < RG_Details.Columns.Count - 5; j++)
                {
                    strQry.Append("EXEC USP_SMHR_LEAVEOPENINGBALANCES ");
                    _obj_smhr_lob.LOB_EMPID = Convert.ToInt32(item.Cells[2].Text);
                    string LT = Convert.ToString(RG_Details.MasterTableView.Columns[j + 4].UniqueName);
                    string[] T = LT.Split(new char[] { '-' });
                    _obj_smhr_lob.LOB_LEAVETYPEID = Convert.ToInt32(T[0]);
                    _obj_smhr_lob.LOB_NOOFDAYS = Convert.ToInt32(item[LT].Text);
                    _obj_smhr_lob.LOB_FINALISE = 0;
                    _obj_smhr_lob.LOB_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_lob.LOB_CREATEDDATE = System.DateTime.Now;
                    _obj_smhr_lob.LOB_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_lob.LOB_LASTMDFDATE = System.DateTime.Now;
                    _obj_smhr_lob.OPERATION = operation.Insert;
                    string str = "@Operation = 'Insert'" +
                                 ",@LOB_EMPID = '" + _obj_smhr_lob.LOB_EMPID + "'" +
                                 ",@LOB_LEAVETYPEID = '" + _obj_smhr_lob.LOB_LEAVETYPEID + "'" +
                                 ",@LOB_NOOFDAYS = '" + _obj_smhr_lob.LOB_NOOFDAYS + "'" +
                                 ",@LOB_FINALISE = '" + _obj_smhr_lob.LOB_FINALISE + "'" +
                                 ",@LOB_CREATEDBY = '" + _obj_smhr_lob.LOB_CREATEDBY + "'" +
                                 ",@LOB_CREATEDDATE = '" + _obj_smhr_lob.LOB_CREATEDDATE + "'" +
                                 ",@LOB_LASTMDFBY = '" + _obj_smhr_lob.LOB_LASTMDFBY + "'" +
                                 ",@LOB_LASTMDFDATE = '" + _obj_smhr_lob.LOB_LASTMDFDATE + "'";
                    strQry.Append(str);

                }

            }
            
        }
            
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Default", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            //return;
        }
        return Convert.ToString(strQry); 
      
    }
    protected void rcmb_Period_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Period.SelectedIndex > 0)
            {
                loadLeaveStruct();
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Default", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void RG_Details_EditCommand(object source, GridCommandEventArgs e)
    {
        try
        {
            getData();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Default", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    public void loadLeaveStruct()
    {
        try
        {
            _obj_smhr_leaveStruct = new SMHR_LEAVESTRUCT();
            _obj_smhr_leaveStruct.OPERATION = operation.Select;
            _obj_smhr_leaveStruct.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtLeaveStruct = BLL.get_LeaveStructHeaderDetails(_obj_smhr_leaveStruct);
            if (dtLeaveStruct.Rows.Count > 0)
            {
                rcmbLeaveStruct.DataSource = dtLeaveStruct;
                rcmbLeaveStruct.DataTextField = "LEAVESTRUCT_CODE";
                rcmbLeaveStruct.DataValueField = "LEAVESTRUCT_ID";
                rcmbLeaveStruct.DataBind();
                rcmbLeaveStruct.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Default", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void rcmbLeaveStruct_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            //if (rcmb_BUID.SelectedItem.Value != "0")
            if (rcmb_BUID.SelectedIndex > 0)
            {
                //if (rcmb_Period.SelectedItem.Value != "0")
                if (rcmb_Period.SelectedIndex > 0)
                {
                    if (period == 0)
                    {
                        period = Convert.ToInt32(rcmb_Period.SelectedItem.Value);
                    }
                    getData();

                    RG_Details.DataBind();
                    RG_Details.Visible = true;
                    btn_Save.Visible = true;
                    btn_Save.Enabled = true;
                    if (RG_Details.Items.Count > 0)
                    {
                        btn_Save.Visible = true;
                    }
                    else
                    {
                        btn_Save.Visible = false;
                    }
                    btn_Update.Visible = false;
                    btn_Finalise.Visible = false;
                }
                else
                {
                    //getData();
                    //Rg_Details.DataBind();
                    RG_Details.Visible = false;
                    btn_Save.Visible = false;
                    //BLL.ShowMessage(this, "Select Period ");
                }
            }
            else
            {
                BLL.ShowMessage(this, "Select BusinessUnit");
            }
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                RG_Details.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                btn_Save.Visible = false;
                RG_Details.Enabled = false;


            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Default", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void lnkEdit(object sender, EventArgs e)
    {
        try
        {
            BLL.ShowMessage(this, "Grid");
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Default", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
}
