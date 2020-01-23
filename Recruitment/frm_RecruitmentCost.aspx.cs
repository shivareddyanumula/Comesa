using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SMHR;
using SmartHR;
using System.Data;
using RECRUITMENT;
using Telerik.Web.UI;
using System.Configuration;
using System.IO;

public partial class Recruitment_frm_RecruitmentCost : System.Web.UI.Page
{
    SMHR_RECRUITMENT_COST _obj_smhr_recruitment_cost = new SMHR_RECRUITMENT_COST();
    RECRUITMENT_JOBREQUISITION _obj_recruitment_jobrequisition = new RECRUITMENT_JOBREQUISITION();
    SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit;
    SMHR_MASTERS _obj_smhr_masters = new SMHR_MASTERS();
    string strPath = "";
    private string MAX_FILE_SIZE = "51200000";

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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Recruitment Cost");//COUNTRY");
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
                    Rg_RecmntCost.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    BTN_SAVE.Visible = false;
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
                LoadRecruitmentCostGrid();
                Rm_HDPT_page.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_RecruitmentCost", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Rg_RecmntCost_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadRecruitmentCostGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_RecruitmentCost", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void LoadJobRequisition()
    {
        try
        {
            _obj_recruitment_jobrequisition = new RECRUITMENT_JOBREQUISITION();
            _obj_recruitment_jobrequisition.MODE = 12;
            _obj_recruitment_jobrequisition.JOBREQ_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_recruitment_jobrequisition.JOBREQ_BUSINESSUNIT_ID = Convert.ToInt32(Rcb_BusinessUnit.SelectedItem.Value);

            DataTable dt = Recruitment_BLL.get_JobRequisition(_obj_recruitment_jobrequisition);
            if (dt.Rows.Count > 0)
            {
                rcmb_RscReq.DataSource = dt;
                rcmb_RscReq.DataValueField = "JOBREQ_ID";
                rcmb_RscReq.DataTextField = "JOBREQ_REQCODE";
                rcmb_RscReq.DataBind();
            }
            rcmb_RscReq.Items.Insert(0, new RadComboBoxItem("Select", "0"));

            //_obj_recruitment_jobrequisition.MODE = 1;
            //_obj_recruitment_jobrequisition.JOBREQ_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            //DataTable dtJobRec = Recruitment_BLL.Get_Job_Requistion_Dropdown(_obj_recruitment_jobrequisition);

            //if (dtJobRec.Rows.Count > 0)
            //{
            //    rcmb_RscReq.DataSource = dtJobRec;
            //    rcmb_RscReq.DataTextField = "JOBREQ_REQCODE";
            //    rcmb_RscReq.DataValueField = "JOBREQ_ID";
            //    rcmb_RscReq.DataBind();
            //}
            //rcmb_RscReq.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_RecruitmentCost", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void LoadTypeCost()
    {
        try
        {
            _obj_smhr_masters.MODE = 3;
            _obj_smhr_masters.MASTER_TYPE = "TYPECOST";
            _obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            DataTable dtTypeCost = BLL.get_MasterRecords(_obj_smhr_masters);

            if (dtTypeCost.Rows.Count > 0)
            {
                rad_TypCost.DataSource = dtTypeCost;
                rad_TypCost.DataTextField = "HR_MASTER_CODE";
                rad_TypCost.DataValueField = "HR_MASTER_ID";
                rad_TypCost.DataBind();
            }
            rad_TypCost.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_RecruitmentCost", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void LoadRecruitmentCostGrid()
    {
        try
        {
            _obj_smhr_recruitment_cost.OPERATION = operation.load;
            _obj_smhr_recruitment_cost.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            Rg_RecmntCost.DataSource = Recruitment_BLL.get_All_SMHR_RECRUITMENT_COST(_obj_smhr_recruitment_cost);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_RecruitmentCost", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            Rcb_BusinessUnit.Enabled = true;
            rcmb_RscReq.Enabled = true;
            rad_TypCost.Enabled = true;
            BTN_SAVE.Visible = true;
            lblMsg.Text = string.Empty;
            ClearControls();

            LoadTypeCost();
            LoadBusinessUnit();
            rcmb_RscReq.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

            Rm_HDPT_page.SelectedIndex = 1;
            btn_Update.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_RecruitmentCost", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void LoadBusinessUnit()
    {
        try
        {
            //_obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
            //_obj_Smhr_BusinessUnit.OPERATION = operation.Select;
            //_obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            SMHR_LOGININFO _obj_LoginInfo = new SMHR_LOGININFO();
            _obj_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            Rcb_BusinessUnit.Items.Clear();
             DataTable dt = BLL.get_Business_Units(_obj_LoginInfo);
            if (dt.Rows.Count != 0)
            {
                Rcb_BusinessUnit.DataSource = dt;
                Rcb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
                Rcb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
                Rcb_BusinessUnit.DataBind();
                Rcb_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            }
            else
            {
                DataTable dt1 = new DataTable();
                Rcb_BusinessUnit.DataSource = dt1;
                Rcb_BusinessUnit.DataBind();
                Rcb_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_RecruitmentCost", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void Rcb_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (Rcb_BusinessUnit.SelectedIndex > 0)
            {
                LoadJobRequisition();
            }
            else
            {
                rcmb_RscReq.ClearSelection();
                rcmb_RscReq.Items.Clear();
                rcmb_RscReq.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_RecruitmentCost", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            BTN_SAVE.Visible = false;
            btn_Update.Visible = true;
            int recCostID = Convert.ToInt32(e.CommandArgument);
            ViewState["COST_ID"] = recCostID;
            //LoadJobRequisition();
            LoadBusinessUnit();
            LoadTypeCost();

            Rcb_BusinessUnit.Enabled = false;
            rcmb_RscReq.Enabled = false;
            rad_TypCost.Enabled = false;

            _obj_smhr_recruitment_cost.COST_ID = recCostID;
            DataTable dt = Recruitment_BLL.get_SMHR_RECRUITMENT_COST(_obj_smhr_recruitment_cost);

            if (dt.Rows.Count > 0)
            {
                Rcb_BusinessUnit.SelectedValue = Convert.ToString(dt.Rows[0]["COST_BU_ID"]);
                LoadJobRequisition();
                rcmb_RscReq.SelectedValue = Convert.ToString(dt.Rows[0]["COST_REQ_ID"]);
                rad_TypCost.SelectedValue = Convert.ToString(dt.Rows[0]["COST_TYPE_ID"]);
                rdtp_Date.SelectedDate = Convert.ToDateTime(dt.Rows[0]["COST_DATE"]);
                rad_Amount.Text = Convert.ToString(dt.Rows[0]["COST_AMOUNT"]);
                if (Convert.ToString(dt.Rows[0]["COST_FILEPATH"]) != string.Empty)
                    lblMsg.Text = Convert.ToString(dt.Rows[0]["COST_FILEPATH"]);
                else
                    lblMsg.Text = string.Empty;
            }
            else
            {
                BLL.ShowMessage(this, "No records to display");
                Rm_HDPT_page.SelectedIndex = 0;
            }
            Rm_HDPT_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_RecruitmentCost", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_RscReq_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        //
    }

    protected void rad_TypCost_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        //
    }

    //protected void btn_Upload_Click(object sender, EventArgs e)
    //{
    //    if (FUpload.HasFile)
    //    {
    //        string fileExt = System.IO.Path.GetExtension(FUpload.FileName);

    //        if (fileExt == ".jpeg" || fileExt == ".jpg" || fileExt == ".png")
    //        {
    //            if (FUpload.HasFile)
    //            {
    //                strPath = "~/Recruitment/RecCostPics/" + FUpload.FileName;
    //                FUpload.PostedFile.SaveAs(Server.MapPath("~/Recruitment/RecCostPics/") + FUpload.FileName); //+ txt_AppLastName.Text 
    //                RBI_BU_Image.ImageUrl = strPath;
    //                RBI_BU_Image.Visible = true;
    //                lblMsg.Visible = true;
    //                lblMsg.Text = Convert.ToString(strPath);
    //            }
    //            else
    //            {
    //                BLL.ShowMessage(this, "Please Upload Image");
    //                return;
    //            }
    //        }
    //        else
    //        {
    //            BLL.ShowMessage(this, "Only .jpeg and .png files are allowed!");
    //        }
    //    }
    //    else
    //    {
    //        BLL.ShowMessage(this, "You have not specified a file");
    //    }
    //} 

    protected void BTN_SAVE_Click(object sender, EventArgs e)
    {
        try
        {
            bool status = false;

            DataTable dtRecCostExists = new DataTable();

            if (lblMsg.Text == string.Empty)
            {
                BLL.ShowMessage(this, "Please Select a File to Upload..");
                return;
            }

            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_SAVE":
                    _obj_smhr_recruitment_cost.OPERATION = operation.Insert;
                    _obj_smhr_recruitment_cost.COST_REQ_ID = Convert.ToInt32(rcmb_RscReq.SelectedValue);
                    _obj_smhr_recruitment_cost.COST_TYPE_ID = Convert.ToInt32(rad_TypCost.SelectedValue);
                    _obj_smhr_recruitment_cost.COST_FILEPATH = Convert.ToString(lblMsg.Text);
                    _obj_smhr_recruitment_cost.COST_AMOUNT = Convert.ToDouble(rad_Amount.Text);
                    _obj_smhr_recruitment_cost.COST_DATE = Convert.ToDateTime(rdtp_Date.SelectedDate);
                    _obj_smhr_recruitment_cost.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_recruitment_cost.CREATEDDATE = DateTime.Now;
                    _obj_smhr_recruitment_cost.BUID = Convert.ToInt32(Rcb_BusinessUnit.SelectedValue);

                    dtRecCostExists = Recruitment_BLL.checkRecCostExists(_obj_smhr_recruitment_cost);

                    if (Convert.ToInt32(dtRecCostExists.Rows[0]["COUNT"]) == 0)
                    {
                        status = Recruitment_BLL.set_SMHR_RECRUITMENT_COST(_obj_smhr_recruitment_cost);

                        if (status == true)
                        {
                            BLL.ShowMessage(this, "Information Successfully Saved");
                        }
                    }
                    else
                    {
                        BLL.ShowMessage(this, "This Record Already Exists");
                        return;
                    }
                    break;

                case "BTN_UPDATE":

                    _obj_smhr_recruitment_cost.OPERATION = operation.Update;
                    _obj_smhr_recruitment_cost.COST_ID = Convert.ToInt32(ViewState["COST_ID"]);
                    _obj_smhr_recruitment_cost.COST_REQ_ID = Convert.ToInt32(rcmb_RscReq.SelectedValue);
                    _obj_smhr_recruitment_cost.COST_TYPE_ID = Convert.ToInt32(rad_TypCost.SelectedValue);
                    _obj_smhr_recruitment_cost.COST_FILEPATH = Convert.ToString(lblMsg.Text);
                    _obj_smhr_recruitment_cost.COST_AMOUNT = Convert.ToDouble(rad_Amount.Text);
                    _obj_smhr_recruitment_cost.COST_DATE = Convert.ToDateTime(rdtp_Date.SelectedDate);
                    _obj_smhr_recruitment_cost.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_recruitment_cost.LASTMDFDATE = DateTime.Now;

                    status = Recruitment_BLL.set_SMHR_RECRUITMENT_COST(_obj_smhr_recruitment_cost);

                    if (status == true)
                    {
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    }

                    break;
            }
            Rm_HDPT_page.SelectedIndex = 0;
            LoadRecruitmentCostGrid();
            Rg_RecmntCost.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_RecruitmentCost", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            Rm_HDPT_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_RecruitmentCost", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void ClearControls()
    {
        try
        {
            rcmb_RscReq.Items.Clear();
            rad_TypCost.Items.Clear();
            rdtp_Date.Clear();
            rad_Amount.Text = string.Empty;
            lblMsg.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_RecruitmentCost", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btnImgUpload_Click(object sender, EventArgs e)
    {
        try
        {
            if (ruImageUpload.UploadedFiles.Count > 0)
            {
                foreach (UploadedFile file in ruImageUpload.UploadedFiles)
                {
                    if (Convert.ToInt32(file.ContentLength) >= Convert.ToInt32(MAX_FILE_SIZE))
                    {
                        BLL.ShowMessage(this, "Selected File Size is: " + file.ContentLength / 1024 + "(KB), Please Select File Size less than 50 MB");
                        return;
                    }

                    file.SaveAs(Server.MapPath("~/RecCostPics/" + file.GetName()));
                    lblMsg.Text = file.GetName();
                    //rtb.Text = file.GetName();
                }
            }
            else
            {
                BLL.ShowMessage(this, "Please Select File to Upload");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_RecruitmentCost", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Rg_RecmntCost_ItemCommand(object source, GridCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "DownloadAttachment")
            {
                GridDataItem ditem = (GridDataItem)e.Item;

                string filename = ((System.Web.UI.WebControls.LinkButton)(e.CommandSource)).Text;
                if (filename == "")
                {
                    return;
                }

                string path = MapPath("~/RecCostPics/" + filename);

                FileInfo file = new FileInfo(path);

                if (file.Exists)
                {
                    //Response.ContentType = "image/jpg";
                    Response.ContentType = "image/jpg";
                    Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filename + "\"");
                    Response.TransmitFile(Server.MapPath("~/RecCostPics/" + filename));
                    Response.End();
                }
                else
                {
                    // if file does not exist
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_RecruitmentCost", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lbtn_download_Command(object sender, CommandEventArgs e)
    {
        try
        {
            string strPath1 = "../RecCostPics/" + e.CommandArgument.ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "<script>window.open('" + strPath1 + "');</script>", false);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_RecruitmentCost", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}