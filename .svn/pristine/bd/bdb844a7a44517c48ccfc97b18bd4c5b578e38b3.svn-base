<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="MonitoringEmployeePensionContribution.aspx.cs" Inherits="Reportss_MonitoringEmployeePensionContribution" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />

    <script type="text/javascript">
        function ShowPop(BU, Directorate, Department, SubDivision, emp, year, month) {
            var win = window.radopen('../Reportss/MonitoringEmployeePensionContributionReport.aspx?&BU=' + BU + '&EMP=' + emp + '&SubDivision=' + SubDivision + '&Directorate' + Directorate + '&Department=' + Department + '&year=' + year + '&month=' + month, "RadWindow1");
            win.center();
            win.set_modal(true);
            win.set_title("Employee Pension Details Reports");
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
    </script>
    <table align="center">
        <tr>
            <td align="center" colspan="3" style="font-weight: bold;">
                <asp:Label ID="label_Pension" runat="server" Text="Employee Pension Details Reports">
                </asp:Label>
            </td>
            <td align="center" style="font-weight: bold;">&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business Unit:"></asp:Label>
            </td>
            <td>:
            </td>
            <td>
                <telerik:RadComboBox ID="rad_BusinessUnit" runat="server" OnSelectedIndexChanged="rad_BusinessUnit_SelectedIndexChanged"
                    EnableEmbeddedSkins="false" MaxLength="50" TabIndex="2" AutoPostBack="True" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_BusinessUnit" runat="server" ControlToValidate="rad_BusinessUnit"
                    InitialValue="Select" ErrorMessage="Please Select Business Unit" ValidationGroup="Controls">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_Directorate" runat="server" Text="Directorate:"></asp:Label>
            </td>
            <td>:
            </td>
            <td>
                <telerik:RadComboBox ID="rad_Directorate" OnSelectedIndexChanged="rad_Directorate_SelectedIndexChanged" runat="server"
                    EnableEmbeddedSkins="false" AutoPostBack="True" MaxLength="50" TabIndex="2" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <%--     <td>
                                    <asp:RequiredFieldValidator ID="rfv_Directorate" runat="server" ControlToValidate="rad_Directorate"
                                        InitialValue="Select" ErrorMessage="Please Select Directorate" ValidationGroup="Controls">*</asp:RequiredFieldValidator></td>--%>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_Department" runat="server" Text="Department:"></asp:Label>
            </td>
            <td>:
            </td>
            <td>
                <telerik:RadComboBox ID="rad_Department" OnSelectedIndexChanged="rad_Department_SelectedIndexChanged" AutoPostBack="true" runat="server"
                    EnableEmbeddedSkins="false" MaxLength="50" TabIndex="2" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <%--   <td>
                                    <asp:RequiredFieldValidator ID="rfv_Department" runat="server" ControlToValidate="rad_Department"
                                        InitialValue="Select" ErrorMessage="Please Select Department" ValidationGroup="Controls">*</asp:RequiredFieldValidator></td>--%>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_SubDepartment" runat="server" Text="Sub Department"></asp:Label>
            </td>
            <td>:
            </td>
            <td>
                <telerik:RadComboBox ID="rad_SubDepartment" runat="server" Filter="Contains"
                    EnableEmbeddedSkins="false" OnSelectedIndexChanged="rad_SubDepartment_SelectedIndexChanged"
                    AutoPostBack="true" MaxLength="50" TabIndex="2">
                </telerik:RadComboBox>
            </td>
            <%--     <td>
                                    <asp:RequiredFieldValidator ID="rfv_SubDepartment" runat="server" ControlToValidate="rad_SubDepartment"
                                        InitialValue="Select" ErrorMessage="Please Select Sub Department" ValidationGroup="Controls">*</asp:RequiredFieldValidator></td>--%>
        </tr>



        <tr>
            <td>
                <asp:Label ID="lbl_EmployeeName" runat="server" Text="Employee"></asp:Label>
            </td>
            <td>:
            </td>
            <td>
                <telerik:RadComboBox ID="rad_Employee" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rad_Employee_SelectedIndexChanged"
                    AutoCompleteType="DisplayName" Skin="WebBlue" Height="51px" MaxLength="100" TextMode="MultiLine"
                    Width="143px" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_Employee" runat="server" ControlToValidate="rad_Employee"
                    InitialValue="Select" ErrorMessage="Please Select Employee" ValidationGroup="Controls">*</asp:RequiredFieldValidator></td>
        </tr>
        </tr>
                                   <tr>
                                       <td>
                                           <asp:Label ID="lbl_Year" runat="server" Text="Year"></asp:Label>
                                       </td>
                                       <td>
                                           <b>:</b>
                                       </td>
                                       <td>
                                           <telerik:RadComboBox ID="rcmb_Year" runat="server" AutoPostBack="true" Filter="Contains"
                                               MarkFirstMatch="true" OnSelectedIndexChanged="rcmb_Year_SelectedIndexChanged">
                                           </telerik:RadComboBox>
                                       </td>
                                       <%--  <td>
                                        <asp:RequiredFieldValidator ID="RFV_Year" runat="server" Text="*" Display="Dynamic"
                                            ErrorMessage="Please Select Year" ControlToValidate="rcmb_Year"
                                            InitialValue="Select" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                    </td>--%>
                                   </tr>
        <tr>

            <td>
                <asp:Label ID="lbl_Month" runat="server" Text="Month"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_Month" MarkFirstMatch="true" runat="server" AutoPostBack="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <%-- <asp:RequiredFieldValidator ID="RFV_Month" runat="server" Text="*" Display="Dynamic"
                                            ErrorMessage="Please Select Month" ControlToValidate="rcmb_Period" InitialValue="Select"
                                            ValidationGroup="Controls"></asp:RequiredFieldValidator>--%>
            </td>
        </tr>


        <tr>
            <td align="center" colspan="4">
                <asp:Button ID="lnk_View" OnClick="lnk_View_Click" ValidationGroup="Controls" runat="server" Text="ViewDetails"></asp:Button>
            </td>
        </tr>
    </table>
</asp:Content>