<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="EmpLeaveStmt.aspx.cs" Inherits="Reportss_New_Reports_EmpLeaveStmt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />

    <script type="text/javascript">
        function ShowPop(Org, BU, Emp, FD, ED,sts) {

            var win = window.radopen('../NewReports/EmpLeaveStmtReport.aspx?Org=' + Org + '&BU=' + BU + '&Emp=' + Emp + '&FD=' + FD + '&ED=' + ED+'&sts='+sts, "RadWindow1");
            win.center();
            win.set_modal(true);
            //win.set_width("670");
            win.set_title("Employee Leave Statement");
            /////////////win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="lbl_header" runat="server" Text="Employee Leave Statement" Font-Bold="true"
                    Font-Size="11pt" Font-Names="Arial"> </asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table align="center">
                    <%--style="width: 32%;"--%>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_Org" runat="server" Text="Organisation"></asp:Label>
                        </td>
                        <td>
                            <b>:</b>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="rcmb_Org" runat="server" MarkFirstMatch="true" MaxHeight="120px" Enabled="false">
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblBU" runat="server" Text="Business Unit"></asp:Label>
                        </td>
                        <td>
                            <b>:</b>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="rcmb_BU" runat="server" MarkFirstMatch="true" MaxHeight="120px" AutoPostBack="true" OnSelectedIndexChanged="rcmb_BU_SelectedIndexChanged">
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfv_rcmb_BU" runat="server" Text="*" InitialValue="Select"
                                ControlToValidate="rcmb_BU" ErrorMessage="Please Select Business Unit" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblEmp" runat="server" Text="Employee"></asp:Label>
                        </td>
                        <td>
                            <b>:</b>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="rcmb_Emp" runat="server" MarkFirstMatch="true" EnableEmbeddedScripts="false" MaxHeight="120px" AutoPostBack="true">
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfv_rcmb_Emp" runat="server" Text="*" InitialValue="Select"
                                ControlToValidate="rcmb_Emp" ErrorMessage="Please Select Employee" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_frmdate" runat="server" Text="From Date"> </asp:Label></td>
                        <td><strong>:</strong></td>
                        <td>
                            <telerik:RadDatePicker ID="rdt_FromDate" runat="server" AutoPostBack="true" OnSelectedDateChanged="rdt_FromDate_SelectedDateChanged">
                            </telerik:RadDatePicker>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfv_rdpStartDate" runat="server" ControlToValidate="rdt_FromDate"
                                ErrorMessage="Please Select From Date"
                                ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_enddate" runat="server" Text="End Date"> </asp:Label>
                        </td>
                        <td><strong>:</strong>
                        </td>
                        <td>
                            <telerik:RadDatePicker ID="rdt_Enddate" runat="server">
                            </telerik:RadDatePicker>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfv_rdpEndDate" runat="server" ControlToValidate="rdt_Enddate"
                                ErrorMessage="Please Select End Date"
                                ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>

                     <tr>
            <td>
                <asp:Label ID="lblStatus" runat="server" Text="Status">
                </asp:Label>
            </td>
            <td>
                <asp:Label ID="lbl" runat="server" Text=":" Font-Bold="true"></asp:Label>
            </td>
            <td>
                <telerik:RadComboBox ID="rcbStatus" runat="server" MarkFirstMatch="true" MaxHeight="200">
                    <Items>
                        <telerik:RadComboBoxItem Text="Select" Value="-1" />
                        <telerik:RadComboBoxItem Text="Approved" Value="1" />
                        <telerik:RadComboBoxItem Text="Pending" Value="0" />
                    </Items>
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvStatus" runat="server" Text="*" InitialValue="Select"
                    ControlToValidate="rcbStatus" ValidationGroup="Controls" ErrorMessage="Please Select Status">
                </asp:RequiredFieldValidator>
            </td>
        </tr>


                    <tr id="tr_Employee1" runat="server">
                        <td colspan="4" style="text-align: center">
                            <br />
                            <asp:Button ID="btn_Submit" runat="server" Text="Generate" OnClick="btn_Submit_Click"
                                ValidationGroup="Controls" />
                            &nbsp;<asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
                            <br />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="vs_EmpLeaveStmt" runat="server" ShowMessageBox="true" ShowSummary="false"
        ValidationGroup="Controls" />
</asp:Content>

