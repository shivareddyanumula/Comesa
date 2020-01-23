using System;
using System.Data;
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

public partial class Security_frm_userPrivileges : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                // Rm_AP_page.SelectedIndex = 0;
                LoadPackage();
                LoadModule();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_userPrivileges", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
      
    }
   
    protected void LoadPackage()
    {
        try
        {
            SMHR_ORGANISATION _obj_smhr_organisation = new SMHR_ORGANISATION();
            _obj_smhr_organisation.MODE = 7;
            rcmb_Package.Items.Clear();
            rcmb_Package.DataSource = BLL.get_Package(_obj_smhr_organisation);
            rcmb_Package.DataTextField = "smhr_Package_name";
            rcmb_Package.DataValueField = "smhr_package_id";
            rcmb_Package.DataBind();
            rcmb_Package.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_userPrivileges", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
      
    }
    protected void LoadModule()
    {
        try
        {
            SMHR_FORMS _obj_smhr_forms = new SMHR_FORMS();
            _obj_smhr_forms.MODE = 2;
            rcmb_Module.Items.Clear();
            rcmb_Module.DataSource = BLL.get_Modules(_obj_smhr_forms);
            rcmb_Module.DataTextField = "SMHR_MODULE_NAME";
            rcmb_Module.DataValueField = "SMHR_MODULE_ID";
            rcmb_Module.DataBind();
            rcmb_Module.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_userPrivileges", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
      
    }
    protected void rcmb_Module_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            SMHR_FORMS _obj_smhr_privileges = new SMHR_FORMS();
            _obj_smhr_privileges.MODE = 3;
            _obj_smhr_privileges.FORMS_PACKAGE_ID = Convert.ToInt32(rcmb_Package.SelectedItem.Value);
            _obj_smhr_privileges.FORMS_MODULE_ID = Convert.ToInt32(rcmb_Module.SelectedItem.Value);
            DataTable dt = new DataTable();
            dt = BLL.get_FormsbyModuleId(_obj_smhr_privileges);
            if (dt.Rows.Count > 0)
            {
                Rg_Privilege.DataSource = dt;
                Rg_Privilege.DataBind();

            }
            else
            {
                Rg_Privilege.DataSource = null;
                Rg_Privilege.DataBind();
                BLL.ShowMessage(this, "No Records Found");

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_userPrivileges", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
      
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            CheckBox chk_Read = new CheckBox();
            CheckBox chk_Write = new CheckBox();
            Label lblform = new Label();
            SMHR_USERPRIVILEGES smhr_userprivileges = new SMHR_USERPRIVILEGES();
            smhr_userprivileges.MODULE_ID = Convert.ToInt32(rcmb_Module.SelectedItem.Value);
            smhr_userprivileges.PACKAGE_ID = Convert.ToInt32(rcmb_Package.SelectedItem.Value);
            for (int i = 0; i < Rg_Privilege.Items.Count; i++)
            {


                chk_Read = Rg_Privilege.Items[i].FindControl("chkRead") as CheckBox;
                smhr_userprivileges.READ = Convert.ToBoolean(chk_Read.Checked);
                chk_Write = Rg_Privilege.Items[i].FindControl("chkWrite") as CheckBox;
                smhr_userprivileges.WRITE = Convert.ToBoolean(chk_Write.Checked);

                lblform = Rg_Privilege.Items[i].FindControl("lbl_Form") as Label;
                smhr_userprivileges.FORM_ID =Convert.ToInt32(lblform.Text);

                //smhr_userprivileges.FORM_ID = Convert.ToInt32(Rg_Privilege.Items[i].Cells[0].Text);
                smhr_userprivileges.OPERATION = operation.Insert;
                BLL.set_USERPRIVILEGES(smhr_userprivileges);
                BLL.ShowMessage(this, "Information Saved Successfully");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_userPrivileges", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
           
                         
                         
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            rcmb_Module.SelectedIndex = 0;
            rcmb_Package.SelectedIndex = 0;
            Rg_Privilege.DataSource = null;
            Rg_Privilege.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_userPrivileges", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
      
    }
    
  
    protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox chk;

            foreach (DataGridItem rowItem in Rg_Privilege.MasterTableView.Items)
            {
                chk = (CheckBox)(rowItem.Cells[3].FindControl("chkSelectAll"));
                chk.Checked = ((CheckBox)sender).Checked;

            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_userPrivileges", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
      
    }
    
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void ToggleRowSelection(object sender, EventArgs e)
        {
            try
            {
                ((sender as CheckBox).Parent.Parent as GridItem).Selected = (sender as CheckBox).Checked;
            }
            catch (Exception ex)
            {
                SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_userPrivileges", ex.StackTrace, DateTime.Now);
                Response.Redirect("~/Frm_ErrorPage.aspx");
            }
      
        }
    
        protected void Rg_Privilege_ItemCreated(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item is GridDataItem)
                {
                    e.Item.PreRender += new EventHandler(Rg_Privilege_ItemPreRender);
                }
            }
            catch (Exception ex)
            {
                SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_userPrivileges", ex.StackTrace, DateTime.Now);
                Response.Redirect("~/Frm_ErrorPage.aspx");
            }
      
        }

        private void Rg_Privilege_ItemPreRender(object sender, EventArgs e)
        {
            try
            {
                ((sender as GridDataItem)["CheckBoxTemplateColumn"].FindControl("chkRead") as CheckBox).Checked = (sender as GridDataItem).Selected;
                ((sender as GridDataItem)["CheckBoxTemplateColumn1"].FindControl("chkWrite") as CheckBox).Checked = (sender as GridDataItem).Selected;
            }
            catch (Exception ex)
            {
                SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_userPrivileges", ex.StackTrace, DateTime.Now);
                Response.Redirect("~/Frm_ErrorPage.aspx");
            }
      
        }
        protected void ToggleSelectedState(object sender, EventArgs e)
        {
            try
            {
                if ((sender as CheckBox).Checked)
                {
                    foreach (GridDataItem dataItem in Rg_Privilege.MasterTableView.Items)
                    {
                        (dataItem.FindControl("chkRead") as CheckBox).Checked = true;
                        dataItem.Selected = true;
                    }
                }
                else
                {
                    foreach (GridDataItem dataItem in Rg_Privilege.MasterTableView.Items)
                    {
                        (dataItem.FindControl("chkRead") as CheckBox).Checked = false;
                        dataItem.Selected = false;
                    }
                }
            }
            catch (Exception ex)
            {
                SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_userPrivileges", ex.StackTrace, DateTime.Now);
                Response.Redirect("~/Frm_ErrorPage.aspx");
            }
      
        }
        protected void ToggleSelectedState1(object sender, EventArgs e)
        {
            try
            {
                if ((sender as CheckBox).Checked)
                {
                    foreach (GridDataItem dataItem in Rg_Privilege.MasterTableView.Items)
                    {
                        (dataItem.FindControl("chkWrite") as CheckBox).Checked = true;
                        dataItem.Selected = true;
                    }
                }
                else
                {
                    foreach (GridDataItem dataItem in Rg_Privilege.MasterTableView.Items)
                    {
                        (dataItem.FindControl("chkWrite") as CheckBox).Checked = false;
                        dataItem.Selected = false;
                    }
                }
            }
            catch (Exception ex)
            {
                SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_userPrivileges", ex.StackTrace, DateTime.Now);
                Response.Redirect("~/Frm_ErrorPage.aspx");
            }
      
        }
        protected void Rg_Privilege_PreRender(object sender, EventArgs e)
        {
            try
            {
                Rg_Privilege.Controls.Add(new LiteralControl("Selected Forms count is: " + Rg_Privilege.SelectedItems.Count));
            }
            catch (Exception ex)
            {
                SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_userPrivileges", ex.StackTrace, DateTime.Now);
                Response.Redirect("~/Frm_ErrorPage.aspx");
            }
        }
}
    
   
   
