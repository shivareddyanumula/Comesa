<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_PayrollTrans.aspx.cs" Inherits="Payroll_frm_PayrollTrans" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <%-- <telerik:RadAjaxManagerProxy runat="server" ID="RAM_Employee">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btn_Paytran">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>--%>
    <table align="center">
        <tr>
            <td align="center">
                <telerik:RadMultiPage ID="RMP_Main" runat="server" Width="980px" SelectedIndex="0"
                    meta:resourcekey="RMP_MainResource1">
                    <telerik:RadPageView ID="PayTran" runat="server" Selected="True" meta:resourcekey="PayTranResource1">
                        <br />
                        <table align="center">
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Label ID="lbl_PayTran" runat="server" Font-Bold="True" Font-Underline="True"
                                        Text="Payroll&amp;nbsp;Transaction" meta:resourcekey="lbl_PayTran"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table align="center">

                            <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business Unit" meta:resourcekey="lbl_BusinessUnit"></asp:Label>
                                </td>
                                <td align="left">
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="ddl_BusinessUnit" runat="server" Filter="Contains"
                                        MarkFirstMatch="true" AutoPostBack="True" OnSelectedIndexChanged="ddl_BusinessUnit_SelectedIndexChanged"
                                        Skin="WebBlue" meta:resourcekey="ddl_BusinessUnitResource1">
                                    </telerik:RadComboBox>
                                </td>
                                <td align="left">
                                    <asp:RequiredFieldValidator ID="rfv_BusinessUnit" runat="server" InitialValue="Select"
                                        Text="*" ControlToValidate="ddl_BusinessUnit" ErrorMessage="Please Choose Business Unit"
                                        ValidationGroup="Controls" meta:resourcekey="rfv_BusinessUnitResource1"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_Period" runat="server" Text="Financial Period" meta:resourcekey="lbl_Period"></asp:Label>
                                </td>
                                <td align="left">
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="ddl_Period" runat="server" AutoPostBack="True" Filter="Contains"
                                        MarkFirstMatch="true" OnSelectedIndexChanged="ddl_Period_SelectedIndexChanged" Skin="WebBlue" meta:resourcekey="ddl_PeriodResource1">
                                    </telerik:RadComboBox>
                                </td>
                                <td align="left">
                                    <asp:RequiredFieldValidator ID="rfv_Period" runat="server" InitialValue="Select"
                                        Text="*" ControlToValidate="ddl_Period" ErrorMessage="Please Choose Period" ValidationGroup="Controls"
                                        meta:resourcekey="rfv_PeriodResource1"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_PeriodElements" runat="server" Text="Period Elements" meta:resourcekey="lbl_PeriodElements"></asp:Label>
                                </td>
                                <td align="left">
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="ddl_PeriodElements" runat="server" Filter="Contains"
                                        MarkFirstMatch="true" Skin="WebBlue" meta:resourcekey="ddl_PeriodElementsResource1" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddl_PeriodElements_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td align="left">
                                    <asp:RequiredFieldValidator ID="rfv_PeriodElements" runat="server" InitialValue="Select"
                                        Text="*" ControlToValidate="ddl_PeriodElements" ErrorMessage="Please Choose Period Elements"
                                        ValidationGroup="Controls" meta:resourcekey="rfv_PeriodElementsResource1"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table align="center">
                            <tr>
                                <td rowspan="1" align="center">
                                    <asp:Label ID="lbl_SalaryStruct" runat="server" meta:resourcekey="lbl_SalaryStruct"
                                        Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBoxList ID="chkSalary_List" runat="server" RepeatColumns="3" OnSelectedIndexChanged="chkSalary_List_SelectedIndexChanged"
                                        RepeatDirection="Horizontal" meta:resourcekey="chkSalary_ListResource1">
                                    </asp:CheckBoxList>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table align="center">
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="lbl_Employess" runat="server" Visible="False" meta:resourcekey="lbl_Employess"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Button ID="btn_Paytran" runat="server" meta:resourcekey="btn_Paytran" OnClick="btn_Paytran_Click"
                                        ValidationGroup="Controls" />
                                </td>
                            </tr>
                        </table>
                        <br />
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
    <asp:ValidationSummary runat="server" ID="vs_Summary" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="Controls" meta:resourcekey="vs_SummaryResource1" />
</asp:Content>