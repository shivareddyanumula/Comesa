<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_QuickPay.aspx.cs" Inherits="Payroll_frm_QuickPay" Culture="auto"
    meta:resourcekey="Page" UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <%--   <telerik:RadAjaxManagerProxy ID="RAM_BusinessUnit" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btn_Paytran">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddl_Period">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddl_PeriodElements">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddl_BusinessUnit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="chkSalary_List">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>--%>
    <table align="center" style="width: 70%">
        <tr>
            <td>
                <telerik:RadMultiPage ID="RMP_Main" runat="server" Width="990px" Height="490px" ScrollBars="Auto"
                    SelectedIndex="0" meta:resourcekey="RMP_Main">
                    <telerik:RadPageView ID="PayTran" runat="server" meta:resourcekey="PayTran" Selected="True">
                        <br />
                        <table align="center">
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Label ID="lbl_PayTran" runat="server" Font-Bold="True" Font-Underline="True"
                                        Text="Quick Pay Process" meta:resourcekey="lbl_PayTran"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table align="center">

                            <tr>
                                <td>
                                    <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business Unit" meta:resourcekey="lbl_BusinessUnit"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="ddl_BusinessUnit" runat="server" TabIndex="1" MaxHeight="120px" Filter="Contains"
                                        MarkFirstMatch="true" Skin="WebBlue" AutoPostBack="True" OnSelectedIndexChanged="ddl_BusinessUnit_SelectedIndexChanged"
                                        meta:resourcekey="ddl_BusinessUnit">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_ddl_BusinessUnit" runat="server" ControlToValidate="ddl_BusinessUnit" InitialValue="Select" ValidationGroup="Controls"
                                        ErrorMessage="Please Select Business Unit">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Period" runat="server" Text="Financial Period" meta:resourcekey="lbl_Period"></asp:Label>
                                </td>
                                <td>
                                    <b>: </b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="ddl_Period" runat="server" AutoPostBack="True" TabIndex="2" MaxHeight="120px"
                                        MarkFirstMatch="true" Skin="WebBlue" OnSelectedIndexChanged="ddl_Period_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_ddl_Period" runat="server" ControlToValidate="ddl_Period"
                                        InitialValue="Select" ErrorMessage="Please select Period" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_PeriodElements" runat="server" Text="Period Elements" meta:resourcekey="lbl_PeriodElements"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="ddl_PeriodElements" runat="server" TabIndex="3" MaxHeight="120px" Filter="Contains"
                                        MarkFirstMatch="true" Skin="WebBlue" AutoPostBack="True" meta:resourcekey="ddl_PeriodElements"
                                        OnSelectedIndexChanged="ddl_PeriodElements_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_ddl_Period0" runat="server" ControlToValidate="ddl_PeriodElements"
                                        InitialValue="Select" ErrorMessage="Please Select Period Elements" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>
                                <td colspan="4" align="center">
                                    <asp:Label ID="lbl_SalaryStruct" runat="server" meta:resourcekey="lbl_SalaryStruct"
                                        Text="Salary Structure"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:RadioButtonList ID="rbt_SalaryList" runat="server" AutoPostBack="true"
                                        RepeatColumns="2" TabIndex="4"
                                        ValidationGroup="Controls"
                                        OnSelectedIndexChanged="rbt_SalaryList_SelectedIndexChanged">
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rbt_SalaryList" runat="server" ControlToValidate="rbt_SalaryList"
                                        ErrorMessage="Please Select Salary Structure" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:Label ID="lbl_Employess" runat="server" meta:resourcekey="lbl_Employess" Text="List of Employees"></asp:Label>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="lbl_FromDate" runat="server" meta:resourcekey="lbl_FromDate" Text="From Date"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="rdtp_FromDate" runat="server" TabIndex="6" AutoPostBack="true"
                                        Skin="WebBlue" meta:resourcekey="rdtp_FromDate"
                                        OnSelectedDateChanged="rdtp_FromDate_SelectedDateChanged">
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rdtp_FromDate0" runat="server" ControlToValidate="rdtp_FromDate"
                                        ErrorMessage="Please select From Date" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_ToDate" runat="server" meta:resourcekey="lbl_ToDate" Text="To Date"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="rdtp_ToDate" runat="server" TabIndex="7" AutoPostBack="True"
                                        Skin="WebBlue" OnSelectedDateChanged="rdtp_ToDate_SelectedDateChanged">
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rdtp_ToDate" runat="server" ControlToValidate="rdtp_ToDate"
                                        ErrorMessage="Please Select ToDate" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="csv_rdtp_Todate" runat="server" ControlToCompare="rdtp_FromDate"
                                        ControlToValidate="rdtp_ToDate" ErrorMessage="To Date cannot be earlier than From date"
                                        Operator="GreaterThanEqual" ValidationGroup="Controls">*</asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Employee" runat="server" Text="Employees"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>&nbsp;
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="ddl_Employees" runat="server" MarkFirstMatch="true" TabIndex="8"
                                        Skin="WebBlue" meta:resourcekey="ddl_Employees" Height="250" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_ddl_Employees" runat="server" ControlToValidate="ddl_Employees" InitialValue="Select"
                                        ErrorMessage="Please Select Employees" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <table align="center">
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Button ID="btn_Paytran" TabIndex="9" runat="server" Text="Run Pay Transaction" OnClick="btn_Paytran_Click"
                                        meta:resourcekey="btn_Paytran" UseSubmitBehavior="false" OnClientClick="fnJSOnFormSubmit(this,'Controls')" />
                                </td>
                                <td></td>
                            </tr>
                        </table>
                        <br />
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="Vs_Summary" runat="server" ShowMessageBox="true" ShowSummary="false"
        ValidationGroup="Controls" />
</asp:Content>