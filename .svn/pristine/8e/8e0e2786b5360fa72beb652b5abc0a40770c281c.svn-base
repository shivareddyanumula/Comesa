<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_Pms_Task.aspx.cs" Inherits="PMS_frm_Pms_Task"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table align="center">
                <tr>
                    <td align="center">
                        <asp:Label ID="lbl_Task" runat="server" Text="Task"></asp:Label>
                    </td>
                </tr>
                <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                </telerik:RadScriptManager>
                <tr>
                    <td>
                        <telerik:RadMultiPage ID="Rm_TASK_PAGE" runat="server" SelectedIndex="0" ScrollBars="Auto"
                            meta:resourcekey="Rm_TASK_PAGEResource1">
                            <telerik:RadPageView ID="Rp_TASK_VIEWMAIN" runat="server" Selected="True" meta:resourcekey="Rp_TASK_VIEWMAINResource1">
                                <table align="center">
                                    <tr>
                                        <td>
                                            <telerik:RadGrid ID="Rg_Task" runat="server" AutoGenerateColumns="False" GridLines="None"
                                                EnableEmbeddedSkins="false" AllowPaging="True" AllowFilteringByColumn="True"
                                                Skin="WebBlue" PageSize="5" meta:resourcekey="Rg_TaskResource1" OnNeedDataSource="Rg_Task_NeedDataSource">
                                                <MasterTableView CommandItemDisplay="Top">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="TASK_ID" UniqueName="TASK_ID" HeaderText="TASKID"
                                                            meta:resourcekey="TASK_ID" Visible="False">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="TASK_NAME" UniqueName="TASK_NAME" HeaderText="Name"
                                                            meta:resourcekey="GridBoundColumnResource1">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="TASK_DESCRIPTION" UniqueName="TASK_DESCRIPTION"
                                                            HeaderText="Description">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn AllowFiltering="False" UniqueName="coledit" meta:resourcekey="GridTemplateColumnResource1">
                                                            <ItemTemplate>
                                                                <div align="right">
                                                                    <asp:LinkButton ID="lnk_edit" runat="server" Text="Edit" OnCommand="lnk_edit_command"
                                                                        CommandArgument='<%# Eval("TASK_ID") %>' meta:resourcekey="lnk_edit"></asp:LinkButton>
                                                                </div>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                    </Columns>
                                                    <CommandItemTemplate>
                                                        <div align="right">
                                                            <asp:LinkButton ID="lnk_add" runat="server" meta:resourcekey="lnk_add" Text="Add"
                                                                OnCommand="lnk_Add_Command"></asp:LinkButton>
                                                        </div>
                                                    </CommandItemTemplate>
                                                </MasterTableView>
                                                <PagerStyle AlwaysVisible="True" />
                                            </telerik:RadGrid>
                                        </td>
                                    </tr>
                                </table>
                            </telerik:RadPageView>
                            <telerik:RadPageView ID="Rp_TASK_VIEWDETAILS" runat="server" meta:resourcekey="Rp_TASK_VIEWDETAILSResource1">
                                <table align="center">
                                    <tr>
                                        <tr>
                                            <td align="center" colspan="3">
                                                <asp:Label ID="lbl_det" runat="server" Text="Details"></asp:Label>
                                            </td>
                                        </tr>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_Task_Id" runat="server" Visible="False" meta:resourcekey="lbl_Task_Id"></asp:Label>
                                            <asp:Label ID="lbl_BusinessUnitName" runat="server" Text="BusinessUnit Name" CssClass="LABELSS"
                                                meta:resourcekey="lbl_BusinessUnitNameResource1"></asp:Label>
                                        </td>
                                        <td></td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="rcmb_BusinessUnitType" runat="server" AutoPostBack="True" MarkFirstMatch="true"
                                                EnableEmbeddedSkins="false" Width="200px" meta:resourcekey="rcmb_BusinessUnitTypeResource1"
                                                OnSelectedIndexChanged="rcmb_BusinessUnitType_SelectedIndexChanged" Filter="Contains">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rcmb_BusinessUnitType" ControlToValidate="rcmb_BusinessUnitType"
                                                runat="server" ValidationGroup="Controls" ErrorMessage="Please Select BusinessUnit Name"
                                                InitialValue="Select" meta:resourcekey="rfv_rcmb_BusinessUnitTypeResource1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_Employee" runat="server" Text="Employee Name" meta:resourcekey="lbl_Employee"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="rcmb_EmployeeType" runat="server" Width="200px" EnableEmbeddedSkins="false"
                                                meta:resourcekey="rcmb_EmployeeTypeResource1" MarkFirstMatch="true" Filter="Contains">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rcmb_EmployeeType" ControlToValidate="rcmb_EmployeeType"
                                                runat="server" ValidationGroup="Controls" ErrorMessage="Please Select Employee Name"
                                                InitialValue="Select" meta:resourcekey="rfv_rcmb_EmployeeTypeResource1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_TaskName" runat="server" Text="Name" meta:resourcekey="lbl_TaskName"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="rtxt_TaskName" runat="server" EnableEmbeddedSkins="false" MaxLength="40" Ena meta:resourcekey="rtxt_TaskNameResource1">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rtxt_TaskName" ControlToValidate="rtxt_TaskName"
                                                runat="server" ValidationGroup="Controls" ErrorMessage="Name Cannot Be Empty"
                                                meta:resourcekey="rfv_rtxt_TaskName">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_TaskDescription" runat="server" Text="Description" meta:resourcekey="lbl_TaskDescription"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td rowspan="3">
                                            <telerik:RadTextBox ID="rtxt_TaskDescription" runat="server" TextMode="MultiLine" EnableEmbeddedSkins="false"
                                                meta:resourcekey="rtxt_TaskDescriptionResource1" Height="70px" Width="200px">
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_DATE" runat="server" Text="Date" meta:resourcekey="lbl_DATE" CssClass="LABELSS"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadDatePicker ID="rdtp_DATE" runat="server" EnableEmbeddedSkins="false"
                                                meta:resourcekey="rdtp_DATEResource1">
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rdtp_DATE" runat="server" ControlToValidate="rdtp_DATE"
                                                ErrorMessage="Date Cannot Be Empty" meta:resourcekey="rfv_rdtp_DATE" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_Goal" runat="server" meta:resourcekey="lbl_Goal"
                                                Text="Goal"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="rcmb_GoalType" runat="server" EnableEmbeddedSkins="false" Filter="Contains"
                                                meta:resourcekey="rcmb_GoalTypeResource1" Width="200px" MarkFirstMatch="true">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rcmb_GoalType" runat="server" ControlToValidate="rcmb_GoalType"
                                                ErrorMessage="Please Select Goal" InitialValue="Select" meta:resourcekey="rfv_rcmb_GoalType"
                                                ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>




                                    <tr>
                                        <td align="center" colspan="3">
                                            <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click"
                                                Text="Save" ValidationGroup="Controls" />
                                            <asp:Button ID="btn_cancel" runat="server" meta:resourcekey="btn_cancel" OnClick="btn_cancel_Click"
                                                Text="Cancel" />
                                            <asp:ValidationSummary ID="vs_GOAL" runat="server" meta:resourcekey="vs_GOALResource1"
                                                ShowMessageBox="True" ShowSummary="False" ValidationGroup="Controls" />
                                        </td>
                                    </tr>
                                </table>
                            </telerik:RadPageView>
                        </telerik:RadMultiPage>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>