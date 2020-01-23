using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml;
using System.Data;
using SMHR;
using Telerik.Web.UI;

public partial class Masters_frm_EmployeeChart : System.Web.UI.Page
{
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (ViewState["IsPostBack"] == null)
            {

                //FileInfo[] file;
                //int i;
                //DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/Images/TempImg/"));
                //file = dir.GetFiles();
                //if (file.Length > 0)
                //{
                //    for (i = 0; i <= file.Length - 1; i++)
                //    {
                //        if(!file[i].IsReadOnly)
                //        file[i].Delete();
                //    }
                //}
                ////wscEmployee.DataSource = getXml();
                ////wscEmployee.DataBind();
                ////LoadEmployee();


                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("COUNTRY");
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
                    // Rg_Countries.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Go.Visible = false;
                    //btn_Update.Visible = false;
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
                LoadCombos();
                ViewState["IsPostBack"] = 1;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeChart", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected XmlDocument getXml()
    {
        DataTable dt = new DataTable();
        XmlDocument doc = new XmlDocument();
        try
        {

            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", null, null);
            doc.AppendChild(dec);
            XmlElement root = doc.CreateElement("root");
            doc.AppendChild(root);
            XmlElement EmpChart;
            if (rcmb_Employee.SelectedIndex == -1 || rcmb_Employee.SelectedItem.Value == "-1")
            {
                EmpChart = doc.CreateElement("Emp");
                EmpChart.SetAttribute("EMP_ID", "0");
                EmpChart.SetAttribute("NAME", "Employee Structure");
                root.AppendChild(EmpChart);
            }
            else
            {
                EmpChart = root;

            }


            if (rcmb_Employee.SelectedIndex == -1 || rcmb_Employee.SelectedItem.Value == "-1")
            {
                if (rcmb_businessunit.SelectedIndex > 0)
                    dt = BLL.get_ChartBUData("EMP", string.Empty, Convert.ToInt32(Session["ORG_ID"]), Convert.ToInt32(rcmb_businessunit.SelectedItem.Value));
                else
                    dt = BLL.get_ChartData("EMP", string.Empty, Convert.ToInt32(Session["ORG_ID"]), 0, 0);
            }
            else
            {
                dt = BLL.get_ChartData("EMP", rcmb_Employee.SelectedItem.Value, Convert.ToInt32(Session["ORG_ID"]), 0, 0);
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                getElement(doc, EmpChart,
                     Convert.ToString(dt.Rows[i]["EMP_ID"]),
                     Convert.ToString(dt.Rows[i]["NAME"]),
                     Convert.ToString(dt.Rows[i]["DESG"]),
                     Convert.ToString(dt.Rows[i]["GRADE"]),
                     Convert.ToString(dt.Rows[i]["BUNIT"]),
                     Convert.ToString(dt.Rows[i]["DOJ"]),
                     Convert.ToString(dt.Rows[i]["PID"]));
            }
            string xmlOutput = doc.OuterXml;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeChart", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

        }
        return doc;
    }

    protected void getElement(XmlDocument doc, XmlElement xmlElement,
        string EMP_ID, string NAME, string DESG, string GRADE, string BUNIT, string DOJ, string PID)
    {
        try
        {
            foreach (XmlElement item in doc.GetElementsByTagName("Emp"))
            {
                if (Convert.ToString(item.Attributes["EMP_ID"].Value).ToUpper() == PID.ToUpper())
                    xmlElement = item;
            }
            XmlElement Emp = doc.CreateElement("Emp");
            Emp.SetAttribute("EMP_ID", EMP_ID);
            Emp.SetAttribute("NAME", NAME);
            Emp.SetAttribute("DESG", DESG);
            Emp.SetAttribute("GRADE", GRADE);
            Emp.SetAttribute("BUNIT", BUNIT);
            Emp.SetAttribute("DOJ", DOJ);
            xmlElement.AppendChild(Emp);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeChart", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

        }
    }
    protected void btn_Go_Click(object sender, EventArgs e)
    {
        try
        {
            wscEmployee.DataSource = getXml();
            wscEmployee.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeChart", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

        }
    }
    protected void LoadEmployee()
    {
        try
        {
            rcmb_Employee.Items.Clear();
            SMHR_EMPDISCIPLINARYACTION _obj_Smhr_EmpDisciplinaryAction = new SMHR_EMPDISCIPLINARYACTION();
            _obj_Smhr_EmpDisciplinaryAction.OPERATION = operation.Empty1;
            _obj_Smhr_EmpDisciplinaryAction.EMPDSPACT_BUID = Convert.ToInt32(rcmb_businessunit.SelectedItem.Value);
            _obj_Smhr_EmpDisciplinaryAction.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            rcmb_Employee.DataSource = BLL.get_EmpDiscNotes(_obj_Smhr_EmpDisciplinaryAction);
            rcmb_Employee.DataTextField = "EMPNAME";
            rcmb_Employee.DataValueField = "EMP_ID";
            rcmb_Employee.DataBind();
            rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeChart", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

    }
    private void LoadCombos()
    {
        try
        {
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);

            rcmb_businessunit.DataSource = dt_BUDetails;
            rcmb_businessunit.DataValueField = "BUSINESSUNIT_ID";
            rcmb_businessunit.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_businessunit.DataBind();
            rcmb_businessunit.Items.Insert(0, new RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeChart", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void rcmb_businessunit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_businessunit.SelectedIndex == 0)
            {
                rcmb_Employee.Items.Clear();
                //wscEmployee.DataSource = getXml();
                //wscEmployee.DataBind();
                wscEmployee.Title = string.Empty;
              
               
            }
            else
            {
                LoadEmployee();
                wscEmployee.DataSource = getXml();
                wscEmployee.DataBind();
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeChart", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
}
