using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Telerik.Web.UI;
using System.Data;
using SMHR;
using RECRUITMENT;
using SPMS;
using System.Globalization;
using System.Threading;
using System.Net.Mail;
using System.Configuration;

public partial class Recruitment_frm_InterviewPhaseDefinition : System.Web.UI.Page
{
    #region References

    SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit;
    SMHR_EMPLOYEE _obj_smhr_employee;
    SMHR_MASTERS _obj_Smhr_Masters;
    RECRUITMENT_INTERVIEW_PHASE_DEF _obj_Rec_Interview_Phase_Def;
    RECRUITMENT_INTERVIEW_PHASE_DEF_SKILLS _obj_Rec_interview_Phase_Def_Skills;
    RECRUITMENT_JOBREQUISITION _obj_Rec_JobRequisition;
    RECRUITMENT_JOBREQSKILLS _obj_Rec_JobReqSkills;
    RECRUITMENT_INTERVIEW_PRIORITY _obj_Rec_Interview_Priority;
    PMS_GETEMPLOYEE _obj_PMS_getemployee;

    #endregion

    #region PageLoad

    static bool ChkStatus = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Page.Validate();
        try
        {
            //code for security privilage
            Session.Remove("WRITEFACILITY");

            SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

            _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
            _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
            _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Phase Definition");//COUNTRY");
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
                RG_InterviewPhaseDefinition.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                btn_Submit.Visible = false;
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
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewPhaseDefinition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region Grid NeedDataSource Event

    protected void RG_InterviewPhaseDefinition_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewPhaseDefinition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    #endregion

    #region Button Click Event

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            //if (rlb_skills.CheckedItems.Count == 0)
            //{
            //    Recruitment_BLL.ShowMessage(this, "Please Select Skills From List");
            //    return;
            //}
            //else
            //{
            _obj_Rec_Interview_Phase_Def = new RECRUITMENT_INTERVIEW_PHASE_DEF();

            _obj_Rec_Interview_Phase_Def.Phase_Name = Convert.ToString(Rtxt_PhaseName.Text.Replace("'", "''"));
            _obj_Rec_Interview_Phase_Def.Phase_Desc = Convert.ToString(Rtxt_PhaseDescription.Text.Replace("'", "''"));
            _obj_Rec_Interview_Phase_Def.Phase_JobReqID = Convert.ToInt32(Rcb_JobRequestId.SelectedItem.Value);
            _obj_Rec_Interview_Phase_Def.Phase_POSID = Convert.ToInt32(rcmb_Designation.SelectedItem.Value);
            _obj_Rec_Interview_Phase_Def.Phase_POSCODE = Convert.ToString(rcmb_Designation.SelectedItem.Text.Replace("'", "''"));

