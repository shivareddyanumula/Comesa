using SMHR;
using SPMS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace SPMS
{
    /// <summary>
    /// Summary description for PMS_BLL1
    /// </summary>
    public partial class Pms_Bll
    {
        //<summary>
        //This Method is used for insertion, deletion and updation of ROLES based upon criteria
        //</summary>
        //<returns>
        //Bool
        //</returns>


        public static bool set_RoleKra(SPMS_ROLEKRA _obj_Pms_RoleKra)
        {
            bool status = false;
            switch (_obj_Pms_RoleKra.OPERATION)
            {
                case operation.Insert:
                    if (Pms_Bll.ExecuteNonQuery("EXEC USP_PMS_ROLEKRA @Operation ='"
                           + _obj_Pms_RoleKra.OPERATION
                           + "', @ROLEKRA_ORG_ID =" + _obj_Pms_RoleKra.ROLEKRA_ORG_ID
                           + ",  @PMS_BU_ID = " + _obj_Pms_RoleKra.BUID
                           + ",  @POSITION_ID =" + _obj_Pms_RoleKra.PositionID
                           + ",  @ROLE_KRA_ID =" + _obj_Pms_RoleKra.ROLE_KRA_ID
                           + ",  @PMS_Type =" + _obj_Pms_RoleKra.PMS_Type
                           + ",  @ROLEKRA_CREATED_BY =" + _obj_Pms_RoleKra.CREATEDBY
                           + ",  @ROLEKRA_CREATED_DATE ='" + _obj_Pms_RoleKra.CREATEDDATE
                           + "',  @ROLEKRA_LASTMDF_BY =" + _obj_Pms_RoleKra.LASTMDFBY
                           + ",  @ROLEKRA_LASTMDF_DATE ='" + _obj_Pms_RoleKra.LASTMDFDATE+"'"))
                        status = true;
                    else
                        status = false;
                    break;
                default:
                    break;
            }
            //switch (_obj_Pms_RoleKra.Mode)
            //{
            //    case 3:
            //        if (ExecuteNonQuery("EXEC USP_PMS_ROLEKRA @MODE = 3 , @ROLE_ID = '" + Convert.ToString(_obj_Pms_RoleKra.ROLE_ID) + "'" +
            //                          " ,@ROLEKRA_ORG_ID= " + Convert.ToString(_obj_Pms_RoleKra.ROLEKRA_ORG_ID) + ",@ROLE_KRA_ID = " + Convert.ToString(_obj_Pms_RoleKra.ROLE_KRA_ID) +
            //                         " , @ROLEKRA_CREATED_BY = " + Convert.ToInt32(_obj_Pms_RoleKra.ROLEKRA_CREATED_BY) +
            //                          ", @ROLEKRA_CREATED_DATE = '" + Convert.ToDateTime(_obj_Pms_RoleKra.ROLEKRA_CREATED_DATE).ToString("MM/dd/yyyy") + "'"))
            //            status = true;
            //        else
            //            status = false;
            //        break;
            //    case 4:
            //        if (ExecuteNonQuery("EXEC USP_PMS_ROLEKRA @MODE = 4 , @ROLEKRA_ID  = " + Convert.ToString(_obj_Pms_RoleKra.ROLEKRA_ID)
            //                           + ",   @ROLE_ID = '" + Convert.ToString(_obj_Pms_RoleKra.ROLE_ID) + "'" +
            //                          " ,@ROLE_KRA_ID = " + Convert.ToString(_obj_Pms_RoleKra.ROLE_KRA_ID) +
            //                         " ,@ROLEKRA_LASTMDF_BY = " + Convert.ToInt32(_obj_Pms_RoleKra.ROLEKRA_LASTMDF_BY) +
            //                          ", @ROLEKRA_LASTMDF_DATE = '" + Convert.ToDateTime(_obj_Pms_RoleKra.ROLEKRA_LASTMDF_DATE).ToString("MM/dd/yyyy") + "'"))
            //            status = true;
            //        else
            //            status = false;

            //        break;
            //    case 5:
            //        if (ExecuteNonQuery("EXEC USP_PMS_ROLEKRA @MODE = 5 ,@ROLEKRA_ID= " + Convert.ToString(_obj_Pms_RoleKra.ROLEKRA_ID)
            //                          + " "))

            //            status = true;
            //        else
            //            status = false;
            //        break;
            //    default:
            //        break;
            //}
            return status;

        }

        //<summary>
        //This Method is used to fetch KRA's, Compentences, and Values from tables PMS_KRA, PMS_CMP, and PMS_IDP respectively.
        //</summary>
        //<returns>
        //DataSet
        //</returns>
        public static DataSet getKRACompetenciesValues(SPMS_ROLEKRA _obj_Pms_RoleKra)
        {
            DataSet ds = new DataSet();
            switch (_obj_Pms_RoleKra.OPERATION)
            {
                case operation.Select:
                    ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["connection"].ToString(), CommandType.Text, "EXEC USP_PMS_ROLEKRA @Operation = '"
                        + _obj_Pms_RoleKra.OPERATION
                        + "', @ROLEKRA_ORG_ID =" + _obj_Pms_RoleKra.ROLEKRA_ORG_ID
                        + ",  @PMS_BU_ID = " + _obj_Pms_RoleKra.BUID);
                    break;
                //case operation.Get:
                //    ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["connection"].ToString(), CommandType.Text, "EXEC USP_PMS_ROLEKRA @Operation = '"
                //        + _obj_Pms_RoleKra.OPERATION
                //        + "', @ROLEKRA_ORG_ID =" + _obj_Pms_RoleKra.ROLEKRA_ORG_ID
                //        + ",  @PMS_BU_ID = " + _obj_Pms_RoleKra.BUID
                //        + ",  @POSITION_ID =" + _obj_Pms_RoleKra.PositionID);
                //    break;
                default:
                    break;
            }
            return ds;
        }

        /// <summary>
        /// This method is used to check if KRA, Competence, and Values already exists for the given criteria
        /// </summary>
        /// <returns>
        ///bool
        /// </returns>
        public static bool IsRoleKRAExits(SPMS_ROLEKRA _obj_Pms_RoleKra)
        {
            bool status = false;
            switch (_obj_Pms_RoleKra.OPERATION)
            {
                case operation.Check:
                    return status = Convert.ToBoolean(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["connection"].ToString(), CommandType.Text, "EXEC USP_PMS_ROLEKRA @Operation ='"
                           + _obj_Pms_RoleKra.OPERATION
                           + "', @ROLEKRA_ORG_ID =" + _obj_Pms_RoleKra.ROLEKRA_ORG_ID
                           + ",  @PMS_BU_ID = " + _obj_Pms_RoleKra.BUID
                           + ",  @POSITION_ID =" + _obj_Pms_RoleKra.PositionID
                           + ",  @ROLE_KRA_ID =" + _obj_Pms_RoleKra.ROLE_KRA_ID
                           + ",  @PMS_Type =" + _obj_Pms_RoleKra.PMS_Type));
                default:
                    return status;
            }
        }

        /// This method is used to get KRA, Competence, and Values for the given criteria
        /// </summary>
        /// <returns>
        /// DataTable 
        /// </returns>
        public static DataTable getPositionKRA(SPMS_ROLEKRA _obj_Pms_RoleKra)
        {
            DataTable dt = new DataTable();
            switch (_obj_Pms_RoleKra.OPERATION)
            {
                case operation.Get:
                    dt = Pms_Bll.ExecuteQuery("EXEC USP_PMS_ROLEKRA @OPERATION ='" + _obj_Pms_RoleKra.OPERATION
                            + "', @ROLEKRA_ORG_ID = " + _obj_Pms_RoleKra.ROLEKRA_ORG_ID
                            + ",  @PMS_BU_ID =" + _obj_Pms_RoleKra.BUID
                            + ",  @POSITION_ID =" + _obj_Pms_RoleKra.PositionID
                            + ",  @PMS_Type =" + _obj_Pms_RoleKra.PMS_Type);
                    break;
                default:
                    break;
            }
            return dt;
        }

        /// <summary>
        /// This method is used to check if KRA, Competence, and Values already exists for the given criteria
        /// </summary>
        /// <returns>
        ///bool
        /// </returns>
        public static bool del_KRA(SPMS_ROLEKRA _obj_Pms_RoleKra)
        {
            bool status = false;
            switch (_obj_Pms_RoleKra.OPERATION)
            {
                case operation.Delete:
                    status = Pms_Bll.ExecuteNonQuery("EXEC USP_PMS_ROLEKRA @Operation ='"
                          + _obj_Pms_RoleKra.OPERATION
                          //+ "', @ROLEKRA_ORG_ID =" + _obj_Pms_RoleKra.ROLEKRA_ORG_ID
                          //+ ",  @PMS_BU_ID = " + _obj_Pms_RoleKra.BUID
                          + "',  @ROLEKRA_ID =" + _obj_Pms_RoleKra.ROLEKRA_ID);
                    break;
                default:
                    break;
            }
            return status;
        }

    }
}