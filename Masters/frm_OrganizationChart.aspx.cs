using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data;
using SMHR;
using System.IO;
using Telerik.Web.UI;
using System.Text;


public partial class Masters_frm_OrganizationChart : System.Web.UI.Page
{
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                //FileInfo[] file;
                //int i;
                //DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/Images/TempImg/"));
                //file = dir.GetFiles();
                //if (file.Length > 0)
                //{
                //    for (i = 0; i <= file.Length - 1; i++)
                //    {
                //        if (!file[i].IsReadOnly)
                //            file[i].Delete();
                //    }
                //}

                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Organization Chart");//COUNTRY");
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
                    RG_EmployeeDetails.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    //btn_Save.Visible = false;
                    // btn_Update.Visible = false;
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
                BindData();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_OrganizationChart", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void BindData()
    {
        try
        {
            if (HttpContext.Current.Session["ORG_ID"] != null)
            {
                DataTable dtOrganisationChart = new DataTable();
                SMHR_OrganisationChart objOrgChart = new SMHR_OrganisationChart();
                objOrgChart.ID = Convert.ToInt32(HttpContext.Current.Session["ORG_ID"]);
                objOrgChart.OPERATION = operation.Select;
                dtOrganisationChart = BLL.getOrganisationTreeViewData(objOrgChart);
                StringBuilder strXML = new StringBuilder(); //StringBuilder to hold xml data from DataTable
                foreach (DataRow dr in dtOrganisationChart.Rows)
                {
                    strXML.Append(dr[0].ToString());    //Appending xml data to StringBuilder
                }
                if (dtOrganisationChart.Rows.Count > 0)
                {
                    /* Code to fetch data from DB*/
                    XmlDocument dc = new XmlDocument();
                    dc.LoadXml(strXML.ToString());
                    wscOrganization.DataSource = dc;
                    wscOrganization.DataBind();




                    ///* Code to fetch data from xml file */
                    //XmlDocument myDoc = new XmlDocument();
                    //myDoc.Load(@"C:\Users\anandkumar.r\Desktop\temp\c.XML");
                    //wscOrganization.DataSource = myDoc;
                    //wscOrganization.DataBind();



                    ////Loop through wscOrganisation (chart items)
                    //string node = wscOrganization.StartNode.Value;
                    //for (int i = 0; i <= wscOrganization.Controls.Count - 1; i++)
                    //{
                    //    //string strType = wscOrganization. .Controls[i].ToString();
                    //    //wscOrganization.BoxColor = System.Drawing.Color.Red;
                    //    int j = wscOrganization.MaxChildrenPerLevelGroup;
                    //}
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_OrganizationChart", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void wscOrganization_SmartChartClicked(object sender, SmartHR.SmartChartEventArgs e)
    {
        try
        {
            string[] selID = e.Item.DataKey.Split('-');
            //string strParentKey = e.Item.ParentDataKey;

            if (selID.Length == 2 && selID[0] != "ORG")
            {
                BindData(); //To rebind chart

                int ID = Convert.ToInt32(selID[1]);
                string Category = selID[0].Trim();
                switch (Category)
                {
                    case "BU":  //To fetch Business Emp Details
                        ShowPopup(ID, operation.Get_BU);    //, strParentKey);
                        break;
                    case "D": //To fetch Directorate Emp Details
                        ShowPopup(ID, operation.EmployeesDirectoratewise);      //, strParentKey);
                        break;
                    case "SD": //To fetch Sub-Directorate Emp Details
                        ShowPopup(ID, operation.EmployeesDirectoratewise);      //, strParentKey);
                        break;
                    case "DP": //To fetch Department Emp Details
                        ShowPopup(ID, operation.Select_Dept);   //, strParentKey);
                        break;
                    case "SB": //To fetch Sub-Department Emp Details
                        ShowPopup(ID, operation.EmployeesSubDepartmentWise);   //, strParentKey);
                        break;
                    default:
                        RWOrgDetails.Visible = false;
                        break;
                }

            }
            else
            {
                RWOrgDetails.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_OrganizationChart", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void ShowPopup(int ID, operation operation) //, string parentDataKey)
    {
        try
        {
            //To Show radwindow as popup
            DataTable dtOrganisationChart = new DataTable();
            SMHR_OrganisationChart objOrgChart = new SMHR_OrganisationChart();
            objOrgChart.ID = Convert.ToInt32(ID);
            objOrgChart.OPERATION = operation;   //To get emp details based on selection

            //string[] selIDParentKey = parentDataKey.Split('-');

            //objOrgChart.ParentID = Convert.ToInt32(selIDParentKey[1]);

            dtOrganisationChart = BLL.getOrganisationEmployeeDtls(objOrgChart);
            ViewState["dtOrganisationChart"] = dtOrganisationChart;
            if (dtOrganisationChart.Rows.Count > 0)
            {
                lblHeading.Text = "Employees";
                RG_EmployeeDetails.DataSource = dtOrganisationChart;
                RG_EmployeeDetails.DataBind();
                RG_EmployeeDetails.Visible = true;
                RWOrgDetails.Height = 400;
                RWOrgDetails.Width = 600;
                RWOrgDetails.Visible = true;
                RWOrgDetails.VisibleOnPageLoad = true;
            }
            else
            {
                //To show alert to user
                BLL.ShowMessage(this, "No data found.");

                //lblHeading.Text = "No data found";
                //RG_EmployeeDetails.DataSource = null;
                //RG_EmployeeDetails.DataBind();
                //RG_EmployeeDetails.Visible = false;
                //RWOrgDetails.Height = 400;
                //RWOrgDetails.Width = 600;
                RWOrgDetails.Visible = false;
                //RWOrgDetails.VisibleOnPageLoad = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_OrganizationChart", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void RG_EmployeeDetails_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            if (ViewState["dtOrganisationChart"] != null)
            {
                RG_EmployeeDetails.DataSource = ViewState["dtOrganisationChart"] as DataTable;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_OrganizationChart", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}