            //_obj_Rec_Interview_Phase_Def.PHASE_SKILL = Convert.ToInt32(Rcb_Skill.SelectedItem.Value);
            _obj_Rec_Interview_Phase_Def.PHASE_FINAL = Convert.ToBoolean(Chk_Final.Checked);
            _obj_Rec_Interview_Phase_Def.PHASE_BUSINESSUNIT = Convert.ToInt32(Rcb_BusinessUnit.SelectedItem.Value);
            //if (rlb_skills.CheckedItems.Count > 0)
            //{
            //    for (int i = 0; i < rlb_skills.CheckedItems.Count; i++)
            //    {
            //        _obj_Rec_Interview_Phase_Def.PHASE_SKILL = Convert.ToInt32(rlb_skills.CheckedItems[i].Value);
            //    }
            //}
            //DateTime DT_Interviewdate = DateTime.Parse(rdtp_interviewdate.SelectedDate,System.Globalization.CultureInfo.CreateSpecificCulture("en-GB"));
            _obj_Rec_Interview_Phase_Def.Phase_InterviewFromDate = Convert.ToDateTime(rdtp_interviewfromdate.SelectedDate);
            _obj_Rec_Interview_Phase_Def.Phase_InterviewToDate = Convert.ToDateTime(rdtp_interviewtodate.SelectedDate);
            //_obj_Rec_Interview_Phase_Def.PHASE_INTERVIEWERNAME = Convert.ToInt32(Rcb_InterviewerName.SelectedItem.Value);
            //_obj_Rec_Interview_Phase_Def.PHASE_GRADESET = Convert.ToInt32(Rcb_Gradeset.SelectedItem.Value);
            //_obj_Rec_Interview_Phase_Def.PHASE_PRIORITY = Convert.ToInt32(Rcb_Priority.SelectedItem.Value);
            _obj_Rec_Interview_Phase_Def.PHASE_PRIORITY = Convert.ToInt32(Rtxt_Priority.Text);
            _obj_Rec_Interview_Phase_Def.Phase_Createdby = Convert.ToInt32(Session["User_Id"]);
            _obj_Rec_Interview_Phase_Def.Phase_CreatedDate = DateTime.Now;
            _obj_Rec_Interview_Phase_Def.Phase_LastMdfBy = Convert.ToInt32(Session["User_Id"]);
            _obj_Rec_Interview_Phase_Def.Phase_LastMdfdate = DateTime.Now;
            _obj_Rec_Interview_Phase_Def.PHASE_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            switch (((Button)sender).ID.ToUpper())
            {

                case "BTN_UPDATE":
                    //_obj_Rec_JobRequisition.MODE = 15;
                    //_obj_Rec_JobRequisition.JOBREQ_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                    //_obj_Rec_JobRequisition.JOBREQ_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
                    //DataTable DTJR = Recruitment_BLL.get_JobRequisition(_obj_Rec_JobRequisition);
                    //lbl_JRID.Text = Convert.ToString(DTJR.Rows[0]["JOBREQ_ID"]);

                    //_obj_Rec_JobRequisition.MODE = 14;
                    //_obj_Rec_JobRequisition.JOBREQ_ID = Convert.ToInt32(lbl_JRID.Text);
                    //_obj_Rec_JobRequisition.JOBREQ_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                    //DataTable DT_ = Recruitment_BLL.get_JobRequisition(_obj_Rec_JobRequisition);

                    //if (Convert.ToDateTime(DT_.Rows[0]["JOBREQ_REQEXPIRY"]) > Convert.ToDateTime(DT_.Rows[0]["PHASE_INTERVIEWDATE"]))
                    //{
                    //    Recruitment_BLL.ShowMessage(this, "Job Requisition Expected Closure date must be less than or Equal to Interview Date");
                    //    return;
                    //}

                    //if (Chk_Final.Checked)
                    //{
                    //    _obj_Rec_Interview_Phase_Def.Mode = 11;
                    //    if (Convert.ToString(Recruitment_BLL.get_InterviewPhaseDefinition(_obj_Rec_Interview_Phase_Def).Rows[0]["Count"]) == "1")
                    //    {
                    //        Recruitment_BLL.ShowMessage(this, "Sorry!This cannot be Final Round");
                    //        return;
                    //    }
                    //}

                    if (Chk_Final.Checked)
                    {

                        _obj_Rec_Interview_Phase_Def.Mode = 11;
                        if (Convert.ToString(Recruitment_BLL.get_InterviewPhaseDefinition(_obj_Rec_Interview_Phase_Def).Rows[0]["Count"]) == "0")
                        {
                            Recruitment_BLL.ShowMessage(this, "Sorry!This cannot be Final Round");
                            return;
                        }

                        if (ChkStatus == false)
                        {
                            _obj_Rec_Interview_Phase_Def.Mode = 8;
                            if (Convert.ToString(Recruitment_BLL.get_InterviewPhaseDefinition(_obj_Rec_Interview_Phase_Def).Rows[0]["Count"]) != "0")
                            {
                                Recruitment_BLL.ShowMessage(this, "Already Final round is Defined");
                                return;
                            }
                        }

                        _obj_Rec_Interview_Phase_Def.Mode = 12;
                        DataTable DTPriorityValue = new DataTable();
                        DTPriorityValue = Recruitment_BLL.get_InterviewPhaseDefinition(_obj_Rec_Interview_Phase_Def);

                        if (Convert.ToInt32(lbl_PriorityValue.Text) < Convert.ToInt32(DTPriorityValue.Rows[0]["VALUE"]))
                        {
                            Recruitment_BLL.ShowMessage(this, "This cannot be declared as Final Round");
                            return;
                        }

                        _obj_Rec_Interview_Phase_Def.Mode = 13;
                        DataTable DTPriorityRows = new DataTable();
                        DTPriorityRows = Recruitment_BLL.get_InterviewPhaseDefinition(_obj_Rec_Interview_Phase_Def);

                        if (Convert.ToInt32(DTPriorityRows.Rows.Count) != Convert.ToInt32(DTPriorityValue.Rows[0]["VALUE"]))
                        {
                            Recruitment_BLL.ShowMessage(this, "Arrange the Priorities in an order");
                            return;
                        }

                        if (Convert.ToInt32(DTPriorityRows.Rows.Count) == Convert.ToInt32(DTPriorityValue.Rows[0]["VALUE"]) - 1)
                        {
                            int test = 0;
                            List<int> listofValues = new List<int>();
                            for (int i = 0; i < Convert.ToInt32(DTPriorityValue.Rows[0]["VALUE"]) - 1; i++)
                            {
                                test = Convert.ToInt32(DTPriorityRows.DataSet.Tables[0].Rows[i][0]);
                                listofValues.Add(test);
                            }
                            for (int i = 0; i < Convert.ToInt32(DTPriorityValue.Rows[0]["VALUE"]); i--)
                            {
                                if (!listofValues.Contains(i))
                                {
                                    Recruitment_BLL.ShowMessage(this, "Arrange the Priorities in an order");
                                    return;
                                }
                            }
                        }
                        else if (Convert.ToInt32(DTPriorityRows.Rows.Count) == Convert.ToInt32(DTPriorityValue.Rows[0]["VALUE"]))
                        {

                            int test = 0;
                            List<int> listofValues = new List<int>();
                            for (int i = 0; i < Convert.ToInt32(DTPriorityValue.Rows[0]["VALUE"]); i++)
                            {
                                test = Convert.ToInt32(DTPriorityRows.DataSet.Tables[0].Rows[i][0]);
                                listofValues.Add(test);
                            }
                            for (int i = 1; i < Convert.ToInt32(DTPriorityValue.Rows[0]["VALUE"]) + 1; i++)
                            {
                                if (!listofValues.Contains(i))
                                {
                                    Recruitment_BLL.ShowMessage(this, "Arrange the Priorities in an order");
                                    return;
                                }
                            }

                        }

                        //if (Convert.ToInt32(lbl_PriorityValue.Text) != Convert.ToInt32(Rcb_Priority.SelectedItem.Value))
                        //{
                        //    if (Convert.ToInt32(Rcb_Priority.SelectedItem.Value) != Convert.ToInt32(DTPriorityValue.Rows[0]["VALUE"]) + 1)
                        //    {
                        //        Recruitment_BLL.ShowMessage(this, "The Priority should be " + (Convert.ToInt32(DTPriorityValue.Rows[0]["VALUE"]) + 1));
                        //        return;
                        //    }
                        //}
                        if (Convert.ToInt32(lbl_PriorityValue.Text) != Convert.ToInt32(Rtxt_Priority.Text))
                        {
                            if (Convert.ToInt32(Rtxt_Priority.Text) != Convert.ToInt32(DTPriorityValue.Rows[0]["VALUE"]) + 1)
                            {
                                Recruitment_BLL.ShowMessage(this, "The Priority should be " + (Convert.ToInt32(DTPriorityValue.Rows[0]["VALUE"]) + 1));
                                return;
                            }
                        }

                    }

                    if (lbl_InterviewNameCheck.Text.Trim() != Rcb_InterviewerName.SelectedItem.Value)
                    {
                        _obj_Rec_Interview_Phase_Def.Mode = 10;
                        _obj_Rec_Interview_Phase_Def.PHASE_INTERVIEWERNAME = Convert.ToInt32(Rcb_InterviewerName.SelectedItem.Value);

                        if (Convert.ToString(Recruitment_BLL.get_InterviewPhaseDefinition(_obj_Rec_Interview_Phase_Def).Rows[0]["Count"]) != "0")
                        {
                            Recruitment_BLL.ShowMessage(this, "Already this Employee is assigned for this JobRequest");
                            return;
                        }

                        _obj_Rec_Interview_Phase_Def.Mode = 5;

                        _obj_Rec_Interview_Phase_Def.Phase_ID = Convert.ToInt32(lbl_PhaseId.Text);
                        if (Convert.ToString(Recruitment_BLL.get_InterviewPhaseDefinition(_obj_Rec_Interview_Phase_Def).Rows[0]["Count"]) != "0")
                        {
                            Recruitment_BLL.ShowMessage(this, "This Combination Already Exists");
                            return;
                        }
                    }
                    else
                    {
                        _obj_Rec_Interview_Phase_Def.Mode = 10;

                        _obj_Rec_Interview_Phase_Def.Phase_ID = Convert.ToInt32(lbl_PhaseId.Text);
                        _obj_Rec_Interview_Phase_Def.PHASE_INTERVIEWERNAME = Convert.ToInt32(lbl_InterviewNameCheck.Text);
                        if (Convert.ToString(Recruitment_BLL.get_InterviewPhaseDefinition(_obj_Rec_Interview_Phase_Def).Rows[0]["Count"]) != "1")
                        {
                            Recruitment_BLL.ShowMessage(this, "This Combination Already Exists");
                            return;
                        }
                    }

                    //To check if given Interview Date(s) is earlier than previous round Date(s)
                    _obj_Rec_Interview_Phase_Def.Mode = 22;
                    if (Recruitment_BLL.IsPhaseExists(_obj_Rec_Interview_Phase_Def))
                    {
                        Recruitment_BLL.ShowMessage(this, "Interview Phase Dates must not be before previous round");
                        return;
                    }

                    _obj_Rec_Interview_Phase_Def.Mode = 2;
                    _obj_Rec_Interview_Phase_Def.Phase_ID = Convert.ToInt32(lbl_PhaseId.Text);
                    //bool dt = Recruitment_BLL.set_InterviewPhaseDefinition(_obj_Rec_Interview_Phase_Def);


                    if (rdtp_interviewtodate.SelectedDate != null)
                    {
                        _obj_Rec_Interview_Phase_Def.Phase_InterviewToDate = Convert.ToDateTime(rdtp_interviewtodate.SelectedDate);
                    }
                    else
                    {
                        _obj_Rec_Interview_Phase_Def.Phase_InterviewToDate = null;
                    }

                    if (rdtp_interviewfromdate.SelectedDate != null)
                    {
                        _obj_Rec_Interview_Phase_Def.Phase_InterviewFromDate = Convert.ToDateTime(rdtp_interviewfromdate.SelectedDate);
                    }
                    else
                    {
                        _obj_Rec_Interview_Phase_Def.Phase_InterviewFromDate = null;
                    }

                    if (Recruitment_BLL.set_InterviewPhaseDefinition(_obj_Rec_Interview_Phase_Def))
                    {
                        _obj_Rec_interview_Phase_Def_Skills = new RECRUITMENT_INTERVIEW_PHASE_DEF_SKILLS();
                        _obj_Rec_interview_Phase_Def_Skills.PHASE_DEF_SKILLS_PHASEID = Convert.ToInt32(lbl_PhaseId.Text);
                        _obj_Rec_interview_Phase_Def_Skills.MODE = 18;
                        Recruitment_BLL.set_interview_def_skills(_obj_Rec_interview_Phase_Def_Skills);

                        for (int i = 0; i <= rlb_skills.CheckedItems.Count - 1; i++)
                        {
                            _obj_Rec_interview_Phase_Def_Skills.MODE = 14;
                            _obj_Rec_interview_Phase_Def_Skills.PHASE_DEF_SKILLS_SKILLID = Convert.ToInt32(rlb_skills.CheckedItems[i].Value);
                          //  _obj_Rec_interview_Phase_Def_Skills.PHASE_DEF_SKILLS_CREATEDBY = 1;//##Session Required Here
                            _obj_Rec_interview_Phase_Def_Skills.PHASE_DEF_SKILLS_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);//##Session Required Here
                            _obj_Rec_interview_Phase_Def_Skills.PHASE_DEF_SKILLS_CREATEDDATE = DateTime.Now;
                            Recruitment_BLL.set_interview_def_skills(_obj_Rec_interview_Phase_Def_Skills);
                        }


                        Recruitment_BLL.ShowMessage(this, "Information Updated Successfully");
                        sendMail();
                    }
                    else
                        Recruitment_BLL.ShowMessage(this, "Information Not Updated");

