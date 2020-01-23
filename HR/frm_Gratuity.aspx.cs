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
using Telerik.Web.UI;
public partial class Payroll_frm_Gratuity : System.Web.UI.Page
{
    SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
    SMHR_GRATUITY _obj_smhr_gratuity = new SMHR_GRATUITY();
    DataTable dt_Payitems = new DataTable();
    DataTable dt_null = new DataTable();
    static string maxamounts;
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

                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("GRATIUTY");
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
                    rg_Gratuity.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    lnkbtn_History.Visible = false;
                    btn_Save.Visible = false;
                    btn_Calculate.Visible = false;
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
                DataTable dt_Businessunit = new DataTable();
                _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                _obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"].ToString());
                dt_Businessunit = BLL.get_Business_Units(_obj_smhr_logininfo);
                rcmb_Businessunit.DataSource = dt_Businessunit;
                rcmb_Businessunit.DataTextField = "BUSINESSUNIT_CODE";
                rcmb_Businessunit.DataValueField = "BUSINESSUNIT_ID";
                rcmb_Businessunit.DataBind();
                rcmb_Businessunit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                DataTable dt_BUDetails = new DataTable();
                btn_Calculate.Visible = false;
                btn_Save.Visible = false;
                rg_Gratuity.Visible = false;
                btn_Cancel.Visible = true;
                rcmb_Businessunit.Items.Clear();
                _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                dt_BUDetails = BLL.get_Business_Units(_obj_smhr_logininfo);
                rcmb_Businessunit.DataSource = dt_BUDetails;
                rcmb_Businessunit.DataTextField = "BUSINESSUNIT_CODE";
                rcmb_Businessunit.DataValueField = "BUSINESSUNIT_ID";
                rcmb_Businessunit.DataBind();
                rcmb_Businessunit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                rlist_Payitems.Enabled = false;
                btn_Calculate.Enabled = false;
                btn_Save.Visible = false;
                btn_Cancel.Visible = true;
                rntxt_Maximun.Enabled = false;
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Gratuity", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

