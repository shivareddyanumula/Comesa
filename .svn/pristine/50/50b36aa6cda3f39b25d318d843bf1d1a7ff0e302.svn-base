<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_ApproverProcess.aspx.cs" Inherits="Masters_frm_ApprovalProcess" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function OnClientItemsRequesting(sender, eventArgs) {
            var context = eventArgs.get_context();
            context["FilterString"] = eventArgs.get_text();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <script type="text/javascript"></script>
    <table align="center" style="vertical-align: top;">
        <tr>
            <td>
                <telerik:RadWindowManager ID="RWM_ApprovalProcess" runat="server" Style="z-index: 8000">
                </telerik:RadWindowManager>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lbl_ApprovalProcess" runat="server" Font-Bold="True"
                    Text="Approver Process"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadAjaxManagerProxy ID="RAM_ApprovalProcess" runat="server">
                    <AjaxSettings>
                        <telerik:AjaxSetting AjaxControlID="Rg_ApprovalProcess">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                    </AjaxSettings>
                </telerik:RadAjaxManagerProxy>
                <telerik:RadMultiPage ID="Rm_ApprovalProcess_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="1100px" Height="690px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_ApprovalProcess_ViewMain" runat="server" Selected="True">
                        <table align="center" width="50%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_ApprovalProcess" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        AllowPaging="True" AllowFilteringByColumn="true" Skin="WebBlue" OnNeedDataSource="Rg_ApprovalProcess_NeedDataSource">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="PMS_APPROVAL_PROCESS_ID" UniqueName="PMS_APPROVAL_PROCESS_ID" HeaderText="ID"
                                                    meta:resourcekey="PMS_APPROVAL_PROCESS_ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="BUSINESSUNIT_CODE" UniqueName="BUSINESSUNIT_CODE"
                                                    AllowFiltering="true" HeaderText="Business Unit"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMP_NAME_1" UniqueName="EMP_NAME_1"
                                                    AllowFiltering="true" HeaderText="Level 1"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMP_NAME_2" UniqueName="EMP_NAME_2"
                                                    AllowFiltering="true" HeaderText="Level 2"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMP_NAME_3" UniqueName="EMP_NAME_3" ItemStyle-Width="1px"
                                                    AllowFiltering="true" HeaderText="Level 3" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="ACTIVE_STATUS" UniqueName="ACTIVE_STATUS"
                                                    AllowFiltering="true" HeaderText="Status" ItemStyle-HorizontalAlign="Left"
                                                    HtmlEncode="false">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="ColEdit" AllowFiltering="false"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("PMS_APPROVAL_PROCESS_ID") %>'
                                                            meta:resourcekey="lnk_Edit" OnCommand="lnk_Edit_Command">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server"
                                                        CommandArgument='<%# Eval("PMS_APPROVAL_PROCESS_ID") %>'
                                                        meta:resourceKey="lnk_Add" OnCommand="lnk_Add_Command">Add</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <PagerStyle AlwaysVisible="true" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_ApprovalProcess_ADDView" runat="server">
                        <table align="center">
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Label ID="lbl_ApprovalProcess_ID" runat="server" Visible="False"></asp:Label>
                                    <br />
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblBusinessUnit" runat="server" Text="Business Unit"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_BusinessUnit" runat="server" Filter="Contains" meta:resourcekey="rcmb_BusinessUnit"></telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_BusinessUnit" runat="server" ControlToValidate="rcmb_BusinessUnit" InitialValue="Select" ErrorMessage="Please Select BusinessUnit" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Emp1" runat="server" meta:resourcekey="lbl_Emp1" Text="Level 1"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Emp1" runat="server" AutoPostBack="True" MarkFirstMatch="true" Skin="WebBlue" OnSelectedIndexChanged="rcmb_Emp1_SelectedIndexChanged"
                                        HighlightTemplatedItems="true" EmptyMessage="Select" EnableLoadOnDemand="true" OnClientItemsRequesting="OnClientItemsRequesting" Filter="Contains">
                                        <WebServiceSettings Method="GET_EmployeeBySearchString" Path="frm_ApproverProcess.aspx" />
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_Emp1" runat="server" ControlToValidate="rcmb_Emp1" ErrorMessage="Please select Level 1" InitialValue="" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Emp2" runat="server" Text="Level 2"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Emp2" runat="server" MarkFirstMatch="true" Skin="WebBlue" AutoPostBack="true" EnableEmbeddedSkins="false" MaxHeight="120px" MaxLength="40" Filter="Contains"
                                        OnSelectedIndexChanged="rcmb_Emp2_SelectedIndexChanged" HighlightTemplatedItems="true" EmptyMessage="Select" EnableLoadOnDemand="true" OnClientItemsRequesting="OnClientItemsRequesting">
                                        <WebServiceSettings Method="GET_EmployeeBySearchString" Path="frm_ApproverProcess.aspx" />
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_Emp2" runat="server" ControlToValidate="rcmb_Emp2"
                                        ErrorMessage="Please select Level 2" InitialValue="" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Emp3" runat="server" Text="Level 3"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Emp3" AutoPostBack="True" runat="server" Skin="WebBlue" MaxLength="40" EnableEmbeddedSkins="false" MarkFirstMatch="true" MaxHeight="120px" Filter="Contains"
                                        OnSelectedIndexChanged="rcmb_Emp3_SelectedIndexChanged" HighlightTemplatedItems="true" EmptyMessage="Select" EnableLoadOnDemand="true" OnClientItemsRequesting="OnClientItemsRequesting">
                                        <WebServiceSettings Method="GET_EmployeeBySearchString" Path="frm_ApproverProcess.aspx" />
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_Emp3" runat="server" ControlToValidate="rcmb_Emp3" ErrorMessage="Please select Level 3" InitialValue="" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Status" runat="server" Text="Is Active"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <asp:CheckBox ID="ChkStatus" runat="server" Enabled="false" Checked="true" />
                                </td>
                                <td></td>
                            </tr>

                            <%--<tr>
                                <td>
                                    <asp:Label ID="lbl_AssignedTo" runat="server" Text="Assigned To"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Employees" runat="server" Skin="WebBlue" HighlightTemplatedItems="True" EmptyMessage="Enter Employee Name"
                                        MarkFirstMatch="true" EnableLoadOnDemand="true" AutoPostBack="true" OnClientItemsRequesting="OnClientItemsRequesting" OnSelectedIndexChanged="rcmb_Employees_SelectedIndexChanged">
                                        <WebServiceSettings Method="GET_EmployeeBySearchString" Path="frm_ScheduleInspections.aspx" />
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_AssignedTo" runat="server" ControlToValidate="rcmb_Employees" ErrorMessage="Please select Employee" InitialValue="" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>--%>
                        </table>
                        <table align="center">
                            <tr>
                                <td align="center" colspan="3">
                                    <br />
                                    <asp:Button ID="btn_Submit" runat="server" Text="Submit" ValidationGroup="Controls" OnClick="btn_Submit_Click" />
                                    <asp:Button ID="btn_Update" runat="server" Text="Update" ValidationGroup="Controls" OnClick="btn_Submit_Click" />
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
                                    <asp:ValidationSummary ID="vsApprovalProcess" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="Controls" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>