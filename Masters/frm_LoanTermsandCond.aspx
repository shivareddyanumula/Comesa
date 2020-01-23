<%@ Page Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_LoanTermsandCond.aspx.cs" Inherits="Masters_frm_LoanTermsandCond"
    Title="Untitled Page" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <br />
    <br />
    <br />
    <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0">
        <telerik:RadPageView runat="server" ID="RadPageView1" Selected="true">
            <table align="center">
                <tr>
                    <td align="right">
                        <asp:HiddenField ID="hdnAssemblyMissionID" runat="server" />
                        <b>Terms & Conditions:</b>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="rtxtTermsAndCond" Height="150px" Width="550px" runat="server"
                            meta:resourcekey="rtxtTermsAndCond" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rf1" runat="server" ErrorMessage="Please Enter Terms & Conditions" Text="*"
                            ControlToValidate="rtxtTermsAndCond" ValidationGroup="Controls">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="right">
                        <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Update" OnClick="btn_Save_Click"
                            Text="Update" Visible="False" UseSubmitBehavior="false" OnClientClick="fnJSOnFormSubmit(this,'Controls')" />
                        <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click"
                            Text="Save" UseSubmitBehavior="false" OnClientClick=" disableButtoneve(this);" />
                        <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" PostBackUrl="~/Masters/Default.aspx"
                            Text="Cancel" />
                        <asp:ValidationSummary ID="vs_ServiceProvider" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="Controls" />
                    </td>
                </tr>
            </table>
        </telerik:RadPageView>
    </telerik:RadMultiPage>
</asp:Content>