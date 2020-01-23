<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_TrainingCalender.aspx.cs" Inherits="Training_frm_TrainingCalender" %>--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_TrainingCalender.aspx.cs" Inherits="Training_frm_TrainingSchedule" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    &nbsp;<table class="style1">
        <tr>
            <td style="width: 10%">
                &nbsp;
            </td>
            <td style="width: 50%">
                <asp:Panel ID="Appoint_panel" runat="server" GroupingText="Appointment Time">
                    <table class="style1">
                        <tr>
                            <td style="width: 22%">
                                <asp:Label ID="lbl_StartDate" runat="server" Text="Start Date"></asp:Label>
                            </td>
                            <td style="width: 2%">
                                <b>:</b>
                            </td>
                            <td style="width: 22%">
                                <telerik:RadDatePicker ID="rdtp_strtdate" runat="server" DateInput-EmptyMessage="Start Date">
                                </telerik:RadDatePicker>
                            </td>
                            <td style="width: 5%">
                                &nbsp;
                            </td>
                            <td class="style2">
                                <asp:Label ID="lbl_EndDate" runat="server" Text="End Date"></asp:Label>
                            </td>
                            <td style="width: 2%">
                                <b>:</b>
                            </td>
                            <td style="width: 22%">
                                <telerik:RadDatePicker ID="rdtp_enddate" runat="server" DateInput-EmptyMessage="End Date"
                                    AutoPostBack="true" OnSelectedDateChanged="rdtp_enddate_SelectedDateChanged">
                                </telerik:RadDatePicker>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbl_strttime" runat="server" Text="Start Time"></asp:Label>
                            </td>
                            <td>
                                <b>:</b>
                            </td>
                            <td>
                                <telerik:RadTimePicker ID="rtp_starttime" runat="server" DateInput-EmptyMessage="Start Time"
                                    BackColor="Chartreuse">
                                </telerik:RadTimePicker>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="style2">
                                <asp:Label ID="lbl_endtime" runat="server" Text="End Time"></asp:Label>
                            </td>
                            <td>
                                <b>:</b>
                            </td>
                            <td>
                                <telerik:RadTimePicker ID="rtp_endtime" runat="server" AutoPostBack="True" AutoPostBackControl="TimeView"
                                    DateInput-EmptyMessage="End Time" BackColor="Chartreuse"
                                    OnSelectedDateChanged="rtp_endtime_SelectedDateChanged">
                                </telerik:RadTimePicker>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbl_duration" runat="server" Text="Duration In(Hour)"></asp:Label>
                            </td>
                            <td>
                                <b>:</b>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="rtxt_duration" runat="server">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="style2">
                                <asp:ValidationSummary ID="vs_Trainer" runat="server" ShowMessageBox="True" ShowSummary="False"
                                    ValidationGroup="Controls" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td style="width: 10%">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Panel ID="panel_Recuer_id" runat="server" GroupingText="Recurrence Pattern">
                    <table class="style1">
                        <tr>
                            <td style="width: 20%" valign="top">
                                <asp:RadioButtonList ID="rbtnlist_recuerence_id" runat="server" Width="145px" OnSelectedIndexChanged="rbtnlist_recuerence_id_SelectedIndexChanged"
                                    AutoPostBack="true">
                                    <asp:ListItem Value="0">Daily</asp:ListItem>
                                    <asp:ListItem Value="1">Weekly</asp:ListItem>
                                    <asp:ListItem Value="2">Monthly</asp:ListItem>
                                    <asp:ListItem Value="3">Yearly</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td style="width: 2%">
                                &nbsp;
                            </td>
                            <td style="width: 78%" valign="top">
                                <asp:Panel ID="pnl_daily" runat="server" Visible="false">
                                    <table class="style1">
                                        <tr>
                                            <td>
                                                <asp:RadioButton ID="rd_every_id_daily" runat="server" Text="Every" GroupName="daily" />
                                                &nbsp;<asp:TextBox ID="txt_daily_id" runat="server" Width="30px" Text="1" ReadOnly="true"></asp:TextBox>
                                                &nbsp;<asp:Label ID="lbl_daily_id" runat="server" Text="Day(s)"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:RadioButton ID="rd_daily_weekday_id" runat="server" Text="EveryWeek Day" GroupName="daily" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnl_weekly" runat="server" Visible="false">
                                    <table class="style1">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_weekly_id" runat="server" Text="Recur Every"></asp:Label>
                                                &nbsp;<asp:TextBox ID="txt_weekly_id" runat="server" Width="30px" Text="1" ReadOnly="true"></asp:TextBox>
                                                &nbsp;<asp:Label ID="lbl_weekly_id_week" runat="server" Text="Week(s) On"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="chk_monday" runat="server" Text="Monday" />
                                                &nbsp;<asp:CheckBox ID="chk_Tuesday" runat="server" Text="Tuesday" />
                                                &nbsp;<asp:CheckBox ID="chk_Wednesday" runat="server" Text="Wednesday" />
                                                <asp:CheckBox ID="chk_Thursday" runat="server" Text="Thursday" />
                                                <asp:CheckBox ID="chk_Friday" runat="server" Text="Friday" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="chk_Saturday" runat="server" Text="Saturday" />
                                                &nbsp;<asp:CheckBox ID="chk_Sunday" runat="server" Text="Sunday" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnl_monthly" runat="server" Visible="false">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:RadioButton ID="rd_monthly_id" runat="server" Text="Day" GroupName="monthly" />
                                                &nbsp;<asp:TextBox ID="txt_monthly_id" runat="server" Width="30px" ReadOnly="true"></asp:TextBox>
                                                &nbsp;Of Every
                                                <asp:TextBox ID="txt_monthly_id1" runat="server" Width="30px" Text="1" ReadOnly="true"></asp:TextBox>
                                                &nbsp;month(s)
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:RadioButton ID="rd_monthly_id5" runat="server" Text="The" GroupName="monthly" />
                                                &nbsp;<asp:DropDownList ID="ddl_monthly_id" runat="server" Width="50px">
                                                    <asp:ListItem Value="0" Text="First"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Second"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Third"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="Fourth"></asp:ListItem>
                                                    <asp:ListItem Value="4" Text="Last"></asp:ListItem>
                                                </asp:DropDownList>
                                                &nbsp;<asp:DropDownList ID="ddl_monthly_id2" runat="server" Width="50px">
                                                    <asp:ListItem Value="0" Text="Sunday"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Monday"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Tuesday"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="Wednesday"></asp:ListItem>
                                                    <asp:ListItem Value="4" Text="Thrusday"></asp:ListItem>
                                                    <asp:ListItem Value="5" Text="Friday"></asp:ListItem>
                                                    <asp:ListItem Value="6" Text="Saturday"></asp:ListItem>
                                                </asp:DropDownList>
                                                &nbsp;Of Every<asp:TextBox ID="txt_monthly_id3" runat="server" Width="30px" Text="1"
                                                    ReadOnly="true"></asp:TextBox>
                                                Month(s)&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnl_yearly" runat="server" Visible="false">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:RadioButton ID="rd_yearly_id" runat="server" Text="Every" GroupName="yearly" />
                                                &nbsp;<asp:DropDownList ID="ddl_yearly_id2" runat="server" Width="80px">
                                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="January"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="February"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="March"></asp:ListItem>
                                                    <asp:ListItem Value="4" Text="April"></asp:ListItem>
                                                    <asp:ListItem Value="5" Text="May"></asp:ListItem>
                                                    <asp:ListItem Value="6" Text="June"></asp:ListItem>
                                                    <asp:ListItem Value="7" Text="July"></asp:ListItem>
                                                    <asp:ListItem Value="8" Text="August"></asp:ListItem>
                                                    <asp:ListItem Value="9" Text="September"></asp:ListItem>
                                                    <asp:ListItem Value="10" Text="October"></asp:ListItem>
                                                    <asp:ListItem Value="11" Text="November"></asp:ListItem>
                                                    <asp:ListItem Value="12" Text="December"></asp:ListItem>
                                                </asp:DropDownList>
                                                &nbsp;<asp:TextBox ID="txt_yearly_id" runat="server" Width="30px" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:RadioButton ID="rd_yearly_id3" runat="server" Text="The" GroupName="yearly" />
                                                &nbsp;<asp:DropDownList ID="ddl_yearly_id3" runat="server" Width="80px">
                                                    <asp:ListItem Value="0" Text="First"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Second"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Third"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="Fourth"></asp:ListItem>
                                                    <asp:ListItem Value="4" Text="Last"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="ddl_yearly_id" runat="server" Width="80px">
                                                    <asp:ListItem Value="0" Text="Sunday"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Monday"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Tuesday"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="Wednesday"></asp:ListItem>
                                                    <asp:ListItem Value="4" Text="Thrusday"></asp:ListItem>
                                                    <asp:ListItem Value="5" Text="Friday"></asp:ListItem>
                                                    <asp:ListItem Value="6" Text="Saturday"></asp:ListItem>
                                                </asp:DropDownList>
                                                Of
                                                <asp:DropDownList ID="ddl_yearly_id4" runat="server" Width="80px">
                                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="January"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="February"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="March"></asp:ListItem>
                                                    <asp:ListItem Value="4" Text="April"></asp:ListItem>
                                                    <asp:ListItem Value="5" Text="May"></asp:ListItem>
                                                    <asp:ListItem Value="6" Text="June"></asp:ListItem>
                                                    <asp:ListItem Value="7" Text="July"></asp:ListItem>
                                                    <asp:ListItem Value="8" Text="August"></asp:ListItem>
                                                    <asp:ListItem Value="9" Text="September"></asp:ListItem>
                                                    <asp:ListItem Value="10" Text="October"></asp:ListItem>
                                                    <asp:ListItem Value="11" Text="November"></asp:ListItem>
                                                    <asp:ListItem Value="12" Text="December"></asp:ListItem>
                                                </asp:DropDownList>
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <%-- <asp:Panel ID="pnl_rangeofrecurrence" runat="server" GroupingText="Range of Recurrence">
                    <table class="style1 ">
                        <tr>
                            <td style="width: 50%">
                                <asp:Label ID="lbl_rangeofrec" runat="server" Text="Start Date   :"></asp:Label>
                                &nbsp;&nbsp;
                                <telerik:RadDatePicker ID="rdtp_strtdate1" runat="server" EnableEmbeddedSkins="false">
                                </telerik:RadDatePicker>
                            </td>
                            <td style="width: 50%">
                                <asp:RadioButton ID="rd_rangeofrec_noend" runat="server" GroupName="Group1" Text="No End Date" />
                                &nbsp;<br />
                                <asp:RadioButton ID="rd_rangeofrec_endafter" runat="server" GroupName="Group1" Text="End After :" />
                                &nbsp;<asp:TextBox ID="txt_rangeofrec_occ" runat="server" Width="30px" ReadOnly="true"></asp:TextBox>
                                &nbsp;Occuerences<br />
                                <asp:RadioButton ID="rd_rangeofrec_endby" runat="server" GroupName="Group1" Text="End By:" />
                                &nbsp;<telerik:RadDatePicker ID="rdtp_strtdate2" runat="server" EnableEmbeddedSkins="false">
                                </telerik:RadDatePicker>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btn_ok_id" runat="server" Text="Ok" OnClick="btn_ok_id_Click" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btn_cancel_id" runat="server" Text="Cancel" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>--%>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    &nbsp;
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 17%;
        }
    </style>
</asp:Content>
