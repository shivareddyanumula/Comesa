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

public partial class Recruitment_frm_recruit_offerletter : System.Web.UI.Page
{
    #region References

    SMHR_JOBOFFERS _obj_Smhr_joboffers;

    #endregion

    #region Variables

    string AppName, Name, TodayDate = "";
    string body;
    
    #endregion

    #region PageLoad

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Title = "Smart HR - HR & Payroll Management System";
            if (!Page.IsPostBack)
            {
                if (Session["Applicant"].ToString() != "")
                {
                    LoadData();
                }
                else
                {
                    string strContent = "Please Choose Applicant on Job Offer Letter Screen or else Applicant not yet offered";
                    //EditorOffer.Content = strContent;
                    //EditorOffer.Enabled = false;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_recruit_offerletter", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region LoadData

    private void LoadData()
    {
        try
        {
            TodayDate = System.DateTime.Now.ToLongDateString();
            DataTable dtDet = new DataTable();
            _obj_Smhr_joboffers = new SMHR_JOBOFFERS();
            _obj_Smhr_joboffers.APPLICANT_ID = Convert.ToInt32(Session["Applicant"].ToString());
            dtDet = BLL.GetApplicantDetails(_obj_Smhr_joboffers);
            if (dtDet.Rows.Count != 0)
            {
                AppName = dtDet.Rows[0][2].ToString() + " " + dtDet.Rows[0][3].ToString() + " " + dtDet.Rows[0][4].ToString() + " " + dtDet.Rows[0][5].ToString();
                Name = dtDet.Rows[0][3].ToString();
            }
            body = "<html> " +
                   "<head> " +
                   "</head> " +
                   "<body> " +
                   "<table style='width: 640px' border='0' cellspacing='0' cellpadding='0'> " +
                   "<tr> " +
                   "<td colspan='3'> " +
                   "     <strong><span style='font-size: 10pt; font-family: Arial'>Ph no: 040 30586061 &nbsp; " +
                   "         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; " +
                   "         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; " +
                   "         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; " +
                   "        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Fax No : 040 30586064</span></strong></td> " +
                   "</tr> " +
                   "<tr> " +
                   "<td style='width: 95px'> " +
                   "</td> " +
                   "<td rowspan='2' style='width: 9px; text-align: left'> " +
                   "<img src='EmpUploads/54_LOGO_DHANUSH.png' /></td> " +
                   "<td> " +
                   "</td> " +
                   "</tr> " +
                   "<tr> " +
                   "<td style='width: 95px'> " +
                   "</td> " +
                   "<td> " +
                   "</td> " +
                   "</tr> " +
                   "<tr> " +
                   "<td colspan='3'> " +
                   "<hr /> " +
                   "</td> " +
                   "</tr> " +
                   "<tr> " +
                   "<td style='width: 95px'> " +
                   "</td> " +
                   "<td style='width: 9px'> " +
                   "</td> " +
                   "<td> " +
                   "</td> " +
                   "</tr> " +
                   "<tr> " +
                   " <td colspan='2'> " +
                   "     <span style='font-size: 10pt; font-family: Arial'><strong>&nbsp;Date : " + TodayDate.ToString() + " </strong></span></td> " +
                   " <td> " +
                   " </td> " +
                   " </tr> " +
                   " <tr> " +
                    "    <td style='width: 95px'> " +
                     "   </td> " +
                     "   <td style='width: 9px'> " +
                     "   </td> " +
                     "   <td> " +
                     "   </td> " +
                    "</tr> " +
                   " <tr> " +
                    "    <td style='width: 95px'> " +
                    "        <strong><span style='font-size: 10pt; font-family: Arial'>&nbsp;To,</span></strong></td> " +
                    "    <td> " +

                    "    </td> " +
                    "    <td> " +

                    "    </td> " +
                    "</tr> " +
                    "<tr> " +
                     "   <td colspan='2' rowspan='4'> " +
                      "<strong><span style='font-size: 10pt; font-family: Arial'> " + AppName.ToString() + "<br/> " +
                    " Hyderabad, Andhra Pradesh. <br/><br/><br/> </span></strong>" +
                     "   </td> " +
                      "  <td>" +
                      "  </td> " +
                    "</tr> " +
                    "<tr> " +
                    "    <td> " +
                     "   </td> " +
                   " </tr> " +
                   " <tr> " +
                    "    <td> " +
                    "    </td> " +
                    "</tr> " +
                    "<tr> " +
                     "   <td> " +
                    "    </td> " +
                    "</tr> " +
                    "<tr> " +
                    "    <td style='width: 95px'> " +
                    "    </td> " +
                    "    <td style='width: 9px'> " +
                    "    </td> " +
                    "    <td> " +
                    "    </td> " +
                    "</tr> " +
                    "<tr> " +
                     "   <td colspan='2'> " +
                    "        <strong><span style='font-size: 10pt; font-family: Arial'>&nbsp;Dear " + Name.ToString() + " </span></strong> " +
                     "   </td> " +
                     "   <td> " +
                     "   </td> " +
                    "</tr> " +
                    "<tr> " +
                     "   <td colspan='2'> " +
                      "      <strong><span style='font-size: 10pt; font-family: Arial'>&nbsp;Sub : Offer Letter</span></strong></td> " +
                      "  <td> " +
                      "  </td> " +
                    "</tr> " +
                    "<tr> " +
                     "   <td colspan='2' rowspan='2'> " +
                      "      <br /> " +
                       "     <br /> " +
                       " </td> " +
                       " <td> " +
                       " </td> " +
                    "</tr> " +
                    "<tr> " +
                     "   <td> " +
                      "  </td> " +
                    "</tr> " +
                    "<tr> " +
                    "<td colspan='3' rowspan='2' style='height: 186px; text-align: justify'> " +
                     "   <strong><span style='font-size: 10pt; font-family: Arial'>It is our pleasure to extend " +
                      "      a job offer to you as an Associate Consultant. Your Monthly CTC will be in Indian " +
                       "     Rupees Rs. 10000 only and is subject to all required taxes and withholding.<br /> " +
                        "    <br /> " +
                        "    You will also be entitled to benefits extended by Dhanush InfoTech Pvt Ltd.<br /> " +
                        "    <br /> " +
                        "    We would like you to start work from&nbsp; onwards. You will be workin from our " +
                       "     Hyderabad Office.<br /> " +
                        "    <br /> " +
                         "   Please review the job offer letter, and if you decide to accept the offer, give " +
                          "  us a signed " +
                         "   <br /> " +
                        "    acknowledgement of your acceptance. Before you begin work, you will also be required " +
                       "     to sign a<br /> " +
                  "          Standard employment letter.<br /> " +
                   "         <br /> " +
                    "        We Look forward to you joining the company and become a productive member of the " +
                       "     team.</span></strong></td> " +
              "  </tr> " +
              "  <tr> " +
              "  </tr> " +
              "  <tr> " +
                   " <td style='width: 95px'> " +
                     "   <br /> " +
                    "    <br /> " +
                   " </td> " +
                   " <td style='width: 9px'> " +
                  "  </td> " +
                 "   <td> " +
                "    </td> " +
               " </tr> " +
                "<tr> " +
                   " <td style='width: 95px'> " +
                   "     <strong><span style='font-size: 10pt; font-family: Arial'>Sincerely,</span></strong></td> " +
             " <td style='width: 9px'> " +
                " </td> " +
                  "  <td> " +
                 "   </td> " +
                "</tr> " +
                "<tr> " +
                   " <td style='width: 95px'> " +
                   " </td> " +
                   " <td style='width: 9px'> " +
                   " </td> " +
                  "  <td> " +
                 "   </td> " +
                "</tr> " +
                "<tr> " +
                "    <td style='width: 95px'> " +
               "         <strong><span style='font-size: 10pt; font-family: Arial'>HR Manager</span></strong></td> " +
              "      <td style='width: 9px'> " +
             "       </td> " +
            "        <td> " +
           "         </td> " +
          "      </tr> " +
                "   </table> " +
                    "</div> " +
                    "</body> " +
                    "</html>";
            EditorOffer.Content = body;

            //  ContentBody.InnerHtml = body; 

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_recruit_offerletter", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
     #endregion

}
