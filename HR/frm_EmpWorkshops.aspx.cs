﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using Telerik.Web.UI;
using SPMS;

public partial class HR_frm_EmpWorkshops : System.Web.UI.Page
{
    SMHR_EMPWORKSHOPSATTENDED _obj_smhr_workshops;
    static int Mode = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                //code for security privilage
                Session.Remove("WRITEFACILITY");
                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();
                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Workshops/Seminars Attended");//KEY RESULT AREA");
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
                    RG_EmpWorkshopform.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_SAVE.Visible = false;
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
                clearfields();
                RM_EmpWorkshopform.SelectedIndex = 0;

            }
            Page.Validate();
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpWorkshops", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void clearfields()
    {
        BUFilter1.BusinessUnitID = 0;
        BUFilter1.DirectorateID = 0;
        BUFilter1.DepartmentID = 0;
        BUFilter1.EmployeeID = 0;
        txtbx_Orgby.Text = string.Empty;
        txtbx_Outcome.Text = string.Empty;
        txtbx_SpnsBy.Text = string.Empty;
        txtbx_WrkshpName.Text = string.Empty;
        rdtp_fromdate.SelectedDate = null;
        rdtp_todate.SelectedDate = null;
    }

    protected void RG_EmpWorkshopform_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            _obj_smhr_workshops = new SMHR_EMPWORKSHOPSATTENDED();
            _obj_smhr_workshops.OPERATION = operation.Select;
            _obj_smhr_workshops.EMPWRKSHOPS_ORGID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_workshops.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);

            DataTable dt = BLL.get_workshops(_obj_smhr_workshops);
            if (dt.Rows.Count != 0)
            {
                RG_EmpWorkshopform.DataSource = dt;
            }
            else
            {
                DataTable dt1 = new DataTable();

                RG_EmpWorkshopform.DataSource = dt1;
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpWorkshops", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void validateInputs(out bool result)
    {
        try
        {
            result = true;
            RadComboBox RadBusinessUnit = (RadComboBox)BUFilter1.FindControl("RadBusinessUnit");
            if (!string.IsNullOrEmpty(RadBusinessUnit.SelectedItem.Text) && string.Compare(RadBusinessUnit.SelectedItem.Text, "Select", true) != 0)
            {
                RadComboBox RadEmployee = (RadComboBox)BUFilter1.FindControl("RadEmployee");
                if (!string.IsNullOrEmpty(RadEmployee.SelectedItem.Text) && string.Compare(RadEmployee.SelectedItem.Text, "Select", true) == 0)
                {
                    result = false;
                    BLL.ShowMessage(this, "Please select Employee");
                    return;
                }
            }
            else
            {
                result = false;
                BLL.ShowMessage(this, "Please select Business Unit");
                return;
            }

            if (string.IsNullOrEmpty(txtbx_WrkshpName.Text))
            {
                result = false;
                BLL.ShowMessage(this, "Please enter Workshop Name");
                return;
            }
            if (string.IsNullOrEmpty(txtbx_Orgby.Text))
            {
                result = false;
                BLL.ShowMessage(this, "Please enter Organised By");
                return;
            }
            if (string.IsNullOrEmpty(txtbx_SpnsBy.Text))
            {
                result = false;
                BLL.ShowMessage(this, "Please enter Sponsored By");
                return;
            }
            if (rdtp_fromdate.SelectedDate == null)
            {
                result = false;
                BLL.ShowMessage(this, "Please select From date");
                return;
            }
            if (rdtp_todate.SelectedDate == null)
            {
                result = false;
                BLL.ShowMessage(this, "Please select To date");
                return;
            }
            if (rdtp_todate.SelectedDate <= rdtp_fromdate.SelectedDate)
            {
                result = false;
                BLL.ShowMessage(this, "To date should be greater than or equal to From date");
                return;
            }
            if (string.IsNullOrEmpty(txtbx_Outcome.Text))
            {
                result = false;
                BLL.ShowMessage(this, "Please enter Outcome");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpWorkshops", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            result = false;
        }
    }

    protected void loadgrid()
    {
        try
        {
            _obj_smhr_workshops = new SMHR_EMPWORKSHOPSATTENDED();
            _obj_smhr_workshops.OPERATION = operation.Select;
            _obj_smhr_workshops.EMPWRKSHOPS_ORGID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_workshops.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt = BLL.get_workshops(_obj_smhr_workshops);
            if (dt.Rows.Count != 0)
            {
                RG_EmpWorkshopform.DataSource = dt;
                RG_EmpWorkshopform.DataBind();
            }
            else
            {
                DataTable dt1 = new DataTable();

                RG_EmpWorkshopform.DataSource = dt1;

                RG_EmpWorkshopform.DataBind();
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpWorkshops", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_SAVE_Click1(object sender, EventArgs e)
    {
        try
        {
            //string s = Convert.ToString(txt_description.Text);
            bool result = true;
            validateInputs(out result);
            if (result)
            {
                _obj_smhr_workshops = new SMHR_EMPWORKSHOPSATTENDED();
                _obj_smhr_workshops.OPERATION = operation.Check;
                _obj_smhr_workshops.EMPWRKSHOPS_NAME = Pms_Bll.ReplaceQuote(Convert.ToString(txtbx_WrkshpName.Text.Trim()));
                DataTable dt = BLL.get_workshops(_obj_smhr_workshops);
                if (Convert.ToInt32(dt.Rows[0]["Count"]) != 0)
                {
                    Pms_Bll.ShowMessage(this, "WorkShop Already Exist");
                    return;
                }
                else
                {
                    _obj_smhr_workshops = new SMHR_EMPWORKSHOPSATTENDED();
                    _obj_smhr_workshops.OPERATION = operation.Insert;
                    _obj_smhr_workshops.EMPWRKSHOPS_BUSINESSUNIT = Convert.ToInt32(BUFilter1.BusinessUnitID);
                    _obj_smhr_workshops.EMPWRKSHOPS_DIRECTORATEID = Convert.ToInt32(BUFilter1.DirectorateID);
                    _obj_smhr_workshops.EMPWRKSHOPS_DEPARTMENTID = Convert.ToInt32(BUFilter1.DepartmentID);
                    _obj_smhr_workshops.EMPWRKSHOPS_EMPID = Convert.ToInt32(BUFilter1.EmployeeID);
                    _obj_smhr_workshops.EMPWRKSHOPS_ORGID = Convert.ToInt32(Session["ORG_ID"].ToString());
                    _obj_smhr_workshops.EMPWRKSHOPS_NAME = BLL.ReplaceQuote(Convert.ToString(txtbx_WrkshpName.Text.Trim()));
                    _obj_smhr_workshops.EMPWRKSHOPS_ORGBY = BLL.ReplaceQuote(Convert.ToString(txtbx_Orgby.Text));
                    _obj_smhr_workshops.EMPWRKSHOPS_SPNOSDBY = BLL.ReplaceQuote(Convert.ToString(txtbx_SpnsBy.Text));
                    _obj_smhr_workshops.EMPWRKSHOPS_OUTCOME = BLL.ReplaceQuote(Convert.ToString(txtbx_Outcome.Text));
                    _obj_smhr_workshops.EMPWRKSHOPS_FROMDATE = Convert.ToDateTime(rdtp_fromdate.SelectedDate);
                    _obj_smhr_workshops.EMPWRKSHOPS_TODATE = Convert.ToDateTime(rdtp_todate.SelectedDate);
                    if (FUpload.HasFile)
                    {
                        string filename = Convert.ToString(FUpload.FileName.Trim().Replace("'", "''"));
                        if (!string.IsNullOrEmpty(filename))
                        {
                            FUpload.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/EmpUploads/DocUploads/"), "WorkShop" + "_" + BUFilter1.EmployeeID + "_" + filename));
                        }
                        _obj_smhr_workshops.EMPWRKSHOPS_PARTCERTDOCNAME = filename;
                        _obj_smhr_workshops.EMPWRKSHOPS_PARTCERTDOCUPLOAD = "~/EmpUploads/DocUploads/" + "WorkShop" + "_" + BUFilter1.EmployeeID + "_" + filename;
                    }
                    _obj_smhr_workshops.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                    _obj_smhr_workshops.LASTMDFDATE = DateTime.Now;
                    _obj_smhr_workshops.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                    _obj_smhr_workshops.CREATEDDATE = DateTime.Now;

                    bool status = BLL.set_workshops(_obj_smhr_workshops);
                    if (status == true)
                    {
                        Pms_Bll.ShowMessage(this, "Workshop Inserted Succesfully");
                        loadgrid();
                        clearfields();
                        RM_EmpWorkshopform.SelectedIndex = 0;
                        return;
                    }
                    else
                    {
                        Pms_Bll.ShowMessage(this, "Unable to Update the record,Execption Occured");
                        return;
                    }
                }
            }

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpWorkshops", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }



    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            RM_EmpWorkshopform.SelectedIndex = 0;
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpWorkshops", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Update_Click(object sender, EventArgs e)
    {
        try
        {
            bool result = true;
            validateInputs(out result);
            if (result)
            {
                _obj_smhr_workshops = new SMHR_EMPWORKSHOPSATTENDED();
                _obj_smhr_workshops.EMPWRKSHOPS_ID = Convert.ToInt32(lbl_id.Text);
                _obj_smhr_workshops.EMPWRKSHOPS_BUSINESSUNIT = Convert.ToInt32(BUFilter1.BusinessUnitID);
                _obj_smhr_workshops.EMPWRKSHOPS_DIRECTORATEID = Convert.ToInt32(BUFilter1.DirectorateID);
                _obj_smhr_workshops.EMPWRKSHOPS_DEPARTMENTID = Convert.ToInt32(BUFilter1.DepartmentID);
                _obj_smhr_workshops.EMPWRKSHOPS_EMPID = Convert.ToInt32(BUFilter1.EmployeeID);
                _obj_smhr_workshops.EMPWRKSHOPS_ORGID = Convert.ToInt32(Session["ORG_ID"].ToString());
                _obj_smhr_workshops.EMPWRKSHOPS_NAME = BLL.ReplaceQuote(Convert.ToString(txtbx_WrkshpName.Text));
                _obj_smhr_workshops.EMPWRKSHOPS_ORGBY = BLL.ReplaceQuote(Convert.ToString(txtbx_Orgby.Text));
                _obj_smhr_workshops.EMPWRKSHOPS_SPNOSDBY = BLL.ReplaceQuote(Convert.ToString(txtbx_SpnsBy.Text));
                _obj_smhr_workshops.EMPWRKSHOPS_OUTCOME = BLL.ReplaceQuote(Convert.ToString(txtbx_Outcome.Text));
                _obj_smhr_workshops.EMPWRKSHOPS_FROMDATE = Convert.ToDateTime(rdtp_fromdate.SelectedDate);
                _obj_smhr_workshops.EMPWRKSHOPS_TODATE = Convert.ToDateTime(rdtp_todate.SelectedDate);
                if (FUpload.HasFile)
                {
                    string filename = Convert.ToString(FUpload.FileName.Trim().Replace("'", "''"));
                    if (!string.IsNullOrEmpty(filename))
                    {
                        FUpload.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/EmpUploads/DocUploads/"), "WorkShop" + "_" + BUFilter1.EmployeeID + "_" + filename));
                    }
                    _obj_smhr_workshops.EMPWRKSHOPS_PARTCERTDOCNAME = filename;
                    _obj_smhr_workshops.EMPWRKSHOPS_PARTCERTDOCUPLOAD = "~/EmpUploads/DocUploads/" + "WorkShop" + "_" + BUFilter1.EmployeeID + "_" + filename;
                }
                _obj_smhr_workshops.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                _obj_smhr_workshops.LASTMDFDATE = DateTime.Now;
                _obj_smhr_workshops.OPERATION = operation.Update;


                bool status = BLL.set_workshops(_obj_smhr_workshops);
                if (status == true)
                {
                    Pms_Bll.ShowMessage(this, "Workshop Updated Succesfully");
                    loadgrid();
                    btn_Update.Visible = true;
                    RM_EmpWorkshopform.SelectedIndex = 0;
                }
                else
                {
                    Pms_Bll.ShowMessage(this, "Unable to Update the record,Execption Occured");
                    return;
                }
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpWorkshops", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            clearfields();
            BUFilter1.DisableBusinessUnit = true;
            BUFilter1.DisableDirectorate = true;
            BUFilter1.DisableDepartment = true;
            BUFilter1.DisableEmployee = true;
            RM_EmpWorkshopform.SelectedIndex = 1;
            btn_SAVE.Visible = true;
            btn_Update.Visible = false;
            txtbx_Orgby.Enabled = true;
            txtbx_SpnsBy.Enabled = true;
            txtbx_Outcome.Enabled = true;
            txtbx_WrkshpName.Enabled = true;
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpWorkshops", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Commnad(object sender, CommandEventArgs e)
    {
        try
        {
            clearfields();

            _obj_smhr_workshops = new SMHR_EMPWORKSHOPSATTENDED();
            _obj_smhr_workshops.OPERATION = operation.Update;
            _obj_smhr_workshops.EMPWRKSHOPS_ID = Convert.ToInt32(e.CommandArgument);

            DataTable DT = BLL.get_workshops(_obj_smhr_workshops);
            if (DT.Rows.Count != 0)
            {
                lbl_id.Text = Convert.ToString(DT.Rows[0]["EMPWRKSHOPS_ID"]);
                BUFilter1.BusinessUnitID = Convert.ToInt32(DT.Rows[0]["EMPWRKSHOPS_BUSINESSUNIT"]);
                BUFilter1.DirectorateID = Convert.ToInt32(DT.Rows[0]["EMPWRKSHOPS_DIRECTORATEID"]);
                BUFilter1.DepartmentID = Convert.ToInt32(DT.Rows[0]["EMPWRKSHOPS_DEPARTMENTID"]);
                BUFilter1.EmployeeID = Convert.ToInt32(DT.Rows[0]["EMPWRKSHOPS_EMPID"]);
                txtbx_WrkshpName.Text = Pms_Bll.ReplaceQuote(Convert.ToString(DT.Rows[0]["EMPWRKSHOPS_NAME"]));
                txtbx_Orgby.Text = Pms_Bll.ReplaceQuote(Convert.ToString(DT.Rows[0]["EMPWRKSHOPS_ORGBY"]));
                txtbx_SpnsBy.Text = Pms_Bll.ReplaceQuote(Convert.ToString(DT.Rows[0]["EMPWRKSHOPS_SPNOSDBY"]));
                txtbx_Outcome.Text = Pms_Bll.ReplaceQuote(Convert.ToString(DT.Rows[0]["EMPWRKSHOPS_OUTCOME"]));
                rdtp_fromdate.SelectedDate = Convert.ToDateTime(DT.Rows[0]["EMPWRKSHOPS_FROMDATE"]);
                rdtp_todate.SelectedDate = Convert.ToDateTime(DT.Rows[0]["EMPWRKSHOPS_TODATE"]);
                RM_EmpWorkshopform.SelectedIndex = 1;
                btn_SAVE.Visible = true;
                btn_SAVE.Visible = false;
                btn_Update.Visible = true;
                txtbx_Orgby.Enabled = true;
                txtbx_SpnsBy.Enabled = true;
                txtbx_Outcome.Enabled = true;
                txtbx_WrkshpName.Enabled = true;
                BUFilter1.DisableBusinessUnit = false;
                BUFilter1.DisableDirectorate = false;
                BUFilter1.DisableDepartment = false;
                BUFilter1.DisableEmployee = false;


                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    btn_Update.Visible = false;
                }

                else
                {
                    btn_Update.Visible = true;
                }
            }

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpWorkshops", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //protected void btn_Upload_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (FUpload.HasFile)
    //        {
    //            //if (Check_Combo(FUpload.FileName))
    //            //{
    //               // if (Mode == 1)
    //                //{

    //                    //DataTable dt_Docs = (DataTable)Session["dt_Docs"];
    //                    //DataRow dr = dt_Docs.NewRow();
    //                    string filename = Convert.ToString(FUpload.FileName.Trim().Replace("'", "''"));
    //                    //dr[0] = dt_Docs.Rows.Count + 1;
    //                    //dr[2] = Convert.ToString(FUpload.FileName);
    //                    //dt_Docs.Rows.Add(dr);
    //                    if (!string.IsNullOrEmpty(filename))
    //                    {
    //                        FUpload.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/EmpUploads/DocUploads/"), "WorkShop" + "_" + filename));
    //                        //dr[3] = "~/EmpUploads/DocUploads/" + "WorkShop" + "_" + filename;
    //                    }
    //                    //dt_Docs.DefaultView.Sort = "EMPWRKSHOPS_DOCNAME";
    //                    //dt_Docs = dt_Docs.DefaultView.ToTable();
    //                    //RG_EmpWorkshopform.DataSource = dt_Docs;
    //                    //RG_EmpWorkshopform.DataBind();
    //                    //Session["dt_Docs"] = dt_Docs;
    //                    _obj_smhr_workshops.EMPWRKSHOPS_PARTCERTDOCNAME = filename;
    //                    _obj_smhr_workshops.EMPWRKSHOPS_PARTCERTDOCUPLOAD = "~/EmpUploads/DocUploads/" + "WorkShop" + BUFilter1.EmployeeID + "_" + filename;
    //                //}
    //                //else
    //                //{

    //                    ////_obj_smhr_workshops.EMPDOCS_ASSETDOC_ID = Convert.ToInt32(HF_ID.Value);
    //                    ////_obj_smhr_empAssetDoc.EMPDOCS_NAME = Convert.ToString(FUpload.FileName.Trim().Replace("'", "''"));
    //                    //string filename = Convert.ToString(FUpload.FileName.Trim().Replace("'", "''"));
    //                    //_obj_smhr_workshops.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
    //                    //if (!string.IsNullOrEmpty(filename))
    //                    //{
    //                    //    FUpload.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/EmpUploads/DocUploads/"), ddl_Employee.SelectedItem.Value + "_" + filename));
    //                    //    _obj_smhr_workshops.EMPWRKSHOPS_PARTCERTDOCUPLOAD = "~/EmpUploads/DocUploads/" + ddl_Employee.SelectedValue + "_" + filename;
    //                    //}
    //                    //else
    //                    //{
    //                    //    _obj_smhr_workshops.EMPWRKSHOPS_PARTCERTDOCUPLOAD = string.Empty;
    //                    //}
    //                    //_obj_smhr_workshops.OPERATION = operation.Insert1;
    //                    //if (BLL.set_EmpAssetDoc(_obj_smhr_workshops))
    //                    //{
    //                    //    _obj_smhr_workshops.OPERATION = operation.Get;
    //                    //    //_obj_smhr_workshops.EMPDOCS_ASSETDOC_ID = Convert.ToInt32(HF_ID.Value);
    //                    //    DataTable dt_docs = BLL.get_EmpAssetDoc(_obj_smhr_workshops);
    //                    //    RG_EmpWorkshopform.DataSource = dt_docs;
    //                    //    RG_EmpWorkshopform.DataBind();
    //                    //    Session["dt_Docs"] = dt_docs;
    //                    //}
    //                //}
    //            //}
    //            //else
    //            //{
    //            //    BLL.ShowMessage(this, "Selected file is already Uploaded.");
    //            //    return;
    //            //}
    //        }
    //        else
    //        {
    //            BLL.ShowMessage(this, "Please Browse Document before Upload.");
    //            return;
    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //    }

    //}

    public bool Check_Combo(string filename)
    {
        bool status = true;
        try
        {
            DataTable dt_Docs = Session["dt_Docs"] as DataTable;
            //bool status = true;

            for (int i = 0; i < dt_Docs.Rows.Count; i++)
            {
                if (Convert.ToString(dt_Docs.Rows[i][2]) == Convert.ToString(filename))
                {
                    status = false;
                }
            }
            return status;
            
        }
            
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpWorkshops", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return status;
        }
    }

    public void FileUpload()
    {
        try
        {
            if (FUpload.HasFile)
            {


                DataTable dt_Docs = (DataTable)Session["dt_Docs"];
                DataRow dr = dt_Docs.NewRow();
                string filename = Convert.ToString(FUpload.FileName.Trim().Replace("'", "''"));
                dr[0] = dt_Docs.Rows.Count + 1;
                dr[2] = Convert.ToString(FUpload.FileName);
                dt_Docs.Rows.Add(dr);
                if (!string.IsNullOrEmpty(filename))
                {
                    FUpload.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/EmpUploads/DocUploads/"), "WorkShop" + "_" + BUFilter1.EmployeeID + "_" + filename));
                    dr[3] = "~/EmpUploads/DocUploads/" + "WorkShop" + "_" + BUFilter1.EmployeeID + "_" + filename;
                }
                dt_Docs.DefaultView.Sort = "EMPWRKSHOPS_DOCNAME";
                dt_Docs = dt_Docs.DefaultView.ToTable();
                RG_EmpWorkshopform.DataSource = dt_Docs;
                RG_EmpWorkshopform.DataBind();
                Session["dt_Docs"] = dt_Docs;
                _obj_smhr_workshops.EMPWRKSHOPS_PARTCERTDOCNAME = filename;
                _obj_smhr_workshops.EMPWRKSHOPS_PARTCERTDOCUPLOAD = "~/EmpUploads/DocUploads/" + "WorkShop" + BUFilter1.EmployeeID + "_" + filename;
            }

            else
            {
                BLL.ShowMessage(this, "Please Browse Document before Upload.");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpWorkshops", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


}