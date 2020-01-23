using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Data;
using Telerik.Web.UI;
using System.IO;
using System.Data.OleDb;
using System.Configuration;
using System.Collections;

public partial class Masters_frm_Department : System.Web.UI.Page
{
    protected SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit;
    static string lbl_DID = "";
    protected SMHR_DEPARTMENT _obj_smhr_Department;
    SMHR_DIRECTORATE _obj_Smhr_Directorate;
    string strfilename2;
    DataSet ds = new DataSet();
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
       
        
        try
        {

            if (RWM_DEPARTMENT.Windows.Count > 0)
            {
                RWM_DEPARTMENT.Windows.RemoveAt(0);
            }
            if (!IsPostBack)
            {




                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("DEPARTMENT");
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
                    Rg_Department.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Save.Visible = false;
                    btn_Edit.Visible = false;
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

                Page.Validate();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Department", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    
    protected void LoadCombos()
    {
        try
        {
            SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
            _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"].ToString());
            rcmb_BusinessUnit.Items.Clear();
            rcmb_BusinessUnit.DataSource = BLL.get_Business_Units(_obj_smhr_logininfo);
            rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BusinessUnit.DataBind();
            rcmb_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            //rcmb_BusinessUnit_Directorate.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));


        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Department", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void LoadMainGrid()
    {
        try
        {
            _obj_smhr_Department = new SMHR_DEPARTMENT();
            _obj_smhr_Department.MODE = 5;
            _obj_smhr_Department.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            Rg_Department.DataSource = BLL.get_Department(_obj_smhr_Department);
            Rm_HDPT_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Department", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            rcmb_Status.Enabled = true;
            rtxt_DCode.Enabled = false;
            LoadCombos();
            _obj_smhr_Department = new SMHR_DEPARTMENT();
            DataTable dt_Values = new DataTable();
            _obj_smhr_Department.MODE = 6;
            _obj_smhr_Department.DEPARTMENT_ID = Convert.ToInt32(e.CommandArgument);
            dt_Values = BLL.get_Department(_obj_smhr_Department);
            lbl_depID.Text = Convert.ToString(dt_Values.Rows[0]["DEPARTMENT_ID"]);
            //rtbCode.Text = Convert.ToString(dt_Values.Rows[0]["DEPARTMENT_CODE"]);
            rtxt_DName.Text = Convert.ToString(dt_Values.Rows[0]["DEPARTMENT_NAME"]);
            rtxt_DCode.Text = Convert.ToString(dt_Values.Rows[0]["DEPARTMENT_CODE"]);
            rtxt_Desc.Text = Convert.ToString(dt_Values.Rows[0]["DEPARTMENT_DESC"]);
            rcmb_BusinessUnit.SelectedIndex = rcmb_BusinessUnit.Items.FindItemIndexByValue(Convert.ToString(dt_Values.Rows[0]["DEPARTMENT_BUID"]));

            //Load Directorate
            _obj_Smhr_Directorate = new SMHR_DIRECTORATE();
            _obj_Smhr_Directorate.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Directorate.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value.ToString());
            DataTable DT = BLL.get_Directorate(_obj_Smhr_Directorate);
            rcmb_BusinessUnit_Directorate.DataTextField = "DIRECTORATE_CODE";
            rcmb_BusinessUnit_Directorate.DataValueField = "DIRECTORATE_ID";
            rcmb_BusinessUnit_Directorate.DataSource = DT;
            rcmb_BusinessUnit_Directorate.DataBind();
            rcmb_BusinessUnit_Directorate.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            rcmb_BusinessUnit_Directorate.SelectedValue = Convert.ToString(dt_Values.Rows[0]["DIRECTORATE_ID"]);
            if (dt_Values.Rows[0]["DEPARTMENT_ISACTIVE"] != System.DBNull.Value)
            {
                int Status = Convert.ToInt32(dt_Values.Rows[0]["DEPARTMENT_ISACTIVE"]);
                rcmb_Status.SelectedIndex = rcmb_Status.Items.FindItemIndexByValue(Convert.ToString(Status));
            }
            else
            {
                //chk_Active.Checked = false;
            }
            //code for security
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Edit.Visible = false;

            }

            else
            {
                btn_Edit.Visible = true;
            }
            //rtbCode.Enabled = false;
            rtxt_DName.Enabled = false;
            rcmb_BusinessUnit.Enabled = false;
            rcmb_BusinessUnit_Directorate.Enabled = false;
            btn_Save.Visible = false;
            Rm_HDPT_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Department", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            LoadCombos();
            clearControls();
            btn_Save.Visible = true;
            btn_Edit.Visible = false;
            rtxt_DName.Enabled = true;
            Rm_HDPT_page.SelectedIndex = 1;
            if (Convert.ToString(Request.QueryString["ID"]) == null)
            {
                rcmb_BusinessUnit.SelectedIndex = 0;
                rcmb_BusinessUnit.Enabled = true;
                rcmb_BusinessUnit_Directorate.Enabled = true;
            }
            else
            {
                rcmb_BusinessUnit.SelectedIndex = rcmb_BusinessUnit.Items.FindItemIndexByValue(Convert.ToString(Request.QueryString["ID"]));
                rcmb_BusinessUnit.Enabled = false;
                rcmb_BusinessUnit_Directorate.Enabled = false;
            }
            rcmb_Status.SelectedIndex = 0;
            rcmb_Status.Enabled = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Department", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Rg_HolidayCalendar_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadMainGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Department", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void clearControls()
    {
        try
        {
            rcmb_BusinessUnit.SelectedIndex = -1;
            rcmb_BusinessUnit_Directorate.Items.Clear();
            rcmb_BusinessUnit_Directorate.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            //rtbCode.Text = string.Empty;
            rtxt_DName.Text = string.Empty;
            rtxt_DCode.Text = string.Empty;
            rtxt_Desc.Text = string.Empty;
            //chk_Active.Checked = false;
            btn_Save.Visible = false;
            btn_Edit.Visible = false;
            Rm_HDPT_page.SelectedIndex = 0;
            rcmb_Status.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Department", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Rg_Department_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadMainGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Department", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Save_Click1(object sender, EventArgs e)  
    {
        try
        {
            _obj_smhr_Department = new SMHR_DEPARTMENT();

            _obj_smhr_Department.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_smhr_Department.BUID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
            _obj_smhr_Department.DIRECTORATE_ID = Convert.ToInt32(rcmb_BusinessUnit_Directorate.SelectedItem.Value);
            //_obj_smhr_Department.DEPARTMENT_CODE = Convert.ToString(rtbCode.Text);
            _obj_smhr_Department.DEPARTMENT_NAME = Convert.ToString(rtxt_DName.Text).Replace("'", "''");
            _obj_smhr_Department.DEPARTMENT_CODE = Convert.ToString(rtxt_DCode.Text).Replace("'","'");
            _obj_smhr_Department.DEPARTMENT_DESC = Convert.ToString(rtxt_Desc.Text).Replace("'", "''");
            int Status = Convert.ToInt32(rcmb_Status.SelectedItem.Value);
            //   if (chk_Active.Checked)
            _obj_smhr_Department.DEPARTMENT_ISACTIVE = Convert.ToBoolean(Status);
            // else
            //_obj_smhr_Department.DEPARTMENT_ISACTIVE = false;
            _obj_smhr_Department.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_Department.CREATEDDATE = DateTime.Now;
            _obj_smhr_Department.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_Department.LASTMDFDATE = DateTime.Now;

            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_SAVE":
                    _obj_smhr_Department.DEPARTMENT_NAME = Convert.ToString(rtxt_DName.Text.Replace("'", "''"));
                    _obj_smhr_Department.BUID = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
                    _obj_smhr_Department.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                    _obj_smhr_Department.MODE = 3;
                    DataTable dt = BLL.get_Department(_obj_smhr_Department);
                    if (dt.Rows.Count != 0)
                    {
                        BLL.ShowMessage(this, "This Department is already created for this Business Unit");
                        rtxt_DName.Text = string.Empty;
                        rtxt_Desc.Text = string.Empty;
                        return;
                    }
                    _obj_smhr_Department.MODE = 1;
                    if (BLL.set_Department(_obj_smhr_Department))
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;

                case "BTN_EDIT":

                    int Exist = 0;
                    _obj_smhr_Department.DEPARTMENT_ID = Convert.ToInt32(lbl_depID.Text);
                    _obj_smhr_Department.DEPARTMENT_NAME = Convert.ToString(rtxt_DName.Text.Replace("'", "''"));

                    if (_obj_smhr_Department.DEPARTMENT_ISACTIVE == false)
                    {
                        _obj_smhr_Department.MODE = 12;
                        Exist = Convert.ToInt32(BLL.get_Department(_obj_smhr_Department).Rows[0]["COUNT"]);
                        if (Exist == 1)
                        {
                            //BLL.ShowMessage(this, "There Are Employee With The Department Name  " + rtxt_DName.Text + "  So You cannot Make this as Inactive!");
                            BLL.ShowMessage(this, " You cannot Inactive Department, As it is already assigned to employee");
                            rcmb_Status.SelectedIndex = 0;
                            //   LoadMainGrid();
                            //  Rg_Department.DataBind();
                            return;
                        }
                    }
                    _obj_smhr_Department.MODE = 2;
                    if (BLL.set_Department(_obj_smhr_Department))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
            }
            Rm_HDPT_page.SelectedIndex = 0;
            LoadMainGrid();
            Rg_Department.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Department", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_Click1(object sender, EventArgs e)
    {
        try
        {
            clearControls();
            Rm_HDPT_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Department", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    //protected void btn_import_Click(object sender, EventArgs e)
    //{
    //    try
    //    {

    //        string strcon = null;

    //        string strfilename1 = fu_department.FileName;
    //        strfilename2 = Convert.ToString(DateTime.Now.TimeOfDay) + "_" + strfilename1;
    //        strfilename2 = strfilename2.Replace("/", "").Replace(":", ".");
    //        if (fu_department.HasFile)
    //        {

    //            if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == false)
    //            {
    //                System.IO.Directory.CreateDirectory(Server.MapPath("~/IMPORT_EXCEL/"));

    //            }



    //            fu_department.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/IMPORT_EXCEL/"), strfilename2));
    //            string filename1 = Server.MapPath("~/IMPORT_EXCEL/") + ("") + (Convert.ToString(strfilename2));
    //            FileInfo fileInfo = new FileInfo(filename1);
    //            if (fileInfo.Exists)
    //            {
    //                string path = MapPath(strfilename1);
    //                // string name = Path.GetFileName( path );
    //                string ext = Path.GetExtension(path);

    //                string type = string.Empty;
    //                //  set known types based on file extension  
    //                if (ext != null)
    //                {
    //                    switch (ext.ToLower())
    //                    {

    //                        case ".xls":

    //                            type = "excel";
    //                            break;
    //                        case ".xlsx":
    //                            type = "excel";
    //                            break;

    //                        default:
    //                            type = string.Empty;
    //                            break;
    //                    }
    //                }
    //                if (type == string.Empty)
    //                {
    //                    if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == true)
    //                    {

    //                        string path1 = Server.MapPath("~/IMPORT_EXCEL/") + ("") + (Convert.ToString(strfilename2));
    //                        System.IO.File.Delete(path1);
    //                    }
    //                    BLL.ShowMessage(this, "Please select the Excel File  (Eg: Excel.xlsx). ");
    //                    return;
    //                }
    //            }
    //        }


    //        else
    //        {
    //            BLL.ShowMessage(this, "Please Select the File to be uploaded");
    //            return;
    //        }

    //        string strpath = Server.MapPath("~/IMPORT_EXCEL/");

    //        strpath = strpath + strfilename2;


    //        // Getting data from excell file to dataset.
    //        strcon = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source='" + strpath + "';" + "Extended Properties=Excel 12.0;";


    //        OleDbConnection objConn = null;
    //        objConn = new OleDbConnection(strcon);
    //        objConn.Open();

    //        DataTable dt_chk2 = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
    //        string sheetname;
    //        if (dt_chk2 == null)
    //        {
    //            objConn.Close();
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        else
    //        {
    //            sheetname = Convert.ToString(dt_chk2.Rows[0]["TABLE_NAME"]);
    //        }
    //        OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM  [" + sheetname + "]", strcon);



    //        da.Fill(ds);

    //        objConn.Close();
    //        DataTable dt = new DataTable();
    //        DataTable dtfail = new DataTable();


    //        string errormsg = string.Empty;

    //        string projecttype = null;
    //        Int32 rowno = 0;


    //        string columnno = null;

    //        Boolean filestatus = true;
    //        dtfail.Columns.Add("S.NO", typeof(Int32));
    //        dtfail.Columns.Add("ROWNO", typeof(Int32));
    //        dtfail.Columns.Add("COLUMNS NAMES", typeof(string));

    //        if (!(ds.Tables[0].Columns[0].ToString().Trim() == "Business Unit*"))
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }

    //        //if (!(ds.Tables[0].Columns[1].ToString().Trim() == "Code*"))
    //        //{
    //        //    Delete_Excel_File();
    //        //    BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //        //    return;
    //        //}

    //        if (!(ds.Tables[0].Columns[2].ToString().Trim() == "Name*"))
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }


    //        if (!(ds.Tables[0].Columns[3].ToString().Trim() == "Description"))
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (!(ds.Tables[0].Columns[4].ToString().Trim() == "Active"))
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (!(ds.Tables[0].Columns[5].ToString().Trim() == "Error Message"))
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds.Tables[0].Rows.Count == 0)
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Successfully processed Excel file. No Records are Imported.");
    //            return;
    //        }
    //        LoadCombos();
    //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //        {

    //            if (ds.Tables[0].Rows[i]["Business Unit*"].ToString().Trim() != "")
    //            {
    //                int bu_id = 0;


    //                for (int count = 0; count < rcmb_BusinessUnit.Items.Count; count++)
    //                {
    //                    if ((ds.Tables[0].Rows[i]["Business Unit*"].ToString().Trim()) == rcmb_BusinessUnit.Items[count].Text)
    //                    {
    //                        bu_id = Convert.ToInt32(rcmb_BusinessUnit.Items[count].Value);

    //                    }

    //                }
    //                if (bu_id == 0)
    //                {
    //                    errormsg = errormsg + "," + "Businessunit with this Name Does not  Exists";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = columnno + "," + "Business Unit*";

    //                }
    //                else
    //                {

    //                    //if (ds.Tables[0].Rows[i]["Code*"].ToString().Trim() != "")
    //                    //{
    //                    //    string bu_code = ds.Tables[0].Rows[i]["Business Unit*"].ToString();
    //                    //    _obj_smhr_Department = new SMHR_DEPARTMENT();
    //                    //    _obj_smhr_Department.OPERATION = operation.MODE;
    //                    //    _obj_smhr_Department.MODE = 10;
    //                    //    _obj_smhr_Department.DEPARTMENT_NAME = ds.Tables[0].Rows[i]["Code*"].ToString().Trim();
    //                    //    _obj_smhr_Department.BUSINESSUNIT_NAME = bu_code;
    //                    //    _obj_smhr_Department.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                    //    DataTable dt_dept_count = BLL.get_Department(_obj_smhr_Department);
    //                    //    if (Convert.ToInt32(dt_dept_count.Rows[0]["COUNT"]) != 0)
    //                    //    {
    //                    //        errormsg = "Businessunit with this Department Code already exists";
    //                    //        filestatus = false;
    //                    //        rowno = i + 2;
    //                    //        columnno = "Code*";
    //                    //    }

    //                    //}
    //                    //else
    //                    //{
    //                    //    filestatus = false;
    //                    //    rowno = i + 2;
    //                    //    columnno = "Code*";
    //                    //}

    //                    if (ds.Tables[0].Rows[i]["Name*"].ToString().Trim() != "")
    //                    {
    //                        string bu_code = ds.Tables[0].Rows[i]["Business Unit*"].ToString();
    //                        _obj_smhr_Department = new SMHR_DEPARTMENT();
    //                        _obj_smhr_Department.OPERATION = operation.MODE;
    //                        _obj_smhr_Department.MODE = 10;
    //                        _obj_smhr_Department.DEPARTMENT_NAME = ds.Tables[0].Rows[i]["Name*"].ToString().Trim();
    //                        _obj_smhr_Department.BUSINESSUNIT_NAME = bu_code;
    //                        _obj_smhr_Department.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                        DataTable dt_dept_count = BLL.get_Department(_obj_smhr_Department);
    //                        if (Convert.ToInt32(dt_dept_count.Rows[0]["COUNT"]) != 0)
    //                        {
    //                            errormsg = "Businessunit with this Department already exists";
    //                            filestatus = false;
    //                            rowno = i + 2;
    //                            columnno = "Name*";
    //                        }

    //                    }
    //                    else
    //                    {
    //                        filestatus = false;
    //                        rowno = i + 2;
    //                        columnno = "Name*";
    //                    }
    //                }

    //            }
    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = "Business Unit*";
    //            }
    //            if ((ds.Tables[0].Rows[i]["Active"].ToString().Trim().ToUpper() != "TRUE") && (ds.Tables[0].Rows[i]["Active"].ToString().Trim().ToUpper() != "FALSE"))
    //            {
    //                errormsg = "You should enter either True or False.";
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = "Active";
    //            }
    //            if (filestatus == false)
    //            {
    //                DataRow newrow = dtfail.NewRow();
    //                newrow["S.NO"] = dtfail.Rows.Count + 1;


    //                newrow["ROWNO"] = rowno;
    //                newrow["COLUMNS NAMES"] = columnno;
    //                dtfail.Rows.Add(newrow);
    //                ds.Tables[0].Rows[i]["Error Message"] = errormsg;
    //            }

    //        }
    //        if (dtfail.Rows.Count > 0)
    //        {
    //            Session["dt_fail"] = dtfail;
    //            Session["ds_data"] = ds;
    //            Delete_Excel_File();
    //            //LinkButton lnk_Import_process = (LinkButton)RadPanelBar1.FindItemByValue("AddAttachment").FindControl("lnk_Import_process");
    //            Telerik.Web.UI.RadWindow newwindow = new Telerik.Web.UI.RadWindow();
    //            // RWM_POSTREPLY.Windows.Remove(newwindow);
    //            newwindow.ID = "RadWindow_import";

    //            newwindow.NavigateUrl = "~/Payroll/frm_AttendanceImportProcess.aspx";
    //            newwindow.Title = "Import Process";
    //            newwindow.Width = 1150;
    //            newwindow.Height = 580;
    //            newwindow.VisibleOnPageLoad = true;
    //            if (RWM_DEPARTMENT.Windows.Count > 1)
    //            {
    //                RWM_DEPARTMENT.Windows.RemoveAt(1);
    //            }
    //            RWM_DEPARTMENT.Windows.Add(newwindow);



    //            RWM_DEPARTMENT.Visible = true;
    //            return;

    //        }
    //        else
    //        {
    //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //            {

    //                _obj_smhr_Department.OPERATION = operation.MODE;
    //                _obj_smhr_Department.MODE = 11;
    //                _obj_smhr_Department.BUSINESSUNIT_NAME = ds.Tables[0].Rows[i]["Business Unit*"].ToString();
    //                _obj_smhr_Department.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                DataTable dt_bu_id = BLL.get_Department(_obj_smhr_Department);
    //                _obj_smhr_Department = new SMHR_DEPARTMENT();
    //                _obj_smhr_Department.MODE = 1;
    //                _obj_smhr_Department.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
    //                _obj_smhr_Department.BUID = Convert.ToInt32(dt_bu_id.Rows[0]["BUSINESSUNIT_ID"]);
    //                //_obj_smhr_Department.DEPARTMENT_CODE = ds.Tables[0].Rows[i]["Code*"].ToString().Trim();
    //                _obj_smhr_Department.DEPARTMENT_NAME = ds.Tables[0].Rows[i]["Name*"].ToString().Trim();
    //                _obj_smhr_Department.DEPARTMENT_DESC = ds.Tables[0].Rows[i]["Description"].ToString().Trim();
    //                if ((ds.Tables[0].Rows[i]["Active"]) != System.DBNull.Value)
    //                {
    //                    _obj_smhr_Department.DEPARTMENT_ISACTIVE = Convert.ToBoolean(ds.Tables[0].Rows[i]["Active"]);
    //                }
    //                else
    //                {
    //                    _obj_smhr_Department.DEPARTMENT_ISACTIVE = false;
    //                }

    //                _obj_smhr_Department.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
    //                _obj_smhr_Department.CREATEDDATE = DateTime.Now;
    //                _obj_smhr_Department.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
    //                _obj_smhr_Department.LASTMDFDATE = DateTime.Now;
    //                if (BLL.set_Department(_obj_smhr_Department))
    //                    BLL.ShowMessage(this, " Successfully processed Excel file.");

    //            }
    //            Rm_HDPT_page.SelectedIndex = 0;
    //            LoadMainGrid();
    //            Rg_Department.DataBind();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Department", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }

    //}

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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Department", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rcmb_BusinessUnit_Directorate.Items.Clear();
            //Load Directorate
            _obj_Smhr_Directorate = new SMHR_DIRECTORATE();
            _obj_Smhr_Directorate.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Directorate.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value.ToString());
            _obj_Smhr_Directorate.OPERATION = operation.Check_Emp;
            DataTable DT = BLL.get_Directorate(_obj_Smhr_Directorate);
            rcmb_BusinessUnit_Directorate.DataTextField = "DIRECTORATE_CODE";
            rcmb_BusinessUnit_Directorate.DataValueField = "DIRECTORATE_ID";
            rcmb_BusinessUnit_Directorate.DataSource = DT;
            rcmb_BusinessUnit_Directorate.DataBind();
            rcmb_BusinessUnit_Directorate.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Department", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}