<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_Voluntary_Deduction_Arrears.aspx.cs"
    Inherits="Payroll_frm_Voluntary_Deduction_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <script type="text/javascript"></script>
    <table align="center" runat="server" style="width: 30%">
        <tr>
            <td colspan="4" align="center"></td>
        </tr>
        <tr>
            <td colspan="4" align="center"></td>
        </tr>
        <tr>
            <td colspan="4" align="center"></td>
        </tr>
        <tr>
            <td colspan="4" align="center"></td>
        </tr>
        <tr>
            <td colspan="4" align="center"></td>
        </tr>
        <tr>
            <td colspan="4" align="center"></td>
        </tr>
        <tr>
            <td colspan="4" align="center"></td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="lblHeader" runat="server" Text="Voluntary Deduction Arrears" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center"></td>
        </tr>
        <tr>
            <td colspan="4" align="center"></td>
        </tr>
        <tr>
            <td colspan="4" align="center"></td>
        </tr>
        <tr>
            <td colspan="4" align="center"></td>
        </tr>
        <tr>
            <td colspan="4" style="width: 100%">
                <table width="100%">
                    <tr>
                        <td style="width: 49%">
                            <asp:Label ID="lblBU" runat="server" Text="Business Unit"></asp:Label>
                        </td>
                        <td style="width: 2%">
                            <b>:</b>
                        </td>
                        <td style="width: 40%">
                            <telerik:RadComboBox ID="rcbBU" runat="server" OnSelectedIndexChanged="rcbBU_SelectedIndexChanged" MarkFirstMatch="true" AutoPostBack="true" MaxHeight="200" Filter="Contains"></telerik:RadComboBox>
                        </td>
                        <td style="width: 9%">
                            <asp:RequiredFieldValidator ID="rfvBU" runat="server" InitialValue="Select" Text="*" ValidationGroup="Controls" ControlToValidate="rcbBU" ErrorMessage="Please Select Business Unit"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 49%">
                            <asp:Label ID="lblDir" runat="server" Text="Directorate"></asp:Label>
                        </td>
                        <td style="width: 2%">
                            <b>:</b>
                        </td>
                        <td style="width: 40%">
                            <telerik:RadComboBox ID="rcbDir" runat="server" OnSelectedIndexChanged="rcbDir_SelectedIndexChanged" MarkFirstMatch="true" AutoPostBack="true" MaxHeight="200" Filter="Contains"></telerik:RadComboBox>
                        </td>
                        <td style="width: 9%"></td>
                    </tr>
                    <tr>
                        <td style="width: 49%">
                            <asp:Label ID="lblDept" runat="server" Text="Department"></asp:Label>
                        </td>
                        <td style="width: 2%">
                            <b>:</b>
                        </td>
                        <td style="width: 40%">
                            <telerik:RadComboBox ID="rcbDept" runat="server" MarkFirstMatch="true" AutoPostBack="true" MaxHeight="200" OnSelectedIndexChanged="rcbDept_SelectedIndexChanged" Filter="Contains"></telerik:RadComboBox>
                        </td>
                        <td style="width: 9%"></td>
                    </tr>
                    <tr>
                        <td style="width: 49%">
                            <asp:Label ID="lblEmp" runat="server" Text="Employee"></asp:Label>
                        </td>
                        <td style="width: 2%">
                            <b>:</b>
                        </td>
                        <td style="width: 40%">
                            <telerik:RadComboBox ID="rcbEmp" runat="server" MaxHeight="200" MarkFirstMatch="true" Filter="Contains"></telerik:RadComboBox>
                        </td>
                        <td style="width: 9%">
                            <asp:RequiredFieldValidator ID="rfvEmp" runat="server" InitialValue="Select" Text="*" ValidationGroup="Controls" ControlToValidate="rcbEmp" ErrorMessage="Please Select Employee"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 49%">
                            <asp:Label ID="lblFinPrd" runat="server" Text="Financial Period"></asp:Label>
                        </td>
                        <td style="width: 2%">
                            <b>:</b>
                        </td>
                        <td style="width: 40%">
                            <telerik:RadComboBox ID="rcbFinPrd" OnSelectedIndexChanged="rcbFinPrd_SelectedIndexChanged" AutoPostBack="true" runat="server" MaxHeight="200" MarkFirstMatch="true" Filter="Contains"></telerik:RadComboBox>
                        </td>
                        <td style="width: 9%">
                            <asp:RequiredFieldValidator ID="rfvFinPrd" runat="server" InitialValue="Select" Text="*" ValidationGroup="Controls" ControlToValidate="rcbFinPrd" ErrorMessage="Please Select Financial Period"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 49%">
                            <asp:Label ID="lblPrdDtl" runat="server" Text="Period Detail"></asp:Label>
                        </td>
                        <td style="width: 2%">
                            <b>:</b>
                        </td>
                        <td style="width: 40%">
                            <telerik:RadComboBox ID="rcbPrdDtl" runat="server" MaxHeight="200" MarkFirstMatch="true" AutoPostBack="true" OnSelectedIndexChanged="rcbPrdDtl_SelectedIndexChanged" Filter="Contains"></telerik:RadComboBox>
                            <%-- --%>
                        </td>
                        <td style="width: 9%">
                            <asp:RequiredFieldValidator ID="rfvPrdDtl" runat="server" InitialValue="Select" Text="*" ValidationGroup="Controls" ControlToValidate="rcbPrdDtl" ErrorMessage="Please Select Period Detail"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <%--<tr>
                        <td style="width:49%">
                            <asp:Label ID="lblPayItem" runat="server" Text="Pay Item"></asp:Label>
                        </td>
                        <td style="width:2%">
                            <b>:</b>
                        </td>
                        <td style="width:40%">
                            <telerik:RadComboBox ID="rcbPayItem" runat="server" OnSelectedIndexChanged="rcbPayItem_SelectedIndexChanged" AutoPostBack="true" MaxHeight="200" MarkFirstMatch="true"></telerik:RadComboBox>
                        </td>
                        <td style="width:9%">
                            <asp:RequiredFieldValidator ID="rfvPayItem" runat="server" InitialValue="Select" Text="*" ValidationGroup="Controls" ControlToValidate="rcbPayItem" ErrorMessage="Please Select Pay Item"></asp:RequiredFieldValidator>
                        </td>
                    </tr>--%>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 51%" align="right">
                <asp:Button ID="btnGenerate" runat="server" OnClick="btnGenerate_Click" Text="Generate" UseSubmitBehavior="false" OnClientClick="fnJSOnFormSubmit(this,'Controls')" />
            </td>
            <td style="width: 40%">
                <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear" />
            </td>
            <td style="width: 40%">
                <asp:ValidationSummary ID="vsVolDed" runat="server" ValidationGroup="Controls" ShowMessageBox="true" ShowSummary="false" />
            </td>
        </tr>
    </table>
    <table align="center" runat="server" style="width: 90%">
        <tr>
            <td colspan="4">
                <%--<asp:Panel ID="pnlGrid" runat="server" Visible="false">
                    <tr>
                        <td colspan="4" align="center" style="width: 90%">--%>
                <telerik:RadGrid ID="rgVolDedArrears" runat="server" AutoGenerateColumns="False" GridLines="None" Visible="false" OnItemDataBound="rgVolDedArrears_ItemDataBound"
                    AllowPaging="true" AllowFilteringByColumn="true" Skin="WebBlue" OnNeedDataSource="rgVolDedArrears_NeedDataSource" PageSize="10">
                    <MasterTableView CommandItemDisplay="None">
                        <Columns>
                            <telerik:GridBoundColumn DataField="PAYITEM_ID" UniqueName="PAYITEM_ID" HeaderText="ID"
                                meta:resourcekey="PAYITEM_ID" Visible="False">
                            </telerik:GridBoundColumn>

                            <telerik:GridTemplateColumn HeaderText="Choose" AllowFiltering="false">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chk_Choose" runat="server" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>

                            <telerik:GridBoundColumn DataField="PAYITEM_PAYITEMNAME" UniqueName="PAYITEM_PAYITEMNAME"
                                AllowFiltering="true" HeaderText="Pay Item"
                                ItemStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>

                            <%--<telerik:GridBoundColumn DataField="EMPSALDTLS_AMOUNT" UniqueName="EMPSALDTLS_AMOUNT"
                                AllowFiltering="true" HeaderText="Emp Sal Amnt"
                                ItemStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>--%>

                            <telerik:GridBoundColumn DataField="VOLUNTARY_DEDUCTION_AMOUNT" UniqueName="VOLUNTARY_DEDUCTION_AMOUNT"
                                AllowFiltering="true" HeaderText="Accumulated Amount"
                                ItemStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="VOLUNTARY_DEDUCTION_ARREARS_AMOUNT" UniqueName="VOLUNTARY_DEDUCTION_ARREARS_AMOUNT"
                                AllowFiltering="true" HeaderText="Withdrawn Amount"
                                ItemStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="ELIGIBLE_AMOUNT" UniqueName="ELIGIBLE_AMOUNT"
                                AllowFiltering="true" HeaderText="Balance Amount"
                                ItemStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>

                            <telerik:GridTemplateColumn UniqueName="Amount" HeaderText="Amount" ItemStyle-HorizontalAlign="Left" AllowFiltering="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_PayItemID" runat="Server" Text='<%# Eval("PAYITEM_ID") %>' Visible="false"></asp:Label>
                                    <asp:Label ID="lbl_EligibleAmnt" runat="Server" Text='<%# Eval("ELIGIBLE_AMOUNT") %>' Visible="false"></asp:Label>
                                    <asp:Label ID="lbl_ArrearsAmnt" runat="Server" Text='<%# Eval("AMOUNT") %>' Visible="false"></asp:Label>
                                    <telerik:RadNumericTextBox ID="rntbMoney" runat="server" Width="10px" MaxLength="250" MinValue="1">
                                    </telerik:RadNumericTextBox>
                                    <asp:RequiredFieldValidator ID="rfv_Money" runat="server" Enabled="false" ControlToValidate="rntbMoney" ErrorMessage="Please Enter Money" ValidationGroup="Controls2">*</asp:RequiredFieldValidator>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                    <PagerStyle AlwaysVisible="true" />
                </telerik:RadGrid>
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" Visible="false" />
                <%--<asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" Visible="false" />--%>
            </td>
        </tr>
        <%--<tr>
            <td colspan="4">
                <table>
                    <asp:Panel ID="pnlDeductions" runat="server" Visible="false">
                        <tr>
                            <td>
                                <asp:Label ID="lblAvailAmnt" runat="server" Text="Available Amount"></asp:Label>
                            </td>
                            <td><b>:</b></td>
                            <td>
                                <telerik:RadNumericTextBox ID="rntbAvailAmnt" runat="server" Enabled="false"></telerik:RadNumericTextBox>
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDeductedAmnt" runat="server" Text="Amount to be Deducted"></asp:Label>
                            </td>
                            <td><b>:</b></td>
                            <td>
                                <telerik:RadNumericTextBox ID="rntbDeductedAmnt" runat="server" EmptyMessage="Please Enter Amount"></telerik:RadNumericTextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvAmnt" runat="server" ControlToValidate="rntbDeductedAmnt" ErrorMessage="Please Enter Amount" ValidationGroup="Controls2">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="cmpAmnt" runat="server" ControlToCompare="rntbAvailAmnt" ControlToValidate="rntbDeductedAmnt"
                                    Operator="LessThanEqual" ValidationGroup="Controls2" Type="Double" ErrorMessage="Please Enter less or equal Amount as shown in Available Amount..">*</asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnDeduct" runat="server" OnClick="btnDeduct_Click" Text="Deduct" ValidationGroup="Controls2" />
                                <asp:Button ID="btnCancelDeduct" runat="server" Text="Cancel" OnClick="btnCancelDeduct_Click" />
                                <asp:ValidationSummary ID="vsDeductions" runat="server" ValidationGroup="Controls2" ShowMessageBox="true" ShowSummary="false" />
                            </td>
                            <td></td>
                        </tr>
                    </asp:Panel>
                </table>
            </td>
        </tr>
                </asp:Panel>
            </td>
        </tr>--%>
    </table>
</asp:Content>