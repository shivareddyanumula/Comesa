<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_Pms_EmpSetup.aspx.cs" Inherits="PMS_frm_Pms_EmpSetup" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_Header" runat="server" Text="Employee Setup"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_EMPSETUP_PAGE" runat="server" SelectedIndex="0" ScrollBars="Auto"
                    meta:resourcekey="Rm_TASK_PAGEResource1">
                    <telerik:RadPageView ID="Rp_EMPSETUP_VIEWMAIN" runat="server" Selected="True" meta:resourcekey="Rp_TASK_VIEWMAINResource1">
                        <table align="center">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_EmpSetup" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        EnableEmbeddedSkins="false" AllowPaging="True" AllowFilteringByColumn="True"
                                        Skin="WebBlue" PageSize="5" meta:resourcekey="Rg_EmpSetupResource1" OnNeedDataSource="rgem_needsource">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="EMP_SETUP_ID" UniqueName="EMP_SETUP_ID" HeaderText="EMP_SETUP_ID"
                                                    meta:resourcekey="EMP_SETUP_ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="BU_ID" UniqueName="BU_ID" HeaderText="Business Unit">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>

                                                <telerik:GridBoundColumn DataField="EMP_ID" UniqueName="EMP_ID" HeaderText="Employee">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="REPORTINGMGR_ID" UniqueName="REPORTINGMGR_ID"
                                                    HeaderText="Reporting Manager">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="GENERALMGR_ID" UniqueName="GENERALMGR_ID" HeaderText="Group Manager">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="False" UniqueName="coledit" meta:resourcekey="GridTemplateColumnResource1">
                                                    <ItemTemplate>
                                                        <div align="right">
                                                            <asp:LinkButton ID="lnk_edit" runat="server" Text="Edit" CommandArgument='<%# Eval("EMP_SETUP_ID") %>'
                                                                OnCommand="lnk_edit_Command"></asp:LinkButton>
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_add" runat="server" Text="Add" OnCommand="lnk_Add_Command"></asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <PagerStyle AlwaysVisible="True" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_EMPSETUP_VIEWDETAILS" runat="server" meta:resourcekey="Rp_EMPSETUP_VIEWDETAILSResource1">
                        <table align="center">
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Label ID="lbl_Header2" runat="server" Text="Details"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Emp_Setup_Id" runat="server" Visible="False" meta:resourcekey="lbl_Emp_Setup_Id"></asp:Label>
                                    <asp:Label ID="lbl_BusinessUnitName" runat="server" Text="BusinessUnit"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="rcmb_BusinessUnitType" runat="server" AutoPostBack="True" MarkFirstMatch="true"
                                        Width="200px" EnableEmbeddedSkins="false" OnSelectedIndexChanged="rcmb_BusinessUnitType_SelectedIndexChanged"
                                        meta:resourcekey="rcmb_BusinessUnitTypeResource1" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_BusinessUnitType" ControlToValidate="rcmb_BusinessUnitType"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please Select BusinessUnit"
                                        InitialValue="Select">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Employee" runat="server" Text="Employee"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="rcmb_EmployeeType" runat="server" Width="200px" AutoPostBack="True" MarkFirstMatch="true"
                                        OnSelectedIndexChanged="rcmb_EmployeeType_SelectedIndexChanged" meta:resourcekey="rcmb_EmployeeTypeResource1"
                                        EnableEmbeddedSkins="false" MaxLength="10" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_EmployeeType" ControlToValidate="rcmb_EmployeeType"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please Select Employee"
                                        InitialValue="Select">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Reporting_Mgr" runat="server" Text="Reporting Manager"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="rcmb_ReportingMgrType" runat="server" Width="200px" meta:resourcekey="rcmb_ReportingMgrType" MarkFirstMatch="true"
                                        AutoPostBack="True" EnableEmbeddedSkins="false" MaxLength="10" OnSelectedIndexChanged="rcmb_ReportingMgrType_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_ReportingMgrType" ControlToValidate="rcmb_ReportingMgrType"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please Select Reporting Manager"
                                        InitialValue="Select">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_General_Mgr" runat="server" Text="Group Manager"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="rcmb_GeneralMgrType" runat="server" Width="200px" meta:resourcekey="rcmb_GeneralMgrType" Filter="Contains"
                                        EnableEmbeddedSkins="false" MaxLength="10" OnSelectedIndexChanged="rcmb_GeneralMgrType_SelectedIndexChanged" MarkFirstMatch="true">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_GeneralMgrType" ControlToValidate="rcmb_GeneralMgrType"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please Select Group Manager"
                                        InitialValue="Select">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" Text="Save"
                                        ValidationGroup="Controls" OnClick="btn_Save_Click" />
                                    <asp:Button ID="btn_update" runat="server" Text="Update"
                                        ValidationGroup="Controls" OnClick="btn_update_Click" />
                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click1"
                                        Text="Cancel" />

                                    <asp:ValidationSummary ID="vs_EmpSetup" runat="server" meta:resourcekey="vs_GOALResource1"
                                        ShowMessageBox="True" ShowSummary="False" ValidationGroup="Controls" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>