                    LoadGrid();
                    RG_InterviewPhaseDefinition.DataBind();
                    RMP_InterviewPhaseDefinition.SelectedIndex = 0;

                    break;

                case "BTN_SUBMIT":

                    _obj_Rec_Interview_Phase_Def.Phase_JobReqID = Convert.ToInt32(Rcb_JobRequestId.SelectedItem.Value);

                    if (Chk_Final.Checked)
                    {
                        _obj_Rec_Interview_Phase_Def.Mode = 11;
                        if (Convert.ToString(Recruitment_BLL.get_InterviewPhaseDefinition(_obj_Rec_Interview_Phase_Def).Rows[0]["Count"]) == "0")
                        {
                            Recruitment_BLL.ShowMessage(this, "Sorry!This cannot be Final Round");
                            return;
                        }

                        _obj_Rec_Interview_Phase_Def.Mode = 12;
                        DataTable DTPriorityValue = new DataTable();
                        DTPriorityValue = Recruitment_BLL.get_InterviewPhaseDefinition(_obj_Rec_Interview_Phase_Def);

                        _obj_Rec_Interview_Phase_Def.Mode = 13;
                        DataTable DTPriorityRows = new DataTable();
                        DTPriorityRows = Recruitment_BLL.get_InterviewPhaseDefinition(_obj_Rec_Interview_Phase_Def);

                        if (Convert.ToInt32(DTPriorityRows.Rows.Count) != Convert.ToInt32(DTPriorityValue.Rows[0]["VALUE"]))
                        {
                            Recruitment_BLL.ShowMessage(this, "Arrange the Priorities in an order");
                            return;
                        }

                        if (Convert.ToInt32(DTPriorityRows.Rows.Count) == Convert.ToInt32(DTPriorityValue.Rows[0]["VALUE"]) - 1)
                        {
                            int test = 0;
                            List<int> listofValues = new List<int>();
                            for (int i = 0; i < Convert.ToInt32(DTPriorityValue.Rows[0]["VALUE"]) - 1; i++)
                            {
                                test = Convert.ToInt32(DTPriorityRows.DataSet.Tables[0].Rows[i][0]);
                                listofValues.Add(test);
                            }
                            for (int i = 0; i < Convert.ToInt32(DTPriorityValue.Rows[0]["VALUE"]); i--)
                            {
                                if (!listofValues.Contains(i))
                                {
                                    Recruitment_BLL.ShowMessage(this, "Arrange the Priorities in an order");
                                    return;
                                }
                            }
                        }
                        else if (Convert.ToInt32(DTPriorityRows.Rows.Count) == Convert.ToInt32(DTPriorityValue.Rows[0]["VALUE"]))
                        {

                            int test = 0;
                            List<int> listofValues = new List<int>();
                            for (int i = 0; i < Convert.ToInt32(DTPriorityValue.Rows[0]["VALUE"]); i++)
                            {
                                test = Convert.ToInt32(DTPriorityRows.DataSet.Tables[0].Rows[i][0]);
                                listofValues.Add(test);
                            }
                            for (int i = 1; i < Convert.ToInt32(DTPriorityValue.Rows[0]["VALUE"]) + 1; i++)
                            {
                                if (!listofValues.Contains(i))
                                {
                                    Recruitment_BLL.ShowMessage(this, "Arrange the Priorities in an order");
                                    return;
                                }
                            }

                        }

                        //if (Convert.ToInt32(Rcb_Priority.SelectedItem.Value) != Convert.ToInt32(DTPriorityValue.Rows[0]["VALUE"]) + 1)
                        if (Convert.ToInt32(Rtxt_Priority.Text) != Convert.ToInt32(DTPriorityValue.Rows[0]["VALUE"]) + 1)
                        {
                            Recruitment_BLL.ShowMessage(this, "The Priority should be " + (Convert.ToInt32(DTPriorityValue.Rows[0]["VALUE"]) + 1));
                            return;
                        }
                    }

