using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Data;
using Telerik.Web.UI;

public partial class Approval_frm_LeaveApproval : System.Web.UI.Page
{
    SMHR_LEAVEAPP _obj_smhr_leaveapp;
    DataTable dt_Details;

    int I_ChkCount = 0;

    #region raj
    //public partial class BLL
    //{
    //    public static bool get_Leave_Mail(SMHR_LEAVEAPP _obj_Smhr_LeaveApp)
    //    {
    //        bool status = false;
    //        switch (_obj_Smhr_LeaveApp.MODE)
    //        {
    //            case 1:
    //                if (ExecuteNonQuery("EXEC USP_SMHR_LEAVE_MAIL @EMPID= '" + Convert.ToString(_obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID) + "',@MODE='" + Convert.ToInt32(_obj_Smhr_LeaveApp.MODE) + "'" +
    //                    ",@FROMDATE='" + Convert.ToDateTime(_obj_Smhr_LeaveApp.LEAVEAPP_FROMDATE).ToString("MM/dd/yyyy") + "',@TODATE='" + Convert.ToDateTime(_obj_Smhr_LeaveApp.LEAVEAPP_TODATE).ToString("MM/dd/yyyy") + "',@TOTALDAYS='" + _obj_Smhr_LeaveApp.LEAVEAPP_DAYS + "'"))
    //                {
    //                    status = true;

    //                }
    //                else
    //                    status = false;
    //                break;
    //            case 2:
    //                if (ExecuteNonQuery("EXEC USP_SMHR_LEAVE_MAIL @EMPID= '" + Convert.ToString(_obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID) + "',@MODE='" + Convert.ToInt32(_obj_Smhr_LeaveApp.MODE) + "'" +
    //                    ",@LEAVE_ID='" + _obj_Smhr_LeaveApp.LEAVEAPP_ID + "'"))
    //                {
    //                    status = true;

    //                }
    //                else
    //                    status = false;
    //                break;
    //            case 3:
    //                if (ExecuteNonQuery("EXEC USP_SMHR_LEAVE_MAIL @EMPID= '" + Convert.ToString(_obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID) + "',@MODE='" + Convert.ToInt32(_obj_Smhr_LeaveApp.MODE) + "'" +
    //                      ",@LEAVE_ID='" + _obj_Smhr_LeaveApp.LEAVEAPP_ID + "'"))
    //                {
    //                    status = true;

    //                }
    //                else
    //                    status = false;
    //                break;
    //            case 4:
    //                if (ExecuteNonQuery("EXEC USP_SMHR_LEAVE_MAIL @EMPID= '" + Convert.ToString(_obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID) + "',@MODE='" + Convert.ToInt32(_obj_Smhr_LeaveApp.MODE) + "'" +
    //                    ",@FROMDATE='" + Convert.ToDateTime(_obj_Smhr_LeaveApp.LEAVEAPP_FROMDATE).ToString("MM/dd/yyyy") + "',@TODATE='" + Convert.ToDateTime(_obj_Smhr_LeaveApp.LEAVEAPP_TODATE).ToString("MM/dd/yyyy") + "',@TOTALDAYS='" + _obj_Smhr_LeaveApp.LEAVEAPP_DAYS + "'"))
    //                {
    //                    status = true;

    //                }
    //                else
    //                    status = false;
    //                break;
    //            case 5:
    //                if (ExecuteNonQuery("EXEC USP_SMHR_LEAVE_MAIL @EMPID= '" + Convert.ToString(_obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID) + "',@MODE='" + Convert.ToInt32(_obj_Smhr_LeaveApp.MODE) + "'" +
    //                    ",@FROMDATE='" + Convert.ToDateTime(_obj_Smhr_LeaveApp.LEAVEAPP_FROMDATE).ToString("MM/dd/yyyy") + "',@TODATE='" + Convert.ToDateTime(_obj_Smhr_LeaveApp.LEAVEAPP_TODATE).ToString("MM/dd/yyyy") + "',@TOTALDAYS='" + _obj_Smhr_LeaveApp.LEAVEAPP_DAYS + "'"))
    //                {
    //                    status = true;

    //                }
    //                else
    //                    status = false;
    //                break;
    //        }
    //        return status;
    //    }

    //    public static DataTable get_LoginInfo(SMHR_LOGININFO _obj_Smhr_LoginInfo)
    //    {
    //        if (_obj_Smhr_LoginInfo.OPERATION == operation.Select)
    //        {
    //            if (_obj_Smhr_LoginInfo.LOGIN_ID.ToString() == "0")
    //                return ExecuteQuery("EXEC USP_SMHR_LOGININFO @Operation = 'select', @LOGIN_ORGANISATION_ID = '" + _obj_Smhr_LoginInfo.ORGANISATION_ID + "'");
    //            else
    //                return ExecuteQuery("EXEC USP_SMHR_LOGININFO @Operation = 'select', @LOGIN_ID =" + Convert.ToString(_obj_Smhr_LoginInfo.LOGIN_ID));
    //        }
    //        else if (_obj_Smhr_LoginInfo.OPERATION == operation.Select3)
    //        {
    //            return ExecuteQuery("EXEC USP_SMHR_LOGININFO @Operation = 'select3', @LOGIN_ORGANISATION_ID = '" + _obj_Smhr_LoginInfo.ORGANISATION_ID + "',@LOGIN_EMP_ID='" + _obj_Smhr_LoginInfo.LOGIN_EMP_ID + "'");
    //        }
    //        else if (_obj_Smhr_LoginInfo.OPERATION == operation.Empty1)
    //        {

    //            return ExecuteQuery("EXEC USP_SMHR_LOGININFO @Operation = 'getforms', " +
    //                            " @LOGIN_USERNAME ='" + Convert.ToString(_obj_Smhr_LoginInfo.LOGIN_USERNAME) + "'" +
    //                            ", @LOGIN_ORGANISATION_ID = '" + _obj_Smhr_LoginInfo.ORGANISATION_ID + "',@LOGIN_PASS_CODE = '" + _obj_Smhr_LoginInfo.LOGIN_PASS_CODE + "'" +
    //                            ",@LOGIN_ID='" + _obj_Smhr_LoginInfo.LOGIN_ID + "'" +
    //                            " ");

