using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using SMHR;
using System.Xml;

public partial class HR_Oracle_EBS_Employee_Postings : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                //code for security privilage
                Session.Remove("WRITEFACILITY");
                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();
                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Oracle EBS Employee Postings");//EMPLOYEE AX");
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
                    lnk_Files.Visible = false;

                    btn_Generate.Visible = false;
                    btn_Get_Details.Visible = false;


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
                RG_Date.Visible = false;
                rdp_FromDate.SelectedDate = null;
                rdp_ToDate.SelectedDate = null;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Employees", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Get_Details_Click(object sender, EventArgs e)
    {
        try
        {
            RG_Date.Visible = true;
            DataTable dt = BLL.ExecuteQuery("EXEC USP_SMHR_EMP_ORACLE_POSTINGS @FROMPERIOD ='" + Convert.ToDateTime(rdp_FromDate.SelectedDate.Value) + "', @TOPERIOD='" + Convert.ToDateTime(rdp_ToDate.SelectedDate.Value) + "',@ORG_ID = '" + Convert.ToInt32(Session["ORG_ID"]) + "'");

            if (dt.Rows.Count > 0)
            {
                RG_Date.DataSource = dt;
                RG_Date.DataBind();
            }
            else
            {
                BLL.ShowMessage(this, "No Employees for the Selected Date");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Employees", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Generate_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = BLL.ExecuteQuery("EXEC USP_SMHR_EMP_ORACLE_POSTINGS @FROMPERIOD = '" + Convert.ToDateTime(rdp_FromDate.SelectedDate.Value) + "', @TOPERIOD = '" + Convert.ToDateTime(rdp_ToDate.SelectedDate.Value) + "',@ORG_ID = '" + Convert.ToInt32(Session["ORG_ID"]) + "'");

            if (dt.Rows.Count != 0)
            {
                DateTime dt1 = DateTime.Now;
                string FileName1 = string.Empty;
                string DateVal = dt1.ToString("ddMMyyyy");
                int partyno = 0;
                DataTable dt_1 = BLL.ExecuteQuery("SELECT MASTERNO,PARTYNO FROM SMHR_GLOBALCONFIG WHERE GLOBALCONFIG_ORGANISATION_ID = '" + Convert.ToInt32(Session["ORG_ID"]) + "'");
                if (dt_1.Rows.Count != 0)
                {
                    FileName1 = "~//XML//ORA_SMHR_MST_" + DateVal + "_" + dt_1.Rows[0]["MASTERNO"] + ".xml";
                    bool status = BLL.ExecuteNonQuery("UPDATE SMHR_GLOBALCONFIG SET MASTERNO = MASTERNO + 1 WHERE " +
                                            "GLOBALCONFIG_ORGANISATION_ID = '" + Convert.ToInt32(Session["ORG_ID"]) + "'");
                    partyno = Convert.ToInt32(dt_1.Rows[0]["PARTYNO"]);
                }
                else
                {
                    FileName1 = "~//XML//ORA_SMHR_MST_" + DateVal + "_1.xml";
                    partyno = 0;
                }

                //DataTable dtpno = BLL.ExecuteQuery("SELECT PARTYNO FROM SMHR_GLOBALCONFIG");
                //if (dtpno.Rows.Count > 0)
                //{

                //    partyno = Convert.ToInt32(dtpno.Rows[0]["PARTYNO"]);
                //}
                string strPath = Server.MapPath(FileName1);
                XmlTextWriter myXmlTextWriter = new XmlTextWriter(strPath, null);
                myXmlTextWriter.Formatting = Formatting.Indented;
                myXmlTextWriter.WriteStartDocument(false);
                myXmlTextWriter.WriteStartElement("xml");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    partyno = partyno + 1;
                    myXmlTextWriter.WriteStartElement("EmplTable", null);
                    myXmlTextWriter.WriteElementString("EmplId", null, Convert.ToString(dt.Rows[i]["Employee_Code"]));
                    myXmlTextWriter.WriteElementString("EmplGender", null, Convert.ToString(dt.Rows[i]["GENDER"]));
                    myXmlTextWriter.WriteElementString("PartyId", null, Convert.ToString(dt.Rows[i]["PARTY_ID"]));
                    // myXmlTextWriter.WriteElementString("PartyId", null, Convert.ToString([Party_ID]));
                    myXmlTextWriter.WriteElementString("Status", null, Convert.ToString(dt.Rows[i]["EmpStatus"]));
                    myXmlTextWriter.WriteElementString("Name", null, Convert.ToString(dt.Rows[i]["NAME"]));
                    myXmlTextWriter.WriteElementString("NameAlias", null, Convert.ToString(dt.Rows[i]["ALIAS"]));
                    //  myXmlTextWriter.WriteElementString("Type", null, Convert.ToString(dt.Rows[i]["TYPE"]));
                    myXmlTextWriter.WriteElementString("FirstName", null, Convert.ToString(dt.Rows[i]["FIRST_NAME"]));
                    myXmlTextWriter.WriteElementString("MiddleName", null, Convert.ToString(dt.Rows[i]["MIDDLE_NAME"]));
                    myXmlTextWriter.WriteElementString("LastName", null, Convert.ToString(dt.Rows[i]["LAST_NAME"]));
                    myXmlTextWriter.WriteElementString("DateOfBirth", null, Convert.ToString(dt.Rows[i]["DateOfBirth"]));
                    myXmlTextWriter.WriteElementString("DateOfJoin", null, Convert.ToString(dt.Rows[i]["DateOfJoin"]));
                    myXmlTextWriter.WriteElementString("EMPStatus", null, Convert.ToString(dt.Rows[i]["EmpStatus"]));
                    myXmlTextWriter.WriteElementString("Position", null, Convert.ToString(dt.Rows[i]["Position"]));
                    myXmlTextWriter.WriteElementString("Dimension", null, Convert.ToString(dt.Rows[i]["DEPARTMENT"]));
                    myXmlTextWriter.WriteElementString("EmailId", null, Convert.ToString(dt.Rows[i]["EmailId"]));
                    myXmlTextWriter.WriteEndElement();
                }
                myXmlTextWriter.Flush();
                myXmlTextWriter.Close();
                BLL.ExecuteNonQuery("update SMHR_GLOBALCONFIG set PARTYNO=" + partyno + " ");

                BLL.ShowMessage(this, FileName1 + " XML Generated Successfully");
                RG_Date.Visible = false;
                rdp_FromDate.SelectedDate = null;
                rdp_ToDate.SelectedDate = null;
            }
            else
            {
                BLL.ShowMessage(this, "No Details to Generate XML");
                return;
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Employees", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            RG_Date.Visible = false;
            rdp_FromDate.SelectedDate = null;
            rdp_ToDate.SelectedDate = null;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Employees", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
}
