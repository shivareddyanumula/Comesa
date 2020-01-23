<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frmHoldPayroll.aspx.cs" Inherits="Payroll_frmHoldPayroll" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="lblHeader" runat="server" Text="Hold Payroll Process" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblBusinessUnit" runat="server" Text="Business Unit"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmbBusinessUnit" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rcmbBusinessUnit_SelectedIndexChanged" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvBusinessUnit" runat="server" InitialValue="Select"
                    Text="*" ControlToValidate="rcmbBusinessUnit" ErrorMessage="Please Select Business Unit"
                    ValidationGroup="Controls"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPeriod" runat="server" Text="Period"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmbPeriod" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rcmbPeriod_SelectedIndexChanged" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvPeriod" runat="server" InitialValue="Select" Text="*"
                    ControlToValidate="rcmbPeriod" ErrorMessage="Please Select Period" ValidationGroup="Controls"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPeriodElement" runat="server" Text="Period Element"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmbPeriodElement" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rcmbPeriodElement_SelectedIndexChanged" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvPeriodElement" runat="server" InitialValue="Select"
                    Text="*" ControlToValidate="rcmbPeriodElement" ErrorMessage="Please Select Period Element"
                    ValidationGroup="Controls"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <%--<tr>
            <td colspan="4">
            </td>
        </tr>
        <tr>
            <td colspan="4">
            </td>
        </tr>
        <tr id="trChkAll" runat="server" visible="false">
            <td>
                <asp:CheckBox ID="chkSelectAll" runat="server" Text="Select&nbsp;All" AutoPostBack="true"
                    OnCheckedChanged="chkSelectAll_CheckedChanged" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <telerik:RadGrid ID="rgMain" runat="server" GridLines="None" AutoGenerateColumns="false">
                    <ClientSettings>
                        <Scrolling AllowScroll="true" UseStaticHeaders="true" />
                    </ClientSettings>
                    <MasterTableView>
                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="Select">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkEmployee" runat="server" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="ATTENDANCE_EMP_ID" HeaderText="Employee Id"
                                Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmpId" runat="server" Text='<%# Eval("ATTENDANCE_EMP_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="ATTENDANCE_EMP_NAME" HeaderText="Employee Name"
                                Visible="true">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmpName" runat="server" Text='<%# Eval("ATTENDANCE_EMP_NAME") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
        <tr id="trBtn" runat="server" visible="false">
            <td align="center" colspan="4">
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnSave_Click" Visible="false" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            </td>
        </tr>--%>
        <%--<tr id="trStruct" runat="server" visible="false">
            <td colspan="4" align="center">
                <asp:CheckBoxList ID="chkList" runat="server" RepeatDirection="Horizontal" RepeatColumns="3">
                </asp:CheckBoxList>
            </td>
        </tr>--%>
    </table>
    <br />
    <br />
    <br />
    <table align="center">
        <tr id="trNote" runat="server" visible="false">
            <td>
                <asp:Label ID="lblNote" runat="server"></asp:Label>
            </td>
        </tr>
        <tr id="trChkAll" runat="server" visible="false">
            <td>
                <asp:CheckBox ID="chkSelectAll" runat="server" Text="Select&nbsp;All" AutoPostBack="true"
                    OnCheckedChanged="chkSelectAll_CheckedChanged" />
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadGrid ID="rgMain" runat="server" GridLines="None" AutoGenerateColumns="false"
                    Width="500px" OnNeedDataSource="rgMain_NeedDataSource">
                    <ClientSettings>
                        <Scrolling AllowScroll="true" UseStaticHeaders="true" />
                    </ClientSettings>
                    <MasterTableView>
                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="Select">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkEmployee" runat="server" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="ATTENDANCE_EMP_ID" HeaderText="Employee Id"
                                Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmpId" runat="server" Text='<%# Eval("ATTENDANCE_EMP_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="ATTENDANCE_EMP_NAME" HeaderText="Employee Name"
                                Visible="true">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmpName" runat="server" Text='<%# Eval("ATTENDANCE_EMP_NAME") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
        <tr>
            <td></td>
        </tr>
        <tr>
            <td></td>
        </tr>
        <tr id="trBtn" runat="server" visible="false">
            <td align="center">
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" UseSubmitBehavior="false" OnClientClick="fnJSOnFormSubmit(this,'Controls')" />
                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnSave_Click" UseSubmitBehavior="false" OnClientClick="fnJSOnFormSubmit(this,'Controls')" Visible="false" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="vs_Holdpayroll" runat="server"
        meta:resourcekey="vs_DisactRec" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="Controls" />
</asp:Content>