<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_CourseSchedule.aspx.cs" Inherits="HR_TRAINING_frm_CourseSchedule" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center" style="vertical-align: top;">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_CourseHeader" runat="server" Text="Course Schedule" Font-Bold="True" meta:resourcekey="lbl_Course"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_Course_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_Course_ViewMain" runat="server" Selected="True">
                        <table align="center" width="45%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_Course" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        Skin="WebBlue" OnNeedDataSource="Rg_Course_NeedDataSource" AllowPaging="True"
                                        AllowFilteringByColumn="true">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="CourseSchedule_ID" UniqueName="CourseSchedule_ID" HeaderText="ID"
                                                    meta:resourcekey="CourseSchedule_ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                
                                                <telerik:GridBoundColumn DataField="CourseSchedule_Name" UniqueName="CourseSchedule_Name"
                                                    HeaderText="CourseSchedule Name" meta:resourcekey="CourseSchedule_Name">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="COURSE_NAME" UniqueName="COURSE_NAME" HeaderText="Course Name"
                                                    meta:resourcekey="Location_ContactPerson">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>

                                                <telerik:GridBoundColumn DataField="Location_Name" UniqueName="Location_Name" HeaderText="Location Name"
                                                    meta:resourcekey="Location_Name">
                                                     <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                 <telerik:GridBoundColumn DataField="ACTIVE_STATUS" UniqueName="ACTIVE_STATUS"
                                                    AllowFiltering="true" HeaderText="Status" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="GridTemplateColumnResource1" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("CourseSchedule_ID") %>'
                                                            OnCommand="lnk_Edit_Command" meta:resourcekey="lnk_Edit">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <EditFormSettings>
                                                <EditColumn CancelImageUrl="Cancel.gif" EditImageUrl="Edit.gif" InsertImageUrl="Update.gif"
                                                    UpdateImageUrl="Update.gif">
                                                </EditColumn>
                                            </EditFormSettings>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" meta:resourceKey="lnk_Add" OnCommand="lnk_Add_Command">Add</asp:LinkButton>
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
                                <td align="left">
                                     <asp:Label ID="lblCourseScheduleID" runat="server" Visible="False" meta:resourcekey="lblCourseScheduleID"></asp:Label>
                                    <asp:Label ID="lblCourse" runat="server" Text="Course" meta:resourcekey="lblCourse"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                 <td>
                                    <telerik:RadComboBox ID="radCourse" runat="server" Skin="WebBlue"  
                                        AutoPostBack="true" OnSelectedIndexChanged="radCourse_SelectedIndexChanged"
                                        MarkFirstMatch="true" MaxHeight="120px" TabIndex="1" Filter="Contains">
                                    </telerik:RadComboBox>                               
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="radCourse"
                                        meta:resourcekey="rfv_rcmb_CC" ErrorMessage="Please Select Course" InitialValue="Select"
                                        Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblCourseType" runat="server" Text="Course Type" meta:resourcekey="lblCourseType"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                 <td>
                                    <telerik:RadComboBox ID="radCourseType" runat="server" Skin="WebBlue" MarkFirstMatch="true" MaxHeight="120px" TabIndex="2"
                                         Filter="Contains">
                                    </telerik:RadComboBox>                                
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="radCourseType"
                                        meta:resourcekey="rfv_rcmb_CC" ErrorMessage="Please Select Course Type" InitialValue="Select"
                                        Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                   
                                    <asp:Label ID="lbl_Loaction" runat="server" Text="Location" meta:resourcekey="lbl_StreetName"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                     <telerik:RadComboBox ID="radLocation" runat="server" Skin="WebBlue" MarkFirstMatch="true" MaxHeight="120px" AutoPostBack="true" 
                                     OnSelectedIndexChanged="radLocation_SelectedIndexChanged" TabIndex="3" Filter="Contains">
                                    </telerik:RadComboBox>                                
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="radLocation"
                                        meta:resourcekey="rfv_rcmb_CC" ErrorMessage="Please Select Location" InitialValue="Select"
                                        Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                                <td align="left">
                                   
                                    <asp:Label ID="lblClassRoom" runat="server" Text="Training Room" meta:resourcekey="lblClassRoom"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                     <telerik:RadComboBox ID="radTrainingRoom" runat="server" Skin="WebBlue" MarkFirstMatch="true" MaxHeight="120px" TabIndex="4" Filter="Contains">
                                    </telerik:RadComboBox>                                
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="radTrainingRoom"
                                        meta:resourcekey="rfv_rcmb_CC" ErrorMessage="Please Select Training Room" InitialValue="Select"
                                        Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                                 </tr>
                             <tr>
                                <td align="left">
                                    <asp:Label ID="lblSessions" runat="server" Text="No of Days" meta:resourcekey="lblSessions"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                 <td>
                                    <telerik:RadNumericTextBox ID="radSessions" runat="server" Skin="WebBlue" NumberFormat-GroupSeparator="" NumberFormat-DecimalDigits="0" TabIndex="5" MaxLength="2" minvalue="0">
                                    </telerik:RadNumericTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="radSessions"
                                        meta:resourcekey="rfv_rcmb_CC" ErrorMessage="Please Enter No Of Days" 
                                        Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                           
                                <td align="left">
                                    <asp:Label ID="lblSeats" runat="server" Text="No Of Seats" meta:resourcekey="lblSeats"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                 <td>
                                    <telerik:RadNumericTextBox ID="radSeats" runat="server" Skin="WebBlue"  MaxLength="3" NumberFormat-GroupSeparator="" NumberFormat-DecimalDigits="0" TabIndex="6">
                                    </telerik:RadNumericTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="radSeats"
                                        meta:resourcekey="rfv_rcmb_CC" ErrorMessage="Please Enter No Of Seats" 
                                        Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                                  </tr>
                            <tr >
                                <td align="left">
                                    <asp:Label ID="lblStartDate" runat="server" Text="Start Date" meta:resourcekey="lblStartDate"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                 <td>                                   
                                     <telerik:RadDatePicker ID="radStartdate" runat="server"  MaxLength="50"  oncut="return false;" TabIndex="7">
                                      <DateInput ID="DateInput1"  DateFormat="dd/MM/yyyy" runat="server" DisplayDateFormat="dd/MM/yyyy"  ReadOnly="true" autocomplete="off" TabIndex="7">
                                       </DateInput>
                                    </telerik:RadDatePicker>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="radStartdate"
                                                        meta:resourcekey="rfv_DOJ" Text="*" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d" ErrorMessage="Please Select Start Date"
                                                        ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                               
                           
                                <td>                                    
                                    <asp:Label ID="lblStartTime" runat="server" Text="Start Time" meta:resourcekey="lblContactName"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTimePicker ID="radStartTime" runat="server" DateInput-ReadOnly="true" MinDate="1900-01-01"  MaxLength="50" Width="245px" TabIndex="8">
                                                                </telerik:RadTimePicker>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="radStartTime"
                                                        meta:resourcekey="rfv_DOJ" Text="*" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d" ErrorMessage="Please Select Start Time"
                                                        ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                                 </tr>
                            <tr >
                                <td align="left">
                                    <asp:Label ID="lblEndDate" runat="server" Text="End Date" meta:resourcekey="lblStartDate"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                 <td>                                   
                                     <telerik:RadDatePicker ID="radEndDate" runat="server" MaxLength="50"  oncut="return false;" TabIndex="9">
                                      <DateInput ID="DateInput2"  DateFormat="dd/MM/yyyy" runat="server" DisplayDateFormat="dd/MM/yyyy"  ReadOnly="true" autocomplete="off">
                                       </DateInput>
                                    </telerik:RadDatePicker>
                                      <asp:CompareValidator ID="cv_DOJ" runat="server" ControlToCompare="radStartdate" ControlToValidate="radEndDate"
                                                        Display="Dynamic" meta:resourcekey="cv_DOJ" Operator="GreaterThan" Text="*" Type="Date" ErrorMessage="End Date should be greater than Start Date"
                                                        ValidationGroup="Controls"></asp:CompareValidator>
                                                    <asp:RequiredFieldValidator ID="rfv_DOJ" runat="server" ControlToValidate="radEndDate"
                                                        meta:resourcekey="rfv_DOJ" Text="*" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d" ErrorMessage="Please Select End Date"
                                                        ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                               
                           
                                <td>                                    
                                    <asp:Label ID="lblEndTime" runat="server" Text="End Time" meta:resourcekey="lblContactName"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTimePicker ID="radEndTime" runat="server" DateInput-ReadOnly="true" MinDate="1900-01-01"  MaxLength="50" Width="245px" TabIndex="10">
                                                                </telerik:RadTimePicker>
                                     <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="radStartTime" ControlToValidate="radEndTime"
                                                        Display="Dynamic" meta:resourcekey="cv_DOJ" Operator="GreaterThan" Text="*" Type="String" ErrorMessage="End Time should be greater than Start Time"
                                                        ValidationGroup="Controls"></asp:CompareValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="radEndTime"
                                                        meta:resourcekey="rfv_DOJ" Text="*" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d" ErrorMessage="Please Select End Time"
                                                        ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                                 </tr>        
                           <tr>
                               <td align="left">
                                   
                                    <asp:Label ID="lblTrainers" runat="server" Text="Trainers" meta:resourcekey="lblClassRoom"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                     <telerik:RadComboBox ID="radTrainers" runat="server" Skin="WebBlue" MarkFirstMatch="true" MaxHeight="120px" TabIndex="11" Filter="Contains">
                                    </telerik:RadComboBox>                                
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="radTrainers"
                                        meta:resourcekey="rfv_rcmb_CC" ErrorMessage="Please Select Trainer" InitialValue="Select"
                                        Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                               <td align="left">
                                    <asp:Label ID="lblBatchDetail" runat="server" Text="CourseSchedule Name" meta:resourcekey="lblBatchDetail"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                 <td>
                                    <telerik:RadTextBox ID="radBatchDetail" runat="server" Skin="WebBlue" NumberFormat-GroupSeparator="" NumberFormat-DecimalDigits="0" TabIndex="12" MaxLength="120">
                                    </telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="radBatchDetail"
                                        meta:resourcekey="rfv_rcmb_CC" ErrorMessage="Please Enter Course Schedule Name" 
                                        Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                              </tr>
                            <tr>
                                 <td>
                                    <asp:Label ID="lbl_IsActive" runat="server" Text="Status"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <asp:CheckBox ID="rad_IsActive" runat="server" Checked="true" TabIndex="13">
                                    </asp:CheckBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="6">
                                    <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Edit" OnClick="btn_Save_Click"
                                        Text="Update" ValidationGroup="Controls" Visible="False" />
                                    <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click"
                                        Text="Save" ValidationGroup="Controls" Visible="False" />
                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click"
                                        Text="Cancel" />
                                    <asp:ValidationSummary ID="vs_Country" runat="server" ShowMessageBox="True" ShowSummary="False"
                                        ValidationGroup="Controls" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>


