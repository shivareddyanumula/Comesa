using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using SMHR;

public partial class Payroll_frm_SalDetails : System.Web.UI.Page
{
    SMHR_PAYROLL _obj_smhr_payroll;
    DataTable dt_income = new DataTable();
    DataTable dt_deductions = new DataTable();
    DataTable dt_Benefitable;
    DataView dv_Deductions;
    DataView dv_Income;
    DataView dv_Benefitable;
    

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                LoadData();
                LoadDetails();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_SalDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    private void LoadData()
    {
        try
        {
            _obj_smhr_payroll = new SMHR_PAYROLL();
            _obj_smhr_payroll.PERIODDTLID = Convert.ToInt32(Convert.ToString(Request.QueryString["PDID"]));
            if (Convert.ToString(Request.QueryString["Status"]).ToUpper() == "APPROVED")
            {
                _obj_smhr_payroll.MODE = 14;
                _obj_smhr_payroll.STATUS = 1;
                _obj_smhr_payroll.EMP_ID = Convert.ToInt32(Convert.ToString(Request.QueryString["ID"]));
                _obj_smhr_payroll.TRANID = Convert.ToInt32(Convert.ToString(Request.QueryString["Trid"]));
                DataTable dt = BLL.get_SalDetails(_obj_smhr_payroll);
                //COMMENTED ON 09.12.2013
                ////if (dt.Rows.Count > 0)
                ////{
                ////    if (Convert.ToInt32(dt.Rows[0]["LOCALISATION"]) == 1)
                ////    {
                ////        if (Convert.ToString(dt.Rows[0]["FLAG"]) == "Y")
                ////        {
                ////            double netpay_bu = 0.0;
                ////            for (int index = 0; index < dt.Rows.Count; index++)
                ////            {
                ////                if (Convert.ToBoolean(dt.Rows[index]["PAYITEM_ISBENEFITABLE"]) == false)
                ////                netpay_bu += Convert.ToDouble(dt.Rows[index]["NETAMT"]);
                ////            }
                ////            lbl_BU_Amount.Text = "Net Salary in " + Convert.ToString(dt.Rows[0]["BU_CURRCODE"]) + " : " + netpay_bu;
                ////            lbl_BU_Amount.Visible = true;
                ////        }
                ////        else
                ////            lbl_BU_Amount.Visible = false;
                ////    }
                ////    else
                ////    {
                ////        lbl_Amount.Text = "Net Salary : " + Convert.ToString(Request.QueryString["sal"]);
                ////        lbl_BU_Amount.Visible = false;
                ////    }
                ////    lbl_Amount.Text = "Net Salary in " + Convert.ToString(dt.Rows[0]["EMP_CURRCODE"]) + " : " + Convert.ToString(Request.QueryString["sal"]);
                ////}
                ////else
                ////    lbl_Amount.Text = "Net Salary : " + Convert.ToString(Request.QueryString["sal"]);
                
                dt_income=dt.Clone();
                dt_deductions = dt.Clone();
                if (dt.Rows.Count != 0)
                {
                    dv_Income = dt.DefaultView;
                    dv_Income.RowFilter = "HR_MASTER_CODE='Income' AND PAYITEM_ISBENEFITABLE='False'";
                    //dv_Income.RowFilter = "HR_MASTER_CODE IN ('Income','Employer') AND PAYITEM_ISBENEFITABLE='False'";
                    dt_income = dv_Income.ToTable();

                    dv_Deductions = dt.DefaultView;
                    dv_Deductions.RowFilter = "HR_MASTER_CODE='Deductions' AND PAYITEM_ISBENEFITABLE='False'";
                    dt_deductions = dv_Deductions.ToTable();

                    dv_Benefitable = dt.DefaultView;
                    dv_Benefitable.RowFilter = "PAYITEM_ISBENEFITABLE='True'";
                    dt_Benefitable = dv_Benefitable.ToTable(); 

                    if (dt_income.Rows.Count > 0)
                    {
                        RG_SalDetails.DataSource = dt_income;
                        RG_SalDetails.DataBind();
                    }
                    else
                    {
                        Income.Visible = false;
                        Incomegrid.Visible = false;
                    }
                    if (dt_deductions.Rows.Count > 0)
                    {
                        Rg_Deductions.DataSource = dt_deductions;
                        Rg_Deductions.DataBind();
                    }
                    else
                    {
                        Deductions.Visible = false;
                        Deductionsgrid.Visible = false;
                    }

                    if (dt_Benefitable.Rows.Count > 0)
                    {
                        Rg_Benefitable.DataSource = dt_Benefitable;
                        Rg_Benefitable.DataBind();
                    }
                    else
                    {
                        Benefitable.Visible = false;
                        Benefitable.Visible = false;
                    }
                }
                else
                {
                    _obj_smhr_payroll.MODE = 21;
                    _obj_smhr_payroll.STATUS = 1;
                    _obj_smhr_payroll.EMP_ID = Convert.ToInt32(Convert.ToString(Request.QueryString["ID"]));
                    _obj_smhr_payroll.TRANID = Convert.ToInt32(Convert.ToString(Request.QueryString["Trid"]));
                    DataTable dt1 = BLL.get_SalDetails(_obj_smhr_payroll);
                    if (dt1.Rows.Count != 0)
                    {                        
                        dv_Income = dt1.DefaultView;
                        dv_Income.RowFilter = "HR_MASTER_CODE='Income' AND PAYITEM_ISBENEFITABLE='False'";
                        dt_income = dv_Income.ToTable();
                        
                        dv_Deductions = dt1.DefaultView;
                        dv_Deductions.RowFilter = "HR_MASTER_CODE='Deductions' AND PAYITEM_ISBENEFITABLE='False'";
                        dt_deductions = dv_Deductions.ToTable();

                        dv_Benefitable = dt1.DefaultView;
                        dv_Benefitable.RowFilter = "PAYITEM_ISBENEFITABLE='True'";
                        dt_Benefitable = dv_Benefitable.ToTable(); 
                        if (dt_income.Rows.Count > 0)
                        {                            
                            RG_SalDetails.DataSource = dt_income;
                            RG_SalDetails.DataBind();
                        }
                        else
                        {
                            Income.Visible = false;
                            Incomegrid.Visible = false;
                        }
                        if (dt_deductions.Rows.Count > 0)
                        {
                            Rg_Deductions.DataSource = dt_deductions;
                            Rg_Deductions.DataBind();
                        }
                        else
                        {
                            Deductions.Visible = false;
                            Deductionsgrid.Visible = false;
                        }
                        if (dt_Benefitable.Rows.Count > 0)
                        {
                            Rg_Benefitable.DataSource = dt_Benefitable;
                            Rg_Benefitable.DataBind();
                        }
                        else
                        {
                            Benefitable.Visible = false;
                            Benefitable.Visible = false;
                        }
                    }
                }
            }
            else if (Convert.ToString(Request.QueryString["Status"]).ToUpper() == "PENDING")
            {
                _obj_smhr_payroll.MODE = 14;
                _obj_smhr_payroll.STATUS = 0;
                _obj_smhr_payroll.EMP_ID = Convert.ToInt32(Convert.ToString(Request.QueryString["ID"]));
                _obj_smhr_payroll.TRANID = Convert.ToInt32(Convert.ToString(Request.QueryString["Trid"]));
                DataTable dt = BLL.get_SalDetails(_obj_smhr_payroll);
                ////if (dt.Rows.Count > 0)
                ////{
                ////    if (Convert.ToInt32(dt.Rows[0]["LOCALISATION"]) == 1)
                ////    {
                ////        if (Convert.ToString(dt.Rows[0]["FLAG"]) == "Y")
                ////        {
                ////            double netpay_bu = 0.0;
                ////            for (int index = 0; index < dt.Rows.Count; index++)
                ////            {
                ////                if (Convert.ToBoolean(dt.Rows[index]["PAYITEM_ISBENEFITABLE"]) == false)
                ////                    netpay_bu += Convert.ToDouble(dt.Rows[index]["NETAMT"]);
                ////            }
                ////            lbl_BU_Amount.Text = "Net Salary in " + Convert.ToString(dt.Rows[0]["BU_CURRCODE"]) + " : " + netpay_bu;
                ////            lbl_BU_Amount.Visible = true;
                ////        }
                ////        else
                ////            lbl_BU_Amount.Visible = false;
                ////    }
                ////    else
                ////    {
                ////        lbl_Amount.Text = "Net Salary : " + Convert.ToString(Request.QueryString["sal"]);
                ////        lbl_BU_Amount.Visible = false;
                ////    }
                ////    lbl_Amount.Text = "Net Salary in " + Convert.ToString(dt.Rows[0]["EMP_CURRCODE"]) + " : " + Convert.ToString(Request.QueryString["sal"]);
                ////}
                ////else
                ////    lbl_Amount.Text = "Net Salary : " + Convert.ToString(Request.QueryString["sal"]);
               
                dt_income = dt.Clone();
                dt_deductions = dt.Clone();
                if (dt.Rows.Count != 0)
                {
                    dv_Income = dt.DefaultView;
                    dv_Income.RowFilter = "HR_MASTER_CODE='Income' AND PAYITEM_ISBENEFITABLE='False'";
                    //dv_Income.RowFilter = "HR_MASTER_CODE IN ('Income','Employer') AND PAYITEM_ISBENEFITABLE='False'";
                    //dv_Income. = "PAYITEM_ISBENEFITABLE='False'";

                    dt_income = dv_Income.ToTable();

                    dv_Deductions = dt.DefaultView;
                    dv_Deductions.RowFilter = "HR_MASTER_CODE='Deductions' AND PAYITEM_ISBENEFITABLE='False'";
                   
                    dt_deductions = dv_Deductions.ToTable();

                    dv_Benefitable = dt.DefaultView;
                    dv_Benefitable.RowFilter = "PAYITEM_ISBENEFITABLE='True' ";
                    dt_Benefitable = dv_Benefitable.ToTable(); 
                    if (dt_income.Rows.Count > 0)
                    {
                        RG_SalDetails.DataSource = dt_income;
                        RG_SalDetails.DataBind();
                    }
                    else
                    {
                        Income.Visible = false;
                        Incomegrid.Visible = false;
                    }
                    if (dt_deductions.Rows.Count > 0)
                    {
                        Rg_Deductions.DataSource = dt_deductions;
                        Rg_Deductions.DataBind();
                    }
                    else
                    {
                        Deductions.Visible = false;
                        Deductionsgrid.Visible = false;
                    }
                    if (dt_Benefitable.Rows.Count > 0)
                    {
                        Rg_Benefitable.DataSource = dt_Benefitable;
                        Rg_Benefitable.DataBind();
                    }
                    else
                    {
                        Benefitable.Visible = false;
                        Benefitable.Visible = false;
                    }
                }
            }
            else
            {
                _obj_smhr_payroll.MODE = 24;
                _obj_smhr_payroll.STATUS = 2;
                _obj_smhr_payroll.EMP_ID = Convert.ToInt32(Convert.ToString(Request.QueryString["ID"]));
                _obj_smhr_payroll.TRANID = Convert.ToInt32(Convert.ToString(Request.QueryString["Trid"]));
                DataTable dt = BLL.get_SalDetails(_obj_smhr_payroll);
                ////if (dt.Rows.Count > 0)
                ////{
                ////    if (Convert.ToInt32(dt.Rows[0]["LOCALISATION"]) == 1)
                ////    {
                ////        if (Convert.ToString(dt.Rows[0]["FLAG"]) == "Y")
                ////        {
                ////            double netpay_bu = 0.0;
                ////            for (int index = 0; index < dt.Rows.Count; index++)
                ////            {
                ////                if (Convert.ToBoolean(dt.Rows[index]["PAYITEM_ISBENEFITABLE"]) == false)
                ////                netpay_bu += Convert.ToDouble(dt.Rows[index]["NETAMT"]);
                ////            }
                ////            lbl_BU_Amount.Text = "Net Salary in " + Convert.ToString(dt.Rows[0]["BU_CURRCODE"]) + " : " + netpay_bu;
                ////            lbl_BU_Amount.Visible = true;
                ////        }
                ////        else
                ////            lbl_BU_Amount.Visible = false;
                ////    }
                ////    else
                ////    {
                ////        lbl_Amount.Text = "Net Salary : " + Convert.ToString(Request.QueryString["sal"]);
                ////        lbl_BU_Amount.Visible = false;
                ////    }
                ////    lbl_Amount.Text = "Net Salary in " + Convert.ToString(dt.Rows[0]["EMP_CURRCODE"]) + " : " + Convert.ToString(Request.QueryString["sal"]);
                ////}
                ////else
                ////    lbl_Amount.Text = "Net Salary : " + Convert.ToString(Request.QueryString["sal"]);
                
                dt_income = dt.Clone();
                dt_deductions = dt.Clone();
                if (dt.Rows.Count != 0)
                {
                    dv_Income = dt.DefaultView;
                    dv_Income.RowFilter = "HR_MASTER_CODE='Income' AND PAYITEM_ISBENEFITABLE='False'";
                    //dv_Income. = "PAYITEM_ISBENEFITABLE='False'";

                    dt_income = dv_Income.ToTable();

                    dv_Deductions = dt.DefaultView;
                    dv_Deductions.RowFilter = "HR_MASTER_CODE='Deductions' AND PAYITEM_ISBENEFITABLE='False'";

                    dt_deductions = dv_Deductions.ToTable();

                    dv_Benefitable = dt.DefaultView;
                    dv_Benefitable.RowFilter = "PAYITEM_ISBENEFITABLE='True' ";
                    dt_Benefitable = dv_Benefitable.ToTable(); 

                    if (dt_income.Rows.Count > 0)
                    {
                        RG_SalDetails.DataSource = dt_income;
                        RG_SalDetails.DataBind();
                    }
                    else
                    {
                        Income.Visible = false;
                        Incomegrid.Visible = false;
                    }
                    if (dt_deductions.Rows.Count > 0)
                    {
                        Rg_Deductions.DataSource = dt_deductions;
                        Rg_Deductions.DataBind();
                    }
                    else
                    {
                        Deductions.Visible = false;
                        Deductionsgrid.Visible = false;
                    }
                    if (dt_Benefitable.Rows.Count > 0)
                    {
                        Rg_Benefitable.DataSource = dt_Benefitable;
                        Rg_Benefitable.DataBind();
                    }
                    else
                    {
                        Benefitable.Visible = false;
                        Benefitable.Visible = false;
                    }
                }
            }
            if (Request.QueryString["sal"] != null)
            {
                lbl_Amount.Text = "Net Salary : " + Convert.ToString(Request.QueryString["sal"]);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_SalDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadDetails()
    {
        try
        {
            _obj_smhr_payroll = new SMHR_PAYROLL();
            _obj_smhr_payroll.MODE = 15;
            _obj_smhr_payroll.EMP_ID = Convert.ToInt32(Convert.ToString(Request.QueryString["ID"]));
            DataTable dt = BLL.get_SalDetails(_obj_smhr_payroll);
            if (dt.Rows.Count != 0)
            {
                lbl_Code.Text = Convert.ToString(dt.Rows[0]["EMP_EMPCODE"]);
                lbl_Name.Text = Convert.ToString(dt.Rows[0]["EMPNAME"]);
                lbl_DOJ.Text = Convert.ToString(dt.Rows[0]["EMPDOJ"]);
                lbl_Position.Text = Convert.ToString(dt.Rows[0]["POSITIONS_CODE"]);
                lbl_BusUnit.Text = Convert.ToString(dt.Rows[0]["BUSINESSUNIT_CODE"]);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_SalDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

}
