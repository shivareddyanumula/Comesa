using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SPMS;

public enum operation2
{
    Select,
    Insert,
    check,
    Update,
    Delete,
    CHECK22,
    MODE

}

#region SPMS_MAIN


public class SPMS_MAIN
{
    private operation _OPERATION;
    public operation OPERATION
    {

        get { return (this._OPERATION); }
        set { this._OPERATION = value; }

    }


    private int _CREATEDBY;
    public int CREATEDBY
    {
        get { return this._CREATEDBY; }
        set { this._CREATEDBY = value; }
    }
    private int _LASTMDFBY;
    public int LASTMDFBY
    {
        get { return this._LASTMDFBY; }
        set { this._LASTMDFBY = value; }
    }

    private DateTime _LASTMDFDATE;
    public DateTime LASTMDFDATE
    {
        get { return (this._LASTMDFDATE); }
        set { this._LASTMDFDATE = value; }
    }

    private DateTime _CREATEDDATE;
    public DateTime CREATEDDATE
    {
        get { return this._CREATEDDATE; }
        set { this._CREATEDDATE = value; }
    }
    private int _GSLIFECYCLE;
    public int GSLIFECYCLE
    {
        get { return this._GSLIFECYCLE; }
        set { this._GSLIFECYCLE = value; }
    }
    private int _ORGANISATION_ID;
    public int ORGANISATION_ID
    {
        get { return this._ORGANISATION_ID; }
        set { this._ORGANISATION_ID = value; }
    }
    private int _GS_ID;
    public int GS_ID
    {
        get { return this._GS_ID; }
        set { this._GS_ID = value; }
    }
    private DateTime _STARTDATE;
    public DateTime STARTDATE
    {
        get { return (this._STARTDATE); }
        set { this._STARTDATE = value; }
    }

    private DateTime? _ENDDATE;
    public DateTime? ENDDATE
    {
        get { return (this._ENDDATE); }
        set { this._ENDDATE = value; }
    }

    private int _bUID;

    public int BUID
    {
        get
        {
            return (this._bUID);
        }
        set
        {
            this._bUID = value;
        }
    }
    private int _LOGIN_ID;
    public int LOGIN_ID
    {
        get { return this._LOGIN_ID; }
        set { this._LOGIN_ID = value; }
    }
    private string _EMP_CODE;
    public string EMP_CODE
    {
        get { return this._EMP_CODE; }
        set { this._EMP_CODE = value; }
    }
    private int _EMP_ID;
    public int EMP_ID
    {
        get { return this._EMP_ID; }
        set { this._EMP_ID = value; }
    }

}
#endregion

#region object pages for pms
public class PMS_MAIN
{
    private int _CREATEDBY;
    public int CREATEDBY
    {
        get { return this._CREATEDBY; }
        set { this._CREATEDBY = value; }
    }

    private DateTime _CREATEDDATE;
    public DateTime CREATEDDATE
    {
        get { return this._CREATEDDATE; }
        set { this._CREATEDDATE = value; }
    }

    private int _LASTMDFBY;
    public int LASTMDFBY
    {
        get { return this._LASTMDFBY; }
        set { this._LASTMDFBY = value; }
    }

    private DateTime _LASTMDFDATE;
    public DateTime LASTMDFDATE
    {
        get { return (this._LASTMDFDATE); }
        set { this._LASTMDFDATE = value; }
    }


    private bool? _ISDELETED;
    public bool? ISDELETED
    {
        get { return (this._ISDELETED); }
        set { this._ISDELETED = value; }
    }

    private operation _OPERATION;
    public operation OPERATION
    {
        get { return (this._OPERATION); }
        set { this._OPERATION = value; }
    }


    private DateTime? _STARTDATE;
    public DateTime? STARTDATE
    {
        get { return (this._STARTDATE); }
        set { this._STARTDATE = value; }
    }

    private DateTime? _ENDDATE;
    public DateTime? ENDDATE
    {
        get { return (this._ENDDATE); }
        set { this._ENDDATE = value; }
    }

    private int _BUID;

    public int BUID
    {
        get { return (this._BUID); }
        set { this._BUID = value; }
    }

    private int _LOGIN_ID;

    public int LOGIN_ID
    {
        get { return (this._LOGIN_ID); }
        set { this._LOGIN_ID = value; }
    }
    private int _APPCYCLE;

    public int APPCYCLE
    {
        get { return (this._APPCYCLE); }
        set { this._APPCYCLE = value; }
    }

    private int _EMP_ID;

    public int EMP_ID
    {
        get { return (this._EMP_ID); }
        set { this._EMP_ID = value; }
    }
}

#endregion

#region PRIMARY EMPLOYEE LIST
public class pms_primary : PMS_MAIN
{
    private string _PMS_MANAGERNAME;
    public string PMS_MANAGERNAME
    {
        get { return (this._PMS_MANAGERNAME); }
        set { this._PMS_MANAGERNAME = value; }
    }
   
    private string _PMS_TASKNAME;
    public string PMS_TASKNAME
    {
        get { return (this._PMS_TASKNAME); }
        set { this._PMS_TASKNAME = value; }
    }

    private string _PMS_TASKID;
    public string PMS_TASKID
    {
        get { return (this._PMS_TASKID); }
        set { this._PMS_TASKID = value; }
    }

    private string _PMS_TASKDESC;
    public string PMS_TASKDESC
    {
        get { return (this._PMS_TASKDESC); }
        set { this._PMS_TASKDESC = value; }
    }
    private DateTime? _PMS_ASSIGNEDTIME;
    public DateTime? PMS_ASSIGNEDTIME
    {
        get { return (this._PMS_ASSIGNEDTIME); }
        set { this._PMS_ASSIGNEDTIME = value; }
    }
    private DateTime? _PMS_ESTIMATEDTIME;
    public DateTime? PMS_ESTIMATEDTIME
    {
        get { return (this._PMS_ESTIMATEDTIME); }
        set { this._PMS_ESTIMATEDTIME=value; }
    }
    private string _PMS_COMMENTS;
    public string PMS_COMMENTS
    {
        get { return (this._PMS_COMMENTS); }
        set { this._PMS_COMMENTS = value; }
    }
    private int _PMS_MODE;
    public int PMS_MODE
    {
        get { return (this._PMS_MODE); }
        set { this._PMS_MODE = value; }
    }
    private int _PMS_TASKDETAILSMANAGERSERVICEID;
    public int PMS_TASKDETAILSMANAGERSERVICEID
    {
        get { return (this._PMS_TASKDETAILSMANAGERSERVICEID); }
        set { this._PMS_TASKDETAILSMANAGERSERVICEID = value; }
    }
    private int _PMS_TASKDETAILS_EMP_ID;
    public int PMS_TASKDETAILS_EMP_ID
    {
        get { return (this._PMS_TASKDETAILS_EMP_ID); }
        set { this._PMS_TASKDETAILS_EMP_ID = value; }
    }

}
#endregion

#region PMS_KEYRESULTAREA
public class pms_keyresultarea : PMS_MAIN
{

    private string _KRA_EMPLOYEENAME;
    public string KRA_EMPLOYEENAME
    {
        get { return (this._KRA_EMPLOYEENAME); }
        set { this._KRA_EMPLOYEENAME = value; }
    }
    private string _KRA_DESCRIPTION;
    public string KRA_DESCRIPTION
        {
            get { return (this._KRA_DESCRIPTION); }
            set { this._KRA_DESCRIPTION = value; }
        }
        private int _KRA_ID;
        public int KRA_ID
        {
            get { return (this._KRA_ID); }
            set { this._KRA_ID = value; }
        }
        private string _KRA_CODE;
        public string KRA_CODE
        {
            get { return (this._KRA_CODE); }
            set { this._KRA_CODE = value; }
        }
        private int _KRA_EMPLOYEEID;
        public int KRA_EMPLOYEEID
        {
            get { return (this._KRA_EMPLOYEEID); }
            set { this._KRA_EMPLOYEEID = value; }
        }
        private int _KRA_MANAGERSERVICEID;
        public int KRA_MANAGERSERVICEID
        {
            get { return (this._KRA_MANAGERSERVICEID); }
            set { this._KRA_MANAGERSERVICEID = value; }
        }
        private int _KRA_MODE;
        public int KRA_MODE
        {
            get { return (this._KRA_MODE); }
            set { this._KRA_MODE = value; }
        }
        private string _KRA_INDICATOR;
        public string KRA_INDICATOR
        {
            get { return (this._KRA_INDICATOR); }
            set { this._KRA_INDICATOR = value; }
        }

        public pms_keyresultarea(int ID)
        {
            KRA_ID = ID;
        }
        public pms_keyresultarea()
        {

        }
       
    
}
#endregion

#region PMS_EMPLOYEEPMSMODE
public class pms_employeepmsmode : PMS_MAIN
{
    private int _PMS_ID;
    public int PMS_ID
    {
        get { return (this._PMS_ID); }
        set { this._PMS_ID = value; }
    }
    private bool _PMS_APPRAISEE;
    public bool PMS_APPRAISEE
    {
        get { return (this._PMS_APPRAISEE); }
        set { this._PMS_APPRAISEE = value; }
    }
    private bool _PMS_APPRAISER;
    public bool PMS_APPRAISER
    {
        get { return (this._PMS_APPRAISER); }
        set { this._PMS_APPRAISER = value; }
    }
    private bool _PMS_REVIEWER;
    public bool PMS_REVIEWER
    {
        get { return (this._PMS_REVIEWER); }
        set { this._PMS_REVIEWER = value; }
    }
    private int _PMS_MODE;
    public int PMS_MODE
    {
        get { return (this._PMS_MODE); }
        set { this._PMS_MODE = value; }
    }

    private string _PMS_EMPLOYEENAME;
    public string PMS_EMPLOYEENAME
    {
        get { return (this._PMS_EMPLOYEENAME); }
        set { this._PMS_EMPLOYEENAME = value; }
    }

    private int _PMS_EMPLOYEENUMBER;
    public int PMS_EMPLOYEENUMBE
    {
        get { return (this._PMS_EMPLOYEENUMBER); }
        set { this._PMS_EMPLOYEENUMBER = value; }
    }
    private int _PMS_BUSINESSUNIT;
    public int PMS_BUSINESSUNIT
    {
        get { return (this.PMS_BUSINESSUNIT); }
        set { this.PMS_BUSINESSUNIT = value; }
    }

   

}
#endregion

#region pms_ASSIGNINGROLES
public class pms_ASSIGNINGROLES : PMS_MAIN
{
    private int _ASSGN_ROLE_ID;
    public int ASSGN_ROLE_ID
    {
        get { return (this._ASSGN_ROLE_ID); }
        set { this._ASSGN_ROLE_ID = value; }
    }
    private int _ASSGN_BU_ID;
    public int ASSGN_BU_ID
    {
        get { return (this._ASSGN_BU_ID); }
        set { this._ASSGN_BU_ID = value; }
    }
    private int _ASSGN_EMP_ID;
    public int ASSGN_EMP_ID
    {
        get { return (this._ASSGN_EMP_ID); }
        set { this._ASSGN_EMP_ID = value; }
    }
    private int _ASSGN_ROLE;
    public int ASSGN_ROLE
    {
        get { return (this._ASSGN_ROLE); }
        set { this._ASSGN_ROLE = value; }
    }
    private int _PMS_MODE;
    public int PMS_MODE
    {
        get { return (this._PMS_MODE); }
        set { this._PMS_MODE = value; }
    }

    private int _pms_did;
    public int pms_did
    {
        get { return (this._pms_did); }
        set { this._pms_did = value; }
    }
}
    
    #endregion

#region PMS_BINDROLES
public class PMS_BINDROLES : PMS_MAIN
{
        private int _role_id;
        public int role_id
        {
            get { return (this._role_id); }
            set { this._role_id = value; }
        }
        private string _ROLE_NAME;
        public string ROLE_NAME
        {
            get { return (this._ROLE_NAME); }
            set { this._ROLE_NAME = value; }
        }
        private string _ROLE_DESCRIPTION;
        public string ROLE_DESCRIPTION
        {
            get { return (this._ROLE_DESCRIPTION); }
            set { this._ROLE_DESCRIPTION = value; }
        }
        private string _ROLE_COMMENTS;
        public string ROLE_COMMENTS
        {
            get { return (this._ROLE_COMMENTS); }
            set { this._ROLE_COMMENTS = value; }
        }
        private int _MODE;
        public int MODE
        {
            get { return (this._MODE); }
            set { this._MODE = value; }
        }
        private int _ROLES_KRA_ID;
        public int ROLES_KRA_ID
        {
            get { return (this._MODE); }
            set { this._ROLES_KRA_ID = value; }
        }

}
#endregion

#region Task Management
public class pms_TaskManagement : PMS_MAIN
{
    private string _PMS_EmployeeName;
    public string PMS_EmployeeName
    {
        get { return (this._PMS_EmployeeName); }
        set { this._PMS_EmployeeName = value; }
    }
    private string _PMS_TASKNAME;
    public string PMS_TASKNAME
    {
        get { return (this._PMS_TASKNAME); }
        set { this._PMS_TASKNAME = value; }
    }
    private string _PMS_TASKDESC;
    public string PMS_TASKDESC
    {
        get { return (this._PMS_TASKDESC); }
        set { this._PMS_TASKDESC = value; }
    }
    private int _PMS_TASKCODE;
    public int PMS_TASKCODE
    {
        get { return (this._PMS_TASKCODE); }
        set { this._PMS_TASKCODE = value; }
    }
    private string _PMS_ASSIGNEDBY;
    public string PMS_ASSIGNEDBY
    {
        get { return (this._PMS_ASSIGNEDBY); }
        set { this._PMS_ASSIGNEDBY = value; }
    }
    private string _PMS_COMMENTS;
    public string PMS_COMMENTS
    {
        get { return (this._PMS_COMMENTS); }
        set { this._PMS_COMMENTS = value; }
    }  
    private string _PMS_SEVERITY;
    public string PMS_SEVERITY
    {
        get { return (this._PMS_SEVERITY); }
        set { this._PMS_SEVERITY = value; }
    }
    private string _PMS_STATUS;
    public string PMS_STATUS
    {
        get { return (this._PMS_STATUS); }
        set { this._PMS_STATUS = value; }
    }
    private int _PMS_MODE;
    public int PMS_MODE
    {
        get { return (this._PMS_MODE); }
        set { this._PMS_MODE = value; }
    }
    private DateTime? _PMS_ESTIMATEDTIME;
    public DateTime? PMS_ESTIMATEDTIME
    {
        get { return (this._PMS_ESTIMATEDTIME); }
        set { this._PMS_ESTIMATEDTIME = value; }
    }
    private DateTime? _PMS_ASSIGNEDDATE;
    public DateTime? PMS_ASSIGNEDDATE
    {
        get { return (this._PMS_ASSIGNEDDATE); }
        set { this._PMS_ASSIGNEDDATE = value; }
    }
    private int _PMS_TASKDETAILS_ID;
    public int PMS_TASKDETAILS_ID
    {
        get { return (this._PMS_TASKDETAILS_ID); }
        set { this._PMS_TASKDETAILS_ID = value; }
    }
    private int _PMS_TASKDETAILSMANAGERSERVICEID;
    public int PMS_TASKDETAILSMANAGERSERVICEID
    {
        get { return (this._PMS_TASKDETAILSMANAGERSERVICEID); }
        set { this._PMS_TASKDETAILSMANAGERSERVICEID = value; }
    }
    private int _PMS_TASKDETAILS_EMP_ID;
    public int PMS_TASKDETAILS_EMP_ID
    {
        get { return (this._PMS_TASKDETAILS_EMP_ID); }
        set { this._PMS_TASKDETAILS_EMP_ID = value; }
    }


   
}
#endregion

#region PMS_KRAFORM
public class pms_kraform : PMS_MAIN
{
    private int _KRA_ID;
    public int KRA_ID
    {
        get { return (this._KRA_ID); }
        set { this._KRA_ID = value; }
    }
    private string _KRA_NAME;
    public string KRA_NAME
    {
        get { return (this._KRA_NAME); }
        set { this._KRA_NAME = value; }
    }
    private int _BU_ID;
    public int BU_ID
    {
        get { return (this._BU_ID); }
        set { this._BU_ID = value; }
    }

