<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_dailylogreport.aspx.cs" Inherits="Reportss_frm_dailylogreport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <asp:UpdatePanel ID="up_Dailylogreport" runat="server">
        <ContentTemplate>
            <table align="center" width="990px" style="vertical-align: top;">
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
                                    <telerik:RadDatePicker EnableEmbeddedSkins="false" ID="rdtp_logdate" runat="server"
                                        Skin="WebBlue" AutoPostBack="True"
                                        OnSelectedDateChanged="rdtp_logdate_SelectedDateChanged">
                                        <DateInput AutoPostBack="True" Skin="WebBlue">
                                        </DateInput>
                                        <Calendar Skin="WebBlue" UseColumnHeadersAsSelectors="False"
                                            UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                        </Calendar>
                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                    </telerik:RadDatePicker>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business Unit"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox EnableEmbeddedSkins="false" ID="rcmb_BusinessUnit" runat="server" AutoPostBack="True" Skin="WebBlue" MarkFirstMatch="true"
                                        OnSelectedIndexChanged="rcmb_BusinessUnit_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Employee" runat="server" Text="Employee"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox EnableEmbeddedSkins="false" ID="rcmb_Employee" runat="server" Skin="WebBlue" MarkFirstMatch="true"
                                        AutoPostBack="True" OnSelectedIndexChanged="rcmb_Employee_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <rsweb:ReportViewer ID="rv_DailyLog" runat="server" Width="600px" ShowBackButton="True"
                            Height="430px" ShowParameterPrompts="False" Font-Names="Verdana" Font-Size="8pt">
                        </rsweb:ReportViewer>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="rcmb_Employee" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>