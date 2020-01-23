using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Payroll_frm_InsuranceTransferFunds : System.Web.UI.Page
{
    DataTable dt_Details;
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Insurance Transfer Amount");
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
                    RG_transferfunds.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btnSave.Visible = false;
                    btnUpdate.Visible = false;
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
                LoadGrid(); //To populate grid
                //LoadPayItems();
                RG_transferfunds.DataBind();
                
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InsuranceTransferFunds", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadPayItems()
    {

        try
        {
            InsTransferFunds _obj_InsTransferFunds = new InsTransferFunds();
            _obj_InsTransferFunds.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_InsTransferFunds.OPERATION = operation.Get;
            dt_Details = BLL.get_InsTransferFunds(_obj_InsTransferFunds);
            if (dt_Details.Rows.Count > 0)
            {
                rcmb_payitem.DataSource = dt_Details;
                rcmb_payitem.DataValueField = "PAYITEM_ID";
                rcmb_payitem.DataTextField = "PAYITEM_PAYITEMNAME";
                rcmb_payitem.DataBind();
                rcmb_payitem.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            }
            else
            {
                rcmb_payitem.Items.Insert(0, new RadComboBoxItem("Select", "0"));
                rcmb_payitem.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InsuranceTransferFunds", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
          protected void rcmb_payitem_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
          {
              try
              {
                  InsTransferFunds _obj_InsTransferFunds = new InsTransferFunds();
                  _obj_InsTransferFunds.TransferFundsEmpID = Convert.ToInt32(BUFilter1.EmployeeID);
                  _obj_InsTransferFunds.TransferFundsPayItemID = Convert.ToInt32(rcmb_payitem.SelectedValue);
                  _obj_InsTransferFunds.OPERATION = operation.Check;
                  dt_Details = BLL.get_InsTransferFunds(_obj_InsTransferFunds);
                  if (dt_Details.Rows.Count > 0)
                  {
                      rtxt_amounttransfer.Text = Convert.ToString(dt_Details.Rows[0]["TransferFundsAmount"]);
                      rtxt_amounttransfer.Enabled = false;
                      btnSave.Enabled = false;

                  }
                  else
                  {
                      rtxt_amounttransfer.Text = string.Empty;
                      rtxt_amounttransfer.Enabled = true;
                      btnSave.Enabled = true;
                  }
              }
              catch (Exception ex)
              {
                  SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InsuranceTransferFunds", ex.StackTrace, DateTime.Now);
                  Response.Redirect("~/Frm_ErrorPage.aspx");
              }
          }

    protected void lnk_Add_Click(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
            LoadPayItems();
            rcmb_payitem.SelectedIndex = 0;
            rcmb_payitem.Enabled = true;
            btnSave.Visible = true;
            BUFilter1.Visible = true;
            btnUpdate.Visible = false;
            rm_MR_Page.SelectedIndex = 1;
            BUFilter1.ClearControls();

            BUFilter1.BusinessUnitID = 0;
            BUFilter1.DirectorateID = 0;
            BUFilter1.DepartmentID = 0;
            BUFilter1.EmployeeID = 0;
            BUFilter1.DisableBusinessUnit = true;
            BUFilter1.DisableDirectorate = true;
            BUFilter1.DisableDepartment = true;
            BUFilter1.DisableEmployee = true;
            rtxt_amounttransfer.Text = string.Empty;
            rtxt_amounttransfer.Enabled = true;
            rcmb_payitem.SelectedIndex = 0;
          
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InsuranceTransferFunds", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadGrid()
    {
        
        try
        {
            InsTransferFunds _obj_InsTransferFunds = new InsTransferFunds();
            _obj_InsTransferFunds.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_InsTransferFunds.OPERATION = operation.load;
            dt_Details = BLL.get_InsTransferFunds(_obj_InsTransferFunds);
            RG_transferfunds.DataSource = dt_Details;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InsuranceTransferFunds", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void BUFilter1Emp_SelectedIndexChanged(object sender, EventArgs e)
    {
        //To fetch employee details based on the "BUFilter" (User Control) employee selection
        try
        {
            rcmb_payitem.ClearSelection();
            rcmb_payitem.SelectedIndex = 0;
            rtxt_amounttransfer.Text = string.Empty;
            rtxt_amounttransfer.Enabled = true;
            btnSave.Enabled = true; 

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InsuranceTransferFunds", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
       
        InsTransferFunds _obj_InsTransferFunds = new InsTransferFunds();
        try
        {
            switch (((Button)sender).ID.ToUpper())
            {
                case "BTNUPDATE":
                      if (rtxt_amounttransfer.Text==string.Empty)
                     {
                         BLL.ShowMessage(this, "Please enter Amount to Transfer");
                         return;
                     }

                    _obj_InsTransferFunds.TransferFundsAmount = Convert.ToInt32(rtxt_amounttransfer.Value);
                    _obj_InsTransferFunds.TransferFundsPayItemID = Convert.ToInt32(rcmb_payitem.SelectedValue);
                    _obj_InsTransferFunds.TransferFundsModifiedDate = Convert.ToDateTime(DateTime.Now);
                    _obj_InsTransferFunds.TransferFundsModifiedBy = Convert.ToInt32(Session["EMP_ID"]);
                    _obj_InsTransferFunds.TransferFundsID = Convert.ToInt32(ViewState["TransferFundsID"]);

                    
                    _obj_InsTransferFunds.OPERATION = operation.Update;



                    if (BLL.set_InsTransferFunds(_obj_InsTransferFunds))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Updated");

                    rtxt_amounttransfer.Text = string.Empty;
                    rm_MR_Page.SelectedIndex = 0;
                    LoadGrid();
                    RG_transferfunds.DataBind();
                    break;
                   

                   
                    

                case "BTNSAVE":
                    //To validate BusinessUnit
                    //if (BUFilter1.BusinessUnitID <= 0)
                    //{
                    //    BLL.ShowMessage(this, "Please select Business Unit");
                    //    return;
                    //}
                    // if (BUFilter1.EmployeeID <= 0)
                    //{
                    //    BLL.ShowMessage(this, "Please select an Employee");
                    //    return;
                    //}
                     if (rtxt_amounttransfer.Text==string.Empty)
                     {
                         BLL.ShowMessage(this, "Please enter Amount to Transfer");
                         return;
                     }
                    _obj_InsTransferFunds.TransferFundsCreatedBy = Convert.ToInt32(Session["EMP_ID"]);
                    _obj_InsTransferFunds.TransferFundsOrgID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_InsTransferFunds.TransferFundsBUID = Convert.ToInt32(BUFilter1.BusinessUnitID);
                    _obj_InsTransferFunds.TransferFundsAmount = Convert.ToInt32(rtxt_amounttransfer.Value);
                   _obj_InsTransferFunds.TransferFundsPayItemID = Convert.ToInt32(rcmb_payitem.SelectedValue);
                    _obj_InsTransferFunds.TransferFundsCreatedDate = DateTime.Now;
                    _obj_InsTransferFunds.TransferFundsEmpID = Convert.ToInt32(BUFilter1.EmployeeID);

                    _obj_InsTransferFunds.OPERATION = operation.Insert;


                    if (BLL.set_InsTransferFunds(_obj_InsTransferFunds))
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    rtxt_amounttransfer.Text = string.Empty;
                    rm_MR_Page.SelectedIndex = 0;
                    LoadGrid();
                    RG_transferfunds.DataBind();
                    break;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InsuranceTransferFunds", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        
        try
        {
            LoadPayItems(); 
            BUFilter1.Visible = true;
            InsTransferFunds _obj_InsTransferFunds = new InsTransferFunds();
            _obj_InsTransferFunds.TransferFundsID = Convert.ToInt32(e.CommandArgument);
            ViewState["TransferFundsID"] = Convert.ToInt32(e.CommandArgument);
            //_obj_InsTransferFunds.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_InsTransferFunds.OPERATION = operation.Edit;
            dt_Details = BLL.get_InsTransferFunds(_obj_InsTransferFunds);  //FOR


            if (dt_Details.Rows.Count > 0)
            {
               BUFilter1.BusinessUnitID = Convert.ToInt32(dt_Details.Rows[0]["TransferFundsBUID"]);
                BUFilter1.DirectorateID = Convert.ToInt32(dt_Details.Rows[0]["EMP_DIRECTORATE_ID"]);
                BUFilter1.DepartmentID = Convert.ToInt32(dt_Details.Rows[0]["EMP_DEPARTMENT_ID"]);
                BUFilter1.EmployeeID = Convert.ToInt32(dt_Details.Rows[0]["TransferFundsEmpID"]);
    

                rcmb_payitem.SelectedIndex = rcmb_payitem.Items.IndexOf(rcmb_payitem.Items.FindItemByValue(Convert.ToString(dt_Details.Rows[0]["TransferFundsPayItemID"])));
                rtxt_amounttransfer.Text = Convert.ToString(dt_Details.Rows[0]["TransferFundsAmount"]);
                rtxt_amounttransfer.Enabled = true;
                rcmb_payitem.Enabled = false;

                BUFilter1.DisableBusinessUnit = false;
                BUFilter1.DisableDirectorate = false;
                BUFilter1.DisableDepartment = false;
                BUFilter1.DisableEmployee = false;
                BUFilter1.ShowBusinessUnitSpan = false;
                BUFilter1.ShowEmployeeSpan = false;
               
            }
           

            btnSave.Visible = false;
            //code for security
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btnUpdate.Visible = false;
            }
            else
            {
                btnUpdate.Visible = true;
            }
            rm_MR_Page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InsuranceTransferFunds", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void RG_transferfunds_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InsuranceTransferFunds", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            rtxt_amounttransfer.Text = string.Empty;
            rm_MR_Page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InsuranceTransferFunds", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    
}