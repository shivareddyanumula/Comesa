<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frmOverTimeCalcHR.aspx.cs" Inherits="Approval_frmOverTimeCalcHR" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .eWidth {
            width: 30px;
        }
    </style>
    <script type="text/javascript">
        function validate(key) {
            var keycode = (key.which) ? key.which : key.keyCode;
            if (keycode < 58 && keycode > 47) {
                return true;
            }
            else return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_OverTime" runat="server" Font-Bold="true" Text="OverTime HR Approval"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_OverTime_page" runat="server" SelectedIndex="0" Width="990px" Height="480px">
                    <telerik:RadPageView ID="Rp_OverTime_ViewMain" runat="server" meta:resourcekey="Rp_OverTime_ViewMain"
                        Selected="True">
                        <table align="center" width="80%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_OverTime" runat="server" AllowFilteringByColumn="True"
                                        AllowPaging="True" AutoGenerateColumns="False" GridLines="None"
                                        OnNeedDataSource="Rg_OverTime_NeedDataSource" PageSize="10" Skin="WebBlue"
                                        ClientSettings-Scrolling-AllowScroll="true"
                                        ClientSettings-Scrolling-UseStaticHeaders="true" Width="900px" Height="355px">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="OTCALC_ID" UniqueName="OTCALC_ID"
                                                    meta:resourcekey="OTCALC_ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <%--<telerik:GridTemplateColumn HeaderText="Select All">
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="chk_selectall" runat="server" AutoPostBack="true" OnCheckedChanged="chk_selectall_CheckedChanged"
                                                            Text="Select All" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox runat="server" ID="chk_Select"></asp:CheckBox>
                                                        <asp:Label ID="lblIsEnabled" runat="server" Visible="false" Text='<%# Eval("IsEnabled") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>--%>
                                                <telerik:GridBoundColumn DataField="BUSINESSUNIT_CODE" HeaderText="Business Unit"
                                                    UniqueName="BUSINESSUNIT_CODE">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMP_EMPCODE"
                                                    HeaderText="Employee Code" UniqueName="EMP_EMPCODE">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMP_NAME" HeaderText="Employee"
                                                    meta:resourcekey="EMP_NAME" UniqueName="EMP_NAME">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridDateTimeColumn DataField="OTCALC_DATE" meta:Resourcekey="OTCALC_DATE" FilterControlWidth="100px"
                                                    HeaderText="OT Date" SortExpression="OTCALC_DATE" PickerType="DatePicker" DataFormatString="{0:MM/dd/yyyy}">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridDateTimeColumn>
                                                <telerik:GridBoundColumn DataField="ACT_HRS" HeaderText="No. Of Actual Hours"
                                                    meta:resourcekey="ACT_HRS" UniqueName="ACT_HRS">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="OT_HRS" HeaderText="No. Of OT Hours"
                                                    meta:resourcekey="OT_HRS" UniqueName="OT_HRS">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <%--<telerik:GridBoundColumn DataField="OTCALC_WORKINGHOURS" HeaderText="No. Of OT Hours"
                                                    meta:resourcekey="OTCALC_WORKINGHOURS" UniqueName="OTCALC_WORKINGHOURS">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>--%>
                                                <telerik:GridBoundColumn DataField="STATUS" HeaderText="Status"
                                                    UniqueName="STATUS">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbtn_Edit" Text="Edit" runat="server" OnCommand="lbtn_Edit_Command"
                                                            CommandArgument='<%#Eval("OTCALC_ID") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <%--<div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" meta:resourceKey="lnk_Add"
                                                        OnCommand="lnk_Add_Command">Add</asp:LinkButton>
                                                </div>--%>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <PagerStyle AlwaysVisible="True" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RPV_OT" runat="server" Selected="false">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <table align="center" width="43%">
                                    <tr>
                                        <td colspan="3" align="center" style="font-weight: bold;"></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_Employee" runat="server" Text="Employee"></asp:Label></td>
                                        <td><b>:</b>

                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_Employee" runat="server" AutoPostBack="True" MaxHeight="300px" Enabled="false"
                                                MarkFirstMatch="true" OnSelectedIndexChanged="rcmb_Employee_SelectedIndexChanged" Skin="WebBlue" Filter="Contains">
                                            </telerik:RadComboBox>
                                        </td>

                                        <%-- <td>
                                            <asp:RequiredFieldValidator ID="rfv_Employee" runat="server" ControlToValidate="rcmb_Employee"
                                                ErrorMessage="Please select Employee"
                                                 Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>&#160;</td>--%>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_BusinessUnit" runat="server" Text="BusinessUnit"></asp:Label></td>
                                        <td><b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_BusinessUnit" runat="server" AutoPostBack="True"
                                                MarkFirstMatch="true" MaxHeight="300px" Enabled="false" Filter="Contains"
                                                OnSelectedIndexChanged="rcmb_BusinessUnit_SelectedIndexChanged" Skin="WebBlue">
                                            </telerik:RadComboBox>
                                        </td>

                                        <%-- <td>
                                            <asp:RequiredFieldValidator ID="rfv_rcmb_BusinessUnit" runat="server" ControlToValidate="rcmb_BusinessUnit"
                                                ErrorMessage="Please select BusinessUnit"
                                                 Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>--%>
                                    </tr>
                                    <%-- <tr>
                                        <td align="right" width="40%">
                                            <asp:Label ID="lbl_EmployeeCode" runat="server" Text="Employee Code"></asp:Label></td>
                                        <td>:
                                        </td>
                                        <td align="left">
                                            <telerik:RadTextBox ID="rntb_code" runat="server" Skin="WebBlue" MaxHeight="300px">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_Empcode" runat="server" ControlToValidate="rntb_code"
                                                ErrorMessage="Please Enter Employee Code"
                                                Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator></td>
                                        <td></td></tr>--%>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_Date" runat="server" Text="Date of Over Time"></asp:Label></td>
                                        <td><b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadDatePicker ID="rdtp_OTDt" runat="server" meta:resourcekey="rdtp_OTDt"
                                                Skin="WebBlue" OnSelectedDateChanged="rdtp_OTDt_SelectedDateChanged"
                                                AutoPostBack="True" Enabled="false">
                                                <DateInput AutoPostBack="True" Skin="WebBlue">
                                                </DateInput>
                                                <Calendar Skin="WebBlue" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                                    ViewSelectorText="x">
                                                </Calendar>
                                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvrdtp_OTDt" runat="server" ControlToValidate="rdtp_OTDt"
                                                ErrorMessage="Please select Date of Over Time"
                                                Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator></td>
                                        <%--<td></td>--%>
                                    </tr>
                                      <tr>
                                        <td>
                                            <asp:Label ID="lbl_fromtime" runat="server" Text="From Time"></asp:Label>

                                        </td>
                                        <td><b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadTimePicker ID="rdp_fromtime" runat="server" DateInput-DateFormat="HH:mm" TimeView-TimeFormat="HH:mm" AutoPostBack="true" Enabled="false"></telerik:RadTimePicker>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl_totime" runat="server" Text="To Time"></asp:Label>
                                        </td>
                                        <td><b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadTimePicker ID="rdp_totime" runat="server" DateInput-DateFormat="HH:mm" TimeView-TimeFormat="HH:mm" AutoPostBack="true" Enabled="false"></telerik:RadTimePicker>
                                        </td>
                                        <%-- <td>
                                            <telerik:RadTextBox ID="txt_hourcalc" runat="server" Enabled="false" /> <asp:label id="lbl_days" runat="server" Text="No. of Hours"></asp:label>
                                        </td>--%>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_ActualHours" runat="server" Text="Actual Hours"></asp:Label>
                                        </td>
                                        <td><b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadTextBox runat="server" ID="rtbActHrs" Skin="Outlook" onkeypress="return validate(event)"
                                                Font-Names="Arial" SkinID="EmpExp" MaxLength="2" placeholder="HH"
                                                AutoPostBack="true" OnTextChanged="rtbActHrs_TextChanged" Enabled="false">
                                            </telerik:RadTextBox>
                                            <telerik:RadTextBox runat="server" ID="rtbActMins" Skin="Outlook" onkeypress="return validate(event)"
                                                Font-Names="Arial" SkinID="EmpExp" MaxLength="2" placeholder="MM"
                                                AutoPostBack="true" OnTextChanged="rtbActHrs_TextChanged" Enabled="false">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rntb_Mins" runat="server" ControlToValidate="rtbActHrs"
                                                ErrorMessage="Please Enter Actual Hours" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_OTHours" runat="server" Text="OverTime Hours "></asp:Label></td>
                                        <td><b>:</b>
                                        </td>
                                        <td align="left">
                                            <telerik:RadTextBox runat="server" ID="rtbOTHrs" Skin="Outlook" Enabled="false"
                                                Font-Names="Arial" SkinID="EmpExp" MaxLength="2" placeholder="HH">
                                            </telerik:RadTextBox>
                                            <telerik:RadTextBox runat="server" ID="rtbOTMins" Skin="Outlook" Enabled="false"
                                                Font-Names="Arial" SkinID="EmpExp" MaxLength="2" placeholder="MM">
                                            </telerik:RadTextBox>
                                        </td>

                                    </tr>
                                    <%--<tr>
                                        <td align="right" width="40%">
                                            <asp:Label ID="lbl_ActualHours" runat="server" Text="Actual Hours"></asp:Label></td>
                                        <td>:
                                        </td>
                                        <td align="left">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rntb_Hours" runat="server" Skin="WebBlue" MaxValue="12" OnTextChanged="rntb_Hours_TextChanged"
                                                            DataType="system.int32" MinValue="0" Width="30px" AutoPostBack="true">
                                                            <NumberFormat DecimalDigits="0" />
                                                        </telerik:RadNumericTextBox>
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rntb_Mins" runat="server" OnTextChanged="rntb_Hours_TextChanged"
                                                            Skin="WebBlue" Width="30px" MaxValue="59" MinValue="0" DataType="system.int32" AutoPostBack="true">
                                                            <NumberFormat DecimalDigits="0" />
                                                        </telerik:RadNumericTextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rntb_Mins" runat="server" ControlToValidate="rntb_Hours"
                                                ErrorMessage="Please Enter  Actual Hours" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="40%">
                                            <asp:Label ID="lbl_OTHours" runat="server" Text="OverTime Hours "></asp:Label></td>
                                        <td>:
                                        </td>
                                        <td align="left">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rntb_OTHours" runat="server" Skin="WebBlue" MaxHeight="300px" Width="30px"
                                                            MinValue="0" DataType="system.int32" Enabled="false">
                                                            <NumberFormat DecimalDigits="0" />
                                                        </telerik:RadNumericTextBox>
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rntb_OTMins" runat="server" Enabled="false"
                                                            Skin="WebBlue" MaxHeight="300px" Width="30px" MaxValue="59" MinValue="0" DataType="system.int32">
                                                            <NumberFormat DecimalDigits="0" />
                                                        </telerik:RadNumericTextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td></td>
                                    </tr>--%>
                                  
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_Comments" runat="server" Text="Comments"></asp:Label></td>
                                        <td><b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="rtxt_Comments" runat="server" Skin="WebBlue" DisabledStyle-BackColor="Window"
                                                Width="125px" MaxLength="200" Height="100" TextMode="MultiLine" Style="resize: none" Enabled="false">
                                            </telerik:RadTextBox>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td colspan="4"></td>
                                        <%--<td></td>--%>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="4">
                                            <asp:Button ID="btn_Submit" runat="server" Text="Approve" ValidationGroup="Controls" OnClick="btn_Submit_Click" Visible="false" />


                                            <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" Visible="false" />
                                        </td>
                                        <%--<td></td>--%>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="4">
                                            <asp:ValidationSummary ID="vg_Master" runat="server" ShowMessageBox="True" ShowSummary="False"
                                                ValidationGroup="Controls" meta:resourcekey="vg_Master" />
                                        </td>
                                        <%--<td></td>--%>
                                    </tr>
                                </table>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btn_Submit" />
                                <asp:PostBackTrigger ControlID="rtbActHrs" />
                                <asp:PostBackTrigger ControlID="rtbActMins" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>
