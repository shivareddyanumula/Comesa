<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="bonus.aspx.cs" Inherits="bonus" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <br />
    <br />
    <table align="center">
        <tr>
            <td colspan="6" align="center">
                <asp:Label ID="lbl_header" runat="server" Text="Masters For Bonus"></asp:Label>
            </td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0">
                    <telerik:RadPageView ID="RadPageView1" runat="server">
                        <table align="center">

                            <tr>
                                <td></td>
                                <td>
                                    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False"
                                        Skin="Office2007" AllowPaging="False" GridLines="None" AllowSorting="True" Width="500px">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                            <Columns>
                                                <telerik:GridTemplateColumn HeaderText="Business Unit">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_businessunit" runat="server" Text='<%#Eval("BUSINESSUNIT_CODE") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="PayItemHead">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_payitemhead" runat="server" Text='<%#Eval("PAYITEM_PAYITEMNAME") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbtn_Edit" Text="Edit" runat="server" OnCommand="lbtn_Edit_OnCommand"
                                                            CommandArgument='<%#Eval("BONUS_ID") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <EditFormSettings>
                                                <EditColumn CancelImageUrl="Cancel.gif" EditImageUrl="Edit.gif" InsertImageUrl="Update.gif"
                                                    UpdateImageUrl="Update.gif">
                                                </EditColumn>
                                            </EditFormSettings>
                                            <PagerStyle AlwaysVisible="True" />
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" OnClick="lnk_add"
                                                        Text="Add"></asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <HeaderContextMenu Skin="WebBlue">
                                        </HeaderContextMenu>
                                        <PagerStyle AlwaysVisible="True" />
                                        <FilterMenu Skin="WebBlue">
                                        </FilterMenu>
                                    </telerik:RadGrid>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RadPageView12" runat="server" Width="100%">
                        <table align="center">

                            <tr>
                                <td></td>
                                <td colspan="2"></td>
                                <td colspan="2"></td>
                                <td width="10%"></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td align="left"></td>
                                <td align="left"></td>
                                <%--<td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_period" runat="server" ControlToValidate="rcmb_period"
                                        ErrorMessage="Please Select Period " InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>--%>
                            </tr>
                            <tr>
                                <td></td>
                                <td>Bussiness&nbsp;Unit
                                </td>
                                <td>:
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="rcmb_businessunit" runat="server" AutoPostBack="false" MarkFirstMatch="true" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td align="left"></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_businessunit" runat="server" ControlToValidate="rcmb_businessunit"
                                        ErrorMessage="Please Select BusinessUnit " InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>Restriction&nbsp;Amount
                                </td>
                                <td>:
                                </td>
                                <td align="left">
                                    <telerik:RadNumericTextBox ID="rtxt_restrictionamount" runat="server" MaxLength="8">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td align="left"></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_restrictionamount" runat="server" ControlToValidate="rtxt_restrictionamount"
                                        ErrorMessage="Please Enter Restriction Amount" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Label ID="lbl_selectpayitemhead" runat="server" Text="Select&nbsp;Pay&nbsp;Item&nbsp;Head"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="rcmb_selectpayitemhead" runat="server" Filter="Contains"
                                        OnSelectedIndexChanged="rcmb_selectpayitemhead_SelectedIndexChanged" AutoPostBack="True" MarkFirstMatch="true">
                                    </telerik:RadComboBox>
                                </td>
                                <td align="left"></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_selectpayitemhead" runat="server" ControlToValidate="rcmb_selectpayitemhead"
                                        ErrorMessage="Please Select Pay Item Head" ValidationGroup="Controls" InitialValue="Select">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Pay Items"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td align="left" rowspan="5">
                                    <asp:Panel ID="Pnl_Payitems" runat="server" ScrollBars="Vertical" Height="120px"
                                        Width="100%">
                                        <asp:CheckBoxList ID="chck_Payitems" runat="server" Visible="TRUE">
                                        </asp:CheckBoxList>
                                    </asp:Panel>
                                    <br />
                                </td>
                                <td align="left">
                                    <%--<asp:RequiredFieldValidator ID="Rfv_chklist" runat="server" ControlToValidate="chck_Payitems"
                                        ErrorMessage="Please Select Payitem" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                    --%>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                                <td align="left">&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                                <td align="left">&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                                <td align="left">&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                                <td align="left">&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>Minimum&nbsp;Bonus
                                </td>
                                <td>:
                                </td>
                                <td align="left">
                                    <telerik:RadNumericTextBox ID="rtxt_minimumbonus" runat="server" MaxLength="4">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td align="left">
                                    <b>%</b>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_minimumbonus" runat="server" ControlToValidate="rtxt_minimumbonus"
                                        ErrorMessage="Please Enter Minimum Bonus" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>Maximum&nbsp;Bonus
                                </td>
                                <td>:
                                </td>
                                <td align="left">
                                    <telerik:RadNumericTextBox ID="rtxt_maximumbonus" runat="server" MaxLength="4">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td align="left">
                                    <b>%</b>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_maximumbonus" runat="server" ControlToValidate="rtxt_maximumbonus"
                                        ErrorMessage="Please Enter Maximum Bonus" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td colspan="2"></td>
                                <td colspan="2"></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td colspan="2"></td>
                                <td colspan="2"></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td colspan="4" align="center">
                                    <asp:Button ID="btn_update" runat="server" OnClick="btnUpdate_Click" Text="Update"
                                        Visible="False" ValidationGroup="Controls" />
                                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" ValidationGroup="Controls" />
                                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
                                    <asp:ValidationSummary ID="vs_bonus" runat="server" ShowMessageBox="True" ShowSummary="False"
                                        ValidationGroup="Controls" />
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td colspan="2"></td>
                                <td colspan="2"></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td colspan="2"></td>
                                <td colspan="2"></td>
                                <td></td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
            <td></td>
        </tr>
    </table>
</asp:Content>