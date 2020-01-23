<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_YearEndLeaveProcess.aspx.cs" Inherits="Payroll_frm_YearEndLeaveProcess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadAjaxManagerProxy runat="server" ID="RAM_Employee">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btn_LYEtran">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>

    <telerik:RadAjaxPanel ID="RAP_Panel" runat="server">
        <table align="center">
            <tr>
                <td align="center">
                    <telerik:RadMultiPage ID="RMP_Main" runat="server" Width="1004px" SelectedIndex="0"
                        meta:resourcekey="RMP_MainResource1">
                        <telerik:RadPageView ID="YEARENDPROCESS" runat="server" Selected="True" meta:resourcekey="PayTranResource1">
                            <br />
                            <table align="center">
                                <tr>
                                    <td></td>
                                    <td>
                                        <asp:Label ID="lbl_LeaveTran" runat="server" Font-Bold="True" Font-Underline="True"
                                            Text="Year End Transaction" meta:resourcekey="lbl_LeaveTran"></asp:Label>
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
                                        <telerik:RadTextBox ID="rtxt_Period" runat="server" meta:resourcekey="rtxt_Period" Enabled="false" Skin="WebBlue">
                                        </telerik:RadTextBox>
                                    </td>
                                    <td align="left">
                                        <asp:RequiredFieldValidator ID="rfv_Period" runat="server" InitialValue="Select"
                                            Text="*" ControlToValidate="rtxt_Period" ErrorMessage="Please Choose Period" ValidationGroup="Controls"
                                            meta:resourcekey="rfv_Period"></asp:RequiredFieldValidator>
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
                                        <telerik:RadComboBox ID="ddl_BusinessUnit" runat="server" Filter="Contains"
                                            MarkFirstMatch="true" Skin="WebBlue" meta:resourcekey="ddl_BusinessUnit">
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
                            <br />
                            <table align="center">
                                <tr>
                                    <td align="center" colspan="3">
                                        <asp:Button ID="btn_LYEtran" runat="server" meta:resourcekey="btn_LYEtran" Text="Process"
                                            ValidationGroup="Controls" OnClick="btn_LYEtran_Click" />
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