using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using RECRUITMENT;

public enum operation1
{
    Select,
    Insert,
    check,
    Update,
    Delete,
    CHECK22,
    MODE

}

public class RECRUITMENT_MAIN
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

    private int _LOGIN_ID;

    public int LOGIN_ID
    {
        get { return (this._LOGIN_ID); }
        set { this._LOGIN_ID = value; }
    }
}
#region Notification
public class RECRUITMENT_NOTIFICATION : RECRUITMENT_MAIN
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
}

#endregion
#region RECRUITMENT_LOGININFO
public class RECRUITMENT_LOGININFO : RECRUITMENT_MAIN
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

public class RECRUITMENT_APPLICANTGRADE : RECRUITMENT_MAIN
{
    public RECRUITMENT_APPLICANTGRADE(int __APPLGRADE_ID)
    {
        this._APPLGRADE_ID = __APPLGRADE_ID;
    }

    public RECRUITMENT_APPLICANTGRADE()
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

public class RECRUITMENT_GETEMPLOYEE : RECRUITMENT_MAIN
{


    public RECRUITMENT_GETEMPLOYEE()
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

public class RECRUITMENT_APPROVALPROCESS : RECRUITMENT_MAIN
{
    public RECRUITMENT_APPROVALPROCESS(int __APPRO_ID)
    {
        this._APPRO_ID = __APPRO_ID;
    }

    public RECRUITMENT_APPROVALPROCESS()
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
    private int _APPRO_1LEVEL;
    public int APPRO_1LEVEL
    {
        get { return (this._APPRO_1LEVEL); }
        set { this._APPRO_1LEVEL = value; }
    }

    private int _APPRO_2LEVEL;
    public int APPRO_2LEVEL
    {
        get { return (this._APPRO_2LEVEL); }
        set { this._APPRO_2LEVEL = value; }
    }

    private int _APPRO_3LEVEL;
    public int APPRO_3LEVEL
    {
        get { return (this._APPRO_3LEVEL); }
        set { this._APPRO_3LEVEL = value; }
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

    private int _APPRO_ORGANISATION_ID;
    public int APPRO_ORGANISATION_ID
    {
        get { return (this._APPRO_ORGANISATION_ID); }
        set { this._APPRO_ORGANISATION_ID = value; }
    }


    private int _Mode;
    public int Mode
    {
        get { return (this._Mode); }
        set { this._Mode = value; }
    }
}

public class RECRUITMENT_INTERVIEWASSESSMENTFORM : RECRUITMENT_MAIN
{
    public RECRUITMENT_INTERVIEWASSESSMENTFORM(int __IAF_ID)
    {
        this._IAF_ID = __IAF_ID;
    }

    public RECRUITMENT_INTERVIEWASSESSMENTFORM()
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
    private string _ASSESSMENT_TYPE;
    public string ASSESSMENT_TYPE
    {
        get { return _ASSESSMENT_TYPE; }
        set { _ASSESSMENT_TYPE = value; }
    }

    private string _ASSESSMENT_APPLICABLEFOR;
    public string ASSESSMENT_APPLICABLEFOR
    {
        get { return _ASSESSMENT_APPLICABLEFOR; }
        set { _ASSESSMENT_APPLICABLEFOR = value; }
    }
}

public class RECRUITMENT_JOBREQUISITION : RECRUITMENT_MAIN
{
    public RECRUITMENT_JOBREQUISITION(int __JOBREQ_ID)
    {
        this._JOBREQ_ID = __JOBREQ_ID;
    }

    public RECRUITMENT_JOBREQUISITION()
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

    public int JOBREQ_PERIOD_ID { get; set; }

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

    private DateTime? _JOBREQ_REQEXPIRY;
    public DateTime? JOBREQ_REQEXPIRY
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
    private int _JOBREQ_BUSINESSUNIT_ID;
    public int JOBREQ_BUSINESSUNIT_ID
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
    private decimal _JOBREQ_EXPYEARS;
    public decimal JOBREQ_EXPYEARS
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

    private string _JOBREQ_REQFOR;
    public string JOBREQ_REQFOR
    {
        get { return (this._JOBREQ_REQFOR); }
        set { this._JOBREQ_REQFOR = value; }
    }

