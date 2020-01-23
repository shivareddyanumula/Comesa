<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_AttendanceDetails.aspx.cs" Inherits="HR_TRAINING_frm_AttendanceDetails" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
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
                                <asp:Label ID="lbl_AttendanceDteails" runat="server" Text="Attendance Details"
                                    Style="font-weight: 700"></asp:Label>
                            </td>
                        </tr>

                        <tr>
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
                                            <telerik:RadComboBox ID="rc_Course" runat="server" AutoPostBack="true" Filter="Contains"
                                                Height="200" OnSelectedIndexChanged="radCourse_SelectedIndexChanged">
                                            </telerik:RadComboBox>

                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rvf_Course" runat="server" ControlToValidate="rc_Course"
                                                meta:resourcekey="rvf_Course" ErrorMessage="Please Select Course" InitialValue="Select"
                                                Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td align="left">
                                            <asp:Label ID="Label1" runat="server" Visible="False" meta:resourcekey="lblTrainigRequestId"></asp:Label>
                                            <asp:Label ID="lbl_CourseSchedule" runat="server" Text="Course Schedule" meta:resourcekey="lblCourse"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rc_CourseSchedule" runat="server" Skin="WebBlue" AutoPostBack="true" Filter="Contains"
                                                Height="200" OnSelectedIndexChanged="rc_CourseSchedule_SelectedIndexChanged">
                                            </telerik:RadComboBox>

                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_CourseSchedule" runat="server" ControlToValidate="rc_CourseSchedule"
                                                meta:resourcekey="rfv_CourseSchedule" ErrorMessage="Please Select Course Schedule" InitialValue="Select"
                                                Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td align="left">
                                            <asp:Label ID="ll" runat="server" Text="Days" meta:resourcekey="lblCourse"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rc_Days" runat="server" Skin="WebBlue" Width="80px" AutoPostBack="true" Filter="Contains"
                                                Height="200" OnSelectedIndexChanged="rc_Days_SelectedIndexChanged">
                                                <%-- <Items>
                                                        <telerik:RadComboBoxItem runat="server" Text="Select" Value="-1" />
                                                        <telerik:RadComboBoxItem runat="server" Text="1" Value="0" />
                                                        <telerik:RadComboBoxItem runat="server" Text="2" Value="1" />
                                                         <telerik:RadComboBoxItem runat="server" Text="3" Value="0" />
                                                         <telerik:RadComboBoxItem runat="server" Text="4" Value="1" />
                                                         <telerik:RadComboBoxItem runat="server" Text="5" Value="0" />
                                                          <telerik:RadComboBoxItem runat="server" Text="6" Value="1" />
                                                         <telerik:RadComboBoxItem runat="server" Text="7" Value="0" />
                                                          <telerik:RadComboBoxItem runat="server" Text="8" Value="1" />
                                                         <telerik:RadComboBoxItem runat="server" Text="9" Value="0" />
                                                         <telerik:RadComboBoxItem runat="server" Text="10" Value="1" />
                                                       
                                                                   </Items>--%>
                                            </telerik:RadComboBox>

                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_Days" runat="server" ControlToValidate="rc_Days"
                                                meta:resourcekey="rfv_rcmb_CC" ErrorMessage="Please Select Day" InitialValue="Select"
                                                Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td align="left"></td>

                                        <td></td>
                                        <td></td>
                                        <td></td>

                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <telerik:RadGrid ID="RG_TrainingApproval" runat="server" AutoGenerateColumns="False" GridLines="None" Visible="false"
                                    Skin="WebBlue">
                                    <MasterTableView>
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="TRAINING_REQUEST_RAISEDBY" UniqueName="TRAINING_REQUEST_RAISEDBY" HeaderText="ID"
                                                meta:resourcekey="TRAINING_REQUEST_RAISEDBY" Visible="False">
                                            </telerik:GridBoundColumn>

                                            <telerik:GridBoundColumn DataField="EMP_Name" UniqueName="EMP_Name"
                                                HeaderText="Employee Name" meta:resourcekey="EMP_NAME">
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </telerik:GridBoundColumn>


                                            <telerik:GridTemplateColumn HeaderText="Trng Request ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRqstID" runat="server" Text='<%# Eval("TRAINING_REQUEST_RAISEDBY") %>'></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="ColApprove" AllowFiltering="false" meta:resourcekey="GridTemplateColumnResource1" HeaderText="Attendance">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="rad_IsActive" runat="server" Checked='<%# Convert.ToBoolean(Eval("Attended")) %>'></asp:CheckBox>
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
                        <tr>
                            <td align="center">
                                <asp:Button ID="btn_submit" runat="server" Text="Save" Visible="false" OnClick="btn_submit_Click" ValidationGroup="Controls" />
                                <asp:Button ID="Btn_cancel" runat="server" Text="Cancel" Visible="false" OnClick="Btn_cancel_Click" />
                                <asp:ValidationSummary ID="vs_TrainerProf" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="Controls" />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>