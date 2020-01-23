<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="Pms_EmpRating.aspx.cs" Inherits="Reportss_Pms_EmpRating" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">
        function ShowPop(ID, BU, SAL, STATUS) {
            var win = window.radopen('../Reportss/Pms_EmpRatingReport.aspx?ORG_ID=' + ID + '&BU=' + BU + '&AppCycle=' + SAL + '&Status=' + STATUS, "RadWindow1");
            win.center();
            win.set_modal(true);
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="lbl_header" runat="server" Text="Employee Rating Details" Font-Bold="true"
                    Font-Size="11pt" Font-Names="Arial"> </asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_Organisation" runat="server" Text="Organisation">
                </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_Organisation" runat="server" MarkFirstMatch="true"
                    AutoPostBack="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_Organisation" runat="server" InitialValue="Select"
                    Text="*" ControlToValidate="rcmb_Organisation" ValidationGroup="Controls" ErrorMessage="Select Organisation">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business Unit"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_BusinessUnit" runat="server" MarkFirstMatch="true" Filter="Contains"
                    MaxHeight="120px" AutoPostBack="true" OnSelectedIndexChanged="rcmb_BusinessUnit_SelectedIndexChanged">
                </telerik:RadComboBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_AppCycle" runat="server" Text="Appraisal Cycle"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_AppCycle" runat="server" MarkFirstMatch="true" MaxHeight="120px"
                    AutoPostBack="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_Status" runat="server" Text="Status"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_Status" runat="server" MarkFirstMatch="true">
                    <Items>
                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="Select" Value="0" />
                        <telerik:RadComboBoxItem runat="server" Text="Completed" Value="1" />
                        <telerik:RadComboBoxItem runat="server" Text="Not Completed" Value="2" />
                    </Items>
                </telerik:RadComboBox>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="Select"
                        Text="*" ControlToValidate="rcmb_Status" ValidationGroup="Controls" ErrorMessage="Please Select Status">
                    </asp:RequiredFieldValidator>
                </td>
            </td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
    </table>
    <table align="center">
        <tr>
            <td align="center">
                <asp:Button ID="btn_Generate" runat="server" Text="Generate" OnClick="btn_Generate_Click"
                    ValidationGroup="Controls" />
            </td>
            <td>
                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="vs_EmployeeDetails" runat="server" ShowMessageBox="true"
        ShowSummary="false" ValidationGroup="Controls" />
</asp:Content>