                    _obj_Rec_Interview_Phase_Def.Mode = 10;
                    _obj_Rec_Interview_Phase_Def.Phase_Name = Convert.ToString(Rtxt_PhaseName.Text.Replace("'", "''"));
                    _obj_Rec_Interview_Phase_Def.PHASE_INTERVIEWERNAME = Convert.ToInt32(Rcb_InterviewerName.SelectedItem.Value);

                    if (Convert.ToString(Recruitment_BLL.get_InterviewPhaseDefinition(_obj_Rec_Interview_Phase_Def).Rows[0]["Count"]) != "0")
                    {
                        Recruitment_BLL.ShowMessage(this, "Already this Employee is assigned for this JobRequest");
                        return;
                    }

                    _obj_Rec_Interview_Phase_Def.Mode = 12;
                    DataTable DTPriorityvalue = new DataTable();
                    DTPriorityvalue = Recruitment_BLL.get_InterviewPhaseDefinition(_obj_Rec_Interview_Phase_Def);
                    //if (Convert.ToInt32(Rcb_Priority.SelectedItem.Text) <= Convert.ToInt32(DTPriorityvalue.Rows[0]["VALUE"]))
                    if (Convert.ToInt32(Rtxt_Priority.Text) <= Convert.ToInt32(DTPriorityvalue.Rows[0]["VALUE"]))
                    {
                        Recruitment_BLL.ShowMessage(this, "Arrange the Priorities in an order");
                        return;
                    }

                    _obj_Rec_Interview_Phase_Def.Mode = 8;
                    if (Convert.ToString(Recruitment_BLL.get_InterviewPhaseDefinition(_obj_Rec_Interview_Phase_Def).Rows[0]["Count"]) != "0")
                    {
                        Recruitment_BLL.ShowMessage(this, "Already Final round is Defined");
                        return;
                    }

                    _obj_Rec_Interview_Phase_Def.Mode = 5;

                    if (Convert.ToString(Recruitment_BLL.get_InterviewPhaseDefinition(_obj_Rec_Interview_Phase_Def).Rows[0]["Count"]) != "0")
                    {
                        Recruitment_BLL.ShowMessage(this, "This Combination Already Exists");
                        return;
                    }

                    //To check if given Interview Date(s) is earlier than previous round Date(s)
                    _obj_Rec_Interview_Phase_Def.Mode = 22;
                    if (Recruitment_BLL.IsPhaseExists(_obj_Rec_Interview_Phase_Def))
                    {
                        Recruitment_BLL.ShowMessage(this, "Interview Phase Dates must not be before previous round");
                        return;
                    }


                    _obj_Rec_Interview_Phase_Def.Mode = 1;
                    _obj_Rec_Interview_Phase_Def.PHASE_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    if (Recruitment_BLL.set_InterviewPhaseDefinition(_obj_Rec_Interview_Phase_Def))
                    {
                        _obj_Rec_Interview_Phase_Def.Mode = 15;
                        DataTable dt_findMax = Recruitment_BLL.get_InterviewPhaseDefinition(_obj_Rec_Interview_Phase_Def);
                        if (dt_findMax.Rows.Count > 0)
                        {
                            _obj_Rec_interview_Phase_Def_Skills = new RECRUITMENT_INTERVIEW_PHASE_DEF_SKILLS();
                            _obj_Rec_interview_Phase_Def_Skills.PHASE_DEF_SKILLS_PHASEID = Convert.ToInt32(dt_findMax.Rows[0]["MAX"]);
                            for (int i = 0; i <= rlb_skills.CheckedItems.Count - 1; i++)
                            {
                                _obj_Rec_interview_Phase_Def_Skills.MODE = 14;
                                _obj_Rec_interview_Phase_Def_Skills.PHASE_DEF_SKILLS_SKILLID = Convert.ToInt32(rlb_skills.Items[i].Value);
                                //_obj_Rec_interview_Phase_Def_Skills.PHASE_DEF_SKILLS_CREATEDBY = 1;//##Session Required Here
                                _obj_Rec_interview_Phase_Def_Skills.PHASE_DEF_SKILLS_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                                _obj_Rec_interview_Phase_Def_Skills.PHASE_DEF_SKILLS_CREATEDDATE = DateTime.Now;
                                _obj_Rec_interview_Phase_Def_Skills.PHASE_DEF_SKILLS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                Recruitment_BLL.set_interview_def_skills(_obj_Rec_interview_Phase_Def_Skills);
                            }

                        }

                        Recruitment_BLL.ShowMessage(this, "Information Saved Successfully");
                        sendMail();
                    }
                    else
                    {
                        Recruitment_BLL.ShowMessage(this, "Information Not Saved");
                    }


