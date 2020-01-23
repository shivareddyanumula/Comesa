<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_TrainingRequest.aspx.cs" Inherits="Training_frm_TrainingRequest" %>


<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center" style="vertical-align: top;">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_CourseHeader" runat="server" Text="Training Request" Font-Bold="True" meta:resourcekey="lbl_Course"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_Course_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_Course_ViewMain" runat="server" Selected="True">
                        <table align="center">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_Course" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        Skin="WebBlue" OnNeedDataSource="Rg_Course_NeedDataSource" AllowPaging="True"
                                        AllowFilteringByColumn="true">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="TRAINING_REQUEST_ID" UniqueName="TRAINING_REQUEST_ID" HeaderText="ID"
                                                    meta:resourcekey="TRAINING_REQUEST_ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="COURSE_NAME" UniqueName="COURSE_NAME"
                                                    HeaderText="Course Name" meta:resourcekey="COURSE_NAME">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>

                                                <telerik:GridBoundColumn DataField="COURSESCHEDULE_NAME" UniqueName="COURSESCHEDULE_NAME"
                                                    HeaderText="Batch Name" meta:resourcekey="COURSESCHEDULE_NAME">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <%-- <telerik:GridBoundColumn DataField="CourseSchedule_StartDate" UniqueName="CourseSchedule_StartDate"
                                                    HeaderText="Course Start Date" meta:resourcekey="CourseSchedule_StartDate" DataFormatString="{0:dd/MM/yyyy}">
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


                                                <%--  <telerik:GridBoundColumn DataField="CourseSchedule_EndDate" UniqueName="CourseSchedule_EndDate"
                                                    HeaderText="Course End Date" meta:resourcekey="CourseSchedule_EndDate"  DataFormatString="{0:dd/MM/yyyy}">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>--%>
                                                <telerik:GridBoundColumn DataField="TRAINING_REQUEST_ISAPPROVED" UniqueName="TRAINING_REQUEST_ISAPPROVED" HeaderText="Training Request Status"
                                                    meta:resourcekey="TRAINING_REQUEST_ISAPPROVED">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                            </Columns>
                                            <EditFormSettings>
                                                <EditColumn CancelImageUrl="Cancel.gif" EditImageUrl="Edit.gif" InsertImageUrl="Update.gif"
                                                    UpdateImageUrl="Update.gif">
                                                </EditColumn>
                                            </EditFormSettings>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" meta:resourceKey="lnk_Add" OnCommand="lnk_Add_Command">Apply</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <PagerStyle AlwaysVisible="True" />
                                        <FilterMenu Skin="WebBlue">
                                        </FilterMenu>
                                        <HeaderContextMenu Skin="WebBlue">
                                        </HeaderContextMenu>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_Course_ViewDetails" runat="server">
                        <table align="center">
                            <tr>
                                <td colspan="6" align="center" style="font-weight: bold;">
                                    <asp:Label ID="lbl_Location" runat="server" Text="Training Request" meta:resourcekey="lbl_Location"></asp:Label>
                                    <br />
                                    <br />
                                </td>
                            </tr>

                            <tr>
                                <td></td>
                                <td></td>
                                <td align="right">
                                    <asp:Label ID="lblTrainigRequestId" runat="server" Visible="False" meta:resourcekey="lblTrainigRequestId"></asp:Label>
                                    <asp:Label ID="lblCourse" runat="server" Text="Course Name" meta:resourcekey="lblCourse"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="radCourse" runat="server" Skin="WebBlue" AutoPostBack="true" OnSelectedIndexChanged="radCourse_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>

                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="radCourse"
                                        meta:resourcekey="rfv_rcmb_CC" ErrorMessage="Please Select Course" InitialValue="Select"
                                        Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>


                            </tr>
                            <tr>
                                <td colspan="6">
                                    <br />
                                    <br />
                                    <telerik:RadGrid ID="RGBatcheDetails" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        Skin="WebBlue" AllowPaging="True" OnNeedDataSource="RGBatcheDetails_NeedDataSource"
                                        AllowFilteringByColumn="true" Width="800px">
                                        <MasterTableView>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="CourseSchedule_ID" UniqueName="CourseSchedule_ID" HeaderText="ID"
                                                    meta:resourcekey="CourseSchedule_ID" Visible="False">
                                                </telerik:GridBoundColumn>

                                                <telerik:GridBoundColumn DataField="CourseSchedule_Name" UniqueName="CourseSchedule_Name"
                                                    HeaderText="Batch Name" meta:resourcekey="CourseSchedule_Name" FilterControlWidth="70%">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <%-- <telerik:GridBoundColumn DataField="CourseSchedule_StartDate" UniqueName="CourseSchedule_StartDate"
                                                    HeaderText="Course Start Date" meta:resourcekey="CourseSchedule_StartDate" DataFormatString="{0:dd/MM/yyyy}">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                 <telerik:GridBoundColumn DataField="CourseSchedule_EndDate" UniqueName="CourseSchedule_EndDate"
                                                    HeaderText="Course End Date" meta:resourcekey="CourseSchedule_EndDate"  DataFormatString="{0:dd/MM/yyyy}">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>--%>

                                                <telerik:GridDateTimeColumn DataField="CourseSchedule_StartDate" DataFormatString="{0:dd/MM/yyyy}" UniqueName="CourseSchedule_StartDate"
                                                    HeaderText="Course Start Date" meta:resourcekey="CourseSchedule_StartDate" FilterControlWidth="80%" PickerType="DatePicker">
                                                    <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                                </telerik:GridDateTimeColumn>
                                                <telerik:GridDateTimeColumn DataField="CourseSchedule_EndDate" DataFormatString="{0:dd/MM/yyyy}" UniqueName="CourseSchedule_EndDate"
                                                    HeaderText="Course End Date" meta:resourcekey="CourseSchedule_EndDate" FilterControlWidth="80%">
                                                    <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                                </telerik:GridDateTimeColumn>

                                                <telerik:GridBoundColumn DataField="TrainerName" UniqueName="TrainerName" HeaderText="Trainer Name"
                                                    meta:resourcekey="TrainerName" FilterControlWidth="70%">
                                                    <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Location_Name" UniqueName="Location_Name" HeaderText="Location Name"
                                                    meta:resourcekey="Location_Name" FilterControlWidth="70%">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" AllowFiltering="false" meta:resourcekey="GridTemplateColumnResource1">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Apply" runat="server" CommandArgument='<%# Eval("CourseSchedule_ID") %>'
                                                            OnCommand="lnk_Apply_Command" meta:resourcekey="lnk_Apply">Apply</asp:LinkButton>
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
                                <td align="center" colspan="5 ">

                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click"
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