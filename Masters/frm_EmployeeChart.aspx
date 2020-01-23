<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_EmployeeChart.aspx.cs" Inherits="Masters_frm_EmployeeChart" %>

<%@ Register Assembly="Dhanush.SmartHR" Namespace="SmartHR" TagPrefix="swc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadAjaxManagerProxy ID="RAM_EmployeeChart" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rcmb_Employee">
            <UpdatedControls>
                 <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
            </UpdatedControls>
        </telerik:AjaxSetting>
          <telerik:AjaxSetting AjaxControlID="wscEmployee">
            <UpdatedControls>
                 <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
            </UpdatedControls>
        </telerik:AjaxSetting>
   </AjaxSettings>
 </telerik:RadAjaxManagerProxy>
    <table align="center">
        <tr>
            <td align="center">
                &nbsp;
                    <asp:Label ID="Label2" runat="server" 
                    Text="Employee Chart" Font-Bold="true"></asp:Label>  
            </td>
        </tr>
        <tr>
            <td>
                <table align="center">
                <tr>
                        <td>
                            <asp:Label ID="lbl_businessunit" runat="server" Text="Business&nbsp;Unit"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadComboBox  ID="rcmb_businessunit" runat="server" TabIndex="1" 
                                AutoPostBack="true" MarkFirstMatch="true" Filter="Contains"
                                onselectedindexchanged="rcmb_businessunit_SelectedIndexChanged">
                            </telerik:RadComboBox>
                        </td>
                        
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_employee" runat="server" Text="Employee"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadComboBox  ID="rcmb_Employee" runat="server" MarkFirstMatch="true" TabIndex="2" Filter="Contains">
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <asp:Button ID="btn_Go" runat="server" Text="Go" OnClick="btn_Go_Click" TabIndex="3"/>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <swc:SmartChartPro ID="wscEmployee" runat="server"  Width="990px" Height="480px"
                    DrawShadows="True" DataTitleFields="NAME,DESG,BUNIT,GRADE,DOJ" DataNodeName="Emp"
                    DataKeyField="EMP_ID" ShadowColor="Gray" DataFields="NAME,DESG" BoxColor="Gainsboro"
                    BoxGradient="True" BoxTextColor="Black" ChartDepth="5" SmartChartDirectory="~/Images/TempImg"
                    AllowDrillDown="True" fontstyle="Bold" ShadowOffset="5" Title="Employee Hierarchy Chart"
                    TitleColor="MidnightBlue" MaxChildrenPerLevelGroup="8" OutputType="Image" />
            </td>
        </tr>
    </table>
</asp:Content>