    private string _JOBREQ_REQTOWORK;
    public string JOBREQ_REQTOWORK
    {
        get { return (this._JOBREQ_REQTOWORK); }
        set { this._JOBREQ_REQTOWORK = value; }
    }

    private string _JOBREQ_INTERVIEWER;
    public string JOBREQ_INTERVIEWER
    {
        get { return (this._JOBREQ_INTERVIEWER); }
        set { this._JOBREQ_INTERVIEWER = value; }
    }

    private string _JOBREQ_LOCATION;
    public string JOBREQ_LOCATION
    {
        get { return (this._JOBREQ_LOCATION); }
        set { this._JOBREQ_LOCATION = value; }
    }

    private string _JOBREQ_EMPTYPE;
    public string JOBREQ_EMPTYPE
    {
        get { return (this._JOBREQ_EMPTYPE); }
        set { this._JOBREQ_EMPTYPE = value; }
    }

    private int _JOBREQ_GRADE;
    public int JOBREQ_GRADE
    {
        get { return (this._JOBREQ_GRADE); }
        set { this._JOBREQ_GRADE = value; }
    }

    private string _JOBREQ_RECRUITMENTFOR;
    public string JOBREQ_RECRUITMENTFOR
    {
        get { return (this._JOBREQ_RECRUITMENTFOR); }
        set { this._JOBREQ_RECRUITMENTFOR = value; }
    }
    private int _JOBREQ_LEVEL;
    public int JOBREQ_LEVEL
    {
        get { return _JOBREQ_LEVEL; }
        set { _JOBREQ_LEVEL = value; }
    }
    private string _JOBREQ_CURRENTSTATUS;
    public string JOBREQ_CURRENTSTATUS
    {
        get { return (this._JOBREQ_CURRENTSTATUS); }
        set { this._JOBREQ_CURRENTSTATUS = value; }
    }   
}

public class RECRUITMENT_INTERVIEW_PHASE_DEF : RECRUITMENT_MAIN
{

    public RECRUITMENT_INTERVIEW_PHASE_DEF(int __Phase_ID)
    {
        this._Phase_ID = __Phase_ID;
    }
    public RECRUITMENT_INTERVIEW_PHASE_DEF()
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

    private int _Phase_POSID;
    public int Phase_POSID
    {
        get { return _Phase_POSID; }
        set { _Phase_POSID = value; }
    }

    private string _Phase_POSCODE;
    public string Phase_POSCODE
    {
        get { return _Phase_POSCODE; }
        set { _Phase_POSCODE = value; }
    }

    private string _Phase_Name;
    public string Phase_Name
    {
        get { return _Phase_Name; }
        set { _Phase_Name = value; }
    }

    private DateTime? _Phase_InterviewFromDate;
    public DateTime? Phase_InterviewFromDate
    {
        get { return _Phase_InterviewFromDate; }
        set { _Phase_InterviewFromDate = value; }
    }

