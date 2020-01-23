<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_CopyTdsParams.aspx.cs" Inherits="Masters_frm_CopyTdsParams" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <%--<script type="text/javascript">
    function confirm() {
    if (confirm("Are you sure you want to copy ?")) {
       return true;
    }
    else {
       return false;
    }
}
</script>--%>

    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_Header" runat="server" Text="PAYE Params - Copy Previous Values" Font-Bold="true">
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table align="center">
                    <%--<tr>
                        <td>
                            <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business Unit">
                            </asp:Label>
                        </td>
                        <td>
                            <b>:</b>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="rcmb_BusinessUnit" runat="server" AutoPostBack="true">
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfv_BusinessUnit" runat="server" InitialValue="Select"
                                Text="*" ControlToValidate="rcmb_BusinessUnit" ValidationGroup="Controls" ErrorMessage="Select Business Unit">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>--%>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_tdsname" runat="server" Text="PAYE">
                            </asp:Label>
                        </td>
                        <td>
                            <b>:</b>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="rcmb_tdsname" runat="server" AutoPostBack="true" MarkFirstMatch="true" MaxHeight="120px" TabIndex="1" Filter="Contains">
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfv_rcmb_tdsname" runat="server" InitialValue="Select"
                                Text="*" ControlToValidate="rcmb_tdsname" ValidationGroup="Controls" ErrorMessage="Please Select PAYE">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_PreviousPeriod" runat="server" Text="Previous Period">
                            </asp:Label>
                        </td>
                        <td>
                            <b>:</b>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="rcmb_PreviousPeriod" runat="server" AutoPostBack="true" MarkFirstMatch="true" MaxHeight="120px" TabIndex="2" Filter="Contains">
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfv_PreviousPeriod" runat="server" InitialValue="Select"
                                Text="*" ControlToValidate="rcmb_PreviousPeriod" ValidationGroup="Controls" ErrorMessage="Please Select Previous Period">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_CurrentPeriod" runat="server" Text="Current Period">
                            </asp:Label>
                        </td>
                        <td>
                            <b>:</b>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="rcmb_CurrentPeriod" runat="server" AutoPostBack="true" MarkFirstMatch="true" MaxHeight="120px" TabIndex="3" Filter="Contains">
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfv_CurrentPeriod" runat="server" InitialValue="Select"
                                Text="*" ControlToValidate="rcmb_CurrentPeriod" ValidationGroup="Controls" ErrorMessage="Please Select Current Period">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Copy" runat="server" Text="COPY" OnClick="btn_Copy_Click" ValidationGroup="Controls" TabIndex="4" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="vs_CopyTdsParams" runat="server" ShowMessageBox="true"
        ShowSummary="false" ValidationGroup="Controls" />
</asp:Content>