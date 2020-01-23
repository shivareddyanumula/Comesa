<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_PmsAppraisal.aspx.cs" Inherits="PMS_frm_PmsApp" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .style2 {
            width: 43px;
        }

        .style3 {
            width: 8px;
        }

        .style5 {
            height: 15px;
            width: 62px;
        }

        .style7 {
            height: 15px;
            width: 115px;
        }

        .style8 {
        }

        .style9 {
        }

        .style10 {
            width: 62px;
        }

        .style12 {
            width: 108px;
        }

        .style13 {
        }

        .style14 {
            width: 38px;
        }
    </style>
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
        AnimationDuration="300" Behaviors="Close" AutoSize="true"
        Height="400px" Width="400px">
        <Windows>
            <telerik:RadWindow ID="RW_IDP" Skin="WebBlue" Modal="true" runat="server" Width="400px"
                Height="400px" Title="IDP" AutoSize="true" VisibleStatusbar="false" ReloadOnShow="true"
                Behaviors="Close" KeepInScreenBounds="true" ShowContentDuringLoad="true">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <telerik:RadWindowManager ID="Rw_Task" runat="server" Skin="WebBlue" Animation="Slide"
        AnimationDuration="300" Behaviors="Close">
        <Windows>
            <telerik:RadWindow ID="RadWindow1" Skin="WebBlue" Modal="true" runat="server" Width="400px"
                Height="400px" Title="Task Details" VisibleStatusbar="false" ReloadOnShow="true"
                Behaviors="Close" InitialBehaviors="Maximize" AutoSize="true" KeepInScreenBounds="true"
                ShowContentDuringLoad="true">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <telerik:RadFormDecorator ID="RadFormDec1" runat="server" DecoratedControls="GridFormDetailsViews"
        EnableRoundedCorners="true" />
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_Appr" runat="server" Text="Appraisal" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table align="center">
                    <tr>
                        <td>
                            <telerik:RadMultiPage ID="Rm_Appraisal_PAGE" runat="server" SelectedIndex="0" ScrollBars="Auto"
                                meta:resourcekey="Rm_Appraisal_PAGEResource1">
                                <telerik:RadPageView ID="Rp_Appraisal_VIEWDETAILS" runat="server" Selected="True"
                                    meta:resourcekey="Rp_Appraisal_VIEWDETAILSResource1">
                                    <asp:Label ID="lbl_BusinessUnitName" runat="server" Visible="false">
                                    </asp:Label>
                                    <table align="center">
                                        <tr>
                                            <td colspan="3" align="center"></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_appraisal_Id" runat="server" Visible="False" meta:resourcekey="lbl_Feedback_IdResource1"></asp:Label>
                                            </td>
                                            <td></td>
                                            <td>
                                                <telerik:RadComboBox ID="rcmb_BusinessUnitType" runat="server" AutoPostBack="True" MarkFirstMatch="true"
                                                    OnSelectedIndexChanged="rcmb_BusinessUnitType_SelectedIndexChanged" Width="200px"
                                                    meta:resourcekey="rcmb_BusinessUnitTypeResource1" Filter="Contains">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfv_rcmb_BusinessUnitType" ControlToValidate="rcmb_BusinessUnitType" MarkFirstMatch="true"
                                                    runat="server" ValidationGroup="Controls5" ErrorMessage="Please Select BusinessUnit"
                                                    InitialValue="Select" meta:resourcekey="rfv_rcmb_BusinessUnitTypeResource1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_Employee" runat="server" Text="Employee"></asp:Label>
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
                                                    runat="server" ValidationGroup="Controls5" ErrorMessage="Please Select Employee"
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
                                                <asp:Label ID="lbl_Role" runat="server" Text="Role"></asp:Label>
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
                                                <asp:Label ID="lbl_givefeedback" runat="server" Text="Please Give Feedback"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td align="left">
                                                <telerik:RadComboBox ID="rcmb_feedback" runat="server" AutoPostBack="True"
                                                    meta:resourcekey="rcmb_feedbackResource1"
                                                    OnSelectedIndexChanged="rcmb_feedback_indexchanged" Width="200px" MarkFirstMatch="true">
                                                    <Items>
                                                        <telerik:RadComboBoxItem runat="server"
                                                            meta:resourcekey="RadComboBoxItemResource1" Text="Select" Value="0" />
                                                        <telerik:RadComboBoxItem runat="server"
                                                            meta:resourcekey="RadComboBoxItemResource2" Text="GOAL" Value="1" />
                                                        <telerik:RadComboBoxItem runat="server"
                                                            meta:resourcekey="RadComboBoxItemResource3" Text="KRA" Value="2" />
                                                    </Items>
                                                </telerik:RadComboBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfv_rcmb_feedback" ControlToValidate="rcmb_feedback"
                                                    runat="server" ValidationGroup="Controls5" ErrorMessage="Please Give Feedback"
                                                    InitialValue="Select" meta:resourcekey="rfv_rcmb_feedbackResource1">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_Project" runat="server" Text="Project"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="rtxt_Project" runat="server" MaxLength="40"
                                                    meta:resourcekey="rtxt_ProjectResource1">
                                                </telerik:RadTextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_Apprais_id" runat="server" Text="Appraisal Cycle" Visible="false"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_Appraisal_Date" runat="server" Text="Appraisal Date"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td>
                                                <telerik:RadDatePicker ID="rdtp_DATEofAppraisal" runat="server">
                                                </telerik:RadDatePicker>
                                            </td>
                                            <td></td>
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
                                        </tr>
                                        <tr>
                                            <asp:Label ID="lbl_final" Visible="false" runat="server"></asp:Label>
                                        </tr>
                                        <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="Controls5" meta:resourcekey="vs_AppraisalDiscussionResource1" />
                                    </table>
                                </telerik:RadPageView>
                            </telerik:RadMultiPage>
                            <telerik:RadMultiPage ID="Rm_Appraisal_Goal" runat="server" SelectedIndex="0" ScrollBars="Auto"
                                Width="100%" meta:resourcekey="Rm_Appraisal_GoalResource1">
                                <telerik:RadPageView ID="Rp_Appraisal_Goal_VIEWMAIN" runat="server" Selected="True"
                                    meta:resourcekey="Rp_Appraisal_Goal_VIEWMAINResource1">
                                    <table align="left" width="500px">
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
                                                    Width="100%" meta:resourcekey="Rg_Appraisal_GoalResource1" PageIndex="5" OnRowCommand="Rg_Appraisal_Goal_RowCommand">
                                                    <Columns>
                                                        <asp:TemplateField meta:resourcekey="TemplateFieldResource2">
                                                            <ItemTemplate>
                                                                <table width="600px">
                                                                    <tr>
                                                                        <td class="style7">
                                                                            <asp:Label ID="lbl_Goal_Id" runat="server" Text='<%# Eval("GSDTL_ID") %>' Visible="False"
                                                                                meta:resourcekey="lbl_Goal_IdResource1"></asp:Label>
                                                                        </td>
                                                                        <td class="style5">&#160;</td>
                                                                    </tr>
                                                                    <%-- <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_Goal_AppraisalCycle" runat="server" Text='<%# Eval("GOAL_APPRAISAL_CYCLE") %>'
                                                                    Visible="False" meta:resourcekey="lbl_Goal_AppraisalCycleResource1"></asp:Label>
                                                            </td>
                                                        </tr>--%>
                                                                    <tr>
                                                                        <td class="style9">
                                                                            <%-- <b>Goal&nbsp;Name &nbsp:</b>--%>
                                                                            <b>Name &nbsp:</b>
                                                                        </td>
                                                                        <td class="style10">
                                                                            <asp:Label ID="lbl_GoalName" runat="server"
                                                                                meta:resourcekey="lbl_GoalNameResource1" Text='<%# Eval("GSDTL_NAME") %>'></asp:Label>
                                                                        </td>
                                                                        <td class="style12">
                                                                            <b>Timelines :</b></td>


                                                                        <td class="style12">
                                                                            <asp:Label ID="lbl_timelines" runat="server"
                                                                                Text='<%# Eval("GSDTL_TIMELINES") %>'></asp:Label>
                                                                        </td>
                                                                        <td>&#160;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        </td>
                                                                        <td class="style9">
                                                                            <b>Measure &#160;:</b>&nbsp;</td>
                                                                        <%--<td>
                                                                            <b>Date &nbsp:</b>
                                                                            <asp:Label ID="lbl_GoalDate" runat="server" Text='<%# Eval("GSDTL_DATE") %>' meta:resourcekey="lbl_GoalDateResource1"></asp:Label>
                                                                        </td>--%>
                                                                        <td class="style10">
                                                                            <asp:Label ID="lbl_GoalMeasure" runat="server"
                                                                                meta:resourcekey="lbl_GoalMeasureResource1" Text='<%# Eval("GSDTL_MEASURE") %>'></asp:Label>
                                                                        </td>
                                                                        <td class="style12">&#160;<b>Target &#160;:</b>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lbl_target" runat="server" Text='<%# Eval("GSDTL_TARGET") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="style9">
                                                                            <b>Weightage &#160;:</b></td>
                                                                        <td class="style10">
                                                                            <asp:Label ID="lbl_GoalWeightage" runat="server"
                                                                                meta:resourcekey="lbl_GoalWeightageResource1"
                                                                                Text='<%# Eval("GSDTL_WEIGHTAGE") %>'></asp:Label>
                                                                        </td>
                                                                        <td class="style12">
                                                                            <b>Target Achieved &#160;:</b>
                                                                            <%--<asp:Label ID="lbl_Goaltargetach" runat="server" Text='<%# Eval("GSDTL_TARGET_ACHEIVED") %>'></asp:Label>--%>&#160;
                                                                        </td>
                                                                        <td>
                                                                            <telerik:RadRating ID="ratingPie" runat="server" ItemHeight="20px"
                                                                                ItemWidth="20px" SelectionMode="Single" Width="136px" Height="32px">
                                                                                <Items>
                                                                                    <telerik:RadRatingItem HoveredImageUrl="../Images/Pie/1h.png"
                                                                                        HoveredSelectedImageUrl="../Images/Pie/1h.png" ImageUrl="../Images/Pie/1.png"
                                                                                        SelectedImageUrl="../Images/Pie/1s.png" ToolTip="0%" Value="1" />
                                                                                    <telerik:RadRatingItem HoveredImageUrl="../Images/Pie/2h.png"
                                                                                        HoveredSelectedImageUrl="../Images/Pie/2h.png" ImageUrl="../Images/Pie/2.png"
                                                                                        SelectedImageUrl="../Images/Pie/2s.png" ToolTip="25%" Value="2" />
                                                                                    <telerik:RadRatingItem HoveredImageUrl="../Images/Pie/3h.png"
                                                                                        HoveredSelectedImageUrl="../Images/Pie/3h.png" ImageUrl="../Images/Pie/3.png"
                                                                                        SelectedImageUrl="../Images/Pie/3s.png" ToolTip="50%" Value="3" />
                                                                                    <telerik:RadRatingItem HoveredImageUrl="../Images/Pie/4h.png"
                                                                                        HoveredSelectedImageUrl="../Images/Pie/4h.png" ImageUrl="../Images/Pie/4.png"
                                                                                        SelectedImageUrl="../Images/Pie/4s.png" ToolTip="75%" Value="4" />
                                                                                    <telerik:RadRatingItem HoveredImageUrl="../Images/Pie/5h.png"
                                                                                        HoveredSelectedImageUrl="../Images/Pie/5h.png" ImageUrl="../Images/Pie/5.png"
                                                                                        SelectedImageUrl="../Images/Pie/5s.png" ToolTip="100%" Value="5" />
                                                                                </Items>
                                                                            </telerik:RadRating>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <table>
                                                                    <tr>
                                                                        <td class="style8" colspan="2">
                                                                            <asp:LinkButton ID="lnk_GoalEmployeeFeedback" runat="server" CommandArgument="<%# Container.DisplayIndex %>"
                                                                                CommandName="GoalEmployee_Feed" Style="font-weight: 700; font-size: small; font-family: Arial, Helvetica, sans-serif"
                                                                                Text="+ Employee Comments"></asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="style9">&#160;</td>
                                                                        <td class="style10">&#160;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <asp:TextBox ID="txt_GoalEmployeeFeedback" runat="server" Height="77px" TextMode="MultiLine"
                                                                                Visible="False" Width="500px" meta:resourcekey="txt_GoalEmployeeFeedbackResource1" MaxLength="4000"></asp:TextBox>
                                                                            <%--<asp:RequiredFieldValidator ID="rfv_txt_GoalEmployeeFeedback" runat="server" ControlToValidate="txt_GoalEmployeeFeedback"
                                                                    ErrorMessage="Comments Cannot Be Empty" ValidationGroup="Controls3">*</asp:RequiredFieldValidator>--%>
                                                                        </td>
                                                                        <%-- <td>
                                                                            &nbsp;
                                                                        </td>--%>
                                                                        <td>&#160;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="style9" colspan="2">
                                                                            <asp:Button ID="btn_GoalEmpSubmit" runat="server" CommandArgument="<%# Container.DisplayIndex %>"
                                                                                CommandName="btn_GoalEmpSubmit" Text="Submit" Visible="False"
                                                                                meta:resourcekey="btn_GoalEmpSubmitResource1"
                                                                                OnClick="btn_GoalEmpSubmit_Click" />
                                                                            <asp:Button ID="btn_GoalEmpUpdate" runat="server" CommandArgument="<%# Container.DisplayIndex %>"
                                                                                CommandName="btn_GoalEmpUpdate" Text="Update" Visible="False" />
                                                                            <asp:Button ID="btn_GoalEmpCancel" runat="server" CommandArgument="<%# Container.DisplayIndex %>"
                                                                                CommandName="btn_GoalEmpCancel" Text="Cancel" Visible="False" meta:resourcekey="btn_GoalEmpCancelResource1" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <%--<asp:ValidationSummary ID="ValidationSummary2" runat="server" CssClass="LABELSS"
                                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="Controls3" meta:resourcekey="vs_AppraisalDiscussionResource1" />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:Button ID="btn_finalise" runat="server" Text="Finalise" Visible="false" OnClick="btn_finalise_Click1" />
                                            </td>
                                        </tr>
                                    </table>
                                </telerik:RadPageView>
                            </telerik:RadMultiPage>
                            <telerik:RadMultiPage ID="Rm_Appraisal_Kra" runat="server" SelectedIndex="0" ScrollBars="Auto"
                                Width="100%" meta:resourcekey="Rm_Appraisal_KraResource1">
                                <telerik:RadPageView ID="Rp_Appraisal_Kra_VIEWMAIN" runat="server" Selected="True"
                                    meta:resourcekey="Rp_Appraisal_Kra_VIEWMAINResource1">
                                    <table align="left" width="80%">
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
                                                    Width="100%" meta:resourcekey="Rg_Appraisal_KraResource1" PageIndex="5" OnRowCommand="Rg_Appraisal_Kra_Command">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <table width="600px">
                                                                    <tr>
                                                                        <td class="style13">
                                                                            <asp:Label ID="lbl_Kra_Id" runat="server" Text='<%# Eval("KRA_ID") %>' Visible="False"
                                                                                meta:resourcekey="lbl_Kra_IdResource1"></asp:Label>
                                                                        </td>
                                                                        <td class="style13">
                                                                            <asp:Label ID="lbl_Kra_AppraisalCycle" runat="server" Text='<%# Eval("GS_APPRAISAL_CYCLE") %>'
                                                                                Visible="False" meta:resourcekey="lbl_Kra_AppraisalCycleResource1"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="style13">
                                                                            <b>Name &nbsp:</b>
                                                                        </td>
                                                                        <td class="style3">
                                                                            <asp:Label ID="lbl_KraName" runat="server"
                                                                                meta:resourcekey="lbl_KraNameResource1" Text='<%# Eval("KRA_NAME") %>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <b>Timelines &nbsp:</b>
                                                                        </td>
                                                                        <td class="style14">
                                                                            <asp:Label ID="lbl_timelines" runat="server" Text='<%# Eval("GS_KRA_TIMELINES") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="style13">
                                                                            <b>Description &nbsp:</b>
                                                                        </td>
                                                                        <td class="style3">
                                                                            <asp:Label ID="lbl_KraDescription" runat="server"
                                                                                meta:resourcekey="lbl_KraDescriptionResource1" Text='<%# Eval("KRA_DESC") %>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <b>Target &nbsp:</b>
                                                                        </td>
                                                                        <td class="style14">
                                                                            <asp:Label ID="lbl_target" runat="server" Text='<%# Eval("GS_KRA_TARGET") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="style13">
                                                                            <b>Weightage &nbsp:</b>
                                                                        </td>
                                                                        <td class="style3">
                                                                            <asp:Label ID="lbl_KrawEIGHTAGE" runat="server"
                                                                                Text='<%# Eval("KRA_WEIGHTAGE") %>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <b>Target Achieved &#160;:</b>
                                                                            <%-- <asp:Label ID="lbl_targetachiev" runat="server" Text='<%# Eval("GS_KRA_TARGET_ACHEIVED") %>'></asp:Label>--%>
                                                                        </td>

                                                                        <td class="style14">
                                                                            <telerik:RadRating ID="ratingPiekra" runat="server" Height="20px"
                                                                                ItemHeight="20px" ItemWidth="20px" SelectionMode="Single" Width="200px">
                                                                                <Items>
                                                                                    <telerik:RadRatingItem HoveredImageUrl="../Images/Pie/1h.png"
                                                                                        HoveredSelectedImageUrl="../Images/Pie/1h.png" ImageUrl="../Images/Pie/1.png"
                                                                                        SelectedImageUrl="../Images/Pie/1s.png" ToolTip="0%" Value="1" />
                                                                                    <telerik:RadRatingItem HoveredImageUrl="../Images/Pie/2h.png"
                                                                                        HoveredSelectedImageUrl="../Images/Pie/2h.png" ImageUrl="../Images/Pie/2.png"
                                                                                        SelectedImageUrl="../Images/Pie/2s.png" ToolTip="25%" Value="2" />
                                                                                    <telerik:RadRatingItem HoveredImageUrl="../Images/Pie/3h.png"
                                                                                        HoveredSelectedImageUrl="../Images/Pie/3h.png" ImageUrl="../Images/Pie/3.png"
                                                                                        SelectedImageUrl="../Images/Pie/3s.png" ToolTip="50%" Value="3" />
                                                                                    <telerik:RadRatingItem HoveredImageUrl="../Images/Pie/4h.png"
                                                                                        HoveredSelectedImageUrl="../Images/Pie/4h.png" ImageUrl="../Images/Pie/4.png"
                                                                                        SelectedImageUrl="../Images/Pie/4s.png" ToolTip="75%" Value="4" />
                                                                                    <telerik:RadRatingItem HoveredImageUrl="../Images/Pie/5h.png"
                                                                                        HoveredSelectedImageUrl="../Images/Pie/5h.png" ImageUrl="../Images/Pie/5.png"
                                                                                        SelectedImageUrl="../Images/Pie/5s.png" ToolTip="100%" Value="5" />
                                                                                </Items>
                                                                            </telerik:RadRating>
                                                                        </td>

                                                                    </tr>
                                                                </table>
                                                                <table>
                                                                    <tr>
                                                                        <td class="style13" colspan="2">
                                                                            <asp:LinkButton ID="lnk_KraEmployeeFeedback" runat="server" CommandArgument="<%# Container.DisplayIndex %>"
                                                                                CommandName="KraEmployee_Feed" Style="font-weight: 700; font-size: small; font-family: Arial, Helvetica, sans-serif"
                                                                                Text="+ Employee Comments"></asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="3">
                                                                            <asp:TextBox ID="txt_KraEmployeeFeedback" runat="server" Height="77px" TextMode="MultiLine"
                                                                                Visible="False" Width="500px" MaxLength="4000" meta:resourcekey="txt_KraEmployeeFeedbackResource1"></asp:TextBox>
                                                                            <%-- <asp:RequiredFieldValidator ID="rfv_txt_KraEmployeeFeedback" runat="server" ControlToValidate="txt_KraEmployeeFeedback"
                                                                    ErrorMessage="Comments Cannot Be Empty" ValidationGroup="Controls2">*</asp:RequiredFieldValidator>--%>
                                                                        </td>
                                                                        <td class="style14">&#160;</td>
                                                                        <td>&nbsp;
                                                                        </td>
                                                                        <td>&nbsp;
                                                                        </td>
                                                                        <td>&#160;<td>
                                                                            <div>
                                                                            </div>
                                                                        </td>
                                                                            <td>&nbsp;
                                                                            </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="style13">
                                                                            <asp:Button ID="btn_KraEmpSubmit" runat="server" CommandArgument="<%# Container.DisplayIndex %>"
                                                                                CommandName="btn_KraEmpSubmit" Text="Submit" Visible="False" meta:resourcekey="btn_KraEmpSubmitResource1" />

                                                                            <asp:Button ID="btn_KraEmpUpdate" runat="server" CommandArgument="<%# Container.DisplayIndex %>"
                                                                                CommandName="btn_KraEmpUpdate" Text="Update" Visible="False" />

                                                                            <asp:Button ID="btn_KraEmpCancel" runat="server" CommandArgument="<%# Container.DisplayIndex %>"
                                                                                CommandName="btn_KraEmpCancel" Text="Cancel" Visible="False" meta:resourcekey="btn_KraEmpCancelResource1" />
                                                                        </td>
                                                                        <%--<td>
                                                                            &nbsp;
                                                                        </td>--%>
                                                                        <td class="style3">&#160;</td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <%--  <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="LABELSS"
                                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="Controls2" meta:resourcekey="vs_AppraisalDiscussionResource1" />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:Button ID="btn_KraFINALISE" runat="server" Text="Finalise" Visible="false" OnClick="btn_KraFINALISE_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </telerik:RadPageView>
                            </telerik:RadMultiPage>
                            <telerik:RadMultiPage ID="Rm_Kra_Details" runat="server" SelectedIndex="0" meta:resourcekey="Rm_Kra_DetailsResource1">
                                <telerik:RadPageView ID="Rp_Kra_Child" runat="server" meta:resourcekey="Rp_Kra_ChildResource1"
                                    Selected="True">
                                    <table align="left">
                                    </table>
                                </telerik:RadPageView>
                            </telerik:RadMultiPage>
                            <telerik:RadMultiPage ID="Rm_AppraisalDiscussion" runat="server" SelectedIndex="0"
                                meta:resourcekey="Rm_AppraisalDiscussionResource1">
                                <telerik:RadPageView ID="RP_AppraisalDiscussion_ViewDetails" runat="server" meta:resourcekey="RP_AppraisalDiscussion_ViewDetailsResource1">
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
                                                    <asp:Label ID="lbl_MgrCommentsAppDiscussion" runat="server" CssClass="LABELSS" Text="Mgr Comments"></asp:Label>
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
                                                        OnClick="btn_Save_Click" Text="Save" ValidationGroup="Controls" />
                                                    <asp:Button ID="btn_Cancel" runat="server" CssClass="LABELSS" meta:resourcekey="btn_Cancel"
                                                        OnClick="btn_Cancel_Click" Text="Cancel" Visible="false" />
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
            </td>
        </tr>
    </table>
</asp:Content>