    //        }
    //        else if (_obj_Smhr_LoginInfo.OPERATION == operation.Empty)
    //        {
    //            return ExecuteQuery("EXEC USP_SMHR_LOGININFO @Operation = 'Empty', @LOGIN_ORGANISATION_ID='" + _obj_Smhr_LoginInfo.ORGANISATION_ID + "'");
    //        }
    //        else if (_obj_Smhr_LoginInfo.OPERATION == operation.getLogin)
    //        {
    //            return ExecuteQuery("EXEC USP_SMHR_LOGININFO @Operation='getLogin',@LOGIN_EMP_ID='" + _obj_Smhr_LoginInfo.LOGIN_EMP_ID + "',@LOGIN_ORGANISATION_ID='" + _obj_Smhr_LoginInfo.LOGIN_ORGANISATION_ID + "'");
    //        }
    //        else if (_obj_Smhr_LoginInfo.OPERATION == operation.Select4)
    //        {
    //            return ExecuteQuery("EXEC USP_SMHR_LOGININFO @Operation = 'Select4',@LOGIN_EMP_ID='" + _obj_Smhr_LoginInfo.LOGIN_EMP_ID + "'");
    //        }
    //        else
    //        {
    //            if (_obj_Smhr_LoginInfo.LOGIN_ID.ToString() == "0")
    //                return ExecuteQuery("EXEC USP_SMHR_LOGININFO @Operation = 'Check', " +
    //                            " @LOGIN_USERNAME ='" + Convert.ToString(_obj_Smhr_LoginInfo.LOGIN_USERNAME) + "'" +
    //                            ", @LOGIN_ORGANISATION_ID = '" + _obj_Smhr_LoginInfo.ORGANISATION_ID + "'");
    //            else
    //                return ExecuteQuery("EXEC USP_SMHR_LOGININFO @Operation = 'Check', " +
    //                                "@LOGIN_USERNAME ='" + Convert.ToString(_obj_Smhr_LoginInfo.LOGIN_USERNAME) + "', " +
    //                                " @LOGIN_ID=" + Convert.ToString(_obj_Smhr_LoginInfo.LOGIN_ID) + "" +
    //                                ", @LOGIN_ORGANISATION_ID = '" + _obj_Smhr_LoginInfo.ORGANISATION_ID + "'" +
    //                                ",@LOGIN_TYPE='" + _obj_Smhr_LoginInfo.LOGIN_TYPE + "'");
    //        }
    //    }
    //    public static string DateFormat(string UserId)
    //    {
    //        return Convert.ToString(ExecuteQuery("EXEC USP_SMHR_SECURITY @Operation ='DATE', @USERTYPE='" + UserId + "'").Rows[0]["DATEFORMAT"]);
    //    }
    //    public static void SetCulture_Theme(Page page, HttpRequest request)
    //    {
    //        if (((System.Web.UI.TemplateControl)(page)).AppRelativeVirtualPath.ToUpper() != "~/LOGIN.ASPX")
    //        {
    //            if (page.Session["USER_ID"] == null)
    //            {
    //                page.Response.Redirect("~/LOGIN.ASPX", false);
    //                return;
    //            }
    //            if (page.Session["ORG_ID"] == null)
    //            {
    //                page.Response.Redirect("~/LOGIN.ASPX", false);
    //                return;
    //            }
    //        }
    //    }
    //    public static void ChangeDateFormat(string UserId, params Telerik.Web.UI.RadDatePicker[] controls)
    //    {
    //        string TFormat = DateFormat(UserId);
    //        foreach (Telerik.Web.UI.RadDatePicker item in controls)
    //        {
    //            item.DateInput.DateFormat = TFormat;
    //        }
    //    }

    //    public static DataTable ExecuteQuery(string Query)
    //    {
    //        return Dal.ExecuteQuery(Query);
    //    }
    //    public static bool set_LeaveApp(SMHR_LEAVEAPP _obj_Smhr_LeaveApp)
    //    {
    //        bool status = false;
    //        switch (_obj_Smhr_LeaveApp.OPERATION)
    //        {
    //            case operation.Insert:
    //                if (ExecuteNonQuery("EXEC USP_SMHR_LEAVEAPP @Operation = 'Insert', @LEAVEAPP_EMP_ID=" + _obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID
    //                                  + " , @LEAVEAPP_LEAVETYPE_ID= " + _obj_Smhr_LeaveApp.LEAVEAPP_LEAVETYPE_ID
    //                                  + " , @LEAVEAPP_STATUS= " + _obj_Smhr_LeaveApp.LEAVEAPP_STATUS
    //                                  + " , @LEAVEAPP_APPLIEDDATE= '" + _obj_Smhr_LeaveApp.LEAVEAPP_APPLIEDDATE.ToString("MM/dd/yyyy")
    //                                  + "', @LEAVEAPP_FROMDATE='" + _obj_Smhr_LeaveApp.LEAVEAPP_FROMDATE.ToString("MM/dd/yyyy")
    //                                  + "', @LEAVEAPP_TODATE= '" + _obj_Smhr_LeaveApp.LEAVEAPP_TODATE.ToString("MM/dd/yyyy")
    //                                  + "', @LEAVEAPP_FIRSTHALF= '" + _obj_Smhr_LeaveApp.LEAVEAPP_FIRSTHALF.ToString()
    //                                  + "', @LEAVEAPP_SECONDHALF= '" + _obj_Smhr_LeaveApp.LEAVEAPP_SECONDHALF.ToString()
    //                                  + "', @LEAVEAPP_DAYS=" + _obj_Smhr_LeaveApp.LEAVEAPP_DAYS
    //                                  + ", @LEAVEAPP_DOCUMENT = '" + _obj_Smhr_LeaveApp.LEAVEAPP_DOCUMENT
    //                                  + "' , @LEAVEAPP_REASON= '" + _obj_Smhr_LeaveApp.LEAVEAPP_REASON
    //                                  + "',@LEAVEAPP_ORGANISATION_ID='" + _obj_Smhr_LeaveApp.ORGANISATION_ID
    //                                  + "', @LEAVEAPP_CREATEDBY= " + Convert.ToString(_obj_Smhr_LeaveApp.CREATEDBY)
    //                                  + " , @LEAVEAPP_CREATEDDATE='" + _obj_Smhr_LeaveApp.CREATEDDATE.ToString("MM/dd/yyyy")
    //                                  + "', @LEAVEAPP_LASTMDFBY =" + Convert.ToString(_obj_Smhr_LeaveApp.LASTMDFBY)
    //                                  + " , @LEAVEAPP_LASTMDFDATE='" + _obj_Smhr_LeaveApp.LASTMDFDATE.ToString("MM/dd/yyyy") + "'"))
    //                    status = true;
    //                else
    //                    status = false;
    //                break;
    //            case operation.Update:
    //                if (ExecuteNonQuery("EXEC USP_SMHR_LEAVEAPP @Operation = 'Update',@LEAVEAPP_ID=" + Convert.ToString(_obj_Smhr_LeaveApp.LEAVEAPP_ID)
    //                                  + " , @LEAVEAPP_LEAVETYPE_ID=" + _obj_Smhr_LeaveApp.LEAVEAPP_LEAVETYPE_ID
    //                                  + " , @LEAVEAPP_EMP_ID= " + _obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID
    //                                  + " , @LEAVEAPP_STATUS= " + _obj_Smhr_LeaveApp.LEAVEAPP_STATUS
    //                                  + " , @LEAVEAPP_APPLIEDDATE= '" + _obj_Smhr_LeaveApp.LEAVEAPP_APPLIEDDATE.ToString("MM/dd/yyyy")
    //                                  + "', @LEAVEAPP_FROMDATE='" + _obj_Smhr_LeaveApp.LEAVEAPP_FROMDATE.ToString("MM/dd/yyyy")
    //                                  + "', @LEAVEAPP_TODATE= '" + _obj_Smhr_LeaveApp.LEAVEAPP_TODATE.ToString("MM/dd/yyyy")
    //                                  + "', @LEAVEAPP_FIRSTHALF= '" + _obj_Smhr_LeaveApp.LEAVEAPP_FIRSTHALF.ToString()
    //                                  + "', @LEAVEAPP_SECONDHALF= '" + _obj_Smhr_LeaveApp.LEAVEAPP_SECONDHALF.ToString()
    //                                  + "', @LEAVEAPP_DAYS=" + _obj_Smhr_LeaveApp.LEAVEAPP_DAYS
    //                                  + ", @LEAVEAPP_DOCUMENT = '" + _obj_Smhr_LeaveApp.LEAVEAPP_DOCUMENT
    //                                  + "' , @LEAVEAPP_REASON= '" + _obj_Smhr_LeaveApp.LEAVEAPP_REASON
    //                                  + "', @LEAVEAPP_LASTMDFBY =" + Convert.ToString(_obj_Smhr_LeaveApp.LASTMDFBY)
    //                                  + " , @LEAVEAPP_LASTMDFDATE='" + _obj_Smhr_LeaveApp.LASTMDFDATE.ToString("MM/dd/yyyy") + "'"))
    //                    status = true;
    //                else
    //                    status = false;

