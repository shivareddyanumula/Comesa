<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_InterviewPhaseDefinition.aspx.cs" Inherits="Recruitment_frm_InterviewPhaseDefinition" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">

    <table align="center">

        <tr>
            <td align="center">
                <asp:Label ID="lbl_PhaseDefinitionHeader" runat="server" Text="Interview Phases"
                    Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>

                <telerik:RadMultiPage ID="RMP_InterviewPhaseDefinition" runat="server" SelectedIndex="0"
                    Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="RPV_InterviewPhaseDefinition" runat="server">
                        <table align="center">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="RG_InterviewPhaseDefinition" runat="server" AutoGenerateColumns="false"
                                        GridLines="None" AllowPaging="True" AllowFilteringByColumn="True" OnNeedDataSource="RG_InterviewPhaseDefinition_NeedDataSource">
                                        <MasterTableView CommandItemDisplay="Top" Width="100%">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="Phase_ID" UniqueName="Phase_ID" Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Phase_JobReqID" HeaderText="Resource Requistion" UniqueName="Phase_JobReqID"
                                                    ItemStyle-HorizontalAlign="Left" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="JOBREQ_REQCODE" HeaderText="Resource Requistion" UniqueName="JOBREQ_REQCODE"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Phase_Name" HeaderText="Phase Name" UniqueName="Phase_Name"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Phase_Desc" HeaderText="Description" UniqueName="Phase_Desc"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Interviewer" HeaderText="Interviewer" UniqueName="Phase_interviewer"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridNumericColumn DataField="PHASE_PRIORITY" HeaderText="Priority" UniqueName="PHASE_PRIORITY" FilterControlWidth="50px"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridNumericColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("Phase_ID") %>'
                                                            OnCommand="lnk_Edit_Command">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" OnCommand="lnk_Add_Command">Add</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <PagerStyle AlwaysVisible="True" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RPV_InterviewPhaseDetails" runat="server">
                        <table align="center">
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business Unit"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="Rcb_BusinessUnit" runat="server" MarkFirstMatch="true" Filter="Contains"
                                        AutoPostBack="True" OnSelectedIndexChanged="Rcb_BusinessUnit_SelectedIndexChanged" MaxHeight="120px">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_BusinessUnit" runat="server" ControlToValidate="Rcb_BusinessUnit"
                                        ErrorMessage="Select Business Unit" ValidationGroup="Controls" InitialValue="Select">*</asp:RequiredFieldValidator>
                                </td>

                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_PhaseId" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lbl_InterviewNameCheck" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lbl_JobRequestId" runat="server" Text="Resource Requisition"></asp:Label>
                                    <asp:Label ID="lbl_PriorityValue" runat="server" Visible="false"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="Rcb_JobRequestId" runat="server" MarkFirstMatch="true" MaxHeight="120px"
                                        AutoPostBack="true" OnSelectedIndexChanged="Rcb_JobRequestId_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_JobRequestId" runat="server" ControlToValidate="Rcb_JobRequestId"
                                        ErrorMessage="Please Select Resource Requisition" Text="*" ValidationGroup="Controls"
                                        InitialValue="Select"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Designation" runat="server" Text="Position" meta:resourcekey="lbl_Designation"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Designation" runat="server" InitialValue="- Select -" AutoPostBack="true" Filter="Contains"
                                        Skin="WebBlue" Width="125px" MarkFirstMatch="true" MaxHeight="120px" OnSelectedIndexChanged="rcmb_Designation_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_Designation" runat="server" ControlToValidate="rcmb_Designation"
                                        ErrorMessage="Please select Position" meta:resourcekey="rfv_Designation" Text="*"
                                        ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_PhaseName" runat="server" Text="Name"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="Rtxt_PhaseName" runat="server" MaxLength="100">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_PhaseName" runat="server" ControlToValidate="Rtxt_PhaseName"
                                        ValidationGroup="Controls" ErrorMessage="Name cannot be empty" Text="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_PhaseDescription" runat="server" Text="Description"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="Rtxt_PhaseDescription" runat="server" MaxLength="500">
                                    </telerik:RadTextBox>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Skill" runat="server" Text="Skill"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <%--<telerik:RadComboBox ID="Rcb_Skill" runat="server" >
                                    </telerik:RadComboBox>--%>
                                    <telerik:RadListBox ID="rlb_skills" runat="server" CheckBoxes="true" AutoPostBack="true" Filter="Contains"
                                        Width="200px" Height="100px" AllowAutomaticUpdates="true" OnItemCheck="QuestionRadListBox_ItemCheck">
                                    </telerik:RadListBox>
                                </td>
                                <td>
                                    <%-- <asp:RequiredFieldValidator ID="RFV_Rcb_Skill" runat="server" ControlToValidate="Rcb_Skill"
                                        ErrorMessage="Select Skill" ValidationGroup="Controls" InitialValue="Select">*</asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_InterviewFromDate" runat="server" Text="Interview From Date"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="rdtp_interviewfromdate" runat="server" AutoPostBack="true"
                                        Skin="WebBlue" Width="205px" OnSelectedDateChanged="rdtp_interviewfromdate_SelectedDateChanged">
                                        <%--<Calendar  Skin="WebBlue" UseColumnHeadersAsSelectors="False"
                                            UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                        </Calendar>
                                        <TimeView CellSpacing="-1"  >
                                        </TimeView>
                                        <TimePopupButton HoverImageUrl="" ImageUrl="" Visible="False" />
                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                        <DateInput DateFormat="M/d/yyyy" DisplayDateFormat="M/d/yyyy">
                                        </DateInput>--%>
                                        <Calendar Skin="WebBlue" UseColumnHeadersAsSelectors="False"
                                            UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                        </Calendar>
                                        <%--<timeview cellspacing="-1">
                                        </timeview>
                                        <timepopupbutton hoverimageurl="" imageurl="" />--%>
                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                        <DateInput DateFormat="M/d/yyyy" DisplayDateFormat="M/d/yyyy">
                                        </DateInput>
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_interviewfromdate" runat="server" ControlToValidate="rdtp_interviewfromdate"
                                        ErrorMessage="Select Interviewer From Date" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>

                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_InterviewToDate" runat="server" Text="Interview To Date"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="rdtp_interviewtodate" runat="server"
                                        Skin="WebBlue" Width="205px">
                                        <%--<Calendar  Skin="WebBlue" UseColumnHeadersAsSelectors="False"
                                            UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                        </Calendar>
                                        <TimeView CellSpacing="-1"  >
                                        </TimeView>
                                        <TimePopupButton HoverImageUrl="" ImageUrl="" Visible="False" />
                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                        <DateInput DateFormat="M/d/yyyy" DisplayDateFormat="M/d/yyyy">
                                        </DateInput>--%>
                                        <Calendar Skin="WebBlue" UseColumnHeadersAsSelectors="False"
                                            UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                        </Calendar>
                                        <%--<timeview cellspacing="-1">
                                        </timeview>
                                        <timepopupbutton hoverimageurl="" imageurl="" />--%>
                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                        <DateInput DateFormat="M/d/yyyy" DisplayDateFormat="M/d/yyyy">
                                        </DateInput>
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_interviewtodate" runat="server" ControlToValidate="rdtp_interviewtodate"
                                        ErrorMessage="Select Interviewer To Date" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="cmpv_interviewtodate" runat="server" Text="*" ErrorMessage="Interview To Date should not be less than Interview From Date"
                                        ControlToValidate="rdtp_interviewtodate" ControlToCompare="rdtp_interviewfromdate" Operator="GreaterThanEqual" ValidationGroup="Controls"></asp:CompareValidator>
                                </td>

                            </tr>
                            <%--<tr>
                                <td>
                                    <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business Unit"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="Rcb_BusinessUnit" runat="server" 
                                        AutoPostBack="True" OnSelectedIndexChanged="Rcb_BusinessUnit_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_BusinessUnit" runat="server" ControlToValidate="Rcb_BusinessUnit"
                                        ErrorMessage="Select Business Unit" ValidationGroup="Controls" InitialValue="Select">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>--%>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_InterviewerName" runat="server" Text="Interviewer Name"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="Rcb_InterviewerName" runat="server" MarkFirstMatch="true" MaxHeight="120px" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_InterviewerName" runat="server" ControlToValidate="Rcb_InterviewerName"
                                        ErrorMessage="Select Interviewer Name" ValidationGroup="Controls" InitialValue="Select">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <%-- <tr>
                                <td>
                                    <asp:Label ID="lbl_Gradeset" runat="server" Text="Interview Round"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="Rcb_Gradeset" runat="server" MarkFirstMatch="true" MaxHeight="120px">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_Gradeset" runat="server" ControlToValidate="Rcb_Gradeset"
                                        ErrorMessage="Select Interview Round" ValidationGroup="Controls" InitialValue="Select">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>--%>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Priority" runat="server" Text="Priority"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <%--<telerik:RadComboBox ID="Rcb_Priority" runat="server" MarkFirstMatch="true" MaxHeight="120px">
                                    </telerik:RadComboBox>--%>
                                    <telerik:RadNumericTextBox ID="Rtxt_Priority" runat="server" MaxLength="50" Enabled="false">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <%-- <asp:RequiredFieldValidator ID="RFV_Priority" runat="server" ControlToValidate="Rcb_Priority"
                                        ValidationGroup="Controls" ErrorMessage="Select Priority" InitialValue="Select">*</asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Final" runat="server" Text="Final Round"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <asp:CheckBox ID="Chk_Final" runat="server" />
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr align="center">
                                <td colspan="5">
                                    <asp:Button ID="btn_Submit" runat="server" OnClick="btn_Submit_Click" Text="Submit"
                                        ValidationGroup="Controls" Visible="false" />
                                    <asp:Button ID="btn_Update" runat="server" OnClick="btn_Submit_Click" Text="Update"
                                        Visible="false" />
                                    <asp:Button ID="btn_Cancel" runat="server" OnClick="btn_Cancel_Click" Text="Cancel" CausesValidation="false" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ValidationSummary ID="vs_OnlineContest" runat="server" ShowMessageBox="True"
                                        ShowSummary="False" ValidationGroup="Controls" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>