﻿using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Masters_VoteCodeEntry : System.Web.UI.Page
{
    SMHR_SALARYSTRUCT _obj_smhr_salaryStruct;
    SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems;
    SMHR_BUSINESSUNIT _obj_smhr_businessunit;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Mapping Vote Codes");//TRAINING APPROVAL");
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
                    //RG_TrainingApproval.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_submit.Visible = false;
                    // btn_Update.Visible = false;
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

                LoadBusinessUnit();
                LoadSalStructure();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "VoteCodeEntry", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void LoadBusinessUnit()
    {
        try
        {
            rcmb_BusinessUnit.Items.Clear();
            _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
            _obj_smhr_businessunit.OPERATION = operation.Select;
            _obj_smhr_businessunit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_BUDetails = BLL.get_BusinessUnit(_obj_smhr_businessunit);
            rcmb_BusinessUnit.DataSource = dt_BUDetails;
            rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BusinessUnit.DataBind();
            string control = Convert.ToString(Request.QueryString["Control"]);
            rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select", "0"));

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "VoteCodeEntry", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    private void LoadSalStructure()
    {
        try
        {
            rcmb_SalaryStructure.Items.Clear();
            _obj_smhr_salaryStruct = new SMHR_SALARYSTRUCT();
            _obj_smhr_salaryStruct.ISDELETED = false;
            _obj_smhr_salaryStruct.OPERATION = operation.Select;
            _obj_smhr_salaryStruct.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Details = BLL.get_SalaryHeaderDetails(_obj_smhr_salaryStruct);
            rcmb_SalaryStructure.DataSource = dt_Details;
            rcmb_SalaryStructure.DataTextField = "SALARYSTRUCT_CODE";
            rcmb_SalaryStructure.DataValueField = "SALARYSTRUCT_ID";
            rcmb_SalaryStructure.DataBind();
            string control = Convert.ToString(Request.QueryString["Control"]);
            rcmb_SalaryStructure.Items.Insert(0, new RadComboBoxItem("Select", "0"));



        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "VoteCodeEntry", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void rcmb_SalaryStructure_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {

            if (rcmb_SalaryStructure.SelectedIndex > 0)
            {
                if (rcmb_BusinessUnit.SelectedIndex > 0)
                {
                    RG_VoteCodeEntry.Visible = true;
                    btn_submit.Visible = true;
                    btn_Cancel.Visible = true;
                    SMHR_VOTECODEENTRY votecodeentry = new SMHR_VOTECODEENTRY();
                    votecodeentry.OPERATION = operation.GET;
                    votecodeentry.VOTECODE_BU_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
                    votecodeentry.VOTECODE_SALSTRUCT_ID = Convert.ToInt32(rcmb_SalaryStructure.SelectedValue);
                    votecodeentry.VOTECODE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dt = BLL.Get_VoteCodeEntry(votecodeentry);
                    RG_VoteCodeEntry.DataSource = dt;
                    RG_VoteCodeEntry.DataBind();
                }
                else
                {
                    rcmb_SalaryStructure.SelectedIndex = 0;
                    BLL.ShowMessage(this, "Please Select Business Unit");
                    return;
                }


            }
            else
            {
                RG_VoteCodeEntry.Visible = false;
                RG_VoteCodeEntry.DataSource = null;
                RG_VoteCodeEntry.DataBind();
                btn_submit.Visible = btn_Cancel.Visible = false;
                rcmb_SalaryStructure.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "VoteCodeEntry", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }


    }
    protected void rcmb_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_BusinessUnit.SelectedIndex == 0)
            {
                //   // RG_VoteCodeEntry.Visible = true;
                //    //btn_submit.Visible = true;
                //    //btn_Cancel.Visible = true;
                //    SMHR_VOTECODEENTRY votecodeentry = new SMHR_VOTECODEENTRY();
                //    votecodeentry.OPERATION = operation.GET;
                //    votecodeentry.VOTECODE_BU_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
                //    votecodeentry.VOTECODE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                //    DataTable dt = BLL.Get_VoteCodeEntry(votecodeentry);
                //    RG_VoteCodeEntry.DataSource = dt;
                //    RG_VoteCodeEntry.DataBind();

                //}
                //else
                //{
                RG_VoteCodeEntry.Visible = false;
                RG_VoteCodeEntry.DataSource = null;
                RG_VoteCodeEntry.DataBind();
                btn_submit.Visible = btn_Cancel.Visible = false;
                rcmb_BusinessUnit.SelectedIndex = 0;
                LoadSalStructure();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "VoteCodeEntry", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        try
        {
            if (rcmb_BusinessUnit.SelectedIndex <= 0)
            {
                BLL.ShowMessage(this, "Please Select Business Unit");
                return;
            }
            else if (rcmb_SalaryStructure.SelectedIndex <= 0)
            {
                BLL.ShowMessage(this, "please select Salary structure");
            }
            string errorMsg = string.Empty;
            DataTable dtGetVoteCode = GetVoteCode(out errorMsg);
            if (!string.IsNullOrEmpty(errorMsg))
            {
                BLL.ShowMessage(this, errorMsg);
                return;
            }
            SMHR_VOTECODEENTRY VOTECODE = new SMHR_VOTECODEENTRY();
            VOTECODE.VOTECODE_GRIDDATA = dtGetVoteCode;
            VOTECODE.VOTECODE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            VOTECODE.VOTECODE_BU_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
            VOTECODE.VOTECODE_SALSTRUCT_ID = Convert.ToInt32(rcmb_SalaryStructure.SelectedValue);
            VOTECODE.VOTECODE_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            VOTECODE.VOTECODE_CREATEDDATE = DateTime.Now;
            VOTECODE.VOTECODE_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            VOTECODE.VOTECODE_LASTMDFDATE = DateTime.Now;
            switch (((Button)sender).Text.ToUpper())
            {

                case "SAVE":
                    VOTECODE.OPERATION = operation.Insert;
                    if (BLL.Set_VoteCodeEntry(VOTECODE))
                    {
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    }
                    else

                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                default:
                    break;
            }
            rcmb_SalaryStructure.ClearSelection();
            rcmb_SalaryStructure.Text = string.Empty;
            rcmb_BusinessUnit.ClearSelection();
            rcmb_BusinessUnit.Text = string.Empty;
            RG_VoteCodeEntry.Visible = false;
            btn_submit.Visible = false;
            btn_Cancel.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "VoteCodeEntry", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            RG_VoteCodeEntry.Visible = false;
            btn_submit.Visible = false;
            btn_Cancel.Visible = false;
            rcmb_SalaryStructure.SelectedIndex = -1;
            rcmb_BusinessUnit.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "VoteCodeEntry", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {
        try
        {
            Label lblPtmID;
            RadTextBox txtVoteName;
            RadTextBox txtVoteCode;

            if (rcmb_BusinessUnit.SelectedIndex <= 0)
            {
                BLL.ShowMessage(this, "Please Select Business Unit");
                return;
            }
            else if (rcmb_SalaryStructure.SelectedIndex <= 0)
                BLL.ShowMessage(this, "please select Salary structure");

            string errorMsg = string.Empty;
            DataTable dtGetVoteCode = GetVoteCode(out errorMsg);

            if (!string.IsNullOrEmpty(errorMsg))
            {
                BLL.ShowMessage(this, errorMsg);
                return;
            }

            //for (int i = 0; i < RG_VoteCodeEntry.Items.Count; i++)
            //{
            //    lblPtmID = RG_VoteCodeEntry.Items[i].FindControl("lblPtmID") as Label;
            //    txtVoteName = RG_VoteCodeEntry.Items[i].FindControl("txtVoteName") as RadTextBox;
            //    txtVoteCode = RG_VoteCodeEntry.Items[i].FindControl("txtVoteCode") as RadTextBox;

            //    if ((txtVoteName.Text == string.Empty && txtVoteCode.Text != string.Empty) || (txtVoteName.Text != string.Empty && txtVoteCode.Text == string.Empty))
            //    {
            //        if (txtVoteName.Text == string.Empty)
            //        {
            //            BLL.ShowMessage(this, "Kindly enter Account Name for the Pay Item - " + lblPtmID.Text);
            //            txtVoteName.Focus();
            //        }
            //        if (txtVoteCode.Text == string.Empty)
            //        {
            //            BLL.ShowMessage(this, "Kindly enter Account Code for the Pay Item - " + lblPtmID.Text);
            //            txtVoteCode.Focus();
            //        }
            //        return;
            //    }
            //}

            SMHR_VOTECODEENTRY VOTECODE = new SMHR_VOTECODEENTRY();
            
            VOTECODE.VOTECODE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            VOTECODE.VOTECODE_BU_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
            VOTECODE.VOTECODE_SALSTRUCT_ID = Convert.ToInt32(rcmb_SalaryStructure.SelectedValue);
            VOTECODE.VOTECODE_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            VOTECODE.VOTECODE_CREATEDDATE = DateTime.Now;
            VOTECODE.VOTECODE_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            VOTECODE.VOTECODE_LASTMDFDATE = DateTime.Now;
            VOTECODE.OPERATION = operation.Insert1;

            for (int i = 0; i < RG_VoteCodeEntry.Items.Count; i++)
            {
                lblPtmID = RG_VoteCodeEntry.Items[i].FindControl("lblPtmID") as Label;
                txtVoteName = RG_VoteCodeEntry.Items[i].FindControl("txtVoteName") as RadTextBox;
                txtVoteCode = RG_VoteCodeEntry.Items[i].FindControl("txtVoteCode") as RadTextBox;

                if (txtVoteName.Text != string.Empty && txtVoteCode.Text != string.Empty && lblPtmID.Text != string.Empty)
                {
                    VOTECODE.VOTECODE_PAYITEM_ID = Convert.ToInt32(lblPtmID.Text);
                    VOTECODE.VOTECODE_NAME = txtVoteName.Text;
                    VOTECODE.VOTECODE_CODE = txtVoteCode.Text;

                    BLL.Set_VoteCodeEntry(VOTECODE);
                }
            }
            
            BLL.ShowMessage(this, "Information Saved Successfully");
           
            rcmb_SalaryStructure.ClearSelection();
            rcmb_SalaryStructure.Text = string.Empty;
            rcmb_BusinessUnit.ClearSelection();
            rcmb_BusinessUnit.Text = string.Empty;
            RG_VoteCodeEntry.Visible = false;
            btn_submit.Visible = false;
            btn_Cancel.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "VoteCodeEntry", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private DataTable GetVoteCode(out string errorMsg)
    {
        errorMsg = string.Empty;
        DataTable dt = GetGridDataTable();
        try
        {
            RadTextBox txtVoteName, txtVoteCode;
            SMHR_VOTECODEENTRY votecodeentry = new SMHR_VOTECODEENTRY();
            votecodeentry.OPERATION = operation.Select;
            votecodeentry.VOTECODE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtVoteCode = BLL.Get_VoteCodeEntry(votecodeentry);
            foreach (GridDataItem d in RG_VoteCodeEntry.Items)
            {

                txtVoteName = new RadTextBox();

                txtVoteName = d.FindControl("txtVoteName") as RadTextBox;

                txtVoteCode = new RadTextBox();
                txtVoteCode = d.FindControl("txtVoteCode") as RadTextBox;
                //if (dtVoteCode.Rows.Count > 0 && !string.IsNullOrEmpty(txtVoteCode.Text))
                //{
                //    //&& v.Field<int>("VOTECODE_BU_ID") == Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value)
                //    DataRow[] dts = dtVoteCode.AsEnumerable().Where(v => v.Field<string>("VOTECODE_CODE") == txtVoteCode.Text && v.Field<int>("VOTECODE_BU_ID") == Convert.ToInt32(rcmb_SalaryStructure.SelectedItem.Value)).ToArray();
                //    if(dts.Count()>0)
                //    { 
                //        foreach(DataRow dr in dts)
                //        {
                //            //if (dr["VOTECODE_PAYITEM_ID"].ToString() != d.Cells[2].Text || dr["VOTECODE_BU_ID"].ToString() != rcmb_BusinessUnit.SelectedItem.Value)
                //            {                                
                //                errorMsg = "Vote Code " + txtVoteCode.Text + " already exists.";
                //                return null;
                //            }
                //        }

                //    }
                //   //DataRow[] dtcurrent = dt.AsEnumerable().Where(v => v.Field<string>("VOTECODE_CODE") == txtVoteCode.Text).ToArray();
                //   //if (dtcurrent.Count() > 0)
                //   //{
                //   //    errorMsg = "Vote Code " + txtVoteCode.Text + " already exists.";
                //   //    return null;
                //   //}
                //}
                dt.Rows.Add(Convert.ToInt32(Session["ORG_ID"]), Convert.ToInt32(rcmb_BusinessUnit.SelectedValue), Convert.ToInt32(rcmb_SalaryStructure.SelectedValue), Convert.ToInt32(d.Cells[2].Text), txtVoteCode.Text, txtVoteName.Text);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "VoteCodeEntry", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return dt;
    }

    private DataTable GetGridDataTable()
    {
        DataTable dt = new DataTable();
        try
        {
            dt.Columns.Add("VOTECODE_ORG_ID", typeof(int));
            dt.Columns.Add("VOTECODE_BU_ID", typeof(int));
            dt.Columns.Add("VOTECODE_SALSTRUCT_ID", typeof(int));
            dt.Columns.Add("VOTECODE_PAYITEM_ID", typeof(int));
            dt.Columns.Add("VOTECODE_CODE", typeof(string));
            dt.Columns.Add("VOTECODE_NAME", typeof(string));

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "VoteCodeEntry", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return dt;
    }
}