
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using SMHR;
using Telerik.Web.UI;
using System.IO;
using System.Threading;
using System.Web.SessionState;

public partial class frm_upload : System.Web.UI.Page
{
    string filename = null;
    string filename1 = null;
    string strpath1 = null;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_UPLOAD _obj_smhr_upload;
    smhr_Bonus_trans _obj_bonus_trans;
    string Control;

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (!IsPostBack)
            {
                ViewState["ORG_ID"] = Session["ORG_ID"];
                ViewState["USER_ID"] = Session["USER_ID"];

                //_obj_bonus_trans=new smhr_Bonus_trans();
                //_obj_bonus_trans.OPERATION = operation.Login;
                //_obj_bonus_trans.APPRCYCLE_ID = Convert.ToInt32(Session["EMP_TYPE"]);
                //DataTable dt_login = BLL.Get_SMHR_BONUS_TRANS1(_obj_bonus_trans);
                //if (dt_login.Rows.Count > 0)
                //{
                //    Session["USERNAME"] = Convert.ToString(dt_login.Rows[0]["LOGTYP_CODE"]);
                //}
                Control = Convert.ToString(Request.QueryString["Control"]);


                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();
                if (Control != null)
                {
                    if (Control.ToUpper() == "SELFDOCMGR")
                    {
                        _obj_Smhr_LoginInfo.LOGIN_ID = 12;
                        //rg_uploadedfiles.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    }
                }
                else
                {
                    _obj_Smhr_LoginInfo.LOGIN_ID = 2;
                }
                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();

                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Document Manager");//DOCUMENT MANAGER");
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
                    rg_uploadedfiles.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;

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
                //if (Convert.ToInt32(Session["EMP_ID"]) == (-1) || Convert.ToInt32(Session["EMP_ID"]) == 0)
                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 1)
                {
                    if (Control != null)
                    {
                        if (Control.ToUpper() == "SELFDOCMGR")
                        {
                            rmp_documentcenter.SelectedIndex = 2;
                            LoadGrid();
                        }
                    }
                    else
                    {
                        rmp_documentcenter.SelectedIndex = 0;
                        LoadGrid();
                    }
                }
                else
                {
                    rmp_documentcenter.SelectedIndex = 2;
                    LoadGrid();
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_upload", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }




        //Session.Remove("WRITEFACILITY");

        //SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

        //_obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
        //_obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
        //_obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
        //_obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("DOCUMENT MANAGER");
        //DataTable dtformdtls = BLL.get_LoginInfo(_obj_Smhr_LoginInfo);
        //if (dtformdtls.Rows.Count != 0)
        //{
        //    if ((Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_READ"]) == true) && (Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_WRITE"]) == true))
        //    {
        //        Session["WRITEFACILITY"] = 1;//WHICH MEANS READ AND WRITE
        //    }
        //    else if ((Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_READ"]) == true) && (Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_WRITE"]) == false))
        //    {
        //        Session["WRITEFACILITY"] = 2;//WHICH MEANS READ NO WRITE
        //    }
        //    else if ((Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_READ"]) == false) && (Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_WRITE"]) == false))
        //    {
        //        Session["WRITEFACILITY"] = 3;//WHICH MEANS NO READ AND NO WRITE
        //    }

        //}



        //if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
        //{
        //    rg_uploadedfiles.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;

        //}
    }

