<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_ScheduleInspections.aspx.cs" Inherits="Health_and_Safety_frm_ScheduleInspections" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function OnClientItemsRequesting(sender, eventArgs) {
            var context = eventArgs.get_context();
            context["FilterString"] = eventArgs.get_text();
        }
    </script>
</asp:Content>
<asp:Content ID="cphScheduleInspection" ContentPlaceHolderID="cphDefault" runat="Server">
    <script type="text/javascript"></script>
    <table align="center" style="vertical-align: top;">
        <tr>
            <td>
                <telerik:RadWindowManager ID="RWM_ScheduleInspection" runat="server" Style="z-index: 8000">
                </telerik:RadWindowManager>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lbl_ScheduleInspection" runat="server" Font-Bold="True"
                    Text="Schedule&nbsp;Inspections"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadAjaxManagerProxy ID="RAM_ScheduleInspection" runat="server">
                    <AjaxSettings>
                        <telerik:AjaxSetting AjaxControlID="Rg_ScheduleInspection">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                    </AjaxSettings>
                </telerik:RadAjaxManagerProxy>
                <telerik:RadMultiPage ID="Rm_HDPT_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="1100px" Height="690px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_DPT_ViewMain" runat="server" Selected="True">
                        <table align="center" width="50%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_InspectionsSchedules" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        AllowPaging="True" AllowFilteringByColumn="true" Skin="WebBlue" OnNeedDataSource="Rg_InspectionsSchedules_NeedDataSource">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="INSPECTION_ID" UniqueName="INSPECTION_ID" HeaderText="ID"
                                                    meta:resourcekey="INSPECTION_ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="INSPECTION_NAME" UniqueName="INSPECTION_NAME"
                                                    AllowFiltering="true" HeaderText="Inspection Name"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMP_NAME" UniqueName="EMP_NAME"
                                                    AllowFiltering="true" HeaderText="Assigned To"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="AREA_NAME" UniqueName="AREA_NAME" ItemStyle-Width="1px"
                                                    AllowFiltering="true" HeaderText="Area" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridDateTimeColumn DataField="INSPECTION_SCHEDULE_FROMDATE" FilterControlWidth="100px" UniqueName="INSPECTION_SCHEDULE_FROMDATE"
                                                    AllowFiltering="true" HeaderText="From Date" ItemStyle-HorizontalAlign="Left" DataFormatString="{0:dd/MM/yyyy}"
                                                    HtmlEncode="false">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridDateTimeColumn>
                                                <telerik:GridDateTimeColumn DataField="INSPECTION_SCHEDULE_TODATE" FilterControlWidth="100px" UniqueName="INSPECTION_SCHEDULE_TODATE"
                                                    AllowFiltering="true" HeaderText="To Date" ItemStyle-HorizontalAlign="Left" DataFormatString="{0:dd/MM/yyyy}">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridDateTimeColumn>

                                                <telerik:GridDateTimeColumn DataField="INSPECTION_SCHEDULE_FROMTIME" FilterControlWidth="100px" UniqueName="INSPECTION_SCHEDULE_FROMTIME"
                                                    AllowFiltering="true" HeaderText="From Time" ItemStyle-HorizontalAlign="Left" PickerType="TimePicker" DataFormatString="{0:t}">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridDateTimeColumn>
                                                <%-- <telerik:GridBoundColumn DataField="INSPECTION_SCHEDULE_FROMTIME" UniqueName="INSPECTION_SCHEDULE_FROMTIME" ItemStyle-Width="1px"
                                                    AllowFiltering="true" HeaderText="From Time" ItemStyle-HorizontalAlign="Left" DataFormatString="{0:t}" CurrentFilterFunction="StartsWith">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>--%>
                                                <telerik:GridDateTimeColumn DataField="INSPECTION_SCHEDULE_TOTIME" FilterControlWidth="100px" UniqueName="INSPECTION_SCHEDULE_TOTIME"
                                                    AllowFiltering="true" HeaderText="To Time" ItemStyle-HorizontalAlign="Left" DataFormatString="{0:t}" DataType="System.DateTime" PickerType="TimePicker">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridDateTimeColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="ColEdit" AllowFiltering="false"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("INSPECTION_SCHEDULE_ID") %>'
                                                            meta:resourcekey="lnk_Edit" OnCommand="lnk_Edit">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server"
                                                        CommandArgument='<%# Eval("INSPECTION_SCHEDULE_ID") %>'
                                                        meta:resourceKey="lnk_Add" OnCommand="lnk_Add_Command">Add</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <PagerStyle AlwaysVisible="true" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                        <%--<table align="center">
                            <tr>
                                <td align="center">
                                    <asp:UpdatePanel ID="updPanel1" runat="server">
                                        <ContentTemplate>
                                            <table align="center">
                                                <tr align="center">
                                                    <td align="center" colspan="3">
                                                        <asp:Label ID="lblheader" runat="server" Text="Import Department Details" Font-Bold="true"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <a href="~/Masters/Importsheets/Import_Department.xlsx" runat="server" id="A2">Download
                                                            Department Details Template</a>
                                                    </td>
                                                    <td>
                                                        <asp:FileUpload ID="fu_department" runat="server" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btn_import" runat="server" Text="Import" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btn_import" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>--%>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_Activity_ADDView" runat="server">
                        <table align="center">
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Label ID="lbl_InspectionID" runat="server" Visible="False"></asp:Label>
                                    <br />
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Empreg_BU" runat="server" meta:resourcekey="lbl_Empreg_BU" Text="Business Unit"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_EmpReg_BU" runat="server" AutoPostBack="True" MarkFirstMatch="true"
                                        Skin="WebBlue" OnSelectedIndexChanged="rcmb_EmpReg_BU_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_EmpReg_BU" runat="server" ControlToValidate="rcmb_EmpReg_BU" ErrorMessage="Please select Business Unit" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Directorate" runat="server" Text="Directorate"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rad_Directorate" runat="server" MarkFirstMatch="true" Filter="Contains"
                                        Skin="WebBlue" AutoPostBack="true" EnableEmbeddedSkins="false" MaxHeight="120px" MaxLength="40" OnSelectedIndexChanged="rad_Directorate_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <%--<asp:RequiredFieldValidator ID="rfv_Directorate" runat="server" ErrorMessage="Please Select Directorate"
                                        ControlToValidate="rad_Directorate" ValidationGroup="Controls" InitialValue="Select">*</asp:RequiredFieldValidator>--%></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Department" runat="server" Text="Department"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rad_Department" AutoPostBack="True" runat="server" Skin="WebBlue" MaxLength="40" Filter="Contains"
                                        EnableEmbeddedSkins="false" MarkFirstMatch="true" MaxHeight="120px" OnSelectedIndexChanged="rad_Department_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <%--<asp:RequiredFieldValidator ID="rfv_Department" runat="server" ControlToValidate="rad_Department"
                                        InitialValue="Select" ErrorMessage="Please Select Department" ValidationGroup="Controls">*</asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_SubDepartment" runat="server" Text="Sub Department"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rad_SubDepartment" runat="server" MaxLength="50" AutoPostBack="true" Filter="Contains"
                                        EnableEmbeddedSkins="false" TabIndex="2" OnSelectedIndexChanged="rad_SubDepartment_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td></td>
                            </tr>
                            <tr align="center">
                                <td align="left">
                                    <asp:Label ID="lbl_InspectionName" runat="server" Text="Inspection Name"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="rad_InspectionName" AutoPostBack="true" OnSelectedIndexChanged="rad_InspectionName_SelectedIndexChanged"
                                        runat="server" Skin="WebBlue" MaxHeight="150px" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_InspectionName" runat="server" ControlToValidate="rad_InspectionName" ErrorMessage="Please select Inspection Name" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Description" runat="server" Text="Description"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rad_Description" runat="server" Skin="WebBlue" Enabled="false">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_AssignedTo" runat="server" Text="Assigned To"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Employees" runat="server" Filter="Contains"
                                        MarkFirstMatch="true" AutoPostBack="True" OnSelectedIndexChanged="rcmb_Employees_SelectedIndexChanged"
                                        MaxHeight="120px" Skin="WebBlue">
                                    </telerik:RadComboBox>
                                    <%-- <telerik:RadComboBox ID="rcmb_Employees" runat="server" Skin="WebBlue" HighlightTemplatedItems="True" EmptyMessage="Enter Employee Name"
                                        MarkFirstMatch="true" EnableLoadOnDemand="true" AutoPostBack="true" OnClientItemsRequesting="OnClientItemsRequesting" OnSelectedIndexChanged="rcmb_Employees_SelectedIndexChanged">
                                        <WebServiceSettings Method="GET_EmployeeBySearchString" Path="frm_ScheduleInspections.aspx" />
                                    </telerik:RadComboBox>--%>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_AssignedTo" runat="server" ControlToValidate="rcmb_Employees" ErrorMessage="Please select Assigned To" InitialValue="" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Date" runat="server" Text="Date&nbsp;<strong>:</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;From"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <%--<asp:Label ID="lbl_FromDate" runat="server" Text="From"></asp:Label>
                                </td>
                                <td>--%>
                                    <telerik:RadDatePicker ID="rdtp_FromDate" runat="server"
                                        Skin="WebBlue">
                                        <Calendar Skin="WebBlue" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                            ViewSelectorText="x">
                                        </Calendar>
                                        <DatePopupButton Skin="WebBlue" HoverImageUrl="" ImageUrl="" />
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_FromDate" runat="server" ControlToValidate="rdtp_FromDate" ErrorMessage="Please select From Date" InitialValue="" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_To" runat="server" Text="To&nbsp;<b>:</b>"></asp:Label>
                                    <%--</td>
                                <td>--%>
                                    <telerik:RadDatePicker ID="rdtp_ToDate" runat="server"
                                        Skin="WebBlue">
                                        <Calendar Skin="WebBlue" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                            ViewSelectorText="x">
                                        </Calendar>
                                        <DatePopupButton Skin="WebBlue" HoverImageUrl="" ImageUrl="" />
                                    </telerik:RadDatePicker>
                                </td>
                                <td>

                                    <asp:RequiredFieldValidator ID="rfv_ToDate" runat="server" ControlToValidate="rdtp_ToDate" ErrorMessage="Please select To Date" InitialValue="" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="cv_DOJ" runat="server" ControlToCompare="rdtp_FromDate" ControlToValidate="rdtp_ToDate"
                                        Display="Dynamic" Operator="GreaterThanEqual" Text="*" Type="Date" ErrorMessage="End Date should be greater than or equal to Start Date"
                                        ValidationGroup="Controls"></asp:CompareValidator>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Time" runat="server" Text="Time&nbsp;<strong>:</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;From"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <%--<asp:Label ID="lbl_FromTime" runat="server" Text="From"></asp:Label>
                                </td>
                                <td>--%>
                                    <telerik:RadTimePicker ID="rtp_FromTime" DateInput-ReadOnly="true" MinDate="1900-01-01" MaxLength="50" Culture="en-US" runat="server" Width="105px" TabIndex="5"></telerik:RadTimePicker>
                                </td>
                                <td>

                                    <asp:RequiredFieldValidator ID="rfv_FromTime" runat="server" ControlToValidate="rtp_FromTime" ErrorMessage="Please select From Time" InitialValue="" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_ToTime" runat="server" Text="To&nbsp;<b>:</b>"></asp:Label>
                                    <%--</td>
                                <td>--%>
                                    <telerik:RadTimePicker ID="rtp_ToTime" DateInput-ReadOnly="true" MinDate="1900-01-01" MaxLength="50" Culture="en-US" runat="server" Width="105px" TabIndex="5"></telerik:RadTimePicker>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_ToTime" runat="server" ControlToValidate="rtp_ToTime" ErrorMessage="Please select To Time" InitialValue="" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="cv_TimeValidator" runat="server" ControlToCompare="rtp_FromTime" ControlToValidate="rtp_ToTime"
                                        Display="Dynamic" Operator="GreaterThan" Text="*" Type="String" ErrorMessage="End Time should be greater than Start Time"
                                        ValidationGroup="Controls"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Area" runat="server" Text="Area"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadListBox ID="rlb_SelectArea" runat="server" CheckBoxes="true" Width="200px"
                                        Height="100px" AllowAutomaticUpdates="true">
                                    </telerik:RadListBox>
                                </td>
                                <td>
                                    <%--<asp:RequiredFieldValidator ID="rfvSelectArea" runat="server" ControlToValidate="rlb_SelectArea" ErrorMessage="Please Select Area"
                                        ValidationGroup="Controls" Enabled="false">*</asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                        </table>
                        <table align="center">
                            <tr>
                                <td align="center" colspan="3">
                                    <br />
                                    <asp:Button ID="btn_Submit" runat="server" Text="Save" ValidationGroup="Controls" OnClick="btn_Submit_Click" />
                                    <asp:Button ID="btn_Update" runat="server" Text="Update" ValidationGroup="Controls" OnClick="btn_Submit_Click" />
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
                                    <asp:ValidationSummary ID="vsSchInspections" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="Controls" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>
