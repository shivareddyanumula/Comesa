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
using SMHR;

namespace RECRUITMENT
{
    // ----------------------------------------------------------------------------------------
    // Author:                    Dhanush InfoTech Pvt Ltd
    // Company:                   Dhanush InfoTech Pvt Ltd
    // Assembly version:          
    // Date:                      02/18/2011
    // Time:                      16:29
    // Project Filename:          
    // Project Item Name:         Recruitment_BLL
    // Project Item Filename:     
    // Project Item Kind:         Code
    // Class FullName:            
    // Class Name:                Recruitment_BLL
    // Class Kind Description:    Class
    // Purpose:                   Business Logic Layer
    // ----------------------------------------------------------------------------------------

    /// <summary>
    /// Summary description for Recruitment_BLL
    /// </summary>

    public class Recruitment_BLL
    {
        public Recruitment_BLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region RECRUITMENT_GENERAL_METHODS

        public static void ShowMessage(Control ctrl, string Msg)
        {
            ScriptManager.RegisterStartupScript(ctrl, ctrl.GetType(), Guid.NewGuid().ToString(), "alert('" + Msg + "');", true);
        }

        public static string ReplaceQuote(string str)
        {
            return str.Replace("'", "''");
        }

        public static void SetCulture_Theme(Page page, HttpRequest request)
        {
            if (((System.Web.UI.TemplateControl)(page)).AppRelativeVirtualPath.ToUpper() != "~/LOGIN.ASPX")
            {
                if (page.Session["USER_ID"] == null)
                {
                    page.Response.Redirect("~/LOGIN.ASPX", false);
                    return;
                }
                if (page.Session["ORG_ID"] == null)
                {
                    page.Response.Redirect("~/LOGIN.ASPX", false);
                    return;
                }
            }
        }

        public static DataTable ExecuteQuery(string Query)
        {
            return Dal.ExecuteQuery(Query);
        }

        //public static DataTable ExecuteQuery_1(string Query)
        //{
        //    return Dal.ExecuteQuery_1(Query);
        //}

        public static bool ExecuteNonQuery(string Query)
        {
            return Dal.ExecuteNonQuery(Query);
        }

        public static string DateFormat(string UserId)
        {
            return Convert.ToString(ExecuteQuery("EXEC USP_SMHR_SECURITY @Operation ='DATE', @USERTYPE='" + UserId + "'").Rows[0]["DATEFORMAT"]);
        }

        public static void ChangeDateFormat(string UserId, params Telerik.Web.UI.RadDatePicker[] controls)
        {
            string TFormat = DateFormat(UserId);
            foreach (Telerik.Web.UI.RadDatePicker item in controls)
            {
                item.DateInput.DateFormat = TFormat;
            }
        }

        public static void gridDateFormat(string UserId, Telerik.Web.UI.RadGrid Grid, params string[] Columns)
        {
            foreach (string item in Columns)
            {
                ((GridBoundColumn)Grid.MasterTableView.GetColumn(item)).DataFormatString = "{0:" + BLL.DateFormat(UserId) + "}";
            }
        }

        public static void Error_Log(string ID, string Method_Name, string Message, string fname, string Trace_Name, DateTime Dt)
        {
            try
            {
                Dal.ExecuteNonQuery("INSERT INTO [ERROR_LOG]([LOG_USER_ID],[LOG_METHOD_NAME],[LOG_MESSAGE],[LOG_FORM_ERROR_DESC],[LOG_TRACE_DESC],[LOG_DATE]) " +
                    " VALUES ('" + ID + "','" + Method_Name + "','" + Message + "','" + fname + "','" + Trace_Name + "','" + Dt.ToString("MM/dd/yyyy") + "')");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable get_Business_Units(SMHR_LOGININFO _obj_LoginInfo)
        {
            return Dal.ExecuteQuery("EXEC USP_SMHR_ORG_BUSINESSUNIT @ORGANISATION_ID = '" + _obj_LoginInfo.ORGANISATION_ID + "'" +
                                    ",@USER_ID = '" + _obj_LoginInfo.LOGIN_ID + "'");
        }

        #endregion

        #region RECRUITMENT_APPLICANTGRADE

        public static DataTable get_ApplicantGrade(RECRUITMENT_APPLICANTGRADE _obj_Rec_ApplicantGrade)
        {
            DataTable dt = new DataTable();

            if (_obj_Rec_ApplicantGrade.MODE == 1)
            {
                dt = ExecuteQuery("Exec USP_SMHR_APPLICANTGRADE @MODE = '" + _obj_Rec_ApplicantGrade.MODE + "',@APPGRADE_NAME ='" + _obj_Rec_ApplicantGrade.APPGRADE_NAME + "'");
            }
            else if (_obj_Rec_ApplicantGrade.MODE == 4)
            {
                dt = ExecuteQuery("Exec USP_SMHR_APPLICANTGRADE @MODE = '" + _obj_Rec_ApplicantGrade.MODE + "',@APPGRADE_NAME ='" + _obj_Rec_ApplicantGrade.APPGRADE_NAME + "',@APPGRADE_SETID ='" + _obj_Rec_ApplicantGrade.APPGRADE_SETID + "'");

            }
            else if (_obj_Rec_ApplicantGrade.MODE == 5)
            {
                dt = ExecuteQuery("Exec USP_SMHR_APPLICANTGRADE @MODE =  '" + _obj_Rec_ApplicantGrade.MODE + "',@APPLGRADE_ORGANISATION_ID = '" + _obj_Rec_ApplicantGrade.ORGANISATION_ID + "'");
            }
            else if (_obj_Rec_ApplicantGrade.MODE == 6)
            {
                dt = ExecuteQuery("Exec USP_SMHR_APPLICANTGRADE @MODE = '" + _obj_Rec_ApplicantGrade.MODE + "',@APPLGRADE_ID = '" + _obj_Rec_ApplicantGrade.APPLGRADE_ID + "'");
            }
            return dt;
        }

        public static bool set_ApplicantGrade(RECRUITMENT_APPLICANTGRADE _obj_Rec_ApplicantGrade)
        {
            bool status = false;
            switch (_obj_Rec_ApplicantGrade.MODE)
            {
                case 2:

                    if (ExecuteNonQuery("EXEC USP_SMHR_APPLICANTGRADE @MODE = '2', @APPGRADE_SETID = '" + _obj_Rec_ApplicantGrade.APPGRADE_SETID
                                      + "', @APPGRADE_NAME = '" + _obj_Rec_ApplicantGrade.APPGRADE_NAME
                                      + "', @APPLGRADE_DESCRIPTION = '" + _obj_Rec_ApplicantGrade.APPLGRADE_DESCRIPTION
                                      + "', @APPLGRADE_ORGANISATION_ID = '" + _obj_Rec_ApplicantGrade.ORGANISATION_ID
                                      + "', @APPLGRADE_CREATEDBY = " + Convert.ToString(_obj_Rec_ApplicantGrade.APPLGRADE_CREATEDBY)
                                      + " , @APPLGRADE_CREATEDDATE ='" + _obj_Rec_ApplicantGrade.APPLGRADE_CREADTEDATE.ToString("MM/dd/yyyy")
                                      + "', @APPLGRADE_LASTMDFBY =" + Convert.ToString(_obj_Rec_ApplicantGrade.APPLGRADE_LASTMDFBY)
                                      + " , @APPLGRADE_LASTMDFDATE ='" + _obj_Rec_ApplicantGrade.APPLGRADE_LASTMDFDATE.ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case 3:
                    if (ExecuteNonQuery("EXEC USP_SMHR_APPLICANTGRADE @MODE = '3', @APPLGRADE_ID ='" + _obj_Rec_ApplicantGrade.APPLGRADE_ID
                                        + "', @APPGRADE_SETID = '" + _obj_Rec_ApplicantGrade.APPGRADE_SETID
                                        + "', @APPGRADE_NAME = '" + _obj_Rec_ApplicantGrade.APPGRADE_NAME
                                        + "', @APPLGRADE_DESCRIPTION = '" + _obj_Rec_ApplicantGrade.APPLGRADE_DESCRIPTION
                                        + "', @APPLGRADE_ORGANISATION_ID = '" + _obj_Rec_ApplicantGrade.ORGANISATION_ID
                                        + "', @APPLGRADE_LASTMDFBY =" + Convert.ToString(_obj_Rec_ApplicantGrade.APPLGRADE_LASTMDFBY)
                                        + " , @APPLGRADE_LASTMDFDATE ='" + _obj_Rec_ApplicantGrade.APPLGRADE_LASTMDFDATE.ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;
                    break;

                default:
                    break;
            }
            return status;
        }
        #endregion

        #region RECRUITMENT_APPROVALPROCESS

        public static DataTable get_EmpSetup(RECRUITMENT_APPROVALPROCESS _obj_Rec_ApprovalProcess)
        {
            DataTable dt = new DataTable();
            switch (_obj_Rec_ApprovalProcess.Mode)
            {

                case 1:
                    dt = ExecuteQuery("EXEC USP_SMHR_APPROVALPROCESS @MODE = 1,@APPRO_ORGANISATION_ID= " + Convert.ToString(_obj_Rec_ApprovalProcess.APPRO_ORGANISATION_ID) +
                                      " ");
                    break;
                case 2:
                    dt = ExecuteQuery("EXEC USP_SMHR_APPROVALPROCESS @MODE = 2,@APPRO_ID= " + Convert.ToString(_obj_Rec_ApprovalProcess.APPRO_ID) +
                                      " ");
                    break;

                case 5:
                    dt = ExecuteQuery("EXEC USP_SMHR_APPROVALPROCESS @MODE = 5 ,@APPRO_BU_ID= " + Convert.ToString(_obj_Rec_ApprovalProcess.APPRO_BU_ID) +
                                      " ,@APPRO_EMP_ID= " + Convert.ToString(_obj_Rec_ApprovalProcess.APPRO_1LEVEL) + " ");
                    // ,@APPRO_APPROVER1_ID= " + Convert.ToString(_obj_smhr_ApprovalProcess.APPRO_APPROVER1_ID) +
                    //" ,@APPRO_APPROVER2_ID = " + Convert.ToString(_obj_smhr_ApprovalProcess.APPRO_APPROVER2_ID) + " ,@APPRO_ISAPPROVER2= " + Convert.ToString(_obj_smhr_ApprovalProcess.APPRO_ISAPPROVER2) + " ");


                    break;
                case 6:
                    dt = ExecuteQuery("EXEC USP_SMHR_APPROVALPROCESS @MODE = 6 ,@APPRO_ORGANISATION_ID= " + Convert.ToString(_obj_Rec_ApprovalProcess.ORGANISATION_ID) +
                                      " ");

                    break;





                default:
                    break;
            }
            return dt;
        }

        public static DataTable get_JRApp(RECRUITMENT_APPROVALPROCESS _obj_Rec_ApprovalProcess)
        {
            //return ExecuteQuery("EXEC USP_SMHR_APPROVALPROCESS @Operation = 'check', @APPRO_APPROVER1_ID = " + _obj_Rec_ApprovalProcess.APPRO_2LEVEL + ", @APPRO_ORGANISATION_ID =" + Convert.ToString(_obj_Rec_ApprovalProcess.ORGANISATION_ID)+ " ");
            return ExecuteQuery("EXEC USP_SMHR_APPROVALPROCESS @Operation = '" + _obj_Rec_ApprovalProcess.OPERATION + "', @APPRO_ID = " + _obj_Rec_ApprovalProcess.APPRO_ID + ", @APPRO_ORGANISATION_ID =" + _obj_Rec_ApprovalProcess.ORGANISATION_ID);
        }




        public static bool set_EmpSetup(RECRUITMENT_APPROVALPROCESS _obj_Rec_ApprovalProcess)
        {
            bool status = false;
            switch (_obj_Rec_ApprovalProcess.Mode)
            {
                case 3:
                    if (ExecuteNonQuery("EXEC USP_SMHR_APPROVALPROCESS @MODE = 3 " +//, @APPRO_BU_ID= " + Convert.ToString(_obj_Rec_ApprovalProcess.APPRO_BU_ID) +
                                      " ,@APPRO_APPROVER1_ID = " + Convert.ToString(_obj_Rec_ApprovalProcess.APPRO_1LEVEL) +
                                     " , @APPRO_APPROVER2_ID = " + Convert.ToString(_obj_Rec_ApprovalProcess.APPRO_2LEVEL) +
                                     " ,@APPRO_APPROVER3_ID = '" + Convert.ToString(_obj_Rec_ApprovalProcess.APPRO_3LEVEL) + "'" +
                                     " , @APPRO_ISAPPROVER2='" + _obj_Rec_ApprovalProcess.APPRO_ISAPPROVER2 + "'" +
                                      " ,  @APPRO_CREATEDBY = " + Convert.ToInt32(_obj_Rec_ApprovalProcess.APPRO_CREATEDBY) +
                                      " , @APPRO_ORGANISATION_ID = " + Convert.ToInt32(_obj_Rec_ApprovalProcess.ORGANISATION_ID) +
                                      ", @APPRO_CREATEDDATE = '" + Convert.ToDateTime(_obj_Rec_ApprovalProcess.APPRO_CREATEDDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case 20:
                    if (ExecuteNonQuery("EXEC USP_SMHR_APPROVALPROCESS @MODE = 20 ,@APPRO_ID= " + Convert.ToString(_obj_Rec_ApprovalProcess.APPRO_ID) +
                        //+ ", @APPRO_BU_ID= " + Convert.ToString(_obj_Rec_ApprovalProcess.APPRO_BU_ID) +
                                      " ,@APPRO_APPROVER1_ID = " + Convert.ToString(_obj_Rec_ApprovalProcess.APPRO_1LEVEL) +
                                     " , @APPRO_APPROVER2_ID= " + Convert.ToString(_obj_Rec_ApprovalProcess.APPRO_2LEVEL) +
                                     " ,@APPRO_APPROVER3_ID = '" + Convert.ToString(_obj_Rec_ApprovalProcess.APPRO_3LEVEL) + "'" +
                                     " , @APPRO_ISAPPROVER2='" + _obj_Rec_ApprovalProcess.APPRO_ISAPPROVER2 + "'" +
                                      " ,  @APPRO_LASTMDFBY = " + Convert.ToInt32(_obj_Rec_ApprovalProcess.@APPRO_LASTMDFBY) +
                                       " , @APPRO_ORGANISATION_ID = " + Convert.ToInt32(_obj_Rec_ApprovalProcess.ORGANISATION_ID) +
                                      ", @APPRO_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Rec_ApprovalProcess.APPRO_LASTMDFDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                default:
                    break;
            }
            return status;

        }
        #endregion

        #region SMHR_EMPLOYEE

        public static DataTable get_Employee(SMHR_EMPLOYEE _obj_smhr_employee)
        {
            if (_obj_smhr_employee.OPERATION == operation.Select)
            {
                if (_obj_smhr_employee.EMP_ID.ToString() == "0")
                {
                    return ExecuteQuery("EXEC USP_SMHR_EMPLOYEE_New @Operation = 'select', @ORGANISATION_ID = '" + _obj_smhr_employee.ORGANISATION_ID + "',@EMP_LOGIN_ID='" + _obj_smhr_employee.EMP_LOGIN_ID + "'");
                }
                else
                {
                    return ExecuteQuery("EXEC USP_SMHR_EMPLOYEE_New @Operation = 'select', @EMP_ID = '" + _obj_smhr_employee.EMP_ID + "', @ORGANISATION_ID = '" + _obj_smhr_employee.ORGANISATION_ID + "'");
                }
            }
            else if (_obj_smhr_employee.OPERATION == operation.Check)
            {
                if (_obj_smhr_employee.EMP_EMPCODE.ToString() == "0")
                {
                    return ExecuteQuery("EXEC USP_SMHR_EMPLOYEE @Operation = 'check',@EMP_ORGANISATION_ID='" + _obj_smhr_employee.ORGANISATION_ID + "'");
                }
                else
                {
                    return ExecuteQuery("EXEC USP_SMHR_EMPLOYEE @Operation = 'check', @EMP_EMPCODE = '" + _obj_smhr_employee.EMP_EMPCODE + "',@EMP_ORGANISATION_ID='" + _obj_smhr_employee.ORGANISATION_ID + "'");
                }

            }
            else if (_obj_smhr_employee.OPERATION == operation.Empty)
            {
                if (_obj_smhr_employee.OPERATION.ToString() == "FILLEMP")
                {
                    if ((_obj_smhr_employee.OPERATION.ToString() == "FILLEMP") && (_obj_smhr_employee.EMP_BUSINESSUNIT_ID.ToString() == "0"))
                    {
                        return ExecuteQuery(" EXEC USP_SMHR_EMPLOYEE @Operation = 'FILLEMP',@EMP_ORGANISATION_ID='" + _obj_smhr_employee.ORGANISATION_ID + "'");
                    }
                    else
                    {
                        return ExecuteQuery(" EXEC USP_SMHR_EMPLOYEE @Operation = 'FILLEMP' and @EMP_BUSINESSUNIT_ID =" + _obj_smhr_employee.EMP_BUSINESSUNIT_ID + ",@EMP_ORGANISATION_ID='" + _obj_smhr_employee.ORGANISATION_ID + "'");
                    }
                }
                else if (_obj_smhr_employee.OPERATION.ToString() == "FILLRESGEMP")
                {
                    return ExecuteQuery(" EXEC USP_SMHR_EMPLOYEE @Operation = 'FILLRESGEMP',@EMP_ORGANISATION_ID='" + _obj_smhr_employee.ORGANISATION_ID + "'");
                }
                else
                {
                    return ExecuteQuery(" EXEC USP_SMHR_EMPLOYEE @Operation = 'FILLRELEMP',@EMP_ORGANISATION_ID='" + _obj_smhr_employee.ORGANISATION_ID + "'");
                }
            }
            else if (_obj_smhr_employee.OPERATION == operation.Update)
            {
                return ExecuteQuery(" EXEC USP_SMHR_EMPLOYEE @Operation = 'Update', @EMP_STATUS_UPDATE = '" + _obj_smhr_employee.APP_EMP_STATUS + "'" +
                                    ", @ORGANISATION_ID = '" + _obj_smhr_employee.ORGANISATION_ID + "'");
            }
            else if (_obj_smhr_employee.OPERATION == operation.SELECTEMPLOYEE)
            {
                return ExecuteQuery(" EXEC USP_SMHR_EMPLOYEE @Operation = 'SELECTEMPLOYEE',@EMP_BUSINESSUNIT_ID ='" + _obj_smhr_employee.BUID + "',@EMP_ORGANISATION_ID='" + _obj_smhr_employee.ORGANISATION_ID + "'");
            }

            else if (_obj_smhr_employee.OPERATION == operation.UpdateSTATUS)
            {
                return ExecuteQuery(" EXEC USP_SMHR_EMPLOYEE @Operation = 'SELECTSTATUS', @EMP_ID = '" + _obj_smhr_employee.EMP_ID + "'" +
                                    " ");
            }
            else if (_obj_smhr_employee.OPERATION == operation.Validate)
            {
                return ExecuteQuery("EXEC USP_SMHR_EMPLOYEE @OPERATION='VALIDATE',@ORGANISATION_ID='" + _obj_smhr_employee.ORGANISATION_ID + "'");
            }
            else if (_obj_smhr_employee.OPERATION == operation.load)
            {
                return ExecuteQuery(" EXEC USP_SMHR_EMPLOYEE @Operation = 'load',@EMP_ID = " + _obj_smhr_employee.EMP_ID + "");
            }
            else
            {
                return ExecuteQuery("EXEC USP_SMHR_EMPLOYEE @Operation = 'Delete', @EMP_BUSINESSUNIT_ID = '" + _obj_smhr_employee.EMP_BUSINESSUNIT_ID + "'");
            }
        }

        public static DataTable get_Supervisor(SMHR_EMPLOYEE _obj_smhr_employee)
        {
            if (_obj_smhr_employee.OPERATION == operation.Check)
            {
                return ExecuteQuery("EXEC USP_SMHR_EMPLOYEE_New @operation='check'," +
                        " @EMP_ID = '" + _obj_smhr_employee.EMP_ID + "'," +
                        " @EMP_BUSINESSUNIT_ID = '" + _obj_smhr_employee.EMP_BUSINESSUNIT_ID + "'");
            }
            else
            {
                return ExecuteQuery("EXEC USP_SMHR_EMPLOYEE_New @operation='Empty'," +
                     " @EMP_DESIGNATION_ID = '" + _obj_smhr_employee.EMP_DESIGNATION_ID + "'");
            }
        }



        public static DataTable get_DefaultSupervisor(SMHR_EMPLOYEE _obj_smhr_employee)
        {
            if (_obj_smhr_employee.OPERATION == operation.Select1)
            {
                return ExecuteQuery("EXEC USP_SMHR_BUSINESSUNIT_NEW @operation='Select1',@EMP_ID='" + _obj_smhr_employee.EMP_ID + "'");
            }
            else if (_obj_smhr_employee.OPERATION == operation.Validate)
            {
                return ExecuteQuery("EXEC USP_SMHR_BUSINESSUNIT_NEW @operation='Validate',@EMP_ID='" + _obj_smhr_employee.EMP_ID + "'");
            }
            else if (_obj_smhr_employee.OPERATION == operation.Check1)
            {
                return ExecuteQuery("EXEC USP_SMHR_BUSINESSUNIT_NEW @operation='Check1',@EMP_BUSINESSUNIT_ID='" + _obj_smhr_employee.EMP_BUSINESSUNIT_ID + "'");
            }
            else
            {
                return ExecuteQuery("EXEC USP_SMHR_EMPLOYEE_New @operation='Empty'," +
                        "@EMP_BUSINESSUNIT_ID = '" + _obj_smhr_employee.EMP_BUSINESSUNIT_ID + "'");
            }
        }
        public static DataTable get_empcode(SMHR_EMPLOYEE _obj_smhr_employee)
        {
            return ExecuteQuery("EXEC USP_SMHR_EMPLOYEE @operation='Get',@EMP_EMPCODE='" + _obj_smhr_employee.EMP_EMPCODE + "',@ORGANISATION_ID='" + _obj_smhr_employee.ORGANISATION_ID + "'");
        }

        public static bool set_Employee(SMHR_EMPLOYEE _obj_smhr_employee)
        {
            bool status = false;
            switch (_obj_smhr_employee.OPERATION)
            {
                case operation.Insert:
                    if (ExecuteNonQuery(" EXEC USP_SMHR_EMPLOYEE @Operation = '" + _obj_smhr_employee.OPERATION + "'" +
                            ",@EMP_EMPCODE = '" + _obj_smhr_employee.EMP_EMPCODE + "'" +
                            ",@EMP_ORGANISATION_ID = '" + _obj_smhr_employee.ORGANISATION_ID + "'" +
                            ",@EMP_APPLICANT_ID = '" + _obj_smhr_employee.EMP_APPLICANT_ID + "'" +
                            ",@EMP_DOJ = '" + _obj_smhr_employee.EMP_DOJ + "'" +
                            ",@EMP_DOC = " + (_obj_smhr_employee.EMP_DOC == null ? "null" : "'" + _obj_smhr_employee.EMP_DOC + "'") + "" +
                            ",@EMP_DESIGNATION_ID = '" + _obj_smhr_employee.EMP_DESIGNATION_ID + "'" +
                            ",@EMP_BUSINESSUNIT_ID = '" + _obj_smhr_employee.EMP_BUSINESSUNIT_ID + "'" +
                            ",@EMP_DATEOFLASTPROMOTION = " + (_obj_smhr_employee.EMP_DATEOFLASTPROMOTION == null ? "null" : "'" + _obj_smhr_employee.EMP_DATEOFLASTPROMOTION + "'") + "" +
                            ",@EMP_GRADE = '" + _obj_smhr_employee.EMP_GRADE + "'" +
                            ",@EMP_REPORTINGEMPLOYEE = '" + _obj_smhr_employee.EMP_REPORTINGEMPLOYEE + "'" +
                            ",@EMP_RPTSTARTDATE = " + (_obj_smhr_employee.EMP_RPTSTARTDATE == null ? "null" : "'" + _obj_smhr_employee.EMP_RPTSTARTDATE + "'") + "" +
                            ",@EMP_RPTENDDATE = " + (_obj_smhr_employee.EMP_RPTENDDATE == null ? "null" : "'" + _obj_smhr_employee.EMP_RPTENDDATE + "'") + "" +
                            ",@EMP_SHIFT_ID = '" + _obj_smhr_employee.EMP_SHIFT_ID + "'" +
                            ",@EMP_GROSSSAL = '" + _obj_smhr_employee.EMP_GROSSSAL + "'" +
                            ",@EMP_BASIC = '" + _obj_smhr_employee.EMP_BASIC + "'" +
                            ",@EMP_PAYMENTMODE_ID = '" + _obj_smhr_employee.EMP_PAYMENTMODE_ID + "'" +
                            ",@EMP_SALALRYSTRUCT_ID = '" + _obj_smhr_employee.EMP_SALALRYSTRUCT_ID + "'" +
                            ",@EMP_LEAVESTRUCT_ID = '" + _obj_smhr_employee.EMP_LEAVESTRUCT_ID + "'" +
                            ",@EMP_STATUS = '" + _obj_smhr_employee.EMP_STATUS + "'" +
                            ",@EMP_PROBATIONDATE = " + (_obj_smhr_employee.EMP_PROBATIONDATE == null ? "null" : "'" + _obj_smhr_employee.EMP_PROBATIONDATE + "'") + "" +
                            ",@EMP_NOTICEPERIOD = '" + _obj_smhr_employee.EMP_NOTICEPERIOD + "'" +
                            ",@EMP_PICTURE = '" + Convert.ToString(_obj_smhr_employee.EMP_PICUTRE) + "'" +
                            ",@EMP_EMPLOYEETYPE = '" + Convert.ToString(_obj_smhr_employee.EMP_EMPLOYEETYPE) + "'" +
                            ",@EMP_PAYCURRENCY = '" + Convert.ToInt32(_obj_smhr_employee.EMP_PAYCURRENCY) + "'" +
                            ",@EMP_DEPARTMENT_ID = '" + Convert.ToInt32(_obj_smhr_employee.EMP_DEPARTMENT_ID) + "'" +
                            ",@EMP_CONTRACT_STARTDATE = " + (_obj_smhr_employee.EMP_CONTRACT_STARTDATE == null ? "null" : "'" + _obj_smhr_employee.EMP_CONTRACT_STARTDATE + "'") + "" +
                            ",@EMP_EMPLOYEE_STATUS = '" + Convert.ToInt32(_obj_smhr_employee.EMP_EMPLOYEE_STATUS) + "'" +
                            ",@EMP_CREATEDBY = '" + _obj_smhr_employee.EMP_CREATEDBY + "'" +
                            ",@EMP_CREATEDDATE = '" + Convert.ToDateTime(_obj_smhr_employee.EMP_CREATEDDATE).ToString("MM/dd/yyyy") + "'" +
                            ",@EMP_SUPBUSINESSUNIT_ID='" + Convert.ToInt32(_obj_smhr_employee.EMP_SUPBUSINESSUNIT_ID) + "'" +
                            ",@EMP_HOBBIES='" + _obj_smhr_employee.EMP_HOBBIES +
                            "',@EMP_AMOUNT='" + _obj_smhr_employee.EMP_VARIABLEAMT +
                            "',@EMP_COUNT='" + _obj_smhr_employee.EMP_VPPAYABLECOUNT +
                            "',@EMP_ISVP='" + Convert.ToBoolean(_obj_smhr_employee.EMP_ISVARIABLEPAY) + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case operation.Insert1:
                    if (ExecuteNonQuery(" EXEC USP_SMHR_EMPLOYEE @Operation = '" + _obj_smhr_employee.OPERATION + "'" +
                            ",@EMP_EMPCODE = '" + _obj_smhr_employee.EMP_EMPCODE + "'" +
                            ",@EMP_ORGANISATION_ID = '" + _obj_smhr_employee.ORGANISATION_ID + "'" +
                            ",@EMP_APPLICANT_ID = '" + _obj_smhr_employee.EMP_APPLICANT_ID + "'" +
                            ",@EMP_DATEOFJOIN = '" + _obj_smhr_employee.EMP_DATEOFJOIN + "'" +
                            ",@EMP_DATEOFCONFORM = " + (_obj_smhr_employee.EMP_DATEOFCONFORM == null ? "null" : "'" + _obj_smhr_employee.EMP_DATEOFCONFORM + "'") + "" +
                            ",@EMP_DESIGNATION_ID = '" + _obj_smhr_employee.EMP_DESIGNATION_ID + "'" +
                            ",@EMP_BUSINESSUNIT_ID = '" + _obj_smhr_employee.EMP_BUSINESSUNIT_ID + "'" +
                            ",@EMP_DATEOLP = " + (_obj_smhr_employee.EMP_DATEOLP == null ? "null" : "'" + _obj_smhr_employee.EMP_DATEOLP + "'") + "" +
                            ",@EMP_GRADE = '" + _obj_smhr_employee.EMP_GRADE + "'" +
                            ",@EMP_REPORTINGEMPLOYEE = '" + _obj_smhr_employee.EMP_REPORTINGEMPLOYEE + "'" +
                            ",@EMP_RPT = " + (_obj_smhr_employee.EMP_rpt == null ? "null" : "'" + _obj_smhr_employee.EMP_rpt + "'") + "" +
                            ",@EMP_RPTENDDATE = " + (_obj_smhr_employee.EMP_RPTENDDATE == null ? "null" : "'" + _obj_smhr_employee.EMP_RPTENDDATE + "'") + "" +
                            ",@EMP_SHIFT_ID = '" + _obj_smhr_employee.EMP_SHIFT_ID + "'" +
                            ",@EMP_GROSSSAL = '" + _obj_smhr_employee.EMP_GROSSSAL + "'" +
                            ",@EMP_BASIC = '" + _obj_smhr_employee.EMP_BASIC + "'" +
                            ",@EMP_PAYMENTMODE_ID = '" + _obj_smhr_employee.EMP_PAYMENTMODE_ID + "'" +
                            ",@EMP_SALALRYSTRUCT_ID = '" + _obj_smhr_employee.EMP_SALALRYSTRUCT_ID + "'" +
                            ",@EMP_LEAVESTRUCT_ID = '" + _obj_smhr_employee.EMP_LEAVESTRUCT_ID + "'" +
                            ",@EMP_STATUS = '" + _obj_smhr_employee.EMP_STATUS + "'" +
                            ",@EMP_PROBDATE = " + (_obj_smhr_employee.EMP_PROBDATE == null ? "null" : "'" + _obj_smhr_employee.EMP_PROBDATE + "'") + "" +
                            ",@EMP_NOTICEPERIOD = '" + _obj_smhr_employee.EMP_NOTICEPERIOD + "'" +
                            ",@EMP_PICTURE = '" + Convert.ToString(_obj_smhr_employee.EMP_PICUTRE) + "'" +
                            ",@EMP_EMPLOYEETYPE = '" + Convert.ToString(_obj_smhr_employee.EMP_EMPLOYEETYPE) + "'" +
                            ",@EMP_PAYCURRENCY = '" + Convert.ToInt32(_obj_smhr_employee.EMP_PAYCURRENCY) + "'" +
                            ",@EMP_DEPARTMENT_ID = '" + Convert.ToInt32(_obj_smhr_employee.EMP_DEPARTMENT_ID) + "'" +
                            ",@EMP_CONTRDATE = " + (_obj_smhr_employee.EMP_CONTRDATE == null ? "null" : "'" + _obj_smhr_employee.EMP_CONTRDATE + "'") + "" +
                            ",@EMP_EMPLOYEE_STATUS = '" + Convert.ToInt32(_obj_smhr_employee.EMP_EMPLOYEE_STATUS) + "'" +
                            ",@EMP_CREATEDBY = '" + _obj_smhr_employee.EMP_CREATEDBY + "'" +
                            ",@EMP_CREATEDDATE = '" + Convert.ToDateTime(_obj_smhr_employee.EMP_CREATEDDATE).ToString("MM/dd/yyyy") + "'" +
                            ",@EMP_SUPBUSINESSUNIT_ID='" + Convert.ToInt32(_obj_smhr_employee.EMP_SUPBUSINESSUNIT_ID) + "'" +
                            ",@EMP_HOBBIES='" + _obj_smhr_employee.EMP_HOBBIES +
                            "',@EMP_AMOUNT='" + _obj_smhr_employee.EMP_VARIABLEAMT +
                            "',@EMP_COUNT='" + _obj_smhr_employee.EMP_VPPAYABLECOUNT +
                            "',@EMP_ISVP='" + Convert.ToBoolean(_obj_smhr_employee.EMP_ISVARIABLEPAY) + "'"))
                        status = true;
                    else
                        status = false;
                    break;

                case operation.Update:
                    if (ExecuteNonQuery(" EXEC USP_SMHR_EMPLOYEE @Operation = '" + _obj_smhr_employee.OPERATION + "'" +
                            ",@EMP_EMPCODE = '" + _obj_smhr_employee.EMP_EMPCODE + "'" +
                            ",@EMP_ORGANISATION_ID = '" + _obj_smhr_employee.ORGANISATION_ID + "'" +
                            ",@EMP_APPLICANT_ID = '" + _obj_smhr_employee.EMP_APPLICANT_ID + "'" +
                            ",@EMP_DOJ = '" + Convert.ToDateTime(_obj_smhr_employee.EMP_DOJ).ToString("MM/dd/yyyy") + "'" +
                            ",@EMP_DOC = " + (_obj_smhr_employee.EMP_DOC == null ? "null" : "'" + _obj_smhr_employee.EMP_DOC + "'") + "" +
                            ",@EMP_DESIGNATION_ID = '" + _obj_smhr_employee.EMP_DESIGNATION_ID + "'" +
                            ",@EMP_BUSINESSUNIT_ID = '" + _obj_smhr_employee.EMP_BUSINESSUNIT_ID + "'" +
                            ",@EMP_DATEOFLASTPROMOTION = " + (_obj_smhr_employee.EMP_DATEOFLASTPROMOTION == null ? "null" : "'" + _obj_smhr_employee.EMP_DATEOFLASTPROMOTION + "'") +
                            ",@EMP_GRADE = '" + _obj_smhr_employee.EMP_GRADE + "'" +
                            ",@EMP_REPORTINGEMPLOYEE = '" + _obj_smhr_employee.EMP_REPORTINGEMPLOYEE + "'" +
                            ",@EMP_RPTSTARTDATE = " + (_obj_smhr_employee.EMP_RPTSTARTDATE == null ? "null" : "'" + _obj_smhr_employee.EMP_RPTSTARTDATE + "'") +
                            ",@EMP_RPTENDDATE = " + (_obj_smhr_employee.EMP_RPTENDDATE == null ? "null" : "'" + _obj_smhr_employee.EMP_RPTENDDATE + "'") +
                            ",@EMP_SHIFT_ID = '" + _obj_smhr_employee.EMP_SHIFT_ID + "'" +
                            ",@EMP_GROSSSAL = '" + _obj_smhr_employee.EMP_GROSSSAL + "'" +
                            ",@EMP_BASIC = '" + _obj_smhr_employee.EMP_BASIC + "'" +
                            ",@EMP_PAYMENTMODE_ID = '" + _obj_smhr_employee.EMP_PAYMENTMODE_ID + "'" +
                            ",@EMP_SALALRYSTRUCT_ID = '" + _obj_smhr_employee.EMP_SALALRYSTRUCT_ID + "'" +
                            ",@EMP_LEAVESTRUCT_ID = '" + _obj_smhr_employee.EMP_LEAVESTRUCT_ID + "'" +
                            ",@EMP_STATUS = '" + _obj_smhr_employee.EMP_STATUS + "'" +
                            ",@EMP_PROBATIONDATE = " + (_obj_smhr_employee.EMP_PROBATIONDATE == null ? "null" : "'" + _obj_smhr_employee.EMP_PROBATIONDATE + "'") +
                            ",@EMP_NOTICEPERIOD = '" + _obj_smhr_employee.EMP_NOTICEPERIOD + "'" +
                            ",@EMP_PICTURE = '" + Convert.ToString(_obj_smhr_employee.EMP_PICUTRE) + "'" +
                            ",@EMP_EMPLOYEETYPE = '" + Convert.ToString(_obj_smhr_employee.EMP_EMPLOYEETYPE) + "'" +
                            ",@EMP_LASTMDFBY = '" + _obj_smhr_employee.EMP_LASTMDFBY + "'" +
                            ",@EMP_CONTRACT_STARTDATE = " + (_obj_smhr_employee.EMP_CONTRACT_STARTDATE == null ? "null" : "'" + _obj_smhr_employee.EMP_CONTRACT_STARTDATE + "'") + "" +
                            ",@EMP_EMPLOYEE_STATUS = '" + Convert.ToInt32(_obj_smhr_employee.EMP_EMPLOYEE_STATUS) + "'" +
                            ",@EMP_LASTMDFDATE = '" + Convert.ToDateTime(_obj_smhr_employee.EMP_LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
                            ",@EMP_PAYCURRENCY = '" + Convert.ToInt32(_obj_smhr_employee.EMP_PAYCURRENCY) + "'" +
                            ",@EMP_DEPARTMENT_ID = '" + Convert.ToInt32(_obj_smhr_employee.EMP_DEPARTMENT_ID) + "'" +
                            ",@EMP_SUPBUSINESSUNIT_ID='" + Convert.ToInt32(_obj_smhr_employee.EMP_SUPBUSINESSUNIT_ID) + "'" +
                            ",@EMP_HOBBIES='" + _obj_smhr_employee.EMP_HOBBIES + "'" +
                            ",@EMP_AMOUNT='" + _obj_smhr_employee.EMP_VARIABLEAMT +
                            "',@EMP_COUNT='" + _obj_smhr_employee.EMP_VPPAYABLECOUNT +
                            "',@EMP_ISVP='" + Convert.ToBoolean(_obj_smhr_employee.EMP_ISVARIABLEPAY) +
                            "',@EMP_ID = '" + _obj_smhr_employee.EMP_ID + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                default:
                    break;
            }
            return status;
        }



        public static bool set_EmpFamily(SMHR_EMPLOYEE _obj_smhr_employee)
        {
            bool status = false;
            switch (_obj_smhr_employee.OPERATION)
            {
                case operation.Insert:
                    if (ExecuteNonQuery(" EXEC USP_SMHR_EMPFAMILYDETAILS @Operation = '" + _obj_smhr_employee.OPERATION + "'" +
                                        ",@EMPFMDTL_EMP_ID = '" + _obj_smhr_employee.EMPFMDTL_EMP_ID + "'" +
                                        ",@EMPFMDTL_SERIAL = '" + _obj_smhr_employee.EMPFMDTL_SERIAL + "'" +
                                        ",@EMPFMDTL_EMPREL_ID = '" + _obj_smhr_employee.EMPFMDTL_EMPREL_ID + "'" +
                                        ",@EMPFMDTL_NAME = '" + _obj_smhr_employee.EMPFMDTL_NAME + "'" +
                                        ",@EMPFMDTL_RELDOB = '" + Convert.ToDateTime(_obj_smhr_employee.EMPFMDTL_RELDOB).ToString("MM/dd/yyyy") + "'" +
                                        ",@EMPFMDTL_RELDEPENDENT = '" + _obj_smhr_employee.EMPFMDTL_RELDEPENDENT + "'" +
                                        ",@EMPFMDTL_RELEMERGENCY = '" + _obj_smhr_employee.EMPFMDTL_EMERGENCYCONTACT + "'" +
                                        ",@EMPFMDTL_RELNEXTTOKIN = '" + _obj_smhr_employee.EMPFMDTL_ISNEXTTOKIN + "'" +
                                        ",@EMPFMDTL_CREATEDBY = '" + _obj_smhr_employee.EMPFMDTL_CREATEDBY + "'" +
                                        ",@EMPFMDTL_CREATEDDATE = '" + Convert.ToDateTime(_obj_smhr_employee.EMPFMDTL_CREATEDDATE).ToString("MM/dd/yyyy") + "'" +
                                        ",@EMPFMDTL_ANNUALINCOME='" + Convert.ToDouble(_obj_smhr_employee.EMPFMDTL_ANNUALINCOME) + "'" +
                                        ",@EMPFMDTL_OCCUPATION='" + _obj_smhr_employee.EMPFMDTL_OCCUPATION + "'" +
                                        ",@EMPFMDTL_RELNOMINEE='" + _obj_smhr_employee.EMPFMDTL_NOMINEE + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case operation.Insert1:
                    if (ExecuteNonQuery(" EXEC USP_SMHR_EMPFAMILYDETAILS @Operation = '" + _obj_smhr_employee.OPERATION + "'" +
                                        ",@EMPFMDTL_EMP_ID = '" + _obj_smhr_employee.EMPFMDTL_EMP_ID + "'" +
                                        ",@EMPFMDTL_SERIAL = '" + _obj_smhr_employee.EMPFMDTL_SERIAL + "'" +
                                        ",@EMPFMDTL_EMPREL_ID = '" + _obj_smhr_employee.EMPFMDTL_EMPREL_ID + "'" +
                                        ",@EMPFMDTL_NAME = '" + _obj_smhr_employee.EMPFMDTL_NAME + "'" +
                                        ",@EMFM_RELDOB = '" + Convert.ToString(_obj_smhr_employee.EMFM_RELDOB) + "'" +
                                        ",@EMPFMDTL_RELDEPENDENT = '" + _obj_smhr_employee.EMPFMDTL_RELDEPENDENT + "'" +
                                        ",@EMPFMDTL_RELEMERGENCY = '" + _obj_smhr_employee.EMPFMDTL_EMERGENCYCONTACT + "'" +
                                        ",@EMPFMDTL_RELNEXTTOKIN = '" + _obj_smhr_employee.EMPFMDTL_ISNEXTTOKIN + "'" +
                                        ",@EMPFMDTL_CREATEDBY = '" + _obj_smhr_employee.EMPFMDTL_CREATEDBY + "'" +
                                        ",@EMPFMDTL_CREATEDDATE = '" + Convert.ToDateTime(_obj_smhr_employee.EMPFMDTL_CREATEDDATE).ToString("MM/dd/yyyy") + "'" +
                                        ",@EMPFMDTL_ANNUALINCOME='" + Convert.ToDouble(_obj_smhr_employee.EMPFMDTL_ANNUALINCOME) + "'" +
                                        ",@EMPFMDTL_OCCUPATION='" + _obj_smhr_employee.EMPFMDTL_OCCUPATION + "'" +
                                        ",@EMPFMDTL_RELNOMINEE='" + _obj_smhr_employee.EMPFMDTL_NOMINEE + "'"))
                        status = true;
                    else
                        status = false;
                    break;


                case operation.Update:
                    if (ExecuteNonQuery(" EXEC USP_SMHR_EMPFAMILYDETAILS @Operation = '" + _obj_smhr_employee.OPERATION + "'" +
                                        ",@EMPFMDTL_EMP_ID = '" + _obj_smhr_employee.EMPFMDTL_EMP_ID + "'" +
                                        ",@EMPFMDTL_SERIAL = '" + _obj_smhr_employee.EMPFMDTL_SERIAL + "'" +
                                        ",@EMPFMDTL_EMPREL_ID = '" + _obj_smhr_employee.EMPFMDTL_EMPREL_ID + "'" +
                                        ",@EMPFMDTL_NAME = '" + _obj_smhr_employee.EMPFMDTL_NAME + "'" +
                                        ",@EMPFMDTL_RELDOB = '" + Convert.ToDateTime(_obj_smhr_employee.EMPFMDTL_RELDOB).ToString("MM/dd/yyyy") + "'" +
                                        ",@EMPFMDTL_RELDEPENDENT = '" + _obj_smhr_employee.EMPFMDTL_RELDEPENDENT + "'" +
                                        ",@EMPFMDTL_RELEMERGENCY = '" + _obj_smhr_employee.EMPFMDTL_EMERGENCYCONTACT + "'" +
                                        ",@EMPFMDTL_RELNEXTTOKIN = '" + _obj_smhr_employee.EMPFMDTL_ISNEXTTOKIN + "'" +
                                        ",@EMPFMDTL_LASTMDFBY = '" + _obj_smhr_employee.EMPFMDTL_LASTMDFBY + "'" +
                                        ",@EMPFMDTL_LASTMDFDATE = '" + Convert.ToDateTime(_obj_smhr_employee.EMPFMDTL_LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
                                         ",@EMPFMDTL_ANNUALINCOME='" + Convert.ToDouble(_obj_smhr_employee.EMPFMDTL_ANNUALINCOME) + "'" +
                                        ",@EMPFMDTL_OCCUPATION='" + _obj_smhr_employee.EMPFMDTL_OCCUPATION + "'" +
                                        ",@EMPFMDTL_RELNOMINEE='" + _obj_smhr_employee.EMPFMDTL_NOMINEE + "'" +
                                        ",@EMPFMDTL_ID = '" + _obj_smhr_employee.EMPFMDTL_ID + "'"))
                        status = true;
                    else
                        status = false;
                    break;

                //Modified
                case operation.Insert_New:
                    if (ExecuteNonQuery("EXEC USP_SMHR_FAMILYDETAILS_MODIFIED @Operation='" + _obj_smhr_employee.OPERATION + "'" +
                                        ",@EMPFMDTL_EMP_ID = '" + _obj_smhr_employee.EMPFMDTL_EMP_ID + "'" +
                                        ",@EMPFMDTL_SERIAL = '" + _obj_smhr_employee.EMPFMDTL_SERIAL + "'" +
                                        ",@EMPFMDTL_EMPREL_ID = '" + _obj_smhr_employee.EMPFMDTL_EMPREL_ID + "'" +
                                        ",@EMPFMDTL_NAME = '" + _obj_smhr_employee.EMPFMDTL_NAME + "'" +
                                        ",@EMPFMDTL_RELDOB = '" + Convert.ToDateTime(_obj_smhr_employee.EMPFMDTL_RELDOB).ToString("MM/dd/yyyy") + "'" +
                                        ",@EMPFMDTL_RELDEPENDENT = '" + _obj_smhr_employee.EMPFMDTL_RELDEPENDENT + "'" +
                                        ",@EMPFMDTL_RELEMERGENCY = '" + _obj_smhr_employee.EMPFMDTL_EMERGENCYCONTACT + "'" +
                                        ",@EMPFMDTL_RELNEXTTOKIN = '" + _obj_smhr_employee.EMPFMDTL_ISNEXTTOKIN + "'" +
                                        ",@EMPFMDTL_CREATEDBY = '" + _obj_smhr_employee.EMPFMDTL_CREATEDBY + "'" +
                                        ",@EMPFMDTL_CREATEDDATE = '" + Convert.ToDateTime(_obj_smhr_employee.EMPFMDTL_CREATEDDATE).ToString("MM/dd/yyyy") + "'" +
                                        ",@EMPFMDTL_ANNUALINCOME='" + _obj_smhr_employee.EMPFMDTL_ANNUALINCOME + "'" +
                                        ",@EMPFMDTL_OCCUPATION='" + _obj_smhr_employee.EMPFMDTL_OCCUPATION + "'"))
                        status = true;
                    else
                        status = false;
                    break;

                //Modified
                case operation.Update_New:
                    if (ExecuteNonQuery("EXEC USP_SMHR_FAMILYDETAILS_MODIFIED @Operation='" + _obj_smhr_employee.OPERATION + "'" +
                                        ",@EMPFMDTL_EMP_ID = '" + _obj_smhr_employee.EMPFMDTL_EMP_ID + "'" +
                                        ",@EMPFMDTL_SERIAL = '" + _obj_smhr_employee.EMPFMDTL_SERIAL + "'" +
                                        ",@EMPFMDTL_EMPREL_ID = '" + _obj_smhr_employee.EMPFMDTL_EMPREL_ID + "'" +
                                        ",@EMPFMDTL_NAME = '" + _obj_smhr_employee.EMPFMDTL_NAME + "'" +
                                        ",@EMPFMDTL_RELDOB = '" + Convert.ToDateTime(_obj_smhr_employee.EMPFMDTL_RELDOB).ToString("MM/dd/yyyy") + "'" +
                                        ",@EMPFMDTL_RELDEPENDENT = '" + _obj_smhr_employee.EMPFMDTL_RELDEPENDENT + "'" +
                                        ",@EMPFMDTL_RELEMERGENCY = '" + _obj_smhr_employee.EMPFMDTL_EMERGENCYCONTACT + "'" +
                                        ",@EMPFMDTL_RELNEXTTOKIN = '" + _obj_smhr_employee.EMPFMDTL_ISNEXTTOKIN + "'" +
                                        ",@EMPFMDTL_CREATEDBY = '" + _obj_smhr_employee.EMPFMDTL_CREATEDBY + "'" +
                                        ",@EMPFMDTL_CREATEDDATE = '" + Convert.ToDateTime(_obj_smhr_employee.EMPFMDTL_CREATEDDATE).ToString("MM/dd/yyyy") + "'" +
                                        ",@EMPFMDTL_ANNUALINCOME='" + _obj_smhr_employee.EMPFMDTL_ANNUALINCOME + "'" +
                                        ",@EMPFMDTL_OCCUPATION='" + _obj_smhr_employee.EMPFMDTL_OCCUPATION + "'" +
                                        ",@EMPFMDTL_ID = '" + _obj_smhr_employee.EMPFMDTL_ID + "'"))
                        status = true;
                    else
                        status = false;
                    break;
            }
            return status;
        }

        public static bool set_RehireEmployee(SMHR_EMPLOYEE _obj_smhr_employee)
        {
            bool status = false;
            switch (_obj_smhr_employee.OPERATION)
            {
                case operation.Insert:
                    if (ExecuteNonQuery(" EXEC USP_SMHR_REHIREEMPLOYEE @EMP_ID = " + _obj_smhr_employee.EMP_ID + "" +
                            ",@EMP_EMPCODE = '" + _obj_smhr_employee.EMP_EMPCODE + "'" +
                            ",@EMP_CREATEDBY = '" + _obj_smhr_employee.EMP_CREATEDBY + "'" +
                            ",@EMP_CREATEDDATE = '" + Convert.ToDateTime(_obj_smhr_employee.EMP_CREATEDDATE).ToString("MM/dd/yyyy") + "'" +
                            ",@EMP_LASTMDFBY = '" + _obj_smhr_employee.EMP_LASTMDFBY + "'" +
                            ",@EMP_LASTMDFDATE = '" + Convert.ToDateTime(_obj_smhr_employee.EMP_LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
                            ",@GLOBALCONFIG_ORGANISATION_ID = '" + _obj_smhr_employee.ORGANISATION_ID + "'" +
                            ",@EMP_APPLICANT = '" + Convert.ToString(_obj_smhr_employee.EMPFMDTL_NAME) + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case operation.Update:
                    if (ExecuteNonQuery(" EXEC USP_SMHR_EMPLOYEE @Operation = '" + _obj_smhr_employee.OPERATION + "'" +
                            ",@EMP_EMPCODE = '" + _obj_smhr_employee.EMP_EMPCODE + "'" +
                            ",@EMP_APPLICANT_ID = '" + _obj_smhr_employee.EMP_APPLICANT_ID + "'" +
                            ",@EMP_DOJ = '" + Convert.ToDateTime(_obj_smhr_employee.EMP_DOJ).ToString("MM/dd/yyyy") + "'" +
                            ",@EMP_DOC = " + (_obj_smhr_employee.EMP_DOC == null ? "null" : "'" + _obj_smhr_employee.EMP_DOC + "'") + "" +
                            ",@EMP_DESIGNATION_ID = '" + _obj_smhr_employee.EMP_DESIGNATION_ID + "'" +
                            ",@EMP_BUSINESSUNIT_ID = '" + _obj_smhr_employee.EMP_BUSINESSUNIT_ID + "'" +
                            ",@EMP_DATEOFLASTPROMOTION = " + (_obj_smhr_employee.EMP_DATEOFLASTPROMOTION == null ? "null" : "'" + _obj_smhr_employee.EMP_DATEOFLASTPROMOTION + "'") +
                            ",@EMP_GRADE = '" + _obj_smhr_employee.EMP_GRADE + "'" +
                            ",@EMP_REPORTINGEMPLOYEE = '" + _obj_smhr_employee.EMP_REPORTINGEMPLOYEE + "'" +
                            ",@EMP_RPTSTARTDATE = " + (_obj_smhr_employee.EMP_RPTSTARTDATE == null ? "null" : "'" + _obj_smhr_employee.EMP_RPTSTARTDATE + "'") +
                            ",@EMP_RPTENDDATE = " + (_obj_smhr_employee.EMP_RPTENDDATE == null ? "null" : "" + _obj_smhr_employee.EMP_RPTENDDATE + "'") +
                            ",@EMP_SHIFT_ID = '" + _obj_smhr_employee.EMP_SHIFT_ID + "'" +
                            ",@EMP_GROSSSAL = '" + _obj_smhr_employee.EMP_GROSSSAL + "'" +
                            ",@EMP_BASIC = '" + _obj_smhr_employee.EMP_BASIC + "'" +
                            ",@EMP_PAYMENTMODE_ID = '" + _obj_smhr_employee.EMP_PAYMENTMODE_ID + "'" +
                            ",@EMP_SALALRYSTRUCT_ID = '" + _obj_smhr_employee.EMP_SALALRYSTRUCT_ID + "'" +
                            ",@EMP_LEAVESTRUCT_ID = '" + _obj_smhr_employee.EMP_LEAVESTRUCT_ID + "'" +
                            ",@EMP_STATUS = '" + _obj_smhr_employee.EMP_STATUS + "'" +
                            ",@EMP_PROBATIONDATE = " + (_obj_smhr_employee.EMP_PROBATIONDATE == null ? "null" : "'" + _obj_smhr_employee.EMP_PROBATIONDATE + "'") +
                            ",@EMP_NOTICEPERIOD = '" + _obj_smhr_employee.EMP_NOTICEPERIOD + "'" +
                            ",@EMP_LASTMDFBY = '" + _obj_smhr_employee.EMP_LASTMDFBY + "'" +
                            ",@EMP_LASTMDFDATE = '" + Convert.ToDateTime(_obj_smhr_employee.EMP_LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
                            ",@EMP_SUPBUSINESSUNIT_ID='" + Convert.ToInt32(_obj_smhr_employee.EMP_SUPBUSINESSUNIT_ID) + "'" +
                            ",@EMP_HOBBIES='" + Convert.ToString(_obj_smhr_employee.EMP_HOBBIES) + "'" +
                            ",@EMP_ID = '" + _obj_smhr_employee.EMP_ID + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                default:
                    break;
            }
            return status;
        }


        //public static bool set_EmpFamily(SMHR_EMPLOYEE _obj_smhr_employee)
        //{
        //    bool status = false;
        //    switch (_obj_smhr_employee.OPERATION)
        //    {
        //        case operation.Insert:
        //            if (ExecuteNonQuery(" EXEC USP_SMHR_EMPFAMILYDETAILS @Operation = '" + _obj_smhr_employee.OPERATION + "'" +
        //                                ",@EMPFMDTL_EMP_ID = '" + _obj_smhr_employee.EMPFMDTL_EMP_ID + "'" +
        //                                ",@EMPFMDTL_SERIAL = '" + _obj_smhr_employee.EMPFMDTL_SERIAL + "'" +
        //                                ",@EMPFMDTL_EMPREL_ID = '" + _obj_smhr_employee.EMPFMDTL_EMPREL_ID + "'" +
        //                                ",@EMPFMDTL_NAME = '" + _obj_smhr_employee.EMPFMDTL_NAME + "'" +
        //                                ",@EMPFMDTL_RELDOB = '" + _obj_smhr_employee.EMPFMDTL_RELDOB + "'" +
        //                                ",@EMPFMDTL_RELDEPENDENT = '" + _obj_smhr_employee.EMPFMDTL_RELDEPENDENT + "'" +
        //                                ",@EMPFMDTL_RELEMERGENCY = '" + _obj_smhr_employee.EMPFMDTL_EMERGENCYCONTACT + "'" +
        //                                ",@EMPFMDTL_RELNEXTTOKIN = '" + _obj_smhr_employee.EMPFMDTL_ISNEXTTOKIN + "'" +
        //                                ",@EMPFMDTL_CREATEDBY = '" + _obj_smhr_employee.EMPFMDTL_CREATEDBY + "'" +
        //                                ",@EMPFMDTL_CREATEDDATE = '" + Convert.ToDateTime(_obj_smhr_employee.EMPFMDTL_CREATEDDATE).ToString("MM/dd/yyyy") + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        case operation.Update:
        //            if (ExecuteNonQuery(" EXEC USP_SMHR_EMPFAMILYDETAILS @Operation = '" + _obj_smhr_employee.OPERATION + "'" +
        //                                ",@EMPFMDTL_EMP_ID = '" + _obj_smhr_employee.EMPFMDTL_EMP_ID + "'" +
        //                                ",@EMPFMDTL_SERIAL = '" + _obj_smhr_employee.EMPFMDTL_SERIAL + "'" +
        //                                ",@EMPFMDTL_EMPREL_ID = '" + _obj_smhr_employee.EMPFMDTL_EMPREL_ID + "'" +
        //                                ",@EMPFMDTL_NAME = '" + _obj_smhr_employee.EMPFMDTL_NAME + "'" +
        //                                ",@EMPFMDTL_RELDOB = '" + _obj_smhr_employee.EMPFMDTL_RELDOB + "'" +
        //                                ",@EMPFMDTL_RELDEPENDENT = '" + _obj_smhr_employee.EMPFMDTL_RELDEPENDENT + "'" +
        //                                ",@EMPFMDTL_RELEMERGENCY = '" + _obj_smhr_employee.EMPFMDTL_EMERGENCYCONTACT + "'" +
        //                                ",@EMPFMDTL_RELNEXTTOKIN = '" + _obj_smhr_employee.EMPFMDTL_ISNEXTTOKIN + "'" +
        //                                ",@EMPFMDTL_LASTMDFBY = '" + _obj_smhr_employee.EMPFMDTL_LASTMDFBY + "'" +
        //                                ",@EMPFMDTL_LASTMDFDATE = '" + Convert.ToDateTime(_obj_smhr_employee.EMPFMDTL_LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
        //                                ",@EMPFMDTL_ID = '" + _obj_smhr_employee.EMPFMDTL_ID + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;

        //        //Modified
        //        case operation.Insert_New:
        //            if (ExecuteNonQuery("EXEC USP_SMHR_FAMILYDETAILS_MODIFIED @Operation='" + _obj_smhr_employee.OPERATION + "'" +
        //                                ",@EMPFMDTL_EMP_ID = '" + _obj_smhr_employee.EMPFMDTL_EMP_ID + "'" +
        //                                ",@EMPFMDTL_SERIAL = '" + _obj_smhr_employee.EMPFMDTL_SERIAL + "'" +
        //                                ",@EMPFMDTL_EMPREL_ID = '" + _obj_smhr_employee.EMPFMDTL_EMPREL_ID + "'" +
        //                                ",@EMPFMDTL_NAME = '" + _obj_smhr_employee.EMPFMDTL_NAME + "'" +
        //                                ",@EMPFMDTL_RELDOB = '" + _obj_smhr_employee.EMPFMDTL_RELDOB + "'" +
        //                                ",@EMPFMDTL_RELDEPENDENT = '" + _obj_smhr_employee.EMPFMDTL_RELDEPENDENT + "'" +
        //                                ",@EMPFMDTL_RELEMERGENCY = '" + _obj_smhr_employee.EMPFMDTL_EMERGENCYCONTACT + "'" +
        //                                ",@EMPFMDTL_RELNEXTTOKIN = '" + _obj_smhr_employee.EMPFMDTL_ISNEXTTOKIN + "'" +
        //                                ",@EMPFMDTL_CREATEDBY = '" + _obj_smhr_employee.EMPFMDTL_CREATEDBY + "'" +
        //                                ",@EMPFMDTL_CREATEDDATE = '" + Convert.ToDateTime(_obj_smhr_employee.EMPFMDTL_CREATEDDATE).ToString("MM/dd/yyyy") + "'" +
        //                                ",@EMPFMDTL_ANNUALINCOME='" + _obj_smhr_employee.EMPFMDTL_ANNUALINCOME + "'" +
        //                                ",@EMPFMDTL_OCCUPATION='" + _obj_smhr_employee.EMPFMDTL_OCCUPATION + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;

        //        //Modified
        //        case operation.Update_New:
        //            if (ExecuteNonQuery("EXEC USP_SMHR_FAMILYDETAILS_MODIFIED @Operation='" + _obj_smhr_employee.OPERATION + "'" +
        //                                ",@EMPFMDTL_EMP_ID = '" + _obj_smhr_employee.EMPFMDTL_EMP_ID + "'" +
        //                                ",@EMPFMDTL_SERIAL = '" + _obj_smhr_employee.EMPFMDTL_SERIAL + "'" +
        //                                ",@EMPFMDTL_EMPREL_ID = '" + _obj_smhr_employee.EMPFMDTL_EMPREL_ID + "'" +
        //                                ",@EMPFMDTL_NAME = '" + _obj_smhr_employee.EMPFMDTL_NAME + "'" +
        //                                ",@EMPFMDTL_RELDOB = '" + _obj_smhr_employee.EMPFMDTL_RELDOB + "'" +
        //                                ",@EMPFMDTL_RELDEPENDENT = '" + _obj_smhr_employee.EMPFMDTL_RELDEPENDENT + "'" +
        //                                ",@EMPFMDTL_RELEMERGENCY = '" + _obj_smhr_employee.EMPFMDTL_EMERGENCYCONTACT + "'" +
        //                                ",@EMPFMDTL_RELNEXTTOKIN = '" + _obj_smhr_employee.EMPFMDTL_ISNEXTTOKIN + "'" +
        //                                ",@EMPFMDTL_CREATEDBY = '" + _obj_smhr_employee.EMPFMDTL_CREATEDBY + "'" +
        //                                ",@EMPFMDTL_CREATEDDATE = '" + Convert.ToDateTime(_obj_smhr_employee.EMPFMDTL_CREATEDDATE).ToString("MM/dd/yyyy") + "'" +
        //                                ",@EMPFMDTL_ANNUALINCOME='" + _obj_smhr_employee.EMPFMDTL_ANNUALINCOME + "'" +
        //                                ",@EMPFMDTL_OCCUPATION='" + _obj_smhr_employee.EMPFMDTL_OCCUPATION + "'" +
        //                                ",@EMPFMDTL_ID = '" + _obj_smhr_employee.EMPFMDTL_ID + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //    }
        //    return status;
        //}

        public static DataTable get_EmployeeFamily(SMHR_EMPLOYEE _obj_smhr_employee)
        {
            if (_obj_smhr_employee.OPERATION == operation.Select)
            {
                return ExecuteQuery(" EXEC USP_SMHR_EMPFAMILYDETAILS @Operation = 'check'");
            }
            else if (_obj_smhr_employee.OPERATION == operation.Check_New)
            {
                return ExecuteQuery(" EXEC USP_SMHR_EMPFAMILYDETAILS @Operation = 'Check_New', @EMPFMDTL_EMP_ID = '" + _obj_smhr_employee.EMPFMDTL_EMP_ID + "'");
            }

            else
            {
                return ExecuteQuery(" EXEC USP_SMHR_EMPFAMILYDETAILS @Operation = 'check', @EMPFMDTL_EMP_ID = '" + _obj_smhr_employee.EMPFMDTL_EMP_ID + "'");
            }
        }

        public static bool set_EmployeeSwipe(SMHR_EMPLOYEE _obj_smhr_employee)
        {
            bool status = false;
            switch (_obj_smhr_employee.OPERATION)
            {
                case operation.Insert:
                    if (ExecuteNonQuery(" EXEC USP_SMHR_EMPLOYEESWIPEMASTER @Operation = '" + _obj_smhr_employee.OPERATION + "'" +
                                        ",@EMPSWM_EMP_ID = '" + _obj_smhr_employee.EMPSWM_EMP_ID + "'" +
                                        ",@EMPSWM_SERIAL = '" + _obj_smhr_employee.EMPSWM_SERIAL + "'" +
                                        ",@EMPSWM_CARDCODE = '" + _obj_smhr_employee.EMPSWM_CARDCODE + "'" +
                                        ",@EMPSWM_CARDISSUE = '" + _obj_smhr_employee.EMPSWM_CARDISSUE + "'" +
                                        ",@EMPSWM_CARDEXPIRY = '" + _obj_smhr_employee.EMPSWM_CARDEXPIRY + "'" +
                                        ",@EMPSWM_REMARKS = '" + _obj_smhr_employee.EMPSWM_REMARKS + "'" +
                                        ",@EMPSWM_CREATEDBY = '" + _obj_smhr_employee.EMPSWM_CREATEDBY + "'" +
                                        ",@EMPSWM_CREATEDDATE = '" + Convert.ToDateTime(_obj_smhr_employee.EMPSWM_CREATEDDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case operation.Update:
                    if (ExecuteNonQuery(" EXEC USP_SMHR_EMPLOYEESWIPEMASTER @Operation = '" + _obj_smhr_employee.OPERATION + "'" +
                                        ",@EMPSWM_EMP_ID = '" + _obj_smhr_employee.EMPSWM_EMP_ID + "'" +
                                        ",@EMPSWM_SERIAL = '" + _obj_smhr_employee.EMPSWM_SERIAL + "'" +
                                        ",@EMPSWM_CARDCODE = '" + _obj_smhr_employee.EMPSWM_CARDCODE + "'" +
                                        ",@EMPSWM_CARDISSUE = '" + _obj_smhr_employee.EMPSWM_CARDISSUE + "'" +
                                        ",@EMPSWM_CARDEXPIRY = '" + _obj_smhr_employee.EMPSWM_CARDEXPIRY + "'" +
                                        ",@EMPSWM_REMARKS = '" + _obj_smhr_employee.EMPSWM_REMARKS + "'" +
                                        ",@EMPSWM_LASTMDFBY = '" + _obj_smhr_employee.EMPSWM_LASTMDFBY + "'" +
                                        ",@EMPSWM_LASTMDFDATE = '" + Convert.ToDateTime(_obj_smhr_employee.EMPSWM_LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
                                        ",@EMPSWM_ID = '" + _obj_smhr_employee.EMPSWM_ID + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                default:
                    break;
            }
            return status;
        }

        public static DataTable get_EmployeeSwipe(SMHR_EMPLOYEE _obj_smhr_employee)
        {
            if (_obj_smhr_employee.OPERATION == operation.Select)
            {
                return ExecuteQuery(" EXEC USP_SMHR_EMPLOYEESWIPEMASTER @Operation = 'check'");
            }
            else
            {
                return ExecuteQuery(" EXEC USP_SMHR_EMPLOYEESWIPEMASTER @Operation = 'check', @EMPSWM_EMP_ID = '" + _obj_smhr_employee.EMPSWM_EMP_ID + "'");
            }
        }

        public static bool set_EmpOTInfo(SMHR_EMPLOYEE _obj_smhr_employee)
        {
            bool status = false;
            switch (_obj_smhr_employee.OPERATION)
            {
                case operation.Insert:
                    if (ExecuteNonQuery(" EXEC USP_SMHR_EMPLOYEEOTRATE @Operation = '" + _obj_smhr_employee.OPERATION + "'" +
                                        ",@EMPOTR_EMP_ID = '" + _obj_smhr_employee.EMPOTR_EMP_ID + "'" +
                                        ",@EMPOTR_OTTYPE_ID = '" + _obj_smhr_employee.EMPOTR_OTTYPE_ID + "'" +
                                        ",@EMPOTR_OTRATE = '" + _obj_smhr_employee.EMPOTR_OTRATE + "'" +
                                        ",@EMPOTR_CREATEDBY = '" + _obj_smhr_employee.EMPOTR_CREATEDBY + "'" +
                                        ",@EMPOTR_CREATEDDATE = '" + Convert.ToDateTime(_obj_smhr_employee.EMPOTR_CREATEDDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case operation.Update:
                    if (ExecuteNonQuery(" EXEC USP_SMHR_EMPLOYEEOTRATE @Operation = '" + _obj_smhr_employee.OPERATION + "'" +
                                        ",@EMPOTR_EMP_ID = '" + _obj_smhr_employee.EMPOTR_EMP_ID + "'" +
                                        ",@EMPOTR_OTTYPE_ID = '" + _obj_smhr_employee.EMPOTR_OTTYPE_ID + "'" +
                                        ",@EMPOTR_OTRATE = '" + _obj_smhr_employee.EMPOTR_OTRATE + "'" +
                                        ",@EMPOTR_LASTMDFBY = '" + _obj_smhr_employee.EMPOTR_LASTMDFBY + "'" +
                                        ",@EMPOTR_LASTMDFDATE = '" + Convert.ToDateTime(_obj_smhr_employee.EMPOTR_LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
                                        ",@EMPOTR_ID = '" + _obj_smhr_employee.EMPOTR_ID + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                default:
                    break;
            }
            return status;
        }

        public static DataTable get_EmpOTRate(SMHR_EMPLOYEE _obj_smhr_employee)
        {
            if (_obj_smhr_employee.OPERATION == operation.Select)
            {
                if (_obj_smhr_employee.EMPWOFF_ID.ToString() == "0")
                {
                    return ExecuteQuery("EXEC USP_SMHR_EMPLOYEEOTRATE @Operation = 'select'");
                }
                else
                {
                    return ExecuteQuery("EXEC USP_SMHR_EMPLOYEEOTRATE @Operation = 'select', @EMPOTR_ID = '" + _obj_smhr_employee.EMPOTR_ID + "'");
                }
            }
            else
            {
                return ExecuteQuery("EXEC USP_SMHR_EMPLOYEEOTRATE @Operation = 'Empty', @EMPOTR_EMP_ID = '" + _obj_smhr_employee.EMPOTR_EMP_ID + "'");

            }

        }

        public static DataTable get_EmpWeeklyoff(SMHR_EMPLOYEE _obj_smhr_employee)
        {
            if (_obj_smhr_employee.OPERATION == operation.Select)
            {
                if (_obj_smhr_employee.EMPWOFF_ID.ToString() == "0")
                {
                    return ExecuteQuery(" EXEC USP_SMHR_EMPLOYEEWEEKLYOFF @Operation = 'select'");
                }
                else
                {
                    return ExecuteQuery(" EXEC USP_SMHR_EMPLOYEEWEEKLYOFF @Operation = 'select', @EMPWOFF_ID = '" + _obj_smhr_employee.EMPWOFF_ID + "'");
                }
            }
            else
            {
                return ExecuteQuery(" EXEC USP_SMHR_EMPLOYEEWEEKLYOFF @Operation = 'select', @EMPWOFF_EMP_ID = '" + _obj_smhr_employee.EMPWOFF_EMP_ID + "'");
            }
        }

        public static bool set_EmpWeeklyoff(SMHR_EMPLOYEE _obj_smhr_employee)
        {
            bool status = false;
            switch (_obj_smhr_employee.OPERATION)
            {
                case operation.Insert:
                    if (ExecuteNonQuery(" EXEC USP_SMHR_EMPLOYEEWEEKLYOFF @Operation = '" + _obj_smhr_employee.OPERATION + "'" +
                                        ",@EMPWOFF_EMP_ID = '" + _obj_smhr_employee.EMPWOFF_EMP_ID + "'" +
                                        ",@EMPWOFF_DAY_ID = '" + _obj_smhr_employee.EMPWOFF_DAY_ID + "'" +
                                        ",@EMPWOFF_CREATEDBY  = '" + _obj_smhr_employee.EMPWOFF_CREATEDBY + "'" +
                                        ",@EMPWOFF_CREATEDDATE = '" + Convert.ToDateTime(_obj_smhr_employee.EMPWOFF_CREATEDDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case operation.Update:
                    if (ExecuteNonQuery(" EXEC USP_SMHR_EMPLOYEEWEEKLYOFF @Operation = '" + _obj_smhr_employee.OPERATION + "'" +
                                        ",@EMPWOFF_EMP_ID = '" + _obj_smhr_employee.EMPWOFF_EMP_ID + "'" +
                                        ",@EMPWOFF_DAY_ID = '" + _obj_smhr_employee.EMPWOFF_DAY_ID + "'" +
                                        ",@EMPWOFF_LASTMDFBY = '" + _obj_smhr_employee.EMPWOFF_LASTMDFBY + "'" +
                                        ",@EMPWOFF_LASTMDFDATE = '" + Convert.ToDateTime(_obj_smhr_employee.EMPWOFF_LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
                                        ",@EMPWOFF_ID = '" + _obj_smhr_employee.EMPWOFF_ID + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                default:
                    break;
            }
            return status;
        }

        #endregion

        #region SMHR_RECRUITMENT_COST

        public static bool set_SMHR_RECRUITMENT_COST(SMHR_RECRUITMENT_COST _obj_smhr_recruitment_cost)
        {
            bool status = false;
            switch (_obj_smhr_recruitment_cost.OPERATION)
            {
                case operation.Insert:
                    if (ExecuteNonQuery(" EXEC USP_SMHR_RECRUITMENT_COST @Operation = '" + _obj_smhr_recruitment_cost.OPERATION + "'"
                        //+ ",@COST_ID = " + _obj_smhr_recruitment_cost.COST_ID
                                        + ",@COST_REQ_ID = " + _obj_smhr_recruitment_cost.COST_REQ_ID
                                        + ",@COST_TYPE_ID = " + _obj_smhr_recruitment_cost.COST_TYPE_ID
                                        + ",@COST_AMOUNT = " + _obj_smhr_recruitment_cost.COST_AMOUNT
                                        + ",@COST_FILEPATH = '" + _obj_smhr_recruitment_cost.COST_FILEPATH
                                        + "',@COST_DATE = '" + _obj_smhr_recruitment_cost.COST_DATE
                                        + "',@COST_CREATED_BY = " + _obj_smhr_recruitment_cost.CREATEDBY
                                        + ",@COST_CREATED_DATE = '" + _obj_smhr_recruitment_cost.CREATEDDATE
                                        + "',@COST_BU_ID = " + _obj_smhr_recruitment_cost.BUID))
                        status = true;
                    else
                        status = false;
                    break;

                case operation.Update:
                    if (ExecuteNonQuery(" EXEC USP_SMHR_RECRUITMENT_COST @Operation = '" + _obj_smhr_recruitment_cost.OPERATION + "'"
                                        + ",@COST_ID = " + _obj_smhr_recruitment_cost.COST_ID
                                        + ",@COST_REQ_ID = " + _obj_smhr_recruitment_cost.COST_REQ_ID
                                        + ",@COST_TYPE_ID = " + _obj_smhr_recruitment_cost.COST_TYPE_ID
                                        + ",@COST_AMOUNT = " + _obj_smhr_recruitment_cost.COST_AMOUNT
                                        + ",@COST_FILEPATH = '" + _obj_smhr_recruitment_cost.COST_FILEPATH
                                        + "',@COST_DATE = '" + _obj_smhr_recruitment_cost.COST_DATE
                                        + "',@COST_MODIFIED_BY = " + _obj_smhr_recruitment_cost.LASTMDFBY
                                        + ",@COST_MODIFIED_DATE = '" + _obj_smhr_recruitment_cost.LASTMDFDATE + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                default:
                    break;
            }
            return status;
        }

        public static DataTable get_SMHR_RECRUITMENT_COST(SMHR_RECRUITMENT_COST _obj_smhr_recruitment_cost)
        {
            //DataTable dtRC = new DataTable();
            //dtRC = ExecuteQuery("EXEC USP_SMHR_RECRUITMENT_COST, @OPERATION='GET_REC_COST'" + _obj_smhr_recruitment_cost.COST_ID);
            //return dtRC;
            return ExecuteQuery("EXEC USP_SMHR_RECRUITMENT_COST @OPERATION='GET_REC_COST',@COST_ID = " + _obj_smhr_recruitment_cost.COST_ID);
        }

        public static DataTable get_All_SMHR_RECRUITMENT_COST(SMHR_RECRUITMENT_COST _obj_smhr_recruitment_cost)
        {
            //if (_obj_smhr_recruitment_cost.OPERATION == operation.load)
            //{
            //    DataTable dtRC = new DataTable();
            //    dtRC = ExecuteQuery("EXEC USP_SMHR_RECRUITMENT_COST, @OPERATION='LOAD_REC_COST'");
            //    return dtRC;
            //}
            return ExecuteQuery("EXEC USP_SMHR_RECRUITMENT_COST @OPERATION='LOAD_REC_COST',@JOBREQ_ORGANISATION_ID='" + _obj_smhr_recruitment_cost .ORGANISATION_ID+ "'");
        }

        public static DataTable checkRecCostExists(SMHR_RECRUITMENT_COST _obj_smhr_recruitment_cost)
        {
            return ExecuteQuery("EXEC USP_SMHR_RECRUITMENT_COST @Operation = 'CHECKEXISTS',@COST_REQ_ID = " + _obj_smhr_recruitment_cost.COST_REQ_ID + ",@COST_TYPE_ID = " + _obj_smhr_recruitment_cost.COST_TYPE_ID + ",@COST_BU_ID = " + _obj_smhr_recruitment_cost.BUID);
        }

        public static DataTable Get_Job_Requistion_Dropdown(RECRUITMENT_JOBREQUISITION _obj_Rec_JobRequisition)
        {
            return ExecuteQuery("EXEC USP_SMHR_JOBREQUISITION @Mode = '" + _obj_Rec_JobRequisition.MODE + "',@JOBREQ_ORGANISATION_ID = " + _obj_Rec_JobRequisition.JOBREQ_ORGANISATION_ID);
        }

        #endregion
        
        #region RECRUITMENT_GETEMPLOYEE

        public static DataTable get_Employee(RECRUITMENT_GETEMPLOYEE _obj_Rec_GetEmployee)
        {
            DataTable dt = new DataTable();
            switch (_obj_Rec_GetEmployee.Mode)
            {


                case 1:
                    dt = ExecuteQuery("EXEC USP_SMHR_GETEMPLOYEE @MODE = 1 ,@APPRO_BU_ID= " + Convert.ToString(_obj_Rec_GetEmployee.APPRO_BU_ID) +
                                      "   ");

                    break;
                case 3:
                    dt = ExecuteQuery("EXEC USP_SMHR_GETEMPLOYEE @MODE = 3 ,@APPRO_BU_ID= " + Convert.ToString(_obj_Rec_GetEmployee.APPRO_BU_ID) +
                                      " ,@APPRO_EMP_ID= " + Convert.ToString(_obj_Rec_GetEmployee.APPRO_EMP_ID) + " ,@APPRO_APPROVER1_ID= " + Convert.ToString(_obj_Rec_GetEmployee.APPRO_APPROVER1_ID) +
                                     "  ");


                    break;
                case 2:
                    dt = ExecuteQuery("EXEC USP_SMHR_GETEMPLOYEE @MODE = 2 ,@APPRO_BU_ID= " + Convert.ToString(_obj_Rec_GetEmployee.APPRO_BU_ID) +
                                      " ,@APPRO_EMP_ID= " + Convert.ToString(_obj_Rec_GetEmployee.APPRO_EMP_ID) + "   ");


                    break;


                default:
                    break;
            }
            return dt;
        }

        #endregion

        #region RECRUITMENT_INTERVIEWASSESSMENTFORM

        public static DataTable get_InterviewAssessment(RECRUITMENT_INTERVIEWASSESSMENTFORM _obj_Rec_InterviewAssessmentForm)
        {
            DataTable Dt = new DataTable();

            if (_obj_Rec_InterviewAssessmentForm.MODE == 3)
            {

                Dt = ExecuteQuery("EXEC USP_SMHR_INTERVIEWASSESSMENTFORM @MODE = '" + _obj_Rec_InterviewAssessmentForm.MODE + "'");
            }
            else if (_obj_Rec_InterviewAssessmentForm.MODE == 4)
            {
                Dt = ExecuteQuery("EXEC USP_SMHR_INTERVIEWASSESSMENTFORM @MODE = '" + _obj_Rec_InterviewAssessmentForm.MODE + "', @IAF_APPLID = '" + _obj_Rec_InterviewAssessmentForm.IAF_APPLID + "'");
            }
            else if (_obj_Rec_InterviewAssessmentForm.MODE == 5)
            {
                Dt = ExecuteQuery("EXEC USP_SMHR_INTERVIEWASSESSMENTFORM @MODE = '" + _obj_Rec_InterviewAssessmentForm.MODE + "'");
            }
            else if (_obj_Rec_InterviewAssessmentForm.MODE == 6)
            {
                Dt = ExecuteQuery("EXEC USP_SMHR_INTERVIEWASSESSMENTFORM @MODE = '" + _obj_Rec_InterviewAssessmentForm.MODE + "',@IAF_APPLID = '" + _obj_Rec_InterviewAssessmentForm.IAF_APPLID + "'");
            }
            else if (_obj_Rec_InterviewAssessmentForm.MODE == 7)
            {
                Dt = ExecuteQuery("EXEC USP_SMHR_INTERVIEWASSESSMENTFORM @MODE = '" + _obj_Rec_InterviewAssessmentForm.MODE + "',@IAF_APPLID = '" + _obj_Rec_InterviewAssessmentForm.IAF_APPLID + "',@IAF_JOBREID = '" + _obj_Rec_InterviewAssessmentForm.IAF_JOBREID + "'");
            }
            else if (_obj_Rec_InterviewAssessmentForm.MODE == 8)
            {
                Dt = ExecuteQuery("EXEC USP_SMHR_INTERVIEWASSESSMENTFORM @MODE = '" + _obj_Rec_InterviewAssessmentForm.MODE + "',@IAF_APPLID = '" + _obj_Rec_InterviewAssessmentForm.IAF_APPLID + "',@IAF_JOBREID = '" + _obj_Rec_InterviewAssessmentForm.IAF_JOBREID + "',@IAF_ORGANISATION_ID= '" + _obj_Rec_InterviewAssessmentForm.IAF_ORGANISATION_ID + "'");
            }
            else if (_obj_Rec_InterviewAssessmentForm.MODE == 9)
            {
                Dt = ExecuteQuery("EXEC USP_SMHR_INTERVIEWASSESSMENTFORM @MODE = '" + _obj_Rec_InterviewAssessmentForm.MODE
                                    + "',@IAF_ORGANISATION_ID = '" + _obj_Rec_InterviewAssessmentForm.ORGANISATION_ID
                                    + "',@ASSESSMENT_TYPE = '" + _obj_Rec_InterviewAssessmentForm.ASSESSMENT_TYPE
                                    + "',@ASSESSMENT_APPLICABLEFOR= '" + _obj_Rec_InterviewAssessmentForm.ASSESSMENT_APPLICABLEFOR + "'");
            }
            else if (_obj_Rec_InterviewAssessmentForm.MODE == 10)
            {
                Dt = ExecuteQuery("EXEC USP_SMHR_INTERVIEWASSESSMENTFORM @MODE = '" + _obj_Rec_InterviewAssessmentForm.MODE + "',@IAF_APPLID = '" + _obj_Rec_InterviewAssessmentForm.IAF_APPLID + "'");
            }
            else if (_obj_Rec_InterviewAssessmentForm.MODE == 11)
            {
                Dt = ExecuteQuery("EXEC USP_SMHR_INTERVIEWASSESSMENTFORM @MODE = '" + _obj_Rec_InterviewAssessmentForm.MODE
                                    + "',@IAF_ORGANISATION_ID = '" + _obj_Rec_InterviewAssessmentForm.ORGANISATION_ID
                                    + "',@IAF_JOBREID= '" + _obj_Rec_InterviewAssessmentForm.IAF_JOBREID + "'");
            }
            else if (_obj_Rec_InterviewAssessmentForm.MODE == 16)
            {
                Dt = ExecuteQuery("EXEC USP_SMHR_INTERVIEWASSESSMENTFORM @MODE = '" + _obj_Rec_InterviewAssessmentForm.MODE
                                    + "',@IAF_ORGANISATION_ID = '" + _obj_Rec_InterviewAssessmentForm.ORGANISATION_ID
                                    + "'");
            }
            return Dt;

        }

        public static bool set_InterviewAssessment(RECRUITMENT_INTERVIEWASSESSMENTFORM _obj_Rec_InterviewAssessmentForm, string Str)
        {
            bool status = false;
            switch (_obj_Rec_InterviewAssessmentForm.MODE)
            {
                case 1:

                    if (ExecuteNonQuery(Str))
                        status = true;
                    else
                        status = false;
                    break;
                case 2:
                    if (ExecuteNonQuery(Str))
                        status = true;
                    else
                        status = false;
                    break;
                default:
                    break;
            }
            return status;

        }
        public static bool set_InterviewAssessmentnew(RECRUITMENT_INTERVIEWASSESSMENTFORM _obj_Rec_InterviewAssessmentForm)
        {
            bool status = false;
            switch (_obj_Rec_InterviewAssessmentForm.MODE)
            {
                case 1:

                    if (ExecuteNonQuery("Exec USP_SMHR_INTERVIEWASSESSMENTFORM @MODE = 1 , @IAF_APPLID = '" + _obj_Rec_InterviewAssessmentForm.IAF_APPLID
                                                + "',@IAF_JOBREID = '" + _obj_Rec_InterviewAssessmentForm.IAF_JOBREID
                                                + "',@IAF_ADDLCOMMENTS = '" + _obj_Rec_InterviewAssessmentForm.IAF_ADDLCOMMENTS
                                                + "',@IAF_APPROVE = '" + _obj_Rec_InterviewAssessmentForm.IAF_APPROVE
                                                + "',@IAF_ORGANISATION_ID = '" + _obj_Rec_InterviewAssessmentForm.IAF_ORGANISATION_ID
                                                + "',@IAF_CREATEDBY = '" + _obj_Rec_InterviewAssessmentForm.IAF_CREATEDBY
                                                + "',@IAF_PHASEDEFID ='" + _obj_Rec_InterviewAssessmentForm.IAF_PHASEDEFID + "'"))
                        status = true;
                    else
                        status = false;
                    break;

                default:
                    break;
            }
            return status;
        }
        public static bool set_IAF_GeneralInfo(RECRUITMENT_IAF_GENERALINFO _obj_IAF_GeneralInfo)
        {
            bool status = false;
            switch (_obj_IAF_GeneralInfo.MODE)
            {
                case 1:
                    if (ExecuteNonQuery("Exec USP_SMHR_IAF_GENERALINFO @MODE = 1 , @IAF_GENERALINFO_IAFID = '" + _obj_IAF_GeneralInfo.IAF_GENERALINFO_IAFID
                                               + "',@IAF_GENERALINFO_EXPECTEDCTC = '" + _obj_IAF_GeneralInfo.IAF_GENERALINFO_EXPECTEDCTC
                                               + "',@IAF_GENERALINFO_AVAILABILITY = '" + _obj_IAF_GeneralInfo.IAF_GENERALINFO_AVAILABILITY
                                               + "',@IAF_GENERALINFO_ONSITE = '" + _obj_IAF_GeneralInfo.IAF_GENERALINFO_ONSITE
                                               + "',@IAF_GENERALINFO_RELOCATION = '" + _obj_IAF_GeneralInfo.IAF_GENERALINFO_RELOCATION
                                               + "',@IAF_GENERALINFO_PASSPORT = '" + _obj_IAF_GeneralInfo.IAF_GENERALINFO_PASSPORT
                                               + "',@IAF_GENERALINFO_RELEXP = '" + _obj_IAF_GeneralInfo.IAF_GENERALINFO_RELEXP
                                               + "'"))
                        status = true;
                    else
                        status = false;
                    break;

                default:
                    break;
            }
            return status;
        }
        public static DataTable get_IAF_GeneralInfo(RECRUITMENT_IAF_GENERALINFO _obj_IAF_GeneralInfo)
        {
            DataTable Dt = new DataTable();
            Dt = ExecuteQuery("EXEC USP_SMHR_IAF_GENERALINFO @MODE =2, @JOBREQ_ID= '" + _obj_IAF_GeneralInfo.JOBREQ_ID
                                    + "',@APPLICANT_ID = '" + _obj_IAF_GeneralInfo.APPLICANT_ID + "'");
            return Dt;
        }
        public static bool set_IAF_Rating(RECRUITMENT_IAF_RATING _obj_IAF_Rating)
        {
            bool status = false;
            switch (_obj_IAF_Rating.MODE)
            {
                case 1:
                    if (ExecuteNonQuery("Exec USP_SMHR_IAF_RATING @MODE = 1 , @IAF_RATING_IAF_ID = '" + _obj_IAF_Rating.IAF_RATING_IAF_ID
                                               + "',@IAF_RATING_ASSESSMENT_TYPE = '" + _obj_IAF_Rating.IAF_RATING_ASSESSMENT_TYPE
                                               + "',@IAF_RATING_ASSESSMNET_ID = '" + _obj_IAF_Rating.IAF_RATING_ASSESSMNET_ID
                                               + "',@IAF_RATING_RATING = '" + _obj_IAF_Rating.IAF_RATING_RATING
                                               + "',@IAF_RATING_REMARKS = '" + _obj_IAF_Rating.IAF_RATING_REMARKS
                                               + "'"))
                        status = true;
                    else
                        status = false;
                    break;

                default:
                    break;
            }
            return status;
        }
        #endregion

        #region RECRUITMENT_JOBREQUISITION

        /// <summary>
        ///  Method to Get Job Requisition Based on the JOBREQ_ID
        /// </summary>
        /// <param name="JOBREQ_ID"></param>
        /// <returns>Datatable with Job Requisition Information</returns>
        /// <remarks>
        ///  Author             : Deepika 
        ///  Created on         :  2010-07-06
        ///  Last Modified on   : N/A
        ///  Last Modfied by    : N/A
        /// </remarks>
        public static DataTable get_JobRequisition(RECRUITMENT_JOBREQUISITION _obj_Rec_JobRequisition)
        {

            if (_obj_Rec_JobRequisition.MODE == 1)
            {
                return ExecuteQuery("EXEC USP_SMHR_JOBREQUISITION @Mode = '" + _obj_Rec_JobRequisition.MODE + "'");

            }
            else if (_obj_Rec_JobRequisition.MODE == 12)
            {
                return ExecuteQuery("EXEC USP_SMHR_JOBREQUISITION @Mode = '" + _obj_Rec_JobRequisition.MODE + "' ,@JOBREQ_BUSINESSUNIT_ID ='" + _obj_Rec_JobRequisition.JOBREQ_BUSINESSUNIT_ID + "', @JOBREQ_ORGANISATION_ID = " + _obj_Rec_JobRequisition.JOBREQ_ORGANISATION_ID + " ");
                //  return ExecuteQuery("EXEC USP_SMHR_JOBREQUISITION @Mode = '" + _obj_Rec_JobRequisition.MODE + "' ,@JOBREQ_BUSINESSUNIT_ID ='" + _obj_Rec_JobRequisition.JOBREQ_BUSINESSUNIT_ID + "'");

            }
            else if (_obj_Rec_JobRequisition.MODE == 2)
            {
                return ExecuteQuery("EXEC USP_SMHR_JOBREQUISITION @Mode = '" + _obj_Rec_JobRequisition.MODE + "'");

            }
            else if (_obj_Rec_JobRequisition.MODE == 11)
            {
                return ExecuteQuery("EXEC USP_SMHR_JOBREQUISITION @Mode = '" + _obj_Rec_JobRequisition.MODE + "' ,@INTERVIWERNAME = '" + _obj_Rec_JobRequisition.INTERVIWERNAME + "', @JOBREQ_ORGANISATION_ID = '" + _obj_Rec_JobRequisition.ORGANISATION_ID + "' ");
            }
            else if (_obj_Rec_JobRequisition.MODE == 13)
            {
                return ExecuteQuery("EXEC USP_SMHR_JOBREQUISITION @Mode = '" + _obj_Rec_JobRequisition.MODE + "' ,@INTERVIWERNAME = '" + _obj_Rec_JobRequisition.INTERVIWERNAME + "', @JOBREQ_ORGANISATION_ID = '" + _obj_Rec_JobRequisition.ORGANISATION_ID + "',@JOBREQ_ID='" + _obj_Rec_JobRequisition.JOBREQ_ID + "' ");
            }
            else if (_obj_Rec_JobRequisition.MODE == 14)
            {
                return ExecuteQuery("EXEC USP_SMHR_JOBREQUISITION @Mode = '" + _obj_Rec_JobRequisition.MODE + "' , @JOBREQ_ORGANISATION_ID = '" + _obj_Rec_JobRequisition.ORGANISATION_ID + "',@JOBREQ_ID='" + _obj_Rec_JobRequisition.JOBREQ_ID + "' ");
            }
            else if (_obj_Rec_JobRequisition.MODE == 15)
            {
                return ExecuteQuery("EXEC USP_SMHR_JOBREQUISITION @Mode = '" + _obj_Rec_JobRequisition.MODE + "' , @JOBREQ_ORGANISATION_ID = '" + _obj_Rec_JobRequisition.ORGANISATION_ID + "',@JOBREQ_BUSINESSUNIT_ID='" + _obj_Rec_JobRequisition.JOBREQ_BUSINESSUNIT_ID + "' ");
            }
            else if (_obj_Rec_JobRequisition.MODE == 5)
            {
                return ExecuteQuery("EXEC USP_SMHR_JOBREQUISITION @MODE = '" + _obj_Rec_JobRequisition.MODE + "', @JR_ID = '" + _obj_Rec_JobRequisition.JOBREQ_ID + "' ");
            }
            else if (_obj_Rec_JobRequisition.MODE == 6)
            {
                return ExecuteQuery("EXEC USP_SMHR_JOBREQUISITION @MODE = '" + _obj_Rec_JobRequisition.MODE + "', @JOBREQ_ORGANISATION_ID = '" + _obj_Rec_JobRequisition.ORGANISATION_ID + "' ");
            }
            else if (_obj_Rec_JobRequisition.MODE == 16)
            {
                return ExecuteQuery("EXEC USP_SMHR_JOBREQUISITION @MODE = '" + _obj_Rec_JobRequisition.MODE + "', @JOBREQ_ORGANISATION_ID = '" + _obj_Rec_JobRequisition.ORGANISATION_ID + "',@JOBREQ_DEPARTMENT='" + _obj_Rec_JobRequisition.JOBREQ_DEPARTMENT + "' ");
            }
            else if (_obj_Rec_JobRequisition.MODE == 17)
            {
                return ExecuteQuery("EXEC USP_SMHR_JOBREQUISITION @MODE = '" + _obj_Rec_JobRequisition.MODE + "', @JOBREQ_ORGANISATION_ID = '" + _obj_Rec_JobRequisition.ORGANISATION_ID + "',@JOBREQ_ID='" + _obj_Rec_JobRequisition.JOBREQ_ID + "' ");
            }
            else if (_obj_Rec_JobRequisition.MODE == 18)
            {
                return ExecuteQuery("EXEC USP_SMHR_JOBREQUISITION @MODE = '" + _obj_Rec_JobRequisition.MODE + "', @JOBREQ_ORGANISATION_ID = '" + _obj_Rec_JobRequisition.ORGANISATION_ID + "',@JOBREQ_ID='" + _obj_Rec_JobRequisition.JOBREQ_ID + "' ");
            }
            else if (_obj_Rec_JobRequisition.MODE == 23)
            {
                return ExecuteQuery("EXEC USP_SMHR_JOBREQUISITION @MODE = '23', @JOBREQ_ID = '" + _obj_Rec_JobRequisition.JOBREQ_ID + "' ");
            }
            else if (_obj_Rec_JobRequisition.MODE == 26)
            {
                return ExecuteQuery("EXEC USP_SMHR_JOBREQUISITION @MODE = '26', @JOBREQ_ID = '" + _obj_Rec_JobRequisition.JOBREQ_ID + "' ");
            }
            else if (_obj_Rec_JobRequisition.MODE == 27)
            {
                return ExecuteQuery("EXEC USP_SMHR_JOBREQUISITION @MODE = '27', @JOBREQ_ID = '" + _obj_Rec_JobRequisition.JOBREQ_ID + "' ");
            }
            else if (_obj_Rec_JobRequisition.OPERATION == operation.Select)
            {
                if (_obj_Rec_JobRequisition.JOBREQ_ID.ToString() == "0")
                {
                    return ExecuteQuery("EXEC USP_SMHR_JOBREQUISITION @Operation = 'Select',@JOBREQ_ORGANISATION_ID = " + _obj_Rec_JobRequisition.ORGANISATION_ID + ", @JOBREQ_RAISEDBY =" + Convert.ToString(_obj_Rec_JobRequisition.JOBREQ_RAISEDBY));
                    // @JOBREQ_BUSINESSUNIT_ID = " + _obj_Rec_JobRequisition.JOBREQ_BUSINESSUNIT_ID + ", 
                }
                else
                {
                    return ExecuteQuery("EXEC USP_SMHR_JOBREQUISITION @Operation = 'Select',@JOBREQ_ORGANISATION_ID = " + _obj_Rec_JobRequisition.ORGANISATION_ID + ", @JOBREQ_ID = '" + _obj_Rec_JobRequisition.JOBREQ_ID + "' ");
                }

            }
            else if (_obj_Rec_JobRequisition.MODE == 20)
            {
                if (_obj_Rec_JobRequisition.JOBREQ_ID.ToString() == "0")
                    return ExecuteQuery("EXEC USP_SMHR_JOBREQUISITION @Operation = 'Check', @JOBREQ_REQNAME ='" + Convert.ToString(_obj_Rec_JobRequisition.JOBREQ_REQNAME) + "',@JOBREQ_ORGANISATION_ID = " + _obj_Rec_JobRequisition.JOBREQ_ORGANISATION_ID + "");
                else
                    return ExecuteQuery("EXEC USP_SMHR_JOBREQUISITION @Operation = 'Check', @JOBREQ_REQNAME ='" + Convert.ToString(_obj_Rec_JobRequisition.JOBREQ_REQNAME) + "', @JOBREQ_ID =" + Convert.ToString(_obj_Rec_JobRequisition.JOBREQ_ID) + ",@JOBREQ_ORGANISATION_ID = " + _obj_Rec_JobRequisition.ORGANISATION_ID + "");
            }
            else
            {
                if (_obj_Rec_JobRequisition.JOBREQ_ID.ToString() == "0")
                    return ExecuteQuery("EXEC USP_SMHR_JOBREQUISITION @Operation = 'Check', @JOBREQ_REQNAME ='" + Convert.ToString(_obj_Rec_JobRequisition.JOBREQ_REQNAME) + "',@JOBREQ_ORGANISATION_ID = " + _obj_Rec_JobRequisition.JOBREQ_ORGANISATION_ID + "");
                else
                    return ExecuteQuery("EXEC USP_SMHR_JOBREQUISITION @Operation = 'Check', @JOBREQ_REQNAME ='" + Convert.ToString(_obj_Rec_JobRequisition.JOBREQ_REQNAME) + "', @JOBREQ_ID =" + Convert.ToString(_obj_Rec_JobRequisition.JOBREQ_ID) + ",@JOBREQ_ORGANISATION_ID = " + _obj_Rec_JobRequisition.ORGANISATION_ID + "");
            }
        }


        public static DataTable get_OfferLetterCheck(RECRUITMENT_JOBOFFERS _obj_Smhr_jobOffer)
        {
            DataTable DT = new DataTable();
            if (_obj_Smhr_jobOffer.MODE == 1)
            {
                DT = ExecuteQuery("EXEC USP_SMHR_JOBOFFERS @Mode =1,@joboffrs_reqcode='" + _obj_Smhr_jobOffer.JOBOFFRS_REQCODE + "'");

            }
            return DT;

        }

        public static DataTable get_JrCode(RECRUITMENT_JOBREQUISITION _obj_Rec_JobRequisition)
        {
            return ExecuteQuery(" EXEC USP_SMHR_JOBREQUISITION @Operation = 'load',@ORGANISATION_ID = '" + _obj_Rec_JobRequisition.ORGANISATION_ID + "'");
        }

        public static DataTable get_Applicant(RECRUITMENT_JOBOFFERS _obj_Smhr_jobOffer)
        {
            if (_obj_Smhr_jobOffer.OPERATION == operation.Check)
            {
                return ExecuteQuery(" EXEC USP_SMHR_JOBOFFERS @Operation = 'Check',@JOBOFFRS_APPLICANT_ID = '" + _obj_Smhr_jobOffer.JOBOFFRS_APPLICANT_ID + "'");
            }
            else
            {
                return ExecuteQuery(" EXEC USP_SMHR_JOBOFFERS @Operation = 'Check',@JOBOFFRS_APPLICANT_ID = '" + _obj_Smhr_jobOffer.JOBOFFRS_APPLICANT_ID + "', @JOBOFFRS_ID =" + Convert.ToString(_obj_Smhr_jobOffer.JOBOFFRS_ID));

            }
        }

        public static DataTable get_JobRequisition_jrid(RECRUITMENT_JOBREQUISITION _obj_Rec_JobRequisition)
        {
            return ExecuteQuery("EXEC USP_SMHR_JR_SKILLS @Mode = '5'");
        }

        public static DataTable get_JobReqDetails(RECRUITMENT_JOBREQUISITION _obj_Rec_JobRequisition)
        {

            if (_obj_Rec_JobRequisition.OPERATION == operation.load)
            {
                return ExecuteQuery("EXEC USP_SMHR_JOBOFFERS @operation='load',@JOBREQ_ID='" + _obj_Rec_JobRequisition.JOBREQ_ID + "'");

            }
            else if (_obj_Rec_JobRequisition.OPERATION == operation.loadapplicant)
            {
                return ExecuteQuery("EXEC USP_SMHR_JOBOFFERS @operation='loadapplicant',@APPLICANT_ID='" + _obj_Rec_JobRequisition.APPLICANT + "'");
            }


            else if (_obj_Rec_JobRequisition.OPERATION == operation.Empty)
            {
                if (_obj_Rec_JobRequisition.JOBREQ_ID.ToString() == "0")
                {
                    return ExecuteQuery("EXEC USP_SMHR_JOBREQUISITION @Operation = 'Empty',@JOBREQ_ORGANISATION_ID = '" + _obj_Rec_JobRequisition.ORGANISATION_ID + "'");

                }
                else
                {
                    return ExecuteQuery("EXEC USP_SMHR_JOBREQUISITION @Operation = 'Empty',@JOBREQ_ID = '" + _obj_Rec_JobRequisition.JOBREQ_ID + "'");
                }

            }
            else if (_obj_Rec_JobRequisition.OPERATION == operation.Empty1)
            {
                return ExecuteQuery("EXEC USP_SMHR_JOBREQUISITION @Operation = 'Empty1',@JOBREQ_ORGANISATION_ID = '" + _obj_Rec_JobRequisition.ORGANISATION_ID + "'");
            }
            else
            {
                if (_obj_Rec_JobRequisition.JOBREQ_ID.ToString() == "0")
                    return ExecuteQuery("EXEC USP_SMHR_JOBREQUISITION @Operation = 'Check', @JOBREQ_REQCODE ='" + Convert.ToString(_obj_Rec_JobRequisition.JOBREQ_REQCODE) + "'");
                else
                    return ExecuteQuery("EXEC USP_SMHR_JOBREQUISITION @Operation = 'Check', @JOBREQ_REQCODE ='" + Convert.ToString(_obj_Rec_JobRequisition.JOBREQ_REQCODE) + "', @JOBREQ_ID =" + Convert.ToString(_obj_Rec_JobRequisition.JOBREQ_ID));
            }



        }

        /// <summary>
        /// Method to Insert or update into the SMHR_JOBREQUISITION table Using Information Passed using the Object. 
        /// </summary>
        /// <param name="_obj_Rec_JobRequisition"></param>
        /// <returns>Boolean stating the Success or failure</returns>
        /// <remarks>
        ///  Author             : Deepika 
        ///  Created on         : 2010-07-06
        ///  Last Modified on   : N/A
        ///  Last Modfied by    : N/A
        /// </remarks>
        public static bool set_JobRequisition(RECRUITMENT_JOBREQUISITION _obj_Rec_JobRequisition)
        {
            bool status = false;
            switch (_obj_Rec_JobRequisition.OPERATION)
            {
                case operation.Insert:
                    if (ExecuteNonQuery("EXEC USP_SMHR_JOBREQUISITION @Operation = 'Insert', @JOBREQ_REQCODE='" + _obj_Rec_JobRequisition.JOBREQ_REQCODE
                                      + "', @JOBREQ_REQNAME='" + _obj_Rec_JobRequisition.JOBREQ_REQNAME

                                      + "', @JOBREQ_REQEXPIRY='" + (_obj_Rec_JobRequisition.JOBREQ_REQEXPIRY)
                        // + "', @JOBREQ_REQEXPIRY=" + Convert.ToDateTime(_obj_Rec_JobRequisition.JOBREQ_REQEXPIRY)+ ""
                                      + "', @JOBREQ_RAISEDBY=" + _obj_Rec_JobRequisition.JOBREQ_RAISEDBY
                                      + " , @JOBREQ_STATUS='" + _obj_Rec_JobRequisition.JOBREQ_STATUS
                                      + "', @JOBREQ_BUSINESSUNIT_ID=" + _obj_Rec_JobRequisition.JOBREQ_BUSINESSUNIT_ID
                                      + " , @JOBREQ_DEPARTMENT=" + _obj_Rec_JobRequisition.JOBREQ_DEPARTMENT
                                      + " , @JOBREQ_DESIGNATION=" + _obj_Rec_JobRequisition.JOBREQ_DESIGNATION
                                      + " , @JOBREQ_APPROVALSTATUS=" + _obj_Rec_JobRequisition.JOBREQ_APPROVALSTATUS
                                      + " , @JOBREQ_POSITIONS=" + _obj_Rec_JobRequisition.JOBREQ_OPENINGS
                                      + " , @JOBREQ_EXPYEARS=" + _obj_Rec_JobRequisition.JOBREQ_EXPYEARS
                                      + " , @JOBREQ_ISYEARSREQ='" + _obj_Rec_JobRequisition.JOBREQ_ISYEARSREQ
                                      + "', @JOBREQ_QUALIFICATION=" + _obj_Rec_JobRequisition.JOBREQ_QUALIFICATION
                                      + ", @JOBREQ_AppCTC=" + _obj_Rec_JobRequisition.JOBREQ_AppCTC
                                      + " , @JOBREQ_ISQUALREQ='" + _obj_Rec_JobRequisition.JOBREQ_ISQUALREQ
                        //+ "' , @JOBREQ_ISBUSINESSUNIT='" + _obj_Rec_JobRequisition.JOBREQ_ISBUSINESSUNIT
                                      + "', @JOBREQ_PERCENTAGE='" + _obj_Rec_JobRequisition.JOBREQ_PERCENTAGE
                        //+ " , @JOBREQ_ISPERCENTAGEREQ='" + _obj_Rec_JobRequisition.JOBREQ_ISPERCENTAGEREQ
                        //+ "', @JOREQ_SKILL=" + _obj_Rec_JobRequisition.JOREQ_SKILL
                        //+ " ', @JOBREQ_ISSKILLREQ='" + _obj_Rec_JobRequisition.JOBREQ_ISSKILLREQ
                                      + "', @JOBREQ_COMMENTS='" + _obj_Rec_JobRequisition.JOBREQ_COMMENTS
                                       + "', @JOBREQ_BUDGETESTIMATION='" + _obj_Rec_JobRequisition.JOBREQ_BUDGETESTIMATION
                                      + "', @JOBREQ_CREATEDBY= " + Convert.ToString(_obj_Rec_JobRequisition.CREATEDBY)
                                      + " , @JOBREQ_CREATEDDATE='" + Convert.ToDateTime(_obj_Rec_JobRequisition.CREATEDDATE).ToString("MM/dd/yyyy")
                                      + "', @JOBREQ_LASTMDFBY ='" + Convert.ToString(_obj_Rec_JobRequisition.LASTMDFBY)
                                      + " ', @JOBREQ_LASTMDFDATE='" + Convert.ToDateTime(_obj_Rec_JobRequisition.LASTMDFDATE).ToString("MM/dd/yyyy")
                        //   + "' , @JOBREQ_ACTUALCLOSEDDATE='" + Convert.ToDateTime(_obj_Rec_JobRequisition.JOBREQ_ACTUALCLOSEDDATE).ToString("MM/dd/yyyy")
                                      + "', @JOBREQ_ORGANISATION_ID=" + _obj_Rec_JobRequisition.JOBREQ_ORGANISATION_ID
                                      + ", @JOBREQ_REQFOR ='" + Convert.ToString(_obj_Rec_JobRequisition.JOBREQ_REQFOR)
                                      + "', @JOBREQ_REQTOWORK = '" + Convert.ToString(_obj_Rec_JobRequisition.JOBREQ_REQTOWORK)
                                      + "', @JOBREQ_INTERVIEWER = '" + Convert.ToString(_obj_Rec_JobRequisition.JOBREQ_INTERVIEWER)
                                      + "', @JOBREQ_GRADE = '" + Convert.ToInt32(_obj_Rec_JobRequisition.JOBREQ_GRADE)
                                      + "', @JOBREQ_LOCATION = '" + Convert.ToString(_obj_Rec_JobRequisition.JOBREQ_LOCATION)
                                      + "', @JOBREQ_EMPTYPE = '" + Convert.ToString(_obj_Rec_JobRequisition.JOBREQ_EMPTYPE)
                                      + "', @JOBREQ_RECRUITMENTFOR = '" + Convert.ToString(_obj_Rec_JobRequisition.JOBREQ_RECRUITMENTFOR)
                                      + "', @JOBREQ_PERIOD_ID = " + Convert.ToInt32(_obj_Rec_JobRequisition.JOBREQ_PERIOD_ID)))


                        //if (ExecuteNonQuery("EXEC USP_SMHR_JOBREQUISITION @Operation = 'Insert' , @JOBREQ_REQCODE='" + _obj_Rec_JobRequisition.JOBREQ_REQCODE
                        //                 + "', @JOBREQ_REQNAME='" + _obj_Rec_JobRequisition.JOBREQ_REQNAME

                        //                 + "', @JOBREQ_REQEXPIRY='" + Convert.ToDateTime(_obj_Rec_JobRequisition.JOBREQ_REQEXPIRY).ToString("MM/dd/yyyy") + ""
                        //                 + "', @JOBREQ_RAISEDBY=" + _obj_Rec_JobRequisition.JOBREQ_RAISEDBY
                        //                 + " , @JOBREQ_STATUS='" + _obj_Rec_JobRequisition.JOBREQ_STATUS
                        //                 + "', @JOBREQ_BUSINESSUNIT_ID=" + _obj_Rec_JobRequisition.JOBREQ_BUSINESSUNIT_ID
                        //                 + " , @JOBREQ_DEPARTMENT=" + _obj_Rec_JobRequisition.JOBREQ_DEPARTMENT
                        //                 + " , @JOBREQ_DESIGNATION=" + _obj_Rec_JobRequisition.JOBREQ_DESIGNATION
                        //                 + " , @JOBREQ_APPROVALSTATUS=" + _obj_Rec_JobRequisition.JOBREQ_APPROVALSTATUS
                        //                 + " , @JOBREQ_POSITIONS=" + _obj_Rec_JobRequisition.JOBREQ_OPENINGS
                        //                 + " , @JOBREQ_EXPYEARS=" + _obj_Rec_JobRequisition.JOBREQ_EXPYEARS
                        //                 + " , @JOBREQ_ISYEARSREQ='" + _obj_Rec_JobRequisition.JOBREQ_ISYEARSREQ
                        //                 + "', @JOBREQ_QUALIFICATION='" + _obj_Rec_JobRequisition.JOBREQ_QUALIFICATION
                        //                  + "',@JOBREQ_AppCTC=" + _obj_Rec_JobRequisition.JOBREQ_AppCTC
                        //                 + " , @JOBREQ_ISQUALREQ='" + _obj_Rec_JobRequisition.JOBREQ_ISQUALREQ

                        //   //+ "', @JOBREQ_ISBUSINESSUNIT='" + _obj_Rec_JobRequisition.JOBREQ_ISBUSINESSUNIT
                        //                 + "', @JOBREQ_PERCENTAGE='" + _obj_Rec_JobRequisition.JOBREQ_PERCENTAGE
                        //    //+ " , @JOBREQ_ISPERCENTAGEREQ='" + _obj_Rec_JobRequisition.JOBREQ_ISPERCENTAGEREQ
                        //    //+ ", @JOREQ_SKILL=" + _obj_Rec_JobRequisition.JOREQ_SKILL
                        //    //+ "', @JOBREQ_ISSKILLREQ='" + _obj_Rec_JobRequisition.JOBREQ_ISSKILLREQ
                        //                 + "', @JOBREQ_COMMENTS='" + _obj_Rec_JobRequisition.JOBREQ_COMMENTS
                        //                 + "', @JOBREQ_BUDGETESTIMATION='" + _obj_Rec_JobRequisition.JOBREQ_BUDGETESTIMATION
                        //                 + "', @JOBREQ_LASTMDFBY =" + Convert.ToString(_obj_Rec_JobRequisition.LASTMDFBY)
                        //                + " , @JOBREQ_LASTMDFDATE='" + Convert.ToDateTime(_obj_Rec_JobRequisition.LASTMDFDATE).ToString("MM/dd/yyyy")
                        //    //  + "' ,@JOBREQ_ACTUALCLOSEDDATE=  " + (_obj_Rec_JobRequisition.JOBREQ_ACTUALCLOSEDDATE == null ? "null" : "'" + _obj_Rec_JobRequisition.JOBREQ_ACTUALCLOSEDDATE + "'")
                        //            //    + "' ,@JOBREQ_ACTUALCLOSEDDATE=  " + (_obj_Rec_JobRequisition.JOBREQ_ACTUALCLOSEDDATE == null ? "null" : "'" + Convert.ToDateTime(_obj_Rec_JobRequisition.JOBREQ_ACTUALCLOSEDDATE).ToString("MM/dd/yyyy") + "'")
                        //                 + "', @JOBREQ_ORGANISATION_ID=" + _obj_Rec_JobRequisition.JOBREQ_ORGANISATION_ID + ""))



                        status = true;
                    else
                        status = false;
                    break;
                case operation.Update:
                    if (ExecuteNonQuery("EXEC USP_SMHR_JOBREQUISITION @Operation = 'Update',@JOBREQ_ID=" + Convert.ToString(_obj_Rec_JobRequisition.JOBREQ_ID)
                                      + " , @JOBREQ_REQCODE='" + _obj_Rec_JobRequisition.JOBREQ_REQCODE
                                      + "', @JOBREQ_REQNAME='" + _obj_Rec_JobRequisition.JOBREQ_REQNAME

                                      + "', @JOBREQ_REQEXPIRY='" + Convert.ToDateTime(_obj_Rec_JobRequisition.JOBREQ_REQEXPIRY).ToString("MM/dd/yyyy") + ""
                                      + "', @JOBREQ_RAISEDBY=" + _obj_Rec_JobRequisition.JOBREQ_RAISEDBY
                                      + " , @JOBREQ_STATUS='" + _obj_Rec_JobRequisition.JOBREQ_STATUS
                                      + "', @JOBREQ_BUSINESSUNIT_ID=" + _obj_Rec_JobRequisition.JOBREQ_BUSINESSUNIT_ID
                                      + " , @JOBREQ_DEPARTMENT=" + _obj_Rec_JobRequisition.JOBREQ_DEPARTMENT
                                      + " , @JOBREQ_DESIGNATION=" + _obj_Rec_JobRequisition.JOBREQ_DESIGNATION
                                      + " , @JOBREQ_APPROVALSTATUS=" + _obj_Rec_JobRequisition.JOBREQ_APPROVALSTATUS
                                      + " , @JOBREQ_POSITIONS=" + _obj_Rec_JobRequisition.JOBREQ_OPENINGS
                                      + " , @JOBREQ_EXPYEARS=" + _obj_Rec_JobRequisition.JOBREQ_EXPYEARS
                                      + " , @JOBREQ_ISYEARSREQ='" + _obj_Rec_JobRequisition.JOBREQ_ISYEARSREQ
                                      + "', @JOBREQ_QUALIFICATION='" + _obj_Rec_JobRequisition.JOBREQ_QUALIFICATION
                                       + "',@JOBREQ_AppCTC=" + _obj_Rec_JobRequisition.JOBREQ_AppCTC
                                      + " , @JOBREQ_ISQUALREQ='" + _obj_Rec_JobRequisition.JOBREQ_ISQUALREQ

                        //+ "', @JOBREQ_ISBUSINESSUNIT='" + _obj_Rec_JobRequisition.JOBREQ_ISBUSINESSUNIT
                                      + "', @JOBREQ_PERCENTAGE='" + _obj_Rec_JobRequisition.JOBREQ_PERCENTAGE
                        //+ " , @JOBREQ_ISPERCENTAGEREQ='" + _obj_Rec_JobRequisition.JOBREQ_ISPERCENTAGEREQ
                        //+ ", @JOREQ_SKILL=" + _obj_Rec_JobRequisition.JOREQ_SKILL
                        //+ "', @JOBREQ_ISSKILLREQ='" + _obj_Rec_JobRequisition.JOBREQ_ISSKILLREQ
                                      + "', @JOBREQ_COMMENTS='" + _obj_Rec_JobRequisition.JOBREQ_COMMENTS
                                      + "', @JOBREQ_BUDGETESTIMATION='" + _obj_Rec_JobRequisition.JOBREQ_BUDGETESTIMATION
                                      + "', @JOBREQ_LASTMDFBY =" + Convert.ToString(_obj_Rec_JobRequisition.LASTMDFBY)
                                     + " , @JOBREQ_LASTMDFDATE='" + Convert.ToDateTime(_obj_Rec_JobRequisition.LASTMDFDATE).ToString("MM/dd/yyyy")
                        //  + "' ,@JOBREQ_ACTUALCLOSEDDATE=  " + (_obj_Rec_JobRequisition.JOBREQ_ACTUALCLOSEDDATE == null ? "null" : "'" + _obj_Rec_JobRequisition.JOBREQ_ACTUALCLOSEDDATE + "'")
                                     + "' ,@JOBREQ_ACTUALCLOSEDDATE=  " + (_obj_Rec_JobRequisition.JOBREQ_ACTUALCLOSEDDATE == null ? "null" : "'" + Convert.ToDateTime(_obj_Rec_JobRequisition.JOBREQ_ACTUALCLOSEDDATE).ToString("MM/dd/yyyy") + "'")
                                      + ", @JOBREQ_ORGANISATION_ID=" + _obj_Rec_JobRequisition.JOBREQ_ORGANISATION_ID
                                      + ", @JOBREQ_REQFOR ='" + Convert.ToString(_obj_Rec_JobRequisition.JOBREQ_REQFOR)
                                      + "', @JOBREQ_REQTOWORK = '" + Convert.ToString(_obj_Rec_JobRequisition.JOBREQ_REQTOWORK)
                                      + "', @JOBREQ_INTERVIEWER = '" + Convert.ToString(_obj_Rec_JobRequisition.JOBREQ_INTERVIEWER)
                                      + "', @JOBREQ_GRADE = '" + Convert.ToInt32(_obj_Rec_JobRequisition.JOBREQ_GRADE)
                                      + "', @JOBREQ_LOCATION = '" + Convert.ToString(_obj_Rec_JobRequisition.JOBREQ_LOCATION)
                                      + "', @JOBREQ_EMPTYPE = '" + Convert.ToString(_obj_Rec_JobRequisition.JOBREQ_EMPTYPE)
                                      + "', @JOBREQ_RECRUITMENTFOR = '" + Convert.ToString(_obj_Rec_JobRequisition.JOBREQ_RECRUITMENTFOR) 
                                      + "', @JOBREQ_PERIOD_ID = " + Convert.ToInt32(_obj_Rec_JobRequisition.JOBREQ_PERIOD_ID)))


                        status = true;

                    else
                        status = false;

                    break;
                case operation.Check1:
                    if (ExecuteNonQuery("EXEC USP_SMHR_JOBREQUISITION @Operation = 'Check1', @JOBREQ_APPROVEDBY=" + Convert.ToInt32(_obj_Rec_JobRequisition.JOBREQ_APPROVEDBY)
                                      + ", @JOBREQ_ID=" + Convert.ToString(_obj_Rec_JobRequisition.JOBREQ_ID)
                                      + " , @JOBREQ_APPROVEDDATE='" + Convert.ToDateTime(_obj_Rec_JobRequisition.JOBREQ_APPROVEDDATE).ToString("MM/dd/yyyy")
                                      + "', @JOBREQ_APPROVALSTATUS=" + _obj_Rec_JobRequisition.JOBREQ_APPROVALSTATUS
                                      + ",@JOBREQ_CURRENTSTATUS='" + _obj_Rec_JobRequisition.JOBREQ_CURRENTSTATUS
                                      + "' , @JOBREQ_LASTMDFBY =" + Convert.ToString(_obj_Rec_JobRequisition.LASTMDFBY)
                                      + " , @JOBREQ_LASTMDFDATE='" + _obj_Rec_JobRequisition.LASTMDFDATE.ToString("MM/dd/yyyy")
                                      + "', @JOBREQ_LEVEL = " + _obj_Rec_JobRequisition.JOBREQ_LEVEL))
                        status = true;
                    else
                        status = false;
                    break;
                case operation.Insert1:
                    if (ExecuteNonQuery("EXEC USP_SMHR_JOBREQUISITION @Operation = 'Insert1', @JOBREQ_ID=" + Convert.ToInt32(_obj_Rec_JobRequisition.JOBREQ_ID)
                                      + ", @JOBREQ_CURRENTSTATUS='" + Convert.ToString(_obj_Rec_JobRequisition.JOBREQ_CURRENTSTATUS)
                                      + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case operation.Insert2:
                    if (ExecuteNonQuery("EXEC USP_SMHR_JOBREQUISITION @Operation = 'Insert2', @JOBREQ_APPLICANT=" + Convert.ToInt32(_obj_Rec_JobRequisition.APPLICANT)
                                      + ", @JOBREQ_CURRENTSTATUS='" + Convert.ToString(_obj_Rec_JobRequisition.JOBREQ_CURRENTSTATUS)
                                      + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                default:
                    break;
            }
            return status;
        }
        /// <summary>
        /// Method to fetch Employees based on BusinessUnit Selection into the SMHR_JOBREQUISITION table Using Information Passed using the Object. 
        /// </summary>
        /// <param name="_obj_Rec_JobRequisition"></param>
        /// <returns>Boolean stating the Success or failure</returns>
        /// <remarks>
        ///  Author             : Anand 
        ///  Created on         : 2013-11-15
        ///  Last Modified on   : N/A
        ///  Last Modfied by    : N/A
        /// </remarks>
        /// 
        public static DataTable get_EmployeeBySearchString(int OrganizationID, int BusinessUntiID, string EMPSearchString)
        {
            return ExecuteQuery("EXEC USP_SMHR_GETEMPLOYEES @ORGANISATION_ID=" + OrganizationID
                                + ",@BUSINESSUNIT_ID =" + BusinessUntiID
                                + ",@SEARCH_STRING='" + EMPSearchString + "'");
        }

        /// <summary>
        /// Method to fetch Employees vacancy count based on Position Selection Using Information Passed by the Object. 
        /// </summary>
        /// <param name="objEmpPositions"></param>
        /// <remarks>
        ///  Author             : Anand 
        ///  Created on         : 2013-11-16
        ///  Last Modified on   : N/A
        ///  Last Modfied by    : N/A
        /// </remarks>
        /// 
        public static int GetEmpVacancyCount(SMHR_POSITIONS objEmpPositions)
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["connection"].ToString(), CommandType.Text, "EXEC USP_GET_EMP_VACANCY_COUNT @Operation = '"
                + objEmpPositions.OPERATION
                + "',@ORGANISATION_ID = " + objEmpPositions.ORGANISATION_ID
                + ", @POSITION_ID = " + objEmpPositions.POSITIONS_ID
                +",@PERIOD_ID="+objEmpPositions.POSITIN_PERIOD_ID));
        }

        /// <summary>
        /// Method to fetch Employees Types from SMHR_EMPLOYEETYPE table using Information Passed by the Object. 
        /// </summary>
        /// <param name="_obj_Rec_JobRequisition"></param>
        /// <returns>Boolean stating the Success or failure</returns>
        /// <remarks>
        ///  Author             : Anand 
        ///  Created on         : 2013-11-18
        ///  Last Modified on   : N/A
        ///  Last Modfied by    : N/A
        /// </remarks>
        /// 
        public static DataTable GetEmpType(RECRUITMENT_JOBREQUISITION _obj_Rec_JobRequisition)
        {
            return ExecuteQuery("EXEC USP_SMHR_EMPLOYEETYPE @Operation = '" + _obj_Rec_JobRequisition.OPERATION
                                + "',@EMPLOYEETYPE_ORGANISATION_ID = " + _obj_Rec_JobRequisition.ORGANISATION_ID);
        }

        /// <summary>
        /// Method to fetch Department of the selected Employee from SMHR_EMPLOYEE, SMHR_DEPARTMENT tables.
        /// </summary>
        /// <param name="_obj_Rec_JobRequisition"></param>
        /// <returns>Employee Department</returns>
        /// <remarks>
        ///  Author             : Anand 
        ///  Created on         : 2013-11-18
        ///  Last Modified on   : N/A
        ///  Last Modfied by    : N/A
        /// </remarks>
        /// 
        public static DataTable GetEmpDept(RECRUITMENT_JOBREQUISITION _obj_Rec_JobRequisition)
        {
            return ExecuteQuery("EXEC USP_SMHR_DEPARTMENT @MODE = 17, @EMP_ID = " + _obj_Rec_JobRequisition.JOBREQ_RAISEDBY);
        }

        /// <summary>
        /// Method to fetch Directorate of the selected Employee from SMHR_Directorate table.
        /// </summary>
        /// <param name="_obj_Rec_JobRequisition"></param>
        /// <returns>Employee Department</returns>
        /// <remarks>
        ///  Author             : Anand 
        ///  Created on         : 2013-11-27
        ///  Last Modified on   : N/A
        ///  Last Modfied by    : N/A
        /// </remarks>
        /// 
        public static DataTable GetEmpDirectorate(RECRUITMENT_JOBREQUISITION _obj_Rec_JobRequisition)
        {
            return ExecuteQuery("EXEC USP_SMHR_EMPLOYEE @OPERATION = '" + _obj_Rec_JobRequisition.OPERATION + "', @EMP_ID = "
                + _obj_Rec_JobRequisition.JOBREQ_RAISEDBY
                + ", @ORGANISATION_ID = " + _obj_Rec_JobRequisition.ORGANISATION_ID);
        }


        /// <summary>
        /// Method to fetch Employees from SMHR_EMPLOYEE, SMHR_APPLICANT by JOB_REQID.
        /// </summary>
        /// <param name="_obj_Rec_JobRequisition"></param>
        /// <returns>Employees</returns>
        /// <remarks>
        ///  Author             : Anand 
        ///  Created on         : 2013-11-19
        ///  Last Modified on   : N/A
        ///  Last Modfied by    : N/A
        /// </remarks>
        /// 
        public static DataTable GetEmployees(SMHR_JOBREQUISITION objGetEmp)
        {
            return ExecuteQuery("EXEC USP_SMHR_GETEMPLOYEES @JOBREQ_ID = " + objGetEmp.JOBREQ_ID);
        }

        public static DataTable GetPosition(RECRUITMENT_JOBREQUISITION _obj_Rec_JobRequisition)
        {
            return ExecuteQuery("EXEC USP_SMHR_JOBREQUISITION @Mode ='19', @JOBREQ_ORGANISATION_ID = " + _obj_Rec_JobRequisition.JOBREQ_ORGANISATION_ID
                + ",@JOBREQ_ID=" + _obj_Rec_JobRequisition.JOBREQ_ID);
        }

        #endregion

        #region RECRUITMENT_JOB_REQUISITION_APPROVAL
        public static bool get_JobReqAprover(RECRUITMENT_JOBREQUISITION _obj_Rec_JobRequisition)
        {
            bool status4 = false;
            if (ExecuteNonQuery("EXEC USP_SMHR_RECRUITMENT_MAIL @MODE='" + _obj_Rec_JobRequisition.MODE + "', @JOBREQID ='" + _obj_Rec_JobRequisition.JOBREQ_ID +
                                    "', @ORGANISATION_ID= " + Convert.ToString(_obj_Rec_JobRequisition.JOBREQ_ORGANISATION_ID) + " "))
            {
                status4 = true;

                return status4;
            }
            else
                return status4;
            //if (ExecuteNonQuery("EXEC USP_SMHR_RECRUITMENT_MAIL @EMPID= " + Convert.ToString(_obj_Rec_JobRequisition.JOBREQ_RAISEDBY) + " "));
            //{
            //    status4 = true;

            //    return status4;
            //}
        }

        public static bool get_JobReqAprover1(RECRUITMENT_JOBREQUISITION _obj_Rec_JobRequisition)
        {
            bool status4 = false;
            if (ExecuteNonQuery("EXEC USP_SMHR_Appvr1ToApprv2_MAIL @EMPID= " + Convert.ToString(_obj_Rec_JobRequisition.JOBREQ_RAISEDBY) + " ")) ;
            {
                status4 = true;

                return status4;
            }
        }

        #endregion

        #region RECRUITMENT_INTERVIEW_PHASE_DEF

        public static DataTable get_InterviewPhaseDefinition(RECRUITMENT_INTERVIEW_PHASE_DEF _obj_Rec_Interview_Phase_Def)
        {
            DataTable Dt = new DataTable();
            if (_obj_Rec_Interview_Phase_Def.Mode == 3)
            {
                Dt = ExecuteQuery("EXEC USP_SMHR_INTERVIEW_PHASE_DEF @MODE = '" + _obj_Rec_Interview_Phase_Def.Mode + "', @PHASE_ORGANISATION_ID =" + _obj_Rec_Interview_Phase_Def.PHASE_ORGANISATION_ID + "");
            }
            else if (_obj_Rec_Interview_Phase_Def.Mode == 4)
            {
                Dt = ExecuteQuery("EXEC USP_SMHR_INTERVIEW_PHASE_DEF @MODE = '" + _obj_Rec_Interview_Phase_Def.Mode + "', @PHASE_ID ='" + _obj_Rec_Interview_Phase_Def.Phase_ID + "', @PHASE_ORGANISATION_ID =" + _obj_Rec_Interview_Phase_Def.PHASE_ORGANISATION_ID + " ");
            }
            else if (_obj_Rec_Interview_Phase_Def.Mode == 5)
            {
                Dt = ExecuteQuery("EXEC USP_SMHR_INTERVIEW_PHASE_DEF @MODE = '" + _obj_Rec_Interview_Phase_Def.Mode + "', @PHASE_JOBREQID ='" + _obj_Rec_Interview_Phase_Def.Phase_JobReqID + "',@PHASE_NAME ='" + _obj_Rec_Interview_Phase_Def.Phase_Name + "',@PHASE_ORGANISATION_ID =" + _obj_Rec_Interview_Phase_Def.PHASE_ORGANISATION_ID + " ");

            }
            else if (_obj_Rec_Interview_Phase_Def.Mode == 6)
            {
                Dt = ExecuteQuery("EXEC USP_SMHR_INTERVIEW_PHASE_DEF @MODE = '" + _obj_Rec_Interview_Phase_Def.Mode + "', @PHASE_JOBREQID ='" + _obj_Rec_Interview_Phase_Def.Phase_JobReqID + "'");

            }
            else if (_obj_Rec_Interview_Phase_Def.Mode == 7)
            {
                Dt = ExecuteQuery("EXEC USP_SMHR_INTERVIEW_PHASE_DEF @MODE = '" + _obj_Rec_Interview_Phase_Def.Mode + "', @PHASE_JOBREQID ='" + _obj_Rec_Interview_Phase_Def.Phase_JobReqID + "',@IAF_APPLID = '" + _obj_Rec_Interview_Phase_Def.Applicant + "',@PHASE_INTERVIEWERNAME ='" + _obj_Rec_Interview_Phase_Def.PHASE_INTERVIEWERNAME + "',@PHASE_ORGANISATION_ID =" + _obj_Rec_Interview_Phase_Def.PHASE_ORGANISATION_ID + " ");

            }
            else if (_obj_Rec_Interview_Phase_Def.Mode == 8)
            {
                Dt = ExecuteQuery("EXEC USP_SMHR_INTERVIEW_PHASE_DEF @MODE = '" + _obj_Rec_Interview_Phase_Def.Mode + "', @PHASE_JOBREQID ='" + _obj_Rec_Interview_Phase_Def.Phase_JobReqID + "', @PHASE_ORGANISATION_ID =" + _obj_Rec_Interview_Phase_Def.PHASE_ORGANISATION_ID + "");
            }
            else if (_obj_Rec_Interview_Phase_Def.Mode == 9)
            {
                Dt = ExecuteQuery("EXEC USP_SMHR_INTERVIEW_PHASE_DEF @MODE = '" + _obj_Rec_Interview_Phase_Def.Mode + "', @JOBREID ='" + _obj_Rec_Interview_Phase_Def.Phase_JobReqID + "'");
            }
            else if (_obj_Rec_Interview_Phase_Def.Mode == 10)
            {
                Dt = ExecuteQuery("EXEC USP_SMHR_INTERVIEW_PHASE_DEF @MODE = '" + _obj_Rec_Interview_Phase_Def.Mode + "', @PHASE_JOBREQID ='" + _obj_Rec_Interview_Phase_Def.Phase_JobReqID + "',@PHASE_INTERVIEWERNAME ='" + _obj_Rec_Interview_Phase_Def.PHASE_INTERVIEWERNAME + "', @PHASE_ORGANISATION_ID =" + _obj_Rec_Interview_Phase_Def.PHASE_ORGANISATION_ID + "");
            }
            else if (_obj_Rec_Interview_Phase_Def.Mode == 11)
            {
                Dt = ExecuteQuery("EXEC USP_SMHR_INTERVIEW_PHASE_DEF @MODE = '" + _obj_Rec_Interview_Phase_Def.Mode + "', @PHASE_JOBREQID ='" + _obj_Rec_Interview_Phase_Def.Phase_JobReqID + "', @PHASE_ORGANISATION_ID =" + _obj_Rec_Interview_Phase_Def.PHASE_ORGANISATION_ID + "");
            }
            else if (_obj_Rec_Interview_Phase_Def.Mode == 12)
            {
                Dt = ExecuteQuery("EXEC USP_SMHR_INTERVIEW_PHASE_DEF @MODE = '" + _obj_Rec_Interview_Phase_Def.Mode + "', @PHASE_JOBREQID ='" + _obj_Rec_Interview_Phase_Def.Phase_JobReqID + "', @PHASE_ORGANISATION_ID =" + _obj_Rec_Interview_Phase_Def.PHASE_ORGANISATION_ID + "");
            }
            else if (_obj_Rec_Interview_Phase_Def.Mode == 13)
            {
                Dt = ExecuteQuery("EXEC USP_SMHR_INTERVIEW_PHASE_DEF @MODE = '" + _obj_Rec_Interview_Phase_Def.Mode + "', @PHASE_JOBREQID ='" + _obj_Rec_Interview_Phase_Def.Phase_JobReqID + "'");
            }
            else if (_obj_Rec_Interview_Phase_Def.Mode == 15)
            {
                Dt = ExecuteQuery("EXEC USP_SMHR_INTERVIEW_PHASE_DEF @MODE = 15");
            }
            else if (_obj_Rec_Interview_Phase_Def.Mode == 21)
            {
                Dt = ExecuteQuery("EXEC USP_SMHR_INTERVIEW_PHASE_DEF @MODE = '" + _obj_Rec_Interview_Phase_Def.Mode + "', @JOBREID ='" + _obj_Rec_Interview_Phase_Def.Phase_JobReqID + "'");
            }
            if (_obj_Rec_Interview_Phase_Def.Mode == 17)
            {
                Dt = ExecuteQuery("EXEC USP_SMHR_INTERVIEW_PHASE_DEF @MODE =17,@PHASE_DEF_SKILLS_PHASEID='" + _obj_Rec_Interview_Phase_Def.Phase_ID + "'");
            }
            if (_obj_Rec_Interview_Phase_Def.MODE == 20)
            {
                Dt = ExecuteQuery("EXEC USP_SMHR_INTERVIEW_PHASE_DEF @MODE =20,@JOBSKILL_POSITIONSID='" + _obj_Rec_Interview_Phase_Def.Phase_POSID + "'");
            }
            return Dt;
        }




        public static bool set_interview_def_skills(RECRUITMENT_INTERVIEW_PHASE_DEF_SKILLS _obj_Rec_interview_Phase_Def_Skills)
        {
            bool status = false;
            switch (_obj_Rec_interview_Phase_Def_Skills.MODE)
            {
                case 14:
                    if (ExecuteNonQuery("EXEC USP_SMHR_INTERVIEW_PHASE_DEF @MODE='14', @PHASE_DEF_SKILLS_SKILLID = '" + _obj_Rec_interview_Phase_Def_Skills.PHASE_DEF_SKILLS_SKILLID + "'" +
                                        ",@PHASE_DEF_SKILLS_PHASEID = '" + Convert.ToInt32(_obj_Rec_interview_Phase_Def_Skills.PHASE_DEF_SKILLS_PHASEID) + "'" +
                                        ",@PHASE_DEF_SKILLS_CREATEDDATE='" + Convert.ToDateTime(_obj_Rec_interview_Phase_Def_Skills.PHASE_DEF_SKILLS_CREATEDDATE).ToString("MM/dd/yyyy") + "'" +
                                        ",@PHASE_DEF_SKILLS_CREATEDBY='" + Convert.ToInt32(_obj_Rec_interview_Phase_Def_Skills.PHASE_DEF_SKILLS_CREATEDBY) + "'" +
                                         ",@PHASE_DEF_SKILLS_ORGANISATION_ID ='" + Convert.ToInt32(_obj_Rec_interview_Phase_Def_Skills.PHASE_DEF_SKILLS_ORGANISATION_ID) + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case 18:
                    if (ExecuteNonQuery("EXEC USP_SMHR_INTERVIEW_PHASE_DEF @MODE='18', @PHASE_DEF_SKILLS_PHASEID = '" + _obj_Rec_interview_Phase_Def_Skills.PHASE_DEF_SKILLS_PHASEID + "'"))

                        status = true;
                    else
                        status = false;
                    break;
                default:
                    break;
            }
            return status;
        }
        public static bool set_InterviewPhaseDefinition(RECRUITMENT_INTERVIEW_PHASE_DEF _obj_Rec_Interview_Phase_Def)
        {
            bool status = false;
            switch (_obj_Rec_Interview_Phase_Def.Mode)
            {
                case 1:

                    if (ExecuteNonQuery("EXEC USP_SMHR_INTERVIEW_PHASE_DEF @MODE = '1', @PHASE_NAME  ='" + _obj_Rec_Interview_Phase_Def.Phase_Name
                                      + "', @PHASE_DESC ='" + _obj_Rec_Interview_Phase_Def.Phase_Desc
                                      + "', @PHASE_JOBREQID = '" + _obj_Rec_Interview_Phase_Def.Phase_JobReqID
                                      + "', @PHASE_POSID = '" + _obj_Rec_Interview_Phase_Def.Phase_POSID
                                      + "', @PHASE_POSCODE = '" + _obj_Rec_Interview_Phase_Def.Phase_POSCODE
                                      + "', @PHASE_SKILL = '" + _obj_Rec_Interview_Phase_Def.PHASE_SKILL
                                      + "', @PHASE_FINAL = '" + _obj_Rec_Interview_Phase_Def.PHASE_FINAL
                                      + "', @PHASE_BUSINESSUNIT = '" + _obj_Rec_Interview_Phase_Def.PHASE_BUSINESSUNIT
                                      + "', @PHASE_INTERVIEWERNAME = '" + _obj_Rec_Interview_Phase_Def.PHASE_INTERVIEWERNAME
                        //   + "', @PHASE_INTERVIEWDATE = '" + Convert.ToDateTime(_obj_Rec_Interview_Phase_Def.Phase_InterviewDate).ToString("MM/dd/yyyy")

                                     + "', @PHASE_INTERVIEWFROMDATE = " + (_obj_Rec_Interview_Phase_Def.Phase_InterviewFromDate == null ? "null" : "'" + Convert.ToDateTime(_obj_Rec_Interview_Phase_Def.Phase_InterviewFromDate).ToString("MM/dd/yyyy") + "'")
                                     + ", @PHASE_INTERVIEWTODATE = " + (_obj_Rec_Interview_Phase_Def.Phase_InterviewToDate == null ? "null" : "'" + Convert.ToDateTime(_obj_Rec_Interview_Phase_Def.Phase_InterviewToDate).ToString("MM/dd/yyyy") + "'")


                                      + ", @PHASE_PRIORITY = '" + _obj_Rec_Interview_Phase_Def.PHASE_PRIORITY
                                      + "', @PHASE_GRADESET = '" + _obj_Rec_Interview_Phase_Def.PHASE_GRADESET
                                      + "', @PHASE_ORGANISATION_ID = '" + _obj_Rec_Interview_Phase_Def.PHASE_ORGANISATION_ID
                                      + "', @PHASE_CREATEDBY = " + Convert.ToString(_obj_Rec_Interview_Phase_Def.Phase_Createdby)
                                      + " , @PHASE_CREATEDDATE ='" + _obj_Rec_Interview_Phase_Def.Phase_CreatedDate.ToString("MM/dd/yyyy")
                                      + "', @PHASE_LASTMDFBY =" + Convert.ToString(_obj_Rec_Interview_Phase_Def.Phase_LastMdfBy)
                                      + " , @PHASE_LASTMDFDATE ='" + _obj_Rec_Interview_Phase_Def.Phase_LastMdfdate.ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case 2:
                    if (ExecuteNonQuery("EXEC USP_SMHR_INTERVIEW_PHASE_DEF @MODE = '2', @PHASE_NAME ='" + _obj_Rec_Interview_Phase_Def.Phase_Name
                                        + "', @PHASE_ID = '" + _obj_Rec_Interview_Phase_Def.Phase_ID
                                        + "', @PHASE_DESC ='" + _obj_Rec_Interview_Phase_Def.Phase_Desc
                                        + "', @PHASE_JOBREQID = '" + _obj_Rec_Interview_Phase_Def.Phase_JobReqID
                                           + "', @PHASE_POSID = '" + _obj_Rec_Interview_Phase_Def.Phase_POSID
                                        + "', @PHASE_POSCODE = '" + _obj_Rec_Interview_Phase_Def.Phase_POSCODE
                                        + "', @PHASE_SKILL = '" + _obj_Rec_Interview_Phase_Def.PHASE_SKILL
                                        + "', @PHASE_FINAL = '" + _obj_Rec_Interview_Phase_Def.PHASE_FINAL
                                        + "', @PHASE_BUSINESSUNIT = '" + _obj_Rec_Interview_Phase_Def.PHASE_BUSINESSUNIT
                                        + "', @PHASE_INTERVIEWERNAME = '" + _obj_Rec_Interview_Phase_Def.PHASE_INTERVIEWERNAME

                                      // + "', @PHASE_INTERVIEWDATE = '" + Convert.ToDateTime(_obj_Rec_Interview_Phase_Def.Phase_InterviewDate).ToString("MM/dd/yyyy")
                                        + "', @PHASE_INTERVIEWFROMDATE = " + (_obj_Rec_Interview_Phase_Def.Phase_InterviewFromDate == null ? "null" : "'" + Convert.ToDateTime(_obj_Rec_Interview_Phase_Def.Phase_InterviewFromDate).ToString("MM/dd/yyyy") + "'")
                                     + ", @PHASE_INTERVIEWTODATE = " + (_obj_Rec_Interview_Phase_Def.Phase_InterviewToDate == null ? "null" : "'" + Convert.ToDateTime(_obj_Rec_Interview_Phase_Def.Phase_InterviewToDate).ToString("MM/dd/yyyy") + "'")
                                        + ", @PHASE_PRIORITY = '" + _obj_Rec_Interview_Phase_Def.PHASE_PRIORITY
                                        + "', @PHASE_GRADESET = '" + _obj_Rec_Interview_Phase_Def.PHASE_GRADESET
                                        + "', @PHASE_ORGANISATION_ID = '" + _obj_Rec_Interview_Phase_Def.PHASE_ORGANISATION_ID
                                        + "', @PHASE_LASTMDFBY =" + Convert.ToString(_obj_Rec_Interview_Phase_Def.Phase_LastMdfBy)
                                        + " , @PHASE_LASTMDFDATE ='" + _obj_Rec_Interview_Phase_Def.Phase_LastMdfdate + "'"))
                        status = true;
                    else
                        status = false;
                    break;

                default:
                    break;
            }
            return status;
        }

        public static DateTime getRequisitionCreatedDate(RECRUITMENT_JOBREQUISITION _obj_Rec_JobRequisition)
        {
            return Convert.ToDateTime(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["connection"].ToString(), CommandType.Text, "EXEC USP_SMHR_JOBREQUISITION @Mode ="
                            + _obj_Rec_JobRequisition.MODE
                            + ", @JOBREQ_ORGANISATION_ID = " + _obj_Rec_JobRequisition.ORGANISATION_ID
                            + ", @JOBREQ_ID = " + _obj_Rec_JobRequisition.JOBREQ_ID));
        }

        public static bool IsPhaseExists(RECRUITMENT_INTERVIEW_PHASE_DEF _obj_Rec_Interview_Phase_Def)
        {
            return Convert.ToBoolean(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["connection"].ToString(), CommandType.Text, "EXEC USP_SMHR_INTERVIEW_PHASE_DEF @Mode = "
                                      + _obj_Rec_Interview_Phase_Def.Mode
                                      + ",  @PHASE_JOBREQID = " + _obj_Rec_Interview_Phase_Def.Phase_JobReqID
                                      + ",  @PHASE_BUSINESSUNIT = " + _obj_Rec_Interview_Phase_Def.PHASE_BUSINESSUNIT
                                      + ",  @PHASE_INTERVIEWFROMDATE = " + (_obj_Rec_Interview_Phase_Def.Phase_InterviewFromDate == null ? "null" : "'" + Convert.ToDateTime(_obj_Rec_Interview_Phase_Def.Phase_InterviewFromDate).ToString("MM/dd/yyyy") + "'")
                                      + ",  @PHASE_INTERVIEWTODATE = " + (_obj_Rec_Interview_Phase_Def.Phase_InterviewToDate == null ? "null" : "'" + Convert.ToDateTime(_obj_Rec_Interview_Phase_Def.Phase_InterviewToDate).ToString("MM/dd/yyyy") + "'")
                                      + ",  @PHASE_PRIORITY = '" + _obj_Rec_Interview_Phase_Def.PHASE_PRIORITY
                //+ "', @PHASE_POSID = '" + _obj_Rec_Interview_Phase_Def.Phase_POSID
                //+ "', @PHASE_POSCODE = '" + _obj_Rec_Interview_Phase_Def.Phase_POSCODE
                //+ "', @PHASE_SKILL = '" + _obj_Rec_Interview_Phase_Def.PHASE_SKILL
                //+ "', @PHASE_FINAL = '" + _obj_Rec_Interview_Phase_Def.PHASE_FINAL
                //+ "', @PHASE_GRADESET = '" + _obj_Rec_Interview_Phase_Def.PHASE_GRADESET
                                     + "',  @PHASE_ORGANISATION_ID = " + _obj_Rec_Interview_Phase_Def.PHASE_ORGANISATION_ID));
        }


        #endregion

        #region RECRUITMENT_RESUMESHORTLIST

        public static DataTable getApplicants(RECRUITMENT_RESUMESHORTLIST _obj_Rec_ResumeShortList)
        {
            DataTable Dt = new DataTable();
            if (_obj_Rec_ResumeShortList.Mode == 1)
            {
                Dt = ExecuteQuery("EXEC USP_SMHR_RESUMESHORTLIST @MODE = '" + _obj_Rec_ResumeShortList.Mode + "', @JOBREQ_REQCODE ='" + _obj_Rec_ResumeShortList.JOBREQ_REQCODE + "',@RESSHT_ORGANISATION_ID='" + _obj_Rec_ResumeShortList.RESSHT_ORGANISATION_ID + "'");
            }
            else if (_obj_Rec_ResumeShortList.Mode == 2)
            {
                Dt = ExecuteQuery("EXEC USP_SMHR_RESUMESHORTLIST @MODE = '" + _obj_Rec_ResumeShortList.Mode + "', @JOBREQ_REQCODE ='" + _obj_Rec_ResumeShortList.JOBREQ_REQCODE + "',@RESSHT_ORGANISATION_ID='" + _obj_Rec_ResumeShortList.RESSHT_ORGANISATION_ID + "' ");
            }
            else if (_obj_Rec_ResumeShortList.Mode == 3)
            {
                Dt = ExecuteQuery("EXEC USP_SMHR_RESUMESHORTLIST @MODE = '" + _obj_Rec_ResumeShortList.Mode + "', @JOBREQ_REQCODE ='" + _obj_Rec_ResumeShortList.JOBREQ_REQCODE + "',@RESSHT_ORGANISATION_ID='" + _obj_Rec_ResumeShortList.RESSHT_ORGANISATION_ID + "' ");
            }
            else if (_obj_Rec_ResumeShortList.Mode == 4)
            {
                Dt = ExecuteQuery("EXEC USP_SMHR_RESUMESHORTLIST @MODE = '" + _obj_Rec_ResumeShortList.Mode + "', @JOBREQ_REQCODE ='" + _obj_Rec_ResumeShortList.JOBREQ_REQCODE + "',@RESSHT_ORGANISATION_ID='" + _obj_Rec_ResumeShortList.RESSHT_ORGANISATION_ID + "' ");
            }
            else if (_obj_Rec_ResumeShortList.Mode == 5)
            {
                Dt = ExecuteQuery("EXEC USP_SMHR_RESUMESHORTLIST @MODE = '" + _obj_Rec_ResumeShortList.Mode + "', @JOBREQ_REQCODE ='" + _obj_Rec_ResumeShortList.JOBREQ_REQCODE + "',@RESSHT_ORGANISATION_ID='" + _obj_Rec_ResumeShortList.RESSHT_ORGANISATION_ID + "' ");
            }
            else if (_obj_Rec_ResumeShortList.Mode == 6)
            {
                Dt = ExecuteQuery("EXEC USP_SMHR_RESUMESHORTLIST @MODE = '" + _obj_Rec_ResumeShortList.Mode + "', @JOBREQ_REQCODE ='" + _obj_Rec_ResumeShortList.JOBREQ_REQCODE + "',@RESSHT_ORGANISATION_ID='" + _obj_Rec_ResumeShortList.RESSHT_ORGANISATION_ID + "' ");
            }
            else if (_obj_Rec_ResumeShortList.Mode == 7)
            {
                Dt = ExecuteQuery("EXEC USP_SMHR_RESUMESHORTLIST @MODE = '" + _obj_Rec_ResumeShortList.Mode + "', @JOBREQ_REQCODE ='" + _obj_Rec_ResumeShortList.JOBREQ_REQCODE + "',@RESSHT_ORGANISATION_ID='" + _obj_Rec_ResumeShortList.RESSHT_ORGANISATION_ID + "' ");
            }
            else if (_obj_Rec_ResumeShortList.Mode == 8)
            {
                Dt = ExecuteQuery("EXEC USP_SMHR_RESUMESHORTLIST @MODE = '" + _obj_Rec_ResumeShortList.Mode + "',  @RESSHT_APPLID = " + _obj_Rec_ResumeShortList.RESSHT_APPLID + " ");
                //@RESSHT_JOBREQID =" + _obj_Rec_ResumeShortList.RESSHT_JOBREQID + ",
            }
            else if (_obj_Rec_ResumeShortList.Mode == 9)
            {
                Dt = ExecuteQuery("EXEC USP_SMHR_RESUMESHORTLIST @MODE = '" + _obj_Rec_ResumeShortList.Mode +
                                    "', @RESSHT_JOBREQID ='" + _obj_Rec_ResumeShortList.RESSHT_JOBREQID +
                                    "',@RESSHT_ORGANISATION_ID = '" + _obj_Rec_ResumeShortList.ORGANISATION_ID +
                                    "',@PRIORITY='" + _obj_Rec_ResumeShortList.RESSHT_ID + "'");
            }
            else if (_obj_Rec_ResumeShortList.Mode == 10)
            {
                Dt = ExecuteQuery("EXEC USP_SMHR_RESUMESHORTLIST @MODE = '" + _obj_Rec_ResumeShortList.Mode + "',@RESSHT_ORGANISATION_ID = " + _obj_Rec_ResumeShortList.ORGANISATION_ID + ",@RESSHT_JOBREQID ='" + _obj_Rec_ResumeShortList.RESSHT_JOBREQID + "' ");
            }

            return Dt;
        }
        public static bool set_ResumeShortList(RECRUITMENT_RESUMESHORTLIST _obj_Rec_ResumeShortList)
        {
            bool status = false;
            switch (_obj_Rec_ResumeShortList.OPERATION)
            {
                case operation.Insert:
                    if (ExecuteNonQuery("EXEC USP_SMHR_RESUMESHORTLIST @Operation = 'Insert', @RESSHT_JOBREQID =" + _obj_Rec_ResumeShortList.RESSHT_JOBREQID
                                      + ", @RESSHT_APPLID=" + _obj_Rec_ResumeShortList.RESSHT_APPLID
                                      + ",@RESSHT_ISSHORTLIST = '" + Convert.ToBoolean(_obj_Rec_ResumeShortList.RESSHT_ISSHORTLIST)
                                      + "',@RESSHT_ORGANISATION_ID= " + Convert.ToString(_obj_Rec_ResumeShortList.ORGANISATION_ID)

                                      + ", @RESSHT_CREATEDBY= " + Convert.ToString(_obj_Rec_ResumeShortList.CREATEDBY)
                                      + " , @RESSHT_CREATEDDATE='" + Convert.ToDateTime(_obj_Rec_ResumeShortList.CREATEDDATE).ToString("MM/dd/yyyy")
                                      + "', @RESSHT_LASTMDFBY =" + Convert.ToString(_obj_Rec_ResumeShortList.LASTMDFBY)
                                      + " , @RESSHT_LASTMDFDATE='" + Convert.ToDateTime(_obj_Rec_ResumeShortList.LASTMDFDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;
                    break;

                case operation.Update:
                    if (ExecuteNonQuery("EXEC USP_SMHR_RESUMESHORTLIST @Operation = 'Update',@RESSHT_ID=" + _obj_Rec_ResumeShortList.RESSHT_ID
                                      + ",   @RESSHT_JOBREQID =" + _obj_Rec_ResumeShortList.RESSHT_JOBREQID
                                      + ", @RESSHT_APPLID=" + _obj_Rec_ResumeShortList.RESSHT_APPLID

                                       + ",@RESSHT_ISSHORTLIST = '" + Convert.ToBoolean(_obj_Rec_ResumeShortList.RESSHT_ISSHORTLIST)
                                       + "',@RESSHT_ORGANISATION_ID= " + Convert.ToString(_obj_Rec_ResumeShortList.ORGANISATION_ID)

                                      + ", @RESSHT_LASTMDFBY =" + Convert.ToString(_obj_Rec_ResumeShortList.LASTMDFBY)
                                      + " , @RESSHT_LASTMDFDATE='" + Convert.ToDateTime(_obj_Rec_ResumeShortList.LASTMDFDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                default:
                    break;
            }
            return status;
        }

        #endregion

        #region RECRUITMENT_INTERVIEW_PHASE_REMARKS

        public static bool set_InterviewPhaseRemarks(RECRUITMENT_INTERVIEW_PHASE_REMARKS _obj_Rec_InterviewPhaseRemarks)
        {
            bool status = false;

            switch (_obj_Rec_InterviewPhaseRemarks.MODE)
            {
                case 1:

                    if (ExecuteNonQuery("EXEC USP_SMHR_INTERVIEW_PHASE_REMARKS @MODE = '1', @INTREM_JOBREQID = '" + _obj_Rec_InterviewPhaseRemarks.INTREM_JOBREQID
                                      + "', @INTREM_PHASEID = '" + _obj_Rec_InterviewPhaseRemarks.INTREM_PHASEID
                                      + "', @INTREM_APPLICANTID = '" + _obj_Rec_InterviewPhaseRemarks.INTREM_APPLICANTID
                                      + "', @INTREM_OFFEREDSALARY  ='" + _obj_Rec_InterviewPhaseRemarks.INTREM_OFFEREDSALARY
                                      + "' , @INTREM_OVERALLASSESSMENT = '" + _obj_Rec_InterviewPhaseRemarks.INTREM_OVERALLASSESSMENT
                                      + "', @INTREM_JOININGDATE= " + (_obj_Rec_InterviewPhaseRemarks.INTREM_JOININGDATE == null ? "null" : "'" + Convert.ToDateTime(_obj_Rec_InterviewPhaseRemarks.INTREM_JOININGDATE).ToString("MM/dd/yyyy") + "'")
                                      + ", @INTREM_LEVEL =" + _obj_Rec_InterviewPhaseRemarks.INTREM_LEVEL
                                      + ", @INTREM_DESIGNATIONOFFERED = " + _obj_Rec_InterviewPhaseRemarks.INTREM_DESIGNATIONOFFERED
                                      + ", @INTREM_DEPARTMENT = " + _obj_Rec_InterviewPhaseRemarks.INTREM_DEPARTMENT
                                      + ", @INTREM_DIVISION = '" + _obj_Rec_InterviewPhaseRemarks.INTREM_DIVISION
                                      + "', @INTREM_ORGANISATION_ID = '" + _obj_Rec_InterviewPhaseRemarks.INTREM_ORGANISATION_ID
                                      + "', @INTREM_BUSINESSUNIT_ID = '" + _obj_Rec_InterviewPhaseRemarks.BUID
                                      + "', @INTREM_CREATEDBY = '" + Convert.ToString(_obj_Rec_InterviewPhaseRemarks.INTREM_CREATEDBY)
                                      + "', @INTREM_LASTMDFBY ='" + Convert.ToString(_obj_Rec_InterviewPhaseRemarks.INTREM_LASTMDFBY)
                                      + "', @INTREM_STATUS ='" + Convert.ToString(_obj_Rec_InterviewPhaseRemarks.INTREM_STATUS)
                                      + "', @INTREM_JOININGBONUS ='" + Convert.ToDecimal(_obj_Rec_InterviewPhaseRemarks.INTREM_JOININGBONUS)
                                      + "'"))
                        status = true;
                    else
                        status = false;
                    break;
            }
            return status;
        }
        #endregion

        #region RECRUITMENT_SKILLSCATEGARY

        public static DataTable get_skillscategary(RECRUITMENT_SKILLSCATEGARY _obj_Rec_SkillCategary)
        {
            DataTable dt = new DataTable();

            if (_obj_Rec_SkillCategary.MODE == 1)
            {
                dt = ExecuteQuery("EXEC [USP_SMHRSKILLCATEGORY]  @SKILLCAT_ID = " + _obj_Rec_SkillCategary.SKILLCAT_ID +
                                    " , @mode = '" + _obj_Rec_SkillCategary.MODE + "'");
            }
            else if (_obj_Rec_SkillCategary.MODE == 6)
            {
                dt = ExecuteQuery("EXEC [USP_SMHRSKILLCATEGORY]  @SKILLCAT_NAME = '" + _obj_Rec_SkillCategary.SKILLCAT_NAME + "'" +
                                        " , @MODE = '" + _obj_Rec_SkillCategary.MODE + "'" +
                                        ",@SKILL_JR_ID='" + _obj_Rec_SkillCategary.SKILL_JR_ID + "'");
            }
            else if (_obj_Rec_SkillCategary.MODE == 7)
            {
                dt = ExecuteQuery("EXEC [USP_SMHRSKILLCATEGORY]  @SKILLCAT_ORGANISATION_ID = '" + _obj_Rec_SkillCategary.ORGANISATION_ID + "'" +
                                        " , @MODE = '" + _obj_Rec_SkillCategary.MODE + "'");
            }
            else if (_obj_Rec_SkillCategary.MODE == 19)
            {
                dt = ExecuteQuery("EXEC USP_SMHR_INTERVIEW_PHASE_DEF  @MODE = 19,@PHASE_ID='" + _obj_Rec_SkillCategary.PHASE_ID + "'");
            }
            else if (_obj_Rec_SkillCategary.MODE == 8)
            {
                //dt = ExecuteQuery("Exec USP_SMHRSKILLCATEGORY @MODE = '" + _obj_Rec_SkillCategary.MODE + "',@SKILLCAT_NAME ='" + _obj_Rec_SkillCategary.SKILLCAT_NAME + "',@SKILLCAT_ID ='" + _obj_Rec_SkillCategary.SKILLCAT_SKILLID + "'");
                dt = ExecuteQuery("Exec USP_SMHRSKILLCATEGORY @MODE = '" + _obj_Rec_SkillCategary.MODE + "',@SKILLCAT_NAME ='" + _obj_Rec_SkillCategary.SKILLCAT_NAME + "',@SKILLCAT_SKILLID='" + _obj_Rec_SkillCategary.SKILLCAT_SKILLID + "'");
            }
            else
            {
                dt = ExecuteQuery("EXEC[USP_SMHRSKILLCATEGORY] @MODE = '2',  @SKILLCAT_ID = " + _obj_Rec_SkillCategary.SKILLCAT_ID + "");
            }
            return dt;

        }
        public static bool set_skillscategary(RECRUITMENT_SKILLSCATEGARY _obj_Rec_SkillCategary)
        {
            if (_obj_Rec_SkillCategary.MODE == 3)
            {
                return ExecuteNonQuery(" EXEC [USP_SMHRSKILLCATEGORY] @SKILLCAT_SKILLID = '" + _obj_Rec_SkillCategary.SKILLCAT_SKILLID + "'" +
                                        ", @SKILLCAT_NAME = '" + Convert.ToString(_obj_Rec_SkillCategary.SKILLCAT_NAME) + "'" +
                                        ", @SKILLCAT_DESCRIPTION = '" + Convert.ToString(_obj_Rec_SkillCategary.SKILLCAT_DESCRIPTION) + "'" +
                                       ", @SKILLCAT_CREATEDBY= " + Convert.ToString(_obj_Rec_SkillCategary.CREATEDBY) + "" +
                                       ", @SKILLCAT_ORGANISATION_ID= " + _obj_Rec_SkillCategary.ORGANISATION_ID +
                                       " , @SKILLCAT_CREATEDDATE='" + Convert.ToDateTime(_obj_Rec_SkillCategary.CREATEDDATE).ToString("MM/dd/yyyy") + "'" +
                    //", @SKILLCAT_LASTMDFBY =" + Convert.ToString(_obj_Rec_SkillCategary.LASTMDFBY) + "" +
                    // " , @SKILLCAT_LASTMDFDATE='" + Convert.ToDateTime(_obj_Rec_SkillCategary.LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
                                       ", @MODE = '" + _obj_Rec_SkillCategary.MODE + "'");
            }
            else if (_obj_Rec_SkillCategary.MODE == 4)
            {
                return ExecuteNonQuery("EXEC [USP_SMHRSKILLCATEGORY] @SKILLCAT_ID  = '" + _obj_Rec_SkillCategary.SKILLCAT_ID + "'" +
                                       ", @SKILLCAT_SKILLID = '" + _obj_Rec_SkillCategary.SKILLCAT_SKILLID + "'" +
                                         ", @SKILLCAT_NAME = '" + Convert.ToString(_obj_Rec_SkillCategary.SKILLCAT_NAME) + "'" +
                                        ", @SKILLCAT_DESCRIPTION = '" + Convert.ToString(_obj_Rec_SkillCategary.SKILLCAT_DESCRIPTION) + "'" +
                                        ", @SKILLCAT_LASTMDFBY =" + Convert.ToString(_obj_Rec_SkillCategary.LASTMDFBY) + "" +
                                       ", @SKILLCAT_ORGANISATION_ID= " + _obj_Rec_SkillCategary.ORGANISATION_ID +
                                       " , @SKILLCAT_LASTMDFDATE='" + Convert.ToDateTime(_obj_Rec_SkillCategary.LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
                                       ", @MODE = '" + _obj_Rec_SkillCategary.MODE + "'");
            }
            else
            {
                return ExecuteNonQuery(" EXEC [USP_SMHRSKILLCATEGORY]  @MODE = '5',  @SKILLCAT_ID  = '" + _obj_Rec_SkillCategary.SKILLCAT_SKILLID + "'" +
                                        " ");
            }
        }
        #endregion

        #region RECRUITMENT_JOBREQSKILLS

        public static DataTable get_SKILLSJOBREQ(RECRUITMENT_JOBREQSKILLS _obj_Rec_JobReqSkills)
        {
            DataTable Dt = new DataTable();
            if (_obj_Rec_JobReqSkills.MODE == 1)
            {
                Dt = ExecuteQuery("EXEC USP_SMHR_JR_SKILLS @MODE = 1,@JR_ID ='" + Convert.ToInt32(_obj_Rec_JobReqSkills.JR_ID) + "'");
            }
            if (_obj_Rec_JobReqSkills.MODE == 6)
            {
                if (_obj_Rec_JobReqSkills.JR_SKILLS_ID.ToString() == "0")
                    Dt = ExecuteQuery("EXEC USP_SMHR_JR_SKILLS @MODE=6, @SKILL_ID ='" + Convert.ToString(_obj_Rec_JobReqSkills.SKILL_ID) + "', @JR_ID =" + Convert.ToString(_obj_Rec_JobReqSkills.JR_ID));
            }
            else if (_obj_Rec_JobReqSkills.MODE == 7)
            {
                Dt = ExecuteQuery("EXEC USP_SMHR_JR_SKILLS @MODE ='" + _obj_Rec_JobReqSkills.MODE + "',@JR_ID ='" + _obj_Rec_JobReqSkills.JR_ID + "' ");
            }

            return Dt;
        }

        public static bool set_Jr_Skills(RECRUITMENT_JOBREQSKILLS _obj_Rec_JobReqSkills)
        {
            bool status = false;
            switch (_obj_Rec_JobReqSkills.MODE)
            {
                case 3:
                    if (ExecuteNonQuery("EXEC USP_SMHR_JOBREQUISITION @MODE='3', @JR_ID = '" + _obj_Rec_JobReqSkills.JR_ID + "'" +
                                        ",@SKILL_ID = '" + Convert.ToInt32(_obj_Rec_JobReqSkills.SKILL_ID) + "'" +
                                        ",@JOBREQ_ISSKILLREQ = '" + Convert.ToInt32(_obj_Rec_JobReqSkills.JOBREQ_ISSKILLREQ) + "'" +
                                        ",@CREATEDDATE='" + Convert.ToDateTime(_obj_Rec_JobReqSkills.CREATEDDATE).ToString("MM/dd/yyyy") + "'" +
                                         ",@JOBREQ_ORGANISATION_ID = " + Convert.ToInt32(_obj_Rec_JobReqSkills.ORGANISATION_ID) + "" +
                                        ",@CREATEDBY='" + Convert.ToInt32(_obj_Rec_JobReqSkills.CREATEDBY) + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case 4:
                    if (ExecuteNonQuery("EXEC USP_SMHR_JOBREQUISITION @MODE='4', @JR_ID = '" + _obj_Rec_JobReqSkills.JR_ID + "'"))

                        status = true;
                    else
                        status = false;
                    break;
                default:
                    break;
            }
            return status;
        }

        public static bool set_SKILLSJOBREQ(SMHR_JOBREQSKILLS _obj_Smhr_JobRequisition)
        {
            try
            {
                bool status = false;
                switch (_obj_Smhr_JobRequisition.OPERATION)
                {
                    case operation.Insert:
                        if (ExecuteNonQuery("EXEC USP_SMHR_JR_SKILLS @MODE = 3, @JR_ID ='" + _obj_Smhr_JobRequisition.JR_ID
                                          + "',@SKILL_ID='" + _obj_Smhr_JobRequisition.SKILL_ID
                                          + "',@JOBREQ_ISSKILLREQ='" + _obj_Smhr_JobRequisition.JOBREQ_ISSKILLREQ
                                          + "',@CREATEDBY='" + _obj_Smhr_JobRequisition.CREATEDBY
                                          + "',@CREATEDDATE='" + Convert.ToDateTime(_obj_Smhr_JobRequisition.CREATEDDATE).ToString("MM/dd/yyyy")
                                          + "'"))
                            status = true;
                        else
                            status = false;
                        break;

                    default:
                        break;
                }
                return status;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool set_DELETESKILLS(SMHR_JOBREQSKILLS _obj_Smhr_JobRequisition)
        {
            try
            {
                bool status = false;
                switch (_obj_Smhr_JobRequisition.OPERATION)
                {
                    case operation.Delete:
                        if (ExecuteNonQuery("EXEC USP_SMHR_JR_SKILLS @MODE = 8,@JR_SKILLS_ID='" + _obj_Smhr_JobRequisition.JR_SKILLS_ID + "'"))
                            status = true;
                        else
                            status = false;
                        break;

                    default:
                        break;
                }
                return status;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        #endregion

        #region RECRUITMENT_INTERVIEW_PRIORITY

        public static DataTable get_InterviewPriority(RECRUITMENT_INTERVIEW_PRIORITY _obj_Rec_Priority)
        {
            DataTable Dt = new DataTable();

            if (_obj_Rec_Priority.MODE == 1)
            {
                Dt = ExecuteQuery("EXEC USP_SMHR_INTERVIEW_PRIORITY @MODE = '" + _obj_Rec_Priority.MODE + "',@PRIORITY_ORGANIZATIONID = '" + _obj_Rec_Priority.PRIORITY_ORGANIZATIONID + "'");
            }
            else if (_obj_Rec_Priority.MODE == 2)
            {
                Dt = ExecuteQuery("Exec USP_SMHR_INTERVIEW_PRIORITY @MODE = '" + _obj_Rec_Priority.MODE + "',@PRIORITY_VALUE =" + _obj_Rec_Priority.PRIORITY_VALUE + ",@PRIORITY_ORGANIZATIONID = '" + _obj_Rec_Priority.PRIORITY_ORGANIZATIONID + "'");

            }
            else if (_obj_Rec_Priority.MODE == 5)
            {
                Dt = ExecuteQuery("Exec USP_SMHR_INTERVIEW_PRIORITY @MODE = '" + _obj_Rec_Priority.MODE + "',@PRIORITY_ID ='" + _obj_Rec_Priority.PRIORITY_ID + "'");

            }
            return Dt;
        }


        public static bool set_InterviewPriority(RECRUITMENT_INTERVIEW_PRIORITY _obj_Rec_Priority)
        {
            bool status = false;
            switch (_obj_Rec_Priority.MODE)
            {
                case 3:

                    if (ExecuteNonQuery("EXEC USP_SMHR_INTERVIEW_PRIORITY @MODE = '3', @PRIORITY_ID = '" + _obj_Rec_Priority.@PRIORITY_ID
                                      + "', @PRIORITY_NAME = '" + _obj_Rec_Priority.PRIORITY_NAME + "',@PRIORITY_ORGANIZATIONID = '" + _obj_Rec_Priority.PRIORITY_ORGANIZATIONID + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case 4:
                    if (ExecuteNonQuery("EXEC USP_SMHR_INTERVIEW_PRIORITY @MODE = '4', @PRIORITY_VALUE =" + _obj_Rec_Priority.PRIORITY_VALUE
                                        + ", @PRIORITY_NAME = '" + _obj_Rec_Priority.PRIORITY_NAME + "',@PRIORITY_ORGANIZATIONID = '" + _obj_Rec_Priority.PRIORITY_ORGANIZATIONID + "'"))
                        status = true;
                    else
                        status = false;
                    break;

                default:
                    break;
            }
            return status;
        }

        #endregion
        
        #region RECRUITMENT_INTERVIEW_ROUND

        public static DataTable get_InterviewPriority(RECRUITMENT_INTERVIEW_ROUND _obj_Rec_interviewround)
        {
            DataTable Dt = new DataTable();

            if (_obj_Rec_interviewround.MODE == 1)
            {
                Dt = ExecuteQuery("EXEC USP_SMHR_INTERVIEW_ROUND @MODE = '" + _obj_Rec_interviewround.MODE + "',@INTERVIEWROUND_ORG_ID = '" + _obj_Rec_interviewround.INTERVIEWROUND_ORGANIZATIONID + "'");
            }
            else if (_obj_Rec_interviewround.MODE == 2)
            {
                Dt = ExecuteQuery("Exec USP_SMHR_INTERVIEW_ROUND @MODE = '" + _obj_Rec_interviewround.MODE + "',@INTERVIEWROUND_NAME ='" + _obj_Rec_interviewround.INTERVIEWROUND_NAME + "',@INTERVIEWROUND_VALUE =" + _obj_Rec_interviewround.INTERVIEWROUND_VALUE + "");

            }
            else if (_obj_Rec_interviewround.MODE == 5)
            {
                Dt = ExecuteQuery("Exec USP_SMHR_INTERVIEW_ROUND @MODE = '" + _obj_Rec_interviewround.MODE + "',@INTERVIEWROUND_ID ='" + _obj_Rec_interviewround.INTERVIEWROUND_ID + "'");

            }
            return Dt;
        }


        public static bool set_InterviewPriority(RECRUITMENT_INTERVIEW_ROUND _obj_Rec_interviewround)
        {
            bool status = false;
            switch (_obj_Rec_interviewround.MODE)
            {
                case 3:

                    if (ExecuteNonQuery("EXEC USP_SMHR_INTERVIEW_ROUND @MODE = '3', @PRIORITY_ID = '" + _obj_Rec_interviewround.INTERVIEWROUND_ID
                                      + "', @PRIORITY_NAME = '" + _obj_Rec_interviewround.INTERVIEWROUND_NAME + "',@INTERVIEWROUND_ORG_ID = '" + _obj_Rec_interviewround.INTERVIEWROUND_ORGANIZATIONID + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case 4:
                    if (ExecuteNonQuery("EXEC USP_SMHR_INTERVIEW_ROUND @MODE = '4', @PRIORITY_VALUE =" + _obj_Rec_interviewround.INTERVIEWROUND_VALUE
                                        + ", @PRIORITY_NAME = '" + _obj_Rec_interviewround.INTERVIEWROUND_NAME + "',@INTERVIEWROUND_ORG_ID = '" + _obj_Rec_interviewround.INTERVIEWROUND_ORGANIZATIONID + "'"))
                        status = true;
                    else
                        status = false;
                    break;

                default:
                    break;
            }
            return status;
        }

        #endregion
        
        #region RECRUITMENT_JOBOFFERS

        public static DataTable get_joboffers(RECRUITMENT_JOBOFFERS _obj_Rec_JobOffers)
        {
            DataTable dt = new DataTable();

            if (_obj_Rec_JobOffers.JOBOFFRS_ID.ToString() == "0")
            {
                dt = ExecuteQuery("EXEC [USP_SMHR_JOBOFFERS]  @operation = 'select', @JOBOFFRS_ORGANISATION_ID = " + _obj_Rec_JobOffers.JOBOFFRS_ORGANISATION_ID + "");
            }
            //else if (_obj_Smhr_skillscategary.MODE == 6)
            //{
            //    dt = ExecuteQuery("EXEC [USP_SMHRSKILLCATEGORY]  @SKILLCAT_SKILLID = " + _obj_Smhr_skillscategary.SKILLCAT_SKILLID +
            //                            " , @MODE = '" + _obj_Smhr_skillscategary.MODE + "'");
            //}
            else
            {
                dt = ExecuteQuery("EXEC USP_SMHR_JOBOFFERS @operation = 'Select', @JOBOFFRS_ID = " + _obj_Rec_JobOffers.JOBOFFRS_ID + "");
            }
            return dt;

        }

        public static DataTable GetApplicantDetails(RECRUITMENT_JOBOFFERS _obj_Rec_JobOffers)
        {
            DataTable dt = new DataTable();

            if (_obj_Rec_JobOffers.JOBOFFRS_ID.ToString() == "0")
            {
                dt = ExecuteQuery("EXEC USP_SMHR_GetApplicantDetails @operation = 'Select', @APPLICANT_ID = " + _obj_Rec_JobOffers.APPLICANT_ID + "");
            }
            return dt;


        }

        public static bool set_joboffers(RECRUITMENT_JOBOFFERS _obj_Rec_JobOffers)
        {
            bool status = false;
            switch (_obj_Rec_JobOffers.OPERATION)
            {
                case operation.Insert:
                    if (ExecuteNonQuery(" EXEC [USP_SMHR_JOBOFFERS] @operation='insert', @JOBOFFRS_REQCODE = '" + _obj_Rec_JobOffers.JOBOFFRS_REQCODE + "'" +
                                       ", @JOBOFFRS_APPLICANT_ID = '" + Convert.ToInt32(_obj_Rec_JobOffers.JOBOFFRS_APPLICANT_ID) + "'" +
                                       ", @JOBOFFRS_SALSTRUCT = '" + Convert.ToInt32(_obj_Rec_JobOffers.JOBOFFRS_SALSTRUCT) + "'" +
                                        ", @JOBOFFRS_OFFERSAL = '" + Convert.ToDecimal(_obj_Rec_JobOffers.JOBOFFRS_OFFERSAL) + "'" +
                                      ", @JOBOFFRS_LEAVESTRUCT= " + Convert.ToInt32(_obj_Rec_JobOffers.JOBOFFRS_LEAVESTRUCT) + "" +
                                      ", @JOBOFFRS_ORGANISATION_ID= " + Convert.ToInt32(_obj_Rec_JobOffers.ORGANISATION_ID) + "" +
                                      " , @JOBOFFRS_OFFERDATE='" + Convert.ToDateTime(_obj_Rec_JobOffers.JOBOFFRS_OFFERDATE).ToString("MM/dd/yyyy") + "'" +
                                       " , @JOBOFFRS_JOINDATE='" + Convert.ToDateTime(_obj_Rec_JobOffers.JOBOFFRS_JOINDATE).ToString("MM/dd/yyyy") + "'" +
                                        " , @JOBOFFRS_CREATEDDATE='" + Convert.ToDateTime(_obj_Rec_JobOffers.JOBOFFRS_CREATEDATE).ToString("MM/dd/yyyy") + "'" +
                                        ", @JOBOFFRS_CREATEDBY= " + Convert.ToInt32(_obj_Rec_JobOffers.JOBOFFRS_CREATEDBY) + "" +
                                        " , @JOBOFFRS_LASTMDFDATE='" + Convert.ToDateTime(_obj_Rec_JobOffers.JOBOFFRS_LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
                                        ", @JOBOFFRS_LASTMDFBY= " + Convert.ToInt32(_obj_Rec_JobOffers.JOBOFFRS_LASTMDFBY) + ""))
                        status = true;
                    else
                        status = false;
                    break;
                case operation.Update:
                    if (ExecuteNonQuery("EXEC [USP_SMHR_JOBOFFERS] @operation='update', @JOBOFFRS_ID  = '" + _obj_Rec_JobOffers.JOBOFFRS_ID + "'" +
                                      ",@JOBOFFRS_REQCODE = '" + _obj_Rec_JobOffers.JOBOFFRS_REQCODE + "'" +
                                     ", @JOBOFFRS_APPLICANT_ID = '" + Convert.ToInt32(_obj_Rec_JobOffers.JOBOFFRS_APPLICANT_ID) + "'" +
                                     ", @JOBOFFRS_SALSTRUCT = '" + Convert.ToInt32(_obj_Rec_JobOffers.JOBOFFRS_SALSTRUCT) + "'" +
                                      ", @JOBOFFRS_OFFERSAL = '" + Convert.ToDecimal(_obj_Rec_JobOffers.JOBOFFRS_OFFERSAL) + "'" +
                                    ", @JOBOFFRS_LEAVESTRUCT= " + Convert.ToInt32(_obj_Rec_JobOffers.JOBOFFRS_LEAVESTRUCT) + "" +
                                      ", @JOBOFFRS_ORGANISATION_ID= " + Convert.ToInt32(_obj_Rec_JobOffers.ORGANISATION_ID) + "" +
                                    " , @JOBOFFRS_OFFERDATE='" + Convert.ToDateTime(_obj_Rec_JobOffers.JOBOFFRS_OFFERDATE).ToString("MM/dd/yyyy") + "'" +
                                     " , @JOBOFFRS_JOINDATE='" + Convert.ToDateTime(_obj_Rec_JobOffers.JOBOFFRS_JOINDATE).ToString("MM/dd/yyyy") + "'" +
                                      " , @JOBOFFRS_LASTMDFDATE='" + Convert.ToDateTime(_obj_Rec_JobOffers.JOBOFFRS_LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
                                      ", @JOBOFFRS_LASTMDFBY= " + Convert.ToInt32(_obj_Rec_JobOffers.JOBOFFRS_LASTMDFBY) + ""))
                        status = true;
                    else
                        status = false;

                    break;
                default:
                    break;
            }
            return status;
        }

        //public static bool set_joboffers(RECRUITMENT_JOBOFFERS _obj_Rec_JobOffers)
        //{
        //    if (_obj_Rec_JobOffers.OPERATION == operation.Insert)
        //    {
        //        return ExecuteNonQuery(" EXEC [USP_SMHR_JOBOFFERS] @operation='insert', @JOBOFFRS_REQCODE = '" + _obj_Rec_JobOffers.JOBOFFRS_REQCODE + "'" +
        //                                ", @JOBOFFRS_APPLICANT_ID = '" + Convert.ToInt32(_obj_Rec_JobOffers.JOBOFFRS_APPLICANT_ID) + "'" +
        //                                ", @JOBOFFRS_SALSTRUCT = '" + Convert.ToInt32(_obj_Rec_JobOffers.JOBOFFRS_SALSTRUCT) + "'" +
        //                                 ", @JOBOFFRS_OFFERSAL = '" + Convert.ToDecimal(_obj_Rec_JobOffers.JOBOFFRS_OFFERSAL) + "'" +
        //                               ", @JOBOFFRS_LEAVESTRUCT= " + Convert.ToInt32(_obj_Rec_JobOffers.JOBOFFRS_LEAVESTRUCT) + "" +
        //                               " , @JOBOFFRS_OFFERDATE='" + Convert.ToDateTime(_obj_Rec_JobOffers.JOBOFFRS_OFFERDATE).ToString("MM/dd/yyyy") + "'" +
        //                                " , @JOBOFFRS_JOINDATE='" + Convert.ToDateTime(_obj_Rec_JobOffers.JOBOFFRS_JOINDATE).ToString("MM/dd/yyyy") + "'" +
        //                                 " , @JOBOFFRS_CREATEDDATE='" + Convert.ToDateTime(_obj_Rec_JobOffers.JOBOFFRS_CREATEDATE).ToString("MM/dd/yyyy") + "'" +
        //                                 ", @JOBOFFRS_CREATEDBY= " + Convert.ToInt32(_obj_Rec_JobOffers.JOBOFFRS_CREATEDBY) + "");
        //        //", @SKILLCAT_LASTMDFBY =" + Convert.ToString(_obj_Smhr_skillscategary.LASTMDFBY) + "" +
        //        // " , @SKILLCAT_LASTMDFDATE='" + Convert.ToDateTime(_obj_Smhr_skillscategary.LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +

        //    }
        //    else
        //    {
        //        return ExecuteNonQuery("EXEC [USP_SMHR_JOBOFFERS] @operation='update', @JOBOFFRS_ID  = '" + _obj_Rec_JobOffers.JOBOFFRS_ID + "'" +
        //                                 ",@JOBOFFRS_REQCODE = '" + _obj_Rec_JobOffers.JOBOFFRS_REQCODE + "'" +
        //                                ", @JOBOFFRS_APPLICANT_ID = '" + Convert.ToInt32(_obj_Rec_JobOffers.JOBOFFRS_APPLICANT_ID) + "'" +
        //                                ", @JOBOFFRS_SALSTRUCT = '" + Convert.ToInt32(_obj_Rec_JobOffers.JOBOFFRS_SALSTRUCT) + "'" +
        //                                 ", @JOBOFFRS_OFFERSAL = '" + Convert.ToDecimal(_obj_Rec_JobOffers.JOBOFFRS_OFFERSAL) + "'" +
        //                               ", @JOBOFFRS_LEAVESTRUCT= " + Convert.ToInt32(_obj_Rec_JobOffers.JOBOFFRS_LEAVESTRUCT) + "" +
        //                               " , @JOBOFFRS_OFFERDATE='" + Convert.ToDateTime(_obj_Rec_JobOffers.JOBOFFRS_OFFERDATE).ToString("MM/dd/yyyy") + "'" +
        //                                " , @JOBOFFRS_JOINDATE='" + Convert.ToDateTime(_obj_Rec_JobOffers.JOBOFFRS_JOINDATE).ToString("MM/dd/yyyy") + "'" +
        //                                 " , @JOBOFFRS_LASTMDFDATE='" + Convert.ToDateTime(_obj_Rec_JobOffers.JOBOFFRS_LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
        //                                 ", @JOBOFFRS_LASTMDFBY= " + Convert.ToInt32(_obj_Rec_JobOffers.JOBOFFRS_LASTMDFBY) + "");
        //    }
        //    //else
        //    //{
        //    //    return ExecuteNonQuery(" EXEC [USP_SMHRSKILLCATEGORY]  @MODE = '5',  @SKILLCAT_ID  = '" + _obj_Smhr_skillscategary.SKILLCAT_ID + "'" +
        //    //                            " ");
        //    //}(_obj_Rec_JobOffers.OPERATION ==operation.Update)
        //}

        #endregion
        
        #region RECRUITMENT_ASSIGNEMPTORSL

        public static DataTable get_AssigmEMPtoRSL(RECRUITMENT_ASSIGNEMPTORSL _obj_Rec_AssignEmptoRSL)
        {
            DataTable dt = new DataTable();
            switch (_obj_Rec_AssignEmptoRSL.MODE)
            {

                case 1:
                    dt = ExecuteQuery("EXEC USP_SMHR_ASSIGNEMPTORSL @MODE = 1,@ASSIGNEMP_ORG= " + Convert.ToString(_obj_Rec_AssignEmptoRSL.ORGANISATION_ID) +
                                      ",@EMP_LOGINID='" + _obj_Rec_AssignEmptoRSL.LOGIN_ID + "' ");
                    break;
                case 5:
                    dt = ExecuteQuery("EXEC USP_SMHR_ASSIGNEMPTORSL @MODE = 5,@ASSIGNEMP_ID= " + Convert.ToString(_obj_Rec_AssignEmptoRSL.ASSIGNEMP_ID) +
                                      ",@ASSIGNEMP_ORG ='" + _obj_Rec_AssignEmptoRSL.ORGANISATION_ID + "' ");
                    break;
                case 4:
                    dt = ExecuteQuery("EXEC USP_SMHR_ASSIGNEMPTORSL @MODE = 4,@ASSIGNEMP_BUID= " + Convert.ToString(_obj_Rec_AssignEmptoRSL.ASSIGNEMP_BUID) +
                                      ",@ASSIGNEMP_ORG ='" + _obj_Rec_AssignEmptoRSL.ORGANISATION_ID + "' ");
                    break;
                case 6:
                    dt = ExecuteQuery("EXEC USP_SMHR_ASSIGNEMPTORSL @MODE = 6,@ASSIGNEMP_BUID= " + Convert.ToString(_obj_Rec_AssignEmptoRSL.ASSIGNEMP_BUID) +
                                      ",@ASSIGNEMP_ORG ='" + _obj_Rec_AssignEmptoRSL.ORGANISATION_ID + "' ");
                    break;
                case 7:
                    dt = ExecuteQuery("EXEC USP_SMHR_ASSIGNEMPTORSL @MODE = 7,@ASSIGNEMP_EMP_ID= " + Convert.ToString(_obj_Rec_AssignEmptoRSL.ASSIGNEMP_EMP_ID) +
                                      ",@ASSIGNEMP_ORG ='" + _obj_Rec_AssignEmptoRSL.ORGANISATION_ID + "' ");
                    break;
                default:
                    break;
            }
            return dt;
        }

        public static bool set_AssigmEMPtoRSL(RECRUITMENT_ASSIGNEMPTORSL _obj_Rec_AssignEmptoRSL)
        {
            bool status = false;
            switch (_obj_Rec_AssignEmptoRSL.MODE)
            {
                case 2:
                    if (ExecuteNonQuery("EXEC USP_SMHR_ASSIGNEMPTORSL @MODE = 2 , @ASSIGNEMP_BUID= " + Convert.ToString(_obj_Rec_AssignEmptoRSL.ASSIGNEMP_BUID) +
                                      " ,@ASSIGNEMP_EMP_ID= " + Convert.ToString(_obj_Rec_AssignEmptoRSL.ASSIGNEMP_EMP_ID) +
                                     " , @ASSIGNEMP_DEPT= " + Convert.ToString(_obj_Rec_AssignEmptoRSL.ASSIGNEMP_DEPT) +
                                     " ,@ASSIGNEMP_JOBREQ = '" + Convert.ToString(_obj_Rec_AssignEmptoRSL.ASSIGNEMP_JOBREQ) + "'" +
                                     " ,@ASSIGNEMP_ORG='" + _obj_Rec_AssignEmptoRSL.ORGANISATION_ID + "'" +
                                      " ,  @ASSIGNEMP_CREATED_BY = " + Convert.ToInt32(_obj_Rec_AssignEmptoRSL.CREATEDBY) +
                                      ""))
                        status = true;
                    else
                        status = false;
                    break;
                case 3:
                    if (ExecuteNonQuery("EXEC USP_SMHR_ASSIGNEMPTORSL @MODE = 3 ,@ASSIGNEMP_ID= " + Convert.ToString(_obj_Rec_AssignEmptoRSL.ASSIGNEMP_ID)
                                       + ",@ASSIGNEMP_BUID= " + Convert.ToString(_obj_Rec_AssignEmptoRSL.ASSIGNEMP_BUID) +
                                      " ,@ASSIGNEMP_EMP_ID= " + Convert.ToString(_obj_Rec_AssignEmptoRSL.ASSIGNEMP_EMP_ID) +
                                     " ,  @ASSIGNEMP_DEPT= " + Convert.ToString(_obj_Rec_AssignEmptoRSL.ASSIGNEMP_DEPT) +
                                     " ,@ASSIGNEMP_JOBREQ = '" + Convert.ToString(_obj_Rec_AssignEmptoRSL.ASSIGNEMP_JOBREQ) + "'" +
                                     " , @ASSIGNEMP_ORG='" + _obj_Rec_AssignEmptoRSL.ORGANISATION_ID + "'" +
                                      " ,  @ASSIGNEMP_MODIFIED_BY = " + Convert.ToInt32(_obj_Rec_AssignEmptoRSL.LASTMDFBY) +
                                      ""))
                        status = true;
                    else
                        status = false;
                    break;
                default:
                    break;
            }
            return status;

        }
        #endregion

        #region RECRUITMENT_ASSESSMENTS

        public static DataTable get_Assessments(RECRUITMENT_ASSESSMENTS _obj_Rec_Assessments)
        {
            DataTable dt = new DataTable();
            switch (_obj_Rec_Assessments.MODE)
            {
                case 3:
                    dt = ExecuteQuery("USP_SMHR_ASSESSMENTS @MODE=3,@ASSESSMENT_ORG='" + _obj_Rec_Assessments.ORGANISATION_ID + "'");
                    break;
                case 4:
                    dt = ExecuteQuery("USP_SMHR_ASSESSMENTS @MODE=4,@ASSESSMENT_ID='" + _obj_Rec_Assessments.ASSESSMENT_ID + "'");
                    break;
                case 5:
                    dt = ExecuteQuery("USP_SMHR_ASSESSMENTS @MODE=5,@ASSESSMENT_NAME= '" + _obj_Rec_Assessments.ASSESSMENT_NAME
                        + "',@ASSESSMENT_TYPE = '" + _obj_Rec_Assessments.ASSESSMENT_TYPE
                        + "',@ASSESSMENT_ORG = '" + _obj_Rec_Assessments.ORGANISATION_ID + "'");
                    break;
                default:
                    break;
            }
            return dt;
        }
        public static bool set_Assessments(RECRUITMENT_ASSESSMENTS _obj_Rec_Assessments)
        {
            bool status = false;
            switch (_obj_Rec_Assessments.MODE)
            {
                case 1:
                    if (ExecuteNonQuery("EXEC USP_SMHR_ASSESSMENTS @MODE=1,@ASSESSMENT_TYPE= '" + _obj_Rec_Assessments.ASSESSMENT_TYPE
                        + "',@ASSESSMENT_NAME= '" + _obj_Rec_Assessments.ASSESSMENT_NAME
                        + "',@ASSESSMENT_DESC= '" + _obj_Rec_Assessments.ASSESSMENT_DESC
                        + "',@ASSESSMENT_APPLICABLEFOR= '" + _obj_Rec_Assessments.ASSESSMENT_APPLICABLEFOR
                        + "',@ASSESSMENT_CREATEDBY = '" + _obj_Rec_Assessments.CREATEDBY
                        + "',@ASSESSMENT_ORG = '" + _obj_Rec_Assessments.ORGANISATION_ID + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case 2:
                    if (ExecuteNonQuery("EXEC USP_SMHR_ASSESSMENTS @MODE=2,@ASSESSMENT_DESC= '" + _obj_Rec_Assessments.ASSESSMENT_DESC
                        + "',@ASSESSMENT_ID = '" + _obj_Rec_Assessments.ASSESSMENT_ID
                        + "',@ASSESSMENT_APPLICABLEFOR = '" + _obj_Rec_Assessments.ASSESSMENT_APPLICABLEFOR
                        + "',@ASSESSMENT_MODIFIEDBY = '" + _obj_Rec_Assessments.LASTMDFBY + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                default:
                    break;
            }
            return status;
        }
        #endregion

        //#region SMHR_APPLICANT

        ///// <summary>
        ///// Method for getting Applicant Details. 
        ///// </summary>
        ///// <returns>DataTable</returns>
        ///// <remarks>
        /////  Author             : Gunti Dheeraj 
        /////  Created on         : 2009-08-24
        /////  Last Modified on   : N/A
        /////  Last Modfied by    : N/A
        ///// </remarks>
        ///// 

        //public static DataTable get_Applicant(SMHR_APPLICANT _obj_smhr_applicant)
        //{
        //    if (_obj_smhr_applicant.OPERATION == operation.Select)
        //    {
        //        if ((_obj_smhr_applicant.APPLICANT_ID.ToString() == "0") || (_obj_smhr_applicant.APPLICANT_ID == null))
        //        {
        //            return ExecuteQuery(" EXEC USP_SMHR_APPLICANT @Operation = 'select',@ORGANISATION_ID = '" + _obj_smhr_applicant.ORGANISATION_ID + "'");
        //        }
        //        else
        //        {
        //            return ExecuteQuery(" EXEC USP_SMHR_APPLICANT @Operation = 'select', " +
        //                            " @APPLICANT_ID = '" + Convert.ToInt32(_obj_smhr_applicant.APPLICANT_ID) +
        //                           "', @ORGANISATION_ID = '" + _obj_smhr_applicant.ORGANISATION_ID + "'");
        //        }
        //    }
        //    else if (_obj_smhr_applicant.OPERATION == operation.Check)
        //    {
        //        if (_obj_smhr_applicant.APPLICANT_CODE == null)
        //        {
        //            return ExecuteQuery(" EXEC USP_SMHR_APPLICANT @Operation = 'check',@ORGANISATION_ID='" + _obj_smhr_applicant.ORGANISATION_ID + "'");
        //        }
        //        else
        //        {
        //            return ExecuteQuery(" EXEC USP_SMHR_APPLICANT @Operation = 'check', @APPLICANT_CODE = '" + Convert.ToString(_obj_smhr_applicant.APPLICANT_CODE) + "',@ORGANISATION_ID='" + Convert.ToString(_obj_smhr_applicant.ORGANISATION_ID) + "'");
        //        }
        //    }
        //    else if (_obj_smhr_applicant.OPERATION == operation.Delete)
        //    {
        //        if (_obj_smhr_applicant.APPLICANT_ID != null)
        //        {
        //            return ExecuteQuery(" EXEC USP_SMHR_APPLICANT @Operation = 'Delete', @APPLICANT_ID = '" + _obj_smhr_applicant.APPLICANT_ID + "'");
        //        }
        //        else
        //        {
        //            return ExecuteQuery(" EXEC USP_SMHR_APPLICANT @Operation = 'Delete',@ORGANISATION_ID = '" + _obj_smhr_applicant.ORGANISATION_ID + "'");
        //        }
        //    }
        //    else if (_obj_smhr_applicant.OPERATION == operation.Validate)
        //    {
        //        // added by sridevi  to  get applicant id in employee screen.

        //        return ExecuteQuery(" EXEC USP_SMHR_APPLICANT @Operation = 'Validate', @ORGANISATION_ID = '" + _obj_smhr_applicant.ORGANISATION_ID + "'");
        //    }
        //    else
        //    {
        //        //return ExecuteQuery(" EXEC USP_SMHR_APPLICANT @Operation = 'Empty', @ORGANISATION_ID = '" + _obj_smhr_applicant.ORGANISATION_ID + "'");
        //        return ExecuteQuery(" EXEC USP_SMHR_APPLICANT @Operation = 'Empty', @APPLICANT_ID = '" + _obj_smhr_applicant.APPLICANT_ID + "'");
        //    }
        //}

        //public static DataTable get_AppCode(SMHR_APPLICANT _obj_smhr_applicant)
        //{
        //    return ExecuteQuery(" EXEC USP_SMHR_APPLICANT @Operation = 'Empty'");
        //}

        ///// <summary>
        ///// Method for Inserting and Updating Applicant Details. 
        ///// </summary>
        ///// <returns>Boolean stating success or failure</returns>
        ///// <remarks>
        /////  Author             : Gunti Dheeraj 
        /////  Created on         : 2009-08-25
        /////  Last Modified on   : N/A
        /////  Last Modfied by    : N/A
        ///// </remarks>
        ///// 

        //public static bool set_Applicant(SMHR_APPLICANT _obj_smhr_applicant)
        //{
        //    bool status = false;
        //    switch (_obj_smhr_applicant.OPERATION)
        //    {
        //        case operation.Insert:
        //            if (ExecuteNonQuery(" EXEC USP_SMHR_APPLICANT @Operation = '" + _obj_smhr_applicant.OPERATION + "'" +
        //                                ",@APPLICANT_CODE = '" + _obj_smhr_applicant.APPLICANT_CODE + "'" +
        //                                ",@APPLICANT_TITLE = '" + _obj_smhr_applicant.APPLICANT_TITLE + "'" +
        //                                ",@APPLICANT_FIRSTNAME = '" + _obj_smhr_applicant.APPLICANT_FIRSTNAME + "'" +
        //                                ",@APPLICANT_MIDDLENAME= '" + _obj_smhr_applicant.APPLICANT_MIDDLENAME + "'" +
        //                                ",@APPLICANT_LASTNAME = '" + _obj_smhr_applicant.APPLICANT_LASTNAME + "'" +
        //                                ",@APPLICANT_DOB = '" + Convert.ToDateTime(_obj_smhr_applicant.APPLICANT_DOB).ToString("MM/dd/yyyy") + "'" +
        //                                ",@APPLICANT_GENDER = '" + _obj_smhr_applicant.APPLICANT_GENDER + "'" +
        //                                ",@APPLICANT_BLOODGROUP = '" + _obj_smhr_applicant.APPLICANT_BLOODGROUP + "'" +
        //                                ",@APPLICANT_RELIGION_ID = '" + _obj_smhr_applicant.APPLICANT_RELIGION_ID + "'" +
        //                                ",@APPLICANT_NATIONALITY_ID = '" + _obj_smhr_applicant.APPLICANT_NATIONALITY_ID + "'" +
        //                                ",@APPLICANT_MARITALSTATUS = '" + _obj_smhr_applicant.APPLICANT_MARITALSTATUS + "'" +
        //                                ",@APPLICANT_STATUS = '" + _obj_smhr_applicant.APPLICANT_STATUS + "'" +
        //                                ",@APPLICANT_REMARKS = '" + _obj_smhr_applicant.APPLICANT_REMARKS + "'" +
        //                                ",@APPLICANT_RESUME = '" + _obj_smhr_applicant.APPLICANT_RESUME + "'" +
        //                                ",@APPLICANT_ADDRESS = '" + _obj_smhr_applicant.APPLICANT_ADDRESS + "'" +
        //                                ",@APPLICANT_TYPE = '" + _obj_smhr_applicant.APPLICANT_TYPE + "'" +
        //                                ",@APPLICANT_CREATEDBY = '" + _obj_smhr_applicant.APPLICANT_CREATEDBY + "'" +
        //                                ",@ORGANISATION_ID = '" + _obj_smhr_applicant.ORGANISATION_ID + "'" +
        //                                ",@APPLICANT_CREATEDDATE = '" + Convert.ToDateTime(_obj_smhr_applicant.APPLICANT_CREATEDDATE).ToString("MM/dd/yyyy") + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        case operation.Update:
        //            if (ExecuteNonQuery(" EXEC USP_SMHR_APPLICANT @Operation = '" + _obj_smhr_applicant.OPERATION + "'" +
        //                                ",@APPLICANT_CODE = '" + _obj_smhr_applicant.APPLICANT_CODE + "'" +
        //                                ",@APPLICANT_TITLE = '" + _obj_smhr_applicant.APPLICANT_TITLE + "'" +
        //                                ",@APPLICANT_FIRSTNAME = '" + _obj_smhr_applicant.APPLICANT_FIRSTNAME + "'" +
        //                                ",@APPLICANT_MIDDLENAME= '" + _obj_smhr_applicant.APPLICANT_MIDDLENAME + "'" +
        //                                ",@APPLICANT_LASTNAME = '" + _obj_smhr_applicant.APPLICANT_LASTNAME + "'" +
        //                                ",@APPLICANT_DOB = '" + Convert.ToDateTime(_obj_smhr_applicant.APPLICANT_DOB).ToString("MM/dd/yyyy") + "'" +
        //                                ",@APPLICANT_GENDER = '" + _obj_smhr_applicant.APPLICANT_GENDER + "'" +
        //                                ",@APPLICANT_BLOODGROUP = '" + _obj_smhr_applicant.APPLICANT_BLOODGROUP + "'" +
        //                                ",@APPLICANT_RELIGION_ID = '" + _obj_smhr_applicant.APPLICANT_RELIGION_ID + "'" +
        //                                ",@APPLICANT_NATIONALITY_ID = '" + _obj_smhr_applicant.APPLICANT_NATIONALITY_ID + "'" +
        //                                ",@APPLICANT_MARITALSTATUS = '" + _obj_smhr_applicant.APPLICANT_MARITALSTATUS + "'" +
        //                                ",@APPLICANT_STATUS = '" + _obj_smhr_applicant.APPLICANT_STATUS + "'" +
        //                                ",@APPLICANT_REMARKS = '" + _obj_smhr_applicant.APPLICANT_REMARKS + "'" +
        //                                ",@APPLICANT_RESUME = '" + _obj_smhr_applicant.APPLICANT_RESUME + "'" +
        //                                ",@APPLICANT_ADDRESS = '" + _obj_smhr_applicant.APPLICANT_ADDRESS + "'" +
        //                                ",@APPLICANT_TYPE = '" + _obj_smhr_applicant.APPLICANT_TYPE + "'" +
        //                                ",@ORGANISATION_ID = '" + _obj_smhr_applicant.ORGANISATION_ID + "'" +
        //                                ",@APPLICANT_LASTMDFBY = '" + _obj_smhr_applicant.APPLICANT_LASTMDFBY + "'" +
        //                                ",@APPLICANT_LASTMDFDATE = '" + Convert.ToDateTime(_obj_smhr_applicant.APPLICANT_LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
        //                                ",@APPLICANT_ID = '" + _obj_smhr_applicant.APPLICANT_ID + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        default:
        //            break;
        //    }
        //    return status;
        //}

        //public static bool set_EmpApplicant(SMHR_APPLICANT _obj_smhr_applicant)
        //{
        //    return (ExecuteNonQuery(" EXEC USP_SMHR_APPLICANT @Operation = '" + _obj_smhr_applicant.OPERATION + "'" +
        //                                ",@APPLICANT_TITLE = '" + _obj_smhr_applicant.APPLICANT_TITLE + "'" +
        //                                ",@APPLICANT_FIRSTNAME = '" + _obj_smhr_applicant.APPLICANT_FIRSTNAME + "'" +
        //                                ",@APPLICANT_MIDDLENAME= '" + _obj_smhr_applicant.APPLICANT_MIDDLENAME + "'" +
        //                                ",@APPLICANT_LASTNAME = '" + _obj_smhr_applicant.APPLICANT_LASTNAME + "'" +
        //                                ",@APPLICANT_DOB = '" + _obj_smhr_applicant.APPLICANT_DOB + "'" +
        //                                ",@APPLICANT_GENDER = '" + _obj_smhr_applicant.APPLICANT_GENDER + "'" +
        //                                ",@APPLICANT_BLOODGROUP = '" + _obj_smhr_applicant.APPLICANT_BLOODGROUP + "'" +
        //                                ",@APPLICANT_RELIGION_ID = '" + _obj_smhr_applicant.APPLICANT_RELIGION_ID + "'" +
        //                                ",@APPLICANT_NATIONALITY_ID = '" + _obj_smhr_applicant.APPLICANT_NATIONALITY_ID + "'" +
        //                                ",@APPLICANT_MARITALSTATUS = '" + _obj_smhr_applicant.APPLICANT_MARITALSTATUS + "'" +
        //                                ",@APPLICANT_STATUS = '" + _obj_smhr_applicant.APPLICANT_STATUS + "'" +
        //                                ",@APPLICANT_REMARKS = '" + _obj_smhr_applicant.APPLICANT_REMARKS + "'" +
        //                                ",@APPLICANT_RESUME = '" + _obj_smhr_applicant.APPLICANT_RESUME + "'" +
        //                                ",@APPLICANT_ADDRESS = '" + _obj_smhr_applicant.APPLICANT_ADDRESS + "'" +
        //                                ",@APPLICANT_LASTMDFBY = '" + _obj_smhr_applicant.APPLICANT_LASTMDFBY + "'" +
        //                                ",@APPLICANT_LASTMDFDATE = '" + Convert.ToDateTime(_obj_smhr_applicant.APPLICANT_LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
        //                                ",@APPLICANT_TYPE = '" + _obj_smhr_applicant.APPLICANT_TYPE + "'" +
        //                                ",@ORGANISATION_ID='" + _obj_smhr_applicant.ORGANISATION_ID + "'" +
        //                                ",@APPLICANT_ID = '" + _obj_smhr_applicant.APPLICANT_ID + "'"));
        //}

        ///// <summary>
        ///// Method for getting Applicant Experience Details. 
        ///// </summary>
        ///// <returns>DataTable</returns>
        ///// <remarks>
        /////  Author             : Gunti Dheeraj 
        /////  Created on         : 2009-08-24
        /////  Last Modified on   : N/A
        /////  Last Modfied by    : N/A
        ///// </remarks>
        ///// 

        //public static DataTable get_ApplicantExperience(SMHR_APPLICANT _obj_smhr_applicant)
        //{
        //    if (_obj_smhr_applicant.OPERATION == operation.Select)
        //    {
        //        return ExecuteQuery(" EXEC USP_SMHR_APPLICANTEXPERIENCE @Operation = 'select'");
        //    }
        //    else
        //    {
        //        return ExecuteQuery(" EXEC USP_SMHR_APPLICANTEXPERIENCE @Operation = 'check', @APPEXP_APPLICANT_ID = '" + Convert.ToInt32(_obj_smhr_applicant.APPEXP_APPLICANT_ID) + "'");
        //    }
        //}

        ///// <summary>
        ///// Method for getting Applicant Qualification Details. 
        ///// </summary>
        ///// <returns>DataTable</returns>
        ///// <remarks>
        /////  Author             : Gunti Dheeraj 
        /////  Created on         : 2009-08-26
        /////  Last Modified on   : N/A
        /////  Last Modfied by    : N/A
        ///// </remarks>
        ///// 

        //public static DataTable get_ApplicantQualification(SMHR_APPLICANT _obj_smhr_applicant)
        //{
        //    if (_obj_smhr_applicant.OPERATION == operation.Select)
        //    {
        //        return ExecuteQuery(" EXEC USP_SMHR_APPLICANTQUALIFICATION @Operation = 'select', @APPDFN_ID = '" + Convert.ToInt32(_obj_smhr_applicant.APPQFN_ID) + "'");
        //    }
        //    else
        //    {
        //        return ExecuteQuery(" EXEC USP_SMHR_APPLICANTQUALIFICATION @Operation = 'check', @APPQFN_APPLICANT_ID = '" + Convert.ToInt32(_obj_smhr_applicant.APPQFN_APPLICANT_ID) + "'");
        //    }
        //}

        ///// <summary>
        ///// Method for getting Applicant Skills Details. 
        ///// </summary>
        ///// <returns>DataTable</returns>
        ///// <remarks>
        /////  Author             : Gunti Dheeraj 
        /////  Created on         : 2009-08-26
        /////  Last Modified on   : N/A
        /////  Last Modfied by    : N/A
        ///// </remarks>
        ///// 

        //public static DataTable get_ApplicantSkills(SMHR_APPLICANT _obj_smhr_applicant)
        //{
        //    if (_obj_smhr_applicant.OPERATION == operation.Select)
        //    {
        //        return ExecuteQuery(" EXEC USP_SMHR_APPLICANTSKILLS @Operation = 'select'");
        //    }
        //    else
        //    {
        //        return ExecuteQuery(" EXEC USP_SMHR_APPLICANTSKILLS @Operation = 'check', @APPSKL_APPLICANT_ID = '" + _obj_smhr_applicant.APPSKL_APPLICANT_ID + "'");
        //    }
        //}

        ///// <summary>
        ///// Method for getting Applicant Contact Details. 
        ///// </summary>
        ///// <returns>DataTable</returns>
        ///// <remarks>
        /////  Author             : Gunti Dheeraj 
        /////  Created on         : 2009-08-26
        /////  Last Modified on   : N/A
        /////  Last Modfied by    : N/A
        ///// </remarks>
        ///// 

        //public static DataTable get_ApplicantContact(SMHR_APPLICANT _obj_smhr_applicant)
        //{
        //    if (_obj_smhr_applicant.OPERATION == operation.Select)
        //    {
        //        return ExecuteQuery(" EXEC USP_SMHR_APPLICANTCONTACT @Operation = 'select'");
        //    }
        //    else
        //    {
        //        return ExecuteQuery(" EXEC USP_SMHR_APPLICANTCONTACT @Operation = 'check', @APPCONT_APPLICANT_ID = '" + _obj_smhr_applicant.APPCONT_APPLICANT_ID + "'");
        //    }
        //}

        ///// <summary>
        ///// Method for getting Applicant Language Details. 
        ///// </summary>
        ///// <returns>DataTable</returns>
        ///// <remarks>
        /////  Author             : Gunti Dheeraj 
        /////  Created on         : 2009-08-26
        /////  Last Modified on   : N/A
        /////  Last Modfied by    : N/A
        ///// </remarks>
        ///// 

        //public static DataTable get_ApplicantLanguage(SMHR_APPLICANT _obj_smhr_applicant)
        //{
        //    if (_obj_smhr_applicant.OPERATION == operation.Select)
        //    {
        //        return ExecuteQuery(" EXEC USP_SMHR_APPLICANTLANGUAGE @Operation = 'select'");
        //    }
        //    else
        //    {
        //        return ExecuteQuery(" EXEC USP_SMHR_APPLICANTLANGUAGE @Operation = 'check', @APPLAN_APPLICANT_ID = '" + _obj_smhr_applicant.APPLAN_APPLICANT_ID + "'");
        //    }
        //}

        ///// <summary>
        ///// Method for getting Applicant Reference Details. 
        ///// </summary>
        ///// <returns>DataTable</returns>
        ///// <remarks>
        /////  Author             : Gunti Dheeraj 
        /////  Created on         : 2009-08-26
        /////  Last Modified on   : N/A
        /////  Last Modfied by    : N/A
        ///// </remarks>
        ///// 

        //public static DataTable get_ApplicantReference(SMHR_APPLICANT _obj_smhr_applicant)
        //{
        //    if (_obj_smhr_applicant.OPERATION == operation.Select)
        //    {
        //        return ExecuteQuery(" EXEC USP_SMHR_APPLICANTREFERENCE @Operation = 'select'");
        //    }
        //    else
        //    {
        //        return ExecuteQuery(" EXEC USP_SMHR_APPLICANTREFERENCE @Operation = 'check', @APPREF_APPLICANT_ID = '" + _obj_smhr_applicant.APPREF_APPLICANT_ID + "'");
        //    }
        //}

        ///// <summary>
        ///// Method for Insert and Update Applicant Qualification Details. 
        ///// </summary>
        ///// <returns>DataTable</returns>
        ///// <remarks>
        /////  Author             : Gunti Dheeraj 
        /////  Created on         : 2009-08-25
        /////  Last Modified on   : N/A
        /////  Last Modfied by    : N/A
        ///// </remarks>
        ///// 

        //public static bool set_AppQualification(SMHR_APPLICANT _obj_smhr_applicant)
        //{
        //    bool status = false;
        //    switch (_obj_smhr_applicant.OPERATION)
        //    {
        //        case operation.Insert:
        //            if (ExecuteNonQuery(" EXEC USP_SMHR_APPLICANTQUALIFICATION @Operation = '" + _obj_smhr_applicant.OPERATION + "'" +
        //                                ",@APPQFN_APPLICANT_ID ='" + Convert.ToInt32(_obj_smhr_applicant.APPLICANT_ID) + "'" +
        //                                ",@APPQFN_QUALIFICATION_ID = '" + Convert.ToInt32(_obj_smhr_applicant.APPQFN_QUALIFICATION_ID) + "'" +
        //                                ",@APPQFN_INSTITUTE = '" + _obj_smhr_applicant.APPQFN_INSTITUTE + "'" +
        //                                ",@APPQFN_PASSEDYEAR = '" + _obj_smhr_applicant.APPQFN_PASSEDYEAR + "'" +
        //                                ",@APPQFN_PERCENTAGE = '" + _obj_smhr_applicant.APPQFN_PERCENTAGE + "'" +
        //                                ",@APPQFN_GRADE = '" + _obj_smhr_applicant.APPQFN_GRADE + "'" +
        //                                ",@APPQFN_CREATEDBY = '" + _obj_smhr_applicant.APPQFN_CREATEDBY + "'" +
        //                                ",@APPQFN_CREATEDDATE = '" + Convert.ToDateTime(_obj_smhr_applicant.APPQFN_CREATEDDATE).ToString("MM/dd/yyyy") + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        case operation.Update:
        //            if (ExecuteNonQuery(" EXEC USP_SMHR_APPLICANTQUALIFICATION @Operation = '" + _obj_smhr_applicant.OPERATION + "'" +
        //                                ",@APPQFN_APPLICANT_ID ='" + Convert.ToInt32(_obj_smhr_applicant.APPLICANT_ID) + "'" +
        //                                ",@APPQFN_QUALIFICATION_ID = '" + Convert.ToInt32(_obj_smhr_applicant.APPQFN_QUALIFICATION_ID) + "'" +
        //                                ",@APPQFN_INSTITUTE = '" + _obj_smhr_applicant.APPQFN_INSTITUTE + "'" +
        //                                ",@APPQFN_PASSEDYEAR = '" + _obj_smhr_applicant.APPQFN_PASSEDYEAR + "'" +
        //                                ",@APPQFN_PERCENTAGE = '" + _obj_smhr_applicant.APPQFN_PERCENTAGE + "'" +
        //                                ",@APPQFN_GRADE = '" + _obj_smhr_applicant.APPQFN_GRADE + "'" +
        //                                ",@APPQFN_LASTMDFBY = '" + _obj_smhr_applicant.APPQFN_LASTMDFBY + "'" +
        //                                ",@APPQFN_LASTMDFDATE = '" + Convert.ToDateTime(_obj_smhr_applicant.APPQFN_LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
        //                                ",@APPQFN_ID = '" + _obj_smhr_applicant.APPQFN_ID + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        default:
        //            break;
        //    }
        //    return status;
        //}


        ///// <summary>
        ///// Method for Insert and Update Applicant Experience Details. 
        ///// </summary>
        ///// <returns>DataTable</returns>
        ///// <remarks>
        /////  Author             : Gunti Dheeraj 
        /////  Created on         : 2009-08-25
        /////  Last Modified on   : N/A
        /////  Last Modfied by    : N/A
        ///// </remarks>
        ///// 

        //public static bool set_ApplicantExperience(SMHR_APPLICANT _obj_smhr_applicant)
        //{
        //    bool status = false;
        //    switch (_obj_smhr_applicant.OPERATION)
        //    {
        //        case operation.Insert:
        //            if (ExecuteNonQuery(" EXEC USP_SMHR_APPLICANTEXPERIENCE @Operation = '" + _obj_smhr_applicant.OPERATION + "'" +
        //                                ",@APPEXP_APPLICANT_ID = '" + _obj_smhr_applicant.APPLICANT_ID + "'" +
        //                                ",@APPEXP_SERIAL = '" + _obj_smhr_applicant.APPEXP_SERIAL + "'" +
        //                                ",@APPEXP_COMPANY = '" + _obj_smhr_applicant.APPEXP_COMPANY + "'" +
        //                                ",@APPEXP_JOINDATE = '" + Convert.ToDateTime(_obj_smhr_applicant.APPEXP_JOINDATE).ToString("MM/dd/yyyy") + "'" +
        //                                ",@APPEXP_JOINSAL = '" + _obj_smhr_applicant.APPEXP_JOINSAL + "'" +
        //                                ",@APPEXP_JOINDESC = '" + _obj_smhr_applicant.APPEXP_JOINDESC + "'" +
        //                                ",@APPEXP_REASONREL = '" + _obj_smhr_applicant.APPEXP_REASONREL + "'" +
        //                                ",@APPEXP_RELDATE = '" + Convert.ToDateTime(_obj_smhr_applicant.APPEXP_RELDATE).ToString("MM/dd/yyyy") + "'" +
        //                                ",@APPEXP_RELSAL = '" + _obj_smhr_applicant.APPEXP_RELSAL + "'" +
        //                                ",@APPEXP_REASONDESC = '" + _obj_smhr_applicant.APPEXP_REASONDESC + "'" +
        //                                ",@APPEXP_CREATEDBY = '" + _obj_smhr_applicant.APPEXP_CREATEDBY + "'" +
        //                                ",@APPEXP_CREATEDDATE = '" + Convert.ToDateTime(_obj_smhr_applicant.APPEXP_CREATEDDATE).ToString("MM/dd/yyyy") + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        case operation.Update:
        //            if (ExecuteNonQuery(" EXEC USP_SMHR_APPLICANTEXPERIENCE @Operation = '" + _obj_smhr_applicant.OPERATION + "'" +
        //                                ",@APPEXP_APPLICANT_ID = '" + _obj_smhr_applicant.APPLICANT_ID + "'" +
        //                                ",@APPEXP_SERIAL = '" + _obj_smhr_applicant.APPEXP_SERIAL + "'" +
        //                                ",@APPEXP_COMPANY = '" + _obj_smhr_applicant.APPEXP_COMPANY + "'" +
        //                                ",@APPEXP_JOINDATE = '" + Convert.ToDateTime(_obj_smhr_applicant.APPEXP_JOINDATE).ToString("MM/dd/yyyy") + "'" +
        //                                ",@APPEXP_JOINSAL = '" + _obj_smhr_applicant.APPEXP_JOINSAL + "'" +
        //                                ",@APPEXP_JOINDESC = '" + _obj_smhr_applicant.APPEXP_JOINDESC + "'" +
        //                                ",@APPEXP_REASONREL = '" + _obj_smhr_applicant.APPEXP_REASONREL + "'" +
        //                                ",@APPEXP_RELDATE = '" + Convert.ToDateTime(_obj_smhr_applicant.APPEXP_RELDATE).ToString("MM/dd/yyyy") + "'" +
        //                                ",@APPEXP_RELSAL = '" + _obj_smhr_applicant.APPEXP_RELSAL + "'" +
        //                                ",@APPEXP_REASONDESC = '" + _obj_smhr_applicant.APPEXP_REASONDESC + "'" +
        //                                ",@APPEXP_LASTMDFBY = '" + _obj_smhr_applicant.APPEXP_LASTMDFBY + "'" +
        //                                ",@APPEXP_LASTMDFDATE = '" + Convert.ToDateTime(_obj_smhr_applicant.APPEXP_LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
        //                                ",@APPEXP_ID = '" + _obj_smhr_applicant.APPEXP_ID + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        default:
        //            break;
        //    }
        //    return status;
        //}


        ///// <summary>
        ///// Method for Insert and Update Applicant Skill Details. 
        ///// </summary>
        ///// <returns>DataTable</returns>
        ///// <remarks>
        /////  Author             : Gunti Dheeraj 
        /////  Created on         : 2009-08-25
        /////  Last Modified on   : N/A
        /////  Last Modfied by    : N/A
        ///// </remarks>
        ///// 

        //public static bool set_ApplicantSkills(SMHR_APPLICANT _obj_smhr_applicant)
        //{
        //    bool status = false;
        //    switch (_obj_smhr_applicant.OPERATION)
        //    {
        //        case operation.Insert:
        //            if (ExecuteNonQuery(" EXEC USP_SMHR_APPLICANTSKILLS @Operation = '" + _obj_smhr_applicant.OPERATION + "'" +
        //                                ",@APPSKL_APPLICANT_ID = '" + _obj_smhr_applicant.APPLICANT_ID + "'" +
        //                                ",@APPSKL_SKILL_ID = '" + _obj_smhr_applicant.APPSKL_SKILL_ID + "'" +
        //                                ",@APPSKL_LASTUSED = '" + _obj_smhr_applicant.APPSKL_LASTUSED + "'" +
        //                                ",@APPSKL_EXPERT = '" + _obj_smhr_applicant.APPSKL_EXPERT + "'" +
        //                                ",@APPSKL_CREATEDBY = '" + _obj_smhr_applicant.APPSKL_CREATEDBY + "'" +
        //                                ",@APPSKL_CREATEDDATE = '" + Convert.ToDateTime(_obj_smhr_applicant.APPSKL_CREATEDDATE).ToString("MM/dd/yyyy") + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        case operation.Update:
        //            if (ExecuteNonQuery(" EXEC USP_SMHR_APPLICANTSKILLS @Operation = '" + _obj_smhr_applicant.OPERATION + "'" +
        //                                ",@APPSKL_APPLICANT_ID = '" + _obj_smhr_applicant.APPLICANT_ID + "'" +
        //                                ",@APPSKL_SKILL_ID = '" + _obj_smhr_applicant.APPSKL_SKILL_ID + "'" +
        //                                ",@APPSKL_LASTUSED = '" + _obj_smhr_applicant.APPSKL_LASTUSED + "'" +
        //                                ",@APPSKL_EXPERT = '" + _obj_smhr_applicant.APPSKL_EXPERT + "'" +
        //                                ",@APPSKL_LASTMDFBY = '" + _obj_smhr_applicant.APPSKL_LASTMDFBY + "'" +
        //                                ",@APPSKL_LASTMDFDATE = '" + Convert.ToDateTime(_obj_smhr_applicant.APPSKL_LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
        //                                ",@APPSKL_ID = '" + _obj_smhr_applicant.APPSKL_ID + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        default:
        //            break;
        //    }
        //    return status;
        //}


        ///// <summary>
        ///// Method for Insert and Update Applicant Contact Details. 
        ///// </summary>
        ///// <returns>DataTable</returns>
        ///// <remarks>
        /////  Author             : Gunti Dheeraj 
        /////  Created on         : 2009-08-25
        /////  Last Modified on   : N/A
        /////  Last Modfied by    : N/A
        ///// </remarks>
        ///// 

        //public static bool set_ApplicantContact(SMHR_APPLICANT _obj_smhr_applicant)
        //{
        //    bool status = false;
        //    switch (_obj_smhr_applicant.OPERATION)
        //    {
        //        case operation.Insert:
        //            if (ExecuteNonQuery(" EXEC USP_SMHR_APPLICANTCONTACT @Operation = '" + _obj_smhr_applicant.OPERATION + "'" +
        //                                ",@APPCONT_SERIAL = '" + _obj_smhr_applicant.APPCONT_SERIAL + "'" +
        //                                ",@APPCONT_APPLICANT_ID = '" + _obj_smhr_applicant.APPLICANT_ID + "'" +
        //                                ",@APPCONT_COMPANY = '" + _obj_smhr_applicant.APPCONT_COMPANY + "'" +
        //                                ",@APPCONT_CONTACT = '" + _obj_smhr_applicant.APPCONT_CONTACT + "'" +
        //                                ",@APPCONT_PHONE = '" + _obj_smhr_applicant.APPCONT_PHONE + "'" +
        //                                ",@APPCONT_ADDRESS = '" + _obj_smhr_applicant.APPCONT_ADDRESS + "'" +
        //                                ",@APPCONT_CREATEDBY = '" + _obj_smhr_applicant.APPCONT_CREATEDBY + "'" +
        //                                ",@APPCONT_CREATEDDATE = '" + Convert.ToDateTime(_obj_smhr_applicant.APPCONT_CREATEDDATE).ToString("MM/dd/yyyy") + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        case operation.Update:
        //            if (ExecuteNonQuery(" EXEC USP_SMHR_APPLICANTCONTACT @Operation = '" + _obj_smhr_applicant.OPERATION + "'" +
        //                                ",@APPCONT_SERIAL = '" + _obj_smhr_applicant.APPCONT_SERIAL + "'" +
        //                                ",@APPCONT_APPLICANT_ID = '" + _obj_smhr_applicant.APPLICANT_ID + "'" +
        //                                ",@APPCONT_COMPANY = '" + _obj_smhr_applicant.APPCONT_COMPANY + "'" +
        //                                ",@APPCONT_CONTACT = '" + _obj_smhr_applicant.APPCONT_CONTACT + "'" +
        //                                ",@APPCONT_PHONE = '" + _obj_smhr_applicant.APPCONT_PHONE + "'" +
        //                                ",@APPCONT_ADDRESS = '" + _obj_smhr_applicant.APPCONT_ADDRESS + "'" +
        //                                ",@APPCONT_LASTMDFBY = '" + _obj_smhr_applicant.APPCONT_LASTMDFBY + "'" +
        //                                ",@APPCONT_LASTMDFDATE = '" + Convert.ToDateTime(_obj_smhr_applicant.APPCONT_LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
        //                                ",@APPCONT_ID = '" + _obj_smhr_applicant.APPCONT_ID + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        default:
        //            break;
        //    }
        //    return status;
        //}


        ///// <summary>
        ///// Method for Insert and Update Applicant Reference Details. 
        ///// </summary>
        ///// <returns>DataTable</returns>
        ///// <remarks>
        /////  Author             : Gunti Dheeraj 
        /////  Created on         : 2009-08-25
        /////  Last Modified on   : N/A
        /////  Last Modfied by    : N/A
        ///// </remarks>
        ///// 

        //public static bool set_ApplicantReference(SMHR_APPLICANT _obj_smhr_applicant)
        //{
        //    bool status = false;
        //    switch (_obj_smhr_applicant.OPERATION)
        //    {
        //        case operation.Insert:
        //            if (ExecuteNonQuery(" EXEC USP_SMHR_APPLICANTREFERENCE @Operation = '" + _obj_smhr_applicant.OPERATION + "'" +
        //                                ",@APPREF_APPLICANT_ID = '" + _obj_smhr_applicant.APPLICANT_ID + "'" +
        //                                ",@APPREF_REFFERED_EMP_ID = '" + _obj_smhr_applicant.APPREF_REFFERED_EMP_ID + "'" +
        //                                ",@APPREF_RELATIONSHIP = '" + _obj_smhr_applicant.APPREF_RELATIONSHIP + "'" +
        //                                ",@APPREF_REFERRED = '" + _obj_smhr_applicant.APPREF_REFERRED + "'" +
        //                                ",@APPREF_CREATEDBY = '" + _obj_smhr_applicant.APPREF_CREATEDBY + "'" +
        //                                ",@APPREF_CREATEDDATE = '" + Convert.ToDateTime(_obj_smhr_applicant.APPREF_CREATEDDATE).ToString("MM/dd/yyyy") + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        case operation.Update:
        //            if (ExecuteNonQuery(" EXEC USP_SMHR_APPLICANTREFERENCE @Operation = '" + _obj_smhr_applicant.OPERATION + "'" +
        //                                ",@APPREF_APPLICANT_ID = '" + _obj_smhr_applicant.APPLICANT_ID + "'" +
        //                                ",@APPREF_REFFERED_EMP_ID = '" + _obj_smhr_applicant.APPREF_REFFERED_EMP_ID + "'" +
        //                                ",@APPREF_RELATIONSHIP = '" + _obj_smhr_applicant.APPREF_RELATIONSHIP + "'" +
        //                                ",@APPREF_REFERRED = '" + _obj_smhr_applicant.APPREF_REFERRED + "'" +
        //                                ",@APPREF_LASTMDFBY = '" + _obj_smhr_applicant.APPREF_LASTMDFBY + "'" +
        //                                ",@APPREF_LASTMDFDATE = '" + Convert.ToDateTime(_obj_smhr_applicant.APPREF_LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
        //                                ",@APPREF_ID = '" + _obj_smhr_applicant.APPREF_ID + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        default:
        //            break;
        //    }
        //    return status;
        //}

        //public static bool set_ApplicantLanguage(SMHR_APPLICANT _obj_smhr_applicant)
        //{
        //    bool status = false;
        //    switch (_obj_smhr_applicant.OPERATION)
        //    {
        //        case operation.Insert:
        //            if (ExecuteNonQuery(" EXEC USP_SMHR_APPLICANTLANGUAGE @Operation = '" + _obj_smhr_applicant.OPERATION + "'" +
        //                                ",@APPLAN_APPLICANT_ID = '" + _obj_smhr_applicant.APPLICANT_ID + "'" +
        //                                ",@APPLAN_LANGUAGE_ID = '" + _obj_smhr_applicant.APPLAN_LANGUAGE_ID + "'" +
        //                                ",@APPLAN_READ = '" + _obj_smhr_applicant.APPLAN_READ + "'" +
        //                                ",@APPLAN_WRITE = '" + _obj_smhr_applicant.APPLAN_WRITE + "'" +
        //                                ",@APPLAN_SPEAK = '" + _obj_smhr_applicant.APPLAN_SPEAK + "'" +
        //                                ",@APPLAN_UNDERSTAND = '" + _obj_smhr_applicant.APPLAN_UNDERSTAND + "'" +
        //                                ",@APPLAN_CREATEDBY = '" + _obj_smhr_applicant.APPLAN_CREATEDBY + "'" +
        //                                ",@APPLAN_CREATEDDATE = '" + Convert.ToDateTime(_obj_smhr_applicant.APPLAN_CREATEDDATE).ToString("MM/dd/yyyy") + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        case operation.Update:
        //            if (ExecuteNonQuery(" EXEC USP_SMHR_APPLICANTLANGUAGE @Operation = '" + _obj_smhr_applicant.OPERATION + "'" +
        //                                ",@APPLAN_APPLICANT_ID = '" + _obj_smhr_applicant.APPLICANT_ID + "'" +
        //                                ",@APPLAN_LANGUAGE_ID = '" + _obj_smhr_applicant.APPLAN_LANGUAGE_ID + "'" +
        //                                ",@APPLAN_READ = '" + _obj_smhr_applicant.APPLAN_READ + "'" +
        //                                ",@APPLAN_WRITE = '" + _obj_smhr_applicant.APPLAN_WRITE + "'" +
        //                                ",@APPLAN_SPEAK = '" + _obj_smhr_applicant.APPLAN_SPEAK + "'" +
        //                                ",@APPLAN_UNDERSTAND = '" + _obj_smhr_applicant.APPLAN_UNDERSTAND + "'" +
        //                                ",@APPLAN_LASTMDFBY= '" + _obj_smhr_applicant.APPLAN_LASTMDFBY + "'" +
        //                                ",@APPLAN_LASTMDFDATE= '" + Convert.ToDateTime(_obj_smhr_applicant.APPLAN_LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
        //                                ",@APPLAN_ID = '" + _obj_smhr_applicant.APPLAN_ID + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        default:
        //            break;
        //    }
        //    return status;
        //}
        //#endregion

        //#region SMHR_BUSINESSUNIT

        ///// <summary>
        /////  Method to Get Business Unit Based on the BusinessUnitID
        ///// </summary>
        ///// <param name="BUSINESSUNIT_ID"></param>
        ///// <returns>Datatable with BusinessUnit Information</returns>
        ///// <remarks>
        /////  Author             : BK 
        /////  Created on         : 2009-08-10 
        /////  Last Modified on   : N/A
        /////  Last Modfied by    : N/A
        ///// </remarks>
        //public static DataTable get_BusinessUnit(SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit)
        //{
        //    if (_obj_Smhr_BusinessUnit.OPERATION == operation.Select)
        //    {
        //        if (_obj_Smhr_BusinessUnit.BUSINESSUNIT_ID == null)
        //        {
        //            return ExecuteQuery("EXEC USP_SMHR_BUSINESSUNIT @Operation = 'select', " +
        //                                " @BUSINESSUNIT_ORGANISATION_ID = '" + _obj_Smhr_BusinessUnit.ORGANISATION_ID + "'" +
        //                                ",@BUSINESSUNIT_ISDELETED=" + (_obj_Smhr_BusinessUnit.ISDELETED == null ? "null" : "'" + Convert.ToString(_obj_Smhr_BusinessUnit.ISDELETED) + "'"));
        //        }
        //        else
        //            return ExecuteQuery("EXEC USP_SMHR_BUSINESSUNIT @Operation = 'select'," +
        //                                "@BUSINESSUNIT_ID='" + Convert.ToString(_obj_Smhr_BusinessUnit.BUSINESSUNIT_ID) + "'" +
        //                                ", @BUSINESSUNIT_ORGANISATION_ID = '" + Convert.ToString(_obj_Smhr_BusinessUnit.BUSINESSUNIT_ORGANISATION_ID) + "'");
        //    }
        //    else if (_obj_Smhr_BusinessUnit.OPERATION == operation.Check)
        //    {
        //        if (_obj_Smhr_BusinessUnit.BUSINESSUNIT_ID == null)
        //            return ExecuteQuery("EXEC USP_SMHR_BUSINESSUNIT @Operation = 'Check'," +
        //                                "@BUSINESSUNIT_CODE ='" + Convert.ToString(_obj_Smhr_BusinessUnit.BUSINESSUNIT_CODE) + "'" +
        //                                ", @BUSINESSUNIT_ORGANISATION_ID = '" + _obj_Smhr_BusinessUnit.ORGANISATION_ID + "'");
        //        else
        //            return ExecuteQuery("EXEC USP_SMHR_BUSINESSUNIT @Operation = 'Check', " +
        //                                " @BUSINESSUNIT_CODE ='" + Convert.ToString(_obj_Smhr_BusinessUnit.BUSINESSUNIT_CODE) + "'," +
        //                                " @BUSINESSUNIT_ID =" + Convert.ToString(_obj_Smhr_BusinessUnit.BUSINESSUNIT_ID + "" +
        //                                ", @BUSINESSUNIT_ORGANISATION_ID = '" + _obj_Smhr_BusinessUnit.ORGANISATION_ID + "'"));
        //    }
        //    else if (_obj_Smhr_BusinessUnit.OPERATION == operation.Check1)
        //    {
        //        return ExecuteQuery("EXEC USP_SMHR_BUSINESSUNIT @Operation = 'Check1', " +
        //                               " @BUSINESSUNIT_ORGANISATION_ID = '" + _obj_Smhr_BusinessUnit.ORGANISATION_ID + "'" +
        //                               ",@BU_LOGIN_ID = '" + _obj_Smhr_BusinessUnit.BU_LOGIN_ID + "'");
        //    }
        //    else if (_obj_Smhr_BusinessUnit.OPERATION == operation.Empty)
        //    {
        //        return ExecuteQuery("EXEC USP_SMHR_BUSINESSUNIT @Operation = 'Empty', " +
        //                            "@BUSINESSUNIT_ID =" + Convert.ToString(_obj_Smhr_BusinessUnit.BUSINESSUNIT_ID + "" +
        //                            ",@BUSINESSUNIT_ORGANISATION_ID = '" + _obj_Smhr_BusinessUnit.ORGANISATION_ID + "'"));
        //    }
        //    else if (_obj_Smhr_BusinessUnit.OPERATION == operation.Validate)
        //    {
        //        return ExecuteQuery("EXEC USP_SMHR_BUSINESSUNIT @Operation='Validate'," +
        //            " @BUSINESSUNIT_CODE ='" + Convert.ToString(_obj_Smhr_BusinessUnit.BUSINESSUNIT_CODE) + "'," +
        //            " @BUSINESSUNIT_ORGANISATION_ID = '" + _obj_Smhr_BusinessUnit.ORGANISATION_ID + "'");
        //    }

        //    else if (_obj_Smhr_BusinessUnit.OPERATION == operation.SELECTEMPLOYEE1)
        //    {
        //        return ExecuteQuery("EXEC USP_SMHR_EMPLOYEE @Operation = 'SELECTEMPLOYEE1', @EMP_ORGANISATION_ID = '" + _obj_Smhr_BusinessUnit.ORGANISATION_ID + "'" +
        //                             ",@emp_id = '" + _obj_Smhr_BusinessUnit.BUID + "',@EMP_BUSINESSUNIT_ID =" + Convert.ToString(_obj_Smhr_BusinessUnit.BUSINESSUNIT_ID + ""));
        //    }

        //    else if (_obj_Smhr_BusinessUnit.OPERATION == operation.SELECTEMPLOYEE)
        //    {

        //        return ExecuteQuery("EXEC USP_SMHR_EMPLOYEE @Operation = 'SELECTEMPLOYEE', @EMP_ORGANISATION_ID = '" + _obj_Smhr_BusinessUnit.ORGANISATION_ID + "'" +
        //                            ",@EMP_BUSINESSUNIT_ID =" + Convert.ToString(_obj_Smhr_BusinessUnit.BUSINESSUNIT_ID + ""));
        //    }

        //    else if (_obj_Smhr_BusinessUnit.OPERATION == operation.load)
        //    {
        //        return ExecuteQuery("EXEC USP_SMHR_BUSINESSUNIT @Operation = 'load', " +
        //                            "@BUSINESSUNIT_ID =" + Convert.ToString(_obj_Smhr_BusinessUnit.BUSINESSUNIT_ID + "" +
        //                            ",@BUSINESSUNIT_ORGANISATION_ID = '" + _obj_Smhr_BusinessUnit.ORGANISATION_ID + "'"));
        //    }

        //    else
        //    {
        //        return ExecuteQuery("EXEC USP_SMHR_BUSINESSUNIT @Operation = 'Empty1', " +
        //                            "@BUSINESSUNIT_ID =" + Convert.ToString(_obj_Smhr_BusinessUnit.BUSINESSUNIT_ID + "" +
        //                            ",@BUSINESSUNIT_ORGANISATION_ID = '" + _obj_Smhr_BusinessUnit.ORGANISATION_ID + "'"));
        //    }




        //}
        ///// <summary>
        ///// Method to Insert or update into the BusinessUnit table Using Information Passed using the Object. 
        ///// </summary>
        ///// <param name="_obj_Smhr_BusinessUnit"></param>
        ///// <returns>Boolean stating the Success or failure</returns>
        ///// <remarks>
        /////  Author             : BK 
        /////  Created on         : 2009-08-11
        /////  Last Modified on   : N/A
        /////  Last Modfied by    : N/A
        ///// </remarks>
        //public static bool set_BusinessUnit(SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit)
        //{
        //    bool status = false;
        //    switch (_obj_Smhr_BusinessUnit.OPERATION)
        //    {
        //        case operation.Insert:
        //            if (ExecuteNonQuery("EXEC USP_SMHR_BUSINESSUNIT @Operation = 'Insert', @BUSINESSUNIT_CODE='" + _obj_Smhr_BusinessUnit.BUSINESSUNIT_CODE
        //                              + "', @BUSINESSUNIT_DESC='" + _obj_Smhr_BusinessUnit.BUSINESSUNIT_DESC
        //                              + "', @BUSINESSUNIT_CATAGORY_ID='" + Convert.ToString(_obj_Smhr_BusinessUnit.BUSINESSUNIT_CATAGORY_ID)
        //                              + "',@BUSNIESSUNIT_ISVARIABLEPAY=" + Convert.ToString(_obj_Smhr_BusinessUnit.IS_VARIABLEPAY)
        //                              + " , @BUSINESSUNIT_PARENT_BUSINESSUNIT_ID=" + Convert.ToString(_obj_Smhr_BusinessUnit.BUSINESSUNIT_PARENT_BUSINESSUNIT_ID)
        //                              + " , @BUSINESSUNIT_CURRENCY_ID=" + (_obj_Smhr_BusinessUnit.BUSINESSUNIT_CURRENCY_ID == null ? "null" : Convert.ToString(_obj_Smhr_BusinessUnit.BUSINESSUNIT_CURRENCY_ID))
        //                              + " , @BUSINESSUNIT_DATEFORMAT_ID=" + (_obj_Smhr_BusinessUnit.BUSINESSUNIT_DATEFORMAT_ID == null ? "null" : Convert.ToString(_obj_Smhr_BusinessUnit.BUSINESSUNIT_DATEFORMAT_ID))
        //                              + " , @BUSINESSUNIT_ADDRESS=" + (_obj_Smhr_BusinessUnit.BUSINESSUNIT_ADDRESS == null ? "null" : "'" + Convert.ToString(_obj_Smhr_BusinessUnit.BUSINESSUNIT_ADDRESS) + "'")
        //                              + " , @BUSINESSUNIT_OVERTIME=" + (_obj_Smhr_BusinessUnit.BUSINESSUNIT_OVERTIME == null ? "null" : "'" + Convert.ToString(_obj_Smhr_BusinessUnit.BUSINESSUNIT_OVERTIME) + "'")
        //                              + " , @BUSINESSUNIT_COUNTRY_ID=" + (_obj_Smhr_BusinessUnit.BUSINESSUNIT_COUNTRY_ID == null ? "null" : Convert.ToString(_obj_Smhr_BusinessUnit.BUSINESSUNIT_COUNTRY_ID))
        //                              + " , @BUSINESSUNIT_AGE=" + (_obj_Smhr_BusinessUnit.BUSINESSUNIT_AGE == null ? "null" : "'" + _obj_Smhr_BusinessUnit.BUSINESSUNIT_AGE + "'")
        //                              + " , @BUSINESSUNIT_FISCALYEAR=" + (_obj_Smhr_BusinessUnit.BUSINESSUNIT_FISCALYEAR == null ? "null" : "'" + _obj_Smhr_BusinessUnit.BUSINESSUNIT_FISCALYEAR + "'")
        //                              + " , @BUSINESSUNIT_CALENDERYEAR=" + (_obj_Smhr_BusinessUnit.BUSINESSUNIT_CALENDERYEAR == null ? "null" : "'" + _obj_Smhr_BusinessUnit.BUSINESSUNIT_CALENDERYEAR + "'")
        //                              + " , @BUSINESSUNIT_EMPCODE ='" + Convert.ToString(_obj_Smhr_BusinessUnit.BUSINESSUNIT_EMPCODE)
        //                              + "', @BUSINESSUNIT_PAYTYPE ='" + Convert.ToString(_obj_Smhr_BusinessUnit.BUSINESSUNIT_PAYTYPE)
        //                              + "', @BUSINESSUNIT_SUPERVISOR = " + Convert.ToString(_obj_Smhr_BusinessUnit.BUSINESSUNIT_SUPERVISOR)
        //                              + ",  @BUSINESSUNIT_ORGANISATION_ID = '" + _obj_Smhr_BusinessUnit.ORGANISATION_ID
        //                              + "', @BUSINESSUNIT_STARTDATE=" + (_obj_Smhr_BusinessUnit.STARTDATE == null ? "null" : "'" + Convert.ToDateTime(_obj_Smhr_BusinessUnit.STARTDATE).ToString("MM/dd/yyyy") + "'")
        //                              + " , @BUSINESSUNIT_ENDDATE=" + (_obj_Smhr_BusinessUnit.ENDDATE == null ? "null" : "'" + Convert.ToDateTime(_obj_Smhr_BusinessUnit.ENDDATE).ToString("MM/dd/yyyy") + "'")
        //                              + " , @BUSINESSUNIT_PAYMENTMETHODS=" + (_obj_Smhr_BusinessUnit.BUSINESSUNIT_PAYMENTMETHODS == null ? "null" : "'" + _obj_Smhr_BusinessUnit.BUSINESSUNIT_PAYMENTMETHODS + "'")
        //                              + " ,@BUSINESSUNIT_ISMETRO = '" + Convert.ToBoolean(_obj_Smhr_BusinessUnit.BUSINESSUNIT_ISMETRO) + "'" +
        //                              ", @BUSINESSUNIT_CREATEDBY= " + Convert.ToString(_obj_Smhr_BusinessUnit.CREATEDBY)
        //                              + " , @BUSINESSUNIT_CREATEDDATE='" + _obj_Smhr_BusinessUnit.CREATEDDATE.ToString("MM/dd/yyyy")
        //                              + "', @BUSINESSUNIT_LASTMDFBY =" + Convert.ToString(_obj_Smhr_BusinessUnit.LASTMDFBY)
        //                              + ",  @BUSINESSUNIT_LOCALISATION = '" + Convert.ToInt32(_obj_Smhr_BusinessUnit.BUSINESSUNIT_LOCALISATION1) + "'"
        //                              + ",  @BUSINESSUNIT_LASTMDFDATE='" + _obj_Smhr_BusinessUnit.LASTMDFDATE.ToString("MM/dd/yyyy") + "'"
        //                              + ",@BUSINESSUNIT_BASICPERCENT='" + _obj_Smhr_BusinessUnit.BUSINESSUNIT_BASICPERCENT + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        case operation.Update:
        //            if (ExecuteNonQuery("EXEC USP_SMHR_BUSINESSUNIT @Operation = 'Update',@BUSINESSUNIT_ID=" + Convert.ToString(_obj_Smhr_BusinessUnit.BUSINESSUNIT_ID)
        //                              + " , @BUSINESSUNIT_CODE='" + _obj_Smhr_BusinessUnit.BUSINESSUNIT_CODE
        //                              + "', @BUSINESSUNIT_DESC='" + _obj_Smhr_BusinessUnit.BUSINESSUNIT_DESC
        //                              + "', @BUSINESSUNIT_CATAGORY_ID='" + Convert.ToString(_obj_Smhr_BusinessUnit.BUSINESSUNIT_CATAGORY_ID)
        //                              + "',@BUSNIESSUNIT_ISVARIABLEPAY=" + Convert.ToString(_obj_Smhr_BusinessUnit.IS_VARIABLEPAY)
        //                              + " , @BUSINESSUNIT_PARENT_BUSINESSUNIT_ID=" + Convert.ToString(_obj_Smhr_BusinessUnit.BUSINESSUNIT_PARENT_BUSINESSUNIT_ID)
        //                              + " , @BUSINESSUNIT_CURRENCY_ID=" + (_obj_Smhr_BusinessUnit.BUSINESSUNIT_CURRENCY_ID == null ? "null" : Convert.ToString(_obj_Smhr_BusinessUnit.BUSINESSUNIT_CURRENCY_ID))
        //                              + " , @BUSINESSUNIT_ORGANISATION_ID = '" + _obj_Smhr_BusinessUnit.ORGANISATION_ID
        //                              + "' , @BUSINESSUNIT_DATEFORMAT_ID=" + (_obj_Smhr_BusinessUnit.BUSINESSUNIT_DATEFORMAT_ID == null ? "null" : Convert.ToString(_obj_Smhr_BusinessUnit.BUSINESSUNIT_DATEFORMAT_ID))
        //                              + " , @BUSINESSUNIT_ADDRESS=" + (_obj_Smhr_BusinessUnit.BUSINESSUNIT_ADDRESS == null ? "null" : "'" + Convert.ToString(_obj_Smhr_BusinessUnit.BUSINESSUNIT_ADDRESS) + "'")
        //                              + " , @BUSINESSUNIT_OVERTIME=" + (_obj_Smhr_BusinessUnit.BUSINESSUNIT_OVERTIME == null ? "null" : "'" + Convert.ToString(_obj_Smhr_BusinessUnit.BUSINESSUNIT_OVERTIME) + "'")
        //                              + " , @BUSINESSUNIT_COUNTRY_ID=" + (_obj_Smhr_BusinessUnit.BUSINESSUNIT_COUNTRY_ID == null ? "null" : Convert.ToString(_obj_Smhr_BusinessUnit.BUSINESSUNIT_COUNTRY_ID))
        //                              + " , @BUSINESSUNIT_AGE=" + (_obj_Smhr_BusinessUnit.BUSINESSUNIT_AGE == null ? "null" : "'" + _obj_Smhr_BusinessUnit.BUSINESSUNIT_AGE + "'")
        //                              + " , @BUSINESSUNIT_FISCALYEAR=" + (_obj_Smhr_BusinessUnit.BUSINESSUNIT_FISCALYEAR == null ? "null" : "'" + _obj_Smhr_BusinessUnit.BUSINESSUNIT_FISCALYEAR + "'")
        //                              + " , @BUSINESSUNIT_CALENDERYEAR=" + (_obj_Smhr_BusinessUnit.BUSINESSUNIT_CALENDERYEAR == null ? "null" : "'" + _obj_Smhr_BusinessUnit.BUSINESSUNIT_CALENDERYEAR + "'")
        //                              + " , @BUSINESSUNIT_PAYMENTMETHODS=" + (_obj_Smhr_BusinessUnit.BUSINESSUNIT_PAYMENTMETHODS == null ? "null" : "'" + _obj_Smhr_BusinessUnit.BUSINESSUNIT_PAYMENTMETHODS + "'")
        //                              + " , @BUSINESSUNIT_EMPCODE ='" + Convert.ToString(_obj_Smhr_BusinessUnit.BUSINESSUNIT_EMPCODE)
        //                              + "', @BUSINESSUNIT_PAYTYPE ='" + Convert.ToString(_obj_Smhr_BusinessUnit.BUSINESSUNIT_PAYTYPE)
        //                              + "', @BUSINESSUNIT_SUPERVISOR = " + Convert.ToString(_obj_Smhr_BusinessUnit.BUSINESSUNIT_SUPERVISOR)
        //                              + ",  @BUSINESSUNIT_STARTDATE=" + (_obj_Smhr_BusinessUnit.STARTDATE == null ? "null" : "'" + Convert.ToDateTime(_obj_Smhr_BusinessUnit.STARTDATE).ToString("MM/dd/yyyy") + "'")
        //                              + " , @BUSINESSUNIT_ENDDATE=" + (_obj_Smhr_BusinessUnit.ENDDATE == null ? "null" : "'" + Convert.ToDateTime(_obj_Smhr_BusinessUnit.ENDDATE).ToString("MM/dd/yyyy") + "'")
        //                              + " , @BUSINESSUNIT_LASTMDFBY =" + Convert.ToString(_obj_Smhr_BusinessUnit.LASTMDFBY)
        //                              + ", @BUSINESSUNIT_LOCALISATION = '" + Convert.ToInt32(_obj_Smhr_BusinessUnit.BUSINESSUNIT_LOCALISATION1) + "'"
        //                              + " , @BUSINESSUNIT_LASTMDFDATE='" + _obj_Smhr_BusinessUnit.LASTMDFDATE.ToString("MM/dd/yyyy") + "'"
        //                              + ",@BUSINESSUNIT_BASICPERCENT='" + _obj_Smhr_BusinessUnit.BUSINESSUNIT_BASICPERCENT + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        case operation.Delete:
        //            if (ExecuteNonQuery("EXEC USP_SMHR_BUSINESSUNIT @Operation = 'Delete',@BUSINESSUNIT_ID=" + Convert.ToString(_obj_Smhr_BusinessUnit.BUSINESSUNIT_ID)
        //                              + " , @BUSINESSUNIT_LASTMDFBY =" + Convert.ToString(_obj_Smhr_BusinessUnit.LASTMDFBY)
        //                              + " , @BUSINESSUNIT_LASTMDFDATE='" + _obj_Smhr_BusinessUnit.LASTMDFDATE.ToString("MM/dd/yyyy") + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        default:
        //            break;
        //    }
        //    return status;
        //}
        //#endregion

        //# region SMHR_DEPARTMENT

        //public static DataTable get_Department(SMHR_DEPARTMENT _obj_SMHR_Department)
        //{
        //    if (_obj_SMHR_Department.MODE == 3)
        //    {
        //        return Dal.ExecuteQuery("EXEC USP_SMHR_DEPARTMENT @MODE = '" + _obj_SMHR_Department.MODE + "', " +
        //                                " @DEPARTMENT_NAME = '" + _obj_SMHR_Department.DEPARTMENT_NAME + "'" +
        //                                ", @DEPARTMENT_BUID = '" + _obj_SMHR_Department.BUID + "'" +
        //                                ", @DEPARTMENT_ORG_ID = '" + _obj_SMHR_Department.ORGANISATION_ID + "'");
        //    }
        //    else if (_obj_SMHR_Department.MODE == 7)
        //    {
        //        return Dal.ExecuteQuery("EXEC USP_SMHR_DEPARTMENT @MODE = '" + _obj_SMHR_Department.MODE + "'" +
        //                                ", @DEPARTMENT_BUID = '" + _obj_SMHR_Department.BUID + "'");
        //    }
        //    else if (_obj_SMHR_Department.MODE == 5)
        //    {
        //        return Dal.ExecuteQuery("EXEC USP_SMHR_DEPARTMENT @MODE = '" + _obj_SMHR_Department.MODE + "'" +
        //                                ", @DEPARTMENT_ORG_ID = '" + _obj_SMHR_Department.ORGANISATION_ID + "'");
        //    }
        //    else if (_obj_SMHR_Department.MODE == 8)
        //    {
        //        return Dal.ExecuteQuery("EXEC USP_SMHR_DEPARTMENT @MODE = '" + _obj_SMHR_Department.MODE + "'" +
        //                              ", @DEPARTMENT_BUID = '" + _obj_SMHR_Department.BUID + "'");
        //    }
        //    else if (_obj_SMHR_Department.MODE == 9)
        //    {
        //        return Dal.ExecuteQuery("EXEC USP_SMHR_DEPARTMENT @MODE = '" + _obj_SMHR_Department.MODE + "'" +
        //                              ", @DEPARTMENT_BUID = '" + _obj_SMHR_Department.BUID + "'" +
        //                              ", @DEPARTMENT_ORG_ID = '" + _obj_SMHR_Department.ORGANISATION_ID + "'");
        //    }
        //    else
        //    {
        //        return Dal.ExecuteQuery("EXEC USP_SMHR_DEPARTMENT @MODE = '" + _obj_SMHR_Department.MODE + "'," +
        //                        " @DEPARTMENT_ID = '" + _obj_SMHR_Department.DEPARTMENT_ID + "'");
        //    }
        //}

        //public static bool set_Department(SMHR_DEPARTMENT _obj_SMHR_Department)
        //{
        //    bool status = false;
        //    if (_obj_SMHR_Department.MODE == 1)
        //    {
        //        if (Dal.ExecuteNonQuery("EXEC USP_SMHR_DEPARTMENT @MODE = '" + _obj_SMHR_Department.MODE + "'" +
        //                                ",@DEPARTMENT_NAME = '" + _obj_SMHR_Department.DEPARTMENT_NAME + "'" +
        //                                ",@DEPARTMENT_DESC = '" + _obj_SMHR_Department.DEPARTMENT_DESC + "'" +
        //                                ",@DEPARTMENT_BUID = '" + _obj_SMHR_Department.BUID + "'" +
        //                                ",@DEPARTMENT_ORG_ID = '" + _obj_SMHR_Department.ORGANISATION_ID + "'" +
        //                                ",@DEPARTMENT_ISACTIVE = '" + _obj_SMHR_Department.DEPARTMENT_ISACTIVE + "'" +
        //                                ",@DEPARTMENT_CREATEDBY = '" + _obj_SMHR_Department.CREATEDBY + "'" +
        //                                ",@DEPARTMENT_CREATEDDATE = '" + _obj_SMHR_Department.CREATEDDATE + "'" +
        //                                ",@DEPARTMENT_LASTMDFBY = '" + _obj_SMHR_Department.LASTMDFBY + "'" +
        //                                ",@DEPARTMENT_LASTMDFDATE = '" + _obj_SMHR_Department.LASTMDFDATE + "'"))
        //            status = true;
        //        else
        //            status = false;
        //    }
        //    else
        //    {
        //        if (Dal.ExecuteNonQuery("EXEC USP_SMHR_DEPARTMENT @MODE = '" + _obj_SMHR_Department.MODE + "'" +
        //                ",@DEPARTMENT_ID = '" + _obj_SMHR_Department.DEPARTMENT_ID + "'" +
        //                ",@DEPARTMENT_NAME = '" + _obj_SMHR_Department.DEPARTMENT_NAME + "'" +
        //                ",@DEPARTMENT_DESC = '" + _obj_SMHR_Department.DEPARTMENT_DESC + "'" +
        //                ",@DEPARTMENT_BUID = '" + _obj_SMHR_Department.BUID + "'" +
        //                ",@DEPARTMENT_ORG_ID = '" + _obj_SMHR_Department.ORGANISATION_ID + "'" +
        //                ",@DEPARTMENT_ISACTIVE = '" + _obj_SMHR_Department.DEPARTMENT_ISACTIVE + "'" +
        //                ",@DEPARTMENT_LASTMDFBY = '" + _obj_SMHR_Department.LASTMDFBY + "'" +
        //                ",@DEPARTMENT_LASTMDFDATE = '" + _obj_SMHR_Department.LASTMDFDATE + "'"))
        //            status = true;
        //        else
        //            status = false;
        //    }
        //    return status;
        //}

        //#endregion

        //#region SMHR_POSITIONS

        ///// <summary>
        /////  Method to Get Positions Based on the POSITIONS_ID
        ///// </summary>
        ///// <param name="POSITIONS_ID"></param>
        ///// <returns>Datatable with SMHR_POSITIONS Information</returns>
        ///// <remarks>
        /////  Author             : BK 
        /////  Created on         : 2009-08-26 
        /////  Last Modified on   : N/A
        /////  Last Modfied by    : N/A
        ///// </remarks>
        //public static DataTable get_Positions(SMHR_POSITIONS _obj_Smhr_Positions)
        //{
        //    if (_obj_Smhr_Positions.OPERATION == operation.Select)
        //    {
        //        if (_obj_Smhr_Positions.POSITIONS_ID == 0)
        //            return ExecuteQuery("EXEC USP_SMHR_POSITIONS @Operation = 'select',@POSITIONS_ORGANISATION_ID= '" + _obj_Smhr_Positions.ORGANISATION_ID + "'");
        //        else
        //            return ExecuteQuery("EXEC USP_SMHR_POSITIONS @Operation = 'select', @POSITIONS_ID=" + Convert.ToString(_obj_Smhr_Positions.POSITIONS_ID) + ",@POSITIONS_ORGANISATION_ID='" + _obj_Smhr_Positions.ORGANISATION_ID + "'");
        //    }
        //    else if (_obj_Smhr_Positions.OPERATION == operation.Check)
        //    {
        //        if (_obj_Smhr_Positions.POSITIONS_ID == 0)
        //            return ExecuteQuery("EXEC USP_SMHR_POSITIONS @Operation = 'Check', @POSITIONS_CODE ='" + Convert.ToString(_obj_Smhr_Positions.POSITIONS_CODE) + "',@POSITIONS_ORGANISATION_ID= '" + _obj_Smhr_Positions.ORGANISATION_ID + "'");
        //        else
        //            return ExecuteQuery("EXEC USP_SMHR_POSITIONS @Operation = 'Check', @POSITIONS_CODE ='" + Convert.ToString(_obj_Smhr_Positions.POSITIONS_CODE) + "', @POSITIONS_ID =" + Convert.ToString(_obj_Smhr_Positions.POSITIONS_ID) + ", @POSITIONS_ORGANISATION_ID= '" + _obj_Smhr_Positions.ORGANISATION_ID + "'");
        //    }
        //    else
        //    {
        //        return ExecuteQuery("EXEC USP_SMHR_POSITIONS @Operation = 'Empty', @POSITIONS_ID =" + Convert.ToString(_obj_Smhr_Positions.POSITIONS_ID) + ",@POSITIONS_ORGANISATION_ID='" + _obj_Smhr_Positions.ORGANISATION_ID + "'");
        //    }
        //}
        ///// <summary>
        /////  Method to Get Positions Based on the BU_ID
        ///// </summary>
        ///// <param name="BU_ID"></param>
        ///// <returns>Datatable with SMHR_POSITIONS AND SMHR_JOBLOCATIONS Information</returns>
        ///// <remarks>
        /////  Author             : Joseph 
        /////  Created on         : 2009-11-21 
        /////  Last Modified on   : N/A
        /////  Last Modfied by    : N/A
        ///// </remarks>
        //public static DataTable get_BUPositions(SMHR_POSITIONS _obj_Smhr_Positions)
        //{
        //    return ExecuteQuery("EXEC USP_SMHR_POSITIONS @Operation = 'EMPTY',  " +
        //                         " @POSITIONS_ISDELETED = 1, " +
        //                        " @JOBLOC_BUSINESSUNIT_ID=" + Convert.ToString(_obj_Smhr_Positions.JOBLOC_BUSINESSUNIT_ID)
        //                        + ",@POSITIONS_ORGANISATION_ID='" + _obj_Smhr_Positions.ORGANISATION_ID + "'");
        //}
        ///// <summary>
        ///// Method to Insert or update into the Positions table Using Information Passed using the Object. 
        ///// </summary>
        ///// <param name="_obj_Smhr_Positions"></param>
        ///// <returns>Boolean stating the Success or failure</returns>
        ///// <remarks>
        /////  Author             : BK 
        /////  Created on         : 2009-08-26
        /////  Last Modified on   : N/A
        /////  Last Modfied by    : N/A
        ///// </remarks>
        //public static bool set_Positions(SMHR_POSITIONS _obj_Smhr_Positions)
        //{
        //    bool status = false;
        //    switch (_obj_Smhr_Positions.OPERATION)
        //    {
        //        case operation.Insert:
        //            if (ExecuteNonQuery("EXEC USP_SMHR_POSITIONS @Operation = 'Insert', @POSITIONS_CODE='" + _obj_Smhr_Positions.POSITIONS_CODE
        //                              + "', @POSITIONS_ORGANISATION_ID = '" + _obj_Smhr_Positions.ORGANISATION_ID
        //                              + "', @POSITIONS_DESC='" + _obj_Smhr_Positions.POSITIONS_DESC
        //                              + "', @POSITIONS_JOBSID=" + Convert.ToString(_obj_Smhr_Positions.POSITIONS_JOBSID)
        //                              + " , @POSITIONS_STATUS=" + Convert.ToString(_obj_Smhr_Positions.POSITIONS_STATUS)

        //                              + " , @POSITIONS_STARTDATE=" + (_obj_Smhr_Positions.STARTDATE == null ? "null" : "'" + Convert.ToDateTime(_obj_Smhr_Positions.STARTDATE).ToString("MM/dd/yyyy") + "'")
        //                              + " , @POSITIONS_ENDDATE=" + (_obj_Smhr_Positions.ENDDATE == null ? "null" : "'" + Convert.ToDateTime(_obj_Smhr_Positions.ENDDATE).ToString("MM/dd/yyyy") + "'")

        //                              + " , @POSITIONS_CREATEDBY= " + Convert.ToString(_obj_Smhr_Positions.CREATEDBY)
        //                              + " , @POSITIONS_CREATEDDATE='" + _obj_Smhr_Positions.CREATEDDATE.ToString("MM/dd/yyyy")
        //                              + "', @POSITIONS_LASTMDFBY  =" + Convert.ToString(_obj_Smhr_Positions.LASTMDFBY)
        //                              + " , @POSITIONS_LASTMDFDATE ='" + _obj_Smhr_Positions.LASTMDFDATE.ToString("MM/dd/yyyy") + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        case operation.Update:
        //            if (ExecuteNonQuery("EXEC USP_SMHR_POSITIONS @Operation = 'Update', @POSITIONS_ID=" + Convert.ToString(_obj_Smhr_Positions.POSITIONS_ID)
        //                              + " , @POSITIONS_ORGANISATION_ID = " + _obj_Smhr_Positions.ORGANISATION_ID
        //                              + " , @POSITIONS_CODE='" + _obj_Smhr_Positions.POSITIONS_CODE
        //                              + "', @POSITIONS_DESC='" + _obj_Smhr_Positions.POSITIONS_DESC
        //                              + "', @POSITIONS_JOBSID=" + Convert.ToString(_obj_Smhr_Positions.POSITIONS_JOBSID)
        //                              + " , @POSITIONS_STATUS=" + Convert.ToString(_obj_Smhr_Positions.POSITIONS_STATUS)
        //                              + " , @POSITIONS_STARTDATE=" + (_obj_Smhr_Positions.STARTDATE == null ? "null" : "'" + Convert.ToDateTime(_obj_Smhr_Positions.STARTDATE).ToString("MM/dd/yyyy") + "'")
        //                              + " , @POSITIONS_ENDDATE=" + (_obj_Smhr_Positions.ENDDATE == null ? "null" : "'" + Convert.ToDateTime(_obj_Smhr_Positions.ENDDATE).ToString("MM/dd/yyyy") + "'")
        //                              + " , @POSITIONS_LASTMDFBY  =" + Convert.ToString(_obj_Smhr_Positions.LASTMDFBY)
        //                              + " , @POSITIONS_LASTMDFDATE ='" + _obj_Smhr_Positions.LASTMDFDATE.ToString("MM/dd/yyyy") + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        case operation.Delete:
        //            if (ExecuteNonQuery("EXEC USP_SMHR_POSITIONS @Operation = 'Delete', @POSITIONS_ID=" + Convert.ToString(_obj_Smhr_Positions.POSITIONS_ID)
        //                              + " , @POSITIONS_LASTMDFBY  =" + Convert.ToString(_obj_Smhr_Positions.LASTMDFBY)
        //                              + " , @POSITIONS_LASTMDFDATE ='" + _obj_Smhr_Positions.LASTMDFDATE.ToString("MM/dd/yyyy") + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        default:
        //            break;
        //    }
        //    return status;
        //}
        //#endregion


        //#region SMHR_SALARYSTRUCT

        ///// <summary>
        ///// Gets the Salary Structure Header Details. 
        ///// </summary>
        ///// <param name="_obj_Smhr_Category"></param>
        ///// <returns>Data Table</returns>
        ///// <remarks>
        /////  Author             : Gunti Dheeraj 
        /////  Created on         : 2009-08-19
        /////  Last Modified on   : N/A
        /////  Last Modfied by    : N/A
        ///// </remarks>

        //public static DataTable get_SalaryHeaderDetails(SMHR_SALARYSTRUCT _obj_smhr_salaryStruct)
        //{
        //    if (_obj_smhr_salaryStruct.OPERATION == operation.Select)
        //    {
        //        if (_obj_smhr_salaryStruct.SALARYSTRUCT_ID.ToString() == "0")
        //        {
        //            //return ExecuteQuery("Exec USP_SMHR_SALARYSTRUCT @Operation = 'Select'");
        //            return ExecuteQuery("Exec USP_SMHR_SALARYSTRUCT @Operation = 'Select', " +
        //                                "@SALARYSTRUCT_ORGANISATION_ID = '" + _obj_smhr_salaryStruct.ORGANISATION_ID + "'" +
        //                                ",@SALARYSTRUCT_TYPE= " + (_obj_smhr_salaryStruct.ISDELETED == null ? "null" : "'1'"));
        //        }
        //        else
        //        {
        //            return ExecuteQuery("Exec USP_SMHR_SALARYSTRUCT @Operation = 'Select'," +
        //                                "@SALARYSTRUCT_ID = '" + Convert.ToString(_obj_smhr_salaryStruct.SALARYSTRUCT_ID) + "'" +
        //                                ",@SALARYSTRUCT_ORGANISATION_ID = '" + _obj_smhr_salaryStruct.ORGANISATION_ID + "'");
        //        }
        //    }
        //    else if (_obj_smhr_salaryStruct.OPERATION == operation.LOADSALARY)
        //    {
        //        return ExecuteQuery("Exec USP_SMHR_SALARYSTRUCT @Operation = 'LOADSALARY'");


        //    }

        //    else if (_obj_smhr_salaryStruct.OPERATION == operation.Check)
        //    {
        //        if (_obj_smhr_salaryStruct.SALARYSTRUCT_CODE != null)
        //        {
        //            return ExecuteQuery("Exec USP_SMHR_SALARYSTRUCT @Operation = 'Check', " +
        //                                "@SALARYSTRUCT_ORGANISATION_ID = '" + _obj_smhr_salaryStruct.ORGANISATION_ID + "'," +
        //                                "@SALARYSTRUCT_CODE = '" + _obj_smhr_salaryStruct.SALARYSTRUCT_CODE + "'");
        //        }
        //        else
        //        {
        //            return ExecuteQuery("Exec USP_SMHR_SALARYSTRUCT @Operation = 'check', " +
        //                                "@SALARYSTRUCT_NAME = '" + Convert.ToString(_obj_smhr_salaryStruct.SALARYSTRUCT_NAME) + "'," +
        //                                "@SALARYSTRUCT_ID = '" + Convert.ToString(_obj_smhr_salaryStruct.SALARYSTRUCT_ID) + "'" +
        //                                "@SALARYSTRUCT_ORGANISATION_ID = '" + _obj_smhr_salaryStruct.ORGANISATION_ID + "'");
        //        }
        //    }
        //    else
        //    {
        //        return ExecuteQuery("Exec USP_SMHR_SALARYSTRUCT @Operation = 'Empty'");
        //    }
        //}

        ///// <summary>
        ///// Gets the Salary Structure Details. 
        ///// </summary>
        ///// <param name="_obj_Smhr_Category"></param>
        ///// <returns>Data Table</returns>
        ///// <remarks>
        /////  Author             : Gunti Dheeraj 
        /////  Created on         : 2009-08-19
        /////  Last Modified on   : N/A
        /////  Last Modfied by    : N/A
        ///// </remarks>

        //public static DataTable get_SalaryDetails(SMHR_SALARYSTRUCT _obj_smhr_salaryStruct)
        //{
        //    if (_obj_smhr_salaryStruct.OPERATION == operation.Select)
        //    {
        //        if (_obj_smhr_salaryStruct.SALARYSTRUCT_ID.ToString() == "0")
        //        {
        //            return ExecuteQuery("Exec USP_SMHR_SALARYSTRUCTDETAILS @Operation = 'Select'");
        //        }
        //        else
        //        {
        //            return ExecuteQuery("Exec USP_SMHR_SALARYSTRUCTDETAILS @Operation = 'Select', @SALARYSTRUCTDET_ID = '" + Convert.ToString(_obj_smhr_salaryStruct.SALARYSTRUCT_ID) + "'");
        //        }
        //    }
        //    else
        //    {
        //        return ExecuteQuery("Exec USP_SMHR_SALARYSTRUCTDETAILS @Operation = 'check', @SALARYSTRUCTDET_SALSTR_ID = '" + Convert.ToString(_obj_smhr_salaryStruct.SALARYSTRUCT_ID) + "'" +
        //                            ",@PAYITEM_ORGANISATION_ID = '" + _obj_smhr_salaryStruct.ORGANISATION_ID + "'");
        //    }
        //}

        ///// <summary>
        ///// Method for Inserting and Updaing Salary Structure Header Details. 
        ///// </summary>
        ///// <returns>Bool stating Success or Failure</returns>
        ///// <remarks>
        /////  Author             : Gunti Dheeraj 
        /////  Created on         : 2009-08-20
        /////  Last Modified on   : N/A
        /////  Last Modfied by    : N/A
        ///// </remarks>
        ///// 

        //public static bool set_SalaryHeaderDetails(SMHR_SALARYSTRUCT _obj_smhr_salaryStruct)
        //{
        //    bool status = false;
        //    switch (_obj_smhr_salaryStruct.OPERATION)
        //    {
        //        case operation.Insert:
        //            if (ExecuteNonQuery(" EXEC USP_SMHR_SALARYSTRUCT @Operation = '" + _obj_smhr_salaryStruct.OPERATION + "'" +
        //                                ",@SALARYSTRUCT_CODE = '" + Convert.ToString(_obj_smhr_salaryStruct.SALARYSTRUCT_CODE) + "'" +
        //                                ",@SALARYSTRUCT_NAME = '" + Convert.ToString(_obj_smhr_salaryStruct.SALARYSTRUCT_NAME) + "'" +
        //                                ",@SALARYSTRUCT_STARTDATE = '" + Convert.ToDateTime(_obj_smhr_salaryStruct.SALARYSTRUCT_STARTDATE).ToString("MM/dd/yyyy") + "'" +
        //                                ",@SALARYSTRUCT_ENDDATE = " + (_obj_smhr_salaryStruct.SALARYSTRUCT_ENDDATE == null ? "null" : "'" + _obj_smhr_salaryStruct.SALARYSTRUCT_ENDDATE + "'") + "" +
        //                                ",@SALARYSTRUCT_TYPE = '" + Convert.ToInt32(_obj_smhr_salaryStruct.SALARYSTRUCT_TYPE) + "'" +
        //                                ",@SALARYSTRUCT_ORGANISATION_ID = '" + Convert.ToString(_obj_smhr_salaryStruct.SALARYSTRUCT_ORGANISATION_ID) + "'" +
        //                                ",@SALARYSTRUCT_CREATEDBY = '" + Convert.ToInt32(_obj_smhr_salaryStruct.SALARYSTRUCT_CREATEDBY) + "'" +
        //                                ",@SALARYSTRUCT_CREATEDDATE = '" + Convert.ToDateTime(_obj_smhr_salaryStruct.SALARYSTRUCT_CREATEDDATE).ToString("MM/dd/yyyy") + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        case operation.Update:
        //            if (ExecuteNonQuery(" EXEC USP_SMHR_SALARYSTRUCT @Operation = '" + _obj_smhr_salaryStruct.OPERATION + "'" +
        //                                ",@SALARYSTRUCT_CODE = '" + Convert.ToString(_obj_smhr_salaryStruct.SALARYSTRUCT_CODE) + "'" +
        //                                ",@SALARYSTRUCT_NAME = '" + Convert.ToString(_obj_smhr_salaryStruct.SALARYSTRUCT_NAME) + "'" +
        //                                ",@SALARYSTRUCT_STARTDATE = '" + Convert.ToDateTime(_obj_smhr_salaryStruct.SALARYSTRUCT_STARTDATE) + "'" +
        //                                ",@SALARYSTRUCT_ENDDATE = " + (_obj_smhr_salaryStruct.SALARYSTRUCT_ENDDATE == null ? "null" : "'" + _obj_smhr_salaryStruct.SALARYSTRUCT_ENDDATE + "'") + "" +
        //                                ",@SALARYSTRUCT_TYPE = '" + Convert.ToInt32(_obj_smhr_salaryStruct.SALARYSTRUCT_TYPE) + "'" +
        //                                ",@SALARYSTRUCT_ORGANISATION_ID = '" + _obj_smhr_salaryStruct.SALARYSTRUCT_ORGANISATION_ID + "'" +
        //                                ",@SALARYSTRUCT_LASTMDFBY = '" + Convert.ToInt32(_obj_smhr_salaryStruct.SALARYSTRUCT_LASTMDFBY) + "'" +
        //                                ",@SALARYSTRUCT_LASTMDFDATE = '" + Convert.ToDateTime(_obj_smhr_salaryStruct.SALARYSTRUCT_LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
        //                                ",@SALARYSTRUCT_ID = '" + Convert.ToInt32(_obj_smhr_salaryStruct.SALARYSTRUCT_ID) + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        default:
        //            break;
        //    }
        //    return status;
        //}

        ///// <summary>
        ///// Method for Inserting and Updaing Salary Structure Details. 
        ///// </summary>
        ///// <returns>Bool stating Success or Failure</returns>
        ///// <remarks>
        /////  Author             : Gunti Dheeraj 
        /////  Created on         : 2009-08-20
        /////  Last Modified on   : N/A
        /////  Last Modfied by    : N/A
        ///// </remarks>
        ///// 

        //public static bool set_SalaryDetails(SMHR_SALARYSTRUCT _obj_smhr_salaryStruct)
        //{
        //    bool status = false;
        //    switch (_obj_smhr_salaryStruct.OPERATION)
        //    {
        //        case operation.Insert:
        //            if (ExecuteNonQuery(" EXEC USP_SMHR_SALARYSTRUCTDETAILS @Operation = '" + _obj_smhr_salaryStruct.OPERATION + "'" +
        //                               ",@SALARYSTRUCTDET_SALSTR_ID = '" + Convert.ToInt32(_obj_smhr_salaryStruct.SALARYSTRUCT_ID) + "'" +
        //                               ",@SALARYSTRUCTDET_PAYITEM_ID = '" + Convert.ToInt32(_obj_smhr_salaryStruct.SALARYSTRUCTDET_PAYITEM_ID) + "'" +
        //                               ",@SALARYSTRUCTDET_PAYMODE = '" + Convert.ToString(_obj_smhr_salaryStruct.SALARYSTRUCTDET_PAYMODE) + "'" +
        //                               ",@SALARYSTRUCTDET_PAYVALUE = '" + Convert.ToString(_obj_smhr_salaryStruct.SALARYSTRUCTDET_PAYVALUE) + "'" +
        //                               ",@SALARYSTRUCTDET_FORMULA = '" + Convert.ToString(_obj_smhr_salaryStruct.SALARYSTRUCTDET_FORMULA) + "'" +
        //                               ",@SALARYSTRUCTDET_CHECKED = '" + Convert.ToBoolean(_obj_smhr_salaryStruct.SALARYSTRUCTDET_CHECKED) + "'" +
        //                               ",@SALARYSTRUCTDET_CREATEDBY = '" + Convert.ToInt32(_obj_smhr_salaryStruct.SALARYSTRUCT_CREATEDBY) + "'" +
        //                               ",@SALARYSTRUCTDET_CREATEDDATE = '" + Convert.ToDateTime(_obj_smhr_salaryStruct.SALARYSTRUCT_CREATEDDATE).ToString("MM/dd/yyyy") + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        case operation.Update:
        //            if (ExecuteNonQuery(" EXEC USP_SMHR_SALARYSTRUCTDETAILS @Operation = '" + _obj_smhr_salaryStruct.OPERATION + "'" +
        //                               ",@SALARYSTRUCTDET_SALSTR_ID = '" + Convert.ToInt32(_obj_smhr_salaryStruct.SALARYSTRUCT_ID) + "'" +
        //                               ",@SALARYSTRUCTDET_PAYITEM_ID = '" + Convert.ToInt32(_obj_smhr_salaryStruct.SALARYSTRUCTDET_PAYITEM_ID) + "'" +
        //                               ",@SALARYSTRUCTDET_PAYMODE = '" + Convert.ToString(_obj_smhr_salaryStruct.SALARYSTRUCTDET_PAYMODE) + "'" +
        //                               ",@SALARYSTRUCTDET_PAYVALUE = '" + Convert.ToString(_obj_smhr_salaryStruct.SALARYSTRUCTDET_PAYVALUE) + "'" +
        //                               ",@SALARYSTRUCTDET_FORMULA = '" + Convert.ToString(_obj_smhr_salaryStruct.SALARYSTRUCTDET_FORMULA) + "'" +
        //                               ",@SALARYSTRUCTDET_CHECKED = '" + Convert.ToBoolean(_obj_smhr_salaryStruct.SALARYSTRUCTDET_CHECKED) + "'" +
        //                               ",@SALARYSTRUCTDET_LASTMDFBY = '" + Convert.ToInt32(_obj_smhr_salaryStruct.SALARYSTRUCT_LASTMDFBY) + "'" +
        //                               ",@SALARYSTRUCTDET_LASTMDFDATE = '" + Convert.ToDateTime(_obj_smhr_salaryStruct.SALARYSTRUCT_LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
        //                               ",@SALARYSTRUCTDET_ID = '" + Convert.ToInt32(_obj_smhr_salaryStruct.SALARYSTRUCTDET_ID) + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        case operation.Delete:
        //            if (ExecuteNonQuery(" EXEC USP_SMHR_SALARYSTRUCTDETAILS @Operation = '" + _obj_smhr_salaryStruct.OPERATION + "'" +
        //                                ",@SALARYSTRUCTDET_SALSTR_ID = '" + _obj_smhr_salaryStruct.SALARYSTRUCT_ID + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        default:
        //            break;
        //    }
        //    return status;
        //}

        ///// <summary>
        ///// Gets the Empty Salary Structure Details. 
        ///// </summary>
        ///// <param name="_obj_Smhr_Category"></param>
        ///// <returns>Data Table</returns>
        ///// <remarks>
        /////  Author             : Gunti Dheeraj 
        /////  Created on         : 2009-08-20
        /////  Last Modified on   : N/A
        /////  Last Modfied by    : N/A
        ///// </remarks>
        ///// 

        //public static DataTable get_EmptyValues(SMHR_SALARYSTRUCT _obj_smhr_salaryStruct)
        //{
        //    return ExecuteQuery("EXEC USP_SMHR_SALARYSTRUCTDETAILS @Operation = '" + _obj_smhr_salaryStruct.OPERATION + "'," +
        //                        " @PAYITEM_ORGANISATION_ID = '" + _obj_smhr_salaryStruct.ORGANISATION_ID + "'");
        //}

        //public static DataTable get_EmptyValues_Pay(SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems)
        //{
        //    return ExecuteQuery("EXEC USP_SMHR_EMP_PAYITEMS @Operation = '" + _obj_smhr_emp_payitems.OPERATION + "'" +
        //                        ",@SMHR_EMP_PAYITEMS_ID = '" + _obj_smhr_emp_payitems.SMHR_EMP_PAYITEMS_ID + "'");
        //}

        //#endregion

        //#region SMHR_LEAVESTRUCT

        ///// <summary>
        ///// Gets the Leave Structure Header Details. 
        ///// </summary>
        ///// <returns>Data Table</returns>
        ///// <remarks>
        /////  Author             : Gunti Dheeraj 
        /////  Created on         : 2009-08-20
        /////  Last Modified on   : N/A
        /////  Last Modfied by    : N/A
        ///// </remarks>
        ///// 

        //public static DataTable get_LeaveStructHeaderDetails(SMHR_LEAVESTRUCT _obj_smhr_leaveStruct)
        //{
        //    if (_obj_smhr_leaveStruct.OPERATION == operation.Select)
        //    {
        //        if (_obj_smhr_leaveStruct.LEAVESTRUCT_ID.ToString() == "0")
        //        {
        //            return ExecuteQuery("EXEC USP_SMHR_LEAVESTRUCT @Operation = 'select'" +
        //                                ",@LEAVESTRUCT_ORGANISATION_ID = '" + _obj_smhr_leaveStruct.ORGANISATION_ID + "'");
        //        }
        //        else
        //        {
        //            return ExecuteQuery("EXEC USP_SMHR_LEAVESTRUCT @Operation = 'select'," +
        //                                "@LEAVESTRUCT_ID = '" + _obj_smhr_leaveStruct.LEAVESTRUCT_ID + "'" +
        //                                ",@LEAVESTRUCT_ORGANISATION_ID = '" + _obj_smhr_leaveStruct.ORGANISATION_ID + "'");
        //        }
        //    }

        //    else if (_obj_smhr_leaveStruct.OPERATION == operation.loadleavestruct)
        //    {
        //        return ExecuteQuery("EXEC USP_SMHR_LEAVESTRUCT @Operation = 'loadleavestruct'");

        //    }

        //    else
        //    {
        //        return ExecuteQuery("EXEC USP_SMHR_LEAVESTRUCT @Operation = 'check', " +
        //                            "@LEAVESTRUCT_CODE = '" + Convert.ToString(_obj_smhr_leaveStruct.LEAVESTRUCT_CODE) + "'" +
        //                            ",@LEAVESTRUCT_ORGANISATION_ID = '" + _obj_smhr_leaveStruct.ORGANISATION_ID + "'");
        //    }
        //}

        ///// <summary>
        ///// Gets the Leave Structure Details. 
        ///// </summary>
        ///// <returns>Data Table</returns>
        ///// <remarks>
        /////  Author             : Gunti Dheeraj 
        /////  Created on         : 2009-08-20
        /////  Last Modified on   : N/A
        /////  Last Modfied by    : N/A
        ///// </remarks>
        ///// 

        //public static DataTable get_LeaveStructDetails(SMHR_LEAVESTRUCT _obj_smhr_leaveStruct)
        //{
        //    if (_obj_smhr_leaveStruct.OPERATION == operation.Select)
        //    {
        //        if (_obj_smhr_leaveStruct.LEAVESTRUCTDET_ID.ToString() == "0")

        //            return ExecuteQuery("EXEC USP_SMHR_LEAVESTRUCTDET @Operation = 'select', @LEAVESTRUCTDET_ID = '" + _obj_smhr_leaveStruct.LEAVESTRUCT_ID + "'");
        //        else
        //            return ExecuteQuery("EXEC USP_SMHR_LEAVESTRUCTDET @Operation = 'select'");
        //    }
        //    else
        //    {
        //        return ExecuteQuery("EXEC USP_SMHR_LEAVESTRUCTDET @Operation = 'Empty',@LEAVESTRUCTDET_LEAVESTR_ID = '" + _obj_smhr_leaveStruct.LEAVESTRUCTDET_LEAVESTR_ID + "'");
        //    }
        //}

        ///// <summary>
        ///// Method for Insert and Update the Leave Structure Header Details. 
        ///// </summary>
        ///// <returns>Bool stating Success or Failure</returns>
        ///// <remarks>
        /////  Author             : Gunti Dheeraj 
        /////  Created on         : 2009-08-20
        /////  Last Modified on   : N/A
        /////  Last Modfied by    : N/A
        ///// </remarks>
        ///// 

        //public static bool set_LeaveStructHeaderDetails(SMHR_LEAVESTRUCT _obj_smhr_leavestruct)
        //{
        //    bool status = false;
        //    switch (_obj_smhr_leavestruct.OPERATION)
        //    {
        //        case operation.Insert:
        //            if (ExecuteNonQuery(" EXEC USP_SMHR_LEAVESTRUCT @Operation = '" + _obj_smhr_leavestruct.OPERATION + "'" +
        //                                ",@LEAVESTRUCT_CODE = '" + Convert.ToString(_obj_smhr_leavestruct.LEAVESTRUCT_CODE) + "'" +
        //                                ",@LEAVESTRUCT_NAME = '" + Convert.ToString(_obj_smhr_leavestruct.LEAVESTRUCT_NAME) + "'" +
        //                                ",@LEAVESTRUCT_ORGANISATION_ID = '" + _obj_smhr_leavestruct.LEAVESTRUCT_ORGANISATION_ID + "'" +
        //                                ",@LEAVESTRUCT_STARTDATE = " + (_obj_smhr_leavestruct.LEAVESTRUCT_STARTDATE == null ? "null" : "'" + Convert.ToDateTime(_obj_smhr_leavestruct.LEAVESTRUCT_STARTDATE).ToString("MM/dd/yyyy") + "'") + "" +
        //                                ",@LEAVESTRUCT_ENDDATE = " + (_obj_smhr_leavestruct.LEAVESTRUCT_ENDDATE == null ? "null" : "'" + Convert.ToDateTime(_obj_smhr_leavestruct.LEAVESTRUCT_ENDDATE).ToString("MM/dd/yyyy") + "'") + "" +
        //                                ",@LEAVESTRUCT_CREATEDBY = '" + Convert.ToInt32(_obj_smhr_leavestruct.LEAVESTRUCT_CREATEDBY) + "'" +
        //                                ",@LEAVESTRUCT_CREATEDDATE = '" + Convert.ToDateTime(_obj_smhr_leavestruct.LEAVESTRUCT_CREATEDDATE).ToString("MM/dd/yyyy") + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        case operation.Update:
        //            if (ExecuteNonQuery(" EXEC USP_SMHR_LEAVESTRUCT @Operation = '" + _obj_smhr_leavestruct.OPERATION + "'" +
        //                                ",@LEAVESTRUCT_CODE = '" + Convert.ToString(_obj_smhr_leavestruct.LEAVESTRUCT_CODE) + "'" +
        //                                ",@LEAVESTRUCT_NAME = '" + Convert.ToString(_obj_smhr_leavestruct.LEAVESTRUCT_NAME) + "'" +
        //                                ",@LEAVESTRUCT_ORGANISATION_ID = '" + _obj_smhr_leavestruct.LEAVESTRUCT_ORGANISATION_ID + "'" +
        //                                ",@LEAVESTRUCT_STARTDATE = '" + Convert.ToDateTime(_obj_smhr_leavestruct.LEAVESTRUCT_STARTDATE).ToString("MM/dd/yyyy") + "'" +
        //                                ",@LEAVESTRUCT_ENDDATE = " + (_obj_smhr_leavestruct.LEAVESTRUCT_ENDDATE == null ? "null" : "'" + Convert.ToDateTime(_obj_smhr_leavestruct.LEAVESTRUCT_ENDDATE).ToString("MM/dd/yyyy") + "'") + "" +
        //                                ",@LEAVESTRUCT_LASTMDFBY = '" + Convert.ToInt32(_obj_smhr_leavestruct.LEAVESTRUCT_LASTMDFBY) + "'" +
        //                                ",@LEAVESTRUCT_LASTMDFDATE = '" + Convert.ToDateTime(_obj_smhr_leavestruct.LEAVESTRUCT_LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
        //                                ",@LEAVESTRUCT_ID = '" + Convert.ToInt32(_obj_smhr_leavestruct.LEAVESTRUCT_ID) + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        default:
        //            break;
        //    }
        //    return status;
        //}

        ///// <summary>
        ///// Method for Insert and Update the Leave Structure  Details. 
        ///// </summary>
        ///// <returns>Bool stating Success or Failure</returns>
        ///// <remarks>
        /////  Author             : Gunti Dheeraj 
        /////  Created on         : 2009-08-20
        /////  Last Modified on   : N/A
        /////  Last Modfied by    : N/A
        ///// </remarks>
        ///// 

        //public static bool set_LeaveStructDetails(SMHR_LEAVESTRUCT _obj_smhr_leaveStruct)
        //{
        //    bool status = false;
        //    switch (_obj_smhr_leaveStruct.OPERATION)
        //    {
        //        case operation.Insert:
        //            if (ExecuteNonQuery(" EXEC USP_SMHR_LEAVESTRUCTDET @Operation = '" + _obj_smhr_leaveStruct.OPERATION + "'" +
        //                                ",@LEAVESTRUCTDET_LEAVETYPE_ID = '" + Convert.ToInt32(_obj_smhr_leaveStruct.LEAVESTRUCTDET_LEAVETYPE_ID) + "'" +
        //                                ",@LEAVESTRUCTDET_LEAVESTR_ID = '" + Convert.ToInt32(_obj_smhr_leaveStruct.LEAVESTRUCTDET_LEAVESTR_ID) + "'" +
        //                                ",@LEAVESTRUCTDET_ISWEEKLYOFF = '" + Convert.ToBoolean(_obj_smhr_leaveStruct.LEAVESTRUCTDET_ISWEEKLYOFF) + "'" +
        //                                ",@LEAVESTRUCTDET_ALLOWHALFDAYS = '" + Convert.ToBoolean(_obj_smhr_leaveStruct.LEAVESTRUCTDET_ALLOWHALFDAYS) + "'" +
        //                                ",@LEAVESTRUCTDET_ACCUMULATE = '" + Convert.ToBoolean(_obj_smhr_leaveStruct.LEAVESTRUCTDET_ACCUMULATE) + "'" +
        //                                ",@LEAVESTRUCTDET_DAYSPERYEAR = '" + Convert.ToDouble(_obj_smhr_leaveStruct.LEAVESTRUCTDET_DAYSPERYEAR) + "'" +
        //                                ",@LEAVESTRUCTDET_MAXDAYS = '" + Convert.ToDouble(_obj_smhr_leaveStruct.LEAVESTRUCTDET_MAXDAYS) + "'" +
        //                                ",@LEAVESTRUCTDET_CFORWARD = '" + Convert.ToBoolean(_obj_smhr_leaveStruct.LEAVESTRUCTDET_CFORWARD) + "'" +
        //                                ",@LEAVESTRUCTDET_CFMAXDAYS = '" + Convert.ToDouble(_obj_smhr_leaveStruct.LEAVESTRUCTDET_CFMAXDAYS) + "'" +
        //                                ",@LEAVESTRUCTDET_ENCASHMENT = '" + Convert.ToBoolean(_obj_smhr_leaveStruct.LEAVESTRUCTDET_ENCASHMENT) + "'" +
        //                                ",@LEAVESTRUCTDET_MAXENCASHDAYS = '" + Convert.ToDouble(_obj_smhr_leaveStruct.LEAVESTRUCTDET_MAXENCASHDAYS) + "'" +
        //                                ",@LEAVESTRUCTDET_CREATEDBY = '" + Convert.ToInt32(_obj_smhr_leaveStruct.LEAVESTRUCTDET_CREATEDBY) + "'" +
        //                                ",@LEAVESTRUCTDET_CREATEDDATE = '" + Convert.ToDateTime(_obj_smhr_leaveStruct.LEAVESTRUCTDET_CREATEDDATE) + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        case operation.Update:
        //            if (ExecuteNonQuery(" EXEC USP_SMHR_LEAVESTRUCTDET @Operation = '" + _obj_smhr_leaveStruct.OPERATION + "'" +
        //                                ",@LEAVESTRUCTDET_LEAVETYPE_ID = '" + Convert.ToInt32(_obj_smhr_leaveStruct.LEAVESTRUCTDET_LEAVETYPE_ID) + "'" +
        //                                ",@LEAVESTRUCTDET_LEAVESTR_ID = '" + Convert.ToInt32(_obj_smhr_leaveStruct.LEAVESTRUCTDET_LEAVESTR_ID) + "'" +
        //                                ",@LEAVESTRUCTDET_ISWEEKLYOFF = '" + Convert.ToBoolean(_obj_smhr_leaveStruct.LEAVESTRUCTDET_ISWEEKLYOFF) + "'" +
        //                                ",@LEAVESTRUCTDET_ALLOWHALFDAYS = '" + Convert.ToBoolean(_obj_smhr_leaveStruct.LEAVESTRUCTDET_ALLOWHALFDAYS) + "'" +
        //                                ",@LEAVESTRUCTDET_ACCUMULATE = '" + Convert.ToBoolean(_obj_smhr_leaveStruct.LEAVESTRUCTDET_ACCUMULATE) + "'" +
        //                                ",@LEAVESTRUCTDET_DAYSPERYEAR = '" + Convert.ToDouble(_obj_smhr_leaveStruct.LEAVESTRUCTDET_DAYSPERYEAR) + "'" +
        //                                ",@LEAVESTRUCTDET_MAXDAYS = '" + Convert.ToDouble(_obj_smhr_leaveStruct.LEAVESTRUCTDET_MAXDAYS) + "'" +
        //                                ",@LEAVESTRUCTDET_CFORWARD = '" + Convert.ToBoolean(_obj_smhr_leaveStruct.LEAVESTRUCTDET_CFORWARD) + "'" +
        //                                ",@LEAVESTRUCTDET_CFMAXDAYS = '" + Convert.ToDouble(_obj_smhr_leaveStruct.LEAVESTRUCTDET_CFMAXDAYS) + "'" +
        //                                ",@LEAVESTRUCTDET_ENCASHMENT = '" + Convert.ToBoolean(_obj_smhr_leaveStruct.LEAVESTRUCTDET_ENCASHMENT) + "'" +
        //                                ",@LEAVESTRUCTDET_MAXENCASHDAYS = '" + Convert.ToDouble(_obj_smhr_leaveStruct.LEAVESTRUCTDET_MAXENCASHDAYS) + "'" +
        //                                ",@LEAVESTRUCTDET_LASTMDFBY = '" + Convert.ToInt32(_obj_smhr_leaveStruct.LEAVESTRUCTDET_LASTMDFBY) + "'" +
        //                                ",@LEAVESTRUCTDET_LASTMDFDATE = '" + Convert.ToDateTime(_obj_smhr_leaveStruct.LEAVESTRUCTDET_LASTMDFDATE) + "'" +
        //                                ",@LEAVESTRUCTDET_ID = '" + Convert.ToInt32(_obj_smhr_leaveStruct.LEAVESTRUCTDET_ID) + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        case operation.Delete:
        //            if (ExecuteNonQuery("EXEC USP_SMHR_LEAVESTRUCTDET @Operation = '" + _obj_smhr_leaveStruct.OPERATION + "'," +
        //                               " @LEAVESTRUCTDET_ID = '" + Convert.ToInt32(_obj_smhr_leaveStruct.LEAVESTRUCTDET_ID) + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        default:
        //            break;
        //    }
        //    return status;
        //}
        //#endregion




        //#region SMHR_MASTERS

        ///// <summary>
        /////  Method to Get Master Records Based on the Master Type
        ///// </summary>
        ///// <param name="MASTER_TYPE"></param>
        ///// <returns>Datatable with MasterRecords Information</returns>
        ///// <remarks>
        /////  Author             : MKD 
        /////  Created on         : 2009-08-11 
        /////  Last Modified on   : N/A
        /////  Last Modfied by    : N/A
        ///// </remarks>
        //public static DataTable get_MasterRecords(SMHR_MASTERS _obj_Smhr_Masters)
        //{
        //    if (_obj_Smhr_Masters.OPERATION == operation.Select)
        //    {
        //        if (_obj_Smhr_Masters.MASTER_ID.ToString() == "0")
        //            return ExecuteQuery("EXEC USP_SMHR_HR_MASTER @Operation = 'select',@HR_MASTER_TYPE='" + Convert.ToString(_obj_Smhr_Masters.MASTER_TYPE) + "'" +
        //                                ",@HR_MASTER_ORGANISATION_ID = '" + _obj_Smhr_Masters.ORGANISATION_ID + "'");
        //        else
        //            return ExecuteQuery("EXEC USP_SMHR_HR_MASTER @Operation = 'select', @HR_MASTER_ID='" + Convert.ToString(_obj_Smhr_Masters.MASTER_ID) + "'" +
        //                                ",@HR_MASTER_TYPE='" + Convert.ToString(_obj_Smhr_Masters.MASTER_TYPE) + "'");
        //    }
        //    if (_obj_Smhr_Masters.OPERATION == operation.Approve)
        //    {
        //        return ExecuteQuery("EXEC USP_SMHR_HR_MASTER @Operation = 'selectresource',@HR_MASTER_ORGANISATION_ID=" + _obj_Smhr_Masters.HR_MASTER_ORGANISATION_ID + " ");


        //    }
        //    else
        //    {
        //        if (_obj_Smhr_Masters.MASTER_ID.ToString() == "0")
        //            return ExecuteQuery("EXEC USP_SMHR_HR_MASTER @Operation = 'Check', @HR_MASTER_CODE ='" + Convert.ToString(_obj_Smhr_Masters.MASTER_CODE) + "'" +
        //                                ",@HR_MASTER_TYPE='" + Convert.ToString(_obj_Smhr_Masters.MASTER_TYPE) + "'" +
        //                                ",@HR_MASTER_ORGANISATION_ID = '" + _obj_Smhr_Masters.ORGANISATION_ID + "'");
        //        else
        //            return ExecuteQuery("EXEC USP_SMHR_HR_MASTER @Operation = 'Check', @HR_MASTER_CODE ='" + Convert.ToString(_obj_Smhr_Masters.MASTER_CODE) + "'" +
        //                                ",@HR_MASTER_TYPE='" + Convert.ToString(_obj_Smhr_Masters.MASTER_TYPE) + "'" +
        //                                ",@HR_MASTER_ID ='" + Convert.ToString(_obj_Smhr_Masters.MASTER_ID) + "'" +
        //                                ",@HR_MASTER_ORGANISATION_ID = '" + _obj_Smhr_Masters.ORGANISATION_ID + "'");
        //    }
        //}

        ///// <summary>
        ///// Method to Insert or update into the Master_HR table Using Information Passed using the Object. 
        ///// </summary>
        ///// <param name="_obj_Smhr_Category"></param>
        ///// <returns>Boolean stating the Success or failure</returns>
        ///// <remarks>
        /////  Author             : MKD 
        /////  Created on         : 2009-08-17
        /////  Last Modified on   : N/A
        /////  Last Modfied by    : N/A
        ///// </remarks>
        //public static bool set_Master(SMHR_MASTERS _obj_Smhr_Masters)
        //{

        //    switch (_obj_Smhr_Masters.OPERATION)
        //    {
        //        case operation.Insert:
        //            ExecuteNonQuery("EXEC USP_SMHR_HR_MASTER @Operation = 'Insert',@HR_MASTER_TYPE ='" + Convert.ToString(_obj_Smhr_Masters.MASTER_TYPE) + "'" +
        //                            ",@HR_MASTER_ORGANISATION_ID = '" + _obj_Smhr_Masters.ORGANISATION_ID + "'" +
        //                            ",@HR_MASTER_CODE = '" + Convert.ToString(_obj_Smhr_Masters.MASTER_CODE) + "'" +
        //                            ",@HR_MASTER_DESC = '" + Convert.ToString(_obj_Smhr_Masters.MASTER_DESC) + "'" +
        //                            ",@HR_MASTER_ISDELETED = 0,@HR_MASTER_CREATEDBY = '" + _obj_Smhr_Masters.CREATEDBY + "'" +
        //                            ",@HR_MASTER_CREATEDDATE = '" + _obj_Smhr_Masters.CREATEDDATE + "'" +
        //                            ",@HR_MASTER_LASTMDFBY = '" + _obj_Smhr_Masters.LASTMDFBY + "'" +
        //                            ",@HR_MASTER_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Smhr_Masters.LASTMDFDATE).ToString("MM/dd/yyyy") + "'");
        //            break;
        //        case operation.Update:
        //            ExecuteNonQuery("EXEC USP_SMHR_HR_MASTER @Operation = 'Update',@HR_MASTER_ID = '" + Convert.ToString(_obj_Smhr_Masters.MASTER_ID) + "'" +
        //                            ",@HR_MASTER_TYPE ='" + Convert.ToString(_obj_Smhr_Masters.MASTER_TYPE) + "'" +
        //                            ",@HR_MASTER_ORGANISATION_ID = '" + _obj_Smhr_Masters.ORGANISATION_ID + "'" +
        //                            ",@HR_MASTER_CODE = '" + Convert.ToString(_obj_Smhr_Masters.MASTER_CODE) + "'" +
        //                            ",@HR_MASTER_DESC = '" + Convert.ToString(_obj_Smhr_Masters.MASTER_DESC) + "'" +
        //                            ",@HR_MASTER_ISDELETED = 0,  @HR_MASTER_LASTMDFBY = '" + _obj_Smhr_Masters.LASTMDFBY + "'" +
        //                            ",@HR_MASTER_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Smhr_Masters.LASTMDFDATE).ToString("MM/dd/yyyy") + "'");
        //            break;
        //        default:
        //            break;
        //    }
        //    return true;
        //}

        //#endregion

        //#region SMHR_LOGININFO

        ///// <summary>
        /////  Method to Get SMHR_LOGININFO Based on the LOGIN_ID
        ///// </summary>
        ///// <param name="LOGIN_ID"></param>
        ///// <returns>Datatable with Countries Information</returns>
        ///// <remarks>
        /////  Author             : BK 
        /////  Created on         : 2009-08-31
        /////  Last Modified on   : N/A
        /////  Last Modfied by    : N/A
        ///// </remarks>
        //public static DataTable get_LoginInfo(SMHR_LOGININFO _obj_Smhr_LoginInfo)
        //{
        //    if (_obj_Smhr_LoginInfo.OPERATION == operation.Select)
        //    {
        //        if (_obj_Smhr_LoginInfo.LOGIN_ID.ToString() == "0")
        //            return ExecuteQuery("EXEC USP_SMHR_LOGININFO @Operation = 'select', @LOGIN_ORGANISATION_ID = '" + _obj_Smhr_LoginInfo.ORGANISATION_ID + "'");
        //        else
        //            return ExecuteQuery("EXEC USP_SMHR_LOGININFO @Operation = 'select', @LOGIN_ID =" + Convert.ToString(_obj_Smhr_LoginInfo.LOGIN_ID));
        //    }
        //    else if (_obj_Smhr_LoginInfo.OPERATION == operation.Empty1)
        //    {

        //        return ExecuteQuery("EXEC USP_SMHR_LOGININFO @Operation = 'getforms', " +
        //                        " @LOGIN_USERNAME ='" + Convert.ToString(_obj_Smhr_LoginInfo.LOGIN_USERNAME) + "'" +
        //                        ", @LOGIN_ORGANISATION_ID = '" + _obj_Smhr_LoginInfo.ORGANISATION_ID + "',@LOGIN_PASS_CODE = '" + _obj_Smhr_LoginInfo.LOGIN_PASS_CODE + "'" +
        //                        " ");

        //    }

        //    else
        //    {
        //        if (_obj_Smhr_LoginInfo.LOGIN_ID.ToString() == "0")
        //            return ExecuteQuery("EXEC USP_SMHR_LOGININFO @Operation = 'Check', " +
        //                        " @LOGIN_USERNAME ='" + Convert.ToString(_obj_Smhr_LoginInfo.LOGIN_USERNAME) + "'" +
        //                        ", @LOGIN_ORGANISATION_ID = '" + _obj_Smhr_LoginInfo.ORGANISATION_ID + "'");
        //        else
        //            return ExecuteQuery("EXEC USP_SMHR_LOGININFO @Operation = 'Check', " +
        //                            "@LOGIN_USERNAME ='" + Convert.ToString(_obj_Smhr_LoginInfo.LOGIN_USERNAME) + "', " +
        //                            " @LOGIN_ID=" + Convert.ToString(_obj_Smhr_LoginInfo.LOGIN_ID) + "" +
        //                            ", @LOGIN_ORGANISATION_ID = '" + _obj_Smhr_LoginInfo.ORGANISATION_ID + "'" +
        //                            ",@LOGIN_TYPE='" + _obj_Smhr_LoginInfo.LOGIN_TYPE + "'");
        //    }
        //}

        //public static DataTable get_Login(SMHR_LOGININFO _obj_Smhr_LoginInfo)
        //{
        //    return ExecuteQuery("EXEC USP_SMHR_LOGININFO @Operation = 'Select', @LOGIN_USERNAME ='" + Convert.ToString(_obj_Smhr_LoginInfo.LOGIN_USERNAME) + "'" +
        //                        ", @LOGIN_ORGANISATION_ID = '" + _obj_Smhr_LoginInfo.ORGANISATION_ID + "'");
        //}

        //public static DataTable get_Login_Validate(SMHR_LOGININFO _obj_Smhr_LoginInfo)
        //{
        //    return ExecuteQuery("EXEC USP_SMHR_LOGININFO @Operation = 'Check1', " +
        //                        " @LOGIN_USERNAME ='" + Convert.ToString(_obj_Smhr_LoginInfo.LOGIN_USERNAME) + "'" +
        //                        ",@LOGIN_PASS_CODE = '" + _obj_Smhr_LoginInfo.LOGIN_PASS_CODE + "'" +
        //                        ",@LOGIN_ORGANISATION_ID = '" + _obj_Smhr_LoginInfo.ORGANISATION_ID + "'");
        //}
        //public static DataTable get_Loginval(SMHR_LOGININFO _obj_Smhr_LoginInfo)
        //{
        //    return ExecuteQuery("EXEC USP_SMHR_LOGININFO @Operation = 'Login',@LOGIN_ID = '" + _obj_Smhr_LoginInfo.LOGIN_ID + "'");
        //}
        //public static DataTable get_Logindetails(SMHR_LOGININFO _obj_Smhr_LoginInfo)
        //{
        //    return ExecuteQuery("EXEC USP_SMHR_LOGININFO @Operation = 'Login1',@LOGIN_ORGANISATION_ID = '" + _obj_Smhr_LoginInfo.LOGIN_ORGANISATION_ID + "'");
        //}
        //public static DataTable get_Loginusergroups(SMHR_LOGININFO _obj_Smhr_LoginInfo)
        //{
        //    return ExecuteQuery("EXEC USP_SMHR_LOGININFO @Operation = 'Login2',@LOGIN_ORGANISATION_ID = '" + _obj_Smhr_LoginInfo.LOGIN_ORGANISATION_ID + "'");
        //}
        //public static DataTable get_usergroups(SMHR_LOGININFO _obj_Smhr_LoginInfo)
        //{
        //    return ExecuteQuery("EXEC USP_SMHR_LOGININFO @Operation = 'Login3'");
        //}
        //public static DataTable get_priviliges(SMHR_LOGININFO _obj_Smhr_LoginInfo)
        //{
        //    return ExecuteQuery("EXEC USP_SMHR_LOGININFO @Operation = 'Login4'");
        //}
        //public static DataTable get_LoginInfo1(SMHR_LOGININFO _obj_Smhr_LoginInfo)
        //{
        //    return ExecuteQuery("EXEC USP_SMHR_LOGININFO @Operation = 'Select1'");
        //}
        //public static DataTable get_adminlogins(SMHR_LOGININFO _obj_Smhr_LoginInfo)
        //{
        //    return ExecuteQuery("EXEC USP_SMHR_LOGININFO @Operation = 'Select_admins',@LOGIN_ORGANISATION_ID = '" + _obj_Smhr_LoginInfo.ORGANISATION_ID + "'");
        //}
        //public static DataTable get_userpriviliges(SMHR_LOGININFO _obj_Smhr_LoginInfo)
        //{
        //    return ExecuteQuery("EXEC USP_SMHR_LOGININFO @Operation = 'Login5',@LOGIN_ORGANISATION_ID = '" + _obj_Smhr_LoginInfo.LOGIN_ORGANISATION_ID + "'");
        //}
        //public static DataTable get_emp(SMHR_LOGININFO _obj_Smhr_LoginInfo)
        //{
        //    return ExecuteQuery("EXEC USP_SMHR_LOGININFO @Operation = 'CheckEmp',@LOGIN_EMP_ID = '" + _obj_Smhr_LoginInfo.LOGIN_EMP_ID + "',@LOGIN_ORGANISATION_ID='" + _obj_Smhr_LoginInfo.ORGANISATION_ID + "'");
        //}
        //public static DataTable get_BU_Admins(SMHR_LOGININFO _obj_Smhr_LoginInfo)
        //{
        //    return ExecuteQuery("EXEC USP_SMHR_LOGININFO @Operation = 'Get_BU'");
        //}

        //public static bool Upadate_Admins(SMHR_LOGININFO _obj_Smhr_LoginInfo)
        //{
        //    try
        //    {
        //        bool status = false;
        //        switch (_obj_Smhr_LoginInfo.OPERATION)
        //        {

        //            case operation.Update_Bu:

        //                if (Dal.ExecuteNonQuery("exec USP_SMHR_LOGININFO @OPERATION='Update_Bu',@LOGIN_BUSINESSUNITID='" + _obj_Smhr_LoginInfo.LOGIN_BUSINESSUNITID + "',@LOGIN_ID='" + _obj_Smhr_LoginInfo.LOGIN_ID + "'"))
        //                {
        //                    status = true;
        //                }
        //                break;
        //            default:
        //                break;
        //        }
        //        return status;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        ///// <summary>
        ///// Method to Insert or update into the SMHR_LOGININFO table Using Information Passed using the Object. 
        ///// </summary>
        ///// <param name="_obj_Smhr_LoginInfo"></param>
        ///// <returns>Boolean stating the Success or failure</returns>
        ///// <remarks>
        /////  Author             : BK 
        /////  Created on         : 2009-08-31
        /////  Last Modified on   : N/A
        /////  Last Modfied by    : N/A
        ///// </remarks> 
        //public static bool set_LoginInfo(SMHR_LOGININFO _obj_Smhr_LoginInfo)
        //{
        //    bool status = false;
        //    switch (_obj_Smhr_LoginInfo.OPERATION)
        //    {
        //        case operation.Insert:
        //            if (ExecuteNonQuery("EXEC USP_SMHR_LOGININFO @Operation = 'Insert',  @LOGIN_USERNAME='" + _obj_Smhr_LoginInfo.LOGIN_USERNAME
        //                              + "', @LOGIN_PASSWORD='" + _obj_Smhr_LoginInfo.LOGIN_PASSWORD
        //                              + "', @LOGIN_EMP_ID =" + Convert.ToString(_obj_Smhr_LoginInfo.LOGIN_EMP_ID)
        //                              + " , @LOGIN_EMAILID='" + Convert.ToString(_obj_Smhr_LoginInfo.LOGIN_EMAILID)
        //                              + "', @LOGIN_TYPE =" + Convert.ToString(_obj_Smhr_LoginInfo.LOGIN_TYPE)
        //                              + " , @LOGIN_STATUS='" + Convert.ToString(_obj_Smhr_LoginInfo.LOGIN_STATUS)
        //                              + "', @LOGIN_BUSINESSUNITID='" + Convert.ToString(_obj_Smhr_LoginInfo.LOGIN_BUSINESSUNITID)
        //                              + "', @LOGIN_CREATEDBY= " + Convert.ToString(_obj_Smhr_LoginInfo.CREATEDBY)
        //                              + ",  @LOGIN_ORGANISATION_ID = '" + _obj_Smhr_LoginInfo.ORGANISATION_ID + "'"
        //                              + ",  @LOGIN_PASS_CODE = '" + _obj_Smhr_LoginInfo.LOGIN_PASS_CODE + "'"
        //                              + " , @LOGIN_CREATEDDATE='" + _obj_Smhr_LoginInfo.CREATEDDATE.ToString("MM/dd/yyyy")
        //                              + "', @LOGIN_LASTMDFBY =" + Convert.ToString(_obj_Smhr_LoginInfo.LASTMDFBY)
        //                              + " , @LOGIN_LASTMDFDATE ='" + _obj_Smhr_LoginInfo.LASTMDFDATE.ToString("MM/dd/yyyy") + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        case operation.Update:
        //            if (ExecuteNonQuery("EXEC USP_SMHR_LOGININFO @Operation = 'Update', @LOGIN_ID=" + _obj_Smhr_LoginInfo.@LOGIN_ID
        //                              + " , @LOGIN_USERNAME='" + _obj_Smhr_LoginInfo.LOGIN_USERNAME
        //                              + "', @LOGIN_PASSWORD='" + _obj_Smhr_LoginInfo.LOGIN_PASSWORD
        //                              + "', @LOGIN_EMP_ID =" + Convert.ToString(_obj_Smhr_LoginInfo.LOGIN_EMP_ID)
        //                              + " , @LOGIN_EMAILID='" + Convert.ToString(_obj_Smhr_LoginInfo.LOGIN_EMAILID)
        //                              + "', @LOGIN_TYPE =" + Convert.ToString(_obj_Smhr_LoginInfo.LOGIN_TYPE)
        //                              + " , @LOGIN_STATUS='" + Convert.ToString(_obj_Smhr_LoginInfo.LOGIN_STATUS)
        //                              + "', @LOGIN_BUSINESSUNITID='" + Convert.ToString(_obj_Smhr_LoginInfo.LOGIN_BUSINESSUNITID)
        //                              + "', @LOGIN_ORGANISATION_ID = '" + _obj_Smhr_LoginInfo.ORGANISATION_ID + "'"
        //                              + ",  @LOGIN_PASS_CODE = '" + _obj_Smhr_LoginInfo.LOGIN_PASS_CODE + "'"
        //                              + ",  @LOGIN_LASTMDFBY =" + Convert.ToString(_obj_Smhr_LoginInfo.LASTMDFBY)
        //                              + " , @LOGIN_LASTMDFDATE ='" + _obj_Smhr_LoginInfo.LASTMDFDATE.ToString("MM/dd/yyyy") + "'"))
        //                status = true;
        //            else
        //                status = false;

        //            break;
        //        case operation.Delete:
        //            if (ExecuteNonQuery("EXEC USP_SMHR_LOGININFO @Operation = 'Delete', @LOGIN_ID=" + Convert.ToString(_obj_Smhr_LoginInfo.LOGIN_ID)
        //                              + " , @LOGIN_LASTMDFBY =" + Convert.ToString(_obj_Smhr_LoginInfo.LASTMDFBY)
        //                              + " , @LOGIN_LASTMDFDATE ='" + _obj_Smhr_LoginInfo.LASTMDFDATE.ToString("MM/dd/yyyy") + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        default:
        //            break;
        //    }
        //    return status;
        //}
        //#endregion

        //#region SMHR_GLOBALCONFIG

        ///// <summary>
        ///// Gets the Details of Global Configuration Details. 
        ///// </summary>
        ///// <param name="_obj_Smhr_Category"></param>
        ///// <returns>Data Table</returns>
        ///// <remarks>
        /////  Author             : Gunti Dheeraj 
        /////  Created on         : 2009-08-17
        /////  Last Modified on   : N/A
        /////  Last Modfied by    : N/A
        ///// </remarks>

        //public static DataTable get_ConfigDetails(SMHR_GLOBALCONFIG _obj_smhr_globalConfig)
        //{
        //    if (_obj_smhr_globalConfig.OPERATION == operation.Select)
        //    {
        //        if (_obj_smhr_globalConfig.GLOBALCONFIG_ID.ToString() == "0")
        //            return ExecuteQuery("EXEC USP_SMHR_GLOBALCONFIG @Operation = 'select',@GLOBALCONFIG_ORGANISATION_ID = '" + _obj_smhr_globalConfig.ORGANISATION_ID + "'");
        //        else
        //            return ExecuteQuery("EXEC USP_SMHR_GLOBALCONFIG @operation='select',@GLOBALCONFIG_ID='" + _obj_smhr_globalConfig.GLOBALCONFIG_ID + "',@GLOBALCONFIG_ORGANISATION_ID = '" + _obj_smhr_globalConfig.ORGANISATION_ID + "'");
        //    }
        //    else if (_obj_smhr_globalConfig.OPERATION == operation.Check)
        //    {
        //        return ExecuteQuery("EXEC USP_SMHR_GLOBALCONFIG @Operation = 'check',@GLOBALCONFIG_ORGANISATION_ID = '" + _obj_smhr_globalConfig.ORGANISATION_ID + "'");
        //    }
        //    else
        //    {
        //        return ExecuteQuery("EXEC USP_SMHR_GLOBALCONFIG @Operation = 'validate',@GLOBALCONFIG_ORGANISATION_ID = '" + _obj_smhr_globalConfig.ORGANISATION_ID + "'");
        //    }
        //}

        ///// <summary>
        ///// Inserts the Details of Global Configuration Details. 
        ///// </summary>
        ///// <param name="_obj_Smhr_GlobalConfig"></param>
        ///// <returns>Boolean stating the Success or failure</returns>
        ///// <remarks>
        /////  Author             : Gunti Dheeraj 
        /////  Created on         : 2009-08-17
        /////  Last Modified on   : N/A
        /////  Last Modfied by    : N/A
        ///// </remarks>

        //public static bool set_GlobalConfig(SMHR_GLOBALCONFIG _obj_Smhr_Global)
        //{
        //    bool status = false;
        //    switch (_obj_Smhr_Global.OPERATION)
        //    {
        //        case operation.Insert:
        //            if (ExecuteNonQuery("EXEC USP_SMHR_GLOBALCONFIG @Operation = 'Insert'," +
        //                            "  @GLOBALCONFIG_NEXT_ID ='" + Convert.ToInt32(_obj_Smhr_Global.GLOBALCONFIG_NEXT_ID) + "'" +
        //                            ", @GLOBALCONFIG_APP_ID = '" + Convert.ToInt32(_obj_Smhr_Global.GLOBALCONFIG_APP_ID) + "'" +
        //                            ", @GLOBALCONFIG_EMP_ID = '" + Convert.ToInt32(_obj_Smhr_Global.GLOBALCONFIG_EMP_ID) + "'" +
        //                            ", @GLOBALCONFIG_NextEMP_ID = '" + Convert.ToInt32(_obj_Smhr_Global.GLOBALCONFIG_NextEMP_ID) + "'" +
        //                            ", @GLOBALCONFIG_LOAN_ID = '" + Convert.ToInt32(_obj_Smhr_Global.GLOBALCONFIG_LOAN_ID) + "'" +
        //                            ", @GLOBALCONFIG_LOAN_NO = '" + Convert.ToString(_obj_Smhr_Global.GLOBALCONFIG_LOAN_NO) + "'" +
        //                            ", @GLOBALCONFIG_EMP_CODE = '" + Convert.ToString(_obj_Smhr_Global.GLOBALCONFIG_EMP_CODE) + "'" +
        //                            ", @GLOBALCONFIG_APP_CODE = '" + Convert.ToString(_obj_Smhr_Global.GLOBALCONFIG_APP_CODE) + "'" +
        //                            ", @GLOBALCONFIG_DOMAIN_IP = '" + Convert.ToString(_obj_Smhr_Global.GLOBALCONFIG_DOMAIN_IP) + "'" +
        //                            ", @GLOBALCONFIG_USERNAME = '" + Convert.ToString(_obj_Smhr_Global.GLOBALCONFIG_USERNAME) + "'" +
        //                            ", @GLOBALCONFIG_PWD = '" + Convert.ToString(_obj_Smhr_Global.GLOBALCONFIG_PWD) + "'" +
        //                            ", @GLOBALCONFIG_MAILID = '" + Convert.ToString(_obj_Smhr_Global.GLOBALCONFIG_MAILID) + "'" +
        //                            ", @GLOBALCONFIG_TRAVEL_REQUEST_CODE = '" + Convert.ToString(_obj_Smhr_Global.GLOBALCONFIG_TRAVEL_REQUEST_CODE) + "'" +
        //                            ", @GLOBALCONFIG_TRAVEL_REQUEST_ID = '" + Convert.ToInt32(_obj_Smhr_Global.GLOBALCONFIG_TRAVEL_REQUEST_ID) + "'" +
        //                            ", @GLOBALCONFIG_SALSTRUCT_CODE = '" + Convert.ToInt32(_obj_Smhr_Global.GLOBALCONFIG_SALSTRUCT_CODE) + "'" +
        //                            ", @GLOBALCONFIG_PERIOD_CODE = '" + Convert.ToInt32(_obj_Smhr_Global.GLOBALCONFIG_PERIOD_CODE) + "'" +
        //                            ", @GLOBALCONFIG_JOB_REQ_CODE = '" + Convert.ToInt32(_obj_Smhr_Global.GLOBALCONFIG_JOB_REQ_CODE) + "'" +
        //                            ", @GLOBALCONFIG_THEME = '" + Convert.ToString(_obj_Smhr_Global.GLOABLCONFIG_THEME) + "'" +
        //                            ", @GLOBALCONFIG_DATEFORMAT='" + _obj_Smhr_Global.GLOBALCONFIG_DATEFORMAT + "'" +
        //                            ", @GLOBALCONFIG_MAXAGE='" + _obj_Smhr_Global.GLOBALCONFIG_MAXAGE + "'" +
        //                            ", @GLOBALCONFIG_MINAGE='" + _obj_Smhr_Global.GLOBALCONFIG_MINAGE + "'" +
        //                            ", @GLOBALCONFIG_APPLIEDDATES='" + Convert.ToString(_obj_Smhr_Global.GLOBALCONFIG_APPLIEDDATES) + "'" +
        //                            ", @GLOBALCONFIG_COMPANYLOGO='" + Convert.ToString(_obj_Smhr_Global.GLOBALCONFIG_COMPANYLOGO) + "'" +
        //                            ", @GLOBALCONFIG_CONTRACTNO = '" + Convert.ToInt32(_obj_Smhr_Global.GLOBALCONFIG_CONTRACTNO) + "'" +
        //                            ", @GLOBALCONFIG_TRAINEENO = '" + Convert.ToInt32(_obj_Smhr_Global.GLOBALCONFIG_TRAINEENO) + "'" +
        //                            ", @GLOBALCONFIG_ORGANISATION_ID = '" + Convert.ToInt32(_obj_Smhr_Global.ORGANISATION_ID) + "'" +
        //                            ", @GLOBALCONFIG_COMPANYLOGO_WIDTH = '" + Convert.ToInt32(_obj_Smhr_Global.GLOBALCONFIG_COMPANYLOGO_WIDTH) + "'" +
        //                            ", @GLOBALCONFIG_COMPANYLOGO_HEIGHT = '" + Convert.ToInt32(_obj_Smhr_Global.GLOBALCONFIG_COMPANYLOGO_HEIGHT) + "'" +
        //                            ", @GLOBALCONFIG_LEAVETRANFLAG =" + Convert.ToInt32(_obj_Smhr_Global.GLOBALCONFIG_LEAVETRANFLAG + "")))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        case operation.Update:
        //            if (ExecuteNonQuery("EXEC USP_SMHR_GLOBALCONFIG @Operation = 'Update'," +
        //                            "  @GLOBALCONFIG_NEXT_ID ='" + Convert.ToInt32(_obj_Smhr_Global.GLOBALCONFIG_NEXT_ID) + "'" +
        //                            ", @GLOBALCONFIG_APP_ID = '" + Convert.ToInt32(_obj_Smhr_Global.GLOBALCONFIG_APP_ID) + "'" +
        //                            ", @GLOBALCONFIG_EMP_ID = '" + Convert.ToInt32(_obj_Smhr_Global.GLOBALCONFIG_EMP_ID) + "'" +
        //                            ", @GLOBALCONFIG_NextEMP_ID = '" + Convert.ToInt32(_obj_Smhr_Global.GLOBALCONFIG_NextEMP_ID) + "'" +
        //                            ", @GLOBALCONFIG_LOAN_ID = '" + Convert.ToInt32(_obj_Smhr_Global.GLOBALCONFIG_LOAN_ID) + "'" +
        //                            ", @GLOBALCONFIG_LOAN_NO = '" + Convert.ToString(_obj_Smhr_Global.GLOBALCONFIG_LOAN_NO) + "'" +
        //                            ", @GLOBALCONFIG_EMP_CODE = '" + Convert.ToString(_obj_Smhr_Global.GLOBALCONFIG_EMP_CODE) + "'" +
        //                            ", @GLOBALCONFIG_APP_CODE = '" + Convert.ToString(_obj_Smhr_Global.GLOBALCONFIG_APP_CODE) + "'" +
        //                            ", @GLOBALCONFIG_DOMAIN_IP = '" + Convert.ToString(_obj_Smhr_Global.GLOBALCONFIG_DOMAIN_IP) + "'" +
        //                            ", @GLOBALCONFIG_USERNAME = '" + Convert.ToString(_obj_Smhr_Global.GLOBALCONFIG_USERNAME) + "'" +
        //                            ", @GLOBALCONFIG_PWD = '" + Convert.ToString(_obj_Smhr_Global.GLOBALCONFIG_PWD) + "'" +
        //                            ", @GLOBALCONFIG_MAILID = '" + Convert.ToString(_obj_Smhr_Global.GLOBALCONFIG_MAILID) + "'" +
        //                            ", @GLOBALCONFIG_TRAVEL_REQUEST_CODE = '" + Convert.ToString(_obj_Smhr_Global.GLOBALCONFIG_TRAVEL_REQUEST_CODE) + "'" +
        //                            ", @GLOBALCONFIG_TRAVEL_REQUEST_ID = '" + Convert.ToInt32(_obj_Smhr_Global.GLOBALCONFIG_TRAVEL_REQUEST_ID) + "'" +
        //                            ", @GLOBALCONFIG_SALSTRUCT_CODE = '" + Convert.ToInt32(_obj_Smhr_Global.GLOBALCONFIG_SALSTRUCT_CODE) + "'" +
        //                            ", @GLOBALCONFIG_PERIOD_CODE = '" + Convert.ToInt32(_obj_Smhr_Global.GLOBALCONFIG_PERIOD_CODE) + "'" +
        //                            ", @GLOBALCONFIG_JOB_REQ_CODE = '" + Convert.ToInt32(_obj_Smhr_Global.GLOBALCONFIG_JOB_REQ_CODE) + "'" +
        //                            ", @GLOBALCONFIG_THEME = '" + Convert.ToString(_obj_Smhr_Global.GLOABLCONFIG_THEME) + "'" +
        //                            ", @GLOBALCONFIG_DATEFORMAT='" + _obj_Smhr_Global.GLOBALCONFIG_DATEFORMAT + "'" +
        //                            ", @GLOBALCONFIG_MAXAGE='" + _obj_Smhr_Global.GLOBALCONFIG_MAXAGE + "'" +
        //                            ", @GLOBALCONFIG_MINAGE='" + _obj_Smhr_Global.GLOBALCONFIG_MINAGE + "'" +
        //                            ", @GLOBALCONFIG_APPLIEDDATES='" + Convert.ToString(_obj_Smhr_Global.GLOBALCONFIG_APPLIEDDATES) + "'" +
        //                            ", @GLOBALCONFIG_COMPANYLOGO='" + Convert.ToString(_obj_Smhr_Global.GLOBALCONFIG_COMPANYLOGO) + "'" +
        //                            ", @GLOBALCONFIG_CONTRACTNO = '" + Convert.ToInt32(_obj_Smhr_Global.GLOBALCONFIG_CONTRACTNO) + "'" +
        //                            ", @GLOBALCONFIG_TRAINEENO = '" + Convert.ToInt32(_obj_Smhr_Global.GLOBALCONFIG_TRAINEENO) + "'" +
        //                            ", @GLOBALCONFIG_ORGANISATION_ID = '" + Convert.ToInt32(_obj_Smhr_Global.ORGANISATION_ID) + "'" +
        //                            ", @GLOBALCONFIG_COMPANYLOGO_WIDTH = '" + Convert.ToInt32(_obj_Smhr_Global.GLOBALCONFIG_COMPANYLOGO_WIDTH) + "'" +
        //                            ", @GLOBALCONFIG_COMPANYLOGO_HEIGHT = '" + Convert.ToInt32(_obj_Smhr_Global.GLOBALCONFIG_COMPANYLOGO_HEIGHT) + "'" +
        //                            ", @GLOBALCONFIG_LEAVETRANFLAG =" + Convert.ToInt32(_obj_Smhr_Global.GLOBALCONFIG_LEAVETRANFLAG + "")))

        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        default:
        //            break;
        //    }
        //    return status;
        //}

        //#endregion

        //#region SMHR_EMPLOYEE

        //public static DataTable get_Employee(SMHR_EMPLOYEE _obj_smhr_employee)
        //{
        //    if (_obj_smhr_employee.OPERATION == operation.Select)
        //    {
        //        if (_obj_smhr_employee.EMP_ID.ToString() == "0")
        //        {
        //            return ExecuteQuery("EXEC USP_SMHR_EMPLOYEE_New @Operation = 'select', @ORGANISATION_ID = '" + _obj_smhr_employee.ORGANISATION_ID + "',@EMP_LOGIN_ID='" + _obj_smhr_employee.EMP_LOGIN_ID + "'");
        //        }
        //        else
        //        {
        //            return ExecuteQuery("EXEC USP_SMHR_EMPLOYEE_New @Operation = 'select', @EMP_ID = '" + _obj_smhr_employee.EMP_ID + "', @ORGANISATION_ID = '" + _obj_smhr_employee.ORGANISATION_ID + "'");
        //        }
        //    }
        //    else if (_obj_smhr_employee.OPERATION == operation.Check)
        //    {
        //        if (_obj_smhr_employee.EMP_EMPCODE.ToString() == "0")
        //        {
        //            return ExecuteQuery("EXEC USP_SMHR_EMPLOYEE @Operation = 'check',@EMP_ORGANISATION_ID='" + _obj_smhr_employee.ORGANISATION_ID + "'");
        //        }
        //        else
        //        {
        //            return ExecuteQuery("EXEC USP_SMHR_EMPLOYEE @Operation = 'check', @EMP_EMPCODE = '" + _obj_smhr_employee.EMP_EMPCODE + "',@EMP_ORGANISATION_ID='" + _obj_smhr_employee.ORGANISATION_ID + "'");
        //        }

        //    }
        //    else if (_obj_smhr_employee.OPERATION == operation.Empty)
        //    {
        //        if (_obj_smhr_employee.OPERATION.ToString() == "FILLEMP")
        //        {
        //            if ((_obj_smhr_employee.OPERATION.ToString() == "FILLEMP") && (_obj_smhr_employee.EMP_BUSINESSUNIT_ID.ToString() == "0"))
        //            {
        //                return ExecuteQuery(" EXEC USP_SMHR_EMPLOYEE @Operation = 'FILLEMP',@EMP_ORGANISATION_ID='" + _obj_smhr_employee.ORGANISATION_ID + "'");
        //            }
        //            else
        //            {
        //                return ExecuteQuery(" EXEC USP_SMHR_EMPLOYEE @Operation = 'FILLEMP' and @EMP_BUSINESSUNIT_ID =" + _obj_smhr_employee.EMP_BUSINESSUNIT_ID + ",@EMP_ORGANISATION_ID='" + _obj_smhr_employee.ORGANISATION_ID + "'");
        //            }
        //        }
        //        else if (_obj_smhr_employee.OPERATION.ToString() == "FILLRESGEMP")
        //        {
        //            return ExecuteQuery(" EXEC USP_SMHR_EMPLOYEE @Operation = 'FILLRESGEMP',@EMP_ORGANISATION_ID='" + _obj_smhr_employee.ORGANISATION_ID + "'");
        //        }
        //        else
        //        {
        //            return ExecuteQuery(" EXEC USP_SMHR_EMPLOYEE @Operation = 'FILLRELEMP',@EMP_ORGANISATION_ID='" + _obj_smhr_employee.ORGANISATION_ID + "'");
        //        }
        //    }
        //    else if (_obj_smhr_employee.OPERATION == operation.Update)
        //    {
        //        return ExecuteQuery(" EXEC USP_SMHR_EMPLOYEE @Operation = 'Update', @EMP_STATUS_UPDATE = '" + _obj_smhr_employee.APP_EMP_STATUS + "'" +
        //                            ", @ORGANISATION_ID = '" + _obj_smhr_employee.ORGANISATION_ID + "'");
        //    }
        //    else if (_obj_smhr_employee.OPERATION == operation.SELECTEMPLOYEE)
        //    {
        //        return ExecuteQuery(" EXEC USP_SMHR_EMPLOYEE @Operation = 'SELECTEMPLOYEE',@EMP_BUSINESSUNIT_ID ='" + _obj_smhr_employee.EMP_BUSINESSUNIT_ID + "'");
        //    }

        //    else if (_obj_smhr_employee.OPERATION == operation.UpdateSTATUS)
        //    {
        //        return ExecuteQuery(" EXEC USP_SMHR_EMPLOYEE @Operation = 'SELECTSTATUS', @EMP_ID = '" + _obj_smhr_employee.EMP_ID + "'" +
        //                            " ");
        //    }
        //    else if (_obj_smhr_employee.OPERATION == operation.Validate)
        //    {
        //        return ExecuteQuery("EXEC USP_SMHR_EMPLOYEE @OPERATION='VALIDATE',@ORGANISATION_ID='" + _obj_smhr_employee.ORGANISATION_ID + "'");
        //    }
        //    else if (_obj_smhr_employee.OPERATION == operation.load)
        //    {
        //        return ExecuteQuery(" EXEC USP_SMHR_EMPLOYEE @Operation = 'load',@EMP_ID = " + _obj_smhr_employee.EMP_ID + "");
        //    }
        //    else
        //    {
        //        return ExecuteQuery("EXEC USP_SMHR_EMPLOYEE @Operation = 'Delete', @EMP_BUSINESSUNIT_ID = '" + _obj_smhr_employee.EMP_BUSINESSUNIT_ID + "'");
        //    }
        //}

        //public static DataTable get_Supervisor(SMHR_EMPLOYEE _obj_smhr_employee)
        //{
        //    if (_obj_smhr_employee.OPERATION == operation.Check)
        //    {
        //        return ExecuteQuery("EXEC USP_SMHR_EMPLOYEE_New @operation='check'," +
        //                " @EMP_ID = '" + _obj_smhr_employee.EMP_ID + "'," +
        //                " @EMP_BUSINESSUNIT_ID = '" + _obj_smhr_employee.EMP_BUSINESSUNIT_ID + "'");
        //    }
        //    else
        //    {
        //        return ExecuteQuery("EXEC USP_SMHR_EMPLOYEE_New @operation='Empty'," +
        //             " @EMP_DESIGNATION_ID = '" + _obj_smhr_employee.EMP_DESIGNATION_ID + "'");
        //    }
        //}



        //public static DataTable get_DefaultSupervisor(SMHR_EMPLOYEE _obj_smhr_employee)
        //{
        //    if (_obj_smhr_employee.OPERATION == operation.Select1)
        //    {
        //        return ExecuteQuery("EXEC USP_SMHR_BUSINESSUNIT_NEW @operation='Select1',@EMP_ID='" + _obj_smhr_employee.EMP_ID + "'");
        //    }
        //    else if (_obj_smhr_employee.OPERATION == operation.Validate)
        //    {
        //        return ExecuteQuery("EXEC USP_SMHR_BUSINESSUNIT_NEW @operation='Validate',@EMP_ID='" + _obj_smhr_employee.EMP_ID + "'");
        //    }
        //    else if (_obj_smhr_employee.OPERATION == operation.Check1)
        //    {
        //        return ExecuteQuery("EXEC USP_SMHR_BUSINESSUNIT_NEW @operation='Check1',@EMP_BUSINESSUNIT_ID='" + _obj_smhr_employee.EMP_BUSINESSUNIT_ID + "'");
        //    }
        //    else
        //    {
        //        return ExecuteQuery("EXEC USP_SMHR_EMPLOYEE_New @operation='Empty'," +
        //                "@EMP_BUSINESSUNIT_ID = '" + _obj_smhr_employee.EMP_BUSINESSUNIT_ID + "'");
        //    }
        //}


        //public static bool set_Employee(SMHR_EMPLOYEE _obj_smhr_employee)
        //{
        //    bool status = false;
        //    switch (_obj_smhr_employee.OPERATION)
        //    {
        //        case operation.Insert:
        //            if (ExecuteNonQuery(" EXEC USP_SMHR_EMPLOYEE @Operation = '" + _obj_smhr_employee.OPERATION + "'" +
        //                    ",@EMP_EMPCODE = '" + _obj_smhr_employee.EMP_EMPCODE + "'" +
        //                    ",@EMP_ORGANISATION_ID = '" + _obj_smhr_employee.ORGANISATION_ID + "'" +
        //                    ",@EMP_APPLICANT_ID = '" + _obj_smhr_employee.EMP_APPLICANT_ID + "'" +
        //                    ",@EMP_DOJ = '" + _obj_smhr_employee.EMP_DOJ + "'" +
        //                    ",@EMP_DOC = " + (_obj_smhr_employee.EMP_DOC == null ? "null" : "'" + _obj_smhr_employee.EMP_DOC + "'") + "" +
        //                    ",@EMP_DESIGNATION_ID = '" + _obj_smhr_employee.EMP_DESIGNATION_ID + "'" +
        //                    ",@EMP_BUSINESSUNIT_ID = '" + _obj_smhr_employee.EMP_BUSINESSUNIT_ID + "'" +
        //                    ",@EMP_DATEOFLASTPROMOTION = " + (_obj_smhr_employee.EMP_DATEOFLASTPROMOTION == null ? "null" : "'" + _obj_smhr_employee.EMP_DATEOFLASTPROMOTION + "'") + "" +
        //                    ",@EMP_GRADE = '" + _obj_smhr_employee.EMP_GRADE + "'" +
        //                    ",@EMP_REPORTINGEMPLOYEE = '" + _obj_smhr_employee.EMP_REPORTINGEMPLOYEE + "'" +
        //                    ",@EMP_RPTSTARTDATE = " + (_obj_smhr_employee.EMP_RPTSTARTDATE == null ? "null" : "'" + _obj_smhr_employee.EMP_RPTSTARTDATE + "'") + "" +
        //                    ",@EMP_RPTENDDATE = " + (_obj_smhr_employee.EMP_RPTENDDATE == null ? "null" : "'" + _obj_smhr_employee.EMP_RPTENDDATE + "'") + "" +
        //                    ",@EMP_SHIFT_ID = '" + _obj_smhr_employee.EMP_SHIFT_ID + "'" +
        //                    ",@EMP_GROSSSAL = '" + _obj_smhr_employee.EMP_GROSSSAL + "'" +
        //                    ",@EMP_BASIC = '" + _obj_smhr_employee.EMP_BASIC + "'" +
        //                    ",@EMP_PAYMENTMODE_ID = '" + _obj_smhr_employee.EMP_PAYMENTMODE_ID + "'" +
        //                    ",@EMP_SALALRYSTRUCT_ID = '" + _obj_smhr_employee.EMP_SALALRYSTRUCT_ID + "'" +
        //                    ",@EMP_LEAVESTRUCT_ID = '" + _obj_smhr_employee.EMP_LEAVESTRUCT_ID + "'" +
        //                    ",@EMP_STATUS = '" + _obj_smhr_employee.EMP_STATUS + "'" +
        //                    ",@EMP_PROBATIONDATE = " + (_obj_smhr_employee.EMP_PROBATIONDATE == null ? "null" : "'" + _obj_smhr_employee.EMP_PROBATIONDATE + "'") + "" +
        //                    ",@EMP_NOTICEPERIOD = '" + _obj_smhr_employee.EMP_NOTICEPERIOD + "'" +
        //                    ",@EMP_PICTURE = '" + Convert.ToString(_obj_smhr_employee.EMP_PICUTRE) + "'" +
        //                    ",@EMP_EMPLOYEETYPE = '" + Convert.ToString(_obj_smhr_employee.EMP_EMPLOYEETYPE) + "'" +
        //                    ",@EMP_PAYCURRENCY = '" + Convert.ToInt32(_obj_smhr_employee.EMP_PAYCURRENCY) + "'" +
        //                    ",@EMP_DEPARTMENT_ID = '" + Convert.ToInt32(_obj_smhr_employee.EMP_DEPARTMENT_ID) + "'" +
        //                    ",@EMP_CONTRACT_DATE = " + (_obj_smhr_employee.EMP_CONTRACT_DATE == null ? "null" : "'" + _obj_smhr_employee.EMP_CONTRACT_DATE + "'") + "" +
        //                    ",@EMP_EMPLOYEE_STATUS = '" + Convert.ToInt32(_obj_smhr_employee.EMP_EMPLOYEE_STATUS) + "'" +
        //                    ",@EMP_CREATEDBY = '" + _obj_smhr_employee.EMP_CREATEDBY + "'" +
        //                    ",@EMP_CREATEDDATE = '" + Convert.ToDateTime(_obj_smhr_employee.EMP_CREATEDDATE).ToString("MM/dd/yyyy") + "'" +
        //                    ",@EMP_SUPBUSINESSUNIT_ID='" + Convert.ToInt32(_obj_smhr_employee.EMP_SUPBUSINESSUNIT_ID) + "'" +
        //                    ",@EMP_HOBBIES='" + _obj_smhr_employee.EMP_HOBBIES + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        case operation.Update:
        //            if (ExecuteNonQuery(" EXEC USP_SMHR_EMPLOYEE @Operation = '" + _obj_smhr_employee.OPERATION + "'" +
        //                    ",@EMP_EMPCODE = '" + _obj_smhr_employee.EMP_EMPCODE + "'" +
        //                    ",@EMP_ORGANISATION_ID = '" + _obj_smhr_employee.ORGANISATION_ID + "'" +
        //                    ",@EMP_APPLICANT_ID = '" + _obj_smhr_employee.EMP_APPLICANT_ID + "'" +
        //                    ",@EMP_DOJ = '" + Convert.ToDateTime(_obj_smhr_employee.EMP_DOJ).ToString("MM/dd/yyyy") + "'" +
        //                    ",@EMP_DOC = " + (_obj_smhr_employee.EMP_DOC == null ? "null" : "'" + _obj_smhr_employee.EMP_DOC + "'") + "" +
        //                    ",@EMP_DESIGNATION_ID = '" + _obj_smhr_employee.EMP_DESIGNATION_ID + "'" +
        //                    ",@EMP_BUSINESSUNIT_ID = '" + _obj_smhr_employee.EMP_BUSINESSUNIT_ID + "'" +
        //                    ",@EMP_DATEOFLASTPROMOTION = " + (_obj_smhr_employee.EMP_DATEOFLASTPROMOTION == null ? "null" : "'" + _obj_smhr_employee.EMP_DATEOFLASTPROMOTION + "'") +
        //                    ",@EMP_GRADE = '" + _obj_smhr_employee.EMP_GRADE + "'" +
        //                    ",@EMP_REPORTINGEMPLOYEE = '" + _obj_smhr_employee.EMP_REPORTINGEMPLOYEE + "'" +
        //                    ",@EMP_RPTSTARTDATE = " + (_obj_smhr_employee.EMP_RPTSTARTDATE == null ? "null" : "'" + _obj_smhr_employee.EMP_RPTSTARTDATE + "'") +
        //                    ",@EMP_RPTENDDATE = " + (_obj_smhr_employee.EMP_RPTENDDATE == null ? "null" : "'" + _obj_smhr_employee.EMP_RPTENDDATE + "'") +
        //                    ",@EMP_SHIFT_ID = '" + _obj_smhr_employee.EMP_SHIFT_ID + "'" +
        //                    ",@EMP_GROSSSAL = '" + _obj_smhr_employee.EMP_GROSSSAL + "'" +
        //                    ",@EMP_BASIC = '" + _obj_smhr_employee.EMP_BASIC + "'" +
        //                    ",@EMP_PAYMENTMODE_ID = '" + _obj_smhr_employee.EMP_PAYMENTMODE_ID + "'" +
        //                    ",@EMP_SALALRYSTRUCT_ID = '" + _obj_smhr_employee.EMP_SALALRYSTRUCT_ID + "'" +
        //                    ",@EMP_LEAVESTRUCT_ID = '" + _obj_smhr_employee.EMP_LEAVESTRUCT_ID + "'" +
        //                    ",@EMP_STATUS = '" + _obj_smhr_employee.EMP_STATUS + "'" +
        //                    ",@EMP_PROBATIONDATE = " + (_obj_smhr_employee.EMP_PROBATIONDATE == null ? "null" : "'" + _obj_smhr_employee.EMP_PROBATIONDATE + "'") +
        //                    ",@EMP_NOTICEPERIOD = '" + _obj_smhr_employee.EMP_NOTICEPERIOD + "'" +
        //                    ",@EMP_PICTURE = '" + Convert.ToString(_obj_smhr_employee.EMP_PICUTRE) + "'" +
        //                    ",@EMP_EMPLOYEETYPE = '" + Convert.ToString(_obj_smhr_employee.EMP_EMPLOYEETYPE) + "'" +
        //                    ",@EMP_LASTMDFBY = '" + _obj_smhr_employee.EMP_LASTMDFBY + "'" +
        //                    ",@EMP_CONTRACT_DATE = " + (_obj_smhr_employee.EMP_CONTRACT_DATE == null ? "null" : "'" + _obj_smhr_employee.EMP_CONTRACT_DATE + "'") + "" +
        //                    ",@EMP_EMPLOYEE_STATUS = '" + Convert.ToInt32(_obj_smhr_employee.EMP_EMPLOYEE_STATUS) + "'" +
        //                    ",@EMP_LASTMDFDATE = '" + Convert.ToDateTime(_obj_smhr_employee.EMP_LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
        //                    ",@EMP_PAYCURRENCY = '" + Convert.ToInt32(_obj_smhr_employee.EMP_PAYCURRENCY) + "'" +
        //                    ",@EMP_DEPARTMENT_ID = '" + Convert.ToInt32(_obj_smhr_employee.EMP_DEPARTMENT_ID) + "'" +
        //                    ",@EMP_SUPBUSINESSUNIT_ID='" + Convert.ToInt32(_obj_smhr_employee.EMP_SUPBUSINESSUNIT_ID) + "'" +
        //                    ",@EMP_HOBBIES='" + _obj_smhr_employee.EMP_HOBBIES + "'" +
        //                    ",@EMP_ID = '" + _obj_smhr_employee.EMP_ID + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        default:
        //            break;
        //    }
        //    return status;
        //}



        //public static bool set_EmpFamily(SMHR_EMPLOYEE _obj_smhr_employee)
        //{
        //    bool status = false;
        //    switch (_obj_smhr_employee.OPERATION)
        //    {
        //        case operation.Insert:
        //            if (ExecuteNonQuery(" EXEC USP_SMHR_EMPFAMILYDETAILS @Operation = '" + _obj_smhr_employee.OPERATION + "'" +
        //                                ",@EMPFMDTL_EMP_ID = '" + _obj_smhr_employee.EMPFMDTL_EMP_ID + "'" +
        //                                ",@EMPFMDTL_SERIAL = '" + _obj_smhr_employee.EMPFMDTL_SERIAL + "'" +
        //                                ",@EMPFMDTL_EMPREL_ID = '" + _obj_smhr_employee.EMPFMDTL_EMPREL_ID + "'" +
        //                                ",@EMPFMDTL_NAME = '" + _obj_smhr_employee.EMPFMDTL_NAME + "'" +
        //                                ",@EMPFMDTL_RELDOB = '" + _obj_smhr_employee.EMPFMDTL_RELDOB + "'" +
        //                                ",@EMPFMDTL_RELDEPENDENT = '" + _obj_smhr_employee.EMPFMDTL_RELDEPENDENT + "'" +
        //                                ",@EMPFMDTL_RELEMERGENCY = '" + _obj_smhr_employee.EMPFMDTL_EMERGENCYCONTACT + "'" +
        //                                ",@EMPFMDTL_RELNEXTTOKIN = '" + _obj_smhr_employee.EMPFMDTL_ISNEXTTOKIN + "'" +
        //                                ",@EMPFMDTL_CREATEDBY = '" + _obj_smhr_employee.EMPFMDTL_CREATEDBY + "'" +
        //                                ",@EMPFMDTL_CREATEDDATE = '" + Convert.ToDateTime(_obj_smhr_employee.EMPFMDTL_CREATEDDATE).ToString("MM/dd/yyyy") + "'" +
        //                                ",@EMPFMDTL_ANNUALINCOME='" + Convert.ToDouble(_obj_smhr_employee.EMPFMDTL_ANNUALINCOME) + "'" +
        //                                ",@EMPFMDTL_OCCUPATION='" + _obj_smhr_employee.EMPFMDTL_OCCUPATION + "'" +
        //                                ",@EMPFMDTL_RELNOMINEE='" + _obj_smhr_employee.EMPFMDTL_NOMINEE + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        case operation.Update:
        //            if (ExecuteNonQuery(" EXEC USP_SMHR_EMPFAMILYDETAILS @Operation = '" + _obj_smhr_employee.OPERATION + "'" +
        //                                ",@EMPFMDTL_EMP_ID = '" + _obj_smhr_employee.EMPFMDTL_EMP_ID + "'" +
        //                                ",@EMPFMDTL_SERIAL = '" + _obj_smhr_employee.EMPFMDTL_SERIAL + "'" +
        //                                ",@EMPFMDTL_EMPREL_ID = '" + _obj_smhr_employee.EMPFMDTL_EMPREL_ID + "'" +
        //                                ",@EMPFMDTL_NAME = '" + _obj_smhr_employee.EMPFMDTL_NAME + "'" +
        //                                ",@EMPFMDTL_RELDOB = '" + _obj_smhr_employee.EMPFMDTL_RELDOB + "'" +
        //                                ",@EMPFMDTL_RELDEPENDENT = '" + _obj_smhr_employee.EMPFMDTL_RELDEPENDENT + "'" +
        //                                ",@EMPFMDTL_RELEMERGENCY = '" + _obj_smhr_employee.EMPFMDTL_EMERGENCYCONTACT + "'" +
        //                                ",@EMPFMDTL_RELNEXTTOKIN = '" + _obj_smhr_employee.EMPFMDTL_ISNEXTTOKIN + "'" +
        //                                ",@EMPFMDTL_LASTMDFBY = '" + _obj_smhr_employee.EMPFMDTL_LASTMDFBY + "'" +
        //                                ",@EMPFMDTL_LASTMDFDATE = '" + Convert.ToDateTime(_obj_smhr_employee.EMPFMDTL_LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
        //                                 ",@EMPFMDTL_ANNUALINCOME='" + Convert.ToDouble(_obj_smhr_employee.EMPFMDTL_ANNUALINCOME) + "'" +
        //                                ",@EMPFMDTL_OCCUPATION='" + _obj_smhr_employee.EMPFMDTL_OCCUPATION + "'" +
        //                                ",@EMPFMDTL_RELNOMINEE='" + _obj_smhr_employee.EMPFMDTL_NOMINEE + "'" +
        //                                ",@EMPFMDTL_ID = '" + _obj_smhr_employee.EMPFMDTL_ID + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;

        //        //Modified
        //        case operation.Insert_New:
        //            if (ExecuteNonQuery("EXEC USP_SMHR_FAMILYDETAILS_MODIFIED @Operation='" + _obj_smhr_employee.OPERATION + "'" +
        //                                ",@EMPFMDTL_EMP_ID = '" + _obj_smhr_employee.EMPFMDTL_EMP_ID + "'" +
        //                                ",@EMPFMDTL_SERIAL = '" + _obj_smhr_employee.EMPFMDTL_SERIAL + "'" +
        //                                ",@EMPFMDTL_EMPREL_ID = '" + _obj_smhr_employee.EMPFMDTL_EMPREL_ID + "'" +
        //                                ",@EMPFMDTL_NAME = '" + _obj_smhr_employee.EMPFMDTL_NAME + "'" +
        //                                ",@EMPFMDTL_RELDOB = '" + _obj_smhr_employee.EMPFMDTL_RELDOB + "'" +
        //                                ",@EMPFMDTL_RELDEPENDENT = '" + _obj_smhr_employee.EMPFMDTL_RELDEPENDENT + "'" +
        //                                ",@EMPFMDTL_RELEMERGENCY = '" + _obj_smhr_employee.EMPFMDTL_EMERGENCYCONTACT + "'" +
        //                                ",@EMPFMDTL_RELNEXTTOKIN = '" + _obj_smhr_employee.EMPFMDTL_ISNEXTTOKIN + "'" +
        //                                ",@EMPFMDTL_CREATEDBY = '" + _obj_smhr_employee.EMPFMDTL_CREATEDBY + "'" +
        //                                ",@EMPFMDTL_CREATEDDATE = '" + Convert.ToDateTime(_obj_smhr_employee.EMPFMDTL_CREATEDDATE).ToString("MM/dd/yyyy") + "'" +
        //                                ",@EMPFMDTL_ANNUALINCOME='" + _obj_smhr_employee.EMPFMDTL_ANNUALINCOME + "'" +
        //                                ",@EMPFMDTL_OCCUPATION='" + _obj_smhr_employee.EMPFMDTL_OCCUPATION + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;

        //        //Modified
        //        case operation.Update_New:
        //            if (ExecuteNonQuery("EXEC USP_SMHR_FAMILYDETAILS_MODIFIED @Operation='" + _obj_smhr_employee.OPERATION + "'" +
        //                                ",@EMPFMDTL_EMP_ID = '" + _obj_smhr_employee.EMPFMDTL_EMP_ID + "'" +
        //                                ",@EMPFMDTL_SERIAL = '" + _obj_smhr_employee.EMPFMDTL_SERIAL + "'" +
        //                                ",@EMPFMDTL_EMPREL_ID = '" + _obj_smhr_employee.EMPFMDTL_EMPREL_ID + "'" +
        //                                ",@EMPFMDTL_NAME = '" + _obj_smhr_employee.EMPFMDTL_NAME + "'" +
        //                                ",@EMPFMDTL_RELDOB = '" + _obj_smhr_employee.EMPFMDTL_RELDOB + "'" +
        //                                ",@EMPFMDTL_RELDEPENDENT = '" + _obj_smhr_employee.EMPFMDTL_RELDEPENDENT + "'" +
        //                                ",@EMPFMDTL_RELEMERGENCY = '" + _obj_smhr_employee.EMPFMDTL_EMERGENCYCONTACT + "'" +
        //                                ",@EMPFMDTL_RELNEXTTOKIN = '" + _obj_smhr_employee.EMPFMDTL_ISNEXTTOKIN + "'" +
        //                                ",@EMPFMDTL_CREATEDBY = '" + _obj_smhr_employee.EMPFMDTL_CREATEDBY + "'" +
        //                                ",@EMPFMDTL_CREATEDDATE = '" + Convert.ToDateTime(_obj_smhr_employee.EMPFMDTL_CREATEDDATE).ToString("MM/dd/yyyy") + "'" +
        //                                ",@EMPFMDTL_ANNUALINCOME='" + _obj_smhr_employee.EMPFMDTL_ANNUALINCOME + "'" +
        //                                ",@EMPFMDTL_OCCUPATION='" + _obj_smhr_employee.EMPFMDTL_OCCUPATION + "'" +
        //                                ",@EMPFMDTL_ID = '" + _obj_smhr_employee.EMPFMDTL_ID + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //    }
        //    return status;
        //}

        //public static bool set_RehireEmployee(SMHR_EMPLOYEE _obj_smhr_employee)
        //{
        //    bool status = false;
        //    switch (_obj_smhr_employee.OPERATION)
        //    {
        //        case operation.Insert:
        //            if (ExecuteNonQuery(" EXEC USP_SMHR_REHIREEMPLOYEE @EMP_ID = " + _obj_smhr_employee.EMP_ID + "" +
        //                    ",@EMP_EMPCODE = '" + _obj_smhr_employee.EMP_EMPCODE + "'" +
        //                    ",@EMP_CREATEDBY = '" + _obj_smhr_employee.EMP_CREATEDBY + "'" +
        //                    ",@EMP_CREATEDDATE = '" + Convert.ToDateTime(_obj_smhr_employee.EMP_CREATEDDATE).ToString("MM/dd/yyyy") + "'" +
        //                    ",@EMP_LASTMDFBY = '" + _obj_smhr_employee.EMP_LASTMDFBY + "'" +
        //                    ",@EMP_LASTMDFDATE = '" + Convert.ToDateTime(_obj_smhr_employee.EMP_LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
        //                    ",@GLOBALCONFIG_ORGANISATION_ID = '" + _obj_smhr_employee.ORGANISATION_ID + "'" +
        //                    ",@EMP_APPLICANT = '" + Convert.ToString(_obj_smhr_employee.EMPFMDTL_NAME) + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        case operation.Update:
        //            if (ExecuteNonQuery(" EXEC USP_SMHR_EMPLOYEE @Operation = '" + _obj_smhr_employee.OPERATION + "'" +
        //                    ",@EMP_EMPCODE = '" + _obj_smhr_employee.EMP_EMPCODE + "'" +
        //                    ",@EMP_APPLICANT_ID = '" + _obj_smhr_employee.EMP_APPLICANT_ID + "'" +
        //                    ",@EMP_DOJ = '" + Convert.ToDateTime(_obj_smhr_employee.EMP_DOJ).ToString("MM/dd/yyyy") + "'" +
        //                    ",@EMP_DOC = " + (_obj_smhr_employee.EMP_DOC == null ? "null" : "'" + _obj_smhr_employee.EMP_DOC + "'") + "" +
        //                    ",@EMP_DESIGNATION_ID = '" + _obj_smhr_employee.EMP_DESIGNATION_ID + "'" +
        //                    ",@EMP_BUSINESSUNIT_ID = '" + _obj_smhr_employee.EMP_BUSINESSUNIT_ID + "'" +
        //                    ",@EMP_DATEOFLASTPROMOTION = " + (_obj_smhr_employee.EMP_DATEOFLASTPROMOTION == null ? "null" : "'" + _obj_smhr_employee.EMP_DATEOFLASTPROMOTION + "'") +
        //                    ",@EMP_GRADE = '" + _obj_smhr_employee.EMP_GRADE + "'" +
        //                    ",@EMP_REPORTINGEMPLOYEE = '" + _obj_smhr_employee.EMP_REPORTINGEMPLOYEE + "'" +
        //                    ",@EMP_RPTSTARTDATE = " + (_obj_smhr_employee.EMP_RPTSTARTDATE == null ? "null" : "'" + _obj_smhr_employee.EMP_RPTSTARTDATE + "'") +
        //                    ",@EMP_RPTENDDATE = " + (_obj_smhr_employee.EMP_RPTENDDATE == null ? "null" : "" + _obj_smhr_employee.EMP_RPTENDDATE + "'") +
        //                    ",@EMP_SHIFT_ID = '" + _obj_smhr_employee.EMP_SHIFT_ID + "'" +
        //                    ",@EMP_GROSSSAL = '" + _obj_smhr_employee.EMP_GROSSSAL + "'" +
        //                    ",@EMP_BASIC = '" + _obj_smhr_employee.EMP_BASIC + "'" +
        //                    ",@EMP_PAYMENTMODE_ID = '" + _obj_smhr_employee.EMP_PAYMENTMODE_ID + "'" +
        //                    ",@EMP_SALALRYSTRUCT_ID = '" + _obj_smhr_employee.EMP_SALALRYSTRUCT_ID + "'" +
        //                    ",@EMP_LEAVESTRUCT_ID = '" + _obj_smhr_employee.EMP_LEAVESTRUCT_ID + "'" +
        //                    ",@EMP_STATUS = '" + _obj_smhr_employee.EMP_STATUS + "'" +
        //                    ",@EMP_PROBATIONDATE = " + (_obj_smhr_employee.EMP_PROBATIONDATE == null ? "null" : "'" + _obj_smhr_employee.EMP_PROBATIONDATE + "'") +
        //                    ",@EMP_NOTICEPERIOD = '" + _obj_smhr_employee.EMP_NOTICEPERIOD + "'" +
        //                    ",@EMP_LASTMDFBY = '" + _obj_smhr_employee.EMP_LASTMDFBY + "'" +
        //                    ",@EMP_LASTMDFDATE = '" + Convert.ToDateTime(_obj_smhr_employee.EMP_LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
        //                    ",@EMP_SUPBUSINESSUNIT_ID='" + Convert.ToInt32(_obj_smhr_employee.EMP_SUPBUSINESSUNIT_ID) + "'" +
        //                    ",@EMP_HOBBIES='" + Convert.ToString(_obj_smhr_employee.EMP_HOBBIES) + "'" +
        //                    ",@EMP_ID = '" + _obj_smhr_employee.EMP_ID + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        default:
        //            break;
        //    }
        //    return status;
        //}


        ////public static bool set_EmpFamily(SMHR_EMPLOYEE _obj_smhr_employee)
        ////{
        ////    bool status = false;
        ////    switch (_obj_smhr_employee.OPERATION)
        ////    {
        ////        case operation.Insert:
        ////            if (ExecuteNonQuery(" EXEC USP_SMHR_EMPFAMILYDETAILS @Operation = '" + _obj_smhr_employee.OPERATION + "'" +
        ////                                ",@EMPFMDTL_EMP_ID = '" + _obj_smhr_employee.EMPFMDTL_EMP_ID + "'" +
        ////                                ",@EMPFMDTL_SERIAL = '" + _obj_smhr_employee.EMPFMDTL_SERIAL + "'" +
        ////                                ",@EMPFMDTL_EMPREL_ID = '" + _obj_smhr_employee.EMPFMDTL_EMPREL_ID + "'" +
        ////                                ",@EMPFMDTL_NAME = '" + _obj_smhr_employee.EMPFMDTL_NAME + "'" +
        ////                                ",@EMPFMDTL_RELDOB = '" + _obj_smhr_employee.EMPFMDTL_RELDOB + "'" +
        ////                                ",@EMPFMDTL_RELDEPENDENT = '" + _obj_smhr_employee.EMPFMDTL_RELDEPENDENT + "'" +
        ////                                ",@EMPFMDTL_RELEMERGENCY = '" + _obj_smhr_employee.EMPFMDTL_EMERGENCYCONTACT + "'" +
        ////                                ",@EMPFMDTL_RELNEXTTOKIN = '" + _obj_smhr_employee.EMPFMDTL_ISNEXTTOKIN + "'" +
        ////                                ",@EMPFMDTL_CREATEDBY = '" + _obj_smhr_employee.EMPFMDTL_CREATEDBY + "'" +
        ////                                ",@EMPFMDTL_CREATEDDATE = '" + Convert.ToDateTime(_obj_smhr_employee.EMPFMDTL_CREATEDDATE).ToString("MM/dd/yyyy") + "'"))
        ////                status = true;
        ////            else
        ////                status = false;
        ////            break;
        ////        case operation.Update:
        ////            if (ExecuteNonQuery(" EXEC USP_SMHR_EMPFAMILYDETAILS @Operation = '" + _obj_smhr_employee.OPERATION + "'" +
        ////                                ",@EMPFMDTL_EMP_ID = '" + _obj_smhr_employee.EMPFMDTL_EMP_ID + "'" +
        ////                                ",@EMPFMDTL_SERIAL = '" + _obj_smhr_employee.EMPFMDTL_SERIAL + "'" +
        ////                                ",@EMPFMDTL_EMPREL_ID = '" + _obj_smhr_employee.EMPFMDTL_EMPREL_ID + "'" +
        ////                                ",@EMPFMDTL_NAME = '" + _obj_smhr_employee.EMPFMDTL_NAME + "'" +
        ////                                ",@EMPFMDTL_RELDOB = '" + _obj_smhr_employee.EMPFMDTL_RELDOB + "'" +
        ////                                ",@EMPFMDTL_RELDEPENDENT = '" + _obj_smhr_employee.EMPFMDTL_RELDEPENDENT + "'" +
        ////                                ",@EMPFMDTL_RELEMERGENCY = '" + _obj_smhr_employee.EMPFMDTL_EMERGENCYCONTACT + "'" +
        ////                                ",@EMPFMDTL_RELNEXTTOKIN = '" + _obj_smhr_employee.EMPFMDTL_ISNEXTTOKIN + "'" +
        ////                                ",@EMPFMDTL_LASTMDFBY = '" + _obj_smhr_employee.EMPFMDTL_LASTMDFBY + "'" +
        ////                                ",@EMPFMDTL_LASTMDFDATE = '" + Convert.ToDateTime(_obj_smhr_employee.EMPFMDTL_LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
        ////                                ",@EMPFMDTL_ID = '" + _obj_smhr_employee.EMPFMDTL_ID + "'"))
        ////                status = true;
        ////            else
        ////                status = false;
        ////            break;

        ////        //Modified
        ////        case operation.Insert_New:
        ////            if (ExecuteNonQuery("EXEC USP_SMHR_FAMILYDETAILS_MODIFIED @Operation='" + _obj_smhr_employee.OPERATION + "'" +
        ////                                ",@EMPFMDTL_EMP_ID = '" + _obj_smhr_employee.EMPFMDTL_EMP_ID + "'" +
        ////                                ",@EMPFMDTL_SERIAL = '" + _obj_smhr_employee.EMPFMDTL_SERIAL + "'" +
        ////                                ",@EMPFMDTL_EMPREL_ID = '" + _obj_smhr_employee.EMPFMDTL_EMPREL_ID + "'" +
        ////                                ",@EMPFMDTL_NAME = '" + _obj_smhr_employee.EMPFMDTL_NAME + "'" +
        ////                                ",@EMPFMDTL_RELDOB = '" + _obj_smhr_employee.EMPFMDTL_RELDOB + "'" +
        ////                                ",@EMPFMDTL_RELDEPENDENT = '" + _obj_smhr_employee.EMPFMDTL_RELDEPENDENT + "'" +
        ////                                ",@EMPFMDTL_RELEMERGENCY = '" + _obj_smhr_employee.EMPFMDTL_EMERGENCYCONTACT + "'" +
        ////                                ",@EMPFMDTL_RELNEXTTOKIN = '" + _obj_smhr_employee.EMPFMDTL_ISNEXTTOKIN + "'" +
        ////                                ",@EMPFMDTL_CREATEDBY = '" + _obj_smhr_employee.EMPFMDTL_CREATEDBY + "'" +
        ////                                ",@EMPFMDTL_CREATEDDATE = '" + Convert.ToDateTime(_obj_smhr_employee.EMPFMDTL_CREATEDDATE).ToString("MM/dd/yyyy") + "'" +
        ////                                ",@EMPFMDTL_ANNUALINCOME='" + _obj_smhr_employee.EMPFMDTL_ANNUALINCOME + "'" +
        ////                                ",@EMPFMDTL_OCCUPATION='" + _obj_smhr_employee.EMPFMDTL_OCCUPATION + "'"))
        ////                status = true;
        ////            else
        ////                status = false;
        ////            break;

        ////        //Modified
        ////        case operation.Update_New:
        ////            if (ExecuteNonQuery("EXEC USP_SMHR_FAMILYDETAILS_MODIFIED @Operation='" + _obj_smhr_employee.OPERATION + "'" +
        ////                                ",@EMPFMDTL_EMP_ID = '" + _obj_smhr_employee.EMPFMDTL_EMP_ID + "'" +
        ////                                ",@EMPFMDTL_SERIAL = '" + _obj_smhr_employee.EMPFMDTL_SERIAL + "'" +
        ////                                ",@EMPFMDTL_EMPREL_ID = '" + _obj_smhr_employee.EMPFMDTL_EMPREL_ID + "'" +
        ////                                ",@EMPFMDTL_NAME = '" + _obj_smhr_employee.EMPFMDTL_NAME + "'" +
        ////                                ",@EMPFMDTL_RELDOB = '" + _obj_smhr_employee.EMPFMDTL_RELDOB + "'" +
        ////                                ",@EMPFMDTL_RELDEPENDENT = '" + _obj_smhr_employee.EMPFMDTL_RELDEPENDENT + "'" +
        ////                                ",@EMPFMDTL_RELEMERGENCY = '" + _obj_smhr_employee.EMPFMDTL_EMERGENCYCONTACT + "'" +
        ////                                ",@EMPFMDTL_RELNEXTTOKIN = '" + _obj_smhr_employee.EMPFMDTL_ISNEXTTOKIN + "'" +
        ////                                ",@EMPFMDTL_CREATEDBY = '" + _obj_smhr_employee.EMPFMDTL_CREATEDBY + "'" +
        ////                                ",@EMPFMDTL_CREATEDDATE = '" + Convert.ToDateTime(_obj_smhr_employee.EMPFMDTL_CREATEDDATE).ToString("MM/dd/yyyy") + "'" +
        ////                                ",@EMPFMDTL_ANNUALINCOME='" + _obj_smhr_employee.EMPFMDTL_ANNUALINCOME + "'" +
        ////                                ",@EMPFMDTL_OCCUPATION='" + _obj_smhr_employee.EMPFMDTL_OCCUPATION + "'" +
        ////                                ",@EMPFMDTL_ID = '" + _obj_smhr_employee.EMPFMDTL_ID + "'"))
        ////                status = true;
        ////            else
        ////                status = false;
        ////            break;
        ////    }
        ////    return status;
        ////}

        //public static DataTable get_EmployeeFamily(SMHR_EMPLOYEE _obj_smhr_employee)
        //{
        //    if (_obj_smhr_employee.OPERATION == operation.Select)
        //    {
        //        return ExecuteQuery(" EXEC USP_SMHR_EMPFAMILYDETAILS @Operation = 'check'");
        //    }
        //    else
        //    {
        //        return ExecuteQuery(" EXEC USP_SMHR_EMPFAMILYDETAILS @Operation = 'check', @EMPFMDTL_EMP_ID = '" + _obj_smhr_employee.EMPFMDTL_EMP_ID + "'");
        //    }
        //}

        //public static bool set_EmployeeSwipe(SMHR_EMPLOYEE _obj_smhr_employee)
        //{
        //    bool status = false;
        //    switch (_obj_smhr_employee.OPERATION)
        //    {
        //        case operation.Insert:
        //            if (ExecuteNonQuery(" EXEC USP_SMHR_EMPLOYEESWIPEMASTER @Operation = '" + _obj_smhr_employee.OPERATION + "'" +
        //                                ",@EMPSWM_EMP_ID = '" + _obj_smhr_employee.EMPSWM_EMP_ID + "'" +
        //                                ",@EMPSWM_SERIAL = '" + _obj_smhr_employee.EMPSWM_SERIAL + "'" +
        //                                ",@EMPSWM_CARDCODE = '" + _obj_smhr_employee.EMPSWM_CARDCODE + "'" +
        //                                ",@EMPSWM_CARDISSUE = '" + _obj_smhr_employee.EMPSWM_CARDISSUE + "'" +
        //                                ",@EMPSWM_CARDEXPIRY = '" + _obj_smhr_employee.EMPSWM_CARDEXPIRY + "'" +
        //                                ",@EMPSWM_REMARKS = '" + _obj_smhr_employee.EMPSWM_REMARKS + "'" +
        //                                ",@EMPSWM_CREATEDBY = '" + _obj_smhr_employee.EMPSWM_CREATEDBY + "'" +
        //                                ",@EMPSWM_CREATEDDATE = '" + Convert.ToDateTime(_obj_smhr_employee.EMPSWM_CREATEDDATE).ToString("MM/dd/yyyy") + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        case operation.Update:
        //            if (ExecuteNonQuery(" EXEC USP_SMHR_EMPLOYEESWIPEMASTER @Operation = '" + _obj_smhr_employee.OPERATION + "'" +
        //                                ",@EMPSWM_EMP_ID = '" + _obj_smhr_employee.EMPSWM_EMP_ID + "'" +
        //                                ",@EMPSWM_SERIAL = '" + _obj_smhr_employee.EMPSWM_SERIAL + "'" +
        //                                ",@EMPSWM_CARDCODE = '" + _obj_smhr_employee.EMPSWM_CARDCODE + "'" +
        //                                ",@EMPSWM_CARDISSUE = '" + _obj_smhr_employee.EMPSWM_CARDISSUE + "'" +
        //                                ",@EMPSWM_CARDEXPIRY = '" + _obj_smhr_employee.EMPSWM_CARDEXPIRY + "'" +
        //                                ",@EMPSWM_REMARKS = '" + _obj_smhr_employee.EMPSWM_REMARKS + "'" +
        //                                ",@EMPSWM_LASTMDFBY = '" + _obj_smhr_employee.EMPSWM_LASTMDFBY + "'" +
        //                                ",@EMPSWM_LASTMDFDATE = '" + Convert.ToDateTime(_obj_smhr_employee.EMPSWM_LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
        //                                ",@EMPSWM_ID = '" + _obj_smhr_employee.EMPSWM_ID + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        default:
        //            break;
        //    }
        //    return status;
        //}

        //public static DataTable get_EmployeeSwipe(SMHR_EMPLOYEE _obj_smhr_employee)
        //{
        //    if (_obj_smhr_employee.OPERATION == operation.Select)
        //    {
        //        return ExecuteQuery(" EXEC USP_SMHR_EMPLOYEESWIPEMASTER @Operation = 'check'");
        //    }
        //    else
        //    {
        //        return ExecuteQuery(" EXEC USP_SMHR_EMPLOYEESWIPEMASTER @Operation = 'check', @EMPSWM_EMP_ID = '" + _obj_smhr_employee.EMPSWM_EMP_ID + "'");
        //    }
        //}

        //public static bool set_EmpOTInfo(SMHR_EMPLOYEE _obj_smhr_employee)
        //{
        //    bool status = false;
        //    switch (_obj_smhr_employee.OPERATION)
        //    {
        //        case operation.Insert:
        //            if (ExecuteNonQuery(" EXEC USP_SMHR_EMPLOYEEOTRATE @Operation = '" + _obj_smhr_employee.OPERATION + "'" +
        //                                ",@EMPOTR_EMP_ID = '" + _obj_smhr_employee.EMPOTR_EMP_ID + "'" +
        //                                ",@EMPOTR_OTTYPE_ID = '" + _obj_smhr_employee.EMPOTR_OTTYPE_ID + "'" +
        //                                ",@EMPOTR_OTRATE = '" + _obj_smhr_employee.EMPOTR_OTRATE + "'" +
        //                                ",@EMPOTR_CREATEDBY = '" + _obj_smhr_employee.EMPOTR_CREATEDBY + "'" +
        //                                ",@EMPOTR_CREATEDDATE = '" + Convert.ToDateTime(_obj_smhr_employee.EMPOTR_CREATEDDATE).ToString("MM/dd/yyyy") + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        case operation.Update:
        //            if (ExecuteNonQuery(" EXEC USP_SMHR_EMPLOYEEOTRATE @Operation = '" + _obj_smhr_employee.OPERATION + "'" +
        //                                ",@EMPOTR_EMP_ID = '" + _obj_smhr_employee.EMPOTR_EMP_ID + "'" +
        //                                ",@EMPOTR_OTTYPE_ID = '" + _obj_smhr_employee.EMPOTR_OTTYPE_ID + "'" +
        //                                ",@EMPOTR_OTRATE = '" + _obj_smhr_employee.EMPOTR_OTRATE + "'" +
        //                                ",@EMPOTR_LASTMDFBY = '" + _obj_smhr_employee.EMPOTR_LASTMDFBY + "'" +
        //                                ",@EMPOTR_LASTMDFDATE = '" + Convert.ToDateTime(_obj_smhr_employee.EMPOTR_LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
        //                                ",@EMPOTR_ID = '" + _obj_smhr_employee.EMPOTR_ID + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        default:
        //            break;
        //    }
        //    return status;
        //}

        //public static DataTable get_EmpOTRate(SMHR_EMPLOYEE _obj_smhr_employee)
        //{
        //    if (_obj_smhr_employee.OPERATION == operation.Select)
        //    {
        //        if (_obj_smhr_employee.EMPWOFF_ID.ToString() == "0")
        //        {
        //            return ExecuteQuery("EXEC USP_SMHR_EMPLOYEEOTRATE @Operation = 'select'");
        //        }
        //        else
        //        {
        //            return ExecuteQuery("EXEC USP_SMHR_EMPLOYEEOTRATE @Operation = 'select', @EMPOTR_ID = '" + _obj_smhr_employee.EMPOTR_ID + "'");
        //        }
        //    }
        //    else
        //    {
        //        return ExecuteQuery("EXEC USP_SMHR_EMPLOYEEOTRATE @Operation = 'Empty', @EMPOTR_EMP_ID = '" + _obj_smhr_employee.EMPOTR_EMP_ID + "'");

        //    }

        //}

        //public static DataTable get_EmpWeeklyoff(SMHR_EMPLOYEE _obj_smhr_employee)
        //{
        //    if (_obj_smhr_employee.OPERATION == operation.Select)
        //    {
        //        if (_obj_smhr_employee.EMPWOFF_ID.ToString() == "0")
        //        {
        //            return ExecuteQuery(" EXEC USP_SMHR_EMPLOYEEWEEKLYOFF @Operation = 'select'");
        //        }
        //        else
        //        {
        //            return ExecuteQuery(" EXEC USP_SMHR_EMPLOYEEWEEKLYOFF @Operation = 'select', @EMPWOFF_ID = '" + _obj_smhr_employee.EMPWOFF_ID + "'");
        //        }
        //    }
        //    else
        //    {
        //        return ExecuteQuery(" EXEC USP_SMHR_EMPLOYEEWEEKLYOFF @Operation = 'select', @EMPWOFF_EMP_ID = '" + _obj_smhr_employee.EMPWOFF_EMP_ID + "'");
        //    }
        //}

        //public static bool set_EmpWeeklyoff(SMHR_EMPLOYEE _obj_smhr_employee)
        //{
        //    bool status = false;
        //    switch (_obj_smhr_employee.OPERATION)
        //    {
        //        case operation.Insert:
        //            if (ExecuteNonQuery(" EXEC USP_SMHR_EMPLOYEEWEEKLYOFF @Operation = '" + _obj_smhr_employee.OPERATION + "'" +
        //                                ",@EMPWOFF_EMP_ID = '" + _obj_smhr_employee.EMPWOFF_EMP_ID + "'" +
        //                                ",@EMPWOFF_DAY_ID = '" + _obj_smhr_employee.EMPWOFF_DAY_ID + "'" +
        //                                ",@EMPWOFF_CREATEDBY  = '" + _obj_smhr_employee.EMPWOFF_CREATEDBY + "'" +
        //                                ",@EMPWOFF_CREATEDDATE = '" + Convert.ToDateTime(_obj_smhr_employee.EMPWOFF_CREATEDDATE).ToString("MM/dd/yyyy") + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        case operation.Update:
        //            if (ExecuteNonQuery(" EXEC USP_SMHR_EMPLOYEEWEEKLYOFF @Operation = '" + _obj_smhr_employee.OPERATION + "'" +
        //                                ",@EMPWOFF_EMP_ID = '" + _obj_smhr_employee.EMPWOFF_EMP_ID + "'" +
        //                                ",@EMPWOFF_DAY_ID = '" + _obj_smhr_employee.EMPWOFF_DAY_ID + "'" +
        //                                ",@EMPWOFF_LASTMDFBY = '" + _obj_smhr_employee.EMPWOFF_LASTMDFBY + "'" +
        //                                ",@EMPWOFF_LASTMDFDATE = '" + Convert.ToDateTime(_obj_smhr_employee.EMPWOFF_LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
        //                                ",@EMPWOFF_ID = '" + _obj_smhr_employee.EMPWOFF_ID + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        default:
        //            break;
        //    }
        //    return status;
        //}

        //#endregion

        //#region SMHR_ORGANISATION

        ////public static DataTable get_Organisation(SMHR_ORGANISATION _obj_Organisation)
        ////{
        ////    if (_obj_Organisation.MODE == 1)
        ////    {
        ////        return Dal.ExecuteQuery("EXEC USP_SMHR_ORGANISATION @MODE = '" + _obj_Organisation.MODE + "'");
        ////    }
        ////    else if (_obj_Organisation.MODE == 6)
        ////    {
        ////        return Dal.ExecuteQuery("EXEC USP_SMHR_ORGANISATION @MODE = '" + _obj_Organisation.MODE + "'" +
        ////                                ",@ORGANISATION_NAME = '" + _obj_Organisation.ORGANISATION_NAME + "'");
        ////    }
        ////    else
        ////    {
        ////        return Dal.ExecuteQuery("EXEC USP_SMHR_ORGANISATION @MODE = '" + _obj_Organisation.MODE + "'" +
        ////                                ",@ORGANISATION_ID = '" + _obj_Organisation.ORGANISATION_ID + "'");
        ////    }
        ////}

        //public static DataTable get_FormsbyModuleId(SMHR_FORMS _obj_forms)
        //{
        //    DataTable dt = new DataTable();
        //    if (_obj_forms.MODE == 3)
        //    {
        //        dt = Dal.ExecuteQuery("EXEC USP_SMHR_USERPRIVILEGES @MODE = '3',@FORM_MODULE_ID = '" + _obj_forms.FORMS_MODULE_ID + "',@FORM_PACKAGE_ID='" + _obj_forms.FORMS_PACKAGE_ID + "'");
        //    }
        //    return dt;
        //}

        //public static DataTable get_Modules(SMHR_FORMS _obj_forms)
        //{
        //    DataTable dt = new DataTable();
        //    if (_obj_forms.MODE == 2)
        //    {
        //        dt = Dal.ExecuteQuery("EXEC USP_SMHR_TYPESECURITY @MODE = '2',@SMHR_MODULE_SUPER_MODULE_ID='" + _obj_forms.FORMS_MODULE_ID + "'");
        //    }
        //    else
        //    {
        //        dt = Dal.ExecuteQuery("EXEC USP_SMHR_TYPESECURITY @MODE = '7',@TYPESEC_ORG_ID='" + _obj_forms.ORGANISATION_ID + "'");
        //    }
        //    return dt;
        //}

        //public static DataTable get_Package(SMHR_ORGANISATION _obj_Organisation)
        //{
        //    DataTable dt = new DataTable();
        //    if (_obj_Organisation.MODE == 7)
        //    {
        //        dt = Dal.ExecuteQuery("EXEC USP_SMHR_ORGANISATION @MODE = '" + _obj_Organisation.MODE + "'");

        //    }
        //    else
        //    {
        //        dt = Dal.ExecuteQuery("EXEC USP_SMHR_ORGANISATION @MODE = '" + _obj_Organisation.MODE + "'");
        //    }
        //    return dt;
        //}

        //public static bool set_USERPRIVILEGES(SMHR_USERPRIVILEGES _obj_Userprivileges)
        //{
        //    bool status = false;
        //    switch (_obj_Userprivileges.OPERATION)
        //    {
        //        case operation.Insert:
        //            if (ExecuteNonQuery("EXEC USP_SMHR_USERPRIVILEGES 'Insert', @SMHR_FORM_ID = '" + _obj_Userprivileges.FORM_ID + "'" +
        //                                        ", @SMHR_MODULE_ID = '" + _obj_Userprivileges.MODULE_ID + "'" +
        //                                        ", @SMHR_PACKAGE_ID = '" + _obj_Userprivileges.PACKAGE_ID + "'" +
        //                                        ", @SMHR_READ = '" + _obj_Userprivileges.READ + "'" +
        //                                        ", @SMHR_WRITE = '" + _obj_Userprivileges.WRITE + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        case operation.Update:
        //            if (ExecuteNonQuery(" EXEC USP_SMHR_USERPRIVILEGES 'Update',@SMHR_USERPRIVILEGES_ID = '" + _obj_Userprivileges.USERPRIVILEGES_ID + "'" +
        //                                ", @SMHR_FORM_ID = '" + _obj_Userprivileges.FORM_ID + "'" +
        //                                ", @SMHR_MODULE_ID = '" + _obj_Userprivileges.MODULE_ID + "'" +
        //                                ", @SMHR_PACKAGE_ID = '" + _obj_Userprivileges.PACKAGE_ID + "'" +
        //                                ", @SMHR_READ = '" + _obj_Userprivileges.READ + "'" +
        //                                ", @SMHR_WRITE = '" + _obj_Userprivileges.WRITE + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        default:
        //            break;
        //    }
        //    return status;
        //}

        //public static bool set_Organisation(SMHR_ORGANISATION _obj_Organisation)
        //{
        //    bool status = false;
        //    if (_obj_Organisation.MODE == 3)
        //    {
        //        return ExecuteNonQuery(" EXEC USP_SMHR_ORGANISATION @MODE = '" + _obj_Organisation.MODE + "'," +
        //                                " @ORGANISATION_NAME = '" + _obj_Organisation.ORGANISATION_NAME + "'" +
        //                                ", @ORGANISATION_DESC = '" + _obj_Organisation.ORGANISATION_DESC + "'" +
        //            //NEWLY ADDED FOR VARIABLE AMOUNT
        //                                ",@ORGANISATION_ISVP='" + _obj_Organisation.ORGANISATION_IS_VARIABLEPAY + "'" +
        //                                ",@ORGANISATION_VP_MINPERCENTAGE='" + _obj_Organisation.ORGANISATION_VP_MINPERCENTAGE + "'" +
        //                                ",@ORGANISATION_VP_MAXPERCENTAGE='" + _obj_Organisation.ORGANISATION_VP_MAXPERCENTAGE + "'" +
        //                                ", @ORGANISATION_ADDRESS1 = '" + _obj_Organisation.ORGANISATION_ADDRESS1 + "'" +
        //                                ", @ORGANISATION_ADDRESS2 = '" + _obj_Organisation.ORGANISATION_ADDRESS1 + "'" +
        //                                ", @ORGANISATION_PHONE1 = '" + _obj_Organisation.ORGANISATION_PHONE1 + "'" +
        //                                ", @ORGANISATION_PHONE2 = '" + _obj_Organisation.ORGANISATION_PHONE2 + "'" +
        //                                ", @ORGANISATION_EMAIL = '" + _obj_Organisation.ORGANISATION_EMAIL + "'" +
        //                                ", @ORGANISATION_WEBSITE = '" + _obj_Organisation.ORGANISATION_WEBSITE + "'" +
        //                                ", @ORGANISATION_CONTACTPERSON = '" + _obj_Organisation.ORGANISATION_CONTACTPERSON + "'" +
        //                                ", @ORGANISATION_PACKAGE_ID = '" + _obj_Organisation.ORGANISATION_PACKAGE_ID + "'" +
        //                                ", @ORGANISATION_CREATEDBY = '" + _obj_Organisation.ORGANISATION_CREATEDBY + "'" +
        //                                ", @ORGANISATION_CREATEDDATE = '" + Convert.ToDateTime(_obj_Organisation.ORGANISATION_CREATEDDATE).ToString("MM/dd/yyyy") + "'" +
        //                                ", @ORGANISATION_LASTMDFBY = '" + _obj_Organisation.ORGANISATION_LASTMDFBY + "'" +
        //                                ", @ORGANISATION_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Organisation.ORGANISATION_LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
        //                                ", @ORGANISATION_EMPLOYEES = '" + _obj_Organisation.ORGANISATION_EMPLOYEES1 + "'" +

        //                                //new added
        //                                ", @ORGANISATION_APPLICANTS = '" + _obj_Organisation.ORGANISATION_APPLICANTS1 + "'" +
        //                                ",@ORGANISATION_SUPER_MODULES='" + _obj_Organisation.ORG_SUPER_MODULE_ID + "'");
        //    }
        //    else
        //    {
        //        return ExecuteNonQuery(" EXEC USP_SMHR_ORGANISATION @MODE = '" + _obj_Organisation.MODE + "'," +
        //                                    " @ORGANISATION_NAME = '" + _obj_Organisation.ORGANISATION_NAME + "'" +
        //                                    ", @ORGANISATION_DESC = '" + _obj_Organisation.ORGANISATION_DESC + "'" +
        //            //NEWLY ADDED FOR VARIABLE AMOUNT
        //                                    ",@ORGANISATION_ISVP='" + _obj_Organisation.ORGANISATION_IS_VARIABLEPAY + "'" +
        //                                    ",@ORGANISATION_VP_MINPERCENTAGE='" + _obj_Organisation.ORGANISATION_VP_MINPERCENTAGE + "'" +
        //                                    ",@ORGANISATION_VP_MAXPERCENTAGE='" + _obj_Organisation.ORGANISATION_VP_MAXPERCENTAGE + "'" +
        //                                    ", @ORGANISATION_ADDRESS1 = '" + _obj_Organisation.ORGANISATION_ADDRESS1 + "'" +
        //                                    ", @ORGANISATION_ADDRESS2 = '" + _obj_Organisation.ORGANISATION_ADDRESS1 + "'" +
        //                                    ", @ORGANISATION_PHONE1 = '" + _obj_Organisation.ORGANISATION_PHONE1 + "'" +
        //                                    ", @ORGANISATION_PHONE2 = '" + _obj_Organisation.ORGANISATION_PHONE2 + "'" +
        //                                    ", @ORGANISATION_EMAIL = '" + _obj_Organisation.ORGANISATION_EMAIL + "'" +
        //                                    ", @ORGANISATION_WEBSITE = '" + _obj_Organisation.ORGANISATION_WEBSITE + "'" +
        //                                    ", @ORGANISATION_CONTACTPERSON = '" + _obj_Organisation.ORGANISATION_CONTACTPERSON + "'" +
        //                                    ", @ORGANISATION_PACKAGE_ID = '" + _obj_Organisation.ORGANISATION_PACKAGE_ID + "'" +
        //                                    ", @ORGANISATION_ID = '" + _obj_Organisation.ORGANISATION_ID + "'" +
        //                                    ", @ORGANISATION_LASTMDFBY = '" + _obj_Organisation.ORGANISATION_LASTMDFBY + "'" +
        //                                    ", @ORGANISATION_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Organisation.ORGANISATION_LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
        //                                    ", @ORGANISATION_EMPLOYEES = '" + _obj_Organisation.ORGANISATION_EMPLOYEES1 + "'" +

        //                                    //new added
        //                                    ", @ORGANISATION_APPLICANTS = '" + _obj_Organisation.ORGANISATION_APPLICANTS1 + "'" +
        //                                    ",@ORGANISATION_SUPER_MODULES='" + _obj_Organisation.ORG_SUPER_MODULE_ID + "'");

        //    }
        //}

        //#endregion
    }
}