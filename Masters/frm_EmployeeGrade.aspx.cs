﻿using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Masters_frm_EmployeeGrade : System.Web.UI.Page
{
    string strfilename2;
    DataSet ds = new DataSet();
    SMHR_EMPLOYEEGRADE _obj_Smhr_EmployeeGrade;
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Grade");//COUNTRY");
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
                    Rg_EmployeeGrade.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
                Page.Validate();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeGrade", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void clearControls()
    {
        try
        {
            lbl_EmployeeGradeID.Text = string.Empty;
            rtxt_EmployeeGradeCode.Text = string.Empty;
            rtxt_EmployeeGradeCode.Enabled = true;
            rtxt_EMPLOYEEGRADE_RANK.Enabled = true;
            rtxt_EmployeeGradeName.Text = string.Empty;
            rtxt_EMPLOYEEGRADE_RANK.Text = string.Empty;
            btn_Save.Visible = false;
            btn_Update.Visible = false;

            tblSlabs.Visible = false;
            ViewState["dtGridData"] = null;
            ViewState["dtCopyGridData"] = null;
            rg_SlabGrid.Enabled = true;
            btn_AddSlabAmount.Enabled = true;
            rtxt_SlabAmount.Enabled = true;
            rtxt_SlabAmount.Text = string.Empty;
            btn_SaveSlabs.Enabled = true;
            btn_FinalizeSlabs.Enabled = true;
            tbl_CopySlabTable.Visible = false;
            rcb_ScalesSlabFromPeriod.Enabled = true;
            rcb_ScalesSlabFromPeriod.SelectedIndex = -1;

            rcb_ToFinYear.SelectedIndex = -1;
            lbl_SlabMessage.Text = string.Empty;
            lbl_CopySlabMessage.Text = string.Empty;
            //btn_SaveSlabs.Text = "Save Slabs";
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeGrade", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            clearControls();



            LinkButton lnkTemp = sender as LinkButton;
            GridDataItem item = lnkTemp.NamingContainer as GridDataItem;
            ViewState["CURRENTPERIODID"] = item["CURRENTPERIODID"].Text;
            ViewState["EmployeeGrade_ID"] = item["EmployeeGrade_ID"].Text;

            rcb_ScalesSlabFromPeriod.Items.Clear();
            rcb_ScalesSlabFromPeriod.DataSource = BLL.get_SlabPeriods(new SMHR_PERIOD { ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]), PERIOD_ID = 0 });
            rcb_ScalesSlabFromPeriod.DataBind();
            rcb_ScalesSlabFromPeriod.Items.Insert(0, new RadComboBoxItem { Text = "Select", Value = "0" });
            //rcb_ScalesSlabFromPeriod.SelectedValue = item["CURRENTPERIODID"].Text;


            rtxt_EmployeeGradeCode.Enabled = false;
            rtxt_EMPLOYEEGRADE_RANK.Enabled = false;
            SMHR_EMPLOYEEGRADE _obj_Smhr_EmployeeGrade = new SMHR_EMPLOYEEGRADE();
            _obj_Smhr_EmployeeGrade.EMPLOYEEGRADE_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            // _obj_Smhr_EmployeeGrade.PERIOD_ID = item["CURRENTPERIODID"].Text != "&nbsp;" ? Convert.ToInt32(item["CURRENTPERIODID"].Text) : 0;
            _obj_Smhr_EmployeeGrade.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataSet ds = BLL.get_EmployeeGrade(_obj_Smhr_EmployeeGrade);
            lbl_EmployeeGradeID.Text = Convert.ToString(ds.Tables[0].Rows[0]["EmployeeGrade_ID"]);
            rtxt_EmployeeGradeCode.Text = Convert.ToString(ds.Tables[0].Rows[0]["EmployeeGrade_CODE"]);
            rtxt_EmployeeGradeName.Text = Convert.ToString(ds.Tables[0].Rows[0]["EmployeeGrade_NAME"]);
            rtxt_EMPLOYEEGRADE_RANK.Text = Convert.ToString(ds.Tables[0].Rows[0]["EMPLOYEEGRADE_RANK"]);

            //rcb_ScalesSlabFromPeriod.Enabled = false;
            //if (ds.Tables[1].Rows.Count > 0)
            //    rcb_ScalesSlabFromPeriod.Enabled = true;
            //else
            //    rcb_ScalesSlabFromPeriod.Enabled = false;

            if (ds.Tables[1].Rows.Count > 0)
            {
                if (Convert.ToBoolean(ds.Tables[1].Rows[0]["ISFINALIZED"]) == true)
                {
                    rg_SlabGrid.Enabled = false;
                    btn_AddSlabAmount.Enabled = false;
                    rtxt_SlabAmount.Enabled = false;
                    btn_SaveSlabs.Enabled = false;
                    btn_FinalizeSlabs.Enabled = false;
                    lbl_SlabMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("#cc0000");
                    lbl_SlabMessage.Text = "Finalized Slabs For Financial Year " + "\"" + rcb_ScalesSlabFromPeriod.SelectedItem.Text + "\"";
                }
                else
                {
                    rg_SlabGrid.Enabled = true;
                    btn_AddSlabAmount.Enabled = true;
                    rtxt_SlabAmount.Enabled = true;
                    btn_SaveSlabs.Enabled = true;
                    btn_FinalizeSlabs.Enabled = true;
                    lbl_SlabMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("#3399ff");
                    lbl_SlabMessage.Text = "Slabs Not Finalized For Financial Year " + "\"" + rcb_ScalesSlabFromPeriod.SelectedItem.Text + "\"";
                }
            }
            else
            {
                if (rcb_ScalesSlabFromPeriod.SelectedItem.Text != "Select" && rcb_ScalesSlabFromPeriod.SelectedItem.Text != string.Empty)
                {
                    lbl_SlabMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("#3399ff");
                    lbl_SlabMessage.Text = "Slabs Not Defined For Financial Year " + "\"" + rcb_ScalesSlabFromPeriod.Text + "\"";
                }
                else
                {
                    lbl_SlabMessage.Text = string.Empty;
                }
            }

            //rg_SlabGrid.DataSource = ds.Tables[1];
            rg_SlabGrid.DataSource = LoadSlabData();
            rg_SlabGrid.DataBind();
            tblSlabs.Visible = true;
            Rm_CY_page.SelectedIndex = 1;

            //code for security
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Update.Visible = false;
            }
            else
            {
                btn_Update.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeGrade", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }
    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            clearControls();

            rcb_ScalesSlabFromPeriod.DataSource = BLL.get_SlabPeriods(new SMHR_PERIOD { ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]), PERIOD_ID = 0 });
            rcb_ScalesSlabFromPeriod.DataBind();
            rcb_ScalesSlabFromPeriod.Items.Insert(0, new RadComboBoxItem { Text = "Select", Value = "0" });

            btn_Save.Visible = true;
            Rm_CY_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeGrade", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void Rg_EmployeeGrade_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeGrade", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    public void LoadGrid()
    {
        try
        {
            _obj_Smhr_EmployeeGrade = new SMHR_EMPLOYEEGRADE();
            _obj_Smhr_EmployeeGrade.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT = BLL.get_EmployeeGrade(_obj_Smhr_EmployeeGrade).Tables[0];
            Rg_EmployeeGrade.DataSource = DT;

            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeGrade", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {


            _obj_Smhr_EmployeeGrade = new SMHR_EMPLOYEEGRADE();
            SMHR_EMPLOYEEGRADE _obj_Smhr_EmployeeGrade1 = new SMHR_EMPLOYEEGRADE();
            _obj_Smhr_EmployeeGrade1.OPERATION = operation.Delete;
            _obj_Smhr_EmployeeGrade1.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_EmployeeGrade1.EMPLOYEEGRADE_RANK = Convert.ToDouble(rtxt_EMPLOYEEGRADE_RANK.Text);
            DataSet ds = BLL.get_EmployeeGrade(_obj_Smhr_EmployeeGrade1);

            _obj_Smhr_EmployeeGrade.EMPLOYEEGRADE_CODE = BLL.ReplaceQuote(rtxt_EmployeeGradeCode.Text);
            _obj_Smhr_EmployeeGrade.EMPLOYEEGRADE_NAME = BLL.ReplaceQuote(rtxt_EmployeeGradeName.Text);
            _obj_Smhr_EmployeeGrade.EMPLOYEEGRADE_RANK = Convert.ToDouble(rtxt_EMPLOYEEGRADE_RANK.Text);
            _obj_Smhr_EmployeeGrade.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_EmployeeGrade.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_EmployeeGrade.CREATEDDATE = DateTime.Now;

            _obj_Smhr_EmployeeGrade.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_EmployeeGrade.LASTMDFDATE = DateTime.Now;

            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_UPDATE":
                    _obj_Smhr_EmployeeGrade.EMPLOYEEGRADE_ID = Convert.ToInt32(lbl_EmployeeGradeID.Text);
                    _obj_Smhr_EmployeeGrade.OPERATION = operation.Update;
                    if (BLL.Set_EmployeeGrade(_obj_Smhr_EmployeeGrade))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Updated");

                    break;
                case "BTN_SAVE":
                    _obj_Smhr_EmployeeGrade.OPERATION = operation.Check;
                    if (Convert.ToString(BLL.get_EmployeeGrade(_obj_Smhr_EmployeeGrade).Tables[0].Rows[0]["Count"]) != "0")
                    {
                        BLL.ShowMessage(this, "Scale Already Defined With Same Rank");
                        return;
                    }
                    DataTable dt_rnk = ds.Tables[0];
                    if (dt_rnk.Rows.Count > 0)
                    {
                        BLL.ShowMessage(this, " Rank Already Assigned To Another Scale");
                        return;
                    }
                    _obj_Smhr_EmployeeGrade.OPERATION = operation.Insert;
                    if (BLL.Set_EmployeeGrade(_obj_Smhr_EmployeeGrade))
                        BLL.ShowMessage(this, "Scale Saved Successfully");
                    else
                        BLL.ShowMessage(this, "Scale Not Saved");
                    break;
                default:
                    break;
            }
            rtxt_EmployeeGradeCode.Enabled = false;
            rtxt_EMPLOYEEGRADE_RANK.Enabled = false;
            //Rm_CY_page.SelectedIndex = 0;
            //LoadGrid();
            //Rg_EmployeeGrade.DataBind();

            rg_SlabGrid.DataSource = new DataTable();
            rg_SlabGrid.DataBind();

            tblSlabs.Visible = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeGrade", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearControls();
            Rm_CY_page.SelectedIndex = 0;
            LoadGrid();
            Rg_EmployeeGrade.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeGrade", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private DataTable LoadSlabData()
    {
        DataTable dt = new DataTable();
        try
        {
            DataColumn c = new DataColumn("EMPLOYEEGRADE_SLAB_SRNO", typeof(int));
            c.AutoIncrement = true;
            c.AutoIncrementSeed = 1;
            c.AutoIncrementStep = 1;

            dt.Columns.Add("EMPLOYEEGRADE_SLAB_ID");
            dt.Columns.Add("EMPLOYEEGRADE_SLAB_AMOUNT", typeof(double));
            dt.Columns.Add("EMPLOYEEGRADE_SLAB_PERIOD_ID", typeof(int));
            dt.Columns.Add(c);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeGrade", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return dt;
    }
    protected void rg_SlabGrid_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            rg_SlabGrid.DataSource = LoadSlabData();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeGrade", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    //protected void btn_AddSlabAmount_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        int i = 1;
    //        DataTable dt = new DataTable();
    //        DataColumn c = new DataColumn("EMPLOYEEGRADE_SLAB_SRNO", typeof(int));
    //        c.AutoIncrement = true;
    //        c.AutoIncrementSeed = 1;
    //        c.AutoIncrementStep = 1;

    //        dt.Columns.Add("EMPLOYEEGRADE_SLAB_ID");
    //        dt.Columns.Add("EMPLOYEEGRADE_SLAB_AMOUNT", typeof(double));
    //        dt.Columns.Add("CURRENTPERIODID", typeof(int));
    //        dt.Columns.Add(c);

    //        //DataRow dr;
    //        int SrNo = rg_SlabGrid.MasterTableView.Items.Count;
    //        foreach (GridDataItem item in rg_SlabGrid.MasterTableView.Items)
    //        {
    //            RadNumericTextBox rtxt_SlabAmtGrid = item.FindControl("rtxt_SlabAmountGrid") as RadNumericTextBox;
    //            if (rtxt_SlabAmount.Text != rtxt_SlabAmtGrid.Text)
    //            {
    //                dt.Rows.Add(i, rtxt_SlabAmtGrid.Text, Convert.ToInt32(rcb_ScalesSlabFromPeriod.SelectedValue));
    //                i++;
    //                //dt.Rows.Add(item["EMPLOYEEGRADE_SLAB_ID"].Text.ToString(), rtxt_SlabAmtGrid.Text, Convert.ToInt32(rcb_ScalesSlabFromPeriod.SelectedValue));
    //            }
    //            else
    //            {
    //                BLL.ShowMessage(this, "Slab Amount Already Added");
    //                return;
    //            }
    //        }

    //        dt.Rows.Add((Convert.ToInt32(rg_SlabGrid.MasterTableView.Items.Count) + 1), rtxt_SlabAmount.Text.ToString(), Convert.ToInt32(rcb_ScalesSlabFromPeriod.SelectedValue));

    //        ViewState["dtGridData"] = dt;
    //        rg_SlabGrid.DataSource = dt;
    //        rg_SlabGrid.DataBind();
    //        rtxt_SlabAmount.Text = string.Empty;
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeGrade", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}
    protected void btn_AddSlabAmount_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            DataColumn c = new DataColumn("EMPLOYEEGRADE_SLAB_SRNO", typeof(int));
            c.AutoIncrement = true;
            c.AutoIncrementSeed = 1;
            c.AutoIncrementStep = 1;

            dt.Columns.Add("EMPLOYEEGRADE_SLAB_ID");
            dt.Columns.Add("EMPLOYEEGRADE_SLAB_AMOUNT", typeof(double));
            dt.Columns.Add("CURRENTPERIODID", typeof(int));
            dt.Columns.Add(c);

            DataRow dr;
            int SrNo = rg_SlabGrid.MasterTableView.Items.Count;
            foreach (GridDataItem item in rg_SlabGrid.MasterTableView.Items)
            {
                RadNumericTextBox rtxt_SlabAmtGrid = item.FindControl("rtxt_SlabAmountGrid") as RadNumericTextBox;
                if (rtxt_SlabAmount.Text != rtxt_SlabAmtGrid.Text)
                    dt.Rows.Add(item["EMPLOYEEGRADE_SLAB_ID"].Text.ToString(), rtxt_SlabAmtGrid.Text, Convert.ToInt32(rcb_ScalesSlabFromPeriod.SelectedValue));
                else
                {
                    BLL.ShowMessage(this, "Slab Amount Already Added");
                    return;
                }
            }

            dt.Rows.Add(null, rtxt_SlabAmount.Text.ToString(), Convert.ToInt32(rcb_ScalesSlabFromPeriod.SelectedValue));

            ViewState["dtGridData"] = dt;
            rg_SlabGrid.DataSource = dt;
            rg_SlabGrid.DataBind();
            rtxt_SlabAmount.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeGrade", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_SaveSlabs_Click(object sender, EventArgs e)
    {
        try
        {
            if (rg_SlabGrid.Items.Count == 0)
            {
                BLL.ShowMessage(this, "Please Add Slabs For Scale");
                return;
            }
            RadNumericTextBox rtxt_SlabAmountGrid = new RadNumericTextBox();
            DataTable dtGRADESLABS = new DataTable();
            dtGRADESLABS.Columns.Add("EMPLOYEEGRADE_SLAB_ID", typeof(int));
            dtGRADESLABS.Columns.Add("EMPLOYEEGRADE_SLAB_SRNO", typeof(int));
            dtGRADESLABS.Columns.Add("EMPLOYEEGRADE_EMPLOYEEGRADE_SLAB_AMOUNT", typeof(float));
            dtGRADESLABS.Columns.Add("CURRENTPERIODID", typeof(int));

            for (int index = 0; index <= rg_SlabGrid.Items.Count - 1; index++)
            {
                rtxt_SlabAmountGrid = rg_SlabGrid.Items[index].FindControl("rtxt_SlabAmountGrid") as RadNumericTextBox;
                int EMPLOYEEGRADE_SLAB_SRNO = Convert.ToInt32(rg_SlabGrid.Items[index]["EMPLOYEEGRADE_SLAB_SRNO"].Text);
                if (rg_SlabGrid.Items[index]["EMPLOYEEGRADE_SLAB_ID"].Text == "&nbsp;")
                    dtGRADESLABS.Rows.Add(null, EMPLOYEEGRADE_SLAB_SRNO, rtxt_SlabAmountGrid.Text, rg_SlabGrid.Items[index]["CURRENTPERIODID"].Text);
                else
                    dtGRADESLABS.Rows.Add(rg_SlabGrid.Items[index]["EMPLOYEEGRADE_SLAB_ID"].Text, EMPLOYEEGRADE_SLAB_SRNO, rtxt_SlabAmountGrid.Text, rg_SlabGrid.Items[index]["CURRENTPERIODID"].Text);
            }
            SMHR_EMPLOYEEGRADE_SLAB _obj_Smhr_EmployeeGrade_Slabs = new SMHR_EMPLOYEEGRADE_SLAB();

            /*
            _obj_Smhr_EmployeeGrade_Slabs.OPERATION = operation.Insert;
            _obj_Smhr_EmployeeGrade_Slabs.EMPLOYEEGRADE_SLAB_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_EmployeeGrade_Slabs.EMPLOYEEGRADE_SLAB_EMPLOYEEGRADE_CODE = rtxt_EmployeeGradeCode.Text;
            _obj_Smhr_EmployeeGrade_Slabs.EMPLOYEEGRADE_SLAB_PERIOD_ID = Convert.ToInt32(rcb_ScalesSlabFromPeriod.SelectedValue);
            _obj_Smhr_EmployeeGrade_Slabs.EMPLOYEEGRADE_SLAB_ISFINALIZED = false;
            _obj_Smhr_EmployeeGrade_Slabs.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_EmployeeGrade_Slabs.CREATEDDATE = DateTime.Now;
            _obj_Smhr_EmployeeGrade_Slabs.GRADESLABS = dtGRADESLABS;

            if (BLL.Set_EMPLOYEEGRADE_SLABS(_obj_Smhr_EmployeeGrade_Slabs))
            {
                if (sender != null)
                    BLL.ShowMessage(this, "Slabs Saved Successfully");
            }
            else
            {
                if (sender != null)
                    BLL.ShowMessage(this, "Slabs Not Saved");
            }
            */

            int grdCnt = 0;

            if (dtGRADESLABS.Rows.Count > 0)
            {
                for (int i = 0; i < dtGRADESLABS.Rows.Count; i++)
                {
                    _obj_Smhr_EmployeeGrade_Slabs.OPERATION = operation.Insert1;
                    _obj_Smhr_EmployeeGrade_Slabs.EMPLOYEEGRADE_SLAB_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Smhr_EmployeeGrade_Slabs.EMPLOYEEGRADE_SLAB_EMPLOYEEGRADE_CODE = rtxt_EmployeeGradeCode.Text;
                    _obj_Smhr_EmployeeGrade_Slabs.EMPLOYEEGRADE_SLAB_SRNO = Convert.ToInt32(dtGRADESLABS.Rows[i]["EMPLOYEEGRADE_SLAB_SRNO"]);
                    _obj_Smhr_EmployeeGrade_Slabs.EMPLOYEEGRADE_SLAB_PERIOD_ID = Convert.ToInt32(rcb_ScalesSlabFromPeriod.SelectedValue);
                    _obj_Smhr_EmployeeGrade_Slabs.EMPLOYEEGRADE_SLAB_ISFINALIZED = false;
                    _obj_Smhr_EmployeeGrade_Slabs.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                    _obj_Smhr_EmployeeGrade_Slabs.EMPLOYEEGRADE_SLAB_AMOUNT = Convert.ToDouble(dtGRADESLABS.Rows[i]["EMPLOYEEGRADE_EMPLOYEEGRADE_SLAB_AMOUNT"]);

                    grdCnt++;
                    BLL.Set_EMPLOYEEGRADE_SLABS(_obj_Smhr_EmployeeGrade_Slabs);
                }
            }

            if (dtGRADESLABS.Rows.Count == grdCnt)
                BLL.ShowMessage(this, "Slabs saved successfully");
            else
                BLL.ShowMessage(this, "Slabs not saved/partially saved");

            //if (sender != null)
            //{
            //    //Rm_CY_page.SelectedIndex = 0;
            //    //LoadGrid();
            //    //Rg_EmployeeGrade.DataBind();
            //}
            //else
            //{
            SMHR_EMPLOYEEGRADE _obj_Smhr_EmployeeGrade = new SMHR_EMPLOYEEGRADE();
            if (Convert.ToString(ViewState["EmployeeGrade_ID"]) != string.Empty)
                _obj_Smhr_EmployeeGrade.EMPLOYEEGRADE_ID = Convert.ToInt32(Convert.ToString(ViewState["EmployeeGrade_ID"]));
            else
            {
                _obj_Smhr_EmployeeGrade.OPERATION = operation.Employeegrades;
                _obj_Smhr_EmployeeGrade.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

                DataTable dtEmpGradeNew = BLL.GetEmployeeGrade(_obj_Smhr_EmployeeGrade);

                if (dtEmpGradeNew.Rows.Count > 0)
                    _obj_Smhr_EmployeeGrade.EMPLOYEEGRADE_ID = Convert.ToInt32(dtEmpGradeNew.Rows[0]["EMPLOYEEGRADE_ID"]);
            }
            _obj_Smhr_EmployeeGrade.EMPLOYEEGRADE_CODE = rtxt_EmployeeGradeCode.Text.Trim();
            _obj_Smhr_EmployeeGrade.PERIOD_ID = Convert.ToInt32(rcb_ScalesSlabFromPeriod.SelectedValue);
            _obj_Smhr_EmployeeGrade.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_EmployeeGrade.OPERATION = operation.GETGRADE;
            DataSet ds = BLL.get_EmployeeGrade(_obj_Smhr_EmployeeGrade);





            rg_SlabGrid.DataSource = ds;
            rg_SlabGrid.DataBind();
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeGrade", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_FinalizeSlabs_Click(object sender, EventArgs e)
    {
        try
        {
            if (rg_SlabGrid.Items.Count == 0)
            {
                BLL.ShowMessage(this, "Please Add Slabs For Scale");
                return;
            }

            btn_SaveSlabs_Click(null, null);

            RadNumericTextBox rtxt_SlabAmountGrid = new RadNumericTextBox();
            DataTable dtGRADESLABS = new DataTable();
            dtGRADESLABS.Columns.Add("EMPLOYEEGRADE_SLAB_ID", typeof(int));
            dtGRADESLABS.Columns.Add("EMPLOYEEGRADE_SLAB_SRNO", typeof(int));
            dtGRADESLABS.Columns.Add("EMPLOYEEGRADE_EMPLOYEEGRADE_SLAB_AMOUNT", typeof(float));
            dtGRADESLABS.Columns.Add("CURRENTPERIODID", typeof(int));

            for (int index = 0; index <= rg_SlabGrid.Items.Count - 1; index++)
            {
                rtxt_SlabAmountGrid = rg_SlabGrid.Items[index].FindControl("rtxt_SlabAmountGrid") as RadNumericTextBox;
                int EMPLOYEEGRADE_SLAB_SRNO = rg_SlabGrid.Items[index]["EMPLOYEEGRADE_SLAB_SRNO"].Text != "&nbsp;" ? Convert.ToInt32(rg_SlabGrid.Items[index]["EMPLOYEEGRADE_SLAB_SRNO"].Text) : 0;
                int EMPLOYEEGRADE_SLAB_ID = rg_SlabGrid.Items[index]["EMPLOYEEGRADE_SLAB_ID"].Text != "&nbsp;" ? Convert.ToInt32(rg_SlabGrid.Items[index]["EMPLOYEEGRADE_SLAB_ID"].Text) : 0;

                //if (EMPLOYEEGRADE_SLAB_ID == 0)
                //{
                //    BLL.ShowMessage(this, "Please Save Slabs Before Finalize");
                //    return;
                //}

                dtGRADESLABS.Rows.Add(EMPLOYEEGRADE_SLAB_ID, EMPLOYEEGRADE_SLAB_SRNO, rtxt_SlabAmountGrid.Text, rg_SlabGrid.Items[index]["CURRENTPERIODID"].Text);
            }
            SMHR_EMPLOYEEGRADE_SLAB _obj_Smhr_EmployeeGrade_Slabs = new SMHR_EMPLOYEEGRADE_SLAB();
            _obj_Smhr_EmployeeGrade_Slabs.OPERATION = operation.Finalized;
            _obj_Smhr_EmployeeGrade_Slabs.EMPLOYEEGRADE_SLAB_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_EmployeeGrade_Slabs.EMPLOYEEGRADE_SLAB_EMPLOYEEGRADE_CODE = rtxt_EmployeeGradeCode.Text;
            _obj_Smhr_EmployeeGrade_Slabs.EMPLOYEEGRADE_SLAB_EMPLOYEEGRADE_ID = Convert.ToInt32(ViewState["EmployeeGrade_ID"]);
            _obj_Smhr_EmployeeGrade_Slabs.EMPLOYEEGRADE_SLAB_PERIOD_ID = Convert.ToInt32(rcb_ScalesSlabFromPeriod.SelectedValue);

            _obj_Smhr_EmployeeGrade_Slabs.EMPLOYEEGRADE_SLAB_ISFINALIZED = true;
            _obj_Smhr_EmployeeGrade_Slabs.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_EmployeeGrade_Slabs.CREATEDDATE = DateTime.Now;
            _obj_Smhr_EmployeeGrade_Slabs.GRADESLABS = dtGRADESLABS;

            if (BLL.Set_EMPLOYEEGRADE_SLABS(_obj_Smhr_EmployeeGrade_Slabs))
                BLL.ShowMessage(this, "Slabs Finalized Successfully");
            else
                BLL.ShowMessage(this, "Slabs Finalized Failed");

            ViewState["EmployeeGrade_ID"] = null;
            ViewState["CURRENTPERIODID"] = null;

            Rm_CY_page.SelectedIndex = 0;
            LoadGrid();
            Rg_EmployeeGrade.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeGrade", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    //protected void lnkDelete_Click(object sender, CommandEventArgs e)
    //{
    //    try
    //    {
    //        SMHR_EMPLOYEEGRADE_SLAB slabs = new SMHR_EMPLOYEEGRADE_SLAB();
    //        slabs.OPERATION = operation.Delete;
    //        slabs.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //        slabs.EMPLOYEEGRADE_SLAB_ID = Convert.ToInt32(e.CommandArgument);
    //        DataSet ds = BLL.get_EmployeeGrade(_obj_Smhr_EmployeeGrade);
    //        DataTable dtTemp = ViewState["dtGridData"] as DataTable;
    //        LinkButton lnkTemp = sender as LinkButton;
    //        GridDataItem item = lnkTemp.NamingContainer as GridDataItem;

    //        for (int i = 0; i < dtTemp.Rows.Count; i++)
    //        {
    //            if (dtTemp.Rows[i]["EMPLOYEEGRADE_SLAB_SRNO"].ToString() == item["EMPLOYEEGRADE_SLAB_SRNO"].Text)
    //            {
    //                dtTemp.Rows[i].Delete();
    //            }
    //        }

    //        //DataTable dt = new DataTable();
    //        //DataColumn c = new DataColumn("EMPLOYEEGRADE_SLAB_SRNO", typeof(int));

    //        //c.AutoIncrement = true;
    //        //c.AutoIncrementSeed = 1;
    //        //c.AutoIncrementStep = 1;
    //        ////dt.Columns.Add("EMPLOYEEGRADE_SLAB_SRNO");
    //        //dt.Columns.Add("EMPLOYEEGRADE_SLAB_ID");
    //        //dt.Columns.Add("EMPLOYEEGRADE_SLAB_AMOUNT", typeof(double));
    //        //dt.Columns.Add("CURRENTPERIODID", typeof(int));
    //        //dt.Columns.Add(c);

    //        //foreach (DataRow dr in dtTemp.Rows)
    //        //{
    //        //    //dt.NewRow();dt.ImportRow(dr);
    //        //    dt.Rows.Add(dr["EMPLOYEEGRADE_SLAB_ID"].ToString(), dr["EMPLOYEEGRADE_SLAB_SRNO"].ToString(), dr["EMPLOYEEGRADE_SLAB_AMOUNT"].ToString(), dr["CURRENTPERIODID"].ToString());
    //        //}

    //        ViewState["dtGridData"] = dtTemp;
    //        rg_SlabGrid.DataSource = dtTemp;
    //        rg_SlabGrid.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeGrade", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}
    protected void rg_SlabGrid_ItemDataBound(object sender, GridItemEventArgs e)
    {
        try
        {
            GridDataItem item = e.Item as GridDataItem;
            if (e.Item is GridDataItem)
            {
                if (item["EMPLOYEEGRADE_SLAB_ID"].Text == "&nbsp;")
                {
                    //(item.FindControl("rtxt_SlabAmountGrid") as RadNumericTextBox).Enabled = false;
                    (item.FindControl("lnkDelete") as LinkButton).Enabled = true;
                }
                else
                {
                    //(item.FindControl("rtxt_SlabAmountGrid") as RadNumericTextBox).Enabled = true;
                    (item.FindControl("lnkDelete") as LinkButton).Enabled = false;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeGrade", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Copy_Command(object sender, CommandEventArgs e)
    {
        try
        {
            clearControls();
            string[] strSlabGradeIDPeriodID = e.CommandArgument.ToString().Split(',');
            ViewState["strSlabGradeIDPeriodID"] = strSlabGradeIDPeriodID;
            LoadFinancialPeriodCombos();
            Rm_CY_page.SelectedIndex = 2;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeGrade", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadFinancialPeriodCombos()
    {
        try
        {
            DataTable dtData = BLL.get_SlabPeriods(new SMHR_PERIOD { ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]), PERIOD_ID = 0 });

            rcb_FromFinYear.DataSource = dtData;
            rcb_FromFinYear.DataBind();
            rcb_FromFinYear.Items.Insert(0, new RadComboBoxItem { Text = "Select", Value = "0" });
            //string[] strSlabGradeIDPeriodID = ViewState["strSlabGradeIDPeriodID"] as string[];
            // rcb_FromFinYear.SelectedValue = Convert.ToString(strSlabGradeIDPeriodID[1]) != string.Empty ? strSlabGradeIDPeriodID[1].ToString() : "0";

            //rcb_ToFinYear.DataSource = dtData;
            //rcb_ToFinYear.DataBind();
            //rcb_ToFinYear.Items.Insert(0, new RadComboBoxItem { Text = "Select", Value = "0" });
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeGrade", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_CopySlabCancel_Click(object sender, EventArgs e)
    {
        try
        {
            Rm_CY_page.SelectedIndex = 0;
            tbl_CopySlabTable.Visible = false;
            rg_CopySlabGrid.DataSource = LoadSlabData();
            ViewState["strSlabGradeIDPeriodID"] = null;
            ViewState["dtCopyGridData"] = null;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeGrade", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btnCopySaveSlabs_Click(object sender, EventArgs e)
    {
        try
        {
            if (rg_CopySlabGrid.Items.Count == 0)
            {
                BLL.ShowMessage(this, "Please Add Slabs For Scale");
                return;
            }
            RadNumericTextBox rtxt_SlabAmountGrid = new RadNumericTextBox();
            DataTable dtGRADESLABS = new DataTable();
            dtGRADESLABS.Columns.Add("EMPLOYEEGRADE_SLAB_ID", typeof(int));
            dtGRADESLABS.Columns.Add("EMPLOYEEGRADE_SLAB_SRNO", typeof(int));
            dtGRADESLABS.Columns.Add("EMPLOYEEGRADE_EMPLOYEEGRADE_SLAB_AMOUNT", typeof(float));
            dtGRADESLABS.Columns.Add("CURRENTPERIODID", typeof(int));

            for (int index = 0; index <= rg_CopySlabGrid.Items.Count - 1; index++)
            {
                rtxt_SlabAmountGrid = rg_CopySlabGrid.Items[index].FindControl("rtxt_SlabAmountGrid") as RadNumericTextBox;
                int EMPLOYEEGRADE_SLAB_SRNO = Convert.ToInt32(rg_CopySlabGrid.Items[index]["EMPLOYEEGRADE_SLAB_SRNO"].Text);
                if (rg_CopySlabGrid.Items[index]["EMPLOYEEGRADE_SLAB_ID"].Text == "&nbsp;")
                    dtGRADESLABS.Rows.Add(null, EMPLOYEEGRADE_SLAB_SRNO, rtxt_SlabAmountGrid.Text, rcb_ToFinYear.SelectedValue);
                else
                    dtGRADESLABS.Rows.Add(rg_CopySlabGrid.Items[index]["EMPLOYEEGRADE_SLAB_ID"].Text, EMPLOYEEGRADE_SLAB_SRNO, rtxt_SlabAmountGrid.Text, rcb_ToFinYear.SelectedValue);
            }
            string[] strSlabGradeIDPeriodID = ViewState["strSlabGradeIDPeriodID"] as string[];
            SMHR_EMPLOYEEGRADE_SLAB _obj_Smhr_EmployeeGrade_Slabs = new SMHR_EMPLOYEEGRADE_SLAB();


            for (int i = 0; i < dtGRADESLABS.Rows.Count; i++)
            {
                _obj_Smhr_EmployeeGrade_Slabs.OPERATION = operation.CHECKEXISTS;
                _obj_Smhr_EmployeeGrade_Slabs.EMPLOYEEGRADE_SLAB_ID = Convert.ToInt32(dtGRADESLABS.Rows[i]["EMPLOYEEGRADE_SLAB_ID"]);
                _obj_Smhr_EmployeeGrade_Slabs.EMPLOYEEGRADE_SLAB_SRNO = Convert.ToInt32(dtGRADESLABS.Rows[i]["EMPLOYEEGRADE_SLAB_SRNO"]);
                _obj_Smhr_EmployeeGrade_Slabs.EMPLOYEEGRADE_SLAB_PERIOD_ID = Convert.ToInt32(rcb_ToFinYear.SelectedValue);
                _obj_Smhr_EmployeeGrade_Slabs.EMPLOYEEGRADE_SLAB_AMOUNT = Convert.ToDouble(dtGRADESLABS.Rows[i]["EMPLOYEEGRADE_EMPLOYEEGRADE_SLAB_AMOUNT"]);
                BLL.Set_EMPLOYEEGRADE_SLABS(_obj_Smhr_EmployeeGrade_Slabs);
            }


            _obj_Smhr_EmployeeGrade_Slabs.EMPLOYEEGRADE_SLAB_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_EmployeeGrade_Slabs.EMPLOYEEGRADE_SLAB_EMPLOYEEGRADE_ID = Convert.ToInt32(strSlabGradeIDPeriodID[0] != string.Empty ? strSlabGradeIDPeriodID[0].ToString() : "0");
            _obj_Smhr_EmployeeGrade_Slabs.EMPLOYEEGRADE_SLAB_PERIOD_ID = Convert.ToInt32(rcb_ToFinYear.SelectedValue);
            _obj_Smhr_EmployeeGrade_Slabs.EMPLOYEEGRADE_SLAB_ISFINALIZED = false;
            _obj_Smhr_EmployeeGrade_Slabs.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_EmployeeGrade_Slabs.CREATEDDATE = DateTime.Now;
           //  _obj_Smhr_EmployeeGrade_Slabs.GRADESLABS = dtGRADESLABS;



           


            _obj_Smhr_EmployeeGrade_Slabs.OPERATION = operation.CHECKDUPLICATE;
            if (BLL.Set_EMPLOYEEGRADE_SLABS(_obj_Smhr_EmployeeGrade_Slabs))
            {
                //if (sender != null)
                //{
                //    BLL.ShowMessage(this, "Slabs Already Exists For Selected To Period");
                return;
                //}
            }

            _obj_Smhr_EmployeeGrade_Slabs.OPERATION = operation.CopySlabs;
            if (BLL.Set_EMPLOYEEGRADE_SLABS(_obj_Smhr_EmployeeGrade_Slabs))
            {
                if (sender != null)
                    BLL.ShowMessage(this, "Slabs Copied Successfully");
            }
            else
            {
                if (sender != null)
                    BLL.ShowMessage(this, "Slabs Not Saved");
            }

            SMHR_EMPLOYEEGRADE _obj_Smhr_EmployeeGrade = new SMHR_EMPLOYEEGRADE();
            _obj_Smhr_EmployeeGrade.EMPLOYEEGRADE_ID = Convert.ToInt32(strSlabGradeIDPeriodID[0] != string.Empty ? strSlabGradeIDPeriodID[0].ToString() : "0");
            _obj_Smhr_EmployeeGrade.PERIOD_ID = Convert.ToInt32(rcb_ToFinYear.SelectedValue);
            _obj_Smhr_EmployeeGrade.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataSet ds = BLL.get_EmployeeGrade(_obj_Smhr_EmployeeGrade);

            rg_CopySlabGrid.DataSource = ds.Tables[1];
            rg_CopySlabGrid.DataBind();

            //Rm_CY_page.SelectedIndex = 0;
            //LoadGrid();
            //Rg_EmployeeGrade.DataBind();

            //if (sender != null)
            //    ViewState["strSlabGradeIDPeriodID"] = null;

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeGrade", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void btnCopyFinalizeSlabs_Click(object sender, EventArgs e)
    {
        try
        {
            //if (rg_CopySlabGrid.Items.Count == 0)
            //{
            //    BLL.ShowMessage(this, "Please Add Slabs For Scale");
            //    return;
            //}
            btnCopySaveSlabs_Click(null, null);
            RadNumericTextBox rtxt_SlabAmountGrid = new RadNumericTextBox();
            DataTable dtGRADESLABS = new DataTable();
            dtGRADESLABS.Columns.Add("EMPLOYEEGRADE_SLAB_ID", typeof(int));
            dtGRADESLABS.Columns.Add("EMPLOYEEGRADE_SLAB_SRNO", typeof(int));
            dtGRADESLABS.Columns.Add("EMPLOYEEGRADE_EMPLOYEEGRADE_SLAB_AMOUNT", typeof(float));
            dtGRADESLABS.Columns.Add("CURRENTPERIODID", typeof(int));

            for (int index = 0; index <= rg_CopySlabGrid.Items.Count - 1; index++)
            {
                rtxt_SlabAmountGrid = rg_CopySlabGrid.Items[index].FindControl("rtxt_SlabAmountGrid") as RadNumericTextBox;
                int EMPLOYEEGRADE_SLAB_SRNO = rg_CopySlabGrid.Items[index]["EMPLOYEEGRADE_SLAB_SRNO"].Text != "&nbsp;" ? Convert.ToInt32(rg_CopySlabGrid.Items[index]["EMPLOYEEGRADE_SLAB_SRNO"].Text) : 0;
                int EMPLOYEEGRADE_SLAB_ID = rg_CopySlabGrid.Items[index]["EMPLOYEEGRADE_SLAB_ID"].Text != "&nbsp;" ? Convert.ToInt32(rg_CopySlabGrid.Items[index]["EMPLOYEEGRADE_SLAB_ID"].Text) : 0;

                //if (EMPLOYEEGRADE_SLAB_ID == 0)
                //{
                //    BLL.ShowMessage(this, "Please Save Slabs Before Finalize");
                //    return;
                //}

                dtGRADESLABS.Rows.Add(EMPLOYEEGRADE_SLAB_ID, EMPLOYEEGRADE_SLAB_SRNO, rtxt_SlabAmountGrid.Text, rg_CopySlabGrid.Items[index]["CURRENTPERIODID"].Text);
            }
            string[] strSlabGradeIDPeriodID = ViewState["strSlabGradeIDPeriodID"] as string[];
            SMHR_EMPLOYEEGRADE_SLAB _obj_Smhr_EmployeeGrade_Slabs = new SMHR_EMPLOYEEGRADE_SLAB();
            _obj_Smhr_EmployeeGrade_Slabs.OPERATION = operation.Finalized;
            _obj_Smhr_EmployeeGrade_Slabs.EMPLOYEEGRADE_SLAB_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_EmployeeGrade_Slabs.EMPLOYEEGRADE_SLAB_EMPLOYEEGRADE_CODE = rtxt_EmployeeGradeCode.Text;
            _obj_Smhr_EmployeeGrade_Slabs.EMPLOYEEGRADE_SLAB_EMPLOYEEGRADE_ID = Convert.ToInt32(strSlabGradeIDPeriodID[0] != string.Empty ? strSlabGradeIDPeriodID[0].ToString() : "0");
            _obj_Smhr_EmployeeGrade_Slabs.EMPLOYEEGRADE_SLAB_PERIOD_ID = Convert.ToInt32(rcb_ToFinYear.SelectedValue);

            _obj_Smhr_EmployeeGrade_Slabs.EMPLOYEEGRADE_SLAB_ISFINALIZED = true;
            _obj_Smhr_EmployeeGrade_Slabs.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_EmployeeGrade_Slabs.CREATEDDATE = DateTime.Now;
            _obj_Smhr_EmployeeGrade_Slabs.GRADESLABS = dtGRADESLABS;

            if (BLL.Set_EMPLOYEEGRADE_SLABS(_obj_Smhr_EmployeeGrade_Slabs))
                BLL.ShowMessage(this, "Slabs Finalized Successfully");
            else
                BLL.ShowMessage(this, "Slabs Finalized Failed");


            Rm_CY_page.SelectedIndex = 0;
            LoadGrid();
            Rg_EmployeeGrade.DataBind();

            ViewState["strSlabGradeIDPeriodID"] = null;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeGrade", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btnGenerateSlabs_Click(object sender, EventArgs e)
    {
        try
        {
            if (rcb_FromFinYear.SelectedValue == "0" || rcb_ToFinYear.SelectedValue == "0")
            {
                BLL.ShowMessage(this, "Please Select From and To Financial Period");
                return;
            }
            if (rcb_FromFinYear.SelectedValue == rcb_ToFinYear.SelectedValue)
            {
                BLL.ShowMessage(this, "From and To Financial Period Cannot Be Same");
                return;
            }
            tbl_CopySlabTable.Visible = true;

            string[] strSlabGradeIDPeriodID = ViewState["strSlabGradeIDPeriodID"] as string[];

            SMHR_EMPLOYEEGRADE _obj_Smhr_EmployeeGrade = new SMHR_EMPLOYEEGRADE();
            _obj_Smhr_EmployeeGrade.EMPLOYEEGRADE_ID = Convert.ToInt32(strSlabGradeIDPeriodID[0] != string.Empty ? strSlabGradeIDPeriodID[0].ToString() : "0");
            _obj_Smhr_EmployeeGrade.PERIOD_ID = Convert.ToInt32(rcb_FromFinYear.SelectedValue);
            _obj_Smhr_EmployeeGrade.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataSet ds = BLL.get_EmployeeGrade(_obj_Smhr_EmployeeGrade);



            if (ds.Tables[1].Rows.Count > 0)
            {
                if (Convert.ToBoolean(ds.Tables[1].Rows[0]["ISFINALIZED"]) == true)
                {
                    //rg_SlabGrid.Enabled = false;
                    //btn_AddSlabAmount.Enabled = false;
                    //rtxt_SlabAmount.Enabled = false;
                    //btn_SaveSlabs.Enabled = false;
                    //btn_FinalizeSlabs.Enabled = false;
                    lbl_CopySlabMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("#3399ff");
                    lbl_CopySlabMessage.Text = "Finalized Slabs of Financial Year " + "\"" + rcb_FromFinYear.Text + "\"";

                    rg_CopySlabGrid.DataSource = ds.Tables[1];
                    rg_CopySlabGrid.DataBind();
                }
                else
                {
                    lbl_CopySlabMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("#cc0000");
                    lbl_CopySlabMessage.Text = "Slabs Not Finalized for Financial Year " + "\"" + rcb_FromFinYear.Text + "\"";
                    rg_CopySlabGrid.DataSource = LoadSlabData();
                    rg_CopySlabGrid.DataBind();
                }
            }
            else
            {
                lbl_CopySlabMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("#cc0000");
                lbl_CopySlabMessage.Text = "Slabs Not Defined For Financial Year " + "\"" + rcb_FromFinYear.Text + "\"";
                rg_CopySlabGrid.DataSource = LoadSlabData();
                rg_CopySlabGrid.DataBind();

            }

            btnCopySaveSlabs.Visible = true;
            btnCopyFinalizeSlabs.Visible = true;
            btn_CopySlabCancel.Visible = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeGrade", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rg_CopySlabGrid_ItemDataBound(object sender, GridItemEventArgs e)
    {
        try
        {
            GridDataItem item = e.Item as GridDataItem;
            if (e.Item is GridDataItem)
            {
                if (item["EMPLOYEEGRADE_SLAB_ID"].Text == "&nbsp;")
                    (item.FindControl("lnkCopySlabDelete") as LinkButton).Enabled = true;
                else
                    (item.FindControl("lnkCopySlabDelete") as LinkButton).Enabled = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeGrade", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rg_CopySlabGrid_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            rg_CopySlabGrid.DataSource = LoadSlabData();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeGrade", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_CopySlabAdd_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            DataColumn c = new DataColumn("EMPLOYEEGRADE_SLAB_SRNO", typeof(int));
            c.AutoIncrement = true;
            c.AutoIncrementSeed = 1;
            c.AutoIncrementStep = 1;

            dt.Columns.Add("EMPLOYEEGRADE_SLAB_ID");
            dt.Columns.Add("EMPLOYEEGRADE_SLAB_AMOUNT", typeof(double));
            dt.Columns.Add("CURRENTPERIODID", typeof(int));
            dt.Columns.Add(c);

            DataRow dr;
            int SrNo = rg_SlabGrid.MasterTableView.Items.Count;
            foreach (GridDataItem item in rg_CopySlabGrid.MasterTableView.Items)
            {
                RadNumericTextBox rtxt_SlabAmtGrid = item.FindControl("rtxt_SlabAmountGrid") as RadNumericTextBox;
                if (rtxt_CopySlabAmount.Text != rtxt_SlabAmtGrid.Text)
                    dt.Rows.Add(item["EMPLOYEEGRADE_SLAB_ID"].Text.ToString(), rtxt_SlabAmtGrid.Text, rcb_ToFinYear.SelectedValue);
                else
                {
                    BLL.ShowMessage(this, "Slab Amount Already Added");
                    return;
                }
            }

            dt.Rows.Add(null, rtxt_CopySlabAmount.Text.ToString(), rcb_ToFinYear.SelectedValue);

            ViewState["dtCopyGridData"] = dt;
            rg_CopySlabGrid.DataSource = dt;
            rg_CopySlabGrid.DataBind();
            rtxt_CopySlabAmount.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeGrade", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnkCopySlabDelete_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dtTemp = ViewState["dtCopyGridData"] as DataTable;
            LinkButton lnkTemp = sender as LinkButton;
            GridDataItem item = lnkTemp.NamingContainer as GridDataItem;
            for (int i = 0; i < dtTemp.Rows.Count; i++)
            {
                if (dtTemp.Rows[i]["EMPLOYEEGRADE_SLAB_SRNO"].ToString() == item["EMPLOYEEGRADE_SLAB_SRNO"].Text)
                {
                    dtTemp.Rows[i].Delete();
                }
            }


            DataTable dt = new DataTable();
            DataColumn c = new DataColumn("EMPLOYEEGRADE_SLAB_SRNO", typeof(int));
            c.AutoIncrement = true;
            c.AutoIncrementSeed = 1;
            c.AutoIncrementStep = 1;

            dt.Columns.Add("EMPLOYEEGRADE_SLAB_ID");
            dt.Columns.Add("EMPLOYEEGRADE_SLAB_AMOUNT", typeof(double));
            dt.Columns.Add(c);

            foreach (DataRow dr in dtTemp.Rows)
            {
                //dt.NewRow();
                //dt.ImportRow(dr);
                dt.Rows.Add(dr["EMPLOYEEGRADE_SLAB_ID"].ToString(), dr["EMPLOYEEGRADE_SLAB_AMOUNT"].ToString());
            }

            ViewState["dtCopyGridData"] = dt;
            rg_CopySlabGrid.DataSource = dt;
            rg_CopySlabGrid.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeGrade", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcb_ScalesSlabFromPeriod_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (ViewState["EmployeeGrade_ID"] != null)
            {
                SMHR_EMPLOYEEGRADE _obj_Smhr_EmployeeGrade = new SMHR_EMPLOYEEGRADE();
                _obj_Smhr_EmployeeGrade.EMPLOYEEGRADE_ID = Convert.ToInt32(Convert.ToString(ViewState["EmployeeGrade_ID"]));
                _obj_Smhr_EmployeeGrade.EMPLOYEEGRADE_CODE = rtxt_EmployeeGradeCode.Text.Trim();
                _obj_Smhr_EmployeeGrade.PERIOD_ID = Convert.ToInt32(rcb_ScalesSlabFromPeriod.SelectedValue);
                _obj_Smhr_EmployeeGrade.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_EmployeeGrade.OPERATION = operation.GETGRADE;
                DataSet ds = BLL.get_EmployeeGrade(_obj_Smhr_EmployeeGrade);

                rg_SlabGrid.DataSource = ds;
                rg_SlabGrid.DataBind();

                ViewState["dtGridData"] = ds.Tables[0];

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(ds.Tables[0].Rows[0]["ISFINALIZED"]) == true &&
                        Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["UG_Grade"]) != rtxt_EmployeeGradeCode.Text.Trim())
                    {
                        rg_SlabGrid.Enabled = false;
                        btn_AddSlabAmount.Enabled = false;
                        rtxt_SlabAmount.Enabled = false;
                        btn_SaveSlabs.Enabled = false;
                        btn_FinalizeSlabs.Enabled = false;
                        lbl_SlabMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("#cc0000");
                        lbl_SlabMessage.Text = "Finalized Slabs For Financial Year " + "\"" + rcb_ScalesSlabFromPeriod.Text + "\"";
                    }
                    else
                    {
                        if (Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["UG_Grade"]) == rtxt_EmployeeGradeCode.Text.Trim())
                        {
                            Label lblEmpSlabID;
                            Label lblEmpSlabPrdID;
                            RadNumericTextBox rtxt_SlabAmountGrid;
                            LinkButton lnkDelete;

                            for (int i = 0; i < rg_SlabGrid.Items.Count; i++)
                            {
                                lblEmpSlabID = rg_SlabGrid.Items[i].FindControl("lblEmpSlabID") as Label;
                                lblEmpSlabPrdID = rg_SlabGrid.Items[i].FindControl("lblEmpSlabPrdID") as Label;
                                rtxt_SlabAmountGrid = rg_SlabGrid.Items[i].FindControl("rtxt_SlabAmountGrid") as RadNumericTextBox;
                                lnkDelete = rg_SlabGrid.Items[i].FindControl("lnkDelete") as LinkButton;

                                DataTable dtEmpSlbCnt = BLL.GetEmployeeSlabsCount(Convert.ToInt32(lblEmpSlabID.Text), Convert.ToInt32(lblEmpSlabPrdID.Text), Convert.ToInt32(Session["ORG_ID"]));

                                if (Convert.ToInt32(dtEmpSlbCnt.Rows[0]["COUNT"]) == 0)
                                    rtxt_SlabAmountGrid.Enabled = lnkDelete.Enabled = true;
                                else
                                    rtxt_SlabAmountGrid.Enabled = lnkDelete.Enabled = false;
                            }
                        }
                        else
                        {
                            rg_SlabGrid.Enabled = true;
                            btn_AddSlabAmount.Enabled = true;
                            rtxt_SlabAmount.Enabled = true;
                            btn_SaveSlabs.Enabled = true;
                            btn_FinalizeSlabs.Enabled = true;
                            lbl_SlabMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("#3399ff");
                            lbl_SlabMessage.Text = "Slabs Not Finalized For Financial Year " + "\"" + rcb_ScalesSlabFromPeriod.Text + "\"";
                        }
                    }
                }
                else
                {
                    rg_SlabGrid.Enabled = true;
                    btn_AddSlabAmount.Enabled = true;
                    rtxt_SlabAmount.Enabled = true;
                    btn_SaveSlabs.Enabled = true;
                    btn_FinalizeSlabs.Enabled = true;

                    if (rcb_ScalesSlabFromPeriod.SelectedItem.Text != "Select" && rcb_ScalesSlabFromPeriod.SelectedItem.Text != string.Empty)
                    {
                        lbl_SlabMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("#3399ff");
                        lbl_SlabMessage.Text = "Slabs Not Defined For Financial Year " + "\"" + rcb_ScalesSlabFromPeriod.Text + "\"";
                    }
                    else
                    {
                        lbl_SlabMessage.Text = string.Empty;
                    }
                }
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeGrade", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcb_FromFinYear_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rcb_ToFinYear.Items.Clear();
            if (rcb_FromFinYear.SelectedValue != string.Empty)
            {
                DataTable dtData = BLL.get_SlabPeriods(new SMHR_PERIOD { OPERATION = operation.CHECKSLABPERIODS, ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]), PERIOD_ID = 0, FROM_PERIODID = Convert.ToInt32(rcb_FromFinYear.SelectedValue) });

                rcb_ToFinYear.DataSource = dtData;
                rcb_ToFinYear.DataBind();
                rcb_ToFinYear.Items.Insert(0, new RadComboBoxItem { Text = "Select", Value = "0" });
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeGrade", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnkDelete_Command(object sender, CommandEventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();

            if (ViewState["dtGridData"] != null)
                dt = (DataTable)ViewState["dtGridData"];

            string valID = Convert.ToString(e.CommandName);
            SMHR_EMPLOYEEGRADE_SLAB slabs = new SMHR_EMPLOYEEGRADE_SLAB();
            slabs.OPERATION = operation.Delete;
            slabs.EMPLOYEEGRADE_SLAB_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            if (Convert.ToString(e.CommandArgument) != "&nbsp;" && Convert.ToString(e.CommandArgument) != string.Empty)
            {
                slabs.EMPLOYEEGRADE_SLAB_ID = Convert.ToInt32(e.CommandArgument);

                BLL.get_EmployeeGrade_slab(slabs);
                rcb_ScalesSlabFromPeriod_SelectedIndexChanged(null, null);
            }
            else
            {
                foreach (DataRow item in dt.Rows)
                {
                    if (Convert.ToString(item["EMPLOYEEGRADE_SLAB_SRNO"]) == valID)
                    {
                        item.Delete();
                        dt.AcceptChanges();

                        rg_SlabGrid.DataSource = dt;
                        rg_SlabGrid.DataBind();

                        return;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeGrade", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}