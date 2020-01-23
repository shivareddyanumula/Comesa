<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_PmsTask.aspx.cs" Inherits="PMS_frm_Task" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .style2 {
            width: 119px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td align="center">


                <telerik:RadMultiPage ID="Rm_TASK_PAGE" runat="server" SelectedIndex="0"
                    meta:resourcekey="Rm_TASK_PAGEResource1" ScrollBars="Auto" EnableAjaxSkinRendering="False">
                    <telerik:RadPageView ID="Rp_TASK_VIEWMAIN" runat="server" Selected="True" meta:resourcekey="Rp_TASK_VIEWMAINResource1">
                        <table align="center">
                            <tr>
                                <td align="center">
                                    <center>
                                        Task
                                    </center>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <telerik:RadGrid ID="Rg_Task" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        AllowPaging="True" AllowFilteringByColumn="True"
                                        Skin="WebBlue" PageSize="5" meta:resourcekey="Rg_TaskResource1" OnNeedDataSource="Rg_Task_NeedDataSource" Width="800px">
                                        <MasterTableView CommandItemDisplay="Top" TableLayout="Fixed">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="TASK_ID" UniqueName="TASK_ID" HeaderText="TASKID"
                                                    meta:resourcekey="TASK_ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMPLOYEE_NAME" UniqueName="EMPLOYEE_NAME" HeaderText="Employee Name">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="TASK_NAME" UniqueName="TASK_NAME" HeaderText="Task Name">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="TASK_DESCRIPTION" UniqueName="TASK_DESCRIPTION"
                                                    HeaderText="Description">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="TASK_DATE" UniqueName="TASK_DATE" HeaderText="Date">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="TASK_GOAL" UniqueName="TASK_GOAL" HeaderText="Goal"
                                                    meta:resourcekey="TASK_GOAL_ID">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>

                                                <telerik:GridBoundColumn DataField="APPRCYCLE_NAME" UniqueName="APPRCYCLE_NAME" HeaderText="Appraisal Cycle">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="False" UniqueName="coledit" meta:resourcekey="GridTemplateColumnResource1">
                                                    <ItemTemplate>
                                                        <div align="right">
                                                            <asp:LinkButton ID="lnk_edit" runat="server" Text="Edit" OnCommand="lnk_edit_command"
                                                                CommandArgument='<%# Eval("TASK_ID") %>'></asp:LinkButton>
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
                    <telerik:RadPageView ID="Rp_TASK_VIEWDETAILS" runat="server" meta:resourcekey="Rp_TASK_VIEWDETAILSResource1">
                        <table align="center">
                            <tr>
                                <td colspan="4" align="center">
                                    <center>
                                        Task Details
                                    </center>
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    <asp:Label ID="lbl_BusinessUnitName" runat="server" meta:resourcekey="lbl_BusinessUnitNameResource1"
                                        Text="BusinessUnit Name"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="rcmb_BusinessUnitType" runat="server" AutoPostBack="True" MarkFirstMatch="true"
                                        meta:resourcekey="rcmb_BusinessUnitTypeResource1" OnSelectedIndexChanged="rcmb_BusinessUnitType_SelectedIndexChanged"
                                        Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>

                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_BusinessUnitType" runat="server" ControlToValidate="rcmb_BusinessUnitType"
                                        ErrorMessage="Please Select BusinessUnit Name" InitialValue="Select" meta:resourcekey="rfv_rcmb_BusinessUnitTypeResource1"
                                        ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_Task_Id" runat="server" meta:resourcekey="lbl_Task_Id" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    <asp:Label ID="lbl_Employee" runat="server" Text="Employee Name"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_EmployeeType" runat="server" meta:resourcekey="rcmb_EmployeeTypeResource1" MarkFirstMatch="true" Filter="Contains"
                                        AutoPostBack="true" Style="margin-left: 0px" Width="200px" OnSelectedIndexChanged="rcmb_EmployeeType_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td align="left">&nbsp;
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_EmployeeType" runat="server" ControlToValidate="rcmb_EmployeeType"
                                        ErrorMessage="Please Select Employee Name" InitialValue="Select" meta:resourcekey="rfv_rcmb_EmployeeTypeResource1"
                                        ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    <asp:Label ID="lbl_TaskName" runat="server" Text="Task Name"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_TaskName" runat="server"
                                        LabelCssClass="" MaxLength="40" meta:resourcekey="rtxt_TaskNameResource1">
                                    </telerik:RadTextBox>
                                </td>
                                <td>&nbsp;
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_TaskName" runat="server" ControlToValidate="rtxt_TaskName"
                                        ErrorMessage="Task Name Cannot Be Empty" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    <asp:Label ID="lbl_TaskDescription" runat="server" Text="Description"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_TaskDescription" runat="server"
                                        Height="70px" meta:resourcekey="rtxt_TaskDescriptionResource1" TextMode="MultiLine"
                                        Width="200px">
                                    </telerik:RadTextBox>
                                </td>
                                <td rowspan="3">&nbsp;
                                </td>
                            </tr>
                            <%-- <tr>
                                <td class="style2">
                                    &nbsp;
                                </td>
                                <td>
                                    :</td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    &nbsp;
                                </td>
                                <td>
                                    :</td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>--%>
                            <tr>
                                <td class="style2">
                                    <asp:Label ID="lbl_DATE" runat="server" Text="Date" meta:resourcekey="lbl_DATE"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="rdtp_DATE" runat="server"
                                        meta:resourcekey="rdtp_DATEResource1">
                                    </telerik:RadDatePicker>
                                </td>
                                <td>&nbsp;
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rdtp_DATE" runat="server" ControlToValidate="rdtp_DATE"
                                        ErrorMessage="Date Cannot Be Empty" meta:resourcekey="rfv_rdtp_DATE" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    <asp:Label ID="lbl_Goal" runat="server" CssClass="LABELSS" meta:resourcekey="lbl_Goal"
                                        Text="Goal"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_GoalType" runat="server" MarkFirstMatch="true"
                                        meta:resourcekey="rcmb_GoalTypeResource1" Width="200px" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td align="left">&nbsp;
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_GoalType" runat="server" ControlToValidate="rcmb_GoalType"
                                        ErrorMessage="Please Select Goal" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    <asp:Label ID="lbl_appr_cycle" runat="server" CssClass="LABELSS" Text="Appraisal Cycle"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcm_apprcycle" runat="server" MarkFirstMatch="true"
                                        Width="200px" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td align="left">&nbsp;
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcm_apprcycle_id" runat="server" ControlToValidate="rcm_apprcycle"
                                        ErrorMessage="Please Select Appraisalcycle" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Button ID="btn_Save" runat="server" CssClass="LABELSS" meta:resourcekey="btn_Save"
                                        OnClick="btn_Save_Click" Text="Submit" ValidationGroup="Controls" />
                                    <asp:Button ID="btn_cancel" runat="server" CssClass="LABELSS" meta:resourcekey="btn_cancel"
                                        OnClick="btn_cancel_Click" Text="Cancel" />
                                    <asp:ValidationSummary ID="vs_GOAL" runat="server" CssClass="LABELSS" meta:resourcekey="vs_GOALResource1"
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