<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_shiftDefinition.aspx.cs" Inherits="Masters_frm_shiftDefinition" Culture="auto" meta:resourcekey="Page" UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_Shift" runat="server" Font-Bold="True" meta:resourcekey="lbl_Shift"
                    Text=" Shift Definition"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_Shift_page" runat="server"
                    SelectedIndex="0" Width="990px" Height="490px" ScrollBars="Auto"
                    meta:resourcekey="Rm_Shift_page">
                    <telerik:RadPageView ID="Rp_Shift_ViewMain" runat="server"
                        meta:resourcekey="Rp_Shift_ViewMain" Selected="True">
                        <table align="center" width="60%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_Shift" runat="server" AutoGenerateColumns="False" Skin="WebBlue"
                                        GridLines="None" OnNeedDataSource="Rg_Shift_NeedDataSource" AllowFilteringByColumn="True"
                                        AllowSorting="True" meta:resourcekey="Rg_Shift">
                                        <GroupingSettings CaseSensitive="False" />
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="SHIFT_ID" HeaderText="ID"
                                                    meta:resourceKey="SHIFT_ID" UniqueName="SHIFT_ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SHIFT_CODE" HeaderText="Code"
                                                    meta:resourceKey="SHIFT_CODE" UniqueName="SHIFT_CODE" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SHIFT_DESC" HeaderText="Description"
                                                    meta:resourceKey="SHIFT_DESC" UniqueName="SHIFT_DESC" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SHIFT_STARTTIME" HeaderText="Start Time"
                                                    meta:resourceKey="SHIFT_STARTTIME" UniqueName="SHIFT_STARTTIME" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SHIFT_ENDTIME" HeaderText="End Time"
                                                    meta:resourceKey="SHIFT_ENDTIME" UniqueName="SHIFT_ENDTIME" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="False"
                                                    UniqueName="ColEdit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server"
                                                            CommandArgument='<%# Eval("SHIFT_ID") %>' meta:resourceKey="lnk_Edit"
                                                            OnCommand="lnk_Edit_Command">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <%--<telerik:GridTemplateColumn AllowFiltering="False" 
                                                    meta:resourcekey="GridTemplateColumnResource2" UniqueName="ColDelete">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Delete" runat="server" 
                                                            CommandArgument='<%# Eval("SHIFT_ID") %>' meta:resourceKey="lnk_Delete" 
                                                            OnCommand="lnk_Delete_Command">Delete</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>--%>
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
                    <telerik:RadPageView ID="Rp_Shift_ViewDetails" runat="server"
                        meta:resourcekey="Rp_Shift_ViewDetails">
                        <table align="center" width="30%">
                            <tr>
                                <td align="center" colspan="3" style="font-weight: bold;"></td>
                                <td align="center" style="font-weight: bold;"></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_ShiftID" runat="server" Visible="False"
                                        meta:resourcekey="lbl_ShiftID"></asp:Label>
                                    <asp:Label ID="lbl_ShiftCode" runat="server" meta:resourcekey="lbl_ShiftCode" Text="Shift Code"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_ShiftCode" runat="server" LabelCssClass="" TabIndex="1"
                                        Skin="WebBlue" MaxLength="100">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_ShiftCode" runat="server" ControlToValidate="rtxt_ShiftCode"
                                        ErrorMessage="Please Enter Name" ValidationGroup="Controls"
                                        meta:resourcekey="rfv_rtxt_ShiftCode">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_ShiftDesc" runat="server" meta:resourcekey="lbl_ShiftDesc" Text="Description"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_ShiftDesc" runat="server" LabelCssClass="" TabIndex="2"
                                        Skin="WebBlue" MaxLength="100">
                                    </telerik:RadTextBox>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_ShiftStartTime" runat="server" Text="Start Time"
                                        meta:resourcekey="lbl_ShiftStartTime"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTimePicker ID="rtp_ShiftStartTime" runat="server" TabIndex="3">
                                    </telerik:RadTimePicker>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtp_ShiftStartTime" runat="server" ControlToValidate="rtp_ShiftStartTime"
                                        ErrorMessage="Please Select Start Time" ValidationGroup="Controls"
                                        meta:resourcekey="rfv_rtp_ShiftStartTime">*</asp:RequiredFieldValidator>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_ShiftEndTime" runat="server" Text="End Date"
                                        meta:resourcekey="lbl_ShiftEndTime"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTimePicker ID="rtp_ShiftEndTime" runat="server" TabIndex="4">
                                    </telerik:RadTimePicker>

                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtp_ShiftEndTime" runat="server" ControlToValidate="rtp_ShiftEndTime"
                                        ErrorMessage="Please Select End Time" ValidationGroup="Controls"
                                        meta:resourcekey="rfv_rtp_ShiftEndTime">*</asp:RequiredFieldValidator>


                                </td>
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
                                    <asp:Button ID="btn_Edit" runat="server" meta:resourcekey="btn_Edit" OnClick="btn_Save_Click" TabIndex="5"
                                        Text="Update" ValidationGroup="Controls" Visible="False" />
                                    <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click" TabIndex="5"
                                        Text="Save" ValidationGroup="Controls" Visible="False" />
                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click" TabIndex="6"
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