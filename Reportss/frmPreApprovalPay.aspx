<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frmPreApprovalPay.aspx.cs" Inherits="Reportss_frmPreApprovalPay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            function ShowPop_Pending(url, ID, BU, prddtl, paytran, Localisation) {
            ////function ShowPop_Pending(url, ID, BU, prddtl, paytran) {
                var win = window.radopen('../Reportss/PreApprovalPayRegisterReport.aspx?PRD=' + url + '&ORG=' + ID + '&BU=' + BU + '&PRDDTL=' + prddtl + '&PAYTRAN=' + paytran + '&Localisation=' + Localisation, "RadWindow1");
               //// var win = window.radopen('../Reportss/frmPreApprovalPayReport.aspx?PRD=' + url + '&ORG=' + ID + '&BU=' + BU + '&PRDDTL=' + prddtl + '&PAYTRAN=' + paytran, "RadWindow1");
                win.center();
                win.set_modal(true);
                win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
            }
        </script>
    </telerik:RadScriptBlock>

    <br />
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_PayTransact" runat="server" Text="Pre-Approval Pay Report" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <%--<telerik:RadMultiPage ID="Rm_CY_page" runat="server" SelectedIndex="0" Width="990px"
                    Height="490px" ScrollBars="Auto" meta:resourcekey="Rm_CY_page">
                    <telerik:RadPageView ID="Rp_CY_ViewMain" runat="server" meta:resourcekey="Rp_CY_ViewMain"
                        Selected="True">--%>
                <table>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business Unit"></asp:Label>
                        </td>
                        <td>
                            <b>:</b>
                        </td>
                        <td align="left">
                            <telerik:RadComboBox ID="rcmb_BUI" runat="server" AutoPostBack="true" MarkFirstMatch="true" OnSelectedIndexChanged="rcmb_BUI_SelectedIndexChanged" Skin="WebBlue" MaxHeight="120px" Filter="Contains">
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfv_rcmb_BUI" runat="server" ControlToValidate="rcmb_BUI" InitialValue="Select"
                                ErrorMessage="Please Select Business Unit" ValidationGroup="Controls" Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lbl_PeriodMaster" runat="server" Text="Period"></asp:Label>
                        </td>
                        <td>
                            <b>:</b>
                        </td>
                        <td align="left">
                            <telerik:RadComboBox ID="rcmb_PeriodMaster" runat="server" AutoPostBack="True" Filter="Contains"
                                MarkFirstMatch="true" OnSelectedIndexChanged="rcmb_PeriodMaster_SelectedIndexChanged" Skin="WebBlue" MaxHeight="120px">
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfv_rcmb_PeriodMaster" runat="server" ControlToValidate="rcmb_PeriodMaster" InitialValue="Select"
                                ErrorMessage="Please Select Period" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lbl_PeriodElement" runat="server" meta:resourcekey="lbl_PeriodElement"
                                Text="Period Element"></asp:Label>
                        </td>
                        <td>
                            <b>:</b>
                        </td>
                        <td align="left">
                            <telerik:RadComboBox ID="rcmb_PeriodElement" runat="server" AutoPostBack="True" MarkFirstMatch="true" OnSelectedIndexChanged="rcmb_PeriodElement_SelectedIndexChanged" Skin="WebBlue" MaxHeight="120px" Filter="Contains">
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfv_rcmb_PeriodElement" runat="server" ControlToValidate="rcmb_PeriodElement" InitialValue="Select"
                                ErrorMessage="Please Select Period Element" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <%-- <tr>
                        <td align="left">
                            <asp:Label ID="lbl_PeriodStatus" runat="server" meta:resourcekey="lbl_PeriodStatus"
                                Text="Status"></asp:Label>
                        </td>
                        <td>
                            <b>:</b>
                        </td>
                        <td align="left">
                            <telerik:RadComboBox ID="rcmb_PeriodStatus" runat="server" AutoPostBack="True"
                                MarkFirstMatch="true"  Skin="WebBlue" MaxHeight="120px">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Text="Select" Value="0" />
                                    <telerik:RadComboBoxItem runat="server" Text="Pending" Value="3" />
                                    <telerik:RadComboBoxItem runat="server" Text="Rejected" Value="2" />
                                    <telerik:RadComboBoxItem runat="server" Text="Approved" Value="1" />
                                </Items>
                            </telerik:RadComboBox>
                        </td>
                        <td></td>
                    </tr>--%>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_Trasaction" runat="server" Text="Transaction"></asp:Label>
                        </td>
                        <td>
                            <b>:</b>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="rcb_Transaction" runat="server" AutoPostBack="True" MarkFirstMatch="true" Skin="WebBlue" Filter="Contains">
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfv_rcb_Transaction" runat="server" ControlToValidate="rcb_Transaction" InitialValue="Select"
                                ErrorMessage="Please Select Transaction" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <%--<td align="center" colspan="4">
                            <asp:LinkButton ID="lnk" runat="server" OnClick="lnk_Click" Text="Click here to see Pre-Payroll Approval Details" Visible="false"></asp:LinkButton>
                            <br />
                            <asp:LinkButton ID="lnk_Approved" runat="server"
                                Text="Click here to see Post-Payroll Approval Details" Visible="false"
                                OnClick="lnk_Approved_Click"></asp:LinkButton>
                        </td>--%>
                        <td align="center" colspan="4">
                            <br />
                            <asp:Button ID="btnGenerate" runat="server" Text="Generate" OnClick="btnGenerate_Click" ValidationGroup="Controls" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                </table>

                <%-- </telerik:RadPageView>
                </telerik:RadMultiPage>--%>
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="vs_Summary" runat="server" ValidationGroup="Controls" ShowMessageBox="true" ShowSummary="false" />
</asp:Content>