<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="EmployeeYearOfExperience.aspx.cs" Inherits="Reportss_EmployeeYearOfExperience" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">
        function ShowPop(ID, from, to) {
            var win = window.radopen('../Reportss/EmployeeYearOfExperienceReport.aspx?&BU=' + ID + '&FROM=' + from + '&TO=' + to, "RadWindow1");
            win.center();
            win.set_modal(true);
            win.set_title("Employee Year Of Experience Report");
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <br />
    <table align="center">
        <tr>
            <td colspan="5" align="center">
                <asp:Label ID="lbl_Header" runat="server" Text="Attendance Report" Font-Bold="True"
                    Font-Names="Arial" Font-Size="11pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_Organisation" runat="server" Text="Organisation"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_Organisation" runat="server" Enabled="false" MarkFirstMatch="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business Unit"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox EnableEmbeddedSkins="false" ID="ddl_BusinessUnit" MarkFirstMatch="true"
                    runat="server" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_BusinessUnit" runat="server" InitialValue="Select"
                    Text="*" ControlToValidate="ddl_BusinessUnit" ValidationGroup="Controls" ErrorMessage="Please Select Business Unit"></asp:RequiredFieldValidator>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblYearOfExperience" runat="server" Text="Year(s)&nbsp;Of&nbsp;Experience"
                    Font-Underline="true"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:Label ID="lblFrom" runat="server" Text="From"></asp:Label>&nbsp; <b>:</b>&nbsp;
                <telerik:RadNumericTextBox ID="rtxtFrom" runat="server" SkinID="EmpExp" MaxLength="4">
                </telerik:RadNumericTextBox>&nbsp;
                <asp:Label ID="lblTo" runat="server" Text="To"></asp:Label>&nbsp; <b>:</b>&nbsp;
                <telerik:RadNumericTextBox ID="rtxtTo" runat="server" SkinID="EmpExp" MaxLength="4">
                </telerik:RadNumericTextBox>&nbsp;
                <%--<telerik:RadTextBox ID="rtxtFrom" runat="server" SkinID="EmpExp">
                </telerik:RadTextBox>&nbsp;
                <asp:Label ID="lblTo" runat="server" Text="To"></asp:Label>&nbsp;
                <b>:</b>&nbsp;
                <telerik:RadTextBox ID="rtxtTo" runat="server" SkinID="EmpExp">
                </telerik:RadTextBox>&nbsp;
                <b>Years</b>--%>
            </td>
        </tr>
        <tr>
            <td colspan="5" align="center">
                <asp:Button ID="btnGenerate" runat="server" Text="Generate" OnClick="btnGenerate_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            </td>
        </tr>
    </table>
</asp:Content>