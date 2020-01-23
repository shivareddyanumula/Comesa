using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using Telerik.Web.UI;

public partial class HR_TRAINING_SamplePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if(!IsPostBack)
        {
          //  BindGrid();
        //GridBoundColumn NewColumn = new GridBoundColumn();
        //NewColumn.DataField = "COLUMN1";
        //NewColumn.UniqueName = "COLUMN1";
        //NewColumn.Visible = true;
        //Grid1.MasterTableView.Columns.Add(NewColumn);
        //GridBoundColumn boundColumn;

        //Important: first Add column to the collection 
            //GridBoundColumn boundColumn = new GridBoundColumn();
            //this.Grid1.MasterTableView.Columns.Add(boundColumn);

        //Then set properties 
        //boundColumn.DataField = "CustomerID";
        //boundColumn.HeaderText = "CustomerID"; 
            //GridBoundColumn boundColumn;
            //boundColumn = new GridBoundColumn();
            //Grid1.MasterTableView.Columns.Add(boundColumn);
            //boundColumn.DataField = "valor";
            //boundColumn.HeaderText = "Valor";
            //boundColumn.UniqueName = "valor";
            //boundColumn.DataFormatString = "{0:R$###,###.##}"; 
        }
    //    DataTable dt = new DataTable();
    //    Grid1.DataSource = dt;
    //    Grid1.DataBind();
    }

    private void BindGrid()
    {
        int columns = 5;
        int rows =300;
        DataTable dt = new DataTable();
        dt.Columns.Add("ID", typeof(int));
        //for (int i = 0; i < columns; i++)
        //{
        //    dt.Columns.Add("month"+i, typeof(string));
        //}
        for(int j=0;j<=rows;j++)
        {
            dt.Rows.Add(j);
        }
        Grid1.Visible = true;
        Grid1.DataSource = dt;
        //Grid1.DataBind();
    }
    public DataTable LoadGridEmployees()
    {

        DataTable dt = new DataTable();
        dt.Columns.Add("Empname",typeof(string));
        dt.Columns.Add("EMP_ID", typeof(string));

        dt.Rows.Add("A", "A");
        dt.Rows.Add("B", "B");
        dt.Rows.Add("C", "C");
        dt.Rows.Add("D", "D");
        return dt;
    }
    protected void rgd_AttDtls_Emp_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        BindGrid();
    }

    protected void rcmb_AttDtls_Status_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        BindGrid();
        Grid1.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        var a = Grid1;
        //Grid1.CurrentPageIndex = 2;
        var a1 = Grid1;
        Grid1.AllowPaging = false;
        Grid1.Rebind();
        for (int i = 0; i <= Grid1.Items.Count; i++)
        {

            //rcm_status = rgd_AttDtls_Emp.Items[i].FindControl("rcmb_AttDtls_Status") as RadComboBox;

            //lblemp = rgd_AttDtls_Emp.Items[i].FindControl("lbl_empid") as Label;

            RadComboBox rcm_Attendance = new RadComboBox();
            Label lblemp = new Label();
            RadComboBox rcm_Attandance2 = new RadComboBox();
            rcm_Attendance = Grid1.Items[i].FindControl("rcmb_AttDtls_Status") as RadComboBox;
            lblemp = Grid1.Items[i].FindControl("ID") as Label;
            rcm_Attandance2 = Grid1.Items[i].FindControl("rcmb_AttDtls_Status1") as RadComboBox;
            DataTable dt_check = new DataTable();


        }
    }
    protected void Grid1_PageIndexChanged(object source, GridPageChangedEventArgs e)
    {

    }
}