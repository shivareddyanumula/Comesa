<%@ Page Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_employeescheme.aspx.cs" Inherits="Pension_frm_employeescheme_" Title="Untitled Page" %>


<%@ Register Src="~/BUFilter.ascx" TagName="BU" TagPrefix="BUFilter" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <br />
    <br />
    <telerik:RadAjaxManagerProxy ID="RAM_MedicalBenfitClaim" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_MedicalBenfitClaim">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnk_Edit">
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
            <telerik:AjaxSetting AjaxControlID="btn_Save">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Update">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <table align="center" style="vertical-align: top;">
        <tr>
            <td>
                <telerik:RadWindowManager ID="RWM_POSTREPLY1" runat="server" Style="z-index: 8000">
                </telerik:RadWindowManager>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lbl_scheme" runat="server" Text="Employee Scheme Details" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_CY_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="650px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_CY_ViewMain" runat="server" Selected="True">
                        <asp:UpdatePanel ID="updPanel1" runat="server">
                            <ContentTemplate>
                                <table align="center" width="50%">
                                    <tr>
                                        <td>
                                            <telerik:RadGrid ID="Rg_MedicalClaim" runat="server" AutoGenerateColumns="False"
                                                GridLines="None" Skin="WebBlue" OnNeedDataSource="Rg_MedicalClaim_NeedDataSource"
                                                AllowPaging="True" AllowFilteringByColumn="true">
                                                <MasterTableView CommandItemDisplay="Top">
                                                    <Columns>
                                                        <%--<telerik:GridBoundColumn DataField="EMP_MEMBERID" UniqueName="EMP_MEMBERID" HeaderText="ID"
                                                            meta:resourcekey="EMP_MEMBERID" Visible="False">
                                                        </telerik:GridBoundColumn>--%>
                                                        <telerik:GridBoundColumn DataField="EMP_ID" UniqueName="EMP_ID" Visible="false" HeaderText="Emp ID"
                                                            meta:resourcekey="EMP_ID">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EMP_EMPCODE" UniqueName="EMP_EMPCODE" HeaderText="Employee Code"
                                                            meta:resourcekey="EMP_EMPCODE">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EMP_NAME" UniqueName="EMP_NAME" HeaderText="Employee Name"
                                                            meta:resourcekey="EMP_NAME">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BUSINESSUNIT_CODE" UniqueName="BUSINESSUNIT_CODE" HeaderText="Business Unit"
                                                            meta:resourcekey="BUSINESSUNIT_CODE">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EMP_MEMBERID" UniqueName="EMP_MEMBERID" HeaderText="Provident Fund ID"
                                                            meta:resourcekey="EMP_MEMBERID">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EMP_PENSION_DOJ" UniqueName="EMP_PENSION_DOJ" HeaderText="Join Date" DataFormatString="{0:dd/MM/yyyy}"
                                                            meta:resourcekey="EMP_PENSION_DOJ">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="GridTemplateColumnResource1" AllowFiltering="false">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("EMP_ID") %>'
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
                                    <tr>
                                        <td>

                                            <table>
                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>

                                                    <td></td>
                                                </tr>

                                            </table>

                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>

                        </asp:UpdatePanel>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_CY_ViewDetails" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <table align="center" width="50%">
                                    <tr>
                                        <td colspan="3" align="center" style="font-weight: bold;"></td>
                                    </tr>
                                    <%--<tr>
                                <td colspan="3" align="left">
                                    &nbsp;<BUFilter:BU ID="BU1" runat="server" />
                                </td>
                            </tr>--%>
                                    <tr>
                                        <td style="width: 150px">Business Unit</td>
                                        <td>:</td>
                                        <td>
                                            <telerik:RadComboBox ID="RadBusinessUnit" runat="server" MaxHeight="150" AutoPostBack="True" OnSelectedIndexChanged="RadBusinessUnit_SelectedIndexChanged" EmptyMessage="Select" MarkFirstMatch="true" Filter="Contains"></telerik:RadComboBox>
                                            <span id="spBU" runat="server" visible="false" style="color: red;">*</span>
                                        </td>
                                    </tr>
                                    <tr id="trDirec" runat="server">
                                        <td>Directorate</td>
                                        <td>:</td>
                                        <td>
                                            <telerik:RadComboBox ID="RadDirectorate" runat="server" MaxHeight="150" AutoPostBack="True" OnSelectedIndexChanged="RadDirectorate_SelectedIndexChanged" EmptyMessage="Select" MarkFirstMatch="true" Filter="Contains"></telerik:RadComboBox>
                                            <span id="spDir" runat="server" visible="false" style="color: red;">*</span>
                                        </td>
                                    </tr>
                                    <tr id="trDept" runat="server">
                                        <td>Department</td>
                                        <td>:</td>
                                        <td>
                                            <telerik:RadComboBox ID="RadDepartment" runat="server" MaxHeight="150" AutoPostBack="True" OnSelectedIndexChanged="RadDepartment_SelectedIndexChanged" EmptyMessage="Select" MarkFirstMatch="true" Filter="Contains"></telerik:RadComboBox>
                                            <span id="spDep" runat="server" visible="false" style="color: red;">*</span>
                                        </td>
                                    </tr>
                                    <tr id="trEmp" runat="server">
                                        <td>Employee</td>
                                        <td>:</td>
                                        <td>
                                            <telerik:RadComboBox ID="RadEmployee" runat="server" MaxHeight="150" AutoPostBack="True" OnSelectedIndexChanged="RadEmployee_SelectedIndexChanged" MarkFirstMatch="true" Filter="Contains"></telerik:RadComboBox>
                                            <span id="spEmp" runat="server" visible="false" style="color: red;">*</span>
                                        </td>
                                    </tr>




                                    <tr>
                                        <td style="width: 150px;">
                                            <asp:Label ID="lblSchemeID" runat="server" Visible="false"></asp:Label>
                                            <asp:Label ID="lblDateofJoiningScheme" runat="server" Text="Date of Joining Scheme"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadDatePicker ID="rdpDateofJoiningScheme" runat="server" MinDate="1900-01-01">
                                            </telerik:RadDatePicker>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*"
                                                ControlToValidate="rdpDateofJoiningScheme" ValidationGroup="Controls"
                                                Display="Dynamic" ErrorMessage="Please Select Date of Joining"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 150px;">
                                            <asp:Label ID="lblIDNumber" runat="server" Text="Provident Fund ID"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="radPensionIDNo" runat="server" Skin="WebBlue" MaxLength="20">
                                            </telerik:RadTextBox>
                                            <asp:RequiredFieldValidator ID="rfv_ExpenditureName" runat="server" Text="*"
                                                ControlToValidate="radPensionIDNo" ValidationGroup="Controls"
                                                Display="Dynamic" ErrorMessage="Please Enter Provident Fund ID"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3">
                                            <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Edit" OnClick="btn_Save_Click" ValidationGroup="Controls"
                                                Text="Update" Visible="False" />
                                            <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click" ValidationGroup="Controls"
                                                Text="Save" Visible="False" />
                                            <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click"
                                                Text="Cancel" />
                                            <asp:ValidationSummary ID="vs_Expenditure" runat="server" ShowMessageBox="True" ShowSummary="False"
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
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>