    private int _KRA_ORG_ID;
    public int KRA_ORG_ID
    {
        get { return (this._KRA_ORG_ID); }
        set { this._KRA_ORG_ID = value; }
    }
    private string _KRA_DESCRIPTION;
    public string KRA_DESCRIPTION
    {
        get { return (this._KRA_DESCRIPTION); }
        set { this._KRA_DESCRIPTION = value; }
    }
    private string _KRA_MEASURE;
    public string KRA_MEASURE
    {
        get { return (this._KRA_MEASURE); }
        set { this._KRA_MEASURE = value; }
    }
    private int _KRA_ORGANISATION_ID;
    public int KRA_ORGANISATION_ID
    {
        get { return (this._KRA_ORGANISATION_ID); }
        set { this._KRA_ORGANISATION_ID = value; }
    }
    private int _KRA_MODE;
    public int KRA_MODE
    {
        get { return (this._KRA_MODE); }
        set { this._KRA_MODE = value; }
    }

    private int _KRA_WEIGHTAGE;
    public int KRA_WEIGHTAGE
    {
        get { return (this._KRA_WEIGHTAGE); }
        set { this._KRA_WEIGHTAGE = value; }
    }

    private int _KRA_TARGET;
    public int KRA_TARGET
    {
        get { return (this._KRA_TARGET); }
        set { this._KRA_TARGET = value; }
    }
    private DateTime _KRA_TIMELINES;
    public DateTime KRA_TIMELINES
    {
        get { return (this._KRA_TIMELINES); }
        set { this._KRA_TIMELINES = value; }
    }
    private string _KRA_TARGET_ACHEIVED;
    public string KRA_TARGET_ACHEIVED
    {
        get { return (this._KRA_TARGET_ACHEIVED); }
        set { this._KRA_TARGET_ACHEIVED = value; }
    }
    private int _KRA_STATUS;
    public int KRA_STATUS
    {
        get { return (this._KRA_STATUS); }
        set { this._KRA_STATUS = value; }
    }
    private string _KRA_KRAID;
    public string KRA_KRAID
    {
        get { return (this._KRA_KRAID); }
        set { this._KRA_KRAID = value; }
    }
}
#endregion


#region PMS_CMP
public class PMS_CMP : PMS_MAIN
{
    private int _CMP_ID;
    public int CMP_ID
    {
        get { return (this._CMP_ID); }
        set { this._CMP_ID = value; }
    }
    private string _CMP_NAME;
    public string CMP_NAME
    {
        get { return (this._CMP_NAME); }
        set { this._CMP_NAME = value; }
    }
    private int _CMP_BU_ID;
    public int CMP_BU_ID
    {
        get { return (this._CMP_BU_ID); }
        set { this._CMP_BU_ID = value; }
    }

    private int _CMP_ORG_ID;
    public int CMP_ORG_ID
    {
        get { return (this._CMP_ORG_ID); }
        set { this._CMP_ORG_ID = value; }
    }
    private string _CMP_DESCRIPTION;
    public string CMP_DESCRIPTION
    {
        get { return (this._CMP_DESCRIPTION); }
        set { this._CMP_DESCRIPTION = value; }
    }

    private int _CMP_MODE;
    public int CMP_MODE
    {
        get { return (this._CMP_MODE); }
        set { this._CMP_MODE = value; }
    }

    private int _CMP_STATUS;
    public int CMP_STATUS
    {
        get { return (this._CMP_STATUS); }
        set { this._CMP_STATUS = value; }
    }
}
#endregion

#region PMS_VALS
public class PMS_VALUES : PMS_MAIN
{
    private int _VAL_ID;
    public int VAL_ID
    {
        get { return (this._VAL_ID); }
        set { this._VAL_ID = value; }
    }
    private string _VAL_NAME;
    public string VAL_NAME
    {
        get { return (this._VAL_NAME); }
        set { this._VAL_NAME = value; }
    }
    private int _VAL_BU_ID;
    public int VAL_BU_ID
    {
        get { return (this._VAL_BU_ID); }
        set { this._VAL_BU_ID = value; }
    }

    private int _VAL_ORG_ID;
    public int VAL_ORG_ID
    {
        get { return (this._VAL_ORG_ID); }
        set { this._VAL_ORG_ID = value; }
    }
    private string _VAL_DESCRIPTION;
    public string VAL_DESCRIPTION
    {
        get { return (this._VAL_DESCRIPTION); }
        set { this._VAL_DESCRIPTION = value; }
    }

    private int _VAL_MODE;
    public int VAL_MODE
    {
        get { return (this._VAL_MODE); }
        set { this._VAL_MODE = value; }
    }

    private bool _VAL_STATUS;
    public bool VAL_STATUS
    {
        get { return (this._VAL_STATUS); }
        set { this._VAL_STATUS = value; }
    }
}
#endregion

#region PMS_IDPSCREEN
public class pms_IDPSCREEN : PMS_MAIN
{
    private int _IDP_ID;
    public int IDP_ID
    {
        get { return (this._IDP_ID); }
        set { this._IDP_ID = value; }
    }
    private int _IDP_EMP_ID;
    public int IDP_EMP_ID
    {
        get { return (this._IDP_EMP_ID); }
        set { this._IDP_EMP_ID = value; }
    }
    private int _IDP_BU_ID;
    public int IDP_BU_ID
    {
        get { return (this._IDP_BU_ID); }
        set { this._IDP_BU_ID = value; }
    }
    private int _IDP_APPRAISALCYCLE;
    public int IDP_APPRAISALCYCLE
    {
        get { return (this._IDP_APPRAISALCYCLE); }
        set { this._IDP_APPRAISALCYCLE = value; }
    }

    private string _IDP_NAME;
    public string IDP_NAME
    {
        get { return (this._IDP_NAME); }
        set { this._IDP_NAME = value; }
    }
    private string _IDP_DESCRIPTION;
    public string IDP_DESCRIPTION
    {
        get { return (this._IDP_DESCRIPTION); }
        set { this._IDP_DESCRIPTION = value; }
    }
    private DateTime? _IDP_DATE;
    public DateTime? IDP_DATE
    {
        get { return (this._IDP_DATE); }
        set { this._IDP_DATE = value; }
    }
    private string _IDP_COMMENTS;
    public string IDP_COMMENTS
    {
        get { return (this._IDP_COMMENTS); }
        set { this._IDP_COMMENTS = value; }
    }
    private int _IDP_ORGANISATION_ID;
    public int IDP_ORGANISATION_ID
    {
        get { return (this._IDP_ORGANISATION_ID); }
        set { this._IDP_ORGANISATION_ID = value; }
    }
    private int _IDP_MODE;
    public int IDP_MODE
    {
        get { return (this._IDP_MODE); }
        set { this._IDP_MODE = value; }
    }
    private DateTime? _IDP_STARTDATE;
    public DateTime? IDP_STARTDATE
    {
        get { return (this._IDP_STARTDATE); }
        set { this._IDP_STARTDATE = value; }
    }
    private DateTime? _IDP_ENDDATE;
    public DateTime? IDP_ENDDATE
    {
        get { return (this._IDP_ENDDATE); }
        set { this._IDP_ENDDATE = value; }
    }
    private int _IDP_STATUS;
    public int IDP_STATUS
    {
        get { return (this._IDP_STATUS); }
        set { this._IDP_STATUS = value; }
    }







}
#endregion


#region SMHR_EMPLOYEE1
public class SMHR_EMPLOYEE1 : PMS_MAIN
{

    private string _EMP_ID;
    public string EMP_ID
    {
        get { return (this._EMP_ID); }
        set { this._EMP_ID = value; }
    }

    private string _emp_code;
    public string emp_code
    {
        get { return (this._emp_code); }
        set { this._emp_code = value; }
    }

    private string _DATE_STRING;
    public string DATE_STRING
    {
        get { return (this._DATE_STRING); }
        set { this._DATE_STRING = value; }
    }

    private string _ATTENDANCE_STATUS1;
    public string ATTENDANCE_STATUS1
    {
        get { return (this._ATTENDANCE_STATUS1); }
        set { this._ATTENDANCE_STATUS1 = value; }
    }
    private int _BU_ID;
    public int BU_ID
    {
        get { return (this._BU_ID); }
        set { this._BU_ID = value; }
    }
   
    private DateTime _DATE;
    public DateTime DATE
    {
        get { return (this._DATE); }
        set { this._DATE = value; }
    }

    private int _MODE;
    public int MODE
    {
        get { return (this._MODE); }
        set { this._MODE = value; }
    }

    private int _LASTMDFBY;
    public int LASTMDFBY
    {
        get { return (this._LASTMDFBY); }
        set { this._LASTMDFBY = value; }
    }  
    
    private int _ORGID;
    public int ORGID
    {
        get { return this._ORGID; }
        set { this._ORGID = value; }
    }
    private int _finperiod;
    public int finperiod
    {
        get {return this._finperiod; }
        set { this._finperiod = value; }
    }

    private string  _DATE1;
    public string DATE1
    {
        get { return (this._DATE1); }
        set { this._DATE1 = value; }
    }
  
}
#endregion




#region Goalsettings
public class PMS_GoalSettings : PMS_MAIN
{
    private int _GS_ID;
    public int GS_ID
    {
        get { return (this._GS_ID); }
        set { this._GS_ID = value; }
    }

    private int _GS_EMP_ID;
    public int GS_EMP_ID
    {
        get { return (this._GS_EMP_ID); }
        set { this._GS_EMP_ID = value; }
    }

    private string _GS_JOB_DESCRIPTION;
    public string GS_JOB_DESCRIPTION
    {
        get { return (this._GS_JOB_DESCRIPTION); }
        set { this._GS_JOB_DESCRIPTION = value; }
    }

    private string _GS_APPRAISAL_CYCLE;
    public string GS_APPRAISAL_CYCLE
    {
        get { return (this._GS_APPRAISAL_CYCLE); }
        set { this._GS_APPRAISAL_CYCLE = value; }
    }

    private int _GS_ORGANISATION_ID;
    public int GS_ORGANISATION_ID
    {
        get { return (this._GS_ORGANISATION_ID); }
        set { this._GS_ORGANISATION_ID = value; }
    }

    private int _GS_MODE;
    public int GS_MODE
    {
        get { return (this._GS_MODE); }
        set { this._GS_MODE = value; }
    }

    private int _GS_STATUS;
    public int GS_STATUS
    {
        get { return (this._GS_STATUS); }
        set { this._GS_STATUS = value; }
    }

    private int _GS_ROLENAME;
    public int GS_ROLENAME
    {
        get { return (this._GS_ROLENAME); }
        set { this._GS_ROLENAME = value; }
    }
    private int _GS_ROLEKRA_ID;
    public int GS_ROLEKRA_ID
    {
        get { return (this._GS_ROLEKRA_ID); }
        set { this._GS_ROLEKRA_ID = value; }
    }
    private string _GS_PROJECT;
    public string GS_PROJECT
    {
        get { return (this._GS_PROJECT); }
        set { this._GS_PROJECT = value; }
    }

    private int _eMPID;

    public int EMPID
    {
        get
        {
            return (this._eMPID);
        }
        set
        {
            this._eMPID = value;
        }
    }


    


}
#endregion

#region PMS_GOALSETTING_DETAIL
public class PMS_GoalSettings_Details: PMS_MAIN
{
    private int _GSDTL_ID;
    public int GSDTL_ID
    {
        get { return (this._GSDTL_ID); }
        set { this._GSDTL_ID = value; }
    }
    private int _GSDTL_GS_ID;
    public int GSDTL_GS_ID
    {
        get { return (this._GSDTL_GS_ID); }
        set { this._GSDTL_GS_ID = value; }
    }
    private int _GSDTL_ORG_ID;
    public int GSDTL_ORG_ID
    {
        get { return (this._GSDTL_ORG_ID); }
        set { this._GSDTL_ORG_ID = value; }
    }
    private string _GSDTL_NAME;
    public string GSDTL_NAME
    {
        get { return (this._GSDTL_NAME); }
        set { this._GSDTL_NAME = value; }
    }
    private string _GSDTL_DESCRIPTION;
    public string GSDTL_DESCRIPTION
    {
        get { return (this._GSDTL_DESCRIPTION); }
        set { this._GSDTL_DESCRIPTION = value; }
    }
    private string _GSDTL_MEASURE;
    public string GSDTL_MEASURE
    {
        get { return (this._GSDTL_MEASURE); }
        set { this._GSDTL_MEASURE = value; }
    }
    private string _GSDTL_TARGET;
    public string GSDTL_TARGET
    {
        get { return (this._GSDTL_TARGET); }
        set { this._GSDTL_TARGET = value; }


    }
    private DateTime _GSDTL_TIMELINES;
    public DateTime GSDTL_TIMELINES
    {
        get { return (this._GSDTL_TIMELINES); }
        set { this._GSDTL_TIMELINES = value; }
    }
    private string _GSDTL_TARGET_ACHEIVED;
    public string GSDTL_TARGET_ACHEIVED
    {
        get { return (this._GSDTL_TARGET_ACHEIVED); }
        set { this._GSDTL_TARGET_ACHEIVED = value; }
    }
    private int _GSDTL_WEIGHTAGE;
    public int GSDTL_WEIGHTAGE
    {
        get { return (this._GSDTL_WEIGHTAGE); }
        set { this._GSDTL_WEIGHTAGE = value; }
    }
    private DateTime? _GSDTL_DATE;
    public DateTime? GSDTL_DATE
    {
        get { return (this._GSDTL_DATE); }
        set { this._GSDTL_DATE = value; }
    }
    private int _GS_DETAILS_MODE;
    public int GS_DETAILS_MODE
    {
        get { return (this._GS_DETAILS_MODE); }
        set { this._GS_DETAILS_MODE = value; }
    }
    private int _GSDTL_CMP_ID;
    public int GSDTL_CMP_ID
    {
        get { return (this._GSDTL_CMP_ID); }
        set { this._GSDTL_CMP_ID = value; }
    }

 
}

#endregion

#region SPMS_ROLES
public class SPMS_ROLES : PMS_MAIN
{
    public SPMS_ROLES(int __ROLES_ID)
    {
        this._ROLES_ID = __ROLES_ID;
    }

    public SPMS_ROLES()
    {
    }
    private int _ROLES_ID;
    public int ROLES_ID
    {
        get { return (this._ROLES_ID); }
        set { this._ROLES_ID = value; }
    }


    private int _ROLES_BU_ID;
    public int ROLES_BU_ID
    {
        get { return (this._ROLES_BU_ID); }
        set { this._ROLES_BU_ID = value; }
    }

    private int _ROLES_EMP_ID;
    public int ROLES_EMP_ID
    {
        get { return (this._ROLES_EMP_ID); }
        set { this._ROLES_EMP_ID = value; }
    }

    private string _ROLES_JOB;
    public string ROLES_JOB
    {
        get { return (this._ROLES_JOB); }
        set { this._ROLES_JOB = value; }
    }

    private string _ROLES_POSITION;
    public string ROLES_POSITION
    {
        get { return (this._ROLES_POSITION); }
        set { this._ROLES_POSITION = value; }
    }

    private string _ROLES_NAME;
    public string ROLES_NAME
    {
        get { return (this._ROLES_NAME); }
        set { this._ROLES_NAME = value; }
    }
    private string _ROLES_DESCRIPTION;
    public string ROLES_DESCRIPTION
    {
        get { return (this._ROLES_DESCRIPTION); }
        set { this._ROLES_DESCRIPTION = value; }
    }
   
    private int _ROLES_KRA_ID;
    public int ROLES_KRA_ID
    {
        get { return (this._ROLES_KRA_ID); }
        set { this._ROLES_KRA_ID = value; }
    }

  
    private int _ROLES_CREATEDBY;
    public int ROLES_CREATEDBY
    {
        get { return (this._ROLES_CREATEDBY); }
        set { this._ROLES_CREATEDBY = value; }
    }

    private DateTime _ROLES_CREATEDDATE;
    public DateTime ROLES_CREATEDDATE
    {
        get { return (this._ROLES_CREATEDDATE); }
        set { this._ROLES_CREATEDDATE = value; }
    }

