<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_Attendance.aspx.cs" Inherits="HR_Attendance" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_Attendance" runat="server" SelectedIndex="0" 
                     Width="990px" Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_Attendance" runat="server" Selected="True">
                        <table align="center">
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:Label ID="lbl_Attendance" Text="Attendance Template" runat="server" Font-Bold="True"
                                        meta:resourcekey="lbl_Attendance"></asp:Label>
                                    <br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_BusinessUnitID" Text="Business Unit" runat="server" meta:resourcekey="lbl_BusinessUnitID"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadComboBox  ID="rcmb_BusinessUnitID" runat="server"  Skin="WebBlue" MarkFirstMatch="true" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Period" runat="server" meta:resourcekey="lbl_Period" Text="Period"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadComboBox  ID="rcmb_Period" runat="server" AutoPostBack="true"  Skin="WebBlue" MarkFirstMatch="true" 
                                        OnSelectedIndexChanged="rcmb_Period_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_PeriodDetails" runat="server" meta:resourcekey="lbl_PeriodDetails"
                                        Text="Period Items"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadComboBox  ID="rcmb_PeriodDetails" runat="server"  Skin="WebBlue" MarkFirstMatch="true" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:Button ID="btn_DownloadSheet" runat="server" Text="Download Sheet" OnClick="btn_DownloadSheet_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <%--
                                    <table align="center">
                                        <tr>
                                            <td>
                                                <rsweb:ReportViewer ID="rv_GenerateAttendance" runat="server" Width="100%" ProcessingMode="Local"
                                                    ShowBackButton="True" ShowToolBar="true" ShowParameterPrompts="false">
                                                </rsweb:ReportViewer>
                                            </td>
                                        </tr>
                                    </table> --%>
                                </td>
                            </tr>
                        </table>
                        
                        
                        
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>
