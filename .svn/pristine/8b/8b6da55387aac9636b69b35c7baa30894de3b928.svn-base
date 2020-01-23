<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_GS.aspx.cs" Inherits="PMS_frm_GS" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">

        <script type="text/javascript">
            function ShowPop(ROLE_ID, BU_ID) {
                var win = window.radopen('../PMS/frm_ViewKRA.aspx?ROLE_ID=' + ROLE_ID + '&BU_ID=' + BU_ID, "RW_ViewKRA");
                win.center();
                //win.height = 30;
                win.set_modal(true);
            }
            //function ShowWin(EMP_ID, APPCYCLE_ID) {
            //    var win = window.radopen('../PMS/frm_CopyKRA.aspx?EMP_ID=' + EMP_ID + '&APPCYCLE_ID=' + APPCYCLE_ID, "RW_CopyKRA");
            //    win.center();
            //    //win.height = 30;
            //    win.set_modal(true);
            //}
        </script>

    </telerik:RadScriptBlock>
    <table align="center">
        <tr>
            <td align="center" runat="server" id="gs_dum_id" style="font-weight: bold">Goal Setting
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="RM_GS" runat="server" SelectedIndex="0">
                    <telerik:RadPageView ID="RP_GS_0" runat="server">
                        <table>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lbl_gs_dum_id" runat="server" Visible="false"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadGrid ID="Rg_Goal" runat="server" AutoGenerateColumns="false" Width="800"
                                        AllowPaging="true" AllowFilteringByColumn="true" AllowSorting="true" OnNeedDataSource="Rg_Goal_NeedDataSource"
                                        meta:resourcekey="Rg_Goal">
                                        <HeaderContextMenu Skin="WebBlue">
                                        </HeaderContextMenu>
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="GS_ID" HeaderText="ID" meta:resourcekey="ID"
                                                    UniqueName="ID" Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="GS_EMP_ID" HeaderText="EMPID" meta:resourcekey="GSID"
                                                    UniqueName="GS_EMP_ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMPLOYEE_NAME" HeaderText="Employee" meta:resourcekey="ID"
                                                    UniqueName="EMPLOYEE_NAME">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <%--<telerik:GridBoundColumn DataField="GS_PROJECT" HeaderText="Project" meta:resourcekey="DESC"
                                                    UniqueName="GS_PROJECT">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>--%>
                                                <telerik:GridBoundColumn DataField="GS_APPRAISAL_CYCLE" HeaderText="Appraisal&nbsp;Cycle"
                                                    UniqueName="GS_APPRAISAL_CYCLE">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <%--<telerik:GridBoundColumn DataField="STATUS" HeaderText="Status" UniqueName="STATUS">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>--%>
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Details_Edit" runat="server" CommandArgument='<%# Eval("GS_ID") %>'
                                                            OnCommand="lnk_Edit_Command">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" meta:resourcekey="lnk_Add" OnCommand="lnk_Add_Command">Add</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                            <PagerStyle AlwaysVisible="true" />
                                        </MasterTableView>
                                        <GroupingSettings CaseSensitive="false" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RP_GS_1" runat="server">
                        <table align="center">
                            <tr>
                                <td colspan="8" align="center"></td>
                            </tr>
                            <tr>
                                <td colspan="8"></td>
                            </tr>
                            <tr>
                                <%-- <td colspan="7">
                                    <label id="lbl_Header" runat="server" text=" Goal Settings">
                                    </label>
                                </td>--%><td>
                                    <asp:Label ID="Label3" runat="server" meta:resourcekey="lbl_idResource1" Visible="False"></asp:Label>
                                    <asp:Label ID="lbl_Gs_Status" runat="server" meta:resourcekey="lbl_Gs_Status" Visible="False"></asp:Label>
                                    <asp:Label ID="lbl_BusinessUnit" runat="server" meta:resourcekey="lbl_BusinessUnitResource1"
                                        Text="Business Unit"></asp:Label>
                                    <asp:HiddenField ID="hid" runat="server" />
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="RCB_BusinessUnit" runat="server" AutoPostBack="True" meta:resourcekey="RCB_BusinessUnitResource2"
                                        OnSelectedIndexChanged="RCB_BusinessUnit_SelectedIndexChanged" MarkFirstMatch="true"
                                        MaxHeight="120px" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RV_BusinessUnit" runat="server" ControlToValidate="RCB_BusinessUnit"
                                        ErrorMessage="Enter BusinessUnit Name" InitialValue="Select" meta:resourcekey="RV_BusinessUnitResource2"
                                        Text="*" ValidationGroup="controls1"></asp:RequiredFieldValidator>
                                </td>
                                <td></td>
                                <td></td>
                                <td style="width: 40%;">
                                    <asp:Label ID="lbl_RMID" runat="server" Text="Reporting Manager" Visible="false"></asp:Label>
                                    <asp:Label ID="lbl_GMID" runat="server" Text="General Manager" Visible="false"></asp:Label>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_ApprasialCycle" runat="server" meta:resourcekey="lbl_ApprasialCycleResource1"
                                        Style="font-family: Arial, Helvetica, sans-serif; font-size: small" Text="Appraisal Cycle"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="RCB_ApprasialCycle" runat="server" EmptyMessage="Select" Filter="Contains"
                                        AutoPostBack="true" OnSelectedIndexChanged="RCB_ApprasialCycle_SelectedIndexChanged"
                                        MaxHeight="120px" meta:resourcekey="RCB_ApprasialCycleResource2" MarkFirstMatch="true">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RV_ApprasialCycle" runat="server" ControlToValidate="RCB_ApprasialCycle"
                                        ErrorMessage="Please Select Appraisal Cycle" InitialValue="Select" meta:resourcekey="RV_ApprasialCycleResource2"
                                        SetFocusOnError="True" Text="*" ValidationGroup="controls1"></asp:RequiredFieldValidator>
                                </td>
                                <%--<td>
                                    <asp:Label ID="lbl_desg" runat="server" Text="Designation"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <asp:Label ID="lbl_desg_text" runat="server"></asp:Label>
                                </td>
                                <td></td>--%>
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
                                    <telerik:RadComboBox ID="RCB_EmployeeName" runat="server" meta:resourcekey="RCB_EmployeeNameResource2"
                                        AutoPostBack="True" OnSelectedIndexChanged="RCB_EmployeeName_SelectedIndexChanged"
                                        MarkFirstMatch="true" MaxHeight="120px" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_RCB_EmployeeName" runat="server" ControlToValidate="RCB_EmployeeName"
                                        ErrorMessage="Please Select Employee" Text="*" InitialValue="Select" ValidationGroup="controls1"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_ReportingManager" runat="server" Text="Reporting Manager" meta:resourcekey="lbl_ReportingManagerResource1" Width="150px"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <asp:Label ID="txt_ReportingManager" runat="server" meta:resourcekey="txt_ReportingManagerResource1"></asp:Label>
                                </td>
                                <td></td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Position" runat="server" Text="Position"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Position" runat="server" initialvalue="Select" AutoPostBack="true"
                                        Skin="WebBlue" Width="125px" MarkFirstMatch="true" MaxHeight="120px" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_Position" runat="server" ControlToValidate="rcmb_Position" InitialValue="Select"
                                        ErrorMessage="Please Select Position" Text="*"
                                        ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_GeneralManager" runat="server" Text="Group Manager"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td align="left">
                                    <asp:Label ID="txt_GeneralManager" runat="server" meta:resourcekey="txt_GeneralManagerResource1"></asp:Label>
                                </td>
                                <td></td>
                            </tr>


                            <tr>
                                <%-- <td>
                                    <asp:Label ID="lbl_RoleName" runat="server" meta:resourcekey="lbl_RoleNameResource1"
                                        Text="Role Name"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="RCB_RoleName" runat="server" meta:resourcekey="RCB_RoleNameResource2"
                                        MarkFirstMatch="true" MaxHeight="120px" OnSelectedIndexChanged="RCB_RoleName_SelectedIndexChanged"
                                        AutoPostBack="true">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RV_RoleName" runat="server" ControlToValidate="RCB_RoleName"
                                        ErrorMessage=" Please Select RoleName" InitialValue="Select" meta:resourcekey="RV_RoleNameResource2"
                                        Text="*" ValidationGroup="controls1"></asp:RequiredFieldValidator>
                                </td>--%>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td>
                                    <asp:LinkButton ID="lnk_ViewKRA" runat="server" Text="View KRA's" OnCommand="lnk_ViewKRA_command"
                                        Visible="false"></asp:LinkButton>
                                </td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <%--<tr>
                                <td>
                                    <asp:Label ID="lbl_Project" runat="server" meta:resourcekey="lbl_ProjectResource1"
                                        Text="Project"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>                                   
                                    <telerik:RadListBox ID="rlst_pjt" runat="server" CheckBoxes="true" Height="120px"
                                        Width="200px">
                                    </telerik:RadListBox>
                                    <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
                                </td>
                                <td></td>
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
                                <td></td>
                            </tr>--%>
                            <tr>
                                <td align="center" colspan="8">
                                    <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_SaveResource1" OnClick="btn_Save_Click" Text="Save" ValidationGroup="controls1" />
                                    <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_UpdateResource1" OnClick="btn_Save_Click" Text="Update" ValidationGroup="controls1" />
                                    <asp:ValidationSummary ID="vs_goal" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="controls1" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="7" align="center">
                                    <asp:Button ID="btn_assignKRA" runat="server" meta:resourcekey="btn_assignKRA" Text="Assign KRA's"
                                        ValidationGroup="controls1" OnClick="btn_assignKRA_Click1" Visible="false" />
                                    <asp:Button ID="btn_assignGoal" runat="server" meta:resourcekey="btn_assignGoal"
                                        Text="Assign Competencies" ValidationGroup="controls1" OnClick="btn_assignGoal_Click" Visible="false" />
                                    <asp:Button ID="btn_assignIDP" runat="server" meta:resourcekey="btn_assignIDP" OnClick="btn_assignIDP_Click" Text="Assign Values" ValidationGroup="controls1" Visible="false" />
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnk_CopyKRA" runat="server" OnCommand="lnk_CopyKRA_command" Text="Copy Previous KRA's" Visible="false"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="8">
                                    <asp:HiddenField ID="hd_Field" runat="server" Visible="false" />
                                    <telerik:RadGrid ID="Rg_KRAGOAL" runat="server" AutoGenerateColumns="false" ClientSettings-Scrolling-AllowScroll="true" ClientSettings-Scrolling-UseStaticHeaders="true" GridLines="None" OnCustomAggregate="Rg_KRAGOAL_CustomAggregate" OnItemCommand="Rg_KRAGOAL_ItemCommand" OnItemDataBound="Rg_KRAGOAL_ItemDataBound" OnNeedDataSource="Rg_KRAGOAL_NeedDataSource" Width="700px">
                                        <%--ShowFooter="true" FooterStyle-HorizontalAlign="Justify" FooterStyle-BorderWidth="0px"--%>
                                        <MasterTableView>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="SNO" HeaderText="S. No" meta:resourcekey="SNO" UniqueName="SNO" Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="GSID" HeaderText="ID" meta:resourcekey="GSID" UniqueName="GSID" Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="ROLEKRA_ID" HeaderText="ID" meta:resourcekey="ID" UniqueName="ROLEKRA_ID" Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn HeaderText="Name" UniqueName="Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_NAME" runat="server" Text='<%# Eval("NAME") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <%--   <telerik:GridBoundColumn DataField="DESC" HeaderStyle-HorizontalAlign="Center" HeaderText="Description"
                                                            meta:resourcekey="DESC" UniqueName="DESC" Visible="false">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>--%><telerik:GridTemplateColumn HeaderText="Description">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_Desc" runat="server" Text='<%# Eval("DESC") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridTemplateColumn>
                                                <%-- <telerik:GridBoundColumn DataField="Measure" HeaderStyle-HorizontalAlign="Center"
                                                            HeaderText="Measure" meta:resourcekey="Measure" UniqueName="MEasure">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>--%>
                                                <%-- <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Measure" UniqueName="MEasure" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_MEasure" runat="server" Text='<%# Eval("Measure") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <%-- <FooterTemplate>
                                                             <asp:Label ID="lbl_footer" runat="server" Text="Total Weightage for this employee is:" Font-Bold="true"></asp:Label>
                                                            </FooterTemplate>
                                                </telerik:GridTemplateColumn>--%>
                                                <%--<telerik:GridTemplateColumn HeaderStyle-Width="70px" HeaderText="Weightage" UniqueName="Template1">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_Weightage" runat="server" Enabled="false" SkinID="one" Text='<%# Eval("WEIGHTAGE") %>' Width="50px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />--%>
                                                <%-- <FooterTemplate>--%>
                                                <%-- <table width="100%" border="0" cellpadding="0" cellspacing="0" >
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lbl_footer" runat="server" Text="Total Weightage for this employee is:"></asp:Label>&nbsp;
                                                                        </td>
                                                                        <td>--%>
                                                <%-- <telerik:RadNumericTextBox ID="TextBox2" runat="server" Enabled="false" Type="Number">
                                                                                <ClientEvents OnLoad="Load" />
                                                                            </telerik:RadNumericTextBox>--%>
                                                <%-- </td>
                                                                    </tr>
                                                                </table>--%>
                                                <%--</FooterTemplate>--%>
                                                <%--</telerik:GridTemplateColumn>--%>
                                                <telerik:GridBoundColumn DataField="A" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" HeaderText="Type" meta:resourcekey="A" UniqueName="A">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Target" HeaderText="Target" meta:resourcekey="A" UniqueName="Target" Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Timelines" HeaderText="Timelines" meta:resourcekey="A" UniqueName="Timelines" Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridButtonColumn CommandName="Edit_Rec" HeaderStyle-Width="50px" Text="View" UniqueName="column">
                                                </telerik:GridButtonColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Details_Edit" runat="server" CommandArgument='<%# Eval("ROLEKRA_ID") %>' OnCommand="lnk_Details_Edit_Command">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderStyle-Width="55px" UniqueName="ColDel">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Delete" runat="server" CommandArgument='<%# Eval("ROLEKRA_ID") %>' CommandName="Del" OnClientClick="return confirm('Are you sure you want to delete?')" OnCommand="lnk_DeleteCommand" Text="Delete"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="KRA_ID" UniqueName="KRA_ID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_KRA_ID" runat="server" Text='<%# Eval("KRA_ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>

                                            </Columns>
                                            <%-- <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" CommandName="ADDKRA" ForeColor="Black">Add KRA</asp:LinkButton>
                                                </div>
                                                <%--    </CommandItemTemplate>
                                            <CommandItemTemplate>--%>
                                            <%--<div align="right">
                                                    <asp:LinkButton ID="lnk_Add_Goal" runat="server" CommandName="ADDGOAL" ForeColor="White">Add Goal</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>--%>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="8" align="center">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btn_Save_Details" runat="server" OnClick="btn_Save_Details_Click" OnClientClick="disableButton(this,'')" Text="Submit" UseSubmitBehavior="false" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btn_Update_Details" runat="server" OnClick="btn_Update_Details_Click" OnClientClick="disableButton(this,'')" Text="Update" UseSubmitBehavior="false" Visible="false" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btn_cancel" runat="server" OnClick="btn_cancel_Click" Text="Close" Visible="True" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RP_GS_2" runat="server">
                        <table align="center">
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Label ID="lbl_KRAHeading" runat="server" Text="Key Result Area"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_GS_ID" runat="server" Visible="False" meta:resourcekey="lbl_kraResource1"></asp:Label>
                                    <asp:Label ID="lbl_kra" runat="server" Text="[lbl_kra]" Visible="False" meta:resourcekey="lbl_kraResource1"></asp:Label><asp:Label
                                        ID="lbl_Kras" runat="server" Text="Name" meta:resourcekey="lbl_KrasResource1"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="RCB_KRA" AutoPostBack="True" runat="server" Height="100px" Filter="Contains"
                                        OnSelectedIndexChanged="RCB_KRA_SelectedIndexChanged" MarkFirstMatch="true" MaxHeight="120px">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RV_kras" runat="server" ControlToValidate="RCB_KRA"
                                        ErrorMessage="Please Select KRA" InitialValue="Select" ValidationGroup="controls2">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="lbl_KraObjective" runat="server" Text="KRA Objective"></asp:Label>
                                </td>
                                <td><b>:</b></td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_KraObjective" runat="server" Filter="Contains"></telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_KraObjective" runat="server" ControlToValidate="rcmb_KraObjective" ErrorMessage="Please Select KRA Objective"
                                        InitialValue="Select" ValidationGroup="controls2">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="lbl_KraDescription" runat="server" Text="Description" meta:resourcekey="lbl_KraDescriptionResource1"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_KraDescription" runat="server" TextMode="MultiLine" meta:resourcekey="txt_KraDescriptionResource1"
                                        Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <%--<tr>
                                <td>
                                    <asp:Label ID="lbl_Measure" runat="server" meta:resourcekey="lbl_MeasureResource2"
                                        Text="Measure"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_KraMeasure" runat="server" TextMode="MultiLine" MaxLength="1000"
                                        Width="200px"></asp:TextBox>
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
                                    <telerik:RadNumericTextBox ID="RNT_KraWeightage" runat="server" MaxLength="2">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_kraweightage" runat="server" ControlToValidate="RNT_KraWeightage"
                                        ErrorMessage="Please Enter Weightage " SetFocusOnError="True" Text="*" ValidationGroup="controls2"></asp:RequiredFieldValidator>
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
                                    <telerik:RadTextBox ID="RNT_KraTarget" runat="server" MaxLength="100">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_kraTarget" runat="server" ControlToValidate="RNT_KraTarget"
                                                ErrorMessage="Please Enter Target " SetFocusOnError="True" Text="*" ValidationGroup="controls2"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                        <td>
                                            <asp:Label ID="lbl_TIMELINES" runat="server" Text="Date"></asp:Label>
                                        </td>
                                        <td>
                                           <b>:</b> 
                                        </td>
                                        <td>
                                            <telerik:RadDatePicker ID="rdtp_TIMELINES" runat="server" MaxDate="">
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rdtp_TIMELINES" runat="server" ControlToValidate="rdtp_TIMELINES"
                                                ErrorMessage="Timelines Cannot Be Empty" ValidationGroup="controls2">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>--%>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Button ID="btn_SaveAssignkra" runat="server" Text="Add" meta:resourcekey="btn_SaveAssignkraResource1"
                                        OnClick="btn_SaveAssignkra_Click" OnClientClick="disableButton(this,'controls2')"
                                        UseSubmitBehavior="false" />
                                    <%-- <asp:Button ID="btn_UpdateAssignkra" Text="Update" runat="server" ValidationGroup="controls2"
                                        Visible="false" meta:resourcekey="btn_UpdateAssignkraResource1" OnClick="btn_UpdateAssignkra_Click" />--%>
                                    <asp:Button ID="btn_CancelKRA" runat="server" meta:resourcekey="btn_UpdateAssignkraResource1"
                                        OnClick="btn_CancelKRA_Click" Text="Cancel" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ValidationSummary ID="vs_kra" runat="server" ShowMessageBox="True" ShowSummary="False"
                                        ValidationGroup="controls2" />
                                </td>
                            </tr>
                        </table>
                        <%--<table align="Center">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblWtDecs_Kra" runat="server" Text="Weightage Description" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="rg_Wt_Desc_KRA" AllowPaging="false" runat="server" AutoGenerateColumns="False"
                                        AllowSorting="true" GridLines="None" Skin="WebBlue">
                                        <MasterTableView>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="WEIGHTAGE_DESC_ID" UniqueName="WEIGHTAGE_DESC_ID"
                                                    HeaderText="ID" meta:resourcekey="WEIGHTAGE_DESC_ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="WEIGHTAGE_DESC_SCALE" UniqueName="WEIGHTAGE_DESC_SCALE"
                                                    HeaderText="Scale" meta:resourcekey="WEIGHTAGE_DESC_SCALE">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="WEIGHTAGE_DESC_INTERPRETATION" UniqueName="WEIGHTAGE_DESC_INTERPRETATION"
                                                    HeaderText="Interpretation" meta:resourcekey="WEIGHTAGE_DESC_INTERPRETATION">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="WEIGHTAGE_DESC_DESC" UniqueName="WEIGHTAGE_DESC_DESC"
                                                    HeaderText="Description" meta:resourcekey="WEIGHTAGE_DESC_DESC">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                            </Columns>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>--%>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RP_GS_3" runat="server">
                        <table align="center">
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Label ID="lbl_GSD" runat="server" Text="Competency Details"></asp:Label>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="lbl_CMP" runat="server" Text="Competencies"></asp:Label>
                                    <asp:Label ID="lbl_GSID" runat="server" Text="[lbl_gsid]" Visible="False" meta:resourcekey="lbl_kraResource1"></asp:Label>
                                    <asp:Label ID="lbl_GSDetails" runat="server" Visible="False" meta:resourcekey="lbl_GSDetailsResource2"></asp:Label>
                                </td>
                                <td><b>:</b></td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_CMP" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rcmb_CMP_SelectedIndexChanged" Filter="Contains"></telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_CMP" runat="server" ErrorMessage="Please Select Competency" InitialValue="Select"
                                        ValidationGroup="controls3" ControlToValidate="rcmb_CMP">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <%--<tr>
                                <td style="text-align: left">
                                    <asp:Label ID="lbl_GoalName" runat="server" Text="Name" meta:resourcekey="lbl_GoalNameResource2"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_GoalName" runat="server" MaxLength="1000" Width="200px" TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <td>
                                    
                                </td>
                            </tr>--%>
                            <tr>
                                <td style="text-align: left">
                                    <asp:Label ID="lbl_GoalDescription" runat="server" Text="Description" meta:resourcekey="lbl_GoalDescriptionResource2"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_GoalDescription" runat="server" TextMode="MultiLine" MaxLength="1000" Enabled="false"
                                        Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <%--<tr>
                                <td style="text-align: left">
                                    <asp:Label ID="Label2" runat="server" Text="Measure" meta:resourcekey="lbl_MeasureResource3"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_Measure" runat="server" TextMode="MultiLine" MaxLength="1000"
                                        Width="200px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RV_Measure" runat="server" ErrorMessage="Enter Measure"
                                                ControlToValidate="txt_Measure" Text="*" ValidationGroup="controls3" meta:resourcekey="RV_MeasureResource2"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left">
                                    <asp:Label ID="lbl_GoalWeightage" runat="server" Text="Weightage" meta:resourcekey="lbl_GoalWeightageResource2"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="RNT_Weightage" runat="server" MaxLength="2" />
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
                                    <telerik:RadTextBox ID="RNT_GoalTarget" runat="server" MaxLength="100">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_GoalTarget" runat="server" ControlToValidate="RNT_GoalTarget"
                                                ErrorMessage="Please Enter Target " SetFocusOnError="True" Text="*" ValidationGroup="controls3"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                        <td>
                                            <asp:Label ID="lbl_Goal_TIMELINES" runat="server" Text="Date"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadDatePicker ID="rdtp_Goal_TIMELINES" runat="server">
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rdtp_goal_TIMELINES" runat="server" ControlToValidate="rdtp_Goal_TIMELINES"
                                                ErrorMessage="Timelines Cannot Be Empty" ValidationGroup="controls3">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>--%>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Button ID="btn_Submit" runat="server" Text="Add" OnClick="btn_Submit_Click"
                                        OnClientClick="disableButton(this,'controls3')" UseSubmitBehavior="false" />
                                    <%--<asp:Button ID="btn_UpdateGoalSettingsDetails" runat="server" meta:resourcekey="btn_UpdateGoalSettingsDetailsResource1"
                                        OnClick="btn_UpdateGoalSettingsDetails_Click" Text="Update" ValidationGroup="controls3"
                                        Visible="false" />--%>
                                    <asp:Button ID="btn_Cancel_GoalSettingsDetails" runat="server" Text="Cancel" OnClick="btn_Cancel_GoalSettingsDetails_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ValidationSummary ID="vs_goaldetails" runat="server" ShowMessageBox="True" ShowSummary="False"
                                        ValidationGroup="controls3" />
                                </td>
                            </tr>
                        </table>
                        <%--<table align="Center">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lbl_wtdesc_Goal" runat="server" Text="Weightage Description" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="rg_Wt_Desc_Goal" AllowPaging="false" runat="server" AutoGenerateColumns="False"
                                        AllowSorting="true" GridLines="None" Skin="WebBlue">
                                        <MasterTableView>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="WEIGHTAGE_DESC_ID" UniqueName="WEIGHTAGE_DESC_ID"
                                                    HeaderText="ID" meta:resourcekey="WEIGHTAGE_DESC_ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="WEIGHTAGE_DESC_SCALE" UniqueName="WEIGHTAGE_DESC_SCALE"
                                                    HeaderText="Scale" meta:resourcekey="WEIGHTAGE_DESC_SCALE">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="WEIGHTAGE_DESC_INTERPRETATION" UniqueName="WEIGHTAGE_DESC_INTERPRETATION"
                                                    HeaderText="Interpretation" meta:resourcekey="WEIGHTAGE_DESC_INTERPRETATION">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="WEIGHTAGE_DESC_DESC" UniqueName="WEIGHTAGE_DESC_DESC"
                                                    HeaderText="Description" meta:resourcekey="WEIGHTAGE_DESC_DESC">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                            </Columns>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>--%>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RP_GS_4" runat="server">
                        <table align="center">
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Label ID="lbl_idpheader" runat="server" Text="Value&nbsp;Details"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left">
                                    <asp:Label ID="lbl_idpname" runat="server" Text="Name"></asp:Label>
                                    <asp:Label ID="lbl_idp" runat="server" Text="[lbl_idp]" Visible="False"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_idp" runat="server" MarkFirstMatch="true" MaxHeight="120px"
                                        AutoPostBack="true" OnSelectedIndexChanged="rcmb_idp_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_idp" runat="server" ErrorMessage="Please Select  value"
                                        InitialValue="Select" Text="*" ValidationGroup="controls4" ControlToValidate="rcmb_idp"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left">
                                    <asp:Label ID="lbl_IDPdesc" runat="server" Text="Description"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_idpdesc" runat="server" TextMode="MultiLine" MaxLength="1000"
                                        Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <%--  <tr>
                                <td style="text-align: left">
                                    <asp:Label ID="lbl_idpmeasure" runat="server" Text="Measure"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_idpmeasure" runat="server" TextMode="MultiLine" MaxLength="1000"
                                        Width="200px"></asp:TextBox>
                                </td>
                                <td>
                                     <asp:RequiredFieldValidator ID="rfv_txt_idpmeasure" runat="server" ErrorMessage="Enter Measure"
                                                ControlToValidate="txt_idpmeasure" Text="*" ValidationGroup="controls4" ></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left">
                                    <asp:Label ID="lbl_idpwt" runat="server" Text="Weightage"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="rnt_idp_wt" runat="server" MaxLength="2" />
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rnt_idp_wt" runat="server" ErrorMessage="Enter Weightage"
                                        ControlToValidate="rnt_idp_wt" Text="*" ValidationGroup="controls4"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_idptarget" runat="server" Text="Target"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_idptarget" runat="server" TextMode="MultiLine" MaxLength="100">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                     <asp:RequiredFieldValidator ID="rfv_rtxt_idptarget" runat="server" ControlToValidate="rtxt_idptarget"
                                                ErrorMessage="Please Enter Target " SetFocusOnError="True" Text="*" ValidationGroup="controls4"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                        <td>
                                            <asp:Label ID="lbl_idpdate" runat="server" Text="Date"></asp:Label>
                                        </td>
                                        <td>
                                           <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadDatePicker ID="rdtp_idpdate" runat="server">
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rdtp_idpdate" runat="server" ControlToValidate="rdtp_idpdate"
                                                ErrorMessage="Date Cannot Be Empty" ValidationGroup="controls4">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>--%>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Button ID="btn_IDP_Save" runat="server" Text="Add" OnClick="btn_IDP_Save_Click"
                                        OnClientClick="disableButton(this,'controls4')" UseSubmitBehavior="false" />
                                    <%--<asp:Button ID="btn_IDP_Update" runat="server" Text="Update" ValidationGroup="controls4"
                                        OnClick="btn_IDP_Update_Click" Visible="false" />--%>
                                    <asp:Button ID="btn_Cancel_IDP" runat="server" Text="Cancel" OnClick="btn_Cancel_IDP_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ValidationSummary ID="vs_idp" runat="server" ShowMessageBox="True" ShowSummary="False"
                                        ValidationGroup="controls4" />
                                </td>
                            </tr>
                        </table>
                        <%--<table align="Center">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblWtDescIDP" runat="server" Text="Weightage Description" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="rg_Wt_Desc_IDP" AllowPaging="false" runat="server" AutoGenerateColumns="False"
                                        AllowSorting="true" GridLines="None" Skin="WebBlue">
                                        <MasterTableView>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="WEIGHTAGE_DESC_ID" UniqueName="WEIGHTAGE_DESC_ID"
                                                    HeaderText="ID" meta:resourcekey="WEIGHTAGE_DESC_ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="WEIGHTAGE_DESC_SCALE" UniqueName="WEIGHTAGE_DESC_SCALE"
                                                    HeaderText="Scale" meta:resourcekey="WEIGHTAGE_DESC_SCALE">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="WEIGHTAGE_DESC_INTERPRETATION" UniqueName="WEIGHTAGE_DESC_INTERPRETATION"
                                                    HeaderText="Interpretation" meta:resourcekey="WEIGHTAGE_DESC_INTERPRETATION">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="WEIGHTAGE_DESC_DESC" UniqueName="WEIGHTAGE_DESC_DESC"
                                                    HeaderText="Description" meta:resourcekey="WEIGHTAGE_DESC_DESC">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                            </Columns>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>--%>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RP_GS_5" runat="server">
                        <table align="center">
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Label ID="lbl_copyheader" runat="server" Text="Copy Previous KRA's"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_CopyAppCycle" runat="server" Text="From Appraisal Cycle"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_CopyAppCycle" runat="server" MarkFirstMatch="true" Filter="Contains"
                                        MaxHeight="120px" AutoPostBack="true" OnSelectedIndexChanged="rcmb_CopyAppCycle_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                        </table>
                        <table align="center">
                            <tr>
                                <td align="center">
                                    <telerik:RadGrid ID="Rg_CopyKRA" runat="server" AutoGenerateColumns="false" Width="500"
                                        GridLines="None" AllowPaging="true" AllowFilteringByColumn="true" AllowSorting="true"
                                        OnNeedDataSource="Rg_CopyKRA_NeedDataSource" PageSize="10" PagerStyle-AlwaysVisible="true">
                                        <HeaderContextMenu Skin="WebBlue">
                                        </HeaderContextMenu>
                                        <MasterTableView>
                                            <Columns>
                                                <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Select" HeaderStyle-Width="80px">
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="chk_selectall" runat="server" AutoPostBack="true" OnCheckedChanged="chk_selectall_checkedchanged"
                                                            Text="Check All" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chckbtn_Select" runat="server" />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn DataField="GSID" HeaderText="ID" UniqueName="GSID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="ROLEKRA_ID" HeaderText="ID" UniqueName="ROLEKRA_ID"
                                                    Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="NAME" HeaderText="Name" UniqueName="NAME">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="DESC" HeaderText="Description" UniqueName="DESC">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <%-- <telerik:GridBoundColumn DataField="Measure" HeaderText="Measure" UniqueName="Measure">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="WEIGHTAGE" HeaderText="Weightage" UniqueName="WEIGHTAGE">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>--%>
                                                <telerik:GridBoundColumn DataField="A" HeaderStyle-HorizontalAlign="Center" HeaderText="Type"
                                                    UniqueName="A" HeaderStyle-Width="60px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn HeaderText="KRA_ID" UniqueName="KRA_ID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_KRA_ID1" runat="server" Text='<%# Eval("KRA_ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <%--  <telerik:GridBoundColumn DataField="Target" HeaderText="Target" UniqueName="Target"
                                                    Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Timelines" HeaderText="Timelines" UniqueName="Timelines"
                                                    Visible="false">
                                                </telerik:GridBoundColumn>--%>
                                            </Columns>
                                        </MasterTableView>
                                        <GroupingSettings CaseSensitive="false" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                        <table align="center">
                            <tr>
                                <td>
                                    <asp:Button ID="btn_Copy" runat="server" Text="Copy" OnClick="btn_Copy_Click" Visible="false" />
                                    <asp:Button ID="btn_CopyCancel" runat="server" Text="Cancel" OnClick="btn_CopyCancel_Click" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>