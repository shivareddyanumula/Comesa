﻿using System;
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
using SPMS;
using SMHR;


namespace SPMS
{
    //create a class//
    public partial class Pms_Bll
    {

        //this for message purpose
        public static void ShowMessage(Control ctrl, string Msg)
        {

            ScriptManager.RegisterStartupScript(ctrl, ctrl.GetType(), Guid.NewGuid().ToString(), "alert('" + Msg + "');", true);
        }
        public static string ReplaceQuote(string str)
        {
            return str.Replace("'", "''");
        }
        //retrive the data from data table..
        public static DataTable ExecuteQuery(string Query)
        {
            return Pms_dal.ExecuteQuery(Query);
        }
        //this for performing the operations
        public static bool ExecuteNonQuery(string Query)
        {
            return Pms_dal.ExecuteNonQuery(Query);
        }

        #region primary employee list
        /// <summary>
        ///  Method to Get TASKDETAILS_ID  Based on the PMS_MODE
        /// </summary>
        /// <param name="PMS_MODE"></param>
        /// <returns>Datatable with Categories Information</returns>
        /// <remarks>
        /// </remarks>
        

        public static DataTable get_pms(pms_primary _obj_primaryvalue)
        {
            if (_obj_primaryvalue.PMS_MODE == 1)
            {
                return ExecuteQuery("EXEC [USP_SPMS_TASKDETAILS] @TASKDETAILS_ID = '" + _obj_primaryvalue.PMS_TASKID + "'" +
                                    ", @MODE = '" + _obj_primaryvalue.PMS_MODE + "'");
            }
            else
            {
                return ExecuteQuery("EXEC[USP_SPMS_TASKDETAILS] @mode = '" + _obj_primaryvalue.PMS_MODE + "'");
            }
        }
        /// <summary>
        ///  Method to Insert or update into the pms_primary table Using Information Passed using the Object
        /// </summary>
        /// <param name="_obj_primaryvalue"></param>
        /// <returns></returns>
        /// 
        public static bool set_pms(pms_primary _obj_primaryvalue)
        {
            if (_obj_primaryvalue.PMS_MODE == 3)
            {
                return ExecuteNonQuery(" EXEC [USP_SPMS_TASKDETAILS] @TASKDETAILS_NAME  = '" + _obj_primaryvalue.PMS_TASKNAME + "'" +
                                       ", @TASKDETAILS_DESC = '" + _obj_primaryvalue.PMS_TASKDESC + "'" +
                                       ", @TASKDETAILS_ASSIGNEDDATE = '" + Convert.ToDateTime(_obj_primaryvalue.PMS_ASSIGNEDTIME) + "'" +
                    //", @TASKDETAILS_ESTIMATEDTIME = '" + Convert.ToDateTime(_obj_primaryvalue.PMS_ESTIMATEDTIME) + "'" +
                                        ", @TASKDETAILS_ESTIMATEDTIME  = " + (_obj_primaryvalue.PMS_ESTIMATEDTIME == null ? "null" : "'" + Convert.ToDateTime(_obj_primaryvalue.PMS_ESTIMATEDTIME).ToString("MM/dd/yyyy") + "'") +
                                       ", @TASKDETAILS_CREATEDBY = '" + _obj_primaryvalue.CREATEDBY + "'" +
                                       ", @TASKDETAILS_CREATEDDATE = '" + _obj_primaryvalue.CREATEDDATE.ToString("MM/dd/yyyy") + "'" +
                                       ", @TASKDETAILS_MANAGERSERVICE_ID = '" + _obj_primaryvalue.PMS_TASKDETAILSMANAGERSERVICEID + "'" +
                                       ", @TASKDETAILS_EMP_ID = '" + _obj_primaryvalue.PMS_TASKDETAILS_EMP_ID + "'" +
                                       ", @mode = '" + _obj_primaryvalue.PMS_MODE + "'");
            }
            else if (_obj_primaryvalue.PMS_MODE == 5)
            {
                return ExecuteNonQuery(" EXEC [USP_SPMS_TASKDETAILS] @TASKDETAILS_NAME= '" + _obj_primaryvalue.PMS_TASKNAME + "'" +
                                    ", @TASKDETAILS_DESC  = '" + _obj_primaryvalue.PMS_TASKDESC + "'" +
                                    ", @TASKDETAILS_ASSIGNEDDATE= '" + _obj_primaryvalue.PMS_ASSIGNEDTIME + "'" +
                    //", @TASKDETAILS_ESTIMATEDTIME = '" + _obj_primaryvalue.PMS_ASSIGNEDTIME + "'" +
                    ", @TASKDETAILS_ESTIMATEDTIME  = " + (_obj_primaryvalue.PMS_ESTIMATEDTIME == null ? "null" : "'" + Convert.ToDateTime(_obj_primaryvalue.PMS_ESTIMATEDTIME).ToString("MM/dd/yyyy") + "'") +
                    //", @TASKDETAILS_ESTIMATEDTIME  = " + (_obj_primaryvalue.PMS_ESTIMATEDTIME == null ? "null" : "'" + Convert.ToDateTime(_obj_primaryvalue.PMS_ESTIMATEDTIME).ToString("MM/dd/yyyy") + "'") +
                                    ", @TASKDETAILS_CREATEDBY = '" + _obj_primaryvalue.CREATEDBY + "'" +
                                    ", @TASKDETAILS_CREATEDDATE = '" + _obj_primaryvalue.CREATEDDATE.ToString("MM/dd/yyyy") + "'" +
                                    ", @TASKDETAILS_LASTMDFBY  = '" + _obj_primaryvalue.LASTMDFBY + "'" +
                                    ", @SMHR_TAXLASTMDFDATE = '" + _obj_primaryvalue.LASTMDFDATE.ToString("MM/dd/yyyy") + "'" +
                                    ", @TASKDETAILS_MANAGERSERVICE_ID = '" + _obj_primaryvalue.PMS_TASKDETAILSMANAGERSERVICEID + "'" +
                                       ", @TASKDETAILS_EMP_ID = '" + _obj_primaryvalue.PMS_TASKDETAILS_EMP_ID + "'" +

                                    ", @mode = '" + _obj_primaryvalue.PMS_MODE + "'");
            }
            else
            {
                return ExecuteNonQuery(" EXEC [USP_SPMS_TASKDETAILS] @TASKDETAILS_ID = '" + _obj_primaryvalue.PMS_TASKID + "'" +
                                       ", @mode = '" + _obj_primaryvalue.PMS_MODE + "'");
            }
        }
        #endregion

        #region kra's
        /// <summary>
        /// Method to Get KRA_ID Based on the mode
        /// </summary>
        /// <param name="_obj_keyresultarea"></param>
        /// <returns></returns>

        public static DataTable get_keyresult(pms_keyresultarea _obj_keyresultarea)
        {
            if (_obj_keyresultarea.KRA_MODE == 1)
            {
                return ExecuteQuery("EXEC [USP_SPMS_KEYRESULTAREAS]  @KRA_ID = " + _obj_keyresultarea.KRA_EMPLOYEEID +
                                    " , @mode = '" + _obj_keyresultarea.KRA_MODE + "'");
            }
            else
            {
                return ExecuteQuery("EXEC[USP_SPMS_KEYRESULTAREAS] @MODE = '2', @KRA_ID = " + _obj_keyresultarea.KRA_EMPLOYEEID + "");
            }
        }
        /// <summary>
        ///  Method to Insert or update into thepms_keyresultarea table Using Information Passed using the Object
        /// </summary>
        /// <param name="_obj_keyresultarea"></param>
        /// <returns></returns>
        public static bool set_keyresult(pms_keyresultarea _obj_keyresultarea)
        {
            if (_obj_keyresultarea.KRA_MODE == 3)
            {
                return ExecuteNonQuery(" EXEC [USP_SPMS_KEYRESULTAREAS] @KRA_ID  = '" + _obj_keyresultarea.KRA_EMPLOYEEID + "'" +
                                       ", @KRA_NAME = '" + Convert.ToString(_obj_keyresultarea.KRA_EMPLOYEENAME) + "'" +
                                        ", @KRA_DESCRIPTION = '" + Convert.ToString(_obj_keyresultarea.KRA_DESCRIPTION) + "'" +
                                        ", @KRA_CODE = '" + Convert.ToString(_obj_keyresultarea.KRA_CODE) + "'" +
                                        ", @KRA_STARTDATE  = '" + Convert.ToDateTime(_obj_keyresultarea.STARTDATE).ToString("MM/dd/yyyy") + "'" +
                                       ", @KRA_ENDDATE  = " + (_obj_keyresultarea.ENDDATE == null ? "null" : "'" + Convert.ToDateTime(_obj_keyresultarea.ENDDATE).ToString("MM/dd/yyyy") + "'") +
                                       ", @KRA_INDICATOR = '" + Convert.ToString(_obj_keyresultarea.KRA_INDICATOR) + "'" +
                                       ", @KRA_MANAGERSERVICE_ID = '" + Convert.ToString(_obj_keyresultarea.KRA_MANAGERSERVICEID) + "'" +
                                       ", @KRA_EMP_ID = '" + Convert.ToString(_obj_keyresultarea.KRA_ID) + "'" +
                                       ", @MODE = '" + _obj_keyresultarea.KRA_MODE + "'");
            }
            else if (_obj_keyresultarea.KRA_MODE == 4)
            {
                return ExecuteNonQuery("EXEC [USP_SPMS_KEYRESULTAREAS] @KRA_ID  = '" + _obj_keyresultarea.KRA_EMPLOYEEID + "'" +
                                      ", @KRA_NAME = '" + Convert.ToString(_obj_keyresultarea.KRA_EMPLOYEENAME) + "'" +
                                        ", @KRA_DESCRIPTION = '" + Convert.ToString(_obj_keyresultarea.KRA_DESCRIPTION) + "'" +
                                        ", @KRA_CODE = '" + Convert.ToString(_obj_keyresultarea.KRA_CODE) + "'" +
                                        ", @KRA_STARTDATE  = '" + Convert.ToDateTime(_obj_keyresultarea.STARTDATE).ToString("MM/dd/yyyy") + "'" +
                                       ", @KRA_ENDDATE  = '" + Convert.ToDateTime(_obj_keyresultarea.ENDDATE).ToString("MM/dd/yyyy") + "'" +
                                       ", @KRA_INDICATOR = '" + Convert.ToString(_obj_keyresultarea.KRA_INDICATOR) + "'" +
                                       ", @KRA_MANAGERSERVICE_ID = '" + Convert.ToString(_obj_keyresultarea.KRA_MANAGERSERVICEID) + "'" +
                                       ", @KRA_EMP_ID = '" + Convert.ToString(_obj_keyresultarea.KRA_ID) + "'" +
                                       ", @MODE = '" + _obj_keyresultarea.KRA_MODE + "'");
            }
            else
            {
                return ExecuteNonQuery(" EXEC [USP_SPMS_KEYRESULTAREAS] @KRA_ID= '" + _obj_keyresultarea.KRA_ID + "'" +
                                       ", @MODE = '" + _obj_keyresultarea.KRA_MODE + "'");
            }
        }

        #endregion

        #region pms mode
        /// <summary>
        ///  Method to Get pms_employeepmsmode Based on the MODE
        /// </summary>
        /// <param name="_obj_employeepmsmode"></param>
        /// <returns></returns>
        public static DataTable get_pmsmode(pms_employeepmsmode _obj_employeepmsmode)
        {
            if (_obj_employeepmsmode.PMS_MODE == 3)
            {
                return ExecuteQuery("EXEC [USP_PMSMODE] @EMP_PMSMODE_ID = '" + _obj_employeepmsmode.PMS_ID + "'" +
                                    ", @MODE = '" + _obj_employeepmsmode.PMS_MODE + "'");
            }
            else if (_obj_employeepmsmode.PMS_MODE == 2)
            {
                return ExecuteQuery("EXEC [USP_PMSMODE]  @MODE = '" + _obj_employeepmsmode.PMS_MODE + "',@EMP_PMSMODE_ID = '" + _obj_employeepmsmode.PMS_MODE + "'");
            }
            else
            {
                return ExecuteQuery("EXEC [USP_PMSMODE]  @MODE = '" + _obj_employeepmsmode.PMS_MODE + "'");
            }
        }
        /// <summary>
        ///  Method to Insert or update into the pms_employeepmsmode table Using Information Passed using the Object
        /// </summary>
        /// <param name="_obj_employeepmsmode"></param>
        /// <returns></returns>
        public static bool set_pmsmode(pms_employeepmsmode _obj_employeepmsmode)
        {
            if (_obj_employeepmsmode.PMS_MODE == 1)
            {
                return ExecuteNonQuery(" EXEC [USP_PMSMODE] @EMP_PMSMODE_ID  = '" + _obj_employeepmsmode.PMS_ID + "'" +
                                       ", @EMP_PMSMODE_BUSINESSUNIT = '" + _obj_employeepmsmode.PMS_BUSINESSUNIT + "'" +
                                       ",@EMP_PMSMODE_EMPLOYEENAME='" + _obj_employeepmsmode.PMS_EMPLOYEENAME + "'" +

                                       ", @EMP_PMSMODE_APPRAISE = '" + _obj_employeepmsmode.PMS_APPRAISEE + "'" +
                                        ", @EMP_PMSMODE_APPRAISER = '" + _obj_employeepmsmode.PMS_APPRAISER + "'" +
                                        ", @EMP_PMSMODE_REVIEWER = '" + _obj_employeepmsmode.PMS_REVIEWER + "'" +



                                       ", @EMP_PMSMODE_CREATEDBY = '" + _obj_employeepmsmode.CREATEDBY + "'" +
                                       ", @EMP_PMSMODE_CREATEDDATE = '" + _obj_employeepmsmode.CREATEDDATE.ToString("MM/dd/yyyy") + "'" +
                                       ", @EMP_PMSMODE_LASTMDF = '" + _obj_employeepmsmode.LASTMDFBY + "'" +
                                      " , @EMP_PMSMODE_LASTMDFDATE= " + (_obj_employeepmsmode.ENDDATE == null ? "null" : "'" + Convert.ToDateTime(_obj_employeepmsmode.ENDDATE).ToString("MM/dd/yyyy") + "'") +

                                       ", @MODE = '" + _obj_employeepmsmode.PMS_MODE + "'");
            }
            else if (_obj_employeepmsmode.PMS_MODE == 5)
            {
                return ExecuteNonQuery("EXEC [USP_PMSMODE] @EMP_PMSMODE_ID  = '" + _obj_employeepmsmode.PMS_ID + "'" +
                                       ", @EMP_PMSMODE_BUSINESSUNIT = '" + _obj_employeepmsmode.PMS_BUSINESSUNIT + "'" +
                                       ",@EMP_PMSMODE_EMPLOYEENAME='" + _obj_employeepmsmode.PMS_EMPLOYEENAME + "'" +
                                       ", @EMP_PMSMODE_APPRAISE = '" + _obj_employeepmsmode.PMS_APPRAISEE + "'" +
                                        ", @EMP_PMSMODE_APPRAISER = '" + _obj_employeepmsmode.PMS_APPRAISER + "'" +
                                        ", @EMP_PMSMODE_REVIEWER = '" + _obj_employeepmsmode.PMS_REVIEWER + "'" +
                                       ", @EMP_PMSMODE_CREATEDBY = '" + _obj_employeepmsmode.CREATEDBY + "'" +
                                       ", @EMP_PMSMODE_CREATEDDATE = '" + _obj_employeepmsmode.CREATEDDATE.ToString("MM/dd/yyyy") + "'" +
                                       ", @EMP_PMSMODE_LASTMDF = '" + _obj_employeepmsmode.LASTMDFBY + "'" +
                                      " , @EMP_PMSMODE_LASTMDFDATE= " + (_obj_employeepmsmode.ENDDATE == null ? "null" : "'" + Convert.ToDateTime(_obj_employeepmsmode.ENDDATE).ToString("MM/dd/yyyy") + "'") +

                                       ", @MODE = '" + _obj_employeepmsmode.PMS_MODE + "'");
            }
            else
            {
                return ExecuteNonQuery(" EXEC [USP_PMSMODE] @EMP_PMSMODE_ID= '" + _obj_employeepmsmode.PMS_ID + "'" +
                                       ", @MODE = '" + _obj_employeepmsmode.PMS_MODE + "'");
            }
        }

        #endregion

        #region Assigning roles to employee
        /// <summary>
        ///  Method to Get pms_employeepmsmode Based on the MODE
        /// </summary>
        /// <param name="_obj_employeepmsmode"></param>
        /// <returns></returns>
        public static DataTable get_mode(pms_ASSIGNINGROLES _obj_assigningroles)
        {
            if (_obj_assigningroles.PMS_MODE == 1)
            {
                return ExecuteQuery("EXEC [USP_ASSGN_EMP_ROLES]  @ASSGN_ROLE_ID = '" + _obj_assigningroles.ASSGN_ROLE_ID + "'" +
                                    ", @MODE = '" + _obj_assigningroles.PMS_MODE + "'");
            }
            else
            {
                return ExecuteQuery("EXEC [USP_ASSGN_EMP_ROLES]   @MODE = '" + _obj_assigningroles.PMS_MODE + "',@ASSGN_ROLE_ID = '" + _obj_assigningroles.ASSGN_ROLE_ID + "'");
            }
        }
        public static bool set_mode(pms_ASSIGNINGROLES _obj_assigningroles)
        {
            if (_obj_assigningroles.PMS_MODE == 3)
            {
                string str = " EXEC [USP_ASSGN_EMP_ROLES] @ASSGN_ROLE_ID  = '" + _obj_assigningroles.ASSGN_ROLE_ID + "'" +
                                       ",@ASSGN_BU_ID='" + _obj_assigningroles.ASSGN_BU_ID + "'" +
                                       ", @ASSGN_EMP_ID= '" + _obj_assigningroles.ASSGN_EMP_ID + "'" +
                                        ", @ASSGN_ROLE = '" + _obj_assigningroles.ASSGN_ROLE + "'" +
                                        ", @ASSGN_CREATEDBY = '" + Convert.ToInt32(_obj_assigningroles.CREATEDBY) + "'" +
                                        ", @ASSGN_CREATEDDATE = '" + (_obj_assigningroles.CREATEDDATE) + "'" +
                                       ",@ASSGN_LASTMDFBY = '" + Convert.ToInt32(_obj_assigningroles.LASTMDFBY) + "'" +
                                       ", @ASSGN_LASTMDFDATE = '" + (_obj_assigningroles.LASTMDFDATE) + "'" +
                                       ", @MODE = '" + _obj_assigningroles.PMS_MODE + "'";
                return ExecuteNonQuery(str);
            }
            else if (_obj_assigningroles.PMS_MODE == 4)
            {
                return ExecuteNonQuery("EXEC [USP_ASSGN_EMP_ROLES]  @ASSGN_ROLE_ID  = '" + _obj_assigningroles.ASSGN_ROLE_ID + "'" +
                                       ",@ASSGN_BU_ID='" + _obj_assigningroles.ASSGN_BU_ID + "'" +
                                       ", @ASSGN_EMP_ID= '" + _obj_assigningroles.ASSGN_EMP_ID + "'" +
                                        ", @ASSGN_ROLE = '" + _obj_assigningroles.ASSGN_ROLE + "'" +
                                       ", @ASSGN_LASTMDFBY = '" + Convert.ToInt32(_obj_assigningroles.LASTMDFBY) + "'" +
                                         ", @ASSGN_LASTMDFDATE = '" + (_obj_assigningroles.LASTMDFDATE) + "'" +
                                       ", @MODE = '" + _obj_assigningroles.PMS_MODE + "'");
            }
            else
            {
                return ExecuteNonQuery(" EXEC [USP_ASSGN_EMP_ROLES] @ASSGN_ROLE_ID= '" + _obj_assigningroles.ASSGN_ROLE_ID + "'" +
                                       ", @MODE = '" + _obj_assigningroles.PMS_MODE + "'");
            }
            //        if (ExecuteNonQuery("EXEC USP_ASSGN_KRA @MODE = 4 , @ASSGNKRA_ID=" + Convert.ToString(_obj_Pms_AssigningKra.ASSGNKRA_ID)
            //               + ", @ASSGNKRA_KRA_ID = " + Convert.ToString(_obj_Pms_AssigningKra.ASSGNKRA_KRA_ID) +
            //              " ,@ASSGNKRA_BUID = " + Convert.ToString(_obj_Pms_AssigningKra.ASSGNKRA_BUID) +
            //              " , @ASSGNKRA_EMP_ID = " + Convert.ToString(_obj_Pms_AssigningKra.ASSGNKRA_EMP_ID) +
            //              " , @ASSGNKRA_MGR_ID = " + Convert.ToString(_obj_Pms_AssigningKra.ASSGNKRA_MGR_ID) +
            //              " ,@ASSGNKRA_LASTMDFBY = " + Convert.ToInt32(_obj_Pms_AssigningKra.ASSGNKRA_LASTMDFBY) +
            //              ", @ASSGNKRA_LASTMDFDATE= '" + Convert.ToDateTime(_obj_Pms_AssigningKra.ASSGNKRA_LASTMDFDATE).ToString("MM/dd/yyyy") + "'"))
            //status = true;

        }
        #endregion

        #region roles of employee
        public static DataTable get_roles(PMS_BINDROLES _obj_roles)
        {
            if (_obj_roles.MODE == 1)
            {
                return ExecuteQuery("EXEC [USP_PMS_ROLES]  @ROLE_ID = '" + _obj_roles.role_id + "'" +
                                    ", @MODE = '" + _obj_roles.MODE + "'");
            }
          

        else  if (_obj_roles.MODE == 8)
            {
                return ExecuteQuery("EXEC [USP_PMS_ROLES]  @ROLE_BUSINESSUNIT_ID = '" + _obj_roles.BUID + "'" +
                                    ",@ROLES_ORG_ID = '" + _obj_roles.CREATEDBY + "'" +
                                    ", @MODE = '" + _obj_roles.MODE + "'");
            }
          else
          {
              return ExecuteQuery("EXEC [USP_PMS_ROLES]   @MODE = '" + _obj_roles.MODE + "',@ROLE_ID = '" + _obj_roles.role_id + "'");
          }
        }
        #endregion

        #region taskmanagement
        public static DataTable get_taskmanagement(pms_TaskManagement _obj_taskmanagement)
        {
            if (_obj_taskmanagement.PMS_MODE == 1)
            {
                return ExecuteQuery("EXEC [USP_SPMS_TASKDETAILS] @TASKDETAILS_ID = '" + _obj_taskmanagement.PMS_TASKDETAILS_ID + "'" +
                                    ", @MODE = '" + _obj_taskmanagement.PMS_MODE + "'");
            }
            else
            {
                return ExecuteQuery("EXEC[USP_SPMS_TASKDETAILS] @mode = '" + _obj_taskmanagement.PMS_MODE + "'");
            }

        }
        public static bool set_taskmanagement(pms_TaskManagement _obj_taskmanagement)
        {
            if (_obj_taskmanagement.PMS_MODE == 3)
            {
                return ExecuteNonQuery(" EXEC [USP_SPMS_TASKDETAILS] @TASKDETAILS_NAME  = '" + _obj_taskmanagement.PMS_TASKNAME + "'" +
                                       ", @TASKDETAILS_DESC = '" + _obj_taskmanagement.PMS_TASKDESC + "'" +
                                       ", @TASKDETAILS_CODE = '" + _obj_taskmanagement.PMS_TASKCODE + "'" +
                                        ", @TASKDETAILS_SEVERITY = '" + _obj_taskmanagement.PMS_SEVERITY + "'" +
                                         ", @TASKDETAILS_STATUS = '" + _obj_taskmanagement.PMS_STATUS + "'" +

                                       ", @TASKDETAILS_ASSIGNEDDATE = '" + Convert.ToDateTime(_obj_taskmanagement.PMS_ASSIGNEDDATE) + "'" +
                                       ", @TASKDETAILS_ESTIMATEDTIME = '" + Convert.ToDateTime(_obj_taskmanagement.PMS_ESTIMATEDTIME) + "'" +
                    //", @TASKDETAILS_ESTIMATEDTIME  = " + (_obj_primaryvalue.PMS_ESTIMATEDTIME == null ? "null" : "'" + Convert.ToDateTime(_obj_primaryvalue.PMS_ESTIMATEDTIME).ToString("MM/dd/yyyy") + "'") +
                                       ", @TASKDETAILS_CREATEDBY = '" + _obj_taskmanagement.CREATEDBY + "'" +
                                       ", @TASKDETAILS_CREATEDDATE = '" + _obj_taskmanagement.CREATEDDATE.ToString("MM/dd/yyyy") + "'" +

                                       ", @TASKDETAILS_MANAGERSERVICE_ID = '" + _obj_taskmanagement.PMS_TASKDETAILSMANAGERSERVICEID + "'" +
                                       ", @TASKDETAILS_EMP_ID = '" + _obj_taskmanagement.PMS_EmployeeName + "'" +
                                       ", @mode = '" + _obj_taskmanagement.PMS_MODE + "'");
            }
            else if (_obj_taskmanagement.PMS_MODE == 5)
            {
                return ExecuteNonQuery(" EXEC [USP_SPMS_TASKDETAILS] @TASKDETAILS_NAME= '" + _obj_taskmanagement.PMS_TASKNAME + "'" +
                                    ", @TASKDETAILS_DESC  = '" + _obj_taskmanagement.PMS_TASKDESC + "'" +
                                    ", @TASKDETAILS_CODE = '" + _obj_taskmanagement.PMS_TASKCODE + "'" +
                                        ", @TASKDETAILS_SEVERITY = '" + _obj_taskmanagement.PMS_SEVERITY + "'" +
                                         ", @TASKDETAILS_STATUS = '" + _obj_taskmanagement.PMS_STATUS + "'" +
                                    ", @TASKDETAILS_ASSIGNEDDATE= '" + _obj_taskmanagement.PMS_ASSIGNEDBY + "'" +
                    //", @TASKDETAILS_ESTIMATEDTIME = '" + _obj_primaryvalue.PMS_ASSIGNEDTIME + "'" +
                                     ", @TASKDETAILS_ESTIMATEDTIME  = " + (_obj_taskmanagement.PMS_ESTIMATEDTIME == null ? "null" : "'" + Convert.ToDateTime(_obj_taskmanagement.PMS_ESTIMATEDTIME).ToString("MM/dd/yyyy") + "'") +
                    //", @TASKDETAILS_ESTIMATEDTIME  = " + (_obj_primaryvalue.PMS_ESTIMATEDTIME == null ? "null" : "'" + Convert.ToDateTime(_obj_primaryvalue.PMS_ESTIMATEDTIME).ToString("MM/dd/yyyy") + "'") +
                                    ", @TASKDETAILS_CREATEDBY = '" + _obj_taskmanagement.CREATEDBY + "'" +
                                    ", @TASKDETAILS_CREATEDDATE = '" + _obj_taskmanagement.CREATEDDATE.ToString("MM/dd/yyyy") + "'" +
                                    ", @TASKDETAILS_LASTMDFBY  = '" + _obj_taskmanagement.LASTMDFBY + "'" +
                                    ", @TASKDETAILS_LASTMDFDATE = '" + _obj_taskmanagement.LASTMDFDATE.ToString("MM/dd/yyyy") + "'" +
                                    ", @TASKDETAILS_MANAGERSERVICE_ID = '" + _obj_taskmanagement.PMS_TASKDETAILSMANAGERSERVICEID + "'" +
                                       ", @TASKDETAILS_EMP_ID = '" + _obj_taskmanagement.PMS_TASKDETAILS_EMP_ID + "'" +

                                    ", @mode = '" + _obj_taskmanagement.PMS_MODE + "'");
            }
            else
            {
                return ExecuteNonQuery(" EXEC [USP_SPMS_TASKDETAILS] @TASKDETAILS_ID = '" + _obj_taskmanagement.PMS_TASKDETAILS_ID + "'" +
                                       ", @mode = '" + _obj_taskmanagement.PMS_MODE + "'");
            }
        }
        #endregion

        #region  Kraform 10-05-2010
        public static DataTable get_kra(pms_kraform _obj_kra)
        {
            if (_obj_kra.KRA_MODE == 1)
            {
                return ExecuteQuery("EXEC [USP_PMS_KRA]  @KRA_ID = " + _obj_kra.KRA_ID +
                                    " ,@KRA_ORG_ID = " + _obj_kra.KRA_ORG_ID +
                                    " , @mode = '" + _obj_kra.KRA_MODE + "',@EMP_LOGIN_ID = '" + _obj_kra.LOGIN_ID + "'");
            }
            else if (_obj_kra.KRA_MODE == 5)
            {
                return ExecuteQuery("EXEC [USP_PMS_KRA]  @KRA_Description = '" + _obj_kra.KRA_DESCRIPTION + "',@mode = '" + _obj_kra.KRA_MODE + "'");
            }
            else if (_obj_kra.KRA_MODE == 6)
            {
                return ExecuteQuery("EXEC [USP_PMS_KRA]  @KRA_NAME = '" + _obj_kra.KRA_NAME + "',@mode = '" + _obj_kra.KRA_MODE + "'");
            }
            else if (_obj_kra.KRA_MODE == 7)
            {
                return ExecuteQuery("EXEC [USP_PMS_KRA]  @KRA_NAME = '" + _obj_kra.KRA_NAME + "',@KRA_BU_ID  = '" + _obj_kra.BU_ID + "'" +
                                       ",@KRA_ORG_ID = " + _obj_kra.KRA_ORG_ID +
                                    ",@mode = '" + _obj_kra.KRA_MODE + "'");
            }
            else if (_obj_kra.KRA_MODE == 9)
            {
                return ExecuteQuery("EXEC [USP_PMS_KRA]  @KRA_ORG_ID = '" + _obj_kra.KRA_ORG_ID + "',@mode = '" + _obj_kra.KRA_MODE + "',@EMP_LOGIN_ID='" + _obj_kra.LOGIN_ID + "'");
            }
            else
            {
                return ExecuteQuery("EXEC [USP_PMS_KRA] @MODE = '2', @KRA_ID = " + _obj_kra.KRA_ID + "");
            }

        }
        public static bool set_kra(pms_kraform _obj_kra)
        {
            if (_obj_kra.KRA_MODE == 3)
            {
                return ExecuteNonQuery(" EXEC [USP_PMS_KRA] @KRA_ID  = '" + _obj_kra.KRA_ID + "'" +
                                       ", @KRA_NAME = '" + Convert.ToString(_obj_kra.KRA_NAME) + "'" +
                                        ", @KRA_DESCRIPTION = '" + Convert.ToString(_obj_kra.KRA_DESCRIPTION) + "'" +
                    //", @KRA_MEASURE = '" + Convert.ToString(_obj_kra.KRA_MEASURE) + "'" +
                                         ",@KRA_ORG_ID = " + _obj_kra.KRA_ORG_ID +
                                    ", @KRA_CREATEDBY = '" + _obj_kra.CREATEDBY + "'" +
                                    ", @KRA_CREATEDDATE = '" + _obj_kra.CREATEDDATE.ToString("MM/dd/yyyy") + "'" +
                                    ", @KRA_LASTMDFBY  = '" + _obj_kra.LASTMDFBY + "'" +
                                    ", @KRA_LASTMDFDATE = '" + _obj_kra.LASTMDFDATE.ToString("MM/dd/yyyy") + "'" +
                                    ", @KRA_ORGANISATION_ID = '" + Convert.ToString(_obj_kra.KRA_ORGANISATION_ID) + "'" +
                                    ",@KRA_BU_ID  = '" + _obj_kra.BU_ID + "'" +
                                       ", @MODE = '" + _obj_kra.KRA_MODE + "'" +
                                       ",@KRA_STATUS = '" + _obj_kra.KRA_STATUS +
                    //"',@KRA_KRAID= '" + _obj_kra.KRA_KRAID + 
                                       "'");
            }
            else if (_obj_kra.KRA_MODE == 4)
            {
                return ExecuteNonQuery("EXEC [USP_PMS_KRA] @KRA_ID  = '" + _obj_kra.KRA_ID + "'" +
                                        ", @KRA_NAME = '" + Convert.ToString(_obj_kra.KRA_NAME) + "'" +
                                         ", @KRA_DESCRIPTION = '" + Convert.ToString(_obj_kra.KRA_DESCRIPTION) + "'" +
                    //", @KRA_MEASURE = '" + Convert.ToString(_obj_kra.KRA_MEASURE) + "'" +
                    //     ", @KRA_CREATEDBY = '" + _obj_kra.CREATEDBY + "'" +
                    //", @KRA_CREATEDDATE = '" + _obj_kra.CREATEDDATE.ToString("MM/dd/yyyy") + "'" +
                                     ", @KRA_LASTMDFBY  = '" + _obj_kra.LASTMDFBY + "'" +
                                     ", @KRA_LASTMDFDATE = '" + _obj_kra.LASTMDFDATE.ToString("MM/dd/yyyy") + "'" +
                                     ", @KRA_ORGANISATION_ID = '" + Convert.ToString(_obj_kra.KRA_ORGANISATION_ID) + "'" +
                                     ",@KRA_BU_ID  = '" + _obj_kra.BU_ID + "'" +
                                       ", @MODE = '" + _obj_kra.KRA_MODE +
                                       "',@KRA_STATUS = '" + _obj_kra.KRA_STATUS +
                    //"',@KRA_KRAID= '" + _obj_kra.KRA_KRAID + 
                                       "'");

            }
            else if (_obj_kra.KRA_MODE == 10)
            {
                return ExecuteNonQuery("EXEC USP_PMS_KRA @MODE = '" + _obj_kra.KRA_MODE + 
                                        "',@KRA_ID = '" + _obj_kra.KRA_ID +
                                        "', @KRA_STATUS = '" + _obj_kra.KRA_STATUS +
                                        "',@KRA_LASTMDFBY = '" + _obj_kra.LASTMDFBY + "'");
            }

            return true;

        }
        #endregion

        #region PMS-Competencies

        public static DataTable get_cmp(PMS_CMP _obj_cmp)
        {
            if (_obj_cmp.OPERATION == operation.Select)
            {
                return ExecuteQuery("EXEC [USP_PMS_CMP] @OPERATION = 'Select', @CMP_ORG_ID = '" + _obj_cmp.CMP_ORG_ID + "',@CMP_BU_ID = '" + _obj_cmp.CMP_BU_ID + "',@EMP_LOGIN_ID = '" + _obj_cmp.LOGIN_ID + "'");
            }           
            else if (_obj_cmp.OPERATION == operation.Get)
            {
                return ExecuteQuery("EXEC [USP_PMS_CMP] @OPERATION = 'Get', @CMP_ID = '" + _obj_cmp.CMP_ID + "'");
            }
            else if (_obj_cmp.OPERATION == operation.Check)
            {
                return ExecuteQuery("EXEC [USP_PMS_CMP] @OPERATION = 'Check', @CMP_NAME = '" + _obj_cmp.CMP_NAME + "', @CMP_ORG_ID = '" + _obj_cmp.CMP_ORG_ID + "',@CMP_BU_ID = '" + _obj_cmp.CMP_BU_ID + "'");
            }
            else if (_obj_cmp.OPERATION == operation.Select_New)
            {
                //To fetch cmp details
                return ExecuteQuery("EXEC [USP_PMS_CMP] @Operation ='" + _obj_cmp.OPERATION + "', @CMP_ORG_ID = " + _obj_cmp.CMP_ORG_ID + ", @CMP_BU_ID =" + _obj_cmp.CMP_BU_ID);
            }
            else
            {
                return ExecuteQuery("EXEC [USP_PMS_CMP] @OPERATION = 'Get', @CMP_ID = " + _obj_cmp.CMP_ID + " ,@CMP_ORG_ID = '" + _obj_cmp.CMP_ORG_ID + "',@CMP_BU_ID = '" + _obj_cmp.CMP_BU_ID + "'");
            }
          

        }
        public static bool set_cmp(PMS_CMP _obj_cmp)
        {
            if (_obj_cmp.OPERATION == operation.Insert)
            {
                return ExecuteNonQuery(" EXEC [USP_PMS_CMP] @OPERATION = 'Insert', @CMP_ID  = '" + _obj_cmp.CMP_ID + "'" +
                                       ", @CMP_NAME = '" + Convert.ToString(_obj_cmp.CMP_NAME) + "'" +
                                        ", @CMP_DESCRIPTION = '" + Convert.ToString(_obj_cmp.CMP_DESCRIPTION) + "'" +
                                         ",@CMP_ORG_ID = " + _obj_cmp.CMP_ORG_ID +
                                    ", @CMP_CREATEDBY = '" + _obj_cmp.CREATEDBY + "'" +
                                    ", @CMP_CREATEDDATE = '" + _obj_cmp.CREATEDDATE.ToString("MM/dd/yyyy") + "'" +
                                    ", @CMP_LASTMDFDBY  = '" + _obj_cmp.LASTMDFBY + "'" +
                                    ", @CMP_LASTMDFDATE = '" + _obj_cmp.LASTMDFDATE.ToString("MM/dd/yyyy") + "'" +
                                    ",@CMP_BU_ID  = '" + _obj_cmp.CMP_BU_ID + "'" +
                                    ",@CMP_STATUS = '" + _obj_cmp.CMP_STATUS + "'"); 
            }
            else if (_obj_cmp.OPERATION == operation.Update)
            {
                return ExecuteNonQuery("EXEC [USP_PMS_CMP]  @OPERATION = 'Update', @CMP_ID  = '" + _obj_cmp.CMP_ID + "'" +
                                ", @CMP_NAME = '" + Convert.ToString(_obj_cmp.CMP_NAME) + "'" +
                                        ", @CMP_DESCRIPTION = '" + Convert.ToString(_obj_cmp.CMP_DESCRIPTION) + "'" +
                                         ",@CMP_ORG_ID = " + _obj_cmp.CMP_ORG_ID +
                    // ", @CMP_CREATEDBY = '" + _obj_cmp.CREATEDBY + "'" +
                    //", @CMP_CREATEDDATE = '" + _obj_cmp.CREATEDDATE.ToString("MM/dd/yyyy") + "'" +
                                    ", @CMP_LASTMDFDBY  = '" + _obj_cmp.LASTMDFBY + "'" +
                                    ", @CMP_LASTMDFDATE = '" + _obj_cmp.LASTMDFDATE.ToString("MM/dd/yyyy") + "'" +
                                    ",@CMP_BU_ID  = '" + _obj_cmp.CMP_BU_ID + "'" +                              
                                       ",@CMP_STATUS = '" + _obj_cmp.CMP_STATUS + "'");

            }
            //else if (_obj_kra.KRA_MODE == 10)
            //{
            //    return ExecuteNonQuery("EXEC USP_PMS_KRA @MODE = '" + _obj_kra.KRA_MODE +
            //                            "',@KRA_ID = '" + _obj_kra.KRA_ID +
            //                            "', @KRA_STATUS = '" + _obj_kra.KRA_STATUS +
            //                            "',@KRA_LASTMDFBY = '" + _obj_kra.LASTMDFBY + "'");
            //}

            return true;

        }
        #endregion

