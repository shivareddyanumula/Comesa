<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_CompOffApproval.aspx.cs" Inherits="Approval_frm_CompOffApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadScriptBlock ID="Rsb_Scripts" runat="server">
        <%--  <script language="javascript" type="text/javascript">
            function ShowPopForm(url) {
                var win = window.radopen('../Payroll/frm_ExpenseTrans.aspx?POP=1&EXPID=' + url, "rwin_Pop");
                // win.maximize();
                win.center();
                win.set_modal(true);
            }
        </script>--%>

        <script type="text/javascript">
            function changeFormat() {

                var dateInput = $find('<%= rdp_ApprovalDate.ClientID %>').get_dateInput();

                dateInput.set_dateFormat("MMM yyyy");

                dateInput.set_displayDateFormat("MMM yyyy");

                dateInput.updateDisplayValue();

            }
        </script>

    </telerik:RadScriptBlock>
    <table align="center">
        <tr>
            <td>
                <div style="height: 490px; width: 990px; overflow: auto;">
                    <table align="center" width="990px">
                        <tr>
                            <td align="center">
                                <asp:Label ID="lbl_CompoffApproval" runat="server" meta:resourcekey="lbl_CompoffApproval"
                                    Style="font-weight: 700"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                                <table align="center">
                                    <tr style="display: none">
                                        <td>
                                            <asp:Label ID="lbl_CReportingMgr" runat="server" meta:resourcekey="lbl_CReportingMgr"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="rtxt_ReportingMgr" Skin="WebBlue" runat="server" Width="125px">
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_ApprovalDate" runat="server" meta:resourcekey="lbl_ApprovalDate"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <%--            <telerik:RadDatePicker ID="rdp_ApprovalDate" runat="server" 
                                                Culture="English (United States)">
                                                <DateInput DateFormat="M/d/yyyy" DisplayDateFormat="M/d/yyyy">
                                            </DateInput>
                                                <Calendar Skin="WebBlue" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                                                    ViewSelectorText="x" runat="server">
                                                </Calendar>
                                                <DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                                            </telerik:RadDatePicker>--%>
                                            <telerik:RadDatePicker ID="rdp_ApprovalDate" runat="server" Width="208px" ShowPopupOnFocus="True">
                                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                </Calendar>
                                                <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="21" />
                                                <DateInput DateFormat="M/d/yyyy" DisplayDateFormat="M/d/yyyy" TabIndex="21">
                                                </DateInput>
                                            </telerik:RadDatePicker>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="center" style="margin-left: 80px">
                                            <asp:Button ID="btn_Approve" runat="server" meta:resourcekey="btn_Approve" OnClick="btn_Approve_Click" />
                                            &nbsp;<asp:Button ID="btn_Reject" runat="server" meta:resourcekey="btn_Reject" OnClick="btn_Reject_Click" />
                                            &nbsp;<asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <telerik:RadGrid ID="RG_CompoffApproval" runat="server" Skin="WebBlue" GridLines="None"
                                    AutoGenerateColumns="False" OnNeedDataSource="RG_CompoffApproval_NeedDataSource"
                                    AllowFilteringByColumn="true">
                                    <HeaderContextMenu Skin="WebBlue">
                                    </HeaderContextMenu>
                                    <MasterTableView>
                                        <Columns>
                                            <telerik:GridTemplateColumn HeaderText="Choose">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chk_Choose" runat="server" />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Expense&nbsp;ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCompoffID" runat="server" Text='<%# Eval("EMPCOMPOFF_ID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Employee&nbsp;ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEMPID" runat="server" Text='<%# Eval("EMPCOMPOFF_EMPID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Employee&nbsp;Name" meta:resourcekey="GridTemplateColumnResource4">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblempName" runat="server" Text='<%# Eval("EMPNAME") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="HR_MASTER_CODE" UniqueName="HR_MASTER_CODE" HeaderText="Employee Grade">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn HeaderText="Work Day">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblWorkDay" runat="server" Text='<%# Eval("EMPCOMPOFF_WORKDAY")%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </telerik:GridTemplateColumn>
                                            <%--<telerik:GridTemplateColumn HeaderText="Compoff Day">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCompoffkDay" runat="server" Text='<%# Eval("EMPCOMPOFF_COMPOFFDAY") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </telerik:GridTemplateColumn>--%>
                                            <telerik:GridTemplateColumn HeaderText="Leave&nbsp;Type" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblleavetype" runat="server" Text='<%# Eval("EMPCOMPOFF_LEAVETYPE") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Login&nbsp;Time">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbllogintime" runat="server" Text='<%# Eval("EMPCOMPOFF_LOGINTIME") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Logout&nbsp;Time">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLogoutTime" runat="server" Text='<%# Eval("EMPCOMPOFF_LOGOUTTIME") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Aapplied&nbsp;Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCompoffApplied" runat="server" Text='<%# Eval("EMPCOMPOFF_APPLIEDDATE","{0:dd/MM/yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblempStatus" runat="server" Text='<%# Eval("EMPCOMPOFF_STATUS") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Reason">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblempReason" runat="server" Text='<%# Eval("EMPCOMPOFF_REASON") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Remarks" Visible="false">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt_AppRemarks" runat="server"></asp:TextBox>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </telerik:GridTemplateColumn>
                                            <%--<telerik:GridTemplateColumn UniqueName="Edit">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("EMPCOMPOFF_ID") %>'
                                                        >"View"
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>--%>
                                        </Columns>
                                    </MasterTableView>
                                </telerik:RadGrid>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
