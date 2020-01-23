using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;

public partial class HR_frmemppersonal : System.Web.UI.Page
{
    SMHR_EMPNODUE _obj_smhr_empnodue = new SMHR_EMPNODUE();
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToString(Request.QueryString["empid"]) != null)
            {
                if (Convert.ToInt32(Request.QueryString["mode"]) == 2)
                {
                    _obj_smhr_empnodue.OPERATION = operation.Empty;
                }
                if (Convert.ToInt32(Request.QueryString["mode"]) == 1)
                {
                    _obj_smhr_empnodue.OPERATION = operation.Edit;
                }

                //_obj_smhr_empnodue.OPERATION = operation.Empty;
                _obj_smhr_empnodue.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_smhr_empnodue.EMPNODUE_EMP_ID = Convert.ToInt32(Request.QueryString["empid"]);
                DataTable dt = new DataTable();
                dt = BLL.get_EmpNoDue(_obj_smhr_empnodue);
                if (dt.Rows.Count != 0)
                {
                    txt_BU.Text = Convert.ToString(dt.Rows[0]["BUSINESSUNIT"]);
                    txt_Grade.Text = Convert.ToString(dt.Rows[0]["SCALE"]);
                    txt_GrossSal.Text = Convert.ToString(dt.Rows[0]["GROSSSALARY"]);
                    txt_LS.Text = Convert.ToString(dt.Rows[0]["LEAVESTRUCTURE"]);
                    txt_Position.Text = Convert.ToString(dt.Rows[0]["DESIGNATION"]);
                    txt_RM.Text = Convert.ToString(dt.Rows[0]["RPE"]);
                    txt_SalStr.Text = Convert.ToString(dt.Rows[0]["SALARYSTRUCTURE"]);
                    txt_Basic.Text = Convert.ToString(dt.Rows[0]["BASIC"]);
                }

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemppersonal", ex.StackTrace, DateTime.Now);
            return;
        }

    }


}
