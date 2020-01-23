using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using Telerik.Web.UI;
using System.ComponentModel;
using System.Collections.Generic;
using System.Net.Mail;

namespace SMHR
{
    // ----------------------------------------------------------------------------------------
    // Author:                    Dinesh
    // Company:                   Dhanush InfoTech Pvt Ltd
    // Date:                      01/11/2013
    // Filename:                  SMHR_KNA_1.cs
    // Class FullName:            SMHR.BLL
    // Class Name:                BLL
    // Class Kind Description:    Class
    // Purpose:                   Business Logic Layer
    // Developer:                 Anand
    // ----------------------------------------------------------------------------------------
    public partial class BLL
    {
        public static DataTable get_EmpLoanDeposits(SMHR_LOANTRANS _obj_smhr_loanTrans)
        {
            try
            {

                if (_obj_smhr_loanTrans.OPERATION == operation.Get)
                {
                    return ExecuteQuery("EXEC USP_LoanDeposits @Operation = 'Get', @EMPLOYEEID = '" + _obj_smhr_loanTrans.LOANTRANS_EMP_ID + "'");
                }
                else if (_obj_smhr_loanTrans.OPERATION == operation.Check1)
                {
                    return ExecuteQuery("EXEC USP_LoanDeposits @Operation = 'Check1',@EMPLOYEEID = '" + _obj_smhr_loanTrans.LOANTRANS_EMP_ID + "', @LOANTRANS_LOANTYPE_ID = '" + _obj_smhr_loanTrans.LOANTRANS_LOANTYPE_ID + "'");
                }
                else if (_obj_smhr_loanTrans.OPERATION == operation.Select)
                {
                    if (_obj_smhr_loanTrans.LOANTRANS_EMP_ID != 0)

                        return ExecuteQuery("EXEC USP_LoanDeposits @Operation = 'Select',@EMPLOYEEID = '" + _obj_smhr_loanTrans.LOANTRANS_EMP_ID + "', @OrganisationId = '" + _obj_smhr_loanTrans.ORGANISATION_ID + "'");
                    else
                        return ExecuteQuery("EXEC USP_LoanDeposits @Operation = 'Select', @OrganisationId = '" + _obj_smhr_loanTrans.ORGANISATION_ID + "'");
                }
                else if (_obj_smhr_loanTrans.OPERATION == operation.Select_New)
                {
                    return ExecuteQuery("EXEC USP_LoanDeposits @Operation = 'Select_New', @LoanTransId = '" + _obj_smhr_loanTrans.LOANTRANS_ID + "'");
                }
                else if(_obj_smhr_loanTrans.OPERATION == operation.Check_New)
                {
                    return ExecuteQuery("EXEC USP_LoanDeposits @Operation = 'Check_New', @DepositsId= '" + _obj_smhr_loanTrans.DepositsId + "'");
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                //throw (ex);
                SMHR.BLL.Error_Log(HttpContext.Current.Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "SMHR_KNA_3", ex.StackTrace, DateTime.Now);
                HttpContext.Current.Response.Redirect("~/Frm_ErrorPage.aspx");
                return null;
            }


        }
        public static bool set_LoanDeposits(SMHR_LOANTRANS _obj_smhr_loanTrans)
        {
            bool status = false;
            if (_obj_smhr_loanTrans.OPERATION == operation.Insert)
            {
                if (ExecuteNonQuery("EXEC USP_LoanDeposits @Operation ='Insert',@EmpId='" + _obj_smhr_loanTrans.LOANTRANS_EMP_ID +
                    "',@BusinessUnitId='" + _obj_smhr_loanTrans.BUSINESSUNIT_ID + "',@OrganisationId='" + _obj_smhr_loanTrans.ORGANISATION_ID +
                    "',@LoanNo='" + _obj_smhr_loanTrans.LOANTRANS_LOANNO + "',@LoanTypeId='" + _obj_smhr_loanTrans.LOANTRANS_LOANTYPE_ID +
                    "',@LoanTransId='" + _obj_smhr_loanTrans.LOANTRANS_ID + "',@DepositAmount='" + _obj_smhr_loanTrans.LOANTRANS_LOANAMOUNT +
                    "',@CreatedDate='" + _obj_smhr_loanTrans.CREATEDDATE + "',@CreatedBy='" + _obj_smhr_loanTrans.CREATEDBY +
                    "',@UpdatedLoanAmt='" + _obj_smhr_loanTrans.UpdatedLoanAmt +
                    "',@AccumulativeBal='" + _obj_smhr_loanTrans.AccumulativeBalance + "'"))
                    status = true;
                else
                    status = false;

            }
            return status;
        }
        ///// <summary>
        /// 
        /// </summary>
        /// <param name="toAddress"></param>
        /// <param name="ccAddress"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        public static void SendMail(string toAddress, string ccAddress, string subject, string body)
        {
            try
            {
                
                //MailMessage msgMail = new MailMessage();
                //msgMail.To.Add(toAddress);
                //if (!string.IsNullOrEmpty(ccAddress))
                //    msgMail.CC.Add(ccAddress);
                //msgMail.IsBodyHtml = true;
                //msgMail.Subject = subject;
                //msgMail.Body = body;
                ////msgMail.From = new MailAddress("smarthr@parliament.go.ke", "Smart HR");
                ////msgMail.From = new MailAddress("smtpmail@dhanushinfotech.com", "Smart HR");
                ////msgMail.From = new MailAddress(ConfigurationManager.AppSettings["FromMailId"]), "Smart HR");
                //msgMail.From = new MailAddress(ConfigurationManager.AppSettings["FromMailId"], "Smart HR");

                //SmtpClient smtpC = new SmtpClient();
                //smtpC.Host = Convert.ToString(ConfigurationManager.AppSettings["MAIL_HOST"]);
                //smtpC.Port = Convert.ToInt32(ConfigurationManager.AppSettings["MAIL_PORT"]);
                //smtpC.EnableSsl = true;
                //smtpC.Credentials = new System.Net.NetworkCredential(Convert.ToString(ConfigurationManager.AppSettings["MAIL_ID"]), Convert.ToString(ConfigurationManager.AppSettings["MAIL_PWD"]));
                //smtpC.Send(msgMail);
            }
            catch (Exception ex)
            {
                //throw (ex);
                SMHR.BLL.Error_Log(HttpContext.Current.Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "SMHR_KNA_3", ex.StackTrace, DateTime.Now);
                HttpContext.Current.Response.Redirect("~/Frm_ErrorPage.aspx");
                return;
            }


        }
    }
}
