
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
using Telerik.Web.UI;
using SMHR;
using System.Collections.Generic;
public partial class Masters_frm_Empcomponents : System.Web.UI.Page
{
    #region References
    /// <summary>
    /// This Region consists of classes and their instances which were used
    /// in throughout the form
    /// </summary>
    SMHR_PERIOD _obj_smhr_period = new SMHR_PERIOD();
    SMHR_VARIABLEAMT _obj_vamt = new SMHR_VARIABLEAMT();
    DataTable dt_Result = new DataTable();
    static int exist = 0;
    DataTable dt_Null = null;
    static int found = 0;
    #endregion

    #region PageLoad
    /// <summary>
    /// This Region Will loads the businessunit and financial periods of that organiastion
    /// based on the login user access permissions and also which are having variable pay
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (!IsPostBack)
            {

                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Employee Components");
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
                    rg_Empcomponents.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Save.Visible = false;
                    btn_Update.Visible = false;
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
                Loadcombos();
                rg_Empcomponents.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Empcomponents", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    #region Load Methods
    /// <summary>
    /// This Region Will consists of loading the businessunit and financial periods
    /// clearing methods for clearing the controls
    /// And Loading the grid.
    /// </summary>
    private void Loadcombos()
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
            btn_Update.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Empcomponents", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
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
                    //ViewState["data"] = dt_Result;
                }
                else
                {
                    BLL.ShowMessage(this, "No Components Are Defined For This Organisation Or No Employee Is Active");
                    rg_Empcomponents.DataSource = dt_Null;
                    btn_Save.Visible = false;
                    btn_Update.Visible = false;
                    return;
                }
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Empcomponents", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void LoadGrid1()
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
                }
                else
                {
                    BLL.ShowMessage(this, "No Components Are Defined For This Organisation Or No Employee Is Active");
                    rg_Empcomponents.DataSource = dt_Null;
                    btn_Save.Visible = false;
                    btn_Update.Visible = false;
                    return;
                }
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Empcomponents", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void LoadComponents()
    {
        try
        {
            _obj_vamt.OPERATION = operation.Check;
            _obj_vamt.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Result = BLL.Get_Components(_obj_vamt);
            if (dt_Result.Rows.Count > 0)
            {
                ViewState["data"] = dt_Result;
                CheckBoxList components = new CheckBoxList();
                rg_Empcomponents.MasterTableView.Rebind();
                //rg_Empcomponents.Rebind();                
                for (int index = 0; index < rg_Empcomponents.Items.Count; index++)
                {
                    GridDataItem row;
                    row = rg_Empcomponents.Items[index];
                    components = rg_Empcomponents.Items[index].FindControl("chklst_Components") as CheckBoxList;
                    components.DataSource = dt_Result;
                    components.DataTextField = "SMHR_VPCOMP_COMPNAME";
                    components.DataValueField = "SMHR_VPCOMP_ID";
                    components.DataBind();
                    DataList dlTxtBox = rg_Empcomponents.Items[index].FindControl("dlTxtBox") as DataList;
                    dlTxtBox.DataSource = dt_Result;
                    dlTxtBox.DataBind();
                }
                //rg_Empcomponents.AllowPaging = true;              

            }
            else
            {
                rg_Empcomponents.DataSource = dt_Null;
                rg_Empcomponents.DataBind();
                BLL.ShowMessage(this, "No Component Is Defined For This Organisation or No One is Active");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Empcomponents", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
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
        btn_Update.Visible = false;
        rg_Empcomponents.MasterTableView.CurrentPageIndex = 0;
        chk_Previous.Checked = false;
    }
    private void LoadEmpData()
    {
        try
        {
            bool Isavialable = false;

            CheckBoxList Chklst_Components = new CheckBoxList();
            CheckBox chk_check = new CheckBox();
            for (int rows = 0; rows < rg_Empcomponents.Items.Count; rows++)
            {
                double sum = 0.0;
                chk_check = rg_Empcomponents.Items[rows].FindControl("chk_Row") as CheckBox;
                DataList dlst = rg_Empcomponents.Items[rows].FindControl("dlTxtBox") as DataList;
                Chklst_Components = (CheckBoxList)rg_Empcomponents.Items[rows].FindControl("chklst_Components");
                _obj_vamt.EMP_ID = Convert.ToInt32(rg_Empcomponents.Items[rows]["EMP_ID"].Text.ToString());
                _obj_vamt.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_vamt.BUID = Convert.ToInt32(rcmb_Businessunit.SelectedValue);
                _obj_vamt.financial_period = Convert.ToInt32(rcmb_Financialperiod.SelectedValue);
                _obj_vamt.OPERATION = operation.Validate;
                dt_Result = BLL.Get_Components(_obj_vamt);
                if (dt_Result.Rows.Count > 0)
                {
                    //int CheckedComponents = dt_Result.Rows.Count;
                    chk_check.Checked = true;
                    for (int Checkeditem = 0, CheckedComponents = 0; Checkeditem < Chklst_Components.Items.Count; Checkeditem++)
                    {
                        if (CheckedComponents < dt_Result.Rows.Count)
                        {
                            if (Chklst_Components.Items[Checkeditem].Value == Convert.ToString(dt_Result.Rows[CheckedComponents]["SMHR_EMPCOMP_COMPID"]))
                            {
                                Chklst_Components.Items[Checkeditem].Selected = true;
                                RadNumericTextBox Rntxt = (RadNumericTextBox)dlst.Items[Checkeditem].FindControl("rntxt");
                                Rntxt.Text = Convert.ToString(dt_Result.Rows[CheckedComponents]["SMHR_EMPCOMP_CPERCENTAGE"]);
                                Rntxt.Enabled = true;
                                sum += Convert.ToInt32(Rntxt.Text);
                                CheckedComponents += 1;
                            }
                        }
                    }
                    int count = dlst.Controls.Count - 1;
                    TextBox txt_Total = dlst.Controls[count].FindControl("txtTotal") as TextBox;
                    //txt_Total.Text = Convert.ToString("100");
                    txt_Total.Text = Convert.ToString(sum);
                }
                //else
                //{
                if (chk_Previous.Checked)
                {
                    sum -= sum;
                    CheckBoxList Chklst_Component = new CheckBoxList();
                    Chklst_Component = (CheckBoxList)rg_Empcomponents.Items[rows].FindControl("chklst_Components");
                    _obj_vamt.EMP_ID = Convert.ToInt32(rg_Empcomponents.Items[rows]["EMP_ID"].Text.ToString());
                    _obj_vamt.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_vamt.BUID = Convert.ToInt32(rcmb_Businessunit.SelectedValue);
                    _obj_vamt.financial_period = Convert.ToInt32(rcmb_Financialperiod.SelectedValue);
                    _obj_vamt.OPERATION = operation.Validate1;
                    dt_Result = BLL.Get_Components(_obj_vamt);
                    if (dt_Result.Rows.Count > 0)
                    {
                        int CheckedComponent = dt_Result.Rows.Count;
                        for (int Checkeditems = 0; Checkeditems < Chklst_Component.Items.Count; Checkeditems++)
                        {
                            if (CheckedComponent > Checkeditems)
                            {
                                if (Chklst_Component.Items[Checkeditems].Value == Convert.ToString(dt_Result.Rows[Checkeditems]["SMHR_EMPCOMP_COMPID"]))
                                {
                                    Chklst_Component.Items[Checkeditems].Selected = true;
                                    RadNumericTextBox Rntxt1 = (RadNumericTextBox)dlst.Items[Checkeditems].FindControl("rntxt");
                                    Rntxt1.Text = Convert.ToString(dt_Result.Rows[Checkeditems]["SMHR_EMPCOMP_CPERCENTAGE"]);
                                    Rntxt1.Enabled = true;
                                    Isavialable = true;
                                    sum += Convert.ToInt32(Rntxt1.Text);
                                }
                            }
                        }
                        int count1 = dlst.Controls.Count - 1;
                        TextBox txt_Total1 = dlst.Controls[count1].FindControl("txtTotal") as TextBox;
                        //txt_Total1.Text = Convert.ToString("100");
                        txt_Total1.Text = Convert.ToString(sum);
                    }
                }

            }
            //}
            if ((!Isavialable) && chk_Previous.Checked)
                BLL.ShowMessage(this, "No Data Is Available For The Last Financial Period!");
            if (Isavialable)
                BLL.ShowMessage(this, "This is the Immidiate Previous Financial Year Data");
            //rg_Empcomponents.MasterTableView.AllowPaging = true;
            //rg_Empcomponents.MasterTableView.Rebind();
            //rg_Empcomponents.PageSize = 10;

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Empcomponents", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    #endregion

    #region Selection Change
    /// <summary>
    /// This region will consists of all selected index changed methods
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Empcomponents", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_Financialperiod_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (!(rcmb_Businessunit.SelectedIndex > 0))
            {
                rcmb_Financialperiod.ClearSelection();
                BLL.ShowMessage(this, "Select Businessunit");
            }
            else
            {
                if (rcmb_Financialperiod.SelectedIndex == 0)
                {
                    BLL.ShowMessage(this, "Select Financial Period");
                }
                else
                {
                    LoadGrid();
                    rg_Empcomponents.DataBind();
                    if (dt_Result.Rows.Count > 0)
                    {
                        LoadComponents();
                        // COMPARING ONLY FIRST ROW BECAUSE IF FIRST ROW IS BOUNDED WITH COMPONENTS ALL WILL BE BOUNDED
                        DataList dlTxtBox = rg_Empcomponents.Items[0].FindControl("dlTxtBox") as DataList;
                        if (dlTxtBox.Items.Count > 0)
                        {
                            rcmb_Businessunit.Enabled = false;
                            rcmb_Financialperiod.Enabled = false;
                            btn_Save.Visible = true;
                            LoadEmpData();
                            chk_Previous.Enabled = true;
                        }
                    }
                    else
                        chk_Previous.Enabled = false;

                    //rg_Empcomponents.MasterTableView.AllowPaging = true;
                    //rg_Empcomponents.MasterTableView.Rebind();
                    //rg_Empcomponents.PageSize = 10;
                }

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Empcomponents", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    //protected void rg_Empcomponents_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    //{
    //    LoadGrid();
    //    //if (rcmb_Financialperiod.SelectedIndex > 0)
    //    //{
    //    //    if (found == 0)
    //    //    {
    //    //        LoadComponents();
    //    //        found++;
    //    //    }
    //    //    LoadEmpData();
    //    //}
    //}

    protected void chk_All_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox chk_row = new CheckBox();
            CheckBox chk_all = new CheckBox();
            chk_all = (sender) as CheckBox;
            if (chk_all.Checked)
            {
                for (int row = 0; row < rg_Empcomponents.Items.Count; row++)
                {
                    chk_row = rg_Empcomponents.Items[row].FindControl("chk_Row") as CheckBox;
                    if (chk_row.Enabled == true)
                        chk_row.Checked = true;
                }
            }
            else
            {
                for (int row = 0; row < rg_Empcomponents.Items.Count; row++)
                {
                    chk_row = rg_Empcomponents.Items[row].FindControl("chk_Row") as CheckBox;
                    if (chk_row.Enabled == true)
                        chk_row.Checked = false;
                }
            }
            //rg_Empcomponents.MasterTableView.AllowPaging = true;
            //rg_Empcomponents.MasterTableView.Rebind();
            //rg_Empcomponents.PageSize = 10;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Empcomponents", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void chk_Previous_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (rcmb_Financialperiod.SelectedIndex > 0)
            {
                LoadGrid();
                rg_Empcomponents.DataBind();
                LoadComponents();
                rcmb_Businessunit.Enabled = false;
                rcmb_Financialperiod.Enabled = false;

                // COMPARING ONLY FIRST ROW BECAUSE IF FIRST ROW IS BOUNDED WITH COMPONENTS ALL WILL BE BOUNDED
                DataList dlTxtBox = rg_Empcomponents.Items[0].FindControl("dlTxtBox") as DataList;
                if (dlTxtBox.Items.Count > 0)
                {
                    LoadEmpData();
                    btn_Save.Visible = true;
                }
                //rg_Empcomponents.MasterTableView.AllowPaging = true;
                //rg_Empcomponents.MasterTableView.Rebind();
                //rg_Empcomponents.PageSize = 10;

            }
            else
            {
                BLL.ShowMessage(this, "Select Financial Period!");
                chk_Previous.Checked = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Empcomponents", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void chklst_Components_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBoxList chkList = sender as CheckBoxList;
            GridDataItem Item = chkList.Parent.Parent as GridDataItem;

            DataList dlTxtBox = Item.FindControl("dlTxtBox") as DataList;
            for (int i = 0; i < chkList.Items.Count; i++)
            {
                if (chkList.Items[i].Selected)
                {
                    (dlTxtBox.Items[i].FindControl("rntxt") as RadNumericTextBox).Enabled = true;
                    (dlTxtBox.Items[i].FindControl("rntxt") as RadNumericTextBox).Focus();
                    ViewState["PreviousValue"] = null;
                }
                else
                {
                    (dlTxtBox.Items[i].FindControl("rntxt") as RadNumericTextBox).Enabled = false;
                    int count = dlTxtBox.Controls.Count - 1;
                    TextBox txt_Total = dlTxtBox.Controls[count].FindControl("txtTotal") as TextBox;
                    if (txt_Total.Text != string.Empty)
                    {
                        if ((dlTxtBox.Items[i].FindControl("rntxt") as RadNumericTextBox).Text != string.Empty)
                        {
                            int value = Convert.ToInt32((dlTxtBox.Items[i].FindControl("rntxt") as RadNumericTextBox).Text);
                            txt_Total.Text = Convert.ToString(Convert.ToInt32(txt_Total.Text) - value);
                        }
                    }
                    (dlTxtBox.Items[i].FindControl("rntxt") as RadNumericTextBox).Text = string.Empty;
                }
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Empcomponents", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rntxt_TextChanged(object sender, EventArgs e)
    {
        try
        {
            //int previous = 0;
            RadNumericTextBox rntxt_value = sender as RadNumericTextBox;
            string s = Convert.ToString(rntxt_value.ID);
            TextBox txt_Total = new TextBox();
            GridDataItem item;
            item = rntxt_value.Parent.Parent.Parent.Parent as GridDataItem;
            DataList dlst = item.FindControl("dlTxtBox") as DataList;
            int count = dlst.Controls.Count - 1;
            txt_Total = dlst.Controls[count].FindControl("txtTotal") as TextBox;
            int sum = 0;
            RadNumericTextBox rntxtsum = new RadNumericTextBox();
            for (int txtbxcount = 0; txtbxcount < dlst.Items.Count; txtbxcount++)
            {
                if ((dlst.Items[txtbxcount].FindControl("rntxt") as RadNumericTextBox).Text != string.Empty)
                {
                    rntxtsum.Text = (dlst.Items[txtbxcount].FindControl("rntxt") as RadNumericTextBox).Text;
                    sum += Convert.ToInt32(rntxtsum.Text);
                }
            }
            txt_Total.Text = Convert.ToString(sum);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Empcomponents", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //protected void rg_Empcomponents_PageIndexChanged(object source, GridPageChangedEventArgs e)
    //{
    //    //int pageno=Convert.ToInt32(e.NewPageIndex
    //    //LoadGrid();
    //    //rg_Empcomponents.DataBind();
    //    //LoadComponents();
    //    //LoadGrid();
    //    //rg_Empcomponents.DataBind();
    //    ////DataTable dt = new DataTable();
    //    ////dt=(DataTable)ViewState["data"];
    //    ////rg_Empcomponents.DataSource = dt;
    //    ////rg_Empcomponents.DataBind();
    //    //LoadComponents();
    //    //rcmb_Businessunit.Enabled = false;
    //    //rcmb_Financialperiod.Enabled = false;
    //    //btn_Save.Visible = true;
    //    //LoadEmpData();

    //    LoadGrid();
    //    LoadComponents();
    //    rg_Empcomponents.DataBind();
    //    rg_Empcomponents.CurrentPageIndex = e.NewPageIndex;
    //    //LoadEmpData();
    //    //rg_Empcomponents.MasterTableView.AllowPaging = true;
    //    //rg_Empcomponents.MasterTableView.Rebind();
    //    //rg_Empcomponents.PageSize = 10;
    //}



    #endregion

    #region Button Clicks
    /// <summary>
    /// This Region will consists of all button clicks functionality.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            bool selected = false;
            bool checkedcomponents = false;
            bool status = false;
            int result = 0;
            CheckBox check = new CheckBox();
            CheckBoxList components = new CheckBoxList();
            //string rowno = "";
            string notchecked = "";
            for (int rows = 0; rows < rg_Empcomponents.Items.Count; rows++)
            {
                check = rg_Empcomponents.Items[rows].FindControl("chk_Row") as CheckBox;
                components = rg_Empcomponents.Items[rows].FindControl("chklst_Components") as CheckBoxList;
                if (check.Checked)
                {
                    selected = true;
                    _obj_vamt.EMP_ID = Convert.ToInt32(rg_Empcomponents.Items[rows]["EMP_ID"].Text.ToString());
                    _obj_vamt.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_vamt.BUID = Convert.ToInt32(rcmb_Businessunit.SelectedValue);
                    _obj_vamt.financial_period = Convert.ToInt32(rcmb_Financialperiod.SelectedValue);
                    _obj_vamt.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_vamt.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    GridDataItem item;
                    item = rg_Empcomponents.Items[rows] as GridDataItem;
                    DataList dlst = item.FindControl("dlTxtBox") as DataList;
                    int count = dlst.Controls.Count - 1;
                    TextBox txt_Total = dlst.Controls[count].FindControl("txtTotal") as TextBox;
                    if (txt_Total.Text != string.Empty)
                    {
                        if (!(Convert.ToInt32(txt_Total.Text) == 100))
                        {
                            //if (rowno == string.Empty)
                            //rowno = Convert.ToString(rows + 1);
                            BLL.ShowMessage(this, "Sum of The Selected Components Percentage Should Be Hundred at row No:" + (rows + 1));
                            BLL.ShowMessage(this, "Employee Components Set for the Selected Employees:" + result);
                            return;
                            //else
                            //    rowno += "  ,  " + Convert.ToString(rows + 1);
                            //continue;
                        }
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Select A Component And Enter Corresponding Percentage For That in the Row:" + (rows + 1));
                        BLL.ShowMessage(this, "Employee Components Set for the Selected Employees:" + result);
                        return;
                    }
                    for (int Checkeditems = 0; Checkeditems < components.Items.Count; Checkeditems++)
                    {
                        if (components.Items[Checkeditems].Selected)
                        {
                            if ((dlst.Items[Checkeditems].FindControl("rntxt") as RadNumericTextBox).Text == string.Empty)
                            {
                                BLL.ShowMessage(this, "Please Enter amount for Selected Components.");
                                return;
                            }
                        }
                    }
                    _obj_vamt.OPERATION = operation.Delete;
                    // check for the existance of employee
                    if (exist == 0)
                    {
                        _obj_vamt.OPERATION = operation.Delete;
                        if (BLL.set_Component(_obj_vamt))
                        //if exist call delete operation then insert
                        {
                            exist++;
                        }
                    }
                    for (int Checkeditems = 0; Checkeditems < components.Items.Count; Checkeditems++)
                    {
                        if (components.Items[Checkeditems].Selected)
                        {
                            if ((dlst.Items[Checkeditems].FindControl("rntxt") as RadNumericTextBox).Text != string.Empty)
                            {
                                _obj_vamt.component_id = Convert.ToInt32(components.Items[Checkeditems].Value);
                                checkedcomponents = true;
                                _obj_vamt.component_percentage = Convert.ToDouble((dlst.Items[Checkeditems].FindControl("rntxt") as RadNumericTextBox).Text);
                                _obj_vamt.OPERATION = operation.MODE1;
                                status = BLL.set_Component(_obj_vamt);
                            }
                        }
                    }
                    if (status)
                        result += 1;

                    if (!checkedcomponents)
                    {
                        if (notchecked == string.Empty)
                            notchecked = Convert.ToString(rows + 1);
                        else
                            notchecked += "  ,  " + Convert.ToString(rows + 1);
                    }
                    else
                    {
                        rg_Empcomponents.Items[rows].Visible = false;
                        check.Enabled = false;
                        check.Checked = false;
                    }

                }
                else
                {
                    continue;
                }
                exist = 0;// for setting the value to inorder to check for the existence of the employee
            }
            if (!selected)
            {
                BLL.ShowMessage(this, "Select Atleast One Employee To Save Their Component Details!");
            }
            else
            {
                // if(rowno!=string.Empty)
                //BLL.ShowMessage(this, "Sum of The Selected Components Percentage Should Be Hundred at row No:" + rowno);
                if (notchecked != string.Empty)
                    BLL.ShowMessage(this, "No Component Is Selected For The Selected Employees In The Rows:" + notchecked);
            }

            BLL.ShowMessage(this, "Employee Components Set for the Selected Employees:" + result);
            if (result > 0)
                btn_Save.Enabled = false;
            else
                btn_Save.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Empcomponents", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            ClearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Empcomponents", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

}
