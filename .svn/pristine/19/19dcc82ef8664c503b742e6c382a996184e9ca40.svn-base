using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
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
    // Developer:                 Rahul
    // ----------------------------------------------------------------------------------------
    public partial class BLL
    {
        #region Grievance Handling

        /// <summary>
        /// Get Employees
        /// </summary>
        /// <param name="_obj_smhr_employee"></param>
        /// <returns></returns>
        public static DataTable get_GrievanceEmployee(SMHR_EMPLOYEE _obj_smhr_employee)
        {
            return ExecuteQuery("EXEC USP_SMHR_EMPLOYEE_New @Operation = 'GETEMPDATA', @EMP_ID = '" + _obj_smhr_employee.EMP_ID + "', @ORGANISATION_ID = '" + _obj_smhr_employee.ORGANISATION_ID + "'");
        }
        /// <summary>
        /// Get all grievance master data
        /// </summary>
        /// <param name="_obj_smhr_Main"></param>
        /// <returns></returns>
        public static DataTable get_GrievanceDisciplinaryMasters(SMHR_MAIN _obj_smhr_Main)
        {
            return ExecuteQuery("EXEC USP_SMHR_GRIEVANCEMASTERS @Operation ='" + _obj_smhr_Main.OPERATION + "'" + ",@GRIEVANCEMASTER_ORGANISATION_ID=" + _obj_smhr_Main.ORGANISATION_ID + ",@COMMITTEE_ID='" + _obj_smhr_Main.COMMITTEE_ID + "'");
        }
        /// <summary>
        /// Insert incident record 
        /// </summary>
        /// <param name="_obj_Smhr_Grievance"></param>
        /// <returns></returns>
        public static bool record_Incident(SMHR_GRIEVANCE _obj_Smhr_Grievance)
        {
            bool status = false;
            switch (_obj_Smhr_Grievance.OPERATION)
            {
                case operation.Insert:
                    if (ExecuteNonQuery("EXEC USP_SMHR_GRIEVANCE @Operation = 'Insert', @GRIEVANCE_ID='" + _obj_Smhr_Grievance.GRIEVANCE_ID
                                      + "', @GRIEVANCE_ORGANISATION_ID = '" + _obj_Smhr_Grievance.ORGANISATION_ID
                                      + "', @GRIEVANCE_REPORTEDBY='" + _obj_Smhr_Grievance.GRIEVANCE_REPORTEDBY
                                      + "', @GRIEVANCE_REPORTEDON='" + _obj_Smhr_Grievance.GRIEVANCE_REPORTEDON
                                      + "', @GRIEVANCE_INCIDENTID='" + Convert.ToString(_obj_Smhr_Grievance.GRIEVANCE_INCIDENTID)
                                      + " ', @GRIEVANCE_INCIDENT='" + Convert.ToString(_obj_Smhr_Grievance.GRIEVANCE_INCIDENT)
                                      + "', @GRIEVANCE_INCIDENTTYPE_ID='" + _obj_Smhr_Grievance.GRIEVANCE_INCIDENTTYPE_ID
                                      + "', @GRIEVANCE_REPORTEDDATE='" + _obj_Smhr_Grievance.GRIEVANCE_REPORTEDDATE
                                      + "', @GRIEVANCE_INCIDENTDESCRIPTION='" + _obj_Smhr_Grievance.GRIEVANCE_INCIDENTDESCRIPTION
                                      + "', @GRIEVANCE_COMMITTEEID='" + _obj_Smhr_Grievance.GRIEVANCE_COMMITTEEID
                                      + " ', @GRIEVANCE_CREATEDBY= '" + Convert.ToString(_obj_Smhr_Grievance.CREATEDBY)
                                      + " ', @GRIEVANCE_CREATEDDATE='" + _obj_Smhr_Grievance.CREATEDDATE.ToString("MM/dd/yyyy")
                                      + "', @GRIEVANCE_LASTMDFBY  ='" + Convert.ToString(_obj_Smhr_Grievance.LASTMDFBY)
                                      + "' , @GRIEVANCE_LASTMDFDATE ='" + _obj_Smhr_Grievance.LASTMDFDATE.ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case operation.Update:
                    if (ExecuteNonQuery("EXEC USP_SMHR_GRIEVANCE @Operation = 'Update', @GRIEVANCE_ID='" + _obj_Smhr_Grievance.GRIEVANCE_ID
                                      + "', @GRIEVANCE_ORGANISATION_ID = '" + _obj_Smhr_Grievance.ORGANISATION_ID
                                      + "', @GRIEVANCE_INCIDENTDESCRIPTION='" + _obj_Smhr_Grievance.GRIEVANCE_INCIDENTDESCRIPTION
                                      + "', @GRIEVANCE_LASTMDFBY  ='" + Convert.ToString(_obj_Smhr_Grievance.LASTMDFBY)
                                      + "' , @GRIEVANCE_LASTMDFDATE ='" + _obj_Smhr_Grievance.LASTMDFDATE.ToString("MM/dd/yyyy") + "'"))
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
        /// Get Recorded Incidents
        /// </summary>
        /// <param name="_obj_Smhr_Grievance"></param>
        /// <returns></returns>
        public static DataTable get_Incidents(SMHR_GRIEVANCE _obj_Smhr_Grievance)
        {
            if (_obj_Smhr_Grievance.OPERATION == operation.Select)
            {
                if (_obj_Smhr_Grievance.GRIEVANCE_ID.ToString() == "0")
                    return ExecuteQuery("EXEC USP_SMHR_GRIEVANCE @Operation = 'select',@GRIEVANCE_ORGANISATION_ID = '" + _obj_Smhr_Grievance.ORGANISATION_ID + "'");
                else
                    return ExecuteQuery("EXEC USP_SMHR_GRIEVANCE @Operation = 'select', @GRIEVANCE_ID =" + Convert.ToString(_obj_Smhr_Grievance.GRIEVANCE_ID) + ",@GRIEVANCE_ORGANISATION_ID = '" + _obj_Smhr_Grievance.ORGANISATION_ID + "'");
            }
            else if (_obj_Smhr_Grievance.OPERATION == operation.Check)
            {
                return ExecuteQuery("EXEC USP_SMHR_GRIEVANCE @Operation = 'Check', @GRIEVANCE_INCIDENTTYPE_ID =" + Convert.ToString(_obj_Smhr_Grievance.GRIEVANCE_INCIDENTTYPE_ID) + ",@GRIEVANCE_ORGANISATION_ID = '" + _obj_Smhr_Grievance.ORGANISATION_ID + "'");
            }
            else
            {
                return new DataTable();
            }
        }
        /// <summary>
        /// Get Employee
        /// </summary>
        /// <param name="_obj_smhr_employee"></param>
        /// <returns></returns>
        public static DataTable getEmployee1(SMHR_EMPLOYEE _obj_smhr_employee)
        {
            if (_obj_smhr_employee.OPERATION == operation.Scale)
            {
                return ExecuteQuery("EXEC USP_SMHR_EMPLOYEE_New @Operation='Scale',@EMP_ID='" + _obj_smhr_employee.EMP_ID + "',@EMP_GRADE='" + _obj_smhr_employee.EMP_GRADE + "',@ORGANISATION_ID='" + _obj_smhr_employee.ORGANISATION_ID + "'");
            }
            else if (_obj_smhr_employee.OPERATION == operation.Employee)
            {
                return ExecuteQuery("EXEC USP_SMHR_EMPLOYEE_New @Operation='Employee',@EMP_GRADE='" + _obj_smhr_employee.EMP_GRADE + "',@EMP_BUSINESSUNIT_ID='" + _obj_smhr_employee.EMP_BUSINESSUNIT_ID + "'");
            }
            else
            {
                return new DataTable();
            }
        }
        #endregion

        #region Increment Cycle


        /// <summary>
        /// Get Financial Period Details
        /// </summary>
        /// <param name="_obj_smhr_IncrementCycle"></param>
        /// <returns></returns>
        public static DataTable Get_FinancialPeriodDetails(SMHR_INCREMENTCYCLE _obj_smhr_IncrementCycle)
        {
            if (_obj_smhr_IncrementCycle.OPERATION == operation.Select)
                return ExecuteQuery("EXEC USP_SMHR_INCREMENTCYCLE @Operation = 'Select', @INCREMENTCYCLE_PERIOD_ID = '" + _obj_smhr_IncrementCycle.INCREMENTCYCLE_PERIODID + "', @PERIOD_INCREMENT = '" + _obj_smhr_IncrementCycle.INCREMENTCYCLE_MONTH + "', @INCREMENTCYCLE_ORG_ID = '" + _obj_smhr_IncrementCycle.ORGANISATION_ID + "'");
            else if (_obj_smhr_IncrementCycle.OPERATION == operation.IncrementCycles)
                return ExecuteQuery("EXEC USP_SMHR_INCREMENTCYCLE @Operation = 'SELECTCYLCLES', @INCREMENTCYCLE_PERIOD_ID = '" + _obj_smhr_IncrementCycle.INCREMENTCYCLE_PERIODID + "', @PERIOD_INCREMENT = '" + _obj_smhr_IncrementCycle.INCREMENTCYCLE_MONTH + "', @INCREMENTCYCLE_ORG_ID = '" + _obj_smhr_IncrementCycle.ORGANISATION_ID + "'");
            else if (_obj_smhr_IncrementCycle.OPERATION == operation.FINANCIALPERIODSINCLUDED)
                return ExecuteQuery("EXEC USP_SMHR_INCREMENTCYCLE @Operation = 'FINANCIALPERIODSINCLUDED', @INCREMENTCYCLE_PERIOD_ID = '" + _obj_smhr_IncrementCycle.INCREMENTCYCLE_PERIODID + "', @PERIOD_INCREMENT = '" + _obj_smhr_IncrementCycle.INCREMENTCYCLE_MONTH + "', @INCREMENTCYCLE_ORG_ID = '" + _obj_smhr_IncrementCycle.ORGANISATION_ID + "'");
            else if (_obj_smhr_IncrementCycle.OPERATION == operation.FINANCIALPERIODSEXCLUDED)
                return ExecuteQuery("EXEC USP_SMHR_INCREMENTCYCLE @Operation = 'FINANCIALPERIODSEXCLUDED', @INCREMENTCYCLE_PERIOD_ID = '" + _obj_smhr_IncrementCycle.INCREMENTCYCLE_PERIODID + "', @PERIOD_INCREMENT = '" + _obj_smhr_IncrementCycle.INCREMENTCYCLE_MONTH + "', @INCREMENTCYCLE_ORG_ID = '" + _obj_smhr_IncrementCycle.ORGANISATION_ID + "'");
            else
                return ExecuteQuery("EXEC USP_SMHR_INCREMENTCYCLE @Operation = 'INCREMENTCYCLES', @INCREMENTCYCLE_PERIOD_ID = '" + _obj_smhr_IncrementCycle.INCREMENTCYCLE_PERIODID + "', @PERIOD_INCREMENT = '" + _obj_smhr_IncrementCycle.INCREMENTCYCLE_MONTH + "', @INCREMENTCYCLE_ORG_ID = '" + _obj_smhr_IncrementCycle.ORGANISATION_ID + "'");
        }
        /// <summary>
        /// Insert_IncrementCycles
        /// </summary>
        /// <param name="_obj_smhr_IncrementCycle"></param>
        /// <returns></returns>
        public static bool Insert_IncrementCycles(SMHR_INCREMENTCYCLE _obj_smhr_IncrementCycle)
        {
            bool status = false;
            int result = 0;
            List<SqlParameter> lstParameters = new List<SqlParameter>();

            lstParameters.Add(new SqlParameter("@INCREMENTCYCLE_PERIOD_ID", _obj_smhr_IncrementCycle.INCREMENTCYCLE_PERIODID));
            lstParameters.Add(new SqlParameter("@INCREMENTCYCLE_ORG_ID", _obj_smhr_IncrementCycle.ORGANISATION_ID));
            lstParameters.Add(new SqlParameter("@PERIOD_INCREMENT", _obj_smhr_IncrementCycle.INCREMENTCYCLE_MONTH));
            lstParameters.Add(new SqlParameter("@TBLINCREMENTCYCLES", _obj_smhr_IncrementCycle.TBLINCREMENTCYCLES));
            lstParameters.Add(new SqlParameter("@INCREMENTCYCLE_CREATEDBY", _obj_smhr_IncrementCycle.CREATEDBY));
            lstParameters.Add(new SqlParameter("@INCREMENTCYCLE_CREATEDDATE", _obj_smhr_IncrementCycle.CREATEDDATE));
            lstParameters.Add(new SqlParameter("@Operation", "Insert"));


            result = ExecuteNonQuery("USP_SMHR_INCREMENTCYCLE", lstParameters.ToArray());
            if (result > 0)
                status = true;
            else
                status = false;

            return status;
        }

        #endregion
    }


}