    //                break;
    //            case operation.Delete:
    //                if (ExecuteNonQuery("EXEC USP_SMHR_LEAVEAPP @Operation = 'Delete', @LEAVEAPP_ID=" + Convert.ToString(_obj_Smhr_LeaveApp.LEAVEAPP_ID)
    //                                  + " , @LEAVEAPP_LASTMDFBY =" + Convert.ToString(_obj_Smhr_LeaveApp.LASTMDFBY)
    //                                  + " , @LEAVEAPP_LASTMDFDATE='" + _obj_Smhr_LeaveApp.LASTMDFDATE.ToString("MM/dd/yyyy") + "'"))
    //                    status = true;
    //                else
    //                    status = false;
    //                break;
    //            case operation.Delete1:
    //                if (ExecuteNonQuery("EXEC USP_SMHR_LEAVEAPP @Operation = 'Rollback', @LEAVEAPP_APPROVEDATE='" + _obj_Smhr_LeaveApp.LEAVEAPP_APPROVEDATE.ToString("MM/dd/yyyy")
    //                    + "', @LEAVE_ROLLBACKDATE='" + _obj_Smhr_LeaveApp.LEAVE_ROLLBACKDATE.ToString("MM/dd/yyyy")
    //                                  + "', @LEAVEAPP_STATUS=" + _obj_Smhr_LeaveApp.LEAVEAPP_STATUS
    //                                  + " , @LEAVEAPP_LASTMDFBY =" + Convert.ToString(_obj_Smhr_LeaveApp.LASTMDFBY)
    //                                  + " , @LEAVEAPP_LASTMDFDATE='" + _obj_Smhr_LeaveApp.LASTMDFDATE.ToString("MM/dd/yyyy")
    //                                  + "',@LEAVEAPP_ORGANISATION_ID='" + _obj_Smhr_LeaveApp.ORGANISATION_ID
    //                                  + "'  ,@LEAVEAPP_ID="+_obj_Smhr_LeaveApp.LEAVEAPP_ID+""))
    //                    status = true;
    //                else
    //                    status = false;
    //                break;
    //            case operation.Check:
    //                if (ExecuteNonQuery("EXEC USP_SMHR_LEAVEAPP @Operation = 'Check', @LEAVEAPP_REASON='" + Convert.ToString(_obj_Smhr_LeaveApp.LEAVEAPP_REASON)
    //                                  + "', @LEAVEAPP_APPROVEDBY =" + Convert.ToString(_obj_Smhr_LeaveApp.LEAVEAPP_APPROVEDBY)
    //                                  + " , @LEAVEAPP_APPROVEDATE='" + _obj_Smhr_LeaveApp.LEAVEAPP_APPROVEDATE.ToString("MM/dd/yyyy")
    //                                  + "', @LEAVEAPP_STATUS=" + _obj_Smhr_LeaveApp.LEAVEAPP_STATUS
    //                                  + " , @LEAVEAPP_LASTMDFBY =" + Convert.ToString(_obj_Smhr_LeaveApp.LASTMDFBY)
    //                                  + " , @LEAVEAPP_LASTMDFDATE='" + _obj_Smhr_LeaveApp.LASTMDFDATE.ToString("MM/dd/yyyy")
    //                                  + "',@LEAVEAPP_ORGANISATION_ID='" + _obj_Smhr_LeaveApp.ORGANISATION_ID
    //                                  + "',@LEAVEAPP_REJECT_REASON ='" + _obj_Smhr_LeaveApp.LEAVEAPP_REJECT_REASON + "'"))
    //                    status = true;
    //                else
    //                    status = false;
    //                break;