    private DateTime? _Phase_InterviewToDate;
    public DateTime? Phase_InterviewToDate
    {
        get { return _Phase_InterviewToDate; }
        set { _Phase_InterviewToDate = value; }
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

public class RECRUITMENT_RESUMESHORTLIST :  RECRUITMENT_MAIN
{
    public RECRUITMENT_RESUMESHORTLIST(int __RESSHT_ID)
    {
        this._RESSHT_ID = __RESSHT_ID;
    }

    public RECRUITMENT_RESUMESHORTLIST()
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


    private int _RESSHT_ORGANISATION_ID;
    public int RESSHT_ORGANISATION_ID
    {
        get { return (this._RESSHT_ORGANISATION_ID); }
        set { this._RESSHT_ORGANISATION_ID = value; }
    }

    private int _Mode;
    public int Mode
    {
        get { return _Mode; }
        set { _Mode = value; }
    }

}

public class RECRUITMENT_INTERVIEW_PHASE_REMARKS : RECRUITMENT_MAIN
{
    public RECRUITMENT_INTERVIEW_PHASE_REMARKS(int __INTREM_ID)
    {
        this._INTREM_ID = __INTREM_ID;
    }

    public RECRUITMENT_INTERVIEW_PHASE_REMARKS()
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

    private string _INTREM_OVERALLASSESSMENT;
    public string INTREM_OVERALLASSESSMENT
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

    private DateTime? _INTREM_JOININGDATE;
    public DateTime? INTREM_JOININGDATE
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
    private string _INTREM_STATUS;
    public string INTREM_STATUS
    {
        get { return _INTREM_STATUS; }
        set { _INTREM_STATUS = value; }
    }

    private decimal _INTREM_JOININGBONUS;
    public decimal INTREM_JOININGBONUS
    {
        get { return _INTREM_JOININGBONUS; }
        set { _INTREM_JOININGBONUS = value; }
    }

}

public class RECRUITMENT_SKILLSCATEGARY : RECRUITMENT_MAIN
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

    private int _SKILLCAT_ORGANISATION_ID;
    public int SKILLCAT_ORGANISATION_ID
    {
        get { return (this._SKILLCAT_ORGANISATION_ID); }
        set { this._SKILLCAT_ORGANISATION_ID = value; }

    }

    public int SKILL_JR_ID { get; set; }

}

public class RECRUITMENT_INTERVIEWPRIORITY : RECRUITMENT_MAIN
{
    private int _PRIORITY_ID;
    public int PRIORITY_ID
    {
        get { return (this._PRIORITY_ID); }
        set { this._PRIORITY_ID = value; }

    }
    private int _INTVPRIORITY_PRIORITYID;
    public int INTVPRIORITY_PRIORITYID
    {
        get { return (this._INTVPRIORITY_PRIORITYID); }
        set { this._INTVPRIORITY_PRIORITYID = value; }

    }
    private int _PHASE_ID;
    public int PHASE_ID
    {
        get { return (this._PHASE_ID); }
        set { this._PHASE_ID = value; }

    }

    private string _PRIORITY_NAME;
    public string PRIORITY_NAME
    {
        get { return (this._PRIORITY_NAME); }
        set { this._PRIORITY_NAME = value; }
    }
    private string _PRIORITY_DESCRIPTION;
    public string PRIORITY_DESCRIPTION
    {
        get { return (this._PRIORITY_DESCRIPTION); }
        set { this._PRIORITY_DESCRIPTION = value; }
    }

    private int _PRIORITY_ORGANISATION_ID;
    public int PRIORITY_ORGANISATION_ID
    {
        get { return (this._PRIORITY_ORGANISATION_ID); }
        set { this._PRIORITY_ORGANISATION_ID = value; }

    }

}


public class RECRUITMENT_INTERVIEW_PHASE_DEF_SKILLS : RECRUITMENT_MAIN
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
    private int _PHASE_DEF_SKILLS_ORGANISATION_ID;
    public int PHASE_DEF_SKILLS_ORGANISATION_ID
    {
        get { return (this._PHASE_DEF_SKILLS_ORGANISATION_ID); }
        set { this._PHASE_DEF_SKILLS_ORGANISATION_ID = value; }
    }



}

public class RECRUITMENT_JOBREQSKILLS : RECRUITMENT_MAIN
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

public class RECRUITMENT_INTERVIEW_PRIORITY
{
    public RECRUITMENT_INTERVIEW_PRIORITY(int __PRIORITY_ID)
    {
        this._PRIORITY_ID = __PRIORITY_ID;
    }

    public RECRUITMENT_INTERVIEW_PRIORITY()
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


