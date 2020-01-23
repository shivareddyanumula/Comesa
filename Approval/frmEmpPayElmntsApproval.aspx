﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frmEmpPayElmntsApproval.aspx.cs" Inherits="Approval_frmEmpPayElmntsApproval" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center" style="vertical-align: top;">
        <tr>
            <td align="center">
                <asp:Label ID="lblEmpPayElmntsApproval" runat="server" Text=" Pay Items Approval " Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <br /><%--<asp:Label runat="server" ID="lblStatus" Text="Status" Font-Bold="true"></asp:Label>&nbsp;&nbsp;<b>:</b>&nbsp;&nbsp;--%>                
                <asp:RadioButtonList runat="server" ID="rblStatus" OnTextChanged="rblStatus_TextChanged"
                    RepeatDirection="Horizontal" AutoPostBack="true">
                    <asp:ListItem Text="Submitted&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" Value="0" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Approved&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Rejected" Value="2"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="rmpEmpPayElmntsApproval" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="100%">
                    <telerik:RadPageView ID="rpvEmpPayElmntsApproval" runat="server" Selected="True">
                        <asp:UpdatePanel ID="upEmpPayElmntsApproval" runat="server">
                            <ContentTemplate>
                                <table align="center" width="100%">
                                    <tr>
                                        <td>
                                            <telerik:RadGrid ID="rgEmpPayElmntsApproval" runat="server" AutoGenerateColumns="False"
                                                AllowFilteringByColumn="True" AllowSorting="True" Skin="WebBlue" GridLines="None"
                                                OnNeedDataSource="rgEmpPayElmntsApproval_NeedDataSource" AllowPaging="True" PageSize="5">
                                                <GroupingSettings CaseSensitive="False" />
                                               <%-- <MasterTableView CommandItemDisplay="Top">--%>
                                                <MasterTableView  CommandItemDisplay="Top"   InsertItemPageIndexAction="ShowItemOnFirstPage">
                                                    <Columns>
                                                        <telerik:GridTemplateColumn AllowFiltering="False" UniqueName="CHOOSE" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="true"
                                                                    OnCheckedChanged="chkAll_CheckedChanged" Text="Check All" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chk" runat="server" />
                                                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>' Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridBoundColumn DataField="ID" HeaderText="ID" meta:resourceKey="ID"
                                                            UniqueName="ID" Visible="False">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EMP_EMPCODE" HeaderText="Code" meta:resourcekey="EMP_EMPCODE"
                                                            UniqueName="EMP_EMPCODE" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EMP_NAME" HeaderText="Name" meta:resourcekey="EMP_NAME"
                                                            UniqueName="EMP_NAME" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PAYITEM_PAYITEMNAME" HeaderText="Pay Item"
                                                            meta:resourcekey="PAYITEM_PAYITEMNAME" UniqueName="PAYITEM_PAYITEMNAME"
                                                            ItemStyle-HorizontalAlign="Left">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="AMOUNT" HeaderText="Amount"
                                                            meta:resourcekey="AMOUNT" UniqueName="AMOUNT"
                                                            ItemStyle-HorizontalAlign="Left">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="STATUS" HeaderText="Status"
                                                            meta:resourcekey="STATUS" UniqueName="STATUS"
                                                            ItemStyle-HorizontalAlign="Left">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                    </Columns>
                                                    <CommandItemTemplate>
                                                        <div align="right">
                                                            <asp:LinkButton ID="lnk_Add" runat="server" Visible="false">Add</asp:LinkButton>
                                                        </div>
                                                    </CommandItemTemplate>
                                                </MasterTableView>
                                                <PagerStyle AlwaysVisible="True" />
                                            </telerik:RadGrid>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                            <Triggers>
                            </Triggers>
                        </asp:UpdatePanel>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button runat="server" ID="btnApprove" Text="Approve" OnClick="btn_Click" />&nbsp;&nbsp;&nbsp;
                <asp:Button runat="server" ID="btnReject" Text="Reject" OnClick="btn_Click" />
            </td>
        </tr>
    </table>
</asp:Content>