    //            default:
    //                break;
    //        }
    //        return status;
    //    }
    //    public static bool ExecuteNonQuery(string Query)
    //    {
    //        return Dal.ExecuteNonQuery(Query);
    //    }
    //    public static bool set_leavebalances(SMHR_LEAVEBALANCE _obj_smhr_leavebal)
    //    {
    //        bool status = false;
    //        switch (_obj_smhr_leavebal.MODE)
    //        {
    //            case 4:
    //                if (ExecuteNonQuery(" EXEC USP_SMHR_LEAVEBALANCES @Operation = 'Update',@MODE = 4,@EMPNAME = '" + _obj_smhr_leavebal.EMPNAME + "',@LT_LEAVETYPEID ='" + _obj_smhr_leavebal.LT_LEAVETYPEID + "'"))
    //                    status = true;
    //                else
    //                    status = false;
    //                break;
    //            case 5:
    //                if (ExecuteNonQuery(" EXEC USP_SMHR_LEAVEBALANCES @Operation = 'Update',@MODE = 5,@LT_EMPID = " + _obj_smhr_leavebal.EMPNAME + ",@NDAYS=" + _obj_smhr_leavebal.NDays + ",@LT_LEAVETYPEID ='" + _obj_smhr_leavebal.LT_LEAVETYPEID + "',@LEAVEAPP_ID='" + _obj_smhr_leavebal.LEAVEAPP_ID + "',@LEAVEAPP_APPROVEDATE='" + _obj_smhr_leavebal.CREATEDDATE+ "'"))
    //                    status = true;
    //                else
    //                    status = false;
    //                break;
    //            case 8:
    //                if (ExecuteNonQuery(" EXEC USP_SMHR_LEAVEBALANCES @Operation = 'Update',@MODE = 8,@LT_EMPID = " + _obj_smhr_leavebal.EMPNAME + ",@NDAYS=" + _obj_smhr_leavebal.NDays + ",@LT_LEAVETYPEID ='" + _obj_smhr_leavebal.LT_LEAVETYPEID + "',@LEAVEAPP_ID='" + _obj_smhr_leavebal.LEAVEAPP_ID + "',@LEAVEAPP_APPROVEDATE='" + _obj_smhr_leavebal.CREATEDDATE + "'"))
    //                    status = true;
    //                else
    //                    status = false;
    //                break;
    //            case 6:
    //                if (ExecuteNonQuery(" EXEC USP_SMHR_LEAVEBALANCES @Operation = 'Update',@MODE = 6,@LT_EMPID = " + _obj_smhr_leavebal.LT_EMPID + ",@NDAYS=" + _obj_smhr_leavebal.NDays + ",@LT_LEAVETYPEID ='" + _obj_smhr_leavebal.LT_LEAVETYPEID + "'"))
    //                    status = true;
    //                else
    //                    status = false;
    //                break;

    //            default: break;
    //        }
    //        return status;

    //    }
    //    public static void ShowMessage(Control ctrl, string Msg)
    //    {
    //        ScriptManager.RegisterStartupScript(ctrl, ctrl.GetType(), Guid.NewGuid().ToString(), "alert('" + Msg + "');", true);
    //    }

    //    public static void ShowConfirmMessage(Control ctrl, string Msg)
    //    {
    //        ScriptManager.RegisterStartupScript(ctrl, ctrl.GetType(), Guid.NewGuid().ToString(), "confirm('" + Msg + "');", true);
    //    }
    //    public static DataTable get_LeaveApp(SMHR_LEAVEAPP _obj_Smhr_LeaveApp)
    //    {
    //        if (_obj_Smhr_LeaveApp.OPERATION == operation.Select)
    //        {
    //            if (_obj_Smhr_LeaveApp.LEAVEAPP_ID.ToString() == "0")
    //                return ExecuteQuery("EXEC USP_SMHR_LEAVEAPP @Operation = 'select', @ORGANISATION_ID = " + _obj_Smhr_LeaveApp.ORGANISATION_ID + ",@EMP_LOGIN_ID='" + _obj_Smhr_LeaveApp.LOGIN_ID + "'");
    //            else
    //                return ExecuteQuery("EXEC USP_SMHR_LEAVEAPP @Operation = 'select', @LEAVEAPP_ID =" + Convert.ToString(_obj_Smhr_LeaveApp.LEAVEAPP_ID));

    //        }
    //        # region RAJ
    //        else if (_obj_Smhr_LeaveApp.OPERATION == operation.Available)
    //        {
    //            return ExecuteQuery("EXEC USP_SMHR_LEAVEAPP @Operation = 'LEAVEDETAILS', @ORGANISATION_ID = " + _obj_Smhr_LeaveApp.ORGANISATION_ID + ",@EMP_LOGIN_ID='" + _obj_Smhr_LeaveApp.LOGIN_ID + "',@LEAVEAPP_EMP_ID = " + _obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID + "");
    //        }

    //        else if (_obj_Smhr_LeaveApp.OPERATION == operation.Delete)
    //        {
    //            return ExecuteQuery("EXEC USP_SMHR_LEAVEAPP @Operation = 'EMPLOYEEUNDREP', @ORGANISATION_ID = " + _obj_Smhr_LeaveApp.ORGANISATION_ID + ",@EMP_LOGIN_ID='" + _obj_Smhr_LeaveApp.LOGIN_ID + "',@LEAVEAPP_EMP_ID = " + _obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID + "");
    //        }
    //        #endregion
    //        else if (_obj_Smhr_LeaveApp.OPERATION == operation.Insert)
    //        {
    //            return ExecuteQuery("EXEC USP_SMHR_LEAVEAPP @Operation = 'FILLLEAVE', @LEAVEAPP_EMP_ID = " + _obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID);

    //        }
    //        else if (_obj_Smhr_LeaveApp.OPERATION == operation.Empty)
    //        {

