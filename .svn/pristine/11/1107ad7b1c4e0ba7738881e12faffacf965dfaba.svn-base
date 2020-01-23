<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_TrainingApproval.aspx.cs" Inherits="Training_frm_TrainingApproval" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

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
                                <asp:Label ID="lbl_TrainingApproval" runat="server" Text="Training Approval"
                                    Style="font-weight: 700"></asp:Label>
                            </td>
                        </tr>

                        <%--<tr>
                            <td align="center">
                                <table>
                                    <tr>
                            <td></td>
                            <td></td>
                            <td align="left">
                                <asp:Label ID="lblTrainigRequestId" runat="server" Visible="False" meta:resourcekey="lblTrainigRequestId"></asp:Label>
                                <asp:Label ID="lblCourse" runat="server" Text="Course Name" meta:resourcekey="lblCourse"></asp:Label>
                            </td>
                            <td>:
                            </td>
                            <td>
                                <telerik:RadComboBox ID="radCourse" runat="server" Skin="WebBlue" AutoPostBack="true" OnSelectedIndexChanged="radCourse_SelectedIndexChanged">
                                </telerik:RadComboBox>

                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="radCourse"
                                    meta:resourcekey="rfv_rcmb_CC" ErrorMessage="Please Select Course" InitialValue="Select"
                                    Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                            </td>

                            </tr>
                                </table>
                            </td>
                        </tr>--%>
                        <tr>
                            <td>
                                <telerik:RadGrid ID="RG_TrainingApproval" runat="server" AutoGenerateColumns="False" GridLines="None" Visible="false"
                                    Skin="WebBlue" AllowPaging="True"
                                    AllowFilteringByColumn="true" OnNeedDataSource="RG_TrainingApproval_NeedDataSource" >
                                    <MasterTableView>
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="TRAINING_REQUEST_ID" UniqueName="TRAINING_REQUEST_ID" HeaderText="ID"
                                                meta:resourcekey="TRAINING_REQUEST_ID" Visible="False">
                                            </telerik:GridBoundColumn>

                                            <telerik:GridBoundColumn DataField="EMP_NAME" UniqueName="EMP_NAME"
                                                HeaderText="Employee Name" meta:resourcekey="EMP_NAME">
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="COURSE_NAME" UniqueName="COURSE_NAME"
                                                HeaderText="Course Name" meta:resourcekey="COURSE_NAME">
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </telerik:GridBoundColumn>
                                           <%-- <telerik:GridBoundColumn DataField="CourseSchedule_StartDate" UniqueName="CourseSchedule_StartDate"
                                                HeaderText="Course Start Date" meta:resourcekey="CourseSchedule_StartDate" DataFormatString="{0:dd/MM/yyyy}">
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CourseSchedule_EndDate" UniqueName="CourseSchedule_EndDate"
                                                HeaderText="Course End Date" meta:resourcekey="CourseSchedule_EndDate" DataFormatString="{0:dd/MM/yyyy}">
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </telerik:GridBoundColumn>--%>

                                            <telerik:GridDateTimeColumn DataField="CourseSchedule_StartDate" DataFormatString="{0:dd/MM/yyyy}" UniqueName="CourseSchedule_StartDate"
                                                                  HeaderText="Course Start Date" meta:resourcekey="CourseSchedule_StartDate">
                                                      <HeaderStyle HorizontalAlign="Center" />
                                                                </telerik:GridDateTimeColumn>
                                                 <telerik:GridDateTimeColumn DataField="CourseSchedule_EndDate" DataFormatString="{0:dd/MM/yyyy}" UniqueName="CourseSchedule_EndDate"
                                                                  HeaderText="Course End Date" meta:resourcekey="CourseSchedule_EndDate">
                                                      <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridDateTimeColumn>

                                            <telerik:GridBoundColumn DataField="COURSESCHEDULE_NAME" UniqueName="COURSESCHEDULE_NAME" HeaderText="Course Schedule Name"
                                                meta:resourcekey="COURSESCHEDULE_NAME">
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Location_Name" UniqueName="Location_Name" HeaderText="Location Name"
                                                meta:resourcekey="Location_Name">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn UniqueName="ColApprove" AllowFiltering="false" meta:resourcekey="GridTemplateColumnResource1">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnk_Apply" runat="server" CommandArgument='<%# Eval("TRAINING_REQUEST_ID") %>'
                                                        OnCommand="lnk_Apply_Command" meta:resourcekey="lnk_Apply">Approve</asp:LinkButton>&nbsp;&nbsp;&nbsp;
                                                    <asp:LinkButton ID="lnk_Reject" runat="server" CommandArgument='<%# Eval("TRAINING_REQUEST_ID") %>'
                                                        OnCommand="lnk_Apply_Command" meta:resourcekey="lnk_Reject">Reject</asp:LinkButton>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            
                                        </Columns>

                                    </MasterTableView>
                                    <PagerStyle AlwaysVisible="True" />
                                    <HeaderContextMenu Skin="WebBlue">
                                    </HeaderContextMenu>
                                </telerik:RadGrid>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
