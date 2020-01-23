<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frmEmployeePensionComputations.aspx.cs" Inherits="HR_frmEmployeePensionComputations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        function ShowPop(EMP_ID) {
            var win = window.radopen('../Reportss/frmEmployeePensionComputationsReport.aspx?EMP_ID=' + EMP_ID, "RadWindow1");
            win.center();
            win.set_modal(true);
            win.set_title("Pension and Life Benefits Report");
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
    </script>

    <table align="center">
        <tr>
            <td align="center" colspan="3" style="font-weight: bold;">
                <asp:Label ID="lbl_EmpResgDetails" runat="server" Text="Pension Computation"></asp:Label>
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
            <%-- <td>
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
            <%--                                <td>
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
                    EnableEmbeddedSkins="false" OnSelectedIndexChanged="rad_SubDepartment_SelectedIndexChanged" AutoPostBack="true" MaxLength="50" TabIndex="2">
                </telerik:RadComboBox>
            </td>
            <%--    <td>
                                    <asp:RequiredFieldValidator ID="rfv_SubDepartment" runat="server" ControlToValidate="rad_SubDepartment"
                                        InitialValue="Select" ErrorMessage="Please Select Sub Department" ValidationGroup="Controls">*</asp:RequiredFieldValidator></td>
            --%>
        </tr>



        <tr>
            <td>
                <asp:Label ID="lbl_EmployeeName" runat="server" Text="Employee"></asp:Label>
            </td>
            <td>:
            </td>
            <td>
                <telerik:RadComboBox ID="rad_Employee" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rad_Employee_SelectedIndexChanged"
                    AutoCompleteType="DisplayName" Skin="WebBlue" Height="51px" MaxLength="50" TextMode="MultiLine" Filter="Contains"
                    Width="143px">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_Employee" runat="server" ControlToValidate="rad_Employee"
                    InitialValue="Select" ErrorMessage="Please Select Employee" ValidationGroup="Controls">*</asp:RequiredFieldValidator></td>


        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_DOB" runat="server" Text="Date Of Birth"></asp:Label>
            </td>
            <td>:
            </td>
            <td>
                <telerik:RadDatePicker ID="rdp_DOB" runat="server"
                    Skin="WebBlue">
                    <Calendar Skin="WebBlue" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                        ViewSelectorText="x">
                    </Calendar>
                    <DatePopupButton Skin="WebBlue" HoverImageUrl="" ImageUrl="" />
                </telerik:RadDatePicker>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_DOJ" runat="server" Text="Date Of Joining"></asp:Label>
            </td>
            <td>:
            </td>
            <td>
                <telerik:RadDatePicker ID="rdp_DOJ" runat="server"
                    Skin="WebBlue">
                    <Calendar Skin="WebBlue" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                        ViewSelectorText="x">
                    </Calendar>
                    <DatePopupButton Skin="WebBlue" HoverImageUrl="" ImageUrl="" />
                </telerik:RadDatePicker>
            </td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_Age" runat="server" Text="Age"></asp:Label>
            </td>
            <td>:
            </td>
            <td>
                <telerik:RadTextBox ID="rad_Age" runat="server"
                    AutoCompleteType="DisplayName" Skin="WebBlue" Height="51px" TextMode="MultiLine">
                </telerik:RadTextBox>
            </td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btn_CalculatePension" OnClick="btn_CalculatePension_Click" ValidationGroup="Controls" runat="server" Text="Calculate Pension"></asp:Button>
            </td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <div id="pnl_CalculatePension" runat="server" visible="false">
            <tr>
                <td>

                    <asp:Label ID="lbl_Category" runat="server" Text="Category"></asp:Label>
                </td>

                <td>:
                </td>
                <td>
                    <asp:TextBox Skin="WebBlue" MaxLength="300" Width="200px" ID="txt_Category" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_Pension" runat="server" Text="Pension"></asp:Label>
                </td>


                <td>:
                </td>
                <td>
                    <asp:TextBox Skin="WebBlue" MaxLength="300" Width="200px" ID="txt_Pension" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btn_ViewDetails" runat="server" Text="Details" OnClick="btn_ViewDetails_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_lifeBenefit" runat="server" Text="Life Benefit"></asp:Label>
                </td>

                <td>:
                </td>
                <td>
                    <asp:TextBox Skin="WebBlue" MaxLength="300" Width="200px" ID="txt_lifeBenefit" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_Total" runat="server" Text="Total"></asp:Label>
                </td>

                <td>:
                </td>
                <td>
                    <asp:TextBox Skin="WebBlue" MaxLength="300" Width="200px" ID="txt_Total" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td></td>
            </tr>
        </div>
        <tr>
            <td align="center" colspan="4">

                <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel"
                    Text="Cancel" />
                <asp:ValidationSummary ID="vs_WHours" runat="server" ShowMessageBox="True" ShowSummary="False"
                    ValidationGroup="Controls" />
            </td>
        </tr>
    </table>
</asp:Content>