    //            return ExecuteQuery("EXEC USP_SMHR_LEAVEAPP @Operation = 'DAYS', @LEAVEAPP_EMP_ID = '" + _obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID
    //                + "', @LEAVEAPP_LEAVETYPE_ID='" + _obj_Smhr_LeaveApp.LEAVEAPP_LEAVETYPE_ID
    //                + "', @LEAVEAPP_FROMDATE='" + _obj_Smhr_LeaveApp.LEAVEAPP_FROMDATE.ToString("MM/dd/yyyy")
    //                + "', @LEAVEAPP_TODATE='" + _obj_Smhr_LeaveApp.LEAVEAPP_TODATE.ToString("MM/dd/yyyy")
    //                + "', @LEAVEAPP_FIRSTHALF='" + Convert.ToString(_obj_Smhr_LeaveApp.LEAVEAPP_FIRSTHALF)
    //                + "', @LEAVEAPP_SECONDHALF='" + Convert.ToString(_obj_Smhr_LeaveApp.LEAVEAPP_SECONDHALF) + "'");
    //        }
    //        else if (_obj_Smhr_LeaveApp.OPERATION == operation.Update)
    //        {
    //            return ExecuteQuery("EXEC USP_SMHR_LEAVEAPP @Operation = 'Gethalf', @LEAVEAPP_LEAVETYPE_ID = " + _obj_Smhr_LeaveApp.LEAVEAPP_LEAVETYPE_ID + ", @LEAVEAPP_EMP_ID=" + _obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID);
    //        }

    //        else if (_obj_Smhr_LeaveApp.OPERATION == operation.Select_New)
    //        {
    //            return ExecuteQuery("EXEC USP_SMHR_LEAVEAPPSTATUS @operation='Select_New',@EMP_ID='" + _obj_Smhr_LeaveApp.EMP_ID + "'");
    //        }
    //        else if (_obj_Smhr_LeaveApp.OPERATION == operation.Check_New)
    //        {
    //            return ExecuteQuery("EXEC USP_SMHR_LEAVEAPPSTATUS @operation='Check_New',@LEAVEAPP_STATUS='" + _obj_Smhr_LeaveApp.LEAVEAPP_STATUS + "',@LeaveApp_ApprovedBy='" + _obj_Smhr_LeaveApp.LEAVEAPP_APPROVEDBY + "'");
    //        }
    //        else if (_obj_Smhr_LeaveApp.OPERATION == operation.Check1)
    //        {
    //            return ExecuteQuery("EXEC USP_SMHR_LEAVEAPP @operation='Check1',@LEAVEAPP_EMP_ID='" + _obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID + "',@LEAVEAPP_FROMDATE='" + Convert.ToDateTime(_obj_Smhr_LeaveApp.LEAVEAPP_FROMDATE).ToString("MM/dd/yyyy") + "',@LEAVEAPP_TODATE='" + Convert.ToDateTime(_obj_Smhr_LeaveApp.LEAVEAPP_TODATE).ToString("MM/dd/yyyy") + "',@LEAVEAPP_ORGANISATION_ID='" + _obj_Smhr_LeaveApp.ORGANISATION_ID + "'");
    //        }
    //        else if (_obj_Smhr_LeaveApp.OPERATION == operation.Validate)
    //        {
    //            return ExecuteQuery("EXEC USP_SMHR_LEAVEAPP @OPERATION='VALIDATE',@LEAVEAPP_EMP_ID='" + _obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID + "',@LEAVEAPP_ORGANISATION_ID='" + _obj_Smhr_LeaveApp.ORGANISATION_ID + "'");
    //        }
    //        else if (_obj_Smhr_LeaveApp.OPERATION == operation.Select1)
    //        {
    //            return ExecuteQuery("EXEC USP_SMHR_LEAVEAPP @OPERATION='Select1',@LEAVEAPP_EMP_ID='" + _obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID + "',@LEAVEAPP_LEAVETYPE_ID='" + _obj_Smhr_LeaveApp.LEAVEAPP_LEAVETYPE_ID + "'");
    //        }
    //        else if (_obj_Smhr_LeaveApp.OPERATION == operation.EMPTY_R)
    //        {
    //            return ExecuteQuery("EXEC USP_SMHR_LEAVEAPP @OPERATION = 'EMPTY_R', @LEAVEAPP_BUSINESSUNIT_ID =" + Convert.ToString(_obj_Smhr_LeaveApp.BUSINESSUNIT_ID)
    //                                    + ", @LEAVEAPP_EMP_ID = " + (_obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID));
    //        }
    //        else if (_obj_Smhr_LeaveApp.OPERATION == operation.Validate1)
    //        {
    //            return ExecuteQuery("EXEC USP_SMHR_EMPLOYEE @Operation = 'Validate1', @EMP_REPORTINGEMPLOYEE = '" + _obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID + "',@EMP_ORGANISATION_ID=" + _obj_Smhr_LeaveApp.ORGANISATION_ID + "");
    //        }
    //        else
    //        {
    //            return ExecuteQuery("EXEC USP_SMHR_EMPLOYEE @Operation = 'check', @EMP_REPORTINGEMPLOYEE = '" + _obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID + "',@EMP_ORGANISATION_ID=" + _obj_Smhr_LeaveApp.ORGANISATION_ID + "");
    //        }


    //    }
    //    public static DataTable get_EmpLeaveDetails(SMHR_LEAVEAPP _obj_Smhr_LeaveApp)
    //    {
    //        DataTable dt = new DataTable();
    //        switch (_obj_Smhr_LeaveApp.MODE)
    //        {
    //            case 1:
    //                dt = ExecuteQuery("EXEC USP_SMHR_LEAVEAPP  @MODE = 1,@ORGANISATION_ID = " + _obj_Smhr_LeaveApp.ORGANISATION_ID);
    //                break;

    //            case 2:
    //                dt = ExecuteQuery("EXEC USP_SMHR_LEAVEAPP @MODE = 2, @LEAVEAPP_BUSINESSUNIT_ID =" + Convert.ToString(_obj_Smhr_LeaveApp.BUSINESSUNIT_ID));
    //                break;

    //            case 3:
    //                dt = ExecuteQuery("EXEC USP_SMHR_LEAVEAPP @MODE = 3, @LEAVEAPP_BUSINESSUNIT_ID =" + Convert.ToString(_obj_Smhr_LeaveApp.BUSINESSUNIT_ID)
    //                                    + ", @LEAVEAPP_EMP_ID = " + (_obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID));
    //                break;
    //            case 4:
    //                dt = ExecuteQuery("EXEC USP_SMHR_LEAVEAPP @MODE = 4, @LEAVEAPP_EMP_ID = " + (_obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID));
    //                break;
    //            default:
    //                break;

    //        }
    //        return dt;

