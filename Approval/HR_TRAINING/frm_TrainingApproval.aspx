<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_TrainingApproval.aspx.cs" Inherits="Training_frm_TrainingApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadScriptBlock ID="Rsb_Scripts" runat="server">

       <%-- <script language="javascript" type="text/javascript">
            function ShowPopForm(url) {
                var win = window.radopen('../Payroll/frm_ExpenseTrans.aspx?POP=1&EXPID=' + url, "rwin_Pop");
                // win.maximize();
                win.center();
                win.set_modal(true);
            }
        </script>--%>

    </telerik:RadScriptBlock>
    <table align="center">
        <tr>
            <td>
                <div style="height: 490px; width: 1014px; overflow: auto;">
                    <table align="center">
                        <tr>
                            <td align="center">
                                <asp:Label ID="lbl_TrainingApproval" runat="server"  Text="Training Approval"
                                    Style="font-weight: 700"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                                <table align="center">
                                  <%--  <tr style="display: none">
                                        <td>
                                            <asp:Label ID="lbl_ReportingMgr" runat="server" meta:resourcekey="lbl_ReportingMgr"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadTextBox EnableEmbeddedSkins="false" ID="rtxt_ReportingMgr" Skin="WebBlue"
                                                runat="server" Width="125px">
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_ApprovalDate" runat="server" Text="Approval Date"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadDatePicker  ID="rdp_ApprovalDate" runat="server"
                                                Culture="English (United States)">
                                                <DateInput LabelCssClass="" Width="" Skin="WebBlue">
                                                </DateInput>
                                                <Calendar Skin="WebBlue" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                                                    ViewSelectorText="x">
                                                </Calendar>
                                                <DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                                            </telerik:RadDatePicker>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" align="center">
                                            <asp:Button ID="btn_Approve"  runat="server"  Text="Approve" OnClick="btn_Approve_Click" />
                                            <asp:Button ID="btn_Reject" runat="server" Text="Reject" OnClick="btn_Reject_Click" />
                                           <%-- <asp:Button ID="btn_Refresh" runat="server" OnClick="btn_Refresh_Click" Text="Refresh" />--%>
                                            <asp:Button ID="btn_Cancel" runat="server" OnClick="btn_Cancel_Click" Text="Cancel" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <telerik:RadGrid  ID="RG_TrainingApproval" runat="server"
                                    Skin="WebBlue" GridLines="None" AutoGenerateColumns="False" OnNeedDataSource="RG_TrainingApproval_NeedDataSource">
                                    <HeaderContextMenu Skin="WebBlue">
                                    </HeaderContextMenu>
                                    <MasterTableView>
                                        <Columns>
                                            <telerik:GridTemplateColumn HeaderText="CHOOSE">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chk_Choose" runat="server" />
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Training_id" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbltrgID" runat="server" Text='<%# Eval("TR_ID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="EMPLOYEE&nbsp;NAME" meta:resourcekey="GridTemplateColumnResource4">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblempName" runat="server" Text='<%# Eval("EMPNAME") %>'></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="TRAINING&nbsp;NAME">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblempExpense" runat="server" Text='<%# Eval("Training") %>'></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                           
                                            <telerik:GridTemplateColumn HeaderText="STATUS">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblempStatus" runat="server" Text='<%# Eval("TR_STATUS") %>'></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                          <%--  <telerik:GridTemplateColumn UniqueName="Edit">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("TR_ID") %>'
                                                        OnCommand="lnk_Edit_Command">View
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
