using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SMHR;
using System.IO;
using System.Data.OleDb;
using Telerik.Web.UI;

public partial class Masters_frm_VariablepayComponents : System.Web.UI.Page
{
    #region References
    /// <summary>
    /// This Region will consists of classes and there 
    /// instances which were used in thorughout the form
    /// </summary>
    DataTable dt_Result = new DataTable();
    DataTable dt_Null = null;
    static string componentid = "";
    DataSet ds = new DataSet();
    SMHR_VARIABLEAMT _obj_vpc = new SMHR_VARIABLEAMT();
    string strfilename2;
    #endregion

    #region Page Load
    /// <summary>
    /// This Region will Load the Grid 
    /// which will have information about the components
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (RWM_POSTREPLY1.Windows.Count > 0)
            {
                RWM_POSTREPLY1.Windows.RemoveAt(0);
            }
            if (!IsPostBack)
            {

                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Components Creation");
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
                    rg_VariablepayComponents.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Save.Visible = false;
                    btn_Update.Visible = false;
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
                LoadGrid();
                rg_VariablepayComponents.DataBind();
                btn_Save.Visible = false;
                btn_Update.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_VariablepayComponents", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    #region Load Methods
    /// <summary>
    ///  This Region contains the methods which consists 
    ///  loading combo boxes and grid
    /// </summary>
    protected void LoadGrid()
    {
        try
        {
            _obj_vpc.OPERATION = operation.Select;
            _obj_vpc.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Result = BLL.Get_Components(_obj_vpc);
            // FOR DISPLAYING THE COMPONETS THAT ARE AVAILABLE IN ORG
            if (dt_Result.Rows.Count > 0)
                rg_VariablepayComponents.DataSource = dt_Result;
            else
                rg_VariablepayComponents.DataSource = dt_Result;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_VariablepayComponents", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void rg_VariablepayComponents_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_VariablepayComponents", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    /// <summary>
    /// for clearing the controls
    /// </summary>
    protected void ClearControls()
    {
        try
        {
            rntxt_Max.Text = string.Empty;
            rntxt_Min.Text = string.Empty;
            txt_Componentdesc.Text = string.Empty;
            txt_Componentname.Text = string.Empty;
            // chk_Status.Checked = false;
            rcmb_Status.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_VariablepayComponents", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    #region Page Redirect
    /// <summary>
    /// this will Transfer the control from one page to other page
    /// in the multipage
    /// </summary>    
    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            ClearControls();// for reseting the values
            RMP_VariablepayComponents.SelectedIndex = 1;
            rcmb_Status.SelectedIndex = 0;
            btn_Save.Visible = true;
            btn_Update.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_VariablepayComponents", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            _obj_vpc.component_id = Convert.ToInt32(e.CommandArgument);
            componentid = Convert.ToString(_obj_vpc.component_id);
            _obj_vpc.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_vpc.OPERATION = operation.Select;
            dt_Result = BLL.Get_Components(_obj_vpc);
            if (dt_Result.Rows.Count > 0)
            {
                txt_Componentdesc.Text = Convert.ToString(dt_Result.Rows[0]["SMHR_VPCOMP_COMPDESC"]);
                txt_Componentname.Text = Convert.ToString(dt_Result.Rows[0]["SMHR_VPCOMP_COMPNAME"]);
                rntxt_Max.Text = Convert.ToString(dt_Result.Rows[0]["SMHR_VPCOMP_MAX"]);
                rntxt_Min.Text = Convert.ToString(dt_Result.Rows[0]["SMHR_VPCOMP_MIN"]);
                if (Convert.ToString(dt_Result.Rows[0]["SMHR_VPCOMP_COMPSTATUS"]) != string.Empty)
                {
                    //chk_Status.Checked = Convert.ToBoolean(dt_Result.Rows[0]["SMHR_VPCOMP_COMPSTATUS"]);
                    int Status = Convert.ToInt32(dt_Result.Rows[0]["SMHR_VPCOMP_COMPSTATUS"]);
                    rcmb_Status.SelectedIndex = rcmb_Status.FindItemIndexByValue(Convert.ToString(Status));
                }

                //chk_Status.Checked = false;
                btn_Update.Visible = true;
                btn_Save.Visible = false;
                RMP_VariablepayComponents.SelectedIndex = 1;
            }
            else
            {
                BLL.ShowMessage(this, "Error is Occured During The Process");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_VariableComponents", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    #endregion

    #region Button Clicks
    /// <summary>
    /// This Region will consists of all operations related to button clicks
    /// </summary>

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToDouble(rntxt_Max.Text) > Convert.ToDouble(rntxt_Min.Text))
            {
                bool status = false;
                _obj_vpc.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_vpc.component_desc = BLL.ReplaceQuote(txt_Componentdesc.Text);
                _obj_vpc.component_name = BLL.ReplaceQuote(txt_Componentname.Text);
                _obj_vpc.component_max = Convert.ToDouble(rntxt_Max.Text);
                _obj_vpc.component_min = Convert.ToDouble(rntxt_Min.Text);
                int Status = Convert.ToInt32(rcmb_Status.SelectedItem.Value);
                _obj_vpc.component_status = Convert.ToBoolean(Status);
                _obj_vpc.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_vpc.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                switch (((Button)sender).ID)
                {
                    case "btn_Save":
                        _obj_vpc.OPERATION = operation.Select2;
                        DataTable Dt_exist = BLL.Get_Components(_obj_vpc);
                        if (Convert.ToInt32(Dt_exist.Rows[0][0]) > 0)
                        {
                            BLL.ShowMessage(this, "This Component is Already Exist");
                            return;
                        }
                        _obj_vpc.OPERATION = operation.Insert;
                        status = BLL.set_Component(_obj_vpc);
                        if (status)
                            BLL.ShowMessage(this, "Information Saved Successfully");
                        else
                            BLL.ShowMessage(this, "Error Occured");
                        LoadGrid();
                        rg_VariablepayComponents.DataBind();
                        RMP_VariablepayComponents.SelectedIndex = 0;
                        break;

                    case "btn_Update":
                        _obj_vpc.OPERATION = operation.Update;
                        _obj_vpc.component_id = Convert.ToInt32(componentid);
                        status = BLL.set_Component(_obj_vpc);
                        if (status)
                            BLL.ShowMessage(this, "Information Updated Successfully");
                        else
                            BLL.ShowMessage(this, "Error Occured");

                        _obj_vpc.component_id = 0;
                        LoadGrid();
                        rg_VariablepayComponents.DataBind();
                        RMP_VariablepayComponents.SelectedIndex = 0;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                BLL.ShowMessage(this, "Max Percentage Should Be Greater than Min Percentage");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_VariableComponents", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            ClearControls();
            LoadGrid();
            rg_VariablepayComponents.DataBind();
            RMP_VariablepayComponents.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_VariablepayComponents", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion


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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_VariablepayComponents", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string strcon = null;

            string strfilename1 = FileUpload1.FileName;
            strfilename2 = Convert.ToString(DateTime.Now.TimeOfDay) + "_" + strfilename1;
            strfilename2 = strfilename2.Replace("/", "").Replace(":", ".");
            if (FileUpload1.HasFile)
            {
                if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == false)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath("~/IMPORT_EXCEL/"));
                }
                FileUpload1.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/IMPORT_EXCEL/"), strfilename2));
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
                sheetname = Convert.ToString(dt_chk2.Rows[0]["TABLE_NAME"]);
            }
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM  [" + sheetname + "]", strcon);



            da.Fill(ds);
            ds.Tables[0].Columns.Add("Error Message");

            objConn.Close();
            DataTable dt = new DataTable();
            DataTable dtfail = new DataTable();


            string errormsg = string.Empty;

            string projecttype = null;
            Int32 rowno = 0;

            DateTime dat;
            string columnno = null;
            string projname = null;
            Boolean filestatus = true;
            dtfail.Columns.Add("S.NO", typeof(Int32));
            dtfail.Columns.Add("ROWNO", typeof(Int32));
            dtfail.Columns.Add("COLUMNS NAMES", typeof(string));

            if (ds.Tables[0].Columns[0].ToString().Trim() == "Component Name*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[1].ToString().Trim() == "Component Description")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[2].ToString().Trim() == "Status")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[3].ToString().Trim() == "Minimum Percentage*")
            {
            }
            else
            {
                Delete_Excel_File();
                BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
                return;
            }
            if (ds.Tables[0].Columns[4].ToString().Trim() == "Max Percentage*")
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
                errormsg = string.Empty;
                columnno = string.Empty;
                if (ds.Tables[0].Rows[i]["Component Name*"].ToString().Trim() != "")
                {


                }
                else
                {
                    errormsg = "enter component name";
                    filestatus = false;
                    rowno = i + 2;
                    columnno = "Component Name*";

                }
                for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                {
                    if (ds.Tables[0].Rows[i]["Component Name*"].ToString().Trim() == ds.Tables[0].Rows[k]["Component Name*"].ToString().Trim())
                    {
                        if (i != k)
                        {
                            errormsg = errormsg + "," + "Component Name with this Name is repeated in Excel Sheet";
                            filestatus = false;
                            rowno = i + 2;
                            columnno = "Component Name*";
                        }
                    }
                }
                if (ds.Tables[0].Rows[i]["Minimum Percentage*"].ToString().Trim() != "")
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[i]["Minimum Percentage*"]) < 1000)
                    {
                    }
                    else
                    {
                        errormsg = errormsg + "," + "Minimum Percentage should be three digits only";
                        filestatus = false;
                        rowno = i + 2;
                        columnno = "Minimum Percentage*";

                    }

                }
                else
                {
                    errormsg = errormsg + "," + "Enter Minimum Percentage";
                    filestatus = false;
                    rowno = i + 2;
                    columnno = "Minimum Percentage*";

                }
                for (int p = 0; p < ds.Tables[0].Rows.Count; p++)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[i]["Minimum Percentage*"]) < Convert.ToInt32(ds.Tables[0].Rows[p]["Max Percentage*"]))
                    {
                        //if (i != p)
                        //{
                        //    errormsg = errormsg + "," + "Minimum Percentage should be less than Max percentage";
                        //    filestatus = false;
                        //    rowno = i + 2;
                        //    columnno = "Component Name*";
                        //}
                    }
                    else
                    {
                        errormsg = errormsg + "," + "Minimum Percentage should be less than Max percentage";
                        filestatus = false;
                        rowno = i + 2;
                        columnno = "Minimum Percentage*";
                    }
                }

                if (ds.Tables[0].Rows[i]["Max Percentage*"].ToString().Trim() != "")
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[i]["Max Percentage*"]) < 1000)
                    {
                    }
                    else
                    {
                        errormsg = errormsg + "," + "Max Percentage should be three digits only";
                        filestatus = false;
                        rowno = i + 2;
                        columnno = "Max Percentage*";

                    }

                }
                else
                {
                    errormsg = errormsg + "," + "Enter Max Percentage";
                    filestatus = false;
                    rowno = i + 2;
                    columnno = "Max Percentage*";

                }
                if (filestatus == false)
                {
                    DataRow newrow = dtfail.NewRow();
                    newrow["S.NO"] = dtfail.Rows.Count + 1;


                    newrow["ROWNO"] = rowno;
                    newrow["COLUMNS NAMES"] = columnno;
                    dtfail.Rows.Add(newrow);
                    ds.Tables[0].Rows[i]["Error Message"] = errormsg;
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
                bool status = false;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {



                    _obj_vpc.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_vpc.component_desc = Convert.ToString(ds.Tables[0].Rows[i]["Component Description"]).Trim();
                    _obj_vpc.component_name = Convert.ToString(ds.Tables[0].Rows[i]["Component Name*"]).Trim();
                    _obj_vpc.component_max = Convert.ToInt32(ds.Tables[0].Rows[i]["Max Percentage*"]);
                    _obj_vpc.component_min = Convert.ToInt32(ds.Tables[0].Rows[i]["Minimum Percentage*"]);

                    if (ds.Tables[0].Rows[i]["Status"].ToString() == "")
                    {
                        _obj_vpc.component_status = false;
                    }
                    else
                    {

                        _obj_vpc.component_status = Convert.ToBoolean(ds.Tables[0].Rows[i]["Status"]);
                    }
                    _obj_vpc.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_vpc.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_vpc.OPERATION = operation.Insert;
                    status = BLL.set_Component(_obj_vpc);
                    //if (status)
                    //    BLL.ShowMessage(this, "Information Saved Successfully");
                    //else
                    //    BLL.ShowMessage(this, "Error Occured");
                    //LoadGrid();
                    //rg_VariablepayComponents.DataBind();


                }

                if (status)
                    BLL.ShowMessage(this, "Information Saved Successfully");

                LoadGrid();
                rg_VariablepayComponents.DataBind();
            }



        }
        //
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_VariableComponents", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }


}
