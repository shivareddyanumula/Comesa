<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frmFoodAllowance.aspx.cs" Inherits="Masters_frmFoodAllowance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td>
                <asp:Label ID="lblHeader" runat="server" Text="Food Allowance"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <table align="center">
        <tr>
            <td>
                <asp:Label ID="lblBusinessUnit" runat="server" Text="Business Unit"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmbBusinessUnit" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rcmbBusinessUnit_SelectedIndexChanged"
                    MarkFirstMatch="true" MaxHeight="120px" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvBusinessUnit" runat="server" InitialValue="Select"
                    Text="*" ControlToValidate="rcmbBusinessUnit" ErrorMessage="Select BusinessUnit"
                    ValidationGroup="Controls"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:CheckBox ID="chkAll" runat="server" Text="Select All" OnCheckedChanged="chkAll_CheckedChanged"
                    AutoPostBack="true" Visible="false" />
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <telerik:RadGrid ID="rgFoodAllowance" runat="server" GridLines="None" AutoGenerateColumns="false">
                    <ClientSettings>
                        <Scrolling AllowScroll="true" UseStaticHeaders="true" />
                    </ClientSettings>
                    <MasterTableView>
                        <Columns>
                            <telerik:GridTemplateColumn Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmpId" runat="server" Text='<%# Eval("EMP_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkCheck" runat="server" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="Empname" HeaderText="Employee Name" UniqueName="EmployeeName">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="Value">
                                <ItemTemplate>
                                    <telerik:RadNumericTextBox ID="rntb" runat="server" MinValue="0.00" Text='<%# Eval("FOODALWNC_AMOUNT") %>'>
                                    </telerik:RadNumericTextBox>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
</asp:Content>