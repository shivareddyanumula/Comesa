<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="SmryRptByGndrFrTheMth.aspx.cs" Inherits="Reportss_New_Reports_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />

    <script type="text/javascript">
        function ShowPop(Org, BU, url, prddtl,sts) {

            var win = window.radopen('../NewReports/SmryRptByGndrFrTheMthReport.aspx?ORG=' + Org + '&BU=' + BU + '&PRD=' + url + '&PRDDTL=' + prddtl+'&sts='+sts, "RadWindow1");
            win.center();
            win.set_modal(true);
           ////// win.set_width("670");
            win.set_title("Summary Report By Gender For The Month");
          //////////////////  win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="lbl_header" runat="server" Text="Summary Report by Gender for the Month" Font-Bold="true"
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
                            <asp:Label ID="lblPeriod" runat="server" Text="Period"></asp:Label>
                        </td>
                        <td>
                            <b>:</b>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="rcmb_Period" runat="server" MarkFirstMatch="true" MaxHeight="120px" AutoPostBack="true"
                                OnSelectedIndexChanged="rcmb_Period_SelectedIndexChanged">
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvPeriod" runat="server" Text="*" InitialValue="Select"
                                ControlToValidate="rcmb_Period" ErrorMessage="Please Select Period" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_payperiod" runat="server" Text="Period Element"></asp:Label>
                        </td>
                        <td>
                            <b>:</b>
                        </td>
                        <td>
                            <telerik:RadComboBox EnableEmbeddedSkins="false" ID="rcmb_PeriodElements" runat="server"
                                Skin="WebBlue" AutoPostBack="True"
                                MarkFirstMatch="true" MaxHeight="120px">
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfv_paypriod" runat="server" InitialValue="Select"
                                ControlToValidate="rcmb_PeriodElements" ErrorMessage="Please select Period Element"
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
    <asp:ValidationSummary ID="vs_SmryRptByGndrFrTheMth" runat="server" ShowMessageBox="true" ShowSummary="false"
        ValidationGroup="Controls" />
</asp:Content>



