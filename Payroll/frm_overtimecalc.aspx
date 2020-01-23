﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_overtimecalc.aspx.cs" Inherits="Payroll_frm_overtimecalc" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadAjaxManagerProxy ID="RAM_OCcalc" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_OTCALC">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnk_Edit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Cancel">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rcmb_PeriodMaster">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rcmb_PeriodStatus">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <%--              <telerik:AjaxSetting AjaxControlID="rcmb_OTDetPeriodDetails">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>--%>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
    </telerik:RadScriptBlock>
    <table align="center">
        <tr>
            <td align="center">
                <%--<asp:Label ID="lbl_PayTransact" runat="server" Text="Over Time Calculation" Font-Bold="true"></asp:Label>--%>
                <asp:Label ID="lbl_PayTransact" runat="server" Text="Over Time History" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <telerik:RadMultiPage ID="Rm_CY_page" runat="server" SelectedIndex="0" Width="990px"
                    Height="490px" meta:resourcekey="Rm_CY_page">
                    <telerik:RadPageView ID="Rp_CY_ViewMain" runat="server" meta:resourcekey="Rp_CY_ViewMain"
                        Selected="True">
                        <table align="center">
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_BusinessUnit" runat="server" meta:resourcekey="lbl_BusinessUnit"
                                        Text="Business Unit"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="rcmb_BUI" runat="server" Skin="WebBlue" AutoPostBack="true" Filter="Contains"
                                        MarkFirstMatch="true" meta:resourcekey="rcmb_BUI" OnSelectedIndexChanged="rcmb_BUI_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_BUI" runat="server" ControlToValidate="rcmb_BUI"
                                        ErrorMessage="Business Unit is a Mmandatory Field" ValidationGroup="Controls" InitialValue="Select"
                                        meta:resourcekey="rfv_rcmb_BUI">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_PeriodMaster" runat="server" Text="Period" meta:resourcekey="lbl_PeriodMaster"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="rcmb_PeriodMaster" runat="server"
                                        MarkFirstMatch="true" Filter="Contains"
                                        AutoPostBack="True" OnSelectedIndexChanged="rcmb_PeriodMaster_SelectedIndexChanged"
                                        Skin="WebBlue" meta:resourcekey="rcmb_PeriodMaster">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_PeriodMaster" ControlToValidate="rcmb_PeriodMaster"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Period is Mandatory" InitialValue="Select"
                                        meta:resourcekey="rfv_rcmb_PeriodMaster">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_PeriodElement" runat="server" Text="Period Element" meta:resourcekey="lbl_PeriodElement"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="rcmb_PeriodElement" runat="server" AutoPostBack="true"
                                        MarkFirstMatch="true" Filter="Contains"
                                        Skin="WebBlue" meta:resourcekey="rcmb_PeriodElement" OnSelectedIndexChanged="rcmb_PeriodElement_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_PeriodElement" ControlToValidate="rcmb_PeriodElement"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Period Element is Mandatory" InitialValue="Select"
                                        meta:resourcekey="rfv_rcmb_PeriodElement">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr runat="server" id="tr_OTDt" visible="false">
                                <td>
                                    <asp:Label ID="lbl_OTDt" runat="server" Text="Date of Over Time" meta:resourcekey="lbl_OTDt"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="rdtp_OTDt" runat="server" meta:resourcekey="rdtp_OTDt"
                                        Skin="WebBlue" OnSelectedDateChanged="rdtp_OTDt_SelectedDateChanged"
                                        AutoPostBack="True">
                                        <DateInput AutoPostBack="True" Skin="WebBlue">
                                        </DateInput>
                                        <Calendar Skin="WebBlue" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                            ViewSelectorText="x">
                                        </Calendar>
                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <%--<asp:Image ID="Image1" runat="server" Height="15px" ImageUrl="~/Images/Green1.png"
                                        Width="20px" />--%>
                                </td>
                                <td>
                                    <%--<asp:Label ID="lbl_color" runat="server" Text="-->Attendance already done"> </asp:Label>--%>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table align="center" style="width: 570px">
                            <tr>
                                <td align="left">
                                    <telerik:RadGrid ID="Rg_OTDetails" runat="server"
                                        GridLines="None" meta:resourcekey="Rg_OTDetails"
                                        AutoGenerateColumns="false" ClientSettings-Scrolling-AllowScroll="true" ClientSettings-Scrolling-UseStaticHeaders="true">
                                        <MasterTableView>
                                            <Columns>
                                                <telerik:GridTemplateColumn HeaderText="Select" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chk_emp" runat="server" />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <%--<telerik:GridTemplateColumn Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_empid" runat="server" Text='<%# Eval("EMPLOYEE CODE") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>--%>
                                                <telerik:GridTemplateColumn HeaderText="Employee Code" Visible="true">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_empcode" runat="server" Visible="true" Text='<%# Eval("EMPLOYEE CODE") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Employee" Visible="true">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_empname" runat="server" Visible="true" Text='<%# Eval("EMPLOYEE") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="No. Of OT Hours" Visible="true">
                                                    <ItemTemplate>
                                                        <%--<asp:TextBox ID="txt_nofdays" runat="server" Text='<%# Eval("OTCALC_WORKINGHOURS") %>' />--%>
                                                        <%--<telerik:RadNumericTextBox ID="txt_nofdays" Visible="true" runat="server" Text='<%# Eval("OTCALC_WORKINGHOURS") %>'>
                                                        </telerik:RadNumericTextBox>--%>
                                                        <asp:Label ID="txt_nofdays" Visible="true" runat="server" Text='<%# Eval("NO OF OT HOURS") %>' Type="Number">
                                                            <%--<NumberFormat DecimalDigits="0" AllowRounding="false" />--%>
                                                            <%--<TimePopupButton  Visible="true" />--%>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn DataField="SCALE" UniqueName="SCALE" HeaderText="Scale">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="DATE" UniqueName="DATE" HeaderText="Date">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <%--<telerik:GridTemplateColumn Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Att_Status" runat="server" Text='<%# Eval("LEAVE_STATUS") %>'></asp:Label>
                                                        <asp:Label ID="lbl_Att_Finalize" runat="server" Text='<%# Eval("ATTENDANCE_FINALIZE") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>--%>
                                            </Columns>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center">
                                    <asp:Button ID="btn_Finalise" runat="server" Text="Finalise" Visible="False" />
                                    &nbsp;<asp:Button ID="btn_Process" runat="server" OnClick="btn_Process_Click"
                                        Text="Process" ValidationGroup="Controls" />
                                    &nbsp;<asp:Button ID="btn_Cancle" runat="server" OnClick="btn_Cancle_Click"
                                        Text="Cancel" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>