<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_Position.aspx.cs" Inherits="Masters_frm_Position" Culture="auto"
    meta:resourcekey="Page" UICulture="auto" %>


<asp:Content ID="cnt_Position" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadAjaxManagerProxy ID="RAM_Positions" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_Positions">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Rm_page" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnk_Edit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Rm_page" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnk_Add">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Rm_page" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Cancel">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Rm_page" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Save">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Rm_page" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Edit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Rm_page" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadWindowManager ID="RWM_POSITIONPOSTREPLY" runat="server" Style="z-index: 8000">
    </telerik:RadWindowManager>
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_PositionsHeader" runat="server" Text="Position" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_PO_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="490px" ScrollBars="Auto" meta:resourcekey="Rm_PO_page">
                    <telerik:RadPageView ID="Rp_PO_ViewMain" runat="server" Selected="True">
                        <table align="center" width="50%">
                            <tr>
                                <td align="center">
                                    <asp:UpdatePanel ID="Upnl_Grid" runat="server">
                                        <ContentTemplate>
                                            <telerik:RadAjaxPanel ID="RAP_Jobs" runat="server" Width="100%" LoadingPanelID="RLP_Applicant">
                                                <table align="center">
                                                    <tr>
                                                        <td align="center">
                                                            <telerik:RadGrid ID="Rg_Positions" runat="server" AutoGenerateColumns="False"
                                                                GridLines="None" Skin="WebBlue" OnNeedDataSource="Rg_Positions_NeedDataSource"
                                                                AllowPaging="True" AllowFilteringByColumn="true">
                                                                <HeaderContextMenu Skin="WebBlue">
                                                                </HeaderContextMenu>
                                                                <PagerStyle AlwaysVisible="true" />
                                                                <MasterTableView CommandItemDisplay="Top">
                                                                    <Columns>
                                                                        <telerik:GridBoundColumn DataField="POSITIONS_ID" HeaderText="ID" meta:resourcekey="POSITIONS_ID"
                                                                            UniqueName="POSITIONS_ID" Visible="False">
                                                                        </telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="POSITIONS_JOBSID" HeaderText="POSITIONS_JOBSID" meta:resourcekey="POSITIONS_JOBSID"
                                                                            UniqueName="POSITIONS_JOBSID" Visible="False">
                                                                        </telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="POSITIONS_CODE" HeaderText="Name" meta:resourcekey="POSITIONS_CODE"
                                                                            UniqueName="POSITIONS_CODE" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="POSITIONS_DESC" HeaderText="Desc" meta:resourcekey="POSITIONS_DESC"
                                                                            UniqueName="POSITIONS_DESC" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="POSITIONS_STATUS" HeaderText="Status" meta:resourcekey="POSITIONS_STATUS"
                                                                            UniqueName="POSITIONS_STATUS" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </telerik:GridBoundColumn>
                                                                        <telerik:GridTemplateColumn meta:resourcekey="GridTemplateColumn" UniqueName="ColEdit"
                                                                            AllowFiltering="false">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("POSITIONS_ID") %>'
                                                                                    meta:resourcekey="lnk_Edit" OnCommand="lnk_Edit_Command">Edit</asp:LinkButton>
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
                                                                <FilterMenu Skin="WebBlue">
                                                                </FilterMenu>
                                                                <GroupingSettings CaseSensitive="false" />
                                                            </telerik:RadGrid>
                                                        </td>
                                                    </tr>

                                                </table>
                                            </telerik:RadAjaxPanel>
                                        </ContentTemplate>

                                    </asp:UpdatePanel>

                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_PO_ViewDetails" runat="server" meta:resourcekey="Rp_PO_ViewDetails">
                        <table align="center" width="70%">
                            <tr>
                                <td>
                                    <table width="100%">
                                        <tr>
                                            <td colspan="3" align="center" style="font-weight: bold;"></td>
                                            <td align="center" style="font-weight: bold;"></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_PositionsID" runat="server" Visible="False" meta:resourcekey="lbl_PositionsID"></asp:Label>
                                                <asp:Label ID="lbl_PositionJobsID" runat="server" Visible="False" meta:resourcekey="lbl_PositionJobsID"></asp:Label>
                                                <asp:Label ID="lbl_PositionsCode" runat="server" Text="Name" meta:resourcekey="lbl_PositionsCode"></asp:Label>
                                            </td>
                                            <td><b>:</b>
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="rtxt_PositionsCode" runat="server" TabIndex="1"
                                                    Skin="WebBlue" MaxLength="100">
                                                </telerik:RadTextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfv_rtxt_PositionsCode" runat="server" ControlToValidate="rtxt_PositionsCode"
                                                    ErrorMessage="Please Select Name " ValidationGroup="Controls" meta:resourcekey="rfv_rtxt_PositionsCode">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="rev_Code" runat="server" ControlToValidate="rtxt_PositionsCode"
                                                    ErrorMessage="Please Enter Valid Position Name" ValidationExpression="^[a-zA-Z0-9\s\\()/]+$"
                                                    ValidationGroup="Controls">*</asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_PositionsDesc" runat="server" Text="Job Description" meta:resourcekey="lbl_PositionsDesc"></asp:Label>
                                            </td>
                                            <td><b>:</b>
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="rtxt_PositionsDesc" runat="server" MaxLength="100" TabIndex="2"
                                                    Skin="WebBlue" TextMode="MultiLine">
                                                </telerik:RadTextBox>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_PositionsJobs" runat="server" meta:resourcekey="lbl_PositionsJob"
                                                    Text="Job"></asp:Label>
                                            </td>
                                            <td><b>:</b>
                                            </td>
                                            <td>
                                                <telerik:RadComboBox ID="rcmb_PositionsJobs" runat="server" MarkFirstMatch="true" MaxHeight="120px" TabIndex="3"
                                                    Skin="WebBlue" OnSelectedIndexChanged="rcmb_PositionsJobs_SelectedIndexChanged"
                                                    AutoPostBack="True" Filter="Contains">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfv_rcmb_PositionsJobs" runat="server" ControlToValidate="rcmb_PositionsJobs"
                                                    ErrorMessage="Please select a Job" ValidationGroup="Controls" InitialValue="Select"
                                                    meta:resourcekey="rfv_rcmb_PositionsJobs">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="startdate" runat="server" visible="true">
                                            <td>
                                                <asp:Label ID="lbl_PositionsStartDate1" runat="server" meta:resourcekey="lbl_PositionsStartDate"
                                                    Text="Job&nbsp;Start&nbsp;Date"></asp:Label>
                                            </td>
                                            <td><b>:</b>
                                            </td>
                                            <td>
                                                <telerik:RadDatePicker ID="lbl_PositionsStartDate0" runat="server"
                                                    Enabled="False" Skin="WebBlue">
                                                    <Calendar Skin="WebBlue" runat="server"
                                                        UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                                        ViewSelectorText="x">
                                                    </Calendar>
                                                    <DatePopupButton CssClass="rcCalPopup rcDisabled" HoverImageUrl=""
                                                        ImageUrl="" />
                                                    <DateInput DateFormat="dd-MM-yyyy" DisplayDateFormat="dd-MM-yyyy"
                                                        runat="server">
                                                    </DateInput>
                                                </telerik:RadDatePicker>
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr id="enddate" runat="server" visible="false">
                                            <td>
                                                <asp:Label ID="lbl_PositionsEndDate1" runat="server" meta:resourcekey="lbl_PositionsEndDate"
                                                    Text="Job&nbsp;End&nbsp;Date"></asp:Label>
                                            </td>
                                            <td><b>:</b>
                                            </td>
                                            <td>
                                                <telerik:RadDatePicker ID="lbl_PositionsEndDate0" runat="server" TabIndex="4"
                                                    Enabled="False" Skin="WebBlue">
                                                </telerik:RadDatePicker>
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_PositionsStatus" runat="server" Text="Status" meta:resourcekey="lbl_PositionsStatus"></asp:Label>
                                            </td>
                                            <td><b>:</b>
                                            </td>
                                            <td>
                                                <telerik:RadComboBox ID="rcmb_PositionsStatus" runat="server" MarkFirstMatch="true" AutoPostBack="true" OnSelectedIndexChanged="rcmb_status_selectedchanged" MaxHeight="120px" TabIndex="5"
                                                    Skin="WebBlue">
                                                    <Items>
                                                        <telerik:RadComboBoxItem runat="server" Text="Select" Value="-1" />
                                                        <telerik:RadComboBoxItem runat="server" Text="Active" Value="0" />
                                                        <telerik:RadComboBoxItem runat="server" Text="InActive" Value="1" />
                                                    </Items>
                                                </telerik:RadComboBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfv_rcmb_PositionsStatus" runat="server" ControlToValidate="rcmb_PositionsStatus"
                                                    ErrorMessage="Please select the Status" InitialValue="Select" meta:resourcekey="rfv_rcmb_PositionsStatus"
                                                    ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="pos_sd" runat="server" visible="true">
                                            <td>
                                                <asp:Label ID="lbl_PositionsStartDate" runat="server" meta:resourcekey="lbl_PositionsStartDate"
                                                    Text="Position Start Date"></asp:Label>
                                            </td>
                                            <td><b>:</b>
                                            </td>
                                            <td>
                                                <telerik:RadDatePicker ID="rdtp_PositionsStartDate" runat="server" TabIndex="6"
                                                    Skin="WebBlue">
                                                </telerik:RadDatePicker>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfv_rdtp_PositionsStartDate" runat="server" ControlToValidate="rdtp_PositionsStartDate"
                                                    ErrorMessage="Please select Start date " meta:resourcekey="rfv_rdtp_PositionsStartDate" Visible="true" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                                <asp:CompareValidator ID="rcv_rdtp_PositionsStartDate" runat="server" ControlToCompare="lbl_PositionsStartDate0" Visible="true"
                                                    ControlToValidate="rdtp_PositionsStartDate" ErrorMessage="Position Start Date Cannot be Less than Jobs Start Date" ValidationGroup="Controls"
                                                    Operator="GreaterThanEqual">*</asp:CompareValidator>
                                            </td>
                                        </tr>
                                        <tr id="pos_ed" runat="server" visible="false">
                                            <td>
                                                <asp:Label ID="lbl_PositionsEndDate" runat="server" meta:resourcekey="lbl_PositionsEndDate"
                                                    Text="Position End Date"></asp:Label>
                                            </td>
                                            <td><b>:</b>
                                            </td>
                                            <td>
                                                <telerik:RadDatePicker ID="rdtp_PositionsEndDate" runat="server" TabIndex="7"
                                                    Skin="WebBlue">
                                                </telerik:RadDatePicker>
                                            </td>
                                            <td>
                                                <asp:CompareValidator ID="rcv_rdtp_PositionsEndDate" runat="server" ControlToCompare="rdtp_PositionsStartDate"
                                                    ControlToValidate="rdtp_PositionsEndDate" ErrorMessage="EndDate Cannot be less than StartDate" Visible="false"
                                                    Operator="GreaterThanEqual">*</asp:CompareValidator>
                                                <asp:CompareValidator ID="rcv_rdtp_PositionsEndDate0" runat="server" ControlToCompare="lbl_PositionsEndDate0"
                                                    ControlToValidate="rdtp_PositionsEndDate" ErrorMessage="Position End Date Cannot be Less than Jobs End Date" Visible="false"
                                                    Operator="GreaterThanEqual">*</asp:CompareValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td>&nbsp;
                                            </td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td>&nbsp;
                                            </td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                    </table>


                                </td>
                                <td valign="top">
                                    <table width="100%">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_JobsGrade" runat="server" Text="Scale"></asp:Label>
                                            </td>
                                            <td><b>:</b>
                                            </td>
                                            <td>
                                                <telerik:RadComboBox ID="rcmb_JobsGrade" runat="server" MarkFirstMatch="true" MaxHeight="120px" TabIndex="8"
                                                    Skin="WebBlue" Filter="Contains">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td>
                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="rcmb_JobsGrade"
                                                    ErrorMessage="Please select the Scale" InitialValue="Select" meta:resourcekey="RequiredFieldValidator2"
                                                    ValidationGroup="Controls">*</asp:RequiredFieldValidator>--%>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_JobsSkills" runat="server" meta:resourcekey="lbl_JobsSkills" Text="Skills"></asp:Label>
                                            </td>
                                            <td><b>:</b>
                                            </td>
                                            <td>
                                                <input id="rcmb_JobsSkills_Value" runat="server" type="hidden" />
                                                <telerik:RadListBox ID="RadListBox1" runat="server" CheckBoxes="true" TabIndex="9"
                                                    Height="130px" Width="200px">
                                                </telerik:RadListBox>
                                                <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td></td>
                                        </tr>

                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_Qualification" runat="server" Text="Qualification" meta:resourcekey="lbl_Qualification"></asp:Label>
                                            </td>
                                            <td><b>:</b>
                                            </td>
                                            <td>
                                                <telerik:RadListBox ID="rcmb_Qualification" runat="server" Skin="WebBlue" CheckBoxes="true" Height="130px" Width="200px" TabIndex="10">
                                                </telerik:RadListBox>
                                            </td>
                                            <td></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2" style="padding-right: 40px;">
                                    <asp:Button ID="btn_Edit" runat="server" meta:resourcekey="btn_Edit" OnClick="btn_Save_Click" TabIndex="11"
                                        Text="Update" ValidationGroup="Controls" Visible="False" />
                                    <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click" TabIndex="11"
                                        Text="Save" ValidationGroup="Controls" Visible="False" />
                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click" TabIndex="12"
                                        Text="Cancel" />
                                    <asp:ValidationSummary ID="vs_Positions" runat="server" meta:resourcekey="vs_Positions"
                                        ShowMessageBox="True" ShowSummary="False" ValidationGroup="Controls" />
                                </td>
                            </tr>

                            <tr>
                                <td colspan="2">
                                    <table id="tdEstablishMents" runat="server" visible="false">
                                        <tr>
                                            <td colspan="4" align="center"><b>Establishment</b></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:HiddenField ID="hdnEstablishmentID" runat="server"></asp:HiddenField>
                                                <asp:Label ID="lbl_Period" runat="server" Text="Financial Period" MarkFirstMatch="true">
                                                </asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td>
                                                <telerik:RadComboBox ID="rcmb_Period" runat="server" Skin="WebBlue" TabIndex="13" Filter="Contains">
                                                </telerik:RadComboBox>

                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rcmb_Period"
                                                    ErrorMessage="Please select a Financial Period" ValidationGroup="Controls1" InitialValue="Select"
                                                    meta:resourcekey="RequiredFieldValidator1">*</asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblNoEstablishment" runat="server" Text="Establishment" meta:resourcekey="lblNoEstablishment"></asp:Label>
                                            </td>
                                            <td><b>:</b>
                                            </td>
                                            <td>
                                                <telerik:RadNumericTextBox ID="rtxtNoEstablishment" MinValue="1" runat="server" Skin="WebBlue" TabIndex="14" MaxLength="5"
                                                    EmptyMessage="Number of Positions" NumberFormat-GroupSeparator="" NumberFormat-DecimalDigits="0">
                                                </telerik:RadNumericTextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="rtxtNoEstablishment"
                                                    ErrorMessage="Establish cannot be Empty" ValidationGroup="Controls1" meta:resourcekey="rtxtNoEstablishment">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnAdd" runat="server" meta:resourcekey="btnAdd" OnClick="btnAdd_Click" TabIndex="15"
                                                    Text="Add" Visible="false" ValidationGroup="Controls1" />
                                                <asp:Button ID="btnUpdate" runat="server" meta:resourcekey="btnUpdate" OnClick="btnUpdate_Click"
                                                    Text="Update" Visible="false" ValidationGroup="Controls1" />
                                                <%--<asp:Button ID="btnFinalise" runat="server" meta:resourcekey="btnFinalise" OnClick="btnFinalise_Click" TabIndex="16"
                                                    Text="Finalise" Visible="false" ValidationGroup="Controls1" />--%>
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" meta:resourcekey="ValidationSummary1"
                                                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="Controls1" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <telerik:RadGrid ID="RadEstablishMents" runat="server" AutoGenerateColumns="False"
                                                    GridLines="None" Skin="WebBlue" PageSize="50" OnNeedDataSource="RadEstablishMents_NeedDataSource"
                                                    AllowPaging="True">
                                                    <%-->--%>
                                                    <PagerStyle AlwaysVisible="true" />
                                                    <MasterTableView>
                                                        <Columns>
                                                            <telerik:GridBoundColumn DataField="ESTABLISHMENTS_ID" HeaderText="ID" meta:resourcekey="ESTABLISHMENTS_ID"
                                                                UniqueName="ESTABLISHMENTS_ID" Visible="False">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="PERIOD_NAME" HeaderText="Financial Period" meta:resourcekey="PERIOD_NAME"
                                                                UniqueName="PERIOD_NAME">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="ESTABLISHMENTS_NO" HeaderText="Establishment No" meta:resourcekey="ESTABLISHMENTS_NO"
                                                                UniqueName="ESTABLISHMENTS_NO" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridTemplateColumn meta:resourcekey="GridTemplateColumn" UniqueName="ColEdit"
                                                                AllowFiltering="false">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("ESTABLISHMENTS_ID") %>'
                                                                        meta:resourcekey="lnk_Edit" OnCommand="lnk_Establish_Edit_Command">Edit</asp:LinkButton>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                        </Columns>

                                                    </MasterTableView>
                                                    <GroupingSettings CaseSensitive="false" />
                                                </telerik:RadGrid>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>



                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>