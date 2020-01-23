<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="Emp_Med_Scheme.aspx.cs" Inherits="HR_Emp_Med_Scheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <br />
    <table align="center">
        <tr>
            <td>
                <telerik:RadMultiPage ID="RMP_MED_SCHEME" runat="server" SelectedIndex="0">
                    <telerik:RadPageView ID="RPV_MED_SCHEME" runat="server">
                        <br />
                        <table align="center">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lbl_Header" runat="server" Text="Employee Medical Scheme" Style="font-weight: 700"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadGrid  ID="RG_MED_SCHEME" runat="server" GridLines="None"
                                        AutoGenerateColumns="false" OnNeedDataSource="RG_MED_SCHEME_NeedDataSource" AllowPaging="True"
                                        PageSize="10" AllowFilteringByColumn="true">
                                        <headercontextmenu >
                                        </headercontextmenu>
                                        <pagerstyle alwaysvisible="True" />
                                        <mastertableview commanditemdisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="SMHR_MED_ID" Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="BUSINESSUNIT_CODE" HeaderText="Business Unit"
                                                    UniqueName="column">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMP_NAME" HeaderText="Employee" UniqueName="column1">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="PERIOD_NAME" HeaderText="Period" UniqueName="column2">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SMHR_MED_IP_AV_AMT" HeaderText="IP Amount" UniqueName="column3">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SMHR_MED_OP_AV_AMT" HeaderText="OP Amount" UniqueName="column4">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="HR_MASTER_CODE" UniqueName="HR_MASTER_CODE" HeaderText="Employee Grade">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("SMHR_MED_ID") %>'
                                                            OnCommand="lnk_Edit_Command" Text="Edit"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_add" runat="server" OnCommand="lnk_Add_Command" Text="Add"></asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </mastertableview>
                                        <filtermenu >
                                        </filtermenu>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RPV_MED_SCHEME_DETAILS" runat="server">
                        <table align="center">
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:Label ID="lbl_Header_Details" runat="server" Text="Employee Medical Scheme Details"
                                        Style="font-weight: 700"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Bus_ID" runat="server" Text="Business Unit"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox  ID="ddl_BusinessUnit" runat="server" MarkFirstMatch="true" Filter="Contains"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddl_BusinessUnit_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_Business_Unit" runat="server" ControlToValidate="ddl_BusinessUnit"
                                        ValidationGroup="Controls" InitialValue="Select" ErrorMessage="Please Select Business Unit"
                                        Text="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Emp_ID" runat="server" Text="Employee"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox  ID="ddl_Employee" runat="server" MaxHeight="120px" MarkFirstMatch="true" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_Employee" runat="server" ControlToValidate="ddl_Employee"
                                        ValidationGroup="Controls" InitialValue="Select" ErrorMessage="Please Select Employee"
                                        Text="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Period" runat="server" Text="Financial Period"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox  ID="ddl_Period" runat="server" MarkFirstMatch="true" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_Period" runat="server" ControlToValidate="ddl_Period"
                                        ValidationGroup="Controls" InitialValue="Select" ErrorMessage="Please Select Period"
                                        Text="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_IP_Av_Amt" runat="server" Text="IP Available Amount"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox  ID="txt_IP_Av_Amt" runat="server"  MinValue="0"  MaxLength="12">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_IP_Av_Amt" runat="server" ControlToValidate="txt_IP_Av_Amt"
                                        ValidationGroup="Controls" ErrorMessage="Please Enter IP Available Amount" Text="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_OP_Av_Amt" runat="server" Text="OP Available Amount"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox  ID="txt_OP_Av_Amt" runat="server" MinValue="0" MaxLength="12">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_OP_Av_Amt" runat="server" ErrorMessage="Please Enter OP Available Amount"
                                        Text="*" ControlToValidate="txt_OP_Av_Amt" ValidationGroup="Controls"></asp:RequiredFieldValidator>
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
                                <td align="center" colspan="4">
                                    <asp:Button ID="btn_Submit" runat="server" Text="Submit" ValidationGroup="Controls"
                                        OnClick="btn_Submit_Click" />
                                    &nbsp;
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
                                    <asp:Label ID="lbl_ID" runat="server" Visible="False"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <asp:ValidationSummary ID="VS_Medical_Scheme" runat="server" ValidationGroup="Controls"
                            ShowMessageBox="true" ShowSummary="false" />
                        <br />
                        <table align="center">
                            <tr>
                                <td>
                                    <telerik:RadGrid  ID="RG_MED_DETAILS" runat="server" AutoGenerateColumns="false">
                                        <mastertableview>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="SMHR_MED_DTL_ID" HeaderText="DTL_ID" Visible="false">
                                                </telerik:GridBoundColumn>
                                                 <telerik:GridBoundColumn DataField="SMHR_MED_BILL_NO" HeaderText="Bill No">
                                                 <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SMHR_MED_IP_USED_AMT" HeaderText="IP Used Amount">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SMHR_MED_OP_USED_AMT" HeaderText="OP Used Amount">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SMHR_MED_UTILIZED_DATE" HeaderText="Utilized Date">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                            </Columns>
                                        </mastertableview>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
