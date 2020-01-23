<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="EmployeeCopy.aspx.cs" Inherits="HR_EmployeeCopy" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td colspan="4">
                <asp:Label ID="lbl_EmployeeCopyHeader" runat="server" Text="Copy Employee From BusinessUnit To BusinessUnit"
                    Font-Bold="true"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <table align="center">
        <tr>
            <td>
                <asp:Label ID="lbl_SourceBU" runat="server" Text="Source BusinessUnit"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_SourceBU" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rcmb_SourceBU_SelectedIndexChanged" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <telerik:RadGrid ID="rg_Employee" runat="server" AutoGenerateColumns="false" GridLines="None">
                    <ClientSettings>
                        <Scrolling AllowScroll="true" UseStaticHeaders="true" />
                    </ClientSettings>
                    <MasterTableView>
                        <Columns>
                            <telerik:GridTemplateColumn Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_EmpCode" runat="server" Text='<%# Eval("EMP_EMPCODE") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_EmployeeID" runat="server" Text='<%# Eval("EMP_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Select">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chk_Select" runat="server" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Employee Name">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Employee" runat="server" Text='<%# Eval("Empname") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_BuId" runat="server" Text='<%# Eval("EMP_BUSINESSUNIT_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_DepartmentId" runat="server" Text='<%# Eval("EMP_DEPARTMENT_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_SalStruct" runat="server" Text='<%# Eval("EMP_SALALRYSTRUCT_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_GrossSal" runat="server" Text='<%# Eval("EMP_GROSSSAL") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_EmpDoj" runat="server" Text='<%# Eval("EMP_DOJ") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_DestinationBU" runat="server" Text="Destination BusinessUnit"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_DestinationBU" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rcmb_DestinationBU_SelectedIndexChanged" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_DestinationDept" runat="server" Text="Destination Department"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_DestinationDept" runat="server" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_DestinationDept" runat="server" ControlToValidate="rcmb_DestinationDept"
                    ErrorMessage="Select Destination Department" ValidationGroup="Controls" Text="*"
                    InitialValue="Select"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_DestinationPosition" runat="server" Text="Destination Position"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_DestinationPosition" runat="server" AutoPostBack="true"
                    OnSelectedIndexChanged="rcmb_DestinationPosition_SelectedIndexChanged" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_DestinationPosition" runat="server" ControlToValidate="rcmb_DestinationPosition"
                    ErrorMessage="Please Select Destination Position" ValidationGroup="Controls"
                    Text="*" InitialValue="Select"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <%--<tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Destination Position"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="RadComboBox1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rcmb_DestinationPosition_SelectedIndexChanged">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rcmb_DestinationPosition"
                    ErrorMessage="Please Select Destination Position" ValidationGroup="Controls"
                    Text="*" InitialValue="Select"></asp:RequiredFieldValidator>
            </td>
        </tr>--%>
        <tr>
            <td>
                <asp:Label ID="lbl_Job" runat="server" Text="Destination Job"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <asp:Label ID="lbl_DestinationJob" runat="server"></asp:Label>
                <%--<telerik:RadComboBox ID="rcmb_DestinationJob" runat="server">
                </telerik:RadComboBox>--%>
            </td>
            <td>
                <%--<asp:RequiredFieldValidator ID="rfv_DestinationJob" runat="server" ControlToValidate="rcmb_DestinationJob"
                    ErrorMessage="Please Select Destination Job" ValidationGroup="Controls" Text="*"
                    InitialValue="Select"></asp:RequiredFieldValidator>--%>
            </td>
        </tr>
        <tr id="tr_AnnualGross" runat="server">
            <td>
                <asp:Label ID="lbl_AnnualGross" runat="server" Text="Annual Gross"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <asp:TextBox ID="txt_AnnualGross" runat="server" AutoPostBack="true" OnTextChanged="txt_AnnualGross_TextChanged"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_Annual" runat="server" ControlToValidate="txt_AnnualGross"
                    ErrorMessage="Please Enter Amount For Annual Gross" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr id="tr_AnnualBasic" runat="server">
            <td>
                <asp:Label ID="lbl_AnnualBasic" runat="server" Text="Annual Basic"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <asp:TextBox ID="txt_AnnualBasic" runat="server" Enabled="false"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr id="tr_MonthlyGross" runat="server">
            <td>
                <asp:Label ID="lbl_Gross" runat="server" Text="Monthly Gross"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <asp:TextBox ID="txt_MonthlyGross" runat="server" AutoPostBack="true" OnTextChanged="txt_MonthlyGross_TextChanged"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_Monthly" runat="server" ControlToValidate="txt_MonthlyGross"
                    ErrorMessage="Please Enter Amount For Monthly Gross" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr id="tr_MonthlyBasic" runat="server">
            <td>
                <asp:Label ID="lbl_MonthlyBasic" runat="server" Text="Monthly Basic"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <asp:TextBox ID="txt_MonthlyBasic" runat="server" Enabled="false"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_DestinationCurr" runat="server" Text="Currency"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_DestinationCurr" runat="server" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_DestinationCurr" runat="server" ControlToValidate="rcmb_DestinationCurr"
                    ErrorMessage="Select Destination Currency" ValidationGroup="Controls" Text="*"
                    InitialValue="Select"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <asp:Button ID="btn_Copy" runat="server" Text="Copy" OnClick="btn_Copy_Click" ValidationGroup="Controls" />
                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="vsEmployeeCopy" runat="server" ValidationGroup="Controls"
        ShowMessageBox="true" ShowSummary="false" />
</asp:Content>
