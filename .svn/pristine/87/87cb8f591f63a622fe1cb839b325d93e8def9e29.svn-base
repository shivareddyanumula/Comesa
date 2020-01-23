<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_TaxExempt.aspx.cs" Inherits="Masters_frm_TaxExempt" Culture="auto"
    UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td>
                <telerik:RadMultiPage ID="RMP_Tax_Exempt" runat="server" Width="1004px" Height="490px"
                    ScrollBars="Auto" SelectedIndex="0">
                    <telerik:RadPageView ID="RPW_Tax_Exempt_search" runat="server" Selected="True">
                        <br />
                        <table align="center">
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:Label ID="lbl_header" runat="server" meta:resourcekey="lbl_header"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <telerik:RadGrid ID="RG_Tax_Exempt" runat="server" AutoGenerateColumns="False" Skin="WebBlue"
                                        GridLines="None" OnNeedDataSource="RG_Tax_Exempt_NeedDataSource" AllowPaging="true" AllowFilteringByColumn="true">
                                        <%-- <PagerStyle AlwaysVisible="true" Mode="NumericPages" />--%>
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn UniqueName="SMHR_TAX_ID" DataField="SMHR_TAX_ID" Visible="False"
                                                    meta:resourcekey="SMHR_TAX_ID">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn UniqueName="COUNTRY_CODE" DataField="COUNTRY_CODE" meta:resourcekey="COUNTRY_CODE" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn UniqueName="SMHR_TAX_NAME" DataField="SMHR_TAX_NAME" meta:resourcekey="SMHR_TAX_NAME" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn UniqueName="SMHR_TAX_DESC" DataField="SMHR_TAX_DESC" meta:resourcekey="SMHR_TAX_DESC" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn UniqueName="SMHR_TAX_MAXLIMIT" DataField="SMHR_TAX_MAXLIMIT"
                                                    meta:resourcekey="SMHR_TAX_MAXLIMIT" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn UniqueName="SMHR_TAX_ACTIVE" DataField="SMHR_TAX_ACTIVE"
                                                    meta:resourcekey="SMHR_TAX_ACTIVE" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="Edit" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("SMHR_TAX_ID") %>'
                                                            OnCommand="lnk_Edit_Command">Edit </asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" OnClick="lnk_Add_Click" Text="Add"></asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RPW_Tax_Exempt_AddUpdate" runat="server">
                        <br />
                        <table align="center" width="40%">
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:Label ID="lbl_Det_Header" runat="server" meta:resourcekey="lbl_Det_Header"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Country_ID" runat="server" meta:resourcekey="lbl_Country_ID"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="ddl_Country" runat="server" Skin="WebBlue" MarkFirstMatch="true" MaxHeight="120px" TabIndex="1" Filter="Contains">
                                    </telerik:RadComboBox>
                                    <asp:RequiredFieldValidator ID="rfv_Country" runat="server" Text="*" ControlToValidate="ddl_Country"
                                        ValidationGroup="Controls" Display="Dynamic" InitialValue="Select" meta:resourcekey="rfv_Country"></asp:RequiredFieldValidator>
                                </td>
                                <td>&#160;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_TaxName" runat="server" meta:resourcekey="lbl_TaxName"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_TaxName" runat="server" Skin="WebBlue" TabIndex="2"
                                        MaxLength="100">
                                    </telerik:RadTextBox><asp:RequiredFieldValidator ID="rfv_Name0" runat="server" ControlToValidate="rtxt_TaxName"
                                        Display="Dynamic" meta:resourcekey="rfv_Name" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                                <td>&#160;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_TaxDesc" runat="server" meta:resourcekey="lbl_TaxDesc"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_TaxDesc" runat="server" Skin="WebBlue" TabIndex="3"
                                        MaxLength="200">
                                    </telerik:RadTextBox><asp:RequiredFieldValidator ID="rfv_Desc0" runat="server" ControlToValidate="rtxt_TaxDesc"
                                        Display="Dynamic" meta:resourcekey="rfv_Desc" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                                <td>&#160;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_TaxMaxLimit" runat="server" meta:resourcekey="lbl_TaxMaxLimit"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="rntxt_MaxLimit" runat="server" Skin="WebBlue" TabIndex="4"
                                        MaxLength="7" MinValue="0">
                                        <NumberFormat DecimalDigits="2" />
                                    </telerik:RadNumericTextBox><asp:RequiredFieldValidator ID="rfv_maxlimit0" runat="server"
                                        ControlToValidate="rntxt_MaxLimit" meta:resourcekey="rfv_maxlimit" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                                <td>&#160;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Active" runat="server" meta:resourcekey="lbl_Active"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="ddl_Active" runat="server" AutoPostBack="true" Skin="WebBlue" MarkFirstMatch="true" TabIndex="5">
                                        <Items>
                                            <telerik:RadComboBoxItem Text="Active" Value="1" />
                                            <telerik:RadComboBoxItem Text="InActive" Value="0" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                                <td>&#160;&nbsp;<asp:CheckBox ID="chk_Active" runat="server" Visible="false" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:Button ID="btn_Add" runat="server" Text="Save" OnClick="btn_Add_Click" ValidationGroup="Controls" TabIndex="6" /><asp:Button
                                        ID="btn_Correct" runat="server" Text="Update" OnClick="btn_Correct_Click" ValidationGroup="Controls" TabIndex="6" /><asp:Button
                                            ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" TabIndex="7" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="vs_Summary" runat="server" ShowMessageBox="true" ShowSummary="false"
        ValidationGroup="Controls" />
</asp:Content>