    private string _PRIORITY_NAME;
    public string PRIORITY_NAME
    {
        get { return _PRIORITY_NAME; }
        set { _PRIORITY_NAME = value; }
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

public class RECRUITMENT_INTERVIEW_ROUND
{
    public RECRUITMENT_INTERVIEW_ROUND(int __INTERVIEWROUND_ID)
    {
        this._INTERVIEWROUND_ID = __INTERVIEWROUND_ID;
    }

    public RECRUITMENT_INTERVIEW_ROUND()
    { }

    private int _INTERVIEWROUND_ID;
    public int INTERVIEWROUND_ID
    {
        get { return _INTERVIEWROUND_ID; }
        set { _INTERVIEWROUND_ID = value; }
    }

    private int _INTERVIEWROUND_NAME;
    public int INTERVIEWROUND_NAME
    {
        get { return _INTERVIEWROUND_NAME; }
        set { _INTERVIEWROUND_NAME = value; }
    }


    private string _INTERVIEWROUND_VALUE;
    public string INTERVIEWROUND_VALUE
    {
        get { return _INTERVIEWROUND_VALUE; }
        set { _INTERVIEWROUND_VALUE = value; }
    }

    private int _MODE;
    public int MODE
    {
        get { return _MODE; }
        set { _MODE = value; }
    }

    private int _INTERVIEWROUND_ORGANIZATIONID;
    public int INTERVIEWROUND_ORGANIZATIONID
    {
        get { return _INTERVIEWROUND_ORGANIZATIONID; }
        set { _INTERVIEWROUND_ORGANIZATIONID = value; }
    }

}

public class RECRUITMENT_JOBOFFERS : RECRUITMENT_MAIN
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
    private int _JOBOFFRS_ORGANISATION_ID;
    public int JOBOFFRS_ORGANISATION_ID
    {
        get { return (this._JOBOFFRS_ORGANISATION_ID); }
        set { this._JOBOFFRS_ORGANISATION_ID = value; }
    }



}
public class RECRUITMENT_ASSIGNEMPTORSL : RECRUITMENT_MAIN
{
    public RECRUITMENT_ASSIGNEMPTORSL(int __ASSIGNEMP_ID)
    {
        this._ASSIGNEMP_ID = __ASSIGNEMP_ID;
    }

    public RECRUITMENT_ASSIGNEMPTORSL()
    {
    }

    private int _ASSIGNEMP_ID;
    public int ASSIGNEMP_ID
    {
        get { return (this._ASSIGNEMP_ID); }
        set { this._ASSIGNEMP_ID = value; }
    }

    private int _ASSIGNEMP_BUID;
    public int ASSIGNEMP_BUID
    {
        get { return (this._ASSIGNEMP_BUID); }
        set { this._ASSIGNEMP_BUID = value; }
    }
    private int _ASSIGNEMP_EMP_ID;
    public int ASSIGNEMP_EMP_ID
    {
        get { return (this._ASSIGNEMP_EMP_ID); }
        set { this._ASSIGNEMP_EMP_ID = value; }
    }

    private int _ASSIGNEMP_DEPT;
    public int ASSIGNEMP_DEPT
    {
        get { return (this._ASSIGNEMP_DEPT); }
        set { this._ASSIGNEMP_DEPT = value; }
    }

    private int _ASSIGNEMP_JOBREQ;
    public int ASSIGNEMP_JOBREQ
    {
        get { return (this._ASSIGNEMP_JOBREQ); }
        set { this._ASSIGNEMP_JOBREQ = value; }
    }
}

#region RECRUITMENT_ASSESSMENTS

public class RECRUITMENT_ASSESSMENTS : RECRUITMENT_MAIN
{
    private int _ASSESSMENT_ID;
    public int ASSESSMENT_ID
    {
        get { return (this._ASSESSMENT_ID); }
        set { this._ASSESSMENT_ID = value; }
    }

    private int _ASSESSMENT_TYPE;
    public int ASSESSMENT_TYPE
    {
        get { return (this._ASSESSMENT_TYPE); }
        set { this._ASSESSMENT_TYPE = value; }
    }

    private string _ASSESSMENT_NAME;
    public string ASSESSMENT_NAME
    {
        get { return (this._ASSESSMENT_NAME); }
        set { this._ASSESSMENT_NAME = value; }
    }

    private string _ASSESSMENT_DESC;
    public string ASSESSMENT_DESC
    {
        get { return (this._ASSESSMENT_DESC); }
        set { this._ASSESSMENT_DESC = value; }
    }

    private string _ASSESSMENT_APPLICABLEFOR;
    public string ASSESSMENT_APPLICABLEFOR
    {
        get { return (this._ASSESSMENT_APPLICABLEFOR); }
        set { this._ASSESSMENT_APPLICABLEFOR = value; }
    }
}
#endregion
#region RECRUITMENT_IAF_RATING

public class RECRUITMENT_IAF_RATING : RECRUITMENT_MAIN
{
    private int _IAF_RATING_ID;
    public int IAF_RATING_ID
    {
        get { return (this._IAF_RATING_ID); }
        set { this._IAF_RATING_ID = value; }
    }

