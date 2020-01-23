﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="EmployeeList.aspx.cs" Inherits="Reportss_EmployeeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">
        function ShowPop(ID, BU, SAL, EMPTYPE, RPTNAME) {

            var win = window.radopen('../Reportss/EmployeeListReport.aspx?ORG_ID=' + ID + '&BU=' + BU + '&SAL=' + SAL + '&EMPTYPE=' + EMPTYPE + '&RPTNAME=' + RPTNAME, "RadWindow1");
            win.center();
            win.set_modal(true);

            if (RPTNAME == "1") {
                win.set_title("List Of Staff");
            }
            else if (RPTNAME == "2") {
                win.set_title("List Of Members");
            }
            else if (RPTNAME == "14") {
                win.set_title("Employee Type");
            }

            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
        function ShowPopC(ID, BU, CTY, RPTNAME) {

            var win = window.radopen('../Reportss/EmployeeListReport.aspx?ORG_ID=' + ID + '&BU=' + BU + '&CTY=' + CTY + '&RPTNAME=' + RPTNAME, "RadWindow1");
            win.center();
            win.set_modal(true);

            win.set_title("Employee List by District");
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
        function ShowPopE(ID, BU, SAL, RPTNAME) {

            var win = window.radopen('../Reportss/EmployeeListReport.aspx?ORG_ID=' + ID + '&BU=' + BU + '&SAL=' + SAL + '&RPTNAME=' + RPTNAME, "RadWindow1");
            win.center();
            win.set_modal(true);

            if (RPTNAME == "3") {
                win.set_title("Employee On Disability Tax Exemption");
            }
            else {
                win.set_title("Employee List by Service");
            }

            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
        function ShowPopEC(ID, BU, RPTNAME) {

            var win = window.radopen('../Reportss/EmployeeListReport.aspx?ORG_ID=' + ID + '&BU=' + BU + '&RPTNAME=' + RPTNAME, "RadWindow1");
            win.center();
            win.set_modal(true);
            if (RPTNAME == "6") {
                win.set_title("Transfer Due by Cash");
            }
            if (RPTNAME == "12") {
                win.set_title("Employee House Allowance");
            }
            if (RPTNAME == "13") {
                win.set_title("Allocation Code");
            }
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
        function ShowPopA(ID, BU, FRM, TO, RPTNAME) {

            var win = window.radopen('../Reportss/EmployeeListReport.aspx?ORG_ID=' + ID + '&BU=' + BU + '&FRM=' + FRM + '&TO=' + TO + '&RPTNAME=' + RPTNAME, "RadWindow1");
            win.center();
            win.set_modal(true);

            win.set_title("Employee List by Age");

            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
        function ShowPopT(ID, BU, TRB, RPTNAME) {

            var win = window.radopen('../Reportss/EmployeeListReport.aspx?ORG_ID=' + ID + '&BU=' + BU + '&TRB=' + TRB + '&RPTNAME=' + RPTNAME, "RadWindow1");
            win.center();
            win.set_modal(true);

            win.set_title("Employee List by Ethnicity");
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }

        function ShowPopl(ID, BU, CTRL, RPTNAME) {

            var win = window.radopen('../Reportss/EmployeeListReport.aspx?ORG_ID=' + ID + '&BU=' + BU + '&CTRL=' + CTRL + '&RPTNAME=' + RPTNAME, "RadWindow1");
            win.center();
            win.set_modal(true);

            win.set_title("Employee List");
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
        function ShowPopDI(ID, BU, DI, CTRL, RPTNAME) {

            var win = window.radopen('../Reportss/EmployeeListReport.aspx?ORG_ID=' + ID + '&BU=' + BU + '&DI=' + DI + '&CTRL=' + CTRL + '&RPTNAME=' + RPTNAME, "RadWindow1");
            win.center();
            win.set_modal(true);


            win.set_title("Employee List by Directorate");


            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
        function ShowPopDE(ID, BU, DI, DE, RPTNAME) {

            var win = window.radopen('../Reportss/EmployeeListReport.aspx?ORG_ID=' + ID + '&BU=' + BU + '&DI=' + DI + '&DE=' + DE + '&RPTNAME=' + RPTNAME, "RadWindow1");
            win.center();
            win.set_modal(true);

            win.set_title("Employee List by Department");

            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }


        function KeyPress(sender, args) {
            if (args.get_keyCharacter() == sender.get_numberFormat().DecimalSeparator) {
                args.set_cancel(true);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <br />
    <table align="center">
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="lbl_header" runat="server" Font-Bold="true" Font-Size="11pt" Font-Names="Arial"> </asp:Label>
                <br />
                <br />
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
                <telerik:RadComboBox ID="rcmb_BusinessUnit" runat="server" MarkFirstMatch="true" MaxHeight="120px"
                    AutoPostBack="true" OnSelectedIndexChanged="rcmb_BusinessUnit_SelectedIndexChanged" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_BusinessUnit" runat="server" ErrorMessage="Please Select Business Unit"
                    ControlToValidate="rcmb_BusinessUnit" ValidationGroup="Controls" InitialValue="Select" ForeColor="Red" Text="*">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr id="trPaymentmode" runat="server" visible="false">
            <td>
                <asp:Label ID="lbl_PaymentMode" runat="server" Text="Payment Mode"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>

            <td>
                <telerik:RadComboBox ID="rcmb_PaymentMode" runat="server" MaxHeight="120px" Enabled="false" TabIndex="25">
                    <Items>
                        <telerik:RadComboBoxItem runat="server" Selected="true" Text="Cash" Value="0" />
                    </Items>
                </telerik:RadComboBox>
            </td>
            <td></td>
        </tr>

        <tr id="trDirectorate" runat="server" visible="false">
            <td>
                <asp:Label ID="lbl_Directorate" runat="server" Text="Directorate"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>

            <td>
                <telerik:RadComboBox ID="rcmb_Directorate" runat="server" MarkFirstMatch="true" MaxHeight="120px"
                    AutoPostBack="true" OnSelectedIndexChanged="rcmb_Directorate_SelectedIndexChanged" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfDirectorate" runat="server" ErrorMessage="Please Select Directorate"
                    ControlToValidate="rcmb_Directorate" ValidationGroup="Controls" InitialValue="Select" ForeColor="Red" Text="*">
                </asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr id="trDepartment" runat="server" visible="false">
            <td>
                <asp:Label ID="lbl_Department" runat="server" Text="Department"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>

            <td>
                <telerik:RadComboBox ID="rcmb_Department" runat="server" MarkFirstMatch="true" MaxHeight="120px"
                    AutoPostBack="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvDepartment" runat="server" ErrorMessage="Please Select Department"
                    ControlToValidate="rcmb_Department" ValidationGroup="Controls" InitialValue="Select" ForeColor="Red" Text="*">
                </asp:RequiredFieldValidator>

            </td>
        </tr>

        <tr id="trSalStruct" runat="server" visible="false">
            <td>
                <asp:Label ID="lbl_SalStruct" runat="server" Text="Salary Structure"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>

            <td>
                <telerik:RadComboBox ID="rcmb_SalStruct" runat="server" MarkFirstMatch="true" MaxHeight="120px"
                    AutoPostBack="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_SalStruct" runat="server" ErrorMessage="Please Select Salary Structure"
                    ControlToValidate="rcmb_SalStruct" ValidationGroup="Controls" InitialValue="Select" ForeColor="Red" Text="*">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr id="trEmployeeType" runat="server" visible="false">
            <td>
                <asp:Label ID="lbl_employeetype" runat="server" Text="Employee Type"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>

            <td>
                <telerik:RadComboBox ID="ddl_EmpStatus" runat="server" MaxHeight="120px" AutoPostBack="True"
                    MarkFirstMatch="true">
                    <%--<Items>
                        <telerik:RadComboBoxItem runat="server" Selected="true" Text="All" Value="-1" />
                        <telerik:RadComboBoxItem runat="server" Text="Permanent and Pensionable" Value="1" />
                        <telerik:RadComboBoxItem runat="server" Text="Contract" Value="2" />
                    </Items>--%>
                </telerik:RadComboBox>
            </td>
            <td></td>
        </tr>


        <tr id="trCounty" runat="server" visible="false">
            <td>
                <asp:Label ID="lbl_County" runat="server" Text="District"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>

            <td>
                <telerik:RadComboBox ID="rcmb_County" runat="server" MarkFirstMatch="true" MaxHeight="120px"
                    AutoPostBack="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>

            <td>
                <asp:RequiredFieldValidator ID="rfv_County" runat="server" ErrorMessage="Please Select County"
                    ControlToValidate="rcmb_County" ValidationGroup="Controls" InitialValue="Select" ForeColor="Red" Text="*">
                </asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr id="trTribe" runat="server" visible="false">
            <td>
                <asp:Label ID="lbl_Tribe" runat="server" Text="Tribe"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>

            <td>
                <telerik:RadComboBox ID="rcmb_Tribe" runat="server" MarkFirstMatch="true" MaxHeight="120px"
                    AutoPostBack="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvTribe" runat="server" ErrorMessage="Please Select Tribe"
                    ControlToValidate="rcmb_Tribe" ValidationGroup="Controls" InitialValue="Select" ForeColor="Red" Text="*">
                </asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr id="trAgeRange" runat="server" visible="false">
            <td>
                <asp:Label ID="lbl_AgeRange" runat="server" Font-Bold="true" Font-Size="11pt" Font-Names="Arial" Text="Age Range:"> </asp:Label>
            </td>
            <td>
                <b></b>
            </td>

            <td></td>
            <td></td>
        </tr>
        <tr id="trFrom" runat="server" visible="false">
            <td>
                <asp:Label ID="lbl_From" runat="server" Text="From"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>

            <td>
                <telerik:RadNumericTextBox ID="txt_From" MaxHeight="200px" runat="server" Width="190px" NumberFormat-DecimalDigits="0" autocomplete="off" MaxLength="2" MinValue="0" AllowRounding="false" KeepNotRoundedValue="true">
                    <ClientEvents OnKeyPress="KeyPress" />
                    <%--<NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>--%>
                </telerik:RadNumericTextBox>
            </td>
            <td></td>
        </tr>
        <tr id="trTo" runat="server" visible="false">
            <td>
                <asp:Label ID="lbl_To" runat="server" Text="To"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>

            <td>

                <telerik:RadNumericTextBox ID="txt_To" MaxHeight="200px" runat="server" Width="190px" autocomplete="off" MaxLength="2" NumberFormat-DecimalDigits="0" MinValue="0" AllowRounding="false" KeepNotRoundedValue="true">
                    <ClientEvents OnKeyPress="KeyPress" />
                    <%-- <NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>--%>
                </telerik:RadNumericTextBox>
            </td>
            <td>
                <%-- <asp:CompareValidator ID="CompareValidator" runat="server" ErrorMessage="" 
                    ControlToValidate="txt_To" ControlToCompare="txt_From" Operator="GreaterThanEqual"  ValidationGroup="Controls"></asp:CompareValidator>     
                --%>
            </td>
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