            return;
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
            int index = rcmb_Businessunit.SelectedIndex;
            int rlistindex = rlist_Payitems.SelectedIndex;
            btn_Cancel_Click(sender, e);
            rntxt_Maximun.Text = Convert.ToString(maxamounts);
            rcmb_Businessunit.SelectedIndex = index;
            rlist_Payitems.SelectedIndex = rlistindex;
            rlist_Payitems.Enabled = true;
            payitems.Visible = true;
            chklst_Payitems.Visible = true;
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


                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    btn_Calculate.Visible = false;

                }

                else
                {
                    btn_Calculate.Visible = true;
                }

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


                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    btn_Calculate.Enabled = false;

                }

                else
                {
                    btn_Calculate.Enabled = true;
                }

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Gratuity", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

            return;
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
            chklst_Payitems.Items.Clear();
            rg_Gratuity.Visible = false;
            btn_Calculate.Enabled = false;
            rntxt_Maximun.Text = "";
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Calculate.Visible = false;

            }

            else
            {
                btn_Calculate.Visible = true;
            }

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
                rntxt_Maximun.Enabled = false;
            }
            else
            {
                rntxt_Maximun.Enabled = true;
            }
            rlist_Payitems.ClearSelection();
            rlist_Payitems.Visible = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Gratuity", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

            return;
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
            //bool flag = false;
            btn_Save.Visible = true;
            string payitems = "";
            rntxt_Maximun.Enabled = false;
            //DataTable dt_grid = new DataTable();
            string payitemid = "";
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


                        if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                        {
                            btn_Calculate.Visible = false;

                        }

                        else
                        {
                            btn_Calculate.Visible = true;
                        }

                    }
                }
                if (payitemid == string.Empty)
                {
                    BLL.ShowMessage(this, "Select A PayItem!");
                    rg_Gratuity.Visible = false;
                    return;
                }
                _obj_smhr_gratuity.EMP_PAYITEM = payitemid;
            }
            else
            {
                btn_Calculate.Visible = false;
                _obj_smhr_gratuity.EMP_PAYITEM = rlist_Payitems.SelectedValue.ToString();
            }

            DataTable dt_Calculation = new DataTable();//FOR CALCULATING 
            _obj_smhr_gratuity.SELECTED_PERIOD = Convert.ToDateTime(DateTime.Now);
            _obj_smhr_gratuity.EMP_BUID = Convert.ToInt32(rcmb_Businessunit.SelectedValue.ToString());
            _obj_smhr_gratuity.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Calculation = BLL.get_empgratuity(_obj_smhr_gratuity);
            if (dt_Calculation.Rows.Count > 0)
            {
                DataTable dt_emp = new DataTable();
                _obj_smhr_gratuity.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                dt_emp = BLL.get_emp(_obj_smhr_gratuity);//validate2
                if (dt_emp.Rows.Count > 0)
                {
                    for (int comparedt = 0; dt_Calculation.Rows.Count > comparedt; comparedt++)
                    {
                        for (int compare = 0; compare < dt_emp.Rows.Count; compare++)
                        {
                            if (dt_Calculation.Rows[comparedt]["EMP_ID"].ToString() == dt_emp.Rows[compare]["EMP_ID"].ToString())
                            {
                                dt_Calculation.Rows.RemoveAt(compare);
                            }
                        }

                    }
                }
                rg_Gratuity.Visible = true;
                rg_Gratuity.DataSource = dt_Calculation;
                rg_Gratuity.DataBind();
                for (int index = 0; dt_Calculation.Rows.Count > index; index++)
                {
                    Label lbl_pay = (Label)rg_Gratuity.Items[index].FindControl("lbl_Payable");
                    Label lbl_max1 = new Label();
                    lbl_max1 = (Label)rg_Gratuity.Items[index].FindControl("lbl_Maxamt");
                    lbl_max1.Text = rntxt_Maximun.Text;
                    Label lbl_amt1 = (Label)rg_Gratuity.Items[index].FindControl("lbl_Amount");
                    if (lbl_amt1.Text != string.Empty)
                    {
                        if (Convert.ToDouble(lbl_amt1.Text) >= Convert.ToDouble(lbl_max1.Text))
                        {
                            lbl_pay.Text = lbl_max1.Text;
                        }
                        else
                        {
                            lbl_pay.Text = lbl_amt1.Text;
                        }
                    }
                }




            }
            else
            {
                BLL.ShowMessage(this, "No Employee Has Finished Five Years Of Service For The Selected Businessunit!");
                btn_Cancel.Enabled = true;
                rg_Gratuity.DataSource = dt_null;
                rg_Gratuity.DataBind();
            }
            btn_Save.Visible = true;
            btn_Save.Enabled = true;
            btn_Cancel.Visible = true;
            btn_Cancel.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Gratuity", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

            return;
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
            int count = 0;
            bool flag = false;
            int exist = 0;
            if (rg_Gratuity.Items.Count > 0)
            {
                for (int index = 0; index < rg_Gratuity.Items.Count; index++)
                {
                    CheckBox CHECK = new CheckBox();
                    CHECK = rg_Gratuity.Items[index].FindControl("chk_Check") as CheckBox;
                    if (CHECK.Checked)
                    {
                        flag = true;
                        _obj_smhr_gratuity.OPERATION = operation.Insert;
                        _obj_smhr_gratuity.EMP_ID = Convert.ToInt32(rg_Gratuity.Items[index]["EMP_ID"].Text);
                        _obj_smhr_gratuity.Emp_name = rg_Gratuity.Items[index]["EMP_NAME"].Text;
                        _obj_smhr_gratuity.Emp_exp = Convert.ToInt32(rg_Gratuity.Items[index]["EXPERIENCE"].Text);
                        _obj_smhr_gratuity.EMP_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_Businessunit.SelectedValue.ToString());
                        Label lbl_amt = (Label)rg_Gratuity.Items[index].FindControl("lbl_Amount");
                        _obj_smhr_gratuity.Emp_amount = Convert.ToDouble(lbl_amt.Text);
                        _obj_smhr_gratuity.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_smhr_gratuity.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                        Label lbl_currency = (Label)rg_Gratuity.Items[index].FindControl("lbl_Currency");
                        _obj_smhr_gratuity.Emp_currency = lbl_currency.Text;

                        Label lbl_maximum = (Label)rg_Gratuity.Items[index].FindControl("lbl_Maxamt");
                        _obj_smhr_gratuity.Emp_max = lbl_maximum.Text;

                        Label lbl_paying = (Label)rg_Gratuity.Items[index].FindControl("lbl_Payable");
                        _obj_smhr_gratuity.Emp_payableamount = lbl_paying.Text;

                        _obj_smhr_gratuity.Emp_nominee = rg_Gratuity.Items[index]["NOMINEE"].Text;
                        _obj_smhr_gratuity.EMP_DOJ = Convert.ToDateTime(rg_Gratuity.Items[index]["EMP_DOJ"].Text);
                        _obj_smhr_gratuity.EMP_PERIOD = DateTime.Now;
                        _obj_smhr_gratuity.Emp_resgstatus = rg_Gratuity.Items[index]["TYPE"].Text;
                        _obj_smhr_gratuity.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        int Iresult = Convert.ToInt32(BLL.set_Gratutityemp(_obj_smhr_gratuity));
                        if (Iresult > 0)
                        {
                            exist += Iresult;
                            CHECK = rg_Gratuity.Items[index].FindControl("chk_Check") as CheckBox;
                            CHECK.Enabled = false;
                            CHECK.Checked = false;
                            rg_Gratuity.Items[index].Visible = false;
                            rg_Gratuity.Items[index].RemoveChildSelectedItems();
                        }
                    }
                    if (CHECK.Enabled == false)
                    {
                        count = 1;
                    }
                }
                if (flag == true)
                {
                    BLL.ShowMessage(this, "" + exist + "  Employees Sent For Approval!");
                }
                else
                {
                    if (count != 0)
                    {
                        BLL.ShowMessage(this, "NO Employee Found To Sent Them For Approval!");
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Select An Employee!");
                    }
                }

            }
            else
            {
                BLL.ShowMessage(this, "NO Employee Has Finished Five Years Of Service For The Selected Businessunit!");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Gratuity", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

            return;
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
                //DataTable dt_employee1 = new DataTable();
                CheckBox Chk_All = (CheckBox)sender;
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
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Gratuity", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

            return;
        }
    }
    #endregion
    #region Canel
    /// <summary>
    /// cancelling the selected businessunit and all
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
            // btn_Approve.Enabled = false;
            chklst_Payitems.Visible = false;
            payitems.Visible = false;
            btn_Save.Visible = false;
            rntxt_Maximun.Text = "";
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Gratuity", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

            return;
        }
    }
    #endregion
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

            return;
        }
    }
    #endregion
    #region Maximum
    /// <summary>
    /// this enables payitem 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rntxt_Maximun_TextChanged(object sender, EventArgs e)
    {
        //rlist_Payitems.ClearSelection();
        try
        {
            chklst_Payitems.Items.Clear();
            if (rntxt_Maximun.Text != string.Empty)
            {
                if (Convert.ToDouble(rntxt_Maximun.Text) > 0)
                {
                    double round = Convert.ToDouble(rntxt_Maximun.Text);
                    rntxt_Maximun.Text = Convert.ToString(Math.Round(round, 0));
                    maxamounts = rntxt_Maximun.Text;
                    rlist_Payitems.Enabled = true;
                }
                else
                {
                    BLL.ShowMessage(this, "Maximum Amount Must be Greater Than Zero");
                    rlist_Payitems.Enabled = false;
                    rlist_Payitems.ClearSelection();
                }
            }
            else
            {
                BLL.ShowMessage(this, "Maximun Amount is Required");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Gratuity", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

            return;
        }
    }
    #endregion
}