    private int _IAF_RATING_IAF_ID;
    public int IAF_RATING_IAF_ID
    {
        get { return (this._IAF_RATING_IAF_ID); }
        set { this._IAF_RATING_IAF_ID = value; }
    }

    private int _IAF_RATING_ASSESSMENT_TYPE;
    public int IAF_RATING_ASSESSMENT_TYPE
    {
        get { return (this._IAF_RATING_ASSESSMENT_TYPE); }
        set { this._IAF_RATING_ASSESSMENT_TYPE = value; }
    }

    private int _IAF_RATING_ASSESSMNET_ID;
    public int IAF_RATING_ASSESSMNET_ID
    {
        get { return (this._IAF_RATING_ASSESSMNET_ID); }
        set { this._IAF_RATING_ASSESSMNET_ID = value; }
    }

    private decimal _IAF_RATING_RATING;
    public decimal IAF_RATING_RATING
    {
        get { return (this._IAF_RATING_RATING); }
        set { this._IAF_RATING_RATING = value; }
    }
    private string _IAF_RATING_REMARKS;
    public string IAF_RATING_REMARKS
    {
        get { return (this._IAF_RATING_REMARKS); }
        set { this._IAF_RATING_REMARKS = value; }
    }
}
#endregion

#region RECRUITMENT_IAF_RATING

public class RECRUITMENT_IAF_GENERALINFO : RECRUITMENT_MAIN
{
    private int _IAF_GENERALINFO_ID;
    public int IAF_GENERALINFO_ID
    {
        get { return (this._IAF_GENERALINFO_ID); }
        set { this._IAF_GENERALINFO_ID = value; }
    }

    private int _IAF_GENERALINFO_IAFID;
    public int IAF_GENERALINFO_IAFID
    {
        get { return (this._IAF_GENERALINFO_IAFID); }
        set { this._IAF_GENERALINFO_IAFID = value; }
    }

    private decimal _IAF_GENERALINFO_EXPECTEDCTC;
    public decimal IAF_GENERALINFO_EXPECTEDCTC
    {
        get { return (this._IAF_GENERALINFO_EXPECTEDCTC); }
        set { this._IAF_GENERALINFO_EXPECTEDCTC = value; }
    }

    private int _IAF_GENERALINFO_AVAILABILITY;
    public int IAF_GENERALINFO_AVAILABILITY
    {
        get { return (this._IAF_GENERALINFO_AVAILABILITY); }
        set { this._IAF_GENERALINFO_AVAILABILITY = value; }
    }

    private string _IAF_GENERALINFO_ONSITE;
    public string IAF_GENERALINFO_ONSITE
    {
        get { return (this._IAF_GENERALINFO_ONSITE); }
        set { this._IAF_GENERALINFO_ONSITE = value; }
    }
    private string _IAF_GENERALINFO_RELOCATION;
    public string IAF_GENERALINFO_RELOCATION
    {
        get { return (this._IAF_GENERALINFO_RELOCATION); }
        set { this._IAF_GENERALINFO_RELOCATION = value; }
    }
    private string _IAF_GENERALINFO_PASSPORT;
    public string IAF_GENERALINFO_PASSPORT
    {
        get { return (this._IAF_GENERALINFO_PASSPORT); }
        set { this._IAF_GENERALINFO_PASSPORT = value; }
    }
    private decimal _IAF_GENERALINFO_RELEXP;
    public decimal IAF_GENERALINFO_RELEXP
    {
        get { return (this._IAF_GENERALINFO_RELEXP); }
        set { this._IAF_GENERALINFO_RELEXP = value; }
    }
    private int _JOBREQ_ID;
    public int JOBREQ_ID
    {
        get { return (this._JOBREQ_ID); }
        set { this._JOBREQ_ID = value; }
    }
    private int _APPLICANT_ID;
    public int APPLICANT_ID
    {
        get { return (this._APPLICANT_ID); }
        set { this._APPLICANT_ID = value; }
    }
}
#endregion

public class Recruitment_Translayer
{
	public Recruitment_Translayer()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
