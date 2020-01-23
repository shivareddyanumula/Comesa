<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_PmsAppraisalDiscussion.aspx.cs" Inherits="PMS_frm_PmsAppraisalDiscussion"
    Culture="auto" UICulture="auto" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">

        <script type="text/javascript">
            function openRadWin(str) {
                radopen(str, "RW_IDP");

            }

            function openRadWin(str) {
                radopen(str, "Rw_Task");

            }

        </script>

    </telerik:RadScriptBlock>
    <telerik:RadWindowManager ID="RWM_EMICALENDER" runat="server" Skin="WebBlue" Animation="Slide"
        AnimationDuration="300" Behaviors="Close" AutoSize="True"
        Height="400px" Width="400px" Behavior="Close" InitialBehavior="None" meta:resourcekey="RWM_EMICALENDERResource1">
        <Windows>
            <telerik:RadWindow ID="RW_IDP" Skin="WebBlue" Modal="true" runat="server" Width="400px"
                Height="400px" Title="IDP" AutoSize="true" VisibleStatusbar="false" ReloadOnShow="true"
                Behaviors="Close" KeepInScreenBounds="true" ShowContentDuringLoad="true" meta:resourcekey="RW_IDPResource1">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <telerik:RadWindowManager ID="Rw_Task" runat="server" Skin="WebBlue" Animation="Slide"
        AnimationDuration="300" Behaviors="Close" Behavior="Close"
        InitialBehavior="None" meta:resourcekey="Rw_TaskResource1">
        <Windows>
            <telerik:RadWindow ID="RadWindow1" Skin="WebBlue" Modal="true" runat="server" Width="400px"
                Height="400px" Title="Task Details" VisibleStatusbar="false" ReloadOnShow="true"
                Behaviors="Close" InitialBehaviors="Maximize" AutoSize="true" KeepInScreenBounds="true"
                ShowContentDuringLoad="true" meta:resourcekey="RadWindow1Resource1">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <table align="center">
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_Appraisal_PAGE" runat="server" SelectedIndex="0" ScrollBars="Auto"
                    meta:resourcekey="Rm_Appraisal_PAGEResource1">
                    <telerik:RadPageView ID="Rp_Appraisal_VIEWDETAILS" runat="server" Selected="True"
                        meta:resourcekey="Rp_Appraisal_VIEWDETAILSResource1" Enabled="true">
                        <center>
                            <b>Appraisal Discussion</b></center>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <table align="center">
                            <tr>
                                <td colspan="3" align="center">
                                    <asp:Label ID="LBL_Appraise_Id" runat="server" Text="Appraisal Cycle :" Visible="false"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_appraisal_Id" runat="server" Visible="False" meta:resourcekey="lbl_Feedback_IdResource1"></asp:Label>
                                    <asp:Label ID="lbl_BusinessUnitName" runat="server" Text="BusinessUnit" meta:resourcekey="lbl_BusinessUnitNameResource1"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_BusinessUnitType" runat="server" AutoPostBack="True" MarkFirstMatch="true"
                                        OnSelectedIndexChanged="rcmb_BusinessUnitType_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_BusinessUnitType" ControlToValidate="rcmb_BusinessUnitType"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please Select BusinessUnit"
                                        InitialValue="Select" meta:resourcekey="rfv_rcmb_BusinessUnitTypeResource1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LBL_AppraisalCycle" runat="server" Text="Appraisal Cycle "></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <%--<telerik:RadTextBox ID="rtxt_AppraisalCycle" runat="server" MaxLength="40" LabelCssClass="" >
                                    </telerik:RadTextBox>--%>
                                    <telerik:RadComboBox ID="rtxt_AppraisalCycle" runat="server"
                                        AutoPostBack="True" MaxHeight="120px" MarkFirstMatch="true"
                                        OnSelectedIndexChanged="rtxt_AppraisalCycle_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td></td>

                                <td>
                                    <asp:Label ID="lbl_RpMgr" runat="server" Text="Reporting Manager:" meta:resourcekey="lbl_RpMgrResource1"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadTextBox ID="rtxt_RpMgr" runat="server" MaxLength="40" LabelCssClass=""
                                        meta:resourcekey="rtxt_RpMgrResource1" Enabled="False">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Employee" runat="server" Text="Employee " meta:resourcekey="lbl_EmployeeResource1"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="rcmb_EmployeeType11" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rcmb_EmployeeType11_SelectedIndexChanged" Enabled="true"
                                        Width="200px" MarkFirstMatch="true" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_EmployeeType11" ControlToValidate="rcmb_EmployeeType11"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please Select Employee"
                                        InitialValue="Select">*</asp:RequiredFieldValidator>
                                </td>

                                <td>
                                    <asp:Label ID="lbl_GpMgr" runat="server" Text="Group Manager"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_GpMgr" runat="server" MaxLength="40" LabelCssClass=""
                                        meta:resourcekey="rtxt_GpMgrResource1" Enabled="False">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Position" runat="server" Text="Position " meta:resourcekey="lbl_PositionResource1"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadTextBox ID="rtxt_Position" runat="server" MaxLength="40" LabelCssClass=""
                                        meta:resourcekey="rtxt_PositionResource1" Enabled="False">
                                    </telerik:RadTextBox>
                                </td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td align="left"></td>
                            </tr>
                            <%--<tr>
                               <td>
                                    <asp:Label ID="lbl_Role" runat="server" Text="Role " meta:resourcekey="lbl_RoleResource1"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadTextBox ID="rtxt_Role" runat="server" MaxLength="40" LabelCssClass=""
                                         meta:resourcekey="rtxt_RoleResource1">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                </td>
                                <td >
                                    <asp:Label ID="lbl_Project" runat="server" Text="Project " meta:resourcekey="lbl_ProjectResource1"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadTextBox ID="rtxt_Project" runat="server" MaxLength="40" LabelCssClass=""
                                        meta:resourcekey="rtxt_ProjectResource1"  
                                        Enabled="False">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>--%>
                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" CssClass="LABELSS"
                                ShowMessageBox="True" ShowSummary="False" ValidationGroup="Controls" meta:resourcekey="vs_AppraisalDiscussionResource1" />
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
                <telerik:RadMultiPage ID="Rm_Appraisal_Goal" runat="server" SelectedIndex="0" ScrollBars="Auto"
                    Width="100%" meta:resourcekey="Rm_Appraisal_GoalResource1">
                    <telerik:RadPageView ID="Rp_Appraisal_Goal_VIEWMAIN" runat="server" Selected="True"
                        meta:resourcekey="Rp_Appraisal_Goal_VIEWMAINResource1">
                        <table align="center" width="100%">
                            <tr>
                                <td align="center"></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="Rg_Appraisal_Goal" runat="server" AutoGenerateColumns="False" ShowHeader="False"
                                        Width="100%" meta:resourcekey="Rg_Appraisal_GoalResource1" OnRowCommand="Rg_Appraisal_Goal_RowCommand">
                                        <Columns>
                                            <asp:TemplateField meta:resourcekey="TemplateFieldResource2">
                                                <ItemTemplate>
                                                    <table width="600px">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_Goal_Id" runat="server" Text='<%# Eval("GSDTL_ID") %>' Visible="False"
                                                                    meta:resourcekey="lbl_Goal_IdResource1"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <b>Goal&nbsp;Name &nbsp:</b>
                                                                <asp:Label ID="lbl_GoalName" runat="server" Text='<%# Eval("GSDTL_NAME") %>' meta:resourcekey="lbl_GoalNameResource1"></asp:Label>
                                                            </td>
                                                            <td class="style1">&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>
                                                                <b>Goal Weightage &nbsp:</b>
                                                                <asp:Label ID="lbl_GoalWeightage" runat="server" Text='<%# Eval("GSDTL_WEIGHTAGE") %>'
                                                                    meta:resourcekey="lbl_GoalWeightageResource1"></asp:Label>
                                                            </td>
                                                            <td class="style1">&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <b>Goal Measure &nbsp:</b>
                                                                <asp:Label ID="lbl_GoalMeasure" runat="server" Text='<%# Eval("GSDTL_MEASURE") %>'
                                                                    meta:resourcekey="lbl_GoalMeasureResource1"></asp:Label>
                                                            </td>
                                                            <td class="style1">&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>
                                                                <b>Goal Date &nbsp:</b>
                                                                <asp:Label ID="lbl_GoalDate" runat="server" Text='<%# Eval("GSDTL_DATE") %>' meta:resourcekey="lbl_GoalDateResource1"></asp:Label>
                                                            </td>
                                                            <td class="style1">&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:LinkButton ID="lnk_GoalEmployeeFeedback" runat="server" CommandArgument="<%# Container.DisplayIndex %>"
                                                                    CommandName="GoalEmployee_Feed" Style="font-weight: 700; font-size: small; font-family: Arial, Helvetica, sans-serif"
                                                                    meta:resourcekey="lnk_GoalEmployeeFeedbackResource1" Text="+ EmployeeFeedback"></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                                <asp:TextBox ID="txt_GoalEmployeeFeedback" runat="server" Height="77px" TextMode="MultiLine"
                                                                    Visible="False" Width="500px" meta:resourcekey="txt_GoalEmployeeFeedbackResource1"></asp:TextBox>
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style1">&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:LinkButton ID="lnk_GoalManagerFeedback" runat="server" CommandArgument="<%# Container.DisplayIndex %>"
                                                                    CommandName="GoalMgr_Feed" Style="font-weight: 700; font-size: small; font-family: Arial, Helvetica, sans-serif"
                                                                    meta:resourcekey="lnk_GoalManagerFeedbackResource1" Text="+ ManagerFeedback"></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                                <asp:TextBox ID="txt_GoalManagerFeedback" runat="server" Height="77px" TextMode="MultiLine"
                                                                    Visible="False" Width="500px" meta:resourcekey="txt_GoalManagerFeedbackResource1"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <telerik:RadRating ID="rdrtg_GoalMgr" runat="server" Visible="False" meta:resourcekey="rdrtg_GoalMgrResource1" />
                                                            </td>
                                                            <td class="style1">&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Button ID="btn_GoalMgrSubmit" runat="server" CommandArgument="<%# Container.DisplayIndex %>"
                                                                    CommandName="btn_GoalMgrSubmit" Text="Submit" Visible="False" meta:resourcekey="btn_GoalMgrSubmitResource1" />
                                                                <asp:Button ID="btn_GoalMgrCancel" runat="server" CommandArgument="<%# Container.DisplayIndex %>"
                                                                    CommandName="btn_GoalMgrCancel" Text="Cancel" Visible="False" meta:resourcekey="btn_GoalMgrCancelResource1" />
                                                            </td>
                                                            <td class="style1">&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr align="right">
                                <td>
                                    <asp:Label ID="lbl_GoalAvgRtg" runat="server" Style="font-weight: 700; font-size: small; font-family: Arial, Helvetica, sans-serif"
                                        meta:resourcekey="lbl_GoalAvgRtgResource1"
                                        Text="Average Rating"></asp:Label>
                                </td>
                                <td class="style1">
                                    <telerik:RadNumericTextBox ID="rnt_GoalAvgrtg" runat="server" LabelCssClass="" meta:resourcekey="rnt_FinalRatingResource1">
                                        <NumberFormat DecimalDigits="0" />
                                    </telerik:RadNumericTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
                <telerik:RadMultiPage ID="Rm_Appraisal_Kra" runat="server" SelectedIndex="0" ScrollBars="Auto"
                    Width="100%" meta:resourcekey="Rm_Appraisal_KraResource1">
                    <telerik:RadPageView ID="Rp_Appraisal_Kra_VIEWMAIN" runat="server" Selected="True"
                        meta:resourcekey="Rp_Appraisal_Kra_VIEWMAINResource1">
                        <table align="center" width="100%">
                            <tr>
                                <td align="center"></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="Rg_Appraisal_Kra" runat="server" AutoGenerateColumns="False" ShowHeader="False"
                                        Width="100%" meta:resourcekey="Rg_Appraisal_KraResource1" OnRowCommand="Rg_Appraisal_Kra_Command">
                                        <Columns>
                                            <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
                                                <ItemTemplate>
                                                    <table width="600px">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_Kra_Id" runat="server" Text='<%# Eval("KRA_ID") %>' Visible="False"
                                                                    meta:resourcekey="lbl_Kra_IdResource1"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_Kra_AppraisalCycle" runat="server" Text='<%# Eval("GS_APPRAISAL_CYCLE") %>'
                                                                    Visible="False" meta:resourcekey="lbl_Kra_AppraisalCycleResource1"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <b>Kra&nbsp;Name &nbsp:</b>
                                                                <asp:Label ID="lbl_KraName" runat="server" Text='<%# Eval("KRA_NAME") %>' meta:resourcekey="lbl_KraNameResource1"></asp:Label>
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <b>Kra Description &nbsp:</b>
                                                                <asp:Label ID="lbl_KraDescription" runat="server" Text='<%# Eval("KRA_DESC") %>'
                                                                    meta:resourcekey="lbl_KraDescriptionResource1"></asp:Label>
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <b>Kra Measure &nbsp:</b>
                                                                <asp:Label ID="lbl_KraMeasure" runat="server" Text='<%# Eval("KRA_MEASURE") %>' meta:resourcekey="lbl_KraMeasureResource1"></asp:Label>
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:LinkButton ID="lnk_KraEmployeeFeedback" runat="server" CommandArgument="<%# Container.DisplayIndex %>"
                                                                    CommandName="KraEmployee_Feed" Style="font-weight: 700; font-size: small; font-family: Arial, Helvetica, sans-serif"
                                                                    meta:resourcekey="lnk_KraEmployeeFeedbackResource1" Text="+ EmployeeFeedback"></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                                <asp:TextBox ID="txt_KraEmployeeFeedback" runat="server" Height="77px" TextMode="MultiLine"
                                                                    Visible="False" Width="500px" meta:resourcekey="txt_KraEmployeeFeedbackResource1"></asp:TextBox>
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
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
                                                            <td>&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:LinkButton ID="lnk_KraManagerFeedback" runat="server" CommandArgument="<%# Container.DisplayIndex %>"
                                                                    CommandName="KraMgr_Feed" Style="font-weight: 700; font-size: small; font-family: Arial, Helvetica, sans-serif"
                                                                    meta:resourcekey="lnk_KraManagerFeedbackResource1" Text="+ ManagerFeedback"></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                                <asp:TextBox ID="txt_KraManagerFeedback" runat="server" Height="77px" TextMode="MultiLine"
                                                                    Visible="False" Width="500px" meta:resourcekey="txt_KraManagerFeedbackResource1"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <telerik:RadRating ID="rdrtg_KraMgr" runat="server" Visible="False" meta:resourcekey="rdrtg_KraMgrResource1" />
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Button ID="btn_KraMgrSubmit" runat="server" CommandArgument="<%# Container.DisplayIndex %>"
                                                                    CommandName="btn_KraMgrSubmit" Text="Submit" Visible="False" meta:resourcekey="btn_KraMgrSubmitResource1" />
                                                                <asp:Button ID="btn_KraMgrCancel" runat="server" CommandArgument="<%# Container.DisplayIndex %>"
                                                                    CommandName="btn_KraMgrCancel" Text="Cancel" Visible="False" meta:resourcekey="btn_KraMgrCancelResource1" />
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <tr align="right">
                                        <td>
                                            <asp:Label ID="lbl_KraAvgRtg" runat="server" Style="font-weight: 700; font-size: small; font-family: Arial, Helvetica, sans-serif"
                                                meta:resourcekey="lbl_KraAvgRtgResource1"
                                                Text="Average Rating"></asp:Label>
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="rnt_KraAvgrtg" runat="server" LabelCssClass="" meta:resourcekey="rnt_FinalRatingResource1">
                                                <NumberFormat DecimalDigits="0" />
                                            </telerik:RadNumericTextBox>
                                        </td>
                                    </tr>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
                <telerik:RadMultiPage ID="Rm_Kra_Details" runat="server" SelectedIndex="0" meta:resourcekey="Rm_Kra_DetailsResource1">
                    <telerik:RadPageView ID="Rp_Kra_Child" runat="server" meta:resourcekey="Rp_Kra_ChildResource1"
                        Visible="true" Selected="True">
                        <table align="left">
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_ApproverComments" runat="server" Style="font-weight: 700; font-size: small; font-family: Arial, Helvetica, sans-serif"
                                        meta:resourcekey="lbl_ApproverCommentsResource1"
                                        Text="Approver Comments"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_ApproverComments" runat="server" Height="77px" TextMode="MultiLine"
                                        Width="500px" meta:resourcekey="txt_ApproverCommentsResource1"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_txt_ApproverComments" runat="server" ControlToValidate="txt_ApproverComments"
                                        ErrorMessage="Comments Cannot Be Empty" ValidationGroup="Controls1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_FinalRating" runat="server" Style="font-weight: 700; font-size: small; font-family: Arial, Helvetica, sans-serif"
                                        meta:resourcekey="lbl_FinalRatingResource1"
                                        Text="Final Rating"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="rnt_FinalRating" runat="server" LabelCssClass="" meta:resourcekey="rnt_FinalRatingResource1"
                                        MaxLength="1">
                                        <NumberFormat DecimalDigits="0" />
                                    </telerik:RadNumericTextBox>
                                </td>
                            </tr>
                            <tr align="center">
                                <td>
                                    <asp:Button ID="btn_ApproverSubmit" runat="server" Text="Submit" OnClick="btn_ApproverSubmit_Click"
                                        meta:resourcekey="btn_ApproverSubmitResource1" ValidationGroup="Controls1" Visible="false" />
                                    &nbsp; &nbsp;
                                    <asp:Button ID="btn_ApproverCancel" runat="server" Text="Cancel" meta:resourcekey="btn_ApproverCancelResource1"
                                        OnClick="btn_ApproverCancel_Click1" Visible="false" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lnk_Idp" runat="server" Text="+ ViewIDP" Visible="false"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lnk_Task" runat="server" Text="+ ViewTask" Visible="false"></asp:LinkButton>
                                </td>
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="LABELSS"
                                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="Controls1" meta:resourcekey="vs_AppraisalDiscussionResource1" />
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
                <telerik:RadMultiPage ID="Rm_AppraisalDiscussion" runat="server" SelectedIndex="0"
                    meta:resourcekey="Rm_AppraisalDiscussionResource1">
                    <telerik:RadPageView ID="RP_AppraisalDiscussion_ViewDetails" runat="server" meta:resourcekey="RP_AppraisalDiscussion_ViewDetailsResource1"
                        Selected="True">
                        <table align="center" width="30%">
                            <tr>
                                <td colspan="3" align="center"></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_App_Discussion_Id" runat="server" Visible="False" meta:resourcekey="lbl_App_Discussion_IdResource1"></asp:Label>
                                </td>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_DateofDiscussion" runat="server" Text="Date of Discussion" CssClass="LABELSS"
                                            meta:resourcekey="lbl_DateofDiscussionResource1"></asp:Label>
                                    </td>
                                    <td>
                                        <b>:</b>
                                    </td>
                                    <td align="left">
                                        <telerik:RadDatePicker ID="rdtp_DateofDiscussion" runat="server"
                                            meta:resourcekey="rdtp_DateofDiscussionResource1" Enabled="False">
                                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                                ViewSelectorText="x">
                                            </Calendar>
                                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                            <DateInput DateFormat="M/d/yyyy" DisplayDateFormat="M/d/yyyy">
                                            </DateInput>
                                        </telerik:RadDatePicker>
                                        <asp:RequiredFieldValidator ID="rfv_rdtp_DateofDiscussion" runat="server" ControlToValidate="rdtp_DateofDiscussion"
                                            ErrorMessage="Please Enter Date of Discussion" ValidationGroup="Controls"
                                            meta:resourcekey="rfv_rdtp_DateofDiscussionResource1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_EmployeeComments" runat="server" CssClass="LABELSS" Text="Employee&nbsp;Comments"
                                            meta:resourcekey="lbl_EmployeeCommentsResource1"></asp:Label>
                                    </td>
                                    <td>
                                        <b>:</b>
                                    </td>
                                    <td>
                                        <telerik:RadTextBox ID="rtxt_EmployeeCommentsAppDiscussion" runat="server"
                                            TextMode="MultiLine" LabelCssClass="">
                                        </telerik:RadTextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfv_rtxt_EmployeeCommentsAppDiscussion" runat="server" ControlToValidate="rtxt_EmployeeCommentsAppDiscussion"
                                            ErrorMessage="Please Enter Employee Comments" ValidationGroup="Controls11">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_MgrCommentsAppDiscussion" runat="server" Text="Manager Comments"></asp:Label>
                                    </td>
                                    <td>
                                        <b>:</b>
                                    </td>
                                    <td>
                                        <telerik:RadTextBox ID="rtxt_MgrCommentsAppDiscussion" runat="server"
                                            TextMode="MultiLine" LabelCssClass="">
                                        </telerik:RadTextBox>
                                    </td>
                                    <td>

                                        <asp:RequiredFieldValidator ID="rfv_rtxt_MgrCommentsAppDiscussion" runat="server" ControlToValidate="rtxt_MgrCommentsAppDiscussion"
                                            ErrorMessage="Please Enter Manager Comments" ValidationGroup="Controls11">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <%--  <tr>
                                <td>
                                Rejected :
                                
                                </td>
                                <td>
                                <asp:CheckBox ID="chk_reject" runat="server" />
                                </td>
                                </tr>--%>
                                <tr>
                                    <td align="center" colspan="3">
                                        <asp:Button ID="btn_Save" runat="server" CssClass="LABELSS" meta:resourcekey="btn_Save"
                                            Text="Save" ValidationGroup="Controls11" OnClick="btn_Save_Click" />
                                        <asp:Button ID="btn_Cancel" runat="server" CssClass="LABELSS" meta:resourcekey="btn_Cancel"
                                            Text="Cancel" Visible="False" OnClick="btn_Cancel_Click" />
                                        <asp:ValidationSummary ID="vs_AppraisalDiscussion" runat="server" CssClass="LABELSS"
                                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="Controls11" />
                                    </td>
                                </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>