        #region PMS - Values
        public static DataTable get_vals(PMS_VALUES _obj_vals)
        {
            if (_obj_vals.OPERATION == operation.Select)
            {
                return ExecuteQuery("EXEC [USP_PMS_VALUES] @OPERATION = 'Select', @VAL_ORG_ID = '" + _obj_vals.VAL_ORG_ID + "'");
            }
            else if (_obj_vals.OPERATION == operation.Check)
            {
                return ExecuteQuery("EXEC [USP_PMS_VALUES] @OPERATION = 'Check', @VAL_NAME = " + _obj_vals.VAL_NAME + ", @VAL_ORG_ID = '" + _obj_vals.VAL_ORG_ID + "'");
            }
            else
            {
                return ExecuteQuery("EXEC [USP_PMS_VALUES] @OPERATION = 'Get', @VAL_ID = " + _obj_vals.VAL_ID + " ,@VAL_ORG_ID = '" + _obj_vals.VAL_ORG_ID + "'");
            }


        }
        public static bool set_vals(PMS_VALUES _obj_vals)
        {
            if (_obj_vals.OPERATION == operation.Insert)
            {
                return ExecuteNonQuery(" EXEC [USP_PMS_VALUES] @OPERATION = 'Insert', @VAL_ID  = '" + _obj_vals.VAL_ID + "'" +
                                       ", @VAL_NAME = '" + Convert.ToString(_obj_vals.VAL_NAME) + "'" +
                                        ", @VAL_DESCRIPTION = '" + Convert.ToString(_obj_vals.VAL_DESCRIPTION) + "'" +
                                         ",@VAL_ORG_ID = " + _obj_vals.VAL_ORG_ID +
                                    ", @VAL_CREATEDBY = '" + _obj_vals.CREATEDBY + "'" +
                                    ", @VAL_CREATEDDATE = '" + _obj_vals.CREATEDDATE.ToString("MM/dd/yyyy") + "'" +
                                    ", @VAL_LASTMDFDBY  = '" + _obj_vals.LASTMDFBY + "'" +
                                    ", @VAL_LASTMDFDATE = '" + _obj_vals.LASTMDFDATE.ToString("MM/dd/yyyy") + "'" +
                                    ",@VAL_BU_ID  = '" + _obj_vals.VAL_BU_ID + "'" +
                                       ",@VAL_STATUS = '" + _obj_vals.VAL_STATUS + "'");
            }
            else if (_obj_vals.OPERATION == operation.Update)
            {
                return ExecuteNonQuery("EXEC [USP_PMS_VALUES]  @OPERATION = 'Update', @VAL_ID  = '" + _obj_vals.VAL_ID + "'" +
                                ", @VAL_NAME = '" + Convert.ToString(_obj_vals.VAL_NAME) + "'" +
                                        ", @VAL_DESCRIPTION = '" + Convert.ToString(_obj_vals.VAL_DESCRIPTION) + "'" +
                                         ",@VAL_ORG_ID = " + _obj_vals.VAL_ORG_ID +
                    // ", @CMP_CREATEDBY = '" + _obj_vals.CREATEDBY + "'" +
                    //", @CMP_CREATEDDATE = '" + _obj_vals.CREATEDDATE.ToString("MM/dd/yyyy") + "'" +
                                    ", @VAL_LASTMDFDBY  = '" + _obj_vals.LASTMDFBY + "'" +
                                    ", @VAL_LASTMDFDATE = '" + _obj_vals.LASTMDFDATE.ToString("MM/dd/yyyy") + "'" +
                                    ",@VAL_BU_ID  = '" + _obj_vals.VAL_BU_ID + "'" +
                                       ",@VAL_STATUS = '" + _obj_vals.VAL_STATUS + "'");

            }
            //else if (_obj_kra.KRA_MODE == 10)
            //{
            //    return ExecuteNonQuery("EXEC USP_PMS_KRA @MODE = '" + _obj_kra.KRA_MODE +
            //                            "',@KRA_ID = '" + _obj_kra.KRA_ID +
            //                            "', @KRA_STATUS = '" + _obj_kra.KRA_STATUS +
            //                            "',@KRA_LASTMDFBY = '" + _obj_kra.LASTMDFBY + "'");
            //}

            return true;

        }
        #endregion
        #region Idp SCREEN
        public static DataTable get_idp(pms_IDPSCREEN _obj_idp)
        {
            if (_obj_idp.IDP_MODE == 1)
            {
                return ExecuteQuery("EXEC [USP_PMS_IDP]  @IDP_ID = " + _obj_idp.IDP_ID +
                                    " ,@IDP_ORGANISATION_ID = " + _obj_idp.IDP_ORGANISATION_ID +
                                    " , @mode = '" + _obj_idp.IDP_MODE + "',@EMP_LOGIN_ID ='" + _obj_idp.LOGIN_ID + "'");
            }
            else if (_obj_idp.IDP_MODE == 6)
            {
                return ExecuteQuery("EXEC [USP_PMS_IDP]  @IDP_EMP_ID = " + _obj_idp.IDP_EMP_ID +
                                    " ,@IDP_ORGANISATION_ID = " + _obj_idp.IDP_ORGANISATION_ID +
                                    " , @mode = '" + _obj_idp.IDP_MODE + "'");
            }
            else if (_obj_idp.IDP_MODE == 7)
            {
                //return ExecuteQuery("EXEC [USP_PMS_IDP]  @IDP_NAME = '" + Convert.ToString(_obj_idp.IDP_NAME) + "'" +
                //                        " ,@IDP_EMP_ID = " + _obj_idp.IDP_EMP_ID +
                //                    "  ,@IDP_ORGANISATION_ID = " + _obj_idp.IDP_ORGANISATION_ID +
                //                    " , @mode = '" + _obj_idp.IDP_MODE + "'");
                return ExecuteQuery("EXEC [USP_PMS_IDP]  @IDP_ID = " + _obj_idp.IDP_ID +
                                    " , @IDP_ORGANISATION_ID = " + _obj_idp.IDP_ORGANISATION_ID +
                                    " , @mode =" + _obj_idp.IDP_MODE);
            }
            else if (_obj_idp.IDP_MODE == 8)
            {
                return ExecuteQuery("EXEC [USP_PMS_IDP] @IDP_EMP_ID = " + _obj_idp.IDP_EMP_ID +
                                    "  ,@IDP_ORGANISATION_ID = " + _obj_idp.IDP_ORGANISATION_ID +
                                    " , @mode = " + _obj_idp.IDP_MODE +
                                    " , @IDP_BU_ID =" + _obj_idp.IDP_BU_ID);
            }
            else if (_obj_idp.IDP_MODE == 9)
            {
                return ExecuteQuery("EXEC [USP_PMS_IDP] @IDP_EMP_ID = " + _obj_idp.IDP_EMP_ID +
                                    "  ,@IDP_ORGANISATION_ID = " + _obj_idp.IDP_ORGANISATION_ID +
                                    " , @mode = '" + _obj_idp.IDP_MODE + "'");
            }
            else if (_obj_idp.IDP_MODE == 3)
            {
                return ExecuteQuery("EXEC [USP_PMS_IDP]  @IDP_EMP_ID = " + _obj_idp.IDP_EMP_ID +
                                    " ,@IDP_ORGANISATION_ID = " + _obj_idp.IDP_ORGANISATION_ID +
                                    ", @mode = '" + _obj_idp.IDP_MODE + "'");
            }
            else if (_obj_idp.IDP_MODE == 10)
            {
                return ExecuteQuery("EXEC [USP_PMS_IDP] @IDP_ORGANISATION_ID = " + _obj_idp.IDP_ORGANISATION_ID +
                                    " ,@IDP_NAME = '" + _obj_idp.IDP_NAME +
                                    "' ,@mode = '" + _obj_idp.IDP_MODE + "'");
            }
            else if (_obj_idp.IDP_MODE == 11)
            {
                return ExecuteQuery("EXEC [USP_PMS_IDP] @IDP_ORGANISATION_ID = " + _obj_idp.IDP_ORGANISATION_ID + ", @mode = '" + _obj_idp.IDP_MODE + "', @IDP_BU_ID = " + _obj_idp.IDP_BU_ID + ",@EMP_LOGIN_ID ='" + _obj_idp.LOGIN_ID + "'");
            }           
            else
            {
                return ExecuteQuery("EXEC [USP_PMS_IDP] @MODE = '2', @IDP_ID = " + _obj_idp.IDP_ID + "");
            }
        }
        public static bool set_idp(pms_IDPSCREEN _obj_idp)
        {
            if (_obj_idp.IDP_MODE == 4)
            {
                return ExecuteNonQuery(" EXEC [USP_PMS_IDP] @IDP_ID  = '" + _obj_idp.IDP_ID + "'" +
                                      ", @IDP_BU_ID = '" + Convert.ToInt32(_obj_idp.IDP_BU_ID) + "'" +
                                       ", @IDP_NAME = '" + Convert.ToString(_obj_idp.IDP_NAME) + "'" +
                                        ", @IDP_DESCRIPTION = '" + Convert.ToString(_obj_idp.IDP_DESCRIPTION) + "'" +
                                       // ", @IDP_STARTDATE  =" + (_obj_idp.IDP_STARTDATE == null ? "null" : "'" + Convert.ToDateTime(_obj_idp.IDP_STARTDATE).ToString("MM/dd/yyyy") + "'") +
                                         //", @IDP_ENDDATE  = '" + Convert.ToDateTime(_obj_idp.IDP_ENDDATE).ToString("MM/dd/yyyy") + "'" +
                                        ", @IDP_COMMENTS = '" + Convert.ToString(_obj_idp.IDP_COMMENTS) + "'" +
                                         ", @IDP_CREATEDBY = '" + _obj_idp.CREATEDBY + "'" +
                                    ", @IDP_CREATEDDATE = '" + Convert.ToDateTime(_obj_idp.CREATEDDATE).ToString("MM/dd/yyyy") + "'" +
                                    ", @IDP_LASTMDFBY  = '" + _obj_idp.LASTMDFBY + "'" +
                                    ", @IDP_LASTMDFDATE = '" + Convert.ToDateTime(_obj_idp.LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
                                    ", @IDP_ORGANISATION_ID = '" + Convert.ToString(_obj_idp.IDP_ORGANISATION_ID) + "'" +
                                    ", @IDP_EMP_ID = '" + Convert.ToString(_obj_idp.IDP_EMP_ID) + "'" +
                                    ",@IDP_APPRAISALCYCLE = '" + Convert.ToString(_obj_idp.IDP_APPRAISALCYCLE) + "'" +
                                    ", @MODE = '" + _obj_idp.IDP_MODE + "'" +
                                    ", @IDP_STATUS = " + _obj_idp.IDP_STATUS);
            }
            else if (_obj_idp.IDP_MODE == 5)
            {
                return ExecuteNonQuery("EXEC [USP_PMS_IDP] @IDP_ID  = '" + _obj_idp.IDP_ID + "'" +
                                         ", @IDP_BU_ID = '" + Convert.ToInt32(_obj_idp.IDP_BU_ID) + "'" +
                                       ", @IDP_NAME = '" + Convert.ToString(_obj_idp.IDP_NAME) + "'" +
                                        ", @IDP_DESCRIPTION = '" + Convert.ToString(_obj_idp.IDP_DESCRIPTION) + "'" +
                                       //", @IDP_STARTDATE  = '" + Convert.ToDateTime(_obj_idp.IDP_STARTDATE).ToString("MM/dd/yyyy") + "'" +
                                         //", @IDP_ENDDATE  = '" + Convert.ToDateTime(_obj_idp.IDP_ENDDATE).ToString("MM/dd/yyyy") + "'" +
                                        ", @IDP_COMMENTS = '" + Convert.ToString(_obj_idp.IDP_COMMENTS) + "'" +
                    //     ", @IDP_CREATEDBY = '" + _obj_idp.CREATEDBY + "'" +
                    //", @IDP_CREATEDDATE = '" +Convert.ToDateTime(_obj_idp.CREATEDDATE).ToString("MM/dd/yyyy") + "'" +
                                    ", @IDP_LASTMDFBY  = '" + _obj_idp.LASTMDFBY + "'" +
                                    ", @IDP_LASTMDFDATE = '" + Convert.ToDateTime(_obj_idp.LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
                                    ", @IDP_ORGANISATION_ID = '" + Convert.ToString(_obj_idp.IDP_ORGANISATION_ID) + "'" +
                                    ",@IDP_APPRAISALCYCLE = '" + Convert.ToString(_obj_idp.IDP_APPRAISALCYCLE) + "'" +
                                    ", @IDP_STATUS = '" + _obj_idp.IDP_STATUS + "'" +
                                    ", @MODE = '" + _obj_idp.IDP_MODE + "'");

            }

            return true;

        }

        #endregion

        #region GoalSettings
        public static DataTable get_GS(PMS_GoalSettings _obj_GS)
        {
            if (_obj_GS.GS_MODE == 1)
            {
                return ExecuteQuery("EXEC [USP_GOAL_SETTING]  @GS_ID = " + _obj_GS.GS_ID +
                                    " , @mode = '" + _obj_GS.GS_MODE + "'");
            }
            else if (_obj_GS.GS_MODE == 6)
            {
                return ExecuteQuery("EXEC [USP_GOAL_SETTING] @MODE = '6', @GS_EMP_ID = " + _obj_GS.GS_EMP_ID + "" +
                                    ",@GS_APPRAISAL_CYCLE = '" + _obj_GS.GS_APPRAISAL_CYCLE + "'");
            }
            else if (_obj_GS.GS_MODE == 9)
            {
                return ExecuteQuery("EXEC [USP_GOAL_SETTING] @MODE = '9', @GS_EMP_ID = " + _obj_GS.GS_EMP_ID + "" +
                                     ",@GS_ORGANISATION_ID = " + _obj_GS.GS_ORGANISATION_ID + ",@GS_APPRAISAL_CYCLE = '" + _obj_GS.GS_APPRAISAL_CYCLE + "'");
            }
            else if (_obj_GS.GS_MODE == 7)
            {
                return ExecuteQuery("EXEC [USP_GOAL_SETTING] @MODE = '7', @GS_EMP_ID = " + _obj_GS.GS_EMP_ID + "");
            }
            else if (_obj_GS.GS_MODE == 2)
            {
                return ExecuteQuery("EXEC [USP_GOAL_SETTING] @MODE = '2', @GS_ID = " + _obj_GS.GS_ID + "");
            }
            else if (_obj_GS.GS_MODE == 12)
            {
                return ExecuteQuery("EXEC [USP_GOAL_SETTING] @MODE = '12'");
            }
            else if (_obj_GS.GS_MODE == 8)
            {
                return ExecuteQuery("EXEC [USP_GOAL_SETTING] @MODE = '8', @GS_EMP_ID = " + _obj_GS.GS_EMP_ID + "");
            }
            else if (_obj_GS.GS_MODE == 13)
            {
                return ExecuteQuery("EXEC [USP_GOAL_SETTING] @MODE = '13'");
            }
            else if (_obj_GS.GS_MODE == 17)
            {
                return ExecuteQuery("EXEC [USP_GOAL_SETTING] @MODE = '17',@EMPID = " + _obj_GS.EMPID + ",@GS_ORGANISATION_ID = " + _obj_GS.GS_ORGANISATION_ID + "");
            }

            else if (_obj_GS.GS_MODE == 21)
            {
                return ExecuteQuery("EXEC [USP_GOAL_SETTING] @MODE = '21', @GS_EMP_ID = " + _obj_GS.GS_EMP_ID + "" +
                                    ",@GS_ORGANISATION_ID = " + _obj_GS.GS_ORGANISATION_ID + ",@GS_APPRAISAL_CYCLE = '" + _obj_GS.GS_APPRAISAL_CYCLE + "'");
            }

            else if (_obj_GS.GS_MODE == 22)
            {
                return ExecuteQuery("EXEC [USP_GOAL_SETTING] @MODE = '22',@GS_ORGANISATION_ID = " + _obj_GS.GS_ORGANISATION_ID + ", @GS_EMP_ID = " + _obj_GS.GS_EMP_ID + "" +
                                    " ");
            }
            else if (_obj_GS.GS_MODE == 23)
            {
                return ExecuteQuery("EXEC [USP_GOAL_SETTING] @MODE = '23',@GS_ORGANISATION_ID = " + _obj_GS.GS_ORGANISATION_ID + " ,@GS_APPRAISAL_CYCLE=" + _obj_GS.GS_APPRAISAL_CYCLE + " ");
            }
            else if (_obj_GS.GS_MODE == 27)
            {
                return ExecuteQuery("EXEC [USP_GOAL_SETTING] @MODE = '27', @GSDTL_ORG_ID = " + _obj_GS.GS_ORGANISATION_ID + ", @GS_ID = " + _obj_GS.GS_ID + "");
            }
            else if (_obj_GS.GS_MODE == 28)
            {
                return ExecuteQuery("EXEC [USP_GOAL_SETTING] @MODE = '28', @GSDTL_ORG_ID = " + _obj_GS.GS_ORGANISATION_ID + ", @GS_ID = " + _obj_GS.GS_ID + ",@ROLEKRA_ID = " + _obj_GS.GS_ROLEKRA_ID + " ");
            }
            else if (_obj_GS.GS_MODE == 29)
            {
                return ExecuteQuery("EXEC [USP_GOAL_SETTING] @MODE = '29', @GSDTL_ORG_ID = " + _obj_GS.GS_ORGANISATION_ID + ", @GS_ID = " + _obj_GS.GS_ID + ",@ROLEKRA_ID = " + _obj_GS.GS_ROLEKRA_ID + " ");
            }
            else if (_obj_GS.GS_MODE == 30)//rajasekhar modified 11 dec
            {
                return ExecuteQuery("EXEC [USP_GOAL_SETTING] @MODE = '30', @GSDTL_ORG_ID = " + _obj_GS.GS_ORGANISATION_ID + ", @GS_ID = " + _obj_GS.GS_ID + ",@ROLEKRA_ID = " + _obj_GS.GS_ROLEKRA_ID + ",@GS_KRA_OBJ_ID="+_obj_GS.CREATEDBY+" ");
            }
            else if (_obj_GS.GS_MODE == 31)
            {
                return ExecuteQuery("EXEC [USP_GOAL_SETTING] @MODE = '31', @GS_ORGANISATION_ID = " + _obj_GS.GS_ORGANISATION_ID + ", @GS_APPRAISAL_CYCLE = " + _obj_GS.GS_APPRAISAL_CYCLE + ",@EMPID = " + _obj_GS.EMPID + " ");
            }
            else if (_obj_GS.GS_MODE == 33)
            {
                return ExecuteQuery("EXEC [USP_GOAL_SETTING] @MODE = '33', @GSDTL_ORG_ID = " + _obj_GS.GS_ORGANISATION_ID + ", @GS_ID = " + _obj_GS.GS_ID + "");
            }
            else if (_obj_GS.GS_MODE == 34)
            {
                return ExecuteQuery("EXEC [USP_GOAL_SETTING] @MODE = '34', @GS_APPRAISAL_CYCLE = " + _obj_GS.GS_APPRAISAL_CYCLE + ",@GS_EMP_ID = " + _obj_GS.GS_EMP_ID + ",@APPCYCLE='" + _obj_GS.BUID + "' ");
            }
            else if (_obj_GS.GS_MODE == 39)
            {
                return ExecuteQuery("EXEC [USP_GOAL_SETTING] @MODE = '39', @GS_APPRAISAL_CYCLE = " + _obj_GS.GS_APPRAISAL_CYCLE + ",@GS_EMP_ID = " + _obj_GS.GS_EMP_ID + ",@APPCYCLE='" + _obj_GS.BUID + "' ");
            }
            else if (_obj_GS.GS_MODE == 35)
            {
                return ExecuteQuery("EXEC [USP_GOAL_SETTING] @MODE = '35'");
            }
            else if (_obj_GS.GS_MODE == 37)
            {
                return ExecuteQuery("EXEC [USP_GOAL_SETTING] @MODE = '37', @GSDTL_ORG_ID = " + _obj_GS.GS_ORGANISATION_ID + ", @GS_ID = " + _obj_GS.GS_ID + "");
            }
            else if (_obj_GS.GS_MODE == 38)
            {
                return ExecuteQuery("EXEC [USP_GOAL_SETTING] @MODE = '38', @GSDTL_ORG_ID = " + _obj_GS.GS_ORGANISATION_ID + ", @GS_ID = " + _obj_GS.GS_ID + "");
            }
            else
            {
                return ExecuteQuery("EXEC [USP_GOAL_SETTING] @MODE = '18', @GSDTL_ORG_ID = " + _obj_GS.GS_ORGANISATION_ID + ", @GS_ID = " + _obj_GS.GS_ID + "");
            }



        }

        public static bool set_GS(PMS_GoalSettings _obj_GS)
        {
            if (_obj_GS.GS_MODE == 4)
            {
                return ExecuteNonQuery(" EXEC [USP_GOAL_SETTING] @GS_ID  = '" + _obj_GS.GS_ID + "'" +
                                       ", @GS_APPRAISAL_CYCLE = '" + Convert.ToInt32(_obj_GS.GS_APPRAISAL_CYCLE) + "'" +
                                        ", @GS_JOB_DESCRIPTION = '" + Convert.ToString(_obj_GS.GS_JOB_DESCRIPTION) + "'" +
                                        ",@GS_ROLENAME='" + Convert.ToString(_obj_GS.GS_ROLENAME) + "'" +
                                        ", @GS_PROJECT = '" + Convert.ToString(_obj_GS.GS_PROJECT) + "'" +
                                         ", @GS_CREATEDBY = '" + _obj_GS.CREATEDBY + "'" +
                                             ",@GS_STATUS='" + Convert.ToInt32(_obj_GS.GS_STATUS) + "'" +
                                    ", @GS_CREATEDDATE = '" + Convert.ToDateTime(_obj_GS.CREATEDDATE).ToString("MM/dd/yyyy") + "'" +
                                    ", @GS_LASTMDFBY  = '" + _obj_GS.LASTMDFBY + "'" +
                                    ", @GS_LASTMDFDATE = '" + Convert.ToDateTime(_obj_GS.LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
                                    ", @GS_ORGANISATION_ID = '" + Convert.ToString(_obj_GS.GS_ORGANISATION_ID) + "'" +
                                    ", @GS_EMP_ID = '" + Convert.ToString(_obj_GS.GS_EMP_ID) + "'" +
                                    ",@BU_ID ='"+Convert.ToInt32(_obj_GS.BUID)+"'"+
                                    ", @MODE = '" + _obj_GS.GS_MODE + "'");
            }
           
            else if (_obj_GS.GS_MODE == 5)
            {
                return ExecuteNonQuery("EXEC [USP_GOAL_SETTING] @GS_ID  = '" + _obj_GS.GS_ID + "'" +
                                       ", @GS_APPRAISAL_CYCLE = '" + Convert.ToInt32(_obj_GS.GS_APPRAISAL_CYCLE) + "'" +
                                        ", @GS_JOB_DESCRIPTION = '" + Convert.ToString(_obj_GS.GS_JOB_DESCRIPTION) + "'" +
                                        ",@GS_ROLENAME='" + Convert.ToString(_obj_GS.GS_ROLENAME) + "'" +
                                         ",@GS_STATUS='" + Convert.ToInt32(_obj_GS.GS_STATUS) + "'" +
                                          ", @GS_PROJECT = '" + Convert.ToString(_obj_GS.GS_PROJECT) + "'" +
                                       ", @GS_LASTMDFBY  = '" + _obj_GS.LASTMDFBY + "'" +
                                    ", @GS_LASTMDFDATE = '" + Convert.ToDateTime(_obj_GS.LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
                                    ", @GS_ORGANISATION_ID = '" + Convert.ToString(_obj_GS.GS_ORGANISATION_ID) + "'" +
                                    ", @GS_EMP_ID = '" + Convert.ToString(_obj_GS.GS_EMP_ID) + "'" +
                                    ", @MODE = '" + _obj_GS.GS_MODE + "'");

            }
            else if (_obj_GS.GS_MODE == 32)
            {
                return ExecuteNonQuery("EXEC [USP_GOAL_SETTING] @GS_ID  = '" + _obj_GS.GS_ID + "'" +
                                      ", @GS_APPRAISAL_CYCLE = '" + Convert.ToInt32(_obj_GS.GS_APPRAISAL_CYCLE) + "'" +
                                        ",@GS_STATUS='" + Convert.ToInt32(_obj_GS.GS_STATUS) + "'" +
                                      ", @GS_LASTMDFBY  = '" + _obj_GS.LASTMDFBY + "'" +
                                   ", @GS_ORGANISATION_ID = '" + Convert.ToString(_obj_GS.GS_ORGANISATION_ID) + "'" +
                                   ", @GS_EMP_ID = '" + Convert.ToString(_obj_GS.GS_EMP_ID) + "'" +
                                   ", @MODE = '" + _obj_GS.GS_MODE + "'");
            }
            else if (_obj_GS.GS_MODE == 20)
            {
                return ExecuteNonQuery("EXEC [USP_GOAL_SETTING]  @GS_APPRAISAL_CYCLE = '" + Convert.ToInt32(_obj_GS.GS_APPRAISAL_CYCLE) + "'" +
                                        ",  @MODE = '" + _obj_GS.GS_MODE + "'");

            }

            return true;

        }


        #endregion

        #region GOALS_SETTINGS_DETAILS
        public static DataTable get_GSdetails(PMS_GoalSettings_Details _obj_GSdetails)
        {
            if (_obj_GSdetails.GS_DETAILS_MODE == 5)
            {
                return ExecuteQuery("EXEC [USP_PMS_GOALSETTING_DETAIL]  @GSDTL_GS_ID = " + _obj_GSdetails.GSDTL_GS_ID +
                                    " , @GSDTL_ORG_ID = " + _obj_GSdetails.LASTMDFBY + ", @mode = '" + _obj_GSdetails.GS_DETAILS_MODE + "'");
            }
            else if (_obj_GSdetails.GS_DETAILS_MODE == 7)
            {
                return ExecuteQuery("EXEC [USP_PMS_GOALSETTING_DETAIL] @mode = '" + _obj_GSdetails.GS_DETAILS_MODE + "'");
            }

            else if (_obj_GSdetails.GS_DETAILS_MODE == 2)
            {
                return ExecuteQuery("EXEC [USP_PMS_GOALSETTING_DETAIL] @MODE = '2', @GSDTL_ID = " + _obj_GSdetails.GSDTL_ID + "");
            }
            else if (_obj_GSdetails.GS_DETAILS_MODE == 12)
            {
                return ExecuteQuery("EXEC [USP_PMS_GOALSETTING_DETAIL] @MODE = '12', @GSDTL_ORG_ID = " + _obj_GSdetails.LASTMDFBY + ", @GSDTL_GS_ID = " + _obj_GSdetails.GSDTL_GS_ID + "");
            }
            else if (_obj_GSdetails.GS_DETAILS_MODE == 11)
            {
                return ExecuteQuery("EXEC [USP_PMS_GOALSETTING_DETAIL] @MODE = '11', @GSDTL_GS_ID = " + _obj_GSdetails.GSDTL_GS_ID +
                                          ", @GSDTL_ORG_ID = " + _obj_GSdetails.LASTMDFBY +
                                          ", @GSDTL_DESCRIPTION = '" + Convert.ToString(_obj_GSdetails.GSDTL_DESCRIPTION) + "'" +
                                           ", @GSDTL_NAME = '" + Convert.ToString(_obj_GSdetails.GSDTL_NAME) + "'" +
                                           ", @GSDTL_CMP_ID = " + _obj_GSdetails.GSDTL_CMP_ID);
            }
            else if (_obj_GSdetails.GS_DETAILS_MODE == 13)
            {
                return ExecuteQuery("EXEC [USP_PMS_GOALSETTING_DETAIL] @MODE = '13', @GSDTL_NAME = '" + Convert.ToString(_obj_GSdetails.GSDTL_NAME) + "'" +
                                         ", @GSDTL_DESCRIPTION = '" + Convert.ToString(_obj_GSdetails.GSDTL_DESCRIPTION) + "'" +
                                         //", @GSDTL_MEASURE = '" + Convert.ToString(_obj_GSdetails.GSDTL_MEASURE) + "'" +
                                         //", @GSDTL_WEIGHTAGE = '" + Convert.ToString(_obj_GSdetails.GSDTL_WEIGHTAGE) + "'" +
                                         //" ,@GSDTL_TARGET = '" + Convert.ToString(_obj_GSdetails.GSDTL_TARGET) + "'" +
                                         //",@GSDTL_TIMELINES = '" + Convert.ToDateTime(_obj_GSdetails.GSDTL_TIMELINES).ToString("MM/dd/yyyy") + "'" +
                                      ", @GSDTL_GS_ID = " + _obj_GSdetails.GSDTL_GS_ID);
            }
            else 
            {
                return ExecuteQuery("EXEC [USP_PMS_GOALSETTING_DETAIL] @MODE = '8', @GSDTL_GS_ID = " + _obj_GSdetails.GSDTL_GS_ID +
                                                                        ", @GSDTL_ORG_ID = " + _obj_GSdetails.LASTMDFBY +
                                                                        ", @GSDTL_CMP_ID = " + _obj_GSdetails.GSDTL_CMP_ID + "");
            }
        }
        public static bool set_GSdetails(PMS_GoalSettings_Details _obj_GSdetails)
        {
            if (_obj_GSdetails.GS_DETAILS_MODE == 3)
            {

                //return ExecuteNonQuery(" EXEC [USP_PMS_GOALSETTING_DETAIL]" +
                //                     "@GSDTL_GS_ID = '" + Convert.ToString(_obj_GSdetails.GSDTL_GS_ID) + "'" +
                //                    ", @GSDTL_NAME = '" + Convert.ToString(_obj_GSdetails.GSDTL_NAME) + "'" +
                //                         ", @GSDTL_DESCRIPTION = '" + Convert.ToString(_obj_GSdetails.GSDTL_DESCRIPTION) + "'" +
                //                           ", @GSDTL_ORG_ID  = '" + _obj_GSdetails.LASTMDFBY + "'" +
                //                    ", @GSDTL_MEASURE = '" + Convert.ToString(_obj_GSdetails.GSDTL_MEASURE) + "'" +
                //                            ", @GSDTL_WEIGHTAGE = '" + Convert.ToString(_obj_GSdetails.GSDTL_WEIGHTAGE) + "'" +
                //                             ", @GSDTL_DATE  = '" + Convert.ToDateTime(_obj_GSdetails.GSDTL_DATE).ToString("MM/dd/yyyy") + "'" +

                //                         ", @GSDTL_CREATEDBY = '" + _obj_GSdetails.CREATEDBY + "'" +
                //                    ", @GSDTL_CREATEDDATE = '" + Convert.ToDateTime(_obj_GSdetails.CREATEDDATE).ToString("MM/dd/yyyy") + "'" +
                //                    ", @GSDTL_LASTMDFBY  = '" + _obj_GSdetails.LASTMDFBY + "'" +
                //                    ", @GSDTL_LASTMDFDATE = '" + Convert.ToDateTime(_obj_GSdetails.LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +

                //                    ",  @GSDTL_TARGET_ACHEIVED = '" + Convert.ToString(_obj_GSdetails.GSDTL_TARGET_ACHEIVED) + "'" +
                //                            " ,@GSDTL_TARGET = '" + Convert.ToString(_obj_GSdetails.GSDTL_TARGET) + "'" +
                //                         //",@GSDTL_TIMELINES = '" + Convert.ToDateTime(_obj_GSdetails.GSDTL_TIMELINES).ToString("MM/dd/yyyy") + "'" +
                //                      ", @MODE = '" + _obj_GSdetails.GS_DETAILS_MODE + "'");

                /* Newly added to insert data to "PMS_GOALSETTING_DETAIL" table */
                return ExecuteNonQuery(" EXEC [USP_PMS_GOALSETTING_DETAIL]" +
                                        "  @GSDTL_GS_ID = '" + Convert.ToInt32(_obj_GSdetails.GSDTL_GS_ID) + "'" +
                                        ", @GSDTL_CMP_ID = '" + Convert.ToInt32(_obj_GSdetails.GSDTL_CMP_ID) + "'" +
                                        ", @GSDTL_NAME = '" + Convert.ToString(_obj_GSdetails.GSDTL_NAME) + "'" +
                                        ", @GSDTL_DESCRIPTION = '" + Convert.ToString(_obj_GSdetails.GSDTL_DESCRIPTION) + "'" +
                                        ", @GSDTL_ORG_ID  = '" + _obj_GSdetails.LASTMDFBY + "'" +
                                        ", @GSDTL_DATE  = '" + Convert.ToDateTime(_obj_GSdetails.GSDTL_DATE).ToString("MM/dd/yyyy") + "'" +
                                        ", @GSDTL_CREATEDBY = '" + _obj_GSdetails.CREATEDBY + "'" +
                                        ", @GSDTL_CREATEDDATE = '" + Convert.ToDateTime(_obj_GSdetails.CREATEDDATE).ToString("MM/dd/yyyy") + "'" +
                                        ", @GSDTL_TARGET_ACHEIVED = '" + Convert.ToString(_obj_GSdetails.GSDTL_TARGET_ACHEIVED) + "'" +
                                        ", @MODE = '" + _obj_GSdetails.GS_DETAILS_MODE + "'");
            }
            else if (_obj_GSdetails.GS_DETAILS_MODE == 4)
            {
                //return ExecuteNonQuery("EXEC [USP_PMS_GOALSETTING_DETAIL] @GSDTL_ID  = '" + _obj_GSdetails.GSDTL_ID + "'" +

                //                        ", @GSDTL_NAME = '" + Convert.ToString(_obj_GSdetails.GSDTL_NAME) + "'" +
                //                         ", @GSDTL_DESCRIPTION = '" + Convert.ToString(_obj_GSdetails.GSDTL_DESCRIPTION) + "'" +
                //                           ", @GSDTL_MEASURE = '" + Convert.ToString(_obj_GSdetails.GSDTL_MEASURE) + "'" +
                //                            ", @GSDTL_WEIGHTAGE = '" + Convert.ToString(_obj_GSdetails.GSDTL_WEIGHTAGE) + "'" +
                //                             ", @GSDTL_DATE  = '" + Convert.ToDateTime(_obj_GSdetails.GSDTL_DATE).ToString("MM/dd/yyyy") + "'" +

                //                         ",  @GSDTL_LASTMDFBY  = '" + _obj_GSdetails.LASTMDFBY + "'" +
                //                    ", @GSDTL_LASTMDFDATE = '" + Convert.ToDateTime(_obj_GSdetails.LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +

                //                    ", @GSDTL_GS_ID = '" + Convert.ToString(_obj_GSdetails.GSDTL_GS_ID) + "'" +
                //                    ", @GSDTL_TARGET = '" + Convert.ToString(_obj_GSdetails.GSDTL_TARGET) + "'" +
                //                         //",@GSDTL_TIMELINES = '" + Convert.ToDateTime(_obj_GSdetails.GSDTL_TIMELINES).ToString("MM/dd/yyyy") + "'" +
                //                      " ,@GSDTL_TARGET_ACHEIVED = '" + Convert.ToString(_obj_GSdetails.GSDTL_TARGET_ACHEIVED) + "'" +
                //                         ",@MODE = '" + _obj_GSdetails.GS_DETAILS_MODE + "'");

                /* To update */
                return ExecuteNonQuery("EXEC [USP_PMS_GOALSETTING_DETAIL] @GSDTL_ID  = '" + _obj_GSdetails.GSDTL_ID + "'" +
                                        ", @GSDTL_GS_ID = " + Convert.ToInt32(_obj_GSdetails.GSDTL_GS_ID) + 
                                        ", @GSDTL_CMP_ID = " + Convert.ToInt32(_obj_GSdetails.GSDTL_CMP_ID) +
                                        ", @GSDTL_NAME = '" + Convert.ToString(_obj_GSdetails.GSDTL_NAME) + "'" +
                                        ", @GSDTL_DESCRIPTION = '" + Convert.ToString(_obj_GSdetails.GSDTL_DESCRIPTION) + "'" +
                                        ", @GSDTL_DATE  = '" + Convert.ToDateTime(_obj_GSdetails.GSDTL_DATE).ToString("MM/dd/yyyy") + "'" +
                                        ", @GSDTL_LASTMDFBY  = '" + _obj_GSdetails.LASTMDFBY + "'" +
                                        ", @GSDTL_LASTMDFDATE = '" + Convert.ToDateTime(_obj_GSdetails.LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
                                        ", @MODE = " + _obj_GSdetails.GS_DETAILS_MODE);

            }
            else if (_obj_GSdetails.GS_DETAILS_MODE == 7)
            {
                return ExecuteNonQuery("EXEC [USP_PMS_GOALSETTING_DETAIL]  @GSDTL_GS_ID = '" + Convert.ToString(_obj_GSdetails.GSDTL_GS_ID) + "'" +
                                    ", @GSDTL_ORG_ID = " + _obj_GSdetails.GSDTL_ORG_ID +
                                          ",@GSDTL_ID = '" + Convert.ToString(_obj_GSdetails.GSDTL_ID) + "'" +
                                    ", @GSDTL_TARGET_ACHEIVED = '" + Convert.ToString(_obj_GSdetails.GSDTL_TARGET_ACHEIVED) + "'" +
                                         ",@MODE = '" + _obj_GSdetails.GS_DETAILS_MODE + "'" +
                                         ",  @GSDTL_LASTMDFBY  = '" + _obj_GSdetails.LASTMDFBY + "'" +
                                         ", @GSDTL_LASTMDFDATE = '" + Convert.ToDateTime(_obj_GSdetails.LASTMDFDATE).ToString("MM/dd/yyyy") + "'");

            }
            else if (_obj_GSdetails.GS_DETAILS_MODE == 9)
            {
                return ExecuteNonQuery("EXEC [USP_PMS_GOALSETTING_DETAIL]  @GSDTL_ID = '" + Convert.ToString(_obj_GSdetails.GSDTL_ID) + "'" +
                                    ", @GSDTL_ORG_ID = " + _obj_GSdetails.LASTMDFBY +
                                          ", @GSDTL_TARGET_ACHEIVED = '" + Convert.ToString(_obj_GSdetails.GSDTL_TARGET_ACHEIVED) + "'" +
                                         ",@MODE = '" + _obj_GSdetails.GS_DETAILS_MODE + "'");

            }
            else if (_obj_GSdetails.GS_DETAILS_MODE == 14)
            {
                //To delete the selected record from PMS_GOALSETTING_DETAIL table
                //return ExecuteNonQuery("EXEC [USP_PMS_GOALSETTING_DETAIL] @MODE = '" + _obj_GSdetails.GS_DETAILS_MODE + 
                //                            "',  @GSDTL_ID= '" + _obj_GSdetails.GSDTL_ID +
                //                            "', @GSDTL_GS_ID= '" + _obj_GSdetails.GSDTL_GS_ID + "'");

                 return ExecuteNonQuery("EXEC [USP_PMS_GOALSETTING_DETAIL] @MODE = " + _obj_GSdetails.GS_DETAILS_MODE +
                                            ", @GSDTL_CMP_ID = " + _obj_GSdetails.GSDTL_CMP_ID +
                                            ", @GSDTL_GS_ID = " + _obj_GSdetails.GSDTL_GS_ID);

                
            }
            else if (_obj_GSdetails.GS_DETAILS_MODE == 15)
            {
                return ExecuteNonQuery("EXEC [USP_PMS_GOALSETTING_DETAIL] @MODE = '" + _obj_GSdetails.GS_DETAILS_MODE +
                                            "',  @GSDTL_ID= '" + _obj_GSdetails.GSDTL_ID +
                                            "', @apprycycle_id= '" + _obj_GSdetails.APPCYCLE +
                                            "',@apprycycle_id_new='" + _obj_GSdetails.BUID +
                                            "',@empid='" + _obj_GSdetails.EMP_ID + "'");
            }
            return true;

        }

        #endregion

        #region SPMS_GOALSETTINGS_GOALKRA_DETAILSKRA


        /// <summary>
        /// This method is used TO GET ROLES BASED ON ROLE_ID
        /// </summary>
        /// <returns>
        /// DataTable WITH ROLE  INFORMATION
        /// </returns>
        public static DataTable get_Gskra(GOALSETTING_GOALKRA_DETAILS _obj_Pms_goalkradetails)
        {
            if (_obj_Pms_goalkradetails.MODE == 6)
            {
                return ExecuteQuery("EXEC USP_PMS_GOALSETTING_KRA_DETAIL @MODE =6 ,@GS_KRA_ID='" + Convert.ToString(_obj_Pms_goalkradetails.GS_KRA_ID) + "'");
            }
            else if (_obj_Pms_goalkradetails.MODE == 9)
            {
                return ExecuteQuery("EXEC USP_PMS_GOALSETTING_KRA_DETAIL @MODE =9 ,@GS_KRA_GS_ID = '" + Convert.ToString(_obj_Pms_goalkradetails.GS_KRA_GS_ID) + "'" +
                                      ",@GS_KRA_ORG_ID = '" + Convert.ToString(_obj_Pms_goalkradetails.GS_KRA_ORG_ID) + "'" +
                                      ",@GS_KRA_KRA_ID='" + Convert.ToString(_obj_Pms_goalkradetails.GS_KRA_KRA_ID) + "'");
            }

            else if (_obj_Pms_goalkradetails.MODE == 11)
            {
                return ExecuteQuery("EXEC USP_PMS_GOALSETTING_KRA_DETAIL @MODE = " + _obj_Pms_goalkradetails.MODE + 
                                      ", @GS_KRA_GS_ID = " + _obj_Pms_goalkradetails.GS_KRA_GS_ID +
                                      ", @GS_KRA_DESCRIPTION = '" + Convert.ToString(_obj_Pms_goalkradetails.GS_KRA_DESCRIPTION) + "'" +
                                      ", @GS_KRA_OBJ_ID = " + _obj_Pms_goalkradetails.GS_KRA_OBJ_ID +
                                      ", @GS_KRA_KRA_ID = " + _obj_Pms_goalkradetails.GS_KRA_KRA_ID);
            }
            else if (_obj_Pms_goalkradetails.MODE  ==1)
            {
                return ExecuteQuery("EXEC USP_PMS_GOALSETTING_KRA_DETAIL @MODE =1 ,@GS_KRA_ID='" + Convert.ToString(_obj_Pms_goalkradetails.GS_KRA_ID) + "'");
            }
            else
            
            {
                return ExecuteQuery("EXEC USP_PMS_GOALSETTING_KRA_DETAIL @MODE =10 ,@GS_KRA_GS_ID = '" + Convert.ToString(_obj_Pms_goalkradetails.GS_KRA_GS_ID) + "'" +
                                      ",@GS_KRA_ORG_ID = " + Convert.ToInt32(_obj_Pms_goalkradetails.GS_KRA_ORG_ID) +
                                      ",@GS_KRA_KRA_ID= " + Convert.ToInt32(_obj_Pms_goalkradetails.GS_KRA_KRA_ID) +
                                      ", @GS_KRA_OBJ_ID = " + Convert.ToInt32(_obj_Pms_goalkradetails.GS_KRA_OBJ_ID));
            }
        }

        public static bool set_Gskra(GOALSETTING_GOALKRA_DETAILS _obj_Pms_goalkradetails)
        {
            if (_obj_Pms_goalkradetails.MODE == 4)
            {
                /* To insert data into PMS_GOALSETTING_KRA_DETAIL table*/

                //return ExecuteNonQuery(" EXEC [USP_PMS_GOALSETTING_KRA_DETAIL]" +
                //                      "@GS_KRA_ID = '" + Convert.ToString(_obj_Pms_goalkradetails.GS_KRA_ID) + "'" +
                //                      ", @GS_KRA_GS_ID = '" + Convert.ToString(_obj_Pms_goalkradetails.GS_KRA_GSDTL_ID) + "'" +
                //                      ", @GS_KRA_KRA_ID = '" + Convert.ToString(_obj_Pms_goalkradetails.GS_KRA_KRA_ID) + "'" +
                //                      ", @GS_KRA_ORG_ID = '" + Convert.ToString(_obj_Pms_goalkradetails.GS_KRA_ORG_ID) + "'" +
                //                      ",@GS_KRA_CHECKED='" + Convert.ToBoolean(_obj_Pms_goalkradetails.GS_KRA_CHECKED) + "'" +
                //                      ", @GS_KRA_NAME = '" + Convert.ToString(_obj_Pms_goalkradetails.GS_KRA_NAME) + "'" +
                //                      ", @GS_KRA_DESCRIPTION = '" + Convert.ToString(_obj_Pms_goalkradetails.GS_KRA_DESCRIPTION) + "'" +
                //                      ", @GS_KRA_MEASURE = '" + Convert.ToString(_obj_Pms_goalkradetails.GS_KRA_MEASURE) + "'" +
                //                      ", @GS_KRA_WEIGHTAGE = '" + Convert.ToString(_obj_Pms_goalkradetails.GS_KRA_WEIGHTAGE) + "'" +
                //                      ", @GS_KRA_CREATEDBY = '" + _obj_Pms_goalkradetails.CREATEDBY + "'" +
                //                      ", @GS_KRA_CREATEDDATE = '" + Convert.ToDateTime(_obj_Pms_goalkradetails.CREATEDDATE.ToString("MM/dd/yyyy")) + "'" +
                //                      ", @GS_KRA_DATE = '" + Convert.ToDateTime(_obj_Pms_goalkradetails.GS_KRA_DATE).ToString("MM/dd/yyyy") + "' " +
                //                     " , @GS_KRA_TARGET_ACHEIVED = '" + Convert.ToString(_obj_Pms_goalkradetails.GS_KRA_TARGET_ACHEIVED) + "'" +
                //                      ", @GS_KRA_TARGET = '" + Convert.ToString(_obj_Pms_goalkradetails.GS_KRA_TARGET) + "'" +
                //                         //",@GS_KRA_TIMELINES = '" + Convert.ToDateTime(_obj_Pms_goalkradetails.GS_KRA_TIMELINES).ToString("MM/dd/yyyy") + "'" +
                //                      //", @GS_KRA_TIMELINES =" + (_obj_Pms_goalkradetails.GS_KRA_TIMELINES == null ? "null" : "'" + Convert.ToDateTime(_obj_Pms_goalkradetails.GS_KRA_TIMELINES).ToString("MM/dd/yyyy") + "'") +
                //                      " , @MODE = '" + _obj_Pms_goalkradetails.MODE + "'");

                //To store new values
                return ExecuteNonQuery(" EXEC [USP_PMS_GOALSETTING_KRA_DETAIL]" +
                                     //"  @GS_KRA_ID = '" + Convert.ToString(_obj_Pms_goalkradetails.GS_KRA_ID) + "'" +
                                     " @GS_KRA_GS_ID = " + Convert.ToInt32(_obj_Pms_goalkradetails.GS_KRA_GSDTL_ID) +
                                     ", @GS_KRA_KRA_ID = " + Convert.ToInt32(_obj_Pms_goalkradetails.GS_KRA_KRA_ID) +
                                     ", @GS_KRA_NAME = '" + Convert.ToString(_obj_Pms_goalkradetails.GS_KRA_NAME) + "'" +
                                     ", @GS_KRA_DESCRIPTION = '" + Convert.ToString(_obj_Pms_goalkradetails.GS_KRA_DESCRIPTION) + "'" +
                                     ", @GS_KRA_ORG_ID = " + Convert.ToInt32(_obj_Pms_goalkradetails.GS_KRA_ORG_ID) +
                                     ", @GS_KRA_DATE = '" + Convert.ToDateTime(_obj_Pms_goalkradetails.GS_KRA_DATE).ToString("MM/dd/yyyy") + "'" +
                                     ", @GS_KRA_CREATEDBY = '" + _obj_Pms_goalkradetails.CREATEDBY + "'" +
                                     ", @GS_KRA_CREATEDDATE = '" + Convert.ToDateTime(_obj_Pms_goalkradetails.CREATEDDATE.ToString("MM/dd/yyyy")) + "'" +
                                     ", @GS_KRA_TARGET_ACHEIVED = '" + Convert.ToString(_obj_Pms_goalkradetails.GS_KRA_TARGET_ACHEIVED) + "'" +
                                     ", @GS_KRA_OBJ_ID = " + Convert.ToInt32(_obj_Pms_goalkradetails.GS_KRA_OBJ_ID) + 
                                     ", @MODE =" + _obj_Pms_goalkradetails.MODE);
            }
            else if (_obj_Pms_goalkradetails.MODE == 5)
            {
                //return ExecuteNonQuery("EXEC [USP_PMS_GOALSETTING_KRA_DETAIL]" +
                //                      "@GS_KRA_ID = '" + Convert.ToString(_obj_Pms_goalkradetails.GS_KRA_ID) + "'" +
                //                      ", @GS_KRA_GS_ID = '" + Convert.ToString(_obj_Pms_goalkradetails.GS_KRA_GSDTL_ID) + "'" +
                //                      ", @GS_KRA_KRA_ID = '" + Convert.ToString(_obj_Pms_goalkradetails.GS_KRA_KRA_ID) + "'" +
                //                      ",@GS_KRA_CHECKED='" + Convert.ToBoolean(_obj_Pms_goalkradetails.GS_KRA_CHECKED) + "'" +
                //                     ", @GS_KRA_NAME = '" + Convert.ToString(_obj_Pms_goalkradetails.GS_KRA_NAME) + "'" +
                //                          ", @GS_KRA_DESCRIPTION = '" + Convert.ToString(_obj_Pms_goalkradetails.GS_KRA_DESCRIPTION) + "'" +
                //                           ", @GS_KRA_MEASURE = '" + Convert.ToString(_obj_Pms_goalkradetails.GS_KRA_MEASURE) + "'" +
                //                            ", @GS_KRA_WEIGHTAGE = '" + Convert.ToString(_obj_Pms_goalkradetails.GS_KRA_WEIGHTAGE) + "'" +
                //                          ", @GS_KRA_LASTMDFBY = '" + _obj_Pms_goalkradetails.LASTMDFBY + "'" +
                //                    ", @GS_KRA_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Pms_goalkradetails.LASTMDFDATE.ToString("MM/dd/yyyy")) + "'" +
                //                     ", @GS_KRA_DATE = '" + Convert.ToDateTime(_obj_Pms_goalkradetails.GS_KRA_DATE.ToString("MM/dd/yyyy")) + "'" +
                //                      ",@GS_KRA_TARGET = '" + Convert.ToString(_obj_Pms_goalkradetails.GS_KRA_TARGET) + "'" +
                //                         //",@GS_KRA_TIMELINES = '" + Convert.ToDateTime(_obj_Pms_goalkradetails.GS_KRA_TIMELINES).ToString("MM/dd/yyyy") + "'" +
                //                         //", @GS_KRA_TIMELINES =" + (_obj_Pms_goalkradetails.GS_KRA_TIMELINES == null ? "null" : "'" + Convert.ToDateTime(_obj_Pms_goalkradetails.GS_KRA_TIMELINES).ToString("MM/dd/yyyy") + "'") +
                //                      " ,@GS_KRA_TARGET_ACHEIVED  = '" + Convert.ToString(_obj_Pms_goalkradetails.GS_KRA_TARGET_ACHEIVED) + "'" +
                //                         ",  @MODE = '" + _obj_Pms_goalkradetails.MODE + "'");


                /* To update data in "PMS_GOALSETTING_KRA_DETAIL" table */

                return ExecuteNonQuery("EXEC [USP_PMS_GOALSETTING_KRA_DETAIL]" +
                                      "  @GS_KRA_ID = " + Convert.ToInt32(_obj_Pms_goalkradetails.GS_KRA_ID) +
                                      ", @GS_KRA_GS_ID = " + Convert.ToInt32(_obj_Pms_goalkradetails.GS_KRA_GSDTL_ID) +
                                      ", @GS_KRA_KRA_ID = " + Convert.ToInt32(_obj_Pms_goalkradetails.GS_KRA_KRA_ID) + 
                                      ", @GS_KRA_NAME = '" + Convert.ToString(_obj_Pms_goalkradetails.GS_KRA_NAME) + "'" +
                                      ", @GS_KRA_DESCRIPTION = '" + Convert.ToString(_obj_Pms_goalkradetails.GS_KRA_DESCRIPTION) + "'" +
                                      ", @GS_KRA_DATE = '" + Convert.ToDateTime(_obj_Pms_goalkradetails.GS_KRA_DATE.ToString("MM/dd/yyyy")) + "'" +
                                      ", @GS_KRA_LASTMDFBY = '" + _obj_Pms_goalkradetails.LASTMDFBY + "'" +
                                      ", @GS_KRA_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Pms_goalkradetails.LASTMDFDATE.ToString("MM/dd/yyyy")) + "'" +
                                      " ,@GS_KRA_TARGET_ACHEIVED  = '" + Convert.ToString(_obj_Pms_goalkradetails.GS_KRA_TARGET_ACHEIVED) + "'" +
                                      ", @GS_KRA_OBJ_ID = " + Convert.ToInt32(_obj_Pms_goalkradetails.GS_KRA_OBJ_ID) + 
                                      ", @MODE = " + _obj_Pms_goalkradetails.MODE);

            }

            else if (_obj_Pms_goalkradetails.MODE == 8)
            {
                return ExecuteNonQuery("EXEC [USP_PMS_GOALSETTING_KRA_DETAIL]" +
                                      " @GS_KRA_GS_ID = '" + Convert.ToString(_obj_Pms_goalkradetails.GS_KRA_GS_ID) + "'" +
                                      ",@GS_KRA_ORG_ID = '" + Convert.ToString(_obj_Pms_goalkradetails.GS_KRA_ORG_ID) + "'" +
                                      ", @GS_KRA_KRA_ID = '" + Convert.ToString(_obj_Pms_goalkradetails.GS_KRA_KRA_ID) + "'" +
                                      ",@GS_KRA_TARGET_ACHEIVED  = '" + Convert.ToString(_obj_Pms_goalkradetails.GS_KRA_TARGET_ACHEIVED) + "'" +
                                         ",  @MODE = '" + _obj_Pms_goalkradetails.MODE + "'" +
                                         ", @GS_KRA_OBJ_ID=" + Convert.ToInt32(_obj_Pms_goalkradetails.GS_KRA_OBJ_ID) + 
                                         ",@GS_KRA_LASTMDFBY = '" + _obj_Pms_goalkradetails.LASTMDFBY + "'" +
                                         ", @GS_KRA_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Pms_goalkradetails.LASTMDFDATE.ToString("MM/dd/yyyy")) + "'");

            }
            else if (_obj_Pms_goalkradetails.MODE == 12)
            {
                /* To delete data from PMS_GOALSETTING_KRA_DETAIL table */
                //return ExecuteNonQuery("EXEC [USP_PMS_GOALSETTING_KRA_DETAIL] @MODE = '" + _obj_Pms_goalkradetails.MODE +
                //                            "', @GS_KRA_KRA_ID= '" + _obj_Pms_goalkradetails.GS_KRA_KRA_ID +
                //                            "', @GS_KRA_GS_ID= '" + _obj_Pms_goalkradetails.GS_KRA_GS_ID + "'");

                return ExecuteNonQuery("EXEC [USP_PMS_GOALSETTING_KRA_DETAIL] @MODE = '" + _obj_Pms_goalkradetails.MODE +
                                           "', @GS_KRA_OBJ_ID= '" + _obj_Pms_goalkradetails.GS_KRA_OBJ_ID +
                                           "', @GS_KRA_GS_ID= '" + _obj_Pms_goalkradetails.GS_KRA_GS_ID + "'");
            }
            else if (_obj_Pms_goalkradetails.MODE == 13)
            {
                return ExecuteNonQuery("EXEC [USP_PMS_GOALSETTING_KRA_DETAIL] @MODE = '" + _obj_Pms_goalkradetails.MODE +
                                            "', @GS_KRA_KRA_ID= '" + _obj_Pms_goalkradetails.GS_KRA_KRA_ID +
                                            "', @GS_APPRAISAL_CYCLE= '" + _obj_Pms_goalkradetails.APPCYCLE +
                                            "',@apprycycle_id_new='" + _obj_Pms_goalkradetails.BUID +
                                            "',@GS_KRA_EMP_ID='" + _obj_Pms_goalkradetails.EMP_ID + "'");
            }
            return true;

        }
        #endregion
        #region
        public static bool set_GsIDP(GOALSETTING_IDP_DETAILS _obj_Pms_goalIDPdetails)
        {
            if (_obj_Pms_goalIDPdetails.MODE == 4)
            {

                //return ExecuteNonQuery(" EXEC [USP_PMS_GOALSETTING_IDP_DETAIL]" +
                //                      "@GS_IDP_ID = '" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_ID) + "'" +
                //                      ",  @GS_IDP_GS_ID = '" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_GSDTL_ID) + "'" +
                //                      ", @GS_IDP_IDP_ID = '" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_IDP_ID) + "'" +
                //                      ", @GS_IDP_ORG_ID = '" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_ORG_ID) + "'" +
                //                      ", @GS_IDP_CHECKED='" + Convert.ToBoolean(_obj_Pms_goalIDPdetails.GS_IDP_CHECKED) + "'" +
                //                      ", @GS_IDP_NAME = '" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_NAME) + "'" +
                //                      ", @GS_IDP_DESCRIPTION = '" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_DESCRIPTION) + "'" +
                //                      ", @GS_IDP_MEASURE = '" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_MEASURE) + "'" +
                //                      ", @GS_IDP_WEIGHTAGE = '" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_WEIGHTAGE) + "'" +
                //                      ", @GS_IDP_CREATEDBY = '" + _obj_Pms_goalIDPdetails.CREATEDBY + "'" +
                //                      ", @GS_IDP_CREATEDDATE = '" + Convert.ToDateTime(_obj_Pms_goalIDPdetails.CREATEDDATE.ToString("MM/dd/yyyy")) + "'" +
                //                      ", @GS_IDP_DATE = '" + Convert.ToDateTime(_obj_Pms_goalIDPdetails.GS_IDP_DATE).ToString("MM/dd/yyyy") + "' " +
                //                     " , @GS_IDP_TARGET_ACHEIVED = '" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_TARGET_ACHEIVED) + "'" +
                //                      ", @GS_IDP_TARGET = '" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_TARGET) + "'" +
                //                         //",@GS_IDP_TIMELINES = '" + Convert.ToDateTime(_obj_Pms_goalIDPdetails.GS_IDP_TIMELINES).ToString("MM/dd/yyyy") + "'" +
                //                      " , @MODE = '" + _obj_Pms_goalIDPdetails.MODE + "'");


                return ExecuteNonQuery(" EXEC [USP_PMS_GOALSETTING_IDP_DETAIL]" +
                                    //"@GS_IDP_ID = '" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_ID) + "'" +
                                     "  @GS_IDP_GS_ID = " + Convert.ToInt32(_obj_Pms_goalIDPdetails.GS_IDP_GSDTL_ID) +
                                     ", @GS_IDP_IDP_ID = " + Convert.ToInt32(_obj_Pms_goalIDPdetails.GS_IDP_IDP_ID) +
                                     ", @GS_IDP_NAME = '" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_NAME) + "'" +
                                     ", @GS_IDP_DESCRIPTION = '" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_DESCRIPTION) + "'" +
                                     ", @GS_IDP_ORG_ID = " + Convert.ToInt32(_obj_Pms_goalIDPdetails.GS_IDP_ORG_ID) + 
                                     ", @GS_IDP_DATE = '" + Convert.ToDateTime(_obj_Pms_goalIDPdetails.GS_IDP_DATE).ToString("MM/dd/yyyy") + "' " +
                                     ", @GS_IDP_CREATEDBY = '" + _obj_Pms_goalIDPdetails.CREATEDBY + "'" +
                                     ", @GS_IDP_CREATEDDATE = '" + Convert.ToDateTime(_obj_Pms_goalIDPdetails.CREATEDDATE.ToString("MM/dd/yyyy")) + "'" +
                                     ", @GS_IDP_TARGET_ACHEIVED = '" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_TARGET_ACHEIVED) + "'" +
                                     ", @MODE = " + _obj_Pms_goalIDPdetails.MODE);
            }
            else if (_obj_Pms_goalIDPdetails.MODE == 5)
            {
                //return ExecuteNonQuery("EXEC [USP_PMS_GOALSETTING_IDP_DETAIL]" +
                //                      "@GS_IDP_ID = '" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_ID) + "'" +
                //                      ", @GS_IDP_GS_ID = '" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_GSDTL_ID) + "'" +
                //                      ", @GS_IDP_IDP_ID = '" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_IDP_ID) + "'" +
                //                      ",@GS_IDP_CHECKED='" + Convert.ToBoolean(_obj_Pms_goalIDPdetails.GS_IDP_CHECKED) + "'" +
                //                     ", @GS_IDP_NAME = '" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_NAME) + "'" +
                //                          ", @GS_IDP_DESCRIPTION = '" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_DESCRIPTION) + "'" +
                //                           ", @GS_IDP_MEASURE = '" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_MEASURE) + "'" +
                //                            ", @GS_IDP_WEIGHTAGE = '" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_WEIGHTAGE) + "'" +
                //                          ", @GS_IDP_LASTMDFBY = '" + _obj_Pms_goalIDPdetails.LASTMDFBY + "'" +
                //                    ", @GS_IDP_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Pms_goalIDPdetails.LASTMDFDATE.ToString("MM/dd/yyyy")) + "'" +
                //                     ", @GS_IDP_DATE = '" + Convert.ToDateTime(_obj_Pms_goalIDPdetails.GS_IDP_DATE.ToString("MM/dd/yyyy")) + "'" +
                //                      ",@GS_IDP_TARGET = '" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_TARGET) + "'" +
                //                         //",@GS_IDP_TIMELINES = '" + Convert.ToDateTime(_obj_Pms_goalIDPdetails.GS_IDP_TIMELINES).ToString("MM/dd/yyyy") + "'" +
                //                      " ,@GS_IDP_TARGET_ACHEIVED  = '" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_TARGET_ACHEIVED) + "'" +
                //                         ",  @MODE = '" + _obj_Pms_goalIDPdetails.MODE + "'");

                /* To update */
                return ExecuteNonQuery("EXEC [USP_PMS_GOALSETTING_IDP_DETAIL]" +
                                      "  @GS_IDP_ID = " + Convert.ToInt32(_obj_Pms_goalIDPdetails.GS_IDP_ID) +
                                      ", @GS_IDP_GS_ID = " + Convert.ToInt32(_obj_Pms_goalIDPdetails.GS_IDP_GSDTL_ID) +
                                      ", @GS_IDP_IDP_ID = " + Convert.ToInt32(_obj_Pms_goalIDPdetails.GS_IDP_IDP_ID) +
                                      ", @GS_IDP_NAME = '" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_NAME) + "'" +
                                      ", @GS_IDP_DESCRIPTION = '" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_DESCRIPTION) + "'" +
                                      ", @GS_IDP_LASTMDFBY = " + _obj_Pms_goalIDPdetails.LASTMDFBY + 
                                      ", @GS_IDP_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Pms_goalIDPdetails.LASTMDFDATE.ToString("MM/dd/yyyy")) + "'" +
                                      ", @GS_IDP_DATE = '" + Convert.ToDateTime(_obj_Pms_goalIDPdetails.GS_IDP_DATE.ToString("MM/dd/yyyy")) + "'" +
                                      ", @GS_IDP_TARGET_ACHEIVED  = '" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_TARGET_ACHEIVED) + "'" +
                                      ", @MODE = " + _obj_Pms_goalIDPdetails.MODE);


            }

            else if (_obj_Pms_goalIDPdetails.MODE == 8)
            {
                return ExecuteNonQuery("EXEC [USP_PMS_GOALSETTING_IDP_DETAIL]" +
                                      " @GS_IDP_GS_ID = '" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_GS_ID) + "'" +
                                      ",@GS_IDP_ORG_ID = '" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_ORG_ID) + "'" +
                                      ", @GS_IDP_IDP_ID = '" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_IDP_ID) + "'" +
                                      ",@GS_IDP_TARGET_ACHEIVED  = '" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_TARGET_ACHEIVED) + "'" +
                                         ",  @MODE = '" + _obj_Pms_goalIDPdetails.MODE + "'" +
                                         ",  @GS_IDP_LASTMDFBY = '" + _obj_Pms_goalIDPdetails.LASTMDFBY + "'" +
                                         ", @GS_IDP_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Pms_goalIDPdetails.LASTMDFDATE.ToString("MM/dd/yyyy")) + "'");

            }
            else if (_obj_Pms_goalIDPdetails.MODE == 12)
            {
                return ExecuteNonQuery("EXEC [USP_PMS_GOALSETTING_IDP_DETAIL] @MODE = '" + _obj_Pms_goalIDPdetails.MODE +
                                            "', @GS_IDP_IDP_ID= '" + _obj_Pms_goalIDPdetails.GS_IDP_IDP_ID +
                                            "', @GS_IDP_GS_ID= '" + _obj_Pms_goalIDPdetails.GS_IDP_GS_ID + "'");
            }
            else if (_obj_Pms_goalIDPdetails.MODE == 13)
            {
                return ExecuteNonQuery("EXEC [USP_PMS_GOALSETTING_IDP_DETAIL] @MODE = '" + _obj_Pms_goalIDPdetails.MODE +
                                            "', @GS_IDP_IDP_ID= '" + _obj_Pms_goalIDPdetails.GS_IDP_IDP_ID +
                                            "', @GS_APPRAISAL_CYCLE= '" + _obj_Pms_goalIDPdetails.APPCYCLE +
                                            "',@apprycycle_id_new='" + _obj_Pms_goalIDPdetails.BUID +
                                            "',@GS_IDP_EMP_ID='" + _obj_Pms_goalIDPdetails.EMP_ID + "'");
            }
            return true;

        }
        public static DataTable get_GsIDP(GOALSETTING_IDP_DETAILS _obj_Pms_goalIDPdetails)
        {
            if (_obj_Pms_goalIDPdetails.MODE == 6)
            {
                return ExecuteQuery("EXEC USP_PMS_GOALSETTING_IDP_DETAIL @MODE =6 ,@GS_IDP_ID='" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_ID) + "'");
            }
            else if (_obj_Pms_goalIDPdetails.MODE == 9)
            {
                return ExecuteQuery("EXEC USP_PMS_GOALSETTING_IDP_DETAIL @MODE =9 ,@GS_IDP_GS_ID = '" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_GS_ID) + "'" +
                                      ",@GS_IDP_ORG_ID = '" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_ORG_ID) + "'" +
                                      ",@GS_IDP_IDP_ID='" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_IDP_ID) + "'");
            }

            else if (_obj_Pms_goalIDPdetails.MODE == 11)
            {
                return ExecuteQuery("EXEC USP_PMS_GOALSETTING_IDP_DETAIL @MODE = 11 ,@GS_IDP_GS_ID = '" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_GS_ID) + "'" +
                                      ", @GS_IDP_DESCRIPTION = '" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_DESCRIPTION) + "'" +
                                      //", @GS_IDP_MEASURE = '" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_MEASURE) + "'" +
                                      //", @GS_IDP_WEIGHTAGE = '" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_WEIGHTAGE) + "'" +
                                      //", @GS_IDP_TARGET = '" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_TARGET) + "'" +
                                         //",@GS_IDP_TIMELINES = '" + Convert.ToDateTime(_obj_Pms_goalIDPdetails.GS_IDP_TIMELINES).ToString("MM/dd/yyyy") + "'" +
                                      ",@GS_IDP_IDP_ID='" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_IDP_ID) + "'");
            }
            else if (_obj_Pms_goalIDPdetails.MODE == 1)
            {
                return ExecuteQuery("EXEC USP_PMS_GOALSETTING_IDP_DETAIL @MODE =1 ,@GS_IDP_ID='" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_ID) + "'");
            }
            else
            {
                return ExecuteQuery("EXEC USP_PMS_GOALSETTING_IDP_DETAIL @MODE =10 ,@GS_IDP_GS_ID = '" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_GS_ID) + "'" +
                                      ",@GS_IDP_ORG_ID = '" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_ORG_ID) + "'" +
                                      ",@GS_IDP_IDP_ID='" + Convert.ToString(_obj_Pms_goalIDPdetails.GS_IDP_IDP_ID) + "'");
            }
        }

        #endregion
        #region PMS_GOALSETTINGS_GOALKRA
        public static DataTable get_goalkra(PMS_GOALKRA _obj_Pms_GOALKRA)
        {

            if (_obj_Pms_GOALKRA.GOALKRA_MODE == 1)
            {
                return ExecuteQuery("EXEC [USP_PMS_GOALSETTING_KRA]  @GOALKRA_ID = " + _obj_Pms_GOALKRA.GOALKRA_ID +
                                    " , @mode = '" + _obj_Pms_GOALKRA.GOALKRA_MODE + "'");
            }
            else
            {
                return ExecuteQuery("EXEC [USP_PMS_GOALSETTING_KRA] @MODE = '2', @GOALKRA_ID = " + _obj_Pms_GOALKRA.GOALKRA_ID + "");
            }




        }
        public static bool set_goalkra(PMS_GOALKRA _obj_Pms_GOALKRA)
        {
            if (_obj_Pms_GOALKRA.GOALKRA_MODE == 3)
            {

                return ExecuteNonQuery(" EXEC [USP_PMS_GOALSETTING_KRA]" +
                                      "@GOALKRA_ID = '" + Convert.ToString(_obj_Pms_GOALKRA.GOALKRA_ID) + "'" +
                                      ",@GSDTL_GS_ID = '" + Convert.ToString(_obj_Pms_GOALKRA.GSDTL_GS_ID) + "'" +
                                      ", @GOALKRA_NAME = '" + Convert.ToString(_obj_Pms_GOALKRA.GOALKRA_NAME) + "'" +
                                      ", @GOALKRA_DESCRIPTION = '" + Convert.ToString(_obj_Pms_GOALKRA.GOALKRA_DESCRIPTION) + "'" +
                                      ",  @MODE = '" + _obj_Pms_GOALKRA.GOALKRA_MODE + "'");
            }
            else if (_obj_Pms_GOALKRA.GOALKRA_MODE == 4)
            {
                return ExecuteNonQuery("EXEC [USP_PMS_GOALSETTING_KRA]" +
                                      "@GOALKRA_ID = '" + Convert.ToString(_obj_Pms_GOALKRA.GOALKRA_ID) + "'" +
                                      ", @GOALKRA_NAME = '" + Convert.ToString(_obj_Pms_GOALKRA.GOALKRA_NAME) + "'" +
                                      ", @GOALKRA_DESCRIPTION = '" + Convert.ToString(_obj_Pms_GOALKRA.GOALKRA_DESCRIPTION) + "'" +
                                      ",  @MODE = '" + _obj_Pms_GOALKRA.GOALKRA_MODE + "'");

            }


            return true;

        }
        #endregion

        #region PMS_RATINGMETHODS

        /// <summary>
        /// This method is used TO GET RATINGDETAILS BASED ON RATING_ID
        /// </summary>
        /// <returns>
        /// DataTable WITH RATING INFORMATION
        /// </returns>
        public static DataTable get_Rating(SPMS_RATINGS _obj_Pms_Ratings)
        { //thismode defined at roles.aspx.cs
            DataTable dt = new DataTable();
            switch (_obj_Pms_Ratings.Mode)
            {

                case 1:
                    dt = ExecuteQuery("EXEC USP_SPMS_RATINGS @MODE = 1 ");
                    break;
                case 2:
                    dt = ExecuteQuery("EXEC USP_SPMS_RATINGS @MODE = 2,@RATINGS_ID = " + Convert.ToString(_obj_Pms_Ratings.RATINGS_ID) + " ");

                    break;
                default:
                    break;
            }
            return dt;
        }

        /// <summary>
        /// This Method is used for insertion, deletion and updation of roles based upon criteria
        /// </summary>
        /// <returns>
        /// Bool
        /// </returns>
        public static bool set_Rating(SPMS_RATINGS _obj_Pms_Ratings)
        {
            bool status = false;
            switch (_obj_Pms_Ratings.Mode)
            {
                case 3:
                    if (ExecuteNonQuery("EXEC USP_SPMS_RATINGS @MODE = 3 , @RATINGS_NAME= '" + Convert.ToString(_obj_Pms_Ratings.RATINGS_NAME) + "'" +
                                       ", @RATINGS_DESCRIPTION= '" + Convert.ToString(_obj_Pms_Ratings.RATINGS_DESCRIPTION) + "'" +
                                      ",@RATINGS_INDICATOR= '" + Convert.ToString(_obj_Pms_Ratings.RATINGS_INDICATOR) + "'" +
                                       ", @RATINGS_CREATEDBY=" + Convert.ToInt32(_obj_Pms_Ratings.CREATEDBY)
                                      + " , @RATINGS_CREATEDDATE='" + Convert.ToDateTime(_obj_Pms_Ratings.CREATEDDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case 4:
                    if (ExecuteNonQuery("EXEC USP_SPMS_RATINGS @MODE = 4 ,@RATINGS_ID= " + Convert.ToString(_obj_Pms_Ratings.RATINGS_ID)
                                       + ",@RATINGS_NAME= '" + Convert.ToString(_obj_Pms_Ratings.RATINGS_NAME) + "'" +
                                      ", @RATINGS_DESCRIPTION= '" + Convert.ToString(_obj_Pms_Ratings.RATINGS_DESCRIPTION) + "'" +
                                      ",@RATINGS_INDICATOR= '" + Convert.ToString(_obj_Pms_Ratings.RATINGS_INDICATOR) + "'" +
                                       ", @RATINGS_LASTMDFBY =" + Convert.ToInt32(_obj_Pms_Ratings.LASTMDFBY)
                                      + " , @RATINGS_LASTMDFDATE='" + Convert.ToDateTime(_obj_Pms_Ratings.LASTMDFDATE).ToString("MM/dd/yyyy") + "'"))


                        status = true;
                    else
                        status = false;

                    break;
                case 5:
                    if (ExecuteNonQuery("EXEC USP_SPMS_RATINGS @MODE = 5 , @RATINGS_ID=" + Convert.ToString(_obj_Pms_Ratings.RATINGS_ID)
                                      + " "))

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

        #region SPMS_ROLEMETHODS

        /// <summary>
        /// This method is used TO GET ROLESDETAILS BASED ON ROLE_ID
        /// </summary>
        /// <returns>
        /// DataTable WITH ROLES INFORMATION
        /// </returns>
        public static DataTable get_Role(SPMS_ROLE _obj_Pms_Role)
        { //thismode defined at roles.aspx.cs
            DataTable dt = new DataTable();
            switch (_obj_Pms_Role.Mode)
            {

                case 1:
                    dt = ExecuteQuery("EXEC USP_PMS_ROLES @MODE = 1");
                    break;
                case 2:
                    dt = ExecuteQuery("EXEC USP_PMS_ROLES @MODE = 2,@ROLE_ID = " + Convert.ToString(_obj_Pms_Role.ROLE_ID) + " ");

                    break;
                case 7:
                    dt = ExecuteQuery("EXEC USP_PMS_ROLES @MODE = 7,@ROLE_NAME = '" + Convert.ToString(_obj_Pms_Role.ROLE_NAME) + "'" +
                                      "  ");

                    break;
                default:
                    break;
            }
            return dt;
        }
        //<summary>
        //This Method is used for insertion, deletion and updation of roles based upon criteria
        //</summary>
        //<returns>
        //Bool
        //</returns>


        public static bool set_Role(SPMS_ROLE _obj_Pms_Role)
        {
            bool status = false;
            switch (_obj_Pms_Role.Mode)
            {
                case 3:
                    if (ExecuteNonQuery("EXEC USP_PMS_ROLES @MODE = 3 , @ROLE_NAME = '" + Convert.ToString(_obj_Pms_Role.ROLE_NAME) + "'" +
                                      " , @ROLE_DESCRIPTION = '" + Convert.ToString(_obj_Pms_Role.ROLE_DESCRIPTION) + "'" +
                                      " , @ROLES_KRA_ID = " + Convert.ToString(_obj_Pms_Role.ROLES_KRA_ID) +
                                      " , @ROLE_STARTDATE = '" + Convert.ToDateTime(_obj_Pms_Role.ROLE_STARTDATE).ToString("MM/dd/yyyy") + "'" +
                                      ", @ROLE_ENDDATE =" + (_obj_Pms_Role.ROLE_ENDDATE == null ? "null" : "'" + Convert.ToDateTime(_obj_Pms_Role.ROLE_ENDDATE).ToString("MM/dd/yyyy") + "'")
                                     + " , @ROLE_COMMENTS = '" + Convert.ToString(_obj_Pms_Role.ROLE_COMMENTS) + "'" +
                                      " , @ROLE_CREATEDBY = " + Convert.ToInt32(_obj_Pms_Role.ROLE_CREATEDBY) +
                                      ", @ROLE_CREATEDDATE= '" + Convert.ToDateTime(_obj_Pms_Role.ROLE_CREATEDDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case 4:
                    if (ExecuteNonQuery("EXEC USP_PMS_ROLES @MODE = 4 ,@ROLE_ID=" + Convert.ToString(_obj_Pms_Role.ROLE_ID)
                                       + ",   @ROLE_NAME = '" + Convert.ToString(_obj_Pms_Role.ROLE_NAME) + "'" +
                                      " , @ROLE_DESCRIPTION = '" + Convert.ToString(_obj_Pms_Role.ROLE_DESCRIPTION) + "'" +
                                      " , @ROLES_KRA_ID = " + Convert.ToString(_obj_Pms_Role.ROLES_KRA_ID) +
                                      " , @ROLE_STARTDATE = '" + Convert.ToDateTime(_obj_Pms_Role.ROLE_STARTDATE).ToString("MM/dd/yyyy") + "'" +
                                      " , @ROLE_ENDDATE = " + (_obj_Pms_Role.ROLE_ENDDATE == null ? "null" : "'" + Convert.ToDateTime(_obj_Pms_Role.ROLE_ENDDATE).ToString("MM/dd/yyyy") + "'")
                                     + " , @ROLE_COMMENTS = '" + Convert.ToString(_obj_Pms_Role.ROLE_COMMENTS) + "'" +
                                      " , @ROLE_LASTMDFBY = " + Convert.ToInt32(_obj_Pms_Role.ROLE_LASTMDFBY) +
                                      " , @ROLE_LASTMDFDATE= '" + Convert.ToDateTime(_obj_Pms_Role.ROLE_LASTMDFDATE).ToString("MM/dd/yyyy") + "'"))


                        status = true;
                    else
                        status = false;

                    break;
                case 5:
                    if (ExecuteNonQuery("EXEC USP_PMS_ROLES @MODE = 5 , @ROLE_ID=" + Convert.ToString(_obj_Pms_Role.ROLE_ID)
                                      + " "))

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

        #region PMS_COMPETENCYMETHODS
        /// <summary>
        /// This method is used TO GET competencydetails BASED ON COMPETENCY_ID
        /// </summary>
        /// <returns>
        /// DataTable WITH COMPETENCY INFORMATION
        /// </returns>
        public static DataTable get_Competencies(SPMS_COMPETENCIES _obj_Pms_Competencies)
        {
            DataTable dt = new DataTable();
            switch (_obj_Pms_Competencies.Mode)
            {

                case 1:
                    dt = ExecuteQuery("EXEC USP_COMPETENCIES @MODE = 1");
                    break;
                case 2:
                    dt = ExecuteQuery("EXEC USP_COMPETENCIES @MODE = 2,@COMPETENCIES_ID = " + Convert.ToString(_obj_Pms_Competencies.COMPETENCIES_ID) + " ");

                    break;
                default:
                    break;
            }
            return dt;
        }

        /// <summary>
        /// This Method is used for insertion, deletion and updation of COMPETENCIES based upon criteria
        /// </summary>
        /// <returns>
        /// Bool
        /// </returns>
        public static bool set_Competencies(SPMS_COMPETENCIES _obj_Pms_Competencies)
        {

            bool status = false;
            switch (_obj_Pms_Competencies.Mode)
            {
                case 3:
                    if (ExecuteNonQuery("EXEC USP_COMPETENCIES @MODE = 3 ,@COMPETENCIES_NAME='" + Convert.ToString(_obj_Pms_Competencies.COMPETENCIES_NAME) + "'"
                                      + ", @COMPETENCIES_DESC='" + Convert.ToString(_obj_Pms_Competencies.COMPETENCIES_DESC) + "'"
                                      + ",@COMPETENCIES_RATING_ID = " + Convert.ToString(_obj_Pms_Competencies.COMPETENCIES_RATING_ID) +
                                      " , @COMPETENCIES_STARTDATE = '" + Convert.ToDateTime(_obj_Pms_Competencies.COMPETENCIES_STARTDATE).ToString("MM/dd/yyyy") + "'" +
                                      " , @COMPETENCIES_ENDDATE = '" + Convert.ToDateTime(_obj_Pms_Competencies.COMPETENCIES_ENDDATE).ToString("MM/dd/yyyy") + "'" +
                                      " , @COMPETENCIES_INDICATOR = '" + Convert.ToString(_obj_Pms_Competencies.COMPETENCIES_INDICATOR) + "'"
                                      + ", @COMPETENCIES_REVIEWPERIOD= " + Convert.ToInt32(_obj_Pms_Competencies.COMPETENCIES_REVIEWPERIOD)
                                      + ",@COMPETENCIES_UNITS= " + Convert.ToString(_obj_Pms_Competencies.COMPETENCIES_UNITS)
                                      + ", @COMPETENCIES_CREATEDBY=" + Convert.ToInt32(_obj_Pms_Competencies.COMPETENCIES_CREATEDBY)
                                      + " , @COMPETENCIES_CREATEDDATE= '" + Convert.ToDateTime(_obj_Pms_Competencies.COMPETENCIES_CREATEDDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case 4:
                    if (ExecuteNonQuery("EXEC USP_COMPETENCIES @MODE = 4 , @COMPETENCIES_ID=" + Convert.ToString(_obj_Pms_Competencies.COMPETENCIES_ID)
                                       + ",@COMPETENCIES_NAME='" + Convert.ToString(_obj_Pms_Competencies.COMPETENCIES_NAME) + "'"
                                      + ", @COMPETENCIES_DESC='" + Convert.ToString(_obj_Pms_Competencies.COMPETENCIES_DESC) + "'"
                                      + ",@COMPETENCIES_RATING_ID = " + Convert.ToString(_obj_Pms_Competencies.COMPETENCIES_RATING_ID) +
                                      " , @COMPETENCIES_STARTDATE = '" + Convert.ToDateTime(_obj_Pms_Competencies.COMPETENCIES_STARTDATE).ToString("MM/dd/yyyy") + "'" +
                                      " , @COMPETENCIES_ENDDATE = '" + Convert.ToDateTime(_obj_Pms_Competencies.COMPETENCIES_ENDDATE).ToString("MM/dd/yyyy") + "'" +
                                      " , @COMPETENCIES_INDICATOR = '" + Convert.ToString(_obj_Pms_Competencies.COMPETENCIES_INDICATOR) + "'"
                                      + ", @COMPETENCIES_REVIEWPERIOD=" + Convert.ToInt32(_obj_Pms_Competencies.COMPETENCIES_REVIEWPERIOD)
                                      + ",@COMPETENCIES_UNITS=" + Convert.ToString(_obj_Pms_Competencies.COMPETENCIES_UNITS)
                                       + ", @COMPETENCIES_LASTMDFBY =" + Convert.ToInt32(_obj_Pms_Competencies.COMPETENCIES_LASTMDFBY) + ""
                                      + " , @COMPETENCIES_LASTMDFDATE='" + Convert.ToDateTime(_obj_Pms_Competencies.COMPETENCIES_LASTMDFDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;

                    break;
                case 5:
                    if (ExecuteNonQuery("EXEC USP_COMPETENCIES @MODE = 5 ,  @COMPETENCIES_ID=" + Convert.ToString(_obj_Pms_Competencies.COMPETENCIES_ID)
                                      + " "))

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

        #region SPMS_ASSIGNINGKRA


        /// <summary>
        /// This method is used TO GET KRADETAILS BASED ON KRA_ID
        /// </summary>
        /// <returns>
        /// DataTable WITH ROLES INFORMATION
        /// </returns>
        public static DataTable get_Kra(SPMS_ASSIGNINGKRA _obj_Pms_AssigningKra)
        {
            DataTable dt = new DataTable();
            switch (_obj_Pms_AssigningKra.Mode)
            {

                case 1:
                    dt = ExecuteQuery("EXEC USP_ASSGN_KRA @MODE = 1");
                    break;
                case 2:
                    dt = ExecuteQuery("EXEC USP_ASSGN_KRA @MODE = 2,@ASSGNKRA_ID = " + Convert.ToString(_obj_Pms_AssigningKra.ASSGNKRA_ID) + " ");

                    break;
                default:
                    break;
            }
            return dt;
        }


        //<summary>
        //This Method is used for insertion, deletion and updation of KRA based upon criteria
        //</summary>
        //<returns>
        //Bool
        //</returns>


        public static bool set_Kra(SPMS_ASSIGNINGKRA _obj_Pms_AssigningKra)
        {
            bool status = false;
            switch (_obj_Pms_AssigningKra.Mode)
            {
                case 3:
                    if (ExecuteNonQuery("EXEC USP_ASSGN_KRA @MODE = 3 ,@ASSGNKRA_KRA_ID = " + Convert.ToString(_obj_Pms_AssigningKra.ASSGNKRA_KRA_ID) +
                                      " ,@ASSGNKRA_BUID = " + Convert.ToString(_obj_Pms_AssigningKra.ASSGNKRA_BUID) +
                                      " , @ASSGNKRA_EMP_ID = " + Convert.ToString(_obj_Pms_AssigningKra.ASSGNKRA_EMP_ID) +
                                      " , @ASSGNKRA_MGR_ID = " + Convert.ToString(_obj_Pms_AssigningKra.ASSGNKRA_MGR_ID) +
                                      " ,@ASSGNKRA_CREATEDBY = " + Convert.ToInt32(_obj_Pms_AssigningKra.ASSGNKRA_CREATEDBY) +
                                      ", @ASSGNKRA_CREATEDDATE= '" + Convert.ToDateTime(_obj_Pms_AssigningKra.ASSGNKRA_CREATEDDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case 4:
                    if (ExecuteNonQuery("EXEC USP_ASSGN_KRA @MODE = 4 , @ASSGNKRA_ID=" + Convert.ToString(_obj_Pms_AssigningKra.ASSGNKRA_ID)
                                       + ", @ASSGNKRA_KRA_ID = " + Convert.ToString(_obj_Pms_AssigningKra.ASSGNKRA_KRA_ID) +
                                      " ,@ASSGNKRA_BUID = " + Convert.ToString(_obj_Pms_AssigningKra.ASSGNKRA_BUID) +
                                      " , @ASSGNKRA_EMP_ID = " + Convert.ToString(_obj_Pms_AssigningKra.ASSGNKRA_EMP_ID) +
                                      " , @ASSGNKRA_MGR_ID = " + Convert.ToString(_obj_Pms_AssigningKra.ASSGNKRA_MGR_ID) +
                                      " ,@ASSGNKRA_LASTMDFBY = " + Convert.ToInt32(_obj_Pms_AssigningKra.ASSGNKRA_LASTMDFBY) +
                                      ", @ASSGNKRA_LASTMDFDATE= '" + Convert.ToDateTime(_obj_Pms_AssigningKra.ASSGNKRA_LASTMDFDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;

                    break;
                case 5:
                    if (ExecuteNonQuery("EXEC USP_ASSGN_KRA @MODE = 5 ,@ASSGNKRA_ID = " + Convert.ToString(_obj_Pms_AssigningKra.ASSGNKRA_ID)
                                      + " "))

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

        #region SPMS_KRAS

        /// <summary>
        /// This method is used TO GET KRADETAILS BASED ON KRA_ID
        /// </summary>
        /// <returns>
        /// DataTable WITH ROLES INFORMATION
        /// </returns>
        public static DataTable get_Kras(SPMS_KRA _obj_Spms_Kras)
        {
            DataTable dt = new DataTable();
            switch (_obj_Spms_Kras.Mode)
            {

                case 1:
                    dt = ExecuteQuery("EXEC USP_PMS_KRA @MODE = 1");
                    break;
                case 2:
                    dt = ExecuteQuery("EXEC USP_PMS_KRA @MODE = 2,@KRA_ID = " + Convert.ToString(_obj_Spms_Kras.KRA_ID) + " ");

                    break;
                case 8:
                    dt = ExecuteQuery("EXEC USP_PMS_KRA @MODE = 8,@KRA_ORG_ID = " + Convert.ToString(_obj_Spms_Kras.KRA_ORG_ID) + ",@KRA_BU_ID   = " + Convert.ToString(_obj_Spms_Kras.BUID) + " ");

                    break;
                default:
                    break;
            }
            return dt;
        }


        #endregion

        #region SPMS_FEEDBACK


        /// <summary>
        /// This method is used TO GET FEEDBACKDETAILS BASED ON FEEDBACK_ID
        /// </summary>
        /// <returns>
        /// DataTable WITH FEEDBACK INFORMATION
        /// </returns>
        public static DataTable get_Feedabck(SPMS_FEEDBACK _obj_Pms_Feedback)
        {
            DataTable dt = new DataTable();
            switch (_obj_Pms_Feedback.Mode)
            {

                case 1:
                    dt = ExecuteQuery("EXEC USP_PMSFEEDBACKS @MODE = 1");
                    break;
                case 2:
                    dt = ExecuteQuery("EXEC USP_PMSFEEDBACKS @MODE = 2,@FEEDBACK_ID = " + Convert.ToString(_obj_Pms_Feedback.FEEDBACK_ID) + " ");

                    break;
                case 6:
                    dt = ExecuteQuery("EXEC USP_PMSFEEDBACKS @MODE = 6,@FEEDBK_ID = " + Convert.ToString(_obj_Pms_Feedback.FEEDBK_ID) + " ");

                    break;


                default:
                    break;
            }
            return dt;
        }


        //<summary>
        //This Method is used for insertion, deletion and updation of FEEDBACK based upon criteria
        //</summary>
        //<returns>
        //Bool
        //</returns>


        public static bool set_Feedback(SPMS_FEEDBACK _obj_Pms_Feedback)
        {
            bool status = false;
            switch (_obj_Pms_Feedback.Mode)
            {
                case 3:
                    if (ExecuteNonQuery("EXEC USP_PMSFEEDBACKS @MODE = 3 ,@FEEDBK_ID = " + Convert.ToString(_obj_Pms_Feedback.FEEDBK_ID) +
                                      " , @FEEDBACK_NAME_ID = '" + Convert.ToString(_obj_Pms_Feedback.FEEDBACK_NAME_ID) + "'" +
                                      " , @FEEDBACK_COMMENTS = '" + Convert.ToString(_obj_Pms_Feedback.FEEDBACK_COMMENTS) + "'" +
                                      " ,@FEEDBACK_DATE = '" + Convert.ToDateTime(_obj_Pms_Feedback.FEEDBACK_DATE).ToString("MM/dd/yyyy") + "'" +
                                      ",@FEEDBACK_CREATEDBY = " + Convert.ToInt32(_obj_Pms_Feedback.FEEDBACK_CREATEDBY) +
                                      ", @FEEDBACK_CREATEDDATE = '" + Convert.ToDateTime(_obj_Pms_Feedback.FEEDBACK_CREATEDDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case 4:
                    if (ExecuteNonQuery("EXEC USP_PMSFEEDBACKS @MODE = 4 , @FEEDBACK_ID =" + Convert.ToString(_obj_Pms_Feedback.FEEDBACK_ID)
                                       + ",@FEEDBK_ID = " + Convert.ToString(_obj_Pms_Feedback.FEEDBK_ID) +
                                      " , @FEEDBACK_NAME_ID = '" + Convert.ToString(_obj_Pms_Feedback.FEEDBACK_NAME_ID) + "'" +
                                      " , @FEEDBACK_COMMENTS = '" + Convert.ToString(_obj_Pms_Feedback.FEEDBACK_COMMENTS) + "'" +
                                      " ,@FEEDBACK_DATE = '" + Convert.ToDateTime(_obj_Pms_Feedback.FEEDBACK_DATE).ToString("MM/dd/yyyy") + "'" +
                                      ", @FEEDBACK_LASTMDFBY = " + Convert.ToInt32(_obj_Pms_Feedback.FEEDBACK_LASTMDFBY) +
                                      ", @FEEDBACK_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Pms_Feedback.FEEDBACK_LASTMDFDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;

                    break;
                case 5:
                    if (ExecuteNonQuery("EXEC USP_PMSFEEDBACKS @MODE = 5 ,@FEEDBACK_ID= " + Convert.ToString(_obj_Pms_Feedback.FEEDBACK_ID)
                                      + " "))

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

        #region SPMS_FEEDBK


        /// <summary>
        /// This method is used TO GET FEEDBACKDETAILS BASED ON FEEDBACK_ID
        /// </summary>
        /// <returns>
        /// DataTable WITH FEEDBACK INFORMATION
        /// </returns>
        public static DataTable get_Feedbk(SPMS_FEEDBK _obj_Pms_Feedbk)
        {
            DataTable dt = new DataTable();
            switch (_obj_Pms_Feedbk.Mode)
            {

                case 1:
                    dt = ExecuteQuery("EXEC USP_PMSFEEDBACK @MODE = 1");
                    break;
                case 2:
                    dt = ExecuteQuery("EXEC USP_PMSFEEDBACK @MODE = 2,@FEEDBK_ID = " + Convert.ToString(_obj_Pms_Feedbk.FEEDBK_ID) + " ");
                    break;
                case 6:
                    dt = ExecuteQuery("EXEC USP_PMSFEEDBACK @MODE = 6,@FEEDBK_BUSINESSUNIT_NAME = " + Convert.ToString(_obj_Pms_Feedbk.FEEDBK_BUSINESSUNIT_NAME) + "  ");

                    break;
                default:
                    break;
            }
            return dt;
        }


        //<summary>
        //This Method is used for insertion, deletion and updation of FEEDBACK based upon criteria
        //</summary>
        //<returns>
        //Bool
        //</returns>


        public static bool set_Feedbk(SPMS_FEEDBK _obj_Pms_Feedbk)
        {
            bool status = false;
            switch (_obj_Pms_Feedbk.Mode)
            {
                case 3:
                    if (ExecuteNonQuery("EXEC USP_PMSFEEDBACK @MODE = 3 ,@FEEDBK_BUSINESSUNIT_NAME = " + Convert.ToString(_obj_Pms_Feedbk.FEEDBK_BUSINESSUNIT_NAME) +
                                      " , @FEEDBK_EMPLOYEE_NAME = " + Convert.ToString(_obj_Pms_Feedbk.FEEDBK_EMPLOYEE_NAME) +
                                      " , @FEEDBK_MANAGER_NAME = " + Convert.ToString(_obj_Pms_Feedbk.FEEDBK_MANAGER_NAME) +
                                      " ,@FEEDBK_CREATEDBY = " + Convert.ToInt32(_obj_Pms_Feedbk.FEEDBK_CREATEDBY) +
                                      " , @FEEDBK_CREATEDDATE = '" + Convert.ToDateTime(_obj_Pms_Feedbk.FEEDBK_CREATEDDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case 4:
                    if (ExecuteNonQuery("EXEC USP_PMSFEEDBACK @MODE = 4 , @FEEDBK_ID = " + Convert.ToString(_obj_Pms_Feedbk.FEEDBK_ID) +
                                      " ,  @FEEDBK_BUSINESSUNIT_NAME = " + Convert.ToString(_obj_Pms_Feedbk.FEEDBK_BUSINESSUNIT_NAME) +
                                      " , @FEEDBK_EMPLOYEE_NAME = " + Convert.ToString(_obj_Pms_Feedbk.FEEDBK_EMPLOYEE_NAME) +
                                      " , @FEEDBK_MANAGER_NAME = " + Convert.ToString(_obj_Pms_Feedbk.FEEDBK_MANAGER_NAME) +
                                      " ,@FEEDBK_LASTMDFBY = " + Convert.ToInt32(_obj_Pms_Feedbk.FEEDBK_LASTMDFBY) +
                                      " , @FEEDBK_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Pms_Feedbk.FEEDBK_LASTMDFDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;

                    break;
                case 5:
                    if (ExecuteNonQuery("EXEC USP_PMSFEEDBACK @MODE = 5 ,@FEEDBK_ID= " + Convert.ToString(_obj_Pms_Feedbk.FEEDBK_ID) + " "))


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

        #region SPMS_TEMPALTE


        /// <summary>
        /// This method is used TO GET TEMPALTEDETAILS BASED ON TEMPLATE_ID
        /// </summary>
        /// <returns>
        /// DataTable WITH TEMPLATE  INFORMATION
        /// </returns>
        public static DataTable get_Template(SPMS_TEMPLATE _obj_Pms_Template)
        {
            DataTable dt = new DataTable();
            switch (_obj_Pms_Template.Mode)
            {

                case 1:
                    dt = ExecuteQuery("EXEC USP_PMS_TEMPLATE @MODE = 1");
                    break;
                case 2:
                    dt = ExecuteQuery("EXEC USP_PMS_TEMPLATE @MODE = 2,@EMP_TEMPLATE_ID = " + Convert.ToString(_obj_Pms_Template.EMP_TEMPLATE_ID) + " ");

                    break;
                default:
                    break;
            }
            return dt;
        }


        //<summary>
        //This Method is used for insertion, deletion and updation of KRA based upon criteria
        //</summary>
        //<returns>
        //Bool
        //</returns>


        public static bool set_Template(SPMS_TEMPLATE _obj_Pms_Template)
        {
            bool status = false;
            switch (_obj_Pms_Template.Mode)
            {
                case 3:
                    if (ExecuteNonQuery("EXEC USP_PMS_TEMPLATE @MODE = 3 , @EMP_TEMPLATE_NAME = '" + Convert.ToString(_obj_Pms_Template.EMP_TEMPLATE_NAME) + "'" +
                                      " ,  @BUSINESSUNIT_ID = " + Convert.ToString(_obj_Pms_Template.BUSINESSUNIT_ID) +
                                      " , @EMPLOYEE_ID = " + Convert.ToString(_obj_Pms_Template.EMPLOYEE_ID) +
                                      " , @TEMPLATE_ID = " + Convert.ToString(_obj_Pms_Template.TEMPLATE_ID) +
                                      " , @TEMPLATE_CREATEDBY = " + Convert.ToInt32(_obj_Pms_Template.TEMPLATE_CREATEDBY) +
                                      ", @TEMPLATE_CREATEDDATE = '" + Convert.ToDateTime(_obj_Pms_Template.TEMPLATE_CREATEDDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case 4:
                    if (ExecuteNonQuery("EXEC USP_PMS_TEMPLATE @MODE = 4 , @EMP_TEMPLATE_ID = " + Convert.ToString(_obj_Pms_Template.EMP_TEMPLATE_ID)
                                       + ", @EMP_TEMPLATE_NAME = '" + Convert.ToString(_obj_Pms_Template.EMP_TEMPLATE_NAME) + "'" +
                                      " ,  @BUSINESSUNIT_ID = " + Convert.ToString(_obj_Pms_Template.BUSINESSUNIT_ID) +
                                      " , @EMPLOYEE_ID = " + Convert.ToString(_obj_Pms_Template.EMPLOYEE_ID) +
                                      " , @TEMPLATE_ID = " + Convert.ToString(_obj_Pms_Template.TEMPLATE_ID) +
                                      " ,@TEMPLATE_LASTMDFBY = " + Convert.ToInt32(_obj_Pms_Template.TEMPLATE_LASTMDFBY) +
                                      ", @TEMPLATE_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Pms_Template.TEMPLATE_LASTMDFDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;

                    break;
                case 5:
                    if (ExecuteNonQuery("EXEC USP_PMS_TEMPLATE @MODE = 5 ,@EMP_TEMPLATE_ID = " + Convert.ToString(_obj_Pms_Template.EMP_TEMPLATE_ID)
                                      + " "))

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

        #region SPMS_APPRAISAL TEMPLATE


        public static DataTable get_AppraisalTemplate(SPMS_APPRAISALTEMPLATE _obj_Pms_AppraisalTemplate)
        {
            DataTable dt = new DataTable();
            switch (_obj_Pms_AppraisalTemplate.Mode)
            {

                case 1:
                    dt = ExecuteQuery("EXEC USP_APPRAISAL_TEMPLATE @MODE = 1");
                    break;
                case 2:
                    dt = ExecuteQuery("EXEC USP_APPRAISAL_TEMPLATE @MODE = 2,@APPRAISAL_ID = " + Convert.ToString(_obj_Pms_AppraisalTemplate.APPRAISAL_ID) + " ");

                    break;
                default:
                    break;
            }
            return dt;
        }


        #endregion

        #region SPMS_GOAL


        /// <summary>
        /// This method is used TO GET GOALS BASED ON GOAL_ID
        /// </summary>
        /// <returns>
        /// DataTable WITH GOAL  INFORMATION
        /// </returns>
        public static DataTable get_Goal(SPMS_GOAL _obj_Pms_Goal)
        {
            DataTable dt = new DataTable();
            switch (_obj_Pms_Goal.Mode)
            {

                case 1:
                    dt = ExecuteQuery("EXEC USP_PMS_GOAL @MODE = 1");
                    break;
                case 2:
                    dt = ExecuteQuery("EXEC USP_PMS_GOAL @MODE = 2,@GOAL_ID = " + Convert.ToString(_obj_Pms_Goal.GOAL_ID) + " ");

                    break;
                default:
                    break;
            }
            return dt;
        }


        //<summary>
        //This Method is used for insertion, deletion and updation of GOAL based upon criteria
        //</summary>
        //<returns>
        //Bool
        //</returns>


        public static bool set_Goal(SPMS_GOAL _obj_Pms_Goal)
        {
            bool status = false;
            switch (_obj_Pms_Goal.Mode)
            {
                case 3:
                    if (ExecuteNonQuery("EXEC USP_PMS_GOAL @MODE = 3 , @GOAL_BU_ID= " + Convert.ToString(_obj_Pms_Goal.GOAL_BU_ID) +
                                      " ,@GOAL_EMP_ID= " + Convert.ToString(_obj_Pms_Goal.GOAL_EMP_ID) +
                                     " , @GOAL_APPRISALPERIOD = " + Convert.ToString(_obj_Pms_Goal.GOAL_APPRISALPERIOD) +
                                     " , @GOAL_KRA_ID = " + Convert.ToString(_obj_Pms_Goal.GOAL_KRA_ID) +
                                     " ,@GOAL_NAME = '" + Convert.ToString(_obj_Pms_Goal.GOAL_NAME) + "'" +
                                      " , @GOAL_WEIGHTAGE = " + Convert.ToString(_obj_Pms_Goal.GOAL_WEIGHTAGE) +
                                      " ,@GOAL_TIMELINE = '" + Convert.ToDateTime(_obj_Pms_Goal.GOAL_TIMELINE).ToString("MM/dd/yyyy") + "'" +
                                      " , @GOAL_CREATEDBY = " + Convert.ToInt32(_obj_Pms_Goal.GOAL_CREATEDBY) +
                                      ", @GOAL_CREATEDDATE = '" + Convert.ToDateTime(_obj_Pms_Goal.GOAL_CREATEDDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case 4:
                    if (ExecuteNonQuery("EXEC USP_PMS_GOAL @MODE = 4 , @GOAL_ID = " + Convert.ToString(_obj_Pms_Goal.GOAL_ID)
                                       + ", @GOAL_BU_ID= " + Convert.ToString(_obj_Pms_Goal.GOAL_BU_ID) +
                                      " , @GOAL_EMP_ID= " + Convert.ToString(_obj_Pms_Goal.GOAL_EMP_ID) +
                                     " , @GOAL_APPRISALPERIOD = " + Convert.ToString(_obj_Pms_Goal.GOAL_APPRISALPERIOD) +
                                     " , @GOAL_KRA_ID = " + Convert.ToString(_obj_Pms_Goal.GOAL_KRA_ID) +
                                     " ,@GOAL_NAME = '" + Convert.ToString(_obj_Pms_Goal.GOAL_NAME) + "'" +
                                      " , @GOAL_WEIGHTAGE = " + Convert.ToString(_obj_Pms_Goal.GOAL_WEIGHTAGE) +
                                      " ,@GOAL_TIMELINE = '" + Convert.ToDateTime(_obj_Pms_Goal.GOAL_TIMELINE).ToString("MM/dd/yyyy") + "'" +
                                      " , @GOAL_LASTMDFBY = " + Convert.ToInt32(_obj_Pms_Goal.GOAL_LASTMDFBY) +
                                      ", @GOAL_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Pms_Goal.GOAL_LASTMDFDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;

                    break;
                case 5:
                    if (ExecuteNonQuery("EXEC USP_PMS_GOAL @MODE = 5 ,@GOAL_ID = " + Convert.ToString(_obj_Pms_Goal.GOAL_ID)
                                      + " "))

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

        #region SPMS_ROLES


        /// <summary>
        /// This method is used TO GET ROLES BASED ON ROLE_ID
        /// </summary>
        /// <returns>
        /// DataTable WITH ROLE  INFORMATION
        /// </returns>
        public static DataTable get_Roles(SPMS_ROLES _obj_Pms_Roles)
        {
            DataTable dt = new DataTable();
            switch (_obj_Pms_Roles.Mode)
            {

                case 1:
                    dt = ExecuteQuery("EXEC USP_PMS_ROLES @MODE = 1,@ROLES_ORG_ID= " + Convert.ToString(_obj_Pms_Roles.ROLES_ORG_ID) + ",@EMP_LOGIN_ID= '" + _obj_Pms_Roles.LOGIN_ID + "'");
                    break;
                case 2:
                    dt = ExecuteQuery("EXEC USP_PMS_ROLES @MODE = 2,@ROLE_ID= " + Convert.ToString(_obj_Pms_Roles.ROLES_ID) + " ");

                    break;
                case 6:
                    dt = ExecuteQuery("EXEC USP_PMS_ROLES @MODE = 6,@ROLE_BUSINESSUNIT_ID  = " + Convert.ToString(_obj_Pms_Roles.BUID)
                                       + ",@ROLES_ORG_ID= " + Convert.ToString(_obj_Pms_Roles.ROLES_ORG_ID) + ",@ROLE_NAME= '" + Convert.ToString(_obj_Pms_Roles.ROLES_NAME) + "'" + " ");

                    break;
                case 7:
                    dt = ExecuteQuery("EXEC USP_PMS_ROLES @MODE = 7,@ROLES_ORG_ID= " + Convert.ToString(_obj_Pms_Roles.ROLES_ORG_ID) + ",@ROLE_BUSINESSUNIT_ID  = " + Convert.ToString(_obj_Pms_Roles.BUID)
                                       + ",@ROLE_NAME= '" + Convert.ToString(_obj_Pms_Roles.ROLES_NAME) + "'" + " ");

                    break;

                case 9:
                    dt = ExecuteQuery("EXEC USP_PMS_ROLES @MODE = 9,@ROLES_ORG_ID= " + Convert.ToString(_obj_Pms_Roles.ROLES_ORG_ID) + ",@ROLE_BUSINESSUNIT_ID  = " + Convert.ToString(_obj_Pms_Roles.BUID)
                                       + ",@ROLE_NAME= '" + Convert.ToString(_obj_Pms_Roles.ROLES_NAME) + "'" + " ");

                    break;
                default:
                    break;
            }
            return dt;
        }


        //<summary>
        //This Method is used for insertion, deletion and updation of ROLES based upon criteria
        //</summary>
        //<returns>
        //Bool
        //</returns>


        public static bool set_Roles(SPMS_ROLES _obj_Pms_Roles)
        {
            bool status = false;
            switch (_obj_Pms_Roles.Mode)
            {
                case 3:
                    if (ExecuteNonQuery("EXEC USP_PMS_ROLES @MODE = 3 , @ROLE_NAME = '" + Convert.ToString(_obj_Pms_Roles.ROLES_NAME) + "'" +
                                      " ,@ROLES_ORG_ID= " + Convert.ToString(_obj_Pms_Roles.ROLES_ORG_ID) + ", @ROLE_DESCRIPTION = '" + Convert.ToString(_obj_Pms_Roles.ROLES_DESCRIPTION) + "'" +
                                      " ,@ROLE_CREATED_BY = " + Convert.ToInt32(_obj_Pms_Roles.ROLES_CREATEDBY) +
                                      ", @ROLE_BUSINESSUNIT_ID  = " + Convert.ToString(_obj_Pms_Roles.BUID)
                                       + ", @ROLE_CREATED_DATE = '" + Convert.ToDateTime(_obj_Pms_Roles.ROLES_CREATEDDATE).ToString("MM/dd/yyyy") +
                                       "',@ROLE_ROLEID='" + Convert.ToString(_obj_Pms_Roles.ROLES_ROLEID) + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case 4:
                    if (ExecuteNonQuery("EXEC USP_PMS_ROLES @MODE = 4 , @ROLE_ID  = " + Convert.ToString(_obj_Pms_Roles.ROLES_ID)
                                       + ", @ROLE_NAME = '" + Convert.ToString(_obj_Pms_Roles.ROLES_NAME) + "'" +
                                      " , @ROLE_DESCRIPTION = '" + Convert.ToString(_obj_Pms_Roles.ROLES_DESCRIPTION) + "'" +
                                      " , @ROLE_LASTMDF_BY = " + Convert.ToInt32(_obj_Pms_Roles.ROLES_LASTMDFBY) +
                                      ",@ROLE_BUSINESSUNIT_ID  = " + Convert.ToString(_obj_Pms_Roles.BUID)
                                       + ", @ROLE_LASTMDF_DATE = '" + Convert.ToDateTime(_obj_Pms_Roles.ROLES_LASTMDFDATE).ToString("MM/dd/yyyy") +
                                       "',@ROLE_ROLEID='" + Convert.ToString(_obj_Pms_Roles.ROLES_ROLEID) + "'"))
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

        #region SPMS_GOALS


        /// <summary>
        /// This method is used TO GET GOALS BASED ON GOAL_ID
        /// </summary>
        /// <returns>
        /// DataTable WITH GOALS  INFORMATION
        /// </returns>
        public static DataTable get_Goals(SPMS_GOALS _obj_Pms_Goals)
        {
            DataTable dt = new DataTable();
            switch (_obj_Pms_Goals.Mode)
            {

                case 1:
                    dt = ExecuteQuery("EXEC USP_PMS_GOALS @MODE = 1");
                    break;
                case 2:
                    dt = ExecuteQuery("EXEC USP_PMS_GOALS @MODE = 2,@GOALS_ID = " + Convert.ToString(_obj_Pms_Goals.GOALS_ID) + " ");

                    break;
                default:
                    break;
            }
            return dt;
        }


        //<summary>
        //This Method is used for insertion, deletion and updation of GOAL based upon criteria
        //</summary>
        //<returns>
        //Bool
        //</returns>


        public static bool set_Goals(SPMS_GOALS _obj_Pms_Goals)
        {
            bool status = false;
            switch (_obj_Pms_Goals.Mode)
            {
                case 3:
                    if (ExecuteNonQuery("EXEC USP_PMS_GOALS @MODE = 3 , @GOALS_BU_ID= " + Convert.ToString(_obj_Pms_Goals.GOALS_BU_ID) +
                                      " ,@GOALS_EMP_ID= " + Convert.ToString(_obj_Pms_Goals.GOALS_EMP_ID) +
                                     " , @GOALS_JOB = " + Convert.ToString(_obj_Pms_Goals.GOALS_JOB) +
                                       " ,@GOALS_POSITION = " + Convert.ToString(_obj_Pms_Goals.GOALS_POSITION) +
                                     " ,@GOALS_NAME = '" + Convert.ToString(_obj_Pms_Goals.GOALS_NAME) + "'" +
                                      " ,@GOALS_DESCRIPTION = '" + Convert.ToString(_obj_Pms_Goals.GOALS_DESCRIPTION) + "'" +
                                      " , @GOALS_MEASURE = " + Convert.ToInt32(_obj_Pms_Goals.GOALS_MEASURE) +
                                      " , @GOALS_WEIGHTAGE = " + Convert.ToInt32(_obj_Pms_Goals.GOALS_WEIGHTAGE) +
                                       " , @GOALS_DATE = '" + Convert.ToDateTime(_obj_Pms_Goals.GOALS_DATE).ToString("MM/dd/yyyy") + "'" +
                                      " , @GOALS_CREATEDBY = " + Convert.ToInt32(_obj_Pms_Goals.GOALS_CREATEDBY) +
                                      ", @GOALS_CREATEDDATE = '" + Convert.ToDateTime(_obj_Pms_Goals.GOALS_CREATEDDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case 4:
                    if (ExecuteNonQuery("EXEC USP_PMS_GOALS @MODE = 4 , @GOALS_ID = " + Convert.ToString(_obj_Pms_Goals.GOALS_ID)
                                       + ",@GOALS_BU_ID= " + Convert.ToString(_obj_Pms_Goals.GOALS_BU_ID) +
                                      " ,@GOALS_EMP_ID= " + Convert.ToString(_obj_Pms_Goals.GOALS_EMP_ID) +
                                     " , @GOALS_JOB = " + Convert.ToString(_obj_Pms_Goals.GOALS_JOB) +
                                       " ,@GOALS_POSITION = " + Convert.ToString(_obj_Pms_Goals.GOALS_POSITION) +
                                     " ,@GOALS_NAME = '" + Convert.ToString(_obj_Pms_Goals.GOALS_NAME) + "'" +
                                      " ,@GOALS_DESCRIPTION = '" + Convert.ToString(_obj_Pms_Goals.GOALS_DESCRIPTION) + "'" +
                                      " , @GOALS_MEASURE = " + Convert.ToInt32(_obj_Pms_Goals.GOALS_MEASURE) +
                                      " , @GOALS_WEIGHTAGE = " + Convert.ToInt32(_obj_Pms_Goals.GOALS_WEIGHTAGE) +
                                       " , @GOALS_DATE = '" + Convert.ToDateTime(_obj_Pms_Goals.GOALS_DATE).ToString("MM/dd/yyyy") + "'" +
                                      " ,   @GOALS_LASTMDFBY = " + Convert.ToInt32(_obj_Pms_Goals.GOALS_LASTMDFBY) +
                                      ", @GOALS_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Pms_Goals.GOALS_LASTMDFDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;

                    break;
                case 5:
                    if (ExecuteNonQuery("EXEC USP_PMS_GOALS @MODE = 5 ,@GOALS_ID = " + Convert.ToString(_obj_Pms_Goals.GOALS_ID)
                                      + " "))

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

        #region SPMS_TASK


        /// <summary>
        /// This method is used TO GET TASK BASED ON TASK_ID
        /// </summary>
        /// <returns>
        /// DataTable WITH TASK  INFORMATION
        /// </returns>
        public static DataTable get_Task(SPMS_TASK _obj_Pms_Task)
        {
            DataTable dt = new DataTable();
            switch (_obj_Pms_Task.Mode)
            {

                case 1:
                    dt = ExecuteQuery("EXEC USP_PMS_TASK @MODE = 1,@TASK_ORG_ID = " + Convert.ToString(_obj_Pms_Task.TASK_ORG_ID) + "");
                    break;
                case 2:
                    dt = ExecuteQuery("EXEC USP_PMS_TASK @MODE = 2,@TASK_ID = " + Convert.ToString(_obj_Pms_Task.TASK_ID) + " ");
                    break;
                case 6:
                    dt = ExecuteQuery("EXEC USP_PMS_TASK @MODE = 6,@TASK_ORG_ID = " + Convert.ToString(_obj_Pms_Task.TASK_ORG_ID) + ",@TASK_EMP_ID = " + Convert.ToString(_obj_Pms_Task.TASK_EMP_ID) + " ");
                    break;
                case 7:
                    dt = ExecuteQuery("EXEC USP_PMS_TASK @MODE = 7,@TASK_ORG_ID = " + Convert.ToString(_obj_Pms_Task.TASK_ORG_ID) + ",@TASK_EMP_ID = " + Convert.ToString(_obj_Pms_Task.TASK_EMP_ID) + " ");
                    break;
                case 8:
                    dt = ExecuteQuery("EXEC USP_PMS_TASK @MODE = 8,@TASK_EMP_ID = " + Convert.ToString(_obj_Pms_Task.TASK_EMP_ID) + "  , @TASK_GOAL = " + Convert.ToString(_obj_Pms_Task.TASK_GOAL_ID) +
                                      " ,@TASK_ORG_ID = " + Convert.ToString(_obj_Pms_Task.TASK_ORG_ID) + ",@TASK_NAME= '" + Convert.ToString(_obj_Pms_Task.TASK_NAME) + "'" + " ");
                    break;
                default:
                    break;
            }
            return dt;
        }


        //<summary>
        //This Method is used for insertion, deletion and updation of TASK based upon criteria
        //</summary>
        //<returns>
        //Bool
        //</returns>


        public static bool set_Task(SPMS_TASK _obj_Pms_Task)
        {
            bool status = false;
            switch (_obj_Pms_Task.Mode)
            {
                case 4:
                    if (ExecuteNonQuery("EXEC USP_PMS_TASK @MODE = 4 ,@TASK_ORG_ID = " + Convert.ToString(_obj_Pms_Task.TASK_ORG_ID) + ",@TASK_EMP_ID= " + Convert.ToString(_obj_Pms_Task.TASK_EMP_ID) +
                        //" , @TASK_JOB = " + Convert.ToString(_obj_Pms_Task.TASK_JOB) +
                        //  " ,@TASK_POSITION = " + Convert.ToString(_obj_Pms_Task.TASK_POSITION) +
                                     " ,@TASK_NAME = '" + Convert.ToString(_obj_Pms_Task.TASK_NAME) + "'" +
                                      " ,@TASK_DESCRIPTION = '" + Convert.ToString(_obj_Pms_Task.TASK_DESCRIPTION) + "'" +
                                       " , @TASK_DATE = '" + Convert.ToDateTime(_obj_Pms_Task.TASK_DATE).ToString("MM/dd/yyyy") + "'" +
                                      " , @TASK_GOAL = " + Convert.ToString(_obj_Pms_Task.TASK_GOAL_ID) +
                                      " , @TASK_CREATEDBY = " + Convert.ToInt32(_obj_Pms_Task.TASK_CREATEDBY) +
                                      ", @TASK_CREATEDDATE = '" + Convert.ToDateTime(_obj_Pms_Task.TASK_CREATEDDATE).ToString("MM/dd/yyyy") + "' , @TASK_APPRAISAL_CYCLE = " + Convert.ToString(_obj_Pms_Task.TASK_APPRAISAL_CYCLE) +
                                      " "))
                        status = true;
                    else
                        status = false;
                    break;
                case 5:
                    if (ExecuteNonQuery("EXEC USP_PMS_TASK @MODE = 5 , @TASK_ID = " + Convert.ToString(_obj_Pms_Task.TASK_ID)
                                       + ",@TASK_EMP_ID= " + Convert.ToString(_obj_Pms_Task.TASK_EMP_ID) +
                        //" , @TASK_JOB = " + Convert.ToString(_obj_Pms_Task.TASK_JOB) +
                        //  " ,@TASK_POSITION = " + Convert.ToString(_obj_Pms_Task.TASK_POSITION) +
                                     " ,@TASK_NAME = '" + Convert.ToString(_obj_Pms_Task.TASK_NAME) + "'" +
                                      " ,@TASK_DESCRIPTION = '" + Convert.ToString(_obj_Pms_Task.TASK_DESCRIPTION) + "'" +
                                       " , @TASK_DATE = '" + Convert.ToDateTime(_obj_Pms_Task.TASK_DATE).ToString("MM/dd/yyyy") + "'" +
                                      " , @TASK_GOAL = " + Convert.ToString(_obj_Pms_Task.TASK_GOAL_ID) +
                                      " ,  @TASK_LASTMDFBY = " + Convert.ToInt32(_obj_Pms_Task.TASK_LASTMDFBY) +
                                      ", @TASK_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Pms_Task.TASK_LASTMDFDATE).ToString("MM/dd/yyyy") + "' , @TASK_APPRAISAL_CYCLE = " + Convert.ToString(_obj_Pms_Task.TASK_APPRAISAL_CYCLE) +
                                      " "))
                        status = true;
                    else
                        status = false;

                    break;
                case 6:
                    if (ExecuteNonQuery("EXEC USP_PMS_TASK @MODE = 6 ,@TASK_ID = " + Convert.ToString(_obj_Pms_Task.TASK_ID)
                                      + " "))

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

        #region SPMS_PERIODICFEEDBACK


        /// <summary>
        /// This method is used TO GET TASK BASED ON TASK_ID
        /// </summary>
        /// <returns>
        /// DataTable WITH TASK  INFORMATION
        /// </returns>
        public static DataTable get_PeriodicFeedback(SPMS_PERIODICFEEDBACK _obj_Pms_PeriodicFeedback)
        {
            DataTable dt = new DataTable();
            switch (_obj_Pms_PeriodicFeedback.Mode)
            {

                case 1:
                    dt = ExecuteQuery("EXEC USP_PMS_PERIODIC_FEEDBACK @MODE = 1");
                    break;
                case 2:
                    dt = ExecuteQuery("EXEC USP_PMS_PERIODIC_FEEDBACK @MODE = 2,@PF_EMP_ID = " + Convert.ToString(_obj_Pms_PeriodicFeedback.PF_EMP_ID) + " ");
                    break;
                case 5:
                    dt = ExecuteQuery("EXEC USP_PMS_PERIODIC_FEEDBACK @MODE = 5,@PF_PM_ID = " + Convert.ToString(_obj_Pms_PeriodicFeedback.PF_PM_ID) + ",@PF_ORGANISATION_ID = " + Convert.ToString(_obj_Pms_PeriodicFeedback.PF_ORGANISATION_ID) + ",@PF_TASK_ID = " + Convert.ToString(_obj_Pms_PeriodicFeedback.PF_TASK_ID) + ",@PF_EMP_ID = " + Convert.ToString(_obj_Pms_PeriodicFeedback.PF_EMP_ID) + ",@APPCYCLE_ID='" + Convert.ToInt32(_obj_Pms_PeriodicFeedback.GSLIFECYCLE) + "'");
                    break;
                case 6:
                    dt = ExecuteQuery("EXEC USP_PMS_PERIODIC_FEEDBACK @MODE = 6,@PF_FEEDBACK_ID = " + Convert.ToString(_obj_Pms_PeriodicFeedback.PF_FEEDBACK_ID) + " ");
                    break;
                case 7:
                    dt = ExecuteQuery("EXEC USP_PMS_PERIODIC_FEEDBACK @MODE = 7,@PF_PM_ID = " + Convert.ToString(_obj_Pms_PeriodicFeedback.PF_PM_ID) + ",@PF_ORGANISATION_ID = " + Convert.ToString(_obj_Pms_PeriodicFeedback.PF_ORGANISATION_ID) + ",@PF_TASK_ID = " + Convert.ToString(_obj_Pms_PeriodicFeedback.PF_TASK_ID) + ",@PF_EMP_ID = " + Convert.ToString(_obj_Pms_PeriodicFeedback.PF_EMP_ID) + " ,@APPCYCLE_ID='" + Convert.ToInt32(_obj_Pms_PeriodicFeedback.GSLIFECYCLE) + "'");
                    break;
                default:
                    break;
            }
            return dt;
        }


        //<summary>
        //This Method is used for insertion, deletion and updation of TASK based upon criteria
        //</summary>
        //<returns>
        //Bool
        //</returns>


        public static bool set_PeriodicFeedback(SPMS_PERIODICFEEDBACK _obj_Pms_PeriodicFeedback)
        {
            bool status = false;
            switch (_obj_Pms_PeriodicFeedback.Mode)
            {
                case 3:
                    if (ExecuteNonQuery("EXEC USP_PMS_PERIODIC_FEEDBACK @MODE = 3 ,@PF_EMP_ID= " + Convert.ToString(_obj_Pms_PeriodicFeedback.PF_EMP_ID) +
                                     " ,@PF_PM_ID = '" + Convert.ToString(_obj_Pms_PeriodicFeedback.PF_PM_ID) + "'" +
                                      " ,@PF_FEEDBACK_ID = '" + Convert.ToString(_obj_Pms_PeriodicFeedback.PF_FEEDBACK_ID) + "'" +
                                       " , @PF_TASK_ID = '" + Convert.ToString(_obj_Pms_PeriodicFeedback.PF_TASK_ID) + "'" +
                                      " ,  @PF_ORGANISATION_ID = " + Convert.ToInt32(_obj_Pms_PeriodicFeedback.PF_ORGANISATION_ID) +
                                      " , @PF_CREATEDBY = " + Convert.ToInt32(_obj_Pms_PeriodicFeedback.PF_CREATEDBY) +
                                      ", @PF_CREATEDDATE = '" + Convert.ToDateTime(_obj_Pms_PeriodicFeedback.PF_CREATEDDATE).ToString("MM/dd/yyyy") + "'" +
                                      ",@APPCYCLE_ID= '" + Convert.ToInt32(_obj_Pms_PeriodicFeedback.GSLIFECYCLE) + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case 4:
                    if (ExecuteNonQuery("EXEC USP_PMS_PERIODIC_FEEDBACK @MODE = 4 , @PF_EMP_ID= " + Convert.ToString(_obj_Pms_PeriodicFeedback.PF_EMP_ID) +
                                     " ,@PF_TASK_ID = '" + Convert.ToString(_obj_Pms_PeriodicFeedback.PF_TASK_ID) + "'" +
                                      " ,@PF_MGR_FEEDBACK = '" + Convert.ToString(_obj_Pms_PeriodicFeedback.PF_MGR_FEEDBACK) + "'" +
                                       " , @PF_MGR_EMP_ID = '" + Convert.ToString(_obj_Pms_PeriodicFeedback.PF_MGR_EMP_ID) + "'" +
                                      " , @PF_MGR_RATING = " + Convert.ToInt32(_obj_Pms_PeriodicFeedback.PF_MGR_RATING) +
                                      " , @PF_ORGANISATION_ID = " + Convert.ToInt32(_obj_Pms_PeriodicFeedback.PF_ORGANISATION_ID) +
                                      " ,  @PF_LASTMDFBY = " + Convert.ToInt32(_obj_Pms_PeriodicFeedback.PF_LASTMDFBY) +
                                      ", @PF_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Pms_PeriodicFeedback.PF_LASTMDFDATE).ToString("MM/dd/yyyy") + "'"))
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

        #region SPMS_GOALSETTING


        /// <summary>
        /// This method is used TO GET GOALS BASED ON GOAL_ID
        /// </summary>
        /// <returns>
        /// DataTable WITH GOAL  INFORMATION
        /// </returns>
        public static DataTable get_GoalSetting(SPMS_GOALSETTING _obj_Pms_GoalSetting)
        {
            DataTable dt = new DataTable();
            switch (_obj_Pms_GoalSetting.Mode)
            {

                case 1:
                    dt = ExecuteQuery("EXEC USP_PMS_GOALSETTING_DETAIL @MODE = 1");
                    break;
                case 10:
                    dt = ExecuteQuery("EXEC USP_PMS_GOALSETTING_DETAIL @MODE = 10,@GSDTL_ORG_ID= " + Convert.ToString(_obj_Pms_GoalSetting.CREATEDBY) + ",@empid= " + Convert.ToString(_obj_Pms_GoalSetting.GSDTL_ID) + ",@apprycycle_id= " + Convert.ToString(_obj_Pms_GoalSetting.BU_ID) + " ");
                    break;
                default:
                    break;
            }
            return dt;
        }
        #endregion

        #region SPMS_ROLEKRA


        /// <summary>
        /// This method is used TO GET ROLES BASED ON ROLE_ID
        /// </summary>
        /// <returns>
        /// DataTable WITH ROLE  INFORMATION
        /// </returns>
        public static DataTable get_RoleKra(SPMS_ROLEKRA _obj_Pms_RoleKra)
        {
            DataTable dt = new DataTable();
            switch (_obj_Pms_RoleKra.Mode)
            {

                case 1:
                    dt = ExecuteQuery("EXEC USP_PMS_ROLEKRA @MODE = 1,@ROLEKRA_ORG_ID= " + Convert.ToString(_obj_Pms_RoleKra.ROLEKRA_ORG_ID) + "");
                    break;
                case 2:
                    dt = ExecuteQuery("EXEC USP_PMS_ROLEKRA @MODE = 2,@ROLEKRA_ID= " + Convert.ToString(_obj_Pms_RoleKra.ROLEKRA_ID) + " ");

                    break;
                case 6:
                    //dt = ExecuteQuery("EXEC USP_PMS_ROLEKRA @MODE = 6,@ROLEKRA_ORG_ID= " + Convert.ToString(_obj_Pms_RoleKra.ROLEKRA_ORG_ID) + ",@ROLE_ID= " + Convert.ToString(_obj_Pms_RoleKra.ROLE_ID) + " ");
                    dt = ExecuteQuery("EXEC USP_PMS_ROLEKRA @MODE = 6, @ROLEKRA_ORG_ID= " + Convert.ToString(_obj_Pms_RoleKra.ROLEKRA_ORG_ID) + ",@ROLE_ID= " + Convert.ToString(_obj_Pms_RoleKra.ROLE_ID) 
                                            + ", @PMS_Type =" + _obj_Pms_RoleKra.PMS_Type );
                    break;
                case 8:
                    dt = ExecuteQuery("EXEC USP_PMS_ROLEKRA @MODE = 8,@ROLEKRA_ORG_ID= " + Convert.ToString(_obj_Pms_RoleKra.ROLEKRA_ORG_ID) + ",@ROLE_ID= " + Convert.ToString(_obj_Pms_RoleKra.ROLE_ID) + ",@ROLE_KRA_ID= " + Convert.ToString(_obj_Pms_RoleKra.ROLE_KRA_ID) + " ");

                    break;
                case 9:
                    dt = ExecuteQuery("EXEC USP_PMS_ROLEKRA @MODE = 9,@ROLEKRA_ORG_ID= " + Convert.ToString(_obj_Pms_RoleKra.ROLEKRA_ORG_ID) + ",@ROLE_ID= " + Convert.ToString(_obj_Pms_RoleKra.ROLE_ID) + ",@ROLEKRA_ID= " + Convert.ToString(_obj_Pms_RoleKra.ROLEKRA_ID) + " ");

                    break;
                case 10:
                    //To fetch KRA_Objectives
                    dt = ExecuteQuery("EXEC USP_PMS_ROLEKRA @MODE =" + _obj_Pms_RoleKra.Mode + ",@ROLEKRA_ORG_ID= " + Convert.ToString(_obj_Pms_RoleKra.ROLEKRA_ORG_ID) + ",@ROLEKRA_ID= " + Convert.ToString(_obj_Pms_RoleKra.ROLEKRA_ID));
                    break;
                case 11:
                    //To fetch all KRA's, Competencies, Values for the selected criteria
                    dt = ExecuteQuery("EXEC USP_PMS_ROLEKRA @MODE =" + _obj_Pms_RoleKra.Mode + 
                                ", @ROLEKRA_ORG_ID= " + _obj_Pms_RoleKra.ROLEKRA_ORG_ID + 
                                ", @ROLE_ID= " + _obj_Pms_RoleKra.ROLE_ID +
                                ", @PMS_BU_ID=" + _obj_Pms_RoleKra.BUID);
                    break;
                case 12:
                    dt = ExecuteQuery("EXEC USP_PMS_ROLEKRA @MODE = 12, @ROLEKRA_ORG_ID= " + _obj_Pms_RoleKra.ROLEKRA_ORG_ID + 
                                            ", @ROLE_ID= " + _obj_Pms_RoleKra.ROLE_ID  +
                                            ", @PMS_BU_ID =" + _obj_Pms_RoleKra.BUID);
                    break;
                default:
                    break;
            }
            return dt;
        }
              
        #endregion

        #region SPMS_EmpGOALSetting


        /// <summary>
        /// This method is used TO GET GOALS BASED ON GOAL_ID
        /// </summary>
        /// <returns>
        /// DataTable WITH GOAL  INFORMATION
        /// </returns>
        public static DataTable get_EmpGoalSetting(SPMS_EMPGOALSETTING _obj_Pms_EmpGoalSetting)
        {
            DataTable dt = new DataTable();
            switch (_obj_Pms_EmpGoalSetting.Mode)
            {

                case 1:
                    dt = ExecuteQuery("EXEC USP_GOAL_SETTING @MODE = 1");
                    break;
                case 8:
                    dt = ExecuteQuery("EXEC USP_GOAL_SETTING @MODE = 8 , @GS_EMP_ID= " + Convert.ToString(_obj_Pms_EmpGoalSetting.GS_EMP_ID)
                                      + ", @GS_ORGANISATION_ID= " + Convert.ToString(_obj_Pms_EmpGoalSetting.CREATEDBY)
                                      + " , @GS_APPRAISAL_CYCLE= " + Convert.ToString(_obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE)
                                      + " ");
                    break;
                case 10://done
                    dt = ExecuteQuery("EXEC USP_GOAL_SETTING @MODE = 10 , @GS_EMP_ID= " + Convert.ToString(_obj_Pms_EmpGoalSetting.GS_EMP_ID)
                                      + " , @GS_ORGANISATION_ID= " + Convert.ToString(_obj_Pms_EmpGoalSetting.CREATEDBY)
                                      + " , @GS_APPRAISAL_CYCLE= " + Convert.ToString(_obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE)
                                      + "  ");
                    break;
                case 11:
                    dt = ExecuteQuery("EXEC USP_GOAL_SETTING @MODE = 11,@BU_ID= " + Convert.ToString(_obj_Pms_EmpGoalSetting.BU_ID) +
                                      " ");
                    break;
                case 15:
                    dt = ExecuteQuery("EXEC USP_GOAL_SETTING @MODE = 15 , @GS_EMP_ID= " + Convert.ToString(_obj_Pms_EmpGoalSetting.GS_EMP_ID)
                                      + ", @GS_ORGANISATION_ID= " + Convert.ToString(_obj_Pms_EmpGoalSetting.CREATEDBY)
                                      + ", @GS_APPRAISAL_CYCLE= " + Convert.ToString(_obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE)
                                      + " ");
                    break;
                case 16:
                    dt = ExecuteQuery("EXEC USP_GOAL_SETTING @MODE = 16 , @GS_EMP_ID= " + Convert.ToString(_obj_Pms_EmpGoalSetting.GS_EMP_ID)
                                      + ", @GS_ORGANISATION_ID= " + Convert.ToString(_obj_Pms_EmpGoalSetting.CREATEDBY)
                                      + ", @GS_APPRAISAL_CYCLE= " + Convert.ToString(_obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE)
                                      + " ");
                    break;
                case 36:
                    dt = ExecuteQuery("EXEC USP_GOAL_SETTING @MODE =" + _obj_Pms_EmpGoalSetting.Mode + ", @GS_EMP_ID= " + _obj_Pms_EmpGoalSetting.GS_EMP_ID
                                      + ", @GS_ORGANISATION_ID= " + _obj_Pms_EmpGoalSetting.ORGANISATION_ID
                                      + ", @BU_ID = " + _obj_Pms_EmpGoalSetting.BU_ID);
                    break;
                default:
                    break;
            }
            return dt;
        }


        public static bool set_EmpGoalSetting(SPMS_EMPGOALSETTING _obj_Pms_EmpGoalSetting)
        {
            bool status = false;
            switch (_obj_Pms_EmpGoalSetting.Mode)
            {
                case 14:
                    if (ExecuteNonQuery("EXEC USP_GOAL_SETTING @MODE = 14 ,@GS_EMP_ID= " + Convert.ToString(_obj_Pms_EmpGoalSetting.GS_EMP_ID)
                                      + " ,@GS_APPRAISAL_CYCLE= " + Convert.ToString(_obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE)
                                      + " "))
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

        #region SPMS_APPRAISAL


        public static DataTable get_Appraisal(SPMS_APPRAISAL _obj_Spms_Appraisal)
        {
            DataTable dt = new DataTable();
            switch (_obj_Spms_Appraisal.Mode)
            {

                case 1:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL @MODE = 1");
                    break;
                case 5:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL @MODE = 5,@APPRAISAL_ORGANISATION_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID) + ",@APPRAISAL_EMP_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_EMP_ID) + " , @APPRAISAL_APPRAISALCYCLE = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE) + "'" +
                                      "  ");

                    break;
                case 2:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL @MODE = 2,@APPRAISAL_ORGANISATION_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID) + ",@APPRAISAL_EMP_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_EMP_ID) + ",@APPRAISAL_APPRAISALCYCLE = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE) + " ");

                    break;
                case 8:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL @MODE = 8,@APPRAISAL_EMP_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_EMP_ID) + ",@APPRAISAL_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_ID) + " ");

                    break;
                case 11:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL @MODE = 11,@APPRAISAL_EMP_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_EMP_ID) + " , @APPRAISAL_APPRAISALCYCLE = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE) + "'" +
                                      " ");

                    break;
                case 12:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL @MODE = 12,@APPRAISAL_ORGANISATION_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID) + ",@APPRAISAL_EMP_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_EMP_ID) + " , @APPRAISAL_APPRAISALCYCLE = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE) + "'" +
                                      " ");

                    break;
                case 10:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL @MODE = 10,@APPRAISAL_ORGANISATION_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID) + ",@APPRAISAL_EMP_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_EMP_ID) + " , @APPRAISAL_APPRAISALCYCLE = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE) + "'" +
                                      " ");

                    break;
                case 9:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL @MODE = 9,@APPRAISAL_EMP_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_EMP_ID) + " ");

                    break;
                case 14:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL @MODE = 14,@APPRAISAL_EMP_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_EMP_ID) + " ");

                    break;
                case 15:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL @MODE = 15,@APPRAISAL_EMP_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_EMP_ID) + " ");

                    break;
                case 16:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL @MODE = 16,@APPRAISAL_EMP_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_EMP_ID) + " ");

                    break;
                case 17:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL @MODE = 17,@APPRAISAL_EMP_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_EMP_ID) + " ");

                    break;
                case 18:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL @MODE = 18,@APPRAISAL_EMP_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_EMP_ID) + " ");

                    break;
                case 19:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL @MODE = 19,@APPRAISAL_ORGANISATION_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID) + ",@BU_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_BUSSINESS_UNIT) + " , @APPRAISAL_APPRAISALCYCLE = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE) + "'" +
                                      " ");

                    break;
                case 20:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL @MODE = 20,@APPRAISAL_EMP_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_EMP_ID) + " ");

                    break;
                case 21:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL @MODE = 21,@APPRAISAL_EMP_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_EMP_ID) + " ");

                    break;
                case 22:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL @MODE = 22,@APPRAISAL_ORGANISATION_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID) + ",@APPRAISAL_EMP_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_EMP_ID) + " , @APPRAISAL_APPRAISALCYCLE = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE) + "'" +
                                      " ");

                    break;
                case 23:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL @MODE = 23,@APPRAISAL_ORGANISATION_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID) + ",@APPRAISAL_EMP_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_EMP_ID) + " , @APPRAISAL_APPRAISALCYCLE = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE) + "'" +
                                      " ");

                    break;
                case 24:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL @MODE = 24,@APPRAISAL_ORGANISATION_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID) + ",@BU_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_BUSSINESS_UNIT) + " , @APPRAISAL_APPRAISALCYCLE = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE) + "'" +
                                      "  ");

                    break;
                case 25:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL @MODE = 25,@APPRAISAL_ORGANISATION_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID) + ",@BU_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_BUSSINESS_UNIT) + " , @APPRAISAL_APPRAISALCYCLE = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE) + "' ,@APPRAISAL_EMP_ID= '" + _obj_Spms_Appraisal.EMP_ID + "'" +
                                      " ");

                    break;
                case 26:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL @MODE = 26,@APPRAISAL_ORGANISATION_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID) + ",@BU_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_BUSSINESS_UNIT) + " , @APPRAISAL_APPRAISALCYCLE = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE) + "'" +
                                      " ");

                    break;
                case 27:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL @MODE = 27,@APPRAISAL_ORGANISATION_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID) + ",@APPRAISAL_EMP_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_EMP_ID) + " , @APPRAISAL_APPRAISALCYCLE = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE) + "'" +
                                      " ");

                    break;
                case 29:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL @MODE = 29,@APPRAISAL_ORGANISATION_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID) + ",@BU_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_BUSSINESS_UNIT) + " , @APPRAISAL_APPRAISALCYCLE = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE) + "'" +
                                      " ");

                    break;
                case 30:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL @MODE = 30,@APPRAISAL_ORGANISATION_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID) + ",@APPRAISAL_EMP_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_EMP_ID) + " , @APPRAISAL_APPRAISALCYCLE = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE) + "'" +
                                      ",@APP_ROLEKRA_ID='" + Convert.ToInt32(_obj_Spms_Appraisal.APP_ROLEKRA_ID) + "'");

                    break;
                case 31:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL @MODE = 31,@APPRAISAL_ORGANISATION_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID) + ",@APPRAISAL_EMP_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_EMP_ID) + " , @APPRAISAL_APPRAISALCYCLE = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE) + "'" +
                                       ",@APP_ROLEKRA_ID='" + Convert.ToInt32(_obj_Spms_Appraisal.APP_ROLEKRA_ID) + "',@APPRAISAL_CREATEDBY=" + _obj_Spms_Appraisal.APPRAISAL_CREATEDBY + "");

                    break;
                case 43:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL @MODE = 43,@APPRAISAL_ORGANISATION_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID) + ",@APPRAISAL_EMP_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_EMP_ID) + " , @APPRAISAL_APPRAISALCYCLE = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE) + "'" +
                                      ",@APP_ROLEKRA_ID='" + Convert.ToInt32(_obj_Spms_Appraisal.APP_ROLEKRA_ID) + "'");

                    break;
                case 34:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL @MODE = 34,@APPRAISAL_ORGANISATION_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID) + ",@APPRAISAL_EMP_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_EMP_ID) + " , @APPRAISAL_APPRAISALCYCLE = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE) + "'" +
                                      " ");

                    break;
                case 35:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL @MODE = 35,@APPRAISAL_ORGANISATION_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID) + ",@APPRAISAL_EMP_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_EMP_ID) + " , @APPRAISAL_APPRAISALCYCLE = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE) + "'" +
                                      " ");

                    break;
                case 36:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL @MODE = 36,@APPRAISAL_ORGANISATION_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID) + ",@APPRAISAL_EMP_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_EMP_ID) + " , @APPRAISAL_APPRAISALCYCLE = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE) + "'" +
                                      " ");

                    break;
                case 37:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL @MODE = 37,@APPRAISAL_ORGANISATION_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID) + ",@APPRAISAL_EMP_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_EMP_ID) + " , @APPRAISAL_APPRAISALCYCLE = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE) + "'" +
                                      " ");

                    break;

                case 40:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL @MODE = 40,@APPRAISAL_ORGANISATION_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID) + ",@APPRAISAL_EMP_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_EMP_ID) + " , @APPRAISAL_APPRAISALCYCLE = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE) + "'" +
                                      " ");

                    break;
                case 41:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL @MODE = 41,@APPRAISAL_EMP_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_EMP_ID) + " , @APPRAISAL_APPRAISALCYCLE = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE) + "'" +
                                      " ");
                    break;
                case 42:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL @MODE = 42,@APPRAISAL_ORGANISATION_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID) + ",@APPRAISAL_EMP_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_EMP_ID) + " , @APPRAISAL_APPRAISALCYCLE = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE) + "'" +
                                      " ");

                   
                    break;
                case 45:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL @MODE = 45,@APPRAISAL_ORGANISATION_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID) + ",@APPRAISAL_EMP_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_EMP_ID) + " , @APPRAISAL_APPRAISALCYCLE = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE) + "'" +
                                      "  ");

                    break;
                case 47:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL @MODE = 47,@APPRAISAL_ORGANISATION_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID) + ",@APPRAISAL_EMP_ID = " + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_EMP_ID) + " , @APPRAISAL_APPRAISALCYCLE = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE) + "'" +
                                      "  ");

                    break;
                default:
                    break;
            }
            return dt;
        }

        public static bool set_Appraisal(SPMS_APPRAISAL _obj_Spms_Appraisal)
        {
            bool status = false;
            switch (_obj_Spms_Appraisal.Mode)
            {
                case 4:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL @MODE = 4 , @APPRAISAL_EMP_ID = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_EMP_ID) + "'" +
                                      " ,  @APPRAISAL_DATE = '" + Convert.ToDateTime(_obj_Spms_Appraisal.APPRAISAL_DATE).ToString("MM/dd/yyyy") + "'" +
                                      " , @APPRAISAL_ORGANISATION_ID = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID) + "'" +
                                      " ,@APPRAISAL_APPROVALSTAGE = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE) + "'" +
                                       " , @APPRAISAL_APPRAISALCYCLE = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE) + "'" +
                                      " ,@APPRAISAL_STATUS = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_STATUS) + "'" +
                                       " ,  @APPRAISAL_CREATEDBY = " + Convert.ToInt32(_obj_Spms_Appraisal.APPRAISAL_CREATEDBY) +
                                      ", @APPRAISAL_CREATEDDATE = '" + Convert.ToDateTime(_obj_Spms_Appraisal.APPRAISAL_CREATEDDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;
                    break;

                case 6:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL @MODE = 6 ,@APPRAISAL_ID = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_ID) + "'" +
                                      " , @APPRAISAL_EMP_ID = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_EMP_ID) + "'" +
                                      " ,  @APPRAISAL_DATE = '" + Convert.ToDateTime(_obj_Spms_Appraisal.APPRAISAL_DATE).ToString("MM/dd/yyyy") + "'" +
                                      " , @APPRAISAL_ORGANISATION_ID = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID) + "'" +
                                      " ,@APPRAISAL_APPROVALSTAGE = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE) + "'" +
                                       " , @APPRAISAL_APPRAISALCYCLE = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE) + "'" +
                                      " ,@APPRAISAL_STATUS = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_STATUS) + "'" +
                                       " ,  @APPRAISAL_CREATEDBY = " + Convert.ToInt32(_obj_Spms_Appraisal.APPRAISAL_CREATEDBY) +
                                      ", @APPRAISAL_CREATEDDATE = '" + Convert.ToDateTime(_obj_Spms_Appraisal.APPRAISAL_CREATEDDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case 28:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL @MODE = 28, @APPRAISAL_EMP_ID = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_EMP_ID) + "'" +
                                      " , @APPRAISAL_ORGANISATION_ID = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID) + "'" +
                                      " , @APPRAISAL_APPRAISALCYCLE = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE) + "'" +
                                      "   "))
                        status = true;
                    else
                        status = false;
                    break;
                case 32:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL @MODE = 32,@APPRAISAL_KRA_AVGRTG = " + Convert.ToDecimal(_obj_Spms_Appraisal.APPRAISAL_KRA_AVGRTG) +
                                      " , @APPRAISAL_ORGANISATION_ID = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID) + "'" +
                                      " , @APPRAISAL_EMP_ID = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_EMP_ID) + "'" +
                                      "  , @APPRAISAL_APPRAISALCYCLE = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE) + "'" +
                                      "   "))
                        status = true;
                    else
                        status = false;
                    break;
                case 33:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL @MODE = 33,@APPRAISAL_GOAL_AVGRTG = " + Convert.ToDecimal(_obj_Spms_Appraisal.APPRAISAL_GOAL_AVGRTG) +
                                      "  , @APPRAISAL_ORGANISATION_ID = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID) + "'" +
                                      ", @APPRAISAL_EMP_ID = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_EMP_ID) + "'" +
                                      " , @APPRAISAL_APPRAISALCYCLE = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE) + "'" +
                                      "    "))
                        status = true;
                    else
                        status = false;
                    break;
                case 44:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL @MODE = 44, @APPRAISAL_EMP_ID = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_EMP_ID) + "'" +
                                      " , @APPRAISAL_ORGANISATION_ID = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID) + "'" +
                                      " , @APPRAISAL_APPRAISALCYCLE = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE) + "'" +
                                      ",  @APPRAISAL_APPROVALSTAGE= '" +  Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE) + "'" +
                                      ",  @APPRAISAL_STATUS = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_STATUS) + "'" +
                                      ",  @APPRAISAL_LASTMDFBY = '" + Convert.ToInt32(_obj_Spms_Appraisal.APPRAISAL_LASTMDFBY) + "'" +
                                      ",  @APPRAISAL_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Spms_Appraisal.APPRAISAL_LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
                                      " "))
                        status = true;
                    else
                        status = false;
                    break;
                case 46:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL @MODE = 46, @APPRAISAL_EMP_ID = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_EMP_ID) + "'" +
                                      " , @APPRAISAL_ORGANISATION_ID = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID) + "'" +
                                      " , @APPRAISAL_APPRAISALCYCLE = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE) + "'" +
                                      ",  @APPRAISAL_GOAL_AVGRTG= '" + Convert.ToDecimal(_obj_Spms_Appraisal.APPRAISAL_GOAL_AVGRTG) + "'" +
                                      ",  @APPRAISAL_KRA_AVGRTG = '" + Convert.ToDecimal(_obj_Spms_Appraisal.APPRAISAL_KRA_AVGRTG) + "'" +
                                      ",  @APPRAISAL_IDP_AVGRTG = '" + Convert.ToDecimal(_obj_Spms_Appraisal.APPRAISAL_IDP_AVGRTG) + "'" +
                                      ",  @APPRAISAL_AVGRTG = '" + Convert.ToDecimal(_obj_Spms_Appraisal.APPRAISAL_AVGRTG) + "'" +
                                      ",  @APPRAISAL_LASTMDFBY = '" + Convert.ToInt32(_obj_Spms_Appraisal.APPRAISAL_LASTMDFBY) + "'" +
                                      ",  @APPRAISAL_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Spms_Appraisal.APPRAISAL_LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
                                      " "))
                        status = true;
                    else
                        status = false;
                    break;
                case 48:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL @MODE = 48, @APPRAISAL_EMP_ID = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_EMP_ID) + "'" +
                                      " , @APPRAISAL_ORGANISATION_ID = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID) + "'" +
                                      " , @APPRAISAL_APPRAISALCYCLE = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE) + "'" +
                                      ",  @APPRAISAL_STATUS = '" + Convert.ToString(_obj_Spms_Appraisal.APPRAISAL_STATUS) + "'" +
                                      ",  @APPRAISAL_LASTMDFBY = '" + Convert.ToInt32(_obj_Spms_Appraisal.APPRAISAL_LASTMDFBY) + "'" +
                                      ",  @APPRAISAL_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Spms_Appraisal.APPRAISAL_LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
                                      " "))
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

        #region SPMS_APPRAISALGOAL


        public static DataTable get_AppraisalGoal(SPMS_APPRAISALGOAL _obj_Spms_AppraisalGoal)
        {
            DataTable dt = new DataTable();
            switch (_obj_Spms_AppraisalGoal.Mode)
            {

                case 1:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL_GOALS @MODE = 1");
                    break;
                case 5:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL_GOALS @MODE = 5,@APP_GOALS_GSDTL_ID = " + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID) + ", @APP_GOALS_LASTMDFBY = '" + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFBY) + "'" +
                                      ",@APP_GOAL_ORG_ID = " + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID) + " ,@APP_GOALS_ID = " + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_ID) + "  ");

                    break;
                case 7:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL_GOALS @MODE = 7,@APP_GOAL_ORG_ID = " + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID) + ",@APP_GOALS_APP_ID = '" + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_APP_ID) + "'" +
                                      " ");
                    break;
                case 8:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL_GOALS @MODE = 8,@APP_GOAL_ORG_ID = " + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID) + ",@APP_GOALS_GSDTL_ID = " + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID) + ",@APP_GOALS_APP_ID = '" + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_APP_ID) + "'" +
                                      "  ");

                    break;
                case 10:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL_GOALS @MODE = 10,@APP_GOALS_GSDTL_ID = " + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID) + "  ");

                    break;
                case 11:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL_GOALS @MODE = 11,@APP_GOAL_ORG_ID = " + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID) + ",@APP_GOALS_GSDTL_ID = " + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID) + "  ");

                    break;
                case 13:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL_GOALS @MODE = 13,@APP_GOALS_APP_ID = " + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_APP_ID) + ",@APP_GOAL_ORG_ID = " + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID) + "  ");

                    break;
                case 14:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL_GOALS @MODE = 14,@APP_GOALS_APP_ID = " + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_APP_ID) + ",@APP_GOAL_ORG_ID = " + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID) + "  ");

                    break;
                default:
                    break;
            }
            return dt;
        }


        public static bool set_AppraisalGoal(SPMS_APPRAISALGOAL _obj_Spms_AppraisalGoal)
        {
            bool status = false;
            switch (_obj_Spms_AppraisalGoal.Mode)
            {
                case 3:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL_GOALS @MODE = 3 , @APP_GOALS_APP_ID = '" + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_APP_ID) + "'" +
                                      " ,@APP_GOAL_ORG_ID = " + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID) + ",  @APP_GOALS_GSDTL_ID= '" + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID) + "'" +
                                      " ,@APP_GOALS_EMP_COMMENTS = '" + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_EMP_COMMENTS) + "'" +
                                       " , @APP_GOALS_MGR_COMMENTS = '" + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_MGR_COMMENTS) + "'" +
                                      " , @APP_GOALS_MGR_RATING = " + Convert.ToDecimal(_obj_Spms_AppraisalGoal.APP_GOALS_MGR_RATING) +
                                      " , @APP_GOALS_CREATEDBY = " + Convert.ToInt32(_obj_Spms_AppraisalGoal.APP_GOALS_CREATEDBY) +
                                      " , @APP_GOALS_LASTMDFBY = " + Convert.ToInt32(_obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFBY) +
                                      ", @APP_GOALS_CREATEDDATE = '" + Convert.ToDateTime(_obj_Spms_AppraisalGoal.APP_GOALS_CREATEDDATE).ToString("MM/dd/yyyy") +

                                        "',  @APP_GOALS_FINAL = '" + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_FINAL) + "'" +
                                      " ,@APP_GOALS_FIXED = '" + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_FIXED) + "'" + ""))
                        status = true;
                    else
                        status = false;
                    break;
                case 4:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL_GOALS @MODE = 4 , @APP_GOALS_ID  = " + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_ID)
                                       + ",  @APP_GOALS_APP_ID = '" + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_APP_ID) + "'" +
                                      " ,  @APP_GOALS_GSDTL_ID= '" + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID) + "'" +
                                      " ,@APP_GOALS_EMP_COMMENTS = '" + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_EMP_COMMENTS) + "'" +
                                       " , @APP_GOALS_MGR_COMMENTS = '" + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_MGR_COMMENTS) + "'" +
                                      " , @APP_GOALS_MGR_RATING = " + Convert.ToInt32(_obj_Spms_AppraisalGoal.APP_GOALS_MGR_RATING) +
                                      " ,@APP_GOALS_LASTMDFBY = " + Convert.ToInt32(_obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFBY) +
                                      ", @APP_GOALS_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;

                    break;
                case 6:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL_GOALS @MODE = 6 , @APP_GOALS_APP_ID = '" + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_APP_ID) + "'" +
                                      "  ,@APP_GOAL_ORG_ID = " + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID) + ",  @APP_GOALS_GSDTL_ID= '" + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID) + "'" +
                                      " ,@APP_GOALS_EMP_COMMENTS = '" + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_EMP_COMMENTS) + "'" +
                                       " , @APP_GOALS_MGR_COMMENTS = '" + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_MGR_COMMENTS) + "'" +
                                      " , @APP_GOALS_MGR_RATING = " + Convert.ToInt32(_obj_Spms_AppraisalGoal.APP_GOALS_MGR_RATING) +
                                      " ,@APP_GOALS_LASTMDFBY = " + Convert.ToInt32(_obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFBY) +
                                      ", @APP_GOALS_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;
               
                    break;
                case 12:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL_GOALS @MODE = 12 , @APP_GOALS_APP_ID = '" + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_APP_ID) + "'" +
                                      " ,@APP_GOAL_ORG_ID = " + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID) + ",@APP_GOALS_FINAL = '" + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_FINAL) + "'" +
                                      "  "))
                        status = true;
                    else
                        status = false;
                    break;
                case 15:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL_GOALS @MODE = 15, @APP_GOALS_APP_ID = '" + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_APP_ID) + "'" +
                                      " ,@APP_GOAL_ORG_ID = " + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID) + ",  @APP_GOALS_GSDTL_ID= '" + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID) + "'" +
                                      " , @APP_GOALS_MGR_COMMENTS = '" + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_MGR_COMMENTS) + "'" +
                                      " , @APP_GOALS_MGR_RATING = " + Convert.ToInt32(_obj_Spms_AppraisalGoal.APP_GOALS_MGR_RATING) +
                                      "  "))
                        status = true;
                    else
                        status = false;

                    break;
                case 16:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL_GOALS @MODE = 16, @APP_GOALS_APP_ID = '" + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_APP_ID) + "'" +
                                      "  ,@APP_GOAL_ORG_ID = " + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID) + ",@APP_GOALS_FIXED = '" + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_FIXED) + "'" +
                                      "  "))
                        status = true;
                    else
                        status = false;
                    break;
                case 17:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL_GOALS @MODE = 17, @APP_GOALS_APP_ID = '" + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_APP_ID) + "'" +
                                      " ,@APP_GOAL_ORG_ID = " + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID) + ",  @APP_GOALS_GSDTL_ID= '" + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID) + "'" +
                                      ",@APP_EMP_GOAL_FIXED = '" + Convert.ToString(_obj_Spms_AppraisalGoal.APP_EMP_GOAL_FIXED) + "'" +
                                      ",@APP_GOALS_LASTMDFBY = '" + Convert.ToInt32(_obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFBY) +"'" +
                                      ",@APP_GOALS_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFDATE).ToString("MM/dd/yyyy")+"'"))
                        status = true;
                    else
                        status = false;
                    break;

                case 18:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL_GOALS @MODE = 18, @APP_GOALS_APP_ID = '" + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_APP_ID) + "'" +
                                      ",@APP_GOAL_ORG_ID = " + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID) + " ,  @APP_GOALS_GSDTL_ID= '" + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID) + "'" +
                                      " , @APP_GOALS_EMP_COMMENTS = '" + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_EMP_COMMENTS) + "'" +
                                      ", @APP_GOALS_LASTMDFBY = '" + Convert.ToInt32(_obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFBY) + "'" +
                                      ",@APP_GOALS_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
                                      ",@APP_GOALS_FINAL= '" + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_FINAL) + "'"))
                        status = true;
                    else
                        status = false;

                    break;
                case 19:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL_GOALS @MODE = 19, @APP_GOALS_APP_ID = '" + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_APP_ID) + "'" +
                                     ",@APP_GOAL_ORG_ID = " + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID) + " ,  @APP_GOALS_GSDTL_ID= '" + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID) + "'" +
                                     " , @APP_GOALS_MGR_COMMENTS = '" + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_MGR_COMMENTS) + "'" +
                                     ", @APP_GOALS_LASTMDFBY = '" + Convert.ToInt32(_obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFBY) + "'" +
                                     ",@APP_GOALS_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
                                     ",@APP_GOALS_FINAL= '" + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_FINAL) + "'" +
                                     ",@APP_GOALS_FIXED = '" + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_FIXED) + "'" +
                                     ",@APP_GOALS_MGR_RATING = '" + Convert.ToDecimal(_obj_Spms_AppraisalGoal.APP_GOALS_MGR_RATING) + "'" +
                                     ""))
                        status = true;
                    else
                        status = false;
                    break;
                case 20:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL_GOALS @MODE = 20, @APP_GOALS_APP_ID = '" + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_APP_ID) + "'" +
                                     ",@APP_GOAL_ORG_ID = " + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID) + " ,  @APP_GOALS_GSDTL_ID= '" + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID) + "'" +
                                     " , @APP_GOALS_APPR_COMMENTS = '" + Convert.ToString(_obj_Spms_AppraisalGoal.APP_GOALS_APPR_COMMENTS) + "'" +
                                     ", @APP_GOALS_LASTMDFBY = '" + Convert.ToInt32(_obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFBY) + "'" +
                                     ",@APP_GOALS_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
                                     ",@APP_GOALS_APPR_FIXED = '" + Convert.ToInt32(_obj_Spms_AppraisalGoal.APP_GOALS_APPR_FIXED) + "'" +
                                     ",@APP_GOALS_APPR_RATING = '" + Convert.ToDecimal(_obj_Spms_AppraisalGoal.APP_GOALS_APPR_RATING) + "'" +
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

        #region SPMS_GOALSETTINGKRADETAILS

        public static DataTable get_GoalStgKraDtls(SPMS_GOALSETTINGKRADETAILS _obj_Spms_GoalStgKraDtls)
        {
            DataTable dt = new DataTable();
            switch (_obj_Spms_GoalStgKraDtls.Mode)
            {

                case 1:
                    dt = ExecuteQuery("EXEC USP_PMS_GOALSETTING_KRA_DETAIL @MODE = 1");
                    break;
                case 7:
                    dt = ExecuteQuery("EXEC USP_PMS_GOALSETTING_KRA_DETAIL @MODE = 7 ,@GS_KRA_GS_ID  = " + Convert.ToString(_obj_Spms_GoalStgKraDtls.GS_KRA_GSDTL_ID) + ",@GS_APPRAISAL_CYCLE = " + Convert.ToString(_obj_Spms_GoalStgKraDtls.LASTMDFBY) + ",@GS_KRA_ORG_ID = " + Convert.ToString(_obj_Spms_GoalStgKraDtls.CREATEDBY) + " ");

                    break;
                                 
            }
            return dt;
        }



        #endregion

        #region SPMS_APPRAISALKRA


        public static DataTable get_AppraisalKra(SPMS_APPRAISALKRA _obj_Spms_AppraisalKra)
        {
            DataTable dt = new DataTable();
            switch (_obj_Spms_AppraisalKra.Mode)
            {

                case 1:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL_KRA @MODE = 1");
                    break;
                case 5:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL_KRA @MODE = 5,@APP_KRA_KRA_ID = " + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_KRA_ID) + ", @APP_KRA_LASTMDFBY = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_LASTMDFBY) + "'" +
                                      " ,@APP_KRA_ORG_ID = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_ORG_ID) + "'" +
                                      ",@APP_KRA_ID = " + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_ID) + "  ");

                    break;
                case 7:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL_KRA @MODE = 7,@APP_KRA_APP_ID = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_APP_ID) + "'" +
                                      " ");
                    break;
                case 8:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL_KRA @MODE = 8,@APP_KRA_ORG_ID = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_ORG_ID) + "'" +
                                      ",@APP_KRA_KRA_ID = " + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_KRA_ID) + ",@APP_KRA_APP_ID = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_APP_ID) + "'" +
                                      "  ");

                    break;
                case 9:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL_KRA @MODE = 9,@APP_KRA_KRA_ID = " + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_KRA_ID) + "  ");

                    break;
                case 10:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL_KRA @MODE = 10,@APP_KRA_KRA_ID = " + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_KRA_ID) + ",@APP_KRA_LASTMDFBY = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_LASTMDFBY) + "'" +
                                      " ,@APP_KRA_ORG_ID = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_ORG_ID) + "'" +
                                      ",@APP_KRA_ID = " + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_ID) + "  ");

                    break;
                case 13:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL_KRA @MODE = 13,@APP_KRA_APP_ID = " + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_APP_ID) + ",@APP_KRA_ORG_ID = " + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_ORG_ID) + "  ");

                    break;
                case 14:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL_KRA @MODE = 14,@APP_KRA_APP_ID = " + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_APP_ID) + ",@APP_KRA_ORG_ID = " + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_ORG_ID) + "  ");

                    break;
                case 15:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL_KRA @MODE = 15,@APP_KRA_APP_ID = " + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_APP_ID) + "  ");

                    break;
                case 16:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL_KRA @MODE = 16,@APP_KRA_APP_ID = " + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_APP_ID) + "  ");

                    break;
                default:
                    break;
            }
            return dt;
        }


        public static bool set_AppraisalKra(SPMS_APPRAISALKRA _obj_Spms_AppraisalKra)
        {
            bool status = false;
            switch (_obj_Spms_AppraisalKra.Mode)
            {
                case 3:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL_KRA @MODE = 3 , @APP_KRA_APP_ID = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_APP_ID) + "'" +
                                      " ,  @APP_KRA_KRA_ID= '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_KRA_ID) + "'" +
                                      " ,@APP_KRA_EMP_COMMENTS = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_EMP_COMMENTS) + "'" +
                                       " ,@APP_KRA_ORG_ID = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_ORG_ID) + "'" +
                                      ", @APP_KRA_MGR_COMMENTS = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_MGR_COMMENTS) + "'" +
                                      " , @APP_KRA_MGR_RATING = " + Convert.ToDecimal(_obj_Spms_AppraisalKra.APP_KRA_MGR_RATING) +
                                      " , @APP_KRA_CREATEDBY = " + Convert.ToInt32(_obj_Spms_AppraisalKra.APP_KRA_CREATEDBY) +
                                      ",@APP_KRA_FINAL = " + Convert.ToInt32(_obj_Spms_AppraisalKra.APP_KRA_FINAL) +
                                      ",@APP_KRA_FIXED = " + Convert.ToInt32(_obj_Spms_AppraisalKra.APP_KRA_FIXED) +
                                      ",@APP_KRA_OBJ_ID="+Convert.ToInt32( _obj_Spms_AppraisalKra.APP_KRA_OBJ_ID )+
                                      ", @APP_KRA_CREATEDDATE = '" + Convert.ToDateTime(_obj_Spms_AppraisalKra.APP_KRA_CREATEDDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case 4:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL_KRA @MODE = 4 , @APP_KRA_ID  = " + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_ID)
                                       + ",  @APP_KRA_APP_ID = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_APP_ID) + "'" +
                                      " ,@APP_KRA_ORG_ID = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_ORG_ID) + "'" +
                                      ",  @APP_KRA_KRA_ID= '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_KRA_ID) + "'" +
                                      " ,@APP_KRA_EMP_COMMENTS = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_EMP_COMMENTS) + "'" +
                                       " , @APP_KRA_MGR_COMMENTS = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_MGR_COMMENTS) + "'" +
                                      " , @APP_KRA_MGR_RATING = " + Convert.ToInt32(_obj_Spms_AppraisalKra.APP_KRA_MGR_RATING) +
                                      " ,@APP_KRA_LASTMDFBY = " + Convert.ToInt32(_obj_Spms_AppraisalKra.APP_KRA_LASTMDFBY) +
                                      ", @APP_KRA_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Spms_AppraisalKra.APP_KRA_LASTMDFDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;

                    break;
                case 6:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL_KRA @MODE = 6 , @APP_KRA_APP_ID = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_APP_ID) + "'" +
                                      " ,  @APP_KRA_KRA_ID= '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_KRA_ID) + "'" +
                                      " ,@APP_KRA_ORG_ID = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_ORG_ID) + "'" +
                                      ",@APP_KRA_EMP_COMMENTS = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_EMP_COMMENTS) + "'" +
                                       " , @APP_KRA_MGR_COMMENTS = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_MGR_COMMENTS) + "'" +
                                      " , @APP_KRA_MGR_RATING = " + Convert.ToInt32(_obj_Spms_AppraisalKra.APP_KRA_MGR_RATING) +
                                      " ,@APP_KRA_LASTMDFBY = " + Convert.ToInt32(_obj_Spms_AppraisalKra.APP_KRA_LASTMDFBY) +
                                      ", @APP_KRA_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Spms_AppraisalKra.APP_KRA_LASTMDFDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;

                    break;
                case 12:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL_KRA @MODE = 12 , @APP_KRA_APP_ID = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_APP_ID) + "'" +
                                      " ,@APP_KRA_ORG_ID = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_ORG_ID) + "'" +
                                      ",@APP_KRA_FINAL = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_FINAL) + "'" +
                                      " "))
                        status = true;
                    else
                        status = false;
                    break;
                case 16:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL_KRA @MODE = 16 , @APP_KRA_APP_ID = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_APP_ID) + "'" +
                                      " ,@APP_KRA_ORG_ID = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_ORG_ID) + "'" +
                                      ",@APP_KRA_KRA_ID= '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_KRA_ID) + "'" +
                                      " ,@APP_KRA_MGR_COMMENTS = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_MGR_COMMENTS) + "'" +
                                      " , @APP_KRA_MGR_RATING = " + Convert.ToInt32(_obj_Spms_AppraisalKra.APP_KRA_MGR_RATING) +
                                      "  "))
                        status = true;
                    else
                        status = false;
                    break;
                case 17:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL_KRA @MODE = 17 , @APP_KRA_APP_ID = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_APP_ID) + "'" +
                                      " ,@APP_KRA_ORG_ID = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_ORG_ID) + "'" +
                                      ",@APP_KRA_FIXED= '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_FIXED) + "'" +
                                      ",@APP_KRA_KRA_ID = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_KRA_ID) + "'" +
                                      " "))
                        status = true;
                    else
                        status = false;
                    break;

                case 18:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL_KRA @MODE = 18 , @APP_KRA_APP_ID = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_APP_ID) + "'" +
                                      " ,@APP_KRA_ORG_ID = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_ORG_ID) + "'" +
                                      ",@APP_KRA_EMP_FIXED= '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_EMP_FIXED) + "'" +
                                      ",@APP_KRA_KRA_ID = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_KRA_ID) + "'" +
                                      ",@APP_KRA_OBJ_ID=" + Convert.ToInt32(_obj_Spms_AppraisalKra.APP_KRA_OBJ_ID) +
                                      ",@APP_KRA_LASTMDFBY = '" + Convert.ToInt32(_obj_Spms_AppraisalKra.APP_KRA_LASTMDFBY) + "'"  +
                                      ",@APP_KRA_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Spms_AppraisalKra.APP_KRA_LASTMDFDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;
                    break;

                case 19:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL_KRA @MODE = 19, @APP_KRA_APP_ID = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_APP_ID) + "'" +
                                      " ,@APP_KRA_KRA_ID= '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_KRA_ID) + "'" +
                                      " ,@APP_KRA_ORG_ID = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_ORG_ID) + "'" +
                                      ",@APP_KRA_OBJ_ID="+Convert.ToInt32( _obj_Spms_AppraisalKra.APP_KRA_OBJ_ID)+
                                      ",@APP_KRA_EMP_COMMENTS = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_EMP_COMMENTS) + "'" +
                                      " , @APP_KRA_LASTMDFBY = '" + Convert.ToInt32(_obj_Spms_AppraisalKra.APP_KRA_LASTMDFBY) + "'" +
                                      ",@APP_KRA_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Spms_AppraisalKra.APP_KRA_LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
                                      ",@APP_KRA_FINAL = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_FINAL) + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case 20:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL_KRA @MODE = 20 , @APP_KRA_APP_ID = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_APP_ID) + "'" +
                                      " ,  @APP_KRA_KRA_ID= '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_KRA_ID) + "'" +
                                      " ,@APP_KRA_MGR_COMMENTS = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_MGR_COMMENTS) + "'" +
                                       " ,@APP_KRA_ORG_ID = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_ORG_ID) + "'" +
                                         ",@APP_KRA_OBJ_ID=" + Convert.ToInt32(_obj_Spms_AppraisalKra.APP_KRA_OBJ_ID) +
                                      " , @APP_KRA_MGR_RATING = " + Convert.ToDecimal(_obj_Spms_AppraisalKra.APP_KRA_MGR_RATING) +
                                      " , @APP_KRA_LASTMDFBY = " + Convert.ToInt32(_obj_Spms_AppraisalKra.APP_KRA_LASTMDFBY) +
                                      ",@APP_KRA_FINAL = " + Convert.ToInt32(_obj_Spms_AppraisalKra.APP_KRA_FINAL) +
                                      ",@APP_KRA_FIXED = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_FIXED) + "'" +
                                      ", @APP_KRA_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Spms_AppraisalKra.APP_KRA_LASTMDFDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case 21:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL_KRA @MODE = 21 , @APP_KRA_APP_ID = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_APP_ID) + "'" +
                                      " ,  @APP_KRA_KRA_ID= '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_KRA_ID) + "'" +
                                      " ,@APP_KRA_APPR_COMMENTS = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_APPR_COMMENTS) + "'" +
                                       " ,@APP_KRA_ORG_ID = '" + Convert.ToString(_obj_Spms_AppraisalKra.APP_KRA_ORG_ID) + "'" +
                                      " , @APP_KRA_APPR_RATING = " + Convert.ToDecimal(_obj_Spms_AppraisalKra.APP_KRA_APPR_RATING) +
                                      " , @APP_KRA_LASTMDFBY = " + Convert.ToInt32(_obj_Spms_AppraisalKra.APP_KRA_LASTMDFBY) +
                                      ",@APP_KRA_APPR_FIXED = '" + Convert.ToInt32(_obj_Spms_AppraisalKra.APP_KRA_APPR_FIXED) + "'" +
                                      ", @APP_KRA_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Spms_AppraisalKra.APP_KRA_LASTMDFDATE).ToString("MM/dd/yyyy") + "'"))
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
        #region SPMS_APPRAISALIDP


        public static DataTable get_AppraisalIdp(SPMS_APPRAISALIDP _obj_Spms_AppraisalIdp)
        {
            DataTable dt = new DataTable();
            switch (_obj_Spms_AppraisalIdp.Mode)
            {

                case 1:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL_IDP @MODE = 1");
                    break;
                case 5:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL_IDP @MODE = 5,@APP_IDP_IDP_ID = " + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_IDP_ID) + ", @APP_IDP_LASTMDFBY = '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_LASTMDFBY) + "'" +
                                      " ,@APP_IDP_ORG_ID = '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_ORG_ID) + "'" +
                                      ",@APP_IDP_ID = " + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_ID) + "  ");

                    break;
                case 7:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL_IDP @MODE = 7,@APP_IDP_APP_ID = '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_APP_ID) + "'" +
                                      " ");
                    break;
                case 8:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL_IDP @MODE = 8,@APP_IDP_ORG_ID = '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_ORG_ID) + "'" +
                                      ",@APP_IDP_IDP_ID = " + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_IDP_ID) + ",@APP_IDP_APP_ID = '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_APP_ID) + "'" +
                                      "  ");

                    break;
                case 9:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL_IDP @MODE = 9,@APP_IDP_IDP_ID = " + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_IDP_ID) + "  ");

                    break;
                case 10:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL_IDP @MODE = 10,@APP_IDP_IDP_ID = " + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_IDP_ID) + ",@APP_IDP_LASTMDFBY = '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_LASTMDFBY) + "'" +
                                      " ,@APP_IDP_ORG_ID = '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_ORG_ID) + "'" +
                                      ",@APP_IDP_ID = " + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_ID) + "  ");

                    break;
                case 13:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL_IDP @MODE = 13,@APP_IDP_APP_ID = " + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_APP_ID) + ",@APP_IDP_ORG_ID = " + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_ORG_ID) + "  ");

                    break;
                case 14:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL_IDP @MODE = 14,@APP_IDP_APP_ID = " + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_APP_ID) + ",@APP_IDP_ORG_ID = " + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_ORG_ID) + "  ");

                    break;
                case 15:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL_IDP @MODE = 15,@APP_IDP_APP_ID = " + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_APP_ID) + "  ");

                    break;
                case 16:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL_IDP @MODE = 16,@APP_IDP_APP_ID = " + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_APP_ID) + "  ");

                    break;
                default:
                    break;
            }
            return dt;
        }


        public static bool set_AppraisalIdp(SPMS_APPRAISALIDP _obj_Spms_AppraisalIdp)
        {
            bool status = false;
            switch (_obj_Spms_AppraisalIdp.Mode)
            {
                case 3:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL_IDP @MODE = 3 , @APP_IDP_APP_ID = '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_APP_ID) + "'" +
                                      " ,  @APP_IDP_IDP_ID= '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_IDP_ID) + "'" +
                                      " ,@APP_IDP_EMP_COMMENTS = '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_EMP_COMMENTS) + "'" +
                                       " ,@APP_IDP_ORG_ID = '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_ORG_ID) + "'" +
                                      ", @APP_IDP_MGR_COMMENTS = '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_MGR_COMMENTS) + "'" +
                                      " , @APP_IDP_MGR_RATING = " + Convert.ToDecimal(_obj_Spms_AppraisalIdp.APP_IDP_MGR_RATING) +
                                      " , @APP_IDP_CREATEDBY = " + Convert.ToInt32(_obj_Spms_AppraisalIdp.APP_IDP_CREATEDBY) +
                                      ",@APP_IDP_FINAL = " + Convert.ToInt32(_obj_Spms_AppraisalIdp.APP_IDP_FINAL) +
                                      ",@APP_IDP_FIXED = " + Convert.ToInt32(_obj_Spms_AppraisalIdp.APP_IDP_FIXED) +
                                      ", @APP_IDP_CREATEDDATE = '" + Convert.ToDateTime(_obj_Spms_AppraisalIdp.APP_IDP_CREATEDDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case 4:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL_IDP @MODE = 4 , @APP_IDP_ID  = " + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_ID)
                                       + ",  @APP_IDP_APP_ID = '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_APP_ID) + "'" +
                                      " ,@APP_IDP_ORG_ID = '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_ORG_ID) + "'" +
                                      ",  @APP_IDP_IDP_ID= '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_IDP_ID) + "'" +
                                      " ,@APP_IDP_EMP_COMMENTS = '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_EMP_COMMENTS) + "'" +
                                       " , @APP_IDP_MGR_COMMENTS = '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_MGR_COMMENTS) + "'" +
                                      " , @APP_IDP_MGR_RATING = " + Convert.ToInt32(_obj_Spms_AppraisalIdp.APP_IDP_MGR_RATING) +
                                      " ,@APP_IDP_LASTMDFBY = " + Convert.ToInt32(_obj_Spms_AppraisalIdp.APP_IDP_LASTMDFBY) +
                                      ", @APP_IDP_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Spms_AppraisalIdp.APP_IDP_LASTMDFDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;

                    break;
                case 6:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL_IDP @MODE = 6 , @APP_IDP_APP_ID = '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_APP_ID) + "'" +
                                      " ,  @APP_IDP_IDP_ID= '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_IDP_ID) + "'" +
                                      " ,@APP_IDP_ORG_ID = '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_ORG_ID) + "'" +
                                      ",@APP_IDP_EMP_COMMENTS = '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_EMP_COMMENTS) + "'" +
                                       " , @APP_IDP_MGR_COMMENTS = '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_MGR_COMMENTS) + "'" +
                                      " , @APP_IDP_MGR_RATING = " + Convert.ToInt32(_obj_Spms_AppraisalIdp.APP_IDP_MGR_RATING) +
                                      " ,@APP_IDP_LASTMDFBY = " + Convert.ToInt32(_obj_Spms_AppraisalIdp.APP_IDP_LASTMDFBY) +
                                      ", @APP_IDP_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Spms_AppraisalIdp.APP_IDP_LASTMDFDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;

                    break;
                case 12:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL_IDP @MODE = 12 , @APP_IDP_APP_ID = '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_APP_ID) + "'" +
                                      " ,@APP_IDP_ORG_ID = '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_ORG_ID) + "'" +
                                      ",@APP_IDP_FINAL = '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_FINAL) + "'" +
                                      " "))
                        status = true;
                    else
                        status = false;
                    break;
                case 16:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL_IDP @MODE = 16 , @APP_IDP_APP_ID = '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_APP_ID) + "'" +
                                      " ,@APP_IDP_ORG_ID = '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_ORG_ID) + "'" +
                                      ",@APP_IDP_IDP_ID= '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_IDP_ID) + "'" +
                                      " ,@APP_IDP_MGR_COMMENTS = '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_MGR_COMMENTS) + "'" +
                                      " , @APP_IDP_MGR_RATING = " + Convert.ToInt32(_obj_Spms_AppraisalIdp.APP_IDP_MGR_RATING) +
                                      "  "))
                        status = true;
                    else
                        status = false;
                    break;
                case 17:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL_IDP @MODE = 17 , @APP_IDP_APP_ID = '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_APP_ID) + "'" +
                                      " ,@APP_IDP_ORG_ID = '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_ORG_ID) + "'" +
                                      ",@APP_IDP_FIXED= '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_FIXED) + "'" +
                                      ",@APP_IDP_IDP_ID = '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_IDP_ID) + "'" +
                                      " "))
                        status = true;
                    else
                        status = false;
                    break;

                case 18:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL_IDP @MODE = 18 , @APP_IDP_APP_ID = '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_APP_ID) + "'" +
                                      " ,@APP_IDP_ORG_ID = '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_ORG_ID) + "'" +
                                      ",@APP_IDP_EMP_FIXED= '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_EMP_FIXED) + "'" +
                                      ",@APP_IDP_IDP_ID = '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_IDP_ID) + "'" +
                                      ",@APP_IDP_LASTMDFBY = '" + Convert.ToInt32(_obj_Spms_AppraisalIdp.APP_IDP_LASTMDFBY) + "'" +
                                      ",@APP_IDP_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Spms_AppraisalIdp.APP_IDP_LASTMDFDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;
                    break;

                case 19:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL_IDP @MODE = 19, @APP_IDP_APP_ID = '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_APP_ID) + "'" +
                                      " ,@APP_IDP_IDP_ID= '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_IDP_ID) + "'" +
                                      " ,@APP_IDP_ORG_ID = '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_ORG_ID) + "'" +
                                      ",@APP_IDP_EMP_COMMENTS = '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_EMP_COMMENTS) + "'" +
                                      " ,@APP_IDP_LASTMDFBY = '" + Convert.ToInt32(_obj_Spms_AppraisalIdp.APP_IDP_LASTMDFBY) + "'" +
                                      ",@APP_IDP_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Spms_AppraisalIdp.APP_IDP_LASTMDFDATE).ToString("MM/dd/yyyy") + "'" +
                                      ",@APP_IDP_FINAL = '" + Convert.ToInt32(_obj_Spms_AppraisalIdp.APP_IDP_FINAL) + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case 20:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL_IDP @MODE = 20 , @APP_IDP_APP_ID = '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_APP_ID) + "'" +
                                      " ,  @APP_IDP_IDP_ID= '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_IDP_ID) + "'" +
                                      " ,@APP_IDP_MGR_COMMENTS = '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_MGR_COMMENTS) + "'" +
                                       " ,@APP_IDP_ORG_ID = '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_ORG_ID) + "'" +
                                      " , @APP_IDP_MGR_RATING = " + Convert.ToDecimal(_obj_Spms_AppraisalIdp.APP_IDP_MGR_RATING) +
                                      " , @APP_IDP_LASTMDFBY = " + Convert.ToInt32(_obj_Spms_AppraisalIdp.APP_IDP_LASTMDFBY) +
                                      ",@APP_IDP_FINAL = " + Convert.ToInt32(_obj_Spms_AppraisalIdp.APP_IDP_FINAL) +
                                      ",@APP_IDP_FIXED = '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_FIXED) + "'" +
                                      ", @APP_IDP_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Spms_AppraisalIdp.APP_IDP_LASTMDFDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case 21:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL_IDP @MODE = 21 , @APP_IDP_APP_ID = '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_APP_ID) + "'" +
                                      " ,  @APP_IDP_IDP_ID= '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_IDP_ID) + "'" +
                                      " ,@APP_IDP_APPR_COMMENTS = '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_APPR_COMMENTS) + "'" +
                                       " ,@APP_IDP_ORG_ID = '" + Convert.ToString(_obj_Spms_AppraisalIdp.APP_IDP_ORG_ID) + "'" +
                                      " , @APP_IDP_APPR_RATING = " + Convert.ToDecimal(_obj_Spms_AppraisalIdp.APP_IDP_APPR_RATING) +
                                      " , @APP_IDP_LASTMDFBY = " + Convert.ToInt32(_obj_Spms_AppraisalIdp.APP_IDP_LASTMDFBY) +
                                      ",@APP_IDP_APPR_FIXED = '" + Convert.ToInt32(_obj_Spms_AppraisalIdp.APP_IDP_APPR_FIXED) + "'" +
                                      ", @APP_IDP_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Spms_AppraisalIdp.APP_IDP_LASTMDFDATE).ToString("MM/dd/yyyy") + "'"))
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
        #region SPMS_APRAISALAPPROVER
    
        public static DataTable get_AppApprover(SPMS_APRAISALAPPROVER _obj_Pms_AppApprover)
        {
            DataTable dt = new DataTable();
            switch (_obj_Pms_AppApprover.Mode)
            {

                case 1:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL_APPROVER @MODE = 1");
                    break;
                case 2:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL_APPROVER @MODE = 2,@APP_APPROVER_ID= " + Convert.ToString(_obj_Pms_AppApprover.APP_APPROVER_ID) + " ");

                    break;
                case 5:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL_APPROVER @MODE = 5,@APP_APPROVER_APP_ID  = " + Convert.ToString(_obj_Pms_AppApprover.APP_APPROVER_APP_ID)
                                       + " ");

                    break;
                case 6:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL_APPROVER @MODE = 6,@APP_APPROVER_APP_ID  = " + Convert.ToString(_obj_Pms_AppApprover.APP_APPROVER_APP_ID)
                                       + " ");

                    break;
                case 7:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL_APPROVER @MODE = 7,@APP_APPROVER_APP_ID  = " + Convert.ToString(_obj_Pms_AppApprover.APP_APPROVER_APP_ID)
                                       + " ");

                    break;
                default:
                    break;
            }
            return dt;
        }
        
        public static bool set_AppApprover(SPMS_APRAISALAPPROVER _obj_Pms_AppApprover)
        {
            bool status = false;
            switch (_obj_Pms_AppApprover.Mode)
            {
                case 3:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL_APPROVER @MODE = 3 ,@APP_APPROVER_APP_ID  = " + Convert.ToString(_obj_Pms_AppApprover.APP_APPROVER_APP_ID)
                                       + ",@APP_APPROVER_ORG_ID  = " + Convert.ToString(_obj_Pms_AppApprover.APP_APPROVER_ORG_ID)
                                       + ", @APP_APPROVER_COMMENTS = '" + Convert.ToString(_obj_Pms_AppApprover.APP_APPROVER_COMMENTS) + "'" +
                                      " , @APP_APPROVER_RATING  = " + Convert.ToDecimal(_obj_Pms_AppApprover.APP_APPROVER_RATING)
                                       + ",@APP_APPROVER_CREATEDBY = " + Convert.ToInt32(_obj_Pms_AppApprover.APP_APPROVER_CREATEDBY) +
                                      ", @APP_APPROVER_CREATEDDATE = '" + Convert.ToDateTime(_obj_Pms_AppApprover.APP_APPROVER_CREATEDDATE).ToString("MM/dd/yyyy") +
                                      "',@APP_APPROVER_STATUS = " + _obj_Pms_AppApprover.APP_APPROVER_STATUS))
                        status = true;
                    else
                        status = false;
                    break;
                case 8:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL_APPROVER @MODE = 8 ,@APP_APPROVER_APP_ID  = " + Convert.ToString(_obj_Pms_AppApprover.APP_APPROVER_APP_ID)
                                       + ",@APP_APPROVER_ORG_ID  = " + Convert.ToString(_obj_Pms_AppApprover.APP_APPROVER_ORG_ID)
                                       + " , @APP_APPROVER_RATING  = " + Convert.ToDecimal(_obj_Pms_AppApprover.APP_APPROVER_RATING)
                                       + " , @APP_APPROVER_COMMENTS  = '" + Convert.ToString(_obj_Pms_AppApprover.APP_APPROVER_COMMENTS) + "'" +
                                       ",@APP_APPROVER_LASTMDFBY = " + Convert.ToInt32(_obj_Pms_AppApprover.APP_APPROVER_LASTMDFBY) +
                                      ", @APP_APPROVER_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Pms_AppApprover.APP_APPROVER_LASTMDFDATE).ToString("MM/dd/yyyy") + 
                                      "',@APP_APPROVER_STATUS = " + _obj_Pms_AppApprover.APP_APPROVER_STATUS))
                        status = true;
                    else
                        status = false;
                    break;
                //case 4:
                //    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL_APPROVER @MODE = 4 , @ROLE_ID  = " + Convert.ToString(_obj_Pms_Roles.ROLES_ID)
                //                       + ", @ROLE_NAME = '" + Convert.ToString(_obj_Pms_Roles.ROLES_NAME) + "'" +
                //                      " , @ROLE_DESCRIPTION = '" + Convert.ToString(_obj_Pms_Roles.ROLES_DESCRIPTION) + "'" +
                //                      " , @ROLE_LASTMDF_BY = " + Convert.ToInt32(_obj_Pms_Roles.ROLES_LASTMDFBY) +
                //                      ", @ROLE_LASTMDF_DATE = '" + Convert.ToDateTime(_obj_Pms_Roles.ROLES_LASTMDFDATE).ToString("MM/dd/yyyy") + "'"))
                //        status = true;
                //    else
                //        status = false;

                //    break;

                default:
                    break;
            }
            return status;

        }

        public static DataTable get_EmpRatingDetails(SPMS_APPRAISAL _obj_Pms_Appraisal)
        { 
             DataTable dt = new DataTable();
             switch (_obj_Pms_Appraisal.Mode)
             {
                 case 1:
                     dt = ExecuteQuery("EXEC USP_PMS_EMPLOYEELIST @MODE = 1,@BUID = " + _obj_Pms_Appraisal.BUID + ",@ORG_ID = " + _obj_Pms_Appraisal.APPRAISAL_ORGANISATION_ID + "");
                     break;

                 case 2:
                     dt = ExecuteQuery("EXEC USP_PMS_EMPLOYEELIST @MODE = 2,@EMPID = " + _obj_Pms_Appraisal.APPRAISAL_EMP_ID + " ,@ORG_ID = " + _obj_Pms_Appraisal.APPRAISAL_ORGANISATION_ID + ",@APPRCYCLE_ID = " + _obj_Pms_Appraisal.APPRAISAL_ID + "  ");
                     break;
                 case 4:
                     dt = ExecuteQuery("EXEC USP_PMS_EMPLOYEELIST @MODE = 4,@ORG_ID = " + _obj_Pms_Appraisal.APPRAISAL_ORGANISATION_ID + ",@APPRAISAL_ID = " + _obj_Pms_Appraisal.APPRAISAL_ID + "  ");
                     break;
                 case 5:
                     dt = ExecuteQuery("EXEC USP_PMS_EMPLOYEELIST @MODE = 5,@ORG_ID = " + _obj_Pms_Appraisal.APPRAISAL_ORGANISATION_ID + ",@EMPID = " + _obj_Pms_Appraisal.EMPID + "  ");
                     break;
                 default:
                     break;

             }
             return dt;
        
        }

        public static bool set_EmpRatingdetails(SPMS_APPRAISAL _obj_Pms_Appraisal)
        {
            bool status = false;

            if (ExecuteNonQuery("EXEC USP_PMS_EMPLOYEELIST @MODE = 3 ,@EMPID  = " + Convert.ToString(_obj_Pms_Appraisal.EMPID) + ",@ORG_ID = " + _obj_Pms_Appraisal.APPRAISAL_ORGANISATION_ID + ",@APPRAISAL_ID  = " + Convert.ToString(_obj_Pms_Appraisal.APPRAISAL_ID) + ",@APP_STATUS_APPRAISALCYCLE  = " + Convert.ToString(_obj_Pms_Appraisal.APPRAISAL_APPRAISALCYCLE) + ""))
             status = true;
            else
              status = false;
            return status;
        }

        public static bool set_EmpRejectdetails(SPMS_APPRAISAL _obj_Pms_Appraisal)
        {
            bool status = false;

            if (ExecuteNonQuery("EXEC USP_PMS_EMPLOYEELIST @MODE = 6 ,@EMPID  = " + Convert.ToString(_obj_Pms_Appraisal.EMPID) 
                + ",@ORG_ID = " + _obj_Pms_Appraisal.ORGANISATION_ID
                + ",@APPRAISAL_ID  = " + Convert.ToString(_obj_Pms_Appraisal.APPRAISAL_ID)
                + ",@APPRCYCLE_ID  = " + Convert.ToString(_obj_Pms_Appraisal.APPRAISAL_APPRAISALCYCLE)
                + ",@BUID = " + Convert.ToInt32(_obj_Pms_Appraisal.APPRAISAL_BUSSINESS_UNIT)
                + ",@APPR_REJECT_COMMENTS = '" + Convert.ToString(_obj_Pms_Appraisal.APP_REJECT_COMMENTS)
                + "',@APPR_REJECT_CREATEDBY = " + Convert.ToInt32(_obj_Pms_Appraisal.CREATEDBY) + ""))
                status = true;
            else
                status = false;
            return status;
        }

        public static DataTable Get_PMS_App_Emp_Details(int empID)
        {
            DataTable dtEmp = ExecuteQuery("EXEC USP_PMS_EMPLOYEELIST @OPERATION = 'GET_EMP_DETAILS', @EMPID = " + empID);
            return dtEmp;
        }

        public static DataTable Get_Pms_App_Emp_Prev_Details(int empID)
        {
            DataTable dtPrevEmpDtls = ExecuteQuery("EXEC USP_PMS_EMPLOYEELIST @OPERATION = 'GET_EMP_PREV_DTLS', @EMPID = " + empID);
            return dtPrevEmpDtls;
        }

        #endregion

        #region SPMS_APRAISALDISCUSSION



        public static DataTable     get_AppDiscDtls(SPMS_APRAISALDISCUSSION _obj_Pms_AppDiscDtls)
        {
            DataTable dt = new DataTable();
            switch (_obj_Pms_AppDiscDtls.Mode)
            {

                case 1:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL_DISCUSSION @MODE = 1");
                    break;
                case 2:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL_DISCUSSION @MODE = 2,@APP_DISCUSSION_ID= " + Convert.ToString(_obj_Pms_AppDiscDtls.APP_DISCUSSION_ID) + " ");

                    break;
                case 5:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL_DISCUSSION @MODE = 5,@APP_DISCUSSION_LASTMDFBY= " + Convert.ToString(_obj_Pms_AppDiscDtls.APP_DISCUSSION_LASTMDFBY) + " ");

                    break;
                case 6:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL_DISCUSSION @MODE = 6, @APP_DISCUSSION_ORG_ID = '" + Convert.ToString(_obj_Pms_AppDiscDtls.APP_DISCUSSION_ORG_ID) + "'" +
                                      ",@APP_DISCUSSION_LASTMDFBY= " + Convert.ToString(_obj_Pms_AppDiscDtls.APP_DISCUSSION_LASTMDFBY) + " ");

                    break;
                case 7:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL_DISCUSSION @MODE = 7, @APP_DISCUSSION_ORG_ID = '" + Convert.ToString(_obj_Pms_AppDiscDtls.APP_DISCUSSION_ORG_ID) + "'" +
                                      ",@APP_DISCUSSION_LASTMDFBY= " + Convert.ToString(_obj_Pms_AppDiscDtls.APP_DISCUSSION_LASTMDFBY) + " ");

                    break;
                case 9:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISAL_DISCUSSION @MODE = 9 , @APP_DISCUSSION_ORG_ID = '" + Convert.ToString(_obj_Pms_AppDiscDtls.APP_DISCUSSION_ORG_ID) + "',@LOGIN_ID='"+_obj_Pms_AppDiscDtls.LOGIN_ID+"'");

                    break;
                default:
                    break;
            }
            return dt;
        }




        public static bool set_AppDiscDtls(SPMS_APRAISALDISCUSSION _obj_Pms_AppDiscDtls)
        {
            bool status = false;
            switch (_obj_Pms_AppDiscDtls.Mode)
            {
                case 3:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL_DISCUSSION @MODE = 3 , @APP_DISCUSSION_APP_ID = '" + Convert.ToString(_obj_Pms_AppDiscDtls.APP_DISCUSSION_APP_ID) + "'" +
                                      ", @APP_DISCUSSION_ORG_ID = '" + Convert.ToString(_obj_Pms_AppDiscDtls.APP_DISCUSSION_ORG_ID) + "'" +
                                      " ,@APP_DISCUSSION_EMP_COMMENTS= '" + Convert.ToString(_obj_Pms_AppDiscDtls.APP_DISCUSSION_EMP_COMMENTS) + "'" +
                                      ", @APP_DISCUSSION_MGR_COMMENTS= '" + Convert.ToString(_obj_Pms_AppDiscDtls.APP_DISCUSSION_MGR_COMMENTS) + "'" +
                                      ",@APP_DISCUSSION_DATE = '" + Convert.ToDateTime(_obj_Pms_AppDiscDtls.APP_DISCUSSION_DATE).ToString("MM/dd/yyyy") + "'" +
                                      ",  @APP_DISCUSSION_CREATEDBY = " + Convert.ToInt32(_obj_Pms_AppDiscDtls.APP_DISCUSSION_CREATEDBY) +
                                      ", @APP_DISCUSSION_CREATEDDATE = '" + Convert.ToDateTime(_obj_Pms_AppDiscDtls.APP_DISCUSSION_CREATEDDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case 4:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISAL_DISCUSSION @MODE = 4 , @APP_DISCUSSION_ID  = " + Convert.ToString(_obj_Pms_AppDiscDtls.APP_DISCUSSION_ID)
                                       + ",@APP_DISCUSSION_APP_ID = '" + Convert.ToString(_obj_Pms_AppDiscDtls.APP_DISCUSSION_APP_ID) + "'" +
                                      " ,@APP_DISCUSSION_EMP_COMMENTS= '" + Convert.ToString(_obj_Pms_AppDiscDtls.APP_DISCUSSION_EMP_COMMENTS) + "'" +
                                      ", @APP_DISCUSSION_MGR_COMMENTS= '" + Convert.ToString(_obj_Pms_AppDiscDtls.APP_DISCUSSION_MGR_COMMENTS) + "'" +
                                      ",@APP_DISCUSSION_DATE = '" + Convert.ToDateTime(_obj_Pms_AppDiscDtls.APP_DISCUSSION_DATE).ToString("MM/dd/yyyy") + "'" +
                                      ", @APP_DISCUSSION_LASTMDFBY = " + Convert.ToInt32(_obj_Pms_AppDiscDtls.APP_DISCUSSION_LASTMDFBY) +
                                      ", @APP_DISCUSSION_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Pms_AppDiscDtls.APP_DISCUSSION_LASTMDFDATE).ToString("MM/dd/yyyy") + "'"))
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

        #region SPMS_PROJECT

        /// <summary>
        /// This method is used TO GET PROJECTDETAILS BASED ON PROJECT_ID
        /// </summary>
        /// <returns>
        /// DataTable WITH PROJECT INFORMATION
        /// </returns>
        public static DataTable get_Project(SPMS_PROJECT _obj_Pms_Project)
        {
            DataTable dt = new DataTable();
            switch (_obj_Pms_Project.Mode)
            {

                case 1:
                    dt = ExecuteQuery("EXEC USP_PMS_PROJECT @MODE = 1,@PROJECT_ORG_ID = " + Convert.ToString(_obj_Pms_Project.PROJECT_ORG_ID) + " ");
                    break;
                case 2:
                    dt = ExecuteQuery("EXEC USP_PMS_PROJECT @MODE = 2,@PROJECT_ID = " + Convert.ToString(_obj_Pms_Project.PROJECT_ID) + " ");

                    break;
                case 5:
                    dt = ExecuteQuery("EXEC USP_PMS_PROJECT @MODE = 5, @PROJECT_BUSINESSUNIT_ID = '" + Convert.ToInt32(_obj_Pms_Project.BUID) + "'" +
                                       ",@PROJECT_ORG_ID = " + Convert.ToString(_obj_Pms_Project.PROJECT_ORG_ID) + ", @PROJECT_NAME= '" + Convert.ToString(_obj_Pms_Project.PROJECT_NAME) + "'" +
                                       " ");

                    break;
                case 6:
                    dt = ExecuteQuery("EXEC USP_PMS_PROJECT @MODE = 6,@PROJECT_ORG_ID = " + Convert.ToString(_obj_Pms_Project.PROJECT_ORG_ID) + ",@PROJECT_BUSINESSUNIT_ID = " + Convert.ToString(_obj_Pms_Project.BUID) + " "
                                       );

                    break;    

                case 7:
                    dt = ExecuteQuery("EXEC USP_PMS_PROJECT @MODE = 7");   
                  
                    break;
                case 8:
                    dt = ExecuteQuery("EXEC USP_PMS_PROJECT @MODE = 8,@PROJECT_ORG_ID = " + Convert.ToString(_obj_Pms_Project.PROJECT_ORG_ID) + ",@EMP_LOGIN_ID= " + Convert.ToInt32(_obj_Pms_Project.LOGIN_ID) + " ");
                    break;
                case 9:
                    dt = ExecuteQuery("EXEC USP_PMS_PROJECT @MODE = 9,@PROJECT_ORG_ID = " + Convert.ToString(_obj_Pms_Project.PROJECT_ORG_ID) + ",@EMP_CODE= '" + Convert.ToString(_obj_Pms_Project.EMP_CODE) + "',@PROJECT_BUSINESSUNIT_ID = '"+ Convert.ToInt32(_obj_Pms_Project.BUID) + "'");
                    break;
                case 10:
                    dt = ExecuteQuery("EXEC USP_PMS_PROJECT @MODE = 10,@PROJECT_ORG_ID = " + Convert.ToString(_obj_Pms_Project.PROJECT_ORG_ID) + ",@EMP_CODE= '" + Convert.ToString(_obj_Pms_Project.EMP_CODE) + "',@PROJECT_BUSINESSUNIT_ID = '" + Convert.ToInt32(_obj_Pms_Project.BUID) + "'");
                    break;
                default:
                    break;
            }
            return dt;
        }

        /// <summary>
        /// This Method is used for insertion, deletion and updation of project based upon criteria
        /// </summary>
        /// <returns>
        /// Bool
        /// </returns>
        public static bool set_Project(SPMS_PROJECT _obj_Pms_Project)
        {
            bool status = false;
            switch (_obj_Pms_Project.Mode)
            {
                case 3:
                    if (ExecuteNonQuery("EXEC USP_PMS_PROJECT @MODE = 3,@PROJECT_NAME= '" + Convert.ToString(_obj_Pms_Project.PROJECT_NAME) + "'" +
                                       ", @PROJECT_DESCRIPTION= '" + Convert.ToString(_obj_Pms_Project.PROJECT_DESCRIPTION) + "'" +
                                       ",@PROJECT_ORG_ID = " + Convert.ToString(_obj_Pms_Project.PROJECT_ORG_ID) + ", @PROJECT_BUSINESSUNIT_ID = '" + Convert.ToInt32(_obj_Pms_Project.BUID) + "'" +
                                       ", @PROJECT_CREATEDBY=" + Convert.ToInt32(_obj_Pms_Project.PROJECT_CREATEDBY)+ ""+
                                       ", @PROJECT_CREATEDDATE='" + Convert.ToDateTime(_obj_Pms_Project.PROJECT_CREATEDDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case 4:
                    if (ExecuteNonQuery("EXEC USP_PMS_PROJECT @MODE = 4 ,@PROJECT_ID= " + Convert.ToString(_obj_Pms_Project.PROJECT_ID)+ ""+
                                         ", @PROJECT_NAME= '" + Convert.ToString(_obj_Pms_Project.PROJECT_NAME) + "'" +
                                         ", @PROJECT_DESCRIPTION= '" + Convert.ToString(_obj_Pms_Project.PROJECT_DESCRIPTION) + "'" +
                                         ", @PROJECT_BUSINESSUNIT_ID = '" + Convert.ToInt32(_obj_Pms_Project.BUID) + "'" +
                                         ", @PROJECT_LASTMDFBY =" + Convert.ToInt32(_obj_Pms_Project.PROJECT_LASTMDFBY)+""+
                                         ", @PROJECT_LASTMDFDATE='" + Convert.ToDateTime(_obj_Pms_Project.PROJECT_LASTMDFDATE).ToString("MM/dd/yyyy") + "'"))


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

        #region SMHR_AX

        /// <summary>
        /// This method is used TO GET PROJECTDETAILS BASED ON PROJECT_ID
        /// </summary>
        /// <returns>
        /// DataTable WITH PROJECT INFORMATION
        /// </returns>
        public static DataTable get_Smhr_Ax(SMHR_AX _obj_Smhr_Ax)
        {
            DataTable dt = new DataTable();
            switch (_obj_Smhr_Ax.Mode)
            {

                case 1:
                    dt = ExecuteQuery("EXEC [USP_SMHR_AX] @MODE = 1 ,@SMHR_AX_ORG_ID=" + Convert.ToInt32(_obj_Smhr_Ax.SMHR_AX_ORG_ID) + ",@EMP_LOGIN_ID='"+_obj_Smhr_Ax.LOGIN_ID+"'");
                    break;
                case 2:
                    dt = ExecuteQuery("EXEC [USP_SMHR_AX] @MODE = 2,@SMHR_AX_ID = " + Convert.ToString(_obj_Smhr_Ax.SMHR_AX_ID) + " ");

                    break;
                case 5:
                    dt = ExecuteQuery("EXEC [USP_SMHR_AX] @MODE = 5, @SMHR_AX_BU_ID = '" + Convert.ToInt32(_obj_Smhr_Ax.SMHR_AX_BU_ID) + "'" +
                                       " ");

                    break;

                default:
                    break;
            }
            return dt;
        }

        /// <summary>
        /// This Method is used for insertion, deletion and updation of  based upon criteria
        /// </summary>
        /// <returns>
        /// Bool
        /// </returns>
        public static bool set_Smhr_Ax(SMHR_AX _obj_Smhr_Ax)
        {
            bool status = false;
            switch (_obj_Smhr_Ax.Mode)
            {
                case 3:
                    if (ExecuteNonQuery("EXEC [USP_SMHR_AX] @MODE = 3,@SMHR_AX_DIM1= '" + Convert.ToString(_obj_Smhr_Ax.SMHR_AX_DIM1) + "'" +
                                       ",@SMHR_AX_DIM2= '" + Convert.ToString(_obj_Smhr_Ax.SMHR_AX_DIM2) + "'" +
                                       ",@SMHR_AX_DIM3= '" + Convert.ToString(_obj_Smhr_Ax.SMHR_AX_DIM3) + "'" +
                                       ", @SMHR_AX_BU_ID = '" + Convert.ToInt32(_obj_Smhr_Ax.SMHR_AX_BU_ID) + "'" +
                                       ", @SMHR_AX_CREATEDBY=" + Convert.ToInt32(_obj_Smhr_Ax.SMHR_AX_CREATEDBY) + "" +
                                       ",@SMHR_AX_ORG_ID=" + Convert.ToInt32(_obj_Smhr_Ax.SMHR_AX_ORG_ID) + "" +
                                       ", @SMHR_AX_CREATEDDATE='" + Convert.ToDateTime(_obj_Smhr_Ax.SMHR_AX_CREATEDDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case 4:
                    if (ExecuteNonQuery("EXEC [USP_SMHR_AX] @MODE = 4,@SMHR_AX_DIM1= '" + Convert.ToString(_obj_Smhr_Ax.SMHR_AX_DIM1) + "'" +
                                       ",@SMHR_AX_DIM2= '" + Convert.ToString(_obj_Smhr_Ax.SMHR_AX_DIM2) + "'" +
                                       ",@SMHR_AX_DIM3= '" + Convert.ToString(_obj_Smhr_Ax.SMHR_AX_DIM3) + "'" +
                                       ", @SMHR_AX_BU_ID = '" + Convert.ToInt32(_obj_Smhr_Ax.SMHR_AX_BU_ID) + "'" +
                                       ", @SMHR_AX_ID = '" + Convert.ToInt32(_obj_Smhr_Ax.SMHR_AX_ID) + "'" +
                                       ", @SMHR_AX_LASTMDFBY=" + Convert.ToInt32(_obj_Smhr_Ax.SMHR_AX_LASTMDFBY) + "" +
                                       ", @SMHR_AX_LASTMDFDATE='" + Convert.ToDateTime(_obj_Smhr_Ax.SMHR_AX_LASTMDFDATE).ToString("MM/dd/yyyy") + "'"))
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

        #region SMHR_HRA

        /// <summary>
        /// This method is used TO GET PROJECTDETAILS BASED ON PROJECT_ID
        /// </summary>
        /// <returns>
        /// DataTable WITH PROJECT INFORMATION
        /// </returns>
        public static DataTable get_Smhr_Hra(SMHR_HRA _obj_Smhr_Hra)
        {
            DataTable dt = new DataTable();
            switch (_obj_Smhr_Hra.Mode)
            {

                case 1:
                    dt = ExecuteQuery("EXEC [USP_SMHR_HRA] @MODE = 1,@SMHR_ORG_ID = " + Convert.ToString(_obj_Smhr_Hra.SMHR_ORG_ID) + " ");
                    break;
                case 2:
                    dt = ExecuteQuery("EXEC [USP_SMHR_HRA] @MODE = 2,@SMHR_ORG_ID = " + Convert.ToString(_obj_Smhr_Hra.SMHR_ORG_ID) + ", @SMHR_PAYITEMID1 = '" + Convert.ToInt32(_obj_Smhr_Hra.SMHR_PAYITEMID1) + "'" +
                                       " ");
                    break;

                case 3:
                    dt = ExecuteQuery("EXEC [USP_SMHR_HRA] @MODE = 3,@SMHR_ORG_ID = " + Convert.ToString(_obj_Smhr_Hra.SMHR_ORG_ID) + " ");
                    break;

                case 4:
                    dt = ExecuteQuery("EXEC [USP_SMHR_HRA] @MODE = 4,@SMHR_ORG_ID = " + Convert.ToString(_obj_Smhr_Hra.SMHR_ORG_ID) + " ");
                    break;

                case 5:
                    dt = ExecuteQuery("EXEC [USP_SMHR_HRA] @MODE = 5,@SMHR_ORG_ID = " + Convert.ToString(_obj_Smhr_Hra.SMHR_ORG_ID) + ",@SMHR_PAYITEMID1 = " + Convert.ToString(_obj_Smhr_Hra.SMHR_PAYITEMID1) + " ");
                    break;
                case 6:
                    dt = ExecuteQuery("EXEC [USP_SMHR_HRA] @MODE = 6,@SMHR_ORG_ID = " + Convert.ToString(_obj_Smhr_Hra.SMHR_ORG_ID) + ",@SMHR_HRA_MUL_ID = ' " + Convert.ToString(_obj_Smhr_Hra.SMHR_HRA_MUL_ID) + " ' ");
                    break;


                case 7:
                    dt = ExecuteQuery("EXEC [USP_SMHR_HRA] @MODE = 7,@SMHR_ORG_ID = " + Convert.ToString(_obj_Smhr_Hra.SMHR_ORG_ID) + ",@SMHR_PAYITEMID1 = " + Convert.ToString(_obj_Smhr_Hra.SMHR_PAYITEMID1) + ",@smhr_org_id1 = " + Convert.ToString(_obj_Smhr_Hra.SMHR_HRA_LASTMDFBY) + ",@SMHR_HRA_MUL_ID = ' " + Convert.ToString(_obj_Smhr_Hra.SMHR_HRA_MUL_ID) + " ' ");
                    break;
                default:
                    break;
            }
            return dt;
        }

        /// <summary>
        /// This Method is used for insertion, deletion and updation of  based upon criteria
        /// </summary>
        /// <returns>
        /// Bool
        /// </returns>
        //public static bool set_Smhr_hra(SMHR_AX _obj_Smhr_Ax)
        //{
        //    bool status = false;
        //    switch (_obj_Smhr_Ax.Mode)
        //    {
        //        case 3:
        //            if (ExecuteNonQuery("EXEC [USP_SMHR_AX] @MODE = 3,@SMHR_AX_DIM1= '" + Convert.ToString(_obj_Smhr_Ax.SMHR_AX_DIM1) + "'" +
        //                               ",@SMHR_AX_DIM2= '" + Convert.ToString(_obj_Smhr_Ax.SMHR_AX_DIM2) + "'" +
        //                               ",@SMHR_AX_DIM3= '" + Convert.ToString(_obj_Smhr_Ax.SMHR_AX_DIM3) + "'" +
        //                               ", @SMHR_AX_BU_ID = '" + Convert.ToInt32(_obj_Smhr_Ax.SMHR_AX_BU_ID) + "'" +
        //                               ", @SMHR_AX_CREATEDBY=" + Convert.ToInt32(_obj_Smhr_Ax.SMHR_AX_CREATEDBY) + "" +
        //                               ", @SMHR_AX_CREATEDDATE='" + Convert.ToDateTime(_obj_Smhr_Ax.SMHR_AX_CREATEDDATE).ToString("MM/dd/yyyy") + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;
        //        case 4:
        //            if (ExecuteNonQuery("EXEC [USP_SMHR_AX] @MODE = 4,@SMHR_AX_DIM1= '" + Convert.ToString(_obj_Smhr_Ax.SMHR_AX_DIM1) + "'" +
        //                               ",@SMHR_AX_DIM2= '" + Convert.ToString(_obj_Smhr_Ax.SMHR_AX_DIM2) + "'" +
        //                               ",@SMHR_AX_DIM3= '" + Convert.ToString(_obj_Smhr_Ax.SMHR_AX_DIM3) + "'" +
        //                               ", @SMHR_AX_BU_ID = '" + Convert.ToInt32(_obj_Smhr_Ax.SMHR_AX_BU_ID) + "'" +
        //                               ", @SMHR_AX_ID = '" + Convert.ToInt32(_obj_Smhr_Ax.SMHR_AX_ID) + "'" +
        //                               ", @SMHR_AX_LASTMDFBY=" + Convert.ToInt32(_obj_Smhr_Ax.SMHR_AX_LASTMDFBY) + "" +
        //                               ", @SMHR_AX_LASTMDFDATE='" + Convert.ToDateTime(_obj_Smhr_Ax.SMHR_AX_LASTMDFDATE).ToString("MM/dd/yyyy") + "'"))
        //                status = true;
        //            else
        //                status = false;
        //            break;

        //        default:
        //            break;
        //    }
        //    return status;

        //}

        #endregion



        #region SMHR_EMP_HRA

        /// <summary>
        /// This method is used TO GET PROJECTDETAILS BASED ON PROJECT_ID
        /// </summary>
        /// <returns>
        /// DataTable WITH PROJECT INFORMATION
        /// </returns>
        public static DataTable get_Smhr_emp_Hra(SMHR_EMP_HRA _obj_Smhr_emp_Hra)
        {
            DataTable dt = new DataTable();
            switch (_obj_Smhr_emp_Hra.Mode)
            {

                case 1:
                    dt = ExecuteQuery("EXEC USP_SMHR_EMP_HRA @MODE = 1 ");
                    break;
                case 2:
                    dt = ExecuteQuery("EXEC USP_SMHR_EMP_HRA @MODE = 2,@SMHR_HRA_ID = " + Convert.ToString(_obj_Smhr_emp_Hra.SMHR_HRA_ID) + " ");
                    break;
                case 4:
                    dt = ExecuteQuery("EXEC USP_SMHR_EMP_HRA @MODE = 4,@SMHR_HRA_EMP_ID = " + Convert.ToString(_obj_Smhr_emp_Hra.SMHR_HRA_EMP_ID) + " ");
                    break;
               
                default:
                    break;
            }
            return dt;
        }

        /// <summary>
        /// This Method is used for insertion, deletion and updation of  based upon criteria
        /// </summary>
        /// <returns>
        /// Bool
        /// </returns>
        public static bool set_Smhr_EMP_hra(SMHR_EMP_HRA _obj_Smhr_emp_Hra)
        {
            bool status = false;
            switch (_obj_Smhr_emp_Hra.Mode)
            {
                case 3:
                    if (ExecuteNonQuery("EXEC USP_SMHR_EMP_HRA @MODE = 3,@SMHR_HRA_BU_ID= " + Convert.ToString(_obj_Smhr_emp_Hra.SMHR_HRA_BU_ID) +
                                       ",@SMHR_HRA_PAYITEM_ID= " + Convert.ToInt32(_obj_Smhr_emp_Hra.SMHR_HRA_PAYITEM_ID)  +
                                       ",@SMHR_HRA_EXCESS_PAYITEM_ID= '" + Convert.ToString(_obj_Smhr_emp_Hra.SMHR_HRA_EXCESS_PAYITEM_ID) + "'" +
                                       ",@SMHR_HRA_TAX_EXEMPT_ID= " + Convert.ToString(_obj_Smhr_emp_Hra.SMHR_HRA_TAX_EXEMPT_ID)  +
                                       ",@SMHR_HRA_EMP_ID= " + Convert.ToString(_obj_Smhr_emp_Hra.SMHR_HRA_EMP_ID)  +
                                       ",@SMHR_HRA_EMP_HRAVALUE= '" + Convert.ToString(_obj_Smhr_emp_Hra.SMHR_HRA_EMP_HRAVALUE) + "'" +
                                       ",@SMHR_HRA_EMP_ACTUALRENT_PAID= '" + Convert.ToString(_obj_Smhr_emp_Hra.SMHR_HRA_EMP_ACTUALRENT_PAID) + "'" +
                                       ",@SMHR_HRA_EMP_EXCESSSALARY= '" + Convert.ToString(_obj_Smhr_emp_Hra.SMHR_HRA_EMP_EXCESSSALARY) + "'" +
                                       ",@SMHR_HRA_EMP_TAX_LIMIT= '" + Convert.ToString(_obj_Smhr_emp_Hra.SMHR_HRA_EMP_TAX_LIMIT) + "'" +
                                       ",@SMHR_HRA_EMP_EXEMPTAMOUNT= '" + Convert.ToString(_obj_Smhr_emp_Hra.SMHR_HRA_EMP_EXEMPTAMOUNT) + "'" +
                                       ",@SMHR_ORG_ID= " + Convert.ToString(_obj_Smhr_emp_Hra.SMHR_ORG_ID)  +
                                       ", @SMHR_HRA_CREATEDBY=" + Convert.ToInt32(_obj_Smhr_emp_Hra.SMHR_HRA_CREATEDBY) + "" +
                                       ", @SMHR_HRA_CREATEDDATE='" + Convert.ToDateTime(_obj_Smhr_emp_Hra.SMHR_HRA_CREATEDDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case 5:
                    if (ExecuteNonQuery("EXEC USP_SMHR_EMP_HRA @MODE = 5,@SMHR_HRA_EMP_ID= " + Convert.ToString(_obj_Smhr_emp_Hra.SMHR_HRA_EMP_ID) +
                                       " "))
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
        #region PMS_APPRAISAL CYCLE
        public static DataTable get_Appraisalcycle(PMS_Appraisalcycle _obj_Pms_Appraisalcycle)
        {

            if (_obj_Pms_Appraisalcycle.MODE == 1)
            {
                return ExecuteQuery("EXEC [USP_PMS_APPRAISALCYCLE_form]  @MODE = '" + _obj_Pms_Appraisalcycle.MODE + "',@APPRCYCLE_ORG_ID = " + _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID + "");
            }
            else if (_obj_Pms_Appraisalcycle.MODE == 2)
            {
                return ExecuteQuery("EXEC [USP_PMS_APPRAISALCYCLE_form] @mode=2,@APPRCYCLE_ID = " + _obj_Pms_Appraisalcycle.APPRCYCLE_ID + ",@APPRCYCLE_ORG_ID = " + _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID + "");
            }
            else if (_obj_Pms_Appraisalcycle.MODE == 7)
            {
                return ExecuteQuery("EXEC [USP_PMS_APPRAISALCYCLE_form] @mode=7, @APPRCYCLE_ORG_ID = " + _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID + ",@APPRCYCLE_BU_ID = " + _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID + ", @APPRCYCLE_ID = " + _obj_Pms_Appraisalcycle.APPRCYCLE_ID + "");
            }

            else if (_obj_Pms_Appraisalcycle.MODE == 14)
            {
                return ExecuteQuery("EXEC [USP_PMS_APPRAISALCYCLE_form] @mode=14, @APPRCYCLE_ORG_ID = " + _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID + ",@APPRCYCLE_BU_ID = " + _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID + " ");
            }
            else if (_obj_Pms_Appraisalcycle.MODE == 6)
            {
                return ExecuteQuery("EXEC [USP_PMS_APPRAISALCYCLE_form] @Mode=6 , @APPRCYCLE_ID = " + _obj_Pms_Appraisalcycle.APPRCYCLE_ID + "");
            }
            else if (_obj_Pms_Appraisalcycle.MODE == 9)
            {
                return ExecuteQuery("EXEC [USP_PMS_APPRAISALCYCLE_form] @Mode=9, @APPRCYCLE_BU_ID = " + _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID + ", @APPRCYCLE_ORG_ID = " + _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID + "");
            }
            else if (_obj_Pms_Appraisalcycle.MODE == 11)
            {
                return ExecuteQuery("EXEC [USP_PMS_APPRAISALCYCLE_form] @Mode=11, @APPRCYCLE_ORG_ID = " + _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID + ", @APPRCYCLE_ID = " + _obj_Pms_Appraisalcycle.APPRCYCLE_ID + "");
            }
            else if (_obj_Pms_Appraisalcycle.MODE == 12)
            {
                return ExecuteQuery("EXEC [USP_PMS_APPRAISALCYCLE_form] @Mode=12, @APPRCYCLE_NAME = '" + Convert.ToString(_obj_Pms_Appraisalcycle.APPRCYCLE_NAME) + "'" +
                                      ", @APPRCYCLE_ORG_ID = " + _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID + ", @APPRCYCLE_BU_ID = " + _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID + "");
            }
            else if (_obj_Pms_Appraisalcycle.MODE == 13)
            {
                return ExecuteQuery("EXEC [USP_PMS_APPRAISALCYCLE_form] @Mode=13, @APPRCYCLE_ORG_ID = " + _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID + ", @APPRCYCLE_ID = " + _obj_Pms_Appraisalcycle.APPRCYCLE_ID + "");
            }
            else if (_obj_Pms_Appraisalcycle.MODE == 15)
            {
                return ExecuteQuery("EXEC [USP_PMS_APPRAISALCYCLE_form] @Mode=15, @APPRCYCLE_ORG_ID = " + _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID + ", @APPRCYCLE_ID = " + _obj_Pms_Appraisalcycle.APPRCYCLE_ID + ",@EMP_ID='" + _obj_Pms_Appraisalcycle.EMP_ID + "'");
            }
            else if (_obj_Pms_Appraisalcycle.MODE == 10)
            {
                return ExecuteQuery("EXEC [USP_PMS_APPRAISALCYCLE_form] @Mode=10,  @APPCYCLE_STARTDATE = '" + Convert.ToDateTime(_obj_Pms_Appraisalcycle.APPCYCLE_STARTDATE).ToString("MM/dd/yyyy") + "'" +
                                      ", @APPRCYCLE_ORG_ID = " + _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID + ", @APPCYCLE_ENDDATE = '" + Convert.ToDateTime(_obj_Pms_Appraisalcycle.APPCYCLE_ENDDATE).ToString("MM/dd/yyyy") + "'" +
                                      ", @APPRCYCLE_BU_ID = '"+ Convert.ToInt32(_obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID)+ "'"+
                                      " ");
            }
            else if (_obj_Pms_Appraisalcycle.MODE == 16)
            {
                return ExecuteQuery("EXEC [USP_PMS_APPRAISALCYCLE_form] @Mode=16, @APPRCYCLE_ORG_ID = " + _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID + ", @APPRCYCLE_ID = " + _obj_Pms_Appraisalcycle.APPRCYCLE_ID);
            }
            else
            {
                return ExecuteQuery("EXEC [USP_PMS_APPRAISALCYCLE_form] @Mode=8, @APPRCYCLE_ORG_ID = " + _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID + ",@APPRCYCLE_BU_ID = " + _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID + " ");
            }




        }
        public static bool set_Appraisalcycle(PMS_Appraisalcycle _obj_Pms_Appraisalcycle)
        {
            if (_obj_Pms_Appraisalcycle.MODE == 3)
            {


                return ExecuteNonQuery(" EXEC [USP_PMS_APPRAISALCYCLE_form] @APPRCYCLE_ID = '" + _obj_Pms_Appraisalcycle.APPRCYCLE_ID + "'" +
                                      ", @APPRCYCLE_NAME = '" + Convert.ToString(_obj_Pms_Appraisalcycle.APPRCYCLE_NAME) + "'" +
                                      ", @APPRCYCLE_DESC = '" + Convert.ToString(_obj_Pms_Appraisalcycle.APPRCYCLE_DESC) + "'" +
                                      ", @APPRCYCLE_ISACTIVE = '" + Convert.ToBoolean(_obj_Pms_Appraisalcycle.APPRCYCLE_ISACTIVE) + "'" +
                                      ", @APPRCYCLE_SELFAPPRAISAL = '" + _obj_Pms_Appraisalcycle.APPRCYCLE_SELFAPPRAISAL + "'" +
                                      ", @APPCYCLE_STARTDATE = '" + Convert.ToDateTime(_obj_Pms_Appraisalcycle.APPCYCLE_STARTDATE).ToString("MM/dd/yyyy") + "'" +
                                      ", @APPCYCLE_ENDDATE = '" + Convert.ToDateTime(_obj_Pms_Appraisalcycle.APPCYCLE_ENDDATE).ToString("MM/dd/yyyy") + "'" +
                                      ", @APPRCYCLE_CREATEDBY = '" + _obj_Pms_Appraisalcycle.CREATEDBY + "'" +
                                      ", @APPRCYCLE_ORG_ID = '" + _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID + "'" +
                                      ", @APPRCYCLE_BU_ID = '" + _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID + "'" +
                                      ", @APPRCYCLE_CREATED_DATE = '" + Convert.ToDateTime(_obj_Pms_Appraisalcycle.CREATEDDATE).ToString("MM/dd/yyyy") + "'" +
                                      ",  @MODE = '" + _obj_Pms_Appraisalcycle.MODE + "'");


            }
            else if (_obj_Pms_Appraisalcycle.MODE == 4)
            {
                return ExecuteNonQuery(" EXEC [USP_PMS_APPRAISALCYCLE_form] @APPRCYCLE_ID = '" + _obj_Pms_Appraisalcycle.APPRCYCLE_ID + "'" +
                                      ",  @APPRCYCLE_DESC = '" + Convert.ToString(_obj_Pms_Appraisalcycle.APPRCYCLE_DESC) + "'" +
                                      ", @APPRCYCLE_ISACTIVE = '" + Convert.ToBoolean(_obj_Pms_Appraisalcycle.APPRCYCLE_ISACTIVE) + "'" +
                                     ", @APPRCYCLE_SELFAPPRAISAL = '" + _obj_Pms_Appraisalcycle.APPRCYCLE_SELFAPPRAISAL + "'" +
                                     ", @APPRCYCLE_MODIFIEDBY = '" + _obj_Pms_Appraisalcycle.APPRCYCLE_MODIFIEDBY + "'" +
                                      ", @APPRCYCLE_MODIFIED_DATE = '" + Convert.ToDateTime(_obj_Pms_Appraisalcycle.APPRCYCLE_MODIFIED_DATE).ToString("MM/dd/yyyy") + "'" +
                                      ",  @MODE = '" + _obj_Pms_Appraisalcycle.MODE + "'");

            }


            return true;

        }
        #endregion

        #region attendance reportslist

        public static DataTable get_Employee1(SMHR_EMPLOYEE1 _obj_SMHR_EMPLOYEE1)
        {
            DataTable dt = new DataTable();
            switch (_obj_SMHR_EMPLOYEE1.MODE)
            {

                case 1:
                    dt = ExecuteQuery("EXEC [USP_SMHR_ATTENDANCEREPORTS_LIST] @MODE = 1,@EMP_ID = '" + Convert.ToString(_obj_SMHR_EMPLOYEE1.EMP_ID) + "'" +
                                      ",@BU_ID = '" + _obj_SMHR_EMPLOYEE1.BU_ID + "'" +
                                      ",@ATTENDANCE_DATE='" + _obj_SMHR_EMPLOYEE1.DATE1 + "'");
                    break;

                case 2:
                    dt = ExecuteQuery("EXEC USP_SMHR_ATTENDANCEREPORTS_LIST @MODE = 2 ,@EMP_ID = '" + Convert.ToString(_obj_SMHR_EMPLOYEE1.EMP_ID) + "'" +
                                      ",@BU_ID = '" + _obj_SMHR_EMPLOYEE1.BU_ID + "'" +
                                      " ");
                    break;


                case 4:
                    dt = ExecuteQuery("EXEC USP_SMHR_ATTENDANCEREPORTS_LIST @MODE = 4 ,@EMP_ID = '" + Convert.ToString(_obj_SMHR_EMPLOYEE1.EMP_ID) + "'" +
                                      ", @DATE_string = '" + (_obj_SMHR_EMPLOYEE1.DATE_STRING) + "'" +
                                      " ,@BU_ID = '" + _obj_SMHR_EMPLOYEE1.BU_ID + "'" +
                                      " ");
                    break;

                case 5:
                    dt = ExecuteQuery("EXEC USP_SMHR_ATTENDANCEREPORTS_LIST @MODE = 5,@EMP_ID = '" + Convert.ToString(_obj_SMHR_EMPLOYEE1.EMP_ID) + "'" +
                                      ", @emp_prddtl_id = '" + _obj_SMHR_EMPLOYEE1.emp_code + "'" +
                                      ",@BU_ID = '" + _obj_SMHR_EMPLOYEE1.BU_ID + "'" +
                                      ",@LASTMDFBY = '" + _obj_SMHR_EMPLOYEE1.LASTMDFBY + "'" +
                                      " ");
                    break;
                case 6:
                    dt = ExecuteQuery("EXEC USP_SMHR_ATTENDANCEREPORTS_LIST @MODE = 6, @DATE_string = '" + _obj_SMHR_EMPLOYEE1.DATE_STRING + "'" +
                                      ",@BU_ID = '" + _obj_SMHR_EMPLOYEE1.BU_ID + "'" +
                                      "  ");
                    break;
                case 7:
                    dt = ExecuteQuery("EXEC USP_SMHR_ATTENDANCEREPORTS_LIST @MODE = 7,@EMP_ID = '" + Convert.ToString(_obj_SMHR_EMPLOYEE1.EMP_ID) + "'" +
                                      " ");
                    break;
                case 8:
                    dt = ExecuteQuery("EXEC USP_SMHR_ATTENDANCEREPORTS_LIST @MODE = 8,@emp_code = '" + Convert.ToString(_obj_SMHR_EMPLOYEE1.EMP_ID) + "'" +
                                     ",@BU_ID = '" + _obj_SMHR_EMPLOYEE1.BU_ID + "'"+
                                     ",@ORGANISATION_ID='"+_obj_SMHR_EMPLOYEE1.ORGID+"'");
                    break;
                case 9:
                    dt = ExecuteQuery("EXEC USP_SMHR_ATTENDANCEREPORTS_LIST @MODE = 9 ,@EMP_ID = '" + Convert.ToString(_obj_SMHR_EMPLOYEE1.EMP_ID) + "'" +
                                      ", @DATE_string = '" + (_obj_SMHR_EMPLOYEE1.DATE_STRING) + "'" +
                                      " ,@BU_ID = '" + _obj_SMHR_EMPLOYEE1.BU_ID + "'" +
                                      " ");
                    break;

                case 12:
                    dt = ExecuteQuery("EXEC USP_SMHR_ATTENDANCEREPORTS_LIST @MODE = 12,@EMP_ID = '" + Convert.ToString(_obj_SMHR_EMPLOYEE1.EMP_ID) + "'" +
                                      ", @DATE_string = '" + _obj_SMHR_EMPLOYEE1.DATE_STRING + "'" +
                                      " ,@BU_ID = '" + _obj_SMHR_EMPLOYEE1.BU_ID + "'" +
                                      " ");
                    break;

                case 13:
                    dt = ExecuteQuery("EXEC USP_SMHR_ATTENDANCEREPORTS_LIST @MODE = 13 ,@EMP_ID = '" + Convert.ToString(_obj_SMHR_EMPLOYEE1.EMP_ID) + "'" +
                                      " ");
                    break;


                case 14:
                    dt = ExecuteQuery("EXEC USP_SMHR_ATTENDANCEREPORTS_LIST @MODE = 14, @DATE_string = '" + _obj_SMHR_EMPLOYEE1.DATE_STRING + "'" +
                                      "  ");
                    break;
                    // for checking employee has joined or not for the selected attendance date
                case 15:
                    dt = ExecuteQuery("EXEC USP_SMHR_ATTENDANCEREPORTS_LIST @MODE = 15 ,@EMP_ID = '" + Convert.ToString(_obj_SMHR_EMPLOYEE1.EMP_ID) + "'" +
                                      ",@ATTENDANCE_DATE='" + _obj_SMHR_EMPLOYEE1.DATE1 + "'");
                    break;
                    // checking for holiday for particular date for the business unit
                case 16:
                    dt = ExecuteQuery("EXEC USP_SMHR_ATTENDANCEREPORTS_LIST @MODE = 16 ,@BU_ID = '" + Convert.ToString(_obj_SMHR_EMPLOYEE1.BU_ID) +
                        "',@DATE_STRING='" + _obj_SMHR_EMPLOYEE1.DATE_STRING + "'");
                    break;
                    // checking weekly off for the selected employee on selected attendance date
                case 17:
                    dt = ExecuteQuery("EXEC USP_SMHR_ATTENDANCEREPORTS_LIST @MODE = 17 ,@EMP_ID1 = '" + Convert.ToString(_obj_SMHR_EMPLOYEE1.EMP_ID) + "'" +
                                      ",@DATE_STRING1='" + _obj_SMHR_EMPLOYEE1.DATE_STRING + "',@ORGANISATION_ID='"+_obj_SMHR_EMPLOYEE1.ORGID+"'");
                    break;
                    // to validate attendance date is with in start date and end date of the financial period
                case 18:
                    dt = ExecuteQuery("EXEC USP_SMHR_ATTENDANCEREPORTS_LIST @MODE = 18,@ATTENDANCE_PERIOD_DTL_ID='"+_obj_SMHR_EMPLOYEE1.finperiod+
                        "',@ATTENDANCE_DATE='"+_obj_SMHR_EMPLOYEE1.DATE1+"'");
                    break;

                default:
                    break;
            }
            return dt;
        }

        public static bool set_Employee1(SMHR_EMPLOYEE1 _obj_SMHR_EMPLOYEE1)
        {
            if (_obj_SMHR_EMPLOYEE1.MODE == 10)
            {


                //return ExecuteNonQuery(" EXEC [USP_SMHR_ATTENDANCEREPORTS_LIST] @MODE = 10 ,@EMP_ID = '" + Convert.ToString(_obj_SMHR_EMPLOYEE1.EMP_ID) + "'" +
                //                      ", @ATTENDANCE_STATUS=" + Convert.ToString(_obj_SMHR_EMPLOYEE1.ATTENDANCE_STATUS1)
                //                        + ", @DATE = '" + _obj_SMHR_EMPLOYEE1.DATE.ToString("MM/dd/yyyy") + "'" +
                //                      " ,@BU_ID = '" + _obj_SMHR_EMPLOYEE1.BU_ID + "'" +
                //                      " ");


                return ExecuteNonQuery(" EXEC [USP_SMHR_ATTENDANCEREPORTS_LIST] @MODE = 10 ,@EMP_ID = '" + Convert.ToString(_obj_SMHR_EMPLOYEE1.EMP_ID) + "'" +
                                    ", @ATTENDANCE_STATUS=" + Convert.ToString(_obj_SMHR_EMPLOYEE1.ATTENDANCE_STATUS1)
                                      + ", @DATE_string = '" + _obj_SMHR_EMPLOYEE1.DATE_STRING + "'" +
                                      ",@BU_ID = '" + _obj_SMHR_EMPLOYEE1.BU_ID + "'" +
                                    " ");


            }



            return true;

        }


        #endregion


        #region PMS_FEEDBACK


        public static DataTable get_Feedback(PMS_FEEDBACK _obj_pms_Feedback)
        {
            DataTable dt = new DataTable();
            switch (_obj_pms_Feedback.Mode)
            {

                case 1:
                    dt = ExecuteQuery("EXEC USP_PMS_FEEDBACK @MODE = 1");
                    break;

                case 4:
                    dt = ExecuteQuery("EXEC USP_PMS_FEEDBACK @MODE = 4");
                    break;
                default:
                    break;
            }
            return dt;
        }


        public static bool set_Feedback(PMS_FEEDBACK _obj_pms_Feedback)
        {
            bool status = false;
            switch (_obj_pms_Feedback.Mode)
            {
                case 3:
                    if (ExecuteNonQuery("EXEC USP_PMS_FEEDBACK @MODE = 3 , @FEEDBACK_COMMENTS = '" + Convert.ToString(_obj_pms_Feedback.FEEDBACK_COMMENTS) + "'" +
                                      " ,  @FEEDBACK_RATING = " + Convert.ToInt32(_obj_pms_Feedback.FEEDBACK_RATING) +
                                      " , @FEEDBACK_DATE = '" + Convert.ToDateTime(_obj_pms_Feedback.FEEDBACK_DATE).ToString("MM/dd/yyyy") + "'" +
                                      " ,@FEEDBACK_MGR_EMP_ID = " + Convert.ToInt32(_obj_pms_Feedback.FEEDBACK_MGR_EMP_ID) +
                                      " , @FEEDBACK_CREATEDBY = " + Convert.ToInt32(_obj_pms_Feedback.FEEDBACK_CREATEDBY) +
                                      ", @FEEDBACK_CREATEDDATE = '" + Convert.ToDateTime(_obj_pms_Feedback.FEEDBACK_CREATEDDATE).ToString("MM/dd/yyyy") + "'"))
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

        #region PMS_EMPSETUP



        public static DataTable get_EmpSetup(PMS_EMPSETUP _obj_Pms_EmpSetup)
        {
            DataTable dt = new DataTable();
            switch (_obj_Pms_EmpSetup.Mode)
            {

                case 1:
                    dt = ExecuteQuery("EXEC USP_PMS_EMPLOYEESETUP @MODE = 1");
                    break;
                case 2:
                    dt = ExecuteQuery("EXEC USP_PMS_EMPLOYEESETUP @MODE = 2,@EMP_SETUP_ID= " + Convert.ToString(_obj_Pms_EmpSetup.EMP_SETUP_ID) +
                                      " ");
                    break;
                case 4:
                    dt = ExecuteQuery("EXEC USP_PMS_EMPLOYEESETUP @MODE = 4 ,@BU_ID= " + Convert.ToString(_obj_Pms_EmpSetup.BU_ID) +
                                      " ,@EMP_ID= " + Convert.ToString(_obj_Pms_EmpSetup.EMP_ID) + "  ");

                    break;
                case 5:
                    dt = ExecuteQuery("EXEC USP_PMS_EMPLOYEESETUP @MODE = 5 ,@BU_ID= " + Convert.ToString(_obj_Pms_EmpSetup.BU_ID) +
                                      " ,@EMP_ID= " + Convert.ToString(_obj_Pms_EmpSetup.EMP_ID) + " ,@REPORTINGMGR_ID= " + Convert.ToString(_obj_Pms_EmpSetup.REPORTINGMGR_ID) +
                                     " ,@GENERALMGR_ID = " + Convert.ToString(_obj_Pms_EmpSetup.GENERALMGR_ID) + "  ");


                    break;
                case 6:
                    dt = ExecuteQuery("EXEC USP_PMS_EMPLOYEESETUP @MODE = 6 ,@BU_ID= " + Convert.ToString(_obj_Pms_EmpSetup.BU_ID) +
                                      ",@EMP_SETUP_CREATEDBY= " + Convert.ToString(_obj_Pms_EmpSetup.CREATEDBY) +
                                      " ,@EMP_ID= " + Convert.ToString(_obj_Pms_EmpSetup.EMP_ID) + "   ");


                    break;
                case 7:
                    dt = ExecuteQuery("EXEC USP_PMS_EMPLOYEESETUP @MODE = 7 ,@BU_ID= " + Convert.ToString(_obj_Pms_EmpSetup.BU_ID) +
                                      " ,@EMP_SETUP_LASTMDFBY= " + Convert.ToString(_obj_Pms_EmpSetup.EMP_SETUP_LASTMDFBY) +
                                      " ,@EMP_ID= " + Convert.ToString(_obj_Pms_EmpSetup.EMP_ID) + "   ");


                    break;

                case 8:
                    dt = ExecuteQuery("EXEC USP_PMS_EMPLOYEESETUP @MODE = 8 ,@BU_ID= " + Convert.ToString(_obj_Pms_EmpSetup.BU_ID) +
                                      " ,@EMP_ID= " + Convert.ToString(_obj_Pms_EmpSetup.EMP_ID) + ",@REPORTINGMGR_ID= " + Convert.ToString(_obj_Pms_EmpSetup.REPORTINGMGR_ID) +
                                     "    ");


                    break;
                case 9:
                    dt = ExecuteQuery("EXEC USP_PMS_EMPLOYEESETUP @MODE = 9 ,@BU_ID= " + Convert.ToString(_obj_Pms_EmpSetup.BU_ID) +
                                      "  ,@EMP_SETUP_ORG_ID= " + Convert.ToString(_obj_Pms_EmpSetup.CREATEDBY) +
                                      ",@EMP_SETUP_LASTMDFBY= " + Convert.ToString(_obj_Pms_EmpSetup.EMP_SETUP_LASTMDFBY) +
                                      " ");


                    break;
                case 10:
                    dt = ExecuteQuery("EXEC USP_PMS_EMPLOYEESETUP @MODE = 10 ,@BU_ID= " + Convert.ToString(_obj_Pms_EmpSetup.BU_ID) +
                                      "   ");


                    break;
                case 11:
                    dt = ExecuteQuery("EXEC USP_PMS_EMPLOYEESETUP @MODE = 11 ,@BU_ID= " + Convert.ToString(_obj_Pms_EmpSetup.BU_ID) +
                                      " ,@EMP_SETUP_ORG_ID= " + Convert.ToString(_obj_Pms_EmpSetup.CREATEDBY) +
                                      ",@EMP_SETUP_LASTMDFBY= " + Convert.ToString(_obj_Pms_EmpSetup.EMP_SETUP_LASTMDFBY) +
                                      "  ");


                    break;
                case 12:
                    dt = ExecuteQuery("EXEC USP_PMS_EMPLOYEESETUP @MODE = 12 ,@BU_ID= " + Convert.ToString(_obj_Pms_EmpSetup.BU_ID) +
                                      ",@EMP_SETUP_LASTMDFBY= " + Convert.ToString(_obj_Pms_EmpSetup.EMP_SETUP_LASTMDFBY) +
                                      " ,@EMP_SETUP_ORG_ID= " + Convert.ToString(_obj_Pms_EmpSetup.CREATEDBY) +
                                      "   ");


                    break;
                case 14:
                    dt = ExecuteQuery("EXEC USP_PMS_EMPLOYEESETUP @MODE = 14 ,@EMP_ID= " + Convert.ToString(_obj_Pms_EmpSetup.EMP_ID) +
                                      "  ,@EMP_SETUP_ORG_ID= " + Convert.ToString(_obj_Pms_EmpSetup.EMP_SETUP_LASTMDFBY) +
                                      "  ");


                    break;
                case 15:
                    dt = ExecuteQuery("EXEC USP_PMS_EMPLOYEESETUP @MODE = 15 ,@EMP_ID= " + Convert.ToString(_obj_Pms_EmpSetup.EMP_ID) +
                                      "   ");


                    break;
                case 16:
                    dt = ExecuteQuery("EXEC USP_PMS_EMPLOYEESETUP @MODE = 16 ,@REPORTINGMGR_ID= " + Convert.ToString(_obj_Pms_EmpSetup.REPORTINGMGR_ID) +
                                      "   ");


                    break;
                case 17:
                    dt = ExecuteQuery("EXEC USP_PMS_EMPLOYEESETUP @MODE = 17 ,@EMP_ID= " + Convert.ToString(_obj_Pms_EmpSetup.EMP_ID) +
                                      ",@EMP_SETUP_LASTMDFBY= " + Convert.ToString(_obj_Pms_EmpSetup.EMP_SETUP_LASTMDFBY) +
                                      "   ");


                    break;
                case 18:
                    dt = ExecuteQuery("EXEC USP_PMS_EMPLOYEESETUP @MODE = 18 ,@EMP_ID= " + Convert.ToString(_obj_Pms_EmpSetup.EMP_ID) +
                                      ",@EMP_SETUP_ORG_ID= " + Convert.ToString(_obj_Pms_EmpSetup.ORGANISATION_ID) +
                                      ",@BU_ID = " + Convert.ToInt32(_obj_Pms_EmpSetup.BU_ID) +
                                      ", @APPRAISALCYCLE_ID= " + Convert.ToInt32(_obj_Pms_EmpSetup.GSLIFECYCLE) + " ");


                    break;
                case 19:
                    dt = ExecuteQuery("EXEC USP_PMS_EMPLOYEESETUP @MODE = 19 ,@EMP_ID= " + Convert.ToString(_obj_Pms_EmpSetup.EMP_ID) +
                                      ",@EMP_SETUP_ORG_ID= " + Convert.ToString(_obj_Pms_EmpSetup.ORGANISATION_ID) +
                                      ",@BU_ID = " + Convert.ToInt32(_obj_Pms_EmpSetup.BU_ID) +
                                      ", @APPRAISALCYCLE_ID= " + Convert.ToInt32(_obj_Pms_EmpSetup.GSLIFECYCLE) + " ");


                    break;
                case 20:
                    dt = ExecuteQuery("EXEC USP_PMS_EMPLOYEESETUP @MODE = 20 ,@EMP_ID= " + Convert.ToString(_obj_Pms_EmpSetup.EMP_ID) +
                                      ",@EMP_SETUP_ORG_ID= " + Convert.ToString(_obj_Pms_EmpSetup.ORGANISATION_ID) +
                                      ",@BU_ID = " + Convert.ToInt32(_obj_Pms_EmpSetup.BU_ID) +
                                      ", @APPRAISALCYCLE_ID= " + Convert.ToInt32(_obj_Pms_EmpSetup.GSLIFECYCLE) + " ");


                    break;
                case 22:
                    dt = ExecuteQuery("EXEC USP_PMS_EMPLOYEESETUP @MODE = 22 ,@EMP_ID= " + Convert.ToString(_obj_Pms_EmpSetup.EMP_ID) +
                                      ",@EMP_SETUP_ORG_ID= " + Convert.ToString(_obj_Pms_EmpSetup.ORGANISATION_ID) +
                                      ",@BU_ID = " + Convert.ToInt32(_obj_Pms_EmpSetup.BU_ID) +
                                      ", @APPRAISALCYCLE_ID= " + Convert.ToInt32(_obj_Pms_EmpSetup.GSLIFECYCLE) + " ");


                    break;
                default:
                    break;
            }
            return dt;
        }





        public static bool set_EmpSetup(PMS_EMPSETUP _obj_Pms_EmpSetup)
        {
            bool status = false;
            switch (_obj_Pms_EmpSetup.Mode)
            {
                case 3:
                    if (ExecuteNonQuery("EXEC USP_PMS_EMPLOYEESETUP @MODE = 3 , @BU_ID= " + Convert.ToString(_obj_Pms_EmpSetup.BU_ID) +
                                      " ,@EMP_ID= " + Convert.ToString(_obj_Pms_EmpSetup.EMP_ID) +
                                     " , @REPORTINGMGR_ID= " + Convert.ToString(_obj_Pms_EmpSetup.REPORTINGMGR_ID) +
                                     " ,@GENERALMGR_ID = '" + Convert.ToString(_obj_Pms_EmpSetup.GENERALMGR_ID) + "'" +
                                      " ,  @EMP_SETUP_CREATEDBY = " + Convert.ToInt32(_obj_Pms_EmpSetup.EMP_SETUP_CREATEDBY) +
                                      ", @EMP_SETUP_CREATEDDATE = '" + Convert.ToDateTime(_obj_Pms_EmpSetup.EMP_SETUP_CREATEDDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case 20:
                    if (ExecuteNonQuery("EXEC USP_PMS_EMPLOYEESETUP @MODE = 20 ,@EMP_SETUP_ID= " + Convert.ToString(_obj_Pms_EmpSetup.EMP_SETUP_ID)
                                       + ", @BU_ID= " + Convert.ToString(_obj_Pms_EmpSetup.BU_ID) +
                                      " ,@EMP_ID= " + Convert.ToString(_obj_Pms_EmpSetup.EMP_ID) +
                                     " , @REPORTINGMGR_ID= " + Convert.ToString(_obj_Pms_EmpSetup.REPORTINGMGR_ID) +
                                     " ,@GENERALMGR_ID = '" + Convert.ToString(_obj_Pms_EmpSetup.GENERALMGR_ID) + "'" +
                                      " ,  @EMP_SETUP_LASTMDFBY = " + Convert.ToInt32(_obj_Pms_EmpSetup.EMP_SETUP_LASTMDFBY) +
                                      ", @EMP_SETUP_LASTMDFDATE = '" + Convert.ToDateTime(_obj_Pms_EmpSetup.EMP_SETUP_LASTMDFDATE).ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                default:
                    break;
            }
            return status;

        }





        public static DataTable get_LoginInfo(PMS_EMPSETUP _obj_Pms_EmpSetup)
        { //thismode defined at roles.aspx.cs
            DataTable dt = new DataTable();

            dt = ExecuteQuery("EXEC USP_PMS_LOGIN_CREDENTIALS_bak @EMPID=" + Convert.ToInt32(_obj_Pms_EmpSetup.EMP_ID) + ",@EMP_ORGANISATION_ID=" + Convert.ToInt32(_obj_Pms_EmpSetup.LASTMDFBY) + ",@BUID = " + Convert.ToInt32(_obj_Pms_EmpSetup.BU_ID) + "");


            return dt;
        }




        #endregion

        #region PMS_GETEMPLOYEE



        public static DataTable get_Employee(PMS_GETEMPLOYEE _obj_Pms_GetEmployee)
        {
            DataTable dt = new DataTable();
            switch (_obj_Pms_GetEmployee.Mode)
            {


                case 1:
                    dt = ExecuteQuery("EXEC USP_PMS_GETEMPLOYEE @MODE = 1 ,@BU_ID= " + Convert.ToString(_obj_Pms_GetEmployee.BU_ID) +
                                      "   ");

                    break;
                case 3:
                    dt = ExecuteQuery("EXEC USP_PMS_GETEMPLOYEE @MODE = 3 ,@BU_ID= " + Convert.ToString(_obj_Pms_GetEmployee.BU_ID) +
                                      " ,@EMP_ID= " + Convert.ToString(_obj_Pms_GetEmployee.EMP_ID) + " ,@REPORTINGMGR_ID= " + Convert.ToString(_obj_Pms_GetEmployee.REPORTINGMGR_ID) +
                                     "  ");


                    break;
                case 2:
                    dt = ExecuteQuery("EXEC USP_PMS_GETEMPLOYEE @MODE = 2 ,@BU_ID= " + Convert.ToString(_obj_Pms_GetEmployee.BU_ID) +
                                      " ,@EMP_ID= " + Convert.ToString(_obj_Pms_GetEmployee.EMP_ID) + "   ");


                    break;


                default:
                    break;
            }
            return dt;
        }


        public static DataTable get_RMEmployees(PMS_GETEMPLOYEE _obj_Pms_GetEmployee)
        {

            DataTable dt = new DataTable();
            if (_obj_Pms_GetEmployee.Mode == 1)
            {
                dt = ExecuteQuery("EXEC USP_PMS_MANAGERCREDENTIALS_BAK @EMP_ID= " + Convert.ToString(_obj_Pms_GetEmployee.EMP_ID) + ",@EMP_ORGANISATION_ID= " + Convert.ToString(_obj_Pms_GetEmployee.LASTMDFBY) + ",@MODE="+Convert.ToInt32(_obj_Pms_GetEmployee.Mode)+"   ");
            }
            else if (_obj_Pms_GetEmployee.Mode == 4)
            {
                dt = ExecuteQuery("EXEC USP_PMS_MANAGERCREDENTIALS_BAK @EMP_ID= " + Convert.ToString(_obj_Pms_GetEmployee.EMP_ID) + ",@EMP_ORGANISATION_ID= " + Convert.ToString(_obj_Pms_GetEmployee.LASTMDFBY) + ",@MODE=" + Convert.ToInt32(_obj_Pms_GetEmployee.Mode) + ",@BU="+ Convert.ToInt32(_obj_Pms_GetEmployee.BU_ID)+"   ");
            }
            else if (_obj_Pms_GetEmployee.Mode == 5)
            {
                dt = ExecuteQuery("EXEC USP_PMS_MANAGERCREDENTIALS_BAK @EMP_ID= " + Convert.ToString(_obj_Pms_GetEmployee.EMP_ID) + ",@EMP_ORGANISATION_ID= " + Convert.ToString(_obj_Pms_GetEmployee.LASTMDFBY) + ",@MODE=" + Convert.ToInt32(_obj_Pms_GetEmployee.Mode) + ",@BU=" + Convert.ToInt32(_obj_Pms_GetEmployee.BU_ID) + "   ");
            }
            else if (_obj_Pms_GetEmployee.Mode == 6)
            {
                dt = ExecuteQuery("EXEC USP_PMS_MANAGERCREDENTIALS_BAK @EMP_ID= " + Convert.ToString(_obj_Pms_GetEmployee.EMP_ID) + ",@EMP_ORGANISATION_ID= " + Convert.ToString(_obj_Pms_GetEmployee.ORGANISATION_ID) + ",@MODE=" + Convert.ToInt32(_obj_Pms_GetEmployee.Mode) + "   ");
            }
            else
            {
                dt = ExecuteQuery("EXEC USP_PMS_MANAGERCREDENTIALS_BAK @EMP_ID= " + Convert.ToString(_obj_Pms_GetEmployee.EMP_ID) + ",@EMP_ORGANISATION_ID= " + Convert.ToString(_obj_Pms_GetEmployee.LASTMDFBY) + " ,@MODE=" + Convert.ToInt32(_obj_Pms_GetEmployee.Mode) + ",@BU=" + Convert.ToInt32(_obj_Pms_GetEmployee.BUID) + ",@GS_LIFECYCLE=" + Convert.ToInt32(_obj_Pms_GetEmployee.GS_APPRAISAL_CYCLE) + " ");
            }


            return dt;
        }
        public static DataTable get_GMEmployees(PMS_GETEMPLOYEE _obj_Pms_GetEmployee)
        {
            DataTable dt = new DataTable();
            dt = ExecuteQuery("EXEC USP_PMS_APPROVALMANAGERDETAILS_bak @EMP_ID= " + Convert.ToString(_obj_Pms_GetEmployee.EMP_ID) + ",@EMP_ORGID= " + Convert.ToString(_obj_Pms_GetEmployee.CREATEDBY) + "   ");


            return dt;
        }
        #endregion

        #region PMS_SELFAPPRAISALNOTIFICATION
        public static bool Send_Notification(PMS_NOTIFICATION _obj_Pms_Send_Notification)
        {
            bool status3 = false;
            if (ExecuteNonQuery("EXEC USP_MAIL_MGR_EMP_APPR @EMPID= " + Convert.ToString(_obj_Pms_Send_Notification.EMPID) + " ,@RMID= " + Convert.ToString(_obj_Pms_Send_Notification.RMID) + ",@EMP_ORGANISATION_ID= " + Convert.ToString(_obj_Pms_Send_Notification.CREATEDBY) + "  ")) ;
            {
                status3 = true;


                return status3;
            }

        }

        public static bool Send_NotificationMangerEmployee(PMS_NOTIFICATION _obj_Pms_Send_Notification)
        {
            bool status4 = false;
            if (ExecuteNonQuery("EXEC USP_MAIL_manageremp @EMPID= " + Convert.ToString(_obj_Pms_Send_Notification.EMPID) + ",@EMP_ORG_ID= " + Convert.ToString(_obj_Pms_Send_Notification.CREATEDBY) + "   ")) ;
            {
                status4 = true;


                return status4;
            }

        }
        public static bool Send_NotificationMangerApprover(PMS_NOTIFICATION _obj_Pms_Send_Notification)
        {
            bool status5 = false;
            if (ExecuteNonQuery("EXEC USP_MAIL_managerapprover @EMPID= " + Convert.ToString(_obj_Pms_Send_Notification.EMPID) + ",@EMP_ORG_ID= " + Convert.ToString(_obj_Pms_Send_Notification.LASTMDFBY) + "   ")) ;
            {
                status5 = true;


                return status5;
            }

        }
        public static bool Send_NotificationApproverManager(PMS_NOTIFICATION _obj_Pms_Send_Notification)
        {
            bool status7 = false;
            if (ExecuteNonQuery("EXEC USP_MAIL_approvermanager @EMPID= " + Convert.ToString(_obj_Pms_Send_Notification.EMPID) + ",@EMPORGID= " + Convert.ToString(_obj_Pms_Send_Notification.LASTMDFBY) + "   ")) ;
            {
                status7 = true;


                return status7;
            }

        }



        public static bool Send_NotificationApproverEmployee(PMS_NOTIFICATION _obj_Pms_Send_Notification)
        {
            bool status8 = false;
            if (ExecuteNonQuery("EXEC USP_MAIL_APPROVERemp @EMPID= " + Convert.ToString(_obj_Pms_Send_Notification.EMPID) + ",@EMPORGID= " + Convert.ToString(_obj_Pms_Send_Notification.CREATEDBY) + "   ")) ;
            {
                status8 = true;


                return status8;
            }

        }
        public static bool Send_Notification2(PMS_NOTIFICATION _obj_Pms_Send_Notification)
        {
            bool status4 = false;
            if (ExecuteNonQuery("EXEC USP_SEND_EMAIL_1 @EMPID= " + Convert.ToString(_obj_Pms_Send_Notification.EMPID) + ",@EMP_ORGANISATION_ID= " + Convert.ToString(_obj_Pms_Send_Notification.LASTMDFBY) + " ,@RMID= " + Convert.ToString(_obj_Pms_Send_Notification.RMID) + ",@APPRAISAL_CYCLE= " + Convert.ToString(_obj_Pms_Send_Notification.APPRAISAL_CYCLE) + "  ")) ;
            {
                status4 = true;


                return status4;
            }

        }

        public static bool Send_MgrNotification(PMS_NOTIFICATION _obj_Pms_Send_MgrNotification)
        {
            bool status4 = false;
            if (ExecuteNonQuery("EXEC USP_MAIL_MGR_APPMGR  @EMPID= " + Convert.ToString(_obj_Pms_Send_MgrNotification.EMPID) + " ,@RMID= " + Convert.ToString(_obj_Pms_Send_MgrNotification.RMID) + "  ")) ;

            {
                status4 = true;


                return status4;
            }
        }

        public static bool Send_AppMgrNotification(PMS_NOTIFICATION _obj_Pms_Send_AppMgrNotification)
        {
            bool status5 = false;
            if (ExecuteNonQuery("EXEC USP_MAIL_APPMGR_MGR222  @GMID= " + Convert.ToString(_obj_Pms_Send_AppMgrNotification.EMPID) + " ,@RMID= " + Convert.ToString(_obj_Pms_Send_AppMgrNotification.RMID) + "  ")) ;

            {
                status5 = true;


                return status5;
            }
        }

        public static bool Send_AppMgrNotification1(PMS_NOTIFICATION _obj_Pms_Send_AppMgrNotification1)
        {
            bool status6 = false;
            if (ExecuteNonQuery("EXEC USP_MAIL_APPMGR_MGR_EMP555  @EMPID= " + Convert.ToString(_obj_Pms_Send_AppMgrNotification1.EMPID) + " ,@GMID= " + Convert.ToString(_obj_Pms_Send_AppMgrNotification1.GMID) + "  ")) ;


            {
                status6 = true;


                return status6;
            }
        }
        #endregion

        #region SPMS_APPRAISALSTATUS


        public static DataTable get_AppStatus(SPMS_APRAISALSTATUS _obj_Pms_AppStatus)
        {
            DataTable dt = new DataTable();
            switch (_obj_Pms_AppStatus.Mode)
            {

                case 1:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISALSTATUS @MODE = 1 ");
                    break;
                case 2:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISALSTATUS @MODE = 2,@APP_STATUS_ORG_ID = " + Convert.ToString(_obj_Pms_AppStatus.APP_STATUS_ORG_ID) + ",@APP_EMP_ID = " + Convert.ToString(_obj_Pms_AppStatus.APP_EMP_ID) + " ");

                    break;
                case 5:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISALSTATUS @MODE = 5,@APP_EMP_ID = " + Convert.ToString(_obj_Pms_AppStatus.APP_EMP_ID) + " ");

                    break;
                case 6:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISALSTATUS @MODE = 6,@APP_EMP_ID = " + Convert.ToString(_obj_Pms_AppStatus.APP_EMP_ID) + ",@APP_STATUS_ORG_ID = " + Convert.ToString(_obj_Pms_AppStatus.APP_STATUS_ORG_ID) + " ,@APP_LASTMDFBY = " + Convert.ToString(_obj_Pms_AppStatus.APP_LASTMDFBY) + " ");

                    break;
                case 7:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISALSTATUS @MODE = 7,@APP_STATUS_ORG_ID = " + Convert.ToString(_obj_Pms_AppStatus.APP_STATUS_ORG_ID) + " ,@APP_STATUS_APPRAISALCYCLE= " + Convert.ToInt32(_obj_Pms_AppStatus.APP_STATUS_APPRAISALCYCLE) + " ");

                    break;

                case 8:
                    dt = ExecuteQuery("EXEC USP_PMS_APPRAISALSTATUS @MODE = 8,@APP_STATUS_ORG_ID = " + Convert.ToString(_obj_Pms_AppStatus.APP_STATUS_ORG_ID) + ",@APP_STATUS_APPRAISALCYCLE= " + _obj_Pms_AppStatus.APP_STATUS_APPRAISALCYCLE + "  ");

                    break;
                default:
                    break;
            }
            return dt;
        }


        public static bool set_AppStatus(SPMS_APRAISALSTATUS _obj_Pms_AppStatus)
        {
            bool status = false;
            switch (_obj_Pms_AppStatus.Mode)
            {
                case 3:
                    if (ExecuteNonQuery("EXEC USP_PMS_APPRAISALSTATUS @MODE = 3 , @APP_EMP_ID= '" + Convert.ToString(_obj_Pms_AppStatus.APP_EMP_ID) + "'" +
                                        ", @APP_STATUS_ORG_ID= '" + Convert.ToString(_obj_Pms_AppStatus.APP_STATUS_ORG_ID) + "'" +
                                        ", @APP_FINALRTG= '" + Convert.ToDecimal(_obj_Pms_AppStatus.APP_FINALRTG) + "'" +
                                       ", @APP_POTENTIALRTG= '" + Convert.ToDecimal(_obj_Pms_AppStatus.APP_POTENTIALRTG) + "'" +
                                       ", @APP_BUSINEESRTG= '" + Convert.ToDecimal(_obj_Pms_AppStatus.APP_BUSINEESRTG) + "'" +
                                        ", @APP_OVERALLRTG= '" + Convert.ToString(_obj_Pms_AppStatus.APP_OVERALLRTG) + "'" +
                                       ", @APP_STATUS= '" + Convert.ToString(_obj_Pms_AppStatus.APP_STATUS) + "'" +
                                         ", @APP_STATUS_APPRAISALCYCLE= '" + Convert.ToString(_obj_Pms_AppStatus.APP_STATUS_APPRAISALCYCLE) + "'" +
                                         ", @APP_CREATEDBY=" + Convert.ToInt32(_obj_Pms_AppStatus.APP_CREATEDBY)
                                      + " , @APP_CREATEDDATE='" + Convert.ToDateTime(_obj_Pms_AppStatus.APP_CREATEDDATE).ToString("MM/dd/yyyy") + "'"))
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

    }
}