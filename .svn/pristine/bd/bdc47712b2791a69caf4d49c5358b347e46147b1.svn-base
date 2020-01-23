<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_KenyaPayItem.aspx.cs" Inherits="Masters_frm_KenyaPayItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_Header" runat="server" Text="Setup For Tax Deductions" Font-Bold="true">
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
                                    <telerik:RadGrid ID="rg_Main" runat="server" AutoGenerateColumns="false" GridLines="None"
                                        AllowPaging="true" Skin="WebBlue" AllowFilteringByColumn="true">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="BUSINESSUNIT_CODE" HeaderText="Business Unit"
                                                    UniqueName="BUSINESSUNIT_CODE" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="PAYITEM_PAYITEMNAME" HeaderText="Payitem" UniqueName="PAYITEM_CODE"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="PERIOD_NAME" HeaderText="Period" UniqueName="PERIOD_CODE"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="STATUS" HeaderText="Status" UniqueName="STATUS"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="EDIT" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" Text="Edit" CommandArgument='<%# Eval("KENYA_PAYITEM_ID") %>'
                                                            OnCommand="lnk_Edit_Command">
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
                                    <asp:Label ID="lbl_BusinessUnit" runat="server" Text="BusinessUnit">
                                    </asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_BusinessUnit" runat="server" AutoPostBack="true" MarkFirstMatch="true" MaxHeight="120px" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_BusinessUnit" runat="server" InitialValue="Select"
                                        Text="*" ControlToValidate="rcmb_BusinessUnit" ValidationGroup="Controls" ErrorMessage="Please Select BusinessUnit">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="right">
                                    <asp:Label ID="lbl_PayItemNote" runat="server" Text="(only Deductions are listed here)">
                                    </asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_PayItem" runat="server" Text="Pay Item">
                                    </asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_PayItem" runat="server" AutoPostBack="true" MarkFirstMatch="true" MaxHeight="120px" Filter="Contains">
                                    </telerik:RadComboBox>
                                    &nbsp;
                                    <%-- <asp:Label ID="lbl_PayItemNote" runat="server" Text="(only Deductions are listed here)">
                                    </asp:Label>--%>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_PayItem" runat="server" InitialValue="Select"
                                        Text="*" ControlToValidate="rcmb_PayItem" ValidationGroup="Controls" ErrorMessage="Please Select Pay Item">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_period" runat="server" Text="Period"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_period" runat="server" MarkFirstMatch="true" MaxHeight="120px" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_period" runat="server" InitialValue="Select"
                                        Text="*" ControlToValidate="rcmb_period" ValidationGroup="Controls" ErrorMessage="Please Select Period">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Status" runat="server" Text="Status">
                                    </asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <%-- <asp:CheckBox ID="chk_Status" runat="server" AutoPostBack="true" />--%>
                                    <telerik:RadComboBox ID="rcmb_Status" runat="server" AutoPostBack="true" Skin="WebBlue" MarkFirstMatch="true">
                                        <Items>
                                            <telerik:RadComboBoxItem Text="Active" Value="1" />
                                            <telerik:RadComboBoxItem Text="InActive" Value="0" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <%-- <asp:RequiredFieldValidator ID="rfv_Status" runat="server" InitialValue="Select"
                                        Text="*" ControlToValidate="chk_Status" ValidationGroup="Controls" ErrorMessage="Select Status">
                                    </asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                        </table>
                        <table align="center">
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click" ValidationGroup="Controls" />
                                    <asp:Button ID="btn_Update" runat="server" Text="Update" OnClick="btn_Save_Click"
                                        ValidationGroup="Controls" />
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="vs_KenyaPayItem" runat="server" ShowMessageBox="true"
        ShowSummary="false" ValidationGroup="Controls" />
</asp:Content>