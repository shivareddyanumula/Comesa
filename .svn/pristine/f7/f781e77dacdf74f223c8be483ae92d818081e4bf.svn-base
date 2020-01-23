<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frmHoldPayrollProcess1.aspx.cs" Inherits="Payroll_frmHoldPayrollProcess1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center" style="width: 85%">
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
        <tr>
            <td colspan="4">
                <telerik:RadGrid ID="rgMain" runat="server" AutoGenerateColumns="false" Width="500px" ClientSettings-Scrolling-UseStaticHeaders="false" Height="200px">
                    <ClientSettings>
                        <Scrolling AllowScroll="true" ScrollHeight="300px" UseStaticHeaders="true" />
                        <ClientEvents OnGridCreated="GridCreated" />
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

        <%--<tr>
            <td>
                <%--<asp:Panel ID="pnl" runat="server">
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
                        Width="500px" Height="200px">
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
                    <asp:Button ID="btnSave" runat="server" Text="Save" UseSubmitBehavior="false" OnClientClick="fnJSOnFormSubmit(this,'Controls')" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" UseSubmitBehavior="false" OnClientClick="fnJSOnFormSubmit(this,'Controls')" Visible="false" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                </td>
            </tr>
        </table>
    </asp:Panel>
            </td>
        </tr>--%>
    </table>
    <asp:ValidationSummary ID="vs_Holdpayroll" runat="server"
        meta:resourcekey="vs_DisactRec" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="Controls" />
</asp:Content>