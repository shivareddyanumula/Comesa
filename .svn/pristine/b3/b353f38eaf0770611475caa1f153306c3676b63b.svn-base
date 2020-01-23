<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_LeaveApproval.aspx.cs" Inherits="Approval_frm_LeaveApproval" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">

    <script type="text/javascript">
        function ShowPop() {
            var win = window.radopen('../Masters/Frm_leaveDetails.aspx', "RW_leavedetails");
            win.center();
            win.set_modal(true);
        }
        function ShowPoprolback() {
            var win = window.radopen('../Masters/Frm_leaveDetails.aspx?control=rollback', "RW_leavedetails");
            win.center();
            win.set_modal(true);
        }


        function ShowPopup() {
            var win = window.radopen('../Masters/Frm_leaveBalances.aspx', "RW_lbalances");
            win.center();
            win.set_modal(true);
        }

    </script>

    <div style="overflow: auto;">


        <table align="center">
            <tr>
                <td>


                    <table align="center">
                        <tr>
                            <td align="center">
                                <asp:Label ID="lbl_LeaveApproval" runat="server" meta:resourcekey="lbl_LeaveApproval"
                                    Style="font-weight: 700"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                                <table align="center">
                                    <tr style="display: none">
                                        <td>
                                            <asp:Label ID="lbl_ReportingMgr" runat="server" meta:resourcekey="lbl_ReportingMgr"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="rtxt_ReportingMgr" runat="server" Skin="WebBlue">
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_ApprovalDate" runat="server" meta:resourcekey="lbl_ApprovalDate"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadDatePicker ID="rdp_ApprovalDate" runat="server" Enabled="false" Skin="WebBlue">
                                            </telerik:RadDatePicker>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td colspan="3" style="width: 425px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
                            <asp:LinkButton ID="Lnk_leavedetails0" runat="server" OnClientClick="ShowPop();" Visible="false">Leave Details</asp:LinkButton>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="ShowPoprolback();" Visible="false">Roll Back</asp:LinkButton>
                            </td>
                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btn_Approve" runat="server" meta:resourcekey="btn_Approve" OnClick="btn_Approve_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btn_Reject" runat="server" meta:resourcekey="btn_Reject" OnClick="btn_Reject_Click" />
                            </td>
                            <td>
                                <asp:Button ID="Button2" Text="Cancel" runat="server" OnClick="btn_Cancel_Click" />
                            </td>
                            <td colspan="3" style="width: 200px" align="right">
                                <asp:LinkButton ID="Lnk_leavebalance0" runat="server" OnClientClick="ShowPopup();" Visible="false">Leave Balances</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadGrid ID="RG_LeaveApproval" runat="server" PagerStyle-AlwaysVisible="true"
                        AllowPaging="true" Skin="WebBlue" GridLines="None" AutoGenerateColumns="false"
                        PageSize="5" OnNeedDataSource="RG_LeaveApproval_NeedDataSource">
                        <HeaderContextMenu Skin="WebBlue">
                        </HeaderContextMenu>
                        <MasterTableView>
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="Choose" HeaderStyle-Width="30px">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk_Choose" runat="server" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Employee&nbsp;ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblempID" runat="server" Text='<%# Eval("EMP_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Employee&nbsp;Code" HeaderStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblempcode" runat="server" Text='<%# Eval("EMP_EMPCODE") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Employee&nbsp;Name" HeaderStyle-Width="70px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblempName" runat="server" Text='<%# Eval("EMPLOYEENAME") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="EMPLOYEEGRADE_CODE" UniqueName="EMPLOYEEGRADE_CODE" HeaderText="Employee Grade"
                                    HeaderStyle-Width="40px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="Leave ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLeavetypeid" runat="server" Text='<%# Eval("LEAVEAPP_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="LEAVE&nbsp;ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLeaveID" runat="server" Text='<%# Eval("LEAVEMASTER_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Leave&nbsp;Type" HeaderStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblempLeave" runat="server" Text='<%# Eval("LEAVEMASTER_CODE") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Applied&nbsp;Date" HeaderStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblempApplied" runat="server" Text='<%# Eval("LEAVEAPP_APPLIEDDATE") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="From&nbsp;Date" HeaderStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblempFrom" runat="server" Text='<%# Eval("LEAVEAPP_FROMDATE") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="To&nbsp;Date" HeaderStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblempTo" runat="server" Text='<%# Eval("LEAVEAPP_TODATE") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Leave&nbsp;Days" HeaderStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblempLeaveDays" runat="server" Text='<%# Eval("LEAVEAPP_DAYS") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Status" HeaderStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblempStatus" runat="server" Text='<%# Eval("LEAVEAPP_STATUS") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Reason" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblempReason" runat="server" Text='<%# Eval("LEAVEAPP_REASON") %>'></asp:Label>
                                        <asp:Label runat="server" ID="lblPrdID" Text='<%# Eval("LEAVEAPP_CAL_PERIOD") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Document" HeaderStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="lnkView" runat="server" Target="_blank" NavigateUrl='<%#Eval("LEAVEAPP_DOCUMENT") %>' Text="View" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Reason For Rejection" HeaderStyle-Width="120px">
                                    <ItemTemplate>
                                        <telerik:RadTextBox ID="rtxt_rej_reason" runat="server" MaxLength="100" TextMode="MultiLine">
                                        </telerik:RadTextBox>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </telerik:GridTemplateColumn>
                                <%--<telerik:GridTemplateColumn UniqueName="Edit">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("EMP_ID") %>'>View
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>--%>
                            </Columns>
                            <EditFormSettings>
                            </EditFormSettings>
                        </MasterTableView>
                        <GroupingSettings CaseSensitive="false" />
                        <FilterMenu Skin="WebBlue">
                        </FilterMenu>
                    </telerik:RadGrid>
                </td>
            </tr>
        </table>
        <br />
    </div>
</asp:Content>