    private int _ROLES_LASTMDFBY;
    public int ROLES_LASTMDFBY
    {
        get { return (this._ROLES_LASTMDFBY); }
        set { this._ROLES_LASTMDFBY = value; }
    }

    private DateTime _ROLES_LASTMDFDATE;
    public DateTime ROLES_LASTMDFDATE
    {
        get { return (this._ROLES_LASTMDFDATE); }
        set { this._ROLES_LASTMDFDATE = value; }
    }
    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }
    private int _ROLES_ORG_ID;
    public int ROLES_ORG_ID
    {
        get { return (this._ROLES_ORG_ID); }
        set { this._ROLES_ORG_ID = value; }
    }
    private string _ROLES_ROLEID;
    public string ROLES_ROLEID
    {
        get { return (this._ROLES_ROLEID); }
        set { this._ROLES_ROLEID = value; }
    }

    
}
#endregion

#region PMS_GOALKRA
public class PMS_GOALKRA
{
    private int _GOALKRA_MODE;
    public int GOALKRA_MODE
    {
        get { return (this._GOALKRA_MODE); }
        set { this._GOALKRA_MODE = value; }
    }
    private int _GOALKRA_ID;
    public int GOALKRA_ID
    {
        get { return (this._GOALKRA_ID); }
        set { this._GOALKRA_ID = value; }
    }
    private int _GSDTL_GS_ID;
    public int GSDTL_GS_ID
    {
        get { return (this._GSDTL_GS_ID); }
        set { this._GSDTL_GS_ID = value; }
    }
    private string _GOALKRA_NAME;
    public string GOALKRA_NAME
    {
        get { return (this._GOALKRA_NAME); }
        set { this._GOALKRA_NAME = value; }
    }
    private string _GOALKRA_DESCRIPTION;
    public string GOALKRA_DESCRIPTION
    {
        get { return (this._GOALKRA_DESCRIPTION); }
        set { this._GOALKRA_DESCRIPTION = value; }
    }



}
#endregion

#region GOALSETTING_GOALKRA_DETAILS
public class GOALSETTING_GOALKRA_DETAILS : PMS_MAIN
{
    private int _GS_KRA_ID;
    public int GS_KRA_ID
    {
        get { return (this._GS_KRA_ID); }
        set { this._GS_KRA_ID = value; }

    }
    private int _GS_KRA_GSDTL_ID;
    public int GS_KRA_GSDTL_ID
    {
        get { return (this._GS_KRA_GSDTL_ID); }
        set { this._GS_KRA_GSDTL_ID = value; }

    }
    private int _GS_KRA_KRA_ID;
    public int GS_KRA_KRA_ID
    {
        get { return (this._GS_KRA_KRA_ID); }
        set { this._GS_KRA_KRA_ID = value; }

    }
    private int _GS_KRA_ORG_ID;
    public int GS_KRA_ORG_ID
    {
        get { return (this._GS_KRA_ORG_ID); }
        set { this._GS_KRA_ORG_ID = value; }

    }
    private int _MODE;
    public int MODE
    {
        get { return (this._MODE); }
        set { this._MODE = value; }
    }
    private string _GS_KRA_NAME;
    public string GS_KRA_NAME
    {
        get { return (this._GS_KRA_NAME); }
        set { this._GS_KRA_NAME = value; }
    }
    private string _GS_KRA_DESCRIPTION;
    public string GS_KRA_DESCRIPTION
    {
        get { return (this._GS_KRA_DESCRIPTION); }
        set { this._GS_KRA_DESCRIPTION = value; }
    }
    
    private bool _GS_KRA_CHECKED;
    public bool GS_KRA_CHECKED
    {
        get { return (this._GS_KRA_CHECKED); }
        set { this._GS_KRA_CHECKED = value; }
    }
    private string _GS_KRA_MEASURE;
    public string GS_KRA_MEASURE
    {
        get { return (this._GS_KRA_MEASURE); }
        set { this._GS_KRA_MEASURE = value; }
    }
    private int _GS_KRA_WEIGHTAGE;
    public int GS_KRA_WEIGHTAGE
    {
        get { return (this._GS_KRA_WEIGHTAGE); }
        set { this._GS_KRA_WEIGHTAGE = value; }
    }
    private DateTime _GS_KRA_DATE;
    public DateTime GS_KRA_DATE
    {
        get { return (this._GS_KRA_DATE); }
        set { this._GS_KRA_DATE = value; }
    }
    private int _GS_KRA_GS_ID;
    public int GS_KRA_GS_ID
    {
        get { return (this._GS_KRA_GS_ID); }
        set { this._GS_KRA_GS_ID = value;}

    
    }
    private string _GS_KRA_TARGET;
    public string GS_KRA_TARGET
    {
        get { return (this._GS_KRA_TARGET); }
        set { this._GS_KRA_TARGET = value; }


    }
    private DateTime _GS_KRA_TIMELINES;
    public DateTime GS_KRA_TIMELINES
    {
        get { return (this._GS_KRA_TIMELINES); }
        set { this._GS_KRA_TIMELINES = value; }
    }
    private string _GS_KRA_TARGET_ACHEIVED;
    public string GS_KRA_TARGET_ACHEIVED
    {
        get { return (this._GS_KRA_TARGET_ACHEIVED); }
        set { this._GS_KRA_TARGET_ACHEIVED = value; }
    }

    private int _GS_KRA_OBJ_ID;
    public int GS_KRA_OBJ_ID
    {
        get { return (this._GS_KRA_OBJ_ID); }
        set { this._GS_KRA_OBJ_ID = value; }

    }
}
#endregion

#region GOALSETTING_IDP_DETAILS
public class GOALSETTING_IDP_DETAILS : PMS_MAIN
{
    private int _GS_IDP_ID;
    public int GS_IDP_ID
    {
        get { return (this._GS_IDP_ID); }
        set { this._GS_IDP_ID = value; }

    }
    private int _GS_IDP_GSDTL_ID;
    public int GS_IDP_GSDTL_ID
    {
        get { return (this._GS_IDP_GSDTL_ID); }
        set { this._GS_IDP_GSDTL_ID = value; }

    }
    private int _GS_IDP_IDP_ID;
    public int GS_IDP_IDP_ID
    {
        get { return (this._GS_IDP_IDP_ID); }
        set { this._GS_IDP_IDP_ID = value; }

    }
    private int _GS_IDP_ORG_ID;
    public int GS_IDP_ORG_ID
    {
        get { return (this._GS_IDP_ORG_ID); }
        set { this._GS_IDP_ORG_ID = value; }

    }
    private int _MODE;
    public int MODE
    {
        get { return (this._MODE); }
        set { this._MODE = value; }
    }
    private string _GS_IDP_NAME;
    public string GS_IDP_NAME
    {
        get { return (this._GS_IDP_NAME); }
        set { this._GS_IDP_NAME = value; }
    }
    private string _GS_IDP_DESCRIPTION;
    public string GS_IDP_DESCRIPTION
    {
        get { return (this._GS_IDP_DESCRIPTION); }
        set { this._GS_IDP_DESCRIPTION = value; }
    }

    private bool _GS_IDP_CHECKED;
    public bool GS_IDP_CHECKED
    {
        get { return (this._GS_IDP_CHECKED); }
        set { this._GS_IDP_CHECKED = value; }
    }
    private string _GS_IDP_MEASURE;
    public string GS_IDP_MEASURE
    {
        get { return (this._GS_IDP_MEASURE); }
        set { this._GS_IDP_MEASURE = value; }
    }
    private int _GS_IDP_WEIGHTAGE;
    public int GS_IDP_WEIGHTAGE
    {
        get { return (this._GS_IDP_WEIGHTAGE); }
        set { this._GS_IDP_WEIGHTAGE = value; }
    }
    private DateTime _GS_IDP_DATE;
    public DateTime GS_IDP_DATE
    {
        get { return (this._GS_IDP_DATE); }
        set { this._GS_IDP_DATE = value; }
    }
    private int _GS_IDP_GS_ID;
    public int GS_IDP_GS_ID
    {
        get { return (this._GS_IDP_GS_ID); }
        set { this._GS_IDP_GS_ID = value; }


    }
    private string _GS_IDP_TARGET;
    public string GS_IDP_TARGET
    {
        get { return (this._GS_IDP_TARGET); }
        set { this._GS_IDP_TARGET = value; }


    }
    private DateTime _GS_IDP_TIMELINES;
    public DateTime GS_IDP_TIMELINES
    {
        get { return (this._GS_IDP_TIMELINES); }
        set { this._GS_IDP_TIMELINES = value; }
    }
    private string _GS_IDP_TARGET_ACHEIVED;
    public string GS_IDP_TARGET_ACHEIVED
    {
        get { return (this._GS_IDP_TARGET_ACHEIVED); }
        set { this._GS_IDP_TARGET_ACHEIVED = value; }
    }
}
#endregion
#region SPMS_ROLE
public class SPMS_ROLE : SPMS_MAIN
{
    public SPMS_ROLE(int __ROLE_ID)
    {
        this._ROLE_ID = __ROLE_ID;
    }

    public SPMS_ROLE()
    {
    }
    private int _ROLE_ID;
    public int ROLE_ID
    {
        get { return (this._ROLE_ID); }
        set { this._ROLE_ID = value; }
    }

    private string _ROLE_NAME;
    public string ROLE_NAME
    {
        get { return (this._ROLE_NAME); }
        set { this._ROLE_NAME = value; }
    }
    private string _ROLE_DESCRIPTION;
    public string ROLE_DESCRIPTION
    {
        get { return (this._ROLE_DESCRIPTION); }
        set { this._ROLE_DESCRIPTION = value; }
    }
    private DateTime? _ROLE_STARTDATE;
    public DateTime? ROLE_STARTDATE
    {
        get { return (this._ROLE_STARTDATE); }
        set { this._ROLE_STARTDATE = value; }
    }
    private DateTime? _ROLE_ENDDATE;
    public DateTime? ROLE_ENDDATE
    {
        get { return (this._ROLE_ENDDATE); }
        set { this._ROLE_ENDDATE = value; }
    }
    private int _ROLES_KRA_ID;
    public int ROLES_KRA_ID
    {
        get { return (this._ROLES_KRA_ID); }
        set { this._ROLES_KRA_ID = value; }
    }

    private string _ROLE_COMMENTS;
    public string ROLE_COMMENTS
    {
        get { return (this._ROLE_COMMENTS); }
        set { this._ROLE_COMMENTS = value; }
    }
    private int _ROLE_CREATEDBY;
    public int ROLE_CREATEDBY
    {
        get { return (this._ROLE_CREATEDBY); }
        set { this._ROLE_CREATEDBY = value; }
    }

    private DateTime _ROLE_CREATEDDATE;
    public DateTime ROLE_CREATEDDATE
    {
        get { return (this._ROLE_CREATEDDATE); }
        set { this._ROLE_CREATEDDATE = value; }
    }

    private int _ROLE_LASTMDFBY;
    public int ROLE_LASTMDFBY
    {
        get { return (this._ROLE_LASTMDFBY); }
        set { this._ROLE_LASTMDFBY = value; }
    }

    private DateTime _ROLE_LASTMDFDATE;
    public DateTime ROLE_LASTMDFDATE
    {
        get { return (this._ROLE_LASTMDFDATE); }
        set { this._ROLE_LASTMDFDATE = value; }
    }
    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }


}
#endregion

#region SPMS_RATINGS
public class SPMS_RATINGS : SPMS_MAIN
{
    public SPMS_RATINGS(int __RATINGS_ID)
    {
        this._RATINGS_ID = __RATINGS_ID;
    }

    public SPMS_RATINGS()
    {
    }
    private int _RATINGS_ID;
    public int RATINGS_ID
    {
        get { return (this._RATINGS_ID); }
        set { this._RATINGS_ID = value; }
    }

    private string _RATINGS_NAME;
    public string RATINGS_NAME
    {
        get { return (this._RATINGS_NAME); }
        set { this._RATINGS_NAME = value; }
    }

    private string _RATINGS_DESCRIPTION;
    public string RATINGS_DESCRIPTION
    {
        get { return (this._RATINGS_DESCRIPTION); }
        set { this._RATINGS_DESCRIPTION = value; }
    }


    private string _RATINGS_INDICATOR;
    public string RATINGS_INDICATOR
    {
        get { return (this._RATINGS_INDICATOR); }
        set { this._RATINGS_INDICATOR = value; }
    }
    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }


}
#endregion

#region SPMS_COMPETENCIES
public class SPMS_COMPETENCIES : SPMS_MAIN
{
    public SPMS_COMPETENCIES(int __COMPETENCIES_ID)
    {
        this._COMPETENCIES_ID = __COMPETENCIES_ID;
    }

    public SPMS_COMPETENCIES()
    {
    }
    private int _COMPETENCIES_ID;
    public int COMPETENCIES_ID
    {
        get { return (this._COMPETENCIES_ID); }
        set { this._COMPETENCIES_ID = value; }
    }

    private string _COMPETENCIES_NAME;
    public string COMPETENCIES_NAME
    {
        get { return (this._COMPETENCIES_NAME); }
        set { this._COMPETENCIES_NAME = value; }
    }

    private string _COMPETENCIES_DESC;
    public string COMPETENCIES_DESC
    {
        get { return (this._COMPETENCIES_DESC); }
        set { this._COMPETENCIES_DESC = value; }
    }
    private DateTime _COMPETENCIES_STARTDATE;
    public DateTime COMPETENCIES_STARTDATE
    {
        get { return (this._COMPETENCIES_STARTDATE); }
        set { this._COMPETENCIES_STARTDATE = value; }
    }
    private DateTime _COMPETENCIES_ENDDATE;
    public DateTime COMPETENCIES_ENDDATE
    {
        get { return (this._COMPETENCIES_ENDDATE); }
        set { this._COMPETENCIES_ENDDATE = value; }
    }
    private int _COMPETENCIES_RATING_ID;
    public int COMPETENCIES_RATING_ID
    {
        get { return (this._COMPETENCIES_RATING_ID); }
        set { this._COMPETENCIES_RATING_ID = value; }
    }

    private Decimal _COMPETENCIES_REVIEWPERIOD;
    public Decimal COMPETENCIES_REVIEWPERIOD
    {
        get { return (this._COMPETENCIES_REVIEWPERIOD); }
        set { this._COMPETENCIES_REVIEWPERIOD = value; }
    }
    private int _COMPETENCIES_UNITS;
    public int COMPETENCIES_UNITS
    {
        get { return (this._COMPETENCIES_UNITS); }
        set { this._COMPETENCIES_UNITS = value; }
    }
    private string _COMPETENCIES_INDICATOR;
    public string COMPETENCIES_INDICATOR
    {
        get { return (this._COMPETENCIES_INDICATOR); }
        set { this._COMPETENCIES_INDICATOR = value; }
    }
    private int _COMPETENCIES_CREATEDBY;
    public int COMPETENCIES_CREATEDBY
    {
        get { return (this._COMPETENCIES_CREATEDBY); }
        set { this._COMPETENCIES_CREATEDBY = value; }
    }

    private DateTime _COMPETENCIES_CREATEDDATE;
    public DateTime COMPETENCIES_CREATEDDATE
    {
        get { return (this._COMPETENCIES_CREATEDDATE); }
        set { this._COMPETENCIES_CREATEDDATE = value; }
    }

    private int _COMPETENCIES_LASTMDFBY;
    public int COMPETENCIES_LASTMDFBY
    {
        get { return (this._COMPETENCIES_LASTMDFBY); }
        set { this._COMPETENCIES_LASTMDFBY = value; }
    }

    private DateTime _COMPETENCIES_LASTMDFDATE;
    public DateTime COMPETENCIES_LASTMDFDATE
    {
        get { return (this._COMPETENCIES_LASTMDFDATE); }
        set { this._COMPETENCIES_LASTMDFDATE = value; }
    }

    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }


}
#endregion

#region SPMS_ASSIGNINGKRA


public class SPMS_ASSIGNINGKRA : SPMS_MAIN
{
    public SPMS_ASSIGNINGKRA(int __ASSGNKRA_ID)
    {
        this._ASSGNKRA_ID = __ASSGNKRA_ID;
    }

    public SPMS_ASSIGNINGKRA()
    {
    }
    private int _ASSGNKRA_ID;
    public int ASSGNKRA_ID
    {
        get { return (this._ASSGNKRA_ID); }
        set { this._ASSGNKRA_ID = value; }
    }

