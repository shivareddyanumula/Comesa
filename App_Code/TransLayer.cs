using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public enum operation
{
    Select,
    Insert,
    Edit,
    Update,
    Check,
    Delete,
    Empty,
    Validate,
    EMPTY1,
    Check1,
    UpdateSTATUS,
    Insert1,
    Check_New,
    Insert_New,
    Update_New,
    Select_New,
    Select_EMPID,
    Select_Dept,
    Select_Emp,
    Select_Pos,
    FeedBack,
    E,
    P,
    D,
    Select_Hike,
    Select_Period,
    Select2,
    Selects,
    Update1,
    PERIOD,
    Select3,
    Select_Self,
    Empty_Self,
    Empty_Self_Edit,
    Get,
    Select1,
    Delete1,
    Approve,
    Empty1,
    Login,
    Login1,
    Login2,
    Login3,
    Login4,
    Login5,
    CheckEmp,
    Get_BU,
    Update_Bu,
    Select_admins,
    Self,
    Self_Edit,
    Validate1,
    EMPTY,
    Get_ID,
    Counseller,
    load,
    Start,
    ADMIN,
    TRAINER,
    Course,
    New,
    MODE,
    MODE2,
    MODE6,
    MODE1,
    SELECTEMPLOYEE,
    SELECTEMPLOYEE1,
    SELECTEMPLOYEE2,
    loadapplicant,
    LOADSALARY,
    loadleavestruct,
    GetAttendance,
    Combination,
    ChkSuperModuleID,
    GET_MONTH,
    Get_BULocalization,
    EMPTY_R,
    FILLEMP_Edit,
    Empty2,
    EMP_COPY,
    Check_Emp,
    Check2,
    Available,
    Empty_PH,
    getdeptwise,
    SELECTSUPERVISOR,
    SelectLocal,
    CHKPAY,
    CHKPAYAPP,
    getEmp,
    Count,
    Select_Doj,
    SELECTEMPLOYEE3,
    CHKATT,
    EMPDETAILS,
    CheckSkype,
    CheckPass,
    DelPic,
    Select4,
    DelDoc,
    GetPass,
    getLogin,
    EMPALL,
    Chk,
    Self_Transfer,
    Self_Count,
    CHK_EMPMAIL,
    CHKPAY2,
    JOBPOSITIONS,
    POSITIONSGRADE,
    GETVACANCY,
    GET_EMPASSETS,
    CHECKEXISTS,
    CHECKASSETEXISTS,
    GETGRADE,
    EmployeesDirectoratewise,
    EmployeesDepartmentwise,
    EmployeesSubDepartmentWise,
    EmployeesBUwise,
    GetEmployeeDOJDOB,
    GetEmployeePensionDetails,
    Finalized,
    CopySlabs,
    EmployeeSlabs,
    Employeegrades,
    GET_ALL_ACTIVITIES,
    CHECKDUPLICATE,
    GET_EQUIPMENT,
    GET_ALLEQUIPMENTS,
    GET_AREA,
    GET_ALLAREAS,
    CHECKSLABPERIODS,
    VALIDATEPERIOD,
    GETIDENTITY,
    INSERT_INSPECTION,
    INSERT_INSPECTION_AREA,
    UPDATE_INSPECTION_AREA,
    GRIEVANCETYPE,
    DISCIPLINARYTYPE,
    GET_ALLINSPECTIONS,
    GET_INSPECTIONS,
    COMMITTEE,
    GET_INSPECTIONS_ASSIGNEDTO,
    GRIEVANCEACTION,
    DISCIPLINARYACTION,
    get_Employee_Assets_Assigned,
    get_All_Assets,
    get_Assets_Assigned,
    Select_DeptHead,
    ISCOMPLIANT,
    Scale,
    Employee,
    EmployeeGrade,
    Insert2,
    Offline,
    Online,
    CountEmailID,
    FINANCIALPERIODSINCLUDED,
    FINANCIALPERIODSEXCLUDED,
    Course2,
    Course3,
    IncrementCycles,
    LoanVoucher,
    USERLOANEMI,
    USERLOANTRANEMI,
    EmployeeCount,
    details,
    GET,
    DepenencyCheck,
    CHK_EMAILORG,
    chkholiday,
    check,
    CurrencyRate,
    LOADUSERGROUP,
    EDUAPPROVE,
    EDUFINALIZE,
    LOADFINALIZE,
    MEDAPPROVE,
    MEDFINALIZE,
    loaneligibility,
    checkOThours
}

#region SMHR_MAIN

public class SMHR_MAIN
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
    private bool _HR_MASTER_ISDELETED;
    public bool HR_MASTER_ISDELETED
    {
        get { return this._HR_MASTER_ISDELETED; }
        set { this._HR_MASTER_ISDELETED = value; }
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
    public string SDATE { get; set; }
    public string EDATE { get; set; }
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


    private int _ORGANISATION_ID;

    public int ORGANISATION_ID
    {
        get { return (this._ORGANISATION_ID); }
        set { this._ORGANISATION_ID = value; }
    }
    private int? _DIRECTORATE_ID;
    public int? DIRECTORATE_ID
    {
        get { return (this._DIRECTORATE_ID); }
        set { this._DIRECTORATE_ID = value; }
    }
    private int? _DEPARTMENT_ID;
    public int? DEPARTMENT_ID
    {
        get { return (this._DEPARTMENT_ID); }
        set { this._DEPARTMENT_ID = value; }
    }
    private int _SUBDEPARTMENT_ID;
    public int SUBDEPARTMENT_ID
    {
        get { return (this._SUBDEPARTMENT_ID); }
        set { this._SUBDEPARTMENT_ID = value; }
    }
    private int? _COMMITTEE_ID;
    public int? COMMITTEE_ID
    {
        get { return (this._COMMITTEE_ID); }
        set { this._COMMITTEE_ID = value; }
    }

    private int _LOGIN_ID;

    public int LOGIN_ID
    {
        get { return (this._LOGIN_ID); }
        set { this._LOGIN_ID = value; }
    }
    private int _mODE;

    public int MODE
    {
        get
        {
            return (this._mODE);
        }
        set
        {
            this._mODE = value;
        }
    }


}

#endregion

#region SMHR_MASTERS

public class SMHR_MASTERS : SMHR_MAIN
{
    private int _MASTER_ID;
    public int MASTER_ID
    {
        get { return _MASTER_ID; }
        set { _MASTER_ID = value; }
    }
    private int _HR_MASTER_ORGANISATION_ID;
    public int HR_MASTER_ORGANISATION_ID
    {
        get { return _HR_MASTER_ORGANISATION_ID; }
        set { _HR_MASTER_ORGANISATION_ID = value; }
    }
    private String _MASTER_PRIORITYID;
    public String MASTER_PRIORITYID
    {
        get { return _MASTER_PRIORITYID; }
        set { _MASTER_PRIORITYID = value; }
    }
    private String _MASTER_TYPE;
    public String MASTER_TYPE
    {
        get { return _MASTER_TYPE; }
        set { _MASTER_TYPE = value; }
    }

    private String _MASTER_CODE;
    public String MASTER_CODE
    {
        get { return _MASTER_CODE; }
        set { _MASTER_CODE = value; }
    }

    private String _MASTER_DESC;
    public String MASTER_DESC
    {
        get { return this._MASTER_DESC; }
        set { this._MASTER_DESC = value; }
    }
    private bool _IsActive;
    public bool IsActive
    {
        get { return (this._IsActive); }
        set { this._IsActive = value; }
    }
    private bool _MASTER_ISDELETED;
    public bool MASTER_ISDELETED
    {
        get { return this._MASTER_ISDELETED; }
        set { this._MASTER_ISDELETED = value; }
    }
    private int _BANKID;
    public int BANKID
    {
        get { return this._BANKID; }
        set { this._BANKID = value; }
    }

}


#endregion

#region SMHR_ACTIONTAKEN

public class SMHR_ACTIONTAKEN : SMHR_MAIN
{
    public int ACTION_ID { get; set; }
    public int ACTION_DISPORGRIV_ID { get; set; }
    public int ACTION_GRIVENCE_ID { get; set; }
    public DateTime? ACTION_DATE { get; set; }
    public DateTime? ACTION_SUSPDFROMDATE { get; set; }

    public DateTime? ACTION_SUSPDTODATE { get; set; }

    public string ACTION_DISCUSSEDWITH { get; set; }
    public DateTime? ACTION_DISCUSSEDDATE { get; set; }
    public string ACTION_OTHERMEMBERS { get; set; }
    public string ACTION_COURT_ATTACHMENT { get; set; }
    public string ACTION_REASON { get; set; }


    //public operations operation { get; set; }
    public int ACTION_CREATED_BY { get; set; }
    public int ACTION_LASTMODIFIED_BY { get; set; }
    public DateTime? ACTION_CREATED_DATE { get; set; }
    public DateTime? ACTION_LASTMODIFIEDDATE { get; set; }
    public int ACTION_ORGANISATION_ID { get; set; }

}

#endregion

#region SMHR_BUSINESSUNIT

public class SMHR_BUSINESSUNIT : SMHR_MAIN
{
    public SMHR_BUSINESSUNIT(int? __BUSINESSUNIT_ID)
    {
        this._BUSINESSUNIT_ID = __BUSINESSUNIT_ID;
    }

    public SMHR_BUSINESSUNIT()
    {
    }

    int BUSINESSUNIT_LOCALISATION;

    public int BUSINESSUNIT_LOCALISATION1
    {
        get
        {
            return BUSINESSUNIT_LOCALISATION;
        }
        set
        {
            BUSINESSUNIT_LOCALISATION = value;
        }
    }
    private bool _IS_VARIABLEPAY;
    public bool IS_VARIABLEPAY
    {
        get { return this._IS_VARIABLEPAY; }
        set { this._IS_VARIABLEPAY = value; }
    }

    private bool _IS_EMPCODE_MANUAL;
    public bool IS_EMPCODE_MANUAL
    {
        get { return this._IS_EMPCODE_MANUAL; }
        set { this._IS_EMPCODE_MANUAL = value; }
    }
    private string _REPORTINGEMPLOYEE;
    public string REPORTINGEMPLOYEE
    {
        get { return this._REPORTINGEMPLOYEE; }
        set { this._REPORTINGEMPLOYEE = value; }
    }

    private int? _BUSINESSUNIT_ID;
    public int? BUSINESSUNIT_ID
    {
        get { return this._BUSINESSUNIT_ID; }
        set { this._BUSINESSUNIT_ID = value; }
    }

    private string _BUSINESSUNIT_CODE;
    public string BUSINESSUNIT_CODE
    {
        get { return (this._BUSINESSUNIT_CODE); }
        set { this._BUSINESSUNIT_CODE = value; }
    }


    private string _BUSINESSUNIT_LOGO;
    public string BUSINESSUNIT_LOGO
    {
        get { return (this._BUSINESSUNIT_LOGO); }
        set { this._BUSINESSUNIT_LOGO = value; }
    }
    private string _BUSINESSUNIT_LOGO_FULLPATH;
    public string BUSINESSUNIT_LOGO_FULLPATH
    {
        get { return (this._BUSINESSUNIT_LOGO_FULLPATH); }
        set { this._BUSINESSUNIT_LOGO_FULLPATH = value; }
    }

    private Boolean _BUSINESSUNIT_ISMETRO;
    public Boolean BUSINESSUNIT_ISMETRO
    {
        get { return (this._BUSINESSUNIT_ISMETRO); }
        set { this._BUSINESSUNIT_ISMETRO = value; }
    }
    private string _BUSINESSUNIT_DESC;
    public string BUSINESSUNIT_DESC
    {
        get { return (this._BUSINESSUNIT_DESC); }
        set { this._BUSINESSUNIT_DESC = value; }
    }

    private int? _BUSINESSUNIT_CATAGORY_ID;
    public int? BUSINESSUNIT_CATAGORY_ID
    {
        get { return (this._BUSINESSUNIT_CATAGORY_ID); }
        set { this._BUSINESSUNIT_CATAGORY_ID = value; }
    }

    private int? _BUSINESSUNIT_PARENT_BUSINESSUNIT_ID;

    public int? BUSINESSUNIT_PARENT_BUSINESSUNIT_ID
    {
        get { return (this._BUSINESSUNIT_PARENT_BUSINESSUNIT_ID); }
        set { this._BUSINESSUNIT_PARENT_BUSINESSUNIT_ID = value; }
    }

    private int? _BUSINESSUNIT_CURRENCY_ID;
    public int? BUSINESSUNIT_CURRENCY_ID
    {
        get { return (this._BUSINESSUNIT_CURRENCY_ID); }
        set { this._BUSINESSUNIT_CURRENCY_ID = value; }
    }

    private int? _BUSINESSUNIT_DATEFORMAT_ID;
    public int? BUSINESSUNIT_DATEFORMAT_ID
    {
        get { return (this._BUSINESSUNIT_DATEFORMAT_ID); }
        set { this._BUSINESSUNIT_DATEFORMAT_ID = value; }
    }

    private string _BUSINESSUNIT_ADDRESS;
    public string BUSINESSUNIT_ADDRESS
    {
        get { return (this._BUSINESSUNIT_ADDRESS); }
        set { this._BUSINESSUNIT_ADDRESS = value; }
    }

    private bool? _BUSINESSUNIT_OVERTIME;
    public bool? BUSINESSUNIT_OVERTIME
    {
        get { return (this._BUSINESSUNIT_OVERTIME); }
        set { this._BUSINESSUNIT_OVERTIME = value; }
    }


    private string _BUSINESSUNIT_AGE;
    public string BUSINESSUNIT_AGE
    {
        get { return (this._BUSINESSUNIT_AGE); }
        set { this._BUSINESSUNIT_AGE = value; }
    }

    private string _BUSINESSUNIT_CALENDERYEAR;
    public string BUSINESSUNIT_CALENDERYEAR
    {
        get { return (this._BUSINESSUNIT_CALENDERYEAR); }
        set { this._BUSINESSUNIT_CALENDERYEAR = value; }
    }

    private string _BUSINESSUNIT_FISCALYEAR;
    public string BUSINESSUNIT_FISCALYEAR
    {
        get { return (this._BUSINESSUNIT_FISCALYEAR); }
        set { this._BUSINESSUNIT_FISCALYEAR = value; }
    }

    private int? _BUSINESSUNIT_COUNTRY_ID;
    public int? BUSINESSUNIT_COUNTRY_ID
    {
        get { return (this._BUSINESSUNIT_COUNTRY_ID); }
        set { this._BUSINESSUNIT_COUNTRY_ID = value; }
    }

    private int? _BUSINESSUNIT_DIRECTORATE_ID;
    public int? BUSINESSUNIT_DIRECTORATE_ID
    {
        get { return (this._BUSINESSUNIT_DIRECTORATE_ID); }
        set { this._BUSINESSUNIT_DIRECTORATE_ID = value; }
    }

    private string _BUSINESSUNIT_PAYMENTMETHODS;
    public string BUSINESSUNIT_PAYMENTMETHODS
    {
        get { return (this._BUSINESSUNIT_PAYMENTMETHODS); }
        set { this._BUSINESSUNIT_PAYMENTMETHODS = value; }
    }

    private string _BUSINESSUNIT_EMPCODE;
    public string BUSINESSUNIT_EMPCODE
    {
        get { return (this._BUSINESSUNIT_EMPCODE); }
        set { this._BUSINESSUNIT_EMPCODE = value; }
    }

    private string _BUSINESSUNIT_PAYTYPE;
    public string BUSINESSUNIT_PAYTYPE
    {
        get { return (this._BUSINESSUNIT_PAYTYPE); }
        set { this._BUSINESSUNIT_PAYTYPE = value; }
    }

    private int _BUSINESSUNIT_SUPERVISOR;
    public int BUSINESSUNIT_SUPERVISOR
    {
        get { return (this._BUSINESSUNIT_SUPERVISOR); }
        set { this._BUSINESSUNIT_SUPERVISOR = value; }
    }

    private int mBUSINESSUNIT_ORGANISATION_ID;

    public int BUSINESSUNIT_ORGANISATION_ID
    {
        get
        {
            return (this.mBUSINESSUNIT_ORGANISATION_ID);
        }
        set
        {
            this.mBUSINESSUNIT_ORGANISATION_ID = value;
        }
    }

    private int _BU_LOGIN_ID;
    public int BU_LOGIN_ID
    {
        get { return (this._BU_LOGIN_ID); }
        set { this._BU_LOGIN_ID = value; }
    }

    private int _BUSINESSUNIT_EMP_ID;
    public int BUSINESSUNIT_EMP_ID
    {
        get { return (this._BUSINESSUNIT_EMP_ID); }
        set { this._BUSINESSUNIT_EMP_ID = value; }
    }

    private double _BUSINESSUNIT_BASICPERCENT;
    public double BUSINESSUNIT_BASICPERCENT
    {
        get { return (this._BUSINESSUNIT_BASICPERCENT); }
        set { this._BUSINESSUNIT_BASICPERCENT = value; }
    }
    private double _BUSINESSUNIT_NOOFHOURS;
    public double BUSINESSUNIT_NOOFHOURS
    {
        get { return (this._BUSINESSUNIT_NOOFHOURS); }
        set { this._BUSINESSUNIT_NOOFHOURS = value; }
    }
    private double _BUSINESSUNIT_FACTOR;
    public double BUSINESSUNIT_FACTOR
    {
        get { return (this._BUSINESSUNIT_FACTOR); }
        set { this._BUSINESSUNIT_FACTOR = value; }
    }

    private Boolean _BUSINESSUNIT_ANNUALPROCESS;
    public Boolean BUSINESSUNIT_ANNUALPROCESS
    {
        get { return (this._BUSINESSUNIT_ANNUALPROCESS); }
        set { this._BUSINESSUNIT_ANNUALPROCESS = value; }
    }
    private string _BUSINESSUNIT_ABN_NO;
    public string BUSINESSUNIT_ABN_NO
    {
        get { return (this._BUSINESSUNIT_ABN_NO); }
        set { this._BUSINESSUNIT_ABN_NO = value; }
    }
}

#endregion

#region SMHR_LEAVEPROCESS

public class SMHR_LEAVEPROCESS : SMHR_MAIN
{
    public SMHR_LEAVEPROCESS(int _BUID)
    {
        this._BUID = _BUID;
    }

    public SMHR_LEAVEPROCESS()
    {
    }

    private int _BUID;
    public int BUID
    {
        get { return (this._BUID); }
        set { this._BUID = value; }
    }

    private int _FROMPERIOD;
    public int FROMPERIOD
    {
        get { return (this._FROMPERIOD); }
        set { this._FROMPERIOD = value; }
    }

    private int _FINANCEPERIOD;
    public int FINANCEPERIOD
    {
        get { return (this._FINANCEPERIOD); }
        set { this._FINANCEPERIOD = value; }
    }

    private int _TOPERIOD;
    public int TOPERIOD
    {
        get { return (this._TOPERIOD); }
        set { this._TOPERIOD = value; }
    }
    private int _MODE;

    public int MODE
    {
        get { return (this._MODE); }
        set { this._MODE = value; }
    }


    public double LP_Enc_Leaves { get; set; }
    public double LP_CF_Leaves { get; set; }
    public int EMP_ID { get; set; }
    public int LEAVETYPE_ID { get; set; }
    public int ORGANISATION_ID { get; set; }
    public int LEAVEPROCESSTYPE { get; set; }
    public double TotalAmount { get; set; }
    public int EMPLOYEENAME { get; set; }
    public string Query { get; set; }
    public string PAYITEM { get; set; }
    public int PERIODELEMENT { get; set; }
    public int RADIOBUTTONTYPE { get; set; }
    public string PAYITEMID { get; set; }
    public int LPCREATEDBY { get; set; }
    public int LPPAYITEMHEAD { get; set; }
    public DateTime LPCREATEDDATE { get; set; }
    public int LP_STATUS { get; set; }
}
#endregion

#region BUSINESSUNIT DETAILS

public class SMHR_BUSINESSUNITIDDETAILS : SMHR_MAIN
{
    public SMHR_BUSINESSUNITIDDETAILS(int __BUIDDETAILS_ID)
    {
        this._BUIDDETAILS_ID = __BUIDDETAILS_ID;
    }

    public SMHR_BUSINESSUNITIDDETAILS()
    {
    }

    private int _BUIDDETAILS_ID;
    public int BUIDDETAILS_ID
    {
        get { return (this._BUIDDETAILS_ID); }
        set { this._BUIDDETAILS_ID = value; }
    }

    private string _BUIDDETAILS_BUID;
    public string BUIDDETAILS_BUID
    {
        get { return (this._BUIDDETAILS_BUID); }
        set { this._BUIDDETAILS_BUID = value; }
    }

    private string _BUIDDETAILS_NAME;
    public string BUIDDETAILS_NAME
    {
        get { return (this._BUIDDETAILS_NAME); }
        set { this._BUIDDETAILS_NAME = value; }
    }

    private string _BUIDDETAILS_DESCRIPTION;
    public string BUIDDETAILS_DESCRIPTION
    {
        get { return (this._BUIDDETAILS_DESCRIPTION); }
        set { this._BUIDDETAILS_DESCRIPTION = value; }
    }
    private string _BUIDDETAILS_VALUE;
    public string BUIDDETAILS_VALUE
    {
        get { return (this._BUIDDETAILS_VALUE); }
        set { this._BUIDDETAILS_VALUE = value; }
    }

}

#endregion

#region SMHR_BUSINESSUNITBANK

public class SMHR_BUSINESSUNITBANK : SMHR_MAIN
{
    public SMHR_BUSINESSUNITBANK(int __BUSUNTBANK_ID)
    {
        this._BUSUNTBANK_ID = __BUSUNTBANK_ID;
    }

    public SMHR_BUSINESSUNITBANK()
    {
    }

    private int _BUSUNTBANK_ID;
    public int BUSUNTBANK_ID
    {
        get { return (this._BUSUNTBANK_ID); }
        set { this._BUSUNTBANK_ID = value; }
    }

    private int _BUSUNTBANK_BUSINESSUNIT_ID;
    public int BUSUNTBANK_BUSINESSUNIT_ID
    {
        get { return (this._BUSUNTBANK_BUSINESSUNIT_ID); }
        set { this._BUSUNTBANK_BUSINESSUNIT_ID = value; }
    }

    private string _BUSUNTBANK_NAME;
    public string BUSUNTBANK_NAME
    {
        get { return (this._BUSUNTBANK_NAME); }
        set { this._BUSUNTBANK_NAME = value; }
    }

    private string _BUSUNTBANK_BRANCH;
    public string BUSUNTBANK_BRANCH
    {
        get { return (this._BUSUNTBANK_BRANCH); }
        set { this._BUSUNTBANK_BRANCH = value; }
    }

    private string _BUSUNTBANK_ADDRESS;
    public string BUSUNTBANK_ADDRESS
    {
        get { return (this._BUSUNTBANK_ADDRESS); }
        set { this._BUSUNTBANK_ADDRESS = value; }
    }

    private string _BUSUNTBANK_ACCOUNTNO;
    public string BUSUNTBANK_ACCOUNTNO
    {
        get { return (this._BUSUNTBANK_ACCOUNTNO); }
        set { this._BUSUNTBANK_ACCOUNTNO = value; }
    }

    private string _BUSUNTBANK_BSBCODE;
    public string BUSUNTBANK_BSBCODE
    {
        get { return (this._BUSUNTBANK_BSBCODE); }
        set { this._BUSUNTBANK_BSBCODE = value; }
    }


    private int _BUSUNTBANK_ISACTIVE;
    public int BUSUNTBANK_ISACTIVE
    {
        get { return (this._BUSUNTBANK_ISACTIVE); }
        set { this._BUSUNTBANK_ISACTIVE = value; }
    }

    private bool _BUSUNTBANK_ISDEFAULT;
    public bool BUSUNTBANK_ISDEFAULT
    {
        get { return (this._BUSUNTBANK_ISDEFAULT); }
        set { this._BUSUNTBANK_ISDEFAULT = value; }
    }

}

#endregion

#region SMHR_CATEGORY

public class SMHR_CATEGORY : SMHR_MAIN
{
    public SMHR_CATEGORY(int __CATEGORY_ID)
    {
        this._CATEGORY_ID = __CATEGORY_ID;
    }

    public SMHR_CATEGORY()
    {
    }

    private int _CATEGORY_ID;
    public int CATEGORY_ID
    {
        get { return (this._CATEGORY_ID); }
        set { this._CATEGORY_ID = value; }
    }

    private string _CATEGORY_CODE;
    public string CATEGORY_CODE
    {
        get { return (this._CATEGORY_CODE); }
        set { this._CATEGORY_CODE = value; }
    }

    private string _CATEGORY_DESC;
    public string CATEGORY_DESC
    {
        get { return (this._CATEGORY_DESC); }
        set { this._CATEGORY_DESC = value; }
    }

    private bool _CATEGORY_ISDELETED;
    public bool CATEGORY_ISDELETED
    {
        get { return (this._CATEGORY_ISDELETED); }
        set { this._CATEGORY_ISDELETED = value; }
    }

    private bool _CATEGORY_ISOVERTIME;
    public bool CATEGORY_ISOVERTIME
    {
        get { return (this._CATEGORY_ISOVERTIME); }
        set { this._CATEGORY_ISOVERTIME = value; }
    }

    private bool _CATEGORY_ISFISCALYEAR;
    public bool CATEGORY_ISFISCALYEAR
    {
        get { return (this._CATEGORY_ISFISCALYEAR); }
        set { this._CATEGORY_ISFISCALYEAR = value; }
    }

    private bool _CATEGORY_ISCURRENCY;
    public bool CATEGORY_ISCURRENCY
    {
        get { return (this._CATEGORY_ISCURRENCY); }
        set { this._CATEGORY_ISCURRENCY = value; }
    }

    private bool _CATEGORY_ISDATEFORMAT;
    public bool CATEGORY_ISDATEFORMAT
    {
        get { return (this._CATEGORY_ISDATEFORMAT); }
        set { this._CATEGORY_ISDATEFORMAT = value; }
    }

    private bool _CATEGORY_ISCOUNTRY;
    public bool CATEGORY_ISCOUNTRY
    {
        get { return (this._CATEGORY_ISCOUNTRY); }
        set { this._CATEGORY_ISCOUNTRY = value; }
    }

    private bool _CATEGORY_ISADDRESS;
    public bool CATEGORY_ISADDRESS
    {
        get { return (this._CATEGORY_ISADDRESS); }
        set { this._CATEGORY_ISADDRESS = value; }
    }

    private bool _CATEGORY_ISAGE;
    public bool CATEGORY_ISAGE
    {
        get { return (this._CATEGORY_ISAGE); }
        set { this._CATEGORY_ISAGE = value; }
    }

    private bool _CATEGORY_ISPAYMENTMODE;
    public bool CATEGORY_ISPAYMENTMODE
    {
        get { return (this._CATEGORY_ISPAYMENTMODE); }
        set { this._CATEGORY_ISPAYMENTMODE = value; }
    }

    private bool _CATEGORY_ISCALENDERYEAR;
    public bool CATEGORY_ISCALENDERYEAR
    {
        get { return (this._CATEGORY_ISCALENDERYEAR); }
        set { this._CATEGORY_ISCALENDERYEAR = value; }
    }

    private bool _CATEGORY_NEEDBANKINFO;
    public bool CATEGORY_NEEDBANKINFO
    {
        get { return (this._CATEGORY_NEEDBANKINFO); }
        set { this._CATEGORY_NEEDBANKINFO = value; }
    }

    private int mCATEGORY_ORGANISATION_ID;

    public int CATEGORY_ORGANISATION_ID
    {
        get
        {
            return (this.mCATEGORY_ORGANISATION_ID);
        }
        set
        {
            this.mCATEGORY_ORGANISATION_ID = value;
        }
    }

    private bool _cATEGORY_LOCALISATION;

    public bool CATEGORY_LOCALISATION
    {
        get
        {
            return (this._cATEGORY_LOCALISATION);
        }
        set
        {
            this._cATEGORY_LOCALISATION = value;
        }
    }


}

#endregion

#region SMHR_COUNTRY

public class SMHR_COUNTRY : SMHR_MAIN
{
    public SMHR_COUNTRY(int __COUNTRY_ID)
    {
        this._COUNTRY_ID = __COUNTRY_ID;
    }

    public SMHR_COUNTRY()
    {
    }
    private int _COUNTY_ID;
    public int COUNTY_ID
    {
        get { return (this._COUNTY_ID); }
        set { this._COUNTY_ID = value; }
    }
    private int _COUNTRY_ID;
    public int COUNTRY_ID
    {
        get { return (this._COUNTRY_ID); }
        set { this._COUNTRY_ID = value; }
    }

    private string _COUNTRY_CODE;
    public string COUNTRY_CODE
    {
        get { return (this._COUNTRY_CODE); }
        set { this._COUNTRY_CODE = value; }
    }

    private string _COUNTRY_NAME;
    public string COUNTRY_NAME
    {
        get { return (this._COUNTRY_NAME); }
        set { this._COUNTRY_NAME = value; }
    }
}

#endregion
#region SMHR_COUNTY

public class SMHR_COUNTY : SMHR_MAIN
{
    public SMHR_COUNTY(int __COUNTY_ID)
    {
        this._COUNTY_ID = __COUNTY_ID;
    }

    public SMHR_COUNTY()
    {
    }
    private int _COUNTY_ID;
    public int COUNTY_ID
    {
        get { return (this._COUNTY_ID); }
        set { this._COUNTY_ID = value; }
    }
    private int _COUNTRY_ID;
    public int COUNTRY_ID
    {
        get { return (this._COUNTRY_ID); }
        set { this._COUNTRY_ID = value; }
    }

    private string _COUNTY_CODE;
    public string COUNTY_CODE
    {
        get { return (this._COUNTY_CODE); }
        set { this._COUNTY_CODE = value; }
    }

    private string _COUNTY_NAME;
    public string COUNTY_NAME
    {
        get { return (this._COUNTY_NAME); }
        set { this._COUNTY_NAME = value; }
    }
}

#endregion
#region SMHR_DIRECTORATE

public class SMHR_DIRECTORATE : SMHR_MAIN
{
    public SMHR_DIRECTORATE(int __DIRECTORATE_ID)
    {
        this._DIRECTORATE_ID = __DIRECTORATE_ID;
    }

    public SMHR_DIRECTORATE()
    {
    }
    private int _DIRECTORATE_ID;
    public int DIRECTORATE_ID
    {
        get { return (this._DIRECTORATE_ID); }
        set { this._DIRECTORATE_ID = value; }
    }
    private int? _DIRECTORATE_PARENTDIRECTORATE_ID;
    public int? DIRECTORATE_PARENTDIRECTORATE_ID
    {
        get { return (this._DIRECTORATE_PARENTDIRECTORATE_ID); }
        set { this._DIRECTORATE_PARENTDIRECTORATE_ID = value; }
    }
    public int DIRECTORATE_STATUS { get; set; }
    private int _BUSINESSUNIT_ID;
    public int BUSINESSUNIT_ID
    {
        get { return (this._BUSINESSUNIT_ID); }
        set { this._BUSINESSUNIT_ID = value; }
    }
    private string _DIRECTORATE_CODE;
    public string DIRECTORATE_CODE
    {
        get { return (this._DIRECTORATE_CODE); }
        set { this._DIRECTORATE_CODE = value; }
    }

    private string _DIRECTORATE_NAME;
    public string DIRECTORATE_NAME
    {
        get { return (this._DIRECTORATE_NAME); }
        set { this._DIRECTORATE_NAME = value; }
    }
}

#endregion

#region SMHR_LOCATION

public class SMHR_LOCATION : SMHR_MAIN
{
    public SMHR_LOCATION(int __LOC_ID)
    {
        this._LOC_ID = __LOC_ID;
    }

    public SMHR_LOCATION()
    {
    }

    private int _LOC_ID;
    public int LOC_ID
    {
        get { return (this._LOC_ID); }
        set { this._LOC_ID = value; }
    }

    public string LOC_NAME { get; set; }
    public string LOC_DESC { get; set; }
    public Boolean ISACTIVE { get; set; }

}

#endregion

#region SMHR_CURRENCY

public class SMHR_CURRENCY : SMHR_MAIN
{
    public SMHR_CURRENCY(int __CURR_ID)
    {
        this._CURR_ID = __CURR_ID;
    }

    public SMHR_CURRENCY()
    {
    }


    private int _CURR_ID;
    public int CURR_ID
    {
        get { return (this._CURR_ID); }
        set { this._CURR_ID = value; }
    }

    private string _CURR_CODE;
    public string CURR_CODE
    {
        get { return (this._CURR_CODE); }
        set { this._CURR_CODE = value; }
    }

    private string _CURR_DESCRIPTION;
    public string CURR_DESCRIPTION
    {
        get { return (this._CURR_DESCRIPTION); }
        set { this._CURR_DESCRIPTION = value; }
    }

    private int _CURR_COUNTRY_ID;
    public int CURR_COUNTRY_ID
    {
        get { return (this._CURR_COUNTRY_ID); }
        set { this._CURR_COUNTRY_ID = value; }
    }

    private string _CURR_SYMBOL;
    public string CURR_SYMBOL
    {
        get { return (this._CURR_SYMBOL); }
        set { this._CURR_SYMBOL = value; }
    }

    private int _CURR_PRECESION;
    public int CURR_PRECESION
    {
        get { return (this._CURR_PRECESION); }
        set { this._CURR_PRECESION = value; }
    }

}

#endregion

#region SMHR_DATEFORMAT

public class SMHR_DATEFORMAT : SMHR_MAIN
{
    public SMHR_DATEFORMAT(int __DATEFORMAT_ID)
    {
        this._DATEFORMAT_ID = __DATEFORMAT_ID;
    }

    public SMHR_DATEFORMAT()
    {
    }

    private int _DATEFORMAT_ID;
    public int DATEFORMAT_ID
    {
        get { return (this._DATEFORMAT_ID); }
        set { this._DATEFORMAT_ID = value; }
    }

    private string _DATEFORMAT_CODE;
    public string DATEFORMAT_CODE
    {
        get { return (this._DATEFORMAT_CODE); }
        set { this._DATEFORMAT_CODE = value; }
    }

    private string _DATEFORMAT_DESC;
    public string DATEFORMAT_DESC
    {
        get { return (this._DATEFORMAT_DESC); }
        set { this._DATEFORMAT_DESC = value; }
    }

    private string _DATEFORMAT_FORMAT;
    public string DATEFORMAT_FORMAT
    {
        get { return (this._DATEFORMAT_FORMAT); }
        set { this._DATEFORMAT_FORMAT = value; }
    }
}

#endregion

#region SMHR_DASHBOARD
public class SMHR_DAHSBOARD : SMHR_MAIN
{
    private int _SMHR_DASHBOARD_EMP_ID;
    public int SMHR_DASHBOARD_EMP_ID
    {
        get { return _SMHR_DASHBOARD_EMP_ID; }
        set { _SMHR_DASHBOARD_EMP_ID = value; }
    }

    private int _SMHR_DASHBOARD_LOGIN_ID;
    public int SMHR_DASHBOARD_LOGIN_ID
    {
        get { return _SMHR_DASHBOARD_LOGIN_ID; }
        set { _SMHR_DASHBOARD_LOGIN_ID = value; }
    }

    private string _SMHR_DASHBOARD_PERIODNAME;
    public string SMHR_DASHBOARD_PERIODNAME
    {
        get { return (this._SMHR_DASHBOARD_PERIODNAME); }
        set { this._SMHR_DASHBOARD_PERIODNAME = value; }
    }

    private int _SMHR_DASHBOARD_PERIODID;
    public int SMHR_DASHBOARD_PERIODID
    {
        get { return (this._SMHR_DASHBOARD_PERIODID); }
        set { this._SMHR_DASHBOARD_PERIODID = value; }
    }

    public int SMHR_DASHBOARD_PRDDTL_ID { get; set; }

    public int SMHR_DASHBOARD_BU_ID { get; set; }
}
#endregion

#region SMHR_JOBS

public class SMHR_JOBS : SMHR_MAIN
{
    public SMHR_JOBS(int __JOBS_ID)
    {
        this._JOBS_ID = __JOBS_ID;
    }

    public SMHR_JOBS()
    {
    }

    private int _JOBS_ID;
    public int JOBS_ID
    {
        get { return (this._JOBS_ID); }
        set { this._JOBS_ID = value; }
    }

    private string _JOBS_CODE;
    public string JOBS_CODE
    {
        get { return (this._JOBS_CODE); }
        set { this._JOBS_CODE = value; }
    }
    public int JOBS_STATUS { get; set; }
    private string _JOBS_DESC;
    public string JOBS_DESC
    {
        get { return (this._JOBS_DESC); }
        set { this._JOBS_DESC = value; }
    }

    private int? _JOBS_GRADE_ID;
    public int? JOBS_GRADE_ID
    {
        get { return (this._JOBS_GRADE_ID); }
        set { this._JOBS_GRADE_ID = value; }
    }

    private decimal? _JOBS_MAXSAL;
    public decimal? JOBS_MAXSAL
    {
        get { return (this._JOBS_MAXSAL); }
        set { this._JOBS_MAXSAL = value; }
    }

    private decimal? _JOBS_MINSAL;
    public decimal? JOBS_MINSAL
    {
        get { return (this._JOBS_MINSAL); }
        set { this._JOBS_MINSAL = value; }
    }
    private string _JOBS_SKILLS;
    public string JOBS_SKILLS
    {
        get { return (this._JOBS_SKILLS); }
        set { this._JOBS_SKILLS = value; }
    }

    private string _JOBS_LOCATIONS;
    public string JOBS_LOCATIONS
    {
        get { return (this._JOBS_LOCATIONS); }
        set { this._JOBS_LOCATIONS = value; }
    }
    /*Import*/
    private string _SDATE;
    public string SDATE
    {
        get { return this._SDATE; }
        set { this._SDATE = value; }
    }

    private string _EDATE;
    public string EDATE
    {
        get { return this._EDATE; }
        set { this._EDATE = value; }
    }

}

#endregion

#region SMHR_RECUITMENTUPDATES
public class SMHR_RECRUITMENTUPDATES : SMHR_MAIN
{
    private DateTime _SMHR_CURRENTDATE;
    public DateTime SMHR_CURRENTDATE
    {
        get { return (this._SMHR_CURRENTDATE); }
        set { this._SMHR_CURRENTDATE = value; }
    }
}
#endregion

#region SMHR_DEPARTMENT

public class SMHR_DEPARTMENT : SMHR_MAIN
{
    private int _dEPARTMENT_ID;
    public int DEPARTMENT_ID
    {
        get { return (this._dEPARTMENT_ID); }
        set { this._dEPARTMENT_ID = value; }
    }

    private string _dEPARTMENT_NAME;
    public string DEPARTMENT_NAME
    {
        get { return (this._dEPARTMENT_NAME); }
        set { this._dEPARTMENT_NAME = value; }
    }

    private string _dEPARTMENT_DESC;
    public string DEPARTMENT_DESC
    {
        get { return (this._dEPARTMENT_DESC); }
        set { this._dEPARTMENT_DESC = value; }
    }
    private string _BUSINESSUNIT_NAME;
    public string BUSINESSUNIT_NAME
    {
        get { return (this._BUSINESSUNIT_NAME); }
        set { this._BUSINESSUNIT_NAME = value; }
    }
    private bool _DEPARTMENT_ISACTIVE;
    public bool DEPARTMENT_ISACTIVE
    {
        get { return (this._DEPARTMENT_ISACTIVE); }
        set { this._DEPARTMENT_ISACTIVE = value; }
    }

    private string _DEPARTMENT_CODE;
    public string DEPARTMENT_CODE
    {
        get { return (this._DEPARTMENT_CODE); }
        set { this._DEPARTMENT_CODE = value; }
    }
    private int _DIRECTORATE_ID;
    public int DIRECTORATE_ID
    {
        get { return (this._DIRECTORATE_ID); }
        set { this._DIRECTORATE_ID = value; }
    }
}

#endregion

#region SMHR_ORGANISATION

public class SMHR_ORGANISATION
{
    private int mORGANISATION_ID;


    public int ORGANISATION_ID
    {
        get
        {
            return (this.mORGANISATION_ID);
        }
        set
        {
            this.mORGANISATION_ID = value;
        }
    }

    private bool _mORGANISATION_IS_VARIABLEPAY;
    public bool ORGANISATION_IS_VARIABLEPAY
    {
        get { return this._mORGANISATION_IS_VARIABLEPAY; }
        set { this._mORGANISATION_IS_VARIABLEPAY = value; }
    }

    private int _mORGANISATION_VP_MINPERCENTAGE;
    public int ORGANISATION_VP_MINPERCENTAGE
    {
        get { return this._mORGANISATION_VP_MINPERCENTAGE; }
        set { this._mORGANISATION_VP_MINPERCENTAGE = value; }
    }

    private int _mORGANISATION_VP_MAXPERCENTAGE;
    public int ORGANISATION_VP_MAXPERCENTAGE
    {
        get { return this._mORGANISATION_VP_MAXPERCENTAGE; }
        set { this._mORGANISATION_VP_MAXPERCENTAGE = value; }
    }
    private int _mORGANISATION_NOOFZEROS;
    public int ORGANISATION_NOOFZEROS
    {
        get { return this._mORGANISATION_NOOFZEROS; }
        set { this._mORGANISATION_NOOFZEROS = value; }
    }
    private string mORGANISATION_NAME;

    public string ORGANISATION_NAME
    {
        get
        {
            return (this.mORGANISATION_NAME);
        }
        set
        {
            this.mORGANISATION_NAME = value;
        }
    }
    private int mORGANISATION_PACKAGE_ID;

    public int ORGANISATION_PACKAGE_ID
    {
        get
        {
            return (this.mORGANISATION_PACKAGE_ID);
        }
        set
        {
            this.mORGANISATION_PACKAGE_ID = value;
        }
    }

    private string mORGANISATION_DESC;

    public string ORGANISATION_DESC
    {
        get
        {
            return (this.mORGANISATION_DESC);
        }
        set
        {
            this.mORGANISATION_DESC = value;
        }
    }

    private string mORGANISATION_ADDRESS1;

    public string ORGANISATION_ADDRESS1
    {
        get
        {
            return (this.mORGANISATION_ADDRESS1);
        }
        set
        {
            this.mORGANISATION_ADDRESS1 = value;
        }
    }

    private string mORGANISATION_ADDRESS2;

    public string ORGANISATION_ADDRESS2
    {
        get
        {
            return (this.mORGANISATION_ADDRESS2);
        }
        set
        {
            this.mORGANISATION_ADDRESS2 = value;
        }
    }

    private string mORGANISATION_PHONE1;

    public string ORGANISATION_PHONE1
    {
        get
        {
            return (this.mORGANISATION_PHONE1);
        }
        set
        {
            this.mORGANISATION_PHONE1 = value;
        }
    }

    private string mORGANISATION_PHONE2;

    public string ORGANISATION_PHONE2
    {
        get
        {
            return (this.mORGANISATION_PHONE2);
        }
        set
        {
            this.mORGANISATION_PHONE2 = value;
        }
    }

    private string mORGANISATION_EMAIL;

    public string ORGANISATION_EMAIL
    {
        get
        {
            return (this.mORGANISATION_EMAIL);
        }
        set
        {
            this.mORGANISATION_EMAIL = value;
        }
    }

    private string mORGANISATION_ALTERNATE_EMAIL;

    public string ORGANISATION_ALTERNATE_EMAIL
    {
        get
        {
            return (this.mORGANISATION_ALTERNATE_EMAIL);
        }
        set
        {
            this.mORGANISATION_ALTERNATE_EMAIL = value;
        }
    }
    private string mORGANISATION_WEBSITE;

    public string ORGANISATION_WEBSITE
    {
        get
        {
            return (this.mORGANISATION_WEBSITE);
        }
        set
        {
            this.mORGANISATION_WEBSITE = value;
        }
    }

    private string mORGANISATION_CONTACTPERSON;

    public string ORGANISATION_CONTACTPERSON
    {
        get
        {
            return (this.mORGANISATION_CONTACTPERSON);
        }
        set
        {
            this.mORGANISATION_CONTACTPERSON = value;
        }
    }

    private bool mORGANISATION_ISDELETED;

    public bool ORGANISATION_ISDELETED
    {
        get
        {
            return (this.mORGANISATION_ISDELETED);
        }
        set
        {
            this.mORGANISATION_ISDELETED = value;
        }
    }

    private int mORGANISATION_CREATEDBY;

    public int ORGANISATION_CREATEDBY
    {
        get
        {
            return (this.mORGANISATION_CREATEDBY);
        }
        set
        {
            this.mORGANISATION_CREATEDBY = value;
        }
    }

    private DateTime mORGANISATION_CREATEDDATE;

    public DateTime ORGANISATION_CREATEDDATE
    {
        get
        {
            return (this.mORGANISATION_CREATEDDATE);
        }
        set
        {
            this.mORGANISATION_CREATEDDATE = value;
        }
    }

    private int mORGANISATION_LASTMDFBY;

    public int ORGANISATION_LASTMDFBY
    {
        get
        {
            return (this.mORGANISATION_LASTMDFBY);
        }
        set
        {
            this.mORGANISATION_LASTMDFBY = value;
        }
    }

    private DateTime mORGANISATION_LASTMDFDATE;

    public DateTime ORGANISATION_LASTMDFDATE
    {
        get
        {
            return (this.mORGANISATION_LASTMDFDATE);
        }
        set
        {
            this.mORGANISATION_LASTMDFDATE = value;
        }
    }

    private int mMODE;

    public int MODE
    {
        get
        {
            return (this.mMODE);
        }
        set
        {
            this.mMODE = value;
        }
    }

    private string ORGANISATION_EMPLOYEES;

    public string ORGANISATION_EMPLOYEES1
    {
        get
        {
            return ORGANISATION_EMPLOYEES;
        }
        set
        {
            ORGANISATION_EMPLOYEES = value;
        }
    }

    private string _ORG_SUPER_MODULE_ID;

    public string ORG_SUPER_MODULE_ID
    {
        get
        {
            return _ORG_SUPER_MODULE_ID;
        }
        set
        {
            _ORG_SUPER_MODULE_ID = value;
        }
    }
    private bool _ORG_IS_EMPCODE_MANUAL;
    public bool ORG_IS_EMPCODE_MANUAL
    {
        get
        {
            return _ORG_IS_EMPCODE_MANUAL;
        }
        set
        {
            _ORG_IS_EMPCODE_MANUAL = value;
        }
    }
    private string ORGANISATION_APPLICANTS;

    public string ORGANISATION_APPLICANTS1
    {
        get
        {
            return ORGANISATION_APPLICANTS;
        }
        set
        {
            ORGANISATION_APPLICANTS = value;
        }
    }

    private Boolean _ORGANISATION_ANNUALPROCESS;
    public Boolean ORGANISATION_ANNUALPROCESS
    {
        get { return (this._ORGANISATION_ANNUALPROCESS); }
        set { this._ORGANISATION_ANNUALPROCESS = value; }
    }

    private Boolean _ORGANISATION_INTEGRATION;
    public Boolean ORGANISATION_INTEGRATION
    {
        get { return (this._ORGANISATION_INTEGRATION); }
        set { this._ORGANISATION_INTEGRATION = value; }
    }
    private Boolean _ORGANISATION_SMOPS_INTEGRATION;
    public Boolean ORGANISATION_SMOPS_INTEGRATION
    {
        get { return (this._ORGANISATION_SMOPS_INTEGRATION); }
        set { this._ORGANISATION_SMOPS_INTEGRATION = value; }
    }
    private string _ORGANISATION_PIN;
    public string ORGANISATION_PIN
    {
        get { return this._ORGANISATION_PIN; }
        set { this._ORGANISATION_PIN = value; }
    }
    private string _ORGANISATION_POSTBOXNO;
    public string ORGANISATION_POSTBOXNO
    {
        get { return this._ORGANISATION_POSTBOXNO; }
        set { this._ORGANISATION_POSTBOXNO = value; }
    }
    private string _ORGANISATION_FAX;
    public string ORGANISATION_FAX
    {
        get { return this._ORGANISATION_FAX; }
        set { this._ORGANISATION_FAX = value; }
    }
    private string _ORGANISATION_NSSF;

    public string ORGANISATION_NSSF
    {
        get { return _ORGANISATION_NSSF; }
        set { _ORGANISATION_NSSF = value; }
    }
    private string _ORGANISATION_NHIF;

    public string ORGANISATION_NHIF
    {
        get { return _ORGANISATION_NHIF; }
        set { _ORGANISATION_NHIF = value; }
    }

    private string _ORGANISATION_VAT;

    public string ORGANISATION_VAT
    {
        get { return _ORGANISATION_VAT; }
        set { _ORGANISATION_VAT = value; }
    }

    public string NotificationMails { get; set; }
}

#endregion

#region SMHR_POSITIONS

public class SMHR_POSITIONS : SMHR_MAIN
{

    public SMHR_POSITIONS(int __POSITIONS_ID)
    {
        this._POSITIONS_ID = __POSITIONS_ID;
    }

    public SMHR_POSITIONS()
    {
    }

    private int _POSITIONS_ID;
    public int POSITIONS_ID
    {
        get { return (this._POSITIONS_ID); }
        set { this._POSITIONS_ID = value; }
    }

    private string _POSITIONS_CODE;
    public string POSITIONS_CODE
    {
        get { return (this._POSITIONS_CODE); }
        set { this._POSITIONS_CODE = value; }
    }
    private string _POSITIONS_NOESTABLISHMENT;
    public string POSITIONS_NOESTABLISHMENT
    {
        get { return (this._POSITIONS_NOESTABLISHMENT); }
        set { this._POSITIONS_NOESTABLISHMENT = value; }
    }

    private string _POSITIONS_DESC;
    public string POSITIONS_DESC
    {
        get { return (this._POSITIONS_DESC); }
        set { this._POSITIONS_DESC = value; }
    }

    private int _POSITIONS_JOBSID;
    public int POSITIONS_JOBSID
    {
        get { return (this._POSITIONS_JOBSID); }
        set { this._POSITIONS_JOBSID = value; }
    }

    private int _POSITIONS_STATUS;
    public int POSITIONS_STATUS
    {
        get { return (this._POSITIONS_STATUS); }
        set { this._POSITIONS_STATUS = value; }
    }

    private int _JOBLOC_BUSINESSUNIT_ID;
    public int JOBLOC_BUSINESSUNIT_ID
    {
        get { return (this._JOBLOC_BUSINESSUNIT_ID); }
        set { this._JOBLOC_BUSINESSUNIT_ID = value; }
    }
    /*Import*/
    private string _SDATE;
    public string SDATE
    {
        get { return this._SDATE; }
        set { this._SDATE = value; }
    }

    private string _EDATE;
    public string EDATE
    {
        get { return this._EDATE; }
        set { this._EDATE = value; }
    }

    private int? _POSITIONS_GRADE_ID;
    public int? POSITIONS_GRADE_ID
    {
        get { return (this._POSITIONS_GRADE_ID); }
        set { this._POSITIONS_GRADE_ID = value; }
    }

    private decimal? _POSITIONS_MAXSAL;
    public decimal? POSITIONS_MAXSAL
    {
        get { return (this._POSITIONS_MAXSAL); }
        set { this._POSITIONS_MAXSAL = value; }
    }

    private decimal? _POSITIONS_MINSAL;
    public decimal? POSITIONS_MINSAL
    {
        get { return (this._POSITIONS_MINSAL); }
        set { this._POSITIONS_MINSAL = value; }
    }
    private string _POSITIONS_SKILLS;
    public string POSITIONS_SKILLS
    {
        get { return (this._POSITIONS_SKILLS); }
        set { this._POSITIONS_SKILLS = value; }
    }
    private int _POSITIN_PERIOD_ID;

    public int POSITIN_PERIOD_ID
    {
        get { return _POSITIN_PERIOD_ID; }
        set { _POSITIN_PERIOD_ID = value; }
    }
    private int _POSITION_ESTABLISHMENT_ID;

    public int POSITION_ESTABLISHMENT_ID
    {
        get { return _POSITION_ESTABLISHMENT_ID; }
        set { _POSITION_ESTABLISHMENT_ID = value; }
    }

    private string _POSITIONS_QUALIFICATION;
    public string POSITIONS_QUALIFICATION
    {
        get { return (this._POSITIONS_QUALIFICATION); }
        set { this._POSITIONS_QUALIFICATION = value; }
    }
    private int _ESTABLISHMENTS_CREATEDBY;
    public int ESTABLISHMENTS_CREATEDBY
    {
        get { return (this._ESTABLISHMENTS_CREATEDBY); }
        set { this._ESTABLISHMENTS_CREATEDBY = value; }
    }
    private DateTime _ESTABLISHMENTS_CREATEDDATE;
    public DateTime ESTABLISHMENTS_CREATEDDATE
    {
        get { return (this._ESTABLISHMENTS_CREATEDDATE); }
        set { this._ESTABLISHMENTS_CREATEDDATE = value; }
    }

    private int _ESTABLISHMENTS_LSTMDFBY;
    public int ESTABLISHMENTS_LSTMDFBY
    {
        get { return (this._ESTABLISHMENTS_LSTMDFBY); }
        set { this._ESTABLISHMENTS_LSTMDFBY = value; }
    }
    private DateTime _ESTABLISHMENTS_LSTMDFDATE;
    public DateTime ESTABLISHMENTS_LSTMDFDATE
    {
        get { return (this._ESTABLISHMENTS_LSTMDFDATE); }
        set { this._ESTABLISHMENTS_LSTMDFDATE = value; }
    }
}

#endregion

#region SMHR_WORKINGHOURS

public class SMHR_WORKINGHOURS : SMHR_MAIN
{

    public SMHR_WORKINGHOURS(int __WRKHRS_ID)
    {
        this._WRKHRS_ID = __WRKHRS_ID;
    }

    public SMHR_WORKINGHOURS()
    {
    }


    private int _WRKHRS_ID;
    public int WRKHRS_ID
    {
        get { return (this._WRKHRS_ID); }
        set { this._WRKHRS_ID = value; }
    }
    private int _WRKHRS_BUSINESSUNIT_ID;
    public int WRKHRS_BUSINESSUNIT_ID
    {
        get { return (this._WRKHRS_BUSINESSUNIT_ID); }
        set { this._WRKHRS_BUSINESSUNIT_ID = value; }
    }

    private int _WRKHRS_DAY_ID;
    public int WRKHRS_DAY_ID
    {
        get { return (this._WRKHRS_DAY_ID); }
        set { this._WRKHRS_DAY_ID = value; }
    }

    private int _WRKHRS_NOOFHOURS;
    public int WRKHRS_NOOFHOURS
    {
        get { return (this._WRKHRS_NOOFHOURS); }
        set { this._WRKHRS_NOOFHOURS = value; }
    }

    private string _WRKHRS_STARTTIME;
    public string WRKHRS_STARTTIME
    {
        get { return (this._WRKHRS_STARTTIME); }
        set { this._WRKHRS_STARTTIME = value; }
    }
    private string _WRKHRS_ENDTIME;
    public string WRKHRS_ENDTIME
    {
        get { return (this._WRKHRS_ENDTIME); }
        set { this._WRKHRS_ENDTIME = value; }
    }

}

#endregion

#region SMHR_BANKBRANCH

public class SMHR_BANKBRANCH : SMHR_MAIN
{
    public SMHR_BANKBRANCH(int __BRANCH_ID)
    {
        this._BRANCH_ID = __BRANCH_ID;
    }

    public SMHR_BANKBRANCH()
    {
    }

    private int _BRANCH_ID;
    public int BRANCH_ID
    {
        get { return (this._BRANCH_ID); }
        set { this._BRANCH_ID = value; }
    }

    private string _BRANCH_CODE;
    public string BRANCH_CODE
    {
        get { return (this._BRANCH_CODE); }
        set { this._BRANCH_CODE = value; }
    }

    private string _BRANCH_NAME;
    public string BRANCH_NAME
    {
        get { return (this._BRANCH_NAME); }
        set { this._BRANCH_NAME = value; }
    }
    private int _BRANCH_BANK_ID;
    public int BRANCH_BANK_ID
    {
        get { return (this._BRANCH_BANK_ID); }
        set { this._BRANCH_BANK_ID = value; }
    }

}

#endregion

#region SMHR_EMPNOTES

public class SMHR_EMPNOTES : SMHR_MAIN
{

    public SMHR_EMPNOTES(int __EMPNOTES_ID)
    {
        this._EMPNOTES_ID = __EMPNOTES_ID;
    }

    public SMHR_EMPNOTES()
    {
    }


    private int _EMPNOTES_ID;
    public int EMPNOTES_ID
    {
        get { return (this._EMPNOTES_ID); }
        set { this._EMPNOTES_ID = value; }
    }

    private int _EMPNOTES_EMPID;
    public int EMPNOTES_EMPID
    {
        get { return (this._EMPNOTES_EMPID); }
        set { this._EMPNOTES_EMPID = value; }
    }

    private int _EMPNOTES_RPTMNGID;
    public int EMPNOTES_RPTMNGID
    {
        get { return (this._EMPNOTES_RPTMNGID); }
        set { this._EMPNOTES_RPTMNGID = value; }
    }

    private string _EMPNOTES_REMARKS;
    public string EMPNOTES_REMARKS
    {
        get { return (this._EMPNOTES_REMARKS); }
        set { this._EMPNOTES_REMARKS = value; }
    }

    private string _EMPNOTES_REASON;
    public string EMPNOTES_REASON
    {
        get { return (this._EMPNOTES_REASON); }
        set { this._EMPNOTES_REASON = value; }
    }

    private DateTime _EMPNOTES_DATE;
    public DateTime EMPNOTES_DATE
    {
        get { return (this._EMPNOTES_DATE); }
        set { this._EMPNOTES_DATE = value; }
    }

    private int _EMPNOTES_BU;
    public int EMPNOTES_BU
    {
        get { return (this._EMPNOTES_BU); }
        set { this._EMPNOTES_BU = value; }
    }

}

#endregion

#region SMHR_EMPDISCIPLINARYACTION

public class SMHR_EMPDISCIPLINARYACTION : SMHR_MAIN
{

    public SMHR_EMPDISCIPLINARYACTION(int __EMPDSPACT_ID)
    {
        this._EMPDSPACT_ID = __EMPDSPACT_ID;
    }

    public SMHR_EMPDISCIPLINARYACTION()
    {
    }

    private int _EMPDSPACT_ID;
    public int EMPDSPACT_ID
    {
        get { return (this._EMPDSPACT_ID); }
        set { this._EMPDSPACT_ID = value; }
    }
    private int _EMP_ID;
    public int EMP_ID
    {
        get { return (this._EMP_ID); }
        set { this._EMP_ID = value; }
    }

    private int _EMPDSPACT_EMPID;
    public int EMPDSPACT_EMPID
    {
        get { return (this._EMPDSPACT_EMPID); }
        set { this._EMPDSPACT_EMPID = value; }
    }

    private int _EMPDSPACT_RPTMNGID;
    public int EMPDSPACT_RPTMNGID
    {
        get { return (this._EMPDSPACT_RPTMNGID); }
        set { this._EMPDSPACT_RPTMNGID = value; }
    }

    private string _EMPDSPACT_REMARKS;
    public string EMPDSPACT_REMARKS
    {
        get { return (this._EMPDSPACT_REMARKS); }
        set { this._EMPDSPACT_REMARKS = value; }
    }

    private string _EMPDSPACT_REASON;
    public string EMPDSPACT_REASON
    {
        get { return (this._EMPDSPACT_REASON); }
        set { this._EMPDSPACT_REASON = value; }
    }
    private DateTime _EMPDSPACT_DATE;
    public DateTime EMPDSPACT_DATE
    {
        get { return (this._EMPDSPACT_DATE); }
        set { this._EMPDSPACT_DATE = value; }
    }

    private string _EMPDSPACT_ATTACHMENT;
    public string EMPDSPACT_ATTACHMENT
    {
        get { return (this._EMPDSPACT_ATTACHMENT); }
        set { this._EMPDSPACT_ATTACHMENT = value; }
    }

    private int _EMPDSPACT_BUID;
    public int EMPDSPACT_BUID
    {
        get { return (this._EMPDSPACT_BUID); }
        set { this._EMPDSPACT_BUID = value; }
    }

}

#endregion
#region SMHR_RESOURCES
public class SMHR_RESOURCES : SPMS_MAIN
{
    public SMHR_RESOURCES(int __RESOURCE_ID)
    {
        this._RESOURCE_ID = __RESOURCE_ID;
    }

    public SMHR_RESOURCES()
    {
    }
    private int _RESOURCE_ID;
    public int RESOURCE_ID
    {
        get { return (this._RESOURCE_ID); }
        set { this._RESOURCE_ID = value; }
    }

    private string _RESOURCE_NAME;
    public string RESOURCE_NAME
    {
        get { return (this._RESOURCE_NAME); }
        set { this._RESOURCE_NAME = value; }
    }

    private string _RESOURCE_DESCRIPTION;
    public string RESOURCE_DESCRIPTION
    {
        get { return (this._RESOURCE_DESCRIPTION); }
        set { this._RESOURCE_DESCRIPTION = value; }
    }
    private int _RESOURCE_CREATEDBY;
    public int RESOURCE_CREATEDBY
    {
        get { return (this._RESOURCE_CREATEDBY); }
        set { this._RESOURCE_CREATEDBY = value; }
    }

    private DateTime _RESOURCE_CREATEDDATE;
    public DateTime RESOURCE_CREATEDDATE
    {
        get { return (this._RESOURCE_CREATEDDATE); }
        set { this._RESOURCE_CREATEDDATE = value; }
    }

    private int _RESOURCE_LASTMDFBY;
    public int RESOURCE_LASTMDFBY
    {
        get { return (this._RESOURCE_LASTMDFBY); }
        set { this._RESOURCE_LASTMDFBY = value; }
    }

    private DateTime _RESOURCE_LASTMDFDATE;
    public DateTime RESOURCE_LASTMDFDATE
    {
        get { return (this._RESOURCE_LASTMDFDATE); }
        set { this._RESOURCE_LASTMDFDATE = value; }
    }

    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }


}
#endregion
#region SMHR_RESOURCE
public class SMHR_RESOURCE : SMHR_MAIN
{
    public SMHR_RESOURCE(int __RESOURCE_ID)
    {
        this._RESOURCE_ID = __RESOURCE_ID;
    }

    public SMHR_RESOURCE()
    {
    }
    private int _RESOURCE_ID;
    public int RESOURCE_ID
    {
        get { return (this._RESOURCE_ID); }
        set { this._RESOURCE_ID = value; }
    }
    private int _RESOUCE_TRID;
    public int RESOUCE_TRID
    {
        get { return (this._RESOUCE_TRID); }
        set { this._RESOUCE_TRID = value; }
    }

    private int _RESOURCE_ORG_ID;
    public int RESOURCE_ORG_ID
    {
        get { return (this._RESOURCE_ORG_ID); }
        set { this._RESOURCE_ORG_ID = value; }
    }
    private int _RESOURCE_TYPEID;
    public int RESOURCE_TYPEID
    {
        get { return (this._RESOURCE_TYPEID); }
        set { this._RESOURCE_TYPEID = value; }
    }

    private string _RESOURCE_NAME;
    public string RESOURCE_NAME
    {
        get { return (this._RESOURCE_NAME); }
        set { this._RESOURCE_NAME = value; }
    }
    private string _RESOURCE_DESC;
    public string RESOURCE_DESC
    {
        get { return (this._RESOURCE_DESC); }
        set { this._RESOURCE_DESC = value; }
    }
    private int _RESOUCE_QTY;
    public int RESOUCE_QTY
    {
        get { return (this._RESOUCE_QTY); }
        set { this._RESOUCE_QTY = value; }
    }
    private decimal _RESOURCE_ESTIMATEDBUDGET;
    public decimal RESOURCE_ESTIMATEDBUDGET
    {
        get { return (this._RESOURCE_ESTIMATEDBUDGET); }
        set { this._RESOURCE_ESTIMATEDBUDGET = value; }
    }
    private int _RESOURCE_CREATEDBY;
    public int RESOURCE_CREATEDBY
    {
        get { return (this._RESOURCE_CREATEDBY); }
        set { this._RESOURCE_CREATEDBY = value; }
    }
    private int _RESOURCE_S_NO;
    public int RESOURCE_S_NO
    {
        get { return (this._RESOURCE_S_NO); }
        set { this._RESOURCE_S_NO = value; }
    }
    private DateTime _RESOURCE_CREATEDDATE;
    public DateTime RESOURCE_CREATEDDATE
    {
        get { return (this._RESOURCE_CREATEDDATE); }
        set { this._RESOURCE_CREATEDDATE = value; }
    }

    private int _RESOURCE_LASTMDFBY;
    public int RESOURCE_LASTMDFBY
    {
        get { return (this._RESOURCE_LASTMDFBY); }
        set { this._RESOURCE_LASTMDFBY = value; }
    }

    private DateTime _RESOURCE_LASTMDFDATE;
    public DateTime RESOURCE_LASTMDFDATE
    {
        get { return (this._RESOURCE_LASTMDFDATE); }
        set { this._RESOURCE_LASTMDFDATE = value; }
    }

    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }


}
#endregion
//#region "SMHR_TRAININGFEEDBACK_RESPONSE"

//public class SMHR_TRAININGFEEDBACK_RESPONSE : SMHR_MAIN
//{
//    private int? _FEEDBACKRES_ID;
//    public int? FEEDBACKRES_ID
//    {
//        get { return (this._FEEDBACKRES_ID); }
//        set { this._FEEDBACKRES_ID = value; }
//    }

//    private int? _FEEDBACKRES_FEEDBACKQUESTS_ID;
//    public int? FEEDBACKRES_FEEDBACKQUESTS_ID
//    {
//        get { return (this._FEEDBACKRES_FEEDBACKQUESTS_ID); }
//        set { this._FEEDBACKRES_FEEDBACKQUESTS_ID = value; }
//    }

//    private int? _FEEDBACKRES_USER_ID;
//    public int? FEEDBACKRES_USER_ID
//    {
//        get { return (this._FEEDBACKRES_USER_ID); }
//        set { this._FEEDBACKRES_USER_ID = value; }
//    }

//    private string _FEEDBACKRES_RESPONSE;
//    public string FEEDBACKRES_RESPONSE
//    {
//        get { return (this._FEEDBACKRES_RESPONSE); }
//        set { this._FEEDBACKRES_RESPONSE = value; }
//    }

//    private DateTime? _FEEDBACKRES_DATE;
//    public DateTime? FEEDBACKRES_DATE
//    {
//        get { return (this._FEEDBACKRES_DATE); }
//        set { this._FEEDBACKRES_DATE = value; }
//    }

//    private string _FEEDBACKRES_COMMENTS;
//    public string FEEDBACKRES_COMMENTS
//    {
//        get { return (this._FEEDBACKRES_COMMENTS); }
//        set { this._FEEDBACKRES_COMMENTS = value; }
//    }


//    private string _FEEDBACKRES_STATUS;
//    public string FEEDBACKRES_STATUS
//    {
//        get { return (this._FEEDBACKRES_STATUS); }
//        set { this._FEEDBACKRES_STATUS = value; }
//    }
//    public int FEEDBACKRES_TR_ID { get; set; }
//    public int FEEBBACKRES_FEEDBACK_NO { get; set; }
//    public int FEEDBACKRES_TRAINER_ID { get; set; }


//}


//#endregion

#region SMHR_TRAININGATTENDANCEDTLS
public class SMHR_TRAININGATTENDANCEDTLS : SMHR_MAIN
{
    public SMHR_TRAININGATTENDANCEDTLS(int __ATTENDANCE_ID)
    {
        this._ATTENDANCE_ID = __ATTENDANCE_ID;
    }

    public SMHR_TRAININGATTENDANCEDTLS()
    {
    }
    private int _ATTENDANCE_ID;
    public int ATTENDANCE_ID
    {
        get { return (this._ATTENDANCE_ID); }
        set { this._ATTENDANCE_ID = value; }
    }


    private int _ATTENDANCE_TR_ID;
    public int ATTENDANCE_TR_ID
    {
        get { return (this._ATTENDANCE_TR_ID); }
        set { this._ATTENDANCE_TR_ID = value; }
    }



    private int _ATTENDANCE_BU_ID;
    public int ATTENDANCE_BU_ID
    {
        get { return (this._ATTENDANCE_BU_ID); }
        set { this._ATTENDANCE_BU_ID = value; }
    }
    private int _ATTENDANCE_EMP_ID;
    public int ATTENDANCE_EMP_ID
    {
        get { return (this._ATTENDANCE_EMP_ID); }
        set { this._ATTENDANCE_EMP_ID = value; }
    }

    private DateTime _ATTENDANCE_DATE;
    public DateTime ATTENDANCE_DATE
    {
        get { return (this._ATTENDANCE_DATE); }
        set { this._ATTENDANCE_DATE = value; }
    }

    private string _ATTENDANCE_STATUS;
    public string ATTENDANCE_STATUS
    {
        get { return (this._ATTENDANCE_STATUS); }
        set { this._ATTENDANCE_STATUS = value; }
    }
    private int _ATTENDANCE_ISFINAL;
    public int ATTENDANCE_ISFINAL
    {
        get { return (this._ATTENDANCE_ISFINAL); }
        set { this._ATTENDANCE_ISFINAL = value; }
    }
    private int _ATTENDANCE_CREATEDBY;
    public int ATTENDANCE_CREATEDBY
    {
        get { return (this._ATTENDANCE_CREATEDBY); }
        set { this._ATTENDANCE_CREATEDBY = value; }
    }

    private DateTime _ATTENDANCE_CREATEDDATE;
    public DateTime ATTENDANCE_CREATEDDATE
    {
        get { return (this._ATTENDANCE_CREATEDDATE); }
        set { this._ATTENDANCE_CREATEDDATE = value; }
    }

    private int _ATTENDANCE_LASTMDFBY;
    public int ATTENDANCE_LASTMDFBY
    {
        get { return (this._ATTENDANCE_LASTMDFBY); }
        set { this._ATTENDANCE_LASTMDFBY = value; }
    }

    private DateTime _ATTENDANCE_LASTMDFDATE;
    public DateTime ATTENDANCE_LASTMDFDATE
    {
        get { return (this._ATTENDANCE_LASTMDFDATE); }
        set { this._ATTENDANCE_LASTMDFDATE = value; }
    }
    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }


}
#endregion

#region SMHR_FEEDBACK_QUESTION

public class SMHR_FEEDBACK_QUESTION : SMHR_MAIN
{
    public SMHR_FEEDBACK_QUESTION(int __FEEDBACKQUESTS_ID)
    {
        this._FEEDBACKQUESTS_ID = __FEEDBACKQUESTS_ID;
    }

    public SMHR_FEEDBACK_QUESTION()
    {
    }
    private int _FEEDBACKQUESTS_ID;
    public int FEEDBACKQUESTS_ID
    {
        get { return (this._FEEDBACKQUESTS_ID); }
        set { this._FEEDBACKQUESTS_ID = value; }
    }

    private int _FEEDBACKQUESTS_ORG_ID;
    public int FEEDBACKQUESTS_ORG_ID
    {
        get { return (this._FEEDBACKQUESTS_ORG_ID); }
        set { this._FEEDBACKQUESTS_ORG_ID = value; }
    }
    private string _FEEDBACKQUESTS_QUESTION_CATEGORY;
    public string FEEDBACKQUESTS_QUESTION_CATEGORY
    {
        get { return (this._FEEDBACKQUESTS_QUESTION_CATEGORY); }
        set { this._FEEDBACKQUESTS_QUESTION_CATEGORY = value; }
    }
    private string _FEEDBACK_ID;
    public string FEEDBACK_ID
    {
        get { return (this._FEEDBACK_ID); }
        set { this._FEEDBACK_ID = value; }
    }

    private string _FEEDBACKQUESTS_QUESTION;
    public string FEEDBACKQUESTS_QUESTION
    {
        get { return (this._FEEDBACKQUESTS_QUESTION); }
        set { this._FEEDBACKQUESTS_QUESTION = value; }
    }

    private string _FEEDBACKQUESTS_OPTION1;
    public string FEEDBACKQUESTS_OPTION1
    {
        get { return (this._FEEDBACKQUESTS_OPTION1); }
        set { this._FEEDBACKQUESTS_OPTION1 = value; }
    }

    private string _FEEDBACKQUESTS_OPTION2;
    public string FEEDBACKQUESTS_OPTION2
    {
        get { return (this._FEEDBACKQUESTS_OPTION2); }
        set { this._FEEDBACKQUESTS_OPTION2 = value; }
    }

    private string _FEEDBACKQUESTS_OPTION3;
    public string FEEDBACKQUESTS_OPTION3
    {
        get { return (this._FEEDBACKQUESTS_OPTION3); }
        set { this._FEEDBACKQUESTS_OPTION3 = value; }
    }

    private string _FEEDBACKQUESTS_OPTION4;
    public string FEEDBACKQUESTS_OPTION4
    {
        get { return (this._FEEDBACKQUESTS_OPTION4); }
        set { this._FEEDBACKQUESTS_OPTION4 = value; }
    }



    private string _FEEDBACKQUESTS_STATUS;
    public string FEEDBACKQUESTS_STATUS
    {
        get { return (this._FEEDBACKQUESTS_STATUS); }
        set { this._FEEDBACKQUESTS_STATUS = value; }
    }

}
#endregion
#region SMHR_TRGFEEDBACKQUESDTLS
public class SMHR_TRGFEEDBACKQUESDTLS : SMHR_MAIN
{
    public SMHR_TRGFEEDBACKQUESDTLS(int __TRFDBDTL_ID)
    {
        this._TRFDBDTL_ID = __TRFDBDTL_ID;
    }

    public SMHR_TRGFEEDBACKQUESDTLS()
    {
    }
    private int _TRFDBDTL_ID;
    public int TRFDBDTL_ID
    {
        get { return (this._TRFDBDTL_ID); }
        set { this._TRFDBDTL_ID = value; }
    }



    private int _TRFDBDTL_FDBID;
    public int TRFDBDTL_FDBID
    {
        get { return (this._TRFDBDTL_FDBID); }
        set { this._TRFDBDTL_FDBID = value; }
    }

    private int _TRFDBDTL_QUESTIONSID;
    public int TRFDBDTL_QUESTIONSID
    {
        get { return (this._TRFDBDTL_QUESTIONSID); }
        set { this._TRFDBDTL_QUESTIONSID = value; }
    }

    private int _TRFDBDTL_CREATEDBY;
    public int TRFDBDTL_CREATEDBY
    {
        get { return (this._TRFDBDTL_CREATEDBY); }
        set { this._TRFDBDTL_CREATEDBY = value; }
    }

    private DateTime _TRFDBDTL_CREATEDDATE;
    public DateTime TRFDBDTL_CREATEDDATE
    {
        get { return (this._TRFDBDTL_CREATEDDATE); }
        set { this._TRFDBDTL_CREATEDDATE = value; }
    }

    private int _TRFDBDTL_LASTMDFBY;
    public int TRFDBDTL_LASTMDFBY
    {
        get { return (this._TRFDBDTL_LASTMDFBY); }
        set { this._TRFDBDTL_LASTMDFBY = value; }
    }

    private DateTime _TRFDBDTL_LASTMDFDATE;
    public DateTime TRFDBDTL_LASTMDFDATE
    {
        get { return (this._TRFDBDTL_LASTMDFDATE); }
        set { this._TRFDBDTL_LASTMDFDATE = value; }
    }
    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }


}
#endregion
#region SMHR_ASSIGNFEEDBACK_EMPLOYEE
public class SMHR_ASSIGNFEEDBACK_EMPLOYEE : SMHR_MAIN
{
    public SMHR_ASSIGNFEEDBACK_EMPLOYEE(int __ASSIGNFEED_ID)
    {
        this._ASSIGNFEED_ID = __ASSIGNFEED_ID;
    }

    public SMHR_ASSIGNFEEDBACK_EMPLOYEE()
    {
    }
    private int _ASSIGNFEED_ID;
    public int ASSIGNFEED_ID
    {
        get { return (this._ASSIGNFEED_ID); }
        set { this._ASSIGNFEED_ID = value; }
    }
    private int _ASSIGNFEED_FEEBAK_ID;
    public int ASSIGNFEED_FEEBAK_ID
    {
        get { return (this._ASSIGNFEED_FEEBAK_ID); }
        set { this._ASSIGNFEED_FEEBAK_ID = value; }
    }

    private int _ASSIGN_EMP_ID;
    public int ASSIGN_EMP_ID
    {
        get { return (this._ASSIGN_EMP_ID); }
        set { this._ASSIGN_EMP_ID = value; }
    }

    private int _ASSIGN_CREATEDBY;
    public int ASSIGN_CREATEDBY
    {
        get { return (this._ASSIGN_CREATEDBY); }
        set { this._ASSIGN_CREATEDBY = value; }
    }

    private DateTime _ASSIGN_CREATEDDATE;
    public DateTime ASSIGN_CREATEDDATE
    {
        get { return (this._ASSIGN_CREATEDDATE); }
        set { this._ASSIGN_CREATEDDATE = value; }
    }



    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }


}
#endregion

#region SMHR_TRAININGSCHEDULE
public class SMHR_TRAININGSCHEDULE : SMHR_MAIN
{
    public SMHR_TRAININGSCHEDULE(int __TS_SCHEDULEID)
    {
        this._TS_SCHEDULEID = __TS_SCHEDULEID;
    }

    public SMHR_TRAININGSCHEDULE()
    {
    }
    private int _TS_SCHEDULEID;
    public int TS_SCHEDULEID
    {
        get { return (this._TS_SCHEDULEID); }
        set { this._TS_SCHEDULEID = value; }
    }


    private int _TS_TR_ID;
    public int TS_TR_ID
    {
        get { return (this._TS_TR_ID); }
        set { this._TS_TR_ID = value; }
    }



    private DateTime _TS_STARTDATE;
    public DateTime TS_STARTDATE
    {
        get { return (this._TS_STARTDATE); }
        set { this._TS_STARTDATE = value; }
    }
    private DateTime _TS_ENDDATE;
    public DateTime TS_ENDDATE
    {
        get { return (this._TS_ENDDATE); }
        set { this._TS_ENDDATE = value; }
    }
    private string _TS_STARTTIME;
    public string TS_STARTTIME
    {
        get { return (this._TS_STARTTIME); }
        set { this._TS_STARTTIME = value; }
    }
    private string _TS_ENDTIME;
    public string TS_ENDTIME
    {
        get { return (this._TS_ENDTIME); }
        set { this._TS_ENDTIME = value; }
    }
    private string _TS_RECURRENCETYPE;
    public string TS_RECURRENCETYPE
    {
        get { return (this._TS_RECURRENCETYPE); }
        set { this._TS_RECURRENCETYPE = value; }
    }

    private int _TS_SESSIONS;
    public int TS_SESSIONS
    {
        get { return (this._TS_SESSIONS); }
        set { this._TS_SESSIONS = value; }
    }

    private int _TS_PARAM1;
    public int TS_PARAM1
    {
        get { return (this._TS_PARAM1); }
        set { this._TS_PARAM1 = value; }
    }
    private int _TS_PARAM2;
    public int TS_PARAM2
    {
        get { return (this._TS_PARAM2); }
        set { this._TS_PARAM2 = value; }
    }
    private int _TS_PARAM3;
    public int TS_PARAM3
    {
        get { return (this._TS_PARAM3); }
        set { this._TS_PARAM3 = value; }
    }
    private int _TS_PARAM4;
    public int TS_PARAM4
    {
        get { return (this._TS_PARAM4); }
        set { this._TS_PARAM4 = value; }
    }
    private int _TS_PARAM5;
    public int TS_PARAM5
    {
        get { return (this._TS_PARAM5); }
        set { this._TS_PARAM5 = value; }
    }
    private int _TS_PARAM6;
    public int TS_PARAM6
    {
        get { return (this._TS_PARAM6); }
        set { this._TS_PARAM6 = value; }
    }
    private int _TS_PARAM7;
    public int TS_PARAM7
    {
        get { return (this._TS_PARAM7); }
        set { this._TS_PARAM7 = value; }
    }
    private int _TS_PARAM8;
    public int TS_PARAM8
    {
        get { return (this._TS_PARAM8); }
        set { this._TS_PARAM8 = value; }
    }

    private int _TS_SELECTIONPARAM;
    public int TS_SELECTIONPARAM
    {
        get { return (this._TS_SELECTIONPARAM); }
        set { this._TS_SELECTIONPARAM = value; }
    }
    private int _TS_CREATEDBY;
    public int TS_CREATEDBY
    {
        get { return (this._TS_CREATEDBY); }
        set { this._TS_CREATEDBY = value; }
    }
    private int _TS_ORG_ID;
    public int TS_ORG_ID
    {
        get { return (this._TS_ORG_ID); }
        set { this._TS_ORG_ID = value; }
    }
    private DateTime _TS_CREATEDDATE;
    public DateTime TS_CREATEDDATE
    {
        get { return (this._TS_CREATEDDATE); }
        set { this._TS_CREATEDDATE = value; }
    }

    private int _TS_LASTMDFBY;
    public int TS_LASTMDFBY
    {
        get { return (this._TS_LASTMDFBY); }
        set { this._TS_LASTMDFBY = value; }
    }

    private DateTime _TS_LASTMDFDATE;
    public DateTime TS_LASTMDFDATE
    {
        get { return (this._TS_LASTMDFDATE); }
        set { this._TS_LASTMDFDATE = value; }
    }
    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }


}
#endregion
#region SMHR_TRAININGREQUEST
public class SMHR_TRAININGREQUEST : SMHR_MAIN
{
    public SMHR_TRAININGREQUEST(int __TR_ID)
    {
        this._TR_ID = __TR_ID;
    }

    public SMHR_TRAININGREQUEST()
    {
    }
    private int _TR_ID;
    public int TR_ID
    {
        get { return (this._TR_ID); }
        set { this._TR_ID = value; }
    }

    private string _TR_TITLE;
    public string TR_TITLE
    {
        get { return (this._TR_TITLE); }
        set { this._TR_TITLE = value; }
    }
    private string _TR_LOCATION;
    public string TR_LOCATION
    {
        get { return (this._TR_LOCATION); }
        set { this._TR_LOCATION = value; }
    }

    private int _TR_COURSEID;
    public int TR_COURSEID
    {
        get { return (this._TR_COURSEID); }
        set { this._TR_COURSEID = value; }
    }
    private int _TR_ORG_ID;
    public int TR_ORG_ID
    {
        get { return (this._TR_ORG_ID); }
        set { this._TR_ORG_ID = value; }
    }
    private string _TR_DESCRIPTION;
    public string TR_DESCRIPTION
    {
        get { return (this._TR_DESCRIPTION); }
        set { this._TR_DESCRIPTION = value; }
    }
    private string _TR_STATUS;
    public string TR_STATUS
    {
        get { return (this._TR_STATUS); }
        set { this._TR_STATUS = value; }
    }
    private int _TR_TRAINERDETAILSID;
    public int TR_TRAINERDETAILSID
    {
        get { return (this._TR_TRAINERDETAILSID); }
        set { this._TR_TRAINERDETAILSID = value; }
    }
    private int _TR_CREATEDBY;
    public int TR_CREATEDBY
    {
        get { return (this._TR_CREATEDBY); }
        set { this._TR_CREATEDBY = value; }
    }

    private DateTime _TR_CREATEDDATE;
    public DateTime TR_CREATEDDATE
    {
        get { return (this._TR_CREATEDDATE); }
        set { this._TR_CREATEDDATE = value; }
    }

    private int _TR_LASTMDFBY;
    public int TR_LASTMDFBY
    {
        get { return (this._TR_LASTMDFBY); }
        set { this._TR_LASTMDFBY = value; }
    }

    private DateTime _TR_LASTMDFDATE;
    public DateTime TR_LASTMDFDATE
    {
        get { return (this._TR_LASTMDFDATE); }
        set { this._TR_LASTMDFDATE = value; }
    }
    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }

    private int _TR_RAISEDBY;
    public int TR_RAISEDBY
    {
        get { return (this._TR_RAISEDBY); }
        set { this._TR_RAISEDBY = value; }
    }
    private int _TR_APPROVEDBY;
    public int TR_APPROVEDBY
    {
        get { return (this._TR_APPROVEDBY); }
        set { this._TR_APPROVEDBY = value; }
    }

    private int _TRAINING_ATTENDANCE_DAYS;
    public int TRAINING_ATTENDANCE_DAYS
    {
        get { return (this._TRAINING_ATTENDANCE_DAYS); }
        set { this._TRAINING_ATTENDANCE_DAYS = value; }
    }



}
#endregion

#region SMHR_TrgSaveFeedback
public class SMHR_TrgSaveFeedback : SMHR_MAIN
{
    public SMHR_TrgSaveFeedback(int __SAVEFEEDBACK_ID)
    {
        this._SAVEFEEDBACK_ID = __SAVEFEEDBACK_ID;
    }

    public SMHR_TrgSaveFeedback()
    {
    }
    private int _SAVEFEEDBACK_ID;
    public int SAVEFEEDBACK_ID
    {
        get { return (this._SAVEFEEDBACK_ID); }
        set { this._SAVEFEEDBACK_ID = value; }
    }
    private int _SAVEFEEDBACK_TR_ID;
    public int SAVEFEEDBACK_TR_ID
    {
        get { return (this._SAVEFEEDBACK_TR_ID); }
        set { this._SAVEFEEDBACK_TR_ID = value; }
    }
    private int _SAVEFEEDBACK_EMP_ID;
    public int SAVEFEEDBACK_EMP_ID
    {
        get { return (this._SAVEFEEDBACK_EMP_ID); }
        set { this._SAVEFEEDBACK_EMP_ID = value; }
    }
    private int _SAVEFEEDBACK_FEEDBACKQUESTS_ID;
    public int SAVEFEEDBACK_FEEDBACKQUESTS_ID
    {
        get { return (this._SAVEFEEDBACK_FEEDBACKQUESTS_ID); }
        set { this._SAVEFEEDBACK_FEEDBACKQUESTS_ID = value; }
    }
    private string _SAVEFEEDBACK_FEEDBACKQUESTION;
    public string SAVEFEEDBACK_FEEDBACKQUESTION
    {
        get { return (this._SAVEFEEDBACK_FEEDBACKQUESTION); }
        set { this._SAVEFEEDBACK_FEEDBACKQUESTION = value; }
    }


    private string _SAVEFEEDBACK_EMPLOYEE_ID_for;
    public string SAVEFEEDBACK_EMPLOYEE_ID_for
    {
        get { return (this._SAVEFEEDBACK_EMPLOYEE_ID_for); }
        set { this._SAVEFEEDBACK_EMPLOYEE_ID_for = value; }
    }
    private string _SAVEFEEDBACK_FEEDBACKQUESTS_OPTION1;
    public string SAVEFEEDBACK_FEEDBACKQUESTS_OPTION1
    {
        get { return (this._SAVEFEEDBACK_FEEDBACKQUESTS_OPTION1); }
        set { this._SAVEFEEDBACK_FEEDBACKQUESTS_OPTION1 = value; }
    }

    private string _SAVEFEEDBACK_FEEDBACKQUESTS_OPTION2;
    public string SAVEFEEDBACK_FEEDBACKQUESTS_OPTION2
    {
        get { return (this._SAVEFEEDBACK_FEEDBACKQUESTS_OPTION2); }
        set { this._SAVEFEEDBACK_FEEDBACKQUESTS_OPTION2 = value; }
    }
    private string _SAVEFEEDBACK_FEEDBACKQUESTS_OPTION3;
    public string SAVEFEEDBACK_FEEDBACKQUESTS_OPTION3
    {
        get { return (this._SAVEFEEDBACK_FEEDBACKQUESTS_OPTION3); }
        set { this._SAVEFEEDBACK_FEEDBACKQUESTS_OPTION3 = value; }
    }
    private string _SAVEFEEDBACK_FEEDBACKQUESTS_OPTION4;
    public string SAVEFEEDBACK_FEEDBACKQUESTS_OPTION4
    {
        get { return (this._SAVEFEEDBACK_FEEDBACKQUESTS_OPTION4); }
        set { this._SAVEFEEDBACK_FEEDBACKQUESTS_OPTION4 = value; }
    }
    private int _SAVEFEEDBACK_STATUS;
    public int SAVEFEEDBACK_STATUS
    {
        get { return (this._SAVEFEEDBACK_STATUS); }
        set { this._SAVEFEEDBACK_STATUS = value; }
    }

    private int _SAVEFEEDBACK_CREATEDBY;
    public int SAVEFEEDBACK_CREATEDBY
    {
        get { return (this._SAVEFEEDBACK_CREATEDBY); }
        set { this._SAVEFEEDBACK_CREATEDBY = value; }
    }

    private DateTime _SAVEFEEDBACK_CREATEDDATE;
    public DateTime SAVEFEEDBACK_CREATEDDATE
    {
        get { return (this._SAVEFEEDBACK_CREATEDDATE); }
        set { this._SAVEFEEDBACK_CREATEDDATE = value; }
    }
    private DateTime _SAVEFEEDBACK_DATE;
    public DateTime SAVEFEEDBACK_DATE
    {
        get { return (this._SAVEFEEDBACK_DATE); }
        set { this._SAVEFEEDBACK_DATE = value; }
    }
    private string _SAVEFEEDBACK_STARTTIME;
    public string SAVEFEEDBACK_STARTTIME
    {
        get { return (this._SAVEFEEDBACK_STARTTIME); }
        set { this._SAVEFEEDBACK_STARTTIME = value; }
    }
    private string _SAVEFEEDBACK_ENDTIME;
    public string SAVEFEEDBACK_ENDTIME
    {
        get { return (this._SAVEFEEDBACK_ENDTIME); }
        set { this._SAVEFEEDBACK_ENDTIME = value; }
    }


    private int _SAVEFEEDBACK_LASTMDFBY;
    public int SAVEFEEDBACK_LASTMDFBY
    {
        get { return (this._SAVEFEEDBACK_LASTMDFBY); }
        set { this._SAVEFEEDBACK_LASTMDFBY = value; }
    }

    private DateTime _SAVEFEEDBACK_LASTMDFDATE;
    public DateTime SAVEFEEDBACK_LASTMDFDATE
    {
        get { return (this._SAVEFEEDBACK_LASTMDFDATE); }
        set { this._SAVEFEEDBACK_LASTMDFDATE = value; }
    }

    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }


}
#endregion
#region SMHR_TRAINEE
public class SMHR_TRAINEE : SMHR_MAIN
{
    public SMHR_TRAINEE(int __TRAINEE_ID)
    {
        this._TRAINEE_ID = __TRAINEE_ID;
    }

    public SMHR_TRAINEE()
    {
    }
    private int _TRAINEE_ID;
    public int TRAINEE_ID
    {
        get { return (this._TRAINEE_ID); }
        set { this._TRAINEE_ID = value; }
    }


    private int _TRAINEE_TR_ID;
    public int TRAINEE_TR_ID
    {
        get { return (this._TRAINEE_TR_ID); }
        set { this._TRAINEE_TR_ID = value; }
    }



    private int _TRAINEE_BUSINESSUNIT_ID;
    public int TRAINEE_BUSINESSUNIT_ID
    {
        get { return (this._TRAINEE_BUSINESSUNIT_ID); }
        set { this._TRAINEE_BUSINESSUNIT_ID = value; }
    }

    private int _TRAINEE_ORG_ID;
    public int TRAINEE_ORG_ID
    {
        get { return (this._TRAINEE_ORG_ID); }
        set { this._TRAINEE_ORG_ID = value; }
    }
    private int _TRAINEE_EMPID;
    public int TRAINEE_EMPID
    {
        get { return (this._TRAINEE_EMPID); }
        set { this._TRAINEE_EMPID = value; }
    }
    private int _TRAINEE_CREATEDBY;
    public int TRAINEE_CREATEDBY
    {
        get { return (this._TRAINEE_CREATEDBY); }
        set { this._TRAINEE_CREATEDBY = value; }
    }

    private DateTime _TRAINEE_CREATEDDATE;
    public DateTime TRAINEE_CREATEDDATE
    {
        get { return (this._TRAINEE_CREATEDDATE); }
        set { this._TRAINEE_CREATEDDATE = value; }
    }

    private int _TRAINEE_LASTMDFBY;
    public int TRAINEE_LASTMDFBY
    {
        get { return (this._TRAINEE_LASTMDFBY); }
        set { this._TRAINEE_LASTMDFBY = value; }
    }

    private DateTime _TRAINEE_LASTMDFDATE;
    public DateTime TRAINEE_LASTMDFDATE
    {
        get { return (this._TRAINEE_LASTMDFDATE); }
        set { this._TRAINEE_LASTMDFDATE = value; }
    }
    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }


}
#endregion
#region SMHR_TRAINER
public class SMHR_TRAINER : SMHR_MAIN
{
    public SMHR_TRAINER(int __TRAINERDETAILS_ID)
    {
        this._TRAINERDETAILS_ID = __TRAINERDETAILS_ID;
    }

    public SMHR_TRAINER()
    {
    }
    private int _TRAINERDETAILS_ID;
    public int TRAINERDETAILS_ID
    {
        get { return (this._TRAINERDETAILS_ID); }
        set { this._TRAINERDETAILS_ID = value; }
    }

    private string _TRAINERDETAILS_EMPLOYEENAME;
    public string TRAINERDETAILS_EMPLOYEENAME
    {
        get { return (this._TRAINERDETAILS_EMPLOYEENAME); }
        set { this._TRAINERDETAILS_EMPLOYEENAME = value; }
    }
    private string _TRAINERDETAILS_TRAININGINSTITUENAME;
    public string TRAINERDETAILS_TRAININGINSTITUENAME
    {
        get { return (this._TRAINERDETAILS_TRAININGINSTITUENAME); }
        set { this._TRAINERDETAILS_TRAININGINSTITUENAME = value; }
    }

    private int _TRAINERDETAILS_HR_MASTER_ID;
    public int TRAINERDETAILS_HR_MASTER_ID
    {
        get { return (this._TRAINERDETAILS_HR_MASTER_ID); }
        set { this._TRAINERDETAILS_HR_MASTER_ID = value; }
    }
    private int _TRAINERDETAILS_EMPLOYEEID;
    public int TRAINERDETAILS_EMPLOYEEID
    {
        get { return (this._TRAINERDETAILS_EMPLOYEEID); }
        set { this._TRAINERDETAILS_EMPLOYEEID = value; }
    }
    private int _TRAINERDETAILS_BUSINESSUNITID;
    public int TRAINERDETAILS_BUSINESSUNITID
    {
        get { return (this._TRAINERDETAILS_BUSINESSUNITID); }
        set { this._TRAINERDETAILS_BUSINESSUNITID = value; }
    }
    private string _TRAINERDETAILS_ORGANISATIONNAME;
    public string TRAINERDETAILS_ORGANISATIONNAME
    {
        get { return (this._TRAINERDETAILS_ORGANISATIONNAME); }
        set { this._TRAINERDETAILS_ORGANISATIONNAME = value; }
    }
    private string _TRAINERDETAILS_DESIGNATION;
    public string TRAINERDETAILS_DESIGNATION
    {
        get { return (this._TRAINERDETAILS_DESIGNATION); }
        set { this._TRAINERDETAILS_DESIGNATION = value; }
    }
    private string _TRAINERDETAILS_ADDRESS;
    public string TRAINERDETAILS_ADDRESS
    {
        get { return (this._TRAINERDETAILS_ADDRESS); }
        set { this._TRAINERDETAILS_ADDRESS = value; }
    }
    //private int _TR_TRAINERDETAILSID;
    //public int TR_TRAINERDETAILSID
    //{
    //    get { return (this._TR_TRAINERDETAILSID); }
    //    set { this._TR_TRAINERDETAILSID = value; }
    //}
    private string _TRAINERDETAILS_CONTACTNO;
    public string TRAINERDETAILS_CONTACTNO
    {
        get { return (this._TRAINERDETAILS_CONTACTNO); }
        set { this._TRAINERDETAILS_CONTACTNO = value; }
    }
    private string _TRAINERDETAILS_CONTACTPERSON;
    public string TRAINERDETAILS_CONTACTPERSON
    {
        get { return (this._TRAINERDETAILS_CONTACTPERSON); }
        set { this._TRAINERDETAILS_CONTACTPERSON = value; }
    }


    private string _TRAINERDETAILS_FACULTY;
    public string TRAINERDETAILS_FACULTY
    {
        get { return (this._TRAINERDETAILS_FACULTY); }
        set { this._TRAINERDETAILS_FACULTY = value; }
    }

    private int _TRAINERDETAILS_CREATEDBY;
    public int TRAINERDETAILS_CREATEDBY
    {
        get { return (this._TRAINERDETAILS_CREATEDBY); }
        set { this._TRAINERDETAILS_CREATEDBY = value; }
    }

    private DateTime _TRAINERDETAILS_CREATEDDATE;
    public DateTime TRAINERDETAILS_CREATEDDATE
    {
        get { return (this._TRAINERDETAILS_CREATEDDATE); }
        set { this._TRAINERDETAILS_CREATEDDATE = value; }
    }

    private int _TRAINERDETAILS_LASTMDFBY;
    public int TRAINERDETAILS_LASTMDFBY
    {
        get { return (this._TRAINERDETAILS_LASTMDFBY); }
        set { this._TRAINERDETAILS_LASTMDFBY = value; }
    }

    private DateTime _TRAINERDETAILS_LASTMDFDATE;
    public DateTime TRAINERDETAILS_LASTMDFDATE
    {
        get { return (this._TRAINERDETAILS_LASTMDFDATE); }
        set { this._TRAINERDETAILS_LASTMDFDATE = value; }
    }
    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }
    private int _TRAINERDETAILS_TR_ID;
    public int TRAINERDETAILS_TR_ID
    {
        get { return (this._TRAINERDETAILS_TR_ID); }
        set { this._TRAINERDETAILS_TR_ID = value; }
    }
    private int _TRAINERDETAILS_ORG_ID;
    public int TRAINERDETAILS_ORG_ID
    {
        get { return (this._TRAINERDETAILS_ORG_ID); }
        set { this._TRAINERDETAILS_ORG_ID = value; }
    }
}
#endregion

#region SMHR_COURSE

public class SMHR_COURSE : SMHR_MAIN
{
    public SMHR_COURSE(int __COURSE_ID)
    {
        this._COURSE_ID = __COURSE_ID;
    }

    public SMHR_COURSE()
    {
    }

    private int _COURSE_ID;
    public int COURSE_ID
    {
        get { return (this._COURSE_ID); }
        set { this._COURSE_ID = value; }
    }
    private int _COURSE_ORG_ID;
    public int COURSE_ORG_ID
    {
        get { return (this._COURSE_ORG_ID); }
        set { this._COURSE_ORG_ID = value; }
    }
    private string _COURSE_NAME;
    public string COURSE_NAME
    {
        get { return (this._COURSE_NAME); }
        set { this._COURSE_NAME = value; }
    }

    private string _COURSE_DESC;
    public string COURSE_DESC
    {
        get { return (this._COURSE_DESC); }
        set { this._COURSE_DESC = value; }
    }
    private string _COURSE_DESIGNEDFOR;
    public string COURSE_DESIGNEDFOR
    {
        get { return (this._COURSE_DESIGNEDFOR); }
        set { this._COURSE_DESIGNEDFOR = value; }
    }

    private string _COURSE_SKILL_WID;
    public string COURSE_SKILL_WID
    {
        get { return (this._COURSE_SKILL_WID); }
        set { this._COURSE_SKILL_WID = value; }
    }

    private string _COURSE_CATEGORYID;
    public string COURSE_CATEGORYID
    {
        get { return (this._COURSE_CATEGORYID); }
        set { this._COURSE_CATEGORYID = value; }
    }

    private string _COURSE_SKILL_ID;
    public string COURSE_SKILL_ID
    {
        get { return (this._COURSE_SKILL_ID); }
        set { this._COURSE_SKILL_ID = value; }
    }
    private int _COURSE_BUSINESSUNIT_ID;
    public int COURSE_BUSINESSUNIT_ID
    {
        get { return (this._COURSE_BUSINESSUNIT_ID); }
        set { this._COURSE_BUSINESSUNIT_ID = value; }
    }
    private int _COURSE_DURATION;

    public int COURSE_DURATION
    {
        get { return _COURSE_DURATION; }
        set { _COURSE_DURATION = value; }
    }

    private bool _COURSE_STATUS;

    public bool COURSE_STATUS
    {
        get { return _COURSE_STATUS; }
        set { _COURSE_STATUS = value; }
    }
}

#endregion
#region "SMHR_TRAININGFEEDBACK"

public class SMHR_TRAININGFEEDBACK : SMHR_MAIN
{
    private int? _FEEDBACK_ID;
    public int? FEEDBACK_ID
    {
        get { return (this._FEEDBACK_ID); }
        set { this._FEEDBACK_ID = value; }
    }

    private int? _FEEDBACK_FEEDBACKQUESTS_ID;
    public int? FEEDBACK_FEEDBACKQUESTS_ID
    {
        get { return (this._FEEDBACK_FEEDBACKQUESTS_ID); }
        set { this._FEEDBACK_FEEDBACKQUESTS_ID = value; }
    }

    private int? _FEEDBACK_BU_ID;
    public int? FEEDBACK_BU_ID
    {
        get { return (this._FEEDBACK_BU_ID); }
        set { this._FEEDBACK_BU_ID = value; }
    }


    private string _FEEDBACK_CATEGORY;
    public string FEEDBACK_CATEGORY
    {
        get { return (this._FEEDBACK_CATEGORY); }
        set { this._FEEDBACK_CATEGORY = value; }
    }

    private int? _FEEDBACK_STATUS;
    public int? FEEDBACK_STATUS
    {
        get { return (this._FEEDBACK_STATUS); }
        set { this._FEEDBACK_STATUS = value; }
    }
    private int _FEEDBACK_ORG_ID;
    public int FEEDBACK_ORG_ID
    {
        get { return (this._FEEDBACK_ORG_ID); }
        set { this._FEEDBACK_ORG_ID = value; }
    }

    private int _FEEDBACK_BACKDATE;
    public int FEEDBACK_BACKDATE
    {
        get { return (this._FEEDBACK_BACKDATE); }
        set { this._FEEDBACK_BACKDATE = value; }
    }
    private string _FEEDBACK_NAME;
    public string FEEDBACK_NAME
    {
        get { return (this._FEEDBACK_NAME); }
        set { this._FEEDBACK_NAME = value; }
    }
    private string _FEEDBACK_DESCRIPTION;
    public string FEEDBACK_DESCRIPTION
    {
        get { return (this._FEEDBACK_DESCRIPTION); }
        set { this._FEEDBACK_DESCRIPTION = value; }
    }

    private int? _FEEDBACK_TR_ID;
    public int? FEEDBACK_TR_ID
    {
        get { return (this._FEEDBACK_TR_ID); }
        set { this._FEEDBACK_TR_ID = value; }
    }



}


#endregion

#region SMHR_RECRUITMENT_COST

public class SMHR_RECRUITMENT_COST : SMHR_MAIN
{
    private int _COST_ID;
    public int COST_ID
    {
        get { return (this._COST_ID); }
        set { this._COST_ID = value; }
    }

    private int _COST_REQ_ID;
    public int COST_REQ_ID
    {
        get { return (this._COST_REQ_ID); }
        set { this._COST_REQ_ID = value; }
    }

    private int _COST_TYPE_ID;
    public int COST_TYPE_ID
    {
        get { return (this._COST_TYPE_ID); }
        set { this._COST_TYPE_ID = value; }
    }

    private double _COST_AMOUNT;
    public double COST_AMOUNT
    {
        get { return (this._COST_AMOUNT); }
        set { this._COST_AMOUNT = value; }
    }

    private string _COST_FILEPATH;
    public string COST_FILEPATH
    {
        get { return (this._COST_FILEPATH); }
        set { this._COST_FILEPATH = value; }
    }

    private DateTime _COST_DATE;
    public DateTime COST_DATE
    {
        get { return (this._COST_DATE); }
        set { this._COST_DATE = value; }
    }

    //private int _COST_CREATED_BY
    //public int COST_CREATED_BY
    //{
    //    get {return (this._COST_CREATED_BY);}
    //    set {this._COST_CREATED_BY=value;}
    //}

    //private DateTime _COST_CREATED_DATE
    //public DateTime COST_CREATED_DATE
    //{
    //    get {return (this._COST_CREATED_DATE);}
    //    set {this._COST_CREATED_DATE=value;}
    //}

    //private int _COST_MODIFIED_BY
    //public int COST_MODIFIED_BY
    //{
    //    get {return (this._COST_MODIFIED_BY);}
    //    set {this._COST_MODIFIED_BY=value;}
    //}

    //private DateTime _COST_MODIFIED_DATE
    //public DateTime COST_MODIFIED_DATE
    //{
    //    get {return (this._COST_MODIFIED_DATE);}
    //    set {this._COST_MODIFIED_DATE=value;}
    //}
}

#endregion

#region "SMHR_TRAININGFEEDBACK_RESPONSE"

public class SMHR_TRAININGFEEDBACK_RESPONSE : SMHR_MAIN
{
    private int? _FEEDBACKRES_ID;
    public int? FEEDBACKRES_ID
    {
        get { return (this._FEEDBACKRES_ID); }
        set { this._FEEDBACKRES_ID = value; }
    }

    private int? _FEEDBACKRES_FEEDBACKQUESTS_ID;
    public int? FEEDBACKRES_FEEDBACKQUESTS_ID
    {
        get { return (this._FEEDBACKRES_FEEDBACKQUESTS_ID); }
        set { this._FEEDBACKRES_FEEDBACKQUESTS_ID = value; }
    }

    private int? _FEEDBACKRES_USER_ID;
    public int? FEEDBACKRES_USER_ID
    {
        get { return (this._FEEDBACKRES_USER_ID); }
        set { this._FEEDBACKRES_USER_ID = value; }
    }

    private string _FEEDBACKRES_RESPONSE;
    public string FEEDBACKRES_RESPONSE
    {
        get { return (this._FEEDBACKRES_RESPONSE); }
        set { this._FEEDBACKRES_RESPONSE = value; }
    }

    private DateTime? _FEEDBACKRES_DATE;
    public DateTime? FEEDBACKRES_DATE
    {
        get { return (this._FEEDBACKRES_DATE); }
        set { this._FEEDBACKRES_DATE = value; }
    }

    private string _FEEDBACKRES_COMMENTS;
    public string FEEDBACKRES_COMMENTS
    {
        get { return (this._FEEDBACKRES_COMMENTS); }
        set { this._FEEDBACKRES_COMMENTS = value; }
    }


    private string _FEEDBACKRES_STATUS;
    public string FEEDBACKRES_STATUS
    {
        get { return (this._FEEDBACKRES_STATUS); }
        set { this._FEEDBACKRES_STATUS = value; }
    }
    public int FEEDBACKRES_TR_ID { get; set; }
    public int FEEBBACKRES_FEEDBACK_NO { get; set; }
    public int FEEDBACKRES_TRAINER_ID { get; set; }


}


#endregion

#region SMHR_FEEDBACK_QUESTIONS

public class SMHR_FEEDBACK_QUESTIONS : SMHR_MAIN
{
    public SMHR_FEEDBACK_QUESTIONS(int __FEEDBACKQUESTS_ID)
    {
        this._FEEDBACKQUESTS_ID = __FEEDBACKQUESTS_ID;
    }

    public SMHR_FEEDBACK_QUESTIONS()
    {
    }
    private int _FEEDBACKQUESTS_ID;
    public int FEEDBACKQUESTS_ID
    {
        get { return (this._FEEDBACKQUESTS_ID); }
        set { this._FEEDBACKQUESTS_ID = value; }
    }
    private int _FEEDBACKQUESTS_QUESTION_CATEGORY;
    public int FEEDBACKQUESTS_QUESTION_CATEGORY
    {
        get { return (this._FEEDBACKQUESTS_QUESTION_CATEGORY); }
        set { this._FEEDBACKQUESTS_QUESTION_CATEGORY = value; }
    }

    private string _FEEDBACKQUESTS_QUESTION;
    public string FEEDBACKQUESTS_QUESTION
    {
        get { return (this._FEEDBACKQUESTS_QUESTION); }
        set { this._FEEDBACKQUESTS_QUESTION = value; }
    }

    private string _FEEDBACKQUESTS_OPTION1;
    public string FEEDBACKQUESTS_OPTION1
    {
        get { return (this._FEEDBACKQUESTS_OPTION1); }
        set { this._FEEDBACKQUESTS_OPTION1 = value; }
    }

    private string _FEEDBACKQUESTS_OPTION2;
    public string FEEDBACKQUESTS_OPTION2
    {
        get { return (this._FEEDBACKQUESTS_OPTION2); }
        set { this._FEEDBACKQUESTS_OPTION2 = value; }
    }

    private string _FEEDBACKQUESTS_OPTION3;
    public string FEEDBACKQUESTS_OPTION3
    {
        get { return (this._FEEDBACKQUESTS_OPTION3); }
        set { this._FEEDBACKQUESTS_OPTION3 = value; }
    }

    private string _FEEDBACKQUESTS_OPTION4;
    public string FEEDBACKQUESTS_OPTION4
    {
        get { return (this._FEEDBACKQUESTS_OPTION4); }
        set { this._FEEDBACKQUESTS_OPTION4 = value; }
    }

    private string _FEEDBACKQUESTS_OPTION5;
    public string FEEDBACKQUESTS_OPTION5
    {
        get { return (this._FEEDBACKQUESTS_OPTION5); }
        set { this._FEEDBACKQUESTS_OPTION5 = value; }
    }


    private string _FEEDBACKQUESTS_STATUS;
    public string FEEDBACKQUESTS_STATUS
    {
        get { return (this._FEEDBACKQUESTS_STATUS); }
        set { this._FEEDBACKQUESTS_STATUS = value; }
    }

}
#endregion
#region SMHR_SCHEDULE

public class SMHR_SCHEDULE : SMHR_MAIN
{
    public SMHR_SCHEDULE(int __Tr_Id)
    {
        this._Tr_Id = __Tr_Id;
    }

    public SMHR_SCHEDULE()
    {
    }
    private int _Tr_Id;
    public int Tr_Id
    {
        get { return (this._Tr_Id); }
        set { this._Tr_Id = value; }
    }
    private int _Tr_Name;
    public int Tr_Name
    {
        get { return (this._Tr_Name); }
        set { this._Tr_Name = value; }
    }

    private string _Tr_TrainerName;
    public string Tr_TrainerName
    {
        get { return (this._Tr_TrainerName); }
        set { this._Tr_TrainerName = value; }
    }

    private DateTime _Tr_Date;
    public DateTime Tr_Date
    {
        get { return (this._Tr_Date); }
        set { this._Tr_Date = value; }
    }

    private DateTime _Tr_Time;
    public DateTime Tr_Time
    {
        get { return (this._Tr_Time); }
        set { this._Tr_Time = value; }
    }
}
#endregion
#region SMHR_LOGINTYPE

public class SMHR_LOGINTYPE : SMHR_MAIN
{

    public SMHR_LOGINTYPE(int __LOGTYP_ID)
    {
        this._LOGTYP_ID = __LOGTYP_ID;
    }

    public SMHR_LOGINTYPE()
    {
    }

    private int _LOGTYP_ID;
    public int LOGTYP_ID
    {
        get { return (this._LOGTYP_ID); }
        set { this._LOGTYP_ID = value; }
    }

    private string _LOGTYP_CODE;
    public string LOGTYP_CODE
    {
        get { return (this._LOGTYP_CODE); }
        set { this._LOGTYP_CODE = value; }
    }

    private string _LOGTYP_DESC;
    public string LOGTYP_DESC
    {
        get { return (this._LOGTYP_DESC); }
        set { this._LOGTYP_DESC = value; }
    }
    public int LOGTYP_UNIQUEID { get; set; }
}

#endregion

#region SMHR_FORMS

public class SMHR_FORMS : SMHR_MAIN
{
    public SMHR_FORMS(int __FORMS_ID)
    {
        this._FORMS_ID = __FORMS_ID;
    }

    public SMHR_FORMS()
    {
    }


    private int _FORMS_PACKAGE_ID;
    public int FORMS_PACKAGE_ID
    {
        get { return (this._FORMS_PACKAGE_ID); }
        set { this._FORMS_PACKAGE_ID = value; }
    }
    private int _FORMS_ID;
    public int FORMS_ID
    {
        get { return (this._FORMS_ID); }
        set { this._FORMS_ID = value; }
    }
    private int _FORMS_MODULE_ID;
    public int FORMS_MODULE_ID
    {
        get { return (this._FORMS_MODULE_ID); }
        set { this._FORMS_MODULE_ID = value; }
    }
    private string _FORMS_NAME;
    public string FORMS_NAME
    {
        get { return (this._FORMS_NAME); }
        set { this._FORMS_NAME = value; }
    }

    private string _FORMS_DESC;
    public string FORMS_DESC
    {
        get { return (this._FORMS_DESC); }
        set { this._FORMS_DESC = value; }
    }

}

#endregion

#region SMHR_USERPRIVILEGES
public class SMHR_USERPRIVILEGES : SMHR_MAIN
{

    public SMHR_USERPRIVILEGES(int _ID)
    {
        this._USERPRIVILEGES_ID = _ID;
    }

    public SMHR_USERPRIVILEGES()
    {
    }
    private int _USERPRIVILEGES_ID;
    public int USERPRIVILEGES_ID
    {
        get { return (this._USERPRIVILEGES_ID); }
        set { this._USERPRIVILEGES_ID = value; }
    }
    private int _FORM_ID;
    public int FORM_ID
    {
        get { return (this._FORM_ID); }
        set { this._FORM_ID = value; }
    }

    private int _MODULE_ID;
    public int MODULE_ID
    {
        get { return (this._MODULE_ID); }
        set { this._MODULE_ID = value; }
    }

    private int _PACKAGE_ID;
    public int PACKAGE_ID
    {
        get { return (this._PACKAGE_ID); }
        set { this._PACKAGE_ID = value; }
    }
    private int _USER_ID;
    public int USER_ID
    {
        get { return (this._USER_ID); }
        set { this._USER_ID = value; }
    }

    private bool _READ;
    public bool READ
    {
        get { return (this._READ); }
        set { this._READ = value; }
    }
    private bool _WRITE;
    public bool WRITE
    {
        get { return (this._WRITE); }
        set { this._WRITE = value; }
    }

    private int _ORGANISATION_ID;
    public int ORGANISATION_ID
    {
        get { return (this._ORGANISATION_ID); }
        set { this._ORGANISATION_ID = value; }
    }
}
#endregion

#region SMHR_TYPESECURITY
public class SMHR_TYPESECURITY : SMHR_MAIN
{

    public SMHR_TYPESECURITY(int __TYPSEC_ID)
    {
        this._TYPSEC_ID = __TYPSEC_ID;
    }

    public SMHR_TYPESECURITY()
    {
    }
    private int _MODULE_ID;
    public int MODULE_ID
    {
        get { return (this._MODULE_ID); }
        set { this._MODULE_ID = value; }
    }
    private int _SUPER_MODULE_ID;
    public int SUPER_MODULE_ID
    {
        get { return (this._SUPER_MODULE_ID); }
        set { this._SUPER_MODULE_ID = value; }
    }
    private int _TYPSEC_ID;
    public int TYPSEC_ID
    {
        get { return (this._TYPSEC_ID); }
        set { this._TYPSEC_ID = value; }
    }

    private int _TYPSEC_FORMS_ID;
    public int TYPSEC_FORMS_ID
    {
        get { return (this._TYPSEC_FORMS_ID); }
        set { this._TYPSEC_FORMS_ID = value; }
    }

    private int _TYPSEC_LOGTYP_ID;
    public int TYPSEC_LOGTYP_ID
    {
        get { return (this._TYPSEC_LOGTYP_ID); }
        set { this._TYPSEC_LOGTYP_ID = value; }
    }
    private int _TYPESEC_ORG_ID;
    public int TYPESEC_ORG_ID
    {
        get { return (this._TYPESEC_ORG_ID); }
        set { this._TYPESEC_ORG_ID = value; }
    }
    private bool _TYPSEC_READ;
    public bool TYPSEC_READ
    {
        get { return (this._TYPSEC_READ); }
        set { this._TYPSEC_READ = value; }
    }

    private bool _TYPSEC_WRITE;
    public bool TYPSEC_WRITE
    {
        get { return (this._TYPSEC_WRITE); }
        set { this._TYPSEC_WRITE = value; }
    }

    private int _TYPSEC_CREATEDBY;
    public int TYPSEC_CREATEDBY
    {
        get { return (this._TYPSEC_CREATEDBY); }
        set { this._TYPSEC_CREATEDBY = value; }
    }

    private DateTime _TYPSEC_CREATEDDATE;
    public DateTime TYPSEC_CREATEDDATE
    {
        get { return (this._TYPSEC_CREATEDDATE); }
        set { this._TYPSEC_CREATEDDATE = value; }
    }

    private int _TYPSEC_LASTMDFBY;
    public int TYPSEC_LASTMDFBY
    {
        get { return (this._TYPSEC_LASTMDFBY); }
        set { this._TYPSEC_LASTMDFBY = value; }
    }

    private DateTime _TYPSEC_LASTMDFDATE;
    public DateTime TYPSEC_LASTMDFDATE
    {
        get { return (this._TYPSEC_LASTMDFDATE); }
        set { this._TYPSEC_LASTMDFDATE = value; }
    }
}

#endregion

#region SMHR_LOGININFO

public class SMHR_LOGININFO : SMHR_MAIN
{
    public SMHR_LOGININFO(int __LOGIN_ID)
    {
        this._LOGIN_ID = __LOGIN_ID;
    }

    public SMHR_LOGININFO()
    {
    }

    private int _LOGIN_ID;
    public int LOGIN_ID
    {
        get { return (this._LOGIN_ID); }
        set { this._LOGIN_ID = value; }
    }

    private string _LOGIN_USERNAME;
    public string LOGIN_USERNAME
    {
        get { return (this._LOGIN_USERNAME); }
        set { this._LOGIN_USERNAME = value; }
    }

    private string _LOGIN_PASSWORD;
    public string LOGIN_PASSWORD
    {
        get { return (this._LOGIN_PASSWORD); }
        set { this._LOGIN_PASSWORD = value; }
    }

    private int _LOGIN_EMP_ID;
    public int LOGIN_EMP_ID
    {
        get { return (this._LOGIN_EMP_ID); }
        set { this._LOGIN_EMP_ID = value; }
    }

    private string _LOGIN_EMAILID;
    public string LOGIN_EMAILID
    {
        get { return (this._LOGIN_EMAILID); }
        set { this._LOGIN_EMAILID = value; }
    }

    private int _LOGIN_TYPE;
    public int LOGIN_TYPE
    {
        get { return (this._LOGIN_TYPE); }
        set { this._LOGIN_TYPE = value; }
    }

    private bool _LOGIN_STATUS;
    public bool LOGIN_STATUS
    {
        get { return (this._LOGIN_STATUS); }
        set { this._LOGIN_STATUS = value; }
    }

    private int _LOGIN_CREATEDBY;
    public int LOGIN_CREATEDBY
    {
        get { return (this._LOGIN_CREATEDBY); }
        set { this._LOGIN_CREATEDBY = value; }
    }

    private DateTime _LOGIN_CREATEDDATE;
    public DateTime LOGIN_CREATEDDATE
    {
        get { return (this._LOGIN_CREATEDDATE); }
        set { this._LOGIN_CREATEDDATE = value; }
    }

    private int _LOGIN_LASTMDFBY;
    public int LOGIN_LASTMDFBY
    {
        get { return (this._LOGIN_LASTMDFBY); }
        set { this._LOGIN_LASTMDFBY = value; }
    }

    private DateTime _LOGIN_LASTMDFDATE;
    public DateTime LOGIN_LASTMDFDATE
    {
        get { return (this._LOGIN_LASTMDFDATE); }
        set { this._LOGIN_LASTMDFDATE = value; }
    }

    private string _LOGIN_BUSINESSUNITID;
    public string LOGIN_BUSINESSUNITID
    {
        get { return (this._LOGIN_BUSINESSUNITID); }
        set { this._LOGIN_BUSINESSUNITID = value; }
    }

    private int mLOGIN_ORGANISATION_ID;
    public int LOGIN_ORGANISATION_ID
    {
        get
        {
            return (this.mLOGIN_ORGANISATION_ID);
        }
        set
        {
            this.mLOGIN_ORGANISATION_ID = value;
        }
    }

    private string _LOGIN_PASS_CODE;
    public string LOGIN_PASS_CODE
    {
        get { return (this._LOGIN_PASS_CODE); }
        set { this._LOGIN_PASS_CODE = value; }
    }

    private string _LEAVEAPP_DOCUMENT;
    public string LEAVEAPP_DOCUMENT
    {
        get { return (this._LEAVEAPP_DOCUMENT); }
        set { this._LEAVEAPP_DOCUMENT = value; }
    }

    private int _LOGIN_PERIOD;
    public int LOGIN_PERIOD
    {
        get { return (this._LOGIN_PERIOD); }
        set { this._LOGIN_PERIOD = value; }
    }

    private int _LOGIN_PRDDTL;
    public int LOGIN_PRDDTL
    {
        get { return (this._LOGIN_PRDDTL); }
        set { this._LOGIN_PRDDTL = value; }
    }


}

#endregion

#region SMHR_LEAVEAPPLICATION

public class SMHR_LEAVEAPP : SMHR_MAIN
{
    public SMHR_LEAVEAPP(int __LEAVEAPP_ID)
    {
        this._LEAVEAPP_ID = __LEAVEAPP_ID;
    }

    public SMHR_LEAVEAPP()
    {
    }

    private int _LEAVEAPP_ID;
    public int LEAVEAPP_ID
    {
        get { return (this._LEAVEAPP_ID); }
        set { this._LEAVEAPP_ID = value; }
    }

    private int _LEAVEAPP_LEAVETYPE_ID;
    public int LEAVEAPP_LEAVETYPE_ID
    {
        get { return (this._LEAVEAPP_LEAVETYPE_ID); }
        set { this._LEAVEAPP_LEAVETYPE_ID = value; }
    }

    private int _LEAVEAPP_EMP_ID;
    public int LEAVEAPP_EMP_ID
    {
        get { return (this._LEAVEAPP_EMP_ID); }
        set { this._LEAVEAPP_EMP_ID = value; }
    }

    private int _LEAVEAPP_STATUS;
    public int LEAVEAPP_STATUS
    {
        get { return (this._LEAVEAPP_STATUS); }
        set { this._LEAVEAPP_STATUS = value; }
    }

    private DateTime _LEAVEAPP_APPLIEDDATE;
    public DateTime LEAVEAPP_APPLIEDDATE
    {
        get { return (this._LEAVEAPP_APPLIEDDATE); }
        set { this._LEAVEAPP_APPLIEDDATE = value; }
    }
    private DateTime _LEAVEAPP_FROMDATE;
    public DateTime LEAVEAPP_FROMDATE
    {
        get { return (this._LEAVEAPP_FROMDATE); }
        set { this._LEAVEAPP_FROMDATE = value; }
    }

    private DateTime _LEAVEAPP_TODATE;
    public DateTime LEAVEAPP_TODATE
    {
        get { return (this._LEAVEAPP_TODATE); }
        set { this._LEAVEAPP_TODATE = value; }
    }

    private bool _LEAVEAPP_FIRSTHALF;
    public bool LEAVEAPP_FIRSTHALF
    {
        get { return (this._LEAVEAPP_FIRSTHALF); }
        set { this._LEAVEAPP_FIRSTHALF = value; }
    }

    private bool _LEAVEAPP_SECONDHALF;
    public bool LEAVEAPP_SECONDHALF
    {
        get { return (this._LEAVEAPP_SECONDHALF); }
        set { this._LEAVEAPP_SECONDHALF = value; }
    }

    private float _LEAVEAPP_DAYS;
    public float LEAVEAPP_DAYS
    {
        get { return (this._LEAVEAPP_DAYS); }
        set { this._LEAVEAPP_DAYS = value; }
    }

    public double LEAVEAPPDAYS { get; set; }

    private string _LEAVEAPP_REASON;
    public string LEAVEAPP_REASON
    {
        get { return (this._LEAVEAPP_REASON); }
        set { this._LEAVEAPP_REASON = value; }
    }
    public DateTime LEAVE_ROLLBACKDATE { get; set; }
    private int _LEAVEAPP_APPROVEDBY;
    public int LEAVEAPP_APPROVEDBY
    {
        get { return (this._LEAVEAPP_APPROVEDBY); }
        set { this._LEAVEAPP_APPROVEDBY = value; }
    }

    private DateTime _LEAVEAPP_APPROVEDATE;
    public DateTime LEAVEAPP_APPROVEDATE
    {
        get { return (this._LEAVEAPP_APPROVEDATE); }
        set { this._LEAVEAPP_APPROVEDATE = value; }
    }

    private int _MODE;

    public int MODE
    {
        get { return (this._MODE); }
        set { this._MODE = value; }
    }

    private int _BUSINESSUNIT_ID;

    public int BUSINESSUNIT_ID
    {
        get { return (this._BUSINESSUNIT_ID); }
        set { this._BUSINESSUNIT_ID = value; }
    }

    private string _LEAVEAPP_DOCUMENT;
    public string LEAVEAPP_DOCUMENT
    {
        get { return (this._LEAVEAPP_DOCUMENT); }
        set { this._LEAVEAPP_DOCUMENT = value; }
    }

    private int _EMP_ID;
    public int EMP_ID
    {
        get { return (this._EMP_ID); }
        set { this._EMP_ID = value; }
    }
    private string _LEAVEAPP_REJECT_REASON;
    public string LEAVEAPP_REJECT_REASON
    {
        get { return (this._LEAVEAPP_REJECT_REASON); }
        set { this._LEAVEAPP_REJECT_REASON = value; }
    }

    private int _LEAVEAPP_INCIDENT_ID;
    public int LEAVEAPP_INCIDENT_ID
    {
        get { return (this._LEAVEAPP_INCIDENT_ID); }
        set { this._LEAVEAPP_INCIDENT_ID = value; }
    }

    public int LEAVEAPP_CAL_PERIOD { get; set; }
    public int SD { get; set; }
    public int ED { get; set; }
}


#endregion

#region SMHR_LEAVEBALANCE

public class SMHR_LEAVEBALANCE : SMHR_MAIN
{
    private int _LT_EMPID;

    public int LT_EMPID
    {
        get { return (this._LT_EMPID); }
        set { this._LT_EMPID = value; }
    }

    private int _LT_ID;

    public int LT_ID
    {
        get { return (this._LT_ID); }
        set { this._LT_ID = value; }

    }

    private int _MODE;

    public int MODE
    {
        get { return (this._MODE); }
        set { this._MODE = value; }
    }

    private int _LT_LEAVETYPEID;

    public int LT_LEAVETYPEID
    {
        get { return (this._LT_LEAVETYPEID); }
        set { this._LT_LEAVETYPEID = value; }
    }

    private int _Months;

    public int Months
    {
        get { return (this._Months); }
        set { this._Months = value; }
    }

    private string _EMPNAME;

    public string EMPNAME
    {
        get { return (this._EMPNAME); }
        set { this._EMPNAME = value; }
    }

    private float _NDays;

    public float NDays
    {
        get { return (this._NDays); }
        set { this._NDays = value; }
    }

    private String _Year;

    public String Year
    {
        get { return (this._Year); }
        set { this._Year = value; }
    }
    private int _LEAVEAPP_ID;

    public int LEAVEAPP_ID
    {
        get { return (this._LEAVEAPP_ID); }
        set { this._LEAVEAPP_ID = value; }
    }

    public int LT_PRD_ID { get; set; }
}

#endregion

#region SMHR_EMPOTTRANS

public class SMHR_EMPOTTRANS : SMHR_MAIN
{

    public SMHR_EMPOTTRANS(int __EMPOTTRANS_ID)
    {
        this._EMPOTTRANS_ID = __EMPOTTRANS_ID;
    }

    public SMHR_EMPOTTRANS()
    {
    }

    private int _EMPOTTRANS_ID;
    public int EMPOTTRANS_ID
    {
        get { return (this._EMPOTTRANS_ID); }
        set { this._EMPOTTRANS_ID = value; }
    }

    private int _EMPOTTRANS_TYPEID;
    public int EMPOTTRANS_TYPEID
    {
        get { return (this._EMPOTTRANS_TYPEID); }
        set { this._EMPOTTRANS_TYPEID = value; }
    }

    private int _EMPOTTRANS_EMPID;
    public int EMPOTTRANS_EMPID
    {
        get { return (this._EMPOTTRANS_EMPID); }
        set { this._EMPOTTRANS_EMPID = value; }
    }

    private int _EMPOTTRANS_PERIOD_ID;
    public int EMPOTTRANS_PERIOD_ID
    {
        get { return (this._EMPOTTRANS_PERIOD_ID); }
        set { this._EMPOTTRANS_PERIOD_ID = value; }
    }

    private int _EMPOTTRANS_HOURS;
    public int EMPOTTRANS_HOURS
    {
        get { return (this._EMPOTTRANS_HOURS); }
        set { this._EMPOTTRANS_HOURS = value; }
    }

    private DateTime _EMPOTTRANS_DATE;
    public DateTime EMPOTTRANS_DATE
    {
        get { return (this._EMPOTTRANS_DATE); }
        set { this._EMPOTTRANS_DATE = value; }
    }

    private int _EMPOTTRANS_PERIODDTL_ID;
    public int EMPOTTRANS_PERIODDTL_ID
    {
        get
        {
            return (this._EMPOTTRANS_PERIODDTL_ID);
        }
        set
        {
            this._EMPOTTRANS_PERIODDTL_ID = value;
        }
    }

    private float? _EMPOTTANS_AMOUNT;

    public float? EMPOTTANS_AMOUNT
    {
        get
        {
            return (this._EMPOTTANS_AMOUNT);
        }
        set
        {
            this._EMPOTTANS_AMOUNT = value;
        }
    }

    private int _EMPOTTRANS_STATUS;
    public int EMPOTTRANS_STATUS
    {
        get { return (this._EMPOTTRANS_STATUS); }
        set { this._EMPOTTRANS_STATUS = value; }
    }

    private int _EMPOTTRANS_APPROVEDBY;
    public int EMPOTTRANS_APPROVEDBY
    {
        get { return (this._EMPOTTRANS_APPROVEDBY); }
        set { this._EMPOTTRANS_APPROVEDBY = value; }
    }

    private DateTime _EMPOTTRANS_APPROVEDDATE;
    public DateTime EMPOTTRANS_APPROVEDDATE
    {
        get { return (this._EMPOTTRANS_APPROVEDDATE); }
        set { this._EMPOTTRANS_APPROVEDDATE = value; }
    }

    private string _EMPOTTRANS_EMPLOYEE;
    public string EMPOTTRANS_EMPLOYEE
    {
        get { return (this._EMPOTTRANS_EMPLOYEE); }
        set { this._EMPOTTRANS_EMPLOYEE = value; }
    }

    private string _OTCALC_EMPCODE;
    public string OTCALC_EMPCODE
    {
        get { return (this._OTCALC_EMPCODE); }
        set { this._OTCALC_EMPCODE = value; }
    }
    private int _OTCALC_ACTUALHOURS;
    public int OTCALC_ACTUALHOURS
    {
        get { return (this._OTCALC_ACTUALHOURS); }
        set { this._OTCALC_ACTUALHOURS = value; }
    }
    private string _OTCALC_COMMENTS;
    public string OTCALC_COMMENTS
    {
        get { return (this._OTCALC_COMMENTS); }
        set { this._OTCALC_COMMENTS = value; }
    }
    private DateTime _OTCALC_DATE;
    public DateTime OTCALC_DATE
    {
        get { return (this._OTCALC_DATE); }
        set { this._OTCALC_DATE = value; }
    }
    private int _OTCALC_ORG_ID;
    public int OTCALC_ORG_ID
    {
        get { return (this._OTCALC_ORG_ID); }
        set { this._OTCALC_ORG_ID = value; }
    }
    //private DateTime _OTCALC_FROMTIME;
    //public DateTime OTCALC_FROMTIME


    public TimeSpan OTCALC_FROMTIME { get; set; }
    public TimeSpan OTCALC_TOTIME { get; set; }
    public int OTCALC_EMPID { get; set; }

}

#endregion

#region SMHR_ATTENDANCE

public class SMHR_ATTENDANCE : SMHR_MAIN
{
    private int _ATTENDANCE_ID;
    public int ATTENDANCE_ID
    {
        get { return (this._ATTENDANCE_ID); }
        set { this._ATTENDANCE_ID = value; }
    }

    private int _ATTENDANCE_PERIOD_DTL_ID;
    public int ATTENDANCE_PERIOD_DTL_ID
    {
        get { return (this._ATTENDANCE_PERIOD_DTL_ID); }
        set { this._ATTENDANCE_PERIOD_DTL_ID = value; }
    }

    private int _ATTENDANCE_PERIOD_ID;
    public int ATTENDANCE_PERIOD_ID
    {
        get { return (this._ATTENDANCE_PERIOD_ID); }
        set { this._ATTENDANCE_PERIOD_ID = value; }
    }
    private int _ATTENDANCE_BU_ID;
    public int ATTENDANCE_BU_ID
    {
        get { return (this._ATTENDANCE_BU_ID); }
        set { this._ATTENDANCE_BU_ID = value; }
    }

    private int _ATTENDANCE_EMP_ID;
    public int ATTENDANCE_EMP_ID
    {
        get { return (this._ATTENDANCE_EMP_ID); }
        set { this._ATTENDANCE_EMP_ID = value; }
    }
    private string _DATE_STRING;
    public string DATE_STRING
    {
        get { return (this._DATE_STRING); }
        set { this._DATE_STRING = value; }
    }
    private DateTime _ATTENDANCE_DATE;
    public DateTime ATTENDANCE_DATE
    {
        get { return (this._ATTENDANCE_DATE); }
        set { this._ATTENDANCE_DATE = value; }
    }

    private string _ATTENDANCE_STATUS;
    public string ATTENDANCE_STATUS
    {
        get { return (this._ATTENDANCE_STATUS); }
        set { this._ATTENDANCE_STATUS = value; }
    }

    private int _ATTENDANCE_FINALIZE;
    public int ATTENDANCE_FINALIZE
    {
        get { return (this._ATTENDANCE_FINALIZE); }
        set { this._ATTENDANCE_FINALIZE = value; }
    }

    private bool _ATTENDANCE_MODE;
    public bool ATTENDANCE_MODE
    {
        get { return (this._ATTENDANCE_MODE); }
        set { this._ATTENDANCE_MODE = value; }
    }

    private string _ATTENDANCE_INTIME;
    public string ATTENDANCE_INTIME
    {
        get { return (this._ATTENDANCE_INTIME); }
        set { this._ATTENDANCE_INTIME = value; }
    }

    private string _ATTENDANCE_OUTTIME;
    public string ATTENDANCE_OUTTIME
    {
        get { return (this._ATTENDANCE_OUTTIME); }
        set { this._ATTENDANCE_OUTTIME = value; }
    }

    private double _ATTENDANCE_NOOFHOURS;
    public double ATTENDANCE_NOOFHOURS
    {
        get { return (this._ATTENDANCE_NOOFHOURS); }
        set { this._ATTENDANCE_NOOFHOURS = value; }
    }

    private DataTable _dtEmpAttendance;
    public DataTable dtEmpAttendance
    {
        get { return _dtEmpAttendance; }
        set { _dtEmpAttendance = value; }
    }
}

#endregion

#region SMHR_LEAVEMASTER

public class SMHR_LEAVEMASTER : SMHR_MAIN
{
    public SMHR_LEAVEMASTER(int __LEAVEMASTER_ID)
    {
        this._LEAVEMASTER_ID = __LEAVEMASTER_ID;
    }

    public SMHR_LEAVEMASTER()
    {
    }

    private int _LEAVEMASTER_ID;

    public int LEAVEMASTER_ID
    {
        get { return (this._LEAVEMASTER_ID); }
        set { this._LEAVEMASTER_ID = value; }
    }

    public Boolean LEAVEMASTER_ALLOWPAY { get; set; }
    private string _LEAVEMASTER_CODE;

    public string LEAVEMASTER_CODE
    {
        get { return (this._LEAVEMASTER_CODE); }
        set { this._LEAVEMASTER_CODE = value; }
    }


    private string _LEAVEMASTER_DESCRIPTION;

    public string LEAVEMASTER_DESCRIPTION
    {
        get { return (this._LEAVEMASTER_DESCRIPTION); }
        set { this._LEAVEMASTER_DESCRIPTION = value; }
    }

    private int _LEAVEMASTER_COMPOFF;

    public int LEAVEMASTER_COMPOFF
    {
        get { return (this._LEAVEMASTER_COMPOFF); }
        set { this._LEAVEMASTER_COMPOFF = value; }
    }
    public bool LEAVEMASTER_ISINCIDENT { get; set; }
}

#endregion

#region SMHR_EMPCOMPOFF

public class SMHR_EMPCOMOFF : SMHR_MAIN
{
    public SMHR_EMPCOMOFF(int __EMPCOMPOFF_ID)
    {
        this._EMPCOMPOFF_ID = __EMPCOMPOFF_ID;
    }

    public SMHR_EMPCOMOFF()
    {
    }
    private int _EMPCOMPOFF_ID;

    public int EMPCOMPOFF_ID
    {
        get { return (this._EMPCOMPOFF_ID); }
        set { this._EMPCOMPOFF_ID = value; }
    }

    private int _EMPCOMPOFF_EMPID;

    public int EMPCOMPOFF_EMPID
    {
        get { return (this._EMPCOMPOFF_EMPID); }
        set { this._EMPCOMPOFF_EMPID = value; }
    }

    private DateTime _EMPCOMPOFF_WORKDAY;

    public DateTime EMPCOMPOFF_WORKDAY
    {
        get { return (this._EMPCOMPOFF_WORKDAY); }
        set { this._EMPCOMPOFF_WORKDAY = value; }
    }
    private DateTime _EMPCOMPOFF_COMPOFFDAY;

    public DateTime EMPCOMPOFF_COMPOFFDAY
    {
        get { return (this._EMPCOMPOFF_COMPOFFDAY); }
        set { this._EMPCOMPOFF_COMPOFFDAY = value; }
    }
    private float _EMPCOMPOFF_DAYS;

    public float EMPCOMPOFF_DAYS
    {
        get { return (this._EMPCOMPOFF_DAYS); }
        set { this._EMPCOMPOFF_DAYS = value; }
    }

    private string _EMPCOMPOFF_REASON;

    public string EMPCOMPOFF_REASON
    {
        get { return (this._EMPCOMPOFF_REASON); }
        set { this._EMPCOMPOFF_REASON = value; }
    }

    private int _EMPCOMPOFF_STATUS;

    public int EMPCOMPOFF_STATUS
    {
        get { return (this._EMPCOMPOFF_STATUS); }
        set { this._EMPCOMPOFF_STATUS = value; }
    }

    private int _EMPCOMPOFF_APPROVEDBY;

    public int EMPCOMPOFF_APPROVEDBY
    {
        get { return (this._EMPCOMPOFF_APPROVEDBY); }
        set { this._EMPCOMPOFF_APPROVEDBY = value; }
    }

    private DateTime _EMPCOMPOFF_APPROVEDDATE;

    public DateTime EMPCOMPOFF_APPROVEDDATE
    {
        get { return (this._EMPCOMPOFF_APPROVEDDATE); }
        set { this._EMPCOMPOFF_APPROVEDDATE = value; }
    }

    private string _EMPCOMPOFF_LOGINTIME;

    public string EMPCOMPOFF_LOGINTIME
    {
        get { return (this._EMPCOMPOFF_LOGINTIME); }
        set { this._EMPCOMPOFF_LOGINTIME = value; }
    }


    private DateTime _EMPCOMPOFF_APPLIEDDATE;

    public DateTime EMPCOMPOFF_APPLIEDDATE
    {
        get { return (this._EMPCOMPOFF_APPLIEDDATE); }
        set { this._EMPCOMPOFF_APPLIEDDATE = value; }
    }

    private string _EMPCOMPOFF_LOGOUTTIME;

    public string EMPCOMPOFF_LOGOUTTIME
    {
        get { return (this._EMPCOMPOFF_LOGOUTTIME); }
        set { this._EMPCOMPOFF_LOGOUTTIME = value; }
    }


    private string _EMPCOMPOFF_APPROVALREMARKS;

    public string EMPCOMPOFF_APPROVALREMARKS
    {
        get { return (this._EMPCOMPOFF_APPROVALREMARKS); }
        set { this._EMPCOMPOFF_APPROVALREMARKS = value; }
    }

    private int _EMP_ID;
    public int EMP_ID
    {
        get { return (this._EMP_ID); }
        set { this._EMP_ID = value; }
    }

    private int _EMPCOMPOFF_LEAVETYPE;
    public int EMPCOMPOFF_LEAVETYPE
    {
        get { return (this._EMPCOMPOFF_LEAVETYPE); }
        set { this._EMPCOMPOFF_LEAVETYPE = value; }
    }
}

#endregion

#region SMHR_EMP_PAYITEMS

public class SMHR_EMP_PAYITEMS : SMHR_MAIN
{
    private int _SMHR_EMP_PAYITEMS_ID;
    public int SMHR_EMP_PAYITEMS_ID
    {
        get { return (this._SMHR_EMP_PAYITEMS_ID); }
        set { this._SMHR_EMP_PAYITEMS_ID = value; }
    }

    private bool _SMHR_EMP_PAYITEMS_CHECKED;
    public bool SMHR_EMP_PAYITEMS_CHECKED
    {
        get { return (this._SMHR_EMP_PAYITEMS_CHECKED); }
        set { this._SMHR_EMP_PAYITEMS_CHECKED = value; }
    }


    private int _SMHR_EMP_PAYITEMS_EMPID;
    public int SMHR_EMP_PAYITEMS_EMPID
    {
        get { return (this._SMHR_EMP_PAYITEMS_EMPID); }
        set { this._SMHR_EMP_PAYITEMS_EMPID = value; }
    }

    private int _SMHR_EMP_PAYITEMS_PAYITEMID;
    public int SMHR_EMP_PAYITEMS_PAYITEMID
    {
        get { return (this._SMHR_EMP_PAYITEMS_PAYITEMID); }
        set { this._SMHR_EMP_PAYITEMS_PAYITEMID = value; }
    }

    private double _SMHR_EMP_PAYITEMS_VALUE;
    public double SMHR_EMP_PAYITEMS_VALUE
    {
        get { return (this._SMHR_EMP_PAYITEMS_VALUE); }
        set { this._SMHR_EMP_PAYITEMS_VALUE = value; }
    }

    private int _SMHR_EMP_PAYITEMS_CREATEDBY;
    public int SMHR_EMP_PAYITEMS_CREATEDBY
    {
        get { return (this._SMHR_EMP_PAYITEMS_CREATEDBY); }
        set { this._SMHR_EMP_PAYITEMS_CREATEDBY = value; }
    }

    private DateTime _SMHR_EMP_PAYITEMS_CREATEDDATE;
    public DateTime SMHR_EMP_PAYITEMS_CREATEDDATE
    {
        get { return (this._SMHR_EMP_PAYITEMS_CREATEDDATE); }
        set { this._SMHR_EMP_PAYITEMS_CREATEDDATE = value; }
    }

    private int _SMHR_EMP_PAYITEMS_LASTMDFBY;
    public int SMHR_EMP_PAYITEMS_LASTMDFBY
    {
        get { return (this._SMHR_EMP_PAYITEMS_LASTMDFBY); }
        set { this._SMHR_EMP_PAYITEMS_LASTMDFBY = value; }
    }

    private DateTime _SMHR_EMP_PAYITEMS_LASTMDFDATE;
    public DateTime SMHR_EMP_PAYITEMS_LASTMDFDATE
    {
        get { return (this._SMHR_EMP_PAYITEMS_LASTMDFDATE); }
        set { this._SMHR_EMP_PAYITEMS_LASTMDFDATE = value; }
    }

    private int _SMHR_EMP_PAYITEMS_ORGANISATION_ID;
    public int SMHR_EMP_PAYITEMS_ORGANISATION_ID
    {
        get { return (this._SMHR_EMP_PAYITEMS_ORGANISATION_ID); }
        set{this._SMHR_EMP_PAYITEMS_ORGANISATION_ID=value;}

    }


    private int _SMHR_BUSUNIT;
    public int SMHR_BUSUNIT
    {
        get { return (this._SMHR_BUSUNIT); }
        set { this._SMHR_BUSUNIT = value; }
    }
    private int _EMP_ID;
    public int EMP_ID
    {
        get { return (this._EMP_ID); }
        set { this._EMP_ID = value; }
    }
    private int _PERIOD_ID;
    public int PERIOD_ID
    {
        get { return (this._PERIOD_ID); }
        set { this._PERIOD_ID = value; }
    }
    private int _REPORTING_EMP_ID;
    public int REPORTING_EMP_ID
    {
        get { return (this._REPORTING_EMP_ID); }
        set { this._REPORTING_EMP_ID = value; }
    }
    private string _SMHR_EMP_PAYITEMS_CALMODE;
    public string SMHR_EMP_PAYITEMS_CALMODE
    {
        get { return (this._SMHR_EMP_PAYITEMS_CALMODE); }
        set { this._SMHR_EMP_PAYITEMS_CALMODE = value; }
    }
}

#endregion

#region SMHR_LOB

public class SMHR_LOB : SMHR_MAIN
{
    private int _LOB_ID;

    public int LOB_ID
    {
        get { return (this._LOB_ID); }
        set { this._LOB_ID = value; }
    }

    private int _LOB_BUID;

    public int LOB_BUID
    {
        get { return (this._LOB_BUID); }
        set { this._LOB_BUID = value; }
    }

    public double LT_BAL { get; set; }

    private int _lOB_PERIODID;

    public int LOB_PERIODID
    {
        get
        {
            return (this._lOB_PERIODID);
        }
        set
        {
            this._lOB_PERIODID = value;
        }
    }


    private int? _LOB_EMPID;

    public int? LOB_EMPID
    {
        get { return (this._LOB_EMPID); }
        set { this._LOB_EMPID = value; }
    }

    private int _LOB_LEAVETYPEID;

    public int LOB_LEAVETYPEID
    {
        get { return (this._LOB_LEAVETYPEID); }
        set { this._LOB_LEAVETYPEID = value; }
    }

    private int _LOB_NOOFDAYS;

    public int LOB_NOOFDAYS
    {
        get { return (this._LOB_NOOFDAYS); }
        set { this._LOB_NOOFDAYS = value; }
    }

    private int _LOB_FINALISE;

    public int LOB_FINALISE
    {
        get { return (this._LOB_FINALISE); }
        set { this._LOB_FINALISE = value; }
    }

    private int _LOB_CREATEDBY;

    public int LOB_CREATEDBY
    {
        get { return (this._LOB_CREATEDBY); }
        set { this._LOB_CREATEDBY = value; }
    }

    private DateTime _LOB_CREATEDDATE;

    public DateTime LOB_CREATEDDATE
    {
        get { return (this._LOB_CREATEDDATE); }
        set { this._LOB_CREATEDDATE = value; }
    }

    private int _LOB_LASTMDFBY;

    public int LOB_LASTMDFBY
    {
        get { return (this._LOB_LASTMDFBY); }
        set { this._LOB_LASTMDFBY = value; }
    }

    private DateTime _LOB_LASTMDFDATE;

    public DateTime LOB_LASTMDFDATE
    {
        get { return (this._LOB_LASTMDFDATE); }
        set { this._LOB_LASTMDFDATE = value; }
    }

    private int _LT_EMPID;
    public int LT_EMPID
    {
        get { return (this._LT_EMPID); }
        set { this._LT_EMPID = value; }
    }

    private int _LT_LEAVETYPEID;
    public int LT_LEAVETYPEID
    {
        get { return (this._LT_LEAVETYPEID); }
        set { this._LT_LEAVETYPEID = value; }
    }

    private int _LT_LOB;
    public int LT_LOB
    {
        get { return (this._LT_LOB); }
        set { this._LT_LOB = value; }
    }

    private double _LT_LEAVEENTITLED;
    public double LT_LEAVEENTITLED
    {
        get { return (this._LT_LEAVEENTITLED); }
        set { this._LT_LEAVEENTITLED = value; }
    }

    private double _LT_CURRENTBALANCE;
    public double LT_CURRENTBALANCE
    {
        get { return (this._LT_CURRENTBALANCE); }
        set { this._LT_CURRENTBALANCE = value; }
    }

    private int _LT_PERIOD;
    public int LT_PERIOD
    {
        get { return (this._LT_PERIOD); }
        set { this._LT_PERIOD = value; }
    }
    private string _LT_LEAVECODE;
    public string LT_LEAVECODE
    {
        get { return (this._LT_LEAVECODE); }
        set { this._LT_LEAVECODE = value; }
    }
}

#endregion

#region SMHR_LOANTRANSDTL

public class SMHR_LOANTRANSDTL : SMHR_MAIN
{

    private int _LOANTRANDTL_ID;

    public int LOANTRANDTL_ID
    {
        get { return (this._LOANTRANDTL_ID); }
        set { this._LOANTRANDTL_ID = value; }
    }

    private int _LOANTRADTL_LOANTRAN_ID;

    public int LOANTRADTL_LOANTRAN_ID
    {
        get { return (this._LOANTRADTL_LOANTRAN_ID); }
        set { this._LOANTRADTL_LOANTRAN_ID = value; }
    }

    private string _LOANTRANDTL_LOANNO;

    public string LOANTRANDTL_LOANNO
    {
        get { return (this._LOANTRANDTL_LOANNO); }
        set { this._LOANTRANDTL_LOANNO = value; }
    }


    private DateTime _LOANTRANDTL_EMIPAYMENTDUEDATE;

    public DateTime LOANTRANDTL_EMIPAYMENTDUEDATE
    {
        get { return (this._LOANTRANDTL_EMIPAYMENTDUEDATE); }
        set { this._LOANTRANDTL_EMIPAYMENTDUEDATE = value; }
    }

    private double _LOANTRANDTL_EMIAMOUNT;

    public double LOANTRANDTL_EMIAMOUNT
    {
        get { return (this._LOANTRANDTL_EMIAMOUNT); }
        set { this._LOANTRANDTL_EMIAMOUNT = value; }
    }

    private int _LOANTRANDTL_EMISTATUS;

    public int LOANTRANDTL_EMISTATUS
    {
        get { return (this._LOANTRANDTL_EMISTATUS); }
        set { this._LOANTRANDTL_EMISTATUS = value; }
    }

    private double _LOANTRANDTL_CURRENTBALANCEAMOUNT;

    public double LOANTRANDTL_CURRENTBALANCEAMOUNT
    {
        get { return (this._LOANTRANDTL_CURRENTBALANCEAMOUNT); }
        set { this._LOANTRANDTL_CURRENTBALANCEAMOUNT = value; }
    }

    private double _LOANTRANDTL_CURRENTLOANAMOUNT;

    public double LOANTRANDTL_CURRENTLOANAMOUNT
    {
        get { return (this._LOANTRANDTL_CURRENTLOANAMOUNT); }
        set { this._LOANTRANDTL_CURRENTLOANAMOUNT = value; }
    }

    private int _LOANTRANDTL_CURR_EMINO;

    public int LOANTRANDTL_CURR_EMINO
    {
        get { return (this._LOANTRANDTL_CURR_EMINO); }
        set { this._LOANTRANDTL_CURR_EMINO = value; }
    }

    private double _LOANTRANDTL_INTEREST;
    public double LOANTRANDTL_INTEREST
    {
        get { return _LOANTRANDTL_INTEREST; }
        set { _LOANTRANDTL_INTEREST = value; }
    }

    private double _LOANTRANDTL_PRINCIPLEAMT;
    public double LOANTRANDTL_PRINCIPLEAMT
    {
        get { return _LOANTRANDTL_PRINCIPLEAMT; }
        set { _LOANTRANDTL_PRINCIPLEAMT = value; }
    }

    private string _LOANTRANS_COMMENTS;
    public string LOANTRANS_COMMENTS
    {
        get { return _LOANTRANS_COMMENTS; }
        set { _LOANTRANS_COMMENTS = value; }
    }

    private int _LOANTRANDTLS_CREATEDBY;
    public int LOANTRANDTLS_CREATEDBY
    {
        get { return _LOANTRANDTLS_CREATEDBY; }
        set { _LOANTRANDTLS_CREATEDBY = value; }
    }

    private DateTime _LOANTRANDTLS_CREATEDDATE;
    public DateTime LOANTRANDTLS_CREATEDDATE
    {
        get { return _LOANTRANDTLS_CREATEDDATE; }
        set { _LOANTRANDTLS_CREATEDDATE = value; }
    }


    private int _LOANTRANDTLS_MDFYBY;
    public int LOANTRANDTLS_MDFYBY
    {
        get { return _LOANTRANDTLS_MDFYBY; }
        set { _LOANTRANDTLS_MDFYBY = value; }
    }

    private DateTime _LOANTRANDTLS_MDFYDATE;
    public DateTime LOANTRANDTLS_MDFYDATE
    {
        get { return _LOANTRANDTLS_MDFYDATE; }
        set { _LOANTRANDTLS_MDFYDATE = value; }
    }
}

#endregion

#region SMHR_LOANRPT

public class SMHR_LOANRPT : SMHR_MAIN
{
    private int _LOANRPT_ID;

    public int LOANRPT_ID
    {
        get { return (this._LOANRPT_ID); }
        set { this._LOANRPT_ID = value; }
    }

    private double _LOANRPT_BALANCEAMOUNT;

    public double LOANRPT_BALANCEAMOUNT
    {
        get { return (this._LOANRPT_BALANCEAMOUNT); }
        set { this._LOANRPT_BALANCEAMOUNT = value; }
    }

    private double _LOANRPT_REPAYMENTAMOUNT;

    public double LOANRPT_REPAYMENTAMOUNT
    {
        get { return (this._LOANRPT_REPAYMENTAMOUNT); }
        set { this._LOANRPT_REPAYMENTAMOUNT = value; }
    }

    private string _LOANRPT_CHEQUENO;

    public string LOANRPT_CHEQUENO
    {
        get { return (this._LOANRPT_CHEQUENO); }
        set { this._LOANRPT_CHEQUENO = value; }
    }

    private string _LOANRPT_BANKNAME;

    public string LOANRPT_BANKNAME
    {
        get { return (this._LOANRPT_BANKNAME); }
        set { this._LOANRPT_BANKNAME = value; }
    }

    private string _LOANRPT_BRANCHNAME;

    public string LOANRPT_BRANCHNAME
    {
        get { return (this._LOANRPT_BRANCHNAME); }
        set { this._LOANRPT_BRANCHNAME = value; }
    }

    private int _LOANRPT_INSTALLMENTS;

    public int LOANRPT_INSTALLMENTS
    {
        get { return (this._LOANRPT_INSTALLMENTS); }
        set { this._LOANRPT_INSTALLMENTS = value; }
    }
    private float _LOANRPT_INTERESTRATE;

    public float LOANRPT_INTERESTRATE
    {
        get { return (this._LOANRPT_INTERESTRATE); }
        set { this._LOANRPT_INTERESTRATE = value; }
    }

    private float _LOANRPT_REVISEDEMI;

    public float LOANRPT_REVISEDEMI
    {
        get { return (this._LOANRPT_REVISEDEMI); }
        set { this._LOANRPT_REVISEDEMI = value; }
    }

    private DateTime _LOANRPT_DATEOFTRANS;

    public DateTime LOANRPT_DATEOFTRANS
    {
        get { return (this._LOANRPT_DATEOFTRANS); }
        set { this._LOANRPT_DATEOFTRANS = value; }
    }

}

#endregion

#region SMHR_PAYITEMS

public class SMHR_PAYITEMS : SMHR_MAIN
{
    private string _PAYITEM_YTD;
    public string PAYITEM_YTD
    {
        get { return (this._PAYITEM_YTD); }
        set { this._PAYITEM_YTD = value; }
    }

    private int _PAYITEM_LOAN_INTEREST;
    public int PAYITEM_LOAN_INTEREST
    {
        get { return (this._PAYITEM_LOAN_INTEREST); }
        set { this._PAYITEM_LOAN_INTEREST = value; }
    }

    private int _PAYITEM_ID;
    public int PAYITEM_ID
    {
        get { return _PAYITEM_ID; }
        set { _PAYITEM_ID = value; }
    }

    private string _PAYITEM_PAYITEMNAME;

    public string PAYITEM_PAYITEMNAME
    {
        get { return _PAYITEM_PAYITEMNAME; }
        set { _PAYITEM_PAYITEMNAME = value; }
    }
    private string _PAYITEM_PAYDESC;

    public string PAYITEM_PAYDESC
    {
        get { return _PAYITEM_PAYDESC; }
        set { _PAYITEM_PAYDESC = value; }
    }

    private int _PAYITEM_ITEMTYPE_ID;
    public int PAYITEM_ITEMTYPE_ID
    {
        get { return _PAYITEM_ITEMTYPE_ID; }
        set { _PAYITEM_ITEMTYPE_ID = value; }
    }


    private int _PAYITEM_ITEMMODE_ID;
    public int PAYITEM_ITEMMODE_ID
    {
        get { return _PAYITEM_ITEMMODE_ID; }
        set { _PAYITEM_ITEMMODE_ID = value; }
    }

    private string _PAYITEM_LOAN_PROCESS_TYPE;
    public string PAYITEM_LOAN_PROCESS_TYPE
    {
        get { return _PAYITEM_LOAN_PROCESS_TYPE; }
        set { _PAYITEM_LOAN_PROCESS_TYPE = value; }
    }

    private string _PAYITEM_CALMODE;
    public string PAYITEM_CALMODE
    {
        get { return _PAYITEM_CALMODE; }
        set { _PAYITEM_CALMODE = value; }
    }

    private bool _PAYITEM_PROCESSTYPE;
    public bool PAYITEM_PROCESSTYPE
    {
        get { return _PAYITEM_PROCESSTYPE; }
        set { _PAYITEM_PROCESSTYPE = value; }
    }

    private int _PAYITEM_PROCESSPRIORITY;
    public int PAYITEM_PROCESSPRIORITY
    {
        get { return _PAYITEM_PROCESSPRIORITY; }
        set { _PAYITEM_PROCESSPRIORITY = value; }
    }

    private DateTime _PAYITEM_STARTDATE;
    public DateTime PAYITEM_STARTDATE
    {
        get { return _PAYITEM_STARTDATE; }
        set { _PAYITEM_STARTDATE = value; }
    }

    private DateTime? _PAYITEM_ENDDATE;
    public DateTime? PAYITEM_ENDDATE
    {
        get { return _PAYITEM_ENDDATE; }
        set { _PAYITEM_ENDDATE = value; }
    }



    private bool _PAYITEM_PRINTINPAYREG;
    public bool PAYITEM_PRINTINPAYREG
    {
        get { return _PAYITEM_PRINTINPAYREG; }
        set { _PAYITEM_PRINTINPAYREG = value; }
    }

    private bool _PAYITEM_PRINTINPAYSLIP;

    public bool PAYITEM_PRINTINPAYSLIP
    {
        get { return (this._PAYITEM_PRINTINPAYSLIP); }
        set { this._PAYITEM_PRINTINPAYSLIP = value; }
    }


    private bool _PAYITEM_CTC;
    public bool PAYITEM_CTC
    {
        get { return (this._PAYITEM_CTC); }
        set { this._PAYITEM_CTC = value; }
    }


    private bool _PAYITEM_INDIVIDUAL;
    public bool PAYITEM_INDIVIDUAL
    {
        get { return (this._PAYITEM_INDIVIDUAL); }
        set { this._PAYITEM_INDIVIDUAL = value; }
    }


    private bool _PAYITEM_AUTOMATIC;
    public bool PAYITEM_AUTOMATIC
    {
        get { return (this._PAYITEM_AUTOMATIC); }
        set { this._PAYITEM_AUTOMATIC = value; }
    }

    private int _PAYITEM_CREATEDBY;
    public int PAYITEM_CREATEDBY
    {
        get { return _PAYITEM_CREATEDBY; }
        set { _PAYITEM_CREATEDBY = value; }
    }

    private DateTime _PAYITEM_CREATEDDATE;
    public DateTime PAYITEM_CREATEDDATE
    {
        get { return _PAYITEM_CREATEDDATE; }
        set { _PAYITEM_CREATEDDATE = value; }
    }

    private int _PAYITEM_LASTMDFBY;
    public int PAYITEM_LASTMDFBY
    {
        get { return _PAYITEM_LASTMDFBY; }
        set { _PAYITEM_LASTMDFBY = value; }
    }

    private DateTime _PAYITEM_LASTMDFDATE;
    public DateTime PAYITEM_LASTMDFDATE
    {
        get { return _PAYITEM_LASTMDFDATE; }
        set { _PAYITEM_LASTMDFDATE = value; }
    }



    private string _EMPASSETDOC_TYPE;
    public string EMPASSETDOC_TYPE
    {
        get { return _EMPASSETDOC_TYPE; }
        set { _EMPASSETDOC_TYPE = value; }
    }

    private string _pAYITEM_ACCOUNTHEAD;

    public string PAYITEM_ACCOUNTHEAD
    {
        get
        {
            return (this._pAYITEM_ACCOUNTHEAD);
        }
        set
        {
            this._pAYITEM_ACCOUNTHEAD = value;
        }
    }

    private string _PAYITEM_ACCOUNTTYPE;
    public string PAYITEM_ACCOUNTTYPE
    {
        get { return (this._PAYITEM_ACCOUNTTYPE); }
        set { this._PAYITEM_ACCOUNTTYPE = value; }
    }

    private string _PAYITEM_POSTINGPROFILE;
    public string PAYITEM_POSTINGPROFILE
    {
        get { return (this._PAYITEM_POSTINGPROFILE); }
        set { this._PAYITEM_POSTINGPROFILE = value; }
    }

    private bool _PAYITEM_ISBENEFITABLE;
    public bool PAYITEM_ISBENFITABLE
    {
        get { return (this._PAYITEM_ISBENEFITABLE); }
        set { this._PAYITEM_ISBENEFITABLE = value; }
    }

    private bool _PAYITEM_ISTAXABLE;
    public bool PAYITEM_ISTAXABLE
    {
        get { return (this._PAYITEM_ISTAXABLE); }
        set { this._PAYITEM_ISTAXABLE = value; }
    }

    private bool _PAYITEM_ISOA_INCLUDED;
    public bool PAYITEM_ISOA_INCLUDED
    {
        get { return (this._PAYITEM_ISOA_INCLUDED); }
        set { this._PAYITEM_ISOA_INCLUDED = value; }
    }
    private double _PAYITEM_MINIMUM_PERCENTAGE_VALUE;
    public double PAYITEM_MINIMUM_PERCENTAGE_VALUE
    {
        get { return (this._PAYITEM_MINIMUM_PERCENTAGE_VALUE); }
        set { this._PAYITEM_MINIMUM_PERCENTAGE_VALUE = value; }
    }
    private bool _PAYITEM_ISAFFECTLOP;
    public bool PAYITEM_ISAFFECTLOP
    {
        get { return (this._PAYITEM_ISAFFECTLOP); }
        set { this._PAYITEM_ISAFFECTLOP = value; }
    }

    private int _PAYITEM_FINPERIODID;
    public int PAYITEM_FINPERIODID
    {
        get { return (this._PAYITEM_FINPERIODID); }
        set { this._PAYITEM_FINPERIODID = value; }
    }

    private int _PAYITEM_LOAN_PROCESSTYPE;
    public int PAYITEM_LOAN_PROCESSTYPE
    {
        get { return (this._PAYITEM_LOAN_PROCESSTYPE); }
        set { this._PAYITEM_LOAN_PROCESSTYPE = value; }
    }

    public decimal PAYITEM_INSTAXRELIEF { get; set; }
    public string PAYITEM_VOTENAME { get; set; }

    public bool PAYITEM_ISLOANVAILDATE { get; set; }
    public string PAYITEM_PROJECTID { get; set; }

    public bool PAYITEM_ISNULLIFY { get; set; }
}

#endregion

#region SMHR_GLOBALCONFIG

public class SMHR_GLOBALCONFIG : SMHR_MAIN
{
    private int _GLOBALCONFIG_ID;
    public int GLOBALCONFIG_ID
    {
        get { return (this._GLOBALCONFIG_ID); }
        set { this._GLOBALCONFIG_ID = value; }
    }

    private int _GLOBALCONFIG_NEXT_ID;
    public int GLOBALCONFIG_NEXT_ID
    {
        get { return (this._GLOBALCONFIG_NEXT_ID); }
        set { this._GLOBALCONFIG_NEXT_ID = value; }
    }

    private int _GLOBALCONFIG_APP_ID;
    public int GLOBALCONFIG_APP_ID
    {
        get { return (this._GLOBALCONFIG_APP_ID); }
        set { this._GLOBALCONFIG_APP_ID = value; }
    }

    private int _GLOBALCONFIG_EMP_ID;
    public int GLOBALCONFIG_EMP_ID
    {
        get { return (this._GLOBALCONFIG_EMP_ID); }
        set { this._GLOBALCONFIG_EMP_ID = value; }
    }

    private int _GLOBALCONFIG_NextEMP_ID;
    public int GLOBALCONFIG_NextEMP_ID
    {
        get { return (this._GLOBALCONFIG_NextEMP_ID); }
        set { this._GLOBALCONFIG_NextEMP_ID = value; }
    }

    private int _GLOBALCONFIG_LOAN_ID;
    public int GLOBALCONFIG_LOAN_ID
    {
        get { return (this._GLOBALCONFIG_LOAN_ID); }
        set { this._GLOBALCONFIG_LOAN_ID = value; }
    }

    private string _GLOBALCONFIG_LOAN_NO;
    public string GLOBALCONFIG_LOAN_NO
    {
        get { return (this._GLOBALCONFIG_LOAN_NO); }
        set { this._GLOBALCONFIG_LOAN_NO = value; }
    }

    private int _GLOBALCONFIG_INCIDENT_ID;
    public int GLOBALCONFIG_INCIDENT_ID
    {
        get { return (this._GLOBALCONFIG_INCIDENT_ID); }
        set { this._GLOBALCONFIG_INCIDENT_ID = value; }
    }

    private string _GLOBALCONFIG_INCIDENT_PREFIX;
    public string GLOBALCONFIG_INCIDENT_PREFIX
    {
        get { return (this._GLOBALCONFIG_INCIDENT_PREFIX); }
        set { this._GLOBALCONFIG_INCIDENT_PREFIX = value; }
    }
    public int GLOBALCONFIG_ORG_EMP_CNT { get; set; }

    private int _GLOBALCONFIG_DISCIPLINE_ID;
    public int GLOBALCONFIG_DISCIPLINE_ID
    {
        get { return (this._GLOBALCONFIG_DISCIPLINE_ID); }
        set { this._GLOBALCONFIG_DISCIPLINE_ID = value; }
    }

    private string _GLOBALCONFIG_DISCIPLINE_PREFIX;
    public string GLOBALCONFIG_DISCIPLINE_PREFIX
    {
        get { return (this._GLOBALCONFIG_DISCIPLINE_PREFIX); }
        set { this._GLOBALCONFIG_DISCIPLINE_PREFIX = value; }
    }

    private string _GLOBALCONFIG_EMP_CODE;
    public string GLOBALCONFIG_EMP_CODE
    {
        get { return (this._GLOBALCONFIG_EMP_CODE); }
        set { this._GLOBALCONFIG_EMP_CODE = value; }
    }
    private string _GLOBALCONFIG_CONSULTANT_EMP_CODE;
    public string GLOBALCONFIG_CONSULTANT_EMP_CODE
    {
        get { return (this._GLOBALCONFIG_CONSULTANT_EMP_CODE); }
        set { this._GLOBALCONFIG_CONSULTANT_EMP_CODE = value; }
    }
    private string _GLOBALCONFIG_CONTRACT_EMP_CODE;
    public string GLOBALCONFIG_CONTRACT_EMP_CODE
    {
        get { return (this._GLOBALCONFIG_CONTRACT_EMP_CODE); }
        set { this._GLOBALCONFIG_CONTRACT_EMP_CODE = value; }
    }
    private string _GLOBALCONFIG_APP_CODE;
    public string GLOBALCONFIG_APP_CODE
    {
        get { return (this._GLOBALCONFIG_APP_CODE); }
        set { this._GLOBALCONFIG_APP_CODE = value; }
    }

    private string _GLOBALCONFIG_DOMAIN_IP;
    public string GLOBALCONFIG_DOMAIN_IP
    {
        get { return (this._GLOBALCONFIG_DOMAIN_IP); }
        set { this._GLOBALCONFIG_DOMAIN_IP = value; }
    }

    private string _GLOBALCONFIG_USERNAME;
    public string GLOBALCONFIG_USERNAME
    {
        get { return (this._GLOBALCONFIG_USERNAME); }
        set { this._GLOBALCONFIG_USERNAME = value; }
    }

    private string _GLOBALCONFIG_PWD;
    public string GLOBALCONFIG_PWD
    {
        get { return (this._GLOBALCONFIG_PWD); }
        set { this._GLOBALCONFIG_PWD = value; }
    }

    private string _GLOBALCONFIG_MAILID;
    public string GLOBALCONFIG_MAILID
    {
        get { return (this._GLOBALCONFIG_MAILID); }
        set { this._GLOBALCONFIG_MAILID = value; }
    }

    private string _GLOBALCONFIG_TRAVEL_REQUEST_CODE;
    public string GLOBALCONFIG_TRAVEL_REQUEST_CODE
    {
        get { return (this._GLOBALCONFIG_TRAVEL_REQUEST_CODE); }
        set { this._GLOBALCONFIG_TRAVEL_REQUEST_CODE = value; }
    }

    private int _GLOBALCONFIG_TRAVEL_REQUEST_ID;
    public int GLOBALCONFIG_TRAVEL_REQUEST_ID
    {
        get { return (this._GLOBALCONFIG_TRAVEL_REQUEST_ID); }
        set { this._GLOBALCONFIG_TRAVEL_REQUEST_ID = value; }
    }

    private int _GLOBALCONFIG_SALSTRUCT_CODE;
    public int GLOBALCONFIG_SALSTRUCT_CODE
    {
        get { return (this._GLOBALCONFIG_SALSTRUCT_CODE); }
        set { this._GLOBALCONFIG_SALSTRUCT_CODE = value; }
    }

    private int _GLOBALCONFIG_PERIOD_CODE;
    public int GLOBALCONFIG_PERIOD_CODE
    {
        get { return (this._GLOBALCONFIG_PERIOD_CODE); }
        set { this._GLOBALCONFIG_PERIOD_CODE = value; }
    }

    private int _GLOBALCONFIG_JOB_REQ_CODE;
    public int GLOBALCONFIG_JOB_REQ_CODE
    {
        get { return (this._GLOBALCONFIG_JOB_REQ_CODE); }
        set { this._GLOBALCONFIG_JOB_REQ_CODE = value; }
    }

    private string _GLOABLCONFIG_THEME;
    public string GLOABLCONFIG_THEME
    {
        get { return (this._GLOABLCONFIG_THEME); }
        set { this._GLOABLCONFIG_THEME = value; }
    }

    private string _GLOBALCONFIG_DATEFORMAT;
    public string GLOBALCONFIG_DATEFORMAT
    {
        get { return (this._GLOBALCONFIG_DATEFORMAT); }
        set { this._GLOBALCONFIG_DATEFORMAT = value; }
    }

    private int _GLOBALCONFIG_MINAGE;
    public int GLOBALCONFIG_MINAGE
    {
        get { return (this._GLOBALCONFIG_MINAGE); }
        set { this._GLOBALCONFIG_MINAGE = value; }
    }

    private int _GLOBALCONFIG_MAXAGE;
    public int GLOBALCONFIG_MAXAGE
    {
        get { return (this._GLOBALCONFIG_MAXAGE); }
        set { this._GLOBALCONFIG_MAXAGE = value; }
    }

    private bool _GLOBALCONFIG_APPLIEDDATES;
    public bool GLOBALCONFIG_APPLIEDDATES
    {
        get { return (this._GLOBALCONFIG_APPLIEDDATES); }
        set { this._GLOBALCONFIG_APPLIEDDATES = value; }
    }

    private string _GLOBALCONFIG_COMPANYLOGO;
    public string GLOBALCONFIG_COMPANYLOGO
    {
        get { return (this._GLOBALCONFIG_COMPANYLOGO); }
        set { this._GLOBALCONFIG_COMPANYLOGO = value; }
    }

    private int _GLOBALCONFIG_LEAVETRANFLAG;
    public int GLOBALCONFIG_LEAVETRANFLAG
    {
        get { return (this._GLOBALCONFIG_LEAVETRANFLAG); }
        set { this._GLOBALCONFIG_LEAVETRANFLAG = value; }
    }

    private string _GLOBALCONFIG_RECRUIT_JOBREQ_CODE;
    public string GLOBALCONFIG_RECRUIT_JOBREQ_CODE
    {
        get { return (this._GLOBALCONFIG_RECRUIT_JOBREQ_CODE); }
        set { this._GLOBALCONFIG_RECRUIT_JOBREQ_CODE = value; }
    }
    private string _PayrollFooterMsg;
    public string PayrollFooterMsg
    {
        get { return (this._PayrollFooterMsg); }
        set { this._PayrollFooterMsg = value; }
    }



    private int mGLOBALCONFIG_CONTRACTNO;
    public int GLOBALCONFIG_CONTRACTNO
    {
        get
        {
            return (this.mGLOBALCONFIG_CONTRACTNO);
        }
        set
        {
            this.mGLOBALCONFIG_CONTRACTNO = value;
        }
    }

    private int mGLOBALCONFIG_TRAINEENO;
    public int GLOBALCONFIG_TRAINEENO
    {
        get
        {
            return (this.mGLOBALCONFIG_TRAINEENO);
        }
        set
        {
            this.mGLOBALCONFIG_TRAINEENO = value;
        }
    }

    private int mGLOBALCONFIG_COMPANYLOGO_WIDTH;

    public int GLOBALCONFIG_COMPANYLOGO_WIDTH
    {
        get
        {
            return (this.mGLOBALCONFIG_COMPANYLOGO_WIDTH);
        }
        set
        {
            this.mGLOBALCONFIG_COMPANYLOGO_WIDTH = value;
        }
    }

    private int mGLOBALCONFIG_COMPANYLOGO_HEIGHT;

    public int GLOBALCONFIG_COMPANYLOGO_HEIGHT
    {
        get
        {
            return (this.mGLOBALCONFIG_COMPANYLOGO_HEIGHT);
        }
        set
        {
            this.mGLOBALCONFIG_COMPANYLOGO_HEIGHT = value;
        }
    }

    private int _GLOBALCONFIG_ORGANISATION_ID;
    public int GLOBALCONFIG_ORGANISATION_ID
    {
        get { return (this._GLOBALCONFIG_ORGANISATION_ID); }
        set { this._GLOBALCONFIG_ORGANISATION_ID = value; }
    }

    private double _GLOBALCONFIG_PEN_REGAMT;
    public double GLOBALCONFIG_PEN_REGAMT
    {
        get { return _GLOBALCONFIG_PEN_REGAMT; }
        set { _GLOBALCONFIG_PEN_REGAMT = value; }
    }
    private double _GLOBALCONFIG_INSTAXRELIEF;
    public double GLOBALCONFIG_INSTAXRELIEF
    {
        get { return _GLOBALCONFIG_INSTAXRELIEF; }
        set { _GLOBALCONFIG_INSTAXRELIEF = value; }
    }

}

#endregion

#region SMHR_EMPASSETDOC

public class SMHR_EMPASSETDOC : SMHR_MAIN
{
    private int _EMPASSETDOC_ID;
    public int EMPASSETDOC_ID
    {
        get { return (this._EMPASSETDOC_ID); }
        set { this._EMPASSETDOC_ID = value; }
    }

    private int _EMPASSETDOC_BU_ID;
    public int EMPASSETDOC_BU_ID
    {
        get { return (this._EMPASSETDOC_BU_ID); }
        set { this._EMPASSETDOC_BU_ID = value; }
    }


    private int? _EMPASSETDOC_CREATED_BY;
    public int? EMPASSETDOC_CREATED_BY
    {
        get { return (this._EMPASSETDOC_CREATED_BY); }
        set { this._EMPASSETDOC_CREATED_BY = value; }
    }

    private DateTime? _EMPASSETDOC_CREATEDDATE;
    public DateTime? EMPASSETDOC_CREATEDDATE
    {
        get { return (this._EMPASSETDOC_CREATEDDATE); }
        set { this._EMPASSETDOC_CREATEDDATE = value; }
    }

    private int? _EMPASSETDOC_LSTMDFBY;
    public int? EMPASSETDOC_LSTMDFBY
    {
        get { return (this._EMPASSETDOC_LSTMDFBY); }
        set { this._EMPASSETDOC_LSTMDFBY = value; }
    }

    private DateTime? _EMPASSETDOC_LSTMDFDATE;
    public DateTime? EMPASSETDOC_LSTMDFDATE
    {
        get { return (this._EMPASSETDOC_LSTMDFDATE); }
        set { this._EMPASSETDOC_LSTMDFDATE = value; }
    }


    private int _EMPASSETDOC_EMP_ID;
    public int EMPASSETDOC_EMP_ID
    {
        get { return (this._EMPASSETDOC_EMP_ID); }
        set { this._EMPASSETDOC_EMP_ID = value; }
    }

    private string _ASSETDOC_UPLOAD;
    public string ASSETDOC_UPLOAD
    {
        get { return (this._ASSETDOC_UPLOAD); }
        set { this._ASSETDOC_UPLOAD = value; }
    }

    private string _EMPASSETDOC_TYPE;
    public string EMPASSETDOC_TYPE
    {
        get { return (this._EMPASSETDOC_TYPE); }
        set { this._EMPASSETDOC_TYPE = value; }
    }

    private int _EMPASSETDOC_SERIAL;
    public int EMPASSETDOC_SERIAL
    {
        get { return (this._EMPASSETDOC_SERIAL); }
        set { this._EMPASSETDOC_SERIAL = value; }
    }

    private int _EMPASSETDOC_DEPT_ID;
    public int EMPASSETDOC_DEPT_ID
    {
        get { return (this._EMPASSETDOC_DEPT_ID); }
        set { this._EMPASSETDOC_DEPT_ID = value; }
    }
    private string _EMPASSETDOC_CODE;
    public string EMPASSETDOC_CODE
    {
        get { return (this._EMPASSETDOC_CODE); }
        set { this._EMPASSETDOC_CODE = value; }
    }

    private string _EMPASSETDOC_NAME;
    public string EMPASSETDOC_NAME
    {
        get { return (this._EMPASSETDOC_NAME); }
        set { this._EMPASSETDOC_NAME = value; }
    }

    private string _EMP_ASSETDOC_AD_Type;
    public string EMP_ASSETDOC_AD_Type
    {
        get { return (this._EMP_ASSETDOC_AD_Type); }
        set { this._EMP_ASSETDOC_AD_Type = value; }
    }

    private DateTime _EMP_ASSETDOC_ISSUEDATE;
    public DateTime EMP_ASSETDOC_ISSUEDATE
    {
        get { return (this._EMP_ASSETDOC_ISSUEDATE); }
        set { this._EMP_ASSETDOC_ISSUEDATE = value; }
    }

    private bool _EMP_ASSETDOC_RETURNABLE;
    public bool EMP_ASSETDOC_RETURNABLE
    {
        get { return (this._EMP_ASSETDOC_RETURNABLE); }
        set { this._EMP_ASSETDOC_RETURNABLE = value; }
    }

    private string _EMP_ASSETDOC_REMARKS;
    public string EMP_ASSETDOC_REMARKS
    {
        get { return (this._EMP_ASSETDOC_REMARKS); }
        set { this._EMP_ASSETDOC_REMARKS = value; }
    }

    private int _EMP_ASSETDOC_STATUS;

    public int EMP_ASSETDOC_STATUS
    {
        get { return (this._EMP_ASSETDOC_STATUS); }
        set { this._EMP_ASSETDOC_STATUS = value; }
    }

    private int? _EMP_ASSETDOC_RECBY;
    public int? EMP_ASSETDOC_RECBY
    {
        get { return (this._EMP_ASSETDOC_RECBY); }
        set { this._EMP_ASSETDOC_RECBY = value; }
    }

    //Inserted By Ragha Sudha on Sep 17th 2013
    private decimal _EMP_ASSETDOC_AMOUNT_RECEIVED;
    public decimal EMP_ASSETDOC_AMOUNT_RECEIVED
    {
        get { return (this._EMP_ASSETDOC_AMOUNT_RECEIVED); }
        set { this._EMP_ASSETDOC_AMOUNT_RECEIVED = value; }
    }
    //Inserted By Ragha Sudha on Sep 17th 2013

    private DateTime? _EMP_ASSETDOC_RECDATE;
    public DateTime? EMP_ASSETDOC_RECDATE
    {
        get { return (this._EMP_ASSETDOC_RECDATE); }
        set { this._EMP_ASSETDOC_RECDATE = value; }
    }

    private int _MODE;
    public int MODE
    {
        get { return (this._MODE); }
        set { this._MODE = value; }
    }
    private int _EMPDOCS_ID;
    public int EMPDOCS_ID
    {
        get { return (this._EMPDOCS_ID); }
        set { this._EMPDOCS_ID = value; }
    }
    private int _EMPDOCS_ASSETDOC_ID;
    public int EMPDOCS_ASSETDOC_ID
    {
        get { return (this._EMPDOCS_ASSETDOC_ID); }
        set { this._EMPDOCS_ASSETDOC_ID = value; }
    }
    private string _EMPDOCS_NAME;
    public string EMPDOCS_NAME
    {
        get { return (this._EMPDOCS_NAME); }
        set { this._EMPDOCS_NAME = value; }
    }
    private string _EMPDOCS_UPLOAD;
    public string EMPDOCS_UPLOAD
    {
        get { return (this._EMPDOCS_UPLOAD); }
        set { this._EMPDOCS_UPLOAD = value; }
    }
}

#endregion

#region SMHR EMPWORKSHOPS

public class SMHR_EMPWORKSHOPSATTENDED : SMHR_MAIN
{
    private int _EMPWRKSHOPS_ID;
    public int EMPWRKSHOPS_ID
    {
        get { return (this._EMPWRKSHOPS_ID); }
        set { this._EMPWRKSHOPS_ID = value; }
    }

    private int _EMPWRKSHOPS_BUSINESSUNIT;
    public int EMPWRKSHOPS_BUSINESSUNIT
    {
        get { return (this._EMPWRKSHOPS_BUSINESSUNIT); }
        set { this._EMPWRKSHOPS_BUSINESSUNIT = value; }
    }

    private int _EMPWRKSHOPS_ORGID;
    public int EMPWRKSHOPS_ORGID
    {
        get { return (this._EMPWRKSHOPS_ORGID); }
        set { this._EMPWRKSHOPS_ORGID = value; }
    }

    private int _EMPWRKSHOPS_DIRECTORATEID;
    public int EMPWRKSHOPS_DIRECTORATEID
    {
        get { return (this._EMPWRKSHOPS_DIRECTORATEID); }
        set { this._EMPWRKSHOPS_DIRECTORATEID = value; }
    }

    private int _EMPWRKSHOPS_DEPARTMENTID;
    public int EMPWRKSHOPS_DEPARTMENTID
    {
        get { return (this._EMPWRKSHOPS_DEPARTMENTID); }
        set { this._EMPWRKSHOPS_DEPARTMENTID = value; }
    }

    private int _EMPWRKSHOPS_EMPID;
    public int EMPWRKSHOPS_EMPID
    {
        get { return (this._EMPWRKSHOPS_EMPID); }
        set { this._EMPWRKSHOPS_EMPID = value; }
    }

    private string _EMPWRKSHOPS_NAME;
    public string EMPWRKSHOPS_NAME
    {
        get { return (this._EMPWRKSHOPS_NAME); }
        set { this._EMPWRKSHOPS_NAME = value; }
    }

    private string _EMPWRKSHOPS_ORGBY;
    public string EMPWRKSHOPS_ORGBY
    {
        get { return (this._EMPWRKSHOPS_ORGBY); }
        set { this._EMPWRKSHOPS_ORGBY = value; }
    }
    private string _EMPWRKSHOPS_SPNOSDBY;
    public string EMPWRKSHOPS_SPNOSDBY
    {
        get { return (this._EMPWRKSHOPS_SPNOSDBY); }
        set { this._EMPWRKSHOPS_SPNOSDBY = value; }
    }
    private DateTime? _EMPWRKSHOPS_FROMDATE;
    public DateTime? EMPWRKSHOPS_FROMDATE
    {
        get { return (this._EMPWRKSHOPS_FROMDATE); }
        set { this._EMPWRKSHOPS_FROMDATE = value; }
    }

    private DateTime? _EMPWRKSHOPS_TODATE;
    public DateTime? EMPWRKSHOPS_TODATE
    {
        get { return (this._EMPWRKSHOPS_TODATE); }
        set { this._EMPWRKSHOPS_TODATE = value; }
    }
    private string _EMPWRKSHOPS_OUTCOME;
    public string EMPWRKSHOPS_OUTCOME
    {
        get { return (this._EMPWRKSHOPS_OUTCOME); }
        set { this._EMPWRKSHOPS_OUTCOME = value; }
    }

    private string _EMPWRKSHOPS_PARTCERTDOC;
    public string EMPWRKSHOPS_PARTCERTDOC
    {
        get { return (this._EMPWRKSHOPS_PARTCERTDOC); }
        set { this._EMPWRKSHOPS_PARTCERTDOC = value; }
    }
    private string _EMPWRKSHOPS_PARTCERTDOCNAME;
    public string EMPWRKSHOPS_PARTCERTDOCNAME
    {
        get { return (this._EMPWRKSHOPS_PARTCERTDOCNAME); }
        set { this._EMPWRKSHOPS_PARTCERTDOCNAME = value; }
    }
    private string _EMPWRKSHOPS_PARTCERTDOCUPLOAD;
    public string EMPWRKSHOPS_PARTCERTDOCUPLOAD
    {
        get { return (this._EMPWRKSHOPS_PARTCERTDOCUPLOAD); }
        set { this._EMPWRKSHOPS_PARTCERTDOCUPLOAD = value; }
    }
}
#endregion

#region SMHR EMP ORG SPONSORED COURSES
public class SMHR_EMPORGSPNSCOURSES : SMHR_MAIN
{
    private int _EMPORGSPNSRCRS_ID;
    public int EMPORGSPNSRCRS_ID
    {
        get { return (this._EMPORGSPNSRCRS_ID); }
        set { this._EMPORGSPNSRCRS_ID = value; }
    }

    private int _EMPORGSPNSRCRS_BUSINESSUNIT;
    public int EMPORGSPNSRCRS_BUSINESSUNIT
    {
        get { return (this._EMPORGSPNSRCRS_BUSINESSUNIT); }
        set { this._EMPORGSPNSRCRS_BUSINESSUNIT = value; }
    }

    private int _EMPORGSPNSRCRS_ORGID;
    public int EMPORGSPNSRCRS_ORGID
    {
        get { return (this._EMPORGSPNSRCRS_ORGID); }
        set { this._EMPORGSPNSRCRS_ORGID = value; }
    }

    private int _EMPORGSPNSRCRS_DIRECTORATEID;
    public int EMPORGSPNSRCRS_DIRECTORATEID
    {
        get { return (this._EMPORGSPNSRCRS_DIRECTORATEID); }
        set { this._EMPORGSPNSRCRS_DIRECTORATEID = value; }
    }

    private int _EMPORGSPNSRCRS_DEPARTMENTID;
    public int EMPORGSPNSRCRS_DEPARTMENTID
    {
        get { return (this._EMPORGSPNSRCRS_DEPARTMENTID); }
        set { this._EMPORGSPNSRCRS_DEPARTMENTID = value; }
    }


    private int _EMPORGSPNSRCRS_EMPID;
    public int EMPORGSPNSRCRS_EMPID
    {
        get { return (this._EMPORGSPNSRCRS_EMPID); }
        set { this._EMPORGSPNSRCRS_EMPID = value; }
    }

    private string _EMPORGSPNSRCRS_COURSENAME;
    public string EMPORGSPNSRCRS_COURSENAME
    {
        get { return (this._EMPORGSPNSRCRS_COURSENAME); }
        set { this._EMPORGSPNSRCRS_COURSENAME = value; }
    }

    private DateTime? _EMPORGSPNSRCRS_FROMDATE;
    public DateTime? EMPORGSPNSRCRS_FROMDATE
    {
        get { return (this._EMPORGSPNSRCRS_FROMDATE); }
        set { this._EMPORGSPNSRCRS_FROMDATE = value; }
    }

    private DateTime? _EMPORGSPNSRCRS_TODATE;
    public DateTime? EMPORGSPNSRCRS_TODATE
    {
        get { return (this._EMPORGSPNSRCRS_TODATE); }
        set { this._EMPORGSPNSRCRS_TODATE = value; }
    }
    private string _EMPORGSPNSRCRS_OUTCOME;
    public string EMPORGSPNSRCRS_OUTCOME
    {
        get { return (this._EMPORGSPNSRCRS_OUTCOME); }
        set { this._EMPORGSPNSRCRS_OUTCOME = value; }
    }

    private string _EMPORGSPNSRCRS_CERTDOC;
    public string EMPORGSPNSRCRS_CERTDOC
    {
        get { return (this._EMPORGSPNSRCRS_CERTDOC); }
        set { this._EMPORGSPNSRCRS_CERTDOC = value; }
    }

    private string _EMPORGSPNSRCRS_CERTDOCNAME;
    public string EMPORGSPNSRCRS_CERTDOCNAME
    {
        get { return (this._EMPORGSPNSRCRS_CERTDOCNAME); }
        set { this._EMPORGSPNSRCRS_CERTDOCNAME = value; }
    }


    private string _EMPORGSPNSRCRS_CERTDOCUPLOAD;
    public string EMPORGSPNSRCRS_CERTDOCUPLOAD
    {
        get { return (this._EMPORGSPNSRCRS_CERTDOCUPLOAD); }
        set { this._EMPORGSPNSRCRS_CERTDOCUPLOAD = value; }
    }
}

#endregion

#region SMHR_LOANTRANS

public class SMHR_LOANTRANS : SMHR_MAIN
{
    private int _LOANTRANS_ID;
    public int LOANTRANS_ID
    {
        get { return (this._LOANTRANS_ID); }
        set { this._LOANTRANS_ID = value; }
    }
    private int _DepositsId;
    public int DepositsId
    {
        get { return (this._DepositsId); }
        set { this._DepositsId = value; }
    }

    private int _LOANTRANS_EMP_ID;
    public int LOANTRANS_EMP_ID
    {
        get { return (this._LOANTRANS_EMP_ID); }
        set { this._LOANTRANS_EMP_ID = value; }
    }

    private string _LOANTRANS_LOANNO;
    public string LOANTRANS_LOANNO
    {
        get { return (this._LOANTRANS_LOANNO); }
        set { this._LOANTRANS_LOANNO = value; }
    }

    private string _LOANTRANS_PROCESS_TYPE;
    public string LOANTRANS_PROCESS_TYPE
    {
        get { return (this._LOANTRANS_PROCESS_TYPE); }
        set { this._LOANTRANS_PROCESS_TYPE = value; }
    }

    private int _LOANTRANS_LOANTYPE_ID;
    public int LOANTRANS_LOANTYPE_ID
    {
        get { return (this._LOANTRANS_LOANTYPE_ID); }
        set { this._LOANTRANS_LOANTYPE_ID = value; }
    }

    private DateTime _LOANTRANS_ISSUEDATE;
    public DateTime LOANTRANS_ISSUEDATE
    {
        get { return (this._LOANTRANS_ISSUEDATE); }
        set { this._LOANTRANS_ISSUEDATE = value; }
    }

    private double _LOANTRANS_LOANAMOUNT;
    public double LOANTRANS_LOANAMOUNT
    {
        get { return (this._LOANTRANS_LOANAMOUNT); }
        set { this._LOANTRANS_LOANAMOUNT = value; }
    }
    private double _UpdatedLoanAmt;
    public double UpdatedLoanAmt
    {
        get { return (this._UpdatedLoanAmt); }
        set { this._UpdatedLoanAmt = value; }
    }
    private double _AccumulativeBalance;
    public double AccumulativeBalance
    {
        get { return (this._AccumulativeBalance); }
        set { this._AccumulativeBalance = value; }
    }
    private double _LOANTRANS_INTERESTAMT;
    public double LOANTRANS_INTERESTAMT
    {
        get { return (this._LOANTRANS_INTERESTAMT); }
        set { this._LOANTRANS_INTERESTAMT = value; }
    }

    private double _LOANTRANS_INTERESTRATE;
    public double LOANTRANS_INTERESTRATE
    {
        get { return (this._LOANTRANS_INTERESTRATE); }
        set { this._LOANTRANS_INTERESTRATE = value; }
    }

    private DateTime _LOANTRANS_EFFDATE;
    public DateTime LOANTRANS_EFFDATE
    {
        get { return (this._LOANTRANS_EFFDATE); }
        set { this._LOANTRANS_EFFDATE = value; }
    }

    private string _LOANTRAN_LOANPURPOSE;
    public string LOANTRAN_LOANPURPOSE
    {
        get { return (this._LOANTRAN_LOANPURPOSE); }
        set { this._LOANTRAN_LOANPURPOSE = value; }
    }

    private double _LOANTRAN_BALANCELOAN;
    public double LOANTRAN_BALANCELOAN
    {
        get { return (this._LOANTRAN_BALANCELOAN); }
        set { this._LOANTRAN_BALANCELOAN = value; }
    }

    private int _LOANTRAN_CREATEDBY;
    public int LOANTRAN_CREATEDBY
    {
        get { return (this._LOANTRAN_CREATEDBY); }
        set { this._LOANTRAN_CREATEDBY = value; }
    }

    private DateTime _LOANTRAN_CREATEDDATE;
    public DateTime LOANTRAN_CREATEDDATE
    {
        get { return (this._LOANTRAN_CREATEDDATE); }
        set { this._LOANTRAN_CREATEDDATE = value; }
    }

    private int _LOANTRAN_LASTMDFBY;
    public int LOANTRAN_LASTMDFBY
    {
        get { return (this._LOANTRAN_LASTMDFBY); }
        set { this._LOANTRAN_LASTMDFBY = value; }
    }

    private DateTime _LOANTRAN_LASTMDFDATE;
    public DateTime LOANTRAN_LASTMDFDATE
    {
        get { return (this._LOANTRAN_LASTMDFDATE); }
        set { this._LOANTRAN_LASTMDFDATE = value; }
    }

    private int _LOANTRANS_LOANINSTALL;
    public int LOANTRANS_LOANINSTALL
    {
        get { return (this._LOANTRANS_LOANINSTALL); }
        set { this._LOANTRANS_LOANINSTALL = value; }
    }

    private string _CONFIRM;

    public string CONFIRM
    {
        get { return (this._CONFIRM); }
        set { this._CONFIRM = value; }
    }

    private int _BUSINESSUNIT_ID;

    public int BUSINESSUNIT_ID
    {
        get { return (this._BUSINESSUNIT_ID); }
        set { this._BUSINESSUNIT_ID = value; }
    }

    private int mLOANTRAN_PAYMODE;

    public int LOANTRAN_PAYMODE
    {
        get
        {
            return (this.mLOANTRAN_PAYMODE);
        }
        set
        {
            this.mLOANTRAN_PAYMODE = value;
        }
    }

    private double mLOANTRAN_CHEQUENUM;

    public double LOANTRAN_CHEQUENUM
    {
        get
        {
            return (this.mLOANTRAN_CHEQUENUM);
        }
        set
        {
            this.mLOANTRAN_CHEQUENUM = value;
        }
    }

    private bool _LOANTRAN_TYPE;
    public bool LOANTRAN_TYPE
    {
        get { return (this._LOANTRAN_TYPE); }
        set { this._LOANTRAN_TYPE = value; }
    }

    private int _LOANTRAN_STATUS;
    public int LOANTRAN_STATUS
    {
        get { return (this._LOANTRAN_STATUS); }
        set { this._LOANTRAN_STATUS = value; }
    }
    private string _LOANNAME;

    public string LOANNAME
    {
        get { return _LOANNAME; }
        set { _LOANNAME = value; }
    }

    private bool _LOANTRANS_LOANISDELETED;
    public bool LOANTRANS_LOANISDELETED
    {
        get { return _LOANTRANS_LOANISDELETED; }
        set { _LOANTRANS_LOANISDELETED = value; }
    }

    public string ReferenceId { get; set; }
}

#endregion

#region SMHR_SALARYSTRUCT

public class SMHR_SALARYSTRUCT : SMHR_MAIN
{
    private int _SALARYSTRUCT_ID;
    public int SALARYSTRUCT_ID
    {
        get { return (this._SALARYSTRUCT_ID); }
        set { this._SALARYSTRUCT_ID = value; }
    }

    private string _SALARYSTRUCT_CODE;
    public string SALARYSTRUCT_CODE
    {
        get { return (this._SALARYSTRUCT_CODE); }
        set { this._SALARYSTRUCT_CODE = value; }
    }

    private string _SALARYSTRUCT_NAME;
    public string SALARYSTRUCT_NAME
    {
        get { return (this._SALARYSTRUCT_NAME); }
        set { this._SALARYSTRUCT_NAME = value; }
    }

    private int _SALARYSTRUCT_TYPE;
    public int SALARYSTRUCT_TYPE
    {
        get { return (this._SALARYSTRUCT_TYPE); }
        set { this._SALARYSTRUCT_TYPE = value; }
    }

    private DateTime _SALARYSTRUCT_STARTDATE;
    public DateTime SALARYSTRUCT_STARTDATE
    {
        get { return (this._SALARYSTRUCT_STARTDATE); }
        set { this._SALARYSTRUCT_STARTDATE = value; }
    }

    private DateTime? _SALARYSTRUCT_ENDDATE;
    public DateTime? SALARYSTRUCT_ENDDATE
    {
        get { return (this._SALARYSTRUCT_ENDDATE); }
        set { this._SALARYSTRUCT_ENDDATE = value; }
    }

    private bool _SALARYSTRUCTDET_CHECKED;
    public bool SALARYSTRUCTDET_CHECKED
    {
        get { return (this._SALARYSTRUCTDET_CHECKED); }
        set { this._SALARYSTRUCTDET_CHECKED = value; }
    }


    private int _SALARYSTRUCT_CREATEDBY;
    public int SALARYSTRUCT_CREATEDBY
    {
        get { return (this._SALARYSTRUCT_CREATEDBY); }
        set { this._SALARYSTRUCT_CREATEDBY = value; }
    }

    private DateTime _SALARYSTRUCT_CREATEDDATE;
    public DateTime SALARYSTRUCT_CREATEDDATE
    {
        get { return (this._SALARYSTRUCT_CREATEDDATE); }
        set { this._SALARYSTRUCT_CREATEDDATE = value; }
    }


    private int _SALARYSTRUCT_LASTMDFBY;
    public int SALARYSTRUCT_LASTMDFBY
    {
        get { return (this._SALARYSTRUCT_LASTMDFBY); }
        set { this._SALARYSTRUCT_LASTMDFBY = value; }
    }

    private DateTime _SALARYSTRUCT_LASTMDFDATE;
    public DateTime SALARYSTRUCT_LASTMDFDATE
    {
        get { return (this._SALARYSTRUCT_LASTMDFDATE); }
        set { this._SALARYSTRUCT_LASTMDFDATE = value; }
    }

    private int _SALARYSTRUCTDET_ID;
    public int SALARYSTRUCTDET_ID
    {
        get { return (this._SALARYSTRUCTDET_ID); }
        set { this._SALARYSTRUCTDET_ID = value; }
    }

    private int _SALARYSTRUCTDET_SALSTR_ID;
    public int SALARYSTRUCTDET_SALSTR_ID
    {
        get { return (this._SALARYSTRUCTDET_SALSTR_ID); }
        set { this._SALARYSTRUCTDET_SALSTR_ID = value; }
    }

    private int _SALARYSTRUCTDET_PAYITEM_ID;
    public int SALARYSTRUCTDET_PAYITEM_ID
    {
        get { return (this._SALARYSTRUCTDET_PAYITEM_ID); }
        set { this._SALARYSTRUCTDET_PAYITEM_ID = value; }
    }

    private string _SALARYSTRUCTDET_PAYMODE;
    public string SALARYSTRUCTDET_PAYMODE
    {
        get { return (this._SALARYSTRUCTDET_PAYMODE); }
        set { this._SALARYSTRUCTDET_PAYMODE = value; }
    }

    private string _SALARYSTRUCTDET_PAYVALUE;
    public string SALARYSTRUCTDET_PAYVALUE
    {
        get { return (this._SALARYSTRUCTDET_PAYVALUE); }
        set { this._SALARYSTRUCTDET_PAYVALUE = value; }
    }

    private string _SALARYSTRUCTDET_FORMULA;
    public string SALARYSTRUCTDET_FORMULA
    {
        get { return (this._SALARYSTRUCTDET_FORMULA); }
        set { this._SALARYSTRUCTDET_FORMULA = value; }
    }

    private string mSALARYSTRUCT_COSTHEAD;

    public string SALARYSTRUCT_COSTHEAD
    {
        get
        {
            return (this.mSALARYSTRUCT_COSTHEAD);
        }
        set
        {
            this.mSALARYSTRUCT_COSTHEAD = value;
        }
    }

    private int mSALARYSTRUCT_ORGANISATION_ID;

    public int SALARYSTRUCT_ORGANISATION_ID
    {
        get
        {
            return (this.mSALARYSTRUCT_ORGANISATION_ID);
        }
        set
        {
            this.mSALARYSTRUCT_ORGANISATION_ID = value;
        }
    }

}

#endregion

#region SMHR_LEAVESTRUCT

public class SMHR_LEAVESTRUCT : SMHR_MAIN
{
    private int _LEAVESTRUCT_ID;
    public int LEAVESTRUCT_ID
    {
        get { return (this._LEAVESTRUCT_ID); }
        set { this._LEAVESTRUCT_ID = value; }
    }

    private string _LEAVESTRUCT_CODE;
    public string LEAVESTRUCT_CODE
    {
        get { return (this._LEAVESTRUCT_CODE); }
        set { this._LEAVESTRUCT_CODE = value; }
    }

    private string _LEAVESTRUCT_NAME;
    public string LEAVESTRUCT_NAME
    {
        get { return (this._LEAVESTRUCT_NAME); }
        set { this._LEAVESTRUCT_NAME = value; }
    }

    private DateTime? _LEAVESTRUCT_STARTDATE;
    public DateTime? LEAVESTRUCT_STARTDATE
    {
        get { return (this._LEAVESTRUCT_STARTDATE); }
        set { this._LEAVESTRUCT_STARTDATE = value; }
    }

    private DateTime? _LEAVESTRUCT_ENDDATE;
    public DateTime? LEAVESTRUCT_ENDDATE
    {
        get { return (this._LEAVESTRUCT_ENDDATE); }
        set { this._LEAVESTRUCT_ENDDATE = value; }
    }

    private int _LEAVESTRUCT_CREATEDBY;
    public int LEAVESTRUCT_CREATEDBY
    {
        get { return (this._LEAVESTRUCT_CREATEDBY); }
        set { this._LEAVESTRUCT_CREATEDBY = value; }
    }

    private DateTime _LEAVESTRUCT_CREATEDDATE;
    public DateTime LEAVESTRUCT_CREATEDDATE
    {
        get { return (this._LEAVESTRUCT_CREATEDDATE); }
        set { this._LEAVESTRUCT_CREATEDDATE = value; }
    }

    private int _LEAVESTRUCT_LASTMDFBY;
    public int LEAVESTRUCT_LASTMDFBY
    {
        get { return (this._LEAVESTRUCT_LASTMDFBY); }
        set { this._LEAVESTRUCT_LASTMDFBY = value; }
    }

    private DateTime _LEAVESTRUCT_LASTMDFDATE;
    public DateTime LEAVESTRUCT_LASTMDFDATE
    {
        get { return (this._LEAVESTRUCT_LASTMDFDATE); }
        set { this._LEAVESTRUCT_LASTMDFDATE = value; }
    }

    private int _LEAVESTRUCTDET_ID;
    public int LEAVESTRUCTDET_ID
    {
        get { return (this._LEAVESTRUCTDET_ID); }
        set { this._LEAVESTRUCTDET_ID = value; }
    }

    private int _LEAVESTRUCTDET_LEAVETYPE_ID;
    public int LEAVESTRUCTDET_LEAVETYPE_ID
    {
        get { return (this._LEAVESTRUCTDET_LEAVETYPE_ID); }
        set { this._LEAVESTRUCTDET_LEAVETYPE_ID = value; }
    }

    private int _LEAVESTRUCTDET_LEAVESTR_ID;
    public int LEAVESTRUCTDET_LEAVESTR_ID
    {
        get { return (this._LEAVESTRUCTDET_LEAVESTR_ID); }
        set { this._LEAVESTRUCTDET_LEAVESTR_ID = value; }
    }

    private string _LEAVESTRUCTDET_LEAVEDAYS;
    public string LEAVESTRUCTDET_LEAVEDAYS
    {
        get { return (this._LEAVESTRUCTDET_LEAVEDAYS); }
        set { this._LEAVESTRUCTDET_LEAVEDAYS = value; }
    }

    private bool _LEAVESTRUCTDET_ISWEEKLYOFF;
    public bool LEAVESTRUCTDET_ISWEEKLYOFF
    {
        get { return (this._LEAVESTRUCTDET_ISWEEKLYOFF); }
        set { this._LEAVESTRUCTDET_ISWEEKLYOFF = value; }
    }

    private bool _LEAVESTRUCTDET_ALLOWHALFDAYS;
    public bool LEAVESTRUCTDET_ALLOWHALFDAYS
    {
        get { return (this._LEAVESTRUCTDET_ALLOWHALFDAYS); }
        set { this._LEAVESTRUCTDET_ALLOWHALFDAYS = value; }
    }

    private bool _LEAVESTRUCTDET_ACCUMULATE;
    public bool LEAVESTRUCTDET_ACCUMULATE
    {
        get { return (this._LEAVESTRUCTDET_ACCUMULATE); }
        set { this._LEAVESTRUCTDET_ACCUMULATE = value; }
    }

    private int _LEAVESTRUCTDET_PERIOD_ID;
    public int LEAVESTRUCTDET_PERIOD_ID
    {
        get { return (this._LEAVESTRUCTDET_PERIOD_ID); }
        set { this._LEAVESTRUCTDET_PERIOD_ID = value; }
    }

    private double _LEAVESTRUCTDET_DAYSPERYEAR;
    public double LEAVESTRUCTDET_DAYSPERYEAR
    {
        get { return (this._LEAVESTRUCTDET_DAYSPERYEAR); }
        set { this._LEAVESTRUCTDET_DAYSPERYEAR = value; }
    }

    private double _LEAVESTRUCTDET_MAXDAYS;
    public double LEAVESTRUCTDET_MAXDAYS
    {
        get { return (this._LEAVESTRUCTDET_MAXDAYS); }
        set { this._LEAVESTRUCTDET_MAXDAYS = value; }
    }

    private bool _LEAVESTRUCTDET_CFORWARD;
    public bool LEAVESTRUCTDET_CFORWARD
    {
        get { return (this._LEAVESTRUCTDET_CFORWARD); }
        set { this._LEAVESTRUCTDET_CFORWARD = value; }
    }

    private double _LEAVESTRUCTDET_CFMAXDAYS;
    public double LEAVESTRUCTDET_CFMAXDAYS
    {
        get { return (this._LEAVESTRUCTDET_CFMAXDAYS); }
        set { this._LEAVESTRUCTDET_CFMAXDAYS = value; }
    }

    private double _LEAVESTRUCTDET_MINWRKDAYS;
    public double LEAVESTRUCTDET_MINWRKDAYS
    {
        get { return (this._LEAVESTRUCTDET_MINWRKDAYS); }
        set { this._LEAVESTRUCTDET_MINWRKDAYS = value; }
    }

    private double _LEAVESTRUCTDET_ELIGIBLEDAYS;
    public double LEAVESTRUCTDET_ELIGIBLEDAYS
    {
        get { return (this._LEAVESTRUCTDET_ELIGIBLEDAYS); }
        set { this._LEAVESTRUCTDET_ELIGIBLEDAYS = value; }
    }

    private bool _LEAVESTRUCTDET_ENCASHMENT;
    public bool LEAVESTRUCTDET_ENCASHMENT
    {
        get { return (this._LEAVESTRUCTDET_ENCASHMENT); }
        set { this._LEAVESTRUCTDET_ENCASHMENT = value; }
    }

    private double _LEAVESTRUCTDET_MAXENCASHDAYS;
    public double LEAVESTRUCTDET_MAXENCASHDAYS
    {
        get { return (this._LEAVESTRUCTDET_MAXENCASHDAYS); }
        set { this._LEAVESTRUCTDET_MAXENCASHDAYS = value; }
    }

    private int _LEAVESTRUCTDET_INCOMEHEADS;
    public int LEAVESTRUCTDET_INCOMEHEADS
    {
        get { return (this._LEAVESTRUCTDET_INCOMEHEADS); }
        set { this._LEAVESTRUCTDET_INCOMEHEADS = value; }
    }

    private int _LEAVESTRUCTDET_CREATEDBY;
    public int LEAVESTRUCTDET_CREATEDBY
    {
        get { return (this._LEAVESTRUCTDET_CREATEDBY); }
        set { this._LEAVESTRUCTDET_CREATEDBY = value; }
    }

    private DateTime _LEAVESTRUCTDET_CREATEDDATE;
    public DateTime LEAVESTRUCTDET_CREATEDDATE
    {
        get { return (this._LEAVESTRUCTDET_CREATEDDATE); }
        set { this._LEAVESTRUCTDET_CREATEDDATE = value; }
    }

    private int _LEAVESTRUCTDET_LASTMDFBY;
    public int LEAVESTRUCTDET_LASTMDFBY
    {
        get { return (this._LEAVESTRUCTDET_LASTMDFBY); }
        set { this._LEAVESTRUCTDET_LASTMDFBY = value; }
    }

    private DateTime _LEAVESTRUCTDET_LASTMDFDATE;
    public DateTime LEAVESTRUCTDET_LASTMDFDATE
    {
        get { return (this._LEAVESTRUCTDET_LASTMDFDATE); }
        set { this._LEAVESTRUCTDET_LASTMDFDATE = value; }
    }

    private int mLEAVESTRUCT_ORGANISATION_ID;

    public int LEAVESTRUCT_ORGANISATION_ID
    {
        get
        {
            return (this.mLEAVESTRUCT_ORGANISATION_ID);
        }
        set
        {
            this.mLEAVESTRUCT_ORGANISATION_ID = value;
        }
    }

    private bool _IsAutoIncrement;
    public bool IsAutoIncrement
    {
        get { return (this._IsAutoIncrement); }
        set { this._IsAutoIncrement = value; }
    }

    private decimal _AutoIncrementDays;
    public decimal AutoIncrementDays
    {
        get { return (this._AutoIncrementDays); }
        set { this._AutoIncrementDays = value; }
    }
}

#endregion

#region SMHR_PERIOD

public class SMHR_PERIOD : SMHR_MAIN
{
    private int _PERIOD_ID;
    public int PERIOD_ID
    {
        get { return (this._PERIOD_ID); }
        set { this._PERIOD_ID = value; }
    }

    private string _PERIOD_CODE;
    public string PERIOD_CODE
    {
        get { return (this._PERIOD_CODE); }
        set { this._PERIOD_CODE = value; }
    }

    private string _PERIOD_NAME;
    public string PERIOD_NAME
    {
        get { return (this._PERIOD_NAME); }
        set { this._PERIOD_NAME = value; }
    }

    private int _FROM_PERIODID;
    public int FROM_PERIODID
    {
        get { return (this._FROM_PERIODID); }
        set { this._FROM_PERIODID = value; }
    }

    private int _PERIOD_TYPE;
    public int PERIOD_TYPE
    {
        get { return (this._PERIOD_TYPE); }
        set { this._PERIOD_TYPE = value; }
    }

    private DateTime _PERIOD_STARTDATE;
    public DateTime PERIOD_STARTDATE
    {
        get { return (this._PERIOD_STARTDATE); }
        set { this._PERIOD_STARTDATE = value; }
    }

    private DateTime _PERIOD_ENDDATE;
    public DateTime PERIOD_ENDDATE
    {
        get { return (this._PERIOD_ENDDATE); }
        set { this._PERIOD_ENDDATE = value; }
    }

    private int _PERIOD_DURATION;

    public int PERIOD_DURATION
    {
        get { return (this._PERIOD_DURATION); }
        set { this._PERIOD_DURATION = value; }
    }

    private int _PERIOD_DURATIONTYPE;

    public int PERIOD_DURATIONTYPE
    {
        get { return (this._PERIOD_DURATIONTYPE); }
        set { this._PERIOD_DURATIONTYPE = value; }
    }

    private int _PERIOD_CREATEDBY;
    public int PERIOD_CREATEDBY
    {
        get { return (this._PERIOD_CREATEDBY); }
        set { this._PERIOD_CREATEDBY = value; }
    }

    private DateTime _PERIOD_CREATEDDATE;
    public DateTime PERIOD_CREATEDDATE
    {
        get { return (this._PERIOD_CREATEDDATE); }
        set { this._PERIOD_CREATEDDATE = value; }
    }

    private int _PERIOD_LASTMDFBY;
    public int PERIOD_LASTMDFBY
    {
        get { return (this._PERIOD_LASTMDFBY); }
        set { this._PERIOD_LASTMDFBY = value; }
    }

    private DateTime _PERIOD_LASTMDFDATE;
    public DateTime PERIOD_LASTMDFDATE
    {
        get { return (this._PERIOD_LASTMDFDATE); }
        set { this._PERIOD_LASTMDFDATE = value; }
    }
}

#endregion

#region SMHR_PERIODDTL

public class SMHR_PERIODDTL : SMHR_MAIN
{
    private int _PRDDTL_ID;

    public int PRDDTL_ID
    {
        get { return (this._PRDDTL_ID); }
        set { this._PRDDTL_ID = value; }
    }
    private int _PRDDTL_PERIOD_ID;

    public int PRDDTL_PERIOD_ID
    {
        get { return (this._PRDDTL_PERIOD_ID); }
        set { this._PRDDTL_PERIOD_ID = value; }
    }

    private String _PRDDTL_NAME;

    public String PRDDTL_NAME
    {
        get { return (this._PRDDTL_NAME); }
        set { this._PRDDTL_NAME = value; }
    }

    private DateTime _PRDDTL_STARTDATE;

    public DateTime PRDDTL_STARTDATE
    {
        get { return (this._PRDDTL_STARTDATE); }
        set { this._PRDDTL_STARTDATE = value; }
    }

    private DateTime _PRDDTL_ENDDATE;

    public DateTime PRDDTL_ENDDATE
    {
        get { return (this._PRDDTL_ENDDATE); }
        set { this._PRDDTL_ENDDATE = value; }
    }

    private int _PRDDTL_STATUS;

    public int PRDDTL_STATUS
    {
        get { return (this._PRDDTL_STATUS); }
        set { this._PRDDTL_STATUS = value; }
    }

    private int _PRDDTL_CREATEDBY;

    public int PRDDTL_CREATEDBY
    {
        get { return (this._PRDDTL_CREATEDBY); }
        set { this._PRDDTL_CREATEDBY = value; }
    }

    private DateTime _PRDDTL_CREATEDDATE;

    public DateTime PRDDTL_CREATEDDATE
    {
        get { return (this._PRDDTL_CREATEDDATE); }
        set { this._PRDDTL_CREATEDDATE = value; }
    }

    private int _PRDDTL_LASTMDFBY;

    public int PRDDTL_LASTMDFBY
    {
        get { return (this._PRDDTL_LASTMDFBY); }
        set { this._PRDDTL_LASTMDFBY = value; }
    }

    private DateTime _PRDDTL_LASTMDFDATE;

    public DateTime PRDDTL_LASTMDFDATE
    {
        get { return (this._PRDDTL_LASTMDFDATE); }
        set { this._PRDDTL_LASTMDFDATE = value; }
    }
}

#endregion

#region SMHR_LOANTYPE

public class SMHR_LOANTYPE : SMHR_MAIN
{
    public SMHR_LOANTYPE(int __LOAN_ID)
    {
        this._LOAN_ID = __LOAN_ID;
    }

    public SMHR_LOANTYPE()
    {
    }

    private int _LOAN_ID;
    public int LOAN_ID
    {
        get { return (this._LOAN_ID); }
        set { this._LOAN_ID = value; }
    }

    private string _LOAN_CODE;
    public string LOAN_CODE
    {
        get { return (this._LOAN_CODE); }
        set { this._LOAN_CODE = value; }
    }

    private string _LOAN_NAME;
    public string LOAN_NAME
    {
        get { return (this._LOAN_NAME); }
        set { this._LOAN_NAME = value; }
    }
    private string _LOAN_LOANTYPE_ID;
    public string LOAN_LOANTYPE_ID
    {
        get { return (this._LOAN_LOANTYPE_ID); }
        set { this._LOAN_LOANTYPE_ID = value; }
    }
}

#endregion

#region SMHR_PERIODTYPE

public class SMHR_PERIODTYPE : SMHR_MAIN
{
    private int _PERIODTYPE_ID;

    public int PERIODTYPE_ID
    {
        get { return (this._PERIODTYPE_ID); }
        set { this._PERIODTYPE_ID = value; }
    }

    private String _PERIODTYPE_NAME;

    public String PERIODTYPE_NAME
    {
        get { return (this._PERIODTYPE_NAME); }
        set { this._PERIODTYPE_NAME = value; }
    }

    private int _PERIODTYPE_NOOFDAYS;

    public int PERIODTYPE_NOOFDAYS
    {
        get { return (this._PERIODTYPE_NOOFDAYS); }
        set { this._PERIODTYPE_NOOFDAYS = value; }
    }

    private int _PERIODTYPE_CREATEDBY;

    public int PERIODTYPE_CREATEDBY
    {
        get { return (this._PERIODTYPE_CREATEDBY); }
        set { this._PERIODTYPE_CREATEDBY = value; }
    }

    private DateTime _PERIODTYPE_CREATEDDATE;

    public DateTime PERIODTYPE_CREATEDDATE
    {
        get { return (this._PERIODTYPE_CREATEDDATE); }
        set { this._PERIODTYPE_CREATEDDATE = value; }
    }

    private int _PERIODTYPE_LASTMDFBY;

    public int PERIODTYPE_LASTMDFBY
    {
        get { return (this._PERIODTYPE_LASTMDFBY); }
        set { this._PERIODTYPE_LASTMDFBY = value; }
    }

    private DateTime _PERIODTYPE_LASTMDFDATE;

    public DateTime PERIODTYPE_LASTMDFDATE
    {
        get { return (this._PERIODTYPE_LASTMDFDATE); }
        set { this._PERIODTYPE_LASTMDFDATE = value; }
    }
}

#endregion

#region SMHR_APPLICANT

public class SMHR_APPLICANT : SMHR_MAIN
{
    private int? _APPLICANT_ID;
    public int? APPLICANT_ID
    {
        get { return (this._APPLICANT_ID); }
        set { this._APPLICANT_ID = value; }
    }

    private string _APPLICANT_RESUME;
    public string APPLICANT_RESUME
    {
        get { return (this._APPLICANT_RESUME); }
        set { this._APPLICANT_RESUME = value; }
    }

    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }
    public string APPLICANT_MOBILE { get; set; }

    private string _APPLICANT_CODE;
    public string APPLICANT_CODE
    {
        get { return (this._APPLICANT_CODE); }
        set { this._APPLICANT_CODE = value; }
    }

    private string _APPLICANT_TITLE;
    public string APPLICANT_TITLE
    {
        get { return (this._APPLICANT_TITLE); }
        set { this._APPLICANT_TITLE = value; }
    }

    private string _APPLICANT_FIRSTNAME;
    public string APPLICANT_FIRSTNAME
    {
        get { return (this._APPLICANT_FIRSTNAME); }
        set { this._APPLICANT_FIRSTNAME = value; }
    }

    private string _APPLICANT_LASTNAME;
    public string APPLICANT_LASTNAME
    {
        get { return (this._APPLICANT_LASTNAME); }
        set { this._APPLICANT_LASTNAME = value; }
    }

    private string _APPLICANT_MIDDLENAME;
    public string APPLICANT_MIDDLENAME
    {
        get { return (this._APPLICANT_MIDDLENAME); }
        set { this._APPLICANT_MIDDLENAME = value; }
    }

    private DateTime _APPLICANT_DOB;
    public DateTime APPLICANT_DOB
    {
        get { return (this._APPLICANT_DOB); }
        set { this._APPLICANT_DOB = value; }
    }

    private string _APPLICANT_GENDER;
    public string APPLICANT_GENDER
    {
        get { return (this._APPLICANT_GENDER); }
        set { this._APPLICANT_GENDER = value; }
    }

    private string _APPLICANT_BLOODGROUP;
    public string APPLICANT_BLOODGROUP
    {
        get { return (this._APPLICANT_BLOODGROUP); }
        set { this._APPLICANT_BLOODGROUP = value; }
    }

    private int _APPLICANT_RELIGION_ID;
    public int APPLICANT_RELIGION_ID
    {
        get { return (this._APPLICANT_RELIGION_ID); }
        set { this._APPLICANT_RELIGION_ID = value; }
    }

    private int _APPLICANT_NATIONALITY_ID;
    public int APPLICANT_NATIONALITY_ID
    {
        get { return (this._APPLICANT_NATIONALITY_ID); }
        set { this._APPLICANT_NATIONALITY_ID = value; }
    }

    private int _APPLICANT_TRIBE_ID;
    public int APPLICANT_TRIBE_ID
    {
        get { return (this._APPLICANT_TRIBE_ID); }
        set { this._APPLICANT_TRIBE_ID = value; }
    }

    private string _APPLICANT_MARITALSTATUS;
    public string APPLICANT_MARITALSTATUS
    {
        get { return (this._APPLICANT_MARITALSTATUS); }
        set { this._APPLICANT_MARITALSTATUS = value; }
    }

    private DateTime _APPLICANT_MARRDATE;
    public DateTime APPLICANT_MARRDATE
    {
        get { return (this._APPLICANT_MARRDATE); }
        set { this._APPLICANT_MARRDATE = value; }
    }

    private string _APPLICANT_STATUS;
    public string APPLICANT_STATUS
    {
        get { return (this._APPLICANT_STATUS); }
        set { this._APPLICANT_STATUS = value; }
    }

    private string _APPLICANT_REMARKS;
    public string APPLICANT_REMARKS
    {
        get { return (this._APPLICANT_REMARKS); }
        set { this._APPLICANT_REMARKS = value; }
    }

    private string _APPLICANT_ADDRESS;
    public string APPLICANT_ADDRESS
    {
        get { return (this._APPLICANT_ADDRESS); }
        set { this._APPLICANT_ADDRESS = value; }
    }

    private string _APPLICANT_EMAIL;
    public string APPLICANT_EMAIL
    {
        get { return (this._APPLICANT_EMAIL); }
        set { this._APPLICANT_EMAIL = value; }
    }
    private string _APPLICANT_TYPE;
    public string APPLICANT_TYPE
    {
        get { return (this._APPLICANT_TYPE); }
        set { this._APPLICANT_TYPE = value; }
    }

    private string _APPLICANT_CREATEDBY;
    public string APPLICANT_CREATEDBY
    {
        get { return (this._APPLICANT_CREATEDBY); }
        set { this._APPLICANT_CREATEDBY = value; }
    }

    private DateTime _APPLICANT_CREATEDDATE;
    public DateTime APPLICANT_CREATEDDATE
    {
        get { return (this._APPLICANT_CREATEDDATE); }
        set { this._APPLICANT_CREATEDDATE = value; }
    }

    private int _APPLICANT_LASTMDFBY;
    public int APPLICANT_LASTMDFBY
    {
        get { return (this._APPLICANT_LASTMDFBY); }
        set { this._APPLICANT_LASTMDFBY = value; }
    }

    private DateTime _APPLICANT_LASTMDFDATE;
    public DateTime APPLICANT_LASTMDFDATE
    {
        get { return (this._APPLICANT_LASTMDFDATE); }
        set { this._APPLICANT_LASTMDFDATE = value; }
    }

    private int _APPCONT_SERIAL;
    public int APPCONT_SERIAL
    {
        get { return (this._APPCONT_SERIAL); }
        set { this._APPCONT_SERIAL = value; }
    }

    private int _APPCONT_ID;
    public int APPCONT_ID
    {
        get { return (this._APPCONT_ID); }
        set { this._APPCONT_ID = value; }
    }

    private int _APPCONT_APPLICANT_ID;
    public int APPCONT_APPLICANT_ID
    {
        get { return (this._APPCONT_APPLICANT_ID); }
        set { this._APPCONT_APPLICANT_ID = value; }
    }

    private string _APPCONT_COMPANY;
    public string APPCONT_COMPANY
    {
        get { return (this._APPCONT_COMPANY); }
        set { this._APPCONT_COMPANY = value; }
    }

    private string _APPCONT_CONTACT;
    public string APPCONT_CONTACT
    {
        get { return (this._APPCONT_CONTACT); }
        set { this._APPCONT_CONTACT = value; }
    }

    private string _APPCONT_PHONE;
    public string APPCONT_PHONE
    {
        get { return (this._APPCONT_PHONE); }
        set { this._APPCONT_PHONE = value; }
    }

    private string _APPCONT_ADDRESS;
    public string APPCONT_ADDRESS
    {
        get { return (this._APPCONT_ADDRESS); }
        set { this._APPCONT_ADDRESS = value; }
    }

    private int _APPCONT_CREATEDBY;
    public int APPCONT_CREATEDBY
    {
        get { return (this._APPCONT_CREATEDBY); }
        set { this._APPCONT_CREATEDBY = value; }
    }

    private DateTime _APPCONT_CREATEDDATE;
    public DateTime APPCONT_CREATEDDATE
    {
        get { return (this._APPCONT_CREATEDDATE); }
        set { this._APPCONT_CREATEDDATE = value; }
    }

    private int _APPCONT_LASTMDFBY;
    public int APPCONT_LASTMDFBY
    {
        get { return (this._APPCONT_LASTMDFBY); }
        set { this._APPCONT_LASTMDFBY = value; }
    }

    private DateTime _APPCONT_LASTMDFDATE;
    public DateTime APPCONT_LASTMDFDATE
    {
        get { return (this._APPCONT_LASTMDFDATE); }
        set { this._APPCONT_LASTMDFDATE = value; }
    }

    private int _APPEXP_SERIAL;
    public int APPEXP_SERIAL
    {
        get { return (this._APPEXP_SERIAL); }
        set { this._APPEXP_SERIAL = value; }
    }

    private int _APPEXP_ID;
    public int APPEXP_ID
    {
        get { return (this._APPEXP_ID); }
        set { this._APPEXP_ID = value; }
    }

    private int _APPEXP_APPLICANT_ID;
    public int APPEXP_APPLICANT_ID
    {
        get { return (this._APPEXP_APPLICANT_ID); }
        set { this._APPEXP_APPLICANT_ID = value; }
    }

    private string _APPEXP_COMPANY;
    public string APPEXP_COMPANY
    {
        get { return (this._APPEXP_COMPANY); }
        set { this._APPEXP_COMPANY = value; }
    }

    private DateTime? _APPEXP_JOINDATE;
    public DateTime? APPEXP_JOINDATE
    {
        get { return (this._APPEXP_JOINDATE); }
        set { this._APPEXP_JOINDATE = value; }
    }
    public string APPEXJOINDATE { get; set; }
    public string APPEXRELDATE { get; set; }

    private double _APPEXP_JOINSAL;
    public double APPEXP_JOINSAL
    {
        get { return (this._APPEXP_JOINSAL); }
        set { this._APPEXP_JOINSAL = value; }
    }

    private string _APPEXP_JOINDESC;
    public string APPEXP_JOINDESC
    {
        get { return (this._APPEXP_JOINDESC); }
        set { this._APPEXP_JOINDESC = value; }
    }

    private string _APPEXP_REASONREL;
    public string APPEXP_REASONREL
    {
        get { return (this._APPEXP_REASONREL); }
        set { this._APPEXP_REASONREL = value; }
    }

    private DateTime? _APPEXP_RELDATE;
    public DateTime? APPEXP_RELDATE
    {
        get { return (this._APPEXP_RELDATE); }
        set { this._APPEXP_RELDATE = value; }
    }

    private double _APPEXP_RELSAL;
    public double APPEXP_RELSAL
    {
        get { return (this._APPEXP_RELSAL); }
        set { this._APPEXP_RELSAL = value; }
    }

    private string _APPEXP_REASONDESC;
    public string APPEXP_REASONDESC
    {
        get { return (this._APPEXP_REASONDESC); }
        set { this._APPEXP_REASONDESC = value; }
    }

    private int _APPEXP_CREATEDBY;
    public int APPEXP_CREATEDBY
    {
        get { return (this._APPEXP_CREATEDBY); }
        set { this._APPEXP_CREATEDBY = value; }
    }

    private DateTime _APPEXP_CREATEDDATE;
    public DateTime APPEXP_CREATEDDATE
    {
        get { return (this._APPEXP_CREATEDDATE); }
        set { this._APPEXP_CREATEDDATE = value; }
    }

    private int _APPEXP_LASTMDFBY;
    public int APPEXP_LASTMDFBY
    {
        get { return (this._APPEXP_LASTMDFBY); }
        set { this._APPEXP_LASTMDFBY = value; }
    }

    private string _APPEXP_LASTMDFDATE;
    public string APPEXP_LASTMDFDATE
    {
        get { return (this._APPEXP_LASTMDFDATE); }
        set { this._APPEXP_LASTMDFDATE = value; }
    }

    private int _APPLAN_ID;
    public int APPLAN_ID
    {
        get { return (this._APPLAN_ID); }
        set { this._APPLAN_ID = value; }
    }

    private int _APPLAN_APPLICANT_ID;
    public int APPLAN_APPLICANT_ID
    {
        get { return (this._APPLAN_APPLICANT_ID); }
        set { this._APPLAN_APPLICANT_ID = value; }
    }

    private int _APPLAN_LANGUAGE_ID;
    public int APPLAN_LANGUAGE_ID
    {
        get { return (this._APPLAN_LANGUAGE_ID); }
        set { this._APPLAN_LANGUAGE_ID = value; }
    }

    private bool _APPLAN_READ;
    public bool APPLAN_READ
    {
        get { return (this._APPLAN_READ); }
        set { this._APPLAN_READ = value; }
    }

    private bool _APPLAN_WRITE;
    public bool APPLAN_WRITE
    {
        get { return (this._APPLAN_WRITE); }
        set { this._APPLAN_WRITE = value; }
    }

    private bool _APPLAN_SPEAK;
    public bool APPLAN_SPEAK
    {
        get { return (this._APPLAN_SPEAK); }
        set { this._APPLAN_SPEAK = value; }
    }

    private bool _APPLAN_UNDERSTAND;
    public bool APPLAN_UNDERSTAND
    {
        get { return (this._APPLAN_UNDERSTAND); }
        set { this._APPLAN_UNDERSTAND = value; }
    }

    private int _APPLAN_CREATEDBY;
    public int APPLAN_CREATEDBY
    {
        get { return (this._APPLAN_CREATEDBY); }
        set { this._APPLAN_CREATEDBY = value; }
    }

    private DateTime _APPLAN_CREATEDDATE;
    public DateTime APPLAN_CREATEDDATE
    {
        get { return (this._APPLAN_CREATEDDATE); }
        set { this._APPLAN_CREATEDDATE = value; }
    }

    private int _APPLAN_LASTMDFBY;
    public int APPLAN_LASTMDFBY
    {
        get { return (this._APPLAN_LASTMDFBY); }
        set { this._APPLAN_LASTMDFBY = value; }
    }

    private DateTime _APPLAN_LASTMDFDATE;
    public DateTime APPLAN_LASTMDFDATE
    {
        get { return (this._APPLAN_LASTMDFDATE); }
        set { this._APPLAN_LASTMDFDATE = value; }
    }

    private int _APPQFN_ID;
    public int APPQFN_ID
    {
        get { return (this._APPQFN_ID); }
        set { this._APPQFN_ID = value; }
    }

    private int _APPQFN_APPLICANT_ID;
    public int APPQFN_APPLICANT_ID
    {
        get { return (this._APPQFN_APPLICANT_ID); }
        set { this._APPQFN_APPLICANT_ID = value; }
    }


    private int _APPQFN_QUALIFICATION_ID;
    public int APPQFN_QUALIFICATION_ID
    {
        get { return (this._APPQFN_QUALIFICATION_ID); }
        set { this._APPQFN_QUALIFICATION_ID = value; }
    }

    private string _APPQFN_INSTITUTE;
    public string APPQFN_INSTITUTE
    {
        get { return (this._APPQFN_INSTITUTE); }
        set { this._APPQFN_INSTITUTE = value; }
    }

    private int _APPQFN_PASSEDYEAR;
    public int APPQFN_PASSEDYEAR
    {
        get { return (this._APPQFN_PASSEDYEAR); }
        set { this._APPQFN_PASSEDYEAR = value; }
    }

    private double _APPQFN_PERCENTAGE;
    public double APPQFN_PERCENTAGE
    {
        get { return (this._APPQFN_PERCENTAGE); }
        set { this._APPQFN_PERCENTAGE = value; }
    }

    private string _APPQFN_GRADE;
    public string APPQFN_GRADE
    {
        get { return (this._APPQFN_GRADE); }
        set { this._APPQFN_GRADE = value; }
    }

    private int _APPQFN_CREATEDBY;
    public int APPQFN_CREATEDBY
    {
        get { return (this._APPQFN_CREATEDBY); }
        set { this._APPQFN_CREATEDBY = value; }
    }

    private DateTime _APPQFN_CREATEDDATE;
    public DateTime APPQFN_CREATEDDATE
    {
        get { return (this._APPQFN_CREATEDDATE); }
        set { this._APPQFN_CREATEDDATE = value; }
    }

    private int _APPQFN_LASTMDFBY;
    public int APPQFN_LASTMDFBY
    {
        get { return (this._APPQFN_LASTMDFBY); }
        set { this._APPQFN_LASTMDFBY = value; }
    }

    private DateTime _APPQFN_LASTMDFDATE;
    public DateTime APPQFN_LASTMDFDATE
    {
        get { return (this._APPQFN_LASTMDFDATE); }
        set { this._APPQFN_LASTMDFDATE = value; }
    }

    private int _APPREF_ID;
    public int APPREF_ID
    {
        get { return (this._APPREF_ID); }
        set { this._APPREF_ID = value; }
    }

    private int _APPREF_APPLICANT_ID;
    public int APPREF_APPLICANT_ID
    {
        get { return (this._APPREF_APPLICANT_ID); }
        set { this._APPREF_APPLICANT_ID = value; }
    }

    private int _APPREF_REFFERED_EMP_ID;
    public int APPREF_REFFERED_EMP_ID
    {
        get { return (this._APPREF_REFFERED_EMP_ID); }
        set { this._APPREF_REFFERED_EMP_ID = value; }
    }

    private int _APPREF_RELATIONSHIP;
    public int APPREF_RELATIONSHIP
    {
        get { return (this._APPREF_RELATIONSHIP); }
        set { this._APPREF_RELATIONSHIP = value; }
    }

    private bool _APPREF_REFERRED;
    public bool APPREF_REFERRED
    {
        get { return (this._APPREF_REFERRED); }
        set { this._APPREF_REFERRED = value; }
    }

    private int _APPREF_CREATEDBY;
    public int APPREF_CREATEDBY
    {
        get { return (this._APPREF_CREATEDBY); }
        set { this._APPREF_CREATEDBY = value; }
    }

    private DateTime _APPREF_CREATEDDATE;
    public DateTime APPREF_CREATEDDATE
    {
        get { return (this._APPREF_CREATEDDATE); }
        set { this._APPREF_CREATEDDATE = value; }
    }

    private int _APPREF_LASTMDFBY;
    public int APPREF_LASTMDFBY
    {
        get { return (this._APPREF_LASTMDFBY); }
        set { this._APPREF_LASTMDFBY = value; }
    }

    private DateTime _APPREF_LASTMDFDATE;
    public DateTime APPREF_LASTMDFDATE
    {
        get { return (this._APPREF_LASTMDFDATE); }
        set { this._APPREF_LASTMDFDATE = value; }
    }

    private int _APPSKL_ID;
    public int APPSKL_ID
    {
        get { return (this._APPSKL_ID); }
        set { this._APPSKL_ID = value; }
    }

    private int _APPSKL_APPLICANT_ID;
    public int APPSKL_APPLICANT_ID
    {
        get { return (this._APPSKL_APPLICANT_ID); }
        set { this._APPSKL_APPLICANT_ID = value; }
    }

    private int _APPSKL_SKILL_ID;
    public int APPSKL_SKILL_ID
    {
        get { return (this._APPSKL_SKILL_ID); }
        set { this._APPSKL_SKILL_ID = value; }
    }

    private int _APPSKL_LASTUSED;
    public int APPSKL_LASTUSED
    {
        get { return (this._APPSKL_LASTUSED); }
        set { this._APPSKL_LASTUSED = value; }
    }

    private int _APPSKL_EXPERT;
    public int APPSKL_EXPERT
    {
        get { return (this._APPSKL_EXPERT); }
        set { this._APPSKL_EXPERT = value; }
    }


    private int _APPSKL_CREATEDBY;
    public int APPSKL_CREATEDBY
    {
        get { return (this._APPSKL_CREATEDBY); }
        set { this._APPSKL_CREATEDBY = value; }
    }

    private DateTime _APPSKL_CREATEDDATE;
    public DateTime APPSKL_CREATEDDATE
    {
        get { return (this._APPSKL_CREATEDDATE); }
        set { this._APPSKL_CREATEDDATE = value; }
    }
    private int _APPSKL_LASTMDFBY;
    public int APPSKL_LASTMDFBY
    {
        get { return (this._APPSKL_LASTMDFBY); }
        set { this._APPSKL_LASTMDFBY = value; }
    }

    private DateTime _APPSKL_LASTMDFDATE;
    public DateTime APPSKL_LASTMDFDATE
    {
        get { return (this._APPSKL_LASTMDFDATE); }
        set { this._APPSKL_LASTMDFDATE = value; }
    }

    private string mAPP_EMP_STATUS;

    public string APP_EMP_STATUS
    {
        get
        {
            return (this.mAPP_EMP_STATUS);
        }
        set
        {
            this.mAPP_EMP_STATUS = value;
        }
    }
    //private string 
    public string APPLI_DOB { get; set; }
}


#endregion

#region SMHR_HOLIDAY

public class SMHR_HOLIDAY : SMHR_MAIN
{
    private int _HOLMST_ID;

    public int HOLMST_ID
    {
        get { return (this._HOLMST_ID); }
        set { this._HOLMST_ID = value; }
    }

    private int _HOLMST_BUSINESSUNITID;

    public int HOLMST_BUSINESSUNITID
    {
        get { return (this._HOLMST_BUSINESSUNITID); }
        set { this._HOLMST_BUSINESSUNITID = value; }
    }

    private string _HOLMST_CODE;

    public string HOLMST_CODE
    {
        get { return (this._HOLMST_CODE); }
        set { this._HOLMST_CODE = value; }
    }

    private string _HOLMST_DESCRIPTION;

    public string HOLMST_DESCRIPTION
    {
        get { return (this._HOLMST_DESCRIPTION); }
        set { this._HOLMST_DESCRIPTION = value; }
    }

    private DateTime _HOLMST_DATE;

    public DateTime HOLMST_DATE
    {
        get { return (this._HOLMST_DATE); }
        set { this._HOLMST_DATE = value; }
    }

    private int _HOLMST_CREATEDBY;

    public int HOLMST_CREATEDBY
    {
        get { return (this._HOLMST_CREATEDBY); }
        set { this._HOLMST_CREATEDBY = value; }
    }

    private DateTime _HOLMST_CREATEDDATE;

    public DateTime HOLMST_CREATEDDATE
    {
        get { return (this._HOLMST_CREATEDDATE); }
        set { this._HOLMST_CREATEDDATE = value; }
    }

    private int _HOLMST_LASTMDFBY;

    public int HOLMST_LASTMDFBY
    {
        get { return (this._HOLMST_LASTMDFBY); }
        set { this._HOLMST_LASTMDFBY = value; }
    }

    private DateTime _HOLMST_LASTMDFDATE;

    public DateTime HOLMST_LASTMDFDATE
    {
        get { return (this._HOLMST_LASTMDFDATE); }
        set { this._HOLMST_LASTMDFDATE = value; }
    }

}

#endregion

#region SMHR_SHIFTDEFINITION

public class SMHR_SHIFTDEFINITION : SMHR_MAIN
{
    private int _SHIFT_ID;

    public int SHIFT_ID
    {
        get { return (this._SHIFT_ID); }
        set { this._SHIFT_ID = value; }
    }

    private string _SHIFT_CODE;

    public string SHIFT_CODE
    {
        get { return (this._SHIFT_CODE); }
        set { this._SHIFT_CODE = value; }
    }

    private string _SHIFT_DESC;

    public string SHIFT_DESC
    {
        get { return (this._SHIFT_DESC); }
        set { this._SHIFT_DESC = value; }
    }

    private String _SHIFT_STARTTIME;

    public String SHIFT_STARTTIME
    {
        get { return (this._SHIFT_STARTTIME); }
        set { this._SHIFT_STARTTIME = value; }
    }

    private String _SHIFT_ENDTIME;

    public String SHIFT_ENDTIME
    {
        get { return (this._SHIFT_ENDTIME); }
        set { this._SHIFT_ENDTIME = value; }
    }


    private int _SHIFT_CREATEDBY;

    public int SHIFT_CREATEDBY
    {
        get { return (this._SHIFT_CREATEDBY); }
        set { this._SHIFT_CREATEDBY = value; }
    }

    private DateTime _SHIFT_CREATEDDATE;

    public DateTime SHIFT_CREATEDDATE
    {
        get { return (this._SHIFT_CREATEDDATE); }
        set { this._SHIFT_CREATEDDATE = value; }
    }

    private int _SHIFT_LASTMDFBY;

    public int SHIFT_LASTMDFBY
    {
        get { return (this._SHIFT_LASTMDFBY); }
        set { this._SHIFT_LASTMDFBY = value; }
    }

    private DateTime _SHIFT_LASTMDFDATE;

    public DateTime SHIFT_LASTMDFDATE
    {
        get { return (this._SHIFT_LASTMDFDATE); }
        set { this._SHIFT_LASTMDFDATE = value; }
    }

}

#endregion

#region SMHR_EMPLOYEE

public class SMHR_EMPLOYEE : SMHR_APPLICANT
{
    private int _EMP_PAYCURRENCY;
    public int EMP_PAYCURRENCY
    {
        get { return (this._EMP_PAYCURRENCY); }
        set { this._EMP_PAYCURRENCY = value; }
    }

    private int _EMP_ID;
    public int EMP_ID
    {
        get { return (this._EMP_ID); }
        set { this._EMP_ID = value; }
    }

    private string _EMP_EMPLOYEETYPE;
    public string EMP_EMPLOYEETYPE
    {
        get { return (this._EMP_EMPLOYEETYPE); }
        set { this._EMP_EMPLOYEETYPE = value; }
    }


    private string _EMP_EMPCODE;
    public string EMP_EMPCODE
    {
        get { return (this._EMP_EMPCODE); }
        set { this._EMP_EMPCODE = value; }
    }

    private int _EMP_SUPBUSINESSUNIT_ID;
    public int EMP_SUPBUSINESSUNIT_ID
    {
        get { return (this._EMP_SUPBUSINESSUNIT_ID); }
        set { this._EMP_SUPBUSINESSUNIT_ID = value; }
    }


    private int _EMP_APPLICANT_ID;
    public int EMP_APPLICANT_ID
    {
        get { return (this._EMP_APPLICANT_ID); }
        set { this._EMP_APPLICANT_ID = value; }
    }

    private DateTime? _EMP_DOJ;
    public DateTime? EMP_DOJ
    {
        get { return (this._EMP_DOJ); }
        set { this._EMP_DOJ = value; }
    }

    private DateTime? _EMP_DOC;
    public DateTime? EMP_DOC
    {
        get { return (this._EMP_DOC); }
        set { this._EMP_DOC = value; }
    }

    private int _EMP_DESIGNATION_ID;
    public int EMP_DESIGNATION_ID
    {
        get { return (this._EMP_DESIGNATION_ID); }
        set { this._EMP_DESIGNATION_ID = value; }
    }

    private int _EMPSALDTLS_ID;
    public int EMPSALDTLS_ID
    {
        get { return (this._EMPSALDTLS_ID); }
        set { this._EMPSALDTLS_ID = value; }
    }

    private DateTime _EMPSALDTLS_DATE;
    public DateTime EMPSALDTLS_DATE
    {
        get { return (this._EMPSALDTLS_DATE); }
        set { this._EMPSALDTLS_DATE = value; }
    }

    private DateTime? _EMPSALDTLS_FRMDT;
    public DateTime? EMPSALDTLS_FRMDT
    {
        get { return (this._EMPSALDTLS_FRMDT); }
        set { this._EMPSALDTLS_FRMDT = value; }
    }

    private DateTime? _EMPSALDTLS_ENDDT;
    public DateTime? EMPSALDTLS_ENDDT
    {
        get { return (this._EMPSALDTLS_ENDDT); }
        set { this._EMPSALDTLS_ENDDT = value; }
    }


    private int _EMP_BUSINESSUNIT_ID;
    public int EMP_BUSINESSUNIT_ID
    {
        get { return (this._EMP_BUSINESSUNIT_ID); }
        set { this._EMP_BUSINESSUNIT_ID = value; }
    }

    private int _EMP_DIRECTORATE_ID;
    public int EMP_DIRECTORATE_ID
    {
        get { return (this._EMP_DIRECTORATE_ID); }
        set { this._EMP_DIRECTORATE_ID = value; }
    }

    private int _EMP_ORGANISATION_ID;
    public int EMP_ORGANISATION_ID
    {
        get { return (this._EMP_ORGANISATION_ID); }
        set { this._EMP_ORGANISATION_ID = value; }
    }

    private DateTime? _EMP_DATEOFLASTPROMOTION;
    public DateTime? EMP_DATEOFLASTPROMOTION
    {
        get { return (this._EMP_DATEOFLASTPROMOTION); }
        set { this._EMP_DATEOFLASTPROMOTION = value; }
    }

    private int? _EMP_GRADE;
    public int? EMP_GRADE
    {
        get { return (this._EMP_GRADE); }
        set { this._EMP_GRADE = value; }
    }

    private int? _EMP_SLAB_ID;
    public int? EMP_SLAB_ID
    {
        get { return (this._EMP_SLAB_ID); }
        set { this._EMP_SLAB_ID = value; }
    }

    private int _EMP_REPORTINGEMPLOYEE;
    public int EMP_REPORTINGEMPLOYEE
    {
        get { return (this._EMP_REPORTINGEMPLOYEE); }
        set { this._EMP_REPORTINGEMPLOYEE = value; }
    }

    private DateTime? _EMP_RPTSTARTDATE;
    public DateTime? EMP_RPTSTARTDATE
    {
        get { return (this._EMP_RPTSTARTDATE); }
        set { this._EMP_RPTSTARTDATE = value; }
    }

    private DateTime? _EMP_RPTENDDATE;
    public DateTime? EMP_RPTENDDATE
    {
        get { return (this._EMP_RPTENDDATE); }
        set { this._EMP_RPTENDDATE = value; }
    }

    private int _EMP_SHIFT_ID;
    public int EMP_SHIFT_ID
    {
        get { return (this._EMP_SHIFT_ID); }
        set { this._EMP_SHIFT_ID = value; }
    }

    private Double _EMP_GROSSSAL;
    public Double EMP_GROSSSAL
    {
        get { return (this._EMP_GROSSSAL); }
        set { this._EMP_GROSSSAL = value; }
    }

    private int _EMP_PAYMENTMODE_ID;
    public int EMP_PAYMENTMODE_ID
    {
        get { return (this._EMP_PAYMENTMODE_ID); }
        set { this._EMP_PAYMENTMODE_ID = value; }
    }

    private int _EMP_SALALRYSTRUCT_ID;
    public int EMP_SALALRYSTRUCT_ID
    {
        get { return (this._EMP_SALALRYSTRUCT_ID); }
        set { this._EMP_SALALRYSTRUCT_ID = value; }
    }

    private int _EMP_LEAVESTRUCT_ID;
    public int EMP_LEAVESTRUCT_ID
    {
        get { return (this._EMP_LEAVESTRUCT_ID); }
        set { this._EMP_LEAVESTRUCT_ID = value; }
    }

    private string _EMP_IDENTIFICATION1;
    public string EMP_IDENTIFICATION1
    {
        get { return (this._EMP_IDENTIFICATION1); }
        set { this._EMP_IDENTIFICATION1 = value; }
    }

    private string _EMP_IDENTIFICATION2;
    public string EMP_IDENTIFICATION2
    {
        get { return (this._EMP_IDENTIFICATION2); }
        set { this._EMP_IDENTIFICATION2 = value; }
    }

    private string _EMP_IDENTIFICATION3;
    public string EMP_IDENTIFICATION3
    {
        get { return (this._EMP_IDENTIFICATION3); }
        set { this._EMP_IDENTIFICATION3 = value; }
    }

    private int _EMP_STATUS;
    public int EMP_STATUS
    {
        get { return (this._EMP_STATUS); }
        set { this._EMP_STATUS = value; }
    }

    private DateTime? _EMP_PROBATIONDATE;
    public DateTime? EMP_PROBATIONDATE
    {
        get { return (this._EMP_PROBATIONDATE); }
        set { this._EMP_PROBATIONDATE = value; }
    }
    public string EMP_PROBDATE { get; set; }
    public string EMP_DATEOFJOIN { get; set; }
    public string EMP_DATEOFCONFORM { get; set; }
    public string EMP_DATEOLP { get; set; }
    public string EMP_CONTRDATE { get; set; }
    public string EMP_rpt { get; set; }

    private DateTime? _EMP_RESGDATE;
    public DateTime? EMP_RESGDATE
    {
        get { return (this._EMP_RESGDATE); }
        set { this._EMP_RESGDATE = value; }
    }

    private DateTime? _EMP_RELDATE;
    public DateTime? EMP_RELDATE
    {
        get { return (this._EMP_RELDATE); }
        set { this._EMP_RELDATE = value; }
    }

    private int _EMP_NOTICEPERIOD;
    public int EMP_NOTICEPERIOD
    {
        get { return (this._EMP_NOTICEPERIOD); }
        set { this._EMP_NOTICEPERIOD = value; }
    }

    private int _EMP_CREATEDBY;
    public int EMP_CREATEDBY
    {
        get { return (this._EMP_CREATEDBY); }
        set { this._EMP_CREATEDBY = value; }
    }

    private DateTime _EMP_CREATEDDATE;
    public DateTime EMP_CREATEDDATE
    {
        get { return (this._EMP_CREATEDDATE); }
        set { this._EMP_CREATEDDATE = value; }
    }

    private int _EMP_LASTMDFBY;
    public int EMP_LASTMDFBY
    {
        get { return (this._EMP_LASTMDFBY); }
        set { this._EMP_LASTMDFBY = value; }
    }

    private DateTime _EMP_LASTMDFDATE;
    public DateTime EMP_LASTMDFDATE
    {
        get { return (this._EMP_LASTMDFDATE); }
        set { this._EMP_LASTMDFDATE = value; }
    }

    private double _EMP_BASIC;
    public double EMP_BASIC
    {
        get { return (this._EMP_BASIC); }
        set { this._EMP_BASIC = value; }
    }

    private string _EMP_PICUTRE;
    public string EMP_PICUTRE
    {
        get { return (this._EMP_PICUTRE); }
        set { this._EMP_PICUTRE = value; }
    }

    private int _Days;
    public int days
    {
        get { return (this._Days); }
        set { this._Days = value; }
    }

    private int _EMPASSETDOC_ID;
    public int EMPASSETDOC_ID
    {
        get { return (this._EMPASSETDOC_ID); }
        set { this._EMPASSETDOC_ID = value; }
    }

    private int _EMPASSETDOC_EMP_ID;
    public int EMPASSETDOC_EMP_ID
    {
        get { return (this._EMPASSETDOC_EMP_ID); }
        set { this._EMPASSETDOC_EMP_ID = value; }
    }

    private string _EMPASSETDOC_TYPE;
    public string EMPASSETDOC_TYPE
    {
        get { return (this._EMPASSETDOC_TYPE); }
        set { this._EMPASSETDOC_TYPE = value; }
    }

    private int _EMPASSETDOC_SERIAL;
    public int EMPASSETDOC_SERIAL
    {
        get { return (this._EMPASSETDOC_SERIAL); }
        set { this._EMPASSETDOC_SERIAL = value; }
    }

    private string _EMPASSETDOC_CODE;
    public string EMPASSETDOC_CODE
    {
        get { return (this._EMPASSETDOC_CODE); }
        set { this._EMPASSETDOC_CODE = value; }
    }

    private string _EMPASSETDOC_NAME;
    public string EMPASSETDOC_NAME
    {
        get { return (this._EMPASSETDOC_NAME); }
        set { this._EMPASSETDOC_NAME = value; }
    }

    private string _EMP_ASSETDOC_AD_Type;
    public string EMP_ASSETDOC_AD_Type
    {
        get { return (this._EMP_ASSETDOC_AD_Type); }
        set { this._EMP_ASSETDOC_AD_Type = value; }
    }

    private DateTime _EMP_ASSETDOC_ISSUEDATE;
    public DateTime EMP_ASSETDOC_ISSUEDATE
    {
        get { return (this._EMP_ASSETDOC_ISSUEDATE); }
        set { this._EMP_ASSETDOC_ISSUEDATE = value; }
    }

    private bool _EMP_ASSETDOC_RETURNABLE;
    public bool EMP_ASSETDOC_RETURNABLE
    {
        get { return (this._EMP_ASSETDOC_RETURNABLE); }
        set { this._EMP_ASSETDOC_RETURNABLE = value; }
    }

    private string _EMP_ASSETDOC_REMARKS;
    public string EMP_ASSETDOC_REMARKS
    {
        get { return (this._EMP_ASSETDOC_REMARKS); }
        set { this._EMP_ASSETDOC_REMARKS = value; }
    }

    private int _EMPFMDTL_ID;
    public int EMPFMDTL_ID
    {
        get { return (this._EMPFMDTL_ID); }
        set { this._EMPFMDTL_ID = value; }
    }

    private int _EMPFMDTL_EMP_ID;
    public int EMPFMDTL_EMP_ID
    {
        get { return (this._EMPFMDTL_EMP_ID); }
        set { this._EMPFMDTL_EMP_ID = value; }
    }

    private int _EMPFMDTL_EMPREL_ID;
    public int EMPFMDTL_EMPREL_ID
    {
        get { return (this._EMPFMDTL_EMPREL_ID); }
        set { this._EMPFMDTL_EMPREL_ID = value; }
    }

    private string _EMPFMDTL_EMPREL_NAME;
    public string EMPFMDTL_EMPREL_NAME
    {
        get { return (this._EMPFMDTL_EMPREL_NAME); }
        set { this._EMPFMDTL_EMPREL_NAME = value; }
    }

    private string _EMPFMDTL_WIFEIDNUMBER;
    public string EMPFMDTL_WIFEIDNUMBER
    {
        get { return (this._EMPFMDTL_WIFEIDNUMBER); }
        set { this._EMPFMDTL_WIFEIDNUMBER = value; }
    }

    private string _EMPFMDTL_SURNAME;
    public string EMPFMDTL_SURNAME
    {
        get { return (this._EMPFMDTL_SURNAME); }
        set { this._EMPFMDTL_SURNAME = value; }
    }

    private string _EMPFMDTL_NAME;
    public string EMPFMDTL_NAME
    {
        get { return (this._EMPFMDTL_NAME); }
        set { this._EMPFMDTL_NAME = value; }
    }

    private string _EMPFMDTL_PHOTO;
    public string EMPFMDTL_PHOTO
    {
        get { return (this._EMPFMDTL_PHOTO); }
        set { this._EMPFMDTL_PHOTO = value; }
    }

    private string _EMPFMDTL_BIODATA;
    public string EMPFMDTL_BIODATA
    {
        get { return (this._EMPFMDTL_BIODATA); }
        set { this._EMPFMDTL_BIODATA = value; }
    }

    private string _EMPFMDTL_BIOMETRICDOC;

    public string EMPFMDTL_BIOMETRICDOC
    {
        get { return _EMPFMDTL_BIOMETRICDOC; }
        set { _EMPFMDTL_BIOMETRICDOC = value; }
    }

    private DateTime _EMPFMDTL_RELDOB;
    public DateTime EMPFMDTL_RELDOB
    {
        get { return (this._EMPFMDTL_RELDOB); }
        set { this._EMPFMDTL_RELDOB = value; }
    }
    public string EMFM_RELDOB { get; set; }
    private int _EMPFMDTL_SERIAL;
    public int EMPFMDTL_SERIAL
    {
        get { return (this._EMPFMDTL_SERIAL); }
        set { this._EMPFMDTL_SERIAL = value; }
    }

    private bool _EMPFMDTL_IS_DEP;
    public bool EMPFMDTL_IS_DEP
    {
        get { return (this._EMPFMDTL_IS_DEP); }
        set { this._EMPFMDTL_IS_DEP = value; }
    }

    private bool _EMPFMDTL_IS_EDU;
    public bool EMPFMDTL_IS_EDU
    {
        get { return (this._EMPFMDTL_IS_EDU); }
        set { this._EMPFMDTL_IS_EDU = value; }
    }

    private bool _EMPFMDTL_IS_MED;
    public bool EMPFMDTL_IS_MED
    {
        get { return (this._EMPFMDTL_IS_MED); }
        set { this._EMPFMDTL_IS_MED = value; }
    }

    private bool _EMPFMDTL_RELDEPENDENT;
    public bool EMPFMDTL_RELDEPENDENT
    {
        get { return (this._EMPFMDTL_RELDEPENDENT); }
        set { this._EMPFMDTL_RELDEPENDENT = value; }
    }

    private string _EMPFMDTL_MOBILENO;

    public string EMPFMDTL_MOBILENO
    {
        get { return _EMPFMDTL_MOBILENO; }
        set { _EMPFMDTL_MOBILENO = value; }
    }

    private string _EMPFMDTL_CONTACTADDRESS;

    public string EMPFMDTL_CONTACTADDRESS
    {
        get { return _EMPFMDTL_CONTACTADDRESS; }
        set { _EMPFMDTL_CONTACTADDRESS = value; }
    }

    private string _EMPFMDTL_IDNUMBER;

    public string EMPFMDTL_IDNUMBER
    {
        get { return _EMPFMDTL_IDNUMBER; }
        set { _EMPFMDTL_IDNUMBER = value; }
    }

    private bool _EMPFMDTL_ISNEXTTOKIN;

    public bool EMPFMDTL_ISNEXTTOKIN
    {
        get { return _EMPFMDTL_ISNEXTTOKIN; }
        set { _EMPFMDTL_ISNEXTTOKIN = value; }
    }

    private bool _EMPFMDTL_EMERGENCYCONTACT;

    public bool EMPFMDTL_EMERGENCYCONTACT
    {
        get { return _EMPFMDTL_EMERGENCYCONTACT; }
        set { _EMPFMDTL_EMERGENCYCONTACT = value; }
    }

    private int _EMPFMDTL_CREATEDBY;
    public int EMPFMDTL_CREATEDBY
    {
        get { return (this._EMPFMDTL_CREATEDBY); }
        set { this._EMPFMDTL_CREATEDBY = value; }
    }

    private DateTime _EMPFMDTL_CREATEDDATE;
    public DateTime EMPFMDTL_CREATEDDATE
    {
        get { return (this._EMPFMDTL_CREATEDDATE); }
        set { this._EMPFMDTL_CREATEDDATE = value; }
    }

    private int _EMPFMDTL_LASTMDFBY;
    public int EMPFMDTL_LASTMDFBY
    {
        get { return (this._EMPFMDTL_LASTMDFBY); }
        set { this._EMPFMDTL_LASTMDFBY = value; }
    }

    private DateTime _EMPFMDTL_LASTMDFDATE;
    public DateTime EMPFMDTL_LASTMDFDATE
    {
        get { return (this._EMPFMDTL_LASTMDFDATE); }
        set { this._EMPFMDTL_LASTMDFDATE = value; }
    }

    private int _EMPOTR_ID;
    public int EMPOTR_ID
    {
        get { return (this._EMPOTR_ID); }
        set { this._EMPOTR_ID = value; }
    }

    private int _EMPOTR_EMP_ID;
    public int EMPOTR_EMP_ID
    {
        get { return (this._EMPOTR_EMP_ID); }
        set { this._EMPOTR_EMP_ID = value; }
    }

    private string _EMPFMDTL_IMAGE;
    public string EMPFMDTL_IMAGE
    {
        get { return (this._EMPFMDTL_IMAGE); }
        set { this._EMPFMDTL_IMAGE = value; }
    }

    private int _EMPOTR_OTTYPE_ID;
    public int EMPOTR_OTTYPE_ID
    {
        get { return (this._EMPOTR_OTTYPE_ID); }
        set { this._EMPOTR_OTTYPE_ID = value; }
    }

    private double _EMPOTR_OTRATE;
    public double EMPOTR_OTRATE
    {
        get { return (this._EMPOTR_OTRATE); }
        set { this._EMPOTR_OTRATE = value; }
    }

    private int _EMPOTR_CREATEDBY;
    public int EMPOTR_CREATEDBY
    {
        get { return (this._EMPOTR_CREATEDBY); }
        set { this._EMPOTR_CREATEDBY = value; }
    }

    private DateTime _EMPOTR_CREATEDDATE;
    public DateTime EMPOTR_CREATEDDATE
    {
        get { return (this._EMPOTR_CREATEDDATE); }
        set { this._EMPOTR_CREATEDDATE = value; }
    }

    private int _EMPOTR_LASTMDFBY;
    public int EMPOTR_LASTMDFBY
    {
        get { return (this._EMPOTR_LASTMDFBY); }
        set { this._EMPOTR_LASTMDFBY = value; }
    }

    private DateTime _EMPOTR_LASTMDFDATE;
    public DateTime EMPOTR_LASTMDFDATE
    {
        get { return (this._EMPOTR_LASTMDFDATE); }
        set { this._EMPOTR_LASTMDFDATE = value; }
    }

    private int _EMPREG_ID;
    public int EMPREG_ID
    {
        get { return (this._EMPREG_ID); }
        set { this._EMPREG_ID = value; }
    }

    private int _EMPWOFF_EMP_ID;
    public int EMPWOFF_EMP_ID
    {
        get { return (this._EMPWOFF_EMP_ID); }
        set { this._EMPWOFF_EMP_ID = value; }
    }

    private int _EMPWOFF_ID;
    public int EMPWOFF_ID
    {
        get { return (this._EMPWOFF_ID); }
        set { this._EMPWOFF_ID = value; }
    }

    private DateTime _EMPREG_REGDATE;
    public DateTime EMPREG_REGDATE
    {
        get { return (this._EMPREG_REGDATE); }
        set { this._EMPREG_REGDATE = value; }
    }

    private string _EMPREG_REMARKS;
    public string EMPREG_REMARKS
    {
        get { return (this._EMPREG_REMARKS); }
        set { this._EMPREG_REMARKS = value; }
    }

    private string _EMPREG_REASON;
    public string EMPREG_REASON
    {
        get { return (this._EMPREG_REASON); }
        set { this._EMPREG_REASON = value; }
    }

    private DateTime _EMPREG_RELDATE;
    public DateTime EMPREG_RELDATE
    {
        get { return (this._EMPREG_RELDATE); }
        set { this._EMPREG_RELDATE = value; }
    }

    private int _EMPWOFF_CREATEDBY;
    public int EMPWOFF_CREATEDBY
    {
        get { return (this._EMPWOFF_CREATEDBY); }
        set { this._EMPWOFF_CREATEDBY = value; }
    }

    private DateTime _EMPWOFF_CREATEDDATE;
    public DateTime EMPWOFF_CREATEDDATE
    {
        get { return (this._EMPWOFF_CREATEDDATE); }
        set { this._EMPWOFF_CREATEDDATE = value; }
    }

    private int _EMPWOFF_LASTMDFBY;
    public int EMPWOFF_LASTMDFBY
    {
        get { return (this._EMPWOFF_LASTMDFBY); }
        set { this._EMPWOFF_LASTMDFBY = value; }
    }

    private DateTime _EMPWOFF_LASTMDFDATE;
    public DateTime EMPWOFF_LASTMDFDATE
    {
        get { return (this._EMPWOFF_LASTMDFDATE); }
        set { this._EMPWOFF_LASTMDFDATE = value; }
    }

    private int _EMPSWM_ID;
    public int EMPSWM_ID
    {
        get { return (this._EMPSWM_ID); }
        set { this._EMPSWM_ID = value; }
    }

    private int _EMPSWM_EMP_ID;
    public int EMPSWM_EMP_ID
    {
        get { return (this._EMPSWM_EMP_ID); }
        set { this._EMPSWM_EMP_ID = value; }
    }

    private int _EMPSWM_SERIAL;
    public int EMPSWM_SERIAL
    {
        get { return (this._EMPSWM_SERIAL); }
        set { this._EMPSWM_SERIAL = value; }
    }

    private string _EMPSWM_CARDCODE;
    public string EMPSWM_CARDCODE
    {
        get { return (this._EMPSWM_CARDCODE); }
        set { this._EMPSWM_CARDCODE = value; }
    }

    private DateTime _EMPSWM_CARDISSUE;
    public DateTime EMPSWM_CARDISSUE
    {
        get { return (this._EMPSWM_CARDISSUE); }
        set { this._EMPSWM_CARDISSUE = value; }
    }

    private DateTime _EMPSWM_CARDEXPIRY;
    public DateTime EMPSWM_CARDEXPIRY
    {
        get { return (this._EMPSWM_CARDEXPIRY); }
        set { this._EMPSWM_CARDEXPIRY = value; }
    }

    private string _EMPSWM_REMARKS;
    public string EMPSWM_REMARKS
    {
        get { return (this._EMPSWM_REMARKS); }
        set { this._EMPSWM_REMARKS = value; }
    }

    private int _EMPSWM_CREATEDBY;
    public int EMPSWM_CREATEDBY
    {
        get { return (this._EMPSWM_CREATEDBY); }
        set { this._EMPSWM_CREATEDBY = value; }
    }

    private DateTime _EMPSWM_CREATEDDATE;
    public DateTime EMPSWM_CREATEDDATE
    {
        get { return (this._EMPSWM_CREATEDDATE); }
        set { this._EMPSWM_CREATEDDATE = value; }
    }

    private int _EMPSWM_LASTMDFBY;
    public int EMPSWM_LASTMDFBY
    {
        get { return (this._EMPSWM_LASTMDFBY); }
        set { this._EMPSWM_LASTMDFBY = value; }
    }

    private DateTime _EMPSWM_LASTMDFDATE;
    public DateTime EMPSWM_LASTMDFDATE
    {
        get { return (this._EMPSWM_LASTMDFDATE); }
        set { this._EMPSWM_LASTMDFDATE = value; }
    }

    private int _EMPWOFF_DAY_ID;
    public int EMPWOFF_DAY_ID
    {
        get { return (this._EMPWOFF_DAY_ID); }
        set { this._EMPWOFF_DAY_ID = value; }
    }

    private string _EMP_STRINGBUILD;
    public string EMP_STRINGBUILD
    {
        get { return (this._EMP_STRINGBUILD); }
        set { this._EMP_STRINGBUILD = value; }
    }

    private int _EMPSALDTLS_PERIOD_ID;
    public int EMPSALDTLS_PERIOD_ID
    {
        get { return (this._EMPSALDTLS_PERIOD_ID); }
        set { this._EMPSALDTLS_PERIOD_ID = value; }
    }

    private int _EMPSALDTLS_PRDDTL_ID;
    public int EMPSALDTLS_PRDDTL_ID
    {
        get { return (this._EMPSALDTLS_PRDDTL_ID); }
        set { this._EMPSALDTLS_PRDDTL_ID = value; }
    }

    private string _EMPSALDTLS_STRUCT;
    public string EMPSALDTLS_STRUCT
    {
        get { return (this._EMPSALDTLS_STRUCT); }
        set { this._EMPSALDTLS_STRUCT = value; }
    }

    private string _EMPSALDTLS_STR;
    public string EMPSALDTLS_STR
    {
        get { return (this._EMPSALDTLS_STR); }
        set { this._EMPSALDTLS_STR = value; }
    }

    private string mEMP_STATUS_UPDATE;
    public string EMP_STATUS_UPDATE
    {
        get
        {
            return (this.mEMP_STATUS_UPDATE);
        }
        set
        {
            this.mEMP_STATUS_UPDATE = value;
        }
    }

    private DateTime? _EMP_CONTRACT_ENDDATE;
    public DateTime? EMP_CONTRACT_ENDDATE
    {
        get { return (this._EMP_CONTRACT_ENDDATE); }
        set { this._EMP_CONTRACT_ENDDATE = value; }
    }
    private DateTime? _EMP_CONTRACT_STARTDATE;
    public DateTime? EMP_CONTRACT_STARTDATE
    {
        get { return (this._EMP_CONTRACT_STARTDATE); }
        set{this._EMP_CONTRACT_STARTDATE=value;}
    }
    private DateTime? _EMP_INCREMENTDATE;
    public DateTime? EMP_INCREMENTDATE
    {
        get { return (this._EMP_INCREMENTDATE); }
        set { this._EMP_INCREMENTDATE = value; }
    }
    private int _EMP_EMPLOYEE_STATUS;
    public int EMP_EMPLOYEE_STATUS
    {
        get { return (this._EMP_EMPLOYEE_STATUS); }
        set { this._EMP_EMPLOYEE_STATUS = value; }
    }

    private int _EMP_DEPARTMENT_ID;
    public int EMP_DEPARTMENT_ID
    {
        get { return (this._EMP_DEPARTMENT_ID); }
        set { this._EMP_DEPARTMENT_ID = value; }
    }

    private string _EMP_IDENTITY;
    public string EMP_IDENTITY
    {
        get { return (this._EMP_IDENTITY); }
        set { this._EMP_IDENTITY = value; }
    }

    //Modified

    private string _EMP_MOBILENO;
    public string EMP_MOBILENO
    {
        get { return (this._EMP_MOBILENO); }
        set { this._EMP_MOBILENO = value; }
    }

    private string _EMP_LANDLINENO;
    public string EMP_LANDLINENO
    {
        get { return (this._EMP_LANDLINENO); }
        set { this._EMP_LANDLINENO = value; }
    }

    private string _EMP_EMAILID;
    public string EMP_EMAILID
    {
        get { return (this._EMP_EMAILID); }
        set { this._EMP_EMAILID = value; }
    }

    public int EMP_LOCID { get; set; }
    private Double _EMPFMDTL_ANNUALINCOME;
    public Double EMPFMDTL_ANNUALINCOME
    {
        get { return (this._EMPFMDTL_ANNUALINCOME); }
        set { this._EMPFMDTL_ANNUALINCOME = value; }
    }

    private string _EMPFMDTL_OCCUPATION;
    public string EMPFMDTL_OCCUPATION
    {
        get { return (this._EMPFMDTL_OCCUPATION); }
        set { this._EMPFMDTL_OCCUPATION = value; }
    }

    private bool _EMPFMDTL_NOMINEE;

    public bool EMPFMDTL_NOMINEE
    {
        get { return _EMPFMDTL_NOMINEE; }
        set { _EMPFMDTL_NOMINEE = value; }
    }


    private string _EMP_HOBBIES;
    public string EMP_HOBBIES
    {
        get { return _EMP_HOBBIES; }
        set { _EMP_HOBBIES = value; }
    }



    private int _EMP_LOGIN_ID;
    public int EMP_LOGIN_ID
    {
        get { return _EMP_LOGIN_ID; }
        set { _EMP_LOGIN_ID = value; }
    }

    private bool _EMP_ISVARIABLEPAY;
    public bool EMP_ISVARIABLEPAY
    {
        get { return this._EMP_ISVARIABLEPAY; }
        set { this._EMP_ISVARIABLEPAY = value; }
    }

    private int _EMP_VARIABLEAMT;
    public int EMP_VARIABLEAMT
    {
        get { return this._EMP_VARIABLEAMT; }
        set { this._EMP_VARIABLEAMT = value; }
    }

    private int _EMP_VPPAYABLECOUNT;
    public int EMP_VPPAYABLECOUNT
    {
        get { return this._EMP_VPPAYABLECOUNT; }
        set { this._EMP_VPPAYABLECOUNT = value; }

    }
    //DIVISION NEW FUNCUTIONALITY FOR AX DIMENSION
    private int _EMP_DIV_ID;
    public int EMP_DIV_ID
    {
        get { return this._EMP_DIV_ID; }
        set { this._EMP_DIV_ID = value; }
    }

    //element for employee type for PNG localization
    private int _EMP_RESIDENCY_ID;
    public int EMP_RESIDENCY_ID
    {
        get { return this._EMP_RESIDENCY_ID; }
        set { this._EMP_RESIDENCY_ID = value; }
    }

    private double _emp_ANNUAL_GROSSSALARY;
    public double emp_ANNUAL_GROSSSALARY
    {
        get { return (this._emp_ANNUAL_GROSSSALARY); }
        set { this._emp_ANNUAL_GROSSSALARY = value; }
    }

    private double _emp_ANNUAL_BASICSALARY;
    public double emp_ANNUAL_BASICSALARY
    {
        get { return (this._emp_ANNUAL_BASICSALARY); }
        set { this._emp_ANNUAL_BASICSALARY = value; }
    }

    private int _emp_SOURCEBU;
    public int emp_SOURCEBU
    {
        get { return (this._emp_SOURCEBU); }
        set { this._emp_SOURCEBU = value; }
    }
    private int _USER_GROUP;
    public int USER_GROUP
    {
        get { return (this._USER_GROUP); }
        set { this._USER_GROUP = value; }
    }
    private string _PASSWORD;
    public string PASSWORD
    {
        get { return (this._PASSWORD); }
        set { this._PASSWORD = value; }
    }

    private string _PASSCODE;
    public string PASSCODE
    {
        get { return (this._PASSCODE); }
        set { this._PASSCODE = value; }
    }

    public int EMP_CATEGORY_ID { get; set; }

    public int EMP_TIMESHEETREQUIRED { get; set; }

    //public string EMP_SKYPEID { get; set; }

    //public string EMP_EXTENSION { get; set; }

    //public string EMP_PASSPORTNO { get; set; }

    //public DateTime EMP_PASSPORTEXPIRY { get; set; }
    private string _EMP_SKYPEID;
    public string EMP_SKYPEID
    {
        get { return (this._EMP_SKYPEID); }
        set { this._EMP_SKYPEID = value; }
    }

    private string _EMP_EXTENSION;
    public string EMP_EXTENSION
    {
        get { return (this._EMP_EXTENSION); }
        set { this._EMP_EXTENSION = value; }
    }

    private string _EMP_PASSPORTNO;
    public string EMP_PASSPORTNO
    {
        get { return (this._EMP_PASSPORTNO); }
        set { this._EMP_PASSPORTNO = value; }
    }

    private DateTime _EMP_PASSPORTEXPIRY;
    public DateTime EMP_PASSPORTEXPIRY
    {
        get { return (this._EMP_PASSPORTEXPIRY); }
        set { this._EMP_PASSPORTEXPIRY = value; }
    }

    public int EMP_AUSRESIDENCY_ID { get; set; }

    private int? _EMP_SUBDIVISION;
    public int? EMP_SUBDIVISION
    {
        get { return (this._EMP_SUBDIVISION); }
        set { this._EMP_SUBDIVISION = value; }
    }
    private string _EMP_MEMBERID;
    public string EMP_MEMBERID
    {
        get { return (this._EMP_MEMBERID); }
        set { this._EMP_MEMBERID = value; }
    }
    private string _EMP_WORKSTATUS;
    public string EMP_WORKSTATUS
    {
        get { return (this._EMP_WORKSTATUS); }
        set { this._EMP_WORKSTATUS = value; }
    }
    private string _EMP_FUNDNAME;
    public string EMP_FUNDNAME
    {
        get { return (this._EMP_FUNDNAME); }
        set { this._EMP_FUNDNAME = value; }
    }
    private string _EMP_CURRENTPROJECT;
    public string EMP_CURRENTPROJECT
    {
        get { return (this._EMP_CURRENTPROJECT); }
        set { this._EMP_CURRENTPROJECT = value; }
    }

    private int _EMP_JOBS_ID;
    public int EMP_JOBS_ID
    {
        get { return (this._EMP_JOBS_ID); }
        set { this._EMP_JOBS_ID = value; }
    }
    private bool _EMP_ISMANUAL;
    public bool EMP_ISMANUAL
    {
        get { return (this._EMP_ISMANUAL); }
        set { this._EMP_ISMANUAL = value; }
    }

    private int _EMP_INCRMENTMONTH;
    public int EMP_INCRMENTMONTH
    {
        get { return _EMP_INCRMENTMONTH; }
        set { _EMP_INCRMENTMONTH = value; }
    }

    private int _EMP_COUNTY_ID;
    public int EMP_COUNTY_ID
    {
        get { return _EMP_COUNTY_ID; }
        set { _EMP_COUNTY_ID = value; }
    }
    private int _EMP_PERIOD_ID;
    public int EMP_PERIOD_ID
    {
        get { return _EMP_PERIOD_ID; }
        set { _EMP_PERIOD_ID = value; }
    }

    public int EMP_CNFM_BY { get; set; }
    public int EMP_APRVD_BY { get; set; }

    public string EMP_ACTIVITY { get; set; }
    public string EMP_PROGRAMME { get; set; }
    public string EMP_ORGUNIT { get; set; }
    public string EMP_INTERVENTION { get; set; }
    public string EMP_FOCUS_AREA { get; set; }
    public string EMP_RESULT_AREA { get; set; }
    public string EMP_OUTCOME { get; set; }
}

#endregion

#region SMHR_EMP_PHYSICALDETAILS
public class SMHR_EMP_PHYSICALDETAILS : SMHR_MAIN
{
    private int _EMPPHYSICALDTL_ID;
    public int EMPPHYSICALDTL_ID
    {
        get { return (this._EMPPHYSICALDTL_ID); }
        set { this._EMPPHYSICALDTL_ID = value; }
    }

    private int _EMPPHYSICALDTL_EMPID;
    public int EMPPHYSICALDTL_EMPID
    {
        get { return (this._EMPPHYSICALDTL_EMPID); }
        set { this._EMPPHYSICALDTL_EMPID = value; }
    }

    private Double _EMPPHYSICALDTL_HEIGHT;
    public Double EMPPHYSICALDTL_HEIGHT
    {
        get { return (this._EMPPHYSICALDTL_HEIGHT); }
        set { this._EMPPHYSICALDTL_HEIGHT = value; }
    }

    private Double _EMPPHYSICALDTL_WEIGHT;
    public Double EMPPHYSICALDTL_WEIGHT
    {
        get { return (this._EMPPHYSICALDTL_WEIGHT); }
        set { this._EMPPHYSICALDTL_WEIGHT = value; }
    }

    private string _EMPPHYSICALDTL_COLOR;
    public string EMPPHYSICALDTL_COLOR
    {
        get { return (this._EMPPHYSICALDTL_COLOR); }
        set { this._EMPPHYSICALDTL_COLOR = value; }
    }

    private string _EMPPHYSICALDTL_IDENTIFICATION;
    public string EMPPHYSICALDTL_IDENTIFICATION
    {
        get { return (this._EMPPHYSICALDTL_IDENTIFICATION); }
        set { this._EMPPHYSICALDTL_IDENTIFICATION = value; }
    }

    private string _EMPPHYSICALDTL_BLOODGROUP;
    public string EMPPHYSICALDTL_BLOODGROUP
    {
        get { return (this._EMPPHYSICALDTL_BLOODGROUP); }
        set { this._EMPPHYSICALDTL_BLOODGROUP = value; }
    }

    private string _EMPPHYSICALDTL_EYEPOWER;
    public string EMPPHYSICALDTL_EYEPOWER
    {
        get { return (this._EMPPHYSICALDTL_EYEPOWER); }
        set { this._EMPPHYSICALDTL_EYEPOWER = value; }
    }

    private bool _EMPPHYSICALDTL_HANDICAP;
    public bool EMPPHYSICALDTL_HANDICAP
    {
        get { return (this._EMPPHYSICALDTL_HANDICAP); }
        set { this._EMPPHYSICALDTL_HANDICAP = value; }
    }

    private string _EMPPHYSICALDTL_HANDICAP_YES;
    public string EMPPHYSICALDTL_HANDICAP_YES
    {
        get { return (this._EMPPHYSICALDTL_HANDICAP_YES); }
        set { this._EMPPHYSICALDTL_HANDICAP_YES = value; }
    }

    private string _EMPPHYSICALDTL_PHYSICALTREATMENT;
    public string EMPPHYSICALDTL_PHYSICALTREATMENT
    {
        get { return (this._EMPPHYSICALDTL_PHYSICALTREATMENT); }
        set { this._EMPPHYSICALDTL_PHYSICALTREATMENT = value; }
    }

    private string _EMPPHYSICALDTL_PHYSICALHOSPITAL;
    public string EMPPHYSICALDTL_PHYSICALHOSPITAL
    {
        get { return (this._EMPPHYSICALDTL_PHYSICALHOSPITAL); }
        set { this._EMPPHYSICALDTL_PHYSICALHOSPITAL = value; }
    }

    private string _EMPPHYSICALDTL_PHYSICALDURATION;
    public string EMPPHYSICALDTL_PHYSICALDURATION
    {
        get { return (this._EMPPHYSICALDTL_PHYSICALDURATION); }
        set { this._EMPPHYSICALDTL_PHYSICALDURATION = value; }
    }

    private string _EMPPHYSICALDTL_PHYSICALSTATUS;
    public string EMPPHYSICALDTL_PHYSICALSTATUS
    {
        get { return (this._EMPPHYSICALDTL_PHYSICALSTATUS); }
        set { this._EMPPHYSICALDTL_PHYSICALSTATUS = value; }
    }

    private string _EMPPHYSICALDTL_MENTALTREATMENT;
    public string EMPPHYSICALDTL_MENTALTREATMENT
    {
        get { return (this._EMPPHYSICALDTL_MENTALTREATMENT); }
        set { this._EMPPHYSICALDTL_MENTALTREATMENT = value; }
    }

    private string _EMPPHYSICALDTL_MENTALHOSPITAL;
    public string EMPPHYSICALDTL_MENTALHOSPITAL
    {
        get { return (this._EMPPHYSICALDTL_MENTALHOSPITAL); }
        set { this._EMPPHYSICALDTL_MENTALHOSPITAL = value; }
    }

    private string _EMPPHYSICALDTL_MENTALDURATION;
    public string EMPPHYSICALDTL_MENTALDURATION
    {
        get { return (this._EMPPHYSICALDTL_MENTALDURATION); }
        set { this._EMPPHYSICALDTL_MENTALDURATION = value; }
    }

    private string _EMPPHYSICALDTL_MENTALSTATUS;
    public string EMPPHYSICALDTL_MENTALSTATUS
    {
        get { return (this._EMPPHYSICALDTL_MENTALSTATUS); }
        set { this._EMPPHYSICALDTL_MENTALSTATUS = value; }
    }



    private int _EMPPHYSICALDTL_CREATEDBY;
    public int EMPPHYSICALDTL_CREATEDBY
    {
        get { return _EMPPHYSICALDTL_CREATEDBY; }
        set { _EMPPHYSICALDTL_CREATEDBY = value; }
    }


    private DateTime _EMPPHYSICALDTL_CREATEDDATE;
    public DateTime EMPPHYSICALDTL_CREATEDDATE
    {
        get { return _EMPPHYSICALDTL_CREATEDDATE; }
        set { _EMPPHYSICALDTL_CREATEDDATE = value; }
    }

    private int _EMPPHYSICALDTL_MODIFIEDBBY;
    public int EMPPHYSICALDTL_MODIFIEDBBY
    {
        get { return _EMPPHYSICALDTL_MODIFIEDBBY; }
        set { _EMPPHYSICALDTL_MODIFIEDBBY = value; }
    }


    private DateTime _EMPPHYSICALDTL_MODIFIEDDATE;
    public DateTime EMPPHYSICALDTL_MODIFIEDDATE
    {
        get { return _EMPPHYSICALDTL_MODIFIEDDATE; }
        set { _EMPPHYSICALDTL_MODIFIEDDATE = value; }
    }

    private string _EMPPHYSICALDTL_PHYSICALDETAILSDOC;

    public string EMPPHYSICALDTL_PHYSICALDETAILSDOC
    {
        get { return _EMPPHYSICALDTL_PHYSICALDETAILSDOC; }
        set { _EMPPHYSICALDTL_PHYSICALDETAILSDOC = value; }
    }
}
#endregion

#region YTD_BALANCES

public class SMHR_YTDOPENINGBALANCE : SMHR_MAIN
{
    public SMHR_YTDOPENINGBALANCE(int __YTD_ID)
    {
        this._YTD_ID = __YTD_ID;
    }


    public SMHR_YTDOPENINGBALANCE()
    {
    }

    private int _YTD_ID;
    public int YTD_ID
    {
        get { return (this._YTD_ID); }
        set { this._YTD_ID = value; }
    }

    private int _YTD_BUSINESSUNIT_ID;
    public int YTD_BUSINESSUNIT_ID
    {
        get { return (this._YTD_BUSINESSUNIT_ID); }
        set { this._YTD_BUSINESSUNIT_ID = value; }
    }

    private int _YTD_EMP_ID;
    public int YTD_EMP_ID
    {
        get { return (this._YTD_EMP_ID); }
        set { this._YTD_EMP_ID = value; }
    }

    private int _YTD_PERIOD_ID;
    public int YTD_PERIOD_ID
    {
        get { return (this._YTD_PERIOD_ID); }
        set { this._YTD_PERIOD_ID = value; }
    }

    private int _YTD_PAYITEM_ID;
    public int YTD_PAYITEM_ID
    {
        get { return (this._YTD_PAYITEM_ID); }
        set { this._YTD_PAYITEM_ID = value; }
    }

    private decimal _YTD_OLDBALANCE;
    public decimal YTD_OLDBALANCE
    {
        get { return (this._YTD_OLDBALANCE); }
        set { this._YTD_OLDBALANCE = value; }
    }

    private decimal _YTD_NEWBALANCE;
    public decimal YTD_NEWBALANCE
    {
        get { return (this._YTD_NEWBALANCE); }
        set { this._YTD_NEWBALANCE = value; }
    }

    private string _YTD_OPERATION;
    public string YTD_OPERATION
    {
        get { return (this._YTD_OPERATION); }
        set { this._YTD_OPERATION = value; }
    }

    private int _YTD_STATUS;
    public int YTD_STATUS
    {
        get { return (this._YTD_STATUS); }
        set { this._YTD_STATUS = value; }
    }
}

#endregion

#region SMHR_EMPRESIGNATION

public class SMHR_EMPRESIGNATION : SMHR_MAIN
{


    public SMHR_EMPRESIGNATION(int __EMPREG_ID)
    {
        this._EMPREG_ID = __EMPREG_ID;
    }

    public SMHR_EMPRESIGNATION()
    {
    }


    private int _EMPREG_ID;

    public int EMPREG_ID
    {
        get { return (this._EMPREG_ID); }
        set { this._EMPREG_ID = value; }
    }

    private int _EMPREG_EMP_ID;

    public int EMPREG_EMP_ID
    {
        get { return (this._EMPREG_EMP_ID); }
        set { this._EMPREG_EMP_ID = value; }
    }

    private DateTime _EMPREG_REGDATE;

    public DateTime EMPREG_REGDATE
    {
        get { return (this._EMPREG_REGDATE); }
        set { this._EMPREG_REGDATE = value; }
    }

    private string _EMPREG_REMARKS;

    public string EMPREG_REMARKS
    {
        get { return (this._EMPREG_REMARKS); }
        set { this._EMPREG_REMARKS = value; }
    }

    private int _EMPREG_REASON;

    public int EMPREG_REASON
    {
        get { return (this._EMPREG_REASON); }
        set { this._EMPREG_REASON = value; }
    }

    private int _EMPREG_DEPT_ID;

    public int EMPREG_DEPT_ID
    {
        get { return (this._EMPREG_DEPT_ID); }
        set { this._EMPREG_DEPT_ID = value; }
    }
    private DateTime? _EMPREG_RELDATE;

    public DateTime? EMPREG_RELDATE
    {
        get { return (this._EMPREG_RELDATE); }
        set { this._EMPREG_RELDATE = value; }
    }

    private int _EMPREG_CREATEDBY;

    public int EMPREG_CREATEDBY
    {
        get { return (this._EMPREG_CREATEDBY); }
        set { this._EMPREG_CREATEDBY = value; }
    }

    private DateTime _EMPREG_CREATEDDATE;

    public DateTime EMPREG_CREATEDDATE
    {
        get { return (this._EMPREG_CREATEDDATE); }
        set { this._EMPREG_CREATEDDATE = value; }
    }
    private bool _EMPREG_IS_TERMINATED;
    public bool EMPREG_IS_TERMINATED
    {
        get { return (this._EMPREG_IS_TERMINATED); }
        set { this._EMPREG_IS_TERMINATED = value; }
    }
    private int _EMPREG_LASTMDFBY;

    public int EMPREG_LASTMDFBY
    {
        get { return (this._EMPREG_LASTMDFBY); }
        set { this._EMPREG_LASTMDFBY = value; }
    }

    private DateTime _EMPREG_LASTMDFDATE;

    public DateTime EMPREG_LASTMDFDATE
    {
        get { return (this._EMPREG_LASTMDFDATE); }
        set { this._EMPREG_LASTMDFDATE = value; }
    }

    private int _EMPREG_APPROVEDBY;

    public int EMPREG_APPROVEDBY
    {
        get { return (this._EMPREG_APPROVEDBY); }
        set { this._EMPREG_APPROVEDBY = value; }
    }

    private DateTime _EMPREG_APPROVEDDATE;

    public DateTime EMPREG_APPROVEDDATE
    {
        get { return (this._EMPREG_APPROVEDDATE); }
        set { this._EMPREG_APPROVEDDATE = value; }
    }

    private int _EMPREG_STATUS;

    public int EMPREG_STATUS
    {
        get { return (this._EMPREG_STATUS); }
        set { this._EMPREG_STATUS = value; }
    }

    private bool _EMPREG_IsRsgndWthOutApprvl;
    public bool EMPREG_IsRsgndWthOutApprvl
    {
        get { return _EMPREG_IsRsgndWthOutApprvl; }
        set { _EMPREG_IsRsgndWthOutApprvl = value; }
    }

    public string EMPREG_FRM_STS { get; set; }
    //Inserted By Ragha Sudha on 24-sep-2013

    private int _EMP_EXIT_INTERVIEW_ID;
    public int EMP_EXIT_INTERVIEW_ID
    {
        get { return (this._EMP_EXIT_INTERVIEW_ID); }
        set { this._EMP_EXIT_INTERVIEW_ID = value; }
    }
    private int _EMP_EXIT_INTERVIEW_EMP_ID;
    public int EMP_EXIT_INTERVIEW_EMP_ID
    {
        get { return (this._EMP_EXIT_INTERVIEW_EMP_ID); }
        set { this._EMP_EXIT_INTERVIEW_EMP_ID = value; }
    }
    private string _EMP_EXIT_INTERVIEW_PRIMARY_REASON;
    public string EMP_EXIT_INTERVIEW_PRIMARY_REASON
    {
        get { return (this._EMP_EXIT_INTERVIEW_PRIMARY_REASON); }
        set { this._EMP_EXIT_INTERVIEW_PRIMARY_REASON = value; }
    }
    private string _EMP_EXIT_INTERVIEW_JOB_SATISFACTION;
    public string EMP_EXIT_INTERVIEW_JOB_SATISFACTION
    {
        get { return (this._EMP_EXIT_INTERVIEW_JOB_SATISFACTION); }
        set { this._EMP_EXIT_INTERVIEW_JOB_SATISFACTION = value; }
    }

    private string _EMP_EXIT_INTERVIEW_JOB_FRUSTRATION;
    public string EMP_EXIT_INTERVIEW_JOB_FRUSTRATION
    {
        get { return (this._EMP_EXIT_INTERVIEW_JOB_FRUSTRATION); }
        set { this._EMP_EXIT_INTERVIEW_JOB_FRUSTRATION = value; }
    }

    private string _EMP_EXIT_INTERVIEW_COMPANY_MEASURES;
    public string EMP_EXIT_INTERVIEW_COMPANY_MEASURES
    {
        get { return (this._EMP_EXIT_INTERVIEW_COMPANY_MEASURES); }
        set { this._EMP_EXIT_INTERVIEW_COMPANY_MEASURES = value; }
    }
    private string _EMP_EXIT_INTERVIEW_SUGGESTION;
    public string EMP_EXIT_INTERVIEW_SUGGESTION
    {
        get { return (this._EMP_EXIT_INTERVIEW_SUGGESTION); }
        set { this._EMP_EXIT_INTERVIEW_SUGGESTION = value; }
    }
    private int _EMP_EXIT_INTERVIEW_EMPREG_ID;
    public int EMP_EXIT_INTERVIEW_EMPREG_ID
    {
        get { return (this._EMP_EXIT_INTERVIEW_EMPREG_ID); }
        set { this._EMP_EXIT_INTERVIEW_EMPREG_ID = value; }
    }
    //Inserted on 24-sep-2013 by Ragha Sudha

}

#endregion

#region SMHR_EMPASSETDOCUMENTS

public class SMHR_EMPASSETDOCUMENTS : SMHR_MAIN
{
    private int _EMPASSETDOCUMENTSUMENTS_ID;
    public int EMPASSETDOCUMENTSUMENTS_ID
    {
        get { return (this._EMPASSETDOCUMENTSUMENTS_ID); }
        set { this._EMPASSETDOCUMENTSUMENTS_ID = value; }
    }

    private int _EMPASSETDOCUMENTSUMENTS_EMP_ID;
    public int EMPASSETDOCUMENTS_EMP_ID
    {
        get { return (this._EMPASSETDOCUMENTSUMENTS_EMP_ID); }
        set { this._EMPASSETDOCUMENTSUMENTS_EMP_ID = value; }
    }

    private string _EMPASSETDOCUMENTS_TYPE;
    public string EMPASSETDOCUMENTS_TYPE
    {
        get { return (this._EMPASSETDOCUMENTS_TYPE); }
        set { this._EMPASSETDOCUMENTS_TYPE = value; }
    }

    private int _EMPASSETDOCUMENTS_SERIAL;
    public int EMPASSETDOCUMENTS_SERIAL
    {
        get { return (this._EMPASSETDOCUMENTS_SERIAL); }
        set { this._EMPASSETDOCUMENTS_SERIAL = value; }
    }

    private string _EMPASSETDOCUMENTS_CODE;
    public string EMPASSETDOCUMENTS_CODE
    {
        get { return (this._EMPASSETDOCUMENTS_CODE); }
        set { this._EMPASSETDOCUMENTS_CODE = value; }
    }

    private string _EMPASSETDOCUMENTS_NAME;
    public string EMPASSETDOCUMENTS_NAME
    {
        get { return (this._EMPASSETDOCUMENTS_NAME); }
        set { this._EMPASSETDOCUMENTS_NAME = value; }
    }

    private string _EMP_ASSETDOCUMENTS_AD_Type;
    public string EMP_ASSETDOCUMENTS_AD_Type
    {
        get { return (this._EMP_ASSETDOCUMENTS_AD_Type); }
        set { this._EMP_ASSETDOCUMENTS_AD_Type = value; }
    }

    private DateTime _EMP_ASSETDOCUMENTS_ISSUEDATE;
    public DateTime EMP_ASSETDOCUMENTS_ISSUEDATE
    {
        get { return (this._EMP_ASSETDOCUMENTS_ISSUEDATE); }
        set { this._EMP_ASSETDOCUMENTS_ISSUEDATE = value; }
    }

    private bool _EMP_ASSETDOCUMENTS_RETURNABLE;
    public bool EMP_ASSETDOCUMENTS_RETURNABLE
    {
        get { return (this._EMP_ASSETDOCUMENTS_RETURNABLE); }
        set { this._EMP_ASSETDOCUMENTS_RETURNABLE = value; }
    }

    private string _EMP_ASSETDOCUMENTS_REMARKS;
    public string EMP_ASSETDOCUMENTS_REMARKS
    {
        get { return (this._EMP_ASSETDOCUMENTS_REMARKS); }
        set { this._EMP_ASSETDOCUMENTS_REMARKS = value; }
    }
}

#endregion

#region SMHR_EMPPROMOTIONS

public class SMHR_EMPPROMOTIONS : SMHR_MAIN
{
    private int _EMPPRO_ID;

    public int EMPPRO_ID
    {
        get { return (this._EMPPRO_ID); }
        set { this._EMPPRO_ID = value; }
    }

    private int _EMPPRO_EMPID;

    public int EMPPRO_EMPID
    {
        get { return (this._EMPPRO_EMPID); }
        set { this._EMPPRO_EMPID = value; }
    }
    private int _EMPPRO_STATUS;

    public int EMPPRO_STATUS
    {
        get { return (this._EMPPRO_STATUS); }
        set { this._EMPPRO_STATUS = value; }
    }
    private DateTime? _EMPPRO_DATEOFPROMOTION;

    public DateTime? EMPPRO_DATEOFPROMOTION
    {
        get { return (this._EMPPRO_DATEOFPROMOTION); }
        set { this._EMPPRO_DATEOFPROMOTION = value; }
    }

    private int _EMPPRO_DESIGNATION_ID;

    public int EMPPRO_DESIGNATION_ID
    {
        get { return (this._EMPPRO_DESIGNATION_ID); }
        set { this._EMPPRO_DESIGNATION_ID = value; }
    }

    private string _EMPPRO_EMPLOYEETYPEN;

    public string EMPPRO_EMPLOYEETYPEN
    {
        get { return (this._EMPPRO_EMPLOYEETYPEN); }
        set { this._EMPPRO_EMPLOYEETYPEN = value; }
    }
    private string _EMPPRO_EMPLOYEETYPE;

    public string EMPPRO_EMPLOYEETYPE
    {
        get { return (this._EMPPRO_EMPLOYEETYPE); }
        set { this._EMPPRO_EMPLOYEETYPE = value; }
    }
    private string _EMPPRO_EMPCODE;

    public string EMPPRO_EMPCODE
    {
        get { return (this._EMPPRO_EMPCODE); }
        set { this._EMPPRO_EMPCODE = value; }
    }
    private string _EMPPRO_EMPCODEN;

    public string EMPPRO_EMPCODEN
    {
        get { return (this._EMPPRO_EMPCODEN); }
        set { this._EMPPRO_EMPCODEN = value; }
    }
    private int _EMPPRO_GRADE;

    public int EMPPRO_GRADE
    {
        get { return (this._EMPPRO_GRADE); }
        set { this._EMPPRO_GRADE = value; }
    }

    private int _EMP_SLAB_ID;
    public int EMP_SLAB_ID
    {
        get { return (this._EMP_SLAB_ID); }
        set { this._EMP_SLAB_ID = value; }
    }

    private DateTime _VALIDATEPERIOD;
    public DateTime VALIDATEPERIOD
    {
        get { return (this._VALIDATEPERIOD); }
        set { this._VALIDATEPERIOD = value; }
    }



    private int _EMPPRO_REPORTINGEMPLOYEE;

    public int EMPPRO_REPORTINGEMPLOYEE
    {
        get { return (this._EMPPRO_REPORTINGEMPLOYEE); }
        set { this._EMPPRO_REPORTINGEMPLOYEE = value; }
    }

    private DateTime? _EMPPRO_REPORTINGEMPLOYEE_ENDDATE;

    public DateTime? EMPPRO_REPORTINGEMPLOYEE_ENDDATE
    {
        get { return (this._EMPPRO_REPORTINGEMPLOYEE_ENDDATE); }
        set { this._EMPPRO_REPORTINGEMPLOYEE_ENDDATE = value; }
    }

    private int _EMMPRO_SHIFT_ID;

    public int EMMPRO_SHIFT_ID
    {
        get { return (this._EMMPRO_SHIFT_ID); }
        set { this._EMMPRO_SHIFT_ID = value; }
    }


    private int _EMPPRO_SALALRYSTRUCT_ID;

    public int EMPPRO_SALALRYSTRUCT_ID
    {
        get { return (this._EMPPRO_SALALRYSTRUCT_ID); }
        set { this._EMPPRO_SALALRYSTRUCT_ID = value; }
    }


    private int _EMPPRO_LEAVESTRUCT_ID;

    public int EMPPRO_LEAVESTRUCT_ID
    {
        get { return (this._EMPPRO_LEAVESTRUCT_ID); }
        set { this._EMPPRO_LEAVESTRUCT_ID = value; }
    }

    private double _EMPPRO_GROSSSAL;

    public double EMPPRO_GROSSSAL
    {
        get { return (this._EMPPRO_GROSSSAL); }
        set { this._EMPPRO_GROSSSAL = value; }
    }
    private Double? _EMPPRO_ANNUALGROSSSAL;

    public Double? EMPPRO_ANNUALGROSSSAL
    {
        get { return (this._EMPPRO_ANNUALGROSSSAL); }
        set { this._EMPPRO_ANNUALGROSSSAL = value; }
    }
    private Double? _EMPPRO_ANNUALBASIC;

    public Double? EMPPRO_ANNUALBASIC
    {
        get { return (this._EMPPRO_ANNUALBASIC); }
        set { this._EMPPRO_ANNUALBASIC = value; }
    }
    private double _EMPPRO_BASIC;

    public double EMPPRO_BASIC
    {
        get { return (this._EMPPRO_BASIC); }
        set { this._EMPPRO_BASIC = value; }
    }

    private int _EMPPRO_INCREMENTTYPE_ID;
    public int EMPPRO_INCREMENTTYPE_ID
    {
        get { return _EMPPRO_INCREMENTTYPE_ID; }
        set { _EMPPRO_INCREMENTTYPE_ID = value; }
    }

    private int _EMP_INCRMENTMONTH;
    public int EMP_INCRMENTMONTH
    {
        get { return _EMP_INCRMENTMONTH; }
        set { _EMP_INCRMENTMONTH = value; }
    }


    private DateTime? _EMPPRO_CONTRACT_STARTDATE;
    public DateTime? EMPPRO_CONTRACT_STARTDATE
    {
        get { return(this. _EMPPRO_CONTRACT_STARTDATE); }
        set { this._EMPPRO_CONTRACT_STARTDATE = value; }
    }
    private DateTime? _EMPPRO_CONTRACT_ENDDATE;
    public DateTime? EMPPRO_CONTRACT_ENDDATE
    {
        get { return (this._EMPPRO_CONTRACT_ENDDATE); }
        set { this._EMPPRO_CONTRACT_ENDDATE = value; }
    }

    private int _EMPPRO_PERIOD;
    public int EMPPRO_PERIOD
    {
        get { return (this._EMPPRO_PERIOD); }
        set { this._EMPPRO_PERIOD = value; }
    }

    private int _EMPPRO_PERIODDETAILS;
    public int EMPPRO_PERIODDETAILS
    {
        get { return (this._EMPPRO_PERIODDETAILS); }
        set { this._EMPPRO_PERIODDETAILS = value; }
    }
    private DateTime? _EMPPRO_INCRMENTDATE;
    public DateTime? EMPPRO_INCRMENTDATE
    {
        get { return (this._EMPPRO_INCRMENTDATE); }
        set { this._EMPPRO_INCRMENTDATE = value; }
    }

    private Int32? _EMPPRO_CREATEDBY;
    public Int32? EMPPRO_CREATEDBY
    {
        get { return (this._EMPPRO_CREATEDBY); }
        set { this._EMPPRO_CREATEDBY = value; }
    }

    private DateTime? _EMPPRO_CREATEDDATE;
    public DateTime? EMPPRO_CREATEDDATE
    {
        get { return (this._EMPPRO_CREATEDDATE); }
        set { this._EMPPRO_CREATEDDATE = value; }
    }

    private Int32? _EMPPRO_LSTMDFBY;
    public Int32? EMPPRO_LSTMDFBY
    {
        get { return (this._EMPPRO_LSTMDFBY); }
        set { this._EMPPRO_LSTMDFBY = value; }
    }

    private DateTime? _MP_LSTMDFDATE;
    public DateTime? MP_LSTMDFDATE
    {
        get { return (this._MP_LSTMDFDATE); }
        set { this._MP_LSTMDFDATE = value; }
    }


}

#endregion

#region SMHR_EMPNODUE

public class SMHR_EMPNODUE : SMHR_MAIN
{
    private int _EMPNODUE_ID;

    public int EMPNODUE_ID
    {
        get { return (this._EMPNODUE_ID); }
        set { this._EMPNODUE_ID = value; }
    }

    private int _EMPNODUE_EMP_ID;

    public int EMPNODUE_EMP_ID
    {
        get { return (this._EMPNODUE_EMP_ID); }
        set { this._EMPNODUE_EMP_ID = value; }
    }

    private int _EMPNODUE_HR_MASTER_ID;

    public int EMPNODUE_HR_MASTER_ID
    {
        get { return (this._EMPNODUE_HR_MASTER_ID); }
        set { this._EMPNODUE_HR_MASTER_ID = value; }
    }

    private int _EMPNODUE_STATUS;

    public int EMPNODUE_STATUS
    {
        get { return (this._EMPNODUE_STATUS); }
        set { this._EMPNODUE_STATUS = value; }
    }

    private string _EMPNODUE_REMARKS;

    public string EMPNODUE_REMARKS
    {
        get { return (this._EMPNODUE_REMARKS); }
        set { this._EMPNODUE_REMARKS = value; }
    }

    private int _EMPNODUE_CREATEDBY;

    public int EMPNODUE_CREATEDBY
    {
        get { return (this._EMPNODUE_CREATEDBY); }
        set { this._EMPNODUE_CREATEDBY = value; }
    }

    private int _EMPNODUE_LASTMDFBY;

    public int EMPNODUE_LASTMDFBY
    {
        get { return (this._EMPNODUE_LASTMDFBY); }
        set { this._EMPNODUE_LASTMDFBY = value; }
    }

    private DateTime _EMPNODUE_CREATEDDATE;

    public DateTime EMPNODUE_CREATEDDATE
    {
        get { return (this._EMPNODUE_CREATEDDATE); }
        set { this._EMPNODUE_CREATEDDATE = value; }
    }

    private DateTime _EMPNODUE_LASTMDFDATE;

    public DateTime EMPNODUE_LASTMDFDATE
    {
        get { return (this._EMPNODUE_LASTMDFDATE); }
        set { this._EMPNODUE_LASTMDFDATE = value; }
    }

}

#endregion

#region SMHR_PAYROLL

public class SMHR_PAYROLL : SMHR_MAIN
{
    private int _PERIODDTLID;
    public int PERIODDTLID
    {
        get { return (this._PERIODDTLID); }
        set { this._PERIODDTLID = value; }
    }

    private int _PERODID;
    public int PERODID
    {
        get { return (this._PERODID); }
        set { this._PERODID = value; }
    }

    private int _STATUS;
    public int STATUS
    {
        get { return (this._STATUS); }
        set { this._STATUS = value; }
    }

    private int _EMP_ID;
    public int EMP_ID
    {
        get { return (this._EMP_ID); }
        set { this._EMP_ID = value; }
    }

    private string _EMP_SALSTRUCT;
    public string EMP_SALSTRUCT
    {
        get { return (this._EMP_SALSTRUCT); }
        set { this._EMP_SALSTRUCT = value; }
    }


    private int _MODE;
    public int MODE
    {
        get { return (this._MODE); }
        set { this._MODE = value; }
    }

    private int _TRANID;
    public int TRANID
    {
        get { return (this._TRANID); }
        set { this._TRANID = value; }
    }

    private string _EMPDATA;
    public string EMPDATA
    {
        get { return (this._EMPDATA); }
        set { this._EMPDATA = value; }
    }

    private string _EMPSALDTLS_STR;
    public string EMPSALDTLS_STR
    {
        get { return (this._EMPSALDTLS_STR); }
        set { this._EMPSALDTLS_STR = value; }
    }

    private int _BUID;
    public int BUID
    {
        get { return (this._BUID); }
        set { this._BUID = value; }
    }
}

#endregion

#region SMHR_EXPENSE

public class SMHR_EXPENSE : SMHR_MAIN
{
    public SMHR_EXPENSE(int __EXPENSE_ID)
    {
        this._EXPENSE_ID = __EXPENSE_ID;
    }

    public SMHR_EXPENSE()
    {
    }

    private int _EXPENSE_ID;
    public int EXPENSE_ID
    {
        get { return (this._EXPENSE_ID); }
        set { this._EXPENSE_ID = value; }
    }
    private int _EXPENSE_EMP_ID;
    public int EXPENSE_EMP_ID
    {
        get { return (this._EXPENSE_EMP_ID); }
        set { this._EXPENSE_EMP_ID = value; }
    }
    private DateTime _EXPENSE_APPDATE;
    public DateTime EXPENSE_APPDATE
    {
        get { return (this._EXPENSE_APPDATE); }
        set { this._EXPENSE_APPDATE = value; }
    }

    private string _EXPENSE_NAME;
    public string EXPENSE_NAME
    {
        get { return (this._EXPENSE_NAME); }
        set { this._EXPENSE_NAME = value; }
    }


    private int _EXPENSE_APPROVEDBY;
    public int EXPENSE_APPROVEDBY
    {
        get { return (this._EXPENSE_APPROVEDBY); }
        set { this._EXPENSE_APPROVEDBY = value; }
    }

    private DateTime _EXPENSE_APPROVEDDATE;
    public DateTime EXPENSE_APPROVEDDATE
    {
        get { return (this._EXPENSE_APPROVEDDATE); }
        set { this._EXPENSE_APPROVEDDATE = value; }
    }

    private int _EXPENSE_STATUS;
    public int EXPENSE_STATUS
    {
        get { return (this._EXPENSE_STATUS); }
        set { this._EXPENSE_STATUS = value; }
    }

    private string _QUERY;
    public string QUERY
    {
        get { return (this._QUERY); }
        set { this._QUERY = value; }
    }

    private int _BUSINESSUNIT_ID;
    public int BUSINESSUNIT_ID
    {
        get { return (this._BUSINESSUNIT_ID); }
        set { this._BUSINESSUNIT_ID = value; }
    }

    private int _EMP_ID;
    public int EMP_ID
    {
        get { return (this._EMP_ID); }
        set { this._EMP_ID = value; }
    }

    public int EXPDTL_ID { get; set; }
}

#endregion

#region SMHR_EXPENSEDETAILS

public class SMHR_EXPENSEDETAIL : SMHR_MAIN
{
    private int _EXPENSEDTL_ID;
    public int EXPENSEDTL_ID
    {
        get { return (this._EXPENSEDTL_ID); }
        set { this._EXPENSEDTL_ID = value; }
    }

    private int _EXPENSEDTL_EXPENSE_ID;
    public int EXPENSEDTL_EXPENSE_ID
    {
        get { return (this._EXPENSEDTL_EXPENSE_ID); }
        set { this._EXPENSEDTL_EXPENSE_ID = value; }
    }

    private int _EXPENSEDTL_TYPE_ID;
    public int EXPENSEDTL_TYPE_ID
    {
        get { return (this._EXPENSEDTL_TYPE_ID); }
        set { this._EXPENSEDTL_TYPE_ID = value; }
    }

    private DateTime _EXPENSEDTL_EXPENSEDATE;
    public DateTime EXPENSEDTL_EXPENSEDATE
    {
        get { return (this._EXPENSEDTL_EXPENSEDATE); }
        set { this._EXPENSEDTL_EXPENSEDATE = value; }
    }
    private decimal _EXPENSEDTL_AMOUNT;
    public decimal EXPENSEDTL_AMOUNT
    {
        get { return (this._EXPENSEDTL_AMOUNT); }
        set { this._EXPENSEDTL_AMOUNT = value; }
    }

    private int _EXPENSEDTL_CURRID;
    public int EXPENSEDTL_CURRID
    {
        get { return (this._EXPENSEDTL_CURRID); }
        set { this._EXPENSEDTL_CURRID = value; }
    }

    private string _EXPENSEDTL_DESC;
    public string EXPENSEDTL_DESC
    {
        get { return (this._EXPENSEDTL_DESC); }
        set { this._EXPENSEDTL_DESC = value; }
    }

    private string _EXPENSEDTL_ATTACHMENT;
    public string EXPENSEDTL_ATTACHMENT
    {
        get { return (this._EXPENSEDTL_ATTACHMENT); }
        set { this._EXPENSEDTL_ATTACHMENT = value; }
    }

    public int EXPENSEDTL_STATUS { get; set; }
}

#endregion

#region SMHR_EMPBNKDETAILS

public class SMHR_EMPBNKDTLS : SMHR_MAIN
{
    private int _EMPBNKDTLS_ID;
    public int EMPBNKDTLS_ID
    {
        get { return (this._EMPBNKDTLS_ID); }
        set { this._EMPBNKDTLS_ID = value; }
    }

    private int _EMPBNKDTLS_EMPID;
    public int EMPBNKDTLS_EMPID
    {
        get { return (this._EMPBNKDTLS_EMPID); }
        set { this._EMPBNKDTLS_EMPID = value; }
    }

    private string _BUSUNTBANK_NAME;
    public string BUSUNTBANK_NAME
    {
        get { return (this._BUSUNTBANK_NAME); }
        set { this._BUSUNTBANK_NAME = value; }
    }

    private string _BUSUNTBANK_ADDRESS;
    public string BUSUNTBANK_ADDRESS
    {
        get { return (this._BUSUNTBANK_ADDRESS); }
        set { this._BUSUNTBANK_ADDRESS = value; }
    }

    private string _BUSUNTBANK_ACCOUNTNO;
    public string BUSUNTBANK_ACCOUNTNO
    {
        get { return (this._BUSUNTBANK_ACCOUNTNO); }
        set { this._BUSUNTBANK_ACCOUNTNO = value; }
    }

    private int _BUSUNITBANK_BANKID;
    public int BUSUNITBANK_BANKID
    {
        get { return (this._BUSUNITBANK_BANKID); }
        set { this._BUSUNITBANK_BANKID = value; }
    }


    private int _BUSUNITBANK_BRANCHID;
    public int BUSUNITBANK_BRANCHID
    {
        get { return (this._BUSUNITBANK_BRANCHID); }
        set { this._BUSUNITBANK_BRANCHID = value; }
    }

    private bool _BUSUNTBANK_ISACTIVE;
    public bool BUSUNTBANK_ISACTIVE
    {
        get { return (this._BUSUNTBANK_ISACTIVE); }
        set { this._BUSUNTBANK_ISACTIVE = value; }
    }

    private bool _BUSUNTBANK_ISDEFAULT;
    public bool BUSUNTBANK_ISDEFAULT
    {
        get { return (this._BUSUNTBANK_ISDEFAULT); }
        set { this._BUSUNTBANK_ISDEFAULT = value; }
    }

    private bool _BUSUNTBANK_ISDELETED;
    public bool BUSUNTBANK_ISDELETED
    {
        get { return (this._BUSUNTBANK_ISDELETED); }
        set { this._BUSUNTBANK_ISDELETED = value; }
    }

    private int _BUSUNTBANK_CREATEDBY;
    public int BUSUNTBANK_CREATEDBY
    {
        get { return (this._BUSUNTBANK_CREATEDBY); }
        set { this._BUSUNTBANK_CREATEDBY = value; }
    }

    private DateTime _BUSUNTBANK_CREATEDDATE;
    public DateTime BUSUNTBANK_CREATEDDATE
    {
        get { return (this._BUSUNTBANK_CREATEDDATE); }
        set { this._BUSUNTBANK_CREATEDDATE = value; }
    }

    private int _BUSUNTBANK_LASTMDFBY;
    public int BUSUNTBANK_LASTMDFBY
    {
        get { return (this._BUSUNTBANK_LASTMDFBY); }
        set { this._BUSUNTBANK_LASTMDFBY = value; }
    }

    private DateTime _BUSUNTBANK_LASTMDFDATE;
    public DateTime BUSUNTBANK_LASTMDFDATE
    {
        get { return (this._BUSUNTBANK_LASTMDFDATE); }
        set { this._BUSUNTBANK_LASTMDFDATE = value; }
    }

    private string _BUSUNTBANK_BRANCH;
    public string BUSUNTBANK_BRANCH
    {
        get { return (this._BUSUNTBANK_BRANCH); }
        set { this._BUSUNTBANK_BRANCH = value; }
    }

    private string _BUSUNTBANK_SWIFT;
    public string BUSUNTBANK_SWIFT
    {
        get { return (this._BUSUNTBANK_SWIFT); }
        set { this._BUSUNTBANK_SWIFT = value; }
    }
}

#endregion

#region SMHR_PAYITEMS_EMP

public class SMHR_PAYITEMS_EMP : SMHR_MAIN
{
    private int _SMHR_EMP_PAYITEMS_ID;
    public int SMHR_EMP_PAYITEMS_ID
    {
        get { return (this._SMHR_EMP_PAYITEMS_ID); }
        set { this._SMHR_EMP_PAYITEMS_ID = value; }
    }

    private bool _SMHR_EMP_PAYITEMS_CHECKED;
    public bool SMHR_EMP_PAYITEMS_CHECKED
    {
        get { return (this._SMHR_EMP_PAYITEMS_CHECKED); }
        set { this._SMHR_EMP_PAYITEMS_CHECKED = value; }
    }


    private int _SMHR_EMP_PAYITEMS_EMPID;
    public int SMHR_EMP_PAYITEMS_EMPID
    {
        get { return (this._SMHR_EMP_PAYITEMS_EMPID); }
        set { this._SMHR_EMP_PAYITEMS_EMPID = value; }
    }

    private int _SMHR_EMP_PAYITEMS_PAYITEMID;
    public int SMHR_EMP_PAYITEMS_PAYITEMID
    {
        get { return (this._SMHR_EMP_PAYITEMS_PAYITEMID); }
        set { this._SMHR_EMP_PAYITEMS_PAYITEMID = value; }
    }

    private int _SMHR_EMP_PAYITEMS_PERIODID;
    public int SMHR_EMP_PAYITEMS_PERIODID
    {
        get { return (this._SMHR_EMP_PAYITEMS_PERIODID); }
        set { this._SMHR_EMP_PAYITEMS_PERIODID = value; }
    }

    private int _SMHR_EMP_GRADEID;
    public int SMHR_EMP_GRADEID
    {
        get { return (this._SMHR_EMP_GRADEID); }
        set { this._SMHR_EMP_GRADEID = value; }
    }


    private double _SMHR_EMP_PAYITEMS_VALUE;
    public double SMHR_EMP_PAYITEMS_VALUE
    {
        get { return (this._SMHR_EMP_PAYITEMS_VALUE); }
        set { this._SMHR_EMP_PAYITEMS_VALUE = value; }
    }

    private int _SMHR_EMP_PAYITEMS_CREATEDBY;
    public int SMHR_EMP_PAYITEMS_CREATEDBY
    {
        get { return (this._SMHR_EMP_PAYITEMS_CREATEDBY); }
        set { this._SMHR_EMP_PAYITEMS_CREATEDBY = value; }
    }

    private DateTime _SMHR_EMP_PAYITEMS_CREATEDDATE;
    public DateTime SMHR_EMP_PAYITEMS_CREATEDDATE
    {
        get { return (this._SMHR_EMP_PAYITEMS_CREATEDDATE); }
        set { this._SMHR_EMP_PAYITEMS_CREATEDDATE = value; }
    }

    private int _SMHR_EMP_PAYITEMS_LASTMDFBY;
    public int SMHR_EMP_PAYITEMS_LASTMDFBY
    {
        get { return (this._SMHR_EMP_PAYITEMS_LASTMDFBY); }
        set { this._SMHR_EMP_PAYITEMS_LASTMDFBY = value; }
    }

    private DateTime _SMHR_EMP_PAYITEMS_LASTMDFDATE;
    public DateTime SMHR_EMP_PAYITEMS_LASTMDFDATE
    {
        get { return (this._SMHR_EMP_PAYITEMS_LASTMDFDATE); }
        set { this._SMHR_EMP_PAYITEMS_LASTMDFDATE = value; }
    }

    private int _SMHR_BUSUNIT;
    public int SMHR_BUSUNIT
    {
        get { return (this._SMHR_BUSUNIT); }
        set { this._SMHR_BUSUNIT = value; }
    }

    private string _SMHR_EMP_PAYITEMS_CALMODE;
    public string SMHR_EMP_PAYITEMS_CALMODE
    {
        get { return (this._SMHR_EMP_PAYITEMS_CALMODE); }
        set { this._SMHR_EMP_PAYITEMS_CALMODE = value; }
    }
}

#endregion

#region SMHR_IDENTIFICATION

public class SMHR_IDENTIFICATION : SMHR_MAIN
{
    private int _IDNTMASTER_ID;
    public int IDNTMASTER_ID
    {
        get { return (this._IDNTMASTER_ID); }
        set { this._IDNTMASTER_ID = value; }
    }

    private int _IDNTMASTER_EMPID;
    public int IDNTMASTER_EMPID
    {
        get { return (this._IDNTMASTER_EMPID); }
        set { this._IDNTMASTER_EMPID = value; }
    }

    private string _IDNTMASTER_CODE;
    public string IDNTMASTER_CODE
    {
        get { return (this._IDNTMASTER_CODE); }
        set { this._IDNTMASTER_CODE = value; }
    }

    private string _IDNTMASTER_NAME;
    public string IDNTMASTER_NAME
    {
        get { return (this._IDNTMASTER_NAME); }
        set { this._IDNTMASTER_NAME = value; }
    }

    private string _IDNTMASTER_TYPE;
    public string IDNTMASTER_TYPE
    {
        get { return (this._IDNTMASTER_TYPE); }
        set { this._IDNTMASTER_TYPE = value; }
    }

    private DateTime? _IDNTMASTER_ISSUEDT;
    public DateTime? IDNTMASTER_ISSUEDT
    {
        get { return (this._IDNTMASTER_ISSUEDT); }
        set { this._IDNTMASTER_ISSUEDT = value; }
    }

    private DateTime? _IDNTMASTER_EXPIRYDT;
    public DateTime? IDNTMASTER_EXPIRYDT
    {
        get { return (this._IDNTMASTER_EXPIRYDT); }
        set { this._IDNTMASTER_EXPIRYDT = value; }
    }

    private string _IDNTMASTER_ISSUEDORG;
    public string IDNTMASTER_ISSUEDORG
    {
        get { return (this._IDNTMASTER_ISSUEDORG); }
        set { this._IDNTMASTER_ISSUEDORG = value; }
    }

    private int _IDNTMASTER_CREATEDBY;
    public int IDNTMASTER_CREATEDBY
    {
        get { return (this._IDNTMASTER_CREATEDBY); }
        set { this._IDNTMASTER_CREATEDBY = value; }
    }

    private DateTime _IDNTMASTER_CREATEDDATE;
    public DateTime IDNTMASTER_CREATEDDATE
    {
        get { return (this._IDNTMASTER_CREATEDDATE); }
        set { this._IDNTMASTER_CREATEDDATE = value; }
    }

    private int _IDNTMASTER_LASTMDFBY;
    public int IDNTMASTER_LASTMDFBY
    {
        get { return (this._IDNTMASTER_LASTMDFBY); }
        set { this._IDNTMASTER_LASTMDFBY = value; }
    }

    private DateTime _IDNTMASTER_LASTMDFDATE;
    public DateTime IDNTMASTER_LASTMDFDATE
    {
        get { return (this._IDNTMASTER_LASTMDFDATE); }
        set { this._IDNTMASTER_LASTMDFDATE = value; }
    }

}


#endregion

#region SMHR_EMPLOYEEWEEKLYOFF

public class SMHR_EMPLOYEEWEEKLYOFF : SMHR_MAIN
{
    private int _EMPWOFF_ID;
    public int EMPWOFF_ID
    {
        get { return (this._EMPWOFF_ID); }
        set { this._EMPWOFF_ID = value; }
    }

    private int _EMPWOFF_EMP_ID;
    public int EMPWOFF_EMP_ID
    {
        get { return (this._EMPWOFF_EMP_ID); }
        set { this._EMPWOFF_EMP_ID = value; }
    }

    private bool _EMPWOFF_MON;
    public bool EMPWOFF_MON
    {
        get { return (this._EMPWOFF_MON); }
        set { this._EMPWOFF_MON = value; }
    }

    private bool _EMPWOFF_TUE;
    public bool EMPWOFF_TUE
    {
        get { return (this._EMPWOFF_TUE); }
        set { this._EMPWOFF_TUE = value; }
    }

    private bool _EMPWOFF_WED;
    public bool EMPWOFF_WED
    {
        get { return (this._EMPWOFF_WED); }
        set { this._EMPWOFF_WED = value; }
    }

    private bool _EMPWOFF_THU;
    public bool EMPWOFF_THU
    {
        get { return (this._EMPWOFF_THU); }
        set { this._EMPWOFF_THU = value; }
    }

    private bool _EMPWOFF_FRI;
    public bool EMPWOFF_FRI
    {
        get { return (this._EMPWOFF_FRI); }
        set { this._EMPWOFF_FRI = value; }
    }

    private bool _EMPWOFF_SAT;
    public bool EMPWOFF_SAT
    {
        get { return (this._EMPWOFF_SAT); }
        set { this._EMPWOFF_SAT = value; }
    }

    private bool _EMPWOFF_SUN;
    public bool EMPWOFF_SUN
    {
        get { return (this._EMPWOFF_SUN); }
        set { this._EMPWOFF_SUN = value; }
    }

    private int _EMPWOFF_CREATEDBY;
    public int EMPWOFF_CREATEDBY
    {
        get { return (this._EMPWOFF_CREATEDBY); }
        set { this._EMPWOFF_CREATEDBY = value; }
    }

    private DateTime _EMPWOFF_CREATEDDATE;
    public DateTime EMPWOFF_CREATEDDATE
    {
        get { return (this._EMPWOFF_CREATEDDATE); }
        set { this._EMPWOFF_CREATEDDATE = value; }
    }

    private int _EMPWOFF_LASTMDFBY;
    public int EMPWOFF_LASTMDFBY
    {
        get { return (this._EMPWOFF_LASTMDFBY); }
        set { this._EMPWOFF_LASTMDFBY = value; }
    }

    private DateTime _EMPWOFF_LASTMDFDATE;
    public DateTime EMPWOFF_LASTMDFDATE
    {
        get { return (this._EMPWOFF_LASTMDFDATE); }
        set { this._EMPWOFF_LASTMDFDATE = value; }
    }

    private DateTime? _EMPWOFF_EFFDATE;
    public DateTime? EMPWOFF_EFFDATE
    {
        get { return (this._EMPWOFF_EFFDATE); }
        set { this._EMPWOFF_EFFDATE = value; }
    }
    public string EMPWOFFEFDATE { get; set; }

}

#endregion

#region SMHR_TAX_SLAB

public class SMHR_TAX_SLAB : SMHR_MAIN
{
    private int _SMHR_ID;
    public int SMHR_ID
    {
        get { return (this._SMHR_ID); }
        set { this._SMHR_ID = value; }
    }

    private int _SMHR_TAXSERIALNO;
    public int SMHR_TAXSERIALNO
    {
        get { return (this._SMHR_TAXSERIALNO); }
        set { this._SMHR_TAXSERIALNO = value; }
    }

    private double _SMHR_TAXFROMVALUE;
    public double SMHR_TAXFROMVALUE
    {
        get { return (this._SMHR_TAXFROMVALUE); }
        set { this._SMHR_TAXFROMVALUE = value; }
    }

    private double _SMHR_TAXTOVALUE;
    public double SMHR_TAXTOVALUE
    {
        get { return (this._SMHR_TAXTOVALUE); }
        set { this._SMHR_TAXTOVALUE = value; }
    }

    private double _SMHR_TAXVALUE;
    public double SMHR_TAXVALUE
    {
        get { return (this._SMHR_TAXVALUE); }
        set { this._SMHR_TAXVALUE = value; }
    }

    private int _SMHR_TAXCREATEDBY;
    public int SMHR_TAXCREATEDBY
    {
        get { return (this._SMHR_TAXCREATEDBY); }
        set { this._SMHR_TAXCREATEDBY = value; }
    }

    private DateTime _SMHR_TAXCREATEDDATE;
    public DateTime SMHR_TAXCREATEDDATE
    {
        get { return (this._SMHR_TAXCREATEDDATE); }
        set { this._SMHR_TAXCREATEDDATE = value; }
    }

    private int _SMHR_TAXLASTMDFBY;
    public int SMHR_TAXLASTMDFBY
    {
        get { return (this._SMHR_TAXLASTMDFBY); }
        set { this._SMHR_TAXLASTMDFBY = value; }
    }

    private DateTime _SMHR_TAXLASTMDFDATE;
    public DateTime SMHR_TAXLASTMDFDATE
    {
        get { return (this._SMHR_TAXLASTMDFDATE); }
        set { this._SMHR_TAXLASTMDFDATE = value; }
    }

    private int _SMHR_TAXMODE;
    public int SMHR_TAXMODE
    {
        get { return (this._SMHR_TAXMODE); }
        set { this._SMHR_TAXMODE = value; }
    }

    private int _SMHR_TAXBU;
    public int SMHR_TAXBU
    {
        get { return (this._SMHR_TAXBU); }
        set { this._SMHR_TAXBU = value; }
    }


}

#endregion

#region SMHR_PAYREJECT

public class SMHR_PAYREJECT : SMHR_MAIN
{
    private int _TRANID;
    public int TRANID
    {
        get { return (this._TRANID); }
        set { this._TRANID = value; }
    }

    private int _MODE;
    public int MODE
    {
        get { return (this._MODE); }
        set { this._MODE = value; }
    }

    private int _EMP_ID;
    public int EMP_ID
    {
        get { return (this._EMP_ID); }
        set { this._EMP_ID = value; }
    }

    private int _PERIODDTL_ID;
    public int PERIODDTL_ID
    {
        get { return (this._PERIODDTL_ID); }
        set { this._PERIODDTL_ID = value; }
    }

}

#endregion

#region SMHR_TAX_EXEMPT

public class SMHR_TAX_EXEMPT : SMHR_MAIN
{
    private int _SMHR_TAX_ID;
    public int SMHR_TAX_ID
    {
        get { return (this._SMHR_TAX_ID); }
        set { this._SMHR_TAX_ID = value; }
    }

    private int _SMHR_TAX_COUNTRY_ID;
    public int SMHR_TAX_COUNTRY_ID
    {
        get { return (this._SMHR_TAX_COUNTRY_ID); }
        set { this._SMHR_TAX_COUNTRY_ID = value; }
    }

    private string _SMHR_TAX_NAME;
    public string SMHR_TAX_NAME
    {
        get { return (this._SMHR_TAX_NAME); }
        set { this._SMHR_TAX_NAME = value; }
    }

    private string _SMHR_TAX_DESC;
    public string SMHR_TAX_DESC
    {
        get { return (this._SMHR_TAX_DESC); }
        set { this._SMHR_TAX_DESC = value; }
    }

    private double _SMHR_TAX_MAXLIMIT;
    public double SMHR_TAX_MAXLIMIT
    {
        get { return (this._SMHR_TAX_MAXLIMIT); }
        set { this._SMHR_TAX_MAXLIMIT = value; }
    }

    private bool _SMHR_TAX_ACTIVE;
    public bool SMHR_TAX_ACTIVE
    {
        get { return (this._SMHR_TAX_ACTIVE); }
        set { this._SMHR_TAX_ACTIVE = value; }
    }

    private int _SMHR_TAX_CREATEDBY;
    public int SMHR_TAX_CREATEDBY
    {
        get { return (this._SMHR_TAX_CREATEDBY); }
        set { this._SMHR_TAX_CREATEDBY = value; }
    }

    private DateTime _SMHR_TAX_CREATEDDATE;
    public DateTime SMHR_TAX_CREATEDDATE
    {
        get { return (this._SMHR_TAX_CREATEDDATE); }
        set { this._SMHR_TAX_CREATEDDATE = value; }
    }

    private int _SMHR_TAX_LASTMDFBY;
    public int SMHR_TAX_LASTMDFBY
    {
        get { return (this._SMHR_TAX_LASTMDFBY); }
        set { this._SMHR_TAX_LASTMDFBY = value; }
    }

    private DateTime _SMHR_TAX_LASTMDFDATE;
    public DateTime SMHR_TAX_LASTMDFDATE
    {
        get { return (this._SMHR_TAX_LASTMDFDATE); }
        set { this._SMHR_TAX_LASTMDFDATE = value; }
    }

    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }
}

#endregion

#region SMHR_INCOME

public class SMHR_INCOME : SMHR_MAIN
{
    private int _SMHR_INCOME_ID;
    public int SMHR_INCOME_ID
    {
        get { return (this._SMHR_INCOME_ID); }
        set { this._SMHR_INCOME_ID = value; }
    }

    private int _SMHR_INCOME_BUID;
    public int SMHR_INCOME_BUID
    {
        get { return (this._SMHR_INCOME_BUID); }
        set { this._SMHR_INCOME_BUID = value; }
    }

    private string _SMHR_INCOME_NAME;
    public string SMHR_INCOME_NAME
    {
        get { return (this._SMHR_INCOME_NAME); }
        set { this._SMHR_INCOME_NAME = value; }
    }

    private string _SMHR_INCOME_DESC;
    public string SMHR_INCOME_DESC
    {
        get { return (this._SMHR_INCOME_DESC); }
        set { this._SMHR_INCOME_DESC = value; }
    }

    private double _SMHR_INCOME_MAXLIMIT;
    public double SMHR_INCOME_MAXLIMIT
    {
        get { return (this._SMHR_INCOME_MAXLIMIT); }
        set { this._SMHR_INCOME_MAXLIMIT = value; }
    }

    private bool _SMHR_INCOME_ACTIVE;
    public bool SMHR_INCOME_ACTIVE
    {
        get { return (this._SMHR_INCOME_ACTIVE); }
        set { this._SMHR_INCOME_ACTIVE = value; }
    }

    private int _SMHR_INCOME_CREATEDBY;
    public int SMHR_INCOME_CREATEDBY
    {
        get { return (this._SMHR_INCOME_CREATEDBY); }
        set { this._SMHR_INCOME_CREATEDBY = value; }
    }

    private DateTime _SMHR_INCOME_CREATEDDATE;
    public DateTime SMHR_INCOME_CREATEDDATE
    {
        get { return (this._SMHR_INCOME_CREATEDDATE); }
        set { this._SMHR_INCOME_CREATEDDATE = value; }
    }

    private int _SMHR_INCOME_LASTMDFBY;
    public int SMHR_INCOME_LASTMDFBY
    {
        get { return (this._SMHR_INCOME_LASTMDFBY); }
        set { this._SMHR_INCOME_LASTMDFBY = value; }
    }

    private DateTime _SMHR_INCOME_LASTMDFDATE;
    public DateTime SMHR_INCOME_LASTMDFDATE
    {
        get { return (this._SMHR_INCOME_LASTMDFDATE); }
        set { this._SMHR_INCOME_LASTMDFDATE = value; }
    }

    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }
}

#endregion

#region SMHR_TAX_TRANS

public class SMHR_TAX_TRANS : SMHR_MAIN
{
    private int _SMHR_EMPTAX_ID;
    public int SMHR_EMPTAX_ID
    {
        get { return (this._SMHR_EMPTAX_ID); }
        set { this._SMHR_EMPTAX_ID = value; }
    }

    private int _SMHR_EMPTAX_EMPID;
    public int SMHR_EMPTAX_EMPID
    {
        get { return (this._SMHR_EMPTAX_EMPID); }
        set { this._SMHR_EMPTAX_EMPID = value; }
    }

    private int _SMHR_EMPTAX_TAXID;
    public int SMHR_EMPTAX_TAXID
    {
        get { return (this._SMHR_EMPTAX_TAXID); }
        set { this._SMHR_EMPTAX_TAXID = value; }
    }

    private int _SMHR_EMPTAX_PERIOD_ID;
    public int SMHR_EMPTAX_PERIOD_ID
    {
        get { return (this._SMHR_EMPTAX_PERIOD_ID); }
        set { this._SMHR_EMPTAX_PERIOD_ID = value; }
    }

    private double _SMHR_EMPTAX_AMOUNT;
    public double SMHR_EMPTAX_AMOUNT
    {
        get { return (this._SMHR_EMPTAX_AMOUNT); }
        set { this._SMHR_EMPTAX_AMOUNT = value; }
    }
    private int _SMHR_EMPTAX_BU;
    public int SMHR_EMPTAX_BU
    {
        get { return (this._SMHR_EMPTAX_BU); }
        set { this._SMHR_EMPTAX_BU = value; }
    }
    private int _SMHR_EMPTAX_CREATEDBY;
    public int SMHR_EMPTAX_CREATEDBY
    {
        get { return (this._SMHR_EMPTAX_CREATEDBY); }
        set { this._SMHR_EMPTAX_CREATEDBY = value; }
    }

    private DateTime _SMHR_EMPTAX_CREATEDDATE;
    public DateTime SMHR_EMPTAX_CREATEDDATE
    {
        get { return (this._SMHR_EMPTAX_CREATEDDATE); }
        set { this._SMHR_EMPTAX_CREATEDDATE = value; }
    }

    private int _SMHR_EMPTAX_LASTMDFBY;
    public int SMHR_EMPTAX_LASTMDFBY
    {
        get { return (this._SMHR_EMPTAX_LASTMDFBY); }
        set { this._SMHR_EMPTAX_LASTMDFBY = value; }
    }

    private DateTime _SMHR_EMPTAX_LASTMDFDATE;
    public DateTime SMHR_EMPTAX_LASTMDFDATE
    {
        get { return (this._SMHR_EMPTAX_LASTMDFDATE); }
        set { this._SMHR_EMPTAX_LASTMDFDATE = value; }
    }

    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }

    private double _SMHR_EMPTAX_AMT;
    public double SMHR_EMPTAX_AMT
    {
        get { return (this._SMHR_EMPTAX_AMT); }
        set { this._SMHR_EMPTAX_AMT = value; }
    }
    // FOR COPYING PURPOSE
    private int _SMHR_EMPTAX_NEWPERIODID;
    public int SMHR_EMPTAX_NEWPERIODID
    {
        get { return this._SMHR_EMPTAX_NEWPERIODID; }
        set { this._SMHR_EMPTAX_NEWPERIODID = value; }
    }

}

#endregion

#region SMHR_INCOME_TRANS

public class SMHR_INCOME_TRANS : SMHR_MAIN
{
    private int _SMHR_EMPINCOME_ID;
    public int SMHR_EMPINCOME_ID
    {
        get { return (this._SMHR_EMPINCOME_ID); }
        set { this._SMHR_EMPINCOME_ID = value; }
    }

    private int _SMHR_EMPINCOME_EMPID;
    public int SMHR_EMPINCOME_EMPID
    {
        get { return (this._SMHR_EMPINCOME_EMPID); }
        set { this._SMHR_EMPINCOME_EMPID = value; }
    }

    private int _SMHR_EMPINCOME_INCOMEID;
    public int SMHR_EMPINCOME_INCOMEID
    {
        get { return (this._SMHR_EMPINCOME_INCOMEID); }
        set { this._SMHR_EMPINCOME_INCOMEID = value; }
    }

    private double _SMHR_EMPINCOME_AMOUNT;
    public double SMHR_EMPINCOME_AMOUNT
    {
        get { return (this._SMHR_EMPINCOME_AMOUNT); }
        set { this._SMHR_EMPINCOME_AMOUNT = value; }
    }

    private int _SMHR_EMPINCOME_CREATEDBY;
    public int SMHR_EMPINCOME_CREATEDBY
    {
        get { return (this._SMHR_EMPINCOME_CREATEDBY); }
        set { this._SMHR_EMPINCOME_CREATEDBY = value; }
    }

    private DateTime _SMHR_EMPINCOME_CREATEDDATE;
    public DateTime SMHR_EMPINCOME_CREATEDDATE
    {
        get { return (this._SMHR_EMPINCOME_CREATEDDATE); }
        set { this._SMHR_EMPINCOME_CREATEDDATE = value; }
    }

    private int _SMHR_EMPINCOME_LASTMDFBY;
    public int SMHR_EMPINCOME_LASTMDFBY
    {
        get { return (this._SMHR_EMPINCOME_LASTMDFBY); }
        set { this._SMHR_EMPINCOME_LASTMDFBY = value; }
    }

    private int _SMHR_EMPINCOME_PERIOD;
    public int SMHR_EMPINCOME_PERIOD
    {
        get { return (this._SMHR_EMPINCOME_PERIOD); }
        set { this._SMHR_EMPINCOME_PERIOD = value; }
    }

    private DateTime _SMHR_EMPINCOME_LASTMDFDATE;
    public DateTime SMHR_EMPINCOME_LASTMDFDATE
    {
        get { return (this._SMHR_EMPINCOME_LASTMDFDATE); }
        set { this._SMHR_EMPINCOME_LASTMDFDATE = value; }
    }

    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }

    private double _SMHR_EMPINCOME_AMT;
    public double SMHR_EMPINCOME_AMT
    {
        get { return (this._SMHR_EMPINCOME_AMT); }
        set { this._SMHR_EMPINCOME_AMT = value; }
    }

}

#endregion

#region SMHR_DIRECTPAYMENTS

public class SMHR_DIRECTPAYMENTS : SMHR_MAIN
{
    private int _SMHR_DIRECTPMT_ID;
    public int SMHR_DIRECTPMT_ID
    {
        get { return (this._SMHR_DIRECTPMT_ID); }
        set { this._SMHR_DIRECTPMT_ID = value; }
    }

    private int _SMHR_DIRECTPMT_BUID;
    public int SMHR_DIRECTPMT_BUID
    {
        get { return (this._SMHR_DIRECTPMT_BUID); }
        set { this._SMHR_DIRECTPMT_BUID = value; }
    }

    private int _SMHR_DIRECTPMT_EMPID;
    public int SMHR_DIRECTPMT_EMPID
    {
        get { return (this._SMHR_DIRECTPMT_EMPID); }
        set { this._SMHR_DIRECTPMT_EMPID = value; }
    }

    private DateTime _SMHR_DIRECTPMT_ISSUEDT;
    public DateTime SMHR_DIRECTPMT_ISSUEDT
    {
        get { return (this._SMHR_DIRECTPMT_ISSUEDT); }
        set { this._SMHR_DIRECTPMT_ISSUEDT = value; }
    }

    private double _SMHR_DIRECTPMT_AMOUNT;
    public double SMHR_DIRECTPMT_AMOUNT
    {
        get { return (this._SMHR_DIRECTPMT_AMOUNT); }
        set { this._SMHR_DIRECTPMT_AMOUNT = value; }
    }

    private string _SMHR_DIRECTPMT_REMARKS;
    public string SMHR_DIRECTPMT_REMARKS
    {
        get { return (this._SMHR_DIRECTPMT_REMARKS); }
        set { this._SMHR_DIRECTPMT_REMARKS = value; }
    }

    private int _SMHR_DIRECTPMT_CREATEDBY;
    public int SMHR_DIRECTPMT_CREATEDBY
    {
        get { return (this._SMHR_DIRECTPMT_CREATEDBY); }
        set { this._SMHR_DIRECTPMT_CREATEDBY = value; }
    }

    private DateTime _SMHR_DIRECTPMT_CREATEDDATE;
    public DateTime SMHR_DIRECTPMT_CREATEDDATE
    {
        get { return (this._SMHR_DIRECTPMT_CREATEDDATE); }
        set { this._SMHR_DIRECTPMT_CREATEDDATE = value; }
    }

    private int _SMHR_DIRECTPMT_LASTMDFBY;
    public int SMHR_DIRECTPMT_LASTMDFBY
    {
        get { return (this._SMHR_DIRECTPMT_LASTMDFBY); }
        set { this._SMHR_DIRECTPMT_LASTMDFBY = value; }
    }

    private DateTime _SMHR_DIRECTPMT_LASTMDFDATE;
    public DateTime SMHR_DIRECTPMT_LASTMDFDATE
    {
        get { return (this._SMHR_DIRECTPMT_LASTMDFDATE); }
        set { this._SMHR_DIRECTPMT_LASTMDFDATE = value; }
    }

    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }

    private int mSMHR_DIRECTPMT_TYPE;

    public int SMHR_DIRECTPMT_TYPE
    {
        get
        {
            return (this.mSMHR_DIRECTPMT_TYPE);
        }
        set
        {
            this.mSMHR_DIRECTPMT_TYPE = value;
        }
    }

    private double mSMHR_CHEQUENUMBER;

    public double SMHR_CHEQUENUMBER
    {
        get
        {
            return (this.mSMHR_CHEQUENUMBER);
        }
        set
        {
            this.mSMHR_CHEQUENUMBER = value;
        }
    }

}


#endregion

#region SMHR_TDS_CONSULTANT

public class SMHR_TDS_CONSULTANT : SMHR_MAIN
{
    public SMHR_TDS_CONSULTANT()
    {
    }

    private int _TDS_ID;
    public int TDS_ID
    {
        get { return (this._TDS_ID); }
        set { this._TDS_ID = value; }
    }

    private int _TDS_COUNTRY_ID;
    public int TDS_COUNTRY_ID
    {
        get { return (this._TDS_COUNTRY_ID); }
        set { this._TDS_COUNTRY_ID = value; }
    }

    private double _TDS_VALUE;
    public double TDS_VALUE
    {
        get { return (this._TDS_VALUE); }
        set { this._TDS_VALUE = value; }
    }

    private int _TDS_CREATED_BY;
    public int TDS_CREATED_BY
    {
        get { return (this._TDS_CREATED_BY); }
        set { this._TDS_CREATED_BY = value; }
    }

    private DateTime _TDS_CREATED_DATE;
    public DateTime TDS_CREATED_DATE
    {
        get { return (this._TDS_CREATED_DATE); }
        set { this._TDS_CREATED_DATE = value; }
    }

    private int _TDS_LSTMDF_BY;
    public int TDS_LSTMDF_BY
    {
        get { return (this._TDS_LSTMDF_BY); }
        set { this._TDS_LSTMDF_BY = value; }
    }

    private DateTime _TDS_LSTMDF_DATE;
    public DateTime TDS_LSTMDF_DATE
    {
        get { return (this._TDS_LSTMDF_DATE); }
        set { this._TDS_LSTMDF_DATE = value; }
    }
}

#endregion

#region SMHR_CHANGEPASSWORD

public class SMHR_ChangePassword : SMHR_MAIN
{
    private string mOldPassword;

    public string oldPassword
    {
        get
        {
            return (this.mOldPassword);
        }
        set
        {
            this.mOldPassword = value;
        }
    }

    private string mNewPasword;

    public string NewPasword
    {
        get
        {
            return (this.mNewPasword);
        }
        set
        {
            this.mNewPasword = value;
        }
    }

    private string mUserName;

    public string UserName
    {
        get
        {
            return (this.mUserName);
        }
        set
        {
            this.mUserName = value;
        }
    }

    private int mMode;

    public int Mode
    {
        get
        {
            return (this.mMode);
        }
        set
        {
            this.mMode = value;
        }
    }

    public string PassCode { get; set; }

}


#endregion

#region SMHR_TAX_NHIF

public class SMHR_TAX_NHIF : SMHR_MAIN
{
    private int _SMHR_ID;
    public int SMHR_ID
    {
        get { return (this._SMHR_ID); }
        set { this._SMHR_ID = value; }
    }

    private int _SMHR_TAXSERIALNO;
    public int SMHR_TAXSERIALNO
    {
        get { return (this._SMHR_TAXSERIALNO); }
        set { this._SMHR_TAXSERIALNO = value; }
    }

    private double _SMHR_TAXFROMVALUE;
    public double SMHR_TAXFROMVALUE
    {
        get { return (this._SMHR_TAXFROMVALUE); }
        set { this._SMHR_TAXFROMVALUE = value; }
    }

    private double _SMHR_TAXTOVALUE;
    public double SMHR_TAXTOVALUE
    {
        get { return (this._SMHR_TAXTOVALUE); }
        set { this._SMHR_TAXTOVALUE = value; }
    }

    private double _SMHR_TAXVALUE;
    public double SMHR_TAXVALUE
    {
        get { return (this._SMHR_TAXVALUE); }
        set { this._SMHR_TAXVALUE = value; }
    }

    private int _SMHR_TAXCREATEDBY;
    public int SMHR_TAXCREATEDBY
    {
        get { return (this._SMHR_TAXCREATEDBY); }
        set { this._SMHR_TAXCREATEDBY = value; }
    }

    private DateTime _SMHR_TAXCREATEDDATE;
    public DateTime SMHR_TAXCREATEDDATE
    {
        get { return (this._SMHR_TAXCREATEDDATE); }
        set { this._SMHR_TAXCREATEDDATE = value; }
    }

    private int _SMHR_TAXLASTMDFBY;
    public int SMHR_TAXLASTMDFBY
    {
        get { return (this._SMHR_TAXLASTMDFBY); }
        set { this._SMHR_TAXLASTMDFBY = value; }
    }

    private DateTime _SMHR_TAXLASTMDFDATE;
    public DateTime SMHR_TAXLASTMDFDATE
    {
        get { return (this._SMHR_TAXLASTMDFDATE); }
        set { this._SMHR_TAXLASTMDFDATE = value; }
    }

    private int _SMHR_TAXMODE;
    public int SMHR_TAXMODE
    {
        get { return (this._SMHR_TAXMODE); }
        set { this._SMHR_TAXMODE = value; }
    }

}

#endregion

#region SMHR_EMP_HRA
public class SMHR_EMP_HRA : SMHR_MAIN
{
    public SMHR_EMP_HRA(int __SMHR_HRA_ID)
    {
        this._SMHR_HRA_ID = __SMHR_HRA_ID;
    }

    public SMHR_EMP_HRA()
    {
    }
    private int _SMHR_HRA_ID;
    public int SMHR_HRA_ID
    {
        get { return (this._SMHR_HRA_ID); }
        set { this._SMHR_HRA_ID = value; }
    }

    private int _SMHR_HRA_BU_ID;
    public int SMHR_HRA_BU_ID
    {
        get { return (this._SMHR_HRA_BU_ID); }
        set { this._SMHR_HRA_BU_ID = value; }
    }
    private int _SMHR_HRA_PAYITEM_ID;
    public int SMHR_HRA_PAYITEM_ID
    {
        get { return (this._SMHR_HRA_PAYITEM_ID); }
        set { this._SMHR_HRA_PAYITEM_ID = value; }
    }
    private string _SMHR_HRA_EXCESS_PAYITEM_ID;
    public string SMHR_HRA_EXCESS_PAYITEM_ID
    {
        get { return (this._SMHR_HRA_EXCESS_PAYITEM_ID); }
        set { this._SMHR_HRA_EXCESS_PAYITEM_ID = value; }
    }
    private int _SMHR_HRA_TAX_EXEMPT_ID;
    public int SMHR_HRA_TAX_EXEMPT_ID
    {
        get { return (this._SMHR_HRA_TAX_EXEMPT_ID); }
        set { this._SMHR_HRA_TAX_EXEMPT_ID = value; }
    }
    private int _SMHR_HRA_EMP_ID;
    public int SMHR_HRA_EMP_ID
    {
        get { return (this._SMHR_HRA_EMP_ID); }
        set { this._SMHR_HRA_EMP_ID = value; }
    }
    private int _SMHR_HRA_PERIOD;
    public int SMHR_HRA_PERIOD
    {
        get { return (this._SMHR_HRA_PERIOD); }
        set { this._SMHR_HRA_PERIOD = value; }
    }

    private string _SMHR_HRA_EMP_HRAVALUE;
    public string SMHR_HRA_EMP_HRAVALUE
    {
        get { return (this._SMHR_HRA_EMP_HRAVALUE); }
        set { this._SMHR_HRA_EMP_HRAVALUE = value; }
    }



    private bool _SMHR_HRA_EMP_ISFINALISED;
    public bool SMHR_HRA_EMP_ISFINALISED
    {
        get { return (this._SMHR_HRA_EMP_ISFINALISED); }
        set { this._SMHR_HRA_EMP_ISFINALISED = value; }
    }

    private string _SMHR_HRA_EMP_ACTUALRENT_PAID;
    public string SMHR_HRA_EMP_ACTUALRENT_PAID
    {
        get { return (this._SMHR_HRA_EMP_ACTUALRENT_PAID); }
        set { this._SMHR_HRA_EMP_ACTUALRENT_PAID = value; }
    }
    private string _SMHR_HRA_EMP_EXCESSSALARY;
    public string SMHR_HRA_EMP_EXCESSSALARY
    {
        get { return (this._SMHR_HRA_EMP_EXCESSSALARY); }
        set { this._SMHR_HRA_EMP_EXCESSSALARY = value; }
    }
    private string _SMHR_HRA_EMP_TAX_LIMIT;
    public string SMHR_HRA_EMP_TAX_LIMIT
    {
        get { return (this._SMHR_HRA_EMP_TAX_LIMIT); }
        set { this._SMHR_HRA_EMP_TAX_LIMIT = value; }
    }
    private string _SMHR_HRA_EMP_EXEMPTAMOUNT;
    public string SMHR_HRA_EMP_EXEMPTAMOUNT
    {
        get { return (this._SMHR_HRA_EMP_EXEMPTAMOUNT); }
        set { this._SMHR_HRA_EMP_EXEMPTAMOUNT = value; }
    }
    private string _SMHR_METRO_HRA;
    public string SMHR_METRO_HRA
    {
        get { return (this._SMHR_METRO_HRA); }
        set { this._SMHR_METRO_HRA = value; }
    }


    private bool _SMHR_ISCHECKED;
    public bool SMHR_ISCHECKED
    {
        get { return (this._SMHR_ISCHECKED); }
        set { this._SMHR_ISCHECKED = value; }
    }
    private bool _SMHR_ISSELECT;
    public bool SMHR_ISSELECT
    {
        get { return (this._SMHR_ISSELECT); }
        set { this._SMHR_ISSELECT = value; }
    }

    private DateTime _SMHR_HRA_CREATEDDATE;
    public DateTime SMHR_HRA_CREATEDDATE
    {
        get { return (this._SMHR_HRA_CREATEDDATE); }
        set { this._SMHR_HRA_CREATEDDATE = value; }
    }

    private int _SMHR_HRA_LASTMDFBY;
    public int SMHR_HRA_LASTMDFBY
    {
        get { return (this._SMHR_HRA_LASTMDFBY); }
        set { this._SMHR_HRA_LASTMDFBY = value; }
    }

    private int _SMHR_HRA_CREATEDBY;
    public int SMHR_HRA_CREATEDBY
    {
        get { return (this._SMHR_HRA_CREATEDBY); }
        set { this._SMHR_HRA_CREATEDBY = value; }
    }
    private int _SMHR_ORG_ID;
    public int SMHR_ORG_ID
    {
        get { return (this._SMHR_ORG_ID); }
        set { this._SMHR_ORG_ID = value; }
    }



    private DateTime _SMHR_HRA_LASTMDFDATE;
    public DateTime SMHR_HRA_LASTMDFDATE
    {
        get { return (this._SMHR_HRA_LASTMDFDATE); }
        set { this._SMHR_HRA_LASTMDFDATE = value; }
    }

    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }


}
#endregion

#region SMHR_HRA
public class SMHR_HRA : SMHR_MAIN
{
    public SMHR_HRA(int __SMHR_HRA_ID)
    {
        this._SMHR_HRA_ID = __SMHR_HRA_ID;
    }

    public SMHR_HRA()
    {
    }
    private int _SMHR_HRA_ID;
    public int SMHR_HRA_ID
    {
        get { return (this._SMHR_HRA_ID); }
        set { this._SMHR_HRA_ID = value; }
    }




    private DateTime _SMHR_HRA_CREATEDDATE;
    public DateTime SMHR_HRA_CREATEDDATE
    {
        get { return (this._SMHR_HRA_CREATEDDATE); }
        set { this._SMHR_HRA_CREATEDDATE = value; }
    }

    private int _SMHR_HRA_LASTMDFBY;
    public int SMHR_HRA_LASTMDFBY
    {
        get { return (this._SMHR_HRA_LASTMDFBY); }
        set { this._SMHR_HRA_LASTMDFBY = value; }
    }


    private int _SMHR_HRA_TAXEXEMPTEDELEMENTS;
    public int SMHR_HRA_TAXEXEMPTEDELEMENTS
    {
        get { return (this._SMHR_HRA_TAXEXEMPTEDELEMENTS); }
        set { this._SMHR_HRA_TAXEXEMPTEDELEMENTS = value; }
    }

    private int _SMHR_HRA_CREATEDBY;
    public int SMHR_HRA_CREATEDBY
    {
        get { return (this._SMHR_HRA_CREATEDBY); }
        set { this._SMHR_HRA_CREATEDBY = value; }
    }
    private int _SMHR_ORG_ID;
    public int SMHR_ORG_ID
    {
        get { return (this._SMHR_ORG_ID); }
        set { this._SMHR_ORG_ID = value; }
    }
    private int _SMHR_PERIOD_ID;
    public int SMHR_PERIOD_ID
    {
        get { return (this._SMHR_PERIOD_ID); }
        set { this._SMHR_PERIOD_ID = value; }
    }
    private string _SMHR_HRA_MUL_ID;
    public string SMHR_HRA_MUL_ID
    {
        get { return (this._SMHR_HRA_MUL_ID); }
        set { this._SMHR_HRA_MUL_ID = value; }
    }

    private int _SMHR_PAYITEMID1;
    public int SMHR_PAYITEMID1
    {
        get { return (this._SMHR_PAYITEMID1); }
        set { this._SMHR_PAYITEMID1 = value; }
    }
    private DateTime _SMHR_HRA_LASTMDFDATE;
    public DateTime SMHR_HRA_LASTMDFDATE
    {
        get { return (this._SMHR_HRA_LASTMDFDATE); }
        set { this._SMHR_HRA_LASTMDFDATE = value; }
    }

    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }


}
#endregion

#region SMHR_ESIMASTER
public class SMHR_ESIMASTER : SMHR_MAIN
{
    public SMHR_ESIMASTER(int __SMHR_ESI_MASTER_ID)
    {
        this._SMHR_ESI_MASTER_ID = __SMHR_ESI_MASTER_ID;
    }

    public SMHR_ESIMASTER()
    {
    }
    private int _SMHR_ESI_MASTER_ID;
    public int SMHR_ESI_MASTER_ID
    {
        get { return (this._SMHR_ESI_MASTER_ID); }
        set { this._SMHR_ESI_MASTER_ID = value; }
    }

    private int _SMHR_ESI_MASTER_BUID;
    public int SMHR_ESI_MASTER_BUID
    {
        get { return (this._SMHR_ESI_MASTER_BUID); }
        set { this._SMHR_ESI_MASTER_BUID = value; }
    }
    private int _SMHR_ESI_MASTER_ORGID;
    public int SMHR_ESI_MASTER_ORGID
    {
        get { return (this._SMHR_ESI_MASTER_ORGID); }
        set { this._SMHR_ESI_MASTER_ORGID = value; }
    }
    private int _SMHR_ESI_MASTER_EMPID;
    public int SMHR_ESI_MASTER_EMPID
    {
        get { return (this._SMHR_ESI_MASTER_EMPID); }
        set { this._SMHR_ESI_MASTER_EMPID = value; }
    }
    private string _SMHR_ESI_MASTER_IPNO;
    public string SMHR_ESI_MASTER_IPNO
    {
        get { return (this._SMHR_ESI_MASTER_IPNO); }
        set { this._SMHR_ESI_MASTER_IPNO = value; }
    }

    private string _SMHR_ESI_MASTER_IPNAME;
    public string SMHR_ESI_MASTER_IPNAME
    {
        get { return (this._SMHR_ESI_MASTER_IPNAME); }
        set { this._SMHR_ESI_MASTER_IPNAME = value; }
    }
    private DateTime _SMHR_ESI_MASTER_CREATEDATE;
    public DateTime SMHR_ESI_MASTER_CREATEDATE
    {
        get { return (this._SMHR_ESI_MASTER_CREATEDATE); }
        set { this._SMHR_ESI_MASTER_CREATEDATE = value; }
    }

    private int _SMHR_ESI_MASTER_CREATEDBY;
    public int SMHR_ESI_MASTER_CREATEDBY
    {
        get { return (this._SMHR_ESI_MASTER_CREATEDBY); }
        set { this._SMHR_ESI_MASTER_CREATEDBY = value; }
    }

    private int _SMHR_ESI_MASTER_MODIFIEDBY;
    public int SMHR_ESI_MASTER_MODIFIEDBY
    {
        get { return (this._SMHR_ESI_MASTER_MODIFIEDBY); }
        set { this._SMHR_ESI_MASTER_MODIFIEDBY = value; }
    }


    private DateTime _SMHR_ESI_MASTER_MODIFIEDDATE;
    public DateTime SMHR_ESI_MASTER_MODIFIEDDATE
    {
        get { return (this._SMHR_ESI_MASTER_MODIFIEDDATE); }
        set { this._SMHR_ESI_MASTER_MODIFIEDDATE = value; }
    }

    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }




}
#endregion

#region SMHR_ESIIMPORT
public class SMHR_ESIIMPORT : SMHR_MAIN
{
    public SMHR_ESIIMPORT(int __ESIIMPORT_ID)
    {
        this._ESIIMPORT_ID = __ESIIMPORT_ID;
    }

    public SMHR_ESIIMPORT()
    {
    }
    private int _ESIIMPORT_ID;
    public int ESIIMPORT_ID
    {
        get { return (this._ESIIMPORT_ID); }
        set { this._ESIIMPORT_ID = value; }
    }
    private string _ESIIMPORT_EMPNAME;
    public string ESIIMPORT_EMPNAME
    {
        get { return (this._ESIIMPORT_EMPNAME); }
        set { this._ESIIMPORT_EMPNAME = value; }
    }
    private int _ESIIMPORT_BUID;
    public int ESIIMPORT_BUID
    {
        get { return (this._ESIIMPORT_BUID); }
        set { this._ESIIMPORT_BUID = value; }
    }
    private string _ESIIMPORT_IPNAME;
    public string ESIIMPORT_IPNAME
    {
        get { return (this._ESIIMPORT_IPNAME); }
        set { this._ESIIMPORT_IPNAME = value; }
    }

    private int _ESIIMPORT_PRESENTDAYS;
    public int ESIIMPORT_PRESENTDAYS
    {
        get { return (this._ESIIMPORT_PRESENTDAYS); }
        set { this._ESIIMPORT_PRESENTDAYS = value; }
    }
    private string _ESIIMPORT_TOTALAMOUNT;
    public string ESIIMPORT_TOTALAMOUNT
    {
        get { return (this._ESIIMPORT_TOTALAMOUNT); }
        set { this._ESIIMPORT_TOTALAMOUNT = value; }
    }

    private int _ESIIMPORT_REASONCODE;
    public int ESIIMPORT_REASONCODE
    {
        get { return (this._ESIIMPORT_REASONCODE); }
        set { this._ESIIMPORT_REASONCODE = value; }
    }
    private int _ESIIMPORT_FINANCIAL_PERIOD;
    public int ESIIMPORT_FINANCIAL_PERIOD
    {
        get { return (this._ESIIMPORT_FINANCIAL_PERIOD); }
        set { this._ESIIMPORT_FINANCIAL_PERIOD = value; }
    }
    private int _ESIIMPORT_PERIDEMLEMENTID;
    public int ESIIMPORT_PERIDEMLEMENTID
    {
        get { return (this._ESIIMPORT_PERIDEMLEMENTID); }
        set { this._ESIIMPORT_PERIDEMLEMENTID = value; }
    }



    private int _ESIIMPORT_ORGID;
    public int ESIIMPORT_ORGID
    {
        get { return (this._ESIIMPORT_ORGID); }
        set { this._ESIIMPORT_ORGID = value; }
    }

    private string _ESIIMPORT_IPNO;
    public string ESIIMPORT_IPNO
    {
        get { return (this._ESIIMPORT_IPNO); }
        set { this._ESIIMPORT_IPNO = value; }
    }

    private int _SMHR_ESIIMPORT_EMPID;
    public int SMHR_ESIIMPORT_EMPID
    {
        get { return this._SMHR_ESIIMPORT_EMPID; }
        set { this._SMHR_ESIIMPORT_EMPID = value; }
    }

    private bool _SMHR_ESIIMPORT_ISFINALISED;
    public bool SMHR_ESIIMPORT_ISFINALISED
    {
        get { return this._SMHR_ESIIMPORT_ISFINALISED; }
        set { this._SMHR_ESIIMPORT_ISFINALISED = value; }
    }

    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }


}
#endregion

#region SMHR_TAX_ENTERTAINMENT

public class SMHR_TAX_ENTERTAINMENT : SMHR_MAIN
{
    private int _SMHR_ID;
    public int SMHR_ID
    {
        get { return (this._SMHR_ID); }
        set { this._SMHR_ID = value; }
    }

    private int _SMHR_TAXSERIALNO;
    public int SMHR_TAXSERIALNO
    {
        get { return (this._SMHR_TAXSERIALNO); }
        set { this._SMHR_TAXSERIALNO = value; }
    }

    private double _SMHR_TAXFROMVALUE;
    public double SMHR_TAXFROMVALUE
    {
        get { return (this._SMHR_TAXFROMVALUE); }
        set { this._SMHR_TAXFROMVALUE = value; }
    }

    private double _SMHR_TAXTOVALUE;
    public double SMHR_TAXTOVALUE
    {
        get { return (this._SMHR_TAXTOVALUE); }
        set { this._SMHR_TAXTOVALUE = value; }
    }

    private double _SMHR_TAXVALUE;
    public double SMHR_TAXVALUE
    {
        get { return (this._SMHR_TAXVALUE); }
        set { this._SMHR_TAXVALUE = value; }
    }

    private int _SMHR_TAXCREATEDBY;
    public int SMHR_TAXCREATEDBY
    {
        get { return (this._SMHR_TAXCREATEDBY); }
        set { this._SMHR_TAXCREATEDBY = value; }
    }

    private DateTime _SMHR_TAXCREATEDDATE;
    public DateTime SMHR_TAXCREATEDDATE
    {
        get { return (this._SMHR_TAXCREATEDDATE); }
        set { this._SMHR_TAXCREATEDDATE = value; }
    }

    private int _SMHR_TAXLASTMDFBY;
    public int SMHR_TAXLASTMDFBY
    {
        get { return (this._SMHR_TAXLASTMDFBY); }
        set { this._SMHR_TAXLASTMDFBY = value; }
    }

    private DateTime _SMHR_TAXLASTMDFDATE;
    public DateTime SMHR_TAXLASTMDFDATE
    {
        get { return (this._SMHR_TAXLASTMDFDATE); }
        set { this._SMHR_TAXLASTMDFDATE = value; }
    }

    private int _SMHR_TAXMODE;
    public int SMHR_TAXMODE
    {
        get { return (this._SMHR_TAXMODE); }
        set { this._SMHR_TAXMODE = value; }
    }

}

#endregion

#region SMHR_EMP_MED_SCHEME

public class SMHR_EMP_MED_SCHEME : SMHR_MAIN
{
    private int _SMHR_MED_DTL_ID;
    public int SMHR_MED_DTL_ID
    {
        get { return (this._SMHR_MED_DTL_ID); }
        set { this._SMHR_MED_DTL_ID = value; }
    }

    private double _SMHR_MED_IP_USED_AMT;
    public double SMHR_MED_IP_USED_AMT
    {
        get { return (this._SMHR_MED_IP_USED_AMT); }
        set { this._SMHR_MED_IP_USED_AMT = value; }
    }

    private double _SMHR_MED_OP_USED_AMT;
    public double SMHR_MED_OP_USED_AMT
    {
        get { return (this._SMHR_MED_OP_USED_AMT); }
        set { this._SMHR_MED_OP_USED_AMT = value; }
    }

    private int _SMHR_MED_ORG_ID;
    public int SMHR_MED_ORG_ID
    {
        get { return (this._SMHR_MED_ORG_ID); }
        set { this._SMHR_MED_ORG_ID = value; }
    }

    private int _SMHR_MED_BU_ID;
    public int SMHR_MED_BU_ID
    {
        get { return (this._SMHR_MED_BU_ID); }
        set { this._SMHR_MED_BU_ID = value; }
    }

    private int _SMHR_MED_EMP_ID;
    public int SMHR_MED_EMP_ID
    {
        get { return (this._SMHR_MED_EMP_ID); }
        set { this._SMHR_MED_EMP_ID = value; }
    }

    private double _SMHR_MED_IP_AV_AMT;
    public double SMHR_MED_IP_AV_AMT
    {
        get { return (this._SMHR_MED_IP_AV_AMT); }
        set { this._SMHR_MED_IP_AV_AMT = value; }
    }

    private double _SMHR_MED_OP_AV_AMT;
    public double SMHR_MED_OP_AV_AMT
    {
        get { return (this._SMHR_MED_OP_AV_AMT); }
        set { this._SMHR_MED_OP_AV_AMT = value; }
    }

    private int _SMHR_MED_CREATEDBY;
    public int SMHR_MED_CREATEDBY
    {
        get { return (this._SMHR_MED_CREATEDBY); }
        set { this._SMHR_MED_CREATEDBY = value; }
    }

    private DateTime _SMHR_MED_CREATEDDATE;
    public DateTime SMHR_MED_CREATEDDATE
    {
        get { return (this._SMHR_MED_CREATEDDATE); }
        set { this._SMHR_MED_CREATEDDATE = value; }
    }

    private int _SMHR_MED_LASTMDFBY;
    public int SMHR_MED_LASTMDFBY
    {
        get { return (this._SMHR_MED_LASTMDFBY); }
        set { this._SMHR_MED_LASTMDFBY = value; }
    }

    private DateTime _SMHR_MED_LASTMDFDATE;
    public DateTime SMHR_MED_LASTMDFDATE
    {
        get { return (this._SMHR_MED_LASTMDFDATE); }
        set { this._SMHR_MED_LASTMDFDATE = value; }
    }

    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }

    private int _SMHR_MED_ID;
    public int SMHR_MED_ID
    {
        get { return (this._SMHR_MED_ID); }
        set { this._SMHR_MED_ID = value; }
    }

    private int _SMHR_MED_PERIOD_ID;
    public int SMHR_MED_PERIOD_ID
    {
        get { return (this._SMHR_MED_PERIOD_ID); }
        set { this._SMHR_MED_PERIOD_ID = value; }
    }

}

#endregion

#region SMHR_EMPOTHERDETAILS
public class SMHR_EMPOTHERDETAILS : SMHR_MAIN
{
    private int _EMPOTHERDTL_ID;

    public int EMPOTHERDTL_ID
    {
        get { return _EMPOTHERDTL_ID; }
        set { _EMPOTHERDTL_ID = value; }
    }
    private int _EMPOTHERDTL_EMPID;

    public int EMPOTHERDTL_EMPID
    {
        get { return _EMPOTHERDTL_EMPID; }
        set { _EMPOTHERDTL_EMPID = value; }
    }
    private string _EMPOTHERDTL_IDNO;

    public string EMPOTHERDTL_IDNO
    {
        get { return _EMPOTHERDTL_IDNO; }
        set { _EMPOTHERDTL_IDNO = value; }
    }
    private string _EMPOTHERDTL_PINNO;

    public string EMPOTHERDTL_PINNO
    {
        get { return _EMPOTHERDTL_PINNO; }
        set { _EMPOTHERDTL_PINNO = value; }
    }
    private string _EMPOTHERDTL_NSSFNO;

    public string EMPOTHERDTL_NSSFNO
    {
        get { return _EMPOTHERDTL_NSSFNO; }
        set { _EMPOTHERDTL_NSSFNO = value; }
    }
    private string _EMPOTHERDTL_NHIFNO;

    public string EMPOTHERDTL_NHIFNO
    {
        get { return _EMPOTHERDTL_NHIFNO; }
        set { _EMPOTHERDTL_NHIFNO = value; }
    }
    private string _EMPOTHERDTL_TAXRELIEFAMOUNT;

    public string EMPOTHERDTL_TAXRELIEFAMOUNT
    {
        get { return _EMPOTHERDTL_TAXRELIEFAMOUNT; }
        set { _EMPOTHERDTL_TAXRELIEFAMOUNT = value; }
    }
    private string _EMPOTHERDTL_NNAKNO;

    public string EMPOTHERDTL_NNAKNO
    {
        get { return _EMPOTHERDTL_NNAKNO; }
        set { _EMPOTHERDTL_NNAKNO = value; }
    }
    private int _EMPOTHERDTL_CREATEDBY;

    public int EMPOTHERDTL_CREATEDBY
    {
        get { return _EMPOTHERDTL_CREATEDBY; }
        set { _EMPOTHERDTL_CREATEDBY = value; }
    }
    private DateTime _EMPOTHERDTL_CREATEDDATE;

    public DateTime EMPOTHERDTL_CREATEDDATE
    {
        get { return _EMPOTHERDTL_CREATEDDATE; }
        set { _EMPOTHERDTL_CREATEDDATE = value; }
    }
    private int _EMPOTHERDTL_MODIFIEDBBY;

    public int EMPOTHERDTL_MODIFIEDBBY
    {
        get { return _EMPOTHERDTL_MODIFIEDBBY; }
        set { _EMPOTHERDTL_MODIFIEDBBY = value; }
    }
    private DateTime _EMPOTHERDTL_MODIFIEDDATE;

    public DateTime EMPOTHERDTL_MODIFIEDDATE
    {
        get { return _EMPOTHERDTL_MODIFIEDDATE; }
        set { _EMPOTHERDTL_MODIFIEDDATE = value; }
    }

    private string _EMPOTHERDTL_PASSPORTNO;
    public string EMPOTHERDTL_PASSPORTNO
    {
        get { return (this._EMPOTHERDTL_PASSPORTNO); }
        set { this._EMPOTHERDTL_PASSPORTNO = value; }
    }

    private DateTime? _EMPOTHERDTL_EXPIRYDATE;
    public DateTime? EMPOTHERDTL_EXPIRYDATE
    {
        get { return (this._EMPOTHERDTL_EXPIRYDATE); }
        set { this._EMPOTHERDTL_EXPIRYDATE = value; }
    }

    private string _EMPOTHERDTL_KRANO;
    public string EMPOTHERDTL_KRANO
    {
        get { return (this._EMPOTHERDTL_KRANO); }
        set { this._EMPOTHERDTL_KRANO = value; }
    }
    private string _EMPOTHERDTL_PPIDNO;
    public string EMPOTHERDTL_PPIDNO
    {
        get { return (this._EMPOTHERDTL_PPIDNO); }
        set { this._EMPOTHERDTL_PPIDNO = value; }
    }

    private string _EMPOTHERDTL_HELBNO;

    public string EMPOTHERDTL_HELBNO
    {
        get { return _EMPOTHERDTL_HELBNO; }
        set { _EMPOTHERDTL_HELBNO = value; }
    }

    private string _EMPOTHERDTL_COOPNO;

    public string EMPOTHERDTL_COOPNO
    {
        get { return _EMPOTHERDTL_COOPNO; }
        set { _EMPOTHERDTL_COOPNO = value; }
    }
    public int EMPOTHERDTL_PROJECT_ID { get; set; }
    public int EMPOTHERDTL_FUNDING_ID { get; set; }

    //added by Shiva Reddy A
    private string _EMPOTHERDTL_BUDGETLINE;
    public string EMPOTHERDTL_BUDGETLINE
    {
        get { return _EMPOTHERDTL_BUDGETLINE; }
        set { _EMPOTHERDTL_BUDGETLINE = value; }
    }
}


#endregion

#region SMHR_EMPIMPORTANTDATES
public class SMHR_EMPIMPORTANTDATES : SMHR_MAIN
{
    private int _EMPIMPORTANTDATES_ID;

    public int EMPIMPORTANTDATES_ID
    {
        get { return _EMPIMPORTANTDATES_ID; }
        set { _EMPIMPORTANTDATES_ID = value; }
    }
    private int _EMPIMPORTANTDATES_EMPID;

    public int EMPIMPORTANTDATES_EMPID
    {
        get { return _EMPIMPORTANTDATES_EMPID; }
        set { _EMPIMPORTANTDATES_EMPID = value; }
    }

    private string _EMPIMPORTANTDATES_ANNIVERSARYDATE;

    public string EMPIMPORTANTDATES_ANNIVERSARYDATE
    {
        get { return (this._EMPIMPORTANTDATES_ANNIVERSARYDATE); }
        set { this._EMPIMPORTANTDATES_ANNIVERSARYDATE = value; }
    }

    private string _EMPIMPORTANTDATES_PENSIONJOINEDDATE;

    public string EMPIMPORTANTDATES_PENSIONJOINEDDATE
    {
        get { return (this._EMPIMPORTANTDATES_PENSIONJOINEDDATE); }
        set { this._EMPIMPORTANTDATES_PENSIONJOINEDDATE = value; }
    }

    private string _EMPIMPORTANTDATES_MEDICALTERMINATIONDATE;

    public string EMPIMPORTANTDATES_MEDICALTERMINATIONDATE
    {
        get { return (this._EMPIMPORTANTDATES_MEDICALTERMINATIONDATE); }
        set { this._EMPIMPORTANTDATES_MEDICALTERMINATIONDATE = value; }
    }

    private int _EMPIMPORTANTDATES_ORG_ID;

    public int EMPIMPORTANTDATES_ORG_ID
    {
        get { return _EMPIMPORTANTDATES_ORG_ID; }
        set { _EMPIMPORTANTDATES_ORG_ID = value; }
    }

    private int _EMPIMPORTANTDATES_CREATEDBY;

    public int EMPIMPORTANTDATES_CREATEDBY
    {
        get { return _EMPIMPORTANTDATES_CREATEDBY; }
        set { _EMPIMPORTANTDATES_CREATEDBY = value; }
    }
    private DateTime _EMPIMPORTANTDATES_CREATEDDATE;

    public DateTime EMPIMPORTANTDATES_CREATEDDATE
    {
        get { return _EMPIMPORTANTDATES_CREATEDDATE; }
        set { _EMPIMPORTANTDATES_CREATEDDATE = value; }
    }
    private int _EMPIMPORTANTDATES_MODIFIEDBBY;

    public int EMPIMPORTANTDATES_MODIFIEDBBY
    {
        get { return _EMPIMPORTANTDATES_MODIFIEDBBY; }
        set { _EMPIMPORTANTDATES_MODIFIEDBBY = value; }
    }
    private DateTime _EMPIMPORTANTDATES_MODIFIEDDATE;

    public DateTime EMPIMPORTANTDATES_MODIFIEDDATE
    {
        get { return _EMPIMPORTANTDATES_MODIFIEDDATE; }
        set { _EMPIMPORTANTDATES_MODIFIEDDATE = value; }
    }

    private string _EMPIMPORTANTDATES_ORIENTATIONDATE;

    public string EMPIMPORTANTDATES_ORIENTATIONDATE
    {
        get { return _EMPIMPORTANTDATES_ORIENTATIONDATE; }
        set { _EMPIMPORTANTDATES_ORIENTATIONDATE = value; }
    }

    private string _EMPIMPORTANTDATES_ORIENTATIONDOC;

    public string EMPIMPORTANTDATES_ORIENTATIONDOC
    {
        get { return _EMPIMPORTANTDATES_ORIENTATIONDOC; }
        set { _EMPIMPORTANTDATES_ORIENTATIONDOC = value; }
    }
    private string _EMPIMPORTANTDATES_OFFICIALSCERECTSACTDOC;

    public string EMPIMPORTANTDATES_OFFICIALSCERECTSACTDOC
    {
        get { return _EMPIMPORTANTDATES_OFFICIALSCERECTSACTDOC; }
        set { _EMPIMPORTANTDATES_OFFICIALSCERECTSACTDOC = value; }
    }

    private string _EMPIMPORTANTDATES_NEXTOFKINFORM;

    public string EMPIMPORTANTDATES_NEXTOFKINFORM
    {
        get { return _EMPIMPORTANTDATES_NEXTOFKINFORM; }
        set { _EMPIMPORTANTDATES_NEXTOFKINFORM = value; }
    }

    private string _EMPIMPORTANTDATES_PSC2_1;

    public string EMPIMPORTANTDATES_PSC2_1
    {
        get { return _EMPIMPORTANTDATES_PSC2_1; }
        set { _EMPIMPORTANTDATES_PSC2_1 = value; }
    }

    private string _EMPIMPORTANTDATES_STAFFPARTICULARS;

    public string EMPIMPORTANTDATES_STAFFPARTICULARS
    {
        get { return _EMPIMPORTANTDATES_STAFFPARTICULARS; }
        set { _EMPIMPORTANTDATES_STAFFPARTICULARS = value; }
    }
}


#endregion

#region SMHR_LEAVE_YEAR_END_PROCESS

public class SMHR_LEAVE_YEAR_END_PROCESS
{
    private int _FROM_PERIOD;
    public int FROM_PERIOD
    {
        get { return (this._FROM_PERIOD); }
        set { this._FROM_PERIOD = value; }
    }

    private int _TO_PERIOD;
    public int TO_PERIOD
    {
        get { return (this._TO_PERIOD); }
        set { this._TO_PERIOD = value; }
    }

    private int _MODE;
    public int MODE
    {
        get { return (this._MODE); }
        set { this._MODE = value; }
    }

}

#endregion

#region SMHR_BONUS

public class smhr_Bonus_trans : SMHR_MAIN
{
    public int Bonus_Emp_ID { get; set; }
    public int Bonus_trans_ID { get; set; }
    public Boolean Bonus_Trans_checked { get; set; }
    public decimal Bonus_Percentage { get; set; }
    public int BONUS_BU_ID { get; set; }
    public int BONUS_PAYITEM_HEAD { get; set; }
    public int BONUS_PERIOD_ID { get; set; }
    public int BONUS_PERIOD_ELEMENTS { get; set; }
    public string CRITERIA { get; set; }
    public string BUSINESSUNIT { get; set; }
    public decimal BONUS_BONUSVALUE { get; set; }
    public int BONUS_COMMIT { get; set; }
    public int BONUS_FINALCOMMIT { get; set; }
    public int APPRCYCLE_ID { get; set; }
    public decimal BONUS_TOTALVALUE { get; set; }
    public decimal BONUS_EXGRATIA { get; set; }
    public int Bonus_org_id { get; set; }
    public int CREATED_BY { get; set; }
    public DateTime CREATED_DATE { get; set; }
    public int MODIFIED_BY { get; set; }
    public DateTime MODIFIED_DATE { get; set; }


}
public class SMHR_Upload
{
    public int BUSINESS_UNIT { get; set; }
    public string FILE_NAME { get; set; }
    public string FOLDER_NAME { get; set; }
    public int UPLOAD_ID { get; set; }
    public int ORG_ID { get; set; }
    public int MyProperty { get; set; }
}


public class SMHR_BONUSMASTER1 : SMHR_MAIN
{
    public int BONUS_ID { get; set; }
    public int PERIOD { get; set; }
    public int PERIOD_ELEMENTS { get; set; }
    public int BUSINESSUNIT { get; set; }
    public decimal RESTRICTION_AMOUNT { get; set; }
    public Boolean AMOUNT_CRITERIA { get; set; }
    public decimal MINIMUM_BONUS_PERCENTAGE { get; set; }
    public decimal MAXIMUM_BONUS_PERCENTAGE { get; set; }
    public int NUMBER_OF_DAYS { get; set; }
    public Boolean CRITERIA { get; set; }
    public int PAYITEM_HEAD { get; set; }
    public int BONUS_PAYITEM_ID { get; set; }
    public int BONUS_PAYITEM_BONUS_ID { get; set; }
    public int BONUS_PAYITEM_PAYITEMID { get; set; }
    public string BONUS_PAYITEM_TYPE { get; set; }
    public Boolean BONUS_PAYITEM_CHECKED { get; set; }
    public int bonus_trans_bu_id { get; set; }
    public int MODIFIED_BY { get; set; }
    public DateTime MODIFIED_DATE { get; set; }

}

#endregion

#region SMHR_DOCUMENT_UPLOAD

public class SMHR_UPLOAD : SMHR_MAIN
{
    public int BUSINESS_UNIT { get; set; }
    public string FILE_NAME { get; set; }
    public string FOLDER_NAME { get; set; }
    public int UPLOAD_ID { get; set; }
    public int ORG_ID { get; set; }
    public string FILE_TYPE { get; set; }
    public string FILE_PATH { get; set; }
    public Boolean NEW_FOLDER { get; set; }
    public int CREATED_BY { get; set; }

    private DateTime _UPLOAD_CREATEDDATE;
    public DateTime UPLOAD_CREATEDDATE
    {
        get { return (this._UPLOAD_CREATEDDATE); }
        set { this._UPLOAD_CREATEDDATE = value; }
    }

}

#endregion

#region SMHR_EMPTRANSFER
/// <summary>
/// To handle transfer information
/// </summary>
public class SMHR_EMPTRANSFER : SMHR_MAIN
{
    private int _TRANSFEREMP_ID;

    public int TRNASFEREMP_ID
    {
        get { return (this._TRANSFEREMP_ID); }
        set { this._TRANSFEREMP_ID = value; }
    }


    private int _EMP_period_id;

    public int EMP_period_id
    {
        get { return (this._EMP_period_id); }
        set { this._EMP_period_id = value; }
    }


    private int _EMP_EMPID;

    public int EMP_EMPID
    {
        get { return (this._EMP_EMPID); }
        set { this._EMP_EMPID = value; }
    }
    private int _EMP_DESIGNATION_ID;

    public int EMP_DESIGNATION_ID
    {
        get { return (this._EMP_DESIGNATION_ID); }
        set { this._EMP_DESIGNATION_ID = value; }
    }
    private int _EMP_REPORTINGEMPLOYEE;

    public int EMP_REPORTINGEMPLOYEE
    {
        get { return (this._EMP_REPORTINGEMPLOYEE); }
        set { this._EMP_REPORTINGEMPLOYEE = value; }
    }

    private DateTime? _EMP_REPORTINGEMPLOYEE_ENDDATE;

    public DateTime? EMP_REPORTINGEMPLOYEE_ENDDATE
    {
        get { return (this._EMP_REPORTINGEMPLOYEE_ENDDATE); }
        set { this._EMP_REPORTINGEMPLOYEE_ENDDATE = value; }
    }

    private int _EMP_SHIFT_ID;

    public int EMP_SHIFT_ID
    {
        get { return (this._EMP_SHIFT_ID); }
        set { this._EMP_SHIFT_ID = value; }
    }
    private int _EMP_LEAVEBALANCE;
    public int EMP_LEAVEBALANCE
    {
        get { return (this._EMP_LEAVEBALANCE); }
        set { this._EMP_LEAVEBALANCE = value; }
    }

    private int _EMP_SALALRYSTRUCT_ID;

    public int EMP_SALALRYSTRUCT_ID
    {
        get { return (this._EMP_SALALRYSTRUCT_ID); }
        set { this._EMP_SALALRYSTRUCT_ID = value; }
    }

    private int _EMP_LEAVESTRUCTS_ID;

    public int EMP_LEAVESTRUCTS_ID
    {
        get { return (this._EMP_LEAVESTRUCTS_ID); }
        set { this._EMP_LEAVESTRUCTS_ID = value; }
    }

    private int _EMP_LEAVESTRUCT_ID;

    public int EMP_LEAVESTRUCT_ID
    {
        get { return (this._EMP_LEAVESTRUCT_ID); }
        set { this._EMP_LEAVESTRUCT_ID = value; }
    }

    private int _EMP_ORG_ID;

    public int EMP_ORG_ID
    {
        get { return (this._EMP_ORG_ID); }
        set { this._EMP_ORG_ID = value; }
    }

    private string _EMP_OLDLEAVESTRUCT;

    public string EMP_OLDLEAVESTRUCT
    {
        get { return (this._EMP_OLDLEAVESTRUCT); }
        set { this._EMP_OLDLEAVESTRUCT = value; }
    }
    private string _EMP_OLDSALSTRUCT;

    public string EMP_OLDSALSTRUCT
    {
        get { return (this._EMP_OLDSALSTRUCT); }
        set { this._EMP_OLDSALSTRUCT = value; }
    }
    private string _EMP_OLDSHIFT;

    public string EMP_OLDSHIFT
    {
        get { return (this._EMP_OLDSHIFT); }
        set { this._EMP_OLDSHIFT = value; }
    }
    private string _EMP_OLDBU;

    public string EMP_OLDBU
    {
        get { return (this._EMP_OLDBU); }
        set { this._EMP_OLDBU = value; }
    }
    private int _EMP_DEPARTMENT_ID;

    public int EMP_DEPARTMENT_ID
    {
        get { return (this._EMP_DEPARTMENT_ID); }
        set { this._EMP_DEPARTMENT_ID = value; }
    }
    private string _EMP_OLDDEPARTMENT;

    public string EMP_OLDDEPARTMENT
    {
        get { return (this._EMP_OLDDEPARTMENT); }
        set { this._EMP_OLDDEPARTMENT = value; }
    }
    private string _EMP_OLDDESIGNATION;

    public string EMP_OLDDESIGNATION
    {
        get { return (this._EMP_OLDDESIGNATION); }
        set { this._EMP_OLDDESIGNATION = value; }
    }
    private string _EMP_OLDREPORTINGEMP;

    public string EMP_OLDREPORTINGEMP
    {
        get { return (this._EMP_OLDREPORTINGEMP); }
        set { this._EMP_OLDREPORTINGEMP = value; }
    }

    private DateTime? _EMP_EXECUTIONDATE;

    public DateTime? EMP_EXECUTIONDATE
    {
        get { return (this._EMP_EXECUTIONDATE); }
        set { this._EMP_EXECUTIONDATE = value; }
    }
    private DateTime? _EMP_DATEOFTRANSFER;

    public DateTime? EMP_DATEOFTRANSFER
    {
        get { return (this._EMP_DATEOFTRANSFER); }
        set { this._EMP_DATEOFTRANSFER = value; }
    }
    private Double _EMP_GROSSSAL;

    public Double EMP_GROSSSAL
    {
        get { return (this._EMP_GROSSSAL); }
        set { this._EMP_GROSSSAL = value; }
    }

    private double _EMP_BASIC;

    public double EMP_BASIC
    {
        get { return (this._EMP_BASIC); }
        set { this._EMP_BASIC = value; }
    }
    private int _EMP_CURR_ID;
    public int EMP_CURR_ID
    {
        get { return (this._EMP_CURR_ID); }
        set { this._EMP_CURR_ID = value; }
    }

    private string _EMP_PREVIOUS_CURRENCY;
    public string EMP_PREVIOUS_CURRENCY
    {
        get { return (this._EMP_PREVIOUS_CURRENCY); }
        set { this._EMP_PREVIOUS_CURRENCY = value; }
    }

    private Double _EMP_PREVIOUS_GROSS;

    public Double EMP_PREVIOUS_GROSS
    {
        get { return (this._EMP_PREVIOUS_GROSS); }
        set { this._EMP_PREVIOUS_GROSS = value; }
    }
    private int _EMP_PREVIOUS_CURRID;

    private int _PREVIOUS_PERIOD;
    public int PREVIOUS_PERIOD
    {
        get { return (this._PREVIOUS_PERIOD); }
        set { this._PREVIOUS_PERIOD = value; }
    }

    public int EMP_PREVIOUS_CURRID
    {
        get { return (this._EMP_PREVIOUS_CURRID); }
        set { this._EMP_PREVIOUS_CURRID = value; }
    }
    private double _EMP_PREVIOUS_BASIC;

    public double EMP_PREVIOUS_BASIC
    {
        get { return (this._EMP_PREVIOUS_BASIC); }
        set { this._EMP_PREVIOUS_BASIC = value; }
    }
    private double? _EMP_ANNUAL_BASIC;

    public double? EMP_ANNUAL_BASIC
    {
        get { return (this._EMP_ANNUAL_BASIC); }
        set { this._EMP_ANNUAL_BASIC = value; }
    }
    private double? _EMP_ANNUAL_GROSS;

    public double? EMP_ANNUAL_GROSS
    {
        get { return (this._EMP_ANNUAL_GROSS); }
        set { this._EMP_ANNUAL_GROSS = value; }
    }
    private bool _EMPCODE_CHECKED;

    public bool EMPCODE_CHECKED
    {
        get { return (this._EMPCODE_CHECKED); }
        set { this._EMPCODE_CHECKED = value; }
    }
    private string _EMP_EMPCODE;
    public string EMP_EMPCODE
    {
        get { return (this._EMP_EMPCODE); }
        set { this._EMP_EMPCODE = value; }
    }
    private string _PREV_EMP_EMPCODE;
    public string PREV_EMP_EMPCODE
    {
        get { return (this._PREV_EMP_EMPCODE); }
        set { this._PREV_EMP_EMPCODE = value; }
    }
    private int _EMP_SUPBUSINESSUNIT_ID;
    public int EMP_SUPBUSINESSUNIT_ID
    {
        get { return (this._EMP_SUPBUSINESSUNIT_ID); }
        set { this._EMP_SUPBUSINESSUNIT_ID = value; }
    }
    private int _EMP_CATEGORY_ID;

    public int EMP_CATEGORY_ID
    {
        get { return (this._EMP_CATEGORY_ID); }
        set { this._EMP_CATEGORY_ID = value; }
    }
    private int? _PREV_EMP_CATEGORY_ID;

    public int? PREV_EMP_CATEGORY_ID
    {
        get { return (this._PREV_EMP_CATEGORY_ID); }
        set { this._PREV_EMP_CATEGORY_ID = value; }
    }
    private int? _EMP_Directorate_ID;

    public int? EMP_Directorate_ID
    {
        get { return (this._EMP_Directorate_ID); }
        set { this._EMP_Directorate_ID = value; }
    }


    private int _EMP_GRADE;

    public int EMP_GRADE
    {
        get { return (this._EMP_GRADE); }
        set { this._EMP_GRADE = value; }
    }


    private int _EMP_SLAB_ID;

    public int EMP_SLAB_ID
    {
        get { return (this._EMP_SLAB_ID); }
        set { this._EMP_SLAB_ID = value; }
    }


    private int _PREVIOUS_EMP_GRADE;

    public int PREVIOUS_EMP_GRADE
    {
        get { return (this._PREVIOUS_EMP_GRADE); }
        set { this._PREVIOUS_EMP_GRADE = value; }
    }


    private int _PREVIOUS_EMP_SLAB_ID;

    public int PREVIOUS_EMP_SLAB_ID
    {
        get { return (this._PREVIOUS_EMP_SLAB_ID); }
        set { this._PREVIOUS_EMP_SLAB_ID = value; }
    }
    private int? _PREV_EMP_Directorate_ID;

    public int? PREV_EMP_Directorate_ID
    {
        get { return (this._PREV_EMP_Directorate_ID); }
        set { this._PREV_EMP_Directorate_ID = value; }
    }
}
#endregion

#region SMHR_GRATUITY
public class SMHR_GRATUITY : SMHR_MAIN
{
    private DateTime _SELECTED_PERIOD;
    public DateTime SELECTED_PERIOD
    {
        get { return _SELECTED_PERIOD; }
        set { this._SELECTED_PERIOD = value; }
    }
    private DateTime _EMP_DOJ;
    public DateTime EMP_DOJ
    {
        get { return _EMP_DOJ; }
        set { this._EMP_DOJ = value; }
    }
    private DateTime _EMP_PERIOD;
    public DateTime EMP_PERIOD
    {
        get { return _EMP_PERIOD; }
        set { this._EMP_PERIOD = value; }
    }
    private DateTime _EMP_COMPLETION;
    public DateTime EMP_COMPLETION
    {
        get { return _EMP_COMPLETION; }
        set { this._EMP_COMPLETION = value; }
    }
    private int _EMP_BUSINESSUNIT_ID;
    public int EMP_BUSINESSUNIT_ID
    {
        get { return _EMP_BUSINESSUNIT_ID; }
        set { this._EMP_BUSINESSUNIT_ID = value; }
    }
    private string _EMP_PAYITEM;
    public string EMP_PAYITEM
    {
        get { return _EMP_PAYITEM; }
        set { this._EMP_PAYITEM = value; }
    }
    private int _EMP_BUID;
    public int EMP_BUID
    {
        get { return _EMP_BUID; }
        set { this._EMP_BUID = value; }
    }
    private int _EMP_ID;
    public int EMP_ID
    {
        get { return _EMP_ID; }
        set { this._EMP_ID = value; }
    }
    private double _Emp_amount;
    public double Emp_amount
    {
        get { return _Emp_amount; }
        set { this._Emp_amount = value; }
    }
    private string _Emp_currency;
    public string Emp_currency
    {
        get { return _Emp_currency; }
        set { this._Emp_currency = value; }
    }

    private string _Emp_resgstatus;
    public string Emp_resgstatus
    {
        get { return _Emp_resgstatus; }
        set { this._Emp_resgstatus = value; }
    }

    private int _Emp_status;
    public int Emp_status
    {
        get { return _Emp_status; }
        set { this._Emp_status = value; }
    }

    private int _Emp_exp;
    public int Emp_exp
    {
        get { return _Emp_exp; }
        set { this._Emp_exp = value; }
    }

    private string _Emp_name;
    public string Emp_name
    {
        get { return _Emp_name; }
        set { this._Emp_name = value; }
    }

    private string _Emp_nominee;
    public string Emp_nominee
    {
        get { return _Emp_nominee; }
        set { this._Emp_nominee = value; }

    }
    private string _Emp_max;
    public string Emp_max
    {
        get { return _Emp_max; }
        set { this._Emp_max = value; }
    }

    private string _Emp_payableamount;
    public string Emp_payableamount
    {
        get { return _Emp_payableamount; }
        set { this._Emp_payableamount = value; }
    }
}

#endregion

#region SMHR_ARREARS

public class SMHR_ARREARS
{
    private int _SMHR_ARR_ID;
    public int SMHR_ARR_ID
    {
        get { return (this._SMHR_ARR_ID); }
        set { this._SMHR_ARR_ID = value; }
    }

    private int _SMHR_ARR_ORG_ID;
    public int SMHR_ARR_ORG_ID
    {
        get { return (this._SMHR_ARR_ORG_ID); }
        set { this._SMHR_ARR_ORG_ID = value; }
    }

    private int _SMHR_ARR_BUID;
    public int SMHR_ARR_BUID
    {
        get { return (this._SMHR_ARR_BUID); }
        set { this._SMHR_ARR_BUID = value; }
    }

    private int _SMHR_ARR_PERIOD;
    public int SMHR_ARR_PERIOD
    {
        get { return (this._SMHR_ARR_PERIOD); }
        set { this._SMHR_ARR_PERIOD = value; }
    }

    private int _SMHR_ARR_WEF;
    public int SMHR_ARR_WEF
    {
        get { return (this._SMHR_ARR_WEF); }
        set { this._SMHR_ARR_WEF = value; }
    }

    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }
    private int _SMHR_ARR_TO_PERIODELEMENT;

    public int SMHR_ARR_TO_PERIODELEMENT
    {
        get { return _SMHR_ARR_TO_PERIODELEMENT; }
        set { _SMHR_ARR_TO_PERIODELEMENT = value; }
    }
    private int _SMHR_ARR_FROM_PERIODELEMENT;

    public int SMHR_ARR_FROM_PERIODELEMENT
    {
        get { return _SMHR_ARR_FROM_PERIODELEMENT; }
        set { _SMHR_ARR_FROM_PERIODELEMENT = value; }
    }

    private int _SMHR_ARR_STATUS;

    public int SMHR_ARR_STATUS
    {
        get { return _SMHR_ARR_STATUS; }
        set { _SMHR_ARR_STATUS = value; }
    }
    private int _SMHR_ARR_SALSTRUCT;

    public int SMHR_ARR_SALSTRUCT
    {
        get { return _SMHR_ARR_SALSTRUCT; }
        set { _SMHR_ARR_SALSTRUCT = value; }
    }
    public string ACTUALGIVENPERIODS { get; set; }



}

#endregion

#region SMHR_ARREARS_DETAILS

public class SMHR_ARREARS_DETAILS : SMHR_ARREARS
{
    private int _SMHR_ARR_DTL_ID;
    public int SMHR_ARR_DTL_ID
    {
        get { return (this._SMHR_ARR_DTL_ID); }
        set { this._SMHR_ARR_DTL_ID = value; }
    }

    private int _SMHR_ARR_ID;
    public int SMHR_ARR_ID
    {
        get { return (this._SMHR_ARR_ID); }
        set { this._SMHR_ARR_ID = value; }
    }

    private int _SMHR_ARR_EMP_ID;
    public int SMHR_ARR_EMP_ID
    {
        get { return (this._SMHR_ARR_EMP_ID); }
        set { this._SMHR_ARR_EMP_ID = value; }
    }

    private double _SMHR_ARR_EMP_PRESENT_GS;
    public double SMHR_ARR_EMP_PRESENT_GS
    {
        get { return (this._SMHR_ARR_EMP_PRESENT_GS); }
        set { this._SMHR_ARR_EMP_PRESENT_GS = value; }
    }

    private string _SMHR_ARR_EMP_ARR_TYPE;
    public string SMHR_ARR_EMP_ARR_TYPE
    {
        get { return (this._SMHR_ARR_EMP_ARR_TYPE); }
        set { this._SMHR_ARR_EMP_ARR_TYPE = value; }
    }

    private double _SMHR_ARR_EMP_ARR_VALUE;
    public double SMHR_ARR_EMP_ARR_VALUE
    {
        get { return (this._SMHR_ARR_EMP_ARR_VALUE); }
        set { this._SMHR_ARR_EMP_ARR_VALUE = value; }
    }

    private double _SMHR_ARR_EMP_NEW_GS;
    public double SMHR_ARR_EMP_NEW_GS
    {
        get { return (this._SMHR_ARR_EMP_NEW_GS); }
        set { this._SMHR_ARR_EMP_NEW_GS = value; }
    }

    private int _SMHR_ARR_CREATEDBY;
    public int SMHR_ARR_CREATEDBY
    {
        get { return (this._SMHR_ARR_CREATEDBY); }
        set { this._SMHR_ARR_CREATEDBY = value; }
    }

    private DateTime _SMHR_ARR_CREATEDDATE;
    public DateTime SMHR_ARR_CREATEDDATE
    {
        get { return (this._SMHR_ARR_CREATEDDATE); }
        set { this._SMHR_ARR_CREATEDDATE = value; }
    }

    private int _SMHR_ARR_STATUS;
    public int SMHR_ARR_STATUS
    {
        get { return (this._SMHR_ARR_STATUS); }
        set { this._SMHR_ARR_STATUS = value; }
    }

    private double _SMHR_ARR_PAY;
    public double SMHR_ARR_PAY
    {
        get { return (this._SMHR_ARR_PAY); }
        set { this._SMHR_ARR_PAY = value; }
    }


}
#endregion

#region SMHR_LOANREQUEST

public class SMHR_LOANREQUEST : SMHR_MAIN
{
    public SMHR_LOANREQUEST()
    {
    }

    private int _SMHR_LOANREQUEST_ID;

    public int SMHR_LOANREQUEST_ID
    {
        get
        {
            return _SMHR_LOANREQUEST_ID;
        }
        set
        {
            _SMHR_LOANREQUEST_ID = value;
        }
    }

    private int? _BUSINESSUNIT_ID;
    public int? BUSINESSUNIT_ID
    {
        get { return this._BUSINESSUNIT_ID; }
        set { this._BUSINESSUNIT_ID = value; }
    }
    private double _AMOUNT;
    public double AMOUNT
    {
        get { return (this._AMOUNT); }
        set { this._AMOUNT = value; }
    }
    private DateTime _APPLIEDDATE;
    public DateTime APPLIEDDATE
    {
        get { return (this._APPLIEDDATE); }
        set { this._APPLIEDDATE = value; }
    }
    private DateTime _APPROVEDDATE;
    public DateTime APPROVEDDATE
    {
        get { return (this._APPROVEDDATE); }
        set { this._APPROVEDDATE = value; }
    }
    private int _APPLIEDBY;
    public int APPLIEDBY
    {
        get { return (this._APPLIEDBY); }
        set { this._APPLIEDBY = value; }
    }

    private int _APPROVEDBY;
    public int APPROVEDBY
    {
        get { return (this._APPROVEDBY); }
        set { this._APPROVEDBY = value; }
    }

    private int _MODIFIEDBY;
    public int MODIFIEDBY
    {
        get { return (this._MODIFIEDBY); }
        set { this._MODIFIEDBY = value; }
    }


    private DateTime _MODIFIEDDATE;
    public DateTime MODIFIEDDATE
    {
        get { return (this._MODIFIEDDATE); }
        set { this._MODIFIEDDATE = value; }
    }



    private int _LoanMode;
    public int LoanMode
    {
        get { return (this._LoanMode); }
        set { this._LoanMode = value; }
    }
    private int _LOANTYPE;
    public int LOANTYPE
    {
        get { return (this._LOANTYPE); }
        set { this._LOANTYPE = value; }
    }
    private string _LOAN_PROCESS_TYPE;
    public string LOAN_PROCESS_TYPE
    {
        get { return (this._LOAN_PROCESS_TYPE); }
        set { this._LOAN_PROCESS_TYPE = value; }
    }
    private int _STATUS;
    public int STATUS
    {
        get { return (this._STATUS); }
        set { this._STATUS = value; }
    }
    private int _LEVEL1;
    public int LEVEL1
    {
        get { return (this._LEVEL1); }
        set { this._LEVEL1 = value; }
    }
    private int _LEVEL2;
    public int LEVEL2
    {
        get { return (this._LEVEL2); }
        set { this._LEVEL2 = value; }
    }
    private double _NOOFINSTALLMENTS;
    public double NOOFINSTALLMENTS
    {
        get { return (this._NOOFINSTALLMENTS); }
        set { this._NOOFINSTALLMENTS = value; }
    }
    private string _status_type;
    public string status_type
    {
        get { return (this._status_type); }
        set { this._status_type = value; }
    }
    private int _status_type_id;
    public int status_type_id
    {
        get { return (this._status_type_id); }
        set { this._status_type_id = value; }
    }


    private int _lOANREQUEST_EMPLOYEEID;
    public int lOANREQUEST_EMPLOYEEID
    {
        get { return (this._lOANREQUEST_EMPLOYEEID); }
        set { this._lOANREQUEST_EMPLOYEEID = value; }
    }

    private int _LOANREQUEST_ORGANISATION_ID;
    public int LOANREQUEST_ORGANISATION_ID
    {
        get
        {
            return (this._LOANREQUEST_ORGANISATION_ID);
        }
        set
        {
            this._LOANREQUEST_ORGANISATION_ID = value;
        }
    }
    private int _ERROR_LOG_ID;
    public int ERROR_LOG_ID
    {
        get
        {
            return (this._ERROR_LOG_ID);
        }
        set
        {
            this._ERROR_LOG_ID = value;
        }
    }

    private string _LOANREQUEST_VALUATIONDOC;

    public string LOANREQUEST_VALUATIONDOC
    {
        get { return _LOANREQUEST_VALUATIONDOC; }
        set { _LOANREQUEST_VALUATIONDOC = value; }
    }
    private string _LOANNAME;

    public string LOANNAME
    {
        get { return _LOANNAME; }
        set { _LOANNAME = value; }
    }

    private string _PARENT_LOANNO;
    public string PARENT_LOANNO
    {
        get { return _PARENT_LOANNO; }
        set { _PARENT_LOANNO = value; }
    }
    private DataTable _LOANVOUCHER;
    public DataTable LOANVOUCHER
    {
        get { return _LOANVOUCHER; }
        set { _LOANVOUCHER = value; }
    }
    private DataTable _USERLOANEMI;
    public DataTable USERLOANEMI
    {
        get { return _USERLOANEMI; }
        set { _USERLOANEMI = value; }
    }
}

#endregion

#region MAPPINGPAYITEMS
public class SMHR_MAPING_REFERPAYITEM
{

    public int ID { get; set; }
    public int PAYITEMREFERID { get; set; }
    public int ORGPAYITEM_ID { get; set; }
    public int BUSINESSUNIT_ID { get; set; }
    public int ORGANISATION_ID { get; set; }
    public int STATUS { get; set; }

    public int MP_CREATEDBY { get; set; }
    public DateTime MP_CREATEDDATE { get; set; }
    public int MP_LSTMDFBY { get; set; }
    public DateTime MP_LSTMDFDATE { get; set; }

    private operation _OPERATION;

    public operation OPERATION
    {
        get { return (this._OPERATION); }
        set { this._OPERATION = value; }
    }
}

public class SMHR_PAYROLL_REFEREPAYTYPE
{
    private operation _OPERATION;
    public operation OPERATION
    {
        get { return (this._OPERATION); }
        set { this._OPERATION = value; }
    }
    public int ORG_ID { get; set; }
}
#endregion

#region _get_1259735
public class SMHR_get_1259735 : SMHR_MAIN
{
    private operation _OPERATION;
    public operation OPERATION
    {
        get { return (this._OPERATION); }
        set { this._OPERATION = value; }
    }
}
#endregion

#region TDS
public class SMHR_TDS : SMHR_MAIN
{
    private int _TDS_ID;
    public int TDS_ID
    {
        get { return (this._TDS_ID); }
        set { this._TDS_ID = value; }
    }

    private string _TDS_NAME;
    public string TDS_NAME
    {
        get { return (this._TDS_NAME); }
        set { this._TDS_NAME = value; }
    }

    private string _TDS_DESC;
    public string TDS_DESC
    {
        get { return (this._TDS_DESC); }
        set { this._TDS_DESC = value; }
    }

    private int _TDS_CREATEDBY;
    public int TDS_CREATEDBY
    {
        get { return (this._TDS_CREATEDBY); }
        set { this._TDS_CREATEDBY = value; }
    }
    private int _TDS_LOCALISATION_ID;
    public int TDS_LOCALISATION_ID
    {
        get { return (this._TDS_LOCALISATION_ID); }
        set { this._TDS_LOCALISATION_ID = value; }
    }

    private DateTime _TDS_CREATEDDATE;
    public DateTime TDS_CREATEDDATE
    {
        get { return (this._TDS_CREATEDDATE); }
        set { this._TDS_CREATEDDATE = value; }
    }

    private int _TDS_MODIFIEDBY;
    public int TDS_MODIFIEDBY
    {
        get { return (this._TDS_MODIFIEDBY); }
        set { this._TDS_MODIFIEDBY = value; }
    }

    private DateTime _TDS_MODIFIEDDATE;
    public DateTime TDS_MODIFIEDDATE
    {
        get { return (this._TDS_MODIFIEDDATE); }
        set { this._TDS_MODIFIEDDATE = value; }
    }

    private int _TDS_BUSINESSUNIT;
    public int TDS_BUSINESSUNIT
    {
        get { return (this._TDS_BUSINESSUNIT); }
        set { this._TDS_BUSINESSUNIT = value; }
    }

    private Boolean _TDS_STATUS;
    public Boolean TDS_STATUS
    {
        get { return (this._TDS_STATUS); }
        set { this._TDS_STATUS = value; }
    }
}
#endregion

#region TdsSlab

public class SMHR_TDS_SLAB : SMHR_MAIN
{
    private int _TDS_SLAB_ID;
    public int TDS_SLAB_ID
    {
        get { return (this._TDS_SLAB_ID); }
        set { this._TDS_SLAB_ID = value; }
    }

    private int _TDS_SLAB_TDS_ID;
    public int TDS_SLAB_TDS_ID
    {
        get { return (this._TDS_SLAB_TDS_ID); }
        set { this._TDS_SLAB_TDS_ID = value; }
    }

    private string _TDS_SLAB_NAME;
    public string TDS_SLAB_NAME
    {
        get { return (this._TDS_SLAB_NAME); }
        set { this._TDS_SLAB_NAME = value; }
    }

    private string _TDS_SLAB_DESC;
    public string TDS_SLAB_DESC
    {
        get { return (this._TDS_SLAB_DESC); }
        set { this._TDS_SLAB_DESC = value; }
    }

    private int _TDS_SLAB_LOCALISATION_ID;
    public int TDS_SLAB_LOCALISATION_ID
    {
        get { return (this._TDS_SLAB_LOCALISATION_ID); }
        set { this._TDS_SLAB_LOCALISATION_ID = value; }
    }

    private int _TDS_SLAB_BUSINESSUNIT_ID;
    public int TDS_SLAB_BUSINESSUNIT_ID
    {
        get { return (this._TDS_SLAB_BUSINESSUNIT_ID); }
        set { this._TDS_SLAB_BUSINESSUNIT_ID = value; }
    }

    private int _TDS_SLAB_ORGANISATION_ID;
    public int TDS_SLAB_ORGANISATION_ID
    {
        get { return (this._TDS_SLAB_ORGANISATION_ID); }
        set { this._TDS_SLAB_ORGANISATION_ID = value; }
    }

    public int TDS_SLAB_HR_ID { get; set; }
}
#endregion

#region SMHR_TDS_PARAMS
public class SMHR_TDS_PARAMS : SMHR_MAIN
{
    private int _TDS_PARAMS_ID;
    public int TDS_PARAMS_ID
    {
        get { return (this._TDS_PARAMS_ID); }
        set { this._TDS_PARAMS_ID = value; }
    }

    private int _TDS_PARAMS_SLAB_ID;
    public int TDS_PARAMS_SLAB_ID
    {
        get { return (this._TDS_PARAMS_SLAB_ID); }
        set { this._TDS_PARAMS_SLAB_ID = value; }
    }

    private float _TDS_PARAMS_FROMVAL;
    public float TDS_PARAMS_FROMVAL
    {
        get { return (this._TDS_PARAMS_FROMVAL); }
        set { this._TDS_PARAMS_FROMVAL = value; }
    }

    private float _TDS_PARAMS_TOVAL;
    public float TDS_PARAMS_TOVAL
    {
        get { return (this._TDS_PARAMS_TOVAL); }
        set { this._TDS_PARAMS_TOVAL = value; }
    }

    private float _TDS_PARAMS_VALUE;
    public float TDS_PARAMS_VALUE
    {
        get { return (this._TDS_PARAMS_VALUE); }
        set { this._TDS_PARAMS_VALUE = value; }
    }

    private float _TDS_PARAMS_PERCENT;
    public float TDS_PARAMS_PERCENT
    {
        get { return (this._TDS_PARAMS_PERCENT); }
        set { this._TDS_PARAMS_PERCENT = value; }
    }

    private int _TDS_PARAMS_PERIOD_ID;
    public int TDS_PARAMS_PERIOD_ID
    {
        get { return (this._TDS_PARAMS_PERIOD_ID); }
        set { this._TDS_PARAMS_PERIOD_ID = value; }
    }
    private int _TDS_PARAMS_TDS_ID;
    public int TDS_PARAMS_TDS_ID
    {
        get { return (this._TDS_PARAMS_TDS_ID); }
        set { this._TDS_PARAMS_TDS_ID = value; }
    }

    private int _TDS_PARAMS_CURRENTPERIOD_ID;
    public int TDS_PARAMS_CURRENTPERIOD_ID
    {
        get { return (this._TDS_PARAMS_CURRENTPERIOD_ID); }
        set { this._TDS_PARAMS_CURRENTPERIOD_ID = value; }
    }
}
#endregion

#region SMHR_VARIABLEAMT

public class SMHR_VARIABLEAMT : SMHR_EMPLOYEE
{
    private int _emp_id;
    public int emp_id
    {
        get { return this._emp_id; }
        set { this._emp_id = value; }
    }
    private int _user_id;
    public int user_id
    {
        get { return this._user_id; }
        set { this._user_id = value; }
    }

    private string _selected_period;
    public string selected_period
    {
        get { return this._selected_period; }
        set { this._selected_period = value; }
    }

    private int _financial_period;
    public int financial_period
    {
        get { return this._financial_period; }
        set { this._financial_period = value; }
    }

    private double _percentage;
    public double percentage
    {
        get { return this._percentage; }
        set { this._percentage = value; }
    }

    private int _emp_countva;
    public int emp_countva
    {
        get { return this._emp_countva; }
        set { this._emp_countva = value; }
    }

    private int _emp_period;
    public int emp_period
    {
        get { return this._emp_period; }
        set { this._emp_period = value; }
    }

    private int _emp_checkedperiod;
    public int emp_checkedperiod
    {
        get { return this._emp_checkedperiod; }
        set { this._emp_checkedperiod = value; }
    }

    private double _emp_va;
    public double emp_va
    {
        get { return this._emp_va; }
        set { this._emp_va = value; }
    }
    private bool _emp_status;
    public bool emp_status
    {
        get { return this._emp_status; }
        set { this._emp_status = value; }
    }
    private bool _emp_isfinalised;
    public bool emp_isfinalised
    {
        get { return this._emp_isfinalised; }
        set { this._emp_isfinalised = value; }
    }
    private string _component_name;
    public string component_name
    {
        get { return this._component_name; }
        set { this._component_name = value; }
    }

    private string _component_desc;
    public string component_desc
    {
        get { return this._component_desc; }
        set { this._component_desc = value; }
    }
    private double _component_min;
    public double component_min
    {
        get { return this._component_min; }
        set { this._component_min = value; }
    }
    private double _component_max;
    public double component_max
    {
        get { return this._component_max; }
        set { this._component_max = value; }
    }
    private bool _component_status;
    public bool component_status
    {
        get { return this._component_status; }
        set { this._component_status = value; }
    }
    private int _component_id;
    public int component_id
    {
        get { return this._component_id; }
        set { this._component_id = value; }
    }
    private double _component_percentage;
    public double component_percentage
    {
        get { return this._component_percentage; }
        set { this._component_percentage = value; }
    }
}

#endregion

#region SMHR_JOBOFFERS
public class SMHR_JOBOFFERS : SPMS_MAIN
{
    private int _JOBOFFRS_ID;
    public int JOBOFFRS_ID
    {
        get { return (this._JOBOFFRS_ID); }
        set { this._JOBOFFRS_ID = value; }
    }
    private int _JOBOFFRS_REQCODE;
    public int JOBOFFRS_REQCODE
    {
        get { return (this._JOBOFFRS_REQCODE); }
        set { this._JOBOFFRS_REQCODE = value; }
    }
    private int _JOBOFFRS_APPLICANT_ID;
    public int JOBOFFRS_APPLICANT_ID
    {
        get { return (this._JOBOFFRS_APPLICANT_ID); }
        set { this._JOBOFFRS_APPLICANT_ID = value; }
    }
    private DateTime _JOBOFFRS_OFFERDATE;
    public DateTime JOBOFFRS_OFFERDATE
    {
        get { return (this._JOBOFFRS_OFFERDATE); }
        set { this._JOBOFFRS_OFFERDATE = value; }
    }
    private DateTime _JOBOFFRS_JOINDATE;
    public DateTime JOBOFFRS_JOINDATE
    {
        get { return (this._JOBOFFRS_JOINDATE); }
        set { this._JOBOFFRS_JOINDATE = value; }
    }
    private DateTime _JOBOFFRS_CREATEDDATE;
    public DateTime JOBOFFRS_CREATEDATE
    {
        get { return (this._JOBOFFRS_CREATEDDATE); }
        set { this._JOBOFFRS_CREATEDDATE = value; }
    }
    private DateTime _JOBOFFRS_LASTMDFDATE;
    public DateTime JOBOFFRS_LASTMDFDATE
    {
        get { return (this._JOBOFFRS_LASTMDFDATE); }
        set { this._JOBOFFRS_LASTMDFDATE = value; }
    }
    private int _JOBOFFRS_CREATEDBY;
    public int JOBOFFRS_CREATEDBY
    {
        get { return (this._JOBOFFRS_CREATEDBY); }
        set { this._JOBOFFRS_CREATEDBY = value; }
    }

    private int _MODE;
    public int MODE
    {
        get { return (this._MODE); }
        set { this._MODE = value; }
    }
    private int _JOBOFFRS_LASTMDFBY;
    public int JOBOFFRS_LASTMDFBY
    {
        get { return (this._JOBOFFRS_LASTMDFBY); }
        set { this._JOBOFFRS_LASTMDFBY = value; }
    }
    private int _JOBOFFRS_SALSTRUCT;
    public int JOBOFFRS_SALSTRUCT
    {
        get { return (this._JOBOFFRS_SALSTRUCT); }
        set { this._JOBOFFRS_SALSTRUCT = value; }
    }
    private int _JOBOFFRS_LEAVESTRUCT;
    public int JOBOFFRS_LEAVESTRUCT
    {
        get { return (this._JOBOFFRS_LEAVESTRUCT); }
        set { this._JOBOFFRS_LEAVESTRUCT = value; }
    }
    private Decimal _JOBOFFRS_OFFERSAL;
    public Decimal JOBOFFRS_OFFERSAL
    {
        get { return (this._JOBOFFRS_OFFERSAL); }
        set { this._JOBOFFRS_OFFERSAL = value; }
    }
    private int _APPLICANT_ID;
    public int APPLICANT_ID
    {
        get { return (this._APPLICANT_ID); }
        set { this._APPLICANT_ID = value; }
    }
    private string _APPLICANT_CODE;
    public string APPLICANT_CODE
    {
        get { return (this._APPLICANT_CODE); }

        set { this._APPLICANT_CODE = value; }
    }



}
#endregion
#region SMHR_INTERVIEW_PRIORITY

public class SMHR_INTERVIEW_PRIORITY
{
    public SMHR_INTERVIEW_PRIORITY(int __PRIORITY_ID)
    {
        this._PRIORITY_ID = __PRIORITY_ID;
    }

    public SMHR_INTERVIEW_PRIORITY()
    { }

    private int _PRIORITY_ID;
    public int PRIORITY_ID
    {
        get { return _PRIORITY_ID; }
        set { _PRIORITY_ID = value; }
    }

    private int _PRIORITY_VALUE;
    public int PRIORITY_VALUE
    {
        get { return _PRIORITY_VALUE; }
        set { _PRIORITY_VALUE = value; }
    }

    private int _MODE;
    public int MODE
    {
        get { return _MODE; }
        set { _MODE = value; }
    }

    private int _PRIORITY_ORGANIZATIONID;
    public int PRIORITY_ORGANIZATIONID
    {
        get { return _PRIORITY_ORGANIZATIONID; }
        set { _PRIORITY_ORGANIZATIONID = value; }
    }

}
#endregion

#region SMHR_INTERVIEW_PHASE_DEF

public class SMHR_INTERVIEW_PHASE_DEF
{

    public SMHR_INTERVIEW_PHASE_DEF(int __Phase_ID)
    {
        this._Phase_ID = __Phase_ID;
    }
    public SMHR_INTERVIEW_PHASE_DEF()
    { }

    private int _Phase_ID;
    public int Phase_ID
    {
        get { return _Phase_ID; }
        set { _Phase_ID = value; }
    }

    private int _Phase_JobReqID;
    public int Phase_JobReqID
    {
        get { return _Phase_JobReqID; }
        set { _Phase_JobReqID = value; }
    }

    private string _Phase_Name;
    public string Phase_Name
    {
        get { return _Phase_Name; }
        set { _Phase_Name = value; }
    }

    private DateTime _Phase_InterviewDate;
    public DateTime Phase_InterviewDate
    {
        get { return _Phase_InterviewDate; }
        set { _Phase_InterviewDate = value; }
    }


    private string _Phase_Desc;
    public string Phase_Desc
    {
        get { return _Phase_Desc; }
        set { _Phase_Desc = value; }
    }

    private int _Phase_Createdby;
    public int Phase_Createdby
    {
        get { return _Phase_Createdby; }
        set { _Phase_Createdby = value; }
    }

    private DateTime _Phase_CreatedDate;
    public DateTime Phase_CreatedDate
    {
        get { return _Phase_CreatedDate; }
        set { _Phase_CreatedDate = value; }
    }

    private int _Phase_LastMdfBy;
    public int Phase_LastMdfBy
    {
        get { return _Phase_LastMdfBy; }
        set { _Phase_LastMdfBy = value; }
    }

    private DateTime _Phase_LastMdfdate;
    public DateTime Phase_LastMdfdate
    {
        get { return _Phase_LastMdfdate; }
        set { _Phase_LastMdfdate = value; }
    }

    private int _Mode;
    public int Mode
    {
        get { return _Mode; }
        set { _Mode = value; }
    }

    private int _Applicant;
    public int Applicant
    {
        get { return _Applicant; }
        set { _Applicant = value; }
    }

    private int _PHASE_SKILL;
    public int PHASE_SKILL
    {
        get { return _PHASE_SKILL; }
        set { _PHASE_SKILL = value; }
    }

    private bool _PHASE_FINAL;
    public bool PHASE_FINAL
    {
        get { return _PHASE_FINAL; }
        set { _PHASE_FINAL = value; }
    }

    private int _PHASE_BUSINESSUNIT;
    public int PHASE_BUSINESSUNIT
    {
        get { return _PHASE_BUSINESSUNIT; }
        set { _PHASE_BUSINESSUNIT = value; }
    }

    private int _PHASE_INTERVIEWERNAME;
    public int PHASE_INTERVIEWERNAME
    {
        get { return _PHASE_INTERVIEWERNAME; }
        set { _PHASE_INTERVIEWERNAME = value; }
    }

    private int _PHASE_PRIORITY;
    public int PHASE_PRIORITY
    {
        get { return _PHASE_PRIORITY; }
        set { _PHASE_PRIORITY = value; }
    }

    private int _PHASE_GRADESET;
    public int PHASE_GRADESET
    {
        get { return _PHASE_GRADESET; }
        set { _PHASE_GRADESET = value; }
    }

    private int _PHASE_ORGANISATION_ID;
    public int PHASE_ORGANISATION_ID
    {
        get { return _PHASE_ORGANISATION_ID; }
        set { _PHASE_ORGANISATION_ID = value; }
    }

}


#endregion

#region SMHR_SKILLSCATEGARY
public class SMHR_SKILLSCATEGARY : SMHR_MAIN
{
    private int _SKILLCAT_ID;
    public int SKILLCAT_ID
    {
        get { return (this._SKILLCAT_ID); }
        set { this._SKILLCAT_ID = value; }

    }
    private int _SKILLCAT_SKILLID;
    public int SKILLCAT_SKILLID
    {
        get { return (this._SKILLCAT_SKILLID); }
        set { this._SKILLCAT_SKILLID = value; }

    }
    private int _PHASE_ID;
    public int PHASE_ID
    {
        get { return (this._PHASE_ID); }
        set { this._PHASE_ID = value; }

    }

    private string _SKILLCAT_NAME;
    public string SKILLCAT_NAME
    {
        get { return (this._SKILLCAT_NAME); }
        set { this._SKILLCAT_NAME = value; }
    }
    private string _SKILLCAT_DESCRIPTION;
    public string SKILLCAT_DESCRIPTION
    {
        get { return (this._SKILLCAT_DESCRIPTION); }
        set { this._SKILLCAT_DESCRIPTION = value; }
    }

}
#endregion

#region SMHR_APPLICANTGRADE

public class SMHR_APPLICANTGRADE : SMHR_MAIN
{
    public SMHR_APPLICANTGRADE(int __APPLGRADE_ID)
    {
        this._APPLGRADE_ID = __APPLGRADE_ID;
    }

    public SMHR_APPLICANTGRADE()
    { }

    private int _APPLGRADE_ID;
    public int APPLGRADE_ID
    {
        get { return _APPLGRADE_ID; }
        set { _APPLGRADE_ID = value; }
    }

    private int _APPGRADE_SETID;
    public int APPGRADE_SETID
    {
        get { return _APPGRADE_SETID; }
        set { _APPGRADE_SETID = value; }
    }

    private string _APPGRADE_NAME;
    public string APPGRADE_NAME
    {
        get { return _APPGRADE_NAME; }
        set { _APPGRADE_NAME = value; }
    }

    private string _APPLGRADE_DESCRIPTION;
    public string APPLGRADE_DESCRIPTION
    {
        get { return _APPLGRADE_DESCRIPTION; }
        set { _APPLGRADE_DESCRIPTION = value; }
    }

    private int _APPLGRADE_CREATEDBY;
    public int APPLGRADE_CREATEDBY
    {
        get { return _APPLGRADE_CREATEDBY; }
        set { _APPLGRADE_CREATEDBY = value; }
    }

    private DateTime _APPLGRADE_CREADTEDATE;
    public DateTime APPLGRADE_CREADTEDATE
    {
        get { return _APPLGRADE_CREADTEDATE; }
        set { _APPLGRADE_CREADTEDATE = value; }
    }

    private int _APPLGRADE_LASTMDFBY;
    public int APPLGRADE_LASTMDFBY
    {
        get { return _APPLGRADE_LASTMDFBY; }
        set { _APPLGRADE_LASTMDFBY = value; }
    }

    private DateTime _APPLGRADE_LASTMDFDATE;
    public DateTime APPLGRADE_LASTMDFDATE
    {
        get { return _APPLGRADE_LASTMDFDATE; }
        set { _APPLGRADE_LASTMDFDATE = value; }
    }

    private int _APPLGRADE_ORGANISATION_ID;
    public int APPLGRADE_ORGANISATION_ID
    {
        get { return _APPLGRADE_ORGANISATION_ID; }
        set { _APPLGRADE_ORGANISATION_ID = value; }
    }

    private int _MODE;
    public int MODE
    {
        get { return _MODE; }
        set { _MODE = value; }
    }
}
#endregion

#region SMHR_INTERVIEWASSESSMENTFORM
public class SMHR_INTERVIEWASSESSMENTFORM
{
    public SMHR_INTERVIEWASSESSMENTFORM(int __IAF_ID)
    {
        this._IAF_ID = __IAF_ID;
    }

    public SMHR_INTERVIEWASSESSMENTFORM()
    { }

    private int _IAF_ID;
    public int IAF_ID
    {
        get { return _IAF_ID; }
        set { _IAF_ID = value; }
    }

    private int _IAF_APPLID;
    public int IAF_APPLID
    {
        get { return _IAF_APPLID; }
        set { _IAF_APPLID = value; }
    }

    private int _IAF_JOBREID;
    public int IAF_JOBREID
    {
        get { return _IAF_JOBREID; }
        set { _IAF_JOBREID = value; }
    }

    private int _IAF_SKILLCAT_ID;
    public int IAF_SKILLCAT_ID
    {
        get { return _IAF_SKILLCAT_ID; }
        set { _IAF_SKILLCAT_ID = value; }
    }

    private int _IAF_APPLGRADE_ID;
    public int IAF_APPLGRADE_ID
    {
        get { return _IAF_APPLGRADE_ID; }
        set { _IAF_APPLGRADE_ID = value; }
    }

    private string _IAF_ADDLCOMMENTS;
    public string IAF_ADDLCOMMENTS
    {
        get { return _IAF_ADDLCOMMENTS; }
        set { _IAF_ADDLCOMMENTS = value; }
    }

    private int _IAF_APPROVE;
    public int IAF_APPROVE
    {
        get { return _IAF_APPROVE; }
        set { _IAF_APPROVE = value; }
    }

    private DateTime _IAF_DATE;
    public DateTime IAF_DATE
    {
        get { return _IAF_DATE; }
        set { _IAF_DATE = value; }
    }

    private int _IAF_PHASEDEFID;
    public int IAF_PHASEDEFID
    {
        get { return _IAF_PHASEDEFID; }
        set { _IAF_PHASEDEFID = value; }
    }

    private int _IAF_ORGANISATION_ID;
    public int IAF_ORGANISATION_ID
    {
        get { return _IAF_ORGANISATION_ID; }
        set { _IAF_ORGANISATION_ID = value; }
    }

    private int _IAF_CREATEDBY;
    public int IAF_CREATEDBY
    {
        get { return _IAF_CREATEDBY; }
        set { _IAF_CREATEDBY = value; }
    }

    private DateTime _IAF_CREATEDDATE;
    public DateTime IAF_CREATEDDATE
    {
        get { return _IAF_CREATEDDATE; }
        set { _IAF_CREATEDDATE = value; }
    }

    private int _IAF_LASTMDFBY;
    public int IAF_LASTMDFBY
    {
        get { return _IAF_LASTMDFBY; }
        set { _IAF_LASTMDFBY = value; }
    }

    private DateTime _IAF_LASTMDFDATE;
    public DateTime IAF_LASTMDFDATE
    {
        get { return _IAF_LASTMDFDATE; }
        set { _IAF_LASTMDFDATE = value; }
    }

    private int _MODE;
    public int MODE
    {
        get { return _MODE; }
        set { _MODE = value; }
    }
}
#endregion

#region SMHR_INTERVIEW_PHASE_REMARKS

public class SMHR_INTERVIEW_PHASE_REMARKS : SMHR_MAIN
{
    public SMHR_INTERVIEW_PHASE_REMARKS(int __INTREM_ID)
    {
        this._INTREM_ID = __INTREM_ID;
    }

    public SMHR_INTERVIEW_PHASE_REMARKS()
    { }

    private int _INTREM_ID;
    public int INTREM_ID
    {
        get { return _INTREM_ID; }
        set { _INTREM_ID = value; }
    }

    private int _INTREM_JOBREQID;
    public int INTREM_JOBREQID
    {
        get { return _INTREM_JOBREQID; }
        set { _INTREM_JOBREQID = value; }
    }

    private int _INTREM_PHASEID;
    public int INTREM_PHASEID
    {
        get { return _INTREM_PHASEID; }
        set { _INTREM_PHASEID = value; }
    }

    private int _INTREM_APPLICANTID;
    public int INTREM_APPLICANTID
    {
        get { return _INTREM_APPLICANTID; }
        set { _INTREM_APPLICANTID = value; }
    }

    private int _INTREM_OVERALLASSESSMENT;
    public int INTREM_OVERALLASSESSMENT
    {
        get { return _INTREM_OVERALLASSESSMENT; }
        set { _INTREM_OVERALLASSESSMENT = value; }
    }

    private int _INTREM_RECOMMENDATION;
    public int INTREM_RECOMMENDATION
    {
        get { return _INTREM_RECOMMENDATION; }
        set { _INTREM_RECOMMENDATION = value; }
    }

    private decimal _INTREM_OFFEREDSALARY;
    public decimal INTREM_OFFEREDSALARY
    {
        get { return _INTREM_OFFEREDSALARY; }
        set { _INTREM_OFFEREDSALARY = value; }
    }

    private DateTime _INTREM_JOININGDATE;
    public DateTime INTREM_JOININGDATE
    {
        get { return _INTREM_JOININGDATE; }
        set { _INTREM_JOININGDATE = value; }
    }

    private int _INTREM_DESIGNATIONOFFERED;
    public int INTREM_DESIGNATIONOFFERED
    {
        get { return _INTREM_DESIGNATIONOFFERED; }
        set { _INTREM_DESIGNATIONOFFERED = value; }
    }

    private int _INTREM_LEVEL;
    public int INTREM_LEVEL
    {
        get { return _INTREM_LEVEL; }
        set { _INTREM_LEVEL = value; }
    }

    private int _INTREM_DEPARTMENT;
    public int INTREM_DEPARTMENT
    {
        get { return _INTREM_DEPARTMENT; }
        set { _INTREM_DEPARTMENT = value; }
    }

    private string _INTREM_DIVISION;
    public string INTREM_DIVISION
    {
        get { return _INTREM_DIVISION; }
        set { _INTREM_DIVISION = value; }
    }

    private int _INTREM_CREATEDBY;
    public int INTREM_CREATEDBY
    {
        get { return _INTREM_CREATEDBY; }
        set { _INTREM_CREATEDBY = value; }
    }

    private DateTime _INTREM_CREATEDDATE;
    public DateTime INTREM_CREATEDDATE
    {
        get { return _INTREM_CREATEDDATE; }
        set { _INTREM_CREATEDDATE = value; }
    }

    private int _INTREM_LASTMDFBY;
    public int INTREM_LASTMDFBY
    {
        get { return _INTREM_LASTMDFBY; }
        set { _INTREM_LASTMDFBY = value; }
    }

    private DateTime _INTREM_LASTMDFDATE;
    public DateTime INTREM_LASTMDFDATE
    {
        get { return _INTREM_LASTMDFDATE; }
        set { _INTREM_LASTMDFDATE = value; }
    }

    private int _MODE;
    public int MODE
    {
        get { return _MODE; }
        set { _MODE = value; }
    }

    private int _INTREM_ORGANISATION_ID;
    public int INTREM_ORGANISATION_ID
    {
        get { return _INTREM_ORGANISATION_ID; }
        set { _INTREM_ORGANISATION_ID = value; }
    }

}
#endregion

#region SMHR_JOBREQUISITION

public class SMHR_JOBREQUISITION : SMHR_MAIN
{
    public SMHR_JOBREQUISITION(int __JOBREQ_ID)
    {
        this._JOBREQ_ID = __JOBREQ_ID;
    }

    public SMHR_JOBREQUISITION()
    {
    }

    private int _JOBREQ_ID;
    public int JOBREQ_ID
    {
        get { return (this._JOBREQ_ID); }
        set { this._JOBREQ_ID = value; }
    }

    private string _JOBREQ_REQCODE;
    public string JOBREQ_REQCODE
    {
        get { return (this._JOBREQ_REQCODE); }
        set { this._JOBREQ_REQCODE = value; }
    }

    private string _JOBREQ_REQNAME;
    public string JOBREQ_REQNAME
    {
        get { return (this._JOBREQ_REQNAME); }
        set { this._JOBREQ_REQNAME = value; }
    }
    private int _APPLICANT;
    public int APPLICANT
    {
        get { return (this._APPLICANT); }
        set { this._APPLICANT = value; }
    }

    private DateTime? _JOBREQ_REQDATE;
    public DateTime? JOBREQ_REQDATE
    {
        get { return _JOBREQ_REQDATE; }
        set { _JOBREQ_REQDATE = value; }
    }
    private long _JOBREQ_AppCTC;
    public long JOBREQ_AppCTC
    {
        get { return _JOBREQ_AppCTC; }
        set { _JOBREQ_AppCTC = value; }
    }
    private decimal _JOBREQ_BUDGETESTIMATION;
    public decimal JOBREQ_BUDGETESTIMATION
    {
        get { return _JOBREQ_BUDGETESTIMATION; }
        set { _JOBREQ_BUDGETESTIMATION = value; }
    }

    private DateTime _JOBREQ_REQEXPIRY;
    public DateTime JOBREQ_REQEXPIRY
    {
        get { return _JOBREQ_REQEXPIRY; }
        set { _JOBREQ_REQEXPIRY = value; }
    }
    private DateTime? _JOBREQ_ACTUALCLOSEDDATE;
    public DateTime? JOBREQ_ACTUALCLOSEDDATE
    {
        get { return _JOBREQ_ACTUALCLOSEDDATE; }
        set { _JOBREQ_ACTUALCLOSEDDATE = value; }
    }
    private int _JOBREQ_RAISEDBY;
    public int JOBREQ_RAISEDBY
    {
        get { return (this._JOBREQ_RAISEDBY); }
        set { this._JOBREQ_RAISEDBY = value; }
    }
    private int _JOBREQ_APPROVEDBY;
    public int JOBREQ_APPROVEDBY
    {
        get { return (this._JOBREQ_APPROVEDBY); }
        set { this._JOBREQ_APPROVEDBY = value; }
    }
    private int _JOBREQ_APPROVALSTATUS;
    public int JOBREQ_APPROVALSTATUS
    {
        get { return (this._JOBREQ_APPROVALSTATUS); }
        set { this._JOBREQ_APPROVALSTATUS = value; }
    }
    private DateTime? _JOBREQ_APPROVEDDATE;
    public DateTime? JOBREQ_APPROVEDDATE
    {
        get { return _JOBREQ_APPROVEDDATE; }
        set { _JOBREQ_APPROVEDDATE = value; }
    }
    private string _JOBREQ_STATUS;
    public string JOBREQ_STATUS
    {
        get { return (this._JOBREQ_STATUS); }
        set { this._JOBREQ_STATUS = value; }
    }
    private string _JOBREQ_BUSINESSUNIT_ID;
    public string JOBREQ_BUSINESSUNIT_ID
    {
        get { return (this._JOBREQ_BUSINESSUNIT_ID); }
        set { this._JOBREQ_BUSINESSUNIT_ID = value; }
    }
    private int _JOBREQ_DEPARTMENT;
    public int JOBREQ_DEPARTMENT
    {
        get { return (this._JOBREQ_DEPARTMENT); }
        set { this._JOBREQ_DEPARTMENT = value; }
    }

    private int _JOBREQ_DESIGNATION;
    public int JOBREQ_DESIGNATION
    {
        get { return (this._JOBREQ_DESIGNATION); }
        set { this._JOBREQ_DESIGNATION = value; }

    }
    private int _JOBREQ_OPENINGS;
    public int JOBREQ_OPENINGS
    {
        get { return (this._JOBREQ_OPENINGS); }
        set { this._JOBREQ_OPENINGS = value; }
    }
    private int _JOBREQ_EXPYEARS;
    public int JOBREQ_EXPYEARS
    {
        get { return (this._JOBREQ_EXPYEARS); }
        set { this._JOBREQ_EXPYEARS = value; }
    }

    private bool _JOBREQ_ISYEARSREQ;
    public bool JOBREQ_ISYEARSREQ
    {
        get { return (this._JOBREQ_ISYEARSREQ); }
        set { this._JOBREQ_ISYEARSREQ = value; }
    }
    private int _JOBREQ_QUALIFICATION;
    public int JOBREQ_QUALIFICATION
    {
        get { return (this._JOBREQ_QUALIFICATION); }
        set { this._JOBREQ_QUALIFICATION = value; }
    }
    private bool _JOBREQ_ISQUALREQ;
    public bool JOBREQ_ISQUALREQ
    {
        get { return (this._JOBREQ_ISQUALREQ); }
        set { this._JOBREQ_ISQUALREQ = value; }
    }
    //private bool _JOBREQ_ISBUSINESSUNIT;
    //public bool JOBREQ_ISBUSINESSUNIT
    //{
    //    get { return (this._JOBREQ_ISBUSINESSUNIT); }
    //    set { this._JOBREQ_ISBUSINESSUNIT = value; }
    //}
    private float _JOBREQ_PERCENTAGE;
    public float JOBREQ_PERCENTAGE
    {
        get { return (this._JOBREQ_PERCENTAGE); }
        set { this._JOBREQ_PERCENTAGE = value; }
    }

    private int _JOREQ_SKILL;
    public int JOREQ_SKILL
    {
        get { return (this._JOREQ_SKILL); }
        set { this._JOREQ_SKILL = value; }
    }

    private bool _JOBREQ_ISSKILLREQ;
    public bool JOBREQ_ISSKILLREQ
    {
        get { return (this._JOBREQ_ISSKILLREQ); }
        set { this._JOBREQ_ISSKILLREQ = value; }
    }
    private string _JOBREQ_COMMENTS;
    public string JOBREQ_COMMENTS
    {
        get { return (this._JOBREQ_COMMENTS); }
        set { this._JOBREQ_COMMENTS = value; }
    }

    private int _INTERVIWERNAME;
    public int INTERVIWERNAME
    {
        get { return _INTERVIWERNAME; }
        set { _INTERVIWERNAME = value; }
    }

    private int _JOBREQ_ORGANISATION_ID;
    public int JOBREQ_ORGANISATION_ID
    {
        get { return _JOBREQ_ORGANISATION_ID; }
        set { _JOBREQ_ORGANISATION_ID = value; }
    }

}

#endregion
#region Class For Deepika

public class SMHR_GETEMPLOYEE : SMHR_MAIN
{


    public SMHR_GETEMPLOYEE()
    {
    }



    private int _APPRO_BU_ID;
    public int APPRO_BU_ID
    {
        get { return (this._APPRO_BU_ID); }
        set { this._APPRO_BU_ID = value; }
    }
    private int _APPRO_EMP_ID;
    public int APPRO_EMP_ID
    {
        get { return (this._APPRO_EMP_ID); }
        set { this._APPRO_EMP_ID = value; }
    }

    private int _APPRO_APPROVER1_ID;
    public int APPRO_APPROVER1_ID
    {
        get { return (this._APPRO_APPROVER1_ID); }
        set { this._APPRO_APPROVER1_ID = value; }
    }

    private int _APPRO_APPROVER2_ID;
    public int APPRO_APPROVER2_ID
    {
        get { return (this._APPRO_APPROVER2_ID); }
        set { this._APPRO_APPROVER2_ID = value; }
    }

    private bool _APPRO_ISAPPROVER2;
    public bool APPRO_ISAPPROVER2
    {
        get { return (this._APPRO_ISAPPROVER2); }
        set { this._APPRO_ISAPPROVER2 = value; }
    }
    private int _APPRO_CREATEDBY;
    public int APPRO_CREATEDBY
    {
        get { return this._APPRO_CREATEDBY; }
        set { this._APPRO_CREATEDBY = value; }
    }

    private DateTime _APPRO_CREATEDDATE;
    public DateTime APPRO_CREATEDDATE
    {
        get { return this._APPRO_CREATEDDATE; }
        set { this._APPRO_CREATEDDATE = value; }
    }

    private int _APPRO_LASTMDFBY;
    public int APPRO_LASTMDFBY
    {
        get { return this._APPRO_LASTMDFBY; }
        set { this._APPRO_LASTMDFBY = value; }
    }

    private DateTime _APPRO_LASTMDFDATE;
    public DateTime APPRO_LASTMDFDATE
    {
        get { return (this._APPRO_LASTMDFDATE); }
        set { this._APPRO_LASTMDFDATE = value; }
    }

    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }
}

public class SMHR_APPROVALPROCESS : SMHR_MAIN
{
    public SMHR_APPROVALPROCESS(int __APPRO_ID)
    {
        this._APPRO_ID = __APPRO_ID;
    }

    public SMHR_APPROVALPROCESS()
    {
    }

    private int _APPRO_ID;
    public int APPRO_ID
    {
        get { return (this._APPRO_ID); }
        set { this._APPRO_ID = value; }
    }

    private int _APPRO_BU_ID;
    public int APPRO_BU_ID
    {
        get { return (this._APPRO_BU_ID); }
        set { this._APPRO_BU_ID = value; }
    }
    private int _APPRO_EMP_ID;
    public int APPRO_EMP_ID
    {
        get { return (this._APPRO_EMP_ID); }
        set { this._APPRO_EMP_ID = value; }
    }

    private int _APPRO_APPROVER1_ID;
    public int APPRO_APPROVER1_ID
    {
        get { return (this._APPRO_APPROVER1_ID); }
        set { this._APPRO_APPROVER1_ID = value; }
    }

    private int _APPRO_APPROVER2_ID;
    public int APPRO_APPROVER2_ID
    {
        get { return (this._APPRO_APPROVER2_ID); }
        set { this._APPRO_APPROVER2_ID = value; }
    }
    private bool _APPRO_ISAPPROVER2;
    public bool APPRO_ISAPPROVER2
    {
        get { return (this._APPRO_ISAPPROVER2); }
        set { this._APPRO_ISAPPROVER2 = value; }
    }

    private int _APPRO_CREATEDBY;
    public int APPRO_CREATEDBY
    {
        get { return this._APPRO_CREATEDBY; }
        set { this._APPRO_CREATEDBY = value; }
    }

    private DateTime _APPRO_CREATEDDATE;
    public DateTime APPRO_CREATEDDATE
    {
        get { return this._APPRO_CREATEDDATE; }
        set { this._APPRO_CREATEDDATE = value; }
    }

    private int _APPRO_LASTMDFBY;
    public int APPRO_LASTMDFBY
    {
        get { return this._APPRO_LASTMDFBY; }
        set { this._APPRO_LASTMDFBY = value; }
    }

    private DateTime _APPRO_LASTMDFDATE;
    public DateTime APPRO_LASTMDFDATE
    {
        get { return (this._APPRO_LASTMDFDATE); }
        set { this._APPRO_LASTMDFDATE = value; }
    }

    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }
}

public class SMHR_RESUMESHORTLIST : SMHR_MAIN
{
    public SMHR_RESUMESHORTLIST(int __RESSHT_ID)
    {
        this._RESSHT_ID = __RESSHT_ID;
    }

    public SMHR_RESUMESHORTLIST()
    {
    }

    private int _RESSHT_ID;
    public int RESSHT_ID
    {
        get { return (this._RESSHT_ID); }
        set { this._RESSHT_ID = value; }
    }

    private int _RESSHT_JOBREQID;
    public int RESSHT_JOBREQID
    {
        get { return (this._RESSHT_JOBREQID); }
        set { this._RESSHT_JOBREQID = value; }
    }

    private int _RESSHT_APPLID;
    public int RESSHT_APPLID
    {
        get { return (this._RESSHT_APPLID); }
        set { this._RESSHT_APPLID = value; }
    }
    private bool _RESSHT_ISSHORTLIST;
    public bool RESSHT_ISSHORTLIST
    {
        get { return (this._RESSHT_ISSHORTLIST); }
        set { this._RESSHT_ISSHORTLIST = value; }
    }

    private bool _SMHR_EMP_PAYITEMS_CHECKED;
    public bool SMHR_EMP_PAYITEMS_CHECKED
    {
        get { return (this._SMHR_EMP_PAYITEMS_CHECKED); }
        set { this._SMHR_EMP_PAYITEMS_CHECKED = value; }
    }

    private int _RESSHT_CREATEDBY;
    public int RESSHT_CREATEDBY
    {
        get { return this._RESSHT_CREATEDBY; }
        set { this._RESSHT_CREATEDBY = value; }
    }

    private DateTime _RESSHT_CREATEDDATE;
    public DateTime RESSHT_CREATEDDATE
    {
        get { return this._RESSHT_CREATEDDATE; }
        set { this._RESSHT_CREATEDDATE = value; }
    }

    private int _RESSHT_LASTMDFBY;
    public int RESSHT_LASTMDFBY
    {
        get { return this._RESSHT_LASTMDFBY; }
        set { this._RESSHT_LASTMDFBY = value; }
    }

    private DateTime _RESSHT_LASTMDFDATE;
    public DateTime RESSHT_LASTMDFDATE
    {
        get { return (this._RESSHT_LASTMDFDATE); }
        set { this._RESSHT_LASTMDFDATE = value; }
    }
    private String _JOBREQ_REQCODE;
    public String JOBREQ_REQCODE
    {
        get { return _JOBREQ_REQCODE; }
        set { _JOBREQ_REQCODE = value; }
    }
    private int _Mode;
    public int Mode
    {
        get { return _Mode; }
        set { _Mode = value; }
    }

}

#endregion
#region skills
public class SMHR_JOBREQSKILLS : SMHR_MAIN
{
    private int _JR_ID;
    public int JR_ID
    {
        get { return (this._JR_ID); }
        set { this._JR_ID = value; }
    }
    private int _SKILL_ID;
    public int SKILL_ID
    {
        get { return (this._SKILL_ID); }
        set { this._SKILL_ID = value; }
    }
    private int _JR_SKILLS_ID;
    public int JR_SKILLS_ID
    {
        get { return (this._JR_SKILLS_ID); }
        set { this._JR_SKILLS_ID = value; }
    }
    private bool _JOBREQ_ISSKILLREQ;
    public bool JOBREQ_ISSKILLREQ
    {
        get { return (this._JOBREQ_ISSKILLREQ); }
        set { this._JOBREQ_ISSKILLREQ = value; }
    }


}
#endregion
#region SMHR_INTERVIEW_PHASE_DEF_SKILLS
public class SMHR_INTERVIEW_PHASE_DEF_SKILLS : SMHR_MAIN
{
    private int _PHASE_DEF_SKILLS_ID;
    public int PHASE_DEF_SKILLS_ID
    {
        get { return (this._PHASE_DEF_SKILLS_ID); }
        set { this._PHASE_DEF_SKILLS_ID = value; }
    }
    private int _PHASE_DEF_SKILLS_SKILLID;
    public int PHASE_DEF_SKILLS_SKILLID
    {
        get { return (this._PHASE_DEF_SKILLS_SKILLID); }
        set { this._PHASE_DEF_SKILLS_SKILLID = value; }
    }
    private int _PHASE_DEF_SKILLS_PHASEID;
    public int PHASE_DEF_SKILLS_PHASEID
    {
        get { return (this._PHASE_DEF_SKILLS_PHASEID); }
        set { this._PHASE_DEF_SKILLS_PHASEID = value; }
    }
    private int _PHASE_DEF_SKILLS_CREATEDBY;
    public int PHASE_DEF_SKILLS_CREATEDBY
    {
        get { return (this._PHASE_DEF_SKILLS_CREATEDBY); }
        set { this._PHASE_DEF_SKILLS_CREATEDBY = value; }
    }

    private int _MODE;
    public int MODE
    {
        get { return (this._MODE); }
        set { this._MODE = value; }
    }

    private DateTime _PHASE_DEF_SKILLS_CREATEDDATE;
    public DateTime PHASE_DEF_SKILLS_CREATEDDATE
    {
        get { return (this._PHASE_DEF_SKILLS_CREATEDDATE); }
        set { this._PHASE_DEF_SKILLS_CREATEDDATE = value; }
    }
    private int _PHASE_DEF_SKILLS_LASTMODIFIEDBY;
    public int PHASE_DEF_SKILLS_LASTMODIFIEDBY
    {
        get { return (this._PHASE_DEF_SKILLS_LASTMODIFIEDBY); }
        set { this._PHASE_DEF_SKILLS_LASTMODIFIEDBY = value; }
    }
    private DateTime _PHASE_DEF_SKILLS_LASTMODIFIEDDATE;
    public DateTime PHASE_DEF_SKILLS_LASTMODIFIEDDATE
    {
        get { return (this._PHASE_DEF_SKILLS_LASTMODIFIEDDATE); }
        set { this._PHASE_DEF_SKILLS_LASTMODIFIEDDATE = value; }
    }



}
#endregion
#region SMHR_COURSEMASTER
public class SMHR_COURSEMASTER : SMHR_MAIN
{
    private string _COURSE;
    public string COURSE
    {
        get { return this._COURSE; }
        set { this._COURSE = value; }
    }
    private string _CODE;
    public string CODE
    {
        get { return this._CODE; }
        set { this._CODE = value; }
    }

}
#endregion

#region SMHR_EMP_TDS
public class SMHR_EMP_TDS : SMHR_MAIN
{
    private int _EMP_TDS_ID;
    public int EMP_TDS_ID
    {
        get { return (this._EMP_TDS_ID); }
        set { this._EMP_TDS_ID = value; }
    }

    private int _TDS_EMPID;
    public int TDS_EMPID
    {
        get { return (this._TDS_EMPID); }
        set { this._TDS_EMPID = value; }
    }

    private int _TDS_BUID;
    public int TDS_BUID
    {
        get { return (this._TDS_BUID); }
        set { this._TDS_BUID = value; }
    }

    private int _TDS_ORGID;
    public int TDS_ORGID
    {
        get { return (this._TDS_ORGID); }
        set { this._TDS_ORGID = value; }
    }

    private double _PREV_GROSS_AMOUNT;
    public double PREV_GROSS_AMOUNT
    {
        get { return (this._PREV_GROSS_AMOUNT); }
        set { this._PREV_GROSS_AMOUNT = value; }
    }

    private double _PREV_TDS_AMOUNT;
    public double PREV_TDS_AMOUNT
    {
        get { return (this._PREV_TDS_AMOUNT); }
        set { this._PREV_TDS_AMOUNT = value; }
    }
    private bool _TDS_CHECKED;
    public bool TDS_CHECKED
    {
        get { return (this._TDS_CHECKED); }
        set { this._TDS_CHECKED = value; }
    }
    private int _TDS_PERIOD;
    public int TDS_PERIOD
    {
        get { return (this._TDS_PERIOD); }
        set { this._TDS_PERIOD = value; }
    }
}
#endregion

#region SMHR_KENYA_PAYITEM
public class SMHR_KENYA_PAYITEM : SMHR_MAIN
{
    private int _KENYA_PAYITEM_ID;
    public int KENYA_PAYITEM_ID
    {
        get { return (this._KENYA_PAYITEM_ID); }
        set { this._KENYA_PAYITEM_ID = value; }
    }

    private int _KENYA_PAYITEM_PAYITEM_ID;
    public int KENYA_PAYITEM_PAYITEM_ID
    {
        get { return (this._KENYA_PAYITEM_PAYITEM_ID); }
        set { this._KENYA_PAYITEM_PAYITEM_ID = value; }
    }

    private int _KENYA_PAYITEM_ORGANISATION_ID;
    public int KENYA_PAYITEM_ORGANISATION_ID
    {
        get { return (this._KENYA_PAYITEM_ORGANISATION_ID); }
        set { this._KENYA_PAYITEM_ORGANISATION_ID = value; }
    }

    private int _KENYA_PAYITEM_BUSINESSUNIT_ID;
    public int KENYA_PAYITEM_BUSINESSUNIT_ID
    {
        get { return (this._KENYA_PAYITEM_BUSINESSUNIT_ID); }
        set { this._KENYA_PAYITEM_BUSINESSUNIT_ID = value; }
    }

    private int _KENYA_PAYITEM_PERIOD_ID;
    public int KENYA_PAYITEM_PERIOD_ID
    {
        get { return (this._KENYA_PAYITEM_PERIOD_ID); }
        set { this._KENYA_PAYITEM_PERIOD_ID = value; }
    }
    private Boolean _KENYA_PAYITEM_STATUS;
    public Boolean KENYA_PAYITEM_STATUS
    {
        get { return (this._KENYA_PAYITEM_STATUS); }
        set { this._KENYA_PAYITEM_STATUS = value; }
    }


}
#endregion

#region PMS_HRCREATION
public class PMS_HRCREATION : SMHR_MAIN
{
    private int _BUSINESSUNIT_ID;
    public int BUSINESSUNIT_ID
    {
        get { return _BUSINESSUNIT_ID; }
        set { this._BUSINESSUNIT_ID = value; }
    }
    private int _USER_ID;
    public int USER_ID
    {
        get { return _USER_ID; }
        set { this._USER_ID = value; }
    }
    private string _HR_MAIL_ID;
    public string HR_EMAIL_ID
    {
        get { return _HR_MAIL_ID; }
        set { this._HR_MAIL_ID = value; }
    }
    private int _HR_CREATION_ID;
    public int HR_CREATION_ID
    {
        get { return _HR_CREATION_ID; }
        set { this._HR_CREATION_ID = value; }
    }
    private int _HR_CREATION_CREATEDBY;
    public int HR_CREATION_CREATEDBY
    {
        get { return _HR_CREATION_CREATEDBY; }
        set { this._HR_CREATION_CREATEDBY = value; }
    }
    private DateTime _HR_CREATION_CREATEDDATE;
    public DateTime HR_CREATION_CREATEDDATE
    {
        get { return _HR_CREATION_CREATEDDATE; }
        set { this._HR_CREATION_CREATEDDATE = value; }
    }
    private int _HR_CREATION_LSTMDFBY;
    public int HR_CREATION_LSTMDFBY
    {
        get { return _HR_CREATION_LSTMDFBY; }
        set { this._HR_CREATION_LSTMDFBY = value; }
    }
    private DateTime _HR_CREATION_LSTMDFDATE;
    public DateTime HR_CREATION_LSTMDFDATE
    {
        get { return _HR_CREATION_LSTMDFDATE; }
        set { this._HR_CREATION_LSTMDFDATE = value; }
    }
}

#endregion

#region SMHR_DIVISION

public class SMHR_DIVISION : SMHR_MAIN
{
    public SMHR_DIVISION(int __DIVISION_ID)
    {
        this._DIVISION_ID = __DIVISION_ID;
    }

    public SMHR_DIVISION()
    {
    }

    private int _DIVISION_ID;
    public int DIVISION_ID
    {
        get { return (this._DIVISION_ID); }
        set { this._DIVISION_ID = value; }
    }

    private string _DIVISION_CODE;
    public string DIVISION_CODE
    {
        get { return (this._DIVISION_CODE); }
        set { this._DIVISION_CODE = value; }
    }

    private string _DIVISION_DESCRIPTION;
    public string DIVISION_DESCRIPTION
    {
        get { return (this._DIVISION_DESCRIPTION); }
        set { this._DIVISION_DESCRIPTION = value; }
    }

    private int _BUSINESSUNIT_ID;
    public int BUSINESSUNIT_ID
    {
        get { return (this._BUSINESSUNIT_ID); }
        set { this._BUSINESSUNIT_ID = value; }
    }
    private int _DEPARTMENT_ID;
    public int DEPARTMENT_ID
    {
        get { return (this._DEPARTMENT_ID); }
        set { this._DEPARTMENT_ID = value; }
    }
}

#endregion
#region SMHR_DEPARTMENT_DIVISION_MAPPING

public class SMHR_DEPARTMENT_DIVISION_MAPPING : SMHR_MAIN
{
    public SMHR_DEPARTMENT_DIVISION_MAPPING(int __DIVISION_ID)
    {
        this._SMHR_DEPARTMENT_DIVISION_MAPPING_ID = __DIVISION_ID;
    }

    public SMHR_DEPARTMENT_DIVISION_MAPPING()
    {
    }

    private int _SMHR_DEPARTMENT_DIVISION_MAPPING_ID;
    public int SMHR_DEPARTMENT_DIVISION_MAPPING_ID
    {
        get { return (this._SMHR_DEPARTMENT_DIVISION_MAPPING_ID); }
        set { this._SMHR_DEPARTMENT_DIVISION_MAPPING_ID = value; }
    }

    private int? _DIVISION_ID;
    public int? DIVISION_ID
    {
        get { return (this._DIVISION_ID); }
        set { this._DIVISION_ID = value; }
    }

    private int? _DEPARTMENT_ID;
    public int? DEPARTMENT_ID
    {
        get { return (this._DEPARTMENT_ID); }
        set { this._DEPARTMENT_ID = value; }
    }
    private string _Type;
    public string Type
    {
        get { return (this._Type); }
        set { this._Type = value; }
    }
    private string _ERP_CODE;
    public string ERP_CODE
    {
        get { return (this._ERP_CODE); }
        set { this._ERP_CODE = value; }
    }

    private string _ERP_DEP_CODE;
    public string ERP_DEP_CODE
    {
        get { return (this._ERP_DEP_CODE); }
        set { this._ERP_DEP_CODE = value; }
    }
    private string _STATUS;
    public string STATUS
    {
        get { return (this._STATUS); }
        set { this._STATUS = value; }
    }
}

#endregion

#region SMHR_FORM16

public class SMHR_FORMSIXTN : SMHR_MAIN
{

    private int _EMPLOYEE;
    public int EMPLOYEE
    {
        get { return (this._EMPLOYEE); }
        set { this._EMPLOYEE = value; }
    }
    private int _PERIOD;
    public int PERIOD
    {
        get { return (this._PERIOD); }
        set { this._PERIOD = value; }
    }
    private string _AMOUNT;
    public string AMOUNT
    {
        get { return (this._AMOUNT); }
        set { this._AMOUNT = value; }
    }
    private DateTime _PAYMENT_DATE;
    public DateTime PAYMENT_DATE
    {
        get { return (this._PAYMENT_DATE); }
        set { this._PAYMENT_DATE = value; }
    }
    private string _CHALLAN_NUMBER;
    public string CHALLAN_NUMBER
    {
        get { return (this._CHALLAN_NUMBER); }
        set { this._CHALLAN_NUMBER = value; }
    }
    private int _BANK;
    public int BANK
    {
        get { return (this._BANK); }
        set { this._BANK = value; }
    }
    private int _STATUS;
    public int STATUS
    {
        get { return (this._STATUS); }
        set { this._STATUS = value; }
    }

    private int _Id;
    public int Id
    {
        get { return (this._Id); }
        set { this._Id = value; }
    }


}
#endregion
#region SMHR_ANNOUNCEMENT
public class SMHR_ANNOUNCEMENT : SMHR_MAIN
{
    private int _ANNCE_ID;
    public int ANNCE_ID
    {
        get { return (this._ANNCE_ID); }
        set { this._ANNCE_ID = value; }
    }

    private string _ANNCE_TITLE;
    public string ANNCE_TITLE
    {
        get { return (this._ANNCE_TITLE); }
        set { this._ANNCE_TITLE = value; }
    }

    private string _ANNCE_MESSAGE;
    public string ANNCE_MESSAGE
    {
        get { return (this._ANNCE_MESSAGE); }
        set { this._ANNCE_MESSAGE = value; }
    }
    private DateTime _ANNCE_EXP_DATE;
    public DateTime ANNCE_EXP_DATE
    {
        get { return (this._ANNCE_EXP_DATE); }
        set { this._ANNCE_EXP_DATE = value; }
    }

    private int _ANNCE_ORG_ID;
    public int ANNCE_ORG_ID
    {
        get { return (this._ANNCE_ORG_ID); }
        set { this._ANNCE_ORG_ID = value; }
    }

    private int _ANNCE_CREATEDBY;
    public int ANNCE_CREATEDBY
    {
        get { return (this._ANNCE_CREATEDBY); }
        set { this._ANNCE_CREATEDBY = value; }
    }

    private DateTime _ANNCE_CREATEDDATE;
    public DateTime ANNCE_CREATEDDATE
    {
        get { return (this._ANNCE_CREATEDDATE); }
        set { this._ANNCE_CREATEDDATE = value; }
    }

    private int _ANNCE_LASTMDFBY;
    public int ANNCE_LASTMDFBY
    {
        get { return (this._ANNCE_LASTMDFBY); }
        set { this._ANNCE_LASTMDFBY = value; }
    }

    private DateTime _ANNCE_LASTMDFDATE;
    public DateTime ANNCE_LASTMDFDATE
    {
        get { return (this._ANNCE_LASTMDFDATE); }
        set { this._ANNCE_LASTMDFDATE = value; }
    }



}
#endregion

#region SMHR_ANNOUNCEMENT
public class SMHR_EMPLOYEETRANSACTION : SMHR_MAIN
{
    private int _EMPBNKTRN_ID;
    public int EMPBNKTRN_ID
    {
        get { return (this._EMPBNKTRN_ID); }
        set { this._EMPBNKTRN_ID = value; }
    }


    private int _EMPBNKTRN_EMP_ID;
    public int EMPBNKTRN_EMP_ID
    {
        get { return (this._EMPBNKTRN_EMP_ID); }
        set { this._EMPBNKTRN_EMP_ID = value; }
    }

    private int _EMPBNKTRN_BANK_DTLS_ID;
    public int EMPBNKTRN_BANK_DTLS_ID
    {
        get { return (this._EMPBNKTRN_BANK_DTLS_ID); }
        set { this._EMPBNKTRN_BANK_DTLS_ID = value; }
    }


    private int _EMPBNKTRN_PERIOD_ID;
    public int EMPBNKTRN_PERIOD_ID
    {
        get { return (this._EMPBNKTRN_PERIOD_ID); }
        set { this._EMPBNKTRN_PERIOD_ID = value; }
    }


    private int _EMPBNKTRN_PRDDTL_ID;
    public int EMPBNKTRN_PRDDTL_ID
    {
        get { return (this._EMPBNKTRN_PRDDTL_ID); }
        set { this._EMPBNKTRN_PRDDTL_ID = value; }
    }


    private double _EMPBNKTRN_AMOUNT;
    public double EMPBNKTRN_AMOUNT
    {
        get { return (this._EMPBNKTRN_AMOUNT); }
        set { this._EMPBNKTRN_AMOUNT = value; }
    }


    private int _EMPBNKTRN_TRAN_STATUS;
    public int EMPBNKTRN_TRAN_STATUS
    {
        get { return (this._EMPBNKTRN_TRAN_STATUS); }
        set { this._EMPBNKTRN_TRAN_STATUS = value; }
    }


    private int _EMPBNKTRN_BU_ID;
    public int EMPBNKTRN_BU_ID
    {
        get { return (this._EMPBNKTRN_BU_ID); }
        set { this._EMPBNKTRN_BU_ID = value; }
    }

    private int _EMPBNKTRN_ORG_ID;
    public int EMPBNKTRN_ORG_ID
    {
        get { return (this._EMPBNKTRN_ORG_ID); }
        set { this._EMPBNKTRN_ORG_ID = value; }
    }



}
#endregion

#region SMHR_FOODALLOWANCE
public class SMHR_FOODALLOWANCE : SMHR_MAIN
{
    private int _FOODALLOWANCE_EMP_ID;
    public int FOODALLOWANCE_EMP_ID
    {
        get { return (this._FOODALLOWANCE_EMP_ID); }
        set { this._FOODALLOWANCE_EMP_ID = value; }
    }

    private double _FOODALLOWANCE_AMOUNT;
    public double FOODALLOWANCE_AMOUNT
    {
        get { return (this._FOODALLOWANCE_AMOUNT); }
        set { this._FOODALLOWANCE_AMOUNT = value; }
    }

    private int _FOODALLOWANCE_BU_ID;
    public int FOODALLOWANCE_BU_ID
    {
        get { return (this._FOODALLOWANCE_BU_ID); }
        set { this._FOODALLOWANCE_BU_ID = value; }
    }

    private int _FOODALLOWANCE_ORG_ID;
    public int FOODALLOWANCE_ORG_ID
    {
        get { return (this._FOODALLOWANCE_ORG_ID); }
        set { this._FOODALLOWANCE_ORG_ID = value; }
    }
}
#endregion

#region SMHR_EMPLOYEE_INHOLD
public class SMHR_EMPLOYEE_INHOLD : SMHR_MAIN
{
    private int _INH_EMP_ID;
    public int INH_EMP_ID
    {
        get { return (this._INH_EMP_ID); }
        set { this._INH_EMP_ID = value; }
    }

    private int _INH_HOLD_STATUS;
    public int INH_HOLD_STATUS
    {
        get { return (this._INH_HOLD_STATUS); }
        set { this._INH_HOLD_STATUS = value; }
    }

    private int _INH_BU_ID;
    public int INH_BU_ID
    {
        get { return (this._INH_BU_ID); }
        set { this._INH_BU_ID = value; }
    }

    private int _INH_FIN_PRDDTL_ID;
    public int INH_FIN_PRDDTL_ID
    {
        get { return (this._INH_FIN_PRDDTL_ID); }
        set { this._INH_FIN_PRDDTL_ID = value; }
    }

    private int _INH_CREATED_BY;
    public int INH_CREATED_BY
    {
        get { return (this._INH_CREATED_BY); }
        set { this._INH_CREATED_BY = value; }
    }

    private DateTime _INH_CREATED_DATE;
    public DateTime INH_CREATED_DATE
    {
        get { return (this._INH_CREATED_DATE); }
        set { this._INH_CREATED_DATE = value; }
    }

    private int _INH_MODIFIED_BY;
    public int INH_MODIFIED_BY
    {
        get { return (this._INH_MODIFIED_BY); }
        set { this._INH_MODIFIED_BY = value; }
    }

    private DateTime _INH_MODIFIED_DATE;
    public DateTime INH_MODIFIED_DATE
    {
        get { return (this._INH_MODIFIED_DATE); }
        set { this._INH_MODIFIED_DATE = value; }
    }
}
#endregion

#region SMHR_ATTENDANCEPERIOD

public class SMHR_ATTENDANCEPERIOD : SMHR_MAIN
{
    private int _ATTENDANCEPERIOD_BU;
    public int ATTENDANCEPERIOD_BU
    {
        get { return (this._ATTENDANCEPERIOD_BU); }
        set { this._ATTENDANCEPERIOD_BU = value; }
    }

    private int _ATTENDANCEPERIOD_PERIOD;
    public int ATTENDANCEPERIOD_PERIOD
    {
        get { return (this._ATTENDANCEPERIOD_PERIOD); }
        set { this._ATTENDANCEPERIOD_PERIOD = value; }
    }

    private int _ATTENDANCEPERIOD_PERIODDETAILS;
    public int ATTENDANCEPERIOD_PERIODDETAILS
    {
        get { return (this._ATTENDANCEPERIOD_PERIODDETAILS); }
        set { this._ATTENDANCEPERIOD_PERIODDETAILS = value; }
    }

    private DateTime _ATTENDANCEPERIOD_STARTDATE;
    public DateTime ATTENDANCEPERIOD_STARTDATE
    {
        get { return (this._ATTENDANCEPERIOD_STARTDATE); }
        set { this._ATTENDANCEPERIOD_STARTDATE = value; }
    }

    private DateTime _ATTENDANCEPERIOD_ENDDATE;
    public DateTime ATTENDANCEPERIOD_ENDDATE
    {
        get { return (this._ATTENDANCEPERIOD_ENDDATE); }
        set { this._ATTENDANCEPERIOD_ENDDATE = value; }
    }

    private int _ATTENDANCEPERIOD_ID;
    public int ATTENDANCEPERIOD_ID
    {
        get { return (this._ATTENDANCEPERIOD_ID); }
        set { this._ATTENDANCEPERIOD_ID = value; }
    }
}
#endregion

#region SMHR_PAYROLLPERIOD

public class SMHR_PAYROLLPERIOD : SMHR_MAIN
{
    private int _PAYROLLPERIOD_BU;
    public int PAYROLLPERIOD_BU
    {
        get { return (this._PAYROLLPERIOD_BU); }
        set { this._PAYROLLPERIOD_BU = value; }
    }

    private int _PAYROLLPERIOD_PERIOD;
    public int PAYROLLPERIOD_PERIOD
    {
        get { return (this._PAYROLLPERIOD_PERIOD); }
        set { this._PAYROLLPERIOD_PERIOD = value; }
    }

    private int _PAYROLLPERIOD_PERIODDETAILS;
    public int PAYROLLPERIOD_PERIODDETAILS
    {
        get { return (this._PAYROLLPERIOD_PERIODDETAILS); }
        set { this._PAYROLLPERIOD_PERIODDETAILS = value; }
    }

    private DateTime _PAYROLLPERIOD_STARTDATE;
    public DateTime PAYROLLPERIOD_STARTDATE
    {
        get { return (this._PAYROLLPERIOD_STARTDATE); }
        set { this._PAYROLLPERIOD_STARTDATE = value; }
    }

    private DateTime _PAYROLLPERIOD_ENDDATE;
    public DateTime PAYROLLPERIOD_ENDDATE
    {
        get { return (this._PAYROLLPERIOD_ENDDATE); }
        set { this._PAYROLLPERIOD_ENDDATE = value; }
    }
    private int _PAYROLLPERIOD_ID;
    public int PAYROLLPERIOD_ID
    {
        get { return (this._PAYROLLPERIOD_ID); }
        set { this._PAYROLLPERIOD_ID = value; }
    }
}
#endregion

#region SMHR_SUBDIVISION

public class SMHR_SUBDIVISION : SMHR_MAIN
{
    private int _SUBDIVISION_ID;
    public int SUBDIVISION_ID
    {
        get { return (this._SUBDIVISION_ID); }
        set { this._SUBDIVISION_ID = value; }
    }
    private string _SUBDIVISION_NAME;
    public string SUBDIVISION_NAME
    {
        get { return (this._SUBDIVISION_NAME); }
        set { this._SUBDIVISION_NAME = value; }
    }
    private string _SUBDIVISION_DESC;
    public string SUBDIVISION_DESC
    {
        get { return (this._SUBDIVISION_DESC); }
        set { this._SUBDIVISION_DESC = value; }
    }
    private int _SUBDIVISION_DIVISION_ID;
    public int SUBDIVISION_DIVISION_ID
    {
        get { return (this._SUBDIVISION_DIVISION_ID); }
        set { this._SUBDIVISION_DIVISION_ID = value; }
    }
    private int _SUBDIVISION_DEPARTMENT_ID;
    public int SUBDIVISION_DEPARTMENT_ID
    {
        get { return (this._SUBDIVISION_DEPARTMENT_ID); }
        set { this._SUBDIVISION_DEPARTMENT_ID = value; }
    }
    private int _SUBDIVISION_BU_ID;
    public int SUBDIVISION_BU_ID
    {
        get { return (this._SUBDIVISION_BU_ID); }
        set { this._SUBDIVISION_BU_ID = value; }
    }
    private string _SUBDIVISION_STATUS;
    public string SUBDIVISION_STATUS
    {
        get { return (this._SUBDIVISION_STATUS); }
        set { this._SUBDIVISION_STATUS = value; }
    }
}

#endregion
#region SMHR_CURRENCY_CONVERSION

public class SMHR_CURRENCY_CONVERSION : SMHR_MAIN
{
    private int _CURRENCY_CONVERSION_ID;
    public int CURRENCY_CONVERSION_ID
    {
        get { return (this._CURRENCY_CONVERSION_ID); }
        set { this._CURRENCY_CONVERSION_ID = value; }
    }
    private int _CURRENCY_CONVERSION_BU;
    public int CURRENCY_CONVERSION_BU
    {
        get { return (this._CURRENCY_CONVERSION_BU); }
        set { this._CURRENCY_CONVERSION_BU = value; }
    }
    private int _CURRENCY_CONVERSION_FROMCURR;
    public int CURRENCY_CONVERSION_FROMCURR
    {
        get { return (this._CURRENCY_CONVERSION_FROMCURR); }
        set { this._CURRENCY_CONVERSION_FROMCURR = value; }
    }
    private int _CURRENCY_CONVERSION_TOCURR;
    public int CURRENCY_CONVERSION_TOCURR
    {
        get { return (this._CURRENCY_CONVERSION_TOCURR); }
        set { this._CURRENCY_CONVERSION_TOCURR = value; }
    }
    private decimal _CURRENCY_CONVERSION_RATE;
    public decimal CURRENCY_CONVERSION_RATE
    {
        get { return (this._CURRENCY_CONVERSION_RATE); }
        set { this._CURRENCY_CONVERSION_RATE = value; }
    }
}

#endregion
#region SMHR_EMP_ONSITEDETAILS

public class SMHR_EMP_ONSITEDETAILS : SMHR_MAIN
{
    private int _ONSITEDETAILS_ID;
    public int ONSITEDETAILS_ID
    {
        get { return (this._ONSITEDETAILS_ID); }
        set { this._ONSITEDETAILS_ID = value; }
    }
    private int _ONSITEDETAILS_EMP_ID;
    public int ONSITEDETAILS_EMP_ID
    {
        get { return (this._ONSITEDETAILS_EMP_ID); }
        set { this._ONSITEDETAILS_EMP_ID = value; }
    }
    private DateTime _ONSITEDETAILS_FROMDATE;
    public DateTime ONSITEDETAILS_FROMDATE
    {
        get { return (this._ONSITEDETAILS_FROMDATE); }
        set { this._ONSITEDETAILS_FROMDATE = value; }
    }
    private DateTime _ONSITEDETAILS_TODATE;
    public DateTime ONSITEDETAILS_TODATE
    {
        get { return (this._ONSITEDETAILS_TODATE); }
        set { this._ONSITEDETAILS_TODATE = value; }
    }
    private int _ONSITEDETAILS_LOCATION;
    public int ONSITEDETAILS_LOCATION
    {
        get { return (this._ONSITEDETAILS_LOCATION); }
        set { this._ONSITEDETAILS_LOCATION = value; }
    }
}

#endregion
#region SMHR_EMP_SHIFTDETAILS

public class SMHR_EMP_SHIFTDETAILS : SMHR_MAIN
{
    private int _SHIFTDETAILS_ID;
    public int SHIFTDETAILS_ID
    {
        get { return (this._SHIFTDETAILS_ID); }
        set { this._SHIFTDETAILS_ID = value; }
    }
    private int _SHIFTDETAILS_EMP_ID;
    public int SHIFTDETAILS_EMP_ID
    {
        get { return (this._SHIFTDETAILS_EMP_ID); }
        set { this._SHIFTDETAILS_EMP_ID = value; }
    }
    private DateTime _SHIFTDETAILS_FROMDATE;
    public DateTime SHIFTDETAILS_FROMDATE
    {
        get { return (this._SHIFTDETAILS_FROMDATE); }
        set { this._SHIFTDETAILS_FROMDATE = value; }
    }
    private DateTime _SHIFTDETAILS_TODATE;
    public DateTime SHIFTDETAILS_TODATE
    {
        get { return (this._SHIFTDETAILS_TODATE); }
        set { this._SHIFTDETAILS_TODATE = value; }
    }
    private int _SHIFTDETAILS_SHIFT_ID;
    public int SHIFTDETAILS_SHIFT_ID
    {
        get { return (this._SHIFTDETAILS_SHIFT_ID); }
        set { this._SHIFTDETAILS_SHIFT_ID = value; }
    }
}

#endregion

#region SMHR_USERLOG

public class SMHR_USERLOG : SMHR_MAIN
{
    public SMHR_USERLOG()
    { }

    public int USERLOG_ID { get; set; }
    public int USERLOG_USER_ID { get; set; }
    public string USERLOG_IP { get; set; }
    public string USERLOG_DOMAIN { get; set; }
    public DateTime USERLOG_LOGSTART { get; set; }
    public DateTime USERLOG_LOGEND { get; set; }
    public int USERLOG_CREATEDBY { get; set; }
    public DateTime USERLOG_CREATEDDATE { get; set; }
}

#endregion
#region SMHR_COMMITTEE

public class SMHR_COMMITTEE : SMHR_MAIN
{
    public SMHR_COMMITTEE(int __COMMITTEE_ID)
    {
        this._COMMITTEE_ID = __COMMITTEE_ID;
    }

    public SMHR_COMMITTEE()
    {
    }
    private int _COMMITTEE_ID;
    public int COMMITTEE_ID
    {
        get { return (this._COMMITTEE_ID); }
        set { this._COMMITTEE_ID = value; }
    }
    private string _COMMITTEE_EMP_ID;
    public string COMMITTEE_EMP_ID
    {
        get { return (this._COMMITTEE_EMP_ID); }
        set { this._COMMITTEE_EMP_ID = value; }
    }

    private int _COMMITTEE_ORGANISATION_ID;
    public int COMMITTEE_ORGANISATION_ID
    {
        get { return (this._COMMITTEE_ORGANISATION_ID); }
        set { this._COMMITTEE_ORGANISATION_ID = value; }
    }
    private string _COMMITTEE_CODE;
    public string COMMITTEE_CODE
    {
        get { return (this._COMMITTEE_CODE); }
        set { this._COMMITTEE_CODE = value; }
    }

    private string _COMMITTEE_DESC;
    public string COMMITTEE_DESC
    {
        get { return (this._COMMITTEE_DESC); }
        set { this._COMMITTEE_DESC = value; }
    }

    private string _COMMITTEE_REVIEW;
    public string COMMITTEE_REVIEW
    {
        get { return (this._COMMITTEE_REVIEW); }
        set { this._COMMITTEE_REVIEW = value; }
    }

    private string _COMMITTEE_REASON;
    public string COMMITTEE_REASON
    {
        get { return (this._COMMITTEE_REASON); }
        set { this._COMMITTEE_REASON = value; }
    }

    private string _COMMITTEE_OUTCOME;
    public string COMMITTEE_OUTCOME
    {
        get { return (this._COMMITTEE_OUTCOME); }
        set { this._COMMITTEE_OUTCOME = value; }
    }

    private bool _COMMITTEE_STATUS;
    public bool COMMITTEE_STATUS
    {
        get { return (this._COMMITTEE_STATUS); }
        set { this._COMMITTEE_STATUS = value; }
    }

    private string _COMMITTEE_STARTDATE;
    public string COMMITTEE_STARTDATE
    {
        get { return (this._COMMITTEE_STARTDATE); }
        set { this._COMMITTEE_STARTDATE = value; }
    }

    private string _COMMITTEE_ENDDATE;
    public string COMMITTEE_ENDDATE
    {
        get { return (this._COMMITTEE_ENDDATE); }
        set { this._COMMITTEE_ENDDATE = value; }
    }

    private int _COMMITTEE_CREATEDBY;
    public int COMMITTEE_CREATEDBY
    {
        get { return (this._COMMITTEE_CREATEDBY); }
        set { this._COMMITTEE_CREATEDBY = value; }
    }

    private string _COMMITTEE_CREATEDDATE;
    public string COMMITTEE_CREATEDDATE
    {
        get { return (this._COMMITTEE_CREATEDDATE); }
        set { this._COMMITTEE_CREATEDDATE = value; }
    }

    private int _COMMITTEE_LASTMDFBY;
    public int COMMITTEE_LASTMDFBY
    {
        get { return (this._COMMITTEE_LASTMDFBY); }
        set { this._COMMITTEE_LASTMDFBY = value; }
    }

    private string _COMMITTEE_LASTMDFDATE;
    public string COMMITTEE_LASTMDFDATE
    {
        get { return (this._COMMITTEE_LASTMDFDATE); }
        set { this._COMMITTEE_LASTMDFDATE = value; }
    }
}

#endregion
#region SMHR_SERVICEPROVIDERS

public class SMHR_SERVICEPROVIDER : SMHR_MAIN
{
    public SMHR_SERVICEPROVIDER(int __SERVICEPROVIDER_ID)
    {
        this._SERVICEPROVIDER_ID = __SERVICEPROVIDER_ID;
    }

    public SMHR_SERVICEPROVIDER()
    {
    }
    private int _SERVICEPROVIDER_ID;
    public int SERVICEPROVIDER_ID
    {
        get { return (this._SERVICEPROVIDER_ID); }
        set { this._SERVICEPROVIDER_ID = value; }
    }

    private string _SERVICEPROVIDER_NAME;
    public string SERVICEPROVIDER_NAME
    {
        get { return (this._SERVICEPROVIDER_NAME); }
        set { this._SERVICEPROVIDER_NAME = value; }
    }


    private string _SERVICEPROVIDER_ADDRESS;
    public string SERVICEPROVIDER_ADDRESS
    {
        get { return (this._SERVICEPROVIDER_ADDRESS); }
        set { this._SERVICEPROVIDER_ADDRESS = value; }
    }

    private string _SERVICEPROVIDER_EMAILID;

    public string SERVICEPROVIDEREMAILID
    {
        get
        {
            return this._SERVICEPROVIDER_EMAILID;
        }
        set
        {
            this._SERVICEPROVIDER_EMAILID = value;
        }
    }

    private string _SERVICEPROVIDER_CONTACTNUMBER;

    public string SERVICEPROVIDER_CONTACTNUMBER
    {
        get
        {
            return this._SERVICEPROVIDER_CONTACTNUMBER;
        }
        set
        {
            this._SERVICEPROVIDER_CONTACTNUMBER = value;
        }
    }

    private string _SERVICEPROVIDER_ALTERNATECONTACTNUMBER1;

    public string SERVICEPROVIDER_ALTERNATECONTACTNUMBER1
    {
        get
        {
            return this._SERVICEPROVIDER_ALTERNATECONTACTNUMBER1;
        }
        set
        {
            this._SERVICEPROVIDER_ALTERNATECONTACTNUMBER1 = value;
        }
    }

    private string _SERVICEPROVIDER_ALTERNATECONTACTNUMBER2;

    public string SERVICEPROVIDER_ALTERNATECONTACTNUMBER2
    {
        get
        {
            return this._SERVICEPROVIDER_ALTERNATECONTACTNUMBER2;
        }
        set
        {
            this._SERVICEPROVIDER_ALTERNATECONTACTNUMBER2 = value;
        }
    }

    private string _SERVICEPROVIDER_KEYCONTACTPERSONNAME;

    public string SERVICEPROVIDER_KEYCONTACTPERSONNAME
    {
        get
        {
            return this._SERVICEPROVIDER_KEYCONTACTPERSONNAME;
        }
        set
        {
            this._SERVICEPROVIDER_KEYCONTACTPERSONNAME = value;
        }
    }

    private string _SERVICEPROVIDER_TYPE;

    public string SERVICEPROVIDER_TYPE
    {
        get
        {
            return this._SERVICEPROVIDER_TYPE;
        }
        set
        {
            this._SERVICEPROVIDER_TYPE = value;
        }
    }

    private string _SERVICEPROVIDER_IFMISNUMBER;

    public string SERVICEPROVIDER_IFMISNUMBER
    {
        get
        {
            return this._SERVICEPROVIDER_IFMISNUMBER;
        }
        set
        {
            this._SERVICEPROVIDER_IFMISNUMBER = value;
        }
    }

    private string _SERVICEPROVIDER_PINNUMBER;

    public string SERVICEPROVIDER_PINNUMBER
    {
        get
        {
            return this._SERVICEPROVIDER_PINNUMBER;
        }
        set
        {
            this._SERVICEPROVIDER_PINNUMBER = value;
        }
    }

    private string _SERVICEPROVIDER_EXPENDITURENAMES;

    public string SERVICEPROVIDER_EXPENDITURENAMES
    {
        get
        {
            return this._SERVICEPROVIDER_EXPENDITURENAMES;
        }
        set
        {
            this._SERVICEPROVIDER_EXPENDITURENAMES = value;
        }
    }
}

#endregion
#region SMHR_EMPASSETTRANSFER

public class SMHR_EMPASSETTRANSFER : SMHR_MAIN
{
    public SMHR_EMPASSETTRANSFER(int __EMPASSETTRANSFER_ID)
    {
        this._EMPASSETTRANSFER_ID = __EMPASSETTRANSFER_ID;
    }

    public SMHR_EMPASSETTRANSFER()
    {
    }
    private int _EMPASSETTRANSFER_ID;
    public int EMPASSETTRANSFER_ID
    {
        get { return (this._EMPASSETTRANSFER_ID); }
        set { this._EMPASSETTRANSFER_ID = value; }
    }
    private int _EMPASSETTRANSFER_BUSINESSUNIT_ID;
    public int EMPASSETTRANSFER_BUSINESSUNIT_ID
    {
        get { return (this._EMPASSETTRANSFER_BUSINESSUNIT_ID); }
        set { this._EMPASSETTRANSFER_BUSINESSUNIT_ID = value; }
    }

    private int _EMPASSETDOC_ID;
    public int EMPASSETDOC_ID
    {
        get { return (this._EMPASSETDOC_ID); }
        set { this._EMPASSETDOC_ID = value; }
    }

    private int _EMPASSETTRANSFER_EMP_ID;
    public int EMPASSETTRANSFER_EMP_ID
    {
        get { return (this._EMPASSETTRANSFER_EMP_ID); }
        set { this._EMPASSETTRANSFER_EMP_ID = value; }
    }

    private int _EMPASSETTRANSFER_ORGANISATION_ID;
    public int EMPASSETTRANSFER_ORGANISATION_ID
    {
        get { return (this._EMPASSETTRANSFER_ORGANISATION_ID); }
        set { this._EMPASSETTRANSFER_ORGANISATION_ID = value; }
    }

    private int _EMPASSETTRANSFER_FROMEMP_ID;
    public int EMPASSETTRANSFER_FROMEMP_ID
    {
        get { return (this._EMPASSETTRANSFER_FROMEMP_ID); }
        set { this._EMPASSETTRANSFER_FROMEMP_ID = value; }
    }

    private int _EMPASSETTRANSFER_TOEMP_ID;
    public int EMPASSETTRANSFER_TOEMP_ID
    {
        get { return (this._EMPASSETTRANSFER_TOEMP_ID); }
        set { this._EMPASSETTRANSFER_TOEMP_ID = value; }
    }
    private string _EMPASSETTRANSFER_ASSETSNAME;
    public string EMPASSETTRANSFER_ASSETSNAME
    {
        get { return (this._EMPASSETTRANSFER_ASSETSNAME); }
        set { this._EMPASSETTRANSFER_ASSETSNAME = value; }
    }

    private string _EMPASSETTRANSFER_ISSUEDDATE;
    public string EMPASSETTRANSFER_ISSUEDDATE
    {
        get { return (this._EMPASSETTRANSFER_ISSUEDDATE); }
        set { this._EMPASSETTRANSFER_ISSUEDDATE = value; }
    }

    private bool _EMPASSETTRANSFER_STATUS;
    public bool EMPASSETTRANSFER_STATUS
    {
        get { return (this._EMPASSETTRANSFER_STATUS); }
        set { this._EMPASSETTRANSFER_STATUS = value; }
    }



    private int _EMPASSETTRANSFER_CREATEDBY;
    public int EMPASSETTRANSFER_CREATEDBY
    {
        get { return (this._EMPASSETTRANSFER_CREATEDBY); }
        set { this._EMPASSETTRANSFER_CREATEDBY = value; }
    }

    private string _EMPASSETTRANSFER_CREATEDDATE;
    public string EMPASSETTRANSFER_CREATEDDATE
    {
        get { return (this._EMPASSETTRANSFER_CREATEDDATE); }
        set { this._EMPASSETTRANSFER_CREATEDDATE = value; }
    }

    private int _EMPASSETTRANSFER_LASTMDFBY;
    public int EMPASSETTRANSFER_LASTMDFBY
    {
        get { return (this._EMPASSETTRANSFER_LASTMDFBY); }
        set { this._EMPASSETTRANSFER_LASTMDFBY = value; }
    }

    private string _EMPASSETTRANSFER_LASTMDFDATE;
    public string EMPASSETTRANSFER_LASTMDFDATE
    {
        get { return (this._EMPASSETTRANSFER_LASTMDFDATE); }
        set { this._EMPASSETTRANSFER_LASTMDFDATE = value; }
    }
}

#endregion
#region SMHR_EMPLOYEETYPE

public class SMHR_EMPLOYEETYPE : SMHR_MAIN
{
    public SMHR_EMPLOYEETYPE(int __EMPLOYEETYPE_ID)
    {
        this._EMPLOYEETYPE_ID = __EMPLOYEETYPE_ID;
    }

    public SMHR_EMPLOYEETYPE()
    {
    }
    private int _EMPLOYEETYPE_ID;
    public int EMPLOYEETYPE_ID
    {
        get { return (this._EMPLOYEETYPE_ID); }
        set { this._EMPLOYEETYPE_ID = value; }
    }

    private int _EMPLOYEETYPE_ORGANISATION_ID;
    public int EMPLOYEETYPE_ORGANISATION_ID
    {
        get { return (this._EMPLOYEETYPE_ORGANISATION_ID); }
        set { this._EMPLOYEETYPE_ORGANISATION_ID = value; }
    }

    private string _EMPLOYEETYPE_CODE;
    public string EMPLOYEETYPE_CODE
    {
        get { return (this._EMPLOYEETYPE_CODE); }
        set { this._EMPLOYEETYPE_CODE = value; }
    }

    private string _EMPLOYEETYPE_DESC;
    public string EMPLOYEETYPE_DESC
    {
        get { return (this._EMPLOYEETYPE_DESC); }
        set { this._EMPLOYEETYPE_DESC = value; }
    }

    private string _EMPLOYEETYPE_PREFIX;
    public string EMPLOYEETYPE_PREFIX
    {
        get { return (this._EMPLOYEETYPE_PREFIX); }
        set { this._EMPLOYEETYPE_PREFIX = value; }
    }

    private string _EMPLOYEETYPE_SERIALNO;
    public string EMPLOYEETYPE_SERIALNO
    {
        get { return (this._EMPLOYEETYPE_SERIALNO); }
        set { this._EMPLOYEETYPE_SERIALNO = value; }
    }

    private int _EMPLOYEETYPE_CREATEDBY;
    public int EMPLOYEETYPE_CREATEDBY
    {
        get { return (this._EMPLOYEETYPE_CREATEDBY); }
        set { this._EMPLOYEETYPE_CREATEDBY = value; }
    }

    private string _EMPLOYEETYPE_CREATEDDATE;
    public string EMPLOYEETYPE_CREATEDDATE
    {
        get { return (this._EMPLOYEETYPE_CREATEDDATE); }
        set { this._EMPLOYEETYPE_CREATEDDATE = value; }
    }

    private int _EMPLOYEETYPE_LASTMDFBY;
    public int EMPLOYEETYPE_LASTMDFBY
    {
        get { return (this._EMPLOYEETYPE_LASTMDFBY); }
        set { this._EMPLOYEETYPE_LASTMDFBY = value; }
    }

    private string _EMPLOYEETYPE_LASTMDFDATE;
    public string EMPLOYEETYPE_LASTMDFDATE
    {
        get { return (this._EMPLOYEETYPE_LASTMDFDATE); }
        set { this._EMPLOYEETYPE_LASTMDFDATE = value; }
    }

    private string _EmployeeTypeAge;
    public string EmployeeTypeAge
    {
        get { return _EmployeeTypeAge; }
        set { _EmployeeTypeAge = value; }
    }
}

#endregion

#region SMHR_DEPARTMENTSHEAD
//Addes By Ragha Sudha on 5th sep 2013
public class SMHR_DEPARTMENTHEADS : SMHR_MAIN
{
    public SMHR_DEPARTMENTHEADS()
    {

    }

    private int _DEPTHEAD_BU_ID;
    public int DEPTHEAD_BU_ID
    {
        get { return (this._DEPTHEAD_BU_ID); }
        set { this._DEPTHEAD_BU_ID = value; }
    }
    private int _DEPTHEAD_DEPT_ID;
    public int DEPTHEAD_DEPT_ID
    {
        get { return (this._DEPTHEAD_DEPT_ID); }
        set { this._DEPTHEAD_DEPT_ID = value; }
    }
    private int _DEPTHEAD_EMP_ID;
    public int DEPTHEAD_EMP_ID
    {
        get { return (this._DEPTHEAD_EMP_ID); }
        set { this._DEPTHEAD_EMP_ID = value; }
    }
    private int _DEPTHEAD_SUBHEAD_ID;
    public int DEPTHEAD_SUBHEAD_ID
    {
        get { return (this._DEPTHEAD_SUBHEAD_ID); }
        set { this._DEPTHEAD_SUBHEAD_ID = value; }
    }
    private bool _DEPTHEAD_STATUS_IS_ACTIVE;
    public bool DEPTHEAD_STATUS_IS_ACTIVE
    {
        get { return (this._DEPTHEAD_STATUS_IS_ACTIVE); }
        set { this._DEPTHEAD_STATUS_IS_ACTIVE = value; }
    }
    private bool _DEPSUBTHEAD_STATUS_IS_ACTIVE;
    public bool DEPSUBTHEAD_STATUS_IS_ACTIVE
    {
        get { return (this._DEPSUBTHEAD_STATUS_IS_ACTIVE); }
        set { this._DEPSUBTHEAD_STATUS_IS_ACTIVE = value; }
    }
    private int _DEPTHEAD_CREATEDBY;
    public int DEPTHEAD_CREATEDBY
    {
        get { return (this._DEPTHEAD_CREATEDBY); }
        set { this._DEPTHEAD_CREATEDBY = value; }
    }
    private DateTime _DEPTHEAD_CREATEDDATE;
    public DateTime DEPTHEAD_CREATEDDATE
    {
        get { return (this._DEPTHEAD_CREATEDDATE); }
        set { this._DEPTHEAD_CREATEDDATE = value; }
    }
    private int _DEPTHEAD_LASTMDFBY;
    public int DEPTHEAD_LASTMDFBY
    {
        get { return (this._DEPTHEAD_LASTMDFBY); }
        set { this._DEPTHEAD_LASTMDFBY = value; }
    }
    private DateTime _DEPTHEAD_LASTMDFDATE;
    public DateTime DEPTHEAD_LASTMDFDATE
    {
        get { return (this._DEPTHEAD_LASTMDFDATE); }
        set { this._DEPTHEAD_LASTMDFDATE = value; }
    }
}
public class SMHR_ASSET_MASTER : SMHR_MAIN
{
    private int _ASSET_ID;
    public int ASSET_ID
    {
        get { return (this._ASSET_ID); }
        set { this._ASSET_ID = value; }
    }
    private string _ASSET_NAME;
    public string ASSET_NAME
    {
        get { return (this._ASSET_NAME); }
        set { this._ASSET_NAME = value; }
    }
    private string _ASSET_DESCRIPTION;
    public string ASSET_DESCRIPTION
    {
        get { return (this._ASSET_DESCRIPTION); }
        set { this._ASSET_DESCRIPTION = value; }
    }
    private int _ASSET_DEPARTMENT_ID;
    public int ASSET_DEPARTMENT_ID
    {
        get { return (this._ASSET_DEPARTMENT_ID); }
        set { this._ASSET_DEPARTMENT_ID = value; }
    }
    private int _ASSET_CREATED_BY;
    public int ASSET_CREATED_BY
    {
        get { return (this._ASSET_CREATED_BY); }
        set { this._ASSET_CREATED_BY = value; }
    }

    private DateTime _ASSET_CREATED_DATE;
    public DateTime ASSET_CREATED_DATE
    {
        get { return (this._ASSET_CREATED_DATE); }
        set { this._ASSET_CREATED_DATE = value; }

    }
    private int _ASSET_MODIFIED_BY;
    public int ASSET_MODIFIED_BY
    {
        get { return (this._ASSET_MODIFIED_BY); }
        set { this._ASSET_MODIFIED_BY = value; }
    }
    private DateTime _ASSET_MODIFIED_DATE;
    public DateTime ASSET_MODIFIED_DATE
    {
        get { return (this._ASSET_MODIFIED_DATE); }
        set { this._ASSET_MODIFIED_DATE = value; }
    }
    private bool _ASSET_IS_ACTIVE;
    public bool ASSET_IS_ACTIVE
    {
        get { return (this._ASSET_IS_ACTIVE); }
        set { this._ASSET_IS_ACTIVE = value; }
    }
    private int _DEPARTMENT_ORG_ID;
    public int DEPARTMENT_ORG_ID
    {
        get { return (this._DEPARTMENT_ORG_ID); }
        set { this._DEPARTMENT_ORG_ID = value; }
    }
}
#endregion

#region SMHR_EMPLOYEEGRADE

public class SMHR_EMPLOYEEGRADE : SMHR_MAIN
{
    public SMHR_EMPLOYEEGRADE(int __EMPLOYEEGRADE_ID)
    {
        this._EMPLOYEEGRADE_ID = __EMPLOYEEGRADE_ID;
    }

    public SMHR_EMPLOYEEGRADE()
    {
    }
    private int _EMPLOYEEGRADE_ID;
    public int EMPLOYEEGRADE_ID
    {
        get { return (this._EMPLOYEEGRADE_ID); }
        set { this._EMPLOYEEGRADE_ID = value; }
    }

    private int _PERIOD_ID;
    public int PERIOD_ID
    {
        get { return (this._PERIOD_ID); }
        set { this._PERIOD_ID = value; }
    }

    private string _EMPLOYEEGRADE_CODE;
    public string EMPLOYEEGRADE_CODE
    {
        get { return (this._EMPLOYEEGRADE_CODE); }
        set { this._EMPLOYEEGRADE_CODE = value; }
    }

    private string _EMPLOYEEGRADE_NAME;
    public string EMPLOYEEGRADE_NAME
    {
        get { return (this._EMPLOYEEGRADE_NAME); }
        set { this._EMPLOYEEGRADE_NAME = value; }
    }

    private double _EMPLOYEEGRADE_RANK;
    public double EMPLOYEEGRADE_RANK
    {
        get { return (this._EMPLOYEEGRADE_RANK); }
        set { this._EMPLOYEEGRADE_RANK = value; }
    }

    private bool _EMPLOYEEGRADE_OT_STATUS;
    public bool EMPLOYEEGRADE_OT_STATUS
    {
        get { return (this._EMPLOYEEGRADE_OT_STATUS); }
        set { this._EMPLOYEEGRADE_OT_STATUS = value; }
    }
}

#endregion

#region SMHR_EMPLOYEE_ASSET_CLEARANCE
public class SMHR_EMP_ASSET_CLEARANCE : SMHR_MAIN
{
    public SMHR_EMP_ASSET_CLEARANCE()
    {

    }
    private int _EMP_ASSET_CLEARANCE_ASSET_ID;
    public int EMP_ASSET_CLEARANCE_ASSET_ID
    {
        get { return (this._EMP_ASSET_CLEARANCE_ASSET_ID); }
        set { this._EMP_ASSET_CLEARANCE_ASSET_ID = value; }
    }
    private int _EMP_ASSET_CLEARANCE_EMP_ID;
    public int EMP_ASSET_CLEARANCE_EMP_ID
    {
        get { return (this._EMP_ASSET_CLEARANCE_EMP_ID); }
        set { this._EMP_ASSET_CLEARANCE_EMP_ID = value; }
    }
    private int _EMP_ASSET_CLEARANCE_DEPT_ID;
    public int EMP_ASSET_CLEARANCE_DEPT_ID
    {
        get { return (this._EMP_ASSET_CLEARANCE_DEPT_ID); }
        set { this._EMP_ASSET_CLEARANCE_DEPT_ID = value; }
    }
    private int _EMP_ASSET_CLEARANCE_RECEIEVED_BY;
    public int EMP_ASSET_CLEARANCE_RECEIEVED_BY
    {
        get { return (this._EMP_ASSET_CLEARANCE_RECEIEVED_BY); }
        set { this._EMP_ASSET_CLEARANCE_RECEIEVED_BY = value; }
    }
    public string _EMP_ASSET_CLEARANCE_DEPTHEADREMARKS;
    public string EMP_ASSET_CLEARANCE_DEPTHEADREMARKS
    {
        get { return (_EMP_ASSET_CLEARANCE_DEPTHEADREMARKS); }
        set { this._EMP_ASSET_CLEARANCE_DEPTHEADREMARKS = value; }

    }

    private decimal _EMP_ASSET_CLEARANCE_AMOUNT;
    public decimal EMP_ASSET_CLEARANCE_AMOUNT
    {
        get { return (this._EMP_ASSET_CLEARANCE_AMOUNT); }
        set { this._EMP_ASSET_CLEARANCE_AMOUNT = value; }
    }

    private string _EMP_ASSET_CLEARANCE_REMARKS;
    public string EMP_ASSET_CLEARANCE_REMARKS
    {
        get { return (this._EMP_ASSET_CLEARANCE_REMARKS); }
        set { this._EMP_ASSET_CLEARANCE_REMARKS = value; }
    }

    private DateTime? _EMP_ASSET_CLEARANCE_RECEIVED_DATE;
    public DateTime? EMP_ASSET_CLEARANCE_RECEIVED_DATE
    {
        get { return (this._EMP_ASSET_CLEARANCE_RECEIVED_DATE); }
        set { this._EMP_ASSET_CLEARANCE_RECEIVED_DATE = value; }
    }

    private Int32? _EMP_ASSET_CLEARANCE_CREATEDBY;
    public Int32? EMP_ASSET_CLEARANCE_CREATEDBY
    {
        get { return (this._EMP_ASSET_CLEARANCE_CREATEDBY); }
        set { this._EMP_ASSET_CLEARANCE_CREATEDBY = value; }
    }

    private DateTime? _EMP_ASSET_CLEARANCE_CREATEDDATE;
    public DateTime? EMP_ASSET_CLEARANCE_CREATEDDATE
    {
        get { return (this._EMP_ASSET_CLEARANCE_CREATEDDATE); }
        set { this._EMP_ASSET_CLEARANCE_CREATEDDATE = value; }
    }

    private Int32? _EMP_ASSET_CLEARANCE_LSTMFDBY;
    public Int32? EMP_ASSET_CLEARANCE_LSTMFDBY
    {
        get { return (this._EMP_ASSET_CLEARANCE_LSTMFDBY); }
        set { this._EMP_ASSET_CLEARANCE_LSTMFDBY = value; }
    }

    private DateTime? _EMP_ASSET_CLEARANCE_LSTMFDDATE;
    public DateTime? EMP_ASSET_CLEARANCE_LSTMFDDATE
    {
        get { return (this._EMP_ASSET_CLEARANCE_LSTMFDDATE); }
        set { this._EMP_ASSET_CLEARANCE_LSTMFDDATE = value; }
    }

}
#endregion
# region EMPLOYEE_EXIT_INTERVIEW

public class SMHR_EMPLOYEE_EXIT_INTERVIEW : SMHR_MAIN
{
    public SMHR_EMPLOYEE_EXIT_INTERVIEW()
    {

    }
    private int _EMP_EXIT_INTERVIEW_ID;
    public int EMP_EXIT_INTERVIEW_ID
    {
        get { return (this._EMP_EXIT_INTERVIEW_ID); }
        set { this._EMP_EXIT_INTERVIEW_ID = value; }
    }
    private int _EMP_EXIT_INTERVIEW_EMP_ID;
    public int EMP_EXIT_INTERVIEW_EMP_ID
    {
        get { return (this._EMP_EXIT_INTERVIEW_EMP_ID); }
        set { this._EMP_EXIT_INTERVIEW_EMP_ID = value; }
    }
    private string _EMP_EXIT_INTERVIEW_PRIMARY_REASON;
    public string EMP_EXIT_INTERVIEW_PRIMARY_REASON
    {
        get { return (this._EMP_EXIT_INTERVIEW_PRIMARY_REASON); }
        set { this._EMP_EXIT_INTERVIEW_PRIMARY_REASON = value; }
    }
    private string _EMP_EXIT_INTERVIEW_JOB_SATISFACTION;
    public string EMP_EXIT_INTERVIEW_JOB_SATISFACTION
    {
        get { return (this._EMP_EXIT_INTERVIEW_JOB_SATISFACTION); }
        set { this._EMP_EXIT_INTERVIEW_JOB_SATISFACTION = value; }
    }

    private string _EMP_EXIT_INTERVIEW_JOB_FRUSTRATION;
    public string EMP_EXIT_INTERVIEW_JOB_FRUSTRATION
    {
        get { return (this._EMP_EXIT_INTERVIEW_JOB_FRUSTRATION); }
        set { this._EMP_EXIT_INTERVIEW_JOB_FRUSTRATION = value; }
    }

    private string _EMP_EXIT_INTERVIEW_COMPANY_MEASURES;
    public string EMP_EXIT_INTERVIEW_COMPANY_MEASURES
    {
        get { return (this._EMP_EXIT_INTERVIEW_COMPANY_MEASURES); }
        set { this._EMP_EXIT_INTERVIEW_COMPANY_MEASURES = value; }
    }
    private string _EMP_EXIT_INTERVIEW_SUGGESTION;
    public string EMP_EXIT_INTERVIEW_SUGGESTION
    {
        get { return (this._EMP_EXIT_INTERVIEW_SUGGESTION); }
        set { this._EMP_EXIT_INTERVIEW_SUGGESTION = value; }
    }
    private int _EMP_EXIT_INTERVIEW_EMPREG_ID;
    public int EMP_EXIT_INTERVIEW_EMPREG_ID
    {
        get { return (this._EMP_EXIT_INTERVIEW_EMPREG_ID); }
        set { this._EMP_EXIT_INTERVIEW_EMPREG_ID = value; }
    }



}
#endregion
#region SMHR_EXPENDITURE

public class SMHR_EXPENDITURE : SMHR_MAIN
{

    public SMHR_EXPENDITURE()
    {
    }
    private int _EXPENDITURE_ID;
    public int EXPENDITURE_ID
    {
        get { return (this._EXPENDITURE_ID); }
        set { this._EXPENDITURE_ID = value; }
    }

    private string _EXPENDITURE_NAME;
    public string EXPENDITURE_NAME
    {
        get { return (this._EXPENDITURE_NAME); }
        set { this._EXPENDITURE_NAME = value; }
    }
    private string _EXPENDITURE_DESC;
    public string EXPENDITURE_DESC
    {
        get { return (this._EXPENDITURE_DESC); }
        set { this._EXPENDITURE_DESC = value; }
    }
}

#endregion

#region SMHR_MISSION_ABOUTUS

public class SMHR_MISSION_ABOUTUS : SMHR_MAIN
{
    public SMHR_MISSION_ABOUTUS(int __MISSION_ABOUTUS_ID)
    {
        this._MISSION_ABOUTUS_ID = __MISSION_ABOUTUS_ID;
    }

    public SMHR_MISSION_ABOUTUS()
    {
    }
    private int _MISSION_ABOUTUS_ID;
    public int MISSION_ABOUTUS_ID
    {
        get { return (this._MISSION_ABOUTUS_ID); }
        set { this._MISSION_ABOUTUS_ID = value; }
    }

    private int _MISSION_ABOUTUS_ORGANISATION_ID;
    public int MISSION_ABOUTUS_ORGANISATION_ID
    {
        get { return (this._MISSION_ABOUTUS_ORGANISATION_ID); }
        set { this._MISSION_ABOUTUS_ORGANISATION_ID = value; }
    }

    private string _MISSION_ABOUTUS_MISSIONDESC;
    public string MISSION_ABOUTUS_MISSIONDESC
    {
        get { return (this._MISSION_ABOUTUS_MISSIONDESC); }
        set { this._MISSION_ABOUTUS_MISSIONDESC = value; }
    }

    private string _MISSION_ABOUTUS_ABOUTUSDESC;
    public string MISSION_ABOUTUS_ABOUTUSDESC
    {
        get { return (this._MISSION_ABOUTUS_ABOUTUSDESC); }
        set { this._MISSION_ABOUTUS_ABOUTUSDESC = value; }
    }

    private bool _MISSION_ABOUTUS_ISASSEMBLY;
    public bool MISSION_ABOUTUS_ISASSEMBLY
    {
        get { return (this._MISSION_ABOUTUS_ISASSEMBLY); }
        set { this._MISSION_ABOUTUS_ISASSEMBLY = value; }
    }

    private bool _MISSION_ABOUTUS_ISSENATE;
    public bool MISSION_ABOUTUS_ISSENATE
    {
        get { return (this._MISSION_ABOUTUS_ISSENATE); }
        set { this._MISSION_ABOUTUS_ISSENATE = value; }
    }
}

#endregion

#region Medical  Benfits

public class SMHR_MEDICALBENFIT : SMHR_MAIN
{

    public SMHR_MEDICALBENFIT()
    {
    }
    private int id;

    public int ID
    {
        get { return id; }
        set { id = value; }
    }

    private int orgID;

    public int OrgID
    {
        get { return orgID; }
        set { orgID = value; }
    }
    private int scaleID;

    public int ScaleID
    {
        get { return scaleID; }
        set { scaleID = value; }
    }

    private string scaleName;

    public string ScaleName
    {
        get { return scaleName; }
        set { scaleName = value; }
    }

    private string expendName;

    public string ExpendName
    {
        get { return expendName; }
        set { expendName = value; }
    }

    private int expendID;

    public int ExpendID
    {
        get { return expendID; }
        set { expendID = value; }
    }

    private double maxAmount;

    public double MaxAmount
    {
        get { return maxAmount; }
        set { maxAmount = value; }
    }
    private int financialPeriodID;

    public int FinancialPeriodID
    {
        get { return financialPeriodID; }
        set { financialPeriodID = value; }
    }
    private DataTable gradeWiseAmount;

    public DataTable GradeWiseAmount
    {
        get { return gradeWiseAmount; }
        set { gradeWiseAmount = value; }
    }
   
    public int MEDICALBENFIT_CREATEDBY { get; set; }
    public DateTime MEDICALBENFIT_CREATEDDATE { get; set; }
    public int MEDICALBENFIT_MDFBY { get; set; }
    public DateTime MEDICALBENFIT_MDFDATE { get; set; }
}

#endregion

#region Employee Grade Slabs
public class SMHR_EMPLOYEEGRADE_SLAB : SMHR_MAIN
{
    public SMHR_EMPLOYEEGRADE_SLAB(int __EMPLOYEEGRADE_SLAB_ID)
    {
        this._EMPLOYEEGRADE_SLAB_ID = __EMPLOYEEGRADE_SLAB_ID;
    }

    public SMHR_EMPLOYEEGRADE_SLAB()
    {
    }
    private int _EMPLOYEEGRADE_SLAB_ID;
    public int EMPLOYEEGRADE_SLAB_ID
    {
        get { return (this._EMPLOYEEGRADE_SLAB_ID); }
        set { this._EMPLOYEEGRADE_SLAB_ID = value; }
    }

    private int _EMPLOYEEGRADE_SLAB_ORGANISATION_ID;
    public int EMPLOYEEGRADE_SLAB_ORGANISATION_ID
    {
        get { return (this._EMPLOYEEGRADE_SLAB_ORGANISATION_ID); }
        set { this._EMPLOYEEGRADE_SLAB_ORGANISATION_ID = value; }
    }

    private int _EMPLOYEEGRADE_SLAB_EMPLOYEEGRADE_ID;
    public int EMPLOYEEGRADE_SLAB_EMPLOYEEGRADE_ID
    {
        get { return (this._EMPLOYEEGRADE_SLAB_EMPLOYEEGRADE_ID); }
        set { this._EMPLOYEEGRADE_SLAB_EMPLOYEEGRADE_ID = value; }
    }

    private string _EMPLOYEEGRADE_SLAB_EMPLOYEEGRADE_CODE;
    public string EMPLOYEEGRADE_SLAB_EMPLOYEEGRADE_CODE
    {
        get { return (this._EMPLOYEEGRADE_SLAB_EMPLOYEEGRADE_CODE); }
        set { this._EMPLOYEEGRADE_SLAB_EMPLOYEEGRADE_CODE = value; }
    }

    private int _EMPLOYEEGRADE_SLAB_SRNO;
    public int EMPLOYEEGRADE_SLAB_SRNO
    {
        get { return (this._EMPLOYEEGRADE_SLAB_SRNO); }
        set { this._EMPLOYEEGRADE_SLAB_SRNO = value; }
    }

    private double _EMPLOYEEGRADE_SLAB_AMOUNT;
    public double EMPLOYEEGRADE_SLAB_AMOUNT
    {
        get { return (this._EMPLOYEEGRADE_SLAB_AMOUNT); }
        set { this._EMPLOYEEGRADE_SLAB_AMOUNT = value; }
    }

    private int _EMPLOYEEGRADE_SLAB_PERIOD_ID;
    public int EMPLOYEEGRADE_SLAB_PERIOD_ID
    {
        get { return (this._EMPLOYEEGRADE_SLAB_PERIOD_ID); }
        set { this._EMPLOYEEGRADE_SLAB_PERIOD_ID = value; }
    }

    private bool _EMPLOYEEGRADE_SLAB_ISFINALIZED;
    public bool EMPLOYEEGRADE_SLAB_ISFINALIZED
    {
        get { return (this._EMPLOYEEGRADE_SLAB_ISFINALIZED); }
        set { this._EMPLOYEEGRADE_SLAB_ISFINALIZED = value; }
    }

    private DataTable _GRADESLABS;
    public DataTable GRADESLABS
    {
        get { return (this._GRADESLABS); }
        set { this._GRADESLABS = value; }
    }
}
#endregion

#region MedicalClaim
public class SMHR_MedicalClaim : SMHR_MAIN
{

    public SMHR_MedicalClaim()
    {
    }
    private int claimId;

    public int ClaimID
    {
        get { return claimId; }
        set { claimId = value; }
    }

    private int empID;

    public int EmpID
    {
        get { return empID; }
        set { empID = value; }
    }
    private string cliamType;

    private int _FIN_PRD_ID;
    public int FIN_PRD_ID
    {
        get { return (this._FIN_PRD_ID); }
        set { this._FIN_PRD_ID = value; }
    }

    public string CliamType
    {
        get { return cliamType; }
        set { cliamType = value; }
    }
    private int benficiarySerialId;

    public int BenficiarySerialId
    {
        get { return benficiarySerialId; }
        set { benficiarySerialId = value; }
    }

    private string benficiaryName;

    public string BenficiaryName
    {
        get { return benficiaryName; }
        set { benficiaryName = value; }
    }

    private int relationID;

    public int RelationID
    {
        get { return relationID; }
        set { relationID = value; }
    }

    private string serviceProviderName;

    public string ServiceProviderName
    {
        get { return serviceProviderName; }
        set { serviceProviderName = value; }
    }
    private int expenditureID;

    public int ExpenditureID
    {
        get { return expenditureID; }
        set { expenditureID = value; }
    }

    public double MED_FINAL_AMNT { get; set; }
    public string OTHER_EXPND_NAME { get; set; }

    private double amount;

    public double Amount
    {
        get { return amount; }
        set { amount = value; }
    }

    private string invoiceDocument;

    public string InvoiceDocument
    {
        get { return invoiceDocument; }
        set { invoiceDocument = value; }
    }

    private string invoiceID;

    public string InvoiceID
    {
        get { return invoiceID; }
        set { invoiceID = value; }
    }

    private DateTime invoiceDate;

    public DateTime InvoiceDate
    {
        get { return invoiceDate; }
        set { invoiceDate = value; }
    }

    public int SERVICEPROVIDERID { get; set; }

    public int MED_CURR_ID { get; set; }
    public decimal MED_CURR_AMT { get; set; }
    public decimal MED_CONVERSION_AMT { get; set; }
    public int MED_CONFIRMEDBY { get; set; }
    public int MED_APPROVEDBY { get; set; }
    public DateTime MED_APPROVEDDATE { get; set; }
    public DateTime MED_CONFIRMEDDATE { get; set; }
    public bool MED_ISRULEID { get; set; }
}
#endregion

public class SMHR_MedicalInvoice : SMHR_MAIN
{

    public SMHR_MedicalInvoice()
    {
    }
    private int invoiceDocID;

    public int InvoiceDocID
    {
        get { return invoiceDocID; }
        set { invoiceDocID = value; }
    }

    private int serviceProviderID;

    public int ServiceProviderID
    {
        get { return serviceProviderID; }
        set { serviceProviderID = value; }
    }

    private string invoiceDoc;

    public string InvoiceDoc
    {
        get { return invoiceDoc; }
        set { invoiceDoc = value; }
    }

    private DataTable medicalInvoice;

    public DataTable MedicalInvoice
    {
        get { return medicalInvoice; }
        set { medicalInvoice = value; }
    }
}

#region OrganisationChart
public class SMHR_OrganisationChart : SMHR_MAIN
{
    private int _ID;
    public int ID
    {
        get { return _ID; }
        set { _ID = value; }
    }
    private int _ParentID;

    public int ParentID
    {
        get { return _ParentID; }
        set { _ParentID = value; }
    }
}

#endregion

#region Helath and Safety
# region SMHR_ACTIVITY

public class SMHR_ACTIVITY : SMHR_MAIN
{
    private int _SMHR_ACTIVITY_ID;
    public int SMHR_ACTIVITY_ID
    {
        get { return _SMHR_ACTIVITY_ID; }
        set { _SMHR_ACTIVITY_ID = value; }
    }
    private string _SMHR_ACTIVITY_NAME;
    public string SMHR_ACTIVITY_NAME
    {
        get { return _SMHR_ACTIVITY_NAME; }
        set { _SMHR_ACTIVITY_NAME = value; }
    }
    private string _SMHR_ACTIVITY_DESCRIPTION;
    public string SMHR_ACTIVITY_DESCRIPTION
    {
        get { return _SMHR_ACTIVITY_DESCRIPTION; }
        set { _SMHR_ACTIVITY_DESCRIPTION = value; }
    }
    private int _SMHR_ACTIVITY_CREATEDBY;
    public int SMHR_ACTIVITY_CREATEDBY
    {
        get { return _SMHR_ACTIVITY_CREATEDBY; }
        set { _SMHR_ACTIVITY_CREATEDBY = value; }
    }
    private DateTime _SMHR_ACTIVITY_CREATEDDATE;
    public DateTime SMHR_ACTIVITY_CREATEDDATE
    {
        get { return _SMHR_ACTIVITY_CREATEDDATE; }
        set { _SMHR_ACTIVITY_CREATEDDATE = value; }

    }
    private int _SMHR_ACTIVITY_MODIFIEDBY;
    public int SMHR_ACTIVITY_MODIFIEDBY
    {
        get { return _SMHR_ACTIVITY_MODIFIEDBY; }
        set { _SMHR_ACTIVITY_MODIFIEDBY = value; }

    }
    private DateTime _SMHR_ACTIVITY_MODIFIEDDATE;
    public DateTime SMHR_ACTIVITY_MODIFIEDDATE
    {
        get { return _SMHR_ACTIVITY_MODIFIEDDATE; }
        set { _SMHR_ACTIVITY_MODIFIEDDATE = value; }
    }
    private bool _SMHR_ACTIVITY_ISACTIVE;
    public bool SMHR_ACTIVITY_ISACTIVE
    {
        get { return _SMHR_ACTIVITY_ISACTIVE; }
        set { _SMHR_ACTIVITY_ISACTIVE = value; }

    }
    private int _SMHR_ACTIVITY_PROTECTIVEUNIFORM_ID;
    public int SMHR_ACTIVITY_PROTECTIVEUNIFORM_ID
    {
        get { return _SMHR_ACTIVITY_PROTECTIVEUNIFORM_ID; }
        set { _SMHR_ACTIVITY_PROTECTIVEUNIFORM_ID = value; }
    }
}
# endregion
#region SMHR_EQUIPMENT
public class SMHR_EQUIPMENT : SMHR_MAIN
{
    private int _EQUIPMENT_ID;
    public int EQUIPMENT_ID
    {
        get { return _EQUIPMENT_ID; }
        set { _EQUIPMENT_ID = value; }
    }
    private string _EQUIPMENT_NAME;
    public string EQUIPMENT_NAME
    {
        get { return _EQUIPMENT_NAME; }
        set { _EQUIPMENT_NAME = value; }
    }
    private DateTime _EQUIPMENT_EXPIRYDATE;
    public DateTime EQUIPMENT_EXPIRYDATE
    {
        get { return _EQUIPMENT_EXPIRYDATE; }
        set { _EQUIPMENT_EXPIRYDATE = value; }
    }
    private int _EQUIPMENT_DIRECTORATE_ID;
    public int EQUIPMENT_DIRECTORATE_ID
    {
        get { return _EQUIPMENT_DIRECTORATE_ID; }
        set { _EQUIPMENT_DIRECTORATE_ID = value; }
    }
    private int _EQUIPMENT_DEPARTMENT_ID;
    public int EQUIPMENT_DEPARTMENT_ID
    {
        get { return _EQUIPMENT_DEPARTMENT_ID; }
        set { _EQUIPMENT_DEPARTMENT_ID = value; }
    }
    private int _EQUIPMENT_SUBDEPARTMNET;
    public int EQUIPMENT_SUBDEPARTMNET
    {
        get { return _EQUIPMENT_SUBDEPARTMNET; }
        set { _EQUIPMENT_SUBDEPARTMNET = value; }
    }
    private int _EQUIPMENT_CREATEDBY;
    public int EQUIPMENT_CREATEDBY
    {
        get { return _EQUIPMENT_CREATEDBY; }
        set { _EQUIPMENT_CREATEDBY = value; }
    }
    private DateTime _EQUIPMENT_CREATEDDATE;
    public DateTime EQUIPMENT_CREATEDDATE
    {
        get { return _EQUIPMENT_CREATEDDATE; }
        set { _EQUIPMENT_CREATEDDATE = value; }
    }
    private int _EQUIPMENT_MODIFIEDBY;
    public int EQUIPMENT_MODIFIEDBY
    {
        get { return _EQUIPMENT_MODIFIEDBY; }
        set { _EQUIPMENT_MODIFIEDBY = value; }
    }
    private DateTime _EQUIPMENT_MODIFIEDDATE;
    public DateTime EQUIPMENT_MODIFIEDDATE
    {
        get { return _EQUIPMENT_MODIFIEDDATE; }
        set { _EQUIPMENT_MODIFIEDDATE = value; }
    }
    private bool _EQUIPMENT_ISACTIVE;
    public bool EQUIPMENT_ISACTIVE
    {
        get { return _EQUIPMENT_ISACTIVE; }
        set { _EQUIPMENT_ISACTIVE = value; }
    }

}
#endregion
#region SMHR_AREA
public class SMHR_AREA : SMHR_MAIN
{
    private string _AREA_NAME;
    public string AREA_NAME
    {
        get { return _AREA_NAME; }
        set { _AREA_NAME = value; }
    }
    private int _AREA_ID;
    public int AREA_ID
    {
        get { return _AREA_ID; }
        set { _AREA_ID = value; }
    }
    private string _AREA_DESCRIPTION;
    public string AREA_DESCRIPTION
    {
        get { return _AREA_DESCRIPTION; }
        set { _AREA_DESCRIPTION = value; }
    }
    public int _AREA_BUSINESSUNIT_ID;
    public int AREA_BUSINESSUNIT_ID
    {
        get { return _AREA_BUSINESSUNIT_ID; }
        set { _AREA_BUSINESSUNIT_ID = value; }
    }
    private int _AREA_DIRECTORATE_ID;
    public int AREA_DIRECTORATE_ID
    {
        get { return _AREA_DIRECTORATE_ID; }
        set { _AREA_DIRECTORATE_ID = value; }
    }
    private int _AREA_DEPARTMENT_ID;
    public int AREA_DEPARTMENT_ID
    {
        get { return _AREA_DEPARTMENT_ID; }
        set { _AREA_DEPARTMENT_ID = value; }
    }
    private int _AREA_SUBDEPARTMENT_ID;
    public int AREA_SUBDEPARTMENT_ID
    {
        get { return _AREA_SUBDEPARTMENT_ID; }
        set { _AREA_SUBDEPARTMENT_ID = value; }
    }
    private int _AREA_CREATED_BY;
    public int AREA_CREATED_BY
    {
        get { return _AREA_CREATED_BY; }
        set { _AREA_CREATED_BY = value; }
    }
    private DateTime _AREA_CREATED_DATE;
    public DateTime AREA_CREATED_DATE
    {
        get { return _AREA_CREATED_DATE; }
        set { _AREA_CREATED_DATE = value; }
    }
    private int _AREA_MODIFIED_BY;
    public int AREA_MODIFIED_BY
    {
        get { return _AREA_MODIFIED_BY; }
        set { _AREA_MODIFIED_BY = value; }
    }
    private DateTime _AREA_MODIFIED_DATE;
    public DateTime AREA_MODIFIED_DATE
    {
        get { return _AREA_MODIFIED_DATE; }
        set { _AREA_MODIFIED_DATE = value; }
    }
    private bool _AREA_IS_ACTIVE;
    public bool AREA_IS_ACTIVE
    {
        get { return _AREA_IS_ACTIVE; }
        set { _AREA_IS_ACTIVE = value; }
    }
}
# endregion
#region  SMHR_INSPECTION
public class SMHR_INSPECTION : SMHR_MAIN
{

    private int _INSPECTION_ID;
    public int INSPECTION_ID
    {
        get { return _INSPECTION_ID; }
        set { _INSPECTION_ID = value; }
    }
    private string _INSPECTION_NAME;
    public string INSPECTION_NAME
    {
        get { return _INSPECTION_NAME; }
        set { _INSPECTION_NAME = value; }
    }
    private string _INSPECTION_DESCRIPTION;
    public string INSPECTION_DESCRIPTION
    {
        get { return _INSPECTION_DESCRIPTION; }
        set { _INSPECTION_DESCRIPTION = value; }
    }
    private int _INSPECTION_BU_ID;
    public int INSPECTION_BU_ID
    {
        get { return _INSPECTION_BU_ID; }
        set { _INSPECTION_BU_ID = value; }
    }
    private int _INSPECTION_DIRECTORATE_ID;
    public int INSPECTION_DIRECTORATE_ID
    {
        get { return _INSPECTION_DIRECTORATE_ID; }
        set { _INSPECTION_DIRECTORATE_ID = value; }
    }
    private int _INSPECTION_DEPARTMENT_ID;
    public int INSPECTION_DEPARTMENT_ID
    {
        get { return _INSPECTION_DEPARTMENT_ID; }
        set { _INSPECTION_DEPARTMENT_ID = value; }
    }
    private int _INSPECTION_SUBDEPARTMENT_ID;
    public int INSPECTION_SUBDEPARTMENT_ID
    {
        get { return _INSPECTION_SUBDEPARTMENT_ID; }
        set { _INSPECTION_SUBDEPARTMENT_ID = value; }
    }

    private int _INSPECTION_CREATEDBY;
    public int INSPECTION_CREATEDBY
    {
        get { return _INSPECTION_CREATEDBY; }
        set { _INSPECTION_CREATEDBY = value; }
    }
    private DateTime _INSPECTION_CREATEDDATE;
    public DateTime INSPECTION_CREATEDDATE
    {
        get { return _INSPECTION_CREATEDDATE; }
        set { _INSPECTION_CREATEDDATE = value; }
    }
    private int _INSPECTION_MODIFIEDBY;
    public int INSPECTION_MODIFIEDBY
    {
        get { return _INSPECTION_MODIFIEDBY; }
        set { _INSPECTION_MODIFIEDBY = value; }
    }
    private DateTime _INSPECTION_MODIFIEDDATE;
    public DateTime INSPECTION_MODIFIEDDATE
    {
        get { return _INSPECTION_MODIFIEDDATE; }
        set { _INSPECTION_MODIFIEDDATE = value; }
    }
    private bool _INSPECTION_ISACTIVE;
    public bool INSPECTION_ISACTIVE
    {
        get { return _INSPECTION_ISACTIVE; }
        set { _INSPECTION_ISACTIVE = value; }
    }
    private int _INSPECTION_ASSIGNED_TO;
    public int INSPECTION_ASSIGNED_TO
    {
        get { return _INSPECTION_ASSIGNED_TO; }
        set { _INSPECTION_ASSIGNED_TO = value; }
    }
    private DateTime _INSPECTION_FROMDATE;
    public DateTime INSPECTION_FROMDATE
    {
        get { return _INSPECTION_FROMDATE; }
        set { _INSPECTION_FROMDATE = value; }
    }
    private DateTime _INSPECTION_TODATE;
    public DateTime INSPECTION_TODATE
    {
        get { return _INSPECTION_TODATE; }
        set { _INSPECTION_TODATE = value; }
    }
    private DateTime _INSPECTION_FROMTIME;
    public DateTime INSPECTION_FROMTIME
    {
        get { return _INSPECTION_FROMTIME; }
        set { _INSPECTION_FROMTIME = value; }
    }
    private DateTime _INSPECTION_TOTIME;
    public DateTime INSPECTION_TOTIME
    {
        get { return _INSPECTION_TOTIME; }
        set { _INSPECTION_TOTIME = value; }
    }
    private int _INSPECTION_AREA_ID;
    public int INSPECTION_AREA_ID
    {
        get { return _INSPECTION_AREA_ID; }
        set { _INSPECTION_AREA_ID = value; }
    }
    private int _AREA_ID;
    public int AREA_ID
    {
        get { return _AREA_ID; }
        set { _AREA_ID = value; }
    }
    private int _INSPECTION_INSPECTION_ID;
    public int INSPECTION_INSPECTION_ID
    {
        get { return _INSPECTION_INSPECTION_ID; }
        set { _INSPECTION_INSPECTION_ID = value; }
    }
    private bool _INSPECTION_AREA_ISCOMPLIANT;
    public bool INSPECTION_AREA_ISCOMPLIANT
    {
        get { return _INSPECTION_AREA_ISCOMPLIANT; }
        set { _INSPECTION_AREA_ISCOMPLIANT = value; }
    }
    private string _INSPECTION_AREA_COMMENTS;
    public string INSPECTION_AREA_COMMENTS
    {
        get { return _INSPECTION_AREA_COMMENTS; }
        set { _INSPECTION_AREA_COMMENTS = value; }
    }
    private int _INSPECTION_AREA_CREATED_BY;
    public int INSPECTION_AREA_CREATED_BY
    {
        get { return _INSPECTION_AREA_CREATED_BY; }
        set { _INSPECTION_AREA_CREATED_BY = value; }
    }
    private DateTime _INSPECTION_AREA_CREATEDDATE;
    public DateTime INSPECTION_AREA_CREATEDDATE
    {
        get { return _INSPECTION_AREA_CREATEDDATE; }
        set { _INSPECTION_AREA_CREATEDDATE = value; }
    }
    private int _INSPECTION_AREA_MODIFIED_BY;
    public int INSPECTION_AREA_MODIFIED_BY
    {
        get { return _INSPECTION_AREA_MODIFIED_BY; }
        set { _INSPECTION_AREA_MODIFIED_BY = value; }
    }
    private DateTime _INSPECTION_AREA_MODIFIEDDATE;
    public DateTime INSPECTION_AREA_MODIFIEDDATE
    {
        get { return _INSPECTION_AREA_MODIFIEDDATE; }
        set { _INSPECTION_AREA_MODIFIEDDATE = value; }
    }

}
public class SMHR_INSPECTION_SCHEDULE : SMHR_MAIN
{
    private int _LOGIN_EMP_ID;
    public int LOGIN_EMP_ID
    {
        get { return _LOGIN_EMP_ID; }
        set { _LOGIN_EMP_ID = value; }
    }
    private int _INSPECTION_SCHEDULE_ID;
    public int INSPECTION_SCHEDULE_ID
    {
        get { return _INSPECTION_SCHEDULE_ID; }
        set { _INSPECTION_SCHEDULE_ID = value; }
    }
    private int _INSPECTION_SCHEDULE_INSPECTION_ID;
    public int INSPECTION_SCHEDULE_INSPECTION_ID
    {
        get { return _INSPECTION_SCHEDULE_INSPECTION_ID; }
        set { _INSPECTION_SCHEDULE_INSPECTION_ID = value; }
    }
    private int _INSPECTION_SCHEDULE_ASSIGNED_TO;
    public int INSPECTION_SCHEDULE_ASSIGNED_TO
    {
        get { return _INSPECTION_SCHEDULE_ASSIGNED_TO; }
        set { _INSPECTION_SCHEDULE_ASSIGNED_TO = value; }
    }

    private DateTime _INSPECTION_SCHEDULE_FROMDATE;
    public DateTime INSPECTION_SCHEDULE_FROMDATE
    {
        get { return _INSPECTION_SCHEDULE_FROMDATE; }
        set { _INSPECTION_SCHEDULE_FROMDATE = value; }
    }
    private DateTime _INSPECTION_SCHEDULE_TODATE;
    public DateTime INSPECTION_SCHEDULE_TODATE
    {
        get { return _INSPECTION_SCHEDULE_TODATE; }
        set { _INSPECTION_SCHEDULE_TODATE = value; }
    }

    private DateTime _INSPECTION_SCHEDULE_FROMTIME;
    public DateTime INSPECTION_SCHEDULE_FROMTIME
    {
        get { return _INSPECTION_SCHEDULE_FROMTIME; }
        set { _INSPECTION_SCHEDULE_FROMTIME = value; }
    }
    private DateTime _INSPECTION_SCHEDULE_TOTIME;
    public DateTime INSPECTION_SCHEDULE_TOTIME
    {
        get { return _INSPECTION_SCHEDULE_TOTIME; }
        set { _INSPECTION_SCHEDULE_TOTIME = value; }
    }

    private int _INSPECTION_SCHEDULE_CREATEDBY;
    public int INSPECTION_SCHEDULE_CREATEDBY
    {
        get { return _INSPECTION_SCHEDULE_CREATEDBY; }
        set { _INSPECTION_SCHEDULE_CREATEDBY = value; }
    }
    private DateTime _INSPECTION_SCHEDULE_CREATEDDATE;
    public DateTime INSPECTION_SCHEDULE_CREATEDDATE
    {
        get { return _INSPECTION_SCHEDULE_CREATEDDATE; }
        set { _INSPECTION_SCHEDULE_CREATEDDATE = value; }
    }

    private int _INSPECTION_SCHEDULE_MODIFIEDBY;
    public int INSPECTION_SCHEDULE_MODIFIEDBY
    {
        get { return _INSPECTION_SCHEDULE_MODIFIEDBY; }
        set { _INSPECTION_SCHEDULE_MODIFIEDBY = value; }
    }

    private DateTime _INSPECTION_SCHEDULE_MODIFIEDDATE;
    public DateTime INSPECTION_SCHEDULE_MODIFIEDDATE
    {
        get { return _INSPECTION_SCHEDULE_MODIFIEDDATE; }
        set { _INSPECTION_SCHEDULE_MODIFIEDDATE = value; }
    }

    private bool _INSPECTION_SCHEDULE_ISACTIVE;
    public bool INSPECTION_SCHEDULE_ISACTIVE
    {
        get { return _INSPECTION_SCHEDULE_ISACTIVE; }
        set { _INSPECTION_SCHEDULE_ISACTIVE = value; }
    }
}
public class SMHR_INSPECTION_AREA : SMHR_AREA
{
    private int _INSPECTION_SCHEDULE_ID;
    public int INSPECTION_SCHEDULE_ID
    {
        get { return _INSPECTION_SCHEDULE_ID; }
        set { _INSPECTION_SCHEDULE_ID = value; }
    }

    private int _INSPECTION_AREA_ID;
    public int INSPECTION_AREA_ID
    {
        get { return _INSPECTION_AREA_ID; }
        set { _INSPECTION_AREA_ID = value; }
    }
    private int _INSPECTION_AREA_SCHEDULE_ID;
    public int INSPECTION_AREA_SCHEDULE_ID
    {
        get { return _INSPECTION_AREA_SCHEDULE_ID; }
        set { _INSPECTION_AREA_SCHEDULE_ID = value; }
    }
    private int _AREA_ID;
    public int AREA_ID
    {
        get { return _AREA_ID; }
        set { _AREA_ID = value; }
    }

    private bool _INSPECTION_AREA_ISCOMPLIANT;
    public bool INSPECTION_AREA_ISCOMPLIANT
    {
        get { return _INSPECTION_AREA_ISCOMPLIANT; }
        set { _INSPECTION_AREA_ISCOMPLIANT = value; }
    }
    private string _INSPECTION_AREA_COMMENTS;
    public string INSPECTION_AREA_COMMENTS
    {
        get { return _INSPECTION_AREA_COMMENTS; }
        set { _INSPECTION_AREA_COMMENTS = value; }
    }
    private int _INSPECTION_AREA_CREATED_BY;
    public int INSPECTION_AREA_CREATED_BY
    {
        get { return _INSPECTION_AREA_CREATED_BY; }
        set { _INSPECTION_AREA_CREATED_BY = value; }
    }
    private DateTime _INSPECTION_AREA_CREATEDDATE;
    public DateTime INSPECTION_AREA_CREATEDDATE
    {
        get { return _INSPECTION_AREA_CREATEDDATE; }
        set { _INSPECTION_AREA_CREATEDDATE = value; }
    }
    private int _INSPECTION_AREA_MODIFIED_BY;
    public int INSPECTION_AREA_MODIFIED_BY
    {
        get { return _INSPECTION_AREA_MODIFIED_BY; }
        set { _INSPECTION_AREA_MODIFIED_BY = value; }
    }

    private DateTime _INSPECTION_AREA_MODIFIEDDATE;
    public DateTime INSPECTION_AREA_MODIFIEDDATE
    {
        get { return _INSPECTION_AREA_MODIFIEDDATE; }
        set { _INSPECTION_AREA_MODIFIEDDATE = value; }
    }
}

#endregion
#endregion

#region Workman Compensation
public class SMHR_WorkmanCompensation : SMHR_MAIN
{
    private int _IncidentID;
    public int IncidentID
    {
        get { return _IncidentID; }
        set { _IncidentID = value; }
    }

    private string _IncidentName;
    public string IncidentName
    {
        get { return _IncidentName; }
        set { _IncidentName = value; }
    }

    private string _IncidentCode;
    public string IncidentCode
    {
        get { return _IncidentCode; }
        set { _IncidentCode = value; }
    }

    private DateTime _IncidentDateTime;
    public DateTime IncidentDatetime
    {
        get { return _IncidentDateTime; }
        set { _IncidentDateTime = value; }
    }

    private string _IncidentPlace;
    public string IncidentPlace
    {
        get { return _IncidentPlace; }
        set { _IncidentPlace = value; }
    }

    private int _EmpID;
    public int EmpID
    {
        get { return _EmpID; }
        set { _EmpID = value; }
    }

    private int _IncidentCauseID;
    public int IncidentCauseID
    {
        get { return _IncidentCauseID; }
        set { _IncidentCauseID = value; }
    }

    private int _InicidentTypeID;
    public int InicidentTypeID
    {
        get { return _InicidentTypeID; }
        set { _InicidentTypeID = value; }
    }

    private int _SeverityID;
    public int SeverityID
    {
        get { return _SeverityID; }
        set { _SeverityID = value; }
    }

    private string _Remarks;
    public string Remarks
    {
        get { return _Remarks; }
        set { _Remarks = value; }
    }


}
#endregion

#region SMHR_TOWN

public class SMHR_TOWN : SMHR_MAIN
{
    public SMHR_TOWN(int __TOWN_ID)
    {
        this._TOWN_ID = __TOWN_ID;
    }

    public SMHR_TOWN()
    {
    }
    private int _TOWN_ID;
    public int TOWN_ID
    {
        get { return (this._TOWN_ID); }
        set { this._TOWN_ID = value; }
    }
    private int _COUNTY_ID;
    public int COUNTY_ID
    {
        get { return (this._COUNTY_ID); }
        set { this._COUNTY_ID = value; }
    }

    private string _TOWN_CODE;
    public string TOWN_CODE
    {
        get { return (this._TOWN_CODE); }
        set { this._TOWN_CODE = value; }
    }

    private string _TOWN_DESCRIPTION;
    public string TOWN_DESCRIPTION
    {
        get { return (this._TOWN_DESCRIPTION); }
        set { this._TOWN_DESCRIPTION = value; }
    }
}

#endregion

#region Location
public class SMHR_TRAINING_LOCATION : SMHR_MAIN
{
    private int _LocationID;

    public int LocationID
    {
        get { return _LocationID; }
        set { _LocationID = value; }
    }

    private string _LocationName;

    public string LocationName
    {
        get { return _LocationName; }
        set { _LocationName = value; }
    }

    private string _Location_StreetName;

    public string Location_StreetName
    {
        get { return _Location_StreetName; }
        set { _Location_StreetName = value; }
    }

    private int _Location_CountryID;

    public int Location_CountryID
    {
        get { return _Location_CountryID; }
        set { _Location_CountryID = value; }
    }

    private int _Location_CountyID;

    public int Location_CountyID
    {
        get { return _Location_CountyID; }
        set { _Location_CountyID = value; }
    }

    private int _Location_TownID;

    public int Location_TownID
    {
        get { return _Location_TownID; }
        set { _Location_TownID = value; }
    }

    private string _Location_ContactPerson;

    public string Location_ContactPerson
    {
        get { return _Location_ContactPerson; }
        set { _Location_ContactPerson = value; }
    }

    private string _Location_EmailID;

    public string Location_EmailID
    {
        get { return _Location_EmailID; }
        set { _Location_EmailID = value; }
    }

    private string _Location_ContactNo;

    public string Location_ContactNo
    {
        get { return _Location_ContactNo; }
        set { _Location_ContactNo = value; }
    }

    private string _Location_AlternateContactNo;

    public string Location_AlternateContactNo
    {
        get { return _Location_AlternateContactNo; }
        set { _Location_AlternateContactNo = value; }
    }

    private bool _Location_Status;

    public bool Location_Status
    {
        get { return _Location_Status; }
        set { _Location_Status = value; }
    }


}
#endregion
#region Grievance Handling

public class SMHR_GRIEVANCE : SMHR_MAIN
{
    public SMHR_GRIEVANCE()
    {
    }

    public SMHR_GRIEVANCE(int __GRIEVANCE_ID)
    {
        this._GRIEVANCE_ID = __GRIEVANCE_ID;
    }

    private int _GRIEVANCE_ID;
    public int GRIEVANCE_ID
    {
        get { return (this._GRIEVANCE_ID); }
        set { this._GRIEVANCE_ID = value; }
    }

    private int _GRIEVANCE_REPORTEDBY;
    public int GRIEVANCE_REPORTEDBY
    {
        get { return (this._GRIEVANCE_REPORTEDBY); }
        set { this._GRIEVANCE_REPORTEDBY = value; }
    }
    private int _GRIEVANCE_REPORTEDON;
    public int GRIEVANCE_REPORTEDON
    {
        get { return (this._GRIEVANCE_REPORTEDON); }
        set { this._GRIEVANCE_REPORTEDON = value; }
    }

    private string _GRIEVANCE_INCIDENTID;
    public string GRIEVANCE_INCIDENTID
    {
        get { return (this._GRIEVANCE_INCIDENTID); }
        set { this._GRIEVANCE_INCIDENTID = value; }
    }

    private string _GRIEVANCE_INCIDENT;
    public string GRIEVANCE_INCIDENT
    {
        get { return (this._GRIEVANCE_INCIDENT); }
        set { this._GRIEVANCE_INCIDENT = value; }
    }

    private int _GRIEVANCE_INCIDENTTYPE_ID;
    public int GRIEVANCE_INCIDENTTYPE_ID
    {
        get { return (this._GRIEVANCE_INCIDENTTYPE_ID); }
        set { this._GRIEVANCE_INCIDENTTYPE_ID = value; }
    }


    private DateTime? _GRIEVANCE_REPORTEDDATE;
    public DateTime? GRIEVANCE_REPORTEDDATE
    {
        get { return (this._GRIEVANCE_REPORTEDDATE); }
        set { this._GRIEVANCE_REPORTEDDATE = value; }
    }

    private string _GRIEVANCE_INCIDENTDESCRIPTION;
    public string GRIEVANCE_INCIDENTDESCRIPTION
    {
        get { return (this._GRIEVANCE_INCIDENTDESCRIPTION); }
        set { this._GRIEVANCE_INCIDENTDESCRIPTION = value; }
    }
    private int _GRIEVANCE_COMMITTEEID;

    public int GRIEVANCE_COMMITTEEID
    {
        get { return _GRIEVANCE_COMMITTEEID; }
        set { _GRIEVANCE_COMMITTEEID = value; }
    }

}

#endregion

#region  TRAINERPROFILE
public class SMHR_TRAINERPROFILE : SMHR_MAIN
{
    public SMHR_TRAINERPROFILE()
    {

    }
    private int _Trainer_TrainerProfile_ID;

    public int Trainer_TrainerProfile_ID
    {
        get { return (this._Trainer_TrainerProfile_ID); }
        set { this._Trainer_TrainerProfile_ID = value; }

    }

    private int _Trainer_ServiceProvider;

    public int Trainer_ServiceProvider
    {
        get { return (this._Trainer_ServiceProvider); }
        set { this._Trainer_ServiceProvider = value; }

    }

    private string _Trainer_UserName;

    public string Trainer_UserName
    {
        get { return (this._Trainer_UserName); }
        set { this._Trainer_UserName = value; }

    }

    private string _Trainer_Password;

    public string Trainer_Password
    {
        get { return (this._Trainer_Password); }
        set { this._Trainer_Password = value; }

    }

    private string _Trainer_ConfirmPassword;

    public string Trainer_ConfirmPassword
    {
        get { return (this._Trainer_ConfirmPassword); }
        set { this._Trainer_ConfirmPassword = value; }

    }

    private string _Trainer_FirstName;

    public string Trainer_FirstName
    {
        get { return (this._Trainer_FirstName); }
        set { this._Trainer_FirstName = value; }

    }

    private string _Trainer_LastName;

    public string Trainer_LastName
    {
        get { return (this._Trainer_LastName); }
        set { this._Trainer_LastName = value; }

    }

    private string _Trainer_MiddleName;

    public string Trainer_MiddleName
    {
        get { return (this._Trainer_MiddleName); }
        set { this._Trainer_MiddleName = value; }

    }

    private string _Trainer_HintQuestion;

    public string Trainer_HintQuestion
    {
        get { return (this._Trainer_HintQuestion); }
        set { this._Trainer_HintQuestion = value; }

    }

    private string _Trainer_Answer;

    public string Trainer_Answer
    {
        get { return (this._Trainer_Answer); }
        set { this._Trainer_Answer = value; }

    }

    private string _Trainer_EmailID;

    public string Trainer_EmailID
    {
        get { return (this._Trainer_EmailID); }
        set { this._Trainer_EmailID = value; }

    }

    private DateTime _Trainer_DOB;

    public DateTime Trainer_DOB
    {
        get { return (this._Trainer_DOB); }
        set { this._Trainer_DOB = value; }

    }

    private int _Trainer_Age;

    public int Trainer_Age
    {
        get { return (this._Trainer_Age); }
        set { this._Trainer_Age = value; }

    }

    private string _Trainer_LandlineNo;

    public string Trainer_LandlineNo
    {
        get { return (this._Trainer_LandlineNo); }
        set { this._Trainer_LandlineNo = value; }

    }

    private int _Trainer_TrainerTypeID;

    public int Trainer_TrainerTypeID
    {
        get { return (this._Trainer_TrainerTypeID); }
        set { this._Trainer_TrainerTypeID = value; }

    }

    private string _Trainer_Address1;

    public string Trainer_Address1
    {
        get { return (this._Trainer_Address1); }
        set { this._Trainer_Address1 = value; }

    }

    private string _Trainer_Address2;

    public string Trainer_Address2
    {
        get { return (this._Trainer_Address2); }
        set { this._Trainer_Address2 = value; }

    }
    private int _Trainer_CountryID;

    public int Trainer_CountryID
    {
        get { return (this._Trainer_CountryID); }
        set { this._Trainer_CountryID = value; }
    }
    private int _Trainer_CountyID;

    public int Trainer_CountyID
    {
        get { return (this._Trainer_CountyID); }
        set { this._Trainer_CountyID = value; }
    }
    private int _Trainer_TownID;

    public int Trainer_TownID
    {
        get { return (this._Trainer_TownID); }
        set { this._Trainer_TownID = value; }
    }

    private string _Trainer_ZipCode;

    public string Trainer_ZipCode
    {
        get { return (this._Trainer_ZipCode); }
        set { this._Trainer_ZipCode = value; }
    }
    private string _Trainer_MoblieNo;

    public string Trainer_MoblieNo
    {
        get { return (this._Trainer_MoblieNo); }
        set { this._Trainer_MoblieNo = value; }
    }
    private int _Trainer_CourseCategory;

    public int Trainer_CourseCategory
    {
        get { return (this._Trainer_CourseCategory); }
        set { this._Trainer_CourseCategory = value; }
    }

    private bool _Trainer_Status;

    public bool Trainer_Status
    {
        get { return (this._Trainer_Status); }
        set { this._Trainer_Status = value; }
    }
    private int _Trainer_Qualification;

    public int Trainer_Qualification
    {
        get { return (this._Trainer_Qualification); }
        set { this._Trainer_Qualification = value; }
    }
    private string _Trainer_Institute;

    public string Trainer_Institute
    {
        get { return (this._Trainer_Institute); }
        set { this._Trainer_Institute = value; }
    }
    private string _Trainer_YearOfPass;

    public string Trainer_YearOfPass
    {
        get { return (this._Trainer_YearOfPass); }
        set { this._Trainer_YearOfPass = value; }
    }
    private string _Trainer_Percentage;

    public string Trainer_Percentage
    {
        get { return (this._Trainer_Percentage); }
        set { this._Trainer_Percentage = value; }
    }

    private int _TRAINER_ORGID;

    public int TRAINER_ORGID
    {
        get { return _TRAINER_ORGID; }
        set { _TRAINER_ORGID = value; }
    }

    private DateTime _TRAINER_CREATEDDATE;

    public DateTime TRAINER_CREATEDDATE
    {
        get { return _TRAINER_CREATEDDATE; }
        set { _TRAINER_CREATEDDATE = value; }

    }
    private DateTime _TRAINER_MODIIFYEDDATE;

    public DateTime TRAINER_MODIIFYEDDATE
    {
        get { return _TRAINER_MODIIFYEDDATE; }
        set { _TRAINER_MODIIFYEDDATE = value; }

    }


    private int _TRAINER_MODIFYEDBY;
    public int TRAINER_MODIFYEDBY
    {
        get { return _TRAINER_MODIFYEDBY; }
        set { _TRAINER_MODIFYEDBY = value; }
    }

    private int _TRAINER_CREATEDBY;
    public int TRAINER_CREATEDBY
    {
        get { return _TRAINER_CREATEDBY; }
        set { _TRAINER_CREATEDBY = value; }
    }


}


#endregion

#region TrainingRoom
public class SMHR_TRAINING_ROOM : SMHR_MAIN
{
    private int _ROOMID;

    public int ROOMID
    {
        get { return _ROOMID; }
        set { _ROOMID = value; }
    }

    private string _ROOMNAME;

    public string ROOMNAME
    {
        get { return _ROOMNAME; }
        set { _ROOMNAME = value; }
    }

    private int _ROOMSTRENGTH;

    public int ROOMSTRENGTH
    {
        get { return _ROOMSTRENGTH; }
        set { _ROOMSTRENGTH = value; }
    }

    private int _ROOMS_LOCATION_ID;

    public int ROOMS_LOCATION_ID
    {
        get { return _ROOMS_LOCATION_ID; }
        set { _ROOMS_LOCATION_ID = value; }
    }

    private bool _ROOM_STATUS;

    public bool ROOM_STATUS
    {
        get { return _ROOM_STATUS; }
        set { _ROOM_STATUS = value; }
    }
    private SMHR_COURSESCHEDULE _SMHR_COURSESCHEDULE;

    public SMHR_COURSESCHEDULE SMHR_COURSESCHEDULE
    {
        get { return _SMHR_COURSESCHEDULE; }
        set { _SMHR_COURSESCHEDULE = value; }
    }

}
#endregion

#region CourseSchedule
public class SMHR_COURSESCHEDULE : SMHR_MAIN
{
    private int _COURSESCHEDULEID;

    public int COURSESCHEDULEID
    {
        get { return _COURSESCHEDULEID; }
        set { _COURSESCHEDULEID = value; }
    }

    private string _COURSESCHEDULE_NAME;

    public string COURSESCHEDULE_NAME
    {
        get { return _COURSESCHEDULE_NAME; }
        set { _COURSESCHEDULE_NAME = value; }
    }

    private int _COURSESCHEDULE_COURSEID;

    public int COURSESCHEDULE_COURSEID
    {
        get { return _COURSESCHEDULE_COURSEID; }
        set { _COURSESCHEDULE_COURSEID = value; }
    }

    private int _COURSESCHEDULE_COURSETYPEID;

    public int COURSESCHEDULE_COURSETYPEID
    {
        get { return _COURSESCHEDULE_COURSETYPEID; }
        set { _COURSESCHEDULE_COURSETYPEID = value; }
    }

    private int _COURSESCHEDULE_LOCATIONID;

    public int COURSESCHEDULE_LOCATIONID
    {
        get { return _COURSESCHEDULE_LOCATIONID; }
        set { _COURSESCHEDULE_LOCATIONID = value; }
    }
    private int _COURSESCHEDULE_ROOMID;

    public int COURSESCHEDULE_ROOMID
    {
        get { return _COURSESCHEDULE_ROOMID; }
        set { _COURSESCHEDULE_ROOMID = value; }
    }
    private int _COURSESCHEDULE_NOOFSESSIONS;

    public int COURSESCHEDULE_NOOFSESSIONS
    {
        get { return _COURSESCHEDULE_NOOFSESSIONS; }
        set { _COURSESCHEDULE_NOOFSESSIONS = value; }
    }
    private int _COURSESCHEDULE_NOOFSEATS;

    public int COURSESCHEDULE_NOOFSEATS
    {
        get { return _COURSESCHEDULE_NOOFSEATS; }
        set { _COURSESCHEDULE_NOOFSEATS = value; }
    }

    private int _COURSESCHEDULE_TRAINERID;

    public int COURSESCHEDULE_TRAINERID
    {
        get { return _COURSESCHEDULE_TRAINERID; }
        set { _COURSESCHEDULE_TRAINERID = value; }
    }

    private DateTime _COURSESCHEDULE_STARTDATE;

    public DateTime COURSESCHEDULE_STARTDATE
    {
        get { return _COURSESCHEDULE_STARTDATE; }
        set { _COURSESCHEDULE_STARTDATE = value; }
    }

    private DateTime _COURSESCHEDULE_SATARTTIME;

    public DateTime COURSESCHEDULE_SATARTTIME
    {
        get { return _COURSESCHEDULE_SATARTTIME; }
        set { _COURSESCHEDULE_SATARTTIME = value; }
    }

    private DateTime _COURSESCHEDULE_ENDDATE;

    public DateTime COURSESCHEDULE_ENDDATE
    {
        get { return _COURSESCHEDULE_ENDDATE; }
        set { _COURSESCHEDULE_ENDDATE = value; }
    }

    private DateTime _COURSESCHEDULE_ENDTIME;

    public DateTime COURSESCHEDULE_ENDTIME
    {
        get { return _COURSESCHEDULE_ENDTIME; }
        set { _COURSESCHEDULE_ENDTIME = value; }
    }

    private bool _COURSESCHEDULE_STATUS;

    public bool COURSESCHEDULE_STATUS
    {
        get { return _COURSESCHEDULE_STATUS; }
        set { _COURSESCHEDULE_STATUS = value; }
    }


}
#endregion

#region Chapter

public class SMHR_CHAPTERS : SMHR_MAIN
{
    private int _CHARPTER_ORGANISATION_ID;

    public int CHARPTER_ORGANISATION_ID
    {
        get { return _CHARPTER_ORGANISATION_ID; }
        set { _CHARPTER_ORGANISATION_ID = value; }
    }

    private string _CHAPTER_NAME;
    public string CHAPTER_NAME
    {
        get { return _CHAPTER_NAME; }
        set { _CHAPTER_NAME = value; }
    }

    private int _CHAPTER_COURSE_ID;
    public int CHAPTER_COURSE_ID
    {
        get { return _CHAPTER_COURSE_ID; }
        set { _CHAPTER_COURSE_ID = value; }
    }

    private string _CHAPTER_DESCRIPTION;

    public string CHAPTER_DESCRIPTION
    {
        get { return _CHAPTER_DESCRIPTION; }
        set { _CHAPTER_DESCRIPTION = value; }
    }
    private bool _CHAPTER_STATUS;
    public bool CHAPTER_STATUS
    {
        get { return _CHAPTER_STATUS; }
        set { _CHAPTER_STATUS = value; }
    }

    private int _CHAPTER_ID;

    public int CHAPTER_ID
    {
        get { return _CHAPTER_ID; }
        set { _CHAPTER_ID = value; }
    }

    private DateTime _CHAPTER_LASTMDFDATE;

    public DateTime CHAPTER_LASTMDFDATE
    {
        get { return _CHAPTER_LASTMDFDATE; }
        set { _CHAPTER_LASTMDFDATE = value; }

    }
    private DateTime _CHAPTER_CREATEDDATE;

    public DateTime CHAPTER_CREATEDDATE
    {
        get { return _CHAPTER_CREATEDDATE; }
        set { _CHAPTER_CREATEDDATE = value; }

    }


    private int _CHAPTER_LASTMDFDBY;
    public int CHAPTER_LASTMDFDBY
    {
        get { return _CHAPTER_LASTMDFDBY; }
        set { _CHAPTER_LASTMDFDBY = value; }
    }

    private int _CHAPTER_CREATEDBY;
    public int CHAPTER_CREATEDBY
    {
        get { return _CHAPTER_CREATEDBY; }
        set { _CHAPTER_CREATEDBY = value; }
    }

}





#endregion

#region SMHR_TRAINING_REQUST

public class SMHR_TRAINING_REQUST : SMHR_MAIN
{
    private int _TRAINING_REQUST_ID;

    public int TRAINING_REQUST_ID
    {
        get { return _TRAINING_REQUST_ID; }
        set { _TRAINING_REQUST_ID = value; }
    }

    private int _TRAINING_RAISEDBY;

    public int TRAINING_RAISEDBY
    {
        get { return _TRAINING_RAISEDBY; }
        set { _TRAINING_RAISEDBY = value; }
    }

    private int _TRAINING_APPROVEDBY;

    public int TRAINING_APPROVEDBY
    {
        get { return _TRAINING_APPROVEDBY; }
        set { _TRAINING_APPROVEDBY = value; }
    }

    private int _TRAINING_BATCHID;

    public int TRAINING_BATCHID
    {
        get { return _TRAINING_BATCHID; }
        set { _TRAINING_BATCHID = value; }
    }

    private int _TRAINING_COURSEID;

    public int TRAINING_COURSEID
    {
        get { return _TRAINING_COURSEID; }
        set { _TRAINING_COURSEID = value; }
    }

    private int _TRAINING_ISAPPROVED;

    public int TRAINING_ISAPPROVED
    {
        get { return _TRAINING_ISAPPROVED; }
        set { _TRAINING_ISAPPROVED = value; }
    }

    private int _TRAINING_ATTENDANCE_DAYS;

    public int TRAINING_ATTENDANCE_DAYS
    {
        get { return _TRAINING_ATTENDANCE_DAYS; }
        set { _TRAINING_ATTENDANCE_DAYS = value; }
    }



}

#endregion

#region Attendance details

public class SMHR_TRAINING_ATTENDANCE : SMHR_MAIN
{
    private int _TRAINING_ATTENDANCE_ID;

    public int TRAINING_ATTENDANCE_ID
    {
        get { return _TRAINING_ATTENDANCE_ID; }
        set { _TRAINING_ATTENDANCE_ID = value; }
    }

    private int _TRAINING_ATTENDANCE_COURSESCHEDULE_ID;

    public int TRAINING_ATTENDANCE_COURSESCHEDULE_ID
    {
        get { return _TRAINING_ATTENDANCE_COURSESCHEDULE_ID; }
        set { _TRAINING_ATTENDANCE_COURSESCHEDULE_ID = value; }
    }
    private int _TRAINING_ATTENDANCE_DAYS;

    public int TRAINING_ATTENDANCE_DAYS
    {
        get { return _TRAINING_ATTENDANCE_DAYS; }
        set { _TRAINING_ATTENDANCE_DAYS = value; }
    }
    private string _TRAINING_ATTENDANCE_EMPLOYEE_ID;

    public string TRAINING_ATTENDANCE_EMPLOYEE_ID
    {
        get { return _TRAINING_ATTENDANCE_EMPLOYEE_ID; }
        set { _TRAINING_ATTENDANCE_EMPLOYEE_ID = value; }
    }





}



#endregion
#region Question Bank
public class SMHR_TRAINING_QUESTIONBANK : SMHR_MAIN
{
    private int _QuestionBank_ID;

    public int QuestionBank_ID
    {
        get { return _QuestionBank_ID; }
        set { _QuestionBank_ID = value; }
    }

    private int _QuestionBank_ORGANISATION_ID;

    public int QuestionBank_ORGANISATION_ID
    {
        get { return _QuestionBank_ORGANISATION_ID; }
        set { _QuestionBank_ORGANISATION_ID = value; }
    }
    private int _QuestionBank_courseID;

    public int QuestionBank_courseID
    {
        get { return _QuestionBank_courseID; }
        set { _QuestionBank_courseID = value; }
    }
    private int _QuestionBank_ChapterID;

    public int QuestionBank_ChapterID
    {
        get { return _QuestionBank_ChapterID; }
        set { _QuestionBank_ChapterID = value; }
    }

    private string _QuestionBank_Question;

    public string QuestionBank_Question
    {
        get { return _QuestionBank_Question; }
        set { _QuestionBank_Question = value; }
    }

    private string _QuestionBank_option1;

    public string QuestionBank_option1
    {
        get { return _QuestionBank_option1; }
        set { _QuestionBank_option1 = value; }
    }

    private string _QuestionBank_option2;

    public string QuestionBank_option2
    {
        get { return _QuestionBank_option2; }
        set { _QuestionBank_option2 = value; }
    }
    private string _QuestionBank_option3;

    public string QuestionBank_option3
    {
        get { return _QuestionBank_option3; }
        set { _QuestionBank_option3 = value; }
    }
    private string _QuestionBank_option4;

    public string QuestionBank_option4
    {
        get { return _QuestionBank_option4; }
        set { _QuestionBank_option4 = value; }
    }

    private int _QuestionBank_answer;

    public int QuestionBank_answer
    {
        get { return _QuestionBank_answer; }
        set { _QuestionBank_answer = value; }
    }
    private int _QuestionBank_CREATEDBY;

    public int QuestionBank_CREATEDBY
    {
        get { return _QuestionBank_CREATEDBY; }
        set { _QuestionBank_CREATEDBY = value; }
    }
    private int _QuestionBank_LASTMDFBY;

    public int QuestionBank_LASTMDFBY
    {
        get { return _QuestionBank_LASTMDFBY; }
        set { _QuestionBank_LASTMDFBY = value; }
    }
    private DateTime _QuestionBank_CREATEDDATE;

    public DateTime QuestionBank_CREATEDDATE
    {
        get { return _QuestionBank_CREATEDDATE; }
        set { _QuestionBank_CREATEDDATE = value; }

    }
    private DateTime _QuestionBank_LASTMDFDATE;

    public DateTime QuestionBank_LASTMDFDATE
    {
        get { return _QuestionBank_LASTMDFDATE; }
        set { _QuestionBank_LASTMDFDATE = value; }

    }
    private bool _QuestionBank_status;

    public bool QuestionBank_status
    {
        get { return (this._QuestionBank_status); }
        set { this._QuestionBank_status = value; }
    }
}



#endregion
#region OFFLINEASSESSMENTS
public class SMHR_TRAINING_OFFLINEASSESSMENTS : SMHR_MAIN
{
    private int _OFFLINEASSESSMENT_ID;

    public int OFFLINEASSESSMENT_ID
    {
        get { return _OFFLINEASSESSMENT_ID; }
        set { _OFFLINEASSESSMENT_ID = value; }
    }

    private int _OFFLINEASSESSMENT_COURSEID;

    public int OFFLINEASSESSMENT_COURSEID
    {
        get { return _OFFLINEASSESSMENT_COURSEID; }
        set { _OFFLINEASSESSMENT_COURSEID = value; }
    }
    private int _OFFLINEASSESSMENT_COURSESCHEDULEID;

    public int OFFLINEASSESSMENT_COURSESCHEDULEID
    {
        get { return _OFFLINEASSESSMENT_COURSESCHEDULEID; }
        set { _OFFLINEASSESSMENT_COURSESCHEDULEID = value; }
    }
    private int _OFFLINEASSESSMENT_ORGID;

    public int OFFLINEASSESSMENT_ORGID
    {
        get { return _OFFLINEASSESSMENT_ORGID; }
        set { _OFFLINEASSESSMENT_ORGID = value; }
    }

    private string _OFFLINEASSESSMENT_NAME;

    public string OFFLINEASSESSMENT_NAME
    {
        get { return _OFFLINEASSESSMENT_NAME; }
        set { _OFFLINEASSESSMENT_NAME = value; }
    }
    private string _OFFLINEASSESSMENT_UPLOADEDDOC;

    public string OFFLINEASSESSMENT_UPLOADEDDOC
    {
        get { return _OFFLINEASSESSMENT_UPLOADEDDOC; }
        set { _OFFLINEASSESSMENT_UPLOADEDDOC = value; }
    }

    private int _OFFLINEASSESSMENT_CREATEDBY;

    public int OFFLINEASSESSMENT_CREATEDBY
    {
        get { return _OFFLINEASSESSMENT_CREATEDBY; }
        set { _OFFLINEASSESSMENT_CREATEDBY = value; }
    }
    private int _OFFLINEASSESSMENT_MODYFIEDBY;

    public int OFFLINEASSESSMENT_MODYFIEDBY
    {
        get { return _OFFLINEASSESSMENT_MODYFIEDBY; }
        set { _OFFLINEASSESSMENT_MODYFIEDBY = value; }
    }

    private DateTime _OFFLINEASSESSMENT_CREATEDDATE;

    public DateTime OFFLINEASSESSMENT_CREATEDDATE
    {
        get { return _OFFLINEASSESSMENT_CREATEDDATE; }
        set { _OFFLINEASSESSMENT_CREATEDDATE = value; }

    }
    private DateTime _OFFLINEASSESSMENT_MODYFIEDDATE;

    public DateTime OFFLINEASSESSMENT_MODYFIEDDATE
    {
        get { return _OFFLINEASSESSMENT_MODYFIEDDATE; }
        set { _OFFLINEASSESSMENT_MODYFIEDDATE = value; }

    }
    private bool _OFFLINEASSESSMENT_STATUS;

    public bool OFFLINEASSESSMENT_STATUS
    {
        get { return (this._OFFLINEASSESSMENT_STATUS); }
        set { this._OFFLINEASSESSMENT_STATUS = value; }
    }


}


#endregion

#region FeedBackQuestions
public class SMHR_TRAINING_FEEDBACKQUESTION : SMHR_MAIN
{
    private int _FEEDBACKQUESTION_ID;

    public int FEEDBACKQUESTION_ID
    {
        get { return _FEEDBACKQUESTION_ID; }
        set { _FEEDBACKQUESTION_ID = value; }
    }

    private string _FEEDBACKQUESTION_TYPE;

    public string FEEDBACKQUESTION_TYPE
    {
        get { return _FEEDBACKQUESTION_TYPE; }
        set { _FEEDBACKQUESTION_TYPE = value; }
    }

    private bool _FEEDBACKQUESTION_STATUS;

    public bool FEEDBACKQUESTION_STATUS
    {
        get { return _FEEDBACKQUESTION_STATUS; }
        set { _FEEDBACKQUESTION_STATUS = value; }
    }



    private int _FEEDBACKQUESTION_ORGID;

    public int FEEDBACKQUESTION_ORGID
    {
        get { return _FEEDBACKQUESTION_ORGID; }
        set { _FEEDBACKQUESTION_ORGID = value; }
    }

    private string _FEEDBACKQUESTION_QUESTION_DESC;

    public string FEEDBACKQUESTION_QUESTION_DESC
    {
        get { return _FEEDBACKQUESTION_QUESTION_DESC; }
        set { _FEEDBACKQUESTION_QUESTION_DESC = value; }
    }


    private int _FEEDBACKQUESTION_CREATEDBY;

    public int FEEDBACKQUESTION_CREATEDBY
    {
        get { return _FEEDBACKQUESTION_CREATEDBY; }
        set { _FEEDBACKQUESTION_CREATEDBY = value; }
    }

    private int _FEEDBACKQUESTION_LASTMDFBY;

    public int FEEDBACKQUESTION_LASTMDFBY
    {
        get { return _FEEDBACKQUESTION_LASTMDFBY; }
        set { _FEEDBACKQUESTION_LASTMDFBY = value; }
    }

    private string _FEEDBACKQUESTION_QUESTION;

    public string FEEDBACKQUESTION_QUESTION
    {
        get { return _FEEDBACKQUESTION_QUESTION; }
        set { _FEEDBACKQUESTION_QUESTION = value; }
    }

    private DateTime _FEEDBACKQUESTION_CREATEDDATE;

    public DateTime FEEDBACKQUESTION_CREATEDDATE
    {
        get { return _FEEDBACKQUESTION_CREATEDDATE; }
        set { _FEEDBACKQUESTION_CREATEDDATE = value; }
    }

    private DateTime _FEEDBACKQUESTION_LASTMDFDATE;

    public DateTime FEEDBACKQUESTION_LASTMDFDATE
    {
        get { return _FEEDBACKQUESTION_LASTMDFDATE; }
        set { _FEEDBACKQUESTION_LASTMDFDATE = value; }
    }


}

#endregion

#region ONLINEASSESSMENTS


public class SMHR_TRAINING_ONLINEASSESSMENT : SMHR_MAIN
{
    private int _TRAINING_ASSESSMENT_ID;

    public int TRAINING_ASSESSMENT_ID
    {
        get { return _TRAINING_ASSESSMENT_ID; }
        set { _TRAINING_ASSESSMENT_ID = value; }
    }

    private string _TRAINING_ASSESSMENT_NAME;

    public string TRAINING_ASSESSMENT_NAME
    {
        get { return _TRAINING_ASSESSMENT_NAME; }
        set { _TRAINING_ASSESSMENT_NAME = value; }
    }

    private int _TRAINING_ASSESSMENT_COURSECATEGORY_ID;

    public int TRAINING_ASSESSMENT_COURSECATEGORY_ID
    {
        get { return _TRAINING_ASSESSMENT_COURSECATEGORY_ID; }
        set { _TRAINING_ASSESSMENT_COURSECATEGORY_ID = value; }
    }

    private int _TRAINING_ASSESSMENT_COURSE_ID;

    public int TRAINING_ASSESSMENT_COURSE_ID
    {
        get { return _TRAINING_ASSESSMENT_COURSE_ID; }
        set { _TRAINING_ASSESSMENT_COURSE_ID = value; }
    }

    private int _TRAINING_ASSESSMENT_COURSESCHEDULE_ID;

    public int TRAINING_ASSESSMENT_COURSESCHEDULE_ID
    {
        get { return _TRAINING_ASSESSMENT_COURSESCHEDULE_ID; }
        set { _TRAINING_ASSESSMENT_COURSESCHEDULE_ID = value; }
    }

    private string _TRAINING_ASSESSMENT_DESC;

    public string TRAINING_ASSESSMENT_DESC
    {
        get { return _TRAINING_ASSESSMENT_DESC; }
        set { _TRAINING_ASSESSMENT_DESC = value; }
    }

    private int _TRAINING_ASSESSMENT_NOOFQUESTIONS;

    public int TRAINING_ASSESSMENT_NOOFQUESTIONS
    {
        get { return _TRAINING_ASSESSMENT_NOOFQUESTIONS; }
        set { _TRAINING_ASSESSMENT_NOOFQUESTIONS = value; }
    }

    private int _TRAINING_ASSESSMENT_MINMARKS;

    public int TRAINING_ASSESSMENT_MINMARKS
    {
        get { return _TRAINING_ASSESSMENT_MINMARKS; }
        set { _TRAINING_ASSESSMENT_MINMARKS = value; }
    }

    private int _TRAINING_ASSESSMENT_TIME;

    public int TRAINING_ASSESSMENT_TIME
    {
        get { return _TRAINING_ASSESSMENT_TIME; }
        set { _TRAINING_ASSESSMENT_TIME = value; }
    }

    private string _TRAINING_ASSESSMENT_QUESTIONS;

    public string TRAINING_ASSESSMENT_QUESTIONS
    {
        get { return _TRAINING_ASSESSMENT_QUESTIONS; }
        set { _TRAINING_ASSESSMENT_QUESTIONS = value; }
    }

    private DateTime _TRAINING_ASSESSMENT_STARTDATE;

    public DateTime TRAINING_ASSESSMENT_STARTDATE
    {
        get { return _TRAINING_ASSESSMENT_STARTDATE; }
        set { _TRAINING_ASSESSMENT_STARTDATE = value; }
    }

    private DateTime _TRAINING_ASSESSMENT_ENDDATE;

    public DateTime TRAINING_ASSESSMENT_ENDDATE
    {
        get { return _TRAINING_ASSESSMENT_ENDDATE; }
        set { _TRAINING_ASSESSMENT_ENDDATE = value; }
    }

    private DateTime _TRAINING_ASSESSMENT_STARTTIME;

    public DateTime TRAINING_ASSESSMENT_STARTTIME
    {
        get { return _TRAINING_ASSESSMENT_STARTTIME; }
        set { _TRAINING_ASSESSMENT_STARTTIME = value; }
    }

    private DateTime _TRAINING_ASSESSMENT_ENDTIME;

    public DateTime TRAINING_ASSESSMENT_ENDTIME
    {
        get { return _TRAINING_ASSESSMENT_ENDTIME; }
        set { _TRAINING_ASSESSMENT_ENDTIME = value; }
    }

    private int _TRAINING_ASSESSMENT_CHAPTER_ID;

    public int TRAINING_ASSESSMENT_CHAPTER_ID
    {
        get { return _TRAINING_ASSESSMENT_CHAPTER_ID; }
        set { _TRAINING_ASSESSMENT_CHAPTER_ID = value; }
    }
}



#endregion
#region ASSESSMENT_RESULT
public class SMHR_ASSESSMENT_RESULT : SMHR_MAIN
{
    private int _ASSESSMENTRESULT_ID;

    public int ASSESSMENTRESULT_ID
    {
        get { return _ASSESSMENTRESULT_ID; }
        set { _ASSESSMENTRESULT_ID = value; }
    }

    private int _ASSESSMENTRESULT_ASSESSMENTID;

    public int ASSESSMENTRESULT_ASSESSMENTID
    {
        get { return _ASSESSMENTRESULT_ASSESSMENTID; }
        set { _ASSESSMENTRESULT_ASSESSMENTID = value; }
    }

    private int _ASSESSMENTRESULT_MARKS;

    public int ASSESSMENTRESULT_MARKS
    {
        get { return _ASSESSMENTRESULT_MARKS; }
        set { _ASSESSMENTRESULT_MARKS = value; }
    }

    private bool _ASSESSMENTRESULT_RESULT;

    public bool ASSESSMENTRESULT_RESULT
    {
        get { return _ASSESSMENTRESULT_RESULT; }
        set { _ASSESSMENTRESULT_RESULT = value; }
    }
    private int _ASSESSMENTRESULT_EMP_ID;

    public int ASSESSMENTRESULT_EMP_ID
    {
        get { return _ASSESSMENTRESULT_EMP_ID; }
        set { _ASSESSMENTRESULT_EMP_ID = value; }
    }
    private DateTime _ASSESSMENTRESULT_DATE;

    public DateTime ASSESSMENTRESULT_DATE
    {
        get { return _ASSESSMENTRESULT_DATE; }
        set { _ASSESSMENTRESULT_DATE = value; }
    }
}
#endregion
#region Rating
public class SMHR_FEEDBACK_RATING : SMHR_MAIN
{
    private int _RATING_ID;

    public int RATING_ID
    {
        get { return _RATING_ID; }
        set { _RATING_ID = value; }
    }
    private int _RATING_ORGID;

    public int RATING_ORGID
    {
        get { return _RATING_ORGID; }
        set { _RATING_ORGID = value; }
    }

    private int _RATING_SERVICEPROVIDER;

    public int RATING_SERVICEPROVIDER
    {
        get { return _RATING_SERVICEPROVIDER; }
        set { _RATING_SERVICEPROVIDER = value; }
    }
    private int _RATING_RATING;

    public int RATING_RATING
    {
        get { return _RATING_RATING; }
        set { _RATING_RATING = value; }
    }


    private int _RATING_TRAINER_NAME;

    public int RATING_TRAINER_NAME
    {
        get { return _RATING_TRAINER_NAME; }
        set { _RATING_TRAINER_NAME = value; }
    }

    private int _RATING_QuestionID;

    public int RATING_QuestionID
    {
        get { return _RATING_QuestionID; }
        set { _RATING_QuestionID = value; }
    }
    private string _RATING_TYPE;

    public string RATING_TYPE
    {
        get { return _RATING_TYPE; }
        set { _RATING_TYPE = value; }
    }

    private int _RATING_CREATEDBY;

    public int RATING_CREATEDBY
    {
        get { return _RATING_CREATEDBY; }
        set { _RATING_CREATEDBY = value; }
    }
    private int _RATING_LASTMDFBY;

    public int RATING_LASTMDFBY
    {
        get { return _RATING_LASTMDFBY; }
        set { _RATING_LASTMDFBY = value; }
    }

    private DateTime _RATING_CREATEDATE;

    public DateTime RATING_CREATEDATE
    {
        get { return _RATING_CREATEDATE; }
        set { _RATING_CREATEDATE = value; }

    }
    private DateTime _RATING_LASTMDFDATE;

    public DateTime RATING_LASTMDFDATE
    {
        get { return _RATING_LASTMDFDATE; }
        set { _RATING_LASTMDFDATE = value; }

    }
    private DataTable _FEEDBACK_TABLE;

    public DataTable FEEDBACK_TABLE
    {
        get { return _FEEDBACK_TABLE; }
        set { _FEEDBACK_TABLE = value; }
    }

}





#endregion

#region OFFLINEASSESSMENTSRESULTS
public class SMHR_OFFLINEASSESSMENT_RESULT : SMHR_MAIN
{
    private int _OFFLINE_RESULTID;

    public int OFFLINE_RESULTID
    {
        get { return _OFFLINE_RESULTID; }
        set { _OFFLINE_RESULTID = value; }
    }
    private int _OFFLINE_ASSESSMENTID;

    public int OFFLINE_ASSESSMENTID
    {
        get { return _OFFLINE_ASSESSMENTID; }
        set { _OFFLINE_ASSESSMENTID = value; }
    }

    private int _OFFLINE_EMPID;

    public int OFFLINE_EMPID
    {
        get { return _OFFLINE_EMPID; }
        set { _OFFLINE_EMPID = value; }
    }

    private string _OFFLINE_RESULTDOC;

    public string OFFLINE_RESULTDOC
    {
        get { return _OFFLINE_RESULTDOC; }
        set { _OFFLINE_RESULTDOC = value; }
    }

    private int _OFFLINE_MARKS;

    public int OFFLINE_MARKS
    {
        get { return _OFFLINE_MARKS; }
        set { _OFFLINE_MARKS = value; }
    }

    private bool _OFFLINE_RESULT;

    public bool OFFLINE_RESULT
    {
        get { return _OFFLINE_RESULT; }
        set { _OFFLINE_RESULT = value; }
    }
}
#endregion
#region LoanSetup
public class SMHR_LOANSETUP : SMHR_MAIN
{
    private int _LOANSETUP_ID;

    public int LOANSETUP_ID
    {
        get { return _LOANSETUP_ID; }
        set { _LOANSETUP_ID = value; }
    }

    private int _LOANSETUP_LOANTYPE_ID;

    public int LOANSETUP_LOANTYPE_ID
    {
        get { return _LOANSETUP_LOANTYPE_ID; }
        set { _LOANSETUP_LOANTYPE_ID = value; }
    }

    private string _LOANSETUP_LOANPROCESSTYPE;

    public string LOANSETUP_LOANPROCESSTYPE
    {
        get { return _LOANSETUP_LOANPROCESSTYPE; }
        set { _LOANSETUP_LOANPROCESSTYPE = value; }
    }

    private int _LOANSETUP_MINTENUREMONTHS;

    public int LOANSETUP_MINTENUREMONTHS
    {
        get { return _LOANSETUP_MINTENUREMONTHS; }
        set { _LOANSETUP_MINTENUREMONTHS = value; }
    }

    private int _LOANSETUP_MAXTENUREMONTHS;

    public int LOANSETUP_MAXTENUREMONTHS
    {
        get { return _LOANSETUP_MAXTENUREMONTHS; }
        set { _LOANSETUP_MAXTENUREMONTHS = value; }
    }

    private int _LOANSETUP_FINPERIODID;

    public int LOANSETUP_FINPERIODID
    {
        get { return _LOANSETUP_FINPERIODID; }
        set { _LOANSETUP_FINPERIODID = value; }
    }

    private decimal _LOANSETUP_LOANINTEREST;
    public decimal LOANSETUP_LOANINTEREST
    {
        get { return _LOANSETUP_LOANINTEREST; }
        set { _LOANSETUP_LOANINTEREST = value; }
    }

    private DataTable _LOANSETUP_GRIDDATA;

    public DataTable LOANSETUP_GRIDDATA
    {
        get { return _LOANSETUP_GRIDDATA; }
        set { _LOANSETUP_GRIDDATA = value; }
    }

    private decimal _Amount;

    public decimal Amount
    {
        get { return _Amount; }
        set { _Amount = value; }
    }

    private DateTime _EffectiveDate;

    public DateTime EffectiveDate
    {
        get { return _EffectiveDate; }
        set { _EffectiveDate = value; }
    }

    private DateTime _ApproveDate;
    public DateTime ApproveDate
    {
        get { return _ApproveDate; }
        set { _ApproveDate = value; }
    }

    private int _LOANTRANS_ID;
    public int LOANTRANS_ID
    {
        get { return _LOANTRANS_ID; }
        set { _LOANTRANS_ID = value; }
    }


}
#endregion

#region loan eligible amount

public class SMHR_LOANELIGIBLEAMOUNT : SMHR_MAIN
{

    public SMHR_LOANELIGIBLEAMOUNT()
    {
    }
    private int id;

    public int ID
    {
        get { return id; }
        set { id = value; }
    }

    private int orgID;

    public int OrgID
    {
        get { return orgID; }
        set { orgID = value; }
    }
    private int scaleID;

    public int ScaleID
    {
        get { return scaleID; }
        set { scaleID = value; }
    }

    private string scaleName;

    public string ScaleName
    {
        get { return scaleName; }
        set { scaleName = value; }
    }

    private string loanName;

    public string LoanName
    {
        get { return loanName; }
        set { loanName = value; }
    }

    private int loanID;

    public int LoanID
    {
        get { return loanID; }
        set { loanID = value; }
    }

    private double maxAmount;

    public double MaxAmount
    {
        get { return maxAmount; }
        set { maxAmount = value; }
    }
    private int financialPeriodID;

    public int FinancialPeriodID
    {
        get { return financialPeriodID; }
        set { financialPeriodID = value; }
    }
    private DataTable gradeWiseAmount;

    public DataTable GradeWiseAmount
    {
        get { return gradeWiseAmount; }
        set { gradeWiseAmount = value; }
    }
}

#endregion

#region SMHR_VOLUNTARY_DEDUCTION

public class SMHR_VOLUNTARY_DEDUCTION : SMHR_MAIN
{
    private int _VOLUNTARY_DEDUCTION_ID;
    public int VOLUNTARY_DEDUCTION_ID
    {
        get { return (this._VOLUNTARY_DEDUCTION_ID); }
        set { this._VOLUNTARY_DEDUCTION_ID = value; }
    }

    private int _VOLUNTARY_DEDUCTION_EMP_ID;
    public int VOLUNTARY_DEDUCTION_EMP_ID
    {
        get { return (this._VOLUNTARY_DEDUCTION_EMP_ID); }
        set { this._VOLUNTARY_DEDUCTION_EMP_ID = value; }
    }

    private int _VOLUNTARY_DEDUCTION_BU_ID;
    public int VOLUNTARY_DEDUCTION_BU_ID
    {
        get { return (this._VOLUNTARY_DEDUCTION_BU_ID); }
        set { this._VOLUNTARY_DEDUCTION_BU_ID = value; }
    }

    private int _VOLUNTARY_DEDUCTION_DIR_ID;
    public int VOLUNTARY_DEDUCTION_DIR_ID
    {
        get { return (this._VOLUNTARY_DEDUCTION_DIR_ID); }
        set { this._VOLUNTARY_DEDUCTION_DIR_ID = value; }
    }

    private int _VOLUNTARY_DEDUCTION_DEP_ID;
    public int VOLUNTARY_DEDUCTION_DEP_ID
    {
        get { return (this._VOLUNTARY_DEDUCTION_DEP_ID); }
        set { this._VOLUNTARY_DEDUCTION_DEP_ID = value; }
    }

    private int _VOLUNTARY_DEDUCTION_PERIOD_ID;
    public int VOLUNTARY_DEDUCTION_PERIOD_ID
    {
        get { return (this._VOLUNTARY_DEDUCTION_PERIOD_ID); }
        set { this._VOLUNTARY_DEDUCTION_PERIOD_ID = value; }
    }

    private int _VOLUNTARY_DEDUCTION_PAYITEM_ID;
    public int VOLUNTARY_DEDUCTION_PAYITEM_ID
    {
        get { return (this._VOLUNTARY_DEDUCTION_PAYITEM_ID); }
        set { this._VOLUNTARY_DEDUCTION_PAYITEM_ID = value; }
    }

    //private decimal _VOLUNTARY_DEDUCTION_AMOUNT_DISPOSED;
    //public decimal VOLUNTARY_DEDUCTION_AMOUNT_DISPOSED
    //{
    //    get { return (this._VOLUNTARY_DEDUCTION_AMOUNT_DISPOSED); }
    //    set { this._VOLUNTARY_DEDUCTION_AMOUNT_DISPOSED = value; }
    //}

    //private decimal _VOLUNTARY_DEDUCTION_AMOUNT_TOBEDISPOSED;
    //public decimal VOLUNTARY_DEDUCTION_AMOUNT_TOBEDISPOSED
    //{
    //    get { return (this._VOLUNTARY_DEDUCTION_AMOUNT_TOBEDISPOSED); }
    //    set { this._VOLUNTARY_DEDUCTION_AMOUNT_TOBEDISPOSED = value; }
    //}

    private string _VOLUNTARY_DEDUCTION_CALCUALTION_MODE;
    public string VOLUNTARY_DEDUCTION_CALCUALTION_MODE
    {
        get { return (this._VOLUNTARY_DEDUCTION_CALCUALTION_MODE); }
        set { this._VOLUNTARY_DEDUCTION_CALCUALTION_MODE = value; }
    }
}

#endregion

#region SMHR_VOLUNTARY_DEDUCTION_DETAIL

public class SMHR_VOLUNTARY_DEDUCTION_DETAIL : SMHR_MAIN
{
    private int _VOLUNTARY_DEDUCTION_DETAIL_ID;
    public int VOLUNTARY_DEDUCTION_DETAIL_ID
    {
        get { return (this._VOLUNTARY_DEDUCTION_DETAIL_ID); }
        set { this._VOLUNTARY_DEDUCTION_DETAIL_ID = value; }
    }

    private int _VOLUNTARY_DEDUCTION_DETAIL_VOLDED_ID;
    public int VOLUNTARY_DEDUCTION_DETAIL_VOLDED_ID
    {
        get { return (this._VOLUNTARY_DEDUCTION_DETAIL_VOLDED_ID); }
        set { this._VOLUNTARY_DEDUCTION_DETAIL_VOLDED_ID = value; }
    }

    private int _VOLUNTARY_DEDUCTION_DETAIL_PRDDTL_ID;
    public int VOLUNTARY_DEDUCTION_DETAIL_PRDDTL_ID
    {
        get { return (this._VOLUNTARY_DEDUCTION_DETAIL_PRDDTL_ID); }
        set { this._VOLUNTARY_DEDUCTION_DETAIL_PRDDTL_ID = value; }
    }

    private decimal _VOLUNTARY_DEDUCTION_DETAIL_AMOUNT;
    public decimal VOLUNTARY_DEDUCTION_DETAIL_AMOUNT
    {
        get { return (this._VOLUNTARY_DEDUCTION_DETAIL_AMOUNT); }
        set { this._VOLUNTARY_DEDUCTION_DETAIL_AMOUNT = value; }
    }

    private bool _VOLUNTARY_DEDUCTION_DETAIL_STATUS;
    public bool VOLUNTARY_DEDUCTION_DETAIL_STATUS
    {
        get { return (this._VOLUNTARY_DEDUCTION_DETAIL_STATUS); }
        set { this._VOLUNTARY_DEDUCTION_DETAIL_STATUS = value; }
    }
}

#endregion

#region SMHR_VOLUNTARY_DEDUCTION_ARREARS

public class SMHR_VOLUNTARY_DEDUCTION_ARREARS : SMHR_MAIN
{
    private int _VOLUNTARY_DEDUCTION_ARREARS_ID;
    public int VOLUNTARY_DEDUCTION_ARREARS_ID
    {
        get { return (this._VOLUNTARY_DEDUCTION_ARREARS_ID); }
        set { this._VOLUNTARY_DEDUCTION_ARREARS_ID = value; }
    }

    private int _VOLUNTARY_DEDUCTION_ARREARS_EMP_ID;
    public int VOLUNTARY_DEDUCTION_ARREARS_EMP_ID
    {
        get { return (this._VOLUNTARY_DEDUCTION_ARREARS_EMP_ID); }
        set { this._VOLUNTARY_DEDUCTION_ARREARS_EMP_ID = value; }
    }

    private int _VOLUNTARY_DEDUCTION_ARREARS_BU_ID;
    public int VOLUNTARY_DEDUCTION_ARREARS_BU_ID
    {
        get { return (this._VOLUNTARY_DEDUCTION_ARREARS_BU_ID); }
        set { this._VOLUNTARY_DEDUCTION_ARREARS_BU_ID = value; }
    }

    private int _VOLUNTARY_DEDUCTION_ARREARS_DIR_ID;
    public int VOLUNTARY_DEDUCTION_ARREARS_DIR_ID
    {
        get { return (this._VOLUNTARY_DEDUCTION_ARREARS_DIR_ID); }
        set { this._VOLUNTARY_DEDUCTION_ARREARS_DIR_ID = value; }
    }

    private int _VOLUNTARY_DEDUCTION_ARREARS_DEP_ID;
    public int VOLUNTARY_DEDUCTION_ARREARS_DEP_ID
    {
        get { return (this._VOLUNTARY_DEDUCTION_ARREARS_DEP_ID); }
        set { this._VOLUNTARY_DEDUCTION_ARREARS_DEP_ID = value; }
    }

    private int _VOLUNTARY_DEDUCTION_ARREARS_PERIOD_ID;
    public int VOLUNTARY_DEDUCTION_ARREARS_PERIOD_ID
    {
        get { return (this._VOLUNTARY_DEDUCTION_ARREARS_PERIOD_ID); }
        set { this._VOLUNTARY_DEDUCTION_ARREARS_PERIOD_ID = value; }
    }

    private int _VOLUNTARY_DEDUCTION_ARREARS_PRDDTL_ID;
    public int VOLUNTARY_DEDUCTION_ARREARS_PRDDTL_ID
    {
        get { return (this._VOLUNTARY_DEDUCTION_ARREARS_PRDDTL_ID); }
        set { this._VOLUNTARY_DEDUCTION_ARREARS_PRDDTL_ID = value; }
    }

    private int _VOLUNTARY_DEDUCTION_ARREARS_PAYITEM_ID;
    public int VOLUNTARY_DEDUCTION_ARREARS_PAYITEM_ID
    {
        get { return (this._VOLUNTARY_DEDUCTION_ARREARS_PAYITEM_ID); }
        set { this._VOLUNTARY_DEDUCTION_ARREARS_PAYITEM_ID = value; }
    }

    private decimal _VOLUNTARY_DEDUCTION_ARREARS_AMOUNT;
    public decimal VOLUNTARY_DEDUCTION_ARREARS_AMOUNT
    {
        get { return (this._VOLUNTARY_DEDUCTION_ARREARS_AMOUNT); }
        set { this._VOLUNTARY_DEDUCTION_ARREARS_AMOUNT = value; }
    }

    private int _VOLUNTARY_DEDUCTION_ARREARS_STATUS;
    public int VOLUNTARY_DEDUCTION_ARREARS_STATUS
    {
        get { return (this._VOLUNTARY_DEDUCTION_ARREARS_STATUS); }
        set { this._VOLUNTARY_DEDUCTION_ARREARS_STATUS = value; }
    }

    private int _VOLUNTARY_DEDUCTION_ARREARS_PAYTRANID;
    public int VOLUNTARY_DEDUCTION_ARREARS_PAYTRANID
    {
        get { return (this._VOLUNTARY_DEDUCTION_ARREARS_PAYTRANID); }
        set { this._VOLUNTARY_DEDUCTION_ARREARS_PAYTRANID = value; }
    }

    //private string _VOLUNTARY_DEDUCTION_ARREARS_CALCUALTION_MODE;
    //public string VOLUNTARY_DEDUCTION_ARREARS_CALCUALTION_MODE
    //{
    //    get { return (this._VOLUNTARY_DEDUCTION_ARREARS_CALCUALTION_MODE); }
    //    set { this._VOLUNTARY_DEDUCTION_ARREARS_CALCUALTION_MODE = value; }
    //}
}

#endregion

#region PMS_KRA_OBJECTIVES

public class PMS_KRA_OBJECTIVES : SMHR_MAIN
{
    private int _KRA_OBJ_ID;
    public int KRA_OBJ_ID
    {
        get { return (this._KRA_OBJ_ID); }
        set { this._KRA_OBJ_ID = value; }
    }

    private string _KRA_OBJ_NAME;
    public string KRA_OBJ_NAME
    {
        get { return (this._KRA_OBJ_NAME); }
        set { this._KRA_OBJ_NAME = value; }
    }

    private int _KRA_OBJ_KRA_ID;
    public int KRA_OBJ_KRA_ID
    {
        get { return (this._KRA_OBJ_KRA_ID); }
        set { this._KRA_OBJ_KRA_ID = value; }
    }

    private int _KRA_OBJ_ISACTIVE;
    public int KRA_OBJ_ISACTIVE
    {
        get { return (this._KRA_OBJ_ISACTIVE); }
        set { this._KRA_OBJ_ISACTIVE = value; }
    }
}

#endregion

#region PMS_APPROVAL_PROCESS

public class PMS_APPROVAL_PROCESS : SMHR_MAIN
{
    public PMS_APPROVAL_PROCESS()
    { }

    private int _PMS_APPROVAL_PROCESS_ID;
    public int PMS_APPROVAL_PROCESS_ID
    {
        get { return (this._PMS_APPROVAL_PROCESS_ID); }
        set { this._PMS_APPROVAL_PROCESS_ID = value; }
    }

    private int _PMS_APPROVAL_PROCESS_EMP_ID_1;
    public int PMS_APPROVAL_PROCESS_EMP_ID_1
    {
        get { return (this._PMS_APPROVAL_PROCESS_EMP_ID_1); }
        set { this._PMS_APPROVAL_PROCESS_EMP_ID_1 = value; }
    }

    private int _PMS_APPROVAL_PROCESS_EMP_ID_2;
    public int PMS_APPROVAL_PROCESS_EMP_ID_2
    {
        get { return (this._PMS_APPROVAL_PROCESS_EMP_ID_2); }
        set { this._PMS_APPROVAL_PROCESS_EMP_ID_2 = value; }
    }

    private int _PMS_APPROVAL_PROCESS_EMP_ID_3;
    public int PMS_APPROVAL_PROCESS_EMP_ID_3
    {
        get { return (this._PMS_APPROVAL_PROCESS_EMP_ID_3); }
        set { this._PMS_APPROVAL_PROCESS_EMP_ID_3 = value; }
    }

    private bool _PMS_APPROVAL_PROCESS_STATUS;
    public bool PMS_APPROVAL_PROCESS_STATUS
    {
        get { return (this._PMS_APPROVAL_PROCESS_STATUS); }
        set { this._PMS_APPROVAL_PROCESS_STATUS = value; }
    }
}

#endregion

#region SMHR_MISSION_ABOUTUS

public class SMHR_LOAN_TERMS : SMHR_MAIN
{
    private int _LOAN_TC_ID;

    public int LOAN_TERM_ID
    {
        get { return _LOAN_TC_ID; }
        set { _LOAN_TC_ID = value; }
    }
    private string _LOAN_TC;

    public string LOAN_TC
    {
        get { return _LOAN_TC; }
        set { _LOAN_TC = value; }
    }
}
#endregion

#region SMHR_INCREMENTCYCLE

public class SMHR_INCREMENTCYCLE : SMHR_MAIN
{
    private int _INCREMENTCYCLE_ID;
    public int INCREMENTCYCLE_ID
    {
        get { return (this._INCREMENTCYCLE_ID); }
        set { this._INCREMENTCYCLE_ID = value; }
    }

    private string _INCREMENTCYCLE_MONTH;
    public string INCREMENTCYCLE_MONTH
    {
        get { return (this._INCREMENTCYCLE_MONTH); }
        set { this._INCREMENTCYCLE_MONTH = value; }
    }

    private int _INCREMENTCYCLE_PERIODID;
    public int INCREMENTCYCLE_PERIODID
    {
        get { return (this._INCREMENTCYCLE_PERIODID); }
        set { this._INCREMENTCYCLE_PERIODID = value; }
    }

    private DateTime _INCREMENTCYCLE_STARTDATE;
    public DateTime INCREMENTCYCLE_STARTDATE
    {
        get { return (this._INCREMENTCYCLE_STARTDATE); }
        set { this._INCREMENTCYCLE_STARTDATE = value; }
    }

    private DateTime _INCREMENTCYCLE_ENDDATE;
    public DateTime INCREMENTCYCLE_ENDDATE
    {
        get { return (this._INCREMENTCYCLE_ENDDATE); }
        set { this._INCREMENTCYCLE_ENDDATE = value; }
    }

    private DataTable _TBLINCREMENTCYCLES;
    public DataTable TBLINCREMENTCYCLES
    {
        get { return (this._TBLINCREMENTCYCLES); }
        set { this._TBLINCREMENTCYCLES = value; }
    }

    private int _INCREMENTCYCLE_STARTMONTH_ID;
    public int INCREMENTCYCLE_STARTMONTH_ID
    {
        get { return (this._INCREMENTCYCLE_STARTMONTH_ID); }
        set { this._INCREMENTCYCLE_STARTMONTH_ID = value; }
    }

    private int _INCREMENTCYCLE_ENDMONTH_ID;
    public int INCREMENTCYCLE_ENDMONTH_ID
    {
        get { return (this._INCREMENTCYCLE_ENDMONTH_ID); }
        set { this._INCREMENTCYCLE_ENDMONTH_ID = value; }
    }
}

#endregion

#region EmpPensionScheme
public class SMHR_EMPPENSIONSCHEME : SMHR_MAIN
{

    public SMHR_EMPPENSIONSCHEME()
    {
    }
    private int _EMPPENSIONSCHEMEID;

    public int EMPPENSIONSCHEMEID
    {
        get { return _EMPPENSIONSCHEMEID; }
        set { _EMPPENSIONSCHEMEID = value; }
    }

    private int _EMPPENSIONSCHEME_EmpID;

    public int EMPPENSIONSCHEME_EMPID
    {
        get { return _EMPPENSIONSCHEME_EmpID; }
        set { _EMPPENSIONSCHEME_EmpID = value; }
    }


    private DateTime _EMPPENSIONSCHEME_JOINDATE;

    public DateTime EMPPENSIONSCHEME_JOINDATE
    {
        get { return _EMPPENSIONSCHEME_JOINDATE; }
        set { _EMPPENSIONSCHEME_JOINDATE = value; }
    }

    private string _EMPPENSIONSCHEME_PENSIONID;

    public string EMPPENSIONSCHEME_PENSIONID
    {
        get { return _EMPPENSIONSCHEME_PENSIONID; }
        set { _EMPPENSIONSCHEME_PENSIONID = value; }
    }


}
#endregion
#region EmpAVC
public class SMHR_EMPAVC : SMHR_MAIN
{
    public SMHR_EMPAVC()
    {
    }
    private int _EMPAVCID;

    public int EMPAVCID
    {
        get { return _EMPAVCID; }
        set { _EMPAVCID = value; }
    }

    private int _EMPAVC_EmpID;

    public int EMPAVC_EMPID
    {
        get { return _EMPAVC_EmpID; }
        set { _EMPAVC_EmpID = value; }
    }


    private int _EMPAVC_PENSION_AMOUNT;

    public int EMPAVC_PENSION_AMOUNT
    {
        get { return _EMPAVC_PENSION_AMOUNT; }
        set { _EMPAVC_PENSION_AMOUNT = value; }
    }


}
#endregion

#region PensionInterestOnRegisteredUnRegistAmt
public class SMHR_PENSION_INT_REG_UNREG : SMHR_MAIN
{
    private int _INT_ID;
    public int INT_ID
    {
        get { return _INT_ID; }
        set { _INT_ID = value; }
    }

    private int _INT_PERIOD_ID;
    public int INT_PERIOD_ID
    {
        get { return _INT_PERIOD_ID; }
        set { _INT_PERIOD_ID = value; }
    }

    private decimal _INT_REGISTERED_AMT;
    public decimal INT_REGISTERED_AMT
    {
        get { return _INT_REGISTERED_AMT; }
        set { _INT_REGISTERED_AMT = value; }
    }

    private decimal _INT_UNREGISTERED_AMT;
    public decimal INT_UNREGISTERED_AMT
    {
        get { return _INT_UNREGISTERED_AMT; }
        set { _INT_UNREGISTERED_AMT = value; }
    }

    private decimal _INT_NORMAL_AMT;
    public decimal INT_NORMAL_AMT
    {
        get { return _INT_NORMAL_AMT; }
        set { _INT_NORMAL_AMT = value; }
    }
}
#endregion

#region Pension Quarters
public class SMHR_PENSION_QUARTERS : SMHR_MAIN
{

    public SMHR_PENSION_QUARTERS()
    {
    }
    private int _QRTR_ID;
    public int QRTR_ID
    {
        get { return _QRTR_ID; }
        set { _QRTR_ID = value; }
    }
    private int _QRTR_PERIODID;
    public int QRTR_PERIODID
    {
        get { return _QRTR_PERIODID; }
        set { _QRTR_PERIODID = value; }
    }
    private int _QRTR_NOOFQRTRS;
    public int QRTR_NOOFQRTRS
    {
        get { return _QRTR_NOOFQRTRS; }
        set { _QRTR_NOOFQRTRS = value; }
    }
    private DateTime? _QRTR_QRTR1SDATE;
    public DateTime? QRTR_QRTR1SDATE
    {
        get { return _QRTR_QRTR1SDATE; }
        set { _QRTR_QRTR1SDATE = value; }
    }
    private DateTime? _QRTR_QRTR1EDATE;
    public DateTime? QRTR_QRTR1EDATE
    {
        get { return _QRTR_QRTR1EDATE; }
        set { _QRTR_QRTR1EDATE = value; }
    }
    private DateTime? _QRTR_QRTR2SDATE;
    public DateTime? QRTR_QRTR2SDATE
    {
        get { return _QRTR_QRTR2SDATE; }
        set { _QRTR_QRTR2SDATE = value; }
    }
    private DateTime? _QRTR_QRTR2EDATE;
    public DateTime? QRTR_QRTR2EDATE
    {
        get { return _QRTR_QRTR2EDATE; }
        set { _QRTR_QRTR2EDATE = value; }
    }
    private DateTime? _QRTR_QRTR3SDATE;
    public DateTime? QRTR_QRTR3SDATE
    {
        get { return _QRTR_QRTR3SDATE; }
        set { _QRTR_QRTR3SDATE = value; }
    }
    private DateTime? _QRTR_QRTR3EDATE;
    public DateTime? QRTR_QRTR3EDATE
    {
        get { return _QRTR_QRTR3EDATE; }
        set { _QRTR_QRTR3EDATE = value; }
    }
    private DateTime? _QRTR_QRTR4SDATE;
    public DateTime? QRTR_QRTR4SDATE
    {
        get { return _QRTR_QRTR4SDATE; }
        set { _QRTR_QRTR4SDATE = value; }
    }
    private DateTime? _QRTR_QRTR4EDATE;
    public DateTime? QRTR_QRTR4EDATE
    {
        get { return _QRTR_QRTR4EDATE; }
        set { _QRTR_QRTR4EDATE = value; }
    }

}
#endregion

#region TAXATION MASTER
public class SMHR_TAXATIONMASTER : SMHR_MAIN
{

    public SMHR_TAXATIONMASTER()
    {
    }
    private int _TAXATIONMASTER_ID;
    public int TAXATIONMASTER_ID
    {
        get { return _TAXATIONMASTER_ID; }
        set { _TAXATIONMASTER_ID = value; }
    }
    private int _TAXATIONMASTER_FINPERIOD_ID;
    public int TAXATIONMASTER_FINPERIOD_ID
    {
        get { return _TAXATIONMASTER_FINPERIOD_ID; }
        set { _TAXATIONMASTER_FINPERIOD_ID = value; }
    }
    private int _TAXATIONMASTER_TYPE_ID;
    public int TAXATIONMASTER_TYPE_ID
    {
        get { return _TAXATIONMASTER_TYPE_ID; }
        set { _TAXATIONMASTER_TYPE_ID = value; }
    }
    private string _TAXATIONMASTER_TYPE_NAME;
    public string TAXATIONMASTER_TYPE_NAME
    {
        get { return _TAXATIONMASTER_TYPE_NAME; }
        set { _TAXATIONMASTER_TYPE_NAME = value; }
    }
    private int _TAXATIONMASTER_ORGID;
    public int TAXATIONMASTER_ORGID
    {
        get { return _TAXATIONMASTER_ORGID; }
        set { _TAXATIONMASTER_ORGID = value; }
    }
    private int _TAXATIONMASTER_SLAB_ID;
    public int TAXATIONMASTER_SLAB_ID
    {
        get { return _TAXATIONMASTER_SLAB_ID; }
        set { _TAXATIONMASTER_SLAB_ID = value; }
    }
    private string _TAXATIONMASTER_SLAB_NAME;
    public string TAXATIONMASTER_SLAB_NAME
    {
        get { return _TAXATIONMASTER_SLAB_NAME; }
        set { _TAXATIONMASTER_SLAB_NAME = value; }
    }
    private decimal _TAXATIONMASTER_SLAB_AMOUNT;
    public decimal TAXATIONMASTER_SLAB_AMOUNT
    {
        get { return _TAXATIONMASTER_SLAB_AMOUNT; }
        set { _TAXATIONMASTER_SLAB_AMOUNT = value; }
    }
    private int _TAXATIONMASTER_SLAB_PER;
    public int TAXATIONMASTER_SLAB_PER
    {
        get { return _TAXATIONMASTER_SLAB_PER; }
        set { _TAXATIONMASTER_SLAB_PER = value; }
    }
    private DateTime _TAXATIONMASTER_CREATEDBY;
    public DateTime TAXATIONMASTER_CREATEDBY
    {
        get { return _TAXATIONMASTER_CREATEDBY; }
        set { _TAXATIONMASTER_CREATEDBY = value; }
    }
    private DateTime _TAXATIONMASTER_CREATEDDATE;
    public DateTime TAXATIONMASTER_CREATEDDATE
    {
        get { return _TAXATIONMASTER_CREATEDDATE; }
        set { _TAXATIONMASTER_CREATEDDATE = value; }
    }
    private DateTime _TAXATIONMASTER_MODYFIEDBY;
    public DateTime TAXATIONMASTER_MODYFIEDBY
    {
        get { return _TAXATIONMASTER_MODYFIEDBY; }
        set { _TAXATIONMASTER_MODYFIEDBY = value; }
    }
    private DateTime _TAXATIONMASTER_MODYFIEDDATE;
    public DateTime TAXATIONMASTER_MODYFIEDDATE
    {
        get { return _TAXATIONMASTER_MODYFIEDDATE; }
        set { _TAXATIONMASTER_MODYFIEDDATE = value; }
    }
    private DataTable _TAXATIONDATA;

    public DataTable TAXATIONDATA
    {
        get { return _TAXATIONDATA; }
        set { _TAXATIONDATA = value; }
    }
}
#endregion

#region InterestOnNormalPensionContribution
public class SMHR_PNCN_INTRST : SMHR_MAIN
{
    private int _PNCN_ID;
    public int PNCN_ID
    {
        get { return _PNCN_ID; }
        set { _PNCN_ID = value; }
    }

    private int _PNCN_PERIOD_ID;
    public int PNCN_PERIOD_ID
    {
        get { return _PNCN_PERIOD_ID; }
        set { _PNCN_PERIOD_ID = value; }
    }

    private decimal _PNCN_QRTR1;
    public decimal PNCN_QRTR1
    {
        get { return _PNCN_QRTR1; }
        set { _PNCN_QRTR1 = value; }
    }

    private decimal _PNCN_QRTR2;
    public decimal PNCN_QRTR2
    {
        get { return _PNCN_QRTR2; }
        set { _PNCN_QRTR2 = value; }
    }

    private decimal _PNCN_QRTR3;
    public decimal PNCN_QRTR3
    {
        get { return _PNCN_QRTR3; }
        set { _PNCN_QRTR3 = value; }
    }

    private decimal _PNCN_QRTR4;
    public decimal PNCN_QRTR4
    {
        get { return _PNCN_QRTR4; }
        set { _PNCN_QRTR4 = value; }
    }

    private decimal _PNCN_YEARLY_INTEREST;
    public decimal PNCN_YEARLY_INTEREST
    {
        get { return _PNCN_YEARLY_INTEREST; }
        set { _PNCN_YEARLY_INTEREST = value; }
    }

    private int _PNCN_ORGANISATION_ID;
    public int PNCN_ORGANISATION_ID
    {
        get { return _PNCN_ORGANISATION_ID; }
        set { _PNCN_ORGANISATION_ID = value; }
    }

    private int _PNCN_CREATEDBY;
    public int PNCN_CREATEDBY
    {
        get { return _PNCN_CREATEDBY; }
        set { _PNCN_CREATEDBY = value; }
    }

    private DateTime _PNCN_CREATEDDATE;
    public DateTime PNCN_CREATEDDATE
    {
        get { return _PNCN_CREATEDDATE; }
        set { _PNCN_CREATEDDATE = value; }
    }

    private int _PNCN_MODIFIEDBY;
    public int PNCN_MODIFIEDBY
    {
        get { return _PNCN_MODIFIEDBY; }
        set { _PNCN_MODIFIEDBY = value; }
    }

    private DateTime _PNCN_MODIFIEDDATE;
    public DateTime PNCN_MODIFIEDDATE
    {
        get { return _PNCN_MODIFIEDDATE; }
        set { _PNCN_MODIFIEDDATE = value; }
    }
}
#endregion
#region TAXATION MASTER
public class SMHR_TRAININGCOST : SMHR_MAIN
{

    public SMHR_TRAININGCOST()
    {
    }
    private int _TRAININGCOST_ID;
    public int TRAININGCOST_ID
    {
        get { return _TRAININGCOST_ID; }
        set { _TRAININGCOST_ID = value; }
    }
    private int _TRAININGCOST_COURSESCHEDULE_ID;
    public int TRAININGCOST_COURSESCHEDULE_ID
    {
        get { return _TRAININGCOST_COURSESCHEDULE_ID; }
        set { _TRAININGCOST_COURSESCHEDULE_ID = value; }
    }
    private int _TRAININGCOST_TYPE_ID;
    public int TRAININGCOST_TYPE_ID
    {
        get { return _TRAININGCOST_TYPE_ID; }
        set { _TRAININGCOST_TYPE_ID = value; }
    }
    private decimal _TRAININGCOST_AMOUNT;
    public decimal TRAININGCOST_AMOUNT
    {
        get { return _TRAININGCOST_AMOUNT; }
        set { _TRAININGCOST_AMOUNT = value; }
    }
    private int _TRAININGCOST_ORG_ID;
    public int TRAININGCOST_ORG_ID
    {
        get { return _TRAININGCOST_ORG_ID; }
        set { _TRAININGCOST_ORG_ID = value; }
    }
    private DateTime _TRAININGCOST_CREATEDBY;
    public DateTime TRAININGCOST_CREATEDBY
    {
        get { return _TRAININGCOST_CREATEDBY; }
        set { _TRAININGCOST_CREATEDBY = value; }
    }
    private DateTime _TRAININGCOST_CREATEDATE;
    public DateTime TRAININGCOST_CREATEDATE
    {
        get { return _TRAININGCOST_CREATEDATE; }
        set { _TRAININGCOST_CREATEDATE = value; }
    }
    private DateTime _TRAININGCOST_MODYFIEDBY;
    public DateTime TRAININGCOST_MODYFIEDBY
    {
        get { return _TRAININGCOST_MODYFIEDBY; }
        set { _TRAININGCOST_MODYFIEDBY = value; }
    }
    private DateTime _TRAININGCOST_MODYFIEDDATE;
    public DateTime TRAININGCOST_MODYFIEDDATE
    {
        get { return _TRAININGCOST_MODYFIEDDATE; }
        set { _TRAININGCOST_MODYFIEDDATE = value; }
    }
    private DataTable _TRAININGCOST;

    public DataTable TRAININGCOST
    {
        get { return _TRAININGCOST; }
        set { _TRAININGCOST = value; }
    }
}
#endregion

#region Module_MailID
public class SMHR_Module_MailID : SMHR_MAIN
{

    public SMHR_Module_MailID()
    {
    }
    private int _Module_MailID_ID;
    public int Module_MailID_ID
    {
        get { return _Module_MailID_ID; }
        set { _Module_MailID_ID = value; }
    }
    private int _Module_MailID_ModuleID;
    public int Module_MailID_ModuleID
    {
        get { return _Module_MailID_ModuleID; }
        set { _Module_MailID_ModuleID = value; }
    }
    private string _Module_MailID_EmailIDS;
    public string Module_MailID_EmailIDS
    {
        get { return _Module_MailID_EmailIDS; }
        set { _Module_MailID_EmailIDS = value; }
    }
    private string _Module_MailID_AdminEMailID;
    public string Module_MailID_AdminEMailID
    {
        get { return _Module_MailID_AdminEMailID; }
        set { _Module_MailID_AdminEMailID = value; }
    }
    private int _Module_MailID_ORG_ID;
    public int Module_MailID_ORG_ID
    {
        get { return _Module_MailID_ORG_ID; }
        set { _Module_MailID_ORG_ID = value; }
    }
    private DateTime _Module_MailID_CreatedBy;
    public DateTime Module_MailID_CreatedBy
    {
        get { return _Module_MailID_CreatedBy; }
        set { _Module_MailID_CreatedBy = value; }
    }
    private DateTime _Module_MailID_CreatedDate;
    public DateTime Module_MailID_CreatedDate
    {
        get { return _Module_MailID_CreatedDate; }
        set { _Module_MailID_CreatedDate = value; }
    }
    private DateTime _Module_MailID_ModyfiedBy;
    public DateTime Module_MailID_ModyfiedBy
    {
        get { return _Module_MailID_ModyfiedBy; }
        set { _Module_MailID_ModyfiedBy = value; }
    }
    private DateTime _Module_MailID_ModyfiedDate;
    public DateTime Module_MailID_ModyfiedDate
    {
        get { return _Module_MailID_ModyfiedDate; }
        set { _Module_MailID_ModyfiedDate = value; }
    }
    private DataTable _MODULEMAILIDS;

    public DataTable MODULEMAILIDS
    {
        get { return _MODULEMAILIDS; }
        set { _MODULEMAILIDS = value; }
    }
}
#endregion

#region TAXATION MASTER
public class PMS_APPRAISAL : SMHR_MAIN
{

    public PMS_APPRAISAL()
    {
    }
    private int _APPRAISAL_ID;
    public int APPRAISAL_ID
    {
        get { return _APPRAISAL_ID; }
        set { _APPRAISAL_ID = value; }
    }
    private int _APPRAISAL_STATUS;
    public int APPRAISAL_STATUS
    {
        get { return _APPRAISAL_STATUS; }
        set { _APPRAISAL_STATUS = value; }
    }

}
#endregion

#region SMHR_PENSION_CONTRIBUTION
public class SMHR_PENSION_CONTRIBUTION : SMHR_MAIN
{
    private int _PENSION_CONTRIBUTION_ID;
    public int PENSION_CONTRIBUTION_ID
    {
        get { return _PENSION_CONTRIBUTION_ID; }
        set { _PENSION_CONTRIBUTION_ID = value; }
    }

    private string _PENSION_EMPTYPE;
    public string PENSION_EMPTYPE
    {
        get { return _PENSION_EMPTYPE; }
        set { _PENSION_EMPTYPE = value; }
    }

    private double _PENSION_EMPLOYEE_VALUE;
    public double PENSION_EMPLOYEE_VALUE
    {
        get { return _PENSION_EMPLOYEE_VALUE; }
        set { _PENSION_EMPLOYEE_VALUE = value; }
    }

    private double _PENSION_EMPLOYER_VALUE;
    public double PENSION_EMPLOYER_VALUE
    {
        get { return _PENSION_EMPLOYER_VALUE; }
        set { _PENSION_EMPLOYER_VALUE = value; }
    }

    private bool _PENSION_ISACTIVE;
    public bool PENSION_ISACTIVE
    {
        get { return _PENSION_ISACTIVE; }
        set { _PENSION_ISACTIVE = value; }
    }
    private int _PENSION_SALALRYSTRUCT_ID;
    public int PENSION_SALALRYSTRUCT_ID
    {
        get { return _PENSION_SALALRYSTRUCT_ID; }
        set { _PENSION_SALALRYSTRUCT_ID = value; }
    }
    public int PENSION_EMPTYPE_ID { get; set; }
}
#endregion

#region SMHR_LOANWITHDRAWL
public class SMHR_LOANWITHDRAWL : SMHR_MAIN
{
    private int _LOANWITHDRAWL_ID;
    public int LOANWITHDRAWL_ID
    {
        get { return _LOANWITHDRAWL_ID; }
        set { _LOANWITHDRAWL_ID = value; }
    }

    private int _LOANWITHDRAWL_LAONTRANS_ID;
    public int LOANWITHDRAWL_LAONTRANS_ID
    {
        get { return _LOANWITHDRAWL_LAONTRANS_ID; }
        set { _LOANWITHDRAWL_LAONTRANS_ID = value; }
    }

    private string _LOANWITHDRAWL_LOANNO;
    public string LOANWITHDRAWL_LOANNO
    {
        get { return _LOANWITHDRAWL_LOANNO; }
        set { _LOANWITHDRAWL_LOANNO = value; }
    }

    private decimal _LOANWITHDRAWL_AMOUNT;
    public decimal LOANWITHDRAWL_AMOUNT
    {
        get { return _LOANWITHDRAWL_AMOUNT; }
        set { _LOANWITHDRAWL_AMOUNT = value; }
    }

    private DateTime _LOANWITHDRAWL_DATE;
    public DateTime LOANWITHDRAWL_DATE
    {
        get { return _LOANWITHDRAWL_DATE; }
        set { _LOANWITHDRAWL_DATE = value; }
    }

    private decimal _LOANWITHDRAWL_BALANCE;
    public decimal LOANWITHDRAWL_BALANCE
    {
        get { return _LOANWITHDRAWL_BALANCE; }
        set { _LOANWITHDRAWL_BALANCE = value; }
    }

    private int _LOANWITHDRAWL_CREATEDBY;
    public int LOANWITHDRAWL_CREATEDBY
    {
        get { return _LOANWITHDRAWL_CREATEDBY; }
        set { _LOANWITHDRAWL_CREATEDBY = value; }
    }

    private DateTime _LOANWITHDRAWL_CREATEDDATE;
    public DateTime LOANWITHDRAWL_CREATEDDATE
    {
        get { return _LOANWITHDRAWL_CREATEDDATE; }
        set { _LOANWITHDRAWL_CREATEDDATE = value; }
    }

    private int _LOANWITHDRAWL_MODIFIEDBY;
    public int LOANWITHDRAWL_MODIFIEDBY
    {
        get { return _LOANWITHDRAWL_MODIFIEDBY; }
        set { _LOANWITHDRAWL_MODIFIEDBY = value; }
    }

    private DateTime _LOANWITHDRAWL_MODIFIEDDATE;
    public DateTime LOANWITHDRAWL_MODIFIEDDATE
    {
        get { return _LOANWITHDRAWL_MODIFIEDDATE; }
        set { _LOANWITHDRAWL_MODIFIEDDATE = value; }
    }

    private string _LOANTRANS_COMMENTS;
    public string LOANTRANS_COMMENTS
    {
        get { return _LOANTRANS_COMMENTS; }
        set { _LOANTRANS_COMMENTS = value; }
    }
}
#endregion

#region SMHR_UNAUTHORIZED
public class smhr_UNAUTHORIZED : SMHR_MAIN
{
    public smhr_UNAUTHORIZED()
    {

    }
    private int _UNAUTHORIZED_ID;
    public int UNAUTHORIZED_ID
    {
        get { return _UNAUTHORIZED_ID; }
        set { _UNAUTHORIZED_ID = value; }
    }

    private int _UNAUTHORIZED_USERID;
    public int UNAUTHORIZED_USERID
    {
        get { return _UNAUTHORIZED_USERID; }
        set { _UNAUTHORIZED_USERID = value; }
    }

    private int _UNAUTHORIZED_MODULEID;
    public int UNAUTHORIZED_MODULEID
    {
        get { return _UNAUTHORIZED_MODULEID; }
        set { _UNAUTHORIZED_MODULEID = value; }
    }

    private int _UNAUTHORIZED_FORMID;
    public int UNAUTHORIZED_FORMID
    {
        get { return _UNAUTHORIZED_FORMID; }
        set { _UNAUTHORIZED_FORMID = value; }
    }

    private DateTime _UNAUTHORIZED_ACCESSDATE;
    public DateTime UNAUTHORIZED_ACCESSDATE
    {
        get { return _UNAUTHORIZED_ACCESSDATE; }
        set { _UNAUTHORIZED_ACCESSDATE = value; }
    }
}
# endregion

#region SMHR_PENSIONTRANSFERFUNDS
public class SMHR_PENSIONTRANSFERFUNDS : SMHR_MAIN
{
    private int _FUNDS_ID;
    public int FUNDS_ID
    {
        get { return _FUNDS_ID; }
        set { _FUNDS_ID = value; }
    }

    private int _FUNDS_EMPID;
    public int FUNDS_EMPID
    {
        get { return _FUNDS_EMPID; }
        set { _FUNDS_EMPID = value; }
    }

    private string _FUNDS_EMPCODE;
    public string FUNDS_EMPCODE
    {
        get { return _FUNDS_EMPCODE; }
        set { _FUNDS_EMPCODE = value; }
    }

    private int _FUNDS_ORGID;
    public int FUNDS_ORGID
    {
        get { return _FUNDS_ORGID; }
        set { _FUNDS_ORGID = value; }
    }

    private int _FUNDS_BUID;
    public int FUNDS_BUID
    {
        get { return _FUNDS_BUID; }
        set { _FUNDS_BUID = value; }
    }

    private decimal _FUNDS_AMOUNT;
    public decimal FUNDS_AMOUNT
    {
        get { return _FUNDS_AMOUNT; }
        set { _FUNDS_AMOUNT = value; }
    }
}

public class SMHR_PENSION_WITHDRAWL : SMHR_MAIN
{
    private int _WITHDRAWL_ID;
    public int WITHDRAWL_ID
    {
        get { return _WITHDRAWL_ID; }
        set { _WITHDRAWL_ID = value; }
    }

    private int _WITHDRAWL_FFS_ID;
    public int WITHDRAWL_FFS_ID
    {
        get { return _WITHDRAWL_FFS_ID; }
        set { _WITHDRAWL_FFS_ID = value; }
    }

    private double _WITHDRAWL_WITHDRAWLAMOUNT;
    public double WITHDRAWL_WITHDRAWLAMOUNT
    {
        get { return _WITHDRAWL_WITHDRAWLAMOUNT; }
        set { _WITHDRAWL_WITHDRAWLAMOUNT = value; }
    }

    private int _WITHDRAWL_PAYITEMID;
    public int WITHDRAWL_PAYITEMID
    {
        get { return _WITHDRAWL_PAYITEMID; }
        set { _WITHDRAWL_PAYITEMID = value; }
    }

    private int _WITHDRAWL_SETTLEMENTTYPE;
    public int WITHDRAWL_SETTLEMENTTYPE
    {
        get { return _WITHDRAWL_SETTLEMENTTYPE; }
        set { _WITHDRAWL_SETTLEMENTTYPE = value; }
    }

    private DateTime _WITHDRAWL_SETTLEMENTDATE;
    public DateTime WITHDRAWL_SETTLEMENTDATE
    {
        get { return _WITHDRAWL_SETTLEMENTDATE; }
        set { _WITHDRAWL_SETTLEMENTDATE = value; }
    }

    private string _WITHDRAWL_BENEFICIARY;
    public string WITHDRAWL_BENEFICIARY
    {
        get { return _WITHDRAWL_BENEFICIARY; }
        set { _WITHDRAWL_BENEFICIARY = value; }
    }

    private double _WITHDRAWL_BALANCE;
    public double WITHDRAWL_BALANCE
    {
        get { return _WITHDRAWL_BALANCE; }
        set { _WITHDRAWL_BALANCE = value; }
    }

    private int _WITHDRAWL_RELATIONTYPE;
    public int WITHDRAWL_RELATIONTYPE
    {
        get { return _WITHDRAWL_RELATIONTYPE; }
        set { _WITHDRAWL_RELATIONTYPE = value; }
    }

    private string _WITHDRAWL_WITHDRAWLTYPE;
    public string WITHDRAWL_WITHDRAWLTYPE
    {
        get { return _WITHDRAWL_WITHDRAWLTYPE; }
        set { _WITHDRAWL_WITHDRAWLTYPE = value; }
    }
}


public class InsTransferFunds : SMHR_MAIN
{
    private int _TransferFundsID;
    public int TransferFundsID
    {
        get { return _TransferFundsID; }
        set { _TransferFundsID = value; }
    }

    private int _TransferFundsEmpID;
    public int TransferFundsEmpID
    {
        get { return _TransferFundsEmpID; }
        set { _TransferFundsEmpID = value; }
    }

    private string _TransferFundsEmpCode;
    public string TransferFundsEmpCode
    {
        get { return _TransferFundsEmpCode; }
        set { _TransferFundsEmpCode = value; }
    }

    private int _TransferFundsOrgID;
    public int TransferFundsOrgID
    {
        get { return _TransferFundsOrgID; }
        set { _TransferFundsOrgID = value; }
    }

    private int _TransferFundsBUID;
    public int TransferFundsBUID
    {
        get { return _TransferFundsBUID; }
        set { _TransferFundsBUID = value; }
    }

    private decimal _TransferFundsAmount;
    public decimal TransferFundsAmount
    {
        get { return _TransferFundsAmount; }
        set { _TransferFundsAmount = value; }
    }
    private int _TransferFundsCreatedBy;
    public int TransferFundsCreatedBy
    {
        get { return _TransferFundsCreatedBy; }
        set { _TransferFundsCreatedBy = value; }
    }

    private DateTime _TransferFundsCreatedDate;
    public DateTime TransferFundsCreatedDate
    {
        get { return _TransferFundsCreatedDate; }
        set { _TransferFundsCreatedDate = value; }
    }

    private int _TransferFundsModifiedBy;
    public int TransferFundsModifiedBy
    {
        get { return _TransferFundsModifiedBy; }
        set { _TransferFundsModifiedBy = value; }
    }

    private DateTime _TransferFundsModifiedDate;
    public DateTime TransferFundsModifiedDate
    {
        get { return _TransferFundsModifiedDate; }
        set { _TransferFundsModifiedDate = value; }
    }
    private int _TransferFundsPayItemID;
    public int TransferFundsPayItemID
    {
        get { return _TransferFundsPayItemID; }
        set { _TransferFundsPayItemID = value; }
    }
    private int _ORGANISATION_ID;
    public int ORGANISATION_ID
    {
        get { return _ORGANISATION_ID; }
        set { _ORGANISATION_ID = value; }
    }
}

#endregion

#region VoteCodeEntry
public class SMHR_VOTECODEENTRY : SMHR_MAIN
{
    private int _VOTECODE_ID;

    public int VOTECODE_ID
    {
        get { return _VOTECODE_ID; }
        set { _VOTECODE_ID = value; }
    }
    private int _VOTECODE_ORG_ID;
    public int VOTECODE_ORG_ID
    {
        get { return _VOTECODE_ORG_ID; }
        set { _VOTECODE_ORG_ID = value; }
    }
    private int _VOTECODE_BU_ID;
    public int VOTECODE_BU_ID
    {
        get { return _VOTECODE_BU_ID; }
        set { _VOTECODE_BU_ID = value; }
    }
    private int _VOTECODE_SALSTRUCT_ID;
    public int VOTECODE_SALSTRUCT_ID
    {
        get { return _VOTECODE_SALSTRUCT_ID; }
        set { _VOTECODE_SALSTRUCT_ID = value; }
    }

    private int _VOTECODE_PAYITEM_ID;
    public int VOTECODE_PAYITEM_ID
    {
        get { return _VOTECODE_PAYITEM_ID; }
        set { _VOTECODE_PAYITEM_ID = value; }
    }
    private string _VOTECODE_CODE;
    public string VOTECODE_CODE
    {
        get { return _VOTECODE_CODE; }
        set { _VOTECODE_CODE = value; }
    }
    private string _VOTECODE_NAME;
    public string VOTECODE_NAME
    {
        get { return _VOTECODE_NAME; }
        set { _VOTECODE_NAME = value; }
    }

    private DataTable _VOTECODE_GRIDDATA;

    public DataTable VOTECODE_GRIDDATA
    {
        get { return _VOTECODE_GRIDDATA; }
        set { _VOTECODE_GRIDDATA = value; }
    }

    private int _VOTECODE_CREATEDBY;
    public int VOTECODE_CREATEDBY
    {
        get { return _VOTECODE_CREATEDBY; }
        set { _VOTECODE_CREATEDBY = value; }
    }
    private DateTime _VOTECODE_CREATEDDATE;
    public DateTime VOTECODE_CREATEDDATE
    {
        get { return _VOTECODE_CREATEDDATE; }
        set { _VOTECODE_CREATEDDATE = value; }

    }
    private int _VOTECOD_LASTMDFBY;
    public int VOTECODE_LASTMDFBY
    {
        get { return _VOTECOD_LASTMDFBY; }
        set { _VOTECOD_LASTMDFBY = value; }
    }
    private DateTime _VOTECODE_LASTMDFDATE;
    public DateTime VOTECODE_LASTMDFDATE
    {
        get { return _VOTECODE_LASTMDFDATE; }
        set { _VOTECODE_LASTMDFDATE = value; }
    }
}
#endregion

#region SMHR_PROJECT

public class SMHR_PROJECT : SMHR_MAIN
{
    private int _PROJECT_ID;
    public int PROJECT_ID
    {
        get { return _PROJECT_ID; }
        set { _PROJECT_ID = value; }
    }

    private string _PROJECT_NAME;
    public string PROJECT_NAME
    {
        get { return _PROJECT_NAME; }
        set { _PROJECT_NAME = value; }
    }

    private string _PROJECT_CODE;
    public string PROJECT_CODE
    {
        get { return _PROJECT_CODE; }
        set { _PROJECT_CODE = value; }
    }

    private string _PROJECT_DESC;
    public string PROJECT_DESC
    {
        get { return _PROJECT_DESC; }
        set { _PROJECT_DESC = value; }
    }

    private int _PROJECT_ORGANISATION_ID;
    public int PROJECT_ORGANISATION_ID
    {
        get { return _PROJECT_ORGANISATION_ID; }
        set { _PROJECT_ORGANISATION_ID = value; }
    }

    private int _PROJECT_BUSINESSUNIT_ID;
    public int PROJECT_BUSINESSUNIT_ID
    {
        get { return _PROJECT_BUSINESSUNIT_ID; }
        set { _PROJECT_BUSINESSUNIT_ID = value; }
    }

    private DateTime _PROJECT_STARTDATE;
    public DateTime PROJECT_STARTDATE
    {
        get { return _PROJECT_STARTDATE; }
        set { _PROJECT_STARTDATE = value; }
    }

    private DateTime _PROJECT_ENDDATE;
    public DateTime PROJECT_ENDDATE
    {
        get { return _PROJECT_ENDDATE; }
        set { _PROJECT_ENDDATE = value; }
    }

    private int _PROJECT_CREATEDBY;
    public int PROJECT_CREATEDBY
    {
        get { return _PROJECT_CREATEDBY; }
        set { _PROJECT_CREATEDBY = value; }
    }

    private int _PROJECT_LASTMDFBY;
    public int PROJECT_LASTMDFBY
    {
        get { return _PROJECT_LASTMDFBY; }
        set { _PROJECT_LASTMDFBY = value; }
    }

    private DateTime _PROJECT_CREATEDDATE;
    public DateTime PROJECT_CREATEDDATE
    {
        get { return _PROJECT_CREATEDDATE; }
        set { _PROJECT_CREATEDDATE = value; }
    }

    private DateTime _PROJECT_LASTMDFDATE;
    public DateTime PROJECT_LASTMDFDATE
    {
        get { return _PROJECT_LASTMDFDATE; }
        set { _PROJECT_LASTMDFDATE = value; }
    }

    private string _PROJECT_ISDELETED;
    public string PROJECT_ISDELETED
    {
        get { return _PROJECT_ISDELETED; }
        set { _PROJECT_ISDELETED = value; }
    }

    private operation _OPERATION;
    public operation OPERATION
    {
        get { return _OPERATION; }
        set { _OPERATION = value; }
    }

    /*
    public SMHR_PROJECT()
    {

    }
    public int PROJECT_ID { get; set; }
    public string PROJECT_NAME { get; set; }
    public string PROJECT_CODE { get; set; }
    public string PROJECT_DESC { get; set; }
    public int PROJECT_ORGANISATION_ID { get; set; }
    public int PROJECT_BUSINESSUNIT_ID { get; set; }
    public DateTime PROJECT_STARTDATE { get; set; }
    public DateTime PROJECT_ENDDATE { get; set; }
    public int PROJECT_CREATEDBY { get; set; }
    public int PROJECT_LASTMDFBY { get; set; }
    public DateTime PROJECT_CREATEDDATE { get; set; }
    public DateTime PROJECT_LASTMDFDATE { get; set; }
    public operation OPERATION { get; set; }
    public string PROJECT_ISDELETED { get; set; }*/
}

#endregion

#region ALLOWANCE
public class SMHR_ALLOWANCE : SMHR_MAIN
{
    private int _ALLOWANCE_ID;

    public int ALLOWANCE_ID
    {
        get { return _ALLOWANCE_ID; }
        set { _ALLOWANCE_ID = value; }
    }
    private int _ALLOWANCE_ORG_ID;
    public int ALLOWANCE_ORG_ID
    {
        get { return _ALLOWANCE_ORG_ID; }
        set { _ALLOWANCE_ORG_ID = value; }
    }
    private int _ALLOWANCE_PERIOD_ID;
    public int ALLOWANCE_PERIOD_ID
    {
        get { return _ALLOWANCE_PERIOD_ID; }
        set { _ALLOWANCE_PERIOD_ID = value; }
    }
    private int _ALLOWANCE_EMPLOYEEGRADE_ID;
    public int ALLOWANCE_EMPLOYEEGRADE_ID
    {
        get { return _ALLOWANCE_EMPLOYEEGRADE_ID; }
        set { _ALLOWANCE_EMPLOYEEGRADE_ID = value; }
    }
    private decimal _ALLOWANCE_DEPENDENT;
    public decimal ALLOWANCE_DEPENDENT
    {
        get { return _ALLOWANCE_DEPENDENT; }
        set { _ALLOWANCE_DEPENDENT = value; }
    }
    private int _ALLOWANCE_ELIGIBLE;
    public int ALLOWANCE_ELIGIBLE
    {
        get { return _ALLOWANCE_ELIGIBLE; }
        set { _ALLOWANCE_ELIGIBLE = value; }
    }

    private DataTable _ALLOWANCE_GRIDDATA;

    public DataTable ALLOWANCE_GRIDDATA
    {
        get { return _ALLOWANCE_GRIDDATA; }
        set { _ALLOWANCE_GRIDDATA = value; }
    }

    private int _ALLOWANCE_CREATEDBY;
    public int ALLOWANCE_CREATEDBY
    {
        get { return _ALLOWANCE_CREATEDBY; }
        set { _ALLOWANCE_CREATEDBY = value; }
    }
    private DateTime _ALLOWANCE_CREATEDDATE;
    public DateTime ALLOWANCE_CREATEDDATE
    {
        get { return _ALLOWANCE_CREATEDDATE; }
        set { _ALLOWANCE_CREATEDDATE = value; }
    }
    private int _ALLOWANCE_LASTMDFBY;
    public int ALLOWANCE_LASTMDFBY
    {
        get { return _ALLOWANCE_LASTMDFBY; }
        set { _ALLOWANCE_LASTMDFBY = value; }
    }
    private DateTime _ALLOWANCE_LASTMDFDATE;
    public DateTime ALLOWANCE_LASTMDFDATE
    {
        get { return _ALLOWANCE_LASTMDFDATE; }
        set { _ALLOWANCE_LASTMDFDATE = value; }
    }

    private int _ALLOWANCE_CONFG_ID;
    public int ALLOWANCE_CONFG_ID
    {
        get { return _ALLOWANCE_CONFG_ID; }
        set { _ALLOWANCE_CONFG_ID = value; }
    }
}
#endregion

#region EDU_ALLOWANCE
public class SMHR_EDU_ALLOWANCE : SMHR_MAIN
{
    public int EDU_ID { get; set; }
    public int EDU_EMP_ID { get; set; }
    public int EDU_ORG_ID { get; set; }
    public int EDU_BU_ID { get; set; }
    public int EDU_DEPT_ID { get; set; }
    public int EDU_EMPLOYEEGRADE_ID { get; set; }
    public int EDU_ALLOWANCE_DEPENDENT { get; set; }
    public int EDU_EMPFMDTL_ID { get; set; }
    public decimal EDU_BAL_AVL { get; set; }
    public string EDU_EXPEN_NAME { get; set; }
    public decimal EDU_CLAIM_AMT { get; set; }
    public int EDU_RECPT_NO { get; set; }
    public DateTime EDU_RECPT_DATE { get; set; }
    public string EDU_UPLOAD_RECPTDOC { get; set; }
    public string EDU_UPLOAD_ATTDCERT { get; set; }
    public bool EDU_IS_FINALIZE { get; set; }
    public int EDU_CREATEDBY { get; set; }
    public DateTime EDU_CREATEDDATE { get; set; }
    public int EDU_LASTMDFBY { get; set; }
    public DateTime EDU_LASTMDFDATE { get; set; }
    public int EDU_STATUS { get; set; }
    public int EDU_PERIOD_ID { get; set; }
    public decimal EDU_FINAL_AMNT { get; set; }
    public int EDU_CURR_ID { get; set; }
    public decimal EDU_CURR_AMT { get; set; }
    public decimal EDU_CONVERION_AMT { get; set; }
    public int EDU_CONFIRMEDBY { get; set; }
    public int EDU_APPROVEDBY { get; set; }
    public DateTime EDU_APPROVEDDATE { get; set; }
    public DateTime EDU_CONFIRMEDDATE { get; set; }
    public bool EDU_ISRULEID { get; set; }
}
#endregion

#region SMHR_AuditTrail
public class SMHR_AuditTrail : SMHR_MAIN
{
    public int AUD_ID { get; set; }
    public string AUD_FormName { get; set; }
    public string AUD_ModifiedBy { get; set; }
    public DateTime AUD_ModifiedDate { get; set; }
    public string AUD_OldValue { get; set; }
    public string AUD_NewValue { get; set; }
    public string AUD_Desc { get; set; }
  
}
#endregion
