using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;
using SMHR;
using SPMS;
using System.IO;
using System.Text;
using Telerik.Web.UI.GridExcelBuilder;
public partial class Payroll_frm_esiimport : System.Web.UI.Page
{
    SMHR_BUSINESSUNIT _obj_smhr_businessunit;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
         
            Page.Validate();
         if (!Page.IsPostBack)
         {
             Session.Remove("WRITEFACILITY");

             SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

             _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
             _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
             _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
             _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("ESIIMPORT");
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
             if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
             {
                 Rg_ESIIMPORT.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;



             }
             Rm_ESIIMPORT_PAGE.SelectedIndex = 0;
             lbl_det.Visible = false;
             lbl_esiimport.Visible = true;
             LoadMainGrid();
             LoadCombos();
         }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_esiimport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    #region LoadGrid
    /// <summary>
    ///IN THIS data binding from database to datatable binding to radgrid
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void Rg_ESIIMPORT_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {

            SMHR_ESIIMPORT _obj_SMHR_ESIIMPORT = new SMHR_ESIIMPORT();
            _obj_SMHR_ESIIMPORT.Mode = 1;
            _obj_SMHR_ESIIMPORT.ESIIMPORT_ORGID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_ESIimport(_obj_SMHR_ESIIMPORT);
            if (dt.Rows.Count != 0)
            {
                Rg_ESIIMPORT.DataSource = dt;

            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_esiimport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    protected void LoadMainGrid()
    {
        try
        {
            SMHR_ESIIMPORT _obj_SMHR_ESIIMPORT = new SMHR_ESIIMPORT();
            _obj_SMHR_ESIIMPORT.Mode = 1;
            _obj_SMHR_ESIIMPORT.ESIIMPORT_ORGID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_ESIimport(_obj_SMHR_ESIIMPORT);
            if (dt.Rows.Count != 0)
            {
                Rg_ESIIMPORT.DataSource = dt;

                Rg_ESIIMPORT.DataBind();
            }
            else
            {
                DataTable dt1 = new DataTable();

                Rg_ESIIMPORT.DataSource = dt1;

                Rg_ESIIMPORT.DataBind();
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_esiimport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    #region LoadchildGrid

    protected void LoadchildGrid()
    {
        try
        {
            SMHR_ESIMASTER _obj_Smhr_ESIMASTER = new SMHR_ESIMASTER();
            _obj_Smhr_ESIMASTER.Mode = 7;
           
                _obj_Smhr_ESIMASTER.SMHR_ESI_MASTER_BUID = Convert.ToInt32(rcmb_BUI.SelectedItem.Value);
            
                //_obj_Smhr_ESIMASTER.SMHR_ESI_MASTER_BUID = 0;

            
            _obj_Smhr_ESIMASTER.SMHR_ESI_MASTER_ORGID = Convert.ToInt32(Session["ORG_ID"]);
           
                _obj_Smhr_ESIMASTER.SMHR_ESI_MASTER_CREATEDBY = Convert.ToInt32(rcm_fin_elem.SelectedItem.Value);
            

            
            DataTable dt = BLL.get_ESIMASTER(_obj_Smhr_ESIMASTER);
            if (dt.Rows.Count != 0)
            {
                btn_Save.Visible = true;
                rg_importchild.DataSource = dt;
                BTN_DOWNLOAD.Visible = true;
                rg_importchild.DataBind();
            }
            else
            {
                DataTable dt1 = new DataTable();
                btn_Save.Visible = false;
                BTN_DOWNLOAD.Visible = false;
                rg_importchild.DataSource = dt1;

                rg_importchild.DataBind();
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_esiimport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rg_importchild_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
           
            SMHR_PAYROLL _obj_smhr_payroll = new SMHR_PAYROLL();
            if (RCM_FINANCIALPERIOD.SelectedItem.Value != "")
            {

                _obj_smhr_payroll.PERIODDTLID = Convert.ToInt32(RCM_FINANCIALPERIOD.SelectedItem.Value);
            }
            else
            {
                _obj_smhr_payroll.PERIODDTLID = 0;
            }
            _obj_smhr_payroll.MODE = 11;
            DataTable dt_Details = new DataTable();
            dt_Details = BLL.get_payrolltrans(_obj_smhr_payroll);
            if (dt_Details.Rows.Count != 0)
            {
                //rcm_fin_elem.DataSource = dt_Details;
                //rcm_fin_elem.DataValueField = "PRDDTL_ID";
                //rcm_fin_elem.DataTextField = "PRDDTL_NAME";
                //rcm_fin_elem.DataBind();
                //rcm_fin_elem.Items.Insert(0, new RadComboBoxItem("Select"));
            }

            else
            {
                DataTable dt_Details2 = new DataTable();
                rcm_fin_elem.DataSource = dt_Details2;

                rcm_fin_elem.DataBind();
                rcm_fin_elem.Items.Insert(0, new RadComboBoxItem("Select"));

            }

            SMHR_ESIMASTER _obj_Smhr_ESIMASTER = new SMHR_ESIMASTER();
            _obj_Smhr_ESIMASTER.Mode = 7;
            if (rcmb_BUI.SelectedItem.Value != "")
            {

                _obj_Smhr_ESIMASTER.SMHR_ESI_MASTER_BUID = Convert.ToInt32(rcmb_BUI.SelectedItem.Value);
            }
            else
            {
                _obj_Smhr_ESIMASTER.SMHR_ESI_MASTER_BUID = 0;
            }
            _obj_Smhr_ESIMASTER.SMHR_ESI_MASTER_ORGID = Convert.ToInt32(Session["ORG_ID"]);
            if (rcm_fin_elem.SelectedItem.Value != "")
            {
                _obj_Smhr_ESIMASTER.SMHR_ESI_MASTER_CREATEDBY = Convert.ToInt32(rcm_fin_elem.SelectedItem.Value);
            }

            else
            {
                _obj_Smhr_ESIMASTER.SMHR_ESI_MASTER_CREATEDBY = 0;

            }
            DataTable dt = BLL.get_ESIMASTER(_obj_Smhr_ESIMASTER);
            if (dt.Rows.Count != 0)
            {

                //btn_Save.Visible = true;
                rg_importchild.DataSource = dt;
                for (int i = 0; i < rg_importchild.Items.Count; i++)
                {
                    Label LBLAMOUNT;
                    LBLAMOUNT = rg_importchild.Items[i].FindControl("lbl_IMPORTCHILD_TOTALAMOUNT") as Label;
                    Label LBLREASONCODE;
                    LBLREASONCODE = rg_importchild.Items[i].FindControl("lbl_IMPORTCHILD_reasoncode") as Label;

                    if (LBLAMOUNT.Text == "0")
                    {
                        LBLREASONCODE.Text = "1";
                    }
                    else
                    {
                        LBLREASONCODE.Text = "0";
                    }

                }
                return;
                //BTN_DOWNLOAD.Visible = true;

            }
            else
            {
                DataTable dt1 = new DataTable();
                btn_Save.Visible = false;
                BTN_DOWNLOAD.Visible = false;
                rg_importchild.DataSource = dt1;


            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_esiimport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion


    #region Add,download Command
    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            rcmb_BUI.SelectedIndex = 0;
            RCM_FINANCIALPERIOD.SelectedIndex = 0;
            rcmb_BUI.Enabled = true;
            RCM_FINANCIALPERIOD.Enabled = true;
            btn_Save.Visible = false;
            BTN_DOWNLOAD.Visible = false;
            lbl_det.Visible = true;
            lbl_esiimport.Visible = false;
            LoadCombos();
            rg_importchild.Visible = false;
            Rm_ESIIMPORT_PAGE.SelectedIndex = 1;
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_esiimport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }





    /// <summary>
    ///IN THIS BASED ON Project_ID(COMMANDARGUMENT) ALL DATA WILL BE TAKEN TO DATATABLE THEN WE CAN BIND TO INDIVIDUAL FIELDS
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>

    protected void lnk_DOWNLOAD_Command(object sender, CommandEventArgs e)
    {
        try
        {
            LoadCombos();




            SMHR_ESIIMPORT _obj_SMHR_ESIIMPORT = new SMHR_ESIIMPORT();
            _obj_SMHR_ESIIMPORT.Mode = 2;

            _obj_SMHR_ESIIMPORT.ESIIMPORT_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            DataTable DT = BLL.get_ESIimport(_obj_SMHR_ESIIMPORT);
            if (DT.Rows.Count != 0)
            {
              


                rcmb_BUI.SelectedIndex = rcmb_BUI.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["ESIIMPORT_BUID"]));

                RCM_FINANCIALPERIOD.SelectedIndex = RCM_FINANCIALPERIOD.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["ESIIMPORT_FINANCIAL_PERIOD"]));



                SMHR_PAYROLL _obj_smhr_payroll = new SMHR_PAYROLL();
                _obj_smhr_payroll.PERIODDTLID = Convert.ToInt32(RCM_FINANCIALPERIOD.SelectedValue);
                _obj_smhr_payroll.MODE = 11;
                DataTable dt_Details = new DataTable();
                dt_Details = BLL.get_payrolltrans(_obj_smhr_payroll);
                if (dt_Details.Rows.Count != 0)
                {
                    rcm_fin_elem.DataSource = dt_Details;
                    rcm_fin_elem.DataValueField = "PRDDTL_ID";
                    rcm_fin_elem.DataTextField = "PRDDTL_NAME";
                    rcm_fin_elem.DataBind();
                    rcm_fin_elem.Items.Insert(0, new RadComboBoxItem("Select"));
                }
                rcm_fin_elem.SelectedIndex = rcm_fin_elem.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["ESIIMPORT_PERIDEMLEMENTID"]));
                rg_importchild.DataSource = DT;
                rg_importchild.DataBind();
                for (int i = 0; i < rg_importchild.Items.Count; i++)
                {
                    Label LBLAMOUNT;
                    LBLAMOUNT = rg_importchild.Items[i].FindControl("lbl_IMPORTCHILD_TOTALAMOUNT") as Label;
                    Label LBLREASONCODE;
                    LBLREASONCODE = rg_importchild.Items[i].FindControl("lbl_IMPORTCHILD_reasoncode") as Label;

                    if (LBLAMOUNT.Text == "0")
                    {
                        LBLREASONCODE.Text = "1";
                    }
                    else
                    {
                        LBLREASONCODE.Text = "0";
                    }

                }
                rcm_fin_elem.Enabled = false;
                RCM_FINANCIALPERIOD.Enabled = false;
                btn_Save.Visible = false;
               
                lbl_esiimport.Visible = false;
                lbl_det.Visible = true;
                rcmb_BUI.Enabled = false;
                Rm_ESIIMPORT_PAGE.SelectedIndex = 1;

                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {


                    BTN_DOWNLOAD.Visible = false;

                }
                else
                {
                    BTN_DOWNLOAD.Visible = true;
                }
            }


        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_esiimport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion



    #region loadcombos,clear fields
    private void LoadCombos()
    {
        try
        {

            _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();


            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            if (dt_BUDetails.Rows.Count != 0)
            {
                rcmb_BUI.DataSource = dt_BUDetails;
                rcmb_BUI.DataValueField = "BUSINESSUNIT_ID";
                rcmb_BUI.DataTextField = "BUSINESSUNIT_CODE";
                rcmb_BUI.DataBind();
                rcmb_BUI.Items.Insert(0, new RadComboBoxItem("Select"));
                rcmb_BUI.SelectedIndex = 0;
               
            }

            else
            {
                DataTable dt_Details = new DataTable();
                rcmb_BUI.DataSource = dt_Details;

                rcmb_BUI.DataBind();
                rcmb_BUI.Items.Insert(0, new RadComboBoxItem("Select"));
            }
            SMHR_PERIOD _obj_smhr_period = new SMHR_PERIOD();
            DataTable dt_Details1 = new DataTable();
            _obj_smhr_period.OPERATION = operation.Select;
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //_obj_SMHR_LoginInfo.LOGIN_ID = 53;
            dt_Details1 = BLL.get_PeriodHeaderDetails(_obj_smhr_period);
            if (dt_Details1.Rows.Count != 0)
            {
                RCM_FINANCIALPERIOD.DataSource = dt_Details1;
                RCM_FINANCIALPERIOD.DataValueField = "PERIOD_ID";
                RCM_FINANCIALPERIOD.DataTextField = "PERIOD_NAME";
                RCM_FINANCIALPERIOD.DataBind();
                RCM_FINANCIALPERIOD.Items.Insert(0, new RadComboBoxItem("Select"));
                RCM_FINANCIALPERIOD.SelectedIndex = 0;
            }
            else
            {
                DataTable dt_Details2 = new DataTable();
                RCM_FINANCIALPERIOD.DataSource = dt_Details2;

                RCM_FINANCIALPERIOD.DataBind();
                RCM_FINANCIALPERIOD.Items.Insert(0, new RadComboBoxItem("Select"));

            }

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_esiimport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

   
    #endregion

     


    protected void RCM_FINANCIALPERIOD_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_BUI.SelectedItem.Text != "Select")
            {
                if (RCM_FINANCIALPERIOD.SelectedItem.Text != "Select")
                {

                    SMHR_PAYROLL _obj_smhr_payroll = new SMHR_PAYROLL();
                    if (RCM_FINANCIALPERIOD.SelectedItem.Value != "")
                    {

                        _obj_smhr_payroll.PERIODDTLID = Convert.ToInt32(RCM_FINANCIALPERIOD.SelectedValue);
                    }
                    else
                    {
                        _obj_smhr_payroll.PERIODDTLID = 0;
                    }
                    _obj_smhr_payroll.MODE = 11;
                    DataTable dt_Details = new DataTable();
                    dt_Details = BLL.get_payrolltrans(_obj_smhr_payroll);
                    if (dt_Details.Rows.Count != 0)
                    {
                        rcm_fin_elem.DataSource = dt_Details;
                        rcm_fin_elem.DataValueField = "PRDDTL_ID";
                        rcm_fin_elem.DataTextField = "PRDDTL_NAME";
                        rcm_fin_elem.DataBind();
                        rcm_fin_elem.Items.Insert(0, new RadComboBoxItem("Select"));
                    }

                    else
                    {
                        DataTable dt_Details2 = new DataTable();
                        rcm_fin_elem.DataSource = dt_Details2;

                        rcm_fin_elem.DataBind();
                        rcm_fin_elem.Items.Insert(0, new RadComboBoxItem("Select"));

                    }
                    finelem_id.Visible = true;
                    rg_importchild.Visible = false;
                    BTN_DOWNLOAD.Visible = false;
                }
                else
                {
                    BLL.ShowMessage(this, "Select Financial Period");
                    finelem_id.Visible = false;
                    rg_importchild.Visible = false;
                    BTN_DOWNLOAD.Visible = false;
                    return;


                }
            }

            else
            {
                BLL.ShowMessage(this, "Select Business Unit");
                RCM_FINANCIALPERIOD.SelectedIndex = 0;
                return;

            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_esiimport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #region import methods


    protected void RadGrid1_ExcelMLExportStyles(object source, GridExportExcelMLStyleCreatedArgs e)
    {
        try
        {
        foreach (Telerik.Web.UI.GridExcelBuilder.StyleElement style in e.Styles)
        {
            if (style.Id == "headerStyle")
            {
                style.FontStyle.Bold = true;
                style.FontStyle.Color = System.Drawing.Color.CadetBlue;
                style.InteriorStyle.Color = System.Drawing.Color.Wheat;
                style.InteriorStyle.Pattern = Telerik.Web.UI.GridExcelBuilder.InteriorPatternType.Solid;
            }
            else if (style.Id == "itemStyle")
            {
                style.InteriorStyle.Color = System.Drawing.Color.WhiteSmoke;
                style.InteriorStyle.Pattern = Telerik.Web.UI.GridExcelBuilder.InteriorPatternType.Solid;
            }
            else if (style.Id == "alternatingItemStyle")
            {
                style.InteriorStyle.Color = System.Drawing.Color.LightGray;
                style.InteriorStyle.Pattern = Telerik.Web.UI.GridExcelBuilder.InteriorPatternType.Solid;
            }
        }

        Telerik.Web.UI.GridExcelBuilder.StyleElement myStyle = new Telerik.Web.UI.GridExcelBuilder.StyleElement("MyCustomStyle");
        myStyle.FontStyle.Bold = true;
        myStyle.FontStyle.Italic = true;
        myStyle.InteriorStyle.Color = System.Drawing.Color.LightGray;
        myStyle.InteriorStyle.Pattern = Telerik.Web.UI.GridExcelBuilder.InteriorPatternType.Solid;
        e.Styles.Add(myStyle);

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_esiimport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void RadGrid1_ExcelMLExportRowCreated(object source, Telerik.Web.UI.GridExcelBuilder.GridExportExcelMLRowCreatedArgs e)
    {
        if (e.RowType == Telerik.Web.UI.GridExcelBuilder.GridExportExcelMLRowType.DataRow)
        {
            if (e.Row.Cells[0] != null && ((string)e.Row.Cells[0].Data.DataItem).Contains("U"))
            {
                e.Row.Cells[0].StyleValue = "MyCustomStyle";
            }
        }
    }

    protected void BTN_DOWNLOAD_Click(object sender, EventArgs e)
    {try
    {
        rg_importchild.ExportSettings.Excel.Format = Telerik.Web.UI.GridExcelExportFormat.ExcelML;
        rg_importchild.ExportSettings.IgnorePaging = true;
        rg_importchild.ExportSettings.ExportOnlyData = true;
       // rg_importchild.ExportSettings.OpenInNewWindow = true;
        rg_importchild.MasterTableView.ExportToExcel();

    }

    catch (Exception ex)
    {
        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_esiimport", ex.StackTrace, DateTime.Now);
        Response.Redirect("~/Frm_ErrorPage.aspx");
    }
    }
    #endregion
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
        for (int i = 0; i < rg_importchild.Items.Count; i++)
        {
            Label LBLEMPLOYEE;
            LBLEMPLOYEE = rg_importchild.Items[i].FindControl("lbl_EMPLOYEE_NAME") as Label;
            Label LBLIPNO;
            LBLIPNO = rg_importchild.Items[i].FindControl("lbl_IMPORTCHILD_IPNUMBER") as Label;
            Label LBLIPNAME;
            LBLIPNAME = rg_importchild.Items[i].FindControl("lbl_IMPORTCHILD_IPNAME") as Label;
            Label LBLPRESENTDAYS;
            LBLPRESENTDAYS = rg_importchild.Items[i].FindControl("lbl_IMPORTCHILD_presentdays") as Label;
            Label LBLTOTALAMOUNT;
            LBLTOTALAMOUNT = rg_importchild.Items[i].FindControl("lbl_IMPORTCHILD_TOTALAMOUNT") as Label;

            Label LBLREASONCODE;
            LBLREASONCODE = rg_importchild.Items[i].FindControl("lbl_IMPORTCHILD_reasoncode") as Label;
            SMHR_ESIIMPORT _obj_SMHR_ESIIMPORT = new SMHR_ESIIMPORT();
            _obj_SMHR_ESIIMPORT.Mode = 3;
            _obj_SMHR_ESIIMPORT.ESIIMPORT_BUID = Convert.ToInt32(rcmb_BUI.SelectedItem.Value);
            _obj_SMHR_ESIIMPORT.ESIIMPORT_ORGID = Convert.ToInt32(Session["org_id"]);
            _obj_SMHR_ESIIMPORT.ESIIMPORT_FINANCIAL_PERIOD = Convert.ToInt32(RCM_FINANCIALPERIOD.SelectedItem.Value);
            _obj_SMHR_ESIIMPORT.ESIIMPORT_PERIDEMLEMENTID = Convert.ToInt32(rcm_fin_elem.SelectedItem.Value);
            _obj_SMHR_ESIIMPORT.ESIIMPORT_EMPNAME = Convert.ToString(LBLEMPLOYEE.Text);
            _obj_SMHR_ESIIMPORT.ESIIMPORT_IPNO = Convert.ToString(LBLIPNO.Text);
            _obj_SMHR_ESIIMPORT.ESIIMPORT_IPNAME = Convert.ToString(LBLIPNAME.Text);
            _obj_SMHR_ESIIMPORT.ESIIMPORT_PRESENTDAYS = Convert.ToInt32(LBLPRESENTDAYS.Text);
            _obj_SMHR_ESIIMPORT.ESIIMPORT_TOTALAMOUNT = Convert.ToString(LBLTOTALAMOUNT.Text);
            _obj_SMHR_ESIIMPORT.ESIIMPORT_REASONCODE = Convert.ToInt32(LBLREASONCODE.Text);
            bool status = BLL.set_ESIimport(_obj_SMHR_ESIIMPORT);
            if (status == true)
            {
                BLL.ShowMessage(this, "Record Inserted Successfully");
                Rm_ESIIMPORT_PAGE.SelectedIndex = 0;
                LoadMainGrid();
                lbl_det.Visible = false;
                lbl_esiimport.Visible = true;
                return;

            }

            
          


        }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_esiimport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


    }
    protected void rcm_fin_elem_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
        if ((RCM_FINANCIALPERIOD.SelectedItem.Text != "Select") && (rcmb_BUI.SelectedItem.Text != "Select") && (rcm_fin_elem.SelectedItem.Text != "Select"))
        {
            LoadchildGrid();
            for (int i = 0; i < rg_importchild.Items.Count; i++)
            {
                Label LBLAMOUNT;
                LBLAMOUNT = rg_importchild.Items[i].FindControl("lbl_IMPORTCHILD_TOTALAMOUNT") as Label;
                Label LBLREASONCODE;
                LBLREASONCODE = rg_importchild.Items[i].FindControl("lbl_IMPORTCHILD_reasoncode") as Label;

                if (LBLAMOUNT.Text == "0")
                {
                    LBLREASONCODE.Text = "1";
                }
                else
                {
                    LBLREASONCODE.Text = "0";
                }

            }

            rg_importchild.Visible = true;
            finelem_id.Visible = true;
            
        }

        else
        {
            BLL.ShowMessage(this, "Select Item");

            rg_importchild.Visible = false;
            
            return;
        }

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_esiimport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

   

   
}
