<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_Relieving.aspx.cs" Inherits="HR_frm_Relieving" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadAjaxManagerProxy ID="RAM_Empreliveing" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rcmb_Employee">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnk_Add">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Cancel">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Submit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="Rg_AssetDetails">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="Rg_VNoDues">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="Rg_AssetDetails">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">

        <script type="text/javascript">
            function openRadWin(str) {
                radopen(str, "RW_Relieving");
            }

        </script>

    </telerik:RadScriptBlock>
    <table align="center">
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_EmpRelive_page" runat="server" Height="530px" 
                    Width="990px" SelectedIndex="0">
                    <telerik:RadPageView ID="Rp_EmpRelive_ViewMain" runat="server">
                        <table align="center">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lbl_EmpRelive" runat="server" Font-Bold="True" meta:resourcekey="lbl_EmpRelive"
                                        Text=" Employee Relieving"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_EmpRelive" runat="server" AutoGenerateColumns="False" Skin="WebBlue"
                                        GridLines="None" AllowPaging="true" OnNeedDataSource="Rg_EmpRelive_NeedDataSource"
                                        AllowFilteringByColumn="True">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="BUNIT" HeaderStyle-HorizontalAlign="Center" HeaderText="Business Unit"
                                                    meta:resourcekey="BUNIT" UniqueName="BUNIT">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMPNAME" HeaderStyle-HorizontalAlign="Center"
                                                    HeaderText="Employee" meta:resourcekey="EMPNAME" UniqueName="EMPNAME">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMP_RESGDATE" HeaderStyle-HorizontalAlign="Center"
                                                    HeaderText="Resigned Date" meta:resourcekey="EMP_RESGDATE" UniqueName="EMP_RESGDATE">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMP_RELDATE" HeaderStyle-HorizontalAlign="Center"
                                                    HeaderText="Relieving Date" meta:resourcekey="EMP_RELDATE" UniqueName="EMP_RELDATE">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMPLOYEEGRADE_CODE" UniqueName="EMPLOYEEGRADE_CODE" HeaderText="Grade">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("EMP_ID") %>'
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
                                                    <asp:LinkButton ID="lnk_Add" runat="server" meta:resourcekey="lnk_Add" OnCommand="lnk_Add_Command">Add</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <HeaderContextMenu Skin="WebBlue">
                                        </HeaderContextMenu>
                                        <PagerStyle AlwaysVisible="true" />
                                        <FilterMenu Skin="WebBlue">
                                        </FilterMenu>
                                        <GroupingSettings CaseSensitive="false" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_EmpRelive_ViewDetails" runat="server">
                        <table align="center">
                            <tr>
                                <td>
                                    <table align="center">
                                        <tr>
                                            <td colspan="2" align="center">
                                                <asp:Label ID="lbl_EmpRelieving" runat="server" Text="Employee Relieving" Font-Bold="True"
                                                    meta:resourcekey="lbl_EmpRelieving"></asp:Label>
                                            </td>
                                            <td align="center">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_Employee" runat="server" Text="Employee" meta:resourcekey="lbl_Employee"></asp:Label>
                                            </td>
                                            <td>
                                                <telerik:RadComboBox ID="rcmb_Employee" Skin="WebBlue" MarkFirstMatch="true" runat="server"
                                                    AutoPostBack="True" OnSelectedIndexChanged="rcmb_Employee_SelectedIndexChanged" Filter="Contains">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfv_rcmb_Employee" runat="server" Text="*" ErrorMessage="Please select a Employee"
                                                    ControlToValidate="rcmb_Employee" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnk_PersonalDetails" runat="server" Enabled="False" OnClientClick="return false">Personal Details</asp:LinkButton>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_EmpResgdDate" runat="server" Text="Resignation Date" meta:resourcekey="lbl_EmpResgdDate"></asp:Label>
                                            </td>
                                            <td>
                                                <telerik:RadDatePicker ID="rdtp_ResgDate" Skin="WebBlue" runat="server" Enabled="false"
                                                    meta:resourcekey="rdtp_RelDate">
                                                </telerik:RadDatePicker>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_RelDate" runat="server" Text="Relieving Date" meta:resourcekey="lbl_RelDate"></asp:Label>
                                            </td>
                                            <td>
                                                <telerik:RadDatePicker ID="rdtp_RelDate" Skin="WebBlue" runat="server" meta:resourcekey="rdtp_RelDate">
                                                </telerik:RadDatePicker>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfv_rdtp_RelDate" runat="server" Text="*" ErrorMessage="Relieving Date is Mandatory"
                                                    ControlToValidate="rdtp_RelDate" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                                <asp:CompareValidator ID="ctl_rdtp_RelievingDate" runat="server" ControlToCompare="rdtp_ResgDate"
                                                    ControlToValidate="rdtp_RelDate" ErrorMessage="Resigned Date cannot be ahead of Relieved Date"
                                                    Operator="GreaterThanEqual" Text="*" ValidationGroup="Controls" Type="Date"></asp:CompareValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadTabStrip ID="rd_Rel" runat="server" MultiPageID="RM_EMPREL_PAGE" SelectedIndex="0" Visible="false"
                                        Skin="WebBlue" Width="570px">
                                        <Tabs>
                                            <telerik:RadTab runat="server" Text="No Dues" Visible="false" PageViewID="RM_NODUE_VIEWPAGE">
                                            </telerik:RadTab>
                                            <telerik:RadTab runat="server" Text="Assets" Visible="false" PageViewID="RM_ASSETS_VIEWPAGE">
                                            </telerik:RadTab>
                                            <telerik:RadTab runat="server" Text="Documents" Visible="false" PageViewID="RM_DOC_VIEWPAGE">
                                            </telerik:RadTab>
                                        </Tabs>
                                    </telerik:RadTabStrip>
                                    <telerik:RadMultiPage ID="RM_EMPREL_PAGE" runat="server">
                                        <telerik:RadPageView ID="RM_NODUE_VIEWPAGE" runat="server" Width="500px">
                                            <telerik:RadGrid ID="Rg_VNoDues" Skin="WebBlue" runat="server" GridLines="None" Visible="false" AutoGenerateColumns="False">
                                                <MasterTableView>
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="HR_MASTER_ID" HeaderText="ID" UniqueName="HR_MASTER_ID"
                                                            Visible="false">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="HR_MASTER_CODE" HeaderText="NO Due" UniqueName="HR_MASTER_DESC"
                                                            Visible="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn AllowFiltering="False" HeaderText="Choose" UniqueName="TemplateColumn2">
                                                            <ItemTemplate>
                                                                <telerik:RadComboBox ID="rcmb_ChooseType" runat="server" MarkFirstMatch="true" EmptyMessage="Choose Type"
                                                                    Skin="WebBlue">
                                                                    <Items>
                                                                        <telerik:RadComboBoxItem runat="server" Text="Select" Value="-1" />
                                                                        <telerik:RadComboBoxItem runat="server" Text="Received" Value="1" />
                                                                        <telerik:RadComboBoxItem runat="server" Text="Pending" Value="2" />
                                                                        <telerik:RadComboBoxItem runat="server" Text="Rejected" Value="3" />
                                                                        <telerik:RadComboBoxItem runat="server" Text="NotApplicable" Value="4" />
                                                                    </Items>
                                                                </telerik:RadComboBox>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn AllowFiltering="False" HeaderText="Remarks" UniqueName="TemplateColumn3">
                                                            <ItemTemplate>
                                                                <telerik:RadTextBox ID="txtRemarks" runat="server" EmptyMessage="Enter Remarks" Skin="WebBlue">
                                                                </telerik:RadTextBox>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridTemplateColumn>
                                                    </Columns>
                                                </MasterTableView>
                                            </telerik:RadGrid>
                                        </telerik:RadPageView>
                                        <telerik:RadPageView ID="RM_ASSETS_VIEWPAGE" runat="server">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <telerik:RadGrid ID="Rg_AssetDetails" Skin="WebBlue" runat="server" AutoGenerateColumns="False"
                                                            GridLines="None">
                                                            <MasterTableView>
                                                                <Columns>
                                                                    <telerik:GridBoundColumn DataField="EMPASSETDOC_NAME" HeaderText="Asset Name" UniqueName="EMPASSETDOC_NAME"
                                                                        Visible="True">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridTemplateColumn AllowFiltering="False" HeaderText="Choose" UniqueName="TemplateColumn1">
                                                                        <ItemTemplate>
                                                                            <telerik:RadComboBox ID="rcmb_AssetType" runat="server" MarkFirstMatch="true" EmptyMessage="Choose Type"
                                                                                Skin="WebBlue">
                                                                                <Items>
                                                                                    <telerik:RadComboBoxItem runat="server" Text="Select" Value="-1" />
                                                                                    <telerik:RadComboBoxItem runat="server" Text="Received" Value="1" />
                                                                                    <telerik:RadComboBoxItem runat="server" Text="Pending" Value="2" />
                                                                                    <telerik:RadComboBoxItem runat="server" Text="Rejected" Value="3" />
                                                                                </Items>
                                                                            </telerik:RadComboBox>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle Width="100px" />
                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridTemplateColumn AllowFiltering="False" HeaderText="Remarks" UniqueName="TemplateColumn2">
                                                                        <ItemTemplate>
                                                                            <telerik:RadTextBox ID="rtxt_AssetRemarks" runat="server" EmptyMessage="Enter Remarks"
                                                                                Skin="WebBlue" Width="354px">
                                                                            </telerik:RadTextBox>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle />
                                                                    </telerik:GridTemplateColumn>
                                                                </Columns>
                                                            </MasterTableView>
                                                        </telerik:RadGrid>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <asp:Label ID="lbl_AsstMessage" runat="server" Text="No Assets Assigned  for this Employee"
                                                            Visible="False"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </telerik:RadPageView>
                                        <telerik:RadPageView ID="RM_DOC_VIEWPAGE" runat="server">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <telerik:RadGrid ID="Rg_Document" Skin="WebBlue" runat="server" GridLines="None"
                                                            AutoGenerateColumns="false">
                                                            <MasterTableView>
                                                                <Columns>
                                                                    <telerik:GridBoundColumn DataField="EMPASSETDOC_NAME" HeaderText="Document Name"
                                                                        UniqueName="EMPASSETDOC_NAME" Visible="True">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridTemplateColumn AllowFiltering="False" HeaderText="Choose" UniqueName="TemplateColumn1">
                                                                        <ItemTemplate>
                                                                            <telerik:RadComboBox ID="rcmb_DocType" runat="server" MarkFirstMatch="true" EmptyMessage="Choose Type"
                                                                                Skin="WebBlue">
                                                                                <Items>
                                                                                    <telerik:RadComboBoxItem runat="server" Text="Select" Value="-1" />
                                                                                    <telerik:RadComboBoxItem runat="server" Text="Handed Over" Value="1" />
                                                                                    <telerik:RadComboBoxItem runat="server" Text="Pending" Value="2" />
                                                                                </Items>
                                                                            </telerik:RadComboBox>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle />
                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridTemplateColumn AllowFiltering="False" HeaderText="Remarks" UniqueName="TemplateColumn2">
                                                                        <ItemTemplate>
                                                                            <telerik:RadTextBox ID="rtxt_DocRemarks" runat="server" EmptyMessage="Enter Remarks"
                                                                                Skin="WebBlue">
                                                                            </telerik:RadTextBox>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle Width="100px" />
                                                                    </telerik:GridTemplateColumn>
                                                                </Columns>
                                                            </MasterTableView>
                                                        </telerik:RadGrid>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <asp:Label ID="lbl_DOCMSG" runat="server" Text="No Documents Assigned  for this Employee"
                                                            Visible="False"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </telerik:RadPageView>
                                    </telerik:RadMultiPage>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table align="center">
                                        <tr>
                                            <td>
                                                <asp:Button ID="btn_Submit" runat="server" Text="Submit" OnClick="btn_Submit_Click"
                                                    ValidationGroup="Controls" Enabled="False" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ValidationSummary ID="vs_EmpRel" runat="server" ShowMessageBox="True" ShowSummary="False"
                                        ValidationGroup="Controls" />
                                </td>
                            </tr>
                        </table>
                        <table align="Center">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="rg_Reportees" runat="server" AutoGenerateColumns="False" Skin="WebBlue"
                                        GridLines="None" AllowPaging="true" OnNeedDataSource="rg_Reportees_NeedDataSource" Width="500px"
                                        AllowFilteringByColumn="True">
                                        <MasterTableView>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="EMP_ID" HeaderStyle-HorizontalAlign="Center"
                                                    Visible="false" UniqueName="EMP_ID">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMP_NAME" HeaderStyle-HorizontalAlign="Center"
                                                    HeaderText="Employee Name" UniqueName="EMP_NAME">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="POSITIONS_CODE" HeaderStyle-HorizontalAlign="Center"
                                                    HeaderText="Designation" UniqueName="POSITIONS_CODE">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="HR_MASTER_CODE" HeaderStyle-HorizontalAlign="Center"
                                                    HeaderText="Grade" UniqueName="HR_MASTER_CODE">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                            </Columns>
                                        </MasterTableView>
                                        <HeaderContextMenu Skin="WebBlue">
                                        </HeaderContextMenu>
                                        <PagerStyle AlwaysVisible="true" />
                                        <FilterMenu Skin="WebBlue">
                                        </FilterMenu>
                                        <GroupingSettings CaseSensitive="false" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>
