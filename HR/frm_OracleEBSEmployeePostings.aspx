<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_OracleEBSEmployeePostings.aspx.cs" MasterPageFile="~/SMHRMaster.master" Inherits="HR_Oracle_EBS_Employee_Postings" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">
        function ShowPop() {
            var win = window.radopen('../HR/XML.aspx', "RW_XML");
            win.center();
            win.set_modal(true);
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td>
                <telerik:RadMultiPage ID="RMP_Employees" runat="server" SelectedIndex="0">
                    <telerik:RadPageView ID="RPV_Employees" runat="server">
                        <table align="center">
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:Label ID="lbl_Header" runat="server" Text="Employee Data"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:LinkButton ID="lnk_Files" runat="server" OnClientClick="ShowPop();">Click Here to View Oracle Posted Files</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Date" runat="server" Text="From Date"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="rdp_FromDate" runat="server" >
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_Date" runat="server" ControlToValidate="rdp_FromDate"
                                        Text="*" ValidationGroup="Controls" ErrorMessage="Please Enter From Date"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                             <tr>
                                <td>
                                    <asp:Label ID="lbl_ToDate" runat="server" Text="To Date"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="rdp_ToDate" runat="server" >
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_ToDate" runat="server" ControlToValidate="rdp_ToDate"
                                        Text="*" ValidationGroup="Controls" ErrorMessage="Please Enter To Date"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table align="center">
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btn_Get_Details" runat="server" Text="Get Details" ValidationGroup="Controls"
                                        OnClick="btn_Get_Details_Click" />
                                    &nbsp;<asp:Button ID="btn_Cancel" runat="server" Text="Cancel" 
                                        onclick="btn_Cancel_Click" />
                                    &nbsp;<asp:Button ID="btn_Generate" runat="server" Text="Generate XML" OnClick="btn_Generate_Click"
                                        ValidationGroup="Controls" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table align="center">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="RG_Date" runat="server" >
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="vs_Summary" runat="server" ValidationGroup="Controls"
        ShowMessageBox="true" ShowSummary="false" />
</asp:Content>

