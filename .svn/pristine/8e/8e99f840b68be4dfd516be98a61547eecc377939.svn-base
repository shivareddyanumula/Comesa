<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_JobRequisition.aspx.cs" Inherits="Recruitment_frm_JobRequisition" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        //function OnClientItemsRequesting(sender, eventArgs) {
        //    var context = eventArgs.get_context();
        //    context["FilterString"] = eventArgs.get_text();
        //}

        function GetSelectedItem(sender, eventArgs) {
            var context = eventArgs.get_context();
            context["FilterString"] = eventArgs.get_text();

            var BUCombo = $find("<%= rcmb_BU.ClientID %>");
            //var BUID = BUCombo.get_text();
            //get the value of the selected BusinessUnit combobox     
            var BUID = BUCombo.get_value();
            if (BUID == "") {
                BUID = "0";
                alert("Please Select BusinessUnit");
            }
            var context = eventArgs.get_context();
            // set the value of the BusinessUnit combobox to the context
            context["BUID"] = BUID;
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">

    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_Heading" runat="server" meta:resourcekey="lbl_Heading" Font-Bold="True"></asp:Label>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_JobRequisition_page" runat="server" SelectedIndex="0"
                    Style="z-index: 10" Width="1014px">
                    <telerik:RadPageView ID="Rp_JobRequisition_ViewMain" runat="server" Selected="True" Height="600px">
                        <table align="center" width="60%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_JobRequisition" runat="server" AutoGenerateColumns="False"
                                        GridLines="None" Skin="WebBlue" AllowPaging="true" PageSize="5" AllowFilteringByColumn="True"
                                        OnNeedDataSource="Rg_JobRequisition_NeedDataSource">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="JOBREQ_REQCODE" UniqueName="JOBREQ_REQCODE" HeaderText=" Resource Requisition"
                                                    meta:resourcekey="JOBREQ_REQCODE">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="JOBREQ_REQNAME" UniqueName="JOBREQ_REQNAME" HeaderText="Resource Requisition Name"
                                                    meta:resourcekey="JOBREQ_REQNAME">
                                                </telerik:GridBoundColumn>
                                                <%-- <%--<telerik:GridBoundColumn DataField="JOBREQ_REQDATE" UniqueName="JOBREQ_REQDATE" HeaderText="Raised Date"
                                                    meta:resourcekey="JOBREQ_REQDATE">
                                               </telerik:GridBoundColumn>--%>
                                                <telerik:GridBoundColumn DataField="JOBREQ_REQEXPIRY" UniqueName="JOBREQ_REQEXPIRY" AllowFiltering="true"
                                                    HeaderText="Expected Closure Date" DataFormatString="{0:dd/MM/yyyy}" FilterControlWidth="100px" meta:resourcekey="JOBREQ_REQEXPIRY">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="JOBREQ_STATUS" UniqueName="JOBREQ_STATUS" HeaderText="Status"
                                                    meta:resourcekey="JOBREQ_STATUS">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="JOBREQ_APPROVALSTATUS" UniqueName="JOBREQ_Approved/Rejected" HeaderText="Resource Requisition Approved/Rejected">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMP_EMPCODE" UniqueName="EMP_EMPCODE" HeaderText="Raised By"
                                                    Visible="false">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="GridTemplateColumn"
                                                    AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" OnCommand="lnk_Edit_Command" CommandArgument='<%# Eval("JOBREQ_ID") %>'
                                                            meta:resourcekey="lnk_Edit" Text="Edit"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <%--<telerik:GridTemplateColumn UniqueName="ColEdit_1" meta:resourcekey="GridTemplateColumn"
                                                    AllowFiltering="false">
                                                </telerik:GridTemplateColumn>--%>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" meta:resourceKey="lnk_Add" OnCommand="lnk_Add_Command">Add</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <PagerStyle AlwaysVisible="True" />
                                        <FilterMenu>
                                        </FilterMenu>
                                        <HeaderContextMenu>
                                        </HeaderContextMenu>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_JobRequisition_ViewDetails" runat="server" Height="990px">
                        <table align="center">
                            <tr>
                                <td>
                                    <b>Manager Details</b>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_BU" runat="server" meta:resourcekey="lbl_BU"></asp:Label>
                                </td>
                                <td align="right"><b>:</b></td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_BU" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rcmb_BU_SelectedIndexChanged"
                                        Skin="WebBlue" Width="125px" MarkFirstMatch="true" MaxHeight="120px" Filter="Contains">
                                    </telerik:RadComboBox>
                                    <%-- <telerik:RadComboBox ID="rcmb_BU" runat="server" AutoPostBack="true" Skin="WebBlue" Width="125px" MarkFirstMatch="true" MaxHeight="120px">
                                    </telerik:RadComboBox>--%>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_BU" runat="server" ControlToValidate="rcmb_BU"
                                        InitialValue="Select" ErrorMessage="Please Select Business Unit" meta:resourcekey="rfv_BU"
                                        Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                                <td></td>

                                <td>
                                    <asp:Label ID="lbl_RaisedBy" runat="server" meta:resourcekey="lbl_RaisedBy"></asp:Label>
                                </td>
                                <td align="right"><b>:</b></td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_RaisedBy" runat="server" Skin="WebBlue" HighlightTemplatedItems="True" EmptyMessage="Enter Employee Name" MaxHeight="120px"
                                        MarkFirstMatch="true" EnableLoadOnDemand="true" AutoPostBack="true" OnClientItemsRequesting="GetSelectedItem" OnSelectedIndexChanged="rcmb_RaisedBy_SelectedIndexChanged">
                                        <WebServiceSettings Method="GET_EmployeeBySearchStr" Path="frm_JobRequisition.aspx" />
                                    </telerik:RadComboBox>
                                    <%--<telerik:RadComboBox ID="rcmb_RaisedBy" runat="server" AutoPostBack="true" Skin="WebBlue"
                                        Width="125px" MarkFirstMatch="true" MaxHeight="120px">
                                    </telerik:RadComboBox>--%>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_RaisedBy" runat="server" ControlToValidate="rcmb_RaisedBy"
                                        ErrorMessage="Please Choose RaisedBy" meta:resourcekey="rfv_RaisedBy" Text="*"
                                        ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                                <td></td>
                            </tr>
                            <tr>

                                <td>
                                    <asp:Label ID="lbl_Directorate" runat="server" meta:resourcekey="lbl_Directorate">
                                    </asp:Label>
                                </td>
                                <td align="right"><b>:</b></td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Directorate" runat="server" InitialValue="- Select -"
                                        Width="125px" MarkFirstMatch="true" MaxHeight="120px" Skin="WebBlue" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td></td>
                                <td></td>

                                <td>
                                    <asp:Label ID="lbl_Department" runat="server" meta:resourcekey="lbl_Department"></asp:Label>
                                </td>
                                <td align="right"><b>:</b></td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Department" runat="server" InitialValue="- Select -"
                                        Width="125px" MarkFirstMatch="true" MaxHeight="120px" Skin="WebBlue" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <%--<asp:RequiredFieldValidator ID="rfv_Department" runat="server" ControlToValidate="rcmb_Department"
                                        ErrorMessage="Please Choose Department" meta:resourcekey="rfv_Department" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>--%>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Desc" runat="server" meta:resourcekey="lbl_Desc"></asp:Label>
                                </td>
                                <td align="right"><b>:</b></td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_Desc" runat="server" Skin="WebBlue"
                                        Width="125px">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_Desc" runat="server" ControlToValidate="rtxt_Desc" ErrorMessage="Please Enter Requisition Name" meta:resourcekey="rfv_Desc" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                                <td></td>

                                <td>
                                    <asp:Label ID="lbl_ExpectedDate" runat="server" meta:resourcekey="lbl_ExpectedDate"></asp:Label>
                                </td>
                                <td align="right"><b>:</b></td>
                                <td>
                                    <telerik:RadDatePicker ID="rdtp_ExpectedDate" runat="server" Skin="WebBlue" Width="205px">
                                        <Calendar Skin="WebBlue" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                        </Calendar>
                                        <%-- <TimeView CellSpacing="-1">
                    </TimeView>
                    <TimePopupButton HoverImageUrl="" ImageUrl="" Visible="False" />--%>
                                        <%-- <DatePopupButton HoverImageUrl="" ImageUrl="" />--%>
                                        <DateInput DateFormat="M/d/yyyy" DisplayDateFormat="M/d/yyyy">
                                        </DateInput>
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_Expecteddate" runat="server" ControlToValidate="rdtp_ExpectedDate"
                                        ErrorMessage="Please Select Expected Closure Date" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                    <%-- <asp:CompareValidator ID="cv_Expecteddate" runat="server" ControlToValidate="rdtp_ExpectedDate" Type="Date" 
                                        ErrorMessage="Date Should Be Less Than The Current Date" Operator="GreaterThanEqual" ValidationGroup="Controls">*</asp:CompareValidator>--%>
                                </td>

                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="lbl_interviewer" runat="server" meta:resourcekey="lbl_interviewer"
                                        Text="Assign Interviewer"></asp:Label>
                                </td>
                                <td align="right"><b>:</b></td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_interviewer" MarkFirstMatch="true" MaxHeight="120px" runat="server" Skin="WebBlue" Width="125px"
                                        HighlightTemplatedItems="True" EmptyMessage="Please Enter Employee Name" EnableLoadOnDemand="true" OnClientItemsRequesting="GetSelectedItem">
                                        <WebServiceSettings Method="GET_EmployeeBySearchStr" Path="frm_JobRequisition.aspx" />
                                    </telerik:RadComboBox>
                                    <%--<telerik:RadComboBox ID="RadComboBox1" runat="server" Skin="WebBlue" HighlightTemplatedItems="True" EmptyMessage="Enter Employee Name"
                                        MarkFirstMatch="true" EnableLoadOnDemand="true" AutoPostBack="true" OnClientItemsRequesting="GetSelectedItem" OnSelectedIndexChanged="rcmb_RaisedBy_SelectedIndexChanged">
                                        <WebServiceSettings Method="GET_EmployeeBySearchStr" Path="frm_JobRequisition.aspx" />
                                    </telerik:RadComboBox>--%>
                                    <%-- <telerik:RadComboBox ID="rcmb_RaisedBy" runat="server" Skin="WebBlue" HighlightTemplatedItems="True" EmptyMessage="Enter Employee Name"
                                        MarkFirstMatch="true" EnableLoadOnDemand="true" AutoPostBack="true" OnClientItemsRequesting="OnClientItemsRequesting" OnSelectedIndexChanged="rcmb_RaisedBy_SelectedIndexChanged">
                                        <WebServiceSettings Method="GET_EmployeeBySearchString" Path="frm_jobrequisition.aspx" />
                                    </telerik:RadComboBox>--%>
                                </td>
                                <td>
                                    <asp:Button ID="btn_AddInterviewer" runat="server" OnClick="btn_AddInterviewer_Click"
                                        Text="Add" />
                                </td>
                                <td></td>
                                <td>
                                    <asp:Label ID="lbl_JRID" runat="server" Text="JR ID" Visible="False">
                                    </asp:Label>
                                    <asp:Label ID="lbl_JRCode" runat="server" meta:resourcekey="lbl_JRCode"></asp:Label>
                                </td>
                                <td align="right"><b>:</b></td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_JRCode" runat="server" EmptyMessage="Auto Generated Code" ReadOnly="True" Skin="WebBlue" Width="125px">
                                    </telerik:RadTextBox>
                                </td>


                            </tr>
                            <tr>
                                <td>&#160;&nbsp;
                                </td>
                                <td align="right"></td>
                                <td>
                                    <telerik:RadListBox ID="rlst_interviewer" Height="120px"
                                        Width="210px" runat="server" AllowDelete="True" Skin="WebBlue" AutoPostBackOnDelete="True">
                                    </telerik:RadListBox>
                                </td>

                                <td>
                                    <%-- <asp:RequiredFieldValidator ID="rfv_rlst_interviewer" runat="server" ControlToValidate="rlst_interviewer"
                    ErrorMessage="Please Assign Atleast One Interviewer" meta:resourcekey="rfv_rlst_interviewer" Text="*"
                    ValidationGroup="Controls"></asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>Resource Requisition Details</b>
                                </td>

                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="lblFinPeriod" runat="server" Text="Financial Period"></asp:Label>
                                </td>
                                <td align="right"><b>:</b></td>
                                <td>
                                    <telerik:RadComboBox ID="rcbFinPeriod" runat="server" AutoPostBack="true" Filter="Contains"
                                        InitialValue="Select" MarkFirstMatch="true" Width="125px" MaxHeight="120px"
                                        OnSelectedIndexChanged="rcbFinPeriod_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvFinPeriod" runat="server" ControlToValidate="rcbFinPeriod" InitialValue="Select"
                                        ErrorMessage="Please Select a Financial Period" ValidationGroup="Controls" Text="*"></asp:RequiredFieldValidator>
                                </td>
                                <td></td>
                                <td></td>
                                <%-- <td align="right"><b>:</b></td>--%>
                                <td></td>
                                <td></td>
                                <td></td>

                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Status" runat="server" meta:resourcekey="lbl_Status"></asp:Label>
                                </td>
                                <td align="right"><b>:</b></td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Status" runat="server" AutoPostBack="true" InitialValue="- Select -" MarkFirstMatch="true" Width="125px" MaxHeight="120px">
                                        <Items>
                                            <%--<telerik:RadComboBoxItem runat="server" Text="Select" Value="0" />--%>
                                            <telerik:RadComboBoxItem runat="server" Text="Open" Value="1" />
                                            <telerik:RadComboBoxItem runat="server" Text="Close" Value="2" />
                                            <telerik:RadComboBoxItem runat="server" Text="Reopen" Value="3" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_Status" runat="server" ControlToValidate="rcmb_Status"
                                        ErrorMessage="Please Select a Status" ValidationGroup="Controls" meta:resourcekey="rfv_Status" Text="*"></asp:RequiredFieldValidator>
                                </td>
                                <td></td>
                                <td>
                                    <asp:Label ID="lbl_emptype" runat="server" meta:resourcekey="lbl_emptype" Text="Employee Type"></asp:Label>
                                </td>
                                <td align="right"><b>:</b></td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Emptype" runat="server" InitialValue="- Select -"
                                        Skin="WebBlue" Width="125px" MarkFirstMatch="true" MaxHeight="120px" Filter="Contains">
                                        <%-- <Items>
                                            <telerik:RadComboBoxItem runat="server" Selected="true" Text="Select" Value="0" />
                                            <telerik:RadComboBoxItem runat="server" Text="Permanent" Value="Permanent" />
                                            <telerik:RadComboBoxItem runat="server" Text="Contract" Value="Contract" />
                                            <telerik:RadComboBoxItem runat="server" Text="Consultant" Value="Consultant" />
                                        </Items>--%>
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_Emptype" runat="server" ControlToValidate="rcmb_Emptype" InitialValue="Select"
                                        ErrorMessage="Please Select Employee Type" meta:resourcekey="rfv_rcmb_Emptype" Text="*"
                                        ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                                <td></td>

                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="lblJob" runat="server" Text="Job"></asp:Label></td>
                                <td align="right"><b>:</b></td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Job" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rcmb_Job_SelectedIndexChanged"
                                        Width="125px" MarkFirstMatch="true" MaxHeight="120px" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_Job" runat="server" ControlToValidate="rcmb_Job" InitialValue="Select"
                                        ErrorMessage="Please Select Job" meta:resourcekey="rfv_rcmb_Job" Text="*"
                                        ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                                <td></td>
                                <td>
                                    <asp:Label ID="lbl_Designation" runat="server" meta:resourcekey="lbl_Designation"></asp:Label>
                                </td>
                                <td align="right"><b>:</b></td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Designation" runat="server" InitialValue="- Select -" AutoPostBack="true" Filter="Contains"
                                        Skin="WebBlue" Width="125px" MarkFirstMatch="true" MaxHeight="120px" OnSelectedIndexChanged="rcmb_Designation_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_Designation" runat="server" ControlToValidate="rcmb_Designation" InitialValue="Select"
                                        ErrorMessage="Please Select Position" meta:resourcekey="rfv_Designation" Text="*"
                                        ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                                <td></td>




                            </tr>

                            <tr>
                                <%--<td>
                                    <asp:Label ID="lbl_req_for" runat="server" meta:resourcekey="lbl_req_for" Text="Requirement For"></asp:Label>
                                </td>
                                <td align="right"><b>:</b></td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_req_for" runat="server" InitialValue="- Select -"
                                        Skin="WebBlue" Width="125px" MarkFirstMatch="true" MaxHeight="120px">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Selected="true" Text="Select" Value="0" />
                                            <telerik:RadComboBoxItem Text="Internal" Value="1" />
                                            <telerik:RadComboBoxItem Text="For Onsite Client" Value="2" />
                                            <telerik:RadComboBoxItem Text="For RFP or RFQ's" Value="3" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_req_for" runat="server" ControlToValidate="rcmb_req_for"
                                        ErrorMessage="Please Select Requirement For" meta:resourcekey="rfv_rcmb_req_for" Text="*"
                                        ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                                <td></td>--%>

                                <%-- <td>
                                    <asp:Label ID="lbl_Qualification" runat="server" meta:resourcekey="lbl_Qualification"></asp:Label>
                                </td>
                                <td align="right"><b>:</b></td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Qualification" runat="server" MarkFirstMatch="true" Skin="WebBlue">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_Qualification" runat="server" ControlToValidate="rcmb_Qualification" ErrorMessage="Please Choose Qualification " meta:resourcekey="rfv_Qualification" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chk_IsQualificationReQ" runat="server" meta:resourcekey="chk_IsQualificationReQ" />
                                </td>--%>

                                <td>
                                    <asp:Label ID="lbl_Grade" runat="server" meta:resourcekey="lbl_Grade" Text="Grade"></asp:Label>
                                </td>
                                <td align="right"><b>:</b></td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Grade" runat="server" InitialValue="Select" MarkFirstMatch="true" MaxHeight="120px"
                                        Skin="WebBlue" Width="125px" AutoPostBack="true" OnSelectedIndexChanged="rcmb_Grade_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_Grade" runat="server" ControlToValidate="rcmb_Grade"
                                        ErrorMessage="Please Select Grade" InitialValue="Select" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                                <td></td>

                                <td>
                                    <asp:Label ID="lbl_Slab" runat="server" meta:resourcekey="lbl_Slab" Text="Slab"></asp:Label>
                                </td>
                                <td align="right"><b>:</b></td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Slab" runat="server" InitialValue="Select" MarkFirstMatch="true" MaxHeight="120px" Skin="WebBlue" Width="125px"
                                        Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_Slab" runat="server" InitialValue="Select" ControlToValidate="rcmb_Slab" ErrorMessage="Please Select Slab" meta:resourcekey="rfv_rcmb_Slab" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                                <td></td>




                            </tr>
                            <%--<tr>
            <td>
                <asp:Label ID="lbl_reqto_work" runat="server" meta:resourcekey="lbl_reqto_work" Text="Required to Work"></asp:Label>
            </td>
            <td align="right">
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_reqto_work" runat="server" InitialValue="- Select -"
                    Skin="WebBlue" Width="125px" MarkFirstMatch="true" MaxHeight="120px">
                    <Items>
                        <telerik:RadComboBoxItem runat="server" Selected="true" Text="Select" Value="0" />
                        <telerik:RadComboBoxItem Text="Onsite" Value="1" />
                        <telerik:RadComboBoxItem Text="Internal" Value="2" />
                        <telerik:RadComboBoxItem Text="Both" Value="3" />
                    </Items>
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_rcmb_reqto_work" runat="server" ControlToValidate="rcmb_reqto_work"
                    ErrorMessage="Please Select Required to Work" meta:resourcekey="rfv_rcmb_reqto_work" Text="*"
                    ValidationGroup="Controls"></asp:RequiredFieldValidator>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_RecruitmentFor" runat="server" meta:resourcekey="lbl_RecruitmentFor" Text="Recruitment For"></asp:Label>
            </td>
            <td align="right">
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_RecruitmentFor" runat="server" InitialValue="Select"
                    Skin="WebBlue" Width="125px" MarkFirstMatch="true" MaxHeight="120px">
                    <Items>
                      <telerik:RadComboBoxItem runat="server" Text="Select" Value="Select" />
                      <telerik:RadComboBoxItem runat="server" Text="Fresher" Value="Fresher" />
                      <telerik:RadComboBoxItem runat="server" Text="Experience" Value="Experience" />
                    </Items>
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_rcmb_RecruitmentFor" runat="server" ControlToValidate="rcmb_RecruitmentFor"
                    ErrorMessage="Please Select Recruitment For" meta:resourcekey="rfv_rcmb_RecruitmentFor" Text="*" InitialValue="Select"
                    ValidationGroup="Controls"></asp:RequiredFieldValidator>
            </td>
            <td>
            </td>
        </tr>--%>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="lbl_SkillReq" runat="server" meta:resourcekey="lbl_SkillReq"></asp:Label>
                                </td>
                                <td align="right" valign="top"><b>:</b>
                                </td>
                                <td>
                                    <asp:Label ID="lblSkills" runat="server"></asp:Label><br />
                                    <%--<telerik:RadListBox ID="rlb_SkillReq" runat="server" AllowAutomaticUpdates="true" CheckBoxes="true" Height="100px" Width="200px">
                                    </telerik:RadListBox>--%>
                                </td>
                                <td></td>
                                <td></td>

                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Qualification" meta:resourcekey="lbl_Qualification"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <asp:Label ID="lblQualifications" runat="server"></asp:Label>
                                    <%--<telerik:RadListBox ID="rlb_Qualification" runat="server" Skin="WebBlue" CheckBoxes="true" Height="130px" Width="200px">
                                    </telerik:RadListBox>--%>
                                </td>
                                <td></td>

                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Percentage" runat="server" meta:resourcekey="lbl_Percentage"></asp:Label>
                                </td>
                                <td align="right"><b>:</b></td>
                                <td>
                                    <telerik:RadNumericTextBox ID="RNT_Percentage" runat="server" Skin="WebBlue" MaxValue="100" Type="Percent" Width="125px">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_Percentage" runat="server" ControlToValidate="RNT_Percentage"
                                        ErrorMessage="Please Enter Percentage " meta:resourcekey="rfv_Percentage" Text="*"
                                        ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                                <td></td>


                                <td>
                                    <asp:Label ID="lbl_Experience" runat="server" meta:resourcekey="lbl_experience"></asp:Label>
                                </td>
                                <td align="right"><b>:</b></td>
                                <td>
                                    <telerik:RadNumericTextBox ID="RNT_Experience" runat="server" MinValue="0" Skin="WebBlue" MaxValue="99">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td><%--    <asp:Label ID ="lbl_yr" runat ="server" Text="(in Years)"></asp:Label>--%>
                                    <asp:RequiredFieldValidator ID="rfv_Experience" runat="server" ControlToValidate="RNT_Experience" ErrorMessage="Please Enter Experience " meta:resourcekey="rfv_Experience" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chk_IsExperienceReq" runat="server" meta:resourcekey="chk_IsExperienceReq" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Openings" runat="server" meta:resourcekey="lbl_Openings"></asp:Label>
                                </td>
                                <td align="right"><b>:</b></td>
                                <td>
                                    <telerik:RadNumericTextBox ID="RNT_Openings" runat="server" NumberFormat-DecimalDigits="0" AutoPostBack="true"
                                        Skin="WebBlue" OnTextChanged="RNT_Openings_TextChanged" MinValue="0" MaxLength="10">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_Openinsgs" runat="server" ControlToValidate="RNT_Openings"
                                        ErrorMessage="Please Enter Target Openings" meta:resourcekey="rfv_Openings" Text="*"
                                        ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <%--<tr>
            <td>
                <asp:Label ID="lbl_location" runat="server" meta:resourcekey="lbl_location" Text="Location"></asp:Label>
            </td>
            <td align="right">
                <b>:</b>
            </td>
            <td>
                <telerik:RadTextBox ID="rtxt_location" runat="server" 
                    Skin="WebBlue" Width="125px" MaxLength="500">
                </telerik:RadTextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_rtxt_location" runat="server" ControlToValidate="rtxt_location"
                    ErrorMessage="Please enter Location" meta:resourcekey="rfv_rtxt_location" Text="*"
                    ValidationGroup="Controls"></asp:RequiredFieldValidator>
            </td>
            <td>
            </td>
        </tr>--%>
                            <%--<tr>
                                <td>
                                    <asp:Label ID="lbl_Appctc" runat="server" Text="App..CTC"></asp:Label>
                                </td>
                                <td align="right">:
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="RNT_Appctc" runat="server" Skin="WebBlue" Width="125px"
                                        MinValue="0">
                                    </telerik:RadNumericTextBox>

                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_RNT_Appctc" runat="server" ControlToValidate="RNT_Appctc"
                                        ErrorMessage="Please Enter App.. CTC " meta:resourcekey="rfv_RNT_Appctc" Text="*"
                                        ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                    <asp:Label ID="lbl_ctc" runat="server" Text="ctc" Visible="false"></asp:Label>
                                </td>
                                <td></td>
                            </tr>--%>
                            <%-- <tr>
                                <td>
                                    <asp:Label ID="lbl_Dept_interviewer" runat="server" meta:resourcekey="lbl_Dept_interviewer" Text="Interviewer Department"></asp:Label>
                                </td>
                                <td align="right"><b>:</b></td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_dept_interviewer" runat="server" InitialValue="- Select -" AutoPostBack="true"
                                        Skin="WebBlue" Width="125px" MarkFirstMatch="true" MaxHeight="120px" OnSelectedIndexChanged="rcmb_dept_interviewer_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_dept_interviewer" runat="server" ControlToValidate="rcmb_dept_interviewer"
                    ErrorMessage="Please Select Designation" meta:resourcekey="rfv_rcmb_dept_interviewer" Text="*"
                    ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                                <td></td>
                            </tr>--%>

                            <tr>
                                <td valign="top">
                                    <asp:Label ID="lbl_Comments" runat="server" meta:resourcekey="lbl_Comments"></asp:Label>
                                </td>
                                <td align="right" valign="top"><b>:</b></td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_Comments" runat="server" Height="120px" Skin="WebBlue"
                                        MaxLength="500" Rows="4" TextMode="MultiLine" Width="140px">
                                    </telerik:RadTextBox>
                                </td>
                                <td valign="top">
                                    <asp:RequiredFieldValidator ID="rfv_Comments" runat="server" ControlToValidate="rtxt_Comments"
                                        ErrorMessage="Please Enter Comments " meta:resourcekey="rfv_Comments" Text="*"
                                        ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                                <td></td>
                            </tr>
                            <tr id="tr_ActDate" runat="server">
                                <td>
                                    <asp:Label ID="lbl_ActualDate" runat="server" meta:resourcekey="lbl_ActualDate"></asp:Label>
                                </td>
                                <td align="right"><b>:</b></td>
                                <td>
                                    <telerik:RadDatePicker ID="rdtp_ActualClosedDate" runat="server" Skin="WebBlue"
                                        Width="205px">
                                        <Calendar Skin="WebBlue" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                            ViewSelectorText="x">
                                        </Calendar>
                                        <%-- <TimeView CellSpacing="-1">
                    </TimeView>
                    <TimePopupButton HoverImageUrl="" ImageUrl="" Visible="False" />--%>
                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                        <DateInput DateFormat="M/d/yyyy" DisplayDateFormat="M/d/yyyy">
                                        </DateInput>
                                    </telerik:RadDatePicker>
                                </td>
                                <%--<td>
                     <asp:RequiredFieldValidator ID="rfv_ActualClosedDate" runat="server" ControlToValidate="rdtp_ActualClosedDate"
                    ErrorMessage="Please Select Actual Closed Date" meta:resourcekey="rfv_ActualClosedDate" Text="*"
                    ValidationGroup="Controls"></asp:RequiredFieldValidator>
                    </td>--%>
                                <td></td>


                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>

                                <td align="right">
                                    <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Edit" OnClick="btn_Save_Click"
                                        Text="Update" ValidationGroup="Controls" Visible="False" />
                                    <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click"
                                        ValidationGroup="Controls" Visible="False" />
                                </td>
                                <td align="left">
                                    <asp:Button ID="btn_Cancel" runat="server" OnCommand="btn_Cancel_Click" Text="Cancel" />
                                </td>
                                <td>
                                    <asp:ValidationSummary ID="vs_JobRequisition" runat="server" meta:resourcekey="vs_JobRequisition"
                                        ShowMessageBox="True" ShowSummary="False" ValidationGroup="Controls" />
                                </td>
                                <td></td>
                            </tr>
                            <%-- <tr>
                                        <td colspan="4" align="center">
                                            <table width="100%">
                                                <tr>
                                                    <td width="100%">--%>
                            <%--   <asp:Panel ID="pnl_multipage2" runat="server" Visible="false">
                                                            <%-- <asp:Label ID="lbl_heading" runat="server" Text="Assign SkillS"></asp:Label>--%>
                            <%-- <table align="center">
                                                                <tr>
                                                                    <td align="center" colspan="7">
                                                                        <telerik:RadMultiPage ID="RM_Skills" runat="server">
                                                                            <telerik:RadPageView ID="RP_SkillForm" runat="server" Width="100%">
                                                                                <table align="center">
                                                                                    <tr>
                                                                                        <td align="left" colspan="3">
                                                                                            <telerik:RadGrid ID="RG_Skills" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                                                                                 PageSize="5" Width="300px">
                                                                                                <MasterTableView CommandItemDisplay="Top">
                                                                                                    <Columns>
                                                                                                        <telerik:GridBoundColumn DataField="JR_SKILLS_ID" HeaderText="Id" Visible="false">
                                                                                                        </telerik:GridBoundColumn>
                                                                                                        <telerik:GridBoundColumn DataField="JR_ID" HeaderText="JR Id" Visible="false">
                                                                                                        </telerik:GridBoundColumn>
                                                                                                        <telerik:GridBoundColumn DataField="SKILL_ID" HeaderText="Skills" Visible="false">
                                                                                                        </telerik:GridBoundColumn>
                                                                                                        <telerik:GridBoundColumn DataField="HR_MASTER_CODE" HeaderText="Skill Name">
                                                                                                        </telerik:GridBoundColumn>
                                                                                                        <telerik:GridTemplateColumn>
                                                                                                            <ItemTemplate>
                                                                                                                <asp:LinkButton ID="lnk_Delete" runat="server" OnClientClick="return confirm('Do you want to delete this Skill?');" OnCommand="lnk_Delete_Command" CommandArgument='<%# Eval("JR_SKILLS_ID") %>'
                                                                                                                    Text="Delete"></asp:LinkButton>
                                                                                                            </ItemTemplate>
                                                                                                        </telerik:GridTemplateColumn>
                                                                                                    </Columns>
                                                                                                    <CommandItemTemplate>
                                                                                                        <div align="right">
                                                                                                            <asp:LinkButton ID="lnk_Add" runat="server" OnCommand="lnk_Add_CommandSkills">Add</asp:LinkButton>
                                                                                                        </div>
                                                                                                    </CommandItemTemplate>
                                                                                                </MasterTableView>
                                                                                            </telerik:RadGrid>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </telerik:RadPageView>
                                                                            <telerik:RadPageView ID="RP_skilldetails" runat="server" Width="100%">
                                                                                <table align="center">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lbl_id" runat="server" Text="[lbl_id]" Visible="false"></asp:Label>
                                                                                            <asp:Label ID="lbl_Skills" runat="server" Text="Skills"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <b>:</b>
                                                                                        </td>
                                                                                        <td>
                                                                                            <telerik:RadComboBox ID="RCMB_Skills" runat="server"  >
                                                                                            </telerik:RadComboBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:CheckBox ID="chk_IsSkillReq" runat="server" meta:resourcekey="chk_IsSkillReq" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="center" colspan="7">
                                                                                            <asp:Button ID="btn_Add" runat="server" Text="Add" OnClick="btn_Save_Click1" ValidationGroup="Controls1" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </telerik:RadPageView>
                                                                        </telerik:RadMultiPage>
                                                                    </td>
                                                                </tr>
                                                            </table>--%>
                            <%--  </asp:Panel>
                                                    </td>--%>
                            <%--    </tr>
                                            </table>
                                        </td>
                                    </tr>--%>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
            <td></td>
        </tr>
    </table>
</asp:Content>