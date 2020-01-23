using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Masters_frm_IncidentMaster : System.Web.UI.Page
{
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Incidents Master");
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
                    return;
                }


                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    RG_IncidentMaster.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btnSave.Visible = false;
                    //btn_Update.Visible = false;
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
                LoadGrid();
                RG_IncidentMaster.DataBind();
                RD_dtIncidentDtTime.MaxDate = DateTime.Now;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IncidentMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    private void LoadGrid()
    {
        try
        {
            DataTable dt = new DataTable();
            SMHR_WorkmanCompensation ObjWrkComp = new SMHR_WorkmanCompensation();
            ObjWrkComp.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            ObjWrkComp.OPERATION = operation.Select;
            RG_IncidentMaster.DataSource = BLL.Get_SMHR_INCIDENTS_MASTERS(ObjWrkComp);
            //RG_IncidentMaster.DataBind();
            RG_IncidentMaster.Visible = true;
            RP_GRIDVIEW.Visible = true;

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IncidentMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SMHR_WorkmanCompensation objWrkComp = new SMHR_WorkmanCompensation();

        try
        {

            switch (((Button)sender).ID.ToUpper())
            {
                case "BTNEDIT": //To update data
                    if (RD_dtIncidentDtTime.SelectedDate == null)
                    {
                        BLL.ShowMessage(this, "Please Select Date & Time");
                        return;
                    }
                    objWrkComp.IncidentID = Convert.ToInt32(lblIncidentID.Text);
                    objWrkComp.IncidentName = BLL.ReplaceQuote(RD_txtIncidentName.Text);
                    objWrkComp.IncidentPlace = BLL.ReplaceQuote(RD_txtPlaceOfIncident.Text);
                    objWrkComp.IncidentDatetime = Convert.ToDateTime(RD_dtIncidentDtTime.SelectedDate.Value);
                    objWrkComp.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                    //objWrkComp.BUID = BUFilter1.BusinessUnitID;
                    //objWrkComp.DIRECTORATE_ID = BUFilter1.DirectorateID;
                    //objWrkComp.DEPARTMENT_ID = BUFilter1.DepartmentID;
                    //objWrkComp.SUBDEPARTMENT_ID = 0;

                    //To check if Incident Name already exits
                    objWrkComp.OPERATION = operation.Check;
                    if (BLL.InsertUpdateIncidents(objWrkComp))
                    {
                        BLL.ShowMessage(this, "Incident Name already exits");
                        return;
                    }

                    objWrkComp.OPERATION = operation.Update;
                    if (BLL.InsertUpdateIncidents(objWrkComp))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Updated");

                    rm_MR_Page.SelectedIndex = 0;
                    LoadGrid();
                    RG_IncidentMaster.DataBind();
                    break;

                case "BTNSAVE":     //To save data
                    if (BUFilter1.BusinessUnitID == 0)  //To check if BusinessUnit in BUFilter is selected
                    {
                        BLL.ShowMessage(this, "Please select Business Unit");
                        return;
                    }
                    else if (RD_dtIncidentDtTime.SelectedDate == null)
                    {
                        BLL.ShowMessage(this, "Please Select Date & Time");
                        return;
                    }
                    //SMHR_WorkmanCompensation objWrkComp = new SMHR_WorkmanCompensation();
                    objWrkComp.IncidentName = BLL.ReplaceQuote(RD_txtIncidentName.Text);
                    objWrkComp.IncidentPlace = BLL.ReplaceQuote(RD_txtPlaceOfIncident.Text.Trim());
                    objWrkComp.IncidentDatetime = Convert.ToDateTime(RD_dtIncidentDtTime.SelectedDate.Value);
                    objWrkComp.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                    objWrkComp.BUID = BUFilter1.BusinessUnitID;
                    objWrkComp.DIRECTORATE_ID = BUFilter1.DirectorateID;
                    objWrkComp.DEPARTMENT_ID = BUFilter1.DepartmentID;
                    objWrkComp.SUBDEPARTMENT_ID = 0;    //Add the sub-department

                    //To check if Incident Name already exits
                    objWrkComp.OPERATION = operation.Check;
                    if (BLL.InsertUpdateIncidents(objWrkComp))
                    {
                        BLL.ShowMessage(this, "Incident Name already exits");
                        return;
                    }

                    objWrkComp.OPERATION = operation.Insert;
                    if (BLL.InsertUpdateIncidents(objWrkComp))
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");

                    rm_MR_Page.SelectedIndex = 0;
                    LoadGrid();
                    RG_IncidentMaster.DataBind();
                    break;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IncidentMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            ClearFields();
            EnableDisableControls(true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IncidentMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void RG_IncidentMaster_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IncidentMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_IncidentMasterEdit_Command(object sender, CommandEventArgs e)
    {
        DataTable dt = new DataTable();
        try
        {
            SMHR_WorkmanCompensation objWrkComp = new SMHR_WorkmanCompensation();
            objWrkComp.IncidentID = Convert.ToInt32(e.CommandArgument);
            objWrkComp.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            objWrkComp.OPERATION = operation.Edit;
            dt = BLL.Get_SMHR_INCIDENTS_MASTERS(objWrkComp);

            if (dt.Rows.Count > 0)
            {
                //trIncCode.Visible = true;
                lblIncidentID.Text = Convert.ToString(dt.Rows[0]["INCIDENT_ID"]);
                RD_txtIncidentCode.Text = Convert.ToString(dt.Rows[0]["INCIDENT_CODE"]);
                RD_txtIncidentName.Text = Convert.ToString(dt.Rows[0]["INCIDENT_NAME"]);
                RD_txtPlaceOfIncident.Text = Convert.ToString(dt.Rows[0]["PLACE_OF_INCIDENT"]);
                RD_dtIncidentDtTime.SelectedDate = Convert.ToDateTime(dt.Rows[0]["INCIDENT_DATE"]);
                //BUFilter1.Visible = false;
                //To select BusinessUnit
                if (Convert.ToString(dt.Rows[0]["INCIDENT_BUSINESSUNIT_ID"]) != "")
                {
                    BUFilter1.BusinessUnitID = Convert.ToInt32(dt.Rows[0]["INCIDENT_BUSINESSUNIT_ID"]);
                }
                if (Convert.ToString(dt.Rows[0]["INCIDENT_DIRECTORATE_ID"]) != "")
                {
                    BUFilter1.DirectorateID = Convert.ToInt32(dt.Rows[0]["INCIDENT_DIRECTORATE_ID"]);
                }
                if (Convert.ToString(dt.Rows[0]["INCIDENT_DEPARTMENT_ID"]) != "")
                {
                    BUFilter1.DepartmentID = Convert.ToInt32(dt.Rows[0]["INCIDENT_DEPARTMENT_ID"]);
                }
                EnableDisableControls(false);
            }
            else
            {
                BLL.ShowMessage(this, "No data found");
            }

            btnSave.Visible = false;
            btnEdit.Visible = false;
            ////code for security
            //if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            //{
            //    btnEdit.Visible = false;
            //}
            //else
            //{
            //    btnEdit.Visible = true;
            //}
            rm_MR_Page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IncidentMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void EnableDisableControls(bool flag)
    {
        try
        {
            RD_txtIncidentName.Enabled = flag;
            RD_txtPlaceOfIncident.Enabled = flag;
            RD_dtIncidentDtTime.Enabled = flag;
            BUFilter1.DisableBusinessUnit = flag;
            BUFilter1.DisableDirectorate = flag;
            BUFilter1.DisableDepartment = flag;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IncidentMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Click(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
            ClearFields();
            EnableDisableControls(true);
            btnSave.Visible = true;
            BUFilter1.Visible = true;
            btnEdit.Visible = false;
            rm_MR_Page.SelectedIndex = 1;
            trIncCode.Visible = false;
            //rad_IsActive.Checked = true;
            //rad_IsActive.Enabled = false;
            BUFilter1.ClearControls();
            BUFilter1.BusinessUnitID = 0;
            BUFilter1.DirectorateID = 0;
            BUFilter1.DepartmentID = 0;
            BUFilter1.EmployeeID = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IncidentMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void ClearFields()
    {
        try
        {
            RD_txtIncidentName.Text = String.Empty;
            RD_txtPlaceOfIncident.Text = String.Empty;
            RD_dtIncidentDtTime.Clear();
            btnSave.Visible = false;
            btnEdit.Visible = false;
            rm_MR_Page.SelectedIndex = 0;
            //rad_IsActive.Checked = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IncidentMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

}