                    LoadGrid();
                    RG_InterviewPhaseDefinition.DataBind();
                    RMP_InterviewPhaseDefinition.SelectedIndex = 0;

                    break;
                default:
                    break;
            }
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewPhaseDefinition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            ClearControls();
            RMP_InterviewPhaseDefinition.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewPhaseDefinition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    #endregion

    #region Methods Used in Page

    public void LoadGrid()
    {
        try
        {
            DataTable DT = new DataTable();
            _obj_Rec_Interview_Phase_Def = new RECRUITMENT_INTERVIEW_PHASE_DEF();
            _obj_Rec_Interview_Phase_Def.PHASE_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_Rec_Interview_Phase_Def.Mode = 3;
            DT = Recruitment_BLL.get_InterviewPhaseDefinition(_obj_Rec_Interview_Phase_Def);
            RG_InterviewPhaseDefinition.DataSource = DT;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewPhaseDefinition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void ClearControls()
    {
        try
        {
            Rcb_JobRequestId.Items.Clear();
            //Rcb_Skill.Items.Clear();
            //Rcb_Priority.Items.Clear();
            Rtxt_Priority.Text = string.Empty;
            Rcb_BusinessUnit.Items.Clear();
            Rcb_InterviewerName.Items.Clear();
            rcmb_Designation.Items.Clear();
            rcmb_Designation.Text = string.Empty;
            //Rcb_Gradeset.Items.Clear();
            lbl_PhaseId.Text = string.Empty;
            Rtxt_PhaseName.Text = string.Empty;
            Rtxt_PhaseDescription.Text = string.Empty;
            Rtxt_PhaseName.Enabled = true;
            Chk_Final.Checked = false;
            rdtp_interviewtodate.Clear();
            rdtp_interviewfromdate.Clear();
            lbl_InterviewNameCheck.Text = string.Empty;
            rlb_skills.ClearChecked();
            btn_Submit.Visible = false;
            btn_Update.Visible = false;
            ChkStatus = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewPhaseDefinition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void LoadJobRequest()
    {
        try
        {
            _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
            _obj_Rec_JobRequisition.MODE = 12;
            _obj_Rec_JobRequisition.JOBREQ_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_Rec_JobRequisition.JOBREQ_BUSINESSUNIT_ID = Convert.ToInt32(Rcb_BusinessUnit.SelectedItem.Value);
            Rcb_JobRequestId.DataSource = Recruitment_BLL.get_JobRequisition(_obj_Rec_JobRequisition);
            Rcb_JobRequestId.DataValueField = "JOBREQ_ID";
            Rcb_JobRequestId.DataTextField = "JOBREQ_REQCODE";
            Rcb_JobRequestId.DataBind();
            Rcb_JobRequestId.Items.Insert(0, new RadComboBoxItem("Select", "0"));
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewPhaseDefinition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

    }
    protected void LoadJobRequest_Edit()
    {
        try
        {
            _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
            _obj_Rec_JobRequisition.MODE = 24;
            _obj_Rec_JobRequisition.JOBREQ_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_Rec_JobRequisition.JOBREQ_BUSINESSUNIT_ID = Convert.ToInt32(Rcb_BusinessUnit.SelectedItem.Value);
            Rcb_JobRequestId.DataSource = Recruitment_BLL.get_JobRequisition(_obj_Rec_JobRequisition);
            Rcb_JobRequestId.DataValueField = "JOBREQ_ID";
            Rcb_JobRequestId.DataTextField = "JOBREQ_REQCODE";
            Rcb_JobRequestId.DataBind();
            Rcb_JobRequestId.Items.Insert(0, new RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewPhaseDefinition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void LoadSkill()
    {
        try
        {
            rlb_skills.Items.Clear();


            //SMHR_POSITIONS _obj_Smhr_Positions = new SMHR_POSITIONS();
            //_obj_Smhr_Positions.POSITIONS_ID = Convert.ToInt32(rcmb_Designation.SelectedItem.Value);
            //_obj_Smhr_Positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Rec_Interview_Phase_Def = new RECRUITMENT_INTERVIEW_PHASE_DEF();
            _obj_Rec_Interview_Phase_Def.MODE = 20;
            _obj_Rec_Interview_Phase_Def.Phase_POSID = Convert.ToInt32(rcmb_Designation.SelectedItem.Value);
            _obj_Rec_Interview_Phase_Def.PHASE_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //DataTable dt = BLL.get_Positions(_obj_Smhr_Positions);
            DataTable dt = Recruitment_BLL.get_InterviewPhaseDefinition(_obj_Rec_Interview_Phase_Def);

            rlb_skills.DataSource = dt;
            rlb_skills.DataTextField = "HR_MASTER_CODE";
            rlb_skills.DataValueField = "HR_MASTER_ID";
            rlb_skills.DataBind();



        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewPhaseDefinition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }




    protected void LoadBusinessUnit()
    {
        //    //  _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
        //    //_obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
        //    // _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
        //    _obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
        //    _obj_Smhr_BusinessUnit.BUSINESSUNIT_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
        //    _obj_Smhr_BusinessUnit.MODE = 1;
        //    Rcb_BusinessUnit.DataSource = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
        //    Rcb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
        //    Rcb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
        //    Rcb_BusinessUnit.DataBind();
        //    Rcb_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select", "0"));

        try
        {

            //  if (Session["BUSINESSUNIT_ID"] != null)
            // {
            _obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
            _obj_Smhr_BusinessUnit.OPERATION = operation.Select;
            _obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            //_obj_Smhr_BusinessUnit.ISDELETED = true;
            //_obj_Smhr_BusinessUnit.BUSINESSUNIT_ID = Convert.ToInt32(Session["BUSINESSUNIT_ID"].ToString());
            Rcb_BusinessUnit.Items.Clear();
            DataTable dt = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
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
        // }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewPhaseDefinition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

    }

    protected void LoadInterviewName()
    {
        try
        {


            Rcb_InterviewerName.Items.Clear();
            _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
            _obj_Rec_JobRequisition.JOBREQ_ID = Convert.ToInt32(Rcb_JobRequestId.SelectedItem.Value);
            _obj_Rec_JobRequisition.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Rec_JobRequisition.MODE = 17;
            DataTable dt = Recruitment_BLL.get_JobRequisition(_obj_Rec_JobRequisition);
            if (dt.Rows.Count > 0)
            {
                Rcb_InterviewerName.DataSource = dt;
                Rcb_InterviewerName.DataTextField = "EMPLOYEE_NAME";
                Rcb_InterviewerName.DataValueField = "EMPLOYEE_ID";
                Rcb_InterviewerName.DataBind();
                Rcb_InterviewerName.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            }
            else
            {

                Rcb_InterviewerName.DataSource = dt;
                Rcb_InterviewerName.DataBind();
                Rcb_InterviewerName.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewPhaseDefinition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void LoadInterviewName_Edit()
    {
        try
        {
            Rcb_InterviewerName.Items.Clear();
            _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
            _obj_Rec_JobRequisition.JOBREQ_ID = Convert.ToInt32(Rcb_JobRequestId.SelectedItem.Value);
            _obj_Rec_JobRequisition.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Rec_JobRequisition.MODE = 18;
            DataTable dt = Recruitment_BLL.get_JobRequisition(_obj_Rec_JobRequisition);
            if (dt.Rows.Count > 0)
            {
                Rcb_InterviewerName.DataSource = dt;
                Rcb_InterviewerName.DataTextField = "EMPLOYEE_NAME";
                Rcb_InterviewerName.DataValueField = "EMPLOYEE_ID";
                Rcb_InterviewerName.DataBind();
                Rcb_InterviewerName.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            }
            else
            {

                Rcb_InterviewerName.DataSource = dt;
                Rcb_InterviewerName.DataBind();
                Rcb_InterviewerName.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewPhaseDefinition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void LoadPriority()
    {
        try
        {
            //To get priority count
            if (Rcb_JobRequestId.SelectedIndex > 0)
            {
                _obj_Rec_Interview_Phase_Def = new RECRUITMENT_INTERVIEW_PHASE_DEF();
                _obj_Rec_Interview_Phase_Def.Mode = 11;
                _obj_Rec_Interview_Phase_Def.Phase_JobReqID = Convert.ToInt32(Rcb_JobRequestId.SelectedValue);
                _obj_Rec_Interview_Phase_Def.PHASE_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());

                DataTable DT = Recruitment_BLL.get_InterviewPhaseDefinition(_obj_Rec_Interview_Phase_Def);

                if (DT.Rows.Count > 0)
                {
                    Rtxt_Priority.Text = Convert.ToString(Convert.ToInt32(DT.Rows[0]["COUNT"]) + 1);
                }
                else
                {
                    Rtxt_Priority.Text = string.Empty;
                }


            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewPhaseDefinition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    //protected void LoadGrade()
    //{
    //    try
    //    {

    //        _obj_Smhr_Masters = new SMHR_MASTERS();
    //        _obj_Smhr_Masters.OPERATION = operation.Select;
    //        _obj_Smhr_Masters.MASTER_TYPE = "INTERVIEW ROUNDS";
    //        _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //        Rcb_Gradeset.DataSource = BLL.get_MasterRecords(_obj_Smhr_Masters);
    //        Rcb_Gradeset.DataTextField = "HR_MASTER_CODE";
    //        Rcb_Gradeset.DataValueField = "HR_MASTER_ID";
    //        Rcb_Gradeset.DataBind();
    //        Rcb_Gradeset.Items.Insert(0, new RadComboBoxItem("Select", "0"));
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewPhaseDefinition", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //        return;
    //    }
    //}

    private void LoadPositions()
    {

        try
        {


            Rcb_InterviewerName.Items.Clear();
            _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
            _obj_Rec_JobRequisition.JOBREQ_ID = Convert.ToInt32(Rcb_JobRequestId.SelectedItem.Value);
            _obj_Rec_JobRequisition.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Rec_JobRequisition.MODE = 19;
            DataTable dt = Recruitment_BLL.GetPosition(_obj_Rec_JobRequisition);
            if (dt.Rows.Count > 0)
            {
                rcmb_Designation.DataSource = dt;
                rcmb_Designation.DataTextField = "POSITIONS_CODE";
                rcmb_Designation.DataValueField = "POSITIONS_ID";
                rcmb_Designation.DataBind();
            }


        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewPhaseDefinition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void rcmb_Designation_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
    }

    #endregion

    #region LinkButton Click Event

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            ClearControls();
            //   LoadJobRequest();
            LoadBusinessUnit();
            //LoadPositions();
            // LoadInterviewName();
            //LoadGrade();
            //LoadPriority();
            btn_Submit.Visible = true;
            btn_Update.Visible = false;
            Rcb_JobRequestId.Enabled = true;
            Rcb_BusinessUnit.Enabled = true;
            RMP_InterviewPhaseDefinition.SelectedIndex = 1;
            Rcb_JobRequestId.Items.Insert(0, new RadComboBoxItem("", ""));
            Rcb_InterviewerName.Items.Insert(0, new RadComboBoxItem("", ""));
            rlb_skills.Items.Clear();

            rdtp_interviewfromdate.MinDate = DateTime.Now;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewPhaseDefinition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            //   ClearControls();
            //  LoadJobRequest();
            //    LoadBusinessUnit();
            //     LoadGrade();


            _obj_Rec_Interview_Phase_Def = new RECRUITMENT_INTERVIEW_PHASE_DEF();


            _obj_Rec_Interview_Phase_Def.Mode = 4;
            _obj_Rec_Interview_Phase_Def.Phase_ID = Convert.ToInt32(e.CommandArgument);
            _obj_Rec_Interview_Phase_Def.PHASE_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());

            DataTable DT = Recruitment_BLL.get_InterviewPhaseDefinition(_obj_Rec_Interview_Phase_Def);

            if (DT.Rows.Count != 0)
            {
                lbl_PhaseId.Text = Convert.ToString(DT.Rows[0]["PHASE_ID"]);
                //  Rcb_JobRequestId.SelectedIndex = Rcb_JobRequestId.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["PHASE_JOBREQID"]));
                Rtxt_PhaseName.Text = Convert.ToString(DT.Rows[0]["PHASE_NAME"]);
                Rtxt_PhaseDescription.Text = Convert.ToString(DT.Rows[0]["PHASE_DESC"]);
                Chk_Final.Checked = Convert.ToBoolean(DT.Rows[0]["PHASE_FINAL"]);
                ChkStatus = Convert.ToBoolean(DT.Rows[0]["PHASE_FINAL"]);
                Rcb_JobRequestId.Enabled = false;
                Rcb_BusinessUnit.Enabled = false;
                if (DT.Rows[0]["Phase_InterviewFromDate"] != System.DBNull.Value)
                {
                    rdtp_interviewfromdate.SelectedDate = Convert.ToDateTime(DT.Rows[0]["Phase_InterviewFromDate"]);
                }
                if (DT.Rows[0]["Phase_InterviewToDate"] != System.DBNull.Value)
                {
                    rdtp_interviewtodate.SelectedDate = Convert.ToDateTime(DT.Rows[0]["Phase_InterviewToDate"]);
                }
                Rtxt_PhaseName.Enabled = false;

                LoadBusinessUnit();
                Rcb_BusinessUnit.SelectedIndex = Rcb_BusinessUnit.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["PHASE_BUSINESSUNIT"]));
                LoadJobRequest();
                Rcb_JobRequestId.SelectedIndex = Rcb_JobRequestId.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["PHASE_JOBREQID"]));
                LoadPositions();
                rcmb_Designation.SelectedIndex = rcmb_Designation.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["PHASE_POSCODE"]));
                LoadSkill();
                rlb_skills.SelectedIndex = rlb_skills.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["PHASE_SKILL"]));
                LoadInterviewName();
                Rcb_InterviewerName.SelectedIndex = Rcb_InterviewerName.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["PHASE_INTERVIEWERNAME"]));
                lbl_InterviewNameCheck.Text = Convert.ToString(DT.Rows[0]["PHASE_INTERVIEWERNAME"]);
                //LoadPriority();
                //Rcb_Priority.SelectedIndex = Rcb_Priority.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["PHASE_PRIORITY"]));
                Rtxt_Priority.Text = Convert.ToString(DT.Rows[0]["PHASE_PRIORITY"]);
                lbl_PriorityValue.Text = Convert.ToString(DT.Rows[0]["PHASE_PRIORITY"]);
                //LoadGrade();
                // Rcb_Gradeset.SelectedIndex = Rcb_Gradeset.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["PHASE_GRADESET"]));
                _obj_Rec_Interview_Phase_Def = new RECRUITMENT_INTERVIEW_PHASE_DEF();
                _obj_Rec_Interview_Phase_Def.Mode = 17;
                _obj_Rec_Interview_Phase_Def.Phase_ID = Convert.ToInt32(lbl_PhaseId.Text);
                DataTable dt_skillid = Recruitment_BLL.get_InterviewPhaseDefinition(_obj_Rec_Interview_Phase_Def);
                if (dt_skillid.Rows.Count > 0)
                {
                    for (int a = 0; a <= rlb_skills.Items.Count - 1; a++)
                    {
                        for (int b = 0; b <= dt_skillid.Rows.Count - 1; b++)
                        {
                            if (dt_skillid.Rows[b]["PHASE_DEF_SKILLS_SKILLID"] != System.DBNull.Value)
                            {
                                if (rlb_skills.Items[a].Value == Convert.ToString(dt_skillid.Rows[b]["PHASE_DEF_SKILLS_SKILLID"]))
                                {
                                    rlb_skills.Items[a].Checked = Convert.ToBoolean(dt_skillid.Rows[b]["PHASE_DEF_SKILLS_SKILLID"]);
                                }

                            }

                        }

                    }


                }
            }
            btn_Submit.Visible = false;
            btn_Update.Visible = true;
            RMP_InterviewPhaseDefinition.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewPhaseDefinition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    #endregion

    #region ComboBox Selected Index Changed Event

    protected void Rcb_JobRequestId_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (Rcb_JobRequestId.SelectedIndex > 0)
            {
                LoadRequisitionDate();
                LoadPositions();
                LoadSkill();
                LoadInterviewName();
                LoadPriority();
                rcmb_Designation.Enabled = false;

            }
            else
            {
                Rcb_InterviewerName.ClearSelection();
                Rcb_InterviewerName.Items.Clear();
                Rcb_InterviewerName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                rlb_skills.Items.Clear();
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewPhaseDefinition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void LoadRequisitionDate()
    {
        try
        {
            if (Rcb_JobRequestId.SelectedIndex > 0)
            {
                _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
                _obj_Rec_JobRequisition.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Rec_JobRequisition.JOBREQ_ID = Convert.ToInt32(Rcb_JobRequestId.SelectedValue);
                _obj_Rec_JobRequisition.MODE = 25;
                DateTime dtRequisition = Recruitment_BLL.getRequisitionCreatedDate(_obj_Rec_JobRequisition);
                rdtp_interviewfromdate.MinDate = dtRequisition;
                rdtp_interviewtodate.MinDate = dtRequisition;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewPhaseDefinition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Rcb_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (Rcb_BusinessUnit.SelectedIndex > 0)
            {
                //LoadInterviewName();
                LoadJobRequest();
            }
            else
            {
                Rcb_JobRequestId.ClearSelection();
                Rcb_JobRequestId.Items.Clear();
                Rcb_JobRequestId.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
            Rcb_InterviewerName.ClearSelection();
            Rcb_InterviewerName.Items.Clear();
            Rcb_InterviewerName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            rlb_skills.Items.Clear();

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewPhaseDefinition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }


    public void sendMail()
    {
        try
        {
            _obj_PMS_getemployee = new PMS_GETEMPLOYEE();
            _obj_PMS_getemployee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_PMS_getemployee.EMP_ID = Convert.ToInt32(Rcb_InterviewerName.SelectedItem.Value);
            _obj_PMS_getemployee.Mode = 6;
            DataTable dt_emp = Pms_Bll.get_RMEmployees(_obj_PMS_getemployee);

            _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
            _obj_Rec_JobRequisition.JOBREQ_ID = Convert.ToInt32(Rcb_JobRequestId.SelectedItem.Value);
            _obj_Rec_JobRequisition.MODE = 27;
            DataTable dt = Recruitment_BLL.get_JobRequisition(_obj_Rec_JobRequisition);

            string name = string.Empty;
            string[] temp = Convert.ToString(dt_emp.Rows[0]["EMP_NAME"]).Split(new char[] { '-' });
            if (temp.Length > 1)
            {
                name = temp[0];
            }
            if (dt.Rows.Count != 0 && dt_emp.Rows.Count != 0)
            //if(dt_emp.Rows.Count != 0) 
            {
                if (Convert.ToString(dt_emp.Rows[0]["EMP_EMAIL"]) != string.Empty
                                   && Convert.ToString(dt.Rows[0]["RAISEDBY_EMAIL"]) != string.Empty)
                //if (Convert.ToString(dt_emp.Rows[0]["EMP_EMAIL"]) != string.Empty)
                {

                    CultureInfo newCulture = (CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
                    newCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
                    newCulture.DateTimeFormat.DateSeparator = "/";
                    Thread.CurrentThread.CurrentCulture = newCulture;
                    string fromdate = Convert.ToDateTime(rdtp_interviewfromdate.SelectedDate).ToShortDateString();
                    string todate = Convert.ToDateTime(rdtp_interviewtodate.SelectedDate).ToShortDateString();
                    //string time = rtp_InterviewTime.SelectedDate.Value.ToShortTimeString();

                    string toAddress, subject, body, ccAddress;
                    toAddress = (Convert.ToString(dt_emp.Rows[0]["EMP_EMAIL"]));
                    //msgMail.CC.Add(Convert.ToString(dt.Rows[0]["HRSTAFF_EMAIL"]));
                    ccAddress = (Convert.ToString(dt.Rows[0]["RAISEDBY_EMAIL"]));
                    subject = "Interview Alined";
                    body = "<!DOCTYPE html>" +
                                    "<html>" +
                                    "<html>" +
                                    "<head>" +
                                    "<title>Title of the document</title>" +
                                    "<style>" +
                                    "table {'" +
                                        "'margin-left: 25px;'" +
                                    "}'" +
                                    "</style>" +
                                    "</head>" +
                                    "<body> " +
                                    "</div>" +
                                    "<div style='width:400px;height:20px; '>" +
                                    "<p>Dear " + name + ", </p> " +
                                    "</div>" +
                                    "<p>You are being scheduled as a interviewer for the following interview. <br>" +
                                    "</p> " +
                                    "<div style='margin-top:-12px;float:left;'>" +
                                    "<table  border='1' bordercolor='#00000' cellpadding='0' cellspacing='0' width=95%>" +
                                    "<tr>" +
                                    "<p> <th nowrap Style='text-align:left; border-style:solid; border-width:2px; border-collapse:collapse; '> &#32; Resource Requisition &nbsp; </th><td Style='border-style:solid; border-width:2px; border-collapse:collapse;'> &#32; " + Convert.ToString(Rcb_JobRequestId.SelectedItem.Text) + " </td></p></tr> " +
                                    "<tr>" +
                                    "<p><th Style='text-align:left; border-style:solid; border-width:2px; border-collapse:collapse;'>&#32; Position &#32;  </th><td Style='border-style:solid; border-width:2px; border-collapse:collapse;'> &#32; " + Convert.ToString(rcmb_Designation.SelectedItem.Text) + "</td></p></tr> " +
                                    "<tr>" +
                                    "<p><th Style='text-align:left; border-style:solid; border-width:2px;'>&#32; Interview Date &#32;  </th><td Style='border-style:solid; border-width:2px;'> &#32; " + fromdate + "&#32; to &#32;" + todate + "</td></p></tr>" +
                        //"<tr>" +
                        //"<p><th  Style='text-align:left; border-style:solid; border-width:2px;'>&#32;  Interview Time &#32;  </th><td Style='border-style:solid; border-width:2px;'> &#32;</td></p></tr>" +
                                    "</table>" +
                                    "</div>" +
                                     "</p> " +
                                    "<p> Regards,<br/>" +
                                    "Smart HR</p>" +
                                    "</body>" +
                                    " </html>";
                    BLL.SendMail(toAddress, ccAddress, subject, body);
                    BLL.ShowMessage(this, "Notification Has Been Sent.");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Test", "<script type='text/javascript'>Close()</" + "script>", false);
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewPhaseDefinition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    #endregion

    protected void QuestionRadListBox_ItemCheck(object sender, Telerik.Web.UI.RadListBoxItemEventArgs e)
    {

    }
            
    protected void rdtp_interviewfromdate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        try
        {
            if (rdtp_interviewfromdate.SelectedDate != null)
                rdtp_interviewtodate.MinDate = Convert.ToDateTime(rdtp_interviewfromdate.SelectedDate);
            else
                rdtp_interviewtodate.Clear();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewPhaseDefinition", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
}