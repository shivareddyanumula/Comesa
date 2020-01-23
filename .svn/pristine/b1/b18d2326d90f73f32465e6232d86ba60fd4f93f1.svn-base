<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_ExpenseTrans.aspx.cs" Inherits="Payroll_frm_ExpenseTrans" %>

<asp:Content ID="cnt_ExpenseTrans" ContentPlaceHolderID="cphDefault" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <telerik:RadAjaxManagerProxy ID="RAM_ExpenseEntry" runat="server">
                <AjaxSettings>
                    <telerik:AjaxSetting AjaxControlID="Rg_ExpenseTrans">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="lnk_Edit">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="lnk_Add">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="btn_Cancel">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="rcmb_ExpenseName">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="rcmb_Employee">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="btn_Details_Cancel">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="lnk_Details_Add">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="lnk_Details_Edit">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="rcmb_BusinessUnit">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                </AjaxSettings>
            </telerik:RadAjaxManagerProxy>
            <table align="center" style="vertical-align: top;">
                <tr>
                    <td align="center">
                        <asp:Label ID="lbl_ExpenseEntryHeader" runat="server" Text="Expense Entry" Font-Bold="True"
                            meta:resourcekey="lbl_ExpenseEntryHeader"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <telerik:RadMultiPage ID="Rm_RT_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                            Width="990px" Height="490px">
                            <telerik:RadPageView ID="Rp_RT_ViewMain" runat="server">
                                <table align="center" width="60%">
                                    <tr>
                                        <td>
                                            <telerik:RadGrid ID="Rg_ExpenseTrans" runat="server"
                                                AutoGenerateColumns="False" GridLines="None" ActiveItemStyle-HorizontalAlign="Center"
                                                Skin="WebBlue" OnNeedDataSource="Rg_ExpenseTrans_NeedDataSource" AllowPaging="True" AllowFilteringByColumn="true">
                                                <MasterTableView CommandItemDisplay="Top">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="EXPENSE_ID" HeaderText="ID" meta:resourcekey="EXPENSE_ID"
                                                            UniqueName="EXPENSE_ID" Visible="False">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EXPENSE_NAME" HeaderStyle-HorizontalAlign="Center"
                                                            HeaderText="Expense Name" meta:resourcekey="EXPENSE_NAME" UniqueName="EXPENSE_NAME">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EXPENSE_EMP_ID" HeaderStyle-HorizontalAlign="Center"
                                                            HeaderText="Employee Name" meta:resourcekey="EXPENSE_EMP_ID" UniqueName="EMPNAME">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EXPENSE_APPDATE" HeaderStyle-HorizontalAlign="Center"
                                                            HeaderText="Applied Date" meta:resourcekey="EXPENSE_APPDATE" UniqueName="EXPENSE_APPDATE">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EXPENSE_STATUS" HeaderStyle-HorizontalAlign="Center"
                                                            HeaderText="Status" meta:resourcekey="EXPENSE_STATUS" UniqueName="EXPENSE_STATUS">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="HR_MASTER_CODE" UniqueName="HR_MASTER_CODE" HeaderText="Employee Grade">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn UniqueName="ColEdit" AllowFiltering="false">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("EXPENSE_ID") %>'
                                                                    meta:resourcekey="lnk_Edit" OnCommand="lnk_Edit_Command">Edit</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                    </Columns>
                                                    <CommandItemTemplate>
                                                        <div align="right">
                                                            <asp:LinkButton ID="lnk_Add" runat="server" meta:resourcekey="lnk_Add" OnCommand="lnk_Add_Command">Add</asp:LinkButton>
                                                        </div>
                                                    </CommandItemTemplate>
                                                </MasterTableView><PagerStyle AlwaysVisible="true" />
                                            </telerik:RadGrid>
                                        </td>
                                    </tr>
                                </table>
                            </telerik:RadPageView>
                            <telerik:RadPageView ID="Rp_RT_ViewDetails" runat="server">
                                <table>
                                    <tr>
                                        <td>
                                            <table align="center">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_BusinessUnit" runat="server" meta:resourcekey="lbl_BusinessUnit">Business Unit</asp:Label>
                                                    </td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadComboBox ID="rcmb_BusinessUnit" Skin="WebBlue" Filter="Contains"
                                                            MarkFirstMatch="true" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rcmb_BusinessUnit_SelectedIndexChanged">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rcmb_BusinessUnit" runat="server" ControlToValidate="rcmb_BusinessUnit"
                                                            ErrorMessage="Please Select Business Unit" InitialValue="Select" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_Employee" runat="server" meta:resourcekey="lbl_Employee">Employee</asp:Label>
                                                    </td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadComboBox ID="rcmb_Employee" runat="server" MaxHeight="120px"
                                                            Skin="WebBlue" MarkFirstMatch="true" Filter="Contains">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rcmb_Employee" runat="server" ControlToValidate="rcmb_Employee"
                                                            ErrorMessage="Please Select Employee" InitialValue="Select" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lbl_ExpenseName" runat="server" meta:resourcekey="lbl_BusinessUnit">Expense Name</asp:Label>
                                                            <asp:Label ID="lbl_ExpenseID" runat="server" Visible="False"></asp:Label>
                                                        </td>
                                                        <td>:
                                                        </td>
                                                        <td>
                                                            <telerik:RadTextBox ID="rtxt_ExpenseName" runat="server"
                                                                MaxLength="50" Skin="WebBlue">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="RFV_ExpenseName" runat="server" ControlToValidate="rtxt_ExpenseName"
                                                                ErrorMessage="Please Specify Expense Name" Text="*"
                                                                ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lbl_AppliedDate" runat="server" meta:resourcekey="lbl_AppliedDate">Applied Date</asp:Label>
                                                        </td>
                                                        <td>:
                                                        </td>
                                                        <td>
                                                            <telerik:RadDatePicker ID="rdp_AppliedDate" runat="server"
                                                                Skin="WebBlue">
                                                            </telerik:RadDatePicker>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="RFV_rdp_AppliedDate" runat="server" ControlToValidate="rdp_AppliedDate"
                                                                ErrorMessage="Please Select Applied on" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Button ID="btn_Edit" runat="server" meta:resourcekey="btn_Edit" OnClick="btn_Save_Click"
                                                Text="Update" ValidationGroup="Controls" Visible="False" />
                                            <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click"
                                                Text="Save" Visible="False" OnClientClick="disableButton(this,'Controls')" UseSubmitBehavior="false" />
                                            <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click"
                                                Text="Cancel" />
                                            <asp:ValidationSummary ID="vs_ExpenseEntry" runat="server" ShowMessageBox="True"
                                                ShowSummary="False" ValidationGroup="Controls" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <telerik:RadMultiPage ID="Rm_Expense" runat="server" SelectedIndex="0" Style="z-index: 10"
                                                Width="990px" Height="290px">
                                                <telerik:RadPageView ID="Rm_ExpenseDetail_view" runat="server">
                                                    <table align="center">
                                                        <tr>
                                                            <td>
                                                                <telerik:RadGrid ID="Rg_ExpenseDetails" runat="server"
                                                                    AutoGenerateColumns="False" GridLines="None" ActiveItemStyle-HorizontalAlign="Center"
                                                                    Skin="WebBlue" OnNeedDataSource="Rg_ExpenseDetails_NeedDataSource" AllowPaging="True">
                                                                    <MasterTableView CommandItemDisplay="Top">
                                                                        <Columns>
                                                                            <telerik:GridBoundColumn DataField="SNO" HeaderText="S. No" meta:resourcekey="SNO"
                                                                                UniqueName="SNO">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridBoundColumn>
                                                                            <telerik:GridBoundColumn DataField="EXPENSEDTL_ID" HeaderText="ID" meta:resourcekey="EXPENSEDTL_ID"
                                                                                UniqueName="EXPENSEDTL_ID" Visible="False">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridBoundColumn>
                                                                            <telerik:GridBoundColumn DataField="_EXPENSEDTL_TYPE_ID" HeaderStyle-HorizontalAlign="Center"
                                                                                HeaderText="Expense Type" meta:resourcekey="EXPENSEDTL_TYPE_ID" UniqueName="EXPENSEDTL_TYPE_ID">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridBoundColumn>
                                                                            <telerik:GridBoundColumn DataField="EXPENSEDTL_EXPENSEDATE" HeaderStyle-HorizontalAlign="Center"
                                                                                HeaderText="Expense Date" meta:resourcekey="EXPENSEDTL_EXPENSEDATE" UniqueName="EXPENSEDTL_EXPENSEDATE">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridBoundColumn>
                                                                            <telerik:GridBoundColumn DataField="EXPENSEDTL_AMOUNT" HeaderStyle-HorizontalAlign="Center"
                                                                                HeaderText="Amount" meta:resourcekey="EXPENSEDTL_AMOUNT" UniqueName="EXPENSEDTL_AMOUNT">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridBoundColumn>
                                                                            <telerik:GridBoundColumn DataField="_EXPENSEDTL_CURRID" HeaderStyle-HorizontalAlign="Center"
                                                                                HeaderText="Currency" meta:resourcekey="EXPENSEDTL_CURRID" UniqueName="EXPENSEDTL_CURRID">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridBoundColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="ColEdit">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnk_Details_Edit" runat="server" CommandArgument='<%# Eval("SNO") %>'
                                                                                        meta:resourcekey="lnk_Details_Edit" OnCommand="lnk_Details_Edit_Command">Edit</asp:LinkButton>
                                                                                </ItemTemplate>
                                                                            </telerik:GridTemplateColumn>
                                                                        </Columns>
                                                                        <CommandItemTemplate>
                                                                            <div align="right">
                                                                                <asp:LinkButton ID="lnk_Details_Add" runat="server" meta:resourcekey="lnk_Details_Add"
                                                                                    OnCommand="lnk_Details_Add_Command">Add</asp:LinkButton>
                                                                            </div>
                                                                        </CommandItemTemplate>
                                                                    </MasterTableView><PagerStyle AlwaysVisible="true" />
                                                                </telerik:RadGrid>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </telerik:RadPageView>
                                                <telerik:RadPageView ID="Rm_ExpenseDetail_Details" runat="server">
                                                    <table align="center">
                                                        <tr>
                                                            <td colspan="4" align="center">&nbsp;
                                                            </td>
                                                            <td align="center">&#160;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" align="center">
                                                                <asp:Label ID="lbl_ExpenseDetails_Header" runat="server" Text="Expense Details">
                                                                </asp:Label>
                                                            </td>
                                                            <td align="center">&#160;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_Sno" runat="server" Visible="false">
                                                                </asp:Label>
                                                                <asp:Label ID="lbl_ExpenseDetailsID" runat="server" Visible="false">
                                                                </asp:Label>
                                                                <asp:Label ID="lbl_ExpenseType" runat="server" meta:resourcekey="lbl_ExpenseType">Expense Type</asp:Label><asp:Label
                                                                    ID="lbl_ExpenseDetailID" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td>
                                                                <telerik:RadComboBox ID="rcmb_ExpenseType" Skin="WebBlue"
                                                                    MarkFirstMatch="true" runat="server" Filter="Contains">
                                                                </telerik:RadComboBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RFV_Expense" runat="server" ControlToValidate="rcmb_ExpenseType"
                                                                    ErrorMessage="Please Select Expense Type" Text="*" InitialValue="Select" ValidationGroup="Controls1"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="btn_ExpenseType_Refresh" runat="server" ImageUrl="~/Images/refreshIcon.png"
                                                                    OnClick="btn_ExpenseType_Refresh_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_ExpenseDate" runat="server" meta:resourcekey="lbl_ExpenseDate">Expense Date</asp:Label>
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td>
                                                                <telerik:RadDatePicker ID="rdp_ExpenseDate" Skin="WebBlue"
                                                                    runat="server">
                                                                </telerik:RadDatePicker>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RFV_ExpenseDate" runat="server" ControlToValidate="rdp_ExpenseDate"
                                                                    ErrorMessage="Please Enter Expense Date" Text="*" ValidationGroup="Controls1"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>&#160;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_ExpenseAmount" runat="server" meta:resourcekey="lbl_ExpenseAmount">Expense Amount</asp:Label>
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td>
                                                                <telerik:RadNumericTextBox ID="rtxt_ExpenseAmt" Skin="WebBlue"
                                                                    runat="server">
                                                                </telerik:RadNumericTextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RFV_ExpenseAmount" runat="server" ControlToValidate="rtxt_ExpenseAmt"
                                                                    ErrorMessage="Please Enter Expense Amount" Text="*" ValidationGroup="Controls1"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>&#160;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_Currency" runat="server" meta:resourcekey="lbl_Currency">Currency </asp:Label>
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td>
                                                                <telerik:RadComboBox ID="rcmb_ExpenseCurrency" Skin="WebBlue" MarkFirstMatch="true"
                                                                    runat="server" Filter="Contains">
                                                                </telerik:RadComboBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_rcmb_ExpenseCurrency" runat="server" ControlToValidate="rcmb_ExpenseCurrency"
                                                                    ErrorMessage="Please Select Currency" InitialValue="Select" Text="*" ValidationGroup="Controls1"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="btn_Currency_Refresh" runat="server" ImageUrl="~/Images/refreshIcon.png"
                                                                    OnClick="btn_Currency_Refresh_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_ExpenseDesc" runat="server" meta:resourcekey="lbl_ExpenseDesc">Description</asp:Label>
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td>
                                                                <telerik:RadTextBox ID="rtxt_Description" Skin="WebBlue"
                                                                    runat="server" MaxLength="100">
                                                                </telerik:RadTextBox>
                                                            </td>
                                                            <td>
                                                                <%-- <asp:RequiredFieldValidator ID="RFV_ExpenseDesc" runat="server" ControlToValidate="rtxt_Description"
                                                            meta:resourcekey="RFV_ExpenseDesc" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator> --%>
                                                            </td>
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_ExpenseUpload" runat="server" Text="Attachment"></asp:Label>
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td>
                                                                <asp:FileUpload ID="fup_ExpenseUpload" runat="server" />
                                                            </td>
                                                            <td>&nbsp;&nbsp;
                                                            </td>
                                                            <td>&#160;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>
                                                                <asp:LinkButton ID="lnk_fup_ExpenseUpload" Visible="false" runat="server">Click Here to View</asp:LinkButton>
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>&#160;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="4">
                                                                <asp:Button ID="btn_Details_Edit" runat="server" meta:resourcekey="btn_Details_Edit"
                                                                    OnClick="btn_Details_Save_Click" Text="Update Details" ValidationGroup="Controls1"
                                                                    Visible="False" />
                                                                <asp:Button ID="btn_Details_Save" runat="server" meta:resourcekey="btn_Details_Save"
                                                                    OnClick="btn_Details_Save_Click" Text="Save Details" ValidationGroup="Controls1"
                                                                    Visible="False" />
                                                                <asp:Button ID="btn_Details_Cancel" runat="server" meta:resourcekey="btn_Details_Cancel"
                                                                    OnClick="btn_Details_Cancel_Click" Text="Cancel" />
                                                                <asp:ValidationSummary ID="vs_ExpenseDetails" runat="server" ShowMessageBox="True"
                                                                    ShowSummary="False" ValidationGroup="Controls1" />
                                                            </td>
                                                            <td align="center">&#160;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </telerik:RadPageView>
                                            </telerik:RadMultiPage>
                                        </td>
                                    </tr>
                                </table>
                            </telerik:RadPageView>
                        </telerik:RadMultiPage>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btn_Details_Edit" />
            <asp:PostBackTrigger ControlID="btn_Details_Save" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>