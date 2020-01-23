<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_ResignationApproval.aspx.cs" Inherits="Approval_frm_ResignationApproval"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td align="center" colspan="3">
                <asp:Label ID="lbl_ResgApproval" runat="server" meta:resourcekey="lbl_ResgApproval"
                    Style="font-weight: 700"></asp:Label>
            </td>
        </tr>
        <tr style="display: none">
            <td>
                <asp:Label ID="lbl_ReportingMgr" runat="server" meta:resourcekey="lbl_ReportingMgr"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadTextBox ID="rtxt_ReportingMgr" Skin="WebBlue" runat="server" Width="125px"
                    meta:resourcekey="rtxt_ReportingMgr">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_ApprovalDate" runat="server" meta:resourcekey="lbl_ApprovalDate"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadDatePicker ID="rdp_ApprovalDate" runat="server" Culture="English (United States)">
                </telerik:RadDatePicker>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <asp:Button ID="btn_Approve" runat="server" meta:resourcekey="btn_Approve" OnClick="btn_Approve_Click" />
                &nbsp;<asp:Button ID="btn_Reject" runat="server" meta:resourcekey="btn_Reject" OnClick="btn_Reject_Click" />
                &nbsp;<asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
            </td>
        </tr>
    </table>
    <table align="center">
        <tr>
            <td>
                <asp:CheckBox ID="chkSelectAll" runat="server" Text="Select All" AutoPostBack="true"
                    OnCheckedChanged="chkSelectAll_CheckedChanged" />
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadGrid ID="RG_ResgApproval" runat="server" Skin="WebBlue" GridLines="None"
                    AutoGenerateColumns="False" meta:resourcekey="RG_ResgApprovalResource1" OnNeedDataSource="RG_ResgApproval_NeedDataSource">
                    <HeaderContextMenu Skin="WebBlue">
                    </HeaderContextMenu>
                    <MasterTableView>
                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="Choose">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chk_Choose" runat="server" meta:resourcekey="CHOOSE" />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="EMPREGID" Visible="false" meta:resourcekey="EMPREGID">
                                <ItemTemplate>
                                    <asp:Label ID="lblresgID" runat="server" Text='<%# Eval("EMPREG_ID") %>' meta:resourcekey="lblresgID"></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Employee&nbsp;Code" meta:resourcekey="EMP_EMPCODE">
                                <ItemTemplate>
                                    <asp:Label ID="lblempcode" runat="server" Text='<%# Eval("EMP_EMPCODE") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Employee&nbsp;Name" meta:resourcekey="EMPNAME">
                                <ItemTemplate>
                                    <asp:Label ID="lblempName" runat="server" Text='<%# Eval("EMPNAME") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Date&nbsp;Of&nbsp;Join" meta:resourcekey="EMP_DOJ">
                                <ItemTemplate>
                                    <asp:Label ID="lblempExpense" runat="server" Text='<%# Eval("EMP_DOJ") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Grade">
                                <ItemTemplate>
                                    <asp:Label ID="lblempGrade" runat="server" Text='<%# Eval("Scale") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridTemplateColumn>
                            <%-- <telerik:GridBoundColumn DataField="HR_MASTER_CODE" UniqueName="Grad" HeaderText="Employee Grade">
                            <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>--%>
                            <%--<telerik:GridTemplateColumn HeaderText="Date&nbsp;Of&nbsp;Confirmation" meta:resourcekey="EMP_DOC">
                                <ItemTemplate>
                                    <asp:Label ID="lblempApplied" runat="server" Text='<%# Eval("EMP_DOC") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridTemplateColumn>--%>
                            <telerik:GridTemplateColumn HeaderText="Date&nbsp;Of&nbsp;Resignation" meta:resourcekey="EMPREG_REGDATE">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmpRegDate" runat="server" Text='<%# Eval("EMPREG_REGDATE") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Status" meta:resourcekey="EMPREG_STATUS">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmpRegStatus" runat="server" Text='<%# Eval("EMPREG_STATUS") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Reason for Resignation">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmpRegRemarks" runat="server" Text='<%# Eval("RESIGNATION_RESON") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                    <FilterMenu Skin="WebBlue">
                    </FilterMenu>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
</asp:Content>