<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_Pms_TaskFeedback.aspx.cs"
    Inherits="PMS_frm_Pms_TaskFeedback" Culture="auto" meta:resourcekey="PageResource1"
    UICulture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>



</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">

            <script language="javascript" type="text/javascript">
                function GetRadWindow() {
                    var oWindow = null;
                    if (window.radWindow)
                        oWindow = window.RadWindow; //Will work in Moz in all cases, including clasic dialog         
                    else if (window.frameElement.radWindow)
                        oWindow = window.frameElement.radWindow; //IE (and Moz as well)         
                    return oWindow;
                }

                function Close() {
                    GetRadWindow().Close();
                }
            </script>

        </telerik:RadScriptBlock>

        <div>
            <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" Skin="WebBlue" DecoratedControls="All"
                meta:resourcekey="RadFormDecorator1Resource1" />
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            </telerik:RadScriptManager>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp;
        <center>Feedback Details</center>
            <table align="center">
                <tr>
                    <td class="style1">
                        <asp:Label ID="lbl_KRA_Name" runat="server" Text="KRA Name :"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="rtxt_KRAName" runat="server">
                        </asp:Label>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="lbl_MgrFeedback" runat="server" Text="Feedback :"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadTextBox ID="rtxt_TaskFeedbac" runat="server" TextMode="MultiLine" meta:resourcekey="rtxt_TaskFeedbacResource1"
                            Width="125px">
                        </telerik:RadTextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfv_rtxt_TaskFeedbac" ControlToValidate="rtxt_TaskFeedbac"
                            runat="server" ValidationGroup="Controls" ErrorMessage="Feedback Cannot Be Empty"
                            meta:resourcekey="rfv_rtxt_TaskFeedbacResource1">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="lbl_MgrRating" runat="server" Text="Rating :"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadRating ID="rd_TaskRt" runat="server">
                        </telerik:RadRating>
                    </td>

                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="lbl_FeedbackDate" runat="server" Text="Date :"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadDatePicker ID="rdtp_Task_Feedbac" runat="server"
                            meta:resourcekey="rdtp_Task_FeedbacResource1">
                        </telerik:RadDatePicker>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfv_rdtp_Task_Feedbac" ControlToValidate="rdtp_Task_Feedbac"
                            runat="server" ValidationGroup="Controls" ErrorMessage="Please Select Date" meta:resourcekey="rfv_rdtp_Task_FeedbacResource1">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Button ID="Btn_Submit_TaskFeedbac" runat="server" Text="Submit" OnClick="Btn_Submit_TaskFeedbac_Click"
                            Width="58px" ValidationGroup="Controls" meta:resourcekey="Btn_Submit_TaskFeedbacResource1" />
                        <asp:ValidationSummary ID="vs_TaskFeedback" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="Controls" meta:resourcekey="vs_TaskFeedbackResource1" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>