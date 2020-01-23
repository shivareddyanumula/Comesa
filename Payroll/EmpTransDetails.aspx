<%@ Page Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="EmpTransDetails.aspx.cs" Inherits="EmpTransDetails" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td>
                <asp:UpdatePanel ID="u1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="Label1" runat="server" Visible="false">
                        </asp:Label>
                        <table align="center">
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:Label ID="lbl_Header" runat="server" Text="Employee Transaction Details"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business Unit">
                                    </asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_AttBusinessUnit" runat="server" AutoPostBack="true"
                                        OnSelectedIndexChanged="rcmb_AttBusinessUnit_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rcmb_AttBusinessUnit"
                                        ErrorMessage="Business Unit is Mandatory" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Period" runat="server" Text="Period">
                                    </asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_AttPeriod" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rcmb_AttPeriod_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="rcmb_AttPeriod"
                                        ErrorMessage="Period Unit is Mandatory" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr runat="server" id="tblr_AttPeriodElement" visible="false">
                                <td>
                                    <asp:Label ID="lbl_PeriodElement" runat="server" Text="Period Element">
                                    </asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_AttPeriodElement" runat="server" AutoPostBack="true"
                                        OnSelectedIndexChanged="rcmb_AttPeriodElement_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="rcmb_AttPeriodElement"
                                        ErrorMessage="Period Element  is Mandatory" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table align="center" width="100%">
                            <tr>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Panel ID="Panel1" runat="server" Height="1000px" Width="1000px">
                                        <telerik:RadGrid ID="rg_Attendence" runat="server" AutoGenerateColumns="false" GridLines="None"
                                            Width="1000px" Height="1000px" OnItemCreated="rg_Attendence_ItemCreated">
                                            <ClientSettings>
                                                <Scrolling UseStaticHeaders="true" AllowScroll="true" SaveScrollPosition="false" />
                                            </ClientSettings>
                                            <MasterTableView Width="100%" EnableColumnsViewState="true">
                                                <CommandItemSettings />
                                                <Columns>
                                                    <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Select" HeaderStyle-Width="70px">
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="chk_selectall" runat="server" AutoPostBack="true" OnCheckedChanged="chk_selectall_CheckedChanged"
                                                                Text="Check All" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chckbtn_Select" runat="server" AutoPostBack="true" OnCheckedChanged="chckbtn_Select_CheckedChanged" />
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn Visible="false" HeaderText="Employee Id">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Empid" runat="server" Text='<%# Eval("EMP_ID") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn Visible="true" HeaderText="Employee Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_EmpName" runat="server" Text='<%# Eval("EMP_NAME") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn Visible="true" HeaderText="Bank Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_BankName" runat="server" Text='<%# Eval("BANK_NAME") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Bank id" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Bankid" runat="server" Text='<%#Eval("BANK_DETAILS_ID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Account No" Visible="true">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Bankid1" runat="server" Text='<%#Eval("EMPBNKDTLS_ACCOUNTNO") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Employee Salary">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEmployeeSalary" runat="server" Text='<%# Eval("SALARY") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn Visible="true" HeaderText="Amount">
                                                        <ItemTemplate>
                                                            <telerik:RadNumericTextBox ID="RadNumericTextBox1" runat="server" MinValue="0" Enabled="false"
                                                                Text='<%# Eval("SALARY") %>'>
                                                            </telerik:RadNumericTextBox>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridBoundColumn DataField="HR_MASTER_CODE" UniqueName="HR_MASTER_CODE" HeaderText="Employee Grade">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="STATUS" UniqueName="STATUS" Visible="false">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </telerik:GridBoundColumn>
                                                </Columns>
                                                <PagerStyle AlwaysVisible="True" />
                                            </MasterTableView>
                                            <PagerStyle AlwaysVisible="true" />
                                        </telerik:RadGrid>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btn_Save" runat="server" Text="Save" Visible="true" OnClick="btn_Save_Click"
                                        ValidationGroup="Controls" />
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" Visible="true" OnClick="btn_Cancel_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="Controls" ShowMessageBox="true"
                                        runat="server" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>