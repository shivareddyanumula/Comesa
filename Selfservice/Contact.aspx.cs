using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using SMHR;

public partial class Selfservice_Contact : System.Web.UI.Page
{
    SMHR_EMPLOYEE _obj_smhr_employee;
    static string _lbl_Emp_ID;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                rmtxt_MobileNo.Enabled = true;
                rmtxt_LandlineNo.Enabled = true;
                rtxt_EmailID.Enabled = false;
                LoadNewContactDetails();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Contact", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        
    }

    private void LoadNewContactDetails()
    {
        _obj_smhr_employee = new SMHR_EMPLOYEE();
        _lbl_Emp_ID = Convert.ToString(Session["EMP_ID"]);
        _obj_smhr_employee.OPERATION = operation.Select;
        _obj_smhr_employee.EMP_ID = Convert.ToInt32(_lbl_Emp_ID.ToString());
        DataTable dt = BLL.get_EMP_NEWCONTACTS(_obj_smhr_employee);
        if (dt.Rows.Count != 0)
        {
            rmtxt_MobileNo.Text = Convert.ToString(dt.Rows[0]["EMP_MOBILENO"]);
            rmtxt_LandlineNo.Text = Convert.ToString(dt.Rows[0]["EMP_LANDLINENO"]);
            rtxt_EmailID.Text = Convert.ToString(dt.Rows[0]["EMP_EMAILID"]);
        }
        if ((rmtxt_LandlineNo.Text != string.Empty) || (rmtxt_MobileNo.Text != string.Empty) || (rtxt_EmailID.Text != string.Empty))
        {
            btn_Correct.Visible = false;
            btn_Update.Visible = true;
        }
        else
        {
            btn_Update.Visible = false;
            btn_Correct.Visible = true;
        }
    }


    protected void btn_Update_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_smhr_employee = new SMHR_EMPLOYEE();
            _lbl_Emp_ID = Convert.ToString(Session["EMP_ID"]);
            //_obj_smhr_employee.OPERATION = operation.Select_EMPID;
            //_obj_smhr_employee.EMP_ID = Convert.ToInt32(_lbl_Emp_ID);
            //DataTable dt_getEMP_ID = BLL.get_EMP_NEWCONTACTS(_obj_smhr_employee);

            //int check = 0;
            //if (dt_getEMP_ID.Rows.Count != 0)
            //{
            //    for (int EMP_ID = 0; EMP_ID < dt_getEMP_ID.Rows.Count; EMP_ID++)
            //    {
            //        check = 1;

            //        if (Convert.ToString(dt_getEMP_ID.Rows[EMP_ID][0]) == _lbl_Emp_ID)
            //        {
            _obj_smhr_employee.OPERATION = operation.Insert1;
            _obj_smhr_employee.EMP_MOBILENO = Convert.ToString(rmtxt_MobileNo.Text.Replace("'", "''"));
            _obj_smhr_employee.EMP_LANDLINENO = Convert.ToString(rmtxt_LandlineNo.Text.Replace("'", "''"));
            _obj_smhr_employee.EMP_EMAILID = Convert.ToString(rtxt_EmailID.Text.Replace("'", "''"));
            _obj_smhr_employee.EMP_ID = Convert.ToInt32(_lbl_Emp_ID);

            BLL.set_EMP_NEWCONTACTS(_obj_smhr_employee);
            BLL.ShowMessage(this, "Records Updated Successfully");
            LoadNewContactDetails();

            //}
            //if (check == 0)
            //{
            //    BLL.ShowMessage(this, "EMP_ID is missing");
            //}
            //}
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Contact", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Correct_Click(object sender, EventArgs e)
    {
        try
        {
            //rmtxt_MobileNo.Enabled = true;
            //rmtxt_LandlineNo.Enabled = true;
            //rtxt_EmailID.Enabled = true;
            if (rmtxt_MobileNo.Text != string.Empty || rmtxt_LandlineNo.Text != string.Empty || rtxt_EmailID.Text != string.Empty)
            {
                _obj_smhr_employee = new SMHR_EMPLOYEE();
                _lbl_Emp_ID = Convert.ToString(Session["EMP_ID"]);
                _obj_smhr_employee.OPERATION = operation.Insert1;
                _obj_smhr_employee.EMP_MOBILENO = Convert.ToString(rmtxt_MobileNo.Text.Replace("'", "''"));
                _obj_smhr_employee.EMP_LANDLINENO = Convert.ToString(rmtxt_LandlineNo.Text.Replace("'", "''"));
                _obj_smhr_employee.EMP_EMAILID = Convert.ToString(rtxt_EmailID.Text.Replace("'", "''"));
                _obj_smhr_employee.EMP_ID = Convert.ToInt32(_lbl_Emp_ID);

                BLL.set_EMP_NEWCONTACTS(_obj_smhr_employee);
                BLL.ShowMessage(this, "Records Inserted Successfully");
            }
            else
            {
                BLL.ShowMessage(this, "Please Enter Atleast one Value.");
            }
            LoadNewContactDetails();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Contact", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            rmtxt_MobileNo.Text = string.Empty;
            rmtxt_LandlineNo.Text = string.Empty;
            LoadNewContactDetails();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Contact", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
