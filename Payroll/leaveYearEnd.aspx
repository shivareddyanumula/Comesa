<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="leaveYearEnd.aspx.cs" Inherits="Payroll_leaveYearEnd" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td>
                <telerik:RadMultiPage ID="RMP_YearEnd" runat="server" SelectedIndex="0">
                    <telerik:RadPageView ID="RPV_YearEnd" runat="server">
                        <table>
                            <tr>
                                <td colspan="4" style="text-align: center">
                                    <asp:Label ID="lbl_heade" runat="server" Text="Leave Year End Process"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_FromYear" runat="server" Text="From Year"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="ddl_FromYear" runat="server" Filter="Contains"
                                        AutoPostBack="True" OnSelectedIndexChanged="ddl_FromYear_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_From_year" runat="server" InitialValue="- Select -"
                                        ControlToValidate="ddl_FromYear" Text="*" Display="Dynamic" ValidationGroup="Controls"
                                        ErrorMessage="Please Select From Year"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_ToYear" runat="server" Text="To Year"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="ddl_ToYear" runat="server" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_To_year" runat="server" InitialValue="- Select -"
                                        ControlToValidate="ddl_ToYear" Text="*" Display="Dynamic" ValidationGroup="Controls"
                                        ErrorMessage="Please Select To Year"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td colspan="4" style="text-align: center">
                                    <asp:Button ID="btn_Process" runat="server" Text="Process" OnClick="btn_Process_Click"
                                        ValidationGroup="Controls" />
                                    &nbsp;<asp:Button ID="btn_Cancel" runat="server" Text="Cancel"
                                        OnClick="btn_Cancel_Click" />
                                </td>
                            </tr>
                        </table>
                        <asp:ValidationSummary ID="VS_Leave_Year_End_Proces" runat="server" ValidationGroup="Controls"
                            ShowMessageBox="true" ShowSummary="false" />
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>