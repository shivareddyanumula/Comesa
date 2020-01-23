<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frmEmpDtlsCnfm.aspx.cs" Inherits="Approval_frmEmpDtlsCnfm" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" Runat="Server">
<table align="center" style="vertical-align: top;">
        <tr>
            <td align="center">
                <asp:Label ID="lblfrmEmpDtlsCnfm" runat="server" Text=" Employee Details Confirm " Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="rmpfrmEmpDtlsCnfm" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="100%">
                    <telerik:RadPageView ID="rpvfrmEmpDtlsCnfm" runat="server" Selected="True">
                        <asp:UpdatePanel ID="upfrmEmpDtlsCnfm" runat="server">
                            <ContentTemplate>
                                <table align="center" width="100%">
                                    <tr>
                                        <td>
                                            <telerik:RadGrid ID="rgfrmEmpDtlsCnfm" runat="server" AutoGenerateColumns="False"
                                                AllowFilteringByColumn="True" AllowSorting="True" Skin="WebBlue" GridLines="None"
                                                OnNeedDataSource="rgfrmEmpDtlsCnfm_NeedDataSource" AllowPaging="True" PageSize="10">
                                                <GroupingSettings CaseSensitive="False" />
                                                <MasterTableView CommandItemDisplay="None">
                                                    <Columns>
                                                        <telerik:GridTemplateColumn AllowFiltering="False" UniqueName="CHOOSE" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="true"
                                                                    OnCheckedChanged="chkAll_CheckedChanged" Text="Check All" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chk" runat="server" />
                                                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("EMP_ID") %>' Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridBoundColumn DataField="EMP_ID" HeaderText="EMP_ID" meta:resourceKey="EMP_ID"
                                                            UniqueName="ID" Visible="False">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BU_CODE" HeaderText="Business Unit"
                                                            meta:resourcekey="BU_CODE" UniqueName="BU_CODE" AutoPostBackOnFilter="true"
                                                            ItemStyle-HorizontalAlign="Left">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EMP_EMPCODE" HeaderText="Employee Code"
                                                            meta:resourcekey="EMP_EMPCODE" AutoPostBackOnFilter="true"
                                                            UniqueName="EMP_EMPCODE" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <%--<telerik:GridBoundColumn DataField="STATUS" HeaderText="Employee Status"
                                                            meta:resourcekey="STATUS" UniqueName="STATUS" AutoPostBackOnFilter="true"
                                                            ItemStyle-HorizontalAlign="Left" AllowFiltering="false">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>--%>
                                                        <telerik:GridBoundColumn DataField="EMP_NAME" HeaderText="Employee Name" meta:resourcekey="EMP_NAME"
                                                            UniqueName="EMP_NAME" ItemStyle-HorizontalAlign="Left" AutoPostBackOnFilter="true">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="GRADE" HeaderText="Grade"
                                                            meta:resourcekey="GRADE" UniqueName="GRADE" AutoPostBackOnFilter="true"
                                                            ItemStyle-HorizontalAlign="Left">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="TYPE" HeaderText="Employee Type"
                                                            meta:resourcekey="TYPE" UniqueName="TYPE" AutoPostBackOnFilter="true"
                                                            ItemStyle-HorizontalAlign="Left">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DOJ" HeaderText="Date of Join"
                                                            meta:resourcekey="DOJ" UniqueName="DOJ" AutoPostBackOnFilter="true"
                                                            ItemStyle-HorizontalAlign="Left">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="STATUS" HeaderText="Employee Status"
                                                            meta:resourcekey="STATUS" UniqueName="STATUS" AutoPostBackOnFilter="true"
                                                            ItemStyle-HorizontalAlign="Left" AllowFiltering="false">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                    </Columns>
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
                <asp:Button runat="server" ID="btnConfirm" Text="Confirm" OnClick="btnConfirm_Click" />
            </td>
        </tr>
    </table>
</asp:Content>