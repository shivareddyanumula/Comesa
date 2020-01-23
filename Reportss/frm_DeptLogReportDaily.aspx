<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_DeptLogReportDaily.aspx.cs" Inherits="Reportss_frm_DeptLogReportDaily" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <br />
    <asp:UpdatePanel ID="up_Dailylogreport" runat="server">
        <ContentTemplate>
            <table align="center" width="990px" style="vertical-align: top;">
                <tr>
                    <td align="center">
                        <asp:Label ID="lbl_DailyLog" runat="server" Text="Department wise Daily Log Report"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table align="center" style="width: 40%;">
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_LogDay" runat="server" Text="Log Date"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadDatePicker EnableEmbeddedSkins="false" ID="rdtp_logdate" runat="server" Skin="WebBlue"
                                        AutoPostBack="True" OnSelectedDateChanged="rdtp_logdate_SelectedDateChanged">
                                    </telerik:RadDatePicker>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Dept" runat="server" Text="Department"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox EnableEmbeddedSkins="false" ID="rcmb_Position" runat="server" Skin="WebBlue" MarkFirstMatch="true"
                                        AutoPostBack="True" OnSelectedIndexChanged="rcmb_Position_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <rsweb:ReportViewer ID="rv_Department_DailyLog" runat="server" Width="600px" ShowBackButton="True"
                            Height="430px" ShowParameterPrompts="False" Font-Names="Verdana" Font-Size="8pt">
                        </rsweb:ReportViewer>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>