    protected void upload_file()
    {
        try
        {
            _obj_smhr_upload = new SMHR_UPLOAD();
            _obj_smhr_upload.ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            if (fileupload_upload.HasFile) //fetch the data from view state and pass in to temp query
            {
                if (Convert.ToInt32(rb_newfolder.SelectedItem.Value) == 0)
                {
                    if (System.IO.Directory.Exists(Server.MapPath("~/Corporate_Contract_Docs/") + _obj_smhr_upload.ORG_ID + "") == false)
                    {
                        System.IO.Directory.CreateDirectory(Server.MapPath("~/Corporate_Contract_Docs/") + _obj_smhr_upload.ORG_ID + "");
                    }
                    if (System.IO.Directory.Exists(Server.MapPath("~/Corporate_Contract_Docs/" + _obj_smhr_upload.ORG_ID + "/") + Convert.ToString(rcmb_businessunit.SelectedItem.Value.Replace("/", "_"))) == false)
                    {
                        System.IO.Directory.CreateDirectory(Server.MapPath("~/Corporate_Contract_Docs/" + _obj_smhr_upload.ORG_ID + "/") + Convert.ToString(rcmb_businessunit.SelectedItem.Value.Replace("/", "_")));
                    }

                    if (System.IO.Directory.Exists(Server.MapPath("~/Corporate_Contract_Docs/" + _obj_smhr_upload.ORG_ID + "/" + Convert.ToString(rcmb_businessunit.SelectedItem.Value.Replace("/", "_")) + "") + Convert.ToString(txt_foldername.Text.Replace("/", "_"))) == false)
                    {
                        System.IO.Directory.CreateDirectory(Server.MapPath("~/Corporate_Contract_Docs/" + _obj_smhr_upload.ORG_ID + "/" + Convert.ToString(rcmb_businessunit.SelectedItem.Value.Replace("/", "_")) + "/") + Convert.ToString(txt_foldername.Text.Replace("/", "_")));
                    }

                    fileupload_upload.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Corporate_Contract_Docs/" + _obj_smhr_upload.ORG_ID + "/" + Convert.ToString(rcmb_businessunit.SelectedItem.Value.Replace("/", "_")) + "/" + Convert.ToString(txt_foldername.Text.Replace("/", "_")) + ""), filename));
                }
                if (Convert.ToInt32(rb_newfolder.SelectedItem.Value) == 1)
                {

                    fileupload_upload.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Corporate_Contract_Docs/" + _obj_smhr_upload.ORG_ID + "/" + Convert.ToString(rcmb_businessunit.SelectedItem.Value.Replace("/", "_")) + "/" + Convert.ToString(rcmb_prev_folder.SelectedItem.Text.Replace("/", "_")) + "/"), filename));

                }
            }
            else
            {
                BLL.ShowMessage(this, "Please Select the File to be uploaded");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_upload", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadCombos()
    {
        try
        {
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(ViewState["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(ViewState["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            rcmb_businessunit.DataSource = dt_BUDetails;
            rcmb_businessunit.DataValueField = "BUSINESSUNIT_ID";
            rcmb_businessunit.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_businessunit.DataBind();
            rcmb_businessunit.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_upload", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadGrid()
    {
        try
        {
            _obj_smhr_upload = new SMHR_UPLOAD();
            _obj_smhr_upload.OPERATION = operation.Select1;
            _obj_smhr_upload.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_upload.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_getuploadfiles = BLL.Get_SMHR_UPLOAD(_obj_smhr_upload);
            //if (Convert.ToInt32(Session["EMP_ID"]) == (-1) || Convert.ToInt32(Session["EMP_ID"]) == 0)
            if (Control != null)
            {
                if (Control.ToUpper() == "SELFDOCMGR")
                {
                    rg_download.DataSource = dt_getuploadfiles;
                    rg_download.DataBind();
                }
            }
            else
            {
                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 1)
                {
                    rg_uploadedfiles.DataSource = dt_getuploadfiles;
                    rg_uploadedfiles.DataBind();
                }
                else
                {
                    rg_download.DataSource = dt_getuploadfiles;
                    rg_download.DataBind();
                }
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_upload", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_add(object sender, EventArgs e)
    {
        try
        {
            rmp_documentcenter.SelectedIndex = 1;
            LoadCombos();
            rcmb_businessunit.SelectedIndex = -1;
            txt_foldername.Text = "";
            txt_filename.Text = "";
            rcmb_prev_folder.SelectedIndex = -1;
            rcmb_prev_folder.Enabled = false;
            rfv_FolderName.Enabled = false;
            rfv_PrevFolder.Enabled = false;
            txt_foldername.Enabled = false;
            rb_newfolder.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_upload", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_upload_Click(object sender, EventArgs e)
    {

        try
        {
            _obj_smhr_upload = new SMHR_UPLOAD();
            _obj_smhr_upload.BUSINESS_UNIT = Convert.ToInt32(rcmb_businessunit.SelectedItem.Value);
            _obj_smhr_upload.ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_upload.FILE_NAME = txt_filename.Text;
            _obj_smhr_upload.CREATED_BY = Convert.ToInt32(Session["USER_ID"]);
            if (rb_newfolder.SelectedItem == null)
            {
                BLL.ShowMessage(this, "Please Select Yes or No for Create New Folder");
                return;
            }
            //if (rcmb_prev_folder.SelectedIndex == 0 && txt_foldername.Text == string.Empty)
            //{
            //    //BLL.ShowMessage(this, "Please Select Folder Name");
            //    //return;
            //}
            //else
            //{
            if (Convert.ToInt32(rb_newfolder.SelectedItem.Value) == 0)
            {
                _obj_smhr_upload.FOLDER_NAME = txt_foldername.Text;
                if (fileupload_upload.HasFile)
                {
                    string strfilename1 = fileupload_upload.FileName;
                    //filename = Convert.ToString(DateTime.Now.TimeOfDay.Ticks) + "_" + (fileupload_upload.FileName).Replace(" ", "_");
                    filename = Convert.ToString(DateTime.Now) + "_" + (fileupload_upload.FileName).Replace(" ", "_");
                    filename = filename.Replace("/", "").Replace(":", "");
                    filename1 = +_obj_smhr_upload.ORG_ID + "/" + (_obj_smhr_upload.BUSINESS_UNIT) + "/" + _obj_smhr_upload.FOLDER_NAME + "/" + filename;
                    string path = MapPath(strfilename1);
                    string ext = Path.GetExtension(strfilename1);
                    _obj_smhr_upload.FILE_PATH = filename1;
                    _obj_smhr_upload.FILE_TYPE = ext;
                    _obj_smhr_upload.NEW_FOLDER = Convert.ToBoolean(rb_newfolder.SelectedItem.Selected);
                    upload_file();
                    _obj_smhr_upload.BUSINESS_UNIT = Convert.ToInt32(rcmb_businessunit.SelectedItem.Value);
                    _obj_smhr_upload.ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_upload.FOLDER_NAME = txt_foldername.Text.Replace("'", "''");
                    _obj_smhr_upload.FILE_NAME = txt_filename.Text.Replace("'", "''");
                    _obj_smhr_upload.FILE_TYPE = ext;
                    _obj_smhr_upload.FILE_PATH = filename1;
                    _obj_smhr_upload.CREATED_BY = Convert.ToInt32(Session["USER_ID"]);
                    //DateTime dt = new DateTime();
                    //string STR2 = DateTime.Now.ToLongDateString();
                    //string STR = DateTime.Now.ToUniversalTime().ToString();
                    //_obj_smhr_upload.UPLOAD_CREATEDDATE =Convert.ToDateTime("MM/dd/yyyy");
                    //_obj_smhr_upload.UPLOAD_CREATEDDATE = DateTime.Now;
                    _obj_smhr_upload.OPERATION = operation.Check;
                    _obj_smhr_upload.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    if (Convert.ToString(BLL.Get_SMHR_UPLOAD(_obj_smhr_upload).Rows[0]["Count"]) != "0")
                    {
                        BLL.ShowMessage(this, "Filename With Folder Name Combination Already Exists.");
                        return;
                    }
                    _obj_smhr_upload.OPERATION = operation.Insert;
                    BLL.insertupload(_obj_smhr_upload);
                    BLL.ShowMessage(this, "The File has been Succesfully Uploaded");
                    rmp_documentcenter.SelectedIndex = 0;
                    LoadGrid();
                }
                else
                {
                    BLL.ShowMessage(this, "Please Select the File to be uploaded");
                }
            }

            if (Convert.ToInt32(rb_newfolder.SelectedItem.Value) == 1)
            {
                _obj_smhr_upload.FOLDER_NAME = rcmb_prev_folder.SelectedItem.Text;
                if (fileupload_upload.HasFile)
                {
                    string strfilename1 = fileupload_upload.FileName;
                    filename = Convert.ToString(DateTime.Now) + "_" + (fileupload_upload.FileName).Replace(" ", "_");
                    filename = filename.Replace("/", "").Replace(":", "");
                    filename1 = +_obj_smhr_upload.ORG_ID + "/" + (_obj_smhr_upload.BUSINESS_UNIT) + "/" + _obj_smhr_upload.FOLDER_NAME + "/" + filename;
                    string path = MapPath(strfilename1);
                    string ext = Path.GetExtension(strfilename1);
                    _obj_smhr_upload.FILE_PATH = filename1;
                    _obj_smhr_upload.FILE_TYPE = ext;
                    upload_file();
                    _obj_smhr_upload.BUSINESS_UNIT = Convert.ToInt32(rcmb_businessunit.SelectedItem.Value);
                    _obj_smhr_upload.ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_upload.NEW_FOLDER = Convert.ToBoolean(rb_newfolder.SelectedItem.Selected);
                    _obj_smhr_upload.FILE_NAME = txt_filename.Text.Replace("'", "''");
                    _obj_smhr_upload.FILE_TYPE = ext;
                    _obj_smhr_upload.FILE_PATH = filename1;
                    _obj_smhr_upload.FOLDER_NAME = rcmb_prev_folder.SelectedItem.Text;
                    _obj_smhr_upload.CREATED_BY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_upload.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    //_obj_smhr_upload.UPLOAD_CREATEDDATE = DateTime.Now;
                    _obj_smhr_upload.OPERATION = operation.Check;
                    DataTable dt_Check = BLL.Get_SMHR_UPLOAD(_obj_smhr_upload);
                    if (dt_Check.Rows.Count > 0 && Convert.ToString(dt_Check.Rows[0][0]) != "0")
                    {
                        BLL.ShowMessage(this, "Filename With Folder Name Combination Already Exists.");
                        return;
                    }
                    _obj_smhr_upload.OPERATION = operation.Insert;
                    BLL.insertupload(_obj_smhr_upload);
                    BLL.ShowMessage(this, "The File has been Succesfully Uploaded");
                    rmp_documentcenter.SelectedIndex = 0;
                    LoadGrid();
                }
                else
                {
                    BLL.ShowMessage(this, "Please Select the File to be uploaded");
                }

            }

            // }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_upload", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }



    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            if (Convert.ToInt32(rb_newfolder.SelectedItem.Value) == 0)
            {
                txt_foldername.Enabled = true;
                rfv_FolderName.Enabled = true;
                rcmb_prev_folder.Enabled = false;
                rfv_PrevFolder.Enabled = false;
            }
            else if (Convert.ToInt32(rb_newfolder.SelectedItem.Value) == 1)
            {
                txt_foldername.Enabled = false;
                rfv_FolderName.Enabled = false;
                rcmb_prev_folder.Enabled = true;
                rfv_PrevFolder.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_upload", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    protected void lbtn_download_OnCommand(object sender, CommandEventArgs e)
    {
        try
        {
            string strPath1 = "../Corporate_Contract_Docs/" + e.CommandArgument.ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "<script>window.open('" + strPath1 + "');</script>", false);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_upload", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lbtn_download_OnCommand1(object sender, CommandEventArgs e)
    {
        try
        {
            string strPath1 = "../Corporate_Contract_Docs/" + e.CommandArgument.ToString();
            FileInfo fileInfo = new FileInfo(strPath1);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "<script>window.open('" + strPath1 + "');</script>", false);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_upload", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lbtn_delete_OnCommand(object sender, CommandEventArgs e)
    {
        try
        {
            ViewState["ORG_ID"] = Session["ORG_ID"];
            ViewState["USER_ID"] = Session["USER_ID"];
            //if (Convert.ToInt32(Session["EMP_ID"]) == (-1) || Convert.ToInt32(Session["EMP_ID"]) == 0)
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 1)
            {
                _obj_smhr_upload = new SMHR_UPLOAD();
                string path = e.CommandArgument.ToString();
                _obj_smhr_upload.OPERATION = operation.Delete;
                _obj_smhr_upload.FILE_PATH = path;
                BLL.Get_SMHR_UPLOAD(_obj_smhr_upload);
                strpath1 = "~/Corporate_Contract_Docs/" + path;
                File.Delete(Server.MapPath(strpath1));
                int pos = strpath1.LastIndexOf(@"/");
                string filename = strpath1.Remove(pos);
                GetFileCount(filename);
                LoadGrid();
            }
            else
            {
                BLL.ShowMessage(this, "You dont have permission to delete this file");
            }
        }
        catch (Exception ex)
        {
            BLL.ShowMessage(this, "File Doesnt exist in this directory");
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_upload", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

    }

    public int GetFileCount(string filename)
    {
      
        int fileCount = 0;
        try
        {
            DirectoryInfo dirinfo = new DirectoryInfo(Server.MapPath(filename));
            DirectoryInfo[] subdirinfo = dirinfo.GetDirectories("*.*");
            FileInfo[] files = dirinfo.GetFiles();
            if (files.Length > 0)
            {
                fileCount = fileCount + files.Length;
            }
            else
            {
                dirinfo.Delete(true);
            }
        }
        catch (System.Exception ex)
        {
            BLL.ShowMessage(this, "File or Directory doesnt exist");
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_upload", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return fileCount;
    }

    protected void RadComboBox1_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            _obj_smhr_upload = new SMHR_UPLOAD();
            _obj_smhr_upload.OPERATION = operation.Select;
            _obj_smhr_upload.BUSINESS_UNIT = Convert.ToInt32(rcmb_businessunit.SelectedItem.Value);
            DataTable dt_FOLDERS = BLL.Get_SMHR_UPLOAD(_obj_smhr_upload);
            rcmb_prev_folder.DataSource = dt_FOLDERS;
            rcmb_prev_folder.DataTextField = "UPLOAD_FOLDER_NAME";
            rcmb_prev_folder.DataBind();
            rcmb_prev_folder.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            BLL.ShowMessage(this, "File Doesnt exist in this directory");
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_upload", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        try
        {
            rmp_documentcenter.SelectedIndex = 0;
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_upload", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public static bool ResponseFile(HttpRequest _Request, HttpResponse _Response, string _fileName, string _fullPath, long _speed)
    {
        //try
        //{
        FileStream myFile = new FileStream(_fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        BinaryReader br = new BinaryReader(myFile);
        try
        {

            _Response.AddHeader("Accept-Ranges", "bytes");
            _Response.Buffer = false;
            long fileLength = myFile.Length;
            long startBytes = 0;

            int pack = 10240; //10K bytes
            int sleep = (int)Math.Floor((double)(1000 * pack / _speed)) + 1;
            if (_Request.Headers["Range"] != null)
            {
                _Response.StatusCode = 206;
                string[] range = _Request.Headers["Range"].Split(new char[] { '=', '-' });
                startBytes = Convert.ToInt64(range[1]);
            }
            _Response.AddHeader("Content-Length", (fileLength - startBytes).ToString());
            if (startBytes != 0)
            {
                _Response.AddHeader("Content-Range", string.Format(" bytes {0}-{1}/{2}", startBytes, fileLength - 1, fileLength));
            }
            _Response.AddHeader("Connection", "Keep-Alive");
            _Response.ContentType = "application/octet-stream";
            _Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(_fileName, System.Text.Encoding.UTF8));

            br.BaseStream.Seek(startBytes, SeekOrigin.Begin);
            int maxCount = (int)Math.Floor((double)((fileLength - startBytes) / pack)) + 1;

            for (int i = 0; i < maxCount; i++)
            {
                if (_Response.IsClientConnected)
                {
                    _Response.BinaryWrite(br.ReadBytes(pack));
                    Thread.Sleep(sleep);
                }
                else
                {
                    i = maxCount;
                }
            }
        }
        catch (Exception ex)
        {
            BLL.Error_Log(HttpContext.Current.Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_upload", ex.StackTrace, DateTime.Now);
             HttpContext.Current.Response.Redirect("~/Frm_ErrorPage.aspx");
            //return false;
        }
        finally
        {
            br.Close();
            myFile.Close();
        }
        //}
        //catch(Exception ex1)
        //{

        //    SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex1.TargetSite.ToString(), ex1.Message.Replace("'", "''"), "frm_upload", ex1.StackTrace, DateTime.Now);
        //    Response.Redirect("~/Frm_ErrorPage.aspx");
        //    return false;
        //}
        return true;
    }
}