    private int _ASSGNKRA_BUID;
    public int ASSGNKRA_BUID
    {
        get { return (this._ASSGNKRA_BUID); }
        set { this._ASSGNKRA_BUID = value; }
    }

    private int _ASSGNKRA_EMP_ID;
    public int ASSGNKRA_EMP_ID
    {
        get { return (this._ASSGNKRA_EMP_ID); }
        set { this._ASSGNKRA_EMP_ID = value; }
    }

    private int _ASSGNKRA_KRA_ID;
    public int ASSGNKRA_KRA_ID
    {
        get { return (this._ASSGNKRA_KRA_ID); }
        set { this._ASSGNKRA_KRA_ID = value; }
    }

    private int _ASSGNKRA_MGR_ID;
    public int ASSGNKRA_MGR_ID
    {
        get { return (this._ASSGNKRA_MGR_ID); }
        set { this._ASSGNKRA_MGR_ID = value; }
    }
    private int _ASSGNKRA_CREATEDBY;
    public int ASSGNKRA_CREATEDBY
    {
        get { return (this._ASSGNKRA_CREATEDBY); }
        set { this._ASSGNKRA_CREATEDBY = value; }
    }

    private DateTime _ASSGNKRA_LASTMDFDATE;
    public DateTime ASSGNKRA_LASTMDFDATE
    {
        get { return (this._ASSGNKRA_LASTMDFDATE); }
        set { this._ASSGNKRA_LASTMDFDATE = value; }
    }

    private int _ASSGNKRA_LASTMDFBY;
    public int ASSGNKRA_LASTMDFBY
    {
        get { return (this._ASSGNKRA_LASTMDFBY); }
        set { this._ASSGNKRA_LASTMDFBY = value; }
    }

    private DateTime _ASSGNKRA_CREATEDDATE;
    public DateTime ASSGNKRA_CREATEDDATE
    {
        get { return (this._ASSGNKRA_CREATEDDATE); }
        set { this._ASSGNKRA_CREATEDDATE = value; }
    }
    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }


}
#endregion

#region SPMS_DEFININGKRA


public class SPMS_KRA : SPMS_MAIN
{
    public SPMS_KRA(int __KRA_ID)
    {
        this._KRA_ID = __KRA_ID;
    }

    public SPMS_KRA()
    {
    }
    private int _KRA_ID;
    public int KRA_ID
    {
        get { return (this._KRA_ID); }
        set { this._KRA_ID = value; }
    }
    private int _KRA_ORG_ID;
    public int KRA_ORG_ID
    {
        get { return (this._KRA_ORG_ID); }
        set { this._KRA_ORG_ID = value; }
    }

    private string _KRA_CODE;
    public string KRA_CODE
    {
        get { return (this._KRA_CODE); }
        set { this._KRA_CODE = value; }
    }

    private string _KRA_NAME;
    public string KRA_NAME
    {
        get { return (this._KRA_NAME); }
        set { this._KRA_NAME = value; }
    }

    private string _KRA_DESCRIPTION;
    public string KRA_DESCRIPTION
    {
        get { return (this._KRA_DESCRIPTION); }
        set { this._KRA_DESCRIPTION = value; }
    }
    private DateTime? _KRA_STARTDATE;
    public DateTime? KRA_STARTDATE
    {
        get { return (this._KRA_STARTDATE); }
        set { this._KRA_STARTDATE = value; }
    }
    private DateTime? _KRA_ENDDATE;
    public DateTime? KRA_ENDDATE
    {
        get { return (this._KRA_ENDDATE); }
        set { this._KRA_ENDDATE = value; }
    }

    private int _ASSGNKRA_CREATEDBY;
    public int ASSGNKRA_CREATEDBY
    {
        get { return (this._ASSGNKRA_CREATEDBY); }
        set { this._ASSGNKRA_CREATEDBY = value; }
    }

    private DateTime _ASSGNKRA_LASTMDFDATE;
    public DateTime ASSGNKRA_LASTMDFDATE
    {
        get { return (this._ASSGNKRA_LASTMDFDATE); }
        set { this._ASSGNKRA_LASTMDFDATE = value; }
    }

    private int _KRA_LASTMDFBY;
    public int KRA_LASTMDFBY
    {
        get { return (this._KRA_LASTMDFBY); }
        set { this._KRA_LASTMDFBY = value; }
    }

    private DateTime _KRA_CREATEDDATE;
    public DateTime KRA_CREATEDDATE
    {
        get { return (this._KRA_CREATEDDATE); }
        set { this._KRA_CREATEDDATE = value; }
    }
    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }


}
#endregion

#region SPMS_FEEDBACK


public class SPMS_FEEDBACK : SPMS_MAIN
{
    public SPMS_FEEDBACK(int __FEEDBACK_ID)
    {
        this._FEEDBACK_ID = __FEEDBACK_ID;
    }

    public SPMS_FEEDBACK()
    {
    }
    private int _FEEDBACK_ID;
    public int FEEDBACK_ID
    {
        get { return (this._FEEDBACK_ID); }
        set { this._FEEDBACK_ID = value; }
    }


    private string _FEEDBACK_NAME_ID;
    public string FEEDBACK_NAME_ID
    {
        get { return (this._FEEDBACK_NAME_ID); }
        set { this._FEEDBACK_NAME_ID = value; }
    }

    private string _FEEDBACK_COMMENTS;
    public string FEEDBACK_COMMENTS
    {
        get { return (this._FEEDBACK_COMMENTS); }
        set { this._FEEDBACK_COMMENTS = value; }
    }
    private DateTime? _FEEDBACK_DATE;
    public DateTime? FEEDBACK_DATE
    {
        get { return (this._FEEDBACK_DATE); }
        set { this._FEEDBACK_DATE = value; }
    }


    private int _FEEDBACK_CREATEDBY;
    public int FEEDBACK_CREATEDBY
    {
        get { return (this._FEEDBACK_CREATEDBY); }
        set { this._FEEDBACK_CREATEDBY = value; }
    }

    private DateTime _FEEDBACK_LASTMDFDATE;
    public DateTime FEEDBACK_LASTMDFDATE
    {
        get { return (this._FEEDBACK_LASTMDFDATE); }
        set { this._FEEDBACK_LASTMDFDATE = value; }
    }

    private int _FEEDBACK_LASTMDFBY;
    public int FEEDBACK_LASTMDFBY
    {
        get { return (this._FEEDBACK_LASTMDFBY); }
        set { this._FEEDBACK_LASTMDFBY = value; }
    }

    private DateTime _FEEDBACK_CREATEDDATE;
    public DateTime FEEDBACK_CREATEDDATE
    {
        get { return (this._FEEDBACK_CREATEDDATE); }
        set { this._FEEDBACK_CREATEDDATE = value; }
    }
    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }

    private int _FEEDBK_ID;
    public int FEEDBK_ID
    {
        get { return (this._FEEDBK_ID); }
        set { this._FEEDBK_ID = value; }
    }

}
#endregion

#region SPMS_FEEDBK


public class SPMS_FEEDBK : SPMS_MAIN
{
    public SPMS_FEEDBK(int __FEEDBK_ID)
    {
        this._FEEDBK_ID = __FEEDBK_ID;
    }

    public SPMS_FEEDBK()
    {
    }
    private int _FEEDBK_ID;
    public int FEEDBK_ID
    {
        get { return (this._FEEDBK_ID); }
        set { this._FEEDBK_ID = value; }
    }


    private int _FEEDBK_BUSINESSUNIT_NAME;
    public int FEEDBK_BUSINESSUNIT_NAME
    {
        get { return (this._FEEDBK_BUSINESSUNIT_NAME); }
        set { this._FEEDBK_BUSINESSUNIT_NAME = value; }
    }

    private int _FEEDBK_EMPLOYEE_NAME;
    public int FEEDBK_EMPLOYEE_NAME
    {
        get { return (this._FEEDBK_EMPLOYEE_NAME); }
        set { this._FEEDBK_EMPLOYEE_NAME = value; }
    }

    private int _FEEDBK_MANAGER_NAME;
    public int FEEDBK_MANAGER_NAME
    {
        get { return (this._FEEDBK_MANAGER_NAME); }
        set { this._FEEDBK_MANAGER_NAME = value; }
    }

    private int _FEEDBK_CREATEDBY;
    public int FEEDBK_CREATEDBY
    {
        get { return (this._FEEDBK_CREATEDBY); }
        set { this._FEEDBK_CREATEDBY = value; }
    }

    private DateTime _FEEDBK_LASTMDFDATE;
    public DateTime FEEDBK_LASTMDFDATE
    {
        get { return (this._FEEDBK_LASTMDFDATE); }
        set { this._FEEDBK_LASTMDFDATE = value; }
    }

    private int _FEEDBK_LASTMDFBY;
    public int FEEDBK_LASTMDFBY
    {
        get { return (this._FEEDBK_LASTMDFBY); }
        set { this._FEEDBK_LASTMDFBY = value; }
    }

    private DateTime _FEEDBK_CREATEDDATE;
    public DateTime FEEDBK_CREATEDDATE
    {
        get { return (this._FEEDBK_CREATEDDATE); }
        set { this._FEEDBK_CREATEDDATE = value; }
    }
    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }


}


#endregion

#region SPMS_TEMPLATE
public class SPMS_TEMPLATE : SPMS_MAIN
{
    public SPMS_TEMPLATE(int __EMP_TEMPLATE_ID)
    {
        this._EMP_TEMPLATE_ID = __EMP_TEMPLATE_ID;
    }

    public SPMS_TEMPLATE()
    {
    }
    private int _EMP_TEMPLATE_ID;
    public int EMP_TEMPLATE_ID
    {
        get { return (this._EMP_TEMPLATE_ID); }
        set { this._EMP_TEMPLATE_ID = value; }
    }
    private string _EMP_TEMPLATE_NAME;
    public string EMP_TEMPLATE_NAME
    {
        get { return (this._EMP_TEMPLATE_NAME); }
        set { this._EMP_TEMPLATE_NAME = value; }
    }



    private int _BUSINESSUNIT_ID;
    public int BUSINESSUNIT_ID
    {
        get { return (this._BUSINESSUNIT_ID); }
        set { this._BUSINESSUNIT_ID = value; }
    }

    private int _EMPLOYEE_ID;
    public int EMPLOYEE_ID
    {
        get { return (this._EMPLOYEE_ID); }
        set { this._EMPLOYEE_ID = value; }
    }

    private int _TEMPLATE_ID;
    public int TEMPLATE_ID
    {
        get { return (this._TEMPLATE_ID); }
        set { this._TEMPLATE_ID = value; }
    }


    private int _TEMPLATE_CREATEDBY;
    public int TEMPLATE_CREATEDBY
    {
        get { return (this._TEMPLATE_CREATEDBY); }
        set { this._TEMPLATE_CREATEDBY = value; }
    }

    private DateTime _TEMPLATE_LASTMDFDATE;
    public DateTime TEMPLATE_LASTMDFDATE
    {
        get { return (this._TEMPLATE_LASTMDFDATE); }
        set { this._TEMPLATE_LASTMDFDATE = value; }
    }

    private int _TEMPLATE_LASTMDFBY;
    public int TEMPLATE_LASTMDFBY
    {
        get { return (this._TEMPLATE_LASTMDFBY); }
        set { this._TEMPLATE_LASTMDFBY = value; }
    }

    private DateTime _TEMPLATE_CREATEDDATE;
    public DateTime TEMPLATE_CREATEDDATE
    {
        get { return (this._TEMPLATE_CREATEDDATE); }
        set { this._TEMPLATE_CREATEDDATE = value; }
    }
    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }


}
#endregion

#region SPMS_APPRAISALTEMPLATE
public class SPMS_APPRAISALTEMPLATE : SPMS_MAIN
{
    public SPMS_APPRAISALTEMPLATE(int __APPRAISAL_ID)
    {
        this._APPRAISAL_ID = __APPRAISAL_ID;
    }

    public SPMS_APPRAISALTEMPLATE()
    {
    }
    private int _APPRAISAL_ID;
    public int APPRAISAL_ID
    {
        get { return (this._APPRAISAL_ID); }
        set { this._APPRAISAL_ID = value; }
    }

    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }



}
#endregion

#region SPMS_GOAL
public class SPMS_GOAL : SPMS_MAIN
{
    public SPMS_GOAL(int __GOAL_ID)
    {
        this._GOAL_ID = __GOAL_ID;
    }

    public SPMS_GOAL()
    {
    }
    private int _GOAL_ID;
    public int GOAL_ID
    {
        get { return (this._GOAL_ID); }
        set { this._GOAL_ID = value; }
    }
    private int _GOAL_BU_ID;
    public int GOAL_BU_ID
    {
        get { return (this._GOAL_BU_ID); }
        set { this._GOAL_BU_ID = value; }
    }

    private int _GOAL_EMP_ID;
    public int GOAL_EMP_ID
    {
        get { return (this._GOAL_EMP_ID); }
        set { this._GOAL_EMP_ID = value; }
    }

    private string _GOAL_DESIGNATION;
    public string GOAL_DESIGNATION
    {
        get { return (this._GOAL_DESIGNATION); }
        set { this._GOAL_DESIGNATION = value; }
    }
    private int _GOAL_EMP_LEVEL;
    public int GOAL_EMP_LEVEL
    {
        get { return (this._GOAL_EMP_LEVEL); }
        set { this._GOAL_EMP_LEVEL = value; }
    }
    private string _GOAL_EMP_LOCATION;
    public string GOAL_EMP_LOCATION
    {
        get { return (this._GOAL_EMP_LOCATION); }
        set { this._GOAL_EMP_LOCATION = value; }
    }
    private DateTime? _GOAL_DATEOFJOINING;
    public DateTime? GOAL_DATEOFJOINING
    {
        get { return (this._GOAL_DATEOFJOINING); }
        set { this._GOAL_DATEOFJOINING = value; }
    }


    private int _GOAL_ROLE_ID;
    public int GOAL_ROLE_ID
    {
        get { return (this._GOAL_ROLE_ID); }
        set { this._GOAL_ROLE_ID = value; }
    }
    private int _GOAL_APPRISALPERIOD;
    public int GOAL_APPRISALPERIOD
    {
        get { return (this._GOAL_APPRISALPERIOD); }
        set { this._GOAL_APPRISALPERIOD = value; }
    }


    private int _GOAL_KRA_ID;
    public int GOAL_KRA_ID
    {
        get { return (this._GOAL_KRA_ID); }
        set { this._GOAL_KRA_ID = value; }
    }
    private string _GOAL_NAME;
    public string GOAL_NAME
    {
        get { return (this._GOAL_NAME); }
        set { this._GOAL_NAME = value; }
    }

    private int _GOAL_WEIGHTAGE;
    public int GOAL_WEIGHTAGE
    {
        get { return (this._GOAL_WEIGHTAGE); }
        set { this._GOAL_WEIGHTAGE = value; }
    }
    private DateTime? _GOAL_TIMELINE;
    public DateTime? GOAL_TIMELINE
    {
        get { return (this._GOAL_TIMELINE); }
        set { this._GOAL_TIMELINE = value; }
    }

    private int _GOAL_CREATEDBY;
    public int GOAL_CREATEDBY
    {
        get { return (this._GOAL_CREATEDBY); }
        set { this._GOAL_CREATEDBY = value; }
    }

    private DateTime _GOAL_CREATEDDATE;
    public DateTime GOAL_CREATEDDATE
    {
        get { return (this._GOAL_CREATEDDATE); }
        set { this._GOAL_CREATEDDATE = value; }
    }

    private int _GOAL_LASTMDFBY;
    public int GOAL_LASTMDFBY
    {
        get { return (this._GOAL_LASTMDFBY); }
        set { this._GOAL_LASTMDFBY = value; }
    }

    private DateTime _GOAL_LASTMDFDATE;
    public DateTime GOAL_LASTMDFDATE
    {
        get { return (this._GOAL_LASTMDFDATE); }
        set { this._GOAL_LASTMDFDATE = value; }
    }
    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }


}
#endregion

