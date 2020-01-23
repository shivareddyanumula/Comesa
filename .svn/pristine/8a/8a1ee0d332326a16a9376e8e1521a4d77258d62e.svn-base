<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_GoalSettings.aspx.cs" Inherits="PMS_frm_GoalSettings" Culture="auto"
    meta:resourcekey="PageResource2" UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadFormDecorator ID="RadFormDec1" runat="server" DecoratedControls="GridFormDetailsViews"
        EnableRoundedCorners="true" />
    <table align="center">
        <tr>
            <td>

                <table>
                    <tr>
                        <td align="center">

                            <asp:Label ID="lbl_head" runat="server" Text="Goal Settings" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <telerik:RadPanelBar runat="server" ID="RadPanelBar1" ExpandMode="SingleExpandedItem"
                                Width="740px" meta:resourcekey="RadPanelBar1Resource1" OnItemClick="RadPanelBar1_ItemClick">
                                <Items>
                                    <telerik:RadPanelItem Expanded="True" Text="Step 1: Job Details" runat="server" Selected="true"
                                        meta:resourcekey="RadPanelItemResource2">
                                        <Items>
                                            <telerik:RadPanelItem Value="Registration Fee Setup" runat="server">
                                                <ItemTemplate>
                                                    <table align="center">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_id" runat="server" Visible="False" meta:resourcekey="lbl_idResource1"></asp:Label>&nbsp
                                                                <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business Unit" meta:resourcekey="lbl_BusinessUnitResource1"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b></b>
                                                            </td>
                                                            <td>
                                                                <telerik:RadComboBox ID="RCB_BusinessUnit" AutoPostBack="True" runat="server" OnSelectedIndexChanged="RCB_BusinessUnit_SelectedIndexChanged"
                                                                    EnableEmbeddedSkins="false" meta:resourcekey="RCB_BusinessUnitResource2" MarkFirstMatch="true" Filter="Contains">
                                                                </telerik:RadComboBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RV_BusinessUnit" runat="server" Text="*" ErrorMessage="Enter BusinessUnit Name"
                                                                    ValidationGroup="controls1" ControlToValidate="RCB_BusinessUnit" InitialValue="Select"
                                                                    meta:resourcekey="RV_BusinessUnitResource2"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lbl_RMID" runat="server" Visible="false" Text="Reporting Manager"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_EmployeeName" runat="server" meta:resourcekey="lbl_EmployeeNameResource1"
                                                                    Text="Employee"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <telerik:RadComboBox ID="RCB_EmployeeName" runat="server" AutoPostBack="True" meta:resourcekey="RCB_EmployeeNameResource2"
                                                                    EnableEmbeddedSkins="false" OnSelectedIndexChanged="RCB_EmployeeName_SelectedIndexChanged" MarkFirstMatch="true" Filter="Contains">
                                                                </telerik:RadComboBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_RCB_EmployeeName" runat="server" Text="*" ErrorMessage="Please Select Employee"
                                                                    ValidationGroup="controls1" ControlToValidate="RCB_EmployeeName" InitialValue="Select"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lbl_ReportingManager" runat="server" meta:resourcekey="lbl_ReportingManagerResource1"
                                                                    Text="Reporting Manager"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="txt_ReportingManager" runat="server" meta:resourcekey="txt_ReportingManagerResource1"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_RoleName" runat="server" meta:resourcekey="lbl_RoleNameResource1"
                                                                    Text="Role Name"></asp:Label>
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td>
                                                                <telerik:RadComboBox ID="RCB_RoleName" runat="server" meta:resourcekey="RCB_RoleNameResource2"
                                                                    EnableEmbeddedSkins="false" MarkFirstMatch="true" Filter="Contains">
                                                                </telerik:RadComboBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RV_RoleName" runat="server" ControlToValidate="RCB_RoleName"
                                                                    ErrorMessage=" Please Select RoleName" InitialValue="Select" meta:resourcekey="RV_RoleNameResource2"
                                                                    Text="*" ValidationGroup="controls1"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lbl_GeneralManager" runat="server"
                                                                    Text="Group Manager"></asp:Label>
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="txt_GeneralManager" runat="server" meta:resourcekey="txt_GeneralManagerResource1"></asp:Label>
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_Project" runat="server" meta:resourcekey="lbl_ProjectResource1"
                                                                    Text="Project"></asp:Label>
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td>
                                                                <telerik:RadComboBox ID="RCMB_Project" runat="server" meta:resourcekey="RCMB_ProjectResource1"
                                                                    EnableEmbeddedSkins="false" MarkFirstMatch="true" Filter="Contains">
                                                                </telerik:RadComboBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RV_Project" runat="server" ControlToValidate="RCMB_Project"
                                                                    ErrorMessage="Please Select Project" meta:resourcekey="RV_ProjectResource2" Text="*"
                                                                    InitialValue="Select" ValidationGroup="controls1"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lbl_ApprasialCycle" runat="server" meta:resourcekey="lbl_ApprasialCycleResource1"
                                                                    Style="font-family: Arial, Helvetica, sans-serif; font-size: small" Text="Apprasial Cycle"></asp:Label>
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td>
                                                                <telerik:RadComboBox ID="RCB_ApprasialCycle" runat="server" EmptyMessage="Select" Filter="Contains"
                                                                    EnableEmbeddedSkins="false" meta:resourcekey="RCB_ApprasialCycleResource2" MarkFirstMatch="true">
                                                                </telerik:RadComboBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RV_ApprasialCycle" runat="server" ControlToValidate="RCB_ApprasialCycle"
                                                                    ErrorMessage="Please Select ApprasialCycle" InitialValue="Select" meta:resourcekey="RV_ApprasialCycleResource2"
                                                                    SetFocusOnError="True" Text="*" ValidationGroup="controls1"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_JobDescription" runat="server" meta:resourcekey="lbl_JobDescriptionResource1"
                                                                    Text="Job Description"></asp:Label>
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txt_JobDescription" runat="server" meta:resourcekey="txt_JobDescriptionResource1"
                                                                    TextMode="MultiLine"></asp:TextBox>
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td></td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table align="center">
                                                        <tr>
                                                            <td align="center" colspan="8">
                                                                <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click" ValidationGroup="controls1"
                                                                    meta:resourcekey="btn_SaveResource1" />&nbsp;
                                                            </td>
                                                            <td>
                                                                <asp:ValidationSummary ID="vs_goal" runat="server" ShowMessageBox="True" ShowSummary="False"
                                                                    ValidationGroup="controls1" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </telerik:RadPanelItem>
                                        </Items>
                                    </telerik:RadPanelItem>
                                    <telerik:RadPanelItem Expanded="True" Text="Step 2: KRA" runat="server" Selected="true"
                                        meta:resourcekey="RadPanelItemResource4">
                                        <Items>
                                            <telerik:RadPanelItem Value="Load KRA" runat="server" meta:resourcekey="RadPanelItemResource3">
                                                <ItemTemplate>
                                                    <table align="center">
                                                        <tr>
                                                            <td align="center" colspan="4">
                                                                <asp:Label ID="lbl_KRAHeading" runat="server" Text="Key Result Area"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_kra" runat="server" Text="[lbl_kra]" Visible="False" meta:resourcekey="lbl_kraResource1"></asp:Label><asp:Label
                                                                    ID="lbl_Kras" runat="server" Text="KRA" meta:resourcekey="lbl_KrasResource1"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <telerik:RadComboBox ID="RCB_KRA" AutoPostBack="True" EmptyMessage="Select" OnSelectedIndexChanged="RCB_KRA_SelectedIndexChanged"
                                                                    EnableEmbeddedSkins="false" runat="server" meta:resourcekey="RCB_KRAResource1" MarkFirstMatch="true" Filter="Contains">
                                                                </telerik:RadComboBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RV_kras" runat="server" ControlToValidate="RCB_KRA"
                                                                    ErrorMessage=" Select KRA's" InitialValue="Select" SetFocusOnError="True" Text="*"
                                                                    ValidationGroup="controls2" meta:resourcekey="RV_krasResource1"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_KraDescription" runat="server" Text="KRA Description" meta:resourcekey="lbl_KraDescriptionResource1"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txt_KraDescription" runat="server" TextMode="MultiLine" meta:resourcekey="txt_KraDescriptionResource1"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_Measure" runat="server" meta:resourcekey="lbl_MeasureResource2"
                                                                    Text="Measure"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txt_KraMeasure" runat="server" meta:resourcekey="txt_KraMeasureResource1"
                                                                    TextMode="MultiLine"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_Weightage" runat="server" meta:resourcekey="lbl_WeightageResource1"
                                                                    Text="Weightage"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <telerik:RadNumericTextBox ID="RNT_KraWeightage" runat="server" EnableEmbeddedSkins="false"
                                                                    MaxLength="2" meta:resourcekey="RNT_KraWeightageResource1">
                                                                </telerik:RadNumericTextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_kraweightage" runat="server" ControlToValidate="RNT_KraWeightage"
                                                                    ErrorMessage="Please Enter Weightage " InitialValue="Select" SetFocusOnError="True"
                                                                    Text="*" ValidationGroup="controls2"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Lbl_Target" runat="server" Text="Target"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>:</b>
                                                            </td>
                                                            <td>
                                                                <telerik:RadNumericTextBox ID="RNT_KraTarget" runat="server" EnableEmbeddedSkins="false"
                                                                    Type="Percent" MinValue="0" MaxValue="100">
                                                                </telerik:RadNumericTextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_kraTarget" runat="server" ControlToValidate="RNT_KraTarget"
                                                                    ErrorMessage="Please Enter Target " SetFocusOnError="True" Text="*" ValidationGroup="controls2"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style2">
                                                                <asp:Label ID="lbl_TIMELINES" runat="server" Text="Timelines"></asp:Label>
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td>
                                                                <telerik:RadDatePicker ID="rdtp_TIMELINES" runat="server" EnableEmbeddedSkins="false">
                                                                </telerik:RadDatePicker>
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_rdtp_TIMELINES" runat="server" ControlToValidate="rdtp_TIMELINES"
                                                                    ErrorMessage="Timelines Cannot Be Empty" ValidationGroup="controls2">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td align="center" colspan="4">
                                                                <asp:Button ID="btn_SaveAssignkra" runat="server" Text="Add" OnClick="btn_SaveAssignkra_Click"
                                                                    ValidationGroup="controls2" meta:resourcekey="btn_SaveAssignkraResource1" />
                                                                <asp:Button ID="btn_UpdateAssignkra" Text="Update" runat="server" OnClick="btn_UpdateAssignkra_Click"
                                                                    ValidationGroup="controls2" Visible="false" meta:resourcekey="btn_UpdateAssignkraResource1" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:ValidationSummary ID="vs_kra" runat="server" ShowMessageBox="True" ShowSummary="False"
                                                                    ValidationGroup="controls2" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="4">
                                                                <telerik:RadGrid ID="RG_kraform" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                                                    EnableEmbeddedSkins="false" PageSize="5" Skin="WebBlue" GridLines="None" AllowFilteringByColumn="True"
                                                                    meta:resourcekey="RG_kraformResource1">
                                                                    <MasterTableView>
                                                                        <Columns>
                                                                            <telerik:GridBoundColumn HeaderText="Kraid" DataField="KRAID" Visible="False" meta:resourcekey="GridBoundColumnResource16"
                                                                                UniqueName="KRAID">
                                                                            </telerik:GridBoundColumn>
                                                                            <telerik:GridBoundColumn HeaderText="KRA Name" DataField="KRANAME" UniqueName="KRANAME">
                                                                            </telerik:GridBoundColumn>
                                                                            <telerik:GridTemplateColumn Visible="false">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_KRANAME" runat="server" Text='<%# Eval("KRANAME") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridBoundColumn HeaderText="Description" DataField="KRAdesc" meta:resourcekey="GridBoundColumnResource18"
                                                                                UniqueName="KRAdesc">
                                                                            </telerik:GridBoundColumn>
                                                                            <telerik:GridBoundColumn HeaderText="Measure" DataField="KRAMEASURE" meta:resourcekey="GridBoundColumnResource19"
                                                                                UniqueName="KRAMEASURE">
                                                                            </telerik:GridBoundColumn>
                                                                            <telerik:GridBoundColumn HeaderText="Weightage" DataField="KRAWEIGHTAGE" meta:resourcekey="GridBoundColumnResource20"
                                                                                UniqueName="KRAWEIGHTAGE">
                                                                            </telerik:GridBoundColumn>

                                                                            <telerik:GridBoundColumn HeaderText="Target" DataField="KRATarget">
                                                                            </telerik:GridBoundColumn>
                                                                            <telerik:GridBoundColumn HeaderText="Timelines" DataField="KRATimelines">
                                                                            </telerik:GridBoundColumn>

                                                                            <telerik:GridTemplateColumn AllowFiltering="False" UniqueName="TemplateColumn" meta:resourcekey="GridTemplateColumnResource5">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnk_Edit" runat="server" OnCommand="lnk_Edit_Commnad" CommandArgument='<%# Eval("Sr_No") %>'
                                                                                        Text="Edit" meta:resourcekey="lnk_EditResource3"></asp:LinkButton>
                                                                                </ItemTemplate>
                                                                            </telerik:GridTemplateColumn>
                                                                        </Columns>
                                                                    </MasterTableView>
                                                                </telerik:RadGrid>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="4">
                                                                <asp:Button ID="btn_KRASubmit" runat="server" Text="Submit" OnClick="btn_KRASubmit_Click"
                                                                    meta:resourcekey="btn_KRASubmitResource1" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </telerik:RadPanelItem>
                                        </Items>
                                    </telerik:RadPanelItem>
                                    <telerik:RadPanelItem Expanded="True" Text="Step 3: Goal" runat="server" meta:resourcekey="RadPanelItemResource6">
                                        <Items>
                                            <telerik:RadPanelItem Value="Goal Details" runat="server" meta:resourcekey="RadPanelItemResource5">
                                                <ItemTemplate>
                                                    <table align="center">
                                                        <tr>
                                                            <telerik:RadMultiPage ID="RMP_GoalSettings_Details" runat="server" meta:resourcekey="RMP_GoalSettings_DetailsResource2"
                                                                SelectedIndex="0">
                                                                <telerik:RadPageView ID="RPV_GoalSetting_AddDetails" runat="server" Width="100%"
                                                                    Selected="True" meta:resourcekey="RPV_GoalSetting_AddDetailsResource1">
                                                                    <table align="center">
                                                                        <tr>
                                                                            <td align="center" colspan="4">
                                                                                <asp:Label if="lbl_GSD" runat="server" Text="GoalSettings Details"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: left">
                                                                                <asp:Label ID="lbl_GSDetails" runat="server" Visible="False" meta:resourcekey="lbl_GSDetailsResource2"></asp:Label><asp:Label
                                                                                    ID="lbl_GoalName" runat="server" Text="Goal Name" meta:resourcekey="lbl_GoalNameResource2"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <b>:</b>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txt_GoalName" runat="server" meta:resourcekey="txt_GoalNameResource2"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="RV_GoalName" runat="server" ErrorMessage="Enter GoalName"
                                                                                    Text="*" ValidationGroup="controls3" ControlToValidate="txt_GoalName" meta:resourcekey="RV_GoalNameResource2"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: left">
                                                                                <asp:Label ID="lbl_GoalDescription" runat="server" Text="Goal Description" meta:resourcekey="lbl_GoalDescriptionResource2"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <b>:</b>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txt_GoalDescription" runat="server" TextMode="MultiLine" meta:resourcekey="txt_GoalDescriptionResource2"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: left">
                                                                                <asp:Label ID="lbl_Measure" runat="server" Text="Measure" meta:resourcekey="lbl_MeasureResource3"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <b>:</b>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txt_Measure" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="RV_Measure" runat="server" ErrorMessage="Enter Measure"
                                                                                    ControlToValidate="txt_Measure" Text="*" ValidationGroup="controls3" meta:resourcekey="RV_MeasureResource2"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: left">
                                                                                <asp:Label ID="lbl_GoalWeightage" runat="server" Text="Goal Weightage" meta:resourcekey="lbl_GoalWeightageResource2"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <b>:</b>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadNumericTextBox ID="RNT_Weightage" runat="server" MaxLength="2" meta:resourcekey="RNT_WeightageResource2"
                                                                                    EnableEmbeddedSkins="false" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="RV_Weightage" runat="server" ErrorMessage="Enter Weightage"
                                                                                    ControlToValidate="RNT_Weightage" Text="*" ValidationGroup="controls3" meta:resourcekey="RV_WeightageResource2"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="Lbl_Goal_Target" runat="server" Text="Target"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <b>:</b>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadNumericTextBox ID="RNT_GoalTarget" runat="server" EnableEmbeddedSkins="false"
                                                                                    Type="Percent" MinValue="0" MaxValue="100">
                                                                                </telerik:RadNumericTextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="rfv_GoalTarget" runat="server" ControlToValidate="RNT_GoalTarget"
                                                                                    ErrorMessage="Please Enter Target " SetFocusOnError="True" Text="*" ValidationGroup="controls3"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="style2">
                                                                                <asp:Label ID="lbl_Goal_TIMELINES" runat="server" Text="Timelines"></asp:Label>
                                                                            </td>
                                                                            <td>:
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadDatePicker ID="rdtp_Goal_TIMELINES" runat="server" EnableEmbeddedSkins="false">
                                                                                </telerik:RadDatePicker>
                                                                            </td>
                                                                            <td>&nbsp;
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="rfv_rdtp_goal_TIMELINES" runat="server" ControlToValidate="rdtp_Goal_TIMELINES"
                                                                                    ErrorMessage="Timelines Cannot Be Empty" ValidationGroup="controls3">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td align="center" colspan="3">
                                                                                <asp:Button ID="btn_Submit" runat="server" Text="Add" ValidationGroup="controls3"
                                                                                    OnClick="btn_Submit_Click" meta:resourcekey="btn_SubmitResource2" />&nbsp;<asp:Button
                                                                                        ID="btn_Cancel_GoalSettingsDetails" runat="server" Text="Cancel" OnClick="btn_Cancel_GoalSettingsDetails_Click"
                                                                                        meta:resourcekey="btn_Cancel_GoalSettingsDetailsResource2" />&nbsp;&nbsp;
                                                                                <asp:Button ID="btn_UpdateGoalSettingsDetails" Text="Update" runat="server" Visible="false"
                                                                                    OnClick="btn_UpdateGoalSettingsDetails_Click" meta:resourcekey="btn_UpdateGoalSettingsDetailsResource1" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:ValidationSummary ID="vs_goaldetails" runat="server" ShowMessageBox="True" ShowSummary="False"
                                                                                    ValidationGroup="controls3" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </telerik:RadPageView>
                                                                <telerik:RadPageView ID="RPV_GoalSetting_Details" runat="server" meta:resourcekey="RPV_GoalSetting_DetailsResource1">
                                                                    <table align="center">
                                                                        <tr>
                                                                            <td>
                                                                                <telerik:RadGrid ID="RG_GoalSettings_DetailsGrid" runat="server" AllowPaging="True"
                                                                                    EnableEmbeddedSkins="false" AutoGenerateColumns="False" PageSize="5" Skin="WebBlue"
                                                                                    GridLines="None" meta:resourcekey="RG_GoalSettings_DetailsResource1">
                                                                                    <MasterTableView>
                                                                                        <Columns>
                                                                                            <telerik:GridBoundColumn DataField="GSDTL_ID" HeaderText="GoalId" Visible="False"
                                                                                                meta:resourcekey="GridBoundColumnResource22" UniqueName="GSDTL_ID">
                                                                                            </telerik:GridBoundColumn>
                                                                                            <telerik:GridBoundColumn DataField="GSDTL_NAME" HeaderText="Goal Name" UniqueName="GSDTL_NAME"
                                                                                                meta:resourcekey="GridBoundColumnResource23">
                                                                                            </telerik:GridBoundColumn>
                                                                                            <telerik:GridBoundColumn DataField="GSDTL_DESC" HeaderText="Description" UniqueName="GSDTL_DESCRIPTION"
                                                                                                meta:resourcekey="GridBoundColumnResource24">
                                                                                            </telerik:GridBoundColumn>
                                                                                            <telerik:GridBoundColumn DataField="GSDTL_WEIGHTAGE" HeaderText="Weightage" UniqueName="GSDTL_WEIGHTAGE"
                                                                                                meta:resourcekey="GridBoundColumnResource25">
                                                                                            </telerik:GridBoundColumn>
                                                                                            <telerik:GridBoundColumn DataField="GSDTL_MEASURE" HeaderText="Measure" UniqueName="GSDTL_MEASURE"
                                                                                                meta:resourcekey="GridBoundColumnResource26">
                                                                                            </telerik:GridBoundColumn>

                                                                                            <telerik:GridBoundColumn HeaderText="Target" DataField="GS_Goal_TARGET">
                                                                                            </telerik:GridBoundColumn>
                                                                                            <telerik:GridBoundColumn HeaderText="Timelines" DataField="GS_Goal_TIMELINES">
                                                                                            </telerik:GridBoundColumn>

                                                                                            <telerik:GridTemplateColumn meta:resourcekey="GridTemplateColumnResource2" UniqueName="TemplateColumn">
                                                                                                <ItemTemplate>
                                                                                                    <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("GSDTL_ID") %>'
                                                                                                        OnCommand="lnk_Edit_CommandGS_Details" meta:resourcekey="lnk_EditResource4">Edit</asp:LinkButton>
                                                                                                </ItemTemplate>
                                                                                            </telerik:GridTemplateColumn>
                                                                                        </Columns>
                                                                                    </MasterTableView>
                                                                                </telerik:RadGrid>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center">
                                                                                <asp:Button ID="btn_GoalDetailSubmit" runat="server" Text=" Submit" OnClick="btn_GoalDtlSubmit_Click"
                                                                                    meta:resourcekey="btn_GoalDetailSubmitResource1" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </telerik:RadPageView>
                                                            </telerik:RadMultiPage>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </telerik:RadPanelItem>
                                        </Items>
                                    </telerik:RadPanelItem>
                                </Items>
                            </telerik:RadPanelBar>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>