using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using Telerik.Web.UI;
using SMHR;
using RECRUITMENT;
public partial class Recruitment_frm_ResumeShortList : System.Web.UI.Page
{

    RECRUITMENT_JOBREQUISITION _obj_Rec_JobRequisition;
    RECRUITMENT_RESUMESHORTLIST _obj_Rec_ResumeShortList;
    RECRUITMENT_ASSIGNEMPTORSL _obj_Rec_AssignEmptoRSL;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            Page.Validate();
            if (!Page.IsPostBack)
            {

                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Resume Short Listing");
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
                    rg_ShortListed.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btnShortList.Visible = false;
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

                if (Session["back"] != null)
                {
                    //  BLL.gridDateFormat(Convert.ToString(Session["EMP_ID"]), GApplicants, "APPLICANT_DOB");

                    if ((Session["REFRESH_JOBREQ_ID"]) != null)
                    {
                        // RMP_Applinat.Visible = false;
                        ddlJobReqCode.SelectedValue = Convert.ToString(Session["REFRESH_JOBREQ_ID"]);
                        int JobReq_id = Convert.ToInt32(ddlJobReqCode.SelectedValue);
                        //ddlJobReqCode.SelectedItem.Value =STR_TEST;
                        if ((Session["Tab"]) == "Apllicant")
                        {
                            ApplicantLoad(JobReq_id);
                            Session["Tab"] = null;

                            // btnShortList.Visible = true;
                        }
                        else
                        {
                            ShortListedLoad(JobReq_id);
                            //  btnShortList.Visible  = true;
                        }
                        Session["REFRESH_JOBREQ_ID"] = null;
                        RTS_ResumeShortList.SelectedIndex = 1;

                        //Load(JobReq_id);
                    }
                    else
                    {
                        try
                        {
                            RMP_Applinat.Visible = false;
                            Session["REFRESH_JOBREQ_ID"] = null;
                            LoadJobRequisition();
                        }
                        catch (Exception ex)
                        {
                            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ResumeShortList", ex.StackTrace, DateTime.Now);
                            Response.Redirect("~/Frm_ErrorPage.aspx");
                            return;
                        }
                    }
                    Session["back"] = null;
                }
                else
                {
                    try
                    {

                        RMP_Applinat.Visible = false;
                        Session["REFRESH_JOBREQ_ID"] = null;
                        LoadJobRequisition();
                    }
                    catch (Exception ex)
                    {
                        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ResumeShortList", ex.StackTrace, DateTime.Now);
                        Response.Redirect("~/Frm_ErrorPage.aspx");
                        return;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ResumeShortList", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }


    }

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    protected void ApplicantLoad(int jobReq_Id)
    {
        try
        {
            // ddlJobReqCode.SelectedItem.Value  = Convert.ToString (jobReq_Id);
            // Session["REFRESH_JOBREQ_ID"] = null;
            DataTable dt_Details = new DataTable();
            _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
            _obj_Rec_JobRequisition.JOBREQ_ID = jobReq_Id;
            _obj_Rec_JobRequisition.OPERATION = operation.Empty;
            // Session["REFRESH_JOBREQ_ID"] = Convert.ToInt32(ddlJobReqCode.SelectedItem.Value);
            // string STR_TEST3 = Convert.ToString(Session["REFRESH_JOBREQ_ID"]);      
            dt_Details = Recruitment_BLL.get_JobReqDetails(_obj_Rec_JobRequisition);
            if (dt_Details.Rows.Count != 0)
            {
                LoadJobRequisition();
                GApplicants.Enabled = true;
                //lbl_JR.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_ID"]);
                //txtDesc.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_REQCODE"]);
                txtDOC.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_REQDATE"]);
                txtDOE.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_REQEXPIRY"]);
                txtBU.Text = Convert.ToString(dt_Details.Rows[0]["BUSINESSUNIT_CODE"]);
                txtRaisedBy.Text = Convert.ToString(dt_Details.Rows[0]["Empname"]);
                txtDesignation.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_DESIGNATION"]);
                txtPositions.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_POSITIONS"]) + "Members";
                txtExp.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_EXPYEARS"]);
                LoadList(Convert.ToString(dt_Details.Rows[0]["JOBREQ_REQCODE"]), Convert.ToString(dt_Details.Rows[0]["JOBREQ_ISYEARSREQ"]), Convert.ToString(dt_Details.Rows[0]["JOBREQ_ISQUALREQ"]), Convert.ToString(dt_Details.Rows[0]["JOBREQ_ISSKILLREQ"]));
                GApplicants.DataBind();
                RMP_Applinat.Visible = true;
                RTS_ResumeShortList.Visible = true;
                //var tabNewYork1 = RTS_ResumeShortList.FindTabByText("Applicant");
                //tabNewYork1.Enabled = false ;
                RMP_Applinat.SelectedIndex = 0;
                GApplicants.Visible = true;
                // btnShortList.Enabled = true;
            }
            else
            {
                LoadList(Convert.ToString(dt_Details.Rows[0]["JOBREQ_REQCODE"]), Convert.ToString(dt_Details.Rows[0]["JOBREQ_ISYEARSREQ"]), Convert.ToString(dt_Details.Rows[0]["JOBREQ_ISQUALREQ"]), Convert.ToString(dt_Details.Rows[0]["JOBREQ_ISSKILLREQ"]));
                GApplicants.DataBind();
                RMP_Applinat.SelectedIndex = 0;
                GApplicants.Visible = true;
                GApplicants.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ResumeShortList", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void ShortListedLoad(int jobReq_Id)
    {
        try
        {
            // ddlJobReqCode.SelectedItem.Value  = Convert.ToString (jobReq_Id);
            // Session["REFRESH_JOBREQ_ID"] = null;
            DataTable dt_Details = new DataTable();
            _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
            _obj_Rec_JobRequisition.JOBREQ_ID = jobReq_Id;
            _obj_Rec_JobRequisition.OPERATION = operation.Empty;
            // Session["REFRESH_JOBREQ_ID"] = Convert.ToInt32(ddlJobReqCode.SelectedItem.Value);
            // string STR_TEST3 = Convert.ToString(Session["REFRESH_JOBREQ_ID"]);
            dt_Details = Recruitment_BLL.get_JobReqDetails(_obj_Rec_JobRequisition);
            if (dt_Details.Rows.Count != 0)
            {
                LoadJobRequisition();
                GApplicants.Enabled = true;
                //lbl_JR.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_ID"]);
                //txtDesc.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_REQCODE"]);
                txtDOC.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_REQDATE"]);
                txtDOE.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_REQEXPIRY"]);
                txtBU.Text = Convert.ToString(dt_Details.Rows[0]["BUSINESSUNIT_CODE"]);
                txtRaisedBy.Text = Convert.ToString(dt_Details.Rows[0]["Empname"]);
                txtDesignation.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_DESIGNATION"]);
                txtPositions.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_POSITIONS"]) + "Members";
                txtExp.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_EXPYEARS"]);
                LoadList(Convert.ToString(dt_Details.Rows[0]["JOBREQ_REQCODE"]), Convert.ToString(dt_Details.Rows[0]["JOBREQ_ISYEARSREQ"]), Convert.ToString(dt_Details.Rows[0]["JOBREQ_ISQUALREQ"]), Convert.ToString(dt_Details.Rows[0]["JOBREQ_ISSKILLREQ"]));
                GApplicants.DataBind();
                RMP_Applinat.Visible = true;
                RTS_ResumeShortList.Visible = true;
                //var tabNewYork1 = RTS_ResumeShortList.FindTabByText("Applicant");
                //tabNewYork1.Enabled = false ;
                RMP_Applinat.SelectedIndex = 1;
                GApplicants.Visible = true;
                //  btnShortList.Enabled = true;
            }
            else
            {
                LoadList(Convert.ToString(dt_Details.Rows[0]["JOBREQ_REQCODE"]), Convert.ToString(dt_Details.Rows[0]["JOBREQ_ISYEARSREQ"]), Convert.ToString(dt_Details.Rows[0]["JOBREQ_ISQUALREQ"]), Convert.ToString(dt_Details.Rows[0]["JOBREQ_ISSKILLREQ"]));
                GApplicants.DataBind();
                RMP_Applinat.SelectedIndex = 0;
                GApplicants.Visible = true;
                GApplicants.Enabled = true;
            }
            DataTable dt_ShortListed = new DataTable();
            _obj_Rec_ResumeShortList.Mode = 10;
            _obj_Rec_ResumeShortList.RESSHT_JOBREQID = jobReq_Id;
            dt_ShortListed = Recruitment_BLL.getApplicants(_obj_Rec_ResumeShortList);
            rg_ShortListed.DataSource = dt_ShortListed;
            rg_ShortListed.DataBind();
            RMP_Applinat.SelectedIndex = 1;

            rg_ShortListed.Visible = true;
            RTS_ResumeShortList.Visible = true;
            // btnShortList.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ResumeShortList", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void LoadShortListed()
    {
        try
        {
            //    Session["REFRESH_JOBREQ_ID"] = null;
            //    DataTable dt_Details = new DataTable();
            //    _obj_Rec_JobRequisition.OPERATION = operation.Empty;
            //    Session["REFRESH_JOBREQ_ID"] = Convert.ToInt32(ddlJobReqCode.SelectedItem.Value);
            //    string STR_TEST3 = Convert.ToString(Session["REFRESH_JOBREQ_ID"]);
            //    _obj_Rec_JobRequisition.JOBREQ_ID = Convert.ToInt32(ddlJobReqCode.SelectedItem.Value);
            //    dt_Details = BLL.get_JobReqDetails(_obj_Rec_JobRequisition);
            //    if (dt_Details.Rows.Count != 0)
            //    {

            //        GApplicants.Enabled = true;
            //        //lbl_JR.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_ID"]);
            //        txtDesc.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_REQCODE"]);
            //        txtDOC.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_REQDATE"]);
            //        txtDOE.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_REQEXPIRY"]);
            //        txtBU.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_REQEXPIRY"]);
            //        txtRaisedBy.Text = Convert.ToString(dt_Details.Rows[0]["Empname"]);
            //        txtDesignation.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_DESIGNATION"]);
            //        txtPositions.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_POSITIONS"]) + "Members";
            //        txtExp.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_EXPYEARS"]);
            //        LoadList(Convert.ToString(dt_Details.Rows[0]["JOBREQ_REQCODE"]), Convert.ToString(dt_Details.Rows[0]["JOBREQ_ISYEARSREQ"]), Convert.ToString(dt_Details.Rows[0]["JOBREQ_ISQUALREQ"]), Convert.ToString(dt_Details.Rows[0]["JOBREQ_ISSKILLREQ"]));
            //       // GApplicants.DataBind();
            //        RMP_Applinat.Visible = true;
            //        RTS_ResumeShortList.Visible = true;
            //        //var tabNewYork1 = RTS_ResumeShortList.FindTabByText("Applicant");
            //        //tabNewYork1.Enabled = false ;
            //        RMP_Applinat.SelectedIndex = 0;
            //        GApplicants.Visible = true;
            //        btnShortList.Enabled = true;
            //    }
            //    else
            //    {
            //        LoadList(Convert.ToString(dt_Details.Rows[0]["JOBREQ_REQCODE"]), Convert.ToString(dt_Details.Rows[0]["JOBREQ_ISYEARSREQ"]), Convert.ToString(dt_Details.Rows[0]["JOBREQ_ISQUALREQ"]), Convert.ToString(dt_Details.Rows[0]["JOBREQ_ISSKILLREQ"]));
            //     //   GApplicants.DataBind();
            //        RMP_Applinat.SelectedIndex = 0;
            //        GApplicants.Visible = true;
            //        GApplicants.Enabled = true;
            //    }
            DataTable dt_ShortListed = new DataTable();
            _obj_Rec_ResumeShortList = new RECRUITMENT_RESUMESHORTLIST();
            _obj_Rec_ResumeShortList.Mode = 10;
            _obj_Rec_ResumeShortList.RESSHT_JOBREQID = Convert.ToInt32(ddlJobReqCode.SelectedItem.Value);
            _obj_Rec_ResumeShortList.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            dt_ShortListed = Recruitment_BLL.getApplicants(_obj_Rec_ResumeShortList);
            rg_ShortListed.DataSource = dt_ShortListed;
            // rg_ShortListed.DataBind();
            rg_ShortListed.Visible = true;
            RTS_ResumeShortList.Visible = true;
            btnShortList.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ResumeShortList", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void Loadgridpaging()
    {
        try
        {
            Session["REFRESH_JOBREQ_ID"] = null;
            DataTable dt_Details = new DataTable();
            _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
            _obj_Rec_JobRequisition.OPERATION = operation.Empty;
            Session["REFRESH_JOBREQ_ID"] = Convert.ToInt32(ddlJobReqCode.SelectedItem.Value);
            string STR_TEST3 = Convert.ToString(Session["REFRESH_JOBREQ_ID"]);
            _obj_Rec_JobRequisition.JOBREQ_ID = Convert.ToInt32(ddlJobReqCode.SelectedItem.Value);
            dt_Details = Recruitment_BLL.get_JobReqDetails(_obj_Rec_JobRequisition);
            if (dt_Details.Rows.Count != 0)
            {
                GApplicants.Enabled = true;
                //lbl_JR.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_ID"]);
                //txtDesc.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_REQCODE"]);
                txtDOC.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_REQDATE"]);
                txtDOE.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_REQEXPIRY"]);
                txtBU.Text = Convert.ToString(dt_Details.Rows[0]["BUSINESSUNIT_CODE"]);
                txtRaisedBy.Text = Convert.ToString(dt_Details.Rows[0]["Empname"]);
                txtDesignation.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_DESIGNATION"]);
                txtPositions.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_POSITIONS"]) + "Members";
                txtExp.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_EXPYEARS"]);
                LoadList(Convert.ToString(dt_Details.Rows[0]["JOBREQ_REQCODE"]), Convert.ToString(dt_Details.Rows[0]["JOBREQ_ISYEARSREQ"]), Convert.ToString(dt_Details.Rows[0]["JOBREQ_ISQUALREQ"]), Convert.ToString(dt_Details.Rows[0]["JOBREQ_ISSKILLREQ"]));
                // GApplicants.DataBind();
                RMP_Applinat.Visible = true;
                RTS_ResumeShortList.Visible = true;
                //var tabNewYork1 = RTS_ResumeShortList.FindTabByText("Applicant");
                //tabNewYork1.Enabled = false ;
                RMP_Applinat.SelectedIndex = 0;
                GApplicants.Visible = true;
                btnShortList.Enabled = true;
            }
            else
            {
                LoadList(Convert.ToString(dt_Details.Rows[0]["JOBREQ_REQCODE"]), Convert.ToString(dt_Details.Rows[0]["JOBREQ_ISYEARSREQ"]), Convert.ToString(dt_Details.Rows[0]["JOBREQ_ISQUALREQ"]), Convert.ToString(dt_Details.Rows[0]["JOBREQ_ISSKILLREQ"]));
                // GApplicants.DataBind();
                RMP_Applinat.SelectedIndex = 0;
                GApplicants.Visible = true;
                GApplicants.Enabled = true;
            }
            //DataTable dt_ShortListed = new DataTable();
            //_obj_Rec_ResumeShortList.Mode = 10;
            //_obj_Rec_ResumeShortList.RESSHT_JOBREQID = Convert.ToInt32(ddlJobReqCode.SelectedItem.Value);
            //dt_ShortListed = BLL.getApplicants(_obj_Rec_ResumeShortList);
            //rg_ShortListed.DataSource = dt_ShortListed;
            //rg_ShortListed.DataBind();
            //rg_ShortListed.Visible = true;
            //RTS_ResumeShortList.Visible = true;
            //btnShortList.Enabled = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ResumeShortList", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void LoadJobRequisition()
    {
        try
        {
            ddlJobReqCode.Items.Clear();
            //DataTable dt = new DataTable();
            //_obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
            //_obj_Rec_JobRequisition.OPERATION = operation.Empty;
            //_obj_Rec_JobRequisition.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            //dt = Recruitment_BLL.get_JobReqDetails(_obj_Rec_JobRequisition);
            //ddlJobReqCode.DataSource = dt;
            //ddlJobReqCode.DataTextField = "JOBREQ_REQCODE";
            //ddlJobReqCode.DataValueField = "JOBREQ_ID";
            //ddlJobReqCode.DataBind();
            //ddlJobReqCode.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

            //TO LOAD JOB REQUISITION, 31.07.2012
            _obj_Rec_AssignEmptoRSL = new RECRUITMENT_ASSIGNEMPTORSL();
            _obj_Rec_AssignEmptoRSL.ASSIGNEMP_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            _obj_Rec_AssignEmptoRSL.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Rec_AssignEmptoRSL.MODE = 7;
            DataTable DT = Recruitment_BLL.get_AssigmEMPtoRSL(_obj_Rec_AssignEmptoRSL);
            if (DT.Rows.Count > 0)
            {
                ddlJobReqCode.DataSource = DT;
                ddlJobReqCode.DataTextField = "JOBREQ_REQCODE";
                ddlJobReqCode.DataValueField = "JOBREQ_ID";
                ddlJobReqCode.DataBind();
                ddlJobReqCode.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ResumeShortList", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void LoadApplicants(string JOBREQ_REQCODE, int Mode)
    {
        try
        {
            DataTable dtApp = new DataTable();
            _obj_Rec_ResumeShortList = new RECRUITMENT_RESUMESHORTLIST();
            _obj_Rec_ResumeShortList.JOBREQ_REQCODE = JOBREQ_REQCODE;
            _obj_Rec_ResumeShortList.Mode = Mode;
            _obj_Rec_ResumeShortList.RESSHT_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dtApp = Recruitment_BLL.getApplicants(_obj_Rec_ResumeShortList);
            if (dtApp.Rows.Count != 0)
            {
                GApplicants.DataSource = dtApp;
            }
            else
            {
                GApplicants.DataSource = dtApp;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ResumeShortList", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void LoadList(string JOBREQ_REQCODE, string IsYears, string IsQual, string IsSkill)
    {
        try
        {
            if (Convert.ToBoolean(IsSkill) && Convert.ToBoolean(IsYears) && Convert.ToBoolean(IsQual))
            {
                LoadApplicants(JOBREQ_REQCODE.ToString(), 7);
                //GApplicants.DataBind();
            }
            else if (Convert.ToBoolean(IsSkill) && Convert.ToBoolean(IsYears))
            {
                LoadApplicants(JOBREQ_REQCODE.ToString(), 5);
                // GApplicants.DataBind();
            }
            else if (Convert.ToBoolean(IsQual) && Convert.ToBoolean(IsSkill))
            {
                LoadApplicants(JOBREQ_REQCODE.ToString(), 4);
                // GApplicants.DataBind();
            }
            else if (Convert.ToBoolean(IsQual) && Convert.ToBoolean(IsYears))
            {
                LoadApplicants(JOBREQ_REQCODE.ToString(), 6);
                //GApplicants.DataBind();
            }

            else if (Convert.ToBoolean(IsYears))
            {
                LoadApplicants(JOBREQ_REQCODE.ToString(), 3);
                // GApplicants.DataBind();
            }

            else if (Convert.ToBoolean(IsQual))
            {
                LoadApplicants(JOBREQ_REQCODE.ToString(), 2);
                // GApplicants.DataBind();
            }
            else if (Convert.ToBoolean(IsSkill))
            {
                LoadApplicants(JOBREQ_REQCODE.ToString(), 1);
                //GApplicants.DataBind();

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ResumeShortList", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private bool chkExisting()
    {
        try
        {
            int index;
            CheckBox chkBox = new CheckBox();
            Label lblApp = new Label();
            bool result = false;
            for (index = 0; index <= GApplicants.Items.Count - 1; index++)
            {
                chkBox = GApplicants.Items[index].FindControl("chkChoose") as CheckBox;
                lblApp = GApplicants.Items[index].FindControl("lblAppID") as Label;
                if (chkBox.Checked)
                {
                    DataTable dtDetails = new DataTable();
                    _obj_Rec_ResumeShortList = new RECRUITMENT_RESUMESHORTLIST();
                    //_obj_Rec_ResumeShortList.RESSHT_JOBREQID = Convert.ToInt32(ddlJobReqCode.SelectedItem.Value);
                    _obj_Rec_ResumeShortList.RESSHT_APPLID = Convert.ToInt32(lblApp.Text);
                    _obj_Rec_ResumeShortList.Mode = 8;
                    dtDetails = Recruitment_BLL.getApplicants(_obj_Rec_ResumeShortList);
                    if (dtDetails.Rows.Count != 0)
                    {
                        result = true;
                        chkBox.BackColor = System.Drawing.Color.Yellow;
                    }
                    else
                    {
                        result = false;
                        chkBox.BackColor = System.Drawing.Color.White;
                    }
                }
            }
            return result;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ResumeShortList", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

            return false;
        }
    }

    protected void rg_needsource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            Loadgridpaging();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ResumeShortList", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void rg_ShortListed_needsource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadShortListed();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ResumeShortList", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void ddlJobReqCode_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (ddlJobReqCode.SelectedValue != "-1")
            {
                RTS_ResumeShortList.SelectedIndex = 0;
                //RTS_ResumeShortList.SelectedTab.Text = "Applicant";

                Session["REFRESH_JOBREQ_ID"] = null;
                DataTable dt_Details = new DataTable();
                _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
                _obj_Rec_JobRequisition.OPERATION = operation.Empty;
                string STR_TEST3 = Convert.ToString(Session["REFRESH_JOBREQ_ID"]);
                _obj_Rec_JobRequisition.JOBREQ_ID = Convert.ToInt32(ddlJobReqCode.SelectedItem.Value);
                dt_Details = Recruitment_BLL.get_JobReqDetails(_obj_Rec_JobRequisition);
                if (dt_Details.Rows.Count != 0)
                {
                    GApplicants.Enabled = true;
                    //lbl_JR.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_ID"]);
                    //txtDesc.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_REQCODE"]);
                    txtDOC.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_REQDATE"]);
                    txtDOE.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_REQEXPIRY"]);
                    txtBU.Text = Convert.ToString(dt_Details.Rows[0]["BUSINESSUNIT_CODE"]);
                    txtRaisedBy.Text = Convert.ToString(dt_Details.Rows[0]["Empname"]);
                    txtDesignation.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_DESIGNATION"]);
                    txtPositions.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_POSITIONS"]) + "Members";
                    txtExp.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_EXPYEARS"]);
                    LoadList(Convert.ToString(dt_Details.Rows[0]["JOBREQ_REQCODE"]), Convert.ToString(dt_Details.Rows[0]["JOBREQ_ISYEARSREQ"]), Convert.ToString(dt_Details.Rows[0]["JOBREQ_ISQUALREQ"]), Convert.ToString(dt_Details.Rows[0]["JOBREQ_ISSKILLREQ"]));
                    GApplicants.DataBind();
                    RMP_Applinat.Visible = true;
                    RTS_ResumeShortList.Visible = true;
                    //var tabNewYork1 = RTS_ResumeShortList.FindTabByText("Applicant");
                    //tabNewYork1.Enabled = false ;
                    RMP_Applinat.SelectedIndex = 0;
                    GApplicants.Visible = true;
                    btnShortList.Visible = true;
                }
                else
                {
                    LoadList(Convert.ToString(dt_Details.Rows[0]["JOBREQ_REQCODE"]), Convert.ToString(dt_Details.Rows[0]["JOBREQ_ISYEARSREQ"]), Convert.ToString(dt_Details.Rows[0]["JOBREQ_ISQUALREQ"]), Convert.ToString(dt_Details.Rows[0]["JOBREQ_ISSKILLREQ"]));
                    DataTable dt = new DataTable();
                    GApplicants.DataSource = dt;
                    GApplicants.DataBind();
                    RMP_Applinat.SelectedIndex = 0;
                    GApplicants.Visible = true;
                    GApplicants.Enabled = true;
                    clearfields();
                }
                DataTable dt_ShortListed = new DataTable();
                _obj_Rec_ResumeShortList = new RECRUITMENT_RESUMESHORTLIST();
                _obj_Rec_ResumeShortList.Mode = 10;

                _obj_Rec_ResumeShortList.RESSHT_JOBREQID = Convert.ToInt32(ddlJobReqCode.SelectedItem.Value);
                _obj_Rec_ResumeShortList.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                dt_ShortListed = Recruitment_BLL.getApplicants(_obj_Rec_ResumeShortList);
                rg_ShortListed.DataSource = dt_ShortListed;
                rg_ShortListed.DataBind();
                rg_ShortListed.Visible = true;
                RTS_ResumeShortList.Visible = true;
                // btnShortList.Enabled = false;  
            }
            else
            {
                RMP_Applinat.Visible = false;
                RTS_ResumeShortList.Visible = false;
                //txtDesc.Text = "";
                txtDOC.Text = "";
                txtDOE.Text = "";
                txtRaisedBy.Text = "";
                txtBU.Text = "";
                txtDesignation.Text = "";
                txtPositions.Text = "";
                txtExp.Text = "";
                btnShortList.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ResumeShortList", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

    }

    protected void btnShortList_Click(object sender, EventArgs e)
    {
        try
        {
            int index1;
            bool res1;
            int i = 0;
            CheckBox chk_Box = new CheckBox();
            for (index1 = 0; index1 <= GApplicants.Items.Count - 1; index1++)
            {
                chk_Box = GApplicants.Items[index1].FindControl("chkChoose") as CheckBox;
                if (chk_Box.Checked)
                {
                    chk_Box.Enabled = false;
                }
                else
                {
                    i = i + 1;
                }
            }
            if (i == GApplicants.Items.Count)
            {
                BLL.ShowMessage(this, "Please Select atleast one Applicant for shortlisting");
                return;
            }
            res1 = chkExisting();
            if (res1 == true)
            {
                BLL.ShowMessage(this, "Applicant(s) have already been shortlisted");
                return;
            }
            int index;
            CheckBox chkBox = new CheckBox();
            Label lblApp = new Label();
            Label lblJR = new Label();
            bool res2 = false;
            for (index = 0; index <= GApplicants.Items.Count - 1; index++)
            {
                chkBox = GApplicants.Items[index].FindControl("chkChoose") as CheckBox;
                lblApp = GApplicants.Items[index].FindControl("lblAppID") as Label;
                lblJR = GApplicants.Items[index].FindControl("JOBREQ_ID") as Label;
                if (chkBox.Checked)
                {
                    _obj_Rec_ResumeShortList = new RECRUITMENT_RESUMESHORTLIST();
                    _obj_Rec_ResumeShortList.RESSHT_JOBREQID = Convert.ToInt32(ddlJobReqCode.SelectedItem.Value);
                    _obj_Rec_ResumeShortList.RESSHT_APPLID = Convert.ToInt32(lblApp.Text);
                    _obj_Rec_ResumeShortList.RESSHT_ISSHORTLIST = true;
                    _obj_Rec_ResumeShortList.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                    _obj_Rec_ResumeShortList.CREATEDBY = 0;
                    _obj_Rec_ResumeShortList.CREATEDDATE = DateTime.Now;
                    _obj_Rec_ResumeShortList.LASTMDFBY = 1;
                    _obj_Rec_ResumeShortList.LASTMDFDATE = DateTime.Now;
                    _obj_Rec_ResumeShortList.OPERATION = operation.Insert;
                    res2 = Recruitment_BLL.set_ResumeShortList(_obj_Rec_ResumeShortList);
                }
            }
            if (res2 == true)
            {
                BLL.ShowMessage(this, "Selected Applicants are Short Listed");
                try
                {
                    Session["REFRESH_JOBREQ_ID"] = null;
                    DataTable dt_Details = new DataTable();
                    _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
                    _obj_Rec_JobRequisition.OPERATION = operation.Empty;

                    string STR_TEST3 = Convert.ToString(Session["REFRESH_JOBREQ_ID"]);
                    _obj_Rec_JobRequisition.JOBREQ_ID = Convert.ToInt32(ddlJobReqCode.SelectedItem.Value);
                    dt_Details = Recruitment_BLL.get_JobReqDetails(_obj_Rec_JobRequisition);
                    if (dt_Details.Rows.Count != 0)
                    {

                        GApplicants.Enabled = true;
                        //lbl_JR.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_ID"]);
                        //txtDesc.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_REQCODE"]);
                        txtDOC.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_REQDATE"]);
                        txtDOE.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_REQEXPIRY"]);
                        txtBU.Text = Convert.ToString(dt_Details.Rows[0]["BUSINESSUNIT_CODE"]);
                        txtRaisedBy.Text = Convert.ToString(dt_Details.Rows[0]["Empname"]);
                        txtDesignation.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_DESIGNATION"]);
                        txtPositions.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_POSITIONS"]) + "Members";
                        txtExp.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_EXPYEARS"]);
                        LoadList(Convert.ToString(dt_Details.Rows[0]["JOBREQ_REQCODE"]), Convert.ToString(dt_Details.Rows[0]["JOBREQ_ISYEARSREQ"]), Convert.ToString(dt_Details.Rows[0]["JOBREQ_ISQUALREQ"]), Convert.ToString(dt_Details.Rows[0]["JOBREQ_ISSKILLREQ"]));
                        GApplicants.DataBind();
                        RMP_Applinat.Visible = true;
                        RTS_ResumeShortList.Visible = true;
                        //var tabNewYork1 = RTS_ResumeShortList.FindTabByText("Applicant");
                        //tabNewYork1.Enabled = false ;
                        RMP_Applinat.SelectedIndex = 0;
                        GApplicants.Visible = true;
                        btnShortList.Visible = true;
                    }
                    else
                    {
                        LoadList(Convert.ToString(dt_Details.Rows[0]["JOBREQ_REQCODE"]), Convert.ToString(dt_Details.Rows[0]["JOBREQ_ISYEARSREQ"]), Convert.ToString(dt_Details.Rows[0]["JOBREQ_ISQUALREQ"]), Convert.ToString(dt_Details.Rows[0]["JOBREQ_ISSKILLREQ"]));
                        GApplicants.DataBind();
                        RMP_Applinat.SelectedIndex = 0;
                        GApplicants.Visible = true;
                        GApplicants.Enabled = true;
                    }
                    DataTable dt_ShortListed = new DataTable();
                    _obj_Rec_ResumeShortList = new RECRUITMENT_RESUMESHORTLIST();
                    _obj_Rec_ResumeShortList.Mode = 10;

                    _obj_Rec_ResumeShortList.RESSHT_JOBREQID = Convert.ToInt32(ddlJobReqCode.SelectedItem.Value);
                    dt_ShortListed = Recruitment_BLL.getApplicants(_obj_Rec_ResumeShortList);
                    rg_ShortListed.DataSource = dt_ShortListed;
                    rg_ShortListed.DataBind();
                    rg_ShortListed.Visible = true;
                    RTS_ResumeShortList.Visible = true;
                    // btnShortList.Enabled = false;  
                }
                catch (Exception ex)
                {
                    SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ResumeShortList", ex.StackTrace, DateTime.Now);
                    Response.Redirect("~/Frm_ErrorPage.aspx");
                    return;
                }
                return;
            }
            else
            {
                BLL.ShowMessage(this, "An Error Occured While doing the process");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ResumeShortList", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void lnk_view_Command(object sender, CommandEventArgs e)
    {
        try
        {
            Session["Tab"] = null;
            Session["Tab"] = "Apllicant";
            Session["REFRESH_JOBREQ_ID"] = Convert.ToInt32(ddlJobReqCode.SelectedItem.Value);
            string str_id = Convert.ToString(e.CommandArgument);
            Response.Redirect("~/Recruitment/frm_ShortListApplicantsView.aspx?APPID=" + str_id, false);
            return;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ResumeShortList", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void lnk_viewShortListed_Command(object sender, CommandEventArgs e)
    {
        try
        {
            Session["Tab"] = null;
            Session["Tab"] = "ShortListed";
            Session["REFRESH_JOBREQ_ID"] = Convert.ToInt32(ddlJobReqCode.SelectedItem.Value);
            string str_id = Convert.ToString(e.CommandArgument);
            Response.Redirect("~/Recruitment/frm_ShortListApplicantsView.aspx?APPID=" + str_id, false);
            return;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ResumeShortList", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void RTS_ResumeShortList_TabClick(object sender, RadTabStripEventArgs e)
    {
        try
        {
            if (RTS_ResumeShortList.SelectedTab.Text == "Applicant")
            {
                btnShortList.Visible = true;
            }
            else
            {
                DataTable dt_ShortListed = new DataTable();
                _obj_Rec_ResumeShortList = new RECRUITMENT_RESUMESHORTLIST();
                _obj_Rec_ResumeShortList.Mode = 10;
                _obj_Rec_ResumeShortList.RESSHT_JOBREQID = Convert.ToInt32(ddlJobReqCode.SelectedItem.Value);
                _obj_Rec_ResumeShortList.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                dt_ShortListed = Recruitment_BLL.getApplicants(_obj_Rec_ResumeShortList);
                rg_ShortListed.DataSource = dt_ShortListed;
                rg_ShortListed.DataBind();
                rg_ShortListed.Visible = true;
                RTS_ResumeShortList.Visible = true;
                btnShortList.Enabled = true;

                //  RTS_ResumeShortList.SelectedIndex = 1;
                //LoadShortListed();
                btnShortList.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ResumeShortList", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void clearfields()
    {
        try
        {

            ddlJobReqCode.Items.Clear();
            LoadJobRequisition();
            //txtDesc.Text = "";
            txtDOC.Text = "";
            txtDOE.Text = "";
            txtRaisedBy.Text = "";
            //txtdepartment.text = "";
            txtDesignation.Text = "";
            txtPositions.Text = "";
            txtExp.Text = "";
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ResumeShortList", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
}
