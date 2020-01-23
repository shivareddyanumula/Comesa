<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_ExpenseApproval.aspx.cs" Inherits="Approval_frm_ExpenseApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadScriptBlock ID="Rsb_Scripts" runat="server">

        <script language="javascript" type="text/javascript">
            function ShowPopForm(url) {
                var win = window.radopen('../Payroll/frm_ExpenseTrans.aspx?POP=1&EXPID=' + url, "rwin_Pop");
                // win.maximize();
                win.center();
                win.set_modal(true);
            }
        </script>

    </telerik:RadScriptBlock>
    <table align="center">
        <tr>
            <td>
                <div style="height: 490px; width: 1014px; overflow: auto;">
                    <table align="center">
                        <tr>
                            <td align="center">
                                <asp:Label ID="lbl_ExpenseApproval" runat="server" meta:resourcekey="lbl_ExpenseApproval"
                                    Style="font-weight: 700"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                                <table align="center">
                                    <tr style="display: none">
                                        <td>
                                            <asp:Label ID="lbl_ReportingMgr" runat="server" meta:resourcekey="lbl_ReportingMgr"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="rtxt_ReportingMgr" Skin="WebBlue" runat="server" Width="125px">
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
                                                <DateInput LabelCssClass="" Width="" Skin="WebBlue">
                                                </DateInput>
                                                <Calendar Skin="WebBlue" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                                                    ViewSelectorText="x">
                                                </Calendar>
                                                <DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
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
                                            &nbsp;<asp:Button ID="btn_Cancel" runat="server" OnClick="btn_Cancel_Click" Text="Cancel" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <telerik:RadGrid ID="RG_ExpenseApproval" runat="server" Skin="WebBlue" GridLines="None"
                                    AutoGenerateColumns="False" OnNeedDataSource="RG_ExpenseApproval_NeedDataSource"
                                    AllowFilteringByColumn="true">
                                    <HeaderContextMenu Skin="WebBlue">
                                    </HeaderContextMenu>
                                    <MasterTableView>
                                        <Columns>
                                            <telerik:GridTemplateColumn HeaderText="Choose">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chk_Choose" runat="server" />
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Expense&nbsp;ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblexpID" runat="server" Text='<%# Eval("EXPENSE_ID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Employee&nbsp;Name" meta:resourcekey="GridTemplateColumnResource4">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblempName" runat="server" Text='<%# Eval("EMPNAME") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="HR_MASTER_CODE" UniqueName="HR_MASTER_CODE" HeaderText="Employee Grade">
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn HeaderText="Expense&nbsp;Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblempExpense" runat="server" Text='<%# Eval("EXPENSE_NAME") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText=" Expense Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblexpenseamt" runat="server" Text='<%# Eval("EXPENSEDTL_AMOUNT") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Applied&nbsp;Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblempApplied" runat="server" Text='<%# Eval("EXPENSE_APPDATE","{0:dd/MM/yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblempStatus" runat="server" Text='<%# Eval("EXPENSE_STATUS") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Expense Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblExpenseType" runat="server" Text='<%# Eval("Expense Type") %>'></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblExpdtl_Id" runat="server" Text='<%# Eval("EXPENSEDTL_ID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                    </MasterTableView>
                                </telerik:RadGrid>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
