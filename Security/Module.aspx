﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="Module.aspx.cs" Inherits="Security_Module" %>


<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">

    <table align="center" style="width: 100%">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_Email" runat="server" Text="Email Configuration" Font-Bold="True" ForeColor="Black"></asp:Label>
            </td>
        </tr>

        <tr>
            <td align="center">
                <table align="center" style="width: 50%">

                    <tr>
                        <td align="left" style="width: 98%" colspan="3">
                            <telerik:RadGrid ID="RG_ModuleMailID" runat="server" AutoGenerateColumns="False"
                                Skin="WebBlue" GridLines="None" Visible="false">
                                <MasterTableView>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="SMHR_MODULE_ID" UniqueName="SMHR_MODULE_ID" HeaderText="ID" Visible="False">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="SMHR_MODULE_NAME" UniqueName="SMHR_MODULE_NAME" HeaderText="Module Name">
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn Visible="false">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblModName" Text='<%# Eval("SMHR_MODULE_NAME") %>'></asp:Label>
                                                <asp:Label runat="server" ID="lblModID" Text='<%# Eval("SMHR_MODULE_ID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Admin-EMailID" UniqueName="E-EMailID">
                                            <ItemTemplate>
                                                <telerik:RadTextBox ID="txt_AdminMail" runat="server" TextMode="MultiLine"
                                                    Text='<%# Eval("Module_MailID_AdminEMailID") %>'
                                                    ValidationGroup="Controls">
                                                </telerik:RadTextBox>
                                                <%--<asp:RequiredFieldValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_AdminMail"
                                                    Text="*" ValidationGroup="Controls" ErrorMessage="Please Enter E-MailID"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server" ControlToValidate="txt_AdminMail" Text="*" ForeColor="Red" ValidationGroup="Controls"
                                                    ErrorMessage="Please give a valid EmailID" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>--%>
                                            </ItemTemplate>

                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="E-MailID" UniqueName="E-MailID">
                                            <ItemTemplate>
                                                <telerik:RadTextBox ID="txt_Mail" runat="server" TextMode="MultiLine"
                                                    Text='<%# Eval("Module_MailID_EmailIDS") %>'
                                                    ValidationGroup="Controls">
                                                </telerik:RadTextBox>
                                                <%--<asp:RequiredFieldValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_Mail"
                                                    Text="*" ValidationGroup="Controls" ErrorMessage="Please Enter E-MailID"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="REV_AdminMail" runat="server" ControlToValidate="txt_Mail" Text="*" ForeColor="Red" ValidationGroup="Controls"
                                                    ErrorMessage="Please give a valid EmailID" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>--%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="3">
                            <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click2" CausesValidation="true"
                                ValidationGroup="Controls" />
                            <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
                            <asp:ValidationSummary ID="vs_Salary" runat="server"
                                ShowMessageBox="True" ShowSummary="False" ValidationGroup="Controls" DisplayMode="SingleParagraph" />
                        </td>
                    </tr>

                </table>
            </td>
        </tr>
    </table>
</asp:Content>