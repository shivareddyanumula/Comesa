<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_Pms_Reports.aspx.cs" Inherits="PMS_frm_Pms_Reports" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">

        <script type="text/javascript">
            function openRadWin(str1) {
                radopen(str1, "RW_FEEDBACK");
            }
            function ShowPop(EMP_ID, APPCYCLE_ID, STR) {
                var win = window.radopen('../PMS/frm_EMPAppraisalDetails.aspx?EMP_ID=' + EMP_ID + '&APPCYCLE_ID= ' + APPCYCLE_ID + '&STR= ' + STR, "RW_EMPAppraisalDetails");
                win.center();
                //win.height = 30;
                win.set_modal(true);
            }
        </script>

    </telerik:RadScriptBlock>
    <telerik:RadWindowManager ID="RWM_POSTREPLY" runat="server">
        <Windows>
            <telerik:RadWindow ID="RW_FEEDBACK" Modal="true" runat="server"
                Width="700px" Height="500px" Title="Post Comments" VisibleStatusbar="false" ReloadOnShow="true"
                Behaviors="Close" KeepInScreenBounds="true" ShowContentDuringLoad="true">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <table align="center">
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_Reprts_Main_PAGE" runat="server" SelectedIndex="0" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_Reports_VIEWMAIN" runat="server" Selected="True" Width="493px">
                        <table align="center" style="width: 61%">
                            <tr>
                                <td align="center">
                                    <center>
                                        <b>Reports</b>
                                    </center>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:RadioButtonList ID="rtn_Reportlist" runat="server" OnSelectedIndexChanged="rtn_Reportlist_SelectedIndexChanged"
                                        AutoPostBack="True" Width="346px">
                                        <asp:ListItem Value="0">List Of Employee Whose Goal Setting Done</asp:ListItem>
                                        <asp:ListItem Value="1">List Of Employee Whose Appraisal Done</asp:ListItem>
                                        <asp:ListItem Value="3">List Of Employee Whose Appraisal Open </asp:ListItem>
                                        <asp:ListItem Value="4">List Of Employee Ratings </asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_EmployeeRatings" runat="server" Selected="True" Width="493px">
                        <table align="center" style="width: 73%">
                            <tr>
                                <%--<td align="center">
                                </td>--%>
                                <td align="center" colspan="3">
                                    <asp:Label ID="lbl_Heading1" runat="server" Text="Employee Ratings" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_BUID" runat="server" Text="BusinessUnit"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_BusinessUnit" AutoPostBack="true" runat="server" Filter="Contains"
                                        OnSelectedIndexChanged="rcmb_BusinessUnit_SelectedIndexChanged" MarkFirstMatch="true">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_ApprCycle" runat="server" Text="AppraisalCycle"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_AppCycle" AutoPostBack="true" runat="server" Filter="Contains"
                                        OnSelectedIndexChanged="rcmb_AppCycle_SelectedIndexChanged" MarkFirstMatch="true">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_RM" runat="server" Text="Reporting Manager"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_RManager" AutoPostBack="true" runat="server" Filter="Contains"
                                        OnSelectedIndexChanged="rcmb_RManager_SelectedIndexChanged" MarkFirstMatch="true">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rpv_EmployeeRatings" runat="server">
                        <table align="center" width="100%">
                            <tr>
                                <td align="center">
                                    <center>
                                        <b>Employee Ratings</b>
                                    </center>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <telerik:RadGrid ID="Rg_Ratings" runat="server" AutoGenerateColumns="False"
                                        ClientSettings-Scrolling-AllowScroll="true" ClientSettings-Scrolling-UseStaticHeaders="true"
                                        Skin="WebBlue" GridLines="None" AllowFilteringByColumn="false"
                                        OnItemDataBound="Rg_Ratings_ItemDataBound">
                                        <HeaderContextMenu>
                                        </HeaderContextMenu>
                                        <MasterTableView>
                                            <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                            <Columns>
                                                <telerik:GridTemplateColumn AllowFiltering="false" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_empid" runat="server" Text='<%# Eval("EMP_ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Employee Code"
                                                    UniqueName="lnkcolumn">
                                                    <ItemTemplate>
                                                        <%-- <asp:HyperLink  ID = "lnkcolumn" runat="server" Text='<%# Eval("EMP_EMPCODE") %>'></asp:HyperLink>--%>
                                                        <asp:LinkButton ID="lnkcolumn" runat="server"
                                                            CommandArgument='<%# Eval("EMP_ID") %>' OnCommand="lnk_ViewDetailsCommand"
                                                            Text='<%# Eval("EMP_EMPCODE") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn AllowFiltering="false" DataField="Employee"
                                                    HeaderText="Employee">
                                                </telerik:GridBoundColumn>

                                                <telerik:GridBoundColumn AllowFiltering="false" DataField="Designation"
                                                    HeaderText="Position">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="APPRAISAL_GOAL_AVGRTG" HeaderText="Competency Avg Rating (%)">
                                                </telerik:GridBoundColumn>
                                                <%-- <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Goal Rating">
                                                    <ItemTemplate>
                                                        <telerik:RadRating ID="rdrtng_Goal" runat="server" AutoPostBack="false" 
                                                            Precision="Exact" 
                                                             Enabled="false"
                                                            Value='<%# Convert.ToDouble(Eval("APPRAISAL_GOAL_AVGRTG")) %>' />
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>--%>
                                                <telerik:GridBoundColumn DataField="APPRAISAL_KRA_AVGRTG" HeaderText="KRA Avg Rating (%)">
                                                </telerik:GridBoundColumn>
                                                <%--<telerik:GridTemplateColumn AllowFiltering="false" HeaderText="KRA Rating">
                                                    <ItemTemplate>
                                                        <telerik:RadRating ID="rdrtng_KRA" runat="server" AutoPostBack="false" 
                                                            Precision="Exact" 
                                                            Enabled="false"
                                                            Value='<%# Convert.ToDouble(Eval("APPRAISAL_KRA_AVGRTG")) %>' />
                                                    </ItemTemplate>--%>
                                                <%--ReadOnly='<%# Convertk.ToBoolean(Eval("APPRAISAL_KRA_AVGRTG")) %>' --%>
                                                <%-- </telerik:GridTemplateColumn>--%>
                                                <telerik:GridBoundColumn DataField="APPRAISAL_IDP_AVGRTG" HeaderText="Value Avg Rating (%)">
                                                </telerik:GridBoundColumn>
                                                <%--<telerik:GridTemplateColumn AllowFiltering="false" HeaderText="IDP Rating">
                                                    <ItemTemplate>
                                                        <telerik:RadRating ID="rdrtng_IDP" runat="server" AutoPostBack="false" 
                                                            Precision="Exact" 
                                                             Enabled="false"
                                                            Value='<%# Convert.ToDouble(Eval("APPRAISAL_IDP_AVGRTG")) %>' />
                                                    </ItemTemplate>--%>
                                                <%-- ReadOnly='<%# Convert.ToBoolean(Eval("APPRAISAL_IDP_AVGRTG")) %>' --%>
                                                <%--</telerik:GridTemplateColumn>--%>

                                                <telerik:GridBoundColumn AllowFiltering="false" DataField="finalrating"
                                                    HeaderText="Final Avg Rating (%)">
                                                </telerik:GridBoundColumn>
                                                <%-- <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Final Rating">
                                                    <ItemTemplate>
                                                        <telerik:RadRating ID="rdrtn_final" runat="server" AutoPostBack="false" 
                                                            Precision="Exact" 
                                                           Enabled="false"
                                                            Value='<%# Convert.ToDouble(Eval("finalrating")) %>' />
                                                    </ItemTemplate>--%>
                                                <%--  ReadOnly='<%# Convert.ToBoolean(Eval("finalrating")) %>' --%>
                                                <%--</telerik:GridTemplateColumn>--%>
                                                <telerik:GridTemplateColumn AllowFiltering="false" UniqueName="Reject">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Employee_Edit" runat="server" OnCommand="lnk_Reject_Command" CommandArgument='<%# Eval("EMP_ID") %>' Text="Reject">
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <EditFormSettings>
                                                <EditColumn CancelImageUrl="Cancel.gif" EditImageUrl="Edit.gif"
                                                    InsertImageUrl="Update.gif" UpdateImageUrl="Update.gif">
                                                </EditColumn>
                                            </EditFormSettings>
                                        </MasterTableView>
                                        <FilterMenu>
                                        </FilterMenu>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
                <telerik:RadMultiPage ID="Rm_Goal_Reports" runat="server" SelectedIndex="0" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_Goal_dtls" runat="server" Selected="True" Width="493px">
                        <table align="center" style="width: 73%">
                            <tr>
                                <td align="center" colspan="3">
                                    <b>Goal Setting</b>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_BusinessUnit" runat="server" Text="BusinessUnit"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_BusinessUnitGoal" AutoPostBack="true" runat="server" Filter="Contains"
                                        OnSelectedIndexChanged="rcmb_BusinessUnitGoal_SelectedIndexChanged" MarkFirstMatch="true">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_AppraisalCycle" runat="server" Text="AppraisalCycle"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="RCB_AppraisalCycleGoal" AutoPostBack="true" runat="server" Filter="Contains"
                                        OnSelectedIndexChanged="RCB_AppraisalCycleGoal_SelectedIndexChanged" MarkFirstMatch="true">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_RptEmp_Goal" runat="server" Text="Reporting Employee"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_RptEmp_Goal" AutoPostBack="true" runat="server" Filter="Contains"
                                        OnSelectedIndexChanged="rcmb_RptEmp_Goal_SelectedIndexChanged" MarkFirstMatch="true" MaxHeight="120px">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_Goal_Reports" runat="server" Width="493px">
                        <table align="center" width="100%">
                            <tr>
                                <td align="center">
                                    <center>
                                        <b>Goal Setting</b>
                                    </center>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <telerik:RadGrid ID="RG_GoalReports" runat="server" AutoGenerateColumns="False"
                                        ClientSettings-Scrolling-AllowScroll="true" ClientSettings-Scrolling-UseStaticHeaders="true" Skin="WebBlue" GridLines="None">
                                        <MasterTableView>
                                            <Columns>
                                                <telerik:GridBoundColumn HeaderText="Employee" DataField="EMPLOYEE_NAME">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Designation" DataField="POSITIONS_CODE">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Status" DataField="GS_STATUS">
                                                </telerik:GridBoundColumn>
                                            </Columns>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
                <telerik:RadMultiPage ID="Rm_Appraisal" runat="server" SelectedIndex="0" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_Appraisal" runat="server" Selected="True" Width="493px">
                        <table align="center" width="50%">
                            <tr>
                                <td align="center" colspan="3">
                                    <b>Appraisal Done</b>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_bu" runat="server" Text="BusinessUnit"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_businessunitAppraisal" AutoPostBack="true" runat="server" Filter="Contains"
                                        OnSelectedIndexChanged="rcmb_businessunitAppraisal_SelectedIndexChanged" MarkFirstMatch="true">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_appraisalcycle1" runat="server" Text="AppraisalCycle"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_appraisalApprais" AutoPostBack="true" runat="server" Filter="Contains"
                                        OnSelectedIndexChanged="rcmb_appraisalApprais_SelectedIndexChanged" MarkFirstMatch="true">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_Appraisal_Grid" runat="server" Width="493px">
                        <table align="center" width="50%">
                            <tr>
                                <td align="center">
                                    <center>
                                        <b>Appraisal Done</b>
                                    </center>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <telerik:RadGrid ID="RG_AppraisalReports" runat="server" AutoGenerateColumns="False"
                                        ClientSettings-Scrolling-AllowScroll="true" ClientSettings-Scrolling-UseStaticHeaders="true"
                                        Skin="WebBlue" GridLines="None" AllowFilteringByColumn="True" Width="500px">
                                        <MasterTableView>
                                            <Columns>
                                                <telerik:GridBoundColumn HeaderText="Employee Code" DataField="EMP_EMPCODE" AllowFiltering="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Emp Name" DataField="EMPLOYEE_NAME" AllowFiltering="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Designation" DataField="EMP_DESIGNATION_ID"
                                                    AllowFiltering="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Grade" DataField="GRADE" AllowFiltering="false">
                                                </telerik:GridBoundColumn>
                                            </Columns>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
                <telerik:RadMultiPage ID="Rm_App_Disc" runat="server" SelectedIndex="0" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_APP_Disc" runat="server" Selected="True" Width="493px">
                        <table align="center" width="50%">
                            <tr>
                                <td align="center" colspan="3">
                                    <b>Appraisal Open</b>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_bu_id" runat="server" Text="BusinessUnit"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcm_bunitAppDisc" AutoPostBack="true" runat="server" Filter="Contains"
                                        OnSelectedIndexChanged="rcm_bunitAppDisc_SelectedIndexChanged" MarkFirstMatch="true">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_app_cycle" runat="server" Text="AppraisalCycle"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcm_app_cycleAppDisc" AutoPostBack="true" runat="server" Filter="Contains"
                                        OnSelectedIndexChanged="rcm_app_cycleAppDisc_SelectedIndexChanged" MarkFirstMatch="true">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_APPdISC" runat="server" Width="493px">
                        <table align="center" width="50%">
                            <tr>
                                <td align="center">
                                    <center>
                                        <b>Appraisal Open </b>
                                    </center>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <telerik:RadGrid ID="Rg_appdisc" runat="server" AutoGenerateColumns="False"
                                        ClientSettings-Scrolling-AllowScroll="true" ClientSettings-Scrolling-UseStaticHeaders="true"
                                        Skin="WebBlue" GridLines="None" AllowFilteringByColumn="True" Width="500px">
                                        <MasterTableView>
                                            <Columns>
                                                <telerik:GridBoundColumn HeaderText="Employee Code" DataField="EMP_EMPCODE" AllowFiltering="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Emp Name" DataField="EMPLOYEE_NAME" AllowFiltering="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Designation" DataField="EMP_DESIGNATION_ID"
                                                    AllowFiltering="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Status" DataField="APPRAISAL_STAGE"
                                                    AllowFiltering="false">
                                                </telerik:GridBoundColumn>
                                            </Columns>
                                        </MasterTableView>
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