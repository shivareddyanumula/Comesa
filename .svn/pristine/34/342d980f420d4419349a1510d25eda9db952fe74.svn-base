<%@ Page Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_Gratuityapproval.aspx.cs" Inherits="Payroll_frm_Gratuityapproval"
    Title="Untitled Page" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td align="center">
            </td>
            <td align="center" colspan="3">
                <asp:Label ID="lbl_Gratuityheader" runat="server" Style="font-weight: 700" Text="Gratuity Approval"></asp:Label>
            </td>
            <td align="center">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="3">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td align="right">
            </td>
            <td align="right">
                <asp:Label ID="lbl_Businessunit" runat="server" Text="Business Unit"></asp:Label>
            </td>
            <td align="center">
                <b>:</b>
            </td>
            <td align="left">
                <telerik:RadComboBox ID="rcmb_Businessunit" runat="server" OnSelectedIndexChanged="rcmb_Businessunit_SelectedIndexChanged"
                    AutoPostBack="true" MarkFirstMatch="true" MaxHeight="120px" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td align="left">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td align="right">
            </td>
            <td align="right">
                <asp:Button ID="btn_Approve" Text="Approve" runat="server" OnClick="btn_Approve_Click" />
            </td>
            <td align="center">
            </td>
            <td align="left">
                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
            </td>
            <td align="left">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
    <table align="center">
        <tr>
            <td align="left">
            </td>
            <td align="center" colspan="3">
                <telerik:RadGrid ID="RG_Approve" runat="server" AutoGenerateColumns="false" >
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn HeaderText="Employee Id" DataField="EMP_ID" Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Employee Name" DataField="EMP_NAME">
                            <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Date Of Joining" DataField="EMP_DOJ">
                            <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Department" DataField="DEPARTMENT">
                            <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Designation" DataField="DESIGNATION">
                            <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="HR_MASTER_CODE" UniqueName="HR_MASTER_CODE" HeaderText="Employee Grade">
                            <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="Amount">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Currency" runat="server" Text='<%#Eval("CURR_SYMBOL") %>'></asp:Label>
                                    <asp:Label ID="lbl_Amount" runat="server" Text='<%#Eval("AMOUNT") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn HeaderText="Nominee If Any" DataField="NOMINEE">
                            <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Years Of Service" DataField="EXPERIENCE">
                            <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Status" DataField="TYPE">
                            <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
        <tr>
            <td align="left">
            </td>
            <td align="left">
            </td>
            <td align="center">
            </td>
            <td align="right">
            </td>
        </tr>
    </table>
</asp:Content>
