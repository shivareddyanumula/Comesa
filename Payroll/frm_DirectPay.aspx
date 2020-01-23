<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_DirectPay.aspx.cs" Inherits="Payroll_frm_DirectPay" Culture="auto"
    UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center" width="60%">
        <tr>
            <td>
                <telerik:RadMultiPage ID="RMP_DirectPayments" runat="server" SelectedIndex="0" Width="100%"
                    Height="470px">
                    <telerik:RadPageView ID="RPW_DirectPayments_Search" runat="server">
                        <br />
                        <table align="center" width="90%">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblHeader" runat="server" meta:resourcekey="lblHeader"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="RG_DirectPayments" runat="server" AutoGenerateColumns="false"
                                        Skin="WebBlue" AllowFilteringByColumn="true" OnNeedDataSource="RG_DirectPayments_NeedDataSource"
                                        Width="100%" AllowPaging="True">
                                        <HeaderContextMenu Skin="WebBlue">
                                        </HeaderContextMenu>
                                        <PagerStyle AlwaysVisible="True" />
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="SMHR_DIRECTPMT_ID" HeaderText="ID" UniqueName="SMHR_DIRECTPMT_ID"
                                                    Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SMHR_DIRECTPMT_BUID" HeaderText="BUID" UniqueName="SMHR_DIRECTPMT_BUID"
                                                    Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="BUSINESSUNIT_CODE" HeaderText="Business&nbsp;Unit"
                                                    UniqueName="BUSINESSUNIT_CODE">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SMHR_DIRECTPMT_EMPID" HeaderText="EMPID" UniqueName="SMHR_DIRECTPMT_EMPID"
                                                    Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMP_NAME" HeaderText="Employee&nbsp;Name" UniqueName="EMP_NAME">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SMHR_DIRECTPMT_ISSUEDT" HeaderText="Issue&nbsp;Date"
                                                    UniqueName="SMHR_DIRECTPMT_ISSUEDT">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SMHR_DIRECTPMT_AMOUNT" HeaderText="Amount" UniqueName="SMHR_DIRECTPMT_AMOUNT">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="HR_MASTER_CODE" UniqueName="HR_MASTER_CODE" HeaderText="Employee Grade">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="false" UniqueName="Edit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("SMHR_DIRECTPMT_ID") %>'
                                                            OnCommand="lnk_Edit_Command">Edit
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <EditFormSettings>
                                                <EditColumn CancelImageUrl="Cancel.gif" EditImageUrl="Edit.gif" InsertImageUrl="Update.gif"
                                                    UpdateImageUrl="Update.gif">
                                                </EditColumn>
                                            </EditFormSettings>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" OnClick="lnk_Add_Click" Text="Add"></asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <FilterMenu Skin="WebBlue">
                                        </FilterMenu>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RPW_DirectPayments" runat="server">
                        <br />
                        <table align="center">
                            <tr>
                                <td colspan="3" align="center">
                                    <asp:Label ID="lbl_Header" runat="server" meta:resourcekey="lbl_Header"></asp:Label>
                                </td>
                                <td align="center">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_BusinessUnit" runat="server" meta:resourcekey="lbl_BusinessUnit"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="ddl_BusinessUnit" runat="server" Skin="WebBlue" AutoPostBack="true" MarkFirstMatch="true"
                                        OnSelectedIndexChanged="ddl_BusinessUnit_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_BusinessUnit" runat="server" InitialValue="Select"
                                        ValidationGroup="Controls" Text="*" Display="Dynamic" ControlToValidate="ddl_BusinessUnit"
                                        ErrorMessage="Please Select Business Unit"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Employee" runat="server" meta:resourcekey="lbl_Employee"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="ddl_Employee" runat="server" Skin="WebBlue" MaxHeight="120px" MarkFirstMatch="true" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_Employee" runat="server" InitialValue="Select"
                                        ValidationGroup="Controls" Text="*" Display="Dynamic" ControlToValidate="ddl_Employee"
                                        ErrorMessage="Please Select Employee"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_IssueDate" runat="server" meta:resourcekey="lbl_IssueDate"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="rdp_Issuedate" runat="server" Skin="WebBlue">
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_Issuedate" runat="server" ValidationGroup="Controls"
                                        Text="*" Display="Dynamic" ControlToValidate="rdp_Issuedate" ErrorMessage="Please Specify Issue Date"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Type" runat="server" meta:resourcekey="lbl_Type"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="ddl_paymentType" runat="server" Skin="WebBlue" AutoPostBack="true" MarkFirstMatch="true"
                                        OnSelectedIndexChanged="ddl_paymentType_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_PaymentType" runat="server" ControlToValidate="ddl_paymentType"
                                        InitialValue="Select" Display="Dynamic" ErrorMessage="Please Select Payment Type" Text="*"
                                        ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr runat="server" id="cheque">
                                <td>
                                    <asp:Label ID="lbl_Cheque" runat="server" meta:resourcekey="lbl_Cheque"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="txt_ChequeNumber" runat="server" NumberFormat-DecimalDigits="0"
                                        NumberFormat-GroupSeparator="">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_ChequeNumber" runat="server" ControlToValidate="txt_ChequeNumber"
                                        Display="Dynamic" ErrorMessage="Please Specify Cheque Number" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Amount" runat="server" meta:resourcekey="lbl_Amount"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="rntxt_Amount" runat="server" Skin="WebBlue" MaxLength="12" MinValue="0">
                                        <IncrementSettings Step="0" />
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_Amount" runat="server" ControlToValidate="rntxt_Amount"
                                        Display="Dynamic" ErrorMessage="Please Specify Amount" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Remarks" runat="server" meta:resourcekey="lbl_Remarks"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txt_Remarks" runat="server" AutoCompleteType="Disabled" Skin="WebBlue" MaxLength="1000">
                                    </telerik:RadTextBox>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>&nbsp;
                                </td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Button ID="btn_Save" runat="server" OnClick="btn_Save_Click" Text="Save" ValidationGroup="Controls" />
                                    <asp:Button ID="btn_Correct" runat="server" OnClick="btn_Correct_Click" Text="Update"
                                        ValidationGroup="Controls" />
                                    <asp:Button ID="btn_Cancel" runat="server" OnClick="btn_Cancel_Click" Text="Cancel" />
                                </td>
                                <td align="center">&nbsp;
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="vs_summary" runat="server" ShowMessageBox="true" ShowSummary="false"
        ValidationGroup="Controls" />
</asp:Content>