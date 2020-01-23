using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Data;
using Telerik.Web.UI;
using System.Text;

public partial class Payroll_frm_leaveopeningbalances : System.Web.UI.Page
{
    SMHR_BUSINESSUNIT _obj_smhr_businessunit;
    SMHR_PERIOD _obj_smhr_period;
    DataTable dt_details;
    SMHR_LOB _obj_smhr_lob;
    StringBuilder strQry = new StringBuilder();

    protected override void OnPreInit(EventArgs e)
    {
        base.OnPreInit(e);

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
            if (!Page.IsPostBack)
            {
                LoadCombos();
                //BLL.gridDateFormat(Convert.ToString(Session["EMP_ID"]), Rg_LOB, "EMPDOJ");
                btn_Finalise.Attributes.Add("onclick", "return confirmationSave();");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leaveopeningbalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        //var checkBox = Rg_LOB.Items[0][""].FindControl("boxControl");

        //if (checkBox != null)
        //    ajaxManager1.Alert("Control in template column found!");


    }

    void GetGridStructure()
    {
        try
        {
            DataTable dt;
            dt = BLL.get_EmpLOB(-1);

            Rg_LOB.Columns.Clear();

            GridBoundColumn GCol = new GridBoundColumn();
            GCol.DataField = "EMP_ID";
            GCol.HeaderText = "ID";
            GCol.UniqueName = "EMP_ID";
            GCol.Visible = false;
            Rg_LOB.Columns.Add(GCol);


            GCol = new GridBoundColumn();
            GCol.DataField = "EMP_CODE";
            GCol.HeaderText = "Employee Code";
            GCol.UniqueName = "EMP_CODE";
            Rg_LOB.Columns.Add(GCol);

            GCol = new GridBoundColumn();
            GCol.DataField = "EMP_NAME";
            GCol.HeaderText = "Employee Name";
            GCol.UniqueName = "EMP_NAME";
            Rg_LOB.Columns.Add(GCol);

            GCol = new GridBoundColumn();
            GCol.DataField = "EMP_DOJ";
            GCol.HeaderText = "Date of Join";
            GCol.UniqueName = "EMP_DOJ";
            Rg_LOB.Columns.Add(GCol);


            GridTemplateColumn GtCol;


            for (int i = 4; i < dt.Columns.Count; i++)
            {
                GtCol = new GridTemplateColumn();
                GtCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                GtCol.UniqueName = dt.Columns[i].ColumnName;
                GtCol.DataField = dt.Columns[i].ColumnName;
                GtCol.ItemTemplate = new myNTemplate(dt.Columns[i].ColumnName, i.ToString());
                //GtCol.ItemTemplate = new myNTemplate(i.ToString(),i.);
                char[] splitchar = { '-' };
                GtCol.HeaderText = dt.Columns[i].ColumnName.Split(splitchar)[1];
                Rg_LOB.Columns.Add(GtCol);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leaveopeningbalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }
    private void LoadCombos()
    {
        try
        {
            _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
            _obj_smhr_period = new SMHR_PERIOD();
            dt_details = new DataTable();

            _obj_smhr_businessunit.OPERATION = operation.Select;
            _obj_smhr_businessunit.ISDELETED = true;
            dt_details = BLL.get_BusinessUnit(_obj_smhr_businessunit);

            rcmb_BUID.DataSource = dt_details;
            rcmb_BUID.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BUID.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BUID.DataBind();
            rcmb_BUID.Items.Insert(0, new RadComboBoxItem("Select", "0"));


            _obj_smhr_period.OPERATION = operation.Select;
            dt_details = BLL.get_PeriodHeaderDetails(_obj_smhr_period);
            rcmb_Period.DataSource = dt_details;
            rcmb_Period.DataValueField = "PERIOD_ID";
            rcmb_Period.DataTextField = "PERIOD_NAME";
            rcmb_Period.DataBind();
            rcmb_Period.Items.Insert(0, new RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leaveopeningbalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void rcmb_BUID_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            SMHR_LOB _obj_smhr_lob = new SMHR_LOB();
            int BUID = Convert.ToInt32(rcmb_BUID.SelectedItem.Value);
            DataTable dt;
            dt = BLL.get_EmpLOB(BUID);

            GetGridStructure();

            ViewState["dt"] = dt;
            Rg_LOB.DataSource = dt;
            // Rg_LOB.MasterTableView.EditMode = GridEditMode.InPlace;
            Rg_LOB.DataBind();

            //FOR UPDATING RECORDS
            _obj_smhr_lob.OPERATION = operation.Empty;
            _obj_smhr_lob.LOB_BUID = Convert.ToInt32(rcmb_BUID.SelectedItem.Value);
            DataTable dtreccount = BLL.get_LOBRecords(_obj_smhr_lob);
            if (dtreccount.Rows.Count > 0)
            {
                btn_Update.Visible = true;

            }
            else
                btn_Submit.Visible = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leaveopeningbalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private class myNTemplate : ITemplate
    {
     
        string TempField = string.Empty;
        string id = string.Empty;
        //RadNumericTextBox ntextBox;
        public myNTemplate(string Field,string idval)
        {
            TempField = Field;
            id = idval;

        }
    
     

        #region ITemplate Members

        public void InstantiateIn(Control container)
        {
            RadNumericTextBox ntextBox = new RadNumericTextBox();
            ntextBox.EnableEmbeddedSkins = false;
            ntextBox.Width = Unit.Pixel(25);
            ntextBox.ID = "ntxt_" + TempField;
            ntextBox.DataBinding += new EventHandler(ntextBox_DataBinding);
            container.Controls.Add(ntextBox);
         //   ntextBox.ID = "ntext_" + id;
        }

        void ntextBox_DataBinding(object sender, EventArgs e)
        {
            RadNumericTextBox ntextBox = (RadNumericTextBox)sender;
           // GridDataItem container = (GridDataItem)ntextBox.NamingContainer;
           // string fieldValue = DataBinder.Eval(container.DataItem, TempField).ToString();
           // ntextBox.Text = (string)((DataRowView)container.DataItem)[TempField];
           //// ntextBox.Value = (string)((DataRowView)container.DataItem)[TempField];

            GridDataItem item = ntextBox.NamingContainer as GridDataItem;
            ntextBox.Text = DataBinder.Eval(item.DataItem, this.TempField).ToString();
        }
    
    
        #endregion
    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_LOB _obj_smhr_lob = new SMHR_LOB();
            btn_Finalise.Enabled = true;
            StringBuilder strQry = new StringBuilder();

            foreach (GridDataItem item in this.Rg_LOB.MasterTableView.Items)
            {
                _obj_smhr_lob.LOB_EMPID = Convert.ToInt32(item.Cells[2].Text);
                for (int j = 0; j < Rg_LOB.Columns.Count - 5; j++)
                {
                    strQry.Append("EXEC USP_SMHR_LEAVEOPENINGBALANCES ");
                    _obj_smhr_lob.LOB_EMPID = Convert.ToInt32(item.Cells[2].Text);
                    string LT = Convert.ToString(Rg_LOB.MasterTableView.Columns[j + 4].UniqueName);
                    string[] T = LT.Split(new char[] { '-' });
                    _obj_smhr_lob.LOB_LEAVETYPEID = Convert.ToInt32(T[0]);
                    string ctrl = "ntxt_" + LT;
                    RadNumericTextBox ntxt;
                    ntxt = (RadNumericTextBox)item[this.Rg_LOB.MasterTableView.Columns[j + 4].UniqueName].FindControl(ctrl);
                    // Double db = double.Parse((item[LT].FindControl(ctrl) as RadNumericTextBox).Value.ToString());


                    //ntxt = (RadNumericTextBox)FindControlIterative(Rg_LOB, "ntxt_26-Casual Leave");

                    _obj_smhr_lob.LOB_NOOFDAYS = 2;//Convert.ToInt32(ntxt.Text);
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
            bool rs = BLL.set_EMpLOB(_obj_smhr_lob, strQry.ToString());
            if (rs == true)
                BLL.ShowMessage(this, "Leave Opening Balances inserted Successfully");
            else
                BLL.ShowMessage(this, "Error found");

            Rg_LOB.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leaveopeningbalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Rg_LOB_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            GetGridStructure();
            DataTable dt = (DataTable)ViewState["dt"];
            Rg_LOB.DataSource = dt;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leaveopeningbalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void btn_Update_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_LOB _obj_smhr_lob = new SMHR_LOB();
            foreach (GridDataItem item in this.Rg_LOB.MasterTableView.Items)
            {
                _obj_smhr_lob.OPERATION = operation.Delete;
                _obj_smhr_lob.LOB_EMPID = Convert.ToInt32(item.Cells[2].Text);
                BLL.set_UpdateEmpLOB(_obj_smhr_lob);
            }
            InsertGridDetails(strQry);

            _obj_smhr_lob.OPERATION = operation.Insert;
            bool result = BLL.set_EMpLOB(_obj_smhr_lob, strQry.ToString());
            if (result == true)
                btn_Finalise.Enabled = true;
            else
                BLL.ShowMessage(this, "Updation failed");
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leaveopeningbalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        

    }

    private string InsertGridDetails(StringBuilder strQry)
    {
        try
        {
            SMHR_LOB _obj_smhr_lob = new SMHR_LOB();
            _obj_smhr_lob.OPERATION = operation.Delete;


            foreach (GridDataItem item in this.Rg_LOB.MasterTableView.Items)
            {
                _obj_smhr_lob.LOB_EMPID = Convert.ToInt32(item.Cells[2].Text);
                for (int j = 0; j < Rg_LOB.Columns.Count - 5; j++)
                {
                    strQry.Append("EXEC USP_SMHR_LEAVEOPENINGBALANCES ");
                    _obj_smhr_lob.LOB_EMPID = Convert.ToInt32(item.Cells[2].Text);
                    string LT = Convert.ToString(Rg_LOB.MasterTableView.Columns[j + 4].UniqueName);
                    string[] T = LT.Split(new char[] { '-' });
                    _obj_smhr_lob.LOB_LEAVETYPEID = Convert.ToInt32(T[0]);
                    string ctrl = "ntxt_" + LT;
                    RadNumericTextBox ntxt;
                    // ntxt = (RadNumericTextBox)item[this.Rg_LOB.MasterTableView.Columns[j + 4].UniqueName].FindControl(ctrl);
                    // Double db = double.Parse((item[LT].FindControl(ctrl) as RadNumericTextBox).Value.ToString());


                    //ntxt = new myNTemplate(Rg_LOB.MasterTableView.Columns[j + 4].UniqueName);

                    _obj_smhr_lob.LOB_NOOFDAYS = 2;//Convert.ToInt32(ntxt.Text);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leaveopeningbalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return Convert.ToString(strQry);
    }
    protected void btn_Finalise_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_LOB _obj_smhr_lob = new SMHR_LOB();
            _obj_smhr_lob.OPERATION = operation.Update;
            StringBuilder strQry = new StringBuilder();

            foreach (GridDataItem item in this.Rg_LOB.MasterTableView.Items)
            {
                _obj_smhr_lob.LOB_EMPID = Convert.ToInt32(item.Cells[2].Text);
                for (int j = 0; j < Rg_LOB.Columns.Count - 5; j++)
                {
                    strQry.Append("EXEC USP_SMHR_LEAVEOPENINGBALANCES ");
                    _obj_smhr_lob.LOB_EMPID = Convert.ToInt32(item.Cells[2].Text);
                    string LT = Convert.ToString(Rg_LOB.MasterTableView.Columns[j + 4].UniqueName);
                    string[] T = LT.Split(new char[] { '-' });
                    _obj_smhr_lob.LOB_LEAVETYPEID = Convert.ToInt32(T[0]);
                    string ctrl = "ntxt_" + LT;
                    RadNumericTextBox ntxt;
                    // ntxt = (RadNumericTextBox)item[this.Rg_LOB.MasterTableView.Columns[j + 4].UniqueName].FindControl(ctrl);
                    // Double db = double.Parse((item[LT].FindControl(ctrl) as RadNumericTextBox).Value.ToString());


                    //ntxt = new myNTemplate(Rg_LOB.MasterTableView.Columns[j + 4].UniqueName);

                    _obj_smhr_lob.LOB_NOOFDAYS = 2;//Convert.ToInt32(ntxt.Text);
                    _obj_smhr_lob.LOB_FINALISE = 1;
                    _obj_smhr_lob.LOB_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_lob.LOB_CREATEDDATE = System.DateTime.Now;
                    _obj_smhr_lob.LOB_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_lob.LOB_LASTMDFDATE = System.DateTime.Now;
                    string str = "@Operation = 'UPDATE'" +
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
            bool result = BLL.set_EMpLOB(_obj_smhr_lob, strQry.ToString());
            if (result == true)
                BLL.ShowMessage(this, "Leave Opening Balances for this BU are Finalised!!");
            else
                BLL.ShowMessage(this, "Record Updation Failed");
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leaveopeningbalances", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_leaveopeningbalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return null;
    }
}
