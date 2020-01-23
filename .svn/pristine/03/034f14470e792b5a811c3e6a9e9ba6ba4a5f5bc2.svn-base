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
    // Filename:                  SMHR_KNA.cs
    // Class FullName:            SMHR.BLL
    // Class Name:                BLL
    // Class Kind Description:    Class
    // Purpose:                   Business Logic Layer
    // Developer:                 Dinesh
    // ----------------------------------------------------------------------------------------
    public partial class BLL
    {
        public static bool set_TrainingLocation(SMHR_TRAINING_LOCATION _obj_Smhr_Location)
        {
            bool status = false;
            switch (_obj_Smhr_Location.OPERATION)
            {
                case operation.Insert:
                    if (ExecuteNonQuery("EXEC USP_SMHR_TRAINING_LOCATION @Operation = 'Insert',@Location_Name='" + Convert.ToString(_obj_Smhr_Location.LocationName)
                                      + "', @Location_Organization='" + _obj_Smhr_Location.ORGANISATION_ID
                                      + "', @Location_StreetName='" + _obj_Smhr_Location.Location_StreetName
                                      + "', @Location_CountryID='" + _obj_Smhr_Location.Location_CountryID
                                      + "', @Location_CountyID='" + _obj_Smhr_Location.Location_CountyID
                                      + "', @Location_TownID='" + _obj_Smhr_Location.Location_TownID
                                      + "', @Location_ContactPerson='" + _obj_Smhr_Location.Location_ContactPerson
                                      + "', @Location_EmailID='" + _obj_Smhr_Location.Location_EmailID
                                      + "', @Location_ContactNo='" + _obj_Smhr_Location.Location_ContactNo
                                      + "', @Location_AlternateContactNo='" + _obj_Smhr_Location.Location_AlternateContactNo
                                      + "' ,@Location_Status='" + _obj_Smhr_Location.Location_Status
                                      + " ', @Location_CretedBy= '" + Convert.ToString(_obj_Smhr_Location.CREATEDBY)
                                      + "', @Location_CreatedDate='" + _obj_Smhr_Location.CREATEDDATE.ToString("MM/dd/yyyy")
                                      + "', @Location_ModifiedBy ='" + Convert.ToString(_obj_Smhr_Location.LASTMDFBY)
                                      + "', @Location_ModifiedDate ='" + _obj_Smhr_Location.LASTMDFDATE.ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case operation.Update:

                    if (ExecuteNonQuery("EXEC USP_SMHR_TRAINING_LOCATION @Operation = 'Update'"
                                      + ", @Location_ID=" + _obj_Smhr_Location.LocationID
                                      + ", @Location_StreetName='" + _obj_Smhr_Location.Location_StreetName
                                      + "', @Location_CountryID='" + _obj_Smhr_Location.Location_CountryID
                                      + "', @Location_CountyID='" + _obj_Smhr_Location.Location_CountyID
                                      + "', @Location_TownID='" + _obj_Smhr_Location.Location_TownID
                                      + "', @Location_ContactPerson='" + _obj_Smhr_Location.Location_ContactPerson
                                      + "', @Location_EmailID='" + _obj_Smhr_Location.Location_EmailID
                                      + "', @Location_ContactNo='" + _obj_Smhr_Location.Location_ContactNo
                                      + "', @Location_AlternateContactNo='" + _obj_Smhr_Location.Location_AlternateContactNo
                                      + "' ,@Location_Status=" + _obj_Smhr_Location.Location_Status
                                      + ", @Location_ModifiedBy ='" + Convert.ToString(_obj_Smhr_Location.LASTMDFBY)
                                      + "' , @Location_ModifiedDate ='" + _obj_Smhr_Location.LASTMDFDATE.ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;

                    break;

                default:
                    break;
            }
            return status;
        }

        public static DataTable get_TrainingLocation(SMHR_TRAINING_LOCATION _obj_Smhr_Location)
        {
            if (_obj_Smhr_Location.OPERATION == operation.Check)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAINING_LOCATION @OPERATION = 'Check',@Location_Organization='" + _obj_Smhr_Location.ORGANISATION_ID + "',@Location_Name='" + _obj_Smhr_Location.LocationName + "'");
            }
            else if (_obj_Smhr_Location.OPERATION == operation.Select)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAINING_LOCATION @OPERATION = 'Select',@Location_Organization='" + _obj_Smhr_Location.ORGANISATION_ID + "'");
            }
            else if (_obj_Smhr_Location.OPERATION == operation.Select2)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAINING_LOCATION @OPERATION='Select2',@Location_Organization='" + _obj_Smhr_Location.ORGANISATION_ID + "'");
            }
            else if (_obj_Smhr_Location.OPERATION == operation.Get)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAINING_LOCATION @OPERATION = 'Get',@Location_Organization='" + _obj_Smhr_Location.ORGANISATION_ID + "',@Location_ID='" + _obj_Smhr_Location.LocationID + "'");
            }
            else if (_obj_Smhr_Location.OPERATION == operation.Select1)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAINING_LOCATION @OPERATION = 'Select1',@Location_Organization='" + _obj_Smhr_Location.ORGANISATION_ID + "',@Location_ID='" + _obj_Smhr_Location.LocationID + "'");
            }
            else
                return null;
        }

        public static bool set_TrainingRooms(SMHR_TRAINING_ROOM _obj_Smhr_Room)
        {
            bool status = false;
            switch (_obj_Smhr_Room.OPERATION)
            {
                case operation.Insert:
                    if (ExecuteNonQuery("EXEC USP_SMHR_TRAINING_ROOMS @Operation = 'Insert',@ROOMS_NAME='" + Convert.ToString(_obj_Smhr_Room.ROOMNAME)
                                      + "', @ROOMS_STRENGTH='" + _obj_Smhr_Room.ROOMSTRENGTH
                                      + "', @ROOMS_LOCATIONID='" + _obj_Smhr_Room.ROOMS_LOCATION_ID
                                      + "', @ROOMS_ORGANIZATION='" + _obj_Smhr_Room.ORGANISATION_ID
                                      + "' ,@ROOMS_STATUS=" + _obj_Smhr_Room.ROOM_STATUS
                                      + " , @ROOMS_CRETEDBY= '" + Convert.ToString(_obj_Smhr_Room.CREATEDBY)
                                      + "', @ROOMS_CREATEDDATE='" + _obj_Smhr_Room.CREATEDDATE.ToString("MM/dd/yyyy")
                                      + "', @ROOMS_MODIFIEDBY ='" + Convert.ToString(_obj_Smhr_Room.LASTMDFBY)
                                      + "', @ROOMS_MODIFIEDDATE ='" + _obj_Smhr_Room.LASTMDFDATE.ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case operation.Update:

                    if (ExecuteNonQuery("EXEC USP_SMHR_TRAINING_ROOMS @Operation = 'Update'"
                                      + ", @ROOMS_ID=" + _obj_Smhr_Room.ROOMID
                                      + ", @ROOMS_STRENGTH='" + _obj_Smhr_Room.ROOMSTRENGTH
                                      + "', @ROOMS_LOCATIONID='" + _obj_Smhr_Room.ROOMS_LOCATION_ID
                                      + "', @ROOMS_STATUS=" + _obj_Smhr_Room.ROOM_STATUS
                                      + ", @ROOMS_MODIFIEDBY ='" + Convert.ToString(_obj_Smhr_Room.LASTMDFBY)
                                      + "' , @ROOMS_MODIFIEDDATE ='" + _obj_Smhr_Room.LASTMDFDATE.ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;

                    break;

                default:
                    break;
            }
            return status;
        }

        public static DataTable get_TrainingRooms(SMHR_TRAINING_ROOM _obj_Smhr_Room)
        {
            if (_obj_Smhr_Room.OPERATION == operation.Check)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAINING_ROOMS @OPERATION = 'Check',@ROOMS_ORGANIZATION='" + _obj_Smhr_Room.ORGANISATION_ID + "',@ROOMS_NAME='" + _obj_Smhr_Room.ROOMNAME + "'");
            }
            else if (_obj_Smhr_Room.OPERATION == operation.Select)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAINING_ROOMS @OPERATION = 'Select',@ROOMS_ORGANIZATION='" + _obj_Smhr_Room.ORGANISATION_ID + "'");
            }
            else if (_obj_Smhr_Room.OPERATION == operation.Get)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAINING_ROOMS @OPERATION = 'Get',@ROOMS_ORGANIZATION='" + _obj_Smhr_Room.ORGANISATION_ID + "',@ROOMS_ID='" + _obj_Smhr_Room.ROOMID + "'");
            }
            else if (_obj_Smhr_Room.OPERATION == operation.Select1)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAINING_ROOMS @OPERATION = 'Select1',@ROOMS_ORGANIZATION='" + _obj_Smhr_Room.ORGANISATION_ID
                    + "',@ROOMS_ID='" + _obj_Smhr_Room.ROOMID
                    + "',@CourseSchedule_StartDate='" + _obj_Smhr_Room.SMHR_COURSESCHEDULE.COURSESCHEDULE_STARTDATE
                    + "',@CourseSchedule_SatartTime='" + _obj_Smhr_Room.SMHR_COURSESCHEDULE.COURSESCHEDULE_SATARTTIME
                    + "'");
            }
            else if (_obj_Smhr_Room.OPERATION == operation.Select2)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAINING_ROOMS @OPERATION = 'Select2',@ROOMS_ORGANIZATION='" + _obj_Smhr_Room.ORGANISATION_ID + "',@ROOMS_LOCATIONID='" + _obj_Smhr_Room.ROOMS_LOCATION_ID + "'");
            }
            else
                return null;
        }
        public static bool set_TrainingProfile(SMHR_TRAINERPROFILE _obj_Smhr_Profile)
        {
            bool status = false;
            switch (_obj_Smhr_Profile.OPERATION)
            {
                case operation.Insert:
                    if (ExecuteNonQuery("EXEC USP_SMHR_TRAINERPROFILE @Operation = 'Insert',@Trainer_ServiceProvider ='" + _obj_Smhr_Profile.Trainer_ServiceProvider
                                         + "', @Trainer_FirstName='" + Convert.ToString(_obj_Smhr_Profile.Trainer_FirstName)
                                         + "', @Trainer_LastName='" + Convert.ToString(_obj_Smhr_Profile.Trainer_LastName)
                                         + "', @Trainer_MiddleName='" + Convert.ToString(_obj_Smhr_Profile.Trainer_MiddleName)
                                         + "' ,@Trainer_EmailID='" + _obj_Smhr_Profile.Trainer_EmailID
                                         + "' , @Trainer_DOB= '" + Convert.ToString(_obj_Smhr_Profile.Trainer_DOB.ToString("MM/dd/yyyy"))
                                         + "', @Trainer_Age='" + _obj_Smhr_Profile.Trainer_Age
                                         + "', @Trainer_LandlineNo ='" + Convert.ToString(_obj_Smhr_Profile.Trainer_LandlineNo)
                                         + "', @Trainer_Address1 ='" + Convert.ToString(_obj_Smhr_Profile.Trainer_Address1)
                                         + "',@Trainer_Address2 ='" + Convert.ToString(_obj_Smhr_Profile.Trainer_Address2)
                                         + "',@Trainer_CountryID ='" + _obj_Smhr_Profile.Trainer_CountryID
                                         + "',@Trainer_MoblieNo ='" + _obj_Smhr_Profile.Trainer_MoblieNo
                                         + "',@Trainer_TownID ='" + _obj_Smhr_Profile.Trainer_TownID
                                         + "',@Trainer_ZipCode ='" + Convert.ToString(_obj_Smhr_Profile.Trainer_ZipCode)
                                         + "',@Trainer_CourseCategory  ='" + _obj_Smhr_Profile.Trainer_CourseCategory
                                         + "',@Trainer_Status ='" + Convert.ToString(_obj_Smhr_Profile.Trainer_Status)
                                         + "',@Trainer_Qualification ='" + Convert.ToString(_obj_Smhr_Profile.Trainer_Qualification)
                                         + "',@Trainer_Institute ='" + Convert.ToString(_obj_Smhr_Profile.Trainer_Institute)
                                         + "',@Trainer_YearOfPass ='" + Convert.ToString(_obj_Smhr_Profile.Trainer_YearOfPass)
                                         + "',@Trainer_Percentage ='" + Convert.ToString(_obj_Smhr_Profile.Trainer_Percentage)
                                         + "', @TRAINER_MODIIFYEDDATE  = '" + _obj_Smhr_Profile.TRAINER_MODIIFYEDDATE.ToString("MM/dd/yyyy")
                                      + "', @TRAINER_CREATEDBY='" + Convert.ToString(_obj_Smhr_Profile.TRAINER_CREATEDBY)
                                      + "', @TRAINER_MODIFYEDBY =" + Convert.ToString(_obj_Smhr_Profile.TRAINER_MODIFYEDBY)
                                      + " , @TRAINER_CREATEDDATE ='" + _obj_Smhr_Profile.TRAINER_CREATEDDATE.ToString("MM/dd/yyyy")
                                      + "' , @TRAINER_ORGID='" + _obj_Smhr_Profile.TRAINER_ORGID
                                         + "',@Trainer_CountyID ='" + _obj_Smhr_Profile.Trainer_CountyID
                                         + "' "))


                        status = true;
                    else
                        status = false;
                    break;

                case operation.Update:
                    if (ExecuteNonQuery("EXEC USP_SMHR_TRAINERPROFILE @Operation = 'Update',@Trainer_TrainerProfile_ID=" + _obj_Smhr_Profile.Trainer_TrainerProfile_ID
                                      + ",@Trainer_ServiceProvider ='" + _obj_Smhr_Profile.Trainer_ServiceProvider
                                      + "', @Trainer_FirstName='" + Convert.ToString(_obj_Smhr_Profile.Trainer_FirstName)
                                      + "', @Trainer_LastName='" + Convert.ToString(_obj_Smhr_Profile.Trainer_LastName)
                                      + "', @Trainer_MiddleName='" + Convert.ToString(_obj_Smhr_Profile.Trainer_MiddleName)
                                      + "' ,@Trainer_EmailID='" + _obj_Smhr_Profile.Trainer_EmailID
                                      + "', @Trainer_DOB= '" + Convert.ToString(_obj_Smhr_Profile.Trainer_DOB)
                                      + "', @Trainer_Age='" + _obj_Smhr_Profile.Trainer_Age
                                      + "', @Trainer_LandlineNo ='" + Convert.ToString(_obj_Smhr_Profile.Trainer_LandlineNo)
                                      + "', @Trainer_Address1 ='" + Convert.ToString(_obj_Smhr_Profile.Trainer_Address1)
                                      + "',@Trainer_Address2 ='" + Convert.ToString(_obj_Smhr_Profile.Trainer_Address2)
                                      + "',@Trainer_CountryID ='" + _obj_Smhr_Profile.Trainer_CountryID
                                      + "',@Trainer_CountyID ='" + _obj_Smhr_Profile.Trainer_CountyID
                                      + "',@Trainer_MoblieNo ='" + _obj_Smhr_Profile.Trainer_MoblieNo
                                      + "',@Trainer_TownID ='" + _obj_Smhr_Profile.Trainer_TownID
                                      + "',@Trainer_ZipCode ='" + Convert.ToString(_obj_Smhr_Profile.Trainer_ZipCode)
                                      + "',@Trainer_CourseCategory  ='" + _obj_Smhr_Profile.Trainer_CourseCategory
                                      + "',@Trainer_Status ='" + Convert.ToString(_obj_Smhr_Profile.Trainer_Status)
                                      + "',@Trainer_Qualification ='" + Convert.ToString(_obj_Smhr_Profile.Trainer_Qualification)
                                      + "',@Trainer_Institute ='" + Convert.ToString(_obj_Smhr_Profile.Trainer_Institute)
                                      + "',@Trainer_YearOfPass ='" + Convert.ToString(_obj_Smhr_Profile.Trainer_YearOfPass)
                                      + "',@Trainer_Percentage ='" + Convert.ToString(_obj_Smhr_Profile.Trainer_Percentage)
                                      + "', @TRAINER_MODIIFYEDDATE  = '" + _obj_Smhr_Profile.TRAINER_MODIIFYEDDATE.ToString("MM/dd/yyyy")
                                      + "',  @TRAINER_MODIFYEDBY ='" + Convert.ToString(_obj_Smhr_Profile.TRAINER_MODIFYEDBY)
                                      + "'"))

                        status = true;
                    else
                        status = false;

                    break;



            }
            return status;
        }

        public static DataTable get_TrainingProfile(SMHR_TRAINERPROFILE _obj_Smhr_Profile)
        {
            if (_obj_Smhr_Profile.OPERATION == operation.Get)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAINERPROFILE @OPERATION = 'Get',@Trainer_TrainerProfile_ID='" + _obj_Smhr_Profile.Trainer_TrainerProfile_ID + "', @TRAINER_ORGID='" + _obj_Smhr_Profile.TRAINER_ORGID
                                         + "'");
            }
            else if (_obj_Smhr_Profile.OPERATION == operation.Select)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAINERPROFILE @OPERATION = 'Select', @TRAINER_ORGID='" + _obj_Smhr_Profile.TRAINER_ORGID
                                         + "' ");
            }
            else if (_obj_Smhr_Profile.OPERATION == operation.Select2)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAINERPROFILE @OPERATION = 'Select2', @TRAINER_ORGID='" + _obj_Smhr_Profile.TRAINER_ORGID
                                         + "',@Trainer_CourseCategory='" + _obj_Smhr_Profile.Trainer_CourseCategory
                                         + "' ");
            }
            else if (_obj_Smhr_Profile.OPERATION == operation.Select1)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAINERPROFILE @OPERATION = 'Select1', @TRAINER_ORGID='" + _obj_Smhr_Profile.TRAINER_ORGID
                                         + "' ,@Trainer_ServiceProvider ='" + _obj_Smhr_Profile.Trainer_ServiceProvider
                                      + "'");
            }
            else if (_obj_Smhr_Profile.OPERATION == operation.Scale)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAINERPROFILE @OPERATION = 'Scale', @TRAINER_ORGID='" + _obj_Smhr_Profile.TRAINER_ORGID
                                         + "' ,@Trainer_CourseCategory ='" + _obj_Smhr_Profile.Trainer_CourseCategory
                                      + "'");
            }
            else if (_obj_Smhr_Profile.OPERATION == operation.CountEmailID)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAINERPROFILE @OPERATION='CountEmailID',@Trainer_EmailID='" + _obj_Smhr_Profile.Trainer_EmailID + "',@TRAINER_ORGID='" + _obj_Smhr_Profile.TRAINER_ORGID + "'");
            }
            else
                return null;
        }

        public static bool set_CourseSchedule(SMHR_COURSESCHEDULE _obj_Smhr_CourseSchedule)
        {
            bool status = false;
            switch (_obj_Smhr_CourseSchedule.OPERATION)
            {
                case operation.Insert:
                    if (ExecuteNonQuery("EXEC USP_SMHR_CourseSchedule @Operation = 'Insert',@CourseSchedule_Name='" + Convert.ToString(_obj_Smhr_CourseSchedule.COURSESCHEDULE_NAME)
                                      + "', @CourseSchedule_Organization='" + _obj_Smhr_CourseSchedule.ORGANISATION_ID
                                      + "', @CourseSchedule_CourseID='" + _obj_Smhr_CourseSchedule.COURSESCHEDULE_COURSEID
                                      + "', @CourseSchedule_CourseTypeID='" + _obj_Smhr_CourseSchedule.COURSESCHEDULE_COURSETYPEID
                                      + "', @CourseSchedule_LocationID='" + _obj_Smhr_CourseSchedule.COURSESCHEDULE_LOCATIONID
                                      + "', @CourseSchedule_RoomID='" + _obj_Smhr_CourseSchedule.COURSESCHEDULE_ROOMID
                                      + "', @CourseSchedule_NoOfSessions='" + _obj_Smhr_CourseSchedule.COURSESCHEDULE_NOOFSESSIONS
                                      + "', @CourseSchedule_NoOfSeats='" + _obj_Smhr_CourseSchedule.COURSESCHEDULE_NOOFSEATS
                                      + "', @CourseSchedule_StartDate='" + _obj_Smhr_CourseSchedule.COURSESCHEDULE_STARTDATE.ToString("MM/dd/yyyy")
                                      + "', @CourseSchedule_SatartTime='" + _obj_Smhr_CourseSchedule.COURSESCHEDULE_SATARTTIME
                                      + "', @CourseSchedule_EndDate='" + _obj_Smhr_CourseSchedule.COURSESCHEDULE_ENDDATE.ToString("MM/dd/yyyy")
                                      + "', @CourseSchedule_EndTime='" + _obj_Smhr_CourseSchedule.COURSESCHEDULE_ENDTIME
                                      + "', @CourseSchedule_TrainerID='" + _obj_Smhr_CourseSchedule.COURSESCHEDULE_TRAINERID
                                      + "' ,@CourseSchedule_Status=" + _obj_Smhr_CourseSchedule.COURSESCHEDULE_STATUS
                                      + " , @CourseSchedule_CretedBy= '" + Convert.ToString(_obj_Smhr_CourseSchedule.CREATEDBY)
                                      + "', @CourseSchedule_CreatedDate='" + _obj_Smhr_CourseSchedule.CREATEDDATE.ToString("MM/dd/yyyy")
                                      + "', @CourseSchedule_ModifiedBy =" + Convert.ToString(_obj_Smhr_CourseSchedule.LASTMDFBY)
                                      + " , @CourseSchedule_ModifiedDate ='" + _obj_Smhr_CourseSchedule.LASTMDFDATE.ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case operation.Update:

                    if (ExecuteNonQuery("EXEC USP_SMHR_CourseSchedule @Operation = 'Update'"
                                      + ", @CourseSchedule_ID='" + _obj_Smhr_CourseSchedule.COURSESCHEDULEID
                                      + "', @CourseSchedule_CourseID='" + _obj_Smhr_CourseSchedule.COURSESCHEDULE_COURSEID
                                      + "', @CourseSchedule_CourseTypeID='" + _obj_Smhr_CourseSchedule.COURSESCHEDULE_COURSETYPEID
                                      + "', @CourseSchedule_LocationID='" + _obj_Smhr_CourseSchedule.COURSESCHEDULE_LOCATIONID
                                      + "', @CourseSchedule_RoomID='" + _obj_Smhr_CourseSchedule.COURSESCHEDULE_ROOMID
                                      + "', @CourseSchedule_NoOfSessions='" + _obj_Smhr_CourseSchedule.COURSESCHEDULE_NOOFSESSIONS
                                      + "', @CourseSchedule_NoOfSeats='" + _obj_Smhr_CourseSchedule.COURSESCHEDULE_NOOFSEATS
                                      + "', @CourseSchedule_StartDate='" + _obj_Smhr_CourseSchedule.COURSESCHEDULE_STARTDATE.ToString("MM/dd/yyyy")
                                      + "', @CourseSchedule_SatartTime='" + _obj_Smhr_CourseSchedule.COURSESCHEDULE_SATARTTIME
                                      + "', @CourseSchedule_EndDate='" + _obj_Smhr_CourseSchedule.COURSESCHEDULE_ENDDATE.ToString("MM/dd/yyyy")
                                      + "', @CourseSchedule_EndTime='" + _obj_Smhr_CourseSchedule.COURSESCHEDULE_ENDTIME
                                      + "', @CourseSchedule_TrainerID='" + _obj_Smhr_CourseSchedule.COURSESCHEDULE_TRAINERID
                                      + "' ,@CourseSchedule_Status=" + _obj_Smhr_CourseSchedule.COURSESCHEDULE_STATUS
                                      + ", @CourseSchedule_ModifiedBy ='" + Convert.ToString(_obj_Smhr_CourseSchedule.LASTMDFBY)
                                      + "' , @CourseSchedule_ModifiedDate ='" + _obj_Smhr_CourseSchedule.LASTMDFDATE.ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;

                    break;

                default:
                    break;
            }
            return status;
        }

        public static DataTable get_CourseSchedule(SMHR_COURSESCHEDULE _obj_Smhr_CourseSchedule)
        {
            if (_obj_Smhr_CourseSchedule.OPERATION == operation.Check)
            {
                return ExecuteQuery("EXEC USP_SMHR_CourseSchedule @OPERATION = 'Check',@CourseSchedule_Organization='" + _obj_Smhr_CourseSchedule.ORGANISATION_ID + "',@CourseSchedule_Name='" + _obj_Smhr_CourseSchedule.COURSESCHEDULE_NAME + "'");
            }
            if (_obj_Smhr_CourseSchedule.OPERATION == operation.MODE)
            {
                return ExecuteQuery("EXEC USP_SMHR_CourseSchedule @OPERATION = 'MODE', @CourseSchedule_ID='" + _obj_Smhr_CourseSchedule.COURSESCHEDULEID
                                      + "'");
            }
            else if (_obj_Smhr_CourseSchedule.OPERATION == operation.Select)
            {
                return ExecuteQuery("EXEC USP_SMHR_CourseSchedule @OPERATION = 'Select',@CourseSchedule_Organization='" + _obj_Smhr_CourseSchedule.ORGANISATION_ID + "'");
            }
            else if (_obj_Smhr_CourseSchedule.OPERATION == operation.Select2)
            {
                return ExecuteQuery("EXEC USP_SMHR_CourseSchedule @OPERATION = 'Select2',@CourseSchedule_Organization='" + _obj_Smhr_CourseSchedule.ORGANISATION_ID + "',@CourseSchedule_CourseID='" + _obj_Smhr_CourseSchedule.COURSESCHEDULE_COURSEID + "',@CourseSchedule_RaisedBy='" + _obj_Smhr_CourseSchedule.CREATEDBY + "'");
            }
            else if (_obj_Smhr_CourseSchedule.OPERATION == operation.Select3)
            {
                return ExecuteQuery("EXEC USP_SMHR_CourseSchedule @OPERATION = 'Select3',@CourseSchedule_Organization='" + _obj_Smhr_CourseSchedule.ORGANISATION_ID + "',@CourseSchedule_CourseID='" + _obj_Smhr_CourseSchedule.COURSESCHEDULE_COURSEID + "'");
            }
            else if (_obj_Smhr_CourseSchedule.OPERATION == operation.Course)
            {
                return ExecuteQuery("EXEC USP_SMHR_CourseSchedule @OPERATION = 'Course',@CourseSchedule_Organization='" + _obj_Smhr_CourseSchedule.ORGANISATION_ID + "',@CourseSchedule_CourseID='" + _obj_Smhr_CourseSchedule.COURSESCHEDULE_COURSEID + "'");
            }

            else if (_obj_Smhr_CourseSchedule.OPERATION == operation.Get)
            {
                return ExecuteQuery("EXEC USP_SMHR_CourseSchedule @OPERATION = 'Get',@CourseSchedule_Organization='" + _obj_Smhr_CourseSchedule.ORGANISATION_ID + "',@CourseSchedule_ID='" + _obj_Smhr_CourseSchedule.COURSESCHEDULEID + "'");
            }
            else if (_obj_Smhr_CourseSchedule.OPERATION == operation.Select4)
            {
                return ExecuteQuery("EXEC USP_SMHR_CourseSchedule @OPERATION = 'Select4',@CourseSchedule_ID='" + _obj_Smhr_CourseSchedule.COURSESCHEDULEID + "'");
            }
            else if (_obj_Smhr_CourseSchedule.OPERATION == operation.Offline)
            {
                return ExecuteQuery("EXEC USP_SMHR_CourseSchedule @OPERATION = 'Offline',@CourseSchedule_Organization='" + _obj_Smhr_CourseSchedule.ORGANISATION_ID + "', @CourseSchedule_TrainerID='" + _obj_Smhr_CourseSchedule.COURSESCHEDULE_TRAINERID
                                      + "'");
            }
            else if (_obj_Smhr_CourseSchedule.OPERATION == operation.Online)
            {
                return ExecuteQuery("EXEC USP_SMHR_CourseSchedule @OPERATION = 'Online',@CourseSchedule_Organization='" + _obj_Smhr_CourseSchedule.ORGANISATION_ID + "', @CourseSchedule_CourseID='" + _obj_Smhr_CourseSchedule.COURSESCHEDULE_COURSEID
                                      + "' ");
            }
            else if (_obj_Smhr_CourseSchedule.OPERATION == operation.Scale)
            {
                return ExecuteQuery("EXEC USP_SMHR_CourseSchedule @OPERATION = 'Scale',@CourseSchedule_Organization='" + _obj_Smhr_CourseSchedule.ORGANISATION_ID + "',@CourseSchedule_LocationID='" + _obj_Smhr_CourseSchedule.COURSESCHEDULE_LOCATIONID
                                      + "' ");
            }
            else if (_obj_Smhr_CourseSchedule.OPERATION == operation.Chk)
            {
                return ExecuteQuery("EXEC USP_SMHR_CourseSchedule @OPERATION = 'Chk',@CourseSchedule_Organization='" + _obj_Smhr_CourseSchedule.ORGANISATION_ID + "',@CourseSchedule_RoomID='" + _obj_Smhr_CourseSchedule.COURSESCHEDULE_ROOMID
                                      + "'");
            }
            else if (_obj_Smhr_CourseSchedule.OPERATION == operation.Course2)
            {
                return ExecuteQuery("EXEC USP_SMHR_CourseSchedule @OPERATION = 'Course2',@CourseSchedule_Organization ='" + _obj_Smhr_CourseSchedule.ORGANISATION_ID + "',@CourseSchedule_CourseID='" + _obj_Smhr_CourseSchedule.COURSESCHEDULE_COURSEID + "'");
            }
            else if (_obj_Smhr_CourseSchedule.OPERATION == operation.Course3)
            {
                return ExecuteQuery("EXEC USP_SMHR_CourseSchedule @OPERATION = 'Course3',@CourseSchedule_Organization ='" + _obj_Smhr_CourseSchedule.ORGANISATION_ID + "',@CourseSchedule_CourseID='" + _obj_Smhr_CourseSchedule.COURSESCHEDULE_COURSEID + "'");
            }
            else
                return null;
        }

        public static bool Set_Allowance_New(SMHR_ALLOWANCE _obj_smhr_allowance)
        {
            bool status = false;

            try
            {
                if (_obj_smhr_allowance.OPERATION == operation.Insert1)
                {
                    if (BLL.ExecuteNonQuery("EXEC USP_SMHR_ALLOWANCE @OPERATION = '" + _obj_smhr_allowance.OPERATION + "'" +
                                                    ", @ALLOWANCE_PAYITEM_ID = " + _obj_smhr_allowance.COMMITTEE_ID +
                                                    ", @ALLOWANCE_ORG_ID = " + _obj_smhr_allowance.ORGANISATION_ID +
                                                    ", @ALLOWANCE_PERIOD_ID = " + _obj_smhr_allowance.ALLOWANCE_PERIOD_ID +
                                                    ", @ALLOWANCE_EMPLOYEEGRADE_ID = " + _obj_smhr_allowance.ALLOWANCE_EMPLOYEEGRADE_ID +
                                                    ", @ALLOWANCE_CONFG_ID = " + _obj_smhr_allowance.ALLOWANCE_CONFG_ID +
                                                    ", @ALLOWANCE_DEPENDENT = " + _obj_smhr_allowance.ALLOWANCE_DEPENDENT +
                                                    ", @ALLOWANCE_ELIGIBLE = " + _obj_smhr_allowance.ALLOWANCE_ELIGIBLE +
                                                    ", @ALLOWANCE_CREATEDBY = " + _obj_smhr_allowance.CREATEDBY +
                                                    ", @ALLOWANCE_LASTMDFBY = " + _obj_smhr_allowance.LASTMDFBY))
                        status = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return status;
        }

        public static bool set_Chapter(SMHR_CHAPTERS _obj_Smhr_Chapter)
        {
            bool status = false;
            switch (_obj_Smhr_Chapter.OPERATION)
            {
                case operation.Insert:
                    if (ExecuteNonQuery("EXEC USP_SMHR_Chapters @Operation = 'Insert',@CHAPTER_NAME ='" + Convert.ToString(_obj_Smhr_Chapter.CHAPTER_NAME)
                                      + "', @CHARPTER_ORGANISATION_ID ='" + _obj_Smhr_Chapter.CHARPTER_ORGANISATION_ID
                                      + "', @CHAPTER_COURSE_ID='" + _obj_Smhr_Chapter.CHAPTER_COURSE_ID
                                      + "' , @CHAPTER_DESCRIPTION= '" + Convert.ToString(_obj_Smhr_Chapter.CHAPTER_DESCRIPTION)
                                      + "', @CHAPTER_STATUS ='" + Convert.ToString(_obj_Smhr_Chapter.CHAPTER_STATUS)
                                     + " ', @CHAPTER_LASTMDFDATE = '" + Convert.ToString(_obj_Smhr_Chapter.CHAPTER_LASTMDFDATE)
                                      + "', @CHAPTER_CREATEDBY='" + Convert.ToString(_obj_Smhr_Chapter.CHAPTER_CREATEDBY)
                                      + "', @CHAPTER_LASTMDFDBY =" + Convert.ToString(_obj_Smhr_Chapter.CHAPTER_LASTMDFDBY)
                                      + " , @CHAPTER_CREATEDDATE ='" + _obj_Smhr_Chapter.CHAPTER_CREATEDDATE.ToString("MM/dd/yyyy") + "'"))


                        status = true;
                    else
                        status = false;
                    break;
                case operation.Update:

                    if (ExecuteNonQuery("EXEC USP_SMHR_Chapters @Operation = 'update',@CHAPTER_ID='" + _obj_Smhr_Chapter.CHAPTER_ID + "',@CHAPTER_NAME ='" + Convert.ToString(_obj_Smhr_Chapter.CHAPTER_NAME)
                                      + "', @CHARPTER_ORGANISATION_ID ='" + _obj_Smhr_Chapter.CHARPTER_ORGANISATION_ID
                                      + "', @CHAPTER_COURSE_ID='" + _obj_Smhr_Chapter.CHAPTER_COURSE_ID
                                      + "' , @CHAPTER_DESCRIPTION= '" + Convert.ToString(_obj_Smhr_Chapter.CHAPTER_DESCRIPTION)
                                      + "', @CHAPTER_STATUS ='" + Convert.ToString(_obj_Smhr_Chapter.CHAPTER_STATUS)
                                    + "', @CHAPTER_LASTMDFDBY =" + Convert.ToString(_obj_Smhr_Chapter.CHAPTER_LASTMDFDBY)
                         + " , @CHAPTER_LASTMDFDATE = '" + Convert.ToString(_obj_Smhr_Chapter.CHAPTER_LASTMDFDATE) + "'"))
                        status = true;
                    else
                        status = false;

                    break;

                default:
                    break;
            }
            return status;
        }


        public static DataTable get_Chapter(SMHR_CHAPTERS _obj_Smhr_Chapter)
        {
            if (_obj_Smhr_Chapter.OPERATION == operation.Get)
            {
                return ExecuteQuery("EXEC USP_SMHR_Chapters @OPERATION = 'Get',@CHAPTER_ID='" + _obj_Smhr_Chapter.CHAPTER_ID + "', @CHARPTER_ORGANISATION_ID ='" + _obj_Smhr_Chapter.CHARPTER_ORGANISATION_ID + "'");
            }
            else if (_obj_Smhr_Chapter.OPERATION == operation.Select)
            {
                return ExecuteQuery("EXEC USP_SMHR_Chapters @OPERATION = 'Select', @CHARPTER_ORGANISATION_ID ='" + _obj_Smhr_Chapter.CHARPTER_ORGANISATION_ID + "'");
            }
            else if (_obj_Smhr_Chapter.OPERATION == operation.Check)
            {
                return ExecuteQuery("EXEC USP_SMHR_Chapters @OPERATION = 'Check',@CHAPTER_NAME ='" + Convert.ToString(_obj_Smhr_Chapter.CHAPTER_NAME) + "', @CHARPTER_ORGANISATION_ID ='" + _obj_Smhr_Chapter.CHARPTER_ORGANISATION_ID + "' ");
            }
            else if (_obj_Smhr_Chapter.OPERATION == operation.Select1)
            {
                return ExecuteQuery("EXEC USP_SMHR_Chapters @OPERATION = 'Select1',@CHAPTER_COURSE_ID='" + Convert.ToString(_obj_Smhr_Chapter.CHAPTER_COURSE_ID) + "', @CHARPTER_ORGANISATION_ID ='" + _obj_Smhr_Chapter.CHARPTER_ORGANISATION_ID + "' ");
            }

            else
                return null;
        }

        public static bool set_TrainigRequest(SMHR_TRAINING_REQUST _obj_smhr_training_requst)
        {
            bool status = false;
            switch (_obj_smhr_training_requst.OPERATION)
            {
                case operation.Insert:
                    if (ExecuteNonQuery("EXEC USP_SMHR_TRAINING_REQUEST @Operation = 'Insert',@TRAINING_REQUEST_RAISEDBY='" + Convert.ToString(_obj_smhr_training_requst.TRAINING_RAISEDBY)
                                       + "', @TRAINING_REQUEST_BATCHID='" + _obj_smhr_training_requst.TRAINING_BATCHID
                                        + "', @TRAINING_REQUEST_ORG_ID='" + _obj_smhr_training_requst.ORGANISATION_ID
                                       + "', @TRAINING_REQUEST_CREATEDBY='" + Convert.ToString(_obj_smhr_training_requst.CREATEDBY)
                                       + "', @TRAINING_REQUEST_CREATEDDATE='" + _obj_smhr_training_requst.CREATEDDATE.ToString("MM/dd/yyyy")
                                       + "', @TRAINING_REQUEST_LASTMDFBY='" + _obj_smhr_training_requst.LASTMDFBY
                                       + "', @TRAINING_REQUEST_LASTMDFDATE='" + _obj_smhr_training_requst.LASTMDFDATE.ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case operation.Insert1:
                    if (ExecuteNonQuery("EXEC USP_SMHR_TRAINING_REQUEST @Operation = '" + _obj_smhr_training_requst.OPERATION
                                       + "', @TRAINING_REQUEST_RAISEDBY='" + Convert.ToString(_obj_smhr_training_requst.TRAINING_RAISEDBY)
                                       + "', @TRAINING_REQUEST_ISAPPROVED='" + _obj_smhr_training_requst.TRAINING_ISAPPROVED
                                       + "', @TRAINING_REQUEST_BATCHID='" + _obj_smhr_training_requst.TRAINING_BATCHID
                                       + "', @TRAINING_REQUEST_ORG_ID='" + _obj_smhr_training_requst.ORGANISATION_ID
                                       + "', @TRAINING_REQUEST_CREATEDBY='" + Convert.ToString(_obj_smhr_training_requst.CREATEDBY)
                                       + "', @TRAINING_REQUEST_CREATEDDATE='" + _obj_smhr_training_requst.CREATEDDATE.ToString("MM/dd/yyyy")
                                       + "', @TRAINING_REQUEST_LASTMDFBY='" + _obj_smhr_training_requst.LASTMDFBY
                                       + "', @TRAINING_REQUEST_LASTMDFDATE='" + _obj_smhr_training_requst.LASTMDFDATE.ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;
                    break;
                case operation.Update:

                    if (ExecuteNonQuery("EXEC USP_SMHR_TRAINING_REQUEST @Operation = 'update',@TRAINING_REQUEST_ISAPPROVED='" + _obj_smhr_training_requst.TRAINING_ISAPPROVED
                         + "', @TRAINING_REQUEST_APPROVEDBY='" + _obj_smhr_training_requst.TRAINING_APPROVEDBY
                        + "', @TRAINING_REQUEST_LASTMDFBY='" + _obj_smhr_training_requst.LASTMDFBY
                        + "', @TRAINING_REQUEST_ID='" + _obj_smhr_training_requst.TRAINING_REQUST_ID
                         + "', @TRAINING_REQUEST_LASTMDFDATE='" + _obj_smhr_training_requst.LASTMDFDATE.ToString("MM/dd/yyyy") + "'"))
                        status = true;
                    else
                        status = false;

                    break;

                default:
                    break;
            }
            return status;
        }

        public static DataTable get_TrainigRequest(SMHR_TRAINING_REQUST _obj_smhr_training_requst)
        {
            if (_obj_smhr_training_requst.OPERATION == operation.Get)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAINING_REQUEST @OPERATION = 'Get',@TRAINING_REQUEST_APPROVEDBY='" + _obj_smhr_training_requst.TRAINING_APPROVEDBY + "', @TRAINING_REQUEST_ORG_ID ='" + _obj_smhr_training_requst.ORGANISATION_ID + "',@CourseSchedule_CourseID='" + _obj_smhr_training_requst.TRAINING_COURSEID + "'");
            }
            else if (_obj_smhr_training_requst.OPERATION == operation.Select)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAINING_REQUEST @OPERATION = 'Select', @TRAINING_REQUEST_RAISEDBY ='" + _obj_smhr_training_requst.TRAINING_RAISEDBY + "', @TRAINING_REQUEST_ORG_ID ='" + _obj_smhr_training_requst.ORGANISATION_ID + "'");
            }
            else if (_obj_smhr_training_requst.OPERATION == operation.Check)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAINING_REQUEST @OPERATION = 'Check',@TRAINING_REQUEST_ID ='" + Convert.ToString(_obj_smhr_training_requst.TRAINING_REQUST_ID)
                    + "' ");
            }

            else if (_obj_smhr_training_requst.OPERATION == operation.Select2)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAINING_REQUEST @OPERATION = 'Select2', @TRAINING_REQUEST_ORG_ID ='" + _obj_smhr_training_requst.ORGANISATION_ID + "',@TRAINING_REQUEST_BATCHID='" + Convert.ToString(_obj_smhr_training_requst.TRAINING_BATCHID)
                    + "',@TRAINING_ATTENDANCE_DAYS='" + Convert.ToString(_obj_smhr_training_requst.TRAINING_ATTENDANCE_DAYS)
                    + "'");
            }

            else
                return null;
        }

        public static bool Set_TrainingAttendance(SMHR_TRAINING_ATTENDANCE _obj_smhr_training_Attendance)
        {

            bool status = false;
            switch (_obj_smhr_training_Attendance.OPERATION)
            {
                case operation.Insert:
                    if (ExecuteNonQuery("EXEC USP_SMHR_TRAINING_ATTENDANCEDETAILS @Operation = 'Insert', @TRAINING_ATTENDANCE_COURSESCHEDULE_ID='" + _obj_smhr_training_Attendance.TRAINING_ATTENDANCE_COURSESCHEDULE_ID
                                       + "', @TRAINING_ATTENDANCE_DAYS='" + _obj_smhr_training_Attendance.TRAINING_ATTENDANCE_DAYS
                                       + "', @TRAINING_ATTENDANCE_EMPLOYEE_ID='" + _obj_smhr_training_Attendance.TRAINING_ATTENDANCE_EMPLOYEE_ID
                                       + "', @TRAINING_ATTENDANCE_ORGANISATION_ID='" + _obj_smhr_training_Attendance.ORGANISATION_ID + "'"))
                        status = true;
                    else
                        status = false;
                    break;
            }
            return status;

        }



        public static bool set_QuestionBank(SMHR_TRAINING_QUESTIONBANK _obj_Smhr_QuestionBank)
        {
            bool status = false;
            switch (_obj_Smhr_QuestionBank.OPERATION)
            {
                case operation.Insert:
                    if (ExecuteNonQuery("EXEC USP_SMHR_TRAINING_QUESTIONBANK @Operation = 'Insert',@QuestionBank_ORGANISATION_ID  ='" + _obj_Smhr_QuestionBank.QuestionBank_ORGANISATION_ID
                                         + "',@QuestionBank_courseID ='" + _obj_Smhr_QuestionBank.QuestionBank_courseID
                                         + "', @QuestionBank_ChapterID  ='" + _obj_Smhr_QuestionBank.QuestionBank_ChapterID
                                         + "',@QuestionBank_answer  ='" + _obj_Smhr_QuestionBank.QuestionBank_answer
                                         + "',@QuestionBank_CREATEDBY ='" + _obj_Smhr_QuestionBank.QuestionBank_CREATEDBY
                                         + "',@QuestionBank_LASTMDFBY    ='" + _obj_Smhr_QuestionBank.QuestionBank_LASTMDFBY
                                         + "',@QuestionBank_Question  ='" + Convert.ToString(_obj_Smhr_QuestionBank.QuestionBank_Question)
                                         + "',@QuestionBank_option1  ='" + Convert.ToString(_obj_Smhr_QuestionBank.QuestionBank_option1)
                                         + "',@QuestionBank_option2  ='" + Convert.ToString(_obj_Smhr_QuestionBank.QuestionBank_option2)
                                         + "',@QuestionBank_option3   ='" + Convert.ToString(_obj_Smhr_QuestionBank.QuestionBank_option3)
                                         + "',@QuestionBank_option4='" + Convert.ToString(_obj_Smhr_QuestionBank.QuestionBank_option4)
                                         + "',@QuestionBank_status   ='" + _obj_Smhr_QuestionBank.QuestionBank_status
                                         + "', @QuestionBank_LASTMDFDATE     = '" + _obj_Smhr_QuestionBank.QuestionBank_LASTMDFDATE.ToString("MM/dd/yyyy")
                                      + "' , @QuestionBank_CREATEDDATE  ='" + _obj_Smhr_QuestionBank.QuestionBank_CREATEDDATE.ToString("MM/dd/yyyy")
                                      + "'  "))


                        status = true;
                    else
                        status = false;
                    break;
                case operation.Update:
                    if (ExecuteNonQuery("EXEC USP_SMHR_TRAINING_QUESTIONBANK @OPERATION = 'Update',@QuestionBank_option1  ='" + Convert.ToString(_obj_Smhr_QuestionBank.QuestionBank_option1)
                                         + "',@QuestionBank_option2  ='" + Convert.ToString(_obj_Smhr_QuestionBank.QuestionBank_option2)
                                         + "',@QuestionBank_option3   ='" + Convert.ToString(_obj_Smhr_QuestionBank.QuestionBank_option3)
                                         + "',@QuestionBank_option4='" + Convert.ToString(_obj_Smhr_QuestionBank.QuestionBank_option4)
                                         + "',@QuestionBank_ID ='" + _obj_Smhr_QuestionBank.QuestionBank_ID
                                         + "',@QuestionBank_answer  ='" + Convert.ToString(_obj_Smhr_QuestionBank.QuestionBank_answer)
                                         + "',@QuestionBank_status   ='" + _obj_Smhr_QuestionBank.QuestionBank_status
                                         + "'"))

                        status = true;
                    else
                        status = false;

                    break;







            }
            return status;
        }
        public static DataTable get_QuestionBank(SMHR_TRAINING_QUESTIONBANK _obj_Smhr_QuestionBank)
        {
            if (_obj_Smhr_QuestionBank.OPERATION == operation.Get)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAINING_QUESTIONBANK @OPERATION = 'Get',@QuestionBank_ORGANISATION_ID ='" + _obj_Smhr_QuestionBank.QuestionBank_ORGANISATION_ID + "',@QuestionBank_courseID ='" + _obj_Smhr_QuestionBank.QuestionBank_courseID
                                         + "', @QuestionBank_ChapterID  ='" + _obj_Smhr_QuestionBank.QuestionBank_ChapterID
                                         + "',@QuestionBank_Question  ='" + Convert.ToString(_obj_Smhr_QuestionBank.QuestionBank_Question)
                                         + "'");
            }
            else if (_obj_Smhr_QuestionBank.OPERATION == operation.Select)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAINING_QUESTIONBANK @OPERATION = 'Select',@QuestionBank_ORGANISATION_ID ='" + _obj_Smhr_QuestionBank.QuestionBank_ORGANISATION_ID + "'");
            }
            else if (_obj_Smhr_QuestionBank.OPERATION == operation.Check)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAINING_QUESTIONBANK @OPERATION = 'Check',@QuestionBank_ORGANISATION_ID ='" + _obj_Smhr_QuestionBank.QuestionBank_ORGANISATION_ID + "',@QuestionBank_ID ='" + _obj_Smhr_QuestionBank.QuestionBank_ID + "'");
            }
            else if (_obj_Smhr_QuestionBank.OPERATION == operation.Select2)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAINING_QUESTIONBANK @OPERATION = 'Select2',@QuestionBank_ORGANISATION_ID ='" + _obj_Smhr_QuestionBank.QuestionBank_ORGANISATION_ID + "',@QuestionBank_ChapterID  ='" + _obj_Smhr_QuestionBank.QuestionBank_ChapterID + "'");
            }
            else if (_obj_Smhr_QuestionBank.OPERATION == operation.Select3)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAINING_QUESTIONBANK @OPERATION = 'Select3',@TRAINING_ASSESSMENT_QUESTIONS ='" + _obj_Smhr_QuestionBank.QuestionBank_Question + "'");
            }
            else
                return null;
        }

        public static bool set_OfflineAssessment(SMHR_TRAINING_OFFLINEASSESSMENTS _obj_Smhr_OfflineAssessment)
        {
            bool status = false;
            switch (_obj_Smhr_OfflineAssessment.OPERATION)
            {
                case operation.Insert:
                    if (ExecuteNonQuery("EXEC USP_SMHR_TRAINING_OFFLINEASSESSMENTS @Operation = 'Insert',@OFFLINEASSESSMENT_COURSEID  ='" + _obj_Smhr_OfflineAssessment.OFFLINEASSESSMENT_COURSEID
                                         + "',@OFFLINEASSESSMENT_COURSESCHEDULEID ='" + _obj_Smhr_OfflineAssessment.OFFLINEASSESSMENT_COURSESCHEDULEID
                                         + "', @OFFLINEASSESSMENT_ORGID ='" + _obj_Smhr_OfflineAssessment.OFFLINEASSESSMENT_ORGID
                                         + "',@OFFLINEASSESSMENT_CREATEDBY='" + _obj_Smhr_OfflineAssessment.OFFLINEASSESSMENT_CREATEDBY
                                         + "',@OFFLINEASSESSMENT_MODYFIEDBY   ='" + _obj_Smhr_OfflineAssessment.OFFLINEASSESSMENT_MODYFIEDBY
                                         + "',@OFFLINEASSESSMENT_NAME ='" + _obj_Smhr_OfflineAssessment.OFFLINEASSESSMENT_NAME
                                         + "',@OFFLINEASSESSMENT_UPLOADEDDOC  ='" + Convert.ToString(_obj_Smhr_OfflineAssessment.OFFLINEASSESSMENT_UPLOADEDDOC)
                                         + "',@OFFLINEASSESSMENT_STATUS   ='" + _obj_Smhr_OfflineAssessment.OFFLINEASSESSMENT_STATUS
                                         + "', @OFFLINEASSESSMENT_MODYFIEDDATE    = '" + _obj_Smhr_OfflineAssessment.OFFLINEASSESSMENT_MODYFIEDDATE.ToString("MM/dd/yyyy")
                                      + "' , @OFFLINEASSESSMENT_CREATEDDATE  ='" + _obj_Smhr_OfflineAssessment.OFFLINEASSESSMENT_CREATEDDATE.ToString("MM/dd/yyyy")
                                      + "'  "))


                        status = true;
                    else
                        status = false;
                    break;
                case operation.Update:
                    if (ExecuteNonQuery("EXEC USP_SMHR_TRAINING_OFFLINEASSESSMENTS @OPERATION = 'Update',@OFFLINEASSESSMENT_ID ='" + _obj_Smhr_OfflineAssessment.OFFLINEASSESSMENT_ID
                                         + "',@OFFLINEASSESSMENT_UPLOADEDDOC ='" + Convert.ToString(_obj_Smhr_OfflineAssessment.OFFLINEASSESSMENT_UPLOADEDDOC)
                                         + "',@OFFLINEASSESSMENT_STATUS   ='" + _obj_Smhr_OfflineAssessment.OFFLINEASSESSMENT_STATUS
                                         + "'"))

                        status = true;
                    else
                        status = false;

                    break;







            }
            return status;
        }
        public static DataTable get_OfflineAssessment(SMHR_TRAINING_OFFLINEASSESSMENTS _obj_Smhr_OfflineAssessment)
        {
            if (_obj_Smhr_OfflineAssessment.OPERATION == operation.Get)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAINING_OFFLINEASSESSMENTS @OPERATION = 'Get',@OFFLINEASSESSMENT_ORGID ='" + _obj_Smhr_OfflineAssessment.OFFLINEASSESSMENT_ORGID
                    + "',@OFFLINEASSESSMENT_ID ='" + _obj_Smhr_OfflineAssessment.OFFLINEASSESSMENT_ID
                                         + "'");
            }
            else if (_obj_Smhr_OfflineAssessment.OPERATION == operation.Select)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAINING_OFFLINEASSESSMENTS @OPERATION = 'Select',@OFFLINEASSESSMENT_ORGID ='" + _obj_Smhr_OfflineAssessment.OFFLINEASSESSMENT_ORGID + "'");
            }
            else if (_obj_Smhr_OfflineAssessment.OPERATION == operation.Select2)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAINING_OFFLINEASSESSMENTS @OPERATION = 'Select2',@OFFLINEASSESSMENT_ORGID ='" + _obj_Smhr_OfflineAssessment.OFFLINEASSESSMENT_ORGID + "',@OFFLINE_EMPID='" + _obj_Smhr_OfflineAssessment.OFFLINEASSESSMENT_ID + "',@OFFLINEASSESSMENT_COURSEID='" + _obj_Smhr_OfflineAssessment.OFFLINEASSESSMENT_COURSEID + "',@OFFLINEASSESSMENT_COURSESCHEDULEID='" + _obj_Smhr_OfflineAssessment.OFFLINEASSESSMENT_COURSESCHEDULEID + "'");
            }
            else if (_obj_Smhr_OfflineAssessment.OPERATION == operation.Check)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAINING_OFFLINEASSESSMENTS @OPERATION = 'Check',@OFFLINEASSESSMENT_ORGID ='" + _obj_Smhr_OfflineAssessment.OFFLINEASSESSMENT_ORGID
                    + "',@OFFLINEASSESSMENT_COURSESCHEDULEID ='" + _obj_Smhr_OfflineAssessment.OFFLINEASSESSMENT_COURSESCHEDULEID
                                         + "', @OFFLINEASSESSMENT_COURSEID  ='" + _obj_Smhr_OfflineAssessment.OFFLINEASSESSMENT_COURSEID
                                         + "',@OFFLINEASSESSMENT_NAME  ='" + Convert.ToString(_obj_Smhr_OfflineAssessment.OFFLINEASSESSMENT_NAME)
                                         + "'");
            }

            else
                return null;
        }

        public static bool set_OnlineAssessment(SMHR_TRAINING_ONLINEASSESSMENT _Obj_Smhr_OnlineAssessment)
        {
            bool status = false;
            switch (_Obj_Smhr_OnlineAssessment.OPERATION)
            {
                case operation.Insert:
                    if (ExecuteNonQuery("EXEC USP_SMHR_TRAINING_ONLINEASSESSMENT @Operation = 'Insert',@TRAINING_ASSESSMENT_NAME  ='" + _Obj_Smhr_OnlineAssessment.TRAINING_ASSESSMENT_NAME
                                         + "',@TRAINING_ASSESSMENT_COURSECATEGORY_ID ='" + _Obj_Smhr_OnlineAssessment.TRAINING_ASSESSMENT_COURSECATEGORY_ID
                                         + "', @TRAINING_ASSESSMENT_COURSE_ID ='" + _Obj_Smhr_OnlineAssessment.TRAINING_ASSESSMENT_COURSE_ID
                                         + "',@TRAINING_ASSESSMENT_COURSESCHEDULE_ID='" + _Obj_Smhr_OnlineAssessment.TRAINING_ASSESSMENT_COURSESCHEDULE_ID
                                         + "',@TRAINING_ASSESSMENT_DESC='" + _Obj_Smhr_OnlineAssessment.TRAINING_ASSESSMENT_DESC
                                         + "',@TRAINING_ASSESSMENT_NOOFQUESTIONS='" + _Obj_Smhr_OnlineAssessment.TRAINING_ASSESSMENT_NOOFQUESTIONS
                                         + "',@TRAINING_ASSESSMENT_MINMARKS='" + _Obj_Smhr_OnlineAssessment.TRAINING_ASSESSMENT_MINMARKS
                                         + "',@TRAINING_ASSESSMENT_TIME='" + _Obj_Smhr_OnlineAssessment.TRAINING_ASSESSMENT_TIME
                                         + "',@TRAINING_ASSESSMENT_QUESTIONS='" + _Obj_Smhr_OnlineAssessment.TRAINING_ASSESSMENT_QUESTIONS
                                         + "',@TRAINING_ASSESSMENT_STARTDATE='" + _Obj_Smhr_OnlineAssessment.TRAINING_ASSESSMENT_STARTDATE
                                         + "',@TRAINING_ASSESSMENT_ENDDATE='" + _Obj_Smhr_OnlineAssessment.TRAINING_ASSESSMENT_ENDDATE
                                         + "',@TRAINING_ASSESSMENT_STARTTIME='" + _Obj_Smhr_OnlineAssessment.TRAINING_ASSESSMENT_STARTTIME
                                         + "',@TRAINING_ASSESSMENT_ENDTIME='" + _Obj_Smhr_OnlineAssessment.TRAINING_ASSESSMENT_ENDTIME
                                         + "',@TRAINING_ASSESSMENT_CHAPTER_ID='" + _Obj_Smhr_OnlineAssessment.TRAINING_ASSESSMENT_CHAPTER_ID
                                         + "',@TRAINING_ASSESSMENT_ORG_ID='" + _Obj_Smhr_OnlineAssessment.ORGANISATION_ID
                                         + "',@TRAINING_ASSESSMENT_MODYFIEDBY   ='" + _Obj_Smhr_OnlineAssessment.LASTMDFBY
                                         + "', @TRAINING_ASSESSMENT_MODYFIEDDATE    = '" + _Obj_Smhr_OnlineAssessment.LASTMDFDATE.ToString("MM/dd/yyyy")
                                      + "' , @TRAINING_ASSESSMENT_CREATEDDATE  ='" + _Obj_Smhr_OnlineAssessment.CREATEDDATE.ToString("MM/dd/yyyy")
                                      + "' , @TRAINING_ASSESSMENT_CREATEDBY  ='" + _Obj_Smhr_OnlineAssessment.CREATEDBY
                                      + "'  "))


                        status = true;
                    else
                        status = false;
                    break;
                case operation.Update:
                    if (ExecuteNonQuery("EXEC USP_SMHR_TRAINING_ONLINEASSESSMENT @Operation = 'Update',@TRAINING_ASSESSMENT_NOOFQUESTIONS='" + _Obj_Smhr_OnlineAssessment.TRAINING_ASSESSMENT_NOOFQUESTIONS
                                         + "',@TRAINING_ASSESSMENT_MINMARKS='" + _Obj_Smhr_OnlineAssessment.TRAINING_ASSESSMENT_MINMARKS
                                         + "',@TRAINING_ASSESSMENT_TIME='" + _Obj_Smhr_OnlineAssessment.TRAINING_ASSESSMENT_TIME
                                         + "',@TRAINING_ASSESSMENT_DESC='" + _Obj_Smhr_OnlineAssessment.TRAINING_ASSESSMENT_DESC
                                         + "',@TRAINING_ASSESSMENT_QUESTIONS='" + _Obj_Smhr_OnlineAssessment.TRAINING_ASSESSMENT_QUESTIONS
                                         + "',@TRAINING_ASSESSMENT_STARTDATE='" + _Obj_Smhr_OnlineAssessment.TRAINING_ASSESSMENT_STARTDATE
                                         + "',@TRAINING_ASSESSMENT_ENDDATE='" + _Obj_Smhr_OnlineAssessment.TRAINING_ASSESSMENT_ENDDATE
                                         + "',@TRAINING_ASSESSMENT_STARTTIME='" + _Obj_Smhr_OnlineAssessment.TRAINING_ASSESSMENT_STARTTIME
                                         + "',@TRAINING_ASSESSMENT_ENDTIME='" + _Obj_Smhr_OnlineAssessment.TRAINING_ASSESSMENT_ENDTIME
                                         + "',@TRAINING_ASSESSMENT_CHAPTER_ID='" + _Obj_Smhr_OnlineAssessment.TRAINING_ASSESSMENT_CHAPTER_ID
                                         + "',@TRAINING_ASSESSMENT_MODYFIEDBY   ='" + _Obj_Smhr_OnlineAssessment.LASTMDFBY
                                         + "', @TRAINING_ASSESSMENT_MODYFIEDDATE    = '" + _Obj_Smhr_OnlineAssessment.LASTMDFDATE.ToString("MM/dd/yyyy")
                                         + "',@TRAINING_ASSESSMENT_ID ='" + _Obj_Smhr_OnlineAssessment.TRAINING_ASSESSMENT_ID
                                      + "'  "))
                        status = true;
                    else
                        status = false;

                    break;







            }
            return status;
        }

        public static DataTable get_OnlineAssessment(SMHR_TRAINING_ONLINEASSESSMENT _obj_Smhr_OnlineAssessment)
        {
            if (_obj_Smhr_OnlineAssessment.OPERATION == operation.Get)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAINING_ONLINEASSESSMENT @OPERATION = 'Get',@TRAINING_ASSESSMENT_ID ='" + _obj_Smhr_OnlineAssessment.TRAINING_ASSESSMENT_ID
                                         + "'");
            }
            else if (_obj_Smhr_OnlineAssessment.OPERATION == operation.Select)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAINING_ONLINEASSESSMENT @OPERATION = 'Select',@TRAINING_ASSESSMENT_ORG_ID ='" + _obj_Smhr_OnlineAssessment.ORGANISATION_ID + "'");
            }
            else if (_obj_Smhr_OnlineAssessment.OPERATION == operation.Select2)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAINING_ONLINEASSESSMENT @OPERATION = 'Select2',@TRAINING_ASSESSMENT_ORG_ID ='" + _obj_Smhr_OnlineAssessment.ORGANISATION_ID + "',@TRAINING_ASSESSMENT_COURSE_ID='" + _obj_Smhr_OnlineAssessment.TRAINING_ASSESSMENT_COURSE_ID + "',@TRAINING_ASSESSMENT_COURSESCHEDULE_ID='"
                    + _obj_Smhr_OnlineAssessment.TRAINING_ASSESSMENT_COURSESCHEDULE_ID + "',@ASSESSMENTRESULT_EMP_ID='" + _obj_Smhr_OnlineAssessment.TRAINING_ASSESSMENT_ID + "'");
            }
            else if (_obj_Smhr_OnlineAssessment.OPERATION == operation.Get_ID)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAINING_ONLINEASSESSMENT @OPERATION = 'Get_ID',@TRAINING_ASSESSMENT_ID ='" + _obj_Smhr_OnlineAssessment.TRAINING_ASSESSMENT_ID + "'");
            }
            else if (_obj_Smhr_OnlineAssessment.OPERATION == operation.Check)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAINING_ONLINEASSESSMENT @OPERATION = 'Check',@TRAINING_ASSESSMENT_ORG_ID ='" + _obj_Smhr_OnlineAssessment.ORGANISATION_ID
                                         + "',@TRAINING_ASSESSMENT_NAME  ='" + Convert.ToString(_obj_Smhr_OnlineAssessment.TRAINING_ASSESSMENT_NAME)
                                         + "'");
            }
            else if (_obj_Smhr_OnlineAssessment.OPERATION == operation.Select_New)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAINING_ONLINEASSESSMENT @OPERATION = 'Select_New',@TRAINING_ASSESSMENT_ID ='" + _obj_Smhr_OnlineAssessment.TRAINING_ASSESSMENT_ID + "',@TRAINING_ASSESSMENT_ORG_ID='" + _obj_Smhr_OnlineAssessment.ORGANISATION_ID + "'");
            }
            else if (_obj_Smhr_OnlineAssessment.OPERATION == operation.Check2)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAINING_ONLINEASSESSMENT @OPERATION = 'Check2',@TRAINING_ASSESSMENT_CHAPTER_ID='" + _obj_Smhr_OnlineAssessment.TRAINING_ASSESSMENT_CHAPTER_ID
                                         + "'");
            }

            else
                return null;
        }

        public static bool set_FeedBackQuestion(SMHR_TRAINING_FEEDBACKQUESTION _Obj_Smhr_FeedBackQuestion)
        {
            bool status = false;
            switch (_Obj_Smhr_FeedBackQuestion.OPERATION)
            {
                case operation.Insert:
                    if (ExecuteNonQuery("EXEC USP_SMHR_TRAINING_FEEDBACKQUESTION @Operation = 'Insert',@FEEDBACKQUESTION_QUESTION='" + Convert.ToString(_Obj_Smhr_FeedBackQuestion.FEEDBACKQUESTION_QUESTION)
                                         + "',@FEEDBACKQUESTION_TYPE='" + Convert.ToString(_Obj_Smhr_FeedBackQuestion.FEEDBACKQUESTION_TYPE)
                                         + "',@FEEDBACKQUESTION_QUESTION_DESC='" + Convert.ToString(_Obj_Smhr_FeedBackQuestion.FEEDBACKQUESTION_QUESTION_DESC)
                                         + "',@FEEDBACKQUESTION_STATUS='" + _Obj_Smhr_FeedBackQuestion.FEEDBACKQUESTION_STATUS
                                         + "',@FEEDBACKQUESTION_CREATEDBY='" + _Obj_Smhr_FeedBackQuestion.FEEDBACKQUESTION_CREATEDBY
                                         + "',@FEEDBACKQUESTION_ORGID ='" + _Obj_Smhr_FeedBackQuestion.FEEDBACKQUESTION_ORGID
                                         + "',@FEEDBACKQUESTION_LASTMDFBY   ='" + _Obj_Smhr_FeedBackQuestion.FEEDBACKQUESTION_LASTMDFBY
                                         + "', @FEEDBACKQUESTION_LASTMDFDATE = '" + _Obj_Smhr_FeedBackQuestion.FEEDBACKQUESTION_LASTMDFDATE.ToString("MM/dd/yyyy")
                                      + "' , @FEEDBACKQUESTION_CREATEDDATE  ='" + _Obj_Smhr_FeedBackQuestion.FEEDBACKQUESTION_CREATEDDATE.ToString("MM/dd/yyyy")
                                      + "'   "))


                        status = true;
                    else
                        status = false;
                    break;
                case operation.Update:
                    if (ExecuteNonQuery("EXEC USP_SMHR_TRAINING_FEEDBACKQUESTION @Operation = 'Update',@FEEDBACKQUESTION_QUESTION='" + Convert.ToString(_Obj_Smhr_FeedBackQuestion.FEEDBACKQUESTION_QUESTION)
                                         + "',@FEEDBACKQUESTION_QUESTION_DESC='" + Convert.ToString(_Obj_Smhr_FeedBackQuestion.FEEDBACKQUESTION_QUESTION_DESC)
                                         + "',@FEEDBACKQUESTION_LASTMDFBY   ='" + _Obj_Smhr_FeedBackQuestion.FEEDBACKQUESTION_LASTMDFBY
                                         + "', @FEEDBACKQUESTION_LASTMDFDATE = '" + _Obj_Smhr_FeedBackQuestion.FEEDBACKQUESTION_LASTMDFDATE.ToString("MM/dd/yyyy")
                                      + "' ,@FEEDBACKQUESTION_STATUS='" + _Obj_Smhr_FeedBackQuestion.FEEDBACKQUESTION_STATUS
                                         + "',@FEEDBACKQUESTION_ID ='" + _Obj_Smhr_FeedBackQuestion.FEEDBACKQUESTION_ID
                                              + "' "))


                        status = true;
                    else
                        status = false;
                    break;





            }
            return status;


        }


        public static DataTable get_FeedbackQuestion(SMHR_TRAINING_FEEDBACKQUESTION _Obj_Smhr_FeedBackQuestion)
        {
            if (_Obj_Smhr_FeedBackQuestion.OPERATION == operation.Get)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAINING_FEEDBACKQUESTION @OPERATION = 'Get',@FEEDBACKQUESTION_ID ='" + _Obj_Smhr_FeedBackQuestion.FEEDBACKQUESTION_ID
                    + "',@FEEDBACKQUESTION_ORGID ='" + _Obj_Smhr_FeedBackQuestion.FEEDBACKQUESTION_ORGID
                                         + "'");
            }
            else if (_Obj_Smhr_FeedBackQuestion.OPERATION == operation.Select)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAINING_FEEDBACKQUESTION @OPERATION = 'Select',@FEEDBACKQUESTION_ORGID ='" + _Obj_Smhr_FeedBackQuestion.FEEDBACKQUESTION_ORGID + "'");
            }
            else if (_Obj_Smhr_FeedBackQuestion.OPERATION == operation.Check)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAINING_FEEDBACKQUESTION @OPERATION = 'Check', @FEEDBACKQUESTION_ORGID  ='" + _Obj_Smhr_FeedBackQuestion.FEEDBACKQUESTION_ORGID
                                         + "',@FEEDBACKQUESTION_QUESTION  ='" + Convert.ToString(_Obj_Smhr_FeedBackQuestion.FEEDBACKQUESTION_QUESTION)
                                         + "',@FEEDBACKQUESTION_TYPE='" + Convert.ToString(_Obj_Smhr_FeedBackQuestion.FEEDBACKQUESTION_TYPE)
                                         + "'");
            }
            else if (_Obj_Smhr_FeedBackQuestion.OPERATION == operation.Select1)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAINING_FEEDBACKQUESTION @OPERATION = 'Select1',@FEEDBACKQUESTION_ORGID ='" + _Obj_Smhr_FeedBackQuestion.FEEDBACKQUESTION_ORGID
                    + "',@FEEDBACKQUESTION_TYPE='" + Convert.ToString(_Obj_Smhr_FeedBackQuestion.FEEDBACKQUESTION_TYPE)
                                         + "'");
            }
            else
                return null;
        }


        public static bool set_AssessmentResult(SMHR_ASSESSMENT_RESULT oSMHR_ASSESSMENT_RESULT)
        {
            bool status = false;
            switch (oSMHR_ASSESSMENT_RESULT.OPERATION)
            {
                case operation.Insert:
                    if (ExecuteNonQuery("EXEC USP_SMHR_ASSESSMENTRESULT @Operation = 'Insert',@ASSESSMENTRESULT_ASSESSMENTID='" + Convert.ToString(oSMHR_ASSESSMENT_RESULT.ASSESSMENTRESULT_ASSESSMENTID)
                                         + "',@ASSESSMENTRESULT_MARKS='" + Convert.ToString(oSMHR_ASSESSMENT_RESULT.ASSESSMENTRESULT_MARKS)
                                         + "',@ASSESSMENTRESULT_RESULT='" + Convert.ToString(oSMHR_ASSESSMENT_RESULT.ASSESSMENTRESULT_RESULT)
                                         + "',@ASSESSMENTRESULT_CREATEDDATE='" + oSMHR_ASSESSMENT_RESULT.CREATEDDATE.ToString("MM/dd/yyyy")
                                         + "',@ASSESSMENTRESULT_CREATEDBY='" + oSMHR_ASSESSMENT_RESULT.CREATEDBY
                                         + "',@ASSESSMENTRESULT_ORG_ID ='" + oSMHR_ASSESSMENT_RESULT.ORGANISATION_ID
                                         + "',@ASSESSMENTRESULT_DATE   ='" + oSMHR_ASSESSMENT_RESULT.ASSESSMENTRESULT_DATE.ToString("MM/dd/yyyy")
                                         + "', @ASSESSMENTRESULT_EMP_ID = '" + oSMHR_ASSESSMENT_RESULT.ASSESSMENTRESULT_EMP_ID
                                      + "'   "))


                        status = true;
                    else
                        status = false;
                    break;
                case operation.Update:
                    //if (ExecuteNonQuery("EXEC USP_SMHR_TRAINING_FEEDBACKQUESTION @Operation = 'Update',@FEEDBACKQUESTION_QUESTION='" + Convert.ToString(_Obj_Smhr_FeedBackQuestion.FEEDBACKQUESTION_QUESTION)
                    //                     + "',@FEEDBACKQUESTION_QUESTION_DESC='" + Convert.ToString(_Obj_Smhr_FeedBackQuestion.FEEDBACKQUESTION_QUESTION_DESC)
                    //                     + "',@FEEDBACKQUESTION_LASTMDFBY   ='" + _Obj_Smhr_FeedBackQuestion.FEEDBACKQUESTION_LASTMDFBY
                    //                     + "', @FEEDBACKQUESTION_LASTMDFDATE = '" + _Obj_Smhr_FeedBackQuestion.FEEDBACKQUESTION_LASTMDFDATE.ToString("MM/dd/yyyy")
                    //                  + "' ,@FEEDBACKQUESTION_ID ='" + _Obj_Smhr_FeedBackQuestion.FEEDBACKQUESTION_ID
                    //                          + "' "))


                    //    status = true;
                    //else
                    status = false;
                    break;





            }
            return status;

        }

        public static bool set_Rating(SMHR_FEEDBACK_RATING _obj_FEEDBACK_RATING)
        {
            bool status = false;
            switch (_obj_FEEDBACK_RATING.OPERATION)
            {
                case operation.Insert:
                    List<SqlParameter> lstSqlparams = new List<SqlParameter>();
                    lstSqlparams.Add(new SqlParameter("@Operation", "Insert"));
                    lstSqlparams.Add(new SqlParameter("@TAB", _obj_FEEDBACK_RATING.FEEDBACK_TABLE));
                    int result = ExecuteNonQuery("USP_SMHR_FEEDBACK_RATING", lstSqlparams.ToArray());
                    if (result > 0)
                        status = true;
                    else
                        status = false;
                    break;

            }
            return status;

        }

        public static bool set_LoanSetup(SMHR_LOANSETUP _obj_SMHR_LOANSETUP)
        {
            bool status = false;
            switch (_obj_SMHR_LOANSETUP.OPERATION)
            {
                case operation.Insert:
                    List<SqlParameter> lstSqlparams = new List<SqlParameter>();
                    lstSqlparams.Add(new SqlParameter("@Operation", "Insert"));
                    lstSqlparams.Add(new SqlParameter("@LOANSETUP_FINPERIODID", _obj_SMHR_LOANSETUP.LOANSETUP_FINPERIODID));
                    lstSqlparams.Add(new SqlParameter("@LOANSETUP_ORG_ID", _obj_SMHR_LOANSETUP.ORGANISATION_ID));
                    lstSqlparams.Add(new SqlParameter("@LOANSETUP_CREATEDBY", _obj_SMHR_LOANSETUP.CREATEDBY));
                    lstSqlparams.Add(new SqlParameter("@LOANSETUP_CREATEDDATE", _obj_SMHR_LOANSETUP.CREATEDDATE.ToString("MM/dd/yyyy")));
                    lstSqlparams.Add(new SqlParameter("@LOANSETUP_MODYFIEDBY", _obj_SMHR_LOANSETUP.LASTMDFBY));
                    lstSqlparams.Add(new SqlParameter("@LOANSETUP_MODYFIEDDATE", _obj_SMHR_LOANSETUP.LASTMDFDATE.ToString("MM/dd/yyyy")));
                    lstSqlparams.Add(new SqlParameter("@LOANSETUPDATA", _obj_SMHR_LOANSETUP.LOANSETUP_GRIDDATA));
                    int result = ExecuteNonQuery("USP_SMHR_LOANSETUP", lstSqlparams.ToArray());
                    if (result > 0)
                        status = true;
                    else
                        status = false;
                    break;

            }
            return status;

        }
        public static DataTable get_LoanSetup(SMHR_LOANSETUP _obj_SMHR_LOANSETUP)
        {
            if (_obj_SMHR_LOANSETUP.OPERATION == operation.Check)
            {
                return ExecuteQuery("EXEC USP_SMHR_LOANSETUP @OPERATION = 'Check',@LOANSETUP_ORG_ID='" + _obj_SMHR_LOANSETUP.ORGANISATION_ID
                    + "',@EMP_ID='" + _obj_SMHR_LOANSETUP.LOGIN_ID
                    + "',@LOANSETUP_LOANTYPE_ID='" + _obj_SMHR_LOANSETUP.LOANSETUP_LOANTYPE_ID
                    + "',@LOANTRANS_ID = " + _obj_SMHR_LOANSETUP.LOANTRANS_ID);
            }
            else if (_obj_SMHR_LOANSETUP.OPERATION == operation.Select)
            {
                return ExecuteQuery("EXEC USP_SMHR_LOANSETUP @OPERATION = 'Select',@LOANSETUP_ORG_ID='" + _obj_SMHR_LOANSETUP.ORGANISATION_ID
                    + "',@EMP_ID='" + _obj_SMHR_LOANSETUP.LOGIN_ID
                    + "',@LOANSETUP_LOANTYPE_ID='" + _obj_SMHR_LOANSETUP.LOANSETUP_LOANTYPE_ID
                    + "'");
            }
            else if (_obj_SMHR_LOANSETUP.OPERATION == operation.Select1)
            {
                return ExecuteQuery("EXEC USP_SMHR_LOANSETUP @OPERATION = 'Select1',@LOANSETUP_ORG_ID='" + _obj_SMHR_LOANSETUP.ORGANISATION_ID
                    + "',@EMP_ID='" + _obj_SMHR_LOANSETUP.LOGIN_ID
                    + "',@LOANSETUP_LOANTYPE_ID='" + _obj_SMHR_LOANSETUP.LOANSETUP_LOANTYPE_ID
                    + "'");
            }
            else if (_obj_SMHR_LOANSETUP.OPERATION == operation.Validate)
            {
                //USP_SMHR_GET_MINSALARY  @OPERATION='VALIDATE',@EMPID=2200,@AMOUNT=0,@PRDTLID ='',@ORGID=4,@EFFECTIVEDATE='2013-12-09'    
                return ExecuteQuery("EXEC USP_SMHR_GET_MINSALARY @OPERATION = 'VALIDATE',@ORGID='" + _obj_SMHR_LOANSETUP.ORGANISATION_ID
                    + "',@EMPID='" + _obj_SMHR_LOANSETUP.LOGIN_ID
                    + "',@AMOUNT='" + _obj_SMHR_LOANSETUP.Amount
                    + "',@EFFECTIVEDATE='" + _obj_SMHR_LOANSETUP.EffectiveDate.ToString("MM/dd/yyyy")
                    + "'");
            }
            else if (_obj_SMHR_LOANSETUP.OPERATION == operation.Get)
            {
                return ExecuteQuery("EXEC USP_SMHR_LOANSETUP @OPERATION = 'Get',@PRINCIPLE_TOTAL='" + _obj_SMHR_LOANSETUP.Amount
                    + "',@RATE_OF_INTREST='" + _obj_SMHR_LOANSETUP.LOANSETUP_LOANINTEREST
                    + "',@NUMBER_OF_MONTHS='" + _obj_SMHR_LOANSETUP.LOANSETUP_MINTENUREMONTHS
                    + "'");
            }
            else
                return null;
        }
        public static bool set_OfflineAssessmentResult(SMHR_OFFLINEASSESSMENT_RESULT oSMHR_OFFLINEASSESSMENT_RESULT)
        {
            bool status = false;
            switch (oSMHR_OFFLINEASSESSMENT_RESULT.OPERATION)
            {
                case operation.Insert:
                    if (ExecuteNonQuery("EXEC USP_SMHR_ASSESSMENT_OFFLINERESULT @Operation = 'Insert',@OFFLINE_ASSESSMENTID='" + Convert.ToString(oSMHR_OFFLINEASSESSMENT_RESULT.OFFLINE_ASSESSMENTID)
                                         + "',@OFFLINE_RESULTDOC='" + Convert.ToString(oSMHR_OFFLINEASSESSMENT_RESULT.OFFLINE_RESULTDOC)
                                         + "',@OFFLINE_CREATEDDATE='" + oSMHR_OFFLINEASSESSMENT_RESULT.CREATEDDATE.ToString("MM/dd/yyyy")
                                         + "',@OFFLINE_CREATEDBY='" + oSMHR_OFFLINEASSESSMENT_RESULT.CREATEDBY
                                         + "',@OFFLINE_ORGID ='" + oSMHR_OFFLINEASSESSMENT_RESULT.ORGANISATION_ID
                                         + "',@OFFLINE_MODYFIEDBY   ='" + oSMHR_OFFLINEASSESSMENT_RESULT.LASTMDFBY
                                         + "',@OFFLINE_MODYFIEDDATE = '" + oSMHR_OFFLINEASSESSMENT_RESULT.LASTMDFDATE.ToString("MM/dd/yyyy")
                                         + "', @OFFLINE_EMPID = '" + oSMHR_OFFLINEASSESSMENT_RESULT.OFFLINE_EMPID
                                      + "'   "))


                        status = true;
                    else
                        status = false;
                    break;
                case operation.Update:

                    if (ExecuteNonQuery("EXEC USP_SMHR_ASSESSMENT_OFFLINERESULT @Operation = 'Update',@OFFLINE_RESULTID='" + Convert.ToString(oSMHR_OFFLINEASSESSMENT_RESULT.OFFLINE_RESULTID)
                                         + "',@OFFLINE_MARKS='" + oSMHR_OFFLINEASSESSMENT_RESULT.OFFLINE_MARKS
                                         + "',@OFFLINE_RESULT='" + oSMHR_OFFLINEASSESSMENT_RESULT.OFFLINE_RESULT
                                         + "',@OFFLINE_MODYFIEDBY   ='" + oSMHR_OFFLINEASSESSMENT_RESULT.LASTMDFBY
                                         + "',@OFFLINE_MODYFIEDDATE = '" + oSMHR_OFFLINEASSESSMENT_RESULT.LASTMDFDATE.ToString("MM/dd/yyyy")
                                      + "'   "))


                        status = true;
                    else
                        status = false;
                    break;

            }
            return status;

        }
        public static DataTable get_OfflineAssessmentResult(SMHR_OFFLINEASSESSMENT_RESULT oSMHR_OFFLINEASSESSMENT_RESULT)
        {
            if (oSMHR_OFFLINEASSESSMENT_RESULT.OPERATION == operation.Get)
            {
                return ExecuteQuery("EXEC USP_SMHR_ASSESSMENT_OFFLINERESULT @OPERATION = 'Get',@OFFLINE_ASSESSMENTID ='" + oSMHR_OFFLINEASSESSMENT_RESULT.OFFLINE_ASSESSMENTID
                    + "',@OFFLINE_ORGID ='" + oSMHR_OFFLINEASSESSMENT_RESULT.ORGANISATION_ID
                                         + "'");
            }
            else if (oSMHR_OFFLINEASSESSMENT_RESULT.OPERATION == operation.Offline)
            {
                return ExecuteQuery("EXEC USP_SMHR_ASSESSMENT_OFFLINERESULT @OPERATION = 'Offline',@OFFLINE_EMPID ='" + oSMHR_OFFLINEASSESSMENT_RESULT.OFFLINE_EMPID
                    + "'");
            }
            else if (oSMHR_OFFLINEASSESSMENT_RESULT.OPERATION == operation.Online)
            {
                return ExecuteQuery("EXEC USP_SMHR_ASSESSMENT_OFFLINERESULT @OPERATION = 'Online',@OFFLINE_EMPID ='" + oSMHR_OFFLINEASSESSMENT_RESULT.OFFLINE_EMPID
                    + "'");
            }

            else
                return null;
        }
        public static DataTable get_Rating(SMHR_FEEDBACK_RATING _obj_FEEDBACK_RATING)
        {
            if (_obj_FEEDBACK_RATING.OPERATION == operation.Check)
            {
                return ExecuteQuery("EXEC USP_SMHR_FEEDBACK_RATING @OPERATION = 'Check',@RATING_QUESTIONID ='" + _obj_FEEDBACK_RATING.RATING_QuestionID
                    + "',@RATING_ORGID ='" + _obj_FEEDBACK_RATING.RATING_ORGID
                                         + "',@RATING_SERVICEPROVIDER ='" + _obj_FEEDBACK_RATING.RATING_TYPE
                                         + "',@RATING_TRAINER_NAME ='" + Convert.ToString(_obj_FEEDBACK_RATING.RATING_TRAINER_NAME)
                                         + "'");
            }
            else if (_obj_FEEDBACK_RATING.OPERATION == operation.Select2)
            {
                return ExecuteQuery("EXEC USP_SMHR_FEEDBACK_RATING @Operation = 'Select2',@RATING_TYPE ='" + _obj_FEEDBACK_RATING.RATING_TYPE
                                         + "',@RATING_ORGID = '" + _obj_FEEDBACK_RATING.RATING_ORGID + "'");

            }
            else if (_obj_FEEDBACK_RATING.OPERATION == operation.Select1)
            {
                return ExecuteQuery("EXEC USP_SMHR_FEEDBACK_RATING @OPERATION = 'Select1', @RATING_ORGID='" + _obj_FEEDBACK_RATING.RATING_ORGID
                                         + "' ,@RATING_SERVICEPROVIDER ='" + _obj_FEEDBACK_RATING.RATING_SERVICEPROVIDER
                                      + "'");
            }

            else
                return null;
        }

        public static DataTable get_LoanMaxEligibleAmount(SMHR_LOANELIGIBLEAMOUNT smhr_LoanAmount)
        {
            if (smhr_LoanAmount.OPERATION == operation.Select)
            {
                return ExecuteQuery("EXEC USP_SMHR_LOANELIGIBLEAMOUNT @OPERATION = 'Select',@LOANELIGIBLEAMOUNT_ORG_ID='" + smhr_LoanAmount.OrgID + "'");
            }
            else if (smhr_LoanAmount.OPERATION == operation.Check)
            {
                return ExecuteQuery("EXEC USP_SMHR_LOANELIGIBLEAMOUNT @OPERATION = 'Check',@LOANELIGIBLEAMOUNT_ORG_ID='" + smhr_LoanAmount.OrgID + "'");
            }
            else if (smhr_LoanAmount.OPERATION == operation.Get)
            {
                return ExecuteQuery("EXEC USP_SMHR_LOANELIGIBLEAMOUNT @OPERATION = 'GET',@LOANELIGIBLEAMOUNT_ORG_ID='" + smhr_LoanAmount.OrgID + "',@LOANELIGIBLEAMOUNT_LOANTYPE_ID='" + smhr_LoanAmount.LoanID + "',@LOANELIGIBLEAMOUNT_FIN_PERIOD_ID='" + smhr_LoanAmount.FinancialPeriodID + "'");
            }
            else
                return null;
        }
        public static bool set_LoanMaxEligibleAmount(SMHR_LOANELIGIBLEAMOUNT smhr_LoanAmount)
        {
            bool status = false;
            switch (smhr_LoanAmount.OPERATION)
            {
                case operation.Insert:
                    List<SqlParameter> lstSqlparams = new List<SqlParameter>();
                    lstSqlparams.Add(new SqlParameter("@OPERATION", "Insert"));
                    lstSqlparams.Add(new SqlParameter("@LOANELIGIBLEAMOUNT_ORG_ID", smhr_LoanAmount.OrgID));
                    lstSqlparams.Add(new SqlParameter("@LOANELIGIBLEAMOUNT_LOANTYPE_ID", smhr_LoanAmount.LoanID));
                    lstSqlparams.Add(new SqlParameter("@LOANELIGIBLEAMOUNT_FIN_PERIOD_ID", smhr_LoanAmount.FinancialPeriodID));
                    lstSqlparams.Add(new SqlParameter("@LOANELIGIBLEAMOUNT_CERATEDBY", smhr_LoanAmount.CREATEDBY));
                    lstSqlparams.Add(new SqlParameter("@LOANELIGIBLEAMOUNT_CREATEDDATE", smhr_LoanAmount.CREATEDDATE));
                    lstSqlparams.Add(new SqlParameter("@LOANELIGIBLEAMOUNT_MODYFIEDBY", smhr_LoanAmount.LASTMDFBY));
                    lstSqlparams.Add(new SqlParameter("@LOANELIGIBLEAMOUNT_MODYFIEDDATE", smhr_LoanAmount.LASTMDFDATE));
                    lstSqlparams.Add(new SqlParameter("@GradeWiseAmount", smhr_LoanAmount.GradeWiseAmount));
                    int result = ExecuteNonQuery("USP_SMHR_LOANELIGIBLEAMOUNT", lstSqlparams.ToArray());
                    if (result > 0)
                        status = true;
                    else
                        status = false;
                    break;
                default:
                    break;
            }
            return status;
        }

        public static bool set_PensionScheme(SMHR_EMPPENSIONSCHEME _obj_Smhr_PENSIONSCHEME)
        {
            bool status = false;
            switch (_obj_Smhr_PENSIONSCHEME.OPERATION)
            {
                case operation.Insert:
                    if (ExecuteNonQuery("EXEC USP_SMHR_EMP_PENSIONSCHEME @Operation = 'Insert',@PENSIONSCHEME_ORGID  ='" + _obj_Smhr_PENSIONSCHEME.ORGANISATION_ID
                                         + "',@PENSIONSCHEME_EMPID ='" + _obj_Smhr_PENSIONSCHEME.EMPPENSIONSCHEME_EMPID
                                         + "', @PENSIONSCHEME_JOINDATE  ='" + _obj_Smhr_PENSIONSCHEME.EMPPENSIONSCHEME_JOINDATE
                                         + "',@PENSIONSCHEME_PENSIONNO  ='" + _obj_Smhr_PENSIONSCHEME.EMPPENSIONSCHEME_PENSIONID
                                      //   + "',@PENSIONSCHEME_CREATEDBY ='" + _obj_Smhr_PENSIONSCHEME.CREATEDBY
                                      //   + "',@PENSIONSCHEME_CREATEDDATE    ='" + _obj_Smhr_PENSIONSCHEME.CREATEDDATE.ToString("MM/dd/yyyy")
                                      //   + "',@PENSIONSCHEME_MODYFIEDBY  ='" + _obj_Smhr_PENSIONSCHEME.LASTMDFBY
                                      //   + "',@PENSIONSCHEME_MODYFIEDDATE  ='" + _obj_Smhr_PENSIONSCHEME.LASTMDFDATE.ToString("MM/dd/yyyy")
                                      + "'"))


                        status = true;
                    else
                        status = false;
                    break;
                case operation.Update:
                    if (ExecuteNonQuery("EXEC USP_SMHR_EMP_PENSIONSCHEME @OPERATION = 'Update'"
                                         + ",@PENSIONSCHEME_EMPID ='" + _obj_Smhr_PENSIONSCHEME.EMPPENSIONSCHEME_EMPID
                                         + "',@PENSIONSCHEME_PENSIONNO  ='" + _obj_Smhr_PENSIONSCHEME.EMPPENSIONSCHEME_PENSIONID
                                         + "', @PENSIONSCHEME_JOINDATE  ='" + _obj_Smhr_PENSIONSCHEME.EMPPENSIONSCHEME_JOINDATE
                                         //+ "',@PENSIONSCHEME_MODYFIEDBY  ='" + _obj_Smhr_PENSIONSCHEME.LASTMDFBY
                                         //+ "',@PENSIONSCHEME_MODYFIEDDATE  ='" + _obj_Smhr_PENSIONSCHEME.LASTMDFDATE.ToString("MM/dd/yyyy")
                                         + "'"))

                        status = true;
                    else
                        status = false;

                    break;
                case operation.Check1:
                    if (ExecuteNonQuery("EXEC USP_SMHR_EMP_PENSIONSCHEME @OPERATION = '" + _obj_Smhr_PENSIONSCHEME.OPERATION
                                         + "',@PENSIONSCHEME_ORGID ='" + _obj_Smhr_PENSIONSCHEME.ORGANISATION_ID
                                         + "',@PENSIONSCHEME_PENSIONNO  ='" + _obj_Smhr_PENSIONSCHEME.EMPPENSIONSCHEME_PENSIONID
                                         + "'"))

                        status = true;
                    else
                        status = false;

                    break;






            }
            return status;
        }
        public static DataTable get_PensionScheme(SMHR_EMPPENSIONSCHEME _obj_Smhr_PENSIONSCHEME)
        {
            if (_obj_Smhr_PENSIONSCHEME.OPERATION == operation.Get)
            {
                return ExecuteQuery("EXEC USP_SMHR_EMP_PENSIONSCHEME @OPERATION = 'Get', @PENSIONSCHEME_EMPID ='" + _obj_Smhr_PENSIONSCHEME.EMPPENSIONSCHEME_EMPID + "'");
            }
            else if (_obj_Smhr_PENSIONSCHEME.OPERATION == operation.Select)
            {
                return ExecuteQuery("EXEC USP_SMHR_EMP_PENSIONSCHEME @OPERATION = 'Select',@PENSIONSCHEME_ORGID ='" + _obj_Smhr_PENSIONSCHEME.ORGANISATION_ID + "'");
            }
            else if (_obj_Smhr_PENSIONSCHEME.OPERATION == operation.Check1)
            {
                return ExecuteQuery("EXEC USP_SMHR_EMP_PENSIONSCHEME @OPERATION = 'Check1',@PENSIONSCHEME_ORGID =" + _obj_Smhr_PENSIONSCHEME.ORGANISATION_ID + ", @PENSIONSCHEME_EMPID = " + _obj_Smhr_PENSIONSCHEME.EMPPENSIONSCHEME_EMPID);
            }
            //else if (_obj_Smhr_QuestionBank.OPERATION == operation.Check)
            //{
            //    return ExecuteQuery("EXEC USP_SMHR_TRAINING_QUESTIONBANK @OPERATION = 'Check',@QuestionBank_ORGANISATION_ID ='" + _obj_Smhr_QuestionBank.QuestionBank_ORGANISATION_ID + "',@QuestionBank_ID ='" + _obj_Smhr_QuestionBank.QuestionBank_ID + "'");
            //}
            //else if (_obj_Smhr_QuestionBank.OPERATION == operation.Select2)
            //{
            //    return ExecuteQuery("EXEC USP_SMHR_TRAINING_QUESTIONBANK @OPERATION = 'Select2',@QuestionBank_ORGANISATION_ID ='" + _obj_Smhr_QuestionBank.QuestionBank_ORGANISATION_ID + "',@QuestionBank_ChapterID  ='" + _obj_Smhr_QuestionBank.QuestionBank_ChapterID + "'");
            //}
            //else if (_obj_Smhr_QuestionBank.OPERATION == operation.Select3)
            //{
            //    return ExecuteQuery("EXEC USP_SMHR_TRAINING_QUESTIONBANK @OPERATION = 'Select3',@TRAINING_ASSESSMENT_QUESTIONS ='" + _obj_Smhr_QuestionBank.QuestionBank_Question + "'");
            //}
            else
                return null;
        }
        public static bool set_AVC(SMHR_EMPAVC _obj_Smhr_AVC)
        {
            bool status = false;
            switch (_obj_Smhr_AVC.OPERATION)
            {
                case operation.Insert:
                    if (ExecuteNonQuery("EXEC USP_SMHR_EMP_AVC @Operation = 'Insert',@AVC_ORGID  ='" + _obj_Smhr_AVC.ORGANISATION_ID
                                         + "',@AVC_EMPID ='" + _obj_Smhr_AVC.EMPAVC_EMPID
                                         + "', @AVC_PENSION_AMOUNT  ='" + _obj_Smhr_AVC.EMPAVC_PENSION_AMOUNT
                                         + "',@AVC_CREATEDBY ='" + _obj_Smhr_AVC.CREATEDBY
                                         + "',@AVC_CREATEDDATE    ='" + _obj_Smhr_AVC.CREATEDDATE.ToString("MM/dd/yyyy")
                                         + "',@AVC_MODYFIEDBY  ='" + _obj_Smhr_AVC.LASTMDFBY
                                         + "',@AVC_MODYFIEDDATE  ='" + _obj_Smhr_AVC.LASTMDFDATE.ToString("MM/dd/yyyy")
                                      + "'  "))


                        status = true;
                    else
                        status = false;
                    break;
                case operation.Update:
                    if (ExecuteNonQuery("EXEC USP_SMHR_EMP_AVC @OPERATION = 'Update',@AVC_ID  ='" + Convert.ToString(_obj_Smhr_AVC.EMPAVCID)
                                          + "', @AVC_PENSION_AMOUNT ='" + _obj_Smhr_AVC.EMPAVC_PENSION_AMOUNT
                                         + "',@AVC_MODYFIEDBY  ='" + _obj_Smhr_AVC.LASTMDFBY
                                         + "',@AVC_MODYFIEDDATE  ='" + _obj_Smhr_AVC.LASTMDFDATE.ToString("MM/dd/yyyy")
                                         + "'"))

                        status = true;
                    else
                        status = false;

                    break;

            }
            return status;
        }
        public static DataTable get_AVC(SMHR_EMPAVC _obj_Smhr_AVC)
        {
            if (_obj_Smhr_AVC.OPERATION == operation.Get)
            {
                return ExecuteQuery("EXEC USP_SMHR_EMP_AVC @OPERATION = 'Get',@AVC_ID ='" + _obj_Smhr_AVC.EMPAVCID + "'");
            }
            else if (_obj_Smhr_AVC.OPERATION == operation.Select)
            {
                return ExecuteQuery("EXEC USP_SMHR_EMP_AVC @OPERATION = 'Select',@AVC_ORGID ='" + _obj_Smhr_AVC.ORGANISATION_ID + "'");
            }

            else
                return null;
        }

        public static DataTable get_PensionQuarters(SMHR_PENSION_QUARTERS smhr_PensionQrtrs)
        {
            if (smhr_PensionQrtrs.OPERATION == operation.Select)
            {
                return ExecuteQuery("EXEC USP_SMHR_PENSIONQRTRS @OPERATION = 'Select',@QRTR_ORG_ID='" + smhr_PensionQrtrs.ORGANISATION_ID + "'");
            }
            //else if (smhr_PensionQrtrs.OPERATION == operation.Check)
            //{
            //    return ExecuteQuery("EXEC USP_SMHR_LOANELIGIBLEAMOUNT @OPERATION = 'Check',@LOANELIGIBLEAMOUNT_ORG_ID='" + smhr_LoanAmount.OrgID + "'");
            //}
            else if (smhr_PensionQrtrs.OPERATION == operation.Get)
            {
                return ExecuteQuery("EXEC USP_SMHR_PENSIONQRTRS @OPERATION = 'GET',@QRTR_ORG_ID='" + smhr_PensionQrtrs.ORGANISATION_ID + "',@QRTR_ID='" + smhr_PensionQrtrs.QRTR_ID + "'");
            }
            else if (smhr_PensionQrtrs.OPERATION == operation.Select_New)
            {
                return ExecuteQuery("EXEC USP_SMHR_PENSIONQRTRS @OPERATION = '" + smhr_PensionQrtrs.OPERATION
                                    + "', @QRTR_ORG_ID =" + smhr_PensionQrtrs.ORGANISATION_ID
                                    + ",  @QRTR_PERIODID =" + smhr_PensionQrtrs.QRTR_PERIODID);
            }
            else
                return null;
        }
        public static bool set_PensionQuarters(SMHR_PENSION_QUARTERS smhr_PensionQrtrs)
        {
            bool status = false;
            switch (smhr_PensionQrtrs.OPERATION)
            {
                case operation.Insert:
                    if (ExecuteNonQuery("EXEC USP_SMHR_PENSIONQRTRS @Operation = 'Insert',@QRTR_PERIODID  ='" + smhr_PensionQrtrs.QRTR_PERIODID
                                         + "',@QRTR_ORG_ID ='" + smhr_PensionQrtrs.ORGANISATION_ID
                                         + "', @QRTR_NOOFQRTRS  ='" + smhr_PensionQrtrs.QRTR_NOOFQRTRS
                                         + "', @QRTR_QRTR1SDATE  ='" + smhr_PensionQrtrs.QRTR_QRTR1SDATE
                                         + "', @QRTR_QRTR1EDATE  ='" + smhr_PensionQrtrs.QRTR_QRTR1EDATE
                                         + "', @QRTR_QRTR2SDATE  ='" + smhr_PensionQrtrs.QRTR_QRTR2SDATE
                                         + "', @QRTR_QRTR2EDATE  ='" + smhr_PensionQrtrs.QRTR_QRTR2EDATE
                                         + "', @QRTR_QRTR3SDATE  ='" + smhr_PensionQrtrs.QRTR_QRTR3SDATE
                                         + "', @QRTR_QRTR3EDATE  ='" + smhr_PensionQrtrs.QRTR_QRTR3EDATE
                                         + "', @QRTR_QRTR4SDATE  ='" + smhr_PensionQrtrs.QRTR_QRTR4SDATE
                                         + "', @QRTR_QRTR4EDATE  ='" + smhr_PensionQrtrs.QRTR_QRTR4EDATE
                                         + "',@QRTR_CREATEDBY ='" + smhr_PensionQrtrs.CREATEDBY
                                         + "',@QRTR_CREATEDDATE    ='" + smhr_PensionQrtrs.CREATEDDATE.ToString("MM/dd/yyyy")
                                         + "',@QRTR_MODYFIEDBY  ='" + smhr_PensionQrtrs.LASTMDFBY
                                         + "',@QRTR_MODYFIEDDATE  ='" + smhr_PensionQrtrs.LASTMDFDATE.ToString("MM/dd/yyyy")
                                      + "'  "))


                        status = true;
                    else
                        status = false;
                    break;
                case operation.Update:
                    //if (ExecuteNonQuery("EXEC USP_SMHR_EMP_AVC @OPERATION = 'Update',@AVC_ID  ='" + Convert.ToString(_obj_Smhr_AVC.EMPAVCID)
                    //                      + "', @AVC_PENSION_AMOUNT ='" + _obj_Smhr_AVC.EMPAVC_PENSION_AMOUNT
                    //                     + "',@AVC_MODYFIEDBY  ='" + _obj_Smhr_AVC.LASTMDFBY
                    //                     + "',@AVC_MODYFIEDDATE  ='" + _obj_Smhr_AVC.LASTMDFDATE.ToString("MM/dd/yyyy")
                    //                     + "'"))

                    //    status = true;
                    //else
                    status = false;

                    break;

            }
            return status;
        }
        public static bool set_Taxation(SMHR_TAXATIONMASTER _obj_Smhr_Taxation)
        {
            bool status = false;
            switch (_obj_Smhr_Taxation.OPERATION)
            {
                case operation.Insert:
                    List<SqlParameter> lstSqlparams = new List<SqlParameter>();
                    lstSqlparams.Add(new SqlParameter("@OPERATION", "Insert"));
                    lstSqlparams.Add(new SqlParameter("@TAXATIONMASTER_FINPERIOD_ID", _obj_Smhr_Taxation.TAXATIONMASTER_FINPERIOD_ID));
                    lstSqlparams.Add(new SqlParameter("@TAXATIONMASTER_TYPE_ID", _obj_Smhr_Taxation.TAXATIONMASTER_TYPE_ID));
                    lstSqlparams.Add(new SqlParameter("@TAXATIONMASTER_TYPE_NAME", _obj_Smhr_Taxation.TAXATIONMASTER_TYPE_NAME));
                    lstSqlparams.Add(new SqlParameter("@TAXATIONMASTER_ORGID", _obj_Smhr_Taxation.ORGANISATION_ID));
                    lstSqlparams.Add(new SqlParameter("@TAXATIONMASTER_CREATEDBY", _obj_Smhr_Taxation.CREATEDBY));
                    lstSqlparams.Add(new SqlParameter("@TAXATIONMASTER_CREATEDDATE", _obj_Smhr_Taxation.CREATEDDATE.ToString("MM/dd/yyyy")));
                    lstSqlparams.Add(new SqlParameter("@TAXATIONMASTER_MODYFIEDBY", _obj_Smhr_Taxation.LASTMDFBY));
                    lstSqlparams.Add(new SqlParameter("@TAXATIONMASTER_MODYFIEDDATE", _obj_Smhr_Taxation.LASTMDFDATE.ToString("MM/dd/yyyy")));
                    lstSqlparams.Add(new SqlParameter("@TAXATIONDATA", _obj_Smhr_Taxation.TAXATIONDATA));
                    int result = ExecuteNonQuery("USP_SMHR_TAXATIONMASTER", lstSqlparams.ToArray());
                    if (result > 0)
                        status = true;
                    else
                        status = false;
                    break;
                case operation.Update:
                    if (ExecuteNonQuery("EXEC USP_SMHR_TAXATIONMASTER @OPERATION = 'Update',@TAXATIONMASTER_ID  ='" + Convert.ToString(_obj_Smhr_Taxation.TAXATIONMASTER_ID)
                                          + "', @TAXATIONMASTER_SLAB_AMOUNT  ='" + _obj_Smhr_Taxation.TAXATIONMASTER_SLAB_AMOUNT
                                         + "',@TAXATIONMASTER_SLAB_PER  ='" + _obj_Smhr_Taxation.TAXATIONMASTER_SLAB_PER
                                         + "',@TAXATIONMASTER_MODYFIEDBY  ='" + _obj_Smhr_Taxation.TAXATIONMASTER_MODYFIEDBY
                                         + "',@TAXATIONMASTER_MODYFIEDDATE  ='" + _obj_Smhr_Taxation.TAXATIONMASTER_MODYFIEDDATE.ToString("MM/dd/yyyy")
                                         + "'"))

                        status = true;
                    else
                        status = false;

                    break;

            }
            return status;
        }
        public static DataTable get_Taxation(SMHR_TAXATIONMASTER _obj_Smhr_Taxation)
        {
            if (_obj_Smhr_Taxation.OPERATION == operation.Get)
            {
                return ExecuteQuery("EXEC USP_SMHR_TAXATIONMASTER @OPERATION = 'Get',@TAXATIONMASTER_FINPERIOD_ID ='" + _obj_Smhr_Taxation.TAXATIONMASTER_FINPERIOD_ID
                    + "',@TAXATIONMASTER_ORGID='" + _obj_Smhr_Taxation.ORGANISATION_ID
                    + "',@TAXATIONMASTER_TYPE_ID='" + _obj_Smhr_Taxation.TAXATIONMASTER_TYPE_ID + "'");

            }
            else if (_obj_Smhr_Taxation.OPERATION == operation.Select)
            {
                return ExecuteQuery("EXEC USP_SMHR_TAXATIONMASTER @OPERATION = 'Check',@TAXATIONMASTER_ORGID ='" + _obj_Smhr_Taxation.TAXATIONMASTER_ORGID + "',@TAXATIONMASTER_FINPERIOD_ID='" + _obj_Smhr_Taxation.TAXATIONMASTER_FINPERIOD_ID + "'");
            }

            else
                return null;
        }
        public static bool set_CostType(SMHR_TRAININGCOST _obj_Smhr_Cost)
        {
            bool status = false;
            switch (_obj_Smhr_Cost.OPERATION)
            {
                case operation.Insert:
                    List<SqlParameter> lstSqlparams = new List<SqlParameter>();
                    lstSqlparams.Add(new SqlParameter("@OPERATION", "Insert"));
                    lstSqlparams.Add(new SqlParameter("@TRAININGCOST_COURSESCHEDULE_ID", _obj_Smhr_Cost.TRAININGCOST_COURSESCHEDULE_ID));
                    lstSqlparams.Add(new SqlParameter("@TRAININGCOST_ORG_ID", _obj_Smhr_Cost.ORGANISATION_ID));
                    lstSqlparams.Add(new SqlParameter("@TRAININGCOST_CREATEDBY", _obj_Smhr_Cost.CREATEDBY));
                    lstSqlparams.Add(new SqlParameter("@TRAININGCOST_CREATEDATE", _obj_Smhr_Cost.CREATEDDATE.ToString("MM/dd/yyyy")));
                    lstSqlparams.Add(new SqlParameter("@TRAININGCOST_MODYFIEDBY", _obj_Smhr_Cost.LASTMDFBY));
                    lstSqlparams.Add(new SqlParameter("@TRAININGCOST_MODYFIEDDATE", _obj_Smhr_Cost.LASTMDFDATE.ToString("MM/dd/yyyy")));
                    lstSqlparams.Add(new SqlParameter("@TRAININGCOST", _obj_Smhr_Cost.TRAININGCOST));
                    int result = ExecuteNonQuery("USP_SMHR_TRAININGCOST", lstSqlparams.ToArray());
                    if (result > 0)
                        status = true;
                    else
                        status = false;
                    break;

            }
            return status;
        }
        public static DataTable get_CostType(SMHR_TRAININGCOST _obj_Smhr_Cost)
        {
            if (_obj_Smhr_Cost.OPERATION == operation.Get)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAININGCOST @OPERATION = 'Get',@TRAININGCOST_ORG_ID ='" + _obj_Smhr_Cost.ORGANISATION_ID
                    + "',@TRAININGCOST_COURSESCHEDULE_ID='" + _obj_Smhr_Cost.TRAININGCOST_COURSESCHEDULE_ID
                    + "'");

            }
            else if (_obj_Smhr_Cost.OPERATION == operation.Select)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAININGCOST @OPERATION = 'Select',@TRAININGCOST_ORG_ID ='" + _obj_Smhr_Cost.ORGANISATION_ID + "'");
            }
            else if (_obj_Smhr_Cost.OPERATION == operation.Select1)
            {
                return ExecuteQuery("EXEC USP_SMHR_TRAININGCOST @OPERATION = 'Select1',@TRAININGCOST_ORG_ID ='" + _obj_Smhr_Cost.ORGANISATION_ID + "'");
            }


            else
                return null;
        }
        public static bool set_MailID(SMHR_Module_MailID _obj_Smhr_MailID)
        {
            bool status = false;
            switch (_obj_Smhr_MailID.OPERATION)
            {
                case operation.Insert:
                    List<SqlParameter> lstSqlparams = new List<SqlParameter>();
                    lstSqlparams.Add(new SqlParameter("@OPERATION", "Insert"));
                    lstSqlparams.Add(new SqlParameter("@Module_MailID_ORG_ID", _obj_Smhr_MailID.ORGANISATION_ID));
                    lstSqlparams.Add(new SqlParameter("@Module_MailID_CreatedBy", _obj_Smhr_MailID.CREATEDBY));
                    lstSqlparams.Add(new SqlParameter("@Module_MailID_CreatedDate", _obj_Smhr_MailID.CREATEDDATE.ToString("MM/dd/yyyy")));
                    lstSqlparams.Add(new SqlParameter("@Module_MailID_ModyfiedBy", _obj_Smhr_MailID.LASTMDFBY));
                    lstSqlparams.Add(new SqlParameter("@Module_MailID_ModyfiedDate", _obj_Smhr_MailID.LASTMDFDATE.ToString("MM/dd/yyyy")));
                    lstSqlparams.Add(new SqlParameter("@MODULEMAILIDS", _obj_Smhr_MailID.MODULEMAILIDS));
                    int result = ExecuteNonQuery("USP_SMHR_MODULEMAILIDS", lstSqlparams.ToArray());
                    if (result > 0)
                        status = true;
                    else
                        status = false;
                    break;

            }
            return status;
        }

        public static bool setEmailConfgMailIds(SMHR_Module_MailID _obj_Smhr_MailID)
        {
            bool sts = false;

            if (BLL.ExecuteNonQuery("EXEC USP_SMHR_MODULEMAILIDS @OPERATION = 'Insert1', @Module_MailID_ModuleID =" + _obj_Smhr_MailID.Module_MailID_ModuleID +
                                        " , @Module_MailID_EmailIDS='" + _obj_Smhr_MailID.Module_MailID_EmailIDS +
                                        "', @Module_MailID_AdminEMailID='" + _obj_Smhr_MailID.Module_MailID_AdminEMailID +
                                        "', @Module_MailID_ORG_ID = " + _obj_Smhr_MailID.ORGANISATION_ID +
                                        " , @Module_MailID_CreatedBy=" + _obj_Smhr_MailID.CREATEDBY +
                                        " , @Module_MailID_ModyfiedBy=" + _obj_Smhr_MailID.LASTMDFBY))
                sts = true;

            return sts;
        }

        public static DataTable get_MailID(SMHR_Module_MailID _obj_Smhr_MailID)
        {

            if (_obj_Smhr_MailID.OPERATION == operation.Select)
            {
                return ExecuteQuery("EXEC USP_SMHR_MODULEMAILIDS @OPERATION = 'Select',@Module_MailID_ModuleID ='" + _obj_Smhr_MailID.Module_MailID_ModuleID
                    + "',@Module_MailID_AdminEMailID='" + _obj_Smhr_MailID.Module_MailID_AdminEMailID
                    + "',@Module_MailID_ORG_ID =" + _obj_Smhr_MailID.ORGANISATION_ID);
            }
            else if (_obj_Smhr_MailID.OPERATION == operation.Get)
            {
                return ExecuteQuery("EXEC USP_SMHR_MODULEMAILIDS @OPERATION = 'Get',@Module_MailID_ORG_ID =" + _obj_Smhr_MailID.ORGANISATION_ID);
            }



            else
                return null;
        }
        public static DataTable get_PMS()
        {
            return ExecuteQuery("EXEC RPT_CONSOLIDATEDSTATUS_DSET");

        }
        public static DataTable get_CourseProc(SMHR_COURSESCHEDULE OSMHR_COURSESCHEDULE)
        {
            return ExecuteQuery("EXEC USP_LOCATIONWISETRAINING_COURSEDSET @Organisation='" + OSMHR_COURSESCHEDULE.ORGANISATION_ID + "',@Location='" + OSMHR_COURSESCHEDULE.COURSESCHEDULE_LOCATIONID + "'");

        }
    }

}