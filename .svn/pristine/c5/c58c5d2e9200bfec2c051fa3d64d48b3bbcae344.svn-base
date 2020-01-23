using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Text;
using System.Collections;
using Telerik.Web.UI;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Data;

public partial class Security_frm_securityprivilages : System.Web.UI.Page
{
    SMHR_LOGINTYPE _obj_LoginType;
    SMHR_LOGININFO _obj_LoginInfo;
    static string track = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                lbl_AssignSecurity.Text = "Assign Privilege";
                Rm_AssignSecurity.SelectedIndex = 0;
                LoadGrid();
                if (Convert.ToString(Session["FILTER"]) != string.Empty)
                {
                    Rg_AssignSecurity.MasterTableView.FilterExpression = Session["FILTER"].ToString();
                    //foreach (GridColumn column in Rg_AssignSecurity.MasterTableView.RenderColumns)
                    //{
                    //    if (column.SupportsFiltering())
                    //    {
                    //        column.FilterControlAltText = Session["FILTER"].ToString();
                    //    }
                    //}
                    //                 Rg_AssignSecurity.MasterTableView.
                    Rg_AssignSecurity.Rebind();
                }
                Rg_AssignSecurity.DataBind();
                Session.Remove("FILTER");
                Page.Validate();

                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Assign Privilages");//SECURITY_RIVILAGES");
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

                if (Convert.ToInt32(Session["EMP_ID"]) != (-1))
                {
                    if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                    {
                        Rg_AssignSecurity.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                        btn_Save.Visible = false;
                        btn_Update.Visible = false;
                    }
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
                    btn_Save.Visible = true;
                    btn_Update.Visible = true;
                }

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_securityprivilages", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }


    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            Session["FILTER"] = Rg_AssignSecurity.MasterTableView.FilterExpression;
            lbl_AssignSecurity.Text = "Assign Privilege Details";
            //loadDropdown();
            track = "Add";
            clearControls();
            btn_Cancel.Visible = true;
            Rm_AssignSecurity.SelectedIndex = 1;
            rcmb_Usergroup.Enabled = true;
            rcmb_Usergroup.SelectedIndex = -1;
            rcmb_Usergroup.Items.Clear();
            rcmb_Organisation.SelectedIndex = -1;
            rcmb_Organisation.Enabled = true;
            rcmb_Module.Enabled = true;
            loadDropdown();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_securityprivilages", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    protected void lnk_edit_command(object sender, CommandEventArgs e)
    {
        try
        {
            Session["FILTER"] = Rg_AssignSecurity.MasterTableView.FilterExpression;
            lbl_AssignSecurity.Text = "Assign Privilege Details";
            loadDropdown();
            track = "Edit";
            _obj_LoginType = new SMHR_LOGINTYPE();
            //_obj_LoginType.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);//0 ;
            _obj_LoginType.OPERATION = operation.Select2;
            _obj_LoginType.LOGTYP_ID = Convert.ToInt32(e.CommandArgument);
            DataTable dt = BLL.get_LoginType(_obj_LoginType);
            rcmb_Organisation.SelectedIndex = rcmb_Organisation.Items.FindItemIndexByValue(dt.Rows[0]["ORGANISATION_ID"].ToString());
            rcmb_Organisation.Enabled = false;
            if (Convert.ToInt32(Session["EMP_ID"]) == (-1))
            {
                rcmb_Usergroup.Items.Clear();
                _obj_LoginType = new SMHR_LOGINTYPE();
                _obj_LoginType.ORGANISATION_ID = Convert.ToInt32(rcmb_Organisation.SelectedValue); ;// Convert.ToInt32(Session["ORG_ID"]);
                _obj_LoginType.OPERATION = operation.Select;
                DataTable dt_usergroup = BLL.get_LoginType(_obj_LoginType);
                rcmb_Usergroup.DataSource = dt_usergroup;
                rcmb_Usergroup.DataTextField = "LOGTYP_CODE";
                rcmb_Usergroup.DataValueField = "LOGTYP_ID";
                rcmb_Usergroup.DataBind();
                rcmb_Usergroup.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                //rcmb_Usergroup.SelectedIndex = rcmb_Usergroup.FindItemIndexByValue(dt.Rows[0]["LOGTYP_CODE"].ToString());
            }
            rcmb_Usergroup.SelectedIndex = rcmb_Usergroup.Items.FindItemIndexByValue(Convert.ToString(e.CommandArgument));
            rcmb_Module.Items.Clear();
            //SMHR_FORMS _obj_Smhr_forms = new SMHR_FORMS();
            //_obj_Smhr_forms.MODE = 2;
            //rcmb_Module.DataSource = BLL.get_Modules(_obj_Smhr_forms);
            //rcmb_Module.DataTextField = "SMHR_MODULE_NAME";
            //rcmb_Module.DataValueField = "SMHR_MODULE_ID";
            //rcmb_Module.DataBind();
            //rcmb_Module.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            //rcmb_sup_module.Items.Clear();
            //TO LOAD SUPER MODULES
            SMHR_FORMS _obj_Smhr_forms = new SMHR_FORMS();
            _obj_Smhr_forms.MODE = 7;

            if (Convert.ToInt32(Session["EMP_ID"]) == (-1))
            {
                _obj_Smhr_forms.ORGANISATION_ID = Convert.ToInt32(rcmb_Organisation.SelectedItem.Value);
            }
            else
            {
                _obj_Smhr_forms.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            }
            rcmb_sup_module.DataSource = BLL.get_Modules(_obj_Smhr_forms);
            rcmb_sup_module.DataTextField = "SMHR_SUP_MODULE_NAME";
            rcmb_sup_module.DataValueField = "SMHR_SUP_MODULE_ID";
            rcmb_sup_module.DataBind();
            rcmb_sup_module.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            module_id.Visible = false;
            super_module_id.Visible = true;
            Rm_AssignSecurity.SelectedIndex = 1;
            btn_Cancel.Visible = true;
            rcmb_Usergroup.Enabled = false;
            rcmb_Module.Enabled = true;


            btn_Save.Visible = false;
            btn_Update.Visible = false;
            Rg_Securitygrid.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_securityprivilages", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void clearControls()
    {
        try
        {
            Rg_Securitygrid.Visible = false;
            btn_Save.Visible = false;
            btn_Update.Visible = false;


            module_id.Visible = false;
            super_module_id.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_securityprivilages", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    public void LoadGrid()
    {
        try
        {
            //SMHR_TYPESECURITY _obj_Smhr_TypeSecurity = new SMHR_TYPESECURITY();
            //_obj_Smhr_TypeSecurity.OPERATION = operation.Select3;

            //DataTable DT = BLL.get_AssignPrivilage(_obj_Smhr_TypeSecurity);
            //if (DT.Rows.Count != 0)
            //{

            //    Rg_AssignSecurity.DataSource = DT;

            //}
            //else
            //{
            //    DataTable dtemptytable = new DataTable();
            //    Rg_AssignSecurity.DataSource = dtemptytable;
            //}
            if (Convert.ToInt32(Session["EMP_ID"]) != (-1))
            {
                _obj_LoginType = new SMHR_LOGINTYPE();
                _obj_LoginType.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_LoginType.OPERATION = operation.Select;
                DataTable dt = BLL.get_LoginType(_obj_LoginType);
                if (dt.Rows.Count != 0)
                {

                    Rg_AssignSecurity.DataSource = dt;

                }
                else
                {
                    DataTable dtemptytable = new DataTable();
                    Rg_AssignSecurity.DataSource = dtemptytable;
                }
            }
            else
            {
                _obj_LoginType = new SMHR_LOGINTYPE();
                //_obj_LoginType.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);//0 ;
                _obj_LoginType.OPERATION = operation.Select1;
                DataTable dt = BLL.get_LoginType(_obj_LoginType);
                if (dt.Rows.Count != 0)
                {

                    Rg_AssignSecurity.DataSource = dt;

                }
                else
                {
                    DataTable dtemptytable = new DataTable();
                    Rg_AssignSecurity.DataSource = dtemptytable;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_securityprivilages", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void Rg_AssignSecurity_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_securityprivilages", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void loadDropdown()
    {
        try
        {
            if (Convert.ToInt32(Session["EMP_ID"]) == (-1))
            {

                SMHR_ORGANISATION _obj_Organisation = new SMHR_ORGANISATION();
                _obj_Organisation.MODE = 1;
                DataTable dtorg = BLL.get_Organisation(_obj_Organisation);
                rcmb_Organisation.DataSource = dtorg;
                rcmb_Organisation.DataTextField = "ORGANISATION_NAME";
                rcmb_Organisation.DataValueField = "ORGANISATION_ID";
                rcmb_Organisation.DataBind();
                rcmb_Organisation.Items.Insert(0, new RadComboBoxItem("Select"));
            }
            else
            {
                _obj_LoginInfo = new SMHR_LOGININFO();
                _obj_LoginInfo.OPERATION = operation.Login1;
                _obj_LoginInfo.LOGIN_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_logindetails = BLL.get_Logindetails(_obj_LoginInfo);
                rcmb_Organisation.DataSource = dt_logindetails;
                rcmb_Organisation.DataTextField = "organisation_name";
                rcmb_Organisation.DataValueField = "organisation_id";
                rcmb_Organisation.DataBind();
                //rcmb_Organisation.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                rcmb_Organisation.SelectedIndex = rcmb_Organisation.FindItemIndexByValue(dt_logindetails.Rows[0]["ORGANISATION_ID"].ToString());

                //to load user groups
                rcmb_Usergroup.Items.Clear();
                _obj_LoginType = new SMHR_LOGINTYPE();
                _obj_LoginType.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_LoginType.OPERATION = operation.Select;
                DataTable dt = BLL.get_LoginType(_obj_LoginType);
                rcmb_Usergroup.DataSource = dt;
                rcmb_Usergroup.DataTextField = "LOGTYP_CODE";
                rcmb_Usergroup.DataValueField = "LOGTYP_ID";
                rcmb_Usergroup.DataBind();
                rcmb_Usergroup.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }

            //if (Convert.ToInt32(Session["EMP_ID"]) != (-1))
            //{
            //    rcmb_Usergroup.Items.Clear();
            //    _obj_LoginType = new SMHR_LOGINTYPE();
            //    _obj_LoginType.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //    _obj_LoginType.OPERATION = operation.Select;
            //    DataTable dt = BLL.get_LoginType(_obj_LoginType);
            //    rcmb_Usergroup.DataSource = dt;
            //    rcmb_Usergroup.DataTextField = "LOGTYP_CODE";
            //    rcmb_Usergroup.DataValueField = "LOGTYP_ID";
            //    rcmb_Usergroup.DataBind();
            //    rcmb_Usergroup.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            //}
            //else
            //{
            //    rcmb_Usergroup.Items.Clear();
            //    _obj_LoginType = new SMHR_LOGINTYPE();
            //    _obj_LoginType.ORGANISATION_ID = 0;// Convert.ToInt32(Session["ORG_ID"]);
            //    _obj_LoginType.OPERATION = operation.Select;
            //    DataTable dt = BLL.get_LoginType(_obj_LoginType);
            //    rcmb_Usergroup.DataSource = dt;
            //    rcmb_Usergroup.DataTextField = "LOGTYP_CODE";
            //    rcmb_Usergroup.DataValueField = "LOGTYP_ID";
            //    rcmb_Usergroup.DataBind();
            //    rcmb_Usergroup.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            //    //rcmb_Usergroup.SelectedIndex = rcmb_Usergroup.FindItemIndexByValue(dt.Rows[0]["LOGTYP_CODE"].ToString());
            //}


            //method to get module names

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_securityprivilages", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_Usergroup_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Usergroup.SelectedItem.Text != "Select")
            {

                rcmb_sup_module.Items.Clear();
                SMHR_FORMS _obj_Smhr_forms = new SMHR_FORMS();
                _obj_Smhr_forms.MODE = 7;
                if (Convert.ToInt32(Session["EMP_ID"]) == (-1))
                {
                    _obj_Smhr_forms.ORGANISATION_ID = Convert.ToInt32(rcmb_Organisation.SelectedItem.Value);
                }
                else
                {
                    _obj_Smhr_forms.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                }
                rcmb_sup_module.DataSource = BLL.get_Modules(_obj_Smhr_forms);
                rcmb_sup_module.DataTextField = "SMHR_SUP_MODULE_NAME";
                rcmb_sup_module.DataValueField = "SMHR_SUP_MODULE_ID";
                rcmb_sup_module.DataBind();
                rcmb_sup_module.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                //module_id.Visible = true;
                super_module_id.Visible = true;
            }

            else
            {

                BLL.ShowMessage(this, "Please Select User Group");
                module_id.Visible = false;
                super_module_id.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_securityprivilages", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void rcmb_Module_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Module.SelectedItem.Text != "Select")
            {
                //if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                //{
                //    btn_Save.Visible = false;

                //}

                //else
                //{
                //    btn_Save.Visible = true;
                //}

                //btn_Cancel.Visible = true;
                //SMHR_TYPESECURITY _obj_Smhr_TypeSecurity = new SMHR_TYPESECURITY();

                //_obj_Smhr_TypeSecurity.TYPSEC_LOGTYP_ID = Convert.ToInt32(rcmb_Usergroup.SelectedItem.Value);
                //_obj_Smhr_TypeSecurity.MODULE_ID = Convert.ToInt32(rcmb_Module.SelectedItem.Value);
                //_obj_Smhr_TypeSecurity.OPERATION = operation.Select2;
                //DataTable dtexist = BLL.get_AssignPrivilage(_obj_Smhr_TypeSecurity);
                //if (dtexist.Rows.Count != 0)
                //{

                //    Rg_Securitygrid.DataSource = dtexist;
                //    Rg_Securitygrid.DataBind();
                //    Rg_Securitygrid.Visible = true;
                //    btn_Save.Visible = false;
                //    btn_Cancel.Visible = true;
                //    if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                //    {
                //        btn_Update.Visible = false;

                //    }

                //    else
                //    {
                //        btn_Update.Visible = true;
                //    }

                //    rcmb_Usergroup.Enabled = false;
                //    rcmb_Module.Enabled = false;

                //    RadioButton Chk_FullControl = new RadioButton();

                //    RadioButton Chk_View = new RadioButton();
                //    RadioButton Chk_NotApplicable = new RadioButton();

                //    for (int i = 0; i <= Rg_Securitygrid.Items.Count - 1; i++)
                //    {
                //        Chk_FullControl = Rg_Securitygrid.Items[i].FindControl("Chk_FullControl") as RadioButton;
                //        Chk_View = Rg_Securitygrid.Items[i].FindControl("Chk_View") as RadioButton;
                //        Chk_NotApplicable = Rg_Securitygrid.Items[i].FindControl("Chk_NotApplicable") as RadioButton;
                //        if ((Convert.ToBoolean(dtexist.Rows[i]["TYPSEC_READ"]) == true) && (Convert.ToBoolean(dtexist.Rows[i]["TYPSEC_WRITE"]) == true))
                //        {
                //            Chk_FullControl.Checked = true;
                //        }

                //        if ((Convert.ToBoolean(dtexist.Rows[i]["TYPSEC_READ"]) == true) && (Convert.ToBoolean(dtexist.Rows[i]["TYPSEC_WRITE"]) == false))
                //        {
                //            Chk_View.Checked = true;
                //        }

                //        if ((Convert.ToBoolean(dtexist.Rows[i]["TYPSEC_READ"]) == false) && (Convert.ToBoolean(dtexist.Rows[i]["TYPSEC_WRITE"]) == false))
                //        {
                //            Chk_NotApplicable.Checked = true;
                //        }
                //    }



                //}

                //else
                //{

                if (Convert.ToInt32(Session["EMP_ID"]) != (-1))
                {
                    if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                    {
                        Rg_AssignSecurity.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                        btn_Save.Visible = false;
                        btn_Update.Visible = false;
                    }
                    else
                    {
                        if (track == "Add")
                        {
                            btn_Save.Visible = true;
                        }
                        else
                        {
                            btn_Update.Visible = true;
                        }


                    }
                }
                else
                {
                    if (track == "Add")
                    {
                        btn_Save.Visible = true;
                    }
                    else
                    {
                        btn_Update.Visible = true;
                    }
                }




                SMHR_FORMS _obj_Smhr_forms = new SMHR_FORMS();

                _obj_Smhr_forms.OPERATION = operation.Validate;
                _obj_Smhr_forms.FORMS_MODULE_ID = Convert.ToInt32(rcmb_Module.SelectedItem.Value);
                DataTable dtforms = BLL.get_FormsbyModule(_obj_Smhr_forms);
                if (dtforms.Rows.Count != 0)
                {
                    Rg_Securitygrid.DataSource = dtforms;
                    Rg_Securitygrid.DataBind();
                    Rg_Securitygrid.Visible = true;





                    SMHR_TYPESECURITY _obj_Smhr_TypeSecurity = new SMHR_TYPESECURITY();

                    _obj_Smhr_TypeSecurity.TYPSEC_LOGTYP_ID = Convert.ToInt32(rcmb_Usergroup.SelectedItem.Value);
                    _obj_Smhr_TypeSecurity.MODULE_ID = Convert.ToInt32(rcmb_Module.SelectedItem.Value);
                    _obj_Smhr_TypeSecurity.OPERATION = operation.Select2;
                    DataTable dtexist = BLL.get_AssignPrivilage(_obj_Smhr_TypeSecurity);
                    if (dtexist.Rows.Count != 0)
                    {
                        btn_Save.Visible = false;
                        btn_Update.Visible = true;

                        for (int J = 0; J <= dtexist.Rows.Count - 1; J++)
                        {
                            Label lblformid = new Label();
                            RadioButton Chk_FullControl = new RadioButton();
                            RadioButton Chk_View = new RadioButton();
                            RadioButton Chk_NotApplicable = new RadioButton();

                            for (int i = 0; i <= Rg_Securitygrid.Items.Count - 1; i++)
                            {
                                lblformid = Rg_Securitygrid.Items[i].FindControl("LBL_form_ID") as Label;
                                Chk_FullControl = Rg_Securitygrid.Items[i].FindControl("Chk_FullControl") as RadioButton;
                                Chk_View = Rg_Securitygrid.Items[i].FindControl("Chk_View") as RadioButton;
                                Chk_NotApplicable = Rg_Securitygrid.Items[i].FindControl("Chk_NotApplicable") as RadioButton;

                                if (Convert.ToInt32(lblformid.Text) == Convert.ToInt32(dtexist.Rows[J]["TYPSEC_FORMS_ID"]))
                                {
                                    if ((Convert.ToBoolean(dtexist.Rows[J]["TYPSEC_READ"]) == true) && (Convert.ToBoolean(dtexist.Rows[J]["TYPSEC_WRITE"]) == true))
                                    {
                                        Chk_FullControl.Checked = true;
                                    }
                                    if ((Convert.ToBoolean(dtexist.Rows[J]["TYPSEC_READ"]) == true) && (Convert.ToBoolean(dtexist.Rows[J]["TYPSEC_WRITE"]) == false))
                                    {
                                        Chk_View.Checked = true;
                                    }

                                    if ((Convert.ToBoolean(dtexist.Rows[J]["TYPSEC_READ"]) == false) && (Convert.ToBoolean(dtexist.Rows[J]["TYPSEC_WRITE"]) == false))
                                    {
                                        Chk_NotApplicable.Checked = true;
                                    }
                                    break;
                                }


                            }
                        }



                    }
                    else
                    {
                        btn_Save.Visible = true;
                        btn_Update.Visible = false;
                        rcmb_Usergroup.Enabled = false;
                        rcmb_Module.Enabled = false;

                        RadioButton Chk_NotApplicable = new RadioButton();
                        for (int i = 0; i <= Rg_Securitygrid.Items.Count - 1; i++)
                        {
                            Chk_NotApplicable = Rg_Securitygrid.Items[i].FindControl("Chk_NotApplicable") as RadioButton;
                            Chk_NotApplicable.Checked = true;
                        }

                    }









                }

                else
                {
                    DataTable dtempty = new DataTable();
                    Rg_Securitygrid.DataSource = dtempty;
                    Rg_Securitygrid.DataBind();
                    Rg_Securitygrid.Visible = true;
                    btn_Cancel.Visible = true;
                    btn_Save.Visible = false;

                }




                //}
            }
            else
            {

                BLL.ShowMessage(this, "Please Select Module");
                Rg_Securitygrid.Visible = false;
                btn_Save.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_securityprivilages", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            lbl_AssignSecurity.Text = "Assign Privilege";
            LoadGrid();
            Rg_AssignSecurity.DataBind();
            Rm_AssignSecurity.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_securityprivilages", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    //protected void Rg_Securitygrid_PageSizeChanged(object source, Telerik.Web.UI.GridPageSizeChangedEventArgs e)
    //{
    //    //SMHR_FORMS _obj_Smhr_forms = new SMHR_FORMS();
    //    //_obj_Smhr_forms.OPERATION = operation.Validate;
    //    //_obj_Smhr_forms.FORMS_MODULE_ID = Convert.ToInt32(rcmb_Module.SelectedItem.Value);
    //    //DataTable dtforms = BLL.get_FormsbyModule(_obj_Smhr_forms);

    //    //    Rg_Securitygrid.DataSource = dtforms;
    //    //    Rg_Securitygrid.DataBind();
    //    //    Rg_Securitygrid.Visible = true;
    //    //    btn_Save.Visible = true;
    //    //    btn_Cancel.Visible = true;

    //}



    #region checked changed events
    protected void Full_Check_Changed(object sender, EventArgs e)
    {
        try
        {
            RadioButton Chk_FullControl = new RadioButton();

            RadioButton Chk_View = new RadioButton();
            RadioButton Chk_NotApplicable = new RadioButton();

            for (int i = 0; i <= Rg_Securitygrid.Items.Count - 1; i++)
            {
                Chk_FullControl = Rg_Securitygrid.Items[i].FindControl("Chk_FullControl") as RadioButton;
                Chk_FullControl.Checked = true;

                Chk_View = Rg_Securitygrid.Items[i].FindControl("Chk_View") as RadioButton;
                Chk_View.Checked = false;
                Chk_NotApplicable = Rg_Securitygrid.Items[i].FindControl("Chk_NotApplicable") as RadioButton;
                Chk_NotApplicable.Checked = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_securityprivilages", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void view_Check_Changed(object sender, EventArgs e)
    {
        try
        {
            RadioButton Chk_FullControl = new RadioButton();

            RadioButton Chk_View = new RadioButton();
            RadioButton Chk_NotApplicable = new RadioButton();
            for (int i = 0; i <= Rg_Securitygrid.Items.Count - 1; i++)
            {
                Chk_FullControl = Rg_Securitygrid.Items[i].FindControl("Chk_FullControl") as RadioButton;
                Chk_FullControl.Checked = false;

                Chk_View = Rg_Securitygrid.Items[i].FindControl("Chk_View") as RadioButton;
                Chk_View.Checked = true;
                Chk_NotApplicable = Rg_Securitygrid.Items[i].FindControl("Chk_NotApplicable") as RadioButton;
                Chk_NotApplicable.Checked = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_securityprivilages", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void NotApplicate_Check_Changed(object sender, EventArgs e)
    {
        try
        {
            RadioButton Chk_FullControl = new RadioButton();

            RadioButton Chk_View = new RadioButton();
            RadioButton Chk_NotApplicable = new RadioButton();
            for (int i = 0; i <= Rg_Securitygrid.Items.Count - 1; i++)
            {
                Chk_FullControl = Rg_Securitygrid.Items[i].FindControl("Chk_FullControl") as RadioButton;
                Chk_FullControl.Checked = false;

                Chk_View = Rg_Securitygrid.Items[i].FindControl("Chk_View") as RadioButton;
                Chk_View.Checked = false;
                Chk_NotApplicable = Rg_Securitygrid.Items[i].FindControl("Chk_NotApplicable") as RadioButton;
                Chk_NotApplicable.Checked = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_securityprivilages", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    #endregion

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            RadioButton Chk_FullControl = new RadioButton();

            RadioButton Chk_View = new RadioButton();
            RadioButton Chk_NotApplicable = new RadioButton();
            Label lbl_form_id = new Label();
            SMHR_TYPESECURITY _obj_Smhr_AssignPrivilage = new SMHR_TYPESECURITY();

            _obj_Smhr_AssignPrivilage.TYPSEC_LOGTYP_ID = Convert.ToInt32(rcmb_Usergroup.SelectedItem.Value);

            _obj_Smhr_AssignPrivilage.MODULE_ID = Convert.ToInt32(rcmb_Module.SelectedItem.Value);
            _obj_Smhr_AssignPrivilage.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_AssignPrivilage.CREATEDDATE = DateTime.Now;

            _obj_Smhr_AssignPrivilage.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_AssignPrivilage.LASTMDFDATE = DateTime.Now;
            for (int i = 0; i <= Rg_Securitygrid.Items.Count - 1; i++)
            {
                Chk_FullControl = Rg_Securitygrid.Items[i].FindControl("Chk_FullControl") as RadioButton;
                lbl_form_id = Rg_Securitygrid.Items[i].FindControl("LBL_form_ID") as Label;
                Chk_View = Rg_Securitygrid.Items[i].FindControl("Chk_View") as RadioButton;
                Chk_NotApplicable = Rg_Securitygrid.Items[i].FindControl("Chk_NotApplicable") as RadioButton;


                _obj_Smhr_AssignPrivilage.TYPSEC_FORMS_ID = Convert.ToInt32(lbl_form_id.Text);

                if (Chk_FullControl.Checked)
                {
                    _obj_Smhr_AssignPrivilage.TYPSEC_READ = true;

                    _obj_Smhr_AssignPrivilage.TYPSEC_WRITE = true;
                }


                if (Chk_View.Checked)
                {
                    _obj_Smhr_AssignPrivilage.TYPSEC_READ = true;

                    _obj_Smhr_AssignPrivilage.TYPSEC_WRITE = false;
                }

                if (Chk_NotApplicable.Checked)
                {
                    _obj_Smhr_AssignPrivilage.TYPSEC_READ = false;

                    _obj_Smhr_AssignPrivilage.TYPSEC_WRITE = false;
                }

                if ((Chk_FullControl.Checked == false) && (Chk_View.Checked == false) && (Chk_NotApplicable.Checked == false))
                {
                    _obj_Smhr_AssignPrivilage.TYPSEC_READ = false;

                    _obj_Smhr_AssignPrivilage.TYPSEC_WRITE = false;
                }

                //to check a user group has been assigned selected froms or not
                _obj_Smhr_AssignPrivilage.OPERATION = operation.Check;
                _obj_Smhr_AssignPrivilage.TYPSEC_LOGTYP_ID = Convert.ToInt32(rcmb_Usergroup.SelectedItem.Value);
                _obj_Smhr_AssignPrivilage.TYPSEC_FORMS_ID = Convert.ToInt32(lbl_form_id.Text);
                _obj_Smhr_AssignPrivilage.SUPER_MODULE_ID = Convert.ToInt32(rcmb_sup_module.SelectedItem.Value);

                if (Convert.ToString(BLL.get_AssignPrivilage(_obj_Smhr_AssignPrivilage).Rows[0]["Count"]) != "0")
                {
                    BLL.ShowMessage(this, "This Combination of the Privilage Already Exists");
                    Rm_AssignSecurity.SelectedIndex = 0;
                    LoadGrid();
                    Rg_AssignSecurity.DataBind();
                    lbl_AssignSecurity.Text = "Assign Privilege";
                    return;
                }
                if (Convert.ToInt32(Session["EMP_ID"]) == (-1))
                {
                    _obj_Smhr_AssignPrivilage.TYPESEC_ORG_ID = Convert.ToInt32(rcmb_Organisation.SelectedItem.Value);
                }
                else
                {
                    _obj_Smhr_AssignPrivilage.TYPESEC_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                }
                _obj_Smhr_AssignPrivilage.OPERATION = operation.Insert;

                bool status = BLL.set_AssignPrivilage(_obj_Smhr_AssignPrivilage);

            }

            BLL.ShowMessage(this, "Record Inserted Successfully");
            Rm_AssignSecurity.SelectedIndex = 0;
            LoadGrid();
            Rg_AssignSecurity.DataBind();
            lbl_AssignSecurity.Text = "Assign Privilege";
            ScriptManager.RegisterStartupScript(this, GetType(), "refresh", "window.setTimeout('window.location.reload(true);',0000);", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_securityprivilages", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Update_Click(object sender, EventArgs e)
    {
        try
        {
            RadioButton Chk_FullControl = new RadioButton();

            RadioButton Chk_View = new RadioButton();
            RadioButton Chk_NotApplicable = new RadioButton();
            Label lbl_form_id = new Label();
            SMHR_TYPESECURITY _obj_Smhr_AssignPrivilage = new SMHR_TYPESECURITY();

            _obj_Smhr_AssignPrivilage.TYPSEC_LOGTYP_ID = Convert.ToInt32(rcmb_Usergroup.SelectedItem.Value);
            _obj_Smhr_AssignPrivilage.SUPER_MODULE_ID = Convert.ToInt32(rcmb_sup_module.SelectedItem.Value);
            _obj_Smhr_AssignPrivilage.MODULE_ID = Convert.ToInt32(rcmb_Module.SelectedItem.Value);
            _obj_Smhr_AssignPrivilage.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_AssignPrivilage.CREATEDDATE = DateTime.Now;
            if (Convert.ToInt32(Session["EMP_ID"]) == (-1))
            {
                _obj_Smhr_AssignPrivilage.TYPESEC_ORG_ID = Convert.ToInt32(rcmb_Organisation.SelectedItem.Value);
            }
            else
            {
                _obj_Smhr_AssignPrivilage.TYPESEC_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            }

            _obj_Smhr_AssignPrivilage.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_AssignPrivilage.LASTMDFDATE = DateTime.Now;
            for (int i = 0; i <= Rg_Securitygrid.Items.Count - 1; i++)
            {
                Chk_FullControl = Rg_Securitygrid.Items[i].FindControl("Chk_FullControl") as RadioButton;
                lbl_form_id = Rg_Securitygrid.Items[i].FindControl("LBL_form_ID") as Label;
                Chk_View = Rg_Securitygrid.Items[i].FindControl("Chk_View") as RadioButton;
                Chk_NotApplicable = Rg_Securitygrid.Items[i].FindControl("Chk_NotApplicable") as RadioButton;

                _obj_Smhr_AssignPrivilage.TYPSEC_FORMS_ID = Convert.ToInt32(lbl_form_id.Text);

                if (Chk_FullControl.Checked)
                {
                    _obj_Smhr_AssignPrivilage.TYPSEC_READ = true;

                    _obj_Smhr_AssignPrivilage.TYPSEC_WRITE = true;
                }

                if (Chk_View.Checked)
                {
                    _obj_Smhr_AssignPrivilage.TYPSEC_READ = true;

                    _obj_Smhr_AssignPrivilage.TYPSEC_WRITE = false;
                }

                if (Chk_NotApplicable.Checked)
                {
                    _obj_Smhr_AssignPrivilage.TYPSEC_READ = false;

                    _obj_Smhr_AssignPrivilage.TYPSEC_WRITE = false;
                }
                if ((Chk_FullControl.Checked == false) && (Chk_View.Checked == false) && (Chk_NotApplicable.Checked == false))
                {
                    _obj_Smhr_AssignPrivilage.TYPSEC_READ = false;

                    _obj_Smhr_AssignPrivilage.TYPSEC_WRITE = false;
                }

                //to check a user group has been assigned selected froms or not
                //_obj_Smhr_AssignPrivilage.OPERATION = operation.Check;
                //_obj_Smhr_AssignPrivilage.TYPSEC_LOGTYP_ID = Convert.ToInt32(rcmb_Usergroup.SelectedItem.Value);
                //_obj_Smhr_AssignPrivilage.TYPSEC_FORMS_ID = Convert.ToInt32(lbl_form_id.Text);
                //if (Convert.ToString(BLL.get_AssignPrivilage(_obj_Smhr_AssignPrivilage).Rows[0]["Count"]) !="0")
                //{
                //    BLL.ShowMessage(this, "This Combination of the Privilage Already Exists");
                //    Rm_AssignSecurity.SelectedIndex = 0;
                //    LoadGrid();
                //    Rg_AssignSecurity.DataBind();
                //    lbl_AssignSecurity.Text = "Assign Privilege";
                //    return;
                //}

                _obj_Smhr_AssignPrivilage.OPERATION = operation.Select3;

                bool status = BLL.set_AssignPrivilage(_obj_Smhr_AssignPrivilage);

            }

            BLL.ShowMessage(this, "Record Updated Successfully");
            Rm_AssignSecurity.SelectedIndex = 0;
            LoadGrid();
            Rg_AssignSecurity.DataBind();
            lbl_AssignSecurity.Text = "Assign Privilege";
            ScriptManager.RegisterStartupScript(this, GetType(), "refresh", "window.setTimeout('window.location.reload(true);',0000);", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_securityprivilages", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    protected void btn_Clear_Click(object sender, EventArgs e)
    {
        try
        {
            rcmb_Module.Enabled = true;
            RadioButton Chk_NotApplicable = new RadioButton();
            for (int i = 0; i <= Rg_Securitygrid.Items.Count - 1; i++)
            {
                Chk_NotApplicable = Rg_Securitygrid.Items[i].FindControl("Chk_NotApplicable") as RadioButton;
                Chk_NotApplicable.Checked = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_securityprivilages", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_Organisation_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            //if (Convert.ToInt32(Session["EMP_ID"]) != (-1))
            //{
            //    rcmb_Usergroup.Items.Clear();
            //    _obj_LoginType = new SMHR_LOGINTYPE();
            //    _obj_LoginType.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //    _obj_LoginType.OPERATION = operation.Select;
            //    DataTable dt = BLL.get_LoginType(_obj_LoginType);
            //    rcmb_Usergroup.DataSource = dt;
            //    rcmb_Usergroup.DataTextField = "LOGTYP_CODE";
            //    rcmb_Usergroup.DataValueField = "LOGTYP_ID";
            //    rcmb_Usergroup.DataBind();
            //    rcmb_Usergroup.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            //}
            //else
            //{
            rcmb_Usergroup.Items.Clear();
            _obj_LoginType = new SMHR_LOGINTYPE();
            _obj_LoginType.ORGANISATION_ID = Convert.ToInt32(rcmb_Organisation.SelectedValue); ;// Convert.ToInt32(Session["ORG_ID"]);
            _obj_LoginType.OPERATION = operation.Select;
            DataTable dt = BLL.get_LoginType(_obj_LoginType);
            rcmb_Usergroup.DataSource = dt;
            rcmb_Usergroup.DataTextField = "LOGTYP_CODE";
            rcmb_Usergroup.DataValueField = "LOGTYP_ID";
            rcmb_Usergroup.DataBind();
            rcmb_Usergroup.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            //rcmb_Usergroup.SelectedIndex = rcmb_Usergroup.FindItemIndexByValue(dt.Rows[0]["LOGTYP_CODE"].ToString());
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_securityprivilages", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_sup_module_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Usergroup.SelectedItem.Text != "Select")
            {
                rcmb_Module.Items.Clear();
                SMHR_FORMS _obj_Smhr_forms = new SMHR_FORMS();
                _obj_Smhr_forms.MODE = 2;
                _obj_Smhr_forms.FORMS_MODULE_ID = Convert.ToInt32(rcmb_sup_module.SelectedItem.Value);
                rcmb_Module.DataSource = BLL.get_Modules(_obj_Smhr_forms);
                rcmb_Module.DataTextField = "SMHR_MODULE_NAME";
                rcmb_Module.DataValueField = "SMHR_MODULE_ID";
                rcmb_Module.DataBind();
                rcmb_Module.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                module_id.Visible = true;
            }

            else
            {

                BLL.ShowMessage(this, "Please Select User Group");
                module_id.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_securityprivilages", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
}
