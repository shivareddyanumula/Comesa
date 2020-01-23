<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_EmployeeRehire.aspx.cs" Inherits="HR_frm_EmployeeRehire" Culture="auto"
    meta:resourcekey="Page" UICulture="auto" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="cnt_EmployeeRehire" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:radajaxmanagerproxy id="RAM_EmpRecreate" runat="server">
        <AjaxSettings>
            <%-- <telerik:AjaxSetting AjaxControlID="Rg_EmpRecreated">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="RadAjaxPanel1" LoadingPanelID="RAL_Panel_Main" />
            </UpdatedControls>
        </telerik:AjaxSetting>--%>
            <telerik:AjaxSetting AjaxControlID="btn_Cancel">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Hire">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rcmb_RelEmpID">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:radajaxmanagerproxy>
    <table align="center" style="vertical-align: top;">
        <tr>
            <td>
                <telerik:radmultipage id="Rm_ER_page" runat="server" selectedindex="0"
                    style="z-index: 10" width="990px" height="490px" scrollbars="Auto" meta:resourcekey="Rm_ER_page">
                    <telerik:RadPageView ID="Rp_DR_ViewDetails" runat="server" meta:resourcekey="Rp_DR_ViewDetails"
                        Selected="True">
                        <table align="center" width="40%">
                            <tr>
                                <td colspan="4" align="center" style="font-weight: bold;">
                                    <asp:Label ID="lbl_Rehire" runat="server" meta:resourcekey="lbl_Rehire"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_RecrTranID" runat="server" Visible="False" meta:resourcekey="lbl_RecrTranID"></asp:Label>
                                    <asp:Label ID="lbl_RelEmpID" runat="server" meta:resourcekey="lbl_RelEmpID"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadComboBox  ID="rcmb_RelEmpID" runat="server" AutoPostBack="True" 
                                        OnSelectedIndexChanged="rcmb_RelEmpID_SelectedIndexChanged" MarkFirstMatch="true"
                                         Skin="WebBlue" Filter="Contains">
                                    </telerik:RadComboBox>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_RelEmpID" runat="server" ControlToValidate="rcmb_RelEmpID"
                                        InitialValue="Select" ValidationGroup="Controls" meta:resourcekey="rfv_rcmb_RelEmpID" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    
                                </td>
                            </tr>
                             <tr>
                                <td>
                                    <asp:Label ID="lbl_EmpType" runat="server" Text="Employee&nbsp;Type" meta:resourcekey="lbl_EmpType"></asp:Label>
                                   
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadComboBox  ID="rcmb_EmpType" runat="server"  MarkFirstMatch="true"
                                         Skin="WebBlue" >
                                         <Items>
                                            <telerik:RadComboBoxItem runat="server" Selected="true" Text="Select" Value="0" />
                                            <telerik:RadComboBoxItem runat="server" Text="Permanent and Pensionable" Value="Permanent and Pensionable" />
                                            <telerik:RadComboBoxItem runat="server" Text="Contract" Value="Contract" />
                                            <telerik:RadComboBoxItem runat="server" Text="Probation" Value="Probation" />
                                            <telerik:RadComboBoxItem runat="server" Text="Secondment" Value="Secondment" />
                                          </Items>
                                    </telerik:RadComboBox>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_EmpType" runat="server" ControlToValidate="rcmb_EmpType" ErrorMessage="Please Select Employee Type"
                                        InitialValue="Select" ValidationGroup="Controls" meta:resourcekey="rfv_rcmb_EmpType" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    
                                </td>
                            </tr>
<%--                            <tr id="tr_empcode" runat="server">
                                <td>
                                    <asp:Label ID="lbl_empcode" runat="server"  Text="Enter Employee Code"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_empcode" runat="server" MaxLength="50"></telerik:RadTextBox>
                                     <asp:RequiredFieldValidator ID="rfv_rtxt_empcode" runat="server" ControlToValidate="rtxt_empcode"
                                        ErrorMessage="Please Enter Employee Code" ValidationGroup="Controls" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                 </td>
                                <td>
                                   
                                </td>
                            </tr>--%>
                            <tr style="display: none;">
                                <td>
                                    <asp:Label ID="lbl_EmployeeID" runat="server" meta:resourcekey="lbl_EmployeeID"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:Label ID="lbl_EmployeeNewID" runat="server" 
                                        meta:resourcekey="lbl_EmployeeNewID"></asp:Label>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Button ID="btn_Hire" runat="server" meta:resourcekey="btn_Save" 
                                        OnClick="btn_Hire_Click" Text="Re-Hire" UseSubmitBehavior="false"  OnClientClick="fnJSOnFormSubmit(this,'Controls')" 
                                        Visible="False" />
                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" 
                                        onclick="btn_Cancel_Click" Text="Cancel" />
                                    <asp:ValidationSummary ID="vs_DisactRec" runat="server" 
                                        meta:resourcekey="vs_DisactRec" ShowMessageBox="True" ShowSummary="False" 
                                        ValidationGroup="Controls" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:radmultipage>
            </td>
        </tr>
    </table>
</asp:Content>
