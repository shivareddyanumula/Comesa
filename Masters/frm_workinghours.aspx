<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_workinghours.aspx.cs" Inherits="Masters_frm_workinghours" Culture="auto" meta:resourcekey="Page" UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_WHoursHeader" runat="server" Text="Working Hours" Font-Bold="True"
                    meta:resourcekey="lbl_WHoursHeader"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_WH_page" runat="server" SelectedIndex="0" Width="990px" Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_WH_ViewMain" runat="server"
                        meta:resourcekey="Rp_WH_ViewMain" Selected="True">
                        <table align="center" width="50%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_WHours" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        Skin="WebBlue" OnNeedDataSource="Rg_WHours_NeedDataSource"
                                        meta:resourcekey="Rg_WHours" AllowFilteringByColumn="true">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="WRKHRS_ID" UniqueName="WRKHRS_ID" HeaderText="ID"
                                                    meta:resourcekey="WRKHRS_ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="WRKHRS_BUSINESSUNIT_ID" UniqueName="WRKHRS_BUSINESSUNIT_ID"
                                                    HeaderText="Business Unit" meta:resourcekey="WRKHRS_BUSINESSUNIT_ID" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="WRKHRS_DAY_ID" UniqueName="WRKHRS_DAY_ID" HeaderText="Days"
                                                    meta:resourcekey="WRKHRS_DAY_ID" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridNumericColumn DataField="WRKHRS_NOOFHOURS" UniqueName="WRKHRS_NOOFHOURS" FilterControlWidth="100px"
                                                    HeaderText="No of Hours" meta:resourcekey="WRKHRS_NOOFHOURS" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridNumericColumn>
                                                <telerik:GridBoundColumn DataField="TIME" UniqueName="TIME" HeaderText="Time" FilterControlWidth="100px"
                                                    meta:resourcekey="TIME" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" AllowFiltering="false"
                                                    meta:resourcekey="GridTemplateColumn">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("WRKHRS_ID") %>'
                                                            OnCommand="lnk_Edit_Command" meta:resourcekey="lnk_Edit">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <EditFormSettings>
                                                <EditColumn CancelImageUrl="Cancel.gif" EditImageUrl="Edit.gif"
                                                    InsertImageUrl="Update.gif" UpdateImageUrl="Update.gif">
                                                </EditColumn>
                                            </EditFormSettings>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" meta:resourceKey="lnk_Add"
                                                        OnCommand="lnk_Add_Command">Add</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <FilterMenu Skin="WebBlue">
                                        </FilterMenu>
                                        <HeaderContextMenu Skin="WebBlue">
                                        </HeaderContextMenu>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_WH_ViewDetails" runat="server"
                        meta:resourcekey="Rp_WH_ViewDetails">
                        <table align="center">
                            <tr>
                                <td colspan="3" align="center" style="font-weight: bold;"></td>
                                <td align="center" style="font-weight: bold;"></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_WHoursID" runat="server" Visible="False"
                                        meta:resourcekey="lbl_WHoursID"></asp:Label>
                                    <asp:Label ID="lbl_WHoursBunitID" runat="server" Text="Business Unit" meta:resourcekey="lbl_WHoursBunitID"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_WHoursBunitID" runat="server" Skin="WebBlue" MarkFirstMatch="true" MaxHeight="120px" TabIndex="1"
                                        Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_WHoursBunitID" runat="server" ControlToValidate="rcmb_WHoursBunitID"
                                        ErrorMessage="Please Select Business Unit" InitialValue="Select"
                                        ValidationGroup="Controls" meta:resourcekey="rfv_rcmb_WHoursBunitID">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_WHoursDay" runat="server" Text="Day" meta:resourcekey="lbl_WHoursDay"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_WHoursDay" runat="server" Skin="WebBlue" MarkFirstMatch="true" MaxHeight="120px" TabIndex="2"
                                        Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_WHoursDay" runat="server" ControlToValidate="rcmb_WHoursDay"
                                        ErrorMessage="Please Select Day" InitialValue="Select"
                                        ValidationGroup="Controls" meta:resourcekey="rfv_rcmb_WHoursDay">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_WHoursHours" runat="server" meta:resourcekey="lbl_WHoursHours"
                                        Text="No of Hours"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td style="margin-left: 40px">
                                    <telerik:RadNumericTextBox ID="rntxt_WhoursHours" runat="server" TabIndex="3"
                                        Skin="WebBlue" MaxLength="2" MaxValue="24" MinValue="1">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rntxt_WhoursHours" runat="server" ControlToValidate="rntxt_WhoursHours"
                                        ErrorMessage="Please Specify No of hours" ValidationGroup="Controls"
                                        meta:resourcekey="rfv_rntxt_WhoursHours">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_WHoursStartTime" runat="server" Text="Start Time"
                                        meta:resourcekey="lbl_WHoursStartTime"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTimePicker ID="rtp_WhoursStartTime" runat="server" TabIndex="4">
                                    </telerik:RadTimePicker>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtp_WhoursStartTime" runat="server" ControlToValidate="rtp_WhoursStartTime"
                                        ErrorMessage="Please Select Start Time" ValidationGroup="Controls"
                                        meta:resourcekey="rfv_rtp_WhoursStartTime">*</asp:RequiredFieldValidator><asp:CompareValidator ID="cv_rtp_WhoursStartTime" runat="server" ControlToCompare="rtp_WhoursStartTime"
                                            ControlToValidate="rtp_WhoursEndTime" ErrorMessage="Start Time Cannot be Less than EndTime"
                                            Operator="GreaterThan" ValidationGroup="Controls"
                                            meta:resourcekey="cv_rtp_WhoursStartTime">*</asp:CompareValidator></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_WHoursEndTime" runat="server" Text="End Time"
                                        meta:resourcekey="lbl_WHoursEndTime"></asp:Label></td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTimePicker ID="rtp_WhoursEndTime" runat="server" TabIndex="5">
                                    </telerik:RadTimePicker>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtp_WhoursEndTime" runat="server" ControlToValidate="rtp_WhoursEndTime"
                                        ErrorMessage="Please Select End Time" ValidationGroup="Controls"
                                        meta:resourcekey="rfv_rtp_WhoursEndTime">*</asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>&nbsp;
                                </td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Button ID="btn_Edit" runat="server" meta:resourcekey="btn_Edit" OnClick="btn_Save_Click" TabIndex="6"
                                        Text="Update" ValidationGroup="Controls" Visible="False" />
                                    <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click" TabIndex="6"
                                        Text="Save" ValidationGroup="Controls" Visible="False" />
                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click" TabIndex="7"
                                        Text="Cancel" />
                                    <asp:ValidationSummary ID="vs_WHours" runat="server" ShowMessageBox="True" ShowSummary="False"
                                        ValidationGroup="Controls" meta:resourcekey="vs_WHours" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>