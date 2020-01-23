using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SMHR;
using Telerik.Web.UI;
using System.IO;
using System.Data.OleDb;

public partial class Recruitment_frmapplicant : System.Web.UI.Page
{
    SMHR_APPLICANT _obj_smhr_applicant;
    string strfilename2;
    string aplicantcode;
    int Year;
    int app_id;
    DataSet ds = new DataSet();
    DataSet ds_personal = new DataSet();
    DataSet ds_Qualification = new DataSet();
    DataSet ds_skills = new DataSet();
    DataSet ds_experiance = new DataSet();
    DataSet ds_contact = new DataSet();
    DataSet ds_language = new DataSet();

    bool stdatetime;

    static DataTable dt_Details = new DataTable();
    static DataTable dtExperience = new DataTable(); //Datatable for Experience
    static DataTable dt_Contact = new DataTable(); // Datatable for Contact
    static DataTable dtLanguage = new DataTable(); // Datatable for Langugae
    static DataTable dt_Skill = new DataTable(); // Datatable for Skill
    static DataTable dtReference = new DataTable(); //Datatable for Reference
    static DataTable dt_Qual = new DataTable(); //Datatable for Qualification

    static string _lbl_App_ID = "";

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                string control = string.Empty;
                if (Request.QueryString.HasKeys())
                {
                    control = Convert.ToString(Request.QueryString["control"]);
                }
                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                if (control == "1")
                {
                    _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Applicant Details");
                }
                else
                {
                    _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("APPLICANT");
                }
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
                    RG_Applicant.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
            }
            BLL.gridDateFormat(Convert.ToString(Session["EMP_ID"]), RG_Applicant, "APPLICANT_DOB");
            if (RWM_POSTREPLY1.Windows.Count > 0)
            {
                RWM_POSTREPLY1.Windows.RemoveAt(0);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmapplicant", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Click(object sender, EventArgs e)
    {
        try
        {
            Session["APPLICANT"] = null;
            //code to check the applicant count : Anirudh

            SMHR_ORGANISATION _obj_Smhr_Organisation = new SMHR_ORGANISATION();
            _obj_Smhr_Organisation.MODE = 8;
            _obj_Smhr_Organisation.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            DataTable dt = BLL.get_Organisation(_obj_Smhr_Organisation);
            if (dt.Rows.Count != 0)
            {
                if (Convert.ToString(dt.Rows[0]["ORGANISATION_APPLICANTS"]) == "0")
                {
                    Response.Redirect("frm_applicantadd.aspx", false);
                }
                else
                {
                    SMHR_APPLICANT _obj_smhr_applicant = new SMHR_APPLICANT();
                    _obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtDetails = BLL.get_Applicant(_obj_smhr_applicant);
                    string Val = BLL.PasswordDecrypt(Convert.ToString(dt.Rows[0]["ORGANISATION_APPLICANTS"]));
                    string strVal = Convert.ToString(dtDetails.Rows.Count);
                    if (dtDetails.Rows.Count != 0)
                    {
                        //if (BLL.PasswordDecrypt(Convert.ToString(dt.Rows[0]["ORGANISATION_APPLICANTS"])) != Convert.ToString(dtDetails.Rows.Count))
                        if (Val != strVal)
                        {
                            //if (Convert.ToInt32(BLL.PasswordDecrypt(Convert.ToString(dt.Rows[0]["ORGANISATION_APPLICANTS"]))) > Convert.ToInt32(Convert.ToString(dtDetails.Rows.Count)))
                            if (Convert.ToInt32(Val) > Convert.ToInt32(strVal))
                            {
                                string control = string.Empty;
                                if (Request.QueryString.HasKeys())
                                {
                                    control = Convert.ToString(Request.QueryString["control"]);
                                }
                                if (control == "1")
                                {
                                    Response.Redirect("~/Recruitment/frm_applicantadd.aspx?control=1", false);
                                }
                                else
                                {
                                    Response.Redirect("~/Recruitment/frm_applicantadd.aspx", false);
                                }
                            }
                            else
                            {
                                _obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                _obj_smhr_applicant.OPERATION = operation.Validate1;
                                // CHECKING THE ACTUAL COUNT OF THE APPLICANT AS EMPLOYEE ALSO CONVERTED INTO APPLICANT
                                DataTable dt_Applicantcount = BLL.get_Applicant(_obj_smhr_applicant);
                                if (dt_Applicantcount.Rows.Count > 0)
                                {
                                    if (Convert.ToInt32(dt_Applicantcount.Rows[0][0]) <= Convert.ToInt32(Val))
                                    {
                                        string control = string.Empty;
                                        if (Request.QueryString.HasKeys())
                                        {
                                            control = Convert.ToString(Request.QueryString["control"]);
                                        }
                                        if (control == "1")
                                        {
                                            Response.Redirect("~/Recruitment/frm_applicantadd.aspx?control=1", false);
                                        }
                                        else
                                        {
                                            Response.Redirect("~/Recruitment/frm_applicantadd.aspx", false);
                                        }
                                    }
                                    else
                                    {
                                        BLL.ShowMessage(this, "You have only limited no of users License. You cannot create more applicants");
                                        return;
                                    }
                                }
                                else
                                {
                                    BLL.ShowMessage(this, "You have only limited no of users License. You cannot create more applicants");
                                    return;
                                }
                            }

                        }
                        else
                        {
                            // if count of the  val (limit of applicants) and strval(count of the applicants from applicant table)are same
                            _obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_smhr_applicant.OPERATION = operation.Validate1;
                            // CHECKING THE ACTUAL COUNT OF THE APPLICANT AS EMPLOYEE ALSO CONVERTED INTO APPLICANT
                            DataTable dt_Applicantcount = BLL.get_Applicant(_obj_smhr_applicant);
                            if (dt_Applicantcount.Rows.Count > 0)
                            {
                                if (Convert.ToInt32(dt_Applicantcount.Rows[0][0]) <= Convert.ToInt32(Val))
                                {
                                    Response.Redirect("frm_applicantadd.aspx", false);
                                }
                                else
                                {
                                    BLL.ShowMessage(this, "You have only limited no of users License. You cannot create more applicants");
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {
                        Response.Redirect("~/Recruitment/frm_applicantadd.aspx", false);
                    }
                }
            }
            else
            {
                Response.Redirect("~/Recruitment/frm_applicantadd.aspx", false);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmapplicant", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        //Response.Redirect("~/Recruitment/frm_applicantadd.aspx");
    }

    protected void lnk_Applicant_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            _obj_smhr_applicant = new SMHR_APPLICANT();
            _lbl_App_ID = Convert.ToString(e.CommandArgument);
            Response.Redirect("~/Recruitment/frm_applicantadd.aspx?APPID=" + Convert.ToString(_lbl_App_ID), false);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmapplicant", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadData()
    {
        try
        {
            _obj_smhr_applicant = new SMHR_APPLICANT();
            _obj_smhr_applicant.OPERATION = operation.Delete;
            _obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_Applicant(_obj_smhr_applicant);
            RG_Applicant.DataSource = dt_Details;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmapplicant", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void RG_Applicant_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadData();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmapplicant", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }



    // import functionality......

    protected void btn_Imp_personal_Click(object sender, EventArgs e)
    {

        try
        {
            // written by rajasekhar
            //to import  personal details
            string strcon = null;

            string strfilename1 = Up_aplicntPersonal.FileName;
            strfilename2 = Convert.ToString(DateTime.Now.TimeOfDay) + "_" + strfilename1;
            strfilename2 = strfilename2.Replace("/", "").Replace(":", ".");
            if (Up_aplicntPersonal.HasFile)
            {

                if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == false)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath("~/IMPORT_EXCEL/"));

                }



                Up_aplicntPersonal.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/IMPORT_EXCEL/"), strfilename2));
                string filename1 = Server.MapPath("~/IMPORT_EXCEL/") + ("") + (Convert.ToString(strfilename2));
                FileInfo fileInfo = new FileInfo(filename1);
                if (fileInfo.Exists)
                {
                    string path = MapPath(strfilename1);
                    // string name = Path.GetFileName( path );
                    string ext = Path.GetExtension(path);

                    string type = string.Empty;
                    //  set known types based on file extension  
                    if (ext != null)
                    {
                        switch (ext.ToLower())
                        {

                            case ".xls":

                                type = "excel";
                                break;
                            case ".xlsx":
                                type = "excel";
                                break;

                            default:
                                type = string.Empty;
                                break;
                        }
                    }
                    if (type == string.Empty)
                    {
                        if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == true)
                        {

                            string path1 = Server.MapPath("~/IMPORT_EXCEL/") + ("") + (Convert.ToString(strfilename2));
                            System.IO.File.Delete(path1);
                        }
                        BLL.ShowMessage(this, "Please select the Excel File  (Eg: Excel.xlsx). ");
                        return;
                    }
                }
            }


            else
            {
                BLL.ShowMessage(this, "Please Select the File to be uploaded");
                return;
            }

            string strpath = Server.MapPath("~/IMPORT_EXCEL/");

            strpath = strpath + strfilename2;


            // Getting data from excell file to dataset.
            strcon = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source='" + strpath + "';" + "Extended Properties=Excel 12.0;";


            OleDbConnection objConn = null;
            objConn = new OleDbConnection(strcon);
            objConn.Open();

            DataTable dt_chk2 = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string sheetname;
            if (dt_chk2 == null)
            {
                objConn.Close();
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            else
            {
                sheetname = Convert.ToString(dt_chk2.Rows[0]["TABLE_NAME"]);
            }
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM  [" + sheetname + "]", strcon);



            da.Fill(ds);

            objConn.Close();
            DataTable dt = new DataTable();
            DataTable dtfail = new DataTable();




            string projecttype = null;
            Int32 rowno = 0;

            DateTime dat;
            string columnno = null;
            string projname = null;
            Boolean filestatus = true;
            dtfail.Columns.Add("S.NO", typeof(Int32));
            dtfail.Columns.Add("ROWNO", typeof(Int32));
            dtfail.Columns.Add("COLUMNS NAMES", typeof(string));
            if (ds.Tables[0].Columns[0].ToString().Trim() == "Title*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[1].ToString().Trim() == "First Name*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[2].ToString().Trim() == "Middle Name")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[3].ToString().Trim() == "Last Name")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[4].ToString().Trim() == "Date of Birth*(DD/MM/YYYY)")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[5].ToString().Trim() == "Gender*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[6].ToString().Trim() == "Blood Group*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[7].ToString().Trim() == "Religion*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[8].ToString().Trim() == "Nationality*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[9].ToString().Trim() == "Status*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[10].ToString().Trim() == "Marital Status")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[11].ToString().Trim() == "Address")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }

            if (ds.Tables[0].Columns[12].ToString().Trim() == "Remarks")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }

            if (ds.Tables[0].Rows.Count == 0)
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Successfully processed Excel file. No Records are Imported.");
                return;
            }

            //to check the data in excel
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["Title*"].ToString().Trim() != "")
                {
                    if (ds.Tables[0].Rows[i]["Title*"].ToString().Trim() == "Mr." || ds.Tables[0].Rows[i]["Title*"].ToString().Trim() == "Ms." || ds.Tables[0].Rows[i]["Title*"].ToString().Trim() == "Mrs.")
                    {

                    }
                    else
                    {
                        filestatus = false;
                        rowno = i + 2;
                        columnno = "Title*";

                    }

                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = "Title*";

                }
                if (ds.Tables[0].Rows[i]["First Name*"].ToString().Trim() != "")
                {

                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "First Name*";

                }



                if (ds.Tables[0].Rows[i]["Date of Birth*(DD/MM/YYYY)"].ToString().Trim() != "")
                {

                    string dobdate = "";

                    dobdate = ds.Tables[0].Rows[i]["Date of Birth*(DD/MM/YYYY)"].ToString().Trim();

                    bool wrongsdformat = dobdate.Contains(".");

                    if (wrongsdformat)
                        dobdate = dobdate.Replace(".", "/");
                    bool Chkdate = CheckDateFormat(dobdate);


                    // bool Chkdate = CheckDateFormat(Convert.ToString(ds.Tables[0].Rows[i]["Date of Birth*(DD/MM/YYYY)"]));
                    if (Chkdate == true)
                    {

                        _obj_smhr_applicant = new SMHR_APPLICANT();
                        _obj_smhr_applicant.OPERATION = operation.Check_New;
                        _obj_smhr_applicant.APPLI_DOB = Convert.ToString(ds.Tables[0].Rows[i]["Date of Birth*(DD/MM/YYYY)"]);
                        DataTable dtdatecheck = BLL.CONVERTTODATE(_obj_smhr_applicant);


                        if ((Convert.ToString(dtdatecheck.Rows[0]["RESULT"])) == "ACCEPT")
                        {

                            stdatetime = true;
                        }
                        else
                        {

                            stdatetime = false;


                            filestatus = false;
                            rowno = i + 2;
                            columnno = columnno + "," + "Date of Birth*(DD/MM/YYYY)";


                        }



                    }

                    else
                    {
                        filestatus = false;
                        rowno = i + 2;
                        columnno = columnno + "," + "Date of Birth*(DD/MM/YYYY)";

                    }
                    if ((ds.Tables[0].Rows[i]["Title*"].ToString().Trim() == "Mr." && ds.Tables[0].Rows[i]["Gender*"].ToString().Trim() == "Male") || ((ds.Tables[0].Rows[i]["Title*"].ToString().Trim() == "Ms." || ds.Tables[0].Rows[i]["Title*"].ToString().Trim() == "Mrs.") && ds.Tables[0].Rows[i]["Gender*"].ToString().Trim() == "Female"))
                    {


                    }
                    else
                    {
                        filestatus = false;
                        rowno = i + 2;
                        columnno = columnno + "," + "Gender*";

                    }

                    if (ds.Tables[0].Rows[i]["Blood Group*"].ToString().Trim() == "O+" || ds.Tables[0].Rows[i]["Blood Group*"].ToString().Trim() == "O-" || ds.Tables[0].Rows[i]["Blood Group*"].ToString().Trim() == "B+" || ds.Tables[0].Rows[i]["Blood Group*"].ToString().Trim() == "B-" || ds.Tables[0].Rows[i]["Blood Group*"].ToString().Trim() == "AB+" || ds.Tables[0].Rows[i]["Blood Group*"].ToString().Trim() == "AB-" || ds.Tables[0].Rows[i]["Blood Group*"].ToString().Trim() == "A-")
                    {
                    }
                    else
                    {
                        filestatus = false;
                        rowno = i + 2;
                        columnno = columnno + "," + "Blood Group*";//Religion*


                    }
                    if (ds.Tables[0].Rows[i]["Religion*"].ToString().Trim() != "")
                    {
                        SMHR_MASTERS _Obj_smhr_Masters = new SMHR_MASTERS();

                        _Obj_smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _Obj_smhr_Masters.MASTER_TYPE = "RELIGION";
                        _Obj_smhr_Masters.OPERATION = operation.Check;

                        _Obj_smhr_Masters.MASTER_CODE = ds.Tables[0].Rows[i]["Religion*"].ToString().Trim();
                        DataTable dt_relig = BLL.get_Applicant_Validate(_Obj_smhr_Masters);
                        if (Convert.ToInt32(dt_relig.Rows[0]["COUNT"]) > 0)
                        {
                        }
                        else
                        {
                            filestatus = false;
                            rowno = i + 2;
                            columnno = columnno + "," + "Religion*";


                        }

                    }
                    else
                    {
                        filestatus = false;
                        rowno = i + 2;
                        columnno = columnno + "," + "Religion*";


                    }
                    if (ds.Tables[0].Rows[i]["Nationality*"].ToString().Trim() != "")
                    {
                        SMHR_MASTERS _Obj_smhr_Masters = new SMHR_MASTERS();
                        _Obj_smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _Obj_smhr_Masters.OPERATION = operation.Check;
                        _Obj_smhr_Masters.MASTER_TYPE = "NATIONALITY";
                        _Obj_smhr_Masters.MASTER_CODE = ds.Tables[0].Rows[i]["Nationality*"].ToString().Trim();
                        DataTable dt_nat = BLL.get_Applicant_Validate(_Obj_smhr_Masters);
                        if (Convert.ToInt32(dt_nat.Rows[0]["COUNT"]) > 0)
                        {
                        }
                        else
                        {
                            filestatus = false;
                            rowno = i + 2;
                            columnno = columnno + "," + "Nationality*";


                        }
                    }
                    else
                    {
                        filestatus = false;
                        rowno = i + 2;
                        columnno = columnno + "," + "Nationality*";


                    }
                    if (ds.Tables[0].Rows[i]["Status*"].ToString().Trim() == "Applied" || ds.Tables[0].Rows[i]["Status*"].ToString().Trim() == "Selected" || ds.Tables[0].Rows[i]["Status*"].ToString().Trim() == "Rejected")
                    {
                    }
                    else
                    {
                        filestatus = false;
                        rowno = i + 2;
                        columnno = columnno + "," + "Status*";
                        //Marital Status



                    }
                    if (ds.Tables[0].Rows[i]["Marital Status"].ToString().Trim() == "Single" || ds.Tables[0].Rows[i]["Marital Status"].ToString().Trim() == "Divorced" || ds.Tables[0].Rows[i]["Marital Status"].ToString().Trim() == "Married" || ds.Tables[0].Rows[i]["Marital Status"].ToString().Trim() == "Now Married")
                    {
                    }
                    else
                    {
                        filestatus = false;
                        rowno = i + 2;
                        columnno = columnno + "," + "Marital Status";




                    }
                    if (ds.Tables[0].Rows[i]["Address"].ToString().Trim() != "")
                    {

                    }


                    else
                    {
                        filestatus = false;
                        rowno = i + 2;
                        columnno = columnno + "," + "Address";




                    }

                    if (ds.Tables[0].Rows[i]["Remarks"].ToString().Trim() != "")
                    {

                    }


                    else
                    {
                        filestatus = false;
                        rowno = i + 2;
                        columnno = columnno + "," + "Remarks";




                    }

                    if (filestatus == false)
                    {
                        DataRow newrow = dtfail.NewRow();
                        newrow["S.NO"] = dtfail.Rows.Count + 1;


                        newrow["ROWNO"] = rowno;
                        newrow["COLUMNS NAMES"] = columnno;
                        dtfail.Rows.Add(newrow);
                    }


                }
            }
            if (dtfail.Rows.Count > 0)
            {
                Session["dt_fail"] = dtfail;
                Session["ds_data"] = ds;
                Delete_Excel_File();
                //LinkButton lnk_Import_process = (LinkButton)RadPanelBar1.FindItemByValue("AddAttachment").FindControl("lnk_Import_process");
                Telerik.Web.UI.RadWindow newwindow = new Telerik.Web.UI.RadWindow();
                // RWM_POSTREPLY.Windows.Remove(newwindow);
                newwindow.ID = "RadWindow_import";

                newwindow.NavigateUrl = "~/Payroll/frm_AttendanceImportProcess.aspx";
                newwindow.Title = "Import Process";
                newwindow.Width = 1150;
                newwindow.Height = 580;
                newwindow.VisibleOnPageLoad = true;
                if (RWM_POSTREPLY1.Windows.Count > 1)
                {
                    RWM_POSTREPLY1.Windows.RemoveAt(1);
                }
                RWM_POSTREPLY1.Windows.Add(newwindow);



                RWM_POSTREPLY1.Visible = true;
                return;

            }
            else
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    _obj_smhr_applicant = new SMHR_APPLICANT();
                    bool status = false;
                    getCode();
                    _obj_smhr_applicant.OPERATION = operation.Insert1;
                    _obj_smhr_applicant.APPLICANT_CODE = aplicantcode;
                    _obj_smhr_applicant.APPLICANT_TITLE = Convert.ToString(ds.Tables[0].Rows[i]["Title*"]).Trim();
                    _obj_smhr_applicant.APPLICANT_FIRSTNAME = (Convert.ToString(ds.Tables[0].Rows[i]["First Name*"]).Replace("'", "''"));
                    _obj_smhr_applicant.APPLICANT_MIDDLENAME = (Convert.ToString(ds.Tables[0].Rows[i]["Middle Name"]).Replace("'", "''"));
                    _obj_smhr_applicant.APPLICANT_LASTNAME = (Convert.ToString(ds.Tables[0].Rows[i]["Last Name"]).Replace("'", "''"));
                    _obj_smhr_applicant.APPLI_DOB = Convert.ToString(ds.Tables[0].Rows[i]["Date of Birth*(DD/MM/YYYY)"]);
                    // _obj_smhr_applicant.APPLICANT_DOB = Convert.ToDateTime(ds.Tables[0].Rows[i]["Date of Birth*(MM/DD/YYYY)"]);
                    _obj_smhr_applicant.APPLICANT_GENDER = Convert.ToString(ds.Tables[0].Rows[i]["Gender*"]).Trim();
                    _obj_smhr_applicant.APPLICANT_BLOODGROUP = Convert.ToString(ds.Tables[0].Rows[i]["Blood Group*"]).Trim();


                    SMHR_MASTERS _Obj_smhr_Masters = new SMHR_MASTERS();

                    _Obj_smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _Obj_smhr_Masters.MASTER_TYPE = "RELIGION";
                    _Obj_smhr_Masters.OPERATION = operation.Select;

                    _Obj_smhr_Masters.MASTER_CODE = ds.Tables[0].Rows[i]["Religion*"].ToString().Trim();
                    DataTable dt_relig1 = BLL.get_Applicant_Validate(_Obj_smhr_Masters);


                    _obj_smhr_applicant.APPLICANT_RELIGION_ID = Convert.ToInt32(dt_relig1.Rows[0]["HR_MASTER_ID"]);


                    _Obj_smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _Obj_smhr_Masters.MASTER_TYPE = "NATIONALITY";
                    _Obj_smhr_Masters.OPERATION = operation.Select;
                    _Obj_smhr_Masters.MASTER_CODE = ds.Tables[0].Rows[i]["Nationality*"].ToString().Trim();
                    DataTable dt_nationality = BLL.get_Applicant_Validate(_Obj_smhr_Masters);

                    _obj_smhr_applicant.APPLICANT_NATIONALITY_ID = Convert.ToInt32(dt_nationality.Rows[0]["HR_MASTER_ID"]);
                    _obj_smhr_applicant.APPLICANT_STATUS = Convert.ToString(ds.Tables[0].Rows[i]["Status*"]).Trim();
                    _obj_smhr_applicant.APPLICANT_MARITALSTATUS = Convert.ToString(ds.Tables[0].Rows[i]["Marital Status"]).Trim();
                    _obj_smhr_applicant.APPLICANT_ADDRESS = Convert.ToString(ds.Tables[0].Rows[i]["Address"]);
                    _obj_smhr_applicant.APPLICANT_REMARKS = Convert.ToString(ds.Tables[0].Rows[i]["Remarks"]);
                    _obj_smhr_applicant.APPLICANT_TYPE = string.Empty;
                    _obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_applicant.APPLICANT_CREATEDBY = Convert.ToString(Session["USER_ID"]);
                    _obj_smhr_applicant.APPLICANT_CREATEDDATE = DateTime.Now;
                    status = BLL.set_Applicant(_obj_smhr_applicant);
                    if (status == true)
                    {
                        LoadData();
                        RG_Applicant.DataBind();

                        BLL.ShowMessage(this, "Successfully processed Excel file.");

                    }

                }
            }






        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmapplicant", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }



    }



    //*******************************


    private void getCode()
    {
        try
        {
            string code = string.Empty;
            string str = string.Empty;
            string Series = string.Empty;
            _obj_smhr_applicant = new SMHR_APPLICANT();
            _obj_smhr_applicant.OPERATION = operation.Validate;
            _obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_Applicant(_obj_smhr_applicant);
            if (dt_Details.Rows.Count != 0)
            {
                str = dt_Details.Rows[0][0].ToString().Trim();
                if (str.Length == 1)
                {
                    Series = "000";
                }
                else if (str.Length == 2)
                {
                    Series = "00";
                }
                else if (str.Length == 3)
                {
                    Series = "00";
                }
                else if (str.Length == 4)
                {
                    Series = "0";
                }

                SMHR_GLOBALCONFIG _obj_smhr_globalconfig = new SMHR_GLOBALCONFIG();
                _obj_smhr_globalconfig.OPERATION = operation.Select;
                _obj_smhr_globalconfig.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt = BLL.get_ConfigDetails(_obj_smhr_globalconfig);
                aplicantcode = dt.Rows[0][8].ToString().Trim() + Convert.ToString(Series) + Convert.ToString(str);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmapplicant", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //******************************

    public static bool CheckStringValue(string str)
    {
        //
        // Convert true if number  or false if not
        //
        int Num;
        try
        {
            if (int.TryParse(str, out Num) == true)
            {
                if (Num > 2359)
                {
                    return false;
                }
                if (str.Length != 4)
                {
                    return false;

                }
                if (str.Length == 4)
                {
                    string minute = str.Substring(2, 2);
                    int minuteInt = int.Parse(minute);
                    if (minuteInt >= 60)
                    {
                        return false;
                    }
                }

            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(HttpContext.Current.Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmapplicant", ex.StackTrace, DateTime.Now);
            HttpContext.Current.Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return true;
    }
    //*********************************

    public static bool CheckDateFormat(string strin)
    {
        try
        {
            if (strin.Length > 10)
            {
                return false;
            }
            char[] c = null;
            string strFinal = string.Empty;
            Array ar = strin.Split(new char[] { '/', '-' });
            string yeararray = Convert.ToString(ar.GetValue(2));
            if (yeararray.Length > 4)
            {
                return false;
            }
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar.GetValue(i).ToString().Length == 1)
                {
                    strFinal = strFinal + "0" + ar.GetValue(i) + "/";
                }
                else if (ar.GetValue(i).ToString().Length == 2)
                {
                    strFinal = strFinal + ar.GetValue(i) + "/";
                }
                else
                {
                    if (strFinal.Length == 6)
                        strFinal = strFinal + ar.GetValue(i).ToString();
                    else
                        strFinal = strFinal + "/" + ar.GetValue(i).ToString();
                }
            }
            c = strFinal.ToCharArray();
            if ((c[2] != '/') || c[5] != '/')
            {
                return false;
            }

            if (Convert.ToInt32(strFinal.Substring(0, 2).Trim()) > 31)
            {
                return false;
            }
            if (Convert.ToInt32(strFinal.Substring(3, 2).Trim()) > 12)
            {
                return false;
            }

            if (Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 2)
            {
                if (Convert.ToInt32(strFinal.Substring(6, 4).Trim()) / 4 == 0)
                { // check leap year

                    if (Convert.ToInt32(strFinal.Substring(0, 2).Trim()) > 29)
                    {
                        return false;
                    }

                }
                else
                {
                    if (Convert.ToInt32(strFinal.Substring(0, 2).Trim()) > 28)
                    {
                        return false;
                    }
                }

            }
            if (Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 1 || Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 3 || Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 5 || Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 7 || Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 8 || Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 10 || Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 12)
            {
                if (Convert.ToInt32(strFinal.Substring(0, 2).Trim()) > 31)
                {
                    return false;
                }
            }
            if (Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 4 || Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 6 || Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 9 || Convert.ToInt32(strFinal.Substring(3, 2).Trim()) == 11)
            {
                if (Convert.ToInt32(strFinal.Substring(0, 2).Trim()) > 30)
                {
                    return false;
                }
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(HttpContext.Current.Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmapplicant", ex.StackTrace, DateTime.Now);
            HttpContext.Current.Response.Redirect("~/Frm_ErrorPage.aspx");
        }

            return true;
        
    }
    //*************************

    protected void Delete_Excel_File()
    {
        try
        {
        ds.Dispose();
        if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == true)
        {
            // FileUpload_Task.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Corporate_Contract_Docs/") + Convert.ToString(rcmb_taskPorjectname.SelectedItem.Text.Replace("/", "_")), filename));

            string strpath = Server.MapPath("~/IMPORT_EXCEL/");


            DirectoryInfo dirinfo = new DirectoryInfo(strpath);
            strpath = strpath + strfilename2;
            FileInfo fi = new FileInfo(strpath);
            {
                fi.Delete();
            }
        }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmapplicant", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    //*******************************


    protected void btn_imp_qualification_Click(object sender, EventArgs e)
    {
        try
        {

            //written by ravindra dated 31-01-2010

            //to import the Qualification details
            string strcon = null;

            string strfilename1 = FileUp_Qual.FileName;
            strfilename2 = Convert.ToString(DateTime.Now.TimeOfDay) + "_" + strfilename1;
            strfilename2 = strfilename2.Replace("/", "").Replace(":", ".");
            if (FileUp_Qual.HasFile)
            {

                if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == false)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath("~/IMPORT_EXCEL/"));

                }



                FileUp_Qual.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/IMPORT_EXCEL/"), strfilename2));
                string filename1 = Server.MapPath("~/IMPORT_EXCEL/") + ("") + (Convert.ToString(strfilename2));
                FileInfo fileInfo = new FileInfo(filename1);
                if (fileInfo.Exists)
                {
                    string path = MapPath(strfilename1);
                    // string name = Path.GetFileName( path );
                    string ext = Path.GetExtension(path);

                    string type = string.Empty;
                    //  set known types based on file extension  
                    if (ext != null)
                    {
                        switch (ext.ToLower())
                        {

                            case ".xls":

                                type = "excel";
                                break;
                            case ".xlsx":
                                type = "excel";
                                break;

                            default:
                                type = string.Empty;
                                break;
                        }
                    }
                    if (type == string.Empty)
                    {
                        if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == true)
                        {

                            string path1 = Server.MapPath("~/IMPORT_EXCEL/") + ("") + (Convert.ToString(strfilename2));
                            System.IO.File.Delete(path1);
                        }
                        BLL.ShowMessage(this, "Please select the Excel File  (Eg: Excel.xlsx). ");
                        return;
                    }
                }
            }


            else
            {
                BLL.ShowMessage(this, "Please Select the File to be uploaded");
                return;
            }

            string strpath = Server.MapPath("~/IMPORT_EXCEL/");

            strpath = strpath + strfilename2;


            // Getting data from excell file to dataset.
            strcon = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source='" + strpath + "';" + "Extended Properties=Excel 12.0;";


            OleDbConnection objConn = null;
            objConn = new OleDbConnection(strcon);
            objConn.Open();

            DataTable dt_chk2 = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string sheetname;
            if (dt_chk2 == null)
            {
                objConn.Close();
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            else
            {
                sheetname = Convert.ToString(dt_chk2.Rows[0]["TABLE_NAME"]);
            }
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM  [" + sheetname + "]", strcon);



            da.Fill(ds);

            objConn.Close();
            DataTable dt = new DataTable();
            DataTable dtfail = new DataTable();





            Int32 rowno = 0;

            DateTime dat;
            string columnno = null;

            Boolean filestatus = true;
            dtfail.Columns.Add("S.NO", typeof(Int32));
            dtfail.Columns.Add("ROWNO", typeof(Int32));
            dtfail.Columns.Add("COLUMNS NAMES", typeof(string));
            if (ds.Tables[0].Columns[0].ToString().Trim() == "Applicant Code*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[1].ToString().Trim() == "Category*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[2].ToString().Trim() == "Institute*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[3].ToString().Trim() == "Year of pass*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[4].ToString().Trim() == "Percentage*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[5].ToString().Trim() == "Grade*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }

            if (ds.Tables[0].Rows.Count == 0)
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Successfully processed Excel file. No Records are Imported.");
                return;
            }
            int app_id = 0;

            //to check the data in excel
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                columnno = string.Empty;
                if (ds.Tables[0].Rows[i]["Applicant Code*"].ToString().Trim() != "")
                {

                    SMHR_APPLICANT _obj_smhr_applicant = new SMHR_APPLICANT();
                    _obj_smhr_applicant.OPERATION = operation.Check;
                    _obj_smhr_applicant.APPLICANT_CODE = Convert.ToString(ds.Tables[0].Rows[i]["Applicant Code*"].ToString().Trim());
                    _obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dt_appcode = BLL.get_Applicant(_obj_smhr_applicant);
                    if (dt_appcode.Rows.Count > 0)//validate applicant id exist or not
                    {
                        app_id = Convert.ToInt32(dt_appcode.Rows[0]["APPLICANT_ID"]);
                    }
                    else
                    {
                        filestatus = false;
                        rowno = i + 2;
                        columnno = "Applicant Code*";

                    }

                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = "Applicant Code*";

                }
                if (ds.Tables[0].Rows[i]["Category*"].ToString().Trim() != "")
                {
                    SMHR_MASTERS _Obj_smhr_Masters = new SMHR_MASTERS();
                    _Obj_smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _Obj_smhr_Masters.OPERATION = operation.Select;
                    _Obj_smhr_Masters.MASTER_TYPE = "QUALIFICATION";
                    _Obj_smhr_Masters.MASTER_CODE = ds.Tables[0].Rows[i]["Category*"].ToString().Trim();
                    DataTable dt_nat = BLL.get_Applicant_Validate(_Obj_smhr_Masters);
                    if (Convert.ToInt32(dt_nat.Rows.Count) > 0)
                    {
                        if (app_id != 0)
                        {
                            SMHR_APPLICANT _obj_smhr_applicant = new SMHR_APPLICANT();
                            _obj_smhr_applicant.APPQFN_APPLICANT_ID = app_id;
                            _obj_smhr_applicant.OPERATION = operation.Check_New;
                            _obj_smhr_applicant.APPQFN_QUALIFICATION_ID = Convert.ToInt32(dt_nat.Rows[0]["HR_MASTER_ID"]);
                            _obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dt_appqual = BLL.get_ApplicantQualification(_obj_smhr_applicant);
                            if (dt_appqual.Rows.Count > 0)
                            {
                                filestatus = false;//already exist in DB
                                rowno = i + 2;
                                columnno = columnno + "," + "Category*";
                            }
                            else
                            {
                                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                                {
                                    if (i != j)
                                    {
                                        if (ds.Tables[0].Rows[j]["Applicant Code*"].ToString().Trim() == ds.Tables[0].Rows[i]["Applicant Code*"].ToString().Trim() && ds.Tables[0].Rows[j]["Category*"].ToString().Trim() == ds.Tables[0].Rows[i]["Category*"].ToString().Trim())
                                        {
                                            filestatus = false;//already exist in excel
                                            rowno = i + 2;
                                            columnno = columnno + "," + "Category*";
                                            break;
                                        }
                                    }
                                }


                            }


                        }

                    }
                    else
                    {
                        filestatus = false;
                        rowno = i + 2;
                        columnno = columnno + "," + "Category*";


                    }

                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Category*";

                }

                if (ds.Tables[0].Rows[i]["Institute*"].ToString().Trim() != "")
                {

                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Institute*";

                }
                if (ds.Tables[0].Rows[i]["Year of pass*"].ToString().Trim() != "")
                {
                    int b;
                    int.TryParse(Convert.ToString(ds.Tables[0].Rows[i]["Year of pass*"]), out  b);
                    if (b != int.MinValue) //year of integer length 4 only
                    {
                        int count = Convert.ToString(ds.Tables[0].Rows[i]["Year of pass*"]).Length;
                        if (count > 4)
                        {
                            filestatus = false;
                            rowno = i + 2;
                            columnno = "Year of pass*";
                        }
                    }
                    else
                    {
                        filestatus = false;
                        rowno = i + 2;
                        columnno = "Year of pass*";

                    }
                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Year of pass*";

                }

                if (ds.Tables[0].Rows[i]["Percentage*"].ToString().Trim() != "")
                {
                    //string date = Convert.ToString(ds.Tables[0].Rows[i]["Date of Birth*"]);
                    //string st = date.Substring(0, 10);

                    int b;
                    int.TryParse(Convert.ToString(ds.Tables[0].Rows[i]["Percentage*"]), out  b);
                    if (b != int.MinValue) //year of integer length 4 only
                    {

                    }
                    else
                    {
                        filestatus = false;
                        rowno = i + 2;
                        columnno = "Percentage*";

                    }
                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Percentage*";
                }







                if (ds.Tables[0].Rows[i]["Grade*"].ToString().Trim() != "")
                {

                    if (ds.Tables[0].Rows[i]["Grade*"].ToString().Trim().ToUpper() == "A" || ds.Tables[0].Rows[i]["Grade*"].ToString().Trim().ToUpper() == "B" || ds.Tables[0].Rows[i]["Grade*"].ToString().Trim().ToUpper() == "C" || ds.Tables[0].Rows[i]["Grade*"].ToString().Trim().ToUpper() == "D")
                    {
                    }
                    else
                    {
                        filestatus = false;
                        rowno = i + 2;
                        columnno = columnno + "," + "Grade*";


                    }

                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Grade*";


                }

                if (filestatus == false)
                {
                    DataRow newrow = dtfail.NewRow();
                    newrow["S.NO"] = dtfail.Rows.Count + 1;


                    newrow["ROWNO"] = rowno;
                    newrow["COLUMNS NAMES"] = columnno;
                    dtfail.Rows.Add(newrow);
                }


            }

            if (dtfail.Rows.Count > 0)
            {
                Session["dt_fail"] = dtfail;
                Session["ds_data"] = ds;
                Delete_Excel_File();
                //LinkButton lnk_Import_process = (LinkButton)RadPanelBar1.FindItemByValue("AddAttachment").FindControl("lnk_Import_process");
                Telerik.Web.UI.RadWindow newwindow = new Telerik.Web.UI.RadWindow();
                // RWM_POSTREPLY.Windows.Remove(newwindow);
                newwindow.ID = "RadWindow_import";

                newwindow.NavigateUrl = "~/Payroll/frm_AttendanceImportProcess.aspx";
                newwindow.Title = "Import Process";
                newwindow.Width = 1150;
                newwindow.Height = 580;
                newwindow.VisibleOnPageLoad = true;
                if (RWM_POSTREPLY1.Windows.Count > 0)
                {
                    RWM_POSTREPLY1.Windows.RemoveAt(0);
                }
                RWM_POSTREPLY1.Windows.Add(newwindow);



                RWM_POSTREPLY1.Visible = true;
                return;

            }
            else
            {

                //write insert method for qualification
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    bool status = false;
                    SMHR_APPLICANT _obj_smhr_applicant = new SMHR_APPLICANT();
                    _obj_smhr_applicant.OPERATION = operation.Check;
                    _obj_smhr_applicant.APPLICANT_CODE = Convert.ToString(ds.Tables[0].Rows[i]["Applicant Code*"].ToString().Trim());
                    _obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dt_appcode = BLL.get_Applicant(_obj_smhr_applicant);
                    if (dt_appcode.Rows.Count > 0)//validate applicant id exist or not
                    {
                        app_id = Convert.ToInt32(dt_appcode.Rows[0]["APPLICANT_ID"]);
                    }
                    _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(app_id);

                    SMHR_MASTERS _Obj_smhr_Masters = new SMHR_MASTERS();
                    _Obj_smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _Obj_smhr_Masters.OPERATION = operation.Select;
                    _Obj_smhr_Masters.MASTER_TYPE = "QUALIFICATION";
                    _Obj_smhr_Masters.MASTER_CODE = ds.Tables[0].Rows[i]["Category*"].ToString().Trim();
                    DataTable dt_nat = BLL.get_Applicant_Validate(_Obj_smhr_Masters);
                    _obj_smhr_applicant.APPQFN_QUALIFICATION_ID = Convert.ToInt32(Convert.ToString(dt_nat.Rows[0]["HR_MASTER_ID"]));
                    _obj_smhr_applicant.APPQFN_INSTITUTE = Convert.ToString(ds.Tables[0].Rows[i]["Institute*"].ToString().Trim());
                    _obj_smhr_applicant.APPQFN_PASSEDYEAR = Convert.ToInt32(Convert.ToString(ds.Tables[0].Rows[i]["Year of pass*"].ToString().Trim()));
                    _obj_smhr_applicant.APPQFN_PERCENTAGE = Convert.ToInt32(Convert.ToString(ds.Tables[0].Rows[i]["Percentage*"].ToString().Trim()));
                    _obj_smhr_applicant.APPQFN_GRADE = Convert.ToString(ds.Tables[0].Rows[i]["Grade*"].ToString().Trim());
                    _obj_smhr_applicant.APPQFN_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_applicant.APPQFN_CREATEDDATE = DateTime.Now;
                    _obj_smhr_applicant.OPERATION = operation.Insert;
                    status = BLL.set_AppQualification(_obj_smhr_applicant);

                }
                Delete_Excel_File();
                BLL.ShowMessage(this, "Successfully processed Excel file.");
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmapplicant", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    //********************



    protected void btn_Imp_exp_Click(object sender, EventArgs e)
    {

        try
        {

            //written by ravindra dated 31-01-2010

            //to import the Qualification details
            string strcon = null;

            string strfilename1 = FileUp_Exp.FileName;
            strfilename2 = Convert.ToString(DateTime.Now.TimeOfDay) + "_" + strfilename1;
            strfilename2 = strfilename2.Replace("/", "").Replace(":", ".");
            if (FileUp_Exp.HasFile)
            {

                if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == false)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath("~/IMPORT_EXCEL/"));

                }



                FileUp_Exp.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/IMPORT_EXCEL/"), strfilename2));
                string filename1 = Server.MapPath("~/IMPORT_EXCEL/") + ("") + (Convert.ToString(strfilename2));
                FileInfo fileInfo = new FileInfo(filename1);
                if (fileInfo.Exists)
                {
                    string path = MapPath(strfilename1);
                    // string name = Path.GetFileName( path );
                    string ext = Path.GetExtension(path);

                    string type = string.Empty;
                    //  set known types based on file extension  
                    if (ext != null)
                    {
                        switch (ext.ToLower())
                        {

                            case ".xls":

                                type = "excel";
                                break;
                            case ".xlsx":
                                type = "excel";
                                break;

                            default:
                                type = string.Empty;
                                break;
                        }
                    }
                    if (type == string.Empty)
                    {
                        if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == true)
                        {

                            string path1 = Server.MapPath("~/IMPORT_EXCEL/") + ("") + (Convert.ToString(strfilename2));
                            System.IO.File.Delete(path1);
                        }
                        BLL.ShowMessage(this, "Please select the Excel File  (Eg: Excel.xlsx). ");
                        return;
                    }
                }
            }


            else
            {
                BLL.ShowMessage(this, "Please Select the File to be uploaded");
                return;
            }

            string strpath = Server.MapPath("~/IMPORT_EXCEL/");

            strpath = strpath + strfilename2;


            // Getting data from excell file to dataset.
            strcon = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source='" + strpath + "';" + "Extended Properties=Excel 12.0;";


            OleDbConnection objConn = null;
            objConn = new OleDbConnection(strcon);
            objConn.Open();

            DataTable dt_chk2 = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string sheetname;
            if (dt_chk2 == null)
            {
                objConn.Close();
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            else
            {
                sheetname = Convert.ToString(dt_chk2.Rows[0]["TABLE_NAME"]);
            }
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM  [" + sheetname + "]", strcon);



            da.Fill(ds);

            objConn.Close();
            DataTable dt = new DataTable();
            DataTable dtfail = new DataTable();





            Int32 rowno = 0;

            DateTime dat;
            string columnno = null;

            Boolean filestatus = true;
            dtfail.Columns.Add("S.NO", typeof(Int32));
            dtfail.Columns.Add("ROWNO", typeof(Int32));
            dtfail.Columns.Add("COLUMNS NAMES", typeof(string));
            if (ds.Tables[0].Columns[0].ToString().Trim() == "Applicant Code*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[1].ToString().Trim() == "Company Name*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[2].ToString().Trim() == "Joining Date*(DD/MM/YYYY)")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[3].ToString().Trim() == "Join Salary*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[4].ToString().Trim() == "Join Position*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[5].ToString().Trim() == "Reason For Relieving*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[6].ToString().Trim() == "Relieving Date*(DD/MM/YYYY)")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[7].ToString().Trim() == "Relieving Salary*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[8].ToString().Trim() == "Relieving Position*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }

            if (ds.Tables[0].Rows.Count == 0)
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Successfully processed Excel file. No Records are Imported.");
                return;
            }
            int app_id = 0;

            //to check the data in excel
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string JOINDAT = string.Empty;
                string RELDAT = string.Empty;
                DateTime jdate;
                DateTime rdate;




                columnno = string.Empty;
                if (ds.Tables[0].Rows[i]["Applicant Code*"].ToString().Trim() != "")
                {

                    SMHR_APPLICANT _obj_smhr_applicant = new SMHR_APPLICANT();
                    _obj_smhr_applicant.OPERATION = operation.Check;
                    _obj_smhr_applicant.APPLICANT_CODE = Convert.ToString(ds.Tables[0].Rows[i]["Applicant Code*"].ToString().Trim());
                    _obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dt_appcode = BLL.get_Applicant(_obj_smhr_applicant);
                    if (dt_appcode.Rows.Count > 0)//validate applicant id exist or not
                    {
                        app_id = Convert.ToInt32(dt_appcode.Rows[0]["APPLICANT_ID"]);
                    }
                    else
                    {
                        filestatus = false;
                        rowno = i + 2;
                        columnno = "Applicant Code*";

                    }

                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = "Applicant Code*";

                }
                if (ds.Tables[0].Rows[i]["Company Name*"].ToString().Trim() != "")
                {

                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Company Name*";

                }

                if (ds.Tables[0].Rows[i]["Joining Date*(DD/MM/YYYY)"].ToString().Trim() != "")
                {
                    //DateTime b;


                    string JD = "";

                    JD = ds.Tables[0].Rows[i]["Joining Date*(DD/MM/YYYY)"].ToString();

                    bool WJD = JD.Contains(".");

                    if (WJD)
                        JD = JD.Replace(".", "/");
                    bool Chkdate = CheckDateFormat(JD);
                    if (Chkdate == false)
                    {
                        // errormsg = errormsg + "," + "Enter Correct Date of Birth";
                        filestatus = false;
                        rowno = i + 2;
                        columnno = columnno + "," + "Joining Date*(DD/MM/YYYY)";

                    }


                    JOINDAT = JD;


                    //jdate = new DateTime();
                    // jdate = DateTime.ParseExact(JOINDAT, "dd/MM/yyyy", null);






                    //DateTime.TryParse(Convert.ToString(jdate), out  b);
                    //if (b != DateTime.MinValue)
                    //{
                    //}
                    //else
                    // {
                    //   filestatus = false;
                    //   rowno = i + 2;
                    //  columnno = columnno + "," + "Joining Date*(DD/MM/YYYY)";
                    //}


                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Joining Date*(DD/MM/YYYY)";

                }
                if (ds.Tables[0].Rows[i]["Join Salary*"].ToString().Trim() != "")
                {
                    int b;
                    int.TryParse(Convert.ToString(ds.Tables[0].Rows[i]["Join Salary*"]), out  b);
                    if (b != 0)
                    {

                    }
                    else
                    {
                        filestatus = false;
                        rowno = i + 2;
                        columnno = columnno + "," + "Join Salary*";

                    }
                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Join Salary*";

                }

                if (ds.Tables[0].Rows[i]["Relieving Salary*"].ToString().Trim() != "")
                {
                    //string date = Convert.ToString(ds.Tables[0].Rows[i]["Date of Birth*"]);
                    //string st = date.Substring(0, 10);

                    //int b;
                    //int.TryParse(Convert.ToString(ds.Tables[0].Rows[i]["Relieving Salary*"]), out  b);
                    //if (b != 0) //year of integer length 4 only
                    //{

                    //}
                    //else
                    //{
                    //    filestatus = false;
                    //    rowno = i + 2;
                    //    columnno = columnno + "," + "Relieving Salary*";

                    //}

                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Relieving Salary*";
                }







                if (ds.Tables[0].Rows[i]["Join Position*"].ToString().Trim() != "")
                {


                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Join Position*";


                }
                if (ds.Tables[0].Rows[i]["Reason For Relieving*"].ToString().Trim() != "")
                {


                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Reason For Relieving*";


                }
                if (ds.Tables[0].Rows[i]["Relieving Date*(DD/MM/YYYY)"].ToString().Trim() != "")
                {
                    DateTime b;

                    string reldate = "";

                    reldate = ds.Tables[0].Rows[i]["Relieving Date*(DD/MM/YYYY)"].ToString();

                    bool wrongsdformat1 = reldate.Contains(".");

                    if (wrongsdformat1)
                        reldate = reldate.Replace(".", "/");

                    bool Chkdate = CheckDateFormat(reldate);
                    if (Chkdate == false)
                    {
                        // errormsg = errormsg + "," + "Enter Correct Date of Birth";
                        filestatus = false;
                        rowno = i + 2;
                        columnno = columnno + "," + "Relieving Date*(DD/MM/YYYY)";

                    }
                    RELDAT = reldate;
                    //rdate = new DateTime();
                    //rdate = DateTime.ParseExact(RELDAT,"dd/MM/yyyy", null);
                    //DateTime.TryParse(Convert.ToString(rdate), out  b);
                    //if (b != DateTime.MinValue)
                    //{
                    //}
                    //else
                    //{
                    //    filestatus = false;
                    //    rowno = i + 2;
                    //    columnno = columnno + "," + "Relieving Date*(DD/MM/YYYY)";
                    //}

                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Relieving Date*(DD/MM/YYYY)";


                }//
                if (ds.Tables[0].Rows[i]["Relieving Position*"].ToString().Trim() != "")
                {


                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Relieving Position*";


                }

                if (filestatus == false)
                {
                    DataRow newrow = dtfail.NewRow();
                    newrow["S.NO"] = dtfail.Rows.Count + 1;


                    newrow["ROWNO"] = rowno;
                    newrow["COLUMNS NAMES"] = columnno;
                    dtfail.Rows.Add(newrow);
                }


            }

            if (dtfail.Rows.Count > 0)
            {
                Session["dt_fail"] = dtfail;
                Session["ds_data"] = ds;
                Delete_Excel_File();
                //LinkButton lnk_Import_process = (LinkButton)RadPanelBar1.FindItemByValue("AddAttachment").FindControl("lnk_Import_process");
                Telerik.Web.UI.RadWindow newwindow = new Telerik.Web.UI.RadWindow();
                // RWM_POSTREPLY.Windows.Remove(newwindow);
                newwindow.ID = "RadWindow_import";

                newwindow.NavigateUrl = "~/Payroll/frm_AttendanceImportProcess.aspx";
                newwindow.Title = "Import Process";
                newwindow.Width = 1150;
                newwindow.Height = 580;
                newwindow.VisibleOnPageLoad = true;
                if (RWM_POSTREPLY1.Windows.Count > 0)
                {
                    RWM_POSTREPLY1.Windows.RemoveAt(0);
                }
                RWM_POSTREPLY1.Windows.Add(newwindow);



                RWM_POSTREPLY1.Visible = true;
                return;

            }
            else
            {

                //  //write insert method for Experience
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {


                    bool status = false;
                    SMHR_APPLICANT _obj_smhr_applicant = new SMHR_APPLICANT();
                    _obj_smhr_applicant.OPERATION = operation.Check;
                    _obj_smhr_applicant.APPLICANT_CODE = Convert.ToString(ds.Tables[0].Rows[i]["Applicant Code*"].ToString().Trim());
                    _obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dt_appcode = BLL.get_Applicant(_obj_smhr_applicant);
                    if (dt_appcode.Rows.Count > 0)//validate applicant id exist or not
                    {
                        app_id = Convert.ToInt32(dt_appcode.Rows[0]["APPLICANT_ID"]);
                    }
                    _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(app_id);
                    _obj_smhr_applicant.APPEXP_APPLICANT_ID = Convert.ToInt32(app_id);
                    _obj_smhr_applicant.OPERATION = operation.Check_New;
                    DataTable dt_serial = BLL.get_ApplicantExperience(_obj_smhr_applicant);
                    _obj_smhr_applicant.APPEXP_SERIAL = Convert.ToInt32(dt_serial.Rows[0]["APPEXP_SERIAL"]) + 1;//get the number
                    _obj_smhr_applicant.APPEXP_COMPANY = Convert.ToString(ds.Tables[0].Rows[i]["Company Name*"].ToString().Trim()).Replace("'", "''");
                    // _obj_smhr_applicant.APPEXP_JOINDATE = Convert.ToDateTime(ds.Tables[0].Rows[i]["Joining Date*"]);
                    if (Convert.ToString(ds.Tables[0].Rows[i]["Joining Date*(DD/MM/YYYY)"]).Contains("."))
                    {
                        _obj_smhr_applicant.APPEXJOINDATE = Convert.ToString(ds.Tables[0].Rows[i]["Joining Date*(DD/MM/YYYY)"]).Replace(".", "/");

                    }
                    else
                    {
                        _obj_smhr_applicant.APPEXJOINDATE = Convert.ToString(ds.Tables[0].Rows[i]["Joining Date*(DD/MM/YYYY)"]);

                    }

                    // _obj_smhr_applicant.APPEXJOINDATE = Convert.ToString(ds.Tables[0].Rows[i]["Joining Date*"]);
                    _obj_smhr_applicant.APPEXP_JOINSAL = Convert.ToDouble(ds.Tables[0].Rows[i]["Join Salary*"]);
                    _obj_smhr_applicant.APPEXP_JOINDESC = Convert.ToString(ds.Tables[0].Rows[i]["Join Position*"].ToString().Trim()).Replace("'", "''");
                    _obj_smhr_applicant.APPEXP_REASONREL = Convert.ToString(ds.Tables[0].Rows[i]["Reason For Relieving*"].ToString().Trim()).Replace("'", "''");
                    //_obj_smhr_applicant.APPEXP_RELDATE = Convert.ToDateTime(ds.Tables[0].Rows[i]["Relieving Date*"]);
                    if (Convert.ToString(ds.Tables[0].Rows[i]["Relieving Date*(DD/MM/YYYY)"]).Contains("."))
                    {
                        _obj_smhr_applicant.APPEXRELDATE = Convert.ToString(ds.Tables[0].Rows[i]["Relieving Date*(DD/MM/YYYY)"]).Replace(".", "/");

                    }
                    else
                    {
                        _obj_smhr_applicant.APPEXRELDATE = Convert.ToString(ds.Tables[0].Rows[i]["Relieving Date*(DD/MM/YYYY)"]);

                    }
                    // _obj_smhr_applicant.APPEXRELDATE = Convert.ToString(ds.Tables[0].Rows[i]["Relieving Date*"]);
                    _obj_smhr_applicant.APPEXP_RELSAL = Convert.ToDouble(ds.Tables[0].Rows[i]["Relieving Salary*"]);
                    _obj_smhr_applicant.APPEXP_REASONDESC = Convert.ToString(ds.Tables[0].Rows[i]["Relieving Position*"].ToString().Trim()).Replace("'", "''");
                    _obj_smhr_applicant.APPEXP_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_applicant.APPEXP_CREATEDDATE = DateTime.Now;
                    _obj_smhr_applicant.OPERATION = operation.Insert1;
                    status = BLL.set_ApplicantExperience(_obj_smhr_applicant);


                }
            }
            Delete_Excel_File();
            BLL.ShowMessage(this, "Successfully processed Excel file.");
        }



        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmapplicant", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    //******************************
    protected void btn_language_Click(object sender, EventArgs e)
    {
        try
        {
            //written by rajasekhar dated 31-01-2010

            //to import the Lanquage details

            string strcon = null;

            string strfilename1 = FileUpload6.FileName;
            strfilename2 = Convert.ToString(DateTime.Now.TimeOfDay) + "_" + strfilename1;
            strfilename2 = strfilename2.Replace("/", "").Replace(":", ".");
            if (FileUpload6.HasFile)
            {

                if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == false)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath("~/IMPORT_EXCEL/"));

                }



                FileUpload6.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/IMPORT_EXCEL/"), strfilename2));
                string filename1 = Server.MapPath("~/IMPORT_EXCEL/") + ("") + (Convert.ToString(strfilename2));
                FileInfo fileInfo = new FileInfo(filename1);
                if (fileInfo.Exists)
                {
                    string path = MapPath(strfilename1);
                    // string name = Path.GetFileName( path );
                    string ext = Path.GetExtension(path);

                    string type = string.Empty;
                    //  set known types based on file extension  
                    if (ext != null)
                    {
                        switch (ext.ToLower())
                        {

                            case ".xls":

                                type = "excel";
                                break;
                            case ".xlsx":
                                type = "excel";
                                break;

                            default:
                                type = string.Empty;
                                break;
                        }
                    }
                    if (type == string.Empty)
                    {
                        if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == true)
                        {

                            string path1 = Server.MapPath("~/IMPORT_EXCEL/") + ("") + (Convert.ToString(strfilename2));
                            System.IO.File.Delete(path1);
                        }
                        BLL.ShowMessage(this, "Please select the Excel File  (Eg: Excel.xlsx). ");
                        return;
                    }
                }
            }


            else
            {
                BLL.ShowMessage(this, "Please Select the File to be uploaded");
                return;
            }

            string strpath = Server.MapPath("~/IMPORT_EXCEL/");

            strpath = strpath + strfilename2;


            // Getting data from excell file to dataset.
            strcon = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source='" + strpath + "';" + "Extended Properties=Excel 12.0;";


            OleDbConnection objConn = null;
            objConn = new OleDbConnection(strcon);
            objConn.Open();

            DataTable dt_chk2 = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string sheetname;
            if (dt_chk2 == null)
            {
                objConn.Close();
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            else
            {
                sheetname = Convert.ToString(dt_chk2.Rows[0]["TABLE_NAME"]);
            }
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM  [" + sheetname + "]", strcon);



            da.Fill(ds);

            objConn.Close();
            DataTable dt = new DataTable();
            DataTable dtfail = new DataTable();




            string projecttype = null;
            Int32 rowno = 0;


            string columnno = null;

            Boolean filestatus = true;
            dtfail.Columns.Add("S.NO", typeof(Int32));
            dtfail.Columns.Add("ROWNO", typeof(Int32));
            dtfail.Columns.Add("COLUMNS NAMES", typeof(string));

            if (ds.Tables[0].Columns[0].ToString().Trim() == "APPlicant Code*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[1].ToString().Trim() == "Language*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }

            if (ds.Tables[0].Columns[2].ToString().Trim() == "Read")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[3].ToString().Trim() == "Write")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[4].ToString().Trim() == "Speak")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[5].ToString().Trim() == "Understand")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Rows.Count == 0)
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Successfully processed Excel file. No Records are Imported.");
                return;
            }

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["APPlicant Code*"].ToString().Trim() != "")
                {

                    string aplicantcode = ds.Tables[0].Rows[i]["APPlicant Code*"].ToString();
                    SMHR_APPLICANT _obj_smhr_applicant = new SMHR_APPLICANT();
                    _obj_smhr_applicant.APPLICANT_CODE = aplicantcode;
                    _obj_smhr_applicant.OPERATION = operation.Check;
                    _obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dt_app_id = BLL.get_Applicant(_obj_smhr_applicant);

                    if (dt_app_id.Rows.Count > 0)//APPLICANT_ID
                    {
                        app_id = Convert.ToInt32(dt_app_id.Rows[0]["APPLICANT_ID"]);
                    }
                    else
                    {
                        filestatus = false;
                        rowno = i + 2;
                        columnno = "APPlicant Code*";
                    }




                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = "APPlicant Code*";
                }


                if (ds.Tables[0].Rows[i]["Language*"].ToString().Trim() != "")
                {
                    SMHR_MASTERS _Obj_smhr_Masters = new SMHR_MASTERS();
                    _Obj_smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _Obj_smhr_Masters.OPERATION = operation.Select;
                    _Obj_smhr_Masters.MASTER_TYPE = "LANGUAGE";
                    _Obj_smhr_Masters.MASTER_CODE = ds.Tables[0].Rows[i]["Language*"].ToString().Trim();
                    DataTable dt_nat = BLL.get_Applicant_Validate(_Obj_smhr_Masters);
                    if (Convert.ToInt32(dt_nat.Rows.Count) > 0)
                    {

                        if (app_id != 0)
                        {
                            SMHR_APPLICANT _obj_smhr_applicant = new SMHR_APPLICANT();
                            _obj_smhr_applicant.APPLAN_APPLICANT_ID = app_id;
                            _obj_smhr_applicant.OPERATION = operation.Check_New;
                            _obj_smhr_applicant.APPLAN_LANGUAGE_ID = Convert.ToInt32(dt_nat.Rows[0]["HR_MASTER_ID"]);
                            _obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

                            DataTable dt_applan = BLL.get_ApplicantLanguage(_obj_smhr_applicant);


                            if (dt_applan.Rows.Count > 0)
                            {
                                filestatus = false;//already exist in DB
                                rowno = i + 2;
                                columnno = columnno + "," + "Language*";
                            }
                            else
                            {
                                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                                {
                                    if (i != j)
                                    {
                                        if (ds.Tables[0].Rows[j]["APPlicant Code*"].ToString().Trim() == ds.Tables[0].Rows[i]["APPlicant Code*"].ToString().Trim() && ds.Tables[0].Rows[j]["Language*"].ToString().Trim() == ds.Tables[0].Rows[i]["Language*"].ToString().Trim())
                                        {
                                            filestatus = false;//already exist in excel
                                            rowno = i + 2;
                                            columnno = columnno + "," + "Language*";
                                            break;
                                        }
                                    }
                                }


                            }

                        }


                    }
                    else
                    {
                        filestatus = false;
                        rowno = i + 2;
                        columnno = columnno + "," + "Language*";


                    }
                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Language*";


                }

                if (ds.Tables[0].Rows[i]["Read"].ToString().Trim() != "")
                {
                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Read";


                }
                if (ds.Tables[0].Rows[i]["Write"].ToString().Trim() != "")
                {
                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Write";


                }
                if (ds.Tables[0].Rows[i]["Speak"].ToString().Trim() != "")
                {
                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Speak";


                }
                if (ds.Tables[0].Rows[i]["Understand"].ToString().Trim() != "")
                {
                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Understand";


                }
                if (filestatus == false)
                {
                    DataRow newrow = dtfail.NewRow();
                    newrow["S.NO"] = dtfail.Rows.Count + 1;


                    newrow["ROWNO"] = rowno;
                    newrow["COLUMNS NAMES"] = columnno;
                    dtfail.Rows.Add(newrow);
                }
            }



            if (dtfail.Rows.Count > 0)
            {
                Session["dt_fail"] = dtfail;
                Session["ds_data"] = ds;
                Delete_Excel_File();
                //LinkButton lnk_Import_process = (LinkButton)RadPanelBar1.FindItemByValue("AddAttachment").FindControl("lnk_Import_process");
                Telerik.Web.UI.RadWindow newwindow = new Telerik.Web.UI.RadWindow();
                // RWM_POSTREPLY.Windows.Remove(newwindow);
                newwindow.ID = "RadWindow_import";

                newwindow.NavigateUrl = "~/Payroll/frm_AttendanceImportProcess.aspx";
                newwindow.Title = "Import Process";
                newwindow.Width = 1150;
                newwindow.Height = 580;
                newwindow.VisibleOnPageLoad = true;
                if (RWM_POSTREPLY1.Windows.Count > 1)
                {
                    RWM_POSTREPLY1.Windows.RemoveAt(1);
                }
                RWM_POSTREPLY1.Windows.Add(newwindow);



                RWM_POSTREPLY1.Visible = true;
                return;

            }
            else
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    bool status = false;

                    string aplicantcode = ds.Tables[0].Rows[i]["APPlicant Code*"].ToString();
                    SMHR_APPLICANT _obj_smhr_applicant = new SMHR_APPLICANT();
                    _obj_smhr_applicant.APPLICANT_CODE = aplicantcode;
                    _obj_smhr_applicant.OPERATION = operation.Check;
                    _obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dt_app_id = BLL.get_Applicant(_obj_smhr_applicant);

                    if (dt_app_id.Rows.Count > 0)//APPLICANT_ID
                    {
                        app_id = Convert.ToInt32(dt_app_id.Rows[0]["APPLICANT_ID"]);
                    }
                    _obj_smhr_applicant.APPLAN_APPLICANT_ID = app_id;


                    //  _obj_smhr_applicant.APPLAN_LANGUAGE_ID=
                    SMHR_MASTERS _Obj_smhr_Masters = new SMHR_MASTERS();
                    _Obj_smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _Obj_smhr_Masters.OPERATION = operation.Select;
                    _Obj_smhr_Masters.MASTER_TYPE = "LANGUAGE";
                    _Obj_smhr_Masters.MASTER_CODE = ds.Tables[0].Rows[i]["Language*"].ToString().Trim();
                    DataTable dt_nat = BLL.get_Applicant_Validate(_Obj_smhr_Masters);

                    _obj_smhr_applicant.APPLAN_LANGUAGE_ID = Convert.ToInt32(dt_nat.Rows[0]["HR_MASTER_ID"]);

                    _obj_smhr_applicant.APPLAN_READ = Convert.ToBoolean(ds.Tables[0].Rows[i]["Read"]);
                    _obj_smhr_applicant.APPLAN_SPEAK = Convert.ToBoolean(ds.Tables[0].Rows[i]["Speak"]);
                    _obj_smhr_applicant.APPLAN_UNDERSTAND = Convert.ToBoolean(ds.Tables[0].Rows[i]["Understand"]);
                    _obj_smhr_applicant.APPLAN_WRITE = Convert.ToBoolean(ds.Tables[0].Rows[i]["Write"]);
                    _obj_smhr_applicant.APPLAN_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_applicant.APPLAN_CREATEDDATE = DateTime.Now;
                    _obj_smhr_applicant.OPERATION = operation.Insert;

                    status = BLL.set_ApplLanguage(_obj_smhr_applicant);


                    if (status == true)
                    {
                        BLL.ShowMessage(this, " Successfully processed Excel file.");
                    }

                }

            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmapplicant", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //********************************************

    protected void btn_Imp_contacts_Click(object sender, EventArgs e)
    {
        try
        {
            //written by rajasekhar
            //To import the contact details
            string strcon = null;

            string strfilename1 = UploadContact.FileName;
            strfilename2 = Convert.ToString(DateTime.Now.TimeOfDay) + "_" + strfilename1;
            strfilename2 = strfilename2.Replace("/", "").Replace(":", ".");
            if (UploadContact.HasFile)
            {

                if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == false)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath("~/IMPORT_EXCEL/"));

                }



                UploadContact.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/IMPORT_EXCEL/"), strfilename2));
                string filename1 = Server.MapPath("~/IMPORT_EXCEL/") + ("") + (Convert.ToString(strfilename2));
                FileInfo fileInfo = new FileInfo(filename1);
                if (fileInfo.Exists)
                {
                    string path = MapPath(strfilename1);
                    // string name = Path.GetFileName( path );
                    string ext = Path.GetExtension(path);

                    string type = string.Empty;
                    //  set known types based on file extension  
                    if (ext != null)
                    {
                        switch (ext.ToLower())
                        {

                            case ".xls":

                                type = "excel";
                                break;
                            case ".xlsx":
                                type = "excel";
                                break;

                            default:
                                type = string.Empty;
                                break;
                        }
                    }
                    if (type == string.Empty)
                    {
                        if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == true)
                        {

                            string path1 = Server.MapPath("~/IMPORT_EXCEL/") + ("") + (Convert.ToString(strfilename2));
                            System.IO.File.Delete(path1);
                        }
                        BLL.ShowMessage(this, "Please select the Excel File  (Eg: Excel.xlsx). ");
                        return;
                    }
                }
            }


            else
            {
                BLL.ShowMessage(this, "Please Select the File to be uploaded");
                return;
            }

            string strpath = Server.MapPath("~/IMPORT_EXCEL/");

            strpath = strpath + strfilename2;


            // Getting data from excell file to dataset.
            strcon = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source='" + strpath + "';" + "Extended Properties=Excel 12.0;";


            OleDbConnection objConn = null;
            objConn = new OleDbConnection(strcon);
            objConn.Open();

            DataTable dt_chk2 = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string sheetname;
            if (dt_chk2 == null)
            {
                objConn.Close();
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            else
            {
                sheetname = Convert.ToString(dt_chk2.Rows[0]["TABLE_NAME"]);
            }
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM  [" + sheetname + "]", strcon);



            da.Fill(ds);

            objConn.Close();
            DataTable dt = new DataTable();
            DataTable dtfail = new DataTable();




            string projecttype = null;
            Int32 rowno = 0;

            DateTime dat;
            string columnno = null;
            string projname = null;
            Boolean filestatus = true;
            dtfail.Columns.Add("S.NO", typeof(Int32));
            dtfail.Columns.Add("ROWNO", typeof(Int32));
            dtfail.Columns.Add("COLUMNS NAMES", typeof(string));


            if (ds.Tables[0].Columns[0].ToString().Trim() == "Applicant Code*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }


            if (ds.Tables[0].Columns[1].ToString().Trim() == "Company Name*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }

            if (ds.Tables[0].Columns[2].ToString().Trim() == "Contact Person*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }

            if (ds.Tables[0].Columns[3].ToString().Trim() == "Phone Number*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }

            if (ds.Tables[0].Columns[4].ToString().Trim() == "Address*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }

            if (ds.Tables[0].Rows.Count == 0)
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Successfully processed Excel file. No Records are Imported.");
                return;
            }

            //to check the data in excel
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["Applicant Code*"].ToString().Trim() != "")
                {

                    string aplicantcode = ds.Tables[0].Rows[i]["Applicant Code*"].ToString();
                    SMHR_APPLICANT _obj_smhr_applicant = new SMHR_APPLICANT();
                    _obj_smhr_applicant.APPLICANT_CODE = aplicantcode;
                    _obj_smhr_applicant.OPERATION = operation.Check;
                    _obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dt_app_id = BLL.get_Applicant(_obj_smhr_applicant);

                    if (dt_app_id.Rows.Count > 0)//APPLICANT_ID
                    {
                        app_id = Convert.ToInt32(dt_app_id.Rows[0]["APPLICANT_ID"]);
                    }
                    else
                    {
                        filestatus = false;
                        rowno = i + 2;
                        columnno = "Applicant Code*";
                    }

                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = "ApplicantCode*";
                }

                if (ds.Tables[0].Rows[i]["Company Name*"].ToString().Trim() != "")
                {

                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Company Name*";

                }

                if (ds.Tables[0].Rows[i]["Contact Person*"].ToString().Trim() != "")
                {

                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Contact Person*";

                }

                if (ds.Tables[0].Rows[i]["Phone Number*"].ToString().Trim() != "")
                {

                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Phone Number*";

                }
                if (ds.Tables[0].Rows[i]["Address*"].ToString().Trim() != "")
                {

                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Address*";

                }

                if (filestatus == false)
                {
                    DataRow newrow = dtfail.NewRow();
                    newrow["S.NO"] = dtfail.Rows.Count + 1;


                    newrow["ROWNO"] = rowno;
                    newrow["COLUMNS NAMES"] = columnno;
                    dtfail.Rows.Add(newrow);
                }


            }

            if (dtfail.Rows.Count > 0)
            {
                Session["dt_fail"] = dtfail;
                Session["ds_data"] = ds;
                Delete_Excel_File();
                Telerik.Web.UI.RadWindow newwindow = new Telerik.Web.UI.RadWindow();
                // RWM_POSTREPLY.Windows.Remove(newwindow);
                newwindow.ID = "RadWindow_import";

                newwindow.NavigateUrl = "~/Payroll/frm_AttendanceImportProcess.aspx";
                newwindow.Title = "Import Process";
                newwindow.Width = 1150;
                newwindow.Height = 580;
                newwindow.VisibleOnPageLoad = true;
                if (RWM_POSTREPLY1.Windows.Count > 1)
                {
                    RWM_POSTREPLY1.Windows.RemoveAt(1);
                }
                RWM_POSTREPLY1.Windows.Add(newwindow);



                RWM_POSTREPLY1.Visible = true;
                return;

            }
            else
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    bool status = false;

                    string aplicantcode = ds.Tables[0].Rows[i]["Applicant Code*"].ToString();
                    SMHR_APPLICANT _obj_smhr_applicant = new SMHR_APPLICANT();
                    _obj_smhr_applicant.APPLICANT_CODE = aplicantcode;
                    _obj_smhr_applicant.OPERATION = operation.Check;
                    _obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dt_app_id = BLL.get_Applicant(_obj_smhr_applicant);

                    if (dt_app_id.Rows.Count > 0)
                    {
                        app_id = Convert.ToInt32(dt_app_id.Rows[0]["APPLICANT_ID"]);
                    }
                    _obj_smhr_applicant.APPCONT_APPLICANT_ID = app_id;
                    _obj_smhr_applicant.APPCONT_COMPANY = (Convert.ToString(ds.Tables[0].Rows[i]["Company Name*"]).Replace("'", "''"));
                    _obj_smhr_applicant.APPCONT_CONTACT = (Convert.ToString(ds.Tables[0].Rows[i]["Contact Person*"]).Replace("'", "''"));
                    _obj_smhr_applicant.APPCONT_PHONE = (Convert.ToString(ds.Tables[0].Rows[i]["Phone Number*"]).Replace("'", "''"));
                    _obj_smhr_applicant.APPCONT_ADDRESS = (Convert.ToString(ds.Tables[0].Rows[i]["Address*"]).Replace("'", "''"));
                    _obj_smhr_applicant.APPCONT_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_applicant.APPCONT_CREATEDDATE = DateTime.Now;
                    _obj_smhr_applicant.OPERATION = operation.Check_New;
                    DataTable dt_serialno = BLL.get_ApplicantContact(_obj_smhr_applicant);
                    //int serno =( Convert.ToInt32(dt_serialno.Rows[0]["APPCONT_SERIAL"]))+1;
                    _obj_smhr_applicant.APPCONT_SERIAL = (Convert.ToInt32(dt_serialno.Rows[0]["APPCONT_SERIAL"])) + 1;


                    _obj_smhr_applicant.OPERATION = operation.Insert;

                    status = BLL.set_ApplContact(_obj_smhr_applicant);


                    if (status == true)
                    {
                        BLL.ShowMessage(this, "Successfully processed Excel file.");
                    }

                }
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmapplicant", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }



    //************************


    protected void btn_Imp_skills_Click(object sender, EventArgs e)
    {
        try
        {
            //written by neymesha
            //to import the  skills details
            string strcon = null;
            string strfilename1 = Uploadskills.FileName;
            strfilename2 = Convert.ToString(DateTime.Now.TimeOfDay) + "_" + strfilename1;
            strfilename2 = strfilename2.Replace("/", "").Replace(":", ".");
            if (Uploadskills.HasFile)
            {
                if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == false)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath("~/IMPORT_EXCEL/"));

                }
                Uploadskills.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/IMPORT_EXCEL/"), strfilename2));
                string filename1 = Server.MapPath("~/IMPORT_EXCEL/") + ("") + (Convert.ToString(strfilename2));
                FileInfo fileInfo = new FileInfo(filename1);
                if (fileInfo.Exists)
                {
                    string path = MapPath(strfilename1);
                    // string name = Path.GetFileName( path );
                    string ext = Path.GetExtension(path);

                    string type = string.Empty;
                    //  set known types based on file extension  
                    if (ext != null)
                    {
                        switch (ext.ToLower())
                        {

                            case ".xls":

                                type = "excel";
                                break;
                            case ".xlsx":
                                type = "excel";
                                break;

                            default:
                                type = string.Empty;
                                break;
                        }
                    }
                    if (type == string.Empty)
                    {
                        if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == true)
                        {

                            string path1 = Server.MapPath("~/IMPORT_EXCEL/") + ("") + (Convert.ToString(strfilename2));
                            System.IO.File.Delete(path1);
                        }
                        BLL.ShowMessage(this, "Please select the Excel File  (Eg: Excel.xlsx). ");
                        return;
                    }
                }
            }
            else
            {
                BLL.ShowMessage(this, "Please Select the File to be uploaded");
                return;
            }

            string strpath = Server.MapPath("~/IMPORT_EXCEL/");

            strpath = strpath + strfilename2;


            // Getting data from excell file to dataset.
            strcon = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source='" + strpath + "';" + "Extended Properties=Excel 12.0;";


            OleDbConnection objConn = null;
            objConn = new OleDbConnection(strcon);
            objConn.Open();

            DataTable dt_chk2 = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string sheetname;
            if (dt_chk2 == null)
            {
                objConn.Close();
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            else
            {
                sheetname = Convert.ToString(dt_chk2.Rows[0]["TABLE_NAME"]);
            }
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM  [" + sheetname + "]", strcon);



            da.Fill(ds);

            objConn.Close();
            DataTable dt = new DataTable();
            DataTable dtfail = new DataTable();
            string projecttype = null;
            Int32 rowno = 0;
            DateTime dat;
            string columnno = null;
            string projname = null;
            Boolean filestatus = true;
            dtfail.Columns.Add("S.NO", typeof(Int32));
            dtfail.Columns.Add("ROWNO", typeof(Int32));
            dtfail.Columns.Add("COLUMNS NAMES", typeof(string));


            if (ds.Tables[0].Columns[0].ToString().Trim() == "Applicant Code*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }



            if (ds.Tables[0].Columns[1].ToString().Trim() == "Skill Name*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }

            if (ds.Tables[0].Columns[2].ToString().Trim() == "Last Used*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }

            if (ds.Tables[0].Columns[3].ToString().Trim() == "Expertise*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please selsct the Correct Excel Template Sheet.");
                return;
            }


            if (ds.Tables[0].Rows.Count == 0)
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Successfully processed Excel file. No Records are Imported.");
                return;
            }

            //to check the data in excel
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                if (ds.Tables[0].Rows[i]["Applicant Code*"].ToString().Trim() != "")
                {

                    string aplicantcode = ds.Tables[0].Rows[i]["Applicant Code*"].ToString();
                    SMHR_APPLICANT _obj_smhr_applicant = new SMHR_APPLICANT();
                    _obj_smhr_applicant.APPLICANT_CODE = aplicantcode;
                    _obj_smhr_applicant.OPERATION = operation.Check;
                    _obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dt_app_id = BLL.get_Applicant(_obj_smhr_applicant);

                    if (dt_app_id.Rows.Count > 0)//APPLICANT_ID
                    {
                        app_id = Convert.ToInt32(dt_app_id.Rows[0]["APPLICANT_ID"]);
                    }
                    else
                    {
                        filestatus = false;
                        rowno = i + 2;
                        columnno = "Applicant Code*";
                    }

                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = "Applicant Code*";
                }

                if (ds.Tables[0].Rows[i]["Skill Name*"].ToString().Trim() != "")
                {
                    SMHR_MASTERS _Obj_smhr_Masters = new SMHR_MASTERS();
                    _Obj_smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _Obj_smhr_Masters.OPERATION = operation.Select;
                    _Obj_smhr_Masters.MASTER_TYPE = "SKILL";
                    _Obj_smhr_Masters.MASTER_CODE = ds.Tables[0].Rows[i]["Skill Name*"].ToString().Trim();
                    DataTable dt_nat = BLL.get_Applicant_Validate(_Obj_smhr_Masters);
                    if (Convert.ToInt32(dt_nat.Rows[0]["HR_MASTER_ID"]) > 0)
                    {

                        if (app_id != 0)
                        {
                            SMHR_APPLICANT _obj_smhr_applicant = new SMHR_APPLICANT();
                            _obj_smhr_applicant.APPSKL_APPLICANT_ID = app_id;
                            _obj_smhr_applicant.OPERATION = operation.Check_New;
                            _obj_smhr_applicant.APPSKL_SKILL_ID = Convert.ToInt32(dt_nat.Rows[0]["HR_MASTER_ID"]);
                            _obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

                            DataTable dt_appskill = BLL.get_ApplicantSkills(_obj_smhr_applicant);


                            if (dt_appskill.Rows.Count > 0)
                            {
                                filestatus = false;//already exist in DB
                                rowno = i + 2;
                                columnno = columnno + "," + "Skill Name*";
                            }
                            else
                            {
                                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                                {
                                    if (i != j)
                                    {
                                        if (ds.Tables[0].Rows[j]["Applicant Code*"].ToString().Trim() == ds.Tables[0].Rows[i]["APPlicant Code*"].ToString().Trim() && ds.Tables[0].Rows[j]["Skill Name*"].ToString().Trim() == ds.Tables[0].Rows[i]["Skill Name*"].ToString().Trim())
                                        {
                                            filestatus = false;//already exist in excel
                                            rowno = i + 2;
                                            columnno = columnno + "," + "Skill Name*";
                                            break;
                                        }
                                    }
                                }


                            }

                        }


                    }
                    else
                    {
                        filestatus = false;
                        rowno = i + 2;
                        columnno = columnno + "," + "Skill Name*";


                    }
                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Skill Name*";


                }

                if (ds.Tables[0].Rows[i]["Last Used*"].ToString().Trim() != "")
                {
                    Year = Convert.ToInt32(ds.Tables[0].Rows[i]["Last Used*"]);



                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Last Used*";


                }

                if (ds.Tables[0].Rows[i]["Expertise*"].ToString().Trim() == "Beginner" || ds.Tables[0].Rows[i]["Expertise*"].ToString().Trim() == "Intermediate" || ds.Tables[0].Rows[i]["Expertise*"].ToString().Trim() == "Expert")
                {

                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Expertise*";

                }

                if (filestatus == false)
                {
                    DataRow newrow = dtfail.NewRow();
                    newrow["S.NO"] = dtfail.Rows.Count + 1;


                    newrow["ROWNO"] = rowno;
                    newrow["COLUMNS NAMES"] = columnno;
                    dtfail.Rows.Add(newrow);
                }


            }

            if (dtfail.Rows.Count > 0)
            {
                Session["dt_fail"] = dtfail;
                Session["ds_data"] = ds;
                Delete_Excel_File();
                //LinkButton lnk_Import_process = (LinkButton)RadPanelBar1.FindItemByValue("AddAttachment").FindControl("lnk_Import_process");
                Telerik.Web.UI.RadWindow newwindow = new Telerik.Web.UI.RadWindow();
                // RWM_POSTREPLY.Windows.Remove(newwindow);
                newwindow.ID = "RadWindow_import";

                newwindow.NavigateUrl = "~/Payroll/frm_AttendanceImportProcess.aspx";
                newwindow.Title = "Import Process";
                newwindow.Width = 1150;
                newwindow.Height = 580;
                newwindow.VisibleOnPageLoad = true;
                if (RWM_POSTREPLY1.Windows.Count > 1)
                {
                    RWM_POSTREPLY1.Windows.RemoveAt(1);
                }
                RWM_POSTREPLY1.Windows.Add(newwindow);



                RWM_POSTREPLY1.Visible = true;
                return;

            }
            else
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    _obj_smhr_applicant = new SMHR_APPLICANT();
                    bool status = false;

                    string aplicantcode = ds.Tables[0].Rows[i]["Applicant Code*"].ToString();
                    //SMHR_APPLICANT _obj_smhr_applicant = new SMHR_APPLICANT();
                    _obj_smhr_applicant.APPLICANT_CODE = aplicantcode;
                    _obj_smhr_applicant.OPERATION = operation.Check;
                    _obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dt_app_id = BLL.get_Applicant(_obj_smhr_applicant);

                    if (dt_app_id.Rows.Count > 0)
                    {
                        app_id = Convert.ToInt32(dt_app_id.Rows[0]["APPLICANT_ID"]);
                    }



                    _obj_smhr_applicant.APPSKL_APPLICANT_ID = app_id;





                    SMHR_MASTERS _Obj_smhr_Masters = new SMHR_MASTERS();

                    _Obj_smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _Obj_smhr_Masters.MASTER_TYPE = "SKILL";
                    _Obj_smhr_Masters.OPERATION = operation.Select;

                    _Obj_smhr_Masters.MASTER_CODE = ds.Tables[0].Rows[i]["Skill Name*"].ToString().Trim();
                    DataTable dt_skill = BLL.get_Applicant_Validate(_Obj_smhr_Masters);


                    _obj_smhr_applicant.APPSKL_SKILL_ID = Convert.ToInt32(dt_skill.Rows[0]["HR_MASTER_ID"]);

                    _obj_smhr_applicant.APPSKL_LASTUSED = Convert.ToInt32(ds.Tables[0].Rows[i]["Last Used*"]);
                    _obj_smhr_applicant.OPERATION = operation.Insert;
                    _obj_smhr_applicant.APPSKL_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_applicant.APPSKL_CREATEDDATE = DateTime.Now;
                    if (ds.Tables[0].Rows[i]["Expertise*"].ToString().Trim() != "")
                    {
                        if (ds.Tables[0].Rows[i]["Expertise*"].ToString().Trim() == "Beginner")
                        {
                            _obj_smhr_applicant.APPSKL_EXPERT = 1;
                        }
                        else if (ds.Tables[0].Rows[i]["Expertise*"].ToString().Trim() == "Intermediate")
                        {
                            _obj_smhr_applicant.APPSKL_EXPERT = 2;
                        }
                        else if (ds.Tables[0].Rows[i]["Expertise*"].ToString().Trim() == "Expert")
                        {
                            _obj_smhr_applicant.APPSKL_EXPERT = 3;

                        }
                    }

                    status = BLL.set_ApplSkills(_obj_smhr_applicant);
                    if (status == true)
                    {
                        BLL.ShowMessage(this, "Successfully processed Excel file.");
                    }

                }
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmapplicant", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }






    protected void btn_Imp_aplicant_Click(object sender, EventArgs e)
    {
        try
        {
            // written by rajasekhar 
            // for Importing All appliant details like personal,qualificarion,skills ...etc..



            Session.Remove("dt_fail_per");



            Session.Remove("ds_data_per");
            Session.Remove("DT_FAIL_QUALI");
            Session.Remove("DT_DATA_QUALI");
            Session.Remove("DT_FAIL_SKILLS");
            Session.Remove("DT_DATA_SKILLS");
            Session.Remove("DT_FAIL_EXPERIANCE");
            Session.Remove("DT_DATA_EXPERIANCE");
            Session.Remove("DT_FAIL_CONTACT");
            Session.Remove("DT_DATA_CONTACT");
            Session.Remove("DT_FAIL_LANGUAGE");
            Session.Remove("DT_DATA_LANGUAGE");





            string strcon = null;

            string strfilename1 = Up_aplicant.FileName;
            strfilename2 = Convert.ToString(DateTime.Now.TimeOfDay) + "_" + strfilename1;
            strfilename2 = strfilename2.Replace("/", "").Replace(":", ".");
            if (Up_aplicant.HasFile)
            {
                if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == false)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath("~/IMPORT_EXCEL/"));
                }
                Up_aplicant.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/IMPORT_EXCEL/"), strfilename2));
                string filename1 = Server.MapPath("~/IMPORT_EXCEL/") + ("") + (Convert.ToString(strfilename2));
                FileInfo fileInfo = new FileInfo(filename1);
                if (fileInfo.Exists)
                {
                    string path = MapPath(strfilename1);
                    // string name = Path.GetFileName( path );
                    string ext = Path.GetExtension(path);

                    string type = string.Empty;
                    if (ext != null)
                    {
                        switch (ext.ToLower())
                        {

                            case ".xls":

                                type = "excel";
                                break;
                            case ".xlsx":
                                type = "excel";
                                break;

                            default:
                                type = string.Empty;
                                break;
                        }
                    }
                    if (type == string.Empty)
                    {
                        if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == true)
                        {

                            string path1 = Server.MapPath("~/IMPORT_EXCEL/") + ("") + (Convert.ToString(strfilename2));
                            System.IO.File.Delete(path1);
                        }
                        BLL.ShowMessage(this, "Please select the Excel File  (Eg: Excel.xlsx). ");
                        return;
                    }



                }


            }
            else
            {
                BLL.ShowMessage(this, "Please Select the File to be uploaded");
                return;
            }

            string strpath = Server.MapPath("~/IMPORT_EXCEL/");

            strpath = strpath + strfilename2;


            // Getting data from excell file to dataset.
            strcon = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source='" + strpath + "';" + "Extended Properties=Excel 12.0;";


            OleDbConnection objConn = null;
            objConn = new OleDbConnection(strcon);
            objConn.Open();

            DataTable dt_chk2 = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string sheetname;
            if (dt_chk2 == null)
            {
                objConn.Close();
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            else
            {
                sheetname = Convert.ToString(dt_chk2.Rows[4]["TABLE_NAME"]);// personal details
            }
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM  [" + sheetname + "]", strcon);



            da.Fill(ds_personal);
            ds_personal.Tables[0].Columns.Add("Error Message");
            objConn.Close();
            DataTable dt = new DataTable();
            DataTable dtfail_personal = new DataTable();

            string errormsg = string.Empty;



            string projecttype = null;
            Int32 rowno = 0;

            DateTime dat;
            string columnno = null;
            string projname = null;
            Boolean filestatus = true;
            dtfail_personal.Columns.Add("S.NO", typeof(Int32));
            dtfail_personal.Columns.Add("ROWNO", typeof(Int32));
            dtfail_personal.Columns.Add("COLUMNS NAMES", typeof(string));

            if (ds_personal.Tables[0].Columns[0].ToString().Trim() == "Applicant SNO*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }

            if (ds_personal.Tables[0].Columns[1].ToString().Trim() == "Title*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds_personal.Tables[0].Columns[2].ToString().Trim() == "First Name*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds_personal.Tables[0].Columns[3].ToString().Trim() == "Middle Name")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds_personal.Tables[0].Columns[4].ToString().Trim() == "Last Name")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds_personal.Tables[0].Columns[5].ToString().Trim() == "Date of Birth*(DD/MM/YYYY)")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds_personal.Tables[0].Columns[6].ToString().Trim() == "Gender*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds_personal.Tables[0].Columns[7].ToString().Trim() == "Blood Group*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds_personal.Tables[0].Columns[8].ToString().Trim() == "Religion*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds_personal.Tables[0].Columns[9].ToString().Trim() == "Nationality*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds_personal.Tables[0].Columns[10].ToString().Trim() == "Status*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds_personal.Tables[0].Columns[11].ToString().Trim() == "Marital Status")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds_personal.Tables[0].Columns[12].ToString().Trim() == "Address")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }

            if (ds_personal.Tables[0].Columns[13].ToString().Trim() == "Remarks")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            //if (ds.Tables[0].Rows.Count == 0)
            //{
            //    Delete_Excel_File();
            //    BLL.ShowMessage(this, "Successfully processed Excel file. No Records are Imported.");
            //    return;

            //}


            //da.Fill(ds);

            //objConn.Close();
            objConn = new OleDbConnection(strcon);
            objConn.Open();
            sheetname = Convert.ToString(dt_chk2.Rows[3]["TABLE_NAME"]);//Qualification Details

            OleDbDataAdapter da1 = new OleDbDataAdapter("SELECT * FROM  [" + sheetname + "]", strcon);
            da1.Fill(ds_Qualification);
            ds_Qualification.Tables[0].Columns.Add("Error Message");

            objConn.Close();
            DataTable dtfail_Qualification = new DataTable();



            dtfail_Qualification.Columns.Add("S.NO", typeof(Int32));
            dtfail_Qualification.Columns.Add("ROWNO", typeof(Int32));
            dtfail_Qualification.Columns.Add("COLUMNS NAMES", typeof(string));
            if (ds_Qualification.Tables[0].Columns[0].ToString().Trim() == "Applicant SNO*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds_Qualification.Tables[0].Columns[1].ToString().Trim() == "Category*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds_Qualification.Tables[0].Columns[2].ToString().Trim() == "Institute*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds_Qualification.Tables[0].Columns[3].ToString().Trim() == "Year of pass*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds_Qualification.Tables[0].Columns[4].ToString().Trim() == "Percentage*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds_Qualification.Tables[0].Columns[5].ToString().Trim() == "Grade*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            objConn = new OleDbConnection(strcon);
            objConn.Open();
            sheetname = Convert.ToString(dt_chk2.Rows[5]["TABLE_NAME"]);//skills Details

            OleDbDataAdapter da_Skills = new OleDbDataAdapter("SELECT * FROM  [" + sheetname + "]", strcon);
            da_Skills.Fill(ds_skills);
            ds_skills.Tables[0].Columns.Add("Error Message");

            objConn.Close();
            DataTable dtfail_Skills = new DataTable();



            dtfail_Skills.Columns.Add("S.NO", typeof(Int32));
            dtfail_Skills.Columns.Add("ROWNO", typeof(Int32));
            dtfail_Skills.Columns.Add("COLUMNS NAMES", typeof(string));
            if (ds_skills.Tables[0].Columns[0].ToString().Trim() == "Applicant SNO*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }



            if (ds_skills.Tables[0].Columns[1].ToString().Trim() == "Skill Name*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }

            if (ds_skills.Tables[0].Columns[2].ToString().Trim() == "Last Used*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }

            if (ds_skills.Tables[0].Columns[3].ToString().Trim() == "Expertise*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please selsct the Correct Excel Template Sheet.");
                return;
            }


            objConn = new OleDbConnection(strcon);
            objConn.Open();
            sheetname = Convert.ToString(dt_chk2.Rows[1]["TABLE_NAME"]);

            OleDbDataAdapter da_Experiance = new OleDbDataAdapter("SELECT * FROM  [" + sheetname + "]", strcon);
            da_Experiance.Fill(ds_experiance);
            ds_experiance.Tables[0].Columns.Add("Error Message");

            objConn.Close();
            DataTable dtfail_experiance = new DataTable();



            dtfail_experiance.Columns.Add("S.NO", typeof(Int32));
            dtfail_experiance.Columns.Add("ROWNO", typeof(Int32));
            dtfail_experiance.Columns.Add("COLUMNS NAMES", typeof(string));
            if (ds_experiance.Tables[0].Columns[0].ToString().Trim() == "Applicant SNO*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds_experiance.Tables[0].Columns[1].ToString().Trim() == "Company Name*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds_experiance.Tables[0].Columns[2].ToString().Trim() == "Joining Date*(DD/MM/YYYY)")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds_experiance.Tables[0].Columns[3].ToString().Trim() == "Join Salary*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds_experiance.Tables[0].Columns[4].ToString().Trim() == "Join Position*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds_experiance.Tables[0].Columns[5].ToString().Trim() == "Reason For Relieving*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds_experiance.Tables[0].Columns[6].ToString().Trim() == "Relieving Date*(DD/MM/YYYY)")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds_experiance.Tables[0].Columns[7].ToString().Trim() == "Relieving Salary*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds_experiance.Tables[0].Columns[8].ToString().Trim() == "Relieving Position*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }

            objConn = new OleDbConnection(strcon);
            objConn.Open();
            sheetname = Convert.ToString(dt_chk2.Rows[0]["TABLE_NAME"]);

            OleDbDataAdapter da_Contact = new OleDbDataAdapter("SELECT * FROM  [" + sheetname + "]", strcon);
            da_Contact.Fill(ds_contact);
            ds_contact.Tables[0].Columns.Add("Error Message");

            objConn.Close();
            DataTable dtfail_contacts = new DataTable();



            dtfail_contacts.Columns.Add("S.NO", typeof(Int32));
            dtfail_contacts.Columns.Add("ROWNO", typeof(Int32));
            dtfail_contacts.Columns.Add("COLUMNS NAMES", typeof(string));
            if (ds_contact.Tables[0].Columns[0].ToString().Trim() == "Applicant SNO*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }


            if (ds_contact.Tables[0].Columns[1].ToString().Trim() == "Company Name*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }

            if (ds_contact.Tables[0].Columns[2].ToString().Trim() == "Contact Person*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }

            if (ds_contact.Tables[0].Columns[3].ToString().Trim() == "Phone Number*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }

            if (ds_contact.Tables[0].Columns[4].ToString().Trim() == "Address*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            objConn = new OleDbConnection(strcon);
            objConn.Open();
            sheetname = Convert.ToString(dt_chk2.Rows[2]["TABLE_NAME"]);

            OleDbDataAdapter da_language = new OleDbDataAdapter("SELECT * FROM  [" + sheetname + "]", strcon);
            da_language.Fill(ds_language);
            ds_language.Tables[0].Columns.Add("Error Message");

            objConn.Close();
            DataTable dtfail_language = new DataTable();



            dtfail_language.Columns.Add("S.NO", typeof(Int32));
            dtfail_language.Columns.Add("ROWNO", typeof(Int32));
            dtfail_language.Columns.Add("COLUMNS NAMES", typeof(string));

            if (ds_language.Tables[0].Columns[0].ToString().Trim() == "Applicant SNO*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds_language.Tables[0].Columns[1].ToString().Trim() == "Language*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }

            if (ds_language.Tables[0].Columns[2].ToString().Trim() == "Read")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds_language.Tables[0].Columns[3].ToString().Trim() == "Write")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds_language.Tables[0].Columns[4].ToString().Trim() == "Speak")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds_language.Tables[0].Columns[5].ToString().Trim() == "Understand")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }


            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            // to check the data in sheet1(Aplicant_personal details
            for (int i = 0; i < ds_personal.Tables[0].Rows.Count; i++)
            {
                errormsg = string.Empty;
                columnno = string.Empty;

                if (ds_personal.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() != "")
                {
                    for (int j = 0; j < ds_personal.Tables[0].Rows.Count; j++)
                    {
                        if (i != j)
                        {
                            if (ds_personal.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() == ds_personal.Tables[0].Rows[j]["Applicant SNO*"].ToString().Trim())
                            {
                                filestatus = false;
                                rowno = i + 2;
                                columnno = columnno + "," + "Applicant SNO*";
                            }
                        }
                    }

                }
                else
                {
                    errormsg = "enter Applicant ID";
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Applicant SNO*";

                }
                if (ds_personal.Tables[0].Rows[i]["Title*"].ToString().Trim() != "")
                {
                    if (ds_personal.Tables[0].Rows[i]["Title*"].ToString().Trim() == "Mr." || ds_personal.Tables[0].Rows[i]["Title*"].ToString().Trim() == "Ms." || ds_personal.Tables[0].Rows[i]["Title*"].ToString().Trim() == "Mrs.")
                    {

                    }
                    else
                    {
                        errormsg = errormsg + "," + "enter Correct Title Eg:Mr.,Mrs.,Ms.";
                        filestatus = false;
                        rowno = i + 2;
                        columnno = "Title*";

                    }

                }
                else
                {
                    errormsg = errormsg + "," + "enter Title";
                    filestatus = false;
                    rowno = i + 2;
                    columnno = "Title*";

                }
                if (ds_personal.Tables[0].Rows[i]["First Name*"].ToString().Trim() != "")
                {

                }
                else
                {
                    errormsg = errormsg + "," + "enter First Name";

                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "First Name*";

                }



                if (ds_personal.Tables[0].Rows[i]["Date of Birth*(DD/MM/YYYY)"].ToString().Trim() != "")
                {

                    bool Chkdate = CheckDateFormat(Convert.ToString(ds_personal.Tables[0].Rows[i]["Date of Birth*(DD/MM/YYYY)"]));
                    if (Chkdate == true)
                    {

                        _obj_smhr_applicant = new SMHR_APPLICANT();
                        _obj_smhr_applicant.OPERATION = operation.Check_New;
                        _obj_smhr_applicant.APPLI_DOB = Convert.ToString(ds_personal.Tables[0].Rows[i]["Date of Birth*(DD/MM/YYYY)"]);
                        DataTable dtdatecheck = BLL.CONVERTTODATE(_obj_smhr_applicant);


                        if ((Convert.ToString(dtdatecheck.Rows[0]["RESULT"])) == "ACCEPT")
                        {

                            stdatetime = true;
                        }
                        else
                        {

                            stdatetime = false;

                            errormsg = errormsg + "," + "enter correct Dateof birth";

                            filestatus = false;
                            rowno = i + 2;
                            columnno = columnno + "," + "Date of Birth*(DD/MM/YYYY)";


                        }



                    }

                    else
                    {
                        errormsg = "enter Date Of birth";
                        filestatus = false;
                        rowno = i + 2;
                        columnno = columnno + "," + "Date of Birth*(DD/MM/YYYY)";

                    }
                    if ((ds_personal.Tables[0].Rows[i]["Title*"].ToString().Trim() == "Mr." && ds_personal.Tables[0].Rows[i]["Gender*"].ToString().Trim() == "Male") || ((ds_personal.Tables[0].Rows[i]["Title*"].ToString().Trim() == "Ms." || ds_personal.Tables[0].Rows[i]["Title*"].ToString().Trim() == "Mrs.") && ds_personal.Tables[0].Rows[i]["Gender*"].ToString().Trim() == "Female"))
                    {


                    }
                    else
                    {
                        errormsg = errormsg + "," + "Title Is not matching for gender";

                        filestatus = false;
                        rowno = i + 2;
                        columnno = columnno + "," + "Gender*";

                    }

                    if (ds_personal.Tables[0].Rows[i]["Blood Group*"].ToString().Trim() == "O+" || ds_personal.Tables[0].Rows[i]["Blood Group*"].ToString().Trim() == "O-" || ds_personal.Tables[0].Rows[i]["Blood Group*"].ToString().Trim() == "B+" || ds_personal.Tables[0].Rows[i]["Blood Group*"].ToString().Trim() == "B-" || ds_personal.Tables[0].Rows[i]["Blood Group*"].ToString().Trim() == "AB+" || ds_personal.Tables[0].Rows[i]["Blood Group*"].ToString().Trim() == "AB-" || ds_personal.Tables[0].Rows[i]["Blood Group*"].ToString().Trim() == "A-")
                    {
                    }
                    else
                    {
                        errormsg = errormsg + "," + "enter Valid Blood Group";

                        filestatus = false;
                        rowno = i + 2;
                        columnno = columnno + "," + "Blood Group*";//Religion*


                    }
                    if (ds_personal.Tables[0].Rows[i]["Religion*"].ToString().Trim() != "")
                    {
                        SMHR_MASTERS _Obj_smhr_Masters = new SMHR_MASTERS();

                        _Obj_smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _Obj_smhr_Masters.MASTER_TYPE = "RELIGION";
                        _Obj_smhr_Masters.OPERATION = operation.Check;

                        _Obj_smhr_Masters.MASTER_CODE = ds_personal.Tables[0].Rows[i]["Religion*"].ToString().Trim();
                        DataTable dt_relig = BLL.get_Applicant_Validate(_Obj_smhr_Masters);
                        if (Convert.ToInt32(dt_relig.Rows[0]["COUNT"]) > 0)
                        {
                        }
                        else
                        {
                            errormsg = errormsg + "," + "Religion Does not exist";

                            filestatus = false;
                            rowno = i + 2;
                            columnno = columnno + "," + "Religion*";


                        }

                    }
                    else
                    {
                        errormsg = "enter Religion";

                        filestatus = false;
                        rowno = i + 2;
                        columnno = columnno + "," + "Religion*";


                    }
                    if (ds_personal.Tables[0].Rows[i]["Nationality*"].ToString().Trim() != "")
                    {
                        SMHR_MASTERS _Obj_smhr_Masters = new SMHR_MASTERS();
                        _Obj_smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _Obj_smhr_Masters.OPERATION = operation.Check;
                        _Obj_smhr_Masters.MASTER_TYPE = "NATIONALITY";
                        _Obj_smhr_Masters.MASTER_CODE = ds_personal.Tables[0].Rows[i]["Nationality*"].ToString().Trim();
                        DataTable dt_nat = BLL.get_Applicant_Validate(_Obj_smhr_Masters);
                        if (Convert.ToInt32(dt_nat.Rows[0]["COUNT"]) > 0)
                        {
                        }
                        else
                        {
                            filestatus = false;
                            rowno = i + 2;
                            columnno = columnno + "," + "Nationality*";


                        }
                    }
                    else
                    {
                        filestatus = false;
                        rowno = i + 2;
                        columnno = columnno + "," + "Nationality*";


                    }
                    if (ds_personal.Tables[0].Rows[i]["Status*"].ToString().Trim() == "Applied" || ds_personal.Tables[0].Rows[i]["Status*"].ToString().Trim() == "Selected" || ds_personal.Tables[0].Rows[i]["Status*"].ToString().Trim() == "Rejected")
                    {
                    }
                    else
                    {
                        errormsg = errormsg + "," + "Enter Valid Status";

                        filestatus = false;
                        rowno = i + 2;
                        columnno = columnno + "," + "Status*";
                        //Marital Status



                    }
                    if (ds_personal.Tables[0].Rows[i]["Marital Status"].ToString().Trim() == "Single" || ds_personal.Tables[0].Rows[i]["Marital Status"].ToString().Trim() == "Divorced" || ds_personal.Tables[0].Rows[i]["Marital Status"].ToString().Trim() == "Married" || ds_personal.Tables[0].Rows[i]["Marital Status"].ToString().Trim() == "Now Married")
                    {
                    }
                    else
                    {
                        errormsg = "Marital Status Does not exists";

                        filestatus = false;
                        rowno = i + 2;
                        columnno = columnno + "," + "Marital Status";




                    }
                    if (ds_personal.Tables[0].Rows[i]["Address"].ToString().Trim() != "")
                    {

                    }


                    else
                    {
                        errormsg = errormsg + "," + "enter Address";

                        filestatus = false;
                        rowno = i + 2;
                        columnno = columnno + "," + "Address";




                    }

                    //if (ds_personal.Tables[0].Rows[i]["Remarks"].ToString().Trim() != "")
                    //{

                    //}


                    //else
                    //{

                    //    filestatus = false;
                    //    rowno = i + 2;
                    //    columnno = columnno + "," + "Remarks";




                    //}

                    if (filestatus == false)
                    {
                        DataRow newrow = dtfail_personal.NewRow();
                        newrow["S.NO"] = dtfail_personal.Rows.Count + 1;


                        newrow["ROWNO"] = rowno;
                        newrow["COLUMNS NAMES"] = columnno;
                        dtfail_personal.Rows.Add(newrow);
                        ds_personal.Tables[0].Rows[i]["Error Message"] = errormsg;

                    }


                }
            }

            //if (dtfail_personal.Rows.Count > 0)
            //{
            //    Session["dt_fail_per"] = dtfail_personal;
            //    Session["ds_data_per"] = ds_personal;
            //    Delete_Excel_File();
            //    //LinkButton lnk_Import_process = (LinkButton)RadPanelBar1.FindItemByValue("AddAttachment").FindControl("lnk_Import_process");
            //    Telerik.Web.UI.RadWindow newwindow = new Telerik.Web.UI.RadWindow();
            //    // RWM_POSTREPLY.Windows.Remove(newwindow);
            //    newwindow.ID = "RadWindow_import";

            //    newwindow.NavigateUrl = "~/Recruitment/Default.aspx";
            //    newwindow.Title = "Import Process";
            //    newwindow.Width = 1150;
            //    newwindow.Height = 580;
            //    newwindow.VisibleOnPageLoad = true;
            //    if (RWM_POSTREPLY1.Windows.Count > 1)
            //    {
            //        RWM_POSTREPLY1.Windows.RemoveAt(1);
            //    }
            //    RWM_POSTREPLY1.Windows.Add(newwindow);



            //    RWM_POSTREPLY1.Visible = true;
            //    return;

            //}










            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@







            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@--To check the Qualification data in excel 

            for (int i = 0; i < ds_Qualification.Tables[0].Rows.Count; i++)
            {
                errormsg = string.Empty;
                columnno = string.Empty;
                if (ds_Qualification.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() != "")
                {
                    bool status1 = false;

                    for (int j = 0; j < ds_personal.Tables[0].Rows.Count; j++)
                    {
                        if (ds_Qualification.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() == ds_personal.Tables[0].Rows[j]["Applicant SNO*"].ToString().Trim())
                        {




                            status1 = true;
                            break;

                        }
                    }
                    for (int k = 0; k < ds_Qualification.Tables[0].Rows.Count; k++)
                    {
                        for (int l = 0; l < ds_Qualification.Tables[0].Rows.Count; l++)
                        {
                            if (k != l)
                            {
                                if (ds_Qualification.Tables[0].Rows[k]["Applicant SNO*"].ToString().Trim() == ds_Qualification.Tables[0].Rows[l]["Applicant SNO*"].ToString().Trim() && ds_Qualification.Tables[0].Rows[k]["Category*"].ToString().Trim() == ds_Qualification.Tables[0].Rows[l]["Category*"].ToString().Trim())
                                {
                                    errormsg = "Category repeated for same applicant in excel";
                                    filestatus = false;//already exist in excel
                                    rowno = i + 2;
                                    columnno = columnno + "," + "Category*";
                                    break;
                                }
                            }
                        }
                    }
                    if (status1 == false)
                    {
                        //errormsg = "Enter Aplicant SNO";
                        filestatus = false;
                        rowno = i + 2;
                        columnno = "Applicant SNO*";

                    }

                    //SMHR_APPLICANT _obj_smhr_applicant = new SMHR_APPLICANT();
                    //_obj_smhr_applicant.OPERATION = operation.Check;
                    //_obj_smhr_applicant.APPLICANT_CODE = Convert.ToString(ds_Qualification.Tables[0].Rows[i]["Applicant Code*"].ToString().Trim());
                    //_obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    //DataTable dt_appcode = BLL.get_Applicant(_obj_smhr_applicant);
                    //if (dt_appcode.Rows.Count > 0)//validate applicant id exist or not
                    //{
                    //    app_id = Convert.ToInt32(dt_appcode.Rows[0]["APPLICANT_ID"]);
                    //}
                    //else
                    //{
                    //    filestatus = false;
                    //    rowno = i + 2;
                    //    columnno = "Applicant Code*";

                    //}




                }
                else
                {
                    errormsg = "Enter Aplicant SNO";
                    filestatus = false;
                    rowno = i + 2;
                    columnno = "Applicant SNO*";

                }
                if (ds_Qualification.Tables[0].Rows[i]["Category*"].ToString().Trim() != "")
                {
                    SMHR_MASTERS _Obj_smhr_Masters = new SMHR_MASTERS();
                    _Obj_smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _Obj_smhr_Masters.OPERATION = operation.Select;
                    _Obj_smhr_Masters.MASTER_TYPE = "QUALIFICATION";
                    _Obj_smhr_Masters.MASTER_CODE = ds_Qualification.Tables[0].Rows[i]["Category*"].ToString().Trim();
                    DataTable dt_nat = BLL.get_Applicant_Validate(_Obj_smhr_Masters);
                    if (Convert.ToInt32(dt_nat.Rows.Count) > 0)
                    {


                    }
                    else
                    {
                        errormsg = errormsg + "," + "Category Does not exist"; ;
                        filestatus = false;
                        rowno = i + 2;
                        columnno = columnno + "," + "Category*";


                    }

                }
                else
                {
                    errormsg = errormsg + "," + "Enter Category ";

                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Category*";

                }

                if (ds_Qualification.Tables[0].Rows[i]["Institute*"].ToString().Trim() != "")
                {

                }
                else
                {
                    errormsg = errormsg + "," + "Enter Institute ";

                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Institute*";

                }
                if (ds_Qualification.Tables[0].Rows[i]["Year of pass*"].ToString().Trim() != "")
                {
                    int b;
                    int.TryParse(Convert.ToString(ds_Qualification.Tables[0].Rows[i]["Year of pass*"]), out  b);
                    if (b != int.MinValue) //year of integer length 4 only
                    {
                        int count = Convert.ToString(ds_Qualification.Tables[0].Rows[i]["Year of pass*"]).Length;
                        if ((count > 4) || (count < 4))
                        {
                            errormsg = errormsg + "," + "Enter valid Year";

                            filestatus = false;
                            rowno = i + 2;
                            columnno = "Year of pass*";
                        }
                    }
                    else
                    {
                        errormsg = errormsg + "," + "Enter valid Year";

                        filestatus = false;
                        rowno = i + 2;
                        columnno = "Year of pass*";

                    }
                }
                else
                {
                    errormsg = errormsg + "," + "Enter Year of Pass ";

                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Year of pass*";

                }

                if (ds_Qualification.Tables[0].Rows[i]["Percentage*"].ToString().Trim() != "")
                {
                    //string date = Convert.ToString(ds.Tables[0].Rows[i]["Date of Birth*"]);
                    //string st = date.Substring(0, 10);

                    int b;
                    int.TryParse(Convert.ToString(ds_Qualification.Tables[0].Rows[i]["Percentage*"]), out  b);
                    if (b != int.MinValue) //year of integer length 4 only
                    {

                    }
                    else
                    {
                        filestatus = false;
                        rowno = i + 2;
                        columnno = "Percentage*";

                    }
                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Percentage*";
                }







                if (ds_Qualification.Tables[0].Rows[i]["Grade*"].ToString().Trim() != "")
                {

                    if (ds_Qualification.Tables[0].Rows[i]["Grade*"].ToString().Trim().ToUpper() == "A" || ds_Qualification.Tables[0].Rows[i]["Grade*"].ToString().Trim().ToUpper() == "B" || ds_Qualification.Tables[0].Rows[i]["Grade*"].ToString().Trim().ToUpper() == "C" || ds_Qualification.Tables[0].Rows[i]["Grade*"].ToString().Trim().ToUpper() == "D")
                    {
                    }
                    else
                    {
                        errormsg = errormsg + "," + "Enter Valid grade ";

                        filestatus = false;
                        rowno = i + 2;
                        columnno = columnno + "," + "Grade*";


                    }

                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Grade*";


                }

                if (filestatus == false)
                {
                    DataRow newrow = dtfail_Qualification.NewRow();
                    newrow["S.NO"] = dtfail_Qualification.Rows.Count + 1;


                    newrow["ROWNO"] = rowno;
                    newrow["COLUMNS NAMES"] = columnno;
                    dtfail_Qualification.Rows.Add(newrow);
                    ds_Qualification.Tables[0].Rows[i]["Error Message"] = errormsg;

                }


            }






            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@




            //@@@@@@@@@@@@@@@@@@@@@@@@@--To check the Skills data in excel sheet

            for (int i = 0; i < ds_skills.Tables[0].Rows.Count; i++)
            {

                errormsg = string.Empty;
                columnno = string.Empty;

                if (ds_skills.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() != "")
                {
                    bool status1 = false;

                    for (int j = 0; j < ds_personal.Tables[0].Rows.Count; j++)
                    {
                        if (ds_skills.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() == ds_personal.Tables[0].Rows[j]["Applicant SNO*"].ToString().Trim())
                        {




                            status1 = true;
                            break;

                        }
                    }
                    for (int k = 0; k < ds_skills.Tables[0].Rows.Count; k++)
                    {
                        for (int l = 0; l < ds_skills.Tables[0].Rows.Count; l++)
                        {
                            if (k != l)
                            {
                                if (ds_skills.Tables[0].Rows[k]["Applicant SNO*"].ToString().Trim() == ds_skills.Tables[0].Rows[l]["Applicant SNO*"].ToString().Trim() && ds_skills.Tables[0].Rows[k]["Skill Name*"].ToString().Trim() == ds_skills.Tables[0].Rows[l]["Skill Name*"].ToString().Trim())
                                {
                                    errormsg = "Skill is repeated for the same employee";
                                    filestatus = false;//already exist in excel
                                    rowno = i + 2;
                                    columnno = columnno + "," + "Skill Name*";
                                    break;
                                }
                            }
                        }
                    }

                    if (status1 == false)
                    {
                        filestatus = false;
                        rowno = i + 2;
                        columnno = "Applicant SNO*";
                    }



                    //string aplicantcode = ds_skills.Tables[0].Rows[i]["Applicant Code*"].ToString();
                    //SMHR_APPLICANT _obj_smhr_applicant = new SMHR_APPLICANT();
                    //_obj_smhr_applicant.APPLICANT_CODE = aplicantcode;
                    //_obj_smhr_applicant.OPERATION = operation.Check;
                    //_obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    //DataTable dt_app_id = BLL.get_Applicant(_obj_smhr_applicant);

                    //if (dt_app_id.Rows.Count > 0)
                    //{
                    //    app_id = Convert.ToInt32(dt_app_id.Rows[0]["APPLICANT_ID"]);
                    //}
                    //else
                    //{
                    //    filestatus = false;
                    //    rowno = i + 2;
                    //    columnno = "Applicant Code*";
                    //}

                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = "Applicant SNO*";
                }

                if (ds_skills.Tables[0].Rows[i]["Skill Name*"].ToString().Trim() != "")
                {
                    SMHR_MASTERS _Obj_smhr_Masters = new SMHR_MASTERS();
                    _Obj_smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _Obj_smhr_Masters.OPERATION = operation.Select;
                    _Obj_smhr_Masters.MASTER_TYPE = "SKILL";
                    _Obj_smhr_Masters.MASTER_CODE = ds_skills.Tables[0].Rows[i]["Skill Name*"].ToString().Trim();
                    DataTable dt_nat = BLL.get_Applicant_Validate(_Obj_smhr_Masters);
                    if (Convert.ToInt32(dt_nat.Rows.Count) > 0)
                    {


                    }



                    else
                    {
                        errormsg = errormsg + "," + "skill Name does not exist";
                        filestatus = false;
                        rowno = i + 2;
                        columnno = columnno + "," + "Skill Name*";


                    }
                }
                else
                {
                    errormsg = errormsg + "," + "Enter Skill Name";
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Skill Name*";


                }

                if (ds_skills.Tables[0].Rows[i]["Last Used*"].ToString().Trim() != "")
                {
                    Year = Convert.ToInt32(ds_skills.Tables[0].Rows[i]["Last Used*"]);



                }
                else
                {
                    errormsg = errormsg + "," + "Enter Last Used";
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Last Used*";


                }

                if (ds_skills.Tables[0].Rows[i]["Expertise*"].ToString().Trim() == "Beginner" || ds_skills.Tables[0].Rows[i]["Expertise*"].ToString().Trim() == "Intermediate" || ds_skills.Tables[0].Rows[i]["Expertise*"].ToString().Trim() == "Expert")
                {

                }
                else
                {

                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Expertise*";

                }

                if (filestatus == false)
                {
                    DataRow newrow = dtfail_Skills.NewRow();
                    newrow["S.NO"] = dtfail_Skills.Rows.Count + 1;


                    newrow["ROWNO"] = rowno;
                    newrow["COLUMNS NAMES"] = columnno;
                    dtfail_Skills.Rows.Add(newrow);
                    ds_skills.Tables[0].Rows[i]["Error Message"] = errormsg;

                }


            }




            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@




            //@@@@@@@@@@@@@@@@@@@@@@@@@@--To check the Experiance data in excel sheet

            for (int i = 0; i < ds_experiance.Tables[0].Rows.Count; i++)
            {
                columnno = string.Empty;
                string JOINDAT = string.Empty;
                string RELDAT = string.Empty;
                DateTime jdate;
                DateTime rdate;
                errormsg = string.Empty;
                columnno = string.Empty;

                if (ds_experiance.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() != "")
                {

                    bool status1 = false;

                    for (int j = 0; j < ds_personal.Tables[0].Rows.Count; j++)
                    {
                        if (ds_experiance.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() == ds_personal.Tables[0].Rows[j]["Applicant SNO*"].ToString().Trim())
                        {
                            status1 = true;
                            break;

                        }
                    }
                    if (status1 == false)
                    {
                        filestatus = false;
                        rowno = i + 2;
                        columnno = "Applicant SNO*";
                    }

                    //SMHR_APPLICANT _obj_smhr_applicant = new SMHR_APPLICANT();
                    //_obj_smhr_applicant.OPERATION = operation.Check;
                    //_obj_smhr_applicant.APPLICANT_CODE = Convert.ToString(ds_experiance.Tables[0].Rows[i]["Applicant Code*"].ToString().Trim());
                    //_obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    //DataTable dt_appcode = BLL.get_Applicant(_obj_smhr_applicant);
                    //if (dt_appcode.Rows.Count > 0)//validate applicant id exist or not
                    //{
                    //    app_id = Convert.ToInt32(dt_appcode.Rows[0]["APPLICANT_ID"]);
                    //}
                    //else
                    //{
                    //    filestatus = false;
                    //    rowno = i + 2;
                    //    columnno = "Applicant Code*";

                    //}

                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = "Applicant SNO*";

                }
                if (ds_experiance.Tables[0].Rows[i]["Company Name*"].ToString().Trim() != "")
                {

                }
                else
                {
                    errormsg = "Enter Company Name";
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Company Name*";

                }

                if (ds_experiance.Tables[0].Rows[i]["Joining Date*(DD/MM/YYYY)"].ToString().Trim() != "")
                {
                    //  DateTime b;


                    string JD = "";

                    JD = ds_experiance.Tables[0].Rows[i]["Joining Date*(DD/MM/YYYY)"].ToString();

                    bool WJD = JD.Contains(".");

                    if (WJD)
                        JD = JD.Replace(".", "/");
                    bool Chkdate = CheckDateFormat(JD);
                    if (Chkdate == false)
                    {
                        errormsg = errormsg + "," + "Enter Correct joining Date ";
                        filestatus = false;
                        rowno = i + 2;
                        columnno = columnno + "," + "Joining Date*(DD/MM/YYYY)";

                    }


                    //JOINDAT = JD;


                    //jdate = new DateTime();
                    //jdate = DateTime.ParseExact(JOINDAT, "dd/MM/yyyy", null);






                    //DateTime.TryParse(Convert.ToString(jdate), out  b);
                    //if (b != DateTime.MinValue)
                    //{
                    //}
                    //else
                    //{
                    //    filestatus = false;
                    //    rowno = i + 2;
                    //    columnno = columnno + "," + "Joining Date*(DD/MM/YYYY)";
                    //}


                }
                else
                {
                    errormsg = errormsg + "," + "Enter Joining Date";
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Joining Date*(DD/MM/YYYY)";

                }
                if (ds_experiance.Tables[0].Rows[i]["Join Salary*"].ToString().Trim() != "")
                {
                    int b;
                    int.TryParse(Convert.ToString(ds_experiance.Tables[0].Rows[i]["Join Salary*"]), out  b);
                    if (b != 0) //year of integer length 4 only
                    {

                    }
                    else
                    {
                        errormsg = "enter correct salary";
                        filestatus = false;
                        rowno = i + 2;
                        columnno = columnno + "," + "Join Salary*";

                    }
                }
                else
                {
                    errormsg = errormsg + "," + "enter Join Salary";
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Join Salary*";

                }








                if (ds_experiance.Tables[0].Rows[i]["Join Position*"].ToString().Trim() != "")
                {


                }
                else
                {
                    errormsg = errormsg + "," + "Enter join position";
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Join Position*";


                }
                if (ds_experiance.Tables[0].Rows[i]["Reason For Relieving*"].ToString().Trim() != "")
                {


                }
                else
                {
                    errormsg = errormsg + "," + "Enter Reason For Relieving";
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Reason For Relieving*";


                }
                if (ds_experiance.Tables[0].Rows[i]["Relieving Date*(DD/MM/YYYY)"].ToString().Trim() != "")
                {

                    //DateTime b;

                    string reldate = "";

                    reldate = ds_experiance.Tables[0].Rows[i]["Relieving Date*(DD/MM/YYYY)"].ToString();

                    bool wrongsdformat1 = reldate.Contains(".");

                    if (wrongsdformat1)
                        reldate = reldate.Replace(".", "/");

                    bool Chkdate = CheckDateFormat(reldate);
                    if (Chkdate == false)
                    {
                        errormsg = errormsg + "," + "Enter Correct Relieving Date format";
                        filestatus = false;
                        rowno = i + 2;
                        columnno = columnno + "," + "Relieving Date*(DD/MM/YYYY)";

                    }
                    //RELDAT = reldate;
                    //rdate = new DateTime();
                    //rdate = DateTime.ParseExact(RELDAT, "dd/MM/yyyy", null);
                    //DateTime.TryParse(Convert.ToString(rdate), out  b);
                    //if (b != DateTime.MinValue)
                    //{
                    //}
                    //else
                    //{
                    //    filestatus = false;
                    //    rowno = i + 2;
                    //    columnno = columnno + "," + "Relieving Date*(DD/MM/YYYY)";
                    //}

                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Relieving Date*(DD/MM/YYYY)";


                }

                if (ds_experiance.Tables[0].Rows[i]["Relieving Salary*"].ToString().Trim() != "")
                {
                    //string date = Convert.ToString(ds.Tables[0].Rows[i]["Date of Birth*"]);
                    //string st = date.Substring(0, 10);

                    int b;
                    int.TryParse(Convert.ToString(ds_experiance.Tables[0].Rows[i]["Relieving Salary*"]), out  b);
                    if (b != 0) //year of integer length 4 only
                    {

                    }
                    else
                    {
                        filestatus = false;
                        rowno = i + 2;
                        columnno = columnno + "," + "Relieving Salary*";

                    }
                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Relieving Salary*";
                }


                if (ds_experiance.Tables[0].Rows[i]["Relieving Position*"].ToString().Trim() != "")
                {


                }
                else
                {
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Relieving Position*";


                }

                if (filestatus == false)
                {
                    DataRow newrow = dtfail_experiance.NewRow();
                    newrow["S.NO"] = dtfail_experiance.Rows.Count + 1;


                    newrow["ROWNO"] = rowno;
                    newrow["COLUMNS NAMES"] = columnno;
                    dtfail_experiance.Rows.Add(newrow);
                    ds_experiance.Tables[0].Rows[i]["Error Message"] = errormsg;

                }


            }


            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

            //@@@@@@@@@@@@@@@@@@@@@@@@--To check contact details in excel

            for (int i = 0; i < ds_contact.Tables[0].Rows.Count; i++)
            {
                errormsg = string.Empty;
                columnno = string.Empty;

                if (ds_contact.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() != "")
                {

                    bool status1 = false;

                    for (int j = 0; j < ds_personal.Tables[0].Rows.Count; j++)
                    {
                        if (ds_contact.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() == ds_personal.Tables[0].Rows[j]["Applicant SNO*"].ToString().Trim())
                        {
                            status1 = true;
                            break;

                        }
                    }
                    if (status1 == false)
                    {
                        filestatus = false;
                        rowno = i + 2;
                        columnno = "Applicant SNO*";

                    }
                    //string aplicantcode = ds_contact.Tables[0].Rows[i]["Applicant Code*"].ToString();
                    //SMHR_APPLICANT _obj_smhr_applicant = new SMHR_APPLICANT();
                    //_obj_smhr_applicant.APPLICANT_CODE = aplicantcode;
                    //_obj_smhr_applicant.OPERATION = operation.Check;
                    //_obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    //DataTable dt_app_id = BLL.get_Applicant(_obj_smhr_applicant);

                    //if (dt_app_id.Rows.Count > 0)//APPLICANT_ID
                    //{
                    //    app_id = Convert.ToInt32(dt_app_id.Rows[0]["APPLICANT_ID"]);
                    //}
                    //else
                    //{
                    //    filestatus = false;
                    //    rowno = i + 2;
                    //    columnno = "Applicant Code*";
                    //}

                }
                else
                {
                    errormsg = "enter Applicant SNO";
                    filestatus = false;
                    rowno = i + 2;
                    columnno = "Applicant SNO*";
                }

                if (ds_contact.Tables[0].Rows[i]["Company Name*"].ToString().Trim() != "")
                {

                }
                else
                {
                    errormsg = "Enter Company Name";
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Company Name*";

                }

                if (ds_contact.Tables[0].Rows[i]["Contact Person*"].ToString().Trim() != "")
                {

                }
                else
                {
                    errormsg = errormsg + "," + "Enter Contact Person";
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Contact Person*";

                }

                if (ds_contact.Tables[0].Rows[i]["Phone Number*"].ToString().Trim() != "")
                {

                }
                else
                {
                    errormsg = errormsg + "," + "Enter Phone Number";
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Phone Number*";

                }
                if (ds_contact.Tables[0].Rows[i]["Address*"].ToString().Trim() != "")
                {

                }
                else
                {
                    errormsg = errormsg + "," + "Enter Address";

                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Address*";

                }

                if (filestatus == false)
                {
                    DataRow newrow = dtfail_contacts.NewRow();
                    newrow["S.NO"] = dtfail_contacts.Rows.Count + 1;


                    newrow["ROWNO"] = rowno;
                    newrow["COLUMNS NAMES"] = columnno;
                    dtfail_contacts.Rows.Add(newrow);
                    ds_contact.Tables[0].Rows[i]["Error Message"] = errormsg;

                }


            }



            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@



            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@--To check the language data in excel 

            for (int i = 0; i < ds_language.Tables[0].Rows.Count; i++)
            {
                if (ds_language.Tables[0].Rows[i]["APPlicant SNO*"].ToString().Trim() != "")
                {

                    bool status1 = false;

                    for (int j = 0; j < ds_personal.Tables[0].Rows.Count; j++)
                    {
                        if (ds_language.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() == ds_personal.Tables[0].Rows[j]["Applicant SNO*"].ToString().Trim())
                        {





                            status1 = true;
                            break;

                        }
                    }

                    for (int k = 0; k < ds_language.Tables[0].Rows.Count; k++)
                    {
                        for (int l = 0; l < ds_language.Tables[0].Rows.Count; l++)
                        {
                            if (k != l)
                            {
                                if (ds_language.Tables[0].Rows[k]["Applicant SNO*"].ToString().Trim() == ds_language.Tables[0].Rows[l]["Applicant SNO*"].ToString().Trim() && ds_language.Tables[0].Rows[k]["Language*"].ToString().Trim() == ds_language.Tables[0].Rows[l]["Language*"].ToString().Trim())
                                {
                                    errormsg = " Language is repeated for the same Applicant";
                                    filestatus = false;//already exist in excel
                                    rowno = i + 2;
                                    columnno = columnno + "," + "Language*";
                                    break;
                                }
                            }
                        }
                    }
                    if (status1 == false)
                    {
                        filestatus = false;
                        rowno = i + 2;
                        columnno = "APPlicant SNO*";

                    }

                    //string aplicantcode = ds_language.Tables[0].Rows[i]["APPlicant Code*"].ToString();
                    //SMHR_APPLICANT _obj_smhr_applicant = new SMHR_APPLICANT();
                    //_obj_smhr_applicant.APPLICANT_CODE = aplicantcode;
                    //_obj_smhr_applicant.OPERATION = operation.Check;
                    //_obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    //DataTable dt_app_id = BLL.get_Applicant(_obj_smhr_applicant);

                    //if (dt_app_id.Rows.Count > 0)//APPLICANT_ID
                    //{
                    //    app_id = Convert.ToInt32(dt_app_id.Rows[0]["APPLICANT_ID"]);
                    //}
                    //else
                    //{
                    //    filestatus = false;
                    //    rowno = i + 2;
                    //    columnno = "APPlicant Code*";
                    //}




                }
                else
                {
                    errormsg = "Enter Applicant SNO";
                    filestatus = false;
                    rowno = i + 2;
                    columnno = "APPlicant SNO*";
                }


                if (ds_language.Tables[0].Rows[i]["Language*"].ToString().Trim() != "")
                {
                    SMHR_MASTERS _Obj_smhr_Masters = new SMHR_MASTERS();
                    _Obj_smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _Obj_smhr_Masters.OPERATION = operation.Select;
                    _Obj_smhr_Masters.MASTER_TYPE = "LANGUAGE";
                    _Obj_smhr_Masters.MASTER_CODE = ds_language.Tables[0].Rows[i]["Language*"].ToString().Trim();
                    DataTable dt_nat = BLL.get_Applicant_Validate(_Obj_smhr_Masters);
                    if (Convert.ToInt32(dt_nat.Rows.Count) > 0)
                    {

                    }
                    else
                    {
                        errormsg = errormsg + "," + "language Does not exist";
                        filestatus = false;
                        rowno = i + 2;
                        columnno = columnno + "," + "Language*";


                    }
                }
                else
                {
                    errormsg = errormsg + "," + "Enter Language";

                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Language*";


                }

                if (ds_language.Tables[0].Rows[i]["Read"].ToString().Trim() != "")
                {
                }
                else
                {
                    errormsg = errormsg + "," + "Enter Read Specification True (or)False";

                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Read";


                }
                if (ds_language.Tables[0].Rows[i]["Write"].ToString().Trim() != "")
                {
                }
                else
                {
                    errormsg = errormsg + "," + "Enter Write Specification True (or)False";
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Write";


                }
                if (ds_language.Tables[0].Rows[i]["Speak"].ToString().Trim() != "")
                {
                }
                else
                {
                    errormsg = errormsg + "," + "Enter Speak Specification True (or)False";
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Speak";


                }
                if (ds_language.Tables[0].Rows[i]["Understand"].ToString().Trim() != "")
                {
                }
                else
                {
                    errormsg = errormsg + "," + "Enter Understand Specification True (or)False";
                    filestatus = false;
                    rowno = i + 2;
                    columnno = columnno + "," + "Understand";


                }
                if (filestatus == false)
                {
                    DataRow newrow = dtfail_language.NewRow();
                    newrow["S.NO"] = dtfail_language.Rows.Count + 1;


                    newrow["ROWNO"] = rowno;
                    newrow["COLUMNS NAMES"] = columnno;
                    dtfail_language.Rows.Add(newrow);
                    ds_language.Tables[0].Rows[i]["Error Message"] = errormsg;
                }
            }





            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

            if (dtfail_personal.Rows.Count > 0 || dtfail_Qualification.Rows.Count > 0 || dtfail_Skills.Rows.Count > 0 || dtfail_experiance.Rows.Count > 0 || dtfail_contacts.Rows.Count > 0 || dtfail_language.Rows.Count > 0)
            {
                Session["dt_fail_per"] = dtfail_personal;
                Session["ds_data_per"] = ds_personal;

                Session["DT_FAIL_QUALI"] = dtfail_Qualification;
                Session["DT_DATA_QUALI"] = ds_Qualification;

                Session["DT_FAIL_SKILLS"] = dtfail_Skills;
                Session["DT_DATA_SKILLS"] = ds_skills;

                Session["DT_FAIL_EXPERIANCE"] = dtfail_experiance;
                Session["DT_DATA_EXPERIANCE"] = ds_experiance;

                Session["DT_FAIL_CONTACT"] = dtfail_contacts;
                Session["DT_DATA_CONTACT"] = ds_contact;

                Session["DT_FAIL_LANGUAGE"] = dtfail_language;
                Session["DT_DATA_LANGUAGE"] = ds_language;

                Delete_Excel_File();
                //LinkButton lnk_Import_process = (LinkButton)RadPanelBar1.FindItemByValue("AddAttachment").FindControl("lnk_Import_process");
                Telerik.Web.UI.RadWindow newwindow = new Telerik.Web.UI.RadWindow();
                // RWM_POSTREPLY.Windows.Remove(newwindow);
                newwindow.ID = "RadWindow_import";

                newwindow.NavigateUrl = "~/Recruitment/Applicanterror.aspx";
                newwindow.Title = "Import Process";
                newwindow.Width = 1150;
                newwindow.Height = 580;
                newwindow.VisibleOnPageLoad = true;
                if (RWM_POSTREPLY1.Windows.Count > 1)
                {
                    RWM_POSTREPLY1.Windows.RemoveAt(1);
                }
                RWM_POSTREPLY1.Windows.Add(newwindow);



                RWM_POSTREPLY1.Visible = true;
                return;

            }

//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

            else
            {
                ds_personal.Tables[0].Columns.Add("ApplicantID");

                for (int i = 0; i < ds_personal.Tables[0].Rows.Count; i++)
                {
                    _obj_smhr_applicant = new SMHR_APPLICANT();
                    bool status = false;
                    getCode();
                    _obj_smhr_applicant.OPERATION = operation.Insert1;
                    _obj_smhr_applicant.APPLICANT_CODE = aplicantcode;
                    _obj_smhr_applicant.APPLICANT_TITLE = Convert.ToString(ds_personal.Tables[0].Rows[i]["Title*"]).Trim();
                    _obj_smhr_applicant.APPLICANT_FIRSTNAME = (Convert.ToString(ds_personal.Tables[0].Rows[i]["First Name*"]).Replace("'", "''"));
                    _obj_smhr_applicant.APPLICANT_MIDDLENAME = (Convert.ToString(ds_personal.Tables[0].Rows[i]["Middle Name"]).Replace("'", "''"));
                    _obj_smhr_applicant.APPLICANT_LASTNAME = (Convert.ToString(ds_personal.Tables[0].Rows[i]["Last Name"]).Replace("'", "''"));
                    _obj_smhr_applicant.APPLI_DOB = Convert.ToString(ds_personal.Tables[0].Rows[i]["Date of Birth*(DD/MM/YYYY)"]);
                    // _obj_smhr_applicant.APPLICANT_DOB = Convert.ToDateTime(ds.Tables[0].Rows[i]["Date of Birth*(MM/DD/YYYY)"]);
                    _obj_smhr_applicant.APPLICANT_GENDER = Convert.ToString(ds_personal.Tables[0].Rows[i]["Gender*"]).Trim();
                    _obj_smhr_applicant.APPLICANT_BLOODGROUP = Convert.ToString(ds_personal.Tables[0].Rows[i]["Blood Group*"]).Trim();


                    SMHR_MASTERS _Obj_smhr_Masters = new SMHR_MASTERS();

                    _Obj_smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _Obj_smhr_Masters.MASTER_TYPE = "RELIGION";
                    _Obj_smhr_Masters.OPERATION = operation.Select;

                    _Obj_smhr_Masters.MASTER_CODE = ds_personal.Tables[0].Rows[i]["Religion*"].ToString().Trim();
                    DataTable dt_relig1 = BLL.get_Applicant_Validate(_Obj_smhr_Masters);


                    _obj_smhr_applicant.APPLICANT_RELIGION_ID = Convert.ToInt32(dt_relig1.Rows[0]["HR_MASTER_ID"]);


                    _Obj_smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _Obj_smhr_Masters.MASTER_TYPE = "NATIONALITY";
                    _Obj_smhr_Masters.OPERATION = operation.Select;
                    _Obj_smhr_Masters.MASTER_CODE = ds_personal.Tables[0].Rows[i]["Nationality*"].ToString().Trim();
                    DataTable dt_nationality = BLL.get_Applicant_Validate(_Obj_smhr_Masters);

                    _obj_smhr_applicant.APPLICANT_NATIONALITY_ID = Convert.ToInt32(dt_nationality.Rows[0]["HR_MASTER_ID"]);
                    _obj_smhr_applicant.APPLICANT_STATUS = Convert.ToString(ds_personal.Tables[0].Rows[i]["Status*"]).Trim();
                    _obj_smhr_applicant.APPLICANT_MARITALSTATUS = Convert.ToString(ds_personal.Tables[0].Rows[i]["Marital Status"]).Trim();
                    _obj_smhr_applicant.APPLICANT_ADDRESS = Convert.ToString(ds_personal.Tables[0].Rows[i]["Address"]);
                    _obj_smhr_applicant.APPLICANT_REMARKS = Convert.ToString(ds_personal.Tables[0].Rows[i]["Remarks"]);
                    _obj_smhr_applicant.APPLICANT_TYPE = string.Empty;
                    _obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_applicant.APPLICANT_CREATEDBY = Convert.ToString(Session["USER_ID"]);
                    _obj_smhr_applicant.APPLICANT_CREATEDDATE = DateTime.Now;
                    status = BLL.set_Applicant(_obj_smhr_applicant);

                    _obj_smhr_applicant.OPERATION = operation.Get;
                    DataTable dt_apid = BLL.get_Applicant(_obj_smhr_applicant);

                    int Applicid = Convert.ToInt32(dt_apid.Rows[0]["applicant_id"]);

                    ds_personal.Tables[0].Rows[i]["ApplicantID"] = Applicid;


                }
                ////inserting Qualification details in to database
                for (int i = 0; i < ds_Qualification.Tables[0].Rows.Count; i++)
                {

                    bool status = false;
                    // columnno = string.Empty;
                    int applicant_id = 0;
                    if (ds_Qualification.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() != "")
                    {
                        bool status_qualification = false;


                        for (int j = 0; j < ds_personal.Tables[0].Rows.Count; j++)
                        {
                            if (ds_Qualification.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() == ds_personal.Tables[0].Rows[j]["Applicant SNO*"].ToString().Trim())
                            {
                                status_qualification = true;
                                applicant_id = Convert.ToInt32(ds_personal.Tables[0].Rows[j]["ApplicantID"]);

                                break;

                            }

                        }
                        if (status_qualification == true)
                        {

                            SMHR_MASTERS _Obj_smhr_Masters = new SMHR_MASTERS();
                            _Obj_smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _Obj_smhr_Masters.OPERATION = operation.Select;
                            _Obj_smhr_Masters.MASTER_TYPE = "QUALIFICATION";
                            _Obj_smhr_Masters.MASTER_CODE = ds_Qualification.Tables[0].Rows[i]["Category*"].ToString().Trim();
                            DataTable dt_Quali = BLL.get_Applicant_Validate(_Obj_smhr_Masters);
                            _obj_smhr_applicant.APPLICANT_ID = applicant_id;

                            _obj_smhr_applicant.APPQFN_QUALIFICATION_ID = Convert.ToInt32(Convert.ToString(dt_Quali.Rows[0]["HR_MASTER_ID"]));
                            _obj_smhr_applicant.APPQFN_INSTITUTE = Convert.ToString(ds_Qualification.Tables[0].Rows[i]["Institute*"].ToString().Trim());
                            _obj_smhr_applicant.APPQFN_PASSEDYEAR = Convert.ToInt32(Convert.ToString(ds_Qualification.Tables[0].Rows[i]["Year of pass*"].ToString().Trim()));
                            _obj_smhr_applicant.APPQFN_PERCENTAGE = Convert.ToInt32(Convert.ToString(ds_Qualification.Tables[0].Rows[i]["Percentage*"].ToString().Trim()));
                            _obj_smhr_applicant.APPQFN_GRADE = Convert.ToString(ds_Qualification.Tables[0].Rows[i]["Grade*"].ToString().Trim());
                            _obj_smhr_applicant.APPQFN_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                            _obj_smhr_applicant.APPQFN_CREATEDDATE = DateTime.Now;
                            _obj_smhr_applicant.OPERATION = operation.Insert;
                            status = BLL.set_AppQualification(_obj_smhr_applicant);

                        }


                    }
                }
                //// inserting skills data into database from excel

                for (int i = 0; i < ds_skills.Tables[0].Rows.Count; i++)
                {

                    bool status = false;
                    // columnno = string.Empty;
                    int applicant_id = 0;

                    if (ds_skills.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() != "")
                    {
                        bool status_skills = false;

                        for (int j = 0; j < ds_personal.Tables[0].Rows.Count; j++)
                        {
                            if (ds_skills.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() == ds_personal.Tables[0].Rows[j]["Applicant SNO*"].ToString().Trim())
                            {
                                status_skills = true;
                                applicant_id = Convert.ToInt32(ds_personal.Tables[0].Rows[j]["ApplicantID"]);

                                break;

                            }
                        }

                        if (status_skills == true)
                        {

                            SMHR_MASTERS _Obj_smhr_Masters = new SMHR_MASTERS();

                            _Obj_smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _Obj_smhr_Masters.MASTER_TYPE = "SKILL";
                            _Obj_smhr_Masters.OPERATION = operation.Select;

                            _Obj_smhr_Masters.MASTER_CODE = ds_skills.Tables[0].Rows[i]["Skill Name*"].ToString().Trim();
                            DataTable dt_skill1 = BLL.get_Applicant_Validate(_Obj_smhr_Masters);

                            _obj_smhr_applicant.APPLICANT_ID = applicant_id;

                            _obj_smhr_applicant.APPSKL_SKILL_ID = Convert.ToInt32(dt_skill1.Rows[0]["HR_MASTER_ID"]);

                            _obj_smhr_applicant.APPSKL_LASTUSED = Convert.ToInt32(ds_skills.Tables[0].Rows[i]["Last Used*"]);
                            _obj_smhr_applicant.OPERATION = operation.Insert;
                            _obj_smhr_applicant.APPSKL_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                            _obj_smhr_applicant.APPSKL_CREATEDDATE = DateTime.Now;
                            if (ds_skills.Tables[0].Rows[i]["Expertise*"].ToString().Trim() != "")
                            {
                                if (ds_skills.Tables[0].Rows[i]["Expertise*"].ToString().Trim() == "Beginner")
                                {
                                    _obj_smhr_applicant.APPSKL_EXPERT = 1;
                                }
                                else if (ds_skills.Tables[0].Rows[i]["Expertise*"].ToString().Trim() == "Intermediate")
                                {
                                    _obj_smhr_applicant.APPSKL_EXPERT = 2;
                                }
                                else if (ds_skills.Tables[0].Rows[i]["Expertise*"].ToString().Trim() == "Expert")
                                {
                                    _obj_smhr_applicant.APPSKL_EXPERT = 3;

                                }
                            }

                            status = BLL.set_ApplicantSkills(_obj_smhr_applicant);

                        }


                    }
                }

                ////inserting experiance data into database from excel

                for (int i = 0; i < ds_experiance.Tables[0].Rows.Count; i++)
                {
                    bool status = false;
                    // columnno = string.Empty;
                    int applicant_id = 0;
                    if (ds_experiance.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() != "")
                    {

                        bool status_experience = false;

                        for (int j = 0; j < ds_personal.Tables[0].Rows.Count; j++)
                        {
                            if (ds_experiance.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() == ds_personal.Tables[0].Rows[j]["Applicant SNO*"].ToString().Trim())
                            {
                                status_experience = true;
                                applicant_id = Convert.ToInt32(ds_personal.Tables[0].Rows[j]["ApplicantID"]);

                                break;

                            }
                        }
                        if (status_experience == true)
                        {

                            _obj_smhr_applicant.APPLICANT_ID = applicant_id;
                            _obj_smhr_applicant.APPEXP_APPLICANT_ID = applicant_id;
                            _obj_smhr_applicant.OPERATION = operation.Check_New;
                            DataTable dt_serial = BLL.get_ApplicantExperience(_obj_smhr_applicant);
                            _obj_smhr_applicant.APPEXP_SERIAL = Convert.ToInt32(dt_serial.Rows[0]["APPEXP_SERIAL"]) + 1;//get the number
                            _obj_smhr_applicant.APPEXP_COMPANY = Convert.ToString(ds_experiance.Tables[0].Rows[i]["Company Name*"].ToString().Trim()).Replace("'", "''");
                            // _obj_smhr_applicant.APPEXP_JOINDATE = Convert.ToDateTime(ds_experiance.Tables[0].Rows[i]["Joining Date*(DD/MM/YYYY)"]);
                            if (Convert.ToString(ds_experiance.Tables[0].Rows[i]["Joining Date*(DD/MM/YYYY)"]).Contains("."))
                            {
                                _obj_smhr_applicant.APPEXJOINDATE = Convert.ToString(ds_experiance.Tables[0].Rows[i]["Joining Date*(DD/MM/YYYY)"]).Replace(".", "/");

                            }
                            else
                            {
                                _obj_smhr_applicant.APPEXJOINDATE = Convert.ToString(ds_experiance.Tables[0].Rows[i]["Joining Date*(DD/MM/YYYY)"]);

                            }
                            _obj_smhr_applicant.APPEXP_JOINSAL = Convert.ToDouble(ds_experiance.Tables[0].Rows[i]["Join Salary*"]);
                            _obj_smhr_applicant.APPEXP_JOINDESC = Convert.ToString(ds_experiance.Tables[0].Rows[i]["Join Position*"].ToString().Trim()).Replace("'", "''");
                            _obj_smhr_applicant.APPEXP_REASONREL = Convert.ToString(ds_experiance.Tables[0].Rows[i]["Reason For Relieving*"].ToString().Trim()).Replace("'", "''");
                            // _obj_smhr_applicant.APPEXP_RELDATE = Convert.ToDateTime(ds_experiance.Tables[0].Rows[i]["Relieving Date*(DD/MM/YYYY)"]);
                            if (Convert.ToString(ds_experiance.Tables[0].Rows[i]["Relieving Date*(DD/MM/YYYY)"]).Contains("."))
                            {
                                _obj_smhr_applicant.APPEXRELDATE = Convert.ToString(ds_experiance.Tables[0].Rows[i]["Relieving Date*(DD/MM/YYYY)"]).Replace(".", "/");

                            }
                            else
                            {
                                _obj_smhr_applicant.APPEXRELDATE = Convert.ToString(ds_experiance.Tables[0].Rows[i]["Relieving Date*(DD/MM/YYYY)"]);

                            }
                            _obj_smhr_applicant.APPEXP_RELSAL = Convert.ToDouble(ds_experiance.Tables[0].Rows[i]["Relieving Salary*"]);
                            _obj_smhr_applicant.APPEXP_REASONDESC = Convert.ToString(ds_experiance.Tables[0].Rows[i]["Relieving Position*"].ToString().Trim()).Replace("'", "''");
                            _obj_smhr_applicant.APPEXP_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                            _obj_smhr_applicant.APPEXP_CREATEDDATE = DateTime.Now;
                            _obj_smhr_applicant.OPERATION = operation.Insert1;
                            status = BLL.set_ApplicantExperience(_obj_smhr_applicant);
                        }
                    }
                }
                ////Inserting Applicant contact data fron excel to database

                for (int i = 0; i < ds_contact.Tables[0].Rows.Count; i++)
                {
                    bool status = false;
                    // columnno = string.Empty;
                    int applicant_id = 0;
                    if (ds_contact.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() != "")
                    {

                        bool status_contact = false;

                        for (int j = 0; j < ds_personal.Tables[0].Rows.Count; j++)
                        {
                            if (ds_contact.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() == ds_personal.Tables[0].Rows[j]["Applicant SNO*"].ToString().Trim())
                            {
                                status_contact = true;
                                applicant_id = Convert.ToInt32(ds_personal.Tables[0].Rows[j]["ApplicantID"]);

                                break;

                            }
                        }
                        if (status_contact == true)
                        {
                            _obj_smhr_applicant.APPLICANT_ID = applicant_id;


                            _obj_smhr_applicant.APPCONT_COMPANY = (Convert.ToString(ds_contact.Tables[0].Rows[i]["Company Name*"]).Replace("'", "''"));
                            _obj_smhr_applicant.APPCONT_CONTACT = (Convert.ToString(ds_contact.Tables[0].Rows[i]["Contact Person*"]).Replace("'", "''"));
                            _obj_smhr_applicant.APPCONT_PHONE = (Convert.ToString(ds_contact.Tables[0].Rows[i]["Phone Number*"]).Replace("'", "''"));
                            _obj_smhr_applicant.APPCONT_ADDRESS = (Convert.ToString(ds_contact.Tables[0].Rows[i]["Address*"]).Replace("'", "''"));
                            _obj_smhr_applicant.APPCONT_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                            _obj_smhr_applicant.APPCONT_CREATEDDATE = DateTime.Now;
                            _obj_smhr_applicant.OPERATION = operation.Check_New;
                            DataTable dt_serialno = BLL.get_ApplicantContact(_obj_smhr_applicant);

                            _obj_smhr_applicant.APPCONT_SERIAL = (Convert.ToInt32(dt_serialno.Rows[0]["APPCONT_SERIAL"])) + 1;


                            _obj_smhr_applicant.OPERATION = operation.Insert;

                            status = BLL.set_ApplicantContact(_obj_smhr_applicant);
                        }

                    }
                }


                ////Inserting Language  data fron excel to database

                for (int i = 0; i < ds_language.Tables[0].Rows.Count; i++)
                {
                    bool status = false;
                    // columnno = string.Empty;
                    int applicant_id = 0;
                    if (ds_language.Tables[0].Rows[i]["APPlicant SNO*"].ToString().Trim() != "")
                    {

                        bool status_language = false;

                        for (int j = 0; j < ds_personal.Tables[0].Rows.Count; j++)
                        {
                            if (ds_language.Tables[0].Rows[i]["Applicant SNO*"].ToString().Trim() == ds_personal.Tables[0].Rows[j]["Applicant SNO*"].ToString().Trim())
                            {
                                status_language = true;
                                applicant_id = Convert.ToInt32(ds_personal.Tables[0].Rows[j]["ApplicantID"]);

                                break;

                            }
                        }

                        if (status_language == true)
                        {
                            _obj_smhr_applicant.APPLICANT_ID = applicant_id;
                            SMHR_MASTERS _Obj_smhr_Masters = new SMHR_MASTERS();

                            _Obj_smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _Obj_smhr_Masters.OPERATION = operation.Select;
                            _Obj_smhr_Masters.MASTER_TYPE = "LANGUAGE";
                            _Obj_smhr_Masters.MASTER_CODE = ds_language.Tables[0].Rows[i]["Language*"].ToString().Trim();
                            DataTable dt_nat = BLL.get_Applicant_Validate(_Obj_smhr_Masters);

                            _obj_smhr_applicant.APPLAN_LANGUAGE_ID = Convert.ToInt32(dt_nat.Rows[0]["HR_MASTER_ID"]);

                            _obj_smhr_applicant.APPLAN_READ = Convert.ToBoolean(ds_language.Tables[0].Rows[i]["Read"]);
                            _obj_smhr_applicant.APPLAN_SPEAK = Convert.ToBoolean(ds_language.Tables[0].Rows[i]["Speak"]);
                            _obj_smhr_applicant.APPLAN_UNDERSTAND = Convert.ToBoolean(ds_language.Tables[0].Rows[i]["Understand"]);
                            _obj_smhr_applicant.APPLAN_WRITE = Convert.ToBoolean(ds_language.Tables[0].Rows[i]["Write"]);
                            _obj_smhr_applicant.APPLAN_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                            _obj_smhr_applicant.APPLAN_CREATEDDATE = DateTime.Now;
                            _obj_smhr_applicant.OPERATION = operation.Insert;

                            status = BLL.set_ApplicantLanguage(_obj_smhr_applicant);


                        }
                    }
                }
                BLL.ShowMessage(this, "Successfully processed Excel file.");

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmapplicant", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
