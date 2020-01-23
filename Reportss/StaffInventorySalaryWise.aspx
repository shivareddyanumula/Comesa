<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="StaffInventorySalaryWise.aspx.cs" Inherits="Reportss_StaffInventorySalaryWise" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function ShowPop(org, buid, derict, depart, rptName) {
            //debugger
            var win = window.radopen('../Reportss/StaffInventorySalaryWiseReport.aspx?OG=' + org + '&BU=' + buid + '&DER=' + derict + '&DEP=' + depart + '&rptName=' + rptName, "RadWindow1");
            //win.center();
            //win.set_modal(true);
            win.center();
            win.set_height("500");
            win.set_width("900");
            win.set_modal(true);
            win.set_title(rptName);
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <div>


        <table align="center">

            <tr>
                <td colspan="4" align="center">
                    <asp:Label ID="lbl_header" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="11pt"> </asp:Label><br />
                    <br />
                </td>
            </tr>

            <%-- <tr>
            <td>
                <asp:Label ID="lbl_Organisation" runat="server" Text="Organisation"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_Organisation" runat="server" Enabled="false" MarkFirstMatch="true">
                </telerik:RadComboBox>
            </td>
            <td>
            </td>
        </tr>--%>
            <tr>
                <td>
                    <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business Unit"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td>
                    <telerik:RadComboBox EnableEmbeddedSkins="false" ID="ddl_BusinessUnit" runat="server" AutoPostBack="True"
                        OnSelectedIndexChanged="ddl_BusinessUnit_SelectedIndexChanged" MarkFirstMatch="true" Filter="Contains">
                    </telerik:RadComboBox>



                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddl_BusinessUnit"
                        ErrorMessage="Please Select BusinessUnit" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>

                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_Directorate" runat="server" Text="Directorate"></asp:Label>
                </td>
                <td>:
                </td>
                <td>
                    <telerik:RadComboBox ID="rad_Directorate" AutoPostBack="true" runat="server" Skin="WebBlue" MaxLength="40" Filter="Contains"
                        EnableEmbeddedSkins="false" MarkFirstMatch="true" MaxHeight="120px" OnSelectedIndexChanged="rad_Directorate_SelectedIndexChanged">
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_Department" runat="server" Text="Department"></asp:Label>
                </td>
                <td>:</td>
                <td>
                    <telerik:RadComboBox EnableEmbeddedSkins="false" ID="rcm_Department" MarkFirstMatch="true"
                        runat="server" AutoPostBack="True" Filter="Contains">
                    </telerik:RadComboBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <%--   <tr>
            <td>
                <asp:Label ID="lbl_FromDate" runat="server" Text="From Date"></asp:Label>
            </td>
            <td>
                :</td>
            <td>
                <telerik:RadDatePicker ID="rd_FromDate" runat="server">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy"></DateInput>
                </telerik:RadDatePicker>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="rd_FromDate" ErrorMessage="Please select From Date" 
                    ValidationGroup="Controls">*</asp:RequiredFieldValidator>
             </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="lbl_ToDate" runat="server" Text="To Date"></asp:Label>
            </td>
            <td>
                :</td>
            <td>
               
                <telerik:RadDatePicker ID="rd_ToDate" runat="server">
                </telerik:RadDatePicker>
               
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="rd_ToDate" ErrorMessage="Please select To Date" 
            ValidationGroup="Controls">*</asp:RequiredFieldValidator>
             </td>
        </tr>--%>
            <tr>
                <td colspan="4" align="center">
                    <asp:Button ID="btn_Submit" runat="server" Text="Generate"
                        OnClick="btn_Submit_Click" ValidationGroup="Controls" />&nbsp;
                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel"
                    OnClick="btn_Cancel_Click" />
                </td>
                <td>
                    <asp:ValidationSummary ID="VS_EmpPapItems" runat="server" ShowMessageBox="true" ShowSummary="false"
                        ValidationGroup="Controls" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>