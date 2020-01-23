<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_OtherIncome.aspx.cs" Inherits="Masters_frm_OtherIncome" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
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
                                    <asp:Label ID="lbl_header" runat="server" meta:resourcekey="lbl_header" Text="Income Element Definition"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <telerik:RadGrid ID="RG_Income_Exempt" runat="server"
                                        AutoGenerateColumns="False" Skin="WebBlue"
                                        GridLines="None" OnNeedDataSource="RG_Income_Exempt_NeedDataSource"
                                        AllowPaging="true" AllowFilteringByColumn="true">
                                        <%-- <PagerStyle AlwaysVisible="true" Mode="NumericPages" />--%>
                                        <MasterTableView CommandItemDisplay="Top">
                                            <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="SMHR_INCOME_ID" meta:resourcekey="SMHR_INCOME_ID"
                                                    UniqueName="SMHR_INCOME_ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="BUSINESSUNIT_CODE"
                                                    ItemStyle-HorizontalAlign="Left" meta:resourcekey="BUSINESSUNIT_CODE"
                                                    UniqueName="BUSINESSUNIT_CODE" HeaderText="Business&nbsp;Unit">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SMHR_INCOME_NAME"
                                                    ItemStyle-HorizontalAlign="Left" meta:resourcekey="SMHR_INCOME_NAME"
                                                    UniqueName="SMHR_INCOME_NAME" HeaderText="Name">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SMHR_INCOME_DESC"
                                                    ItemStyle-HorizontalAlign="Left" meta:resourcekey="SMHR_INCOME_DESC"
                                                    UniqueName="SMHR_INCOME_DESC" HeaderText="Description">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SMHR_INCOME_MAXLIMIT"
                                                    ItemStyle-HorizontalAlign="Left" meta:resourcekey="SMHR_INCOME_MAXLIMIT"
                                                    UniqueName="SMHR_INCOME_MAXLIMIT" HeaderText="Maximum&nbsp;Limit">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SMHR_INCOME_ACTIVE"
                                                    ItemStyle-HorizontalAlign="Left" meta:resourcekey="SMHR_INCOME_ACTIVE"
                                                    UniqueName="SMHR_INCOME_ACTIVE" HeaderText="Active">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="False" UniqueName="Edit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server"
                                                            CommandArgument='<%# Eval("SMHR_INCOME_ID") %>' OnCommand="lnk_Edit_Command">Edit
                                                        </asp:LinkButton>
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
                                    <asp:Label ID="lbl_Det_Header" runat="server" meta:resourcekey="lbl_Det_Header" Text="Income Element Definition"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_BU_ID" runat="server" meta:resourcekey="lbl_BU_ID" Text="Business&nbsp;Unit"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="ddl_Businessunit" runat="server" Skin="WebBlue" MarkFirstMatch="true" MaxHeight="120px" TabIndex="1" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_ddl_Businessunit" runat="server" Text="*" ControlToValidate="ddl_Businessunit"
                                        ValidationGroup="Controls" Display="Dynamic" InitialValue="Select" meta:resourcekey="rfv_ddl_Businessunit" ErrorMessage="Please Select Business Unit"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_IncomeName" runat="server" meta:resourcekey="lbl_IncomeName" Text="Name"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_IncomeName" runat="server" Skin="WebBlue" TabIndex="2"
                                        MaxLength="100">
                                    </telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_IncomeName" runat="server" ControlToValidate="rtxt_IncomeName"
                                        Display="Dynamic" meta:resourcekey="rfv_rtxt_IncomeName" Text="*" ValidationGroup="Controls" ErrorMessage="Please Enter Name"></asp:RequiredFieldValidator>
                                </td>
                                <td>&#160;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_IncomeDesc" runat="server" meta:resourcekey="lbl_IncomeDesc" Text="Description"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_IncomeDesc" runat="server" Skin="WebBlue" TabIndex="3"
                                        MaxLength="100">
                                    </telerik:RadTextBox><asp:RequiredFieldValidator ID="rfv_rtxt_IncomeDesc" runat="server" ControlToValidate="rtxt_IncomeDesc"
                                        Display="Dynamic" meta:resourcekey="rfv_rtxt_IncomeDesc" Text="*" ValidationGroup="Controls" ErrorMessage="Please Enter Description"></asp:RequiredFieldValidator>
                                </td>
                                <td>&#160;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_IncomeMaxLimit" runat="server" meta:resourcekey="lbl_IncomeMaxLimit" Text="Maximum Limit"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="rntxt_MaxLimit" runat="server" Skin="WebBlue" TabIndex="4"
                                        MaxLength="7" MinValue="0">


                                        <NumberFormat DecimalDigits="2" />


                                    </telerik:RadNumericTextBox><asp:RequiredFieldValidator ID="rfv_rntxt_MaxLimit" runat="server"
                                        ControlToValidate="rntxt_MaxLimit" meta:resourcekey="rfv_rntxt_MaxLimit" Text="*" ValidationGroup="Controls" ErrorMessage="Please Enter Maximum Limit"></asp:RequiredFieldValidator>
                                </td>
                                <td>&#160;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Active" runat="server" meta:resourcekey="lbl_Active" Text="Status"></asp:Label>
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
                                <td>&#160;<asp:CheckBox ID="chk_Active" runat="server" Visible="false" />
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