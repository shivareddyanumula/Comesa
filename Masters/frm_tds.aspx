<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_Tds.aspx.cs" Inherits="Masters_frm_tds" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_Header" runat="server" Text="Define PAYE Name">
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="rmp_Main" runat="server" SelectedIndex="0" Height="490px"
                    Width="990px">
                    <telerik:RadPageView ID="rpv_Main" runat="server" Selected="true">
                        <table align="center">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="rg_Main" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                                        Skin="WebBlue" GridLines="None" AllowFilteringByColumn="true">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridTemplateColumn UniqueName="TDS_ID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_tdsid" runat="server" Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn DataField="TDS_NAME" HeaderText="Name" UniqueName="TDS_NAME"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="TDS_DESC" HeaderText="Description" UniqueName="TDS_DESC"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="BUSINESSUNIT_CODE" HeaderText="Business Unit Name"
                                                    UniqueName="BUSINESSUNIT_CODE" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="TDS_STATUS" HeaderText="Status" UniqueName="BUSINESSUNITCODE"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="EDIT" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("TDS_ID") %>'
                                                            OnCommand="lnk_Edit_Command">Edit
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" Text="Add" OnCommand="lnk_Add_Command">
                                                    </asp:LinkButton>
                                                </div>
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
                                    <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business Unit">
                                    </asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_BusinessUnit" runat="server" Skin="WebBlue" AutoPostBack="true" TabIndex="1" Filter="Contains"
                                        OnSelectedIndexChanged="rcmb_BusinessUnit_SelectedIndexChanged" MarkFirstMatch="true" MaxHeight="120px">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*" ValidationGroup="Controls"
                                        ControlToValidate="rcmb_BusinessUnit" ErrorMessage="Please Select Business Unit" InitialValue="Select">                                        
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_TdsName" runat="server" Text="Name">
                                    </asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_TdsName" runat="server" Skin="WebBlue" MaxLength="100" TabIndex="2">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_TdsName" runat="server" Text="*" ValidationGroup="Controls"
                                        ControlToValidate="rtxt_TdsName" ErrorMessage="Please Enter Name">                                        
                                    </asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="rev_TdsName" ErrorMessage="Enter Only Alphabets For Name"
                                        runat="server" ValidationGroup="Controls" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$"
                                        ControlToValidate="rtxt_TdsName">*</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_TdsDesc" runat="server" Text="Description">
                                    </asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_TdsDesc" runat="server" Skin="WebBlue" MaxLength="400" TabIndex="3">
                                    </telerik:RadTextBox>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_TdsStatus" runat="server" Text="Status">
                                    </asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <%--<asp:CheckBox ID="chk_TdsStatus" runat="server" AutoPostBack="true" />--%>
                                    <telerik:RadComboBox ID="rcmb_Status" runat="server" AutoPostBack="true" Skin="WebBlue" MarkFirstMatch="true" TabIndex="4">
                                        <Items>
                                            <telerik:RadComboBoxItem Text="Active" Value="1" />
                                            <telerik:RadComboBoxItem Text="InActive" Value="0" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <%--<asp:RequiredFieldValidator ID="rfv_TdsStatus" runat="server" InitialValue="Select"
                                        Text="*" ControlToValidate="chk_TdsStatus" ValidationGroup="Controls" ErrorMessage="Select the Status">
                                    </asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                        </table>
                        <table align="center">
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btn_Save" runat="server" Text="Save" ValidationGroup="Controls" OnClick="btn_Save_Click" TabIndex="5" />
                                    <asp:Button ID="btn_Update" runat="server" Text="Update" ValidationGroup="Controls" TabIndex="5"
                                        OnClick="btn_Save_Click" />
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" TabIndex="6" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="vs_TDS" runat="server" ShowMessageBox="true" ShowSummary="false"
        ValidationGroup="Controls" />
</asp:Content>