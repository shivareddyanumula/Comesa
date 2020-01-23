<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_PmsFeedback.aspx.cs" Inherits="PMS_frm_PmsFeedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">

        <script type="text/javascript">
            function openRadWin(str) {
                radopen(str, "RW_TaskFeedback");
            }



        </script>
        <script type="text/javascript">
            //function FeedBack_Details() {
            //    var win = window.radopen('../PMS/frm_Pms_ViewFeedBack.aspx', "RW_FeedBackDetails");
            //    win.center();
            //    //win.height = 30;
            //    win.set_modal(true);
            //}
            function FeedBack_Details(str) {
                //var win = window.radopen('../PMS/frm_Pms_ViewFeedBack.aspx', "RW_FeedBackDetails");
                var win = window.radopen(str, "RW_TaskFeedback");
                win.setSize(580, 370);
                win.center();
                //win.height = 30;
                win.set_modal(true);
            }
        </script>

    </telerik:RadScriptBlock>
    <telerik:RadWindowManager ID="RWM_TASKFEEDBACK" runat="server" Skin="WebBlue" Animation="Slide"
        AnimationDuration="300" Behaviors="Close" AutoSize="true"
        Height="400px" Width="400px">
        <Windows>
            <telerik:RadWindow ID="RW_TaskFeedback" Skin="WebBlue" Modal="true" runat="server"
                Width="400px" Height="400px" Title="TASK FEEDBACK" AutoSize="true" VisibleStatusbar="false"
                ReloadOnShow="true" Behaviors="Close" KeepInScreenBounds="true" ShowContentDuringLoad="true">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <table align="center">
        <tr>
            <%--  <telerik:RadMultiPage ID="Rm_Feedback_PAGE" runat="server" SelectedIndex="0" ScrollBars="Auto"
                    meta:resourcekey="Rm_Feedback_PAGEResource1">
                    <telerik:RadPageView ID="Rp_Feedback_VIEWDETAILS" runat="server" Selected="True"
                        meta:resourcekey="Rp_Feedback_VIEWDETAILSResource1">
                        <center>
                            <b>Periodic Feedback</b></center>--%>
            <td colspan="3" align="right">
                <asp:Label ID="lbl_Heading" runat="server" Text="My Periodic Feedback" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_appraisal_Id" runat="server" meta:resourcekey="lbl_Feedback_IdResource1"
                    Visible="False"></asp:Label>
                <asp:Label ID="lbl_BusinessUnitName" runat="server" meta:resourcekey="lbl_BusinessUnitNameResource1"
                    Text="BusinessUnit" Visible="false"></asp:Label>
            </td>
            <td></td>
            <td>
                <telerik:RadComboBox ID="rcmb_BusinessUnitType" runat="server" AutoPostBack="True" Visible="false"
                    meta:resourcekey="rcmb_BusinessUnitTypeResource1" MarkFirstMatch="true" Filter="Contains"
                    OnSelectedIndexChanged="rcmb_BusinessUnitType_SelectedIndexChanged" Width="200px">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_rcmb_BusinessUnitType" runat="server" ControlToValidate="rcmb_BusinessUnitType"
                    ErrorMessage="Please Select BusinessUnit" InitialValue="Select" meta:resourcekey="rfv_rcmb_BusinessUnitTypeResource1"
                    ValidationGroup="Controls5">*</asp:RequiredFieldValidator>
            </td>
            <tr>
                <td>
                    <asp:Label ID="lbl_Employee" runat="server" Text="Employee"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td align="left">
                    <telerik:RadComboBox ID="rcmb_EmployeeType" runat="server" AutoPostBack="True" MarkFirstMatch="true" Filter="Contains"
                        meta:resourcekey="rcmb_EmployeeTypeResource1" OnSelectedIndexChanged="rcmb_EmployeeType_SelectedIndexChanged"
                        Width="200px">
                    </telerik:RadComboBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfv_rcmb_EmployeeType" runat="server" ControlToValidate="rcmb_EmployeeType"
                        ErrorMessage="Please Select Employee" InitialValue="Select" meta:resourcekey="rfv_rcmb_EmployeeTypeResource1"
                        ValidationGroup="Controls5">*</asp:RequiredFieldValidator>
                </td>


                <td>
                    <asp:Label ID="lbl_RpMgr" runat="server" meta:resourcekey="lbl_RpMgrResource1" Text="Reporting Manager"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td align="left">
                    <telerik:RadTextBox ID="rtxt_RpMgr" runat="server" MaxLength="40"
                        meta:resourcekey="rtxt_RpMgrResource1" Enabled="False">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LBL_AppraisalCycle" runat="server" Text="Appraisal&nbsp;Cycle"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td align="left">
                    <telerik:RadComboBox ID="rtxt_AppraisalCycle" runat="server" AutoPostBack="True" Filter="Contains"
                        MarkFirstMatch="true" MaxHeight="120px" OnSelectedIndexChanged="rtxt_AppraisalCycle_SelectedIndexChanged">
                    </telerik:RadComboBox>
                </td>
                <td></td>

                <td>
                    <asp:Label ID="lbl_GpMgr" runat="server" Text="Group Manager"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td>
                    <telerik:RadTextBox ID="rtxt_GpMgr" runat="server" MaxLength="40"
                        meta:resourcekey="rtxt_GpMgrResource1" Enabled="False">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <%-- <td>
                    <br />
                    <asp:Label ID="lbl_Project" runat="server" Text="Project"></asp:Label>
                </td>
                  <td>
                      <b>:</b>
                 </td>
                <td align="left" >
                    <telerik:RadTextBox ID="rtxt_Project" runat="server" 
                        MaxLength="40" meta:resourcekey="rtxt_ProjectResource1" Enabled="False">
                    </telerik:RadTextBox>
                </td>
                <td >
                  
                </td>--%>
                <td>
                    <asp:Label ID="lbl_Role" runat="server" Text="Position"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td align="left">
                    <telerik:RadTextBox ID="rtxt_Role" runat="server" LabelCssClass="" MaxLength="40"
                        meta:resourcekey="rtxt_RoleResource1" Enabled="False">
                    </telerik:RadTextBox>
                </td>
                <td></td>
            </tr>
            <%-- <tr>
            <td >
                <asp:Label ID="lbl_givefeedback" runat="server" Text="Feedback For"></asp:Label>
            </td>
              <td>
                <b>:</b>
              </td>
            <td align="left" >
                <telerik:RadComboBox ID="rcmb_feedback" runat="server" AutoPostBack="True" MarkFirstMatch="true" 
                    meta:resourcekey="rcmb_feedbackResource1" OnSelectedIndexChanged="rcmb_feedback_indexchanged"
                    Width="200px">
                    <Items>
                        <telerik:RadComboBoxItem runat="server" meta:resourcekey="RadComboBoxItemResource1"
                            Text="Select" Value="0" />
                        <telerik:RadComboBoxItem runat="server" meta:resourcekey="RadComboBoxItemResource2"
                            Text="GOAL" Value="1" />
                        <telerik:RadComboBoxItem runat="server" meta:resourcekey="RadComboBoxItemResource3"
                            Text="TASK" Value="2" />
                        <telerik:RadComboBoxItem runat="server" meta:resourcekey="RadComboBoxItemResource4"
                            Text="KRA" Value="3" />
                    </Items>
                </telerik:RadComboBox>
            </td>
        </tr>--%>
    </table>
    <telerik:RadMultiPage ID="RMP_Task" runat="server" Width="100%" SelectedIndex="0"
        meta:resourcekey="RMP_TaskResource1">
        <telerik:RadPageView ID="RP_TaskDetails" runat="server" Selected="True" meta:resourcekey="RP_TaskDetailsResource1">
            <table align="center" width="70%">
                <tr>
                    <td align="center">
                        <telerik:RadGrid ID="RG_Task" runat="server" Width="100%" ShowStatusBar="true" AutoGenerateColumns="False"
                            PageSize="5" AllowSorting="True" AllowMultiRowSelection="False"
                            AllowPaging="True" OnDetailTableDataBind="Rg_Task_DetailTableDataBind" OnNeedDataSource="Rg_Task_NeedDataSource">
                            <PagerStyle Mode="NumericPages"></PagerStyle>
                            <MasterTableView DataKeyNames="TASK_ID" AllowMultiColumnSorting="True">
                                <DetailTables>
                                    <telerik:GridTableView DataKeyNames="PF_FEEDBACK_ID" Name="Feedback" Width="100%">
                                        <Columns>
                                            <telerik:GridTemplateColumn>
                                                <ItemTemplate>
                                                    <table>
                                                        <tr style="border-bottom-color: White">
                                                            <td style="border-bottom-color: White">
                                                                <asp:Label ID="lbl_feedbackdate" runat="server" Text='<%# Eval("FEEDBACK_DATE") %>' />
                                                            </td>
                                                        </tr>
                                                        <tr style="border-bottom-color: White">
                                                            <td colspan="2" style="border-bottom-color: White">
                                                                <asp:Label ID="lbl_feedbbackname" runat="server" Text='<%# Eval("FEEDBACK_COMMENTS") %>' />
                                                            </td>
                                                        </tr>
                                                        <tr style="border-bottom-color: White">
                                                            <td align="left" style="border-bottom-color: White">
                                                                <telerik:RadRating ID="lbl_rating2" runat="server" Value='<%# Convert.ToInt32(Eval("FEEDBACK_RATING")) %>'
                                                                    ReadOnly="true" />
                                                            </td>
                                                            <td style="border-bottom-color: White">
                                                                <asp:Label ID="lbl_Feedback_id" runat="server" Text='<%# Eval("PF_FEEDBACK_ID") %>'
                                                                    Visible="false" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                    </telerik:GridTableView>
                                </DetailTables>
                                <ExpandCollapseColumn Visible="True">
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridTemplateColumn AllowFiltering="False" meta:resourcekey="GridTemplateColumnResource1"
                                        UniqueName="TASK_ID" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTASK_ID" runat="server" CommandArgument='<%# Eval("TASK_ID") %>'
                                                meta:resourcekey="lblTASK_IDResource1" Text='<%# Eval("TASK_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="TASK_NAME" HeaderText="Name" meta:resourcekey="GridBoundColumnResource1"
                                        UniqueName="TASK_NAME">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="TASK_DESCRIPTION" HeaderText="Description" meta:resourcekey="GridBoundColumnResource2"
                                        UniqueName="TASK_DESCRIPTION">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn AllowFiltering="False" HeaderText="AddFeedback" Visible="false">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk_AddFeedback" runat="server" CommandArgument='<%# Eval("TASK_ID") %>'
                                                OnClientClick=" openRadWin('frm_Pms_TaskFeedback.aspx'); return true;" OnCommand="lnk_taskaddcommand" Text="AddFeedback"></asp:LinkButton>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn AllowFiltering="False" Visible="false">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk_update" runat="server" CommandArgument='<%# Eval("TASK_ID") %>'
                                                OnCommand="lnk_update_command" Text="Update" Visible="false"></asp:LinkButton>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </td>
                </tr>
                <tr align="center">
                    <td>
                        <asp:Button ID="btn_Submit" Text="Submit" runat="server" Visible="false" OnClick="btnsubmit_TaskFeedback_click" />
                    </td>
                </tr>
            </table>
        </telerik:RadPageView>
    </telerik:RadMultiPage>
    <telerik:RadMultiPage ID="Rm_Goal" runat="server" Width="100%" SelectedIndex="0">
        <telerik:RadPageView ID="RP_Goal" runat="server" Selected="True" meta:resourcekey="RP_TaskDetailsResource1">
            <table align="center" width="70%">
                <tr>
                    <td align="center">
                        <telerik:RadGrid ID="RG_Goal" runat="server" Width="100%" AutoGenerateColumns="False"
                            PageSize="5" AllowSorting="True" AllowMultiRowSelection="False" AllowPaging="True"
                            OnDetailTableDataBind="RG_Goal_DetailTableDataBind" OnNeedDataSource="RG_Goal_NeedDataSource">
                            <PagerStyle Mode="NumericPages"></PagerStyle>
                            <MasterTableView DataKeyNames="GSDTL_ID" AllowMultiColumnSorting="True">
                                <ExpandCollapseColumn Visible="True">
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridTemplateColumn AllowFiltering="False" UniqueName="TASK_ID" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGOAL_ID" runat="server" CommandArgument='<%# Eval("GSDTL_ID") %>'
                                                Text='<%# Eval("GSDTL_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="GSDTL_NAME" HeaderText="Name" meta:resourcekey="GridBoundColumnResource1"
                                        UniqueName="GOALNAME">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="GSDTL_TARGET" HeaderText="Target" UniqueName="GSDTL_TARGET">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn AllowFiltering="False" HeaderText="AddFeedback" Visible="false">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk_AddFeedback" runat="server" CommandArgument='<%# Eval("GSDTL_ID") %>'
                                                OnClientClick=" openRadWin('frm_Pms_TaskFeedback.aspx'); return true;" OnCommand="lnk_goal_addcomand" Text="AddFeedback"></asp:LinkButton>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn AllowFiltering="False" Visible="false">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk_update" runat="server" CommandArgument='<%# Eval("GSDTL_ID") %>'
                                                OnCommand="lnk_goalupdate_command" Text="Update" Visible="false"></asp:LinkButton>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                                <DetailTables>
                                    <telerik:GridTableView DataKeyNames="PF_FEEDBACK_ID" Name="Feedback" Width="100%">
                                        <Columns>
                                            <telerik:GridTemplateColumn>
                                                <ItemTemplate>
                                                    <table>
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Label ID="lbl_feedbbackname" runat="server" Text='<%# Eval("FEEDBACK_COMMENTS") %>' />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_feedbackdate" runat="server" Text='<%# Eval("FEEDBACK_DATE") %>' />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <telerik:RadRating ID="lbl_rating1" runat="server" Value='<%# Convert.ToInt32(Eval("FEEDBACK_RATING")) %>'
                                                                    ReadOnly="true" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lbl_Feedback_id" runat="server" Text='<%# Eval("PF_FEEDBACK_ID") %>'
                                                                    Visible="false" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                    </telerik:GridTableView>
                                </DetailTables>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </td>
                </tr>
                <tr align="center">
                    <td>
                        <asp:Button ID="btn_Submit_Goal" Text="Submit" Visible="false" runat="server" OnClick="btn_Submit_GoalFeedback_click" />
                    </td>
                </tr>
            </table>
        </telerik:RadPageView>
    </telerik:RadMultiPage>
    <telerik:RadMultiPage ID="Rm_Kra" runat="server" Width="100%" SelectedIndex="0">
        <telerik:RadPageView ID="RP_Kra" runat="server" Selected="True">
            <table align="center" width="70%">
                <tr>
                    <td align="center">
                        <telerik:RadGrid ID="RG_Kra" runat="server" Width="100%" ShowStatusBar="true" AutoGenerateColumns="False"
                            PageSize="3" AllowSorting="True" AllowMultiRowSelection="False"
                            AllowPaging="True" OnDetailTableDataBind="RG_Kra_DetailTableDataBind" OnNeedDataSource="RG_kra_NeedDataSource">
                            <PagerStyle Mode="NumericPages"></PagerStyle>
                            <MasterTableView DataKeyNames="gs_kra_id" AllowMultiColumnSorting="True">
                                <ExpandCollapseColumn Visible="True">
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridTemplateColumn AllowFiltering="False" UniqueName="TASK_ID" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblKRA_ID" runat="server" CommandArgument='<%# Eval("gs_kra_id") %>'
                                                Text='<%# Eval("gs_kra_id") %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="KRA_NAME" HeaderText="Name" meta:resourcekey="GridBoundColumnResource1"
                                        UniqueName="KRA_NAME">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="KRA_DESC" HeaderText="Description" meta:resourcekey="GridBoundColumnResource2"
                                        UniqueName="KRA_DESC">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="GS_KRA_TARGET" HeaderText="Target" UniqueName="GS_KRA_TARGET">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn AllowFiltering="False" HeaderText="AddFeedback" Visible="false">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk_AddFeedback" runat="server" CommandArgument='<%# Eval("gs_kra_id") %>'
                                                OnClientClick=" openRadWin('frm_Pms_TaskFeedback.aspx'); return true;" OnCommand="lnk_kraaddcommand" Text="AddFeedback"></asp:LinkButton>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn AllowFiltering="False" Visible="false">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk_update" runat="server" CommandArgument='<%# Eval("gs_kra_id") %>'
                                                OnCommand="lnk_kraupdate_command" Text="Update" Visible="false"></asp:LinkButton>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                                <DetailTables>
                                    <telerik:GridTableView DataKeyNames="PF_FEEDBACK_ID" Name="Feedback" Width="100%"
                                        Style="border-bottom-color: White">
                                        <Columns>
                                            <telerik:GridTemplateColumn>
                                                <ItemTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_feedbackdate" runat="server" Text='<%# Eval("FEEDBACK_DATE") %>' />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Label ID="lbl_feedbbackname" runat="server" Text='<%# Eval("FEEDBACK_COMMENTS") %>' />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <telerik:RadRating ID="lbl_rating" runat="server" Value='<%# Convert.ToInt32(Eval("FEEDBACK_RATING")) %>'
                                                                    ReadOnly="true" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lbl_Feedback_id" runat="server" Text='<%# Eval("PF_FEEDBACK_ID") %>'
                                                                    Visible="false" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                    </telerik:GridTableView>
                                </DetailTables>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </td>
                </tr>
                <tr align="center">
                    <td>
                        <asp:Button ID="btn_Submit_Kra" Text="Submit" Visible="false" runat="server" OnClick="btn_Submit_KraFeedback_click" />
                    </td>
                </tr>
            </table>
        </telerik:RadPageView>
    </telerik:RadMultiPage>
    <telerik:RadMultiPage ID="RM_All" runat="server" Width="100%" SelectedIndex="0">
        <telerik:RadPageView ID="RP_All" runat="server" Selected="True">
            <table align="center" width="70%">
                <tr>
                    <td align="center">
                        <telerik:RadGrid ID="RG_All" runat="server" Width="100%" AutoGenerateColumns="False"
                            AllowSorting="True" AllowMultiRowSelection="False"
                            OnNeedDataSource="RG_All_NeedDataSource" OnItemDataBound="RG_All_ItemDataBound">
                            <PagerStyle Mode="NumericPages"></PagerStyle>
                            <MasterTableView DataKeyNames="ROLEKRA_ID,A" AllowMultiColumnSorting="True">
                                <ExpandCollapseColumn Visible="True">
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridTemplateColumn AllowFiltering="False" UniqueName="TASK_ID" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblROLEKRA_ID" runat="server" CommandArgument='<%# Eval("ROLEKRA_ID") %>'
                                                Text='<%# Eval("ROLEKRA_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <%-- <telerik:GridTemplateColumn AllowFiltering="False" UniqueName="A" HeaderText="Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_type" runat="server" Text='<%# Eval("A") %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>--%>
                                    <telerik:GridBoundColumn DataField="A" HeaderText="Type" UniqueName="A" HeaderStyle-HorizontalAlign="Center">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="NAME" HeaderText="Name" UniqueName="NAME" HeaderStyle-HorizontalAlign="Center">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="TARGET" HeaderText="Target" UniqueName="TARGET" Visible="false" Display="false">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn AllowFiltering="False" HeaderText="ViewFeedback" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk_ViewFeedback" runat="server" CommandArgument='<%# Eval("ROLEKRA_ID") %>' CommandName='<%# Eval("A") %>'
                                                OnCommand="lnk_all_Viewcomand" Text="ViewFeedback"></asp:LinkButton>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <%--<telerik:GridTemplateColumn AllowFiltering="False" HeaderText="AddFeedback">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk_AddFeedback" runat="server" CommandArgument='<%# Eval("ROLEKRA_ID") %>'
                                                OnClientClick=" openRadWin('frm_Pms_TaskFeedback.aspx'); return true;" OnCommand="lnk_all_addcomand"  Text="AddFeedback"></asp:LinkButton>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>--%>
                                    <%--<telerik:GridTemplateColumn AllowFiltering="False" Visible="false">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk_update" runat="server" CommandArgument='<%# Eval("ROLEKRA_ID") %>'
                                                OnCommand="lnk_goalupdate_command" Text="Update" Visible="false"></asp:LinkButton>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>--%>
                                </Columns>
                                <%--  <DetailTables>
                                    <telerik:GridTableView DataKeyNames="PF_FEEDBACK_ID" Name="Feedback" Width="100%">
                                        <Columns>
                                            <telerik:GridTemplateColumn>
                                                <ItemTemplate>
                                                    <table>
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Label ID="lbl_feedbbackname" runat="server" Text='<%# Eval("FEEDBACK_COMMENTS") %>' />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_feedbackdate" runat="server" Text='<%# Eval("FEEDBACK_DATE") %>' />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <telerik:RadRating ID="lbl_rating1" runat="server" Value='<%# Convert.ToInt32(Eval("FEEDBACK_RATING")) %>'
                                                                    ReadOnly="true" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lbl_Feedback_id" runat="server" Text='<%# Eval("PF_FEEDBACK_ID") %>'
                                                                    Visible="false" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                    </telerik:GridTableView>
                                </DetailTables>--%>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </td>
                </tr>
            </table>
        </telerik:RadPageView>
    </telerik:RadMultiPage>
</asp:Content>