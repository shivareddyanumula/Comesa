<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_offline Assessments.aspx.cs" Inherits="HR_TRAINING_frm_offline_Assessments" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">

    <table align="center" style="vertical-align: top;">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_CourseHeader" runat="server" Text="Offline Assessments" Font-Bold="True" meta:resourcekey="lbl_Course"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_Course_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_Course_ViewMain" runat="server" Selected="True">
                        <table align="center" width="50%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_Course" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        Skin="WebBlue" OnNeedDataSource="Rg_Course_NeedDataSource" AllowPaging="True"
                                        AllowFilteringByColumn="true">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="OFFLINEASSESSMENT_ID" UniqueName="OFFLINEASSESSMENT_ID" HeaderText="ID"
                                                    meta:resourcekey="OFFLINEASSESSMENT_ID" Visible="False">
                                                </telerik:GridBoundColumn>

                                                <telerik:GridBoundColumn DataField="OFFLINEASSESSMENT_NAME" UniqueName="OFFLINEASSESSMENT_NAME"
                                                    HeaderText="Assessment Name " meta:resourcekey="OFFLINEASSESSMENT_NAME">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                   <%-- <HeaderStyle HorizontalAlign="Center" />--%>
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="COURSE_NAME" UniqueName="COURSE_NAME" HeaderText="Course Name"
                                                    meta:resourcekey="COURSE_NAME">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="CourseSchedule_Name" UniqueName="CourseSchedule_Name" HeaderText="Course Schedule"
                                                    meta:resourcekey="CourseSchedule_Name">
                                                </telerik:GridBoundColumn>
                                                  <telerik:GridBoundColumn DataField="ACTIVE_STATUS" UniqueName="ACTIVE_STATUS"
                                                    AllowFiltering="true" HeaderText="Course Schedule Status" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn HeaderText="Download Assessment" AllowFiltering="false" >
                                                    <ItemTemplate>
                                                        <a id="D2" runat="server" target="_blank" href='<%#Eval("OFFLINEASSESSMENT_UPLOADEDDOC") %>'>Download Assessment</a>
                                                        <asp:Label ID="lbl_BioData" Text='<%#Eval("OFFLINEASSESSMENT_UPLOADEDDOC") %>' Visible="false"
                                                            runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                
                                                <telerik:GridTemplateColumn UniqueName="ColResult" HeaderText="View Assessment" meta:resourcekey="ColResult" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Result" runat="server" CommandArgument='<%# Eval("OFFLINEASSESSMENT_ID") %>'
                                                            OnCommand="lnk_Result_Command" meta:resourcekey="lnk_Result">View Assessment</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="GridTemplateColumnResource1" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("OFFLINEASSESSMENT_ID") %>'
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
                                         
                                        <ActiveItemStyle HorizontalAlign="Left" />
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
                        <asp:UpdatePanel ID="upnl" runat="server">
                            <ContentTemplate>
                                <table align="center">
                                  

                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lbl_CC" runat="server" Text="Course" meta:resourcekey="lbl_CC"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_CC" runat="server" Skin="WebBlue" MarkFirstMatch="true" AutoPostBack="true" OnSelectedIndexChanged="radCourse_SelectedIndexChanged" Filter="Contains">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rcmb_CC" runat="server" ControlToValidate="rcmb_CC"
                                                meta:resourcekey="rfv_rcmb_CC" ErrorMessage="Please Select Course Name" InitialValue="Select"
                                                Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lbl_OfflineassementId" runat="server" Visible="False" meta:resourcekey="lbl_CourseId"></asp:Label>
                                            <asp:Label ID="lbl_CourseSchedule" runat="server" Text="Course Schedule" meta:resourcekey="lbl_CourseSchedule"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rfc_rcmb_CS" runat="server" Skin="WebBlue" MarkFirstMatch="true" Filter="Contains">
                                            </telerik:RadComboBox>

                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rtxt_CourseSchedule" ControlToValidate="rfc_rcmb_CS" InitialValue="Select"
                                                runat="server" ValidationGroup="Controls" ErrorMessage="Please Select Course Schedule"
                                                meta:resourcekey="rfc_rcmb_CS"   >*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lbl_AssessmentName" runat="server" Text="Assessment ID" meta:resourcekey="lbl_AssessmentName" Visible="false"></asp:Label>
                                            <asp:Label ID="lbl_Assessment" runat="server" Text="Assessment Name" meta:resourcekey="lbl_AssessmentName"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="rtxt_AssessmentName" runat="server" Skin="WebBlue" MaxLength="50">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rtxt_AssessmentName" ControlToValidate="rtxt_AssessmentName"
                                                runat="server" ValidationGroup="Controls" ErrorMessage="Please select Assessment Name"
                                                meta:resourcekey="rfv_rtxt_CourseDesc">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lbl_upload" runat="server" Text="Upload"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <asp:FileUpload ID="fileupload_upload" runat="server" />
                                        </td>
                                        <td>
                                         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="fileupload_upload"
                                                runat="Server" ErrorMessage="Only Pdf and Doc files are allowed" ValidationGroup="Controls"
                                                Text="*" ValidationExpression="^.+\.((doc)|(docx)|(pdf))$" />
                                            <asp:RequiredFieldValidator ID="rvf_Fileupload" ControlToValidate="fileupload_upload"
                                                runat="server" ValidationGroup="Controls" ErrorMessage="Please Select a File"
                                                meta:resourcekey="rfv_rtxt_CourseDesc">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>


                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_IsActive" runat="server" Text="Status:"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="rad_IsActive" runat="server" Checked="true"></asp:CheckBox>
                                        </td>
                                        <td></td>
                                    </tr>

                                    <tr>

                                        <td align="center" colspan="4">

                                            <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click"
                                                Text="Save" ValidationGroup="Controls" Visible="False" />
                                            <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Upadte" OnClick="btn_Save_Click"
                                                Text="Update"  Visible="False" />
                                            <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click"
                                                Text="Cancel" />
                                            <asp:ValidationSummary ID="vs_Country" runat="server" ShowMessageBox="True" ShowSummary="False"
                                                ValidationGroup="Controls" />
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btn_Save" />
                                <asp:PostBackTrigger ControlID="btn_Update" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RadPageView1" runat="server" Selected="True">
                        <table align="center" width="45%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="RadOfflineResults" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        Skin="WebBlue" AllowPaging="True"
                                        AllowFilteringByColumn="true" OnNeedDataSource="RadOfflineResults_NeedDataSource" >
                                        <MasterTableView>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="OFFLINE_RESULTID" UniqueName="OFFLINE_RESULTID" HeaderText="ID"
                                                    meta:resourcekey="OFFLINE_RESULTID" Visible="False">
                                                </telerik:GridBoundColumn>

                                                <telerik:GridBoundColumn DataField="OFFLINEASSESSMENT_NAME" UniqueName="OFFLINEASSESSMENT_NAME"
                                                    HeaderText="Assessment Name " meta:resourcekey="OFFLINEASSESSMENT_NAME">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMP_NAME" UniqueName="EMP_NAME" HeaderText="Employee Name"
                                                    meta:resourcekey="EMP_NAME">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="CourseSchedule_Name" UniqueName="CourseSchedule_Name" HeaderText="Course Schedule"
                                                    meta:resourcekey="CourseSchedule_Name">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn HeaderText="Assessment Doc" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <a id="D2" runat="server" target="_blank" href='<%#Eval("OFFLINE_RESULTDOC") %>'>Assessment Doc</a>
                                                        <asp:Label ID="lbl_BioData" Text='<%#Eval("OFFLINE_RESULTDOC") %>' Visible="false"
                                                            runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColResult" meta:resourcekey="ColResult" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Marks" runat="server" CommandArgument='<%# Eval("OFFLINE_RESULTID") %>'
                                                            OnCommand="lnk_Marks_Command" meta:resourcekey="lnk_Result">Add Results</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                        </MasterTableView>
                                        <PagerStyle AlwaysVisible="True" />
                                        <FilterMenu Skin="WebBlue">
                                        </FilterMenu>
                                        <HeaderContextMenu Skin="WebBlue">
                                        </HeaderContextMenu>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                       <asp:Button ID="Btn_Cancel1" runat="server" Visible="false" meta:resourcekey="btn_Cancel1" OnClick="btn_Cancel_Click"
                                                Text="Cancel" />

                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RadPageView2" runat="server" Selected="True">
                        <table align="center" width="45%">
                            <tr>
                                <td><asp:Label ID="lblAssessmentID" runat="server" Text="Assessment ID" meta:resourcekey="lblAssessmentID" Visible="false"></asp:Label>
                                            <asp:Label ID="lblAssessmentNametxt" runat="server" Text="Assessment Name" meta:resourcekey="lblAssessmentNametxt"></asp:Label></td>
                                <td><asp:Label ID="lblAssessmentName" runat="server" Text="Assessment Name" meta:resourcekey="lbl_AssessmentName"></asp:Label></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lblMarks" runat="server" Text="Marks" meta:resourcekey="lblMarks"></asp:Label></td>
                                <td><telerik:RadNumericTextBox ID="txtmarks" runat="server" NumberFormat-GroupSeparator="" NumberFormat-DecimalDigits="0" MaxLength="3" ></telerik:RadNumericTextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtmarks"
                                                runat="server" ValidationGroup="Controls1" ErrorMessage="Please enter Marks"
                                                meta:resourcekey="rfv_rtxt_CourseDesc">*</asp:RequiredFieldValidator>
                                </td>

                            </tr>
                            <tr>
                                <td><asp:Label ID="lblResult" runat="server" Text="Result" meta:resourcekey="lblResult"></asp:Label></td>
                                <td>
                                    <asp:RadioButtonList ID="rbtnlst" runat="server">
                                        <asp:ListItem Text="Pass" Value="Pass"></asp:ListItem>
                                        <asp:ListItem Text="Fail" Value="Fail"></asp:ListItem>
                                    </asp:RadioButtonList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="rbtnlst"
                                                runat="server" ValidationGroup="Controls1" ErrorMessage="Please select Result"
                                                meta:resourcekey="rfv_rtxt_CourseDesc">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="right">
                                     <asp:Button ID="btnSaveMarks" runat="server" meta:resourcekey="btnSaveMarks" OnClick="btnSaveMarks_Click"
                                                Text="Save" ValidationGroup="Controls1"/>
                                            <asp:Button ID="btnCancelMarks" runat="server" meta:resourcekey="btnCancelMarks" OnClick="btnCancelMarks_Click"
                                                Text="Cancel" />
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False"
                                                ValidationGroup="Controls1" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>

            </td>
        </tr>
    </table>





</asp:Content>

