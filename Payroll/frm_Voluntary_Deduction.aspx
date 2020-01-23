<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_Voluntary_Deduction.aspx.cs" Inherits="Payroll_frm_Voluntary_Deduction" %>

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
                <asp:Label ID="lblHeader" runat="server" Text="Voluntary Deduction" Font-Bold="true"></asp:Label>
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
                        <td style="width: 9%">
                            <%--<asp:RequiredFieldValidator ID="rfvDir" runat="server" InitialValue="Select" Text="*" ValidationGroup="Controls" ControlToValidate="rcbDir" ErrorMessage="Please Select Directorate"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 49%">
                            <asp:Label ID="lblDept" runat="server" Text="Department"></asp:Label>
                        </td>
                        <td style="width: 2%">
                            <b>:</b>
                        </td>
                        <td style="width: 40%">
                            <telerik:RadComboBox ID="rcbDept" runat="server" OnSelectedIndexChanged="rcbDept_SelectedIndexChanged" MarkFirstMatch="true" AutoPostBack="true" MaxHeight="200" Filter="Contains"></telerik:RadComboBox>
                        </td>
                        <td style="width: 9%">
                            <%--<asp:RequiredFieldValidator ID="rfvDept" runat="server" InitialValue="Select" Text="*" ValidationGroup="Controls" ControlToValidate="rcbDept" ErrorMessage="Please Select Department"></asp:RequiredFieldValidator>--%>
                        </td>
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
                            <%--OnSelectedIndexChanged="rcbEmp_SelectedIndexChanged" AutoPostBack="true" --%>
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
                            <telerik:RadComboBox ID="rcbFinPrd" runat="server" MaxHeight="200" MarkFirstMatch="true" Filter="Contains"></telerik:RadComboBox>
                            <%--OnSelectedIndexChanged="rcbFinPrd_SelectedIndexChanged" AutoPostBack="true" --%>
                        </td>
                        <td style="width: 9%">
                            <asp:RequiredFieldValidator ID="rfvFinPrd" runat="server" InitialValue="Select" Text="*" ValidationGroup="Controls" ControlToValidate="rcbFinPrd" ErrorMessage="Please Select Financial Period"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 49%">
                            <asp:Label ID="lblPayItem" runat="server" Text="Pay Item"></asp:Label>
                        </td>
                        <td style="width: 2%">
                            <b>:</b>
                        </td>
                        <td style="width: 40%">
                            <telerik:RadComboBox ID="rcbPayItem" runat="server" MaxHeight="200" MarkFirstMatch="true" Filter="Contains"></telerik:RadComboBox>
                            <%--OnSelectedIndexChanged="rcbPayItem_SelectedIndexChanged" AutoPostBack="true" --%>
                        </td>
                        <td style="width: 9%">
                            <asp:RequiredFieldValidator ID="rfvPayItem" runat="server" InitialValue="Select" Text="*" ValidationGroup="Controls" ControlToValidate="rcbPayItem" ErrorMessage="Please Select Pay Item"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 51%" align="right">
                <asp:Button ID="btnGenerate" runat="server" OnClick="btnGenerate_Click" Text="Generate" UseSubmitBehavior="false" OnClientClick="fnJSOnFormSubmit(this,'Controls')" />
            </td>
            <%--<td style="width:2%">
                </td>--%>
            <td style="width: 40%">
                <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear" />
            </td>
            <td style="width: 40%">
                <asp:ValidationSummary ID="vsVolDed" runat="server" ValidationGroup="Controls" ShowMessageBox="true" ShowSummary="false" />
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <table style="text-align: center">
                    <asp:Panel ID="pnlCalMode" runat="server" Visible="false">
                        <tr>
                            <td>
                                <asp:Label ID="lblCalMode" runat="server" Text="Calculation Mode"></asp:Label>
                            </td>
                            <td>
                                <b>:</b>
                            </td>
                            <td>
                                <telerik:RadComboBox ID="rcbCalMode" runat="server" MaxHeight="200" MarkFirstMatch="true" ValidationGroup="Controls2">
                                    <Items>
                                        <telerik:RadComboBoxItem runat="server" Text="Select" Value="0" />
                                        <telerik:RadComboBoxItem runat="server" Text="%Age" Value="1" />
                                        <telerik:RadComboBoxItem runat="server" Text="Direct" Value="2" />
                                    </Items>
                                </telerik:RadComboBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvCalMode" runat="server" InitialValue="Select" Text="*" ValidationGroup="Controls2" ControlToValidate="rcbCalMode" ErrorMessage="Please Select Calculation Mode"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </asp:Panel>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center" style="width: 60%">
                <telerik:RadGrid ID="rgVolDeduction" runat="server" AutoGenerateColumns="False" GridLines="None" Visible="false" OnItemDataBound="rgVolDeduction_ItemDataBound"
                    AllowPaging="true" AllowFilteringByColumn="true" Skin="WebBlue" OnNeedDataSource="rgVolDeduction_NeedDataSource" PageSize="12">
                    <MasterTableView CommandItemDisplay="None">
                        <Columns>
                            <telerik:GridBoundColumn DataField="PERIOD_ID" UniqueName="PERIOD_ID" HeaderText="ID"
                                meta:resourcekey="PERIOD_ID" Visible="False">
                            </telerik:GridBoundColumn>

                            <telerik:GridTemplateColumn HeaderText="Choose" AllowFiltering="false">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chk_Choose" runat="server" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>

                            <telerik:GridBoundColumn DataField="PRDDTL_NAME" UniqueName="PRDDTL_NAME"
                                AllowFiltering="true" HeaderText="Period Detail"
                                ItemStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>

                            <telerik:GridTemplateColumn UniqueName="Amount" HeaderText="Amount" ItemStyle-HorizontalAlign="Left" AllowFiltering="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_PrdDtlID" runat="Server" Text='<%# Eval("PRDDTL_ID") %>' Visible="false"></asp:Label>
                                    <%--<asp:Label ID="lbl_VolDedPrdDtlID" runat="Server" Text='<%# Eval("VOLUNTARY_DEDUCTION_DETAIL_PRDDTL_ID") %>' Visible="false"></asp:Label>--%>
                                    <asp:Label ID="lbl_PrdDtlMoney" runat="Server" Text='<%# Eval("VOLUNTARY_DEDUCTION_DETAIL_AMOUNT") %>' Visible="false"></asp:Label>
                                    <telerik:RadNumericTextBox ID="rntbMoney" runat="server" Width="10px" MaxLength="250" MinValue="0">
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
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Visible="false" /><%-- OnClick="btnCancel_Click"
                <asp:Button ID="btnDeduction" runat="server" OnClick="btnDeduction_Click" Visible="false" Text="Deduct Amount"></asp:Button>
                <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Visible="false" Text="Back"></asp:Button>--%>
            </td>
        </tr>
        <%--<tr>
            <td></td>
            <td colspan="2">
                <asp:LinkButton ID="btnDeduction" runat="server" OnClick="btnDeduction_Click" Visible="false"></asp:LinkButton>
                <asp:LinkButton ID="btnBack" runat="server" OnClick="btnBack_Click" Visible="false"></asp:LinkButton>
            </td>
            <td></td>
        </tr>
        <tr>
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
        </tr>--%>
    </table>
</asp:Content>