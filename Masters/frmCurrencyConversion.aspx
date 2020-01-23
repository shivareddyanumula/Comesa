<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frmCurrencyConversion.aspx.cs" Inherits="Masters_frmCurrencyConversion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_Header" runat="server" Text="Currency Conversion" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_CurrConv" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_CurrConv" runat="server" Selected="True">
                        <table align="center">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_CurrConv" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        AllowPaging="True" AllowFilteringByColumn="true" Skin="WebBlue" OnNeedDataSource="Rg_CurrConv_NeedDataSource">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="CURRENCY_CONVERSION_ID" UniqueName="CURRENCY_CONVERSION_ID"
                                                    HeaderText="ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="BUSINESSUNIT_CODE" UniqueName="BUSINESSUNIT_CODE"
                                                    AllowFiltering="true" HeaderText="Business Unit" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="FROM_CURR" UniqueName="FROM_CURR" AllowFiltering="true"
                                                    HeaderText="From Currency" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="TO_CURR" UniqueName="TO_CURR" AllowFiltering="true"
                                                    HeaderText="To Currency" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="CURRENCY_CONVERSION_RATE" UniqueName="CURRENCY_CONVERSION_RATE"
                                                    AllowFiltering="true" HeaderText="Conversion Rate" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="ColEdit" AllowFiltering="false"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("CURRENCY_CONVERSION_ID") %>'
                                                            OnCommand="lnk_Edit_Command" meta:resourcekey="lnk_Edit">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" OnCommand="lnk_Add_Command" meta:resourceKey="lnk_Add">Add</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <PagerStyle AlwaysVisible="true" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_Location_ViewDetails" runat="server">
                        <table align="center" width="30%">
                            <tr>
                                <td colspan="3" align="center" style="font-weight: bold;"></td>
                                <td align="center" style="font-weight: bold;">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_currID" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="lbl_Bu" runat="server" Text="Business&nbsp;Unit"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="rcmb_BusinessUnit" runat="server" MarkFirstMatch="true" MaxHeight="120px" Filter="Contains"
                                        AutoPostBack="True" Skin="WebBlue" OnSelectedIndexChanged="rcmb_BusinessUnit_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_rcmb_BusinessUnit" runat="server" ControlToValidate="rcmb_BusinessUnit"
                                        ErrorMessage="Please Select Business Unit" Text="*" ValidationGroup="Controls"
                                        InitialValue="Select"> </asp:RequiredFieldValidator>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_FromCurrency" runat="server" Text="From&nbsp;Currency"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="rcmb_FromCurrency" runat="server" MarkFirstMatch="true" MaxHeight="120px"
                                        Skin="WebBlue" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_rcmb_FromCurrency" runat="server" ControlToValidate="rcmb_FromCurrency"
                                        ErrorMessage="Please Select From Currency" Text="*" ValidationGroup="Controls"
                                        InitialValue="Select"> </asp:RequiredFieldValidator>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_ToCurrency" runat="server" Text="To&nbsp;Currency"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="rcmb_ToCurrency" runat="server" MarkFirstMatch="true" Skin="WebBlue" MaxHeight="120px" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_rcmb_ToCurrency" runat="server" ControlToValidate="rcmb_ToCurrency"
                                        ErrorMessage="Please Select To Currency" Text="*" ValidationGroup="Controls"
                                        InitialValue="Select"> </asp:RequiredFieldValidator>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_ConvRate" runat="server" Text="Conversion&nbsp;Rate"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadNumericTextBox ID="rnt_ConvRate" runat="server" Skin="WebBlue" NumberFormat-DecimalDigits="7">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_rnt_ConvRate" runat="server" ControlToValidate="rnt_ConvRate"
                                        ErrorMessage="Please Enter Conversion Rate" Text="*" ValidationGroup="Controls"> </asp:RequiredFieldValidator>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td colspan="3" align="center">
                                    <asp:Button ID="btn_Update" runat="server" Text="Update" Visible="False" ValidationGroup="Controls"
                                        OnClick="btn_Save_Click" />
                                    <asp:Button ID="btn_Save" runat="server" Text="Save" Visible="False" ValidationGroup="Controls"
                                        OnClick="btn_Save_Click" />
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
                                    <asp:ValidationSummary ID="vs_CurrConv" runat="server" ShowMessageBox="True" ValidationGroup="Controls"
                                        ShowSummary="False" meta:resourcekey="vs_CurrConv" />
                                </td>
                                <td align="center">&nbsp;
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>