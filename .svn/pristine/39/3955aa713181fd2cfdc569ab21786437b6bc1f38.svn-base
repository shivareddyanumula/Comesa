using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Masters_frm_ServiceProviders : System.Web.UI.Page
{
    string strfilename2;
    DataSet ds = new DataSet();
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }
    SMHR_SERVICEPROVIDER _obj_Smhr_ServiceProvider;
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (!IsPostBack)
            {

                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Service Provider");//COUNTRY");
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
                    Rg_ServiceProviders.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
                Page.Validate();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ServiceProviders", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void BindServiceProviderTypes()
    {
        try
        {
            SMHR_MASTERS _obj_smhr_masters = new SMHR_MASTERS();
            _obj_smhr_masters.OPERATION = operation.Select;
            _obj_smhr_masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_masters.MASTER_TYPE = "SERVICEPROVIDERTYPE";
            DataTable dt = BLL.get_MasterRecords(_obj_smhr_masters);
            radServiceProviderType.DataSource = dt;
            radServiceProviderType.DataTextField = "HR_MASTER_CODE";
            radServiceProviderType.DataValueField = "HR_MASTER_ID";
            radServiceProviderType.DataBind();
            radServiceProviderType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ServiceProviders", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void clearControls()
    {
        try
        {
            lbl_ServiceProviderID.Text = string.Empty;
            rtxt_ServiceProviderName.Text = string.Empty;
            rtxt_ServiceProviderName.Enabled = true;
            rtxt_ServiceProviderAddress.Text = string.Empty;
            radEmailID.Text = string.Empty;
            radContactName.Text = string.Empty;
            radContactNo.Text = string.Empty;
            radAlternateContact1.Text = string.Empty;
            radAlternateContact2.Text = string.Empty;
            radIFMISNumber.Text = string.Empty;
            radPinNumber.Text = string.Empty;
            btn_Save.Visible = false;
            btn_Update.Visible = false;
            Rm_CY_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ServiceProviders", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            clearControls();
            rtxt_ServiceProviderName.Enabled = false;
            radIFMISNumber.Enabled = false;
            radPinNumber.Enabled = false;
            DataTable dt = BLL.get_ServiceProvider(new SMHR_SERVICEPROVIDER(Convert.ToInt32(Convert.ToString(e.CommandArgument))));
            lbl_ServiceProviderID.Text = Convert.ToString(dt.Rows[0]["ServiceProvider_ID"]);
            rtxt_ServiceProviderName.Text = Convert.ToString(dt.Rows[0]["ServiceProvider_NAME"]);
            rtxt_ServiceProviderAddress.Text = Convert.ToString(dt.Rows[0]["SERVICEPROVIDER_ADDRESS"]);
            radEmailID.Text = dt.Rows[0]["SERVICEPROVIDER_EmailID"].ToString();
            radContactName.Text = dt.Rows[0]["SERVICEPROVIDER_KeyContactPersonName"].ToString();
            radContactNo.Text = dt.Rows[0]["SERVICEPROVIDER_CONTACTNUMBER"].ToString();
            radAlternateContact1.Text = dt.Rows[0]["SERVICEPROVIDER_ALTERNATECONTACTNUMBER1"].ToString();
            radAlternateContact2.Text = dt.Rows[0]["SERVICEPROVIDER_ALTERNATECONTACTNUMBER2"].ToString();
            radIFMISNumber.Text = dt.Rows[0]["SERVICEPROVIDER_IFMISNUMBER"].ToString();
            radPinNumber.Text = dt.Rows[0]["SERVICEPROVIDER_PINNUMBER"].ToString();
            BindServiceProviderTypes();
            radServiceProviderType.SelectedValue = radServiceProviderType.FindItemByText(dt.Rows[0]["SERVICEPROVIDER_TYPE"].ToString()).Value;
            if (string.Compare(dt.Rows[0]["SERVICEPROVIDER_TYPE"].ToString().ToLower(), "medical", true) == 0)
            {
                trexpenditure.Visible = true;
                // trifimsnumber.Visible = true;
                // trpinnumber.Visible = true;

                BindExpenditure();
                string[] checkedExpenditurevalues = dt.Rows[0]["SERVICEPROVIDER_ExpenditureNames"].ToString().Split(',');

                foreach (RadListBoxItem rl in radExpenditureName.Items)
                {
                    foreach (string s in checkedExpenditurevalues)
                    {
                        if (string.Compare(rl.Value, s, true) == 0)
                        {
                            rl.Checked = true;
                        }
                    }
                }

            }
            else
            {
                trexpenditure.Visible = false;
                // trifimsnumber.Visible = false;
                // trpinnumber.Visible = false;
            }

            //code for security
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Update.Visible = false;

            }

            else
            {
                btn_Update.Visible = true;
            }
            Rm_CY_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ServiceProviders", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            clearControls();
            BindServiceProviderTypes();
            btn_Save.Visible = true;
            Rm_CY_page.SelectedIndex = 1;
            trexpenditure.Visible = false;
            radIFMISNumber.Enabled = true;
            radPinNumber.Enabled = true;
            //trifimsnumber.Visible = false;
            //trpinnumber.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ServiceProviders", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rg_ServiceProviders_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ServiceProviders", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    public void LoadGrid()
    {
        try
        {
            _obj_Smhr_ServiceProvider = new SMHR_SERVICEPROVIDER();
            _obj_Smhr_ServiceProvider.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT = BLL.get_ServiceProvider(_obj_Smhr_ServiceProvider);
            Rg_ServiceProviders.DataSource = DT;

            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ServiceProviders", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(radAlternateContact1.Text) && string.Compare(radContactNo.Text, radAlternateContact1.Text, true) == 0)
            {
                BLL.ShowMessage(this, "Contact Number and Alternative Contact Number Cannot be Same");
                return;
            }
            if (!string.IsNullOrEmpty(radAlternateContact1.Text) && !string.IsNullOrEmpty(radAlternateContact2.Text) && string.Compare(radAlternateContact1.Text, radAlternateContact2.Text, true) == 0)
            {
                BLL.ShowMessage(this, "Both Alternative Contact Numbers Cannot be Same");
                return;
            }
            if (!string.IsNullOrEmpty(radAlternateContact2.Text) && string.Compare(radContactNo.Text, radAlternateContact2.Text, true) == 0)
            {
                BLL.ShowMessage(this, "Contact Number and Alternative Contact Number Cannot be Same");
                return;
            }
            string errorMsg = string.Empty;
            if (ValidateInputs(out errorMsg))
            {
                _obj_Smhr_ServiceProvider = new SMHR_SERVICEPROVIDER();
                _obj_Smhr_ServiceProvider.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_ServiceProvider.SERVICEPROVIDER_NAME = BLL.ReplaceQuote(rtxt_ServiceProviderName.Text).Trim();
                _obj_Smhr_ServiceProvider.SERVICEPROVIDER_ADDRESS = BLL.ReplaceQuote(rtxt_ServiceProviderAddress.Text);
                _obj_Smhr_ServiceProvider.SERVICEPROVIDEREMAILID = radEmailID.Text;
                _obj_Smhr_ServiceProvider.SERVICEPROVIDER_KEYCONTACTPERSONNAME = radContactName.Text;
                _obj_Smhr_ServiceProvider.SERVICEPROVIDER_CONTACTNUMBER = radContactNo.Text;
                _obj_Smhr_ServiceProvider.SERVICEPROVIDER_ALTERNATECONTACTNUMBER1 = radAlternateContact1.Text;
                _obj_Smhr_ServiceProvider.SERVICEPROVIDER_ALTERNATECONTACTNUMBER2 = radAlternateContact2.Text;
                _obj_Smhr_ServiceProvider.SERVICEPROVIDER_TYPE = radServiceProviderType.SelectedItem.Text;

                _obj_Smhr_ServiceProvider.SERVICEPROVIDER_IFMISNUMBER = radIFMISNumber.Text;
                _obj_Smhr_ServiceProvider.SERVICEPROVIDER_PINNUMBER = radPinNumber.Text;

                if (string.Compare(_obj_Smhr_ServiceProvider.SERVICEPROVIDER_TYPE.ToLower(), "medical", true) == 0)
                {

                    StringBuilder sb = new StringBuilder();
                    foreach (RadListBoxItem rl in radExpenditureName.CheckedItems)
                    {
                        sb.Append(rl.Value + ",");
                    }
                    _obj_Smhr_ServiceProvider.SERVICEPROVIDER_EXPENDITURENAMES = sb.ToString().Remove(sb.ToString().Length - 1);
                }
                else
                {

                }
                _obj_Smhr_ServiceProvider.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                _obj_Smhr_ServiceProvider.CREATEDDATE = DateTime.Now;
                _obj_Smhr_ServiceProvider.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                _obj_Smhr_ServiceProvider.LASTMDFDATE = DateTime.Now;

                switch (((Button)sender).ID.ToUpper())
                {
                    case "BTN_UPDATE":
                        _obj_Smhr_ServiceProvider.SERVICEPROVIDER_ID = Convert.ToInt32(lbl_ServiceProviderID.Text);
                        _obj_Smhr_ServiceProvider.OPERATION = operation.Update;
                        if (BLL.set_ServiceProvider(_obj_Smhr_ServiceProvider))
                            BLL.ShowMessage(this, "Information Updated Successfully");
                        else
                            BLL.ShowMessage(this, "Information Not Updated");

                        break;
                    case "BTN_SAVE":
                        _obj_Smhr_ServiceProvider.OPERATION = operation.Check;
                        if (Convert.ToString(BLL.get_ServiceProvider(_obj_Smhr_ServiceProvider).Rows[0]["Count"]) != "0")
                        {
                            BLL.ShowMessage(this, "Service Provider Name Already Exists");
                            return;
                        }
                        _obj_Smhr_ServiceProvider.OPERATION = operation.Check1;
                        if (Convert.ToString(BLL.get_ServiceProvider(_obj_Smhr_ServiceProvider).Rows[0]["Count"]) != "0")
                        {
                            BLL.ShowMessage(this, "IFMIS Number Already Exists");
                            return;
                        }
                        _obj_Smhr_ServiceProvider.OPERATION = operation.Check2;
                        if (Convert.ToString(BLL.get_ServiceProvider(_obj_Smhr_ServiceProvider).Rows[0]["Count"]) != "0")
                        {
                            BLL.ShowMessage(this, "Pin Number Already Exists");
                            return;
                        }
                        _obj_Smhr_ServiceProvider.OPERATION = operation.Insert;
                        if (BLL.set_ServiceProvider(_obj_Smhr_ServiceProvider))
                            BLL.ShowMessage(this, "Information Saved Successfully");
                        else
                            BLL.ShowMessage(this, "Information Not Saved");
                        break;
                    default:
                        break;
                }
                Rm_CY_page.SelectedIndex = 0;
                LoadGrid();
                Rg_ServiceProviders.DataBind();
            }
            else
            {
                if (!string.IsNullOrEmpty(errorMsg))
                    BLL.ShowMessage(this, errorMsg);
            }


        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ServiceProviders", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private bool ValidateInputs(out string errorMsg)
    {

        errorMsg = string.Empty;

        if (string.Compare(radServiceProviderType.SelectedItem.Text.ToLower(), "medical", true) == 0)
        {
            if (!string.IsNullOrEmpty(radIFMISNumber.Text))
            {
                if (!string.IsNullOrEmpty(radPinNumber.Text))
                {
                    if (radExpenditureName.CheckedItems.Count > 0)
                    {
                        errorMsg = string.Empty;
                        return true;
                    }
                    else
                    {
                        errorMsg = "Please select atleast one Expenditure Name ";
                        return false;
                    }
                }
                else
                {
                    errorMsg = "Please Enter Pin Number";
                    return false;
                }
            }
            else
            {
                errorMsg = "Please Enter IFMIS Number";
                return false;
            }
        }
        else
        {
            errorMsg = string.Empty;
            return true;
        }

    }



    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ServiceProviders", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ServiceProviders", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //protected void Btn_Imp_Businessunit_click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        // written by rajasekhar
    //        // to import ServiceProvider details

    //        string strcon = null;

    //        string strfilename1 = FileUpload1.FileName;
    //        strfilename2 = Convert.ToString(DateTime.Now.TimeOfDay) + "_" + strfilename1;
    //        strfilename2 = strfilename2.Replace("/", "").Replace(":", ".");
    //        if (FileUpload1.HasFile)
    //        {

    //            if (System.IO.Directory.Exists(Server.MapPath("~/IMPORT_EXCEL/")) == false)
    //            {
    //                System.IO.Directory.CreateDirectory(Server.MapPath("~/IMPORT_EXCEL/"));

    //            }



    //            FileUpload1.PostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/IMPORT_EXCEL/"), strfilename2));
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
    //        ds.Tables[0].Columns.Add("Error Message");

    //        objConn.Close();
    //        DataTable dt = new DataTable();
    //        DataTable dtfail = new DataTable();


    //        string errormsg = string.Empty;


    //        Int32 rowno = 0;


    //        string columnno = null;

    //        Boolean filestatus = true;
    //        dtfail.Columns.Add("S.NO", typeof(Int32));
    //        dtfail.Columns.Add("ROWNO", typeof(Int32));
    //        dtfail.Columns.Add("COLUMNS NAMES", typeof(string));
    //        if (ds.Tables[0].Columns[0].ToString().Trim() == "Name*")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds.Tables[0].Columns[1].ToString().Trim() == "Description")
    //        {
    //        }
    //        else
    //        {
    //            Delete_Excel_File();
    //            BLL.ShowMessage(this, "Please select the Correct Excel Template  Sheet.");
    //            return;
    //        }
    //        if (ds.Tables[0].Columns[2].ToString().Trim() == "")
    //        {
    //        }
    //        else
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

    //        //to check the data in excel
    //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //        {

    //            errormsg = string.Empty;
    //            columnno = string.Empty;
    //            if (ds.Tables[0].Rows[i]["Name*"].ToString().Trim() != "")
    //            {
    //                _obj_Smhr_ServiceProvider = new SMHR_SERVICEPROVIDER();
    //                _obj_Smhr_ServiceProvider.SERVICEPROVIDER_NAME = ds.Tables[0].Rows[i]["Name*"].ToString().Trim();
    //                _obj_Smhr_ServiceProvider.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);


    //                _obj_Smhr_ServiceProvider.OPERATION = operation.Check;
    //                if (Convert.ToString(BLL.get_ServiceProvider(_obj_Smhr_ServiceProvider).Rows[0]["Count"]) != "0")
    //                {
    //                    errormsg = "ServiceProvider Name Already Exists";
    //                    filestatus = false;
    //                    rowno = i + 2;
    //                    columnno = "Name*";
    //                }
    //                else
    //                {

    //                }
    //                for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
    //                {
    //                    if (ds.Tables[0].Rows[i]["Name*"].ToString().Trim() == ds.Tables[0].Rows[k]["Name*"].ToString().Trim())
    //                    {
    //                        if (i != k)
    //                        {
    //                            errormsg = errormsg + "," + " ServiceProvider Name is repeated in Excel Sheet";
    //                            filestatus = false;
    //                            rowno = i + 2;
    //                            columnno = "Name*";
    //                        }
    //                    }
    //                }

    //            }

    //            else
    //            {
    //                filestatus = false;
    //                rowno = i + 2;
    //                columnno = "Name*";
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
    //            if (RWM_POSTREPLY1.Windows.Count > 1)
    //            {
    //                RWM_POSTREPLY1.Windows.RemoveAt(1);
    //            }
    //            RWM_POSTREPLY1.Windows.Add(newwindow);



    //            RWM_POSTREPLY1.Visible = true;
    //            return;

    //        }


    //        else
    //        {
    //            bool status = false;
    //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //            {

    //                _obj_Smhr_ServiceProvider = new SMHR_SERVICEPROVIDER();
    //                _obj_Smhr_ServiceProvider.SERVICEPROVIDER_NAME = ds.Tables[0].Rows[i]["Name*"].ToString().Trim();
    //                _obj_Smhr_ServiceProvider.SERVICEPROVIDER_ADDRESS = ds.Tables[0].Rows[i]["Description"].ToString().Trim();
    //                _obj_Smhr_ServiceProvider.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                _obj_Smhr_ServiceProvider.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
    //                _obj_Smhr_ServiceProvider.CREATEDDATE = DateTime.Now;

    //                _obj_Smhr_ServiceProvider.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
    //                _obj_Smhr_ServiceProvider.LASTMDFDATE = DateTime.Now;
    //                _obj_Smhr_ServiceProvider.OPERATION = operation.Insert;
    //                status = BLL.set_ServiceProvider(_obj_Smhr_ServiceProvider);

    //            }
    //            if (status == true)
    //            {
    //                BLL.ShowMessage(this, "Information Saved Successfully");
    //            }
    //            else
    //            {
    //            }
    //            LoadGrid();
    //            Rg_ServiceProviders.DataBind();

    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}
    protected void radServiceProviderType_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (string.Compare(radServiceProviderType.SelectedItem.Text.ToLower(), "medical", true) == 0)
            {
                trexpenditure.Visible = true;
                // trifimsnumber.Visible = true;
                // trpinnumber.Visible = true;
                BindExpenditure();
            }
            else
            {
                trexpenditure.Visible = false;
                // trifimsnumber.Visible = false;
                // trpinnumber.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ServiceProviders", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void BindExpenditure()
    {
        try
        {
            SMHR_EXPENDITURE _obj_smhr_expenditure = new SMHR_EXPENDITURE();
            _obj_smhr_expenditure.OPERATION = operation.Select;
            _obj_smhr_expenditure.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_Expenditure(_obj_smhr_expenditure);
            radExpenditureName.DataSource = dt;
            radExpenditureName.DataTextField = "EXPENDITURE_NAME";
            radExpenditureName.DataValueField = "EXPENDITURE_ID";
            radExpenditureName.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ServiceProviders", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

}