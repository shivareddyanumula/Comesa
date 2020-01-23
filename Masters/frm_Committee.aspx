<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_Committee.aspx.cs" Inherits="Masters_frm_Committee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <script type="text/javascript">
        function OnClientItemsRequesting(sender, eventArgs) {
            var context = eventArgs.get_context();
            context["FilterString"] = eventArgs.get_text();
        }
    </script>
    <telerik:RadWindowManager ID="RWM_COMMITTEE" runat="server" Style="z-index: 8000">
    </telerik:RadWindowManager>
    <telerik:RadAjaxManagerProxy ID="RAM_DPT" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_COMMITTEE">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_COMMITTEEHeader" runat="server" Text="Committee" Font-Bold="True"
                    meta:resourcekey="lbl_HolidayCalendarHeader"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_CY_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_DPT_ViewMain" runat="server" Selected="True">
                        <table align="center" width="50%">
                            <tr>
                                <td>


                                    <telerik:RadGrid ID="Rg_COMMITTEE" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        AllowPaging="True" AllowFilteringByColumn="true" Skin="WebBlue" OnNeedDataSource="Rg_COMMITTEE_NeedDataSource">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="COMMITTEE_ID" UniqueName="COMMITTEE_ID" HeaderText="ID"
                                                    meta:resourcekey="COMMITTEE_ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="COMMITTEE_CODE" UniqueName="COMMITTEE_CODE"
                                                    AllowFiltering="true" HeaderText="Name " meta:resourcekey="COMMITTEE_CODE"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="COMMITTEE_DESC" UniqueName="COMMITTEE_DESC"
                                                    AllowFiltering="true" HeaderText="Description" meta:resourcekey="COMMITTEE_DESC" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="COMMITTEE_REVIEW" UniqueName="COMMITTEE_REVIEW"
                                                    AllowFiltering="true" HeaderText="Review" meta:resourcekey="COMMITTEE_REVIEW" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="COMMITTEE_REASON" UniqueName="COMMITTEE_REASON"
                                                    AllowFiltering="true" HeaderText="Reason" meta:resourcekey="COMMITTEE_REASON" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="COMMITTEE_OUTCOME" UniqueName="COMMITTEE_OUTCOME"
                                                    AllowFiltering="true" HeaderText="Outcome" meta:resourcekey="COMMITTEE_OUTCOME" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn HeaderText="Status">
                                                    <ItemTemplate>
                                                        <%# (Boolean.Parse(Eval("COMMITTEE_STATUS").ToString())) ? "Active" : "InActive" %>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="ColEdit" AllowFiltering="false"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("COMMITTEE_ID") %>'
                                                            OnCommand="lnk_Edit_Command" meta:resourcekey="lnk_Edit">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" OnCommand="lnk_Add_Command" meta:resourceKey="lnk_Add">Add</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <PagerStyle AlwaysVisible="true" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                        <%-- <table align="center">
                            <tr>
                                <td align="center">
                                    <asp:UpdatePanel ID="updPanel1" runat="server">
                                        <ContentTemplate>
                                            <table align="center">
                                                <tr align="center">
                                                    <td align="center" colspan="3">
                                                        <asp:Label ID="lblheader" runat="server" Text="Import Committee Details" Font-Bold="true"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <a href="~/Masters/Importsheets/Import_Committee .xlsx" runat="server" id="A2">Download
                                                            Committee Details Template</a>
                                                    </td>
                                                    <td>
                                                        <asp:FileUpload ID="fu_COMMITTEE" runat="server" />
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
                    <telerik:RadPageView ID="Rp_COMMITTEE_ViewDetails" runat="server">
                        <table align="center" width="45%">
                            <tr>
                                <td colspan="3" align="center" style="font-weight: bold;"></td>
                                <td align="center" style="font-weight: bold;">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_CommiteeID" runat="server" meta:resourcekey="lbl_CommiteeID" Text="lbl_CommiteeID"
                                        Visible="False"></asp:Label>
                                    <asp:Label ID="lbl_CommiteeName" runat="server" Text="Name" meta:resourcekey="lbl_CommiteeName"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_CommiteeName" runat="server"
                                        Skin="WebBlue" MaxLength="100">
                                    </telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_CommiteeName" ControlToValidate="rtxt_CommiteeName"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please Enter Name" meta:resourcekey="rfv_rtxt_CommiteeName" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>


                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_CommitteeDesc" runat="server" Text="Description" meta:resourcekey="lbl_CommitteeDesc"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_CommitteeDesc" runat="server"
                                        Skin="WebBlue" MaxLength="100">
                                    </telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_CommitteeDesc" ControlToValidate="rtxt_CommitteeDesc"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please Enter Description "
                                        meta:resourcekey="rfv_rtxt_CommitteeDesc" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="rev_Code" runat="server" ControlToValidate="rtxt_CommitteeDesc" ErrorMessage="Enter only Alphabets for Committee Name"
                                        ValidationExpression="^[a-zA-Z''-'\s-]{1,50}$" ValidationGroup="Controls" Text="*" ForeColor="Red"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="lbl_CommitteeMembers" runat="server" Text=" Members" meta:resourcekey="lbl_CommitteeMembers"></asp:Label>
                                </td>
                                <td valign="top">
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_CommitteeEmployees" runat="server" Skin="WebBlue" HighlightTemplatedItems="True" EmptyMessage="Enter Employee Name" MaxHeight="120px" Filter="Contains"
                                        MarkFirstMatch="true" EnableLoadOnDemand="true" AutoPostBack="true" OnClientItemsRequesting="OnClientItemsRequesting" OnSelectedIndexChanged="rcmb_CommitteeEmployee_SelectedIndexChanged">
                                        <WebServiceSettings Method="GET_EmployeeBySearchString" Path="frm_Committee.aspx" />
                                    </telerik:RadComboBox>
                                    <asp:Button ID="btn_AddEmployees" runat="server" Text="Add" OnClick="btn_AddEmployees_Click" meta:resourcekey="btn_AddEmployees" />
                                    <div style="float: left;">
                                        <asp:ListBox ID="lstEmployees" runat="server" Width="200px" DataTextField="EMPNAME" DataValueField="EMP_ID" />
                                    </div>
                                    <asp:Button ID="btn_RemoveEmployees" runat="server" Text="Remove" meta:resourcekey="btn_RemoveEmployees" OnClick="btn_RemoveEmployees_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_CommitteeReview" runat="server" Text="Review" meta:resourcekey="lbl_CommitteeReview"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_Review" runat="server"
                                        Skin="WebBlue" MaxLength="50">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width=50%;">
                                    <asp:Label ID="lbl_CommitteeReason" runat="server" Text="Reason For Existence" meta:resourcekey="lbl_CommitteeReason"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_CommitteeReason" runat="server"
                                        Skin="WebBlue" MaxLength="50">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_CommitteeOutcome" runat="server" Text="Outcome of Committee" meta:resourcekey="lbl_CommitteeOutcome"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_CommitteeOutcome" runat="server"
                                        Skin="WebBlue" MaxLength="50">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="lbl_CommitteeStartDate" runat="server" meta:resourcekey="lbl_CommitteeStartDate"
                                        Text="Start Date"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="rdtp_CommitteeStartDate" runat="server" meta:resourcekey="rdtp_CommitteeStartDate"
                                        Skin="WebBlue">
                                    </telerik:RadDatePicker>
                                    <asp:RequiredFieldValidator ID="RFV_CommitteeStartDate" runat="server" ControlToValidate="rdtp_CommitteeStartDate"
                                        ErrorMessage="Please Specify Start Date" Text="*" ForeColor="Red" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_CommitteeEndDate" runat="server" meta:resourcekey="lbl_CommitteeEndDate"
                                        Text="End Date"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="rdtp_CommitteeEndDate" runat="server" meta:resourcekey="rdtp_CommitteeEndDate"
                                        Skin="WebBlue">
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <asp:CompareValidator ID="rcv_rdtp_CommitteeEndDate" runat="server" ControlToCompare="rdtp_CommitteeStartDate"
                                        ControlToValidate="rdtp_CommitteeEndDate" ErrorMessage="End Date should be Greater than Start Date"
                                        Operator="GreaterThan" ValidationGroup="Controls" Text="*" ForeColor="Red"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_CommitteeStatus" runat="server" Text="Status"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <%--  <asp:CheckBox ID="chk_Active" runat="server" Checked="true" />--%>
                                    <telerik:RadComboBox ID="rcmb_Status" runat="server" Skin="WebBlue"
                                        MarkFirstMatch="true">
                                        <Items>
                                            <telerik:RadComboBoxItem Text="Active" Value="1" Selected="true" />
                                            <telerik:RadComboBoxItem Text="InActive" Value="0" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" align="center">
                                    <asp:Button ID="btn_Update" runat="server" Text="Update" Visible="False" OnClick="btn_Save_Click" ValidationGroup="Controls"
                                        meta:resourcekey="btn_Edit" />
                                    <asp:Button ID="btn_Save" runat="server" Text="Save" Visible="False" OnClick="btn_Save_Click" ValidationGroup="Controls"
                                        meta:resourcekey="btn_Save" />
                                    <asp:Button ID="btn_Cancel" runat="server" OnClick="btn_Cancel_Click" Text="Cancel" meta:resourcekey="btn_Cancel" />
                                </td>
                                <td align="center">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:ValidationSummary ID="vs_HolidayCalendar" runat="server" ShowMessageBox="True"
                                        ValidationGroup="Controls" ShowSummary="False" meta:resourcekey="vs_HolidayCalendar" />
                                </td>
                                <td align="center">&nbsp;
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" Runat="Server">
</asp:Content>--%>