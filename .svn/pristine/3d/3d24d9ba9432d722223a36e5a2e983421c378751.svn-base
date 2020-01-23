<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_emppayelements.aspx.cs" Inherits="HR_frm_emppayelements" Culture="auto"
    meta:resourcekey="Page" UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center" style="width: 85%">
        <tr>
            <td align="center">
                <telerik:RadMultiPage ID="RMP_SalaryStruct" runat="server" Font-Bold="True" Width="1014px"
                    ScrollBars="Auto" SelectedIndex="0">
                    <telerik:RadPageView ID="RP_SalaryStruct_AddUpdate" runat="server" Selected="True">
                        <table align="center">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lbl_SalaryDetails" runat="server" Font-Bold="True" meta:resourcekey="lbl_SalaryDetails"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table align="center">
                                        <%--bu --%>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lbl_BusUnit" runat="server" meta:resourcekey="lbl_BusUnit"></asp:Label>
                                            </td>
                                            <td>
                                                <b>: </b>
                                            </td>
                                            <td align="left">
                                                <telerik:RadComboBox ID="rcb_BussinessUnit" runat="server" AutoPostBack="True" MarkFirstMatch="true" 
                                                    MaxHeight="200px" OnSelectedIndexChanged="rcb_BussinessUnit_SelectedIndexChanged" Filter="Contains">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td align="left">
                                                <asp:RequiredFieldValidator ID="rfv_BusinessUnit" runat="server" ControlToValidate="rcb_BussinessUnit"
                                                    InitialValue="Select" meta:resourcekey="rfv_BusinessUnit" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <%--pay --%>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lbl_Payitem" runat="server" meta:resourcekey="lbl_Payitem"></asp:Label>
                                            </td>
                                            <td>
                                                <b>: </b>
                                            </td>
                                            <td align="left">
                                                <telerik:RadComboBox ID="rcmb_Payitem" runat="server" AutoPostBack="True" MarkFirstMatch="true" 
                                                    MaxHeight="200px" OnSelectedIndexChanged="rcmb_Payitem_SelectedIndexChanged" Filter="Contains">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td align="left">
                                                <asp:RequiredFieldValidator ID="rfv_Payitem0" runat="server" ControlToValidate="rcmb_Payitem"
                                                    InitialValue="Select" meta:resourcekey="rfv_Payitem" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <%--period --%>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lbl_Peroid" runat="server" meta:resourcekey="lbl_Peroid"></asp:Label>
                                            </td>
                                            <td>
                                                <b>: </b>
                                            </td>
                                            <td align="right">
                                                <telerik:RadComboBox ID="rcmb_Period" runat="server" AutoPostBack="True" MarkFirstMatch="true" 
                                                    MaxHeight="200px" OnSelectedIndexChanged="rcmb_Period_SelectedIndexChanged" Filter="Contains">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td align="right">
                                                &nbsp;
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
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                            </td>
                                            <td align="left">
                                            </td>
                                            <td align="left">
                                                <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click"
                                                    ValidationGroup="Controls" Width="63px" />
                                                <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click"
                                                    Width="63px" />
                                            </td>
                                            <td align="left">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="4">
                                                <asp:ValidationSummary ID="vs_Salary" runat="server" meta:resourcekey="vs_Salary"
                                                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="Controls" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td align="center" rowspan="2">
                                                <table align="center" style="width: 50%">
                                                    <tr>
                                                        <td align="left" style="width: 98%">
                                                            <telerik:RadGrid ID="Rg_Employeesal" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                                 GridLines="None" Width="596px">
                                                                <HeaderContextMenu >
                                                                </HeaderContextMenu>
                                                                <MasterTableView>
                                                                    <Columns>
                                                                        <telerik:GridTemplateColumn HeaderText="Select" meta:resourcekey="GridTemplateColumn"
                                                                            UniqueName="TemplateColumn">
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="chk_Choose" runat="server" meta:resourcekey="chk_Choose" />
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Employee Id" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_empid" runat="server" Text='<%# Eval("EMP_ID") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridBoundColumn DataField="EMP_EMPCODE" HeaderText="Employee Code" UniqueName="EMP_EMPCODE ">
                                                                        </telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="Empname" HeaderText="Employee Name" UniqueName="Empname">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="HR_MASTER_CODE" HeaderText="Designation" UniqueName="HR_MASTER_CODE ">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </telerik:GridBoundColumn>
                                                                        <%--<telerik:GridTemplateColumn HeaderText="Mode" meta:resourcekey="mode" UniqueName="Mode"
                                                                Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCALMODE_1" runat="server" Text='<%# Eval("PAYITEM_CALMODE_1") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                            --%>
                                                                        <telerik:GridTemplateColumn HeaderText="Value" meta:resourcekey="value" UniqueName="Value">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtNumber" runat="server" meta:resourcekey="txtNumber" Style="text-align: right"
                                                                                    Text='<%# Eval("VALUE") %>' ValidationGroup="Controls" Width="110px"></asp:TextBox>
                                                                                <asp:RegularExpressionValidator ID="rfv_Number" runat="server" ControlToValidate="txtNumber"
                                                                                    meta:resourcekey="rfv_Number" Text="*" ValidationExpression="^[-+]?[0-9]*\.?[0-9]+$"
                                                                                    ValidationGroup="Controls"></asp:RegularExpressionValidator>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                    </Columns>
                                                                    <EditFormSettings>
                                                                        <EditColumn CancelImageUrl="Cancel.gif" EditImageUrl="Edit.gif" InsertImageUrl="Update.gif"
                                                                            UpdateImageUrl="Update.gif">
                                                                        </EditColumn>
                                                                    </EditFormSettings>
                                                                </MasterTableView>
                                                                <FilterMenu >
                                                                </FilterMenu>
                                                            </telerik:RadGrid>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
