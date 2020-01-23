using System;
using System.Collections.Generic;
using System.Data;
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
    // Developer:                 Raga Sudha
    // ----------------------------------------------------------------------------------------  
    public partial class BLL
    {
        #region SMHR_INSPECTION_AREA
        public static DataTable get_InspectedBy(SMHR_INSPECTION_SCHEDULE _obj_smhr_Inspection_schedule)
        {
            return ExecuteQuery("EXEC USP_SMHR_INSPECTION_SCHEDULE @Operation = 'GET_INSPECTEDBY'" + ", @EMP_ID=" + _obj_smhr_Inspection_schedule.LOGIN_EMP_ID);
        }
        public static DataTable GET_INSPECTIONS_ASSIGNEDTO(SMHR_INSPECTION_SCHEDULE _obj_smhr_Inspection_schedule)
        {
            return ExecuteQuery("EXEC USP_SMHR_INSPECTION_MASTER @Operation = 'GET_INSPECTIONS_ASSIGNEDTO'" + ", @EMP_ID=" + _obj_smhr_Inspection_schedule.LOGIN_EMP_ID);
        }
        public static DataTable get_Identity_value(SMHR_INSPECTION_SCHEDULE _obj_smhr_Inspection_schedule)
        {
            return ExecuteQuery("EXEC USP_SMHR_INSPECTION_SCHEDULE @Operation = 'GETIDENTITY',@INSPECTION_SCHEDULE_ASSIGNED_TO='" + _obj_smhr_Inspection_schedule.INSPECTION_SCHEDULE_ASSIGNED_TO + "'"
                + ",@INSPECTION_SCHEDULE_FROMDATE='" + _obj_smhr_Inspection_schedule.INSPECTION_SCHEDULE_FROMDATE
                + "',@INSPECTION_SCHEDULE_TODATE='" + _obj_smhr_Inspection_schedule.INSPECTION_SCHEDULE_TODATE + "'");

        }
        public static bool set_Inspection_Area_FeedBack(SMHR_INSPECTION_AREA _obj_smhr_Inspection_Area)
        {
            bool status = false;
            if (_obj_smhr_Inspection_Area.OPERATION == operation.FeedBack)
            {
                if (ExecuteNonQuery("EXEC USP_SMHR_INSPECTION_AREA @OPERATION = 'FeedBack',@AREA_ID=" + _obj_smhr_Inspection_Area.AREA_ID +
                                        " ,@INSPECTION_AREA_ID=" + Convert.ToInt32(_obj_smhr_Inspection_Area.INSPECTION_AREA_ID) +
                                        " ,@INSPECTION_AREA_ISCOMPLIANT=" + Convert.ToBoolean(_obj_smhr_Inspection_Area.INSPECTION_AREA_ISCOMPLIANT) +
                                        " ,@INSPECTION_AREA_COMMENTS  ='" + Convert.ToString(_obj_smhr_Inspection_Area.INSPECTION_AREA_COMMENTS) +
                                        "',@INSPECTION_AREA_MODIFIED_BY  =" + Convert.ToInt32(_obj_smhr_Inspection_Area.INSPECTION_AREA_MODIFIED_BY) +
                                        " ,@INSPECTION_AREA_MODIFIEDDATE ='" + Convert.ToDateTime(_obj_smhr_Inspection_Area.INSPECTION_AREA_MODIFIEDDATE) + "'"))
                    status = true;
                else
                    status = false;
            }
            return status;
        }
        public static bool set_Inspection_Area(SMHR_INSPECTION_AREA _obj_smhr_Inspection_Area)
        {
            bool status = false;
            if (_obj_smhr_Inspection_Area.OPERATION == operation.Insert)
            {
                if (ExecuteNonQuery("EXEC USP_SMHR_INSPECTION_AREA @OPERATION = 'INSERT',@INSPECTION_AREA_SCHEDULE_ID = " + _obj_smhr_Inspection_Area.INSPECTION_AREA_SCHEDULE_ID +
                                    " ,@AREA_ID=" + _obj_smhr_Inspection_Area.AREA_ID +
                                    " ,@INSPECTION_AREA_ISCOMPLIANT=" + Convert.ToBoolean(_obj_smhr_Inspection_Area.INSPECTION_AREA_ISCOMPLIANT) +
                                    "  ,@INSPECTION_AREA_COMMENTS  ='" + Convert.ToString(_obj_smhr_Inspection_Area.INSPECTION_AREA_COMMENTS) +
                                    "'  ,@INSPECTION_AREA_CREATED_BY =" + Convert.ToInt32(_obj_smhr_Inspection_Area.INSPECTION_AREA_CREATED_BY) +
                                    "  ,@INSPECTION_AREA_CREATEDDATE ='" + Convert.ToDateTime(_obj_smhr_Inspection_Area.INSPECTION_AREA_CREATEDDATE) + "'"))
                    status = true;
                else
                    status = false;
            }

            if (_obj_smhr_Inspection_Area.OPERATION == operation.Update)
            {
                if (ExecuteNonQuery("EXEC USP_SMHR_INSPECTION_AREA @OPERATION = 'UPDATE',@INSPECTION_AREA_SCHEDULE_ID = " + _obj_smhr_Inspection_Area.INSPECTION_AREA_SCHEDULE_ID +
                                    ",@AREA_ID=" + _obj_smhr_Inspection_Area.AREA_ID +
                                    " ,@INSPECTION_AREA_ISCOMPLIANT=" +Convert.ToBoolean(_obj_smhr_Inspection_Area.INSPECTION_AREA_ISCOMPLIANT) +
                                    " ,@INSPECTION_AREA_COMMENTS='" +Convert.ToString(_obj_smhr_Inspection_Area.INSPECTION_AREA_COMMENTS )+
                                    "' ,@INSPECTION_AREA_MODIFIED_BY  =" + Convert.ToInt32(_obj_smhr_Inspection_Area.INSPECTION_AREA_MODIFIED_BY) +
                                    " ,@INSPECTION_AREA_MODIFIEDDATE ='" + Convert.ToDateTime(_obj_smhr_Inspection_Area.INSPECTION_AREA_MODIFIEDDATE) + "'"))
                    status = true;
                else
                    status = false;
            }
            if (_obj_smhr_Inspection_Area.OPERATION == operation.ISCOMPLIANT)
            {
                if (ExecuteNonQuery("EXEC USP_SMHR_INSPECTION_AREA @OPERATION = 'ISCOMPLIANT',@INSPECTION_AREA_SCHEDULE_ID = " + _obj_smhr_Inspection_Area.INSPECTION_AREA_SCHEDULE_ID +
                                    ",@AREA_ID=" + _obj_smhr_Inspection_Area.AREA_ID +
                                    " ,@INSPECTION_AREA_ISCOMPLIANT=" + Convert.ToBoolean(_obj_smhr_Inspection_Area.INSPECTION_AREA_ISCOMPLIANT) +
                                    " ,@INSPECTION_AREA_COMMENTS='" + Convert.ToString(_obj_smhr_Inspection_Area.INSPECTION_AREA_COMMENTS) +
                                    "' ,@INSPECTION_AREA_MODIFIED_BY  =" + Convert.ToInt32(_obj_smhr_Inspection_Area.INSPECTION_AREA_MODIFIED_BY) +
                                    " ,@INSPECTION_AREA_MODIFIEDDATE ='" + Convert.ToDateTime(_obj_smhr_Inspection_Area.INSPECTION_AREA_MODIFIEDDATE) + "'"))
                    status = true;
                else
                    status = false;
            }
            return status;
        }
        public static DataTable get_INSPECTION_SCHEDULEAREA(SMHR_INSPECTION_AREA _obj_smhr_Inspection_Schedule)
        {
            return ExecuteQuery("EXEC USP_SMHR_INSPECTION_AREA @Operation = 'GET_INSPECTION_SCHEDULEAREA'" + ", @INSPECTION_AREA_SCHEDULE_ID=" + _obj_smhr_Inspection_Schedule.INSPECTION_AREA_SCHEDULE_ID);
        }
        public static DataTable GET_ALLINSPECTION_SCHEDULEAREA(SMHR_INSPECTION_AREA _obj_smhr_Inspection_Schedule)
        {
            return ExecuteQuery("EXEC USP_SMHR_INSPECTION_AREA @Operation = 'GET_ALLINSPECTION_SCHEDULEAREA'");
        }
        public static bool delete_Inspection_Area(SMHR_INSPECTION_AREA _obj_smhr_Inspection_Area)
        {
              bool status = false;
              if (ExecuteNonQuery("EXEC USP_SMHR_INSPECTION_AREA @OPERATION = 'DELETEAREADETAILS',@INSPECTION_AREA_SCHEDULE_ID = " + _obj_smhr_Inspection_Area.INSPECTION_AREA_SCHEDULE_ID))
                  status = true;
              else
                  status = false;
              return status;                 
        }
        public static DataTable get_AllInspectionSchedules2(SMHR_INSPECTION_SCHEDULE _obj_smhr_Inspection_Schedule)
        {
            return ExecuteQuery("EXEC USP_SMHR_INSPECTION_SCHEDULE @Operation = 'GET_ALLINSPECTIONSSCHEDULES2'" + ", @EMP_ID=" + _obj_smhr_Inspection_Schedule.LOGIN_EMP_ID + ",@INSPECTION_SCHEDULE_INSPECTION_ID="+_obj_smhr_Inspection_Schedule.INSPECTION_SCHEDULE_INSPECTION_ID);
        }
        public static DataTable get_Inspections_InspectedBy(SMHR_INSPECTION_SCHEDULE _obj_smhr_Inspection_Schedule)
        {
            return ExecuteQuery("EXEC USP_SMHR_INSPECTION_SCHEDULE @Operation = 'GET_INSPECTIONS_INSPECTEDBY'" + ", @EMP_ID=" + _obj_smhr_Inspection_Schedule.LOGIN_EMP_ID);
        }

        public static DataTable Get_MainInspectionsIds(SMHR_INSPECTION_SCHEDULE _obj_smhr_Inspection_Schedule, int inspID)
        {
            return ExecuteQuery("EXEC USP_SMHR_INSPECTION_SCHEDULE @Operation = 'GET_INSPECIONDATA_FINAL'" 
                                                            + ",@INSPECTION_SCHEDULE_ASSIGNED_TO = " + _obj_smhr_Inspection_Schedule.LOGIN_EMP_ID 
                                                            + ",@ORG_ID = " + _obj_smhr_Inspection_Schedule.ORGANISATION_ID
                                                            + ",@INSPECTION_SCHEDULE_INSPECTION_ID = " + inspID);
        }

        public static DataTable Get_FinalInspectionsData(SMHR_INSPECTION_SCHEDULE _obj_smhr_Inspection_Schedule, string inspIDs)
        {
            return ExecuteQuery("EXEC USP_SMHR_INSPECTION_SCHEDULE @Operation = 'GET_INSPECTIONS_GRID_DATA_FINAL'" + ",@INSPECTION_SCHEDULE_ASSIGNED_TO=" + _obj_smhr_Inspection_Schedule.LOGIN_EMP_ID + ",@INSPECTION_IDS='" + inspIDs + "'");
        }


        public static DataTable get_allareas_by_buID(SMHR_AREA _obj_smhr_area)
        {
            return ExecuteQuery("EXEC USP_SMHR_AREA @Operation = 'GET_ALLAREAS_BY_BUID'" + ", @AREA_BU=" + _obj_smhr_area.AREA_BUSINESSUNIT_ID);
        }
        public static DataTable get_allInspections_by_buID(SMHR_INSPECTION _obj_smhr_inspection)
        {
            return ExecuteQuery("EXEC USP_SMHR_INSPECTION_MASTER @Operation = 'GET_INSPECTIONS_BY_BUID'" + ", @INSPECTION_BU_ID=" + _obj_smhr_inspection.INSPECTION_BU_ID
                                                                                                         + ",@ORG_ID = " + _obj_smhr_inspection.ORGANISATION_ID);
        }
        public static DataTable Get_Past_Inspection_Data(SMHR_INSPECTION_SCHEDULE _obj_smhr_Inspection_Schedule, int empID)
        {
            return ExecuteQuery("EXEC USP_SMHR_INSPECTION_SCHEDULE @Operation = 'GET_PAST_INSPECTION_DATA'"
                                                                + ", @INSPECTION_SCHEDULE_FROMDATE='" + _obj_smhr_Inspection_Schedule.INSPECTION_SCHEDULE_FROMDATE
                                                                + "',@INSPECTION_SCHEDULE_TODATE='" + _obj_smhr_Inspection_Schedule.INSPECTION_SCHEDULE_TODATE
                                                                + "',@EMP_ID=" + empID
                                                                + " ,@ORG_ID=" + _obj_smhr_Inspection_Schedule.ORGANISATION_ID);
        }

        #endregion

        #region Duplication_H&S

        public static DataTable checkEquipmentexistsbyBuID(SMHR_EQUIPMENT _obj_smhr_equipment)
        {
            return ExecuteQuery("EXEC USP_SMHR_EQUIPMENT_MASTER @Operation = 'CHECKEXISTS_BY_BU_ID',@EQUIPMENT_NAME = '" + _obj_smhr_equipment.EQUIPMENT_NAME + "'" + ",@EQUIPMENT_BU_ID=" + _obj_smhr_equipment.BUID);
        }

        public static DataTable checkAreaexistsbyBuID(SMHR_AREA _obj_smhr_areas_master)
        {
            return ExecuteQuery("EXEC USP_SMHR_AREA @Operation = 'CHECKEXISTS_BY_BU_ID',@AREA_NAME = '" + _obj_smhr_areas_master.AREA_NAME + "'" + ",@AREA_BU=" + _obj_smhr_areas_master.AREA_BUSINESSUNIT_ID);
        }

        public static DataTable checkInspectionexistsbyBuID(SMHR_INSPECTION _obj_smhr_inspection)
        {
            return ExecuteQuery("EXEC USP_SMHR_INSPECTION_MASTER @Operation = 'CHECKEXISTS_BY_BU_ID',@INSPECTION_NAME = '" + _obj_smhr_inspection.INSPECTION_NAME + "'" + ",@INSPECTION_BU_ID=" + _obj_smhr_inspection.INSPECTION_BU_ID);
        }

        public static DataTable checkInspectionScheduleexistsbyBuID(SMHR_INSPECTION_SCHEDULE _obj_smhr_inspection_schedule)
        {
            return ExecuteQuery("EXEC USP_SMHR_INSPECTION_SCHEDULE @Operation = 'CHECKEXISTS_BY_BU_ID',@INSPECTION_SCHEDULE_BU_ID = '" + _obj_smhr_inspection_schedule.BUID + "'" + ",@INSPECTION_SCHEDULE_INSPECTION_ID=" + _obj_smhr_inspection_schedule.INSPECTION_SCHEDULE_INSPECTION_ID);
        }

        #endregion

        #region AreasLoading_H&S

        public static DataTable GET_AREA_BU_WISE(SMHR_AREA _obj_smhr_Area)
        {
            return ExecuteQuery("EXEC USP_SMHR_AREA @Operation = 'GET_AREA_BU_WISE'" +
                           ",@AREA_BU= " + _obj_smhr_Area.AREA_BUSINESSUNIT_ID +
                           ",@ORG_ID= " + _obj_smhr_Area.ORGANISATION_ID);
                           //",@AREA_ID= " + _obj_smhr_Area.AREA_ID
        }

        public static DataTable GET_AREA_BU_DI_WISE(SMHR_AREA _obj_smhr_Area)
        {
            return ExecuteQuery("EXEC USP_SMHR_AREA @Operation = 'GET_AREA_BU_DI_WISE'" +
                           ",@AREA_BU= " + _obj_smhr_Area.AREA_BUSINESSUNIT_ID +
                           ",@ORG_ID= " + _obj_smhr_Area.ORGANISATION_ID +
                           //",@AREA_ID= " + _obj_smhr_Area.AREA_ID +
                           ",@AREA_DIRECTORATE_ID= " + _obj_smhr_Area.AREA_DIRECTORATE_ID);
        }

        public static DataTable GET_AREA_BU_DI_DP_WISE(SMHR_AREA _obj_smhr_Area)
        {
            return ExecuteQuery("EXEC USP_SMHR_AREA @Operation = 'GET_AREA_BU_DI_DP_WISE'" +
                           ",@AREA_BU= " + _obj_smhr_Area.AREA_BUSINESSUNIT_ID +
                           ",@ORG_ID= " + _obj_smhr_Area.ORGANISATION_ID +
                           //",@AREA_ID= " + _obj_smhr_Area.AREA_ID +
                           ",@AREA_DIRECTORATE_ID= " + _obj_smhr_Area.AREA_DIRECTORATE_ID +
                           ",@AREA_DEPARTMENT_ID= " + _obj_smhr_Area.AREA_DEPARTMENT_ID);
        }

        public static DataTable GET_AREA_BU_DI_DP_SD_WISE(SMHR_AREA _obj_smhr_Area)
        {
            return ExecuteQuery("EXEC USP_SMHR_AREA @Operation = 'GET_AREA_BU_DI_DP_SD_WISE'" +
                           ",@AREA_BU= " + _obj_smhr_Area.AREA_BUSINESSUNIT_ID +
                           ",@ORG_ID= " + _obj_smhr_Area.ORGANISATION_ID +
                           //",@AREA_ID= " + _obj_smhr_Area.AREA_ID +
                           ",@AREA_DIRECTORATE_ID= " + _obj_smhr_Area.AREA_DIRECTORATE_ID +
                           ",@AREA_DEPARTMENT_ID= " + _obj_smhr_Area.AREA_DEPARTMENT_ID +
                           ",@AREA_SUBDEPARTMENT_ID= " + _obj_smhr_Area.AREA_SUBDEPARTMENT_ID);
        }

        #endregion

        #region PMS_APPROVAL_PROCESS

        public static bool set_PMS_APPROVAL_PROCESS(PMS_APPROVAL_PROCESS _obj_pms_approval_process)
        {
            bool status = false;
            if (_obj_pms_approval_process.OPERATION == operation.Insert)
            {
                if (ExecuteNonQuery("EXEC USP_PMS_APPROVAL_PROCESS @OPERATION = 'INSERT'"
                                                                            + ",@PMS_APPROVAL_PROCESS_EMP_ID_1 = " + _obj_pms_approval_process.PMS_APPROVAL_PROCESS_EMP_ID_1
                                                                            + ",@PMS_APPROVAL_PROCESS_EMP_ID_2 = " + _obj_pms_approval_process.PMS_APPROVAL_PROCESS_EMP_ID_2
                                                                            + ",@PMS_APPROVAL_PROCESS_EMP_ID_3 = " + _obj_pms_approval_process.PMS_APPROVAL_PROCESS_EMP_ID_3
                                                                            + ",@PMS_APPROVAL_PROCESS_ORGANISATION_ID = " + _obj_pms_approval_process.ORGANISATION_ID
                                                                            + ",@PMS_APPROVAL_PROCESS_STATUS = " + _obj_pms_approval_process.PMS_APPROVAL_PROCESS_STATUS
                                                                            + ",@PMS_APPROVAL_PROCESS_CREATED_BY = " + _obj_pms_approval_process.CREATEDBY
                                                                            + ",@PMS_APPROVAL_PROCESS_CREATED_DATE = '" + _obj_pms_approval_process.CREATEDDATE
                                                                            + "',@PMS_APPROVAL_PROCESS_BU_ID = " + _obj_pms_approval_process.BUID))
                    status = true;
            }
            if (_obj_pms_approval_process.OPERATION == operation.Update)
            {
                if (ExecuteNonQuery("EXEC USP_PMS_APPROVAL_PROCESS @OPERATION = 'UPDATE'"
                                                                            + ",@PMS_APPROVAL_PROCESS_ID = " + _obj_pms_approval_process.PMS_APPROVAL_PROCESS_ID
                                                                            //+ "@PMS_APPROVAL_PROCESS_EMP_ID_1 = " + _obj_pms_approval_process.PMS_APPROVAL_PROCESS_EMP_ID_1
                                                                            //+ "@PMS_APPROVAL_PROCESS_EMP_ID_2 = " + _obj_pms_approval_process.PMS_APPROVAL_PROCESS_EMP_ID_2
                                                                            //+ "@PMS_APPROVAL_PROCESS_EMP_ID_3 = " + _obj_pms_approval_process.PMS_APPROVAL_PROCESS_EMP_ID_3
                                                                            //+ "@PMS_APPROVAL_PROCESS_ORGANISATION_ID = " + _obj_pms_approval_process.ORGANISATION_ID
                                                                            + ",@PMS_APPROVAL_PROCESS_STATUS = " + _obj_pms_approval_process.PMS_APPROVAL_PROCESS_STATUS
                                                                            + ",@PMS_APPROVAL_PROCESS_MODIFIED_BY = " + _obj_pms_approval_process.LASTMDFBY
                                                                            + ",@PMS_APPROVAL_PROCESS_MODIFIED_DATE = '" + _obj_pms_approval_process.LASTMDFDATE + "'"))
                    status = true;
            }
            return status;
        }

        public static DataTable get_PMS_APPROVAL_PROCESS(int appPrcsID)
        {
            return ExecuteQuery("EXEC USP_PMS_APPROVAL_PROCESS @OPERATION = 'GETPMS_APPROVAL_PROCESS_BY_ID', @PMS_APPROVAL_PROCESS_ID = " + appPrcsID);
        }

        public static DataTable Load_PMS_APPROVAL_PROCESS_GRID(int OrgID)
        {
            return ExecuteQuery("EXEC USP_PMS_APPROVAL_PROCESS @OPERATION = 'LOAD_PMS_APPROVAL_PROCESS_GRID', @PMS_APPROVAL_PROCESS_ORGANISATION_ID =" + OrgID );
        }

        public static DataTable Check_PMS_Approval_Process_Exists(PMS_APPROVAL_PROCESS _obj_pms_approval_process)
        {
            return ExecuteQuery("EXEC USP_PMS_APPROVAL_PROCESS @OPERATION = 'CHECK_EXISTS',@PMS_APPROVAL_PROCESS_ORGANISATION_ID = " + _obj_pms_approval_process.ORGANISATION_ID
                                                                + ",@PMS_APPROVAL_PROCESS_STATUS = " + Convert.ToBoolean(_obj_pms_approval_process.PMS_APPROVAL_PROCESS_STATUS)
                                                                + ",@PMS_APPROVAL_PROCESS_BU_ID =" + _obj_pms_approval_process.BUID);
        }

        public static DataTable Check_PMS_Approval_Process_Update_Exists(int orgID, int BUID) //, int mode
        {
            return ExecuteQuery("EXEC USP_PMS_APPROVAL_PROCESS @OPERATION = 'CHECK_UPDATE_EXISTS',@PMS_APPROVAL_PROCESS_ORGANISATION_ID = " + orgID
                                                    + ",@PMS_APPROVAL_PROCESS_BU_ID =" + BUID);
                                                                    //+ ",@MODE = " + mode);
        }

        public static DataTable get_PMS_APPROVAL_PROCESS_BY_ORG_ID(int orgID, int BUID)
        {
            return ExecuteQuery("EXEC USP_PMS_APPROVAL_PROCESS @OPERATION = 'CHECK_EMPLOYEE', @PMS_APPROVAL_PROCESS_ORGANISATION_ID = " + orgID + ",@PMS_APPROVAL_PROCESS_BU_ID=" + BUID);
        }

        public static DataTable Load_Pms_Approver_Appraisal_Grid(PMS_EMPSETUP _obj_Pms_EmpSetup)
        {
            DataTable dt = new DataTable();

            switch (_obj_Pms_EmpSetup.Mode)
            {
                case 23:
                    dt = ExecuteQuery("EXEC USP_PMS_EMPLOYEESETUP @OPERATION = 'LOAD_APPROVE_APPRAISAL_GRID', @MODE = 23 ,@EMP_ID= " + Convert.ToString(_obj_Pms_EmpSetup.EMP_ID) +
                                      ",@EMP_SETUP_ORG_ID= " + Convert.ToString(_obj_Pms_EmpSetup.ORGANISATION_ID) +
                                      //",@BU_ID = " + Convert.ToInt32(_obj_Pms_EmpSetup.BU_ID) +
                                      ", @APPRAISALCYCLE_ID= " + Convert.ToInt32(_obj_Pms_EmpSetup.GSLIFECYCLE) + " ");
                    break;
                case 24:
                    dt = ExecuteQuery("EXEC USP_PMS_EMPLOYEESETUP @OPERATION = 'LOAD_APPROVE_APPRAISAL_GRID', @MODE = 24 ,@EMP_ID= " + Convert.ToString(_obj_Pms_EmpSetup.EMP_ID) +
                                      ",@EMP_SETUP_ORG_ID= " + Convert.ToString(_obj_Pms_EmpSetup.ORGANISATION_ID) +
                                      //",@BU_ID = " + Convert.ToInt32(_obj_Pms_EmpSetup.BU_ID) +
                                      ", @APPRAISALCYCLE_ID= " + Convert.ToInt32(_obj_Pms_EmpSetup.GSLIFECYCLE) + " ");
                    break;
                case 25:
                    dt = ExecuteQuery("EXEC USP_PMS_EMPLOYEESETUP @OPERATION = 'LOAD_APPROVE_APPRAISAL_GRID', @MODE = 25 ,@EMP_ID= " + Convert.ToString(_obj_Pms_EmpSetup.EMP_ID) +
                                      ",@EMP_SETUP_ORG_ID= " + Convert.ToString(_obj_Pms_EmpSetup.ORGANISATION_ID) +
                                      //",@BU_ID = " + Convert.ToInt32(_obj_Pms_EmpSetup.BU_ID) +
                                      ", @APPRAISALCYCLE_ID= " + Convert.ToInt32(_obj_Pms_EmpSetup.GSLIFECYCLE) + " ");
                    break;
                default:
                    break;
            }

            return dt;
        }

        #endregion
    }
}