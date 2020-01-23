using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using SMHR;

public partial class HR_frm_emppayelements : System.Web.UI.Page
{

    SMHR_SALARYSTRUCT _obj_smhr_salaryStruct;
    SMHR_BUSINESSUNIT _obj_smhr_businessunit;
    SMHR_PAYITEMS_EMP _obj_smhr_emp_payitems;
    SMHR_PERIODDTL _obj_Smhr_Prddtl;

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            Page.Validate();
            if (!Page.IsPostBack)
            {

                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("EMPLOYEE PAY ELEMENTS");
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
                    Rg_Employeesal.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Save.Visible = false;
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
                Rg_Employeesal.Visible = false;
                LoadCombos();



            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emppayelements", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
           
        }
    }

    private void LoadEmptyData()
    {
        try
        {
            _obj_smhr_salaryStruct = new SMHR_SALARYSTRUCT();
            _obj_smhr_salaryStruct.OPERATION = operation.EMPTY1;
            DataTable dt_Details = BLL.get_EmptyValues(_obj_smhr_salaryStruct);
            Rg_Employeesal.DataSource = dt_Details;
            Rg_Employeesal.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emppayelements", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
           
        }

    }

    private void LoadCombos()
    {
        try
        {
            _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
            _obj_smhr_businessunit.OPERATION = operation.Select;
            _obj_smhr_businessunit.ISDELETED = true;
            DataTable dt_Details = BLL.get_BusinessUnit(_obj_smhr_businessunit);
            rcb_BussinessUnit.DataSource = dt_Details;
            rcb_BussinessUnit.DataValueField = "BUSINESSUNIT_ID";
            rcb_BussinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            rcb_BussinessUnit.DataBind();
            rcb_BussinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emppayelements", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcb_BussinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            Rg_Employeesal.Visible = true;
            if (rcb_BussinessUnit.SelectedIndex != 0)
            {

                _obj_smhr_salaryStruct = new SMHR_SALARYSTRUCT();
                _obj_smhr_salaryStruct.OPERATION = operation.EMPTY1;
                DataTable dt_Details = BLL.get_EmptyValues(_obj_smhr_salaryStruct);
                if (dt_Details.Rows.Count != 0)
                {

                    Rg_Employeesal.DataSource = dt_Details;
                    Rg_Employeesal.DataBind();
                }
                else
                {
                    LoadEmptyData();

                }
            }
            else
            {
                BLL.ShowMessage(this, "Business Unit is not available");
                return;

            }
            rcmb_Payitem.Items.Clear();
            _obj_smhr_salaryStruct = new SMHR_SALARYSTRUCT();
            _obj_smhr_salaryStruct.OPERATION = operation.Empty;
            DataTable dt = BLL.get_EmptyValues(_obj_smhr_salaryStruct);
            rcmb_Payitem.DataSource = dt;
            rcmb_Payitem.DataValueField = "PAYITEM_ID";
            rcmb_Payitem.DataTextField = "PAYITEM_PAYITEMNAME";
            rcmb_Payitem.DataBind();
            rcmb_Payitem.Items.Insert(0, new RadComboBoxItem("Select"));
            rcmb_Period.Items.Clear();
            rcmb_Period.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emppayelements", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_Payitem_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rcmb_Period.Items.Clear();
            _obj_Smhr_Prddtl = new SMHR_PERIODDTL();
            _obj_Smhr_Prddtl.OPERATION = operation.Select;
            _obj_Smhr_Prddtl.ISDELETED = true;
            DataTable dt_Period = BLL.get_PeriodDetails(_obj_Smhr_Prddtl);
            rcmb_Period.DataSource = dt_Period;
            rcmb_Period.DataValueField = "PRDDTL_ID";
            rcmb_Period.DataTextField = "PRDDTL_NAME";
            rcmb_Period.DataBind();
            rcmb_Period.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emppayelements", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_Period_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Payitem.SelectedIndex != 0 && rcmb_Payitem.SelectedItem.Text != "Select")
            {
                _obj_smhr_emp_payitems = new SMHR_PAYITEMS_EMP();
                _obj_smhr_emp_payitems.SMHR_EMP_PAYITEMS_PAYITEMID = Convert.ToInt32(rcmb_Payitem.SelectedValue);
                _obj_smhr_emp_payitems.SMHR_EMP_PAYITEMS_PERIODID = Convert.ToInt32(rcmb_Period.SelectedValue);
                _obj_smhr_emp_payitems.OPERATION = operation.Check1;
                DataTable dt = BLL.get_EmpDetails_1(_obj_smhr_emp_payitems);
                if (dt.Rows.Count != 0)
                {
                    Rg_Employeesal.DataSource = dt;
                    Rg_Employeesal.DataBind();
                }
                else
                {
                    //LoadEmptyData();
                }
                int i;
                for (i = 0; i <= Rg_Employeesal.Items.Count - 1; i++)
                {
                    CheckBox chkChoose = new CheckBox();
                    TextBox txtgetVal = new TextBox();
                    chkChoose = Rg_Employeesal.Items[i].FindControl("chk_Choose") as CheckBox;
                    txtgetVal = Rg_Employeesal.Items[i].FindControl("txtNumber") as TextBox;

                    if (Convert.ToString(txtgetVal.Text) != "")
                    {
                        chkChoose.Checked = true;

                    }
                    else
                    {
                        chkChoose.Checked = false;
                    }
                }
            }
            else
            {
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emppayelements", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {

        try
        {
            int i;
            int j = 0;

            for (i = 0; i <= Rg_Employeesal.Items.Count - 1; i++)
            {
                Label lblCalMode = new Label();
                TextBox txtgetVal = new TextBox();
                CheckBox chkChoose = new CheckBox();
                chkChoose = Rg_Employeesal.Items[i].FindControl("chk_Choose") as CheckBox;
                txtgetVal = Rg_Employeesal.Items[i].FindControl("txtNumber") as TextBox;

                if (Convert.ToString(txtgetVal.Text) != string.Empty)
                {
                    if (chkChoose.Checked == false)
                    {
                        BLL.ShowMessage(this, "Please check an employee to which you want to give Value");
                        return;
                    }
                }
                else
                {
                    j = j + 1;
                }
                if (chkChoose.Checked == true)
                {
                    if (Convert.ToString(txtgetVal.Text) == string.Empty)
                    {
                        BLL.ShowMessage(this, "Please enter value");
                        return;
                    }
                }
                else
                {
                    j = j + 1;
                }
            }

            bool status = false;
            _obj_smhr_emp_payitems = new SMHR_PAYITEMS_EMP();
            _obj_smhr_emp_payitems.OPERATION = operation.Delete;
            _obj_smhr_emp_payitems.SMHR_EMP_PAYITEMS_PAYITEMID = Convert.ToInt32(rcmb_Payitem.SelectedValue);
            _obj_smhr_emp_payitems.SMHR_EMP_PAYITEMS_PERIODID = Convert.ToInt32(rcmb_Period.SelectedValue);
            //_obj_smhr_emp_payitems.SMHR_EMP_PAYITEMS_EMPID = Convert.ToInt32(Rg_Employeesal.Items[i]["EMP_ID"].Text);
            status = BLL.set_EmpPayElements_1(_obj_smhr_emp_payitems);
            if (status == true)
            {
                int index;
                for (index = 0; index <= Rg_Employeesal.Items.Count - 1; index++)
                {
                    Label lblCode = new Label();
                    TextBox txtVal = new TextBox();
                    CheckBox chkChoose = new CheckBox();
                    chkChoose = Rg_Employeesal.Items[index].FindControl("chk_Choose") as CheckBox;
                    lblCode = Rg_Employeesal.Items[index].FindControl("lbl_empid") as Label;
                    txtVal = Rg_Employeesal.Items[index].FindControl("txtNumber") as TextBox;
                    if (Convert.ToString(txtVal.Text) != string.Empty)
                    {
                        _obj_smhr_emp_payitems.SMHR_EMP_PAYITEMS_EMPID = Convert.ToInt32(lblCode.Text);
                        _obj_smhr_emp_payitems.SMHR_EMP_PAYITEMS_PAYITEMID = Convert.ToInt32(rcmb_Payitem.SelectedValue);
                        _obj_smhr_emp_payitems.SMHR_EMP_PAYITEMS_PERIODID = Convert.ToInt32(rcmb_Period.SelectedValue);
                        if (chkChoose.Checked)
                            _obj_smhr_emp_payitems.SMHR_EMP_PAYITEMS_VALUE = Convert.ToDouble(txtVal.Text);
                        else
                            _obj_smhr_emp_payitems.SMHR_EMP_PAYITEMS_VALUE = -1;
                        _obj_smhr_emp_payitems.SMHR_EMP_PAYITEMS_CHECKED = true;
                        _obj_smhr_emp_payitems.OPERATION = operation.Insert;
                        _obj_smhr_emp_payitems.SMHR_EMP_PAYITEMS_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_smhr_emp_payitems.SMHR_EMP_PAYITEMS_CREATEDDATE = DateTime.Now;
                        status = BLL.set_EmpPayElements_1(_obj_smhr_emp_payitems);
                    }
                }

                BLL.ShowMessage(this, "Employee Pay Elements Saved Succesfully");
                return;
            }
            else
            {
                BLL.ShowMessage(this, "Please select an employee and payitem value");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emppayelements", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            ClearFields();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emppayelements", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void ClearFields()
    {
        try
        {
            Rg_Employeesal.Visible = false;
            rcb_BussinessUnit.Items.Clear();
            rcmb_Payitem.Items.Clear();
            LoadCombos();
            rcmb_Payitem.Items.Insert(0, new RadComboBoxItem("Select"));
            rcmb_Period.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emppayelements", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

}