#region SPMS_GOALS
public class SPMS_GOALS : SPMS_MAIN
{
    public SPMS_GOALS(int __GOALS_ID)
    {
        this._GOALS_ID = __GOALS_ID;
    }

    public SPMS_GOALS()
    {
    }
    private int _GOALS_ID;
    public int GOALS_ID
    {
        get { return (this._GOALS_ID); }
        set { this._GOALS_ID = value; }
    }


    private int _GOALS_BU_ID;
    public int GOALS_BU_ID
    {
        get { return (this._GOALS_BU_ID); }
        set { this._GOALS_BU_ID = value; }
    }

    private int _GOALS_EMP_ID;
    public int GOALS_EMP_ID
    {
        get { return (this._GOALS_EMP_ID); }
        set { this._GOALS_EMP_ID = value; }
    }

    private string _GOALS_JOB;
    public string GOALS_JOB
    {
        get { return (this._GOALS_JOB); }
        set { this._GOALS_JOB = value; }
    }

    private string _GOALS_POSITION;
    public string GOALS_POSITION
    {
        get { return (this._GOALS_POSITION); }
        set { this._GOALS_POSITION = value; }
    }

    private string _GOALS_NAME;
    public string GOALS_NAME
    {
        get { return (this._GOALS_NAME); }
        set { this._GOALS_NAME = value; }
    }
    private string _GOALS_DESCRIPTION;
    public string GOALS_DESCRIPTION
    {
        get { return (this._GOALS_DESCRIPTION); }
        set { this._GOALS_DESCRIPTION = value; }
    }

    private int _GOALS_MEASURE;
    public int GOALS_MEASURE
    {
        get { return (this._GOALS_MEASURE); }
        set { this._GOALS_MEASURE = value; }
    }
    private int _GOALS_WEIGHTAGE;
    public int GOALS_WEIGHTAGE
    {
        get { return (this._GOALS_WEIGHTAGE); }
        set { this._GOALS_WEIGHTAGE = value; }
    }
    private DateTime _GOALS_DATE;
    public DateTime GOALS_DATE
    {
        get { return (this._GOALS_DATE); }
        set { this._GOALS_DATE = value; }
    }
    private int _GOALS_CREATEDBY;
    public int GOALS_CREATEDBY
    {
        get { return (this._GOALS_CREATEDBY); }
        set { this._GOALS_CREATEDBY = value; }
    }

    private DateTime _GOALS_CREATEDDATE;
    public DateTime GOALS_CREATEDDATE
    {
        get { return (this._GOALS_CREATEDDATE); }
        set { this._GOALS_CREATEDDATE = value; }
    }

    private int _GOALS_LASTMDFBY;
    public int GOALS_LASTMDFBY
    {
        get { return (this._GOALS_LASTMDFBY); }
        set { this._GOALS_LASTMDFBY = value; }
    }

    private DateTime _GOALS_LASTMDFDATE;
    public DateTime GOALS_LASTMDFDATE
    {
        get { return (this._GOALS_LASTMDFDATE); }
        set { this._GOALS_LASTMDFDATE = value; }
    }
    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }


}
#endregion

#region SPMS_TASK
public class SPMS_TASK : SPMS_MAIN
{
    public SPMS_TASK(int __TASK_ID)
    {
        this._TASK_ID = __TASK_ID;
    }

    public SPMS_TASK()
    {
    }
    private int _TASK_ID;
    public int TASK_ID
    {
        get { return (this._TASK_ID); }
        set { this._TASK_ID = value; }
    }


    private int _TASK_BU_ID;
    public int TASK_BU_ID
    {
        get { return (this._TASK_BU_ID); }
        set { this._TASK_BU_ID = value; }
    }

    private int _TASK_EMP_ID;
    public int TASK_EMP_ID
    {
        get { return (this._TASK_EMP_ID); }
        set { this._TASK_EMP_ID = value; }
    }
    private int _TASK_ORG_ID;
    public int TASK_ORG_ID
    {
        get { return (this._TASK_ORG_ID); }
        set { this._TASK_ORG_ID = value; }
    }
    //private string _TASK_JOB;
    //public string TASK_JOB
    //{
    //    get { return (this._TASK_JOB); }
    //    set { this._TASK_JOB = value; }
    //}

    //private string _TASK_POSITION;
    //public string TASK_POSITION
    //{
    //    get { return (this._TASK_POSITION); }
    //    set { this._TASK_POSITION = value; }
    //}

    private string _TASK_NAME;
    public string TASK_NAME
    {
        get { return (this._TASK_NAME); }
        set { this._TASK_NAME = value; }
    }
    private string _TASK_DESCRIPTION;
    public string TASK_DESCRIPTION
    {
        get { return (this._TASK_DESCRIPTION); }
        set { this._TASK_DESCRIPTION = value; }
    }

    private int _TASK_GOAL_ID;
    public int TASK_GOAL_ID
    {
        get { return (this._TASK_GOAL_ID); }
        set { this._TASK_GOAL_ID = value; }
    }

    private DateTime _TASK_DATE;
    public DateTime TASK_DATE
    {
        get { return (this._TASK_DATE); }
        set { this._TASK_DATE = value; }
    }
    private int _TASK_CREATEDBY;
    public int TASK_CREATEDBY
    {
        get { return (this._TASK_CREATEDBY); }
        set { this._TASK_CREATEDBY = value; }
    }

    private DateTime _TASK_CREATEDDATE;
    public DateTime TASK_CREATEDDATE
    {
        get { return (this._TASK_CREATEDDATE); }
        set { this._TASK_CREATEDDATE = value; }
    }

    private int _TASK_LASTMDFBY;
    public int TASK_LASTMDFBY
    {
        get { return (this._TASK_LASTMDFBY); }
        set { this._TASK_LASTMDFBY = value; }
    }

    private DateTime _TASK_LASTMDFDATE;
    public DateTime TASK_LASTMDFDATE
    {
        get { return (this._TASK_LASTMDFDATE); }
        set { this._TASK_LASTMDFDATE = value; }
    }
    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }
    private int _TASK_APPRAISAL_CYCLE;
    public int TASK_APPRAISAL_CYCLE
    {
        get { return (this._TASK_APPRAISAL_CYCLE); }
        set { this._TASK_APPRAISAL_CYCLE = value; }
    }

}
#endregion

#region SPMS_PERIODICFEEDBACK
public class SPMS_PERIODICFEEDBACK : SPMS_MAIN
{
    public SPMS_PERIODICFEEDBACK(int __PF_ID)
    {
        this._PF_ID = __PF_ID;
    }

    public SPMS_PERIODICFEEDBACK()
    {
    }
    private int _PF_ID;
    public int PF_ID
    {
        get { return (this._PF_ID); }
        set { this._PF_ID = value; }
    }


    private int _PF_EMP_ID;
    public int PF_EMP_ID
    {
        get { return (this._PF_EMP_ID); }
        set { this._PF_EMP_ID = value; }
    }

    private int _PF_TASK_ID;
    public int PF_TASK_ID
    {
        get { return (this._PF_TASK_ID); }
        set { this._PF_TASK_ID = value; }
    }


    private string _PF_MGR_FEEDBACK;
    public string PF_MGR_FEEDBACK
    {
        get { return (this._PF_MGR_FEEDBACK); }
        set { this._PF_MGR_FEEDBACK = value; }
    }
    private int _PF_PM_ID;
    public int PF_PM_ID
    {
        get { return (this._PF_PM_ID); }
        set { this._PF_PM_ID = value; }
    }
    private int _PF_FEEDBACK_ID;
    public int PF_FEEDBACK_ID
    {
        get { return (this._PF_FEEDBACK_ID); }
        set { this._PF_FEEDBACK_ID = value; }
    }

   
    private int _PF_MGR_EMP_ID;
    public int PF_MGR_EMP_ID
    {
        get { return (this._PF_MGR_EMP_ID); }
        set { this._PF_MGR_EMP_ID = value; }
    }
    private int _PF_MGR_RATING;
    public int PF_MGR_RATING
    {
        get { return (this._PF_MGR_RATING); }
        set { this._PF_MGR_RATING = value; }
    }
    private int _PF_ORGANISATION_ID;
    public int PF_ORGANISATION_ID
    {
        get { return (this._PF_ORGANISATION_ID); }
        set { this._PF_ORGANISATION_ID = value; }
    }

    private int _PF_CREATEDBY;
    public int PF_CREATEDBY
    {
        get { return (this._PF_CREATEDBY); }
        set { this._PF_CREATEDBY = value; }
    }

    private DateTime _PF_CREATEDDATE;
    public DateTime PF_CREATEDDATE
    {
        get { return (this._PF_CREATEDDATE); }
        set { this._PF_CREATEDDATE = value; }
    }

    private int _PF_LASTMDFBY;
    public int PF_LASTMDFBY
    {
        get { return (this._PF_LASTMDFBY); }
        set { this._PF_LASTMDFBY = value; }
    }

    private DateTime _PF_LASTMDFDATE;
    public DateTime PF_LASTMDFDATE
    {
        get { return (this._PF_LASTMDFDATE); }
        set { this._PF_LASTMDFDATE = value; }
    }
    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }


}
#endregion

#region SPMS_GOALSETTING
public class SPMS_GOALSETTING : SPMS_MAIN
{
    public SPMS_GOALSETTING(int __GSDTL_ID)
    {
        this._GSDTL_ID = __GSDTL_ID;
    }

    public SPMS_GOALSETTING()
    {
    }
    private int _GSDTL_ID;
    public int GSDTL_ID
    {
        get { return (this._GSDTL_ID); }
        set { this._GSDTL_ID = value; }
    }
    private int _BU_ID;
    public int BU_ID
    {
        get { return (this._BU_ID); }
        set { this._BU_ID = value; }
    }

    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }


}
#endregion

#region SPMS_ROLEKRA
public class SPMS_ROLEKRA : SPMS_MAIN
{
    public SPMS_ROLEKRA(int __ROLEKRA_ID)
    {
        this._ROLEKRA_ID = __ROLEKRA_ID;
    }

    public SPMS_ROLEKRA()
    {
    }
    private int _ROLEKRA_ID;
    public int ROLEKRA_ID
    {
        get { return (this._ROLEKRA_ID); }
        set { this._ROLEKRA_ID = value; }
    }


    private int _ROLE_KRA_ID;
    public int ROLE_KRA_ID
    {
        get { return (this._ROLE_KRA_ID); }
        set { this._ROLE_KRA_ID = value; }
    }

    private int _ROLE_ID;
    public int ROLE_ID
    {
        get { return (this._ROLE_ID); }
        set { this._ROLE_ID = value; }
    }

    private int _ROLEKRA_ORG_ID;
    public int ROLEKRA_ORG_ID
    {
        get { return (this._ROLEKRA_ORG_ID); }
        set { this._ROLEKRA_ORG_ID = value; }
    }


    private int _ROLEKRA_CREATED_BY;
    public int ROLEKRA_CREATED_BY
    {
        get { return (this._ROLEKRA_CREATED_BY); }
        set { this._ROLEKRA_CREATED_BY = value; }
    }

    private DateTime _ROLEKRA_CREATED_DATE;
    public DateTime ROLEKRA_CREATED_DATE
    {
        get { return (this._ROLEKRA_CREATED_DATE); }
        set { this._ROLEKRA_CREATED_DATE = value; }
    }

    private int _ROLEKRA_LASTMDF_BY;
    public int ROLEKRA_LASTMDF_BY
    {
        get { return (this._ROLEKRA_LASTMDF_BY); }
        set { this._ROLEKRA_LASTMDF_BY = value; }
    }

    private DateTime _ROLEKRA_LASTMDF_DATE;
    public DateTime ROLEKRA_LASTMDF_DATE
    {
        get { return (this._ROLEKRA_LASTMDF_DATE); }
        set { this._ROLEKRA_LASTMDF_DATE = value; }
    }
    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }

    private int _PMS_Type;
    public int PMS_Type
    {
        get { return _PMS_Type; }
        set { _PMS_Type = value; }
    }

    private int _PositionID;
    public int PositionID
    {
        get { return _PositionID; }
        set { _PositionID = value; }
    }
}
#endregion


#region SPMS_EMPGOALSETTING
public class SPMS_EMPGOALSETTING : SPMS_MAIN
{
    public SPMS_EMPGOALSETTING(int __GS_ID)
    {
        this._GS_ID = __GS_ID;
    }

    public SPMS_EMPGOALSETTING()
    {
    }
    private int _GS_ID;
    public int GS_ID
    {
        get { return (this._GS_ID); }
        set { this._GS_ID = value; }
    }


    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }
    private int _BU_ID;
    public int BU_ID
    {
        get { return (this._BU_ID); }
        set { this._BU_ID = value; }
    }
    private int _GS_EMP_ID;
    public int GS_EMP_ID
    {
        get { return (this._GS_EMP_ID); }
        set { this._GS_EMP_ID = value; }
    }
    private int _GS_APPRAISALSTAGE;
    public int GS_APPRAISALSTAGE
    {
        get { return (this._GS_APPRAISALSTAGE); }
        set { this._GS_APPRAISALSTAGE = value; }
    }
    private string _GS_APPRAISAL_CYCLE;
    public string GS_APPRAISAL_CYCLE
    {
        get { return (this._GS_APPRAISAL_CYCLE); }
        set { this._GS_APPRAISAL_CYCLE = value; }
    }
}
#endregion


#region SPMS_APPRAISAL
public class SPMS_APPRAISAL : SPMS_MAIN
{
    public SPMS_APPRAISAL(int __APPRAISAL_ID)
    {
        this._APPRAISAL_ID = __APPRAISAL_ID;
    }

    public SPMS_APPRAISAL()
    {
    }
    private int _APPRAISAL_ID;
    public int APPRAISAL_ID
    {
        get { return (this._APPRAISAL_ID); }
        set { this._APPRAISAL_ID = value; }
    }

    private int _EMPID;
    public int EMPID
    {
        get { return (this._EMPID); }
        set { this._EMPID = value; }
    }
    private int _APP_STATUS_APPRAISALCYCLE;
    public int APP_STATUS_APPRAISALCYCLE
    {
        get { return (this._APP_STATUS_APPRAISALCYCLE); }
        set { this._APP_STATUS_APPRAISALCYCLE = value; }
    }


    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }

    private int _APPRAISAL_EMP_ID;
    public int APPRAISAL_EMP_ID
    {
        get { return (this._APPRAISAL_EMP_ID); }
        set { this._APPRAISAL_EMP_ID = value; }
    }
    private int _APPRAISAL_BUSSINESS_UNIT;
    public int APPRAISAL_BUSSINESS_UNIT
    {
        get { return (this._APPRAISAL_BUSSINESS_UNIT); }
        set { this._APPRAISAL_BUSSINESS_UNIT = value; }
    }


    private int _APPRAISAL_APPROVALSTAGE;
    public int APPRAISAL_APPROVALSTAGE
    {
        get { return (this._APPRAISAL_APPROVALSTAGE); }
        set { this._APPRAISAL_APPROVALSTAGE = value; }
    }
    private int _APPRAISAL_STATUS;
    public int APPRAISAL_STATUS
    {
        get { return (this._APPRAISAL_STATUS); }
        set { this._APPRAISAL_STATUS = value; }
    }
    private int _APPRAISAL_APPRAISALCYCLE;
    public int APPRAISAL_APPRAISALCYCLE
    {
        get { return (this._APPRAISAL_APPRAISALCYCLE); }
        set { this._APPRAISAL_APPRAISALCYCLE = value; }
    }
    private int _APPRAISAL_ORGANISATION_ID;
    public int APPRAISAL_ORGANISATION_ID
    {
        get { return (this._APPRAISAL_ORGANISATION_ID); }
        set { this._APPRAISAL_ORGANISATION_ID = value; }
    }
    private DateTime _APPRAISAL_DATE;
    public DateTime APPRAISAL_DATE
    {
        get { return (this._APPRAISAL_DATE); }
        set { this._APPRAISAL_DATE = value; }
    }
    private int _APPRAISAL_CREATEDBY;
    public int APPRAISAL_CREATEDBY
    {
        get { return (this._APPRAISAL_CREATEDBY); }
        set { this._APPRAISAL_CREATEDBY = value; }
    }

    private DateTime _APPRAISAL_CREATEDDATE;
    public DateTime APPRAISAL_CREATEDDATE
    {
        get { return (this._APPRAISAL_CREATEDDATE); }
        set { this._APPRAISAL_CREATEDDATE = value; }
    }
    private decimal _APPRAISAL_GOAL_AVGRTG;
    public decimal APPRAISAL_GOAL_AVGRTG
    {
        get { return (this._APPRAISAL_GOAL_AVGRTG); }
        set { this._APPRAISAL_GOAL_AVGRTG = value; }
    }

    private decimal _APPRAISAL_KRA_AVGRTG;
    public decimal APPRAISAL_KRA_AVGRTG
    {
        get { return (this._APPRAISAL_KRA_AVGRTG); }
        set { this._APPRAISAL_KRA_AVGRTG = value; }
    }
    private decimal _APPRAISAL_IDP_AVGRTG;
    public decimal APPRAISAL_IDP_AVGRTG
    {
        get { return (this._APPRAISAL_IDP_AVGRTG); }
        set { this._APPRAISAL_IDP_AVGRTG = value; }
    }
    private decimal _APPRAISAL_AVGRTG;
    public decimal APPRAISAL_AVGRTG
    {
        get { return (this._APPRAISAL_AVGRTG); }
        set { this._APPRAISAL_AVGRTG = value; }
    }
    private int _APPRAISAL_LASTMDFBY;
    public int APPRAISAL_LASTMDFBY
    {
        get { return (this._APPRAISAL_LASTMDFBY); }
        set { this._APPRAISAL_LASTMDFBY = value; }
    }

    private DateTime _APPRAISAL_LASTMDFDATE;
    public DateTime APPRAISAL_LASTMDFDATE
    {
        get { return (this._APPRAISAL_LASTMDFDATE); }
        set { this._APPRAISAL_LASTMDFDATE = value; }
    }
    private int _APP_ROLEKRA_ID;
    public int APP_ROLEKRA_ID
    {
        get { return (this._APP_ROLEKRA_ID); }
        set { this._APP_ROLEKRA_ID = value; }
    }
    private string _APP_REJECT_COMMENTS;
    public string APP_REJECT_COMMENTS
    {
        get { return (this._APP_REJECT_COMMENTS); }
        set { this._APP_REJECT_COMMENTS = value; }
    }
}
#endregion

