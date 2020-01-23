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
using RECRUITMENT;
using System.Data;

public partial class Recruitment_frm_JobReqDetails : System.Web.UI.Page
{
    RECRUITMENT_JOBREQUISITION _obj_Rec_JobRequisition;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
                if (Request.QueryString["JOBREQ_ID"] != null)
                    _obj_Rec_JobRequisition.JOBREQ_ID = Convert.ToInt32(Convert.ToString(Request.QueryString["JOBREQ_ID"]));
                else
                    _obj_Rec_JobRequisition.JOBREQ_ID = 0;
                _obj_Rec_JobRequisition.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Rec_JobRequisition.MODE = 26;
                DataTable dt = Recruitment_BLL.get_JobRequisition(_obj_Rec_JobRequisition);
                if (dt.Rows.Count > 0)
                {
                    lbl_BU_Value.Text = Convert.ToString(dt.Rows[0]["BUSINESSUNIT_CODE"]);
                    lbl_Dept_Value.Text = Convert.ToString(dt.Rows[0]["DEPARTMENT_NAME"]);
                    lbl_Desg_Value.Text = Convert.ToString(dt.Rows[0]["POSITIONS_CODE"]);
                    lbl_Level_Value.Text = Convert.ToString(dt.Rows[0]["EMPLOYEEGRADE_CODE"]);
                    lbl_EmpType_Value.Text = Convert.ToString(dt.Rows[0]["EMPLOYEETYPE_CODE"]);
                    lbl_CTC_Value.Text = Convert.ToString(dt.Rows[0]["EMPLOYEEGRADE_SLAB_AMOUNT"]);
                    lbl_Directorate_Value.Text = Convert.ToString(dt.Rows[0]["DIRECTORATE_CODE"]);
                }
                else
                {
                    lbl_BU_Value.Text = string.Empty;
                    lbl_Dept_Value.Text = string.Empty;
                    lbl_Desg_Value.Text = string.Empty;
                    lbl_Level_Value.Text = string.Empty;
                    lbl_EmpType_Value.Text = string.Empty;
                    lbl_CTC_Value.Text = string.Empty;
                    lbl_Directorate.Text = string.Empty;
                    lbl_Directorate_Value.Text = string.Empty;

                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_JobReqDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
