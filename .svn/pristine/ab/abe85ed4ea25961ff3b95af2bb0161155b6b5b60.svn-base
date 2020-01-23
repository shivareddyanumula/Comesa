using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;

public partial class Security_ChangePassword : System.Web.UI.Page
{
    SMHR_ChangePassword _obj_ChangePWD;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                clearFields();
                lbl_Name.Text = Convert.ToString(Session["USERNAME"]);
                //rdb.SelectedIndex = 1;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "ChangePassword", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        
    }

    private void clearFields()
    {
        txt_CurrentPWD.Text = string.Empty;
        txt_NewPWD.Text = string.Empty;
        txt_ReTypePWD.Text = string.Empty;
        rtxtCode.Text = string.Empty;
        rdb.SelectedIndex = 1;
    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            if(Convert.ToString(txt_NewPWD.Text).Length < 4 || Convert.ToString(txt_NewPWD.Text).Length >14)
            {
                BLL.ShowMessage(this, "Password Length should be Minimum 4 & Maximum 14 Characters.");
                clearFields();
                return;
            }
            if (rtxtCode.Text != string.Empty)
            {
                if (Convert.ToString(rtxtCode.Text).Length < 4 || Convert.ToString(rtxtCode.Text).Length > 14)
                {
                    BLL.ShowMessage(this, "Security Code Length should be Minimum 4 & Maximum 14 Characters.");
                    clearFields();
                    return;
                }
            }
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
           _obj_SMHR_LoginInfo.LOGIN_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
           _obj_SMHR_LoginInfo.LOGIN_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
          _obj_SMHR_LoginInfo.OPERATION = operation.getLogin;
          DataTable dtLogin = BLL.get_LoginInfo(_obj_SMHR_LoginInfo);
          if (dtLogin.Rows.Count > 0)
          {
              int i_LoginId = Convert.ToInt32(dtLogin.Rows[0]["LOGIN_ID"]);
              DataTable dtLoginInfo = BLL.get_LoginInfo(new SMHR_LOGININFO(Convert.ToInt32(Convert.ToString(i_LoginId))));
              if (dtLoginInfo.Rows.Count > 0)
              {
                  ViewState["LOGIN_PASS_CODE"]=Convert.ToString(dtLoginInfo.Rows[0]["LOGIN_PASS_CODE"]);
              }
          }
            _obj_ChangePWD = new SMHR_ChangePassword();
            _obj_ChangePWD.UserName = Convert.ToString(Session["USERNAME"]);
            _obj_ChangePWD.oldPassword = Convert.ToString(BLL.PasswordEncrypt(txt_CurrentPWD.Text));
            _obj_ChangePWD.Mode = 2;
            DataTable dt = BLL.get_UserInfo(_obj_ChangePWD);
            if (dt.Rows.Count != 0)
            {
                _obj_ChangePWD = new SMHR_ChangePassword();
                _obj_ChangePWD.UserName = Convert.ToString(Session["USERNAME"]);
                _obj_ChangePWD.NewPasword = Convert.ToString(BLL.PasswordEncrypt(txt_NewPWD.Text));
                _obj_ChangePWD.Mode = 1;
                _obj_ChangePWD.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                if(rtxtCode.Text==string.Empty)
                {
                    _obj_ChangePWD.PassCode = Convert.ToString(ViewState["LOGIN_PASS_CODE"]);
                }
                else
                {
                _obj_ChangePWD.PassCode = Convert.ToString(BLL.PasswordEncrypt(rtxtCode.Text));
                }
                bool status = BLL.set_UserInfo(_obj_ChangePWD);
                if (status == true)
                {
                    BLL.ShowMessage(this, "Password Changed Successfully");
                    clearFields();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Test", "<script type='text/javascript'>Close()</" + "script>", false);
                    return;
                }
                else
                {
                    BLL.ShowMessage(this, "Password is not Valid");
                    clearFields();
                    return;
                }
            }
            else
            {
                BLL.ShowMessage(this, "Current Password is not Valid");
                clearFields();
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "ChangePassword", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    

}