#region SPMS_APPRAISALGOAL
public class SPMS_APPRAISALGOAL : SPMS_MAIN
{
    public SPMS_APPRAISALGOAL(int __APP_GOALS_ID)
    {
        this._APP_GOALS_ID = __APP_GOALS_ID;
    }

    public SPMS_APPRAISALGOAL()
    {
    }
    private int _APP_GOALS_ID;
    public int APP_GOALS_ID
    {
        get { return (this._APP_GOALS_ID); }
        set { this._APP_GOALS_ID = value; }
    }

    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }
    private int _APP_GOALS_APP_ID;
    public int APP_GOALS_APP_ID
    {
        get { return (this._APP_GOALS_APP_ID); }
        set { this._APP_GOALS_APP_ID = value; }
    }
    private int _APP_GOAL_ORG_ID;
    public int APP_GOAL_ORG_ID
    {
        get { return (this._APP_GOAL_ORG_ID); }
        set { this._APP_GOAL_ORG_ID = value; }
    }
    private int _APP_GOALS_GSDTL_ID;
    public int APP_GOALS_GSDTL_ID
    {
        get { return (this._APP_GOALS_GSDTL_ID); }
        set { this._APP_GOALS_GSDTL_ID = value; }
    }
    private string _APP_GOALS_EMP_COMMENTS;
    public string APP_GOALS_EMP_COMMENTS
    {
        get { return (this._APP_GOALS_EMP_COMMENTS); }
        set { this._APP_GOALS_EMP_COMMENTS = value; }
    }
    private string _APP_GOALS_MGR_COMMENTS;
    public string APP_GOALS_MGR_COMMENTS
    {
        get { return (this._APP_GOALS_MGR_COMMENTS); }
        set { this._APP_GOALS_MGR_COMMENTS = value; }
    }
    private decimal _APP_GOALS_MGR_RATING;
    public decimal APP_GOALS_MGR_RATING
    {
        get { return (this._APP_GOALS_MGR_RATING); }
        set { this._APP_GOALS_MGR_RATING = value; }
    }
    private string _APP_GOALS_APPR_COMMENTS;
    public string APP_GOALS_APPR_COMMENTS
    {
        get { return (this._APP_GOALS_APPR_COMMENTS); }
        set { this._APP_GOALS_APPR_COMMENTS = value; }
    }
    private decimal _APP_GOALS_APPR_RATING;
    public decimal APP_GOALS_APPR_RATING
    {
        get { return (this._APP_GOALS_APPR_RATING); }
        set { this._APP_GOALS_APPR_RATING = value; }
    }
    //private decimal _APP_GOALS_AVGRTG;
    //public decimal APP_GOALS_AVGRTG
    //{
    //    get { return (this._APP_GOALS_AVGRTG); }
    //    set { this._APP_GOALS_AVGRTG = value; }
    //}
    private int _APP_GOALS_CREATEDBY;
    public int APP_GOALS_CREATEDBY
    {
        get { return (this._APP_GOALS_CREATEDBY); }
        set { this._APP_GOALS_CREATEDBY = value; }
    }

    private DateTime _APP_GOALS_CREATEDDATE;
    public DateTime APP_GOALS_CREATEDDATE
    {
        get { return (this._APP_GOALS_CREATEDDATE); }
        set { this._APP_GOALS_CREATEDDATE = value; }
    }

    private int _APP_GOALS_LASTMDFBY;
    public int APP_GOALS_LASTMDFBY
    {
        get { return (this._APP_GOALS_LASTMDFBY); }
        set { this._APP_GOALS_LASTMDFBY = value; }
    }
    private string _APP_GOALS_FIXED;
    public string APP_GOALS_FIXED
    {
        get { return (this._APP_GOALS_FIXED); }
        set { this._APP_GOALS_FIXED = value; }
    }


    private string _APP_EMP_GOAL_FIXED;
    public string APP_EMP_GOAL_FIXED
    {
        get { return (this._APP_EMP_GOAL_FIXED); }
        set { this._APP_EMP_GOAL_FIXED = value; }
    }
    private DateTime _APP_GOALS_LASTMDFDATE;
    public DateTime APP_GOALS_LASTMDFDATE
    {
        get { return (this._APP_GOALS_LASTMDFDATE); }
        set { this._APP_GOALS_LASTMDFDATE = value; }
    }
    private int _APP_GOALS_FINAL;
    public int APP_GOALS_FINAL
    {
        get { return (this._APP_GOALS_FINAL); }
        set { this._APP_GOALS_FINAL = value; }
    }

    private int _APP_GOALS_APPR_FIXED;
    public int APP_GOALS_APPR_FIXED
    {
        get { return (this._APP_GOALS_APPR_FIXED); }
        set { this._APP_GOALS_APPR_FIXED = value; }
    }

}
#endregion


#region SPMS_GOALSETTINGKRADETAILS
public class SPMS_GOALSETTINGKRADETAILS : SPMS_MAIN
{
    public SPMS_GOALSETTINGKRADETAILS(int __GS_KRA_ID)
    {
        this._GS_KRA_ID = __GS_KRA_ID;
    }

    public SPMS_GOALSETTINGKRADETAILS()
    {
    }
    private int _GS_KRA_ID;
    public int GS_KRA_ID
    {
        get { return (this._GS_KRA_ID); }
        set { this._GS_KRA_ID = value; }
    }


    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }

    private int _GS_KRA_GSDTL_ID;
    public int GS_KRA_GSDTL_ID
    {
        get { return (this._GS_KRA_GSDTL_ID); }
        set { this._GS_KRA_GSDTL_ID = value; }
    }

}
#endregion

#region SPMS_APPRAISALKRA
public class SPMS_APPRAISALKRA : SPMS_MAIN
{
    public SPMS_APPRAISALKRA(int __APP_KRA_ID)
    {
        this._APP_KRA_ID = __APP_KRA_ID;
    }

    public SPMS_APPRAISALKRA()
    {
    }
    private int _APP_KRA_ID;
    public int APP_KRA_ID
    {
        get { return (this._APP_KRA_ID); }
        set { this._APP_KRA_ID = value; }
    }

    public int APP_KRA_OBJ_ID { get; set; }
    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }

    private int _APP_KRA_APP_ID;
    public int APP_KRA_APP_ID
    {
        get { return (this._APP_KRA_APP_ID); }
        set { this._APP_KRA_APP_ID = value; }
    }
    private int _APP_KRA_ORG_ID;
    public int APP_KRA_ORG_ID
    {
        get { return (this._APP_KRA_ORG_ID); }
        set { this._APP_KRA_ORG_ID = value; }
    }
    private int _APP_KRA_KRA_ID;
    public int APP_KRA_KRA_ID
    {
        get { return (this._APP_KRA_KRA_ID); }
        set { this._APP_KRA_KRA_ID = value; }
    }
    private string _APP_KRA_EMP_COMMENTS;
    public string APP_KRA_EMP_COMMENTS
    {
        get { return (this._APP_KRA_EMP_COMMENTS); }
        set { this._APP_KRA_EMP_COMMENTS = value; }
    }
    private string _APP_KRA_MGR_COMMENTS;
    public string APP_KRA_MGR_COMMENTS
    {
        get { return (this._APP_KRA_MGR_COMMENTS); }
        set { this._APP_KRA_MGR_COMMENTS = value; }
    }
    private decimal _APP_KRA_MGR_RATING;
    public decimal APP_KRA_MGR_RATING
    {
        get { return (this._APP_KRA_MGR_RATING); }
        set { this._APP_KRA_MGR_RATING = value; }
    }
    //private decimal _APP_KRA_AVGRTG;
    //public decimal APP_KRA_AVGRTG
    //{
    //    get { return (this._APP_KRA_AVGRTG); }
    //    set { this._APP_KRA_AVGRTG = value; }
    //}
    private int _APP_KRA_CREATEDBY;
    public int APP_KRA_CREATEDBY
    {
        get { return (this._APP_KRA_CREATEDBY); }
        set { this._APP_KRA_CREATEDBY = value; }
    }
    private string _APP_KRA_FIXED;
    public string APP_KRA_FIXED
    {
        get { return (this._APP_KRA_FIXED); }
        set { this._APP_KRA_FIXED = value; }
    }
    
    private string _APP_KRA_EMP_FIXED;
    public string APP_KRA_EMP_FIXED
    {
        get { return (this._APP_KRA_EMP_FIXED); }
        set { this._APP_KRA_EMP_FIXED = value; }
    }
    private DateTime _APP_KRA_CREATEDDATE;
    public DateTime APP_KRA_CREATEDDATE
    {
        get { return (this._APP_KRA_CREATEDDATE); }
        set { this._APP_KRA_CREATEDDATE = value; }
    }

    private int _APP_KRA_LASTMDFBY;
    public int APP_KRA_LASTMDFBY
    {
        get { return (this._APP_KRA_LASTMDFBY); }
        set { this._APP_KRA_LASTMDFBY = value; }
    }

    private DateTime _APP_KRA_LASTMDFDATE;
    public DateTime APP_KRA_LASTMDFDATE
    {
        get { return (this._APP_KRA_LASTMDFDATE); }
        set { this._APP_KRA_LASTMDFDATE = value; }
    }
    private int _APP_KRA_FINAL;
    public int APP_KRA_FINAL
    {
        get { return (this._APP_KRA_FINAL); }
        set { this._APP_KRA_FINAL = value; }
    }

    private string _APP_KRA_APPR_COMMENTS;
    public string APP_KRA_APPR_COMMENTS
    {
        get { return (this._APP_KRA_APPR_COMMENTS); }
        set { this._APP_KRA_APPR_COMMENTS = value; }
    }
    private decimal _APP_KRA_APPR_RATING;
    public decimal APP_KRA_APPR_RATING
    {
        get { return (this._APP_KRA_APPR_RATING); }
        set { this._APP_KRA_APPR_RATING = value; }
    }
    private int _APP_KRA_APPR_FIXED;
    public int APP_KRA_APPR_FIXED
    {
        get { return (this._APP_KRA_APPR_FIXED); }
        set { this._APP_KRA_APPR_FIXED = value; }
    }
}
#endregion

#region SPMS_APPRAISALIDP
public class SPMS_APPRAISALIDP : SPMS_MAIN
{
    public SPMS_APPRAISALIDP(int __APP_IDP_ID)
    {
        this._APP_IDP_ID = __APP_IDP_ID;
    }

    public SPMS_APPRAISALIDP()
    {
    }
    private int _APP_IDP_ID;
    public int APP_IDP_ID
    {
        get { return (this._APP_IDP_ID); }
        set { this._APP_IDP_ID = value; }
    }


    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }

    private int _APP_IDP_APP_ID;
    public int APP_IDP_APP_ID
    {
        get { return (this._APP_IDP_APP_ID); }
        set { this._APP_IDP_APP_ID = value; }
    }
    private int _APP_IDP_ORG_ID;
    public int APP_IDP_ORG_ID
    {
        get { return (this._APP_IDP_ORG_ID); }
        set { this._APP_IDP_ORG_ID = value; }
    }
    private int _APP_IDP_IDP_ID;
    public int APP_IDP_IDP_ID
    {
        get { return (this._APP_IDP_IDP_ID); }
        set { this._APP_IDP_IDP_ID = value; }
    }
    private string _APP_IDP_EMP_COMMENTS;
    public string APP_IDP_EMP_COMMENTS
    {
        get { return (this._APP_IDP_EMP_COMMENTS); }
        set { this._APP_IDP_EMP_COMMENTS = value; }
    }
    private string _APP_IDP_MGR_COMMENTS;
    public string APP_IDP_MGR_COMMENTS
    {
        get { return (this._APP_IDP_MGR_COMMENTS); }
        set { this._APP_IDP_MGR_COMMENTS = value; }
    }
    private decimal _APP_IDP_MGR_RATING;
    public decimal APP_IDP_MGR_RATING
    {
        get { return (this._APP_IDP_MGR_RATING); }
        set { this._APP_IDP_MGR_RATING = value; }
    }
    //private decimal _APP_IDP_AVGRTG;
    //public decimal APP_IDP_AVGRTG
    //{
    //    get { return (this._APP_IDP_AVGRTG); }
    //    set { this._APP_IDP_AVGRTG = value; }
    //}
    private int _APP_IDP_CREATEDBY;
    public int APP_IDP_CREATEDBY
    {
        get { return (this._APP_IDP_CREATEDBY); }
        set { this._APP_IDP_CREATEDBY = value; }
    }
    private string _APP_IDP_FIXED;
    public string APP_IDP_FIXED
    {
        get { return (this._APP_IDP_FIXED); }
        set { this._APP_IDP_FIXED = value; }
    }

    private string _APP_IDP_EMP_FIXED;
    public string APP_IDP_EMP_FIXED
    {
        get { return (this._APP_IDP_EMP_FIXED); }
        set { this._APP_IDP_EMP_FIXED = value; }
    }
    private DateTime _APP_IDP_CREATEDDATE;
    public DateTime APP_IDP_CREATEDDATE
    {
        get { return (this._APP_IDP_CREATEDDATE); }
        set { this._APP_IDP_CREATEDDATE = value; }
    }

    private int _APP_IDP_LASTMDFBY;
    public int APP_IDP_LASTMDFBY
    {
        get { return (this._APP_IDP_LASTMDFBY); }
        set { this._APP_IDP_LASTMDFBY = value; }
    }

    private DateTime _APP_IDP_LASTMDFDATE;
    public DateTime APP_IDP_LASTMDFDATE
    {
        get { return (this._APP_IDP_LASTMDFDATE); }
        set { this._APP_IDP_LASTMDFDATE = value; }
    }
    private int _APP_IDP_FINAL;
    public int APP_IDP_FINAL
    {
        get { return (this._APP_IDP_FINAL); }
        set { this._APP_IDP_FINAL = value; }
    }
    private string _APP_IDP_APPR_COMMENTS;
    public string APP_IDP_APPR_COMMENTS
    {
        get { return (this._APP_IDP_APPR_COMMENTS); }
        set { this._APP_IDP_APPR_COMMENTS = value; }
    }
    private decimal _APP_IDP_APPR_RATING;
    public decimal APP_IDP_APPR_RATING
    {
        get { return (this._APP_IDP_APPR_RATING); }
        set { this._APP_IDP_APPR_RATING = value; }
    }
    private int _APP_IDP_APPR_FIXED;
    public int APP_IDP_APPR_FIXED
    {
        get { return (this._APP_IDP_APPR_FIXED); }
        set { this._APP_IDP_APPR_FIXED = value; }
    }



}
#endregion

