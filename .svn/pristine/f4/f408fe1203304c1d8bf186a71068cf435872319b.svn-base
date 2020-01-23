<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_PmsApproverAppraisal.aspx.cs" Inherits="PMS_frm_PmsApproverAppraisal"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

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
        Width="1000px" meta:resourcekey="Rw_TaskResource1">
        <Windows>
            <telerik:RadWindow ID="RadWindow1" Skin="WebBlue" Modal="true" runat="server" Width="1000px"
                Height="400px" Title="Task Details" VisibleStatusbar="false" ReloadOnShow="true"
                Behaviors="Maximize" InitialBehaviors="Maximize" AutoSize="true" KeepInScreenBounds="true"
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
                        meta:resourcekey="Rp_Appraisal_VIEWDETAILSResource1">
                        <center>
                            <b>Approver Appraisal</b></center>
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
                                    <asp:Label ID="lbl_Employee" runat="server" Text="Employee" meta:resourcekey="lbl_EmployeeResource1"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="rcmb_EmployeeType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rcmb_EmployeeType_SelectedIndexChanged"
                                        Width="200px" MarkFirstMatch="true" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_EmployeeType" ControlToValidate="rcmb_EmployeeType"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please Select Employee"
                                        InitialValue="Select" meta:resourcekey="rfv_rcmb_EmployeeTypeResource1">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_RpMgr" runat="server" Text="Reporting Manager" meta:resourcekey="lbl_RpMgrResource1"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadTextBox ID="rtxt_RpMgr" runat="server" MaxLength="40"
                                        meta:resourcekey="rtxt_RpMgrResource1">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Role" runat="server" meta:resourcekey="lbl_RoleResource1" Text="Role"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadTextBox ID="rtxt_Role" runat="server" MaxLength="40"
                                        meta:resourcekey="rtxt_RoleResource1">
                                    </telerik:RadTextBox>
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
                                        meta:resourcekey="rtxt_GpMgrResource1">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LBL_AppraisalCycle" runat="server" Text="Appraisal Cycle"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadTextBox ID="rtxt_AppraisalCycle" runat="server" MaxLength="40">
                                    </telerik:RadTextBox>
                                </td>
                                <td></td>
                                <td align="left">
                                    <asp:Label ID="lbl_Project" runat="server" meta:resourcekey="lbl_ProjectResource1"
                                        Text="Project"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_Project" runat="server"
                                        MaxLength="40" meta:resourcekey="rtxt_ProjectResource1">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <asp:ValidationSummary ID="ValidationSummary2" runat="server"
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
                                <td align="center">
                                    <asp:Label ID="lblgoal" runat="server" Text="Goal Detalis"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="Rg_Appraisal_Goal" runat="server" AutoGenerateColumns="False" ShowHeader="False"
                                        Width="100%" meta:resourcekey="Rg_Appraisal_GoalResource1" OnRowCommand="Rg_Appraisal_Goal_RowCommand">
                                        <Columns>
                                            <asp:TemplateField meta:resourcekey="TemplateFieldResource2">
                                                <ItemTemplate>
                                                    <table align="center" width="100%">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_Goal_Id" runat="server" Text='<%# Eval("GSDTL_ID") %>' Visible="False"
                                                                    meta:resourcekey="lbl_Goal_IdResource1"></asp:Label>
                                                            </td>
                                                            <td></td>
                                                            <td></td>

                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <b>Name &nbsp:</b>
                                                                <asp:Label ID="lbl_GoalName" runat="server" Text='<%# Eval("GSDTL_NAME") %>' meta:resourcekey="lbl_GoalNameResource1"></asp:Label>
                                                            </td>
                                                            <td class="style1">&nbsp;
                                                            </td>

                                                            <td class="style4">
                                                                <b>Target Achieved</b>
                                                            </td>
                                                            <td class="style4">:
                                                            </td>
                                                            <td class="style3">
                                                                <telerik:RadRating ID="ratingPie" runat="server" ItemHeight="20px" ItemWidth="20px"
                                                                    SelectionMode="Single">
                                                                    <Items>
                                                                        <telerik:RadRatingItem ToolTip="0%" Value="1" HoveredSelectedImageUrl="../Images/6.gif"
                                                                            HoveredImageUrl="../Images/6.gif" SelectedImageUrl="../Images/6.gif" ImageUrl="../Images/1.gif" />
                                                                        <telerik:RadRatingItem ToolTip="25%" Value="2" HoveredSelectedImageUrl="../Images/7.gif"
                                                                            HoveredImageUrl="../Images/7.gif" ImageUrl="../Images/2.gif" SelectedImageUrl="../Images/7.gif" />
                                                                        <telerik:RadRatingItem ToolTip="50%" Value="3" HoveredSelectedImageUrl="../Images/8.gif"
                                                                            HoveredImageUrl="../Images/8.gif" ImageUrl="../Images/3.gif" SelectedImageUrl="../Images/8.gif" />
                                                                        <telerik:RadRatingItem ToolTip="75%" Value="4" HoveredSelectedImageUrl="../Images/9.gif"
                                                                            HoveredImageUrl="../Images/9.gif" ImageUrl="../Images/4.gif" SelectedImageUrl="../Images/9.gif" />
                                                                        <telerik:RadRatingItem ToolTip="100%" Value="5" HoveredSelectedImageUrl="../Images/10.gif"
                                                                            HoveredImageUrl="../Images/10.gif" ImageUrl="../Images/5.gif" SelectedImageUrl="../Images/10.gif" />
                                                                    </Items>
                                                                </telerik:RadRating>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <%-- <td>
                                                                <b>Measure &nbsp:</b>
                                                                <asp:Label ID="lbl_GoalMeasure" runat="server" Text='<%# Eval("GSDTL_MEASURE") %>'
                                                                    meta:resourcekey="lbl_GoalMeasureResource1"></asp:Label>
                                                            </td>--%>
                                                            <td>
                                                                <b>Weightage &nbsp;:<asp:Label ID="lbl_GoalWeightage" runat="server" meta:resourcekey="lbl_GoalWeightageResource1"
                                                                    Text='<%# Eval("GSDTL_WEIGHTAGE") %>'></asp:Label>
                                                                </b>
                                                            </td>
                                                            <td class="style1">&nbsp;
                                                            </td>


                                                            <td class="style4">
                                                                <b>Target</b>
                                                            </td>
                                                            <td class="style4">:
                                                            </td>
                                                            <td class="style3">
                                                                <asp:Label ID="lbl_target" runat="server" Text='<%# Eval("GSDTL_TARGET") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:LinkButton ID="lnk_GoalEmployeeFeedback" runat="server" CommandArgument="<%# Container.DisplayIndex %>"
                                                                    CommandName="GoalEmployee_Feed" Style="font-weight: 700; font-size: small; font-family: Arial, Helvetica, sans-serif"
                                                                    Text="+&amp;nbsp;Employee&amp;nbsp;Comments"></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="5">
                                                                <asp:TextBox ID="txt_GoalEmployeeFeedback" runat="server" Height="46px" TextMode="MultiLine"
                                                                    Visible="False" Width="500px" meta:resourcekey="txt_GoalEmployeeFeedbackResource1"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:LinkButton ID="lnk_GoalManagerFeedback" runat="server" CommandArgument="<%# Container.DisplayIndex %>"
                                                                    CommandName="GoalMgr_Feed" Style="font-weight: 700; font-size: small; font-family: Arial, Helvetica, sans-serif"
                                                                    Text="+&amp;nbsp;Manager&amp;nbsp;Feedback"></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="5">
                                                                <asp:TextBox ID="txt_GoalManagerFeedback" runat="server" Height="44px" TextMode="MultiLine"
                                                                    Visible="False" Width="500px" meta:resourcekey="txt_GoalManagerFeedbackResource1"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="5">
                                                                <telerik:RadRating ID="rdrtg_GoalMgr" runat="server" Visible="False" meta:resourcekey="rdrtg_GoalMgrResource1" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Button ID="btn_GoalMgrSubmit" runat="server" CommandArgument="<%# Container.DisplayIndex %>"
                                                                    CommandName="btn_GoalMgrSubmit" Text="Submit" Visible="False" meta:resourcekey="btn_GoalMgrSubmitResource1" />
                                                                <asp:Button ID="btn_GoalMgrCancel" runat="server" CommandArgument="<%# Container.DisplayIndex %>"
                                                                    CommandName="btn_GoalMgrCancel" Text="Cancel" Visible="False" meta:resourcekey="btn_GoalMgrCancelResource1" />
                                                            </td>
                                                            <td class="style1"></td>
                                                            <td></td>
                                                            <td></td>
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
                                    <asp:Label ID="lbl_GoalAvgRtg" runat="server" meta:resourcekey="lbl_GoalAvgRtgResource1"
                                        Style="font-weight: 700; font-size: small; font-family: Arial, Helvetica, sans-serif"
                                        Text="Average Rating"></asp:Label>
                                    &nbsp;<telerik:RadNumericTextBox ID="rnt_GoalAvgrtg" runat="server" LabelCssClass=""
                                        meta:resourcekey="rnt_FinalRatingResource1" Enabled="false">
                                        <NumberFormat DecimalDigits="2" />
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
                                <td align="center">
                                    <asp:Label ID="lblkra" runat="server" Text="KRA Detalis"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="Rg_Appraisal_Kra" runat="server" AutoGenerateColumns="False" ShowHeader="False"
                                        Width="100%" meta:resourcekey="Rg_Appraisal_KraResource1" OnRowCommand="Rg_Appraisal_Kra_Command">
                                        <Columns>
                                            <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
                                                <ItemTemplate>
                                                    <table align="center" width="100%">
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
                                                                <b>Name &nbsp:</b>
                                                                <asp:Label ID="lbl_KraName" runat="server" Text='<%# Eval("KRA_NAME") %>' meta:resourcekey="lbl_KraNameResource1"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <b>Description &nbsp:</b>
                                                                <asp:Label ID="lbl_KraDescription" runat="server" Text='<%# Eval("KRA_DESC") %>'
                                                                    meta:resourcekey="lbl_KraDescriptionResource1"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>Target &nbsp:</b>
                                                                <asp:Label ID="lbl_target" runat="server" Text='<%# Eval("GS_KRA_TARGET") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <b>Weightage &nbsp:</b>
                                                                <asp:Label ID="lbl_KraWeightage" runat="server" Text='<%# Eval("KRA_WEIGHTAGE") %>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>Target Achieved &nbsp:</b>

                                                                <telerik:RadRating ID="ratingPiekra" runat="server" SelectionMode="Single" ItemHeight="20px"
                                                                    ItemWidth="20px">
                                                                    <Items>
                                                                        <telerik:RadRatingItem ToolTip="0%" Value="1" HoveredSelectedImageUrl="../Images/6.gif"
                                                                            HoveredImageUrl="../Images/6.gif" SelectedImageUrl="../Images/6.gif" ImageUrl="../Images/1.gif" />
                                                                        <telerik:RadRatingItem ToolTip="25%" Value="2" HoveredSelectedImageUrl="../Images/7.gif"
                                                                            HoveredImageUrl="../Images/7.gif" ImageUrl="../Images/2.gif" SelectedImageUrl="../Images/7.gif" />
                                                                        <telerik:RadRatingItem ToolTip="50%" Value="3" HoveredSelectedImageUrl="../Images/8.gif"
                                                                            HoveredImageUrl="../Images/8.gif" ImageUrl="../Images/3.gif" SelectedImageUrl="../Images/8.gif" />
                                                                        <telerik:RadRatingItem ToolTip="75%" Value="4" HoveredSelectedImageUrl="../Images/9.gif"
                                                                            HoveredImageUrl="../Images/9.gif" ImageUrl="../Images/4.gif" SelectedImageUrl="../Images/9.gif" />
                                                                        <telerik:RadRatingItem ToolTip="100%" Value="5" HoveredSelectedImageUrl="../Images/10.gif"
                                                                            HoveredImageUrl="../Images/10.gif" ImageUrl="../Images/5.gif" SelectedImageUrl="../Images/10.gif" />
                                                                    </Items>
                                                                </telerik:RadRating>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:LinkButton ID="lnk_KraEmployeeFeedback" runat="server" CommandArgument="<%# Container.DisplayIndex %>"
                                                                    CommandName="KraEmployee_Feed" Style="font-weight: 700; font-size: small; font-family: Arial, Helvetica, sans-serif"
                                                                    Text="+&amp;nbsp;Employee&amp;nbsp;Comments"></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txt_KraEmployeeFeedback" runat="server" Height="51px" TextMode="MultiLine"
                                                                    Visible="False" Width="500px" meta:resourcekey="txt_KraEmployeeFeedbackResource1"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:LinkButton ID="lnk_KraManagerFeedback" runat="server" CommandArgument="<%# Container.DisplayIndex %>"
                                                                    CommandName="KraMgr_Feed" Style="font-weight: 700; font-size: small; font-family: Arial, Helvetica, sans-serif"
                                                                    Text="+&amp;nbsp;Manager&amp;nbsp;Feedback"></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txt_KraManagerFeedback" runat="server" Height="49px" TextMode="MultiLine"
                                                                    Visible="False" Width="500px" meta:resourcekey="txt_KraManagerFeedbackResource1"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <telerik:RadRating ID="rdrtg_KraMgr" runat="server" Visible="False" meta:resourcekey="rdrtg_KraMgrResource1" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Button ID="btn_KraMgrSubmit" runat="server" CommandArgument="<%# Container.DisplayIndex %>"
                                                                    CommandName="btn_KraMgrSubmit" Text="Submit" Visible="False" meta:resourcekey="btn_KraMgrSubmitResource1" />
                                                                &nbsp;<asp:Button ID="btn_KraMgrCancel" runat="server" CommandArgument="<%# Container.DisplayIndex %>"
                                                                    CommandName="btn_KraMgrCancel" Text="Cancel" Visible="False" meta:resourcekey="btn_KraMgrCancelResource1" />
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
                                            &nbsp;<telerik:RadNumericTextBox ID="rnt_KraAvgrtg" runat="server" LabelCssClass=""
                                                meta:resourcekey="rnt_FinalRatingResource1" Enabled="false">
                                                <NumberFormat DecimalDigits="2" />
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
                        Selected="True">
                        <table align="left">
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_ApproverComments" runat="server" Style="font-weight: 700; font-size: small; font-family: Arial, Helvetica, sans-serif"
                                        meta:resourcekey="lbl_ApproverCommentsResource1"
                                        Text="Approver Comments"></asp:Label>
                                </td>
                                <td rowspan="4">
                                    <asp:TextBox ID="txt_ApproverComments" runat="server" Height="77px" TextMode="MultiLine"
                                        Width="500px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_txt_ApproverComments" runat="server" ControlToValidate="txt_ApproverComments"
                                        ErrorMessage="Comments Cannot Be Empty" ValidationGroup="Controls23">*</asp:RequiredFieldValidator>
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
                                <td>&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_FinalRating" runat="server" Style="font-weight: 700; font-size: small; font-family: Arial, Helvetica, sans-serif"
                                        meta:resourcekey="lbl_FinalRatingResource1"
                                        Text="Final Rating"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadRating ID="rdrtg_final" runat="server" Precision="Exact" />
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>&nbsp;
                                </td>
                                <td colspan="2">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;
                                </td>
                                <td>
                                    <asp:Button ID="btn_ApproverSubmit" runat="server"
                                        OnClick="btn_ApproverSubmit_Click" Text="Submit" ValidationGroup="Controls23" />
                                    &nbsp;<asp:Button ID="btn_ApproverCancel" runat="server" meta:resourcekey="btn_ApproverCancelResource1"
                                        OnClick="btn_ApproverCancel_Click1" Text="Cancel" />
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="LABELSS"
                                        ShowMessageBox="True" ShowSummary="False" ValidationGroup="Controls23" />
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lnk_Idp" runat="server" Text="+ ViewIDP"></asp:LinkButton>
                                </td>
                                <td>&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lnk_Task" runat="server" Text="+ ViewTask"></asp:LinkButton>
                                </td>
                                <td>&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
                <telerik:RadMultiPage ID="Rm_AppraisalDiscussion" runat="server" SelectedIndex="0"
                    meta:resourcekey="Rm_AppraisalDiscussionResource1" Width="100%">
                    <telerik:RadPageView ID="RP_AppraisalDiscussion_ViewDetails" runat="server" meta:resourcekey="RP_AppraisalDiscussion_ViewDetailsResource1"
                        Selected="True">
                        <table align="center" width="30%">
                            <tr>
                                <td colspan="3" align="center">
                                    <center>
                                        <h4>Appraisal Discussion
                                        </h4>
                                    </center>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_App_Discussion_Id" runat="server" Visible="False" meta:resourcekey="lbl_App_Discussion_IdResource1"></asp:Label>
                                </td>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_Manager" runat="server" Text="Mgr Name" meta:resourcekey="lbl_Manager"
                                            CssClass="LABELSS"></asp:Label>
                                    </td>
                                    <td>:
                                    </td>
                                    <td align="left">
                                        <telerik:RadComboBox ID="rcmb_ManagerType" runat="server" Width="200px" meta:resourcekey="rcmb_ManagerTypeResource1" MarkFirstMatch="true" Filter="Contains">
                                        </telerik:RadComboBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfv_rcmb_ManagerType" ControlToValidate="rcmb_ManagerType"
                                            runat="server" ValidationGroup="Controls" ErrorMessage="Please Select Manager"
                                            InitialValue="Select" meta:resourcekey="rfv_rcmb_ManagerTypeResource1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_DateofDiscussion" runat="server" Text="Date of Discussion" CssClass="LABELSS"
                                            meta:resourcekey="lbl_DateofDiscussionResource1"></asp:Label>
                                    </td>
                                    <td>:
                                    </td>
                                    <td align="left">
                                        <telerik:RadDatePicker ID="rdtp_DateofDiscussion" runat="server" meta:resourcekey="rdtp_DateofDiscussionResource1">
                                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                            </Calendar>
                                            <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelCssClass=""
                                                Width="">
                                            </DateInput>
                                            <DatePopupButton CssClass="" HoverImageUrl="" ImageUrl="" />
                                        </telerik:RadDatePicker>
                                        <asp:RequiredFieldValidator ID="rfv_rdtp_DateofDiscussion" runat="server" ControlToValidate="rdtp_DateofDiscussion"
                                            ErrorMessage="Please Enter Date of Discussion" ValidationGroup="Controls" meta:resourcekey="rfv_rdtp_DateofDiscussionResource1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_EmployeeComments" runat="server" CssClass="LABELSS" Text="Employee Comments"
                                            meta:resourcekey="lbl_EmployeeCommentsResource1"></asp:Label>
                                    </td>
                                    <td>:
                                    </td>
                                    <td>
                                        <telerik:RadTextBox ID="rtxt_EmployeeCommentsAppDiscussion" runat="server"
                                            TextMode="MultiLine" LabelCssClass="" meta:resourcekey="rtxt_EmployeeCommentsAppDiscussionResource1">
                                        </telerik:RadTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_MgrCommentsAppDiscussion" runat="server" CssClass="LABELSS" Text="Mgr Comments"
                                            meta:resourcekey="lbl_MgrCommentsAppDiscussionResource1"></asp:Label>
                                    </td>
                                    <td>:
                                    </td>
                                    <td>
                                        <telerik:RadTextBox ID="rtxt_MgrCommentsAppDiscussion" runat="server"
                                            TextMode="MultiLine" LabelCssClass="" meta:resourcekey="rtxt_MgrCommentsAppDiscussionResource1">
                                        </telerik:RadTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="3">
                                        <asp:Button ID="btn_Save" runat="server" CssClass="LABELSS" meta:resourcekey="btn_Save"
                                            Text="Save" ValidationGroup="Controls" />
                                        <asp:Button ID="btn_Cancel" runat="server" CssClass="LABELSS" meta:resourcekey="btn_Cancel"
                                            Text="Cancel" Visible="False" />
                                        <asp:ValidationSummary ID="vs_AppraisalDiscussion" runat="server" CssClass="LABELSS"
                                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="Controls" meta:resourcekey="vs_AppraisalDiscussionResource1" />
                                    </td>
                                </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>