    //    }
    //}

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("LEAVE APPROVAL");
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
                    RG_LeaveApproval.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Approve.Visible = false;
                    btn_Reject.Visible = false;
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
                rtxt_ReportingMgr.Text = Convert.ToString(Session["EMP_ID"]);
                //LoadData();
                rdp_ApprovalDate.SelectedDate = DateTime.Now;
                BLL.ChangeDateFormat(Convert.ToString(Session["EMP_ID"]), rdp_ApprovalDate);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }
    private void LoadData()
    {
        try
        {
            _obj_smhr_leaveapp = new SMHR_LEAVEAPP();
            //_obj_smhr_leaveapp.OPERATION = operation.Check;
            _obj_smhr_leaveapp.OPERATION = operation.Validate1;
            _obj_smhr_leaveapp.LEAVEAPP_EMP_ID = Convert.ToInt32(Convert.ToString(Session["EMP_ID"]));
            _obj_smhr_leaveapp.ORGANISATION_ID = Convert.ToInt32(Convert.ToString(Session["org_ID"]));
            _obj_smhr_leaveapp.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            dt_Details = new DataTable();
            dt_Details = BLL.get_LeaveApp(_obj_smhr_leaveapp);
            RG_LeaveApproval.DataSource = dt_Details;
            //RG_LeaveApproval.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rollback_click(object sender, CommandEventArgs e)
    {
        try
        {
            SMHR_LEAVEAPP _obj_smhr_leaveApp1 = new SMHR_LEAVEAPP();
            _obj_smhr_leaveApp1.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_leaveApp1.LEAVEAPP_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            _obj_smhr_leaveApp1.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_leaveApp1.OPERATION = operation.Available;
            DataTable dt_Details = BLL.get_LeaveApp(_obj_smhr_leaveApp1);

            string str = Convert.ToString(e.CommandArgument);
            _obj_smhr_leaveapp = new SMHR_LEAVEAPP();
            _obj_smhr_leaveapp.LEAVEAPP_STATUS = 3;
            _obj_smhr_leaveapp.LEAVEAPP_EMP_ID = Convert.ToInt32(dt_Details.Rows[0]["EMP_ID"]);
            //_obj_smhr_leaveapp.LEAVEAPP_APPROVEDBY = Convert.ToInt32(Convert.ToString(Session["EMP_ID"]));
            _obj_smhr_leaveapp.LEAVEAPP_APPROVEDATE = Convert.ToDateTime((dt_Details.Rows[0]["LEAVEAPP_TODATE"]));
            _obj_smhr_leaveapp.LEAVE_ROLLBACKDATE = DateTime.Now;
            _obj_smhr_leaveapp.LASTMDFBY = Convert.ToInt32(Convert.ToString(Session["EMP_ID"]));
            _obj_smhr_leaveapp.LEAVEAPP_ID = Convert.ToInt32(e.CommandArgument);
            _obj_smhr_leaveapp.LASTMDFDATE = DateTime.Now;
            _obj_smhr_leaveapp.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_leaveapp.LEAVEAPP_LEAVETYPE_ID = Convert.ToInt32(dt_Details.Rows[0]["LEAVETYPEID"]);

            _obj_smhr_leaveapp.OPERATION = operation.Delete1;
            BLL.set_LeaveApp(_obj_smhr_leaveapp);
            SMHR_LEAVEBALANCE _obj_smhr_leavebal = new SMHR_LEAVEBALANCE();
            _obj_smhr_leavebal.LT_LEAVETYPEID = Convert.ToInt32(dt_Details.Rows[0]["LEAVETYPEID"]);
            _obj_smhr_leavebal.OPERATION = operation.Update;
            _obj_smhr_leavebal.EMPNAME = Convert.ToString(dt_Details.Rows[0]["EMP_ID"]);
            _obj_smhr_leavebal.ORGANISATION_ID = Convert.ToInt32(Convert.ToString(Session["org_ID"]));
            _obj_smhr_leavebal.MODE = 8;
            _obj_smhr_leavebal.NDays = float.Parse(Convert.ToString(dt_Details.Rows[0]["LEAVEAPP_DAYS"]));
            _obj_smhr_leavebal.LEAVEAPP_ID = Convert.ToInt32(e.CommandArgument);
            _obj_smhr_leavebal.CREATEDDATE = Convert.ToDateTime((dt_Details.Rows[0]["LEAVEAPP_TODATE"]));
            _obj_smhr_leavebal.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            bool rs = BLL.set_leavebalances(_obj_smhr_leavebal);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


    }
    protected void btn_Approve_Click(object sender, EventArgs e)
    {
        try
        {
            CheckBox chkBox = new CheckBox();
            Label lblAppID = new Label();
            Label lblempid = new Label();
            Label lblNoDays = new Label();
            Label lblLeaveID = new Label();
            Label lblLeaveCode = new Label();
            Label lblPrdID = new Label();
            RadTextBox rtxt_rej_reason = new RadTextBox();
            bool status = false;
            bool status1 = false;
            //string str = "";
            //string str1 = "";
            for (int index = 0; index <= RG_LeaveApproval.Items.Count - 1; index++)
            {
                string str = "";
                string str1 = "";
                chkBox = RG_LeaveApproval.Items[index].FindControl("chk_Choose") as CheckBox;
                lblAppID = RG_LeaveApproval.Items[index].FindControl("lblLeavetypeid") as Label;
                lblempid = RG_LeaveApproval.Items[index].FindControl("lblempID") as Label;
                lblNoDays = RG_LeaveApproval.Items[index].FindControl("lblempLeaveDays") as Label;
                lblLeaveID = RG_LeaveApproval.Items[index].FindControl("lblLeaveID") as Label;
                lblLeaveCode = RG_LeaveApproval.Items[index].FindControl("lblempLeave") as Label;
                lblPrdID = RG_LeaveApproval.Items[index].FindControl("lblPrdID") as Label;
                rtxt_rej_reason = RG_LeaveApproval.Items[index].FindControl("rtxt_rej_reason") as RadTextBox;
                if (chkBox.Checked)
                {
                    I_ChkCount = I_ChkCount + 1;
                    if (str == "")
                        str = "" + lblAppID.Text + "";
                    else
                        str = str + "," + lblAppID.Text + "";
                    if (str1 == "")
                        str1 = "" + lblempid.Text + "";

                    _obj_smhr_leaveapp = new SMHR_LEAVEAPP();
                    _obj_smhr_leaveapp.LEAVEAPP_REASON = str;
                    _obj_smhr_leaveapp.LEAVEAPP_STATUS = 1;
                    _obj_smhr_leaveapp.LEAVEAPP_EMP_ID = Convert.ToInt32(str1);
                    _obj_smhr_leaveapp.LEAVEAPP_APPROVEDBY = Convert.ToInt32(Convert.ToString(Session["EMP_ID"]));
                    _obj_smhr_leaveapp.LEAVEAPP_APPROVEDATE = Convert.ToDateTime(rdp_ApprovalDate.SelectedDate.Value);
                    _obj_smhr_leaveapp.LASTMDFBY = 1;
                    _obj_smhr_leaveapp.LASTMDFDATE = DateTime.Now;
                    _obj_smhr_leaveapp.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_leaveapp.LEAVEAPP_LEAVETYPE_ID = Convert.ToInt32(lblLeaveID.Text);
                    _obj_smhr_leaveapp.LEAVEAPP_REJECT_REASON = Convert.ToString(rtxt_rej_reason.Text.Replace("'", "''"));
                    /*if (lblLeaveCode.Text.Trim() != "LOP")
                    {
                        //TO GET LEAVEBALANCES OF EMPLOYEE
                        _obj_smhr_leaveapp.OPERATION = operation.Select1;
                        DataTable dt_bal = BLL.get_LeaveApp(_obj_smhr_leaveapp);
                        if (dt_bal.Rows.Count > 0)
                        {
                            if (Convert.ToDouble(dt_bal.Rows[0]["LT_CURRENTBALANCE"]) <= 0.00)
                            {
                                BLL.ShowMessage(this, "Employee Does Not Have Leaves For This LeaveType.");
                                return;
                            }
                            if (Convert.ToDouble(dt_bal.Rows[0]["LT_CURRENTBALANCE"]) < Convert.ToDouble(lblNoDays.Text))
                            {
                                BLL.ShowMessage(this, "Employee Has Only " + Convert.ToDouble(dt_bal.Rows[0]["LT_CURRENTBALANCE"]) + " Balances.");
                                return;
                            }

                        }
                        else
                        {
                            BLL.ShowMessage(this, "Employee Does Not Have Balances For Selected Leave Type.");
                            return;
                        }
                    }*/
                    _obj_smhr_leaveapp.OPERATION = operation.Check;
                    status = BLL.set_LeaveApp(_obj_smhr_leaveapp);
                    if (lblLeaveCode.Text.Trim() != "LOP")
                    {
                        if (status == true)
                        {
                            SMHR_LEAVEBALANCE _obj_smhr_leavebal = new SMHR_LEAVEBALANCE();

                            _obj_smhr_leavebal.LT_LEAVETYPEID = Convert.ToInt32(lblLeaveID.Text);
                            _obj_smhr_leavebal.OPERATION = operation.Update;
                            _obj_smhr_leavebal.EMPNAME = str1;
                            _obj_smhr_leavebal.MODE = 9;    //5;
                            _obj_smhr_leavebal.NDays = float.Parse(lblNoDays.Text);
                            _obj_smhr_leavebal.LEAVEAPP_ID = Convert.ToInt32(lblAppID.Text);
                            _obj_smhr_leavebal.CREATEDDATE = Convert.ToDateTime(rdp_ApprovalDate.SelectedDate.Value);
                            _obj_smhr_leavebal.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            if (lblPrdID.Text != string.Empty)
                                _obj_smhr_leavebal.LT_PRD_ID = Convert.ToInt32(lblPrdID.Text);
                            _obj_smhr_leavebal.LT_EMPID = Convert.ToInt32(lblempid.Text);
                            bool rs = BLL.set_leavebalances(_obj_smhr_leavebal);
                            //BLL.ShowMessage(this, "Selected Leave approved and Leave Balance Updated");
                            SMHR_LEAVEAPP _obj_Smhr_LeaveApp = new SMHR_LEAVEAPP();
                            _obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID = Convert.ToInt32(str1);
                            _obj_Smhr_LeaveApp.LEAVEAPP_ID = Convert.ToInt32(lblAppID.Text);
                            _obj_Smhr_LeaveApp.MODE = 4;
                            DataTable dt_mail = BLL.get_EmpLeaveDetails(_obj_Smhr_LeaveApp);
                            if (dt_mail.Rows.Count > 0)
                            {
                                //if (!((dt_mail.Rows[0]["REPORTING_EMP_EMAIL"] != System.DBNull.Value && dt_mail.Rows[0]["REPORTING_EMP_EMAIL"] != string.Empty) || (dt_mail.Rows[0]["EMP_EMAIL"] != System.DBNull.Value && dt_mail.Rows[0]["EMP_EMAIL"] != string.Empty) || (dt_mail.Rows[0]["REPORTING_EMP"] != System.DBNull.Value && dt_mail.Rows[0]["REPORTING_EMP"] != string.Empty)))
                                if (((Convert.ToString(dt_mail.Rows[0]["REPORTING_EMP_EMAIL"]) != string.Empty) && (dt_mail.Rows[0]["REPORTING_EMP_EMAIL"]) != System.DBNull.Value)
                                    && ((Convert.ToString(dt_mail.Rows[0]["EMP_EMAIL"]) != string.Empty) && (dt_mail.Rows[0]["EMP_EMAIL"]) != System.DBNull.Value)
                                    && ((Convert.ToString(dt_mail.Rows[0]["REPORTING_EMP"]) != string.Empty) && ((dt_mail.Rows[0]["REPORTING_EMP"]) != System.DBNull.Value)))
                                {
                                    _obj_Smhr_LeaveApp.MODE = 2;
                                    if (BLL.get_Leave_Mail(_obj_Smhr_LeaveApp))
                                    {
                                        status1 = true;
                                        //BLL.ShowMessage(this, "Notification Sent");
                                    }
                                }
                            }
                            //LoadData();
                            //return;
                        }
                    }
                    else
                    {
                        if (status == true)
                        {
                            //BLL.ShowMessage(this, "Selected Leave Approved.");

                        }
                    }
                }
                //}


                //if (string.IsNullOrEmpty(str))
                //{
                //    BLL.ShowMessage(this, "Please Select Employees");
                //    return;
                //}

            }
            if (I_ChkCount == 0)
            {
                BLL.ShowMessage(this, "Please Select Employees");
                return;
            }
            if (status)
            {
                if (status1)
                    BLL.ShowMessage(this, "Selected Leave Approved And Leave Balance Updated And Notification Sent");
                else
                    BLL.ShowMessage(this, "Selected Leave Approved And Leave Balance Updated");
            }

            LoadData();
            RG_LeaveApproval.DataBind();
            return;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Reject_Click(object sender, EventArgs e)
    {
        try
        {
            CheckBox chkBox = new CheckBox();
            Label lblID = new Label();
            Label lblempid = new Label();
            RadTextBox rtxt_rej_reason = new RadTextBox();
            int i = 0;
            Label1.Text = "";
            bool status = false;
            bool status1 = false;
            for (i = 0; i < RG_LeaveApproval.Items.Count; i++)
            {
                chkBox = RG_LeaveApproval.Items[i].FindControl("chk_Choose") as CheckBox;
                lblID = RG_LeaveApproval.Items[i].FindControl("lblLeavetypeid") as Label;
                lblempid = RG_LeaveApproval.Items[i].FindControl("lblempID") as Label;
                rtxt_rej_reason = RG_LeaveApproval.Items[i].FindControl("rtxt_rej_reason") as RadTextBox;
                if (chkBox.Checked)
                {
                    if (Label1.Text == "")
                        Label1.Text = lblID.Text;
                    else
                        Label1.Text = Label1.Text + "," + lblID.Text;
                    if (Convert.ToString(rtxt_rej_reason.Text) == string.Empty)
                    {
                        BLL.ShowMessage(this, "Please Enter Comments For rejection"); return;
                    }
                    _obj_smhr_leaveapp = new SMHR_LEAVEAPP();
                    _obj_smhr_leaveapp.LEAVEAPP_REASON = lblID.Text;
                    _obj_smhr_leaveapp.LEAVEAPP_STATUS = 2;
                    _obj_smhr_leaveapp.LEAVEAPP_APPROVEDBY = Convert.ToInt32(Convert.ToString(Session["EMP_ID"]));
                    _obj_smhr_leaveapp.LEAVEAPP_APPROVEDATE = Convert.ToDateTime(rdp_ApprovalDate.SelectedDate.Value);
                    _obj_smhr_leaveapp.LASTMDFBY = 1;
                    _obj_smhr_leaveapp.LASTMDFDATE = DateTime.Now;
                    _obj_smhr_leaveapp.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_leaveapp.LEAVEAPP_REJECT_REASON = Convert.ToString(rtxt_rej_reason.Text.Replace("'", "''"));
                    _obj_smhr_leaveapp.OPERATION = operation.Check;
                    status = BLL.set_LeaveApp(_obj_smhr_leaveapp);
                    if (status == true)
                    {
                        //BLL.ShowMessage(this, "Selected Leaves Rejected");
                        SMHR_LEAVEAPP _obj_Smhr_LeaveApp = new SMHR_LEAVEAPP();
                        _obj_Smhr_LeaveApp.LEAVEAPP_EMP_ID = Convert.ToInt32(lblempid.Text);
                        _obj_Smhr_LeaveApp.MODE = 4;
                        DataTable dt_mail = BLL.get_EmpLeaveDetails(_obj_Smhr_LeaveApp);
                        if (dt_mail.Rows.Count > 0)
                        {
                            //if (!((dt_mail.Rows[0]["REPORTING_EMP_EMAIL"] != System.DBNull.Value && dt_mail.Rows[0]["REPORTING_EMP_EMAIL"] != string.Empty) || (dt_mail.Rows[0]["EMP_EMAIL"] != System.DBNull.Value && dt_mail.Rows[0]["EMP_EMAIL"] != string.Empty) || (dt_mail.Rows[0]["REPORTING_EMP"] != System.DBNull.Value && dt_mail.Rows[0]["REPORTING_EMP"] != string.Empty)))
                            if (((Convert.ToString(dt_mail.Rows[0]["REPORTING_EMP_EMAIL"]) != string.Empty) && (dt_mail.Rows[0]["REPORTING_EMP_EMAIL"]) != System.DBNull.Value)
                                && ((Convert.ToString(dt_mail.Rows[0]["EMP_EMAIL"]) != string.Empty) && (dt_mail.Rows[0]["EMP_EMAIL"]) != System.DBNull.Value)
                                && ((Convert.ToString(dt_mail.Rows[0]["REPORTING_EMP"]) != string.Empty) && ((dt_mail.Rows[0]["REPORTING_EMP"]) != System.DBNull.Value)))
                            {
                                _obj_Smhr_LeaveApp.MODE = 3;
                                _obj_Smhr_LeaveApp.LEAVEAPP_ID = Convert.ToInt32(lblID.Text);
                                if (BLL.get_Leave_Mail(_obj_Smhr_LeaveApp))
                                {
                                    status1 = true;

                                }
                            }
                        }
                    }
                }
                //else
                //{
                //    i = i + 1;
                //}
            }

            if (string.IsNullOrEmpty(Label1.Text))
            {
                BLL.ShowMessage(this, "Please Select Employees");
                return;
            }
            if (status)
            {
                if (status1)
                    BLL.ShowMessage(this, "Selected Leave Rejected and Notification Sent");
                else
                    BLL.ShowMessage(this, "Selected Leave Rejected");
            }
            LoadData();
            RG_LeaveApproval.DataBind();
            return;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["DASHBOARD"] != null)
            {
                Response.Redirect("~/Security/frm_Dashboradmngr.aspx", false);
            }
            else
            {
                Response.Redirect("~/Masters/Default.aspx", false);
            }
            return;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void RG_LeaveApproval_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadData();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LeaveApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    //public void LoadGrid()
    //{
    //    SMHR_LEAVEAPP _obj_smhr_leaveApp = new SMHR_LEAVEAPP();
    //    _obj_smhr_leaveApp.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //    _obj_smhr_leaveApp.LEAVEAPP_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
    //    _obj_smhr_leaveApp.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
    //    _obj_smhr_leaveApp.OPERATION = operation.Available;
    //    DataTable dt_Details = BLL.get_LeaveApp(_obj_smhr_leaveApp);
    //    Rg_LeaveApp.DataSource = dt_Details;
    //  //  Rg_LeaveApp.DataBind();
    //}
    //protected void Rg_LeaveApp_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    //{
    //    LoadGrid();
    //}
    protected void Lnk_leavedetails0_Click(object sender, EventArgs e)
    {
        // LoadGrid();
    }
}