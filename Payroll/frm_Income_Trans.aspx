<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_Income_Trans.aspx.cs" Inherits="Payroll_frm_Income_Trans" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td>
                <telerik:RadMultiPage ID="rmp_IncomeTrans" runat="server" Width="990px" SelectedIndex="0">
                    <telerik:RadPageView ID="rpw_IncomeTrans" runat="server">
                        <table align="center">
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Header" runat="server" Text="Employee Other Income Savings" Font-Bold="true">
                                    </asp:Label>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table align="center">

                            <tr>
                                <td>
                                    <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business&nbsp;Unit">
                                    </asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcb_BusinessUnit" runat="server" Skin="WebBlue" Filter="Contains"
                                        AutoPostBack="true" OnSelectedIndexChanged="rcb_BusinessUnit_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_period" runat="server" Text="Financial Period"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_period" runat="server" Skin="WebBlue"
                                        AutoPostBack="true" Filter="Contains"
                                        OnSelectedIndexChanged="rcmb_period_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Employee" runat="server" Text="Employee">
                                    </asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcb_Employee" runat="server" Skin="WebBlue" MaxHeight="120px" Filter="Contains"
                                        AutoPostBack="true" OnSelectedIndexChanged="rcb_Employee_SelectedIndexChanged" MarkFirstMatch="true">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>

                            <tr>
                                <td colspan="3" align="center">
                                    <asp:Button ID="btn_Save" runat="server" Text="Save" Visible="false" OnClick="btn_Save_Click" />
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" Visible="false" OnClick="btn_Cancel_Click" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table align="center" width="60%">
                            <tr>
                                <td>
                                    <table align="center" width="100%">
                                        <tr>
                                            <td>
                                                <telerik:RadGrid ID="RG_Employee" runat="server" Skin="WebBlue" AutoGenerateColumns="false"
                                                    OnNeedDataSource="RG_Employee_NeedDataSource" Width="100%" AllowFilteringByColumn="true" ClientSettings-Scrolling-AllowScroll="true" ClientSettings-Scrolling-UseStaticHeaders="true">
                                                    <HeaderContextMenu Skin="WebBlue">
                                                    </HeaderContextMenu>
                                                    <MasterTableView>
                                                        <Columns>
                                                            <telerik:GridTemplateColumn UniqueName="SMHR_INCOME_ID" Visible="false" HeaderText="ID">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_tax_id" runat="server" Text='<%# Eval("SMHR_INCOME_ID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn UniqueName="SMHR_INCOME_NAME" HeaderText="Element&nbsp;Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_tax_name" runat="server" Text='<%# Eval("SMHR_INCOME_NAME") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn UniqueName="SMHR_EMPINCOME_AMOUNT" HeaderText="Amount">
                                                                <ItemTemplate>
                                                                    <telerik:RadNumericTextBox ID="rntxt_Number" runat="server" Value='<%# Convert.ToDouble(Eval("SMHR_EMPINCOME_AMOUNT")) %>'
                                                                        Skin="WebBlue" IncrementSettings-InterceptArrowKeys="true" IncrementSettings-InterceptMouseWheel="true" MaxLength="12" MinValue="0"
                                                                        IncrementSettings-Step="0">
                                                                    </telerik:RadNumericTextBox>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn UniqueName="SMHR_INCOME_MAXLIMIT" HeaderText="Tax&nbsp;Limit">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_tax_maxlimit" runat="server" Text='<%# Convert.ToDouble(Eval("SMHR_INCOME_MAXLIMIT")) %>'>
                                                                    </asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridTemplateColumn>
                                                        </Columns>
                                                    </MasterTableView>
                                                </telerik:RadGrid>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>