#region SPMS_APRAISALAPPROVER

public class SPMS_APRAISALAPPROVER : SPMS_MAIN
{
    public SPMS_APRAISALAPPROVER(int __APP_APPROVER_ID)
    {
        this._APP_APPROVER_ID = __APP_APPROVER_ID;
    }

    public SPMS_APRAISALAPPROVER()
    {
    }
    private int _APP_APPROVER_ID;
    public int APP_APPROVER_ID
    {
        get { return (this._APP_APPROVER_ID); }
        set { this._APP_APPROVER_ID = value; }
    }


    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }

    private int _APP_APPROVER_APP_ID;
    public int APP_APPROVER_APP_ID
    {
        get { return (this._APP_APPROVER_APP_ID); }
        set { this._APP_APPROVER_APP_ID = value; }
    }

    private string _APP_APPROVER_COMMENTS;
    public string APP_APPROVER_COMMENTS
    {
        get { return (this._APP_APPROVER_COMMENTS); }
        set { this._APP_APPROVER_COMMENTS = value; }
    }

    private decimal _APP_APPROVER_RATING;
    public decimal APP_APPROVER_RATING
    {
        get { return (this._APP_APPROVER_RATING); }
        set { this._APP_APPROVER_RATING = value; }
    }
    private int _APP_APPROVER_CREATEDBY;
    public int APP_APPROVER_CREATEDBY
    {
        get { return (this._APP_APPROVER_CREATEDBY); }
        set { this._APP_APPROVER_CREATEDBY = value; }
    }
    private int _APP_APPROVER_ORG_ID;
    public int APP_APPROVER_ORG_ID
    {
        get { return (this._APP_APPROVER_ORG_ID); }
        set { this._APP_APPROVER_ORG_ID = value; }
    }
    private DateTime _APP_APPROVER_CREATEDDATE;
    public DateTime APP_APPROVER_CREATEDDATE
    {
        get { return (this._APP_APPROVER_CREATEDDATE); }
        set { this._APP_APPROVER_CREATEDDATE = value; }
    }

    private int _APP_APPROVER_LASTMDFBY;
    public int APP_APPROVER_LASTMDFBY
    {
        get { return (this._APP_APPROVER_LASTMDFBY); }
        set { this._APP_APPROVER_LASTMDFBY = value; }
    }

    private DateTime _APP_APPROVER_LASTMDFDATE;
    public DateTime APP_APPROVER_LASTMDFDATE
    {
        get { return (this._APP_APPROVER_LASTMDFDATE); }
        set { this._APP_APPROVER_LASTMDFDATE = value; }
    }

    private int _APP_APPROVER_STATUS;
    public int APP_APPROVER_STATUS
    {
        get { return (this._APP_APPROVER_STATUS); }
        set { this._APP_APPROVER_STATUS = value; }
    }




}
#endregion


#region SPMS_APRAISALDISCUSSION

public class SPMS_APRAISALDISCUSSION : SPMS_MAIN
{
    public SPMS_APRAISALDISCUSSION(int __APP_DISCUSSION_ID)
    {
        this._APP_DISCUSSION_ID = __APP_DISCUSSION_ID;
    }

    public SPMS_APRAISALDISCUSSION()
    {
    }
    private int _APP_DISCUSSION_ID;
    public int APP_DISCUSSION_ID
    {
        get { return (this._APP_DISCUSSION_ID); }
        set { this._APP_DISCUSSION_ID = value; }
    }


    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }

    private int _APP_DISCUSSION_APP_ID;
    public int APP_DISCUSSION_APP_ID
    {
        get { return (this._APP_DISCUSSION_APP_ID); }
        set { this._APP_DISCUSSION_APP_ID = value; }
    }
    private int _LOGIN_ID;
    public int LOGIN_ID
    {
        get { return (this._LOGIN_ID); }
        set { this._LOGIN_ID = value; }
    }
    private int _APP_DISCUSSION_ORG_ID;
    public int APP_DISCUSSION_ORG_ID
    {
        get { return (this._APP_DISCUSSION_ORG_ID); }
        set { this._APP_DISCUSSION_ORG_ID = value; }
    }
    private string _APP_DISCUSSION_EMP_COMMENTS;
    public string APP_DISCUSSION_EMP_COMMENTS
    {
        get { return (this._APP_DISCUSSION_EMP_COMMENTS); }
        set { this._APP_DISCUSSION_EMP_COMMENTS = value; }
    }

    private string _APP_DISCUSSION_MGR_COMMENTS;
    public string APP_DISCUSSION_MGR_COMMENTS
    {
        get { return (this._APP_DISCUSSION_MGR_COMMENTS); }
        set { this._APP_DISCUSSION_MGR_COMMENTS = value; }
    }

    private DateTime _APP_DISCUSSION_DATE;
    public DateTime APP_DISCUSSION_DATE
    {
        get { return (this._APP_DISCUSSION_DATE); }
        set { this._APP_DISCUSSION_DATE = value; }
    }
    private int _APP_DISCUSSION_CREATEDBY;
    public int APP_DISCUSSION_CREATEDBY
    {
        get { return (this._APP_DISCUSSION_CREATEDBY); }
        set { this._APP_DISCUSSION_CREATEDBY = value; }
    }

    private DateTime _APP_DISCUSSION_CREATEDDATE;
    public DateTime APP_DISCUSSION_CREATEDDATE
    {
        get { return (this._APP_DISCUSSION_CREATEDDATE); }
        set { this._APP_DISCUSSION_CREATEDDATE = value; }
    }

    private int _APP_DISCUSSION_LASTMDFBY;
    public int APP_DISCUSSION_LASTMDFBY
    {
        get { return (this._APP_DISCUSSION_LASTMDFBY); }
        set { this._APP_DISCUSSION_LASTMDFBY = value; }
    }

    private DateTime _APP_DISCUSSION_LASTMDFDATE;
    public DateTime APP_DISCUSSION_LASTMDFDATE
    {
        get { return (this._APP_DISCUSSION_LASTMDFDATE); }
        set { this._APP_DISCUSSION_LASTMDFDATE = value; }
    }






}
#endregion

#region SPMS_PROJECT
public class SPMS_PROJECT : SPMS_MAIN
{
    public SPMS_PROJECT(int __PROJECT_ID)
    {
        this._PROJECT_ID = __PROJECT_ID;
    }

    public SPMS_PROJECT()
    {
    }
    private int _PROJECT_ID;
    public int PROJECT_ID
    {
        get { return (this._PROJECT_ID); }
        set { this._PROJECT_ID = value; }
    }

    private string _PROJECT_NAME;
    public string PROJECT_NAME
    {
        get { return (this._PROJECT_NAME); }
        set { this._PROJECT_NAME = value; }
    }

    private string _PROJECT_DESCRIPTION;
    public string PROJECT_DESCRIPTION
    {
        get { return (this._PROJECT_DESCRIPTION); }
        set { this._PROJECT_DESCRIPTION = value; }
    }
    private int _PROJECT_CREATEDBY;
    public int PROJECT_CREATEDBY
    {
        get { return (this._PROJECT_CREATEDBY); }
        set { this._PROJECT_CREATEDBY = value; }
    }

    private DateTime _PROJECT_CREATEDDATE;
    public DateTime PROJECT_CREATEDDATE
    {
        get { return (this._PROJECT_CREATEDDATE); }
        set { this._PROJECT_CREATEDDATE = value; }
    }

    private int _PROJECT_LASTMDFBY;
    public int PROJECT_LASTMDFBY
    {
        get { return (this._PROJECT_LASTMDFBY); }
        set { this._PROJECT_LASTMDFBY = value; }
    }
    private int _max_weightage;
    public int max_weightage
    {
        get { return (this._max_weightage); }
        set { this._max_weightage = value; }
    }
    private DateTime _PROJECT_LASTMDFDATE;
    public DateTime PROJECT_LASTMDFDATE
    {
        get { return (this._PROJECT_LASTMDFDATE); }
        set { this._PROJECT_LASTMDFDATE = value; }
    }

    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }

    private int _PROJECT_ORG_ID;
    public int PROJECT_ORG_ID
    {
        get { return (this._PROJECT_ORG_ID); }
        set { this._PROJECT_ORG_ID = value; }
    }
}
#endregion


#region SMHR_AX
public class SMHR_AX : SMHR_MAIN
{
    public SMHR_AX(int __SMHR_AX_ID)
    {
        this._SMHR_AX_ID = __SMHR_AX_ID;
    }

    public SMHR_AX()
    {
    }
    private int _SMHR_AX_ID;
    public int SMHR_AX_ID
    {
        get { return (this._SMHR_AX_ID); }
        set { this._SMHR_AX_ID = value; }
    }

    private string _SMHR_AX_DIM1;
    public string SMHR_AX_DIM1
    {
        get { return (this._SMHR_AX_DIM1); }
        set { this._SMHR_AX_DIM1 = value; }
    }

    private string _SMHR_AX_DIM2;
    public string SMHR_AX_DIM2
    {
        get { return (this._SMHR_AX_DIM2); }
        set { this._SMHR_AX_DIM2 = value; }
    }

    private string _SMHR_AX_DIM3;
    public string SMHR_AX_DIM3
    {
        get { return (this._SMHR_AX_DIM3); }
        set { this._SMHR_AX_DIM3 = value; }
    }
    private int _SMHR_AX_CREATEDBY;
    public int SMHR_AX_CREATEDBY
    {
        get { return (this._SMHR_AX_CREATEDBY); }
        set { this._SMHR_AX_CREATEDBY = value; }
    }

    private DateTime _SMHR_AX_CREATEDDATE;
    public DateTime SMHR_AX_CREATEDDATE
    {
        get { return (this._SMHR_AX_CREATEDDATE); }
        set { this._SMHR_AX_CREATEDDATE = value; }
    }

    private int _SMHR_AX_LASTMDFBY;
    public int SMHR_AX_LASTMDFBY
    {
        get { return (this._SMHR_AX_LASTMDFBY); }
        set { this._SMHR_AX_LASTMDFBY = value; }
    }
    private int _SMHR_AX_BU_ID;
    public int SMHR_AX_BU_ID
    {
        get { return (this._SMHR_AX_BU_ID); }
        set { this._SMHR_AX_BU_ID = value; }
    }
    private DateTime _SMHR_AX_LASTMDFDATE;
    public DateTime SMHR_AX_LASTMDFDATE
    {
        get { return (this._SMHR_AX_LASTMDFDATE); }
        set { this._SMHR_AX_LASTMDFDATE = value; }
    }

    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }
    private int _SMHR_AX_ORG_ID;
    public int SMHR_AX_ORG_ID
    {
        get { return (this._SMHR_AX_ORG_ID); }
        set { this._SMHR_AX_ORG_ID = value; }
    }

}
#endregion

//#region SMHR_HRA
//public class SMHR_HRA : SPMS_MAIN
//{
//    public SMHR_HRA(int __SMHR_HRA_ID)
//    {
//        this._SMHR_HRA_ID = __SMHR_HRA_ID;
//    }

//    public SMHR_HRA()
//    {
//    }
//    private int _SMHR_HRA_ID;
//    public int SMHR_HRA_ID
//    {
//        get { return (this._SMHR_HRA_ID); }
//        set { this._SMHR_HRA_ID = value; }
//    }




//    private DateTime _SMHR_HRA_CREATEDDATE;
//    public DateTime SMHR_HRA_CREATEDDATE
//    {
//        get { return (this._SMHR_HRA_CREATEDDATE); }
//        set { this._SMHR_HRA_CREATEDDATE = value; }
//    }

//    private int _SMHR_HRA_LASTMDFBY;
//    public int SMHR_HRA_LASTMDFBY
//    {
//        get { return (this._SMHR_HRA_LASTMDFBY); }
//        set { this._SMHR_HRA_LASTMDFBY = value; }
//    }

//    private int _SMHR_HRA_CREATEDBY;
//    public int SMHR_HRA_CREATEDBY
//    {
//        get { return (this._SMHR_HRA_CREATEDBY); }
//        set { this._SMHR_HRA_CREATEDBY = value; }
//    }
//    private int _SMHR_ORG_ID;
//    public int SMHR_ORG_ID
//    {
//        get { return (this._SMHR_ORG_ID); }
//        set { this._SMHR_ORG_ID = value; }
//    }
//    private string _SMHR_HRA_MUL_ID;
//    public string SMHR_HRA_MUL_ID
//    {
//        get { return (this._SMHR_HRA_MUL_ID); }
//        set { this._SMHR_HRA_MUL_ID = value; }
//    }

//    private int _SMHR_PAYITEMID1;
//    public int SMHR_PAYITEMID1
//    {
//        get { return (this._SMHR_PAYITEMID1); }
//        set { this._SMHR_PAYITEMID1 = value; }
//    }
//    private DateTime _SMHR_HRA_LASTMDFDATE;
//    public DateTime SMHR_HRA_LASTMDFDATE
//    {
//        get { return (this._SMHR_HRA_LASTMDFDATE); }
//        set { this._SMHR_HRA_LASTMDFDATE = value; }
//    }

//    private int _Mode;
//    public int Mode
//    {
//        get { return (this._Mode); }
//        set { this._Mode = value; }
//    }


//}
//#endregion


//#region SMHR_EMP_HRA
//public class SMHR_EMP_HRA : SPMS_MAIN
//{
//    public SMHR_EMP_HRA(int __SMHR_HRA_ID)
//    {
//        this._SMHR_HRA_ID = __SMHR_HRA_ID;
//    }

//    public SMHR_EMP_HRA()
//    {
//    }
//    private int _SMHR_HRA_ID;
//    public int SMHR_HRA_ID
//    {
//        get { return (this._SMHR_HRA_ID); }
//        set { this._SMHR_HRA_ID = value; }
//    }

//    private int _SMHR_HRA_BU_ID;
//    public int SMHR_HRA_BU_ID
//    {
//        get { return (this._SMHR_HRA_BU_ID); }
//        set { this._SMHR_HRA_BU_ID = value; }
//    }
//    private int _SMHR_HRA_PAYITEM_ID;
//    public int SMHR_HRA_PAYITEM_ID
//    {
//        get { return (this._SMHR_HRA_PAYITEM_ID); }
//        set { this._SMHR_HRA_PAYITEM_ID = value; }
//    }
//    private string _SMHR_HRA_EXCESS_PAYITEM_ID;
//    public string SMHR_HRA_EXCESS_PAYITEM_ID
//    {
//        get { return (this._SMHR_HRA_EXCESS_PAYITEM_ID); }
//        set { this._SMHR_HRA_EXCESS_PAYITEM_ID = value; }
//    }
//    private int _SMHR_HRA_TAX_EXEMPT_ID;
//    public int SMHR_HRA_TAX_EXEMPT_ID
//    {
//        get { return (this._SMHR_HRA_TAX_EXEMPT_ID); }
//        set { this._SMHR_HRA_TAX_EXEMPT_ID = value; }
//    }
//    private int _SMHR_HRA_EMP_ID;
//    public int SMHR_HRA_EMP_ID
//    {
//        get { return (this._SMHR_HRA_EMP_ID); }
//        set { this._SMHR_HRA_EMP_ID = value; }
//    }
//    private string _SMHR_HRA_EMP_HRAVALUE;
//    public string SMHR_HRA_EMP_HRAVALUE
//    {
//        get { return (this._SMHR_HRA_EMP_HRAVALUE); }
//        set { this._SMHR_HRA_EMP_HRAVALUE = value; }
//    }
//    private string _SMHR_HRA_EMP_ACTUALRENT_PAID;
//    public string SMHR_HRA_EMP_ACTUALRENT_PAID
//    {
//        get { return (this._SMHR_HRA_EMP_ACTUALRENT_PAID); }
//        set { this._SMHR_HRA_EMP_ACTUALRENT_PAID = value; }
//    }
//    private string _SMHR_HRA_EMP_EXCESSSALARY;
//    public string SMHR_HRA_EMP_EXCESSSALARY
//    {
//        get { return (this._SMHR_HRA_EMP_EXCESSSALARY); }
//        set { this._SMHR_HRA_EMP_EXCESSSALARY = value; }
//    }
//    private string _SMHR_HRA_EMP_TAX_LIMIT;
//    public string SMHR_HRA_EMP_TAX_LIMIT
//    {
//        get { return (this._SMHR_HRA_EMP_TAX_LIMIT); }
//        set { this._SMHR_HRA_EMP_TAX_LIMIT = value; }
//    }
//    private string _SMHR_HRA_EMP_EXEMPTAMOUNT;
//    public string SMHR_HRA_EMP_EXEMPTAMOUNT
//    {
//        get { return (this._SMHR_HRA_EMP_EXEMPTAMOUNT); }
//        set { this._SMHR_HRA_EMP_EXEMPTAMOUNT = value; }
//    }

