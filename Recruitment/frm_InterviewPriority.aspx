<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_InterviewPriority.aspx.cs" Inherits="Recruitment_frm_InterviewPriority" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td align="center">&nbsp;<asp:Label ID="lbl_PhaseDefinitionHeader" runat="server" Text="Interview Priority" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="RM_InterviewPriority" runat="server" SelectedIndex="0">
                    <telerik:RadPageView ID="RP_InterviewPriority" runat="server">
                        <table align="center">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="RG_InterviewPriority" runat="server" 
                                        AllowFilteringByColumn="true" AutoGenerateColumns="false" 
                                        OnNeedDataSource="RG_InterviewPriority_NeedDataSource"
                                        AllowPaging="true" PageSize="5">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn HeaderText="Priority_id" DataField="PRIORITY_ID" Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="InterviewPriorityId" DataField="INTERVIEWPRIORITY_PRIORITYID"
                                                    Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Priority Value" DataField="PRIORITY_VALUE">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Priority Description" DataField="PRIORITY_NAME">
                                                </telerik:GridBoundColumn>
                                                 <telerik:GridTemplateColumn AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" OnCommand="lnk_Edit_Command" CommandArgument='<%#Eval("PRIORITY_ID") %>'>Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                              <%--  <telerik:GridBoundColumn HeaderText="Priority Description" DataField="SKILLCAT_DESCRIPTION">
                                                </telerik:GridBoundColumn>--%>
                                               <%-- <telerik:GridTemplateColumn AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" OnCommand="lnk_Edit_Command" CommandArgument='<%#Eval("SKILLCAT_ID") %>'>Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>--%>
                                            </Columns>
                                            
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" OnCommand="lnk_Add_Command">Add</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RP_InterviewPrioritydetails" runat="server" Width="100%" >
                        <table align="center">
                            <%--<tr>
                                <td align="center" colspan="5">
                                    <h4>
                                        Skill Category Details
                                    </h4>
                                </td>
                            </tr>--%>
                            <tr>
                                <td align="right" >
                                    
                                <asp:Label ID="lbl_Id" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lbl_Priority" runat="server" Text="Priority Value"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                  <telerik:RadNumericTextBox ID="RNTB_PriorityValue" runat ="server" AutoPostBack ="true">
                                  </telerik:RadNumericTextBox> 
                                  
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_Priority" runat="server" ErrorMessage="Please Enter Priority Value"
                                        Text="*" ControlToValidate="RNTB_PriorityValue" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" >
                                    <asp:Label ID="lbl_PriorityId" runat="server" Text="Priority Description"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                  <%-- <asp:TextBox ID="Txt_Skillname" runat="server"></asp:TextBox>--%>
                                    <telerik:RadTextBox ID="txt_Priorityname" runat="server" >
                                    </telerik:RadTextBox>
                                </td>
                               <%-- <td>
                                    <asp:RequiredFieldValidator ID="rfv_priporityID" runat="server" ErrorMessage="Please Enter Priority Name"
                                        ControlToValidate="txt_Priorityname" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>--%>
                            </tr>
                            
                           <%-- <tr>
                                <td align="left" >
                                    <asp:Label ID="lbl_Priorityname" runat="server" Text="Name"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                
                                    <telerik:RadTextBox ID="RT_Priorityname" runat="server" >
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_Priorityname" runat="server" Text="*" ErrorMessage="Enter Name"
                                        ControlToValidate="RT_Priorityname" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>--%>
                    
                            <tr>
                                <td align="center" colspan="7">
                                    <asp:Button ID="btn_Submit" runat="server" Text="Submit" OnClick="btn_Submit_Click" ValidationGroup="Controls" />&nbsp;
                                    <asp:Button ID="btn_Update" runat="server" Text="Update" OnClick="btn_Submit_Click"
                                        ValidationGroup="Controls" />&nbsp;
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
                                </td>
                            </tr>
                        </table>
                        <asp:ValidationSummary ID="VS_InterviewPrioritySummary" runat="server" ValidationGroup="Controls"
                            ShowMessageBox="True" ShowSummary="False" />
                    </telerik:RadPageView>
                </telerik:RadMultiPage> 
            </td>
        </tr>
    </table>
</asp:Content>

