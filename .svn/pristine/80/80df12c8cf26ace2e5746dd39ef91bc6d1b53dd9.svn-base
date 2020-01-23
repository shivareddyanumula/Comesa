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
using System.Drawing;
using Telerik.Web.UI;

public partial class Masters_frm_Employeecomp : System.Web.UI.Page
{
    #region References
    /// <summary>
    /// This Region Will Consists Of Classes That Were Used Thorugh Out This Screen
    /// </summary>
    SMHR_PERIOD _obj_smhr_period = new SMHR_PERIOD();
    SMHR_VARIABLEAMT _obj_vamt = new SMHR_VARIABLEAMT();
    DataTable dt_Result = new DataTable();
    DataTable dt_PagesInfo = new DataTable();
    static bool exist = false;
    DataTable dt_Null = null;
    DataColumn dc_isselected = new DataColumn();
    DataColumn dc_empid = new DataColumn();
    DataColumn dc_checkeditems = new DataColumn();
    DataColumn dc_percentage = new DataColumn();
    DataColumn dc_total = new DataColumn();
    static int found = 0;
    #endregion

    #region Loading Combos
    /// <summary>
    /// This Region Will Load The ComboBoxes That Are Avaialble In This Screen
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
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
                    //rg_Empcomponents.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Save.Visible = false;
                    //   btn_Update.Visible = false;
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

                LoadCombos();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Employeecomp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    #endregion

