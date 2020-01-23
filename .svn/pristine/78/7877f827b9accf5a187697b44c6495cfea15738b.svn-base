<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_emppastinfo.aspx.cs" Inherits="HR_frm_emppastinfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" Runat="Server">
    <br />
    <table align="center">
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="lbl_Header" runat="server" Text="Period Wise Employee Past Gross & TDS Info"></asp:Label>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="lbl_BusUnit" runat="server" Text="Business Unit"></asp:Label>
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
                    InitialValue="Select" ErrorMessage="Please Choose BusinessUnit" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="lbl_Period" runat="server" Text="Period"></asp:Label>
            </td>
            <td>
                <b>: </b>
            </td>
            <td align="left">
                <telerik:RadComboBox ID="rcmb_Period" runat="server" AutoPostBack="True" MarkFirstMatch="true" 
                    MaxHeight="200px" onselectedindexchanged="rcmb_Period_SelectedIndexChanged" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td align="left">
                <asp:RequiredFieldValidator ID="rfv_rcmb_Period" runat="server" ControlToValidate="rcmb_Period"
                    InitialValue="Select" ErrorMessage="Please Select Period" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
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
        </tr>
        <tr>
            <td align="left" colspan="4" style="text-align: center">
                <asp:Button ID="btn_Save" runat="server" Text="Submit" ValidationGroup="Controls"
                    Width="63px" onclick="btn_Save_Click" />
                &nbsp;<asp:Button ID="btn_Cancel" runat="server" Text="Cancel" Width="63px" OnClick="btn_Cancel_Click" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4">
                <asp:ValidationSummary ID="vs_Salary" runat="server" meta:resourcekey="vs_Salary"
                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="Controls" />
            </td>
        </tr>
    </table>
    <br />
    <table align="center">
        <tr>
            <td>
                <telerik:RadGrid ID="RG_PayElements" runat="server"  AutoGenerateColumns="false" Width="800px"  ClientSettings-Scrolling-AllowScroll="true" ClientSettings-Scrolling-UseStaticHeaders="true">
                    <HeaderContextMenu >
                    </HeaderContextMenu>
                    <MasterTableView>
                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="Check All">
                             <HeaderTemplate>
                               <asp:CheckBox ID="chk_selectall" runat="server" AutoPostBack="true" OnCheckedChanged="chk_selectall_checkedchanged" Text="Check All" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chk_Select"></asp:CheckBox>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_EmpID" runat="server" Text='<%# Eval("EMP_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Employee&nbsp;Code">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_EmpCode" runat="server" Text='<%# Eval("EMP_EMPCODE") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Employee&nbsp;Name">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_EmpName" runat="server" Text='<%# Eval("EMP_NAME") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Designation">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Desgn" runat="server" Text='<%# Eval("POSITIONS_CODE") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Gross Value">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Value" runat="server" Text='<%# Eval("GROSSVALUE") %>' Width="80px"
                                        MaxLength="10" Style="text-align: right;">
                                    </asp:TextBox>
                                    <asp:RegularExpressionValidator ID="rfv_Number" runat="server" ControlToValidate="txt_Value"
                                        ErrorMessage="Only Numerical Values" Text="*" ValidationExpression="^[-+]?[0-9]*\.?[0-9]+$"
                                        ValidationGroup="Controls"></asp:RegularExpressionValidator>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="HR_MASTER_CODE" UniqueName="HR_MASTER_CODE" HeaderText="Employee Grade">
                            <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="TDS Value">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_tds_Value" runat="server" Text='<%# Eval("TDSVALUE") %>' Width="80px"
                                        MaxLength="10" Style="text-align: right;">
                                    </asp:TextBox>
                                    <asp:RegularExpressionValidator ID="rfv_TDSNumber" runat="server" ControlToValidate="txt_tds_Value"
                                        ErrorMessage="Only Numerical Values" Text="*" ValidationExpression="^[-+]?[0-9]*\.?[0-9]+$"
                                        ValidationGroup="Controls"></asp:RegularExpressionValidator>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                    <FilterMenu >
                    </FilterMenu>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
</asp:Content>