//    private DateTime _SMHR_HRA_CREATEDDATE;
//    public DateTime SMHR_HRA_CREATEDDATE
//    {
//        get { return (this._SMHR_HRA_CREATEDDATE); }
//        set { this._SMHR_HRA_CREATEDDATE = value; }
//    }
  
//    private int _SMHR_HRA_LASTMDFBY;
//    public int SMHR_HRA_LASTMDFBY
//    {
//        get { return (this._SMHR_HRA_LASTMDFBY); }
//        set { this._SMHR_HRA_LASTMDFBY = value; }
//    }

//    private int _SMHR_HRA_CREATEDBY;
//    public int SMHR_HRA_CREATEDBY
//    {
//        get { return (this._SMHR_HRA_CREATEDBY); }
//        set { this._SMHR_HRA_CREATEDBY = value; }
//    }
//    private int _SMHR_ORG_ID;
//    public int SMHR_ORG_ID
//    {
//        get { return (this._SMHR_ORG_ID); }
//        set { this._SMHR_ORG_ID = value; }
//    }
   

  
//    private DateTime _SMHR_HRA_LASTMDFDATE;
//    public DateTime SMHR_HRA_LASTMDFDATE
//    {
//        get { return (this._SMHR_HRA_LASTMDFDATE); }
//        set { this._SMHR_HRA_LASTMDFDATE = value; }
//    }

//    private int _Mode;
//    public int Mode
//    {
//        get { return (this._Mode); }
//        set { this._Mode = value; }
//    }


//}
//#endregion

#region SPMS_APPRAISALCYCLE
public class PMS_Appraisalcycle : PMS_MAIN
{
    private int _APPRCYCLE_ID;
    public int APPRCYCLE_ID
    {
        get { return (this._APPRCYCLE_ID); }
        set { this._APPRCYCLE_ID = value; }

    }

    private string _APPRCYCLE_NAME;
    public string APPRCYCLE_NAME
    {
        get { return (this._APPRCYCLE_NAME); }
        set { this._APPRCYCLE_NAME = value; }
    }

    private string _APPRCYCLE_DESC;
    public string APPRCYCLE_DESC
    {
        get { return (this._APPRCYCLE_DESC); }
        set { this._APPRCYCLE_DESC = value; }
    }

    private int _APPRCYCLE_PERIOD;
    public int APPRCYCLE_PERIOD
    {
        get { return (this._APPRCYCLE_PERIOD); }
        set { this._APPRCYCLE_PERIOD = value; }
    }

    private string _APPRCYCLE_START_MONTH;
    public string APPRCYCLE_START_MONTH
    {
        get { return (this._APPRCYCLE_START_MONTH); }
        set { this._APPRCYCLE_START_MONTH = value; }
    }

    private string _APPRCYCLE_END_MONTH;
    public string APPRCYCLE_END_MONTH
    {
        get { return (this._APPRCYCLE_END_MONTH); }
        set { this._APPRCYCLE_END_MONTH = value; }
    }

    private int _MODE;
    public int MODE
    {
        get { return (this._MODE); }
        set { this._MODE = value; }
    }
   
    private int _APPRCYCLE_MODIFIEDBY;
    public int APPRCYCLE_MODIFIEDBY
    {
        get { return this._APPRCYCLE_MODIFIEDBY; }
        set { this._APPRCYCLE_MODIFIEDBY = value; }
    }

    private DateTime _APPRCYCLE_MODIFIED_DATE;
    public DateTime APPRCYCLE_MODIFIED_DATE
    {
        get { return (this._APPRCYCLE_MODIFIED_DATE); }
        set { this._APPRCYCLE_MODIFIED_DATE = value; }
    }

    private DateTime _APPCYCLE_STARTDATE;
    public DateTime APPCYCLE_STARTDATE
    {
        get { return (this._APPCYCLE_STARTDATE); }
        set { this._APPCYCLE_STARTDATE = value; }
    }
    private DateTime _APPCYCLE_ENDDATE;
    public DateTime APPCYCLE_ENDDATE
    {
        get { return (this._APPCYCLE_ENDDATE); }
        set { this._APPCYCLE_ENDDATE = value; }
    }
    private bool _APPRCYCLE_ISACTIVE;
    public bool APPRCYCLE_ISACTIVE
    {
        get { return (this._APPRCYCLE_ISACTIVE); }
        set { this._APPRCYCLE_ISACTIVE = value; }
    }
    private int _APPRCYCLE_ORG_ID;
    public int APPRCYCLE_ORG_ID
    {
        get { return this._APPRCYCLE_ORG_ID; }
        set { this._APPRCYCLE_ORG_ID = value; }
    }
    private int _APPRCYCLE_BU_ID;
    public int APPRCYCLE_BU_ID
    {
        get { return this._APPRCYCLE_BU_ID; }
        set { this._APPRCYCLE_BU_ID = value; }
    }
    private bool _APPRCYCLE_SELFAPPRAISAL;
    public bool APPRCYCLE_SELFAPPRAISAL
    {
        get { return (this._APPRCYCLE_SELFAPPRAISAL); }
        set { this._APPRCYCLE_SELFAPPRAISAL = value; }
    }

    private int _APPRCYCLE_APPROVAL_STATUS;
    public int APPRCYCLE_APPROVAL_STATUS
    {
        get { return (this._APPRCYCLE_APPROVAL_STATUS); }
        set { this._APPRCYCLE_APPROVAL_STATUS = value; }
    }
}
#endregion



#region PMS_FEEDBACK
public class PMS_FEEDBACK : SPMS_MAIN
{
    public PMS_FEEDBACK(int __FEEDBACK_ID)
    {
        this._FEEDBACK_ID = __FEEDBACK_ID;
    }

    public PMS_FEEDBACK()
    {
    }
    private int _FEEDBACK_ID;
    public int FEEDBACK_ID
    {
        get { return (this._FEEDBACK_ID); }
        set { this._FEEDBACK_ID = value; }
    }

    private string _FEEDBACK_COMMENTS;
    public string FEEDBACK_COMMENTS
    {
        get { return (this._FEEDBACK_COMMENTS); }
        set { this._FEEDBACK_COMMENTS = value; }
    }

    private int _FEEDBACK_RATING;
    public int FEEDBACK_RATING
    {
        get { return (this._FEEDBACK_RATING); }
        set { this._FEEDBACK_RATING = value; }
    }


    private DateTime _FEEDBACK_DATE;
    public DateTime FEEDBACK_DATE
    {
        get { return (this._FEEDBACK_DATE); }
        set { this._FEEDBACK_DATE = value; }
    }
    private int _FEEDBACK_MGR_EMP_ID;
    public int FEEDBACK_MGR_EMP_ID
    {
        get { return (this._FEEDBACK_MGR_EMP_ID); }
        set { this._FEEDBACK_MGR_EMP_ID = value; }
    }


    private int _FEEDBACK_CREATEDBY;
    public int FEEDBACK_CREATEDBY
    {
        get { return (this._FEEDBACK_CREATEDBY); }
        set { this._FEEDBACK_CREATEDBY = value; }
    }

    private DateTime _FEEDBACK_CREATEDDATE;
    public DateTime FEEDBACK_CREATEDDATE
    {
        get { return (this._FEEDBACK_CREATEDDATE); }
        set { this._FEEDBACK_CREATEDDATE = value; }
    }

    private int _FEEDBACK_LASTMDFBY;
    public int FEEDBACK_LASTMDFBY
    {
        get { return (this._FEEDBACK_LASTMDFBY); }
        set { this._FEEDBACK_LASTMDFBY = value; }
    }

    private DateTime _FEEDBACK_LASTMDFDATE;
    public DateTime FEEDBACK_LASTMDFDATE
    {
        get { return (this._FEEDBACK_LASTMDFDATE); }
        set { this._FEEDBACK_LASTMDFDATE = value; }
    }

    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }


}
#endregion


#region PMS_EMPSETUP
public class PMS_EMPSETUP : SPMS_MAIN
{
    public PMS_EMPSETUP(int __EMP_SETUP_ID)
    {
        this._EMP_SETUP_ID = __EMP_SETUP_ID;
    }

    public PMS_EMPSETUP()
    {
    }
    private int _EMP_SETUP_ID;
    public int EMP_SETUP_ID
    {
        get { return (this._EMP_SETUP_ID); }
        set { this._EMP_SETUP_ID = value; }
    }


    private int _BU_ID;
    public int BU_ID
    {
        get { return (this._BU_ID); }
        set { this._BU_ID = value; }
    }



    private int _EMP_ID;
    public int EMP_ID
    {
        get { return (this._EMP_ID); }
        set { this._EMP_ID = value; }
    }

    private int _REPORTINGMGR_ID;
    public int REPORTINGMGR_ID
    {
        get { return (this._REPORTINGMGR_ID); }
        set { this._REPORTINGMGR_ID = value; }
    }
    private int _GENERALMGR_ID;
    public int GENERALMGR_ID
    {
        get { return (this._GENERALMGR_ID); }
        set { this._GENERALMGR_ID = value; }
    }
    private int _EMP_SETUP_CREATEDBY;
    public int EMP_SETUP_CREATEDBY
    {
        get { return (this._EMP_SETUP_CREATEDBY); }
        set { this._EMP_SETUP_CREATEDBY = value; }
    }

    private DateTime _EMP_SETUP_CREATEDDATE;
    public DateTime EMP_SETUP_CREATEDDATE
    {
        get { return (this._EMP_SETUP_CREATEDDATE); }
        set { this._EMP_SETUP_CREATEDDATE = value; }
    }

    private int _EMP_SETUP_LASTMDFBY;
    public int EMP_SETUP_LASTMDFBY
    {
        get { return (this._EMP_SETUP_LASTMDFBY); }
        set { this._EMP_SETUP_LASTMDFBY = value; }
    }

    private DateTime _EMP_SETUP_LASTMDFDATE;
    public DateTime EMP_SETUP_LASTMDFDATE
    {
        get { return (this._EMP_SETUP_LASTMDFDATE); }
        set { this._EMP_SETUP_LASTMDFDATE = value; }
    }

    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }
}



#endregion

#region PMS_LOGININFO
public class PMS_LOGININFO : SPMS_MAIN
{

    private int _EMPID;
    public int EMPID
    {
        get { return (this._EMPID); }
        set { this._EMPID = value; }
    }

    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }

    private int _bUID;

    public int BUID
    {
        get
        {
            return (this._bUID);
        }
        set
        {
            this._bUID = value;
        }
    }

}

    #endregion

#region PMS_GETEMPLOYEE
public class PMS_GETEMPLOYEE : SPMS_MAIN
{
   
  

    private int _BU_ID;
    public int BU_ID
    {
        get { return (this._BU_ID); }
        set { this._BU_ID = value; }
    }
    private int _GS_APPRAISAL_CYCLE;
    public int GS_APPRAISAL_CYCLE
    {
        get { return (this._GS_APPRAISAL_CYCLE); }
        set { this._GS_APPRAISAL_CYCLE = value; }
    }
   

    private int _EMP_ID;
    public int EMP_ID
    {
        get { return (this._EMP_ID); }
        set { this._EMP_ID = value; }
    }

    private int _REPORTINGMGR_ID;
    public int REPORTINGMGR_ID
    {
        get { return (this._REPORTINGMGR_ID); }
        set { this._REPORTINGMGR_ID = value; }
    }
    private int _GENERALMGR_ID;
    public int GENERALMGR_ID
    {
        get { return (this._GENERALMGR_ID); }
        set { this._GENERALMGR_ID = value; }
    }
  

    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }
}



#endregion


#region notification
public class PMS_NOTIFICATION : SPMS_MAIN
{
    private int _EMPID;
    public int EMPID
    {
        get { return (this._EMPID); }
        set { this._EMPID = value; }
    }


    private int _RMID;
    public int RMID
    {
        get { return (this._RMID); }
        set { this._RMID = value; }
    }


    private int _APPRAISAL_CYCLE;
    public int APPRAISAL_CYCLE
    {
        get { return (this._APPRAISAL_CYCLE); }
        set { this._APPRAISAL_CYCLE = value; }
    }
    private int _GMID;
    public int GMID
    {
        get { return (this._GMID); }
        set { this._GMID = value; }
    }
}

#endregion


#region SPMS_APRAISALSTATUS

public class SPMS_APRAISALSTATUS : SPMS_MAIN
{
    public SPMS_APRAISALSTATUS(int __APPSTATUS_ID)
    {
        this._APPSTATUS_ID = __APPSTATUS_ID;
    }

     public SPMS_APRAISALSTATUS()
    {
    }
     private int _APPSTATUS_ID;
     public int APPSTATUS_ID
    {
        get { return (this._APPSTATUS_ID); }
        set { this._APPSTATUS_ID = value; }
    }


    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }
    private int _APP_STATUS;
    public int APP_STATUS
    {
        get { return (this._APP_STATUS); }
        set { this._APP_STATUS = value; }
    }
    private int _APP_STATUS_APPRAISALCYCLE;
    public int APP_STATUS_APPRAISALCYCLE
    {
        get { return (this._APP_STATUS_APPRAISALCYCLE); }
        set { this._APP_STATUS_APPRAISALCYCLE = value; }
    }
    private int _APP_EMP_ID;
    public int APP_EMP_ID
    {
        get { return (this._APP_EMP_ID); }
        set { this._APP_EMP_ID = value; }
    }
    private int _APP_STATUS_ORG_ID;
    public int APP_STATUS_ORG_ID
    {
        get { return (this._APP_STATUS_ORG_ID); }
        set { this._APP_STATUS_ORG_ID = value; }
    }
    private decimal _APP_FINALRTG;
    public decimal APP_FINALRTG
    {
        get { return (this._APP_FINALRTG); }
        set { this._APP_FINALRTG = value; }
    }

    private decimal _APP_POTENTIALRTG;
    public decimal APP_POTENTIALRTG
    {
        get { return (this._APP_POTENTIALRTG); }
        set { this._APP_POTENTIALRTG = value; }
    }
    private decimal _APP_BUSINEESRTG;
    public decimal APP_BUSINEESRTG
    {
        get { return (this._APP_BUSINEESRTG); }
        set { this._APP_BUSINEESRTG = value; }
    }

    private string _APP_OVERALLRTG;
    public string APP_OVERALLRTG
    {
        get { return (this._APP_OVERALLRTG); }
        set { this._APP_OVERALLRTG = value; }
    }



    private int _APP_CREATEDBY;
    public int APP_CREATEDBY
    {
        get { return (this._APP_CREATEDBY); }
        set { this._APP_CREATEDBY = value; }
    }

    private DateTime _APP_CREATEDDATE;
    public DateTime APP_CREATEDDATE
    {
        get { return (this._APP_CREATEDDATE); }
        set { this._APP_CREATEDDATE = value; }
    }

    private int _APP_LASTMDFBY;
    public int APP_LASTMDFBY
    {
        get { return (this._APP_LASTMDFBY); }
        set { this._APP_LASTMDFBY = value; }
    }

    private DateTime _APP_LASTMDFDATE;
    public DateTime APP_LASTMDFDATE
    {
        get { return (this._APP_LASTMDFDATE); }
        set { this._APP_LASTMDFDATE = value; }
    }






}
#endregion