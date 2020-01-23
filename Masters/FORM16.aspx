<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="FORM16.aspx.cs" Inherits="Masters_FORM16" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">

    <table align="center">
        <tr>
            <td colspan="5"></td>
        </tr>
        <tr>
            <td colspan="5" align="center">
                <asp:Label ID="lbl_Name" runat="server" Style="font-weight: 700" Text="PAYE Payment Voucher Information"> </asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="5"></td>
        </tr>
        <tr>
            <td colspan="5">

                <telerik:RadMultiPage ID="RMP_Formsixtn" runat="server" SelectedIndex="0">
                    <telerik:RadPageView ID="Search" runat="server">
                        <table align="center">
                            <tr>
                                <td colspan="5"></td>
                            </tr>

                            <tr>
                                <td colspan="5"></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td align="center" colspan="3">
                                    <telerik:RadGrid ID="RG_Formsixtn" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        Skin="WebBlue" GridLines="None" OnNeedDataSource="RG_FormSixtn_NeedDataSource"
                                        AllowFilteringByColumn="True">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="SMHR_FRMSIXTN_ID" HeaderText="ID" UniqueName="SMHR_FRMSIXTN_ID"
                                                    Visible="false">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="BUSINESSUNIT_CODE" HeaderText="Business Unit"
                                                    UniqueName="EMPLOYEE">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMPLOYEENAME" HeaderText="Employee" UniqueName="Id">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="PERIOD_NAME" HeaderText="Financial Period" UniqueName="Period">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SMHR_FRMSIXTN_AMOUNT" HeaderText="Amount" Visible="false" UniqueName="Chalan Number">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SMHR_FRMSIXTN_DATEOFPAYMENT" HeaderText="Date Of Payment"
                                                    UniqueName="SMHR_FRMSIXTN_DATEOFPAYMENT">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SMHR_FRMSIXTN_CHALAN_NO" HeaderText="Chalan Number"
                                                    Visible="false" UniqueName="EMPASSETDOC_CODE3">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="BUSUNTBANK_NAME" HeaderText="Bank" UniqueName="Status" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="SMHR_FRMSIXTN_STATUS" HeaderText="Status"
                                                    meta:resourcekey="SMHR_FRMSIXTN_STATUS" ItemStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Status" runat="server" Text='<%# (Convert.ToString(Eval("SMHR_FRMSIXTN_STATUS")) == "1" ? "Active": "InActive") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="Edit" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_FormSixtn_Edit" runat="server" CommandArgument='<%# Eval("SMHR_FRMSIXTN_ID") %>'
                                                            OnCommand="lnk_AssetDoc_Edit_Command">Edit </asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" meta:resourcekey="lnk_AddResource1" OnCommand="lnk_Add_Command">Add</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                                <td></td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="AddUpdate" runat="server">
                        <table align="center">
                            <tr>
                                <td colspan="5" align="center">&nbsp;</td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business Unit"></asp:Label>
                                </td>
                                <td><b>:</b></td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_BusinessUnit" runat="server" EnableEmbeddedSkins="false" MarkFirstMatch="true" MaxHeight="120px" TabIndex="1"
                                        AutoPostBack="true" OnSelectedIndexChanged="rcmb_BusinessUnit_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_BusinessUnit" runat="server" ControlToValidate="rcmb_BusinessUnit"
                                        InitialValue="Select" ErrorMessage="Please Select Business Unit" Text="*" ValidationGroup="Controls"
                                        meta:resourcekey="rfv_rcmb_BusinessUnit"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Label ID="lbl_Employee" runat="server" Text="Employee"></asp:Label>
                                </td>
                                <td><b>:</b></td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Employee" runat="server" EnableEmbeddedSkins="false" MaxHeight="120px" TabIndex="2"
                                        AutoPostBack="true" MarkFirstMatch="true" OnSelectedIndexChanged="rcmb_Employee_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rcmb_Employee"
                                        InitialValue="Select" ErrorMessage="Please Select Employee" Text="*" ValidationGroup="Controls"
                                        meta:resourcekey="rfv_rcmb_BusinessUnit"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Label ID="lbl_Period" runat="server" Text="Financial Period"></asp:Label>
                                </td>
                                <td><b>:</b></td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Period" runat="server" EnableEmbeddedSkins="false" MarkFirstMatch="true" TabIndex="3"
                                        AutoPostBack="true" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="rcmb_Period"
                                        InitialValue="Select" ErrorMessage="Please Select Financial Period" Text="*" ValidationGroup="Controls"
                                        meta:resourcekey="rfv_rcmb_BusinessUnit"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Label ID="lbl_Amount" runat="server" Text="Amount"></asp:Label>
                                </td>
                                <td><b>:</b></td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_Amount" runat="server" Width="160px" TabIndex="4">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="rtxt_Amount"
                                        InitialValue="" ErrorMessage="Please Specify Amount" Text="*" ValidationGroup="Controls"
                                        meta:resourcekey="rfv_rcmb_BusinessUnit"></asp:RequiredFieldValidator>
                                </td>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="rtxt_Amount"
                                    ErrorMessage="Please Enter Only Numbers" ValidationExpression="\d+(?:(?:\.)\d{1,5})?" ValidationGroup="Controls"></asp:RegularExpressionValidator>



                            </tr>

                            <tr>
                                <td></td>
                                <td>
                                    <asp:Label ID="lbl_PaymentDate" runat="server" Text="Payment Date"></asp:Label>
                                </td>
                                <td><b>:</b></td>
                                <td align="left">
                                    <telerik:RadDatePicker ID="txt_Receiveddate" runat="server" Skin="WebBlue" MinDate="1900-01-01" TabIndex="5"
                                        Culture="English (United States)">
                                        <Calendar Skin="WebBlue" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                            ViewSelectorText="x">
                                        </Calendar>
                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                        <DateInput DateFormat="d/M/yyyy" DisplayDateFormat="d/M/yyyy">
                                        </DateInput>
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_Receiveddate"
                                        InitialValue="" ErrorMessage="Please Select Payment Date" Text="*" ValidationGroup="Controls"
                                        meta:resourcekey="rfv_rcmb_BusinessUnit"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Label ID="lbl_ChalanNumber" runat="server" Text="Chalan Number"></asp:Label>
                                </td>
                                <td><b>:</b></td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_ChalanNumber" runat="server" Width="160px" TabIndex="6">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="rtxt_ChalanNumber"
                                        InitialValue="" ErrorMessage="Please Specify Chalan Number" Text="*" ValidationGroup="Controls"
                                        meta:resourcekey="rfv_rcmb_BusinessUnit"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Label ID="lbl_Bank" runat="server" Text="BusinessUnit Bank"></asp:Label>
                                </td>
                                <td><b>:</b></td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Bank" runat="server" EnableEmbeddedSkins="false" AutoPostBack="true" MarkFirstMatch="true" TabIndex="7" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="rcmb_Bank"
                                        InitialValue="" ErrorMessage="Please Select BusinessUnit Bank" Text="*" ValidationGroup="Controls"
                                        meta:resourcekey="rfv_rcmb_BusinessUnit"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Label ID="lbl_Status" runat="server" Text="Status"></asp:Label>
                                </td>
                                <td><b>:</b></td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Status" runat="server" AutoPostBack="true" Skin="WebBlue" MarkFirstMatch="true" TabIndex="8">
                                        <Items>
                                            <telerik:RadComboBoxItem Text="Active" Value="1" />
                                            <telerik:RadComboBoxItem Text="InActive" Value="0" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_Type" runat="server" ControlToValidate="rcmb_Status"
                                        InitialValue="Select" ErrorMessage="Please Select Asset Type" meta:resourcekey="RFV_Type"
                                        Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5"></td>
                            </tr>

                            <tr>
                                <td></td>
                                <td align="center" colspan="3">
                                    <asp:Button ID="btn_Save" Text="Save" runat="server" OnClick="btn_Save_Click" ValidationGroup="Controls" TabIndex="9" />
                                    <asp:Button ID="btn_Update" Text="Update" runat="server" OnClick="btn_Update_Click" TabIndex="9"
                                        ValidationGroup="Controls" />
                                    <asp:Button ID="btn_Cancel" Text="Cancel" runat="server" OnClick="btn_Cancel_Click" TabIndex="10"
                                        CausesValidation="false" />
                                </td>
                                <td>
                                    <asp:Label ID="lbl_Id" Visible="false" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5"></td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:ValidationSummary ID="vs_Form16" runat="server" ValidationGroup="Controls" ShowMessageBox="true"
                                        ShowSummary="false" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>

            </td>
        </tr>
    </table>
</asp:Content>