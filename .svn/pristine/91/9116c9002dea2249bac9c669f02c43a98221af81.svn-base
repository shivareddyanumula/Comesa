<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_Announcements.aspx.cs" Inherits="Security_frm_Announcements" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="Label1" runat="server" Text="Company Announcements and Events"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="rmp_MainPage" runat="server" SelectedIndex="0" Height="490px"
                    Width="990px">
                    <telerik:RadPageView ID="rpv_Grid" runat="server" Selected="true">
                        <table align="center">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="rg_Main" runat="server" AutoGenerateColumns="false" GridLines="None" AllowFilteringByColumn="true">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridTemplateColumn AllowFiltering="false" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_MessageId" runat="server" Text='<%# Eval("ANNCE_ID") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn HeaderText="Title" DataField="ANNCE_TITLE"  >
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Message" DataField="ANNCE_MESSAGE">
                                                </telerik:GridBoundColumn>
                                                <%--<telerik:GridBoundColumn HeaderText="Expiry Date" DataField="ANNCE_EXP_DATE",>
                                                </telerik:GridBoundColumn>--%>
                                                <telerik:GridTemplateColumn HeaderText ="Expiry Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Expirydate" runat="server" Text='<%# Eval("ANNCE_EXP_DATE1","{0:dd/MM/yyyy}") %>' Visible="true"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                
                                                <telerik:GridTemplateColumn  AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" Text="Edit" OnCommand="lnk_Edit_Command"
                                                            CommandArgument='<%# Eval("ANNCE_ID") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" Text="Add" OnCommand="lnk_Add_Command"></asp:LinkButton>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="rpv_Details" runat="server">
                        <table align="center">
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Title" runat="server" Text="Title"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_Title" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_Title" runat="server" Text="*" ControlToValidate="txt_Title"
                                        ValidationGroup="Controls" ErrorMessage="Enter Title"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Description" runat="server" Text="Message"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_Description" runat="server" TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_Description" runat="server" Text="*" ControlToValidate="txt_Description"
                                        ValidationGroup="Controls" ErrorMessage="Enter Message"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_ExpiryDate" runat="server" Text="Expiry Date"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="rdp_ExpiryDate" runat="server">
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_ExpiryDate" runat="server" Text="*" ValidationGroup="Controls"
                                        ControlToValidate="rdp_ExpiryDate" ErrorMessage="Select Expiry Date for Message"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click" OnClientClick="disableButton(this,'Controls')" UseSubmitBehavior="false"/>
                                    <asp:Button ID="btn_Update" runat="server" Text="Update" OnClick="btn_Save_Click" />
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="vs_Announcements" runat="server" ShowMessageBox="true"
        ShowSummary="false" ValidationGroup="Controls" />
</asp:Content>
