<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_JobRequisitionApproval.aspx.cs" Inherits="Approval_frm_JobRequisitionApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
   <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            function ShowPop(JOBREQ_ID) {
                var win = window.radopen('../Recruitment/frm_ViewJobReq.aspx?JOBREQ_ID=' + JOBREQ_ID, "RW_JobRequisition");
                win.center();
                //win.height = 30;
                win.width = "500px";
                win.set_modal(true);
            }
        </script>
    </telerik:RadScriptBlock>
    <table align="center">
        <tr>
            <td>
               <%-- <div style="height: 490px; width: 980px; overflow: auto;">--%>
                    <table align="center">
                        <tr>
                            <td align="center" colspan = "3">
                                <asp:Label ID="lbl_JRApproval" runat="server" meta:resourcekey="lbl_JRApproval" Font-Bold="True" ></asp:Label>
                            </td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                           <td></td>
                            <td></td>
                             <td></td>
                        </tr>
                        <tr style="display: none">
                            <td>
                                <asp:Label ID="lbl_Approver1" runat="server" meta:resourcekey="lbl_Approver1"></asp:Label>
                            </td>
                            <td>
                                <b>:</b>
                            </td>
                            <td>
                                <telerik:RadTextBox EnableEmbeddedSkins="false" ID="rtxt_Approver" runat="server"
                                    Skin="WebBlue">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbl_JRApprovalDate" runat="server" meta:resourcekey="lbl_JRApprovalDate"></asp:Label>
                            </td>
                            <td>
                                <b>:</b>
                            </td>
                            <td>
                                <telerik:RadDatePicker EnableEmbeddedSkins="false" ID="rdp_JRApprovalDate" runat="server"
                                    Skin="WebBlue">
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
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btn_JRApprove" runat="server" meta:resourcekey="btn_JRApprove" OnClick="btn_JRApprove_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btn_JRReject" runat="server" meta:resourcekey="btn_JRReject" OnClick="btn_JRReject_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btn_JRCancel" Text="Cancel" runat="server" meta:resourcekey="btn_JRCancel"
                                                OnClick="btn_JRCancel_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <%--//AllowPaging="True"  PageSize="5"--%>
                                <telerik:RadGrid ID="RG_JRApproval" runat="server" Skin="WebBlue" GridLines="None"
                                    OnNeedDataSource="rgap_needsource" AutoGenerateColumns="false"
                                    AllowPaging="True" PageSize="5" AllowFilteringByColumn="True">
                                    <%-- Width="900px" Height="350px">--%>
                                    <HeaderContextMenu Skin="WebBlue">
                                    </HeaderContextMenu>
                                    <MasterTableView>
                                       <%-- <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>--%>
                                        <Columns>
                                            <telerik:GridTemplateColumn HeaderText="Choose" AllowFiltering="false">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chk_Choose" runat="server" />
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                           <%-- <telerik:GridTemplateColumn HeaderText="EPMLOYEE&nbsp;ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblempID" runat="server" Text='<%# Eval("EMPID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>--%>
                                           <%-- <telerik:GridBoundColumn DataField="EMP_EMPCODE" UniqueName="EMP_EMPCODE" HeaderText="Employee&nbsp;Code">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </telerik:GridBoundColumn>--%>
                                            <telerik:GridBoundColumn DataField="EMPNAME" UniqueName="EMPNAME" HeaderText="Requisition Raised by">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn HeaderText="JOBID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbljrID" runat="server" Text='<%# Eval("JOBREQ_ID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="JOBREQ_REQCODE" UniqueName="JOBREQ_REQCODE" HeaderText="Requisition&nbsp;Code">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="JOBREQ_REQNAME" UniqueName="JOBREQ_REQNAME" HeaderText="Requisition&nbsp;Name">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </telerik:GridBoundColumn>
                                            <%-- <telerik:GridBoundColumn DataField="JOBREQ_REQDATE" UniqueName="JOBREQ_REQDATE" HeaderText="JOB&nbsp;REQUISITION&nbsp;RAISEDDATE">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                           </telerik:GridBoundColumn>
                                           <telerik:GridBoundColumn DataField="JOBREQ_REQEXPIRY" UniqueName="JOBREQ_REQEXPIRY" HeaderText="JOB&nbsp;REQUISITION&nbsp;EXPIRYDATE">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                           </telerik:GridBoundColumn>--%>
                                            <telerik:GridNumericColumn DataField="JOBREQ_EXPYEARS" UniqueName="JOBREQ_EXPYEARS"
                                                HeaderText="Experience">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </telerik:GridNumericColumn>
                                            <telerik:GridBoundColumn DataField="JOBREQ_QUALIFICATION" UniqueName="JOBREQ_QUALIFICATION"
                                                HeaderText="QUALIFICATION" Visible = "false">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="JOBREQ_PERCENTAGE" UniqueName="JOBREQ_PERCENTAGE"
                                                HeaderText="PERCENTAGE" Visible = "false">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbljrstatus" runat="server" Text='<%# Eval("JOBREQ_APPROVALSTATUS") %>'></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn AllowFiltering="False" UniqueName="Edit" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="80px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnk_ViewDetails" runat="server" CommandArgument='<%# Eval("JOBREQ_ID") %>' OnCommand="lnk_ViewDetailsCommand" 
                                                        meta:resourcekey="lnk_ViewDetails" >View Details</asp:LinkButton>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="APPROVER1_EMAIL" UniqueName="APPROVER1_EMAIL"
                                                HeaderText="APPROVER1_EMAIL" Visible = "false">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="APPROVER2_EMAIL" UniqueName="APPROVER2_EMAIL"
                                                HeaderText="APPROVER2_EMAIL" Visible = "false">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </telerik:GridBoundColumn>
                                             <telerik:GridBoundColumn DataField="APPROVER3_EMAIL" UniqueName="APPROVER3_EMAIL"
                                                HeaderText="APPROVER3_EMAIL" Visible = "false">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="EMAIL" UniqueName="EMAIL"
                                                HeaderText="EMAIL" Visible = "false">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </telerik:GridBoundColumn>
                                             <telerik:GridBoundColumn DataField="EMPNAME_APPROVER1" UniqueName="EMPNAME_APPROVER1"
                                                HeaderText="EMPNAME_APPROVER1" Visible = "false">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </telerik:GridBoundColumn>
                                             <telerik:GridBoundColumn DataField="EMPNAME_APPROVER2" UniqueName="EMPNAME_APPROVER2"
                                                HeaderText="EMPNAME_APPROVER2" Visible = "false">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="EMPNAME_APPROVER3" UniqueName="EMPNAME_APPROVER3"
                                                HeaderText="EMPNAME_APPROVER3" Visible = "false">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                       <%-- <EditFormSettings>
                                            <EditColumn InsertImageUrl="Update.gif" UpdateImageUrl="Update.gif" EditImageUrl="Edit.gif"
                                                CancelImageUrl="Cancel.gif">
                                            </EditColumn>
                                        </EditFormSettings>
                                    
                                    <ClientSettings>
                                        <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="True" FrozenColumnsCount="1">
                                        </Scrolling>
                                    </ClientSettings>
                                    <FilterMenu Skin="WebBlue">
                                    </FilterMenu>--%>
                                    </MasterTableView>
                                </telerik:RadGrid>
                            </td>
                        </tr>
                    </table>
 </td> </tr> </table>
</asp:Content>