    #region Loading Methods
    /// <summary>
    /// This Region Will Consists Of Methods Which Will Loads Data Related To The Controls
    /// </summary>
    protected void LoadCombos()
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
            btn_Save.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Employeecomp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void LoadGrid()
    {
        try
        {
            rg_Empcomponents.Visible = true;
            _obj_vamt.OPERATION = operation.Select;
            _obj_vamt.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            if ((rcmb_Businessunit.SelectedIndex > 0) && (rcmb_Financialperiod.SelectedIndex > 0))
            {
                _obj_vamt.BUID = Convert.ToInt32(rcmb_Businessunit.SelectedValue);
                dt_Result = BLL.get_Employeevariableamt(_obj_vamt);//GETTING ALL EMPLOYEES WHO ARE HAVING VARIABLE PAY           
                if (dt_Result.Rows.Count > 0)
                {
                    rg_Empcomponents.DataSource = dt_Result;
                    rg_Empcomponents.DataBind();
                    ViewState["Result"] = dt_Result;
                }
                else
                {
                    BLL.ShowMessage(this, "No Employee Has Variable Pay in This Businessunit");
                    rg_Empcomponents.DataSource = dt_Null;
                    btn_Save.Visible = false;
                    return;
                }
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Employeecomp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

    }

    protected void LoadComponents()
    {
        try
        {
            _obj_vamt.OPERATION = operation.Check;
            _obj_vamt.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            dt_Result = BLL.Get_Components(_obj_vamt);
            if (dt_Result.Rows.Count > 0)
            {
                CheckBoxList components = new CheckBoxList();
                //rg_Empcomponents.MasterTableView.Rebind();
                //rg_Empcomponents.Rebind();                
                for (int index = 0; index < rg_Empcomponents.Rows.Count; index++)
                {
                    //GridItem row;
                    // row = rg_Empcomponents.Rows[index];
                    components = rg_Empcomponents.Rows[index].FindControl("chklst_Components") as CheckBoxList;
                    components.DataSource = dt_Result;
                    components.DataTextField = "SMHR_VPCOMP_COMPNAME";
                    components.DataValueField = "SMHR_VPCOMP_ID";
                    components.DataBind();
                    DataList dlTxtBox = rg_Empcomponents.Rows[index].FindControl("dlst_Percentages") as DataList;
                    dlTxtBox.DataSource = dt_Result;
                    dlTxtBox.DataBind();
                }
                //rg_Empcomponents.AllowPaging = true;              

            }
            else
            {
                rg_Empcomponents.DataSource = dt_Null;
                rg_Empcomponents.DataBind();
                BLL.ShowMessage(this, "No Component Is Defined For This Organisation");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Employeecomp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void ClearControls()
    {
        rcmb_Businessunit.ClearSelection();
        rcmb_Financialperiod.ClearSelection();
        rcmb_Businessunit.Enabled = true;
        rcmb_Financialperiod.Enabled = true;
        rg_Empcomponents.Visible = false;
        rg_Empcomponents.DataSource = null;
        rg_Empcomponents.DataBind();
        btn_Save.Visible = false;
        chk_Previous.Checked = false;
    }
    private void LoadEmpData()
    {
        try
        {
            bool Isavialable = false;
            CheckBoxList Chklst_Components = new CheckBoxList();
            CheckBox chk_check = new CheckBox();
            for (int rows = 0; rows < rg_Empcomponents.Rows.Count; rows++)
            {
                chk_check = rg_Empcomponents.Rows[rows].FindControl("chk_Row") as CheckBox;
                DataList dlst = rg_Empcomponents.Rows[rows].FindControl("dlst_Percentages") as DataList;
                Chklst_Components = (CheckBoxList)rg_Empcomponents.Rows[rows].FindControl("chklst_Components");
                Label empid = rg_Empcomponents.Rows[rows].FindControl("lbl_Empid") as Label;
                _obj_vamt.EMP_ID = Convert.ToInt32(empid.Text);
                _obj_vamt.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_vamt.BUID = Convert.ToInt32(rcmb_Businessunit.SelectedValue);
                _obj_vamt.financial_period = Convert.ToInt32(rcmb_Financialperiod.SelectedValue);
                _obj_vamt.OPERATION = operation.Validate;
                dt_Result = BLL.Get_Components(_obj_vamt);
                if (dt_Result.Rows.Count > 0)
                {
                    int CheckedComponents = dt_Result.Rows.Count;
                    chk_check.Checked = true;
                    for (int Checkeditem = 0; Checkeditem < Chklst_Components.Items.Count; Checkeditem++)
                    {
                        if (CheckedComponents > Checkeditem)
                        {
                            if (Chklst_Components.Items[Checkeditem].Value == Convert.ToString(dt_Result.Rows[Checkeditem]["SMHR_EMPCOMP_COMPID"]))
                            {
                                Chklst_Components.Items[Checkeditem].Selected = true;
                                RadNumericTextBox Rntxt = (RadNumericTextBox)dlst.Items[Checkeditem].FindControl("txt_Percentage");
                                Rntxt.Text = Convert.ToString(dt_Result.Rows[Checkeditem]["SMHR_EMPCOMP_CPERCENTAGE"]);
                                Rntxt.Enabled = true;
                            }
                        }
                    }
                    int count = dlst.Controls.Count - 1;
                    TextBox txt_Total = dlst.Controls[count].FindControl("txt_Total") as TextBox;
                    txt_Total.Text = Convert.ToString("100");
                }
                else
                {
                    if (chk_Previous.Checked)
                    {
                        CheckBoxList Chklst_Component = new CheckBoxList();
                        Chklst_Component = (CheckBoxList)rg_Empcomponents.Rows[rows].FindControl("chklst_Components");
                        Label empids = rg_Empcomponents.Rows[rows].FindControl("lbl_Empid") as Label;
                        _obj_vamt.EMP_ID = Convert.ToInt32(empids.Text);
                        //_obj_vamt.EMP_ID = Convert.ToInt32(rg_Empcomponents.;
                        _obj_vamt.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_vamt.BUID = Convert.ToInt32(rcmb_Businessunit.SelectedValue);
                        _obj_vamt.financial_period = Convert.ToInt32(rcmb_Financialperiod.SelectedValue);
                        _obj_vamt.OPERATION = operation.Validate1;
                        dt_Result = BLL.Get_Components(_obj_vamt);
                        if (dt_Result.Rows.Count > 0)
                        {
                            BLL.ShowMessage(this, "This is the Immidiate Previous Financial Year Data");
                            int CheckedComponent = dt_Result.Rows.Count;
                            Isavialable = true;
                            for (int Checkeditems = 0; Checkeditems < Chklst_Component.Items.Count; Checkeditems++)
                            {
                                if (CheckedComponent > Checkeditems)
                                {
                                    if (Chklst_Component.Items[Checkeditems].Value == Convert.ToString(dt_Result.Rows[Checkeditems]["SMHR_EMPCOMP_COMPID"]))
                                    {
                                        Chklst_Component.Items[Checkeditems].Selected = true;
                                        RadNumericTextBox Rntxt1 = (RadNumericTextBox)dlst.Items[Checkeditems].FindControl("txt_Percentage");
                                        Rntxt1.Text = Convert.ToString(dt_Result.Rows[Checkeditems]["SMHR_EMPCOMP_CPERCENTAGE"]);
                                        Rntxt1.Enabled = true;
                                    }
                                }
                            }
                            int count1 = dlst.Controls.Count - 1;
                            TextBox txt_Total1 = dlst.Controls[count1].FindControl("txt_Total") as TextBox;
                            txt_Total1.Text = Convert.ToString("100");
                        }
                    }
                }
            }
            if ((!Isavialable) && (chk_Previous.Checked))
                BLL.ShowMessage(this, "No Data Is Available For The Last Financial Period!");
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Employeecomp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

    }
    protected void LoadColumns()
    {
        try
        {
            // adding cloumns to the datatable inorder to maintain the page information       
            found += 1;
            dc_isselected.ColumnName = "Selected";
            dc_isselected.DataType = typeof(bool);
            dt_PagesInfo.Columns.Add(dc_isselected);

            dc_empid.ColumnName = "Empid";
            dc_empid.DataType = typeof(int);
            dt_PagesInfo.Columns.Add(dc_empid);

            dc_checkeditems.ColumnName = "Chekceditems";
            dc_checkeditems.DataType = typeof(string);
            dt_PagesInfo.Columns.Add(dc_checkeditems);

            dc_percentage.ColumnName = "Percentage";
            dc_percentage.DataType = typeof(string);
            dt_PagesInfo.Columns.Add(dc_percentage);

            dc_total.ColumnName = "Total";
            dc_total.DataType = typeof(string);
            dt_PagesInfo.Columns.Add(dc_total);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Employeecomp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    /// <summary>
    /// loading the information about the pages which user has done modifications.
    /// </summary>
    private void LoadPages()
    {
        try
        {
            if (ViewState["Pages"] != null)
            {
                dt_PagesInfo = ViewState["Pages"] as DataTable;
                for (int gridrows = 0; gridrows < rg_Empcomponents.Rows.Count; gridrows++)
                {
                    GridViewRow row = rg_Empcomponents.Rows[gridrows];
                    DataList dlTxtBox = row.FindControl("dlst_Percentages") as DataList;
                    RadNumericTextBox rntxt = new RadNumericTextBox();
                    CheckBoxList chklst = row.FindControl("chklst_Components") as CheckBoxList;
                    for (int available = 0; available < dt_PagesInfo.Rows.Count; available++)
                    {
                        // checking for the existance of the employee
                        if (Convert.ToString(dt_PagesInfo.Rows[available]["Empid"]) == (rg_Empcomponents.Rows[gridrows].FindControl("lbl_Empid") as Label).Text)
                        {
                            // found
                            CheckBox chk = rg_Empcomponents.Rows[gridrows].FindControl("chk_Row") as CheckBox;
                            //whether he has selected or not previously
                            if (Convert.ToString(dt_PagesInfo.Rows[available]["Selected"]) != "")
                            {
                                if (Convert.ToBoolean(dt_PagesInfo.Rows[available]["Selected"]) == true)
                                    chk.Checked = true;
                            }
                            //total
                            TextBox txttotal = (dlTxtBox.Controls[dlTxtBox.Controls.Count - 1].FindControl("txt_Total") as TextBox);
                            txttotal.Text = Convert.ToString(dt_PagesInfo.Rows[available]["Total"]);
                            for (int checkedcomp = 0; checkedcomp < chklst.Items.Count; checkedcomp++)
                            {//here comparing the components and also there respective percentages                            
                                string[] check = Convert.ToString(dt_PagesInfo.Rows[available]["Chekceditems"]).Split(new char[] { '-' });
                                string[] percenatages = Convert.ToString(dt_PagesInfo.Rows[available]["Chekceditems"]).Split(new char[] { '-' });
                                if (check.Length > 0)
                                {
                                    for (int length = 0; (length < check.Length) && (length < percenatages.Length); length++)
                                    {
                                        for (int items = 0; items < chklst.Items.Count; items++)
                                        {
                                            if (Convert.ToString(chklst.Items[items].Value) == check[length].ToString())
                                            {
                                                chklst.Items[items].Selected = true;
                                                rntxt = dlTxtBox.Items[items].FindControl("txt_Percentage") as RadNumericTextBox;
                                                rntxt.Text = percenatages[length].ToString();
                                            }

                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Employeecomp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    #endregion

    #region Selction Changed
    /// <summary>
    /// This Region Will Consists Of Methods When Ever The Selction Is Made
    /// </summary>
    /// <param name="o"></param>
    /// <param name="e"></param>
    protected void rcmb_Businessunit_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rcmb_Financialperiod.ClearSelection();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Employeecomp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void rcmb_Financialperiod_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Businessunit.SelectedIndex > 0)
            {
                if (rcmb_Financialperiod.SelectedIndex > 0)
                {
                    LoadGrid();
                    LoadComponents();
                    //LoadEmpData();
                }
                else
                {
                    BLL.ShowMessage(this, "Select Financialperiod");
                    return;
                }
            }
            else
            {
                rcmb_Financialperiod.ClearSelection();
                BLL.ShowMessage(this, "Select Businessunit");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Employeecomp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void chk_All_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox chk_row = new CheckBox();
            CheckBox chk_all = new CheckBox();
            chk_all = (sender) as CheckBox;
            if (chk_all.Checked)
            {
                exist = true;
                for (int row = 0; row < rg_Empcomponents.Rows.Count; row++)
                {
                    chk_row = rg_Empcomponents.Rows[row].FindControl("chk_Row") as CheckBox;
                    chk_row.Checked = true;
                }
            }
            else
            {
                exist = false;
                for (int row = 0; row < rg_Empcomponents.Rows.Count; row++)
                {
                    chk_row = rg_Empcomponents.Rows[row].FindControl("chk_Row") as CheckBox;
                    chk_row.Checked = false;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Employeecomp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    //protected void rg_Empcomponents_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    rg_Empcomponents.PageIndex = e.NewPageIndex;
    //}
    //protected void rg_Empcomponents_DataBound(object sender, EventArgs e)
    //{
    //    SetPaging();
    //}

    protected void chklst_Components_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBoxList chkList = sender as CheckBoxList;
            GridViewRow Item = chkList.Parent.Parent as GridViewRow;

            DataList dlTxtBox = Item.FindControl("dlst_Percentages") as DataList;
            for (int i = 0; i < chkList.Items.Count; i++)
            {
                if (chkList.Items[i].Selected)
                {
                    (dlTxtBox.Items[i].FindControl("txt_Percentage") as RadNumericTextBox).Enabled = true;
                    (dlTxtBox.Items[i].FindControl("txt_Percentage") as RadNumericTextBox).Focus();
                    ViewState["PreviousValue"] = null;
                }
                else
                {
                    (dlTxtBox.Items[i].FindControl("txt_Percentage") as RadNumericTextBox).Enabled = false;
                    int count = dlTxtBox.Controls.Count - 1;
                    TextBox txt_Total = dlTxtBox.Controls[count].FindControl("txt_Total") as TextBox;
                    if (txt_Total.Text != string.Empty)
                    {
                        if ((dlTxtBox.Items[i].FindControl("txt_Percentage") as RadNumericTextBox).Text != string.Empty)
                        {
                            int value = Convert.ToInt32((dlTxtBox.Items[i].FindControl("txt_Percentage") as RadNumericTextBox).Text);
                            txt_Total.Text = Convert.ToString(Convert.ToInt32(txt_Total.Text) - value);
                        }
                    }
                    else
                    {
                        txt_Total.Text = "0";
                    }
                    (dlTxtBox.Items[i].FindControl("txt_Percentage") as RadNumericTextBox).Text = string.Empty;
                }
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Employeecomp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void txt_Percentage_TextChanged(object sender, EventArgs e)
    {
        try
        {
            //int previous = 0;
            RadNumericTextBox rntxt_value = sender as RadNumericTextBox;
            string s = Convert.ToString(rntxt_value.ID);
            TextBox txt_Total = new TextBox();
            GridViewRow item;
            item = rntxt_value.Parent.Parent.Parent.Parent as GridViewRow;
            DataList dlst = item.FindControl("dlst_Percentages") as DataList;
            int count = dlst.Controls.Count - 1;
            txt_Total = dlst.Controls[count].FindControl("txt_Total") as TextBox;
            int sum = 0;
            TextBox rntxtsum = new TextBox();
            for (int txtbxcount = 0; txtbxcount < dlst.Items.Count; txtbxcount++)
            {
                if ((dlst.Items[txtbxcount].FindControl("txt_Percentage") as RadNumericTextBox).Text != string.Empty)
                {
                    rntxtsum.Text = (dlst.Items[txtbxcount].FindControl("txt_Percentage") as RadNumericTextBox).Text;
                    sum += Convert.ToInt32(rntxtsum.Text);
                }
            }
            txt_Total.Text = Convert.ToString(sum);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Employeecomp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }


    #endregion


    //protected void rg_Empcomponents_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    SetPaging();
    //}
    protected void rg_Empcomponents_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            if (dt_PagesInfo.Columns.Count < 0)
                LoadColumns();
            /*
            before going to the selected page we are saving those details in to the data table
            */
            for (int records = 0; records < rg_Empcomponents.Rows.Count; records++)
            {
                GridViewRow row = rg_Empcomponents.Rows[records];
                DataList dlTxtBox = row.FindControl("dlst_Percentages") as DataList;
                CheckBoxList chklst = row.FindControl("chklst_Components") as CheckBoxList;
                string selected = "";
                string totals = "";
                bool isexist = false;
                if (dt_PagesInfo.Rows.Count > 0)
                {
                    // checking for the existance of the employee in data table
                    for (int rowsavailable = 0; rowsavailable < dt_PagesInfo.Rows.Count; rowsavailable++)
                    {
                        if (Convert.ToString(dt_PagesInfo.Rows[rowsavailable]["Empid"]) == (rg_Empcomponents.Rows[records].FindControl("lbl_Empid") as Label).Text)
                        {
                            // found then removing that record and inserting the current information
                            dt_PagesInfo.Rows[rowsavailable].Delete();
                            isexist = true;
                            if ((rg_Empcomponents.Rows[records].FindControl("chk_Row") as CheckBox).Checked)
                            {
                                DataRow dr = dt_PagesInfo.NewRow();
                                dr[0] = Convert.ToBoolean((rg_Empcomponents.Rows[records].FindControl("chk_Row") as CheckBox).Checked);
                                dr[1] = Convert.ToInt32((rg_Empcomponents.Rows[records].FindControl("lbl_Empid") as Label).Text);
                                dr[4] = Convert.ToString((dlTxtBox.Controls[dlTxtBox.Controls.Count - 1].FindControl("txt_Total") as TextBox).Text);
                                for (int checkeditems = 0; checkeditems < chklst.Items.Count; checkeditems++)
                                {
                                    if (chklst.Items[checkeditems].Selected)
                                    {
                                        if (selected == "")
                                            selected = chklst.Items[checkeditems].Value;
                                        else
                                            selected += "," + chklst.Items[checkeditems].Value;
                                    }
                                }
                                dr[2] = selected;

                                for (int totalpercentage = 0; totalpercentage < dlTxtBox.Items.Count; totalpercentage++)
                                {
                                    if (((dlTxtBox.Items[totalpercentage].FindControl("txt_Percentage") as RadNumericTextBox).Text) != "")
                                    {
                                        if (totals == "")
                                            totals = ((dlTxtBox.Items[totalpercentage].FindControl("txt_Percentage") as RadNumericTextBox).Text);
                                        else
                                            totals += "," + ((dlTxtBox.Items[totalpercentage].FindControl("txt_Percentage") as RadNumericTextBox).Text);
                                    }
                                }
                                dr[3] = totals;
                                dt_PagesInfo.Rows.Add(dr);
                            }
                        }
                    }
                    if (!isexist)
                    {
                        if ((rg_Empcomponents.Rows[records].FindControl("chk_Row") as CheckBox).Checked)
                        {

                            DataRow dr = dt_PagesInfo.NewRow();
                            dr[0] = Convert.ToBoolean((rg_Empcomponents.Rows[records].FindControl("chk_Row") as CheckBox).Checked);
                            dr[1] = Convert.ToInt32((rg_Empcomponents.Rows[records].FindControl("lbl_Empid") as Label).Text);
                            dr[4] = Convert.ToString((dlTxtBox.Controls[dlTxtBox.Controls.Count - 1].FindControl("txt_Total") as TextBox).Text);
                            for (int checkeditems = 0; checkeditems < chklst.Items.Count; checkeditems++)
                            {
                                if (chklst.Items[checkeditems].Selected)
                                {
                                    if (selected == "")
                                        selected = chklst.Items[checkeditems].Value;
                                    else
                                        selected += "," + chklst.Items[checkeditems].Value;
                                }
                            }
                            dr[2] = selected;

                            for (int totalpercentage = 0; totalpercentage < dlTxtBox.Items.Count; totalpercentage++)
                            {
                                if (((dlTxtBox.Items[totalpercentage].FindControl("txt_Percentage") as RadNumericTextBox).Text) != "")
                                {
                                    if (totals == "")
                                        totals = ((dlTxtBox.Items[totalpercentage].FindControl("txt_Percentage") as RadNumericTextBox).Text);
                                    else
                                        totals += "," + ((dlTxtBox.Items[totalpercentage].FindControl("txt_Percentage") as RadNumericTextBox).Text);
                                }
                            }
                            dr[3] = totals;
                            dt_PagesInfo.Rows.Add(dr);
                        }
                    }
                }
                else
                {
                    DataRow dr = dt_PagesInfo.NewRow();
                    dr[0] = Convert.ToBoolean((rg_Empcomponents.Rows[records].FindControl("chk_Row") as CheckBox).Checked);
                    dr[1] = Convert.ToInt32((rg_Empcomponents.Rows[records].FindControl("lbl_Empid") as Label).Text);
                    dr[4] = Convert.ToString((dlTxtBox.Controls[dlTxtBox.Controls.Count - 1].FindControl("txt_Total") as TextBox).Text);
                    for (int checkeditems = 0; checkeditems < chklst.Items.Count; checkeditems++)
                    {
                        if (chklst.Items[checkeditems].Selected)
                        {
                            if (selected == "")
                                selected = chklst.Items[checkeditems].Value;
                            else
                                selected += "," + chklst.Items[checkeditems].Value;
                        }
                    }
                    dr[2] = selected;

                    for (int totalpercentage = 0; totalpercentage < dlTxtBox.Items.Count; totalpercentage++)
                    {
                        if (((dlTxtBox.Items[totalpercentage].FindControl("txt_Percentage") as RadNumericTextBox).Text) != "")
                        {
                            if (totals == "")
                                totals = ((dlTxtBox.Items[totalpercentage].FindControl("txt_Percentage") as RadNumericTextBox).Text);
                            else
                                totals += "," + ((dlTxtBox.Items[totalpercentage].FindControl("txt_Percentage") as RadNumericTextBox).Text);
                        }
                    }
                    dr[3] = totals;
                    dt_PagesInfo.Rows.Add(dr);
                }

            }
            ViewState["Pages"] = dt_PagesInfo;
            rg_Empcomponents.PageIndex = e.NewPageIndex;
            //if (e.NewPageIndex > 0)
            //{
            rg_Empcomponents.DataSource = ViewState["Result"] as DataTable;
            rg_Empcomponents.DataBind();
            LoadComponents();
            LoadEmpData();

            for (int rows = 0; rows < rg_Empcomponents.Rows.Count; rows++)
            {
                CheckBox chk_row = rg_Empcomponents.Rows[rows].FindControl("chk_Row") as CheckBox;
                if (exist == true)
                    chk_row.Checked = true;
                else
                    chk_row.Checked = false;
            }
            LoadPages();

            //}
            //else
            //{
            //    DataTable dt = ViewState["Result"] as DataTable;
            //    DataTable dt_first=dt;             
            //    dt_first.Clear();
            //     dt = ViewState["Result"] as DataTable;
            //    int pagesize = rg_Empcomponents.PageSize;
            //    for (int Firstten = 0; (Firstten < dt.Rows.Count)&&(pagesize>Firstten); Firstten++)
            //    {
            //        DataRow dr=dt_first.NewRow();
            //        dr = dt.Rows[Firstten];
            //        dt_first.Rows.Add(dr);                  
            //    }
            //    rg_Empcomponents.DataSource = dt_first;
            //    rg_Empcomponents.DataBind();
            //    LoadComponents();
            //    LoadEmpData();

            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Employeecomp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
}
