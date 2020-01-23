<%@ Page Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_PayrollPeriod.aspx.cs" Inherits="Masters_frm_PayrollPeriod" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <br />
        <tr>
            <td align="center">
                <asp:Label ID="lbl_Header" runat="server" Text="Payroll&nbsp;Period" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="RMP_PayrollPeriod" runat="server" SelectedIndex="0">
                    <telerik:RadPageView ID="RPV_PayrollPeriod" runat="server" Selected="true">
                        <table>
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="rg_PayrollPeriod" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                        GridLines="None" Skin="WebBlue" AllowFilteringByColumn="true"
                                        OnNeedDataSource="rg_PayrollPeriod_NeedDataSource">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="PAYROLLPERIOD_ID" UniqueName="PAYROLLPERIOD_ID" Visible="false"
                                                    HeaderText="ID" meta:resourcekey="PAYROLLPERIOD_ID">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="BUSINESSUNIT_CODE" UniqueName="BUSINESSUNIT_CODE"
                                                    HeaderText="Buniness&nbsp;Unit" meta:resourcekey="BUSINESSUNIT_CODE">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="PERIOD_NAME" UniqueName="PERIOD_NAME"
                                                    HeaderText="Period" meta:resourcekey="PERIOD_NAME">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="PRDDTL_NAME" UniqueName="PRDDTL_NAME"
                                                    HeaderText="Period&nbsp;Details" meta:resourcekey="PRDDTL_NAME">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="PAYROLLPERIOD_STARTDATE" UniqueName="PAYROLLPERIOD_STARTDATE"
                                                    HeaderText="Start&nbsp;Date" meta:resourcekey="PAYROLLPERIOD_STARTDATE" DataFormatString="{0:d}">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="PAYROLLPERIOD_ENDDATE" UniqueName="PAYROLLPERIOD_ENDDATE"
                                                    HeaderText="End&nbsp;Date" meta:resourcekey="PAYROLLPERIOD_ENDDATE" DataFormatString="{0:d}">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColEdit"
                                                    meta:resourceKey="ColEdit" ItemStyle-HorizontalAlign="Left" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("PAYROLLPERIOD_ID") %>'
                                                            meta:resourcekey="lnk_Edit" OnCommand="lnk_Edit_Command">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" meta:resourceKey="lnk_Add"
                                                        OnCommand="lnk_Add_Command">Add</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <PagerStyle AlwaysVisible="True" />
                                        <FilterMenu Skin="WebBlue">
                                        </FilterMenu>
                                        <HeaderContextMenu Skin="WebBlue">
                                        </HeaderContextMenu>
                                        <GroupingSettings CaseSensitive="false" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RPV_PayrollPeriodDetails" runat="server">
                        <table align="center">
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_BU" runat="server" Text="Business&nbsp;Unit"></asp:Label>
                                    <asp:Label ID="lbl_ID" runat="server" Visible="false"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_BU" runat="server" MarkFirstMatch="true" TabIndex="1"
                                        MaxHeight="120px" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_BU" runat="server" ControlToValidate="rcmb_BU" ErrorMessage="Please Select Busniness Unit"
                                        Text="*" ValidationGroup="Controls" InitialValue="Select">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Period" runat="server" Text="Period"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Period" runat="server" MarkFirstMatch="true" TabIndex="2"
                                        MaxHeight="120px" AutoPostBack="true" Filter="Contains"
                                        OnSelectedIndexChanged="rcmb_Period_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_Period" runat="server" ControlToValidate="rcmb_Period" ErrorMessage="Please Select Period"
                                        Text="*" ValidationGroup="Controls" InitialValue="Select">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_PeriodDetails" runat="server" Text="Period&nbsp;Details"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_PeriodDetails" runat="server" MarkFirstMatch="true" MaxHeight="120px"
                                        AutoPostBack="true" TabIndex="3" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_PeriodDetails" runat="server" ControlToValidate="rcmb_BU" ErrorMessage="Please Select Period Details"
                                        Text="*" ValidationGroup="Controls" InitialValue="Select">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_StartDate" runat="server" Text="Start&nbsp;Date"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="rdtp_StartDate" runat="server" TabIndex="4"></telerik:RadDatePicker>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rdtp_StartDate" runat="server" ControlToValidate="rdtp_StartDate" ErrorMessage="Please Select Start Date"
                                        Text="*" ValidationGroup="Controls">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_EndDate" runat="server" Text="End&nbsp;Date"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="rdtp_EndDate" runat="server" TabIndex="5"></telerik:RadDatePicker>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rdtp_EndDate" runat="server" ControlToValidate="rdtp_EndDate" ErrorMessage="Please Select End Date"
                                        Text="*" ValidationGroup="Controls">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Button ID="btn_Save" runat="server" Text="Save" ValidationGroup="Controls" TabIndex="6"
                                        OnClick="btn_Save_Click" />
                                    <asp:Button ID="btn_Update" runat="server" Text="Update" ValidationGroup="Controls" TabIndex="6"
                                        OnClick="btn_Save_Click" />
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" TabIndex="7"
                                        OnClick="btn_Cancel_Click" />
                                    <asp:ValidationSummary ID="vs_PAYROLLPERIOD" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="Controls" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>