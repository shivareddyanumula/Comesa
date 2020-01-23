<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_Retropay.aspx.cs" Inherits="Payroll_frm_Retropay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadAjaxPanel ID="RAP_Panel" runat="server">
        <table align="center">
            <tr>
                <td align="center">
                    <telerik:RadMultiPage ID="RMP_Main" runat="server" Width="1004px" SelectedIndex="0"
                        meta:resourcekey="RMP_MainResource1">
                        <telerik:RadPageView ID="PayTran" runat="server" Selected="True" meta:resourcekey="PayTranResource1">
                            <br />
                            <table align="center">
                                <tr>
                                    <td></td>
                                    <td>
                                        <asp:Label ID="lbl_PayTran" runat="server" Font-Bold="True" Font-Underline="True"
                                            Text="Retronbsp;Pay&nbsp;Transaction" meta:resourcekey="lbl_PayTran"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <table align="center">
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lbl_Period" runat="server" Text="Period" meta:resourcekey="lbl_Period"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <b>:</b>
                                    </td>
                                    <td align="left">
                                        <telerik:RadComboBox ID="ddl_Period" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_Period_SelectedIndexChanged"
                                            MarkFirstMatch="true" Skin="WebBlue" meta:resourcekey="ddl_PeriodResource1" Filter="Contains">
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
                                        <telerik:RadComboBox ID="ddl_PeriodElements" runat="server" Skin="WebBlue" Filter="Contains"
                                            MarkFirstMatch="true" meta:resourcekey="ddl_PeriodElementsResource1" AutoPostBack="True" OnSelectedIndexChanged="ddl_PeriodElements_SelectedIndexChanged">
                                        </telerik:RadComboBox>
                                    </td>
                                    <td align="left">
                                        <asp:RequiredFieldValidator ID="rfv_PeriodElements" runat="server" InitialValue="Select"
                                            Text="*" ControlToValidate="ddl_PeriodElements" ErrorMessage="Please Choose Period Elements"
                                            ValidationGroup="Controls" meta:resourcekey="rfv_PeriodElementsResource1"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business Unit" meta:resourcekey="lbl_BusinessUnit"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <b>:</b>
                                    </td>
                                    <td align="left">
                                        <telerik:RadComboBox ID="ddl_BusinessUnit" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_BusinessUnit_SelectedIndexChanged"
                                            MarkFirstMatch="true" Skin="WebBlue" meta:resourcekey="ddl_BusinessUnitResource1" Filter="Contains">
                                        </telerik:RadComboBox>
                                    </td>
                                    <td align="left">
                                        <asp:RequiredFieldValidator ID="rfv_BusinessUnit" runat="server" InitialValue="Select"
                                            Text="*" ControlToValidate="ddl_BusinessUnit" ErrorMessage="Please Choose Business Unit"
                                            ValidationGroup="Controls" meta:resourcekey="rfv_BusinessUnitResource1"></asp:RequiredFieldValidator>
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
                                        <asp:CheckBoxList ID="chkSalary_List" runat="server" RepeatColumns="3"
                                            RepeatDirection="Horizontal" meta:resourcekey="chkSalary_ListResource1">
                                        </asp:CheckBoxList>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <table align="center">
                                <tr>
                                    <td align="center">
                                        <asp:Button ID="btn_Paytran" runat="server" meta:resourcekey="btn_Paytran"
                                            OnClick="btn_Paytran_Click" ValidationGroup="Controls" />
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
    </telerik:RadAjaxPanel>
</asp:Content>